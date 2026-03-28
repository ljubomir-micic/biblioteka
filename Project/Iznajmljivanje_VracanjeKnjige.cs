////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;

namespace Project
{
	public partial class Iznajmljivanje_VracanjeKnjige : Form
	{
		private bool seIznajmljuje;
		private Knjiga knjiga;
		private Clan clan;
		private Korisnik korisnik;
		private bool jeIznajmljena = false;
		
		private List<ArhivaIznajmljivanja> Arhiva {
			get {
				return MenadzmentPodataka.arhiva;
			} set {
				MenadzmentPodataka.arhiva = value;
			}
		}

		public bool SeIznajmljuje {
			get {
				return this.seIznajmljuje;
			} set {
				this.seIznajmljuje = value;
				this.Text = "Библиотека: " + (value ? "Изнајмљивање књиге" : "Враћање књиге");
				this.iznajmljivanjePanel.Visible = value;
				this.vracanjePanel.Visible = !value;
			}
		}
		
		public bool Zastava {
			get {
				return jeIznajmljena;
			} set {
				jeIznajmljena = value;
			}
		}
		
		public Iznajmljivanje_VracanjeKnjige(ref Knjiga knjiga, Korisnik korisnik)
		{
			InitializeComponent();

			this.iznajmljivanjePanel.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) {
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeForeColor<GroupBox>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentDugme>(control, Colors.AccentColor);
			}
			
			this.knjiga = knjiga;
			this.korisnik = korisnik;
			this.knjigaUI1.Naziv = knjiga.preuzmiNaziv();
			this.knjigaUI1.Autor = Autor.preuzmiImePrezime_ID(MenadzmentPodataka.autori.ToArray(), this.knjiga.preuzmiIDAutora());
			this.knjigaUI1.GodinaIzdanja = knjiga.preuzmiGodinuIzdavanja();
			this.label6.Text = this.knjigaUI1.Autor;
			this.label1.Text = this.knjiga.preuzmiNaziv();
			this.SeIznajmljuje = true;
			foreach (var i in MenadzmentPodataka.clanovi) accentIzbornoPolje1.Items.Add(i.preuzmiIme() + " " + i.preuzmiPrezime());
			this.accentDugme1.Enabled = false;
			this.accentDugme1.Click += new EventHandler(OnFinishClick);
		}
		
		void AccentIzbornoPolje1SelektovanIndeksPromenjen(object sender, EventArgs e)
		{
			this.clan = MenadzmentPodataka.clanovi[accentIzbornoPolje1.SelectedIndex];
			label2.Text = "Име:            " + clan.preuzmiIme();
			label3.Text = "Презиме:        " + clan.preuzmiPrezime();
			label4.Text = "ЈМБГ:           " + clan.preuzmiJMBG();
			label5.Text = "Година рођења:  " + clan.preuzmiGodinuRodjenja();
			this.accentDugme1.Enabled = clan.pozicijaSlobodnogIznajmljivanja() != -1;
		}

		void OnFinishClick(object sender, EventArgs e) {
			try {
				if (SeIznajmljuje) {
					if (!(korisnik == null || knjiga == null || clan == null)) {
						Arhiva.Add(new ArhivaIznajmljivanja(this.knjiga.preuzmiID(), this.clan.preuzmiID(), this.korisnik.preuzmiID(), EIznajmljivanjeVracanje.Iznajmljena, DateTime.Now));
						MenadzmentPodataka.arhivaIznajmljivanjaPodaciCuvanje(Arhiva, "arhiva");
						this.clan.postaviIznajmljenuKnjigu(this.clan.pozicijaSlobodnogIznajmljivanja(), Arhiva.Last().preuzmiIDKnjige());
						this.knjiga.postaviStatusIznajmljena(true);
						MenadzmentPodataka.clanPodaciCuvanje(MenadzmentPodataka.clanovi, "clanovi");
						MenadzmentPodataka.knjigaPodaciCuvanje(MenadzmentPodataka.knjige, "knjige");
						Zastava = true;
						this.Close();
					}
				} else {

				}
			} catch (Exception ex) {
				 System.Diagnostics.Debug.WriteLine(ex);
			}
		}
	}
}
