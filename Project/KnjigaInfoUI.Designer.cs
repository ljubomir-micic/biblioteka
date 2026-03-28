////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

namespace Project
{
	partial class KnjigaInfoUI
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.knjigaUI1 = new Project.KnjigaUI();
			this.label1 = new System.Windows.Forms.Label();
			this.zvezdastoDugme1 = new Project.ZvezdastoDugme();
			this.label2 = new System.Windows.Forms.Label();
			this.dugmeKrug1 = new Project.DugmeKrug();
			this.SuspendLayout();
			// 
			// knjigaUI1
			// 
			this.knjigaUI1.Autor = "label2";
			this.knjigaUI1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.knjigaUI1.GodinaIzdanja = 0;
			this.knjigaUI1.Location = new System.Drawing.Point(21, 16);
			this.knjigaUI1.Name = "knjigaUI1";
			this.knjigaUI1.Naziv = "label1";
			this.knjigaUI1.Size = new System.Drawing.Size(125, 167);
			this.knjigaUI1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(3, 193);
			this.label1.Name = "label1";
			this.label1.Padding = new System.Windows.Forms.Padding(7, 0, 7, 0);
			this.label1.Size = new System.Drawing.Size(124, 52);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			this.label1.Click += new System.EventHandler(this.Label1Click);
			// 
			// zvezdastoDugme1
			// 
			this.zvezdastoDugme1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.zvezdastoDugme1.FlatAppearance.BorderSize = 0;
			this.zvezdastoDugme1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.zvezdastoDugme1.JeOmiljen = false;
			this.zvezdastoDugme1.Kraci = 5;
			this.zvezdastoDugme1.Location = new System.Drawing.Point(133, 198);
			this.zvezdastoDugme1.Name = "zvezdastoDugme1";
			this.zvezdastoDugme1.Size = new System.Drawing.Size(23, 23);
			this.zvezdastoDugme1.TabIndex = 2;
			this.zvezdastoDugme1.Text = "zvezdastoDugme1";
			this.zvezdastoDugme1.UseVisualStyleBackColor = true;
			this.zvezdastoDugme1.Click += new System.EventHandler(this.ZvezdastoDugme1Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
			this.label2.Location = new System.Drawing.Point(3, 240);
			this.label2.Name = "label2";
			this.label2.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
			this.label2.Size = new System.Drawing.Size(161, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "label2";
			this.label2.Click += new System.EventHandler(this.Label2Click);
			// 
			// dugmeKrug1
			// 
			this.dugmeKrug1.Location = new System.Drawing.Point(10, 7);
			this.dugmeKrug1.Name = "dugmeKrug1";
			this.dugmeKrug1.Pozadina = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
			this.dugmeKrug1.Size = new System.Drawing.Size(75, 23);
			this.dugmeKrug1.TabIndex = 4;
			this.dugmeKrug1.Text = "dugmeKrug1";
			this.dugmeKrug1.UseVisualStyleBackColor = true;
			this.dugmeKrug1.Click += new System.EventHandler(this.DugmeKrug1Click);
			// 
			// KnjigaInfoUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dugmeKrug1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.zvezdastoDugme1);
			this.Controls.Add(this.knjigaUI1);
			this.Controls.Add(this.label1);
			this.Name = "KnjigaInfoUI";
			this.Size = new System.Drawing.Size(167, 261);
			this.ResumeLayout(false);
		}
		private Project.DugmeKrug dugmeKrug1;
		private System.Windows.Forms.Label label2;
		private ZvezdastoDugme zvezdastoDugme1;
		private System.Windows.Forms.Label label1;
		private KnjigaUI knjigaUI1;
	}
}
