using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房盘点界面控制层
    /// </summary>
    public class clsCtl_DrugStoreCheck : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmDrugStoreCheck m_objViewer;
        private clsDcl_DrugStoreCheck m_objDomain;
        internal DataView m_dtvCurrentMainVienPage1 = null;
        internal DataView m_dtvCurrentMainVienPage2 = null;
        /// <summary>
        /// 主表记录
        /// </summary>
        DataTable dtbStoreCheck = null;

        /// <summary>
        /// 未合并的明细表记录
        /// </summary>
        DataTable dtbDetailTrue = null;

        /// <summary>
        /// 已合并的明细表记录
        /// </summary>
        DataTable dtbStoreCheck_detail = null;
        /// <summary>
        /// 当前药品出库主表信息
        /// </summary>
        private clsDS_Check_VO m_objStoreCheck = null;
        /// <summary>
        /// 单据状态，0-作废，1--新制，2-审核，3--入帐，
        /// </summary>
        private int m_intStatus = -1;
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_DrugStoreCheck()
        {
            m_objDomain = new clsDcl_DrugStoreCheck();
        }
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmDrugStoreCheck)frmMDI_Child_Base_in;
        }
        #endregion

        #region 显示明细窗体
        /// <summary>
        /// 显示明细窗体
        /// </summary>
        /// <param name="intShowType">窗体显示类型０：新制,１：修改</param>
        public void m_mthFrmDetail(int intShowType)
        {
            frmDrugStoreCheck_Detail frmDetail = new frmDrugStoreCheck_Detail(m_objViewer.m_strStoreID, m_objViewer.m_strStoreDeptID);
            frmDetail.m_blnIsHospital = m_objViewer.m_blnIsHospital;
            if (intShowType == 1)
            {
                if (m_objViewer.m_dgvMain.SelectedRows.Count == 0)
                {
                    MessageBox.Show("请先选择一行盘点信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DataRowView drCurrent = m_objViewer.m_dgvMain.SelectedRows[0].DataBoundItem as DataRowView;
                clsDS_Check_VO objMain = GetObjMain(drCurrent.Row);
                frmDetail.m_objMain = objMain;
                m_objViewer.m_strBillNo = objMain.m_strCHECKID_CHR;

                DataView dv = dtbStoreCheck_detail.DefaultView;
                dv.Sort = "checkmedicineorder_chr,assistcode_chr,medicineid_chr";
                dtbStoreCheck = dv.ToTable();
                DataTable dtbDetail = dtbStoreCheck_detail.Copy();
                DataTable dtbTrue = dtbDetailTrue.Copy();
                frmDetail.dtbDrugCheck_detail = dtbDetail;
                frmDetail.dtbDrugCheck_TrueDetail = dtbTrue;
            }
            else
            {
                frmDetail.m_objMain = null;
                frmDetail.dtbDrugCheck_detail = new DataTable();

            }
            frmDetail.intShowType = intShowType;
            frmDetail.m_strStoreID = this.m_objViewer.m_strStoreID;
            if (m_objViewer.m_intCheckMode == 0 || intShowType == 0)
            {
                frmDetail.FormClosed += new FormClosedEventHandler(frmDetail_FormClosed);
            }
            frmDetail.Show();
        }
        #endregion

        int intCheckTime = 0;
        private void frmDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            intCheckTime++;
            if (intCheckTime == 1)
            {
                m_mthGetStoreCheck();
            }
            else
            {
                intCheckTime = 0;
            }
        }

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        internal void m_mthGetStoreCheck()
        {
            m_objViewer.m_intRowIndex = -1;
            DateTime dtBeginTime = DateTime.MinValue;
            if (!DateTime.TryParse(m_objViewer.m_datBegin.Text, out dtBeginTime))
            {
                MessageBox.Show("请输入开始时间。", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_objViewer.m_datBegin.Focus();
                return;
            }
            DateTime dtEndTime = DateTime.MinValue;
            if (!DateTime.TryParse(m_objViewer.m_datEnd.Text, out dtEndTime))
            {
                MessageBox.Show("请输入结束时间。", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_objViewer.m_datEnd.Focus();
                return;
            }
            if (dtBeginTime > dtEndTime)
            {
                MessageBox.Show("开始时间不能大于结束时间。", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_objViewer.m_datBegin.Focus();
                return;
            }
            m_objDomain.m_lngGetDrugStoreCheckMainInfo(m_objViewer.m_strStoreDeptID, dtBeginTime, dtEndTime, out dtbStoreCheck);
            if (m_objViewer.m_dtMainTemp == null)
            {
                m_objViewer.m_dtMainTemp = dtbStoreCheck.Clone();
            }
            m_mthSetDataToUI();
        }

        /// <summary>
        /// 设置数据至界面
        /// </summary>
        internal void m_mthSetDataToUI()
        {
            m_objViewer.m_lblBalanceMoney.Text = "0.0000元";
            m_objViewer.m_lblBuyInSubMoney.Text = "0.0000元";
            m_objViewer.m_lblRetailSubMoney.Text = "0.0000元";
            if (dtbStoreCheck != null && dtbStoreCheck.Rows.Count > 0)
            {
                m_dtvCurrentMainVienPage1 = new DataView(dtbStoreCheck);

                if (!string.IsNullOrEmpty(m_objViewer.m_txtCheckNo.Text))
                {
                    m_dtvCurrentMainVienPage1.RowFilter = " checkid_chr like '" + m_objViewer.m_txtCheckNo.Text + "%'";
                }

                if (!string.IsNullOrEmpty(m_objViewer.m_txtMaker.Text))
                {
                    if (m_dtvCurrentMainVienPage1.RowFilter == "")
                        m_dtvCurrentMainVienPage1.RowFilter = " askername like '" + m_objViewer.m_txtMaker.Text + "%'";
                    else
                        m_dtvCurrentMainVienPage1.RowFilter = m_dtvCurrentMainVienPage1.RowFilter + " and askername like '" + m_objViewer.m_txtMaker.Text + "%'";
                }

                if (m_objViewer.m_cboStatus.SelectedIndex > 0)
                {
                    if (m_dtvCurrentMainVienPage1.RowFilter == "")
                        m_dtvCurrentMainVienPage1.RowFilter = " status_int = '" + m_objViewer.m_cboStatus.Text + "'";
                    else
                        m_dtvCurrentMainVienPage1.RowFilter = m_dtvCurrentMainVienPage1.RowFilter + " and status_int = '" + m_objViewer.m_cboStatus.Text + "'";
                }

                if (m_dtvCurrentMainVienPage1.Count > 0)
                {
                    m_objViewer.m_dgvMain.DataSource = m_dtvCurrentMainVienPage1;

                    //for(int i1 = 0;i1 < m_objViewer.m_dgvMain.Rows.Count;i1++)
                    //{
                    //    try
                    //    {
                    //        if (Convert.ToString(m_objViewer.m_dgvMain.Rows[i1].Cells["CHECKID_CHR"].Value) == m_objViewer.m_strBillNo)
                    //        {
                    if (m_objViewer.m_dgvMain.CurrentCell == null && m_objViewer.m_dgvMain.Rows.Count > 0)
                    {
                        m_objViewer.m_dgvMain.CurrentCell = m_objViewer.m_dgvMain.Rows[0].Cells[0];
                        m_objViewer.m_dgvMain.CurrentCell.Selected = true;
                        //break;
                    }
                    //        }
                    //    }
                    //    catch
                    //    {
                    //    }
                    //}
                    //m_mthGetStoreCheck_detail();
                }
                else
                {
                    m_objViewer.m_dgvMain.DataSource = m_objViewer.m_dtMainTemp;
                    if (m_objViewer.m_dtSubTemp != null)
                        m_objViewer.m_dtSubTemp.Rows.Clear();
                    m_objViewer.m_dgvDetail.DataSource = m_objViewer.m_dtSubTemp;
                    m_objViewer.m_dgvMain.Refresh();
                    m_objViewer.m_dgvDetail.Refresh();
                }
            }
            else
            {
                m_objViewer.m_dgvMain.DataSource = m_objViewer.m_dtMainTemp;
                if (m_objViewer.m_dtSubTemp != null)
                    m_objViewer.m_dtSubTemp.Rows.Clear();
                m_objViewer.m_dgvDetail.DataSource = m_objViewer.m_dtSubTemp;
                m_objViewer.m_dgvMain.Refresh();
                m_objViewer.m_dgvDetail.Refresh();
            }

        }
        #endregion

        #region 获取当前主记录

        /// <summary>
        /// 获取当前主记录
        /// </summary>
        /// <param name="p_drmain">数据</param>
        /// <returns></returns>
        private clsDS_Check_VO GetObjMain(DataRow p_drmain)
        {
            if (p_drmain == null)
            {
                return null;
            }
            clsDS_Check_VO objMain = new clsDS_Check_VO();
            objMain.m_dtmASKDATE_DAT = Convert.ToDateTime(p_drmain["askdate_dat"]);

            //switch (p_drmain["status_int"].ToString())
            //{
            //    case "删除":
            //        objMain.m_intSTATUS_INT = 0;
            //        break;
            //    case "新制":
            //        objMain.m_intSTATUS_INT = 1;
            //        break;
            //    case "审核":
            //        objMain.m_intSTATUS_INT = 2;
            //        break;
            //    case "入账":
            //        objMain.m_intSTATUS_INT = 3;
            //        break;
            //}

            objMain.m_strDRUGSTOREID_CHR = m_objViewer.m_strStoreID;
            objMain.m_strASKERID_CHR = p_drmain["askerid_chr"].ToString();
            objMain.m_strASKERNAME_VCHR = p_drmain["askername"].ToString();
            objMain.m_lngSERIESID_INT = Convert.ToInt64(p_drmain["seriesid_int"]);
            objMain.m_dtmCHECKDATE_DAT = Convert.ToDateTime(p_drmain["checkdate_dat"]);
            objMain.m_strCHECKID_CHR = p_drmain["checkid_chr"].ToString();
            m_objDomain.m_lngCheckStatus(2, objMain.m_lngSERIESID_INT, out objMain.m_intSTATUS_INT);
            return objMain;
        }
        #endregion

        #region 获取明细表内容
        /// <summary>
        /// 获取明细表内容
        /// </summary>
        internal void m_mthGetStoreCheck_detail()
        {
            if (m_objViewer.m_dgvMain.CurrentCell == null)
            {
                m_objDomain.m_lngGetStoreCheck_detail(0, m_objViewer.m_intCheckMode, m_objViewer.m_blnIsHospital, out dtbDetailTrue, out dtbStoreCheck_detail);                
            }
            else
            {
                DataRowView drvSelected = m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMain.CurrentCell.RowIndex];
                long lngSeriesId = Convert.ToInt64(drvSelected["SERIESID_INT"]);
                m_objDomain.m_lngGetStoreCheck_detail(lngSeriesId, m_objViewer.m_intCheckMode,m_objViewer.m_blnIsHospital, out dtbDetailTrue, out dtbStoreCheck_detail);                
            }
            m_dtvCurrentMainVienPage2 = new DataView(dtbStoreCheck_detail);

            m_mthSetCheckMoney();
            if (m_objViewer.m_intCheckMode == 0)
            {
                DataView dv = dtbDetailTrue.DefaultView;
                dv.Sort = "checkmedicineorder_chr,assistcode_chr,medicineid_chr,opretailprice_int";
                dtbDetailTrue = dv.ToTable();
                m_objViewer.m_dgvDetail.DataSource = dtbDetailTrue;
            }
            else
            {
                m_objViewer.m_dgvDetail.DataSource = m_dtvCurrentMainVienPage2;
            }
            m_objViewer.m_dgvDetail.Refresh();

            if (m_objViewer.m_dtSubTemp == null)
            {
                if (m_objViewer.m_intCheckMode == 0)
                {
                    m_objViewer.m_dtSubTemp = dtbDetailTrue.Copy();
                }
                else
                {
                    m_objViewer.m_dtSubTemp = dtbStoreCheck_detail.Copy();
                }
            }
        }

        private void m_mthSetCheckMoney()
        {
            m_objViewer.m_lblBalanceMoney.Text = string.Empty;
            m_objViewer.m_lblBuyInSubMoney.Text = string.Empty;
            m_objViewer.m_lblRetailSubMoney.Text = string.Empty;

            if (dtbStoreCheck_detail == null || dtbStoreCheck_detail.Rows.Count == 0)
            {
                return;
            }

            int intRowsCount = dtbStoreCheck_detail.Rows.Count;
            double dblBalanceMoney = 0d;
            double dblBuyInMoney = 0d;
            double dblRetailMoney = 0d;
            DataRow drTemp = null;
            //if (m_objViewer.m_intCheckMode == 1)
            //{
            //    for (int iRow = 0; iRow < intRowsCount; iRow++)
            //    {
            //        drTemp = dtbStoreCheck_detail.Rows[iRow];
            //        dblBalanceMoney += Convert.ToDouble(drTemp["checkresult_int"]) * Convert.ToDouble(drTemp["opretailprice_int"]) / Convert.ToDouble(drTemp["packqty_dec"]);
            //        dblBuyInMoney += Convert.ToDouble(drTemp["iprealgross_int"]) * Convert.ToDouble(drTemp["opcallprice_int"]) / Convert.ToDouble(drTemp["packqty_dec"]);
            //        dblRetailMoney += Math.Round(Convert.ToDouble(drTemp["iprealgross_int"]) * Convert.ToDouble(drTemp["opretailprice_int"]) / Convert.ToDouble(drTemp["packqty_dec"]), 8);
            //    }
            //}
            //else
            //{
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = dtbStoreCheck_detail.Rows[iRow];
                    dblBalanceMoney += Convert.ToDouble(drTemp["balance"]);// Math.Round((Convert.ToDouble(drTemp["opcheckresult_int"]) * Convert.ToDouble(drTemp["packqty_dec"]) + Convert.ToDouble(drTemp["ipcheckresult_int"])) * Convert.ToDouble(drTemp["opretailprice_int"]) / Convert.ToDouble(drTemp["packqty_dec"]), 8, MidpointRounding.AwayFromZero);
                    dblBuyInMoney += Convert.ToDouble(drTemp["callmoney"]);// Math.Round((Convert.ToDouble(drTemp["opcheckgross_int"]) * Convert.ToDouble(drTemp["packqty_dec"]) + Convert.ToDouble(drTemp["ipcheckgross_int"])) * Convert.ToDouble(drTemp["opcallprice_int"]) / Convert.ToDouble(drTemp["packqty_dec"]), 8, MidpointRounding.AwayFromZero);
                    dblRetailMoney += Convert.ToDouble(drTemp["realmoney"]);// Math.Round((Convert.ToDouble(drTemp["opcheckgross_int"]) * Convert.ToDouble(drTemp["packqty_dec"]) + Convert.ToDouble(drTemp["ipcheckgross_int"])) * Convert.ToDouble(drTemp["opretailprice_int"]) / Convert.ToDouble(drTemp["packqty_dec"]), 8, MidpointRounding.AwayFromZero);
                }
            //}
            m_objViewer.m_lblBalanceMoney.Text = dblBalanceMoney.ToString("0.0000")+"元";
            m_objViewer.m_lblBuyInSubMoney.Text = dblBuyInMoney.ToString("0.0000");
            m_objViewer.m_lblRetailSubMoney.Text = dblRetailMoney.ToString("0.0000")+"元";
        }
        #endregion

        #region 删除盘点记录
        /// <summary>
        /// 删除盘点记录
        /// </summary>
        internal void m_mthDeleteCheckStore()
        {
            if (m_objViewer.m_dgvMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择一条新制药品盘点信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //检查是否新制
            m_objDomain.m_lngCheckStatus(2, Convert.ToInt64(m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMain.SelectedRows[0].Index]["SERIESID_INT"]), out m_intStatus);
            if (m_intStatus != 1)
            {
                MessageBox.Show("您所选择的盘点单不是新制状态,不能进行删除！", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否删除选中记录？", "药品盘点", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }

            long lngSEQ = Convert.ToInt64(m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMain.SelectedRows[0].Index]["SERIESID_INT"]);

            long lngRes = m_objDomain.m_lngDeleteStorageCheck(lngSEQ);
            if (lngRes > 0)
            {
                try
                {
                    DataRow drDel = m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMain.SelectedRows[0].Index].Row;
                    if (drDel != null)
                    {
                        //drDel["STATUS_INT"] = "删除";
                        dtbStoreCheck.Rows.Remove(drDel);
                    }

                    if (m_dtvCurrentMainVienPage1.Count == 0 && dtbStoreCheck_detail != null)
                    {
                        dtbStoreCheck_detail.Rows.Clear();
                        dtbDetailTrue.Rows.Clear();
                        m_objViewer.m_dtSubTemp.Rows.Clear();
                        m_objViewer.m_lblBuyInSubMoney.Text = "0.0000元";
                        m_objViewer.m_lblRetailSubMoney.Text = "0.0000元";
                        m_objViewer.m_lblBalanceMoney.Text = "0.0000元";
                        m_objViewer.m_dgvDetail.Refresh();
                    }
                }
                catch
                {
                    m_objViewer.m_btnFind.PerformClick();
                }
            }
            else
            {
                if(lngRes == -99)
                {
                    MessageBox.Show("删除失败，当前单据状态已经改变，请重新加载后处理。", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("删除失败", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 审核药品盘点
        /// <summary>
        /// 审核药品盘点
        /// </summary>
        internal void m_mthCommitStoreCheck()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药房管理权限，不能审核", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_objViewer.m_dgvMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("请先选择需审核的药品盘点信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            m_objDomain.m_lngCheckStatus(2, Convert.ToInt64(m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMain.SelectedRows[0].Index]["SERIESID_INT"]), out m_intStatus);
            if (m_intStatus != 1)
            {
                MessageBox.Show("您所选择的盘点单不是新制状态,不能进行审核！", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (m_dtvCurrentMainVienPage2.Count == 0)
            {
                return;
            }

            long lngRes = 0;

            DataRowView drvCurrentMain = m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMain.SelectedRows[0].Index];
            string strCheckID = drvCurrentMain["checkid_chr"].ToString();
            DateTime dtmCheckDate = Convert.ToDateTime(drvCurrentMain["askdate_dat"]);
            string strCreator = drvCurrentMain["askerid_chr"].ToString();
            long lngMainSEQ = Convert.ToInt64(drvCurrentMain["seriesid_int"]);

            List<clsDS_StorageDetail_VO> lstStDetail = new List<clsDS_StorageDetail_VO>();
            //clsDcl_StorageCheck_detail objSCDDomain = new clsDcl_StorageCheck_detail();
            List<clsDS_StorageCheckDetail_VO> lstDef = new List<clsDS_StorageCheckDetail_VO>();//盘亏
            List<clsDS_StorageCheckDetail_VO> lstSuf = new List<clsDS_StorageCheckDetail_VO>();//盘盈

            //盘亏
            DataRow[] drDef = dtbStoreCheck_detail.Select("CHECKRESULT_INT < 0");
            if (drDef != null && drDef.Length > 0)
            {
                lstDef.AddRange(m_objCheckDetail(drDef));
                lstStDetail.AddRange(m_objStorageDetailArr(drDef));
            }
            //盘盈
            DataRow[] drSuf = dtbStoreCheck_detail.Select("CHECKRESULT_INT > 0");
            if (drSuf != null && drSuf.Length > 0)
            {
                lstSuf.AddRange(m_objCheckDetail(drSuf));
                lstStDetail.AddRange(m_objStorageDetailArr(drSuf));
            }

            Hashtable hstMedicine = new Hashtable();
            List<string> lstMedicineID = new List<string>();
            if (lstStDetail.Count > 0)
            {
                for (int iMed = 0; iMed < lstStDetail.Count; iMed++)
                {
                    if (!hstMedicine.Contains(lstStDetail[iMed].m_strMEDICINEID_CHR))
                    {
                        hstMedicine.Add(lstStDetail[iMed].m_strMEDICINEID_CHR, lstStDetail[iMed].m_strMEDICINENAME_VCHR);
                        lstMedicineID.Add(lstStDetail[iMed].m_strMEDICINEID_CHR);
                    }
                }
            }

            try
            {
                DateTime dtmNow = Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));
                lngRes = m_objDomain.m_lngCommitStoreCheck(lngMainSEQ, lstDef.ToArray(), lstSuf.ToArray(), lstStDetail.ToArray(), lstMedicineID.ToArray(), m_objViewer.LoginInfo.m_strEmpID,
                    dtmNow, strCheckID, strCreator, dtmCheckDate, m_objViewer.m_strStoreDeptID, m_objViewer.m_blnIsHospital);

                if (lngRes > 0)
                {
                    DataRow drCurrent = drvCurrentMain.Row;
                    drCurrent["examdate_dat"] = Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"));
                    drCurrent["examername"] = m_objViewer.LoginInfo.m_strEmpName;
                    drCurrent["STATUS_INT"] = "审核";
                    //drCurrent["statusdesc"] =  "审核";
                    MessageBox.Show("审核成功", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetStoreCheck();
                }
                else
                {

                    if(lngRes == -99)
                    {
                        MessageBox.Show("审核失败。该单据的状态已经改变，请重新加载数据后操作。", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("审核失败", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        #region 获取盘点明细
        /// <summary>
        /// 获取盘点明细
        /// </summary>
        /// <param name="p_drData">盘点明细数据</param>
        /// <returns></returns>
        private clsDS_StorageCheckDetail_VO[] m_objCheckDetail(DataRow[] p_drData)
        {
            if (p_drData == null || p_drData.Length == 0)
            {
                return null;
            }

            clsDS_StorageCheckDetail_VO[] objCheck = new clsDS_StorageCheckDetail_VO[p_drData.Length];
            for (int iRow = 0; iRow < p_drData.Length; iRow++)
            {
                objCheck[iRow] = new clsDS_StorageCheckDetail_VO();
                objCheck[iRow].m_dblIPCHECKGROSS_INT = Convert.ToDouble(p_drData[iRow]["ipcheckgross_int"]);
                objCheck[iRow].m_dblOPCHECKGROSS_INT = Convert.ToDouble(p_drData[iRow]["opcheckgross_int"]);
                objCheck[iRow].m_dblIPCHECKRESULT_INT = Convert.ToDouble(p_drData[iRow]["ipcheckresult_int"]);
                objCheck[iRow].m_dblOPCHECKRESULT_INT = Convert.ToDouble(p_drData[iRow]["opcheckresult_int"]);                
                objCheck[iRow].m_dtmMODIFYDATE_DAT = Convert.ToDateTime(p_drData[iRow]["modifydate_dat"]);
                objCheck[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drData[iRow]["validperiod_dat"]);
                objCheck[iRow].m_intISZERO_INT = Convert.ToInt32(p_drData[iRow]["iszero_int"]);
                objCheck[iRow].m_intSTATUS_INT = Convert.ToInt32(p_drData[iRow]["status_int"]);
                objCheck[iRow].m_lngSERIESID_INT = Convert.ToInt64(p_drData[iRow]["seriesid_int"]);
                objCheck[iRow].m_lngSERIESID2_INT = Convert.ToInt64(p_drData[iRow]["seriesid2_int"]);
                objCheck[iRow].m_strCHECKREASON_VCHR = p_drData[iRow]["checkreason_vchr"].ToString();
                objCheck[iRow].m_strINDRUGSTOREID_VCHR = p_drData[iRow]["indrugstoreid_vchr"].ToString();
                objCheck[iRow].m_strLOTNO_VCHR = p_drData[iRow]["lotno_vchr"].ToString();
                objCheck[iRow].m_strMedicineCode = p_drData[iRow]["medicineid_chr"].ToString();                
                objCheck[iRow].m_strMEDICINENAME_VCHR = p_drData[iRow]["medicinename_vchr"].ToString();
                objCheck[iRow].m_strMedicineTypeID = p_drData[iRow]["medicinetypeid_chr"].ToString();
                objCheck[iRow].m_strMEDSPEC_VCHR = p_drData[iRow]["medspec_vchr"].ToString();
                objCheck[iRow].m_strMODIFIER_CHR = p_drData[iRow]["modifier_chr"].ToString();
                objCheck[iRow].m_strOPUNIT_CHR = p_drData[iRow]["opunit_chr"].ToString();
                objCheck[iRow].m_strPRODUCTORID_CHR = p_drData[iRow]["productorid_chr"].ToString();
                objCheck[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(p_drData[iRow]["packqty_dec"]);
                objCheck[iRow].m_strIPUNIT_CHR = p_drData[iRow]["ipunit_chr"].ToString();
                objCheck[iRow].m_dblOPCHARGEFLG_INT = Convert.ToDouble(p_drData[iRow]["opchargeflg_int"]);
                objCheck[iRow].m_dblIPREALGROSS_INT = Convert.ToDouble(p_drData[iRow]["iprealgross_int"]);
                objCheck[iRow].m_dblOPREALGROSS_INT = Convert.ToDouble(p_drData[iRow]["oprealgross_int"]);
                objCheck[iRow].m_dblIPRETAILPRICE_INT = Convert.ToDouble(p_drData[iRow]["ipretailprice_int"]);
                objCheck[iRow].m_dblOPRETAILPRICE_INT = Convert.ToDouble(p_drData[iRow]["opretailprice_int"]);
                objCheck[iRow].m_dblIPCALLPRICE_INT = Convert.ToDouble(p_drData[iRow]["ipcallprice_int"]);
                objCheck[iRow].m_dblOPCALLPRICE_INT = Convert.ToDouble(p_drData[iRow]["opcallprice_int"]);
                objCheck[iRow].m_dtmDSINSTORAGEDATE_DAT = Convert.ToDateTime(p_drData[iRow]["dsinstoragedate_dat"]);
                objCheck[iRow].m_dblIPCHARGEFLG_INT = Convert.ToDouble(p_drData[iRow]["ipchargeflg_int"]);
                objCheck[iRow].m_strUNIT_CHR = p_drData[iRow]["unit_chr"].ToString();
            }
            return objCheck;
        }
        #endregion

        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <returns></returns>
        private clsDS_StorageDetail_VO[] m_objStorageDetailArr(DataRow[] p_drData)
        {
            if (p_drData == null || p_drData.Length == 0)
            {
                return null;
            }

            List<clsDS_StorageDetail_VO> lstDetail = new List<clsDS_StorageDetail_VO>();
            for (int iRow = 0; iRow < p_drData.Length; iRow++)
            {
                clsDS_StorageDetail_VO objDetail = m_objStorageDetail(p_drData[iRow]);
                if (objDetail != null)
                {
                    lstDetail.Add(objDetail);
                }
            }

            return lstDetail.ToArray();
        }

        /// <summary>
        /// 获取库存信息
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <returns></returns>
        private clsDS_StorageDetail_VO m_objStorageDetail(DataRow p_drData)
        {
            if (p_drData == null)
            {
                return null;
            }
            clsDS_StorageDetail_VO objDetail = new clsDS_StorageDetail_VO();
            objDetail.m_dblOPCHARGEFLG_INT = Convert.ToDouble(p_drData["opchargeflg_int"]);
            objDetail.m_dblIPCHARGEFLG_INT = Convert.ToDouble(p_drData["ipchargeflg_int"]);
            objDetail.m_dblPACKQTY_DEC = Convert.ToDouble(p_drData["packqty_dec"]);

            objDetail.m_dblOPAVAILABLEGROSS_NUM = Convert.ToDouble(p_drData["opcheckresult_int"]) + Math.Round(Convert.ToDouble(p_drData["ipcheckresult_int"]) / objDetail.m_dblPACKQTY_DEC, 2, MidpointRounding.AwayFromZero);
            objDetail.m_dblIPAVAILABLEGROSS_NUM = Convert.ToDouble(p_drData["opcheckresult_int"]) * objDetail.m_dblPACKQTY_DEC + Convert.ToDouble(p_drData["ipcheckresult_int"]);
            objDetail.m_dblOPREALGROSS_INT = objDetail.m_dblOPAVAILABLEGROSS_NUM;
            objDetail.m_dblIPREALGROSS_INT = objDetail.m_dblIPAVAILABLEGROSS_NUM;
            objDetail.m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(p_drData["opcallprice_int"]);
            objDetail.m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(p_drData["ipcallprice_int"]);
            objDetail.m_dblOPRETAILPRICE_INT = Convert.ToDouble(p_drData["opretailprice_int"]);
            objDetail.m_dblIPRETAILPRICE_INT = Convert.ToDouble(p_drData["ipretailprice_int"]);

            objDetail.m_strLOTNO_VCHR = p_drData["LOTNO_VCHR"].ToString();
            objDetail.m_strINSTOREID_VCHR = p_drData["indrugstoreid_vchr"].ToString();
            objDetail.m_strMEDICINEID_CHR = p_drData["MEDICINEID_CHR"].ToString();

            objDetail.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drData["VALIDPERIOD_DAT"]);
            objDetail.m_strDRUGSTOREID_CHR = m_objViewer.m_strStoreDeptID;
            objDetail.m_strOPUNIT_CHR = p_drData["opunit_chr"].ToString();
            objDetail.m_strIPUNIT_CHR = p_drData["ipunit_chr"].ToString();
            objDetail.m_dblOldOPREALGROSS_INT = Convert.ToDouble(p_drData["oprealgross_int"]);
            objDetail.m_dblOldIPREALGROSS_INT = Convert.ToDouble(p_drData["iprealgross_int"]);
            return objDetail;
        }
        #endregion

        #region 检查是否有药库管理权限
        /// <summary>
        /// 检查是否有药库管理权限
        /// </summary>
        /// <param name="strEmpID">员工ID</param>
        /// <param name="p_blnHasRole">是否有权限</param>
        internal void m_mthCheckHasAdminRole(string strEmpID, out bool p_blnHasRole)
        {
            ((clsDcl_DrugStoreCheck)this.m_objDomain).m_lngCheckEmpHasRole(strEmpID, out p_blnHasRole);

        }
        #endregion

        /// <summary>
        /// 入账
        /// </summary>
        internal void m_mthInAccount()
        {
            try
            {
                long lngRes = 0;
                long m_lngSeqid = 0;
                string m_strChittyid;
                string m_strDrugStoreid;

                m_lngSeqid = Convert.ToInt64(this.m_objViewer.m_dgvMain.SelectedRows[0].Cells["m_txtSerialNo"].Value);
                m_strChittyid = Convert.ToString(this.m_objViewer.m_dgvMain.SelectedRows[0].Cells["CHECKID_CHR"].Value);
                m_strDrugStoreid = Convert.ToString(this.m_objViewer.m_dgvMain.SelectedRows[0].Cells["drugstoreid_chr"].Value);
                DateTime m_dtmAccountDate = clsPub.CurrentDateTimeNow;
                lngRes = m_objDomain.m_lngInAccount(this.m_objViewer.LoginInfo.m_strEmpID, m_dtmAccountDate, m_lngSeqid, m_strChittyid, m_strDrugStoreid);
                if (lngRes > 0)
                {
                    DataRow drCurrent = m_dtvCurrentMainVienPage1[m_objViewer.m_dgvMain.SelectedRows[0].Index].Row;
                    drCurrent["INACCOUNTID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
                    drCurrent["INACCOUNTDATE_DAT"] = m_dtmAccountDate;
                    drCurrent["STATUS_INT"] = "入帐";

                    this.m_objViewer.m_dgvMain.SelectedRows[0].Cells["m_txtStatus"].Value = "入账";
                }


                if (lngRes > 0)
                {
                    MessageBox.Show("入账成功！", "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "药房盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region 获取盘点模式，0为默认，1为广医三院
        /// <summary>
        /// #region 获取盘点模式，0为默认，1为广医三院
        /// </summary>
        /// <param name="p_intCheckMode">盘点模式</param>
        internal void m_mthGetCheckMode(out int p_intCheckMode)
        {
            m_objDomain.m_mthGetCheckMode(out p_intCheckMode);
        }
        #endregion

        #region 检查单据状态值
        /// <summary>
        /// 检查单据状态值
        /// </summary>
        /// <param name="p_intType">单据类别：2为药房盘点单</param>
        /// <param name="p_lngSeq">主表seq</param>
        /// <param name="m_intStatus">单据状态值</param>
        /// <returns></returns>
        internal long m_lngCheckStatus(int p_intType, long p_lngSeq, out int m_intStatus)
        {
            long lngRes = 0;
            lngRes = m_objDomain.m_lngCheckStatus(p_intType, p_lngSeq, out  m_intStatus);
            return lngRes;
        }
        #endregion

        /// <summary>
        /// 是否住院药房
        /// </summary>
        /// <param name="p_strStorageid"></param>
        /// <param name="p_blnIsHospital"></param>
        internal long m_lngCheckIsHospital(string p_strStorageid, out bool p_blnIsHospital)
        {
            clsDcl_AskForMedicine objDom = new clsDcl_AskForMedicine();
            return objDom.m_lngCheckIsHospital(p_strStorageid, out p_blnIsHospital);
        }
    }
}
