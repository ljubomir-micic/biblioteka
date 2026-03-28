////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using STR = System.String;
using TAC = System.Boolean;
using CEBR = System.Int32;

namespace Project {
    public class TemaUI : Control {
        private Color[] boje;
        private TAC misJeNa;
        private TAC jeSelektovan;
        private STR naziv;
        private CEBR margina;

        public override STR Text {
            get {
                return naziv;
            } set { 
                naziv = value;
            }
        }

        public TAC JeSelektovana {
            get {
                return jeSelektovan;
            } set {
                jeSelektovan = value;
                Invalidate();
            }
        }

        public Color Boja1 {
            get {
                return boje[0];
            } set {
                boje[0] = value;
                Invalidate();
            }
        }

        public Color Boja2 {
            get {
                return boje[1];
            } set {
                boje[1] = value;
                Invalidate();
            }
        }

        public Color Boja3 {
            get {
                return boje[2];
            } set {
                boje[2] = value;
                Invalidate();
            }
        }

        public event EventHandler JeSelektovanaJeIzmenjeno = delegate {};
        
        public TemaUI() {
            this.boje = new Color[3];
            this.Size = new Size(75, 75);
            this.margina = 8;
            this.misJeNa = false;
            Boja1 = Colors.AccentColor;
            Boja2 = Colors.SvetlijaPozadina;
            Boja3 = Colors.TamnijaPozadina;
            this.Click += delegate(object sender, EventArgs e) { 
            	foreach (Control kontrola in this.Parent.Controls) {
            		if (kontrola is TemaUI) ((TemaUI) kontrola).JeSelektovana = false;
            	}
            	
            	this.JeSelektovana = true;
            	JeSelektovanaJeIzmenjeno.Invoke(this, e);
            };
        }

        public TemaUI(STR Naziv_Teme, TAC jeSelektovana, Color boja1, Color boja2, Color boja3) {
            this.boje = new Color[3];
            this.Size = new Size(75, 75);
            this.margina = 8;
            this.naziv = Naziv_Teme;
            this.misJeNa = false;
            this.jeSelektovan = jeSelektovana;
            this.Boja1 = boja1;
            this.Boja2 = boja2;
            this.Boja3 = boja3;
            this.Click += delegate(object sender, EventArgs e) { 
            	foreach (Control kontrola in this.Parent.Controls) {
            		if (kontrola is TemaUI) ((TemaUI) kontrola).JeSelektovana = false;
            	}
            	
            	this.JeSelektovana = true;
            	JeSelektovanaJeIzmenjeno.Invoke(this, e);
            };
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            misJeNa = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            misJeNa = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
			Color _hoverColor = Podesavanja.Tema == ETema.Svetla ? Color.FromArgb(240, 240, 240) : Color.FromArgb(70, 70, 70);
			e.Graphics.Clear(this.misJeNa ? _hoverColor : this.Parent.BackColor);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            CEBR duzina = (this.Width - 2 * margina - 2 * 1) / 3, visina = (CEBR) (this.Height - 3.4 * margina);
            e.Graphics.FillRectangle(new SolidBrush(Colors.BojaTeksta), new Rectangle(margina, margina, duzina * 3 + 3, visina + 1));
            for (CEBR i = 0; i < 3; i++) e.Graphics.FillRectangle(new SolidBrush(this.boje[i]), new Rectangle(margina + i * duzina + i * 1, margina, duzina, visina));

            e.Graphics.DrawString(this.naziv, this.Font, new SolidBrush(Colors.BojaTeksta), new PointF((float) (margina * 0.8), (CEBR) (this.Height - margina * 2.4)));
            if (misJeNa || jeSelektovan) e.Graphics.DrawPath(new Pen(Colors.AccentColor), Oblik.ZaobljeniPravougaonik(new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1)), 3));
            base.OnPaint(e);
        }
    }
}