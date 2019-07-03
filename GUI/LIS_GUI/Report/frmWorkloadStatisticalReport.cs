using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using com.digitalwave.iCare.ValueObject;//iCareData

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// frmWorkloadStatisticalReport 的摘要说明。
	/// </summary>
	public class frmWorkloadStatisticalReport : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		internal System.Windows.Forms.GroupBox m_gbQueryCondition;
		private System.Windows.Forms.Label m_lbTo;
		private System.Windows.Forms.Label m_lbApplyEmployee;
		internal com.digitalwave.Utility.ctlEmpTextBox m_txtApplyEmployee;
		private System.Windows.Forms.Label m_lbCheckItem;
		internal System.Windows.Forms.ComboBox m_cboCheckItem;
		private System.Windows.Forms.Label m_lbCheckEmployee;
		internal com.digitalwave.Utility.ctlEmpTextBox m_txtCheckEmployee;
		private System.Windows.Forms.Label m_lbApplyDept;
		private System.Windows.Forms.Label m_lbPatientType;
		internal System.Windows.Forms.ComboBox m_cboPatientType;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_CRVewerWorkload;
		internal com.digitalwave.Utility.ctlDeptTextBox m_txtApplyDept;
		private System.Windows.Forms.Label m_lbCheckCategory;
        internal System.Windows.Forms.ComboBox m_cboCheckCategory;
		internal System.Windows.Forms.DateTimePicker m_dtpToDat;
		internal System.Windows.Forms.DateTimePicker m_dtpFromDat;
		private System.Windows.Forms.Label m_lbCheckDat;
		internal System.Windows.Forms.CheckBox m_chkCheckDat;
        private PinkieControls.ButtonXP m_btnReset;
        private PinkieControls.ButtonXP btnExit;
        private PinkieControls.ButtonXP m_btnQry;
		
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmWorkloadStatisticalReport()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

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
            this.m_gbQueryCondition = new System.Windows.Forms.GroupBox();
            this.m_chkCheckDat = new System.Windows.Forms.CheckBox();
            this.m_cboCheckCategory = new System.Windows.Forms.ComboBox();
            this.m_txtApplyDept = new com.digitalwave.Utility.ctlDeptTextBox();
            this.m_cboPatientType = new System.Windows.Forms.ComboBox();
            this.m_lbPatientType = new System.Windows.Forms.Label();
            this.m_lbApplyDept = new System.Windows.Forms.Label();
            this.m_txtCheckEmployee = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_lbCheckEmployee = new System.Windows.Forms.Label();
            this.m_cboCheckItem = new System.Windows.Forms.ComboBox();
            this.m_lbCheckItem = new System.Windows.Forms.Label();
            this.m_txtApplyEmployee = new com.digitalwave.Utility.ctlEmpTextBox();
            this.m_lbApplyEmployee = new System.Windows.Forms.Label();
            this.m_lbCheckCategory = new System.Windows.Forms.Label();
            this.m_dtpFromDat = new System.Windows.Forms.DateTimePicker();
            this.m_lbCheckDat = new System.Windows.Forms.Label();
            this.m_dtpToDat = new System.Windows.Forms.DateTimePicker();
            this.m_lbTo = new System.Windows.Forms.Label();
            this.m_CRVewerWorkload = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.btnExit = new PinkieControls.ButtonXP();
            this.m_btnReset = new PinkieControls.ButtonXP();
            this.m_btnQry = new PinkieControls.ButtonXP();
            this.m_gbQueryCondition.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_gbQueryCondition
            // 
            this.m_gbQueryCondition.Controls.Add(this.m_btnQry);
            this.m_gbQueryCondition.Controls.Add(this.m_btnReset);
            this.m_gbQueryCondition.Controls.Add(this.btnExit);
            this.m_gbQueryCondition.Controls.Add(this.m_chkCheckDat);
            this.m_gbQueryCondition.Controls.Add(this.m_cboCheckCategory);
            this.m_gbQueryCondition.Controls.Add(this.m_txtApplyDept);
            this.m_gbQueryCondition.Controls.Add(this.m_cboPatientType);
            this.m_gbQueryCondition.Controls.Add(this.m_lbPatientType);
            this.m_gbQueryCondition.Controls.Add(this.m_lbApplyDept);
            this.m_gbQueryCondition.Controls.Add(this.m_txtCheckEmployee);
            this.m_gbQueryCondition.Controls.Add(this.m_lbCheckEmployee);
            this.m_gbQueryCondition.Controls.Add(this.m_cboCheckItem);
            this.m_gbQueryCondition.Controls.Add(this.m_lbCheckItem);
            this.m_gbQueryCondition.Controls.Add(this.m_txtApplyEmployee);
            this.m_gbQueryCondition.Controls.Add(this.m_lbApplyEmployee);
            this.m_gbQueryCondition.Controls.Add(this.m_lbCheckCategory);
            this.m_gbQueryCondition.Controls.Add(this.m_dtpFromDat);
            this.m_gbQueryCondition.Controls.Add(this.m_lbCheckDat);
            this.m_gbQueryCondition.Controls.Add(this.m_dtpToDat);
            this.m_gbQueryCondition.Controls.Add(this.m_lbTo);
            this.m_gbQueryCondition.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_gbQueryCondition.Location = new System.Drawing.Point(12, 8);
            this.m_gbQueryCondition.Name = "m_gbQueryCondition";
            this.m_gbQueryCondition.Size = new System.Drawing.Size(596, 132);
            this.m_gbQueryCondition.TabIndex = 0;
            this.m_gbQueryCondition.TabStop = false;
            this.m_gbQueryCondition.Text = "查询条件";
            // 
            // m_chkCheckDat
            // 
            this.m_chkCheckDat.Checked = true;
            this.m_chkCheckDat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCheckDat.Location = new System.Drawing.Point(376, 20);
            this.m_chkCheckDat.Name = "m_chkCheckDat";
            this.m_chkCheckDat.Size = new System.Drawing.Size(20, 24);
            this.m_chkCheckDat.TabIndex = 18;
            this.m_chkCheckDat.CheckedChanged += new System.EventHandler(this.m_chkCheckDat_CheckedChanged);
            // 
            // m_cboCheckCategory
            // 
            this.m_cboCheckCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckCategory.Location = new System.Drawing.Point(84, 44);
            this.m_cboCheckCategory.Name = "m_cboCheckCategory";
            this.m_cboCheckCategory.Size = new System.Drawing.Size(144, 22);
            this.m_cboCheckCategory.TabIndex = 15;
            this.m_cboCheckCategory.SelectedIndexChanged += new System.EventHandler(this.m_cboCheckCategory_SelectedIndexChanged);
            // 
            // m_txtApplyDept
            // 
            this.m_txtApplyDept.EnableAutoValidation = true;
            this.m_txtApplyDept.EnableEnterKeyValidate = true;
            this.m_txtApplyDept.EnableEscapeKeyUndo = true;
            this.m_txtApplyDept.EnableLastValidValue = true;
            this.m_txtApplyDept.ErrorProvider = null;
            this.m_txtApplyDept.ErrorProviderMessage = "Invalid value";
            this.m_txtApplyDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtApplyDept.ForceFormatText = true;
            this.m_txtApplyDept.Location = new System.Drawing.Point(84, 68);
            this.m_txtApplyDept.m_StrDeptID = null;
            this.m_txtApplyDept.m_StrDeptName = null;
            this.m_txtApplyDept.Name = "m_txtApplyDept";
            this.m_txtApplyDept.SetDepartment = com.digitalwave.Utility.ctlDeptTextBox.eDeptArea.All;
            this.m_txtApplyDept.Size = new System.Drawing.Size(144, 23);
            this.m_txtApplyDept.TabIndex = 14;
            this.m_txtApplyDept.evtValueChanged += new com.digitalwave.Utility.dlgExValueChangedEventHandler(this.m_txtApplyDept_evtValueChanged);
            // 
            // m_cboPatientType
            // 
            this.m_cboPatientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboPatientType.Location = new System.Drawing.Point(84, 96);
            this.m_cboPatientType.Name = "m_cboPatientType";
            this.m_cboPatientType.Size = new System.Drawing.Size(144, 22);
            this.m_cboPatientType.TabIndex = 13;
            // 
            // m_lbPatientType
            // 
            this.m_lbPatientType.Location = new System.Drawing.Point(12, 104);
            this.m_lbPatientType.Name = "m_lbPatientType";
            this.m_lbPatientType.Size = new System.Drawing.Size(64, 23);
            this.m_lbPatientType.TabIndex = 12;
            this.m_lbPatientType.Text = "病人类型";
            // 
            // m_lbApplyDept
            // 
            this.m_lbApplyDept.Location = new System.Drawing.Point(12, 76);
            this.m_lbApplyDept.Name = "m_lbApplyDept";
            this.m_lbApplyDept.Size = new System.Drawing.Size(64, 23);
            this.m_lbApplyDept.TabIndex = 10;
            this.m_lbApplyDept.Text = "申请科室";
            // 
            // m_txtCheckEmployee
            // 
            this.m_txtCheckEmployee.EnableAutoValidation = true;
            this.m_txtCheckEmployee.EnableEnterKeyValidate = true;
            this.m_txtCheckEmployee.EnableEscapeKeyUndo = true;
            this.m_txtCheckEmployee.EnableLastValidValue = true;
            this.m_txtCheckEmployee.ErrorProvider = null;
            this.m_txtCheckEmployee.ErrorProviderMessage = "Invalid value";
            this.m_txtCheckEmployee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtCheckEmployee.ForceFormatText = true;
            this.m_txtCheckEmployee.Location = new System.Drawing.Point(344, 96);
            this.m_txtCheckEmployee.m_intShowOtherEmp = 0;
            this.m_txtCheckEmployee.m_StrDeptID = "0000147";
            this.m_txtCheckEmployee.m_StrEmployeeID = null;
            this.m_txtCheckEmployee.m_StrEmployeeName = null;
            this.m_txtCheckEmployee.Name = "m_txtCheckEmployee";
            this.m_txtCheckEmployee.Size = new System.Drawing.Size(144, 23);
            this.m_txtCheckEmployee.TabIndex = 9;
            // 
            // m_lbCheckEmployee
            // 
            this.m_lbCheckEmployee.Location = new System.Drawing.Point(280, 104);
            this.m_lbCheckEmployee.Name = "m_lbCheckEmployee";
            this.m_lbCheckEmployee.Size = new System.Drawing.Size(64, 23);
            this.m_lbCheckEmployee.TabIndex = 8;
            this.m_lbCheckEmployee.Text = "检验医生";
            // 
            // m_cboCheckItem
            // 
            this.m_cboCheckItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboCheckItem.Location = new System.Drawing.Point(344, 44);
            this.m_cboCheckItem.Name = "m_cboCheckItem";
            this.m_cboCheckItem.Size = new System.Drawing.Size(144, 22);
            this.m_cboCheckItem.TabIndex = 7;
            // 
            // m_lbCheckItem
            // 
            this.m_lbCheckItem.Location = new System.Drawing.Point(280, 52);
            this.m_lbCheckItem.Name = "m_lbCheckItem";
            this.m_lbCheckItem.Size = new System.Drawing.Size(72, 16);
            this.m_lbCheckItem.TabIndex = 6;
            this.m_lbCheckItem.Text = "检验项目";
            // 
            // m_txtApplyEmployee
            // 
            this.m_txtApplyEmployee.EnableAutoValidation = true;
            this.m_txtApplyEmployee.EnableEnterKeyValidate = true;
            this.m_txtApplyEmployee.EnableEscapeKeyUndo = true;
            this.m_txtApplyEmployee.EnableLastValidValue = true;
            this.m_txtApplyEmployee.ErrorProvider = null;
            this.m_txtApplyEmployee.ErrorProviderMessage = "Invalid value";
            this.m_txtApplyEmployee.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtApplyEmployee.ForceFormatText = true;
            this.m_txtApplyEmployee.Location = new System.Drawing.Point(344, 68);
            this.m_txtApplyEmployee.m_intShowOtherEmp = 0;
            this.m_txtApplyEmployee.m_StrDeptID = null;
            this.m_txtApplyEmployee.m_StrEmployeeID = null;
            this.m_txtApplyEmployee.m_StrEmployeeName = null;
            this.m_txtApplyEmployee.Name = "m_txtApplyEmployee";
            this.m_txtApplyEmployee.Size = new System.Drawing.Size(144, 23);
            this.m_txtApplyEmployee.TabIndex = 5;
            // 
            // m_lbApplyEmployee
            // 
            this.m_lbApplyEmployee.Location = new System.Drawing.Point(280, 76);
            this.m_lbApplyEmployee.Name = "m_lbApplyEmployee";
            this.m_lbApplyEmployee.Size = new System.Drawing.Size(64, 23);
            this.m_lbApplyEmployee.TabIndex = 4;
            this.m_lbApplyEmployee.Text = "申请医生";
            // 
            // m_lbCheckCategory
            // 
            this.m_lbCheckCategory.Location = new System.Drawing.Point(12, 52);
            this.m_lbCheckCategory.Name = "m_lbCheckCategory";
            this.m_lbCheckCategory.Size = new System.Drawing.Size(68, 23);
            this.m_lbCheckCategory.TabIndex = 2;
            this.m_lbCheckCategory.Text = "检验类别";
            // 
            // m_dtpFromDat
            // 
            this.m_dtpFromDat.Location = new System.Drawing.Point(84, 16);
            this.m_dtpFromDat.Name = "m_dtpFromDat";
            this.m_dtpFromDat.Size = new System.Drawing.Size(120, 23);
            this.m_dtpFromDat.TabIndex = 1;
            // 
            // m_lbCheckDat
            // 
            this.m_lbCheckDat.Location = new System.Drawing.Point(12, 24);
            this.m_lbCheckDat.Name = "m_lbCheckDat";
            this.m_lbCheckDat.Size = new System.Drawing.Size(72, 23);
            this.m_lbCheckDat.TabIndex = 0;
            this.m_lbCheckDat.Text = "检验日期";
            // 
            // m_dtpToDat
            // 
            this.m_dtpToDat.Location = new System.Drawing.Point(236, 16);
            this.m_dtpToDat.Name = "m_dtpToDat";
            this.m_dtpToDat.Size = new System.Drawing.Size(120, 23);
            this.m_dtpToDat.TabIndex = 3;
            // 
            // m_lbTo
            // 
            this.m_lbTo.Location = new System.Drawing.Point(208, 20);
            this.m_lbTo.Name = "m_lbTo";
            this.m_lbTo.Size = new System.Drawing.Size(24, 23);
            this.m_lbTo.TabIndex = 2;
            this.m_lbTo.Text = "至";
            // 
            // m_CRVewerWorkload
            // 
            this.m_CRVewerWorkload.ActiveViewIndex = -1;
            this.m_CRVewerWorkload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_CRVewerWorkload.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_CRVewerWorkload.DisplayGroupTree = false;
            this.m_CRVewerWorkload.Location = new System.Drawing.Point(12, 152);
            this.m_CRVewerWorkload.Name = "m_CRVewerWorkload";
            this.m_CRVewerWorkload.SelectionFormula = "";
            this.m_CRVewerWorkload.ShowGroupTreeButton = false;
            this.m_CRVewerWorkload.Size = new System.Drawing.Size(860, 380);
            this.m_CRVewerWorkload.TabIndex = 1;
            this.m_CRVewerWorkload.ViewTimeSelectionFormula = "";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExit.DefaultScheme = true;
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExit.Hint = "";
            this.btnExit.Location = new System.Drawing.Point(508, 91);
            this.btnExit.Name = "btnExit";
            this.btnExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExit.Size = new System.Drawing.Size(75, 29);
            this.btnExit.TabIndex = 19;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // m_btnReset
            // 
            this.m_btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnReset.DefaultScheme = true;
            this.m_btnReset.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnReset.Hint = "";
            this.m_btnReset.Location = new System.Drawing.Point(508, 21);
            this.m_btnReset.Name = "m_btnReset";
            this.m_btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnReset.Size = new System.Drawing.Size(75, 29);
            this.m_btnReset.TabIndex = 17;
            this.m_btnReset.Text = "重  置";
            this.m_btnReset.Click += new System.EventHandler(this.m_btnReset_Click);
            // 
            // m_btnQry
            // 
            this.m_btnQry.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnQry.DefaultScheme = true;
            this.m_btnQry.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnQry.Hint = "";
            this.m_btnQry.Location = new System.Drawing.Point(508, 56);
            this.m_btnQry.Name = "m_btnQry";
            this.m_btnQry.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnQry.Size = new System.Drawing.Size(75, 29);
            this.m_btnQry.TabIndex = 16;
            this.m_btnQry.Text = "查  询";
            this.m_btnQry.Click += new System.EventHandler(this.m_btnQry_Click);
            // 
            // frmWorkloadStatisticalReport
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(892, 557);
            this.Controls.Add(this.m_CRVewerWorkload);
            this.Controls.Add(this.m_gbQueryCondition);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmWorkloadStatisticalReport";
            this.Text = "frmWorkloadStatisticalReport";
            this.Load += new System.EventHandler(this.frmWorkloadStatisticalReport_Load);
            this.m_gbQueryCondition.ResumeLayout(false);
            this.m_gbQueryCondition.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.LIS.clsController_workloadStatisticalReport();
			objController.Set_GUI_Apperance(this);
		}

		private void m_txtApplyDept_evtValueChanged(object sender, com.digitalwave.Utility.clsExValueChangedEventArgs e)
		{
			m_txtApplyEmployee.m_StrDeptID = m_txtApplyDept.m_StrDeptID;
		}

		private void frmWorkloadStatisticalReport_Load(object sender, System.EventArgs e)
		{
			((clsController_workloadStatisticalReport)this.objController).m_mthInitInfo();
		}

		private void m_cboCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_cboCheckCategory.Items.Count > 0)
			{
				if(this.m_cboCheckCategory.SelectedIndex == 0)
				{
					((clsController_workloadStatisticalReport)this.objController).m_mthGetCheckItemByCheckCategory("");
				}
				else
				{
					((clsController_workloadStatisticalReport)this.objController).m_mthGetCheckItemByCheckCategory(
						((clsCheckCategory_VO[])this.m_cboCheckCategory.Tag)[this.m_cboCheckCategory.SelectedIndex-1].m_strCheck_Category_ID);
				}
			}
		}

		private void m_btnQry_Click(object sender, System.EventArgs e)
		{
			((clsController_workloadStatisticalReport)this.objController).m_mthQryByCondition();
		}

		private void m_btnReset_Click(object sender, System.EventArgs e)
		{
			((clsController_workloadStatisticalReport)this.objController).m_mthClear();
		}

		private void m_chkCheckDat_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_chkCheckDat.Checked)
			{
				this.m_dtpFromDat.Enabled = true;
				this.m_dtpToDat.Enabled = true;
			}
			else
			{
				this.m_dtpFromDat.Enabled = false;
				this.m_dtpToDat.Enabled = false;
			}
		}

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

	}
}
