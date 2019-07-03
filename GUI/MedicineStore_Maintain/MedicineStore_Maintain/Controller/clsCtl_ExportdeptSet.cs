using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsCtl_ExportdeptSet : com.digitalwave.GUI_Base.clsController_Base
    {
        private DataTable p_dtbStorage = new DataTable();
        public DataTable p_dtbExportAll;
        public DataTable p_dtbExport;
        /// <summary>
        /// 模块控制类

        /// </summary>
        private clsDcl_ExportdeptSet m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmExportdeptSet m_objViewer;

        #region 构造函数
        /// <summary>
        /// 盘点药品顺序设置
        /// </summary>
        public clsCtl_ExportdeptSet()
        {
            m_objDomain = new clsDcl_ExportdeptSet();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象.
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmExportdeptSet)frmMDI_Child_Base_in;
        }
        #endregion

        public void m_mthGetExportDept()
        {
            m_objDomain.m_lngGetExportdeptAll(out p_dtbExportAll);
            m_objViewer.m_dgvExportdeptAll.DataSource = p_dtbExportAll;
            m_objDomain.m_lngGetExportdept(out p_dtbExport);
            m_objViewer.m_dgvExportdept.DataSource = p_dtbExport;
        }

        internal void m_mthBindStorage()
        {
            this.m_objViewer.cboFlag.DataSource = null;
            p_dtbStorage.Clear();
            try
            {
                p_dtbStorage.Columns.Add("storageflag_int", typeof(Int16));
                p_dtbStorage.Columns.Add("deptname_vchr", typeof(string));

                p_dtbStorage.Rows.Add(0, "药库");
                p_dtbStorage.Rows.Add(1, "药房");
                p_dtbStorage.Rows.Add(2, "药库房共用");

                m_objViewer.cboFlag.DataSource = p_dtbStorage;
                m_objViewer.cboFlag.DisplayMember = "deptname_vchr";
                m_objViewer.cboFlag.ValueMember = "storageflag_int";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "库房加载出错", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        public void m_mthAddExportDept()
        {
            if (m_objViewer.m_dgvExportdeptAll.CurrentRow == null)
            {
                return;
            }

            DataRow dr = p_dtbExport.NewRow();
            string strDeptid = m_objViewer.m_dgvExportdeptAll.Rows[m_objViewer.m_dgvExportdeptAll.CurrentRow.Index].Cells["deptid_chr"].Value.ToString();
            dr[0] = strDeptid;
            dr[1] = m_objViewer.m_dgvExportdeptAll.Rows[m_objViewer.m_dgvExportdeptAll.CurrentRow.Index].Cells["deptname_vchr"].Value.ToString();
            dr[2] = p_dtbStorage.Rows[0]["storageflag_int"].ToString();
            DataRow[] drNull = p_dtbExport.Select("deptid_chr = '" + strDeptid + "'");
            if (drNull != null && drNull.Length > 0)
            {
                MessageBox.Show("该部门已添加", "领用部门列表设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            p_dtbExport.Rows.Add(dr);
        }

        public long m_mthSaverExportDept()
        {
            long lngRes = 0;

            //m_objViewer.m_dgvExportdept.CommitEdit(DataGridViewDataErrorContexts.CurrentCellChange);
            //if (m_objViewer.m_dicStorageFlag.Count > 0)
            //{
            //    if (m_objDomain.m_lngUpdateStorageFlag(m_objViewer.m_dicStorageFlag) > 0)
            //    {
            //        m_objViewer.m_dicStorageFlag.Clear();
            //    }
            //}

            int iRowLength = p_dtbExport.Rows.Count;
            string strSeriesID = string.Empty;
            clsMS_ExportDept[] objExportDept = new clsMS_ExportDept[iRowLength];
            DataRow dr = null;
            for (int iOr = 0; iOr < iRowLength; iOr++)
            {
                dr = p_dtbExport.Rows[iOr];
                objExportDept[iOr] = new clsMS_ExportDept();
                objExportDept[iOr].m_strExportDept = dr["deptid_chr"].ToString();
                objExportDept[iOr].m_strSeriesID = (iOr + 1).ToString("0000");
                objExportDept[iOr].m_strFlag = m_objViewer.m_dgvExportdept.Rows[iOr].Cells["cboFlag"].Value.ToString();
            }

            lngRes = m_objDomain.m_lngSaverExportdept(objExportDept);
            return lngRes;
        }

        public void m_mthDelExportDept()
        {
            if (m_objViewer.m_dgvExportdept.CurrentRow == null)
            {
                return;
            }

            if (MessageBox.Show("是否确定删除该信息", "信息提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvExportdept.CurrentRow.DataBoundItem)).Row;
                p_dtbExport.Rows.Remove(drCurrent);
                p_dtbExport.AcceptChanges();
            }
        }

        public void m_mthUp()
        {
            if (m_objViewer.m_dgvExportdept.CurrentCell.RowIndex - 1 < 0)
            {
                return;
            }

            if (m_objViewer.m_dgvExportdept.Rows.Count == 0)
            {
                return;
            }

            if (m_objViewer.m_dgvExportdept.CurrentCell == null)
            {
                MessageBox.Show("请先选择一行", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string strName = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[2].Value.ToString();
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[1].Value = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex - 1].Cells[1].Value;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[2].Value = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex - 1].Cells[2].Value;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex - 1].Cells[1].Value = id;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex - 1].Cells[2].Value = strName;
            m_objViewer.m_dgvExportdept.CurrentCell = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex - 1].Cells[2];
        }

        public void m_mthDown()
        {
            if (m_objViewer.m_dgvExportdept.CurrentCell.RowIndex + 1 >= m_objViewer.m_dgvExportdept.Rows.Count)
            {
                return;
            }

            if (m_objViewer.m_dgvExportdept.Rows.Count == 0)
            {
                return;
            }

            if (m_objViewer.m_dgvExportdept.CurrentCell == null)
            {
                MessageBox.Show("请先选择一行", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string strName = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[2].Value.ToString();
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[1].Value = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex + 1].Cells[1].Value;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[2].Value = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex + 1].Cells[2].Value;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex + 1].Cells[1].Value = id;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex + 1].Cells[2].Value = strName;
            m_objViewer.m_dgvExportdept.CurrentCell = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex + 1].Cells[2];
        }

        public void m_mthTop()
        {
            if (m_objViewer.m_dgvExportdept.Rows.Count == 0)
            {
                return;
            }

            if (m_objViewer.m_dgvExportdept.CurrentCell == null)
            {
                MessageBox.Show("请先选择一行", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string strName = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[2].Value.ToString();

            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[1].Value = m_objViewer.m_dgvExportdept.Rows[0].Cells[1].Value;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[2].Value = m_objViewer.m_dgvExportdept.Rows[0].Cells[2].Value;
            m_objViewer.m_dgvExportdept.Rows[0].Cells[1].Value = id;
            m_objViewer.m_dgvExportdept.Rows[0].Cells[2].Value = strName;
            m_objViewer.m_dgvExportdept.CurrentCell = m_objViewer.m_dgvExportdept.Rows[0].Cells[2];

        }

        public void m_mthBott()
        {
            if (m_objViewer.m_dgvExportdept.Rows.Count == 0)
            {
                return;
            }

            if (m_objViewer.m_dgvExportdept.CurrentCell == null)
            {
                MessageBox.Show("请先选择一行", "盘点药品顺序设置", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string id = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[1].Value.ToString();
            string strName = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[2].Value.ToString();

            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[1].Value = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.Rows.Count - 1].Cells[1].Value;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.CurrentCell.RowIndex].Cells[2].Value = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.Rows.Count - 1].Cells[2].Value;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.Rows.Count - 1].Cells[1].Value = id;
            m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.Rows.Count - 1].Cells[2].Value = strName;
            m_objViewer.m_dgvExportdept.CurrentCell = m_objViewer.m_dgvExportdept.Rows[m_objViewer.m_dgvExportdept.Rows.Count - 1].Cells[2];
        }

        /// <summary>
        /// 文本框输入时,返回查询到的值的行的第一个单元格,以备将该行选中
        /// </summary>
        /// <param name="p_dgvExportdeptAll">DataGridView控件:所有部门</param>
        /// <param name="p_strTextValue">文本框的值</param>
        /// <returns></returns>
        public DataGridViewCell m_dgvcSelect(DataGridView p_dgvExportdeptAll, string p_strTextValue)
        {
            DataRowView dr = null;
            string p_strConvertTextValue = p_strTextValue.ToLower();
            for (int iOr = 0; iOr < p_dgvExportdeptAll.Rows.Count; iOr++)
            {
                dr = (DataRowView)p_dgvExportdeptAll.Rows[iOr].DataBoundItem;
                if (dr["deptname_vchr"].ToString().ToLower().StartsWith(p_strConvertTextValue) || dr["pycode_chr"].ToString().ToLower().StartsWith(p_strConvertTextValue)
                    || dr["code_vchr"].ToString().ToLower().StartsWith(p_strConvertTextValue))
                {
                    return p_dgvExportdeptAll.Rows[iOr].Cells[0];
                }
            }
            return null;
        }
    }
}
