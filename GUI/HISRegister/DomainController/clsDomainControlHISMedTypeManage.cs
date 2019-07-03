using System;
using System.Data;
//using com.digitalwave.iCare.middletier.HIS;//HISMedStore_SVC.dll
using com.digitalwave.GUI_Base;//GUI_Base.dll
using com.digitalwave.iCare.ValueObject;//iCareDate.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药理分类维护业务操作
	/// Create 黄伟灵 by 2005-09-8
	/// </summary>
	public class clsDomainControlHISMedTypeManage : clsDomainController_Base//GUI_Base.dll
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsDomainControlHISMedTypeManage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 药理分类维护业务操作：加载主结点
		/// <summary>
		/// 药理分类维护业务操作：加载主结点
		/// Create 黄伟灵 by 2005-09-8
		/// <param name="strMainID">根据结点号取出子结点，顶结点标识为“”</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		/// </summary>
		public long m_lngGetMedTypeInfo(out clsHISMedType_VO[] p_objResultArr,string strMainID)
		{
			p_objResultArr=null;
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngGetMedTypeInfo(objPrincipal, out p_objResultArr, strMainID);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
			
		}

		#endregion

		#region 药理分类维护业务操作:修改分类信息结点
		/// <summary>
		/// 药理分类维护业务操作:修改信息
		/// Create 黄伟灵 by 2005-09-8
		/// <param name="strMainID">修改分类信息结点</param>
		/// <param name="p_objResultArr">输出数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		/// </summary>
		public long m_lngModify(com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO)
		{		
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngModify(objPrincipal, objTD_VO);
            objSvc.Dispose();
            objSvc = null;				
			return lngRes;
		}
		#endregion

		#region 添加
		/// <summary>
		/// 药理分类维护业务操作:添加信息
		/// Create 黄伟灵 by 2005-09-9
		/// <param name="objTD_VO">添加分类信息结点</param>
		/// <param name="objTD_VOReturn">输出数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		/// </summary>
		public long m_lngAddNew(com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO,out com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VOReturn )
		{
			long lngRes = 0;
			objTD_VOReturn =null;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));

            lngRes = objSvc.m_lngAddNew(objPrincipal, objTD_VO, out objTD_VOReturn);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

		#region 药理分类维护业务操作:删除药理分类
		/// <summary>
		/// 药理分类维护业务操作:删除药理分类
		/// Create 黄伟灵 by 2005-09-9
		/// <param name="objTD_VO">删除分类信息结点</param>
		/// <param name="objTD_VOReturn">输出数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>
		/// </summary>
		public long m_lngDelete(com.digitalwave.iCare.ValueObject.clsHISMedType_VO objTD_VO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngDelete(objPrincipal, objTD_VO);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

		#region 方法：判断某结点是否拥有子结点：（药理分类中是否有子分类）
		/// <summary>
		/// 方法：判断某结点是否拥有子结点：（药理分类中是否有子分类）
		/// </summary>
		/// <param name="blnHasSubNode">返回结果，存在子结点则返回true</param>
		/// <param name="m_strPHARMAID_CHR">数据库中自动产生的ID号</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>

		public long m_lngCheckMedTypeIsHasSubById(out bool blnHasSubNode, string m_strPHARMAID_CHR)
		{
			
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngCheckMedTypeIsHasSubById(objPrincipal, out blnHasSubNode, m_strPHARMAID_CHR);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
			
		}

		#endregion

		#region 方法：判断助记码是否唯一。
		/// <summary>
		/// 方法：判断助记码是否唯一
		/// </summary>
		/// <param name="blnHasThisZhujima">返回结果，已存在此助记码则返回true</param>
		/// <param name="p_strZhuJiMa">助记码数据</param>
		/// <returns>失败：-1 ，成功：所影响的结果数</returns>

		public long m_lngGetMedTypeZhuJiMaById(out bool blnHasThisZhujima, string p_strZhuJiMa)
		{
			
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHISMedTypeManageSvc));
            lngRes = objSvc.m_lngGetMedTypeZhuJiMaById(objPrincipal, out blnHasThisZhujima, p_strZhuJiMa);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
			
		}
		#endregion
	}
}
