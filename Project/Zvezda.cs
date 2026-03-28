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
	public class Zvezda : Control
	{
		public Zvezda()
		{
		}
		
		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			pevent.Graphics.Clear(BackColor);
			pevent.Graphics.FillPath(new SolidBrush(Colors.AccentColor), Oblik.Zvezda(this.Size, 5));
		}
	}
}
