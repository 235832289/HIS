using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Emr.StaticObject;
using com.digitalwave.emr.BEDExplorer;

namespace iCare
{
    public partial class frmEMR_HIS_CheckRequisition : frmHRPBaseForm, PublicFunction
    {
        #region 全局变量
        /// <summary>
        /// 入院登记号
        /// </summary>
        private string m_strRegisterID = string.Empty;
        /// <summary>
        /// 医嘱流水号
        /// </summary>
        private string m_strOrderID = string.Empty;
        /// <summary>
        /// 当前申请单内容
        /// </summary>
        private clsEMR_HIS_CheckRequisitionValue m_objRequisitionValue = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 医嘱系统-检查申请单
        /// </summary>
        private frmEMR_HIS_CheckRequisition()
        {
            InitializeComponent();

            m_mthSetRichTextBoxAttribInControl(this);

            m_ctlAreaPatientSelection.m_mthSetSubItemEnable(false, false, false, false);
        }

        /// <summary>
        /// 医嘱系统-检查申请单
        /// </summary>
        /// <param name="p_strRegisterID">入院登记号</param>
        /// <param name="p_strOrderID">医嘱流水号</param>
        internal frmEMR_HIS_CheckRequisition(string p_strRegisterID, string p_strOrderID)
            : this()
        {
            m_strRegisterID = p_strRegisterID;
            m_strOrderID = p_strOrderID;

            m_mthGetPatient();
            m_bgwGetRecord.RunWorkerAsync();
        }

        /// <summary>
        /// 医嘱系统-检查申请单
        /// </summary>
        /// <param name="p_strRegisterID">入院登记号</param>
        /// <param name="p_strOrderID">医嘱流水号</param>
        /// <param name="p_objRequisitionValue">申请单内容</param>
        internal frmEMR_HIS_CheckRequisition(string p_strRegisterID, string p_strOrderID, clsEMR_HIS_CheckRequisitionValue p_objRequisitionValue)
            : this()
        {
            m_strRegisterID = p_strRegisterID;
            m_strOrderID = p_strOrderID;
            m_objRequisitionValue = p_objRequisitionValue;

            m_mthGetPatient();
            m_bgwGetRecord.RunWorkerAsync();
        }
        #endregion

        #region 事件
        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            m_mthDeleteValue();
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            m_mthSaveValue();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_bgwGetRecord_DoWork(object sender, DoWorkEventArgs e)
        {
            m_mthGetRequisition();
        }

        private void m_bgwGetRecord_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            m_mthSetValueToUI();
        }

        private void m_cmdAddTemplate_Click(object sender, EventArgs e)
        {
            m_mthNewTemplate();
        }

        private void m_cmdAddCommonUse_Click(object sender, EventArgs e)
        {
            if (m_txtFocusedRichTextBox == null)
            {
                clsPublicFunction.ShowInformationMessageBox( "该输入框不能生成常用值或内容为空。");
                return;
            }
            m_txtFocusedRichTextBox.Focus();
            m_mthNewCommonUse();
        }

        private void m_cmdSetDefault_Click(object sender, EventArgs e)
        {
            clsDefaultValueTool objTool = new clsDefaultValueTool(this, MDIParent.s_ObjCurrentPatient);

            if (objTool != null)
            {
                if (clsPublicFunction.ShowQuestionMessageBox(this, "注意！保存默认值后将会覆盖原来的默认值，这样可能会引起数据混乱，在未确定您所输入的默认值是否为正常的默认值时，请不要随便保存，是否继续？") == DialogResult.Yes)
                    objTool.m_mthSaveDefaultValue();
            }
        }

        private void m_cmdResetDefault_Click(object sender, EventArgs e)
        {
            clsDefaultValueTool objTool = new clsDefaultValueTool(this, MDIParent.s_ObjCurrentPatient);

            if (objTool != null)
            {
                if (clsPublicFunction.ShowQuestionMessageBox(this, "是否重置默认值？") == DialogResult.Yes)
                {
                    objTool.m_BlnReplaceDataShare = false;
                    objTool.m_mthSetDefaultValue();
                }
            }
        }
        #endregion

