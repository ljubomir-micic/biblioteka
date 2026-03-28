////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using Newtonsoft.Json;
using CEBR = System.Int32;
using STR = System.String;
using TAC = System.Boolean;

namespace Project {
	// PODSETNIK: Nisam preterano edukovan oko menadzmenta memorije
	public static class MenadzmentPodataka {
		private static STR ekstenzija = ".data";
		public static List<Korisnik> korisnici = new List<Korisnik>();
		public static List<Autor> autori = new List<Autor>();
		public static List<Izdavac> izdavaci = new List<Izdavac>();
		public static List<Knjiga> knjige = new List<Knjiga>();
		public static List<Clan> clanovi = new List<Clan>();
		public static List<ArhivaIznajmljivanja> arhiva = new List<ArhivaIznajmljivanja>();

		public static TAC CuvaPodatkeLokalno {
			get { return Podesavanja.podesavanja["CPL"]; }
			set { Podesavanja.podesavanja["CPL"] = value; }
		}
		
		public static void OtvoriFormu() {
			if (System.IO.File.Exists(System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name, ("korisnici.data")
			))) {
				Application.Run(new Form1());
			} else {
				Application.Run(new InicijalnaPodesavanja());
			}
		}

		public static void AppDataBiblioteka() {
			if (System.IO.Directory.Exists(System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name
			))) {
				return;
			}
			
