////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

namespace Project
{
	partial class Iznajmljivanje_VracanjeKnjige
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Iznajmljivanje_VracanjeKnjige));
			this.iznajmljivanjePanel = new System.Windows.Forms.Panel();
			this.accentDugme1 = new Project.AccentDugme();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.accentIzbornoPolje1 = new Project.AccentIzbornoPolje();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.knjigaUI1 = new Project.KnjigaUI();
			this.vracanjePanel = new System.Windows.Forms.Panel();
			this.iznajmljivanjePanel.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// iznajmljivanjePanel
			// 
			this.iznajmljivanjePanel.BackColor = System.Drawing.Color.White;
			this.iznajmljivanjePanel.Controls.Add(this.accentDugme1);
			this.iznajmljivanjePanel.Controls.Add(this.groupBox2);
			this.iznajmljivanjePanel.Controls.Add(this.groupBox1);
			this.iznajmljivanjePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.iznajmljivanjePanel.Location = new System.Drawing.Point(0, 0);
			this.iznajmljivanjePanel.Name = "iznajmljivanjePanel";
			this.iznajmljivanjePanel.Size = new System.Drawing.Size(504, 497);
			this.iznajmljivanjePanel.TabIndex = 0;
			// 
			// accentDugme1
			// 
			this.accentDugme1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.accentDugme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentDugme1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.accentDugme1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.accentDugme1.ForeColor = System.Drawing.Color.White;
			this.accentDugme1.KursorNaDugmetu = false;
			this.accentDugme1.Location = new System.Drawing.Point(374, 450);
			this.accentDugme1.Name = "accentDugme1";
			this.accentDugme1.Size = new System.Drawing.Size(118, 35);
			this.accentDugme1.TabIndex = 2;
			this.accentDugme1.Text = "Заврши";
			this.accentDugme1.UseVisualStyleBackColor = false;
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.accentIzbornoPolje1);
			this.groupBox2.Location = new System.Drawing.Point(13, 241);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(479, 194);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Подаци о члану";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.label5.Location = new System.Drawing.Point(31, 152);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Година рођења: ";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.label4.Location = new System.Drawing.Point(31, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(38, 13);
			this.label4.TabIndex = 1;
			this.label4.Text = "ЈМБГ: ";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.label3.Location = new System.Drawing.Point(31, 104);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(60, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Презиме: ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.label2.Location = new System.Drawing.Point(31, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(35, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Име: ";
			// 
			// accentIzbornoPolje1
			// 
			this.accentIzbornoPolje1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.accentIzbornoPolje1.Font = new System.Drawing.Font("Segoe UI", 10F);
			this.accentIzbornoPolje1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentIzbornoPolje1.IzborBoja = Project.AccentIzbornoPolje.IzbornoPolje_StilBoja.Jednostavno;
			this.accentIzbornoPolje1.Location = new System.Drawing.Point(18, 29);
			this.accentIzbornoPolje1.MinimumSize = new System.Drawing.Size(200, 30);
			this.accentIzbornoPolje1.Name = "accentIzbornoPolje1";
			this.accentIzbornoPolje1.Padding = new System.Windows.Forms.Padding(1);
			this.accentIzbornoPolje1.Size = new System.Drawing.Size(443, 30);
			this.accentIzbornoPolje1.TabIndex = 0;
			this.accentIzbornoPolje1.Tekst = "";
			this.accentIzbornoPolje1.VelicinaIvica = 1;
			this.accentIzbornoPolje1.SelektovanIndeksPromenjen += new System.EventHandler(this.AccentIzbornoPolje1SelektovanIndeksPromenjen);
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.knjigaUI1);
			this.groupBox1.Location = new System.Drawing.Point(13, 13);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(479, 222);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Информације о књизи";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.label6.Location = new System.Drawing.Point(178, 43);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(38, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "label6";
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(175, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(286, 49);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			// 
			// knjigaUI1
			// 
			this.knjigaUI1.Autor = "label2";
			this.knjigaUI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.knjigaUI1.GodinaIzdanja = 0;
			this.knjigaUI1.Location = new System.Drawing.Point(31, 34);
			this.knjigaUI1.Name = "knjigaUI1";
			this.knjigaUI1.Naziv = "label1";
			this.knjigaUI1.Size = new System.Drawing.Size(125, 167);
			this.knjigaUI1.TabIndex = 0;
			// 
			// vracanjePanel
			// 
			this.vracanjePanel.BackColor = System.Drawing.Color.White;
			this.vracanjePanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.vracanjePanel.Location = new System.Drawing.Point(0, 0);
			this.vracanjePanel.Name = "vracanjePanel";
			this.vracanjePanel.Size = new System.Drawing.Size(504, 497);
			this.vracanjePanel.TabIndex = 0;
			// 
			// Iznajmljivanje_VracanjeKnjige
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(504, 497);
			this.Controls.Add(this.iznajmljivanjePanel);
			this.Controls.Add(this.vracanjePanel);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Iznajmljivanje_VracanjeKnjige";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Iznajmljivanje_VracanjeKnjige";
			this.iznajmljivanjePanel.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label1;
		private Project.AccentIzbornoPolje accentIzbornoPolje1;
		private Project.KnjigaUI knjigaUI1;
		private Project.AccentDugme accentDugme1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Panel vracanjePanel;
		private System.Windows.Forms.Panel iznajmljivanjePanel;
	}
}
