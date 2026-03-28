////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using STR = System.String;
using CEBR = System.Int32;

namespace Project
{
	[DefaultEvent("TekstIzmenjen")]
	public partial class AccentPolje : UserControl
	{
		STR hint = "", text = "";
		CEBR maksimalanBrojKaraktera = 32767;
		bool jeSelektovan = false;
		bool jeSifrovan = false;
		bool jePoljeZaPretragu = false;
		public event EventHandler TekstIzmenjen = delegate { };
		
		public override Color BackColor {
			get { return base.BackColor; }
			set {
				base.BackColor = value;
				textBox1.BackColor = value;
			}
		}
		
		public override Color ForeColor {
			get { return base.ForeColor; }
			set {
				base.ForeColor = value;
				textBox1.ForeColor = value;
			}
		}
		
		[Category("Appearance")]
		public CEBR MaksimalanBrojKaraktera {
			get { return maksimalanBrojKaraktera; }
			set {
				maksimalanBrojKaraktera = value;
				this.textBox1.MaxLength = value != 0 ? value : 32767;
			}
		}
		
		[Category("Appearance")]
		public bool JeSifrovan {
			get { return jeSifrovan; }
			set {
				jeSifrovan = value;
				this.textBox1.UseSystemPasswordChar = value;
			}
		}
		
		public override STR Text {
			get { return this.textBox1.Text; }
			set { this.textBox1.Text = value; }
		}
		
		[Category("Appearance")]
		public bool JeSelektovan {
			get { return jeSelektovan; }
			set {
				jeSelektovan = value;
				Invalidate();
			}
		}
		
		[Category("Appearance")]
		public bool JePoljeZaPretragu {
			get { return jePoljeZaPretragu; }
			set { jePoljeZaPretragu = value; }
		}
		
		[Category("Appearance")]
		public STR Hint {
			get { return hint; }
			set {
				hint = value;
				label1.Text = value;
			}
		}

		[DefaultValue(""), Category("Appearance")]
		public STR Tekst {
			get { return text; }
			set {
				text = value;
			}
		}
		
		public AccentPolje()
		{
			InitializeComponent();
		}
		
		public void Clear() {
			this.textBox1.Clear();
		}
		
		protected override void OnEnter(EventArgs e)
		{
			base.OnEnter(e);
			JeSelektovan = true;
		}
		
		protected override void OnLeave(EventArgs e)
		{
			base.OnLeave(e);
			JeSelektovan = false;
		}
		
		protected override void OnSizeChanged(EventArgs e)
		{
			base.OnSizeChanged(e);
			this.Size = new Size(Size.Width, 32);
		}
		
		protected override void OnPaint(PaintEventArgs e)
		{
//			e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			e.Graphics.DrawPath(new Pen(JeSelektovan ? Colors.AccentColor : Color.FromArgb(89, 89, 89)), Oblik.GlavniOblik(this.Size));
			label1.ForeColor = JeSelektovan ? Colors.AccentColor : Color.FromArgb(89, 89, 89);
			base.OnPaint(e);
		}

		protected void TextChaged(object sender, EventArgs e) {
			this.Tekst = textBox1.Text;
			TekstIzmenjen(this, new EventArgs());
		}
	}
}