        #region 方法
        #region 根据入院登记号获取病人信息
        /// <summary>
        /// 根据入院登记号获取病人信息
        /// </summary>
        private void m_mthGetPatient()
        {
            clsPatient ObjCurrentPatient = new clsPatient(true, m_strRegisterID);

            m_lblInDate.Text = ObjCurrentPatient.m_DtmSelectedHISInDate.ToString("yyyy年MM月dd日 HH:mm:ss");

            clsHospitalManagerDomain objMain = new clsHospitalManagerDomain();
            clsEmrDept_VO objDeptNew;
            objMain.m_lngGetSpecialDeptInfo(ObjCurrentPatient.m_strDeptNewID, out objDeptNew);
            frmHRPExplorer.objpCurrentDepartment = objDeptNew;
            if (m_ctlAreaPatientSelection.m_BlnIsInUse)
                m_ctlAreaPatientSelection.m_mthSetPatient(ObjCurrentPatient.m_strAreaNewID, ObjCurrentPatient.m_StrPatientID, m_strRegisterID);
            else
                m_mthSetPatientInfo(ObjCurrentPatient);
        }
         #endregion

        #region 获取申请单内容
        /// <summary>
        /// 获取申请单内容
        /// </summary>
        private void m_mthGetRequisition()
        {
            if (m_objRequisitionValue == null)
            {
                clsEMR_HIS_CheckRequisitionDomain objDomain = new clsEMR_HIS_CheckRequisitionDomain();
                long lngRes = objDomain.m_lngGetCheckRequisitionValue(m_strRegisterID, m_strOrderID, out m_objRequisitionValue);
                objDomain = null;
            }
        }
        #endregion

        #region 设置内容至界面
        private void m_mthSetValueToUI()
        {
            MDIParent.s_ObjSaveCue.m_mthRemoveForm(this);
            chkModifyWithoutMatk.Checked = true;
            if (m_objRequisitionValue != null)
            {
                m_dtpRecordDate.Value = m_objRequisitionValue.m_dtmRECORDDATE_DAT;
                m_txtAdmissionDiagnosis.Text = m_objRequisitionValue.m_strADMISSIONDIAGNOSIS_VCHR;
                m_txtCaseSummary.Text = m_objRequisitionValue.m_strCASESUMMARY_VCHR;
                m_txtPhysExam.Text = m_objRequisitionValue.m_strPHYSEXAM_VCHR;
            }
            else
            {
                try
                {
                    m_mthSetSpecialPatientTemplateSet(m_objBaseCurrentPatient);
                    //默认值
                    new clsDefaultValueTool(this, m_objBaseCurrentPatient).m_mthSetDefaultValue();
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }                
            }
            MDIParent.s_ObjSaveCue.m_mthAddFormStatus(this);
        }
        #endregion

