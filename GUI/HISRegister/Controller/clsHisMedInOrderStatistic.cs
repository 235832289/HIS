using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
//using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
using com.digitalwave.iCare.ValueObject;	//iCareData.dll
using CrystalDecisions.CrystalReports.Engine;

namespace com.digitalwave.iCare.gui.HIS
{
	#region 药库入库单统计窗体控制类 ：created by weiling.huang  at 2005-9-14
	/// <summary>
	/// 药库入库单统计窗体控制类 ：created by weiling.huang  at 2005-9-14
	/// </summary>
	public class clsHisMedInOrderStatistic: com.digitalwave.GUI_Base.clsController_Base	//GUI_Base.dll
	{
		#region 构造函数
		public clsHisMedInOrderStatistic()
		{
			m_objManage = new clsDomainHisMedInOrderStatistic();
		}
		#endregion

		#region 变量
		/// <summary>
		/// DomainControl对象
		/// </summary>
		private clsDomainHisMedInOrderStatistic m_objManage = null;
		
		/// <summary>
		/// frm窗体对象
		/// </summary>
		private com.digitalwave.iCare.gui.HIS.frmHisMedInOrderStatistic m_objViewer ;


		/// <summary>
		/// 保存当前务期的索引
		/// </summary>
		private int intSelPeriod=-1;

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
			this.m_objViewer = (frmHisMedInOrderStatistic)frmMDI_Child_Base_in;
		}
		#endregion

		#region 窗体时间控件的初始化		
		/// <summary>
		/// 窗体时间控件的初始化		
		/// </summary>
		public void m_mthFrmInit()
		{
			m_mthGetPeriodList();//加载账务期到ComboBox
			
			m_mthButtonClickToStatistic();//默认显示接近系统时间的账务期报表
			
		}
		#endregion

		#region 按账务期统计
		/// <summary>
		/// 按账务期统计		
		/// </summary>
		public void m_mthButtonClickToStatistic()
		{
			string p_strPriodId = "";
			clsPeriod_VO[] objPriodItems = this.m_objViewer.m_cboSelPeriod.Tag as clsPeriod_VO[];
			if(this.m_objViewer.m_cboSelPeriod.SelectedItem == null)
			{
				MessageBox.Show("请选择账务期");
				return ;
			}
			if(this.m_objViewer.m_cboSelPeriod.Text != "所有财务期的数据")
			{
				p_strPriodId = objPriodItems[this.m_objViewer.m_cboSelPeriod.SelectedIndex-1].m_strPeriodID;
			}
			
				DataTable dtbStatistic ;
				long lngRes = 0;
				lngRes = this.m_objManage.m_lngGetStatiticsData(out dtbStatistic,p_strPriodId);
				System.Data.DataColumn dc = new DataColumn("SEQUENCEID");
				dtbStatistic.Columns.Add(dc);
				if(dtbStatistic.Rows.Count != 0)
				{
					for(int j1 = 0;j1<dtbStatistic.Rows.Count; j1++)
					{
						dtbStatistic.Rows[j1]["SEQUENCEID"] = j1+1;
					}
				}
				if(lngRes<0)
				{
					return ;
				}
				else
				{
					CrystalDecisions.CrystalReports.Engine.ReportDocument rpt =new CrystalDecisions.CrystalReports.Engine.ReportDocument();
					rpt.Load("Report\\CrystalReportHisMedInOrderStaticstic.rpt");
//					HISMedTypeManage.Rpt.CrystalReportHisMedInOrderStaticstic rpt = new HISMedTypeManage.Rpt.CrystalReportHisMedInOrderStaticstic();
					((TextObject)rpt.ReportDefinition.ReportObjects["Text11"]).Text = this.m_objViewer.m_cboSelPeriod.SelectedText;
					double totalMoney = 0;
					if(dtbStatistic.Rows.Count>0)
					{
						
						for(int i1=0;i1<dtbStatistic.Rows.Count;i1++)
						{
							totalMoney += Convert.ToDouble(dtbStatistic.Rows[i1]["TOLMNY_MNY"].ToString().Trim());
						
						}						
						
						//((TextObject)rpt.ReportDefinition.ReportObjects["Text9"]).Text = totalMoney.ToString("######.00");
					}
					else
					{
								
						//((TextObject)rpt.ReportDefinition.ReportObjects["Text9"]).Text = "0.00";
					}
					
					((TextObject)rpt.ReportDefinition.ReportObjects["Text11"]).Text = this.m_objViewer.m_cboSelPeriod.Text;
					rpt.SetDataSource(dtbStatistic);
					rpt.Refresh();
					this.m_objViewer.m_crystalReportViewer1.ReportSource = rpt;
				}
						
		}
		#endregion

		#region 获得帐务期列表，并加入Combox
		/// <summary>
		/// 获得帐务期列表，并加入Combox
		/// </summary>
		private void m_mthGetPeriodList()
		{	
			clsPeriod_VO[] objPriodItems ;
			 this.m_objManage.m_lngGetPeriodList(out objPriodItems); //获得帐务期列表
			string nowdate= this.m_objManage.m_dtmGetServerDate().Date.ToString();//获取系统时间
			if(objPriodItems.Length >0)
			{
				
				this.m_objViewer.m_cboSelPeriod.Items.Insert(0,"所有财务期的数据");
				for(int i1=0;i1<objPriodItems.Length;i1++)
				{
					

					string strBegin = Convert.ToDateTime(objPriodItems[i1].m_strStartDate).Date.ToShortDateString() ;
					string strEnd = Convert.ToDateTime(objPriodItems[i1].m_strEndDate).Date.ToShortDateString() ;
					this.m_objViewer.m_cboSelPeriod.Items.Insert(i1+1,strBegin + " 至 " + strEnd);
					if(Convert.ToDateTime(nowdate)>=Convert.ToDateTime(objPriodItems[i1].m_strStartDate)&&Convert.ToDateTime(nowdate)<=Convert.ToDateTime(objPriodItems[i1].m_strEndDate))
					{
						intSelPeriod = i1+1;
						
					}
					
					this.m_objViewer.m_cboSelPeriod.Tag = objPriodItems;
				}
				
				if(intSelPeriod!=-1)
				{
					m_objViewer.m_cboSelPeriod.SelectedIndex = intSelPeriod;
				}
				else
				{
					MessageBox.Show("没有账务期!","系统提示");
				}
				
			}
		}
		#endregion

	}
	#endregion

}
