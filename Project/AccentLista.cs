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
	public class AccentLista : ListBox
	{
		private int rectHeight = 25;
		private Color selectedColor = Colors.AccentColor;
		
		public int RectHeight {
			get { return rectHeight; }
			set { rectHeight = value; }
		}
		
		public Color SelectedColor {
			get { return selectedColor; }
			set { selectedColor = value; }
		}
		
		public AccentLista()
		{
			SelectedColor = Colors.AccentColor;
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
			for (int itemIndex = 0; itemIndex < this.Items.Count; itemIndex++) {
				Rectangle itemRectangle = GetItemRectangle(itemIndex);
				if (e.ClipRectangle.IntersectsWith(itemRectangle)) {
					if (SelectedIndices.Contains(itemIndex)) {
						DrawItemEventArgs drawItemEventArgs = new DrawItemEventArgs(e.Graphics, this.Font, itemRectangle, itemIndex, DrawItemState.Checked);
						OnDrawItem(drawItemEventArgs);
					} else {
						DrawItemEventArgs drawItemEventArgs = new DrawItemEventArgs(e.Graphics, this.Font, itemRectangle, itemIndex, DrawItemState.None);
						OnDrawItem(drawItemEventArgs);
					}
				}
			}
		}
		
		protected override void OnDrawItem(DrawItemEventArgs e)
		{
			TextFormatFlags flags = TextFormatFlags.Bottom;
    		
			// base.OnDrawItem(e);
			if (e.State == DrawItemState.Checked) e.Graphics.FillRectangle(new SolidBrush(SelectedColor), e.Bounds);
			else e.Graphics.FillRectangle(new SolidBrush(BackColor), e.Bounds);
			// DONE: Tekst je, nakon drugog predmeta, ofsetovan po Y osi vise no sto je potrebno
			TextRenderer.DrawText(e.Graphics, this.Items[e.Index].ToString(), this.Font, new Rectangle(e.Bounds.X + 5, e.Bounds.Y, e.Bounds.Width - 5, e.Bounds.Height), (e.State == DrawItemState.Checked) ? Color.White : Colors.BojaTeksta, flags);
		}
		
		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);
			if (e.Button != MouseButtons.None) this.Invalidate(true);
		}
		
		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			this.Invalidate(true);
		}
		
		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);
			this.Invalidate();
		}
	}
}
