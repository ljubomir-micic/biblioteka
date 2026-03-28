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
    public class AccentPrekidac : CheckBox
    {
        private Color onBackColor = Colors.AccentColor;

        public Color OnBackColor {
            get
            {
                return onBackColor;
            }
            
            set
            {
                onBackColor = value;
                this.Invalidate();
            }
        }

        public AccentPrekidac()
        {
        	this.Size = new Size(41, 24);
        	this.Cursor = Cursors.Hand;
        }

        public override string Text {
            get
            {
                return base.Text;
            }

            set
            {
            	
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if(this.Checked) {
                pevent.Graphics.FillPath(new SolidBrush(onBackColor), Oblik.Kapsula(this.ClientSize));
            	pevent.Graphics.DrawPath(new Pen(Colors.BojaTeksta), Oblik.Kapsula(this.ClientSize));
                pevent.Graphics.FillEllipse(new SolidBrush(Color.White), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            } else {
            	pevent.Graphics.FillPath(new SolidBrush(ControlPaint.Dark(Colors.TamnijaPozadina)), Oblik.Kapsula(this.ClientSize));
            	pevent.Graphics.DrawPath(new Pen(Colors.BojaTeksta), Oblik.Kapsula(this.ClientSize));
                pevent.Graphics.FillEllipse(new SolidBrush(Color.White), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
    }
}
