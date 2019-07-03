using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 漏盘药品
    /// </summary>
    public class clsCtl_GetMissStorageCheckMedicine : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 窗体
        /// </summary>
        com.digitalwave.iCare.gui.MedicineStore.frmGetMissStorageCheckMedicine m_objViewer;
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_GetStorageCheckMedicine m_objDomain = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 获取盘点药品
        /// </summary>
        public clsCtl_GetMissStorageCheckMedicine()
        {
            m_objDomain = new clsDcl_GetStorageCheckMedicine();
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
            m_objViewer = (frmGetMissStorageCheckMedicine)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化数据源
        /// <summary>
        /// 初始化数据源
        /// </summary>
        internal void m_mthInitDataSource()
        {
            m_objViewer.m_dtbMissMedicine = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("checkmedicineorder_chr"), new DataColumn("assistcode_chr"), new DataColumn("medicineid_chr"), new DataColumn("medicinename_vchr"),
                new DataColumn("medspec_vchr"),new DataColumn("opunit_vchr"), new DataColumn("realgross_int"),new DataColumn("callprice_int",typeof(double)),new DataColumn("wholesaleprice_int",typeof(double)),
                new DataColumn("retailprice_int",typeof(double)),new DataColumn("lotno_vchr"),new DataColumn("instorageid_vchr"),new DataColumn("validperiod_dat",typeof(DateTime)),new DataColumn("productorid_chr"),
                new DataColumn("vendorid_chr"),new DataColumn("medicinepreptype_chr"),new DataColumn("medicinepreptypename_vchr"), new DataColumn("storagerackcode_vchr")};
            m_objViewer.m_dtbMissMedicine.Columns.AddRange(dcColumns);
        } 
        #endregion

        #region 检查漏盘药品
        /// <summary>
        /// 检查漏盘药品
        /// </summary>
        internal void m_mthCheckMedicine()
        {
            m_objViewer.m_dtbMissMedicine.Rows.Clear();

            DataTable dtbStorageMedicine = null;
            long lngRes = 0;
            if (m_objViewer.m_rdbMedicineCode.Checked)
            {
                if (string.IsNullOrEmpty(m_objViewer.m_txtMedicineCode1.Text) || string.IsNullOrEmpty(m_objViewer.m_txtMedicineCode2.Text))
                {
                    MessageBox.Show("请先输入完整查询条件", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_txtMedicineCode1.Focus();
                    return ;
                }

                lngRes = m_objDomain.m_lngGetMedicineByMedicineCode(m_objViewer.m_txtMedicineCode1.Text, m_objViewer.m_txtMedicineCode2.Text, m_objViewer.m_strStorageID, out dtbStorageMedicine);
            }
            else if (m_objViewer.m_rdbMedicinePreptype.Checked)
            {
                if (m_objViewer.m_cboMediciePreptype.SelectedIndex == -1 || m_objViewer.m_cboMediciePreptype.SelectedItem == null)
                {
                    MessageBox.Show("请先选择药品剂型", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_cboMediciePreptype.Focus();
                    return ;
                }

                com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objTypeVO = m_objViewer.m_cboMediciePreptype.SelectedItem as com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO;
                lngRes = m_objDomain.m_lngGetMedicineByMedicinePreptype(objTypeVO.m_strMEDICINEPREPTYPE_CHR, m_objViewer.m_strStorageID, out dtbStorageMedicine);
            }
            else if (m_objViewer.m_rdbMedicineType.Checked)
            {
                if (m_objViewer.m_cboMedicineType.SelectedIndex == -1 || m_objViewer.m_cboMedicineType.SelectedItem == null)
                {
                    MessageBox.Show("请先选择药品类型", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_cboMedicineType.Focus();
                    return ;
                }

                com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO objTypeVO = m_objViewer.m_cboMedicineType.SelectedItem as com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO;
                lngRes = m_objDomain.m_lngGetMedicineByMedicinePreptype(objTypeVO.m_strMedicineTypeID_CHR, m_objViewer.m_strStorageID, out dtbStorageMedicine);
            }
            else
            {
                MessageBox.Show("请先选择查询条件", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtbStorageMedicine == null || dtbStorageMedicine.Rows.Count == 0)
            {
                return;
            }

            if (m_objViewer.m_dtbHasCheckMedicine == null || m_objViewer.m_dtbHasCheckMedicine.Rows.Count == 0)
            {
                m_objViewer.m_dtbMissMedicine.Merge(dtbStorageMedicine, true);
                return;
            }

            DataTable dtbHasCheckCopy = m_objViewer.m_dtbHasCheckMedicine.Copy();
            DataRow[] drNull = dtbHasCheckCopy.Select("medicineid_chr is null");
            if (drNull != null && drNull.Length > 0)
            {
                foreach (DataRow  dr in drNull)
                {
                    dtbHasCheckCopy.Rows.Remove(dr);
                }
            }

            if (dtbHasCheckCopy.Rows.Count == 0)
            {
                m_objViewer.m_dtbMissMedicine.Merge(dtbStorageMedicine, true);
                return;
            }

            dtbHasCheckCopy.PrimaryKey = new DataColumn[] { dtbHasCheckCopy.Columns["medicineid_chr"], dtbHasCheckCopy.Columns["lotno_vchr"], dtbHasCheckCopy.Columns["instorageid_vchr"] };

            dtbHasCheckCopy.Merge(dtbStorageMedicine, true);

            DataRow[] drNewArr = dtbHasCheckCopy.Select("medicinename_vchr is not null");//盘点表字段名为MEDICINENAME_VCH，库存表为MEDICINENAME_VCHR

            dtbHasCheckCopy = null;

            if (drNewArr != null && drNewArr.Length > 0)
            {
                DataRow drTemp = null;
                DataRow drNewRow = null;
                m_objViewer.m_dtbMissMedicine.BeginLoadData();
                for (int iRow = 0; iRow < drNewArr.Length; iRow++)
                {
                    drTemp = drNewArr[iRow];
                    drNewRow = m_objViewer.m_dtbMissMedicine.NewRow();
                    drNewRow["checkmedicineorder_chr"] = drTemp["checkmedicineorder_chr"].ToString();
                    drNewRow["assistcode_chr"] = drTemp["assistcode_chr"].ToString();
                    drNewRow["medicineid_chr"] = drTemp["medicineid_chr"].ToString();
                    drNewRow["medicinename_vchr"] = drTemp["medicinename_vchr"].ToString();
                    drNewRow["medspec_vchr"] = drTemp["MEDSPEC_VCHR"].ToString();
                    drNewRow["opunit_vchr"] = drTemp["opunit_vchr"].ToString();
                    drNewRow["realgross_int"] = drTemp["realgross_int"].ToString();
                    drNewRow["callprice_int"] = drTemp["CALLPRICE_INT"].ToString();
                    drNewRow["wholesaleprice_int"] = drTemp["WHOLESALEPRICE_INT"].ToString();
                    drNewRow["retailprice_int"] = drTemp["RETAILPRICE_INT"].ToString();
                    drNewRow["lotno_vchr"] = drTemp["lotno_vchr"].ToString();
                    drNewRow["instorageid_vchr"] = drTemp["instorageid_vchr"].ToString();
                    drNewRow["validperiod_dat"] = drTemp["validperiod_dat"].ToString();
                    drNewRow["productorid_chr"] = drTemp["PRODUCTORID_CHR"].ToString();
                    drNewRow["vendorid_chr"] = drTemp["vendorid_chr"].ToString();
                    drNewRow["medicinepreptype_chr"] = drTemp["medicinepreptype_chr"].ToString();
                    drNewRow["medicinepreptypename_vchr"] = drTemp["medicinepreptypename_vchr"].ToString();
                    drNewRow["storagerackcode_vchr"] = drTemp["storagerackcode_vchr"].ToString();
                    m_objViewer.m_dtbMissMedicine.LoadDataRow(drNewRow.ItemArray,true);
                }
                m_objViewer.m_dtbMissMedicine.EndLoadData();
            }
        } 
        #endregion

        #region 获取药品制剂类型
        /// <summary>
        /// 获取药品制剂类型
        /// </summary>
        internal void m_mthGetMedicinePreptype()
        {
            com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[] objMPVO = null;
            clsDcl_Purchase objPDomain = new clsDcl_Purchase();
            long lngRes = objPDomain.m_lngGetMedicinePreptype(out objMPVO);
            objPDomain = null;

            if (objMPVO != null && objMPVO.Length > 0)
            {
                m_objViewer.m_cboMediciePreptype.Items.Clear();
                com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objAll = new com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO();
                objAll.m_intFLAGA_INT = 0;
                objAll.m_strMEDICINEPREPTYPE_CHR = string.Empty;
                objAll.m_strMEDICINEPREPTYPENAME_VCHR = "全部";
                m_objViewer.m_cboMediciePreptype.Items.Add(objAll);
                m_objViewer.m_cboMediciePreptype.Items.AddRange(objMPVO);
            }
        }
        #endregion

        #region 获取仓库可见药品类型
        /// <summary>
        /// 获取仓库可见药品类型
        /// </summary>
        internal void m_mthGetMedicineType()
        {
            com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO[] objMTVO = null;
            clsDcl_Purchase objPDomain = new clsDcl_Purchase();
            long lngRes = objPDomain.m_lngGetStorageMedicineType(m_objViewer.m_strStorageID, out objMTVO);
            objPDomain = null;

            if (objMTVO != null && objMTVO.Length > 0)
            {
                m_objViewer.m_cboMedicineType.Items.Clear();
                com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO objAll = new com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO();
                objAll.m_strMedicineTypeID_CHR = string.Empty;
                objAll.m_strMedicineTypeName_VCHR = "全部";
                m_objViewer.m_cboMedicineType.Items.Add(objAll);
                m_objViewer.m_cboMedicineType.Items.AddRange(objMTVO);
            }
        } 
        #endregion

        #region 获取选择的数据
        /// <summary>
        /// 获取选择的数据
        /// </summary>
        /// <returns></returns>
        internal DataRow[] m_drGetSelectedRows()
        {
            List<DataRow> drSelected = new List<DataRow>();
            for (int iRow = 0; iRow < m_objViewer.m_dgvStorageDetail.Rows.Count; iRow++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvStorageDetail.Rows[iRow].Cells[0].Value))
                {
                    DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvStorageDetail.Rows[iRow].DataBoundItem).Row;
                    drSelected.Add(drCurrent);
                }
            }

            if (drSelected.Count > 0)
            {
                return drSelected.ToArray();
            }
            else
            {
                return null;
            }
        } 
        #endregion
    }
}
