using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 盘点药品顺序设置
    /// </summary>
    public class clsCtl_CheckMedicineOrder : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类       /// </summary>
        private clsDcl_CheckMedicineOrder m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmCheckMedicineOrder m_objViewer;
        /// <summary>
        /// 货架信息查询控件
        /// </summary>
        private ctlShowStoragePack m_ctlStoragePack = null;
        /// <summary>
        /// 货架数据
        /// </summary>
        private DataTable m_dtbStoragePack = null;
        /// <summary>
        /// 查询药品字典控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        #endregion

        #region 构造函数        /// <summary>
        /// 盘点药品顺序设置
        /// </summary>
        public clsCtl_CheckMedicineOrder()
        {
            m_objDomain = new clsDcl_CheckMedicineOrder();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象.
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmCheckMedicineOrder)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化DataTable
        /// <summary>
        /// 初始化DataTable
        /// </summary>
        /// <param name="p_dtbMedicineTalbe"></param>
        internal void m_mthInitMedicineTable(ref DataTable p_dtbMedicineTalbe)
        {
            p_dtbMedicineTalbe = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("checkmedicineorder_chr"), new DataColumn("medicineid_chr"), new DataColumn("storagerackid_chr"), new DataColumn("storageid_chr"),
                new DataColumn("assistcode_chr"),new DataColumn("medicinename_vchr"),new DataColumn("medspec_vchr"),new DataColumn("opunit_chr")};
            p_dtbMedicineTalbe.Columns.AddRange(dcColumns);
        }
        #endregion

        #region 获取仓库名
        /// <summary>
        /// 获取仓库名
        /// </summary>
        internal void m_mthGetStorageName()
        {
            clsDcl_InStorageStatisticsReport objISDomain = new clsDcl_InStorageStatisticsReport();
            string strStorageName = string.Empty;
            long lngRes = objISDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStorageName);
            objISDomain = null;

            m_objViewer.m_txtStorage.Text = strStorageName;
            m_objViewer.m_txtStorage.Tag = m_objViewer.m_strStorageID;
        }
        #endregion

        #region 显示货架查询

        /// <summary>
        /// 获取货架信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetStoragePack(out DataTable p_dtbVendor)
        {
            long lngRes = m_objDomain.m_lngGetStoragePack(m_objViewer.m_strStorageID, 1, out p_dtbVendor);
        }
        /// <summary>
        /// 显示货架查询
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowStoragePack(string p_strSearchCon)
        {
            if (m_ctlStoragePack == null)
            {
                m_mthGetStoragePack(out m_dtbStoragePack);
                m_ctlStoragePack = new ctlShowStoragePack(m_dtbStoragePack);
                m_objViewer.Controls.Add(m_ctlStoragePack);

                int X = m_objViewer.m_txtStoragePack.Location.X;
                int Y = m_objViewer.m_txtStoragePack.Location.Y + m_objViewer.m_txtStoragePack.Size.Height;

                m_ctlStoragePack.Location = new System.Drawing.Point(X, Y);
                m_ctlStoragePack.ReturnInfo += new ReturnStoragePackInfo(m_ctlStoragePack_ReturnInfo);
            }
            m_ctlStoragePack.BringToFront();
            m_ctlStoragePack.m_mthSetSearchText(p_strSearchCon);
            m_ctlStoragePack.Visible = true;
            m_ctlStoragePack.Focus();
        }

        private void m_ctlStoragePack_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_StorInfoVo MS_VO)
        {
            m_objViewer.m_txtStoragePack.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtStoragePack.Tag = MS_VO.m_ID;
            m_objViewer.m_txtStoragePack.Text = MS_VO.m_storName;

            if (m_objViewer.m_dtbMedicineSource != null)
            {
                m_objViewer.m_dtbMedicineSource.Rows.Clear();
            }

            try
            {
                m_objViewer.Cursor = Cursors.WaitCursor;
                DataTable dtbValue = null;
                long lngRes = m_objDomain.m_lngGetCheckMedicineOrder(m_objViewer.m_strStorageID, MS_VO.m_ID, out dtbValue);
                if (dtbValue != null)
                {
                    m_objViewer.m_dtbMedicineSource = dtbValue;
                }
                m_objViewer.m_dtvCurrentView = new DataView(m_objViewer.m_dtbMedicineSource);
                m_objViewer.m_dgvMedicineOrder.DataSource = m_objViewer.m_dtvCurrentView;

                if (m_objViewer.m_dgvMedicineOrder.Rows.Count == 0)
                {
                    m_mthInsertNewMedicineData();
                }
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
            finally
            {
                m_objViewer.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region 初始化药品字典最小元素集信息
        /// <summary>
        /// 初始化药品字典最小元素集信息
        /// </summary>
        /// <param name="p_dtbMedicineInfo"></param>
        internal void m_mthInitMedicineInfo(ref DataTable p_dtbMedicineInfo)
        {
            long lngRes = m_objDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out p_dtbMedicineInfo);
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体


        /// <summary>
        /// 显示药品字典最小元素信息查询窗体        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// <param name="p_dtbMedicint">字典内容</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable p_dtbMedicint)
        {
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvMedicineOrder.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvMedicineOrder.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineOrder.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineOrder.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineOrder.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineOrder.Location.Y - m_ctlQueryMedicint.Size.Height);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        {
            long lngReturn = 1;

            DataRow[] drOld = m_objViewer.m_dtbMedicineSource.Select("MEDICINEID_CHR = '" + p_strMedicineID + "'");
            if (drOld != null && drOld.Length > 0)
            {
                MessageBox.Show("已选择此药，不能重复设置", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            int intRowIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.ColumnIndex;

            if (m_objViewer.m_dtbMedicineSource != null)
            {
                DataRowView drCurrent = m_objViewer.m_dtvCurrentView[intRowIndex];
                drCurrent["assistcode_chr"] = MS_VO.m_strMedicineCode;
                drCurrent["medicinename_vchr"] = MS_VO.m_strMedicineName;
                drCurrent["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
                drCurrent["OPUNIT_CHR"] = MS_VO.m_strMedicineUnit;
                drCurrent["medicineid_chr"] = MS_VO.m_strMedicineID;
            }

            m_mthInsertNewMedicineData();
            //m_objViewer.m_dgvMedicineOrder.Refresh();
            //m_objViewer.m_dgvMedicineOrder.Focus();
            //m_objViewer.m_dgvMedicineOrder.CurrentCell.Selected = true;
        }
        #endregion

        #region 插入新的一行药品出库信息

        /// <summary>
        /// 插入新的一行药品出库信息        /// </summary>
        internal void m_mthInsertNewMedicineData()
        {
            if (m_objViewer.m_dtvCurrentView == null)
            {
                return;
            }

            DataRowView drNew = m_objViewer.m_dtvCurrentView.AddNew();

            string strSort = string.Empty;
            int intRowsCount = m_objViewer.m_dtvCurrentView.Count;
            if (intRowsCount == 0 || intRowsCount == 1)
            {
                string strHeader = m_strGetOrderIDHeader();
                strSort = strHeader + "00000001";
            }
            else
            {
                long lngSort = Convert.ToInt64(m_objViewer.m_dtvCurrentView[intRowsCount - 2]["checkmedicineorder_chr"]);
                strSort = (lngSort + 1).ToString("000000000000");
            }

            drNew["checkmedicineorder_chr"] = strSort;
            drNew["storageid_chr"] = m_objViewer.m_strStorageID;
            drNew["storagerackid_chr"] = m_objViewer.m_txtStoragePack.Tag;

            m_objViewer.m_dgvMedicineOrder.Focus();
            m_objViewer.m_dgvMedicineOrder.CurrentCell = m_objViewer.m_dgvMedicineOrder[2, m_objViewer.m_dgvMedicineOrder.RowCount - 1];
        }
        #endregion

        #region 获取顺序ID头
        /// <summary>
        /// 获取顺序ID头(根据设置可以为当前仓库ID或货架ID) 
        /// </summary>
        /// <returns></returns>
        private string m_strGetOrderIDHeader()
        {
            string strHeader = string.Empty;
            if (m_objViewer.m_txtStoragePack.Visible)
            {
                if (m_objViewer.m_txtStoragePack.Tag != null)
                {
                    strHeader = m_objViewer.m_txtStoragePack.Tag.ToString();
                }
                else
                {
                    strHeader = m_objViewer.m_strStorageID;
                }
            }
            else
            {
                strHeader = m_objViewer.m_strStorageID;
            }
            return strHeader;
        } 
        #endregion

        #region 检查药库是否存在货架设置
        /// <summary>
        /// 检查药库是否存在货架设置
        /// </summary>
        internal void m_mthCheckHasStoragePack()
        {
            int intHasPack = 1;
            long lngRes = m_objDomain.m_lngGetHasStoragePack(out intHasPack);
            if (intHasPack == 1)
            {
                m_objViewer.m_txtStoragePack.Visible = true;
                m_objViewer.m_lblPack.Visible = true;
            }
            else
            {
                m_objViewer.m_txtStoragePack.Visible = false;
                m_objViewer.m_lblPack.Visible = false;
            }
        } 
        #endregion

        #region 获取药品顺序数据
        /// <summary>
        /// 获取药品顺序数据
        /// </summary>
        internal void m_mthGetCheckMedicineOrder()
        {
            DataTable dtb = new DataTable();
            m_mthInitMedicineTable(ref dtb);
            m_objViewer.m_dtbMedicineSource.Clear();
            long lngRes = m_objDomain.m_lngGetCheckMedicineOrder(m_objViewer.m_strStorageID, m_objViewer.m_txtStoragePack.Tag.ToString(), out m_objViewer.m_dtbMedicineSource);
            m_objViewer.m_dtvCurrentView = new DataView(m_objViewer.m_dtbMedicineSource);
            m_objViewer.m_dgvMedicineOrder.DataSource = m_objViewer.m_dtvCurrentView;
        }
        #endregion

        #region 获取药品顺序数据(无货架)
        /// <summary>
        /// 获取药品顺序数据(无货架)
        /// </summary>
        internal void m_mthGetCheckMedicineOrderWithoutPack()
        {
            DataTable dtb = new DataTable();
            m_mthInitMedicineTable(ref dtb);
            m_objViewer.m_dtbMedicineSource.Clear();
            long lngRes = m_objDomain.m_lngGetCheckMedicineOrderWithoutPack(m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicineSource);
            m_objViewer.m_dtvCurrentView = new DataView(m_objViewer.m_dtbMedicineSource);
            m_objViewer.m_dgvMedicineOrder.DataSource = m_objViewer.m_dtvCurrentView;
        } 
        #endregion

        #region 保存药品顺序设置
        /// <summary>
        /// 保存药品顺序设置
        /// </summary>
        internal long m_lngSaveMedicinOrder()
        {
            if (m_objViewer.m_dtbMedicineSource == null || m_objViewer.m_dtbMedicineSource.Rows.Count == 0)
            {
                return 0;
            }

            long lngRes = 0;

            DataRow[] drNull = m_objViewer.m_dtbMedicineSource.Select("medicinename_vchr is null");
            if (drNull != null && drNull.Length > 0)
            {
                foreach (DataRow dr in drNull)
                {
                    m_objViewer.m_dtbMedicineSource.Rows.Remove(dr);
                }
            }

            DataTable dtbNew = m_objViewer.m_dtbMedicineSource.GetChanges(DataRowState.Added);

            if (dtbNew != null)
            {
                int intRowsCount = dtbNew.Rows.Count;
                if (intRowsCount > 0)
                {
                    clsMS_CheckMedicineOrderVO[] objNew = m_objGetOrderVO(dtbNew);
                    lngRes = m_objDomain.m_lngAddNewCheckMedicineOrder(objNew);

                    if (lngRes <= 0)
                    {
                        MessageBox.Show("保存失败","药品盘点顺序设置",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }

            DataTable dtbModify = m_objViewer.m_dtbMedicineSource.GetChanges(DataRowState.Modified);
            if (dtbModify != null)
            {
                int intRowsCount = dtbModify.Rows.Count;
                if (intRowsCount > 0)
                {
                    clsMS_CheckMedicineOrderVO[] objModify = m_objGetOrderVO(dtbModify);
                    if (m_objViewer.m_txtStoragePack.Visible)
                    {
                        lngRes = m_objDomain.m_lngModifyCheckOrder(objModify);
                    }
                    else
                    {
                        lngRes = m_objDomain.m_lngModifyCheckOrderWithoutPack(objModify);
                    }
                   

                    if (lngRes <= 0)
                    {
                        MessageBox.Show("保存失败", "药品盘点顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }
            }
            return lngRes;
        } 
        #endregion

        #region 获取盘点顺序VO
        /// <summary>
        /// 获取盘点顺序VO
        /// </summary>
        /// <param name="p_dtbSource">数据源</param>
        /// <returns></returns>
        internal clsMS_CheckMedicineOrderVO[] m_objGetOrderVO(DataTable p_dtbSource)
        {
            if (p_dtbSource == null || p_dtbSource.Rows.Count == 0)
            {
                return null;
            }
           

            string strPackID = string.Empty;
            if (m_objViewer.m_txtStoragePack.Tag != null)
            {
                strPackID = m_objViewer.m_txtStoragePack.Tag.ToString();
            }

            int intRowsCount = p_dtbSource.Rows.Count;
            clsMS_CheckMedicineOrderVO[] objOrderVO = new clsMS_CheckMedicineOrderVO[intRowsCount];
            DataRow drTemp = null;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                drTemp = p_dtbSource.Rows[iRow];
                objOrderVO[iRow] = new clsMS_CheckMedicineOrderVO();
                objOrderVO[iRow].m_strCHECKMEDICINEORDER_CHR = drTemp["checkmedicineorder_chr"].ToString();
                objOrderVO[iRow].m_strMEDICINEID_CHR = drTemp["medicineid_chr"].ToString();
                objOrderVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objOrderVO[iRow].m_strSTORAGERACKID_CHR = strPackID;
            }
            return objOrderVO;
        }

        /// <summary>
        /// 获取盘点顺序VO
        /// </summary>
        /// <param name="p_drvSource">数据源</param>
        /// <returns></returns>
        internal clsMS_CheckMedicineOrderVO m_objGetOrderVO(DataRowView p_drvSource)
        {
            if (p_drvSource == null)
            {
                return null;
            }

            string strPackID = string.Empty;
            if (m_objViewer.m_txtStoragePack.Tag != null)
            {
                strPackID = m_objViewer.m_txtStoragePack.Tag.ToString();
            }

            clsMS_CheckMedicineOrderVO objOrderVO = new clsMS_CheckMedicineOrderVO();
            objOrderVO.m_strCHECKMEDICINEORDER_CHR = p_drvSource["checkmedicineorder_chr"].ToString();
            objOrderVO.m_strMEDICINEID_CHR = p_drvSource["medicineid_chr"].ToString();
            objOrderVO.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            objOrderVO.m_strSTORAGERACKID_CHR = strPackID;

            return objOrderVO;
        } 
        #endregion


        #region 删除选定盘点药品顺序设置
        /// <summary>
        /// 删除选定盘点药品顺序设置
        /// </summary>
        internal void m_mthDeleteMedicinOrder()
        {
            if (m_objViewer.m_dtvCurrentView == null || m_objViewer.m_dtvCurrentView.Count == 0)
            {
                return;
            }

            DataRow dtvDtr = null;
            List<clsMS_CheckMedicineOrderVO> lstOrder = new List<clsMS_CheckMedicineOrderVO>();
            List<int> lstDelRow = new List<int>();//需删除的索引
            List<int> lstNewRow = new List<int>();//未保存过的新行
            for (int iRow = 0; iRow < m_objViewer.m_dgvMedicineOrder.Rows.Count; iRow++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMedicineOrder.Rows[iRow].Cells[0].Value))
                {
                    if (m_objViewer.m_dtvCurrentView[iRow]["medicinename_vchr"] == DBNull.Value)
                    {
                        lstNewRow.Add(iRow);
                    }
                    else
                    {
                        dtvDtr = m_objViewer.m_dtvCurrentView[iRow].Row;
                        clsMS_CheckMedicineOrderVO objOrder = m_objGetOrderVO(m_objViewer.m_dtvCurrentView[iRow]);
                        if (objOrder != null)
                        {
                            lstOrder.Add(objOrder);
                            lstDelRow.Add(iRow);
                        }
                    }                    
                }
            }

            if (lstOrder.Count > 0)
            {

                if (m_objViewer.m_txtStoragePack.Visible)
                {
                    long lngRes = m_objDomain.m_lngDeleteMedicineOrder(lstOrder.ToArray());
                }
                else
                {
                    long lngRes = m_objDomain.m_lngDeleteMedicineOrderWithoutPack(lstOrder.ToArray());
                }
                if (lstNewRow.Count > 0)
                {
                    lstDelRow.AddRange(lstNewRow.ToArray());
                }

                lstDelRow.Sort();
               
                for (int iDel = lstDelRow.Count - 1; iDel >= 0; iDel--)
                {
                    m_objViewer.m_dtvCurrentView.Delete(lstDelRow[iDel]);
                }
                m_mthSetAllOrderSort();
                MessageBox.Show("删除成功", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 重新设置所有行的顺序
        /// <summary>
        /// 重新设置所有行的顺序
        /// </summary>
        internal void m_mthSetAllOrderSort()
        {
            if (m_objViewer.m_dtvCurrentView == null)
            {
                return;
            }

            int intRowsCount = m_objViewer.m_dtvCurrentView.Count;
            string strHeader = m_strGetOrderIDHeader();
            DataRowView drvTemp = null;
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                drvTemp = m_objViewer.m_dtvCurrentView[iRow];
                string strOrderID = drvTemp["checkmedicineorder_chr"].ToString();//当前保存顺序号
                string strRightOrder = strHeader + (iRow + 1).ToString("00000000");//正确的顺序号
                if (strOrderID != strRightOrder)
                {
                    drvTemp.BeginEdit();
                    drvTemp["checkmedicineorder_chr"] = strRightOrder;
                    drvTemp.EndEdit();
                }
            }

            m_lngSaveMedicinOrder();
        } 
        #endregion

        #region 选择行向上移动
        /// <summary>
        /// 选择行向上移动
        /// </summary>
        internal void m_mthSelectRowUp()
        {
            if (m_objViewer.m_dgvMedicineOrder.Rows.Count == 0)
            {
                return;
            }

            if (m_objViewer.m_dgvMedicineOrder.CurrentCell == null)
            {
                MessageBox.Show("请先选择一行", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.ColumnIndex;
            if (intRowIndex == 0)
            {
                return;
            }

            string strCurrentOrder = m_objViewer.m_dtvCurrentView[intRowIndex]["checkmedicineorder_chr"].ToString();//当前顺序号
            string strPreOrder = m_objViewer.m_dtvCurrentView[intRowIndex-1]["checkmedicineorder_chr"].ToString();//上一行顺序号

            //向上移动，即将选择行的顺序号与上一行调换
            m_objViewer.m_dtvCurrentView[intRowIndex].BeginEdit();
            m_objViewer.m_dtvCurrentView[intRowIndex - 1].BeginEdit();

            m_objViewer.m_dtvCurrentView[intRowIndex]["checkmedicineorder_chr"] = strPreOrder;
            m_objViewer.m_dtvCurrentView[intRowIndex - 1]["checkmedicineorder_chr"] = strCurrentOrder;

            m_objViewer.m_dtvCurrentView[intRowIndex].EndEdit();
            m_objViewer.m_dtvCurrentView[intRowIndex - 1].EndEdit();

            m_objViewer.m_dtvCurrentView.Sort = "checkmedicineorder_chr";
            m_objViewer.m_dgvMedicineOrder.CurrentCell = m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex - 1].Cells[intColumnIndex];
            m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex-1].Selected = true;

            m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex].Cells[0].Value = false;
            m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex - 1].Cells[0].Value = true;
        } 
        #endregion

        #region 选择行向下移动
        /// <summary>
        /// 选择行向下移动
        /// </summary>
        internal void m_mthSelectRowDown()
        {
            if (m_objViewer.m_dgvMedicineOrder.Rows.Count == 0)
            {
                return;
            }

            if (m_objViewer.m_dgvMedicineOrder.CurrentCell == null)
            {
                MessageBox.Show("请先选择一行", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.ColumnIndex;
            if (intRowIndex == m_objViewer.m_dgvMedicineOrder.Rows.Count - 1)
            {
                return;
            }

            string strCurrentOrder = m_objViewer.m_dtvCurrentView[intRowIndex]["checkmedicineorder_chr"].ToString();//当前顺序号
            string strNextOrder = m_objViewer.m_dtvCurrentView[intRowIndex + 1]["checkmedicineorder_chr"].ToString();//下一行顺序号

            //向下移动，即将选择行的顺序号与下一行调换
            m_objViewer.m_dtvCurrentView[intRowIndex].BeginEdit();
            m_objViewer.m_dtvCurrentView[intRowIndex + 1].BeginEdit();

            m_objViewer.m_dtvCurrentView[intRowIndex]["checkmedicineorder_chr"] = strNextOrder;
            m_objViewer.m_dtvCurrentView[intRowIndex + 1]["checkmedicineorder_chr"] = strCurrentOrder;

            m_objViewer.m_dtvCurrentView[intRowIndex].EndEdit();
            m_objViewer.m_dtvCurrentView[intRowIndex + 1].EndEdit();

            m_objViewer.m_dtvCurrentView.Sort = "checkmedicineorder_chr";
            m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex].Cells[0].Value = false;
            m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex + 1].Cells[0].Value = true;
            m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex + 1].Selected = true;
            m_objViewer.m_dgvMedicineOrder.CurrentCell = m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex + 1].Cells[intColumnIndex];
        } 
        #endregion

        #region 向上移动至指定行
        /// <summary>
        /// 向上移动至指定行
        /// </summary>
        /// <param name="p_intSpecIndex">指定行索引</param>
        internal void m_mthUpToSpecifyRow(int p_intSpecIndex)
        {
            if (m_objViewer.m_dgvMedicineOrder.Rows.Count == 0 || p_intSpecIndex < 0)
            {
                return;
            }

            if (m_objViewer.m_dgvMedicineOrder.CurrentCell == null)
            {
                MessageBox.Show("请先选择一行", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.ColumnIndex;
            if (intRowIndex == 0 && p_intSpecIndex == 0)
            {
                return;
            }

            string strFirstOrder = m_objViewer.m_dtvCurrentView[p_intSpecIndex]["checkmedicineorder_chr"].ToString();//指定行顺序号

            //向上移动至指定行，即将选择行的顺序号更改为指定行的顺序号，原行号小于选择行的顺序号均加一
            m_objViewer.m_dtvCurrentView[intRowIndex].BeginEdit();
            m_objViewer.m_dtvCurrentView[intRowIndex]["checkmedicineorder_chr"] = strFirstOrder;

            List<DataRowView> drvModify = new List<DataRowView>();//为防止因DataView排序而使索引变化，先记录需要修改的行
            for (int iRow = p_intSpecIndex; iRow < intRowIndex; iRow++)
            {
                drvModify.Add(m_objViewer.m_dtvCurrentView[iRow]);
            }

            for (int iRow = 0; iRow < drvModify.Count; iRow++)
            {
                drvModify[iRow].BeginEdit();
                drvModify[iRow]["checkmedicineorder_chr"] = (Convert.ToInt64(drvModify[iRow]["checkmedicineorder_chr"]) + 1).ToString("000000000000");
                drvModify[iRow].EndEdit();
            }

            m_objViewer.m_dtvCurrentView[intRowIndex].EndEdit();
            m_objViewer.m_dtvCurrentView.Sort = "checkmedicineorder_chr";
            m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex].Cells[0].Value = false;
            m_objViewer.m_dgvMedicineOrder.Rows[p_intSpecIndex].Cells[0].Value = true;
            m_objViewer.m_dgvMedicineOrder.Rows[p_intSpecIndex].Selected = true;
            m_objViewer.m_dgvMedicineOrder.CurrentCell = m_objViewer.m_dgvMedicineOrder.Rows[p_intSpecIndex].Cells[intColumnIndex];
        } 
        #endregion

        #region 向下移动至指定行
        /// <summary>
        /// 向下移动至指定行
        /// </summary>
        /// <param name="p_intSpecIndex">指定行索引</param>
        internal void m_mthDownToSpecifyRow(int p_intSpecIndex)
        {
            if (m_objViewer.m_dgvMedicineOrder.Rows.Count == 0 || p_intSpecIndex < 0)
            {
                return;
            }

            if (m_objViewer.m_dgvMedicineOrder.CurrentCell == null)
            {
                MessageBox.Show("请先选择一行", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.ColumnIndex;
            int intRowsCount = m_objViewer.m_dgvMedicineOrder.Rows.Count;
            if (intRowIndex == intRowsCount - 1 && p_intSpecIndex == intRowsCount - 1)
            {
                return;
            }

            string strLastOrder = m_objViewer.m_dtvCurrentView[p_intSpecIndex]["checkmedicineorder_chr"].ToString();//指定行顺序号

            //向下移动至指定行，即将选择行的顺序号更改为指定行的顺序号，原行号大于选择行的顺序号均减一
            m_objViewer.m_dtvCurrentView[intRowIndex].BeginEdit();
            m_objViewer.m_dtvCurrentView[intRowIndex]["checkmedicineorder_chr"] = strLastOrder;

            List<DataRowView> drvModify = new List<DataRowView>();//为防止因DataView排序而使索引变化，先记录需要修改的行
            for (int iRow = p_intSpecIndex; iRow > intRowIndex; iRow--)
            {
                drvModify.Add(m_objViewer.m_dtvCurrentView[iRow]);
            }

            for (int iRow = 0; iRow < drvModify.Count; iRow++)
            {
                drvModify[iRow].BeginEdit();
                drvModify[iRow]["checkmedicineorder_chr"] = (Convert.ToInt64(drvModify[iRow]["checkmedicineorder_chr"]) - 1).ToString("000000000000");
                drvModify[iRow].EndEdit();
            }

            m_objViewer.m_dtvCurrentView[intRowIndex].EndEdit();
            m_objViewer.m_dtvCurrentView.Sort = "checkmedicineorder_chr";
            m_objViewer.m_dgvMedicineOrder.Rows[intRowIndex].Cells[0].Value = false;
            m_objViewer.m_dgvMedicineOrder.Rows[p_intSpecIndex].Cells[0].Value = true;
            m_objViewer.m_dgvMedicineOrder.Rows[p_intSpecIndex].Selected = true;
            m_objViewer.m_dgvMedicineOrder.CurrentCell = m_objViewer.m_dgvMedicineOrder.Rows[p_intSpecIndex].Cells[intColumnIndex];
        } 
        #endregion

        #region 跳转至指定行
        /// <summary>
        /// 跳转至指定行
        /// </summary>
        internal void m_mthJumpToSpecifyRow()
        {
            if (m_objViewer.m_dgvMedicineOrder.Rows.Count == 0 )
            {
                return;
            }

            if (string.IsNullOrEmpty( m_objViewer.m_txtJumpToRow.Text))
            {
                MessageBox.Show("请先填写跳转目标行数","盘点药品顺序设置",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            int intTarget = 0;
            if (!int.TryParse(m_objViewer.m_txtJumpToRow.Text,out intTarget))
            {
                MessageBox.Show("跳转目标行数必须为大于零的整数", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                if (intTarget == 0)
                {
                    MessageBox.Show("跳转目标行数必须为大于零的整数", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (intTarget > m_objViewer.m_dgvMedicineOrder.Rows.Count)
            {
                MessageBox.Show("跳转目标行数必须为小于总行数", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (m_objViewer.m_dgvMedicineOrder.CurrentCell == null)
            {
                MessageBox.Show("请先选择要跳转的行", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int intRowsIndex = m_objViewer.m_dgvMedicineOrder.CurrentCell.RowIndex;

            if (intRowsIndex == intTarget - 1)
            {
                return;
            }
            else if (intRowsIndex < intTarget - 1)
            {
                m_mthDownToSpecifyRow(intTarget - 1);
            }
            else
            {
                m_mthUpToSpecifyRow(intTarget - 1);
            }
        } 
        #endregion

        #region 导入药品
        internal void m_mthCheckMedicine()
        {
          
            frmGetStorageCheckMedicine frmGet = new frmGetStorageCheckMedicine(m_objViewer.m_strStorageID);
            frmGet.ShowDialog();

            if (frmGet.m_DtbStorageMedicine != null && frmGet.m_DtbStorageMedicine.Rows.Count != 0)
            {
                
                //去除空行
                 DataRow[] drNull = m_objViewer.m_dtbMedicineSource.Select("medicineid_chr is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow dr in drNull)
                    {
                        m_objViewer.m_dtbMedicineSource.Rows.Remove(dr);
                    }
                }

                DataTable dtbDetailCopy = m_objViewer.m_dtbMedicineSource.Copy();//获取界面数据的拷贝
                dtbDetailCopy.PrimaryKey = new DataColumn[] { dtbDetailCopy.Columns["medicineid_chr"] };
                dtbDetailCopy.AcceptChanges();
                int intViewRow = m_objViewer.m_dtbMedicineSource.Rows.Count;
                dtbDetailCopy.Merge(frmGet.m_DtbStorageMedicine, true);

                DataTable dtbGetNewMedicine = dtbDetailCopy.GetChanges(DataRowState.Unchanged);//原记录没有的新增药品
                //此做法是为了保持原有记录的DataRowState不发生变化
                if (dtbGetNewMedicine != null)
                {
                    string strSort;
                    if (m_objViewer.m_dgvMedicineOrder.Rows.Count == 0 || m_objViewer.m_dtbMedicineSource.Rows.Count == 0)
                    {
                        string strHeader = m_strGetOrderIDHeader();
                        strSort = strHeader + "00000000";
                    }
                    else
                    {
                        strSort = m_objViewer.m_dtbMedicineSource.Rows[m_objViewer.m_dtbMedicineSource.Rows.Count - 1]["checkmedicineorder_chr"].ToString();
                    }
                    int intRowsCount = dtbGetNewMedicine.Rows.Count;
                    m_objViewer.m_dtbMedicineSource.BeginLoadData();
                    for (int iRow = 0; iRow < intRowsCount; iRow++)
                    {
                        long lngSort = Convert.ToInt64(strSort);
                        strSort = (lngSort + 1).ToString("000000000000");
                        dtbGetNewMedicine.Rows[iRow]["checkmedicineorder_chr"] = strSort;
                        dtbGetNewMedicine.Rows[iRow]["storageid_chr"] = m_objViewer.m_strStorageID;
                        dtbGetNewMedicine.Rows[iRow]["storagerackid_chr"] = m_objViewer.m_txtStoragePack.Tag;
                        m_objViewer.m_dtbMedicineSource.LoadDataRow(dtbGetNewMedicine.Rows[iRow].ItemArray, false);
                    }
                    m_objViewer.m_dtbMedicineSource.EndLoadData();
                }

                //string strHeader = m_strGetOrderIDHeader();
                //string strSort = strHeader + "00000000";
                //for (int iRow = 0; iRow < m_objViewer.m_dtbMedicineSource.Rows.Count; iRow++)
                //{
                //    long lngSort = Convert.ToInt64(strSort);
                //    strSort = (lngSort + 1).ToString("000000000000");
                //    m_objViewer.m_dtbMedicineSource.Rows[iRow]["storageid_chr"] = m_objViewer.m_strStorageID;
                //    m_objViewer.m_dtbMedicineSourcez.Rows[iRow]["checkmedicineorder_chr"] = strSort;
                //    m_objViewer.m_dtbMedicineSource.Rows[iRow]["storagerackid_chr"] = m_objViewer.m_txtStoragePack.Tag;
                //}
            }
        }
        #endregion
    }
}
