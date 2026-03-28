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
using Project.Alati;
using CEBR = System.Int32;
using TAC = System.Boolean;
using DECF = System.Single;
using STR = System.String;

namespace Project
{
	public partial class Form1 : Form
	{
		public enum SortiranjeKnjiga {
			Датум_додавања,
			Назив_књиге,
			UDK_број
		}

		// Promenljive
		private TAC _jeUlogovan;
		private TAC sigurnosniKljuc;
		private TAC JeIzmenjenaKnjiga;
		private TAC JeIzmenjenAutor;
		private TAC JeIzmenjenIzdavac;
		private TAC JeIzmenjenClan;
		private Knjiga knjiga;
		private Autor autor;
		private Izdavac izdavac;
		private Clan clan;
		private List<KnjigaInfoUI> knjigaInfoUI;
		private List<AutorUI> autorUI;
		private List<IzdavacUI> izdavacUI;
		private List<ClanUI> clanUI;
		private AccentKrugOpcija[] accentKrugOpcija;
		private CEBR marginaKomponenti;
		private CEBR viewPicker;
		private DECF procenatVisinePanela = 0.9546f;

		private Korisnik Korisnik {
			get {
				return Podesavanja.korisnik;
			} set {
				Podesavanja.korisnik = value;
			}
		}
		
		public TAC JeUlogovan {
			get {
				return _jeUlogovan;
			}
			
			set {
				this._jeUlogovan = value;
				this.logout_button.Visible = _jeUlogovan;
				this.settings_button.Visible = _jeUlogovan;
				this.option_list.Visible = _jeUlogovan;
				this.PostaviVidljivPanel();
				this.Text = _jeUlogovan ? "Библиотека" : "Библиотека: Пријава";
				this.optionlist_highlight.Visible = _jeUlogovan;
				this.option_list1.Visible = _jeUlogovan;
				this.option_list2.Visible = _jeUlogovan;
				this.option_list3.Visible = _jeUlogovan;
				this.option_list4.Visible = _jeUlogovan;
				this.textBox1.Clear();
				this.textBox2.Clear();
			}
		}
		
		public List<ArhivaIznajmljivanja> Arhiva {
			get { return MenadzmentPodataka.arhiva; }
			set { MenadzmentPodataka.arhiva = value; }
		}
		
		public List<Autor> Autori {
			get { return MenadzmentPodataka.autori; }
			set { MenadzmentPodataka.autori = value; }
		}

		public List<Clan> Clanovi {
			get { return MenadzmentPodataka.clanovi; }
			set { MenadzmentPodataka.clanovi = value; }
		}

		public List<Izdavac> Izdavaci {
			get { return MenadzmentPodataka.izdavaci; }
			set { MenadzmentPodataka.izdavaci = value; }
		}
		
		public List<Knjiga> Knjige {
			get { return MenadzmentPodataka.knjige; }
			set { MenadzmentPodataka.knjige = value; }
		}
		
		public List<Korisnik> Korisnici {
			get { return MenadzmentPodataka.korisnici; }
			set { MenadzmentPodataka.korisnici = value; }
		}
		
		public void IzmeniOmiljenStatusKnjige(CEBR id) {
			foreach(var knjiga in this.Knjige) if (knjiga.preuzmiID() == id) knjiga.postaviStatusOmiljeno(!knjiga.preuzmiStatusOmiljeno());
		}
		
		void GenerisanjeKnjigaUI(CEBR index) {
			this.knjigaInfoUI.Add(new Project.KnjigaInfoUI(Knjige[index], Autori));
			this.SuspendLayout();
			CEBR i = knjigaInfoUI.Count - 1;
			// DONE: knjigaPoRedu neocekivano utice, pored broja knjiga po redu, na broj knjiga po koloni
			CEBR knjigaPoRedu = (this.evidencijaKnjiga_panel.Width - 2 * marginaKomponenti) / this.knjigaInfoUI[i].Width;
			CEBR horizRazmakKnjiga = (this.evidencijaKnjiga_panel.Width - 2 * marginaKomponenti - knjigaPoRedu * this.knjigaInfoUI[i].Width) / knjigaPoRedu / 2;
			CEBR vertRazmakKnjiga = 20;
			// DONE: koristeci knjigaPoRedu dodati taj broj knjigaInfoUI po redu
			// OLD_COMMAND: this.knjigaInfoUI[index].Width * (index % 3) + (this.evidencijaKnjiga_panel.Width - this.knjigaInfoUI[index].Width * 3) / 3, (81 + 167 * ((index/3) % 3) + 20 * ((index/3) % 3))
			// OLD_COMMAND: this.marginaKomponenti + this.knjigaInfoUI[index].Width + index * horizRazmakKnjiga + (index % knjigaPoRedu != 0 ? (index + 1) * horizRazmakKnjiga : 0), (marginaKomponenti + this.knjigaInfoUI[index].Height * ((index/knjigaPoRedu) % knjigaPoRedu) + vertRazmakKnjiga * ((index/knjigaPoRedu) % knjigaPoRedu))
			// OLD_COMMAND: this.knjigaInfoUI[index].Width * (index % knjigaPoRedu) + (this.evidencijaKnjiga_panel.Width - this.knjigaInfoUI[index].Width * knjigaPoRedu) / knjigaPoRedu, (marginaKomponenti + this.knjigaInfoUI[index].Height * ((index/knjigaPoRedu) % knjigaPoRedu) + 20 * ((index/knjigaPoRedu) % knjigaPoRedu))
			this.knjigaInfoUI[i].Location = new System.Drawing.Point(marginaKomponenti + (i % knjigaPoRedu) * 2 * horizRazmakKnjiga + horizRazmakKnjiga / knjigaPoRedu + (i % knjigaPoRedu) * this.knjigaInfoUI[i].Width, (marginaKomponenti + this.knjigaInfoUI[i].Height * (i / knjigaPoRedu) + vertRazmakKnjiga * (i / knjigaPoRedu)));
			this.knjigaInfoUI[i].Name = "knjigaInfoUI[" + i + "]";
			this.knjigaInfoUI[i].Size = new System.Drawing.Size(167, 261);
			this.knjigaInfoUI[i].TabIndex = 2;
			this.knjigaInfoUI[i].ForeColor = Colors.BojaTeksta;
			this.knjigaInfoUI[i].Click += new EventHandler(KnjigaPritisnuta);
			this.knjigaInfoUI[i].Click += delegate {
				this.Cursor = Cursors.Default;
				this.accentKrugOpcija[viewPicker - 1].Visible = false;
			};
			this.knjigaInfoUI[i].JeOmiljenStatusJeIzmenjen += new EventHandler(JeOmiljenStatusJeIzmenjen);
			this.knjigaInfoUI[i].KnjigaSeBrise += new EventHandler(ObjekatSeBrise<KnjigaInfoUI>);
			this.evidencijaKnjiga_panel.Controls.Add(this.knjigaInfoUI[i]);
			this.Form1Resize(this, new EventArgs());
			if (sigurnosniKljuc) this.TipSortiranjaPromenjen(this, new EventArgs());
		}
		
		// BELESKA: Ne menjati redosled liste this.knjigaInfoUI
		void PromeniRedosledKnjiga() {
			if (accentPolje1.Text.Length > 0) return;
			List<KnjigaInfoUI> knjigaInfoUI = new List<KnjigaInfoUI>();
			
			for (CEBR i = 0; i < this.knjigaInfoUI.Count; i++) {
				if (this.knjigaInfoUI[i].JeOmiljena) {
					knjigaInfoUI.Add(this.knjigaInfoUI[i]);
				}
			}
			
			for (CEBR i = 0; i < this.knjigaInfoUI.Count; i++) {
				if (!this.knjigaInfoUI[i].JeOmiljena) {
					knjigaInfoUI.Add(this.knjigaInfoUI[i]);
				}
			}
			
			for (CEBR i = 0; i < knjigaInfoUI.Count; i++) this.IzmenaRedosledaKomponente<KnjigaInfoUI>(knjigaInfoUI, i, i);
		}

		void GenerisanjeAutorUI(CEBR index) {
			this.autorUI.Add(new Project.AutorUI(Autori[index]));
			this.SuspendLayout();
			CEBR i = autorUI.Count - 1;
			CEBR autorPoRedu = (this.evidencijaAutora_panel.Width - 2 * marginaKomponenti) / this.autorUI[i].Width;
			CEBR horizRazmakAutora = (this.evidencijaAutora_panel.Width - 2 * marginaKomponenti - autorPoRedu * this.autorUI[i].Width) / autorPoRedu / 2;
			CEBR vertRazmakAutora = 20;
			this.autorUI[i].Location = new System.Drawing.Point(marginaKomponenti + (i % autorPoRedu) * 2 * horizRazmakAutora + horizRazmakAutora / autorPoRedu + (i % autorPoRedu) * this.autorUI[i].Width, (marginaKomponenti + this.autorUI[i].Height * (i / autorPoRedu) + vertRazmakAutora * (i / autorPoRedu)));
			this.autorUI[i].Name = "autorUI[" + i + "]";
			this.autorUI[i].Size = new System.Drawing.Size(167, 200);
			this.autorUI[i].TabIndex = 2;
			this.autorUI[i].ForeColor = Colors.BojaTeksta;
			this.autorUI[i].Click += new EventHandler(AutorPritisnut);
			this.autorUI[i].Click += delegate {
				this.Cursor = Cursors.Default;
				this.accentKrugOpcija[viewPicker - 1].Visible = false;
			};
			this.autorUI[i].AutorSeBrise += new EventHandler(ObjekatSeBrise<AutorUI>);
			this.evidencijaAutora_panel.Controls.Add(this.autorUI[i]);
			this.Form1Resize(this, new EventArgs());
		}

