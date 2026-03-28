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
using TAC = System.Boolean;
using DUZINA = System.Int32;

namespace Project
{
	public class AccentDugme : Button
	{
		private TAC kursorNaDugmetu = false;
		private TAC jeSelektovan = false;
		
		public TAC KursorNaDugmetu {
			get { return kursorNaDugmetu; }
			set {
				kursorNaDugmetu = value;
				Invalidate();
			}
		}

		public TAC JeSelektovan {
			get { return jeSelektovan; }
			set {
				jeSelektovan = value;
				Invalidate();
			}
		}
		
		public AccentDugme()
		{
			this.BackColor = Colors.AccentColor;
			this.ForeColor = Color.White;
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Cursor = Cursors.Hand;
		}
		
		protected override void OnMouseEnter(EventArgs e)
		{
			KursorNaDugmetu = true;
		}
		
		protected override void OnMouseLeave(EventArgs e)
		{
			KursorNaDugmetu = false;
		}

		protected override void OnEnter(EventArgs e) {
			JeSelektovan = true;
		}

		protected override void OnLeave(EventArgs e) {
			JeSelektovan = false;
		}

		protected override void OnPaint(PaintEventArgs pevent)
		{
			DUZINA toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            TextFormatFlags flags = TextFormatFlags.Bottom;
    		SizeF velicinaStringa = pevent.Graphics.MeasureString(this.Text, this.Font);
    		Point pocetnaTackaStringa = new Point((DUZINA)this.Width / 2 - (DUZINA)velicinaStringa.Width / 2, this.Height / 2 + (DUZINA)velicinaStringa.Height / 2);

    		pevent.Graphics.FillPath(new SolidBrush(this.Enabled ? (this.KursorNaDugmetu ? ControlPaint.Light(this.BackColor) : this.BackColor) : Color.Gray), Oblik.GlavniOblik(this.Size));
		    TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, pocetnaTackaStringa, this.ForeColor, flags);
			if (JeSelektovan) pevent.Graphics.DrawPath(new Pen(Colors.BojaTeksta), Oblik.GlavniOblik(this.Size));
		}
	}
}
