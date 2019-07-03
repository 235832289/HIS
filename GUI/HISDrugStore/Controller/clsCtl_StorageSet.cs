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

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房库存查询控制层
    /// </summary>
    public class clsCtl_StorageSet : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 药房库存查询控制层构造方法
        /// </summary>
        public clsCtl_StorageSet()
        {
            m_objDomain = new clsDcl_StorageSet();
        }

        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_StorageSet m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmStorageSet m_objViewer;
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
        /// 药品明细数据表
        /// </summary>  
        internal DataTable dtbResult = null;
        /// <summary>
        /// 统计信息临时表
        /// </summary>
        private DataTable dtbTem = new DataTable();
        /// <summary>
        /// 缺药
        /// </summary>
        private DataTable m_dtbLack = new DataTable();
        /// <summary>
        /// 停用
        /// </summary>
        private DataTable m_dtbStop = new DataTable();
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmStorageSet)frmMDI_Child_Base_in;
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
            clsPub.m_mthGetMedBaseInfo(m_objViewer.m_strMedStoreArr[0], out m_objViewer.m_dtMedicineInfo);            
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
                        //this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());

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
                    MessageBox.Show(objEx.Message, "药房设置提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    MessageBox.Show(objEx.Message, "药房设置提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            string m_strStorageID = string.Empty;
            string m_strMedicineID = string.Empty;
            string m_strAssistCode = string.Empty;
            string m_strMedicineTypeID = string.Empty;

            if (m_objViewer.m_cboStorage.Text.Trim().Length == 0)
            {
                MessageBox.Show("必须选择药库!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            long lngRes = 0;
            List<string> lstMedicineType = new List<string>();            

            m_objViewer.m_dgvDrugStorage.DataSource = null;

            if (dtbResult != null)
            {
                dtbResult.Clear();
                dtbResult.Dispose();
                dtbResult = null;
            }



            m_strStorageID = m_objViewer.m_cboStorage.SelectItemValue;
            
            if (m_objViewer.m_txtMedicineCode.Text.Trim().Length > 0)
            {
                if (m_objViewer.m_objMedicineBase.m_strMedicineID.Trim().Length > 0)
                    m_strMedicineID = m_objViewer.m_objMedicineBase.m_strMedicineID.Trim();
                else
                {
                    m_strAssistCode = m_objViewer.m_txtMedicineCode.Text + @"%";
                }
            }
            else
            {
                m_strAssistCode = "";
            }

            //药品类型
            if ((m_objViewer.m_cboMedicineType.Text.Trim().Length > 0) && (m_objViewer.m_cboMedicineType.Text.Trim() != "所有类型"))
            {
                lstMedicineType.Add(objMedicineTypeArr[m_objViewer.m_cboMedicineType.SelectedIndex - 1].m_strMedicineTypeID);
            }
            else
                m_strMedicineTypeID = "";
            
            dtbResult = new DataTable();//数据库返回的结果集

            lngRes = m_objDomain.m_mthGetStorageDetailData(m_strStorageID, m_strMedicineID, m_strAssistCode, m_strMedicineTypeID,
                out dtbResult,lstMedicineType,m_objViewer.m_blnIsHospital);
            if ((lngRes > 0) && (dtbResult != null))
            {
                m_objViewer.m_dgvDrugStorage.DataSource = dtbResult;               
            }
            m_objViewer.m_dtbModify.Rows.Clear();
            m_objViewer.m_dtbModify = dtbResult.Clone();
            m_mthFilterShow();
        }
        #endregion

        internal void m_mthFilterShow()
        {            
            if(dtbResult == null) return;
            DataTable m_dtbTemp = dtbResult.Copy();
            
            DataView dvResult = m_dtbTemp.DefaultView;            

            if (m_objViewer.m_rbtNormal.Checked)
            {
                dvResult.RowFilter = "ifstop_int = 0 and NOQTYFLAG_INT = 0";       
            }
            else if (m_objViewer.m_rbtStop.Checked)
            {
                dvResult.RowFilter = "ifstop_int = 1";
            }
            else if (m_objViewer.m_rbtLack.Checked)
            {
                dvResult.RowFilter = "NOQTYFLAG_INT = 1";
            }

            m_dtbTemp = dvResult.ToTable();
            m_objViewer.m_dgvDrugStorage.DataSource = m_dtbTemp;            
        }

        #region 从网格导出数据到Excel
        /// <summary>
        /// 从网格导出数据到Excel
        /// </summary>
        internal void m_mthExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                //添加列标题
                for (int iOr = 0; iOr < m_objViewer.m_dgvDrugStorage.ColumnCount; iOr++)
                {
                    if (m_objViewer.m_dgvDrugStorage.Columns[iOr].Visible == false)
                        continue;
                    if (iOr > 0)
                    {
                        str += "\t";
                    }
                    str += m_objViewer.m_dgvDrugStorage.Columns[iOr].HeaderText.Replace("\n", "");
                }
                sw.WriteLine(str);
                //添加行文本
                StringBuilder objStrBuilder = null;
                for (int iOr = 0; iOr < m_objViewer.m_dgvDrugStorage.Rows.Count; iOr++)
                {                    
                    objStrBuilder = new StringBuilder();
                    for (int jOr = 0; jOr < m_objViewer.m_dgvDrugStorage.Columns.Count; jOr++)
                    {
                        if (m_objViewer.m_dgvDrugStorage.Columns[jOr].Visible == false)
                            continue;
                        if (jOr > 0)
                        {
                            objStrBuilder.Append("\t");
                        }
                        if (jOr == 0 || jOr == 1)
                        {
                            objStrBuilder.Append(m_objViewer.m_dgvDrugStorage.Rows[iOr].Cells[jOr].FormattedValue.ToString());
                        }
                        else
                            objStrBuilder.Append(m_objViewer.m_dgvDrugStorage.Rows[iOr].Cells[jOr].Value.ToString());
                    }
                    sw.WriteLine(objStrBuilder);
                }
                MessageBox.Show("导出成功！", "药品库存设置", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        internal void m_mthPrint()
        {
            return;//报表尚未做 

            m_mthQuery();
            DataWindowControl m_dwcDrugQuery = new DataWindowControl();
            m_dwcDrugQuery.LibraryList = Application.StartupPath + "\\PB_OP.pbl";            
            m_dwcDrugQuery.DataWindowObject = "d_op_drugquerydetail";

            //datWindow.Modify("t_tile.text = '" + base.m_objComInfo.m_strGetHospitalTitle() + "(" + p_strStorageName + ")'");
            m_dwcDrugQuery.SetRedrawOff();            
            m_dwcDrugQuery.Retrieve(dtbResult);            
            m_dwcDrugQuery.Refresh();
            m_dwcDrugQuery.SetRedrawOn();
            m_dwcDrugQuery.Modify("t_storename.text = '药房：" + m_objViewer.m_cboStorage.Text + "'");
            m_dwcDrugQuery.Modify("t_drugtypename.text = '药品类型：" + m_objViewer.m_cboMedicineType.Text + "'");
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(m_dwcDrugQuery);
        }
        #endregion

        #region 绑定选项
        /// <summary>
        /// 绑定选项
        /// </summary>
        internal void m_mthBindOption()
        {
            try
            {
                m_dtbLack.Columns.Add("NOQTYFLAG_INT",typeof(Int16));
                m_dtbLack.Columns.Add("noquatityname_vchr",typeof(string));
                DataRow dr = m_dtbLack.NewRow();
                dr["NOQTYFLAG_INT"] = 0;
                dr["noquatityname_vchr"] = "有药";
                m_dtbLack.Rows.Add(dr);
                dr = m_dtbLack.NewRow();
                dr["NOQTYFLAG_INT"] = 1;
                dr["noquatityname_vchr"] = "缺药";
                m_dtbLack.Rows.Add(dr);

                m_objViewer.colNoQuality.DataSource = m_dtbLack;
                m_objViewer.colNoQuality.ValueMember = "NOQTYFLAG_INT";
                m_objViewer.colNoQuality.DisplayMember = "noquatityname_vchr";

                m_dtbStop.Columns.Add("ifstop_int", typeof(Int16));
                m_dtbStop.Columns.Add("ifstopname_vchr", typeof(string));
                DataRow dr2 = m_dtbStop.NewRow();
                dr2["ifstop_int"] = 0;
                dr2["ifstopname_vchr"] = "正常";
                m_dtbStop.Rows.Add(dr2);
                dr2 = m_dtbStop.NewRow();
                dr2["ifstop_int"] = 1;
                dr2["ifstopname_vchr"] = "停用";
                m_dtbStop.Rows.Add(dr2);

                m_objViewer.colStop.DataSource = m_dtbStop;
                m_objViewer.colStop.ValueMember = "ifstop_int";
                m_objViewer.colStop.DisplayMember = "ifstopname_vchr";

            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "加载出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }           
        }
        #endregion

        #region 保存缺药和停用,货架
        internal long m_lngSaveStorageSet(DataTable p_dtbModify)
        {
            long lngRes = 0;

            if (p_dtbModify.Rows.Count > 0)
            {
                try
                {
                    lngRes = m_objDomain.m_lngSaveStorageSet(p_dtbModify);

                    if (lngRes > 0)
                    {
                        //MessageBox.Show("数量修改完毕！", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "保存出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return lngRes;
        }
        #endregion

        #region 是否住院药房
        /// <summary>
        /// 是否住院药房
        /// </summary>
        /// <param name="p_strStorageid"></param>
        /// <param name="p_blnIsHospital"></param>
        internal long m_lngCheckIsHospital(string p_strStorageid, out bool p_blnIsHospital)
        {
            clsDcl_AskForMedicine objDom = new clsDcl_AskForMedicine();
            return objDom.m_lngCheckIsHospital(p_strStorageid, out p_blnIsHospital);
        }
        #endregion
    }
}
