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
    public class Korisnik : Iid {
        private CEBR id;
        private STR ime, prezime;
        private STR korisnickoIme, lozinka;
        private CEBR godinaRodjenja;

        public CEBR AutoIncrementInt() {
            // Bolja solucija jer se na ovaj nacin, inkrementovanjem id-a svakog sledeceg objekta
            // izbacuje mogucnost da dva objekta imaju isti ID
            CEBR broj = 0;
            if (MenadzmentPodataka.korisnici.Count > 0) broj = MenadzmentPodataka.korisnici[MenadzmentPodataka.korisnici.Count - 1].preuzmiID() + 1;
            return broj;
        }

        public CEBR RandomInt() {
        	Random rand = new Random();
        	CEBR a = rand.Next();
        	return Math.Abs(a);
        }

        public Korisnik(STR ime, STR prezime, STR korisnickoIme, STR lozinka, CEBR godinaRodjenja) {
        	this.id = AutoIncrementInt();
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.godinaRodjenja = godinaRodjenja;
        }

        public Korisnik(CEBR id, STR ime, STR prezime, STR korisnickoIme, STR lozinka, CEBR godinaRodjenja) {
        	this.id = id;
            this.ime = ime;
            this.prezime = prezime;
            this.korisnickoIme = korisnickoIme;
            this.lozinka = lozinka;
            this.godinaRodjenja = godinaRodjenja;
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

        public void postaviGodinuRodjenja(CEBR godina) {
            this.godinaRodjenja = godina;
        }

        public CEBR preuzmiGodinuRodjenja() {
            return this.godinaRodjenja;
        }
        
        public STR preuzmiKorisnickoIme() {
        	return this.korisnickoIme;
        }
        
        public STR preuzmiLozinku() {
        	return this.lozinka;
        }
        
        public void postaviLozinku(STR novaLozinka) {
        	this.lozinka = novaLozinka;
        }
    }
}