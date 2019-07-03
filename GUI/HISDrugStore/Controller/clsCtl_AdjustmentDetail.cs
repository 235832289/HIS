using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.MedicineStore;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药品调价明细
    /// </summary>
    public class clsCtl_AdjustmentDetail : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_AdjustmentDetail m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmAdjustPriceDetail m_objViewer;
        /// <summary>
        /// 查询药品字典控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 查询员工控件
        /// </summary>
        private ctlQueryEmployee m_ctlEMP = null;
        /// <summary>
        /// 当前药品调价主记录
        /// </summary>
        private clsDS_Adjustment_VO m_objCurrentMain = null;
        /// <summary>
        /// 当前药品调价明细记录
        /// </summary>
        private clsDS_Adjustment_Detail[] m_objCurrentSubArr = null;
        /// <summary>
        /// 当前药品明细(非界面显示内容)
        /// </summary>
        private DataTable m_dtbCurrentMedicineDetail = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 药品调价
        /// </summary>
        public clsCtl_AdjustmentDetail()
        {
            m_objDomain = new clsDcl_AdjustmentDetail();
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
            m_objViewer = (frmAdjustPriceDetail)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化数据源
        /// <summary>
        /// 初始化数据源
        /// </summary>
        internal void m_mthInitDataTable()
        {
            m_objViewer.m_dtbAdjustPrice = new System.Data.DataTable();

            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("seriesid_int"), new DataColumn("medicineid_chr"), new DataColumn("medicinename_vch"), new DataColumn("medspec_vchr"),
                new DataColumn("lotno_vchr"),new DataColumn("currentgross_int", typeof(double)),new DataColumn("oldretailprice_int", typeof(double)),new DataColumn("newretailprice_int", typeof(double)),
                new DataColumn("reason_vchr"),new DataColumn("status_int"),new DataColumn("validperiod_dat"),new DataColumn("opunit_vchr"),new DataColumn("assistcode_chr"),new DataColumn("Balance", typeof(double)),
                new DataColumn("oldmoney", typeof(double)),new DataColumn("NewMoney", typeof(double)), new DataColumn("CALLPRICE_INT"),new DataColumn("productorid_chr")};

            m_objViewer.m_dtbAdjustPrice.Columns.AddRange(dcColumns);

            m_objViewer.m_dtbAdjustPrice.Columns["balance"].Expression = "currentgross_int * newretailprice_int - currentgross_int * oldretailprice_int";
            m_objViewer.m_dtbAdjustPrice.Columns["oldmoney"].Expression = "currentgross_int * oldretailprice_int";
            m_objViewer.m_dtbAdjustPrice.Columns["NewMoney"].Expression = "currentgross_int * newretailprice_int ";

            m_dtbCurrentMedicineDetail = new DataTable();

            DataColumn[] dcColumns1 = new DataColumn[] { new DataColumn("seriesid_int"), new DataColumn("medicineid_chr"), new DataColumn("medicinename_vch"), new DataColumn("medspec_vchr"),
                new DataColumn("lotno_vchr"),new DataColumn("currentgross_int", typeof(double)),new DataColumn("oldretailprice_int", typeof(double)),new DataColumn("newretailprice_int", typeof(double)),
                new DataColumn("reason_vchr"),new DataColumn("status_int"),new DataColumn("validperiod_dat"),new DataColumn("opunit_vchr"),new DataColumn("assistcode_chr"),new DataColumn("INSTORAGEID_VCHR"), 
                new DataColumn("CALLPRICE_INT"),new DataColumn("productorid_chr")};

            m_dtbCurrentMedicineDetail.Columns.AddRange(dcColumns1);
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
            p_intCommitFolw = 0;
            p_intCommitFolw = Convert.ToInt16(this.m_objComInfo.m_lonGetModuleInfo("5005"));
        }
        #endregion

        #region 获取调价设置
        /// <summary>
        /// 获取调价设置
        /// </summary>
        internal void m_mthGetAdjustPriceSetting()
        {
            int intDiffLotNO = 0;//同一药品是否分批号调价
            int intAdjustDrugstore = 0;//药库调价是否同时调整药房价格

            long lngRes = m_objDomain.m_lngGetIsDiffLotNO(out intDiffLotNO);
            if (intDiffLotNO == 0)
            {
                m_objViewer.m_blnIsDiffLotNO = false;
            }
            else if(intDiffLotNO == 1)
            {
                m_objViewer.m_blnIsDiffLotNO = true;
            }

            lngRes = m_objDomain.m_lngGetIsAdjustDrugstore(out intAdjustDrugstore);
            if (intAdjustDrugstore == 0)
            {
                m_objViewer.m_blnIsAdjustDrugstore = false;
            }
            else if (intAdjustDrugstore == 1)
            {
                m_objViewer.m_blnIsAdjustDrugstore = true;
            }
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
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvAdjustPrice.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvAdjustPrice.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(m_ctlQueryMedicint_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvAdjustPrice.Location.X,
                rect.Y + m_objViewer.m_dgvAdjustPrice.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvAdjustPrice.Location.X,
                rect.Y + m_objViewer.m_dgvAdjustPrice.Location.Y - m_ctlQueryMedicint.Size.Height);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthGetMedicineInfo(m_objViewer.m_strDrugStoreid);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtMedicine;
        }

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo(string m_strMedStoreid)
        {
            clsPub.m_mthGetMedBaseInfo(m_strMedStoreid, out m_objViewer.m_dtMedicine);
        }
        #endregion
        private void m_ctlQueryMedicint_ReturnInfo(clsMS_MedicintLeastElement_VO MS_VO)
        {
            m_objViewer.m_dgvAdjustPrice.Focus();
            m_objViewer.m_dgvAdjustPrice.CurrentCell = null;
            if (m_objViewer.m_dgvAdjustPrice.Rows.Count > 0)
            {
                m_objViewer.m_dgvAdjustPrice.CurrentCell = m_objViewer.m_dgvAdjustPrice.Rows[m_objViewer.m_dgvAdjustPrice.Rows.Count - 1].Cells[8];
                m_objViewer.m_dgvAdjustPrice.CurrentCell.Selected = true;
            }
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        {
            DataTable dtbMedicine = null;
            //获取的DataTable已根据批号及单价排序
            long lngRes = m_objDomain.m_lngGetMedicineByMedicineID(p_strMedicineID, m_objViewer.m_strDrugStoreid, out dtbMedicine);

            if (dtbMedicine == null || dtbMedicine.Rows.Count == 0)
            {
                MessageBox.Show("未找到所选择药品的库存信息", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_ctlQueryMedicint.Visible = true;
                m_ctlQueryMedicint.Focus();
                return -1;
            }

            if (dtbMedicine.Columns.Contains("retailprice_int"))
            {
                //数字类型会出现小数位不止四位的情况，比如数据库保存的值0.7000会在DataRow中变成0.70000000007，原因未明，暂用此方法格式化
                foreach (DataRow dr in dtbMedicine.Rows)
                {
                    dr["retailprice_int"] = Convert.ToDouble(dr["retailprice_int"]).ToString("0.0000");
                }
            }

            //只要是零售单价不同，不管是否分批号显示设置，均分开显示
            int intRowsCount = dtbMedicine.Rows.Count;
            if (m_objViewer.m_blnIsDiffLotNO)
            {
                List<DataRow> lstDRMedicine = new List<DataRow>();
                double dblGross = 0d;
                double LastPrice = 0d;
                DataRow drFirstRow = null;
                for (int i = 0; i < intRowsCount; i++)
                {
                    if (i > 0)
                    {
                        double dblCurrent = Convert.ToDouble(dtbMedicine.Rows[i]["retailprice_int"]);
                        if (dtbMedicine.Rows[i]["lotno_vchr"].ToString() == dtbMedicine.Rows[i-1]["lotno_vchr"].ToString())
                        {
                            if (LastPrice != dblCurrent)
                            {
                                drFirstRow = dtbMedicine.Rows[i];
                                LastPrice = dblCurrent;
                                dblGross = 0;
                                lstDRMedicine.Add(dtbMedicine.Rows[i]);
                            }
                            else
                            {
                                dblGross += Convert.ToDouble(dtbMedicine.Rows[i]["realgross_int"]);
                                LastPrice = dblCurrent;
                                drFirstRow["realgross_int"] = dblGross;
                                continue;
                            }                            
                        }
                        else
                        {
                            drFirstRow = dtbMedicine.Rows[i];
                            LastPrice = dblCurrent;
                            dblGross = 0;
                            lstDRMedicine.Add(dtbMedicine.Rows[i]);
                        }
                    }
                    else
                    {
                        drFirstRow = dtbMedicine.Rows[0];
                        dblGross = Convert.ToDouble(dtbMedicine.Rows[0]["realgross_int"]);
                        LastPrice = Convert.ToDouble(dtbMedicine.Rows[0]["retailprice_int"]);
                        lstDRMedicine.Add(dtbMedicine.Rows[i]);
                    }
                }

                List<DataRow> lstNewMedicine = new List<DataRow>();//未添加的药品
                foreach (DataRow dr in lstDRMedicine)
                {
                    DataRow[] drMed = m_objViewer.m_dtbAdjustPrice.Select("medicineid_chr = '" + dr["medicineid_chr"].ToString() + "' and lotno_vchr = '" + dr["lotno_vchr"].ToString() + "' and oldretailprice_int = " + dr["retailprice_int"].ToString());
                    if (drMed == null || drMed.Length == 0)
                    {
                        lstNewMedicine.Add(dr);
                        //添加至药品明细
                        DataRow[] drSource = dtbMedicine.Select("medicineid_chr = '" + dr["medicineid_chr"].ToString() + "' and lotno_vchr = '" + dr["lotno_vchr"].ToString() + "' and retailprice_int = " + dr["retailprice_int"].ToString());
                        if (drSource != null && drSource.Length > 0)
                        {
                            for (int iSo = 0; iSo < drSource.Length; iSo++)
                            {
                                DataRow drNewMed = m_dtbCurrentMedicineDetail.NewRow();
                                drNewMed["seriesid_int"] = DBNull.Value;
                                drNewMed["medicineid_chr"] = drSource[iSo]["medicineid_chr"].ToString();
                                drNewMed["medicinename_vch"] = drSource[iSo]["medicinename_vchr"].ToString();
                                drNewMed["medspec_vchr"] = drSource[iSo]["medspec_vchr"].ToString();
                                drNewMed["lotno_vchr"] = drSource[iSo]["lotno_vchr"].ToString();
                                drNewMed["currentgross_int"] = drSource[iSo]["realgross_int"].ToString();
                                drNewMed["oldretailprice_int"] = drSource[iSo]["retailprice_int"].ToString();
                                drNewMed["newretailprice_int"] = drSource[iSo]["retailprice_int"].ToString();
                                drNewMed["reason_vchr"] = string.Empty;
                                drNewMed["status_int"] = 1;
                                drNewMed["validperiod_dat"] = drSource[iSo]["validperiod_dat"].ToString();
                                drNewMed["opunit_vchr"] = drSource[iSo]["opunit_vchr"].ToString();
                                drNewMed["assistcode_chr"] = drSource[iSo]["assistcode_chr"].ToString();
                                drNewMed["INSTORAGEID_VCHR"] = drSource[iSo]["instorageid_vchr"].ToString();
                                drNewMed["CALLPRICE_INT"] = drSource[iSo]["CALLPRICE_INT"].ToString();
                                drNewMed["productorid_chr"] = drSource[iSo]["productorid_chr"].ToString();
                                
                                m_dtbCurrentMedicineDetail.Rows.Add(drNewMed);
                            }
                        }
                    }
                }
                if (lstNewMedicine.Count > 0)
                {
                    m_mthAddStorageDataToUI(lstNewMedicine.ToArray());
                }                
            }
            else
            {
                Hashtable hstMedicine = new Hashtable();
                for (int i = 0; i < intRowsCount; i++)
                {
                    double dblCurrentPrice = Convert.ToDouble(dtbMedicine.Rows[i]["retailprice_int"]);
                    if (hstMedicine.Contains(dblCurrentPrice))
                    {
                        DataRow dr = hstMedicine[dblCurrentPrice] as DataRow;
                        dr["realgross_int"] = Convert.ToDouble(dr["realgross_int"]) + Convert.ToDouble(dtbMedicine.Rows[i]["realgross_int"]);
                    }
                    else
                    {
                        hstMedicine.Add(dblCurrentPrice, dtbMedicine.Rows[i]);
                    }
                }

                List<DataRow> lstDRMedicine = new List<DataRow>();
                foreach (object obj in hstMedicine.Values)
                {
                    DataRow dr = obj as DataRow;
                    lstDRMedicine.Add(dr);
                }

                List<DataRow> lstNewMedicine = new List<DataRow>();//未添加的药品
                foreach (DataRow dr in lstDRMedicine)
                {
                    DataRow[] drMed = m_objViewer.m_dtbAdjustPrice.Select("medicineid_chr = '" + dr["medicineid_chr"].ToString() + "' and oldretailprice_int = " + dr["retailprice_int"].ToString());
                    if (drMed == null || drMed.Length == 0)
                    {
                        lstNewMedicine.Add(dr);
                        //添加至药品明细
                        string strFilter = "medicineid_chr = '" + dr["medicineid_chr"].ToString() + "' and retailprice_int = " + Convert.ToDouble(dr["retailprice_int"]).ToString("0.0000");
                        DataRow[] drSource = dtbMedicine.Select(strFilter);
                        if (drSource != null && drSource.Length > 0)
                        {
                            for (int iSo = 0; iSo < drSource.Length; iSo++)
                            {
                                DataRow drNewMed = m_dtbCurrentMedicineDetail.NewRow();
                                drNewMed["seriesid_int"] = DBNull.Value;
                                drNewMed["medicineid_chr"] = drSource[iSo]["medicineid_chr"].ToString();
                                drNewMed["medicinename_vch"] = drSource[iSo]["medicinename_vchr"].ToString();
                                drNewMed["medspec_vchr"] = drSource[iSo]["medspec_vchr"].ToString();
                                drNewMed["lotno_vchr"] = drSource[iSo]["lotno_vchr"].ToString();
                                drNewMed["currentgross_int"] = drSource[iSo]["realgross_int"].ToString();
                                drNewMed["oldretailprice_int"] = drSource[iSo]["retailprice_int"].ToString();
                                drNewMed["newretailprice_int"] = drSource[iSo]["retailprice_int"].ToString();
                                drNewMed["reason_vchr"] = string.Empty;
                                drNewMed["status_int"] = 1;
                                drNewMed["validperiod_dat"] = drSource[iSo]["validperiod_dat"].ToString();
                                drNewMed["opunit_vchr"] = drSource[iSo]["opunit_vchr"].ToString();
                                drNewMed["assistcode_chr"] = drSource[iSo]["assistcode_chr"].ToString();
                                drNewMed["INSTORAGEID_VCHR"] = drSource[iSo]["instorageid_vchr"].ToString();
                                drNewMed["CALLPRICE_INT"] = drSource[iSo]["CALLPRICE_INT"].ToString();
                                drNewMed["productorid_chr"] = drSource[iSo]["productorid_chr"].ToString();
                                m_dtbCurrentMedicineDetail.Rows.Add(drNewMed);
                            }
                        }
                    }
                }
                if (lstNewMedicine.Count > 0)
                {
                    m_mthAddStorageDataToUI(lstNewMedicine.ToArray());
                }                
            }
            return 1;
        }

        /// <summary>
        /// 设置库存信息至界面
        /// </summary>
        /// <param name="p_drDataArr">库存信息</param>
        private void m_mthAddStorageDataToUI(DataRow[] p_drDataArr)
        {
            if (p_drDataArr == null || p_drDataArr.Length == 0)
            {
                return;
            }

            DataRow[] drNull = m_objViewer.m_dtbAdjustPrice.Select("medicineid_chr is null");
            if (drNull != null && drNull.Length > 0)
            {
                foreach (DataRow dr in drNull)
                {
                    m_objViewer.m_dtbAdjustPrice.Rows.Remove(dr);
                }
            }

            m_objViewer.m_dtbAdjustPrice.BeginLoadData();
            for (int iRow = 0; iRow < p_drDataArr.Length; iRow++)
            {
                DataRow drAdjust = m_objViewer.m_dtbAdjustPrice.NewRow();
                drAdjust["medicineid_chr"] = p_drDataArr[iRow]["medicineid_chr"].ToString();
                drAdjust["medicinename_vch"] = p_drDataArr[iRow]["medicinename_vchr"].ToString();
                drAdjust["medspec_vchr"] = p_drDataArr[iRow]["medspec_vchr"].ToString();
                drAdjust["lotno_vchr"] = p_drDataArr[iRow]["lotno_vchr"].ToString();
                drAdjust["currentgross_int"] = p_drDataArr[iRow]["realgross_int"].ToString();
                drAdjust["oldretailprice_int"] = p_drDataArr[iRow]["retailprice_int"].ToString();
                drAdjust["newretailprice_int"] = p_drDataArr[iRow]["retailprice_int"].ToString();
                drAdjust["status_int"] = 1;
                drAdjust["validperiod_dat"] = Convert.ToDateTime(p_drDataArr[iRow]["validperiod_dat"]).ToString("yyyy-MM-dd");
                drAdjust["opunit_vchr"] = p_drDataArr[iRow]["opunit_vchr"].ToString();
                drAdjust["CALLPRICE_INT"] = p_drDataArr[iRow]["CALLPRICE_INT"].ToString();
                drAdjust["assistcode_chr"] = p_drDataArr[iRow]["assistcode_chr"].ToString();
                drAdjust["productorid_chr"] = p_drDataArr[iRow]["productorid_chr"].ToString();
                m_objViewer.m_dtbAdjustPrice.LoadDataRow(drAdjust.ItemArray,false);
            }
            m_objViewer.m_dtbAdjustPrice.EndLoadData();

            if (m_objViewer.m_dgvAdjustPrice.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < m_objViewer.m_dgvAdjustPrice.Rows.Count; iRow++)
                {
                    m_objViewer.m_dgvAdjustPrice.Rows[iRow].Cells[1].ReadOnly = true;
                }
                m_objViewer.m_dgvAdjustPrice.CurrentCell = m_objViewer.m_dgvAdjustPrice.Rows[m_objViewer.m_dgvAdjustPrice.Rows.Count - 1].Cells["m_dgvtxtNewPrice"];
            }
        }
        #endregion

        #region 插入新的一行药品出库信息

        /// <summary>
        /// 插入新的一行药品出库信息
        /// </summary>
        internal void m_mthInsertNewMedicineData()
        {
            if (m_objViewer.m_dtbAdjustPrice == null)
            {
                return;
            }

            DataRow drNew = m_objViewer.m_dtbAdjustPrice.NewRow();
            m_objViewer.m_dtbAdjustPrice.Rows.Add(drNew);

            m_objViewer.m_dgvAdjustPrice.Focus();
            m_objViewer.m_dgvAdjustPrice.CurrentCell = m_objViewer.m_dgvAdjustPrice[1, m_objViewer.m_dgvAdjustPrice.RowCount - 1];
        }
        #endregion

        #region 跳转至下一行
        /// <summary>
        /// 跳转至下一行
        /// </summary>
        internal void m_mthJumpToNewRow()
        {
            if (m_objViewer.m_dtbAdjustPrice.Rows.Count > 0)
            {
                DataRow drLast = m_objViewer.m_dtbAdjustPrice.Rows[m_objViewer.m_dtbAdjustPrice.Rows.Count - 1];
                if (drLast["medicineid_chr"] == DBNull.Value)
                {
                    m_objViewer.m_dgvAdjustPrice.Focus();
                    m_objViewer.m_dgvAdjustPrice.CurrentCell = m_objViewer.m_dgvAdjustPrice.Rows[m_objViewer.m_dtbAdjustPrice.Rows.Count - 1].Cells[1];
                    m_objViewer.m_dgvAdjustPrice.CurrentCell.Selected = true;
                }
            }
            else
            {
                m_mthInsertNewMedicineData();
            }
        } 
        #endregion

        #region 设置员工至列表


        /// <summary>
        /// 设置员工至列表
        /// </summary>
        /// <param name="p_strSearch">搜索字符串</param>
        /// <param name="p_txtEmp">员工控件</param>
        internal void m_mthSetEmpToList(string p_strSearch, TextBox p_txtEmp)
        {
            DataTable dtbEmp = null;
            clsDcl_Purchase_Detail objPDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDomain.m_lngGetEMP(p_strSearch, out dtbEmp);
            objPDomain = null;

            if (dtbEmp == null || dtbEmp.Rows.Count == 0)
            {
                p_txtEmp.Tag = null;
            }

            if (m_ctlEMP == null)
            {
                m_ctlEMP = new ctlQueryEmployee();
                m_ctlEMP.ReturnInfo += new ReturnEmpInfo(m_ctlEMP_ReturnInfo);
                m_objViewer.Controls.Add(m_ctlEMP);
            }
            m_ctlEMP.m_mthSetTxtBase(p_txtEmp);
            m_ctlEMP.BringToFront();
            int X = m_objViewer.gradientPanel2.Location.X + p_txtEmp.Location.X;
            int Y = m_objViewer.gradientPanel2.Location.Y + p_txtEmp.Location.Y + p_txtEmp.Size.Height;

            if ((X + m_ctlEMP.Size.Width) > m_objViewer.Size.Width)
            {
                X = m_objViewer.gradientPanel2.Location.X + p_txtEmp.Location.X - (X + m_ctlEMP.Size.Width - m_objViewer.Size.Width);
            }
            m_ctlEMP.Location = new System.Drawing.Point(X, Y);

            try
            {
                int intRowCount = dtbEmp.Rows.Count;
                DataRow drCurrent = null;
                List<ListViewItem> lstItems = new List<ListViewItem>();
                for (int iRow = 0; iRow < intRowCount; iRow++)
                {
                    drCurrent = dtbEmp.Rows[iRow];
                    ListViewItem lsi = new ListViewItem(drCurrent["EMPNO_CHR"].ToString());
                    lsi.SubItems.Add(drCurrent["LASTNAME_VCHR"].ToString());
                    lsi.Tag = drCurrent;
                    lstItems.Add(lsi);
                }
                m_ctlEMP.AddRange(lstItems.ToArray());
                if (lstItems.Count == 0)
                {
                    p_txtEmp.Tag = null;
                }
                m_ctlEMP.Visible = true;
                m_ctlEMP.Focus();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
        }

        private void m_ctlEMP_ReturnInfo(DataRow DR_EMP, TextBox Sender)
        {
            Sender.Tag = null;
            if (DR_EMP != null)
            {
                Sender.Tag = DR_EMP["EMPID_CHR"].ToString();
                Sender.Text = DR_EMP["LASTNAME_VCHR"].ToString();
            }

            m_objViewer.m_txtRemark.Focus();
        }
        #endregion

        #region 保存药品调价记录
        /// <summary>
        /// 保存药品调价记录
        /// </summary>
        /// <returns></returns>
        internal long m_lngSaveMedicine()
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intFORMSTATE_INT > 1)
            {
                if (m_objCurrentMain.m_intFORMSTATE_INT == 3)
                {
                    MessageBox.Show("该药品调价记录已入帐，不能修改", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                else if (m_objCurrentMain.m_intFORMSTATE_INT == 2 && m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品调价记录已审核，不能修改", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
            }

            //DateTime datOutTime;
            //m_objDomain.m_mthGetAccountperiodTime(m_objViewer.m_strDrugStoreid, out datOutTime);
            //if (Convert.ToDateTime(m_objViewer.m_datMakeDate.Text) < datOutTime)
            //{
            //    MessageBox.Show("制单日期不能小于上次帐务结转的结束日期。\r\n上次结转结束日期是：" + datOutTime.ToString("yyyy年MM月dd日"), "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    m_objViewer.m_datMakeDate.Focus();
            //    return 0;
            //}

            //去除空行
            DataRow[] drNull = m_objViewer.m_dtbAdjustPrice.Select("medicineid_chr is null");
            if (drNull != null && drNull.Length > 0)
            {
                foreach (DataRow dr in drNull)
                {
                    m_objViewer.m_dtbAdjustPrice.Rows.Remove(dr);
                }
            }

            //新旧零售价相同
            DataRow[] drEqual = m_objViewer.m_dtbAdjustPrice.Select("oldretailprice_int=newretailprice_int");
            if (drEqual != null && drEqual.Length > 0)
            {
                StringBuilder stbHint = new StringBuilder(100);
                stbHint.Append("以下药品未改变零售调，是否忽略并继续保存？");
                stbHint.Append(Environment.NewLine);
                stbHint.Append("药品代码      批号          药品名称");
                stbHint.Append(Environment.NewLine);
                for (int iRow = 0; iRow < drEqual.Length; iRow++)
                {
                    stbHint.Append(drEqual[iRow]["assistcode_chr"].ToString().PadRight(14, ' '));
                    stbHint.Append(drEqual[iRow]["lotno_vchr"].ToString().PadRight(14, ' '));
                    stbHint.Append(drEqual[iRow]["medicinename_vch"].ToString());
                    stbHint.Append(Environment.NewLine);
                }
                frmHintMessageBox frmHint = new frmHintMessageBox(stbHint.ToString());
                frmHint.ShowDialog();
                if (frmHint.DialogResult == DialogResult.No)
                {
                    return 0;
                }
                else
                {
                    foreach (DataRow dr in drEqual)
                    {
                        m_objViewer.m_dtbAdjustPrice.Rows.Remove(dr);
                    }
                }
            }
            if (m_objViewer.m_dtbAdjustPrice.Rows.Count == 0)
            {
                MessageBox.Show("请先录入药品调价信息", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }

            long lngRes = 0;

            try
            {
                long[] lngSubSEQArr = null;//药品调价明细序列
                bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;
                DataRow[] drSource = null;//药品明细
                //调价暂时不允许保存即审核
                if (m_objCurrentMain == null)
                {
                    clsDS_Adjustment_VO objMain = m_objMain();
                    clsDS_Adjustment_Detail[] objDetail = m_objDetail(m_objViewer.m_dtbAdjustPrice, out drSource);

                    long lngMainSEQ = 0;
                    string strAdjustID = string.Empty;
                    lngRes = m_objDomain.m_lngAddNewAdjustment(objMain, objDetail, false, m_objViewer.m_blnIsDiffLotNO, false, out lngMainSEQ, out strAdjustID, out lngSubSEQArr);

                    if (lngRes <= 0)
                    {
                        m_objCurrentMain = null;
                    }
                    else
                    {
                        m_objViewer.m_txtAdjustID.Text = objMain.m_strADJUSTPRICEID_VCHR;
                        m_objCurrentSubArr = objDetail;
                    }
                }
                else
                {
                    clsDS_Adjustment_VO objMain = m_objMain();
                    clsDS_Adjustment_Detail[] objDetail = m_objDetail(m_objViewer.m_dtbAdjustPrice, out drSource);

                    lngRes = m_objDomain.m_lngModifyAdjustment(objMain, objDetail, false, m_objViewer.m_blnIsDiffLotNO, out lngSubSEQArr);

                    if (lngRes > 0)
                    {
                        m_objCurrentSubArr = objDetail;
                    }
                }

                if (lngRes > 0)
                {
                    m_mthSetDetailSEQToUI(lngSubSEQArr, drSource);
                }
            }
            catch (Exception Ex)
            {
                m_objCurrentMain = null;
                MessageBox.Show("保存失败","药品调价",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }            
            return lngRes;
        }

        /// <summary>
        /// 设置明细序列号至界面
        /// </summary>
        /// <param name="p_lngSubSEQArr">明细表序列号</param>
        /// <param name="p_drSource">药品明细</param>
        private void m_mthSetDetailSEQToUI(long[] p_lngSubSEQArr,DataRow[] p_drSource)
        {
            if (p_lngSubSEQArr == null || p_lngSubSEQArr.Length == 0 || p_drSource == null || p_drSource.Length == 0 || p_lngSubSEQArr.Length != p_drSource.Length)
            {
                return;
            }

            for (int iRow = 0; iRow < p_drSource.Length; iRow++)
            {
                p_drSource[iRow]["seriesid_int"] = p_lngSubSEQArr[iRow];
            }

            for (int i = 0; i < m_objViewer.m_dtbAdjustPrice.Rows.Count; i++)
            {
                m_objViewer.m_dtbAdjustPrice.Rows[i]["seriesid_int"] = 1;//界面表数据给一个大于零的数字，表示已保存
            }
        }

        /// <summary>
        /// 获取当前界面主表界面
        /// </summary>
        /// <returns></returns>
        private clsDS_Adjustment_VO m_objMain()
        {//调价暂时不允许保存即审核
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsDS_Adjustment_VO();
                //if (m_objViewer.m_intCommitFolow == 1)
                //{
                //    m_objCurrentMain.m_intFORMSTATE_INT = 2;
                //}
                //else
                //{
                    m_objCurrentMain.m_intFORMSTATE_INT = 1;
                //}
                
                //m_objCurrentMain.m_intFORMTYPE_INT = 1;
                m_objCurrentMain.m_dtmNEWDATE_DAT = Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));
                //m_objCurrentMain.m_strDrugStoreid = m_objViewer.m_strDrugStoreid;
            }

            if (m_objViewer.m_txtMan.Tag == null)
            {
                m_objCurrentMain.m_strCREATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                //if (m_objViewer.m_intCommitFolow == 1)
                //{
                //    m_objCurrentMain.m_strEXAMERID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                //}
            }
            else
            {
                m_objCurrentMain.m_strCREATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                //if (m_objViewer.m_intCommitFolow == 1)
                //{
                //    m_objCurrentMain.m_strEXAMERID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                //}
            }

            //if (m_objViewer.m_intCommitFolow == 1)
            //{
            //    m_objCurrentMain.m_dtmEXAMDATE_DAT = Convert.ToDateTime(clsPub.SysDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));
            //}
            m_objCurrentMain.m_dtmADJUSTPRICEDATE_DAT = Convert.ToDateTime(m_objViewer.m_datMakeDate.Text);
            m_objCurrentMain.m_strADJUSTPRICEID_VCHR = m_objViewer.m_txtAdjustID.Text;
            m_objCurrentMain.m_strCOMMENT_VCHR = m_objViewer.m_txtRemark.Text;
            return m_objCurrentMain;
        }

        /// <summary>
        /// 获取当前界面药品调价明细
        /// </summary>
        /// <param name="p_dtbDetail">当前界面内容</param>
        /// <param name="p_drMedicineSourde">药品明细内容</param>
        /// <returns></returns>
        private clsDS_Adjustment_Detail[] m_objDetail(DataTable p_dtbDetail, out DataRow[] p_drMedicineSourde)
        {
            p_drMedicineSourde = null;
            if (p_dtbDetail == null || p_dtbDetail.Rows.Count == 0)
            {
                return null;
            }

            if (m_dtbCurrentMedicineDetail.Columns.Contains("oldretailprice_int"))
            {
                //数字类型会出现小数位不止四位的情况，比如数据库保存的值0.7000会在DataRow中变成0.70000000007，原因未明，暂用此方法格式化
                foreach (DataRow dr in m_dtbCurrentMedicineDetail.Rows)
                {
                    dr["oldretailprice_int"] = Convert.ToDouble(dr["oldretailprice_int"]).ToString("0.0000");
                }
            }

            List<DataRow> lstMedicine = new List<DataRow>();

            int intRowsCount = p_dtbDetail.Rows.Count;
            List<clsDS_Adjustment_Detail> lstDetail = new List<clsDS_Adjustment_Detail>();
            DataRow drTemp = null;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                drTemp = p_dtbDetail.Rows[iRow];

                DataRow[] drSource = null;
                if (m_objViewer.m_blnIsDiffLotNO)
                {
                    drSource = m_dtbCurrentMedicineDetail.Select("medicineid_chr = '" + drTemp["medicineid_chr"].ToString() + "' and lotno_vchr = '" + drTemp["lotno_vchr"].ToString() + "' and oldretailprice_int = " + drTemp["oldretailprice_int"].ToString());
                }
                else
                {
                    drSource = m_dtbCurrentMedicineDetail.Select("medicineid_chr = '" + drTemp["medicineid_chr"].ToString() + "' and oldretailprice_int = " + drTemp["oldretailprice_int"].ToString());
                }

                if (drSource == null || drSource.Length == 0)
                {
                    continue;
                }

                lstMedicine.AddRange(drSource);
                for (int iSo = 0; iSo < drSource.Length; iSo++)
                {
                    clsDS_Adjustment_Detail objDetailTemp = new clsDS_Adjustment_Detail();
                    //objDetailTemp.m_dblCURRENTGROSS_INT = Convert.ToDouble(drSource[iSo]["currentgross_int"]);
                    //objDetailTemp.m_dblNEWRETAILPRICE_INT = Convert.ToDouble(drTemp["newretailprice_int"]);
                    //objDetailTemp.m_dblOLDRETAILPRICE_INT = Convert.ToDouble(drSource[iSo]["oldretailprice_int"]);
                    objDetailTemp.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drSource[iSo]["validperiod_dat"]);
                    objDetailTemp.m_intSTATUS_INT = 1;
                    if (drSource[iSo]["lotno_vchr"].ToString() == "")
                    {
                        objDetailTemp.m_strLOTNO_VCHR = "UNKNOWN";
                    }
                    else
                    {
                        objDetailTemp.m_strLOTNO_VCHR = drSource[iSo]["lotno_vchr"].ToString();
                    }
                    objDetailTemp.m_strMEDICINEID_CHR = drSource[iSo]["medicineid_chr"].ToString();
                    objDetailTemp.m_strMEDICINENAME_VCHR = drSource[iSo]["medicinename_vch"].ToString();
                    objDetailTemp.m_strMEDSPEC_VCHR = drSource[iSo]["medspec_vchr"].ToString();
                    objDetailTemp.m_strREASON_VCHR = drTemp["reason_vchr"].ToString();
                    objDetailTemp.m_strOPUNIT_VCHR = drSource[iSo]["OPUNIT_VCHR"].ToString();
                    objDetailTemp.m_lngSERIESID2_INT = m_objCurrentMain.m_lngSERIESID_INT;
                    objDetailTemp.m_strINSTORAGEID_VCHR = drSource[iSo]["instorageid_vchr"].ToString();
 
                    objDetailTemp.m_strPRODUCTORID_CHR = drSource[iSo]["productorid_chr"].ToString();
                    lstDetail.Add(objDetailTemp);
                }                
            }

            if (lstMedicine.Count > 0)
            {
                p_drMedicineSourde = lstMedicine.ToArray();
            }

            if (lstDetail.Count == 0)
            {
                return null;
            }
            return lstDetail.ToArray();
        }
        #endregion

        #region 删除调价明细
        /// <summary>
        /// 删除调价明细
        /// </summary>
        internal void m_mthDeleteDetail()
        {
            if (m_objViewer.m_dgvAdjustPrice.CurrentCell == null)
                return;

            long lngSEQ = 0;
             bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;
            DataRowView drvCurrent = m_objViewer.m_dgvAdjustPrice.Rows[m_objViewer.m_dgvAdjustPrice.CurrentCell.RowIndex].DataBoundItem as DataRowView;
            if (long.TryParse(drvCurrent["seriesid_int"].ToString(), out lngSEQ))
            {
                DataRow[] drSource = null;
                if (m_objViewer.m_blnIsDiffLotNO)
                {
                    drSource = m_dtbCurrentMedicineDetail.Select("medicineid_chr = '" + drvCurrent["medicineid_chr"].ToString() + "' and lotno_vchr = '" + drvCurrent["lotno_vchr"].ToString() + "' and oldretailprice_int = " + drvCurrent["oldretailprice_int"].ToString());
                }
                else
                {
                    drSource = m_dtbCurrentMedicineDetail.Select("medicineid_chr = '" + drvCurrent["medicineid_chr"].ToString() + "' and oldretailprice_int = " + drvCurrent["oldretailprice_int"].ToString());
                }

                if (drSource == null || drSource.Length == 0)
                {
                    return;
                }

                long[] lngSeqArr = new long[drSource.Length];
                for (int iSEQ = 0; iSEQ < drSource.Length; iSEQ++)
                {
                    lngSeqArr[iSEQ] = Convert.ToInt64(drSource[iSEQ]["SERIESID_INT"]);
                }

                clsMS_MedicineInfoForAdjustPrice objMedicine = null;
                if (blnIsCommit)//退审，即将原有库存零售价设为无效，新添零售价为调价之前的记录
                {
                    objMedicine = new clsMS_MedicineInfoForAdjustPrice();
                    objMedicine.m_dblNewRetailPrice = Convert.ToDouble(drvCurrent["oldretailprice_int"]);
                    objMedicine.m_dblOldRetailPrice = Convert.ToDouble(drvCurrent["newretailprice_int"]);
                    objMedicine.m_dtmAdjustDate = m_objCurrentMain.m_dtmADJUSTPRICEDATE_DAT;
                    objMedicine.m_strAdjustManID = m_objCurrentMain.m_strEXAMERID_CHR;
                    objMedicine.m_strLotNO = drvCurrent["lotno_vchr"].ToString();
                    objMedicine.m_strMedicineID = drvCurrent["medicineid_chr"].ToString();
                    objMedicine.m_dtmValidDate = Convert.ToDateTime(drvCurrent["VALIDPERIOD_DAT"]);
                    objMedicine.m_dblInPrice = Convert.ToDouble(drvCurrent["CALLPRICE_INT"]);
                    objMedicine.m_strStorageID = m_objViewer.m_strDrugStoreid;
                }

                //调价暂时不允许保存即审核
                long lngRes = m_objDomain.m_lngDeleteSpecAdjustmentDetail(lngSeqArr, false, m_objViewer.m_blnIsDiffLotNO, objMedicine);
                if (lngRes > 0)
                {
                    m_objViewer.m_dtbAdjustPrice.Rows.Remove(drvCurrent.Row);
                    foreach (DataRow dr in drSource)
                    {
                        m_dtbCurrentMedicineDetail.Rows.Remove(dr);
                    }
                    MessageBox.Show("删除成功","药品调价",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("删除失败", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                m_objViewer.m_dtbAdjustPrice.Rows.Remove(drvCurrent.Row);
            }
        } 
        #endregion

        #region 清空界面
        /// <summary>
        /// 清空界面
        /// </summary>
        internal void m_mthClear()
        {
            m_objViewer.m_txtRemark.Clear();
            m_objViewer.m_txtAdjustID.Clear();
            if (m_objViewer.m_dtbAdjustPrice != null)
            {
                m_objViewer.m_dtbAdjustPrice.Rows.Clear();
            }
            m_objCurrentMain = null;
        } 
        #endregion

        #region 设置数据到界面
        /// <summary>
        /// 设置数据到界面        /// </summary>
        /// <param name="p_objMain">调价主记录</param>
        /// <param name="p_objSubArr">调价明细记录</param>
        internal void m_mthSetDataToUI(clsDS_Adjustment_VO p_objMain, clsDS_Adjustment_Detail[] p_objSubArr)
        {
            if (p_objMain == null || p_objSubArr == null || p_objSubArr.Length == 0)
            {
                return ;
            }

            m_objCurrentMain = p_objMain;
            m_objViewer.m_txtAdjustID.Text = p_objMain.m_strADJUSTPRICEID_VCHR;
            m_objViewer.m_txtMan.Text = p_objMain.m_strCreatorName;
            m_objViewer.m_txtMan.Tag = p_objMain.m_strCREATORID_CHR;
            m_objViewer.m_txtRemark.Text = p_objMain.m_strCOMMENT_VCHR;
            m_objViewer.m_datMakeDate.Text = p_objMain.m_dtmADJUSTPRICEDATE_DAT.ToString("yyyy年MM月dd日");

            if (m_objViewer.m_intCommitFolow == 1 && p_objMain.m_intFORMSTATE_INT != 0 && p_objMain.m_intFORMSTATE_INT != 3)
            {
                m_objViewer.m_btnSave.Enabled = true;
                m_objViewer.m_btnDelete.Enabled = true;
                m_objViewer.m_btnInsert.Enabled = true;
                m_objViewer.m_btnNext.Enabled = true;
            }

            m_dtbCurrentMedicineDetail.BeginLoadData();
            for (int iRow = 0; iRow < p_objSubArr.Length; iRow++)
            {
                DataRow drCurrent = m_dtbCurrentMedicineDetail.NewRow();
                drCurrent["seriesid_int"] = p_objSubArr[iRow].m_lngSERIESID_INT;
                drCurrent["medicineid_chr"] = p_objSubArr[iRow].m_strMEDICINEID_CHR;
                drCurrent["medicinename_vch"] = p_objSubArr[iRow].m_strMEDICINENAME_VCHR;
                drCurrent["medspec_vchr"] = p_objSubArr[iRow].m_strMEDSPEC_VCHR;
                drCurrent["lotno_vchr"] = p_objSubArr[iRow].m_strLOTNO_VCHR;
                //drCurrent["currentgross_int"] = p_objSubArr[iRow].m_dblCURRENTGROSS_INT;
                //drCurrent["oldretailprice_int"] = p_objSubArr[iRow].m_dblOLDRETAILPRICE_INT;
                //drCurrent["newretailprice_int"] = p_objSubArr[iRow].m_dblNEWRETAILPRICE_INT;
                drCurrent["reason_vchr"] = p_objSubArr[iRow].m_strREASON_VCHR;
                drCurrent["status_int"] = p_objSubArr[iRow].m_intSTATUS_INT;
                drCurrent["validperiod_dat"] = p_objSubArr[iRow].m_dtmVALIDPERIOD_DAT;
                drCurrent["opunit_vchr"] = p_objSubArr[iRow].m_strOPUNIT_VCHR;
                drCurrent["assistcode_chr"] = p_objSubArr[iRow].m_strMedicineCode;
                drCurrent["INSTORAGEID_VCHR"] = p_objSubArr[iRow].m_strINSTORAGEID_VCHR;
      
                drCurrent["productorid_chr"] = p_objSubArr[iRow].m_strPRODUCTORID_CHR;
                
                m_dtbCurrentMedicineDetail.LoadDataRow(drCurrent.ItemArray, true);
            }
            m_dtbCurrentMedicineDetail.EndLoadData();

            DataTable dtbTemp = m_dtbCurrentMedicineDetail.Copy();
            m_mthAdjustDetailRows(dtbTemp);//根据是否分批号显示，合并数据

            //将合并后的数据显示至界面
            DataRow drTemp = null;
            m_objViewer.m_dtbAdjustPrice.BeginLoadData();
            for (int iRow = 0; iRow < dtbTemp.Rows.Count; iRow++)
            {
                drTemp = dtbTemp.Rows[iRow];
                DataRow drCurrent = m_objViewer.m_dtbAdjustPrice.NewRow();
                drCurrent["seriesid_int"] = drTemp["seriesid_int"].ToString();
                drCurrent["medicineid_chr"] = drTemp["medicineid_chr"].ToString();
                drCurrent["medicinename_vch"] = drTemp["medicinename_vch"].ToString();
                drCurrent["medspec_vchr"] = drTemp["medspec_vchr"].ToString();
                drCurrent["lotno_vchr"] = drTemp["lotno_vchr"].ToString();
                drCurrent["currentgross_int"] = drTemp["currentgross_int"].ToString();
                drCurrent["oldretailprice_int"] = drTemp["oldretailprice_int"].ToString();
                drCurrent["newretailprice_int"] = drTemp["newretailprice_int"].ToString();
                drCurrent["reason_vchr"] = drTemp["reason_vchr"].ToString();
                drCurrent["status_int"] = drTemp["status_int"].ToString();
                drCurrent["validperiod_dat"] = drTemp["validperiod_dat"].ToString();
                drCurrent["opunit_vchr"] = drTemp["opunit_vchr"].ToString();
                drCurrent["assistcode_chr"] = drTemp["assistcode_chr"].ToString();
                drCurrent["productorid_chr"] = drTemp["productorid_chr"].ToString();
                m_objViewer.m_dtbAdjustPrice.LoadDataRow(drCurrent.ItemArray, true);
            }
            m_objViewer.m_dtbAdjustPrice.EndLoadData();
            dtbTemp = null;

            if (p_objMain.m_intFORMSTATE_INT != 1)
            {
                m_objViewer.m_btnSave.Enabled = false;
                m_objViewer.m_btnDelete.Enabled = false;
                m_objViewer.m_btnInsert.Enabled = false;
                m_objViewer.m_btnNext.Enabled = false;
                m_objViewer.m_datMakeDate.Enabled = false;
                m_objViewer.m_txtMan.Enabled = false;
                m_objViewer.m_txtRemark.Enabled = false;
                m_objViewer.m_dgvAdjustPrice.ReadOnly = true;
            }
        } 
        #endregion

        #region 获取总金额
        /// <summary>
        /// 获取总金额
        /// </summary>
        internal void m_mthGetAllMoney()
        {
            m_objViewer.m_lblAfterMoney.Text = string.Empty;
            m_objViewer.m_lblBeforeMoney.Text = string.Empty;
            m_objViewer.m_lblSubMoney.Text = string.Empty;

            if (m_objViewer.m_dtbAdjustPrice == null || m_objViewer.m_dtbAdjustPrice.Rows.Count == 0)
            {
                return;
            }

            int intRowsCount = m_objViewer.m_dtbAdjustPrice.Rows.Count;
            DataRow drCurrent = null;
            double dblBeforemoney = 0d;
            double dblAftermoney = 0d;
            double dblSubMoney = 0d;

            try
            {
                for (int i = 0; i < intRowsCount; i++)
                {
                    drCurrent = m_objViewer.m_dtbAdjustPrice.Rows[i];
                    if (drCurrent.RowState == DataRowState.Detached || drCurrent.RowState == DataRowState.Deleted)
                    {
                        continue;
                    }
                    double dblAM = Convert.ToDouble(drCurrent["newretailprice_int"]) * Convert.ToDouble(drCurrent["currentgross_int"]);
                    double dblBM = Convert.ToDouble(drCurrent["oldretailprice_int"]) * Convert.ToDouble(drCurrent["currentgross_int"]);

                    dblAftermoney += dblAM;
                    dblBeforemoney += dblBM;
                    dblSubMoney += (dblAM - dblBM);
                }
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }            

            m_objViewer.m_lblSubMoney.Text = dblSubMoney.ToString("0.0000");
            m_objViewer.m_lblBeforeMoney.Text = dblBeforemoney.ToString("0.0000");
            m_objViewer.m_lblAfterMoney.Text = dblAftermoney.ToString("0.0000");
        } 
        #endregion

        #region 不分批号时设置同批号药品零售单价
        /// <summary>
        /// 不分批号时设置同批号药品零售单价
        /// </summary>
        internal void m_mthSetSameLotNOPrice(DataRow p_drCurrent)
        {
            if (p_drCurrent == null)
            {
                return;
            }

            DataRow[] drSameLotNO = m_objViewer.m_dtbAdjustPrice.Select("MEDICINEID_CHR = '" + p_drCurrent["MEDICINEID_CHR"].ToString() + "'");

            if (drSameLotNO != null && drSameLotNO.Length > 0)
            {
                foreach (DataRow dr in drSameLotNO)
                {
                    if (dr != p_drCurrent)
                    {
                        dr["NEWRETAILPRICE_INT"] = Convert.ToDouble(p_drCurrent["NEWRETAILPRICE_INT"]);
                    }
                }
            }
        } 
        #endregion

        #region 根据是否按批号显示调整明细行
        /// <summary>
        /// 根据是否按批号显示调整明细行
        /// </summary>
        /// <param name="p_dtbDetail">明细数据</param>
        internal void m_mthAdjustDetailRows(DataTable p_dtbDetail)
        {
            if (p_dtbDetail == null || p_dtbDetail.Rows.Count == 0)
            {
                return;
            }

            List<DataRow> lstDRMedicine = new List<DataRow>();
            //只要是零售单价不同，不管是否分批号显示设置，均分开显示
            int intRowsCount = p_dtbDetail.Rows.Count;
            if (m_objViewer.m_blnIsDiffLotNO)
            {
                double dblGross = 0d;
                double LastPrice = 0d;
                DataRow drFirstRow = null;
                for (int i = 0; i < intRowsCount; i++)
                {
                    if (i > 0)
                    {
                        double dblCurrent = Convert.ToDouble(p_dtbDetail.Rows[i]["OLDRETAILPRICE_INT"]);
                        if (p_dtbDetail.Rows[i]["lotno_vchr"].ToString() == p_dtbDetail.Rows[i - 1]["lotno_vchr"].ToString() && p_dtbDetail.Rows[i]["MEDICINEID_CHR"].ToString() == p_dtbDetail.Rows[i - 1]["MEDICINEID_CHR"].ToString())
                        {
                            if (LastPrice != dblCurrent)
                            {
                                drFirstRow = p_dtbDetail.NewRow();
                                drFirstRow.ItemArray = p_dtbDetail.Rows[i].ItemArray;
                                LastPrice = dblCurrent;
                                dblGross = 0;
                                lstDRMedicine.Add(drFirstRow);
                            }
                            else
                            {
                                dblGross += Convert.ToDouble(p_dtbDetail.Rows[i]["CURRENTGROSS_INT"]);
                                LastPrice = dblCurrent;
                                drFirstRow["CURRENTGROSS_INT"] = dblGross;
                                continue;
                            }
                        }
                        else
                        {
                            drFirstRow = p_dtbDetail.NewRow();
                            drFirstRow.ItemArray = p_dtbDetail.Rows[i].ItemArray;
                            LastPrice = dblCurrent;
                            dblGross = 0;
                            lstDRMedicine.Add(drFirstRow);
                        }
                    }
                    else
                    {
                        drFirstRow = p_dtbDetail.NewRow();
                        drFirstRow.ItemArray = p_dtbDetail.Rows[0].ItemArray;
                        dblGross = Convert.ToDouble(p_dtbDetail.Rows[0]["CURRENTGROSS_INT"]);
                        LastPrice = Convert.ToDouble(p_dtbDetail.Rows[0]["OLDRETAILPRICE_INT"]);
                        lstDRMedicine.Add(drFirstRow);
                    }
                }
            }
            else
            {
                double dblGross = 0d;
                double LastPrice = 0d;
                DataRow drFirstRow = null;
                for (int i = 0; i < intRowsCount; i++)
                {
                    if (i > 0)
                    {
                        double dblCurrent = Convert.ToDouble(p_dtbDetail.Rows[i]["OLDRETAILPRICE_INT"]);
                        if (p_dtbDetail.Rows[i]["MEDICINEID_CHR"].ToString() == p_dtbDetail.Rows[i - 1]["MEDICINEID_CHR"].ToString())
                        {
                            if (LastPrice != dblCurrent)
                            {
                                drFirstRow = p_dtbDetail.NewRow();
                                drFirstRow.ItemArray = p_dtbDetail.Rows[i].ItemArray;
                                LastPrice = dblCurrent;
                                dblGross = 0;
                                lstDRMedicine.Add(drFirstRow);
                            }
                            else
                            {
                                dblGross += Convert.ToDouble(p_dtbDetail.Rows[i]["CURRENTGROSS_INT"]);
                                LastPrice = dblCurrent;
                                drFirstRow["CURRENTGROSS_INT"] = dblGross;
                                continue;
                            }
                        }
                        else
                        {
                            drFirstRow = p_dtbDetail.NewRow();
                            drFirstRow.ItemArray = p_dtbDetail.Rows[i].ItemArray;
                            LastPrice = dblCurrent;
                            dblGross = 0;
                            lstDRMedicine.Add(drFirstRow);
                        }
                    }
                    else
                    {
                        drFirstRow = p_dtbDetail.NewRow();
                        drFirstRow.ItemArray = p_dtbDetail.Rows[0].ItemArray;
                        dblGross = Convert.ToDouble(p_dtbDetail.Rows[0]["CURRENTGROSS_INT"]);
                        LastPrice = Convert.ToDouble(p_dtbDetail.Rows[0]["OLDRETAILPRICE_INT"]);
                        lstDRMedicine.Add(drFirstRow);
                    }
                }
            }

            p_dtbDetail.Rows.Clear();
            p_dtbDetail.BeginLoadData();
            for (int iRow = 0; iRow < lstDRMedicine.Count; iRow++)
            {
                p_dtbDetail.LoadDataRow(lstDRMedicine[iRow].ItemArray,true);
            }
            p_dtbDetail.EndLoadData();
        }
        #endregion

        #region 打印预览窗口
        internal void m_mthPrint()
        {
            if (m_objCurrentMain == null)
            {
                MessageBox.Show("抱歉！请先保存，再打印！", "药品调价", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            frmAdjustmentDetailReport frmAdjReport = new frmAdjustmentDetailReport();
            frmAdjReport.datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;

            int intPrintType;
            string strStorageName = string.Empty;
            m_objDomain.m_lngGetPrintType(out intPrintType);
            if (intPrintType == 0)
            {
                frmAdjReport.datWindow.DataWindowObject = "adjustment_lj";
            }
            else
            {
                frmAdjReport.datWindow.DataWindowObject = "adjustment_cs";
            }

            frmAdjReport.p_strCREATORID_CHR = m_objViewer.m_txtMan.Text;
            frmAdjReport.p_strEXAMERID_CHR = m_objCurrentMain.m_strEXAMERName;
            frmAdjReport.p_strCOMMENT_VCHR = m_objCurrentMain.m_strCOMMENT_VCHR;
            //m_objDomain.m_lngGetStorageNameByStorageID(m_objCurrentMain.m_strDrugStoreid,out strStorageName);
            frmAdjReport.p_strStorageName = strStorageName;
            frmAdjReport.dtbPrin = m_objViewer.m_dtbAdjustPrice.Copy();

           
            frmAdjReport.ShowDialog();
        }
        #endregion

    }
}