		void GenerisanjeIzdavacUI(CEBR index) {
			this.izdavacUI.Add(new Project.IzdavacUI(Izdavaci[index]));
			this.SuspendLayout();
			CEBR i = izdavacUI.Count - 1;
			CEBR izdavacPoRedu = (this.evidencijaIzdavaca_panel.Width - 2 * marginaKomponenti) / this.izdavacUI[i].Width;
			CEBR horizRazmakIzdavaca = (this.evidencijaIzdavaca_panel.Width - 2 * marginaKomponenti - izdavacPoRedu * this.izdavacUI[i].Width) / izdavacPoRedu / 2;
			CEBR vertRazmakIzdavaca = 20;
			this.izdavacUI[i].Location = new System.Drawing.Point(marginaKomponenti + (i % izdavacPoRedu) * 2 * horizRazmakIzdavaca + horizRazmakIzdavaca / izdavacPoRedu + (i % izdavacPoRedu) * this.izdavacUI[i].Width, (marginaKomponenti + this.izdavacUI[i].Height * (i / izdavacPoRedu) + vertRazmakIzdavaca * (i / izdavacPoRedu)));
			this.izdavacUI[i].Name = "izdavacUI[" + i + "]";
			this.izdavacUI[i].Size = new System.Drawing.Size(167, 200);
			this.izdavacUI[i].TabIndex = 2;
			this.izdavacUI[i].ForeColor = Colors.BojaTeksta;
			this.izdavacUI[i].Click += new EventHandler(IzdavacPritisnut);
			this.izdavacUI[i].Click += delegate {
				this.Cursor = Cursors.Default;
				this.accentKrugOpcija[viewPicker - 1].Visible = false;
			};
			this.izdavacUI[i].IzdavacSeBrise += new EventHandler(ObjekatSeBrise<IzdavacUI>);
			this.evidencijaIzdavaca_panel.Controls.Add(this.izdavacUI[i]);
			this.Form1Resize(this, new EventArgs());
		}

		void GenerisanjeClanUI(CEBR index) {
			this.clanUI.Add(new Project.ClanUI(Clanovi[index]));
			this.SuspendLayout();
			CEBR i = clanUI.Count - 1;
			CEBR clanPoRedu = (this.evidencijaClanova_panel.Width - 2 * marginaKomponenti) / this.clanUI[i].Width;
			CEBR horizRazmakClanova = (this.evidencijaClanova_panel.Width - 2 * marginaKomponenti - clanPoRedu * this.clanUI[i].Width) / clanPoRedu / 2;
			CEBR vertRazmakClanova = 20;
			this.clanUI[i].Location = new System.Drawing.Point(marginaKomponenti + (i % clanPoRedu) * 2 * horizRazmakClanova + horizRazmakClanova / clanPoRedu + (i % clanPoRedu) * this.clanUI[i].Width, (marginaKomponenti + this.clanUI[i].Height * (i / clanPoRedu) + vertRazmakClanova * (i / clanPoRedu)));
			this.clanUI[i].Name = "clanUI[" + i + "]";
			this.clanUI[i].Size = new System.Drawing.Size(167, 200);
			this.clanUI[i].TabIndex = 2;
			this.clanUI[i].ForeColor = Colors.BojaTeksta;
			this.clanUI[i].Click += new EventHandler(ClanPritisnut);
			this.clanUI[i].Click += delegate {
				this.Cursor = Cursors.Default;
				this.accentKrugOpcija[viewPicker - 1].Visible = false;
			};
			this.clanUI[i].ClanSeBrise += new EventHandler(ObjekatSeBrise<ClanUI>);
			this.evidencijaClanova_panel.Controls.Add(this.clanUI[i]);
			this.Form1Resize(this, new EventArgs());
		}

		void PromeniRedosledClanova() {
			if (accentPolje4.Text.Length > 0) return;
			List<ClanUI> clanUI = new List<ClanUI>();
			
			for (CEBR i = 0; i < this.clanUI.Count; i++) {
				if (this.clanUI[i].JeProsaoRok) {
					clanUI.Add(this.clanUI[i]);
				}
			}
			
			for (CEBR i = 0; i < this.clanUI.Count; i++) {
				if (!this.clanUI[i].JeProsaoRok) {
					clanUI.Add(this.clanUI[i]);
				}
			}
			
			for (CEBR i = 0; i < clanUI.Count; i++) this.IzmenaRedosledaKomponente<ClanUI>(clanUI, i, i);
		}
		
		void IzmenaRedosledaKomponente<Tip>(List<Tip> komponente, CEBR index, CEBR novoMesto) where Tip : UserControl, IObjekatUI {
			try {
				CEBR komponenataPoRedu = (komponente[index].Parent.Width - 2 * marginaKomponenti) / komponente[index].Width;
				CEBR hRazmakKomponenti = (komponente[index].Parent.Width - 2 * marginaKomponenti - komponenataPoRedu * komponente[index].Width) / komponenataPoRedu / 2;
				CEBR vRazmakKomponenti = 20;
				komponente[index].Location = new System.Drawing.Point(marginaKomponenti + (novoMesto % komponenataPoRedu) * 2 * hRazmakKomponenti + hRazmakKomponenti / komponenataPoRedu + (novoMesto % komponenataPoRedu) * komponente[index].Width, (marginaKomponenti + komponente[index].Height * (novoMesto / komponenataPoRedu) + vRazmakKomponenti * (novoMesto / komponenataPoRedu)));
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine(ex);
			}
		}
		
		void PostaviKruzniOblikDugmeta(Button dugme) {
			GraphicsPath path = new GraphicsPath();
			path.StartFigure();
			path.AddEllipse(new RectangleF(0, 0, dugme.Width, dugme.Height));
			path.CloseFigure();
			
			Region r = new Region(path);
			dugme.Region = r;
		}

		void VratiPodrazumevaneVrednosti(CEBR i) {
			this.Cursor = Cursors.Default;
			this.accentKrugOpcija[i].Visible = false;
		}

