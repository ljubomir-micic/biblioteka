////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

namespace Project
{
	partial class Podesavanja
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Podesavanja));
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.temaUI2 = new Project.TemaUI();
			this.temaUI1 = new Project.TemaUI();
			this.label1 = new System.Windows.Forms.Label();
			this.accentPrekidac1 = new Project.AccentPrekidac();
			this.accentTrakaOpcija = new Project.AccentTrakaOpcija();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
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
			this.label4 = new System.Windows.Forms.Label();
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
			this.temaUI2.Boja1 = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
			this.temaUI2.Boja2 = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
			this.temaUI2.Boja3 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
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
			this.temaUI1.Boja1 = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
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
			this.accentPrekidac1.OnBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
			this.accentPrekidac1.Size = new System.Drawing.Size(41, 24);
			this.accentPrekidac1.TabIndex = 1;
			this.accentPrekidac1.UseVisualStyleBackColor = true;
			this.accentPrekidac1.CheckedChanged += new System.EventHandler(this.AccentPrekidac1CheckedChanged);
			// 
			// accentTrakaOpcija
			// 
			this.accentTrakaOpcija.Location = new System.Drawing.Point(12, 258);
			this.accentTrakaOpcija.Name = "accentTrakaOpcija";
			this.accentTrakaOpcija.OpcijaSelektovana = 0;
			this.accentTrakaOpcija.Size = new System.Drawing.Size(402, 23);
			this.accentTrakaOpcija.TabIndex = 3;
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
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
			this.groupBox2.Location = new System.Drawing.Point(12, 76);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(402, 176);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Налог";
			// 
			// promenaLozinke
			// 
			this.promenaLozinke.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(159)))), ((int)(((byte)(75)))), ((int)(((byte)(71)))));
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
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label4;
		private Project.TemaUI temaUI2;
		private Project.TemaUI temaUI1;
		private Project.AccentTrakaOpcija accentTrakaOpcija;
		private System.Windows.Forms.ToolStripMenuItem одјавиСеToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem менаџментНалогаToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem измениПодаткеToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip podesavanjaNalogaMeni;
		private Project.AccentPolje staraLozinkaPolje;
		private Project.AccentPolje novaLozinkaPolje;
		private Project.AccentDugme promenaLozinke;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label korisnickoIme;
		private System.Windows.Forms.PictureBox slikaProfila;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private Project.AccentPrekidac accentPrekidac1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
