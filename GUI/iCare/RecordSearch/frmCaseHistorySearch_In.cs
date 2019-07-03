using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;
using iCare.iCareBaseForm;

namespace iCare
{
    public partial class frmCaseHistorySearch_In : frmBaseForm
    {
        #region 全局变量
        /// <summary>
        /// 当前病人
        /// </summary>
        private clsPatient m_objCurrentPatient = null; 
        #endregion

        #region 构造方法
        /// <summary>
        /// 住院史查询
        /// </summary>
        public frmCaseHistorySearch_In()
        {
            InitializeComponent();
        } 
        #endregion

        #region 窗体Load事件
        /// <summary>
        /// 窗体Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmCaseHistorySearch_In_Load(object sender, EventArgs e)
        {
            m_lblPatientName.Text = "";
            m_lblPatientSex.Text = "";
        } 
        #endregion

        #region 清空界面
        /// <summary>
        /// 清空界面
        /// </summary>
        private void m_mthClearUI()
        {
            m_lblPatientSex.Text = "";
            m_lblPatientName.Text = "";
            m_lsvDiagnoseDesc.Items.Clear();
            m_lsvInHospitalDesc.Items.Clear();
            m_lsvOpDesc.Items.Clear();
            m_dtpBirthDate.Value = DateTime.Now;
            m_dtpBirthDate.Visible = false;
        } 
        #endregion

