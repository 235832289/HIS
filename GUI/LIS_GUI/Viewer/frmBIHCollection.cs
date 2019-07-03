using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 病区采集界面
    /// </summary>
    public partial class frmBIHSampleCollection : frmMDI_Child_Base
    {
        public frmBIHSampleCollection()
        {
            InitializeComponent();
        }

        #region 私有成员

        private clsSampleCollectionController m_objController = new clsSampleCollectionController();
        private clsLisApplMainVO[] m_arrApplications = new clsLisApplMainVO[0];
        private clsSealedBIHLisApplyReportPrint m_objPrint = new clsSealedBIHLisApplyReportPrint();

        /// <summary>
        /// 申请单样式 0 普通式 1 伦教式
        /// </summary>
        private int BillStyle = 0;

        /// <summary>
        /// 微信推送信息地址
        /// </summary>
        string WechatWebUrl { get; set; }

        #endregion

        #region 事件实现

        private void frmBIHCollection_Load(object sender, EventArgs e)
        {
            m_mthSetFormControlCanBeNull(this);
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { });

            FormLoadInit();
            m_cmdSearch.Focus();

            //get parm value
            BillStyle = clsPublic.m_intGetSysParm("4009");
            m_cboSearchCollectionType.SelectedIndex = 2;
            m_cboQualified.SelectedIndex = 0;

            #region Wechat
            string tmpStr = clsPublic.m_strGetSysparm("1010");
            if (!string.IsNullOrEmpty(tmpStr) && tmpStr.Trim() != "")
            {
                this.WechatWebUrl = tmpStr.Trim();
            }
            #endregion
        }

        private void m_cmdSubmitBarCode_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.m_cmdSubmitBarCode.Enabled = false;

            this.m_mthConfirm();
            Cursor.Current = Cursors.Default;
        }

        private void m_cmdModifyBarCode_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此样本的条码将被修改！", "iCare-LIS", MessageBoxButtons.OKCancel) != DialogResult.OK)
            {
                return;
            }
            if (this.m_lsvApplication.SelectedItems != null && this.m_lsvApplication.SelectedItems.Count > 0)
            {
                if ((clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag != null)
                {
                    clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;
                    long lngRes = 0;
                    int intStatus;
                    lngRes = this.m_objController.m_lngFindStatusBySampleID(objAppVO.m_strSampleID, out intStatus);
                    if (lngRes < 0)
                    {
                        MessageBox.Show(this, "操作失败！", "检验采集信息提示");
                    }
                    if (intStatus != 8)
                    {
                        if (intStatus >= 3 && intStatus <= 6)
                        {
                            MessageBox.Show(this, "该样本已核收，不允许修改！", "检验采集信息提示");
                        }
                        else
                        {
                            lngRes = 0;
                            lngRes = this.m_objController.m_lngModifyBarCode(objAppVO.m_strSampleID, objAppVO.m_strAPPLICATION_ID);
                            if (lngRes < 0)
                            {
                                MessageBox.Show(this, "删除原有信息失败！", "检验采集信息提示");
                            }

                            objAppVO.m_intSampleStatus = 1;
                            objAppVO.m_strSampleID = "";
                            this.m_lsvApplication.SelectedItems[0].Text = "";
                            this.m_lsvApplication.SelectedItems[0].SubItems[3].Text = "";
                            this.m_lsvApplication.SelectedItems[0].BackColor = Color.White;
                            this.m_lsvApplication_Click(null, null);
                        }
                    }
                    else
                    {
                        //MessageBox.Show(this, "读取样本状态信息失败", "检验采集信息提示");
                    }
                }
            }
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            this.m_cmdSearch.Enabled = false;
            this.m_cboBarCodeType.SelectedIndex = 2;
            this.m_cboPrintStyle.SelectedIndex = 2;

            this.CollectionQuery();

            m_lsvApplication.ListViewItemSorter = new ListViewItemComparer(1, true, m_lsvApplication);
            m_lsvApplication.Sort();

            this.m_cmdSearch.Enabled = true;

            Cursor.Current = Cursors.Default;
        }

        private void m_dtpSearchEnd_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Right)
            {
                DateTime dtEndTime = DateTime.MinValue;
                DateTime dtStartTime = DateTime.MinValue;
                try
                {
                    dtStartTime = Convert.ToDateTime(this.m_dtpSearchBegin.Text.Trim());

                }
                catch
                {
                    dtStartTime = DateTime.MinValue;
                }

                try
                {
                    dtEndTime = Convert.ToDateTime(this.m_dtpSearchEnd.Text.Trim());

                }
                catch
                {
                    dtEndTime = DateTime.MinValue;
                }
                if (dtStartTime > dtEndTime && dtEndTime != DateTime.MinValue)
                {
                    ShowMessage("结束时间不能少于开始时间!");
                    m_dtpSearchEnd.Focus();
                    return;
                }
            }
        }

        private void m_cboBarCodeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadApplicationList(GetApplArrayByCondition());
        }

        private void m_cmdChangeEmergency_Click(object sender, EventArgs e)
        {
            if (this.m_lsvApplication.SelectedItems.Count > 0 && (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag != null)
            {
                clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;

                if (objAppVO.m_intEmergency == 1)
                {
                    objAppVO.m_intEmergency = 0;
                }
                else if (objAppVO.m_intEmergency == 0)
                {
                    objAppVO.m_intEmergency = 1;
                }

                long lngRes = m_objController.m_lngChangeEmergency(objAppVO);
                if (lngRes > 0)
                {
                    this.m_lsvApplication.SelectedItems[0].Tag = objAppVO;

                    if (objAppVO.m_intEmergency == 1)
                    {
                        this.m_lsvApplication.SelectedItems[0].ForeColor = Color.Red;
                        this.m_txtFlagEmergency.Text = "急诊";
                    }
                    else
                    {
                        this.m_lsvApplication.SelectedItems[0].ForeColor = Color.Black;
                        this.m_txtFlagEmergency.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("更新急诊标志失败。");
                }
            }
        }

        private void m_txtSearchBedNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdSearch_Click(null, EventArgs.Empty);
            }
        }

        private void m_txtBarCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdSubmitBarCode_Click(null, EventArgs.Empty);
            }
        }

        private void m_txtSearchCardId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_txtSearchCardId.Text.Length < 10 && m_txtSearchCardId.Text.Length > 0)
                {
                    string strCardID = "";
                    strCardID = "0000000000" + this.m_txtSearchCardId.Text;
                    this.m_txtSearchCardId.Text = strCardID.Substring(strCardID.Length - 10);
                }
            }
        }

        private void frmBIHSampleCollection_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                m_cmdSearch_Click(null, EventArgs.Empty);
            }

            if (e.KeyCode == Keys.F4 && this.m_cmdSubmitBarCode.Enabled)
            {
                m_cmdSubmitBarCode_Click(null, EventArgs.Empty);
            }
        }

        private void m_cmdSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdSearch_Click(null, EventArgs.Empty);
            }
        }

        #endregion

        #region 病区控件

        private void m_ctlFindArea_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            //add by wjqin(06-06-9)
            //clsBIHOrderService m_objService = new clsBIHOrderService();
            /*<----------------------------------------*/
            this.m_txtApplArea.Tag = null;
            clsBIHArea[] arrArea;
            long ret = this.m_objController.m_lngFindArea(strFindCode, out arrArea);
            if ((ret > 0) && (arrArea != null))
            {
                //获取有权限访问的病区ID集合
                if (this.LoginInfo != null)
                {
                    IList ilUsableAreaID = this.LoginInfo.m_ilUsableAreaID;
                    arrArea = (clsBIHArea[])(GetUsableAreaObject(arrArea, ilUsableAreaID)).ToArray(typeof(clsBIHArea));
                }
                for (int i = 0; i < arrArea.Length; i++)
                {
                    /** @update by xzf (05-09-20)
                     * 
                     */
                    ListViewItem lvi = lvwList.Items.Add(arrArea[i].code);
                    lvi.SubItems.Add(arrArea[i].m_strAreaName);
                    /* <<================================== */
                    lvi.Tag = arrArea[i].m_strAreaID;
                }
            }

        }

        private void m_ctlFindArea_m_evtInitListView(ListView lvwList)
        {
            //@lvwList.Columns.Add("",120,HorizontalAlignment.Left);
            //@lvwList.Width=140;
            /** update by xzf (05-09-20) */
            lvwList.Columns.Add("病区编号", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("病区名称", 100, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 180;
            /* <<================================= */
        }

        private void m_ctlFindArea_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_txtSearchArea.Text = lviSelected.SubItems[1].Text;
                m_txtSearchArea.Tag = lviSelected.Tag;
            }
        }

        private void m_ctlFindArea_DoubleClick(object sender, EventArgs e)
        {
            this.m_txtSearchArea.Text = "";
            SendKeys.Send("{ENTER}");
        }

        /// <summary>
        /// 过滤出有权限的病区




        /// </summary>
        /// <param name="p_objArea">病区对象</param>
        /// <param name="p_ilUsableAreaID">有权访问的病区ID集合</param>
        /// <returns>有权访问的病区对象集合</returns>
        public ArrayList GetUsableAreaObject(clsBIHArea[] p_objArea, IList p_ilUsableAreaID)
        {
            ArrayList ilRes = new ArrayList();
            if (p_objArea == null || p_objArea.Length <= 0) return ilRes;

            //全部的可访问的病区对象




            for (int i1 = 0; i1 < p_objArea.Length; i1++)
            {
                if (p_objArea[i1] == null) continue;
                if (p_ilUsableAreaID.Contains(p_objArea[i1].m_strAreaID.Trim()))
                {
                    if (!(ilRes.Contains(p_objArea[i1])))
                        ilRes.Add(p_objArea[i1]);
                }
            }
            return ilRes;
        }

        #endregion

        #region 方法实现

        private void FormLoadInit()
        {
            this.m_txtSearchArea.Tag = this.LoginInfo.m_strInpatientAreaID;
            this.m_txtSearchArea.Text = this.LoginInfo.m_strInpatientAreaName;

            this.m_cboBarCodeType.SelectedIndexChanged -= m_cboBarCodeType_SelectedIndexChanged;
            this.m_cboPrintStyle.SelectedIndexChanged -= m_cboPrintStyle_SelectedIndexChanged;

            this.m_cboBarCodeType.SelectedIndex = 2;
            this.m_cboPrintStyle.SelectedIndex = 2;
            this.m_cboBarCodeType.SelectedIndexChanged += m_cboBarCodeType_SelectedIndexChanged;
            this.m_cboPrintStyle.SelectedIndexChanged += m_cboPrintStyle_SelectedIndexChanged;

            this.m_cboSearchCollectionType.SelectedIndex = 0;

            m_dtpSearchBegin.Text = DateTime.Now.ToString("yyyy年MM月dd日00时00分");
            m_dtpSearchEnd.Text = DateTime.Now.ToString("yyyy年MM月dd日23时59分");
        }

        /// <summary>
        /// 获取样本VO
        /// </summary>
        private clsT_OPR_LIS_SAMPLE_VO GetSampleVO(clsLisApplMainVO objAppVO)
        {
            clsT_OPR_LIS_SAMPLE_VO objSampleVO = new clsT_OPR_LIS_SAMPLE_VO();
            objSampleVO.m_strAPPL_DAT = objAppVO.m_strAppl_Dat;

            objSampleVO.m_strSEX_CHR = objAppVO.m_strSex;
            objSampleVO.m_strPATIENT_NAME_VCHR = objAppVO.m_strPatient_Name;
            objSampleVO.m_strPATIENT_SUBNO_CHR = objAppVO.m_strPatient_SubNO;
            objSampleVO.m_strAGE_CHR = objAppVO.m_strAge;
            objSampleVO.m_strPATIENT_TYPE_CHR = objAppVO.m_strPatientType;
            objSampleVO.m_strDIAGNOSE_VCHR = objAppVO.m_strDiagnose;
            objSampleVO.m_strBEDNO_CHR = objAppVO.m_strBedNO;
            objSampleVO.m_strICD_VCHR = objAppVO.m_strICD;
            objSampleVO.m_strPATIENTCARDID_CHR = objAppVO.m_strPatientcardID;
            objSampleVO.m_strPATIENTID_CHR = objAppVO.m_strPatientID;
            objSampleVO.m_strAPPL_EMPID_CHR = objAppVO.m_strAppl_EmpID;
            objSampleVO.m_strAPPL_DEPTID_CHR = objAppVO.m_strAppl_DeptID;
            objSampleVO.m_strAPPLICATION_ID_CHR = objAppVO.m_strAPPLICATION_ID;
            objSampleVO.m_strPATIENT_INHOSPITALNO_CHR = objAppVO.m_strPatient_inhospitalno_chr;
            objSampleVO.m_strSAMPLE_TYPE_ID_CHR = objAppVO.m_strSampleID;
            objSampleVO.m_strSAMPLETYPE_VCHR = objAppVO.m_strSampleType;

            //已采集标志				
            objSampleVO.m_intSTATUS_INT = 2;
            objSampleVO.m_strQCSAMPLEID_CHR = "-1";
            objSampleVO.m_strSAMPLEKIND_CHR = "1";

            objSampleVO.m_strSAMPLE_ID_CHR = null;

            objSampleVO.m_strSAMPLESTATE_VCHR = null;

            objSampleVO.m_strBARCODE_VCHR = this.m_txtBarCode.Text.Trim();

            objSampleVO.m_strOPERATOR_ID_CHR = this.LoginInfo.m_strEmpID;

            objSampleVO.m_strSAMPLING_DATE_DAT = this.m_dtpCollectionTime.Value.ToString("yyyy-MM-dd HH:mm:ss").Trim();

            objSampleVO.m_strCOLLECTOR_ID_CHR = this.LoginInfo.m_strEmpID;
            return objSampleVO;
        }

        /// <summary>
        /// 显示选中的患者信息




        /// </summary>
        private void SelectedApplication()
        {
            m_mthResetAll();

            if (m_lsvApplication.Items.Count <= 0) { return; }

            clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;
            if (objAppVO != null)
            {
                ShowPatientInfo(objAppVO);
            }
        }

        private void ShowPatientInfo(clsLisApplMainVO objAppVO)
        {
            // 患者信息
            this.m_txtPatientName.Text = objAppVO.m_strPatient_Name;
            this.m_txtInHospitalNo.Text = objAppVO.m_strPatient_inhospitalno_chr;
            this.m_txtSex.Text = objAppVO.m_strSex;
            this.m_txtAge.Text = objAppVO.m_strAge;
            this.m_txtBedNo.Text = objAppVO.m_strBedNO;
            this.m_txtApplArea.m_StrDeptID = objAppVO.m_strAppl_DeptID;
            this.m_txtApplDoctor.m_StrEmployeeID = objAppVO.m_strAppl_EmpID;

            try
            {
                this.m_dtpApplTime.Value = DateTime.Parse(objAppVO.m_strAppl_Dat);
            }
            catch
            {
                this.m_dtpApplTime.Value = DateTime.Parse("1900-01-01 00:00:00");
            }

            if (objAppVO.m_intEmergency == 1)
            {
                this.m_txtFlagEmergency.Text = "急诊";
            }
            else
            {
                this.m_txtFlagEmergency.Text = "";
            }
            this.m_txtChargeItemName.Text = objAppVO.m_strChargeInfo;

            // 采样信息
            this.m_txtSampleType.Text = objAppVO.m_strSampleType;
            this.m_txtCheckContent.Text = objAppVO.m_strCheckContent;

            clsSampleGroup_VO[] objSampleGroupVOArr = null;
            long lngResExt = this.m_objController.m_lngGetSampleRemark(objAppVO.m_strAPPLICATION_ID, out objSampleGroupVOArr);
            if (lngResExt > 0 && objSampleGroupVOArr != null)
            {
                string strSampleRule = "";
                for (int i = 0; i < objSampleGroupVOArr.Length; i++)
                {
                    strSampleRule += objSampleGroupVOArr[i].strSampleGroupName + ": " + objSampleGroupVOArr[i].strRemark + "\r\n";
                }
                this.m_txtCollectionRule.Text = strSampleRule;
            }

            if (objAppVO.m_intSampleStatus >= 2)
            {
                clsT_OPR_LIS_SAMPLE_VO objSample = null;
                long lngRes = this.m_objController.m_lngGetSampleBySampleID(objAppVO.m_strSampleID, out objSample);
                if (lngRes > 0 && objSample != null)
                {
                    this.m_txtOperator.m_StrEmployeeID = (objSample.m_strCOLLECTOR_ID_CHR == "" ? null : objSample.m_strCOLLECTOR_ID_CHR.Trim());
                    this.m_txtBarCode.Text = objSample.m_strBARCODE_VCHR;
                    try
                    {
                        this.m_dtpCollectionTime.Value = DateTime.Parse(objSample.m_strSAMPLING_DATE_DAT);
                    }
                    catch
                    {
                        this.m_dtpCollectionTime.Value = DateTime.Parse("1900-01-01 00:00:00");
                    }
                }
                else if (lngRes > 0)
                {
                    //ShowMessage("样本不存在!");
                }
                else
                {
                    m_dtpCollectionTime.Value = DateTime.Parse("1900-01-01 00:00:00");
                    ShowMessage("操作失败!");
                }

                this.m_txtSampleType.Enabled = false;
                this.m_txtBarCode.Enabled = false;
                this.m_txtOperator.Enabled = false;
                this.m_dtpCollectionTime.Enabled = false;
                this.m_txtCollectionRule.Enabled = false;

                this.m_cmdSubmitBarCode.Enabled = false;
                this.m_lsvApplication.SelectedItems[0].Focused = true;
            }
            else
            {
                this.m_txtOperator.m_StrEmployeeID = this.LoginInfo.m_strEmpID;
                this.m_pnlSampleInfo.Enabled = true;
                this.m_txtSampleType.Enabled = true;
                this.m_txtBarCode.Enabled = true;
                this.m_txtOperator.Enabled = true;
                this.m_dtpCollectionTime.Enabled = true;
                this.m_txtCollectionRule.Enabled = true;

                this.m_cmdSubmitBarCode.Enabled = true;

                this.m_txtBarCode.Focus();
            }
            this.btnModify.Visible = false;
        }

        private void m_mthResetAll()
        {
            clsControlCleanUpUtil cleanAssist = new clsControlCleanUpUtil();
            cleanAssist.m_mthCleanUp(this.m_pnlSampleInfo, new clsControlCleanUpUtil_TypePara(null, new Type[] { typeof(Label) }));

            this.m_txtSampleType.Clear();
            this.m_txtCollectionRule.Clear();
            this.m_txtBarCode.Clear();
            this.m_txtOperator.m_mthClear();
            this.m_dtpCollectionTime.Value = DateTime.Now;

            this.m_txtPatientName.Text = string.Empty;
            this.m_txtInHospitalNo.Text = string.Empty;
            this.m_txtSex.Text = string.Empty;
            this.m_txtAge.Text = string.Empty;
            this.m_txtBedNo.Text = string.Empty;
            this.m_txtApplArea.m_StrDeptID = string.Empty;
            //this.m_txtApplDoctor.m_StrEmployeeID = string.Empty;
            this.m_txtFlagEmergency.Text = string.Empty;

            this.m_txtChargeItemName.Text = string.Empty;
        }

        /// <summary>
        /// 获取Barcode
        /// </summary>
        /// <param name="applID">申请单ID</param>
        /// <returns>Barcode</returns>
        private string GetBarcode(string sampleID)
        {
            clsT_OPR_LIS_SAMPLE_VO objSample = null;
            long lngRes = this.m_objController.m_lngGetSampleBySampleID(sampleID, out objSample);
            if (lngRes > 0 && objSample != null)
            {
                return objSample.m_strBARCODE_VCHR;
            }
            return string.Empty;
        }

        /// <summary>
        /// 根据部门ID获取部门名称
        /// </summary>
        /// <param name="deptID">部门ID</param>
        /// <returns>部门名称</returns>
        private string GetDeptName(string deptID)
        {
            com.digitalwave.Utility.ctlDeptTextBox deptTextbox = new ctlDeptTextBox();
            deptTextbox.m_StrDeptID = deptID;
            return deptTextbox.m_StrDeptName;
        }

        private int CompareApplMain(clsLisApplMainVO x, clsLisApplMainVO y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    return 0;
                }
                else { return -1; }
            }
            else
            {
                if (y == null)
                {
                    return 1;
                }
                else
                {
                    int intDept = string.Compare(x.m_strSummary, y.m_strSummary);
                    if (intDept == 0)
                    {
                        int intBed = string.Compare(x.m_strBedNO, y.m_strBedNO);
                        if (intBed == 0)
                        {
                            return string.Compare(x.m_strSampleType, y.m_strSampleType);
                        }
                        else { return intBed; }
                    }
                    else { return intDept; }
                }
            }
        }

        private void ShowMessage(string message)
        {
            MessageBox.Show(message, "系统提示!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private clsLisApplMainVO[] GetApplArrayByCondition()
        {
            int barcodeIndex = m_cboBarCodeType.SelectedIndex;
            int printIndex = m_cboPrintStyle.SelectedIndex;
            List<clsLisApplMainVO> dumpContainer = new List<clsLisApplMainVO>();

            foreach (clsLisApplMainVO appl in m_arrApplications)
            {
                bool isAddBarcode = barcodeIndex == 2 || (barcodeIndex == 0 && appl.m_blnHasBarcode)
                                                      || (barcodeIndex == 1 && !appl.m_blnHasBarcode);

                bool isAddPrint = printIndex == 2 || (printIndex == 0 && appl.m_isPrinted)
                                                  || (printIndex == 1 && !appl.m_isPrinted);

                if (isAddBarcode && isAddPrint)
                {
                    dumpContainer.Add(appl);
                }
            }

            return dumpContainer.ToArray();
        }

        #endregion

        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        private void CollectionQuery()
        {
            clsLisApplMainVO[] arrApplication = null;
            string strFromDate = this.m_dtpSearchBegin.Text;
            string strToDate = this.m_dtpSearchEnd.Text;

            // 查找病区
            string areaID = this.m_txtSearchArea.Tag as string;
            if (this.m_txtSearchArea.Text == string.Empty || areaID == null)
            {
                ShowMessage("请选择申请病区!");
                return;
            }

            string strAppDeptID = areaID;

            // 采集状态
            int intStatus = 0;
            switch (this.m_cboSearchCollectionType.SelectedIndex)
            {
                case 0: intStatus = 1; break;
                case 1: intStatus = 2; break;
                case 2: intStatus = 3; break;
                case 3: intStatus = 4; break;
                case 4: intStatus = 0; break;

                default:
                    break;
            }
            int intSampleBack = 3;
            switch (m_cboQualified.SelectedIndex)
            {
                case 0: intSampleBack = 0; break;
                case 1: intSampleBack = 1; break;
                default:
                    intSampleBack = 3;
                    break;
            }

            string strPatientName = string.Format("%{0}%", this.m_txtSearchPatientName.Text.Trim());
            string strPatientCardID = this.m_txtSearchCardId.Text.Trim();
            string strPatientHosipitalNO = this.m_txtSearchInPatientNo.Text.Trim();
            string bedNo = this.m_txtSearchBedNo.Text.Trim();

            long lngRes = clsLisSearchSmp.s_obj.m_lngGetBIHQuery(strFromDate, strToDate, strAppDeptID,
                               intStatus, strPatientName, strPatientCardID, strPatientHosipitalNO, bedNo, intSampleBack, out arrApplication);

            if (arrApplication == null)
            {
                arrApplication = new clsLisApplMainVO[0];
            }

            m_arrApplications = arrApplication;

            m_lsvApplication.Items.Clear();
            //m_mthResetAll();

            if (lngRes > 0)
            {
                LoadApplicationList(arrApplication);
            }
            else
            {
                m_mthResetAll();
                ShowMessage("操作失败!");
            }
        }
        #endregion

        #region 申请单列表相关
        private void m_lsvApplication_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            bool isAsc = false;
            ListView lsvTemp = m_lsvApplication;
            if (lsvTemp.Sorting == SortOrder.Ascending)
            {
                lsvTemp.Sorting = SortOrder.Descending;
            }
            else
            {
                lsvTemp.Sorting = SortOrder.Ascending;
                isAsc = true;
            }
            lsvTemp.ListViewItemSorter = new ListViewItemComparer(e.Column, isAsc, lsvTemp);
            lsvTemp.Sort();
        }

        private void m_lsvApplication_Click(object sender, EventArgs e)
        {
            if (m_lsvApplication.SelectedItems.Count <= 0) { return; }

            SelectedApplication();
        }

        private void m_lsvApplication_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.m_lsvApplication.FocusedItem != null)
            {
                this.m_lsvApplication.FocusedItem.Selected = true;
            }
        }

        private void m_lsvApplication_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) { return; }

            if (m_lsvApplication.SelectedItems.Count <= 0) { return; }

            SelectedApplication();
        }

        #endregion

        #region 加载申请单列表




        private void LoadApplicationList(clsLisApplMainVO[] arrApplications)
        {
            m_lsvApplication.Items.Clear();
            m_lsvApplication.Tag = arrApplications;
            //m_mthResetAll();

            if (arrApplications != null && arrApplications.Length > 0)
            {
                m_lsvApplication.BeginUpdate();
                for (int i = 0; i < arrApplications.Length; i++)
                {
                    ListViewItem item = new ListViewItem();

                    //样本状态已采集
                    if (arrApplications[i].m_intSampleStatus >= 2)
                    {
                        item.Text = "√";
                        item.BackColor = Color.AntiqueWhite;
                    }
                    else
                    {
                        item.Text = "";
                    }

                    item.SubItems.Add(arrApplications[i].m_strPatient_Name);
                    item.SubItems.Add(arrApplications[i].m_strSampleType);
                    item.SubItems.Add(arrApplications[i].m_strBarcode);
                    item.SubItems.Add(arrApplications[i].m_strSample_Back_Reason);
                    item.SubItems.Add(arrApplications[i].m_isPrinted ? "√" : "");
                    item.SubItems.Add(arrApplications[i].m_strCheckContent);

                    if (arrApplications[i].m_intEmergency == 1)
                    {
                        item.ForeColor = Color.Red;
                    }

                    item.Tag = arrApplications[i];
                    m_lsvApplication.Items.Add(item);
                }

                m_lsvApplication.EndUpdate();

                if (m_lsvApplication.Items.Count > 0)
                {
                    m_lsvApplication.Items[0].Focused = true;
                    m_lsvApplication.Items[0].Selected = true;
                }

                this.SelectedApplication();
            }
        }

        #endregion

        #region 样本采集

        private bool CheckAndRefreshApplications(string applicationId)
        {
            bool isValid = clsLisServiceSmp.s_obj.GetApplicationIsValid(applicationId);
            if (!isValid)
            {
                DialogResult diaglogResult = MessageBox.Show("申请单已删除!是否刷新数据?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (diaglogResult == DialogResult.Yes)
                {
                    CollectionQuery();
                }
                return false;
            }

            return true;
        }

        /// <summary>
        /// 样本采集
        /// </summary>
        private void m_mthConfirm()
        {
            if (this.m_lsvApplication.SelectedItems.Count == 0)
            {
                ShowMessage("请选择申请单!");
                return;
            }

            clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;
            bool isValid = CheckAndRefreshApplications(objAppVO.m_strAPPLICATION_ID);
            if (!isValid)
            {
                return;
            }

            string barCode = this.m_txtBarCode.Text.Trim();
            if (string.IsNullOrEmpty(barCode))
            {
                ShowMessage("BarCode 不能为空!");
                this.m_cmdSubmitBarCode.Enabled = true;
                this.m_txtBarCode.Focus();
                this.m_txtBarCode.SelectAll();
            }
            else
            {
                if (this.m_objController.m_blnBarCodeExsit(barCode))
                {
                    ShowMessage("此 BarCode 已存在!");
                    this.m_cmdSubmitBarCode.Enabled = true;
                    this.m_txtBarCode.Focus();
                    this.m_txtBarCode.SelectAll();
                }
                else
                {
                    clsT_OPR_LIS_SAMPLE_VO objSampleVO = GetSampleVO(objAppVO);

                    long lngRes = this.m_objController.m_lngSave(objAppVO.m_strAPPLICATION_ID, ref objSampleVO);
                    this.m_cmdSubmitBarCode.Enabled = true;
                    if (lngRes <= 0)
                    {
                        ShowMessage("操作失败!");
                        this.m_cmdSubmitBarCode.Focus();
                    }
                    else
                    {
                        int intCurrApp = this.m_lsvApplication.SelectedIndices[0];

                        if (this.m_lsvApplication.SelectedItems.Count > 0)
                        {
                            //this.m_lsvApplication.SelectedItems[0].Remove();
                            SetItemHasBarcode(m_lsvApplication.SelectedItems[0], barCode, objSampleVO.m_strSAMPLE_ID_CHR);
                        }

                        if (intCurrApp < this.m_lsvApplication.Items.Count - 1)
                        {
                            this.m_lsvApplication.Focus();

                            this.m_lsvApplication.Items[intCurrApp + 1].Selected = true;
                            this.m_lsvApplication.Items[intCurrApp + 1].Focused = true;
                            this.m_lsvApplication.Items[intCurrApp + 1].EnsureVisible();
                            this.SelectedApplication();
                        }
                        else
                        {
                            if (intCurrApp == this.m_lsvApplication.Items.Count - 1)
                            {
                                this.m_lsvApplication.Items[intCurrApp].Selected = true;
                                this.m_lsvApplication.Items[intCurrApp].Focused = true;
                                this.m_lsvApplication.Items[intCurrApp].EnsureVisible();
                                this.SelectedApplication();
                            }
                            else
                            {
                                m_mthResetAll();
                            }
                        }
                    }
                }
            }
        }

        private void SetItemHasBarcode(ListViewItem item, string barcode, string sampleId)
        {
            clsLisApplMainVO appl = item.Tag as clsLisApplMainVO;
            if (appl != null)
            {
                appl.m_strBarcode = barcode;
                appl.m_strSampleID = sampleId;
                appl.m_intSampleStatus = 2;

                item.BackColor = Color.AntiqueWhite;
                item.Text = "√";
                item.SubItems[3].Text = barcode;
                item.Selected = false;
                item.Focused = false;
            }
        }

        #endregion

        #region 打印相关

        private void m_cmdPrintList_Click(object sender, EventArgs e)
        {
            clsLisApplMainVO[] arrAppl = this.m_lsvApplication.Tag as clsLisApplMainVO[];
            PrintList(arrAppl);
        }

        private void m_cmdPrintSelectedList_Click(object sender, EventArgs e)
        {
            int num = m_lsvApplication.SelectedItems.Count;
            clsLisApplMainVO[] arrAppl = new clsLisApplMainVO[num];
            for (int i = 0; i < num; i++)
            {
                arrAppl[i] = m_lsvApplication.SelectedItems[i].Tag as clsLisApplMainVO;
            }

            PrintList(arrAppl);
        }

        private void m_cmdPrintDetail_Click(object sender, EventArgs e)
        {
            clsSealedBIHLisApplyReportPrint m_objPrint = new clsSealedBIHLisApplyReportPrint();
            if (this.m_lsvApplication.SelectedItems.Count > 0)
            {
                for (int i = 0; i < m_lsvApplication.SelectedItems.Count; i++)
                {
                    clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[i].Tag;
                    if (objAppVO == null)
                    {
                        continue;
                    }
                    SetApplPrintStatus(m_lsvApplication.SelectedItems[i], objAppVO, true);
                    PrintApplicationDetail(objAppVO);

                    // 微信推送消息
                    WechatPost(objAppVO.m_strAPPLICATION_ID);
                }
            }
            else
            {
                ShowMessage("请选择要打印的申请!");
            }
        }

        #region WechatPost
        /// <summary>
        /// WechatPost
        /// </summary>
        void WechatPost(string applicationId)
        {
            try
            {
                if (string.IsNullOrEmpty(this.WechatWebUrl) || string.IsNullOrEmpty(applicationId)) return;
                clsDomainController_ApplicationManage doMain = new clsDomainController_ApplicationManage();
                DataTable dt = doMain.GetWechatSampleInfo(applicationId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (doMain.IsWechatBanding(dr["patientcardid_chr"].ToString()))
                    {
                        string xmlData = string.Empty;
                        xmlData += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine;
                        xmlData += "<req>" + Environment.NewLine;
                        xmlData += string.Format("<eventNo>{0}</eventNo>", "41332004414") + Environment.NewLine;
                        xmlData += string.Format("<eventType>{0}</eventType>", "customMessage") + Environment.NewLine;
                        xmlData += "<eventData>" + Environment.NewLine;
                        xmlData += string.Format("<healthCardNo>{0}</healthCardNo>", dr["patientcardid_chr"].ToString()) + Environment.NewLine;
                        xmlData += string.Format("<patientId>{0}</patientId>", dr["patientid_chr"].ToString()) + Environment.NewLine;
                        xmlData += string.Format("<title>{0}</title>", "检验科温馨提示") + Environment.NewLine;
                        xmlData += string.Format("<message>检验报告将于{0}后出具</message>", "X小时") + Environment.NewLine;
                        xmlData += "</eventData>" + Environment.NewLine;
                        xmlData += "</req>" + Environment.NewLine;

                        byte[] dataArray = System.Text.Encoding.Default.GetBytes(xmlData);
                        //创建请求
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.WechatWebUrl);
                        request.Method = "POST";
                        request.ContentLength = dataArray.Length;
                        //创建输入流
                        Stream dataStream = null;
                        try
                        {
                            dataStream = request.GetRequestStream();
                        }
                        catch
                        {
                            return;
                        }
                        //发送请求
                        dataStream.Write(dataArray, 0, dataArray.Length);
                        dataStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void m_cmdPrintView_Click(object sender, EventArgs e)
        {
            clsSealedBIHLisApplyReportPrint m_objPrint = new clsSealedBIHLisApplyReportPrint();
            if (this.m_lsvApplication.SelectedItems.Count > 0)
            {
                clsLisApplMainVO objAppVO = (clsLisApplMainVO)this.m_lsvApplication.SelectedItems[0].Tag;

                if (objAppVO == null)
                {
                    return;
                }

                if (BillStyle == 0)
                {
                    if (!string.IsNullOrEmpty(objAppVO.m_strBarcode))
                    {
                        //Barcode.clsBarcode barcode = new Barcode.clsBarcode();
                        //生成条型码
                        string png = string.Empty;
                        //barcode.GetBarcode(objAppVO.m_strBarcode, out png);
                        clsBarcodeMaker objBarcode = new clsBarcodeMaker();
                        objBarcode.CreateBarcodeBMP(objAppVO.m_strBarcode, out png);
                        objBarcode = null;
                    }

                    m_objPrint.m_mthGetPrintContent(objAppVO.m_strAPPLICATION_ID, objAppVO.m_strBarcode);

                    m_objPrint.m_mthPrintPreview();
                }
                else if (BillStyle == 1)
                {
                    m_objPrint.m_mthGetPrintContent(objAppVO.m_strAPPLICATION_ID, objAppVO.m_strBarcode);
                    m_objPrint.m_mthReport(1, "");
                }
            }
            else
            {
                MessageBox.Show(this, "请选择要预览的申请", "检验采集信息提示");
            }
        }

        private void m_cmdPrintSelected_Click(object sender, EventArgs e)
        {
            clsSealedBIHLisApplyReportPrint m_objPrint = new clsSealedBIHLisApplyReportPrint();
            if (this.m_lsvApplication.SelectedItems.Count > 0)
            {
                string printName = GetPrintName();
                if (printName == string.Empty)
                {
                    return;
                }

                foreach (ListViewItem item in m_lsvApplication.SelectedItems)
                {
                    clsLisApplMainVO objAppVO = item.Tag as clsLisApplMainVO;
                    SetApplPrintStatus(item, objAppVO, true);
                    if (objAppVO != null)
                    {
                        PrintApplicationDetail(objAppVO, printName);
                    }
                }
            }
            else
            {
                ShowMessage("请选择要打印的申请!");
            }
        }

        private void m_cmdNoBarCodePrint_Click(object sender, EventArgs e)
        {
            clsLisApplMainVO[] arrAppl = this.m_lsvApplication.Tag as clsLisApplMainVO[];
            if (arrAppl == null || arrAppl.Length == 0)
            {
                ShowMessage("当前没有申请单!");
                return;
            }

            string printName = GetPrintName();
            if (printName == string.Empty)
            {
                return;
            }

            if (SetApplPrinted(arrAppl, true))
            {
                foreach (ListViewItem item in m_lsvApplication.Items)
                {
                    SetListViewItemPrinted(item, true);
                }
            }

            foreach (clsLisApplMainVO app in arrAppl)
            {
                PrintApplicationDetail(app, printName);
            }
        }

        private void m_cboPrintStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadApplicationList(GetApplArrayByCondition());
        }

        private void m_cmdSetPrinted_Click(object sender, EventArgs e)
        {
            clsSealedBIHLisApplyReportPrint m_objPrint = new clsSealedBIHLisApplyReportPrint();
            if (this.m_lsvApplication.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in m_lsvApplication.SelectedItems)
                {
                    clsLisApplMainVO objAppVO = item.Tag as clsLisApplMainVO;

                    SetApplPrintStatus(item, objAppVO, true);
                }
            }
            else
            {
                ShowMessage("当前选择的申请单为空!");
            }
        }

        private void m_cmdSetNoPrinted_Click(object sender, EventArgs e)
        {
            clsSealedBIHLisApplyReportPrint m_objPrint = new clsSealedBIHLisApplyReportPrint();
            if (this.m_lsvApplication.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in m_lsvApplication.SelectedItems)
                {
                    clsLisApplMainVO objAppVO = item.Tag as clsLisApplMainVO;

                    SetApplPrintStatus(item, objAppVO, false);
                }
            }
            else
            {
                ShowMessage("当前选择的申请单为空!");
            }
        }

        private void SetListViewItemPrinted(ListViewItem item, bool isPrinted)
        {
            item.SubItems[5].Text = isPrinted ? "√" : "";
        }

        private void PrintApplicationDetail(clsLisApplMainVO objAppVO, string printName)
        {
            if (BillStyle == 0)
            {
                if (!string.IsNullOrEmpty(objAppVO.m_strBarcode))
                {
                    //Barcode.clsBarcode barcode = new Barcode.clsBarcode();
                    //生成条型码
                    string png = string.Empty;
                    //barcode.GetBarcode(objAppVO.m_strBarcode, out png);
                    clsBarcodeMaker objBarcode = new clsBarcodeMaker();
                    objBarcode.CreateBarcodeBMP(objAppVO.m_strBarcode, out png);
                }

                m_objPrint.m_mthGetPrintContent(objAppVO.m_strAPPLICATION_ID, objAppVO.m_strBarcode);
                if (printName == string.Empty)
                {
                    m_objPrint.m_mthPrint();
                }
                else
                {
                    m_objPrint.m_mthPrint(printName);
                }
            }
            else if (BillStyle == 1)
            {
                m_objPrint.m_mthGetPrintContent(objAppVO.m_strAPPLICATION_ID, objAppVO.m_strBarcode);
                m_objPrint.m_mthReport(0, printName);
            }
        }

        private void PrintApplicationDetail(clsLisApplMainVO objAppVO)
        {
            PrintApplicationDetail(objAppVO, string.Empty);
        }

        private void PrintList(clsLisApplMainVO[] arrAppl)
        {
            if (arrAppl == null || arrAppl.Length == 0)
            {
                MessageBox.Show("检验申请单列表为空!");
                return;
            }

            #region 打印赋值





            clsBIHLisPrintVO p_objPrint = new clsBIHLisPrintVO();
            try
            {
                p_objPrint.m_dtStart = Convert.ToDateTime(this.m_dtpSearchBegin.Text);
            }
            catch
            {
                p_objPrint.m_dtStart = DateTime.MinValue;
            }
            try
            {
                p_objPrint.m_dtEnd = Convert.ToDateTime(this.m_dtpSearchEnd.Text);
            }
            catch
            {
                p_objPrint.m_dtEnd = DateTime.MinValue;
            }
            #endregion

            Dictionary<clsLisApplMainVO, string> dictPrint = new Dictionary<clsLisApplMainVO, string>();

            List<clsLisApplMainVO> lstApplMain = new List<clsLisApplMainVO>(arrAppl);
            lstApplMain.Sort(CompareApplMain); //排序


            foreach (clsLisApplMainVO appl in lstApplMain)
            {
                string barcode = GetBarcode(appl.m_strSampleID);
                string strItemName = "";

                appl.m_strChargeInfo = strItemName;
                dictPrint.Add(appl, barcode);
            }

            p_objPrint.m_strApplDept = this.m_txtApplArea.Text;
            p_objPrint.dictReportPrint = dictPrint;
            clsSealedBIHLisApplyListPrint printer = new clsSealedBIHLisApplyListPrint(p_objPrint);
            printer.m_mthPrintPreview();
        }

        private bool SetApplPrinted(clsLisApplMainVO[] arrApplication, bool isPrinted)
        {
            int num = arrApplication.Length;
            string[] arrApplicationId = new string[num];
            List<string> lstBarCode = new List<string>();
            for (int i = 0; i < num; i++)
            {
                arrApplicationId[i] = arrApplication[i].m_strAPPLICATION_ID;
                lstBarCode.Add(arrApplication[i].m_strBarcode);
            }
            // 修改采样时间为当前时间
            com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc =
              (com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
            objSvc.UpdateCollectorTime(lstBarCode, DateTime.Now);
            objSvc = null;

            long lngRes = clsApplicationMainSmp.s_obj.m_mthSetApplPrinted(arrApplicationId, isPrinted);
            if (lngRes > 0)
            {
                foreach (clsLisApplMainVO appl in arrApplication)
                {
                    if (isPrinted)
                    {
                        appl.m_isPrinted = true;
                    }
                    else
                    {
                        appl.m_isPrinted = false;
                    }

                }
            }
            else
            {
                return false;
            }

            return true;
        }

        private bool SetApplPrinted(clsLisApplMainVO application, bool isPrinted)
        {
            clsLisApplMainVO[] arrAppl = new clsLisApplMainVO[1];
            arrAppl[0] = application;
            return SetApplPrinted(arrAppl, isPrinted);
        }

        private void SetApplPrintStatus(ListViewItem item, clsLisApplMainVO objAppVO, bool isPrinted)
        {
            if (SetApplPrinted(objAppVO, isPrinted))
            {
                SetListViewItemPrinted(item, isPrinted);
            }
        }

        private string GetPrintName()
        {

            PrintDialog printDialog = new PrintDialog();
            string printName = string.Empty;

            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printName = printDialog.PrinterSettings.PrinterName;
                return printName;
            }

            return printName;
        }

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label23_DoubleClick(object sender, EventArgs e)
        {
            if (this.m_dtpCollectionTime.Enabled == false)
            {
                this.btnModify.Visible = true;
                this.m_dtpCollectionTime.Enabled = true;
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            string barCode = this.m_txtBarCode.Text.Trim();
            if (barCode == string.Empty)
            {
                ShowMessage("请选择申请单!");
                return;
            }
            string collTime = this.m_dtpCollectionTime.Text.Trim();
            if (collTime == string.Empty)
            {
                ShowMessage("请输入采样时间!");
                return;
            }

            com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc =
               (com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
            if (objSvc.UpdateCollectorTime(new List<string>() { barCode }, Convert.ToDateTime(collTime)) > 0)
            {
                ShowMessage("修改成功!");
            }
            else
            {
                ShowMessage("修改失败.");
            }
            objSvc = null;
        }

        private void m_dtpCollectionTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnPack_Click(object sender, EventArgs e)
        {
            frmSamplePack frm = new frmSamplePack();
            frm.ShowDialog();
        }

        #region 缓存数据



        #endregion

    }
}