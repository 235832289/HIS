using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    class clsCtl_MedicineLimit : com.digitalwave.GUI_Base.clsController_Base
    {
        public frmMedicineLimit m_objViewer;
        public clsDcl_MedicineLimit m_objDomain;
        public DataTable dtbLimit;
        public DataView dtvFind = new DataView();
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        #region 构造函数
        /// <summary>
        /// 药品限量
        /// </summary>
        public clsCtl_MedicineLimit()
        {
            m_objDomain = new clsDcl_MedicineLimit();
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
            m_objViewer = (frmMedicineLimit)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {

            clsDcl_MedicineLimit objIRDomain = new clsDcl_MedicineLimit();
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
            
            //if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtFindBox.Location.X + m_objViewer.panel2.Location.X;
                Y = m_objViewer.m_txtFindBox.Location.Y + m_objViewer.m_txtFindBox.Size.Height + m_objViewer.panel2.Location.Y;

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

            m_objViewer.m_txtFindBox.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtFindBox.Text = MS_VO.m_strMedicineName;

            m_objViewer.m_txtFindBox.Focus();
            m_mthLocalizeRow(MS_VO.m_strMedicineID);
        }
        #endregion

        #region 取所有药品

        /// <summary>
        /// 取所有药品

        /// </summary>
        public void m_mthGetAllMedicine()
        {
            m_objDomain.m_lngGetAllMedicine(m_objViewer.m_strStorageID,out dtbLimit);

            m_objViewer.m_dgvDetailInfo.DataSource = dtbLimit;
            m_objViewer.m_dgvDetailInfo.Columns["medicineid_chr"].Visible = false;
            m_objViewer.m_dgvDetailInfo.Columns["pycode_chr"].Visible = false;
        }
        #endregion

        #region 查询出的药品
        /// <summary>
        /// 查询出的药品
        /// </summary>
        public void m_mthFindMedicine()
        {
            string strFind = m_objViewer.m_txtFindBox.Text.Trim();
            dtvFind = dtbLimit.DefaultView;
            dtvFind.RowFilter = "assistcode_chr like '" + strFind + "%' or medicinename_vchr like '%" + strFind + "%'or pycode_chr like '" + strFind + "%'";
            m_objViewer.m_dgvDetailInfo.DataSource = dtvFind;
        }
        #endregion

        #region 刷新
        /// <summary>
        /// 刷新
        /// </summary>
        public void m_mthAllMedicine()
        {
            dtvFind = dtbLimit.DefaultView;
            dtvFind.RowFilter = "assistcode_chr like '%'";
            m_objViewer.m_dgvDetailInfo.DataSource = dtvFind;
            m_objViewer.m_dgvDetailInfo.Refresh();
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        public void m_mthSaverMedicine()
        {
            DataTable dtbEditMedicine = dtbLimit.GetChanges(DataRowState.Modified);
            if (dtbEditMedicine != null && dtbEditMedicine.Rows.Count > 0)
            {
                clsMedicineLimit_VO[] objLimitVO = new clsMedicineLimit_VO[dtbEditMedicine.Rows.Count];
                for (int i=0;i<dtbEditMedicine.Rows.Count;i++)
                {
                    if (Convert.ToDouble(dtbEditMedicine.Rows[i]["tiptoplimit_int"]) < Convert.ToDouble(dtbEditMedicine.Rows[i]["neaplimit_int"]))
                    {
                        MessageBox.Show("保存失败,最高限量不能小于最低限量。药品:" + dtbEditMedicine.Rows[i]["medicinename_vchr"].ToString().Trim(), "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_mthLocalizeRow(dtbEditMedicine.Rows[i]["medicineid_chr"].ToString().Trim());
                        return;
                    }
                    objLimitVO[i] = new clsMedicineLimit_VO();
                    objLimitVO[i].m_strMedicineid = dtbEditMedicine.Rows[i]["medicineid_chr"].ToString();
                    objLimitVO[i].m_douTiptopLimit = Convert.ToDouble(dtbEditMedicine.Rows[i]["tiptoplimit_int"]);
                    objLimitVO[i].m_douNeapLimit = Convert.ToDouble(dtbEditMedicine.Rows[i]["neaplimit_int"]);
                }
                long lngRes= m_objDomain.m_lngSaverMedicine(objLimitVO);
                if (lngRes != -1)
                {
                    MessageBox.Show("保存成功", "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("保存失败", "药品限量设置", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        public void m_mthPrint()
        {
            Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();
            dsData.LibraryList = clsPublic.PBLPath;
            dsData.DataWindowObject = "ms_medicinelimit";
            dsData.Retrieve(dtbLimit);
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog_DataStore(dsData, true);
        }
        #endregion

        #region 定位行


        /// <summary>
        /// 定位行

        /// </summary>
        /// <param name="p_strSearch">搜索字符</param>
        internal void m_mthLocalizeRow(string p_strSearch)
        {
            for (int iRow = 0; iRow < m_objViewer.m_dgvDetailInfo.Rows.Count; iRow++)
            {
                if (m_objViewer.m_dgvDetailInfo.Rows[iRow].Cells[0].Value != null
                    && m_objViewer.m_dgvDetailInfo.Rows[iRow].Cells[0].Value.ToString() == p_strSearch)
                {
                    m_objViewer.m_dgvDetailInfo.Rows[iRow].Selected = true;
                    m_objViewer.m_dgvDetailInfo.CurrentCell = m_objViewer.m_dgvDetailInfo.Rows[iRow].Cells[7];
                    //m_objViewer.m_dgvDetailInfo.CurrentCell.Selected = true;
                    break;
                }
            }
        }
        #endregion

        internal void m_mthExit()
        {
            DataTable dtbNew = dtbLimit.GetChanges(DataRowState.Added);
            DataTable dtbEdit = dtbLimit.GetChanges(DataRowState.Modified);
            if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
            {
                DialogResult drResult = MessageBox.Show("当前窗体存在未保存的记录，确定退出?", "药品限价设置", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
            }
            m_objViewer.Close();
        }
    }
}