			System.IO.Directory.CreateDirectory(System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name
			));
		}

		public static List<Korisnik> korisnikPodaciUcitavanje(STR nazivFajla) {
			// Spajanje lokacije AppData foldera, Imena projekta i imena fajla
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			List<Korisnik> a = new List<Korisnik>();
			
			if (System.IO.File.Exists(lokacija)) {
				using (System.IO.StreamReader streamReader = new System.IO.StreamReader(lokacija)) {
					while (!streamReader.EndOfStream) {
						// DONE: Proveriti sintaksu i dodati da se iz .data fajla iscitaju svi podaci, konvertuju u 'Korisnik' i dodati u listu
						a.Add(new Korisnik(
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine()))	
						));
					}
					
					streamReader.Close();
				}
			}
			
			return a;
		}

		public static void korisnikPodaciCuvanje(List<Korisnik> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}
			
			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
				foreach (var korisnik in lista) {
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + korisnik.preuzmiID()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(korisnik.preuzmiIme()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(korisnik.preuzmiPrezime()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(korisnik.preuzmiKorisnickoIme()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(korisnik.preuzmiLozinku()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + korisnik.preuzmiGodinuRodjenja()));
				}
				
				streamWriter.Close();
			}
		}

		public static void korisnikPodaciCuvanjeSQL(List<Korisnik> lista, STR nazivFajla) {
			try {
				using (SqlConnection connection = new SqlConnection("Server=LJUBOMIR\\SQL;Database=Biblioteka;Trusted_Connection=True;")) {
					connection.Open();

				}
			} catch (Exception ex) {
				 System.Diagnostics.Debug.WriteLine(ex);
				MenadzmentPodataka.CuvaPodatkeLokalno = true;
				MenadzmentPodataka.korisnikPodaciCuvanje(lista, nazivFajla);
			}
		}
		
		public static void korisnikPodaciCuvanjeJSON(List<Korisnik> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + ".json")
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}
			
			// BUG: STR se manifestuje u jednom i jedinom obliku [{}]; ne cuvaju se ostali podaci
			STR jsonString = JsonConvert.SerializeObject(lista);
			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
			 	streamWriter.WriteLine(jsonString);
				
				streamWriter.Close();
			}
		}
		
		public static List<Autor> autorPodaciUcitavanje(STR nazivFajla) {
			// Spajanje lokacije AppData foldera, Imena projekta i imena fajla
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			List<Autor> a = new List<Autor>();
			
			if (System.IO.File.Exists(lokacija)) {
				using (System.IO.StreamReader streamReader = new System.IO.StreamReader(lokacija)) {
					while (!streamReader.EndOfStream) {
						// DONE: Proveriti sintaksu i dodati da se iz .data fajla iscitaju svi podaci, konvertuju u 'Autor' i dodati u listu
						a.Add(new Autor(
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine()))
						));
					}
					
					streamReader.Close();
				}
			}
			
			return a;
		}

		public static void autorPodaciCuvanje(List<Autor> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}
			
			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
				foreach (var autor in lista) {
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + autor.preuzmiID()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(autor.preuzmiIme()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(autor.preuzmiPrezime()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + autor.preuzmiGodinuRodjenja()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + autor.preuzmiGodinuSmrti()));
				}
				
				streamWriter.Close();
			}
		}

		public static void autorPodaciCuvanjeSQL(List<Autor> lista, STR nazivFajla) {
			
		}
		
		public static void autorPodaciCuvanjeJSON(List<Autor> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + ".json")
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}
			
			// BUG: STR se manifestuje u jednom i jedinom obliku [{}]; ne cuvaju se ostali podaci
			STR jsonString = JsonConvert.SerializeObject(lista);
			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
				streamWriter.WriteLine(jsonString);
				
				streamWriter.Close();
			}
		}
		
		public static List<Izdavac> izdavacPodaciUcitavanje(STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			List<Izdavac> a = new List<Izdavac>();
			
			if (System.IO.File.Exists(lokacija)) {
				using (System.IO.StreamReader streamReader = new System.IO.StreamReader(lokacija)) {
					while (!streamReader.EndOfStream) {
						// DONE: Proveriti sintaksu i dodati da se iz .data fajla iscitaju svi podaci, konvertuju u 'Izdavac' i dodati u listu
						a.Add(new Izdavac(
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine()))
						));
					}
					
					streamReader.Close();
				}
			}
			
			return a;
		}

		public static void izdavacPodaciCuvanje(List<Izdavac> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}
			
			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
				foreach (var izdavac in lista) {
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + izdavac.preuzmiID()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(izdavac.preuzmiNaziv()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + izdavac.preuzmiMBR()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + izdavac.preuzmiPIB()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + izdavac.preuzmiGodinuOsnivanja()));
				}
				
				streamWriter.Close();
			}
		}
		
		public static void izdavacPodaciCuvanjeSQL(List<Izdavac> lista, STR nazivFajla) {
			
		}
		
		public static void izdavacPodaciCuvanjeJSON(List<Izdavac> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + ".json")
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}
			
			// BUG: STR se manifestuje u jednom i jedinom obliku [{}]; ne cuvaju se ostali podaci
			STR jsonString = JsonConvert.SerializeObject(lista);
			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
				streamWriter.WriteLine(jsonString);
				
				streamWriter.Close();
			}
		}
		
		public static List<Knjiga> knjigaPodaciUcitavanje(STR nazivFajla) {
			// Spajanje lokacije AppData foldera, Imena projekta i imena fajla
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			List<Knjiga> a = new List<Knjiga>();
			
			if (System.IO.File.Exists(lokacija)) {
				using (System.IO.StreamReader streamReader = new System.IO.StreamReader(lokacija)) {
					while (!streamReader.EndOfStream) {
						// DONE: Proveriti sintaksu i dodati da se iz .data fajla iscitaju svi podaci, konvertuju u 'Knjiga' i dodati u listu
						a.Add(new Knjiga(
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							TAC.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							TAC.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine()))
						));
					}
					
					streamReader.Close();
				}
			}

			return a;
		}
		
		public static void knjigaPodaciCuvanje(List<Knjiga> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}
			
			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
				foreach (var knjiga in lista) {
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + knjiga.preuzmiID()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(knjiga.preuzmiNaziv()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + knjiga.preuzmiIDAutora()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + knjiga.preuzmiIDIzdavaca()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + knjiga.preuzmiBrojStrana()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + knjiga.preuzmiGodinuIzdavanja()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + knjiga.preuzmiUDK()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + knjiga.preuzmiStatusOmiljeno()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + knjiga.preuzmiStatusIznajmljena()));
				}
				
				streamWriter.Close();
			}
		}

		public static void knjigaPodaciCuvanjeSQL(List<Knjiga> lista, STR nazivFajla) {
			
		}
		
		public static void knjigaPodaciCuvanjeJSON(List<Knjiga> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + ".json")
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}
			
			STR jsonString = JsonConvert.SerializeObject(lista);
			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
				streamWriter.WriteLine(jsonString);
				
				streamWriter.Close();
			}
		}
		
		public static List<Clan> clanPodaciUcitavanje(STR nazivFajla) {
			// Spajanje lokacije AppData foldera, Imena projekta i imena fajla
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			List<Clan> a = new List<Clan>();

			if (System.IO.File.Exists(lokacija)) {
				using (System.IO.StreamReader streamReader = new System.IO.StreamReader(lokacija)) {
					while (!streamReader.EndOfStream) {
						// DONE: Proveriti sintaksu i dodati da se iz .data fajla iscitaju svi podaci, konvertuju u 'Knjiga' i dodati u listu
						a.Add(new Clan(
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							Kriptografija.Desifrovanje(streamReader.ReadLine()),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							new CEBR[] {
								CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
								CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
								CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine()))
							}
						));
					}
					
					streamReader.Close();
				}
			}

			return a;
		}

		public static void clanPodaciCuvanje(List<Clan> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}

			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
				foreach (var clan in lista) {
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + clan.preuzmiID()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(clan.preuzmiIme()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(clan.preuzmiPrezime()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje(clan.preuzmiJMBG()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + clan.preuzmiGodinuRodjenja()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + clan.preuzmiIznajmljeneKnjige()[0]));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + clan.preuzmiIznajmljeneKnjige()[1]));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + clan.preuzmiIznajmljeneKnjige()[2]));
				}
				
				streamWriter.Close();
			}
		}

		public static void clanPodaciCuvanjeSQL(List<Clan> lista, STR nazivFajla) {

		}

		public static void clanPodaciCuvanjeJSON(List<Clan> lista, STR nazivFajla) {

		}

		public static List<ArhivaIznajmljivanja> arhivaIznajmljivanjaPodaciUcitavanje(STR nazivFajla) {
			// Spajanje lokacije AppData foldera, Imena projekta i imena fajla
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			List<ArhivaIznajmljivanja> a = new List<ArhivaIznajmljivanja>();

			if (System.IO.File.Exists(lokacija)) {
				using (System.IO.StreamReader streamReader = new System.IO.StreamReader(lokacija)) {
					while (!streamReader.EndOfStream) {
						// DONE: Proveriti sintaksu i dodati da se iz .data fajla iscitaju svi podaci, konvertuju u 'Knjiga' i dodati u listu
						a.Add(new ArhivaIznajmljivanja(
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							CEBR.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							(EIznajmljivanjeVracanje) Enum.Parse(
								typeof(EIznajmljivanjeVracanje),
								(STR) Kriptografija.Desifrovanje(streamReader.ReadLine()),
								true
							),
							DateTime.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine())),
							TAC.Parse(Kriptografija.Desifrovanje(streamReader.ReadLine()))
						));
					}
					
					streamReader.Close();
				}
			}

			return a;
		}

		public static void arhivaIznajmljivanjaPodaciCuvanje(List<ArhivaIznajmljivanja> lista, STR nazivFajla) {
			STR lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				System.Reflection.Assembly.GetEntryAssembly().GetName().Name,
				(nazivFajla + MenadzmentPodataka.ekstenzija)
			);
			
			if (!System.IO.File.Exists(lokacija)) {
				System.IO.File.Create(lokacija).Close();
			}

			using (System.IO.StreamWriter streamWriter = new System.IO.StreamWriter(lokacija)) {
				foreach (var arhiva in lista) {
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + arhiva.preuzmiID()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + arhiva.preuzmiIDKnjige()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + arhiva.preuzmiIDClan()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + arhiva.preuzmiIDKorisnik()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + arhiva.preuzmiStatus()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + arhiva.preuzmiDatum()));
					streamWriter.WriteLine(Kriptografija.Sifrovanje("" + arhiva.preuzmiJeVracena()));
				}
				
				streamWriter.Close();
			}
		}

		public static void arhivaIznajmljivanjaPodaciCuvanjeSQL(List<ArhivaIznajmljivanja> lista, STR nazivFajla) {
			
		}

		public static void arhivaIznajmljivanjaPodaciCuvanjeJSON(List<ArhivaIznajmljivanja> lista, STR nazivFajla) {
			
		}
	}
}