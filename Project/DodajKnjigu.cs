////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Project.Alati;
using STR = System.String;
using PIR = System.Collections.Generic.KeyValuePair<string, string>;

namespace Project
{
	// DONE: Dodati button za kreiranje autora i izdavaca ukoliko ne postoje odredjeni?
	public partial class DodajKnjigu : Form, IDodavanje
	{
		private Knjiga knjiga;
		private bool _jeDodata, _jeDodatAutor, _jeDodatIzdavac;
		
		public bool JeDodat {
			get {
				return _jeDodata;
			} set {
				_jeDodata = value;
				KorigujLabelu();
			}
		}
		
		public bool JeDodatAutor {
			get {
				return _jeDodatAutor;
			} set {
				_jeDodatAutor = value;
			}
		}

		public bool JeDodatIzdavac {
			get {
				return _jeDodatIzdavac;
			} set {
				_jeDodatIzdavac = value;
			}
		}
		
		public List<Knjiga> Knjige {
			get {
				return MenadzmentPodataka.knjige;
			} set {
				MenadzmentPodataka.knjige = value;
			}
		}
		
		public DodajKnjigu()
		{
			InitializeComponent();
			this._jeDodata = false;
			this.knjiga = new Knjiga();

			this.KeyPreview = true;
			
			// DONE: Implementirati mogucnost uskladjivanja teme shodno podesavanjima
			this.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) {
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeForeColor<AccentPolje>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentPolje>(control, Colors.SvetlijaPozadina);
				Colors.BojenjeForeColor<Button>(control, Colors.AccentColor);
				if (control is Button) ((Button) control).FlatAppearance.BorderColor = Colors.AccentColor;
			}
			KorigujLabelu();
			
			foreach (var a in MenadzmentPodataka.autori.ToArray().Reverse()) accentIzbornoPolje1.Items.Add(a.preuzmiImePrezime());
			foreach (var a in MenadzmentPodataka.izdavaci.ToArray().Reverse()) accentIzbornoPolje2.Items.Add(a.preuzmiNaziv());
//			foreach (var zanrovi in Enum.GetNames(typeof(EZanrKnjiga))) accentIzbornoPolje3.Items.Add(zanrovi);
			UDK.PopuniAccentIzbornoPolje(this.accentIzbornoPolje3);
			this.knjigaUI1.Naziv = "";
			this.knjigaUI1.Autor = "";
		}
		
		private void KorigujLabelu() {
			label1.ForeColor = _jeDodata ? Colors.BookColor2 : Colors.AccentColor;
			label1.Text = _jeDodata ? "Затворите овај прозор како бисте сачували књигу" : "Попуните сва поља";
		}

		private bool ProveravanjeSvihStavki() {
			return (!String.IsNullOrEmpty(accentPolje1.Text) && 
			        !String.IsNullOrEmpty(accentPolje2.Text) && 
			        !String.IsNullOrEmpty(accentPolje3.Text) && 
			        accentIzbornoPolje1.SelectedItem != null && 
			        accentIzbornoPolje2.SelectedItem != null && 
			        accentIzbornoPolje3.SelectedItem != null
			       );
		}
		
		protected void AccentPolje1TekstIzmenjen(object sender, EventArgs e) {
			this.knjiga.postaviNaziv(accentPolje1.Text);
			this.knjigaUI1.Naziv = accentPolje1.Text;
			this.JeDodat = ProveravanjeSvihStavki();
		}

		protected void AccentPolje2TekstIzmenjen(object sender, EventArgs e) {
			int greska = 1;
			int.TryParse(accentPolje2.Tekst, out greska);
			if (greska == 0 || String.IsNullOrEmpty(accentPolje2.Text)) {
				accentPolje2.Text = "";
				this.knjiga.postaviBrojStrana(0);
				this.JeDodat = ProveravanjeSvihStavki();
				return;
			}
			this.knjiga.postaviBrojStrana(int.Parse(accentPolje2.Tekst));
			this.JeDodat = ProveravanjeSvihStavki();
		}

		protected void AccentPolje3TekstIzmenjen(object sender, EventArgs e) {
			int greska = 1;
			int.TryParse(accentPolje3.Tekst, out greska);
			if (greska == 0 || String.IsNullOrEmpty(accentPolje3.Text)) {
				accentPolje3.Text = "";
				this.knjiga.postaviGodinuIzdavanja(0);
				this.knjigaUI1.GodinaIzdanja = 0;
				this.JeDodat = ProveravanjeSvihStavki();
				return;
			}
			this.knjiga.postaviGodinuIzdavanja(int.Parse(accentPolje3.Tekst));
			this.knjigaUI1.GodinaIzdanja = int.Parse(accentPolje3.Tekst);
			this.JeDodat = ProveravanjeSvihStavki();
		}

