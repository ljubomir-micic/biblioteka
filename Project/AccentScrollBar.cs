////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace Project
{
	public enum EAccentScrollBarStatus {
		Normalan,
		Hoverovan,
		Pritisnut,
		Onemogucen
	}

	public enum EAccentScrollBarStrelicaStatus {
		Gornja_Normalna,
		Gornja_Hoverovana,
		Gornja_Pritisnuta,
		Gornja_Onemogucena,
		Donja_Normalna,
		Donja_Hoverovana,
		Donja_Pritisnuta,
		Donja_Onemogucena
	}

	public enum EAccentScrollBarOrijentacija {
		Vertikalna,
		Horizontalna
	}

	internal static class AccentScrollBarCrtanje {
		private static Color[] bojaSimbola = new Color[3];
		private static Color[] bojaPozadine = new Color[3];

		static AccentScrollBarCrtanje() {
			// Normalno
			bojaPozadine[0] = Color.Transparent;
			bojaSimbola[0] = Colors.TamnijaPozadina;

			// Hover
			bojaPozadine[1] = Podesavanja.Tema == ETema.Svetla ? Color.FromArgb(240, 240, 240) : Color.FromArgb(70, 70, 70);
			bojaSimbola[1] = ControlPaint.Dark(Colors.TamnijaPozadina);

			// Pritisnuto
			bojaPozadine[2] = bojaPozadine[1];
			bojaSimbola[2] = Podesavanja.Tema == ETema.Svetla ? Color.FromArgb(220, 220, 220) : Color.Black;
		}

		public static void NacrtajPozadinu(Graphics grafika, Rectangle pravougaonik, EAccentScrollBarOrijentacija orijentacija) {
			if (grafika == null) throw new ArgumentNullException("grafika");
			if (pravougaonik.IsEmpty || grafika.IsVisibleClipEmpty || !grafika.VisibleClipBounds.IntersectsWith(pravougaonik)) return;
			if (orijentacija == EAccentScrollBarOrijentacija.Vertikalna) NacrtajPozadinuVertikalno(grafika, pravougaonik);
			else NacrtajPozadinuHorizontalno(grafika, pravougaonik);
		}

		public static void NacrtajTraku(Graphics grafika, Rectangle pravougaonik, EAccentScrollBarStatus status, EAccentScrollBarOrijentacija orijentacija) {
			if (grafika == null) throw new ArgumentNullException("grafika");
			if (pravougaonik.IsEmpty || grafika.IsVisibleClipEmpty || !grafika.VisibleClipBounds.IntersectsWith(pravougaonik) || status == EAccentScrollBarStatus.Onemogucen) return;
			if (orijentacija == EAccentScrollBarOrijentacija.Vertikalna) NacrtajTrakuVertikalno(grafika, pravougaonik, status);
			else NacrtajTrakuHorizontalno(grafika, pravougaonik, status);
		}

		private static void NacrtajPozadinuVertikalno(Graphics grafika, Rectangle pravougaonik) {

		}

		private static void NacrtajPozadinuHorizontalno(Graphics grafika, Rectangle pravougaonik) {

		}

		private static void NacrtajTrakuVertikalno(Graphics grafika, Rectangle pravougaonik, EAccentScrollBarStatus status) {

		}

		private static void NacrtajTrakuHorizontalno(Graphics grafika, Rectangle pravougaonik, EAccentScrollBarStatus status) {

		}
	}

	public class AccentScrollBar : Control
	{
		private int minimum;
		private int maksimum = 1;
		private int vrednost;
		private EAccentScrollBarOrijentacija orijentacija;
		Color boja;

		public int Minimum {
			get {
				return minimum;
			} set {
				minimum = value;
			}
		}

		public int Maksimum {
			get {
				return maksimum;
			} set {
				maksimum = value;
			}
		}

		public int Vrednost {
			get {
				return vrednost;
			} set {
				vrednost = value;
			}
		}

		public EAccentScrollBarOrijentacija Orijentacija {
			get {
				return orijentacija;
			} set {
				orijentacija = value;
			}
		}
		
		public Color Boja {
			get {
				return boja;
			} set {
				boja = value;
			}
		}
		
		public AccentScrollBar()
		{
			Boja = Podesavanja.Tema == ETema.Svetla ? Color.Black : Color.White ;
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);
			e.Graphics.Clear(this.Parent.BackColor);
			e.Graphics.SmoothingMode = SmoothingMode.None;
			Rectangle pravougoanik = ClientRectangle;
			if (Orijentacija == EAccentScrollBarOrijentacija.Vertikalna) {
				pravougoanik.X ++;
				pravougoanik.Y += 3;
			} else {

			}

			AccentScrollBarCrtanje.NacrtajPozadinu(e.Graphics, ClientRectangle, this.Orijentacija);
			AccentScrollBarCrtanje.NacrtajTraku(e.Graphics, pravougoanik, EAccentScrollBarStatus.Normalan, this.Orijentacija);
		}
		
		private Rectangle GetScrollerRectangle()
	    {
	        int thumbHeight = this.Height / 10;
	        int thumbTop = (this.Height - thumbHeight) * (this.Vrednost - this.Minimum) / (this.Maksimum - this.Minimum);
	        return new Rectangle(0, thumbTop, this.Width, thumbHeight);
	    }
	}
}