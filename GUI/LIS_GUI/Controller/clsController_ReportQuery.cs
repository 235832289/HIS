using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll commoninfo.dll
using com.digitalwave.iCare.middletier.LIS; //LisApplSvr.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Collections;
namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsController_ReportQuery 的摘要说明。
	/// 刘彬 2004.06.23
	/// </summary>
	public class clsController_ReportQuery : com.digitalwave.GUI_Base.clsController_Base
	{
		private System.Collections.Hashtable m_hasDeptList = new Hashtable();
		private System.Collections.Hashtable m_hasEmployeeList = new Hashtable();

		private const string c_strMessageBoxTitle = "iCare-报告查询";
		com.digitalwave.iCare.gui.LIS.frmReportQuery m_objViewer;
		#region 构造函数
		public clsController_ReportQuery()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 设置窗体对象
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			m_objViewer = (frmReportQuery)frmMDI_Child_Base_in;
		}
		#endregion

		public void m_mthInit()
		{
			clsCommmonInfo objInfo = new clsCommmonInfo();
			clsDepartmentVO[] objDeptArr = null;
			clsEmployeeVO[] objEmployeeArr = null;
			objInfo.m_mthGetAllDeptArr(out objDeptArr);
			objInfo.m_mthGetAllEmpInfo(out objEmployeeArr);
			if(objDeptArr != null)
			{
				for(int i=0;i<objDeptArr.Length;i++)
				{
					this.m_hasDeptList.Add(objDeptArr[i].strDeptID,objDeptArr[i].strDeptName);
				}
			}
			if(objEmployeeArr != null)
			{
				for(int i=0;i<objEmployeeArr.Length;i++)
				{
					this.m_hasEmployeeList.Add(objEmployeeArr[i].strEmpID,objEmployeeArr[i].strLastName);
				}
			}
		}
		public void m_mthQueryReports(clsLISApplicationSchVO p_objSchVO)
		{


			clsLisApplMainVO[] objAppVOArr = null;
			long lngRes = new clsDomainController_ApplicationManage().m_lngGetAppInfoByCondition(
				p_objSchVO,out objAppVOArr);
			if(objAppVOArr == null || objAppVOArr.Length == 0)
			{
				MessageBox.Show(this.m_objViewer,"没有找到符合条件的记录!",c_strMessageBoxTitle);
			}
			else
			{
				this.m_objViewer.m_lsvReportList.Items.Clear();				
				for(int i=0;i<objAppVOArr.Length;i++)
				{
					this.m_objViewer.m_lsvReportList.BeginUpdate();
					m_mthReportListAddReport(objAppVOArr[i]);
					this.m_objViewer.m_lsvReportList.EndUpdate();
				}
			}
		}

		private void m_mthReportListAddReport(clsLisApplMainVO p_objAppMainVO)
		{
			ListViewItem lvt = new ListViewItem();
			lvt.Text = p_objAppMainVO.m_strPatient_Name;
			
			lvt.SubItems.Add(p_objAppMainVO.m_strCheckContent);
			lvt.SubItems.Add(p_objAppMainVO.m_strPatient_inhospitalno_chr);
			lvt.SubItems.Add(p_objAppMainVO.m_strBedNO);

//			com.digitalwave.Utility.ctlDeptTextBox txtDept = new com.digitalwave.Utility.ctlDeptTextBox();
//			txtDept.m_StrDeptID = p_objAppMainVO.m_strAppl_DeptID;
//			string strDeptName = txtDept.m_StrDeptName;
//			lvt.SubItems.Add(strDeptName);
//
//			com.digitalwave.Utility.ctlEmpTextBox txtDoct = new com.digitalwave.Utility.ctlEmpTextBox();
//			txtDoct.m_StrEmployeeID = p_objAppMainVO.m_strAppl_EmpID;
//			string strDoctName = txtDoct.m_StrEmployeeName;
//			lvt.SubItems.Add(strDoctName);
			if(p_objAppMainVO.m_strAppl_DeptID != null && this.m_hasDeptList.ContainsKey(p_objAppMainVO.m_strAppl_DeptID))
			{
				object objDeptName = this.m_hasDeptList[p_objAppMainVO.m_strAppl_DeptID];
				if(objDeptName != null)
				{
					lvt.SubItems.Add(objDeptName.ToString());
				}
			}
			else
			{
				lvt.SubItems.Add("");
			}
			if(p_objAppMainVO.m_strAppl_EmpID != null && this.m_hasEmployeeList.ContainsKey(p_objAppMainVO.m_strAppl_EmpID))
			{
				object objEmployeeName = this.m_hasEmployeeList[p_objAppMainVO.m_strAppl_EmpID];
				if(objEmployeeName != null)
				{
					lvt.SubItems.Add(objEmployeeName.ToString());
				}
			}
			else
			{
				lvt.SubItems.Add("");
			}
			lvt.SubItems.Add(p_objAppMainVO.m_strAppl_Dat);
			lvt.SubItems.Add(p_objAppMainVO.m_strReportDate);
			if(p_objAppMainVO.m_intReportStatus == 2)
			{
				lvt.SubItems.Add("√");
			}
			else
			{
				lvt.SubItems.Add("");
			}
			lvt.Tag = p_objAppMainVO;
			this.m_objViewer.m_lsvReportList.Items.Add(lvt);
		}

		#region 打印报告
		public override void Print(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			m_objViewer.m_mthPrint();
		}

		#endregion
	}	
}