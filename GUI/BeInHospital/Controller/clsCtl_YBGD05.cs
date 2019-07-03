using System;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HIS;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_YBGD05 的摘要说明。
	/// </summary>
	public class clsCtl_YBGD05:com.digitalwave.GUI_Base.clsController_Base
	{
		#region 自定义变量
		private clsYBGD05_SVC m_objService=new clsYBGD05_SVC();
		#endregion
		public clsCtl_YBGD05()
		{
		}

//		public long m_lngGetYBGD05ByFilter(string p_strFilter,out clsYBGD05_VO[] p_objYBGD05Arr)
//		{
//			p_objYBGD05Arr=null;
//			long lngRes=m_objService.m_lngGetByFilter(this.objPrincipal,p_strFilter,"");
//			p_objYBGD05Arr=m_objService.m_objYBGD05Arr;
//			return lngRes;
//		}

		public long m_lngGetDetailByFilter(string p_strFilter,out DataTable p_dtbDetail)
		{
			p_dtbDetail=new DataTable();
			long lngRes=m_objService.m_lngGetDetailByFilter(this.objPrincipal,p_strFilter,"DMCODE");
			p_dtbDetail=m_objService.m_dtbRes;
			return lngRes;
		}
	}
}
