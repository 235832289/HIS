using System;
using iCareData;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using com.digitalwave.Emr.Signature_gui;
using System.Windows.Forms;


namespace iCare
{
	public class frmPICUShiftInForm : iCare.frmPICUShiftBaseForm
	{
		private System.ComponentModel.IContainer components = null;
        private clsEmrSignToolCollection m_objSign;
//		private clsCommonUseTool m_objICU;

		public frmPICUShiftInForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //指明医生工作站表单
            intFormType = 1;
//			m_strDeptID = m_strGetICUDeptID();

			m_objShiftInDomain = new clsPICUShiftInDomain();

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdFromDoctor, txtFromDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}

		private clsPICUShiftInDomain m_objShiftInDomain;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		//谢桂军2003.12.19日将 lblPupilReflection1.Text = "瞳孔反射:右" 更改成 lblPupilReflection1.Text = "瞳孔光反射:右"
		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPICUShiftInForm));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Location = new System.Drawing.Point(173, 155);
            this.m_lblAddress.Size = new System.Drawing.Size(224, 32);
            this.m_lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            this.lblAddress.Size = new System.Drawing.Size(42, 14);
            this.lblAddress.Text = "住址:";
            // 
            // m_lblTurnBaseDept
            // 
            this.m_lblTurnBaseDept.Text = "转出科室:";
            // 
            // m_lblTurnTime
            // 
            this.m_lblTurnTime.Location = new System.Drawing.Point(440, 134);
            this.m_lblTurnTime.Text = "转入时间:";
            // 
            // lblTurnDiagnose
            // 
            this.lblTurnDiagnose.Text = "转入诊断:";
            // 
            // lblInDiagnoseCourse
            // 
            this.lblInDiagnoseCourse.Location = new System.Drawing.Point(12, 226);
            // 
            // m_txtInDiagnoseCourse
            // 
            this.m_txtInDiagnoseCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtInDiagnoseCourse.Location = new System.Drawing.Point(20, 251);
            this.m_txtInDiagnoseCourse.MaxLength = 2000;
            this.m_txtInDiagnoseCourse.Size = new System.Drawing.Size(757, 191);
            // 
            // m_txtInDiagnose
            // 
            this.m_txtInDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtInDiagnose.MaxLength = 2000;
            this.m_txtInDiagnose.Size = new System.Drawing.Size(685, 21);
            // 
            // m_txtAnaesthesiaType
            // 
            this.m_txtAnaesthesiaType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtAnaesthesiaType.MaxLength = 2000;
            this.m_txtAnaesthesiaType.Size = new System.Drawing.Size(685, 21);
            // 
            // m_txtOperationName
            // 
            this.m_txtOperationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOperationName.MaxLength = 2000;
            this.m_txtOperationName.Size = new System.Drawing.Size(685, 21);
            // 
            // m_txtTurnDiagnose
            // 
            this.m_txtTurnDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTurnDiagnose.MaxLength = 2000;
            this.m_txtTurnDiagnose.Size = new System.Drawing.Size(685, 56);
            // 
            // m_dtpTurnTime
            // 
            this.m_dtpTurnTime.Location = new System.Drawing.Point(516, 131);
            // 
            // m_lblTurnInfo
            // 
            this.m_lblTurnInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblTurnInfo.Location = new System.Drawing.Point(16, 439);
            this.m_lblTurnInfo.Text = "转入情况";
            this.m_lblTurnInfo.Visible = false;
            // 
            // lblPupilReflection1
            // 
            this.lblPupilReflection1.Location = new System.Drawing.Point(350, 84);
            this.lblPupilReflection1.Size = new System.Drawing.Size(98, 14);
            this.lblPupilReflection1.Text = "瞳孔光反射:右";
            // 
            // lblPupilReflection2
            // 
            this.lblPupilReflection2.Location = new System.Drawing.Point(564, 84);
            // 
            // lblGlasgow1
            // 
            this.lblGlasgow1.Location = new System.Drawing.Point(16, 120);
            this.lblGlasgow1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGlasgow2
            // 
            this.lblGlasgow2.Location = new System.Drawing.Point(188, 120);
            this.lblGlasgow2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGlasgow3
            // 
            this.lblGlasgow3.Location = new System.Drawing.Point(332, 120);
            this.lblGlasgow3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGlasgow4
            // 
            this.lblGlasgow4.Location = new System.Drawing.Point(464, 120);
            this.lblGlasgow4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblGlasgow5
            // 
            this.lblGlasgow5.Location = new System.Drawing.Point(576, 120);
            this.lblGlasgow5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtOther
            // 
            this.m_txtOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOther.MaxLength = 2000;
            this.m_txtOther.Size = new System.Drawing.Size(765, 288);
            // 
            // m_txtWoundInfo
            // 
            this.m_txtWoundInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtWoundInfo.MaxLength = 2000;
            this.m_txtWoundInfo.Size = new System.Drawing.Size(773, 172);
            // 
            // lblFromDeptDoctor
            // 
            this.lblFromDeptDoctor.Location = new System.Drawing.Point(288, 550);
            this.lblFromDeptDoctor.Text = "转出科医师";
            // 
            // lblToDeptDoctor
            // 
            this.lblToDeptDoctor.Location = new System.Drawing.Point(260, 578);
            this.lblToDeptDoctor.Text = "中心ICU医师";
            // 
            // m_lblTurnBaseDeptName
            // 
            this.m_lblTurnBaseDeptName.Location = new System.Drawing.Point(98, 130);
            // 
            // m_lblToDeptDoctor
            // 
            this.m_lblToDeptDoctor.Location = new System.Drawing.Point(396, 551);
            // 
            // m_lblFromDeptDoctor
            // 
            this.m_lblFromDeptDoctor.Location = new System.Drawing.Point(317, 549);
            // 
            // m_trvTime
            // 
            this.m_trvTime.LineColor = System.Drawing.Color.Black;
            this.m_trvTime.Visible = true;
            // 
            // m_txtBE
            // 
            this.m_txtBE.Size = new System.Drawing.Size(59, 18);
            // 
            // m_trvLabCheckSendTime
            // 
            this.m_trvLabCheckSendTime.LineColor = System.Drawing.Color.Black;
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(4, 95);
            this.tabControl1.Size = new System.Drawing.Size(791, 478);
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage1, 0);
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Size = new System.Drawing.Size(791, 453);
            this.tabPage1.Text = "转入情况";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Size = new System.Drawing.Size(791, 453);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Size = new System.Drawing.Size(791, 453);
            // 
            // m_cmdFromDoctor
            // 
            this.m_cmdFromDoctor.Location = new System.Drawing.Point(552, 53);
            this.m_cmdFromDoctor.Text = "转出科医师";
            // 
            // txtFromDoctor
            // 
            this.txtFromDoctor.Location = new System.Drawing.Point(659, 57);
            this.txtFromDoctor.Size = new System.Drawing.Size(124, 23);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(301, 132);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(254, 159);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(267, 152);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(253, 147);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(234, 164);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.TabIndex = 6;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.TabIndex = 5;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(234, 164);
            this.m_txtPatientName.Size = new System.Drawing.Size(75, 23);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(246, 138);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Text = "转 入 记 录 表";
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(724, 38);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(596, 54);
            // 
            // frmPICUShiftInForm
            // 
            this.AccessibleDescription = "转入记录表";
            this.ClientSize = new System.Drawing.Size(800, 593);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPICUShiftInForm";
            this.Text = "转入记录表";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		protected override iCare.clsPICUShiftBaseDomain m_ObjShiftDomain
		{
			get
			{
				return m_objShiftInDomain;
			}
		}

		protected override bool m_BlnIsShiftInRecord
		{
			get
			{
				return true;
			}
		}

		protected override iCare.clsPICUShiftTurnInfo m_objGetShiftTurnInfo()
		{
			return new clsPICUShiftInTurnInfo();
		}

		/// <summary>
		/// 窗体ID，只针对允许作废重做的窗体
		/// </summary>		
		protected override int m_IntSubFormID
		{
			get
			{
				return 25;
			}
		}
        /// <summary>
        /// 获取记录建立者
        /// </summary>
        protected virtual string m_StrRecorder_ID
        {
            get
            {
                if (txtFromDoctor.Tag != null)
                    return ((clsEmrEmployeeBase_VO)txtFromDoctor.Tag).m_strEMPID_CHR;
                return "";
            }
        }
//		private string m_strGetICUDeptID
//		{
//		}
	}
}

