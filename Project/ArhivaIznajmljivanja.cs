////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using CEBR = System.Int32;
using TAC = System.Boolean;
using TIMESTAMP = System.DateTime;

namespace Project {
    public class ArhivaIznajmljivanja : Iid {
        CEBR id, id_knjiga, id_clan, id_korisnik;
        EIznajmljivanjeVracanje status;
        TAC jeVracena;
        TIMESTAMP datum;

        public CEBR AutoIncrementInt() {
            CEBR broj = 0;
            using (Microsoft.Win32.RegistryKey kljuc = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека", true)) {
                if (kljuc != null) {
                    try {
                        broj = CEBR.Parse(kljuc.GetValue("AIID").ToString()) + 1;
                    } catch (Exception ex) {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }

                    kljuc.SetValue("AIID", (CEBR) broj);
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

        public ArhivaIznajmljivanja(CEBR idKnjige, CEBR idClana, CEBR idKorisnika, EIznajmljivanjeVracanje status, TIMESTAMP vreme) {
            this.id = AutoIncrementInt();
            this.id_knjiga = idKnjige;
            this.id_clan = idClana;
            this.id_korisnik = idKorisnika;
            this.status = status;
            this.datum = vreme;
            this.jeVracena = false;
        }

        public ArhivaIznajmljivanja(CEBR id, CEBR idKnjige, CEBR idClana, CEBR idKorisnika, EIznajmljivanjeVracanje status, TIMESTAMP vreme, TAC vracena) {
            this.id = id;
            this.id_knjiga = idKnjige;
            this.id_clan = idClana;
            this.id_korisnik = idKorisnika;
            this.status = status;
            this.datum = vreme;
            this.jeVracena = vracena;
        }

        public CEBR preuzmiID() {
            return this.id;
        }

        public CEBR preuzmiIDKnjige() {
            return id_knjiga;
        }

        public CEBR preuzmiIDClan() {
            return id_clan;
        }

        public CEBR preuzmiIDKorisnik() {
            return id_korisnik;
        }

        public EIznajmljivanjeVracanje preuzmiStatus() {
            return status;
        }

        public void EvidentirajJeVracena(TAC jeVracena) {
            this.jeVracena = jeVracena;
        }

        public TAC preuzmiJeVracena() {
            return this.jeVracena;
        }

        public TIMESTAMP preuzmiDatum() {
            return datum;
        }
    }
}