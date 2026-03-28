////////////////////////////////////////////////////////////
//
//    Библиотека: Extensions
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;

namespace Extensions {
    public static class WinApp {
        public static void WriteHeader() {
            System.Diagnostics.Debug.WriteLine("Copyright © 2022-2023 Љубомир Мићић. Сва права задржана.");
            System.Diagnostics.Debug.WriteLine("" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + "\n---------------------------");
        }
    }
}