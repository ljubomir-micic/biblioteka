////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

namespace Project
{
	partial class IzmenaAutora
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IzmenaAutora));
			this.label1 = new System.Windows.Forms.Label();
			this.accentPolje4 = new Project.AccentPolje();
			this.accentPolje3 = new Project.AccentPolje();
			this.accentPolje2 = new Project.AccentPolje();
			this.accentPolje1 = new Project.AccentPolje();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(12, 148);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(335, 23);
			this.label1.TabIndex = 11;
			this.label1.Text = "Попуните сва поља";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// accentPolje4
			// 
			this.accentPolje4.BackColor = System.Drawing.Color.White;
			this.accentPolje4.Hint = "Година смрти";
			this.accentPolje4.JePoljeZaPretragu = false;
			this.accentPolje4.JeSelektovan = false;
			this.accentPolje4.JeSifrovan = false;
			this.accentPolje4.Location = new System.Drawing.Point(192, 107);
			this.accentPolje4.MaksimalanBrojKaraktera = 4;
			this.accentPolje4.Name = "accentPolje4";
			this.accentPolje4.Size = new System.Drawing.Size(124, 32);
			this.accentPolje4.TabIndex = 10;
			this.accentPolje4.TekstIzmenjen += new System.EventHandler(this.AccentPolja_TekstIzmenjen);
			// 
			// accentPolje3
			// 
			this.accentPolje3.BackColor = System.Drawing.Color.White;
			this.accentPolje3.Hint = "Година рођења";
			this.accentPolje3.JePoljeZaPretragu = false;
			this.accentPolje3.JeSelektovan = false;
			this.accentPolje3.JeSifrovan = false;
			this.accentPolje3.Location = new System.Drawing.Point(43, 107);
			this.accentPolje3.MaksimalanBrojKaraktera = 4;
			this.accentPolje3.Name = "accentPolje3";
			this.accentPolje3.Size = new System.Drawing.Size(124, 32);
			this.accentPolje3.TabIndex = 9;
			this.accentPolje3.TekstIzmenjen += new System.EventHandler(this.AccentPolja_TekstIzmenjen);
			// 
			// accentPolje2
			// 
			this.accentPolje2.BackColor = System.Drawing.Color.White;
			this.accentPolje2.Hint = "Презиме";
			this.accentPolje2.JePoljeZaPretragu = false;
			this.accentPolje2.JeSelektovan = false;
			this.accentPolje2.JeSifrovan = false;
			this.accentPolje2.Location = new System.Drawing.Point(122, 59);
			this.accentPolje2.MaksimalanBrojKaraktera = 32767;
			this.accentPolje2.Name = "accentPolje2";
			this.accentPolje2.Size = new System.Drawing.Size(212, 32);
			this.accentPolje2.TabIndex = 8;
			this.accentPolje2.TekstIzmenjen += new System.EventHandler(this.AccentPolja_TekstIzmenjen);
			// 
			// accentPolje1
			// 
			this.accentPolje1.BackColor = System.Drawing.Color.White;
			this.accentPolje1.Hint = "Име";
			this.accentPolje1.JePoljeZaPretragu = false;
			this.accentPolje1.JeSelektovan = false;
			this.accentPolje1.JeSifrovan = false;
			this.accentPolje1.Location = new System.Drawing.Point(122, 16);
			this.accentPolje1.MaksimalanBrojKaraktera = 32767;
			this.accentPolje1.Name = "accentPolje1";
			this.accentPolje1.Size = new System.Drawing.Size(212, 32);
			this.accentPolje1.TabIndex = 7;
			this.accentPolje1.TekstIzmenjen += new System.EventHandler(this.AccentPolja_TekstIzmenjen);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Location = new System.Drawing.Point(25, 16);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(75, 75);
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// IzmenaAutora
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(359, 187);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.accentPolje4);
			this.Controls.Add(this.accentPolje3);
			this.Controls.Add(this.accentPolje2);
			this.Controls.Add(this.accentPolje1);
			this.Controls.Add(this.pictureBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IzmenaAutora";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Библиотека: Измена аутора";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.NaPritisnutTaster);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.PictureBox pictureBox1;
		private Project.AccentPolje accentPolje1;
		private Project.AccentPolje accentPolje2;
		private Project.AccentPolje accentPolje3;
		private Project.AccentPolje accentPolje4;
		private System.Windows.Forms.Label label1;
	}
}
