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
	public partial class IzmenaClana : Form, IIzmena
	{
		Clan clan;
		bool _jeIzmenjen;
		
		public bool JeIzmenjen {
			get {
				return _jeIzmenjen;
			} set {
				_jeIzmenjen = value;
				KorigujLabelu();
			}
		}

		private List<Clan> Clanovi {
			get {
				return MenadzmentPodataka.clanovi;
			} set {
				MenadzmentPodataka.clanovi = value;
			}
		}
		
		public IzmenaClana(ref Clan clan)
		{
			InitializeComponent();
			this.clan = clan;

			this.KeyPreview = true;

			this.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) {
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeForeColor<AccentPolje>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentPolje>(control, Colors.SvetlijaPozadina);
			}

			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.pictureBox1.ClientRectangle);
                graphicsPath.CloseFigure();
                this.pictureBox1.Region = new Region(graphicsPath);
			}

			this.accentPolje1.Text = this.clan.preuzmiIme();
			this.accentPolje2.Text = this.clan.preuzmiPrezime();
			this.accentPolje3.Text = this.clan.preuzmiJMBG();
			this.accentPolje4.Text = "" + this.clan.preuzmiGodinuRodjenja();
			this.JeIzmenjen = false;
		}

		void KorigujLabelu() {
			label1.ForeColor = JeIzmenjen ? Colors.BookColor2 : Colors.AccentColor;
			label1.Text = JeIzmenjen ? "Затворите овај прозор како бисте сачували измене" : (IspunjavaUsloveZaIzmenu() ? "Унесите измену" : "Попуните сва поља");
		}

		protected void NaPritisnutTaster(object sender, KeyEventArgs e) {
			if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F5)) {
				this.accentPolje1.Text = this.clan.preuzmiIme();
				this.accentPolje2.Text = this.clan.preuzmiPrezime();
				this.accentPolje3.Text = this.clan.preuzmiJMBG();
				this.accentPolje4.Text = "" + this.clan.preuzmiGodinuRodjenja();
				this.JeIzmenjen = false;
				if (e.KeyCode == Keys.Escape) this.Close();
			}
		}

		bool IspunjavaUsloveZaIzmenu() {
			int greska = -1;
			int.TryParse(accentPolje4.Text, out greska);
			return (
				!String.IsNullOrEmpty(accentPolje1.Text) &&
				!String.IsNullOrEmpty(accentPolje2.Text) &&
				!String.IsNullOrEmpty(accentPolje3.Text) &&
				greska != 0
			);
		}

		protected bool ProveravanjeSvihStavki() {
			return (!String.IsNullOrEmpty(accentPolje1.Text) && 
			        !String.IsNullOrEmpty(accentPolje2.Text) && 
					!String.IsNullOrEmpty(accentPolje3.Text) && 
					!String.IsNullOrEmpty(accentPolje4.Text)
			       );
		}

		protected void AccentPolja_TekstIzmenjen(object sender, EventArgs e) {
			this.JeIzmenjen = this.IspunjavaUsloveZaIzmenu();
		}
		
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
			if (this.JeIzmenjen) {
				this.clan.postaviIme(accentPolje1.Text);
				this.clan.postaviPrezime(accentPolje2.Text);
				this.clan.postaviJMBG(accentPolje3.Text);
				this.clan.postaviGodinuRodjenja(int.Parse(accentPolje4.Text));

				for (int i = 0; i < Clanovi.Count; i ++) if (Clanovi[i].preuzmiID() == this.clan.preuzmiID()) Clanovi[i] = this.clan;
				MenadzmentPodataka.clanPodaciCuvanje(Clanovi, "clanovi");
			}
		}
	}
}
