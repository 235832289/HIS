using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品出库药品信息浏览
    /// </summary>
    public class clsCtl_QueryMedicineInfo : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmQueryMedicineInfo m_objViewer;
        /// <summary>
        /// 库存明细信息
        /// </summary>
        private clsMS_StorageDetail[] m_objData = null;

        /// <summary>
        /// 药品出库药品信息浏览
        /// </summary>
        public clsCtl_QueryMedicineInfo()
        {
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmQueryMedicineInfo)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化药品数据源
        /// <summary>
        /// 初始化药品数据源
        /// </summary>
        /// <param name="p_dtbSource"></param>
        internal void m_mthInitDataSouce(ref DataTable p_dtbSource)
        {
            p_dtbSource = new DataTable();
            DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEID_CHR"), new DataColumn("medicinename_vchr"), new DataColumn("MEDSPEC_VCHR"),new DataColumn("OPUNIT_CHR"),
                new DataColumn("NETAMOUNT_INT"),new DataColumn("LOTNO_VCHR"),new DataColumn("INSTORAGEID_VCHR"),new DataColumn("CALLPRICE_INT"),new DataColumn("MEDICINETYPEID_CHR"),
                new DataColumn("WHOLESALEPRICE_INT"),new DataColumn("RETAILPRICE_INT"),new DataColumn("VENDORID_CHR"),new DataColumn("vendorname_vchr"),new DataColumn("productorid_chr"),
                new DataColumn("instoragedate_dat"),new DataColumn("validperiod_dat"),new DataColumn("realgross_int"),new DataColumn("assistcode_chr"),new DataColumn("producedate_dat"),
                new DataColumn("availagross_int"),new DataColumn("seriesid_int"), new DataColumn("instorageamount"), new DataColumn("packqty_dec",typeof(double)), new DataColumn("ipunit_chr",typeof(string))};
            p_dtbSource.Columns.AddRange(drColumns);
        } 
        #endregion

        #region 设置药品数据至界面

        /// <summary>
        /// 设置药品数据至界面

        /// </summary>
        /// <param name="p_objData"></param>
        internal void m_mthSetDataToUI(clsMS_StorageDetail[] p_objData,System.Collections.Hashtable hstNoChange)
        {
            if (p_objData == null || m_objViewer.m_dtbMedicineInfo == null)
            {
                return;
            }

            m_objData = p_objData;

            DataRow drNew = null;
            double dblCurrentAmount = m_objViewer.m_dblAmount;
            m_objViewer.m_dtbMedicineInfo.BeginLoadData();
            for (int iRow = 0; iRow < p_objData.Length; iRow++)
            {
                //if ( p_objData[iRow].m_dblAVAILAGROSS_INT <= 0)
                //{
                //    continue;
                //}

                drNew = m_objViewer.m_dtbMedicineInfo.NewRow();
                drNew["MEDICINEID_CHR"] = p_objData[iRow].m_strMEDICINEID_CHR;
                drNew["MEDICINENAME_VCHR"] = p_objData[iRow].m_strMEDICINENAME_VCHR;
                drNew["MEDSPEC_VCHR"] = p_objData[iRow].m_strMEDSPEC_VCHR;
                drNew["OPUNIT_CHR"] = p_objData[iRow].m_strOPUNIT_VCHR;
                //if (dblCurrentAmount > 0)
                //{
                //    if (dblCurrentAmount > p_objData[iRow].m_dblAVAILAGROSS_INT)
                //    {
                //        drNew["NETAMOUNT_INT"] = p_objData[iRow].m_dblAVAILAGROSS_INT.ToString("0.00");
                //        dblCurrentAmount -= p_objData[iRow].m_dblAVAILAGROSS_INT;
                //    }
                //    else
                //    {
                //        drNew["NETAMOUNT_INT"] = dblCurrentAmount;
                //        dblCurrentAmount = 0;
                //    }
                //}
                //else
                //{
                //    drNew["NETAMOUNT_INT"] = 0;
                //}
                if (hstNoChange != null && hstNoChange.Count > 0)
                {
                    if (hstNoChange.ContainsKey(p_objData[iRow].m_strLOTNO_VCHR + p_objData[iRow].m_strINSTORAGEID_VCHR))
                    {
                        drNew["NETAMOUNT_INT"] = Convert.ToDouble(hstNoChange[p_objData[iRow].m_strLOTNO_VCHR + p_objData[iRow].m_strINSTORAGEID_VCHR]);
                    }
                    else
                    {
                        drNew["NETAMOUNT_INT"] = 0;
                    }
                }
                else
                {
                    if (dblCurrentAmount > 0)
                    {
                        if (dblCurrentAmount > p_objData[iRow].m_dblAVAILAGROSS_INT)
                        {
                            drNew["NETAMOUNT_INT"] = p_objData[iRow].m_dblAVAILAGROSS_INT.ToString("0.00");
                            dblCurrentAmount -= p_objData[iRow].m_dblAVAILAGROSS_INT;
                        }
                        else
                        {
                            drNew["NETAMOUNT_INT"] = dblCurrentAmount;
                            dblCurrentAmount = 0;
                        }
                    }
                    else
                    {
                        drNew["NETAMOUNT_INT"] = dblCurrentAmount;
                        dblCurrentAmount = 0;
                    }
                }
                drNew["realgross_int"] = p_objData[iRow].m_dblREALGROSS_INT.ToString("0.00");
                drNew["availagross_int"] = p_objData[iRow].m_dblAVAILAGROSS_INT.ToString("0.00");
                drNew["LOTNO_VCHR"] = p_objData[iRow].m_strLOTNO_VCHR;
                drNew["INSTORAGEID_VCHR"] = p_objData[iRow].m_strINSTORAGEID_VCHR;
                drNew["CALLPRICE_INT"] = p_objData[iRow].m_dcmCALLPRICE_INT.ToString("0.0000");
                drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dcmWHOLESALEPRICE_INT.ToString("0.0000");
                drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dcmRETAILPRICE_INT.ToString("0.0000");
                drNew["VENDORID_CHR"] = p_objData[iRow].m_strVENDORID_CHR;
                drNew["vendorname_vchr"] = p_objData[iRow].m_strVENDORName;
                drNew["productorid_chr"] = p_objData[iRow].m_strPRODUCTORID_CHR;
                drNew["instoragedate_dat"] = p_objData[iRow].m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
                drNew["validperiod_dat"] = p_objData[iRow].m_dtmVALIDPERIOD_DAT;
                drNew["assistcode_chr"] = p_objData[iRow].m_strMEDICINECode;
                drNew["seriesid_int"] = p_objData[iRow].m_lngSERIESID_INT;
                drNew["instorageamount"] = p_objData[iRow].m_dblInStorageAmount.ToString("0.00");
                drNew["MEDICINETYPEID_CHR"] = p_objData[iRow].m_strMEDICINETYPEID_CHR;
                drNew["packqty_dec"] = Convert.ToDouble(p_objData[iRow].m_dblPackQty);
                drNew["ipunit_chr"] = p_objData[iRow].m_strIPUnit;
                drNew["producedate_dat"] = p_objData[iRow].m_dtmPRODUCEDATE_DAT;
                m_objViewer.m_dblAllAmount += p_objData[iRow].m_dblAVAILAGROSS_INT;
                m_objViewer.m_dtbMedicineInfo.LoadDataRow(drNew.ItemArray,true);
            }
            m_objViewer.m_dtbMedicineInfo.EndLoadData();

            if (m_objViewer.m_dblAllAmount < m_objViewer.m_dblAmount)
            {
                m_objViewer.m_lblHintText.Text = "当前可用库存少于请求出库库存";
                m_objViewer.m_lblHintText.Visible = true;
            }

            if (m_objViewer.m_dgvQueryMedicineInfo.Rows.Count > 0)
            {
                m_objViewer.m_dgvQueryMedicineInfo.Focus();
                m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[0].Cells[6];
                m_objViewer.m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
            }
        } 
        #endregion

        #region 从界面获取药品出库VO
        /// <summary>
        /// 从界面获取药品出库VO
        /// </summary>
        /// <param name="p_intStatus">状态0,出错　1,正常</param>
        /// <returns></returns>
        internal clsMS_StorageMedicineShow[] m_objGetVOFromTable(out int p_intStatus)
        {
            p_intStatus = 1;
            clsMS_StorageMedicineShow[] objValueArr = null;
            if (m_objViewer.m_dtbMedicineInfo != null)
            {
                int intRowsCount = m_objViewer.m_dtbMedicineInfo.Rows.Count;
                if (intRowsCount == 0)
                {
                    return null;
                }

                clsMS_StorageMedicineShow objValue = null;
                List<clsMS_StorageMedicineShow> lstMedicineInfo = new List<clsMS_StorageMedicineShow>();
                DataRow drTemp = null;
                double dblTemp = 0d;
                DateTime datTemp;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = m_objViewer.m_dtbMedicineInfo.Rows[iRow];
                    if (double.TryParse(drTemp["NETAMOUNT_INT"].ToString(),out dblTemp))
                    {
                        //if (dblTemp < 0)
                        //{
                        //    MessageBox.Show("出库数量不能为负数", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    m_objViewer.m_dgvQueryMedicineInfo.Focus();
                        //    m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[iRow].Cells[7];
                        //    p_intStatus = 0;
                        //    return null;
                        //}
                        //else 
                            if(dblTemp == 0)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("出库数量必须为数字", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_objViewer.m_dgvQueryMedicineInfo.Focus();
                        m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[iRow].Cells[7];
                        p_intStatus = 0;
                        return null;
                    }
                    
                    objValue = new clsMS_StorageMedicineShow();
                    objValue.m_strMEDICINEID_CHR = drTemp["MEDICINEID_CHR"].ToString();
                    objValue.m_strMEDICINENAME_VCHR = drTemp["MEDICINENAME_VCHR"].ToString();
                    objValue.m_strMEDSPEC_VCHR = drTemp["MEDSPEC_VCHR"].ToString();
                    objValue.m_strLOTNO_VCHR = drTemp["LOTNO_VCHR"].ToString();
                    objValue.m_dcmRETAILPRICE_INT = Convert.ToDecimal(drTemp["RETAILPRICE_INT"]);
                    objValue.m_dcmCALLPRICE_INT = Convert.ToDecimal(drTemp["CALLPRICE_INT"]);
                    objValue.m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drTemp["WHOLESALEPRICE_INT"]);
                    objValue.m_dblREALGROSS_INT = Convert.ToDouble(drTemp["REALGROSS_INT"]);
                    objValue.m_dblAVAILAGROSS_INT = Convert.ToDouble(drTemp["AVAILAGROSS_INT"]);
                    objValue.m_strOPUNIT_VCHR = drTemp["OPUNIT_CHR"].ToString();
                    objValue.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drTemp["VALIDPERIOD_DAT"]);
                    objValue.m_strPRODUCTORID_CHR = drTemp["PRODUCTORID_CHR"].ToString();
                    objValue.m_strINSTORAGEID_VCHR = drTemp["INSTORAGEID_VCHR"].ToString();
                    objValue.m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(drTemp["INSTORAGEDATE_DAT"]);
                    objValue.m_strMEDICINECode = drTemp["assistcode_chr"].ToString();
                    objValue.m_strVENDORID_CHR = drTemp["vendorid_chr"].ToString();
                    objValue.m_strVENDORName = drTemp["vendorname_vchr"].ToString();
                    objValue.m_lngSERIESID_INT = Convert.ToInt64(drTemp["seriesid_int"]);
                    objValue.m_dblOutAmount = Convert.ToDouble(drTemp["NETAMOUNT_INT"]);
                    objValue.m_strMedicineTypeID_chr = drTemp["MEDICINETYPEID_CHR"].ToString();
                    objValue.m_dblPackQty = Convert.ToDouble(drTemp["packqty_dec"]);
                    objValue.m_strIPUnit = drTemp["ipunit_chr"].ToString();
                    objValue.m_strTYPECODE_CHR = m_objViewer.m_strTYPECODE_CHR;
                    if (DateTime.TryParse(drTemp["producedate_dat"].ToString(), out datTemp))
                    {
                        objValue.m_dtmPRODUCEDATE_DAT = datTemp;
                    }
                    if (dblTemp > objValue.m_dblAVAILAGROSS_INT)
                    {
                        MessageBox.Show("出库数量不能大于可用库存", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_objViewer.m_dgvQueryMedicineInfo.Focus();
                        m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[iRow].Cells[7];
                        p_intStatus = 0;
                        return null;
                    }
                    lstMedicineInfo.Add(objValue);
                }
                if (lstMedicineInfo.Count > 0)
                {
                    objValueArr = lstMedicineInfo.ToArray();
                }                
            }
            return objValueArr;
        } 
        #endregion

        #region 设置药品数据至界面

        /// <summary>
        /// 设置药品数据至界面
        /// </summary>
        /// <param name="p_objData"></param>
        internal void m_mthSetDataToUI(clsMS_StorageDetail[] p_objData)
        {
            if (p_objData == null || m_objViewer.m_dtbMedicineInfo == null)
            {
                return;
            }

            m_objData = p_objData;

            DataRow drNew = null;
            double dblCurrentAmount = m_objViewer.m_dblAmount;
            m_objViewer.m_dtbMedicineInfo.BeginLoadData();
            for (int iRow = 0; iRow < p_objData.Length; iRow++)
            {
                if (p_objData[iRow].m_dblAVAILAGROSS_INT <= 0)
                {
                    continue;
                }

                drNew = m_objViewer.m_dtbMedicineInfo.NewRow();
                drNew["MEDICINEID_CHR"] = p_objData[iRow].m_strMEDICINEID_CHR;
                drNew["MEDICINENAME_VCHR"] = p_objData[iRow].m_strMEDICINENAME_VCHR;
                drNew["MEDSPEC_VCHR"] = p_objData[iRow].m_strMEDSPEC_VCHR;
                drNew["OPUNIT_CHR"] = p_objData[iRow].m_strOPUNIT_VCHR;
                if (dblCurrentAmount > 0)
                {
                    if (dblCurrentAmount > p_objData[iRow].m_dblAVAILAGROSS_INT)
                    {
                        drNew["NETAMOUNT_INT"] = p_objData[iRow].m_dblAVAILAGROSS_INT.ToString("0.00");
                        dblCurrentAmount -= p_objData[iRow].m_dblAVAILAGROSS_INT;
                    }
                    else
                    {
                        drNew["NETAMOUNT_INT"] = dblCurrentAmount;
                        dblCurrentAmount = 0;
                    }
                }
                else
                {
                    drNew["NETAMOUNT_INT"] = 0;
                }
                drNew["realgross_int"] = p_objData[iRow].m_dblREALGROSS_INT.ToString("0.00");
                drNew["availagross_int"] = p_objData[iRow].m_dblAVAILAGROSS_INT.ToString("0.00");
                drNew["LOTNO_VCHR"] = p_objData[iRow].m_strLOTNO_VCHR;
                drNew["INSTORAGEID_VCHR"] = p_objData[iRow].m_strINSTORAGEID_VCHR;
                drNew["CALLPRICE_INT"] = p_objData[iRow].m_dcmCALLPRICE_INT.ToString("0.0000");
                drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dcmWHOLESALEPRICE_INT.ToString("0.0000");
                drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dcmRETAILPRICE_INT.ToString("0.0000");
                drNew["VENDORID_CHR"] = p_objData[iRow].m_strVENDORID_CHR;
                drNew["vendorname_vchr"] = p_objData[iRow].m_strVENDORName;
                drNew["productorid_chr"] = p_objData[iRow].m_strPRODUCTORID_CHR;
                drNew["instoragedate_dat"] = p_objData[iRow].m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
                drNew["validperiod_dat"] = p_objData[iRow].m_dtmVALIDPERIOD_DAT;
                drNew["assistcode_chr"] = p_objData[iRow].m_strMEDICINECode;
                drNew["seriesid_int"] = p_objData[iRow].m_lngSERIESID_INT;
                drNew["instorageamount"] = p_objData[iRow].m_dblInStorageAmount.ToString("0.00");
                drNew["MEDICINETYPEID_CHR"] = p_objData[iRow].m_strMEDICINETYPEID_CHR;
                drNew["packqty_dec"] = p_objData[iRow].m_dblPackQty.ToString("0.00");

                m_objViewer.m_dblAllAmount += p_objData[iRow].m_dblAVAILAGROSS_INT;
                m_objViewer.m_dtbMedicineInfo.LoadDataRow(drNew.ItemArray, true);
            }
            m_objViewer.m_dtbMedicineInfo.EndLoadData();

            if (m_objViewer.m_dblAllAmount < m_objViewer.m_dblAmount)
            {
                m_objViewer.m_lblHintText.Text = "当前可用库存少于请求出库库存";
                m_objViewer.m_lblHintText.Visible = true;
            }

            if (m_objViewer.m_dgvQueryMedicineInfo.Rows.Count > 0)
            {
                m_objViewer.m_dgvQueryMedicineInfo.Focus();
                m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[0].Cells[6];
                m_objViewer.m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
            }
        }
        #endregion
    }
}
