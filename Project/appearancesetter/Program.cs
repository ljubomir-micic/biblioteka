////////////////////////////////////////////////////////////
//
//    Библиотека - Appearance Setting Tool
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Diagnostics;
using System.Security.Principal;
using Extensions;

namespace appearancesetter {
	class Program {
		public static void Main(string[] args) {
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
				
				Console.ReadKey(true);
			}
		}
	}
}