using System;
using System.Data;
using System.EnterpriseServices;
using Microsoft.VisualBasic;
using com.digitalwave.Utility; //Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.middletier.LIS
{
	/// <summary>
	/// Summary description for clsBaseCheckGroupSvc.
	/// 
	/// 封装有关基本检验组的数据通迅逻辑
	/// </summary>
	[Transaction(TransactionOption.Supported)]
	[ObjectPooling(Enabled=true)]
	public class clsBaseCheckGroupSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsBaseCheckGroupSvc()
		{
			//
			// TODO: Add constructor logic here
			//
		}



		#region 根据样本的类型ID查询所有可能做的基本检验组 
		/// <summary>
		/// 根据样本的类型ID查询所有可能做的基本检验组 
		/// </summary>
		/// <param name="p_objPrinipal"></param>
		/// <param name="p_strSampleTypeID"></param>
		/// <param name="p_dtbGroup"></param>
		/// <returns>
		/// GROUPID_CHR
		/// GROUPNAME_VCHR
		/// </returns>
		[AutoComplete]
		public long m_lngGetBaseCheckGroupBySampleTypeID(System.Security.Principal.IPrincipal p_objPrinipal,string p_strSampleTypeID,out System.Data.DataTable p_dtbGroup)
		{
			long lngRes=0;
			p_dtbGroup=null;
			string strSQL=@"SELECT t1.groupid_chr, t1.groupname_vchr 
							FROM t_aid_lis_check_group t1								
							WHERE t1.has_subgroup_chr = '0' 
							AND t1.sample_type_id_chr = ? 
							";

			try
			{
				System.Data.IDataParameter[] objParamArr = clsIDataParameterCreator.m_objConstructIDataParameterArr(p_strSampleTypeID);
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref p_dtbGroup,objParamArr);  
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion

		#region 根据基本检验组ID查找能做这组检验的所有的仪器类型ID 
		/// <summary>
		/// 根据基本检验组ID查找能做这组检验的所有的仪器类型ID 刘彬 2004.05.07
		/// </summary>
		/// <param name="p_objPrinipal"></param>
		/// <param name="p_strBaseCheckGroupID"></param>
		/// <param name="p_dtbDeviceModel"></param>
		/// <returns>
		/// DEVICE_MODEL_ID_CHR
		/// DEVICE_MODEL_DESC_VCHR
		/// </returns>
		[AutoComplete]
		public long m_lngGetDeviceModelByBaseCheckGroupID(System.Security.Principal.IPrincipal p_objPrinipal,string p_strBaseCheckGroupID,out System.Data.DataTable p_dtbDeviceModel)
		{
			long lngRes = 0;
			p_dtbDeviceModel = null;
			string strSQL=@"SELECT DISTINCT t1.device_model_id_chr, t2.device_model_desc_vchr 
							FROM t_bse_lis_check_item_dev_item t1 ,
								 t_bse_lis_device_model t2							
							WHERE t1.device_model_id_chr = t2.device_model_id_chr 
							AND t1.groupid_chr = ? 
							";

			try
			{
				System.Data.IDataParameter[] objParamArr = clsIDataParameterCreator.m_objConstructIDataParameterArr(p_strBaseCheckGroupID);
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref p_dtbDeviceModel,objParamArr);  
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);//要在LogError方法中抛出异常。 
			}
			return lngRes;
		}
		#endregion
	}
}
