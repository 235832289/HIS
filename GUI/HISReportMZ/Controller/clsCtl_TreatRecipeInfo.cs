using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Collections;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 查询配药人员的处方信息
    /// </summary>
    public class clsCtl_TreatRecipeInfo : com.digitalwave.GUI_Base.clsController_Base
    {


        #region 全局变量
        /// <summary>
        /// 模块控制类

        /// </summary>
        private clsDcl_TreatRecipeInfo m_objDomain = null;
        /// <summary>
        /// 控制窗体对象
        /// </summary>
        private frmTreatRecipeInfo m_objViewer = null;
        /// <summary>
        /// 药房名称ID
        /// </summary>
        private string p_strMedicineName;
        /// <summary>
        /// 配药员工ID
        /// </summary>
        private string p_strTreatEmp;
        /// <summary>
        /// 配药员工和处方信息表
        /// </summary>
        private DataTable m_dtbResult;
        /// <summary>
        /// 配药员工数据表

        /// </summary>
        private DataTable m_dtData = null;
        /// <summary>
        /// 处方明细信息
        /// </summary>
        private DataTable m_dtbDetail;
        /// <summary>
        /// 配药员工和处方信息

        /// </summary>
        //List<clsTreatEmpRecipeVO> m_objTreatRecipeList;
        List<clsRecipeDetailVO> m_objDetailInfoList;
        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数

        /// </summary>
        public clsCtl_TreatRecipeInfo()
        {
            m_objDomain = new clsDcl_TreatRecipeInfo();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmTreatRecipeInfo)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取药房名称
        /// <summary>
        /// 获取药房名称
        /// </summary>
        /// <param name="m_objTable"></param>
        public long m_mthGetMedicineName(out DataTable m_objTable)
        {
            long lngRes = 0;
            lngRes = this.m_objDomain.m_lngGetMedicineName(out m_objTable);
            return lngRes;
        }
        #endregion

        #region 配药员工和处方信息列表

        /// <summary>
        /// 配药员工和处方信息列表

        /// </summary>
        public void m_mthSelectTreatEmpInfo()
        {
            long lngRes = -1;
            string strCartNo = this.m_objViewer.m_txtCartNo.Text.Trim();
            string strPatientName = this.m_objViewer.m_txtPatientName.Text.Trim();
            string strInvoiceNo = this.m_objViewer.m_txtInvoiceno.Text.Trim();
            p_strMedicineName = this.m_objViewer.m_cboMedicineName.SelectItemValue.ToString();
            if (this.m_objViewer.m_ctbEmpList.txtValuse.ToString() == "" || this.m_objViewer.m_ctbEmpList.txtValuse == null)
            {
                p_strTreatEmp = "10000";
            }
            else
            {
                string m_strTag = "";
                bool m_blnExist = false;
                string m_strEmpValuse = m_objViewer.m_ctbEmpList.txtValuse.ToString().Trim();
                for (int iExist = 0; iExist < m_dtData.Rows.Count; iExist++)
                {
                    if (m_dtData.Rows[iExist]["姓    名"].ToString().Equals(m_strEmpValuse))
                    {
                        m_blnExist = true;
                        m_strTag = m_dtData.Rows[iExist]["员工ID"].ToString();
                    }
                }
                if (m_blnExist)
                {
                    p_strTreatEmp = m_strTag;
                }
                else
                {
                    p_strTreatEmp = "0000000";
                }
            }
            DateTime p_dtpBegin = this.m_objViewer.m_dtpBegin.Value;
            DateTime p_dtpEnd = this.m_objViewer.m_dtpEnd.Value;

            lngRes = this.m_objDomain.m_lngGetTreatEmpInfo(strCartNo, strPatientName, strInvoiceNo, p_dtpBegin, p_dtpEnd, p_strMedicineName, p_strTreatEmp, out m_dtbResult);

            if (lngRes > 0)
            {
                m_mthlsvDetailInfo(m_dtbResult, ref m_objDetailInfoList);
                if (m_objDetailInfoList == null || m_objDetailInfoList.Count == 0 || m_dtbResult.Rows.Count == 0)
                {
                    this.m_objViewer.m_lsvRecipeInfo.Items.Clear();
                    this.m_objViewer.m_lsvRecipeDetailInfo.Items.Clear();
                    MessageBox.Show("没有符合条件的记录！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                else
                {
                    try
                    {
                        this.m_objViewer.m_lsvRecipeInfo.Items.Clear();
                        this.m_objViewer.m_lsvRecipeDetailInfo.Items.Clear();

                        this.m_objViewer.m_lsvRecipeInfo.BeginUpdate();
                        int iCount = this.m_objDetailInfoList.Count;
                        ListViewItem lsiTemp = null;
                        for (int i1 = 0; i1 < iCount; i1++)
                        {
                            lsiTemp = new ListViewItem(m_objDetailInfoList[i1].treatdate_dat);
                            //lsiTemp.SubItems.Add(m_objDetailInfoList[i1].outpatrecipeid_chr);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].patientcardid_chr);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].patientname);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].invoiceno_vchr);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].outpatrecipeid_chr);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].diagdrname);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].diagdeptname);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].treatempname);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].sendempname);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].medstorename_vchr);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].treatwinname);
                            lsiTemp.SubItems.Add(m_objDetailInfoList[i1].sendwinname);
                            lsiTemp.Tag = m_objDetailInfoList[i1];
                            this.m_objViewer.m_lsvRecipeInfo.Items.Add(lsiTemp);
                        }
                        this.m_objViewer.m_lsvRecipeInfo.EndUpdate();
                    }
                    catch (Exception ex)
                    {
                        com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                        bool blnRes = objLogger.LogError(ex);
                    }
                }
                #region 不用
                //m_mthlsvTreatEmpData(m_dtbResult, ref m_objTreatRecipeList);
                //if (m_objTreatRecipeList == null || m_objTreatRecipeList.Count == 0 || m_dtbResult.Rows.Count == 0)
                //{
                //    this.m_objViewer.m_lsvTreatEmp.Items.Clear();
                //    this.m_objViewer.m_lsvRecipeInfo.Items.Clear();
                //    this.m_objViewer.m_lsvRecipeDetailInfo.Items.Clear();
                //    MessageBox.Show("没有符合条件的记录！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //}
                //else
                //{
                //    try
                //    {
                //        this.m_objViewer.m_lsvTreatEmp.Items.Clear();
                //        this.m_objViewer.m_lsvRecipeInfo.Items.Clear();
                //        this.m_objViewer.m_lsvRecipeDetailInfo.Items.Clear();
                //        this.m_objViewer.m_lsvTreatEmp.BeginUpdate();
                //        ListViewItem lsiTemp = null;
                //        for (int i1 = 0; i1 < m_objTreatRecipeList.Count; i1++)
                //        {
                //            lsiTemp = new ListViewItem(m_objTreatRecipeList[i1].empno_chr);
                //            lsiTemp.SubItems.Add(m_objTreatRecipeList[i1].treatempname);
                //            lsiTemp.Tag = m_objTreatRecipeList[i1];
                //            this.m_objViewer.m_lsvTreatEmp.Items.Add(lsiTemp);
                //        }
                //        this.m_objViewer.m_lsvTreatEmp.EndUpdate();
                //    }
                //    catch (Exception ex)
                //    {
                //        com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                //        bool blnRes = objLogger.LogError(ex);
                //    }
                //}
                #endregion
            }
            else
            {
                this.m_objViewer.m_lsvRecipeInfo.Items.Clear();
                this.m_objViewer.m_lsvRecipeDetailInfo.Items.Clear();
                MessageBox.Show("没有符合条件的记录！", "icare", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            if (this.m_objViewer.m_lsvRecipeInfo.Items.Count > 0)
            {
                this.m_objViewer.m_lsvRecipeInfo.Focus();
                this.m_objViewer.m_lsvRecipeInfo.Items[0].Selected = true;
            }
            //if (this.m_objViewer.m_lsvTreatEmp.Items.Count > 0)
            //{
            //    this.m_objViewer.m_lsvTreatEmp.Items[0].Selected = true;
            //}
        }
        #endregion

        #region 处方信息列表
        /// <summary>
        /// 处方信息列表
        /// </summary>
        /// <param name="m_dtbResult"></param>
        /// <param name="m_objDetailInfo"></param>
        public void m_mthlsvDetailInfo(DataTable m_dtbResult, ref List<clsRecipeDetailVO> m_objDetailInfoList)
        {
            if (m_dtbResult.Rows.Count > 0)
            {
                try
                {
                    m_objDetailInfoList = new List<clsRecipeDetailVO>();

                    clsRecipeDetailVO m_objDetailInfo;

                    DataView dv = new DataView(m_dtbResult);
                    dv.Sort = "treatdate_dat desc";
                    m_dtbResult = dv.ToTable();

                    int iRowCount = m_dtbResult.Rows.Count;

                    for (int j2 = 0; j2 < iRowCount; j2++)
                    {
                        m_objDetailInfo = new clsRecipeDetailVO();
                        m_objDetailInfo.treatdate_dat = Convert.ToDateTime(m_dtbResult.Rows[j2]["treatdate_dat"]).ToString("yyyy-MM-dd HH:mm");
                        m_objDetailInfo.outpatrecipeid_chr = m_dtbResult.Rows[j2]["outpatrecipeid_chr"].ToString();
                        m_objDetailInfo.patientcardid_chr = m_dtbResult.Rows[j2]["patientcardid_chr"].ToString();
                        m_objDetailInfo.patientname = m_dtbResult.Rows[j2]["patientname"].ToString();
                        m_objDetailInfo.invoiceno_vchr = m_dtbResult.Rows[j2]["invoiceno_vchr"].ToString();
                        m_objDetailInfo.diagdrname = m_dtbResult.Rows[j2]["diagdrname"].ToString();
                        m_objDetailInfo.diagdeptname = m_dtbResult.Rows[j2]["diagdeptname"].ToString();
                        m_objDetailInfo.treatempname = m_dtbResult.Rows[j2]["treatempname"].ToString();
                        m_objDetailInfo.sendempname = m_dtbResult.Rows[j2]["sendempname"].ToString();
                        m_objDetailInfo.medstorename_vchr = m_dtbResult.Rows[j2]["medstorename_vchr"].ToString();
                        m_objDetailInfo.treatwinname = m_dtbResult.Rows[j2]["treatwinname"].ToString();
                        m_objDetailInfo.sendwinname = m_dtbResult.Rows[j2]["sendwinname"].ToString();
                        m_objDetailInfo.sid_int = m_dtbResult.Rows[j2]["sid_int"].ToString();
                        m_objDetailInfo.medstoreid_chr = m_dtbResult.Rows[j2]["medstoreid_chr"].ToString();
                        m_objDetailInfoList.Add(m_objDetailInfo);
                    }
                }
                catch (Exception ex)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(ex);
                }
            }
        }
        #endregion

        #region 绑定配药员工数据和处方信息列表


        /// <summary>
        /// 绑定配药员工数据和处方信息列表

        /// </summary>
        //public void m_mthlsvTreatEmpData(DataTable m_dtbResult, ref List<clsTreatEmpRecipeVO> m_objTreatRecipeList)
        //{
        //    if (m_dtbResult.Rows.Count > 0)
        //    {
        //        try
        //        {
        //            m_objTreatRecipeList = new List<clsTreatEmpRecipeVO>();

        //            clsTreatEmpRecipeVO m_objTreatEmpRecipe;

        //            clsRecipeDetailVO m_objDetailInfo;

        //            DataView dv = new DataView(m_dtbResult);
        //            dv.Sort = "treatdate_dat desc";
        //            m_dtbResult = dv.ToTable();

        //            for (int i1 = 0; i1 < this.m_dtbResult.Rows.Count; i1++)
        //            {
        //                m_objTreatEmpRecipe = new clsTreatEmpRecipeVO();

        //                m_strTempid_int = m_dtbResult.Rows[i1]["empid_chr"].ToString();

        //                if (m_objTreatRecipeList.Exists(m_mthEmpidExists))
        //                {
        //                    continue;
        //                }
        //                else
        //                {
        //                    m_objTreatEmpRecipe.m_objRecipeDetailList = new List<clsRecipeDetailVO>();

        //                    m_objTreatEmpRecipe.empid_chr = m_dtbResult.Rows[i1]["empid_chr"].ToString();
        //                    //m_objTreatEmpRecipe.sid_int = m_dtbResult.Rows[i1]["sid_int"].ToString();
        //                    //m_objTreatEmpRecipe.medstoreid_chr = m_dtbResult.Rows[i1]["medstoreid_chr"].ToString();
        //                    m_objTreatEmpRecipe.treatempname = m_dtbResult.Rows[i1]["treatempname"].ToString();
        //                    m_objTreatEmpRecipe.empno_chr = m_dtbResult.Rows[i1]["empno_chr"].ToString();

        //                    for (int j2 = i1; j2 < this.m_dtbResult.Rows.Count; j2++)
        //                    {
        //                        if (m_objTreatEmpRecipe.empid_chr == m_dtbResult.Rows[j2]["empid_chr"].ToString())
        //                        {
        //                            m_objDetailInfo = new clsRecipeDetailVO();
        //                            m_objDetailInfo.treatdate_dat = m_dtbResult.Rows[j2]["treatdate_dat"].ToString();
        //                            m_objDetailInfo.outpatrecipeid_chr = m_dtbResult.Rows[j2]["outpatrecipeid_chr"].ToString();
        //                            m_objDetailInfo.patientcardid_chr = m_dtbResult.Rows[j2]["patientcardid_chr"].ToString();
        //                            m_objDetailInfo.patientname = m_dtbResult.Rows[j2]["patientname"].ToString();
        //                            m_objDetailInfo.invoiceno_vchr = m_dtbResult.Rows[j2]["invoiceno_vchr"].ToString();
        //                            m_objDetailInfo.diagdrname = m_dtbResult.Rows[j2]["diagdrname"].ToString();
        //                            m_objDetailInfo.diagdeptname = m_dtbResult.Rows[j2]["diagdeptname"].ToString();
        //                            m_objDetailInfo.treatempname = m_dtbResult.Rows[j2]["treatempname"].ToString();
        //                            m_objDetailInfo.sendempname = m_dtbResult.Rows[j2]["sendempname"].ToString();
        //                            m_objDetailInfo.medstorename_vchr = m_dtbResult.Rows[j2]["medstorename_vchr"].ToString();
        //                            m_objDetailInfo.treatwinname = m_dtbResult.Rows[j2]["treatwinname"].ToString();
        //                            m_objDetailInfo.sendwinname = m_dtbResult.Rows[j2]["sendwinname"].ToString();
        //                            m_objDetailInfo.sid_int = m_dtbResult.Rows[j2]["sid_int"].ToString();
        //                            m_objDetailInfo.medstoreid_chr = m_dtbResult.Rows[j2]["medstoreid_chr"].ToString();
        //                            m_objTreatEmpRecipe.m_objRecipeDetailList.Add(m_objDetailInfo);
        //                        }
        //                    }
        //                    m_objTreatRecipeList.Add(m_objTreatEmpRecipe);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
        //            bool blnRes = objLogger.LogError(ex);
        //        }
        //    }
        //}
        #endregion

        #region 配药员工ID
        /// <summary>
        /// 配药员工ID
        /// </summary>
        internal string m_strTempid_int;
        #endregion

        #region 判配药处方队列信息中是否存在该记录


        /// <summary>
        /// 判配药处方队列信息中是否存在该记录

        /// </summary>
        /// <param name="m_objTemp"></param>
        /// <returns></returns>
        public bool m_mthEmpidExists(clsTreatEmpRecipeVO m_objTemp)
        {
            if (m_objTemp.empid_chr == m_strTempid_int)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 处方信息列表
        /// <summary>
        /// 处方信息列表
        /// </summary>
        //public void m_mthSelectRecipeInfo()
        //{
        //    //if (this.m_objViewer.m_lsvTreatEmp.SelectedItems.Count == 0)
        //    //    return;

        //    //int m_strTreatIndex = this.m_objViewer.m_lsvTreatEmp.SelectedItems[0].Index;

        //    clsTreatEmpRecipeVO obj = (clsTreatEmpRecipeVO)this.m_objViewer.m_lsvTreatEmp.Items[m_strTreatIndex].Tag;

        //    List<clsRecipeDetailVO> m_objDetail = obj.m_objRecipeDetailList;

        //    try
        //    {
        //        this.m_objViewer.m_lsvRecipeInfo.Items.Clear();
        //        this.m_objViewer.m_lsvRecipeDetailInfo.Items.Clear();
        //        this.m_objViewer.m_lsvRecipeInfo.BeginUpdate();

        //        ListViewItem lsiTemp = null;

        //        for (int i1 = 0; i1 < m_objDetail.Count; i1++)
        //        {
        //            lsiTemp = new ListViewItem(m_objDetail[i1].treatdate_dat);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].outpatrecipeid_chr);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].patientcardid_chr);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].patientname);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].invoiceno_vchr);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].diagdrname);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].diagdeptname);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].treatempname);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].sendempname);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].medstorename_vchr);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].treatwinname);
        //            lsiTemp.SubItems.Add(m_objDetail[i1].sendwinname);
        //            lsiTemp.Tag = m_objDetail[i1];
        //            this.m_objViewer.m_lsvRecipeInfo.Items.Add(lsiTemp);
        //        }
        //        this.m_objViewer.m_lsvRecipeInfo.EndUpdate();
        //    }
        //    catch (Exception ex)
        //    {
        //        com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
        //        bool blnRes = objLogger.LogError(ex);
        //    }
        //    if (this.m_objViewer.m_lsvRecipeInfo.Items.Count > 0)
        //    {
        //        this.m_objViewer.m_lsvRecipeInfo.Items[0].Selected = true;
        //    }
        //}
        #endregion

        #region 绑定处方明细信息数据
        /// <summary>
        /// 绑定处方明细信息数据
        /// </summary>
        /// <param name="m_dtbDetail"></param>
        private void m_mthlsvRecipeDetailData(DataTable m_dtbDetail)
        {
            if (m_dtbDetail.Rows.Count > 0)
            {
                try
                {
                    if (this.m_objViewer.m_lsvRecipeDetailInfo.Items.Count > 0)
                    {
                        this.m_objViewer.m_lsvRecipeDetailInfo.Items.Clear();
                    }
                    this.m_objViewer.m_lsvRecipeDetailInfo.BeginUpdate();
                    ListViewItem lsiTempDetail = null;

                    for (int i1 = 0; i1 < m_dtbDetail.Rows.Count; i1++)
                    {
                        /// itemname_vchr itemspec_vchr dosage_dec dosageunit_chr  usagename_vchr  freqname_chr(频率) 
                        /// days_int1 qty_dec unitid_chr price_mny tolprice_mny itemcode_vchr

                        lsiTempDetail = new ListViewItem(m_dtbDetail.Rows[i1]["itemname_vchr"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["itemspec_vchr"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["dosage_dec"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["dosageunit_chr"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["usagename_vchr"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["freqname_chr"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["days_int1"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["qty_dec"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["unitid_chr"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["price_mny"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["tolprice_mny"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["itemcode_vchr"].ToString());
                        lsiTempDetail.SubItems.Add(m_dtbDetail.Rows[i1]["productorid_chr"].ToString());
                        this.m_objViewer.m_lsvRecipeDetailInfo.Items.Add(lsiTempDetail);
                    }
                    this.m_objViewer.m_lsvRecipeDetailInfo.EndUpdate();
                }
                catch (Exception ex)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(ex);
                }
            }
        }
        #endregion

        #region 处方明细信息
        /// <summary>
        /// 处方明细信息
        /// </summary>
        public void m_mthSelectRecipeDetailInfo()
        {
            if (this.m_objViewer.m_lsvRecipeInfo.SelectedItems.Count == 0)
                return;

            int m_strRecipeIndex = this.m_objViewer.m_lsvRecipeInfo.SelectedItems[0].Index;
            clsRecipeDetailVO objDetail = (clsRecipeDetailVO)this.m_objViewer.m_lsvRecipeInfo.Items[m_strRecipeIndex].Tag;
            long lngDetailRes = -1;
            string p_strsid_int = objDetail.outpatrecipeid_chr;
            string p_strmedstoreid_chr = objDetail.medstoreid_chr;
            lngDetailRes = this.m_objDomain.m_lngGetDetailInfo(p_strsid_int, p_strmedstoreid_chr, out m_dtbDetail);
            if (lngDetailRes > 0)
            {
                m_mthlsvRecipeDetailData(m_dtbDetail);   //绑定处方明细信息数据
            }
        }
        #endregion

        #region 配药员工数据
        /// <summary>
        /// 配药员工数据
        /// </summary>
        internal void m_mthGetEmpData()
        {
            string strMedNameid = this.m_objViewer.m_cboMedicineName.SelectItemValue.ToString();
            DataTable m_objResult = null;
            long lngRes = 0;
            lngRes = this.m_objDomain.m_lngGetTreatEmp(strMedNameid, out m_objResult);

            if (lngRes > 0 && m_objResult.Rows.Count > 0)
            {
                m_dtData = new DataTable();
                m_dtData.Columns.Add("员 工 号");
                m_dtData.Columns.Add("姓    名");
                m_dtData.Columns.Add("员工ID");
                DataRow m_newRow = null;
                //m_newRow = m_dtData.NewRow();
                //m_newRow["员 工 号"] = "0000";
                //m_newRow["姓    名"] = "全部";
                //m_newRow["员工ID"] = "10000";
                //m_dtData.Rows.Add(m_newRow);
                DataRow m_dr = null;
                for (int iRow = 0; iRow < m_objResult.Rows.Count; iRow++)
                {
                    m_dr = m_objResult.Rows[iRow];
                    m_newRow = m_dtData.NewRow();
                    m_newRow["员 工 号"] = m_dr["empno_chr"].ToString();
                    m_newRow["姓    名"] = m_dr["lastname_vchr"].ToString();
                    m_newRow["员工ID"] = m_dr["empid_chr"].ToString();
                    m_dtData.Rows.Add(m_newRow);
                }
                m_dtData.AcceptChanges();
                this.m_objViewer.m_ctbEmpList.m_GetDataTable = m_dtData;
            }
        }
        #endregion

        internal void m_mthShowSearchCartNoForm(string p_strSearchCon, out bool p_blnExist)
        {
            p_blnExist = false;
            if (this.m_objViewer.m_lsvRecipeInfo.Items.Count > 0)
            {
                for (int iCount = 0; iCount < this.m_objViewer.m_lsvRecipeInfo.Items.Count; iCount++)
                {
                    if (this.m_objViewer.m_lsvRecipeInfo.Items[iCount].SubItems[1].Text != null
                        && this.m_objViewer.m_lsvRecipeInfo.Items[iCount].SubItems[1].Text == p_strSearchCon)
                    {
                        this.m_objViewer.m_lsvRecipeInfo.Focus();
                        this.m_objViewer.m_lsvRecipeInfo.Items[iCount].Selected = true;
                        this.m_objViewer.m_lsvRecipeInfo.SelectedItems[0].EnsureVisible();
                        p_blnExist = true;
                        break;
                    }
                }
            }
        }
    }
}
