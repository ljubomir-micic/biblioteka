////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using Project.Alati;
using CEBR = System.Int32;
using STR = System.String;
using TAC = System.Boolean;

namespace Project
{
	// DONE: Dodati opciju za upravljanje nalozima korisnika
	public partial class Podesavanja : Form
	{
		private TAC jeOdjavljen;
		public static Korisnik korisnik;
		public static Dictionary<STR, TAC> podesavanja = new Dictionary<STR, TAC> {
			{ "KST", true },
			{ "TamnaTema", false },
			{ "CPL", true },
			{ "PL", true }
		};
		public static Form1.SortiranjeKnjiga sortiranjeKnjiga = Form1.SortiranjeKnjiga.Датум_додавања;
		public static UDK.UDK_Koriscenje koriscenjeUDK = UDK.UDK_Koriscenje.Nista;

		public static ETema Tema {
			get {
				if (podesavanja["KST"]) {
					return (((STR) Registry.GetValue(
						@"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Themes",
						"CurrentTheme",
						"dark")
					).Split('\\').Last().Split('.').First().ToString()) == "dark" ? ETema.Tamna : ETema.Svetla;
				} else {
					return podesavanja["TamnaTema"] ? ETema.Tamna : ETema.Svetla;
				}
			}
		}
		
		public TAC JeOdjavljen {
			get {
				return jeOdjavljen;
			} set {
				jeOdjavljen = value;
			}
		}
		
