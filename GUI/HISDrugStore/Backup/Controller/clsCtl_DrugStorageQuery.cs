using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.IO;
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using Sybase.DataWindow;
using System.Collections;
using System.Data.OleDb;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房库存查询控制层
    /// </summary>
    public class clsCtl_DrugStorageQuery : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 药房库存查询控制层构造方法
        /// </summary>
        public clsCtl_DrugStorageQuery()
        {            
            m_objDomain = new clsDcl_DrugStorageQuery();
        }

        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_DrugStorageQuery m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmDrugStorageQuery m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;        
        /// <summary>
        /// 药库基本信息
        /// </summary>
        private clsValue_StorageBse_VO[] m_objStorageBseArr = null;
        /// <summary>
        /// 药品类型数组
        /// </summary>
        private clsValue_MedicineType_VO[] m_objMedicineTypeArr = null;
        private clsValue_MedicineType_VO[] objMedicineTypeArr = null;
        /// <summary>
        /// 查询药品信息
        /// </summary>
        private clsStorageDetail_SqlConditionQueryParam_VO m_value_Param = new clsStorageDetail_SqlConditionQueryParam_VO();
        /// <summary>
        /// 药品明细数据表
        /// </summary>  
        internal DataTable dtbResult = null;
        /// <summary>
        /// 统计信息
        /// </summary>
        private clsStorageDetail_Stat_VO m_objStatValue = new clsStorageDetail_Stat_VO();
        /// <summary>
        /// 统计信息临时表
        /// </summary>
        private DataTable dtbTem = new DataTable();
        /// <summary>
        /// 货架
        /// </summary>
        private DataTable m_dtbStorageRack = new DataTable();
        
        /// <summary>
        /// 20080701 增加住院药房库存查询
        /// </summary>
        bool m_blnIsHospital = false;
        
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmDrugStorageQuery)frmMDI_Child_Base_in;
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable m_dtMedicineInfo)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_dtMedicineInfo);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedicineCode.Location.X + m_objViewer.gradientPanel1.Location.X;
                Y = m_objViewer.m_txtMedicineCode.Location.Y + m_objViewer.m_txtMedicineCode.Size.Height + m_objViewer.gradientPanel1.Location.Y;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            clsPub.m_mthGetMedBaseInfo(m_objViewer.m_cboStorage.SelectItemValue, out m_objViewer.m_dtMedicineInfo);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtMedicineInfo;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }
            m_objViewer.m_txtMedicineCode.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineCode.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_blnFound = false;
            m_objViewer.fqn_OnLocateMedicine(MS_VO.m_strMedicineName, 1);
            if (m_objViewer.m_blnFound == false)
            {
                m_objViewer.m_btnQuery.PerformClick();
                m_objViewer.m_blnFound = false;
                m_objViewer.blnRestart = true;
                m_objViewer.fqn_OnLocateMedicine(MS_VO.m_strMedicineName, 1);
                if(m_objViewer.m_blnFound == false)
                    MessageBox.Show("当前查询界面没有此药品的库存情况，请修改查询条件。", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.blnRestart = false;
            }
        }
        #endregion

        #region 获取药库基本信息
        /// <summary>
        /// 获取药库基本信息
        /// </summary>
        internal void m_mthShowStorage()
        {
            long lngRes = 0;
            clsValue_StorageBse_VO[] objStorageBseArr = null;
            if (m_objViewer.m_cboStorage.Items.Count == 0)
            {
                try
                {
                    if (m_objViewer.m_strMedStoreArr != null)
                    {
                        m_objDomain.m_lngGetResultByConditionStorageBse(out objStorageBseArr);
                        for (int i = 0; i < objStorageBseArr.Length; i++)
                        {
                            for (int j = 0; j < m_objViewer.m_strMedStoreArr.Length; j++)
                            {
                                if (m_objViewer.m_strMedStoreArr[j].Trim() == objStorageBseArr[i].MEDICINEROOMID)
                                    m_objViewer.m_cboStorage.Item.Add(objStorageBseArr[i].MEDICINEROOMNAME, objStorageBseArr[i].MEDICINEROOMID);
                            }
                        }
                        m_objViewer.m_cboStorage.SelectedIndex = 0;
                    }
                    else
                    {
                        lngRes = m_objDomain.m_lngGetResultByConditionStorageBse(out objStorageBseArr);

                        if (lngRes > 0)
                        {
                            m_objStorageBseArr = new clsValue_StorageBse_VO[objStorageBseArr.Length];
                            int m_index = 0;
                            for (int i1 = 0; i1 < objStorageBseArr.Length; i1++)
                            {
                                m_index = m_objViewer.m_cboStorage.Items.Add(objStorageBseArr[i1].MEDICINEROOMNAME);
                                m_objStorageBseArr[m_index] = objStorageBseArr[i1];
                            }
                            m_objViewer.m_cboStorage.SelectedIndex = 0;
                        }
                        else
                        {
                            m_objViewer.m_cboStorage.Items.Clear();
                        }
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "药房查询提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                int m_index = 0;
                for (int i1 = 0; i1 < objStorageBseArr.Length; i1++)
                {
                    m_index = m_objViewer.m_cboStorage.Items.Add(objStorageBseArr[i1].MEDICINEROOMNAME);
                    m_objStorageBseArr[m_index] = objStorageBseArr[i1];
                }
                m_objViewer.m_cboStorage.SelectedIndex = 0;
            }
        }
        #endregion

        #region 获取药品类型
        /// <summary>
        /// 获取药品类型
        /// </summary>
        internal void m_mthShowMedicineType()
        {
            long lngRes = 0;

            m_objViewer.m_cboMedicineType.Items.Clear();
            if ((m_objViewer.m_cboMedicineType.Items.Count >= 0) && (objMedicineTypeArr == null))
            {
                m_objViewer.m_cboMedicineType.Items.Clear();
                try
                {
                    lngRes = m_objDomain.m_lngGetResultByConditionMedicineType(out objMedicineTypeArr);

                    if (lngRes > 0)
                    {
                        m_objMedicineTypeArr = new clsValue_MedicineType_VO[objMedicineTypeArr.Length + 1];
                        m_objViewer.m_cboMedicineType.Items.Add("所有类型");
                        int m_index = 0;
                        for (int i1 = 0; i1 < objMedicineTypeArr.Length; i1++)
                        {                            
                            m_index = m_objViewer.m_cboMedicineType.Items.Add(objMedicineTypeArr[i1].m_strMedicineTypeName);
                            m_objMedicineTypeArr[m_index] = objMedicineTypeArr[i1];                      
                        }
                        m_objViewer.m_cboMedicineType.SelectedIndex = 0;
                    }
                    else
                    {
                        m_objViewer.m_cboMedicineType.Items.Clear();
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "药房查询提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else if ((m_objViewer.m_cboMedicineType.Items.Count >= 0) && (objMedicineTypeArr != null))
            {
                m_objViewer.m_cboMedicineType.Items.Add("所有类型");
                int m_index = 0;
                for (int i1 = 0; i1 < objMedicineTypeArr.Length; i1++)
                {
                    m_index = m_objViewer.m_cboMedicineType.Items.Add(objMedicineTypeArr[i1].m_strMedicineTypeName);
                    m_objMedicineTypeArr[m_index] = objMedicineTypeArr[i1];                   
                }
                m_objViewer.m_cboMedicineType.SelectedIndex = 0;

            }
            m_objViewer.Text = "药房库存查询(" + m_objViewer.m_cboStorage.Text + ")";
        }
        #endregion

        #region 获取药品明细数据
        /// <summary>
        /// 获取药品明细数据
        /// 实现统计查询和明细查询功能。
        /// 可按药品的助记码、拼音码、五笔码、药品的ID或药品名称进行模糊查询
        /// </summary>
        internal void m_mthQuery()
        {
            if (m_objViewer.m_cboStorage.Text.Trim().Length == 0)
            {
                MessageBox.Show("必须选择药库!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                m_value_Param.m_strStorageName = m_objViewer.m_cboStorage.SelectItemText;

            if (m_objViewer.m_datBeginDate.Text.Trim().Length < 11)
                m_objViewer.m_datBeginDate.Text = "";
            if (m_objViewer.m_datEndDate.Text.Trim().Length < 11)
                m_objViewer.m_datEndDate.Text = "";

            if (this.m_objViewer.m_chkValidDate.Checked&&(m_objViewer.m_datBeginDate.Text.Trim().Length == 11) && (m_objViewer.m_datEndDate.Text.Trim().Length == 11))
            {
                if ((Convert.ToDateTime(m_objViewer.m_datBeginDate.Text)) > (Convert.ToDateTime(m_objViewer.m_datEndDate.Text)))
                {
                    DialogResult tmpResult = MessageBox.Show("失效开始日期必须小于失效结束日期！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    m_objViewer.m_datBeginDate.Focus();
                    return;
                }
            }

            long lngRes = 0;
            List<string> lstMedicineType = new List<string>();

            m_value_Param.m_strStorageID = "";
            m_value_Param.m_strMedicineTypeID = "";
            m_value_Param.m_strMedicineID = "";
            m_value_Param.m_strValidBeginDate = "";
            m_value_Param.m_strValidEndDate = "";
            m_value_Param.m_strAssistCode = "";
            m_value_Param.m_blnZeroGross = false;

            m_objViewer.m_dgvDrugStorage.DataSource = null;
            m_objViewer.intRecordCount = 0;
            m_objViewer.displayRecordNo();

            if (dtbResult != null)
            {
                dtbResult.Clear();
                dtbResult.Dispose();
                dtbResult = null;
            }

            
            m_objDomain.m_lngCheckIsHospital(m_objViewer.m_cboStorage.SelectItemValue, out m_blnIsHospital);


            m_objViewer.m_mthInitDataTable(m_blnIsHospital);
            m_value_Param.m_strStorageID = m_objViewer.m_cboStorage.SelectItemValue;
            if (this.m_objViewer.m_chkValidDate.Checked&&m_objViewer.m_datBeginDate.Text.Trim().Length == 11)
            {
                string strDate = m_objViewer.m_datBeginDate.Text;
                m_value_Param.m_strValidBeginDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd");
            }
            if (this.m_objViewer.m_chkValidDate.Checked&&m_objViewer.m_datEndDate.Text.Trim().Length == 11)
            {
                string strDate = m_objViewer.m_datEndDate.Text;
                m_value_Param.m_strValidEndDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd");
            }

            if (m_objViewer.m_txtMedicineCode.Text.Trim().Length > 0)
            {
                if (m_objViewer.m_objMedicineBase.m_strMedicineID.Trim().Length > 0)
                    m_value_Param.m_strMedicineID = m_objViewer.m_objMedicineBase.m_strMedicineID.Trim();
                else
                {
                    m_value_Param.m_strAssistCode = m_objViewer.m_txtMedicineCode.Text + @"%";
                }
            }
            else
            {
                m_value_Param.m_strAssistCode = "";
            }

            //药品类型
            if ((m_objViewer.m_cboMedicineType.Text.Trim().Length > 0) && (m_objViewer.m_cboMedicineType.Text.Trim() != "所有类型"))
            {                
               lstMedicineType.Add(objMedicineTypeArr[m_objViewer.m_cboMedicineType.SelectedIndex-1].m_strMedicineTypeID); 
            }
            else
                m_value_Param.m_strMedicineTypeID = "";

            m_value_Param.m_blnZeroGross = true;// radZeroStorage.Checked;
            dtbResult = new DataTable();//数据库返回的结果集
            //com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objTypeVO = m_objViewer.m_cboMediciePreptype.SelectedItem as com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO;
            com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[] objTypeVOArr = new com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[m_objViewer.m_lsbMediciePreptype.SelectedItems.Count];
            for (int i1 = 0; i1 < m_objViewer.m_lsbMediciePreptype.SelectedItems.Count; i1++)
            {
                objTypeVOArr[i1] = (com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO)m_objViewer.m_lsbMediciePreptype.SelectedItems[i1];
            }

            lngRes = m_mthGetStorageDetailData(ref m_value_Param, out dtbResult, ref m_objStatValue, lstMedicineType, m_objViewer.m_rdbTotal.Checked, m_objViewer.m_txtProductor.Text.Trim(), objTypeVOArr);
            if ((lngRes > 0) && (dtbResult != null))
            {
                m_objViewer.m_dgvDrugStorage.DataSource = dtbResult;
                m_objViewer.intRecordCount = dtbResult.Rows.Count;
                m_objViewer.displayRecordNo();

                m_objViewer.m_lblCallSum.Text = m_objStatValue.m_decCallSumTotal.ToString("#,##0.0000");//购入金额
                m_objViewer.m_lblRetailSum.Text = m_objStatValue.m_decRetailSumTotal.ToString("#,##0.0000");//零售金额
                //m_objViewer.m_lblWholesaleSum.Text = m_objStatValue.m_decWholesaleSumTotal.ToString("#,##0.00");//批发金额
            }

            string strFilter = string.Empty;
            if (m_objViewer.m_rdbNotZero.Checked)
            {
                if (dtbResult.Rows.Count > 0)
                {
                    strFilter = "realgross_int <> 0";
                    if (m_objViewer.m_rbtCanProvide.Checked)
                    {
                        strFilter += " and canprovide_int = 1";
                    }
                    else if (m_objViewer.m_rbtNotProvide.Checked)
                    {
                        strFilter += " and canprovide_int = 0";
                    }

                    DataRow[] rows = dtbResult.Select(strFilter);
                    dtbTem = dtbResult.Clone();
                    for (int intRow = 0; intRow < rows.Length; intRow++)
                    {
                        dtbTem.Rows.Add(rows[intRow].ItemArray);
                    }
                    m_objViewer.m_dgvDrugStorage.DataSource = dtbTem;
                    m_objViewer.intRecordCount = dtbTem.Rows.Count;
                    m_objViewer.displayRecordNo();
                }
                else
                {
                    dtbTem = dtbResult.Copy();
                    m_objViewer.m_dgvDrugStorage.DataSource = dtbTem;
                    m_objViewer.intRecordCount = dtbTem.Rows.Count;
                    m_objViewer.displayRecordNo();
                }
            }
            else
            {
                if (dtbResult.Rows.Count > 0)
                {                    
                    if (m_objViewer.m_rdbZero.Checked)
                    {
                        strFilter = "realgross_int = 0";
                    }
                    else if(m_objViewer.m_rbtNegative.Checked)
                    {
                        strFilter = "realgross_int < 0";
                    }

                    if (m_objViewer.m_rbtCanProvide.Checked)
                    {
                        if (strFilter.Length == 0)
                            strFilter += "canprovide_int = 1";
                        else
                            strFilter += " and canprovide_int = 1";
                    }
                    else if (m_objViewer.m_rbtNotProvide.Checked)
                    {
                        if (strFilter.Length == 0)
                            strFilter += "canprovide_int = 0";
                        else
                            strFilter += " and canprovide_int = 0";
                    }

                    DataRow[] rows = dtbResult.Select(strFilter);                  
                    dtbTem = dtbResult.Clone();
                    for (int intRow = 0; intRow < rows.Length; intRow++)
                    {
                        dtbTem.Rows.Add(rows[intRow].ItemArray);
                    }
                    m_objViewer.m_dgvDrugStorage.DataSource = dtbTem;
                    m_objViewer.intRecordCount = dtbTem.Rows.Count;
                    m_objViewer.displayRecordNo();
                }
                else
                {
                    dtbTem = dtbResult.Copy();
                    m_objViewer.m_dgvDrugStorage.DataSource = dtbTem;
                    m_objViewer.intRecordCount = dtbTem.Rows.Count;
                    m_objViewer.displayRecordNo();
                }
            }

            m_objViewer.m_dtbAmount.Rows.Clear();
            m_objViewer.m_dtbAmount = dtbResult.Clone();
        }
        #endregion
        
        #region 获取库存明细数据
        /// <summary>
        /// 获取库存明细数据
        /// </summary>
        /// <param name="objvalue_Param">查询条件</param>
        /// <param name="dtbResult">返回的结果集</param>
        /// <param name="m_objStatValue">统计数据</param>
        /// <param name="lstMedicineType"></param>
        /// <param name="blnQueryFlag">查询标志</param>
        /// <param name="p_strProductor">生产厂家</param>
        /// <param name="p_objPrepTypeArr">剂型</param>
        /// <returns></returns>
        public long m_mthGetStorageDetailData(ref clsStorageDetail_SqlConditionQueryParam_VO objvalue_Param, out DataTable dtbResult, ref clsStorageDetail_Stat_VO m_objStatValue, List<string> lstMedicineType, bool blnQueryFlag,string p_strProductor,clsMEDICINEPREPTYPE_VO[] p_objPrepTypeArr)
        {
            long lngRes = 0;
            try
            {
                m_objStatValue.m_decCallSumTotal = 0;
                m_objStatValue.m_decRetailSumTotal = 0;
                m_objStatValue.m_decWholesaleSumTotal = 0;

                DataTable Query_dtbResult = new DataTable();//数据库返回的结果集

                lngRes = m_objDomain.m_lngGetResultByConditionStorageDetail(ref objvalue_Param, lstMedicineType, ref Query_dtbResult, p_strProductor, p_objPrepTypeArr);
                
                if (lngRes > 0)
                {
                    DataColumn[] dcPrimaryKeyArr = new DataColumn[1];
                    dcPrimaryKeyArr[0] = Query_dtbResult.Columns["seriesid_int"];
                    Query_dtbResult.PrimaryKey = dcPrimaryKeyArr;
                    //DataColumn[] dcPrimaryKeyArr = new DataColumn[1];
                    //DataColumn dcPrimaryKey = new DataColumn();
                    //dcPrimaryKey.DataType = System.Type.GetType("System.Int64");
                    //dcPrimaryKey.ColumnName = "seriesid_int";

                    DataTable Stat_dtbResult = new DataTable();//处理后生成的统计表

                    DataRow[] drArr = null;
                    //统计查询
                    if (blnQueryFlag == true)
                    {
                        m_GroupSum(objvalue_Param.m_strStorageName, ref Query_dtbResult, ref Stat_dtbResult, ref m_objStatValue);
                        drArr=Stat_dtbResult.Select("","assistcode_chr");//,DataViewRowState.CurrentRows,lotno_vchr"
                        dtbResult = Stat_dtbResult.Clone();
                        for(int i1 = 0;i1< drArr.Length;i1++)
                        {
                            dtbResult.Rows.Add(drArr[i1].ItemArray);
                        }
                        Query_dtbResult = null;
                    }
                    else//明细查询
                    {
                        m_DetailQuery(objvalue_Param.m_strStorageName, ref Query_dtbResult, ref m_objStatValue);
                        drArr = Query_dtbResult.Select("", "assistcode_chr,lotno_vchr");
                        Query_dtbResult.PrimaryKey = null;
                        dtbResult = Query_dtbResult.Clone();
                        for (int i1 = 0; i1 < drArr.Length; i1++)
                        {
                            dtbResult.Rows.Add(drArr[i1].ItemArray);
                        }
                        //dtbResult = Query_dtbResult;
                    }
                    dtbResult.AcceptChanges();
                }
                else
                    dtbResult = null;

                return lngRes;
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "药房查询提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            dtbResult = null;
            return lngRes;

        }
        #endregion

        #region 明细查询函数
        /// <summary>
        /// 明细查询函数
        /// </summary>
        /// <param name="strMedicineStorageName">药房</param>
        /// <param name="Query_dtbResult">初始的结果集</param>
        /// <param name="m_objStatValue">处理后的统计表</param>
        private void m_DetailQuery(string strMedicineStorageName, ref DataTable Query_dtbResult, ref clsStorageDetail_Stat_VO m_objStatValue)
        {
            DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEROOMNAME"), new DataColumn("retailsum", typeof(double)), new DataColumn("wholesalesum", typeof(double)) };
            Query_dtbResult.Columns.AddRange(drColumns);

            decimal m_decDBRealGross = 0;//结果集记录中的实际库存
            decimal m_decRetailPrice = 0;//结果中的零售单价
            decimal m_decWholesalePrice = 0;//结果中的购入单价
            decimal m_decWholesaleSum = 0;//统计表中的购入金额
            decimal m_decRetailSum = 0;//统计表中的零售金额
            decimal m_decPackQty = 1;//包装单位
            DataRow m_dtbResultRow = null;

            m_objStatValue.m_decCallSumTotal = 0;
            m_objStatValue.m_decRetailSumTotal = 0;
            m_objStatValue.m_decWholesaleSumTotal = 0;

            for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
            {
                m_dtbResultRow = Query_dtbResult.Rows[i1];

                decimal.TryParse(m_dtbResultRow["IPREALGROSS_INT"].ToString(), out m_decDBRealGross);
                decimal.TryParse(m_dtbResultRow["opretailprice_int"].ToString(), out m_decRetailPrice);
                decimal.TryParse(m_dtbResultRow["opwholesaleprice_int"].ToString(), out m_decWholesalePrice);
                decimal.TryParse(m_dtbResultRow["packqty_dec"].ToString(), out m_decPackQty);
                if (m_decPackQty == 0) m_decPackQty = 1;

                m_decWholesaleSum = m_decDBRealGross * m_decWholesalePrice / m_decPackQty;
                m_decRetailSum = m_decDBRealGross * m_decRetailPrice / m_decPackQty;

                m_dtbResultRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                m_dtbResultRow["retailsum"] = m_decRetailSum;
                m_dtbResultRow["wholesalesum"] = m_decWholesaleSum;

                m_objStatValue.m_decCallSumTotal += m_decWholesaleSum;
                m_objStatValue.m_decRetailSumTotal += m_decRetailSum;

                m_dtbResultRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                m_dtbResultRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();
            }
        }
        #endregion

        #region 分组统计函数
        /// <summary>
        /// 分组统计数据
        /// 根据药品ID（MEDICINEID_CHR）进行分组统计，药品ID相同的记录归为一组。
        /// 对每组的“实际库存”、“可用库存”、“购入金额”、“零售金额”、“批发金额”进行求和计算。
        /// 将每组的统计数据写入最终的统计表。统计表中“购入单价”、“零售单价”、“批发单价”采用平均价格。
        /// </summary>
        /// <param name="dtbResult">初始的结果集</param>
        /// <param name="tmp_dtbResult">处理后的统计表</param>
        private void m_GroupSum(string strMedicineStorageName, ref DataTable dtbResult, ref DataTable tmp_dtbResult, ref clsStorageDetail_Stat_VO m_objStatValue)
        {
            DataRow m_newRow = null, m_dtbResultRow = null;

            int i1;
            string m_strMedicineID = string.Empty;//用于分组的药品ID
            string m_strDBMedicineID = string.Empty;//结果集中被筛选的药品ID
            decimal m_decRealGrossSum = 0;//每组的实际库存合计
            decimal m_decAvailGrossSum = 0;//每组的可用库存合计
            decimal m_decDBRealGross = 0;//结果集记录中的实际库存
            decimal m_decDBAvailGross = 0;//结果集记录中的可用库存
            decimal m_decEndamount = 0;
            decimal m_decCallSum = 0;//统计表中的购入金额
            decimal m_decRetailSum = 0;//统计表中的零售金额
            decimal m_decWholesaleSum = 0;//统计表中的批发金额
            decimal m_decCallPrice = 0;//统计表中的购入平均单价
            decimal m_decRetailPrice = 0;//统计表中的零售平均单价
            decimal m_decWholesalePrice = 0;//统计表中的批发平均单价
            decimal m_decPackQty = 1;//包装单位
            decimal m_decIPRealGrossSum = 0;//每组的最小实际库存合计
            decimal m_decIPAvailGrossSum = 0;//每组的最小可用库存合计
            decimal m_decDBIPRealGross = 0;//结果集记录中的最小实际库存
            decimal m_decDBIPAvailGross = 0;//结果集记录中的最小可用库存
            decimal m_decRealGross = 0;//门诊实际量
            decimal m_decAvailGross = 0;//门诊可用量
            decimal m_decDBRealGrossSum = 0;//基本单位实际量
            decimal m_decDBAvailGrossSum = 0;//基本单位可用量
            m_objStatValue.m_decCallSumTotal = 0;
            m_objStatValue.m_decRetailSumTotal = 0;
            m_objStatValue.m_decWholesaleSumTotal = 0;

            if (dtbResult.Rows.Count <= 1)
            {
                tmp_dtbResult = dtbResult.Copy();
                tmp_dtbResult.PrimaryKey = null;
                DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEROOMNAME"), new DataColumn("WHOLESALESUM", typeof(double)), new DataColumn("retailsum", typeof(double)) };
                tmp_dtbResult.Columns.AddRange(drColumns);

                if (dtbResult.Rows.Count == 1)
                {
                    m_dtbResultRow = tmp_dtbResult.Rows[0];

                    decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decRealGross);
                    decimal.TryParse(m_dtbResultRow["AVAILAGROSS_INT"].ToString(), out m_decAvailGross);
                    decimal.TryParse(m_dtbResultRow["OPREALGROSS_INT"].ToString(), out m_decDBRealGross);
                    decimal.TryParse(m_dtbResultRow["OPAVAILAGROSS_INT"].ToString(), out m_decDBAvailGross);
                    decimal.TryParse(m_dtbResultRow["IPREALGROSS_INT"].ToString(), out m_decDBIPRealGross);
                    decimal.TryParse(m_dtbResultRow["IPAVAILAGROSS_INT"].ToString(), out m_decDBIPAvailGross);
                    decimal.TryParse(m_dtbResultRow["packqty_dec"].ToString(), out m_decPackQty);
                    if (m_decPackQty == 0) m_decPackQty = 1;
                    decimal.TryParse(m_dtbResultRow["opretailprice_int"].ToString(), out m_decRetailPrice);
                    decimal.TryParse(m_dtbResultRow["opwholesaleprice_int"].ToString(), out m_decWholesalePrice);

                    m_decCallSum = m_decDBIPRealGross * m_decWholesalePrice / m_decPackQty;
                    m_decRetailSum = m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;

                    m_dtbResultRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                    m_dtbResultRow["WHOLESALESUM"] = m_decCallSum;
                    m_dtbResultRow["retailsum"] = m_decRetailSum;

                    m_objStatValue.m_decCallSumTotal += m_decCallSum;
                    m_objStatValue.m_decRetailSumTotal += m_decRetailSum;

                    m_dtbResultRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                    m_dtbResultRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();
                }
            }
            else if (dtbResult.Rows.Count > 1)
            {
                tmp_dtbResult = dtbResult.Clone();
                tmp_dtbResult.PrimaryKey = null;

                DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEROOMNAME"), new DataColumn("retailsum", typeof(double)), new DataColumn("wholesalesum", typeof(double)) };
                tmp_dtbResult.Columns.AddRange(drColumns);

                m_dtbResultRow = dtbResult.Rows[0];

                m_strMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString().Trim();
                decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decRealGross);
                decimal.TryParse(m_dtbResultRow["AVAILAGROSS_INT"].ToString(), out m_decAvailGross);
                decimal.TryParse(m_dtbResultRow["OPREALGROSS_INT"].ToString(), out m_decDBRealGross);
                decimal.TryParse(m_dtbResultRow["OPAVAILAGROSS_INT"].ToString(), out m_decDBAvailGross);
                decimal.TryParse(m_dtbResultRow["IPREALGROSS_INT"].ToString(), out m_decDBIPRealGross);
                decimal.TryParse(m_dtbResultRow["IPAVAILAGROSS_INT"].ToString(), out m_decDBIPAvailGross);
                decimal.TryParse(m_dtbResultRow["packqty_dec"].ToString(), out m_decPackQty);
                if (m_decPackQty == 0) m_decPackQty = 1;
                decimal.TryParse(m_dtbResultRow["opretailprice_int"].ToString(), out m_decRetailPrice);
                decimal.TryParse(m_dtbResultRow["opwholesaleprice_int"].ToString(), out m_decWholesalePrice);

                m_decRealGrossSum = m_decRealGross;
                m_decAvailGrossSum = m_decAvailGross;
                m_decDBRealGrossSum = m_decDBRealGross;
                m_decDBAvailGrossSum = m_decDBAvailGross;
                m_decIPRealGrossSum = m_decDBIPRealGross;
                m_decIPAvailGrossSum = m_decDBIPAvailGross;

                m_decCallSum = m_decDBIPRealGross * m_decWholesalePrice / m_decPackQty;
                m_decRetailSum = m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;

                m_objStatValue.m_decCallSumTotal += m_decCallSum;
                m_objStatValue.m_decRetailSumTotal += m_decRetailSum;

                m_dtbResultRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                m_dtbResultRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();

                decimal dcmEndAmountTemp = 0m;
                for (i1 = 1; i1 < dtbResult.Rows.Count; i1++)
                {//汇总
                    m_dtbResultRow = dtbResult.Rows[i1];

                    //小计
                    m_strDBMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString().Trim();

                    decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decRealGross);
                    decimal.TryParse(m_dtbResultRow["AVAILAGROSS_INT"].ToString(), out m_decAvailGross);
                    decimal.TryParse(m_dtbResultRow["OPREALGROSS_INT"].ToString(), out m_decDBRealGross);
                    decimal.TryParse(m_dtbResultRow["OPAVAILAGROSS_INT"].ToString(), out m_decDBAvailGross);
                    decimal.TryParse(m_dtbResultRow["IPREALGROSS_INT"].ToString(), out m_decDBIPRealGross);
                    decimal.TryParse(m_dtbResultRow["IPAVAILAGROSS_INT"].ToString(), out m_decDBIPAvailGross);
                    decimal.TryParse(m_dtbResultRow["packqty_dec"].ToString(), out m_decPackQty);
                    if (m_decPackQty == 0) m_decPackQty = 1;
                    decimal.TryParse(m_dtbResultRow["opretailprice_int"].ToString(), out m_decRetailPrice);
                    decimal.TryParse(m_dtbResultRow["opwholesaleprice_int"].ToString(), out m_decWholesalePrice);

                    //计算最终的合计金额
                    m_objStatValue.m_decCallSumTotal += m_decDBIPRealGross * m_decWholesalePrice / m_decPackQty;
                    m_objStatValue.m_decRetailSumTotal += m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;

                    if (m_strMedicineID == m_strDBMedicineID)
                    {
                        m_decRealGrossSum += m_decRealGross;
                        m_decAvailGrossSum += m_decAvailGross;
                        m_decDBRealGrossSum += m_decDBRealGross;
                        m_decDBAvailGrossSum += m_decDBAvailGross;
                        m_decIPRealGrossSum += m_decDBIPRealGross;
                        m_decIPAvailGrossSum += m_decDBIPAvailGross;
                        m_decCallSum += m_decDBIPRealGross * m_decCallPrice / m_decPackQty;
                        m_decRetailSum += m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;
                    }//小计
                    else
                    {
                        m_dtbResultRow = dtbResult.Rows[i1 - 1];

                        m_newRow = tmp_dtbResult.NewRow();

                        m_newRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                        m_newRow["ASSISTCODE_CHR"] = m_dtbResultRow["ASSISTCODE_CHR"];//助记码
                        m_newRow["MEDICINENAME_VCHR"] = m_dtbResultRow["MEDICINENAME_VCHR"];//药品名称
                        m_newRow["MEDSPEC_VCHR"] = m_dtbResultRow["MEDSPEC_VCHR"];//规格
                        m_newRow["LOTNO_VCHR"] = m_dtbResultRow["LOTNO_VCHR"];//批号
                        m_newRow["MEDICINETYPENAME_VCHR"] = m_dtbResultRow["MEDICINETYPENAME_VCHR"];//药品类型名称
                        m_newRow["REALGROSS_INT"] = m_decRealGrossSum;//实际库存
                        m_newRow["AVAILAGROSS_INT"] = m_decAvailGrossSum;//可用库存
                        m_newRow["OPREALGROSS_INT"] = m_decDBRealGrossSum;//基本实际库存
                        m_newRow["OPAVAILAGROSS_INT"] = m_decDBAvailGrossSum;//基本可用库存
                        m_newRow["IPREALGROSS_INT"] = m_decIPRealGrossSum;//最小实际库存
                        m_newRow["IPAVAILAGROSS_INT"] = m_decIPAvailGrossSum;//最小可用库存                        
                        m_newRow["storagerackid_chr"] = m_dtbResultRow["storagerackid_chr"];//货架
                        m_newRow["unit_chr"] = m_dtbResultRow["unit_chr"].ToString().Trim();
                        m_newRow["ifstop_int"] = m_dtbResultRow["ifstop_int"];
                        m_newRow["noqtyflag_int"] = m_dtbResultRow["noqtyflag_int"];
                        m_newRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                        m_newRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();
                        m_newRow["productorid_chr"] = m_dtbResultRow["productorid_chr"];
                        m_newRow["pycode_chr"] = m_dtbResultRow["pycode_chr"];
                        m_newRow["wbcode_chr"] = m_dtbResultRow["wbcode_chr"];

                        /*if (m_decIPRealGrossSum == 0)
                            m_newRow["RETAILPRICE_INT"] = 0;//零售单价
                        else
                            m_newRow["RETAILPRICE_INT"] = m_decRetailSum / m_decIPRealGrossSum;//零售单价

                        if (m_decIPRealGrossSum == 0)
                            m_newRow["WHOLESALEPRICE_INT"] = 0;//购入单价
                        else
                            m_newRow["WHOLESALEPRICE_INT"] = m_decCallSum / m_decIPRealGrossSum;//购入单价
                        */
                        m_newRow["RETAILPRICE_INT"] = m_dtbResultRow["retailprice_int"];
                        m_newRow["WHOLESALEPRICE_INT"] = m_dtbResultRow["wholesaleprice_int"];

                        m_newRow["WHOLESALESUM"] = m_decCallSum;//购入金额
                        m_newRow["RETAILSUM"] = m_decRetailSum;//零售金额
                        m_newRow["VALIDPERIOD_DAT"] = m_dtbResultRow["VALIDPERIOD_DAT"];//失效日期
                        m_newRow["MEDICINEPREPTYPENAME_VCHR"] = m_dtbResultRow["MEDICINEPREPTYPENAME_VCHR"];//药品剂型
                        m_newRow["seriesid_int"] = m_dtbResultRow["seriesid_int"];
                        
                        //增加新行
                        tmp_dtbResult.Rows.Add(m_newRow);
                        m_newRow.AcceptChanges();

                        m_dtbResultRow = dtbResult.Rows[i1];

                        m_strMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString();
                        //重置m_decRealGrossSum、m_decAvailGrossSum、
                        m_decRealGrossSum = m_decRealGross;
                        m_decAvailGrossSum = m_decAvailGross;
                        m_decDBRealGrossSum = m_decDBRealGross;
                        m_decDBAvailGrossSum = m_decDBAvailGross;
                        m_decIPRealGrossSum = m_decDBIPRealGross;
                        m_decIPAvailGrossSum = m_decDBIPAvailGross;

                        m_decCallSum = m_decDBIPRealGross * m_decWholesalePrice / m_decPackQty;
                        m_decRetailSum = m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;

                        m_decEndamount = dcmEndAmountTemp;

                    }//else
                    //处理最后一条记录
                    if (i1 == dtbResult.Rows.Count - 1)
                    {
                        m_dtbResultRow = dtbResult.Rows[i1];

                        m_newRow = tmp_dtbResult.NewRow();

                        m_newRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                        m_newRow["ASSISTCODE_CHR"] = m_dtbResultRow["ASSISTCODE_CHR"];//助记码
                        m_newRow["MEDICINENAME_VCHR"] = m_dtbResultRow["MEDICINENAME_VCHR"];//药品名称
                        m_newRow["MEDSPEC_VCHR"] = m_dtbResultRow["MEDSPEC_VCHR"];//规格
                        m_newRow["LOTNO_VCHR"] = m_dtbResultRow["LOTNO_VCHR"];//批号
                        m_newRow["MEDICINETYPENAME_VCHR"] = m_dtbResultRow["MEDICINETYPENAME_VCHR"];//药品类型名称
                        m_newRow["REALGROSS_INT"] = m_decRealGrossSum;//实际库存
                        m_newRow["AVAILAGROSS_INT"] = m_decAvailGrossSum;//可用库存
                        m_newRow["OPREALGROSS_INT"] = m_decDBRealGrossSum;//基本实际库存
                        m_newRow["OPAVAILAGROSS_INT"] = m_decDBAvailGrossSum;//基本可用库存
                        m_newRow["IPREALGROSS_INT"] = m_decIPRealGrossSum;//最小实际库存
                        m_newRow["IPAVAILAGROSS_INT"] = m_decIPAvailGrossSum;//最小可用库存
                        m_newRow["storagerackid_chr"] = m_dtbResultRow["storagerackid_chr"];//货架
                        m_newRow["unit_chr"] = m_dtbResultRow["unit_chr"].ToString().Trim();
                        m_newRow["ifstop_int"] = m_dtbResultRow["ifstop_int"];
                        m_newRow["noqtyflag_int"] = m_dtbResultRow["noqtyflag_int"];
                        m_newRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                        m_newRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();
                        m_newRow["productorid_chr"] = m_dtbResultRow["productorid_chr"];
                        m_newRow["pycode_chr"] = m_dtbResultRow["pycode_chr"];
                        m_newRow["wbcode_chr"] = m_dtbResultRow["wbcode_chr"];

                        /*if (m_decIPRealGrossSum == 0)
                            m_newRow["RETAILPRICE_INT"] = 0;//零售单价
                        else
                            m_newRow["RETAILPRICE_INT"] = m_decRetailSum / m_decIPRealGrossSum;//零售单价

                        if (m_decRealGrossSum == 0)
                            m_newRow["WHOLESALEPRICE_INT"] = 0;//购入单价
                        else
                            m_newRow["WHOLESALEPRICE_INT"] = m_decCallSum / m_decIPRealGrossSum;//购入单价
                        */
                        m_newRow["RETAILPRICE_INT"] = m_dtbResultRow["retailprice_int"];
                        m_newRow["WHOLESALEPRICE_INT"] = m_dtbResultRow["wholesaleprice_int"];

                        m_newRow["WHOLESALESUM"] = m_decCallSum;//购入金额
                        m_newRow["RETAILSUM"] = m_decRetailSum;//零售金额
                        m_newRow["VALIDPERIOD_DAT"] = m_dtbResultRow["VALIDPERIOD_DAT"];//失效日期
                        m_newRow["MEDICINEPREPTYPENAME_VCHR"] = m_dtbResultRow["MEDICINEPREPTYPENAME_VCHR"];//药品剂型
                        m_newRow["seriesid_int"] = m_dtbResultRow["seriesid_int"];
                        //增加新行
                        tmp_dtbResult.Rows.Add(m_newRow);
                        m_newRow.AcceptChanges();
                    }
                }
            }
        }
        #endregion

        #region 从网格导出数据到Excel
        /// <summary>
        /// 从网格导出数据到Excel
        /// </summary>
        internal void m_mthExportToExcel()
        {
            DataTable dtExport = new DataTable("dtExoprt");

            string strColName = "";
            int intSame = 1;
            for (int i = 0; i < m_objViewer.m_dgvDrugStorage.Columns.Count; i++)
            {               
                if (m_objViewer.m_dgvDrugStorage.Columns[i].Visible == false)
                {
                    continue;
                }

                strColName = m_objViewer.m_dgvDrugStorage.Columns[i].HeaderText.Replace("(", "").Replace(")", "").Replace(".", "").Replace("\n","").Trim();
               
                //防止重名（如有多列重名，可将此处理过程改为递归）
                if (dtExport.Columns.Contains(strColName))
                {
                    strColName = strColName + intSame.ToString();
                    intSame++;
                }

                if (m_objViewer.m_dgvDrugStorage.Columns[i].ValueType == null)
                {
                    dtExport.Columns.Add(strColName, typeof(string));
                }
                else if (m_objViewer.m_dgvDrugStorage.Columns[i].ValueType.FullName.ToLower() == "system.numeric" || m_objViewer.m_dgvDrugStorage.Columns[i].ValueType.FullName.ToLower() == "system.decimal")
                {
                    dtExport.Columns.Add(strColName, typeof(decimal));
                }
                else
                {
                    dtExport.Columns.Add(strColName, typeof(string));
                }
            }

            DataRow dr;
            for (int i = 0; i < m_objViewer.m_dgvDrugStorage.Rows.Count; i++)
            {
                dr = dtExport.NewRow();

                int row = 0;
                for (int j = 0; j < m_objViewer.m_dgvDrugStorage.Columns.Count; j++)
                {                   
                    if (m_objViewer.m_dgvDrugStorage.Columns[j].Visible == false)
                    {
                        continue;
                    }
                    if (j == 6)
                    {
                        dr[row] = m_objViewer.m_dgvDrugStorage.Rows[i].Cells[j].FormattedValue;
                    }
                    else
                    {
                        dr[row] = m_objViewer.m_dgvDrugStorage.Rows[i].Cells[j].Value;
                    }
                    row++;
                }

                dtExport.Rows.Add(dr);
            }

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add(dtExport);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel files (*.xls)|*.xls";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            bool b = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                b = m_mthExport(dsExport, dialog.FileName);
            }

            if (b)
            {
                MessageBox.Show("导出Excel成功！", "药品库存查询记录", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("导出Excel失败。", "药品库存查询记录", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            dtExport.Dispose();
            dsExport.Tables.Clear();
            dsExport.Dispose();
            #region OldCode
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            //saveFileDialog.FilterIndex = 0;
            //saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.CreatePrompt = true;
            //saveFileDialog.Title = "导出Excel文件到";
            //if (saveFileDialog.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
            //Stream myStream;
            //myStream = saveFileDialog.OpenFile();
            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            //string str = "";
            //try
            //{
            //    //添加列标题
            //    for (int iOr = 0; iOr < m_objViewer.m_dgvDrugStorage.ColumnCount; iOr++)
            //    {
            //        if (iOr > 0)
            //        {
            //            str += "\t";
            //        }
            //        str += m_objViewer.m_dgvDrugStorage.Columns[iOr].HeaderText.Replace("\n","");
            //    }
            //    sw.WriteLine(str);
            //    //添加行文本
            //    StringBuilder objStrBuilder = null;                
            //    for (int iOr = 0; iOr < m_objViewer.m_dgvDrugStorage.Rows.Count; iOr++)
            //    {
            //        objStrBuilder = new StringBuilder();
            //        for (int jOr = 0; jOr < m_objViewer.m_dgvDrugStorage.Columns.Count; jOr++)
            //        {
            //            if (jOr > 0)
            //            {
            //                objStrBuilder.Append("\t");
            //            }
            //            if (jOr == 6)
            //            {                            
            //                objStrBuilder.Append(m_objViewer.m_dgvDrugStorage.Rows[iOr].Cells[jOr].FormattedValue.ToString());
            //            }
            //            else
            //                objStrBuilder.Append(m_objViewer.m_dgvDrugStorage.Rows[iOr].Cells[jOr].Value.ToString());
            //        }
            //        sw.WriteLine(objStrBuilder);
            //    }
            //    MessageBox.Show("导出成功！", "药品库存查询记录", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    sw.Close();
            //    myStream.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    sw.Close();
            //    myStream.Close();
            //}
            #endregion
        }

        /// <summary>
        /// 写入Excel
        /// </summary>
        /// <param name="dsSource"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool m_mthExport(DataSet dsSource, string fileName)
        {
            if ((fileName == null) || (fileName == ""))
            {
                return false;
            }
            if (!fileName.EndsWith(".xls"))
            {
                fileName = fileName + ".xls";
            }
            if (dsSource == null)
            {
                return false;
            }
            if (dsSource.Tables.Count < 1)
            {
                MessageBox.Show("数据源没有任何表!");
                return false;
            }
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("文件无法写入!\n\n" + exception.ToString());
                    return true;
                }
            }

            string provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;";
            OleDbConnection connection = new OleDbConnection(string.Format(provider, fileName));
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            connection.Open();
            string format = "Create Table {0} ({1})";
            string str2 = "Insert Into {0} ({1}) values({2})";
            foreach (DataTable table in dsSource.Tables)
            {
                string str4;
                string str5;
                string str3 = str4 = str5 = "";
                foreach (DataColumn column in table.Columns)
                {
                    if (column.DataType == Type.GetType("System.String"))
                    {
                        str3 = str3 + column.ColumnName + " varchar,";
                    }
                    else if (column.DataType == Type.GetType("System.DateTime"))
                    {
                        str3 = str3 + column.ColumnName + " datetime,";
                    }
                    else
                    {
                        str3 = str3 + column.ColumnName + " number,";
                    }
                    str4 = str4 + column.ColumnName + ",";
                    str5 = str5 + "@" + column.ColumnName + ",";
                }
                if (str3.EndsWith(","))
                {
                    str3 = str3.TrimEnd(new char[] { ',' });
                    str4 = str4.Trim(new char[] { ',' });
                    str5 = str5.TrimEnd(new char[] { ',' });
                }
                command.CommandText = string.Format(format, table.TableName, str3);
                command.ExecuteNonQuery();
                command.CommandText = string.Format(str2, table.TableName, str4, str5);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    command.Parameters.Clear();
                    foreach (DataColumn column in table.Columns)
                    {
                        command.Parameters.AddWithValue("@" + column.ColumnName, table.Rows[i][column]);
                    }
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
            return true;
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        internal void m_mthPrint()
        {
            if (dtbTem == null || dtbTem.Rows.Count <= 0)
            {
                MessageBox.Show("没有可打印数据！", "库存查询", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (m_objViewer.m_rdbDetail.Checked)
            {
                DataWindowControl m_dwcDrugQuery = new DataWindowControl();
                m_dwcDrugQuery.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
                //if(m_objViewer.m_rdbTotal.Checked)
                //    m_dwcDrugQuery.DataWindowObject = "d_op_drugquerytotal";
                //else
                m_dwcDrugQuery.DataWindowObject = "d_op_drugquerydetail";


                m_dwcDrugQuery.SetRedrawOff();
                //DataTable dtbPrint = ((DataTable)m_objViewer.m_dgvDrugStorage.DataSource).Copy();
                DataTable dtbPrint = ((DataTable)m_objViewer.m_dgvDrugStorage.DataSource).Clone();
                DataRowView drv = null;
                for (int intRow = 0; intRow < this.m_objViewer.m_dgvDrugStorage.Rows.Count;intRow++ )
                {
                    drv = this.m_objViewer.m_dgvDrugStorage.Rows[intRow].DataBoundItem as DataRowView;
                    dtbPrint.Rows.Add(drv .Row.ItemArray);

                }

                DataTable dtbTemp = new DataTable();
                DataColumn[] dcColumns = new DataColumn[] { new DataColumn("medicineid_chr"), new DataColumn("assistcode_chr"), new DataColumn("medicinename_vchr"),new DataColumn("medspec_vchr"), new DataColumn("lotno_vchr"),
                new DataColumn("medicinetypename_vchr"),new DataColumn("realgross_int",typeof(double)),new DataColumn("availagross_int",typeof(double)),new DataColumn("opunit_chr"),new DataColumn("retailprice_int",typeof(double)),new DataColumn("wholesaleprice_int",
                typeof(double)),new DataColumn("validperiod_dat1",typeof(string)),new DataColumn("medicinepreptypename_vchr"),new DataColumn("productorid_chr"),new DataColumn("storagerackid_chr"),
                new DataColumn("storagerackname_vchr"),new DataColumn("retailsum",typeof(double)),new DataColumn("bca"),new DataColumn("cab",typeof(string)),new DataColumn("validperiod_dat",typeof(DateTime))};
                dtbTemp.Columns.AddRange(dcColumns);
                dtbTemp.Merge(dtbPrint, true, MissingSchemaAction.Ignore);
                //某些药品有效期超过范围1753年，不得不转成字符串来显示
                DataRow dr = null;
                for (int i1 = 0; i1 < dtbTemp.Rows.Count; i1++)
                {
                    dr = dtbTemp.Rows[i1];
                    dr["validperiod_dat1"] = Convert.ToDateTime(dr["validperiod_dat"]).ToString("yyyy-MM-dd");
                }
                dtbTemp.AcceptChanges();
                dtbTemp.Columns.Remove("validperiod_dat");

                m_dwcDrugQuery.Retrieve(dtbTemp);

                m_dwcDrugQuery.Refresh();
                m_dwcDrugQuery.SetRedrawOn();
                m_dwcDrugQuery.Modify("t_title.text = '" + base.m_objComInfo.m_strGetHospitalTitle() + "药房药品库存'");
                m_dwcDrugQuery.Modify("t_storename.text = '药房：" + m_objViewer.m_cboStorage.Text + "'");
                m_dwcDrugQuery.Modify("t_drugtypename.text = '药品类型：" + m_objViewer.m_cboMedicineType.Text + "'");
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(m_dwcDrugQuery);
            }
            else
            {
                frmStorageCheckReport frmCheckRep = new frmStorageCheckReport();
                frmCheckRep.m_blnUseByDS = true;
                frmCheckRep.datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
                frmCheckRep.datWindow.DataWindowObject = "ds_storagecheck";
                DataTable dtbTemp = ((DataTable)m_objViewer.m_dgvDrugStorage.DataSource).Copy();
                dtbTemp.Columns["medicinename_vchr"].ColumnName = "medicinename_vch";
                dtbTemp.Columns["REALGROSS_INT"].ColumnName = "currentgross_int";
                dtbTemp.Columns.Add("RetailMoney", typeof(double));

                DataTable dtbTmp;
                clsDcl_DrugStoreCheckDetail objDomain = new clsDcl_DrugStoreCheckDetail();
                objDomain.m_lngGetStoreCheck_DetailForPrint(0,m_blnIsHospital, out dtbTmp);
                //帐面金额：RetailMoney 实盘金额：realmoney 盈亏金额：balance
                dtbTmp.Columns.Add("RetailMoney", typeof(double));
                dtbTmp.Columns.Add("realmoney", typeof(double));
                dtbTmp.Columns.Add("balance", typeof(double));

                foreach (DataRow dr in dtbTemp.Rows)
                {
                    dr["RetailMoney"] = Convert.ToDouble(dr["RETAILSUM"]).ToString("F4");
                }

                dtbTmp.Merge(dtbTemp, true, MissingSchemaAction.Ignore);

                frmCheckRep.dtb = dtbTmp.DefaultView.ToTable();
                double dblTotalPrice = 0d;

                for (int i1 = 0; i1 < dtbTmp.Rows.Count; i1++)
                {
                    if (Convert.ToString(dtbTmp.Rows[i1]["RetailMoney"]).Length == 0) continue;
                    dblTotalPrice += Convert.ToDouble(dtbTmp.Rows[i1]["RetailMoney"]);
                }
                frmCheckRep.m_dblTotalPrice = dblTotalPrice;
                string strStorName = string.Empty; ;
                clsMedStore_VO objStore = clsPub.m_mthGetMedStoreNameByid(m_objViewer.m_strMedStoreArr[0]);
                if (objStore != null)
                {
                    strStorName = objStore.m_strMedStoreName;
                }
                frmCheckRep.strStorageName = strStorName;
                
                frmCheckRep.strCheckDate = DateTime.Now.ToString("yyyy年M月");
                frmCheckRep.strAskerName = m_objViewer.LoginInfo.m_strEmpName;
                frmCheckRep.strFhr = m_objViewer.LoginInfo.m_strEmpName;
                frmCheckRep.strExamerName = m_objViewer.LoginInfo.m_strEmpName;                

                frmCheckRep.m_strHospitalName = m_objComInfo.m_strGetHospitalTitle();
                frmCheckRep.ShowDialog();
            }
        }
        #endregion

        #region 根据药房实际货架绑定货架
        /// <summary>
        /// 根据药房实际货架绑定货架
        /// </summary>
        internal void m_mthBindStorageRack()
        {
            long lngRes = 0;
            m_objViewer.comculumn.DataSource = null;
            m_dtbStorageRack.Clear();
            
            if (m_objViewer.m_cboStorage.Text != "")
            {
                try
                {
                    lngRes = m_objDomain.m_lngGetStorageRack(m_objViewer.m_cboStorage.Text, out m_dtbStorageRack);

                    if (lngRes > 0)
                    {                        
                        if (m_dtbStorageRack.Rows.Count > 0)
                        {
                            m_objViewer.comculumn.DataSource = m_dtbStorageRack;
                            m_objViewer.comculumn.ValueMember = "storagerackid_chr";
                            m_objViewer.comculumn.DisplayMember = "STORAGERACKNAME_VCHR";                            
                        }
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "货架加载出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        #endregion

        #region 保存货架设置
        /// <summary>
        /// 保存货架设置
        /// </summary>
        /// <param name="p_dicStorageRack"></param>
        /// <returns></returns>
        internal long m_lngSaveStorageRack(Dictionary<string, string> p_dicStorageRack)
        {
            long lngRes = 0;

            if (p_dicStorageRack.Count > 0)
            {
                try
                {
                    lngRes = m_objDomain.m_lngSaveStorageRack(p_dicStorageRack);

                    if (lngRes > 0)
                    {
                        //MessageBox.Show("货架设置完毕！", "货架设置", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "货架保存出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return lngRes;
        }


        internal long m_lngSaveProvide(DataTable p_dtbAmount)//保存可供不可供
        {
            long lngRes = 0;

            if (p_dtbAmount.Rows.Count > 0)
            {
                try
                {
                    lngRes = m_objDomain.m_lngSaveProvide(p_dtbAmount);
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "保存出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return lngRes;
        }
        #endregion

        #region 提示用户是否需要把其它批号也设置为可供或不可供。
        DataRow m_rowAmount = null;
        Int64 m_intSeriesID = 0;
        string m_strCanProvide = "";
        string m_strCanProvideName = "";
        string strMedicineID = "";
        internal void m_mthEdit(int p_intIndex)
        {
            try
            {
                m_objViewer.m_blnEditing = true;
                m_rowAmount = ((DataRowView)(m_objViewer.m_dgvDrugStorage.CurrentCell.OwningRow.DataBoundItem)).Row;
                if (m_objViewer.m_dtbAmount.PrimaryKey.Length == 0)
                {
                    DataColumn[] dcPrimaryKeyArr = new DataColumn[1];
                    dcPrimaryKeyArr[0] = m_objViewer.m_dtbAmount.Columns["seriesid_int"];
                    m_objViewer.m_dtbAmount.PrimaryKey = dcPrimaryKeyArr;
                }
                m_intSeriesID = Convert.ToInt64(m_rowAmount["seriesid_int"]);
                m_strCanProvide = Convert.ToString(m_rowAmount["canprovide_int"]);
                //自动计算改变门诊单位的可用库存后，相应包装单位可用库存的变化量
                //if (p_intIndex == m_objViewer.m_dgvDrugStorage.Columns["colIPAvailaGross"].Index)
                //{
                //    if (m_blnIsHospital)
                //    {
                //        if (Convert.ToInt16(m_rowAmount["ipchargeflg_int"]) == 0)
                //        {
                //            m_rowAmount["opavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value);
                //            m_rowAmount["ipavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value) * Convert.ToDouble(m_rowAmount["packqty_dec"]);
                //        }
                //        else if ((Convert.ToInt16(m_rowAmount["ipchargeflg_int"]) == 1))
                //        {
                //            m_rowAmount["opavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value) / Convert.ToDouble(m_rowAmount["packqty_dec"]);
                //            m_rowAmount["ipavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value);
                //        }
                //    }
                //    else
                //    {
                //        if (Convert.ToInt16(m_rowAmount["opchargeflg_int"]) == 0)
                //        {
                //            m_rowAmount["opavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value);
                //            m_rowAmount["ipavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value) * Convert.ToDouble(m_rowAmount["packqty_dec"]);
                //        }
                //        else if ((Convert.ToInt16(m_rowAmount["opchargeflg_int"]) == 1))
                //        {
                //            m_rowAmount["opavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value) / Convert.ToDouble(m_rowAmount["packqty_dec"]);
                //            m_rowAmount["ipavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value);
                //        }
                //    }
                //}

                if (m_objViewer.m_dtbAmount.Rows.Contains(m_intSeriesID))
                {
                    m_objViewer.m_dtbAmount.Rows.Remove(m_objViewer.m_dtbAmount.Rows.Find(m_intSeriesID));
                }
                m_objViewer.m_dtbAmount.Rows.Add(m_rowAmount.ItemArray);

                m_strCanProvideName = m_objViewer.m_dgvDrugStorage.CurrentCell.Value.ToString() == "0" ? "不可供" : "可供";
                strMedicineID = m_rowAmount["medicineid_chr"].ToString();
                DataView dvResult = dtbResult.DefaultView;
                dvResult.RowFilter = "medicineid_chr = '" + strMedicineID + "'";
                DataTable dtTemp = dvResult.ToTable();
                if (dtTemp.Rows.Count > 1 && p_intIndex == m_objViewer.m_dgvDrugStorage.Columns["colStorageProvide"].Index)
                {
                    if (MessageBox.Show("是否需要把其它批号的药品【" + m_rowAmount["medicinename_vchr"].ToString() + "】也设置为" + m_strCanProvideName + "？", "可供状态设置",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        for (int i1 = 0; i1 < m_objViewer.m_dgvDrugStorage.Rows.Count; i1++)
                        {
                            m_rowAmount = ((DataRowView)(m_objViewer.m_dgvDrugStorage.Rows[i1].Cells[0].OwningRow.DataBoundItem)).Row;
                            if (m_rowAmount["medicineid_chr"].ToString() == strMedicineID && Convert.ToInt64(m_rowAmount["seriesid_int"]) != m_intSeriesID)
                            {
                                m_objViewer.m_dgvDrugStorage.Rows[i1].Cells["colStorageProvide"].Value = m_strCanProvide;
                                if (m_objViewer.m_dtbAmount.Rows.Contains(Convert.ToInt64(m_rowAmount["seriesid_int"])))
                                {
                                    m_objViewer.m_dtbAmount.Rows.Remove(m_objViewer.m_dtbAmount.Rows.Find(Convert.ToInt64(m_rowAmount["seriesid_int"])));
                                }
                                m_objViewer.m_dtbAmount.Rows.Add(m_rowAmount.ItemArray);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                m_objViewer.m_blnEditing = false;
            }
        }
        #endregion

        internal long m_lngSaveAmount(clsDS_StorageHistory_VO objHistory)
        {
            return m_objDomain.m_lngSaveAmount(objHistory);
        }

        internal long m_lngGetAmountBySeriesID(long p_intSeriesID, out clsDS_StorageHistory_VO objHistory)
        {
            return m_objDomain.m_lngGetAmountBySeriesID(p_intSeriesID, out objHistory);
        }

        #region 获取药品制剂类型
        /// <summary>
        /// 获取药品制剂类型
        /// </summary>
        internal void m_mthShowMedicinePreptype()
        {
            com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[] objMPVO = null;
            m_objDomain.m_mthShowMedicinePreptype(m_objViewer.m_strMedStoreArr[0], out objMPVO);

            if (objMPVO != null && objMPVO.Length > 0)
            {
                m_objViewer.m_lsbMediciePreptype.Items.Clear();
                com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objAll = new com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO();
                objAll.m_intFLAGA_INT = 0;
                objAll.m_strMEDICINEPREPTYPE_CHR = string.Empty;
                objAll.m_strMEDICINEPREPTYPENAME_VCHR = "全部";
                m_objViewer.m_lsbMediciePreptype.Items.Add(objAll);
                m_objViewer.m_lsbMediciePreptype.Items.AddRange(objMPVO);
                m_objViewer.m_lsbMediciePreptype.SelectedIndex = 0;
            }
        }
        #endregion
    }
}
