using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 按组统计门诊挂号费及诊金报表 界面逻辑控制类
    /// </summary>
    class clsCtl_Report_GroupEarning : com.digitalwave.GUI_Base.clsController_Base
    {
        clsDcl_Report_GroupEarning m_objManage = null;        

        #region 构造函数
        public clsCtl_Report_GroupEarning()
		{
            m_objManage = new clsDcl_Report_GroupEarning();
		}
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmReport_GroupEarning m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmReport_GroupEarning)frmMDI_Child_Base_in;
        }
        #endregion
        internal void m_mthSelectGroupEarning()
        {
            string strBeginDat = m_objViewer.m_dtpBeginDat.Value.ToShortDateString();
            string strEndDat = m_objViewer.m_dtpEndDat.Value.ToShortDateString();
            DataTable m_dtbReport = new DataTable();
            long lngRes = m_objManage.m_lngSelectGroupEarning(strBeginDat, strEndDat, out m_dtbReport);
            bindTable(m_dtbReport);
        }

        private void bindTable(DataTable m_dtbReport)
        {

            m_objViewer.dw_groupearning.Reset();
            m_objViewer.dw_groupearning.SetRedrawOff();

            m_objViewer.dw_groupearning.Modify("bigindatetext.text='" + m_objViewer.m_dtpBeginDat.Value.ToShortDateString() + "'");
            m_objViewer.dw_groupearning.Modify("enddatetext.text='" + m_objViewer.m_dtpEndDat.Value.ToShortDateString() + "'");

            m_objViewer.dw_groupearning.Retrieve(m_dtbReport);

            this.m_objViewer.dw_groupearning.SetRedrawOn();
            this.m_objViewer.dw_groupearning.Refresh();
        }
    }
}
