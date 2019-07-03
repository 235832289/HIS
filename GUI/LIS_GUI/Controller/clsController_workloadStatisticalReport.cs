using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using com.digitalwave.iCare.gui.LIS.Report;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsController_workloadStatisticalReport 的摘要说明。
	/// </summary>
	public class clsController_workloadStatisticalReport : com.digitalwave.GUI_Base.clsController_Base
	{
		public workloadStatisticalReport objRpt = new workloadStatisticalReport();
		private com.digitalwave.iCare.gui.LIS.clsDomainController_LIS objManage = null;

		#region 构造函数
		public clsController_workloadStatisticalReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			objManage = new clsDomainController_LIS();
		}
		#endregion

		#region 设置窗体对象
		com.digitalwave.iCare.gui.LIS.frmWorkloadStatisticalReport m_objViewer;

		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			m_objViewer = (frmWorkloadStatisticalReport)frmMDI_Child_Base_in;
		}
		#endregion

		#region 初始化界面信息 童华 2004.06.21
		public void m_mthInitInfo()
		{
			m_mthGetPatientType();
			m_mthGetCheckCategory();
			m_objViewer.m_cboCheckCategory.SelectedIndex = 0;
			m_objViewer.m_cboPatientType.SelectedIndex = 0;
		}
		#endregion

		#region 获取病人类型列表 童华 2004.06.21
		public void m_mthGetPatientType()
		{
			clsDomainController_DictManage objDomainManage = new clsDomainController_DictManage();
			clsAIDDICT_VO[] objAIDDictVOArr = null;
			long lngRes = 0;
			lngRes = objDomainManage.m_lngGetListFor("61",out objAIDDictVOArr);
			if(lngRes > 0 && objAIDDictVOArr != null)
			{
				if(objAIDDictVOArr.Length > 0)
				{
					m_objViewer.m_cboPatientType.Items.Add("全部");
					for(int i=0;i<objAIDDictVOArr.Length;i++)
					{
						m_objViewer.m_cboPatientType.Items.Add(objAIDDictVOArr[i].m_strDICTNAME_VCHR);
					}
					m_objViewer.m_cboPatientType.Tag = objAIDDictVOArr;
				}
			}
		}
		#endregion

		#region 获取所有的检验项目类别列表 童华 2004.06.21
		public void m_mthGetCheckCategory()
		{
			clsDomainController_CheckItemManage objDomainManage = new clsDomainController_CheckItemManage();
			clsCheckCategory_VO[] objCheckCategoryVOArr = null;
			long lngRes = 0;
			lngRes = objDomainManage.m_lngGetCheckCategory(out objCheckCategoryVOArr);
			if(lngRes > 0 && objCheckCategoryVOArr != null)
			{
				if(objCheckCategoryVOArr.Length > 0)
				{
					m_objViewer.m_cboCheckCategory.Items.Add("全部");
					for(int i=0;i<objCheckCategoryVOArr.Length;i++)
					{
						m_objViewer.m_cboCheckCategory.Items.Add(objCheckCategoryVOArr[i].m_strCheck_Category_Name);
					}
					m_objViewer.m_cboCheckCategory.Tag = objCheckCategoryVOArr;
				}
			}
		}
		#endregion

		#region 根据检验类别获取对应的检验项目列表 童华 2004.06.21
		public void m_mthGetCheckItemByCheckCategory(string p_strCheckCategoryID)
		{
			long lngRes = 0;
			clsCheckItem_VO[] objCheckItemVOArr = null;
			clsDomainController_CheckItemManage objDomainManage = new clsDomainController_CheckItemManage();
			m_objViewer.m_cboCheckItem.Items.Clear();
			lngRes = objDomainManage.m_lngGetCheckItemByCategoryID(p_strCheckCategoryID,out objCheckItemVOArr);
			if(lngRes > 0 && objCheckItemVOArr != null)
			{
				if(objCheckItemVOArr.Length > 0)
				{
					m_objViewer.m_cboCheckItem.Items.Add("全部");
					for(int i=0;i<objCheckItemVOArr.Length;i++)
					{
						m_objViewer.m_cboCheckItem.Items.Add(objCheckItemVOArr[i].m_strCheck_Item_Name);
					}
					m_objViewer.m_cboCheckItem.Tag = objCheckItemVOArr;
				}
				else
				{
					m_objViewer.m_cboCheckItem.Items.Add("全部");
				}
			}
			else
			{
				m_objViewer.m_cboCheckItem.Items.Add("全部");
			}
			m_objViewer.m_cboCheckItem.SelectedIndex = 0;
		}
		#endregion

		#region 清空 童华 2004.06.21
		public void m_mthClear()
		{
			m_objViewer.m_dtpFromDat.Value = System.DateTime.Now;
			m_objViewer.m_dtpToDat.Value = System.DateTime.Now;
			m_objViewer.m_cboCheckCategory.SelectedIndex = 0;
			m_objViewer.m_cboCheckItem.SelectedIndex = 0;
			m_objViewer.m_txtApplyDept.Clear();
			m_objViewer.m_txtApplyDept.Tag = null;
			m_objViewer.m_txtApplyEmployee.Clear();
			m_objViewer.m_txtApplyEmployee.Tag = null;
			m_objViewer.m_txtCheckEmployee.Clear();
			m_objViewer.m_txtCheckEmployee.Tag = null;
		}
		#endregion
		
		#region 组合查询符合条件的记录 童华 2004.06.22
		public void m_mthQryByCondition()
		{
			string strFromDat = "";
			string strToDat = "";
			string strCheckItemID = "";
			string strApplEmpID = "";
			string strApplDeptID = "";
			string strPatientTypeID = "";
			string strCheckEmpID = "";
			string strCheckCategoryID = "";
			DataTable workload = null;
			long lngRes = 0;
			if(m_objViewer.m_chkCheckDat.Checked)
			{
				strFromDat = m_objViewer.m_dtpFromDat.Value.ToShortDateString() + " 00:00:00";
				strToDat = m_objViewer.m_dtpToDat.Value.ToShortDateString() + " 23:59:59";
			}
			if(m_objViewer.m_cboCheckItem.Items.Count > 0)
			{
				if(m_objViewer.m_cboCheckItem.SelectedIndex > 0)
				{
					strCheckItemID = ((clsCheckItem_VO[])m_objViewer.m_cboCheckItem.Tag)[m_objViewer.m_cboCheckItem.SelectedIndex-1].m_strCheck_Item_ID;
				}
			}
			if(m_objViewer.m_txtApplyDept.m_StrDeptID != null)
			{
				strApplDeptID = m_objViewer.m_txtApplyDept.m_StrDeptID.ToString().Trim();
			}
			if(m_objViewer.m_txtApplyEmployee.m_StrEmployeeID != null)
			{
				strApplEmpID = m_objViewer.m_txtApplyEmployee.m_StrEmployeeID.ToString().Trim();
			}
			if(m_objViewer.m_txtCheckEmployee.m_StrEmployeeID != null)
			{
				strCheckEmpID = m_objViewer.m_txtCheckEmployee.m_StrEmployeeID.ToString().Trim();
			}
			if(m_objViewer.m_cboPatientType.Items.Count > 0)
			{
				if(m_objViewer.m_cboPatientType.SelectedIndex > 0)
				{
					strPatientTypeID = ((clsAIDDICT_VO[])m_objViewer.m_cboPatientType.Tag)[m_objViewer.m_cboPatientType.SelectedIndex-1].m_strDICTID_CHR;
				}
			}
			if(m_objViewer.m_cboCheckCategory.Items.Count > 0)
			{
				if(m_objViewer.m_cboCheckCategory.SelectedIndex > 0)
				{
					strCheckCategoryID = ((clsCheckCategory_VO[])m_objViewer.m_cboCheckCategory.Tag)[m_objViewer.m_cboCheckCategory.SelectedIndex-1].m_strCheck_Category_ID;
				}
			}
			lngRes = objManage.m_lngGetWorkloadReportByCondition(strFromDat,strToDat,strCheckItemID,strApplEmpID,strApplDeptID,strPatientTypeID,
				strCheckEmpID,strCheckCategoryID,out workload);
			if(lngRes > 0 && workload != null && workload.Rows.Count > 0)
			{
				objRpt.SetDataSource(workload);
				m_objViewer.m_CRVewerWorkload.ReportSource = objRpt;
				m_objViewer.m_CRVewerWorkload.RefreshReport();
			}
			else
			{
				objRpt.SetDataSource(workload);
				m_objViewer.m_CRVewerWorkload.ReportSource = objRpt;
				m_objViewer.m_CRVewerWorkload.RefreshReport();
				MessageBox.Show("没有查到符合条件的记录！");
			}
		}
		#endregion

	}
}
