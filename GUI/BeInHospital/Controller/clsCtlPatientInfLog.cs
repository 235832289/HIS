using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 
    /// </summary>
    public class clsCtlPatientInfLog : com.digitalwave.GUI_Base.clsController_Base
    {
        com.digitalwave.iCare.gui.HIS.clsDcl_BIHTransfer m_objMain;
        
        DataView m_dvFilter;

		#region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmPatientInfLog m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPatientInfLog)frmMDI_Child_Base_in;
		}
		#endregion
		/// <summary>
		/// 构造函数
		/// </summary>
        public clsCtlPatientInfLog()
		{
            m_objMain = new clsDcl_BIHTransfer();
		}

        internal void GetPatienInfLog()
        {
            
            this.m_dvFilter = null;

            DateTime startDate = DateTime.Parse(this.m_objViewer.m_dtpBeginDate.Value.ToShortDateString() + " 00:00:00");
            DateTime endDate = DateTime.Parse(this.m_objViewer.m_dtpEndDate.Value.ToShortDateString() + " 23:59:59");

            long lngRet = 0;
            DataTable dt;
            lngRet = this.m_objMain.GetPatienInfLog(startDate, endDate, out dt);
            if (lngRet > 0 && dt.Rows.Count > 0)
            {
                this.m_dvFilter = new DataView(dt);

                DwRetrieve();
            }
        }

        internal void DwRetrieve()
        {
            this.m_objViewer.m_dwLog.SetRedrawOff();
            this.m_objViewer.m_dwLog.Reset();

            if (this.m_dvFilter == null)
            {
                this.m_objViewer.m_dwLog.SetRedrawOn();
                return;
            }

            string strInpatientId = this.m_objViewer.m_txtInPatientId.Text.Trim();
            if (strInpatientId != null && strInpatientId != "")
            {
                m_dvFilter.RowFilter = "inpatientid_chr = '" + strInpatientId + "'";
            }
            else
            {
                m_dvFilter.RowFilter = "1=1";
            }

            this.m_objViewer.m_dwLog.Retrieve(m_dvFilter.ToTable());

            this.m_objViewer.m_dwLog.SetRedrawOn();
            this.m_objViewer.m_dwLog.Refresh();
        }
    }
}
