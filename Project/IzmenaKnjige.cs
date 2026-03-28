////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Linq;
using System.Windows.Forms;
using STR = System.String;
using PIR = System.Collections.Generic.KeyValuePair<string, string>;

namespace Project
{
	public partial class IzmenaKnjige : Form, IIzmena
	{
		private Knjiga knjiga;
		public bool _jeIzmenjena;
		
		public bool JeIzmenjen {
			get {
				return _jeIzmenjena;
			} set {
				_jeIzmenjena = value;
				KorigujLabelu();
			}
		}
		
		public IzmenaKnjige(ref Knjiga knjiga)
		{
			InitializeComponent();
			this.knjiga = knjiga;
			this._jeIzmenjena = false;

			this.KeyPreview = true;
			
			// DONE: Implementirati mogucnost uskladjivanja teme shodno podesavanjima
			this.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) {
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeForeColor<AccentPolje>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentPolje>(control, Colors.SvetlijaPozadina);
			}

			int index = -1;
			accentPolje1.Text = knjiga.preuzmiNaziv();
			foreach(var a in MenadzmentPodataka.autori) {
				accentIzbornoPolje1.Items.Add(a.preuzmiIme() + " " + a.preuzmiPrezime());
				if (a.preuzmiID() == knjiga.preuzmiIDAutora()) index = accentIzbornoPolje1.Items.Count - 1;
			}
			// accentIzbornoPolje1.Tekst = Autor.preuzmiImePrezime_ID(MenadzmentPodataka.autori.ToArray(), this.knjiga.preuzmiIDAutora());
			accentIzbornoPolje1.SelectedIndex = index;
			accentPolje2.Text = "" + knjiga.preuzmiBrojStrana();
			accentPolje3.Text = "" + knjiga.preuzmiGodinuIzdavanja();
			foreach (var a in MenadzmentPodataka.izdavaci) {
				accentIzbornoPolje2.Items.Add(a.preuzmiNaziv());
				if (a.preuzmiID() == knjiga.preuzmiIDIzdavaca()) index = accentIzbornoPolje2.Items.Count - 1;
			}
			// accentIzbornoPolje2.Tekst = Izdavac.preuzmiNaziv_ID(MenadzmentPodataka.izdavaci.ToArray(), knjiga.preuzmiIDIzdavaca());
			accentIzbornoPolje2.SelectedIndex = index;
			accentIzbornoPolje3.Tekst = knjiga.preuzmiRelativniZanr().ToString();
			// foreach (var zanrovi in Enum.GetNames(typeof(EZanrKnjiga))) accentIzbornoPolje3.Items.Add(zanrovi);
			UDK.PopuniAccentIzbornoPolje(this.accentIzbornoPolje3);
			this.knjigaUI1.Naziv = accentPolje1.Text;
			this.knjigaUI1.Autor = accentIzbornoPolje1.Tekst;
			this.knjigaUI1.GodinaIzdanja = knjiga.preuzmiGodinuIzdavanja();

			accentPolje1.TekstIzmenjen += new EventHandler(AccentPolje1_TekstIzmenjen);
			accentPolje2.TekstIzmenjen += new EventHandler(AccentPolje2_TekstIzmenjen);
			accentPolje3.TekstIzmenjen += new EventHandler(AccentPolje3_TekstIzmenjen);
			accentIzbornoPolje1.SelektovanIndeksPromenjen += new EventHandler(AccentIzbornoPolje1_SelektovanIndeksPromenjen);
			accentIzbornoPolje2.SelektovanIndeksPromenjen += new EventHandler(AccentIzbornoPolje2_SelektovanIndeksPromenjen);
			accentIzbornoPolje3.SelektovanIndeksPromenjen += new EventHandler(AccentIzbornoPolje3_SelektovanIndeksPromenjen);
			JeIzmenjen = false;
		}
		
		private void KorigujLabelu() {
			label1.ForeColor = JeIzmenjen ? Colors.BookColor2 : Colors.AccentColor;
			label1.Text = JeIzmenjen ? "Затворите овај прозор како бисте сачували књигу" : (IspunjavaUsloveZaIzmenu() ? "Унесите измену" : "Попуните сва поља");
		}

		protected void AccentPolje1_TekstIzmenjen(object sender, EventArgs e) {
			this.knjigaUI1.Naziv = accentPolje1.Text;
			this.JeIzmenjen = IspunjavaUsloveZaIzmenu();
		}

		protected void AccentPolje2_TekstIzmenjen(object sender, EventArgs e) {
			this.JeIzmenjen = IspunjavaUsloveZaIzmenu();
		}

		protected void AccentPolje3_TekstIzmenjen(object sender, EventArgs e) {
			this.knjigaUI1.GodinaIzdanja = accentPolje3.Text.Length == 0 ? 0 : int.Parse(accentPolje3.Tekst);
			this.JeIzmenjen = IspunjavaUsloveZaIzmenu();
		}

