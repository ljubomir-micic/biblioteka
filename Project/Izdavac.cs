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
    public class Izdavac : Iid {
        private CEBR id;
        private STR naziv;
        private CEBR pib, mBr, godinaOsnivanja;

        public CEBR AutoIncrementInt() {
            CEBR broj = 0;
            using (Microsoft.Win32.RegistryKey kljuc = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека", true)) {
                if (kljuc != null) {
                    try {
                        broj = CEBR.Parse(kljuc.GetValue("IID").ToString()) + 1;
                    } catch (Exception ex) {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }

                    kljuc.SetValue("IID", (CEBR) broj);
                    kljuc.Close();
                }
            }
            return broj;
        }

        public CEBR AutoIncrementInt_Old() {
            // Bolja solucija jer se na ovaj nacin, inkrementovanjem id-a svakog sledeceg objekta
            // izbacuje mogucnost da dva objekta imaju isti ID
            CEBR broj = 0;
            if (MenadzmentPodataka.izdavaci.Count > 0) broj = MenadzmentPodataka.izdavaci[MenadzmentPodataka.izdavaci.Count - 1].preuzmiID() + 1;
            return broj;
        }

        public CEBR RandomInt() {
        	Random rand = new Random();
        	CEBR a = rand.Next();
        	return Math.Abs(a);
        }

        public Izdavac() {
            this.id = AutoIncrementInt();
        }
        
        public Izdavac(STR naziv) {
        	this.id = AutoIncrementInt();
            this.naziv = naziv;
        }

        public Izdavac(STR naziv, CEBR pib, CEBR maticniBroj, CEBR godinaOsnivanja) {
        	this.id = AutoIncrementInt();
            this.naziv = naziv;
            this.pib = pib;
            this.mBr = maticniBroj;
            this.godinaOsnivanja = godinaOsnivanja;
        }

        public Izdavac(CEBR id, STR naziv, CEBR pib, CEBR maticniBroj, CEBR godinaOsnivanja) {
        	this.id = id;
            this.naziv = naziv;
            this.pib = pib;
            this.mBr = maticniBroj;
            this.godinaOsnivanja = godinaOsnivanja;
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

        public static STR preuzmiNaziv_ID(Izdavac[] izdavaci, CEBR izdavac_id) {
            foreach (var izdavac in izdavaci) if (izdavac.preuzmiID() == izdavac_id) return (izdavac.preuzmiNaziv());
        	return "";
        }

        public void postaviPIB(CEBR pib) {
            this.pib = pib;
        }

        public CEBR preuzmiPIB() {
            return this.pib;
        }

        public void postaviMBR(CEBR mBr) {
            this.mBr = mBr;
        }

        public CEBR preuzmiMBR() {
            return this.mBr;
        }

        public void postaviGodinuOsnivanja(CEBR godina) {
            this.godinaOsnivanja = godina;
        }

        public CEBR preuzmiGodinuOsnivanja() {
            return this.godinaOsnivanja;
        }
    }
}