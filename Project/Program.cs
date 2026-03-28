////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Extensions;
using CEBR = System.Int32;
using TAC = System.Boolean;
using STR = System.String;

namespace Project
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(STR[] args)
		{
			WinApp.WriteHeader();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			using (RegistryKey registriKljuc = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека")) {
				// Ukoliko kljuc postoji, onda se ucitavaju podaci
				if (registriKljuc != null) {
					foreach (STR kljuc in Podesavanja.podesavanja.Keys.ToArray()) Podesavanja.podesavanja[kljuc] = TAC.Parse(registriKljuc.GetValue(kljuc).ToString());
					Podesavanja.koriscenjeUDK = (UDK.UDK_Koriscenje) ((CEBR) registriKljuc.GetValue("UDK"));

					registriKljuc.Close();
				} else {
					InicijalnaPodesavanja.inicijalnoPodesavanjeREGEDIT();
				}
			}
			
			MenadzmentPodataka.OtvoriFormu();
		}
	}
}
