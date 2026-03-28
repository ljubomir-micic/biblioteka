////////////////////////////////////////////////////////////
//
//    Библиотека: Resources Reset Tool
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using System.Security.Principal;
using Extensions;

namespace reset
{
	class Program
	{
		public static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			bool isAdmin = new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
			if (!isAdmin) {
				ProcessStartInfo startInfo = new ProcessStartInfo();
				startInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
				startInfo.Verb = "runas";
				Process.Start(startInfo);
				return;
			}
			string lokacija = System.IO.Path.Combine(
				Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
				"Библиотека"
			);
			while (true) {
				Console.WriteHeader();
				Console.WriteLine("Метод брисања података:\n\t1. Локални подаци\n\t2. Подешавања програма");
				switch (int.Parse(Console.ReadLine())) {
					case 1:
						if (System.IO.Directory.Exists(lokacija)) {
							Console.WriteLine("Брисање је радња неповратног карактера. Да ли сте сигурни да желите да наставите? [D/N]");
							if (Console.ReadLine() != "D") break;
		
							try {
								Console.WriteLine("Брисање...");
								foreach (string FileName in System.IO.Directory.GetFiles(lokacija)) {
									System.IO.File.Delete(FileName);
								}
								System.IO.Directory.Delete(lokacija);
								Console.WriteLine("Обрисани су сви локални подаци.");
							} catch (Exception e) {
								Console.WriteLine(e);
							}
						} else {
							Console.WriteLine("Локални подаци не постоје...");
						}
						
						break;
					case 2:
						Microsoft.Win32.Registry.CurrentUser.DeleteSubKey(@"SOFTWARE\\Библиотека");
						Console.WriteLine("Сва подешавања су успешно обрисана. Поновним покретањем главног програма ће се вратити подразумеване вредности.");
						break;
					default:
						break;
				}
				Console.ReadKey(true);
			}
		}
	}
}