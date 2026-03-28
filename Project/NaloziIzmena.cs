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

namespace Project
{
	public partial class NaloziIzmena : Form, IIzmena
	{
		private bool _jeIzmenjen;
		private List<NaloziCelija> korisniciUI;
		private int marginaKomponenti = 35;

		public bool JeIzmenjen {
			get {
				return _jeIzmenjen;
			} set {
				_jeIzmenjen = value;
			}
		}

		private List<Korisnik> Korisnici {
			get {
				return MenadzmentPodataka.korisnici;
			} set {
				MenadzmentPodataka.korisnici = value;
			}
		}

		private void GenerisanjeKorisnikUI(int index) {
			korisniciUI.Add(new NaloziCelija(Korisnici[index]));
			this.SuspendLayout();
			int i = korisniciUI.Count - 1;
			this.korisniciUI[i].Size = new System.Drawing.Size(this.Width - 2 * marginaKomponenti, 52);
			this.korisniciUI[i].Location = new System.Drawing.Point(marginaKomponenti, (marginaKomponenti + i * (this.korisniciUI[i].Height + 10)));
			this.korisniciUI[i].Name = "korisniciUI[" + i + "]";
			this.korisniciUI[i].TabIndex = 2;
			this.korisniciUI[i].ForeColor = Colors.BojaTeksta;
			this.korisniciUI[i].CelijaSeBrise += new EventHandler(this.CelijaSeBrise);
			this.korisniciUI[i].DoubleClick += new EventHandler(this.IzmenaNekogNaloga);
			foreach (Control a in this.korisniciUI[i].Controls) a.DoubleClick += new EventHandler(this.IzmenaNekogNaloga);
			this.panel1.Controls.Add(korisniciUI[i]);
		}
		
		void IzmeniRedosledKorisnika(int mesto) {
			this.korisniciUI[mesto].Location = new System.Drawing.Point(marginaKomponenti, (marginaKomponenti + mesto * (this.korisniciUI[mesto].Height + 10)));
		}

		public NaloziIzmena()
		{
			_jeIzmenjen = false;
			korisniciUI = new List<NaloziCelija>();
			InitializeComponent();

			this.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) {
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentDugme>(control, Colors.AccentColor);
			}
			for (int i = 0; i < Korisnici.Count; i ++) GenerisanjeKorisnikUI(i);
		}

		void CelijaSeBrise(object sender, EventArgs e) {
			if (MessageBox.Show("Брисање је радња неопозивог карактера.\nЈесте ли сигурни да желите да наставите?", "Библиотека: Потврда брисања" , MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;
			NaloziCelija nalogCelija = (NaloziCelija) sender;
			for (int i = 0; i < this.korisniciUI.Count; i ++) if (korisniciUI[i].id == nalogCelija.id) korisniciUI.RemoveAt(i);
			for (int i = 0; i < Korisnici.Count; i ++) if (Korisnici[i].preuzmiID() == nalogCelija.id) Korisnici.RemoveAt(i);
			MenadzmentPodataka.korisnikPodaciCuvanje(Korisnici, "korisnici");
			nalogCelija.Dispose();
			for (int i = 0; i < korisniciUI.Count; i ++) IzmeniRedosledKorisnika(i);
		}
		
		void IzmenaNekogNaloga(object sender, EventArgs e) {
			NaloziCelija nalogCelija = (NaloziCelija) sender;
			Korisnik korisnik = Korisnici.Find(x => x.preuzmiID() == nalogCelija.id);
			NalogIzmena nalogIzmena = new NalogIzmena(ref korisnik);
			nalogIzmena.ShowDialog();
			if (nalogIzmena.JeIzmenjen) {
				if (!this.JeIzmenjen) this.JeIzmenjen = korisnik.preuzmiID() == Podesavanja.korisnik.preuzmiID();
				nalogCelija.ImePrezime = korisnik.preuzmiIme() + " " + korisnik.preuzmiPrezime();
				nalogCelija.GodRodjenja = korisnik.preuzmiGodinuRodjenja();
			}
			nalogIzmena.Dispose();
		}
		
		void AccentDugme1Click(object sender, EventArgs e)
		{
			DodajKorisnika dodajKorisnika = new DodajKorisnika();
			dodajKorisnika.ShowDialog();
			if (dodajKorisnika.JeDodat) {
				GenerisanjeKorisnikUI(Korisnici.Count - 1);
			}
			dodajKorisnika.Dispose();
		}
	}
}
