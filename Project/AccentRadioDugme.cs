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
	public class AccentRadioDugme : RadioButton
	{
		public AccentRadioDugme()
		{
		}
		
		protected override void OnPaint(PaintEventArgs pevent)
		{
			int poluprecnik1 = 8;
			int poluprecnik2 = 4;
			Point centar = new Point(24, this.Height / 2);
			pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);
            
            if (this.Checked) {
            	pevent.Graphics.DrawEllipse(new Pen(Colors.BojaTeksta), new RectangleF(centar.X - poluprecnik1, centar.Y - poluprecnik1, poluprecnik1 * 2, poluprecnik1 * 2));
            	pevent.Graphics.FillEllipse(new SolidBrush(Colors.AccentColor), new RectangleF(centar.X - poluprecnik1, centar.Y - poluprecnik1, poluprecnik1 * 2, poluprecnik1 * 2));
            	pevent.Graphics.FillEllipse(new SolidBrush(Color.White),new RectangleF(centar.X - poluprecnik2, centar.Y - poluprecnik2, poluprecnik2 * 2, poluprecnik2 * 2));
            } else {
            	pevent.Graphics.DrawEllipse(new Pen(Colors.BojaTeksta), new RectangleF(centar.X - poluprecnik1, centar.Y - poluprecnik1, poluprecnik1 * 2, poluprecnik1 * 2));
            }
            
    		SizeF velicinaStringa = pevent.Graphics.MeasureString(this.Text, this.Font);
            pevent.Graphics.DrawString(this.Text, this.Font, new SolidBrush(Colors.BojaTeksta), (centar.X + poluprecnik1) + 3, this.Height / 2 - velicinaStringa.Height / 2);
		}
	}
}