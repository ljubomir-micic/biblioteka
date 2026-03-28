////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using CEBR = System.Int32;
using STR = System.String;
using BOJA = System.Drawing.Color;
using VELICINA = System.Drawing.Size;

namespace Project
{
	public partial class KnjigaUI : UserControl
	{
		STR ime, autor;
		CEBR godinaIzdanja;
		
		[Category("Detalji Knjige")]
		public STR Naziv {
			get { return ime; }
			set {
				ime = value;
				label1.Text = ime;
				this.BackColor = BookColor(this.ime);
			}
		}
		
		[Category("Detalji Knjige")]
		public STR Autor {
			get { return autor; }
			set {
				autor = value;
				label2.Text = (godinaIzdanja != 0) ? (autor + "\n" + godinaIzdanja) : (autor + "\n");
			}
		}

		[Category("Detalji Knjige")]
		public CEBR GodinaIzdanja {
			get { return godinaIzdanja; }
			set {
				godinaIzdanja = value;
				label2.Text = (godinaIzdanja != 0) ? (autor + "\n" + godinaIzdanja) : (autor + "\n");
			}
		}
		
		protected override VELICINA DefaultSize {
			get { return new VELICINA(125, 167); }
		}
		
		public static BOJA BookColor(STR Naziv) {
			if (Naziv == null) {
				return BOJA.Gray;
			} else if (Naziv.Length % 3 == 0) {
				return Colors.AccentColor;
			} else if (Naziv.Length % 3 == 1) {
				return Colors.BookColor2;
			} else {
				return Colors.BookColor3;
			}
		}
		
		public KnjigaUI()
		{
			InitializeComponent();
		}
		
		public KnjigaUI(STR naziv, STR autor)
		{
			InitializeComponent();
			
			this.Naziv = naziv;
			this.Autor = autor;
		}
		
		public KnjigaUI(STR naziv, STR autor, CEBR godinaIzdanja)
		{
			InitializeComponent();
			
			this.Naziv = naziv;
			this.Autor = autor;
			this.GodinaIzdanja = godinaIzdanja;
		}
		
		public KnjigaUI(Knjiga knjiga, List<Autor> autori)
		{
			InitializeComponent();
			
			this.Naziv = knjiga.preuzmiNaziv();
			Autor a = autori.Find(i => i.preuzmiID() == knjiga.preuzmiIDAutora());
			this.Autor = a.preuzmiIme() + " " + a.preuzmiPrezime();
			this.GodinaIzdanja = knjiga.preuzmiGodinuIzdavanja();
		}
	}
}
