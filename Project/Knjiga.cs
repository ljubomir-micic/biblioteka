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
using TAC = System.Boolean;

namespace Project {
    public class Knjiga : Iid {
        private CEBR id;
        private STR naziv;
        private CEBR autorID, izdavacID, brojStrana, godinaIzdanja;
        private STR UDK;
        private TAC JeOmiljena, JeIznajmljena;

        // TEST: Ukoliko se obrise clan koji je poslednji dodat u biblioteci koriscenjem AutoIncrementInt() funkcije, a zatim se doda - sve nove transakcije sa prethodno obrisanim clanom ce se dodati novom
        // TEST: Ucitati podatke iz Registri baze
        public CEBR AutoIncrementInt() {
            CEBR broj = 0;
            using (Microsoft.Win32.RegistryKey kljuc = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека", true)) {
                if (kljuc != null) {
                    try {
                        broj = CEBR.Parse(kljuc.GetValue("KID").ToString()) + 1;
                    } catch (Exception ex) {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }

                    kljuc.SetValue("KID", (CEBR) broj);
                    kljuc.Close();
                }
            }
            return broj;
        }

        public CEBR AutoIncrementInt_Old() {
            // Bolja solucija jer se na ovaj nacin, inkrementovanjem id-a svakog sledeceg objekta
            // izbacuje mogucnost da dva objekta imaju isti ID
            CEBR broj = 0;
            if (MenadzmentPodataka.knjige.Count > 0) broj = MenadzmentPodataka.knjige[MenadzmentPodataka.knjige.Count - 1].preuzmiID() + 1;
            return broj;
        }

        public CEBR RandomInt() {
        	Random rand = new Random();
        	CEBR a = rand.Next();
        	return Math.Abs(a);
        }
        
        public Knjiga() {
            this.id = AutoIncrementInt();
        }

        public Knjiga(STR naziv, CEBR autorID, CEBR izdavacID, CEBR brojStrana, CEBR godinaIzdanja, STR zanr) {
        	this.id = AutoIncrementInt();
            this.naziv = naziv;
            this.autorID = autorID;
            this.izdavacID = izdavacID;
            this.brojStrana = brojStrana;
            this.godinaIzdanja = godinaIzdanja;
            this.UDK = zanr;
            this.JeOmiljena = false;
            this.JeIznajmljena = false;
        }
        
        public Knjiga(STR naziv, CEBR autorID, CEBR izdavacID, CEBR brojStrana, CEBR godinaIzdanja, STR zanr, TAC _jeOmiljena,  TAC _jeIznajmljena) {
        	this.id = AutoIncrementInt();
            this.naziv = naziv;
            this.autorID = autorID;
            this.izdavacID = izdavacID;
            this.brojStrana = brojStrana;
            this.godinaIzdanja = godinaIzdanja;
            this.UDK = zanr;
            this.JeOmiljena = _jeOmiljena;
            this.JeIznajmljena = _jeIznajmljena;
        }
        
        // Konstruktor kad program ucitava iz fajla
        public Knjiga(CEBR id, STR naziv, CEBR autorID, CEBR izdavacID, CEBR brojStrana, CEBR godinaIzdanja, STR zanr) {
        	this.id = id;
            this.naziv = naziv;
            this.autorID = autorID;
            this.izdavacID = izdavacID;
            this.brojStrana = brojStrana;
            this.godinaIzdanja = godinaIzdanja;
            this.UDK = zanr;
            this.JeOmiljena = false;
            this.JeIznajmljena = false;
        }
        
        public Knjiga(CEBR id, STR naziv, CEBR autorID, CEBR izdavacID, CEBR brojStrana, CEBR godinaIzdanja, STR zanr, TAC _jeOmiljena, TAC _jeIznajmljena) {
        	this.id = id;
            this.naziv = naziv;
            this.autorID = autorID;
            this.izdavacID = izdavacID;
            this.brojStrana = brojStrana;
            this.godinaIzdanja = godinaIzdanja;
            this.UDK = zanr;
            this.JeOmiljena = _jeOmiljena;
            this.JeIznajmljena = _jeIznajmljena;
        }

        public CEBR preuzmiID() {
            return this.id;
        }

        public void postaviNaziv(STR naziv) {
            this.naziv = naziv;
        }

        public STR preuzmiNaziv() {
            return this.naziv;
        }

        public void postaviIDAutora(CEBR autor) {
            this.autorID = autor;
        }

        public CEBR preuzmiIDAutora() {
            return this.autorID;
        }

        public void postaviIDIzdavaca(CEBR izdavacID) {
            this.izdavacID = izdavacID;
        }

        public CEBR preuzmiIDIzdavaca() {
            return this.izdavacID;
        }

        public void postaviBrojStrana(CEBR brS) {
            this.brojStrana = brS;
        }

        public CEBR preuzmiBrojStrana() {
            return this.brojStrana;
        }

        public void postaviGodinuIzdavanja(CEBR godina) {
            this.godinaIzdanja = godina;
        }

        public CEBR preuzmiGodinuIzdavanja() {
            return this.godinaIzdanja;
        }

        public void postaviZanr(STR zanr) {
            this.UDK = zanr;
        }

        public STR preuzmiUDK() {
        	return this.UDK;
        }
        
        public STR preuzmiZanr() {
        	return Project.UDK.UDK_Lista[this.UDK];
        }

        public STR preuzmiRelativniZanr() {
            // System.Diagnostics.Debug.WriteLine(this.UDK);
            if (Podesavanja.koriscenjeUDK != Project.UDK.UDK_Koriscenje.Nista) return preuzmiZanr();
            try {
            	STR[] zanr = Konverzija.GenerisanjeEZanrKnjigaPrekoUDK(this.UDK).ToString().Split('_');
	            STR a = "";
	            for (CEBR i = 0; i < zanr.Length; i ++) a += zanr[i] + " ";
	            return a;
            } catch {
            	return preuzmiZanr();
            }
        }

        public void postaviStatusOmiljeno(TAC vrednost) {
            this.JeOmiljena = vrednost;
        }

        public TAC preuzmiStatusOmiljeno() {
            return this.JeOmiljena;
        }

        public void postaviStatusIznajmljena(TAC vrednost) {
            this.JeIznajmljena = vrednost;
        }

        public TAC preuzmiStatusIznajmljena() {
            return this.JeIznajmljena;
        }
    }
}