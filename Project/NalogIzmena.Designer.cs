////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

namespace Project
{
	partial class NalogIzmena
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NalogIzmena));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.accentPolje1 = new Project.AccentPolje();
			this.accentPolje2 = new Project.AccentPolje();
			this.accentPolje3 = new Project.AccentPolje();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Location = new System.Drawing.Point(31, 24);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(75, 75);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// accentPolje1
			// 
			this.accentPolje1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.accentPolje1.BackColor = System.Drawing.Color.White;
			this.accentPolje1.Hint = "Име";
			this.accentPolje1.JePoljeZaPretragu = false;
			this.accentPolje1.JeSelektovan = false;
			this.accentPolje1.JeSifrovan = false;
			this.accentPolje1.Location = new System.Drawing.Point(124, 24);
			this.accentPolje1.MaksimalanBrojKaraktera = 32767;
			this.accentPolje1.Name = "accentPolje1";
			this.accentPolje1.Size = new System.Drawing.Size(179, 32);
			this.accentPolje1.TabIndex = 1;
			this.accentPolje1.TekstIzmenjen += new System.EventHandler(this.AccentPoljeTekstIzmenjen);
			// 
			// accentPolje2
			// 
			this.accentPolje2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.accentPolje2.BackColor = System.Drawing.Color.White;
			this.accentPolje2.Hint = "Презиме";
			this.accentPolje2.JePoljeZaPretragu = false;
			this.accentPolje2.JeSelektovan = false;
			this.accentPolje2.JeSifrovan = false;
			this.accentPolje2.Location = new System.Drawing.Point(124, 67);
			this.accentPolje2.MaksimalanBrojKaraktera = 32767;
			this.accentPolje2.Name = "accentPolje2";
			this.accentPolje2.Size = new System.Drawing.Size(175, 32);
			this.accentPolje2.TabIndex = 2;
			this.accentPolje2.TekstIzmenjen += new System.EventHandler(this.AccentPoljeTekstIzmenjen);
			// 
			// accentPolje3
			// 
			this.accentPolje3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.accentPolje3.BackColor = System.Drawing.Color.White;
			this.accentPolje3.Hint = "Година рођења";
			this.accentPolje3.JePoljeZaPretragu = false;
			this.accentPolje3.JeSelektovan = false;
			this.accentPolje3.JeSifrovan = false;
			this.accentPolje3.Location = new System.Drawing.Point(23, 115);
			this.accentPolje3.MaksimalanBrojKaraktera = 4;
			this.accentPolje3.Name = "accentPolje3";
			this.accentPolje3.Size = new System.Drawing.Size(280, 32);
			this.accentPolje3.TabIndex = 3;
			this.accentPolje3.TekstIzmenjen += new System.EventHandler(this.AccentPoljeTekstIzmenjen);
			// 
			// label1
			// 
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(4, 156);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(319, 23);
			this.label1.TabIndex = 8;
			this.label1.Text = "Попуните сва поља";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// NalogIzmena
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(327, 184);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.accentPolje3);
			this.Controls.Add(this.accentPolje2);
			this.Controls.Add(this.accentPolje1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NalogIzmena";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Библиотека: Измена налога";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NalogIzmenaKeyDown);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label1;
		private Project.AccentPolje accentPolje3;
		private Project.AccentPolje accentPolje2;
		private Project.AccentPolje accentPolje1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
