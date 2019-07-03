using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Drawing;
using Sybase.DataWindow;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 药房请领控制层
    /// </summary>
    public class clsCtl_AskForMedManage: com.digitalwave.GUI_Base.clsController_Base
    {   
        /// <summary>
        /// 请领单信息
        /// </summary>
        internal DataTable m_dtAskMainInfo = new DataTable();
        /// <summary>
        /// 出库单信息
        /// </summary>
        internal DataTable m_dtOutStorageMainInfo = new DataTable();
        /// <summary>
        /// 药品基本信息表
        /// </summary>
        private DataTable m_dtMedicineInfo = new DataTable();
        /// <summary>
        /// 出库部门信息
        /// </summary>
        internal DataTable m_dtExportDept = new DataTable();
        /// <summary>
        /// 药房请领主界面域控制层
        /// </summary>
        private clsDcl_AskForMedicine m_objDomain;
        private clsDcl_AskForMedDetail m_objDomainDetail;
        private clsDcl_MakeOutStorageOrder m_objDomainOutStorage;
        private clsDcl_Instorage objDomainInStorage;
        /// <summary>
        /// 药房请领主界面
        /// </summary>
        private frmAskForMedManage m_objViewer;
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAskForMedManage)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_AskForMedManage()
        {
            m_objDomain = new clsDcl_AskForMedicine();
            m_objDomainDetail = new clsDcl_AskForMedDetail();
            m_objDomainOutStorage = new clsDcl_MakeOutStorageOrder();
            objDomainInStorage = new clsDcl_Instorage();
        }
        #region 获取请领部门信息
        /// <summary>
        /// 获取请领部门信息
        /// </summary>
        public void m_mthGetApplyDeptInfo(out DataTable m_dtDept)
        {
            long lngRes = -1;
            m_dtDept = new DataTable();
            //lngRes=clsPub.m_lngGetMedStoreInfo(out m_dtDept);
            lngRes = this.m_objDomain.m_lngGetApplyDept(out m_dtDept);

        }
        #endregion
        #region 获取出库部门信息
        /// <summary>
        /// 获取出库部门信息
        /// </summary>
        public void m_mthGetExportDeptInfo()
        {
            m_dtExportDept = new DataTable();
            this.m_objDomain.m_lngGetExportDept(out m_dtExportDept);
        }
        #endregion
        #region 获取药房当天请领主表信息
        /// <summary>
        /// 获取药房当天请领主表信息
        /// </summary>
        public void m_mthGetCurrentDayAskInfo(string m_strAskDeptid,string m_strStorageid)
        {
            //DataTable m_dtAskMainInfo = new DataTable();
            //DataTable m_dtOutStorageMainInfo = new DataTable();
            try
            {
                long lngRes = this.m_objDomain.m_lngGetAskInfo(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"), clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"), m_strAskDeptid, m_strStorageid, out m_dtAskMainInfo, out m_dtOutStorageMainInfo);
                double dblSummoney = 0d;
                if (lngRes > 0)
                {
                    if (m_dtAskMainInfo != null && m_dtAskMainInfo.Rows.Count > 0)
                    {

                        for (int i1 = 0; i1 < m_dtAskMainInfo.Rows.Count; i1++)
                        {
                            this.m_objDomain.m_lngGetAskMoney(Convert.ToInt64(m_dtAskMainInfo.Rows[i1]["seriesid_int"]), out dblSummoney);
                            m_dtAskMainInfo.Rows[i1]["summoney"] = dblSummoney;
                        }
                    }

                    if (m_dtOutStorageMainInfo != null && m_dtOutStorageMainInfo.Rows.Count > 0)
                    {
                        dblSummoney = 0d;
                        for (int i1 = 0; i1 < m_dtOutStorageMainInfo.Rows.Count; i1++)
                        {
                            this.m_objDomain.m_lngGetOutMoney(Convert.ToInt64(m_dtOutStorageMainInfo.Rows[i1]["seriesid_int"]), out dblSummoney);
                            m_dtOutStorageMainInfo.Rows[i1]["summoney"] = dblSummoney;
                        }
                    }                    
                }
                this.m_mthBindData();
                ShowMainAskMoney();
                ShowMainOutMoney();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误...");
            }
            finally
            {               
            }
        }

        internal void ShowMainAskMoney()
        {
            double dblTmp = 0d;
            DataTable m_dtbMain = (DataTable)this.m_objViewer.m_dgvAskMedMain.DataSource;
            if (m_dtbMain != null && m_dtbMain.Rows.Count > 0)
            {
                double dblTemp = 0d;
                for (int i1 = 0; i1 < m_dtbMain.Rows.Count; i1++)
                {
                    double.TryParse(Convert.ToString(m_dtbMain.Rows[i1]["summoney"]), out dblTmp);
                    dblTemp += Convert.ToDouble(dblTmp.ToString("F4"));
                }
                m_objViewer.m_lblAllRetailMoney.Text = dblTemp.ToString("F4") + "元";
            }
            else
            {
                m_objViewer.m_lblAllRetailMoney.Text = "0.0000元";
            }
        }

        internal void ShowMainOutMoney()
        {
            double dblTmp = 0d;
            DataTable m_dtbMain = (DataTable)this.m_objViewer.m_dgvOutStorageMain.DataSource;
            if (m_dtbMain != null && m_dtbMain.Rows.Count > 0)
            {
                double dblTemp = 0d;
                for (int i1 = 0; i1 < m_dtbMain.Rows.Count; i1++)
                {
                    double.TryParse(Convert.ToString(m_dtbMain.Rows[i1]["summoney"]), out dblTmp);
                    dblTemp += Convert.ToDouble(dblTmp.ToString("F4"));
                }
                m_objViewer.m_lblOutMoney.Text = dblTemp.ToString("F4") + "元";
            }
            else
            {
                m_objViewer.m_lblOutMoney.Text = "0.0000元";
            }
        }
        #endregion
        #region 绑定主表信息
        /// <summary>
        /// 绑定主表信息
        /// </summary>
        public void m_mthBindData()
        {
            if (this.m_objViewer.strStorageType == "2")
            {

                this.m_objViewer.m_dgvAskMedMain.Tag = m_dtAskMainInfo;
                DataView dv = m_dtAskMainInfo.DefaultView;
                //dv.RowFilter = "status_int<>'作废' and status_int<>'新制'";
                dv.RowFilter = "status_int = '提交'";//20080321
                m_dtAskMainInfo = dv.ToTable();
                this.m_objViewer.m_dgvAskMedMain.DataSource = m_dtAskMainInfo;
                if (m_dtAskMainInfo.Rows.Count == 0)
                    this.m_objViewer.m_dgvAskMedDetail.DataSource = null;

                this.m_objViewer.m_dgvOutStorageMain.DataSource = m_dtOutStorageMainInfo;
                if (m_dtOutStorageMainInfo.Rows.Count == 0)
                    this.m_objViewer.m_dgvOutStorageDetail.DataSource = null;
            }
            else
            {
                if (this.m_objViewer.m_btnShowDelete.Image != null)
                {
                    this.m_objViewer.m_dgvAskMedMain.Tag = m_dtAskMainInfo;
                    this.m_objViewer.m_dgvAskMedMain.DataSource = m_dtAskMainInfo;
                    if (m_dtAskMainInfo.Rows.Count == 0)
                        this.m_objViewer.m_dgvAskMedDetail.DataSource = null;
                }
                else
                {
                    this.m_objViewer.m_dgvAskMedMain.Tag = m_dtAskMainInfo;
                    DataView dv = m_dtAskMainInfo.DefaultView;
                    dv.RowFilter = "status_int<>'作废'";
                    m_dtAskMainInfo = dv.ToTable();
                    this.m_objViewer.m_dgvAskMedMain.DataSource = m_dtAskMainInfo;
                    if (m_dtAskMainInfo.Rows.Count == 0)
                        this.m_objViewer.m_dgvAskMedDetail.DataSource = null;

                }
                this.m_objViewer.m_dgvOutStorageMain.DataSource = m_dtOutStorageMainInfo;
                if (m_dtOutStorageMainInfo.Rows.Count == 0)
                    this.m_objViewer.m_dgvOutStorageDetail.DataSource = null;
            }

        }
        #endregion
        #region 根据主表流水号获取明细表信息
        /// <summary>
        /// 根据主表流水号获取明细表信息
        /// </summary>
        public void m_lngGetAskDetailInfoByid()
        {
            long lngRes = 0;
            DataTable m_dtDetail = new DataTable();
            string m_strSeq = this.m_objViewer.m_dgvAskMedMain.Rows[this.m_objViewer.m_dgvAskMedMain.CurrentCell.RowIndex].Cells["m_txtSeq"].Value.ToString().Trim();
            lngRes = this.m_objDomain.m_lngGetAskDetailInfoByid(m_objViewer.m_blnIsHospital,Convert.ToInt64(m_strSeq), out m_dtDetail);
            if (lngRes > 0)
            {
                this.m_objViewer.m_dgvAskMedDetail.DataSource = m_dtDetail;
                m_mthGetSubMoneyForAsk(m_dtDetail);
            }
        }
        #endregion
        #region 根据出库主表流水号获取明细表信息
        /// <summary>
        /// 根据出库主表流水号获取明细表信息
        /// </summary>
        public void m_lngGetOutStorageDetailInfoByid()
        {
            m_objViewer.m_hstEnough.Clear();
            if (this.m_objViewer.m_dgvOutStorageMain.CurrentCell == null)
                return;
            long lngRes = 0;
            DataTable m_dtDetail = new DataTable();
            string m_strSeq = this.m_objViewer.m_dgvOutStorageMain.Rows[this.m_objViewer.m_dgvOutStorageMain.CurrentCell.RowIndex].Cells["m_txtSeqid"].Value.ToString().Trim();
            lngRes = this.m_objDomainOutStorage.m_lngGetOutStorageDetailInfoByid(m_objViewer.m_blnIsHospital,Convert.ToInt64(m_strSeq), out m_dtDetail);
            if (lngRes > 0)
            {
                if (m_dtDetail != null && m_dtDetail.Rows.Count > 0)
                {
                    DataView dv = m_dtDetail.DefaultView;
                    dv.Sort = "seriesid_int";
                    m_dtDetail = dv.ToTable();

                    m_dtDetail.Columns.Add("validperiod_chr", typeof(string));
                    foreach (DataRow dr in m_dtDetail.Rows)
                    {
                        if (dr["lotno_vchr"].ToString() == "UNKNOWN")
                            dr["lotno_vchr"] = "";
                        if (Convert.ToDateTime(dr["validperiod_dat"]).ToString("yyyy-MM-dd") == "0001-01-01")
                        {
                            dr["validperiod_chr"] = "";
                        }
                        else
                        {
                            dr["validperiod_chr"] = Convert.ToDateTime(dr["validperiod_dat"]).ToString("yyyy-MM-dd");
                        }
                    }
                    m_dtDetail.Columns.Remove("validperiod_dat");
                    m_dtDetail.Columns["validperiod_chr"].ColumnName = "validperiod_dat";
                }
                m_mthGetEnoughState(m_dtDetail, out m_objViewer.m_hstEnough);
                this.m_objViewer.m_dgvOutStorageDetail.DataSource = m_dtDetail;
                this.m_mthGetSubMoney(m_dtDetail);
            }
        }

        private void m_mthGetEnoughState(DataTable p_dtDetail, out Hashtable p_hstEnough)
        {
            p_hstEnough = new Hashtable();
            string strMedicineID = string.Empty;
            int intRowCount = p_dtDetail.Rows.Count;
            DataRow drRow = null;
            double dblAsk = 0;
            double dblOut = 0;
            double dblHasOut = 0;
            DataTable dtbTemp = p_dtDetail.Copy();
            DataView dvDetail = dtbTemp.DefaultView;
            dvDetail.Sort = "medicineid_chr";
            dtbTemp = dvDetail.ToTable();
            for (int i1 = 0; i1 < intRowCount; i1++)
            {
                drRow = dtbTemp.Rows[i1];
                if (strMedicineID != drRow["medicineid_chr"].ToString())
                {
                    strMedicineID = drRow["medicineid_chr"].ToString();
                    dblHasOut = 0;
                    dblAsk = Convert.ToDouble(drRow["askamount_int"]);
                    dblOut = Convert.ToDouble(drRow["opamount"]);
                    if (dblAsk > dblOut)
                        p_hstEnough.Add(strMedicineID, 0);
                    else
                        p_hstEnough.Add(strMedicineID, 1);
                    dblHasOut = dblOut;
                }
                else
                {
                    dblAsk = Convert.ToDouble(drRow["askamount_int"]);
                    dblOut = Convert.ToDouble(drRow["opamount"]);
                    dblHasOut += dblOut;
                    if (dblAsk > dblHasOut)
                        p_hstEnough[strMedicineID] = 0;
                    else
                        p_hstEnough[strMedicineID] = 1;
                }
            }
        }
        #endregion
        #region 删除请领药品信息
        /// <summary>
        /// 删除请领药品信息
        /// </summary>
        internal void m_mthDeleteAskInfo(long lngSeq)
        {
            long[] lngSeqArr = new long[1];
            lngSeqArr[0] = lngSeq;
            long lngRes = m_objDomain.m_lngDeleAskInfo(lngSeqArr);
            if (lngRes > 0)
            {
                MessageBox.Show("删除成功", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < this.m_objViewer.m_dgvAskMedMain.Rows.Count; i++)
                {
                    for (int j = 0; j < lngSeqArr.Length; j++)
                    {
                        if (Convert.ToInt64(m_objViewer.m_dgvAskMedMain.Rows[i].Cells["m_txtSeq"].Value) == lngSeqArr[j])
                        {
                            m_objViewer.m_dgvAskMedMain.Rows[i].Cells["m_txtStatus"].Value = "作废";
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("删除失败", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region 提交请领药品信息
        /// <summary>
        /// 提交请领药品信息
        /// </summary>
        internal void m_mthCommitAskInfo()
        {
            List<clsDS_Ask_VO> m_objAskVoList = new List<clsDS_Ask_VO>();
            clsDS_Ask_VO TempVo;
            TempVo = new clsDS_Ask_VO();
            TempVo.m_lngSERIESID_INT = Convert.ToInt64(m_objViewer.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtSeq"].Value);
            TempVo.m_intSTATUS_INT = 2;
            TempVo.m_strCOMMITER_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
            TempVo.m_strCommiterName = this.m_objViewer.LoginInfo.m_strEmpName;
            TempVo.m_datCOMMIT_DAT = clsPub.CurrentDateTimeNow;
            m_objAskVoList.Add(TempVo);
            long lngRes = m_objDomain.m_lngCommiteAskInfo(m_objAskVoList.ToArray());
            if (lngRes > 0)
            {
                MessageBox.Show("提交成功", "药房请领提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvAskMedMain.CurrentCell.OwningRow.DataBoundItem)).Row;
                drCurrent["status_int"] = "提交";
                drCurrent["commiter_chr"] = TempVo.m_strCOMMITER_CHR;
                drCurrent["commitername"] = TempVo.m_strCommiterName;
                drCurrent["commit_dat"] = TempVo.m_datCOMMIT_DAT;
                this.m_objViewer.m_dgvAskMedMain.Refresh();
            }
            else
            {
                MessageBox.Show("提交失败", "药房请领提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region 提交请领药品信息
        /// <summary>
        ///  提交请领药品信息
        /// </summary>
        /// <param name="m_intType">状态值: 3、药库审核4、药房审核 </param>
        internal void m_mthExamAskInfo(int m_intType)
        {
            long lngSeqid = 0;
            lngSeqid = Convert.ToInt64(m_objViewer.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtSeq"].Value);
            long lngRes = m_objDomain.m_lngExamAskInfo(lngSeqid,m_intType,"");
            if (lngRes > 0)
            {
                m_objViewer.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtStatus"].Value = m_intType == 3 ? "药库审核" : "药房审核";
                this.m_objViewer.m_dgvAskMedMain.Refresh();
            }
        }
         #endregion
        #region 根据流水号进行药房审核
        /// <summary>
        /// 根据流水号进行药房审核
        /// </summary>
        /// <param name="m_lngOutStorateSeqid">出库主表序列</param>
        /// <param name="m_lngAskSeqid">请领主表序列</param>
        public void m_mthDrugStoreExam(long m_lngOutStorateSeqid,long m_lngAskSeqid)
        {
            try
            {
                if (this.m_objViewer.m_dgvOutStorageMain.SelectedRows.Count == 0)
                    return;
                long lngRes = 0;
                clsDS_Instorage_VO m_objMainVo = null;
                m_objMainVo = this.m_objGetMainISVO();
                clsDS_StorageDetail_VO[] m_objDetailVoArr = null;
                clsDS_Instorage_Detail[] m_objInStorageDetailVoArr = null;
                m_objInStorageDetailVoArr = this.m_objGetInstorageDetailArr(m_objMainVo.m_lngSERIESID_INT);
                m_objDetailVoArr = this.m_mthGetDS_StorageDetail(m_objMainVo);

                lngRes = this.objDomainInStorage.m_lngAddNewInstorage(ref m_objMainVo, ref m_objInStorageDetailVoArr, ref m_objDetailVoArr, 1, m_lngAskSeqid,4);
                
                //if (m_objDetailVoArr != null && m_objDetailVoArr.Length > 0)
                //{
                //    lngRes = this.objDomainInStorage.m_lngAddStorage(ref m_objDetailVoArr, 1);
                //    lngRes = this.objDomainInStorage.m_lngAddNewAccountDetail(m_objDetailVoArr);
                //}
                if (lngRes > 0)
                {
                    //long lngResult = -1;
                    //lngResult = m_objDomain.m_lngExamAskInfo(m_lngAskSeqid, 4, m_objMainVo.m_strINDRUGSTOREID_VCHR);
                    //if (lngResult > 0)
                    //{
                        MessageBox.Show("药房审核成功！", "药房请领提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        for (int i = 0; i < this.m_objViewer.m_dgvAskMedMain.Rows.Count; i++)
                        {
                            if (this.m_objViewer.m_dgvAskMedMain.Rows[i].Cells["m_txtSeq"].Value.ToString() == m_lngAskSeqid.ToString())
                            {
                                this.m_objViewer.m_dgvAskMedMain.Rows[i].Cells["m_txtStatus"].Value = "药房审核";
                                break;
                            }
                        }
                        this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskStausName"].Value = "药房审核";
                        this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtStatus_int"].Value=4;
                        this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["instoreid_vchr"].Value = m_objMainVo.m_strINDRUGSTOREID_VCHR;
                        //this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].DefaultCellStyle.ForeColor = System.Drawing.Color.Magenta;
                        this.m_objViewer.m_btnReturn.PerformClick();
                    //}
                }
                else
                {
                    MessageBox.Show("药房审核失败！", "药房请领提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "药房请领提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
#endregion
        #region 根据流水号进行药房入帐
        /// <summary>
        /// 根据流水号进行药房入帐
        /// </summary>
        /// <param name="m_lngAskSeqid">请领主表序列</param>
        public void m_mthDrugStoreInAccount(long m_lngAskSeqid)
        {
            try
            {
                if (this.m_objViewer.m_dgvOutStorageMain.SelectedRows.Count == 0)
                    return;
                clsDS_Instorage_VO m_objMainVo = null;
                m_objMainVo = this.m_objGetMainISVO();
                long lngResult = -1;
                lngResult = m_objDomain.m_lngInAccountAskInfo(m_lngAskSeqid, this.m_objViewer.LoginInfo.m_strEmpID, m_objMainVo.m_strINDRUGSTOREID_VCHR, m_objMainVo.m_strDRUGSTOREID_INT);
                if (lngResult > 0)
                {
                    MessageBox.Show("入帐成功！", "药房请领提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    for (int i = 0; i < this.m_objViewer.m_dgvAskMedMain.Rows.Count; i++)
                    {
                        if (this.m_objViewer.m_dgvAskMedMain.Rows[i].Cells["m_txtSeq"].Value.ToString() == m_lngAskSeqid.ToString())
                        {
                            this.m_objViewer.m_dgvAskMedMain.Rows[i].Cells["m_txtStatus"].Value = "入帐";
                            break;
                        }
                    }
                    this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskStausName"].Value = "入帐";
                    this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtStatus_int"].Value = 5;
                    this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].DefaultCellStyle.ForeColor = System.Drawing.Color.Magenta;
                    this.m_objViewer.m_btnReturn.PerformClick();
                }
                else
                {
                    MessageBox.Show("入帐失败！", "药房请领提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "药房请领提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
          #endregion
        #region 获取药库出库单明细内容
        /// <summary>
        ///  获取药库出库单明细内容
        /// </summary>
        /// <param name="p_drDetail"></param>
        /// <param name="p_lngMainSEQ"></param>
        /// <returns></returns>
        private clsDS_StorageDetail_VO[] m_mthGetDS_StorageDetail(clsDS_Instorage_VO m_objMainVo)
        {
            clsDS_StorageDetail_VO[] objDetailArr = null;
            //20080724 数量为0 的不用更新库存。
            int intRow = 0;
            for (int i1 = 0; i1 < this.m_objViewer.m_dgvOutStorageDetail.Rows.Count; i1++)
            {
                if (Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[i1].Cells["m_dgvtxtOutAmount"].Value) != 0)
                {
                    intRow++;
                }
            }
            if (intRow > 0)
            {
                objDetailArr = new clsDS_StorageDetail_VO[intRow];
                intRow = 0;
                for (int iRow = 0; iRow < this.m_objViewer.m_dgvOutStorageDetail.Rows.Count; iRow++)
                {
                    if (Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtOutAmount"].Value) == 0)
                    {
                        continue;
                    }
                    objDetailArr[intRow] = new clsDS_StorageDetail_VO();
                    objDetailArr[intRow].m_strDRUGSTOREID_CHR = this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskDeptid"].Value.ToString();
                    objDetailArr[intRow].m_dtmINSTORAGEDATE_DAT = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtinstoragedate_dat"].Value == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtinstoragedate_dat"].Value.ToString());
                    objDetailArr[intRow].m_strINSTOREID_VCHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtinstorageid_vchr"].Value.ToString();
                    objDetailArr[intRow].m_strMEDICINEID_CHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["medicineid_chr"].Value.ToString();
                    objDetailArr[intRow].m_strMEDICINENAME_VCHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtMedicineName"].Value.ToString();
                    objDetailArr[intRow].m_strMEDSPEC_VCHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtMedicineSpec"].Value.ToString();
                    objDetailArr[intRow].m_strOPUNIT_CHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtOutUint"].Value.ToString();
                    objDetailArr[intRow].m_dblOPREALGROSS_INT = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtOutAmount"].Value.ToString());
                    objDetailArr[intRow].m_strIPUNIT_CHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtipunit_chr"].Value.ToString();
                    objDetailArr[intRow].m_dblIPREALGROSS_INT = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txIPAmount"].Value.ToString());
                    objDetailArr[intRow].m_dblPACKQTY_DEC = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtPackqty_dec"].Value.ToString());
                    objDetailArr[intRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtEffectDate"].Value.ToString());
                    objDetailArr[intRow].m_strLOTNO_VCHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtProduceNumber"].Value.ToString();
                    objDetailArr[intRow].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtBuyPrice"].Value.ToString());
                    objDetailArr[intRow].m_dblIPWHOLESALEPRICE_INT = Math.Round(Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtBuyPrice"].Value.ToString()) / Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtPackqty_dec"].Value.ToString()), 4);
                    objDetailArr[intRow].m_dblOPRETAILPRICE_INT = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtSalePrice"].Value.ToString());
                    objDetailArr[intRow].m_dblIPRETAILPRICE_INT = Math.Round(Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtSalePrice"].Value) / Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtPackqty_dec"].Value.ToString()), 4);
                    objDetailArr[intRow].m_dtmDSINSTORAGEDATE_DAT = m_objMainVo.m_datMAKEORDER_DAT;
                    objDetailArr[intRow].m_intType = Convert.ToInt16(m_objMainVo.m_intFORMTYPE_INT);
                    objDetailArr[intRow].m_strDSINSTOREID_VCHR = m_objMainVo.m_strINDRUGSTOREID_VCHR;
                    objDetailArr[intRow].m_strMEDICINETYPEID_CHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtMedicineTypeid"].Value.ToString();
                    objDetailArr[intRow].m_strPRODUCTORID_CHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["productorid_chr"].Value != DBNull.Value ? this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["productorid_chr"].Value.ToString() : string.Empty;
                    objDetailArr[intRow].STATUS = 1;
                    intRow++;

                }
            }
            return objDetailArr;
        }
        #endregion
        #region 获取入库子表内容
        /// <summary>
        ///  获取入库子表内容
        /// </summary>
        /// <param name="p_drDetail"></param>
        /// <param name="p_lngMainSEQ"></param>
        /// <returns></returns>
        private clsDS_Instorage_Detail[] m_objGetInstorageDetailArr(long p_lngMainSEQ)
        {
            clsDS_Instorage_Detail[] objDetailArr = new clsDS_Instorage_Detail[this.m_objViewer.m_dgvOutStorageDetail.Rows.Count];
            for (int iRow = 0; iRow < this.m_objViewer.m_dgvOutStorageDetail.Rows.Count; iRow++)
            {
                objDetailArr[iRow] = new clsDS_Instorage_Detail();
                objDetailArr[iRow].m_lngSERIESID_INT = -1;
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["medicineid_chr"].Value.ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtMedicineName"].Value.ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtMedicineSpec"].Value.ToString();
                objDetailArr[iRow].m_strOPUNIT_CHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtOutUint"].Value.ToString();
                objDetailArr[iRow].m_dblOPAMOUNT_INT = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtOutAmount"].Value.ToString());
                objDetailArr[iRow].m_strIPUNIT_CHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtipunit_chr"].Value.ToString();


                objDetailArr[iRow].m_dblIPAMOUNT_INT = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txIPAmount"].Value.ToString());
                objDetailArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtPackqty_dec"].Value.ToString());

                if (this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtEffectDate"].Value.ToString().Length > 0)
                {
                    objDetailArr[iRow].m_datVALIDPERIOD_DAT = Convert.ToDateTime(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtEffectDate"].Value.ToString());
                }
                if (this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtProduceNumber"].Value.ToString().Length == 0)
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtProduceNumber"].Value.ToString();
                }
                objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtBuyPrice"].Value.ToString());
                objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT = Math.Round(Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtBuyPrice"].Value.ToString()) / objDetailArr[iRow].m_dblPACKQTY_DEC, 4);
                objDetailArr[iRow].m_dblOPRETAILPRICE_INT = Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtSalePrice"].Value.ToString());
                objDetailArr[iRow].m_dblIPRETAILPRICE_INT = Math.Round(Convert.ToDouble(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtSalePrice"].Value)/ objDetailArr[iRow].m_dblPACKQTY_DEC, 4);
                objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtinstoragedate_dat"].Value==DBNull.Value?DateTime.MinValue:Convert.ToDateTime(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtinstoragedate_dat"].Value);
                objDetailArr[iRow].m_strINSTOREID_VCHR = Convert.ToString(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["m_txtinstorageid_vchr"].Value);
                objDetailArr[iRow].m_intSTATUS = 1;
                objDetailArr[iRow].m_strPRODUCTORID_CHR = Convert.ToString(this.m_objViewer.m_dgvOutStorageDetail.Rows[iRow].Cells["productorid_chr"].Value);
            }
            return objDetailArr;
        }
        #endregion
        #region 获取入库主表内容
        /// <summary>
        /// 获取入库主表内容
        /// </summary>
        /// <returns></returns>
        private clsDS_Instorage_VO m_objGetMainISVO()
        {

            clsDS_Instorage_VO m_objCurrentMain = new clsDS_Instorage_VO();
            m_objCurrentMain.m_datMAKEORDER_DAT = clsPub.CurrentDateTimeNow;
            m_objCurrentMain.m_strMAKERID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
            m_objCurrentMain.m_intSTATUS = 2;
            //1、请领入库 2、药房自身入库(来源部门是本药房)  3、药房借调（来源部门是其它药房） 4、科室借调（来源部门除了药房以外的部门） 5、盘盈，
            m_objCurrentMain.m_intFORMTYPE_INT = 1;
            clsDcl_MakeOutStorageOrder objmain = new clsDcl_MakeOutStorageOrder();
            int intTypeCode;
            objmain.m_lngGetTypeCodeByName(0, "正常入库", out intTypeCode);
            m_objCurrentMain.m_strTYPECODE_VCHR = intTypeCode.ToString();
            m_objCurrentMain.m_strOUTSTORAGEID_VCHR = this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtOutStorageid"].Value.ToString();
            if (this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["instoreid_vchr"].Value != null)
            {
                m_objCurrentMain.m_strINDRUGSTOREID_VCHR = this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["instoreid_vchr"].Value.ToString();
            }
            m_objCurrentMain.m_datSTORAGEEXAM_DATE = Convert.ToDateTime(this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtExamDate"].Value.ToString());
            m_objCurrentMain.m_datDRUGSTOREEXAM_DATE = clsPub.CurrentDateTimeNow;
            m_objCurrentMain.m_strSTORAGEEXAMID_CHR = this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtExamerid"].Value.ToString();
            m_objCurrentMain.m_strDRUGSTOREEXAMID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;            
            m_objCurrentMain.m_strDRUGSTOREID_INT = this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskDeptid"].Value.ToString();
            m_objCurrentMain.m_strBORROWDEPT_CHR = this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtStorageID"].Value.ToString();
            m_objCurrentMain.m_strASKID_VCHR = this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskid"].Value.ToString();
            return m_objCurrentMain;
        }
       #endregion

        public void m_mthGetSubMoney(DataTable dtbSub)
        {
            this.m_objViewer.m_lblRetailSubMoney.Text = "0.0000";

            double subBuyInmoney = 0.00;
            double subWholeSaleMoney = 0.00;
            double subRetailMoney = 0.00;
            double subLY = 0.00;
            DataRow dr = null;
            if (dtbSub == null) return;
            for (int i = 0; i < dtbSub.Rows.Count; i++)
            {
                dr = dtbSub.Rows[i];

                subBuyInmoney += Convert.ToDouble(dr["inmoney"]);
                subRetailMoney += Convert.ToDouble(dr["retailmoney"]);
                subWholeSaleMoney += Convert.ToDouble(dr["ipamount"]);
            }
            subLY = subRetailMoney - subBuyInmoney;
            this.m_objViewer.m_lblRetailSubMoney.Text = subRetailMoney.ToString("0.0000")+"元";
        }

        /// <summary>
        /// 请领单零售金额
        /// </summary>
        /// <param name="dtbSub"></param>
        public void m_mthGetSubMoneyForAsk(DataTable dtbSub)
        {
            this.m_objViewer.m_lblRetailSubMoney.Text = "0.0000元";
            double subRetailMoney = 0.00;
            double m_dblTemp = 0d;
            DataRow dr = null;
            if (dtbSub == null) return;

            for (int i = 0; i < dtbSub.Rows.Count; i++)
            {
                dr = dtbSub.Rows[i];
                double.TryParse(Convert.ToString(Convert.ToDouble(dr["unitprice_mny"]) * Convert.ToDouble(dr["opamount_int"])), out m_dblTemp);
                subRetailMoney += Convert.ToDouble(m_dblTemp.ToString("F4"));
            }
            
            this.m_objViewer.m_lblRetailSubMoney.Text = subRetailMoney.ToString("0.0000")+"元";
        }

        internal void m_mthPrint()
        {
            if (m_objViewer.m_dgvAskMedMain.Rows.Count <= 0)
                return;
            if (m_objViewer.tabControl1.SelectedIndex == 0)
            {
                int m_intRowIndex = m_objViewer.m_dgvAskMedMain.CurrentCell.RowIndex;
                string m_strTemp = Convert.ToString(m_objViewer.m_dgvAskMedMain.Rows[m_intRowIndex].Cells["m_txtBillNo"].Value);               
                DataStore ds = new DataStore();
                ds.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
                ds.DataWindowObject = "d_op_askmedicine";
                
                if (m_objViewer.m_blnIsHospital)
                {
                    ds.Modify("t_3.text = '住院单位'");
                    ds.Modify("t_1.text='" + m_objComInfo.m_strGetHospitalTitle() + "住院药房请领单'");
                }
                else
                {
                    ds.Modify("t_1.text='" + m_objComInfo.m_strGetHospitalTitle() + "门诊药房请领单'");
                }
                ds.Modify("t_aksdept.text='" + Convert.ToString(m_objViewer.m_dgvAskMedMain.Rows[m_intRowIndex].Cells["m_txtAskDeptName"].Value) + "'");
                ds.Modify("t_askid.text='" + m_strTemp + "'");
                ds.Modify("t_asktime.text='" + Convert.ToDateTime(m_objViewer.m_dgvAskMedMain.Rows[m_intRowIndex].Cells["m_txtAskDate"].Value).ToString("yyyy年MM月dd日") + "'");
                ds.Modify("t_asker.text='" + Convert.ToString(m_objViewer.m_dgvAskMedMain.Rows[m_intRowIndex].Cells["m_txtAskName"].Value) + "'");
                DataTable m_dtbSub = this.m_objViewer.m_dgvAskMedDetail.DataSource as DataTable;
                DataRow[] drArr = m_dtbSub.Select("seriesid_int is not null and seriesid2_int is not null");
                for (int i = 0; i < drArr.Length; i++)
                {
                    int row = ds.InsertRow(0);
                    ds.SetItemString(row, "RowNo", Convert.ToString(i + 1));
                    ds.SetItemString(row, "MedCode", drArr[i]["assistcode_chr"].ToString());
                    ds.SetItemString(row, "MedName", drArr[i]["MEDICINENAME_VCHR"].ToString());
                    ds.SetItemString(row, "MedSepc", drArr[i]["MEDSPEC_VCHR"].ToString());
                    ds.SetItemString(row, "OPAmount", drArr[i]["OPAMOUNT_INT"].ToString());
                    ds.SetItemString(row, "OPUnit", drArr[i]["OPUNIT_CHR"].ToString());
                    ds.SetItemString(row, "IPAmount", drArr[i]["AMOUNT_INT"].ToString());
                    ds.SetItemString(row, "IPUnit", drArr[i]["UNIT_CHR"].ToString());
                    ds.SetItemString(row, "Package", drArr[i]["PACKQTY_DEC"].ToString());
                }
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(ds);
            }
            else
            {
                /* 三院格式
                int p_intRowIndex = this.m_objViewer.m_dgvOutStorageMain.CurrentCell.RowIndex;
                DataTable p_OutDtbVal = new DataTable();
                clsDcl_MedicineOut m_objDo = new clsDcl_MedicineOut();
                long p_lngSeqid = Convert.ToInt64(this.m_objViewer.m_dgvOutStorageMain.Rows[p_intRowIndex].Cells["m_txtSeqid"].Value);
                m_objDo.m_lngGetOutStorageDetailReportForGY3Y(p_lngSeqid, out p_OutDtbVal);

                DataStore ds = new DataStore();
                ds.LibraryList = Application.StartupPath + "\\pb_gy3y_ms.pbl";
                ds.DataWindowObject = "ms_outstoragedetail";
                ds.Reset();
                ds.Modify("t_title.text='" + this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle() + Convert.ToString(m_objViewer.m_dgvOutStorageMain.Rows[p_intRowIndex].Cells["m_txtStorageName"].Value) + "出库凭证'");
                ds.Modify("m_storagename.text='" + Convert.ToString(m_objViewer.m_dgvOutStorageMain.Rows[p_intRowIndex].Cells["m_txtStorageName"].Value) + "'");
                ds.Modify("m_txtreceivedept.text='" + Convert.ToString(m_objViewer.m_dgvOutStorageMain.Rows[p_intRowIndex].Cells["m_txtAskDepName"].Value) + "'");
                ds.Modify("m_txtman.text='" + Convert.ToString(m_objViewer.m_dgvOutStorageMain.Rows[p_intRowIndex].Cells["m_txtMakerName"].Value) + "'");
                //ds.Modify("m_txtman2.text='" + Convert.ToString(m_objViewer.m_dgvOutStorageMain.Rows[p_intRowIndex].Cells["m_txtMakerName"].Value) + "'");
                ds.Modify("m_txtman3.text='" + Convert.ToString(m_objViewer.m_dgvOutStorageMain.Rows[p_intRowIndex].Cells["m_txtMakerName"].Value) + "'");
                ds.Modify("m_txtman4.text='" + Convert.ToString(m_objViewer.m_dgvOutStorageMain.Rows[p_intRowIndex].Cells["m_txtExamerName"].Value) + "'");
                ds.Modify("m_txtoutputorder.text='" + Convert.ToString(m_objViewer.m_dgvOutStorageMain.Rows[p_intRowIndex].Cells["m_txtOutStorageid"].Value) + "'");
                ds.Modify("t_RowNum.text='" + p_OutDtbVal.Rows.Count + "'");
                ds.Retrieve(p_OutDtbVal);
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(ds);
                */



                decimal decTMoney;
                decTMoney = Convert.ToDecimal(m_objViewer.m_lblRetailSubMoney.Text.Replace("元",""));
                string strAllInMoney = new Money(decTMoney).ToString();

                if (m_objViewer.m_dgvOutStorageDetail.Rows.Count == 0)
                {
                    MessageBox.Show("抱歉，没有数据可打印！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                int intPrintType;
                m_objDomain.m_lngGetPrinType(out intPrintType);
                frmMedicineOutReport frmReport = new frmMedicineOutReport();
                DataTable p_OutDtbVal = new DataTable();
                this.m_objDomain.m_lngGetOutStorageDetailReport(Convert.ToInt64(this.m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtSeqid"].Value), intPrintType, out p_OutDtbVal);

                DataRow dro;

                int i_temp = 0;
                DataTable dtb = new DataTable();

                string RoomName = m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtStorageName"].Value.ToString();


                if (intPrintType == 0)
                {
                    dtb = p_OutDtbVal.Clone();
                    for (int i_low = 0; i_low < p_OutDtbVal.Rows.Count; i_low++)
                    {
                        i_temp++;
                        dtb.ImportRow(p_OutDtbVal.Rows[i_low]);
                        //药品和材料不能打在同一张

                        if (((i_low + 1) >= p_OutDtbVal.Rows.Count) || ((p_OutDtbVal.Rows[i_low]["medicinetypesetid"].ToString()) != (p_OutDtbVal.Rows[i_low + 1]["medicinetypesetid"].ToString())))
                        {
                            int ros = 7 - i_temp % 7;
                            if (ros != 7)
                            {
                                int i_valCount = dtb.Rows.Count + ros;
                                for (int i = 0; i < ros; i++)
                                {
                                    dro = dtb.NewRow();
                                    dtb.Rows.Add(dro);
                                }
                                i_temp = 0;
                            }
                        }
                    }
                    frmReport.datWindow.DataWindowObject = "outstorage_detailreport_lj";
                }

                if (intPrintType == 1)
                {
                    dtb = p_OutDtbVal.Copy(); 
                    frmReport.datWindow.DataWindowObject = "outstorage_detailreport_cs";
                }

                frmReport.ReceiveDept = m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskDepName"].Value.ToString();
                frmReport.OutputOrder = m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtOutStorageid"].Value.ToString();
                string mmm = new Money(decTMoney).ToString();
                frmReport.strBigwrith = mmm;
                frmReport.zDate = Convert.ToDateTime(m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtExamDate"].Value).ToString("yyyy年MM月dd日 HH时mm分ss秒");
                frmReport.Man = m_objViewer.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtExamerName"].Value.ToString(); 
                frmReport.RoomName = RoomName;
                frmReport.dtb = dtb;
                frmReport.i_showType = 1;
                frmReport.strAllInMoney = strAllInMoney;
                frmReport.ShowDialog();
            }
        }

        internal long m_lngGetAskStatus(long p_lngAskSeqid,out string p_strStatus)
        {
            return m_objDomain.m_lngGetAskStatus(p_lngAskSeqid,out p_strStatus);
        }

        /// <summary>
        /// 是否住院药房
        /// </summary>
        /// <param name="p_strStorageid"></param>
        /// <param name="p_blnIsHospital"></param>
        internal long m_lngCheckIsHospital(string p_strStorageid, out bool p_blnIsHospital)
        {
            return m_objDomain.m_lngCheckIsHospital(p_strStorageid, out p_blnIsHospital);
        }

        #region 检查单据状态值
        /// <summary>
        /// 检查单据状态值
        /// </summary>
        /// <param name="p_intType">单据类别：1为药房出库单</param>
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
    }
}
