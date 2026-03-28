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
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Project.Alati;
using STR = System.String;

namespace Project
{
	public partial class InicijalnaPodesavanja : Form
	{
		public enum TipPodesavanja {
			Quick,
			Full
		}
		
		private TipPodesavanja tip = TipPodesavanja.Quick;
		private bool close = false;
		
		public List<Autor> Autori {
			get { return MenadzmentPodataka.autori; }
			set { MenadzmentPodataka.autori = value; }
		}

		public List<Izdavac> Izdavaci {
			get { return MenadzmentPodataka.izdavaci; }
			set { MenadzmentPodataka.izdavaci = value; }
		}
		
		public List<Knjiga> Knjige {
			get {
				return MenadzmentPodataka.knjige;
			}
			set {
				MenadzmentPodataka.knjige = value;
				Invalidate();
			}
		}
		
		public List<Korisnik> Korisnici {
			get { return MenadzmentPodataka.korisnici; }
			set { MenadzmentPodataka.korisnici = value; }
		}

		public InicijalnaPodesavanja()
		{
			InitializeComponent();

			this.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) {
				Colors.BojenjeBackColor<AccentDugme>(control, Colors.AccentColor);
				Colors.BojenjeBackColor<Panel>(control, Colors.SvetlijaPozadina);
				Colors.BojenjeBackColor<AccentLista>(control, Colors.SvetlijaPozadina);
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentPolje>(control, Colors.SvetlijaPozadina);
				Colors.BojenjeForeColor<AccentPolje>(control, Colors.BojaTeksta);
			}
			
			OnViewUpdate();
			accentPolje14.MaksimalanBrojKaraktera = int.MaxValue;
			accentPolje16.MaksimalanBrojKaraktera = int.MaxValue;
			foreach (var enumType in Enum.GetValues(typeof(EZanrKnjiga)).Cast<EZanrKnjiga>().ToArray()) {
				accentIzbornoPolje3.Items.Add(enumType);
			}
		}
		
		// DONE: Ukoliko ne postoji aplikacija se ne pokrece
		public static void inicijalnoPodesavanjeREGEDIT() {
			RegistryKey registriKljuc = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Библиотека");
			foreach (STR kljuc in Podesavanja.podesavanja.Keys.ToArray()) registriKljuc.SetValue(kljuc, Podesavanja.podesavanja[kljuc]);
			registriKljuc.SetValue("UDK", (int) Podesavanja.koriscenjeUDK);
			registriKljuc.Close(); 
		}
		
		void RadioButton1CheckedChanged(object sender, EventArgs e)
		{
			tip = radioButton1.Checked ? TipPodesavanja.Quick : TipPodesavanja.Full;
			OnViewUpdate();
		}
		
		void AccentDugme1Click(object sender, EventArgs e)
		{
			if (accentTacke1.JeAktivna == 0) {
				MenadzmentPodataka.AppDataBiblioteka();
			}
			
			if (accentTacke1.JeAktivna == 2) {
				MenadzmentPodataka.korisnikPodaciCuvanje(Korisnici, "korisnici");
			}
			
			if (accentTacke1.JeAktivna == 3) {
				MenadzmentPodataka.autorPodaciCuvanje(Autori, "autori");
			}
			
			if (accentTacke1.JeAktivna == 4) {
				MenadzmentPodataka.izdavacPodaciCuvanje(Izdavaci, "izdavaci");
			}
			
			if (accentTacke1.JeAktivna == 5) {
				MenadzmentPodataka.knjigaPodaciCuvanje(Knjige, "knjige");
			}
			
			if (accentTacke1.JeAktivna == accentTacke1.BrojTacaka - 1) {
				close = true;
			} else {
				accentTacke1.JeAktivna += 1;
			}
			OnViewUpdate();
			
			if (close) {
				Application.Restart();
			}
		}
		
		void Application_ThreadExit(object sender, EventArgs e) {
			MenadzmentPodataka.OtvoriFormu();
		}
		
		void AccentDugme2Click(object sender, EventArgs e)
		{
			accentTacke1.JeAktivna -= 1;
			OnViewUpdate();
		}
		
		void AccentDugme3Click(object sender, EventArgs e)
		{
			try {
				if (accentPolje1.Text == String.Empty || accentPolje2.Text == String.Empty || accentPolje3.Text == String.Empty || accentPolje4.Text == String.Empty || accentPolje5.Text == String.Empty) throw new InvalidCastException();
				Korisnici.Add(new Korisnik(accentPolje1.Text, accentPolje2.Text, accentPolje3.Text, accentPolje4.Text, int.Parse(accentPolje5.Text)));
				accentLista1.Items.Add(accentPolje1.Text + " " + accentPolje2.Text);
				OnViewUpdate();
				this.accentLista1.SelectedIndex = accentLista1.Items.Count - 1;
				accentPolje1.Text = "";
				accentPolje2.Text = "";
				accentPolje3.Text = "";
				accentPolje4.Text = "";
				accentPolje5.Text = "";
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine("" + ex);
			}
		}
		