        #region 保存申请单内容
        /// <summary>
        /// 保存申请单内容
        /// </summary>
        private void m_mthSaveValue()
        {
            clsEMR_HIS_CheckRequisitionDomain objDomain = new clsEMR_HIS_CheckRequisitionDomain();
            long lngRes = 0;
            if (m_objRequisitionValue == null)
            {
                m_objRequisitionValue = new clsEMR_HIS_CheckRequisitionValue();
                m_objRequisitionValue.m_dtmRECORDDATE_DAT = m_dtpRecordDate.Value;
                m_objRequisitionValue.m_strPHYSEXAM_VCHR = m_txtPhysExam.Text;
                m_objRequisitionValue.m_strCASESUMMARY_VCHR = m_txtCaseSummary.Text;
                m_objRequisitionValue.m_strADMISSIONDIAGNOSIS_VCHR = m_txtAdmissionDiagnosis.Text;
                m_objRequisitionValue.m_strCREATEUSERID = clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR;
                m_objRequisitionValue.m_strREGISTERID_CHR = m_strRegisterID;
                m_objRequisitionValue.m_strORDERID_CHR = m_strOrderID;
                lngRes = objDomain.m_lngAddNewRequisition(m_objRequisitionValue);
            }
            else
            {
                m_objRequisitionValue.m_dtmRECORDDATE_DAT = m_dtpRecordDate.Value;
                m_objRequisitionValue.m_strPHYSEXAM_VCHR = m_txtPhysExam.Text;
                m_objRequisitionValue.m_strCASESUMMARY_VCHR = m_txtCaseSummary.Text;
                m_objRequisitionValue.m_strADMISSIONDIAGNOSIS_VCHR = m_txtAdmissionDiagnosis.Text;
                m_objRequisitionValue.m_strREGISTERID_CHR = m_strRegisterID;
                m_objRequisitionValue.m_strORDERID_CHR = m_strOrderID;
                lngRes = objDomain.m_lngModifyRequisition(m_objRequisitionValue);
            }
            objDomain = null;

            if (lngRes > 0)
            {
                DialogResult drSuccess = MessageBox.Show("保存成功！" + System.Environment.NewLine + "是否关闭当前窗体？", "检查申请单", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (drSuccess == DialogResult.Yes)
                {
                    MDIParent.s_ObjSaveCue.m_mthRemoveForm(this);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("保存失败！" , "检查申请单", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region 删除申请单内容
        /// <summary>
        /// 删除申请单内容
        /// </summary>
        private void m_mthDeleteValue()
        {
            if (m_objRequisitionValue == null)
            {
                return;
            }

            clsEMR_HIS_CheckRequisitionDomain objDomain = new clsEMR_HIS_CheckRequisitionDomain();
            long lngRes = objDomain.m_lngDeleteRequisition(clsEMR_StaticObject.s_ObjCurrentEmployee.m_strEMPID_CHR, m_objRequisitionValue.m_strREGISTERID_CHR, m_objRequisitionValue.m_strORDERID_CHR);
            objDomain = null;

            if (lngRes > 0)
            {
                m_mthClear();
                DialogResult drSuccess = MessageBox.Show("删除成功！" + System.Environment.NewLine + "是否关闭当前窗体？", "检查申请单", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (drSuccess == DialogResult.Yes)
                {
                    MDIParent.s_ObjSaveCue.m_mthRemoveForm(this);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("删除失败！", "检查申请单", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region 清空当前记录
        /// <summary>
        /// 清空当前记录
        /// </summary>
        private void m_mthClear()
        {
            m_objRequisitionValue = null;
            m_dtpRecordDate.Value = DateTime.Now;
            m_txtAdmissionDiagnosis.Clear();
            m_txtCaseSummary.Clear();
            m_txtPhysExam.Clear();
        } 
        #endregion

        #region RichTextBox相关
        /// <summary>
        /// 设置RichTetxtBox
        /// </summary>
        /// <param name="p_ctlControl"></param>
        protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
        {
            if (p_ctlControl.GetType().FullName == "com.digitalwave.controls.ctlRichTextBox")
            {
                m_mthSetRichTextBoxAttrib((com.digitalwave.controls.ctlRichTextBox)p_ctlControl);
            }

            if (p_ctlControl.HasChildren && p_ctlControl.GetType().Name != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextBoxAttribInControl(subcontrol);
                }
            }
        }

        /// <summary>
        /// 设置RichTextBox属性
        /// </summary>
        /// <param name="p_objRichTextBox"></param>
        protected void m_mthSetRichTextBoxAttrib(Control p_objRichTextBox)
        {
            if (p_objRichTextBox is com.digitalwave.controls.ctlRichTextBox)
            {
                ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);

                //设置其他属性			
                ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserID = clsEMRLogin.LoginInfo.m_strEmpID;
                ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserName = clsEMRLogin.LoginInfo.m_strEmpName;
                ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_ClrOldPartInsertText = Color.Black;
                ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_ClrDST = Color.Red;
            }
        }

        /// <summary>
        /// 设置双划线
        /// </summary>
        protected void m_mthSetRichTextBoxDoubleStrike()
        {
            if (m_txtFocusedRichTextBox != null)
            {
                if (m_txtFocusedRichTextBox is com.digitalwave.controls.ctlRichTextBox)
                    ((com.digitalwave.controls.ctlRichTextBox)m_txtFocusedRichTextBox).m_mthSelectionDoubleStrikeThough(false);
            }
        }

        private Control m_txtFocusedRichTextBox = null;//存放当前获得焦点的RichTextBox
        private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
        {
            m_txtFocusedRichTextBox = ((Control)(sender));
        }

        #endregion

        #region PublicFunction 成员

        public void Copy()
        {
            Control ctlControl = this.ActiveControl;

            if (ctlControl is com.digitalwave.controls.ctlRichTextBox)
            {
                if (((com.digitalwave.controls.ctlRichTextBox)ctlControl).Text != "")
                {
                    ((com.digitalwave.controls.ctlRichTextBox)ctlControl).Copy();
                }
            }
        }

        public void Paste()
        {
            Control ctlControl = this.ActiveControl;

            if (ctlControl is com.digitalwave.controls.ctlRichTextBox)
            {
                ((com.digitalwave.controls.ctlRichTextBox)ctlControl).Paste();
            }
        }

        public void Cut()
        {
            return;
        }

        public void Delete()
        {
            return;
        }

        public void Display(string cardno, string sendcheckdate)
        {
            return;
        }

        public void Display()
        {
            return;
        }

        public void Print()
        {
            return;
        }

        public void Redo()
        {
            return;
        }

        public void Save()
        {
            return;
        }

        public void Undo()
        {
            return;
        }

        public void Verify()
        {
            return;
        }

        #endregion

        private void frmEMR_HIS_CheckRequisition_Load(object sender, EventArgs e)
        {
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
        }
        #endregion
    }
}