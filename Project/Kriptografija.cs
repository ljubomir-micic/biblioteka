////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Text;
using B = System.Byte;
using STR = System.String;

namespace Project {
    public static class Kriptografija {
        public static STR Sifrovanje(STR tekst) {
            B[] data = Encoding.UTF8.GetBytes(tekst);
            tekst = Convert.ToBase64String(data);
            return tekst;
        }

        public static STR Desifrovanje(STR tekst) {
            B[] data = Convert.FromBase64String(tekst);
            tekst = Encoding.UTF8.GetString(data);
            return tekst;
        }
    }
}