////////////////////////////////////////////////////////////
//
//    Библиотека
//    Copyright © 2022-2023 Љубомир Мићић
//    Сва права су заштићена.
//
////////////////////////////////////////////////////////////

using System;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.ComponentModel;
using STR = System.String;
using CEBR = System.Int32;

namespace Project
{
	[DefaultEvent("SelektovanIndeksPromenjen")]
	public class AccentIzbornoPolje : UserControl
	{
		public enum IzbornoPolje_StilBoja {
			Jednostavno,
			Ispunjeno
		}

		private IzbornoPolje_StilBoja izborBoja = IzbornoPolje_StilBoja.Jednostavno;
		private Color boja1 = Color.White;
		private Color boja2 = Color.Gray;
		private CEBR velicinaIvica = 1;

		private ComboBox comboBox;
		private Label label;
		private Button button;
		
		public IzbornoPolje_StilBoja IzborBoja {
			get { return izborBoja; }
			set {
				izborBoja = value;
				if (value == IzbornoPolje_StilBoja.Jednostavno) {
					boja1 = Colors.SvetlijaPozadina;
					boja2 = Colors.AccentColor;
					IzmeniIzgled();
				} else {
					boja1 = Colors.AccentColor;
					boja2 = Colors.SvetlijaPozadina;
					IzmeniIzgled();
				}
				IzmeniIzgled();
			}
		}

		public STR GetItemText(object obj) {
			return this.comboBox.GetItemText(obj);
		}
		
		public CEBR VelicinaIvica {
			get { return velicinaIvica; }
			set {
				velicinaIvica = value;
				this.Padding = new Padding(velicinaIvica);
				AdjustComboBoxDimensions();
			}
		}

		public override Color ForeColor {
			get {
				return base.ForeColor;
			}

			set {
				base.ForeColor = value;
				label.ForeColor = value;
			}
		}

		public override Font Font {
			get {
				return base.Font;
			}

			set {
				base.Font = value;
				label.Font = value;
				comboBox.Font = value;
			}
		}

		public STR Tekst {
			get {
				return label.Text;
			}
			set {
				label.Text = value;
			}
		}

		public ComboBoxStyle DropDownStyle {
			get{ 
				return comboBox.DropDownStyle;
			}
				
			set {
				if (comboBox.DropDownStyle != ComboBoxStyle.Simple) comboBox.DropDownStyle = value;
			}
		}

		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[Localizable(true)]
		[MergableProperty(false)]
		public ComboBox.ObjectCollection Items {
			get {
				return comboBox.Items;
			}
		}
		
		[AttributeProvider(typeof(IListSource))]
		[DefaultValue(null)]
		[RefreshProperties(RefreshProperties.Repaint)]
		public object DataSource
		{
			get
			{
				return comboBox.DataSource;
			}
			set
			{
				comboBox.DataSource = value;
			}
		}
		
