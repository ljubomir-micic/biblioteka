////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System.Reflection;
using System.Windows.Forms;

namespace Project
{
	public partial class AppInfo : Form
	{
		public AppInfo()
		{
			InitializeComponent();
			this.BackColor = Colors.SvetlijaPozadina;
			this.label1.ForeColor = Colors.BojaTeksta;
			this.label3.ForeColor = Colors.BojaTeksta;
			this.label2.BackColor = Colors.AccentColor;
			this.label3.Text = "Верзија " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
		}
	}
}
