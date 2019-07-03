using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 出库单控制类
    /// </summary>
    public class clsCtl_OutStorageMakerOrder : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 初始化
        /// <summary>
        /// contructor
        /// </summary>
        public clsCtl_OutStorageMakerOrder()
        {
            m_objDomain = new clsDcl_OutStorageMakerOrder();
        }
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOutStorageMakerOrder)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 制单主界面
        /// </summary>
        private frmOutStorageMakerOrder m_objViewer;
        private clsDcl_OutStorageMakerOrder m_objDomain;
        /// <summary>
        /// 查询药品字典控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 当前药房出库主表信息
        /// </summary>
        private clsDS_OutStorage_VO m_objCurrentMain = null;
        /// <summary>
        ///  当前药房出库子表信息
        /// </summary>
        private clsDS_Outstorage_Detail[] m_objCurrentSubArr = null;        
        #endregion
        #region 初始化子表作为DataGridView数据源的DataTable
        /// <summary>
        /// 初始化子表作为DataGridView数据源的DataTable
        /// </summary>
        /// <param name="m_dtMedDetail"></param>
        public void m_mthInitMedicineTable(ref DataTable m_dtMedDetail)
        {
            m_dtMedDetail = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("SERIESID_INT"), new DataColumn("SERIESID2_INT"), new DataColumn("MEDICINEID_CHR"),new DataColumn("assistcode_chr"), new DataColumn("MEDICINENAME_VCHR"),
                new DataColumn("MEDSPEC_VCHR"),new DataColumn("OPUNIT_CHR"),new DataColumn("OPAMOUNT_INT",typeof(double)),new DataColumn("IPUNIT_CHR"),new DataColumn("IPAMOUNT_INT",typeof(double)),new DataColumn("PACKQTY_DEC",
                typeof(double)),new DataColumn("OPWHOLESALEPRICE_INT",typeof(double)),new DataColumn("IPWHOLESALEPRICE_INT",typeof(double)),new DataColumn("OPRETAILPRICE_INT",typeof(double)),new DataColumn("IPRETAILPRICE_INT",typeof(double)),
                new DataColumn("LOTNO_VCHR",typeof(string)),new DataColumn("VALIDPERIOD_DAT",typeof(string)),new DataColumn("STATUS",typeof(string)),new DataColumn("rejectreason",typeof(string)),new DataColumn("storageseriesid_chr",typeof(string)),
                new DataColumn("INSTOREID_VCHR",typeof(string)),new DataColumn("instoragedate_dat",typeof(DateTime)),new DataColumn("oprealgross_int",typeof(double)),new DataColumn("opavailagross_int",typeof(double)),new DataColumn("medicinetypeid_chr",typeof(string)),
                new DataColumn("iprealgross_int",typeof(double)),new DataColumn("ipavailablegross_num",typeof(double)),new DataColumn("productorid_chr",typeof(string)),new DataColumn("amount_int",typeof(double)),new DataColumn("UNIT_CHR"),
            new DataColumn("WHOLESALEPRICE_INT",typeof(double)),new DataColumn("RETAILPRICE_INT",typeof(double)),new DataColumn("opchargeflg_int",typeof(double)),new DataColumn("ipchargeflg_int",typeof(double)),new DataColumn("DSINSTOREID_VCHR",typeof(string)),new DataColumn("retailmoney",typeof(double))};
            m_dtMedDetail.Columns.AddRange(dcColumns);
            m_dtMedDetail.Columns["retailmoney"].Expression = "OPRETAILPRICE_INT / PACKQTY_DEC * IPAMOUNT_INT";
        }
        #endregion
        
        #region 插入新的一行药品信息
        /// <summary>
        /// 插入新的一行药品信息
        /// </summary>
        internal void m_mthInsertNewMedicineInfo()
        {
            if (m_objViewer.m_dtOutStorageMedicine == null)
            {
                return;
            }
            m_objViewer.m_dtOutStorageMedicine.AcceptChanges();
            DataRow drNew = m_objViewer.m_dtOutStorageMedicine.NewRow();
            m_objViewer.m_dtOutStorageMedicine.Rows.Add(drNew);
            m_objViewer.m_dgvDetail.Focus();
            m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail[1, m_objViewer.m_dgvDetail.RowCount - 1];
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
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvDetail.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvDetail.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint,true);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
                m_ctlQueryMedicint.Location = new System.Drawing.Point(0, rect.Y + m_objViewer.m_dgvDetail.Location.Y+112);// + m_objViewer.m_dgvDetail.Location.Y + rect.Height);
                //if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
                //{
                //    m_ctlQueryMedicint.Location = new System.Drawing.Point(0, rect.Y + m_objViewer.m_dgvDetail.Location.Y - m_ctlQueryMedicint.Size.Height);
                //}
            }            
            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            clsPub.m_mthGetOutStorageMedBaseInfo(m_objViewer.m_blnIsHospital,m_objViewer.frmMain.m_strMedStoreArr[0], out m_objViewer.m_dtMedicine);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtMedicine;
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        {
            long lngReturn = 1;
            return lngReturn;
        }
        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }
            int intRowIndex = m_objViewer.m_dgvDetail.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvDetail.CurrentCell.ColumnIndex;

            if (m_objViewer.m_dtOutStorageMedicine != null)
            {
                DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvDetail.CurrentCell.OwningRow.DataBoundItem)).Row;

                //清空一些内容，防止修改药品时出错
                for (int i1 = 0; i1 < drCurrent.Table.Columns.Count; i1++)
                {
                    if (drCurrent.Table.Columns[i1].ColumnName.ToLower() != "retailmoney")
                        drCurrent[i1] = drCurrent.Table.Columns[i1].DefaultValue;
                }
                m_objViewer.m_mthShowRetailMoney();

                drCurrent["assistcode_chr"] = MS_VO.m_strMedicineCode;
                drCurrent["MEDICINENAME_VCHr"] = MS_VO.m_strMedicineName;
                drCurrent["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
                drCurrent["medicinetypeid_chr"] = MS_VO.m_strMedicineTypeID;
                drCurrent["OPUNIT_CHR"] = MS_VO.m_strOpUnit_chr;
                drCurrent["IPUNIT_CHR"] = MS_VO.m_strIpUnit_chr;
                drCurrent["MEDICINEID_CHR"] = MS_VO.m_strMedicineID;
                drCurrent["packqty_dec"] = MS_VO.m_strPackqty_dec;
                drCurrent["OPWHOLESALEPRICE_INT"] = MS_VO.m_dcmTradePrice;
                drCurrent["OPRETAILPRICE_INT"] = MS_VO.m_dcmRetailPrice;
                drCurrent["productorid_chr"] = MS_VO.m_strManufacturer;
                drCurrent["opchargeflg_int"] = MS_VO.m_intOpChargeflg_int;
                drCurrent["ipchargeflg_int"] = MS_VO.m_intIpchargeflg_int;
                double dblUnitPrice = 0d;
                double dblPackQty = 0d;
                if (double.TryParse(drCurrent["packqty_dec"].ToString(), out dblPackQty) && double.TryParse(drCurrent["OPWHOLESALEPRICE_INT"].ToString(), out dblUnitPrice))
                {
                    drCurrent["IPWHOLESALEPRICE_INT"] = ((double)(dblUnitPrice / dblPackQty)).ToString("0.0000");
                }
                if (double.TryParse(drCurrent["packqty_dec"].ToString(), out dblPackQty) && double.TryParse(drCurrent["OPRETAILPRICE_INT"].ToString(), out dblUnitPrice))
                {
                    drCurrent["IPRETAILPRICE_INT"] = ((double)(dblUnitPrice / dblPackQty)).ToString("0.0000");
                }
                m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail.Rows[intRowIndex].Cells["amount_int"];
                m_objViewer.m_dgvDetail.CurrentCell.Value = 0;
            }
            m_objViewer.m_dgvDetail.Refresh();
            m_objViewer.m_dgvDetail.Focus();
            m_objViewer.m_dgvDetail.CurrentCell.Selected = true;
            //System.Windows.Forms.SendKeys.SendWait("{Enter}");
        }
        #endregion

        #region 保存药房出库制单明细信息
        /// <summary>
        /// 保存药房出库制单明细信息
        /// </summary>
        /// <param name="p_blnWantHint">是否显示提示信息</param>
        /// <returns></returns>
        internal long m_lngSaveOutstorageMedInfo(bool p_blnWantHint)
        {
            #region 有效性检查
            m_objViewer.m_dgvDetail.EndEdit();
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS != 1 && m_objCurrentMain.m_intSTATUS != 2 && m_objCurrentMain.m_intSTATUS != 0 && p_blnWantHint)
            {
                if (m_objCurrentMain.m_intSTATUS == 2)
                {
                    MessageBox.Show("该药房出库单记录已审核，不能修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (m_objCurrentMain.m_intSTATUS == 3)
                {
                    MessageBox.Show("该药房出库单记录已入帐，不能修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            if (string.IsNullOrEmpty(m_objViewer.m_cboStatus.Text) && p_blnWantHint)
            {
                MessageBox.Show("必须填写出库类型", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_cboStatus.Focus();
                return -1;
            }
            if (string.IsNullOrEmpty(m_objViewer.m_txtFromDept.Text) && p_blnWantHint)
            {
                MessageBox.Show("必须填写发往部门", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_txtFromDept.Focus();
                return -1;
            }
            if (string.IsNullOrEmpty(m_objViewer.m_cboMedStore.Text) && p_blnWantHint)
            {
                MessageBox.Show("必须填写出库的药房名称", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_cboMedStore.Focus();
                return -1;
            }
            //if (m_objViewer.m_txtFromDept.StrItemId == m_objViewer.m_cboMedStore.SelectItemValue)
            //{
            //    MessageBox.Show("申请部门和出库药房不能相同", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    this.m_objViewer.m_txtFromDept.Focus();
            //    return -1;
            //}
            if ((m_objViewer.m_dtOutStorageMedicine == null || m_objViewer.m_dtOutStorageMedicine.Rows.Count == 0) && p_blnWantHint)
            {
                MessageBox.Show("请先填写出库药品信息", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return -1;
            }
            else if (m_objViewer.m_dtOutStorageMedicine.Rows.Count == 1)//只有一行自动添加的空数据
            {
                if (m_objViewer.m_dtOutStorageMedicine.Rows[0]["MEDICINEID_CHR"] == DBNull.Value)
                {
                    MessageBox.Show("请先填写出库药品信息", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            double dblAmount = 0d;
            DataRow drTemp = null;
            decimal dcmInputPrice = 0;
            decimal dcmGetPrice = 0;
            bool bln = false;
            List<long> m_glstAvailableGross = new List<long>(m_objViewer.m_dtOutStorageMedicine.Rows.Count);
            for (int iRow = 0; iRow < m_objViewer.m_dtOutStorageMedicine.Rows.Count; iRow++)
            {
                drTemp = m_objViewer.m_dtOutStorageMedicine.Rows[iRow];
                //if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["OPAMOUNT_INT"] != DBNull.Value && drTemp["IPAMOUNT_INT"] != DBNull.Value && drTemp["OPRETAILPRICE_INT"] != DBNull.Value)
                //{
                //    m_objDomain.m_lngGetRetailPrice(Convert.ToString(drTemp["MEDICINEID_CHR"]), out dcmGetPrice);
                //    dcmInputPrice = Convert.ToDecimal(drTemp["OPRETAILPRICE_INT"]);
                //    if (dcmGetPrice != dcmInputPrice)
                //    {
                //        MessageBox.Show(Convert.ToString(drTemp["MEDICINENAME_VCHR"]) + "：检测到零售单价已经调价，不能保存！\n(提示：可以将该药品删除再重新输入，或从药品代码处重新选择此药品)", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        return -1;
                //    }
                //}
                if (bln == false)
                {
                    if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["OPAMOUNT_INT"] != DBNull.Value && drTemp["IPAMOUNT_INT"] != DBNull.Value && drTemp["OPRETAILPRICE_INT"] != DBNull.Value)
                    {
                        m_objDomain.m_lngGetRetailPrice(Convert.ToString(drTemp["MEDICINEID_CHR"]), out dcmGetPrice);
                        dcmInputPrice = Convert.ToDecimal(drTemp["OPRETAILPRICE_INT"]);
                        if (dcmGetPrice != dcmInputPrice)
                        {
                            DialogResult dgl = MessageBox.Show("检查到有出库药品与药品信息的零售价不一致，是否继续保存？", "药品入库", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            if (dgl == DialogResult.Yes)
                            {
                                bln = true;
                            }
                            else
                            {
                                return -1;
                            }
                        }
                    }
                }

                if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["OPAMOUNT_INT"] != DBNull.Value)
                {
                    if (!double.TryParse(drTemp["amount_int"].ToString(), out dblAmount))
                    {
                        MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "出库数量必须为数字", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    
                    if (dblAmount == 0)
                    {
                        MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "出库数量不能为零", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    if (!m_glstAvailableGross.Contains(long.Parse(drTemp["storageseriesid_chr"].ToString())))
                    {
                        m_glstAvailableGross.Add(long.Parse(drTemp["storageseriesid_chr"].ToString()));
                    }

                    #region 杨镇伟修改:按照三院格式修改代码 隐藏判断
                    //if (dblAmount > 0)
                    //{
                    //    if (m_objViewer.m_blnIsHospital)
                    //    {
                    //        if (Convert.ToDouble(drTemp["ipchargeflg_int"]) == 0)
                    //        {
                    //            if (Convert.ToDouble(drTemp["amount_int"]) > Math.Round(Convert.ToDouble(drTemp["ipavailablegross_num"]) / Convert.ToDouble(drTemp["packqty_dec"]), 2, MidpointRounding.AwayFromZero))
                    //            {
                    //                MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "可用库存不足，请修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //                return -1;
                    //            }
                    //            drTemp["OPAMOUNT_INT"] = drTemp["amount_int"];
                    //            drTemp["IPAMOUNT_INT"] = Convert.ToDouble(drTemp["amount_int"]) * Convert.ToDouble(drTemp["packqty_dec"]);
                    //        }
                    //        else
                    //        {
                    //            if (Convert.ToDouble(drTemp["amount_int"]) > Convert.ToDouble(drTemp["ipavailablegross_num"]))
                    //            {
                    //                MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "可用库存不足，请修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //                return -1;
                    //            }
                    //            drTemp["OPAMOUNT_INT"] = Math.Round(Convert.ToDouble(drTemp["amount_int"]) / Convert.ToDouble(drTemp["packqty_dec"]), 2, MidpointRounding.AwayFromZero);
                    //            drTemp["IPAMOUNT_INT"] = drTemp["amount_int"];
                    //        }
                    //    }
                    //    else
                    //    {
                    //        if (Convert.ToDouble(drTemp["opchargeflg_int"]) == 0)
                    //        {
                    //            if (Convert.ToDouble(drTemp["amount_int"]) > Math.Round(Convert.ToDouble(drTemp["ipavailablegross_num"]) / Convert.ToDouble(drTemp["packqty_dec"]), 2, MidpointRounding.AwayFromZero))
                    //            {
                    //                MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "可用库存不足，请修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //                return -1;
                    //            }
                    //            drTemp["OPAMOUNT_INT"] = drTemp["amount_int"];
                    //            drTemp["IPAMOUNT_INT"] = Convert.ToDouble(drTemp["amount_int"]) * Convert.ToDouble(drTemp["packqty_dec"]);
                    //        }
                    //        else
                    //        {
                    //            if (Convert.ToDouble(drTemp["amount_int"]) > Convert.ToDouble(drTemp["ipavailablegross_num"]))
                    //            {
                    //                MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "可用库存不足，请修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    //                return -1;
                    //            }
                    //            drTemp["OPAMOUNT_INT"] = Math.Round(Convert.ToDouble(drTemp["amount_int"]) / Convert.ToDouble(drTemp["packqty_dec"]), 2, MidpointRounding.AwayFromZero);
                    //            drTemp["IPAMOUNT_INT"] = drTemp["amount_int"];
                    //        }
                    //    }
                    //}
                    #endregion
                }
            }

            Dictionary<long, double> m_gdicAvailableGross = null;
            long m_lngSeriesID = -1;
            if (m_objViewer.m_lngMainSEQ != 0)
            {
                m_lngSeriesID = m_objViewer.m_lngMainSEQ;
            }
            long lngRes = this.m_objDomain.m_lngGetDSStorageGross(m_glstAvailableGross, m_lngSeriesID, out m_gdicAvailableGross);
            if (lngRes == -11)
            {
                MessageBox.Show("保存失败！\n该单据状态已经改变，请重新加载后再处理。", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            double m_dblAvailableGross = 0d;
            long m_lngStorageID = -1;
            for (int iRow = 0; iRow < m_objViewer.m_dtOutStorageMedicine.Rows.Count; iRow++)
            {
                drTemp = m_objViewer.m_dtOutStorageMedicine.Rows[iRow];
                if (drTemp["MEDICINEID_CHR"] == DBNull.Value || drTemp["OPAMOUNT_INT"] == DBNull.Value)
                {
                    continue;
                }

                dblAmount = Convert.ToDouble(drTemp["amount_int"]);

                m_lngStorageID = long.Parse(drTemp["storageseriesid_chr"].ToString());

                if (m_gdicAvailableGross.ContainsKey(m_lngStorageID))
                {
                    m_dblAvailableGross = m_gdicAvailableGross[m_lngStorageID];
                }
                else
                {
                    //不足
                }

                if (dblAmount > 0)
                {
                    if (m_objViewer.m_blnIsHospital)
                    {
                        if (Convert.ToDouble(drTemp["ipchargeflg_int"]) == 0)
                        {
                            if (Convert.ToDouble(drTemp["amount_int"]) > Math.Round(m_dblAvailableGross / Convert.ToDouble(drTemp["packqty_dec"]), 2, MidpointRounding.AwayFromZero))
                            {
                                MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "可用库存不足，请修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return -1;
                            }
                            drTemp["OPAMOUNT_INT"] = drTemp["amount_int"];
                            drTemp["IPAMOUNT_INT"] = Convert.ToDouble(drTemp["amount_int"]) * Convert.ToDouble(drTemp["packqty_dec"]);

                            m_dblAvailableGross -= Convert.ToDouble(drTemp["amount_int"]) * Convert.ToDouble(drTemp["packqty_dec"]);
                        }
                        else
                        {
                            if (Convert.ToDouble(drTemp["amount_int"]) > m_dblAvailableGross)
                            {
                                MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "可用库存不足，请修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return -1;
                            }
                            drTemp["OPAMOUNT_INT"] = Math.Round(Convert.ToDouble(drTemp["amount_int"]) / Convert.ToDouble(drTemp["packqty_dec"]), 2, MidpointRounding.AwayFromZero);
                            drTemp["IPAMOUNT_INT"] = drTemp["amount_int"];
                            m_dblAvailableGross -= Convert.ToDouble(drTemp["amount_int"]);
                        }
                    }
                    else
                    {
                        if (Convert.ToDouble(drTemp["opchargeflg_int"]) == 0)
                        {
                            if (Convert.ToDouble(drTemp["amount_int"]) > Math.Round(m_dblAvailableGross / Convert.ToDouble(drTemp["packqty_dec"]), 2, MidpointRounding.AwayFromZero))
                            {
                                MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "可用库存不足，请修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return -1;
                            }
                            drTemp["OPAMOUNT_INT"] = drTemp["amount_int"];
                            drTemp["IPAMOUNT_INT"] = Convert.ToDouble(drTemp["amount_int"]) * Convert.ToDouble(drTemp["packqty_dec"]);

                            m_dblAvailableGross -= Convert.ToDouble(drTemp["amount_int"]) * Convert.ToDouble(drTemp["packqty_dec"]);
                        }
                        else
                        {
                            if (Convert.ToDouble(drTemp["amount_int"]) > m_dblAvailableGross)
                            {
                                MessageBox.Show(drTemp["medicinename_vchr"].ToString() + "可用库存不足，请修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return -1;
                            }
                            drTemp["OPAMOUNT_INT"] = Math.Round(Convert.ToDouble(drTemp["amount_int"]) / Convert.ToDouble(drTemp["packqty_dec"]), 2, MidpointRounding.AwayFromZero);
                            drTemp["IPAMOUNT_INT"] = drTemp["amount_int"];
                            m_dblAvailableGross -= Convert.ToDouble(drTemp["amount_int"]);
                        }
                    }
                }

                m_gdicAvailableGross[m_lngStorageID] = m_dblAvailableGross;
            }

            #endregion

            this.m_objViewer.m_dtOutStorageMedicine.AcceptChanges();
            lngRes = 0;

            string strState = null;
            try
            {
                bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;

                clsDS_OutStorage_VO objMain = m_objGetMainISVO();
                if (objMain.m_strINSTOREDEPT_CHR.Length == 0)
                {
                    MessageBox.Show("必须填写发往部门", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.m_objViewer.m_txtFromDept.Focus();
                    return -1;
                }
                DataRow[] drNew = m_objViewer.m_dtOutStorageMedicine.Select("MEDICINEID_CHR IS NOT NULL AND OPAMOUNT_INT IS NOT NULL");
                if (drNew == null || drNew.Length == 0)
                {
                    MessageBox.Show("填写出库数量后，请在数字处按回车键，选择具体批号的药品", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                clsDS_Outstorage_Detail[] objDetailArr = m_objGetDetailArr(drNew, objMain.m_lngSERIESID_INT);

                string strMedicineName = string.Empty;

                if (blnIsAddNew)
                {
                    lngRes = m_objDomain.m_lngAddNewOutstorageInfo(ref objMain, ref objDetailArr, m_objViewer.m_intCommitFolow, m_objViewer.LoginInfo.m_strEmpID, out strMedicineName);
                }
                else
                {   
                    //zhenwei.yang添加药品不属于新制不可修改
                    if (objMain.m_lngSERIESID_INT != 0)
                    {
                        long lngRt = this.m_objDomain.m_lngQueryMedOutStoreState(objMain.m_lngSERIESID_INT.ToString(), 0, out strState);
                        if (strState != "1")//0-作废，1--新制，2-审核，3--入帐
                        {
                            MessageBox.Show("药品出库单据已改变,无法修改！", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                    }
                    //获取保存前出库明细的数量
                    //clsDS_UpdateStorageBySeriesID_VO[] m_objForUpdateArr;
                    //m_objDomain.m_lngGetDetailForUpdate(objMain.m_lngSERIESID_INT, 0, out m_objForUpdateArr);
                    //lngRes = m_objDomain.m_lngUpdateOutStorageInfo(objMain, m_objForUpdateArr, ref objDetailArr,m_objViewer.m_intCommitFolow, m_objViewer.LoginInfo.m_strEmpID);

                    lngRes = m_objDomain.m_lngModifyOutStoreAndStore(this.m_objViewer.m_txtBillId.Text, ref objDetailArr);

                }

                if (lngRes > 0)
                {
                    m_objViewer.m_lngMainSEQ = objMain.m_lngSERIESID_INT;
                    m_objViewer.m_txtBillId.Text = objMain.m_strOUTDRUGSTOREID_VCHR;
                    m_objCurrentMain = objMain;
                    m_objCurrentSubArr = objDetailArr;
                    m_objViewer.m_strOriginalDept = m_objViewer.m_txtFromDept.AccessibleName;
                   
                    m_mthSetSeriesIDToUI(objDetailArr);

                    #region 去除空行
                    DataRow[] drNull = m_objViewer.m_dtOutStorageMedicine.Select("OPAMOUNT_INT IS  NULL");
                    if (drNull != null && drNull.Length > 0)
                    {
                        foreach (DataRow drDel in drNull)
                        {
                            m_objViewer.m_dtOutStorageMedicine.Rows.Remove(drDel);
                        }
                    }
                    #endregion

                    m_objViewer.m_dtOutStorageMedicine.AcceptChanges();

                    if (m_objViewer.m_intCommitFolow == 1)
                    {
                        m_objCurrentMain.m_intSTATUS = 2;
                        m_objViewer.m_btnInsert.Enabled = false;
                        m_objViewer.m_btnImpRecipeData.Enabled = false;
                        //m_objViewer.m_btnNext.Enabled = false;
                        //m_objViewer.m_btnSave.Enabled = false;
                        m_objViewer.m_btnDelete.Enabled = false;
                        m_objViewer.m_dgvDetail.Columns[1].ReadOnly = true;
                        m_objViewer.m_dgvDetail.Columns[7].ReadOnly = true;
                        m_objViewer.m_dgvDetail.Columns["rejectreason"].ReadOnly = true;
//                        m_objViewer.m_dgvDetail.ReadOnly = true;
                        m_objViewer.m_txtComment.ReadOnly = true;
                        m_objViewer.m_blnIsCommit = true;
                        m_objViewer.m_intEditStatus = 2;
                    }
                    if (p_blnWantHint)
                    {
                        if (blnIsAddNew)
                        {
                            this.m_objViewer.m_objOutstorageList.Add(m_objCurrentMain);
                        }
                        else
                        {
                            foreach (clsDS_OutStorage_VO var in m_objViewer.m_objOutstorageList)
                            {
                                if (var.m_lngSERIESID_INT == m_objCurrentMain.m_lngSERIESID_INT)
                                {
                                    m_objViewer.m_objOutstorageList.Remove(var);
                                    break;
                                }
                            }
                            this.m_objViewer.m_objOutstorageList.Add(m_objCurrentMain);
                        }
                        MessageBox.Show(blnIsAddNew ? "保存成功！" : "修改成功！", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (m_objCurrentMain != null)
                        m_objCurrentMain.m_intSTATUS = 1;
                    MessageBox.Show("保存失败！\n"+strMedicineName+"可用库存不足扣减", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }


            }
            catch (Exception Ex)
            {
                if (m_objCurrentMain != null)
                    m_objCurrentMain.m_intSTATUS = 1;
                MessageBox.Show("保存失败" + Environment.NewLine + Ex.Message,"药房出库制单",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return -1;
            }
            return lngRes;
        }
        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <returns></returns>
        private clsDS_OutStorage_VO m_objGetMainISVO()
        {
            bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;
            if (m_objCurrentMain == null || blnIsAddNew == true)
            {
                m_objCurrentMain = new clsDS_OutStorage_VO();
                m_objCurrentMain.m_datMAKEORDER_DAT = clsPub.ServerDateTimeNow;//Convert.ToDateTime(this.m_objViewer.m_datMakeDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objCurrentMain.m_intSTATUS =m_objViewer.m_intCommitFolow==1?2:1;
            }
            //switch (this.m_objViewer.m_cboStatus.Text.Trim())
            //{
            //    case "病人发药": m_objCurrentMain.m_intFORMTYPE_INT = 1; break;
            //    case "药房退药库": m_objCurrentMain.m_intFORMTYPE_INT = 2; break;
            //    case "盘亏": m_objCurrentMain.m_intFORMTYPE_INT = 3; break;
            //    case "报废": m_objCurrentMain.m_intFORMTYPE_INT = 4; break;
            //    case "药品出库": m_objCurrentMain.m_intFORMTYPE_INT = 5; break;
            //    case "药房借调": m_objCurrentMain.m_intFORMTYPE_INT = 6; break;
            //    default: m_objCurrentMain.m_intFORMTYPE_INT = -1; break;
            //}
            //单据类型，1、药房自身出库（申请部门是本药房），2、药房借调（申请部门是其它药房），3、科室出库（申请部门除药房外的其它部门），4、盘亏
            string strMedStoreID = string.Empty;
            if (m_objViewer.m_cboMedStore.SelectItemValue != "")
            {
                strMedStoreID = m_objViewer.m_cboMedStore.SelectItemValue != string.Empty ? m_objViewer.m_cboMedStore.SelectItemValue : m_objViewer.m_cboMedStore.AccessibleName;
            }
            string m_strDeptCode = "";
            if (m_objViewer.m_txtFromDept.Text.Trim() != "")
            {
                m_strDeptCode = m_objViewer.m_txtFromDept.AccessibleName;
            }
            if (strMedStoreID == m_strDeptCode)
            {
                this.m_objCurrentMain.m_intFORMTYPE_INT =1;
            }
            else if (this.m_objViewer.frmMain.m_dtMedStoreInfo != null)
            {
                int m_intRowsCount = this.m_objViewer.frmMain.m_dtMedStoreInfo.Rows.Count;
                DataRow dr;
                for (int i = 0; i < m_intRowsCount; i++)
                {
                    dr = this.m_objViewer.frmMain.m_dtMedStoreInfo.Rows[i];
                    if (dr["deptid_chr"].ToString() == m_strDeptCode)
                    {
                        this.m_objCurrentMain.m_intFORMTYPE_INT = 2;
                        break;
                    }
                    if (i == m_intRowsCount - 1)
                        this.m_objCurrentMain.m_intFORMTYPE_INT = 3;

                }
            }
            else
            {
                this.m_objCurrentMain.m_intFORMTYPE_INT = 3;
            }
          //  m_objCurrentMain.m_intFORMTYPE_INT = 1;
            m_objCurrentMain.m_strTYPECODE_VCHR = m_objViewer.m_cboStatus.AccessibleName;
            m_objCurrentMain.m_strTYPENAME_VCHR = m_objViewer.m_cboStatus.SelectItemText;
            m_objCurrentMain.m_lngSERIESID_INT = this.m_objViewer.m_lngMainSEQ;
            m_objCurrentMain.m_strMAKERID_CHR = this.m_objViewer.m_txtMaker.Tag.ToString();
            m_objCurrentMain.m_strMakeName = this.m_objViewer.m_txtMaker.Text.Trim();
            m_objCurrentMain.m_strINSTOREDEPT_CHR = m_strDeptCode;
            m_objCurrentMain.m_strINSTOREDEPTName_CHR = m_objViewer.m_txtFromDept.Text;
            m_objCurrentMain.m_strDRUGSTOREID_CHR = strMedStoreID;
            m_objCurrentMain.m_strDRUGSTOREName = m_objViewer.m_cboMedStore.Text;
            m_objCurrentMain.m_strCOMMENT_VCHR = m_objViewer.m_txtComment.Text;
            m_objCurrentMain.m_strOUTDRUGSTOREID_VCHR = this.m_objViewer.m_txtBillId.Text;
            if (this.m_objViewer.m_intCommitFolow == 1)
            {
                m_objCurrentMain.m_strEXAMName = this.m_objViewer.LoginInfo.m_strEmpName;
                m_objCurrentMain.m_strEXAMID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
                m_objCurrentMain.m_datEXAM_DATE = clsPub.ServerDateTimeNow;
            }
            return m_objCurrentMain;
        }
        #endregion

        #region 获取子表内容
        /// <summary>
        ///  获取子表内容
        /// </summary>
        /// <param name="p_drDetail"></param>
        /// <param name="p_lngMainSEQ"></param>
        /// <returns></returns>
        private clsDS_Outstorage_Detail[] m_objGetDetailArr(DataRow[] p_drDetail, long p_lngMainSEQ)
        {
            clsDS_Outstorage_Detail[] objDetailArr = null;
            if (p_drDetail == null || p_drDetail.Length == 0)
            {
                return null;
            }
            objDetailArr = new clsDS_Outstorage_Detail[p_drDetail.Length];
            for (int iRow = 0; iRow < p_drDetail.Length; iRow++)
            {
                objDetailArr[iRow] = new clsDS_Outstorage_Detail();
                if (p_drDetail[iRow]["SERIESID_INT"] != System.DBNull.Value)
                {
                    objDetailArr[iRow].m_lngSERIESID_INT = long.Parse(p_drDetail[iRow]["SERIESID_INT"].ToString());
                }
                else
                {
                    objDetailArr[iRow].m_lngSERIESID_INT = -1;
                }
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = p_drDetail[iRow]["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strMedicineTypeid = p_drDetail[iRow]["medicinetypeid_chr"].ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCHR = p_drDetail[iRow]["MEDICINENAME_VCHR"].ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR = p_drDetail[iRow]["MEDSPEC_VCHR"].ToString();
                objDetailArr[iRow].m_strOPUNIT_CHR = p_drDetail[iRow]["OPUNIT_CHR"].ToString();
                objDetailArr[iRow].m_strIPUNIT_CHR = p_drDetail[iRow]["IPUNIT_CHR"].ToString();
                
                objDetailArr[iRow].m_dblOPAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["OPAMOUNT_INT"]);                
                objDetailArr[iRow].m_dblIPAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["IPAMOUNT_INT"]);

                objDetailArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(p_drDetail[iRow]["PACKQTY_DEC"]);
                if (Convert.ToString(p_drDetail[iRow]["VALIDPERIOD_DAT"]).Length > 0 && Convert.ToDateTime(p_drDetail[iRow]["VALIDPERIOD_DAT"]).ToString("yyyy-MM-dd") != "0001-01-01")
                    objDetailArr[iRow].m_datVALIDPERIOD_DAT = Convert.ToDateTime(p_drDetail[iRow]["VALIDPERIOD_DAT"].ToString());
                objDetailArr[iRow].m_strLOTNO_VCHR = p_drDetail[iRow]["LOTNO_VCHR"].ToString();

                objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(p_drDetail[iRow]["OPWHOLESALEPRICE_INT"]);
                objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(p_drDetail[iRow]["IPWHOLESALEPRICE_INT"]);
                objDetailArr[iRow].m_dblOPRETAILPRICE_INT = Convert.ToDouble(p_drDetail[iRow]["OPRETAILPRICE_INT"]);
                objDetailArr[iRow].m_dblIPRETAILPRICE_INT = Convert.ToDouble(p_drDetail[iRow]["IPRETAILPRICE_INT"]);
                objDetailArr[iRow].m_intSTATUS = 1;
                objDetailArr[iRow].m_strRejectReason = p_drDetail[iRow]["REJECTREASON"].ToString();
                objDetailArr[iRow].m_intSTORAGESERIESID_CHR = p_drDetail[iRow]["storageseriesid_chr"].ToString();
                objDetailArr[iRow].m_strPRODUCTORID_CHR = p_drDetail[iRow]["productorid_chr"].ToString();
                objDetailArr[iRow].m_strInStorageid = p_drDetail[iRow]["INSTOREID_VCHR"].ToString();
                objDetailArr[iRow].m_strDSInStorageid = p_drDetail[iRow]["DSINSTOREID_VCHR"].ToString();
                if (Convert.ToString(p_drDetail[iRow]["instoragedate_dat"]).Length != 0 && Convert.ToDateTime(p_drDetail[iRow]["instoragedate_dat"]).ToString("yyyy-MM-dd") != "0001-01-01")
                {
                   objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(p_drDetail[iRow]["instoragedate_dat"]);                    
                }
                
            }
            return objDetailArr;
        }
        #endregion
        /// <summary>
        /// 更新界面数据的序列号
        /// </summary>
        /// <param name="p_objDetailArr"></param>
        private void m_mthSetSeriesIDToUI(clsDS_Outstorage_Detail[] p_objDetailArr)
        {
            if (m_objViewer.m_dtOutStorageMedicine != null && m_objViewer.m_dtOutStorageMedicine.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < m_objViewer.m_dtOutStorageMedicine.Rows.Count; iRow++)
                {
                    if (iRow < p_objDetailArr.Length)
                    {
                        m_objViewer.m_dtOutStorageMedicine.Rows[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        m_objViewer.m_dtOutStorageMedicine.Rows[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                    }
                }
            }

        }
        #endregion

        #region 删除药房出库明细
        /// <summary>
        /// 删除药房出库明细
        /// </summary>
        /// <returns></returns>
        internal void m_mthDeleteDetail(bool p_blnWantHint)
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS != 1 && m_objCurrentMain.m_intSTATUS != 0 && p_blnWantHint)
            {
                if (m_objCurrentMain.m_intSTATUS == 2)
                {
                    MessageBox.Show("该药房出库单记录已审核，不能修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (m_objCurrentMain.m_intSTATUS == 3)
                {
                    MessageBox.Show("该药房出库单记录已入帐，不能修改", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (m_objViewer.m_dgvDetail.SelectedCells.Count == 0)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvDetail.SelectedCells[0].RowIndex;
            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvDetail.CurrentCell.OwningRow.DataBoundItem).Row;

            long lngSEQ = 0;
            if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngSEQ))
            {
                //zhenwei.yang添加药品不属于新制不可修改
                if (lngSEQ > 0)
                {
                    string strState = null;
                    long lngRt = this.m_objDomain.m_lngQueryMedOutStoreState(lngSEQ.ToString(), 1, out strState);
                    if (strState != "1")//0-作废，1--新制，2-审核，3--入帐
                    {
                        MessageBox.Show("药品出库单据已改变,无法修改！", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                if (lngSEQ > 0)
                {
                    long lngRes = m_objDomain.m_lngDelOutstorageDetail(lngSEQ);
                    if (lngRes > 0)
                    {
                        if (m_objCurrentSubArr != null)
                        {
                            List<clsDS_Outstorage_Detail> lstDetail = new List<clsDS_Outstorage_Detail>();
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

                        m_objViewer.m_dtOutStorageMedicine.Rows.Remove(drCurrent);
                        m_objViewer.m_mthShowRetailMoney();
                        MessageBox.Show("删除成功", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        if (lngRes == -11)
                        {
                            MessageBox.Show("删除失败,药品单据状态已改变,请重新加载数据", "药房出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }                 
                    }
                }
                else
                {
                    m_objViewer.m_dtOutStorageMedicine.Rows.Remove(drCurrent);
                }
            }
            else
            {
                m_objViewer.m_dtOutStorageMedicine.Rows.Remove(drCurrent);
            }
        }
        #endregion

        #region 清空界面
        /// <summary>
        /// 清空界面
        /// </summary>
        internal void m_mthClear()
        {
            m_objViewer.IsCanModify = true;
            m_objViewer.m_datValidPeriod.Visible = false;
            m_objViewer.m_dtOutStorageMedicine.Rows.Clear();
            //m_objViewer.m_cboStatus.SelectedIndex = -1;
            m_objViewer.m_cboStatus.AccessibleName = m_objViewer.m_strDefaultTypeID;
            if (m_objViewer.m_blnIsHospital)
            {
                m_objViewer.m_cboStatus.Text = "发放出库";
            }
            else
            {
                m_objViewer.m_cboStatus.Text = "领药出库";
            }
            m_objViewer.m_txtFromDept.Clear();
            m_objViewer.m_txtComment.Clear();
            m_objViewer.m_txtBillId.Clear();
            m_objViewer.m_lngMainSEQ = 0;
            m_objViewer.m_datMakeDate.Value = clsPub.CurrentDateTimeNow;
            m_objCurrentMain = null;
            m_objCurrentSubArr = null;
            m_objViewer.m_txtComment.ReadOnly = false;
            m_objViewer.m_blnIsCommit = false;
            m_objViewer.m_intEditStatus = 1;
            m_objViewer.m_btnSave.Enabled = true;
            m_objViewer.m_btnInsert.Enabled = true;
            m_objViewer.m_btnImpRecipeData.Enabled = true;
            m_objViewer.m_btnDelete.Enabled = true;
            m_objViewer.m_txtMaker.Tag = m_objViewer.LoginInfo.m_strEmpID;
            m_objViewer.m_txtMaker.Text = m_objViewer.LoginInfo.m_strEmpName;
            m_objViewer.m_dgvDetail.Columns[1].ReadOnly = false;
            m_objViewer.m_dgvDetail.Columns[7].ReadOnly = false;
            m_objViewer.m_dgvDetail.Columns["rejectreason"].ReadOnly = false;
            m_mthInsertNewMedicineInfo();
        }
        #endregion

        #region 显示出库药品选择窗体
        /*
        /// <summary>
        /// 显示出库药品选择窗体
        /// </summary>
        /// <param name="p_strAmount"></param>
        internal long m_lngShowMedicineSelect(string p_strAmount)
        {
            int intRowsCount = m_objViewer.m_dtOutStorageMedicine.Rows.Count;


            if (intRowsCount > 0)//去除空行
            {
                DataRow[] drNull = m_objViewer.m_dtOutStorageMedicine.Select(" MEDICINEID_CHR is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_objViewer.m_dtOutStorageMedicine.Rows.Remove(drTemp);
                    }
                }
            }

            double dblAmount = 0d;
            if (!double.TryParse(p_strAmount, out dblAmount))
            {
                MessageBox.Show("数量不能为空且必须为数字", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            //else
            //{
            //    if (dblAmount <= 0)
            //    {
            //        MessageBox.Show("数量必须大于零", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return -1;
            //    }
            //}

            if (m_objViewer.m_dgvDetail.CurrentCell == null || m_objViewer.m_dtOutStorageMedicine == null)
            {
                return -1;
            }

            int intCurrentRow = m_objViewer.m_dgvDetail.CurrentCell.RowIndex;
            DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvDetail.CurrentCell.OwningRow.DataBoundItem)).Row;
            string strMedicineID = drCurrent["MEDICINEID_CHR"].ToString();
            clsDS_StorageDetail_VO[] objDetail = null;
            Hashtable hstPeriod = null;
            Hashtable hstCurrent = null;
            long lngRes = 0;

            //检查本出库单之前是否已录入相同药品
            DataRowView dtvTemp = null;
            long lngSeriesID = 0;
            for (int iRow = 0; iRow < m_objViewer.m_dgvDetail.Rows.Count; iRow++)
            {
                if (m_objViewer.m_dgvDetail.Rows[iRow].DataBoundItem == null) continue;
                dtvTemp = m_objViewer.m_dgvDetail.Rows[iRow].DataBoundItem as DataRowView;
                if (dtvTemp["MEDICINEID_CHR"].ToString() == strMedicineID && iRow != intCurrentRow)
                {
                    //DialogResult drQ = MessageBox.Show("本出库单已录入此药品，详见第" + (iRow + 1).ToString() + "行，是否合并？", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    //if (drQ == DialogResult.No)
                    //{
                    //    return -1;
                    //}
                    //else//合并
                    //{
                        long.TryParse(dtvTemp["SERIESID_INT"].ToString(), out lngSeriesID);
                        //dblAmount = 0;
                        DataRowView dtvTmp = null;
                        hstPeriod = new Hashtable();
                        double dblTemp = 0d;

                        long lngSidTemp = 0;
                        for (int i1 = 0; i1 < m_objViewer.m_dgvDetail.Rows.Count; i1++)
                        {
                            if (m_objViewer.m_dgvDetail.Rows[i1].DataBoundItem == null) continue;
                            dtvTmp = m_objViewer.m_dgvDetail.Rows[i1].DataBoundItem as DataRowView;
                            if (dtvTmp["MEDICINEID_CHR"].ToString() == strMedicineID && i1 != intCurrentRow)
                            {
                                //if (i1 == iRow)
                                //{
                                //    double.TryParse(Convert.ToString(m_objViewer.m_dgvDetail["m_dgvtxtInAmount", intCurrentRow].Value), out dblTemp);
                                //    hstPeriod.Add(dtvTmp["LOTNO_VCHR"].ToString() + dtvTmp["storageseriesid_chr"].ToString(), Convert.ToDouble(dtvTmp["IPAMOUNT_INT"]) + dblTemp);
                                //}
                                //else
                                //    hstPeriod.Add(dtvTmp["LOTNO_VCHR"].ToString() + dtvTmp["storageseriesid_chr"].ToString(), Convert.ToDouble(dtvTmp["IPAMOUNT_INT"]));
                                if (long.TryParse(dtvTmp["storageseriesid_chr"].ToString(), out lngSidTemp))
                                {
                                    if (hstPeriod.ContainsKey(lngSidTemp))
                                    {
                                        hstPeriod[lngSidTemp] = Convert.ToDouble(hstPeriod[lngSidTemp]) + Convert.ToDouble(dtvTmp["IPAMOUNT_INT"]);
                                    }
                                    else
                                    {
                                        hstPeriod.Add(lngSidTemp, Convert.ToDouble(dtvTmp["IPAMOUNT_INT"]));
                                    }
                                }
                            }
                        }
                        break;
                    //}                   
                }
                else if (dtvTemp["MEDICINEID_CHR"].ToString() == strMedicineID && iRow == intCurrentRow)
                {
                    Int64 intTemp = 0;
                    if (Int64.TryParse(dtvTemp["storageseriesid_chr"].ToString(), out intTemp))
                    {
                        hstCurrent = new Hashtable();
                        hstCurrent.Add(intTemp, Convert.ToDouble(dtvTemp["IPAMOUNT_INT"]));
                    }
                }
            }

            DataRow[] drOld = m_objViewer.m_dtOutStorageMedicine.Select("MEDICINEID_CHR = '" + strMedicineID + "'");

            Hashtable hstNetAmount = new Hashtable();
            bool blnHasMain = false;//是否已有旧记录，即当前是否处于修改状态
            if (m_objViewer.m_txtBillId.Text != "")
            {
                blnHasMain = true;
            }

            if (m_objViewer.m_strStoreid == "")
                m_objViewer.m_strStoreid = m_objViewer.m_cboMedStore.AccessibleName;
            if (m_objViewer.m_strStoreid == "")
            {
                MessageBox.Show("请先选择药房！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            lngRes = ((clsDcl_OutStorageMakerOrder)m_objDomain).m_lngGetStoreMedicineDetail(strMedicineID, m_objViewer.m_strStoreid, out objDetail);
            //获取当前行所占用的可用库存
            //clsDS_UpdateStorageBySeriesID_VO[] objForUpdateArr = new clsDS_UpdateStorageBySeriesID_VO[m_objViewer.m_dgvDetail.Rows.Count];
            //long lngSerieID = 0;
            //for (int iRow = 0; iRow < m_objViewer.m_dgvDetail.Rows.Count; iRow++)
            //{
            //    if (m_objViewer.m_dgvDetail.Rows[iRow].DataBoundItem == null) continue;
            //    dtvTemp = m_objViewer.m_dgvDetail.Rows[iRow].DataBoundItem as DataRowView;
            //    long.TryParse(dtvTemp["SERIESID_INT"].ToString(), out lngSerieID);
            //    if (lngSerieID > 0)
            //    {
            //        objForUpdateArr[iRow] = new clsDS_UpdateStorageBySeriesID_VO();
            //        objForUpdateArr[iRow].m_dblIPAvalid = Convert.ToDouble(dtvTemp["IPAMOUNT_INT"]);
            //        objForUpdateArr[iRow].m_intSeriesID = Convert.ToInt64(dtvTemp["storageseriesid_chr"]);
            //    }
            //}
            double dblAllRealGross = 0d;//总实际库存
            double dblAllAvaGross = 0d;//总可用库存

            if (objDetail != null && objDetail.Length > 0)
            {
                for (int iGro = 0; iGro < objDetail.Length; iGro++)
                {
                    dblAllAvaGross += objDetail[iGro].m_dblIPAVAILABLEGROSS_NUM;
                    dblAllRealGross += objDetail[iGro].m_dblIPREALGROSS_INT;
                }

                //if (blnHasMain)//当前处于修改状态
                //{
                //    lngRes = m_objDomain.m_lngGetIPAmount(m_objViewer.m_lngMainSEQ, strMedicineID, out hstNetAmount);

                //    if (drOld != null && drOld.Length > 0)
                //    {
                //        dblAmount = 0d;
                //        double dblTemp = 0d;
                //        for (int iOld = 0; iOld < drOld.Length; iOld++)
                //        {
                //            if (double.TryParse(drOld[iOld]["AMOUNT_INT"].ToString(), out dblTemp))
                //            {
                //                dblAmount += dblTemp;

                //                if (drOld[iOld]["VALIDPERIOD_DAT"] == DBNull.Value)
                //                {
                //                    continue;
                //                }
                //                string strKey = drOld[iOld]["lotno_vchr"].ToString().PadLeft(10, '0') + drOld[iOld]["instoreid_vchr"].ToString()
                //                    + Convert.ToDateTime(drOld[iOld]["VALIDPERIOD_DAT"]).ToString("yyyy-MM-dd HH:mm:ss");

                //                if (blnHasMain && hstNetAmount.Contains(strKey))
                //                {
                //                    double dblTempAmount = 0d;
                //                    if (double.TryParse(hstNetAmount[strKey].ToString(), out dblTempAmount))
                //                    {
                //                        for (int iSD = 0; iSD < objDetail.Length; iSD++)
                //                        {
                //                            if (drOld[iOld]["lotno_vchr"].ToString() == objDetail[iSD].m_strLOTNO_VCHR && drOld[iOld]["instoreid_vchr"].ToString() == objDetail[iSD].m_strINSTOREID_VCHR
                //                                && Convert.ToDateTime(drOld[iOld]["VALIDPERIOD_DAT"]) == objDetail[iSD].m_dtmVALIDPERIOD_DAT)
                //                            {
                //                                objDetail[iSD].m_dblIPAVAILABLEGROSS_NUM += dblTempAmount;
                //                                break;
                //                            }
                //                        }
                //                        //lngRes = objSTDomain.m_lngAddStorageDetailAvailaGross(dblTempAmount, drCurrent["MEDICINEID_CHR"].ToString(), drCurrent["LOTNO_VCHR"].ToString(), drCurrent["INSTORAGEID_VCHR"].ToString(), m_objViewer.m_strStorageID);
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}

                if (lngSeriesID == 0)
                {
                    if (m_objViewer.m_dgvDetail.Rows[m_objViewer.m_dgvDetail.CurrentCell.RowIndex].DataBoundItem != null)
                    {
                        DataRowView dtvTmp = m_objViewer.m_dgvDetail.Rows[m_objViewer.m_dgvDetail.CurrentCell.RowIndex].DataBoundItem as DataRowView;
                        long.TryParse(dtvTmp["SERIESID_INT"].ToString(), out lngSeriesID);
                    }
                }

                //20090119：库存不足时，提示是否要出库
                if (dblAllAvaGross < dblAmount)
                {
                    if (MessageBox.Show("可用库存不足出库，是否继续？", "温馨提示...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return -1;
                }
                frmQueryMedicine frmQMI = new frmQueryMedicine(dblAmount);
                frmQMI.m_blnIsHospital = m_objViewer.m_blnIsHospital;
                frmQMI.m_mthSetMedicineVO(objDetail, hstPeriod, hstCurrent);
                frmQMI.m_lngSeriesID = lngSeriesID;
                frmQMI.m_dgvQueryMedicineInfo.Focus();
                frmQMI.ShowDialog();

                if (frmQMI.DialogResult == DialogResult.OK)
                {
                    //int intFirstRowIndex = 0;//所选药品第一行在DataTable中的索引
                    //if (drOld != null && drOld.Length > 0)
                    //{
                    //    //for (int iRow = m_objViewer.m_dtOutStorageMedicine.Rows.Count -1; iRow > 0; iRow--)
                    //    //{
                    //    //    if (strMedicineID == m_objViewer.m_dtOutStorageMedicine.Rows[iRow]["MEDICINEID_CHR"].ToString())
                    //    //    {
                    //    //        intFirstRowIndex = iRow;
                    //    //        break;
                    //    //    }
                    //    //}
                    //    //if (drOld[0]["oldgross_int"] != DBNull.Value)
                    //    //{
                    //    //    dblOldGross = Convert.ToDouble(drOld[0]["oldgross_int"]);
                    //    //}
                    //    //foreach (DataRow drC in drOld)
                    //    //{
                    //    //    m_objViewer.m_dtOutStorageMedicine.Rows.Remove(drC);
                    //    //}
                    //}


                    m_objViewer.m_dtOutStorageMedicine.Rows.RemoveAt(intCurrentRow);
                    clsDS_StorageMedicineShow[] objValue = frmQMI.m_ObjOutMedicinArr;
                    m_mthSetOutMedicineVOToTable(objValue, dblAllRealGross, dblAllAvaGross);//, intFirstRowIndex);
                    lngRes = 1;
                }
                else
                {
                    return -1;
                }
                
            }
            else
            {
                MessageBox.Show("没有当前选择药品库存信息", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;
            }
            return lngRes;
        }

        #region 设置出库药品信息至界面
        /// <summary>
        /// 设置出库药品信息至界面
        /// </summary>
        /// <param name="p_objValue">出库药品信息</param>
        /// <param name="p_dblAllRealGross">总实际库存</param>
        /// <param name="p_dblAllAvaGross">总可用库存</param>        
        internal void m_mthSetOutMedicineVOToTable(clsDS_StorageMedicineShow[] p_objValue, double p_dblAllRealGross, double p_dblAllAvaGross)//, int p_intFirstRowIndex)
        {            
            if (p_objValue == null || p_objValue.Length == 0)
            {
                return;
            }

            int intRowsCount = m_objViewer.m_dtOutStorageMedicine.Rows.Count;

            
            if (intRowsCount > 0)//去除空行
            {
                DataRow[] drNull = m_objViewer.m_dtOutStorageMedicine.Select(" ipavailablegross_num is null");
                //DataRow[] drNull = m_objViewer.m_dtOutStorageMedicine.Select(" iprealgross_int is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_objViewer.m_dtOutStorageMedicine.Rows.Remove(drTemp);
                    }
                }
            }

           
            for (int iRow = 0; iRow < p_objValue.Length; iRow++)
            {
                DataRow drNew = m_objViewer.m_dtOutStorageMedicine.NewRow();
                m_mthAddDataToRow(drNew, p_objValue[iRow], p_dblAllRealGross, p_dblAllAvaGross);
                m_objViewer.m_dtOutStorageMedicine.Rows.Add(drNew);//.InsertAt(drNew, p_intFirstRowIndex);//要将新行插入至指定位置

               // p_intFirstRowIndex++;                
            }
            //m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail[6, p_intFirstRowIndex];
        }

        /// <summary>
        /// 添加数据至指定行
        /// </summary>
        /// <param name="p_drRow">数据行</param>
        /// <param name="p_objValue">出库药品信息</param>
        /// <param name="p_dblAllRealGross">总实际库存</param>
        /// <param name="p_dblAllAvaGross">总可用库存</param>
        private void m_mthAddDataToRow(DataRow p_drRow, clsDS_StorageMedicineShow p_objValue, double p_dblAllRealGross, double p_dblAllAvaGross)
        {
            if (p_drRow == null || p_objValue == null)
            {
                return;
            }

            p_drRow["MEDICINEID_CHR"] = p_objValue.m_strMEDICINEID_CHR;
            p_drRow["MEDICINENAME_VCHR"] = p_objValue.m_strMEDICINENAME_VCHR;
            p_drRow["MEDSPEC_VCHR"] = p_objValue.m_strMEDSPEC_VCHR;
            p_drRow["OPUNIT_CHR"] = p_objValue.m_strOPUNIT_VCHR;
            p_drRow["OPAMOUNT_INT"] = p_objValue.m_dblOutAmount.ToString("0.00");
            p_drRow["LOTNO_VCHR"] = p_objValue.m_strLOTNO_VCHR;
            p_drRow["INSTOREID_VCHR"] = p_objValue.m_strINSTOREID_VCHR;
            p_drRow["DSINSTOREID_VCHR"] = p_objValue.m_strDSINSTOREID_VCHR;
            p_drRow["OPWHOLESALEPRICE_INT"] = p_objValue.m_dcmOPWHOLESALEPRICE_INT.ToString("0.0000");
            p_drRow["OPRETAILPRICE_INT"] = p_objValue.m_dcmOPRETAILPRICE_INT.ToString("0.0000");
            p_drRow["instoragedate_dat"] = p_objValue.m_dtmINSTOREDATE_DAT.ToString("yyyy-MM-dd");
            if (p_objValue.m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd") == "0001-01-01")
            {
                p_drRow["validperiod_dat"] = DBNull.Value;
            }
            else
            {
                p_drRow["validperiod_dat"] = p_objValue.m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd");
            }
            p_drRow["oprealgross_int"] = p_objValue.m_dblOPREALGROSS_INT.ToString("0.00");
            p_drRow["assistcode_chr"] = p_objValue.m_strASSISTCODE_CHR;
            p_drRow["opavailagross_int"] = p_objValue.m_dblOPAVAILAGROSS_INT.ToString("0.00");
            //p_drRow["allrealgross"] = p_dblAllRealGross.ToString("0.00");
            //p_drRow["allavagross"] = p_dblAllAvaGross.ToString("0.00");
            p_drRow["medicinetypeid_chr"] = p_objValue.m_strMedicineTypeID_CHR;
            //p_drRow["oldgross_int"] = p_dblOldGross;
            p_drRow["ipunit_chr"] = p_objValue.m_strIPUNIT_VCHR;
            p_drRow["packqty_dec"] = p_objValue.m_dblPACKQTY_DEC;
            p_drRow["seriesid_int"] = p_objValue.m_lngSERIESID_INT;
            p_drRow["storageseriesid_chr"] = p_objValue.m_strStorageseriesid_chr;
            p_drRow["ipretailprice_int"] = p_objValue.m_dcmIPRETAILPRICE_INT;
            p_drRow["ipwholesaleprice_int"] = p_objValue.m_dcmIPWHOLESALEPRICE_INT;
            p_drRow["iprealgross_int"] = p_objValue.m_dblIPREALGROSS_INT;
            p_drRow["ipavailablegross_num"] = p_objValue.m_dblIPAVAILAGROSS_INT;            
            p_drRow["productorid_chr"] = p_objValue.m_strPRODUCTORID_CHR;
            p_drRow["opchargeflg_int"] = p_objValue.m_dblOPCHARGEFLG_INT;
            p_drRow["ipchargeflg_int"] = p_objValue.m_dblIPCHARGEFLG_INT;  
            p_drRow["AMOUNT_INT"] = p_objValue.m_dblChargeAmount.ToString("0.00");
            if (m_objViewer.m_blnIsHospital)
            {
                if (p_objValue.m_dblIPCHARGEFLG_INT == 0)
                {
                    p_drRow["IPAMOUNT_INT"] = p_objValue.m_dblChargeAmount * p_objValue.m_dblPACKQTY_DEC;
                    p_drRow["UNIT_CHR"] = p_objValue.m_strOPUNIT_VCHR;
                    p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmOPWHOLESALEPRICE_INT.ToString("0.0000");
                    p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmOPRETAILPRICE_INT.ToString("0.0000");
                }
                else
                {
                    p_drRow["IPAMOUNT_INT"] = p_objValue.m_dblChargeAmount.ToString("0.00");
                    p_drRow["UNIT_CHR"] = p_objValue.m_strIPUNIT_VCHR;
                    p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmIPWHOLESALEPRICE_INT.ToString("0.0000");
                    p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmIPRETAILPRICE_INT.ToString("0.0000");
                }
            }
            else
            {
                if (p_objValue.m_dblOPCHARGEFLG_INT == 0)
                {
                    p_drRow["IPAMOUNT_INT"] = p_objValue.m_dblChargeAmount * p_objValue.m_dblPACKQTY_DEC;
                    p_drRow["UNIT_CHR"] = p_objValue.m_strOPUNIT_VCHR;
                    p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmOPWHOLESALEPRICE_INT.ToString("0.0000");
                    p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmOPRETAILPRICE_INT.ToString("0.0000");
                }
                else
                {
                    p_drRow["IPAMOUNT_INT"] = p_objValue.m_dblChargeAmount.ToString("0.00");
                    p_drRow["UNIT_CHR"] = p_objValue.m_strIPUNIT_VCHR;
                    p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmIPWHOLESALEPRICE_INT.ToString("0.0000");
                    p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmIPRETAILPRICE_INT.ToString("0.0000");
                }
            }
            

            p_drRow.EndEdit();
        }
        #endregion*/
        #endregion

        #region 显示出库药品选择窗体(引用三院格式)杨镇伟
        /// <summary>
        /// 显示出库药品选择窗体
        /// </summary>
        /// <param name="p_strAmount"></param>
        internal long m_lngShowMedicineSelect(string p_strAmount)
        {
            int intRowsCount = m_objViewer.m_dtOutStorageMedicine.Rows.Count;


            if (intRowsCount > 0)//去除空行
            {
                DataRow[] drNull = m_objViewer.m_dtOutStorageMedicine.Select(" MEDICINEID_CHR is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_objViewer.m_dtOutStorageMedicine.Rows.Remove(drTemp);
                    }
                }
            }

            double dblAmount = 0d;
            if (!double.TryParse(p_strAmount, out dblAmount))
            {
                MessageBox.Show("数量不能为空且必须为数字", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }

            if (m_objViewer.m_dgvDetail.CurrentCell == null || m_objViewer.m_dtOutStorageMedicine == null)
            {
                return -1;
            }

            int intCurrentRow = m_objViewer.m_dgvDetail.CurrentCell.RowIndex;
            DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvDetail.CurrentCell.OwningRow.DataBoundItem)).Row;
            string strMedicineID = drCurrent["MEDICINEID_CHR"].ToString();
            clsDS_StorageDetail_VO[] objDetail = null;
            Hashtable hstPeriod = new Hashtable(); ;// 新数据
            Hashtable hstCurrent = null;// 旧数据
            string strSeriesID = string.Empty;//已保存的单据，当前行的序列
            double dblTmp = 0;//该行已选择数量。（修改已保存的数据时）
            Hashtable hstGross = new Hashtable();
            long lngRes = 0;

            //检查本出库单之前是否已录入相同药品
            DataRowView dtvTemp = null;
            long lngSeriesID = 0;
            for (int iRow = 0; iRow < m_objViewer.m_dgvDetail.Rows.Count; iRow++)
            {
                if (m_objViewer.m_dgvDetail.Rows[iRow].DataBoundItem == null)
                {
                    continue;
                }

                dtvTemp = m_objViewer.m_dgvDetail.Rows[iRow].DataBoundItem as DataRowView;
                long lngSidTemp = 0;
                if (dtvTemp["MEDICINEID_CHR"].ToString() == strMedicineID)
                {
                    if (dtvTemp["SERIESID_INT"].ToString() == "0" && iRow != intCurrentRow)
                    {
                        if (long.TryParse(dtvTemp["storageseriesid_chr"].ToString(), out lngSidTemp))
                        {
                            if (hstPeriod.ContainsKey(lngSidTemp))
                            {
                                hstPeriod[lngSidTemp] = Convert.ToDouble(hstPeriod[lngSidTemp]) + Convert.ToDouble(dtvTemp["IPAMOUNT_INT"]);
                            }
                            else
                            {
                                hstPeriod.Add(lngSidTemp, Convert.ToDouble(dtvTemp["IPAMOUNT_INT"]));
                            }
                        }
                    }
                    else if (dtvTemp["SERIESID_INT"].ToString() != "0" && iRow == intCurrentRow)
                    {
                        hstGross.Add(dtvTemp["storageseriesid_chr"].ToString() + "*" + dtvTemp["SERIESID_INT"].ToString(), null);
                        strSeriesID = dtvTemp["storageseriesid_chr"].ToString() + "*" + dtvTemp["SERIESID_INT"].ToString();
                    }
                }

                //if(dtvTemp["MEDICINEID_CHR"].ToString() == strMedicineID && iRow != intCurrentRow && dtvTemp["SERIESID_INT"].ToString()=="0")
                //{
                //    long.TryParse(dtvTemp["SERIESID_INT"].ToString(), out lngSeriesID);
                //    DataRowView dtvTmp = null;
                //    hstPeriod = new Hashtable();

                //    long lngSidTemp = 0;
                //    for(int i1 = 0; i1 < m_objViewer.m_dgvDetail.Rows.Count; i1++)
                //    {
                //        if(m_objViewer.m_dgvDetail.Rows[i1].DataBoundItem == null)
                //        {
                //            continue;
                //        }

                //        dtvTmp = m_objViewer.m_dgvDetail.Rows[i1].DataBoundItem as DataRowView;
                //        if(dtvTmp["MEDICINEID_CHR"].ToString() == strMedicineID && i1 != intCurrentRow)
                //        {
                //            if(long.TryParse(dtvTmp["storageseriesid_chr"].ToString(), out lngSidTemp))
                //            {
                //                if(hstPeriod.ContainsKey(lngSidTemp))
                //                {
                //                    hstPeriod[lngSidTemp] = Convert.ToDouble(hstPeriod[lngSidTemp]) + Convert.ToDouble(dtvTmp["IPAMOUNT_INT"]);
                //                }
                //                else
                //                {
                //                    hstPeriod.Add(lngSidTemp, Convert.ToDouble(dtvTmp["IPAMOUNT_INT"]));
                //                }
                //            }
                //        }
                //    }
                //    break;
                //}
                //else if(dtvTemp["MEDICINEID_CHR"].ToString() == strMedicineID && iRow == intCurrentRow)
                //{
                //    Int64 intTemp = 0;
                //    if(Int64.TryParse(dtvTemp["storageseriesid_chr"].ToString(), out intTemp))
                //    {
                //        hstCurrent = new Hashtable();
                //        hstCurrent.Add(intTemp, Convert.ToDouble(dtvTemp["IPAMOUNT_INT"]));
                //    }
                //}
            }

            DataRow[] drOld = m_objViewer.m_dtOutStorageMedicine.Select("MEDICINEID_CHR = '" + strMedicineID + "'");

            Hashtable hstNetAmount = new Hashtable();

            bool blnHasMain = false;//是否已有旧记录，即当前是否处于修改状态
            if (m_objViewer.m_txtBillId.Text != "")
            {
                blnHasMain = true;
            }

            if (m_objViewer.m_strStoreid == "")
            {
                m_objViewer.m_strStoreid = m_objViewer.m_cboMedStore.AccessibleName;
            }
            if (m_objViewer.m_strStoreid == "")
            {
                MessageBox.Show("请先选择药房！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            lngRes = ((clsDcl_OutStorageMakerOrder)m_objDomain).m_lngGetStoreMedicineDetail(strMedicineID, m_objViewer.m_strStoreid, out objDetail);
            double dblAllRealGross = 0d;//总实际库存
            double dblAllAvaGross = 0d;//总可用库存

            Dictionary<string, double> m_gdicNetAmont = null;
            if (objDetail != null && objDetail.Length > 0)
            {
                for (int iGro = 0; iGro < objDetail.Length; iGro++)
                {
                    dblAllAvaGross += objDetail[iGro].m_dblIPAVAILABLEGROSS_NUM;
                    dblAllRealGross += objDetail[iGro].m_dblIPREALGROSS_INT;
                }


                if (blnHasMain)//当前处于修改状态
                {
                    lngRes = m_objDomain.m_lngGetIPAmount(m_objViewer.m_lngMainSEQ, strMedicineID, out hstNetAmount);
                    for (int i1 = 0; i1 < hstNetAmount.Count; i1++)
                    {
                        if (hstNetAmount.ContainsKey(strSeriesID))
                        {
                            dblTmp = Convert.ToDouble(hstNetAmount[strSeriesID]);
                            break;
                        }
                    }

                    if (hstNetAmount != null && hstNetAmount.Count > 0)
                    {
                        m_gdicNetAmont = new Dictionary<string, double>(hstNetAmount.Count);
                        hstCurrent = new Hashtable();
                        if (drOld != null && drOld.Length > 0)
                        {
                            double dblTemp = 0d;
                            for (int iOld = 0; iOld < drOld.Length; iOld++)
                            {
                                if (drOld[iOld]["storageseriesid_chr"].ToString() == "")
                                {
                                    continue;
                                }
                                if (double.TryParse(drOld[iOld]["AMOUNT_INT"].ToString(), out dblTemp))
                                {
                                    string strKey = drOld[iOld]["storageseriesid_chr"].ToString() + "*" + drOld[iOld]["seriesid_int"].ToString();
                                    if (hstGross.ContainsKey(strKey))
                                    {
                                        for (int iSD = 0; iSD < objDetail.Length; iSD++)
                                        {
                                            double dblTempAmount = 0d;
                                            if (double.TryParse(hstNetAmount[strKey].ToString(), out dblTempAmount))
                                            {
                                                if (m_gdicNetAmont.ContainsKey(strKey.Split('*')[0].Trim()))
                                                {
                                                    m_gdicNetAmont[strKey.Split('*')[0].Trim()] += Convert.ToDouble(hstNetAmount[strKey]) * -1;
                                                }
                                                else
                                                {
                                                    m_gdicNetAmont.Add(strKey.Split('*')[0].Trim(), Convert.ToDouble(hstNetAmount[strKey]) * -1);
                                                }

                                                break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (blnHasMain && hstNetAmount.Contains(strKey))
                                        {
                                            double dblTempAmount = 0d;
                                            if (double.TryParse(hstNetAmount[strKey].ToString(), out dblTempAmount))
                                            {
                                                for (int iSD = 0; iSD < objDetail.Length; iSD++)
                                                {
                                                    if (strKey.Split('*')[0].Trim() == objDetail[iSD].m_lngSERIESID_INT.ToString())
                                                    {
                                                        if (dblTemp != Convert.ToDouble(hstNetAmount[strKey]))
                                                        {
                                                            if (m_gdicNetAmont.ContainsKey(strKey.Split('*')[0].Trim()))
                                                            {
                                                                m_gdicNetAmont[strKey.Split('*')[0].Trim()] += dblTemp - Convert.ToDouble(hstNetAmount[strKey]);
                                                            }
                                                            else
                                                            {

                                                                m_gdicNetAmont.Add(strKey.Split('*')[0].Trim(), dblTemp - Convert.ToDouble(hstNetAmount[strKey]));
                                                            }
                                                        }
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        hstNetAmount.Clear();
                        foreach (KeyValuePair<string, double> objNetAmount in m_gdicNetAmont)
                        {
                            hstNetAmount.Add(objNetAmount.Key, objNetAmount.Value);
                            hstCurrent.Add(objNetAmount.Key, objNetAmount.Value);
                        }

                        m_gdicNetAmont = null;
                    }
                }

                if (lngSeriesID == 0)
                {
                    if (m_objViewer.m_dgvDetail.Rows[m_objViewer.m_dgvDetail.CurrentCell.RowIndex].DataBoundItem != null)
                    {
                        DataRowView dtvTmp = m_objViewer.m_dgvDetail.Rows[m_objViewer.m_dgvDetail.CurrentCell.RowIndex].DataBoundItem as DataRowView;
                        long.TryParse(dtvTmp["SERIESID_INT"].ToString(), out lngSeriesID);
                    }
                }

                //20090119：库存不足时，提示是否要出库
                if (blnHasMain)
                {
                    if (dblAllAvaGross + dblTmp < dblAmount)
                    {
                        if (MessageBox.Show("可用库存不足出库，是否继续？", "温馨提示...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return -1;
                    }
                }
                else
                {
                    if (dblAllAvaGross < dblAmount)
                    {
                        if (MessageBox.Show("可用库存不足出库，是否继续？", "温馨提示...", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return -1;
                    }
                }
                frmQueryMedicine frmQMI = new frmQueryMedicine(dblAmount);
                frmQMI.m_blnIsHospital = m_objViewer.m_blnIsHospital;
                frmQMI.m_mthSetMedicineVO(objDetail, hstPeriod, hstCurrent);
                frmQMI.m_lngSeriesID = lngSeriesID;
                frmQMI.m_dgvQueryMedicineInfo.Focus();
                frmQMI.ShowDialog();

                if (frmQMI.DialogResult == DialogResult.OK)
                {
                    m_objViewer.m_dtOutStorageMedicine.Rows.RemoveAt(intCurrentRow);
                    clsDS_StorageMedicineShow[] objValue = frmQMI.m_ObjOutMedicinArr;
                    m_mthSetOutMedicineVOToTable(objValue, dblAllRealGross, dblAllAvaGross);//, intFirstRowIndex);
                    lngRes = 1;
                }
                else
                {
                    return -1;
                }

            }
            else
            {
                MessageBox.Show("没有当前选择药品库存信息", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;
            }
            return lngRes;
        }

        #region 设置出库药品信息至界面
        /// <summary>
        /// 设置出库药品信息至界面
        /// </summary>
        /// <param name="p_objValue">出库药品信息</param>
        /// <param name="p_dblAllRealGross">总实际库存</param>
        /// <param name="p_dblAllAvaGross">总可用库存</param>        
        internal void m_mthSetOutMedicineVOToTable(clsDS_StorageMedicineShow[] p_objValue, double p_dblAllRealGross, double p_dblAllAvaGross)//, int p_intFirstRowIndex)
        {
            if (p_objValue == null || p_objValue.Length == 0)
            {
                return;
            }

            int intRowsCount = m_objViewer.m_dtOutStorageMedicine.Rows.Count;


            if (intRowsCount > 0)//去除空行
            {
                DataRow[] drNull = m_objViewer.m_dtOutStorageMedicine.Select(" ipavailablegross_num is null");
                //DataRow[] drNull = m_objViewer.m_dtOutStorageMedicine.Select(" iprealgross_int is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_objViewer.m_dtOutStorageMedicine.Rows.Remove(drTemp);
                    }
                }
            }


            for (int iRow = 0; iRow < p_objValue.Length; iRow++)
            {
                DataRow drNew = m_objViewer.m_dtOutStorageMedicine.NewRow();
                m_mthAddDataToRow(drNew, p_objValue[iRow], p_dblAllRealGross, p_dblAllAvaGross);
                m_objViewer.m_dtOutStorageMedicine.Rows.Add(drNew);//.InsertAt(drNew, p_intFirstRowIndex);//要将新行插入至指定位置

                // p_intFirstRowIndex++;                
            }
            //m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail[6, p_intFirstRowIndex];
        }

        /// <summary>
        /// 添加数据至指定行
        /// </summary>
        /// <param name="p_drRow">数据行</param>
        /// <param name="p_objValue">出库药品信息</param>
        /// <param name="p_dblAllRealGross">总实际库存</param>
        /// <param name="p_dblAllAvaGross">总可用库存</param>
        private void m_mthAddDataToRow(DataRow p_drRow, clsDS_StorageMedicineShow p_objValue, double p_dblAllRealGross, double p_dblAllAvaGross)
        {
            if (p_drRow == null || p_objValue == null)
            {
                return;
            }

            p_drRow["MEDICINEID_CHR"] = p_objValue.m_strMEDICINEID_CHR;
            p_drRow["MEDICINENAME_VCHR"] = p_objValue.m_strMEDICINENAME_VCHR;
            p_drRow["MEDSPEC_VCHR"] = p_objValue.m_strMEDSPEC_VCHR;
            p_drRow["OPUNIT_CHR"] = p_objValue.m_strOPUNIT_VCHR;
            p_drRow["OPAMOUNT_INT"] = p_objValue.m_dblOutAmount.ToString("0.00");
            p_drRow["LOTNO_VCHR"] = p_objValue.m_strLOTNO_VCHR;
            p_drRow["INSTOREID_VCHR"] = p_objValue.m_strINSTOREID_VCHR;
            p_drRow["DSINSTOREID_VCHR"] = p_objValue.m_strDSINSTOREID_VCHR;
            p_drRow["OPWHOLESALEPRICE_INT"] = p_objValue.m_dcmOPWHOLESALEPRICE_INT.ToString("0.0000");
            p_drRow["OPRETAILPRICE_INT"] = p_objValue.m_dcmOPRETAILPRICE_INT.ToString("0.0000");
            p_drRow["instoragedate_dat"] = p_objValue.m_dtmINSTOREDATE_DAT.ToString("yyyy-MM-dd");
            if (p_objValue.m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd") == "0001-01-01")
            {
                p_drRow["validperiod_dat"] = DBNull.Value;
            }
            else
            {
                p_drRow["validperiod_dat"] = p_objValue.m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd");
            }
            p_drRow["oprealgross_int"] = p_objValue.m_dblOPREALGROSS_INT.ToString("0.00");
            p_drRow["assistcode_chr"] = p_objValue.m_strASSISTCODE_CHR;
            p_drRow["opavailagross_int"] = p_objValue.m_dblOPAVAILAGROSS_INT.ToString("0.00");
            p_drRow["medicinetypeid_chr"] = p_objValue.m_strMedicineTypeID_CHR;
            p_drRow["ipunit_chr"] = p_objValue.m_strIPUNIT_VCHR;
            p_drRow["packqty_dec"] = p_objValue.m_dblPACKQTY_DEC;
            p_drRow["seriesid_int"] = p_objValue.m_lngSERIESID_INT;
            p_drRow["storageseriesid_chr"] = p_objValue.m_strStorageseriesid_chr;
            p_drRow["ipretailprice_int"] = p_objValue.m_dcmIPRETAILPRICE_INT;
            p_drRow["ipwholesaleprice_int"] = p_objValue.m_dcmIPWHOLESALEPRICE_INT;
            p_drRow["iprealgross_int"] = p_objValue.m_dblIPREALGROSS_INT;
            p_drRow["ipavailablegross_num"] = p_objValue.m_dblIPAVAILAGROSS_INT;
            p_drRow["productorid_chr"] = p_objValue.m_strPRODUCTORID_CHR;
            p_drRow["opchargeflg_int"] = p_objValue.m_dblOPCHARGEFLG_INT;
            p_drRow["ipchargeflg_int"] = p_objValue.m_dblIPCHARGEFLG_INT;
            p_drRow["AMOUNT_INT"] = p_objValue.m_dblChargeAmount.ToString("0.00");
            if (m_objViewer.m_blnIsHospital)
            {
                if (p_objValue.m_dblIPCHARGEFLG_INT == 0)
                {
                    p_drRow["IPAMOUNT_INT"] = p_objValue.m_dblChargeAmount * p_objValue.m_dblPACKQTY_DEC;
                    p_drRow["UNIT_CHR"] = p_objValue.m_strOPUNIT_VCHR;
                    p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmOPWHOLESALEPRICE_INT.ToString("0.0000");
                    p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmOPRETAILPRICE_INT.ToString("0.0000");
                }
                else
                {
                    p_drRow["IPAMOUNT_INT"] = p_objValue.m_dblChargeAmount.ToString("0.00");
                    p_drRow["UNIT_CHR"] = p_objValue.m_strIPUNIT_VCHR;
                    p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmIPWHOLESALEPRICE_INT.ToString("0.0000");
                    p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmIPRETAILPRICE_INT.ToString("0.0000");
                }
            }
            else
            {
                if (p_objValue.m_dblOPCHARGEFLG_INT == 0)
                {
                    p_drRow["IPAMOUNT_INT"] = p_objValue.m_dblChargeAmount * p_objValue.m_dblPACKQTY_DEC;
                    p_drRow["UNIT_CHR"] = p_objValue.m_strOPUNIT_VCHR;
                    p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmOPWHOLESALEPRICE_INT.ToString("0.0000");
                    p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmOPRETAILPRICE_INT.ToString("0.0000");
                }
                else
                {
                    p_drRow["IPAMOUNT_INT"] = p_objValue.m_dblChargeAmount.ToString("0.00");
                    p_drRow["UNIT_CHR"] = p_objValue.m_strIPUNIT_VCHR;
                    p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmIPWHOLESALEPRICE_INT.ToString("0.0000");
                    p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmIPRETAILPRICE_INT.ToString("0.0000");
                }
            }


            p_drRow.EndEdit();
        }
        #endregion
        #endregion

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

        internal void m_mthPrint()
        {
            DataStore ds = new DataStore();
            ds.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            ds.DataWindowObject = "d_op_outstoragemakerorder";
            ds.Modify("t_title.text='" + m_objComInfo.m_strGetHospitalTitle() + "药品出库凭证'");
            ds.Modify("t_storagename.text='" + this.m_objViewer.m_cboMedStore.Text + "'");
            ds.Modify("t_todept.text='" + this.m_objViewer.m_txtFromDept.Text + "'");
            ds.Modify("t_outtype.text='" + this.m_objViewer.m_cboStatus.Text + "'");
            ds.Modify("t_count.text='" + this.m_objViewer.m_dtOutStorageMedicine.Rows.Count.ToString() + "'");
            ds.Modify("t_billid.text='" + this.m_objViewer.m_txtBillId.Text + "'");
            ds.Modify("t_name.text='" + this.m_objViewer.m_txtMaker.Text + "'");

            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("medicineno", typeof(String));
            dtTemp.Columns.Add("medicinename_vchr", typeof(String));
            dtTemp.Columns.Add("medspec_vchr", typeof(String));
            dtTemp.Columns.Add("unit_chr", typeof(String));
            dtTemp.Columns.Add("amount_int", typeof(String));
            dtTemp.Columns.Add("outstorageprice", typeof(String));
            dtTemp.Columns.Add("outtotalstorageprice", typeof(String));
            dtTemp.Columns.Add("productorid_chr", typeof(String));
            dtTemp.Columns.Add("lotno_vchr", typeof(String));
            dtTemp.Columns.Add("retailprice_int", typeof(String));

            int intRowCount = m_objViewer.m_dtOutStorageMedicine.Rows.Count;
            double sumouttotalretailprice = 0d;
            DataRow dr = null;
            DataRow drTemp = null;
            for (int i = 0; i < intRowCount; i++)
            {
                drTemp = dtTemp.NewRow();
                dr = m_objViewer.m_dtOutStorageMedicine.Rows[i];
                drTemp["medicineno"] = Convert.ToString(i + 1);
                drTemp["medicinename_vchr"] = dr["medicinename_vchr"].ToString();
                drTemp["medspec_vchr"] = dr["medspec_vchr"].ToString();
                drTemp["unit_chr"] = dr["unit_chr"].ToString();
                drTemp["amount_int"] = Convert.ToString(dr["amount_int"]).Length == 0 ? "0" : Convert.ToDouble(dr["amount_int"]).ToString("0.00");
                drTemp["outstorageprice"] = Convert.ToString(dr["retailprice_int"]).Length == 0 ? "0" : Convert.ToDouble(dr["retailprice_int"]).ToString("0.0000");
                if (Convert.ToString(dr["ipamount_int"]).Length == 0 || Convert.ToString(dr["opretailprice_int"]).Length == 0)
                {
                    drTemp["outtotalstorageprice"] = 0;
                }
                else
                {
                    drTemp["outtotalstorageprice"] = Convert.ToDouble(Convert.ToDouble(dr["ipamount_int"]) * Convert.ToDouble(dr["opretailprice_int"]) / Convert.ToDouble(dr["packqty_dec"])).ToString("F4");
                }
                    //Convert.ToDouble(Convert.ToDouble(dr["retailprice_int"]) * Convert.ToDouble(dr["amount_int"])).ToString("0.0000");
                drTemp["productorid_chr"] = dr["productorid_chr"].ToString();
                drTemp["lotno_vchr"] = dr["lotno_vchr"].ToString();
                drTemp["retailprice_int"] = Convert.ToString(dr["retailprice_int"]).Length == 0 ? "0" : Convert.ToDouble(dr["retailprice_int"]).ToString("0.0000");
                dtTemp.Rows.Add(drTemp.ItemArray);
                if(Convert.ToString(drTemp["outtotalstorageprice"]).Length > 0)
                    sumouttotalretailprice += Convert.ToDouble(drTemp["outtotalstorageprice"]);
            }
            dtTemp.AcceptChanges();
            dr = null;
            drTemp = null;

            ds.Reset();
            ds.Modify("t_sumoutdetailprice.text='" + sumouttotalretailprice.ToString("0.0000") + "'");
            ds.Retrieve(dtTemp);

            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(ds);
        }

        /// <summary>
        /// 修改单据类型、发往部门等信息
        /// </summary>
        /// <param name="blnGenerateInBill"></param>
        /// <returns></returns>
        internal long m_lngUpdateTypeAndDept(bool blnGenerateInBill)
        {
            long lngRes = -1;
            if (string.IsNullOrEmpty(m_objViewer.m_cboStatus.Text))
            {
                MessageBox.Show("必须填写出库类型", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_cboStatus.Focus();
                return -1;
            }
            int m_intFormType_int = -1;
            //1、药房自身出库（出库部门是本药房），2、药房借调（出库部门是其它药房），3、科室出库（出库部门除药房外的其它部门）
            string strMedStoreID = string.Empty;
            if (m_objViewer.m_cboMedStore.SelectItemValue != "")
            {
                strMedStoreID = m_objViewer.m_cboMedStore.SelectItemValue != string.Empty ? m_objViewer.m_cboMedStore.SelectItemValue : m_objViewer.m_cboMedStore.AccessibleName;
            }
            string m_strDeptCode = "";
            if (m_objViewer.m_txtFromDept.Text.Trim() != "")
            {
                m_strDeptCode = m_objViewer.m_txtFromDept.AccessibleName;
            }
            if (m_strDeptCode.Length == 0)
            {
                MessageBox.Show("必须选择出库部门", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_txtFromDept.Focus();
                return -1;
            }

            if (m_objViewer.m_intEditStatus == 3)
            {
                m_lngCheckIsDrugStoreDept(m_strDeptCode, out m_objViewer.m_blnSendToDrugStore);
                if (m_objViewer.m_blnSendToDrugStore)
                {
                    MessageBox.Show("已入账的出库单不允许将发往部门修改为发往药房。", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.m_objViewer.m_txtFromDept.Focus();
                    return -1;
                }
            }

            if (m_objViewer.m_intEditStatus == 2 && blnGenerateInBill == true && m_strDeptCode != m_objViewer.m_strOriginalDept)
            {
                MessageBox.Show("已生成入库单，不允许修改发往部门", "药房出库制单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_txtFromDept.Focus();
                return -1;
            }

            if (strMedStoreID == m_strDeptCode)
            {
                m_intFormType_int = 1;
            }
            else if (this.m_objViewer.frmMain.m_dtMedStoreInfo != null)
            {
                int m_intRowsCount = this.m_objViewer.frmMain.m_dtMedStoreInfo.Rows.Count;
                DataRow dr;
                for (int i = 0; i < m_intRowsCount; i++)
                {
                    dr = this.m_objViewer.frmMain.m_dtMedStoreInfo.Rows[i];
                    if (dr["deptid_chr"].ToString() == m_strDeptCode)
                    {
                        m_intFormType_int = 2;
                        break;
                    }
                    if (i == m_intRowsCount - 1)
                        m_intFormType_int = 3;
                }
            }
            else
            {
                m_intFormType_int = 3;
            }
            string m_strTypeCode = m_objViewer.m_cboStatus.SelectItemValue != string.Empty ? m_objViewer.m_cboStatus.SelectItemValue : m_objViewer.m_cboStatus.AccessibleName;
            return m_objDomain.m_lngUpdateTypeAndDept(m_objViewer.m_txtBillId.Text, m_intFormType_int, m_strTypeCode, m_strDeptCode, blnGenerateInBill,this .m_objViewer.m_txtComment.Text);
        }

        /// <summary>
        /// 该部门是否为药房
        /// </summary>
        /// <param name="p_strDeptID"></param>
        /// <param name="p_blnSendToDrugStore"></param>
        /// <returns></returns>
        internal long m_lngCheckIsDrugStoreDept(string p_strDeptID, out bool p_blnSendToDrugStore)
        {
            return m_objDomain.m_lngCheckIsDrugStoreDept(p_strDeptID, out p_blnSendToDrugStore);
        }

        internal long m_lngCheckIfHasGenerateInstorage(string p_strOutBillNo, out bool p_blnHasGenerateInstorageBill)
        {
            return m_objDomain.m_lngCheckIfHasGenerateInstorage(p_strOutBillNo, out p_blnHasGenerateInstorageBill);
        }

        /// <summary>
        /// 从Excel导入住院处方
        /// </summary>
        /// <param name="dtb_FromExcel"></param>
        internal long m_lngImportFromExcel(DataTable dtb_FromExcel)
        {
            long lngRes = 0;
            try
            {                
                if (dtb_FromExcel.Rows.Count > 0)
                {
                    m_objViewer.m_dtOutStorageMedicine.Clear();
                    dtb_FromExcel.Columns.Add("原因");
                    DataTable dtbTemp = m_objViewer.m_dtOutStorageMedicine.Clone();
                    ((clsDcl_OutStorageMakerOrder)m_objDomain).m_lngCheckStorage(m_objViewer.m_blnIsHospital, m_objViewer.m_strStoreid, ref dtb_FromExcel, ref dtbTemp);
                    if (dtbTemp != null && dtbTemp.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dtbTemp.Rows)
                        {
                            m_objViewer.m_dtOutStorageMedicine.ImportRow(dr);
                        }
                        lngRes = 1;
                    }
                    
                    clsPublic.CloseAvi();
                    if (dtb_FromExcel.Rows.Count > 0)
                    {
                        frmNoteAndExpExcel frmNE = new frmNoteAndExpExcel();
                        frmNE.m_dgvDetail.AutoResizeColumns();
                        frmNE.m_dgvDetail.AllowUserToAddRows = false;
                        frmNE.m_dgvDetail.DataSource = dtb_FromExcel;
                        frmNE.m_dgvDetail.ReadOnly = true;
                        int intWidth = 0;
                        for (int i2 = 0; i2 < frmNE.m_dgvDetail.Columns.Count; i2++)
                        {
                            intWidth += frmNE.m_dgvDetail.Columns[i2].Width;
                            frmNE.m_dgvDetail.Columns[i2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                        }
                        frmNE.StartPosition = FormStartPosition.CenterParent;
                        frmNE.m_lblNote.Text = "总共有"+dtb_FromExcel.Rows.Count.ToString()+"行数据";
                        frmNE.ShowDialog();                        
                    }
                    m_objViewer.m_mthShowRetailMoney();
                }                
            }
            catch (Exception ex)
            {
                lngRes = -1;
                MessageBox.Show(ex.Message);
            }
            finally
            {                
                clsPublic.CloseAvi();                
            }
            return lngRes;
        }

        internal void LoadBill(string p_strBillID)
        {
            clsDS_OutStorage_VO m_objMain = null;
            long lngRes = 0;
            lngRes = m_objDomain.m_lngLoadBill(m_objViewer.m_blnIsHospital, p_strBillID, out m_objMain, out m_objViewer.m_dtOutStorageMedicine);
            if (lngRes > 0)
            {
                m_objViewer.m_datMakeDate.Value = m_objMain.m_datMAKEORDER_DAT;
                m_objViewer.m_txtMaker.Text = m_objMain.m_strMakeName;
                m_objViewer.m_cboStatus.Text = m_objMain.m_strTYPENAME_VCHR;
                m_objViewer.m_txtFromDept.Text = m_objMain.m_strINSTOREDEPTName_CHR;
                m_objViewer.m_cboMedStore.Text = m_objMain.m_strDRUGSTOREName;
                m_objViewer.m_txtBillId.Text = m_objMain.m_strOUTDRUGSTOREID_VCHR;
                m_objViewer.m_txtComment.Text = m_objMain.m_strCOMMENT_VCHR;

                m_objViewer.m_btnSave.Enabled = false;
                m_objViewer.m_btnInsert.Enabled = false;
                m_objViewer.m_btnNext.Enabled = false;
                m_objViewer.m_btnDelete.Enabled = false;
                m_objViewer.m_datMakeDate.Enabled = false;
                m_objViewer.m_cboStatus.Enabled = false;
                m_objViewer.m_txtFromDept.Enabled = false;
                m_objViewer.m_cboMedStore.Enabled = false;
                m_objViewer.m_txtComment.ReadOnly = true;
                m_objViewer.m_txtMaker.Enabled = false;
                m_objViewer.m_txtBillId.Enabled = false;
                m_objViewer.m_btnImpRecipeData.Enabled = false;
                m_objViewer.m_dgvDetail.DataSource = m_objViewer.m_dtOutStorageMedicine;
            }
            else
            {
                MessageBox.Show("找不到该药房出库单！", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
