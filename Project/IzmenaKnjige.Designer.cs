////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

namespace Project
{
	partial class IzmenaKnjige
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzmenaKnjige));
			this.label1 = new System.Windows.Forms.Label();
			this.knjigaUI1 = new Project.KnjigaUI();
			this.accentPolje1 = new Project.AccentPolje();
			this.accentPolje2 = new Project.AccentPolje();
			this.accentIzbornoPolje1 = new Project.AccentIzbornoPolje();
			this.accentPolje3 = new Project.AccentPolje();
			this.accentIzbornoPolje2 = new Project.AccentIzbornoPolje();
			this.accentIzbornoPolje3 = new Project.AccentIzbornoPolje();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.BackColor = System.Drawing.Color.White;
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(4, 441);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(316, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Унесите измену";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// knjigaUI1
			// 
			this.knjigaUI1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.knjigaUI1.Autor = "label2";
			this.knjigaUI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.knjigaUI1.GodinaIzdanja = 0;
			this.knjigaUI1.Location = new System.Drawing.Point(97, 26);
			this.knjigaUI1.Name = "knjigaUI1";
			this.knjigaUI1.Naziv = "label1";
			this.knjigaUI1.Size = new System.Drawing.Size(125, 167);
			this.knjigaUI1.TabIndex = 0;
			// 
			// accentPolje1
			// 
			this.accentPolje1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentPolje1.BackColor = System.Drawing.Color.White;
			this.accentPolje1.Hint = "Назив";
			this.accentPolje1.JePoljeZaPretragu = false;
			this.accentPolje1.JeSelektovan = false;
			this.accentPolje1.JeSifrovan = false;
			this.accentPolje1.Location = new System.Drawing.Point(26, 216);
			this.accentPolje1.MaksimalanBrojKaraktera = 32767;
			this.accentPolje1.Name = "accentPolje1";
			this.accentPolje1.Size = new System.Drawing.Size(266, 32);
			this.accentPolje1.TabIndex = 1;
			// 
			// accentPolje2
			// 
			this.accentPolje2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentPolje2.BackColor = System.Drawing.Color.White;
			this.accentPolje2.Hint = "Број страна";
			this.accentPolje2.JePoljeZaPretragu = false;
			this.accentPolje2.JeSelektovan = false;
			this.accentPolje2.JeSifrovan = false;
			this.accentPolje2.Location = new System.Drawing.Point(26, 306);
			this.accentPolje2.MaksimalanBrojKaraktera = 5;
			this.accentPolje2.Name = "accentPolje2";
			this.accentPolje2.Size = new System.Drawing.Size(134, 32);
			this.accentPolje2.TabIndex = 1;
			// 
			// accentIzbornoPolje1
			// 
			this.accentIzbornoPolje1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentIzbornoPolje1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.accentIzbornoPolje1.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.accentIzbornoPolje1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje1.IzborBoja = Project.AccentIzbornoPolje.IzbornoPolje_StilBoja.Jednostavno;
			this.accentIzbornoPolje1.Location = new System.Drawing.Point(26, 261);
			this.accentIzbornoPolje1.MinimumSize = new System.Drawing.Size(200, 30);
			this.accentIzbornoPolje1.Name = "accentIzbornoPolje1";
			this.accentIzbornoPolje1.Padding = new System.Windows.Forms.Padding(1);
			this.accentIzbornoPolje1.Size = new System.Drawing.Size(266, 30);
			this.accentIzbornoPolje1.TabIndex = 2;
			this.accentIzbornoPolje1.Tekst = "";
			this.accentIzbornoPolje1.VelicinaIvica = 1;
			// 
			// accentPolje3
			// 
			this.accentPolje3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentPolje3.BackColor = System.Drawing.Color.White;
			this.accentPolje3.Hint = "Година издања";
			this.accentPolje3.JePoljeZaPretragu = false;
			this.accentPolje3.JeSelektovan = false;
			this.accentPolje3.JeSifrovan = false;
			this.accentPolje3.Location = new System.Drawing.Point(166, 306);
			this.accentPolje3.MaksimalanBrojKaraktera = 4;
			this.accentPolje3.Name = "accentPolje3";
			this.accentPolje3.Size = new System.Drawing.Size(126, 32);
			this.accentPolje3.TabIndex = 1;
			// 
			// accentIzbornoPolje2
			// 
			this.accentIzbornoPolje2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentIzbornoPolje2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.accentIzbornoPolje2.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.accentIzbornoPolje2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje2.IzborBoja = Project.AccentIzbornoPolje.IzbornoPolje_StilBoja.Jednostavno;
			this.accentIzbornoPolje2.Location = new System.Drawing.Point(26, 354);
			this.accentIzbornoPolje2.MinimumSize = new System.Drawing.Size(200, 30);
			this.accentIzbornoPolje2.Name = "accentIzbornoPolje2";
			this.accentIzbornoPolje2.Padding = new System.Windows.Forms.Padding(1);
			this.accentIzbornoPolje2.Size = new System.Drawing.Size(266, 30);
			this.accentIzbornoPolje2.TabIndex = 3;
			this.accentIzbornoPolje2.Tekst = "";
			this.accentIzbornoPolje2.VelicinaIvica = 1;
			// 
			// accentIzbornoPolje3
			// 
			this.accentIzbornoPolje3.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.accentIzbornoPolje3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.accentIzbornoPolje3.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.accentIzbornoPolje3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje3.IzborBoja = Project.AccentIzbornoPolje.IzbornoPolje_StilBoja.Jednostavno;
			this.accentIzbornoPolje3.Location = new System.Drawing.Point(26, 394);
			this.accentIzbornoPolje3.MinimumSize = new System.Drawing.Size(200, 30);
			this.accentIzbornoPolje3.Name = "accentIzbornoPolje3";
			this.accentIzbornoPolje3.Padding = new System.Windows.Forms.Padding(1);
			this.accentIzbornoPolje3.Size = new System.Drawing.Size(266, 30);
			this.accentIzbornoPolje3.TabIndex = 4;
			this.accentIzbornoPolje3.Tekst = "";
			this.accentIzbornoPolje3.VelicinaIvica = 1;
			// 
			// IzmenaKnjige
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(318, 465);
			this.Controls.Add(this.accentIzbornoPolje3);
			this.Controls.Add(this.accentIzbornoPolje2);
			this.Controls.Add(this.accentIzbornoPolje1);
			this.Controls.Add(this.accentPolje1);
			this.Controls.Add(this.accentPolje3);
			this.Controls.Add(this.accentPolje2);
			this.Controls.Add(this.knjigaUI1);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IzmenaKnjige";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Библоитека: Измена књиге";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NaPritisnutTaster);
			this.ResumeLayout(false);
		}
		private Project.AccentIzbornoPolje accentIzbornoPolje3;
		private Project.AccentIzbornoPolje accentIzbornoPolje2;
		private Project.AccentPolje accentPolje3;
		private Project.AccentIzbornoPolje accentIzbornoPolje1;
		private Project.AccentPolje accentPolje1;
		private Project.AccentPolje accentPolje2;
		private Project.KnjigaUI knjigaUI1;
		private System.Windows.Forms.Label label1;
	}
}
