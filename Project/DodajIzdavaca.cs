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
	public partial class DodajIzdavaca : Form, IDodavanje
	{
		private Izdavac izdavac;
		private bool _jeDodat;

		public bool JeDodat {
			get {
				return _jeDodat;
			} set {
				_jeDodat = value;
				KorigujLabelu();
			}
		}

		private List<Izdavac> Izdavaci {
			get {
				return MenadzmentPodataka.izdavaci;
			} set {
				MenadzmentPodataka.izdavaci = value;
			}
		}

		public DodajIzdavaca()
		{
			izdavac = new Izdavac();
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
			label1.Text = _jeDodat ? "Затворите овај прозор како бисте сачували издавача" : "Попуните сва поља";
		}
		
		protected bool ProveravanjeSvihStavki() {
			return (
				!String.IsNullOrEmpty(accentPolje1.Text) && 
				!String.IsNullOrEmpty(accentPolje2.Text) && 
				!String.IsNullOrEmpty(accentPolje3.Text) && 
				!String.IsNullOrEmpty(accentPolje4.Text)
			);
		}

		protected void AccentPolje1TekstIzmenjen(object sender, EventArgs e) {
			this.izdavac.postaviNaziv(this.accentPolje1.Text);
			this.JeDodat = ProveravanjeSvihStavki();
		}

		protected void AccentPolje2TekstIzmenjen(object sender, EventArgs e) {
			int greska = 1;
			int.TryParse(accentPolje2.Tekst, out greska);
			if (greska == 0 || String.IsNullOrEmpty(accentPolje2.Text)) {
				accentPolje2.Text = "";
				this.izdavac.postaviMBR(0);
				this.JeDodat = ProveravanjeSvihStavki();
				return;
			}
			this.izdavac.postaviMBR(int.Parse(accentPolje2.Text));
			this.JeDodat = ProveravanjeSvihStavki();
		}

		protected void AccentPolje3TekstIzmenjen(object sender, EventArgs e) {
			int greska = 1;
			int.TryParse(accentPolje3.Tekst, out greska);
			if (greska == 0 || String.IsNullOrEmpty(accentPolje3.Text)) {
				accentPolje3.Text = "";
				this.izdavac.postaviPIB(0);
				this.JeDodat = ProveravanjeSvihStavki();
				return;
			}
			this.izdavac.postaviPIB(int.Parse(accentPolje3.Text));
			this.JeDodat = ProveravanjeSvihStavki();
		}

		protected void AccentPolje4TekstIzmenjen(object sender, EventArgs e) {
			int greska = 1;
			int.TryParse(accentPolje4.Tekst, out greska);
			if (greska == 0 || String.IsNullOrEmpty(accentPolje4.Text)) {
				accentPolje4.Text = "";
				this.izdavac.postaviGodinuOsnivanja(0);
				this.JeDodat = ProveravanjeSvihStavki();
				return;
			}
			this.izdavac.postaviGodinuOsnivanja(int.Parse(accentPolje4.Text));
			this.JeDodat = ProveravanjeSvihStavki();
		}

		protected void NaPritisnutTaster(object sender, KeyEventArgs e) {
			if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F5)) {
				this.accentPolje1.Clear();
				this.accentPolje2.Clear();
				this.accentPolje3.Clear();
				this.accentPolje4.Clear();
				this.accentPolje1.Select();
				this.izdavac = new Izdavac();
				this.JeDodat = false;
				KorigujLabelu();
				if (e.KeyCode == Keys.Escape) this.Close();
			}
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
			if (JeDodat) {
				Izdavaci.Add(this.izdavac);
				MenadzmentPodataka.izdavacPodaciCuvanje(Izdavaci, "izdavaci");
			}

			base.OnClosing(e);
		}
	}
}
