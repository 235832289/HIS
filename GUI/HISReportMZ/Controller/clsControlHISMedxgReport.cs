using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
//using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
using com.digitalwave.iCare.ValueObject;	//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// clsControlHISMedxgReport ��ժҪ˵����
	/// </summary>
	public class clsControlHISMedxgReport : com.digitalwave.GUI_Base.clsController_Base	//GUI_Base.dll
	{
		public clsControlHISMedxgReport()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			
			//
		}
		//clsDomainControlChangPrice objSVC=new clsDomainControlChangPrice();
		private clsDomainControlHISMedxgReport Obj_Manage=new clsDomainControlHISMedxgReport();
		#region ���ô������
		/// <summary>
		/// �������
		/// </summary>
		frmHISMedTypexgReport m_objViewer;
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			m_objViewer = (frmHISMedTypexgReport)frmMDI_Child_Base_in;
		}
		#endregion
        
		#region ͳ��
		public void Statistic()
		{
			DataTable dt;
			long lngs=0;
			string m_strStartDateTimer;
			string m_strEndDateTimer;
			m_strStartDateTimer=this.m_objViewer.m_dtpStartDate.Value.ToString();
			m_strEndDateTimer=this.m_objViewer.m_dtpEndDate.Value.ToString();
			lngs=this.Obj_Manage.m_lngGetMedReport(m_strStartDateTimer, m_strEndDateTimer,out dt);
			if(dt.Rows.Count==0)
			{
				MessageBox.Show("���ݿ��޼�¼ ");
				return;
			}
			if(lngs<0)
			{
				return;
			}
            HISReportMZ.Rpt.CrystalRptCharge rpt = new HISReportMZ.Rpt.CrystalRptCharge();
			rpt.SetDataSource(dt);
			rpt.Refresh();
			this.m_objViewer.crystalReportViewer1.ReportSource = rpt;

		}	
		#endregion

	}
}
