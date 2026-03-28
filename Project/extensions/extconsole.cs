////////////////////////////////////////////////////////////
//
//    Библиотека: Extensions
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;

namespace Extensions {
	public static class Console {
        public static void WriteHeader() {
			Console.Clear();
            Console.WriteLine("Copyright © 2022-2023 Љубомир Мићић. Сва права задржана.");
            Console.WriteLine("" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\n---------------------------");
        }
    }
}
