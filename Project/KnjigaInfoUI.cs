////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Project
{
	public partial class KnjigaInfoUI : UserControl, IObjekatUI
	{
		private int _id;
		public bool jeIzmenjen;
		private static bool _brisanje = false;
		private static char oznaka = '❌';
		private Color _hoverColor = Podesavanja.Tema == ETema.Svetla ? Color.FromArgb(240, 240, 240) : Color.FromArgb(70, 70, 70);

        public int id {
            get {
                return _id;
            } set {
                _id = value;
            }
        }

		public Color HoverColor {
			get {
				return _hoverColor;
			} set {
				_hoverColor = value;
				Invalidate();
			}
		}

		public bool JeOmiljena {
			get {
				return this.zvezdastoDugme1.JeOmiljen;
			}
		}

		public static bool Brisanje {
			get {
				return _brisanje;
			} set {
				_brisanje = value;
			}
		}
		
		public static char Oznaka {
			get {
				return oznaka;
			} set {
				oznaka = value;
			}
		}

		public event EventHandler JeOmiljenStatusJeIzmenjen = delegate { };
		public event EventHandler KnjigaSeBrise = delegate { };
		
		public void KorigujVidljivostBrisanja() {
			this.dugmeKrug1.Visible = KnjigaInfoUI.Brisanje;
		}
		
		public KnjigaInfoUI()
		{
			InitializeComponent();
			
			this.id = 0;
			this.jeIzmenjen = false;
			KorigujVidljivostBrisanja();
		}
		
		public KnjigaInfoUI(Knjiga knjiga, List<Autor> autori)
		{
			InitializeComponent();
			
			this.jeIzmenjen = false;
			this.id = knjiga.preuzmiID();

			this.knjigaUI1.Naziv = knjiga.preuzmiNaziv();
			this.knjigaUI1.Autor = "";
			Autor a = autori.Find(i => i.preuzmiID() == knjiga.preuzmiIDAutora());
			this.knjigaUI1.Autor = a.preuzmiImePrezime();
			this.knjigaUI1.GodinaIzdanja = knjiga.preuzmiGodinuIzdavanja();
			this.knjigaUI1.MouseEnter += new System.EventHandler(this.MouseOverIn);
			this.knjigaUI1.MouseLeave += new System.EventHandler(this.MouseOverOut);
			this.knjigaUI1.Region = new Region(Oblik.ZaobljeniPravougaonik(knjigaUI1.ClientRectangle, 4));
			this.label1.Text = knjiga.preuzmiNaziv();
			this.label1.MouseEnter += new System.EventHandler(this.MouseOverIn);
			this.label1.MouseLeave += new System.EventHandler(this.MouseOverOut);
			this.label2.Text = this.knjigaUI1.Autor;
			this.label2.MouseEnter += new System.EventHandler(this.MouseOverIn);
			this.label2.MouseLeave += new System.EventHandler(this.MouseOverOut);
			this.zvezdastoDugme1.JeOmiljen = knjiga.preuzmiStatusOmiljeno();
			KorigujVidljivostBrisanja();
			
			this.Cursor = Cursors.Hand;
			this.MouseEnter += new System.EventHandler(this.MouseOverIn);
			this.MouseLeave += new System.EventHandler(this.MouseOverOut);
			this.Paint += delegate(object sender, PaintEventArgs e) {
				if (BackColor == HoverColor) {
					e.Graphics.DrawPath(new Pen(Colors.AccentColor), Oblik.ZaobljeniPravougaonik(this.ClientRectangle, 10));
				}
			};
		}

		public void AzurirajPodatke(Knjiga knjiga) {
			this.knjigaUI1.Naziv = knjiga.preuzmiNaziv();
			Autor a = MenadzmentPodataka.autori.Find(i => i.preuzmiID() == knjiga.preuzmiIDAutora());
			this.knjigaUI1.Autor = a.preuzmiImePrezime();
			this.knjigaUI1.GodinaIzdanja = knjiga.preuzmiGodinuIzdavanja();
			this.label1.Text = knjiga.preuzmiNaziv();
			this.label2.Text = this.knjigaUI1.Autor;
		}

		void ZvezdastoDugme1Click(object sender, EventArgs e)
		{
			this.jeIzmenjen = true;
			zvezdastoDugme1.JeOmiljen = !JeOmiljena;
			for(int i = 0; i < MenadzmentPodataka.knjige.Count; i++) {
				if (MenadzmentPodataka.knjige[i].preuzmiID() == this.id) MenadzmentPodataka.knjige[i].postaviStatusOmiljeno(JeOmiljena);
			}
			this.JeOmiljenStatusJeIzmenjen.Invoke(this, new EventArgs());
		}

		protected void MouseOverIn(object sender, EventArgs e) {
			this.BackColor = HoverColor;
			Invalidate();
		}

		protected void MouseOverOut(object sender, EventArgs e) {
			this.BackColor = Colors.SvetlijaPozadina;
			Invalidate();
		}
		
		void Label1Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}
		
		void Label2Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}
		
		void DugmeKrug1Click(object sender, EventArgs e)
		{
			KnjigaSeBrise.Invoke(this, e);
		}
	}
}
