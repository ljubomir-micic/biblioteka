////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System.Windows.Forms;
using BOJA = System.Drawing.Color;
using STR = System.String;

namespace Project
{
	public static class Colors {
		// Rekurzivni metodi za podesavanje teme
		public static void BojenjeForeColor<Tip>(Control control, BOJA Boja) where Tip : Control {
			if (control is KnjigaUI) return;
			else if (control is Tip && !((STR) control.Tag == "ZakljucanaPrednjaBoja")) ((Tip) control).ForeColor = Boja;
			else foreach (Control control2 in control.Controls) BojenjeForeColor<Tip>(control2, Boja);
		}
		
		public static void BojenjeBackColor<Tip>(Control control, BOJA Boja) where Tip : Control {
			if (control is Tip && !((STR) control.Tag == "ZakljucanaBoja")) ((Tip) control).BackColor = Boja;
			else foreach (Control control2 in control.Controls) BojenjeBackColor<Tip>(control2, Boja);
		}
		
		public static BOJA AccentColor {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return BOJA.FromArgb(122, 31, 31);
				else return BOJA.FromArgb(159, 75, 71);
			}
		}

		public static BOJA BookColor2 {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return BOJA.FromArgb(15, 137, 48);
				else return BOJA.FromArgb(74, 148, 94);
			}
		}

		public static BOJA BookColor3 {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return BOJA.FromArgb(16, 100, 165);
				else return BOJA.FromArgb(74, 116, 148);
			}
		}
		
		public static BOJA TamnijaPozadina {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return BOJA.FromName("Control");
				else return BOJA.FromArgb(36, 36, 36);
			}
		}
		
		public static BOJA SvetlijaPozadina {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return BOJA.White;
				else return BOJA.FromArgb(60, 60, 60);
			}
		}
		
		public static BOJA BojaTeksta {
			get {
				if (Podesavanja.Tema == ETema.Svetla) return BOJA.Black;
				else return BOJA.White;
			}
		}
	}
}