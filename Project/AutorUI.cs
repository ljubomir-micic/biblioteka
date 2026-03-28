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
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using CEBR = System.Int32;
using TAC = System.Boolean;
using BOJA = System.Drawing.Color;
using SLIKA = System.Drawing.Image;
using VELICINA = System.Drawing.Size;
using TACKA = System.Drawing.Point;

namespace Project
{
	public class AutorUI : UserControl, IObjekatUI {
        private CEBR _id;
        private static TAC _brisanje = false;
        PictureBox slikaAutor;
        Label imeAutor;
        DugmeKrug dugmeKrug;
		private BOJA _hoverColor = Podesavanja.Tema == ETema.Svetla ? BOJA.FromArgb(240, 240, 240) : BOJA.FromArgb(70, 70, 70);
        private CEBR grupaAutora;

        public CEBR id {
            get {
                return _id;
            } set {
                _id = value;
            }
        }
        
        public static TAC Brisanje {
            get {
                return _brisanje;
            } set {
                _brisanje = value;
            }
        }

		public BOJA HoverColor {
			get {
				return _hoverColor;
			} set {
				_hoverColor = value;
				Invalidate();
			}
		}

        public CEBR GrupaAutora {
            get {
                return grupaAutora;
            } set {
                grupaAutora = value;
            }
        }
		
		public void KorigujVidljivostBrisanja() {
			this.dugmeKrug.Visible = AutorUI.Brisanje;
		}

        public event EventHandler AutorSeBrise = delegate { };

        public AutorUI() {
            id = 0;
            GrupaAutora = 0;
        }

