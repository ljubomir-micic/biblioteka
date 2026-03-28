////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using CEBR = System.Int32;
using VELICINA = System.Drawing.Size;
using PRAVOUGAONIK = System.Drawing.Rectangle;
using PUTANJA = System.Drawing.Drawing2D.GraphicsPath;
using TACKA = System.Drawing.PointF;
using DECF = System.Single;

namespace Project {
    public static class Oblik {
        public static PUTANJA GlavniOblik(VELICINA velicina) {
			CEBR velicinaIsecka = Math.Min(velicina.Width, velicina.Height) - 1;
            PRAVOUGAONIK donjiLeviPravougaonik = new PRAVOUGAONIK(0, 0, velicinaIsecka, velicinaIsecka);
            PRAVOUGAONIK gornjiDesniPravougaonik = new PRAVOUGAONIK(velicina.Width - velicinaIsecka, 0, velicinaIsecka, velicinaIsecka);

            PUTANJA putanja = new PUTANJA();
            putanja.StartFigure();
            putanja.AddArc(donjiLeviPravougaonik, 90, 180/2);
            putanja.AddLine(new Point(0, velicina.Height/2), new Point(0, 0));
            putanja.AddArc(gornjiDesniPravougaonik, 270, 180/2);
            putanja.AddLine(new Point(velicina.Width, velicina.Height/2), new Point(velicina.Width, velicina.Height));
            putanja.CloseFigure();

            return putanja;
		}

        public static PUTANJA Kapsula(VELICINA velicina)
        {
            CEBR arcSize = velicina.Height - 1;
            PRAVOUGAONIK leftArc = new PRAVOUGAONIK(0, 0, arcSize, arcSize);
            PRAVOUGAONIK rightArc = new PRAVOUGAONIK(velicina.Width - arcSize - 2, 0, arcSize, arcSize);

            PUTANJA path = new PUTANJA();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }

		public static PUTANJA ZaobljeniPravougaonik(PRAVOUGAONIK Pravougaonik, CEBR intervalZaobljenosti) {
			PRAVOUGAONIK[] kvadrati = new PRAVOUGAONIK[4];
			for (CEBR i = 0; i < kvadrati.Length; i++) kvadrati[i] = new PRAVOUGAONIK((i % 2 == 0) ? Pravougaonik.X : (Pravougaonik.X + Pravougaonik.Width - intervalZaobljenosti - 1), (i < 2) ? Pravougaonik.Y : (Pravougaonik.Height - intervalZaobljenosti - 1), intervalZaobljenosti, intervalZaobljenosti);

			PUTANJA putanja = new PUTANJA();
			putanja.StartFigure();
			putanja.AddArc(kvadrati[0], 180, 90);
			putanja.AddArc(kvadrati[1], 270, 90);
			putanja.AddArc(kvadrati[3], 0, 90);
			putanja.AddArc(kvadrati[2], 90, 90);
			putanja.CloseFigure();
			return putanja;
		}

        public static PUTANJA Zvezda(VELICINA velicina, CEBR kraci)
		{
			TACKA centar = new TACKA(velicina.Width / 2, velicina.Height / 2);

			TACKA[] tacke = new TACKA[kraci * 2];
			DECF poluprecnik = Math.Min(velicina.Width, velicina.Height) / 2;
			DECF ugao = -90;
			DECF ugaoInkrementovanja = 360.0f / tacke.Length;
			for (CEBR i = 0; i < tacke.Length; i++)
			{
				tacke[i] = new TACKA(
					centar.X + (DECF)((i % 2 == 0 ? poluprecnik : poluprecnik / 2) * Math.Cos(Konverzija.StepeniURadijane(ugao))),
					centar.Y + (DECF)((i % 2 == 0 ? poluprecnik : poluprecnik / 2) * Math.Sin(Konverzija.StepeniURadijane(ugao)))
				);
				ugao += ugaoInkrementovanja;
			}

			PUTANJA putanja = new PUTANJA();
			putanja.StartFigure();
			putanja.AddLines(tacke);
			putanja.CloseFigure();
			
			return putanja;
		}
    }
}