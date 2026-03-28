////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
	public static class Colors {
		// Rekurzivni metodi za podesavanje teme
		public static void BojenjeForeColor<Tip>(Control control, Color Boja) where Tip : Control {
			if (control is KnjigaUI) return;
			else if (control is Tip) ((Tip) control).ForeColor = Boja;
			else foreach (Control control2 in control.Controls) BojenjeForeColor<Tip>(control2, Boja);
		}
		
		public static void BojenjeBackColor<Tip>(Control control, Color Boja) where Tip : Control {
			if (control is Tip && !((string) control.Tag == "Destructive")) ((Tip) control).BackColor = Boja;
			else foreach (Control control2 in control.Controls) BojenjeBackColor<Tip>(control2, Boja);
		}
		
		public static Color AccentColor {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return System.Drawing.Color.FromArgb(122, 31, 31);
				else return System.Drawing.Color.FromArgb(159, 75, 71);
			}
		}

		public static Color BookColor2 {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return System.Drawing.Color.FromArgb(15, 137, 48);
				else return System.Drawing.Color.FromArgb(74, 148, 94);
			}
		}

		public static Color BookColor3 {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return System.Drawing.Color.FromArgb(16, 100, 165);
				else return System.Drawing.Color.FromArgb(74, 116, 148);
			}
		}
		
		public static Color TamnijaPozadina {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return System.Drawing.Color.FromName("Control");
				else return System.Drawing.Color.FromArgb(38, 36, 34);
			}
		}
		
		public static Color SvetlijaPozadina {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return System.Drawing.Color.White;
				else return System.Drawing.Color.FromArgb(57, 61, 59);
			}
		}
		
		public static Color BojaTeksta {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return System.Drawing.Color.Black;
				else return System.Drawing.Color.White;
			}
		}
	}
}