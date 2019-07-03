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
    /// 统计门诊挂号费及诊金报表 界面逻辑控制类
    /// </summary>
    class clsCtl_Report_DoctorEarning : com.digitalwave.GUI_Base.clsController_Base
    {
        clsDcl_Report_DoctorEarning m_objManage = null;        

        #region 构造函数
        public clsCtl_Report_DoctorEarning()
		{
            m_objManage = new clsDcl_Report_DoctorEarning();
		}
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.Reports.frmReport_DoctorEarning m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmReport_DoctorEarning)frmMDI_Child_Base_in;
        }
        #endregion

        internal void m_mthSelectDoctorEarning()
        {
            DateTime dtBeginDat = m_objViewer.m_dtpBeginDat.Value;
            DateTime dtEndDat = m_objViewer.m_dtpEndDat.Value;
            DataTable m_dtbReport = new DataTable();
            long lngRes = m_objManage.m_lngSelectDoctorEarning(dtBeginDat, dtEndDat, out m_dtbReport);
            bindTable(m_dtbReport);
        }

        private void bindTable(DataTable m_dtbReport)
        {
            m_objViewer.dw_doctorearning.Reset();
            m_objViewer.dw_doctorearning.SetRedrawOff();

            m_objViewer.dw_doctorearning.Modify("bigindatetext.text='"+m_objViewer.m_dtpBeginDat.Value.ToShortDateString()+"'");
            m_objViewer.dw_doctorearning.Modify("enddatetext.text='" + m_objViewer.m_dtpEndDat.Value.ToShortDateString() + "'");

            m_objViewer.dw_doctorearning.Retrieve(m_dtbReport);


            this.m_objViewer.dw_doctorearning.SetRedrawOn();
            this.m_objViewer.dw_doctorearning.Refresh();
        }

    }

}
