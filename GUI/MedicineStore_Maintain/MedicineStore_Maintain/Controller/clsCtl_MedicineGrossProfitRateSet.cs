using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品毛利率设置逻辑控制
    /// </summary>
    public class clsCtl_MedicineGrossProfitRateSet : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 药品毛利率设置中间件访问类
        /// </summary>
        private clsDcl_MedicineGrossProfitRateSet m_objDomain = null;
        /// <summary>
        /// 药品毛利率设置窗体
        /// </summary>
        private frmMedicineGrossProfitRateSet m_objViewer = null;

        /// <summary>
        /// 药品毛利率设置逻辑控制
        /// </summary>
        public clsCtl_MedicineGrossProfitRateSet()
        {
            m_objDomain = new clsDcl_MedicineGrossProfitRateSet();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMedicineGrossProfitRateSet)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取药品毛利率设置
        /// <summary>
        /// 获取药品毛利率设置
        /// </summary>
        /// <param name="p_objRateArr">药品毛利率设置</param>
        internal void m_mthGetGrossProfitRateSet(out  clsMS_GrossProfitRateSet_VO[] p_objRateArr)
        {
            long lngRes = m_objDomain.m_lngGetGrossProfitRateSet(out p_objRateArr);
        } 
        #endregion

        /// <summary>
        /// 初始化数据源
        /// </summary>
        /// <param name="p_dtbSource"></param>
        internal void m_mthInitDataTable(ref DataTable p_dtbSource)
        {
            p_dtbSource = new DataTable();
            DataColumn[] dcArr = new DataColumn[] { new DataColumn("ID"), new DataColumn("Name"), new DataColumn("Rate"), new DataColumn("Status") };
            p_dtbSource.Columns.AddRange(dcArr);
        }

        #region 设置药品毛利率至界面
        /// <summary>
        /// 设置药品毛利率至界面
        /// </summary>
        /// <param name="p_objRateArr"></param>
        internal void m_mthSetGrossProfitRateDataToUI(clsMS_GrossProfitRateSet_VO[] p_objRateArr)
        {
            if (m_objViewer.m_dtbDataSource != null && p_objRateArr != null)
            {
                m_objViewer.m_dtbDataSource.BeginLoadData();
                for (int iRow = 0; iRow < p_objRateArr.Length; iRow++)
                {
                    DataRow drTemp = m_objViewer.m_dtbDataSource.NewRow();
                    drTemp["ID"] = p_objRateArr[iRow].m_strMEDICINETYPEID_CHR;
                    drTemp["Name"] = p_objRateArr[iRow].m_strMEDICINETYPENAME;
                    drTemp["Rate"] = p_objRateArr[iRow].m_dblGROSSPROFITRATE.ToString("0.00") ;
                    if (p_objRateArr[iRow].m_blnIsInGrossProfitRateSet)
                    {
                        drTemp["Status"] = 1;
                    }
                    else
                    {
                        drTemp["Status"] = 0;
                    }
                    m_objViewer.m_dtbDataSource.LoadDataRow(drTemp.ItemArray, true);
                }               
                m_objViewer.m_dtbDataSource.EndLoadData();
            }
        } 
        #endregion

        #region 检查毛利率是否有效
        /// <summary>
        /// 检查毛利率是否有效
        /// </summary>
        /// <returns></returns>
        internal bool m_blnCheckRate()
        {
            if (m_objViewer.m_dtbDataSource != null)
            {
                int intRowsCount = m_objViewer.m_dtbDataSource.Rows.Count;
                DataRow drTemp = null;
                double dblRate = 0d;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = m_objViewer.m_dtbDataSource.Rows[iRow];
                    if (string.IsNullOrEmpty(drTemp["Rate"].ToString()))
                    {
                        MessageBox.Show("毛利率不能为空", "毛利率设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_objViewer.m_dgvRateSet.Focus();
                        m_objViewer.m_dgvRateSet.CurrentCell = m_objViewer.m_dgvRateSet.Rows[iRow].Cells[2];
                        m_objViewer.m_dgvRateSet.CurrentCell.Selected = true;
                        return false;
                    }
                    if (double.TryParse(drTemp["Rate"].ToString(),out dblRate))
                    {
                        if (dblRate >100 || dblRate < 0)
                        {
                            MessageBox.Show("毛利率数值超出有效范围", "毛利率设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            m_objViewer.m_dgvRateSet.Focus();
                            m_objViewer.m_dgvRateSet.CurrentCell = m_objViewer.m_dgvRateSet.Rows[iRow].Cells[2];
                            m_objViewer.m_dgvRateSet.CurrentCell.Selected = true;
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("毛利率必须为数字", "毛利率设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_objViewer.m_dgvRateSet.Focus();
                        m_objViewer.m_dgvRateSet.CurrentCell = m_objViewer.m_dgvRateSet.Rows[iRow].Cells[2];
                        m_objViewer.m_dgvRateSet.CurrentCell.Selected = true;
                        return false;
                    }
                }
            }
            return true;
        } 
        #endregion

        #region 保存毛利率设置
        /// <summary>
        /// 保存毛利率设置
        /// </summary>
        internal void m_mthSaveGrossProfitRateSet()
        {
            if (m_objViewer == null)
            {
                return;
            }

            int intRowsCount = m_objViewer.m_dtbDataSource.Rows.Count;

            long lngRes = m_lngAddNew();
            

            DataRow[] drOld = m_objViewer.m_dtbDataSource.Select("status = 1");

            List<DataRow> drModift = new List<DataRow>();
            foreach (DataRow dr in drOld)
            {
                if (dr.RowState == DataRowState.Modified)
                {
                    drModift.Add(dr);
                }
            }

            if (drModift.Count > 0)
            {
                clsMS_GrossProfitRateSet_VO[] objModifyArr = new clsMS_GrossProfitRateSet_VO[drModift.Count];
                for (int iRow = 0; iRow < drModift.Count; iRow++)
                {
                    objModifyArr[iRow] = new clsMS_GrossProfitRateSet_VO();
                    objModifyArr[iRow].m_dblGROSSPROFITRATE = Convert.ToDouble(drModift[iRow]["Rate"]);
                    objModifyArr[iRow].m_strMEDICINETYPEID_CHR = drModift[iRow]["ID"].ToString();
                }
                lngRes = m_objDomain.m_lngModifyGrossProfitRateSet(objModifyArr);
                if (lngRes > 0)
                {
                    m_objViewer.m_dtbDataSource.AcceptChanges();
                    MessageBox.Show("保存成功", "毛利率设置", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败", "毛利率设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }

        /// <summary>
        /// 新添记录
        /// </summary>
        /// <returns></returns>
        private long m_lngAddNew()
        {
            long lngRes = 0;
            DataRow[] drNew = m_objViewer.m_dtbDataSource.Select("status = 0");
            if (drNew != null && drNew.Length > 0)
            {
                clsMS_GrossProfitRateSet_VO[] objNewArr = new clsMS_GrossProfitRateSet_VO[drNew.Length];
                for (int iRow = 0; iRow < drNew.Length; iRow++)
                {
                    objNewArr[iRow] = new clsMS_GrossProfitRateSet_VO();
                    objNewArr[iRow].m_dblGROSSPROFITRATE = Convert.ToDouble(drNew[iRow]["Rate"]);
                    objNewArr[iRow].m_strMEDICINETYPEID_CHR = drNew[iRow]["ID"].ToString();
                }
                lngRes = m_objDomain.m_lngAddGrossProfitRateSet(objNewArr);

                if (lngRes > 0)
                {
                    for (int iRow = 0; iRow < drNew.Length; iRow++)
                    {
                        drNew[iRow]["Status"] = 1;
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region 重置毛利率
        /// <summary>
        /// 重置毛利率
        /// </summary>
        internal void m_mthResetGrossProfitRate()
        {
            if (m_objViewer.m_dtbDataSource != null && m_objViewer.m_dtbDataSource.Rows.Count > 0)
            {
                DialogResult drResult = MessageBox.Show("是否确定将所有的毛利率重置成15%?", "毛利率设置", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.Yes)
                {
                    for (int iRow = 0; iRow < m_objViewer.m_dtbDataSource.Rows.Count; iRow++)
                    {
                        m_objViewer.m_dtbDataSource.Rows[iRow]["Rate"] = 15.00d;
                    }
                }

                m_mthSaveGrossProfitRateSet();
            }            
        } 
        #endregion

        #region 检查是否有未保存数据
        /// <summary>
        /// 检查是否有未保存数据
        /// </summary>
        /// <returns></returns>
        internal int m_intCheckHasUnSaveData()
        {
            int intReturn = 1;
            m_objViewer.m_dgvRateSet.EndEdit();
            if (m_objViewer.m_dtbDataSource != null && m_objViewer.m_dtbDataSource.Rows.Count > 0)
            {
                DataTable dtbChange = m_objViewer.m_dtbDataSource.GetChanges(DataRowState.Modified);

                m_lngAddNew();

                if (dtbChange != null && dtbChange.Rows.Count > 0)
                {
                    DialogResult drResult = MessageBox.Show("当前窗体含有未保存的数据，是否保存？","毛利率设置",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                    if (drResult == DialogResult.Yes)
                    {
                        if (m_blnCheckRate())
                        {
                            m_mthSaveGrossProfitRateSet();
                            intReturn = 1;
                        }
                        else
                        {
                            intReturn = -1;
                        }
                    }
                    else if (drResult == DialogResult.No)
                    {
                        intReturn = 1;
                    }
                    else
                    {
                        intReturn = -1;
                    }
                }
            }
            return intReturn;
        } 
        #endregion
    }
}
