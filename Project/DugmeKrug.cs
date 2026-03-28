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
	public class DugmeKrug : Button
	{
		private Color bojaPozadine = Colors.BojaTeksta;

		public Color Pozadina { 
			get {
				return bojaPozadine;
			} set {
                bojaPozadine = value;
                Invalidate();
            }
		}

		public DugmeKrug()
		{
		}

		protected override void OnPaint(PaintEventArgs e) {
			e.Graphics.Clear(Color.Transparent);
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			int stranica = Math.Min(Width - 1, Height - 1);
    		SizeF velicinaStringa = e.Graphics.MeasureString("" + KnjigaInfoUI.Oznaka, this.Font);

			e.Graphics.FillEllipse(new SolidBrush(Pozadina), new Rectangle(0, 0, stranica, stranica));
			e.Graphics.DrawEllipse(new Pen(ControlPaint.Dark(Pozadina)), new Rectangle(0, 0, stranica, stranica));
			e.Graphics.DrawString("" + KnjigaInfoUI.Oznaka, this.Font, new SolidBrush(ControlPaint.Dark(Pozadina)), new Point((int)stranica / 2 - (int)velicinaStringa.Width / 2, stranica / 2 - (int)velicinaStringa.Height / 2 + 1));
			
			GraphicsPath krug = new GraphicsPath();
			krug.AddEllipse(new Rectangle(0, 0, stranica, stranica));
			krug.CloseFigure();
			this.Region = new Region(krug);
		}
	}
}
