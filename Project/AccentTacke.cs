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

namespace Project
{
	public class AccentTacke : Label
	{
		private int brojTacaka = 3;
		private float velicinaTacaka = 6;
		private float razmak = 4;
		private int jeAktivna = 0;
		
		public int BrojTacaka {
			get {
				return brojTacaka;
			}
			set {
				brojTacaka = value;
				PromeniDuzinu();
			}
		}
		
		public float VelicinaTacaka {
			get {
				return velicinaTacaka;
			}
			set {
				velicinaTacaka = value;
				PromeniDuzinu();
			}
		}
		
		public float Razmak {
			get {
				return razmak;
			}
			set {
				razmak = value;
				PromeniDuzinu();
			}
		}
		
		public int JeAktivna {
			get {
				return jeAktivna;
			}
			set {
				if (Math.Abs(value) < BrojTacaka) jeAktivna = Math.Abs(value);
				Invalidate();
			}
		}
	
		protected void PromeniDuzinu() {
			this.Width = (int)BrojTacaka * (int)VelicinaTacaka + ((int)BrojTacaka - 1) * (int)Razmak + 12;
			Invalidate();
		}
		
		public AccentTacke()
		{
			this.BackColor = Colors.AccentColor;
			PromeniDuzinu();
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.Parent.BackColor);
            
            for (int i = 0; i < BrojTacaka; i++) {
            	if (i > this.JeAktivna) {
            		e.Graphics.DrawEllipse(new Pen(Color.Gray), new RectangleF(6 + this.Razmak * i + this.VelicinaTacaka * i, this.Height / 2 - VelicinaTacaka / 2, VelicinaTacaka, VelicinaTacaka));
            	} else if (i == this.JeAktivna) {
            		e.Graphics.DrawEllipse(new Pen(this.BackColor), new RectangleF(6 + this.Razmak * i + this.VelicinaTacaka * i, this.Height / 2 - VelicinaTacaka / 2, VelicinaTacaka, VelicinaTacaka));
            		e.Graphics.FillEllipse(new SolidBrush(ControlPaint.Light(this.BackColor)), new RectangleF(6 + this.Razmak * i + this.VelicinaTacaka * i, this.Height / 2 - VelicinaTacaka / 2, VelicinaTacaka, VelicinaTacaka));
            	} else {
					e.Graphics.DrawEllipse(new Pen(this.BackColor), new RectangleF(6 + this.Razmak * i + this.VelicinaTacaka * i, this.Height / 2 - VelicinaTacaka / 2, VelicinaTacaka, VelicinaTacaka));
            		e.Graphics.FillEllipse(new SolidBrush(this.BackColor), new RectangleF(6 + this.Razmak * i + this.VelicinaTacaka * i, this.Height / 2 - VelicinaTacaka / 2, VelicinaTacaka, VelicinaTacaka));
            	}
            }
		}
	}
}
