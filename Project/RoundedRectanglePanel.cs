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
using CEBR = System.Int32;
using TACKA = System.Drawing.Point;

namespace Project
{
	public class RoundedRectanglePanel : Panel
	{
		public RoundedRectanglePanel()
		{
			this.BackColor = Colors.AccentColor;
		}
		
		protected GraphicsPath OblikFigure() {
			CEBR arcSize = this.Height - 1;
            Rectangle upperLeftArc = new Rectangle(0, 0, arcSize, arcSize);
            Rectangle upperRightArc = new Rectangle(this.Width - arcSize, 0, arcSize, arcSize);

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(upperLeftArc, 90, 180/2);
            path.AddLine(new TACKA(0, this.Height/2), new TACKA(0, 0));
            path.AddArc(upperRightArc, 270, 180/2);
            path.AddLine(new TACKA(this.Width, this.Height/2), new TACKA(this.Width, this.Height));
            path.CloseFigure();

            return path;
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			CEBR toggleSize = this.Height - 5;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.Parent.BackColor);
            
      		e.Graphics.FillPath(new SolidBrush(BackColor), OblikFigure());
		}

		protected override void OnResize(EventArgs eventargs)
		{
			base.OnResize(eventargs);
			Invalidate();
		}
	}
}
