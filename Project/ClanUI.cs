////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using ZNAK = System.Char;
using CEBR = System.Int32;
using TAC = System.Boolean;
using BOJA = System.Drawing.Color;
using SLIKA = System.Drawing.Image;
using VELICINA = System.Drawing.Size;
using TACKA = System.Drawing.Point;

namespace Project {
    public class ClanUI : UserControl, IObjekatUI {
        private CEBR _id;
        private static TAC _brisanje = false;
        private TAC jeProsaoRok = false;
        private static ZNAK uzvicnik = '❕';
        private Label imePrezimeClana;
        private PictureBox slikaClana;
        private DugmeKrug dugmeKrug;
        private BOJA _hoverColor = Podesavanja.Tema == ETema.Svetla ? BOJA.FromArgb(240, 240, 240) : BOJA.FromArgb(70, 70, 70);
        private Font Font1;

        public CEBR id {
            get {
                return _id;
            } set {
                _id = value;
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

        public TAC JeProsaoRok {
            get {
                return jeProsaoRok;
            } set {
                this.jeProsaoRok = value;
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Podesavanja));
                slikaClana.BackgroundImage = this.jeProsaoRok ? ((SLIKA)(resources.GetObject("CrvenaSlikaClana"))) : ((SLIKA)(resources.GetObject("slikaProfila.Image")));
                this.imePrezimeClana.ForeColor = this.jeProsaoRok ? Colors.AccentColor : Colors.BojaTeksta;
                Invalidate();
            }
        }
        
        public static TAC Brisanje {
            get {
                return _brisanje;
            } set {
                _brisanje = value;
            }
        }
		
		public void KorigujVidljivostBrisanja() {
			 this.dugmeKrug.Visible = ClanUI.Brisanje;
		}

        public event EventHandler ClanSeBrise = delegate { };

        public ClanUI() {

        }

        public ClanUI(Clan clan) {
            this._id = clan.preuzmiID();
            this.imePrezimeClana = new Label();
            this.slikaClana = new PictureBox();
            this.dugmeKrug = new DugmeKrug();
            this.SuspendLayout();
            
            this.Size = new VELICINA(167, 261);
            CEBR size = Math.Min(this.Width, this.Height) - 50;

            ComponentResourceManager resources = new ComponentResourceManager(typeof(Podesavanja));
            slikaClana.BackgroundImage = ((SLIKA)(resources.GetObject("slikaProfila.Image")));
            this.slikaClana.BackgroundImageLayout = ImageLayout.Stretch;
            this.slikaClana.Name = "slikaClana";
            this.slikaClana.Size = new VELICINA(size, size);
            CEBR positionV = (this.Width - this.slikaClana.Width) / 2;
            this.slikaClana.Location = new TACKA(positionV, positionV / 2);
            {
                System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
                graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.slikaClana.ClientRectangle);
                graphicsPath.CloseFigure();
                this.slikaClana.Region = new Region(graphicsPath);
            }
            this.slikaClana.MouseEnter += new EventHandler(MouseOverIn);
            this.slikaClana.MouseLeave += new EventHandler(MouseOverOut);
            this.slikaClana.Click += delegate(object sender, EventArgs e) {
                this.OnClick(e);
            };

            this.imePrezimeClana.AutoSize = false;
            this.imePrezimeClana.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.imePrezimeClana.Name = "imePrezimeClana";
            this.imePrezimeClana.Text = clan.preuzmiIme() + " " + clan.preuzmiPrezime();
            this.imePrezimeClana.Size = new VELICINA(this.Width - 2*7, (this.Height - positionV - slikaClana.Size.Height - 3) / 2);
            this.imePrezimeClana.TextAlign = ContentAlignment.MiddleLeft;
            this.imePrezimeClana.Location = new TACKA(7, positionV + size - 3);
            this.imePrezimeClana.MouseEnter += new EventHandler(MouseOverIn);
            this.imePrezimeClana.MouseLeave += new EventHandler(MouseOverOut);
            this.imePrezimeClana.Click += delegate(object sender, EventArgs e) {
                this.OnClick(e);
            };

            CEBR minSide = Math.Min(dugmeKrug.Width, dugmeKrug.Height);
            this.dugmeKrug.Location = new TACKA(((CEBR) (1 / size * Math.Cos(Konverzija.StepeniURadijane(135)))) + minSide, ((CEBR) (1 / size * Math.Sin(Konverzija.StepeniURadijane(135)))) + minSide);
			this.dugmeKrug.Visible = ClanUI.Brisanje;
			this.dugmeKrug.Pozadina = BOJA.FromArgb(240, 40, 40);
            this.dugmeKrug.Click += new EventHandler(DugmeKrugPritisnuto);

            this.JeProsaoRok = this.jeProsaoRokZaVracanjeIkojeKnjige(clan);
            this.Controls.Add(this.dugmeKrug);
            this.Controls.Add(this.slikaClana);
            this.Controls.Add(this.imePrezimeClana);
            this.Cursor = Cursors.Hand;
            this.Font1 = new Font("Segoe UI", 12.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.Name = "IzdavacUI";
            this.MouseEnter += new EventHandler(MouseOverIn);
            this.MouseLeave += new EventHandler(MouseOverOut);
            this.ResumeLayout();

            this.Paint += delegate(object sender, PaintEventArgs e) {
				if (BackColor == HoverColor) {
					e.Graphics.DrawPath(new Pen(Colors.AccentColor), Oblik.ZaobljeniPravougaonik(this.ClientRectangle, 10));
				}
            	if (JeProsaoRok) {
            		e.Graphics.DrawString("" + ClanUI.uzvicnik, this.Font1, new SolidBrush(BOJA.Red), new TACKA(((CEBR) ((size + 40) * Math.Cos(Konverzija.StepeniURadijane(45)))) + minSide, ((CEBR) (1 / size * Math.Sin(Konverzija.StepeniURadijane(135)))) + minSide));
            	}
			};
        }

        public TAC jeProsaoRokZaVracanjeIkojeKnjige(Clan clan) {
        	for (CEBR i = 0; i < clan.preuzmiIznajmljeneKnjige().Length; i ++) if (clan.preuzmiIznajmljeneKnjige()[i] != -1) {
        		System.Collections.Generic.List<ArhivaIznajmljivanja> arhive = MenadzmentPodataka.arhiva.FindAll(x => (x.preuzmiIDClan() == this.id && x.preuzmiIDKnjige() == clan.preuzmiIznajmljeneKnjige()[i] && x.preuzmiStatus() == EIznajmljivanjeVracanje.Iznajmljena));
                if (arhive == null) continue;
                foreach (var arhiva in arhive) {
                    if (!arhiva.preuzmiJeVracena() && ((DateTime.Now - arhiva.preuzmiDatum()).TotalDays >= 15)) {
                        // System.Diagnostics.Debug.WriteLine(true);
                        return true;
                    }
                }
            }
            // System.Diagnostics.Debug.WriteLine(false);
            return false;
        }

		public void AzurirajPodatke(Clan clan) {
			this.imePrezimeClana.Text = clan.preuzmiIme() + " " + clan.preuzmiPrezime();
		}

		protected void MouseOverIn(object sender, EventArgs e) {
			this.BackColor = HoverColor;
			Invalidate();
		}

		protected void MouseOverOut(object sender, EventArgs e) {
			this.BackColor = Colors.SvetlijaPozadina;
			Invalidate();
		}

        private void DugmeKrugPritisnuto(object sender, EventArgs e) {
            ClanSeBrise.Invoke(this, e);
        }
    }
}