		public Form1()
		{
			InitializeComponent();
			
			// Prilagodjavanje boja
			this.Form1_PostaviIzgled();
			this.optionlist_highlight.Height = option_list1.Height;
			this.optionlist_highlight.Location = new Point(0, 0);
			this.optionlist_highlight.Top = option_list1.Top;
			this.optionlist_highlight.Visible = false;
			this.Invalidate();
			this.sortirajKnjigeDugme.Select();
			this.textBox1.Select();
			
			this.KeyPreview = true;
			
			// Inicijalizacija promenljivih
			this.viewPicker = 1;
			this._jeUlogovan = false;
			this.sigurnosniKljuc = true;
			this.JeIzmenjenaKnjiga = false;
			this.JeIzmenjenAutor = false;
			this.JeIzmenjenIzdavac = false;
			this.JeIzmenjenClan = false;
			this.knjigaInfoUI = new List<KnjigaInfoUI>();
			this.autorUI = new List<AutorUI>();
			this.izdavacUI = new List<IzdavacUI>();
			this.clanUI = new List<ClanUI>();
			this.login_panel.BringToFront();
			this.marginaKomponenti = 81;
			this.PostaviKruzniOblikDugmeta(this.logout_button);
			this.PostaviKruzniOblikDugmeta(this.settings_button);
			this.accentPolje1.TekstIzmenjen += new EventHandler(TekstJeIzmenjen);
			this.evidencijaAutora_panel.AutoScroll = true;
			this.evidencijaClanova_panel.AutoScroll = true;
			this.evidencijaIzdavaca_panel.AutoScroll = true;
			this.evidencijaKnjiga_panel.AutoScroll = true;
			this.evidencijaKnjiga_panel.MouseDown += new MouseEventHandler(Panel_MisDole);
			this.evidencijaAutora_panel.MouseDown += new MouseEventHandler(Panel_MisDole);
			this.evidencijaIzdavaca_panel.MouseDown += new MouseEventHandler(Panel_MisDole);
			this.evidencijaClanova_panel.MouseDown += new MouseEventHandler(Panel_MisDole);
			this.knjigaUI1.Region = new Region(Oblik.ZaobljeniPravougaonik(knjigaUI1.ClientRectangle, 4));
			{
                System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
                graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.pictureBox1.ClientRectangle);
                graphicsPath.CloseFigure();
                this.pictureBox1.Region = new Region(graphicsPath);
				graphicsPath.Reset();
				graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.pictureBox2.ClientRectangle);
                graphicsPath.CloseFigure();
                this.pictureBox2.Region = new Region(graphicsPath);
				graphicsPath.Reset();
				graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.pictureBox3.ClientRectangle);
                graphicsPath.CloseFigure();
                this.pictureBox3.Region = new Region(graphicsPath);
            }
			
			this.SuspendLayout();
			this.accentKrugOpcija = new AccentKrugOpcija[4];
			for (CEBR i = 0; i < accentKrugOpcija.Length; i++) {
				this.accentKrugOpcija[i] = new AccentKrugOpcija();
				this.accentKrugOpcija[i].Name = "accentKrugOpcija";
				if (i == 0) this.accentKrugOpcija[i].DodajOpciju("Pretrazi knjigu prema ID-u", "🔎");
				this.accentKrugOpcija[i].DodajOpciju("Obrisi komponente", "➖");
				this.accentKrugOpcija[i].DodajOpciju("Dodaj komponentu", "➕");
				this.accentKrugOpcija[i].Location = Cursor.Position;
			}
			
			this.accentKrugOpcija[0].OpcijaSelektovana += delegate(object sender, EventArgs e) { 
				if (accentKrugOpcija[0].preuzmiNaIndex() == 0) {
					VratiPodrazumevaneVrednosti(0);
					
					DodajKnjigu dk = new DodajKnjigu();
					dk.ShowDialog();
					if (dk.JeDodat) this.GenerisanjeKnjigaUI(Knjige.Count - 1);
					if (dk.JeDodatAutor) for (CEBR i = autorUI.Count; i < Autori.Count; i ++) {
						this.GenerisanjeAutorUI(i);
					}
					if (dk.JeDodatIzdavac) for (CEBR i = izdavacUI.Count; i < Izdavaci.Count; i ++) {
						this.GenerisanjeIzdavacUI(i);
					}
					dk.Dispose();
				} else if (accentKrugOpcija[0].preuzmiNaIndex() == 1) {
					VratiPodrazumevaneVrednosti(0);
					
					KnjigaInfoUI.Brisanje = true;
					foreach (KnjigaInfoUI control in knjigaInfoUI) control.KorigujVidljivostBrisanja();
				} else if (accentKrugOpcija[0].preuzmiNaIndex() == 2) {
					VratiPodrazumevaneVrednosti(0);

					PronadjiKnjiguPoID pronadjiKnjiguPoIDu = new PronadjiKnjiguPoID();
					pronadjiKnjiguPoIDu.ShowDialog();

					try {
						KnjigaInfoUI knjigaInfoUI = this.knjigaInfoUI.Find(x => x.id == pronadjiKnjiguPoIDu.ID);
						if (knjigaInfoUI != null) KnjigaPritisnuta(knjigaInfoUI, new EventArgs());
					} catch (Exception ex) {
						System.Diagnostics.Debug.WriteLine(ex);
					}

					pronadjiKnjiguPoIDu.Dispose();
				}
			};
			
			this.accentKrugOpcija[1].OpcijaSelektovana += delegate(object sender, EventArgs e) {
				if (accentKrugOpcija[1].preuzmiNaIndex() == 0) {
					VratiPodrazumevaneVrednosti(1);

					DodajAutora da = new DodajAutora();
					da.ShowDialog();
					if (da.JeDodat) this.GenerisanjeAutorUI(Autori.Count - 1);
					da.Dispose();
				} else if (accentKrugOpcija[1].preuzmiNaIndex() == 1) {
					VratiPodrazumevaneVrednosti(1);

					AutorUI.Brisanje = true;
					foreach (AutorUI control in autorUI) control.KorigujVidljivostBrisanja();
				}
			};

			this.accentKrugOpcija[2].OpcijaSelektovana += delegate(object sender, EventArgs e) {
				if (accentKrugOpcija[2].preuzmiNaIndex() == 0) {
					VratiPodrazumevaneVrednosti(2);

					DodajIzdavaca di = new DodajIzdavaca();
					di.ShowDialog();
					if (di.JeDodat) this.GenerisanjeIzdavacUI(Izdavaci.Count - 1);
					di.Dispose();
				} else if (accentKrugOpcija[2].preuzmiNaIndex() == 1) {
					VratiPodrazumevaneVrednosti(2);

					IzdavacUI.Brisanje = true;
					foreach (IzdavacUI control in izdavacUI) control.KorigujVidljivostBrisanja();
				}
			};

			this.accentKrugOpcija[3].OpcijaSelektovana += delegate(object sender, EventArgs e) {
				if (accentKrugOpcija[3].preuzmiNaIndex() == 0) {
					VratiPodrazumevaneVrednosti(3);

					DodajClana dc = new DodajClana();
					dc.ShowDialog();
					if (dc.JeDodat) this.GenerisanjeClanUI(Clanovi.Count - 1);
					dc.Dispose();
				} else if (accentKrugOpcija[3].preuzmiNaIndex() == 1) {
					VratiPodrazumevaneVrednosti(3);

					ClanUI.Brisanje = true;
					foreach (ClanUI control in clanUI) control.KorigujVidljivostBrisanja();
				}
			};
			
			this.evidencijaKnjiga_panel.Controls.Add(accentKrugOpcija[0]);
			this.accentKrugOpcija[0].BringToFront();
			this.evidencijaAutora_panel.Controls.Add(accentKrugOpcija[1]);
			this.accentKrugOpcija[1].BringToFront();
			this.evidencijaIzdavaca_panel.Controls.Add(accentKrugOpcija[2]);
			this.accentKrugOpcija[2].BringToFront();
			this.evidencijaClanova_panel.Controls.Add(accentKrugOpcija[3]);
			this.accentKrugOpcija[3].BringToFront();
			
			this.KeyDown += new KeyEventHandler(DugmePritisnuto);
			this.ResumeLayout();
			
			if (MenadzmentPodataka.CuvaPodatkeLokalno) {
				this.Arhiva = MenadzmentPodataka.arhivaIznajmljivanjaPodaciUcitavanje("arhiva");
				this.Korisnici = MenadzmentPodataka.korisnikPodaciUcitavanje("korisnici");
				this.Autori = MenadzmentPodataka.autorPodaciUcitavanje("autori");
				for (CEBR i = 0; i < Autori.Count; i++) GenerisanjeAutorUI(i);
				this.Izdavaci = MenadzmentPodataka.izdavacPodaciUcitavanje("izdavaci");
				for (CEBR i = 0; i < Izdavaci.Count; i++) GenerisanjeIzdavacUI(i);
				// DONE: GenerisanjeKnjigaUI() metod nece automatski da se pokrene kada se doda nova knjiga
				this.Knjige = MenadzmentPodataka.knjigaPodaciUcitavanje("knjige");
				this.sigurnosniKljuc = false;
				for (CEBR i = 0; i < Knjige.Count; i++) GenerisanjeKnjigaUI(i);
				this.sigurnosniKljuc = true;
				PromeniRedosledKnjiga();
				this.Clanovi = MenadzmentPodataka.clanPodaciUcitavanje("clanovi");
				for (CEBR i = 0; i < Clanovi.Count; i++) GenerisanjeClanUI(i);
				PromeniRedosledClanova();
			}
			this.sortirajKnjigeDugme.SelectedIndex = 0;
		}
		
		void Form1Load(object sender, EventArgs e) {
			if (!Podesavanja.podesavanja["PL"]) return;
			Saveti s = new Saveti();
			s.ShowDialog();
		}
		
		void PostaviVidljivPanel() {
			this.login_panel.Visible = !_jeUlogovan;
			this.evidencijaKnjiga_panel.Visible = _jeUlogovan && viewPicker == 1;
			this.evidencijaAutora_panel.Visible = _jeUlogovan && viewPicker == 2;
			this.evidencijaIzdavaca_panel.Visible = _jeUlogovan && viewPicker == 3;
			this.evidencijaClanova_panel.Visible = _jeUlogovan && viewPicker == 4;
		}
		
		void Form1_PostaviIzgled() {
			this.BackColor = Colors.TamnijaPozadina;
			this.roundedRectanglePanel1.BackColor = Colors.AccentColor;
			this.navigationPanel.BackColor = Colors.TamnijaPozadina;
			this.login_panel.BackColor = Colors.SvetlijaPozadina;
			this.evidencijaKnjiga_panel.BackColor = Colors.SvetlijaPozadina;
			this.evidencijaAutora_panel.BackColor = Colors.SvetlijaPozadina;
			this.evidencijaClanova_panel.BackColor = Colors.SvetlijaPozadina;
			this.evidencijaIzdavaca_panel.BackColor = Colors.SvetlijaPozadina;
			this.knjigaInfoPanel.BackColor = Colors.SvetlijaPozadina;
			this.autorInfoPanel.BackColor = Colors.SvetlijaPozadina;
			this.izdavacInfoPanel.BackColor = Colors.SvetlijaPozadina;
			this.clanInfoPanel.BackColor = Colors.SvetlijaPozadina;
			this.option_list.BackColor = navigationPanel.BackColor;
			this.sortirajKnjigeDugme.IzborBoja = AccentIzbornoPolje.IzbornoPolje_StilBoja.Jednostavno;
			
			foreach (Control control in this.Controls) {
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeForeColor<GroupBox>(control, Colors.BojaTeksta);
				Colors.BojenjeForeColor<AccentPolje>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentPolje>(control, Colors.SvetlijaPozadina);
				Colors.BojenjeBackColor<AccentDugme>(control, Colors.AccentColor);
				Colors.BojenjeBackColor<AccentLista>(control, Colors.SvetlijaPozadina);
			}
			
			if (knjigaInfoUI != null) for (CEBR i = 0; i < this.knjigaInfoUI.Count; i++) {
				this.knjigaInfoUI[i].BackColor = evidencijaKnjiga_panel.BackColor;
				this.knjigaInfoUI[i].HoverColor = Podesavanja.Tema == ETema.Svetla ? Color.FromArgb(240, 240, 240) : Color.FromArgb(70, 70, 70);
				foreach (Control c in knjigaInfoUI[i].Controls) if (c is KnjigaUI) c.BackColor = KnjigaUI.BookColor(this.Knjige[i].preuzmiNaziv());
			}

			if(autorUI != null) for (CEBR i = 0; i < this.autorUI.Count; i++) {
				this.autorUI[i].BackColor = evidencijaAutora_panel.BackColor;
				this.autorUI[i].HoverColor = Podesavanja.Tema == ETema.Svetla ? Color.FromArgb(240, 240, 240) : Color.FromArgb(70, 70, 70);
			}
			
			if(izdavacUI != null) for (CEBR i = 0; i < this.izdavacUI.Count; i++) {
				this.izdavacUI[i].BackColor = evidencijaIzdavaca_panel.BackColor;
				this.izdavacUI[i].HoverColor = Podesavanja.Tema == ETema.Svetla ? Color.FromArgb(240, 240, 240) : Color.FromArgb(70, 70, 70);
			}
			
			if(clanUI != null) for (CEBR i = 0; i < this.clanUI.Count; i++) {
				this.clanUI[i].BackColor = evidencijaClanova_panel.BackColor;
				this.clanUI[i].HoverColor = Podesavanja.Tema == ETema.Svetla ? Color.FromArgb(240, 240, 240) : Color.FromArgb(70, 70, 70);
				if (this.clanUI[i].JeProsaoRok) this.clanUI[i].Controls[2].ForeColor = Colors.AccentColor;
			}

			this.optionlist_highlight.BackColor = Colors.AccentColor;
			this.option_list1.ForeColor = Colors.BojaTeksta;
			this.option_list2.ForeColor = Colors.BojaTeksta;
			this.option_list3.ForeColor = Colors.BojaTeksta;
			this.option_list4.ForeColor = Colors.BojaTeksta;
			this.label1.ForeColor = Color.White;
		}
		
		void DugmePritisnuto(object sender, KeyEventArgs e) {
			if (e.Alt && e.KeyCode == Keys.Left) {
				if (knjigaInfoPanel.Visible) this.NazadNaListuKnjiga(knjigaInfoPanel, new EventArgs());
				else if (autorInfoPanel.Visible) this.NazadNaListuAutora(autorInfoPanel, new EventArgs());
				else if (izdavacInfoPanel.Visible) this.NazadNaListuIzdavaca(izdavacInfoPanel, new EventArgs());
				else if (clanInfoPanel.Visible) this.NazadNaListuClanova(clanInfoPanel, new EventArgs());
			}
		}

		void KnjigaPritisnuta(object sender, EventArgs e) {
			this.evidencijaKnjiga_panel.AutoScroll = false;
			this.sigurnosniKljuc = false;
			NazadNaListuKnjiga(this, new EventArgs());
			this.sigurnosniKljuc = true;
			KnjigaInfoUI knjigaInfoUI = (KnjigaInfoUI) sender;
			foreach (var i in Knjige) if (i.preuzmiID() == knjigaInfoUI.id) this.knjiga = i;
			// System.Diagnostics.Debug.WriteLine(this.knjiga.preuzmiNaziv());
			knjigaUI1.Naziv = this.knjiga.preuzmiNaziv();
			knjigaUI1.Autor = Autor.preuzmiImePrezime_ID(MenadzmentPodataka.autori.ToArray(), this.knjiga.preuzmiIDAutora());
			knjigaUI1.GodinaIzdanja = this.knjiga.preuzmiGodinuIzdavanja();
			label4.Text = knjigaUI1.Naziv;
			label5.Text = knjigaUI1.Autor + " • " + this.knjiga.preuzmiBrojStrana() + " страна • " + knjigaUI1.GodinaIzdanja + ". година • " + this.knjiga.preuzmiRelativniZanr();
			label6.Visible = this.knjiga.preuzmiStatusIznajmljena();
			if (this.knjiga.preuzmiStatusIznajmljena()) this.stampanjeIDKnjige.Location = new Point(216, 89 + label6.Height);
			iznajmljivanjeKnjigeButton.Text = (!this.knjiga.preuzmiStatusIznajmljena()) ? "Изнајми" : "Врати";
			iznajmljivanjeKnjigeButton.Enabled = this.Clanovi.Count != 0;
			foreach (var arhiva in this.Arhiva) {
				if (arhiva.preuzmiIDKnjige() == this.knjiga.preuzmiID()) {
					try {
						Clan c = Clanovi.Find(i => i.preuzmiID() == arhiva.preuzmiIDClan());
						accentLista1.Items.Add(arhiva.preuzmiDatum() + ": " + c.preuzmiIme() + " " + c.preuzmiPrezime() + " | " + (arhiva.preuzmiStatus() == EIznajmljivanjeVracanje.Iznajmljena ? "⬆️" : "⬇️"));
					} catch (Exception ex) {
						System.Diagnostics.Debug.WriteLine(ex);
					}
				}
			}
			this.knjigaInfoPanel.Visible = true;
			this.knjigaInfoPanel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
		}

		void NazadNaListuKnjiga(object sender, EventArgs e) {
			// DONE: Pre no sto se knjiga vrati na null, potrebno je preko ID-a overridovati postojece podatke u listi i sacuvati ih
			if (this.sigurnosniKljuc) {
				this.evidencijaKnjiga_panel.AutoScroll = true;
				for (CEBR i = 0; i < Knjige.Count; i++) if (this.knjiga.preuzmiID() == this.Knjige[i].preuzmiID()) this.Knjige[i] = knjiga;
				this.knjiga = null;
				this.knjigaUI1.Naziv = null;
				this.knjigaUI1.Autor = null;
				this.knjigaUI1.GodinaIzdanja = 0;
				this.stampanjeIDKnjige.Location = new Point(216, 89);
			}
			this.label4.Text = "label4";
			this.label5.Text = "label5";
			this.label6.Visible = true;
			this.iznajmljivanjeKnjigeButton.Text = "Изнајми";
			this.iznajmljivanjeKnjigeButton.Enabled = true;
			this.accentLista1.Items.Clear();
			if (this.sigurnosniKljuc) this.knjigaInfoPanel.Visible = false;
		}
		
		void AutorPritisnut(object sender, EventArgs e) {
			this.evidencijaAutora_panel.AutoScroll = false;
			this.sigurnosniKljuc = false;
			NazadNaListuAutora(this, new EventArgs());
			this.sigurnosniKljuc = true;
			AutorUI autorUI1 = (AutorUI) sender;
			foreach (var i in this.Autori) if (i.preuzmiID() == autorUI1.id) this.autor = i;
			// System.Diagnostics.Debug.WriteLine(this.autor.preuzmiImePrezime());
			label9.Text = this.autor.preuzmiImePrezime();
			label10.Text = "(" + this.autor.preuzmiGodinuRodjenja() + " - " + this.autor.preuzmiGodinuSmrti() + ")";
			foreach (var k in this.Knjige) {
				if (k.preuzmiIDAutora() == this.autor.preuzmiID()) {
					accentLista2.Items.Add(k.preuzmiNaziv());
				}
			}
			this.autorInfoPanel.Visible = true;
			this.autorInfoPanel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
		}
		
		// DONE: Otvaranje knjige koja je selektovana u accentListi Knjiga kod Autora
		void AccentLista2DoubleClick(object sender, EventArgs e)
		{
			List<Knjiga> k = Knjige.FindAll(x => x.preuzmiIDAutora() == this.autor.preuzmiID());
			KnjigaInfoUI knjigaInfoUI = this.knjigaInfoUI.Find(x => x.id == k[accentLista2.SelectedIndex].preuzmiID());
			NazadNaListuAutora(accentDugme6, e);
			OptionlistbuttonClick(option_list1, e);
			KnjigaPritisnuta(knjigaInfoUI, e);
		}

		void NazadNaListuAutora(object sender, EventArgs e) {
			// DONE: Pre no sto se knjiga vrati na null, potrebno je preko ID-a overridovati postojece podatke u listi i sacuvati ih
			if (this.sigurnosniKljuc) {
				this.evidencijaAutora_panel.AutoScroll = true;
				for (CEBR i = 0; i < Autori.Count; i++) if (this.autor.preuzmiID() == this.Autori[i].preuzmiID()) this.Autori[i] = autor;
				this.autor = null;
			}
			this.label9.Text = "label9";
			this.label10.Text = "label10";
			this.accentLista2.Items.Clear();
			if (this.sigurnosniKljuc) this.autorInfoPanel.Visible = false;
		}

		void IzdavacPritisnut(object sender, EventArgs e) {
			this.evidencijaIzdavaca_panel.AutoScroll = false;
			this.sigurnosniKljuc = false;
			NazadNaListuIzdavaca(this, new EventArgs());
			this.sigurnosniKljuc = true;
			IzdavacUI izdavacUI = (IzdavacUI) sender;
			foreach (var i in this.Izdavaci) if (i.preuzmiID() == izdavacUI.id) this.izdavac = i;
			// System.Diagnostics.Debug.WriteLine(this.izdavac.preuzmiNaziv());
			label11.Text = this.izdavac.preuzmiNaziv();
			label12.Text = "" + this.izdavac.preuzmiGodinuOsnivanja();
			foreach (var k in Knjige) {
				if (k.preuzmiIDIzdavaca() == this.izdavac.preuzmiID()) {
					accentLista3.Items.Add(k.preuzmiNaziv());
				}
			}
			this.izdavacInfoPanel.Visible = true;
			this.izdavacInfoPanel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
		}
		
		void AccentLista3DoubleClick(object sender, EventArgs e)
		{
			List<Knjiga> k = Knjige.FindAll(x => x.preuzmiIDIzdavaca() == this.izdavac.preuzmiID());
			KnjigaInfoUI knjigaInfoUI = this.knjigaInfoUI.Find(x => x.id == k[accentLista3.SelectedIndex].preuzmiID());
			NazadNaListuIzdavaca(accentDugme8, e);
			OptionlistbuttonClick(option_list1, e);
			KnjigaPritisnuta(knjigaInfoUI, e);
		}

		void NazadNaListuIzdavaca(object sender, EventArgs e) {
			if (this.sigurnosniKljuc) {
				this.evidencijaIzdavaca_panel.AutoScroll = true;
				for (CEBR i = 0; i < Izdavaci.Count; i++) if (this.izdavac.preuzmiID() == this.Izdavaci[i].preuzmiID()) this.Izdavaci[i] = izdavac;
				this.izdavac = null;
			}
			this.label11.Text = "label11";
			this.label12.Text = "label12";
			this.accentLista3.Items.Clear();
			if (this.sigurnosniKljuc) this.izdavacInfoPanel.Visible = false;
		}

		void ClanPritisnut(object sender, EventArgs e) {
			this.evidencijaClanova_panel.AutoScroll = false;
			this.sigurnosniKljuc = false;
			NazadNaListuClanova(this, new EventArgs());
			this.sigurnosniKljuc = true;
			ClanUI clanUI = (ClanUI) sender;
			foreach (var i in this.Clanovi) if (i.preuzmiID() == clanUI.id) this.clan = i;
			// System.Diagnostics.Debug.WriteLine(this.clan.preuzmiIme() + " " + this.clan.preuzmiPrezime());
			{
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Podesavanja));
				this.pictureBox3.BackgroundImage = clanUI.JeProsaoRok ? ((Image)(resources.GetObject("CrvenaSlikaClana"))) : ((Image)(resources.GetObject("slikaProfila.Image")));
				this.label14.ForeColor = clanUI.JeProsaoRok ? Colors.AccentColor : Colors.BojaTeksta;
				this.label15.ForeColor = clanUI.JeProsaoRok ? Colors.AccentColor : Colors.BojaTeksta;
			}
			this.label14.Text = this.clan.preuzmiIme() + " " + this.clan.preuzmiPrezime();
			this.label15.Text = "" + this.clan.preuzmiGodinuRodjenja();
			this.accentDugme12.Enabled = this.clan.imaIznajmljenuKnjigu() ? true : false;
			foreach (var a in Arhiva) {
				if (a.preuzmiIDClan() == this.clan.preuzmiID()) {
					try {
						Knjiga knjiga = Knjige.Find(x => x.preuzmiID() == a.preuzmiIDKnjige());
						accentLista4.Items.Add(a.preuzmiDatum() + ": " + knjiga.preuzmiNaziv() + " | " + (a.preuzmiStatus() == EIznajmljivanjeVracanje.Iznajmljena ? "⬆️" : "⬇️"));
					} catch (Exception ex) {
						System.Diagnostics.Debug.WriteLine(ex);
					}
				}
			}
			this.clanInfoPanel.Visible = true;
			this.clanInfoPanel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
		}

		void NazadNaListuClanova(object sender, EventArgs e) {
			if (this.sigurnosniKljuc) {
				this.evidencijaClanova_panel.AutoScroll = true;
				for (CEBR i = 0; i < Clanovi.Count; i++) if (this.clan.preuzmiID() == this.Clanovi[i].preuzmiID()) this.Clanovi[i] = clan;
				this.clan = null;
			}
			this.label14.Text = "label14";
			this.label15.Text = "label15";
			this.accentDugme12.Enabled = true;
			this.accentLista4.Items.Clear();
			if (this.sigurnosniKljuc) this.clanInfoPanel.Visible = false;
		}

		void JeOmiljenStatusJeIzmenjen(object sender, EventArgs e) {
			// DONE: Proveriti da li je status ikoje knjige izmenjen i ukoliko vec jeste vratiti se iz metoda
			// DONE: PROMENIREDOSLEDKNJIGA uzima neizmenjenu vrednost
			this.evidencijaKnjiga_panel.VerticalScroll.Value = 0;
			this.evidencijaKnjiga_panel.PerformLayout();
			PromeniRedosledKnjiga();
			if (JeIzmenjenaKnjiga == true) return;

//			KnjigaInfoUI knjigaInfoUI1 = (KnjigaInfoUI) sender;
			this.JeIzmenjenaKnjiga = true;
		}
		
		// DONE: Pravljenje genericke metode 'ObjekatSeBrise'
		void ObjekatSeBrise<TipObjekta>(object sender, EventArgs e) where TipObjekta : UserControl, IObjekatUI {
			TipObjekta objekatUI = (TipObjekta) sender;

			TAC jeKnjiga = objekatUI is KnjigaInfoUI;
			TAC jeClan = objekatUI is ClanUI;
			STR poruka = "Брисање је радња неопозивог карактера. " + (jeKnjiga || jeClan ? "" : "Свака књига повезана са овим " + (objekatUI is AutorUI ? "аутором" : "издавачем") + " ће такође бити обрисана.") + "\nЈесте ли сигурни да желите да наставите?";
			if (this.sigurnosniKljuc) if (MessageBox.Show(poruka, "Библиотека: Потврда брисања", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes) return;

			CEBR idobjekat = objekatUI.id;
			if (!jeKnjiga && !jeClan) {
				this.sigurnosniKljuc = false;
				
				{
					KnjigaInfoUI[] knjigaInfoUI1 = new KnjigaInfoUI[0];
					
					foreach (KnjigaInfoUI knjigaInfoUI in this.knjigaInfoUI) {
						Knjiga knjiga = Knjige.Find(x => x.preuzmiID() == knjigaInfoUI.id);

						if (objekatUI is AutorUI ? knjiga.preuzmiIDAutora() == idobjekat : knjiga.preuzmiIDIzdavaca() == idobjekat) {
							Array.Resize(ref knjigaInfoUI1, knjigaInfoUI1.Length + 1);
							knjigaInfoUI1[knjigaInfoUI1.Length - 1] = knjigaInfoUI;
						}
					}
				
					foreach (var knjigaInfoUI in knjigaInfoUI1) {
						ObjekatSeBrise<KnjigaInfoUI>(knjigaInfoUI, e);
					}
				}
				
				this.sigurnosniKljuc = true;
			}

			if (jeKnjiga) {
				for (CEBR i = 0; i < Knjige.Count; i++) if (Knjige[i].preuzmiID() == idobjekat) {
					Knjige.RemoveAt(i);
					this.knjigaInfoUI.RemoveAt(i);
				}

				MenadzmentPodataka.knjigaPodaciCuvanje(Knjige, "knjige");

				objekatUI.Dispose();

				for (CEBR i = 0; i < this.knjigaInfoUI.Count; i++) {
					this.knjigaInfoUI[i].Visible = true;
					IzmenaRedosledaKomponente<KnjigaInfoUI>(this.knjigaInfoUI, i, i);
				}
			} else if (objekatUI is AutorUI) {
				for (CEBR i = 0; i < Autori.Count; i++) if (Autori[i].preuzmiID() == idobjekat) {
					Autori.RemoveAt(i);
					this.autorUI.RemoveAt(i);
				}

				MenadzmentPodataka.autorPodaciCuvanje(Autori, "autori");

				objekatUI.Dispose();

				for (CEBR i = 0; i < this.autorUI.Count; i++) {
					this.autorUI[i].Visible = true;
					IzmenaRedosledaKomponente<AutorUI>(this.autorUI, i, i);
				}
			} else if (objekatUI is IzdavacUI) {
				for (CEBR i = 0; i < Izdavaci.Count; i++) if (Izdavaci[i].preuzmiID() == idobjekat) {
					Izdavaci.RemoveAt(i);
					this.izdavacUI.RemoveAt(i);
				}

				MenadzmentPodataka.izdavacPodaciCuvanje(Izdavaci, "izdavaci");

				objekatUI.Dispose();

				for (CEBR i = 0; i < this.izdavacUI.Count; i++) {
					this.izdavacUI[i].Visible = true;
					IzmenaRedosledaKomponente<IzdavacUI>(this.izdavacUI, i, i);
				}
			} else if (objekatUI is ClanUI) {
				for (CEBR i = 0; i < Clanovi.Count; i++) if (Clanovi[i].preuzmiID() == idobjekat) {
					Clanovi.RemoveAt(i);
					this.clanUI.RemoveAt(i);
				}

				MenadzmentPodataka.clanPodaciCuvanje(Clanovi, "clanovi");

				objekatUI.Dispose();

				for (CEBR i = 0; i < this.clanUI.Count; i++) {
					this.clanUI[i].Visible = true;
					IzmenaRedosledaKomponente<ClanUI>(this.clanUI, i, i);
				}
			}
		}
		
		// Proveravanje korisnickog imena i lozinke; Autentifikacija
		void Button1Click(object sender, EventArgs e)
		{
			foreach(var i in Korisnici) {
				if ((this.textBox1.Text == i.preuzmiKorisnickoIme()) && (this.textBox2.Text == i.preuzmiLozinku())) {
					this.Korisnik = i;
					this.JeUlogovan = true;
					this.evidencijaKnjiga_panel.BringToFront();
					this.option_list1.PerformClick();
				}
			}
			
			if (Korisnik == null) {
				MessageBox.Show("Корисник не постоји! Проверите да ли сте унели исправне податке.", "Библиотека: Грешка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			AppInfo appInfo = new AppInfo();
			appInfo.Show();
			appInfo.FormClosing += delegate {
				appInfo.Dispose();
			};
		}
		
		void Logout_buttonClick(object sender, EventArgs e)
		{
			this.Korisnik = null;
			this.JeUlogovan = false;
		}

		void TekstJeIzmenjen(object sender, EventArgs e) {
			AccentPolje t = (AccentPolje) sender;
			this.SuspendLayout();
			
			// 1 k 2 c 3 a 4 i
			if (t == accentPolje1) RezultatiPretrage<KnjigaInfoUI>(knjigaInfoUI, t);
			else if (t == accentPolje3) RezultatiPretrage<AutorUI>(autorUI, t);
			else if (t == accentPolje2) RezultatiPretrage<IzdavacUI>(izdavacUI, t);
			else if (t == accentPolje4) RezultatiPretrage<ClanUI>(clanUI, t);
			
			this.ResumeLayout();
		}
		
		void RezultatiPretrage<Tip>(List<Tip> lista, AccentPolje t) where Tip : UserControl, IObjekatUI {
			for (CEBR i = 0; i < lista.Count; i++) lista[i].Visible = false;

			CEBR y = 0;
			for (CEBR i = 0; i < lista.Count; i++) {
				if (t.Text == String.Empty) {
					if (typeof(Tip) == typeof(KnjigaInfoUI)) PromeniRedosledKnjiga();
					else this.IzmenaRedosledaKomponente<Tip>(lista, i, i);
					lista[i].Visible = true;
				} else {
					// DONE: Samo jedna knjiga se prikaze pri pretrazi
					STR naziv = "";
					
					if (typeof(Tip) == typeof(KnjigaInfoUI)) {
						naziv = Knjige[i].preuzmiNaziv();
					} else if (typeof(Tip) == typeof(AutorUI)) {
						naziv = Autori[i].preuzmiImePrezime();
					} else if (typeof(Tip) == typeof(IzdavacUI)) {
						naziv = Izdavaci[i].preuzmiNaziv();
					} else if (typeof(Tip) == typeof(ClanUI)) {
						naziv = Clanovi[i].preuzmiIme() + " " + Clanovi[i].preuzmiPrezime();
					}

					if (naziv.ToLower().Contains(t.Tekst.ToLower())) {
						this.IzmenaRedosledaKomponente<Tip>(lista, i, y++);
						lista[i].Visible = true;
					} else {
						lista[i].Visible = false;
					}
				}
			}
		}
		
		void Panel_MisDole(object sender, MouseEventArgs e)
		{
			// DONE: accentKrugOpcija za sve panele
			if (e.Button == MouseButtons.Right)
			{
				this.Cursor = Cursors.Cross;
				// Prikazuje meni na lokaciji kursora
				Point mestoKursora = this.evidencijaKnjiga_panel.PointToClient(Cursor.Position);
				switch(this.viewPicker) {
					case 2:
						mestoKursora = this.evidencijaAutora_panel.PointToClient(Cursor.Position);
						break;
					case 3:
						mestoKursora = this.evidencijaIzdavaca_panel.PointToClient(Cursor.Position);
						break;
					case 4:
						mestoKursora = this.evidencijaClanova_panel.PointToClient(Cursor.Position);
						break;
					default:
						break;
				}
				this.accentKrugOpcija[viewPicker - 1].Location = new Point(mestoKursora.X - accentKrugOpcija[viewPicker - 1].Width / 2, mestoKursora.Y - accentKrugOpcija[viewPicker - 1].Height / 2);
				this.accentKrugOpcija[viewPicker - 1].Visible = true;
			} else {
				this.Cursor = Cursors.Default;
				this.accentKrugOpcija[viewPicker - 1].Visible = false;
			}
			
			KnjigaInfoUI.Brisanje = false;
			foreach (var control in this.knjigaInfoUI) ((KnjigaInfoUI) control).KorigujVidljivostBrisanja();
			AutorUI.Brisanje = false;
			foreach (var control in this.autorUI) ((AutorUI) control).KorigujVidljivostBrisanja();
			IzdavacUI.Brisanje = false;
			foreach (var control in this.izdavacUI) ((IzdavacUI) control).KorigujVidljivostBrisanja();
			ClanUI.Brisanje = false;
			foreach (var control in this.clanUI) ((ClanUI) control).KorigujVidljivostBrisanja();
		}
		
		void IznajmljivanjeKnjigeButtonClick(object sender, EventArgs e)
		{
			if (iznajmljivanjeKnjigeButton.Text == "Изнајми") {
				Iznajmljivanje_VracanjeKnjige iznajmljivanjeVracanjeKnjige = new Iznajmljivanje_VracanjeKnjige(ref this.knjiga, this.Korisnik);
				iznajmljivanjeVracanjeKnjige.ShowDialog();
				if (iznajmljivanjeVracanjeKnjige.Zastava) {
					Clan c = Clanovi.Find(x => x.preuzmiID() == this.Arhiva[Arhiva.Count - 1].preuzmiIDClan());
					accentLista1.Items.Add(this.Arhiva[Arhiva.Count - 1].preuzmiDatum() + ": " + c.preuzmiIme() + " " + c.preuzmiPrezime() + " | " + (this.Arhiva[Arhiva.Count - 1].preuzmiStatus() == EIznajmljivanjeVracanje.Iznajmljena ? "⬆️" : "⬇️"));
					iznajmljivanjeKnjigeButton.Text = (!this.knjiga.preuzmiStatusIznajmljena()) ? "Изнајми" : "Врати";
					label6.Visible = this.knjiga.preuzmiStatusIznajmljena();
					this.stampanjeIDKnjige.Location = new Point(216, 89 + label6.Height);
				}
				iznajmljivanjeVracanjeKnjige.Dispose();
			} else {
				ArhivaIznajmljivanja arh = this.Arhiva.FindLast(x => x.preuzmiIDKnjige() == this.knjiga.preuzmiID());
				this.VracanjeKnjige(arh);
			}
		}

		// DONE: Testirati -> BUG: knjiga razduzena preko evidencije clana? biva evidentirana kao vracena, ali unutar this.knjiga se ne menja status iznajmljena (greska u liniji: 953)
		void VracanjeKnjige(ArhivaIznajmljivanja arh) {
			if (MessageBox.Show("Потврдите враћање књиге", "Библиотека: Враћање књиге", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No) return;
			arh.EvidentirajJeVracena(true);
			this.Arhiva.Add(new ArhivaIznajmljivanja(arh.preuzmiIDKnjige(), arh.preuzmiIDClan(), Podesavanja.korisnik.preuzmiID(), EIznajmljivanjeVracanje.Vracena, DateTime.Now));
			MenadzmentPodataka.arhivaIznajmljivanjaPodaciCuvanje(this.Arhiva, "arhiva");
			Clan clan = this.Clanovi.Find(x => x.preuzmiID() == arh.preuzmiIDClan());
			clan.postaviSlobodnoMesto(arh.preuzmiIDKnjige());
			MenadzmentPodataka.clanPodaciCuvanje(this.Clanovi, "clanovi");
			ClanUI clanUI = this.clanUI.Find(x => x.id == arh.preuzmiIDClan());
			clanUI.JeProsaoRok = clanUI.jeProsaoRokZaVracanjeIkojeKnjige(clan);
			for (CEBR i = 0; i < Knjige.Count; i ++) if (Knjige[i].preuzmiID() == arh.preuzmiIDKnjige()) {
				Knjige[i].postaviStatusIznajmljena(false);
				if (this.clan != null) {
					accentLista4.Items.Add(Arhiva[Arhiva.Count - 1].preuzmiDatum() + ": " + Knjige[i].preuzmiNaziv() + " | " + (Arhiva[Arhiva.Count - 1].preuzmiStatus() == EIznajmljivanjeVracanje.Iznajmljena ? "⬆️" : "⬇️"));
					{
						System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Podesavanja));
						this.pictureBox3.BackgroundImage = clanUI.JeProsaoRok ? ((Image)(resources.GetObject("CrvenaSlikaClana"))) : ((Image)(resources.GetObject("slikaProfila.Image")));
						this.label14.ForeColor = clanUI.JeProsaoRok ? Colors.AccentColor : Colors.BojaTeksta;
						this.label15.ForeColor = clanUI.JeProsaoRok ? Colors.AccentColor : Colors.BojaTeksta;
					}
				}
				if (this.knjiga != null) {
					accentLista1.Items.Add(this.Arhiva[Arhiva.Count - 1].preuzmiDatum() + ": " + clan.preuzmiIme() + " " + clan.preuzmiPrezime() + " | " + (this.Arhiva[Arhiva.Count - 1].preuzmiStatus() == EIznajmljivanjeVracanje.Iznajmljena ? "⬆️" : "⬇️"));
					iznajmljivanjeKnjigeButton.Text = "Изнајми";
					label6.Visible = false;
					this.stampanjeIDKnjige.Location = new Point(216, 89);
				}
			}
			MenadzmentPodataka.knjigaPodaciCuvanje(this.Knjige, "knjige");
		}
		
		void IzmenaKnjigeButtonClick(object sender, EventArgs e)
		{
			IzmenaKnjige izmenaKnjige = new IzmenaKnjige(ref this.knjiga);
			izmenaKnjige.ShowDialog();

			// DONE: Ukoliko su podaci izmenjeni azurirati Formu i knjigaPodaciCuvanje
			if (izmenaKnjige.JeIzmenjen) {
				this.knjiga = Knjige.Find(x => x.preuzmiID() == this.knjiga.preuzmiID());

				foreach(KnjigaInfoUI knjigaInfoUI in this.knjigaInfoUI)
				if (knjigaInfoUI.id == this.knjiga.preuzmiID())
				knjigaInfoUI.AzurirajPodatke(this.knjiga);

				this.knjigaUI1.Naziv = this.knjiga.preuzmiNaziv();
				this.knjigaUI1.Autor = Autor.preuzmiImePrezime_ID(MenadzmentPodataka.autori.ToArray(), this.knjiga.preuzmiIDAutora());
				this.knjigaUI1.GodinaIzdanja = this.knjiga.preuzmiGodinuIzdavanja();
				this.label4.Text = this.knjigaUI1.Naziv;
				label5.Text = knjigaUI1.Autor + " • " + this.knjiga.preuzmiBrojStrana() + " страна • " + knjigaUI1.GodinaIzdanja + ". година • " + this.knjiga.preuzmiRelativniZanr();
	
				this.JeIzmenjenaKnjiga = true;
			}
			
			izmenaKnjige.Dispose();
		}
		
		void AccentDugme4Click(object sender, EventArgs e)
		{
			IzmenaAutora izmenaAutora = new IzmenaAutora(ref this.autor);
			izmenaAutora.ShowDialog();
			
			if (izmenaAutora.JeIzmenjen) {
				this.autor = Autori.Find(x => x.preuzmiID() == this.autor.preuzmiID());

				foreach (AutorUI autorUI in this.autorUI)
				if (autorUI.id == this.autor.preuzmiID())
				autorUI.AzurirajPodatke(this.autor);

				label9.Text = this.autor.preuzmiImePrezime();
				label10.Text = "(" + this.autor.preuzmiGodinuRodjenja() + " - " + this.autor.preuzmiGodinuSmrti() + ")";

				this.JeIzmenjenAutor = true;
			}
			
			izmenaAutora.Dispose();
		}
		
		void AccentDugme3Click(object sender, EventArgs e)
		{
			IzmenaIzdavaca izmenaIzdavaca = new IzmenaIzdavaca(ref this.izdavac);
			izmenaIzdavaca.ShowDialog();
			
			if (izmenaIzdavaca.JeIzmenjen) {
				this.izdavac = Izdavaci.Find(x => x.preuzmiID() == this.izdavac.preuzmiID());

				foreach (IzdavacUI izdavacUI in this.izdavacUI)
				if (izdavacUI.id == this.izdavac.preuzmiID())
				izdavacUI.AzurirajPodatke(this.izdavac);

				label11.Text = this.izdavac.preuzmiNaziv();
				label12.Text = "" + this.izdavac.preuzmiGodinuOsnivanja();

				this.JeIzmenjenIzdavac = true;
			}
			
			izmenaIzdavaca.Dispose();
		}
		
		void AccentDugme9Click(object sender, EventArgs e)
		{
			IzmenaClana	izmenaClana = new IzmenaClana(ref this.clan);
			izmenaClana.ShowDialog();

			if (izmenaClana.JeIzmenjen) {
				this.clan = Clanovi.Find(x => x.preuzmiID() == this.clan.preuzmiID());

				foreach (ClanUI clanUI in this.clanUI)
				if (clanUI.id == this.clan.preuzmiID())
				clanUI.AzurirajPodatke(this.clan);

				this.label14.Text = this.clan.preuzmiIme() + " " + this.clan.preuzmiPrezime();
				this.label15.Text = "" + this.clan.preuzmiGodinuRodjenja();

				this.JeIzmenjenClan = true;
			}
			
			izmenaClana.Dispose();
		}
		
		void AccentDugme2Click(object sender, EventArgs e)
		{
			KnjigaInfoUI knjigaInfoUI = this.knjigaInfoUI.Find(x => x.id == this.knjiga.preuzmiID());
			NazadNaListuKnjiga(this.knjiga, new EventArgs());
			this.ObjekatSeBrise<KnjigaInfoUI>(knjigaInfoUI, e);
		}
		
		void AccentDugme5Click(object sender, EventArgs e)
		{
			AutorUI autorUI = this.autorUI.Find(x => x.id == this.autor.preuzmiID());
			NazadNaListuAutora(this.autor, new EventArgs());
			this.ObjekatSeBrise<AutorUI>(autorUI, e);
		}
		
		void AccentDugme7Click(object sender, EventArgs e)
		{
			IzdavacUI izdavacUI = this.izdavacUI.Find(x => x.id == this.izdavac.preuzmiID());
			NazadNaListuIzdavaca(this.izdavac, new EventArgs());
			this.ObjekatSeBrise<IzdavacUI>(izdavacUI, e);
		}
		
		void AccentDugme10Click(object sender, EventArgs e)
		{
			ClanUI clanUI = this.clanUI.Find(x => x.id == this.clan.preuzmiID());
			NazadNaListuClanova(this.clan, new EventArgs());
			this.ObjekatSeBrise<ClanUI>(clanUI, e);
		}
		
		// Razduzivanje knjiga po clanu
		void AccentDugme12Click(object sender, EventArgs e)
		{
			if (this.accentLista4.SelectedItem == null) MessageBox.Show("Молимо селектујте изнајмљену књигу у листи како бисте је раздужили.", "Библиотека: Пажња", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
			else {
				List<ArhivaIznajmljivanja> arhivaIznajmljivanjaClana = new List<ArhivaIznajmljivanja>();
				foreach (var a in Arhiva) if (a.preuzmiIDClan() == this.clan.preuzmiID()) {
					arhivaIznajmljivanjaClana.Add(a);
				}
				if (!arhivaIznajmljivanjaClana[accentLista4.SelectedIndex].preuzmiJeVracena()) this.VracanjeKnjige(arhivaIznajmljivanjaClana[accentLista4.SelectedIndex]);
				else MessageBox.Show("Одабрана књига је већ враћена!", "Библиотека: Обавештење", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		
		void Form1Resize(object sender, EventArgs e)
		{
//			DECF procenat = 273.0f / 1100.0f;
//			DECF duzinaXprocenat = this.Width * procenat;
			DECF duzinaXprocenat = 273;
			this.navigationPanel.Width = Convert.ToInt32(duzinaXprocenat);
			this.login_panel.Width = Convert.ToInt32(this.Width - duzinaXprocenat);
			this.login_panel.Location = new Point(this.navigationPanel.Width, 0);
			this.evidencijaKnjiga_panel.Width = Convert.ToInt32(this.Width * 0.99 - duzinaXprocenat);
			this.evidencijaKnjiga_panel.Location = new Point(this.navigationPanel.Width, 0);
			this.evidencijaAutora_panel.Width = Convert.ToInt32(this.Width * 0.99 - duzinaXprocenat);
			this.evidencijaAutora_panel.Location = new Point(this.navigationPanel.Width, 0);
			this.evidencijaIzdavaca_panel.Width = Convert.ToInt32(this.Width * 0.99 - duzinaXprocenat);
			this.evidencijaIzdavaca_panel.Location = new Point(this.navigationPanel.Width, 0);
			this.evidencijaClanova_panel.Width = Convert.ToInt32(this.Width * 0.99 - duzinaXprocenat);
			this.evidencijaClanova_panel.Location = new Point(this.navigationPanel.Width, 0);
			this.navigationPanel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			this.login_panel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			this.evidencijaKnjiga_panel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			this.evidencijaAutora_panel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			this.evidencijaIzdavaca_panel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			this.evidencijaClanova_panel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			
			this.knjigaInfoPanel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			this.autorInfoPanel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			this.izdavacInfoPanel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			this.clanInfoPanel.Height = Convert.ToInt32(this.Height * procenatVisinePanela);
			
			Transformacije.PromeniLokacijuZavisnogObjekta<AccentDugme, Label>(accentDugme2, brisanjeKnjige_LabelaZaObjasnjenje, 0, 45);
			Transformacije.PromeniLokacijuZavisnogObjekta<AccentDugme, Label>(accentDugme5, label7,  0, 45);
			Transformacije.PromeniLokacijuZavisnogObjekta<AccentDugme, Label>(accentDugme2, label8, 0, 45);
			Transformacije.PromeniLokacijuZavisnogObjekta<AccentDugme, Label>(accentDugme7, label13, 0, 45);
			// OLD_COMMAND: this.navigationPanel.Dock = DockStyle.Left;
			// OLD_COMMAND: this.login_panel.Dock = DockStyle.Fill;
			// OLD_COMMAND: this.evidencijaKnjiga_panel.Dock = DockStyle.Fill;
			if (this.evidencijaKnjiga_panel.Visible) {
				// DONE: Tekst u AP1 se ne brise
				this.accentPolje1.Text = "";
				this.evidencijaKnjiga_panel.VerticalScroll.Value = 0;
				this.evidencijaKnjiga_panel.PerformLayout();
				for (CEBR i = 0; i < this.knjigaInfoUI.Count; i ++) {
					knjigaInfoUI[i].Visible = true;
					PromeniRedosledKnjiga();
				}
			} else if (this.evidencijaAutora_panel.Visible) {
				this.accentPolje3.Text = "";
				this.evidencijaAutora_panel.VerticalScroll.Value = 0;
				this.evidencijaAutora_panel.PerformLayout();
				for (CEBR i = 0; i < this.autorUI.Count; i ++) {
					autorUI[i].Visible = true;
					IzmenaRedosledaKomponente<AutorUI>(autorUI, i, i);
				}
			} else if (this.evidencijaIzdavaca_panel.Visible) {
				this.accentPolje2.Text = "";
				this.evidencijaIzdavaca_panel.VerticalScroll.Value = 0;
				this.evidencijaIzdavaca_panel.PerformLayout();
				for (CEBR i = 0; i < this.izdavacUI.Count; i ++) {
					izdavacUI[i].Visible = true;
					IzmenaRedosledaKomponente<IzdavacUI>(izdavacUI, i, i);
				}
			} else if (this.evidencijaClanova_panel.Visible) {
				this.accentPolje4.Text = "";
				this.evidencijaClanova_panel.VerticalScroll.Value = 0;
				this.evidencijaClanova_panel.PerformLayout();
				for (CEBR i = 0; i < this.clanUI.Count; i ++) {
					clanUI[i].Visible = true;
					IzmenaRedosledaKomponente<ClanUI>(clanUI, i, i);
				}
			}
			this.PromeniRedosledClanova();
		}

		private void AccentScrollBar_Scroll(object sender, ScrollEventArgs e)
		{
			// Pronalazenje aktivnog panela
			Panel panel = evidencijaKnjiga_panel;
			switch (viewPicker) {
				case 2:
					panel = evidencijaAutora_panel;
					break;
				case 3:
					panel = evidencijaIzdavaca_panel;
					break;
				case 4:
					panel = evidencijaClanova_panel;
					break;
			}

			// Pomeranje panela
			panel.Location = new Point(panel.Location.X, -e.NewValue);
		}
		
		void Settings_buttonClick(object sender, EventArgs e)
		{
			Podesavanja podesavanja = new Podesavanja();
			podesavanja.ShowDialog();
			
			Form1_PostaviIzgled();
			Invalidate();
			if (podesavanja.JeOdjavljen) logout_button.PerformClick();
			
			podesavanja.Dispose();
		}
		
		void OptionlistbuttonClick(object sender, EventArgs e)
		{
			if (this.evidencijaKnjiga_panel.Visible) {
				accentPolje1.Text = "";
				if (knjigaInfoPanel.Visible) accentDugme1.PerformClick();
				this.evidencijaKnjiga_panel.VerticalScroll.Value = 0;
				this.evidencijaKnjiga_panel.PerformLayout();
			}
			if (this.evidencijaClanova_panel.Visible) {
				accentPolje2.Text = "";
				if (clanInfoPanel.Visible) accentDugme11.PerformClick();
				this.evidencijaClanova_panel.VerticalScroll.Value = 0;
				this.evidencijaClanova_panel.PerformLayout();
			}
			if (this.evidencijaAutora_panel.Visible) {
				accentPolje3.Text = "";
				if (autorInfoPanel.Visible) accentDugme6.PerformClick();
				this.evidencijaAutora_panel.VerticalScroll.Value = 0;
				this.evidencijaAutora_panel.PerformLayout();
			}
			if (this.evidencijaIzdavaca_panel.Visible) {
				accentPolje4.Text = "";
				if (izdavacInfoPanel.Visible) accentDugme8.PerformClick();
				this.evidencijaIzdavaca_panel.VerticalScroll.Value = 0;
				this.evidencijaIzdavaca_panel.PerformLayout();
			}
			this.Cursor = Cursors.Default;
			this.accentKrugOpcija[this.viewPicker - 1].Visible = false;
			
			Button btn = (Button) sender;
			this.optionlist_highlight.Height = btn.Height;
			Animacije.PromeniLokaciju<Panel>(optionlist_highlight, btn.Location, 60, 0.3);
			this.viewPicker = CEBR.Parse((STR) btn.Tag);
			PostaviVidljivPanel();
			
			Form1Resize(this, new EventArgs());
		}

		void TipSortiranjaPromenjen(object sender, EventArgs e) {
			switch (this.sortirajKnjigeDugme.SelectedIndex) {
				case 0:
					this.PromeniRedosledKnjiga();
					break;
				case 1:
					{
						List<Tuple<CEBR, STR>> knjige = new List<Tuple<CEBR, STR>>();
						for (CEBR i = 0; i < this.Knjige.Count; i++)  knjige.Add(new Tuple<CEBR, STR>(this.Knjige[i].preuzmiID(), this.Knjige[i].preuzmiNaziv()));
						knjige.Sort((x, y) => x.Item2.CompareTo(y.Item2));
						CEBR novaPozicija = 0;
						List<Tuple<CEBR, CEBR>> knjigaInfoUI = new List<Tuple<CEBR, CEBR>>();
						while (novaPozicija < this.knjigaInfoUI.Count) {
							CEBR a = this.knjigaInfoUI.FindIndex(x => x.id == knjige[novaPozicija].Item1);
							knjigaInfoUI.Add(new Tuple<CEBR, CEBR>(novaPozicija, a));
							novaPozicija ++;
						}
						knjigaInfoUI.Sort((x, y) => x.Item2.CompareTo(y.Item2));
						for (CEBR i = 0; i < this.knjigaInfoUI.Count; i ++) IzmenaRedosledaKomponente<KnjigaInfoUI>(this.knjigaInfoUI, i, knjigaInfoUI[i].Item1);
					}
					break;
				case 2:
					{
						List<Tuple<CEBR, STR, STR>> knjige = new List<Tuple<CEBR, STR, STR>>();
						for (CEBR i = 0; i < this.Knjige.Count; i++)  knjige.Add(new Tuple<CEBR, STR, STR>(this.Knjige[i].preuzmiID(), this.Knjige[i].preuzmiNaziv(), this.Knjige[i].preuzmiUDK()));
						knjige.Sort((x, y) => {
						            	CEBR rezUporedjivanje = x.Item3.CompareTo(y.Item3);
						            	if (rezUporedjivanje == 0) {
						            		rezUporedjivanje = x.Item2.CompareTo(y.Item2);
						            	}
						            	return rezUporedjivanje;
						            });
						CEBR novaPozicija = 0;
						List<Tuple<CEBR, CEBR>> knjigaInfoUI = new List<Tuple<CEBR, CEBR>>();
						while (novaPozicija < this.knjigaInfoUI.Count) {
							CEBR a = this.knjigaInfoUI.FindIndex(x => x.id == knjige[novaPozicija].Item1);
							knjigaInfoUI.Add(new Tuple<CEBR, CEBR>(novaPozicija, a));
							novaPozicija ++;
						}
						knjigaInfoUI.Sort((x, y) => x.Item2.CompareTo(y.Item2));
						for (CEBR i = 0; i < this.knjigaInfoUI.Count; i ++) IzmenaRedosledaKomponente<KnjigaInfoUI>(this.knjigaInfoUI, i, knjigaInfoUI[i].Item1);
					}
					break;
				default:
					// System.Diagnostics.Debug.WriteLine("Indeks \"sortirajKnjigeDugme\" AccentIzbornogPolja je izvan postojeceg opsega brojeva.");
					break;
			}
		}

		protected override void OnClosing(System.ComponentModel.CancelEventArgs e) {
			// DONE: Sacuvaj podatke ukoliko su izmenjeni [potrebno zbog statusa JeOmiljen kod knjiga npr]
			if (this.JeIzmenjenaKnjiga) MenadzmentPodataka.knjigaPodaciCuvanje(MenadzmentPodataka.knjige, "knjige");
			if (this.JeIzmenjenAutor) MenadzmentPodataka.autorPodaciCuvanje(MenadzmentPodataka.autori, "autori");
			if (this.JeIzmenjenIzdavac) MenadzmentPodataka.izdavacPodaciCuvanje(MenadzmentPodataka.izdavaci, "izdavaci");
			if (this.JeIzmenjenClan) MenadzmentPodataka.clanPodaciCuvanje(MenadzmentPodataka.clanovi, "clanovi");
		}
	}
}
