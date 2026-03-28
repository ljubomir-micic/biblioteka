////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Project
{
	public partial class DodajKorisnika : Form, IDodavanje
	{
		private Korisnik korisnik;
		private System.Windows.Forms.PictureBox pictureBox1;
		private Project.AccentPolje accentPolje1, accentPolje2, accentPolje3, accentPolje4, accentPolje5;
		private System.Windows.Forms.Label label1;
		private bool jeDodat;

        public bool JeDodat { 
			get {
				return jeDodat;
			} set{
				jeDodat = value;
				KorigujLabelu();
			}
		}

		private System.Collections.Generic.List<Korisnik> Korisnici {
			get {
				return MenadzmentPodataka.korisnici;
			} set {
				MenadzmentPodataka.korisnici = value;
			}
		}

		public DodajKorisnika()
		{
			pictureBox1 = new System.Windows.Forms.PictureBox();
			accentPolje1 = new Project.AccentPolje();
			accentPolje2 = new Project.AccentPolje();
			accentPolje3 = new Project.AccentPolje();
			accentPolje4 = new Project.AccentPolje();
			accentPolje5 = new Project.AccentPolje();
			label1 = new System.Windows.Forms.Label();
			jeDodat = false;
			
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NalogIzmena));
			System.ComponentModel.ComponentResourceManager resources1 = new System.ComponentModel.ComponentResourceManager(typeof(DodajKorisnika));
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(75, 75);
			this.pictureBox1.Location = new System.Drawing.Point(28, 23);
			this.pictureBox1.BackgroundImage = (System.Drawing.Image) (resources.GetObject("pictureBox1.BackgroundImage"));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			{
				GraphicsPath graphicsPath = new GraphicsPath();
				graphicsPath.AddEllipse(new Rectangle(0, 0, this.pictureBox1.Width, this.pictureBox1.Height));
				graphicsPath.CloseFigure();
				this.pictureBox1.Region = new Region(graphicsPath);
			}
			
			this.accentPolje1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.accentPolje1.BackColor = System.Drawing.Color.White;
			this.accentPolje1.Hint = "Име";
			this.accentPolje1.JePoljeZaPretragu = false;
			this.accentPolje1.JeSelektovan = false;
			this.accentPolje1.JeSifrovan = false;
			this.accentPolje1.Location = new System.Drawing.Point(124, 24);
			this.accentPolje1.MaksimalanBrojKaraktera = 32767;
			this.accentPolje1.Name = "accentPolje1";
			this.accentPolje1.Size = new System.Drawing.Size(179, 32);
			this.accentPolje1.TabIndex = 0;
			this.accentPolje1.TekstIzmenjen += new System.EventHandler(this.AccentPoljeTekstIzmenjen);
			
			this.accentPolje2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.accentPolje2.BackColor = System.Drawing.Color.White;
			this.accentPolje2.Hint = "Презиме";
			this.accentPolje2.JePoljeZaPretragu = false;
			this.accentPolje2.JeSelektovan = false;
			this.accentPolje2.JeSifrovan = false;
			this.accentPolje2.Location = new System.Drawing.Point(124, 69);
			this.accentPolje2.MaksimalanBrojKaraktera = 32767;
			this.accentPolje2.Name = "accentPolje2";
			this.accentPolje2.Size = new System.Drawing.Size(179, 32);
			this.accentPolje2.TabIndex = 1;
			this.accentPolje2.TekstIzmenjen += new System.EventHandler(this.AccentPoljeTekstIzmenjen);
			
			this.accentPolje3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.accentPolje3.BackColor = System.Drawing.Color.White;
			this.accentPolje3.Hint = "Корисничко име";
			this.accentPolje3.JePoljeZaPretragu = false;
			this.accentPolje3.JeSelektovan = false;
			this.accentPolje3.JeSifrovan = false;
			this.accentPolje3.Location = new System.Drawing.Point(23, 114);
			this.accentPolje3.MaksimalanBrojKaraktera = 32767;
			this.accentPolje3.Name = "accentPolje3";
			this.accentPolje3.Size = new System.Drawing.Size(280, 32);
			this.accentPolje3.TabIndex = 2;
			this.accentPolje3.TekstIzmenjen += new System.EventHandler(this.AccentPoljeTekstIzmenjen);
			
			this.accentPolje4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.accentPolje4.BackColor = System.Drawing.Color.White;
			this.accentPolje4.Hint = "Лозинка";
			this.accentPolje4.JePoljeZaPretragu = false;
			this.accentPolje4.JeSelektovan = false;
			this.accentPolje4.JeSifrovan = false;
			this.accentPolje4.Location = new System.Drawing.Point(23, 159);
			this.accentPolje4.MaksimalanBrojKaraktera = 32767;
			this.accentPolje4.Name = "accentPolje4";
			this.accentPolje4.Size = new System.Drawing.Size(145, 32);
			this.accentPolje4.TabIndex = 3;
			this.accentPolje4.TekstIzmenjen += new System.EventHandler(this.AccentPoljeTekstIzmenjen);
			
			this.accentPolje5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.accentPolje5.BackColor = System.Drawing.Color.White;
			this.accentPolje5.Hint = "Година рођења";
			this.accentPolje5.JePoljeZaPretragu = false;
			this.accentPolje5.JeSelektovan = false;
			this.accentPolje5.JeSifrovan = false;
			this.accentPolje5.Location = new System.Drawing.Point(175, 159);
			this.accentPolje5.MaksimalanBrojKaraktera = 4;
			this.accentPolje5.Name = "accentPolje5";
			this.accentPolje5.Size = new System.Drawing.Size(127, 32);
			this.accentPolje5.TabIndex = 4;
			this.accentPolje5.TekstIzmenjen += new System.EventHandler(this.AccentPoljeTekstIzmenjen);
			
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(4, 193);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(319, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "Попуните сва поља";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

			this.ResumeLayout(false);
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = Colors.SvetlijaPozadina;
			this.ClientSize = new System.Drawing.Size(327, 219);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.accentPolje1);
			this.Controls.Add(this.accentPolje2);
			this.Controls.Add(this.accentPolje3);
			this.Controls.Add(this.accentPolje4);
			this.Controls.Add(this.accentPolje5);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources1.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DodajKorisnika";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Библиотека: Додавање радника";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NaPritisnutTaster);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

			foreach (Control control in this.Controls) {
				Colors.BojenjeBackColor<AccentPolje>(control, Colors.SvetlijaPozadina);
				Colors.BojenjeForeColor<AccentPolje>(control, Colors.BojaTeksta);
			}
			this.JeDodat = false;
		}

		bool IspunjavaUsloveZaDodavanje() {
			int greska = -1;
			int.TryParse(accentPolje5.Tekst, out greska);
			return (
				!String.IsNullOrEmpty(accentPolje1.Tekst) &&
				!String.IsNullOrEmpty(accentPolje2.Tekst) &&
				!String.IsNullOrEmpty(accentPolje3.Tekst) &&
				!String.IsNullOrEmpty(accentPolje4.Tekst) &&
				!String.IsNullOrEmpty(accentPolje5.Tekst) &&
				greska != 0
			);
		}

		void KorigujLabelu() {
			label1.ForeColor = JeDodat ? Colors.BookColor2 : Colors.AccentColor;
			label1.Text = JeDodat ? "Затворите прозор како бисте сачували податке" : (IspunjavaUsloveZaDodavanje() ? "Унесите податке" : "Попуните сва поља");
		}

		void AccentPoljeTekstIzmenjen(object sender, EventArgs e) {
			JeDodat = IspunjavaUsloveZaDodavanje();
		}

		void NaPritisnutTaster(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.F5 || e.KeyCode == Keys.Escape) {
				this.accentPolje1.Clear();
				this.accentPolje2.Clear();
				this.accentPolje3.Clear();
				this.accentPolje4.Clear();
				this.accentPolje5.Clear();
				this.JeDodat = IspunjavaUsloveZaDodavanje();

				if (e.KeyCode == Keys.Escape) this.Close();
			}
		}

        protected override void OnClosing(CancelEventArgs e)
        {
			if (this.JeDodat) {
				korisnik = new Korisnik(
					accentPolje1.Tekst,
					accentPolje2.Tekst,
					accentPolje3.Tekst,
					accentPolje4.Tekst,
					int.Parse(accentPolje5.Tekst)
				);
				
				Korisnici.Add(this.korisnik);
				MenadzmentPodataka.korisnikPodaciCuvanje(Korisnici, "korisnici");
			}

            base.OnClosing(e);
        }
    }
}
