using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.GUI_Base;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsCtl_MedIcineCheckReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDcl_MedIcineCheckReport m_objDomain = null;
        private frmMedIcineCheckReport m_objViewer = null;
       
        private ctlQueryVendor m_ctlQueryVendor = null;
        private DataTable m_dtbVendor = null;

        public clsCtl_MedIcineCheckReport()
        {
           m_objDomain = new clsDcl_MedIcineCheckReport();
         }
        
       #region 设置窗体对象


        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMedIcineCheckReport)frmMDI_Child_Base_in;
            
        }
        

        #endregion


        #region 显示供应商查询

        /// <summary>
        /// 获取供应商信息
        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            //m_objDomain = new m_objDomain();
            long lngRes = m_objDomain.m_lngGetVendor(out p_dtbVendor);
        }
        /// <summary>
        /// 显示供应商查询
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// 
        /// <summary>
        /// 显示供应商查询
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        
        internal void m_mthShowVendor(string p_strSearchCon)
        {
            if (m_ctlQueryVendor == null)
            {
                m_mthGetVendor(out m_dtbVendor);
                m_ctlQueryVendor = new ctlQueryVendor(m_dtbVendor);
                m_objViewer.Controls.Add(m_ctlQueryVendor);

                int X = m_objViewer.panel1.Location.X + m_objViewer.m_txtProviderName.Location.X;
                int Y = m_objViewer.panel1.Location.Y + m_objViewer.m_txtProviderName.Location.Y + m_objViewer.m_txtProviderName.Size.Height;

                m_ctlQueryVendor.Location = new System.Drawing.Point(X, Y);
                m_ctlQueryVendor.ReturnInfo += new ReturnVendorInfo(QueryVendor_ReturnInfo);
            }
            m_ctlQueryVendor.BringToFront();
            m_ctlQueryVendor.m_mthSetSearchText(p_strSearchCon);
            m_ctlQueryVendor.Visible = true;
            m_ctlQueryVendor.Focus();
        }

        internal void QueryVendor_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_Vendor MS_VO)
        {
            m_objViewer.m_txtProviderName.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtProviderName.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtProviderName.Text = MS_VO.m_strVendorName;

           // m_objViewer.m_cboInComeType.Focus();
        }
        #endregion


        //#region 设置药品类型
        ///// <summary>
        ///// 设置药品类型
        ///// </summary>
        ///// <param name="p_objMPVO"></param>
        //internal void m_mthSetMedicineType(clsMS_MedicineType_VO[] p_objMPVO)
        //{
        //    if (p_objMPVO == null || m_objViewer.m_cboDoseType.Items.Count > 0)
        //    {
        //        return;
        //    }

        //    clsMS_MedicineType_VO objAll = new clsMS_MedicineType_VO();
        //    objAll.m_strMedicineTypeID_CHR = "0";
        //    objAll.m_strMedicineTypeName_VCHR = "全部";

        //    m_objViewer.m_cboDoseType.Items.Add(objAll);
        //    m_objViewer.m_cboDoseType.Items.AddRange(p_objMPVO);

        //    m_objViewer.m_cboDoseType.SelectedIndex = 0;
        //}
        //#endregion

        //public long m_getMedIcineType()
        //{
        //    long ret;
        //    clsMS_MedicineType_VO[] p_objMPVO;

        //    ret = m_objDomain.m_lngGetStorageMedicineType(m_objViewer.typeID, out p_objMPVO);
        //    m_mthSetMedicineType(p_objMPVO);
        //    return ret;
        //}


        public long m_getMedIcineCheck()
        {
            DataTable dt;
            long ret;
            if (m_objViewer.m_txtProviderName.Text.Trim() == "")
            {
                MessageBox.Show("请选译供应商名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
            clsMS_MedicineTypeSetVO objVo = m_objViewer.m_cboType.SelectedItem as clsMS_MedicineTypeSetVO;
            string strVendor = m_objViewer.m_txtProviderName.Tag.ToString();
            int intMedicinetype = objVo.m_intMedicineTypeSetID;
            string strDateStar = this.m_objViewer.dtpStar.Value.ToShortDateString() + " 00:00:00";
            string strDateEnd = this.m_objViewer.dtpEnd.Value.ToShortDateString() + " 23:59:59";
            string STORAGEID = this.m_objViewer.typeID;
            ret = this.m_objDomain.m_lngGetMedIcineCheck(strVendor, intMedicinetype, strDateStar, strDateEnd, STORAGEID, out dt);

            DataTable dtbOut = null;//外退数据
            if (m_objViewer.m_chkStatOut.Checked)
            {
                ret = m_objDomain.m_lngStatisticsForeignRetreat(STORAGEID, Convert.ToDateTime(strDateStar), Convert.ToDateTime(strDateEnd), strVendor, intMedicinetype, out dtbOut);
            }

            DataTable dtbShow = m_dtbMergeStatisticsData(dt, dtbOut);

            if (dtbShow == null || dt.Rows.Count <= 0)
            {
                MessageBox.Show("抱歉,没有找到符合条件的记录！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.m_objViewer.m_dwRpt.Reset();
                return -1;
            }
            this.m_objViewer.m_dwRpt.Modify("t_date.text = '" + DateTime.Now.ToString("yyyy年MM月dd日") + "'");
            this.m_objViewer.m_dwRpt.Modify("t_tile.text = '" + this.m_objComInfo.m_strGetHospitalTitle() + "验收单" + "'");
            this.m_objViewer.m_dwRpt.Retrieve(dt);
            return ret;
        }
        public long m_loadDwrpt()
        {

            this.m_objViewer.m_dwRpt.Modify("t_tile.text = '" + this.m_objComInfo.m_strGetHospitalTitle() + "验收单" + "'");

            return 1;
        }

        /// <summary>
        /// 合并入库统计及外退统计
        /// </summary>
        /// <param name="p_dtbData">入库统计表数据</param>
        /// <param name="p_dtbForeignRetreat">外退统计表数据</param>
        /// <returns></returns>
        private DataTable m_dtbMergeStatisticsData(DataTable p_dtbData, DataTable p_dtbForeignRetreat)
        {
            DataTable dtbReturn = null;

            if ((p_dtbData == null || p_dtbData.Rows.Count == 0) && (p_dtbForeignRetreat == null || p_dtbForeignRetreat.Rows.Count == 0))
            {
                return null;
            }

            #region 只有其中一表有数据，则返回该表，不合并
            if (p_dtbData != null && p_dtbData.Rows.Count > 0 && (p_dtbForeignRetreat == null || p_dtbForeignRetreat.Rows.Count == 0))
            {
                dtbReturn = p_dtbData;
                return dtbReturn;
            }
            if (p_dtbForeignRetreat != null && p_dtbForeignRetreat.Rows.Count > 0 && (p_dtbData == null || p_dtbData.Rows.Count == 0))
            {
                DataRow drTemp = null;
                int intRowsCount = p_dtbForeignRetreat.Rows.Count;
                string strVendorName = string.Empty;//供应商名
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = p_dtbForeignRetreat.Rows[iRow];
                    strVendorName = drTemp["vendorname_vchr"].ToString();
                    if (string.IsNullOrEmpty(strVendorName))
                    {
                        drTemp["vendorname_vchr"] = "退";
                    }
                    else
                    {
                        drTemp["vendorname_vchr"] = "退(" + strVendorName + ")";
                    }
                }
                dtbReturn = p_dtbForeignRetreat;
                return dtbReturn;
            }
            #endregion

            int intInDataCount = p_dtbData.Rows.Count;//入库统计行数            
            DataRow drInTemp = null;
            for (int iInRow = 0; iInRow < intInDataCount; iInRow++)
            {
                drInTemp = p_dtbData.Rows[iInRow];
                //获取相同供应商相同分类的数据行
                DataRow[] drOut = p_dtbForeignRetreat.Select("vendorname_vchr = '" + drInTemp["vendorname_vchr"].ToString() + "' and medicinetypename_vchr = '" + drInTemp["medicinetypename_vchr"].ToString() + "'");
                if (drOut != null && drOut.Length > 0)
                {
                    //入库统计中的金额减去外退金额
                    double dblInMoney = Convert.ToDouble(drInTemp["sum_callprice_int"]);
                    double dblWholeSaleMoney = Convert.ToDouble(drInTemp["sum_wholesaleprice_int"]);
                    double dblRetailMoney = Convert.ToDouble(drInTemp["sum_retailprice_int"]);
                    for (int iRow = 0; iRow < drOut.Length; iRow++)
                    {
                        dblInMoney -= Convert.ToDouble(drOut[iRow]["sum_callprice_int"]);
                        dblWholeSaleMoney -= Convert.ToDouble(drOut[iRow]["sum_wholesaleprice_int"]);
                        dblRetailMoney -= Convert.ToDouble(drOut[iRow]["sum_retailprice_int"]);
                    }

                    drInTemp["sum_callprice_int"] = dblInMoney.ToString("0.0000");
                    drInTemp["sum_wholesaleprice_int"] = dblWholeSaleMoney.ToString("0.0000");
                    drInTemp["sum_retailprice_int"] = dblRetailMoney.ToString("0.0000");

                    foreach (DataRow drDel in drOut)
                    {
                        p_dtbForeignRetreat.Rows.Remove(drDel);
                    }
                }
            }

            #region 外理外退数据
            //如有剩余外退统计供应商数据，即此外退供应商未能与入库统计中的供应商相对应，则在供应商名前标明"退"
            //同时将这些数据添加至返回表中
            int intOutDataCount = p_dtbForeignRetreat.Rows.Count;
            if (intOutDataCount > 0)
            {
                DataRow drTemp = null;
                string strVendorName = string.Empty;//供应商名
                for (int iRow = 0; iRow < intOutDataCount; iRow++)
                {
                    drTemp = p_dtbForeignRetreat.Rows[iRow];
                    strVendorName = drTemp["vendorname_vchr"].ToString();
                    if (string.IsNullOrEmpty(strVendorName))
                    {
                        drTemp["vendorname_vchr"] = "退";
                    }
                    else
                    {
                        drTemp["vendorname_vchr"] = "退(" + strVendorName + ")";
                    }
                }
                dtbReturn = p_dtbForeignRetreat;
            }
            #endregion

            if (dtbReturn != null)//有剩余外退统计供应商数据
            {
                try
                {
                    dtbReturn.BeginLoadData();
                    for (int iInRow = 0; iInRow < intInDataCount; iInRow++)
                    {
                        dtbReturn.LoadDataRow(p_dtbData.Rows[iInRow].ItemArray, true);
                    }
                }
                catch (Exception Ex)
                {
                    string strEx = Ex.Message;
                }
                finally
                {
                    dtbReturn.EndLoadData();
                }
            }
            else
            {
                dtbReturn = p_dtbData;
            }
            return dtbReturn;
        }

        #region 获取药品类型设置
        /// <summary>
        /// 获取药品类型设置
        /// </summary>
        internal void m_mthGetMedicineTypeSet()
        {
            clsMS_MedicineTypeSetVO[] objMPVO = null;
            clsDcl_MedicineTypeSet objMTDomain = new clsDcl_MedicineTypeSet();
            long lngRes = objMTDomain.m_lngGetAllMedicinTypeSetInfo(out objMPVO);
            objMTDomain = null;

            if (objMPVO == null || m_objViewer.m_cboType.Items.Count > 0)
            {
                return;
            }

            clsMS_MedicineTypeSetVO objAll = new clsMS_MedicineTypeSetVO();
            objAll.m_intMedicineTypeSetID = 0;
            objAll.m_strMedicineTypeSetName = "全部";

            m_objViewer.m_cboType.Items.Add(objAll);
            m_objViewer.m_cboType.Items.AddRange(objMPVO);

            m_objViewer.m_cboType.SelectedIndex = 0;
        }
        #endregion
    }
}
