using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// frmEMRBaseForm 的摘要说明。
	/// 电子病历基本窗体，实现公用基本方法
	/// 继承此窗体，界面上公用窗体头部尽量不作改动，保持整洁统一；
	/// </summary>
	public class frmEMRBaseForm : System.Windows.Forms.Form
	{
		#region 系统
		protected System.Windows.Forms.Label lblDept;
		protected System.Windows.Forms.Label lblAreaTitle;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboDept;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboArea;
		protected System.Windows.Forms.Label lblAgeTitle;
		protected System.Windows.Forms.Label lblSexTitle;
		protected System.Windows.Forms.Label lblSex;
		protected System.Windows.Forms.Label lblAge;
		protected System.Windows.Forms.Label lblInHospitalNoTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtInPatientID;
		protected System.Windows.Forms.Label lblBedNoTitle;
		protected System.Windows.Forms.Label lblNameTitle;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtPatientName;
		protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboBed;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox picLogo;
		protected System.Windows.Forms.Label lblInpatientdate;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;


		/// <summary>
		/// 清理所有正在使用的资源。
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

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmEMRBaseForm));
			this.lblDept = new System.Windows.Forms.Label();
			this.lblAreaTitle = new System.Windows.Forms.Label();
			this.m_cboDept = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.m_cboArea = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.lblAgeTitle = new System.Windows.Forms.Label();
			this.lblSexTitle = new System.Windows.Forms.Label();
			this.lblSex = new System.Windows.Forms.Label();
			this.lblAge = new System.Windows.Forms.Label();
			this.lblInHospitalNoTitle = new System.Windows.Forms.Label();
			this.txtInPatientID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblBedNoTitle = new System.Windows.Forms.Label();
			this.lblNameTitle = new System.Windows.Forms.Label();
			this.m_txtPatientName = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.lblInpatientdate = new System.Windows.Forms.Label();
			this.m_cboBed = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.picLogo = new System.Windows.Forms.PictureBox();
			this.SuspendLayout();
			// 
			// lblDept
			// 
			this.lblDept.AutoSize = true;
			this.lblDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblDept.ForeColor = System.Drawing.Color.Black;
			this.lblDept.Location = new System.Drawing.Point(64, 12);
			this.lblDept.Name = "lblDept";
			this.lblDept.Size = new System.Drawing.Size(70, 19);
			this.lblDept.TabIndex = 0;
			this.lblDept.Text = "科    室:";
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.AutoSize = true;
			this.lblAreaTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAreaTitle.ForeColor = System.Drawing.Color.Black;
			this.lblAreaTitle.Location = new System.Drawing.Point(364, 12);
			this.lblAreaTitle.Name = "lblAreaTitle";
			this.lblAreaTitle.Size = new System.Drawing.Size(56, 19);
			this.lblAreaTitle.TabIndex = 1;
			this.lblAreaTitle.Text = "病  区:";
			// 
			// m_cboDept
			// 
			this.m_cboDept.AccessibleName = "NoDefault";
			this.m_cboDept.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.m_cboDept.BorderColor = System.Drawing.Color.Black;
			this.m_cboDept.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboDept.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboDept.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboDept.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboDept.ForeColor = System.Drawing.Color.Black;
			this.m_cboDept.ListBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboDept.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboDept.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboDept.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboDept.Location = new System.Drawing.Point(136, 8);
			this.m_cboDept.m_BlnEnableItemEventMenu = false;
			this.m_cboDept.Name = "m_cboDept";
			this.m_cboDept.SelectedIndex = -1;
			this.m_cboDept.SelectedItem = null;
			this.m_cboDept.SelectionStart = -1;
			this.m_cboDept.Size = new System.Drawing.Size(212, 23);
			this.m_cboDept.TabIndex = 100;
			this.m_cboDept.TabStop = false;
			this.m_cboDept.TextBackColor = System.Drawing.Color.White;
			this.m_cboDept.TextForeColor = System.Drawing.Color.Black;
			// 
			// m_cboArea
			// 
			this.m_cboArea.AccessibleName = "NoDefault";
			this.m_cboArea.BackColor = System.Drawing.Color.White;
			this.m_cboArea.BorderColor = System.Drawing.Color.Black;
			this.m_cboArea.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboArea.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboArea.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboArea.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboArea.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboArea.ForeColor = System.Drawing.Color.Black;
			this.m_cboArea.ListBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboArea.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboArea.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboArea.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboArea.Location = new System.Drawing.Point(420, 8);
			this.m_cboArea.m_BlnEnableItemEventMenu = false;
			this.m_cboArea.Name = "m_cboArea";
			this.m_cboArea.SelectedIndex = -1;
			this.m_cboArea.SelectedItem = null;
			this.m_cboArea.SelectionStart = -1;
			this.m_cboArea.Size = new System.Drawing.Size(144, 23);
			this.m_cboArea.TabIndex = 200;
			this.m_cboArea.TabStop = false;
			this.m_cboArea.TextBackColor = System.Drawing.Color.White;
			this.m_cboArea.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.AutoSize = true;
			this.lblAgeTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAgeTitle.ForeColor = System.Drawing.Color.Black;
			this.lblAgeTitle.Location = new System.Drawing.Point(740, 40);
			this.lblAgeTitle.Name = "lblAgeTitle";
			this.lblAgeTitle.Size = new System.Drawing.Size(41, 19);
			this.lblAgeTitle.TabIndex = 8;
			this.lblAgeTitle.Text = "年龄:";
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.AutoSize = true;
			this.lblSexTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSexTitle.ForeColor = System.Drawing.Color.Black;
			this.lblSexTitle.Location = new System.Drawing.Point(740, 12);
			this.lblSexTitle.Name = "lblSexTitle";
			this.lblSexTitle.Size = new System.Drawing.Size(41, 19);
			this.lblSexTitle.TabIndex = 3;
			this.lblSexTitle.Text = "性别:";
			// 
			// lblSex
			// 
			this.lblSex.BackColor = System.Drawing.Color.Transparent;
			this.lblSex.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSex.ForeColor = System.Drawing.Color.Black;
			this.lblSex.Location = new System.Drawing.Point(784, 12);
			this.lblSex.Name = "lblSex";
			this.lblSex.Size = new System.Drawing.Size(48, 19);
			this.lblSex.TabIndex = 4;
			// 
			// lblAge
			// 
			this.lblAge.BackColor = System.Drawing.Color.Transparent;
			this.lblAge.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblAge.ForeColor = System.Drawing.Color.Black;
			this.lblAge.Location = new System.Drawing.Point(784, 40);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(48, 19);
			this.lblAge.TabIndex = 9;
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.AutoSize = true;
			this.lblInHospitalNoTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInHospitalNoTitle.ForeColor = System.Drawing.Color.Black;
			this.lblInHospitalNoTitle.Location = new System.Drawing.Point(364, 40);
			this.lblInHospitalNoTitle.Name = "lblInHospitalNoTitle";
			this.lblInHospitalNoTitle.Size = new System.Drawing.Size(56, 19);
			this.lblInHospitalNoTitle.TabIndex = 6;
			this.lblInHospitalNoTitle.Text = "住院号:";
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.AccessibleName = "NoDefault";
			this.txtInPatientID.AutoSize = false;
			this.txtInPatientID.BackColor = System.Drawing.Color.White;
			this.txtInPatientID.BorderColor = System.Drawing.Color.Transparent;
			this.txtInPatientID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtInPatientID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtInPatientID.ForeColor = System.Drawing.Color.Black;
			this.txtInPatientID.Location = new System.Drawing.Point(420, 36);
			this.txtInPatientID.MaxLength = 20;
			this.txtInPatientID.Name = "txtInPatientID";
			this.txtInPatientID.Size = new System.Drawing.Size(144, 21);
			this.txtInPatientID.TabIndex = 500;
			this.txtInPatientID.Text = "";
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.AutoSize = true;
			this.lblBedNoTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblBedNoTitle.ForeColor = System.Drawing.Color.Black;
			this.lblBedNoTitle.Location = new System.Drawing.Point(580, 12);
			this.lblBedNoTitle.Name = "lblBedNoTitle";
			this.lblBedNoTitle.Size = new System.Drawing.Size(41, 19);
			this.lblBedNoTitle.TabIndex = 2;
			this.lblBedNoTitle.Text = "床号:";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.AutoSize = true;
			this.lblNameTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblNameTitle.ForeColor = System.Drawing.Color.Black;
			this.lblNameTitle.Location = new System.Drawing.Point(580, 40);
			this.lblNameTitle.Name = "lblNameTitle";
			this.lblNameTitle.Size = new System.Drawing.Size(41, 19);
			this.lblNameTitle.TabIndex = 7;
			this.lblNameTitle.Text = "姓名:";
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.AccessibleName = "NoDefault";
			this.m_txtPatientName.AutoSize = false;
			this.m_txtPatientName.BackColor = System.Drawing.Color.White;
			this.m_txtPatientName.BorderColor = System.Drawing.Color.Transparent;
			this.m_txtPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtPatientName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtPatientName.ForeColor = System.Drawing.Color.Black;
			this.m_txtPatientName.Location = new System.Drawing.Point(624, 36);
			this.m_txtPatientName.MaxLength = 50;
			this.m_txtPatientName.Name = "m_txtPatientName";
			this.m_txtPatientName.Size = new System.Drawing.Size(108, 21);
			this.m_txtPatientName.TabIndex = 600;
			this.m_txtPatientName.Text = "";
			// 
			// m_dtpCreateDate
			// 
			this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Black;
			this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
			this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
			this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtpCreateDate.Location = new System.Drawing.Point(136, 36);
			this.m_dtpCreateDate.m_BlnOnlyTime = false;
			this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
			this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.m_dtpCreateDate.Name = "m_dtpCreateDate";
			this.m_dtpCreateDate.ReadOnly = false;
			this.m_dtpCreateDate.Size = new System.Drawing.Size(212, 22);
			this.m_dtpCreateDate.TabIndex = 400;
			this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
			this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
			// 
			// lblInpatientdate
			// 
			this.lblInpatientdate.AutoSize = true;
			this.lblInpatientdate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblInpatientdate.ForeColor = System.Drawing.Color.Black;
			this.lblInpatientdate.Location = new System.Drawing.Point(64, 40);
			this.lblInpatientdate.Name = "lblInpatientdate";
			this.lblInpatientdate.Size = new System.Drawing.Size(70, 19);
			this.lblInpatientdate.TabIndex = 5;
			this.lblInpatientdate.Text = "入院日期:";
			// 
			// m_cboBed
			// 
			this.m_cboBed.AccessibleName = "NoDefault";
			this.m_cboBed.BackColor = System.Drawing.Color.White;
			this.m_cboBed.BorderColor = System.Drawing.Color.Black;
			this.m_cboBed.DropButtonBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboBed.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboBed.DropButtonForeColor = System.Drawing.Color.Black;
			this.m_cboBed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboBed.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBed.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboBed.ForeColor = System.Drawing.Color.Black;
			this.m_cboBed.ListBackColor = System.Drawing.SystemColors.ControlLight;
			this.m_cboBed.ListForeColor = System.Drawing.SystemColors.WindowText;
			this.m_cboBed.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
			this.m_cboBed.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
			this.m_cboBed.Location = new System.Drawing.Point(624, 8);
			this.m_cboBed.m_BlnEnableItemEventMenu = false;
			this.m_cboBed.Name = "m_cboBed";
			this.m_cboBed.SelectedIndex = -1;
			this.m_cboBed.SelectedItem = null;
			this.m_cboBed.SelectionStart = -1;
			this.m_cboBed.Size = new System.Drawing.Size(108, 23);
			this.m_cboBed.TabIndex = 300;
			this.m_cboBed.TabStop = false;
			this.m_cboBed.TextBackColor = System.Drawing.Color.White;
			this.m_cboBed.TextForeColor = System.Drawing.Color.Black;
			// 
			// label2
			// 
			this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label2.BackColor = System.Drawing.Color.MediumVioletRed;
			this.label2.ForeColor = System.Drawing.SystemColors.Highlight;
			this.label2.Location = new System.Drawing.Point(4, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(828, 2);
			this.label2.TabIndex = 10;
			// 
			// picLogo
			// 
			this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
			this.picLogo.Location = new System.Drawing.Point(8, 8);
			this.picLogo.Name = "picLogo";
			this.picLogo.Size = new System.Drawing.Size(49, 49);
			this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picLogo.TabIndex = 10000034;
			this.picLogo.TabStop = false;
			// 
			// frmEMRBaseForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(844, 397);
			this.Controls.Add(this.picLogo);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.m_cboBed);
			this.Controls.Add(this.lblInpatientdate);
			this.Controls.Add(this.m_dtpCreateDate);
			this.Controls.Add(this.lblNameTitle);
			this.Controls.Add(this.m_txtPatientName);
			this.Controls.Add(this.lblBedNoTitle);
			this.Controls.Add(this.lblInHospitalNoTitle);
			this.Controls.Add(this.txtInPatientID);
			this.Controls.Add(this.lblAgeTitle);
			this.Controls.Add(this.lblSexTitle);
			this.Controls.Add(this.lblSex);
			this.Controls.Add(this.lblAge);
			this.Controls.Add(this.lblDept);
			this.Controls.Add(this.lblAreaTitle);
			this.Controls.Add(this.m_cboDept);
			this.Controls.Add(this.m_cboArea);
			this.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmEMRBaseForm";
			this.Text = "frmEMRBaseForm";
			this.ResumeLayout(false);

		}
		#endregion
		#endregion

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public frmEMRBaseForm()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		#endregion

	
	}
}
