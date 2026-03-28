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
	public class ZvezdastoDugme : Button
	{
		private bool _jeOmiljen;
		private int kraci = 5;
		
		public bool JeOmiljen
		{
			get {
				return _jeOmiljen;
			}
			
			set {
				_jeOmiljen = value;
				Invalidate();
			}
		}

		public int Kraci
		{
			get {
				return kraci;
			}

			set {
				kraci = value;
			}
		}
		
		public ZvezdastoDugme()
		{
			this.JeOmiljen = false;
			this.FlatAppearance.BorderSize = 0;
			this.FlatStyle = FlatStyle.Flat;
			this.Cursor = Cursors.Hand;
		}
		
		protected override void OnPaint(PaintEventArgs pevent)
		{
			base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			pevent.Graphics.Clear(BackColor);
			pevent.Graphics.FillPath(new SolidBrush(JeOmiljen ? Colors.AccentColor : Color.DarkGray), Oblik.Zvezda(this.Size, this.Kraci));
		}
		
		protected bool Toggle(bool a)
		{
			return !a;
		}
		
		protected override void OnClick(EventArgs e)
		{
			base.OnClick(e);
//			JeOmiljen = Toggle(JeOmiljen);
		}
	}
}
