////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Windows.Forms;
using CEBR = System.Int32;
using STR = System.String;

namespace Project
{
	public partial class PronadjiKnjiguPoID : Form
	{
		CEBR id = -1;
		Timer tajmer;
		
		public CEBR ID {
			get {
				return id;
			} set {
				id = value;
			}
		}
		
		protected override CreateParams CreateParams {
			get {
				CreateParams createParams = base.CreateParams;
				createParams.Style = 0x00800000;
				createParams.ClassStyle = 0x00020000; // https://learn.microsoft.com/sr-latn-rs/windows/win32/winmsg/window-class-styles?redirectedfrom=MSDN#CS_DROPSHADOW
				return createParams;
			}
		}

		protected CEBR IntSiguranTekst(STR rec) {
			STR novaRec = "";
			foreach (var param in rec) if (
				param=='0' ||
				param=='1' ||
				param=='2' ||
				param=='3' ||
				param=='4' ||
				param=='5' ||
				param=='6' ||
				param=='7' ||
				param=='8' ||
				param=='9'
			) novaRec += param;
			return CEBR.Parse(novaRec);
		}
		
		public PronadjiKnjiguPoID()
		{
			InitializeComponent();
			
			this.KeyPreview = true;
			
			this.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
			this.panel1.BackColor = Colors.AccentColor;
		}
		
		void PronadjiKnjiguPoIDKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape) this.Close();
		}

		protected void TekstIzmenjen(object sender, EventArgs eventArgs) {
			if (tajmer != null) {
				tajmer.Stop();
				tajmer.Dispose();
			}
			tajmer = new Timer();
			tajmer.Interval = 850;
			tajmer.Tick += delegate {
				tajmer.Stop();
				tajmer.Dispose();
				this.ID = this.IntSiguranTekst(textBox.Text);
				this.Close();
			};
			tajmer.Start();
		}
	}
}