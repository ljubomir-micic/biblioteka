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
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Project
{
	public partial class DodajClana : Form, IDodavanje
	{
		private Clan clan;
		private bool _jeDodat;

        public bool JeDodat {
			get {
				return _jeDodat;
			} set {
				_jeDodat = value;
				KorigujLabelu();
			}
		}

		public List<Clan> Clanovi {
			get {
				return MenadzmentPodataka.clanovi;
			} set {
				MenadzmentPodataka.clanovi = value;
			}
		}

		public DodajClana()
		{
			clan = new Clan();
			_jeDodat = false;

			this.KeyPreview = true;

			InitializeComponent();

			// DONE: Implementirati mogucnost uskladjivanja teme shodno podesavanjima
			this.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) {
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeForeColor<AccentPolje>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentPolje>(control, Colors.SvetlijaPozadina);
			}
			KorigujLabelu();

			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.pictureBox1.ClientRectangle);
                graphicsPath.CloseFigure();
                this.pictureBox1.Region = new Region(graphicsPath);
			}
		}
		
		private void KorigujLabelu() {
			label1.ForeColor = _jeDodat ? Colors.BookColor2 : Colors.AccentColor;
			label1.Text = _jeDodat ? "Затворите овај прозор како бисте сачували члана" : "Попуните сва поља";
		}
		
		protected bool ProveravanjeSvihStavki() {
			return (
				!String.IsNullOrEmpty(this.accentPolje1.Text) &&
				!String.IsNullOrEmpty(this.accentPolje2.Text) &&
			 	!String.IsNullOrEmpty(this.accentPolje3.Text) && 
			 	!String.IsNullOrEmpty(this.accentPolje4.Text)
			);
		}
		
		protected void AccentPolje1TekstIzmenjen(object sender, EventArgs e) {
			this.clan.postaviIme(accentPolje1.Text);
			this.JeDodat = ProveravanjeSvihStavki();
		}
		
		protected void AccentPolje2TekstIzmenjen(object sender, EventArgs e) {
			this.clan.postaviPrezime(accentPolje2.Text);
			this.JeDodat = ProveravanjeSvihStavki();
		}
		
		protected void AccentPolje3TekstIzmenjen(object sender, EventArgs e) {
			this.clan.postaviJMBG(accentPolje3.Text);
			this.JeDodat = ProveravanjeSvihStavki();
		}
		
		protected void AccentPolje4TekstIzmenjen(object sender, EventArgs e) {
			int greska = 1;
			int.TryParse(accentPolje4.Tekst, out greska);
			if (greska == 0 || String.IsNullOrEmpty(accentPolje4.Text)) {
				accentPolje4.Text = "";
				this.clan.postaviGodinuRodjenja(0);
				this.JeDodat = ProveravanjeSvihStavki();
				return;
			}
			this.clan.postaviGodinuRodjenja(int.Parse(accentPolje4.Text));
			this.JeDodat = ProveravanjeSvihStavki();
		}

		protected void NaPritisnutTaster(object sender, KeyEventArgs e) {
			if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F5)) {
				this.accentPolje1.Clear();
				this.accentPolje2.Clear();
				this.accentPolje3.Clear();
				this.accentPolje4.Clear();
				this.accentPolje1.Select();
				this.clan = new Clan();
				this.JeDodat = false;
				KorigujLabelu();
				if (e.KeyCode == Keys.Escape) this.Close();
			}
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			if (JeDodat) {
				Clanovi.Add(this.clan);
				MenadzmentPodataka.clanPodaciCuvanje(Clanovi, "clanovi");
			}
			
			base.OnClosing(e);
		}
    }
}
