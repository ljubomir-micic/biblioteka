////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using CEBR = System.Int32;
using INDEKS = System.Int32;
using STR = System.String;
using VELICINA = System.Drawing.Size;
using VELICINAF = System.Drawing.SizeF;
using PRAVOUGAONIK = System.Drawing.RectangleF;
using PUTANJA = System.Drawing.Drawing2D.GraphicsPath;
using TACKA = System.Drawing.PointF;
using TACKA0 = System.Drawing.Point;
using SIO = System.Tuple<string, string>;

namespace Project
{
	[DefaultEvent("OpcijaSelektovana")]
	public class AccentKrugOpcija : Control
	{
        private SIO[] opcije;
        private INDEKS naIndeks;
        private CEBR velicina;

        public SIO[] Opcije {
            get {
                return opcije;
            } set {
                opcije = value;
            }
        }

		public event EventHandler OpcijaSelektovana = delegate { };

		public AccentKrugOpcija()
        {
            opcije = new SIO[0];
            naIndeks = -1;
            velicina = 250;
            this.SuspendLayout();
            this.MinimumSize = new VELICINA(velicina, velicina);
            this.Size = new VELICINA(velicina, velicina);
            this.Font = new Font("Segoe UI", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResumeLayout();

            this.MouseLeave += new System.EventHandler(AccentKrugOpcija_MisJeIzasao);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(AccentKrugOpcija_MisSePomera);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(AccentKrugOpcija_TasterMisaDole);
            
            this.Visible = false;
        }
        
        public INDEKS preuzmiNaIndex() {
        	return naIndeks;
        }
        
        public void DodajOpciju(STR opcija, STR simbol)
        {
            Array.Resize(ref opcije, Opcije.Length + 1);
            Opcije[Opcije.Length - 1] = Tuple.Create(opcija, simbol);
        }

		protected void AccentKrugOpcija_MisJeIzasao(object sender, EventArgs e){
            // Vrati indeks na pocetnu vrednost
            this.naIndeks = -1;
            this.Invalidate();
        }

        // DONE: Metod ne izracunava nista dok je mis spusten
		public void AccentKrugOpcija_MisSePomera(object sender, MouseEventArgs e) {
        	TACKA centar = new TACKA(velicina / 2, velicina / 2);
        	TACKA pozicijaKursora = (e.Location);
            
            // Izracunaj indeks opcije na kojoj se nalazi mis
            CEBR ukupno = this.Opcije.Length;
        	float maksimalniUgao = 360.0f / (float) ukupno;
            double ugaoURadijanima = Math.Atan2(pozicijaKursora.Y - centar.Y, pozicijaKursora.X - centar.X);
            // System.Diagnostics.Debug.WriteLine(ugaoURadijanima);
            double ugao = ((Konverzija.RadijaniUStepene(ugaoURadijanima) - 360) * -1) % 360;
            // System.Diagnostics.Debug.WriteLine(ugao);
            CEBR index = (CEBR) ((ugao) / maksimalniUgao);
            
            if (index >= 0 && index < opcije.Length)
            {
            	bool seRazlikuje = this.naIndeks != index;
                this.naIndeks = index;
                // System.Diagnostics.Debug.WriteLine(naIndeks);
                if (seRazlikuje) this.Invalidate();
            }
        }

		protected void AccentKrugOpcija_TasterMisaDole(object sender, MouseEventArgs e) {
            // Ako je mis pritisnut pokrenuti opciju
            if (naIndeks >= 0 && naIndeks < opcije.Length)
            {
				OpcijaSelektovana.Invoke(this, new EventArgs());
            }
        }

        // OPREZ: Opcije se crtaju od X-ose; u smeru kazaljke na satu => Uskladiti OpcijaSelektovana event
        public PUTANJA DeoKrofne(CEBR deo, CEBR ukupno) {
        	TACKA centar = new TACKA(this.Width / 2, this.Height / 2);
        	CEBR poluprecnik = (CEBR) (Math.Min(this.Width, this.Height) / 2.02);
        	float maksimalniUgao = 360 / (float) ukupno;
        	float pocetniUgao = deo * maksimalniUgao;
            PUTANJA path = new PUTANJA();
        	path.StartFigure();
        	path.AddPie(centar.X - poluprecnik, centar.Y - poluprecnik, poluprecnik * 2, poluprecnik * 2, pocetniUgao, maksimalniUgao);
        	path.AddPie(centar.X - poluprecnik / 2, centar.Y - poluprecnik / 2, poluprecnik, poluprecnik, pocetniUgao, maksimalniUgao);
            path.SetMarkers();
            path.CloseFigure();
        	return path;
        }

		protected override void OnPaint(PaintEventArgs e) {
        	TACKA centar = new TACKA(this.Width / 2, this.Height / 2);
        	e.Graphics.Clear(Colors.BojaTeksta);
        	e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            CEBR poluprecnik = (CEBR) (Math.Min(this.Width, this.Height) / 2.02);
        	double maxUgao = 360 / (float) Opcije.Length;

            for (CEBR i = 0; i < opcije.Length; i++) {
                STR simbol = opcije[i].Item2;
                VELICINAF velicinaStringa = e.Graphics.MeasureString(simbol, this.Font);
        		e.Graphics.FillPath(new SolidBrush((naIndeks == (Opcije.Length - 1 - i)) ? Colors.AccentColor : this.Parent.BackColor), DeoKrofne(i, opcije.Length));
            	e.Graphics.DrawPath(new Pen(Colors.BojaTeksta), DeoKrofne(i, opcije.Length));
                TACKA0 tacka = new TACKA0((CEBR) (centar.X - velicinaStringa.Width / 2 + (poluprecnik * 3 / 4) * Math.Cos(Konverzija.StepeniURadijane((i + 0.5) * maxUgao))), (CEBR) (centar.Y - velicinaStringa.Height / 2 + (poluprecnik * 3 / 4) * Math.Sin(Konverzija.StepeniURadijane((i + 0.5) * maxUgao))));
//                e.Graphics.DrawString(simbol, this.Font, new SolidBrush(Colors.BojaTeksta), tacka);
				TextRenderer.DrawText(e.Graphics, simbol, this.Font, tacka, Colors.BojaTeksta);
			}
            
            PUTANJA a = new PUTANJA();
            a.AddEllipse(new PRAVOUGAONIK(0, 0, this.Width, this.Height));
            a.AddEllipse(new PRAVOUGAONIK(this.Width / 4, this.Height / 4, this.Width / 2 - 1, this.Height / 2 - 1));
            a.SetMarkers();
            a.CloseFigure();
            this.Region = new Region(a);
			base.OnPaint(e);
        }
	}
}