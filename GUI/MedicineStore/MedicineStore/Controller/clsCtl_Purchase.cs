using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药品入库
    /// </summary>
    public class clsCtl_Purchase : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_Purchase m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmPurchase m_objViewer;
        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 供应商
        /// </summary>
        private DataTable m_dtbVendor = null;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null; 
        #endregion

        #region 药品入库
        /// <summary>
        /// 药品入库
        /// </summary>
        public clsCtl_Purchase()
        {
            m_objDomain = new clsDcl_Purchase();
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
            m_objViewer = (frmPurchase)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <param name="p_dtmBegin">查询开始时间</param>
        /// <param name="p_dtmEnd">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_dtbValue">主表内容</param>
        internal void m_mthGetMainData(DateTime p_dtmBegin, DateTime p_dtmEnd, string p_strStorageID, out DataTable p_dtbValue)
        {
            long lngRes = m_objDomain.m_lngGetInStorage(p_dtmBegin, p_dtmEnd, p_strStorageID, out p_dtbValue);
        }

        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strMedicinePreptype">药品剂型</param>
        /// <param name="p_dtbValue">主表内容</param>
        internal void m_mthGetMainData(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID,
            string p_strMedicineName, string p_strVendorName,  string p_strInStorageID, string p_strMedicinePreptype,out DataTable p_dtbValue)
        {
            long lngRes = m_objDomain.m_lngGetInStorage(p_dtmBeginDate, p_dtmEndDate, p_strStorageID, p_strMedicineName, p_strVendorName, p_strInStorageID,p_strMedicinePreptype, out p_dtbValue);


            if (p_dtbValue != null)
            {
                string strUnCommit = "STATE_INT = 1 and EXAMERID_CHR is not null";
                DataRow[] drUnCommit = p_dtbValue.Select(strUnCommit);
                if (drUnCommit != null && drUnCommit.Length > 0)
                {
                    for (int iRow = 0; iRow < drUnCommit.Length; iRow++)
                    {
                        drUnCommit[iRow]["EXAMERID_CHR"] = DBNull.Value;
                        drUnCommit[iRow]["examername"] = DBNull.Value;
                        drUnCommit[iRow]["EXAM_DAT"] = DBNull.Value;
                    }
                }                
            }            
        }
        #endregion

        #region 获取主表内容（多类型）
        /// <summary>
        /// 获取主表内容（多类型）
        /// </summary>
        /// <param name="p_dtmBeginDate">查询开始时间</param>
        /// <param name="p_dtmEndDate">查询结束时间</param>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_strMedicineName">药品名称</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <param name="p_strInStorageID">入库单据号</param>
        /// <param name="p_strMedicinePreptype">药品剂型</param>
        /// <param name="p_intInStorageTypeID">入库类型</param>
        /// <param name="p_dtbValue">主表内容</param>
        internal void m_mthGetMainData(DateTime p_dtmBeginDate, DateTime p_dtmEndDate, string p_strStorageID,
            string p_strMedicineName, string p_strVendorName,  string p_strInStorageID, string p_strMedicinePreptype,int p_intInStorageTypeID, out DataTable p_dtbValue)
        {
            long lngRes = m_objDomain.m_lngGetInStorage(p_dtmBeginDate, p_dtmEndDate, p_strStorageID, p_strMedicineName, p_strVendorName, p_strInStorageID,p_strMedicinePreptype,p_intInStorageTypeID,out p_dtbValue);


            if (p_dtbValue != null)
            {
                string strUnCommit = "STATE_INT = 1 and EXAMERID_CHR is not null";
                DataRow[] drUnCommit = p_dtbValue.Select(strUnCommit);
                if (drUnCommit != null && drUnCommit.Length > 0)
                {
                    for (int iRow = 0; iRow < drUnCommit.Length; iRow++)
                    {
                        drUnCommit[iRow]["EXAMERID_CHR"] = DBNull.Value;
                        drUnCommit[iRow]["examername"] = DBNull.Value;
                        drUnCommit[iRow]["EXAM_DAT"] = DBNull.Value;
                    }
                }                
            }            
        }
        #endregion

        #region 获取入库明细表内容

        /// <summary>
        /// 获取入库明细表内容
        /// </summary>
        /// <param name="p_lngSeries2ID">入库明细主表序列</param>
        /// <param name="p_dtbValue">明细表内容</param>
        /// <returns></returns>
        internal void m_mthGetInstorageDetal(long p_lngSeries2ID, out DataTable p_dtbValue)
        {
            long lngRes = m_objDomain.m_lngGetInstorageDetal(p_lngSeries2ID, out p_dtbValue);
        }
        #endregion

        #region 获取药品制剂类型
        /// <summary>
        /// 获取药品制剂类型
        /// </summary>
        /// <param name="p_objMPVO">药品制剂类型</param>
        /// <returns></returns>
        internal void m_mthGetMedicinePreptype(out clsMEDICINEPREPTYPE_VO[] p_objMPVO)
        {
            long lngRes = m_objDomain.m_lngGetMedicinePreptype(out p_objMPVO);
        }
        #endregion

        #region 获取指定仓库的药品类型

        /// <summary>
        /// 获取指定仓库的药品类型

        /// </summary>
        /// <param name="p_strStorageID">仓库ID</param>
        /// <param name="p_objMTVO">药品制剂类型</param>
        internal void m_mthGetStorageMedicineType(string p_strStorageID, out clsMS_MedicineType_VO[] p_objMTVO)
        {
            long lngRes = m_objDomain.m_lngGetStorageMedicineType(p_strStorageID, out p_objMTVO);
        }
        #endregion

        #region 设置药品类型
        /// <summary>
        /// 设置药品类型
        /// </summary>
        /// <param name="p_objMPVO"></param>
        internal void m_mthSetMedicineType(clsMS_MedicineType_VO[] p_objMPVO)
        {
            if (p_objMPVO == null || m_objViewer.m_cboDoseType.Items.Count > 0)
            {
                return;
            }

            clsMS_MedicineType_VO objAll = new clsMS_MedicineType_VO();
            objAll.m_strMedicineTypeID_CHR = "0";
            objAll.m_strMedicineTypeName_VCHR = "全部";

            m_objViewer.m_cboDoseType.Items.Add(objAll);
            m_objViewer.m_cboDoseType.Items.AddRange(p_objMPVO);

            m_objViewer.m_cboDoseType.SelectedIndex = 0;
        }
        #endregion

        #region 过滤药品信息
        /// <summary>
        /// 获取主表过滤条件
        /// </summary>
        /// <returns></returns>
        private string m_strMainFilter()
        {
            string strFilterMain = string.Empty;
            //if (!string.IsNullOrEmpty(m_objViewer.m_txtProviderName.Text))
            //{
            //    strFilterMain = " vendorname_vchr like '" + m_objViewer.m_txtProviderName.Text + "%'";
            //}

            if (m_objViewer.m_cboInComeType.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(strFilterMain))
                {
                    strFilterMain += " and ";
                }
                strFilterMain += " INSTORAGETYPE_INT = " + m_objViewer.m_cboInComeType.SelectItemValue.ToString();
            }

            if (m_objViewer.m_cboBillState.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(strFilterMain))
                {
                    strFilterMain += " and ";
                }
                strFilterMain += " STATE_INT = " + (m_objViewer.m_cboBillState.SelectedIndex).ToString();
            }

            //if (!string.IsNullOrEmpty(m_objViewer.m_txtBillNumber.Text))
            //{
            //    if (!string.IsNullOrEmpty(strFilterMain))
            //    {
            //        strFilterMain += " and ";
            //    }
            //    strFilterMain += " INSTORAGEID_VCHR like '" + m_objViewer.m_txtBillNumber.Text + "%'";
            //}
            return strFilterMain;
        }

        /// <summary>
        /// 过滤主表信息
        /// </summary>
        internal void m_mthFilterMainData()
        {
            if (m_objViewer.m_dtbSubData != null)
            {
                m_objViewer.m_dtbSubData.Rows.Clear();
            }

            string strFilterMain = m_strMainFilter();

            m_objViewer.m_dtvMainView = new DataView(m_objViewer.m_dtbMainData);
            m_objViewer.m_dtvMainView.RowFilter = strFilterMain;
            m_objViewer.m_dgvMainInfo.DataSource = m_objViewer.m_dtvMainView;

            m_objViewer.m_dgvMainInfo.Refresh();

            m_mthGetAllMoney();
            if (m_objViewer.m_dgvMainInfo.Rows.Count > 0)
            {

                //m_objViewer.m_dgvMainInfo.Focus();
                if (m_objViewer.m_dgvMainInfo.CurrentCell == null)
                {
                    m_objViewer.m_dgvMainInfo.Rows[0].Selected = true;
                    m_objViewer.m_dgvMainInfo.CurrentCell = m_objViewer.m_dgvMainInfo.Rows[0].Cells[1];
                }                
            }
            else
            {
                if (m_objViewer.m_dtbSubData != null)
                {
                    m_objViewer.m_dtbSubData.Rows.Clear();
                }
            }
        }

        /// <summary>
        /// 过滤子表信息
        /// </summary>
        internal void m_mthFilterSubData()
        {
            string strFilterSub = string.Empty;
            if (!string.IsNullOrEmpty(m_objViewer.m_txtMedicineName.Text))
            {
                strFilterSub = "MEDICINENAME_VCH like '" + m_objViewer.m_txtMedicineName.Text + "%'";
            }

            if (m_objViewer.m_cboDoseType.SelectedIndex > 0)
            {
                if (!string.IsNullOrEmpty(strFilterSub))
                {
                    strFilterSub += " and ";
                }
                clsMEDICINEPREPTYPE_VO objVo = m_objViewer.m_cboDoseType.SelectedItem as clsMEDICINEPREPTYPE_VO;
                if (objVo != null)
                {
                    strFilterSub += " MEDICINEPREPTYPE_CHR = '" + objVo.m_strMEDICINEPREPTYPE_CHR + "'";
                }
            }

            if (m_objViewer.m_dtbSubData != null)
            {
                DataView dtvSub = new DataView(m_objViewer.m_dtbSubData);
                dtvSub.RowFilter = strFilterSub;
                m_objViewer.m_dgvSubInfo.DataSource = dtvSub;
            }

            m_objViewer.m_dgvSubInfo.Refresh();
        }
        #endregion

        #region 显示供应商查询


        /// <summary>
        /// 获取供应商信息

        /// </summary>
        /// <param name="p_dtbVendor"></param>
        internal void m_mthGetVendor(out DataTable p_dtbVendor)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetVendor(out p_dtbVendor);
        }
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

            m_objViewer.m_cboInComeType.Focus();
        }
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID,out m_objViewer.m_dtbMedicinDict);
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体


        /// <summary>
        /// 显示药品字典最小元素信息查询窗体

        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict,true);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = m_objViewer.panel1.Location.X + m_objViewer.m_txtMedicineName.Location.X;
                int Y = m_objViewer.panel1.Location.Y + m_objViewer.m_txtMedicineName.Location.Y + m_objViewer.m_txtMedicineName.Size.Height;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
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

            m_objViewer.m_txtMedicineName.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineName.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_txtBillNumber.Focus();
        }
        #endregion

        #region 修改选定的入库单
        /// <summary>
        /// 修改选定的入库单
        /// </summary>
        /// <param name="p_objMain">主表</param>
        /// <param name="p_objSubVO">子表</param>
        internal void m_mthModifySelected(out clsMS_InStorage_VO p_objMain, out clsMS_InStorageDetail_VO[] p_objSubVO)
        {
            p_objMain = null;
            p_objSubVO = null;
            #region 主表VO
            clsMS_InStorage_VO objMain = null;
            if (m_objViewer.m_dgvMainInfo.SelectedRows.Count == 1)
            {
                DataRowView drvMain = m_objViewer.m_dtvMainView[m_objViewer.m_dgvMainInfo.SelectedRows[0].Index];
                //int intState = Convert.ToInt32(drvMain["STATE_INT"]);
                //if (intState != 1)
                //{
                //    MessageBox.Show("非新制表单不能修改", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return;
                //}
                objMain = new clsMS_InStorage_VO();
                objMain.m_lngSERIESID_INT = Convert.ToInt64(drvMain["SERIESID_INT"]);
                objMain.m_strINSTORAGEID_VCHR = drvMain["INSTORAGEID_VCHR"].ToString();
                objMain.m_intFORMTYPE_INT = Convert.ToInt32(drvMain["FORMTYPE_INT"]);
                objMain.m_intINSTORAGETYPE_INT = Convert.ToInt32(drvMain["INSTORAGETYPE_INT"]);
                objMain.m_intSTATE_INT = Convert.ToInt32(drvMain["STATE_INT"]);
                objMain.m_strSTORAGEID_CHR = drvMain["STORAGEID_CHR"].ToString();
                objMain.m_strVENDORID_CHR = drvMain["VENDORID_CHR"].ToString();
                objMain.m_strVENDORName = drvMain["vendorname_vchr"].ToString();
                objMain.m_strBUYERID_CHAR = drvMain["BUYERID_CHAR"].ToString();
                objMain.m_strBUYERName = drvMain["buyername"].ToString();
                objMain.m_strSTORAGERID_CHAR = drvMain["STORAGERID_CHAR"].ToString();
                objMain.m_strSTORAGERName = drvMain["storagername"].ToString();
                objMain.m_strACCOUNTERID_CHAR = drvMain["ACCOUNTERID_CHAR"].ToString();
                objMain.m_strACCOUNTERName = drvMain["accountername"].ToString();
                objMain.m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(drvMain["INSTORAGEDATE_DAT"]);
                objMain.m_dtmNEWORDER_DAT = Convert.ToDateTime(drvMain["NEWORDER_DAT"]);
                objMain.m_strSUPPLYCODE_VCHR = drvMain["SUPPLYCODE_VCHR"].ToString();
                objMain.m_strINVOICECODE_VCHR = drvMain["INVOICECODE_VCHR"].ToString();
                objMain.m_dtmINVOICEDATER_DAT = Convert.ToDateTime(drvMain["INVOICEDATER_DAT"]);
                objMain.m_strCOMMNET_VCHR = drvMain["COMMNET_VCHR"].ToString();
                objMain.m_strMAKERID_CHR = drvMain["MAKERID_CHR"].ToString();
                objMain.m_strMAKERName = drvMain["makername"].ToString();
                objMain.m_strExportDept_CHR = drvMain["deptname_vchr"].ToString();
                objMain.m_strExportDeptID_CHR = drvMain["deptid_chr"].ToString();
                objMain.Procurement = drvMain["Procurement"].ToString();
            }

            if (objMain == null)
            {
                return;
            }
            p_objMain = objMain;
            #endregion

            #region 子表VO
            clsMS_InStorageDetail_VO[] objSubVO = null;
            DataView dvSub = m_objViewer.m_dgvSubInfo.DataSource as DataView;
            if (dvSub != null && dvSub.Count > 0)
            {
                DataRowView drvCurrent = null;
                DateTime datTemp;
                objSubVO = new clsMS_InStorageDetail_VO[dvSub.Count];
                for (int iRow = 0; iRow < m_objViewer.m_dgvSubInfo.Rows.Count; iRow++)
                {
                    drvCurrent = dvSub[iRow];
                    objSubVO[iRow] = new clsMS_InStorageDetail_VO();
                    objSubVO[iRow].m_lngSERIESID_INT = Convert.ToInt64(drvCurrent["SERIESID_INT"]);
                    objSubVO[iRow].m_lngSERIESID_INT2 = Convert.ToInt64(drvCurrent["SERIESID2_INT"]);
                    objSubVO[iRow].m_strMEDICINEID_CHR = drvCurrent["MEDICINEID_CHR"].ToString();
                    objSubVO[iRow].m_strMEDICINENAME_VCH = drvCurrent["MEDICINENAME_VCH"].ToString();
                    objSubVO[iRow].m_strMEDSPEC_VCHR = drvCurrent["MEDSPEC_VCHR"].ToString();
                    objSubVO[iRow].m_strInvoicecode_vchr = drvCurrent["invoicecode_vchr"].ToString();
                    if (DateTime.TryParse(drvCurrent["invoicedater_dat"].ToString(), out datTemp))
                    {
                        objSubVO[iRow].m_dtmInvoicedater_dat = datTemp;
                    }
                    //objSubVO[iRow].m_dtmInvoicedater_dat = Convert.ToDateTime(drvCurrent["invoicedater_dat"]);
                    if (drvCurrent["PACKAMOUNT"] != DBNull.Value)
                    {
                        objSubVO[iRow].m_dblPACKAMOUNT = Convert.ToDouble(drvCurrent["PACKAMOUNT"]);
                    }
                    objSubVO[iRow].m_strPACKUNIT_VCHR = drvCurrent["PACKUNIT_VCHR"].ToString();
                    if (drvCurrent["PACKCALLPRICE_INT"] != DBNull.Value)
                    {
                        objSubVO[iRow].m_dcmPACKCALLPRICE_INT = Convert.ToDecimal(drvCurrent["PACKCALLPRICE_INT"]);
                    }
                    if (drvCurrent["PACKCONVERT_INT"] != DBNull.Value)
                    {
                        objSubVO[iRow].m_dblPACKCONVERT_INT = Convert.ToDouble(drvCurrent["PACKCONVERT_INT"]);
                    }
                    objSubVO[iRow].m_strLOTNO_VCHR = drvCurrent["LOTNO_VCHR"].ToString();
                    objSubVO[iRow].m_dblAMOUNT = Convert.ToDouble(drvCurrent["AMOUNT"]);
                    objSubVO[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drvCurrent["CALLPRICE_INT"]);
                    objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drvCurrent["WHOLESALEPRICE_INT"]);
                    objSubVO[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drvCurrent["RETAILPRICE_INT"]);
                    objSubVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drvCurrent["VALIDPERIOD_DAT"]);
                    if (drvCurrent["ACCEPTANCE_INT"] != DBNull.Value)
                    {
                        objSubVO[iRow].m_intACCEPTANCE_INT = Convert.ToInt32(drvCurrent["ACCEPTANCE_INT"]);
                    }
                    objSubVO[iRow].m_strAPPROVECODE_VCHR = drvCurrent["APPROVECODE_VCHR"].ToString();
                    if (drvCurrent["APPARENTQUALITY_INT"] != DBNull.Value)
                    {
                        objSubVO[iRow].m_intAPPARENTQUALITY_INT = Convert.ToInt32(drvCurrent["APPARENTQUALITY_INT"]);
                    }
                    if (drvCurrent["PACKQUALITY_INT"] != DBNull.Value)
                    {
                        objSubVO[iRow].m_intPACKQUALITY_INT = Convert.ToInt32(drvCurrent["PACKQUALITY_INT"]);
                    }
                    if (drvCurrent["EXAMRUSULT_INT"] != DBNull.Value)
                    {
                        objSubVO[iRow].m_intEXAMRUSULT_INT = Convert.ToInt32(drvCurrent["EXAMRUSULT_INT"]);
                    }
                    objSubVO[iRow].m_strEXAMINER = drvCurrent["EXAMINER"].ToString();
                    objSubVO[iRow].m_strEXAMINERName = drvCurrent["examinername"].ToString();
                    objSubVO[iRow].m_strPRODUCTORID_CHR = drvCurrent["PRODUCTORID_CHR"].ToString();
                    objSubVO[iRow].m_strACCEPTANCECOMPANY_CHR = drvCurrent["ACCEPTANCECOMPANY_CHR"].ToString();
                    objSubVO[iRow].m_strACCEPTANCECOMPANYName = drvCurrent["ACCEPTANCECOMPANYname"].ToString();
                    objSubVO[iRow].m_strUNIT_VCHR = drvCurrent["UNIT_VCHR"].ToString();
                    objSubVO[iRow].m_strMEDICINECode = drvCurrent["MedicineCode"].ToString();
                    objSubVO[iRow].m_strMEDICINEPREPTYPE_CHR = drvCurrent["MEDICINEPREPTYPE_CHR"].ToString();
                    objSubVO[iRow].m_strMedicineTypeID_chr = drvCurrent["medicinetypeid_chr"].ToString();
                   
                    if (drvCurrent["GROSSPROFITRATE_INT"] != DBNull.Value)
                    {
                        objSubVO[iRow].m_dblGrossProfitRate = Convert.ToInt32(drvCurrent["GROSSPROFITRATE_INT"]);
                    }

                    if (drvCurrent["LIMITUNITPRICE_MNY"] != DBNull.Value)
                    {
                        objSubVO[iRow].m_dblLimitunitPrice = Convert.ToDouble(drvCurrent["LIMITUNITPRICE_MNY"]);
                    }
                    objSubVO[iRow].m_strTYPECODE_CHR = drvCurrent["typecode_vchr"].ToString();
                    if (DateTime.TryParse(drvCurrent["producedate_dat"].ToString(), out datTemp))
                    {
                        objSubVO[iRow].m_dtmPRODUCEDATE_DAT = datTemp;
                    }
                }
            }
            p_objSubVO = objSubVO;
            #endregion
        }
        #endregion

        #region 检查是否有药库管理权限
        /// <summary>
        /// 检查是否有药库管理权限
        /// </summary>
        /// <param name="strEmpID">员工ID</param>
        /// <param name="p_blnHasRole">是否有权限</param>
        internal void m_mthCheckHasAdminRole(string strEmpID, out bool p_blnHasRole)
        {
            long lngRes = m_objDomain.m_lngCheckEmpHasRole(strEmpID, out p_blnHasRole);
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

        #region 删除药品信息
        /// <summary>
        /// 删除药品信息
        /// </summary>
        internal void m_mthDeleteMedicine()
        {
            //if (!m_objViewer.m_blnIsAdmin)
            //{
            //    MessageBox.Show("当前用户没有药库管理权限，不能删除", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            int m_intBillNo = 0;
            int m_intStatus = 0;
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    //int intState = Convert.ToInt32(m_objViewer.m_dtvMainView[iSe]["STATE_INT"]);
                    //if (intState == 2 || intState == 3)//已审核或已入帐

                    //{
                    m_intBillNo++;
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;
                    
                    m_objDomain.m_lngCheckStatus(Convert.ToInt64(drCheck["SERIESID_INT"]), out m_intStatus);
                    if (m_intStatus != 1)
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtvMainView[iSe]["SERIESID_INT"]));
                        continue;
                    }
                    //}
                    lngCheckRowIndex.Add(Convert.ToInt64(m_objViewer.m_dtvMainView[iSe]["SERIESID_INT"]));
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录已审核或已入账，将不能删除，是否继续？", "药品入库", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("请先选择一条新制药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否删除选中记录？", "药品入库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }

            //int intRowIndex = m_objViewer.m_dgvMainInfo.SelectedRows[0].Index;
            //DataRowView drvSelected = m_objViewer.m_dtvMainView[intRowIndex];

            //int intState = Convert.ToInt32(drvSelected["STATE_INT"]);

            //if (intState == 2)
            //{
            //    MessageBox.Show("该记录已审核，不能删除", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //else if (intState == 3)
            //{
            //    MessageBox.Show("该记录已入帐，不能删除", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}

            //long lngSEQ = Convert.ToInt64(drvSelected["SERIESID_INT"]);

            long lngRes = m_objDomain.m_lngDeleteMainInStorage(lngCheckRowIndex.ToArray());
            if (lngRes > 0)
            {
                MessageBox.Show("删除成功", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);

                StringBuilder stbFilter = new StringBuilder(50);
                for (int iSer = 0; iSer < lngCheckRowIndex.Count; iSer++)
                {
                    stbFilter.Append(" SERIESID_INT = '");
                    stbFilter.Append(lngCheckRowIndex[iSer]);
                    stbFilter.Append("'");
                    if (iSer < lngCheckRowIndex.Count-1)
                    {
                        stbFilter.Append(" or ");
                    }                    
                }
                DataRow[] drRemove = m_objViewer.m_dtbMainData.Select(stbFilter.ToString());
                if (drRemove != null && drRemove.Length > 0)
                {
                    for (int iRev = 0; iRev < drRemove.Length; iRev++)
                    {
                        m_objViewer.m_dtbMainData.Rows.Remove(drRemove[iRev]);
                    }
                }             

                DataView dtvSub = m_objViewer.m_dgvSubInfo.DataSource as DataView;
                if (dtvSub != null)
                {
                    dtvSub.Table.Rows.Clear();
                }
            }
            else
            {
                MessageBox.Show("删除失败", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } 
        #endregion

        #region 退审

        /// <summary>
        /// 退审
        /// </summary>
        internal void m_mthUnCommit()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能退审", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            int m_intBillNo = 0;
            int m_intStatus = 0;
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    m_intBillNo++;
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;
                    
                    m_objDomain.m_lngCheckStatus(Convert.ToInt64(drCheck["SERIESID_INT"]), out m_intStatus);
                    if (m_intStatus != 2)
                    {
                        MessageBox.Show("您所选择的第" + (m_intBillNo) + "张入库单不是审核状态,不能进行退审！", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    lstCheck.Add(drCheck);
                    
                }
            }

            DataRow[] drCommit = lstCheck.ToArray();

            if (drCommit == null || drCommit.Length == 0)
            {
                MessageBox.Show("没有符合退审条件的药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool blnHasDone = false;//此单入库后是否已做其它操作

            string strOtherID = string.Empty;//其它操作的单据号
            List<long> lstSEQ = new List<long>();//未做其它操作的入库序列号
            List<string> lstRigthInStorageID = new List<string>();//未做其它操作的入库单号

            List<string> lstWrongInStorageID = new List<string>();//已做其它操作的入库单号

            List<DataRow> lstCommitRow = new List<DataRow>();//符合退审条件的行

            Hashtable hstWrongID = new Hashtable();

            for (int iRow = 0; iRow < drCommit.Length; iRow++)
            {
                m_objDomain.m_lngCheckHasDoneAfterInStorage(drCommit[iRow]["INSTORAGEID_VCHR"].ToString(), out blnHasDone, out strOtherID);
                if (!blnHasDone)// || drCommit[iRow]["INSTORAGETYPE_INT"].ToString() == "3")
                {
                    lstSEQ.Add(Convert.ToInt64(drCommit[iRow]["SERIESID_INT"]));
                    lstRigthInStorageID.Add(drCommit[iRow]["INSTORAGEID_VCHR"].ToString());
                    lstCommitRow.Add(drCommit[iRow]);
                }
                else
                {
                    lstWrongInStorageID.Add(drCommit[iRow]["INSTORAGEID_VCHR"].ToString());
                    hstWrongID.Add(drCommit[iRow]["INSTORAGEID_VCHR"].ToString(), strOtherID);
                }
            }

            if (lstWrongInStorageID.Count > 0)
            {
                StringBuilder stbHint = new StringBuilder(100);
                stbHint.Append("下列入库单不能退审,是否忽略并继续退审选择的其它入库单？");
                stbHint.Append(Environment.NewLine);
                stbHint.Append("入库单号           状态");
                stbHint.Append(Environment.NewLine);
                string strWrongOtherID = string.Empty;//已作其它操作的ID
                string strTypeName = string.Empty;//其它操作名称
                for (int iID = 0; iID < lstWrongInStorageID.Count; iID++)
                {
                    strWrongOtherID = hstWrongID[lstWrongInStorageID[iID]].ToString();
                    strTypeName = m_strGetIDType(strWrongOtherID);

                    stbHint.Append(lstWrongInStorageID[iID]);
                    stbHint.Append("    已");
                    stbHint.Append(strTypeName);
                    stbHint.Append(",");
                    stbHint.Append(strTypeName);
                    stbHint.Append("单号为:");
                    stbHint.Append(strWrongOtherID);
                    stbHint.Append(Environment.NewLine);
                }

                lstWrongInStorageID = null;
                hstWrongID = null;

                frmHintMessageBox HintBox = new frmHintMessageBox(stbHint.ToString());
                DialogResult drResult = HintBox.ShowDialog();
                if (drResult == DialogResult.No)
                {
                    return;
                }
                
            }

            if (lstRigthInStorageID.Count == 0)
            {
                MessageBox.Show("没有符合退审条件的药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            long[] lngSEQArr = lstSEQ.ToArray();
            string[] strInStorageIDArr = lstRigthInStorageID.ToArray();

            //long lngRes = m_objDomain.m_lngUnCommit(lngSEQArr);

            long lngRes = 0;
            List<clsMS_StorageDetail> objDetail = new List<clsMS_StorageDetail>();
            DataTable dtbDetail = null;
            clsMS_StorageDetail[] objDetailTemp = null;//各入库单需要审核的明细VO
            for (int iRow = 0; iRow < lngSEQArr.Length; iRow++)
            {
                lngRes = m_objDomain.m_lngGetInstorageDetal(lngSEQArr[iRow], out dtbDetail);
                objDetailTemp = m_objDetailVO(dtbDetail, drCommit[iRow]["INSTORAGEID_VCHR"].ToString(), drCommit[iRow]["VENDORID_CHR"].ToString(), drCommit[iRow]["vendorname_vchr"].ToString());
                if (objDetailTemp != null && objDetailTemp.Length > 0)
                {
                    objDetail.AddRange(objDetailTemp);
                }
            }

            clsMS_StorageDetail[] objAllDetail = objDetail.ToArray();//全部明细VO

            if (objAllDetail == null || objAllDetail.Length == 0)
            {
                MessageBox.Show("没有符合退审条件的药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //clsDcl_Storage objSTDomain = new clsDcl_Storage();
            //bool blnSaveComplete = true;

            //clsMS_Storage objStorage = null;
            //bool blnHasDetail = false;//是否已存在


            //for (int iRow = 0; iRow < objAllDetail.Length; iRow++)
            //{
            //    objStorage = new clsMS_Storage();
            //    objStorage.m_strMEDICINEID_CHR = objAllDetail[iRow].m_strMEDICINEID_CHR;
            //    objStorage.m_strMEDICINENAME_VCHR = objAllDetail[iRow].m_strMEDICINENAME_VCHR;
            //    objStorage.m_strMEDSPEC_VCHR = objAllDetail[iRow].m_strMEDSPEC_VCHR;
            //    objStorage.m_strOPUNIT_VCHR = objAllDetail[iRow].m_strOPUNIT_VCHR;
            //    objStorage.m_dblINSTOREGROSS_INT = objAllDetail[iRow].m_dblAVAILAGROSS_INT;
            //    objStorage.m_dblCURRENTGROSS_NUM = objAllDetail[iRow].m_dblAVAILAGROSS_INT;
            //    objStorage.m_dcmCALLPRICE_INT = objAllDetail[iRow].m_dcmCALLPRICE_INT;
            //    objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

            //    long lngCurrentSeriesID = 0;
            //    lngRes = objSTDomain.m_lngCheckHasStorage(objAllDetail[iRow].m_strMEDICINEID_CHR, m_objViewer.m_strStorageID,out blnHasDetail, out lngCurrentSeriesID);

            //    objAllDetail[iRow].m_lngSERIESID_INT = lngCurrentSeriesID;
            //    lngRes = objSTDomain.m_lngModifyStorageFromUnCommit(objStorage, lngCurrentSeriesID);
            //}

            
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

            //lngRes = objSTDomain.m_lngDeleteStorageDetail(strInStorageIDArr);

            //System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
            //for (int iRow = 0; iRow < objAllDetail.Length; iRow++)
            //{
            //    if (!hstStastic.Contains(objAllDetail[iRow].m_strMEDICINEID_CHR))
            //    {
            //        hstStastic.Add(objAllDetail[iRow].m_strMEDICINEID_CHR, objAllDetail[iRow].m_lngSERIESID_INT);
            //        lngRes = objSTDomain.m_lngStatisticsStorage(objAllDetail[iRow].m_strMEDICINEID_CHR,m_objViewer.m_strStorageID);
            //    }
            //}

            lngRes = m_objDomain.m_lngUnCommit(m_objViewer.m_strStorageID, lngSEQArr, strInStorageIDArr, objAllDetail);
            if (lngRes > 0)
            {
                m_mthUpdateUIAfterUnCommit(lstCommitRow.ToArray());
                if (m_objViewer.m_dgvMainInfo.Rows.Count > 0)
                {
                    m_objViewer.m_dgvMainInfo.Rows[0].Selected = true;
                }
                else
                {
                    if (m_objViewer.m_dtbSubData != null)
                    {
                        m_objViewer.m_dtbSubData.Rows.Clear();
                    }                    
                }
                System.Windows.Forms.MessageBox.Show("退审完成", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("退审失败", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }

        
        internal void m_mthUnCommitInOut()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能退审", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;
                    if (drCheck["STATE_INT"].ToString() == "2")
                    {
                        lstCheck.Add(drCheck);
                    }
                }
            }

            DataRow[] drCommit = lstCheck.ToArray();

            if (drCommit == null || drCommit.Length == 0)
            {
                MessageBox.Show("没有符合退审条件的药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            bool blnHasDone = false;//此单入库后是否已做其它操作


            string strOtherID = string.Empty;//其它操作的单据号
            List<long> lstSEQ = new List<long>();//未做其它操作的入库序列号
            List<string> lstRigthInStorageID = new List<string>();//未做其它操作的入库单号


            List<string> lstWrongInStorageID = new List<string>();//已做其它操作的入库单号


            List<DataRow> lstCommitRow = new List<DataRow>();//符合退审条件的行


            Hashtable hstWrongID = new Hashtable();
            for (int iRow = 0; iRow < drCommit.Length; iRow++)
            {
                m_objDomain.m_lngCheckHasDoneAfterInStorage(drCommit[iRow]["INSTORAGEID_VCHR"].ToString(), out blnHasDone, out strOtherID);
                if (!blnHasDone)
                {
                    lstSEQ.Add(Convert.ToInt64(drCommit[iRow]["SERIESID_INT"]));
                    lstRigthInStorageID.Add(drCommit[iRow]["INSTORAGEID_VCHR"].ToString());
                    lstCommitRow.Add(drCommit[iRow]);
                }
                else
                {
                    lstWrongInStorageID.Add(drCommit[iRow]["INSTORAGEID_VCHR"].ToString());
                    hstWrongID.Add(drCommit[iRow]["INSTORAGEID_VCHR"].ToString(), strOtherID);
                }
            }

            //if (lstWrongInStorageID.Count > 0)
            //{
            //    StringBuilder stbHint = new StringBuilder(100);
            //    stbHint.Append("下列入库单不能退审,是否忽略并继续退审选择的其它入库单？");
            //    stbHint.Append(Environment.NewLine);
            //    stbHint.Append("入库单号           状态");
            //    stbHint.Append(Environment.NewLine);
            //    string strWrongOtherID = string.Empty;//已作其它操作的ID
            //    string strTypeName = string.Empty;//其它操作名称
            //    for (int iID = 0; iID < lstWrongInStorageID.Count; iID++)
            //    {
            //        strWrongOtherID = hstWrongID[lstWrongInStorageID[iID]].ToString();
            //        strTypeName = m_strGetIDType(strWrongOtherID);

            //        stbHint.Append(lstWrongInStorageID[iID]);
            //        stbHint.Append("    已");
            //        stbHint.Append(strTypeName);
            //        stbHint.Append(",");
            //        stbHint.Append(strTypeName);
            //        stbHint.Append("单号为:");
            //        stbHint.Append(strWrongOtherID);
            //        stbHint.Append(Environment.NewLine);
            //    }

            //    lstWrongInStorageID = null;
            //    hstWrongID = null;

            //    frmHintMessageBox HintBox = new frmHintMessageBox(stbHint.ToString());
            //    DialogResult drResult = HintBox.ShowDialog();
            //    if (drResult == DialogResult.No)
            //    {
            //        return;
            //    }

            //}

            //if (lstRigthInStorageID.Count == 0)
            //{
            //    MessageBox.Show("没有符合退审条件的药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}

            long[] lngSEQArr = lstSEQ.ToArray();
            string[] strInStorageIDArr = lstRigthInStorageID.ToArray();

            //long lngRes = m_objDomain.m_lngUnCommit(lngSEQArr);

            long lngRes = 0;
            List<clsMS_StorageDetail> objDetail = new List<clsMS_StorageDetail>();
            DataTable dtbDetail = null;
            clsMS_StorageDetail[] objDetailTemp = null;//各入库单需要审核的明细VO
            for (int iRow = 0; iRow < lngSEQArr.Length; iRow++)
            {
                lngRes = m_objDomain.m_lngGetInstorageDetal(lngSEQArr[iRow], out dtbDetail);
                objDetailTemp = m_objDetailVO(dtbDetail, drCommit[iRow]["INSTORAGEID_VCHR"].ToString(), drCommit[iRow]["VENDORID_CHR"].ToString(), drCommit[iRow]["vendorname_vchr"].ToString());
                if (objDetailTemp != null && objDetailTemp.Length > 0)
                {
                    objDetail.AddRange(objDetailTemp);
                }
            }

            clsMS_StorageDetail[] objAllDetail = objDetail.ToArray();//全部明细VO

            if (objAllDetail == null || objAllDetail.Length == 0)
            {
                MessageBox.Show("没有符合退审条件的药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            

            lngRes = m_objDomain.m_lngUnCommit(m_objViewer.m_strStorageID, lngSEQArr, strInStorageIDArr, objAllDetail);
            if (lngRes > 0)
            {
                m_mthUpdateUIAfterUnCommit(lstCommitRow.ToArray());
                if (m_objViewer.m_dgvMainInfo.Rows.Count > 0)
                {
                    m_objViewer.m_dgvMainInfo.Rows[0].Selected = true;
                }
                else
                {
                    if (m_objViewer.m_dtbSubData != null)
                    {
                        m_objViewer.m_dtbSubData.Rows.Clear();
                    }
                }
                System.Windows.Forms.MessageBox.Show("退审完成", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("退审失败", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 获取单据号类型
        /// </summary>
        /// <param name="p_strID">单据号</param>
        /// <returns></returns>
        private string m_strGetIDType(string p_strID)
        {
            string strType = string.Empty;
            if (p_strID != null)
            {
                char chrType = p_strID[8];
                switch (chrType)
                {
                    case '1':
                        strType = "入库";
                        break;
                    case '2':
                        strType = "出库";
                        break;
                    case '3':
                        strType = "外退";
                        break;
                    case '4':
                        strType = "内退";
                        break;
                    case '5':
                        strType = "报废出库";
                        break;
                    case '6':
                        strType = "盘点";
                        break;
                    case '7':
                        strType = "期初数";
                        break;
                }
            }
            return strType;
        }

        /// <summary>
        /// 退审后更新界面
        /// </summary>
        /// <param name="drData">序列</param>
        private void m_mthUpdateUIAfterUnCommit(DataRow[] drData)
        {
            if (drData == null || drData.Length == 0)
            {
                return;
            }

            for (int iRow = 0; iRow < drData.Length; iRow++)
            {
                drData[iRow]["examername"] = DBNull.Value;
                drData[iRow]["STATE_INT"] = 1;
                drData[iRow]["EXAM_DAT"] = DBNull.Value;
                drData[iRow]["statedesc"] = "新制";
            }
        }
        #endregion


        #region 审核药品信息
        /// <summary>
        /// 审核药品信息
        /// </summary>
        /// <param name="p_drCommit">审核的行</param>
        internal void m_mthCommitMedicine(out DataRow[] p_drCommit)
        {
            p_drCommit = null;
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能审核", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            int m_intBillNo = 0;
            int m_intStatus = 0;
            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;
                    //if (drCheck["STATE_INT"].ToString() == "1")
                    //{
                    m_intBillNo++;
                    //检查是否新制

                    m_objDomain.m_lngCheckStatus(Convert.ToInt64(drCheck["SERIESID_INT"]), out m_intStatus);
                    if (m_intStatus != 1)
                    {
                        MessageBox.Show("您所选择的第" + (m_intBillNo) + "张入库单不是新制状态,不能进行审核！", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                        lstCheck.Add(drCheck);
                    //}
                }                
            }

            DataRow[] drNew = lstCheck.ToArray();

            if (drNew == null || drNew.Length == 0)
            {
                MessageBox.Show("没有需审核的药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            try
            {
                long lngRes = 0;
                long lngSEQ = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                bool blnSaveComplete = true;
                DataTable dtbDetail = null;
                clsMS_StorageDetail[] objDetailTemp = null;//各入库单需要审核的明细VO
                DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                for (int iRow = 0; iRow < drNew.Length; iRow++)
                {
                    lngSEQ = Convert.ToInt64(drNew[iRow]["SERIESID_INT"]);
                    lngRes = m_objDomain.m_lngGetInstorageDetal(lngSEQ, out dtbDetail);
                    objDetailTemp = m_objDetailVO(dtbDetail, drNew[iRow]["INSTORAGEID_VCHR"].ToString(), drNew[iRow]["VENDORID_CHR"].ToString(), drNew[iRow]["vendorname_vchr"].ToString());
                    if (objDetailTemp != null && objDetailTemp.Length > 0)
                    {

                        if (drNew[iRow]["INSTORAGETYPE_INT"].ToString() == "3")
                        {
                            clsMS_OutStorage_VO outMainStoVO = new clsMS_OutStorage_VO();
                            outMainStoVO = m_objGetOutMainISVO(drNew[iRow]);
                            clsMS_OutStorageDetail_VO[] outDetStoVO;
                            outDetStoVO = m_objGetDetailArr(dtbDetail, lngSEQ);
                            lngRes = m_objDomain.m_lngCommitInStorage(objDetailTemp, m_objViewer.LoginInfo.m_strEmpID, dtmNow, lngSEQ, Convert.ToInt32(drNew[iRow]["formtype_int"]), drNew[iRow]["instorageid_vchr"].ToString(), m_objViewer.m_blnIsImmAccount,ref outMainStoVO, null, ref outDetStoVO,true);
                        }
                        else
                        {
                            lngRes = m_objDomain.m_lngCommitInStorage(objDetailTemp, m_objViewer.LoginInfo.m_strEmpID, dtmNow, lngSEQ, Convert.ToInt32(drNew[iRow]["formtype_int"]), drNew[iRow]["instorageid_vchr"].ToString(), m_objViewer.m_blnIsImmAccount);
                        }
                        if (lngRes <= 0)
                        {
                            blnSaveComplete = false;
                        }
                    }
                }                

                if (blnSaveComplete)
                {
                    p_drCommit = drNew;
                    System.Windows.Forms.MessageBox.Show("审核完成", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("审核失败", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
                System.Windows.Forms.MessageBox.Show("审核失败", "药品入库", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
            }          
        }

        /// <summary>
        /// 设置审核人

        /// </summary>
        /// <param name="p_drCommit">数据</param>
        private void m_mthSetCommitUser(DataRow[] p_drCommit)
        {
            if (p_drCommit == null || p_drCommit.Length == 0)
            {
                return;
            }

            long[] lngSEQ = new long[p_drCommit.Length];
            for (int iRow = 0; iRow < p_drCommit.Length; iRow++)
            {
                lngSEQ[iRow] = Convert.ToInt64(p_drCommit[iRow]["SERIESID_INT"]);
            }

            long lngRes = m_objDomain.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSEQ);
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="p_drNew">数据</param>
        internal void m_mthUpdateUIAfterCommit(DataRow[] p_drNew)
        {
            if (p_drNew == null || p_drNew.Length == 0)
            {
                return;
            }

            int intState = m_objViewer.m_blnIsImmAccount ? 3 : 2;
            string strStateDesc = m_objViewer.m_blnIsImmAccount ? "入帐" : "审核";
            for (int iRow = 0; iRow < p_drNew.Length; iRow++)
            {
                DataRow[] drTemp = m_objViewer.m_dtbMainData.Select("SERIESID_INT = " + Convert.ToInt64(p_drNew[iRow]["SERIESID_INT"]));
                if (drTemp.Length > 0)
                {
                    drTemp[0]["EXAMERID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
                    drTemp[0]["examername"] = m_objViewer.LoginInfo.m_strEmpName;
                    drTemp[0]["STATE_INT"] = intState;
                    drTemp[0]["EXAM_DAT"] = DateTime.Now;
                    drTemp[0]["statedesc"] = strStateDesc;
                }
            }

            if (m_objViewer.m_dtvMainView.Count == 0)
            {
                m_objViewer.m_dtbSubData.Rows.Clear();
            }
        }
        #endregion

        #region 获取库存主表VO
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
            objSVO.m_strMEDICINEID_CHR = p_drStorageVO["MEDICINEID_CHR"].ToString();
            objSVO.m_strMEDICINENAME_VCHR = p_drStorageVO["MEDICINENAME_VCH"].ToString();
            objSVO.m_strMEDSPEC_VCHR = p_drStorageVO["MEDSPEC_VCHR"].ToString();
            objSVO.m_strOPUNIT_VCHR = p_drStorageVO["UNIT_VCHR"].ToString();
            objSVO.m_dblINSTOREGROSS_INT = Convert.ToDouble(p_drStorageVO["AMOUNT"]);
            objSVO.m_dblCURRENTGROSS_NUM = Convert.ToDouble(p_drStorageVO["AMOUNT"]);
            objSVO.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drStorageVO["CALLPRICE_INT"]);
            return objSVO;
        } 
        #endregion

        #region 根据数据返回库存子表VO
        /// <summary>
        /// 根据数据返回库存子表VO
        /// </summary>
        /// <param name="p_dtbDetail">数据</param>
        /// <param name="p_strInID">入库单号</param>
        /// <param name="p_strVendorID">供应商ID</param>
        /// <param name="p_strVendorName">供应商名称</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objDetailVO(DataTable p_dtbDetail, string p_strInID, string p_strVendorID, string p_strVendorName)
        {
            if (p_dtbDetail == null || p_dtbDetail.Rows.Count == 0)
            {
                return null;
            }

            DataRow drCurrent = null;
            DateTime datTemp;
            clsMS_StorageDetail[] objSubVO = new clsMS_StorageDetail[p_dtbDetail.Rows.Count];
            for (int iRow = 0; iRow < p_dtbDetail.Rows.Count; iRow++)
            {
                drCurrent = p_dtbDetail.Rows[iRow];
                objSubVO[iRow] = new clsMS_StorageDetail();
                objSubVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objSubVO[iRow].m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                objSubVO[iRow].m_strMEDICINENAME_VCHR = drCurrent["MEDICINENAME_VCH"].ToString();
                objSubVO[iRow].m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();

                m_objDomain.m_lngGetMedicineTypeVisionm(drCurrent["medicinetypeid_chr"].ToString(), out m_objViewer.m_clsTypeVisVO);
                if (m_objViewer.m_clsTypeVisVO != null && m_objViewer.m_clsTypeVisVO.m_intLotno == 0 && drCurrent["LOTNO_VCHR"].ToString() == "")
                {
                    objSubVO[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objSubVO[iRow].m_strLOTNO_VCHR = drCurrent["LOTNO_VCHR"].ToString();
                }

                
                objSubVO[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(drCurrent["RETAILPRICE_INT"]);
                objSubVO[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                if (drCurrent["WHOLESALEPRICE_INT"] != DBNull.Value)
                {
                    objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(drCurrent["WHOLESALEPRICE_INT"]);
                }
                objSubVO[iRow].m_dblREALGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objSubVO[iRow].m_dblAVAILAGROSS_INT = Convert.ToDouble(drCurrent["AMOUNT"]);
                objSubVO[iRow].m_strOPUNIT_VCHR = drCurrent["UNIT_VCHR"].ToString();
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);
                objSubVO[iRow].m_strPRODUCTORID_CHR = drCurrent["PRODUCTORID_CHR"].ToString();
                objSubVO[iRow].m_strINSTORAGEID_VCHR = p_strInID;
                objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                objSubVO[iRow].m_strVENDORID_CHR = p_strVendorID;
                objSubVO[iRow].m_strVENDORName = p_strVendorName;
                objSubVO[iRow].m_intStatus = 1;
                objSubVO[iRow].m_strMEDICINETYPEID_CHR = drCurrent["medicinetypeid_chr"].ToString();
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]);
                objSubVO[iRow].m_strTYPECODE_CHR = drCurrent["typecode_vchr"].ToString();
                if(DateTime.TryParse(drCurrent["producedate_dat"].ToString(),out datTemp))
                {
                    objSubVO[iRow].m_dtmPRODUCEDATE_DAT = datTemp;
                }
            }
            return objSubVO;
        } 
        #endregion

        #region 设置非新制入库单审核选项为只读

        /// <summary>
        /// 设置非新制入库单审核选项为只读

        /// </summary>
        internal void m_mthSetCommitSelectReadonly()
        {
            for (int iRow = 0; iRow < m_objViewer.m_dgvMainInfo.Rows.Count; iRow++)
            {
                if (m_objViewer.m_dgvMainInfo.Rows[iRow].Cells["m_dgvtxtStatus"].Value.ToString() != "新制")
                {
                    m_objViewer.m_dgvMainInfo.Rows[iRow].Cells[0].ReadOnly = true;
                }
            }
        } 
        #endregion

        #region 获取仓库名

        /// <summary>
        /// 获取仓库名

        /// </summary>
        /// <param name="p_strStoreRoomID">仓库ID</param>
        /// <returns></returns>
        internal string m_strStoreRoomName(string p_strStoreRoomID)
        {
            string strStoreRoomName = string.Empty;
            long lngRes = m_objDomain.m_lngGetStoreRoomName(p_strStoreRoomID, out strStoreRoomName);
            return strStoreRoomName;
        } 
        #endregion
        /// <summary>
        /// 获取出入库类型
        /// </summary>
        /// <param name="m_strImportType"></param>
        /// <returns></returns>
        internal void m_mthGetImpExpTypeInfo(string m_strImportType)
        {
            DataTable  m_dtImpExpTypeInfo = new DataTable();
            long lngRes = -1;
            lngRes = m_objDomain.m_mthGetImpExpTypeInfo(out m_dtImpExpTypeInfo);
            if (lngRes > 0)
            {
                if (m_dtImpExpTypeInfo.Rows.Count == 0)
                {
                    MessageBox.Show("药库入库类型数据为空，请先维护药库入库类型数据！");
                    return;
                }
                DataView dv=m_dtImpExpTypeInfo.DefaultView;

                if (m_strImportType != "*")
                {   string[] strImpTypeArr=m_strImportType.Split('*');
             
                string m_strFilter = "flag_int=0 and typecode_vchr in ({Conditions}) ";
                    string m_strConditions="";
                    for(int i=0;i<strImpTypeArr.Length;i++)
                    {
                        if (strImpTypeArr.Length == 1)
                        {
                            m_strConditions = "'" + strImpTypeArr[0] + "'";
                            break;
                        }
                        m_strConditions += "'" + strImpTypeArr[i] + "'";
                        if (i != strImpTypeArr.Length - 1)
                        {
                            m_strConditions+=",";
                        }
                    }
                    m_strFilter = m_strFilter.Replace("{Conditions}", m_strConditions);
                    dv.RowFilter = m_strFilter;
                }
                else
                {
                    dv.RowFilter = "flag_int=0";
                }
                DataTable dtTemp = dv.ToTable();
                this.m_objViewer.m_tmsShowNewMake.Items.Clear();
                ToolStripMenuItem mi;
                ToolStripSeparator Separator;
                this.m_objViewer.m_cboInComeType.Items.Clear();
                this.m_objViewer.m_cboInComeType.Item.Add("全部", "0");
                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    mi = new ToolStripMenuItem(string.Format("新制({0})",dtTemp.Rows[j]["typename_vchr"].ToString()));
                    mi.Tag = dtTemp.Rows[j]["typecode_vchr"].ToString();
                    mi.Click += new EventHandler(mi_Click);
                    this.m_objViewer.m_tmsShowNewMake.Items.Add(mi);
                    if (j != dtTemp.Rows.Count - 1)
                    {
                        Separator = new ToolStripSeparator();
                        this.m_objViewer.m_tmsShowNewMake.Items.Add(Separator);
                    }
                    this.m_objViewer.m_cboInComeType.Item.Add(dtTemp.Rows[j]["typename_vchr"].ToString(), dtTemp.Rows[j]["typecode_vchr"].ToString());
                }
                this.m_objViewer.m_cboInComeType.SelectedIndex = 0;
            }
        }

        private void mi_Click(object sender, EventArgs e)
        {  
            ToolStripMenuItem mi=sender as ToolStripMenuItem;
            frmPurchase_Detail frmPurchaseType = new frmPurchase_Detail(this.m_objViewer.m_strStorageID, 1, Convert.ToInt16(mi.Tag));
            frmPurchaseType.Text = mi.Text.Replace("新制", string.Empty).Replace("(", string.Empty).Replace(")", string.Empty); ;
            //frmPurchaseType.m_bolAddOutMedicineInfo = true;
            //frmPurchaseType.m_intInstorageType = 3;
            frmPurchaseType.FormClosed += new FormClosedEventHandler(this.m_objViewer.frmPurchaseType_FormClosed);
            frmPurchaseType.ShowDialog();
        }
        #region 获取指定日期内的金额
        /// <summary>
        /// 获取指定日期内的金额
        /// </summary>
        internal void m_mthGetAllMoney()
        {
            m_objViewer.m_lblBuyInMoney.Text = string.Empty;
            m_objViewer.m_lblRetailMoney.Text = string.Empty;
            m_objViewer.m_lblWholeSaleMoney.Text = string.Empty;

            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));

            if (m_objViewer.m_dtbAllMoney == null)
            {
                long lngRes = m_objDomain.m_lngGetAllInMoney(dtmBegin, dtmEnd,m_objViewer.m_strStorageID, out m_objViewer.m_dtbAllMoney);
            }

            if (m_objViewer.m_dtbAllMoney != null && m_objViewer.m_dtbAllMoney.Rows.Count == 0)
            {
                m_objViewer.m_dtbAllMoney = null;
            }

            if (m_objViewer.m_dtbAllMoney != null && m_objViewer.m_dtvMainView != null)
            {
                int intRowsCount = m_objViewer.m_dtvMainView.Count;
                Hashtable hstMedicine = new Hashtable();
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    hstMedicine.Add(Convert.ToInt64(m_objViewer.m_dtvMainView[iRow]["SERIESID_INT"]), m_objViewer.m_dtvMainView[iRow]["instorageid_vchr"].ToString());
                }

                //if (lstSEQ.Count > 0)
                //{
                DataRow[] drAllMoney = m_objViewer.m_dtbAllMoney.Select(m_strMainFilter());
                    //if (lstSEQ.Count <= 300)
                    //{
                    //    StringBuilder stbFilter = new StringBuilder(100);
                    //    for (int iRow = 0; iRow < lstSEQ.Count; iRow++)
                    //    {
                    //        stbFilter.Append("SERIESID_INT=");
                    //        stbFilter.Append(lstSEQ[iRow].ToString());
                    //        if (iRow < lstSEQ.Count-1)
                    //        {
                    //            stbFilter.Append(" or ");
                    //        }
                    //    }
                    //    drAllMoney = m_objViewer.m_dtbAllMoney.Select(stbFilter.ToString());
                    //}
                    //else//大于300，DataTable作Select操作时会出现堆栈溢出错误
                    //{
                    //    int intCount = lstSEQ.Count / 300;
                    //    List<DataRow> lstRows = new List<DataRow>();
                    //    for (int iAll = 0; iAll < intCount; iAll++)
                    //    {
                    //        StringBuilder stbFilter = new StringBuilder(100);
                    //        for (int iRow = 0 + iAll * 300; iRow < 300 + iAll * 300; iRow++)
                    //        {
                    //            stbFilter.Append("SERIESID_INT=");
                    //            stbFilter.Append(lstSEQ[iRow].ToString());
                    //            if (iRow < 300 + iAll * 300 - 1)
                    //            {
                    //                stbFilter.Append(" or ");
                    //            }
                    //        }
                    //        DataRow[] drTemp = m_objViewer.m_dtbAllMoney.Select(stbFilter.ToString());
                    //        if (drTemp != null && drTemp.Length > 0)
                    //        {
                    //            lstRows.AddRange(drTemp);
                    //        }
                    //    }
                    //    if (lstSEQ.Count % 300 != 0)
                    //    {
                    //        StringBuilder stbFilter = new StringBuilder(100);
                    //        for (int iRow = 300 * intCount; iRow < lstSEQ.Count; iRow++)
                    //        {
                    //            stbFilter.Append("SERIESID_INT=");
                    //            stbFilter.Append(lstSEQ[iRow].ToString());
                    //            if (iRow < lstSEQ.Count - 1)
                    //            {
                    //                stbFilter.Append(" or ");
                    //            }
                    //        }
                    //        DataRow[] drTemp = m_objViewer.m_dtbAllMoney.Select(stbFilter.ToString());
                    //        if (drTemp != null && drTemp.Length > 0)
                    //        {
                    //            lstRows.AddRange(drTemp);
                    //        }
                    //    }
                    //    drAllMoney = lstRows.ToArray();
                    //}

                if (drAllMoney != null && drAllMoney.Length > 0)
                {
                    decimal dcmBuyIn = 0m;
                    decimal dcmWholeSale = 0m;
                    decimal dcmRetailSale = 0m;
                    for (int iM = 0; iM < drAllMoney.Length; iM++)
                    {
                        if (!hstMedicine.Contains(Convert.ToInt64(drAllMoney[iM]["seriesid_int"])))
                        {
                            continue;
                        }
                        dcmBuyIn += Convert.ToDecimal(drAllMoney[iM]["BuyInMoney"]);
                        dcmWholeSale += Convert.ToDecimal(drAllMoney[iM]["WholeSaleMoney"]);
                        dcmRetailSale += Convert.ToDecimal(drAllMoney[iM]["RetailPrice"]);
                    }

                    m_objViewer.m_lblBuyInMoney.Text = dcmBuyIn.ToString("0.0000");
                    m_objViewer.m_lblRetailMoney.Text = dcmRetailSale.ToString("0.0000");
                    m_objViewer.m_lblWholeSaleMoney.Text = dcmWholeSale.ToString("0.0000");
                }
                //}                
            }
        }

        /// <summary>
        /// 获取明细金额
        /// </summary>
        internal void m_mthGetAllSubMoney()
        {
            m_objViewer.m_lblBuyInSubMoney.Text = string.Empty;
            m_objViewer.m_lblWholeSaleSubMoney.Text = string.Empty;
            m_objViewer.m_lblRetailSubMoney.Text = string.Empty;

            if (m_objViewer.m_dtbSubData != null)
            {
                double dcmBuyIn = 0d;
                double dcmWholeSale = 0d;
                double dcmRetailSale = 0d;
                DataRow drTemp = null;
                for (int iM = 0; iM < m_objViewer.m_dtbSubData.Rows.Count; iM++)
                {
                    drTemp = m_objViewer.m_dtbSubData.Rows[iM];
                    //if (Convert.ToDouble(drTemp["PACKAMOUNT"]) > 0)
                    //{
                    //    dcmBuyIn += Convert.ToDouble(drTemp["PACKAMOUNT"]) * Convert.ToDouble(drTemp["PACKCALLPRICE_INT"]);
                    //}
                   // else
                   // {
                        dcmBuyIn += Convert.ToDouble(drTemp["CALLPRICE_INT"]) * Convert.ToDouble(drTemp["AMOUNT"]);
                    //}
                    dcmWholeSale += Convert.ToDouble(drTemp["WHOLESALEPRICE_INT"]) * Convert.ToDouble(drTemp["AMOUNT"]);
                    dcmRetailSale += Convert.ToDouble(drTemp["RETAILPRICE_INT"]) * Convert.ToDouble(drTemp["AMOUNT"]);
                }

                m_objViewer.m_lblBuyInSubMoney.Text = dcmBuyIn.ToString("0.0000");
                m_objViewer.m_lblRetailSubMoney.Text = dcmRetailSale.ToString("0.0000");
                m_objViewer.m_lblWholeSaleSubMoney.Text = dcmWholeSale.ToString("0.0000");
                double dcmly = dcmRetailSale - dcmBuyIn;
                m_objViewer.m_lblly.Text = dcmly.ToString("0.0000");
            }
        }
        #endregion

        #region 入账
        /// <summary>
        /// 入账
        /// </summary>
        internal void m_mthInAccount()
        {
            if (!m_objViewer.m_blnIsAdmin)
            {
                MessageBox.Show("当前用户没有药库管理权限，不能将药品入帐", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            List<DataRow> lstCheck = new List<DataRow>();
            List<long> lstSeq = new List<long>();//主表序列
            List<string> lstInStorageID = new List<string>();//入库单据号


            List<DataRow> lstCheckInOut = new List<DataRow>();
            List<long> lstSeqInOut = new List<long>();//主表序列
            List<string> lstInStorageIDInOut = new List<string>();//入库单据号

            for (int iSe = 0; iSe < m_objViewer.m_dgvMainInfo.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvMainInfo.Rows[iSe].Cells[0].Value))
                {
                    DataRow drCheck = ((DataRowView)m_objViewer.m_dgvMainInfo.Rows[iSe].DataBoundItem).Row;
                    if (drCheck["STATE_INT"].ToString() == "2")
                    {
                        if (drCheck["instoragetype_int"].ToString() == "3")
                        {
                            lstCheckInOut.Add(drCheck);
                            lstSeqInOut.Add(Convert.ToInt64(drCheck["seriesid_int"]));
                            lstInStorageIDInOut.Add(drCheck["instorageid_vchr"].ToString());
                        }
                        else
                        {
                            lstCheck.Add(drCheck);
                            lstSeq.Add(Convert.ToInt64(drCheck["seriesid_int"]));
                            lstInStorageID.Add(drCheck["instorageid_vchr"].ToString());
                        }
                    }

                }
            }

            DataRow[] drCommit = lstCheck.ToArray();
            DataRow[] drCommitInOut = lstCheckInOut.ToArray();
            if ((drCommit == null || drCommit.Length == 0) && (drCommitInOut == null || drCommitInOut.Length == 0))
            {
                MessageBox.Show("没有需入帐的药品入库信息", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            long lngResInOut=1;
            long lngRes=1;
            DateTime dtmNow = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            if (lstInStorageIDInOut.Count > 0)
            {
                lngResInOut = m_objDomain.m_lngInAccount(lstInStorageIDInOut.ToArray(), lstSeqInOut.ToArray(), m_objViewer.m_strStorageID, m_objViewer.LoginInfo.m_strEmpID, dtmNow, true);
                if (lngResInOut > 0)
                {
                    foreach (DataRow dr in drCommitInOut)
                    {
                        dr["INACCOUNTERID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
                        dr["accountername"] = m_objViewer.LoginInfo.m_strEmpName;
                        dr["STATE_INT"] = 3;
                        dr["ACCOUNT_DAT"] = dtmNow;
                        dr["statedesc"] = "入帐";
                    }
                }
            }
            if (lstInStorageID.Count > 0)
            {
                lngRes = m_objDomain.m_lngInAccount(lstInStorageID.ToArray(), lstSeq.ToArray(), m_objViewer.m_strStorageID, m_objViewer.LoginInfo.m_strEmpID, dtmNow);
                if (lngRes > 0)
                {
                    foreach (DataRow dr in drCommit)
                    {
                        dr["INACCOUNTERID_CHR"] = m_objViewer.LoginInfo.m_strEmpID;
                        dr["accountername"] = m_objViewer.LoginInfo.m_strEmpName;
                        dr["STATE_INT"] = 3;
                        dr["ACCOUNT_DAT"] = dtmNow;
                        dr["statedesc"] = "入帐";
                    }
                }
            }
            if (lngRes > 0 && lngResInOut > 0)
            {

                MessageBox.Show("入帐成功", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("入帐失败", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        /// <summary>
        /// 出库主表
        /// </summary>
        /// <param name="dtr"></param>
        /// <returns></returns>
        public clsMS_OutStorage_VO m_objGetOutMainISVO(DataRow dtr)
        {
           
            clsMS_OutStorage_VO m_objCurrentOutMain = new clsMS_OutStorage_VO();
            m_objCurrentOutMain.m_dtmASKDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            m_objCurrentOutMain.m_intSTATUS = 1;
            m_objCurrentOutMain.m_strASKDEPT_CHR = dtr["deptid_chr"].ToString();
            m_objCurrentOutMain.m_intOutStorageTYPE_INT = 3; //即入即出
            m_objCurrentOutMain.m_intFORMTYPE_INT = 1;
            m_objCurrentOutMain.m_strASKERID_CHR = dtr["MAKERID_CHR"].ToString();
            m_objCurrentOutMain.m_strCOMMENT_VCHR = dtr["COMMNET_VCHR"].ToString();
            m_objCurrentOutMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            m_objCurrentOutMain.m_dtmOutStorageDate = Convert.ToDateTime(dtr["INSTORAGEDATE_DAT"].ToString());
            return m_objCurrentOutMain;
        }

        #region 获取子表内容
        /// <summary>
        /// 获取子表内容
        /// </summary>
        /// <param name="p_drDetail">子表数据</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        private clsMS_OutStorageDetail_VO[] m_objGetDetailArr(DataTable p_drDetail, long p_lngMainSEQ)
        {
            clsMS_OutStorageDetail_VO[] objDetailArr = null;
            if (p_drDetail == null)
            {
                return null;
            }
            DateTime datTemp ;
            objDetailArr = new clsMS_OutStorageDetail_VO[p_drDetail.Rows.Count];
            for (int iRow = 0; iRow < p_drDetail.Rows.Count; iRow++)
            {
                objDetailArr[iRow] = new clsMS_OutStorageDetail_VO();
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = p_drDetail.Rows[iRow]["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCH = p_drDetail.Rows[iRow]["medicinename_vch"].ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR = p_drDetail.Rows[iRow]["MEDSPEC_VCHR"].ToString();
                objDetailArr[iRow].m_strOPUNIT_CHR = p_drDetail.Rows[iRow]["UNIT_VCHR"].ToString();
                objDetailArr[iRow].m_dblNETAMOUNT_INT = Convert.ToDouble(p_drDetail.Rows[iRow]["AMOUNT"]);

                m_objDomain.m_lngGetMedicineTypeVisionm(p_drDetail.Rows[iRow]["medicinetypeid_chr"].ToString(),out m_objViewer.m_clsTypeVisVO);
                if (m_objViewer.m_clsTypeVisVO != null && m_objViewer.m_clsTypeVisVO.m_intLotno == 0 && p_drDetail.Rows[iRow]["LOTNO_VCHR"].ToString() == "")
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = p_drDetail.Rows[iRow]["LOTNO_VCHR"].ToString();
                }
                //objDetailArr[iRow].m_strINSTORAGEID_VCHR = p_drDetail.Rows[iRow]["INSTORAGEID_VCHR"].ToString();
                objDetailArr[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drDetail.Rows[iRow]["CALLPRICE_INT"]);
                objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(p_drDetail.Rows[iRow]["WHOLESALEPRICE_INT"]);
                objDetailArr[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(p_drDetail.Rows[iRow]["RETAILPRICE_INT"]);
               // objDetailArr[iRow].m_strVENDORID_CHR = p_drDetail.Rows[iRow]["VENDORID_CHR"].ToString();
              //  objDetailArr[iRow].m_strVendorName = 
                //objDetailArr[iRow].m_dtmValidperiod_dat = Convert.ToDateTime(p_drDetail[iRow]["validperiod_dat"]);
                objDetailArr[iRow].m_strProductorID_chr = p_drDetail.Rows[iRow]["PRODUCTORID_CHR"].ToString();
             //   objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(p_drDetail.Rows[iRow]["INSTORAGEDATE_DAT"].ToString());
                objDetailArr[iRow].m_strMedicineTypeID_chr = p_drDetail.Rows[iRow]["medicinetypeid_chr"].ToString();
                objDetailArr[iRow].m_dtmValidperiod_dat = Convert.ToDateTime(p_drDetail.Rows[iRow]["VALIDPERIOD_DAT"]);
                //objDetailArr[iRow].m_dblRealGross = Convert.ToDouble(p_drDetail[iRow]["realgross_int"]);
                objDetailArr[iRow].m_intStatus = 1;
                objDetailArr[iRow].m_intRETURNNUM_INT = 0;
                objDetailArr[iRow].m_decPackQty = Convert.ToDecimal(p_drDetail.Rows[iRow]["PACKAMOUNT"]);
                objDetailArr[iRow].m_strTYPECODE_CHR = p_drDetail.Rows[iRow]["typecode_vchr"].ToString();
                if (DateTime.TryParse(p_drDetail.Rows[iRow]["producedate_dat"].ToString(), out datTemp))
                {
                    objDetailArr[iRow].m_dtmPRODUCEDATE_DAT = datTemp;
                }

            }
            return objDetailArr;
        }
        #endregion

        #region 是否显示批发价

        /// <summary>
        /// 是否显示批发价

        /// </summary>
        /// <param name="m_intShowWholePrice"></param>
        internal void m_lngGetShowWholePrice(out int m_intShowWholePrice)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetShowWholePrice(out m_intShowWholePrice);
            objPDDomain = null;
        }
        #endregion
    }
}
