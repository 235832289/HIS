using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
//using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
using com.digitalwave.iCare.ValueObject;	//iCareData.dll
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
	#region 门诊收费核算分类组成报表窗体控制类
	/// <summary>	
	/// 门诊收费核算分类组成报表窗体控制类
	/// Create 黄伟灵 by 2005-09-13
	/// </summary>
	public class clsOutPatient: com.digitalwave.GUI_Base.clsController_Base	//GUI_Base.dll
	{
		#region 构造函数
		public clsOutPatient()
		{
			m_objManage = new clsDomainControlOutPatient();
			
		}
		#endregion
		
		#region 变量
		/// <summary>
		/// DomainControl对象
		/// </summary>
		private clsDomainControlOutPatient m_objManage = null;
		
		/// <summary>
		/// frm窗体对象
		/// </summary>
        private com.digitalwave.iCare.gui.HIS.Reports.frmOutPatient m_objViewer;

		#endregion

		#region 设置窗体对象，override Set_GUI_Apperance 实现
		
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			// TODO:  添加 Set_GUI_Apperance 实现
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmOutPatient)frmMDI_Child_Base_in;
		}
		#endregion

		#region 窗体时间控件的初始化		
		/// <summary>
		/// 窗体时间控件的初始化		
		/// </summary>
		public void m_mthFrmInit()
		{
			DateTime dtm = this.m_objManage.m_dtmGetServerDate();
			this.m_objViewer.m_dateTimePickerbegin.Value = Convert.ToDateTime(dtm.Year.ToString()+"-"+dtm.Month.ToString()+"-"+"01");;
			this.m_objViewer.m_dateTimePickerEnd.Value = dtm;
			//m_mthButtonClickToStatistic();
		}
		#endregion

		#region 统计操作
		/// <summary>
		/// 统计操作
		/// </summary>
		public void m_mthButtonClickToStatistic()
		{
			DataTable dtbStatistic;
			string dtmStart = this.m_objViewer.m_dateTimePickerbegin.Value.ToShortDateString();
			string dtmEnd = this.m_objViewer.m_dateTimePickerEnd.Value.ToShortDateString();
			long lngRes = this.m_objManage.m_lngGetStatiticsData(dtmStart, dtmEnd, out dtbStatistic);
			if(lngRes<0)
			{
				return ;
			}
			else
			{
                HISReportMZ.Rpt.CrystalReportOutPatient rpt = new HISReportMZ.Rpt.CrystalReportOutPatient();
				((TextObject)rpt.ReportDefinition.ReportObjects["Text7"]).Text = this.m_objViewer.m_dateTimePickerbegin.Value.ToShortDateString();
				((TextObject)rpt.ReportDefinition.ReportObjects["Text8"]).Text = this.m_objViewer.m_dateTimePickerEnd.Value.ToShortDateString();

				if(dtbStatistic.Rows.Count>0)
				{
					double totalMoney = 0;
					for(int i1=0;i1<dtbStatistic.Rows.Count;i1++)
					{
						totalMoney += Convert.ToDouble(dtbStatistic.Rows[i1]["TOTALMONEY"].ToString().Trim());
						
					}
					((TextObject)rpt.ReportDefinition.ReportObjects["Text13"]).Text = totalMoney.ToString();
				}
				else
				{
					MessageBox.Show("此时间段无统计数据！");					
					return ;
				}
				//((TextObject)rpt.ReportDefinition.ReportObjects["Text13"]).Text = 
				rpt.SetDataSource(dtbStatistic);
				rpt.Refresh();
				this.m_objViewer.m_crystalReportViewer1.ReportSource = rpt;
			}
		}
		#endregion

	}
	#endregion
}
