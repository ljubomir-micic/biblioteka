////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;

namespace Project {
    public class IzdavacUI : UserControl, IObjekatUI {
        private int _id;
        private static bool _brisanje = false;
        private Label nazivIzdavackeKuce;
        private PictureBox slikaIzdavackeKuce;
        private DugmeKrug dugmeKrug;
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
        
        public static bool Brisanje {
            get {
                return _brisanje;
            } set {
                _brisanje = value;
            }
        }
		
		public void KorigujVidljivostBrisanja() {
			this.dugmeKrug.Visible = IzdavacUI.Brisanje;
		}

        public event EventHandler IzdavacSeBrise = delegate { };

        public IzdavacUI() {

        }

        public IzdavacUI(Izdavac izdavac) {
            this._id = izdavac.preuzmiID();
            this.nazivIzdavackeKuce = new Label();
            this.slikaIzdavackeKuce = new PictureBox();
            this.dugmeKrug = new DugmeKrug();
            this.SuspendLayout();
            
            this.Size = new Size(167, 261);
            int size = Math.Min(this.Width, this.Height) - 50;

            ComponentResourceManager resources = new ComponentResourceManager(typeof(IzdavacUI));
            slikaIzdavackeKuce.BackgroundImage = ((Image)(resources.GetObject("Izdavac")));
            this.slikaIzdavackeKuce.BackgroundImageLayout = ImageLayout.Stretch;
            this.slikaIzdavackeKuce.Name = "slikaIzdavackeKuce";
            this.slikaIzdavackeKuce.Size = new Size(size, size);
            int positionV = (this.Width - this.slikaIzdavackeKuce.Width) / 2;
            this.slikaIzdavackeKuce.Location = new Point(positionV, positionV / 2);
            {
                System.Drawing.Drawing2D.GraphicsPath graphicsPath = new System.Drawing.Drawing2D.GraphicsPath();
                graphicsPath.StartFigure();
                graphicsPath.AddEllipse(this.slikaIzdavackeKuce.ClientRectangle);
                graphicsPath.CloseFigure();
                this.slikaIzdavackeKuce.Region = new Region(graphicsPath);
            }
            this.slikaIzdavackeKuce.MouseEnter += new EventHandler(MouseOverIn);
            this.slikaIzdavackeKuce.MouseLeave += new EventHandler(MouseOverOut);
            this.slikaIzdavackeKuce.Click += delegate(object sender, EventArgs e) {
                this.OnClick(e);
            };

            this.nazivIzdavackeKuce.AutoSize = false;
            this.nazivIzdavackeKuce.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.nazivIzdavackeKuce.Name = "nazivIzdavackeKuce";
            this.nazivIzdavackeKuce.Text = izdavac.preuzmiNaziv();
            this.nazivIzdavackeKuce.Size = new Size(this.Width - 2*7, (this.Height - positionV - slikaIzdavackeKuce.Size.Height - 3) / 2);
            this.nazivIzdavackeKuce.TextAlign = ContentAlignment.MiddleLeft;
            this.nazivIzdavackeKuce.Location = new Point(7, positionV + size - 3);
            this.nazivIzdavackeKuce.MouseEnter += new EventHandler(MouseOverIn);
            this.nazivIzdavackeKuce.MouseLeave += new EventHandler(MouseOverOut);
            this.nazivIzdavackeKuce.Click += delegate(object sender, EventArgs e) {
                this.OnClick(e);
            };

            int minSide = Math.Min(dugmeKrug.Width, dugmeKrug.Height);
            this.dugmeKrug.Location = new Point(((int) (1 / size * Math.Cos(Konverzija.StepeniURadijane(135)))) + minSide, ((int) (1 / size * Math.Sin(Konverzija.StepeniURadijane(135)))) + minSide);
			this.dugmeKrug.Visible = IzdavacUI.Brisanje;
			this.dugmeKrug.Pozadina = Color.FromArgb(240, 40, 40);
            this.dugmeKrug.Click += new EventHandler(DugmeKrugPritisnuto);

            this.Controls.Add(this.dugmeKrug);
            this.Controls.Add(this.slikaIzdavackeKuce);
            this.Controls.Add(this.nazivIzdavackeKuce);
            this.Cursor = Cursors.Hand;
            this.Name = "IzdavacUI";
            this.MouseEnter += new EventHandler(MouseOverIn);
            this.MouseLeave += new EventHandler(MouseOverOut);
            this.ResumeLayout();

            this.Paint += delegate(object sender, PaintEventArgs e) {
				if (BackColor == HoverColor) {
					e.Graphics.DrawPath(new Pen(Colors.AccentColor), Oblik.ZaobljeniPravougaonik(this.ClientRectangle, 10));
				}
			};
        }

		public void AzurirajPodatke(Izdavac izdavac) {
			this.nazivIzdavackeKuce.Text = izdavac.preuzmiNaziv();
		}

		protected void MouseOverIn(object sender, EventArgs e) {
			this.BackColor = HoverColor;
			Invalidate();
		}

		protected void MouseOverOut(object sender, EventArgs e) {
			this.BackColor = Colors.SvetlijaPozadina;
			Invalidate();
		}

        protected void DugmeKrugPritisnuto(object sender, EventArgs e) {
            IzdavacSeBrise.Invoke(this, e);
        }
    }
}