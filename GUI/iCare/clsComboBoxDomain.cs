using System;
using  com.digitalwave.ComboBoxService;
using System.Data;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsComboBoxDomain.
	/// </summary>
	public class clsComboBoxDomain
	{

		public clsComboBoxDomain()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// 获取所有项目
		/// </summary>
		/// <param name="p_strDeptID"></param>
		/// <param name="p_strTypeID"></param>
		/// <param name="p_strItemID"></param>
		/// <param name="p_objValueArr"></param>
		/// <returns></returns>
		public long m_lngGetAllItem(string p_strDeptID,string p_strTypeID,string p_strItemID,out clsComboBoxValue[] p_objValueArr)
		{
			p_objValueArr = null;

            clsComboBoxService m_objService =
                (clsComboBoxService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsComboBoxService));

			long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngGetAllItem(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strDeptID, p_strTypeID, p_strItemID, out p_objValueArr);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 添加一项
		/// </summary>
		/// <param name="p_objValue"></param>
		/// <returns></returns>
		public long m_lngAddItemToDB(clsComboBoxValue p_objValue)
		{
            clsComboBoxService m_objService =
                (clsComboBoxService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsComboBoxService));

			long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngAddItemToDB(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objValue);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 删除一项
		/// </summary>
		/// <param name="p_objValue"></param>
		/// <returns></returns>
		public long m_lngDeleteItem(clsComboBoxValue p_objValue)
		{
            clsComboBoxService m_objService =
                (clsComboBoxService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsComboBoxService));

			long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngDeleteItem(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objValue);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}

		/// <summary>
		/// 修改一项
		/// </summary>
		/// <param name="p_objOldValue"></param>
		/// <param name="p_strNewItemContent"></param>
		/// <returns></returns>
		public long m_lngModifyItem(clsComboBoxValue p_objOldValue,string p_strNewItemContent)
		{
            clsComboBoxService m_objService =
                (clsComboBoxService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsComboBoxService));

			long lngRes = 0;
            try
            {
                lngRes = m_objService.m_lngModifyItem(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_objOldValue,p_strNewItemContent);
            }
            finally
            {
                ////m_objService.Dispose();
            }
            return lngRes;
		}

	}
}
