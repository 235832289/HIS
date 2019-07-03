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
	class clsCtl_PatientDebtReport : com.digitalwave.GUI_Base.clsController_Base
	{
		com.digitalwave.iCare.gui.HIS.clsDcl_StatQuery objSvc;
		private CrystalDecisions.CrystalReports.Engine.ReportDocument rptInHospitalLog;
		com.digitalwave.iCare.gui.HIS.frmPatientDebtReport m_objViewer;
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmPatientDebtReport)frmMDI_Child_Base_in;
		}
		public clsCtl_PatientDebtReport()
		{
			objSvc = new clsDcl_StatQuery();
		}
		#region 载入科室对应的病区
		/// <summary>
		/// 载入科室对应的病区
		/// </summary>
		public void LoadAreaID()
		{
			m_objViewer.lsvAreaInfo.Items.Clear();
			com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] DataResultArr =null;
			string strFilter = "WHERE ATTRIBUTEID = '0000003' AND STATUS_INT = 1 AND (shortno_chr LIKE '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or DEPTNAME_VCHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or PYCODE_CHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%' or WBCODE_CHR like '"+m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()+"%')";
			System.Windows.Forms.ListViewItem FindItem;
			long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfo(strFilter,out DataResultArr);
			if(lngRes>0&&DataResultArr.Length >0)
			{
				#region 在病区里增加一个全院选项	glzhang	2005.07.26
				FindItem = new ListViewItem("");
				FindItem.SubItems.Add("全院");
				FindItem.Tag = "";
				m_objViewer.lsvAreaInfo.Items.Add(FindItem);
				#endregion

				for(int i = 0;i<DataResultArr.Length;i++)
				{
					FindItem = new ListViewItem(DataResultArr[i].m_strDEPTID_CHR);
					FindItem.SubItems.Add(DataResultArr[i].m_strDEPTNAME_VCHR);
					FindItem.Tag = DataResultArr[i];
					m_objViewer.lsvAreaInfo.Items.Add(FindItem);
				}
			}
		}
		#endregion
		/// <summary>
		/// 病区病人欠费一览表
		/// </summary>
		public void m_mthShowInHospitalDebtLog()
		{
			if(this.m_objViewer.m_txtAREAID_CHR.Tag==null)
			{
				this.m_objViewer.m_txtAREAID_CHR.Tag="";
				this.m_objViewer.m_txtAREAID_CHR.Text="全院";
			}
			this.m_objViewer.Cursor = Cursors.WaitCursor;
			DataTable dtbResult =new DataTable();
			rptInHospitalLog = new ReportDocument();
			rptInHospitalLog.Load(@"Report\rptDebtView.rpt");
			rptInHospitalLog.DataDefinition.FormulaFields["AreaName"].Text = "'"+this.m_objViewer.m_txtAREAID_CHR.Text.Trim()+"'";
			rptInHospitalLog.DataDefinition.FormulaFields["StatDate"].Text = "'"+this.m_objViewer.m_StatDate.Value.ToShortDateString()+"'";
			rptInHospitalLog.DataDefinition.FormulaFields["operatorname"].Text = "'"+this.m_objViewer.LoginInfo.m_strEmpName+"'";
			int type = -1;
			if(this.m_objViewer.radioButton1.Checked)
			{
				type = 1;
			}
			if(this.m_objViewer.radioButton2.Checked)
			{
				type = 0;
			}
			long lngRes  = objSvc.m_lngGetPatientDebt(type,(string)this.m_objViewer.m_txtAREAID_CHR.Tag,"",this.m_objViewer.m_StatDate.Value,"","",out dtbResult);
			if(lngRes>0)
			{
				rptInHospitalLog.SetDataSource(dtbResult);
				this.m_objViewer.m_ctrvPatientDebtReport.ReportSource = rptInHospitalLog;
			}
			this.m_objViewer.Cursor = Cursors.Default;
		}
	}
		
}