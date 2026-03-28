////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

namespace Project
{
	partial class Saveti
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Saveti));
			this.accentDugme1 = new Project.AccentDugme();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			this.SuspendLayout();
			// 
			// accentDugme1
			// 
			this.accentDugme1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.accentDugme1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(122)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
			this.accentDugme1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.accentDugme1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.accentDugme1.ForeColor = System.Drawing.Color.White;
			this.accentDugme1.JeSelektovan = false;
			this.accentDugme1.KursorNaDugmetu = false;
			this.accentDugme1.Location = new System.Drawing.Point(265, 363);
			this.accentDugme1.Name = "accentDugme1";
			this.accentDugme1.Size = new System.Drawing.Size(125, 32);
			this.accentDugme1.TabIndex = 0;
			this.accentDugme1.Text = "Настави";
			this.accentDugme1.UseVisualStyleBackColor = false;
			this.accentDugme1.Click += new System.EventHandler(this.AccentDugme1Click);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.label1.Font = new System.Drawing.Font("Segoe UI Black", 33F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(2, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(650, 70);
			this.label1.TabIndex = 1;
			this.label1.Text = "Шта је ново?";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(70, 144);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(82, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(70, 200);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(82, 50);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 3;
			this.pictureBox2.TabStop = false;
			// 
			// pictureBox3
			// 
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(70, 256);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(82, 50);
			this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox3.TabIndex = 4;
			this.pictureBox3.TabStop = false;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.label2.Location = new System.Drawing.Point(192, 144);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(393, 50);
			this.label2.TabIndex = 5;
			this.label2.Text = "Додајте књиге, ауторе и чланове библиотеке ради лакшег одржавања литературе.";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.label3.Location = new System.Drawing.Point(192, 197);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(393, 56);
			this.label3.TabIndex = 6;
			this.label3.Text = "Притиском на десни тастер миша (када се курсор налази на панелу на коме се врши и" +
			"каква евиденција података) приказује се мени са опцијама, попут опције за додава" +
			"ње нових података или брисање старих.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
			this.label4.Location = new System.Drawing.Point(192, 256);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(393, 50);
			this.label4.TabIndex = 7;
			this.label4.Text = "У подешавањима, изаберите ниво разумевања библиотекарства како бисте имали присту" +
			"п напреднијим опцијама попут многих УДК бројева.";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.ForeColor = System.Drawing.SystemColors.AppWorkspace;
			this.label5.Location = new System.Drawing.Point(12, 99);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(631, 23);
			this.label5.TabIndex = 8;
			this.label5.Tag = "ZakljucanaPrednjaBoja";
			this.label5.Text = "Верзија:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Saveti
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(655, 422);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox3);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.accentDugme1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Saveti";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Saveti";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label1;
		private Project.AccentDugme accentDugme1;
	}
}