        public AutorUI(Autor autor) {
            id = autor.preuzmiID();
            slikaAutor = new PictureBox();
            imeAutor = new Label();
            dugmeKrug = new DugmeKrug();
            GrupaAutora = 0;
            this.SuspendLayout();

            // Podesavanja komponenti
			this.Size = new VELICINA(167, 261);
			
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AutorUI));
            slikaAutor.BackgroundImage = ((SLIKA)(resources.GetObject("Autor")));
			this.slikaAutor.BackgroundImageLayout = ImageLayout.Stretch;
            CEBR VELICINA = Math.Min(this.Width, this.Height) - 50;
            this.slikaAutor.Size = new VELICINA(VELICINA, VELICINA);
            CEBR positionV = (this.Width - this.slikaAutor.Width) / 2;
            this.slikaAutor.Location = new TACKA(positionV, positionV / 2);
            {
                System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
                graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.slikaAutor.ClientRectangle);
                graphicsPath.CloseFigure();
                this.slikaAutor.Region = new Region(graphicsPath);
            }
            this.slikaAutor.Click += new EventHandler(slikaAutorClick);
            this.slikaAutor.MouseEnter += new EventHandler(MouseOverIn);
            this.slikaAutor.MouseLeave += new EventHandler(MouseOverOut);

            this.imeAutor.AutoSize = false;
            this.imeAutor.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.imeAutor.Text = autor.preuzmiImePrezime();
            this.imeAutor.Size = new VELICINA(this.Width - 2*7, (this.Height - positionV - slikaAutor.Size.Height - 3) / 2);
            this.imeAutor.TextAlign = ContentAlignment.MiddleLeft;
            this.imeAutor.Location = new TACKA(7, (slikaAutor.Location.Y * 2 + slikaAutor.Size.Height));
            this.imeAutor.MouseEnter += new EventHandler(MouseOverIn);
            this.imeAutor.MouseLeave += new EventHandler(MouseOverOut);
            this.imeAutor.Click += new EventHandler(imeAutorClick);

            CEBR minSide = Math.Min(dugmeKrug.Width, dugmeKrug.Height);
            // SIN I COS UGLA 135º -> Rad
            this.dugmeKrug.Location = new TACKA(((CEBR) (1 / VELICINA * Math.Cos(Konverzija.StepeniURadijane(135)))) + minSide, ((CEBR) (1 / VELICINA * Math.Sin(Konverzija.StepeniURadijane(135)))) + minSide);
			this.dugmeKrug.Visible = AutorUI.Brisanje;
			this.dugmeKrug.Pozadina = BOJA.FromArgb(240, 40, 40);
            this.dugmeKrug.Click += new EventHandler(DugmeKrugPritisnuto);

            // Podesavanja AutorUI
            this.Controls.Add(this.dugmeKrug);
            this.Controls.Add(this.slikaAutor);
            this.Controls.Add(this.imeAutor);
            this.Cursor = Cursors.Hand;
            this.Name = "AutorUI";
            this.MouseEnter += new EventHandler(MouseOverIn);
            this.MouseLeave += new EventHandler(MouseOverOut);
            this.ResumeLayout();

            this.Paint += delegate(object sender, PaintEventArgs e) {
				if (BackColor == HoverColor) {
					e.Graphics.DrawPath(new Pen(Colors.AccentColor), Oblik.ZaobljeniPravougaonik(this.ClientRectangle, 10));
				}
            };
		}

        public AutorUI(Autor[] autori) {
            id = id;
            slikaAutor = new PictureBox();
            imeAutor = new Label();
            dugmeKrug = new DugmeKrug();
            GrupaAutora = 1;
            this.SuspendLayout();

            // Podesavanja komponenti
			this.Size = new VELICINA(167, 261);
			
            ComponentResourceManager resources = new ComponentResourceManager(typeof(AutorUI));
            slikaAutor.BackgroundImage = ((SLIKA)(resources.GetObject("AutorGroup")));
			this.slikaAutor.BackgroundImageLayout = ImageLayout.Stretch;
            CEBR VELICINA = Math.Min(this.Width, this.Height) - 50;
            this.slikaAutor.Size = new VELICINA(VELICINA, VELICINA);
            CEBR positionV = (this.Width - this.slikaAutor.Width) / 2;
            this.slikaAutor.Location = new TACKA(positionV, positionV / 2);
            {
                System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
                graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.slikaAutor.ClientRectangle);
                graphicsPath.CloseFigure();
                this.slikaAutor.Region = new Region(graphicsPath);
            }
            this.slikaAutor.Click += new EventHandler(slikaAutorClick);
            this.slikaAutor.MouseEnter += new EventHandler(MouseOverIn);
            this.slikaAutor.MouseLeave += new EventHandler(MouseOverOut);

            this.imeAutor.AutoSize = false;
            this.imeAutor.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.imeAutor.Text = "";
            foreach (var autor in autori) this.imeAutor.Text += autor == autori.Last() ? autor.preuzmiPrezime() : (autor.preuzmiPrezime() + ", ");
            this.imeAutor.Size = new VELICINA(this.Width - 2*7, (this.Height - positionV - slikaAutor.Size.Height - 3) / 2);
            this.imeAutor.TextAlign = ContentAlignment.MiddleLeft;
            this.imeAutor.Location = new TACKA(7, (slikaAutor.Location.Y * 2 + slikaAutor.Size.Height));
            this.imeAutor.MouseEnter += new EventHandler(MouseOverIn);
            this.imeAutor.MouseLeave += new EventHandler(MouseOverOut);
            this.imeAutor.Click += new EventHandler(imeAutorClick);

            CEBR minSide = Math.Min(dugmeKrug.Width, dugmeKrug.Height);
            // SIN I COS UGLA 135º -> Rad
            this.dugmeKrug.Location = new TACKA(((CEBR) (1 / VELICINA * Math.Cos(Konverzija.StepeniURadijane(135)))) + minSide, ((CEBR) (1 / VELICINA * Math.Sin(Konverzija.StepeniURadijane(135)))) + minSide);
			this.dugmeKrug.Visible = AutorUI.Brisanje;
			this.dugmeKrug.Pozadina = BOJA.FromArgb(240, 40, 40);
            this.dugmeKrug.Click += new EventHandler(DugmeKrugPritisnuto);

            // Podesavanja AutorUI
            this.Controls.Add(this.dugmeKrug);
            this.Controls.Add(this.slikaAutor);
            this.Controls.Add(this.imeAutor);
            this.Cursor = Cursors.Hand;
            this.Name = "AutorUI";
            this.MouseEnter += new EventHandler(MouseOverIn);
            this.MouseLeave += new EventHandler(MouseOverOut);
            this.ResumeLayout();

            this.Paint += delegate(object sender, PaintEventArgs e) {
				if (BackColor == HoverColor) {
					e.Graphics.DrawPath(new Pen(Colors.AccentColor), Oblik.ZaobljeniPravougaonik(this.ClientRectangle, 10));
				}
            };
        }

		public void AzurirajPodatke(Autor autor) {
			this.imeAutor.Text = autor.preuzmiImePrezime();
		}

		protected void MouseOverIn(object sender, EventArgs e) {
			this.BackColor = HoverColor;
			Invalidate();
		}

		protected void MouseOverOut(object sender, EventArgs e) {
			this.BackColor = Colors.SvetlijaPozadina;
			Invalidate();
		}

        protected void slikaAutorClick(object sender, EventArgs e) {
            this.OnClick(e);
        }

        protected void imeAutorClick(object sender, EventArgs e) {
            this.OnClick(e);
        }

        protected void DugmeKrugPritisnuto(object sender, EventArgs e) {
            AutorSeBrise.Invoke(this, e);
        }
    }
}