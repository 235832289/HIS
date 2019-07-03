using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace HRP
{
	/// <summary>
	/// Summary description for frmLabel.
	/// </summary>
	public class frmLabel : iCare.iCareBaseForm.frmBaseForm
	{
		public System.Windows.Forms.GroupBox Tied;
		public System.Windows.Forms.RadioButton Control;
		public System.Windows.Forms.RadioButton ImageCell;
		public System.Windows.Forms.RadioButton ImageScale;
		public System.Windows.Forms.CheckBox Transparent;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.PictureBox BackColour;
		public System.Windows.Forms.Button OK;
		public System.Windows.Forms.TextBox LineWidth;
		public System.Windows.Forms.PictureBox ForeColour;
		public System.Windows.Forms.GroupBox AlignmentBox;
		public System.Windows.Forms.RadioButton _Alignment_2;
		public System.Windows.Forms.RadioButton _Alignment_1;
		public System.Windows.Forms.RadioButton _Alignment_0;
		public System.Windows.Forms.ToolTip ToolTip1;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.GroupBox LabelTypeBox;
		public System.Windows.Forms.RadioButton _LabelType_5;
		public System.Windows.Forms.RadioButton _LabelType_1;
		public System.Windows.Forms.RadioButton _LabelType_2;
		public System.Windows.Forms.RadioButton _LabelType_4;
		public System.Windows.Forms.RadioButton _LabelType_3;
		public System.Windows.Forms.RadioButton _LabelType_0;
		public System.Windows.Forms.Label Label4;
		public System.Windows.Forms.TextBox FontDisplay;
		public System.Windows.Forms.Label Label1;
		private System.Windows.Forms.ColorDialog colorDialog1;
		private System.ComponentModel.IContainer components;

		public frmLabel()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLabel));
			this.Tied = new System.Windows.Forms.GroupBox();
			this.Control = new System.Windows.Forms.RadioButton();
			this.ImageCell = new System.Windows.Forms.RadioButton();
			this.ImageScale = new System.Windows.Forms.RadioButton();
			this.Transparent = new System.Windows.Forms.CheckBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.BackColour = new System.Windows.Forms.PictureBox();
			this.OK = new System.Windows.Forms.Button();
			this.LineWidth = new System.Windows.Forms.TextBox();
			this.ForeColour = new System.Windows.Forms.PictureBox();
			this.AlignmentBox = new System.Windows.Forms.GroupBox();
			this._Alignment_2 = new System.Windows.Forms.RadioButton();
			this._Alignment_1 = new System.Windows.Forms.RadioButton();
			this._Alignment_0 = new System.Windows.Forms.RadioButton();
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.Label2 = new System.Windows.Forms.Label();
			this.LabelTypeBox = new System.Windows.Forms.GroupBox();
			this._LabelType_5 = new System.Windows.Forms.RadioButton();
			this._LabelType_1 = new System.Windows.Forms.RadioButton();
			this._LabelType_2 = new System.Windows.Forms.RadioButton();
			this._LabelType_4 = new System.Windows.Forms.RadioButton();
			this._LabelType_3 = new System.Windows.Forms.RadioButton();
			this._LabelType_0 = new System.Windows.Forms.RadioButton();
			this.Label4 = new System.Windows.Forms.Label();
			this.FontDisplay = new System.Windows.Forms.TextBox();
			this.Label1 = new System.Windows.Forms.Label();
			this.colorDialog1 = new System.Windows.Forms.ColorDialog();
			this.Tied.SuspendLayout();
			this.AlignmentBox.SuspendLayout();
			this.LabelTypeBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// Tied
			// 
			this.Tied.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.Tied.Controls.AddRange(new System.Windows.Forms.Control[] {
																			   this.Control,
																			   this.ImageCell,
																			   this.ImageScale});
			this.Tied.ForeColor = System.Drawing.Color.White;
			this.Tied.Location = new System.Drawing.Point(328, 136);
			this.Tied.Name = "Tied";
			this.Tied.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Tied.Size = new System.Drawing.Size(128, 104);
			this.Tied.TabIndex = 32;
			this.Tied.TabStop = false;
			this.Tied.Text = "约束到";
			// 
			// Control
			// 
			this.Control.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.Control.Cursor = System.Windows.Forms.Cursors.Default;
			this.Control.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Control.ForeColor = System.Drawing.Color.White;
			this.Control.Location = new System.Drawing.Point(20, 80);
			this.Control.Name = "Control";
			this.Control.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Control.Size = new System.Drawing.Size(94, 19);
			this.Control.TabIndex = 23;
			this.Control.TabStop = true;
			this.Control.Text = "控制";
			// 
			// ImageCell
			// 
			this.ImageCell.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ImageCell.Cursor = System.Windows.Forms.Cursors.Default;
			this.ImageCell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ImageCell.ForeColor = System.Drawing.Color.White;
			this.ImageCell.Location = new System.Drawing.Point(20, 52);
			this.ImageCell.Name = "ImageCell";
			this.ImageCell.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ImageCell.Size = new System.Drawing.Size(94, 24);
			this.ImageCell.TabIndex = 22;
			this.ImageCell.TabStop = true;
			this.ImageCell.Text = "图象单元";
			// 
			// ImageScale
			// 
			this.ImageScale.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ImageScale.Checked = true;
			this.ImageScale.Cursor = System.Windows.Forms.Cursors.Default;
			this.ImageScale.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.ImageScale.ForeColor = System.Drawing.Color.White;
			this.ImageScale.Location = new System.Drawing.Point(20, 24);
			this.ImageScale.Name = "ImageScale";
			this.ImageScale.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ImageScale.Size = new System.Drawing.Size(92, 24);
			this.ImageScale.TabIndex = 21;
			this.ImageScale.TabStop = true;
			this.ImageScale.Text = "图象";
			// 
			// Transparent
			// 
			this.Transparent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.Transparent.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.Transparent.Checked = true;
			this.Transparent.CheckState = System.Windows.Forms.CheckState.Checked;
			this.Transparent.Cursor = System.Windows.Forms.Cursors.Default;
			this.Transparent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Transparent.ForeColor = System.Drawing.Color.White;
			this.Transparent.Location = new System.Drawing.Point(16, 136);
			this.Transparent.Name = "Transparent";
			this.Transparent.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Transparent.Size = new System.Drawing.Size(56, 24);
			this.Transparent.TabIndex = 25;
			this.Transparent.Text = "透明";
			// 
			// Label3
			// 
			this.Label3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label3.ForeColor = System.Drawing.Color.White;
			this.Label3.Location = new System.Drawing.Point(192, 136);
			this.Label3.Name = "Label3";
			this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label3.Size = new System.Drawing.Size(40, 20);
			this.Label3.TabIndex = 34;
			this.Label3.Text = "线宽";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// BackColour
			// 
			this.BackColour.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(64)), ((System.Byte)(64)));
			this.BackColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.BackColour.Cursor = System.Windows.Forms.Cursors.Default;
			this.BackColour.ForeColor = System.Drawing.SystemColors.ControlText;
			this.BackColour.Location = new System.Drawing.Point(248, 168);
			this.BackColour.Name = "BackColour";
			this.BackColour.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.BackColour.Size = new System.Drawing.Size(32, 29);
			this.BackColour.TabIndex = 29;
			this.BackColour.TabStop = false;
			this.BackColour.Click += new System.EventHandler(this.BackColour_Click);
			// 
			// OK
			// 
			this.OK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.OK.Cursor = System.Windows.Forms.Cursors.Hand;
			this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.OK.ForeColor = System.Drawing.Color.White;
			this.OK.Location = new System.Drawing.Point(360, 248);
			this.OK.Name = "OK";
			this.OK.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.OK.Size = new System.Drawing.Size(93, 29);
			this.OK.TabIndex = 35;
			this.OK.Text = "确定";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// LineWidth
			// 
			this.LineWidth.AcceptsReturn = true;
			this.LineWidth.AutoSize = false;
			this.LineWidth.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.LineWidth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.LineWidth.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.LineWidth.ForeColor = System.Drawing.Color.White;
			this.LineWidth.Location = new System.Drawing.Point(248, 136);
			this.LineWidth.MaxLength = 0;
			this.LineWidth.Name = "LineWidth";
			this.LineWidth.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LineWidth.Size = new System.Drawing.Size(32, 22);
			this.LineWidth.TabIndex = 33;
			this.LineWidth.Text = "1";
			// 
			// ForeColour
			// 
			this.ForeColour.BackColor = System.Drawing.Color.Red;
			this.ForeColour.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ForeColour.Cursor = System.Windows.Forms.Cursors.Default;
			this.ForeColour.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ForeColour.Location = new System.Drawing.Point(104, 168);
			this.ForeColour.Name = "ForeColour";
			this.ForeColour.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ForeColour.Size = new System.Drawing.Size(32, 29);
			this.ForeColour.TabIndex = 28;
			this.ForeColour.TabStop = false;
			this.ForeColour.Click += new System.EventHandler(this.ForeColour_Click);
			// 
			// AlignmentBox
			// 
			this.AlignmentBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.AlignmentBox.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this._Alignment_2,
																					   this._Alignment_1,
																					   this._Alignment_0});
			this.AlignmentBox.ForeColor = System.Drawing.Color.White;
			this.AlignmentBox.Location = new System.Drawing.Point(328, 8);
			this.AlignmentBox.Name = "AlignmentBox";
			this.AlignmentBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.AlignmentBox.Size = new System.Drawing.Size(135, 112);
			this.AlignmentBox.TabIndex = 27;
			this.AlignmentBox.TabStop = false;
			this.AlignmentBox.Tag = "0";
			this.AlignmentBox.Text = "文本对齐";
			// 
			// _Alignment_2
			// 
			this._Alignment_2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this._Alignment_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._Alignment_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._Alignment_2.ForeColor = System.Drawing.Color.White;
			this._Alignment_2.Location = new System.Drawing.Point(24, 79);
			this._Alignment_2.Name = "_Alignment_2";
			this._Alignment_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Alignment_2.Size = new System.Drawing.Size(73, 24);
			this._Alignment_2.TabIndex = 11;
			this._Alignment_2.TabStop = true;
			this._Alignment_2.Tag = "2";
			this._Alignment_2.Text = "右对齐";
			this._Alignment_2.Click += new System.EventHandler(this._Alignment_0_Click);
			// 
			// _Alignment_1
			// 
			this._Alignment_1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this._Alignment_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._Alignment_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._Alignment_1.ForeColor = System.Drawing.Color.White;
			this._Alignment_1.Location = new System.Drawing.Point(24, 53);
			this._Alignment_1.Name = "_Alignment_1";
			this._Alignment_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Alignment_1.Size = new System.Drawing.Size(80, 21);
			this._Alignment_1.TabIndex = 10;
			this._Alignment_1.TabStop = true;
			this._Alignment_1.Tag = "1";
			this._Alignment_1.Text = "中间对齐";
			this._Alignment_1.Click += new System.EventHandler(this._Alignment_0_Click);
			// 
			// _Alignment_0
			// 
			this._Alignment_0.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this._Alignment_0.Checked = true;
			this._Alignment_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._Alignment_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._Alignment_0.ForeColor = System.Drawing.Color.White;
			this._Alignment_0.Location = new System.Drawing.Point(24, 24);
			this._Alignment_0.Name = "_Alignment_0";
			this._Alignment_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._Alignment_0.Size = new System.Drawing.Size(80, 24);
			this._Alignment_0.TabIndex = 9;
			this._Alignment_0.TabStop = true;
			this._Alignment_0.Tag = "0";
			this._Alignment_0.Text = "左对齐";
			this._Alignment_0.Click += new System.EventHandler(this._Alignment_0_Click);
			// 
			// Label2
			// 
			this.Label2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.ForeColor = System.Drawing.Color.White;
			this.Label2.Location = new System.Drawing.Point(176, 176);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(56, 20);
			this.Label2.TabIndex = 31;
			this.Label2.Text = "背景色";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// LabelTypeBox
			// 
			this.LabelTypeBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.LabelTypeBox.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this._LabelType_5,
																					   this._LabelType_1,
																					   this._LabelType_2,
																					   this._LabelType_4,
																					   this._LabelType_3,
																					   this._LabelType_0});
			this.LabelTypeBox.ForeColor = System.Drawing.Color.White;
			this.LabelTypeBox.Location = new System.Drawing.Point(16, 8);
			this.LabelTypeBox.Name = "LabelTypeBox";
			this.LabelTypeBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.LabelTypeBox.Size = new System.Drawing.Size(268, 112);
			this.LabelTypeBox.TabIndex = 26;
			this.LabelTypeBox.TabStop = false;
			this.LabelTypeBox.Tag = "0";
			this.LabelTypeBox.Text = "标签类型";
			// 
			// _LabelType_5
			// 
			this._LabelType_5.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this._LabelType_5.Cursor = System.Windows.Forms.Cursors.Default;
			this._LabelType_5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._LabelType_5.ForeColor = System.Drawing.Color.White;
			this._LabelType_5.Location = new System.Drawing.Point(154, 80);
			this._LabelType_5.Name = "_LabelType_5";
			this._LabelType_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LabelType_5.Size = new System.Drawing.Size(93, 24);
			this._LabelType_5.TabIndex = 7;
			this._LabelType_5.TabStop = true;
			this._LabelType_5.Tag = "5";
			this._LabelType_5.Text = "多边形";
			this._LabelType_5.Click += new System.EventHandler(this._LabelType_5_Click);
			// 
			// _LabelType_1
			// 
			this._LabelType_1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this._LabelType_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._LabelType_1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._LabelType_1.ForeColor = System.Drawing.Color.White;
			this._LabelType_1.Location = new System.Drawing.Point(154, 52);
			this._LabelType_1.Name = "_LabelType_1";
			this._LabelType_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LabelType_1.Size = new System.Drawing.Size(93, 24);
			this._LabelType_1.TabIndex = 6;
			this._LabelType_1.TabStop = true;
			this._LabelType_1.Tag = "1";
			this._LabelType_1.Text = "椭圆";
			this._LabelType_1.Click += new System.EventHandler(this._LabelType_5_Click);
			// 
			// _LabelType_2
			// 
			this._LabelType_2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this._LabelType_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._LabelType_2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._LabelType_2.ForeColor = System.Drawing.Color.White;
			this._LabelType_2.Location = new System.Drawing.Point(154, 24);
			this._LabelType_2.Name = "_LabelType_2";
			this._LabelType_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LabelType_2.Size = new System.Drawing.Size(93, 24);
			this._LabelType_2.TabIndex = 5;
			this._LabelType_2.TabStop = true;
			this._LabelType_2.Tag = "2";
			this._LabelType_2.Text = "矩形";
			this._LabelType_2.Click += new System.EventHandler(this._LabelType_5_Click);
			// 
			// _LabelType_4
			// 
			this._LabelType_4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this._LabelType_4.Cursor = System.Windows.Forms.Cursors.Default;
			this._LabelType_4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._LabelType_4.ForeColor = System.Drawing.Color.White;
			this._LabelType_4.Location = new System.Drawing.Point(20, 80);
			this._LabelType_4.Name = "_LabelType_4";
			this._LabelType_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LabelType_4.Size = new System.Drawing.Size(94, 24);
			this._LabelType_4.TabIndex = 4;
			this._LabelType_4.TabStop = true;
			this._LabelType_4.Tag = "4";
			this._LabelType_4.Text = "手画线";
			this._LabelType_4.Click += new System.EventHandler(this._LabelType_5_Click);
			// 
			// _LabelType_3
			// 
			this._LabelType_3.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this._LabelType_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._LabelType_3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._LabelType_3.ForeColor = System.Drawing.Color.White;
			this._LabelType_3.Location = new System.Drawing.Point(20, 52);
			this._LabelType_3.Name = "_LabelType_3";
			this._LabelType_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LabelType_3.Size = new System.Drawing.Size(94, 24);
			this._LabelType_3.TabIndex = 3;
			this._LabelType_3.TabStop = true;
			this._LabelType_3.Tag = "3";
			this._LabelType_3.Text = "直线";
			this._LabelType_3.Click += new System.EventHandler(this._LabelType_5_Click);
			// 
			// _LabelType_0
			// 
			this._LabelType_0.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this._LabelType_0.Checked = true;
			this._LabelType_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._LabelType_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this._LabelType_0.ForeColor = System.Drawing.Color.White;
			this._LabelType_0.Location = new System.Drawing.Point(20, 24);
			this._LabelType_0.Name = "_LabelType_0";
			this._LabelType_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._LabelType_0.Size = new System.Drawing.Size(94, 24);
			this._LabelType_0.TabIndex = 2;
			this._LabelType_0.TabStop = true;
			this._LabelType_0.Tag = "0";
			this._LabelType_0.Text = "文字";
			this._LabelType_0.Click += new System.EventHandler(this._LabelType_5_Click);
			// 
			// Label4
			// 
			this.Label4.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label4.ForeColor = System.Drawing.Color.White;
			this.Label4.Location = new System.Drawing.Point(16, 208);
			this.Label4.Name = "Label4";
			this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label4.Size = new System.Drawing.Size(258, 16);
			this.Label4.TabIndex = 37;
			this.Label4.Text = "单击下面的区域来改变字体：";
			// 
			// FontDisplay
			// 
			this.FontDisplay.AcceptsReturn = true;
			this.FontDisplay.AutoSize = false;
			this.FontDisplay.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.FontDisplay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.FontDisplay.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.FontDisplay.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FontDisplay.ForeColor = System.Drawing.Color.White;
			this.FontDisplay.Location = new System.Drawing.Point(16, 232);
			this.FontDisplay.MaxLength = 0;
			this.FontDisplay.Name = "FontDisplay";
			this.FontDisplay.ReadOnly = true;
			this.FontDisplay.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.FontDisplay.Size = new System.Drawing.Size(258, 48);
			this.FontDisplay.TabIndex = 36;
			this.FontDisplay.Text = "Arial";
			// 
			// Label1
			// 
			this.Label1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.ForeColor = System.Drawing.Color.White;
			this.Label1.Location = new System.Drawing.Point(40, 176);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(48, 20);
			this.Label1.TabIndex = 30;
			this.Label1.Text = "前景色";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frmLabel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.ClientSize = new System.Drawing.Size(504, 293);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Transparent,
																		  this.Label3,
																		  this.BackColour,
																		  this.OK,
																		  this.LineWidth,
																		  this.ForeColour,
																		  this.AlignmentBox,
																		  this.Label2,
																		  this.LabelTypeBox,
																		  this.Label4,
																		  this.FontDisplay,
																		  this.Label1,
																		  this.Tied});
			this.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmLabel";
			this.Text = "标签";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmLabel_Closing);
			this.Tied.ResumeLayout(false);
			this.AlignmentBox.ResumeLayout(false);
			this.LabelTypeBox.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void OK_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.Hide();
			}
			catch{}
		}

		private void _LabelType_5_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.LabelTypeBox.Tag = int.Parse(((RadioButton)sender).Tag.ToString());
			}
			catch{}
		}

		private void _Alignment_0_Click(object sender, System.EventArgs e)
		{
			try
			{
				this.AlignmentBox.Tag = int.Parse(((RadioButton)sender).Tag.ToString());
			}
			catch{}
		}
//swh-2002-6-18
		private void ForeColour_Click(object sender, System.EventArgs e)
		{
			try
			{
				colorDialog1.Color=ForeColour.BackColor;
				colorDialog1.FullOpen=false;
				colorDialog1.ShowDialog();	
				ForeColour.BackColor=colorDialog1.Color;
				/*  Dialog.Color = ForeColour.BackColor;
				  Dialog.Flags = cdCClFullOpen & cdlCCRGBInit
				  Dialog.ShowColor
				  ForeColour.BackColor = Dialog.Color
				  */
			}
			catch{}
		
		}

		private void BackColour_Click(object sender, System.EventArgs e)
		{	
			try
			{
				colorDialog1.Color=BackColour.BackColor;
				colorDialog1.FullOpen=false;
				colorDialog1.ShowDialog();	
				BackColour.BackColor=colorDialog1.Color;
			}
			catch{}
		
		}

		private void frmLabel_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				e.Cancel=true;
				this.Hide();
			}catch{}
		 }
	
	}
}
