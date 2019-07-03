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
    /// 自动生成请领单控制层
    /// </summary>
    public class clsCtl_MedicineLimit : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 自动生成请领单控制层构造方法
        /// </summary>
        public clsCtl_MedicineLimit()
        {
            m_objDomain = new clsDcl_MedicineLimit();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMedicineLimit)frmMDI_Child_Base_in;
        }
        #endregion

        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_MedicineLimit m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmMedicineLimit m_objViewer;
        /// <summary>
        /// 药库基本信息
        /// </summary>
        private clsValue_StorageBse_VO[] m_objStorageBseArr = null;
        /// <summary>
        /// 药房ID
        /// </summary>
        private string m_strStorageID = string.Empty;
        /// <summary>
        /// 药品类型ID
        /// </summary>
        private string[] m_strMedicineType = null;
        /// <summary>
        /// 药房名称
        /// </summary>
        private string m_strStorageName = string.Empty;
        /// <summary>
        /// 出库明细数据表
        /// </summary>  
        internal DataTable dtbResult = null;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        #endregion

        /// <summary>
        /// 初始化子表作为DataGridView数据源的DataTable
        /// </summary>
        /// <param name="m_dtMedDetail"></param>
        public void m_mthInitMedicineTable(ref DataTable m_dtMedDetail)
        {
            dtbResult = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("IfCheck"),new DataColumn("assistcode_chr"), new DataColumn("medicineid_chr"), new DataColumn("medicinename_vchr"),
                new DataColumn("medspec_vchr"),new DataColumn("productorid_chr"),new DataColumn("opunit_chr"),new DataColumn("realgross_int",typeof(double)),new DataColumn("tiptoplimit_int",typeof(double)),new DataColumn("neaplimit_int",typeof(double))};
            dtbResult.Columns.AddRange(dcColumns);
            //dtbResult.PrimaryKey = new DataColumn[] { dtbResult.Columns["medicineid_chr"] };
        }

        #region 获取药品明细数据
        /// <summary>
        /// 获取药品明细数据
        /// 实现统计查询和明细查询功能。
        /// 可按药品的助记码、拼音码、五笔码、药品的ID或药品名称进行模糊查询
        /// </summary>
        internal void m_mthQuery()
        {
            //if (m_objViewer.m_cboStorage.Text.Trim().Length == 0)
            //{
            //    MessageBox.Show("必须选择药房!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            //else
            //    m_strStorageName = m_objViewer.m_cboStorage.Text;

            
            long lngRes = 0;

            m_objViewer.m_dgvDrugLimit.DataSource = null;

            if (dtbResult != null)
            {
                dtbResult.Clear();
                dtbResult.Dispose();
                dtbResult = null;
            }

            m_objViewer.m_mthInitDataTable();

            m_objDomain.m_mthGetDeptID(m_objViewer.m_strStoreID, out m_strStorageID);//m_objStorageBseArr[m_objViewer.m_cboStorage.SelectedIndex].MEDICINEROOMID;                  

            if (dtbResult == null)
            {
                m_mthInitMedicineTable(ref dtbResult);
            }

            lngRes = m_objDomain.m_mthGetLimitData(m_strStorageID,m_strMedicineType[m_objViewer.m_cbbDrugType.SelectedIndex],m_objViewer.m_blnIsHospital, ref dtbResult);
            if ((lngRes > 0) && (dtbResult != null))
            {
                m_objViewer.m_dgvDrugLimit.DataSource = dtbResult;
            }
            dtbResult.AcceptChanges();
        }
        #endregion

        /// <summary>
        /// 生成
        /// </summary>
        internal void m_mthGenerate()
        {
            if (m_objViewer.m_dgvDrugLimit.CurrentCell.RowIndex == -1) return;
            if (dtbResult.Rows.Count <= 0) return;
            DataTable dtbSelected = dtbResult.Clone();
            dtbResult.PrimaryKey = new DataColumn[] { dtbResult.Columns["medicineid_chr"] };
            DataRow drSelect = null;
            for (int i1 = 0; i1 < m_objViewer.m_dgvDrugLimit.Rows.Count; i1++)
            {
                if (m_objViewer.m_dgvDrugLimit[0, i1].Value.ToString() == "T")
                {
                    drSelect = dtbResult.Rows.Find(m_objViewer.m_dgvDrugLimit["medicineid_chr", i1].Value);
                    dtbSelected.Rows.Add(drSelect.ItemArray);
                }
            }

            if (dtbSelected.Rows.Count > 0)
            {
                frmInStorageMakeOrder objMakeOrder = new frmInStorageMakeOrder();
                objMakeOrder.m_btnNext.Enabled = false;
                objMakeOrder.IsCanModify = true;
                objMakeOrder.Show();
                objMakeOrder.SetDetail(dtbSelected);
            }
        }

        #region 获取药库基本信息
        /// <summary>
        /// 获取药库基本信息
        /// </summary>
        //internal void m_mthShowStorage()
        //{
        //    long lngRes = 0;
        //    clsValue_StorageBse_VO[] objStorageBseArr = null;
        //    if (m_objViewer.m_cboStorage.Items.Count == 0)
        //    {
        //        try
        //        {
        //            lngRes = m_objDomain.m_lngGetResultByConditionStorageBse(out objStorageBseArr);

        //            if (lngRes > 0)
        //            {
        //                m_objStorageBseArr = new clsValue_StorageBse_VO[objStorageBseArr.Length];
        //                int m_index = 0;
        //                for (int i1 = 0; i1 < objStorageBseArr.Length; i1++)
        //                {
        //                    m_index = m_objViewer.m_cboStorage.Items.Add(objStorageBseArr[i1].MEDICINEROOMNAME);
        //                    m_objStorageBseArr[m_index] = objStorageBseArr[i1];    
        //                }
        //                m_objViewer.m_cboStorage.SelectedIndex = 0;
        //            }
        //            else
        //            {
        //                m_objViewer.m_cboStorage.Items.Clear();
        //            }
        //        }
        //        catch (Exception objEx)
        //        {
        //            MessageBox.Show(objEx.Message, "药房查询提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        }
        //    }
        //    else
        //    {
        //        int m_index = 0;
        //        for (int i1 = 0; i1 < objStorageBseArr.Length; i1++)
        //        {
        //            m_index = m_objViewer.m_cboStorage.Items.Add(objStorageBseArr[i1].MEDICINEROOMNAME);
        //            m_objStorageBseArr[m_index] = objStorageBseArr[i1];
        //        }
        //        m_objViewer.m_cboStorage.SelectedIndex = 0;
        //    }
        //}
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        public void m_mthSaveMedicine()
        {
            DataTable dtbEditMedicine = dtbResult.GetChanges(DataRowState.Modified);
            if (dtbEditMedicine != null && dtbEditMedicine.Rows.Count > 0)
            {
                clsDS_MedicineLimit[] objLimitVO = new clsDS_MedicineLimit[dtbEditMedicine.Rows.Count];
                for (int i = 0; i < dtbEditMedicine.Rows.Count; i++)
                {
                    if (dtbEditMedicine.Rows[i]["tiptoplimit_int"].ToString() == "")
                        dtbEditMedicine.Rows[i]["tiptoplimit_int"] = 0;
                    if (Convert.ToDouble(dtbEditMedicine.Rows[i]["tiptoplimit_int"]) < 0)
                    {
                        MessageBox.Show("保存失败,最高限量不能小于0。药品:" + dtbEditMedicine.Rows[i]["medicinename_vchr"].ToString().Trim(), "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_mthLocalizeRow(dtbEditMedicine.Rows[i]["medicineid_chr"].ToString().Trim());
                        return;
                    }                    
                    if (dtbEditMedicine.Rows[i]["neaplimit_int"].ToString() == "")
                        dtbEditMedicine.Rows[i]["neaplimit_int"] = 0;
                    if (Convert.ToDouble(dtbEditMedicine.Rows[i]["neaplimit_int"]) < 0)
                    {
                        MessageBox.Show("保存失败,最低限量不能小于0。药品:" + dtbEditMedicine.Rows[i]["medicinename_vchr"].ToString().Trim(), "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_mthLocalizeRow(dtbEditMedicine.Rows[i]["medicineid_chr"].ToString().Trim());
                        return;
                    }
                    if (Convert.ToDouble(dtbEditMedicine.Rows[i]["tiptoplimit_int"]) != 0 && 
                        Convert.ToDouble(dtbEditMedicine.Rows[i]["tiptoplimit_int"]) < Convert.ToDouble(dtbEditMedicine.Rows[i]["neaplimit_int"]))
                    {
                        MessageBox.Show("保存失败,最高限量不能小于最低限量。药品:" + dtbEditMedicine.Rows[i]["medicinename_vchr"].ToString().Trim(), "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_mthLocalizeRow(dtbEditMedicine.Rows[i]["medicineid_chr"].ToString().Trim());
                        return;
                    }
                    objLimitVO[i] = new clsDS_MedicineLimit();
                    objLimitVO[i].m_strDrugstoreid_chr = m_strStorageID;
                    objLimitVO[i].m_strMedicineid_chr = dtbEditMedicine.Rows[i]["medicineid_chr"].ToString();
                    objLimitVO[i].m_dblTiptoplimit_int = Convert.ToDouble(dtbEditMedicine.Rows[i]["tiptoplimit_int"]);
                    objLimitVO[i].m_dblNeaplimit_int = Convert.ToDouble(dtbEditMedicine.Rows[i]["neaplimit_int"]);
                }
                long lngRes = m_objDomain.m_lngSaveMedicine(objLimitVO);
                if (lngRes != -1)
                {
                    dtbResult.AcceptChanges();
                    MessageBox.Show("保存成功", "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("保存失败", "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
        }
        #endregion

        #region 定位行
        /// <summary>
        /// 定位行
        /// </summary>
        /// <param name="p_strSearch">搜索字符</param>
        internal void m_mthLocalizeRow(string p_strSearch)
        {
            for (int iRow = 0; iRow < m_objViewer.m_dgvDrugLimit.Rows.Count; iRow++)
            {
                if (m_objViewer.m_dgvDrugLimit.Rows[iRow].Cells[2].Value != null
                    && m_objViewer.m_dgvDrugLimit.Rows[iRow].Cells[2].Value.ToString() == p_strSearch)
                {
                    m_objViewer.m_dgvDrugLimit.Rows[iRow].Selected = true;
                    m_objViewer.m_dgvDrugLimit.CurrentCell = m_objViewer.m_dgvDrugLimit.Rows[iRow].Cells[8];
                    break;
                }
            }
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
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.Location = new System.Drawing.Point(200, 38);
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
            m_mthGetMedicineInfo();
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicinDict;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            m_objViewer.m_txtSearch.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtSearch.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_txtSearch.Focus();
            m_mthLocalizeRow(MS_VO.m_strMedicineID);
        }
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            if(m_objViewer.m_cbbDrugType.SelectedIndex != -1)
            {
                clsDcl_MedicineLimit objIRDomain = new clsDcl_MedicineLimit();
                long lngRes = objIRDomain.m_lngGetBaseMedicine(string.Empty, m_strMedicineType[m_objViewer.m_cbbDrugType.SelectedIndex],out m_objViewer.m_dtbMedicinDict);
            }
        }
        #endregion


        /// <summary>
        /// 加载药品类型
        /// </summary>
        internal void m_mthShowDrugType()
        {
            m_objViewer.m_cbbDrugType.Items.Clear();
            DataTable dtResult = null;            
            int m_index = 0;
            string[] m_strMedicineTypeArr = m_objViewer.m_strDrugType.Split('*'); 
            clsDcl_MedicineLimit objIRDomain = new clsDcl_MedicineLimit();
            long lngRes = objIRDomain.m_lngGetMedicineType(out dtResult);
            m_strMedicineType = new string[dtResult.Rows.Count];
            for (int i1 = 0; i1 < dtResult.Rows.Count; i1++)
            {
                if (Array.IndexOf(m_strMedicineTypeArr, dtResult.Rows[i1]["medicinetypeid_chr"]) != -1)
                {
                    m_index = m_objViewer.m_cbbDrugType.Items.Add(dtResult.Rows[i1]["medicinetypename_vchr"]);
                    m_strMedicineType[m_index] = dtResult.Rows[i1]["medicinetypeid_chr"].ToString();
                }
            }
            if(m_objViewer.m_cbbDrugType.Items.Count > 0)
                m_objViewer.m_cbbDrugType.SelectedIndex = 0;
        }

        internal void m_mthExportExcle()
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
            StringBuilder str = null;
            try
            {
                //添加列标题
                str = new StringBuilder();
                for (int iOr = 1; iOr < m_objViewer.m_dgvDrugLimit.ColumnCount; iOr++)
                {
                        str.Append (m_objViewer.m_dgvDrugLimit.Columns[iOr].HeaderText.ToString ());
                        str.Append ("\t");
                }
                sw.WriteLine(str);

                //添加行文本
                StringBuilder objStrBuilder = null;
                for (int iOr = 0; iOr < m_objViewer.m_dgvDrugLimit.Rows.Count; iOr++)
                {
                    objStrBuilder = new StringBuilder();
                    for (int jOr =1; jOr < m_objViewer.m_dgvDrugLimit.Columns.Count; jOr++)
                    {
                            objStrBuilder.Append(m_objViewer.m_dgvDrugLimit.Rows[iOr].Cells[jOr].FormattedValue.ToString());
                            objStrBuilder.Append("\t");

                    }
                    sw.WriteLine(objStrBuilder);

                }
                MessageBox.Show("导出成功！", "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
