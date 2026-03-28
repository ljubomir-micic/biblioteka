////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

namespace Project
{
	partial class NaloziIzmena
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NaloziIzmena));
			this.panel1 = new System.Windows.Forms.Panel();
			this.accentDugme1 = new Project.AccentDugme();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.accentDugme1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(374, 456);
			this.panel1.TabIndex = 0;
			// 
			// accentDugme1
			// 
			this.accentDugme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentDugme1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.accentDugme1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.accentDugme1.ForeColor = System.Drawing.Color.White;
			this.accentDugme1.JeSelektovan = false;
			this.accentDugme1.KursorNaDugmetu = false;
			this.accentDugme1.Location = new System.Drawing.Point(268, 421);
			this.accentDugme1.Name = "accentDugme1";
			this.accentDugme1.Size = new System.Drawing.Size(94, 23);
			this.accentDugme1.TabIndex = 0;
			this.accentDugme1.Text = "Додај ➕";
			this.accentDugme1.UseVisualStyleBackColor = false;
			this.accentDugme1.Click += new System.EventHandler(this.AccentDugme1Click);
			// 
			// NaloziIzmena
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(374, 456);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "NaloziIzmena";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Библиотека: Измена свих налога";
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private Project.AccentDugme accentDugme1;
		private System.Windows.Forms.Panel panel1;
	}
}
