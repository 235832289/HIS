using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 自动接收通知单据设置
    /// </summary>
    public class clsCtl_OutOrInStorageDeptSet : com.digitalwave.GUI_Base.clsController_Base
    {
        public DataTable p_dtbOutOrInStore;
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_OutOrInStorageDeptSet m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmOutOrInStorageDeptSet m_objViewer;
        /// <summary>
        /// 库房表
        /// </summary>
        private DataTable p_dtbStoreName;

        public clsCtl_OutOrInStorageDeptSet()
        {
            m_objDomain = new clsDcl_OutOrInStorageDeptSet();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象.
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOutOrInStorageDeptSet)frmMDI_Child_Base_in;
        }
        #endregion

        internal void m_mthGetOutOrInStoreDept()
        {
            m_objDomain.m_mthGetOutOrInStoreDept(this.m_objViewer.m_blnIsDrugStore, out p_dtbOutOrInStore);
            this.m_objViewer.m_dgvOutOrInStorageDept.DataSource = p_dtbOutOrInStore;
        }

        internal void m_mthGetStorageName()
        {
            this.m_objDomain.m_mthGetStoreName(this.m_objViewer.m_blnIsDrugStore, out p_dtbStoreName);
            if (p_dtbStoreName.Rows.Count > 0)
            {
                this.m_objViewer.m_cboStorageName.Items.Clear();

                for (int i = 0; i < p_dtbStoreName.Rows.Count; i++)
                {
                    this.m_objViewer.m_cboStorageName.Item.Add(p_dtbStoreName.Rows[i]["medstorename_vchr"].ToString(), p_dtbStoreName.Rows[i]["deptid_chr"].ToString());
                }
            }
        }

        internal void m_mthSearchInfo()
        {
            DataTable dtDept = new DataTable();
            string strStoreid = this.m_objViewer.m_cboStorageName.SelectItemValue.ToString().Trim();
            long lngRes = this.m_objDomain.m_mthSearchDept(strStoreid, out dtDept);
            int iRowCount = this.m_objViewer.m_dgvOutOrInStorageDept.Rows.Count;
            if (dtDept.Rows.Count > 0)
            {
                DataRow drDept = null;
                int iDeptCount = dtDept.Rows.Count;
                bool blnExist = false;
                for (int iOr = 0; iOr < iRowCount; iOr++)
                {
                    string strCellValue = p_dtbOutOrInStore.Rows[iOr]["deptid_chr"].ToString();

                    for (int jOr = 0; jOr < iDeptCount; jOr++)
                    {
                        drDept = dtDept.Rows[jOr];

                        if (drDept["deptid_chr"].ToString().Trim() == strCellValue)
                        {
                            p_dtbOutOrInStore.Rows[iOr]["checkbox_chr"] = "T";
                            blnExist = true;
                            break;
                        }
                    }
                    if (!blnExist)
                    {
                        p_dtbOutOrInStore.Rows[iOr]["checkbox_chr"] = "F";
                    }
                    blnExist = false;
                }
            }
            else
            {
                for (int kOr = 0; kOr < iRowCount; kOr++)
                {
                    p_dtbOutOrInStore.Rows[kOr]["checkbox_chr"] = "F";
                }
            }

            m_mthSortNo();
        }

        private void m_mthSortNo()
        {
            DataView dv = new DataView(p_dtbOutOrInStore);
            dv.Sort = "checkbox_chr desc,numberno asc";
            this.m_objViewer.m_dgvOutOrInStorageDept.DataSource = dv.ToTable();
        }

        internal void m_mthSaveData()
        {
            long lng = 0;
            int intRowCount = 0;
            
            for (int i = 0; i < this.m_objViewer.m_dgvOutOrInStorageDept.Rows.Count; i++)
            {
                if (this.m_objViewer.m_dgvOutOrInStorageDept.Rows[i].Cells[0].Value != null && this.m_objViewer.m_dgvOutOrInStorageDept.Rows[i].Cells[0].Value.ToString() == "T")
                {
                    intRowCount++;
                }
            }
            string strStoreid = this.m_objViewer.m_cboStorageName.SelectItemValue.ToString().Trim();
            clsOutOrInStorageDeptSet[] objDeptArr = new clsOutOrInStorageDeptSet[intRowCount];
            int intRow = 0;
            for (int j = 0; j < this.m_objViewer.m_dgvOutOrInStorageDept.Rows.Count; j++)
            {
                if (this.m_objViewer.m_dgvOutOrInStorageDept.Rows[j].Cells[0].Value != null && this.m_objViewer.m_dgvOutOrInStorageDept.Rows[j].Cells[0].Value.ToString() == "T")
                {
                    objDeptArr[intRow] = new clsOutOrInStorageDeptSet();
                    objDeptArr[intRow].strDeptid = this.m_objViewer.m_dgvOutOrInStorageDept.Rows[j].Cells["m_dgvtxtDeptid"].Value.ToString();
                    intRow++;
                }
            }
            
            lng = m_objDomain.m_lngSaveData(strStoreid, objDeptArr);
            
            if (lng > 0)
            {
                MessageBox.Show("保存成功", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("保存失败", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            m_mthSearchInfo();
        }

        public DataGridViewCell m_dgvcSelect(DataGridView m_dgvOutOrInStorageDept, string p_strTextValue)
        {
            DataRowView drv = null;
            string strConverTextValue = p_strTextValue.ToLower();
            for (int iOr = 0; iOr < m_dgvOutOrInStorageDept.Rows.Count; iOr++)
            {
                drv = (DataRowView)m_dgvOutOrInStorageDept.Rows[iOr].DataBoundItem;
                if (drv["deptname_vchr"].ToString().ToLower().StartsWith(strConverTextValue)
                    || drv["pycode_chr"].ToString().ToLower().StartsWith(strConverTextValue)
                    || drv["code_vchr"].ToString().ToLower().StartsWith(strConverTextValue))
                {
                    return m_dgvOutOrInStorageDept.Rows[iOr].Cells[1];
                }
            }
            return null;
        }
    }
}