		protected void AccentIzbornoPolje1_SelektovanIndeksPromenjen(object cender, EventArgs e) {
			if (this.accentIzbornoPolje1.SelectedItem == null) return;
			this.knjigaUI1.Autor = MenadzmentPodataka.autori[accentIzbornoPolje1.SelectedIndex].preuzmiImePrezime();
			this.JeIzmenjen = IspunjavaUsloveZaIzmenu();
		}
		
		protected void AccentIzbornoPolje2_SelektovanIndeksPromenjen(object sender, EventArgs e) {
			this.JeIzmenjen = IspunjavaUsloveZaIzmenu();
		}

		protected void AccentIzbornoPolje3_SelektovanIndeksPromenjen(object sender, EventArgs e) {
			this.JeIzmenjen = IspunjavaUsloveZaIzmenu();
		}

		private bool IspunjavaUsloveZaIzmenu() {
			return (!String.IsNullOrEmpty(accentPolje1.Text) && 
			        !String.IsNullOrEmpty(accentPolje2.Text) && 
			        !String.IsNullOrEmpty(accentPolje3.Text) && 
			        accentIzbornoPolje1.Tekst != "" && 
			        accentIzbornoPolje2.Tekst != "" && 
			        accentIzbornoPolje3.Tekst != ""
			       );
		}

		protected void NaPritisnutTaster(object sender, KeyEventArgs e) {
			if ((e.KeyCode == Keys.Escape) || (e.KeyCode == Keys.F5)) {
				this.accentPolje1.Text = this.knjiga.preuzmiNaziv();
				this.accentPolje2.Text = "" + this.knjiga.preuzmiBrojStrana();
				this.accentPolje3.Text = "" + this.knjiga.preuzmiGodinuIzdavanja();
				this.accentIzbornoPolje1.SelectedItem = null;
				accentIzbornoPolje1.Tekst = Autor.preuzmiImePrezime_ID(MenadzmentPodataka.autori.ToArray(), this.knjiga.preuzmiIDAutora());
				this.accentIzbornoPolje2.SelectedItem = null;
				accentIzbornoPolje2.Tekst = Izdavac.preuzmiNaziv_ID(MenadzmentPodataka.izdavaci.ToArray(), knjiga.preuzmiIDIzdavaca());
				this.accentIzbornoPolje3.SelectedItem = null;
				accentIzbornoPolje3.Tekst = knjiga.preuzmiRelativniZanr().ToString();
				this.JeIzmenjen = false;
				KorigujLabelu();

				if (e.KeyCode == Keys.Escape) this.Close();
			}
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
			if (JeIzmenjen) {
				this.knjiga.postaviNaziv(accentPolje1.Text);
				this.knjiga.postaviBrojStrana(int.Parse(accentPolje2.Tekst));
				this.knjiga.postaviGodinuIzdavanja(accentPolje3.Text.Length == 0 ? 0 : int.Parse(accentPolje3.Tekst));
				this.knjiga.postaviIDAutora(MenadzmentPodataka.autori[accentIzbornoPolje1.SelectedIndex].preuzmiID());
				this.knjiga.postaviIDIzdavaca(MenadzmentPodataka.izdavaci[accentIzbornoPolje2.SelectedIndex].preuzmiID());
				if (accentIzbornoPolje3.SelectedItem != null) {
					switch (Podesavanja.koriscenjeUDK) {
						case UDK.UDK_Koriscenje.Nista:
							this.knjiga.postaviZanr(
								Konverzija.UDKKljucPrekoOsnovnogZanra(
									(EZanrKnjiga) (Enum.Parse(typeof(EZanrKnjiga), this.accentIzbornoPolje3.GetItemText(this.accentIzbornoPolje3.SelectedItem)))
								)
							);
							break;
						case UDK.UDK_Koriscenje.Osnovno:
							{
								STR key = this.accentIzbornoPolje3.GetItemText(this.accentIzbornoPolje3.SelectedItem).Split('-').Last().Remove(0, 1);
								PIR keys = UDK.UDK_Lista.First(x => x.Value == key);
								this.knjiga.postaviZanr(keys.Key);
							}
							break;
						case UDK.UDK_Koriscenje.Sve:
							{
								STR key = this.accentIzbornoPolje3.GetItemText(this.accentIzbornoPolje3.SelectedItem).Split('-').Last().Remove(0, 1);
								PIR keys = UDK.UDK_Lista.First(x => x.Value == key);
								this.knjiga.postaviZanr(keys.Key);
							}
							break;
						default:
							// System.Diagnostics.Debug.WriteLine("Грешка.");
							break;
					}
				}
				
				for(int i = 0; i < MenadzmentPodataka.knjige.Count; i++) if (MenadzmentPodataka.knjige[i].preuzmiID() == knjiga.preuzmiID()) MenadzmentPodataka.knjige[i] = knjiga;
				MenadzmentPodataka.knjigaPodaciCuvanje(MenadzmentPodataka.knjige, "knjige");
			}
			
			base.OnClosing(e);
		}
	}
}
