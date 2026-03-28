////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using CEBR = System.Int32;
using DECD = System.Double;
using TACKA = System.Drawing.Point;
using VELICINA = System.Drawing.Size;

namespace Project {
	namespace Alati
	{
		public static class Animacije
		{
			public static void PromeniLokaciju<TipKontrole>(TipKontrole kontrola, TACKA krajnjaTacka, CEBR frejmPoSekundi, DECD brojSekundi) where TipKontrole : Control {
				Timer tajmer = new Timer();
				tajmer.Interval = 1000 / frejmPoSekundi;
				
				TACKA pocetnaTacka = kontrola.Location;
				CEBR razdaljinaX = krajnjaTacka.X - pocetnaTacka.X;
				CEBR razdaljinaY = krajnjaTacka.Y - pocetnaTacka.Y;
				
				tajmer.Tick += delegate {
					DECD procenat = tajmer.Tag == null ? 0 : (DECD)tajmer.Tag;
					procenat += (DECD)tajmer.Interval / (500 * brojSekundi);
					
					DECD easeInOutProcenat = (Math.Sin(procenat * Math.PI - Math.PI / 2) + 1) / 2;

					kontrola.Location = new TACKA(pocetnaTacka.X + (CEBR)(razdaljinaX * easeInOutProcenat), pocetnaTacka.Y + (CEBR)(razdaljinaY * easeInOutProcenat));

					if (procenat >= 1) {
						kontrola.Location = krajnjaTacka;
						tajmer.Stop();
					} else {
						tajmer.Tag = procenat;
					}
				};

				tajmer.Start();
			}
			
			public static void PromeniVelicinu<TipKontrole>(TipKontrole kontrola, VELICINA konacnaVelicina, CEBR frejmPoSekundi, DECD brojSekundi) where TipKontrole : Control {
				Timer tajmer = new Timer();
				tajmer.Interval = 1000 / frejmPoSekundi;
			}
		}
	}
}