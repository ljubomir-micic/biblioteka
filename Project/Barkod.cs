////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System.Drawing;
using BarcodeLib;
using STR = System.String;

namespace Project {
	namespace Alati
	{
		public static class Barkod
		{
			public static Image GenerisiBarkod(STR input)
			{
				Barcode a = new Barcode() {
					IncludeLabel = true,
					Alignment = AlignmentPositions.CENTER,
					Width = 300,
					Height = 100,
					RotateFlipType = RotateFlipType.RotateNoneFlipNone,
					BackColor = Color.White,
					ForeColor = Colors.AccentColor
				};
				
				return a.Encode(TYPE.CODE128B, input);
			}
			
			public static void SacuvajBarkod(STR input)
			{
				Image image = GenerisiBarkod(input);
				System.Windows.Forms.SaveFileDialog formaZaCuvanje = new System.Windows.Forms.SaveFileDialog() {
					InitialDirectory = @"C:\",
					Title = "Претрага локације за чување",
					DefaultExt = "data",
					Filter = "PNG слика (*.png)|*.png|Све датотеке (*.*)|*.*"
				};
				
				if (formaZaCuvanje.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
					image.Save(formaZaCuvanje.FileName);
				}

				formaZaCuvanje.Dispose();
			}
			
			public static void SacuvajBarkod(STR input, STR lokacijaCuvanja)
			{
				Image image = GenerisiBarkod(input);
				image.Save(lokacijaCuvanja);
			}

			public static void OdstampajBarkod(STR input)
			{
				// System.Drawing.Printing.PrintDocument dokument = new System.Drawing.Printing.PrintDocument();
				// dokument.PrintPage += PrintPage;
				// dokument.Print();
			}

			// private void PrintPage(object o, PrintPageEventArgs e)
			// {
			// 	System.Drawing.Image img = System.Drawing.Image.FromFile("D:\\Foto.jpg");
			// 	Point loc = new Point(100, 100);
			// 	e.Graphics.DrawImage(img, loc);     
			// }
		}
	}
}