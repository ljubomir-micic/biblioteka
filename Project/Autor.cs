////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using CEBR = System.Int32;
using STR = System.String;

namespace Project {
    public class Autor : Iid {
        private CEBR id;
        private STR ime, prezime;
        private CEBR godinaRodjenja, godinaSmrti;

        public CEBR AutoIncrementInt() {
            CEBR broj = 0;
            using (Microsoft.Win32.RegistryKey kljuc = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека", true)) {
                if (kljuc != null) {
                    try {
                        broj = CEBR.Parse(kljuc.GetValue("AID").ToString()) + 1;
                    } catch (Exception ex) {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }

                    kljuc.SetValue("AID", (CEBR) broj);
                    kljuc.Close();
                }
            }
            return broj;
        }

        public CEBR AutoIncrementInt_Old() {
            // Bolja solucija jer se na ovaj nacin, inkrementovanjem id-a svakog sledeceg objekta
            // izbacuje mogucnost da dva objekta imaju isti ID
            CEBR broj = 0;
            if (MenadzmentPodataka.arhiva.Count > 0) broj = MenadzmentPodataka.arhiva[MenadzmentPodataka.arhiva.Count - 1].preuzmiID() + 1;
            return broj;
        }

        public CEBR RandomInt() {
        	Random rand = new Random();
        	CEBR a = rand.Next();
        	return Math.Abs(a);
        }

        public Autor() {
            this.id = AutoIncrementInt();
        }

        public Autor(STR ime, STR prezime, CEBR godinaRodjenja, CEBR godinaSmrti) {
        	this.id = AutoIncrementInt();
            this.ime = ime;
            this.prezime = prezime;
            this.godinaRodjenja = godinaRodjenja;
            this.godinaSmrti = godinaSmrti;
        }

        public Autor(STR ime, STR prezime, CEBR godinaRodjenja) {
        	this.id = AutoIncrementInt();
            this.ime = ime;
            this.prezime = prezime;
            this.godinaRodjenja = godinaRodjenja;
        }

        public Autor(CEBR id, STR ime, STR prezime, CEBR godinaRodjenja) {
        	this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.godinaRodjenja = godinaRodjenja;
        }
        
        public Autor(CEBR id, STR ime, STR prezime, CEBR godinaRodjenja, CEBR godinaSmrti) {
        	this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.godinaRodjenja = godinaRodjenja;
            this.godinaSmrti = godinaSmrti;
        }

        public CEBR preuzmiID() {
            return this.id;
        }

        public void postaviIme(STR ime) {
            this.ime = ime;
        }

        public STR preuzmiIme() {
            return this.ime;
        }

        public void postaviPrezime(STR prezime) {
            this.prezime = prezime;
        }

        public STR preuzmiPrezime() {
            return this.prezime;
        }

        public STR preuzmiImePrezime() {
            return ime + " " + prezime;
        }
        
        public static STR preuzmiImePrezime_ID(Autor[] autori, CEBR autor_id) {
        	foreach (var autor in autori) if (autor.preuzmiID() == autor_id) return (autor.preuzmiIme() + " " + autor.preuzmiPrezime());
        	return "";
        }

        public void postaviGodinuRodjenja(CEBR godina) {
            this.godinaRodjenja = godina;
        }

        public CEBR preuzmiGodinuRodjenja() {
            return this.godinaRodjenja;
        }

        public void postaviGodinuSmrti(CEBR godina) {
            this.godinaSmrti = godina;
        }

        public CEBR preuzmiGodinuSmrti() {
            if (this.godinaSmrti == 0) {
                return 0;
            }
            return this.godinaSmrti;
        }
    }
}