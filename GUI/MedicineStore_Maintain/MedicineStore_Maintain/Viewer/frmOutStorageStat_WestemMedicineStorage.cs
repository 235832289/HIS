using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
//using com.digitalwave.iCare.middletier.MedicineStoreService;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.MedicineStore_Maintain;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public partial class frmOutStorageStat_WestemMedicineStorage : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public string p_strReportName;
        public string p_strStorageName;
        public frmOutStorageStat_WestemMedicineStorage()
        {
            DataTable dtbExportDept = new DataTable();
            InitializeComponent();
            //m_txtAskDeptPage1.m_mthInitDeptData(LoginInfo.m_strEmpID);
            clsDomainController_OutStorageStat objDomain = new clsDomainController_OutStorageStat();
            objDomain.m_lngGetExportDept(out dtbExportDept);
            m_txtAskDeptPage1.m_mthInitDeptData(dtbExportDept);


        }

        internal DataTable dtbResult = null;
        //internal clsMS_ReceiveDept_VO[] m_objDeptBseArr = null;
        internal clsMS_OutStorageStatQueryCondition_VO m_value_Param ;
        private string m_strStorageID = string.Empty;

        public void ShowOutStorageStat(string strStorageID,string m_strReportName)
        {
            clsDomainController_OutStorageStat objDomain = new clsDomainController_OutStorageStat();
            m_strStorageID = strStorageID;
            p_strReportName = m_strReportName;
            objDomain.m_lngGetStoreRoomName(m_strStorageID, out p_strStorageName);
            this.Show();
        }

        #region 窗体Load事件
        /// <summary>
        /// 窗体Load事件
        /// </summary>
        private void frmOutStorageStat_WestemMedicineStorage_Load(object sender, EventArgs e)
        {
            if (m_value_Param == null)
                m_value_Param = new clsMS_OutStorageStatQueryCondition_VO();
            m_value_Param.m_blnPharmacyMedicineCancel = false;
            m_value_Param.m_blnStorageMedicineCancel = false;
            m_value_Param.m_intOutStorageType = 0;
            m_value_Param.m_strReceiveDept = "";
            m_value_Param.m_dtmOutStorageBeginDate = "";
            m_value_Param.m_dtmOutStorageEndDate = "";
            m_value_Param.m_strStorageID = m_strStorageID;

            txtOutStorageBeginDate.Text = DateTime.Now.AddMonths(-1).ToString("yyyy年MM月dd日");
            txtOutStorageEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd日");

            dwOutStorageStat.LibraryList = clsPublic.PBLPath;//库名

            dwOutStorageStat.DataWindowObject = p_strReportName == "" ? "outstoragestat" : "outstoragestat_" + p_strReportName;//库中的对象名

            dwOutStorageStat.PrintProperties.Prompt = true;
            dwOutStorageStat.Modify("title_t_1.text='出库统计报表(" + p_strStorageName + ")'");
            dwOutStorageStat.Modify(@"t_9.text=' '");
            //dwOutStorageStat.Enabled = false;

            m_mthGetMedicineTypeSet();

            //dwOutStorageStat.PrintProperties.Preview = true;

            //dwOutStorageStat.PrintProperties.ShowPreviewButtons = true;
            //dwOutStorageStat.PrintProperties.ShowPreviewOutline = true;

        }
        #endregion

        #region 获取药品出库统计数据
        /// <summary>
        /// 查询条件保存在“clsMS_OutStorageStatQueryCondition_VO”类型对象中
        /// </summary>
        private void GetOutStorageStatData()
        {
            long lngRes = 0;

            if (m_value_Param == null)
                m_value_Param = new clsMS_OutStorageStatQueryCondition_VO();
            m_value_Param.m_blnPharmacyMedicineCancel = false;
            m_value_Param.m_blnStorageMedicineCancel = false;
            m_value_Param.m_intOutStorageType = 0;
            m_value_Param.m_strReceiveDept = "";
            m_value_Param.m_dtmOutStorageBeginDate = "";
            m_value_Param.m_dtmOutStorageEndDate = "";
            m_value_Param.m_strStorageID = m_strStorageID;

            if ((txtOutStorageBeginDate.Text.Trim().Length == 11) && (txtOutStorageEndDate.Text.Trim().Length == 11))
            {
                if ((Convert.ToDateTime(txtOutStorageBeginDate.Text)) > (Convert.ToDateTime(txtOutStorageEndDate.Text)))
                {
                    MessageBox.Show("出库开始日期必须小于或等于出库结束日期！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtOutStorageBeginDate.Focus();
                    return;
                }
            }

            if (txtOutStorageBeginDate.Text.Trim().Length == 11)
            {
                string strDate = txtOutStorageBeginDate.Text;
                m_value_Param.m_dtmOutStorageBeginDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd 00:00:00");
            }
            else
            {
                m_value_Param.m_dtmOutStorageBeginDate = "";
            }

            if (txtOutStorageEndDate.Text.Trim().Length == 11)
            {
                string strDate = txtOutStorageEndDate.Text;
                m_value_Param.m_dtmOutStorageEndDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd 23:59:59"); 
            }
            else
            {
                m_value_Param.m_dtmOutStorageEndDate = "";
            }


            m_value_Param.m_blnPharmacyMedicineCancel = chkPharmacyMedicineCancel.Checked;

            m_value_Param.m_intOutStorageType = 0;

            if (m_txtAskDeptPage1.Text.Length > 0)
            {
                m_value_Param.m_strReceiveDept = m_txtAskDeptPage1.StrItemId;
            }
            else
                m_value_Param.m_strReceiveDept = "all";

            int intMedicineTypeSetID = -1;
            if (m_cboType.SelectedItem != null)
            {
                clsMS_MedicineTypeSetVO objSet = m_cboType.SelectedItem as clsMS_MedicineTypeSetVO;
                if (objSet != null)
                {
                    intMedicineTypeSetID = objSet.m_intMedicineTypeSetID;
                    m_value_Param.m_intMedicineTypeSetID = objSet.m_intMedicineTypeSetID;
                }
            }

            clsDomainController_OutStorageStat objDomain = new clsDomainController_OutStorageStat();

              //调用Com+服务端
            DataTable dtbOut = null;//出库数据
            DataTable dtbWithin = null;//内退数据
            lngRes = objDomain.m_lngGetResultByOutStorageStat(ref m_value_Param, ref dtbOut);
            if (chkPharmacyMedicineCancel.Checked)
            {
                string strDeptID = string.Empty;
                if (!string.IsNullOrEmpty(m_txtAskDeptPage1.Text) && !string.IsNullOrEmpty(m_txtAskDeptPage1.StrItemId))
                {
                    strDeptID = m_txtAskDeptPage1.StrItemId;
                }
                lngRes = objDomain.m_lngGetWithinWithdrawal(m_strStorageID, Convert.ToDateTime(Convert.ToDateTime(txtOutStorageBeginDate.Text).ToString("yyyy-MM-dd 00:00:00")), Convert.ToDateTime(Convert.ToDateTime(txtOutStorageEndDate.Text).ToString("yyyy-MM-dd 23:59:59")), strDeptID, intMedicineTypeSetID, out dtbWithin);
            }
            if (lngRes <= 0)
            {
                dtbResult = null;
                return;
            }
            dtbResult = m_dtbMergeStatisticsData(dtbOut, dtbWithin);
        }

        #region 合并出库统计及内退统计
        /// <summary>
        /// 合并出库统计及内退统计
        /// </summary>
        /// <param name="p_dtbData">出库统计表数据</param>
        /// <param name="p_dtbWithin">内退统计表数据</param>
        /// <returns></returns>
        private DataTable m_dtbMergeStatisticsData(DataTable p_dtbData, DataTable p_dtbWithin)
        {
            DataTable dtbReturn = null;

            if ((p_dtbData == null || p_dtbData.Rows.Count == 0) && (p_dtbWithin == null || p_dtbWithin.Rows.Count == 0))
            {
                return null;
            }

            #region 只有其中一表有数据，则返回该表，不合并
            if (p_dtbData != null && p_dtbData.Rows.Count > 0 && (p_dtbWithin == null || p_dtbWithin.Rows.Count == 0))
            {
                dtbReturn = p_dtbData;
                return dtbReturn;
            }
            if (p_dtbWithin != null && p_dtbWithin.Rows.Count > 0 && (p_dtbData == null || p_dtbData.Rows.Count == 0))
            {
                DataRow drTemp = null;
                int intRowsCount = p_dtbWithin.Rows.Count;
                string strDeptName = string.Empty;//科室
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = p_dtbWithin.Rows[iRow];
                    strDeptName = drTemp["deptname_vchr"].ToString();
                    if (string.IsNullOrEmpty(strDeptName))
                    {
                        drTemp["deptname_vchr"] = "退";
                    }
                    else
                    {
                        drTemp["deptname_vchr"] = "退(" + strDeptName + ")";
                    }
                    drTemp["callsum"] = 0 - Convert.ToDouble(drTemp["callsum"]);
                    drTemp["wholesalesum"] = 0 - Convert.ToDouble(drTemp["wholesalesum"]);
                    drTemp["retailsum"] = 0 - Convert.ToDouble(drTemp["retailsum"]);
                }
                dtbReturn = p_dtbWithin;
                return dtbReturn;
            }
            #endregion

            int intInDataCount = p_dtbData.Rows.Count;//出库统计行数            
            DataRow drInTemp = null;
            for (int iInRow = 0; iInRow < intInDataCount; iInRow++)
            {
                drInTemp = p_dtbData.Rows[iInRow];
                //获取相同供应商相同分类的数据行
                DataRow[] drOut = p_dtbWithin.Select("deptname_vchr = '" + drInTemp["deptname_vchr"].ToString() + "'");
                if (drOut != null && drOut.Length > 0)
                {
                    //入库统计中的金额减去外退金额
                    double dblInMoney = Convert.ToDouble(drInTemp["callsum"]);
                    double dblWholeSaleMoney = Convert.ToDouble(drInTemp["wholesalesum"]);
                    double dblRetailMoney = Convert.ToDouble(drInTemp["retailsum"]);
                    for (int iRow = 0; iRow < drOut.Length; iRow++)
                    {
                        dblInMoney -= Convert.ToDouble(drOut[iRow]["callsum"]);
                        dblWholeSaleMoney -= Convert.ToDouble(drOut[iRow]["wholesalesum"]);
                        dblRetailMoney -= Convert.ToDouble(drOut[iRow]["retailsum"]);
                    }

                    drInTemp["callsum"] = dblInMoney.ToString("0.0000");
                    drInTemp["wholesalesum"] = dblWholeSaleMoney.ToString("0.0000");
                    drInTemp["retailsum"] = dblRetailMoney.ToString("0.0000");

                    foreach (DataRow drDel in drOut)
                    {
                        p_dtbWithin.Rows.Remove(drDel);
                    }
                }
            }

            #region 外理内退数据
            //如有剩余内退统计科室数据，即此内退科室未能与出库统计中的科室相对应，则在科室名前标明"退"
            //同时将这些数据添加至返回表中
            int intOutDataCount = p_dtbWithin.Rows.Count;
            if (intOutDataCount > 0)
            {
                DataRow drTemp = null;
                string strDeptName = string.Empty;//供应商名
                for (int iRow = 0; iRow < intOutDataCount; iRow++)
                {
                    drTemp = p_dtbWithin.Rows[iRow];
                    strDeptName = drTemp["deptname_vchr"].ToString();
                    if (string.IsNullOrEmpty(strDeptName))
                    {
                        drTemp["deptname_vchr"] = "退";
                    }
                    else
                    {
                        drTemp["deptname_vchr"] = "退(" + strDeptName + ")";
                    }
                    drTemp["callsum"] = 0 - Convert.ToDouble(drTemp["callsum"]);
                    drTemp["wholesalesum"] = 0 - Convert.ToDouble(drTemp["wholesalesum"]);
                    drTemp["retailsum"] = 0 - Convert.ToDouble(drTemp["retailsum"]);
                }
                dtbReturn = p_dtbWithin;
            }
            #endregion

            if (dtbReturn != null)//有剩余内退统计科室数据
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

            if (objMPVO == null || m_cboType.Items.Count > 0)
            {
                return;
            }

            clsMS_MedicineTypeSetVO objAll = new clsMS_MedicineTypeSetVO();
            objAll.m_intMedicineTypeSetID = 0;
            objAll.m_strMedicineTypeSetName = "全部";

            m_cboType.Items.Add(objAll);
            m_cboType.Items.AddRange(objMPVO);

            m_cboType.SelectedIndex = 0;
        }
        #endregion


        #region 统计按钮
        /// <summary>
        /// 统计按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdStat_Click(object sender, EventArgs e)
        {
            dwOutStorageStat.Reset();
            GetOutStorageStatData();//获取数据
            if (dtbResult != null)
            {
                if ((txtOutStorageBeginDate.Text.Trim().Length == 11) || (txtOutStorageEndDate.Text.Trim().Length == 11))
                   dwOutStorageStat.Modify("t_9.text='"+txtOutStorageBeginDate.Text+" 至 "+txtOutStorageEndDate.Text+"'");
                else
                   dwOutStorageStat.Modify("t_9.text='全部'");
               dwOutStorageStat.Modify("t_type.text='" + m_cboType.Text + "'");
               dwOutStorageStat.SetRedrawOff();
               dwOutStorageStat.Retrieve(dtbResult);//绑定表
               dwOutStorageStat.SetRedrawOn();
               dwOutStorageStat.Refresh();

            }

        }
        #endregion

        #region 是否预览
        /// <summary>
        /// 是否预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkPreview_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkPreview.Checked == true)
            //    dwOutStorageStat.Enabled = true;
            //else
            //    dwOutStorageStat.Enabled = false;            
            dwOutStorageStat.PrintProperties.Preview = chkPreview.Checked;
            dwOutStorageStat.PrintProperties.ShowPreviewRulers = true;//显示预览标尺
            dwOutStorageStat.PrintProperties.PreviewZoom=100;//缩放比例

        }
        #endregion

        #region 打印按钮
        /// <summary>
        /// 打印按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdPrint_Click(object sender, EventArgs e)
        {
            dwOutStorageStat.Print();
        }
        #endregion

        #region 实现按回车键移动焦点
        private void txtOutStorageBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    txtOutStorageEndDate.Focus();
                    break;
            }

        }

        private void txtOutStorageEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    m_txtAskDeptPage1.Focus();
                    break;
            }

        }

        private void m_txtAskDeptPage1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    chkPharmacyMedicineCancel.Focus();
                    break;
            }


        }


        private void chkPharmacyMedicineCancel_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    chkPreview.Focus();
                    break;
            }

        }

        private void chkPreview_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    txtOutStorageBeginDate.Focus();
                    break;
            }

        }

        #endregion

        #region 退出按钮
        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion



    }
}