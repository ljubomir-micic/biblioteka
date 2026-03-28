////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

namespace Project
{
	partial class DodajKnjigu
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DodajKnjigu));
			this.accentIzbornoPolje3 = new Project.AccentIzbornoPolje();
			this.accentIzbornoPolje2 = new Project.AccentIzbornoPolje();
			this.accentIzbornoPolje1 = new Project.AccentIzbornoPolje();
			this.accentPolje1 = new Project.AccentPolje();
			this.accentPolje3 = new Project.AccentPolje();
			this.accentPolje2 = new Project.AccentPolje();
			this.knjigaUI1 = new Project.KnjigaUI();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// accentIzbornoPolje3
			// 
			this.accentIzbornoPolje3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentIzbornoPolje3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.accentIzbornoPolje3.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.accentIzbornoPolje3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje3.IzborBoja = Project.AccentIzbornoPolje.IzbornoPolje_StilBoja.Jednostavno;
			this.accentIzbornoPolje3.Location = new System.Drawing.Point(20, 390);
			this.accentIzbornoPolje3.MinimumSize = new System.Drawing.Size(200, 30);
			this.accentIzbornoPolje3.Name = "accentIzbornoPolje3";
			this.accentIzbornoPolje3.Padding = new System.Windows.Forms.Padding(1);
			this.accentIzbornoPolje3.Size = new System.Drawing.Size(287, 30);
			this.accentIzbornoPolje3.TabIndex = 6;
			this.accentIzbornoPolje3.Tekst = "";
			this.accentIzbornoPolje3.VelicinaIvica = 1;
			this.accentIzbornoPolje3.SelektovanIndeksPromenjen += new System.EventHandler(this.AccentIzbornoPolje3SelektovanIndeksPromenjen);
			// 
			// accentIzbornoPolje2
			// 
			this.accentIzbornoPolje2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentIzbornoPolje2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.accentIzbornoPolje2.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.accentIzbornoPolje2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje2.IzborBoja = Project.AccentIzbornoPolje.IzbornoPolje_StilBoja.Jednostavno;
			this.accentIzbornoPolje2.Location = new System.Drawing.Point(20, 350);
			this.accentIzbornoPolje2.MinimumSize = new System.Drawing.Size(200, 30);
			this.accentIzbornoPolje2.Name = "accentIzbornoPolje2";
			this.accentIzbornoPolje2.Padding = new System.Windows.Forms.Padding(1);
			this.accentIzbornoPolje2.Size = new System.Drawing.Size(239, 30);
			this.accentIzbornoPolje2.TabIndex = 5;
			this.accentIzbornoPolje2.Tekst = "";
			this.accentIzbornoPolje2.VelicinaIvica = 1;
			this.accentIzbornoPolje2.SelektovanIndeksPromenjen += new System.EventHandler(this.AccentIzbornoPolje2SelektovanIndeksPromenjen);
			// 
			// accentIzbornoPolje1
			// 
			this.accentIzbornoPolje1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentIzbornoPolje1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.accentIzbornoPolje1.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.accentIzbornoPolje1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje1.IzborBoja = Project.AccentIzbornoPolje.IzbornoPolje_StilBoja.Jednostavno;
			this.accentIzbornoPolje1.Location = new System.Drawing.Point(21, 257);
			this.accentIzbornoPolje1.MinimumSize = new System.Drawing.Size(200, 30);
			this.accentIzbornoPolje1.Name = "accentIzbornoPolje1";
			this.accentIzbornoPolje1.Padding = new System.Windows.Forms.Padding(1);
			this.accentIzbornoPolje1.Size = new System.Drawing.Size(239, 30);
			this.accentIzbornoPolje1.TabIndex = 2;
			this.accentIzbornoPolje1.Tekst = "";
			this.accentIzbornoPolje1.VelicinaIvica = 1;
			this.accentIzbornoPolje1.SelektovanIndeksPromenjen += new System.EventHandler(this.AccentIzbornoPolje1SelektovanIndeksPromenjen);
			// 
			// accentPolje1
			// 
			this.accentPolje1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentPolje1.BackColor = System.Drawing.Color.White;
			this.accentPolje1.Hint = "Назив";
			this.accentPolje1.JePoljeZaPretragu = false;
			this.accentPolje1.JeSelektovan = false;
			this.accentPolje1.JeSifrovan = false;
			this.accentPolje1.Location = new System.Drawing.Point(20, 212);
			this.accentPolje1.MaksimalanBrojKaraktera = 32767;
			this.accentPolje1.Name = "accentPolje1";
			this.accentPolje1.Size = new System.Drawing.Size(287, 32);
			this.accentPolje1.TabIndex = 1;
			this.accentPolje1.TekstIzmenjen += new System.EventHandler(this.AccentPolje1TekstIzmenjen);
			// 
			// accentPolje3
			// 
			this.accentPolje3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentPolje3.BackColor = System.Drawing.Color.White;
			this.accentPolje3.Hint = "Година издања";
			this.accentPolje3.JePoljeZaPretragu = false;
			this.accentPolje3.JeSelektovan = false;
			this.accentPolje3.JeSifrovan = false;
			this.accentPolje3.Location = new System.Drawing.Point(168, 302);
			this.accentPolje3.MaksimalanBrojKaraktera = 4;
			this.accentPolje3.Name = "accentPolje3";
			this.accentPolje3.Size = new System.Drawing.Size(139, 32);
			this.accentPolje3.TabIndex = 4;
			this.accentPolje3.TekstIzmenjen += new System.EventHandler(this.AccentPolje3TekstIzmenjen);
			// 
			// accentPolje2
			// 
			this.accentPolje2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentPolje2.BackColor = System.Drawing.Color.White;
			this.accentPolje2.Hint = "Број страна";
			this.accentPolje2.JePoljeZaPretragu = false;
			this.accentPolje2.JeSelektovan = false;
			this.accentPolje2.JeSifrovan = false;
			this.accentPolje2.Location = new System.Drawing.Point(20, 302);
			this.accentPolje2.MaksimalanBrojKaraktera = 5;
			this.accentPolje2.Name = "accentPolje2";
			this.accentPolje2.Size = new System.Drawing.Size(139, 32);
			this.accentPolje2.TabIndex = 3;
			this.accentPolje2.TekstIzmenjen += new System.EventHandler(this.AccentPolje2TekstIzmenjen);
			// 
			// knjigaUI1
			// 
			this.knjigaUI1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.knjigaUI1.Autor = "label2";
			this.knjigaUI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.knjigaUI1.GodinaIzdanja = 0;
			this.knjigaUI1.Location = new System.Drawing.Point(101, 22);
			this.knjigaUI1.Name = "knjigaUI1";
			this.knjigaUI1.Naziv = "label1";
			this.knjigaUI1.Size = new System.Drawing.Size(125, 167);
			this.knjigaUI1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(12, 433);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(303, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "Попуните сва поља";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.button1.Location = new System.Drawing.Point(267, 257);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(40, 30);
			this.button1.TabIndex = 8;
			this.button1.Text = "➕";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
			this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.button2.Location = new System.Drawing.Point(267, 350);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(40, 30);
			this.button2.TabIndex = 8;
			this.button2.Text = "➕";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// DodajKnjigu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(327, 465);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.accentIzbornoPolje3);
			this.Controls.Add(this.accentIzbornoPolje2);
			this.Controls.Add(this.accentIzbornoPolje1);
			this.Controls.Add(this.accentPolje1);
			this.Controls.Add(this.accentPolje3);
			this.Controls.Add(this.accentPolje2);
			this.Controls.Add(this.knjigaUI1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "DodajKnjigu";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Библиотека: Додавање књиге";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NaPritisnutTaster);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label1;
		private Project.KnjigaUI knjigaUI1;
		private Project.AccentPolje accentPolje2;
		private Project.AccentPolje accentPolje3;
		private Project.AccentPolje accentPolje1;
		private Project.AccentIzbornoPolje accentIzbornoPolje1;
		private Project.AccentIzbornoPolje accentIzbornoPolje2;
		private Project.AccentIzbornoPolje accentIzbornoPolje3;
	}
}
