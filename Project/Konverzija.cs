////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Linq;
using CEBR = System.Int32;
using DECD = System.Double;
using STR = System.String;

namespace Project
{
	public static class Konverzija {
		public static DECD RadijaniUStepene(DECD rad) {
			return (rad * 180) / Math.PI;
		}

		public static DECD StepeniURadijane(DECD deg) {
			return (deg * Math.PI) / 180;
		}

        public static EZanrKnjiga Generisanje_EZanraKnjige_PrekoStringa(STR zanr) {
            foreach (var tip in Enum.GetValues(typeof(EZanrKnjiga)).Cast<EZanrKnjiga>().ToArray()) if ((EZanrKnjiga) CEBR.Parse(zanr) == tip) return tip;
            throw new Exception();
        }

        public static EZanrKnjiga GenerisanjeEZanrKnjigaPrekoUDK(STR UDK) {
			try {
				STR[] podUDK = UDK.Split('-');
				// // System.Diagnostics.Debug.WriteLine(podUDK[0] + "\n" + podUDK[1]);
				return (EZanrKnjiga) Enum.Parse(typeof(EZanrKnjiga), podUDK[1]);
			} catch (Exception ex) {
				throw ex;
			}
        }

        public static STR UDKKljucPrekoOsnovnogZanra(EZanrKnjiga eZanr) {
            return "821.163.41-" + (CEBR) eZanr;
        }
	}
}