		public Podesavanja()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Podesavanja));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.temaUI2 = new Project.TemaUI();
			this.temaUI1 = new Project.TemaUI();
			this.label1 = new System.Windows.Forms.Label();
			this.accentPrekidac1 = new Project.AccentPrekidac();
			this.accentTrakaOpcija = new Project.AccentTrakaOpcija(new STR[] {"Ништа", "Основно", "Све"}, (CEBR) Podesavanja.koriscenjeUDK);
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.promenaLozinke = new Project.AccentDugme();
			this.slikaProfila = new System.Windows.Forms.PictureBox();
			this.novaLozinkaPolje = new Project.AccentPolje();
			this.staraLozinkaPolje = new Project.AccentPolje();
			this.korisnickoIme = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.podesavanjaNalogaMeni = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.измениПодаткеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.менаџментНалогаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.одјавиСеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBox1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.slikaProfila)).BeginInit();
			this.podesavanjaNalogaMeni.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.temaUI2);
			this.groupBox1.Controls.Add(this.temaUI1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.accentPrekidac1);
			this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.groupBox1.Location = new System.Drawing.Point(12, 285);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(402, 100);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Тема";
			// 
			// temaUI2
			// 
			this.temaUI2.Boja1 = System.Drawing.Color.FromArgb(((CEBR)(((byte)(159)))), ((CEBR)(((byte)(75)))), ((CEBR)(((byte)(71)))));
			this.temaUI2.Boja2 = System.Drawing.Color.FromArgb(((CEBR)(((byte)(60)))), ((CEBR)(((byte)(60)))), ((CEBR)(((byte)(60)))));
			this.temaUI2.Boja3 = System.Drawing.Color.FromArgb(((CEBR)(((byte)(36)))), ((CEBR)(((byte)(36)))), ((CEBR)(((byte)(36)))));
			this.temaUI2.JeSelektovana = false;
			this.temaUI2.Location = new System.Drawing.Point(301, 19);
			this.temaUI2.Name = "temaUI2";
			this.temaUI2.Size = new System.Drawing.Size(75, 75);
			this.temaUI2.TabIndex = 3;
			this.temaUI2.Text = "Тамни мод";
			this.temaUI2.JeSelektovanaJeIzmenjeno += new System.EventHandler(this.SvetliModRadioCheckedChanged);
			// 
			// temaUI1
			// 
			this.temaUI1.Boja1 = System.Drawing.Color.FromArgb(((CEBR)(((byte)(122)))), ((CEBR)(((byte)(31)))), ((CEBR)(((byte)(31)))));
			this.temaUI1.Boja2 = System.Drawing.Color.White;
			this.temaUI1.Boja3 = System.Drawing.SystemColors.Control;
			this.temaUI1.JeSelektovana = false;
			this.temaUI1.Location = new System.Drawing.Point(220, 19);
			this.temaUI1.Name = "temaUI1";
			this.temaUI1.Size = new System.Drawing.Size(75, 75);
			this.temaUI1.TabIndex = 3;
			this.temaUI1.Text = "Светли мод";
			this.temaUI1.JeSelektovanaJeIzmenjeno += new System.EventHandler(this.SvetliModRadioCheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.label1.Location = new System.Drawing.Point(16, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(178, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Користи системска подешавања";
			// 
			// accentPrekidac1
			// 
			this.accentPrekidac1.Checked = true;
			this.accentPrekidac1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.accentPrekidac1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.accentPrekidac1.Location = new System.Drawing.Point(16, 51);
			this.accentPrekidac1.Name = "accentPrekidac1";
			this.accentPrekidac1.OnBackColor = System.Drawing.Color.FromArgb(((CEBR)(((byte)(159)))), ((CEBR)(((byte)(75)))), ((CEBR)(((byte)(71)))));
			this.accentPrekidac1.Size = new System.Drawing.Size(41, 24);
			this.accentPrekidac1.TabIndex = 1;
			this.accentPrekidac1.UseVisualStyleBackColor = true;
			this.accentPrekidac1.CheckedChanged += new System.EventHandler(this.AccentPrekidac1CheckedChanged);
			// 
			// accentTrakaOpcija
			// 
			// this.accentTrakaOpcija.Location = new System.Drawing.Point(12, 258);
			this.accentTrakaOpcija.Location = new System.Drawing.Point(12, 76);
			this.accentTrakaOpcija.Name = "accentTrakaOpcija";
			this.accentTrakaOpcija.Size = new System.Drawing.Size(402, 23);
			this.accentTrakaOpcija.TabIndex = 3;
			this.accentTrakaOpcija.SelektovanIndeksPromenjen += new EventHandler(this.TrakaOpcijaIzmenjena);
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((CEBR)(((byte)(121)))), ((CEBR)(((byte)(31)))), ((CEBR)(((byte)(31)))));
			this.panel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel2.BackgroundImage")));
			this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.panel2.Controls.Add(this.label2);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(427, 54);
			this.panel2.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Cursor = System.Windows.Forms.Cursors.Arrow;
			this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold);
			this.label2.ForeColor = System.Drawing.Color.White;
			this.label2.Location = new System.Drawing.Point(0, 0);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
			this.label2.Size = new System.Drawing.Size(427, 54);
			this.label2.TabIndex = 0;
			this.label2.Text = "Библиотека";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.promenaLozinke);
			this.groupBox2.Controls.Add(this.slikaProfila);
			this.groupBox2.Controls.Add(this.novaLozinkaPolje);
			this.groupBox2.Controls.Add(this.staraLozinkaPolje);
			this.groupBox2.Controls.Add(this.korisnickoIme);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			// this.groupBox2.Location = new System.Drawing.Point(12, 76);
			this.groupBox2.Location = new System.Drawing.Point(12, 105);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(402, 176);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Налог";
			// 
			// promenaLozinke
			// 
			this.promenaLozinke.BackColor = System.Drawing.Color.FromArgb(((CEBR)(((byte)(159)))), ((CEBR)(((byte)(75)))), ((CEBR)(((byte)(71)))));
			this.promenaLozinke.Cursor = System.Windows.Forms.Cursors.Hand;
			this.promenaLozinke.Enabled = false;
			this.promenaLozinke.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.promenaLozinke.ForeColor = System.Drawing.Color.White;
			this.promenaLozinke.JeSelektovan = false;
			this.promenaLozinke.KursorNaDugmetu = false;
			this.promenaLozinke.Location = new System.Drawing.Point(156, 140);
			this.promenaLozinke.Name = "promenaLozinke";
			this.promenaLozinke.Size = new System.Drawing.Size(90, 23);
			this.promenaLozinke.TabIndex = 4;
			this.promenaLozinke.Text = "Потврди";
			this.promenaLozinke.UseVisualStyleBackColor = false;
			this.promenaLozinke.Click += new System.EventHandler(this.PromenaLozinkeClick);
			// 
			// slikaProfila
			// 
			this.slikaProfila.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slikaProfila.BackgroundImage")));
			this.slikaProfila.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.slikaProfila.Image = ((System.Drawing.Image)(resources.GetObject("slikaProfila.Image")));
			this.slikaProfila.Location = new System.Drawing.Point(27, 25);
			this.slikaProfila.Name = "slikaProfila";
			this.slikaProfila.Size = new System.Drawing.Size(59, 59);
			this.slikaProfila.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.slikaProfila.TabIndex = 0;
			this.slikaProfila.TabStop = false;
			// 
			// novaLozinkaPolje
			// 
			this.novaLozinkaPolje.BackColor = System.Drawing.Color.White;
			this.novaLozinkaPolje.Hint = "Нова лозинка";
			this.novaLozinkaPolje.JePoljeZaPretragu = false;
			this.novaLozinkaPolje.JeSelektovan = false;
			this.novaLozinkaPolje.JeSifrovan = false;
			this.novaLozinkaPolje.Location = new System.Drawing.Point(220, 97);
			this.novaLozinkaPolje.MaksimalanBrojKaraktera = 32767;
			this.novaLozinkaPolje.Name = "novaLozinkaPolje";
			this.novaLozinkaPolje.Size = new System.Drawing.Size(163, 32);
			this.novaLozinkaPolje.TabIndex = 3;
			this.novaLozinkaPolje.TekstIzmenjen += new System.EventHandler(this.PoljeTekstIzmenjen);
			// 
			// staraLozinkaPolje
			// 
			this.staraLozinkaPolje.BackColor = System.Drawing.Color.White;
			this.staraLozinkaPolje.Hint = "Стара лозинка";
			this.staraLozinkaPolje.JePoljeZaPretragu = false;
			this.staraLozinkaPolje.JeSelektovan = false;
			this.staraLozinkaPolje.JeSifrovan = true;
			this.staraLozinkaPolje.Location = new System.Drawing.Point(19, 97);
			this.staraLozinkaPolje.MaksimalanBrojKaraktera = 32767;
			this.staraLozinkaPolje.Name = "staraLozinkaPolje";
			this.staraLozinkaPolje.Size = new System.Drawing.Size(163, 32);
			this.staraLozinkaPolje.TabIndex = 2;
			this.staraLozinkaPolje.TekstIzmenjen += new System.EventHandler(this.PoljeTekstIzmenjen);
			// 
			// korisnickoIme
			// 
			this.korisnickoIme.AutoSize = true;
			this.korisnickoIme.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.korisnickoIme.Location = new System.Drawing.Point(108, 42);
			this.korisnickoIme.Name = "korisnickoIme";
			this.korisnickoIme.Size = new System.Drawing.Size(0, 25);
			this.korisnickoIme.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label3.Location = new System.Drawing.Point(108, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(94, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Улогован као 🔽";
			this.label3.Click += new System.EventHandler(this.Label3Click);
			// 
			// podesavanjaNalogaMeni
			// 
			this.podesavanjaNalogaMeni.BackColor = System.Drawing.Color.White;
			this.podesavanjaNalogaMeni.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.измениПодаткеToolStripMenuItem,
									this.менаџментНалогаToolStripMenuItem,
									this.одјавиСеToolStripMenuItem});
			this.podesavanjaNalogaMeni.Name = "contextMenuStrip1";
			this.podesavanjaNalogaMeni.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.podesavanjaNalogaMeni.Size = new System.Drawing.Size(180, 70);
			// 
			// измениПодаткеToolStripMenuItem
			// 
			this.измениПодаткеToolStripMenuItem.Name = "измениПодаткеToolStripMenuItem";
			this.измениПодаткеToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.измениПодаткеToolStripMenuItem.Text = "Измени податке";
			this.измениПодаткеToolStripMenuItem.Click += new System.EventHandler(this.ИзмениПодаткеToolStripMenuItemClick);
			// 
			// менаџментНалогаToolStripMenuItem
			// 
			this.менаџментНалогаToolStripMenuItem.Name = "менаџментНалогаToolStripMenuItem";
			this.менаџментНалогаToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.менаџментНалогаToolStripMenuItem.Text = "Менаџмент налога";
			this.менаџментНалогаToolStripMenuItem.Click += new System.EventHandler(this.МенаџментНалогаToolStripMenuItemClick);
			// 
			// одјавиСеToolStripMenuItem
			// 
			this.одјавиСеToolStripMenuItem.Name = "одјавиСеToolStripMenuItem";
			this.одјавиСеToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
			this.одјавиСеToolStripMenuItem.Text = "Одјави се";
			this.одјавиСеToolStripMenuItem.Click += new System.EventHandler(this.ОдјавиСеToolStripMenuItemClick);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 60);
			this.label4.ForeColor = Colors.BojaTeksta;
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(30, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "UDK";
			// 
			// Podesavanja
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(427, 397);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.accentTrakaOpcija);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Podesavanja";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Библиотека: Подешавања";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel2.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.slikaProfila)).EndInit();
			this.podesavanjaNalogaMeni.ResumeLayout(false);
			this.ResumeLayout(false);
			JeOdjavljen = false;
			
			korisnickoIme.Text = korisnik.preuzmiIme() + " " + korisnik.preuzmiPrezime();
			GraphicsPath gp = new GraphicsPath();
			gp.StartFigure();
			gp.AddEllipse(new RectangleF(0, 0, slikaProfila.Width, slikaProfila.Height));
			gp.CloseFigure();
			slikaProfila.Region = new Region(gp);
			Podesavanja_PostaviIzgled(0);
		}
		
		void Podesavanja_PostaviIzgled(CEBR put) {
			this.BackColor = Colors.SvetlijaPozadina;
			accentPrekidac1.Checked = podesavanja["KST"];
			if (put == 0) {
				label1.Location = new Point(accentPrekidac1.Checked ? 112 : 16, 35);
				accentPrekidac1.Location = new Point(accentPrekidac1.Checked ? 181 : 16, 51);
			} else {
				if (accentPrekidac1.Checked) {
					Animacije.PromeniLokaciju(label1, new Point(112, 35), 60, 0.3);
					Animacije.PromeniLokaciju(accentPrekidac1, new Point(181, 51), 60, 0.3);
				} else {
					Animacije.PromeniLokaciju(label1, new Point(16, 35), 60, 0.3);
					Animacije.PromeniLokaciju(accentPrekidac1, new Point(16, 51), 60, 0.3);
				}
			}
			temaUI1.Visible = !accentPrekidac1.Checked;
			temaUI2.Visible = !accentPrekidac1.Checked;
			if (!Podesavanja.podesavanja["TamnaTema"]) temaUI1.JeSelektovana = true;
			else temaUI2.JeSelektovana = true;
			foreach (Control control in this.Controls) {
				Colors.BojenjeForeColor<Label>(control, Colors.BojaTeksta);
				Colors.BojenjeForeColor<GroupBox>(control, Colors.BojaTeksta);
				Colors.BojenjeBackColor<AccentPolje>(control, this.BackColor);
				Colors.BojenjeForeColor<AccentPolje>(control, Colors.BojaTeksta);
			}
			promenaLozinke.BackColor = Colors.AccentColor;
			podesavanjaNalogaMeni.BackColor = Podesavanja.Tema == ETema.Svetla ? Color.FromArgb(240, 240, 240) : Color.FromArgb(70, 70, 70);
			podesavanjaNalogaMeni.ForeColor = Colors.BojaTeksta;
			label2.ForeColor = Color.White;
		}

		void TrakaOpcijaIzmenjena(object sender, EventArgs e) {
			Podesavanja.koriscenjeUDK = (UDK.UDK_Koriscenje) this.accentTrakaOpcija.OpcijaSelektovana;
			using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека", true)) {
				key.SetValue("UDK", (CEBR) Podesavanja.koriscenjeUDK);
				key.Close();
			}
		}
		
		void AccentPrekidac1CheckedChanged(object sender, EventArgs e)
		{
			podesavanja["KST"] = accentPrekidac1.Checked;
			using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека", true)) {
				key.SetValue("KST", podesavanja["KST"]);
				key.Close();
			}
			Podesavanja_PostaviIzgled(1);
		}
		
		void SvetliModRadioCheckedChanged(object sender, EventArgs e)
		{
			Podesavanja.podesavanja["TamnaTema"] = !temaUI1.JeSelektovana;
			using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Библиотека", true)) {
				key.SetValue("TamnaTema", podesavanja["TamnaTema"]);
				key.Close();
			}
			Podesavanja_PostaviIzgled(1);
		}
		
		void PoljeTekstIzmenjen(object sender, EventArgs e)
		{
			promenaLozinke.Enabled = staraLozinkaPolje.Text.Length != 0 && novaLozinkaPolje.Text.Length != 0;
			promenaLozinke.Invalidate();
		}
		
		void PromenaLozinkeClick(object sender, EventArgs e)
		{
			if (korisnik.preuzmiLozinku() == staraLozinkaPolje.Text) {
				korisnik.postaviLozinku(novaLozinkaPolje.Text);
				staraLozinkaPolje.Clear();
				
				for (CEBR i = 0; i < MenadzmentPodataka.korisnici.Count; i++) {
					if (MenadzmentPodataka.korisnici[i].preuzmiID() == korisnik.preuzmiID()) {
						MenadzmentPodataka.korisnici[i] = korisnik;
						MenadzmentPodataka.korisnikPodaciCuvanje(MenadzmentPodataka.korisnici, "korisnici");
					}
				}
			}
			
			novaLozinkaPolje.Clear();
		}
		
		void Label3Click(object sender, EventArgs e)
		{
			podesavanjaNalogaMeni.Show();
			podesavanjaNalogaMeni.Location = Cursor.Position;
		}
		
		void ИзмениПодаткеToolStripMenuItemClick(object sender, EventArgs e)
		{
			// DONE: Otvoriti formu za kompletnu izmenu podataka
			NalogIzmena nalogIzmena = new NalogIzmena(ref Podesavanja.korisnik);
			nalogIzmena.ShowDialog();
			if (nalogIzmena.JeIzmenjen) korisnickoIme.Text = korisnik.preuzmiIme() + " " + korisnik.preuzmiPrezime();
			nalogIzmena.Dispose();
		}
		
		void МенаџментНалогаToolStripMenuItemClick(object sender, EventArgs e)
		{
			NaloziIzmena naloziIzmena = new NaloziIzmena();
			naloziIzmena.ShowDialog();
			if (naloziIzmena.JeIzmenjen) korisnickoIme.Text = korisnik.preuzmiIme() + " " + korisnik.preuzmiPrezime();
			naloziIzmena.Dispose();
		}
		
		void ОдјавиСеToolStripMenuItemClick(object sender, EventArgs e)
		{
			JeOdjavljen = true;
			this.Close();
		}
	}
}
