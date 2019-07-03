using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.middletier.LIS; //LisApplSvr.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsController_ApplyUnitProperty 的摘要说明。
	/// </summary>
	public class clsController_ApplyUnitProperty : com.digitalwave.GUI_Base.clsController_Base
	{
		private frmApplyUnitProperty m_frmViewer;
		public clsController_ApplyUnitProperty()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region override
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_frmViewer = (frmApplyUnitProperty)frmMDI_Child_Base_in;
		}

		#endregion

	}
}
