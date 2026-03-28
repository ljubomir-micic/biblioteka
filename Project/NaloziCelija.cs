////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using STR = System.String;
using CEBR = System.Int32;
using TAC = System.Boolean;

namespace Project
{
	public class NaloziCelija : UserControl, IObjekatUI
	{
		private CEBR _id;
		private Project.DugmeKrug dugmeKrug1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private TAC jeMisNa;

		public CEBR id {
			get {
				return _id;
			} set {
				_id = value;
			}
		}
		
		public STR ImePrezime {
			get {
				return this.label1.Text;
			} set {
				this.label1.Text = value;
			}
		}
		
		public CEBR GodRodjenja {
			get {
				return CEBR.Parse(this.label2.Text);
			} set {
				this.label2.Text = "" + value;
			}
		}
		
		public event EventHandler CelijaSeBrise = delegate { };
		
		public NaloziCelija(Korisnik korisnik) {
			this.id = korisnik.preuzmiID();
			ComponentResourceManager resources = new ComponentResourceManager(typeof(Podesavanja));
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.dugmeKrug1 = new Project.DugmeKrug();
			((ISupportInitialize)(this.pictureBox1)).BeginInit();
			
			this.SuspendLayout();
			
			this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("slikaProfila.Image")));
			this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureBox1.Location = new System.Drawing.Point(14, 9);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(35, 35);
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.MouseEnter += delegate {
				this.jeMisNa = true;
				Invalidate();
			};
			
			this.label1.AutoSize = true;
			this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
			this.label1.Location = new System.Drawing.Point(56, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(215, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.MouseEnter += delegate {
				this.jeMisNa = true;
				Invalidate();
			};
			
			this.label2.AutoSize = true;
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
			this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(56, 31);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(131, 13);
			this.label2.TabIndex = 2;
			this.label2.Text = "label2";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.MouseEnter += delegate {
				this.jeMisNa = true;
				Invalidate();
			};
			
			this.dugmeKrug1.BackColor = System.Drawing.SystemColors.Control;
			this.dugmeKrug1.Cursor = Cursors.Hand;
			this.dugmeKrug1.Enabled = Podesavanja.korisnik.preuzmiID() != this.id;
			this.dugmeKrug1.Location = new System.Drawing.Point(2, 2);
			this.dugmeKrug1.Name = "dugmeKrug1";
			this.dugmeKrug1.Pozadina = System.Drawing.Color.FromArgb(((CEBR)(((byte)(240)))), ((CEBR)(((byte)(40)))), ((CEBR)(((byte)(40)))));
			this.dugmeKrug1.Size = new System.Drawing.Size(24, 23);
			this.dugmeKrug1.TabIndex = 3;
			this.dugmeKrug1.Text = "dugmeKrug1";
			this.dugmeKrug1.UseVisualStyleBackColor = false;
			this.dugmeKrug1.Visible = Podesavanja.korisnik.preuzmiID() != this.id;
			this.dugmeKrug1.Click += new System.EventHandler(this.DugmeKrug1Click);
			this.dugmeKrug1.MouseEnter += delegate {
				this.jeMisNa = true;
				Invalidate();
			};
			
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dugmeKrug1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Name = "NaloziCelija";
			this.Size = new System.Drawing.Size(284, 52);
			this.MouseEnter += delegate {
				this.jeMisNa = true;
				Invalidate();
			};
			this.MouseLeave += delegate {
				this.jeMisNa = false;
				Invalidate();
			};
			this.Paint += delegate (object sender, PaintEventArgs e) {
				if (this.jeMisNa) e.Graphics.DrawPath(new Pen(Colors.AccentColor), Oblik.ZaobljeniPravougaonik(new Rectangle(new Point(0, 0), new Size(this.Width - 1, this.Height - 1)), 5));
			};
			((ISupportInitialize)(this.pictureBox1)).EndInit();
			
			this.ResumeLayout(false);
			
			this.BackColor = Colors.TamnijaPozadina;
			ImePrezime = (korisnik.preuzmiIme() + " " + korisnik.preuzmiPrezime());
			GodRodjenja = korisnik.preuzmiGodinuRodjenja();
			{
				GraphicsPath gp = new GraphicsPath();
				gp.AddEllipse(new Rectangle(0, 0, pictureBox1.Width - 1, pictureBox1.Height - 1));
				gp.CloseFigure();
				this.pictureBox1.Region = new Region(gp);
			}
			{
				GraphicsPath gp = new GraphicsPath();
				gp.AddPath(Oblik.ZaobljeniPravougaonik(new Rectangle(new Point(0, 0), new Size(ClientRectangle.Width, ClientRectangle.Height)), 3), true);
				gp.CloseFigure();
				this.Region = new Region(gp);
			}
		}
		
		void DugmeKrug1Click(object sender, EventArgs e) {
			CelijaSeBrise.Invoke(this, new EventArgs());
		}
	}
}
