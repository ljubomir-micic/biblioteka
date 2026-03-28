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
    public class Clan : Iid {
        private CEBR id;
        private STR ime, prezime, jmbg, brojTelefona;
        private CEBR godinaRodjenja;
        private CEBR[] ID_iznajmljeneKnjige;

        public CEBR AutoIncrementInt() {
            CEBR broj = 0;
            using (Microsoft.Win32.RegistryKey kljuc = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека", true)) {
                if (kljuc != null) {
                    try {
                        broj = CEBR.Parse(kljuc.GetValue("CID").ToString()) + 1;
                    } catch (Exception ex) {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }

                    kljuc.SetValue("CID", (CEBR) broj);
                    kljuc.Close();
                }
            }
            return broj;
        }

        public CEBR AutoIncrementInt_Old() {
            // Bolja solucija jer se na ovaj nacin, inkrementovanjem id-a svakog sledeceg objekta
            // izbacuje mogucnost da dva objekta imaju isti ID
            CEBR broj = 0;
            if (MenadzmentPodataka.clanovi.Count > 0) broj = MenadzmentPodataka.clanovi[MenadzmentPodataka.clanovi.Count - 1].preuzmiID() + 1;
            return broj;
        }

        public CEBR RandomInt() {
        	Random rand = new Random();
        	CEBR a = rand.Next();
        	return Math.Abs(a);
        }

        public Clan() {
            this.id = AutoIncrementInt();
            ID_iznajmljeneKnjige = new CEBR[3] {-1, -1, -1};
        }

        public Clan(CEBR id, STR ime, STR prezime, STR jmbg, CEBR godinaRodjenja) {
        	this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.godinaRodjenja = godinaRodjenja;
            ID_iznajmljeneKnjige = new CEBR[3] {-1, -1, -1};
        }

        public Clan(CEBR id, STR ime, STR prezime, STR jmbg, CEBR godinaRodjenja, CEBR[] ID_iznajmljenaKnjiga) {
        	this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.jmbg = jmbg;
            this.godinaRodjenja = godinaRodjenja;
            this.ID_iznajmljeneKnjige = ID_iznajmljenaKnjiga;
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
        
        public void postaviJMBG(STR jmbg) {
            this.jmbg = jmbg;
        }

        public STR preuzmiJMBG() {
            return this.jmbg;
        }
        
        public void postaviBrojTelefona(STR telefon) {
            this.brojTelefona = telefon;
        }

        public STR preuzmiBrojTelefona() {
            return this.brojTelefona;
        }

        public void postaviGodinuRodjenja(CEBR godina) {
            this.godinaRodjenja = godina;
        }

        public CEBR preuzmiGodinuRodjenja() {
            return this.godinaRodjenja;
        }

        public bool imaIznajmljenuKnjigu() {
            return !(
                this.ID_iznajmljeneKnjige[0] == -1 &&
                this.ID_iznajmljeneKnjige[1] == -1 &&
                this.ID_iznajmljeneKnjige[2] == -1
            );
        }

        public CEBR pozicijaSlobodnogIznajmljivanja() {
            for (CEBR i = 0; i < this.ID_iznajmljeneKnjige.Length; i ++) if (this.ID_iznajmljeneKnjige[i] == -1) return i;
            return -1;
        }
        
        public void postaviIznajmljenuKnjigu(CEBR brojKnjige, CEBR idKnjige) {
            this.ID_iznajmljeneKnjige[brojKnjige] = idKnjige;
        }

        public void postaviSlobodnoMesto(CEBR idKnjige) {
            for (CEBR i = 0; i < this.ID_iznajmljeneKnjige.Length; i ++) if (this.ID_iznajmljeneKnjige[i] == idKnjige) this.ID_iznajmljeneKnjige[i] = -1;
        }

        public CEBR[] preuzmiIznajmljeneKnjige() {
            return this.ID_iznajmljeneKnjige;
        }
    }
}