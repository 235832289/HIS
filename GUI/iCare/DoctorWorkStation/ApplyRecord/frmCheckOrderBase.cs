using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// frmCheckOrderBase 的摘要说明。
	/// </summary>
	public class frmCheckOrderBase : iCare.frmHRPBaseForm//,PublicFunction
	{
		protected System.Windows.Forms.TreeView trvTime;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCheckOrderBase()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		#region Member
		protected clsInPatientCaseHisoryDefaultDomain m_objInPaitentCaseDefault=new clsInPatientCaseHisoryDefaultDomain();
		protected bool m_blnCanSearch = true;
		protected bool blnCanDelete=true;              //是否可以执行删除操作
		
		/// <summary>
		/// 出报表的DataSet
		/// </summary>
//		protected DataSet m_dtsRept;
//
//		/// <summary>
//		/// 报告单的报表类
//		/// </summary>
//		protected ReportDocument m_rpdOrderRept;
		
		protected string m_strInPatientID;
		protected string m_strInPatientDate;
		protected string m_strCreateDate = "";

		
		#endregion Member

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
			this.trvTime = new System.Windows.Forms.TreeView();
			this.SuspendLayout();
			// 
			// lblSex
			// 
			this.lblSex.Location = new System.Drawing.Point(733, 14);
			this.lblSex.Name = "lblSex";
			this.lblSex.Size = new System.Drawing.Size(56, 21);
			// 
			// lblAge
			// 
			this.lblAge.Location = new System.Drawing.Point(859, 14);
			this.lblAge.Name = "lblAge";
			this.lblAge.Size = new System.Drawing.Size(60, 21);
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Location = new System.Drawing.Point(275, 18);
			this.lblBedNoTitle.Name = "lblBedNoTitle";
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Location = new System.Drawing.Point(261, 55);
			this.lblInHospitalNoTitle.Name = "lblInHospitalNoTitle";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Location = new System.Drawing.Point(476, 18);
			this.lblNameTitle.Name = "lblNameTitle";
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Location = new System.Drawing.Point(677, 14);
			this.lblSexTitle.Name = "lblSexTitle";
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Location = new System.Drawing.Point(803, 14);
			this.lblAgeTitle.Name = "lblAgeTitle";
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Location = new System.Drawing.Point(19, 55);
			this.lblAreaTitle.Name = "lblAreaTitle";
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Location = new System.Drawing.Point(327, 78);
			this.m_lsvInPatientID.Name = "m_lsvInPatientID";
			this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 119);
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Location = new System.Drawing.Point(327, 50);
			this.txtInPatientID.Name = "txtInPatientID";
			this.txtInPatientID.Size = new System.Drawing.Size(135, 24);
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Location = new System.Drawing.Point(527, 14);
			this.m_txtPatientName.Name = "m_txtPatientName";
			this.m_txtPatientName.Size = new System.Drawing.Size(136, 24);
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Location = new System.Drawing.Point(327, 14);
			this.m_txtBedNO.Name = "m_txtBedNO";
			this.m_txtBedNO.Size = new System.Drawing.Size(135, 24);
			// 
			// m_cboArea
			// 
			this.m_cboArea.Location = new System.Drawing.Point(68, 52);
			this.m_cboArea.Name = "m_cboArea";
			this.m_cboArea.Size = new System.Drawing.Size(168, 23);
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Location = new System.Drawing.Point(527, 41);
			this.m_lsvPatientName.Name = "m_lsvPatientName";
			this.m_lsvPatientName.Size = new System.Drawing.Size(136, 119);
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Location = new System.Drawing.Point(327, 38);
			this.m_lsvBedNO.Name = "m_lsvBedNO";
			this.m_lsvBedNO.Size = new System.Drawing.Size(135, 119);
			// 
			// m_cboDept
			// 
			this.m_cboDept.Location = new System.Drawing.Point(68, 16);
			this.m_cboDept.Name = "m_cboDept";
			this.m_cboDept.Size = new System.Drawing.Size(168, 23);
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(19, 18);
			this.lblDept.Name = "lblDept";
			// 
			// m_cmdNewTemplate
			// 
			this.m_cmdNewTemplate.Location = new System.Drawing.Point(821, 55);
			this.m_cmdNewTemplate.Name = "m_cmdNewTemplate";
			this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 36);
			// 
			// m_cmdNext
			// 
			this.m_cmdNext.Location = new System.Drawing.Point(229, 14);
			this.m_cmdNext.Name = "m_cmdNext";
			this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
			// 
			// m_cmdPre
			// 
			this.m_cmdPre.Location = new System.Drawing.Point(182, 14);
			this.m_cmdPre.Name = "m_cmdPre";
			this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Location = new System.Drawing.Point(523, 9);
			this.m_lblForTitle.Name = "m_lblForTitle";
			this.m_lblForTitle.Size = new System.Drawing.Size(18, 26);
			// 
			// trvTime
			// 
			this.trvTime.BackColor = System.Drawing.Color.White;
			this.trvTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.trvTime.ForeColor = System.Drawing.Color.Black;
			this.trvTime.HideSelection = false;
			this.trvTime.ImageIndex = -1;
			this.trvTime.ItemHeight = 18;
			this.trvTime.Location = new System.Drawing.Point(20, 88);
			this.trvTime.Name = "trvTime";
			this.trvTime.SelectedImageIndex = -1;
			this.trvTime.ShowRootLines = false;
			this.trvTime.Size = new System.Drawing.Size(208, 80);
			this.trvTime.TabIndex = 10000004;
			// 
			// frmCheckOrderBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(976, 513);
			this.Controls.Add(this.trvTime);
			this.Name = "frmCheckOrderBase";
			this.Text = "frmCheckOrderBase";
			this.Controls.SetChildIndex(this.m_cmdNext, 0);
			this.Controls.SetChildIndex(this.m_cmdPre, 0);
			this.Controls.SetChildIndex(this.lblAge, 0);
			this.Controls.SetChildIndex(this.lblSex, 0);
			this.Controls.SetChildIndex(this.m_cboArea, 0);
			this.Controls.SetChildIndex(this.m_cboDept, 0);
			this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
			this.Controls.SetChildIndex(this.lblSexTitle, 0);
			this.Controls.SetChildIndex(this.lblAgeTitle, 0);
			this.Controls.SetChildIndex(this.m_txtPatientName, 0);
			this.Controls.SetChildIndex(this.lblNameTitle, 0);
			this.Controls.SetChildIndex(this.txtInPatientID, 0);
			this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
			this.Controls.SetChildIndex(this.m_txtBedNO, 0);
			this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
			this.Controls.SetChildIndex(this.lblAreaTitle, 0);
			this.Controls.SetChildIndex(this.lblDept, 0);
			this.Controls.SetChildIndex(this.m_lblForTitle, 0);
			this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
			this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
			this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
			this.Controls.SetChildIndex(this.trvTime, 0);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
