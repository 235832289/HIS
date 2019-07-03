using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlCreatePlan 的摘要说明。
	/// </summary>
	public class clsControlCreatePlan:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlCreatePlan()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objDoMain=new clsDomainConrol_Plan();
		}
		clsDomainConrol_Plan m_objDoMain=null;
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmCreatePlanByDate m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmCreatePlanByDate)frmMDI_Child_Base_in;
		}
		#endregion

		#region 导入计划
		public long m_lngCreatePlan(DateTime startDate,DateTime endDate)
		{
			com.digitalwave.iCare.gui.Security.clsController_Security clsSec=new clsController_Security();
			string strOperator=clsSec.objGetCurrentLoginEmployee().strEmpID;
			if(MessageBox.Show("导入周计划将覆盖现在数据，确认导入吗？","",MessageBoxButtons.YesNo)==DialogResult.No)
				return -1;
			if(startDate>endDate)
			{
				MessageBox.Show("开始日期不能大于结束日期","提示");
				return -1;
			}
			long lngRes=m_objDoMain.m_lngCreatePlan(startDate,endDate,strOperator);
			if (lngRes>=0)
				MessageBox.Show("导入周计划成功！","提示");
			else
			{
				if(lngRes<0)
					MessageBox.Show("导入周计划失败！","提示");
			}
			return lngRes;
		}
		#endregion

	}
}