		void AccentDugme4Click(object sender, EventArgs e)
		{
			try {
				if (accentPolje10.Text == String.Empty || accentPolje9.Text == String.Empty || accentPolje8.Text == String.Empty || accentPolje7.Text == String.Empty) throw new InvalidCastException();
				Autori.Add(new Autor(accentPolje10.Text, accentPolje9.Text, int.Parse(accentPolje8.Text), int.Parse(accentPolje7.Text)));
				accentLista2.Items.Add(accentPolje10.Text + " " + accentPolje9.Text);
				accentIzbornoPolje1.Items.Add(accentPolje10.Text + " " + accentPolje9.Text);
				OnViewUpdate();
				this.accentLista2.SelectedIndex = accentLista2.Items.Count - 1;
				accentPolje7.Text = "";
				accentPolje8.Text = "";
				accentPolje9.Text = "";
				accentPolje10.Text = "";
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine("" + ex);
			}
		}
		
		void AccentDugme6Click(object sender, EventArgs e)
		{
			try {
				if (accentPolje15.Text == String.Empty || accentPolje14.Text == String.Empty || accentPolje16.Text == String.Empty || accentPolje6.Text == String.Empty) throw new InvalidCastException();
				Izdavaci.Add(new Izdavac(accentPolje15.Text, int.Parse(accentPolje14.Text), int.Parse(accentPolje16.Text), int.Parse(accentPolje6.Text)));
				accentLista4.Items.Add(accentPolje15.Text);
				accentIzbornoPolje2.Items.Add(accentPolje15.Text);
				OnViewUpdate();
				this.accentLista4.SelectedIndex = accentLista4.Items.Count - 1;
				accentPolje15.Text = "";
				accentPolje14.Text = "";
				accentPolje16.Text = "";
				accentPolje6.Text = "";
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine("" + ex);
			}
		}
		
		void AccentDugme5Click(object sender, EventArgs e)
		{
			try {
				if (accentPolje13.Text == String.Empty || accentIzbornoPolje1.Tekst == String.Empty || accentIzbornoPolje2.Tekst == String.Empty || accentIzbornoPolje3.Tekst == String.Empty || accentPolje12.Text == String.Empty || accentPolje11.Text == String.Empty) throw new InvalidCastException();
				Knjige.Add(new Knjiga(accentPolje13.Text, Autori[accentIzbornoPolje1.SelectedIndex].preuzmiID(), Izdavaci[accentIzbornoPolje2.SelectedIndex].preuzmiID(), int.Parse(accentPolje12.Text), int.Parse(accentPolje11.Text), Konverzija.UDKKljucPrekoOsnovnogZanra((EZanrKnjiga) (Enum.Parse(typeof(EZanrKnjiga), this.accentIzbornoPolje3.GetItemText(this.accentIzbornoPolje3.SelectedItem))))));
				accentLista3.Items.Add(accentPolje13.Text);
				OnViewUpdate();
				this.accentLista3.SelectedIndex = accentLista3.Items.Count - 1;
				accentPolje13.Text = "";
				accentPolje12.Text = "";
				accentPolje11.Text = "";
				accentIzbornoPolje1.Tekst = "";
				accentIzbornoPolje2.Tekst = "";
				accentIzbornoPolje3.Tekst = "";
				Barkod.SacuvajBarkod("" + Knjige[Knjige.Count - 1].preuzmiID());
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine("" + ex);
			}
		}
		
		void OnViewUpdate() {
			panel2.Visible = accentTacke1.JeAktivna == 0;
			panel1.Visible = accentTacke1.JeAktivna == 1;
			panel3.Visible = accentTacke1.JeAktivna == 2;
			panel4.Visible = accentTacke1.JeAktivna == 3;
			panel6.Visible = accentTacke1.JeAktivna == 4;
			panel5.Visible = accentTacke1.JeAktivna == 5;
			accentTacke1.BrojTacaka = tip == TipPodesavanja.Quick ? 3 : 6;
			accentTacke1.Location = new Point((this.Width - accentTacke1.Width - 6) / 2, accentTacke1.Location.Y);
			accentDugme1.Text = (accentTacke1.JeAktivna != accentTacke1.BrojTacaka - 1) ? "Настави" : "Заврши";
			accentDugme1.Enabled = !((accentTacke1.JeAktivna == 2 && accentLista1.Items.Count == 0) || (accentTacke1.JeAktivna == 3 && accentLista2.Items.Count == 0) || (accentTacke1.JeAktivna == 4 && accentLista4.Items.Count == 0) || (accentTacke1.JeAktivna == 5 && accentLista3.Items.Count == 0));
			accentDugme2.Visible = accentTacke1.JeAktivna != 0;
		}
	}
}
