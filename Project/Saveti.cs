////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Reflection;
using System.Windows.Forms;

namespace Project
{
	public partial class Saveti : Form
	{
		protected override CreateParams CreateParams {
			get {
				CreateParams createParams = base.CreateParams;
				createParams.Style = 0x00800000;
				createParams.ClassStyle = 0x00020000; // https://learn.microsoft.com/sr-latn-rs/windows/win32/winmsg/window-class-styles?redirectedfrom=MSDN#CS_DROPSHADOW
				return createParams;
			}
		}
		
		public Saveti()
		{
			InitializeComponent();
			label5.Text = "Верзија: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
			this.BackColor = Colors.SvetlijaPozadina;
			foreach (Control control in this.Controls) {
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentDugme>(control, Colors.AccentColor);
			}
			Podesavanja.podesavanja["PL"] = false;
			using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека", true)) {
				key.SetValue("PL", Podesavanja.podesavanja["PL"]);
				key.Close();
			}
		}
		
		void AccentDugme1Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
