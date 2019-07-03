//#define Debug
using iCareData;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using com.digitalwave.Emr.Signature_gui;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// ICU转出记录
	/// </summary>
	public class frmPICUShiftOutForm : iCare.frmPICUShiftBaseForm
	{
		private System.ComponentModel.IContainer components = null;
        private clsEmrSignToolCollection m_objSign;

		public frmPICUShiftOutForm()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			// TODO: Add any initialization after the InitializeComponent call
		
			m_objShiftOutDomain = new clsPICUShiftOutDomain();	
		
			clsDepartment [] objDeptArr = m_objCurrentContext.m_ObjDeptManager.m_objGetAllInDeptArr();
			m_cboToDept.AddRangeItems(objDeptArr);

            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(m_cmdFromDoctor, txtFromDoctor, 1, true, clsEMRLogin.LoginInfo.m_strEmpID);
		}

		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboToDept;

		private clsPICUShiftOutDomain m_objShiftOutDomain;

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
		//谢桂军2003.12.19日将 m_lblTurnBaseDept.Text = "转入科室:" 更改成 m_lblTurnBaseDept.Text = "原转入科室:";

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_cboToDept = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblAddress
            // 
            this.m_lblAddress.Location = new System.Drawing.Point(564, 44);
            this.m_lblAddress.Size = new System.Drawing.Size(224, 36);
            this.m_lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAddress
            // 
            this.lblAddress.Size = new System.Drawing.Size(42, 14);
            this.lblAddress.Text = "住址:";
            // 
            // m_lblTurnBaseDept
            // 
            this.m_lblTurnBaseDept.Location = new System.Drawing.Point(20, 133);
            this.m_lblTurnBaseDept.Size = new System.Drawing.Size(84, 14);
            this.m_lblTurnBaseDept.Text = "原转入科室:";
            // 
            // m_lblTurnTime
            // 
            this.m_lblTurnTime.Location = new System.Drawing.Point(440, 135);
            this.m_lblTurnTime.Text = "转出时间:";
            // 
            // lblTurnDiagnose
            // 
            this.lblTurnDiagnose.Text = "转出诊断:";
            // 
            // lblInDiagnoseCourse
            // 
            this.lblInDiagnoseCourse.Location = new System.Drawing.Point(20, 219);
            // 
            // m_txtInDiagnoseCourse
            // 
            this.m_txtInDiagnoseCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtInDiagnoseCourse.Location = new System.Drawing.Point(20, 241);
            this.m_txtInDiagnoseCourse.Size = new System.Drawing.Size(749, 203);
            // 
            // m_txtInDiagnose
            // 
            this.m_txtInDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtInDiagnose.Size = new System.Drawing.Size(673, 21);
            // 
            // m_txtAnaesthesiaType
            // 
            this.m_txtAnaesthesiaType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtAnaesthesiaType.Size = new System.Drawing.Size(673, 21);
            // 
            // m_txtOperationName
            // 
            this.m_txtOperationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOperationName.Size = new System.Drawing.Size(673, 21);
            // 
            // m_txtTurnDiagnose
            // 
            this.m_txtTurnDiagnose.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtTurnDiagnose.Size = new System.Drawing.Size(673, 56);
            // 
            // m_dtpTurnTime
            // 
            this.m_dtpTurnTime.Location = new System.Drawing.Point(516, 131);
            // 
            // m_lblTurnInfo
            // 
            this.m_lblTurnInfo.Location = new System.Drawing.Point(16, 446);
            this.m_lblTurnInfo.Text = "转出情况";
            this.m_lblTurnInfo.Visible = false;
            // 
            // lblPupilDiameter2
            // 
            this.lblPupilDiameter2.Location = new System.Drawing.Point(188, 81);
            this.lblPupilDiameter2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblPupilDiameterUnit
            // 
            this.lblPupilDiameterUnit.Location = new System.Drawing.Point(308, 81);
            // 
            // lblPupilReflection1
            // 
            this.lblPupilReflection1.Location = new System.Drawing.Point(344, 81);
            this.lblPupilReflection1.Size = new System.Drawing.Size(98, 14);
            this.lblPupilReflection1.Text = "瞳孔光反射:右";
            this.lblPupilReflection1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblPupilReflection2
            // 
            this.lblPupilReflection2.Location = new System.Drawing.Point(564, 81);
            this.lblPupilReflection2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblPupilDiameter1
            // 
            this.lblPupilDiameter1.Location = new System.Drawing.Point(16, 81);
            this.lblPupilDiameter1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lblGlasgow1
            // 
            this.lblGlasgow1.Location = new System.Drawing.Point(16, 120);
            // 
            // lblGlasgow2
            // 
            this.lblGlasgow2.Location = new System.Drawing.Point(188, 120);
            // 
            // lblGlasgow3
            // 
            this.lblGlasgow3.Location = new System.Drawing.Point(332, 120);
            // 
            // lblGlasgow4
            // 
            this.lblGlasgow4.Location = new System.Drawing.Point(464, 120);
            // 
            // lblGlasgow5
            // 
            this.lblGlasgow5.Location = new System.Drawing.Point(576, 120);
            // 
            // m_txtOther
            // 
            this.m_txtOther.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOther.Size = new System.Drawing.Size(756, 292);
            // 
            // m_txtWoundInfo
            // 
            this.m_txtWoundInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtWoundInfo.Size = new System.Drawing.Size(764, 176);
            // 
            // lblFromDeptDoctor
            // 
            this.lblFromDeptDoctor.Location = new System.Drawing.Point(288, 564);
            this.lblFromDeptDoctor.Text = "中心ICU医师";
            // 
            // lblToDeptDoctor
            // 
            this.lblToDeptDoctor.Location = new System.Drawing.Point(260, 591);
            this.lblToDeptDoctor.Text = "接收科医师";
            // 
            // m_lblTurnBaseDeptName
            // 
            this.m_lblTurnBaseDeptName.Location = new System.Drawing.Point(100, 129);
            // 
            // m_lblToDeptDoctor
            // 
            this.m_lblToDeptDoctor.Location = new System.Drawing.Point(396, 553);
            this.m_lblToDeptDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lblFromDeptDoctor
            // 
            this.m_lblFromDeptDoctor.Location = new System.Drawing.Point(317, 552);
            this.m_lblFromDeptDoctor.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_trvTime
            // 
            this.m_trvTime.LineColor = System.Drawing.Color.Black;
            this.m_trvTime.Visible = true;
            // 
            // m_trvLabCheckSendTime
            // 
            this.m_trvLabCheckSendTime.LineColor = System.Drawing.Color.Black;
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(789, 485);
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage1, 0);
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Size = new System.Drawing.Size(789, 460);
            this.tabPage1.Text = "转出情况";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Size = new System.Drawing.Size(789, 460);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage3.Size = new System.Drawing.Size(789, 460);
            // 
            // m_cmdFromDoctor
            // 
            this.m_cmdFromDoctor.Location = new System.Drawing.Point(571, 53);
            this.m_cmdFromDoctor.Text = "中心ICU医师";
            // 
            // txtFromDoctor
            // 
            this.txtFromDoctor.Location = new System.Drawing.Point(679, 56);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(692, 105);
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(764, 105);
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(364, 105);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(-42, 147);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(516, 105);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(652, 105);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(720, 105);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(-16, 147);
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
            this.m_txtPatientName.Location = new System.Drawing.Point(560, 101);
            this.m_txtPatientName.Size = new System.Drawing.Size(80, 23);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Visible = true;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(-28, 173);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(-46, 126);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Visible = true;
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Text = "转 出 记 录 表";
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(724, 37);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.m_ctlPatientInfo.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_ctlPatientInfo.Location = new System.Drawing.Point(194, 29);
            this.m_ctlPatientInfo.m_BlnIsShowAddres = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(595, 54);
            // 
            // m_cboToDept
            // 
            this.m_cboToDept.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_cboToDept.BorderColor = System.Drawing.Color.White;
            this.m_cboToDept.DropButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_cboToDept.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboToDept.DropButtonForeColor = System.Drawing.Color.White;
            this.m_cboToDept.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboToDept.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboToDept.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboToDept.ForeColor = System.Drawing.Color.White;
            this.m_cboToDept.ListBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_cboToDept.ListForeColor = System.Drawing.Color.White;
            this.m_cboToDept.ListSelectedBackColor = System.Drawing.Color.Blue;
            this.m_cboToDept.ListSelectedForeColor = System.Drawing.Color.White;
            this.m_cboToDept.Location = new System.Drawing.Point(115, 229);
            this.m_cboToDept.m_BlnEnableItemEventMenu = true;
            this.m_cboToDept.Name = "m_cboToDept";
            this.m_cboToDept.SelectedIndex = -1;
            this.m_cboToDept.SelectedItem = null;
            this.m_cboToDept.SelectionStart = 0;
            this.m_cboToDept.Size = new System.Drawing.Size(148, 23);
            this.m_cboToDept.TabIndex = 210;
            this.m_cboToDept.TextBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(113)))), ((int)(((byte)(152)))));
            this.m_cboToDept.TextForeColor = System.Drawing.Color.White;
            // 
            // frmPICUShiftOutForm
            // 
            this.AccessibleDescription = "转出记录表";
            this.ClientSize = new System.Drawing.Size(811, 673);
            this.Controls.Add(this.m_cboToDept);
            this.Name = "frmPICUShiftOutForm";
            this.Text = "转出记录表";
            this.Load += new System.EventHandler(this.frmPICUShiftOutForm_Load);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboToDept, 0);
            this.Controls.SetChildIndex(this.lblFromDeptDoctor, 0);
            this.Controls.SetChildIndex(this.m_lblFromDeptDoctor, 0);
            this.Controls.SetChildIndex(this.m_lblToDeptDoctor, 0);
            this.Controls.SetChildIndex(this.lblToDeptDoctor, 0);
            this.Controls.SetChildIndex(this.m_trvLabCheckSendTime, 0);
            this.Controls.SetChildIndex(this.m_lblAddress, 0);
            this.Controls.SetChildIndex(this.lblAddress, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.m_trvTime, 0);
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

        private void frmPICUShiftOutForm_Load(object sender, EventArgs e)
        {
            //m_mthGetICUEmployee();
        }
		#endregion

		/// <summary>
		/// 窗体ID，只针对允许作废重做的窗体
		/// </summary>		
		protected override int m_IntSubFormID
		{
			get
			{
				return 26;
			}
		}

		protected override void m_mthSetShiftTurnInfo(clsPICUShiftTurnInfo p_objTurnInfo,clsPatient p_objPatient)
		{
			p_objTurnInfo.m_strInPatientID = p_objPatient.m_StrInPatientID;
            p_objTurnInfo.m_strINPATIENTDATE = p_objPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss");
			p_objTurnInfo.m_dtmTurnTime = m_dtpTurnTime.Value;

            p_objTurnInfo.m_strTurnFromEmployeeID = ((clsEmrEmployeeBase_VO)txtFromDoctor.Tag).m_strEMPNO_CHR;
            if (m_lblFromDeptDoctor.Tag != null)
            {
                //			if(p_objTurnInfo.m_strTurnFromEmployeeID != null)
                //				p_objTurnInfo.m_strTurnFromDeptID = p_objTurnInfo.m_objTurnFromDoctor.m_ObjDepartment;

                p_objTurnInfo.m_strTurnToEmployeeID = ((clsEmrEmployeeBase_VO)m_lblToDeptDoctor.Tag).m_strEMPNO_CHR;
            }

            p_objTurnInfo.m_strTurnToDeptID = m_ObjCurrentArea.m_strDEPTID_CHR;// ((clsDepartment)m_cboToDept.SelectedItem).m_StrDeptID;
		}

		protected override iCare.clsPICUShiftBaseDomain m_ObjShiftDomain
		{
			get
			{
				return m_objShiftOutDomain;
			}
		}

		protected override void m_mthSetBaseDept(clsPICUShiftInfo p_objShiftInfo)
		{
			//m_cboToDept.Text = p_objShiftInfo.m_objTurnInfo.m_strTurnToDeptName;
            //if (m_ObjCurrentArea != null)
            clsPatient objPatient = m_objBaseCurrentPatient;

            if (objPatient == null)
                m_lblTurnBaseDeptName.Text = "";
            else
            {
                clsDepartment objFromDept = m_objShiftOutDomain.m_objGetPatientLastFromDept(objPatient);
                if (objFromDept == null)
                    m_lblTurnBaseDeptName.Text = "";
                else
                    m_lblTurnBaseDeptName.Text = objFromDept.m_StrDeptID;
            }
		}
		
		protected override void m_mthResetBaseDept()
		{
			m_cboToDept.SelectedIndex = 0;
		}

		protected override void m_mthSetDefaultBaseDept()
		{
            //clsPatient objPatient = (clsPatient)txtInPatientID.Tag;

            //if(objPatient == null)
            //    m_cboToDept.SelectedIndex = 0;
            //else
            //{
            //    clsDepartment objFromDept = m_objShiftOutDomain.m_objGetPatientLastFromDept(objPatient);

            //    if(objFromDept == null)
            //        m_cboToDept.SelectedIndex = 0;
            //    else
            //    {
            //        for(int i=0;i<m_cboToDept.GetItemsCount();i++)
            //        {
            //            clsDepartment objDept = (clsDepartment)m_cboToDept.GetItem(i);

            //            if(objDept.m_StrDeptID == objFromDept.m_StrDeptID)
            //            {
            //                m_cboToDept.SelectedItem = objDept;
            //                break;
            //            }
            //        }
            //    }
            //}
		}
		
		protected override bool m_BlnIsShiftInRecord
		{
			get
			{
				return false;
			}
		}

		protected override iCare.clsPICUShiftTurnInfo m_objGetShiftTurnInfo()
		{
			return new clsPICUShiftOutTurnInfo();
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
		

#if Debug
		protected override void m_mthSetTestBaseDept(com.digitalwave.Utility.clsTestContentMaker p_objContentMaker)
		{
			m_cboToDept.SelectedIndex = p_objContentMaker.m_intNextSelectIndex(m_cboToDept,m_cboToDept.GetItemsCount()-1);
		}		
#endif

		private void m_mthGetICUEmployee()
		{			
			if(strDeptArr != null)
			{
				bool blnIsSame = false;
                if (m_ObjCurrentArea != null)
                {
                    for (int i = 0; i < strDeptArr.Length; i++)
                    {
                        if (m_ObjCurrentArea.m_strDEPTID_CHR.Trim() == strDeptArr[i].Trim())
                        {
                            blnIsSame = true;
                            break;
                        }
                    }
                }
				if(!blnIsSame)
				{
					MDIParent.ShowInformationMessageBox("非ICU不能开转出记录表！");
				}
			}
		}
	}
}

