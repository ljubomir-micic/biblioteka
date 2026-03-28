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
using STR = System.String;
using DECF = System.Single;

namespace Project {
	public class AccentTrakaOpcija : Control {
		STR[] opcije;
		CEBR selektovana;

		public CEBR OpcijaSelektovana {
			get {
				return selektovana;
			} set {
				selektovana = value;
				Invalidate();
				SelektovanIndeksPromenjen.Invoke(this, new EventArgs());
				// System.Diagnostics.Debug.WriteLine(selektovana);
			}
		}

		STR[] Opcije {
			get {
				return opcije;
			} set {
				opcije = value;
			}
		}
		
		public override Cursor Cursor {
			get { return Cursors.Hand; }
		}

		protected void DodajOpciju(STR opcija)
        {
            Array.Resize(ref opcije, Opcije.Length + 1);
            Opcije[Opcije.Length - 1] = opcija;
			Invalidate();
        }

		public event EventHandler SelektovanIndeksPromenjen = delegate { };

		public AccentTrakaOpcija()
		{
			this.opcije = new STR[0];
		}

		public AccentTrakaOpcija(STR[] opcije, CEBR selektovana)
		{
			this.opcije = new STR[0];
			foreach (var opcija in opcije) DodajOpciju(opcija);
			OpcijaSelektovana = selektovana;
			this.MouseDown += new MouseEventHandler(ClickMisa);
		}

		void ClickMisa(object sender, MouseEventArgs e) {
			if (e.Button != MouseButtons.Left) return;
			DECF pojedinacnaDebljinaX = (DECF) this.Width / opcije.Length;
			DECF lokacijaX = (DECF) e.X;
			OpcijaSelektovana = (CEBR) (lokacijaX / pojedinacnaDebljinaX);
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
        	e.Graphics.Clear(this.Parent.BackColor);
			DECF pojedinacnaDebljina = this.Width / opcije.Length - (opcije.Length - 1);
			e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
			e.Graphics.DrawPath(new Pen(Colors.TamnijaPozadina), Oblik.ZaobljeniPravougaonik(this.ClientRectangle, 5));
			for (CEBR i = 1; i < Opcije.Length; i++) e.Graphics.DrawLine(new Pen(Colors.TamnijaPozadina), new Point((CEBR) pojedinacnaDebljina * i, 3), new Point((CEBR) pojedinacnaDebljina * i, this.Height - 3));
			e.Graphics.FillPath(new SolidBrush(Colors.AccentColor), Oblik.ZaobljeniPravougaonik(new Rectangle(new Point((CEBR) (OpcijaSelektovana * (pojedinacnaDebljina+1)), 0), new Size((CEBR) pojedinacnaDebljina, this.Height)), 3));
			e.Graphics.DrawPath(new Pen(Colors.AccentColor), Oblik.ZaobljeniPravougaonik(new Rectangle(new Point((CEBR) (OpcijaSelektovana * (pojedinacnaDebljina+1)), 0), new Size((CEBR) pojedinacnaDebljina, this.Height)), 3));
			e.Graphics.SmoothingMode = SmoothingMode.Default;
			for (CEBR i = 0; i < Opcije.Length; i++) {
				SizeF velicinaStringa = e.Graphics.MeasureString(Opcije[i], Font);
				e.Graphics.DrawString(Opcije[i], Font, new SolidBrush((i == OpcijaSelektovana) ? Color.White : Colors.BojaTeksta), new PointF(i * (pojedinacnaDebljina+1) + (pojedinacnaDebljina - velicinaStringa.Width)/2, (this.Height - velicinaStringa.Height)/2));
			}
			base.OnPaint(e);
		}
	}
}
