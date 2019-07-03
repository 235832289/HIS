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
	/// 用户登陆信息
	/// 作者： Cameron Wong
	/// 时间： Aug 16, 2004
	/// </summary>
	public class clsCtl_LoginInfo : com.digitalwave.GUI_Base.clsController_Base
	{
		clsDcl_HISInfoDefine clsDomain;

		public clsCtl_LoginInfo()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain = new clsDcl_HISInfoDefine();
		}

		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmLoginInfo m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmLoginInfo)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取用户登陆信息
		/// <summary>
		/// 获取用户登陆信息
		/// </summary>
		public void m_GetLoginInfo()
		{
			m_objViewer.m_lsv.Items.Clear();
			DataTable dtbResult;
			long lngRes = clsDomain.m_lngFindLoginInfoList(out dtbResult);
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
			long lngRes = clsDomain.m_lngDelAllLoginInfo();
		}
		#endregion

		#region Print created by Cameron Wong on Aug 16, 2004
		/// <summary>
		/// Print the error log
		/// </summary>
		public void m_Print()
		{
			try
			{
				DataSet dsLoginInfo = new DataSet();
				DataTable dtbLoginInfo = new DataTable("element1");
				CrystalDecisions.CrystalReports.Engine.ReportDocument rdtLoginInfo = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
				rdtLoginInfo.Load("Report\\crpLoginInfo.rpt");
				string columnName1;
				for (int i = 0; i < rdtLoginInfo.Database.Tables[0].Fields.Count; i++)
				{
					columnName1 = rdtLoginInfo.Database.Tables[0].Fields[i].Name.ToString();
					dtbLoginInfo.Columns.Add(columnName1, rdtLoginInfo.Database.Tables[0].Fields[i].GetType());
				}
				//					dtbErrLog.Columns.Add(rdt);
				DataRow dtrNewRow;
				//insert data**********************************************
				for (int lines = 0; lines < m_objViewer.m_lsv.Items.Count; lines++)
				{
					dtrNewRow = dtbLoginInfo.NewRow();
					for (int i = 0; i < 7; i++)
					{
						dtrNewRow[i] = m_objViewer.m_lsv.Items[lines].SubItems[i+1].Text;
					}
					/*					dtrNewRow[6] = m_objViewer.m_lsv.Items[lines].SubItems[7].Text
											+ m_objViewer.m_lsv.Items[lines].SubItems[8].Text;
										for (int i = 7; i < 12; i++)
											dtrNewRow[i] = m_objViewer.m_lsv.Items[lines].SubItems[i+2].Text;
										for (int i = 12; i < 12 + 9; i++)
											dtrNewRow[i] = "";
					for (int i = 12+9; i < 12+18; i++)
						dtrNewRow[i] = 0; */
					dtbLoginInfo.Rows.Add(dtrNewRow);
				}
			
				dsLoginInfo.Tables.Add(dtbLoginInfo);
				rdtLoginInfo.SetDataSource(dsLoginInfo);
				//				CommonClassReport.clsReport ObjDemo = new CommonClassReport.clsReport();
				
				m_objViewer.m_crvTemp.ReportSource = rdtLoginInfo;
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