		protected void AccentIzbornoPolje1SelektovanIndeksPromenjen(object cender, EventArgs e) {
			if (this.accentIzbornoPolje1.SelectedItem == null) {
				this.knjigaUI1.Autor = "";
				return;
			}
			this.knjiga.postaviIDAutora(MenadzmentPodataka.autori[MenadzmentPodataka.autori.Count - 1 - accentIzbornoPolje1.SelectedIndex].preuzmiID());
			this.knjigaUI1.Autor = MenadzmentPodataka.autori[MenadzmentPodataka.autori.Count - 1 - accentIzbornoPolje1.SelectedIndex].preuzmiImePrezime();
			this.JeDodat = ProveravanjeSvihStavki();
		}
		
		protected void Button1Click(object sender, EventArgs e)
		{
			DodajAutora da = new DodajAutora();
			da.ShowDialog();
			if (da.JeDodat) {
				this.JeDodatAutor = true;
				accentIzbornoPolje1.Items.Clear();
				foreach (var a in MenadzmentPodataka.autori.ToArray().Reverse()) accentIzbornoPolje1.Items.Add(a.preuzmiImePrezime());
			}
			da.Dispose();
		}
		
		protected void AccentIzbornoPolje2SelektovanIndeksPromenjen(object sender, EventArgs e) {
			if (this.accentIzbornoPolje2.SelectedItem == null) return;
			this.knjiga.postaviIDIzdavaca(MenadzmentPodataka.izdavaci[MenadzmentPodataka.izdavaci.Count - 1 - accentIzbornoPolje2.SelectedIndex].preuzmiID());
			this.JeDodat = ProveravanjeSvihStavki();
		}
		
		protected void Button2Click(object sender, EventArgs e)
		{
			DodajIzdavaca di = new DodajIzdavaca();
			di.ShowDialog();
			if (di.JeDodat) {
				this.JeDodatIzdavac = true;
				accentIzbornoPolje2.Items.Clear();
				foreach (var a in MenadzmentPodataka.izdavaci.ToArray().Reverse()) accentIzbornoPolje2.Items.Add(a.preuzmiNaziv());
			}
			di.Dispose();
		}

		protected void AccentIzbornoPolje3SelektovanIndeksPromenjen(object sender, EventArgs e) {
			if (this.accentIzbornoPolje3.SelectedItem == null) return;
			switch (Podesavanja.koriscenjeUDK) {
				case UDK.UDK_Koriscenje.Nista:
					this.knjiga.postaviZanr(
						Konverzija.UDKKljucPrekoOsnovnogZanra(
							(EZanrKnjiga) (Enum.Parse(typeof(EZanrKnjiga), this.accentIzbornoPolje3.GetItemText(this.accentIzbornoPolje3.SelectedItem)))
						)
					);
					break;
				case UDK.UDK_Koriscenje.Osnovno:
					STR key = this.accentIzbornoPolje3.GetItemText(this.accentIzbornoPolje3.SelectedItem).Split('-').Last().Remove(0, 1);
					PIR keys = UDK.UDK_Lista.First(x => x.Value == key);
					this.knjiga.postaviZanr(keys.Key);
					break;
				case UDK.UDK_Koriscenje.Sve:
					key = this.accentIzbornoPolje3.GetItemText(this.accentIzbornoPolje3.SelectedItem).Split('-').Last().Remove(0, 1);
					keys = UDK.UDK_Lista.First(x => x.Value == key);
					this.knjiga.postaviZanr(keys.Key);
					break;
				default:
					// System.Diagnostics.Debug.WriteLine("Грешка.");
					break;
			}
			
			this.JeDodat = ProveravanjeSvihStavki();
		}

		protected void NaPritisnutTaster(object sender, KeyEventArgs e) {
			if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F5)) {
				this.accentPolje1.Clear();
				this.accentPolje2.Clear();
				this.accentPolje3.Clear();
				this.accentIzbornoPolje1.SelectedItem = null;
				this.accentIzbornoPolje1.Tekst = "";
				this.accentIzbornoPolje2.SelectedItem = null;
				this.accentIzbornoPolje2.Tekst = "";
				this.accentIzbornoPolje3.SelectedItem = null;
				this.accentIzbornoPolje3.Tekst = "";
				this.knjiga = new Knjiga();
				this.JeDodat = false;
				KorigujLabelu();
				if (e.KeyCode == Keys.Escape) this.Close();
			}
		}
		
		protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
		{
			if (JeDodat) {
				Knjige.Add(this.knjiga);
				try {
					Barkod.SacuvajBarkod("" + Knjige[Knjige.Count - 1].preuzmiID());
				} catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine(ex);
				}
				MenadzmentPodataka.knjigaPodaciCuvanje(Knjige, "knjige");
			}
			
			base.OnClosing(e);
		}
	}
}
