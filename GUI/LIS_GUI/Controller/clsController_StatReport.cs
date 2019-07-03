using System;
using System.Data;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using com.digitalwave.iCare.gui.LIS.Report;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsController_StatReport 的摘要说明。
	/// </summary>
	public class clsController_StatReport: com.digitalwave.GUI_Base.clsController_Base
	{
		com.digitalwave.iCare.gui.LIS.frmStatReport m_objViewer;
		com.digitalwave.iCare.gui.LIS.clsDomainController_StatManage m_objManage;
		#region 构造函数
		public clsController_StatReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDomainController_StatManage();
		}
		#endregion

		#region 设置窗体对象
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			m_objViewer = (frmStatReport)frmMDI_Child_Base_in;
		}
		#endregion

		#region 根据条件生成报表 童华 2004.09.22
		public void m_mthCreateReport()
		{
			m_objViewer.m_btnQuery.Enabled = false;
			m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
			long lngRes = 0;
			string strDatFrom = m_objViewer.m_dtpDatFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");		//xing.chen modify for 为统计查询增加时间
            string strDatTo = m_objViewer.m_dtpDatTo.Value.ToString("yyyy-MM-dd HH:mm:ss");			//xing.chen modify for 为统计查询增加时间
			string strOprID = m_objViewer.m_txtOprDoct.m_StrEmployeeID;
			DataTable dtbResult = null;

			CrystalDecisions.CrystalReports.Engine.ReportDocument objReportDoc = new ReportDocument();

			try
			{
				if(m_objViewer.m_cboReport.SelectedIndex == 0)
				{
					#region 工作量汇总
					lngRes = m_objManage.m_lngGetStatTotalReport(strDatFrom,strDatTo,strOprID,out dtbResult);
					if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
					{
						//					cryStatTotalReport objReport = new cryStatTotalReport();
						//					objReport.SetDataSource(dtbResult);
						try
						{
							objReportDoc.Load(@"lis_reports\cryStatTotalReport.rpt");
							objReportDoc.SetDataSource(dtbResult);
						}
						catch
						{
							MessageBox.Show("加载报表失败！");
						}
					}
					else
					{
						MessageBox.Show("没有符合条件的记录！");
						return;
					}
					#endregion
				}
				else if(m_objViewer.m_cboReport.SelectedIndex == 1)
				{
					#region 工作量明细
					lngRes = m_objManage.m_lngGetStatDetailReport(strDatFrom,strDatTo,strOprID,out dtbResult);
					if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
					{
						//					cryStatDetailReport objReport = new cryStatDetailReport();
						//					objReport.SetDataSource(dtbResult);
						try
						{
							objReportDoc.Load(@"lis_reports\cryStatDetailReport.rpt");

                            objReportDoc.SetDataSource(dtbResult);
						}
						catch
						{
							MessageBox.Show("加载报表失败！");
						}

						//					//传送参数
						//					for(int i=0;i<=paramValues.Count-1;i++)
						//					{	
						//						paramValue.Clear();
						//						paramValue.Add(paramValues[i]);
						//						objReport.DataDefinition.ParameterFields[i].ApplyCurrentValues(paramValue);
						//					}
						//					m_objViewer.m_ReportViewer.ReportSource = objReport;
						//					m_objViewer.m_ReportViewer.RefreshReport();
					}
					else
					{
						MessageBox.Show("没有符合条件的记录！");
						return;
					}
					#endregion
				}
				else if(m_objViewer.m_cboReport.SelectedIndex == 2)
				{
					#region 检验费用汇总
					lngRes = m_objManage.m_lngGetCheckPriceTotalReport(strDatFrom,strDatTo,strOprID,out dtbResult);
					if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
					{
						//					cryCheckPriceTotalReport objReport = new cryCheckPriceTotalReport();
						//					objReport.SetDataSource(dtbResult);
						try
						{
							objReportDoc.Load(@"lis_reports\cryCheckPriceTotalReport.rpt");
							objReportDoc.SetDataSource(dtbResult);
						}
						catch
						{
							MessageBox.Show("加载报表失败！");
						}

						//					//传送参数
						//					for(int i=0;i<=paramValues.Count-1;i++)
						//					{	
						//						paramValue.Clear();
						//						paramValue.Add(paramValues[i]);
						//						objReport.DataDefinition.ParameterFields[i].ApplyCurrentValues(paramValue);
						//					}
						//					m_objViewer.m_ReportViewer.ReportSource = objReport;
						//					m_objViewer.m_ReportViewer.RefreshReport();
					}
					else
					{
						MessageBox.Show("没有符合条件的记录！");
						return;
					}
					#endregion
				}
				else if(m_objViewer.m_cboReport.SelectedIndex == 3)
				{
					#region 检验费用明细
					lngRes = m_objManage.m_lngGetCheckPriceDetailReport(strDatFrom,strDatTo,strOprID,out dtbResult);
					if(lngRes > 0 && dtbResult != null && dtbResult.Rows.Count > 0)
					{
						//					cryCheckPriceDetailReport objReport = new cryCheckPriceDetailReport();
						//					objReport.SetDataSource(dtbResult);
						try
						{
							objReportDoc.Load(@"lis_reports\cryCheckPriceDetailReport.rpt");
							objReportDoc.SetDataSource(dtbResult);
						}
						catch
						{
							MessageBox.Show("加载报表失败！");
						}

						//					//传送参数
						//					for(int i=0;i<=paramValues.Count-1;i++)
						//					{	
						//						paramValue.Clear();
						//						paramValue.Add(paramValues[i]);
						//						objReport.DataDefinition.ParameterFields[i].ApplyCurrentValues(paramValue);
						//					}
						//					m_objViewer.m_ReportViewer.ReportSource = objReport;
						//					m_objViewer.m_ReportViewer.RefreshReport();
					}
					else
					{
						MessageBox.Show("没有符合条件的记录！");
						return;
					}
					#endregion
				}
				#region 传送参数
                ////传送参数
                //ParameterValues paramValues=new ParameterValues();
                ////定义参数
                //ParameterDiscreteValue discreteVal = new ParameterDiscreteValue();//
                //discreteVal.Value=m_objViewer.m_dtpDatFrom.Value.ToShortDateString();
                //paramValues.Add(discreteVal);
                //discreteVal=new ParameterDiscreteValue();//
                //discreteVal.Value=m_objViewer.m_dtpDatTo.Value.ToShortDateString();
                //paramValues.Add(discreteVal);
		
                ////将参数加入集合
                //discreteVal.Kind =DiscreteOrRangeKind.DiscreteValue;
                //ParameterValues paramValue=new ParameterValues();

                ////传送参数
                //for(int i=0;i<=paramValues.Count-1;i++)
                //{	
                //    paramValue.Clear();
                //    paramValue.Add(paramValues[i]);
                //    objReportDoc.DataDefinition.ParameterFields[i].ApplyCurrentValues(paramValue);
                //}

                objReportDoc.SetParameterValue(0, strDatFrom.Substring(0,16));
                objReportDoc.SetParameterValue(1, strDatTo.Substring(0, 16));
                #endregion            

				m_objViewer.m_ReportViewer.ReportSource = objReportDoc;
                //m_objViewer.m_ReportViewer.RefreshReport(); 加上此句则会使之前已设置的参数失效。
			}
			catch(Exception objEx)
			{
			}
			finally
			{
				m_objViewer.m_btnQuery.Enabled = true;
				m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
			}
		}
		#endregion

        #region 仪器工作量统计报表
        /// <summary>
        /// 仪器工作量统计报表
        /// baojian.mo add in 2007.12.01
        /// </summary>
        /// <param name="p_datStart"></param>
        /// <param name="p_datEnd"></param>
        /// <param name="p_dtDevice"></param>
        public void m_mthGetDeviceCheckTotal(DateTime p_datStart, DateTime p_datEnd, ref DataTable p_dtDevice)
        {
            m_objManage.m_mthGetDeviceCheckStatis(p_datStart, p_datEnd, ref p_dtDevice);
        }        
        #endregion


    }
}
