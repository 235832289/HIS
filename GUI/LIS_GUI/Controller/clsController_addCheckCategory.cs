using System;
using System.Data;
using com.digitalwave.iCare.common;
using com.digitalwave.Utility; //Utility.dll
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// Summary description for clsController_addCheckCategory.
	/// </summary>
	public class clsController_addCheckCategory : com.digitalwave.GUI_Base.clsController_Base
	{
		public clsController_addCheckCategory()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		//新增检验类别
		public long AddCheckCategory(string strCheckCategory,out string strCategoryID)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.ValueObject.clsCheckCategory_VO objCheckCategoryVO = new com.digitalwave.iCare.ValueObject.clsCheckCategory_VO();
			objCheckCategoryVO.m_strCheck_Category_Name = strCheckCategory;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngAddCheckCategory(p_objPrincipal,ref objCheckCategoryVO);
			strCategoryID = objCheckCategoryVO.m_strCheck_Category_ID;
			return lngRes;
		}

		//删除检验类别
		public long DelCheckCategory(string strCategory)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngDelCheckCategory(p_objPrincipal,strCategory);
			return lngRes;
		}

		//查询所有的检验类别
		public long QryAllCheckCategory(out System.Data.DataTable dtbCheckCategory)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc objCheckItemSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngGetAllCheckCategory(p_objPrincipal,out dtbCheckCategory);
			return lngRes;
		}

		//更新选中的检验类别
		public long SetCheckCategory(com.digitalwave.iCare.gui.LIS.frmCheckCategory infrmCheckCategory)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			string strCheckCategory = infrmCheckCategory.txtCheckCategory.Text.ToString().Trim();
			string strCheckCategoryID = infrmCheckCategory.lsvCheckCategory.SelectedItems[0].SubItems[0].Text.ToString().Trim();
			com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc objCheckItemSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckItemSvc));
			lngRes = objCheckItemSvc.m_lngSetCheckCategoryInfo(p_objPrincipal,strCheckCategory,strCheckCategoryID);
			if(lngRes > 0)
			{
				MessageBox.Show("记录修改成功","检验类别",MessageBoxButtons.OK);
				infrmCheckCategory.lsvCheckCategory.SelectedItems[0].SubItems[1].Text = strCheckCategory;
			}
//			objCheckItemSvc.Dispose();
			return lngRes;
		}
	}
}
