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
    /// 漏盘药品
    /// </summary>
    public class clsCtl_GetMissStoreCheckMedicine : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 窗体
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmGetMissStoreCheckMedicine m_objViewer;
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_GetStoreCheckMedicine m_objDomain = null;
        
        #endregion

        #region 构造函数

        /// <summary>
        /// 获取盘点药品
        /// </summary>
        public clsCtl_GetMissStoreCheckMedicine()
        {
            m_objDomain = new clsDcl_GetStoreCheckMedicine();
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
            m_objViewer = (frmGetMissStoreCheckMedicine)frmMDI_Child_Base_in;
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
                new DataColumn("medspec_vchr"),new DataColumn("unit_chr"),new DataColumn("opunit_chr"),new DataColumn("ipunit_chr"), new DataColumn("realgross_int"),new DataColumn("callprice_int",typeof(double)),new DataColumn("wholesaleprice_int",typeof(double)),
                new DataColumn("retailprice_int",typeof(double)),new DataColumn("lotno_vchr"),new DataColumn("indrugstoreid_vchr"),new DataColumn("validperiod_dat",typeof(DateTime)),new DataColumn("productorid_chr"),
                new DataColumn("medicinepreptype_chr"),new DataColumn("medicinepreptypename_vchr"), new DataColumn("storagerackcode_vchr"),new DataColumn("packqty_dec"),new DataColumn("medicinetypeid_chr"),new DataColumn("opchargeflg_int"),new DataColumn("ipchargeflg_int"),
            new DataColumn("currentgross_int"),new DataColumn("checkgross_int"),new DataColumn("retailmoney"),new DataColumn("iprealgross_int",typeof(double)),new DataColumn("oprealgross_int",typeof(double)),new DataColumn("ipretailprice_int"),new DataColumn("opretailprice_int",typeof(double)),
                new DataColumn("ipcallprice_int",typeof(double)),new DataColumn("opcallprice_int",typeof(double)),new DataColumn("dsinstoragedate_dat",typeof(DateTime)),new DataColumn("medicinetypename_vchr"),new DataColumn("realmoney",typeof(double)),new DataColumn("checkreason_vchr")};
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
                    return;
                }

                lngRes = m_objDomain.m_lngGetMedicineByMedicineCode(m_objViewer.m_txtMedicineCode1.Text, m_objViewer.m_txtMedicineCode2.Text, m_objViewer.m_strDeptID, m_objViewer.m_blnIsHospital, out dtbStorageMedicine);
            }
            else if (m_objViewer.m_rdbMedicinePreptype.Checked)
            {
                if (m_objViewer.m_cboMediciePreptype.SelectedIndex == -1 || m_objViewer.m_cboMediciePreptype.SelectedItem == null)
                {
                    MessageBox.Show("请先选择药品剂型", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_cboMediciePreptype.Focus();
                    return;
                }

                com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objTypeVO = m_objViewer.m_cboMediciePreptype.SelectedItem as com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO;
                lngRes = m_objDomain.m_lngGetMedicineByMedicinePreptype(objTypeVO.m_strMEDICINEPREPTYPE_CHR, m_objViewer.m_strDeptID, m_objViewer.m_blnIsHospital, out dtbStorageMedicine);
            }
            else if (m_objViewer.m_rdbMedicineType.Checked)
            {
                if (m_objViewer.m_cboMedicineType.SelectedIndex == -1 || m_objViewer.m_cboMedicineType.SelectedItem == null)
                {
                    MessageBox.Show("请先选择药品类型", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_objViewer.m_cboMedicineType.Focus();
                    return;
                }

                com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO objTypeVO = m_objViewer.m_cboMedicineType.SelectedItem as com.digitalwave.iCare.ValueObject.clsMS_MedicineType_VO;
                lngRes = m_objDomain.m_lngGetMedicineByMedicineType(objTypeVO.m_strMedicineTypeID_CHR, m_objViewer.m_strDeptID, m_objViewer.m_blnIsHospital, out dtbStorageMedicine);
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
            //if (m_objViewer.m_intCheckMode == 1)
            //{
            DataTable m_dtResult = null;
            DataTable m_dtbResultDetail = null;
            m_mthChangeToTotal(dtbStorageMedicine, out m_dtResult, out m_dtbResultDetail);
            if (m_objViewer.m_dtbMissDetail == null)
            {
                m_objViewer.m_dtbMissDetail = m_dtbResultDetail.Clone();
            }
            if (m_objViewer.m_dtbHasCheckMedicine == null || m_objViewer.m_dtbHasCheckMedicine.Rows.Count == 0)
            {
                m_objViewer.m_dtbMissMedicine.Merge(m_dtResult, true);
                m_objViewer.m_dtbMissDetail.Merge(m_dtbResultDetail, true);
                return;
            }
            DataTable m_dtbHasCheckCopy = m_objViewer.m_dtbHasCheckMedicineFixed.Copy();
            DataRow[] m_drNull = m_dtbHasCheckCopy.Select("medicineid_chr is null");
            if (m_drNull != null && m_drNull.Length > 0)
            {
                foreach (DataRow dr in m_drNull)
                {
                    m_dtbHasCheckCopy.Rows.Remove(dr);
                }
            }
            if (m_dtbHasCheckCopy.Rows.Count == 0)
            {
                m_objViewer.m_dtbMissMedicine.Merge(m_dtResult, true);
                m_objViewer.m_dtbMissDetail.Merge(m_dtbResultDetail, true);
                return;
            }

            m_dtbHasCheckCopy.PrimaryKey = new DataColumn[] { m_dtbHasCheckCopy.Columns["medicineid_chr"], m_dtbHasCheckCopy.Columns["opretailprice_int"] };
            DataRow drDelete = null;
            DataRow drDeleteDetail = null;
            object[] objParamArr = new object[2];

            for (int i1 = 0; i1 < m_dtbHasCheckCopy.Rows.Count; i1++)
            {
                objParamArr[0] = m_dtbHasCheckCopy.Rows[i1]["medicineid_chr"];
                objParamArr[1] = m_dtbHasCheckCopy.Rows[i1]["opretailprice_int"];
                if (m_dtResult.Rows.Contains(objParamArr))
                {
                    drDelete = m_dtResult.Rows.Find(objParamArr);
                    m_dtResult.Rows.Remove(drDelete);
                    for (int i2 = 0; i2 < m_dtbResultDetail.Rows.Count; i2++)
                    {
                        drDeleteDetail = m_dtbResultDetail.Rows[i2];
                        if (drDeleteDetail["medicineid_chr"].ToString() == objParamArr[0].ToString() 
                            && Convert.ToDouble(drDeleteDetail["medicineid_chr"]).ToString("F4") == Convert.ToDouble(objParamArr[1]).ToString("F4"))
                        {
                            m_dtbResultDetail.Rows.Remove(drDeleteDetail);
                        }
                    }
                }
            }
            DataRow[] m_drNewArr = m_dtResult.Select("medicinename_vchr is not null");

            if (m_drNewArr != null && m_drNewArr.Length > 0)
            {
                DataRow m_drTemp = null;
                DataRow m_drNewRow = null;
                m_objViewer.m_dtbMissMedicine.BeginLoadData();
                for (int iRow = 0; iRow < m_drNewArr.Length; iRow++)
                {
                    m_drTemp = m_drNewArr[iRow];
                    if (Convert.ToString(m_drTemp["retailprice_int"]) == string.Empty)
                        continue;
                    m_drNewRow = m_objViewer.m_dtbMissMedicine.NewRow();
                    m_drNewRow["checkmedicineorder_chr"] = m_drTemp["checkmedicineorder_chr"].ToString();
                    m_drNewRow["assistcode_chr"] = m_drTemp["assistcode_chr"].ToString();
                    m_drNewRow["medicineid_chr"] = m_drTemp["medicineid_chr"].ToString();
                    m_drNewRow["medicinename_vchr"] = m_drTemp["medicinename_vchr"].ToString();
                    m_drNewRow["medspec_vchr"] = m_drTemp["MEDSPEC_VCHR"].ToString();
                    m_drNewRow["unit_chr"] = m_drTemp["unit_chr"].ToString();
                    m_drNewRow["opunit_chr"] = m_drTemp["opunit_chr"].ToString();
                    m_drNewRow["ipunit_chr"] = m_drTemp["ipunit_chr"].ToString();
                    m_drNewRow["packqty_dec"] = Convert.ToDouble(m_drTemp["packqty_dec"]);
                    m_drNewRow["opchargeflg_int"] = Convert.ToDouble(m_drTemp["opchargeflg_int"]);
                    m_drNewRow["ipchargeflg_int"] = Convert.ToDouble(m_drTemp["ipchargeflg_int"]);
                    m_drNewRow["realgross_int"] = m_drTemp["realgross_int"].ToString();
                    //m_drNewRow["callprice_int"] = m_drTemp["CALLPRICE_INT"].ToString();
                    //m_drNewRow["wholesaleprice_int"] = m_drTemp["WHOLESALEPRICE_INT"].ToString();
                    m_drNewRow["retailprice_int"] = m_drTemp["RETAILPRICE_INT"].ToString();
                    m_drNewRow["lotno_vchr"] = m_drTemp["lotno_vchr"].ToString();
                    m_drNewRow["indrugstoreid_vchr"] = m_drTemp["indrugstoreid_vchr"].ToString();
                    m_drNewRow["validperiod_dat"] = m_drTemp["validperiod_dat"].ToString();
                    m_drNewRow["productorid_chr"] = m_drTemp["PRODUCTORID_CHR"].ToString();
                    m_drNewRow["medicinepreptype_chr"] = m_drTemp["medicinepreptype_chr"].ToString();
                    m_drNewRow["medicinepreptypename_vchr"] = m_drTemp["medicinepreptypename_vchr"].ToString();
                    m_drNewRow["storagerackcode_vchr"] = m_drTemp["storagerackcode_vchr"].ToString();
                    m_drNewRow["checkgross_int"] = m_drTemp["checkgross_int"].ToString();
                    m_drNewRow["retailmoney"] = m_drTemp["retailmoney"].ToString();
                    m_drNewRow["realmoney"] = m_drTemp["retailmoney"].ToString();
                    m_drNewRow["iprealgross_int"] = Convert.ToDouble(m_drTemp["iprealgross_int"]);
                    m_drNewRow["oprealgross_int"] = Convert.ToDouble(m_drTemp["oprealgross_int"]);
                    m_drNewRow["ipretailprice_int"] = Convert.ToDouble(m_drTemp["ipretailprice_int"]);
                    m_drNewRow["opretailprice_int"] = Convert.ToDouble(m_drTemp["opretailprice_int"]);
                    m_drNewRow["ipcallprice_int"] = Convert.ToDouble(m_drTemp["ipcallprice_int"]);
                    m_drNewRow["opcallprice_int"] = Convert.ToDouble(m_drTemp["opcallprice_int"]);
                    m_drNewRow["dsinstoragedate_dat"] = Convert.ToDateTime(m_drTemp["dsinstoragedate_dat"]);
                    m_drNewRow["checkreason_vchr"] = m_drTemp["checkreason_vchr"].ToString();
                    m_objViewer.m_dtbMissMedicine.LoadDataRow(m_drNewRow.ItemArray, true);
                }
                m_objViewer.m_dtbMissMedicine.EndLoadData();
            }
            DataRow[] m_drNewDetail = m_dtbResultDetail.Select("retailprice_int is not null");
            if (m_drNewDetail != null && m_drNewDetail.Length > 0)
            {
                m_objViewer.m_dtbMissDetail.BeginLoadData();
                for (int i3 = 0; i3 < m_drNewDetail.Length; i3++)
                {
                    m_objViewer.m_dtbMissDetail.LoadDataRow(m_drNewDetail[i3].ItemArray, true);
                }
                m_objViewer.m_dtbMissDetail.EndLoadData();
            }

            //}
            //}
            //else
            //{
            //    if (m_objViewer.m_dtbHasCheckMedicine == null || m_objViewer.m_dtbHasCheckMedicine.Rows.Count == 0)
            //    {
            //        m_objViewer.m_dtbMissMedicine.Merge(dtbStorageMedicine, true);
            //        for (int i1 = 1; i1 < m_objViewer.m_dtbMissMedicine.Rows.Count; i1++)
            //        {
            //            if (Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["opchargeflg_int"]) == 1)
            //            {
            //                m_objViewer.m_dtbMissMedicine.Rows[i1]["realgross_int"] = Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["realgross_int"]) * Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["packqty_dec"]);
            //                //m_objViewer.m_dtbMissMedicine.Rows[i1]["callprice_int"] = Convert.ToDouble(Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["CALLPRICE_INT"]) / Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["packqty_dec"])).ToString("F4");
            //                //m_objViewer.m_dtbMissMedicine.Rows[i1]["wholesaleprice_int"] = Convert.ToDouble(Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["WHOLESALEPRICE_INT"]) / Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["packqty_dec"])).ToString("F4");
            //                m_objViewer.m_dtbMissMedicine.Rows[i1]["retailprice_int"] = Convert.ToDouble(Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["RETAILPRICE_INT"]) / Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["packqty_dec"])).ToString("F4");
            //            }
            //        }
            //        return;
            //    }

            //    DataTable dtbHasCheckCopy = m_objViewer.m_dtbHasCheckMedicineFixed.Copy();
            //    DataRow[] drNull = dtbHasCheckCopy.Select("medicineid_chr is null");
            //    if (drNull != null && drNull.Length > 0)
            //    {
            //        foreach (DataRow dr in drNull)
            //        {
            //            dtbHasCheckCopy.Rows.Remove(dr);
            //        }
            //    }

            //    if (dtbHasCheckCopy.Rows.Count == 0)
            //    {
            //        m_objViewer.m_dtbMissMedicine.Merge(dtbStorageMedicine, true);
            //        for (int i1 = 1; i1 < m_objViewer.m_dtbMissMedicine.Rows.Count; i1++)
            //        {
            //            if (Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["opchargeflg_int"]) == 1)
            //            {
            //                m_objViewer.m_dtbMissMedicine.Rows[i1]["realgross_int"] = Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["realgross_int"]) * Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["packqty_dec"]);
            //                //m_objViewer.m_dtbMissMedicine.Rows[i1]["callprice_int"] = Convert.ToDouble(Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["CALLPRICE_INT"]) / Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["packqty_dec"])).ToString("F4");
            //                //m_objViewer.m_dtbMissMedicine.Rows[i1]["wholesaleprice_int"] = Convert.ToDouble(Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["WHOLESALEPRICE_INT"]) / Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["packqty_dec"])).ToString("F4");
            //                m_objViewer.m_dtbMissMedicine.Rows[i1]["retailprice_int"] = Convert.ToDouble(Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["RETAILPRICE_INT"]) / Convert.ToDouble(m_objViewer.m_dtbMissMedicine.Rows[i1]["packqty_dec"])).ToString("F4");
            //            }
            //        }
            //        return;
            //    }

            //dtbHasCheckCopy.PrimaryKey = new DataColumn[] { dtbHasCheckCopy.Columns["medicineid_chr"], dtbHasCheckCopy.Columns["lotno_vchr"], dtbHasCheckCopy.Columns["indrugstoreid_vchr"] };

            //dtbHasCheckCopy.Merge(dtbStorageMedicine, true);

            //DataRow[] drNewArr = dtbHasCheckCopy.Select("medicinename_vchr is not null");

            //dtbHasCheckCopy = null;

            //if (drNewArr != null && drNewArr.Length > 0)
            //{
            //    DataRow drTemp = null;
            //    DataRow drNewRow = null;
            //    m_objViewer.m_dtbMissMedicine.BeginLoadData();
            //    for (int iRow = 0; iRow < drNewArr.Length; iRow++)
            //    {
            //        drTemp = drNewArr[iRow];
            //        if (Convert.ToString(drTemp["CALLPRICE_INT"]) == string.Empty)
            //            continue;
            //        drNewRow = m_objViewer.m_dtbMissMedicine.NewRow();
            //        drNewRow["checkmedicineorder_chr"] = drTemp["checkmedicineorder_chr"].ToString();
            //        drNewRow["assistcode_chr"] = drTemp["assistcode_chr"].ToString();
            //        drNewRow["medicineid_chr"] = drTemp["medicineid_chr"].ToString();
            //        drNewRow["medicinename_vchr"] = drTemp["medicinename_vchr"].ToString();
            //        drNewRow["medspec_vchr"] = drTemp["MEDSPEC_VCHR"].ToString();
            //        drNewRow["unit_chr"] = drTemp["unit_chr"].ToString();
            //        drNewRow["opunit_chr"] = drTemp["opunit_chr"].ToString();
            //        drNewRow["ipunit_chr"] = drTemp["ipunit_chr"].ToString();
            //        drNewRow["packqty_dec"] = Convert.ToDouble(drTemp["packqty_dec"]);
            //        drNewRow["opchargeflg_int"] = Convert.ToDouble(drTemp["opchargeflg_int"]);
            //        //if (Convert.ToDouble(drTemp["opchargeflg_int"]) == 1)//最小单位
            //        //{
            //        //    drNewRow["realgross_int"] = Convert.ToDouble(drTemp["realgross_int"]) * Convert.ToDouble(drTemp["packqty_dec"]);
            //        //    //drNewRow["callprice_int"] = Convert.ToDouble(Convert.ToDouble(drTemp["CALLPRICE_INT"]) / Convert.ToDouble(drTemp["packqty_dec"])).ToString("F4");
            //        //    //drNewRow["wholesaleprice_int"] = Convert.ToDouble(Convert.ToDouble(drTemp["WHOLESALEPRICE_INT"]) / Convert.ToDouble(drTemp["packqty_dec"])).ToString("F4");
            //        //    drNewRow["retailprice_int"] = Convert.ToDouble(Convert.ToDouble(drTemp["RETAILPRICE_INT"]) / Convert.ToDouble(drTemp["packqty_dec"])).ToString("F4");
            //        //}
            //        //else//基本单位
            //        //{
            //            drNewRow["realgross_int"] = drTemp["realgross_int"].ToString();
            //            //drNewRow["callprice_int"] = drTemp["CALLPRICE_INT"].ToString();
            //            //drNewRow["wholesaleprice_int"] = drTemp["WHOLESALEPRICE_INT"].ToString();
            //            drNewRow["retailprice_int"] = drTemp["RETAILPRICE_INT"].ToString();
            //        //}

            //        drNewRow["lotno_vchr"] = drTemp["lotno_vchr"].ToString();
            //        drNewRow["indrugstoreid_vchr"] = drTemp["indrugstoreid_vchr"].ToString();
            //        drNewRow["validperiod_dat"] = drTemp["validperiod_dat"].ToString();
            //        drNewRow["productorid_chr"] = drTemp["PRODUCTORID_CHR"].ToString();
            //        drNewRow["medicinepreptype_chr"] = drTemp["medicinepreptype_chr"].ToString();
            //        drNewRow["medicinepreptypename_vchr"] = drTemp["medicinepreptypename_vchr"].ToString();
            //        drNewRow["storagerackcode_vchr"] = drTemp["storagerackcode_vchr"].ToString();

            //        m_objViewer.m_dtbMissMedicine.LoadDataRow(drNewRow.ItemArray, true);
            //    }
            //    m_objViewer.m_dtbMissMedicine.EndLoadData();
            //}
        }
        #endregion

        #region 获取药品制剂类型
        /// <summary>
        /// 获取药品制剂类型
        /// </summary>
        internal void m_mthGetMedicinePreptype()
        {
            com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[] objMPVO = null;
            m_objDomain.m_lngGetMedicinePreptype(m_objViewer.m_strStorageID,out objMPVO);            

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
            m_objDomain.m_lngGetStorageMedicineType(out objMTVO);

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
            DataRow drCurrent = null;
            for (int iRow = 0; iRow < m_objViewer.m_dgvStorageDetail.Rows.Count; iRow++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvStorageDetail.Rows[iRow].Cells[0].Value))
                {
                    drCurrent = ((DataRowView)m_objViewer.m_dgvStorageDetail.Rows[iRow].DataBoundItem).Row;                    
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

        internal DataRow[] m_drGetSelectedDetailRows()
        {
            List<DataRow> drSelectedDetail = new List<DataRow>();
            DataRow drCurrent = null;
            string strMedicineID = string.Empty;
            DataRow[] drTemp = null;
            double dblRetailPrice = 0d;
            for (int iRow = 0; iRow < m_objViewer.m_dgvStorageDetail.Rows.Count; iRow++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvStorageDetail.Rows[iRow].Cells[0].Value))
                {
                    drCurrent = ((DataRowView)m_objViewer.m_dgvStorageDetail.Rows[iRow].DataBoundItem).Row;
                    strMedicineID = drCurrent["medicineid_chr"].ToString();
                    dblRetailPrice = Convert.ToDouble(Convert.ToDouble(drCurrent["opretailprice_int"]).ToString("F4"));
                    drTemp = m_objViewer.m_dtbMissDetail.Select("medicineid_chr = '" + strMedicineID + "' and opretailprice_int = " + dblRetailPrice);
                    if (drTemp != null && drTemp.Length > 0)
                    {
                        //foreach (DataRow dr in drTemp)
                        //    drSelectedDetail.Add(dr);
                        drSelectedDetail.AddRange(drTemp);
                    }
                }
            }

            if (drSelectedDetail.Count > 0)
            {
                return drSelectedDetail.ToArray();
            }
            else
            {
                return null;
            }
        }


        #endregion

        internal void m_mthFixTable(DataTable m_dtbHasCheckMedicine)
        {
            DataTable p_dtbFixedCheckResult = m_objViewer.m_dtbMissMedicine.Clone();
            DataRow p_drData;
            for (int i1 = 0; i1 < m_objViewer.m_dtbHasCheckMedicine.Rows.Count; i1++)
            {
                p_drData = p_dtbFixedCheckResult.NewRow();
                p_drData["checkmedicineorder_chr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["checkmedicineorder_chr"];
                p_drData["assistcode_chr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["assistcode_chr"];
                p_drData["medicineid_chr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["MEDICINEID_CHR"];
                p_drData["medicinename_vchr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["MEDICINENAME_VCHR"];
                p_drData["medspec_vchr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["MEDSPEC_VCHR"];
                p_drData["unit_chr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["UNIT_CHR"];
                p_drData["opunit_chr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["OPUNIT_CHR"];
                p_drData["ipunit_chr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["IPUNIT_CHR"];
                p_drData["realgross_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["CHECKGROSS_INT"];
                //p_drData["callprice_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["CALLPRICE_INT"];
                //p_drData["wholesaleprice_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["WHOLESALEPRICE_INT"];
                p_drData["retailprice_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["RETAILPRICE_INT"];
                p_drData["lotno_vchr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["LOTNO_VCHR"];
                p_drData["indrugstoreid_vchr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["indrugstoreid_vchr"];
                p_drData["validperiod_dat"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["VALIDPERIOD_DAT"];
                p_drData["productorid_chr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["PRODUCTORID_CHR"];                
                p_drData["medicinepreptype_chr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["medicinepreptype_chr"];
                p_drData["medicinepreptypename_vchr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["medicinepreptypename_vchr"];
                p_drData["storagerackcode_vchr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["storagerackcode_vchr"];
                p_drData["packqty_dec"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["packqty_dec"];
                p_drData["medicinetypeid_chr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["medicinetypeid_chr"];
                p_drData["opchargeflg_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["opchargeflg_int"];
                p_drData["ipchargeflg_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["ipchargeflg_int"];
                p_drData["iprealgross_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["iprealgross_int"];
                p_drData["oprealgross_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["oprealgross_int"];
                p_drData["ipretailprice_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["ipretailprice_int"];
                p_drData["opretailprice_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["opretailprice_int"];
                p_drData["ipcallprice_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["ipcallprice_int"];
                p_drData["opcallprice_int"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["opcallprice_int"];
                p_drData["dsinstoragedate_dat"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["dsinstoragedate_dat"];
                p_drData["medicinetypename_vchr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["medicinetypename_vchr"];
                p_drData["checkreason_vchr"] = m_objViewer.m_dtbHasCheckMedicine.Rows[i1]["checkreason_vchr"];
                p_dtbFixedCheckResult.Rows.Add(p_drData);
            }
            m_objViewer.m_dtbHasCheckMedicineFixed = p_dtbFixedCheckResult.Copy();
        }

        /// <summary>
        /// 将明细转换成统计
        /// </summary>
        /// <param name="p_dtbMedicine"></param>
        /// <param name="p_dtbResult"></param>
        internal void m_mthChangeToTotal(DataTable p_dtbMedicine, out DataTable p_dtbResult, out DataTable p_dtbResultDetail)
        {
            p_dtbResult = p_dtbMedicine.Clone();
            p_dtbResultDetail = p_dtbMedicine.Copy();
            p_dtbResult.PrimaryKey = new DataColumn[] { p_dtbResult.Columns["MEDICINEID_CHR"], p_dtbResult.Columns["opretailprice_int"] };
            string m_strMedicineID = string.Empty;
            double m_dblPrice = 0d;
            DataRow m_drResult = null;
            for (int i1 = 0; i1 < p_dtbMedicine.Rows.Count; i1++)
            {
                if (p_dtbMedicine.Rows[i1]["MEDICINEID_CHR"].ToString() != m_strMedicineID && Convert.ToDouble(Convert.ToDouble(p_dtbMedicine.Rows[i1]["opretailprice_int"]).ToString("F4")) != m_dblPrice)
                {
                    m_strMedicineID = p_dtbMedicine.Rows[i1]["MEDICINEID_CHR"].ToString();
                    m_dblPrice = Convert.ToDouble(Convert.ToDouble(p_dtbMedicine.Rows[i1]["opretailprice_int"]).ToString("F4"));
                    m_drResult = p_dtbResult.NewRow();
                    m_drResult["MEDICINEID_CHR"] = m_strMedicineID;
                    m_drResult["LOTNO_VCHR"] = string.Empty;
                    m_drResult["indrugstoreid_vchr"] = string.Empty;
                    m_drResult["MEDICINENAME_VCHR"] = p_dtbMedicine.Rows[i1]["MEDICINENAME_VCHR"];
                    m_drResult["assistcode_chr"] = p_dtbMedicine.Rows[i1]["assistcode_chr"];
                    m_drResult["MEDSPEC_VCHR"] = p_dtbMedicine.Rows[i1]["MEDSPEC_VCHR"];
                    m_drResult["UNIT_CHR"] = p_dtbMedicine.Rows[i1]["UNIT_CHR"];
                    m_drResult["OPUNIT_CHR"] = p_dtbMedicine.Rows[i1]["OPUNIT_CHR"];
                    m_drResult["IPUNIT_CHR"] = p_dtbMedicine.Rows[i1]["IPUNIT_CHR"];
                    m_drResult["VALIDPERIOD_DAT"] = p_dtbMedicine.Rows[i1]["VALIDPERIOD_DAT"];
                    m_drResult["PRODUCTORID_CHR"] = p_dtbMedicine.Rows[i1]["PRODUCTORID_CHR"];
                    m_drResult["RETAILPRICE_INT"] = p_dtbMedicine.Rows[i1]["RETAILPRICE_INT"];                    
                    m_drResult["realgross_int"] = p_dtbMedicine.Rows[i1]["realgross_int"];
                    m_drResult["medicinepreptype_chr"] = p_dtbMedicine.Rows[i1]["medicinepreptype_chr"];
                    m_drResult["medicinepreptypename_vchr"] = p_dtbMedicine.Rows[i1]["medicinepreptypename_vchr"];                   
                    m_drResult["medicinetypeid_chr"] = p_dtbMedicine.Rows[i1]["medicinetypeid_chr"];
                    m_drResult["packqty_dec"] = p_dtbMedicine.Rows[i1]["packqty_dec"];
                    m_drResult["medicinetypename_vchr"] = p_dtbMedicine.Rows[i1]["medicinetypename_vchr"];
                    m_drResult["opchargeflg_int"] = p_dtbMedicine.Rows[i1]["opchargeflg_int"];
                    m_drResult["ipchargeflg_int"] = p_dtbMedicine.Rows[i1]["ipchargeflg_int"];                    
                    m_drResult["CHECKGROSS_INT"] = Convert.ToDouble(p_dtbMedicine.Rows[i1]["realgross_int"]);
                    m_drResult["iprealgross_int"] = p_dtbMedicine.Rows[i1]["iprealgross_int"];
                    m_drResult["oprealgross_int"] = p_dtbMedicine.Rows[i1]["oprealgross_int"];
                    m_drResult["ipretailprice_int"] = p_dtbMedicine.Rows[i1]["ipretailprice_int"];
                    m_drResult["opretailprice_int"] = p_dtbMedicine.Rows[i1]["opretailprice_int"];
                    m_drResult["ipcallprice_int"] = p_dtbMedicine.Rows[i1]["ipcallprice_int"];
                    m_drResult["opcallprice_int"] = p_dtbMedicine.Rows[i1]["opcallprice_int"];
                    m_drResult["dsinstoragedate_dat"] = Convert.ToDateTime(p_dtbMedicine.Rows[i1]["dsinstoragedate_dat"]);
                    m_drResult["RETAILMONEY"] = Convert.ToDouble(p_dtbMedicine.Rows[i1]["iprealgross_int"]) * Convert.ToDouble(p_dtbMedicine.Rows[i1]["opretailprice_int"]) / Convert.ToDouble(p_dtbMedicine.Rows[i1]["packqty_dec"]);
                    m_drResult["realmoney"] = p_dtbMedicine.Rows[i1]["RETAILMONEY"];
                    m_drResult["checkreason_vchr"] = p_dtbMedicine.Rows[i1]["checkreason_vchr"];
                    p_dtbResult.Rows.Add(m_drResult);
                }
                else
                {
                    m_drResult = p_dtbResult.Rows[p_dtbResult.Rows.Count - 1];
                    m_drResult["realgross_int"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["realgross_int"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["realgross_int"]);                    
                    m_drResult["CHECKGROSS_INT"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["CHECKGROSS_INT"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["realgross_int"]);
                    m_drResult["iprealgross_int"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["iprealgross_int"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["iprealgross_int"]);
                    m_drResult["oprealgross_int"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["oprealgross_int"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["oprealgross_int"]);
                    m_drResult["RETAILMONEY"] = Convert.ToDouble(p_dtbResult.Rows[p_dtbResult.Rows.Count - 1]["RETAILMONEY"]) + Convert.ToDouble(p_dtbMedicine.Rows[i1]["iprealgross_int"]) * Convert.ToDouble(p_dtbMedicine.Rows[i1]["opretailprice_int"]) / Convert.ToDouble(p_dtbMedicine.Rows[i1]["packqty_dec"]); ;
                    m_drResult["realmoney"] = m_drResult["RETAILMONEY"];
                }
                p_dtbResult.AcceptChanges();
            }

            //库存明细
            for (int i1 = 0; i1 < p_dtbResultDetail.Rows.Count; i1++)
            {
                //基本单位和最小单位的金额均以最小单位来计算
                p_dtbResultDetail.Rows[i1]["RETAILMONEY"] = Convert.ToDouble(p_dtbMedicine.Rows[i1]["iprealgross_int"]) * Convert.ToDouble(p_dtbMedicine.Rows[i1]["opretailprice_int"]) / Convert.ToDouble(p_dtbMedicine.Rows[i1]["packqty_dec"]);
                p_dtbResultDetail.Rows[i1]["realmoney"] = p_dtbResultDetail.Rows[i1]["RETAILMONEY"];
            }
            p_dtbResultDetail.AcceptChanges();
        }
    }
}
