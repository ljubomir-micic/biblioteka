////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TAC = System.Boolean;
using CEBR = System.Int32;

namespace Project
{
	public partial class NalogIzmena : Form
	{
		private Korisnik nalog;
		private TAC jeIzmenjen;

		public TAC JeIzmenjen {
			get {
				return jeIzmenjen;
			} set {
				jeIzmenjen = value;
			}
		}

		List<Korisnik> Korisnici {
			get {
				return MenadzmentPodataka.korisnici;
			} set {
				MenadzmentPodataka.korisnici = value;
			}
		}

		public NalogIzmena(ref Korisnik nalog)
		{
			InitializeComponent();
			
			this.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) {
				Colors.BojenjeBackColor<AccentPolje>(control, this.BackColor);
				Colors.BojenjeForeColor<AccentPolje>(control, Colors.BojaTeksta);
			}
			
			this.KeyPreview = true;
			
			this.nalog = nalog;
			{
                System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
                graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.pictureBox1.ClientRectangle);
                graphicsPath.CloseFigure();
                this.pictureBox1.Region = new Region(graphicsPath);
			}
			this.accentPolje1.Text = nalog.preuzmiIme();
			this.accentPolje2.Text = nalog.preuzmiPrezime();
			this.accentPolje3.Text = "" + nalog.preuzmiGodinuRodjenja();
			this.JeIzmenjen = false;
			KorigujLabelu();
		}
		
		void KorigujLabelu() {
			label1.ForeColor = JeIzmenjen ? Colors.BookColor2 : Colors.AccentColor;
			label1.Text = JeIzmenjen ? "Затворите овај прозор како бисте сачували измене" : (IspunjavaUsloveZaIzmenu() ? "Унесите измену" : "Попуните сва поља");
		}

		TAC IspunjavaUsloveZaIzmenu() {
			CEBR greska = -1;
			CEBR.TryParse(accentPolje3.Text, out greska);
			return (
				!String.IsNullOrEmpty(accentPolje1.Text) &&
				!String.IsNullOrEmpty(accentPolje2.Text) &&
				!String.IsNullOrEmpty(accentPolje3.Text) &&
				greska != 0
			);
		}
		
		void AccentPoljeTekstIzmenjen(object sender, EventArgs e)
		{
			this.JeIzmenjen = IspunjavaUsloveZaIzmenu();
			this.KorigujLabelu();
		}
		
		void NalogIzmenaKeyDown(object sender, KeyEventArgs e)
		{
			if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F5)) {
				this.accentPolje1.Text = nalog.preuzmiIme();
				this.accentPolje2.Text = nalog.preuzmiPrezime();
				this.accentPolje3.Text = "" + nalog.preuzmiGodinuRodjenja();
				this.JeIzmenjen = false;
				KorigujLabelu();
				if (e.KeyCode == Keys.Escape) this.Close();
			}
		}
		
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			if (this.JeIzmenjen) {
				nalog.postaviIme(accentPolje1.Text);
				nalog.postaviPrezime(accentPolje2.Text);
				nalog.postaviGodinuRodjenja(CEBR.Parse(accentPolje3.Text));

				for (CEBR i = 0; i < Korisnici.Count; i ++) if (Korisnici[i].preuzmiID() == nalog.preuzmiID()) {
					Korisnici[i] = nalog;
					MenadzmentPodataka.korisnikPodaciCuvanje(Korisnici, "korisnici");
				}
			}

			base.OnClosing(e);
		}
	}
}
