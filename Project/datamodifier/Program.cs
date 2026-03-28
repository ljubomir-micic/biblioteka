////////////////////////////////////////////////////////////
//
//    Библиотека: Data Modification Tool
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using System.Security.Principal;
using System.Text;
using Extensions;

namespace datamodifier {
	class Program {
		public enum Eniteti {
			arhiva,
			autori,
			clanovi,
			izdavaci,
			knjige,
			korisnici
		}

		static int brojAtributa(int index) {
			if (index == 0) return 7;
			if (index == 1) return 5;
			if (index == 2) return 8;
			if (index == 3) return 5;
			if (index == 4) return 9;
			if (index == 5) return 6;
			return 0;
		}

		static string Encrypt(string rec) {
			byte[] data = System.Text.Encoding.UTF8.GetBytes(rec);
            rec = Convert.ToBase64String(data);
            return rec;
		}

		static string Decrypt(string rec) {
			byte[] data = Convert.FromBase64String(rec);
            rec = System.Text.Encoding.UTF8.GetString(data);
            return rec;
		}

		static void DodajElement(ref string[] niz, string element) {
			Array.Resize(ref niz, niz.Length + 1);
            niz[niz.Length - 1] = element;
		}

		public static void Main(string[] args) {
			Console.OutputEncoding = Encoding.UTF8;
			bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			if (!isAdmin) {
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
				startInfo.Verb = "runas";
				Process.Start(startInfo);
				return;
			}
			while (true) {
				Console.WriteHeader();
				Console.WriteLine("Изaберите ентитет:\n\t1. Архива\n\t2. Аутори\n\t3. Чланови\n\t4. Издавачи\n\t5. Књиге\n\t6. Корисници");
				unos:
				int odabir = int.Parse(Console.ReadLine().ToString());
				if (odabir > 6 || odabir < 1) goto unos;
				odabir -= 1;
				Console.WriteHeader();
				try {
					Console.WriteLine("Одабран ентитет:\t" + ((Eniteti) odabir).ToString() + "\n--------------------------");
					string lokacijaFajl = System.IO.Path.Combine(
						Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
						"Библиотека",
						((Eniteti) odabir).ToString() + ".data"
					);
					int broj = 1;
					using (System.IO.StreamReader sr = new System.IO.StreamReader(lokacijaFajl)) {
						Console.WriteLine("Одаберите објекат ентитета:");
						while (!sr.EndOfStream) {
							for (int i = 0; i < brojAtributa(odabir); i++) if (i == 1) {
								Console.WriteLine("\t" + broj + ". " + Decrypt(sr.ReadLine()));
							} else {
								sr.ReadLine();
							}
							broj++;
						}
						sr.Close();
					}
					odabirobjekta:
					int objekat = int.Parse(Console.ReadLine().ToString());
					if (objekat > broj || objekat < 1) goto odabirobjekta;
					objekat--;
					string[] podaci = new string[0];
					using (System.IO.StreamReader sr = new System.IO.StreamReader(lokacijaFajl)) {
						while (!sr.EndOfStream) {
							for (int i = 0; i < objekat; i++) for (int j = 0; j < brojAtributa(odabir); j++) {
								sr.ReadLine();
							}
							for (int i = 0; i < brojAtributa(odabir); i++) DodajElement(ref podaci, Decrypt(sr.ReadLine()));
							break;
						}
						sr.Close();
					}
					izmena:
					Console.WriteHeader();
					Console.WriteLine("Одабран објекат ентитета");
					for (int i = 0; i < podaci.Length; i++) Console.WriteLine("\t" + (i+1) + ". " + podaci[i]);
					Console.WriteLine("Одаберите број за измену атрибута [\'n\' за крај]: ");
					string a = Console.ReadLine();
					if (a == "n") goto kraj;
					else if (int.Parse(a) > podaci.Length + 1 || int.Parse(a) < 1) goto izmena;
					else {
						Console.WriteLine("Нова вредност за " + podaci[int.Parse(a) - 1] + ": ");
						podaci[int.Parse(a) - 1] = Console.ReadLine();
						string lokacijaFajl1 = System.IO.Path.Combine(
							Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
							"Библиотека",
							((Eniteti) odabir).ToString() + "1.data"
						);
						System.IO.File.Move(lokacijaFajl, lokacijaFajl1);
						using (System.IO.StreamWriter sw = new System.IO.StreamWriter(lokacijaFajl)) {
							using (System.IO.StreamReader sr = new System.IO.StreamReader(lokacijaFajl1)) {
								while (!sr.EndOfStream)	for (int i = 0; i < broj - 1; i ++) {
									for (int j = 0; j < brojAtributa(odabir); j ++) {
										if (i == objekat) {
											sr.ReadLine();
											sw.WriteLine(Encrypt(podaci[j]));
										} else sw.WriteLine(sr.ReadLine());
									}
								}
								sr.Close();
							}
							sw.Close();
						}
						System.IO.File.Delete(lokacijaFajl1);
						goto izmena;
					}
				} catch {
					Console.WriteLine("Подаци о одабраном ентитету не постоје!");
					Console.ReadKey();
					goto kraj;
				}
				kraj:
				System.Diagnostics.Debug.WriteLine("Крај");
			}
		}
	}
}