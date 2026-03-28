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
	public partial class IzmenaAutora : Form, IIzmena
	{
		Autor autor;
		bool _jeIzmenjen;
		
		public bool JeIzmenjen {
			get {
				return _jeIzmenjen;
			} set {
				_jeIzmenjen = value;
				KorigujLabelu();
			}
		}

		private List<Autor> Autori {
			get {
				return MenadzmentPodataka.autori;
			} set {
				MenadzmentPodataka.autori = value;
			}
		}
		
		public IzmenaAutora(ref Autor autor)
		{
			InitializeComponent();
			this.autor = autor;
			this._jeIzmenjen = false;

			this.KeyPreview = true;
			
			// DONE: Implementirati mogucnost uskladjivanja teme shodno podesavanjima
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

			this.accentPolje1.Text = this.autor.preuzmiIme();
			this.accentPolje2.Text = this.autor.preuzmiPrezime();
			this.accentPolje3.Text = "" + this.autor.preuzmiGodinuRodjenja();
			this.accentPolje4.Text = "" + this.autor.preuzmiGodinuSmrti();
			this.JeIzmenjen = false;
		}
		
		private void KorigujLabelu() {
			label1.ForeColor = JeIzmenjen ? Colors.BookColor2 : Colors.AccentColor;
			label1.Text = JeIzmenjen ? "Затворите овај прозор како бисте сачували измене" : (IspunjavaUsloveZaIzmenu() ? "Унесите измену" : "Попуните сва поља");
		}

		bool IspunjavaUsloveZaIzmenu() {
			int greska = -1;
			int.TryParse(accentPolje3.Text, out greska);
			if (greska != 0) int.TryParse(accentPolje4.Text, out greska);
			return (
				!String.IsNullOrEmpty(accentPolje1.Text) &&
				!String.IsNullOrEmpty(accentPolje2.Text) &&
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

		void NaPritisnutTaster(object sender, KeyEventArgs e) {
			if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F5)) {
				this.accentPolje1.Text = this.autor.preuzmiIme();
				this.accentPolje2.Text = this.autor.preuzmiPrezime();
				this.accentPolje3.Text = "" + this.autor.preuzmiGodinuRodjenja();
				this.accentPolje4.Text = "" + this.autor.preuzmiGodinuSmrti();
				this.autor = new Autor();
				this.JeIzmenjen = false;
				if (e.KeyCode == Keys.Escape) this.Close();
			}
		}
		
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
			if (this.JeIzmenjen) {
				this.autor.postaviIme(accentPolje1.Text);
				this.autor.postaviPrezime(accentPolje2.Text);
				this.autor.postaviGodinuRodjenja(int.Parse(accentPolje3.Text));
				this.autor.postaviGodinuSmrti(int.Parse(accentPolje4.Text));

				for (int i = 0; i < Autori.Count; i ++) if (Autori[i].preuzmiID() == this.autor.preuzmiID()) Autori[i] = this.autor;
				MenadzmentPodataka.autorPodaciCuvanje(Autori, "autori");
			}
		}
	}
}