		[Browsable(true)]
		[DefaultValue(AutoCompleteMode.None)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public AutoCompleteMode AutoCompleteMode
		{
			get
			{
				return comboBox.AutoCompleteMode;
			}
			set
			{
				comboBox.AutoCompleteMode = value;
			}
		}
		
		[Browsable(true)]
		[DefaultValue(AutoCompleteSource.None)]
		[EditorBrowsable(EditorBrowsableState.Always)]
		public AutoCompleteSource AutoCompleteSource
		{
			get
			{
				return comboBox.AutoCompleteSource;
			}
			set
			{
				comboBox.AutoCompleteSource = value;
			}
		}
		
		[Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", typeof(UITypeEditor))]
		[EditorBrowsable(EditorBrowsableState.Always)]
		[Localizable(true)]
		public AutoCompleteStringCollection AutoCompleteCustomSource
		{
			get
			{
				return comboBox.AutoCompleteCustomSource;
			}
			set
			{
				comboBox.AutoCompleteCustomSource = value;
			}
		}
		
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public CEBR SelectedIndex
		{
			get
			{
				return comboBox.SelectedIndex;
			}
			set
			{
				comboBox.SelectedIndex = value;
			}
		}
		
		[Bindable(true)]
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object SelectedItem
		{
			get
			{
				return comboBox.SelectedItem;
			}
			set
			{
				comboBox.SelectedItem = value;
			}
		}

		public event EventHandler SelektovanIndeksPromenjen;

		private void AdjustComboBoxDimensions()
		{
			comboBox.Width = label.Width;
			comboBox.Location = new Point()
			{
				X = this.Width - this.Padding.Right - comboBox.Width,
				Y = label.Bottom - comboBox.Height
			};
		}

		public AccentIzbornoPolje()
		{
			comboBox = new ComboBox();
			label = new Label();
			button = new Button();
			this.SuspendLayout();
			
			comboBox.BackColor = boja1;
			comboBox.Font = new Font(this.Font.Name, 10F);
			comboBox.ForeColor = Color.Black;
			comboBox.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
			comboBox.TextChanged += new EventHandler(ComboBox_TextChanged);
			
			button.Dock = DockStyle.Right;
			button.FlatStyle = FlatStyle.Flat;
			button.FlatAppearance.BorderSize = 0;
			button.FlatAppearance.MouseOverBackColor = boja1;
			button.FlatAppearance.MouseDownBackColor = boja1;
			button.BackColor = boja1;
			button.Size = new Size(30, 30);
			button.Cursor = Cursors.Hand;
			button.Click += new EventHandler(DugmeClick);
			button.Paint += new PaintEventHandler(DugmePaint);
			
			label.Dock = DockStyle.Fill;
			label.AutoSize = false;
			label.BackColor = boja1;
			label.ForeColor = boja2;
			label.TextAlign = ContentAlignment.MiddleLeft;
			label.Padding = new Padding(8, 0, 0, 0);
			label.Font = new Font(this.Font.Name, 10F);
			label.Click += new EventHandler(KontrolaClick);
			
			this.Controls.Add(button);
			this.Controls.Add(label);
			this.Controls.Add(comboBox);
			this.MinimumSize = new Size(200, 30);
			this.Size = new Size(200, 30);
			this.ForeColor = boja2;
			this.Padding = new Padding(velicinaIvica);
			this.Font = new Font("Segoe UI", 10F);
			base.BackColor = boja2;
			this.DropDownStyle = ComboBoxStyle.DropDownList;
			this.Enter += delegate(object sender, EventArgs e) { 
				this.boja2 = this.IzborBoja == IzbornoPolje_StilBoja.Jednostavno ? Colors.AccentColor : Color.White;
				IzmeniIzgled();
			};
			this.Leave += delegate(object sender, EventArgs e) { 
				this.boja2 = Color.Gray;
				IzmeniIzgled();
			};
			this.ResumeLayout();
			AdjustComboBoxDimensions();
		}

		private void IzmeniIzgled() {
			Invalidate();
			button.FlatAppearance.MouseOverBackColor = boja1;
			button.FlatAppearance.MouseDownBackColor = boja1;
			button.BackColor = boja1;
			label.BackColor = boja1;
			label.ForeColor = boja2;
			this.ForeColor = boja2;
			this.BackColor = boja2;
		}
		
		private void KontrolaClick(object sender, EventArgs e) {
			comboBox.Select();
			if (comboBox.DropDownStyle == ComboBoxStyle.DropDownList) comboBox.DroppedDown = true;
		}

		private void DugmeClick(object sender, EventArgs e) {
			comboBox.Select();
			comboBox.DroppedDown = true;
		}

		private void DugmePaint(object sender, PaintEventArgs e) {
			CEBR sirinaIkonice = 14;
			CEBR visinaIkonice = 6;
			var rectIcon = new Rectangle((button.Width - sirinaIkonice) / 2, (button.Height - visinaIkonice) / 2, sirinaIkonice, visinaIkonice);
			Graphics strelica = e.Graphics;

			using (GraphicsPath path = new GraphicsPath())
			using (Pen pen = new Pen(boja2, 2)) {
				strelica.SmoothingMode = SmoothingMode.AntiAlias;
				path.AddLine(rectIcon.X, rectIcon.Y, rectIcon.X + (sirinaIkonice / 2), rectIcon.Bottom);
				path.AddLine(rectIcon.X + (sirinaIkonice / 2), rectIcon.Bottom, rectIcon.Right, rectIcon.Y);
				strelica.DrawPath(pen, path);
			}
		}

		private void ComboBox_TextChanged(object sender, EventArgs e) {
			label.Text = comboBox.Text;
		}

		private void ComboBox_SelectedIndexChanged(object sender, EventArgs e) {
			if (SelektovanIndeksPromenjen != null) SelektovanIndeksPromenjen.Invoke(sender, e);
			label.Text = comboBox.Text;
		}
	}
}
