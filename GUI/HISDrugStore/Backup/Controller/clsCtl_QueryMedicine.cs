using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Windows.Forms;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 选择药品控制类
    /// </summary>
    public class clsCtl_QueryMedicine : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmQueryMedicine)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 药品出库药品信息浏览
        /// </summary>
        public clsCtl_QueryMedicine()
        {
        }

        /// <summary>
        /// 选择药品主界面
        /// </summary>
        private frmQueryMedicine m_objViewer;        

        #region 初始化药品数据源
        /// <summary>
        /// 初始化药品数据源
        /// </summary>
        /// <param name="p_dtbSource"></param>
        internal void m_mthInitDataSouce(ref DataTable p_dtbSource)
        {
            p_dtbSource = new DataTable();
            DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEID_CHR"), new DataColumn("medicinename_vchr"), new DataColumn("MEDSPEC_VCHR"),new DataColumn("OPUNIT_CHR"),
                new DataColumn("NETAMOUNT_INT"),new DataColumn("LOTNO_VCHR"),new DataColumn("OPWHOLESALEPRICE_INT"),new DataColumn("MEDICINETYPEID_CHR"),new DataColumn("INSTOREID_VCHR"),new DataColumn("DSINSTOREID_VCHR"),
                new DataColumn("OPRETAILPRICE_INT"),new DataColumn("validperiod_dat"),new DataColumn("oprealgross_int"),new DataColumn("assistcode_chr"),new DataColumn("instoragedate_dat"),
                new DataColumn("opavailagross_int"),new DataColumn("seriesid_int"),new DataColumn("packqty_dec",typeof(double)), new DataColumn("ipunit_chr",typeof(string)),
                new DataColumn("ipretailprice_int",typeof(double)),new DataColumn("ipwholesaleprice_int",typeof(double)),new DataColumn("iprealgross_int",typeof(double)),
                new DataColumn("ipavailablegross_num",typeof(double)),new DataColumn("productorid_chr",typeof(string)),new DataColumn("opchargeflg_int",typeof(double)),new DataColumn("ipchargeflg_int",typeof(double)),
            new DataColumn("unit_chr",typeof(string)),new DataColumn("realgross_int",typeof(double)),new DataColumn("availagross_int",typeof(double)),
            new DataColumn("WHOLESALEPRICE_INT",typeof(double)),new DataColumn("RETAILPRICE_INT",typeof(double)),new DataColumn("amount_int",typeof(double)),new DataColumn("ipamount_int",typeof(double))};
            p_dtbSource.Columns.AddRange(drColumns);
        }
        #endregion

        #region 设置药品数据至界面(作废)
        /*
        /// <summary>
        /// 设置药品数据至界面
        /// </summary>
        /// <param name="p_objData"></param>
        /// <param name="hstNoChange"></param>
        internal void m_mthSetDataToUI(clsDS_StorageDetail_VO[] p_objData, Hashtable hstNoChange, Hashtable hstCurrent)//clsDS_UpdateStorageBySeriesID_VO[] p_objForUpdateArr)
        {
            if (p_objData == null || m_objViewer.m_dtbMedicineInfo == null)
            {
                return;
            }

            //m_objData = p_objData;

            DataRow drNew = null;
            double dblOP = 0;
            double dblTemp = 0d;
            double dblCurrentAmount = m_objViewer.m_dblAmount;
            m_objViewer.m_dtbMedicineInfo.BeginLoadData();
            for (int iRow = 0; iRow < p_objData.Length; iRow++)
            {
                if (hstNoChange != null && hstNoChange.Count > 0)
                {                    
                    if (hstNoChange.ContainsKey(p_objData[iRow].m_lngSERIESID_INT))
                    {
                        //20081112 界面上已经出库的相同药品数量，如果大于可用库存，则显示0
                        if (p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM >= Convert.ToDouble(hstNoChange[p_objData[iRow].m_lngSERIESID_INT]))
                        {
                            p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM -= Convert.ToDouble(hstNoChange[p_objData[iRow].m_lngSERIESID_INT]);
                            //p_objData[iRow].m_dblIPREALGROSS_INT -= Convert.ToDouble(hstNoChange[p_objData[iRow].m_lngSERIESID_INT]);

                            p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM -= Convert.ToDouble(hstNoChange[p_objData[iRow].m_lngSERIESID_INT]) / p_objData[iRow].m_dblPACKQTY_DEC;
                            //p_objData[iRow].m_dblOPREALGROSS_INT -= Convert.ToDouble(hstNoChange[p_objData[iRow].m_lngSERIESID_INT]) / p_objData[iRow].m_dblPACKQTY_DEC;
                        }
                        else
                        {
                             p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM = 0;
                            //p_objData[iRow].m_dblIPREALGROSS_INT = 0;
                            p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM = 0;
                            //p_objData[iRow].m_dblOPREALGROSS_INT = 0;
                        }                        
                    }
                }

                drNew = m_objViewer.m_dtbMedicineInfo.NewRow();
                if (dblCurrentAmount <= 0)
                {
                    drNew["IPAMOUNT_INT"] = dblCurrentAmount;
                    dblCurrentAmount = 0;
                }
                else
                {
                    //if (p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM <= 0)
                    //{
                    //    continue;
                    //}
                }
                drNew["MEDICINEID_CHR"] = p_objData[iRow].m_strMEDICINEID_CHR;
                drNew["MEDICINENAME_VCHR"] = p_objData[iRow].m_strMEDICINENAME_VCHR;
                drNew["MEDSPEC_VCHR"] = p_objData[iRow].m_strMEDSPEC_VCHR;
                drNew["OPUNIT_CHR"] = p_objData[iRow].m_strOPUNIT_CHR;
                
                
                
                if (dblCurrentAmount > 0)
                {
                    if (dblCurrentAmount > p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM)
                    {
                        drNew["IPAMOUNT_INT"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                        dblCurrentAmount -= p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM;
                    }
                    else
                    {
                        drNew["IPAMOUNT_INT"] = dblCurrentAmount;
                        dblCurrentAmount = 0;
                    }
                }
                else
                {
                    double.TryParse(Convert.ToString(drNew["IPAMOUNT_INT"]), out dblTemp);
                    drNew["IPAMOUNT_INT"] = dblTemp;
                }
                
                drNew["amount_int"] = drNew["IPAMOUNT_INT"];
                drNew["iprealgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT.ToString("0.00");
                if (hstCurrent == null || hstCurrent.Count == 0)
                    drNew["ipavailablegross_num"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                else
                {
                    if (hstCurrent.ContainsKey(p_objData[iRow].m_lngSERIESID_INT))
                    {
                        drNew["ipavailablegross_num"] = Convert.ToDouble(p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM) + Convert.ToDouble(hstCurrent[p_objData[iRow].m_lngSERIESID_INT]);
                    }
                    else
                        drNew["ipavailablegross_num"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM;
                }
                drNew["oprealgross_int"] = p_objData[iRow].m_dblOPREALGROSS_INT.ToString("0.00");
                drNew["opavailagross_int"] = p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM.ToString("0.00");
                drNew["LOTNO_VCHR"] = p_objData[iRow].m_strLOTNO_VCHR;
                drNew["INSTOREID_VCHR"] = p_objData[iRow].m_strINSTOREID_VCHR;
                drNew["DSINSTOREID_VCHR"] = p_objData[iRow].m_strDSINSTOREID_VCHR;   
                drNew["OPWHOLESALEPRICE_INT"] = p_objData[iRow].m_dblOPWHOLESALEPRICE_INT.ToString("0.0000");
                drNew["OPRETAILPRICE_INT"] = p_objData[iRow].m_dblOPRETAILPRICE_INT.ToString("0.0000");                
                drNew["instoragedate_dat"] = p_objData[iRow].m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
                if (p_objData[iRow].m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd") == "0001-01-01")
                {
                    drNew["validperiod_dat"] = DBNull.Value;
                }
                else
                {
                    drNew["validperiod_dat"] = p_objData[iRow].m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd");
                }
                drNew["assistcode_chr"] = p_objData[iRow].m_strASSISTCODE_CHR;
                drNew["seriesid_int"] = p_objData[iRow].m_lngSERIESID_INT;                
                drNew["MEDICINETYPEID_CHR"] = p_objData[iRow].m_strMEDICINETYPEID_CHR;
                drNew["packqty_dec"] = Convert.ToDouble(p_objData[iRow].m_dblPACKQTY_DEC);
                drNew["ipunit_chr"] = p_objData[iRow].m_strIPUNIT_CHR;
                drNew["ipretailprice_int"] = p_objData[iRow].m_dblIPRETAILPRICE_INT.ToString("0.0000");
                drNew["ipwholesaleprice_int"] = p_objData[iRow].m_dblIPWHOLESALEPRICE_INT.ToString("0.0000");
                //drNew["iprealgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT.ToString("0.00");
                //drNew["ipavailablegross_num"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                drNew["productorid_chr"] = p_objData[iRow].m_strPRODUCTORID_CHR;
                drNew["opchargeflg_int"] = p_objData[iRow].m_dblOPCHARGEFLG_INT;
                drNew["ipchargeflg_int"] = p_objData[iRow].m_dblIPCHARGEFLG_INT;
                //20081027 显示的数量，全部以最小单位为准
                if (m_objViewer.m_blnIsHospital)
                {
                    if (p_objData[iRow].m_dblIPCHARGEFLG_INT == 0)
                    {
                        drNew["NETAMOUNT_INT"] = drNew["amount_int"];
                        drNew["unit_chr"] = p_objData[iRow].m_strOPUNIT_CHR;
                        drNew["realgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT / p_objData[iRow].m_dblPACKQTY_DEC; //p_objData[iRow].m_dblOPREALGROSS_INT;
                        drNew["availagross_int"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objData[iRow].m_dblPACKQTY_DEC; //p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM;
                        drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dblOPWHOLESALEPRICE_INT.ToString("0.0000");
                        drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dblOPRETAILPRICE_INT.ToString("0.0000");
                    }
                    else
                    {
                        drNew["NETAMOUNT_INT"] = Convert.ToDouble(drNew["amount_int"]) / p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["unit_chr"] = p_objData[iRow].m_strIPUNIT_CHR;
                        drNew["realgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT;// p_objData[iRow].m_dblOPREALGROSS_INT * p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["availagross_int"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM;// Convert.ToDouble(drNew["opavailagross_int"]) * p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dblIPWHOLESALEPRICE_INT;
                        drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dblIPRETAILPRICE_INT;
                    }
                }
                else
                {
                    if (p_objData[iRow].m_dblOPCHARGEFLG_INT == 0)
                    {
                        drNew["NETAMOUNT_INT"] = drNew["amount_int"];
                        drNew["unit_chr"] = p_objData[iRow].m_strOPUNIT_CHR;
                        drNew["realgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT / p_objData[iRow].m_dblPACKQTY_DEC; //p_objData[iRow].m_dblOPREALGROSS_INT;
                        drNew["availagross_int"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objData[iRow].m_dblPACKQTY_DEC; //p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM;
                        drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dblOPWHOLESALEPRICE_INT.ToString("0.0000");
                        drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dblOPRETAILPRICE_INT.ToString("0.0000");
                    }
                    else
                    {
                        drNew["NETAMOUNT_INT"] = Convert.ToDouble(drNew["amount_int"]) / p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["unit_chr"] = p_objData[iRow].m_strIPUNIT_CHR;
                        drNew["realgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT;// p_objData[iRow].m_dblOPREALGROSS_INT * p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["availagross_int"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM;// Convert.ToDouble(drNew["opavailagross_int"]) * p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dblIPWHOLESALEPRICE_INT;
                        drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dblIPRETAILPRICE_INT;
                    }
                }
                //m_objViewer.m_dblAllAmount += Convert.ToDouble(drNew["iprealgross_int"]);// ipavailablegross_num  20080822
                m_objViewer.m_dblAllAmount += Convert.ToDouble(drNew["ipavailablegross_num"]);// iprealgross_int  20081105
                m_objViewer.m_dtbMedicineInfo.LoadDataRow(drNew.ItemArray, true);
            }
            m_objViewer.m_dtbMedicineInfo.EndLoadData();

            if (m_objViewer.m_dblAllAmount < m_objViewer.m_dblAmount && m_objViewer.m_dblAmount > 0)
            {
                m_objViewer.m_lblHintText.Text = "当前可用库存少于请求出库库存";//"当前实际库存少于请求出库库存";
                m_objViewer.m_lblHintText.Visible = true;
            }

            if (m_objViewer.m_dgvQueryMedicineInfo.Rows.Count > 0)
            {
                m_objViewer.m_dgvQueryMedicineInfo.Focus();
                m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[0].Cells[14];
                m_objViewer.m_dgvQueryMedicineInfo.CurrentCell.Selected = true;
            }
        }
        */
        #endregion

        #region 设置药品数据至界面(三院模式计算格式)杨镇伟
        /// <summary>
        /// 设置药品数据至界面
        /// </summary>
        /// <param name="p_objData"></param>
        /// <param name="hstNoChange">  新数据 </param>
        /// <param name="hstCurrent"> 旧数据 </param>
        internal void m_mthSetDataToUI(clsDS_StorageDetail_VO[] p_objData, Hashtable hstNoChange, Hashtable hstCurrent)//clsDS_UpdateStorageBySeriesID_VO[] p_objForUpdateArr)
        {
            if (p_objData == null || m_objViewer.m_dtbMedicineInfo == null)
            {
                return;
            }

            /* m_objData = p_objData;*/

            DataRow drNew = null;
            double dblOP = 0;
            double dblTemp = 0d;
            double dblCurrentAmount = m_objViewer.m_dblAmount;
            m_objViewer.m_dtbMedicineInfo.BeginLoadData();
            double dblOldGross = 0d;
            for (int iRow = 0; iRow < p_objData.Length; iRow++)
            {
                dblOldGross = 0d;
                if (hstNoChange != null && hstNoChange.Count > 0 && hstNoChange.ContainsKey(p_objData[iRow].m_lngSERIESID_INT))
                {
                    dblOldGross = Convert.ToDouble(hstNoChange[p_objData[iRow].m_lngSERIESID_INT]);
                }

                if (hstCurrent != null && hstCurrent.Count > 0 && hstCurrent.ContainsKey(p_objData[iRow].m_lngSERIESID_INT.ToString()))
                {
                    dblOldGross += Convert.ToDouble(hstCurrent[p_objData[iRow].m_lngSERIESID_INT.ToString()]);
                }

                if (p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM >= dblOldGross)
                {
                    p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM -= dblOldGross;
                    p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM -= dblOldGross / p_objData[iRow].m_dblPACKQTY_DEC;
                }
                else
                {
                    p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM = 0;
                    p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM = 0;
                }

                drNew = m_objViewer.m_dtbMedicineInfo.NewRow();
                if (dblCurrentAmount <= 0)
                {
                    drNew["IPAMOUNT_INT"] = dblCurrentAmount;
                    dblCurrentAmount = 0;
                }

                drNew["MEDICINEID_CHR"] = p_objData[iRow].m_strMEDICINEID_CHR;
                drNew["MEDICINENAME_VCHR"] = p_objData[iRow].m_strMEDICINENAME_VCHR;
                drNew["MEDSPEC_VCHR"] = p_objData[iRow].m_strMEDSPEC_VCHR;
                drNew["OPUNIT_CHR"] = p_objData[iRow].m_strOPUNIT_CHR;

                if (m_objViewer.m_blnIsHospital)
                {
                    if (p_objData[iRow].m_dblIPCHARGEFLG_INT == 0)
                    {
                        if (iRow == 0)
                        {
                            m_objViewer.m_dblAmount *= p_objData[iRow].m_dblPACKQTY_DEC;
                        }
                        if (dblCurrentAmount > 0)
                        {
                            if (dblCurrentAmount > p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objData[iRow].m_dblPACKQTY_DEC)
                            {
                                drNew["IPAMOUNT_INT"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                                dblCurrentAmount -= p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objData[iRow].m_dblPACKQTY_DEC;
                            }
                            else
                            {
                                drNew["IPAMOUNT_INT"] = dblCurrentAmount * p_objData[iRow].m_dblPACKQTY_DEC;
                                dblCurrentAmount = 0;
                            }
                        }
                        else
                        {
                            double.TryParse(Convert.ToString(drNew["IPAMOUNT_INT"]), out dblTemp);
                            drNew["IPAMOUNT_INT"] = dblTemp;
                        }
                        drNew["amount_int"] = Convert.ToDouble(Convert.ToDouble(drNew["IPAMOUNT_INT"]) / p_objData[iRow].m_dblPACKQTY_DEC).ToString("F2");
                    }
                    else
                    {
                        if (dblCurrentAmount > 0)
                        {
                            if (dblCurrentAmount > p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM)
                            {
                                drNew["IPAMOUNT_INT"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                                dblCurrentAmount -= p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM;
                            }
                            else
                            {
                                drNew["IPAMOUNT_INT"] = dblCurrentAmount;
                                dblCurrentAmount = 0;
                            }
                        }
                        else
                        {
                            double.TryParse(Convert.ToString(drNew["IPAMOUNT_INT"]), out dblTemp);
                            drNew["IPAMOUNT_INT"] = dblTemp;
                        }
                        drNew["amount_int"] = drNew["IPAMOUNT_INT"];
                    }
                }
                else
                {
                    if (p_objData[iRow].m_dblOPCHARGEFLG_INT == 0)
                    {
                        if (iRow == 0)
                        {
                            m_objViewer.m_dblAmount *= p_objData[iRow].m_dblPACKQTY_DEC;
                        }
                        if (dblCurrentAmount > 0)
                        {
                            if (dblCurrentAmount > p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objData[iRow].m_dblPACKQTY_DEC)
                            {
                                drNew["IPAMOUNT_INT"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                                dblCurrentAmount -= p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objData[iRow].m_dblPACKQTY_DEC;
                            }
                            else
                            {
                                drNew["IPAMOUNT_INT"] = dblCurrentAmount * p_objData[iRow].m_dblPACKQTY_DEC;
                                dblCurrentAmount = 0;
                            }
                        }
                        else
                        {
                            double.TryParse(Convert.ToString(drNew["IPAMOUNT_INT"]), out dblTemp);
                            drNew["IPAMOUNT_INT"] = dblTemp;
                        }
                        drNew["amount_int"] = Convert.ToDouble(Convert.ToDouble(drNew["IPAMOUNT_INT"]) / p_objData[iRow].m_dblPACKQTY_DEC).ToString("F2");
                    }
                    else
                    {
                        if (dblCurrentAmount > 0)
                        {
                            if (dblCurrentAmount > p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM)
                            {
                                drNew["IPAMOUNT_INT"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                                dblCurrentAmount -= p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM;
                            }
                            else
                            {
                                drNew["IPAMOUNT_INT"] = dblCurrentAmount;
                                dblCurrentAmount = 0;
                            }
                        }
                        else
                        {
                            double.TryParse(Convert.ToString(drNew["IPAMOUNT_INT"]), out dblTemp);
                            drNew["IPAMOUNT_INT"] = dblTemp;
                        }
                        drNew["amount_int"] = drNew["IPAMOUNT_INT"];
                    }
                }

                drNew["iprealgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT.ToString("0.00");
                drNew["ipavailablegross_num"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                //if (hstCurrent == null || hstCurrent.Count == 0)
                //    drNew["ipavailablegross_num"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                //else
                //{
                //    if (hstCurrent.ContainsKey(p_objData[iRow].m_lngSERIESID_INT))
                //    {
                //        drNew["ipavailablegross_num"] = Convert.ToDouble(p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM) + Convert.ToDouble(hstCurrent[p_objData[iRow].m_lngSERIESID_INT]);
                //    }
                //    else
                //        drNew["ipavailablegross_num"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM;
                //}
                drNew["oprealgross_int"] = p_objData[iRow].m_dblOPREALGROSS_INT.ToString("0.00");
                drNew["opavailagross_int"] = p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM.ToString("0.00");
                drNew["LOTNO_VCHR"] = p_objData[iRow].m_strLOTNO_VCHR;
                drNew["INSTOREID_VCHR"] = p_objData[iRow].m_strINSTOREID_VCHR;
                drNew["DSINSTOREID_VCHR"] = p_objData[iRow].m_strDSINSTOREID_VCHR;
                drNew["OPWHOLESALEPRICE_INT"] = p_objData[iRow].m_dblOPWHOLESALEPRICE_INT.ToString("0.0000");
                drNew["OPRETAILPRICE_INT"] = p_objData[iRow].m_dblOPRETAILPRICE_INT.ToString("0.0000");
                drNew["instoragedate_dat"] = p_objData[iRow].m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
                if (p_objData[iRow].m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd") == "0001-01-01")
                {
                    drNew["validperiod_dat"] = DBNull.Value;
                }
                else
                {
                    drNew["validperiod_dat"] = p_objData[iRow].m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd");
                }
                drNew["assistcode_chr"] = p_objData[iRow].m_strASSISTCODE_CHR;
                drNew["seriesid_int"] = p_objData[iRow].m_lngSERIESID_INT;
                drNew["MEDICINETYPEID_CHR"] = p_objData[iRow].m_strMEDICINETYPEID_CHR;
                drNew["packqty_dec"] = Convert.ToDouble(p_objData[iRow].m_dblPACKQTY_DEC);
                drNew["ipunit_chr"] = p_objData[iRow].m_strIPUNIT_CHR;
                drNew["ipretailprice_int"] = p_objData[iRow].m_dblIPRETAILPRICE_INT.ToString("0.0000");
                drNew["ipwholesaleprice_int"] = p_objData[iRow].m_dblIPWHOLESALEPRICE_INT.ToString("0.0000");
                //drNew["iprealgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT.ToString("0.00");
                //drNew["ipavailablegross_num"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM.ToString("0.00");
                drNew["productorid_chr"] = p_objData[iRow].m_strPRODUCTORID_CHR;
                drNew["opchargeflg_int"] = p_objData[iRow].m_dblOPCHARGEFLG_INT;
                drNew["ipchargeflg_int"] = p_objData[iRow].m_dblIPCHARGEFLG_INT;
                //20081027 显示的数量，全部以最小单位为准
                if (m_objViewer.m_blnIsHospital)
                {
                    if (p_objData[iRow].m_dblIPCHARGEFLG_INT == 0)
                    {
                        drNew["NETAMOUNT_INT"] = drNew["amount_int"];
                        drNew["unit_chr"] = p_objData[iRow].m_strOPUNIT_CHR;
                        drNew["realgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT / p_objData[iRow].m_dblPACKQTY_DEC; //p_objData[iRow].m_dblOPREALGROSS_INT;
                        drNew["availagross_int"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objData[iRow].m_dblPACKQTY_DEC; //p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM;
                        drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dblOPWHOLESALEPRICE_INT.ToString("0.0000");
                        drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dblOPRETAILPRICE_INT.ToString("0.0000");
                    }
                    else
                    {
                        drNew["NETAMOUNT_INT"] = Convert.ToDouble(drNew["amount_int"]) / p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["unit_chr"] = p_objData[iRow].m_strIPUNIT_CHR;
                        drNew["realgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT;// p_objData[iRow].m_dblOPREALGROSS_INT * p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["availagross_int"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM;// Convert.ToDouble(drNew["opavailagross_int"]) * p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dblIPWHOLESALEPRICE_INT;
                        drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dblIPRETAILPRICE_INT;
                    }
                }
                else
                {
                    if (p_objData[iRow].m_dblOPCHARGEFLG_INT == 0)
                    {
                        drNew["NETAMOUNT_INT"] = drNew["amount_int"];
                        drNew["unit_chr"] = p_objData[iRow].m_strOPUNIT_CHR;
                        drNew["realgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT / p_objData[iRow].m_dblPACKQTY_DEC; //p_objData[iRow].m_dblOPREALGROSS_INT;
                        drNew["availagross_int"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM / p_objData[iRow].m_dblPACKQTY_DEC; //p_objData[iRow].m_dblOPAVAILABLEGROSS_NUM;
                        drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dblOPWHOLESALEPRICE_INT.ToString("0.0000");
                        drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dblOPRETAILPRICE_INT.ToString("0.0000");
                    }
                    else
                    {
                        drNew["NETAMOUNT_INT"] = Convert.ToDouble(drNew["amount_int"]) / p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["unit_chr"] = p_objData[iRow].m_strIPUNIT_CHR;
                        drNew["realgross_int"] = p_objData[iRow].m_dblIPREALGROSS_INT;// p_objData[iRow].m_dblOPREALGROSS_INT * p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["availagross_int"] = p_objData[iRow].m_dblIPAVAILABLEGROSS_NUM;// Convert.ToDouble(drNew["opavailagross_int"]) * p_objData[iRow].m_dblPACKQTY_DEC;
                        drNew["WHOLESALEPRICE_INT"] = p_objData[iRow].m_dblIPWHOLESALEPRICE_INT;
                        drNew["RETAILPRICE_INT"] = p_objData[iRow].m_dblIPRETAILPRICE_INT;
                    }
                }
                //m_objViewer.m_dblAllAmount += Convert.ToDouble(drNew["iprealgross_int"]);// ipavailablegross_num  20080822
                m_objViewer.m_dblAllAmount += Convert.ToDouble(drNew["ipavailablegross_num"]);// iprealgross_int  20081105
                m_objViewer.m_dtbMedicineInfo.LoadDataRow(drNew.ItemArray, true);
            }
            m_objViewer.m_dtbMedicineInfo.EndLoadData();

            if (m_objViewer.m_dblAllAmount < m_objViewer.m_dblAmount && m_objViewer.m_dblAmount > 0)
            {
                m_objViewer.m_lblHintText.Text = "当前可用库存少于请求出库库存";//"当前实际库存少于请求出库库存";
                m_objViewer.m_lblHintText.Visible = true;
            }

            if (m_objViewer.m_dgvQueryMedicineInfo.Rows.Count > 0)
            {
                m_objViewer.m_dgvQueryMedicineInfo.Focus();
                m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[0].Cells[14];
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
        internal clsDS_StorageMedicineShow[] m_objGetVOFromTable(out int p_intStatus)
        {
            p_intStatus = 1;
            clsDS_StorageMedicineShow[] objValueArr = null;
            if (m_objViewer.m_dtbMedicineInfo != null)
            {
                int intRowsCount = m_objViewer.m_dtbMedicineInfo.Rows.Count;
                if (intRowsCount == 0)
                {
                    return null;
                }

                clsDS_StorageMedicineShow objValue = null;
                List<clsDS_StorageMedicineShow> lstMedicineInfo = new List<clsDS_StorageMedicineShow>();
                DataRow drTemp = null;
                double dblTemp = 0d;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = m_objViewer.m_dtbMedicineInfo.Rows[iRow];
                    if (Convert.ToString(drTemp["AMOUNT_INT"]) == "")
                        drTemp["AMOUNT_INT"] = 0;
                    if (double.TryParse(drTemp["AMOUNT_INT"].ToString(), out dblTemp))
                    {
                        //if (dblTemp < 0)
                        //{
                        //    MessageBox.Show("出库数量不能为负数", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    m_objViewer.m_dgvQueryMedicineInfo.Focus();
                        //    m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[iRow].Cells[14];
                        //    p_intStatus = 0;
                        //    return null;
                        //}
                        //else 
                        if (dblTemp == 0)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("出库数量必须为数字", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_objViewer.m_dgvQueryMedicineInfo.Focus();
                        m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[iRow].Cells[14];
                        p_intStatus = 0;
                        return null;
                    }

                    objValue = new clsDS_StorageMedicineShow();
                    objValue.m_strMEDICINEID_CHR = drTemp["MEDICINEID_CHR"].ToString();
                    objValue.m_strMEDICINENAME_VCHR = drTemp["MEDICINENAME_VCHR"].ToString();
                    objValue.m_strMEDSPEC_VCHR = drTemp["MEDSPEC_VCHR"].ToString();
                    objValue.m_strLOTNO_VCHR = drTemp["LOTNO_VCHR"].ToString();
                    objValue.m_dcmOPRETAILPRICE_INT = Convert.ToDecimal(drTemp["OPRETAILPRICE_INT"]);
                    objValue.m_dcmOPWHOLESALEPRICE_INT = Convert.ToDecimal(drTemp["OPWHOLESALEPRICE_INT"]);
                    objValue.m_dblOPREALGROSS_INT = Convert.ToDouble(drTemp["OPREALGROSS_INT"]);
                    objValue.m_dblOPAVAILAGROSS_INT = Convert.ToDouble(drTemp["OPAVAILAGROSS_INT"]);
                    objValue.m_strOPUNIT_VCHR = drTemp["OPUNIT_CHR"].ToString();
                    if (Convert.ToString(drTemp["VALIDPERIOD_DAT"]).Length > 0)
                        objValue.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drTemp["VALIDPERIOD_DAT"]).Date;
                    objValue.m_strINSTOREID_VCHR = drTemp["INSTOREID_VCHR"].ToString();
                    objValue.m_dtmINSTOREDATE_DAT = Convert.ToDateTime(drTemp["INSTORAGEDATE_DAT"]);
                    objValue.m_strDSINSTOREID_VCHR = drTemp["DSINSTOREID_VCHR"].ToString();
                    objValue.m_strASSISTCODE_CHR = drTemp["assistcode_chr"].ToString();
                    objValue.m_lngSERIESID_INT = m_objViewer.m_lngSeriesID;
                    objValue.m_strStorageseriesid_chr = drTemp["seriesid_int"].ToString();
                    objValue.m_dblOutAmount = Convert.ToDouble(drTemp["NETAMOUNT_INT"]);
                    objValue.m_strMedicineTypeID_CHR = drTemp["MEDICINETYPEID_CHR"].ToString();
                    objValue.m_dblPACKQTY_DEC = Convert.ToDouble(drTemp["packqty_dec"]);
                    objValue.m_strIPUNIT_VCHR = drTemp["ipunit_chr"].ToString();
                    objValue.m_dcmIPRETAILPRICE_INT = Convert.ToDecimal(drTemp["ipretailprice_int"]);
                    objValue.m_dcmIPWHOLESALEPRICE_INT = Convert.ToDecimal(drTemp["ipwholesaleprice_int"]);
                    objValue.m_dblIPREALGROSS_INT = Convert.ToDouble(drTemp["iprealgross_int"]);
                    objValue.m_dblIPAVAILAGROSS_INT = Convert.ToDouble(drTemp["ipavailablegross_num"]);
                    objValue.m_strPRODUCTORID_CHR = drTemp["productorid_chr"].ToString();
                    objValue.m_dblOPCHARGEFLG_INT = Convert.ToDouble(drTemp["opchargeflg_int"]);
                    objValue.m_dblIPCHARGEFLG_INT = Convert.ToDouble(drTemp["ipchargeflg_int"]);
                    objValue.m_dblChargeAmount = Convert.ToDouble(drTemp["amount_int"]);
                    //20080822 不卡可用库存，而改为卡实际库存realgross_int
                    //if (dblTemp > 0 &&  dblTemp > double.Parse(Convert.ToDouble(drTemp["AVAILAGROSS_INT"]).ToString("F2")))//20080326起，药房库存数量判断应以最小单位为准。而非.m_dblOPAVAILAGROSS_INT)
                    //20081105 又改回8月22日的卡可用库存 if (dblTemp > 0 && dblTemp > double.Parse(Convert.ToDouble(drTemp["realgross_int"]).ToString("F2")))
                    if (dblTemp > 0 && dblTemp > double.Parse(Convert.ToDouble(drTemp["AVAILAGROSS_INT"]).ToString("F2")))
                    {
                        //MessageBox.Show("出库数量不能大于实际库存", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show("出库数量不能大于可用库存", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_objViewer.m_dgvQueryMedicineInfo.Focus();
                        m_objViewer.m_dgvQueryMedicineInfo.CurrentCell = m_objViewer.m_dgvQueryMedicineInfo.Rows[iRow].Cells[14];
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
    }
}
