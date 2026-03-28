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
	public partial class IzmenaIzdavaca : Form, IIzmena
	{
		Izdavac izdavac;
		bool _jeIzmenjen;
		
		public bool JeIzmenjen {
			get {
				return _jeIzmenjen;
			} set {
				_jeIzmenjen = value;
				KorigujLabelu();
			}
		}

		private List<Izdavac> Izdavaci {
			get {
				return Project.MenadzmentPodataka.izdavaci;
			} set {
				MenadzmentPodataka.izdavaci = value;
			}
		}
		
		public IzmenaIzdavaca(ref Izdavac izdavac)
		{
			InitializeComponent();
			this.izdavac = izdavac;

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

			this.accentPolje1.Text = this.izdavac.preuzmiNaziv();
			this.accentPolje2.Text = "" + this.izdavac.preuzmiPIB();
			this.accentPolje3.Text = "" + this.izdavac.preuzmiMBR();
			this.accentPolje4.Text = "" + this.izdavac.preuzmiGodinuOsnivanja();
			this.JeIzmenjen = false;
		}

		void KorigujLabelu() {
			label1.ForeColor = JeIzmenjen ? Colors.BookColor2 : Colors.AccentColor;
			label1.Text = JeIzmenjen ? "Затворите овај прозор како бисте сачували измене" : (IspunjavaUsloveZaIzmenu() ? "Унесите измену" : "Попуните сва поља");
		}

		protected void NaPritisnutTaster(object sender, KeyEventArgs e) {
			if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F5)) {
				this.accentPolje1.Text = this.izdavac.preuzmiNaziv();
				this.accentPolje2.Text = "" + this.izdavac.preuzmiPIB();
				this.accentPolje3.Text = "" + this.izdavac.preuzmiMBR();
				this.accentPolje4.Text = "" + this.izdavac.preuzmiGodinuOsnivanja();
				this.JeIzmenjen = false;
				if (e.KeyCode == Keys.Escape) this.Close();
			}
		}

		bool IspunjavaUsloveZaIzmenu() {
			int greska = -1;
			int.TryParse(accentPolje2.Text, out greska);
			if (greska != 0) int.TryParse(accentPolje3.Text, out greska);
			if (greska != 0) int.TryParse(accentPolje4.Text, out greska);
			return (
				!String.IsNullOrEmpty(accentPolje1.Text) &&
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
				this.izdavac.postaviNaziv(accentPolje1.Text);
				this.izdavac.postaviPIB(int.Parse(accentPolje2.Text));
				this.izdavac.postaviMBR(int.Parse(accentPolje3.Text));
				this.izdavac.postaviGodinuOsnivanja(int.Parse(accentPolje4.Text));

				for (int i = 0; i < Izdavaci.Count; i ++) if (Izdavaci[i].preuzmiID() == this.izdavac.preuzmiID()) Izdavaci[i] = this.izdavac;
				MenadzmentPodataka.izdavacPodaciCuvanje(Izdavaci, "izdavaci");
			}
		}
	}
}
