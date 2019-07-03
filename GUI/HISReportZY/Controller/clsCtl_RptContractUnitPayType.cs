using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Sybase.DataWindow;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS.Reports 
{
    class clsCtl_RptContractUnitPayType : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 医院名称
        /// </summary>
        internal string strHospitalName = "";
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.Reports.frmRptContractUnitPayType m_objViewer;

        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_ReportZY objSvc;
        public clsCtl_RptContractUnitPayType()
        {
            objSvc = new clsDcl_ReportZY();
            com.digitalwave.iCare.common.clsCommmonInfo objCommonInfo = new com.digitalwave.iCare.common.clsCommmonInfo();
            strHospitalName = objCommonInfo.m_strGetHospitalTitle();
            
        }
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmRptContractUnitPayType)frmMDI_Child_Base_in;
        }
        #endregion


        #region 查询

        internal void m_mthSelect()
        {
            clsPublic.PlayAvi("正在查询中,请稍候.............");
            string strStratDate = this.m_objViewer.m_dtpStartDate.Value.ToString("yyyy-MM-dd")+" 00:00:00";
            string strEndDate = this.m_objViewer.m_dtpEndDate.Value.ToString("yyyy-MM-dd")+" 23:59:59";
            
            DataTable dtbResult = new DataTable();
            long lngRes = objSvc.m_lngContractUnitPayType(strStratDate, strEndDate, out dtbResult);
            if(lngRes>0&&dtbResult.Rows.Count>0)
            {

                this.m_objViewer.m_dwreport.Modify("t_date.text='" + strStratDate + "至" + strEndDate + "'");
                this.m_objViewer.m_dwreport.SetRedrawOff();

                this.m_objViewer.m_dwreport.Retrieve(dtbResult);
               
                this.m_objViewer.m_dwreport.SetRedrawOn();
                this.m_objViewer.m_dwreport.Refresh();
            }
            clsPublic.CloseAvi();
        }
        #endregion
    }
}