        #region 病人标识KeyDown事件
        /// <summary>
        /// 病人标识KeyDown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_txtPatientID_KeyDown(object sender, KeyEventArgs e)
        {
            if (m_txtPatientID.Text.Trim() == string.Empty)
                return;

            if (e.KeyCode == Keys.Enter)
            {
                clsCaseHistorySearchDomain objDomain = new clsCaseHistorySearchDomain();
                try 
                {
                    this.Cursor = Cursors.WaitCursor;
                    m_objCurrentPatient = new clsPatient(m_txtPatientID.Text.Trim());
                    if (m_objCurrentPatient == null)
                    {
                        m_mthClearUI();
                        return;
                    }

                    m_lblPatientName.Text = m_objCurrentPatient.m_StrName;
                    m_lblPatientSex.Text = m_objCurrentPatient.m_StrSex;
                    if (m_objCurrentPatient.m_ObjPeopleInfo.m_DtmBirth != DateTime.MaxValue
                        && m_objCurrentPatient.m_ObjPeopleInfo.m_DtmBirth != new DateTime(1900, 1, 1))
                    {
                        m_dtpBirthDate.Value = m_objCurrentPatient.m_ObjPeopleInfo.m_DtmBirth;
                        m_dtpBirthDate.Visible = true;
                    }
                    else
                    {
                        m_dtpBirthDate.Visible = false;
                    }

                    DataTable dtResult = null;
                    long lngRes = objDomain.m_lngGetInAndOutInfo(m_objCurrentPatient.m_StrInPatientID, out dtResult);

                    if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                    {
                        m_mthSetInAndOutInfoToUI(dtResult);
                    }
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region 显示入出院情况到界面
        /// <summary>
        /// 显示入出院情况到界面
        /// </summary>
        /// <param name="p_dtbResult">查询结果</param>
        private void m_mthSetInAndOutInfoToUI(DataTable p_dtbResult)
        {
            m_lsvInHospitalDesc.Items.Clear();
            if (p_dtbResult == null || p_dtbResult.Rows.Count <= 0)
                return;

            try
            {
                m_lsvInHospitalDesc.BeginUpdate();
                for (int i = 0; i < p_dtbResult.Rows.Count; i++)
                {
                    ListViewItem lst = new ListViewItem(new string[] { p_dtbResult.Rows[i]["InDate"].ToString(),
                    p_dtbResult.Rows[i]["InDeptName"].ToString(),
                    p_dtbResult.Rows[i]["OutDate"].ToString(),
                    p_dtbResult.Rows[i]["OutDeptName"].ToString()});
                    lst.Tag = p_dtbResult.Rows[i]["registerid_chr"].ToString();
                    m_lsvInHospitalDesc.Items.Add(lst);
                }
            }
            finally
            {
                m_lsvInHospitalDesc.EndUpdate();
                if (m_lsvInHospitalDesc.Items.Count > 0)
                {
                    m_lsvInHospitalDesc.Focus();
                    m_lsvInHospitalDesc.Items[0].Selected = true;
                }
            }
        } 
        #endregion

        #region 入出院情况ListView的SelectedIndexChanged事件
        private void m_lsvInHospitalDesc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_lsvInHospitalDesc.Items.Count > 0 && m_lsvInHospitalDesc.SelectedItems.Count > 0)
            {
                string strRegisterID = m_lsvInHospitalDesc.SelectedItems[0].Tag as string;
                if (strRegisterID == null || strRegisterID == string.Empty)
                    return;

                clsCaseHistorySearchDomain objDomain = new clsCaseHistorySearchDomain();
                clsInHospitalMainRecord_GX_Collection objCollection = null;
                long lngRes = objDomain.lngGetDiagnoseAndOpInfo(strRegisterID, out objCollection);

                if (lngRes > 0 && objCollection != null)
                {
                    m_mthSetDiagnoseToUI(objCollection);
                }
            }
        } 
        #endregion

        #region 显示诊断及手术信息到界面
        /// <summary>
        /// 显示诊断及手术信息到界面
        /// </summary>
        /// <param name="p_objCollection"></param>
        private void m_mthSetDiagnoseToUI(clsInHospitalMainRecord_GX_Collection p_objCollection)
        {
            m_lsvDiagnoseDesc.Items.Clear();
            m_lsvOpDesc.Items.Clear();
            if (p_objCollection == null || p_objCollection.m_objContent == null)
                return;

            try
            {
                this.Cursor = Cursors.WaitCursor;
                m_lsvDiagnoseDesc.BeginUpdate();
                m_lsvOpDesc.BeginUpdate();

                ListViewItem lst = null;

                lst = new ListViewItem(new string[]{"门诊诊断",p_objCollection.m_objContent.m_strDIAGNOSIS,
                    "","",p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                m_lsvDiagnoseDesc.Items.Add(lst);

                if (p_objCollection.m_objInDiagnosisArr != null && p_objCollection.m_objInDiagnosisArr.Length > 0)
                {
                    string strDiaName = "";
                    for (int i = 0; i < p_objCollection.m_objInDiagnosisArr.Length; i++)
                    {
                        if (i == 0)
                        {
                            strDiaName = "入院诊断";
                        }
                        else
                        {
                            strDiaName = "";
                        }
                        lst = new ListViewItem(new string[]{strDiaName,p_objCollection.m_objInDiagnosisArr[i].m_strDIAGNOSISDESC,
                            "","",p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                        m_lsvDiagnoseDesc.Items.Add(lst);
                    }
                }

                lst = new ListViewItem(new string[]{"出院诊断",p_objCollection.m_objContent.m_strMAINDIAGNOSIS,
                    m_strSetDiagnoseSeq(p_objCollection.m_objContent.m_intMAINCONDITIONSEQ),"",
                    p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                m_lsvDiagnoseDesc.Items.Add(lst);

                if (p_objCollection.m_objOtherDiagnosisArr != null && p_objCollection.m_objOtherDiagnosisArr.Length > 0)
                {
                    for (int i = 0; i < p_objCollection.m_objOtherDiagnosisArr.Length; i++)
                    {
                        lst = new ListViewItem(new string[]{"",p_objCollection.m_objOtherDiagnosisArr[i].m_strDIAGNOSISDESC,
                            m_strSetDiagnoseSeq(p_objCollection.m_objOtherDiagnosisArr[i].m_intCONDITIONSEQ),"",
                            p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                        m_lsvDiagnoseDesc.Items.Add(lst);
                    }
                }

                lst = new ListViewItem(new string[]{"并发症(含手术麻醉)",p_objCollection.m_objContent.m_strCOMPLICATION,
                    m_strSetDiagnoseSeq(p_objCollection.m_objContent.m_intCOMPLICATIONSEQ),"",
                    p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                m_lsvDiagnoseDesc.Items.Add(lst);

                lst = new ListViewItem(new string[]{"院内感染名称",p_objCollection.m_objContent.m_strINFECTIONDIAGNOSIS,
                    m_strSetDiagnoseSeq(p_objCollection.m_objContent.m_intINFECTIONCONDICTIONSEQ),"",
                    p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                m_lsvDiagnoseDesc.Items.Add(lst);

                lst = new ListViewItem(new string[]{"病理诊断",p_objCollection.m_objContent.m_strPATHOLOGYDIAGNOSIS,
                    m_strSetDiagnoseSeq(p_objCollection.m_objContent.m_intPATHOLOGYDIAGNOSISSEQ),"",
                    p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                m_lsvDiagnoseDesc.Items.Add(lst);

                lst = new ListViewItem(new string[]{"操作和中毒的外部原因",p_objCollection.m_objContent.m_strSCACHESOURCE,
                    "","", p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                m_lsvDiagnoseDesc.Items.Add(lst);

                if ((p_objCollection.m_objContent.m_strNEONATEDISEASE1 != null && p_objCollection.m_objContent.m_strNEONATEDISEASE1 != string.Empty)
                    || (p_objCollection.m_objContent.m_strNEONATEDISEASE2 != null && p_objCollection.m_objContent.m_strNEONATEDISEASE2 != string.Empty)
                    || (p_objCollection.m_objContent.m_strNEONATEDISEASE3 != null && p_objCollection.m_objContent.m_strNEONATEDISEASE3 != string.Empty)
                    || (p_objCollection.m_objContent.m_strNEONATEDISEASE4 != null && p_objCollection.m_objContent.m_strNEONATEDISEASE4 != string.Empty))
                {
                    lst = new ListViewItem(new string[]{"新生儿疾病诊断",p_objCollection.m_objContent.m_strNEONATEDISEASE1,
                    "","", p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                    m_lsvDiagnoseDesc.Items.Add(lst);
                    lst = new ListViewItem(new string[]{"",p_objCollection.m_objContent.m_strNEONATEDISEASE2,
                    "","", p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                    m_lsvDiagnoseDesc.Items.Add(lst);
                    lst = new ListViewItem(new string[]{"",p_objCollection.m_objContent.m_strNEONATEDISEASE3,
                    "","", p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                    m_lsvDiagnoseDesc.Items.Add(lst);
                    lst = new ListViewItem(new string[]{"",p_objCollection.m_objContent.m_strNEONATEDISEASE4,
                    "","", p_objCollection.m_objContent.m_dtmCONFIRMDIAGNOSISDATE.ToString("yyyy年MM月dd日")});
                    m_lsvDiagnoseDesc.Items.Add(lst);
                }

                if (p_objCollection.m_objOperationArr != null && p_objCollection.m_objOperationArr.Length > 0)
                {
                    for (int i = 0; i < p_objCollection.m_objOperationArr.Length; i++)
                    {
                        lst = new ListViewItem(new string[]{p_objCollection.m_objOperationArr[i].m_strOPERATIONNAME,
                            p_objCollection.m_objOperationArr[i].m_strOPERATIONAANAESTHESIAMODENAME,
                            p_objCollection.m_objOperationArr[i].m_strOPERATORNAME,
                            p_objCollection.m_objOperationArr[i].m_dtmOPERATIONDATE.ToString("yyyy年MM月dd日")});
                        m_lsvOpDesc.Items.Add(lst);
                    }
                }
            }
            finally
            {
                m_lsvDiagnoseDesc.EndUpdate();
                m_lsvOpDesc.EndUpdate();
                this.Cursor = Cursors.Default;
            }
        } 
        #endregion

        #region 根据标识返回相应的治疗结果
        /// <summary>
        /// 根据标识返回相应的治疗结果
        /// </summary>
        /// <param name="p_intSeq"></param>
        /// <returns></returns>
        private string m_strSetDiagnoseSeq(int p_intSeq)
        {
            switch (p_intSeq)
            {
                case 0:
                    return "治愈";
                case 1:
                    return "好转";
                case 2:
                    return "未愈";
                case 3:
                    return "死亡";
                case 4:
                    return "其他";
                case 5:
                    return "正常分娩";
                default:
                    return "";
            }
        } 
        #endregion 

        #region 清空按钮的Click事件
        private void m_cmdClear_Click(object sender, EventArgs e)
        {
            m_txtPatientID.Clear();
            m_mthClearUI();
        } 
        #endregion

        #region 关闭窗体
        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion
    }
}