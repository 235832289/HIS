using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 报废出库
    /// </summary>
    public class clsCtl_RejectOutStorage : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_RejectOutStorage m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmRejectOutStorage m_objViewer;
        /// <summary>
        /// 查询药品字典控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 当前药品出库主表信息
        /// </summary>
        private clsMS_OutStorage_VO m_objCurrentMain = null;
        /// <summary>
        /// 当前药品出库子表信息
        /// </summary>
        private clsMS_OutStorageDetail_VO[] m_objCurrentSubArr = null;
        #endregion

        #region 构造函数        /// <summary>
        /// 报废出库
        /// </summary>
        public clsCtl_RejectOutStorage()
        {
            m_objDomain = new clsDcl_RejectOutStorage();
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
            m_objViewer = (frmRejectOutStorage)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化子表作为DataGridView数据源的DataTable
        /// <summary>
        /// 初始化子表作为DataGridView数据源的DataTable
        /// </summary>
        /// <param name="p_dtbMedicineTalbe"></param>
        internal void m_mthInitMedicineTalbe(ref DataTable p_dtbMedicineTalbe)
        {
            p_dtbMedicineTalbe = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("SERIESID_INT"), new DataColumn("SERIESID2_INT"), new DataColumn("MEDICINEID_CHR"), new DataColumn("MEDICINENAME_VCHr"),
                new DataColumn("MEDSPEC_VCHR"),new DataColumn("OPUNIT_CHR"),new DataColumn("NETAMOUNT_INT",typeof(double)),new DataColumn("LOTNO_VCHR"),new DataColumn("INSTORAGEID_VCHR"),new DataColumn("CALLPRICE_INT",typeof(double)),
                new DataColumn("WHOLESALEPRICE_INT",typeof(double)),new DataColumn("RETAILPRICE_INT",typeof(double)),new DataColumn("VENDORID_CHR"),new DataColumn("vendorname_vchr"),new DataColumn("productorid_chr"),
                new DataColumn("inmoney",typeof(double)),new DataColumn("retailmoney",typeof(double)),new DataColumn("instoragedate_dat"),new DataColumn("validperiod_dat"),new DataColumn("realgross_int"),new DataColumn("assistcode_chr"),
                new DataColumn("availagross_int"),new DataColumn("storageunit"),new DataColumn("askamount"),new DataColumn("originality_Amount"),new DataColumn("REJECTREASON"),new DataColumn("medicinetypeid_chr"),new DataColumn("packqty_dec",typeof(double))};
            p_dtbMedicineTalbe.Columns.AddRange(dcColumns);

            p_dtbMedicineTalbe.Columns["inmoney"].Expression = "callprice_int * netamount_int";
            p_dtbMedicineTalbe.Columns["retailmoney"].Expression = "retailprice_int * netamount_int";
        }
        #endregion

        #region 初始化药品字典最小元素集信息
        /// <summary>
        /// 初始化药品字典最小元素集信息
        /// </summary>
        /// <param name="p_dtbMedicineInfo"></param>
        internal void m_mthInitMedicineInfo(ref DataTable p_dtbMedicineInfo)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetBaseMedicineNotZero(string.Empty, m_objViewer.m_strStorageID, out p_dtbMedicineInfo);
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

                m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineDetail.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineDetail.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineDetail.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineDetail.Location.Y - m_ctlQueryMedicint.Size.Height);
            }

            //m_ctlQueryMedicint.m_blnNotShowZero = true;
            m_ctlQueryMedicint.m_strStorageID = m_objViewer.m_strStorageID;
            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        {
            long lngReturn = 1;

            double dblGrossTemp = 0d;
            clsDcl_Storage objSTDomain = new clsDcl_Storage();
            long lngRes = objSTDomain.m_lngGetAvailaGross(m_objViewer.m_strStorageID, p_strMedicineID, out dblGrossTemp);
            if (dblGrossTemp <= 0)
            {
                MessageBox.Show("此药品已无可用库存", "药库出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_ctlQueryMedicint.Visible = true;
                m_ctlQueryMedicint.Focus();
                lngReturn = -1;
            }
            return lngReturn;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineDetail.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvMedicineDetail.CurrentCell.ColumnIndex;

            DataRow[] drOld = m_objViewer.m_dtbOutMedicine.Select("MEDICINEID_CHR = '" + MS_VO.m_strMedicineID + "'");

            if (m_objViewer.m_dtbOutMedicine != null)
            {
                if (drOld != null && drOld.Length > 0)
                {
                    MessageBox.Show("本出库单已选择此药", "药库出库", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail.Rows[intRowIndex].Cells["m_dgvtxtMedicineCode"];
                }
                else
                {
                    m_lngShowMedicineSelect(MS_VO.m_strMedicineID, 0);
                }
            }

        }
        #endregion

        #region 显示药品选择窗体
        /// <summary>
        /// 显示药品选择窗体，选择需报废的药品批次
        /// </summary>
        /// <param name="p_strMedicineID">药品ID</param>
        /// <param name="p_dblAmount">报废数量，如果小于零表示新添药品</param>
        internal void m_lngShowMedicineSelect(string p_strMedicineID, double p_dblAmount)
        {
            double dblAmount = p_dblAmount;
            DataRow[] drOld = m_objViewer.m_dtbOutMedicine.Select("MEDICINEID_CHR = '" + p_strMedicineID + "'");

            clsMS_StorageDetail[] objDetail = null;
            clsDcl_Storage objSTDomain = new clsDcl_Storage();

            Hashtable hstNetAmount = new Hashtable();
            bool blnHasMain = false;//是否已有旧记录，即当前是否处于修改状态
            if (m_objCurrentMain != null)
            {
                blnHasMain = true;
            }

            long lngRes = 0;
            lngRes = objSTDomain.m_lngGetStorageMedicineDetail(p_strMedicineID, m_objViewer.m_strStorageID, out objDetail);
            objSTDomain = null;

            if (objDetail != null && objDetail.Length > 0)
            {
                if (blnHasMain && p_dblAmount >= 0)
                {
                    clsDcl_MedicineOut objMODomain = new clsDcl_MedicineOut();
                    lngRes = objMODomain.m_lngGetNetAmount(m_objCurrentMain.m_lngSERIESID_INT, p_strMedicineID, out hstNetAmount);
                    objMODomain = null;

                    #region 处理界面已设定的数量
                    if (drOld != null && drOld.Length > 0)
                    {
                        dblAmount = 0d;
                        double dblTemp = 0d;
                        for (int iOld = 0; iOld < drOld.Length; iOld++)
                        {
                            if (double.TryParse(drOld[iOld]["NETAMOUNT_INT"].ToString(), out dblTemp))
                            {
                                dblAmount += dblTemp;
                                if (blnHasMain && hstNetAmount.Contains(drOld[iOld]["lotno_vchr"].ToString()))
                                {
                                    double dblTempAmount = 0d;
                                    if (double.TryParse(hstNetAmount[drOld[iOld]["lotno_vchr"].ToString()].ToString(), out dblTempAmount))
                                    {
                                        for (int iSD = 0; iSD < objDetail.Length; iSD++)
                                        {
                                            if (drOld[iOld]["lotno_vchr"].ToString() == objDetail[iSD].m_strLOTNO_VCHR)
                                            {
                                                objDetail[iSD].m_dblAVAILAGROSS_INT += dblTempAmount;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                }

                frmQueryMedicineInfo frmQMI = new frmQueryMedicineInfo(dblAmount);
                Hashtable hstTemp = new Hashtable();
                frmQMI.m_mthSetMedicineVO(objDetail, hstTemp);
                frmQMI.m_mthSetAmountName("报废数量");
                frmQMI.ShowDialog();

                if (frmQMI.DialogResult == DialogResult.OK)
                {
                    if (drOld != null && drOld.Length > 0 && p_dblAmount >= 0)
                    {
                        foreach (DataRow drC in drOld)
                        {
                            m_objViewer.m_dtbOutMedicine.Rows.Remove(drC);
                        }
                    }
                    clsMS_StorageMedicineShow[] objValue = frmQMI.m_ObjOutMedicinArr;
                    m_mthSetOutMedicineVOToTable(objValue);
                }
            }
        }
        #endregion

        #region 设置出库药品信息至界面
        /// <summary>
        /// 设置出库药品信息至界面
        /// </summary>
        /// <param name="p_objValue"></param>
        internal void m_mthSetOutMedicineVOToTable(clsMS_StorageMedicineShow[] p_objValue)
        {
            if (p_objValue == null || p_objValue.Length == 0)
            {
                return;
            }

            int intRowsCount = m_objViewer.m_dtbOutMedicine.Rows.Count;
            //去除最后一行空行
            if (intRowsCount > 0 && m_objViewer.m_dtbOutMedicine.Rows[intRowsCount - 1]["availagross_int"] == DBNull.Value)
            {
                m_objViewer.m_dtbOutMedicine.Rows.RemoveAt(intRowsCount - 1);
            }

            m_objViewer.m_dtbOutMedicine.BeginLoadData();
            for (int iRow = 0; iRow < p_objValue.Length; iRow++)
            {
                DataRow drNew = m_objViewer.m_dtbOutMedicine.NewRow();
                m_mthAddDataToRow(drNew, p_objValue[iRow]);
                m_objViewer.m_dtbOutMedicine.LoadDataRow(drNew.ItemArray, true);
            }
            m_objViewer.m_dtbOutMedicine.EndLoadData();

            intRowsCount = m_objViewer.m_dtbOutMedicine.Rows.Count;
            int intFirstRowIndex = intRowsCount - p_objValue.Length;
            if (intFirstRowIndex >= 0 && intRowsCount > 0)
            {
                m_objViewer.m_dgvMedicineDetail.Focus();
                m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail.Rows[intFirstRowIndex].Cells["m_dgvtxtRejectReason"];
                m_objViewer.m_dgvMedicineDetail.CurrentCell.Selected = true;
            }
        }

        /// <summary>
        /// 添加数据至指定行
        /// </summary>
        /// <param name="p_drRow"></param>
        /// <param name="p_objValue"></param>
        private void m_mthAddDataToRow(DataRow p_drRow, clsMS_StorageMedicineShow p_objValue)
        {
            if (p_drRow == null || p_objValue == null)
            {
                return;
            }

            p_drRow["MEDICINEID_CHR"] = p_objValue.m_strMEDICINEID_CHR;
            p_drRow["MEDICINENAME_VCHR"] = p_objValue.m_strMEDICINENAME_VCHR;
            p_drRow["MEDSPEC_VCHR"] = p_objValue.m_strMEDSPEC_VCHR;
            p_drRow["storageunit"] = p_objValue.m_strOPUNIT_VCHR;
            p_drRow["OPUNIT_CHR"] = p_objValue.m_strOPUNIT_VCHR;
            p_drRow["NETAMOUNT_INT"] = p_objValue.m_dblOutAmount.ToString("0.00");
            p_drRow["LOTNO_VCHR"] = p_objValue.m_strLOTNO_VCHR;
            p_drRow["INSTORAGEID_VCHR"] = p_objValue.m_strINSTORAGEID_VCHR;
            p_drRow["CALLPRICE_INT"] = p_objValue.m_dcmCALLPRICE_INT.ToString("0.0000");
            p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmWHOLESALEPRICE_INT.ToString("0.0000");
            p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmRETAILPRICE_INT.ToString("0.0000");
            p_drRow["VENDORID_CHR"] = p_objValue.m_strVENDORID_CHR;
            p_drRow["vendorname_vchr"] = p_objValue.m_strVENDORName;
            p_drRow["productorid_chr"] = p_objValue.m_strPRODUCTORID_CHR;
            p_drRow["instoragedate_dat"] = p_objValue.m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
            p_drRow["validperiod_dat"] = p_objValue.m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd");
            p_drRow["realgross_int"] = p_objValue.m_dblREALGROSS_INT.ToString("0.00");
            p_drRow["assistcode_chr"] = p_objValue.m_strMEDICINECode;
            p_drRow["availagross_int"] = p_objValue.m_dblAVAILAGROSS_INT.ToString("0.00");
            p_drRow["inmoney"] = (p_objValue.m_dblOutAmount * (double)p_objValue.m_dcmCALLPRICE_INT).ToString("0.0000");
            p_drRow["retailmoney"] = (p_objValue.m_dblOutAmount * (double)p_objValue.m_dcmRETAILPRICE_INT).ToString("0.0000");
            if (m_objViewer.m_objReasons != null && m_objViewer.m_objReasons.Length > 0)
            {
                p_drRow["REJECTREASON"] = m_objViewer.m_objReasons[0].m_strREASONDESC_VCHR;
            }
            p_drRow["medicinetypeid_chr"] = p_objValue.m_strMedicineTypeID_chr;
            p_drRow["packqty_dec"] = p_objValue.m_dblPackQty;
        }
        #endregion

        #region 插入新的一行药品出库信息
        /// <summary>
        /// 插入新的一行药品出库信息
        /// </summary>
        internal void m_mthInsertNewMedicineDate()
        {
            if (m_objViewer.m_dtbOutMedicine == null)
            {
                return;
            }

            DataRow drNew = m_objViewer.m_dtbOutMedicine.NewRow();
            m_objViewer.m_dtbOutMedicine.Rows.Add(drNew);

            m_objViewer.m_dgvMedicineDetail.Focus();
            m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail[1, m_objViewer.m_dgvMedicineDetail.RowCount - 1];
        }
        #endregion

        #region 获取审核流程设置
        /// <summary>
        /// 获取审核流程设置
        /// </summary>
        /// <param name="p_intCommitFolw">审核流程设置</param>
        /// <returns></returns>
        internal void m_mthGetCommitFlow(out int p_intCommitFolw)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetCommitFlow(out p_intCommitFolw);
        }
        #endregion

        #region 计算界面金额
        /// <summary>
        /// 计算界面金额
        /// </summary>
        internal void m_mthCountMoney()
        {
            m_objViewer.m_lblBugMoney.Text = string.Empty;
            m_objViewer.m_lblSaleMoney.Text = string.Empty;

            if (m_objViewer.m_dtbOutMedicine != null)
            {
                int intRowsCount = m_objViewer.m_dtbOutMedicine.Rows.Count;
                double dblBuyMoney = 0d;
                double dblSaleMoney = 0d;

                double dblAmountTemp = 0d;
                double dblPriceTemp = 0d;
                DataRow drTemp = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = m_objViewer.m_dtbOutMedicine.Rows[iRow];
                    if (drTemp.RowState == DataRowState.Deleted || drTemp.RowState == DataRowState.Detached)
                    {
                        continue;
                    }
                    if (double.TryParse(drTemp["NETAMOUNT_INT"].ToString(), out dblAmountTemp))
                    {
                        if (double.TryParse(drTemp["CALLPRICE_INT"].ToString(), out dblPriceTemp))
                        {
                            dblBuyMoney += dblAmountTemp * dblPriceTemp;
                        }
                        if (double.TryParse(drTemp["RETAILPRICE_INT"].ToString(), out dblPriceTemp))
                        {
                            dblSaleMoney += dblAmountTemp * dblPriceTemp;
                        }
                    }
                }
                m_objViewer.m_lblBugMoney.Text = dblBuyMoney.ToString("0.0000");
                m_objViewer.m_lblSaleMoney.Text = dblSaleMoney.ToString("0.0000");
            }
        }
        #endregion

        #region 获取所有报废原因
        /// <summary>
        /// 获取所有报废原因
        /// </summary>
        /// <param name="p_objReasons">报废原因</param>
        /// <returns></returns>
        internal void m_mthGetAllRejectReason(out clsMS_RejectReason[] p_objReasons)
        {
            long lngRes = m_objDomain.m_lngGetAllRejectReason(out p_objReasons);
        } 
        #endregion

        #region 添加报废原因至DataGridViewComboBox
        /// <summary>
        /// 添加报废原因至DataGridViewComboBox
        /// </summary>
        /// <param name="p_cboControl">ComboBox</param>
        internal void m_mthAddReasonItems(DataGridViewComboBoxEditingControl p_cboControl)
        {
            if (m_objViewer.m_objReasons == null || m_objViewer.m_objReasons.Length == 0 
                || p_cboControl == null || p_cboControl.Items.Count > 0)
            {
                return;
            }

            for (int iItem = 0; iItem < m_objViewer.m_objReasons.Length; iItem++)
            {
                p_cboControl.Items.Add(m_objViewer.m_objReasons[iItem].m_strREASONDESC_VCHR);
            }
        }

        /// <summary>
        /// 添加报废原因至DataGridViewComboBoxColumn
        /// </summary>
        /// <param name="p_clmReason">DataGridViewComboBoxColumn</param>
        internal void m_mthAddReasonItems(DataGridViewComboBoxColumn p_clmReason)
        {
            if (m_objViewer.m_objReasons == null || m_objViewer.m_objReasons.Length == 0
                || p_clmReason == null || p_clmReason.Items.Count > 0)
            {
                return;
            }

            for (int iItem = 0; iItem < m_objViewer.m_objReasons.Length; iItem++)
            {
                p_clmReason.Items.Add(m_objViewer.m_objReasons[iItem].m_strREASONDESC_VCHR);
            }
        }
        #endregion

        #region 获取是否审核即入帐
        /// <summary>
        /// 获取是否审核即入帐
        /// </summary>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        internal void m_mthGetIsImmAccount(out bool p_blnIsImmAccount)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetIsImmAccount(out p_blnIsImmAccount);
            objPDDomain = null;
        }
        #endregion

        #region 保存药品出库信息
        /// <summary>
        /// 保存药品出库信息
        /// </summary>
        /// <returns></returns>
        internal long m_lngSaveOutStorageInfo()
        {
            #region 有效性检查
            //20090721:保存、删除、审核单据时，均判断是否新制状态
            if (m_objViewer.m_txtIncomeBillNumber.Text.Length > 0)
            {
                bool blnNewState = false;
                clsDcl_Purchase_Detail clsDcl = new clsDcl_Purchase_Detail();
                clsDcl.m_lngCheckBillState(2, m_objViewer.m_txtIncomeBillNumber.Text.Trim(), out blnNewState);
                if (!blnNewState)
                {
                    MessageBox.Show("该出库单不是新制状态，请关闭并刷新后重试", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -1;
                }
            }

            DateTime datOutTime;
            m_objDomain.m_mthGetAccountperiodTime(out datOutTime);
            if (Convert.ToDateTime(m_objViewer.m_dtpInComeDate.Tag) < datOutTime)
            {
                MessageBox.Show("报废日期不能小于上次帐务结转的结束日期。\r\n上次结转结束日期是：" + datOutTime.ToString("yyyy年MM月dd日"), "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_dtpInComeDate.Focus();
                return -1;
            }

            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS != 1)
            {
                if (m_objCurrentMain.m_intSTATUS == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品出库记录已入帐，不能修改", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品出库记录已审核，不能修改", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            if (m_objViewer.m_dtbOutMedicine == null || m_objViewer.m_dtbOutMedicine.Rows.Count == 0)
            {
                MessageBox.Show("请先选择出库药品", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (m_objViewer.m_dtbOutMedicine.Rows.Count == 1)//只有一行自动添加的空数据
            {
                if (m_objViewer.m_dtbOutMedicine.Rows[0]["availagross_int"] == DBNull.Value)
                {
                    MessageBox.Show("请先选择出库药品", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            double dblAmount = 0d;
            DataRow drTemp = null;
            for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
            {
                drTemp = m_objViewer.m_dtbOutMedicine.Rows[iRow];
                if (drTemp.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["availagross_int"] != DBNull.Value)
                {
                    if (!double.TryParse(drTemp["NETAMOUNT_INT"].ToString(), out dblAmount))
                    {
                        MessageBox.Show("报废数量必须为数字", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    else
                    {
                        if (dblAmount <= 0)
                        {
                            MessageBox.Show("报废数量必须为大于零数字", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        else
                        {
                            double dblOriAmount = 0d;
                            if (double.TryParse(drTemp["originality_Amount"].ToString(), out dblOriAmount))
                            {
                                if ((dblAmount - dblOriAmount) > Convert.ToDouble(drTemp["availagross_int"]))
                                {
                                    MessageBox.Show("出库数量必须小于可用库存", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return -1;
                                }
                            }
                            else if (dblAmount > Convert.ToDouble(drTemp["availagross_int"]))
                            {
                                MessageBox.Show("出库数量必须小于可用库存", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return -1;
                            }
                        }
                    }
                }
            }
            #endregion

            long lngRes = 0;
            clsDcl_MedicineOut objMODomain = new clsDcl_MedicineOut();
            bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;
            bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;
            clsMS_OutStorage_VO objMain = m_objGetMainISVO();
            DataRow[] drNew = m_objViewer.m_dtbOutMedicine.Select("availagross_int is not null and NETAMOUNT_INT is not null");
            clsMS_OutStorageDetail_VO[] objDetailArr = m_objGetDetailArr(drNew, objMain.m_lngSERIESID_INT);

            lngRes = objMODomain.m_lngSaveOutStorage(ref objMain, m_objCurrentSubArr, ref objDetailArr, blnIsCommit, blnIsAddNew, m_objViewer.m_blnIsImmAccount);

            if (lngRes > 0)
            {
                m_objViewer.m_lngMainSEQ = objMain.m_lngSERIESID_INT;
                m_objViewer.m_txtIncomeBillNumber.Text = objMain.m_strOUTSTORAGEID_VCHR;
                m_objCurrentMain = objMain;
                m_objCurrentSubArr = objDetailArr;
                m_mthSetSeriesIDToUI(objDetailArr);

                #region 去除空行
                DataRow[] drNull = m_objViewer.m_dtbOutMedicine.Select("availagross_int is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow drDel in drNull)
                    {
                        m_objViewer.m_dtbOutMedicine.Rows.Remove(drDel);
                    }
                }
                #endregion
                m_objViewer.m_dtbOutMedicine.AcceptChanges();

                if (blnIsCommit)
                {
                    if (m_objViewer.m_blnIsImmAccount)
                    {
                        m_objCurrentMain.m_intSTATUS = 3;
                        m_objViewer.m_cmdSave.Enabled = false;
                        m_objViewer.m_cmdDelete.Enabled = false;
                        m_objViewer.m_cmdInsertRecord.Enabled = false;
                        m_objViewer.m_cmdNextBill.Enabled = false;
                        m_objViewer.panel2.Enabled = false;
                        m_objViewer.m_dgvMedicineDetail.ReadOnly = true;
                        m_objViewer.m_dgvMedicineDetail.AllowUserToAddRows = false;
                    }
                    else
                    {
                        m_objCurrentMain.m_intSTATUS = 2;
                        m_objViewer.m_cmdSave.Enabled = true;
                        m_objViewer.m_cmdDelete.Enabled = true;
                        m_objViewer.m_cmdInsertRecord.Enabled = true;
                        m_objViewer.m_cmdNextBill.Enabled = true;
                        m_objViewer.panel2.Enabled = true;
                        m_objViewer.m_dgvMedicineDetail.ReadOnly = false;
                        m_objViewer.m_dgvMedicineDetail.AllowUserToAddRows = true;
                    }
                }

                MessageBox.Show("保存成功", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("保存失败", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }            
            return lngRes;
        }

        /// <summary>
        /// 更新界面数据的序列号
        /// </summary>
        /// <param name="p_objDetailArr">药品出库明细</param>
        private void m_mthSetSeriesIDToUI(clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            if (m_objViewer.m_dtbOutMedicine != null && m_objViewer.m_dtbOutMedicine.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
                {
                    if (iRow < p_objDetailArr.Length)
                    {
                        m_objViewer.m_dtbOutMedicine.Rows[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        m_objViewer.m_dtbOutMedicine.Rows[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                    }                    
                }
            }
        }
        #endregion

        #region 审核药品信息
        /// <summary>
        /// 审核药品信息
        /// </summary>
        internal void m_mthCommitMedicine(clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objSubArr)
        {

            if (p_objMain == null || p_objSubArr == null)
            {
                return;
            }

            try
            {
                long lngRes = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                List<clsMS_StorageDetail> objDetail = new List<clsMS_StorageDetail>();
                DataTable dtbDetail = null;
                clsMS_StorageDetail[] objDetailTemp = m_objDetailVO(p_objSubArr);
                if (objDetailTemp != null && objDetailTemp.Length > 0)
                {
                    objDetail.AddRange(objDetailTemp);
                }

                clsMS_StorageDetail[] objAllDetail = objDetail.ToArray();//全部明细VO

                if (objAllDetail == null || objAllDetail.Length == 0)
                {
                    return;
                }

                clsMS_Storage[] objStorageArr = new clsMS_Storage[objAllDetail.Length];
                for (int iRow = 0; iRow < objAllDetail.Length; iRow++)
                {
                    //先获取库存主表信息
                    objStorageArr[iRow] = new clsMS_Storage();
                    objStorageArr[iRow].m_strMEDICINEID_CHR = objAllDetail[iRow].m_strMEDICINEID_CHR;
                    objStorageArr[iRow].m_strMEDICINENAME_VCHR = objAllDetail[iRow].m_strMEDICINENAME_VCHR;
                    objStorageArr[iRow].m_strMEDSPEC_VCHR = objAllDetail[iRow].m_strMEDSPEC_VCHR;
                    objStorageArr[iRow].m_strOPUNIT_VCHR = objAllDetail[iRow].m_strOPUNIT_VCHR;
                    objStorageArr[iRow].m_dblINSTOREGROSS_INT = 0;//出库时不需对入库总量作修改

                    objStorageArr[iRow].m_dblCURRENTGROSS_NUM = objAllDetail[iRow].m_dblAVAILAGROSS_INT;
                    objStorageArr[iRow].m_dcmCALLPRICE_INT = objAllDetail[iRow].m_dcmCALLPRICE_INT;
                    objStorageArr[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

                    objAllDetail[iRow].m_dblAVAILAGROSS_INT = 0;//审核时库存子表不再对可用库存进行修改，以免重复
                }
                bool blnSaveComplete = true;
                lngRes = objSTDomain.m_lngSubStorageDetailGross(objAllDetail);

                if (lngRes > 0)
                {
                    blnSaveComplete = true;
                }
                else
                {
                    blnSaveComplete = false;
                }

                if (!blnSaveComplete)
                {
                    return;
                }

                for (int iRow = 0; iRow < objStorageArr.Length; iRow++)
                {
                    lngRes = objSTDomain.m_lngSubStorageGross(objStorageArr[iRow]);
                }

                if (blnSaveComplete)
                {
                    m_mthUpdateUIAfterCommit(p_objMain);
                    m_mthSetCommitUser(p_objMain);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }

        /// <summary>
        /// 设置审核人
        /// </summary>
        /// <param name="p_objMain">数据</param>
        private void m_mthSetCommitUser(clsMS_OutStorage_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return;
            }

            clsDcl_OutStorage objPur = new clsDcl_OutStorage();
            long[] lngSeq = new long[] { p_objMain.m_lngSERIESID_INT };
            long lngRes = objPur.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSeq);
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="p_objMain">数据</param>
        private void m_mthUpdateUIAfterCommit(clsMS_OutStorage_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return;
            }

            p_objMain.m_intSTATUS = 2;
        }

        #region 根据数据返回库存子表VO
        /// <summary>
        /// 根据数据返回库存子表VO
        /// </summary>
        /// <param name="p_objSubArr">数据</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objDetailVO(clsMS_OutStorageDetail_VO[] p_objSubArr)
        {
            if (p_objSubArr == null || p_objSubArr.Length == 0)
            {
                return null;
            }

            clsMS_StorageDetail[] objSubVO = new clsMS_StorageDetail[p_objSubArr.Length];
            for (int iRow = 0; iRow < p_objSubArr.Length; iRow++)
            {
                objSubVO[iRow] = new clsMS_StorageDetail();
                objSubVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objSubVO[iRow].m_strMEDICINEID_CHR = p_objSubArr[iRow].m_strMEDICINEID_CHR;
                objSubVO[iRow].m_strMEDICINENAME_VCHR = p_objSubArr[iRow].m_strMEDICINENAME_VCH;
                objSubVO[iRow].m_strMEDSPEC_VCHR = p_objSubArr[iRow].m_strMEDSPEC_VCHR;
                objSubVO[iRow].m_strLOTNO_VCHR = p_objSubArr[iRow].m_strLOTNO_VCHR;
                objSubVO[iRow].m_dcmRETAILPRICE_INT = p_objSubArr[iRow].m_dcmRETAILPRICE_INT;
                objSubVO[iRow].m_dcmCALLPRICE_INT = p_objSubArr[iRow].m_dcmCALLPRICE_INT;
                objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = p_objSubArr[iRow].m_dcmWHOLESALEPRICE_INT;
                objSubVO[iRow].m_dblREALGROSS_INT = p_objSubArr[iRow].m_dblNETAMOUNT_INT;
                objSubVO[iRow].m_dblAVAILAGROSS_INT = p_objSubArr[iRow].m_dblNETAMOUNT_INT;
                objSubVO[iRow].m_strOPUNIT_VCHR = p_objSubArr[iRow].m_strOPUNIT_CHR;
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = p_objSubArr[iRow].m_dtmValidperiod_dat;
                objSubVO[iRow].m_strPRODUCTORID_CHR = p_objSubArr[iRow].m_strProductorID_chr;
                objSubVO[iRow].m_strINSTORAGEID_VCHR = p_objSubArr[iRow].m_strINSTORAGEID_VCHR;
                objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = p_objSubArr[iRow].m_dtmINSTORAGEDATE_DAT;
                objSubVO[iRow].m_strVENDORID_CHR = p_objSubArr[iRow].m_strVENDORID_CHR;
                objSubVO[iRow].m_strVENDORName = p_objSubArr[iRow].m_strVendorName;
                objSubVO[iRow].m_intStatus = 1;
            }
            return objSubVO;
        }
        #endregion 
        #endregion

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <returns></returns>
        private clsMS_OutStorage_VO m_objGetMainISVO()
        {
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsMS_OutStorage_VO();
                m_objCurrentMain.m_dtmASKDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objCurrentMain.m_intSTATUS = 1;
                m_objCurrentMain.m_strASKERID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            }

            m_objCurrentMain.m_strASKDEPT_CHR = string.Empty;
            m_objCurrentMain.m_intOutStorageTYPE_INT = 1;
            m_objCurrentMain.m_intFORMTYPE_INT = 4;
            m_objCurrentMain.m_strCOMMENT_VCHR = string.Empty;
            m_objCurrentMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            m_objCurrentMain.m_dtmOutStorageDate = Convert.ToDateTime(m_objViewer.m_dtpInComeDate.Text);
            return m_objCurrentMain;
        }
        #endregion

        #region 获取子表内容
        /// <summary>
        /// 获取子表内容
        /// </summary>
        /// <param name="p_drDetail">子表数据</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        private clsMS_OutStorageDetail_VO[] m_objGetDetailArr(DataRow[] p_drDetail, long p_lngMainSEQ)
        {
            clsMS_OutStorageDetail_VO[] objDetailArr = null;
            if (p_drDetail == null || p_drDetail.Length == 0)
            {
                return null;
            }

            objDetailArr = new clsMS_OutStorageDetail_VO[p_drDetail.Length];
            for (int iRow = 0; iRow < p_drDetail.Length; iRow++)
            {
                objDetailArr[iRow] = new clsMS_OutStorageDetail_VO();
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = p_drDetail[iRow]["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCH = p_drDetail[iRow]["MEDICINENAME_VCHR"].ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR = p_drDetail[iRow]["MEDSPEC_VCHR"].ToString();
                objDetailArr[iRow].m_strOPUNIT_CHR = p_drDetail[iRow]["OPUNIT_CHR"].ToString();
                objDetailArr[iRow].m_dblNETAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["NETAMOUNT_INT"]);

                clsMS_MedicineTypeVisionmSet clsTypeVO = new clsMS_MedicineTypeVisionmSet();
                m_objDomain.m_lngGetMedicineTypeVisionm(p_drDetail[iRow]["MedicineTypeID_chr"].ToString(),out clsTypeVO);
                if (clsTypeVO != null && p_drDetail[iRow]["LOTNO_VCHR"].ToString().Trim() == "" && clsTypeVO.m_intLotno == 0)
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = p_drDetail[iRow]["LOTNO_VCHR"].ToString();
                }

                objDetailArr[iRow].m_strINSTORAGEID_VCHR = p_drDetail[iRow]["INSTORAGEID_VCHR"].ToString();
                objDetailArr[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drDetail[iRow]["CALLPRICE_INT"]);
                objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(p_drDetail[iRow]["WHOLESALEPRICE_INT"]);
                objDetailArr[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(p_drDetail[iRow]["RETAILPRICE_INT"]);
                objDetailArr[iRow].m_strVENDORID_CHR = p_drDetail[iRow]["VENDORID_CHR"].ToString();
                objDetailArr[iRow].m_strVendorName = p_drDetail[iRow]["vendorname_vchr"].ToString();
                objDetailArr[iRow].m_dtmValidperiod_dat = Convert.ToDateTime(p_drDetail[iRow]["validperiod_dat"]);
                objDetailArr[iRow].m_strProductorID_chr = p_drDetail[iRow]["productorid_chr"].ToString();
                objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(p_drDetail[iRow]["instoragedate_dat"]);
                objDetailArr[iRow].m_strRejectReason = p_drDetail[iRow]["REJECTREASON"].ToString();
                objDetailArr[iRow].m_dblRealGross = Convert.ToDouble(p_drDetail[iRow]["realgross_int"]);

                objDetailArr[iRow].m_strMedicineTypeID_chr = p_drDetail[iRow]["MedicineTypeID_chr"].ToString();

                objDetailArr[iRow].m_intStatus = 1;
                objDetailArr[iRow].m_intRETURNNUM_INT = 0;
                if (p_drDetail[iRow]["packqty_dec"] == DBNull.Value)
                {
                    objDetailArr[iRow].m_decPackQty = 0;
                }
                else
                {
                    objDetailArr[iRow].m_decPackQty = Convert.ToDecimal(p_drDetail[iRow]["packqty_dec"]);
                }
            }
            return objDetailArr;
        }
        #endregion

        #region 增加可用库存
        /// <summary>
        /// 增加可用库存
        /// </summary>
        /// <param name="p_objDetail">出库子表数据</param>
        private void m_mthAddAvailaGross(clsMS_OutStorageDetail_VO[] p_objDetail)
        {
            clsMS_StorageGrossForOut[] objSubArr = null;
            long lngRes = 0;
            objSubArr = m_objGetDetail(p_objDetail);

            if (objSubArr.Length > 0)
            {
                clsDcl_Storage objSTDomain = new clsDcl_Storage();
                lngRes = objSTDomain.m_lngAddStorageDetailAvailaGross(objSubArr);
            }
        }
        #endregion

        #region 获取库存子表VO
        /// <summary>
        /// 获取库存子表VO
        /// </summary>
        /// <param name="p_objDetail">出库子表数据</param>
        /// <returns></returns>
        private clsMS_StorageGrossForOut[] m_objGetDetail(clsMS_OutStorageDetail_VO[] p_objDetail)
        {
            clsMS_StorageGrossForOut[] objDetailArr = null;

            if (p_objDetail == null || p_objDetail.Length == 0)
            {
                return null;
            }

            int intRowsCount = p_objDetail.Length;
            if (intRowsCount > 0)
            {
                objDetailArr = new clsMS_StorageGrossForOut[intRowsCount];
            }
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                objDetailArr[iRow] = new clsMS_StorageGrossForOut();
                objDetailArr[iRow].m_strMedicineID = p_objDetail[iRow].m_strMEDICINEID_CHR;
                objDetailArr[iRow].m_strStorageID = m_objViewer.m_strStorageID;
                objDetailArr[iRow].m_strInStorageID = p_objDetail[iRow].m_strINSTORAGEID_VCHR;
                objDetailArr[iRow].m_strLotNO = p_objDetail[iRow].m_strLOTNO_VCHR;
                objDetailArr[iRow].m_dblGross = p_objDetail[iRow].m_dblNETAMOUNT_INT;
                objDetailArr[iRow].m_dblGross = p_objDetail[iRow].m_dblNETAMOUNT_INT;
            }
            return objDetailArr;
        }
        #endregion

        #region 退审
        /// <summary>
        /// 退审
        /// </summary>
        /// <param name="p_drCurrent">选定药品数据</param>
        /// <param name="dblAmount">出库实发数量</param>
        internal void m_mthUnCommit(DataRow p_drCurrent, double dblAmount)
        {
            clsMS_Storage objStorage = new clsMS_Storage();
            objStorage.m_strMEDICINEID_CHR = p_drCurrent["MEDICINEID_CHR"].ToString();
            objStorage.m_strMEDICINENAME_VCHR = p_drCurrent["MEDICINENAME_VCHR"].ToString();
            objStorage.m_strMEDSPEC_VCHR = p_drCurrent["MEDSPEC_VCHR"].ToString();
            objStorage.m_strOPUNIT_VCHR = p_drCurrent["OPUNIT_CHR"].ToString();
            objStorage.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drCurrent["CALLPRICE_INT"]);
            objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

            clsDcl_Storage objSTDomain = new clsDcl_Storage();
            bool blnHasDetail = false;
            long lngCurrentSeriesID = 0;
            long lngRes = objSTDomain.m_lngCheckHasStorage(objStorage.m_strMEDICINEID_CHR, m_objViewer.m_strStorageID, out blnHasDetail, out lngCurrentSeriesID);

            long lngSubSEQ = 0;
            double p_dblRealgross = 0d;
            double p_dblAvailagross = 0d;
            lngRes = objSTDomain.m_lngGetDetailSEQByIndex(p_drCurrent["INSTORAGEID_VCHR"].ToString(), p_drCurrent["MEDICINEID_CHR"].ToString(), p_drCurrent["LOTNO_VCHR"].ToString(), Convert.ToDateTime(p_drCurrent["validperiod_dat"]), Convert.ToDouble(p_drCurrent["CALLPRICE_INT"]), m_objViewer.m_strStorageID, out lngSubSEQ, out p_dblRealgross, out p_dblAvailagross);
            if (lngSubSEQ > 0)
            {
                objStorage.m_dblINSTOREGROSS_INT = 0;
                objStorage.m_dblCURRENTGROSS_NUM = dblAmount;
                lngRes = objSTDomain.m_lngAddStorageDetailGross(dblAmount, 0, lngSubSEQ);//删除时不再增加可用库存，以免重复添加
            }

            objStorage.m_lngSERIESID_INT = lngCurrentSeriesID;
            lngRes = objSTDomain.m_lngModifyStorageFromInitial(objStorage, lngCurrentSeriesID);
        }
        #endregion

        #region 删除出库明细
        /// <summary>
        /// 删除出库明细
        /// </summary>
        /// <returns></returns>
        internal void m_mthDeleteDetail()
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS != 1)
            {
                if (m_objCurrentMain.m_intSTATUS == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品出库记录已入帐，不能删除", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品出库记录已审核，不能删除", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            //20090721:保存、删除、审核单据时，均判断是否新制状态
            if (m_objViewer.m_txtIncomeBillNumber.Text.Length > 0)
            {
                bool blnNewState = false;
                clsDcl_Purchase_Detail clsDcl = new clsDcl_Purchase_Detail();
                clsDcl.m_lngCheckBillState(2, m_objViewer.m_txtIncomeBillNumber.Text.Trim(), out blnNewState);
                if (!blnNewState)
                {
                    MessageBox.Show("该出库单不是新制状态，请关闭并刷新后重试", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (m_objViewer.m_dgvMedicineDetail.SelectedCells.Count == 0)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineDetail.SelectedCells[0].RowIndex;
            DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvMedicineDetail.Rows[intRowIndex].DataBoundItem)).Row;
            clsDcl_MedicineOut objMODomain = new clsDcl_MedicineOut();

            long lngSEQ = 0;
            if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngSEQ))
            {
                double dblAmount = 0d;
                long lngRes = objMODomain.m_lngGetOutStorageDetailGross(lngSEQ, out dblAmount);
                bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;

                clsMS_Storage objStorage = null;
                if (blnIsCommit)
                {
                    objStorage = new clsMS_Storage();
                    objStorage.m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                    objStorage.m_strMEDICINENAME_VCHR = drCurrent["MEDICINENAME_VCHR"].ToString();
                    objStorage.m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                    objStorage.m_strOPUNIT_VCHR = drCurrent["OPUNIT_CHR"].ToString();
                    objStorage.m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                    objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                    objStorage.m_strVENDORID_CHR = drCurrent["VENDORID_CHR"].ToString();
                }

                lngRes = objMODomain.m_lngDeleteSelectedMedicine(lngSEQ, m_objCurrentMain.m_strOUTSTORAGEID_VCHR, m_objViewer.m_strStorageID, drCurrent["MEDICINEID_CHR"].ToString(), drCurrent["LOTNO_VCHR"].ToString(), drCurrent["INSTORAGEID_VCHR"].ToString(), Convert.ToDateTime(drCurrent["validperiod_dat"]), Convert.ToDouble(drCurrent["CALLPRICE_INT"]), blnIsCommit, objStorage, dblAmount);
                
                if (lngRes > 0)
                {
                    if (m_objCurrentSubArr != null)
                    {
                        List<clsMS_OutStorageDetail_VO> lstDetail = new List<clsMS_OutStorageDetail_VO>();
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

                    m_objViewer.m_dtbOutMedicine.Rows.Remove(drCurrent);
                    MessageBox.Show("删除成功", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                m_objViewer.m_dtbOutMedicine.Rows.Remove(drCurrent);
            }
        }
        #endregion

        #region 清空界面
        /// <summary>
        /// 清空界面
        /// </summary>
        internal void m_mthClear()
        {
            m_objViewer.m_dtbOutMedicine.Rows.Clear();
            m_objViewer.m_txtIncomeBillNumber.Clear();
            m_objViewer.m_dtpInComeDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            m_objViewer.m_lngMainSEQ = 0;

            m_objCurrentMain = null;
            m_objCurrentSubArr = null;
        }
        #endregion

        #region 设置出库信息至界面
        /// <summary>
        /// 设置出库信息至界面
        /// </summary>
        /// <param name="p_objMain">出库主表信息</param>
        /// <param name="p_objDetailArr">出库子表信息</param>
        /// <param name="p_intSelectedSubRow">子表选中行索引</param>
        internal void m_mthSetOutStorageToUI(clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objDetailArr, int p_intSelectedSubRow)
        {
            if (p_objMain == null)
            {
                return;
            }

            #region 主表
            m_objCurrentMain = p_objMain;
            m_objViewer.m_dtpInComeDate.Text = p_objMain.m_dtmOutStorageDate.ToString("yyyy年MM月dd日");
            m_objViewer.m_txtIncomeBillNumber.Text = p_objMain.m_strOUTSTORAGEID_VCHR;
            m_objViewer.m_lngMainSEQ = p_objMain.m_lngSERIESID_INT;

            if (p_objMain.m_intSTATUS != 1)
            {
                m_objViewer.m_cmdSave.Enabled = false;
                m_objViewer.m_cmdDelete.Enabled = false;
                m_objViewer.m_cmdInsertRecord.Enabled = false;
                m_objViewer.m_cmdNextBill.Enabled = false;
                m_objViewer.panel2.Enabled = false;
                m_objViewer.m_dgvMedicineDetail.ReadOnly = true;
                m_objViewer.m_dgvMedicineDetail.AllowUserToAddRows = false;
            }

            if (m_objViewer.m_intCommitFolow == 1 && p_objMain.m_intSTATUS != 0 && p_objMain.m_intSTATUS != 3)
            {
                m_objViewer.m_cmdSave.Enabled = true;
                m_objViewer.m_cmdDelete.Enabled = true;
                m_objViewer.m_cmdInsertRecord.Enabled = true;
                m_objViewer.m_cmdNextBill.Enabled = true;
                m_objViewer.panel2.Enabled = true;
                m_objViewer.m_dgvMedicineDetail.ReadOnly = false;
                m_objViewer.m_dgvMedicineDetail.AllowUserToAddRows = true;
            }
            #endregion

            try
            {
                m_objCurrentSubArr = p_objDetailArr;
                m_objViewer.m_dtbOutMedicine.BeginLoadData();
                DataRow drSub = null;
                for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                {
                    drSub = m_objViewer.m_dtbOutMedicine.NewRow();
                    drSub["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                    drSub["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                    drSub["MEDICINEID_CHR"] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                    drSub["MEDICINENAME_VCHr"] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                    drSub["MEDSPEC_VCHR"] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                    drSub["OPUNIT_CHR"] = p_objDetailArr[iRow].m_strOPUNIT_CHR;
                    drSub["NETAMOUNT_INT"] = p_objDetailArr[iRow].m_dblNETAMOUNT_INT;
                    drSub["originality_Amount"] = p_objDetailArr[iRow].m_dblNETAMOUNT_INT;
                    drSub["LOTNO_VCHR"] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                    drSub["INSTORAGEID_VCHR"] = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                    drSub["CALLPRICE_INT"] = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                    drSub["WHOLESALEPRICE_INT"] = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                    drSub["RETAILPRICE_INT"] = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                    drSub["VENDORID_CHR"] = p_objDetailArr[iRow].m_strVENDORID_CHR;
                    drSub["vendorname_vchr"] = p_objDetailArr[iRow].m_strVendorName;
                    drSub["productorid_chr"] = p_objDetailArr[iRow].m_strProductorID_chr;
                    drSub["inmoney"] = p_objDetailArr[iRow].m_dcmBuyInMoney;
                    drSub["retailmoney"] = p_objDetailArr[iRow].m_dcmRetailMoney;
                    drSub["instoragedate_dat"] = p_objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
                    drSub["validperiod_dat"] = p_objDetailArr[iRow].m_dtmValidperiod_dat.ToString("yyyy-MM-dd");
                    drSub["realgross_int"] = p_objDetailArr[iRow].m_dblRealGross;
                    drSub["assistcode_chr"] = p_objDetailArr[iRow].m_strMEDICINECode;
                    drSub["availagross_int"] = p_objDetailArr[iRow].m_dblAvailaGross;
                    drSub["storageunit"] = p_objDetailArr[iRow].m_strStorageUnit;
                    drSub["REJECTREASON"] = p_objDetailArr[iRow].m_strRejectReason;
                    drSub["medicinetypeid_chr"] = p_objDetailArr[iRow].m_strMedicineTypeID_chr;
                    if (p_objDetailArr[iRow].m_dblAskAmount == 0)
                    {
                        drSub["askamount"] = DBNull.Value;
                    }
                    else
                    {
                        drSub["askamount"] = p_objDetailArr[iRow].m_dblAskAmount;
                    }
                    drSub["packqty_dec"] = p_objDetailArr[iRow].m_decPackQty;
                    m_objViewer.m_mthAddReasonItem(p_objDetailArr[iRow].m_strRejectReason);
                    m_objViewer.m_dtbOutMedicine.LoadDataRow(drSub.ItemArray, true);
                }
            }
            catch (Exception Ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(Ex);
            }
            finally
            {
                m_objViewer.m_dtbOutMedicine.EndLoadData();
            }

            if (p_intSelectedSubRow > 0 && m_objViewer.m_dgvMedicineDetail.Rows.Count > 0 && p_intSelectedSubRow < m_objViewer.m_dgvMedicineDetail.Rows.Count)
            {
                m_objViewer.m_dgvMedicineDetail.Rows[p_intSelectedSubRow].Selected = true;
                m_objViewer.m_dgvMedicineDetail.CurrentCell = m_objViewer.m_dgvMedicineDetail.Rows[p_intSelectedSubRow].Cells[1];
            }
        }
        #endregion

        #region 调价判断
        internal void m_mthGetAdjustrice(string medicineid_chr, string lotno_vchr, string instorageid_vchr, DateTime p_dtmValiDate, double p_dblInPrice, out bool bolAdjustrice)
        {
            if (lotno_vchr == "")
            {
                lotno_vchr = "UNKNOWN";
            }
            m_objDomain.m_mthGetAdjustrice(medicineid_chr, lotno_vchr, instorageid_vchr, p_dtmValiDate, p_dblInPrice, m_objCurrentMain.m_dtmASKDATE_DAT, out bolAdjustrice);
        }

        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        /// <param name="dtbStorageCheck_detail"></param>
        internal void m_mthPrint()
        {
            if (m_objCurrentMain == null)
            {
                MessageBox.Show("抱歉！请先保存，再打印！", "药品报废", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmRejectOutStorageReport frmRejectRep = new frmRejectOutStorageReport();
            frmRejectRep.m_strReportName = m_objViewer.m_strReportName;
            DataTable dtbPrint;
            m_objDomain.m_lngGetRejectPrint(m_objCurrentMain.m_lngSERIESID_INT, out dtbPrint);
            frmRejectRep.dtb = dtbPrint;

            string strStorName;
            m_objDomain.m_lngGetStoreRoomName(m_objCurrentMain.m_strSTORAGEID_CHR, out strStorName);
            frmRejectRep.strStorageName = strStorName;
            decimal mm = Convert.ToDecimal(m_objViewer.m_lblBugMoney.Text);
            frmRejectRep.strBag = new Money(mm).ToString();

            frmRejectRep.m_strTitle = this.m_objComInfo.m_strGetHospitalTitle() + "报废单(" + strStorName +")";
            frmRejectRep.strCheckDate = m_objCurrentMain.m_dtmASKDATE_DAT.ToString("yyyy年MM月dd日");
            long sss = m_objCurrentMain.m_lngSERIESID_INT;
            frmRejectRep.strAskerName = m_objCurrentMain.m_strASKERName;
            frmRejectRep.strStorageName = strStorName; 
            frmRejectRep.strExamerName = m_objCurrentMain.m_strEXAMERName;
            frmRejectRep.ShowDialog();
        }
        #endregion

    }
}
