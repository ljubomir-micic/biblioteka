////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System.Windows.Forms;
using CEBR = System.Int32;
using TACKA = System.Drawing.Point;

namespace Project {
	namespace Alati
	{
		// BEZ ANIMACIJA
		public static class Transformacije
		{
			public static void PromeniLokacijuZavisnogObjekta<TipGlavnogObjekta, TipZavisnogObjekta>(TipGlavnogObjekta glavniObjekat, TipZavisnogObjekta zavisniObjekat, CEBR offsetX, CEBR offsetY) where TipGlavnogObjekta : Control where TipZavisnogObjekta : Control {
				zavisniObjekat.Location = new TACKA(glavniObjekat.Location.X + offsetX, glavniObjekat.Location.Y + offsetY);
			}
		}
	}
}