using System;
using System.Collections.Generic;
using System.Data;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 入库统计报表
    /// </summary>
    public class clsCtl_InStorageStatisticsReport : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 入库统计报表中间件访问类
        /// </summary>
        private clsDcl_InStorageStatisticsReport m_objDomain = null;
        /// <summary>
        /// 入库统计报表窗体
        /// </summary>
        private frmInStorageStatisticsReport m_objViewer = null;
        /// <summary>
        /// 查询供应商控件

        /// </summary>
        private ctlQueryVendor m_ctlQueryVendor = null;
        /// <summary>
        /// 供应商

        /// </summary>
        private DataTable m_dtbVendor = null;

        /// <summary>
        /// 入库统计报表窗体逻辑控制
        /// </summary>
        public clsCtl_InStorageStatisticsReport()
        {
            m_objDomain = new clsDcl_InStorageStatisticsReport();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmInStorageStatisticsReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region 设置仓库名至报表
        /// <summary>
        /// 设置仓库名至报表
        /// </summary>
        public void m_mthSetStorageNameToReport()
        {
            if (string.IsNullOrEmpty(m_objViewer.m_strStorageName))
            {
                long lngRes = m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out m_objViewer.m_strStorageName);
            }
            this.m_objViewer.m_dwcData.Modify("storagename.text = '" + m_objViewer.m_strStorageName + "'");

        }
        #endregion

        public void m_mthSetStorageNameToFrm()
        {
            long lngRes = m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out m_objViewer.m_strStorageName);
            this.m_objViewer.Text += "(" + m_objViewer.m_strStorageName + ")";
        }
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

            m_objViewer.m_cmdSearch.Focus();
        }
        #endregion

        #region 统计入库
        /// <summary>
        /// 统计入库
        /// </summary>
        internal void m_mthStatistics()
        {
            DateTime dtmBegin = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd 23:59:59"));

            this.m_objViewer.m_dwcData.Modify("begindate.text = '" + dtmBegin.ToString("yyyy-MM-dd") + "'");
            this.m_objViewer.m_dwcData.Modify("enddate.text = '" + dtmEnd.ToString("yyyy-MM-dd") + "'");
            m_mthSetStorageNameToReport();

            string strVendorID = string.Empty;
            if (m_objViewer.m_txtVendor.Tag != null && !string.IsNullOrEmpty(m_objViewer.m_txtVendor.Text))
            {
                strVendorID = m_objViewer.m_txtVendor.Tag.ToString();
            }

            int intSetID = 0;
            if (m_objViewer.m_cboType.SelectedItem != null)
            {
                clsMS_MedicineTypeSetVO objSet = m_objViewer.m_cboType.SelectedItem as clsMS_MedicineTypeSetVO;
                if (objSet != null)
                {
                    intSetID = objSet.m_intMedicineTypeSetID;
                }
            }

            DataTable dtbData = null;
            long lngRes = m_objDomain.m_lngStatistics(m_objViewer.m_strStorageID, dtmBegin, dtmEnd, strVendorID, intSetID, out dtbData);

            DataTable dtbForeignRetreat = null;
            if (m_objViewer.m_chkStatOut.Checked)
            {
                lngRes = m_objDomain.m_lngStatisticsForeignRetreat(m_objViewer.m_strStorageID, dtmBegin, dtmEnd, strVendorID, intSetID, out dtbForeignRetreat);
            }

            if ((dtbData == null || dtbData.Rows.Count == 0) && (dtbForeignRetreat == null || dtbForeignRetreat.Rows.Count == 0))
            {
                m_objViewer.m_dwcData.Reset();
                return;
            }

            //合并入库统计及外退统计
            DataTable dtbStatistics = m_dtbMergeStatisticsData(dtbData, dtbForeignRetreat);

            if (dtbStatistics != null)
            {
                this.m_objViewer.m_dwcData.SetRedrawOff();

                //按药品ID排序
                int intTaxis;
                DataView dtv = new DataView();
                dtv = dtbStatistics.DefaultView;
                m_objDomain.m_lngGetTaxisType(out intTaxis);
                if (intTaxis == 0)
                {
                    dtv.Sort = "vendorname_vchr";
                }
                else
                {
                    dtv.Sort = "usercode_chr";

                }
                dtbStatistics = dtv.ToTable();

                this.m_objViewer.m_dwcData.Retrieve(dtbStatistics);
                this.m_objViewer.m_dwcData.SetRedrawOn();
                this.m_objViewer.m_dwcData.Refresh();
            }
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
                    drTemp["inmoney"] = 0 - Convert.ToDouble(drTemp["inmoney"]);
                    drTemp["wholesalemoney"] = 0 - Convert.ToDouble(drTemp["wholesalemoney"]);
                    drTemp["retailmoney"] = 0 - Convert.ToDouble(drTemp["retailmoney"]);
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
                    double dblInMoney = Convert.ToDouble(drInTemp["inmoney"]);
                    double dblWholeSaleMoney = Convert.ToDouble(drInTemp["wholesalemoney"]);
                    double dblRetailMoney = Convert.ToDouble(drInTemp["retailmoney"]);
                    for (int iRow = 0; iRow < drOut.Length; iRow++)
                    {
                        dblInMoney -= Convert.ToDouble(drOut[iRow]["inmoney"]);
                        dblWholeSaleMoney -= Convert.ToDouble(drOut[iRow]["wholesalemoney"]);
                        dblRetailMoney -= Convert.ToDouble(drOut[iRow]["retailmoney"]);
                    }

                    drInTemp["inmoney"] = dblInMoney.ToString("0.0000");
                    drInTemp["wholesalemoney"] = dblWholeSaleMoney.ToString("0.0000");
                    drInTemp["retailmoney"] = dblRetailMoney.ToString("0.0000");

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
                    drTemp["inmoney"] = 0 - Convert.ToDouble(drTemp["inmoney"]);
                    drTemp["wholesalemoney"] = 0 - Convert.ToDouble(drTemp["wholesalemoney"]);
                    drTemp["retailmoney"] = 0 - Convert.ToDouble(drTemp["retailmoney"]);
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
        #endregion

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

        #region 获取仓库
        /// <summary>
        /// 获取仓库
        /// </summary>
        internal void m_mthGetStoreroom()
        {
            if (m_objViewer.tvRoom.Nodes.Count > 1)
            {
                return;
            }
            DataTable dtbRoom = new DataTable();
            DataView dv;
            
            m_objDomain.m_lngGetStoreroom(out dtbRoom);
            dv = dtbRoom.DefaultView;

            m_objViewer.tvRoom.Nodes.Clear();
            TreeNode tn = new TreeNode();
            tn.Tag = "all";
            tn.Text = "全部";
            tn.Checked = true;
            m_objViewer.tvRoom.Nodes.Add(tn);
            for (int intRow = 0; intRow < dtbRoom.Rows.Count; intRow++)
            {
                TreeNode tn2 = new TreeNode();
                tn2.Tag = dtbRoom.Rows[intRow]["MEDICINEROOMID"].ToString().Trim();
                tn2.Text = dtbRoom.Rows[intRow]["MEDICINEROOMNAME"].ToString().Trim();
                m_objViewer.tvRoom.Nodes.Add(tn2);
            }
        }
        #endregion
    }
}
