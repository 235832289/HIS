using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
	/// <summary>
	/// clsControlReckoningReport 的摘要说明。
	/// </summary>
	public class clsControlPublicPayReport:com.digitalwave.GUI_Base.clsController_Base
	{
		private CrystalDecisions.CrystalReports.Engine.ReportDocument m_rptRpt;
		clsDcl_ReckoningReport clsDomain;
		string str_firstDate,str_toDate;
		int m_intFindType;
		
		public clsControlPublicPayReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_rptRpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
			clsDomain = new clsDcl_ReckoningReport();
			
		}
		
		#region 设置窗体对象	张国良	 2004-9-9
        com.digitalwave.iCare.gui.HIS.Reports.frmPublicPayReport m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmPublicPayReport)frmMDI_Child_Base_in;

			
		}
		#endregion

		#region 报表数据  张国良	 2004-9-14
		public  void m_mthFindByDateReport()
		{
			

			str_firstDate=m_objViewer.m_daFinDate.Value.ToShortDateString();
			str_toDate = m_objViewer.m_toDate.Value.ToShortDateString();
			
			m_rptRpt.Load("Report\\rptPublicPay.rpt");
			((TextObject)m_rptRpt.ReportDefinition.ReportObjects["txtReportTitle"]).Text = this.m_objComInfo.m_strGetHospitalTitle()+"公费费用报表";
			DataTable m_dtRpt = new DataTable();
			DataTable m_dtRptDitial = new DataTable();
			if(m_objViewer.m_chbPatienName.Checked==true&&m_objViewer.m_chbDate.Checked==true)
			m_intFindType=1;
			else if(m_objViewer.m_chbPatienName.Checked==true&&m_objViewer.m_chbDate.Checked==false)
			m_intFindType=2;
			else if(m_objViewer.m_chbPatienName.Checked==false&&m_objViewer.m_chbDate.Checked==true) 
			m_intFindType=3;
			else
				m_intFindType=4;

				long lngRes;
			lngRes = clsDomain.m_lngPublicPayReport(m_intFindType,m_objViewer.m_txtName.Text.Trim(),str_firstDate,str_toDate,out m_dtRpt);
			if(lngRes>=1)
			{
				m_rptRpt.SetDataSource(m_dtRpt);
				m_rptRpt.Refresh();
				m_objViewer.cryReportViewer.ReportSource=m_rptRpt;
			}
			
			
		}
		#endregion

		#region 查找病人信息
		public void m_mthFindPatientInfo(int intflag,string strValue)
		{
			DataTable dt =null;
			long strRet=clsDomain.m_mthFindPatientInfo(intflag,strValue,out dt);
			if(strRet>0&&dt.Rows.Count>0)
			{
				this.m_objViewer.listView1.Items.Clear();
				for(int i=0;i<dt.Rows.Count;i++)
				{
					ListViewItem lv =new ListViewItem(dt.Rows[i]["PATIENTCARDID_CHR"].ToString().Trim());
					lv.SubItems.Add(dt.Rows[i]["FIRSTNAME_VCHR"].ToString().Trim());
					lv.SubItems.Add(dt.Rows[i]["SEX_CHR"].ToString().Trim());
					string stryear=dt.Rows[i]["BIRTH_DAT"].ToString().Substring(0,4);
					int year=DateTime.Now.Year-int.Parse(stryear);
					lv.SubItems.Add(year.ToString());
					lv.SubItems.Add(dt.Rows[i]["PATIENTID_CHR"].ToString().Trim());
					this.m_objViewer.listView1.Items.Add(lv);
				}
				this.m_objViewer.listView1.Visible=true;
				this.m_objViewer.listView1.BringToFront();
				this.m_objViewer.listView1.Items[0].Selected=true;
				this.m_objViewer.listView1.Select();
			}

		}
		#endregion

		#region 双击事件
		public void m_mthListViewDoubleClick()
		{
			if(this.m_objViewer.listView1.SelectedItems.Count==1)
			{
				this.m_objViewer.txtCardID.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[0].Text.Trim();
				this.m_objViewer.m_txtName.Text=this.m_objViewer.listView1.SelectedItems[0].SubItems[1].Text.Trim();
				this.m_objViewer.listView1.Hide();
				this.m_objViewer.m_txtName.Focus();
			}
		}
		#endregion

	}
}
