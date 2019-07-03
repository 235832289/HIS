using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 全院病人流动情况统计——界面控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-23
	/// </summary>
	public class clsCtl_StatHospitalPatientFlow: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_BedAdmin m_objBedAdmin = null;
		clsDcl_Register m_objRegister = null;
		public string m_strReportID;
		public string m_strOperatorID;
		#endregion 

		#region 构造函数
		public clsCtl_StatHospitalPatientFlow()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objBedAdmin =new clsDcl_BedAdmin();
			m_objRegister = new clsDcl_Register();
			m_strReportID = null;
			m_strOperatorID = "0000001";
		}
		#endregion 

		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmStatHospitalPatientFlow m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmStatHospitalPatientFlow)frmMDI_Child_Base_in;
		}
		#endregion
	}
}
