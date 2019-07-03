using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 调入库单
    /// </summary>
    public class clsCtl_CallInStorageInfo : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_CallInStorageInfo m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore.frmCallInStorageInfo m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 查询供应商控件
        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 供应商
        /// </summary>
        private DataTable m_dtbVendor = null;
        #endregion

        #region 构造函数
        /// <summary>
        /// 调入库单
        /// </summary>
        public clsCtl_CallInStorageInfo()
        {
            m_objDomain = new clsDcl_CallInStorageInfo();
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
            m_objViewer = (frmCallInStorageInfo)frmMDI_Child_Base_in;
        }
        #endregion

        #region 查询入库信息
        /// <summary>
        /// 查询入库信息
        /// </summary>
        internal void m_mthSearchInStorageInfo()
        {
            if (m_objViewer.m_dtbInStorageInfo != null)
            {
                m_objViewer.m_dtbInStorageInfo.Rows.Clear();
            }

            if (m_objViewer.m_rdbInStorageID.Checked && string.IsNullOrEmpty(m_objViewer.m_txtInStorageID.Text))
            {
                MessageBox.Show("请先输入入库单据号","调入库单",MessageBoxButtons.OK,MessageBoxIcon.Error);
                m_objViewer.m_txtInStorageID.Focus();
                return;
            }
            else if (m_objViewer.m_rdbMedicineCode.Checked && m_objViewer.m_txtMedicineCode.Tag == null)
            {
                MessageBox.Show("请先选择药品", "调入库单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtMedicineCode.Focus();
                return;
            }

            if (m_objViewer.m_txtVendor.Tag == null)
            {
                MessageBox.Show("请先选择供应商", "调入库单", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_txtVendor.Focus();
                return;
            }

            long lngRes = 0;
            if (m_objViewer.m_rdbInStorageID.Checked)
            {
                lngRes = m_objDomain.m_lngCallInStorageInfoByInID(m_objViewer.m_strStorageID, m_objViewer.m_txtInStorageID.Text, m_objViewer.m_txtVendor.Tag.ToString(), out m_objViewer.m_dtbInStorageInfo);
            }
            else if (m_objViewer.m_rdbMedicineCode.Checked)
            {
                lngRes = m_objDomain.m_lngCallInStorageInfoByMedicineID(m_objViewer.m_strStorageID, m_objViewer.m_txtMedicineCode.Tag.ToString(), m_objViewer.m_txtVendor.Tag.ToString(), out m_objViewer.m_dtbInStorageInfo);
            }

            if (m_objViewer.m_dtbInStorageInfo != null)
            {
                m_objViewer.m_dgvInStorage.DataSource = m_objViewer.m_dtbInStorageInfo;
            }

            if (m_objViewer.m_dgvInStorage.Rows.Count > 0)
            {
                m_objViewer.m_dgvInStorage.Focus();
                m_objViewer.m_dgvInStorage.Rows[0].Selected = true;
                m_objViewer.m_dgvInStorage.CurrentCell = m_objViewer.m_dgvInStorage.Rows[0].Cells[1];
                m_objViewer.m_dgvInStorage.CurrentCell.Selected = true;
            }
            else
            {
                MessageBox.Show("未能找到相关数据", "调出库单", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        } 
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetBaseMedicine(string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicinDict);
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
                if (m_objViewer.m_dtbMedicinDict == null)
                {
                    m_mthGetMedicineInfo();
                }
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedicineCode.Location.X;
                Y = m_objViewer.m_txtMedicineCode.Location.Y + m_objViewer.m_txtMedicineCode.Size.Height;

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

            m_objViewer.m_txtMedicineCode.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineCode.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_txtVendor.Focus();
        }
        #endregion

        #region 获取选择的药品入库信息
        /// <summary>
        /// 获取选择的药品入库信息
        /// </summary>
        /// <param name="p_objDetailArr">药品入库信息</param>
        /// <returns></returns>
        internal long m_mthGetSelectedDetailVO(out clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            p_objDetailArr = null;
            if (m_objViewer.m_dtbInStorageInfo == null || m_objViewer.m_dtbInStorageInfo.Rows.Count == 0)
            {
                return 0;
            }
            long lngRes = 0;

            List<DataRow> drCheckRowIndex = new List<DataRow>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvInStorage.Rows.Count; iSe++)
            {
                if (Convert.ToBoolean(m_objViewer.m_dgvInStorage.Rows[iSe].Cells[0].Value))
                {
                    drCheckRowIndex.Add(m_objViewer.m_dtbInStorageInfo.Rows[iSe]);
                }
            }

            int intSelected = drCheckRowIndex.Count;
            if (intSelected == 0)
            {
                return 0;
            }

            clsDcl_ForeignRetreatOutStorageDetail objOSDomain = new clsDcl_ForeignRetreatOutStorageDetail();
            List<clsMS_OutStorageDetail_VO> objMSVO = new List<clsMS_OutStorageDetail_VO>();
            List<clsMS_OutStorageDetail_VO> objHasReturnMSVO = new List<clsMS_OutStorageDetail_VO>();//有退货历史的记录
            clsMS_OutStorageDetail_VO objTemp = null;
            int intReturnTimes = 0;
            StringBuilder stbQuestion = new StringBuilder(50);
            for (int iRow = 0; iRow < intSelected; iRow++)
            {
                objTemp = m_objGetOutVO(drCheckRowIndex[iRow]);
                lngRes = objOSDomain.m_lngGetCurrentReturnTimes(drCheckRowIndex[iRow]["medicineid_chr"].ToString(), drCheckRowIndex[iRow]["lotno_vchr"].ToString(), drCheckRowIndex[iRow]["instorageid_vchr"].ToString(), out intReturnTimes);
                
                if (intReturnTimes > 1)
                {
                    stbQuestion.Append(Convert.ToDateTime(drCheckRowIndex[iRow]["instoragedate_dat"]).ToString("yyyy年MM月dd日"));
                    stbQuestion.Append("入库的");
                    stbQuestion.Append(drCheckRowIndex[iRow]["medicinename_vch"].ToString());
                    stbQuestion.Append("已有");
                    stbQuestion.Append((intReturnTimes - 1).ToString());
                    stbQuestion.Append("次退货记录");
                    stbQuestion.Append(Environment.NewLine);
                    if (objTemp != null)
                    {
                        objHasReturnMSVO.Add(objTemp);
                    }
                }
                else
                {
                    if (objTemp != null)
                    {
                        objMSVO.Add(objTemp);
                    }
                }
            }
            objOSDomain = null;

            string strQuestion = stbQuestion.ToString();
            if (!string.IsNullOrEmpty(strQuestion))
            {
                strQuestion += "是否继续添加至退药出库记录？";
                frmHintMessageBox HintBox = new frmHintMessageBox(strQuestion);
                DialogResult drResult = HintBox.ShowDialog();
                if (drResult == DialogResult.Yes)
                {
                    objMSVO.AddRange(objHasReturnMSVO.ToArray());
                }
                else
                {
                    objMSVO.Clear();
                    objMSVO = null;
                    objHasReturnMSVO.Clear();
                    objHasReturnMSVO = null;
                    return -1;
                }

            }

            if (objMSVO.Count > 0)
            {
                p_objDetailArr = objMSVO.ToArray();
            }
           
            return lngRes;
        } 
        #endregion

        #region 获取出库信息
        /// <summary>
        /// 获取出库信息
        /// </summary>
        /// <param name="p_drData">数据</param>
        /// <returns></returns>
        private clsMS_OutStorageDetail_VO m_objGetOutVO(DataRow p_drData)
        {
            if (p_drData == null)
            {
                return null;
            }
            clsMS_OutStorageDetail_VO objOut = new clsMS_OutStorageDetail_VO();
            objOut.m_dblAskAmount = 0d;
            objOut.m_dblAvailaGross = Convert.ToDouble(p_drData["availagross_int"]);
            objOut.m_dblNETAMOUNT_INT = 0d;
            objOut.m_dblRealGross = Convert.ToDouble(p_drData["realgross_int"]);
            objOut.m_dcmBuyInMoney = Convert.ToDecimal(p_drData["inmoney"]);
            objOut.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drData["callprice_int"]);
            objOut.m_dcmRetailMoney = Convert.ToDecimal(p_drData["salemoney"]);
            objOut.m_dcmRETAILPRICE_INT = Convert.ToDecimal(p_drData["retailprice_int"]);
            objOut.m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(p_drData["wholesaleprice_int"]);
            objOut.m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(p_drData["instoragedate_dat"]);
            objOut.m_dtmValidperiod_dat = Convert.ToDateTime(p_drData["validperiod_dat"]);
            objOut.m_intRETURNNUM_INT = Convert.ToInt32(p_drData["ruturnnum_int"]);
            objOut.m_intStatus = 1;
            objOut.m_lngSERIESID_INT = -1;
            objOut.m_lngSERIESID2_INT = -1;
            objOut.m_strINSTORAGEID_VCHR = p_drData["instorageid_vchr"].ToString();
            objOut.m_strLOTNO_VCHR = p_drData["lotno_vchr"].ToString();
            objOut.m_strMEDICINECode = p_drData["assistcode_chr"].ToString();
            objOut.m_strMEDICINEID_CHR = p_drData["medicineid_chr"].ToString();
            objOut.m_strMEDICINENAME_VCH = p_drData["medicinename_vch"].ToString();
            objOut.m_strMEDSPEC_VCHR = p_drData["medspec_vchr"].ToString();
            objOut.m_strOPUNIT_CHR = p_drData["unit_vchr"].ToString();
            objOut.m_strProductorID_chr = p_drData["productorid_chr"].ToString();
            objOut.m_strRejectReason = string.Empty;
            objOut.m_strStorageUnit = p_drData["unit_vchr"].ToString();
            objOut.m_strVENDORID_CHR = p_drData["vendorid_chr"].ToString();
            objOut.m_strVendorName = p_drData["vendorname_vchr"].ToString();

            return objOut;
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

                int X = m_objViewer.m_txtVendor.Location.X;
                int Y = m_objViewer.m_txtVendor.Location.Y + m_objViewer.m_txtVendor.Size.Height;

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
            m_objViewer.m_txtVendor.Tag = null;
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtVendor.Tag = MS_VO.m_strVendorID;
            m_objViewer.m_txtVendor.Text = MS_VO.m_strVendorName;

            m_objViewer.m_mthInvokeVendorChange();
            m_objViewer.m_cmdSearch.Focus();
        }
        #endregion
    }
}
