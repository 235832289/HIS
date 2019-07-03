using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房库存初始化
    /// </summary>
    public class clsCtl_InitialDS : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_InitialDS m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmInitialDS m_objViewer;
        /// <summary>
        /// 查询药品字典控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 查询药品字典控件(查询筛选时用)
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicintForFilter = null;
        DataTable m_dtbMoney = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 药房库存初始化
        /// </summary>
        public clsCtl_InitialDS()
        {
            m_objDomain = new clsDcl_InitialDS();
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
            m_objViewer = (frmInitialDS)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化作为DataGridView数据源的DataTable
        /// <summary>
        /// 初始化作为DataGridView数据源的DataTable
        /// </summary>
        /// <param name="p_dtbMedicineTalbe"></param>
        internal void m_mthInitMedicineTalbe(ref DataTable p_dtbMedicineTalbe)
        {
            p_dtbMedicineTalbe = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("ASSISTCODE_CHR"), new DataColumn("MEDICINENAME_VCHR"), new DataColumn("MEDSPEC_VCHR"),
                new DataColumn("IPAMOUNT",typeof(Double)), new DataColumn("IPUNIT_CHR"), new DataColumn("OPAMOUNT",typeof(Double)), new DataColumn("OPUNIT_CHR"), new DataColumn("MEDICINEID_CHR"),
                new DataColumn("PACKQTY_DEC",typeof(Double)), new DataColumn("IPRETAILPRICE_INT",typeof(Double)), new DataColumn("OPRETAILPRICE_INT",typeof(Double)), new DataColumn("IPWHOLESALEPRICE_INT",typeof(Double)),
                new DataColumn("OPWHOLESALEPRICE_INT",typeof(Double)), new DataColumn("VALIDPERIOD_DAT", typeof(DateTime)), new DataColumn("LOTNO_VCHR"), new DataColumn("CREATERID"), new DataColumn("EXAMERID"),
                new DataColumn("createrno"), new DataColumn("creatername"), new DataColumn("examerno"), new DataColumn("examername"), new DataColumn("status"),
                new DataColumn("INACCOUNTERID_CHR"),new DataColumn("INITIALID_CHR"), new DataColumn("SERIESID_INT"),new DataColumn("productorid_chr"),new DataColumn("medicinetypeid_chr"),
            new DataColumn("amount",typeof(Double)),new DataColumn("unit_chr",typeof(String)),new DataColumn("retailprice_int",typeof(Double)),new DataColumn("wholesaleprice_int",typeof(Double)),new DataColumn("opchargeflg_int",typeof(Double)),new DataColumn("ipchargeflg_int",typeof(Double))};
            p_dtbMedicineTalbe.Columns.AddRange(dcColumns);
        }
        #endregion

        #region 添加新行
        /// <summary>
        /// 插入新药品信息
        /// </summary>
        internal void m_mthInsertNewMedicine()
        {
             bool m_blnHasAccountPeriod=false;
            m_objDomain.m_lngCheckHasAccount(m_objViewer.m_strDeptID,out m_blnHasAccountPeriod);
            if (m_blnHasAccountPeriod)
            {
                MessageBox.Show("该药房已有结转记录，不允许添加期初数。", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataView dvSource = m_objViewer.m_dtgvMedicineDetail.DataSource as DataView;
            DataRowView drNew = dvSource.AddNew();

            //DataRow drNew = m_objViewer.m_dtbMedicineDetail.NewRow();

            drNew["CREATERID"] = m_objViewer.LoginInfo.m_strEmpID;
            drNew["createrno"] = m_objViewer.LoginInfo.m_strEmpNo;
            drNew["creatername"] = m_objViewer.LoginInfo.m_strEmpName;
            drNew["VALIDPERIOD_DAT"] = clsPub.CurrentDateTimeNow.AddYears(2);
            drNew["status"] = "未审核";

            //m_objViewer.m_dtbMedicineDetail.Rows.Add(drNew);
            m_objViewer.m_dtgvMedicineDetail.Refresh();

            m_objViewer.m_dtgvMedicineDetail.Focus();
            m_objViewer.m_dtgvMedicineDetail.CurrentCell = m_objViewer.m_dtgvMedicineDetail[1, m_objViewer.m_dtgvMedicineDetail.RowCount - 1];
            m_mthSetTotalMoney();
        }
        #endregion

        #region 删除指定初始库存
        /// <summary>
        /// 删除指定初始库存
        /// </summary>
        /// <param name="p_lngSEQ">序列号</param>
        internal long m_lngDeleteMedicineInitial(long p_lngSEQ)
        {
            long lngRes = m_objDomain.m_lngDeleteMedicineInitial(p_lngSEQ);

            if (lngRes <= 0)
            {
                System.Windows.Forms.MessageBox.Show("删除失败", "库存初始化", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lngRes;
        }
        #endregion

        #region 初始化药品字典最小元素集信息
        /// <summary>
        /// 初始化药品字典最小元素集信息
        /// </summary>
        /// <param name="p_dtbMedicineInfo"></param>
        internal void m_mthInitMedicineInfo(string m_strMedStoreid,ref DataTable p_dtbMedicineInfo)
        {
           long lngRes = m_objDomain.m_lngGetBaseMedicine(string.Empty,m_strMedStoreid, out p_dtbMedicineInfo);            
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
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dtgvMedicineDetail.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dtgvMedicineDetail.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dtgvMedicineDetail.Location.X,
                rect.Y + m_objViewer.m_dtgvMedicineDetail.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dtgvMedicineDetail.Location.X,
                rect.Y + m_objViewer.m_dtgvMedicineDetail.Location.Y - m_ctlQueryMedicint.Size.Height);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthInitMedicineInfo(m_objViewer.m_strDrugStoreID, ref m_objViewer.m_dtbMedicineDict);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicineDict;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dtgvMedicineDetail.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dtgvMedicineDetail.CurrentCell.ColumnIndex;

            DataRowView drCurrent = m_objViewer.m_dtvCurrentView[intRowIndex];
            drCurrent["assistcode_chr"] = MS_VO.m_strMedicineCode;
            drCurrent["medicinename_vchr"] = MS_VO.m_strMedicineName;
            drCurrent["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
            drCurrent["opunit_chr"] = MS_VO.m_strOpUnit_chr;
            drCurrent["medicineid_chr"] = MS_VO.m_strMedicineID;
            drCurrent["ipunit_chr"] = MS_VO.m_strIpUnit_chr;
            drCurrent["packqty_dec"] = MS_VO.m_strPackqty_dec;
            drCurrent["productorid_chr"] = MS_VO.m_strManufacturer;
            drCurrent["medicinetypeid_chr"] = MS_VO.m_strMedicineTypeID;
            drCurrent["opchargeflg_int"] = MS_VO.m_intOpChargeflg_int;
            drCurrent["ipchargeflg_int"] = MS_VO.m_intIpchargeflg_int;
            if (m_objViewer.m_blnIsHospital)
            {
                if (MS_VO.m_intIpchargeflg_int == 0)
                {
                    drCurrent["unit_chr"] = MS_VO.m_strOpUnit_chr;
                    drCurrent["retailprice_int"] = MS_VO.m_dcmRetailPrice;
                }
                else
                {
                    drCurrent["unit_chr"] = MS_VO.m_strIpUnit_chr;
                    drCurrent["retailprice_int"] = Math.Round(MS_VO.m_dcmRetailPrice / Convert.ToDecimal(MS_VO.m_strPackqty_dec),4,MidpointRounding.AwayFromZero);
                }
            }
            else
            {
                if (MS_VO.m_intOpChargeflg_int == 0)
                {
                    drCurrent["unit_chr"] = MS_VO.m_strOpUnit_chr;
                    drCurrent["retailprice_int"] = MS_VO.m_dcmRetailPrice;
                }
                else
                {
                    drCurrent["unit_chr"] = MS_VO.m_strIpUnit_chr;
                    drCurrent["retailprice_int"] = Math.Round(MS_VO.m_dcmRetailPrice / Convert.ToDecimal(MS_VO.m_strPackqty_dec),4,MidpointRounding.AwayFromZero);
                }
            }
            m_objViewer.m_dtgvMedicineDetail.Refresh();
            m_objViewer.m_dtgvMedicineDetail.Focus();
            m_objViewer.m_dtgvMedicineDetail.CurrentCell = m_objViewer.m_dtgvMedicineDetail.Rows[intRowIndex].Cells["amount"];
            m_objViewer.m_dtgvMedicineDetail.CurrentCell.Selected = true;
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体(查询筛选药品时使用)

        /// <summary>
        /// 显示药品字典最小元素信息查询窗体(查询筛选药品时使用)
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// <param name="p_dtbMedicint">字典内容</param>
        internal void m_mthShowQueryMedicineFormForFilter(string p_strSearchCon, DataTable p_dtbMedicint)
        {
            if (m_ctlQueryMedicintForFilter == null)
            {

                m_ctlQueryMedicintForFilter = new ctlQueryMedicintLeastElement(p_dtbMedicint);
                m_objViewer.Controls.Add(m_ctlQueryMedicintForFilter);

                int X = m_objViewer.m_txtMedName.Location.X;
                int Y = m_objViewer.m_txtMedName.Location.Y + m_objViewer.m_txtMedName.Size.Height;

                m_ctlQueryMedicintForFilter.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicintForFilter.ReturnInfo += new ReturnMedicineInfo(frmQueryFormForFilter_ReturnInfo);
                m_ctlQueryMedicintForFilter.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicintForFilter_RefreshMedicine);
            }

            m_ctlQueryMedicintForFilter.Visible = true;
            m_ctlQueryMedicintForFilter.BringToFront();
            m_ctlQueryMedicintForFilter.Focus();
            m_ctlQueryMedicintForFilter.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicintForFilter_RefreshMedicine()
        {
            m_mthInitMedicineInfo(m_objViewer.m_strDrugStoreID, ref m_objViewer.m_dtbMedicineDict);
            m_ctlQueryMedicintForFilter.m_dtbMedicineInfo = m_objViewer.m_dtbMedicineDict;
        }

        internal void frmQueryFormForFilter_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtMedName.Text = MS_VO.m_strMedicineName;
            m_objViewer.m_txtMedName.Tag = MS_VO.m_strMedicineID;

            m_mthFilter();
        }
        #endregion

        #region 保存录入的药品信息

        /// <summary>
        /// 保存录入的药品信息(期初数录入不能保存即审核)
        /// </summary>
        /// <param name="p_blnIsCommit">是否审核前保存</param>
        internal long m_lngSaveMedicineInfo(bool p_blnIsCommit)
        {
            DataView dvCurrent = m_objViewer.m_dtgvMedicineDetail.DataSource as DataView;
            if (dvCurrent == null || dvCurrent.Count == 0)
            {
                return -1;
            }

            DataTable dtbNew = dvCurrent.Table;
            DataRow[] drNewArr = dtbNew.Select("SERIESID_INT is null and MEDICINEID_CHR is not null");
            clsDS_Initial_VO[] objNew = m_objGetInitialVO(drNewArr);

            DataTable dtbModify = m_objViewer.m_dtbMedicineDetail.GetChanges(DataRowState.Modified);
            clsDS_Initial_VO[] objModify = m_objGetInitialVO(dtbModify);

            if ((objNew == null || objNew.Length == 0) && dtbModify == null)
            {
                return 0;
            }

            if (!m_blnIsAllAvailabileVO(drNewArr, dtbModify))
            {
                System.Windows.Forms.MessageBox.Show("含有非法数据或某些必填项未填，保存失败！", "原始库存初始化", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                return -1;
            }

            long lngRes = 0;

            try
            {
                long[] lngNewSeqArr = null;
                string[] strIDArr = null;
                lngRes = m_objDomain.m_lngSaveMedicineInfo(objNew, objModify, out lngNewSeqArr, out strIDArr);

                if (lngRes > 0)
                {
                    m_mthUpdateSEQ(lngNewSeqArr,strIDArr,drNewArr);
                    m_objViewer.m_dtbMedicineDetail.AcceptChanges();

                    DataRow[] drNull = m_objViewer.m_dtbMedicineDetail.Select("SERIESID_INT is null");
                    foreach (DataRow dr in drNull)
                    {
                        m_objViewer.m_dtbMedicineDetail.Rows.Remove(dr);
                    }
                    m_objViewer.m_dtbMedicineDetail.AcceptChanges();
                    if (!p_blnIsCommit)
                    {
                        System.Windows.Forms.MessageBox.Show("保存成功", "原始库存初始化", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (!p_blnIsCommit)
                    {
                        System.Windows.Forms.MessageBox.Show("保存失败", "原始库存初始化", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception Ex)
            {
                lngRes = -1;
                if (!p_blnIsCommit)
                {
                    System.Windows.Forms.MessageBox.Show("保存失败", "原始库存初始化", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }

            return lngRes;
        }

        /// <summary>
        /// 检查是否都为有效内容
        /// </summary>
        /// <param name="p_drNewArr">新添内容</param>
        /// <param name="p_dtbModify">修改内容</param>
        internal bool m_blnIsAllAvailabileVO(DataRow[] p_drNewArr, DataTable p_dtbModify)
        {
            DataView dtSource = m_objViewer.m_dtgvMedicineDetail.DataSource as DataView;
            if (p_drNewArr != null)
            {
                decimal dcmTest = 0m;
                double dblTest = 0d;

                int intRowNum = p_drNewArr.Length;
                for (int iRow = 0; iRow < intRowNum; iRow++)
                {
                    bool blnAllNull = m_blnCheckIsNullRow(p_drNewArr[iRow]);//如果全为空，则不保存，且不提示错误


                    if (blnAllNull)
                    {
                        continue;
                    }

                    if (p_drNewArr[iRow]["MEDICINEID_CHR"] == DBNull.Value || p_drNewArr[iRow]["IPAMOUNT"] == DBNull.Value || p_drNewArr[iRow]["OPAMOUNT"] == DBNull.Value
                        || p_drNewArr[iRow]["IPRETAILPRICE_INT"] == DBNull.Value || p_drNewArr[iRow]["OPRETAILPRICE_INT"] == DBNull.Value
                        || p_drNewArr[iRow]["VALIDPERIOD_DAT"] == DBNull.Value )
                    {
                        return false;//p_drNewArr[iRow]["OPWHOLESALEPRICE_INT"] == DBNull.Value // || p_drNewArr[iRow]["IPWHOLESALEPRICE_INT"] == DBNull.Value
                    }
                    else if (!decimal.TryParse(p_drNewArr[iRow]["IPAMOUNT"].ToString(), out dcmTest) || !decimal.TryParse(p_drNewArr[iRow]["OPAMOUNT"].ToString(), out dcmTest)
                        || !double.TryParse(p_drNewArr[iRow]["IPRETAILPRICE_INT"].ToString(), out dblTest) || !double.TryParse(p_drNewArr[iRow]["OPRETAILPRICE_INT"].ToString(), out dblTest))
                    {
                        return false;//|| !double.TryParse(p_drNewArr[iRow]["IPWHOLESALEPRICE_INT"].ToString(), out dblTest)//|| !double.TryParse(p_drNewArr[iRow]["OPWHOLESALEPRICE_INT"].ToString(), out dblTest)
                    }
                }
            }

            if (p_dtbModify != null)
            {
                decimal dcmTest = 0m;
                double dblTest = 0d;
                DataRow drTemp = null;
                for (int iRow = 0; iRow < p_dtbModify.Rows.Count; iRow++)
                {
                    drTemp = p_dtbModify.Rows[iRow];
                    if (drTemp["MEDICINEID_CHR"] == DBNull.Value || drTemp["IPAMOUNT"] == DBNull.Value || drTemp["OPAMOUNT"] == DBNull.Value
                        || drTemp["IPRETAILPRICE_INT"] == DBNull.Value || drTemp["OPRETAILPRICE_INT"] == DBNull.Value
                        || drTemp["VALIDPERIOD_DAT"] == DBNull.Value)
                    {
                        return false;//|| drTemp["OPWHOLESALEPRICE_INT"] == DBNull.Value // || drTemp["IPWHOLESALEPRICE_INT"] == DBNull.Value
                    }
                    else if (!decimal.TryParse(drTemp["IPAMOUNT"].ToString(), out dcmTest) || !decimal.TryParse(drTemp["OPAMOUNT"].ToString(), out dcmTest)
                        || !double.TryParse(drTemp["IPRETAILPRICE_INT"].ToString(), out dblTest) || !double.TryParse(drTemp["OPRETAILPRICE_INT"].ToString(), out dblTest))
                    {
                        return false;//|| !double.TryParse(drTemp["IPWHOLESALEPRICE_INT"].ToString(), out dblTest) || !double.TryParse(drTemp["OPWHOLESALEPRICE_INT"].ToString(), out dblTest)
                    }
                }
            }

            return true;
        }
        #endregion

        #region 获取原始库存VO
        /// <summary>
        /// 获取原始库存VO
        /// </summary>
        /// <param name="p_dtbDataArr">数据表</param>
        /// <returns></returns>
        private clsDS_Initial_VO[] m_objGetInitialVO(DataTable p_dtbDataArr)
        {
            if (p_dtbDataArr == null || p_dtbDataArr.Rows.Count == 0)
            {
                return null;
            }
            clsDS_Initial_VO[] objInitialVO = null;
            List<clsDS_Initial_VO> lstInitialVO = new List<clsDS_Initial_VO>();
            try
            {
                int intRowsCount = p_dtbDataArr.Rows.Count;
                clsDS_Initial_VO objTemp = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    objTemp = m_objGetInitialVO(p_dtbDataArr.Rows[iRow]);
                    lstInitialVO.Add(objTemp);
                }
                objInitialVO = lstInitialVO.ToArray();
            }
            catch (Exception Ex)
            {
                return null;
            }
            return objInitialVO;
        }

        /// <summary>
        /// 获取原始库存VO
        /// </summary>
        /// <param name="p_drDataArr">数据行</param>
        /// <returns></returns>
        private clsDS_Initial_VO[] m_objGetInitialVO(DataRow[] p_drDataArr)
        {
            if (p_drDataArr == null || p_drDataArr.Length == 0)
            {
                return null;
            }

            clsDS_Initial_VO[] objInitialVO = null;
            List<clsDS_Initial_VO> lstInitialVO = new List<clsDS_Initial_VO>();
            try
            {
                int intRowsCount = p_drDataArr.Length;

                clsDS_Initial_VO objTemp = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    if (m_blnCheckIsNullRow(p_drDataArr[iRow]))
                    {
                        continue;
                    }

                    objTemp = m_objGetInitialVO(p_drDataArr[iRow]);
                    lstInitialVO.Add(objTemp);
                }
                objInitialVO = lstInitialVO.ToArray();
            }
            catch (Exception Ex)
            {
                return null;
            }
            return objInitialVO;
        }

        /// <summary>
        /// 获取原始库存VO
        /// </summary>
        /// <param name="p_drData">数据行</param>
        /// <returns></returns>
        private clsDS_Initial_VO m_objGetInitialVO(DataRow p_drData)
        {
            if (p_drData == null)
            {
                return null;
            }

            double dblTemp = 0d;//用作类型转换的临时变量
            clsDS_Initial_VO objInitial = new clsDS_Initial_VO();
            if (double.TryParse(p_drData["IPAMOUNT"].ToString(), out dblTemp))
            {
                objInitial.m_dblIPAMOUNT = Math.Round(dblTemp,2,MidpointRounding.AwayFromZero);
            }
            else
            {
                objInitial.m_dblIPAMOUNT = 0;
            }
            if (double.TryParse(p_drData["IPRETAILPRICE_INT"].ToString(), out dblTemp))
            {
                objInitial.m_dblIPRETAILPRICE_INT = Math.Round(dblTemp, 4, MidpointRounding.AwayFromZero);
            }
            else
            {
                objInitial.m_dblIPRETAILPRICE_INT = 0;
            }
            if (double.TryParse(p_drData["IPWHOLESALEPRICE_INT"].ToString(), out dblTemp))
            {
                objInitial.m_dblIPWHOLESALEPRICE_INT = Math.Round(dblTemp, 4, MidpointRounding.AwayFromZero);
            }
            else
            {
                objInitial.m_dblIPWHOLESALEPRICE_INT = 0;
            }
            if (double.TryParse(p_drData["OPAMOUNT"].ToString(), out dblTemp))
            {
                objInitial.m_dblOPAMOUNT = Math.Round(dblTemp, 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                objInitial.m_dblOPAMOUNT = 0;
            }
            if (double.TryParse(p_drData["OPRETAILPRICE_INT"].ToString(), out dblTemp))
            {
                objInitial.m_dblOPRETAILPRICE_INT = Math.Round(dblTemp, 4, MidpointRounding.AwayFromZero);
            }
            else
            {
                objInitial.m_dblOPRETAILPRICE_INT = 0;
            }
            if (double.TryParse(p_drData["OPWHOLESALEPRICE_INT"].ToString(), out dblTemp))
            {
                objInitial.m_dblOPWHOLESALEPRICE_INT = Math.Round(dblTemp, 4, MidpointRounding.AwayFromZero);
            }
            else
            {
                objInitial.m_dblOPWHOLESALEPRICE_INT = 0;
            }
            if (double.TryParse(p_drData["PACKQTY_DEC"].ToString(), out dblTemp))
            {
                objInitial.m_dblPACKQTY_DEC = dblTemp;
            }
            else
            {
                objInitial.m_dblPACKQTY_DEC = 0;
            }
            DateTime dtmTemp = DateTime.MinValue;
            if (DateTime.TryParse(p_drData["VALIDPERIOD_DAT"].ToString(), out dtmTemp))
            {
                objInitial.m_dtmVALIDPERIOD_DAT = dtmTemp;
            }
            else
            {
                objInitial.m_dtmVALIDPERIOD_DAT = DateTime.MinValue;
            }

            long lngTemp = 0;
            if (long.TryParse(p_drData["SERIESID_INT"].ToString(), out lngTemp))
            {
                objInitial.m_lngSERIESID_INT = lngTemp;
            }
            else
            {
                objInitial.m_lngSERIESID_INT = 0;
            }
            objInitial.m_strCREATERID = p_drData["CREATERID"].ToString();
            objInitial.m_strDRUGSTOREID_CHR = m_objViewer.m_strDeptID;
            objInitial.m_strEXAMERID = p_drData["examerid"].ToString();
            objInitial.m_strINACCOUNTERID_CHR = p_drData["INACCOUNTERID_CHR"].ToString();
            objInitial.m_strINITIALID_CHR = p_drData["INITIALID_CHR"].ToString();
            objInitial.m_strIPUNIT_CHR = p_drData["IPUNIT_CHR"].ToString();
            objInitial.m_strLOTNO_VCHR = p_drData["LOTNO_VCHR"].ToString();
            objInitial.m_strMEDICINEID_CHR = p_drData["MEDICINEID_CHR"].ToString();
            objInitial.m_strMEDICINENAME_VCH = p_drData["MEDICINENAME_VCHR"].ToString();
            objInitial.m_strMEDSPEC_VCHR = p_drData["MEDSPEC_VCHR"].ToString();
            objInitial.m_strOPUNIT_CHR = p_drData["OPUNIT_CHR"].ToString();
            objInitial.m_strPRODUCTORID_CHR = p_drData["productorid_chr"].ToString();
            return objInitial;
        }
        #endregion

        #region 该行是否为空行

        /// <summary>
        /// 该行是否为空行
        /// </summary>
        /// <param name="p_drCheck">数据行</param>
        /// <returns></returns>
        private bool m_blnCheckIsNullRow(DataRow p_drCheck)
        {
            if (p_drCheck == null)
            {
                return true;
            }
            bool blnAllNull = true;//如果全为空，则不保存，且不提示错误

            for (int iColumn = 0; iColumn < p_drCheck.ItemArray.Length; iColumn++)
            {
                if (p_drCheck.ItemArray[iColumn] != DBNull.Value
                    && iColumn != 14 && iColumn != 16 && iColumn != 19 && iColumn != 20 && iColumn != 22
                    && iColumn != 23 && iColumn != 24)
                {
                    blnAllNull = false;
                    break;
                }
            }

            return blnAllNull;
        }
        #endregion

        #region 对界面上已成功新增的内容的序列号进行更新
        /// <summary>
        /// 对界面上已成功新增的内容的序列号进行更新
        /// </summary>
        /// <param name="p_lngNewSeqArr">新添药品返回的序列号</param>
        /// <param name="p_drNewArr">需更新的数据行</param>
        private void m_mthUpdateSEQ(long[] p_lngNewSeqArr,string[] p_strIDArr ,DataRow[] p_drNewArr)
        {
            if (p_lngNewSeqArr == null || p_lngNewSeqArr.Length == 0 || p_drNewArr == null || p_drNewArr.Length == 0
                || p_lngNewSeqArr.Length != p_lngNewSeqArr.Length)
            {
                return;
            }

            for (int iRow = 0; iRow < p_lngNewSeqArr.Length; iRow++)
            {
                p_drNewArr[iRow]["SERIESID_INT"] = p_lngNewSeqArr[iRow];
                p_drNewArr[iRow]["creatername"] = m_objViewer.LoginInfo.m_strEmpName;
                p_drNewArr[iRow]["createrno"] = m_objViewer.LoginInfo.m_strEmpNo;
                p_drNewArr[iRow]["CREATERID"] = m_objViewer.LoginInfo.m_strEmpID;
                p_drNewArr[iRow]["INITIALID_CHR"] = p_strIDArr[iRow];
            }
        }
        #endregion

        #region 获取药房初始化药品信息
        /// <summary>
        /// 获取药房初始化药品信息
        /// </summary>
        /// <param name="p_strDrugStoreID">药房ID</param>
        /// <param name="p_dtbMedicine">药品信息</param>
        internal void m_mthGetInitilaMedicine(string p_strDrugStoreID, out DataTable p_dtbMedicine)
        {
            long lngRes = m_objDomain.m_lngGetInitilaMedicine(p_strDrugStoreID, m_objViewer.m_blnIsHospital,out p_dtbMedicine);
        } 
        #endregion

        #region 检查是否有未保存的数据
        /// <summary>
        /// 检查是否有未保存的数据
        /// </summary>
        /// <returns></returns>
        internal bool m_blnHasUnSaveData()
        {
            m_objViewer.m_dtgvMedicineDetail.EndEdit();
            m_objViewer.m_txtInputMan.Focus();//让DataView的数据提交至DataTable
            //是否有新添

            DataTable drNew = m_objViewer.m_dtbMedicineDetail.GetChanges(DataRowState.Added);
            if (drNew != null && drNew.Rows.Count > 0)
            {
                return true;
            }

            //是否有修改

            DataTable drModify = m_objViewer.m_dtbMedicineDetail.GetChanges(DataRowState.Modified);
            if (drModify != null && drModify.Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 设置过滤条件，过滤界面

        /// <summary>
        /// 设置过滤条件，过滤界面
        /// </summary>
        internal void m_mthFilter()
        {
            if (m_objViewer.m_dtvCurrentView != null)
            {
                bool blnHasFilter = false;//是否已有条件
                StringBuilder stbFilter = new StringBuilder(50);
                if (m_objViewer.m_txtMedName.Tag != null && !string.IsNullOrEmpty(m_objViewer.m_txtMedName.Text))
                {
                    stbFilter.Append("MEDICINEID_CHR = '");
                    stbFilter.Append(m_objViewer.m_txtMedName.Tag.ToString());
                    stbFilter.Append("' ");
                    blnHasFilter = true;
                }
                if (!string.IsNullOrEmpty(m_objViewer.m_txtInputMan.Text))
                {
                    if (blnHasFilter)
                    {
                        stbFilter.Append(" and (");
                    }
                    stbFilter.Append("creatername like '");
                    stbFilter.Append(m_objViewer.m_txtInputMan.Text);
                    stbFilter.Append("%' or ");
                    stbFilter.Append("createrno like '");
                    stbFilter.Append(m_objViewer.m_txtInputMan.Text);
                    stbFilter.Append("%'");
                    if (blnHasFilter)
                    {
                        stbFilter.Append(")");
                    }
                    blnHasFilter = true;
                }
                if (!string.IsNullOrEmpty(m_objViewer.m_txtCommitMan.Text))
                {
                    if (blnHasFilter)
                    {
                        stbFilter.Append(" and (");
                    }
                    stbFilter.Append("examerno like '");
                    stbFilter.Append(m_objViewer.m_txtCommitMan.Text);
                    stbFilter.Append("%' or ");
                    stbFilter.Append("examername like '");
                    stbFilter.Append(m_objViewer.m_txtCommitMan.Text);
                    stbFilter.Append("%' ");
                    if (blnHasFilter)
                    {
                        stbFilter.Append(")");
                    }
                    blnHasFilter = true;
                }
                if (m_objViewer.m_cboCommitInfo.SelectedIndex > 0)
                {
                    if (m_objViewer.m_cboCommitInfo.SelectedIndex == 1)
                    {
                        if (blnHasFilter)
                        {
                            stbFilter.Append(" and ");
                        }
                        stbFilter.Append("status = '未审核'");
                    }
                    else
                    {
                        if (blnHasFilter)
                        {
                            stbFilter.Append(" and ");
                        }
                        stbFilter.Append("status = '已审核'");
                    }
                }
                m_objViewer.m_dtvCurrentView.RowFilter = stbFilter.ToString();
            }
        }
        #endregion

        #region 审核药品信息
        /// <summary>
        /// 审核药品信息
        /// </summary>
        /// <param name="p_dtbSource">数据源</param>
        internal long m_lngCommitToStorageDetail(DataTable p_dtbSource)
        {
            //clsDcl_Storage objSTDomain = new clsDcl_Storage();

            //20080626 药房初始化改为在界面就合并相同批号的同一药品，在中间件不要再判断是否已存在该批次药品
            DataView dvTemp = p_dtbSource.DefaultView;
            dvTemp.Sort = "MEDICINEID_CHR";
            p_dtbSource = dvTemp.ToTable();
            string strMedicineID = string.Empty;
            string strLotno = string.Empty;            
            DataRow drTemp = null;
            for (int i1 = 0; i1 < p_dtbSource.Rows.Count; i1++)
            {
                drTemp = p_dtbSource.Rows[i1];
                if (drTemp["MEDICINEID_CHR"].ToString() == strMedicineID && drTemp["LOTNO_VCHR"].ToString() == strLotno)
                {
                    p_dtbSource.Rows[i1 - 1]["amount"] = Convert.ToDouble(p_dtbSource.Rows[i1 - 1]["amount"]) + Convert.ToDouble(drTemp["amount"]);
                    p_dtbSource.Rows[i1 - 1]["IPAMOUNT"] = Convert.ToDouble(p_dtbSource.Rows[i1 - 1]["IPAMOUNT"]) + Convert.ToDouble(drTemp["IPAMOUNT"]);
                    p_dtbSource.Rows[i1 - 1]["OPAMOUNT"] = Convert.ToDouble(p_dtbSource.Rows[i1 - 1]["OPAMOUNT"]) + Convert.ToDouble(drTemp["OPAMOUNT"]);

                    drTemp["amount"] = 0;
                    drTemp["IPAMOUNT"] = 0;
                    drTemp["OPAMOUNT"] = 0;
                }
                strMedicineID = drTemp["MEDICINEID_CHR"].ToString();
                strLotno = drTemp["LOTNO_VCHR"].ToString();
            }


            DataRow[] drCommit = p_dtbSource.Select("EXAMERID is null");

            if (drCommit == null || drCommit.Length == 0)
            {
                return 0;
            }

            long lngRes = 0;
            //数据量较大，需分块审核，否则会事务超时
            if (drCommit.Length > 200)
            {
                bool blnSaveComplete = true;//是否全部保存完毕，没有错误


                int intBlock = drCommit.Length / 200;
                int intSur = drCommit.Length % 200;
                if (intSur != 0)
                {
                    intBlock++;
                }

                int intEndIndex = 0;//结束索引
                int intStartIndex = 0;//开始索引

                for (int iBl = 0; iBl < intBlock; iBl++)
                {
                    intStartIndex = 200 * iBl;
                    if (iBl == intBlock - 1 && intSur != 0)//有余数，不是200的整数倍
                    {
                        intEndIndex = drCommit.Length - 1;
                    }
                    else
                    {
                        intEndIndex = intStartIndex + 199;
                    }

                    //新生成分块后的数组

                    int intLength = intEndIndex - intStartIndex + 1;
                    DataRow[] drCurrent = new DataRow[intLength];
                    for (int iDr = intStartIndex; iDr <= intEndIndex; iDr++)
                    {
                        drCurrent[intEndIndex - iDr] = drCommit[iDr];
                    }
                    
                    clsDS_StorageDetail_VO[] objDetailArr = m_mthGetStorageDetailVO(drCurrent);
                    clsDS_Storage_VO[] objStorageArr = m_mthGetStorageVOArr(drCurrent);
                    long[] lngSEQArr = m_lngSEQArr(drCurrent);

                    try
                    {
                        lngRes = m_objDomain.m_lngCommitMedicineInfo(objDetailArr, objStorageArr, lngSEQArr, m_objViewer.LoginInfo.m_strEmpID, m_objViewer.m_blnIsImmAccount);
                        if (lngRes <= 0)
                        {
                            blnSaveComplete = false;
                        }
                        //else
                        //{
                        //    m_mthUpdateUIAfterCommit(drCurrent);
                        //}
                    }
                    catch (Exception Ex)
                    {
                        blnSaveComplete = false;
                        lngRes = -1;
                    }
                    objDetailArr = null;
                    objStorageArr = null;
                    lngSEQArr = null;
                }

                if (!blnSaveComplete)
                {
                    lngRes = -1;
                }
                else
                {
                    lngRes = 1;
                }
            }
            else
            {
                clsDS_StorageDetail_VO[] objDetailArr = m_mthGetStorageDetailVO(drCommit);
                clsDS_Storage_VO[] objStorageArr = m_mthGetStorageVOArr(drCommit);
                long[] lngSEQArr = m_lngSEQArr(drCommit);

                try
                {
                    lngRes = m_objDomain.m_lngCommitMedicineInfo(objDetailArr, objStorageArr, lngSEQArr, m_objViewer.LoginInfo.m_strEmpID, m_objViewer.m_blnIsImmAccount);
                }
                catch (Exception Ex)
                {
                    lngRes = -1;
                }
            }
            return lngRes;
        }

        /// <summary>
        /// 获取库存明细VO
        /// </summary>
        /// <param name="p_drCommit">数据行</param>
        /// <returns></returns>
        private clsDS_StorageDetail_VO[] m_mthGetStorageDetailVO(DataRow[] p_drCommit)
        {
            if (p_drCommit == null || p_drCommit.Length == 0)
            {
                return null;
            }

            clsDS_StorageDetail_VO[] objSDVO = null;
            try
            {
                objSDVO = new clsDS_StorageDetail_VO[p_drCommit.Length];                
                for (int iRow = 0; iRow < p_drCommit.Length; iRow++)
                {
                    objSDVO[iRow] = new clsDS_StorageDetail_VO();
                    objSDVO[iRow].m_strDRUGSTOREID_CHR = m_objViewer.m_strDeptID;
                    objSDVO[iRow].m_strMEDICINEID_CHR = p_drCommit[iRow]["MEDICINEID_CHR"].ToString();
                    objSDVO[iRow].m_strMEDICINENAME_VCHR = p_drCommit[iRow]["MEDICINENAME_VCHR"].ToString();
                    objSDVO[iRow].m_strMEDSPEC_VCHR = p_drCommit[iRow]["MEDSPEC_VCHR"].ToString();
                    objSDVO[iRow].m_strLOTNO_VCHR = p_drCommit[iRow]["LOTNO_VCHR"].ToString();
                    objSDVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drCommit[iRow]["VALIDPERIOD_DAT"]);  
                    objSDVO[iRow].m_strIPUNIT_CHR = p_drCommit[iRow]["IPUNIT_CHR"].ToString();
                    objSDVO[iRow].m_strOPUNIT_CHR = p_drCommit[iRow]["OPUNIT_CHR"].ToString();
                    objSDVO[iRow].m_dblIPREALGROSS_INT = Math.Round(Convert.ToDouble(p_drCommit[iRow]["IPAMOUNT"]),2,MidpointRounding.AwayFromZero);
                    objSDVO[iRow].m_dblOPREALGROSS_INT = Math.Round(Convert.ToDouble(p_drCommit[iRow]["OPAMOUNT"]),2,MidpointRounding.AwayFromZero);
                    objSDVO[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(p_drCommit[iRow]["PACKQTY_DEC"]);
                    objSDVO[iRow].m_dblIPRETAILPRICE_INT = Math.Round(Convert.ToDouble(p_drCommit[iRow]["IPRETAILPRICE_INT"]),4,MidpointRounding.AwayFromZero);
                     objSDVO[iRow].m_dblOPRETAILPRICE_INT = Math.Round(Convert.ToDouble(p_drCommit[iRow]["OPRETAILPRICE_INT"]),4,MidpointRounding.AwayFromZero);
                     try
                     {
                         objSDVO[iRow].m_dblIPWHOLESALEPRICE_INT = Math.Round(Convert.ToDouble(p_drCommit[iRow]["IPWHOLESALEPRICE_INT"]), 4, MidpointRounding.AwayFromZero);
                     }
                     catch
                     {
                     }
                     try
                     {
                         objSDVO[iRow].m_dblOPWHOLESALEPRICE_INT = Math.Round(Convert.ToDouble(p_drCommit[iRow]["OPWHOLESALEPRICE_INT"]), 4, MidpointRounding.AwayFromZero);
                     }
                     catch
                     {
                     }
                    objSDVO[iRow].STATUS = 1;
                    objSDVO[iRow].m_strPRODUCTORID_CHR = p_drCommit[iRow]["productorid_chr"].ToString();
                    objSDVO[iRow].m_strMEDICINETYPEID_CHR = p_drCommit[iRow]["medicinetypeid_chr"].ToString();
                    objSDVO[iRow].m_strDSINSTOREID_VCHR = p_drCommit[iRow]["INITIALID_CHR"].ToString();
                }
            }
            catch (Exception Ex)
            {
                return null;
            }
            return objSDVO;
        }

        /// <summary>
        /// 获取库存主表VO
        /// </summary>
        /// <param name="p_drStorageVO">数据</param>
        /// <returns></returns>
        private clsDS_Storage_VO[] m_mthGetStorageVOArr(DataRow[] p_drStorageVO)
        {
            if (p_drStorageVO == null || p_drStorageVO.Length == 0)
            {
                return null;
            }

            clsDS_Storage_VO[] objStArr = new clsDS_Storage_VO[p_drStorageVO.Length];
            for (int iRow = 0; iRow < p_drStorageVO.Length; iRow++)
            {
                objStArr[iRow] = new clsDS_Storage_VO();
                objStArr[iRow].m_strMEDICINEID_CHR = p_drStorageVO[iRow]["MEDICINEID_CHR"].ToString();
                objStArr[iRow].m_strMEDICINENAME_VCHR = p_drStorageVO[iRow]["MEDICINENAME_VCHR"].ToString();
                objStArr[iRow].m_strMEDSPEC_VCHR = p_drStorageVO[iRow]["MEDSPEC_VCHR"].ToString();
                objStArr[iRow].m_strIPUNIT_CHR = p_drStorageVO[iRow]["IPUNIT_CHR"].ToString();
                //objStArr[iRow].m_dblIPCURRENTGROSS_NUM = Convert.ToDouble(p_drStorageVO[iRow]["StoreAmount"]);
                //objStArr[iRow].m_dblOPCURRENTGROSS_NUM = Convert.ToDouble(p_drStorageVO[iRow]["m_dblOPCURRENTGROSS_NUM"]);
                objStArr[iRow].m_strOPUNIT_CHR = p_drStorageVO[iRow]["OPUNIT_CHR"].ToString();
                //objStArr[iRow].m_lngSERIESID_INT = Convert.ToDecimal(p_drStorageVO[iRow]["BugUnitPrice"]);
                objStArr[iRow].m_strDRUGSTOREID_CHR = m_objViewer.m_strDeptID;

                objStArr[iRow].m_dblOPCURRENTGROSS_NUM = Convert.ToDouble(p_drStorageVO[iRow]["opamount"]);
                objStArr[iRow].m_dblIPCURRENTGROSS_NUM = Convert.ToDouble(p_drStorageVO[iRow]["ipamount"]);
            }
            return objStArr;
        }

        /// <summary>
        /// 设置审核人
        /// </summary>
        /// <param name="p_drCommit">数据</param>
        private long[] m_lngSEQArr(DataRow[] p_drCommit)
        {
            if (p_drCommit == null || p_drCommit.Length == 0)
            {
                return null;
            }

            long[] lngSEQ = new long[p_drCommit.Length];
            for (int iRow = 0; iRow < p_drCommit.Length; iRow++)
            {
                lngSEQ[iRow] = Convert.ToInt64(p_drCommit[iRow]["SERIESID_INT"]);
            }

            return lngSEQ;
        }
        #endregion

        #region 获取药库名字和对应的部门号
        /// <summary>
        /// 获取药库名字和对应的部门号
        /// </summary>
        /// <param name="p_strDrugStoreID">药库ID</param>
        /// <param name="p_strStoreName">药库名称</param>
        /// <param name="p_strDeptID">部门ID</param>
        internal void m_mthGetStoreInfo(string p_strDrugStoreID, out string p_strStoreName,out string p_strDeptID)
        {
            long lngRes = m_objDomain.m_lngGetStoreInfo(p_strDrugStoreID, out p_strStoreName, out p_strDeptID);
        }
        #endregion

        #region 入帐
        /// <summary>
        /// 入帐
        /// </summary>
        internal void m_mthInAccount()
        {
            DataView dvSource = m_objViewer.m_dtgvMedicineDetail.DataSource as DataView;
            DataTable dtbTemp = dvSource.Table;

            if (dtbTemp == null)
            {
                return;
            }

            DataRow[] drCommit = dtbTemp.Select("EXAMERID is not null and INACCOUNTERID_CHR is null");
            if (drCommit == null || drCommit.Length == 0)
            {
                MessageBox.Show("没有需入帐的记录", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long[] lngSEQ = new long[drCommit.Length];
            string[] strInitialID = new string[drCommit.Length];
            for (int iRow = 0; iRow < drCommit.Length; iRow++)
            {
                lngSEQ[iRow] = Convert.ToInt64(drCommit[iRow]["SERIESID_INT"]);
                strInitialID[iRow] = drCommit[iRow]["INITIALID_CHR"].ToString();
            }

            long lngRes = 0;
            try
            {
                lngRes = m_objDomain.m_lngInAccount(lngSEQ, strInitialID, m_objViewer.LoginInfo.m_strEmpID, m_objViewer.m_strDeptID);
            }
            catch (Exception Ex)
            {
                lngRes = -1;
                string strEx = Ex.Message;
            }

            if (lngRes > 0)
            {
                for (int iRow = 0; iRow < drCommit.Length; iRow++)
                {
                    drCommit[iRow]["INACCOUNTERID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
                    drCommit[iRow]["status"] = "已入帐";
                }
                m_objViewer.m_dtbMedicineDetail.AcceptChanges();
                MessageBox.Show("入帐成功", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("入帐失败", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 退审
        /// <summary>
        /// 退审
        /// </summary>
        internal void m_mthUnCommit()
        {
            if (m_objViewer.m_dtgvMedicineDetail.CurrentCell == null)
            {
                MessageBox.Show("请先选择要退审的记录", "原始库存初始化",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataRowView drvCurrent = (DataRowView)m_objViewer.m_dtgvMedicineDetail.Rows[m_objViewer.m_dtgvMedicineDetail.CurrentCell.RowIndex].DataBoundItem;
            if (drvCurrent == null)
            {
                MessageBox.Show("退审失败", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (drvCurrent["SERIESID_INT"] == DBNull.Value)
            {
                MessageBox.Show("该记录未保存，不能进行退审操作", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(drvCurrent["examerno"].ToString()) || !string.IsNullOrEmpty(drvCurrent["INACCOUNTERID_CHR"].ToString()))
            {
                MessageBox.Show("只有审核状态的记录才能退审", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long lngRes = 0;
            try
            {//INSTOREID_VCHR
                lngRes = m_objDomain.m_lngUnCommit(Convert.ToInt64(drvCurrent["SERIESID_INT"]), drvCurrent["INITIALID_CHR"].ToString(), m_objViewer.m_strDeptID,
                    drvCurrent["MEDICINEID_CHR"].ToString(), drvCurrent["LOTNO_VCHR"].ToString(), Convert.ToDouble(drvCurrent["OPAMOUNT"]));
            }
            catch (Exception Ex)
            {
                lngRes = -1;
                string strEx = Ex.Message;
            }
            if (lngRes > 0)
            {
                m_objViewer.m_dtgvMedicineDetail.Rows[m_objViewer.m_dtgvMedicineDetail.CurrentCell.RowIndex].ReadOnly = false;
                m_objViewer.m_dtgvMedicineDetail.Rows[m_objViewer.m_dtgvMedicineDetail.CurrentCell.RowIndex].DefaultCellStyle.BackColor = System.Drawing.SystemColors.Info;
                DataRow drCurrent = drvCurrent.Row;
                drCurrent["examerno"] = DBNull.Value;
                drCurrent["status"] = "未审核";
                m_objViewer.m_dtbMedicineDetail.AcceptChanges();
                MessageBox.Show("退审成功", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("退审失败", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region 计算总金额
        /// <summary>
        /// 计算总金额
        /// </summary>
        internal void m_mthSetTotalMoney()
        {
            m_objViewer.m_lblRetailSubMoney.Text = string.Empty;

            if (m_objViewer.m_dtbMedicineDetail == null || m_objViewer.m_dtbMedicineDetail.Rows.Count == 0)
            {
                return;
            }

            m_dtbMoney = m_objViewer.m_dtbMedicineDetail.DefaultView.ToTable();
            int intRowsCount = m_dtbMoney.Rows.Count;           
            double dblRetailMoney = 0d;
            double dblAmount = 0d;
            double dblPackQty = 0d;
            DataRow drTemp = null;

            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                drTemp = m_dtbMoney.Rows[iRow];
                if (drTemp["OPRETAILPRICE_INT"].ToString().Length == 0)
                {
                    continue;
                }
                if (double.TryParse(Convert.ToString(drTemp["IPAMOUNT"]), out dblAmount) && double.TryParse(Convert.ToString(drTemp["PACKQTY_DEC"]), out dblPackQty))
                {
                    dblRetailMoney += Convert.ToDouble(drTemp["OPRETAILPRICE_INT"]) * dblAmount / dblPackQty;
                }
            }

            //零售金额
            m_objViewer.m_lblRetailSubMoney.Text = dblRetailMoney.ToString("0.0000") + "元";
        }
        #endregion

        #region 是否住院药房
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
        #endregion
    }
}
