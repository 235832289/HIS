using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public class clsCtl_ResultReport : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_ResultReport m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        private frmResultReport m_objViewer;


        /// <summary>
        /// 明细表记录

        /// </summary>
        DataTable dtbStorageCheck_detail = null;
        /// <summary>
        /// 当前药品出库主表信息
        /// </summary>
        private clsMS_StorageCheck_VO m_objStorageCheck = null;

        #endregion

        #region 构造函数


        /// <summary>
        /// 盘点主表
        /// </summary>
        public clsCtl_ResultReport()
        {
            m_objDomain = new clsDcl_ResultReport();
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
            m_objViewer = (frmResultReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        internal void m_mthGetStorageCheck()
        {
            DateTime dtmBegin = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpBeginDatePage1.Text).ToString("yyyy-MM-dd 00:00:00"));
            DateTime dtmEnd = Convert.ToDateTime(Convert.ToDateTime(m_objViewer.m_dtpEndDatePage1.Text).ToString("yyyy-MM-dd 23:59:59"));
            m_objDomain.m_lngGetStorageCheck(dtmBegin, dtmEnd, m_objViewer.m_strStorageID, out m_objViewer.dtbStorageCheck);
           
            DataView dtv = new DataView();
            dtv = m_objViewer.dtbStorageCheck.DefaultView;
            dtv.Sort = "inaccountdate_dat desc";
            m_objViewer.dtbStorageCheck = dtv.ToTable();

            m_objViewer.m_dgvMainInfo.DataSource = m_objViewer.dtbStorageCheck;
            

        }
        #endregion

        #region 获取明细表内容
        /// <summary>
        /// 获取明细表内容
        /// </summary>
        internal void m_mthGetStorageCheck_detail()
        {
            m_objDomain.m_lngGetStorageCheck_detail(Convert.ToInt64(m_objViewer.m_dgvMainInfo.Rows[m_objViewer.m_dgvMainInfo.CurrentCell.RowIndex].Cells[4].Value), out dtbStorageCheck_detail);
            dtbStorageCheck_detail.DefaultView.RowFilter = "CHECKRESULT_INT <> 0";

            if (dtbStorageCheck_detail.DefaultView.ToTable().Rows.Count == 0)
            {
                MessageBox.Show("该盘点单号没有差额数据！", "药品差额统计表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                m_objViewer.datWindow.Reset();
                return;
            }
            m_objViewer.datWindow.Modify("t_strstoragename.text='" + m_objViewer.m_strStorageName + "'");
            m_objViewer.datWindow.Modify("t_askername.text='" + m_objViewer.m_dgvMainInfo.Rows[m_objViewer.m_dgvMainInfo.CurrentCell.RowIndex].Cells[2].Value + "'");
            m_objViewer.datWindow.Modify("t_fhr.text='" + m_objViewer.m_dgvMainInfo.Rows[m_objViewer.m_dgvMainInfo.CurrentCell.RowIndex].Cells[3].Value + "'");

            m_objViewer.datWindow.SetRedrawOff();
            m_objViewer.datWindow.Retrieve(dtbStorageCheck_detail.DefaultView.ToTable());
            m_objViewer.datWindow.SetRedrawOn();
            m_objViewer.datWindow.Refresh();
        }
        #endregion

        #region 获取仓库名
        internal void m_mthGetStoreRoomName(out string strStorageName)
        {
            m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStorageName);
        }
        #endregion
    }
}
