using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.IO;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 期初数录入业务操作类
    /// </summary>
    public class clsCtl_InventoryRecord : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_InventoryRecord m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        com.digitalwave.iCare.gui.MedicineStore.frmInventoryRecord m_objViewer;
        /// <summary>
        /// 查询药品字典控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        #endregion

        #region 构造函数
        public clsCtl_InventoryRecord()
        {
            m_objDomain = new clsDcl_InventoryRecord();
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
            m_objViewer = (frmInventoryRecord)frmMDI_Child_Base_in;
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
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("MedicineCode"), new DataColumn("MedicineName"), new DataColumn("MedicineSpec"),
                new DataColumn("StoreAmount"), new DataColumn("MedicineUnit"), new DataColumn("BatchNumber"), new DataColumn("BugUnitPrice"), 
                new DataColumn("WholeSaleUnitPrice"), new DataColumn("SaleUnitPrice"), new DataColumn("Validity"), new DataColumn("SupplierName"),
                new DataColumn("Manufacturer"), new DataColumn("MEDICINEID"), new DataColumn("SERIESID"), new DataColumn("CREATERID"), new DataColumn("EXAMERID"),
                new DataColumn("createrno"), new DataColumn("creatername"), new DataColumn("examerno"), new DataColumn("examername"), new DataColumn("status"),
                new DataColumn("SupplierID"),new DataColumn("medicinetypeid_chr"),new DataColumn("INACCOUNTERID_CHR"), new DataColumn("INITIALID_CHR")};
            p_dtbMedicineTalbe.Columns.AddRange(dcColumns);
        } 
        #endregion

        #region 初始化药品字典最小元素集信息
        /// <summary>
        /// 初始化药品字典最小元素集信息
        /// </summary>
        /// <param name="p_dtbMedicineInfo"></param>
        internal void m_mthInitMedicineInfo(ref DataTable p_dtbMedicineInfo)
        {
            if (p_dtbMedicineInfo == null || p_dtbMedicineInfo.Columns.Count == 0)
            {
                long lngRes = m_objDomain.m_lngGetBaseMedicine(string.Empty,m_objViewer.m_strStorageID, out p_dtbMedicineInfo);
            }
        } 
        #endregion

        #region 显示供应商查询
        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            long lngRes = m_objDomain.m_lngGetVendor(out p_dtbVendor);
        }
        /// <summary>
        /// 显示供应商查询
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// <param name="p_dtbVendor">字典内容</param>
        internal void m_mthShowVendor(string p_strSearchCon, DataTable p_dtbVendor)
        {
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dtgvMedicineDetail.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dtgvMedicineDetail.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryVendor == null)
            {
                m_ctlQueryVendor = new ctlQueryVendor(p_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            }

            int X = rect.X + m_objViewer.m_dtgvMedicineDetail.Location.X;
            int Y = rect.Y + m_objViewer.m_dtgvMedicineDetail.Location.Y + rect.Height;
            //if ((m_objViewer.Size.Height - m_ctlQueryVendor.Location.Y) < m_ctlQueryVendor.Size.Height)
            //{
            //    Y = rect.Y + m_objViewer.m_dtgvMedicineDetail.Location.Y - m_ctlQueryVendor.Size.Height;
            //}
            //if ((m_objViewer.Size.Width - rect.X) < m_ctlQueryVendor.Size.Width)
            //{
            //    X = rect.X + m_objViewer.m_dtgvMedicineDetail.Location.X - (m_ctlQueryVendor.Size.Width - (m_objViewer.Size.Width - rect.X));
            //}

            if ((m_objViewer.Size.Width - X - m_ctlQueryVendor.Width) < m_ctlQueryVendor.Size.Width)
            {
                X = X - m_ctlQueryVendor.Width+cCell.Size.Width;
            }
            if ((m_objViewer.Size.Height - Y) < m_ctlQueryVendor.Size.Height)
            {
                Y = rect.Y + m_objViewer.m_dtgvMedicineDetail.Location.Y - m_ctlQueryVendor.Size.Height;
            }
            m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);

            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.Focus();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            int intRowIndex = ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell.RowIndex;
            int intColumnIndex = ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell.ColumnIndex;

            DataRowView drCurrent = ((frmInventoryRecord)m_objViewer).m_dtvCurrentView[intRowIndex];
            drCurrent["SupplierID"] = MS_VO.m_strVendorID;
            drCurrent["SupplierName"] = MS_VO.m_strVendorName;

            //DataTable dtbSource = m_objViewer.m_dtgvMedicineDetail.DataSource as DataTable;
            //DataRow drV = dtbSource.Rows[intRowIndex];
            //drV["SupplierID"] = MS_VO.m_strVendorID;
            //drV["SupplierName"] = MS_VO.m_strVendorName;

            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.BringToFront();
            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.Focus();
            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell = ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.Rows[intRowIndex].Cells["m_dgvtxtStatus"];
            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell.Selected = true;
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

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

          

            int intRowIndex = ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell.RowIndex;
            int intColumnIndex = ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell.ColumnIndex;

            DataRowView drCurrent = ((frmInventoryRecord)m_objViewer).m_dtvCurrentView[intRowIndex];
            drCurrent["MedicineCode"] = MS_VO.m_strMedicineCode;
            drCurrent["MedicineName"] = MS_VO.m_strMedicineName;
            drCurrent["MedicineSpec"] = MS_VO.m_strMedicineSpec;
            drCurrent["MedicineUnit"] = MS_VO.m_strMedicineUnit;
            drCurrent["Manufacturer"] = MS_VO.m_strManufacturer;
            drCurrent["MEDICINEID"] = MS_VO.m_strMedicineID;
            drCurrent["medicinetypeid_chr"] = MS_VO.m_strMedicineTypeID;

            m_objDomain.m_lngGetMedicineTypeVisionm(MS_VO.m_strMedicineTypeID,out m_objViewer.m_clsTypeVisVO);
            if (m_objViewer.m_clsTypeVisVO != null)
            {
                drCurrent["lotno_int"] = m_objViewer.m_clsTypeVisVO.m_intLotno;
            }

            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.Refresh();

            //DataTable dtbSource = m_objViewer.m_dtgvMedicineDetail.DataSource as DataTable;
            //DataRow drV = dtbSource.Rows[intRowIndex];
            //drV["MedicineCode"] = MS_VO.m_strMedicineCode;
            //drV["MedicineName"] = MS_VO.m_strMedicineName;
            //drV["MedicineSpec"] = MS_VO.m_strMedicineSpec;
            //drV["MedicineUnit"] = MS_VO.m_strMedicineUnit;
            //drV["Manufacturer"] = MS_VO.m_strManufacturer;
            //drV["MEDICINEID"] = MS_VO.m_strMedicineID;

            //((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.BringToFront();
            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.Focus();
            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell = ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.Rows[intRowIndex].Cells["m_dgvtxtStoreAmount"];
            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell.Selected = true;
        }
        #endregion

        #region 获取已录入药品信息
        /// <summary>
        /// 获取已录入药品信息
        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbMedicine">药品信息</param>
        internal void m_lngGetMedicineDetail(string p_strStorageID, out DataTable p_dtbMedicine)
        {
            long lngRes = m_objDomain.m_lngGetMedicineDetail(p_strStorageID, out p_dtbMedicine);
        }
        #endregion

        #region 获取是否默认批号设置
        /// <summary>
        /// 获取是否默认批号设置
        /// </summary>
        /// <param name="p_blnIsSetDefault">是否默认</param>
        internal void m_mthGetBatchNumberDefaultSetting(out bool p_blnIsSetDefault)
        {
            long lngRes = m_objDomain.m_lngGetBatchNumberDefaultSetting(out p_blnIsSetDefault);
        } 
        #endregion

        #region 添加新行
        /// <summary>
        /// 插入新药品信息
        /// </summary>
        internal void m_mthInsertNewMedicine()
        {
            //if (m_objViewer.m_dtbMedicineDetail == null || m_objViewer.m_dtbMedicineDetail.Columns.Count == 0)
            //{
            //    m_mthInitMedicineTalbe(ref m_objViewer.m_dtbMedicineDetail);
            //}
            DataView dtSource = m_objViewer.m_dtgvMedicineDetail.DataSource as DataView;

            DataRowView drNew = dtSource.AddNew();

            if (m_objViewer.m_blnIsSetDefaultBatchNumber)
            {
                drNew["BatchNumber"] = "9999";
            }
            drNew["CREATERID"] = m_objViewer.LoginInfo.m_strEmpID;
            drNew["createrno"] = m_objViewer.LoginInfo.m_strEmpNo;
            drNew["creatername"] = m_objViewer.LoginInfo.m_strEmpName;
            drNew["status"] = "未审核";
            m_objViewer.m_dtgvMedicineDetail.Refresh();

            //dtSource.Rows.Add(drNew);
            m_objViewer.m_dtgvMedicineDetail.Focus();
            m_objViewer.m_dtgvMedicineDetail.CurrentCell = m_objViewer.m_dtgvMedicineDetail[0, m_objViewer.m_dtgvMedicineDetail.RowCount - 1];
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
            DataRow[] drNewArr = dtbNew.Select("SERIESID is null"); 
            clsMS_MedicineInitial_VO[] objNew = m_objGetInitialVO(drNewArr);

            DataTable dtbModify = m_objViewer.m_dtbMedicineDetail.GetChanges(DataRowState.Modified);
            clsMS_MedicineInitial_VO[] objModify = m_objGetInitialVO(dtbModify);

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
                lngRes = m_objDomain.m_lngSaveMedicineInfo(ref objNew, objModify);

                if (lngRes > 0)
                {
                    m_mthUpdateSEQ(objNew, drNewArr);
                    m_objViewer.m_dtbMedicineDetail.AcceptChanges();

                    DataRow[] drNull = m_objViewer.m_dtbMedicineDetail.Select("SERIESID is null");
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
        /// 检查是否都为有效内容        /// </summary>
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

                    if (blnAllNull || p_drNewArr[iRow]["MEDICINEID"] == DBNull.Value)
                    {
                        continue;
                    }
                    //p_drNewArr[iRow]["MEDICINEID"] == DBNull.Value 
                    if ( p_drNewArr[iRow]["StoreAmount"] == DBNull.Value || p_drNewArr[iRow]["BugUnitPrice"] == DBNull.Value
                        || p_drNewArr[iRow]["SaleUnitPrice"] == DBNull.Value || p_drNewArr[iRow]["Validity"] == DBNull.Value)
                    {
                        return false;
                    }
                    else if (!decimal.TryParse(p_drNewArr[iRow]["BugUnitPrice"].ToString(), out dcmTest) || !decimal.TryParse(p_drNewArr[iRow]["SaleUnitPrice"].ToString(), out dcmTest)
                        || !double.TryParse(p_drNewArr[iRow]["MEDICINEID"].ToString(), out dblTest))
                    {
                        return false;
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
                    if (drTemp["MEDICINEID"] == DBNull.Value || drTemp["StoreAmount"] == DBNull.Value || drTemp["BugUnitPrice"] == DBNull.Value
                        || drTemp["SaleUnitPrice"] == DBNull.Value || drTemp["Validity"] == DBNull.Value)
                    {
                        return false;
                    }
                    else if (!decimal.TryParse(drTemp["BugUnitPrice"].ToString(), out dcmTest) || !decimal.TryParse(drTemp["SaleUnitPrice"].ToString(), out dcmTest)
                        || !double.TryParse(drTemp["StoreAmount"].ToString(), out dblTest))
                    {
                        return false;
                    }
                }
            }

            return true;
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
                    && iColumn != 13 && iColumn != 14 && iColumn != 15 && iColumn != 16 && iColumn != 20)
                {
                    blnAllNull = false;
                    break;
                }
            }

            return blnAllNull;
        } 
        #endregion

        #region 获取原始库存VO
        /// <summary>
        /// 获取原始库存VO
        /// </summary>
        /// <param name="p_dtbDataArr">数据表</param>
        /// <returns></returns>
        private clsMS_MedicineInitial_VO[] m_objGetInitialVO(DataTable p_dtbDataArr)
        {
            if (p_dtbDataArr == null || p_dtbDataArr.Rows.Count == 0)
            {
                return null;
            }
            clsMS_MedicineInitial_VO[] objInitialVO = null;
            List<clsMS_MedicineInitial_VO> lstInitialVO = new List<clsMS_MedicineInitial_VO>();
            try
            {
                int intRowsCount = p_dtbDataArr.Rows.Count;
                DataRow drTemp = null;
                clsMS_MedicineInitial_VO objTemp = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = p_dtbDataArr.Rows[iRow];

                    objTemp = new clsMS_MedicineInitial_VO();
                    objTemp.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                    if (drTemp["SERIESID"] != DBNull.Value)
                    {
                        objTemp.m_lngSERIESID_INT = Convert.ToInt64(drTemp["SERIESID"]);
                    }
                    objTemp.m_strMEDICINEID_CHR = drTemp["MEDICINEID"].ToString();
                    objTemp.m_strMEDICINENAME_VCH = drTemp["MedicineName"].ToString();
                    objTemp.m_strMEDSPEC_VCHR = drTemp["MedicineSpec"].ToString();
                    objTemp.m_dblCURRENTGROSS_NUM = Convert.ToDouble(drTemp["StoreAmount"]);
                    objTemp.m_dcmRETAILPRICE_INT = Convert.ToDecimal(drTemp["SaleUnitPrice"]);
                    if (drTemp["WholeSaleUnitPrice"] != DBNull.Value)
                    {
                        objTemp.m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drTemp["WholeSaleUnitPrice"]);
                    }
                    objTemp.m_dcmCALLPRICE_INT = Convert.ToDecimal(drTemp["BugUnitPrice"]);
                    objTemp.m_strVENDORID_CHR = drTemp["SupplierID"].ToString();
                    objTemp.m_strPRODUCTORID_CHR = drTemp["Manufacturer"].ToString();
                    objTemp.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drTemp["Validity"]);

                    if (m_objViewer.m_clsTypeVisVO != null && (m_objViewer.m_clsTypeVisVO.m_intLotno == 0) && (drTemp["BatchNumber"].ToString().Trim() == ""))
                    {
                        objTemp.m_strLOTNO_VCHR = "UNKNOWN";
                    }
                    else
                    {
                        objTemp.m_strLOTNO_VCHR = drTemp["BatchNumber"].ToString();
                    }

                    objTemp.m_strCREATERID = m_objViewer.LoginInfo.m_strEmpID;
                    objTemp.m_strEXAMERID = drTemp["EXAMERID"].ToString();
                    objTemp.m_strOPUNIT_VCHR = drTemp["MedicineUnit"].ToString();
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
        private clsMS_MedicineInitial_VO[] m_objGetInitialVO(DataRow[] p_drDataArr)
        {
            if (p_drDataArr == null || p_drDataArr.Length == 0)
            {
                return null;
            }

            clsMS_MedicineInitial_VO[] objInitialVO = null;
            List<clsMS_MedicineInitial_VO> lstInitialVO = new List<clsMS_MedicineInitial_VO>();
            try
            {
                int intRowsCount = p_drDataArr.Length;

                clsMS_MedicineInitial_VO objTemp = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    if (m_blnCheckIsNullRow(p_drDataArr[iRow]))
                    {
                        continue;
                    }

                    objTemp = new clsMS_MedicineInitial_VO();
                    objTemp.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                    if (p_drDataArr[iRow]["SERIESID"] != DBNull.Value)
                    {
                        objTemp.m_lngSERIESID_INT = Convert.ToInt64(p_drDataArr[iRow]["SERIESID"]);
                    }                    
                    objTemp.m_strMEDICINEID_CHR = p_drDataArr[iRow]["MEDICINEID"].ToString();
                    objTemp.m_strMEDICINENAME_VCH = p_drDataArr[iRow]["MedicineName"].ToString();
                    objTemp.m_strMEDSPEC_VCHR = p_drDataArr[iRow]["MedicineSpec"].ToString();
                    if (p_drDataArr[iRow]["StoreAmount"] != DBNull.Value)
                    {
                        objTemp.m_dblCURRENTGROSS_NUM = Convert.ToDouble(p_drDataArr[iRow]["StoreAmount"]);
                    }
                    if (p_drDataArr[iRow]["SaleUnitPrice"] != DBNull.Value)
                    {
                        objTemp.m_dcmRETAILPRICE_INT = Convert.ToDecimal(p_drDataArr[iRow]["SaleUnitPrice"]);
                    }                    
                    if (p_drDataArr[iRow]["WholeSaleUnitPrice"] != DBNull.Value)
                    {
                        objTemp.m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(p_drDataArr[iRow]["WholeSaleUnitPrice"]);
                    }
                    if (p_drDataArr[iRow]["BugUnitPrice"] != DBNull.Value)
                    {
                        objTemp.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drDataArr[iRow]["BugUnitPrice"]);
                    }                    
                    objTemp.m_strVENDORID_CHR = p_drDataArr[iRow]["SupplierID"].ToString();
                    objTemp.m_strPRODUCTORID_CHR = p_drDataArr[iRow]["Manufacturer"].ToString();
                    if (p_drDataArr[iRow]["Validity"] != DBNull.Value)
                    {
                        objTemp.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drDataArr[iRow]["Validity"]);
                    }

                    if (m_objViewer.m_clsTypeVisVO != null && (m_objViewer.m_clsTypeVisVO.m_intLotno == 0) && (p_drDataArr[iRow]["BatchNumber"].ToString().Trim() == ""))
                    {
                        objTemp.m_strLOTNO_VCHR = "UNKNOWN";
                    }
                    else
                    {
                        objTemp.m_strLOTNO_VCHR = p_drDataArr[iRow]["BatchNumber"].ToString();
                    }

                   // objTemp.m_strLOTNO_VCHR = p_drDataArr[iRow]["BatchNumber"].ToString();

                    objTemp.m_strCREATERID = m_objViewer.LoginInfo.m_strEmpID;
                    objTemp.m_strEXAMERID = p_drDataArr[iRow]["EXAMERID"].ToString();
                    objTemp.m_strOPUNIT_VCHR = p_drDataArr[iRow]["MedicineUnit"].ToString();
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
        #endregion

        #region 对界面上已成功新增的内容的序列号进行更新
        /// <summary>
        /// 对界面上已成功新增的内容的序列号进行更新
        /// </summary>
        /// <param name="p_objNewArr">新添药品</param>
        /// <param name="p_drNewArr">需更新的数据行</param>
        private void m_mthUpdateSEQ(clsMS_MedicineInitial_VO[] p_objNewArr, DataRow[] p_drNewArr)
        {
            if (p_objNewArr == null || p_objNewArr.Length == 0 || p_drNewArr == null || p_drNewArr.Length == 0
                || p_drNewArr.Length != p_objNewArr.Length)
            {
                return;
            }

            for (int iRow = 0; iRow < p_objNewArr.Length; iRow++)
            {
                p_drNewArr[iRow]["SERIESID"] = p_objNewArr[iRow].m_lngSERIESID_INT;
                p_drNewArr[iRow]["creatername"] = m_objViewer.LoginInfo.m_strEmpName;
                p_drNewArr[iRow]["createrno"] = m_objViewer.LoginInfo.m_strEmpNo;
                p_drNewArr[iRow]["CREATERID"] = m_objViewer.LoginInfo.m_strEmpID;
                p_drNewArr[iRow]["status"] = "未审核";
                p_drNewArr[iRow]["INITIALID_CHR"] = p_objNewArr[iRow].m_strINITIALID_CHR;
            }
        } 
        #endregion

        #region 检查数量是否合法
        /// <summary>
        /// 检查数量是否合法
        /// </summary>
        /// <param name="CurrentCell">当前单元格</param>
        /// <param name="CancelJump">是否跳转</param>
        internal void m_mthCheckAmount(System.Windows.Forms.DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell.ColumnIndex == 3)
            {
                if (CurrentCell.Value != null && !string.IsNullOrEmpty(CurrentCell.Value.ToString()))
                {
                    DataView dtbSource = m_objViewer.m_dtgvMedicineDetail.DataSource as DataView;
                    double dblAmount = 0D;
                    if (double.TryParse(CurrentCell.Value.ToString(), out dblAmount))
                    {
                        if (dblAmount < 0)
                        {
                            System.Windows.Forms.MessageBox.Show(m_objViewer.m_dtgvMedicineDetail.Columns[CurrentCell.ColumnIndex].HeaderText + "不能为负数！", "期初数录入", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            CancelJump = true;
                            return;
                        }
                        else
                        {
                            dblAmount = Math.Round(dblAmount, 2);
                            dtbSource[CurrentCell.RowIndex]["StoreAmount"] = dblAmount.ToString();

                            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell = ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.Rows[CurrentCell.RowIndex].Cells["m_dgvtxtBatchNumber"];
                            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell.Selected = true;
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(m_objViewer.m_dtgvMedicineDetail.Columns[CurrentCell.ColumnIndex].HeaderText + "必须为数字！", "期初数录入", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        CancelJump = true;
                        return;
                    }
                }
                else
                {
                    CancelJump = true;
                }
            }
        } 
        #endregion

        #region 检查价格
		/// <summary>
        /// 检查价格
        /// </summary>
        /// <param name="CurrentCell">当前单元格</param>
        /// <param name="CancelJump">是否跳转</param>
        internal void m_mthCheckPrice(System.Windows.Forms.DataGridViewCell CurrentCell, out bool CancelJump)
        {
            CancelJump = false;
            if (CurrentCell.ColumnIndex == 6 || CurrentCell.ColumnIndex == 7 || CurrentCell.ColumnIndex == 8)
            {
                if (CurrentCell.Value != null && !string.IsNullOrEmpty(CurrentCell.Value.ToString()))
                {
                    DataView dtbSource = m_objViewer.m_dtgvMedicineDetail.DataSource as DataView;
                    decimal dcMoney = 0m;
                    if (decimal.TryParse(CurrentCell.Value.ToString(), out dcMoney))
                    {
                        if (dcMoney < 0)
                        {
                            System.Windows.Forms.MessageBox.Show(m_objViewer.m_dtgvMedicineDetail.Columns[CurrentCell.ColumnIndex].HeaderText + "不能为负数！", "期初数录入", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                            CancelJump = true;
                            return;
                        }
                        else
                        {
                            dcMoney = Math.Round(dcMoney, 4);
                            if (CurrentCell.ColumnIndex == 6)
                            {
                                dtbSource[CurrentCell.RowIndex]["BugUnitPrice"] = dcMoney.ToString("0.0000");
                            }
                            else if (CurrentCell.ColumnIndex == 7)
                            {
                                dtbSource[CurrentCell.RowIndex]["WholeSaleUnitPrice"] = dcMoney.ToString("0.0000");
                            }
                            else if (CurrentCell.ColumnIndex == 8)
                            {
                                dtbSource[CurrentCell.RowIndex]["SaleUnitPrice"] = dcMoney.ToString("0.0000");

                                decimal dcWhole = 0m;
                                if (decimal.TryParse(dtbSource[CurrentCell.RowIndex]["WholeSaleUnitPrice"].ToString(),out dcWhole))
                                {
                                    if (dcWhole > dcMoney)
                                    {
                                        CancelJump = true;
                                        System.Windows.Forms.DialogResult drResult = System.Windows.Forms.MessageBox.Show("零售价小于批发价，是否继续","库存初始化",System.Windows.Forms.MessageBoxButtons.YesNo,System.Windows.Forms.MessageBoxIcon.Question);
                                        if (drResult == System.Windows.Forms.DialogResult.No)
                                        {
                                            return;
                                        }
                                        else
                                        {
                                            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell = ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.Rows[CurrentCell.RowIndex].Cells["m_dgvtxtValidity"];
                                            ((frmInventoryRecord)m_objViewer).m_dtgvMedicineDetail.CurrentCell.Selected = true;
                                        }
                                    }
                                }
                            }                            
                        }
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show(m_objViewer.m_dtgvMedicineDetail.Columns[CurrentCell.ColumnIndex].HeaderText + "必须为数字！", "期初数录入", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        CancelJump = true;
                        return;
                    }
                }
                else
                {
                    if (CurrentCell.ColumnIndex != 7)
                    {
                        CancelJump = true;
                    }                    
                }
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
            clsDcl_Storage objSTDomain = new clsDcl_Storage();
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
                    if (iBl == intBlock-1 && intSur != 0)//有余数，不是200的整数倍
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
                    clsMS_StorageDetail[] objDetailArr = m_mthGetStorageDetailVO(drCurrent);
                    clsMS_Storage[] objStorageArr = m_mthGetStorageVOArr(drCurrent);
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
                clsMS_StorageDetail[] objDetailArr = m_mthGetStorageDetailVO(drCommit);
                clsMS_Storage[] objStorageArr = m_mthGetStorageVOArr(drCommit);
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
            #region 废弃旧代码，将操作移至中间件，在同一事务中，保存数据完整性
            //bool blnSaveComplete = true;
            //long lngRes = objSTDomain.m_lngAddNewStorageDetail(objDetailArr);
            //if (lngRes > 0)
            //{
            //    blnSaveComplete = true;
            //}
            //else
            //{
            //    blnSaveComplete = false;
            //}

            //if (!blnSaveComplete)
            //{
            //    return;
            //}
            //System.Collections.Hashtable hstMedicine = new System.Collections.Hashtable();
            //clsMS_Storage objStorage = null;
            //bool blnHasDetail = false;//是否已存在

            //for (int iRow = 0; iRow < drCommit.Length; iRow++)
            //{
            //    objStorage = m_mthGetStorageVO(drCommit[iRow]);
            //    if (!hstMedicine.Contains(drCommit[iRow]["MEDICINEID"].ToString()))
            //    {
            //        long lngCurrentSeriesID = 0;
            //        lngRes = objSTDomain.m_lngCheckHasStorage(drCommit[iRow]["MEDICINEID"].ToString(),m_objViewer.m_strStorageID, out blnHasDetail, out lngCurrentSeriesID);

            //        if (blnHasDetail)
            //        {
            //            if (objStorage != null)
            //            {
            //                lngRes = objSTDomain.m_lngModifyStorageFromInitial(objStorage, lngCurrentSeriesID);
            //            }
            //        }
            //        else
            //        {
            //            if (objStorage != null)
            //            {
            //                lngRes = objSTDomain.m_lngAddNewStorage(ref objStorage);
            //            }
            //            hstMedicine.Add(drCommit[iRow]["MEDICINEID"].ToString(), lngCurrentSeriesID);   
            //        }                                  
            //    }
            //    else
            //    {
            //        lngRes = objSTDomain.m_lngModifyStorageFromInitial(objStorage, Convert.ToInt64(hstMedicine[drCommit[iRow]["MEDICINEID"].ToString()] ));
            //    }
            //}
            //hstMedicine = null;

            //System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
            //for (int iRow = 0; iRow < drCommit.Length; iRow++)
            //{
            //    if (!hstStastic.Contains(drCommit[iRow]["MEDICINEID"].ToString()))
            //    {
            //        hstStastic.Add(drCommit[iRow]["MEDICINEID"].ToString(), objStorage.m_lngSERIESID_INT);
            //        lngRes = objSTDomain.m_lngStatisticsStorage(drCommit[iRow]["MEDICINEID"].ToString(),m_objViewer.m_strStorageID);
            //    }
            //} 
            #endregion
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
                lngSEQ[iRow] = Convert.ToInt64(p_drCommit[iRow]["SERIESID"]);
            }

            return lngSEQ;
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="p_drCommit">数据</param>
        private void m_mthUpdateUIAfterCommit(DataRow[] p_drCommit)
        {
            if (p_drCommit != null)
            {
                for (int iRow = 0; iRow < p_drCommit.Length; iRow++)
                {
                    p_drCommit[iRow]["examerno"] = m_objViewer.LoginInfo.m_strEmpNo;
                    p_drCommit[iRow]["EXAMERID"] = m_objViewer.LoginInfo.m_strEmpID;
                    p_drCommit[iRow]["examername"] = m_objViewer.LoginInfo.m_strEmpName;
                    p_drCommit[iRow]["status"] = "已审核";
                }
            }
        }

        /// <summary>
        /// 获取库存主表VO
        /// </summary>
        /// <param name="p_drStorageVO"></param>
        /// <returns></returns>
        private clsMS_Storage m_mthGetStorageVO(DataRow p_drStorageVO)
        {
            if (p_drStorageVO == null)
            {
                return null;
            }

            clsMS_Storage objSVO = new clsMS_Storage();
            objSVO.m_strMEDICINEID_CHR = p_drStorageVO["MEDICINEID"].ToString();
            objSVO.m_strMEDICINENAME_VCHR = p_drStorageVO["MedicineName"].ToString();
            objSVO.m_strMEDSPEC_VCHR = p_drStorageVO["MedicineSpec"].ToString();
            objSVO.m_strOPUNIT_VCHR = p_drStorageVO["MedicineUnit"].ToString();
            objSVO.m_dblINSTOREGROSS_INT = Convert.ToDouble(p_drStorageVO["StoreAmount"]);
            objSVO.m_dblCURRENTGROSS_NUM = Convert.ToDouble(p_drStorageVO["StoreAmount"]);
            objSVO.m_strVENDORID_CHR = p_drStorageVO["SupplierID"].ToString();
            objSVO.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drStorageVO["BugUnitPrice"]);
            objSVO.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            return objSVO;
        }

        /// <summary>
        /// 获取库存主表VO
        /// </summary>
        /// <param name="p_drStorageVO">数据</param>
        /// <returns></returns>
        private clsMS_Storage[] m_mthGetStorageVOArr(DataRow[] p_drStorageVO)
        {
            if (p_drStorageVO == null || p_drStorageVO.Length == 0)
            {
                return null;
            }

            clsMS_Storage[] objStArr = new clsMS_Storage[p_drStorageVO.Length];
            for (int iRow = 0; iRow < p_drStorageVO.Length; iRow++)
            {
                objStArr[iRow] = new clsMS_Storage();
                objStArr[iRow].m_strMEDICINEID_CHR = p_drStorageVO[iRow]["MEDICINEID"].ToString();
                objStArr[iRow].m_strMEDICINENAME_VCHR = p_drStorageVO[iRow]["MedicineName"].ToString();
                objStArr[iRow].m_strMEDSPEC_VCHR = p_drStorageVO[iRow]["MedicineSpec"].ToString();
                objStArr[iRow].m_strOPUNIT_VCHR = p_drStorageVO[iRow]["MedicineUnit"].ToString();
                objStArr[iRow].m_dblINSTOREGROSS_INT = Convert.ToDouble(p_drStorageVO[iRow]["StoreAmount"]);
                objStArr[iRow].m_dblCURRENTGROSS_NUM = Convert.ToDouble(p_drStorageVO[iRow]["StoreAmount"]);
                objStArr[iRow].m_strVENDORID_CHR = p_drStorageVO[iRow]["SupplierID"].ToString();
                objStArr[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drStorageVO[iRow]["BugUnitPrice"]);
                objStArr[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            }
            return objStArr;
        }

        /// <summary>
        /// 获取库存明细VO
        /// </summary>
        /// <param name="p_drCommit">数据行</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_mthGetStorageDetailVO(DataRow[] p_drCommit)
        {
            if (p_drCommit == null || p_drCommit.Length == 0)
            {
                return null;
            }

            clsMS_StorageDetail[] objSDVO = null;
            try
            {
                objSDVO = new clsMS_StorageDetail[p_drCommit.Length];
                //string strInStorageID = DateTime.Now.ToString("yyyyMMdd") + "7" + "0000";
                for (int iRow = 0; iRow < p_drCommit.Length; iRow++)
                {
                    objSDVO[iRow] = new clsMS_StorageDetail();
                    objSDVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                    objSDVO[iRow].m_strMEDICINEID_CHR = p_drCommit[iRow]["MEDICINEID"].ToString();
                    objSDVO[iRow].m_strMEDICINENAME_VCHR = p_drCommit[iRow]["MedicineName"].ToString();
                    objSDVO[iRow].m_strMEDSPEC_VCHR = p_drCommit[iRow]["MedicineSpec"].ToString();
                    objSDVO[iRow].m_strLOTNO_VCHR = p_drCommit[iRow]["BatchNumber"].ToString();
                    objSDVO[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(p_drCommit[iRow]["SaleUnitPrice"]);
                    objSDVO[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drCommit[iRow]["BugUnitPrice"]);
                    if (p_drCommit[iRow]["WholeSaleUnitPrice"] != DBNull.Value)
                    {
                        objSDVO[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(p_drCommit[iRow]["WholeSaleUnitPrice"]);
                    }
                    objSDVO[iRow].m_dblREALGROSS_INT = Convert.ToDouble(p_drCommit[iRow]["StoreAmount"]);
                    objSDVO[iRow].m_dblAVAILAGROSS_INT = Convert.ToDouble(p_drCommit[iRow]["StoreAmount"]);
                    objSDVO[iRow].m_strOPUNIT_VCHR = p_drCommit[iRow]["MedicineUnit"].ToString();
                    objSDVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drCommit[iRow]["Validity"]);
                    objSDVO[iRow].m_strPRODUCTORID_CHR = p_drCommit[iRow]["Manufacturer"].ToString();
                    objSDVO[iRow].m_strINSTORAGEID_VCHR = p_drCommit[iRow]["INITIALID_CHR"].ToString();
                    objSDVO[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    objSDVO[iRow].m_strVENDORID_CHR = p_drCommit[iRow]["SupplierID"].ToString();
                    objSDVO[iRow].m_strVENDORName = p_drCommit[iRow]["SupplierName"].ToString();
                    objSDVO[iRow].m_strMEDICINETYPEID_CHR = p_drCommit[iRow]["medicinetypeid_chr"].ToString();
                    objSDVO[iRow].m_intStatus = 1;
                }
            }
            catch (Exception Ex)
            {
                return null;
            }
            return objSDVO;
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
                System.Windows.Forms.MessageBox.Show("删除失败","库存初始化",System.Windows.Forms.MessageBoxButtons.OK,System.Windows.Forms.MessageBoxIcon.Error);
            }
            return lngRes;
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
                if (!string.IsNullOrEmpty(m_objViewer.m_txtMedicineID.Text))
                {
                    stbFilter.Append("MedicineCode like '");
                    stbFilter.Append(m_objViewer.m_txtMedicineID.Text);
                    stbFilter.Append("%' ");
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
                m_mthGetAllMoney();
            }
        } 
        #endregion

        #region 检查是否有未保存的数据
        /// <summary>
        /// 检查是否有未保存的数据
        /// </summary>
        /// <returns></returns>
        internal bool m_blnHasUnSaveData()
        {   
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

        #region 计算总金额
        /// <summary>
        /// 计算总金额
        /// </summary>
        internal void m_mthGetAllMoney()
        {
            try
            {
                decimal dcmAllInMoney = 0m;//购入总金额
                decimal dcmAllWholeSaleMoney = 0m;//批发总金额
                decimal dcmAllRetailMoney = 0m;//零售总金额

                if (m_objViewer.m_dtvCurrentView != null)
                {
                    DataRowView drvCurrent = null;
                    for (int iRow = 0; iRow < m_objViewer.m_dtvCurrentView.Count; iRow++)
                    {
                        drvCurrent = m_objViewer.m_dtvCurrentView[iRow];
                        dcmAllInMoney += Convert.ToDecimal(drvCurrent["StoreAmount"]) * Convert.ToDecimal(drvCurrent["BugUnitPrice"]);
                        dcmAllWholeSaleMoney += Convert.ToDecimal(drvCurrent["StoreAmount"]) * Convert.ToDecimal(drvCurrent["WholeSaleUnitPrice"]);
                        dcmAllRetailMoney += Convert.ToDecimal(drvCurrent["StoreAmount"]) * Convert.ToDecimal(drvCurrent["SaleUnitPrice"]);
                    }
                }
                m_objViewer.m_lblAllInMoney.Text = dcmAllInMoney.ToString("0.0000");
                m_objViewer.m_lblAllRetailMoney.Text = dcmAllRetailMoney.ToString("0.0000");
                m_objViewer.m_lblAllWholeSaleMoney.Text = dcmAllWholeSaleMoney.ToString("0.0000");
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
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
                lngSEQ[iRow] = Convert.ToInt64(drCommit[iRow]["SERIESID"]);
                strInitialID[iRow] = drCommit[iRow]["INITIALID_CHR"].ToString();
            }

            long lngRes = 0;
            try
            {
                lngRes = m_objDomain.m_lngInAccount(lngSEQ, strInitialID, m_objViewer.LoginInfo.m_strEmpID, m_objViewer.m_strStorageID);
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

            if (drvCurrent["SERIESID"] == DBNull.Value)
            {
                MessageBox.Show("该记录未保存，不能进行退审操作", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(drvCurrent["EXAMERID"].ToString()) || !string.IsNullOrEmpty(drvCurrent["INACCOUNTERID_CHR"].ToString()))
            {
                MessageBox.Show("只有审核状态的记录才能退审", "原始库存初始化", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            long lngRes = 0;
            try
            {
                lngRes = m_objDomain.m_lngUnCommit(Convert.ToInt64(drvCurrent["SERIESID"]), drvCurrent["INITIALID_CHR"].ToString(), m_objViewer.m_strStorageID,
                    drvCurrent["MEDICINEID"].ToString(), drvCurrent["BatchNumber"].ToString(), Convert.ToDouble(drvCurrent["StoreAmount"]), drvCurrent["supplierid"].ToString(),
                    Convert.ToDecimal(drvCurrent["bugunitprice"]));
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
                drCurrent["EXAMERID"] = DBNull.Value;
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

        #region 导出至Excel
        /// <summary>
        /// 导出至Excel
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
                for (int iOr = 0; iOr < m_objViewer.m_dtgvMedicineDetail.ColumnCount; iOr++)
                {
                    if (iOr > 0)
                    {
                        str += "\t";
                    }
                    str += m_objViewer.m_dtgvMedicineDetail.Columns[iOr].HeaderText;
                }
                sw.WriteLine(str);
                //添加行文本
                StringBuilder objStrBuilder = null;
                for (int iOr = 0; iOr < m_objViewer.m_dtgvMedicineDetail.Rows.Count; iOr++)
                {
                    objStrBuilder = new StringBuilder();
                    for (int jOr = 0; jOr < m_objViewer.m_dtgvMedicineDetail.Columns.Count; jOr++)
                    {
                        if (jOr > 0)
                        {
                            objStrBuilder.Append("\t");
                        }
                        objStrBuilder.Append(m_objViewer.m_dtgvMedicineDetail.Rows[iOr].Cells[jOr].Value.ToString());
                    }
                    sw.WriteLine(objStrBuilder);

                }
                MessageBox.Show("导出成功！", "药品记录", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        #endregion

        #region 打印药品信息        
        /// <summary>
        /// 打印药品信息
        /// </summary>
        /// <param name="p_strReportName">报表名称</param>
        internal void m_mthPrintMedicineDetail(string p_strReportName)
        {
            Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();
            dsData.LibraryList = clsMedicineStoreFormFactory.PBLPath;
            dsData.DataWindowObject = p_strReportName == ""?"inventoryrecord":"inventoryrecord_"+p_strReportName;
            DataTable p_dtbVal = new DataTable();
            p_dtbVal = m_objViewer.m_dtvCurrentView.ToTable();
            dsData.Retrieve(p_dtbVal);
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog_DataStore(dsData, true);
        }
        #endregion
    }
}
