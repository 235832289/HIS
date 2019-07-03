using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;


namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 系统错误信息记录
	/// 作者： Cameron Wong
	/// 时间： Aug 12, 2004
	/// </summary>
	public class clsCtl_ErrorLog : com.digitalwave.GUI_Base.clsController_Base
	{
		clsDcl_HISInfoDefine clsDomain;

		public clsCtl_ErrorLog()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain = new clsDcl_HISInfoDefine();
		}

		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmErrorLog m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmErrorLog)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取系统错误信息
		/// <summary>
		/// 获取系统错误信息
		/// </summary>
		public void m_GetErrorLog()
		{
			m_objViewer.m_lsv.Items.Clear();
			DataTable dtbResult;
/*				= new DataTable();
			for (int i = 0; i < 13; i++)
				dtbResult.Columns.Add();	*/
			long lngRes = clsDomain.m_lngFindErrorLogList(out dtbResult);
			if (lngRes > 0 && dtbResult.Rows.Count > 0)
			{
				ListViewItem lvi;
				for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
				{
					lvi = new ListViewItem();
					for (int j = 0; j < 6; j++)
						lvi.SubItems.Add(dtbResult.Rows[i1].ItemArray[j].ToString());
					// join first name and last name
					lvi.SubItems.Add(dtbResult.Rows[i1].ItemArray[6].ToString() + ' ' + dtbResult.Rows[i1].ItemArray[7].ToString());
					for (int j = 8; j < 13; j++)
						lvi.SubItems.Add(dtbResult.Rows[i1].ItemArray[j].ToString());
					m_objViewer.m_lsv.Items.Add(lvi);
				}
			}
			if (m_objViewer.m_lsv.Items.Count > 0)
				m_objViewer.m_lsv.Items[0].Selected = true;
		}
		#endregion

		#region 删除
		public void m_DeleteAll()
		{
			if (m_objViewer.m_lsv.Items.Count == 0 || m_objViewer.m_lsv.SelectedItems == null)
				return;
			if(MessageBox.Show("确认删除所有记录吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.No)
				return;
			long lngRes = clsDomain.m_lngDelAllErrorLog();
		}
		#endregion

		#region Print created by Cameron Wong on Aug 13, 2004
		/// <summary>
		/// Print the error log
		/// </summary>
		public void m_Print()
		{
			try
			{
				DataSet dsErrLog = new DataSet();
				DataTable dtbErrLog = new DataTable("element1");
				CrystalDecisions.CrystalReports.Engine.ReportDocument rdtErrLog = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
				rdtErrLog.Load("Report\\crpErrorLog.rpt");
				string columnName1, columnType1;
				for (int i = 0; i < rdtErrLog.Database.Tables[0].Fields.Count; i++)
				{
					columnName1 = rdtErrLog.Database.Tables[0].Fields[i].Name.ToString();
					columnType1 = rdtErrLog.Database.Tables[0].Fields[i].GetType().ToString();
					dtbErrLog.Columns.Add(columnName1, rdtErrLog.Database.Tables[0].Fields[i].GetType());
				}
//					dtbErrLog.Columns.Add(rdt);
				DataRow dtrNewRow;
				//insert data**********************************************
				for (int lines = 0; lines < m_objViewer.m_lsv.Items.Count; lines++)
				{
					dtrNewRow = dtbErrLog.NewRow();
					for (int i = 0; i < 12; i++)
					{
						dtrNewRow[i] = m_objViewer.m_lsv.Items[lines].SubItems[i+1].Text;
					}
/*					dtrNewRow[6] = m_objViewer.m_lsv.Items[lines].SubItems[7].Text
						+ m_objViewer.m_lsv.Items[lines].SubItems[8].Text;
					for (int i = 7; i < 12; i++)
						dtrNewRow[i] = m_objViewer.m_lsv.Items[lines].SubItems[i+2].Text;
*/					for (int i = 12; i < 12 + 9; i++)
						dtrNewRow[i] = "";
					for (int i = 12+9; i < 12+18; i++)
						dtrNewRow[i] = 0;
					dtbErrLog.Rows.Add(dtrNewRow);
				}
			
				dsErrLog.Tables.Add(dtbErrLog);
				rdtErrLog.SetDataSource(dsErrLog);
//				CommonClassReport.clsReport ObjDemo = new CommonClassReport.clsReport();
				
				m_objViewer.m_crvTemp.ReportSource = rdtErrLog;
				m_objViewer.m_crvTemp.PrintReport();
			}
			catch
			{
				MessageBox.Show("打印故障！","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		}
		#endregion

	}
}