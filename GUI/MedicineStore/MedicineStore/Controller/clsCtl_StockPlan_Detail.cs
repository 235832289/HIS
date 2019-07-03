using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.IO;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 采购表
    /// </summary>
    public class clsCtl_StockPlan_Detail : com.digitalwave.GUI_Base.clsController_Base
    {

        #region 构造函数

        /// <summary>
        /// 采购入库
        /// </summary>
        public clsCtl_StockPlan_Detail()
        {
            m_objDomain = new clsDcl_StockPlan_Detail();
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
            m_objViewer = (frmStockPlan_Detail)frmMDI_Child_Base_in;
        }
        #endregion

        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_StockPlan_Detail m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmStockPlan_Detail m_objViewer;

        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 当前药品采购主表信息
        /// </summary>
        private clsMS_StockPlan_VO m_objCurrentMain = null;
        /// <summary>
        /// 当前药品采购子表信息
        /// </summary>
        private clsMS_StockPlan_Detail_VO[] m_objCurrentSubArr = null;
        /// <summary>
        /// 供应商（经销商）
        /// </summary>
        DataTable m_dtbVendor = null;
        /// <summary>
        /// 药品列表
        /// </summary>
        ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 保存新建计划单
        /// </summary>
        public List<clsMS_StockPlan_VO> m_objMainVoList = null;
        #endregion
        #region 初始化药品信息表
        /// <summary>
        /// 初始化药品信息表
        /// </summary>
        /// <returns></returns>
        internal DataTable m_dtbInitTable()
        {
            DataTable dtbMedicine = new DataTable();
            dtbMedicine.Columns.AddRange(new DataColumn[] { new DataColumn("SERIESID_INT"), new DataColumn("SERIESID2_INT"), new DataColumn("MEDICINEID_CHR"), new DataColumn("MEDICINENAME_VCHR"),
                new DataColumn("MEDSPEC_VCHR"), new DataColumn("PACKAMOUNT"), new DataColumn("PACKUNIT_VCHR"),new DataColumn("PACKCALLPRICE_INT"),new DataColumn("PACKCONVERT_INT"),new DataColumn("LOTNO_VCHR"),
                new DataColumn("AMOUNT"), new DataColumn("CALLPRICE_INT"), new DataColumn("WHOLESALEPRICE_INT"), new DataColumn("RETAILPRICE_INT"), new DataColumn("VALIDPERIOD_DAT"),new DataColumn("ACCEPTANCE_INT"),
                new DataColumn("APPROVECODE_VCHR"), new DataColumn("APPARENTQUALITY_INT"), new DataColumn("PACKQUALITY_INT"), new DataColumn("EXAMRUSULT_INT"), new DataColumn("EXAMINER"), new DataColumn("PRODUCTORID_CHR"),
                new DataColumn("ACCOUNTPERIOD_INT"), new DataColumn("ACCEPTANCECOMPANY_CHR"), new DataColumn("ACCEPTANCECOMPANYname"), new DataColumn("examinername"),new DataColumn("ACCEPTANCENAME"),new DataColumn("medicinetypeid_chr"),
                new DataColumn("APPARENTQUALITYNAME"), new DataColumn("PACKQUALITYNAME"), new DataColumn("EXAMRUSULTNAME"), new DataColumn("UNIT_VCHR"), new DataColumn("STATUS"), new DataColumn("SALEMONEY"), 
                new DataColumn("SortNum"), new DataColumn("MedicineCode"),new DataColumn("WHOLESALEMONEY"),new DataColumn("MEDICINEPREPTYPE_CHR"),new DataColumn("REMARK_VCHR"),new DataColumn("assistcode_chr"),
            new DataColumn("VENDORID_CHR"),new DataColumn("vendorname"),new DataColumn("stocksum"),new DataColumn("LASTINSTORAGEDATE_DAT")});
            return dtbMedicine;
        }
        #endregion


        /// <summary>
        /// 显示供应商查询
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_mthGetVendor(out m_dtbVendor);

                m_ctlQueryVendor = new ctlQueryVendor(m_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);

                int X = m_objViewer.panel2.Location.X + m_objViewer.m_txtProviderName.Location.X;
                int Y = m_objViewer.panel2.Location.Y + m_objViewer.m_txtProviderName.Location.Y + m_objViewer.m_txtProviderName.Size.Height;

                m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            }
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtProviderName.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtProviderName.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtProviderName.Text = MS_VO.m_strVendorName;
            m_objViewer.m_dtpPlanDate.Focus();
        }

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetVendor(out p_dtbVendor);
        }

        #region 获取审核流程设置
        /// <summary>
        /// 获取审核流程设置
        /// </summary>
        /// <param name="p_intCommitFolw">审核流程设置</param>
        /// <returns></returns>
        internal void m_mthGetCommitFlow(out int p_intCommitFolw)
        {
            long lngRes = m_objDomain.m_lngGetCommitFlow(out p_intCommitFolw);
        }
        #endregion

        #region 设置药品信息至界面(外部传入VO，以进行修改)
        /// <summary>
        /// 设置药品信息至界面(外部传入VO，以进行修改)
        /// </summary>
        /// <param name="p_objISVO">主表信息</param>
        /// <param name="p_objDetailArr">子表信息</param>
        /// <param name="p_intSelectedSubRow">选中子表行</param>
        internal void m_mthSetMedicineDetailToUI(clsMS_StockPlan_VO p_objISVO, clsMS_StockPlan_Detail_VO[] p_objDetailArr, int p_intSelectedSubRow)
        {
            if (p_objISVO == null)
            {
                return;
            }

            #region 主表
            m_objViewer.m_lngMainSEQ = p_objISVO.m_lngSERIESID_INT;
            m_objViewer.m_txtProviderName.Text = p_objISVO.m_strVENDORNAME_VCHR;
            m_objViewer.m_txtProviderName.Tag = p_objISVO.m_strVENDORID_CHR;
            m_objViewer.m_txtMakeBillPerson.Text = p_objISVO.m_strMAKERNAME_VCHR;
            m_objViewer.m_txtMakeBillPerson.Tag = p_objISVO.m_strMAKERID_CHR;
            m_objViewer.m_txtRemark.Text = p_objISVO.m_strCOMMENT_VCHR;
            m_objViewer.m_dtpNewOrderDate.Text = p_objISVO.m_datNEWORDER_DAT.ToString("yyyy年MM月dd日"); ;
            m_objViewer.m_txtBillNumber.Text = p_objISVO.m_strSTOCKPLANID_VCHR;
            m_objCurrentMain = p_objISVO;

            if (p_objDetailArr == null)
            {
                return;
            }
            #endregion

            #region 子表
            try
            {
                m_objViewer.m_dtbMedicineInfo = m_dtbInitTable();
                m_objViewer.m_dtbMedicineInfo.BeginLoadData();
                DataRow[] drSub = new DataRow[p_objDetailArr.Length];
                for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                {
                    drSub[iRow] = m_objViewer.m_dtbMedicineInfo.NewRow();
                    drSub[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                    drSub[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                    drSub[iRow]["MEDICINEID_CHR"] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    drSub[iRow]["MEDICINENAME_VCHR"] = p_objDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    drSub[iRow]["MEDSPEC_VCHR"] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                    drSub[iRow]["AMOUNT"] = p_objDetailArr[iRow].m_dblAMOUNT;
                    drSub[iRow]["PRODUCTORID_CHR"] = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                    drSub[iRow]["UNIT_VCHR"] = p_objDetailArr[iRow].m_strUNIT_VCHR;
                    drSub[iRow]["SortNum"] = iRow + 1;
                    drSub[iRow]["ASSISTCODE_CHR"] = p_objDetailArr[iRow].m_strASSISTCODE_CHR;
                    drSub[iRow]["REMARK_VCHR"] = p_objDetailArr[iRow].m_strREMARK_VCHR;
                    drSub[iRow]["STATUS"] = p_objDetailArr[iRow].m_lngSTATUS;
                    drSub[iRow]["CALLPRICE_INT"] = p_objDetailArr[iRow].m_dblCALLPRICE_INT;
                    drSub[iRow]["STOCKSUM"] = p_objDetailArr[iRow].m_dblSTOCKSUM;
                    drSub[iRow]["LASTINSTORAGEDATE_DAT"] = p_objDetailArr[iRow].m_datLASTINSTORAGEDATE_DAT;
                    drSub[iRow]["VENDORID_CHR"] = p_objDetailArr[iRow].m_strVENDORID_CHR;
                    drSub[iRow]["vendorname"] = p_objDetailArr[iRow].m_strVENDORNAME_VCHR;
                    m_objViewer.m_dtbMedicineInfo.LoadDataRow(drSub[iRow].ItemArray, true);
                }
            }
            catch (Exception Ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(Ex);
            }
            finally
            {
                m_objViewer.m_dtbMedicineInfo.EndLoadData();
            }
            m_objViewer.m_dgvMedicineDetail.DataSource = m_objViewer.m_dtbMedicineInfo;

            if (p_intSelectedSubRow > 0 && m_objViewer.m_dgvMedicineDetail.Rows.Count > 0 && p_intSelectedSubRow < m_objViewer.m_dgvMedicineDetail.Rows.Count)
            {
                m_objViewer.m_dgvMedicineDetail.Rows[p_intSelectedSubRow].Selected = true;
                m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail.Rows[p_intSelectedSubRow].Cells[0];
            }
            m_objViewer.m_dtbMedicineInfo.AcceptChanges();
            #endregion
        }
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            long lngRes = m_objDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicinDict);
        }
        #endregion


        #region 保存当前采购计划
        /// <summary>
        /// 保存当前采购计划
        /// </summary>
        internal long m_lngSaveStockPlan()
        {
            //if (m_objCurrentMain != null)
            //{                
            //    if (m_objViewer.m_intCommitFolow == 0)
            //    {
            //        MessageBox.Show("该药品采购记录已审核，不能修改", "药品采购", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return -1;
            //    }
            //}

            if (m_objCurrentMain != null && m_objCurrentMain.m_lngSTATE_INT != 1 && m_objCurrentMain.m_lngSTATE_INT != 0)
            {
                m_objViewer.m_blnHasCommit = true;
            }

            if (m_objViewer.m_dtbMedicineInfo.Rows.Count == 0)
            {
                MessageBox.Show("请先录入药品信息", "药品采购", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (Convert.ToString(m_objViewer.m_txtProviderName.Tag) == "")
            {
                MessageBox.Show("请先选择供应商", "药品采购", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            DateTime datOutTime;
            m_objDomain.m_mthGetAccountperiodTime(out datOutTime);
            if (Convert.ToDateTime(m_objViewer.m_dtpPlanDate.Text) < datOutTime)
            {
                MessageBox.Show("采购日期不能小于上次帐务结转的结束日期。\r\n上次结转结束日期是：" + datOutTime.ToString("yyyy年MM月dd日"), "药品采购", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_dtpPlanDate.Focus();
                return -1;
            }

            double dblAmount = 0d;
            DataRow drTemp = null;
            for (int iRow = 0; iRow < m_objViewer.m_dtbMedicineInfo.Rows.Count; iRow++)
            {
                drTemp = m_objViewer.m_dtbMedicineInfo.Rows[iRow];
                if (drTemp.RowState == DataRowState.Unchanged || drTemp.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["AMOUNT"] != DBNull.Value)
                {
                    if (!double.TryParse(drTemp["AMOUNT"].ToString(), out dblAmount))
                    {
                        MessageBox.Show("采购数量必须为数字", "药品采购", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    else
                    {
                        if (dblAmount <= 0)
                        {
                            MessageBox.Show("采购数量必须大于零", "药品采购", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                    }
                }
            }

            this.m_objViewer.m_dtbMedicineInfo.AcceptChanges();
            long lngRes = 0;

            try
            {
                bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;

                clsMS_StockPlan_VO objMain = m_objGetMainISVO();
                DataRow[] drNew = m_objViewer.m_dtbMedicineInfo.Select("MEDICINEID_CHR IS NOT NULL AND AMOUNT IS NOT NULL");
                clsMS_StockPlan_Detail_VO[] objDetailArr = m_objGetDetailArr(drNew, objMain.m_lngSERIESID_INT);
                if (blnIsAddNew)
                {
                    lngRes = m_objDomain.m_lngAddNewPlanMedInfo(m_objViewer.m_intCommitFolow, ref objMain, ref objDetailArr);
                    if (lngRes > 0 && this.m_objMainVoList != null)
                    {

                        this.m_objMainVoList.Add(objMain);

                    }
                }
                else
                {
                    lngRes = m_objDomain.m_lngUpdatePlanMedInfo(m_objViewer.m_intCommitFolow, objMain, ref objDetailArr);
                    if (lngRes > 0 && this.m_objMainVoList != null)
                    {
                        foreach (clsMS_StockPlan_VO vo in m_objMainVoList)
                        {
                            if (vo.m_lngSERIESID_INT == objMain.m_lngSERIESID_INT)
                            {
                                m_objMainVoList.Remove(vo);
                            }
                        }
                        m_objMainVoList.Add(objMain);
                    }
                }

                if (lngRes > 0)
                {
                    m_objViewer.m_lngMainSEQ = objMain.m_lngSERIESID_INT;
                    m_objViewer.m_txtBillNumber.Text = objMain.m_strSTOCKPLANID_VCHR;
                    m_objCurrentMain = objMain;
                    m_objCurrentSubArr = objDetailArr;

                    m_mthSetSeriesIDToUI(objDetailArr);

                    #region 去除空行
                    DataRow[] drNull = m_objViewer.m_dtbMedicineInfo.Select("AMOUNT IS  NULL");
                    if (drNull != null && drNull.Length > 0)
                    {
                        foreach (DataRow drDel in drNull)
                        {
                            m_objViewer.m_dtbMedicineInfo.Rows.Remove(drDel);
                        }
                    }
                    #endregion

                    m_objViewer.m_dtbMedicineInfo.AcceptChanges();


                    MessageBox.Show("保存成功", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }


            }
            catch (Exception Ex)
            {
                string strExMessage = "保存失败" + Environment.NewLine + Ex.Message;
                return -1;
            }
            return lngRes;


        }


        /// <summary>
        /// 更新界面数据的序列号
        /// </summary>
        /// <param name="p_objDetailArr"></param>
        private void m_mthSetSeriesIDToUI(clsMS_StockPlan_Detail_VO[] p_objDetailArr)
        {
            if (m_objViewer.m_dtbMedicineInfo != null && m_objViewer.m_dtbMedicineInfo.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < m_objViewer.m_dtbMedicineInfo.Rows.Count; iRow++)
                {
                    if (iRow < p_objDetailArr.Length)
                    {
                        m_objViewer.m_dtbMedicineInfo.Rows[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        m_objViewer.m_dtbMedicineInfo.Rows[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                        m_objViewer.m_dtbMedicineInfo.Rows[iRow]["STATUS"] = p_objDetailArr[iRow].m_lngSTATUS;
                    }
                }
            }
        }

        /// <summary>
        /// 获取主表VO
        /// </summary>
        /// <returns></returns>
        private clsMS_StockPlan_VO m_objGetMainISVO()
        {
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsMS_StockPlan_VO();
                m_objCurrentMain.m_datNEWORDER_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objCurrentMain.m_lngSTATE_INT = 1;
            }
            m_objCurrentMain.m_lngSERIESID_INT = m_objViewer.m_lngMainSEQ;
            m_objCurrentMain.m_strSTOCKPLANID_VCHR = m_objViewer.m_txtBillNumber.Text;
            m_objCurrentMain.m_strVENDORID_CHR = m_objViewer.m_txtProviderName.Tag.ToString();
            m_objCurrentMain.m_strVENDORNAME_VCHR = m_objViewer.m_txtProviderName.Text;
            m_objCurrentMain.m_datSTOCKPLAN_DAT = Convert.ToDateTime(m_objViewer.m_dtpPlanDate.Text);
            m_objCurrentMain.m_datNEWORDER_DAT = Convert.ToDateTime(m_objViewer.m_dtpNewOrderDate.Text);
            m_objCurrentMain.m_strMAKERID_CHR = m_objViewer.m_txtMakeBillPerson.Tag.ToString();
            m_objCurrentMain.m_strVENDORID_CHR = m_objViewer.m_txtProviderName.Tag.ToString();
            m_objCurrentMain.m_strCOMMENT_VCHR = m_objViewer.m_txtRemark.Text;

            m_objCurrentMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;


            return m_objCurrentMain;
        }

        #region 获取子表内容
        /// <summary>
        ///  获取子表内容
        /// </summary>
        /// <param name="p_drDetail"></param>
        /// <param name="p_lngMainSEQ"></param>
        /// <returns></returns>
        private clsMS_StockPlan_Detail_VO[] m_objGetDetailArr(DataRow[] p_drDetail, long p_lngMainSEQ)
        {
            clsMS_StockPlan_Detail_VO[] objDetailArr = null;
            if (p_drDetail == null || p_drDetail.Length == 0)
            {
                return null;
            }

            objDetailArr = new clsMS_StockPlan_Detail_VO[p_drDetail.Length];
            DateTime datTemp;
            for (int iRow = 0; iRow < p_drDetail.Length; iRow++)
            {
                objDetailArr[iRow] = new clsMS_StockPlan_Detail_VO();
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = p_drDetail[iRow]["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCHR = p_drDetail[iRow]["MEDICINENAME_VCHR"].ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR = p_drDetail[iRow]["MEDSPEC_VCHR"].ToString();
                objDetailArr[iRow].m_strASSISTCODE_CHR = p_drDetail[iRow]["ASSISTCODE_CHR"].ToString();
                objDetailArr[iRow].m_strUNIT_VCHR = p_drDetail[iRow]["UNIT_VCHR"].ToString();
                objDetailArr[iRow].m_dblAMOUNT = Convert.ToDouble(p_drDetail[iRow]["AMOUNT"]);
                objDetailArr[iRow].m_strPRODUCTORID_CHR = p_drDetail[iRow]["PRODUCTORID_CHR"].ToString();
                objDetailArr[iRow].m_strREMARK_VCHR = p_drDetail[iRow]["REMARK_VCHR"].ToString();
                if (DateTime.TryParse(p_drDetail[iRow]["LASTINSTORAGEDATE_DAT"].ToString(), out datTemp))
                    objDetailArr[iRow].m_datLASTINSTORAGEDATE_DAT = Convert.ToDateTime(p_drDetail[iRow]["LASTINSTORAGEDATE_DAT"]);
                objDetailArr[iRow].m_dblCALLPRICE_INT = Convert.ToDouble(p_drDetail[iRow]["CALLPRICE_INT"]);
                objDetailArr[iRow].m_dblSTOCKSUM = objDetailArr[iRow].m_dblCALLPRICE_INT * objDetailArr[iRow].m_dblAMOUNT;
                objDetailArr[iRow].m_strVENDORID_CHR = p_drDetail[iRow]["VENDORID_CHR"].ToString();
                objDetailArr[iRow].m_strVENDORNAME_VCHR = p_drDetail[iRow]["vendorname"].ToString();
                objDetailArr[iRow].m_lngSTATUS = 1;
            }
            return objDetailArr;
        }
        #endregion


        #endregion

        #region 插入新的一行药品采购信息
        /// <summary>
        /// 插入新的一行药品采购信息
        /// </summary>
        internal void m_mthInsertNewMedicineData()
        {
            if (m_objViewer.m_dtbMedicineInfo == null)
            {
                return;
            }

            DataRow drNew = m_objViewer.m_dtbMedicineInfo.NewRow();
            m_objViewer.m_dtbMedicineInfo.Rows.Add(drNew);

            m_objViewer.m_dgvMedicineDetail.Focus();
            m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail[1, m_objViewer.m_dgvMedicineDetail.RowCount - 1];
            string strStorageName;
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStorageName);
            m_objViewer.Text = "药品采购(" + strStorageName + ")";
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// <param name="p_dtbMedicint">字典内容</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable p_dtbMedicint)
        {
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvMedicineDetail.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvMedicineDetail.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                //m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineDetail.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineDetail.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineDetail.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineDetail.Location.Y - m_ctlQueryMedicint.Size.Height);
            }
            m_ctlQueryMedicint.m_blnExtendForStock = true;
            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        //private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        //{
        //    long lngReturn = 1;
        //    return lngReturn;
        //}

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineDetail.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvMedicineDetail.CurrentCell.ColumnIndex;
            double dblAmount = 0d;

            if (m_objViewer.m_dtbMedicineInfo != null)
            {
                DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvMedicineDetail.CurrentCell.OwningRow.DataBoundItem)).Row;
                for (int i1 = 0; i1 < m_objViewer.m_dgvMedicineDetail.Rows.Count; i1++)
                {
                    if (m_objViewer.m_dgvMedicineDetail["m_dgvtxtMedicineCode", i1].Value.ToString() != "" && i1 != m_objViewer.m_dgvMedicineDetail.CurrentCell.RowIndex
                        && m_objViewer.m_dgvMedicineDetail["m_dgvtxtMedicineCode", i1].Value.ToString() == MS_VO.m_strMedicineID)
                    {
                        MessageBox.Show("该药品已选择！", "采购明细", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail.Rows[m_objViewer.m_dgvMedicineDetail.CurrentCell.RowIndex].Cells["ASSISTCODE_CHR"];
                        m_objViewer.m_dgvMedicineDetail.Refresh();
                        m_objViewer.m_dgvMedicineDetail.Focus();
                        m_objViewer.m_dgvMedicineDetail.CurrentCell.Selected = true;
                        return;
                    }
                }

                drCurrent["assistcode_chr"] = MS_VO.m_strMedicineCode;
                drCurrent["MEDICINENAME_VCHR"] = MS_VO.m_strMedicineName;
                drCurrent["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
                drCurrent["UNIT_VCHR"] = MS_VO.m_strMedicineUnit;
                drCurrent["MEDICINEID_CHR"] = MS_VO.m_strMedicineID;
                //drCurrent["packqty_dec"] = MS_VO.m_strPackqty_dec;
                drCurrent["PRODUCTORID_CHR"] = MS_VO.m_strManufacturer;

                drCurrent["vendorid_chr"] = MS_VO.m_strVENDORID_CHR;
                drCurrent["vendorname"] = MS_VO.m_strVENDORNAME_VCHR;
                drCurrent["callprice_int"] = MS_VO.m_dblCALLPRICE_INT;
                drCurrent["LASTINSTORAGEDATE_DAT"] = MS_VO.m_datLASTINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");

                m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail.Rows[intRowIndex].Cells["m_dgvtxtAmount"];
                //设置数量为：上限 – 库存数量
                ((clsDcl_StockPlan_Detail)m_objDomain).m_mthGetAmount(m_objViewer.m_strStorageID, MS_VO.m_strMedicineID, out dblAmount);
                m_objViewer.m_dgvMedicineDetail.Rows[intRowIndex].Cells["m_dgvtxtAmount"].Value = dblAmount;

                drCurrent["stocksum"] = MS_VO.m_dblCALLPRICE_INT * dblAmount;
            }

            m_objViewer.m_dgvMedicineDetail.Refresh();
            m_objViewer.m_dgvMedicineDetail.Focus();
            m_objViewer.m_dgvMedicineDetail.CurrentCell.Selected = true;
        }
        #endregion

        #region 插入新的一行请领药品信息
        /// <summary>
        /// 插入新的一行请领药品信息
        /// </summary>
        internal void m_mthInsertNewMedicineInfo()
        {
            if (m_objViewer.m_dtbMedicineInfo == null)
            {
                return;
            }
            if (this.m_objViewer.m_dtbMedicineInfo.Rows.Count > 0)
            {
                DataRow drLast = this.m_objViewer.m_dtbMedicineInfo.Rows[this.m_objViewer.m_dtbMedicineInfo.Rows.Count - 1];
                if (drLast["MEDICINEID_CHR"] == DBNull.Value)
                {
                    this.m_objViewer.m_dgvMedicineDetail.Focus();
                    this.m_objViewer.m_dgvMedicineDetail.CurrentCell = this.m_objViewer.m_dgvMedicineDetail.Rows[this.m_objViewer.m_dtbMedicineInfo.Rows.Count - 1].Cells[1];
                    this.m_objViewer.m_dgvMedicineDetail.CurrentCell.Selected = true;

                }
                else
                {
                    DataRow drNew = m_objViewer.m_dtbMedicineInfo.NewRow();
                    m_objViewer.m_dtbMedicineInfo.Rows.Add(drNew);
                    m_objViewer.m_dgvMedicineDetail.Focus();
                    m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail[1, m_objViewer.m_dgvMedicineDetail.RowCount - 1];
                    this.m_objViewer.m_dgvMedicineDetail.CurrentCell.Selected = true;
                }
            }
            else
            {
                DataRow drNew = m_objViewer.m_dtbMedicineInfo.NewRow();
                m_objViewer.m_dtbMedicineInfo.Rows.Add(drNew);
                m_objViewer.m_dgvMedicineDetail.Focus();
                m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail[1, m_objViewer.m_dgvMedicineDetail.RowCount - 1];
                this.m_objViewer.m_dgvMedicineDetail.CurrentCell.Selected = true;
            }

        }
        #endregion

        #region 删除请领明细
        /// <summary>
        /// 删除请领明细
        /// </summary>
        /// <returns></returns>
        internal void m_mthDeleteStockPlanDetail()
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_lngSTATE_INT == 2)
            {
                MessageBox.Show("该药品采购计划已经审核，不能删除", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (m_objViewer.m_dgvMedicineDetail.SelectedCells.Count == 0)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineDetail.SelectedCells[0].RowIndex;
            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvMedicineDetail.CurrentCell.OwningRow.DataBoundItem).Row;

            long lngSEQ = 0;
            if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngSEQ))
            {

                long lngRes = m_objDomain.m_lngDelMedDetail(lngSEQ);
                if (lngRes > 0)
                {
                    if (m_objCurrentSubArr != null)
                    {
                        List<clsMS_StockPlan_Detail_VO> lstDetail = new List<clsMS_StockPlan_Detail_VO>();
                        for (int iDe = 0; iDe < m_objCurrentSubArr.Length; iDe++)
                        {
                            if (m_objCurrentSubArr[iDe].m_lngSERIESID_INT != lngSEQ)
                            {
                                lstDetail.Add(m_objCurrentSubArr[iDe]);
                            }
                        }
                        m_objCurrentSubArr = null;
                        if (lstDetail.Count > 0)
                        {
                            m_objCurrentSubArr = lstDetail.ToArray();
                        }
                    }

                    m_objViewer.m_dtbMedicineInfo.Rows.Remove(drCurrent);
                    MessageBox.Show("删除成功", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                m_objViewer.m_dtbMedicineInfo.Rows.Remove(drCurrent);
            }
        }
        #endregion

        #region 打印预览窗体
        /// <summary>
        /// 打印预览窗体
        /// </summary>
        /// <returns></returns>
        internal void m_mthPrint()
        {
            if (this.m_objViewer.m_dtbMedicineInfo.Rows.Count < 1)
            {
                MessageBox.Show("抱歉，没有数据可预览！", "采购计划", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            frmStockPlan_DetailReport frmReport = new frmStockPlan_DetailReport();
            //long m_lngSid = Convert.ToInt64(this.m_objViewer.m_dtbMedicineInfo.Rows[0]["seriesid2_int"].ToString());
            
            long m_lngSid = m_objViewer.m_lngMainSEQ;
            int m_intState = Convert.ToInt32(this.m_objViewer.m_dtbMedicineInfo.Rows[0]["STATUS"].ToString());
            int m_intType = 0;//默认格式
            ((clsDcl_StockPlan_Detail)m_objDomain).m_lngGetPrintType(out m_intType);
            if (m_intType == 0)
            {
                ((clsDcl_StockPlan_Detail)m_objDomain).m_lngGetStockPlanForPrint(m_lngSid, m_intState, out frmReport.p_dtbVal);
            }
            else if (m_intType == 1)
            {
                frmReport.datWindow.DataWindowObject = "ms_stockplan_ts";
                ((clsDcl_StockPlan_Detail)m_objDomain).m_lngGetStockPlanForPrintTaiShan(m_lngSid, m_intState, out frmReport.p_dtbVal);
            }
                
            //ReportVal Drv = new ReportVal();
            //报表头信息
            //Drv.p_dtbVal = p_dtbVal;
            //Drv.StockPlanID = this.m_objViewer.m_txtBillNumber.Text;
            //Drv.StockPlanDate = this.m_objViewer.m_dtpPlanDate.Text;
            //string m_strStoragename = "";
            //((clsDcl_StockPlan_Detail)m_objDomain).m_lngGetStoreRoomName(this.m_objViewer.m_strStorageID, out m_strStoragename);
            //Drv.StorageName = m_strStoragename;
            //frmReport.Drv = Drv;
            frmReport.ShowDialog();
        }
        #endregion

        internal void m_mthClear()
        {
            m_objViewer.m_txtBillNumber.Clear();
            m_objViewer.m_txtMakeBillPerson.Text = m_objViewer.LoginInfo.m_strEmpName;
            m_objViewer.m_txtMakeBillPerson.Tag = m_objViewer.LoginInfo.m_strEmpID;
            m_objViewer.m_txtProviderName.Clear();
            m_objViewer.m_txtProviderName.Tag = null;
            m_objViewer.m_txtRemark.Clear();
            m_objViewer.m_lngMainSEQ = 0;
            m_objViewer.m_dtpPlanDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_objViewer.m_dtpNewOrderDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
        }

        /// <summary>
        /// 是否已审核
        /// </summary>
        /// <param name="p_strBillNo">单号</param>
        /// <param name="p_intStatus">单据状态2为审核1为新增</param>
        internal void m_mthGetCommitStatus(string p_strBillNo, out int p_intStatus)
        {
            ((clsDcl_StockPlan_Detail)this.m_objDomain).m_mthGetCommitStatus(p_strBillNo, out p_intStatus);
        }

        /// <summary>
        /// 导出到Excel
        /// </summary>
        internal void m_mthExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                //添加列标题
                for (int iOr = 0; iOr < m_objViewer.m_dgvMedicineDetail.ColumnCount; iOr++)
                {
                    if (iOr > 0)
                    {
                        str += "\t";
                    }
                    str += m_objViewer.m_dgvMedicineDetail.Columns[iOr].HeaderText;
                }
                sw.WriteLine(str);
                //添加行文本

                StringBuilder objStrBuilder = null;
                for (int iOr = 0; iOr < m_objViewer.m_dgvMedicineDetail.Rows.Count; iOr++)
                {
                    objStrBuilder = new StringBuilder();
                    for (int jOr = 0; jOr < m_objViewer.m_dgvMedicineDetail.Columns.Count; jOr++)
                    {
                        if (jOr > 0)
                        {
                            objStrBuilder.Append("\t");
                        }
                        objStrBuilder.Append(m_objViewer.m_dgvMedicineDetail.Rows[iOr].Cells[jOr].Value.ToString());
                    }
                    sw.WriteLine(objStrBuilder);

                }
                MessageBox.Show("导出成功！", "采购明细", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }

        /// <summary>
        /// 判断是否超过上限或低于下限
        /// </summary>
        /// <param name="p_intRowIndex"></param>
        internal void m_mthComputeAmount(int p_intRowIndex)
        {
            if (m_blnAuto) return;
            try
            {
                int m_intInput = 0;
                if (Int32.TryParse(m_objViewer.m_dgvMedicineDetail[7, p_intRowIndex].Value.ToString(), out m_intInput) == false)
                {
                    m_objViewer.m_dgvMedicineDetail[7, p_intRowIndex].Value = 0;
                }

                double intRealAmount, intTopAmount, intNeapAmount;
                ((clsDcl_StockPlan_Detail)m_objDomain).m_mthGetAmount(m_objViewer.m_strStorageID, m_objViewer.m_dgvMedicineDetail[2, p_intRowIndex].Value.ToString(), out intRealAmount, out intTopAmount, out intNeapAmount);
                if (intTopAmount > 0 && m_intInput > 0)
                {
                    if (m_intInput > (intTopAmount - intRealAmount))
                    {
                        if (DialogResult.No == MessageBox.Show("采购数量与库存之和将高于上限,是否继续按此数量对该药品进行采购?", "注意...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            Application.DoEvents();
                            m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail[7, p_intRowIndex];
                        }
                        else
                        {
                            m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail[8, p_intRowIndex];
                        }
                        m_objViewer.m_dgvMedicineDetail.CurrentCell.Selected = true;
                        m_objViewer.m_dgvMedicineDetail.Focus();//这一步仍有问题，不能锁定在此cell？（20080103 zheng)
                        return;
                    }
                    else if (m_intInput < (intNeapAmount - intRealAmount))
                    {
                        if (DialogResult.No == MessageBox.Show("采购数量与库存之和将低于下限,是否继续按此数量对该药品进行采购?", "注意...", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                        {
                            m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail[7, p_intRowIndex];
                        }
                        else
                        {
                            m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail[8, p_intRowIndex];
                        }
                        m_objViewer.m_dgvMedicineDetail.CurrentCell.Selected = true;
                        m_objViewer.m_dgvMedicineDetail.Focus();
                    }
                }
            }
            catch
            {
            }
            finally
            {
                m_objViewer.m_dgvMedicineDetail["stocksum", p_intRowIndex].Value = Convert.ToDouble(m_objViewer.m_dgvMedicineDetail["m_dgvtxtAmount", p_intRowIndex].Value) * Convert.ToDouble(m_objViewer.m_dgvMedicineDetail["callprice_int", p_intRowIndex].Value);
            }
        }

        private bool m_blnAuto = false;
        /// <summary>
        /// 自动计算药品采购数量
        /// </summary>
        internal void m_mthAutoComputeAmount()
        {
            try
            {
                m_blnAuto = true;
                double intRealAmount, intTopAmount, intNeapAmount;
                for (int i1 = 0; i1 < m_objViewer.m_dgvMedicineDetail.Rows.Count; i1++)
                {
                    ((clsDcl_StockPlan_Detail)m_objDomain).m_mthGetAmount(m_objViewer.m_strStorageID, m_objViewer.m_dgvMedicineDetail[2, i1].Value.ToString(), out intRealAmount, out intTopAmount, out intNeapAmount);
                    if (intTopAmount > 0 && intTopAmount > intRealAmount)
                    {
                        m_objViewer.m_dgvMedicineDetail[7, i1].Value = intTopAmount - intRealAmount;
                    }
                }
            }
            catch
            {
            }
            finally
            {
                m_blnAuto = false;
            }
        }

        internal void m_mthPrintDirect()
        {
            DataTable m_dtbPrint = new DataTable();
            long m_lngSid = m_objViewer.m_lngMainSEQ;
            int m_intState = Convert.ToInt32(this.m_objViewer.m_dtbMedicineInfo.Rows[0]["STATUS"].ToString());
            Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();
            dsData.LibraryList = clsMedicineStoreFormFactory.PBLPath;
            int m_intType = 0;//默认格式
            ((clsDcl_StockPlan_Detail)m_objDomain).m_lngGetPrintType(out m_intType);
            if (m_intType == 0)
            {
                ((clsDcl_StockPlan_Detail)m_objDomain).m_lngGetStockPlanForPrint(m_lngSid, m_intState, out m_dtbPrint);
                dsData.DataWindowObject = "ms_stockplan";
            }
            else if (m_intType == 1)
            {
                ((clsDcl_StockPlan_Detail)m_objDomain).m_lngGetStockPlanForPrintTaiShan(m_lngSid, m_intState, out m_dtbPrint);
                dsData.DataWindowObject = "ms_stockplan_ts";
            }           
            dsData.Retrieve(m_dtbPrint);
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog_DataStore(dsData, true);
        }

        internal void m_mthAutoGenerate(clsMS_StockPlan_Detail_VO[] p_objDetailArr)
        {
            #region 子表
            try
            {
                m_objViewer.m_dtbMedicineInfo = m_dtbInitTable();
                m_objViewer.m_dtbMedicineInfo.BeginLoadData();
                DataRow[] drSub = new DataRow[p_objDetailArr.Length];
                for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                {
                    drSub[iRow] = m_objViewer.m_dtbMedicineInfo.NewRow();
                    drSub[iRow]["MEDICINEID_CHR"] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    drSub[iRow]["MEDICINENAME_VCHR"] = p_objDetailArr[iRow].m_strMEDICINENAME_VCHR;
                    drSub[iRow]["MEDSPEC_VCHR"] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                    drSub[iRow]["AMOUNT"] = p_objDetailArr[iRow].m_dblAMOUNT;
                    drSub[iRow]["PRODUCTORID_CHR"] = p_objDetailArr[iRow].m_strPRODUCTORID_CHR;
                    drSub[iRow]["UNIT_VCHR"] = p_objDetailArr[iRow].m_strUNIT_VCHR;
                    drSub[iRow]["SortNum"] = iRow + 1;
                    drSub[iRow]["ASSISTCODE_CHR"] = p_objDetailArr[iRow].m_strASSISTCODE_CHR;
                    drSub[iRow]["REMARK_VCHR"] = p_objDetailArr[iRow].m_strREMARK_VCHR;
                    drSub[iRow]["VENDORID_CHR"] = p_objDetailArr[iRow].m_strVENDORID_CHR;
                    drSub[iRow]["vendorname"] = p_objDetailArr[iRow].m_strVENDORNAME_VCHR;
                    drSub[iRow]["LASTINSTORAGEDATE_DAT"] = p_objDetailArr[iRow].m_datLASTINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
                    drSub[iRow]["CALLPRICE_INT"] = p_objDetailArr[iRow].m_dblCALLPRICE_INT;
                    drSub[iRow]["stocksum"] = p_objDetailArr[iRow].m_dblSTOCKSUM;
                    m_objViewer.m_dtbMedicineInfo.LoadDataRow(drSub[iRow].ItemArray, true);
                }
            }
            catch (Exception Ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(Ex);
            }
            finally
            {
                m_objViewer.m_dtbMedicineInfo.EndLoadData();
            }
            m_objViewer.m_dgvMedicineDetail.DataSource = m_objViewer.m_dtbMedicineInfo;
            m_objViewer.m_dtbMedicineInfo.AcceptChanges();
            #endregion;
        }
    }
}
