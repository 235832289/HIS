using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 住院登记逻辑控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-06
	/// </summary>
	public class clsDcl_Register: com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region 构造函数
		public clsDcl_Register()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		//T_OPR_BIH_REGISTER(住院登记)
		#region 增加
		/// <summary>
		/// 增加住院登记
		/// </summary>
		/// <param name="p_strRecordID">流水号 [out 参数]</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewBihRegister(out string p_strRecordID,clsT_Opr_Bih_Register_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewBihRegister(objPrincipal,out p_strRecordID,p_objRecord);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region 查询
		/// <summary>
		/// 根据入院登记流水号求得第几次入院
		/// </summary>
		/// <param name="p_strRegisterid_chr">入院登记流水号</param>
		/// <param name="intOrder">次序数 [out 参数]</param>
		/// <returns></returns>
		public int m_intGetBihOrderByRegisterID(string p_strRegisterid_chr)
		{
			int intOrder =0;
			long lngRes = 0;
			clsT_Opr_Bih_Register_VO p_objResult = null;
			try
			{
				lngRes=m_lngGetBinRegisterByRegisterID(p_strRegisterid_chr,out p_objResult);
			}
			catch
			{
                intOrder = 0;
			}
			if(lngRes>0 && p_objResult!=null && p_objResult.m_strREGISTERID_CHR!=null)
			{
				intOrder =p_objResult.m_intINPATIENTCOUNT_INT;
			}
			return intOrder;
		}
		/// <summary>
		/// 查询所有的住院登记［有效的］
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetAllBihRegisterInfo(out clsT_Opr_Bih_Register_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Register_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetAllBihRegisterInfo(objPrincipal,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 根据住院号 查询住院登记　[有效的记录]
		/// </summary>
		/// <param name="p_strInpatientid_chr">住院号</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBinRegisterByInpatientID(string p_strInpatientid_chr, out clsT_Opr_Bih_Register_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Register_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinRegisterByInpatientID(objPrincipal,p_strInpatientid_chr,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 获取住院号的最近一次住院登记流水号，没有则获取为空串
		/// 		/// </summary>
		/// <param name="p_strInpatientid_chr">住院号</param>
		/// <param name="p_strRegisterid_chr">住院登记流水号 [out 参数]</param>
		/// <returns></returns>
		public long m_lngGetRegisteridByInpatientID(string p_strInpatientid_chr, out string p_strRegisterid_chr)
		{
			long lngRes=0;
			p_strRegisterid_chr = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetRegisteridByInpatientID(objPrincipal,p_strInpatientid_chr,out p_strRegisterid_chr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 获取住院号的住院登记流水号，没有则获取为空数组
		/// </summary>
		/// <param name="p_strInpatientid_chr">住院号</param>
		/// <param name="p_strRegisterid_chr">住院登记流水号 [out 参数]</param>
		/// <returns></returns>
		public long m_lngGetRegisteridByInpatientID(string p_strInpatientid_chr, out string[] p_strRegisteridArr)
		{
			long lngRes=0;
			p_strRegisteridArr = new string[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetRegisteridByInpatientID(objPrincipal,p_strInpatientid_chr,out p_strRegisteridArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 根据住院流水号 查询住院登记　[有效的记录]
		/// </summary>
		/// <param name="p_strRegisterid_chr">住院流水号</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		public long m_lngGetBinRegisterByRegisterID(string p_strRegisterid_chr, out clsT_Opr_Bih_Register_VO p_objResult)
		{
			long lngRes=0;
			p_objResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinRegisterByRegisterID(objPrincipal,p_strRegisterid_chr,out p_objResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 按条件——住院登记查询
		/// </summary>
		/// <param name="p_strQueryCondition">查询条件</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihRegisterInfo(string p_strQueryCondition, out clsT_Opr_Bih_Register_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Register_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihRegisterInfo(objPrincipal,p_strQueryCondition,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 修改
		#region  修改——修改住院登记的记录状态｛-1历史、0无效、1有效｝
		/// <summary>
		/// 修改住院登记的记录状态｛-1历史、0无效、1有效｝
		/// </summary>
		/// <param name="p_strRegisterid_chr">流水号</param>
		/// <param name="p_intStatus_int">状态｛-1历史、0无效、1有效｝</param>
		/// <param name="p_strOPERATORID_CHR">操作人ID</param>
		/// <returns></returns>
		public long m_lngModifyBihRegisterByRegisterID(string p_strRegisterid_chr,int p_intStatus_int,string p_strOPERATORID_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihRegisterByRegisterID(objPrincipal,p_strRegisterid_chr,p_intStatus_int,p_strOPERATORID_CHR);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region  修改——入院科室、入院病区、病床号、在院状态
		/// <summary>
		///  修改——入院科室、入院病区、病床号、在院状态
		/// </summary>
		/// <param name="p_strRegisterid_chr">流水号</param>
		/// <param name="p_strDEPTID_CHR">入院科室</param>
		/// <param name="p_strAREAID_CHR">入院病区</param>
		/// <param name="p_strBEDID_CHR">病床</param>
		/// <param name="intPSTATUS_INT">{0=未上床;1=已上床;2=预出院;3=实际出院}</param>
		/// <param name="p_strOPERATORID_CHR">操作人</param>
		/// <returns></returns>
		public long m_lngModifyBedInfoByRegisterID(string p_strRegisterid_chr,string p_strDEPTID_CHR,string p_strAREAID_CHR,string p_strBEDID_CHR,int intPSTATUS_INT,string p_strOPERATORID_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			
			try
			{
				lngRes = objSvc.m_lngModifyBedInfoByRegisterID(objPrincipal,p_strRegisterid_chr,p_strDEPTID_CHR,p_strAREAID_CHR,p_strBEDID_CHR,intPSTATUS_INT,p_strOPERATORID_CHR,System.DateTime.Now.ToString());
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region
		public long m_lngModifyBihRegisterPSTATUS_INTByRegisterID(string p_strRegisterid_chr,int intPSTATUS_INT,string p_strOPERATORID_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihRegisterPSTATUS_INTByRegisterID(objPrincipal,p_strRegisterid_chr,intPSTATUS_INT,p_strOPERATORID_CHR,System.DateTime.Now.ToString());
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 按SQL——修改住院登记信息
		/// <summary>
		/// 按SQL——修改住院登记信息
		/// </summary>
		/// <param name="p_strSQLUpdate">Update的SQL语句</param>
		/// <returns></returns>
		public long m_lngModifyBihRegisterInfo(string p_strSQLUpdate)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihRegisterInfo(objPrincipal,p_strSQLUpdate);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion
		#region 验证
		/// <summary>
		///  验证住院号是否存在[有效]登记记录
		/// </summary>
		/// <param name="p_strInpatientid_chr">住院号</param>
		/// <param name="IsRegisterd">是否存在 [out 参赛]</param>
		/// <returns></returns>
		public long m_lngCheckIsRegisterdByInpatientID(string p_strInpatientid_chr,out bool IsRegisterd)
		{
			long lngRes=0;
			IsRegisterd = false;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngCheckIsRegisterdByInpatientID(objPrincipal,p_strInpatientid_chr,out IsRegisterd);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		
		#region 生成住院号
		/// <summary>
		/// 生成住院号 
		/// </summary>
		/// <param name="p_strInpatientid_chr">住院号 [out 参数]</param>
		/// <returns></returns>
		public long m_lngGetInpatientID(out string p_strInpatientid_chr)
		{
			long lngRes=0;
			p_strInpatientid_chr = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			
			try
			{
				lngRes = objSvc.m_lngGetInpatientID(objPrincipal,out p_strInpatientid_chr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		

		#region	获取住院病人列表	glzhang	2005.08.05
		/// <summary>
		/// 获取住院病人列表	glzhang	2005.08.05
		/// </summary>
		/// <param name="p_strFind">查询字符串</param>
		/// <param name="p_dtbResult">结果集</param>
		public long m_lngGetInHosPatienList(string p_strFind,out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult = new DataTable();
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetInHosPatienList(objPrincipal,p_strFind,out p_dtbResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		#region	撤消入院	glzhang	2005.08.30
		/// <summary>
		/// 撤消入院	glzhang	2005.08.30
		/// </summary>
		/// <param name="p_strRegisterID">入院登记ID</param>
		/// <param name="p_strPatientID">病人ID</param>
		/// <param name="p_strPatientID">住院号</param>
		/// <param name="p_strInHospitalDate">入院日期</param>
		/// <param name="p_intStatus">入院次数</param>
		/// <returns></returns>
			public long m_lngModifyCancelPatient(string p_strRegisterID,string p_strPatientID,string p_strInPatientID,string p_strInHospitalDate,int p_intStatus)
			{
				long lngRes=0;
				com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
					(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
				try
				{
					lngRes = objSvc.m_lngModifyCancelPatient(objPrincipal,p_strRegisterID,p_strPatientID,p_strInPatientID,p_strInHospitalDate,p_intStatus);
				}
				catch
				{
					return 0;
				}
				objSvc.Dispose();
				return lngRes;
			}
		#endregion

		#region	根据病人ID获取病人门诊诊断	glzhang	2005.09.29
		/// <summary>
		/// 根据病人ID获取病人门诊诊断	glzhang	2005.09.29
		/// </summary>
		/// <param name="p_strPatientID">病人ID</param>
		/// <param name="p_strDiag">门诊诊断</param>
		/// <returns></returns>
		public long m_lngFindDiagByPatientID(string p_strPatientID,out string p_strDiag)
		{
			p_strDiag="";
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngFindDiagByPatientID(objPrincipal,p_strPatientID,out p_strDiag);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region	获取门诊转入病人信息列表	glzhang	2005.10.10
		/// <summary>
		/// 获取门诊转入病人信息列表	glzhang	2005.10.10
		/// </summary>
		/// <param name="p_dtbResult">结果集</param>
		public long m_lngGetTurnInPatienList(out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult = new DataTable();
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetTurnInPatienList(objPrincipal,out p_dtbResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据病人ID获取病人在院信息,供门诊填写入院登记卡时作判断 glzhang	2005.10.12
		/// <summary>
		/// 根据病人ID获取病人在院信息,供门诊填写入院登记卡时作判断 glzhang	2005.10.12
		/// </summary>
		/// <param name="p_strInPatientID">病人ID</param>
		/// <param name="p_intFlag">标志:0=在院和门诊转入的病人信息,供门诊入院登记卡使用;1=在院和门诊转入的病人信息,入院时使用</param>
		/// <param name="p_dtbResult">结果集</param>
		/// <returns></returns>
		public long m_lngGetPatientInHospitalInfo(string p_strInPatientID,int p_intFlag,out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult=null;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInHospitalInfo(objPrincipal,p_strInPatientID,p_intFlag,out p_dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region	门诊转入病人入院	glzhang	2005.10.10
		/// <summary>
		/// 门诊转入病人入院	glzhang	2005.10.10
		/// </summary>
		/// <param name="p_strRegisterID"></param>
		/// <returns></returns>
		public long m_lngPatientTurnIn(string p_strRegisterID,string p_strArearID,string p_strOperatorID,string p_strInPatientID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngPatientTurnIn(objPrincipal,p_strRegisterID,p_strArearID,p_strOperatorID,p_strInPatientID);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 修改病人住院号 glzhag	glzhang 2006.01.20
		/// <summary>
		/// 修改病人住院号 glzhag	glzhang 2006.01.20
		/// </summary>
		/// <param name="p_strOldInPatientID">旧住院号</param>
		/// <param name="p_strNewInPatientID">新住院号</param>
		/// <returns></returns>
		public long m_lngModifyInPatientID(string p_strOldInPatientID,string p_strNewInPatientID)
		{
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			return objSvc.m_lngModifyInPatientID(objPrincipal,p_strOldInPatientID,p_strNewInPatientID);
		}
		#endregion

        #region	门获取预交金余额	glzhang	2005.03.06
        /// <summary>
        /// 获取预交金余额	glzhang	2005.03.06
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <returns></returns>
        public long m_lngGetPrepayMoney(string p_strRegisterID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            lngRes = objSvc.m_lngGetPrepayMoney(objPrincipal, p_strRegisterID, out p_dtbResult);
            return lngRes;
        }
        #endregion

		//T_Opr_Bih_Leave(出院记录)
		#region 增加
		/// <summary>
		/// 出院---增加出院记录
		/// </summary>
		/// <param name="p_strRecordID">流水号[200409010001] [out 参数]</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewBihLeave(out string p_strRecordID,clsT_Opr_Bih_Leave_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewBihLeave(objPrincipal,out p_strRecordID,p_objRecord);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region 查找
		/// <summary>
		/// 查询所有的出院记录［有效的］
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetAllBihLeaveInfo(out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetAllBihLeaveInfo(objPrincipal,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 根据入院登记流水号查询有效的出院登记记录 {原则上只有一个有效的记录}
		/// </summary>
		/// <param name="p_strRegisterid_chr">入院登记流水号</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBinLeaveByRegisterID(string p_strRegisterid_chr, out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinLeaveByRegisterID(objPrincipal,p_strRegisterid_chr,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 按条件——出院记录查询
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strQueryCondition">查询条件</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihLeaveInfo(string p_strQueryCondition, out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihLeaveInfo(objPrincipal,p_strQueryCondition,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region 修改 | 删除
		/// <summary>
		/// 修改出院的记录状态｛-1历史、0无效、1有效｝	根据流水号
		/// </summary>
		/// <param name="p_strID">出院流水号</param>
		/// <param name="p_intStatus_int">状态｛-1历史、0无效、1有效｝</param>
		/// <param name="p_strOPERATORID_CHR">操作人ID</param>
		/// <returns></returns>
		public long m_lngModifyBihLeaveSTATUS_INTByID(string p_strID,int p_intStatus_int,string p_strOPERATORID_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihLeaveSTATUS_INTByID(objPrincipal,p_strID,p_intStatus_int,p_strOPERATORID_CHR);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 按SQL——修改出院登记信息
		/// </summary>
		/// <param name="p_strSQLUpdate">Update的SQL语句</param>
		/// <returns></returns>
		public long m_lngModifyBihLeaveInfo(string p_strSQLUpdate)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihLeaveInfo(objPrincipal,p_strSQLUpdate);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region 验证
		/// <summary>
		/// 验证某入院流水号是否存在[有效]出院记录
		/// </summary>
		/// <param name="p_strRegisterid_chr">入院登记流水号</param>
		/// <param name="IsLeaveHospital">是否出院 [out 参赛]</param>
		/// <returns></returns>
		public long m_lngCheckIsLeaveHospitalByRegisterID(string p_strRegisterid_chr,out bool IsLeaveHospital)
		{
			long lngRes=0;
			IsLeaveHospital = false;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngCheckIsLeaveHospitalByRegisterID(objPrincipal,p_strRegisterid_chr,out IsLeaveHospital);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		//综合 
		#region 获取住院号的最近一次住院的状态 [首次入院、在院、已出院]  
		/// <summary>
		/// 获取住院号的最近一次住院的状态 [首次入院、在院、已出院] 
		/// </summary>
		/// <param name="p_strInpatientid_chr">住院号</param>
		/// <param name="p_intBihState">住院状态 {1-首次入院、2-在院、3-已出院} [ out 参数 ]</param>
		/// <returns></returns>
		public long m_lngGetBihState(string p_strInpatientid_chr, out int p_intBihState)
		{
			long lngRes=0;
			p_intBihState = 0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihState(objPrincipal,p_strInpatientid_chr,out p_intBihState);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region 获取住院流水号的住院状态 [首次入院、在院、已出院]  
		/// <summary>
		/// 获取住院流水号的住院状态 [首次入院、在院、已出院] 
		/// </summary>
		/// <param name="p_strRegisterid_chr">住院流水号</param>
		/// <param name="p_intBihState">住院状态 {1-首次入院、2-在院、3-已出院} [ out 参数 ]</param>
		/// <returns></returns>
		public long m_lngGetBihStateByRegisterID(string p_strRegisterid_chr, out int p_intBihState)
		{
			long lngRes=0;
			p_intBihState =0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihStateByRegisterID(objPrincipal,p_strRegisterid_chr,out p_intBihState);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region 获取某住院号的所有[有效的]出院纪录
		/// <summary>
		/// 获取某住院号的所有[有效的]出院纪录
		/// </summary>
		/// <param name="p_strInpatientid_chr">住院号</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihLeaveByInpatientID(string p_strInpatientid_chr,out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihLeaveByInpatientID(objPrincipal,p_strInpatientid_chr,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region  获取某住院号的所有[有效的]调转纪录
		/// <summary>
		///  获取某住院号的所有[有效的]调转纪录
		/// </summary>
		/// <param name="p_strInpatientid_chr">住院号</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihTransferByInpatientID(string p_strInpatientid_chr,string p_strFilter,out clsT_Opr_Bih_Transfer_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihTransferByInpatientID(objPrincipal,p_strInpatientid_chr,p_strFilter,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region	病人住院流动记录	glzhang	2005.09.14
		/// <summary>
		/// 病人住院流动记录 glzhang	2005.09.14
		/// </summary>
		/// <param name="p_strRegisterid_chr">ID</param>
		/// <param name="p_strFilter">查询字符串</param>
		/// <param name="p_objResultArr">结果集</param>
		/// <param name="p_intFlag">操作标志:0=本次住院流动记录;1=历次住院流动记录</param>
		/// <returns></returns>
		public long m_lngGetBinTransferByRegisterID(string p_strRegisterid_chr,string p_strFilter,out clsT_Opr_Bih_Transfer_VO[] p_objResultArr,int p_intFlag)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinTransferByRegisterID(objPrincipal, p_strRegisterid_chr,p_strFilter, out p_objResultArr,p_intFlag);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		//Add by jli 2005-03-03
		#region 获取出院召回期限
		public long m_lngGetRecallLimit()
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lnggetrecalllimitdays(objPrincipal);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取最后一次住院日期
		public long m_lngGetLastLeaveDate(string strregisterid,out DateTime dtleave)
		{
			long lngRes=0;
			dtleave=DateTime.Now;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lnggetlastleavedate(objPrincipal,strregisterid,out dtleave);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 判断是否可以召回
		public long m_lngIfCanRecall(string strregisterid)
		{
			DateTime dtLast=DateTime.Now;
			try
			{
				long lngRes=m_lngGetLastLeaveDate(strregisterid,out dtLast);
			}
			catch
			{
			}
		    TimeSpan ts=DateTime.Now-dtLast;
		    if(ts.Days<=m_lngGetRecallLimit())
		    {
		     	return 0;
		    }
		    else
		    {
		     	return -1;
		    }

		}
		#endregion

		//Add End
		//T_Opr_Bih_Transfer(住院调转记录)
		#region 增加
		/// <summary>
		/// 增加住院调转记录
		/// </summary>
		/// <param name="p_strRecordID">住院调转流水号 [out 参数]</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewBinTransfer(out string p_strRecordID,clsT_Opr_Bih_Transfer_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewBinTransfer(objPrincipal,out p_strRecordID, p_objRecord);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 查找
		/// <summary>
		/// 根据入院登记流水号查询转床记录 {包括了ＩＤ到Ｎａｍｅ的转换}
		/// </summary>
		/// <param name="p_strRegisterid_chr">入院登记流水号</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBinTransferByRegisterID(string p_strRegisterid_chr,string p_strFilter,out clsT_Opr_Bih_Transfer_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinTransferByRegisterID(objPrincipal, p_strRegisterid_chr,p_strFilter, out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 根据转床流水号查询对应记录的信息
		/// </summary>
		/// <param name="p_strTransferID">转床流水号</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		public long m_lngGetBinTransferByTransferID(string p_strTransferID, out clsT_Opr_Bih_Transfer_VO p_objResult)
		{
			long lngRes=0;
			p_objResult =null;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinTransferByTransferID(objPrincipal, p_strTransferID, out p_objResult);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// 按条件——转床查询
		/// </summary>
		/// <param name="p_strQueryCondition">查询条件</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihTransferInfo(string p_strQueryCondition, out clsT_Opr_Bih_Transfer_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihTransferInfo(objPrincipal, p_strQueryCondition, out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		//病人基本信息
		#region 增加
		#region 增加病人基本资料
		/// <summary>
		/// 增加病人基本资料
		/// </summary>
		/// <param name="p_strRecordID">流水号</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewPatient(out string p_strRecordID,clsPatient_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = null;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewPatient(objPrincipal,out p_strRecordID,p_objRecord);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 增加病人基本资料索引表
		/// <summary>
		/// 增加病人基本资料索引表
		/// </summary>
		/// <param name="p_strRecordID">流水号</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewPatientIdx(out string p_strRecordID,clsclsPatientIdxVO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewPatientIndexInfo(objPrincipal,out p_strRecordID,p_objRecord);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		

		#region  增加病人卡记录
		/// <summary>
		/// 增加病人卡记录
		/// </summary>
		/// <param name="p_strRecordID"></param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewPatientCard(out string p_strRecordID,clsPatientCardVO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			clsPatientSvc objSvc = (clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			
			try
			{
				lngRes = objSvc.m_lngAddNewPatientCard(objPrincipal,out p_strRecordID,p_objRecord);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion		
		#region 查询
		#region 根据住院号
		/// <summary>
		/// 根据住院号获取病人基本信息
		/// </summary>
		/// <param name="p_strInpatientid_chr">住院号</param>
		/// <param name="objPatientVO"></param>
		/// <returns></returns>
		public long m_lngGetPatientInfoByInpatientID(string p_strInpatientid_chr,out clsPatient_VO objPatientVO)
		{
			long lngRes=0;
			objPatientVO =null;
			clsPatient_VO[] p_objResultArr;
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoByInpatientID(objPrincipal,p_strInpatientid_chr,out p_objResultArr);
			
				if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
					objPatientVO =p_objResultArr[0];
				objSvc.Dispose();
			}
			catch
			{
				return 0;
			}
			return lngRes;
		}
		#endregion 

		#region 根据病人编号
		/// <summary>
		/// 根据诊疗卡号获取病人基本信息
		/// </summary>
		/// <param name="strPatientID">诊疗卡号</param>
		/// <param name="objPatientVO"></param>
		/// <returns></returns>
		public long m_lngGetPatientInfoByPatientID(string strPatientID,out clsPatient_VO objPatientVO)
		{
			long lngRes=0;
			objPatientVO =null;
			clsPatient_VO[] p_objResultArr;
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngShowOneRecord(objPrincipal,strPatientID,out p_objResultArr);
				if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
					objPatientVO =p_objResultArr[0];
				objSvc.Dispose();
			}
			catch
			{
				return 0;
			}
			return lngRes;
		}
		#endregion 

		#region 根据身份证号
		/// <summary>
		/// 根据身份证号获取病人基本信息
		/// </summary>
		/// <param name="p_strIDCARD_CHR">身份证号</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetPatientInfoByIDCARD(string p_strIDCARD_CHR, out clsPatient_VO objPatientVO)
		{
			long lngRes=0;
			objPatientVO =null;
			clsPatient_VO[] p_objResultArr;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoByIDCARD(objPrincipal,p_strIDCARD_CHR,out p_objResultArr);
				if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
					objPatientVO =p_objResultArr[0];
				objSvc.Dispose();
			}
			catch
			{
				return 0;
			}
			return lngRes;
		}
		#endregion 

		#region 根据医保编号
		/// <summary>
		/// 根据医保编号获取病人基本信息
		/// </summary>
		/// <param name="p_strInsuranceID">病人编号</param>
		/// <returns></returns>
		public long m_lngGetPatientInfoByInsuranceID(string p_strInsuranceID, out clsPatient_VO objPatientVO)
		{
			long lngRes=0;
			objPatientVO =null;
			clsPatient_VO[] p_objResultArr;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoByInsuranceID(objPrincipal,p_strInsuranceID,out p_objResultArr);
				if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
					objPatientVO =p_objResultArr[0];
				objSvc.Dispose();
			}
			catch
			{
				return 0;
			}
			return lngRes;
		}
		#endregion	

		#region 根据病历卡号获得病人编号
		public string m_strGetPatientIDByPatientcardid(string p_strPatientcardid)
		{
			string strPatientID ="";
			if(p_strPatientcardid.Trim()=="")
				return strPatientID;
			
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				objSvc.m_lngGetPatientIDByPatientcardid(objPrincipal,p_strPatientcardid,out strPatientID);
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
		
			return strPatientID;
		}
		#endregion		

		#region 根据病人编号获得病历卡号
		/// <summary>
		/// 根据病人编号获得病历卡号
		/// </summary>
		/// <param name="p_strPatientID">病人编号</param>
		/// <returns></returns>
		public string m_strGetPatientcardidByPatientID(string p_strPatientID)
		{
			string strPatientcardid ="";
			if(p_strPatientID.Trim()=="")
				return strPatientcardid;
			
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				objSvc.m_lngGetPatientcardidByPatientID(objPrincipal,p_strPatientID,out strPatientcardid);
			
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
		
			return strPatientcardid;
		}
		#endregion			

        #region 根据住院登记流水号
        /// <summary>
        /// 根据住院登记流水号
        /// </summary>
        /// <param name="p_strREGISTERID_CHR">住院号</param>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        public long m_lngGetPatientInfoByREGISTERID_CHR(string p_strREGISTERID_CHR, out clsPatient_VO objPatientVO)
        {
            long lngRes = 0;
            objPatientVO = null;
            
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objSvc.m_lngGetPatientInfoByREGISTERID_CHR(objPrincipal, p_strREGISTERID_CHR, out objPatientVO);

                objSvc.Dispose();
            }
            catch
            {
                return 0;
            }
            return lngRes;
        }
        #endregion 
		#endregion 
		#region 修改
		#region  修改病人基本信息
		/// <summary>
		/// 修改病人基本信息
		/// </summary>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngModifyPatient(clsPatient_VO p_objRecord)
		{
			long lngRes=0;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			
			try
			{
				lngRes = objSvc.m_lngModifyPatient(objPrincipal,p_objRecord);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion	
	
		#region  修改病人基本资料索引表
		/// <summary>
		/// 修改索引表
		/// </summary>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngModifyPatientIdx(clsclsPatientIdxVO p_objRecord)
		{
			long lngRes=0;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngModifyPatientIdx(objPrincipal,p_objRecord);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion		

		#region 修改病人卡表
		/// <summary>
		/// 修改病人卡表
		/// </summary>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngModifyPatientCard(clsPatientCardVO p_objRecord)
		{
			long lngRes=0;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngModifyPatientCard(objPrincipal,p_objRecord);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion		
		#endregion		
		#region 初始化
		#region 初始化费用类别下拉框
		/// <summary>
		/// 初始化费用类别下拉框
		/// </summary>
		/// <param name="p_cboName">下拉框ID</param>
		public void m_FillCboPatientType(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			long lngRes;
			clsPatientPayTypeVO[] objPatientTypeVO;
			clsPatientSvc objSvc =(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
                lngRes = objSvc.m_GetBIHPatientType(objPrincipal, out objPatientTypeVO);
			}
			catch
			{
				return;
			}
			if(lngRes<=0)
				return;
			for(int i=0;i<objPatientTypeVO.Length;i++)
			{
				p_cboName.Items.Add(objPatientTypeVO[i].m_strPAYTYPENAME_VCHR.ToString());
			}
			p_cboName.Tag=objPatientTypeVO;
			objSvc.Dispose();
		}
		#endregion		

		#region 初始化国籍类别下拉框
		/// <summary>
		/// 初始化国籍下拉框
		/// </summary>
		/// <param name="p_cboName">下拉框ID</param>
		public void m_FillCboNationality(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(2,out objResultArr);
			if(objResultArr.Length == 0) 
				return;
			for(int i=0;i< objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion	
	
		#region 初始化民族类别下拉框
		/// <summary>
		/// 初始化民族类别下拉框
		/// </summary>
		/// <param name="p_cboName">下拉框ID</param>
		public void m_FillCboPatientRace(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(1,out objResultArr);
			if(objResultArr.Length == 0) 
				return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region 初始化籍贯下拉框
		/// <summary>
		/// 初始化籍贯下拉框
		/// </summary>
		/// <param name="p_cboName">下拉框ID</param>
		public void m_FillCboPatientNativeplace(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			p_cboName.Items.Add("");

			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(3,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region 初始化职业下拉框
		/// <summary>
		/// 初始化职业下拉框
		/// </summary>
		/// <param name="p_cboName">下拉框ID</param>
		public void m_FillCboPatienttxtOccupation(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(9,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region 初始化关系下拉框
		/// <summary>
		/// 初始化关系下拉框
		/// </summary>
		/// <param name="p_cboName">下拉框ID</param>
		public void m_FillCboPatientRelation(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			p_cboName.Items.Add("");

			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(4,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region 初始化婚否下拉框
		/// <summary>
		/// 初始化婚否下拉框
		/// </summary>
		/// <param name="p_cboName">下拉框ID</param>
		public void m_FillCboMarried(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(5,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region 初始化性别下拉框
		/// <summary>
		/// 初始化性别下拉框
		/// </summary>
		/// <param name="p_cboName">下拉框ID</param>
		public void m_FillCboSex(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();

			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(10,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion
		#endregion		
		#region 验证病人编号是否存在
		public bool IsExistPatientID(string p_strPatientID)
		{
			bool IsExist =false;
			long lngRes=0;
			clsPatient_VO[] p_objResultArr = null;
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngShowOneRecord(objPrincipal,p_strPatientID,out p_objResultArr);
			}
			catch
			{
				lngRes = 0;
			}
			if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
				IsExist =true;
			objSvc.Dispose();
	
			return IsExist;		
		}
		#endregion 

		//床位信息
		#region 根据病区号、床号——修改病床状态 {1=空床;2=占床;3=预约占床;4=包房占床}
		/// <summary>
		///  根据病区号、床号——修改病床状态 {1=空床;2=占床;3=预约占床;4=包房占床}
		/// </summary>
		/// <param name="p_strAreaID_chr">病区号</param>
		/// <param name="p_strCode_chr">床号</param>
		/// <param name="p_intStatus_int">病床状态 {1=空床;2=占床;3=预约占床;4=包房占床}</param>
		/// <returns></returns>
		public long m_lngModifyBedByCode_chr(string p_strAreaID_chr,string p_strCode_chr,int p_intStatus_int )
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBedByAreaIDCode(objPrincipal,p_strAreaID_chr,p_strCode_chr,p_intStatus_int);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 验证空床	[根据病区号、床号]
		/// <summary>
		/// 验证对应病区号、床号是否空床
		/// </summary>
		/// <param name="p_strAreaID_chr">病区号</param>
		/// <param name="p_strCode_chr">床号</param>
		/// <returns></returns>
		public bool IsEmptyBedByAreaIDAndCode(string p_strAreaID_chr,string p_strCode_chr)
		{
			bool IsEmptyBed =false;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngCheckIsEmptyBedByAreaIDAndCode(objPrincipal,p_strAreaID_chr,p_strCode_chr,out IsEmptyBed);
		    
			}
			catch
			{
			}objSvc.Dispose();
			return IsEmptyBed;	
		}
		#endregion

		//其他方法
		#region 获取职员名称
		#region 获取职工名称	根据工号
		/// <summary>
		/// 根据工号求得员工名称
		/// </summary>
		/// <param name="p_strNo">工号</param>
		/// <returns>返回名称</returns>
		public string m_GetEmployeeNameByNo(string p_strNo)
		{	
			string p_strName="";

			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetApplyName(objPrincipal,p_strNo,out p_strName);
			
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
			return p_strName;
		}
		#endregion
		#region 获取职员名称	根据流水号
		/// <summary>
		/// 获取职员名称	根据流水号
		/// </summary>
		/// <param name="p_strID">流水号</param>
		/// <returns></returns>
		public string m_GetEmployeeNameByID(string p_strID)
		{
			string p_strName ="";
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetEmployeeNameByID(objPrincipal, p_strID, out p_strName);
			
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
			return p_strName;
		}
		#endregion
		#endregion
		#region 获取部门名称
		/// <summary>
		/// 查询某部门ID对应的部门名称
		/// </summary>
		/// <param name="p_strID">部门ID</param>
		/// <returns></returns>
		public string m_DeptIDToName(string p_strID)
		{
			string strName="";
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngDeptIDToName(objPrincipal,p_strID,out strName);
			
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
			return strName;
		}
		#endregion		
		#region 获取病区信息
		public long m_lngGetAreaInfo(string p_strFilter,out com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] p_objRecordArr)
		{
			long lngRes=0;
			p_objRecordArr = new clsT_BSE_DEPTDESC_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetAreaInfo(objPrincipal,p_strFilter,out p_objRecordArr);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 新增预交金
		/// <summary>
		/// 新增预交金收费
		/// </summary>
		/// <param name="p_strRecordID">流水号</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewPrePay(out string p_strRecordID,clsT_opr_bih_prepay_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewPrePay(objPrincipal,out p_strRecordID,p_objRecord);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 获取结余根据入院登记流水号
		/// <summary>
		/// 获取结余根据入院登记流水号
		/// </summary>
		/// <param name="p_strRegisterID">入院登记流水号</param>
		/// <param name="p_dblBalanceMoney">结余 [out 参数 double类型]</param>
		/// <returns></returns>
		public long m_lngGetBalanceMoneyByRegisterID(string p_strRegisterID,out double p_dblBalanceMoney)
		{
			long lngRes=0;
			p_dblBalanceMoney = 0;
			com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
			try
			{
				lngRes = objSvc.m_lngGetBalanceMoneyByRegisterID(p_strRegisterID,out p_dblBalanceMoney);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 获取当前未停的长期医嘱
		/// <summary>
		/// 获取当前未停止[审核]的长期医嘱	根据入院登记ID	
		/// 业务说明: {类型=1-长期; 执行状态=1-提交;2-执行;5- 审核执行;}
		/// </summary>
		/// <param name="p_strRegisterID">入院登记ID</param>
		/// <param name="p_objResultArr">医嘱Vo对象[out 参数]</param>
		/// <returns></returns>
		/// <remark>
		/// 执行类型	{1=长期;2=临时;}
		/// 执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-撤消;5- 审核执行;6-审核停止;}
		/// </remark>
		public long m_lngGetNotStopLongOrderByRegisterID(string p_strRegisterID,out clsBIHOrder[] p_objResultArr)
		{			
			long lngRes=0;
			p_objResultArr = new clsBIHOrder[0];
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
			try
			{
				lngRes = objSvc.m_lngGetNotStopLongOrderByRegisterID2(objPrincipal, p_strRegisterID,out p_objResultArr);
			
			}
			catch
			{
				return 0;
			}return lngRes;
		}
		#endregion
		#region 停止长期医嘱
		/// <summary>
		/// 停止长期医嘱	
		/// 执行状态	{-1作废医嘱;0-创建;1-提交;2-执行;3-停止;4-撤消;5- 审核执行;6-审核停止;}
		/// 业务说明：	只针对状态：1-提交、2-执行
		/// </summary>
		/// <param name="p_objItemArr">医嘱对象Vo [数组]</param>
		/// <param name="p_strDoctorID">执行者ID</param>
		/// <param name="p_strDoctorName">执行者姓名</param>
		/// <returns></returns>
        //public long m_lngStopOrder(clsBIHOrder[] p_objItemArr,string p_strDoctorID,string p_strDoctorName)
        //{
        //    long lngRes=0;
        //    com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
        //    try
        //    {
        //        lngRes = objSvc.m_lngStopOrder(objPrincipal,p_objItemArr,p_strDoctorID,p_strDoctorName);	
        //    }
        //    catch
        //    {
        //        return 0;
        //    }return lngRes;
        //}
		#endregion
		#region 审核停止医嘱
		/// <summary>
		/// 审核停止
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strOrderIDArr">[数组]	医嘱ID</param>
		/// <param name="p_strHandlersID">操作者ID</param>
		/// <param name="p_strHandlers">操作者名称</param>
		/// <returns></returns>
		/// <remarks>
		/// 如果有连续性医嘱,则计费	{同方号，用法不计费}
		/// </remarks>
		public long m_lngAuditingForStop(string[] p_strOrderIDArr,string p_strHandlersID,string p_strHandlers)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
			try
			{
				lngRes = objSvc.m_lngAuditingForStop(objPrincipal,p_strOrderIDArr,p_strHandlersID,p_strHandlers);
			
			}
			catch
			{
				return 0;
			}return lngRes;
		}
		#endregion
		#region 停止[审核]
		/// <summary>
		/// 停止[审核] 在一个事务中执行
		/// 用处:	一般用于自动停止医嘱
		/// </summary>
		/// <param name="p_objOrderArr">医嘱数据对象</param>
		/// <param name="p_strHandlersID"></param>
		/// <param name="p_strHandlers"></param>
		/// <returns></returns>
        //public long m_lngStopANDAuditingOrder(clsBIHOrder[] p_objOrderArr,string p_strHandlersID,string p_strHandlers)
        //{
        //    long lngRes=0;
        //    com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
        //    try
        //    {
        //        lngRes = objSvc.m_lngStopANDAuditingOrder(objPrincipal,p_objOrderArr,p_strHandlersID,p_strHandlers);			
        //    }
        //    catch
        //    {
        //        return 0;
        //    }return lngRes;
        //}
		#endregion
		#region 判断是否存在未审核停止的连续医嘱
		/// <summary>
		/// 判断是否存在未审核停止的连续医嘱
		/// </summary>
		/// <param name="p_strRegisterID">入院登记流水号</param>
		/// <returns></returns>
		public bool m_blnExistNotCheckConfreqOrder(string p_strRegisterID)
		{
			bool p_blnExist =false;
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
			try
			{
				lngRes = objSvc.m_lngJudgeExistNotCheckConfreqOrder(objPrincipal,p_strRegisterID,out p_blnExist);
			
			}
			catch
			{
				return false;
			}objSvc.Dispose();
			return p_blnExist;
		}
		#endregion
		#region 判断今天入院，今天出院的病人，是否漏收收床位费|诊金
		/// <summary>
		/// 判断是否对今天入院，今天出院的病人，收取了床位费
		/// 返回: {0-没有收费;1-已经收费;2-不是今天入院的病人;}
		/// </summary>
		/// <param name="p_strRegisterID">入院登记流水号</param>
		/// <returns>{0-没有收费;1-已经收费;2-不是今天入院的病人;}</returns>
		public long m_lngChargeBedForTodayPatient(string p_strRegisterID)
		{
			bool p_blnExist =false;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngChargeBedForTodayPatient(objPrincipal,p_strRegisterID,out p_blnExist);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			if (lngRes>0)
			{
				if (lngRes==2)	
					return 2;	//不是今天入院的病人	
				if (p_blnExist) 
					return 1;	//已经收费
				else
					return 0;	//没有收费
			}
			return 0;
		}
		/// <summary>
		/// 判断是否对今天入院，今天出院的病人，收取了诊金
		/// 返回: {0-没有收费;1-已经收费;2-不是今天入院的病人;}
		/// </summary>
		/// <param name="p_strRegisterID">入院登记流水号</param>
		/// <returns>{0-没有收费;1-已经收费;2-不是今天入院的病人;}</returns>
		public long m_lngChargeDiagnosisForTodayPatient(string p_strRegisterID)
		{
			bool p_blnExist =false;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngChargeDiagnosisForTodayPatient(objPrincipal,p_strRegisterID,out p_blnExist);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			if (lngRes>0)
			{
				if (lngRes==2)	
					return 2;	//不是今天入院的病人	
				if (p_blnExist) 
					return 1;	//已经收费
				else
					return 0;	//没有收费
			}
			return 0;
		}
		#endregion

        #region 根据病人入院登记ID判断是否有未停止的长期医嘱
        /// <summary>
        /// 根据病人入院登记ID判断是否有未停止的长期医嘱
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="p_blnHaveStop"></param>
        /// <returns></returns>
        public long m_lngGetNotStopLongOrderByRegisterID3(string p_strRegisterID, out bool p_blnHaveStop)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            return objSvc.m_lngGetNotStopLongOrderByRegisterID(objPrincipal, p_strRegisterID, out p_blnHaveStop);
        }
        #endregion

        #region 停止长期医嘱
        /// <summary>
        /// 停止长期医嘱
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        /// <param name="strHandlerID"></param>
        /// <param name="p_strHandlerName"></param>
        /// <returns></returns>
        public long m_lngStopANDAuditingOrderByRegID(string p_strRegisterID, string strHandlerID, string p_strHandlerName)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            return objSvc.m_lngStopANDAuditingOrderByRegID(objPrincipal, p_strRegisterID, strHandlerID, p_strHandlerName);
        }
        #endregion

		//事务方法
		#region 入院登记
		/// <summary>
		/// 入院登记
		/// </summary>
		/// <param name="intBihState">住院状态[1、首次入院；、2在院；、3、再次入院；]</param>
		/// <param name="objPatientVO">[clsPatient_VO]</param>
		/// <param name="objBIHVO">[clsT_Opr_Bih_Register_VO]</param>
		/// <returns></returns>
		public long m_lngRegisterHospital(int intBihState, clsPatient_VO objPatientVO ,ref clsT_Opr_Bih_Register_VO objBIHVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngRegisterHospital(objPrincipal,intBihState,objPatientVO,ref objBIHVO);
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion		

        #region 修改住院信息
        /// <summary>
        /// 修改住院信息
        /// </summary>
        /// <param name="intBihState"></param>
        /// <param name="objPatientVO"></param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        public long m_lngChangeRegisterHospital(int intBihState, clsPatient_VO objPatientVO, ref clsT_Opr_Bih_Register_VO objBIHVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objSvc.m_lngChangeRegisterHospital2(objPrincipal, intBihState, objPatientVO, ref objBIHVO);
            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion		

		#region 调转
		/// <summary>
		/// 调转
		/// </summary>
		/// <param name="objPatientVO">[clsT_Opr_Bih_Transfer_VO]</param>
		/// <returns></returns>
		public long m_lngTransferInHospital(clsT_Opr_Bih_Transfer_VO objPatientVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngTransferInHospital(objPrincipal,objPatientVO);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 调转
		/// <summary>
		/// 调转
		/// </summary>
		/// <param name="objPatientVO">[clsT_Opr_Bih_Transfer_VO]</param>
		/// <returns></returns>
		public long m_lngTransferInHospital(clsT_Opr_Bih_Transfer_VO objPatientVO,string p_strCASEDOCTOR_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngTransferInHospital(objPrincipal,objPatientVO,p_strCASEDOCTOR_CHR);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		
		#region 出院
		/// <summary>
		/// 出院
		/// </summary>
		/// <param name="objPatientVO">[clsT_Opr_Bih_Leave_VO]</param>
		/// <returns></returns>
		public long m_lngLeaveHospital(clsT_Opr_Bih_Leave_VO objPatientVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngLeaveHospital(objPrincipal,objPatientVO);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 
		public bool m_lngIshasAdvice(string p_strRegisterID)
		{
			bool bolHasAdvice = false;
			int Count= 0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			long lngRes = 0;
			try
			{
				 lngRes = objSvc.m_lngIshasAdvice(p_strRegisterID,out Count);
			
			}
			catch
			{
				return false;
			}if(lngRes>0&&Count>0)
			{
				bolHasAdvice = true;
			}
			return bolHasAdvice;
		}
		#endregion
		#region 出院召回
		/// <summary>
		/// 出院召回
		/// </summary>
		/// <param name="objPatientVO">[clsT_Opr_Bih_Transfer_VO]</param>
		/// <returns></returns>
		public long m_lngRecallHospital(clsT_Opr_Bih_Transfer_VO objPatientVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngRecallHospital(objPrincipal,objPatientVO);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		
		#region 根据住院登记ID查询掉转信息
		public long m_lngGetTransferInfoByRegisterID(string p_strRegisterID,out com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Transfer_VO p_objResult)
		{
			long lngRes=0;
			p_objResult =null;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			
			try
			{
				lngRes = objSvc.m_lngGetTransferInfoByRegisterID(objPrincipal,p_strRegisterID,out p_objResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 获得电子病历所需信息
		#region 获得最初的住院登记信息
		public long m_lngGetPatientRegisterInfoByID(string p_strRegisterID,out com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Register_VO objResult)
		{
			long lngRes=0;
			objResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientRegisterInfoByID(objPrincipal,p_strRegisterID,out objResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 获得床位信息
		public long m_lngGetBedInfoByID(string p_strBedID,out com.digitalwave.iCare.ValueObject.clsT_Bse_Bed_VO objResult)
		{
			long lngRes=0;
			objResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetBedInfoByID(objPrincipal,p_strBedID,out objResult);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 获得病区信息
		public long m_lngGetAreaInfoByID(string p_strAreaID,out com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO objResult)
		{
			long lngRes=0;
			objResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetAreaInfoByID(objPrincipal,p_strAreaID,out objResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion
		#region 获取患者护理类型
		public long m_lngGetPatientCareInfo(string p_strResgisterID,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientCareInfo(objPrincipal,p_strResgisterID,out dtbResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 
		public long m_lngGetSpChargeItemIDType(out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetSpChargeItemIDType(out dtbResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 获取主治医师信息
		public long m_lngGetMainDoctor(string p_strFilter,out com.digitalwave.iCare.ValueObject.clsEmployee_VO[] p_objRecordArr)
		{
			long lngRes=0;
			p_objRecordArr = new clsEmployee_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsPatientQuerySVC objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsPatientQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPatientQuerySVC));
			try
			{
				lngRes = objSvc.m_lngGetMainDoctor(objPrincipal,p_strFilter,out p_objRecordArr);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 判断住院号是否重复
		public bool IsExistInptientID(string InpatientID)
		{
			bool IsExist = false;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
			
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				IsExist= objSvc.IsExistInptientID(InpatientID);
			}
			catch
			{
			}
			return IsExist;
		}
		#endregion
		#region 判断医包号是否重复
		public bool m_lngCheckInsuranceNum(string insuranceID,string PatientID)
		{
			bool IsExist = false;
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
			
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes= objSvc.m_lngCheckInsuranceNum(insuranceID,PatientID,out IsExist);
				if(lngRes>0)
				{
					return IsExist;
				}
			}
			catch
			{
				return false;
			}
			return false;
		}
		#endregion
		#region 住院编号状态 add by wjqin (05-12-15)
		/// <summary>
		/// 住院编号状态
		/// </summary>
		/// <param name="m_intISHOSNUMATUO"></param>
		/// <returns></returns>
		public long m_lngGetISHOSNUMATUO(out int m_intISHOSNUMATUO)
		{
			m_intISHOSNUMATUO=0;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetISHOSNUMATUO(objPrincipal,out m_intISHOSNUMATUO);
			}
			catch
			{
				return 0;		
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		

        // 入院登记使用

        #region 获得住院号（普通入院）
        public long  m_lngGetBigPatientIDNor(ref string m_strHead,out string m_strMaxNo, out int m_intSour)
        {
            m_strMaxNo = "";
            m_intSour = -1;
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngGetBigPatientIDNor(objPrincipal,out m_strHead, out m_strMaxNo, out m_intSour);

        }
        #endregion

        internal long m_lngGetBigPatientIDOth(ref string m_strhead, out string m_strMaxNo, out int m_intSour)
        {
            m_strMaxNo = "";
            m_intSour = -1;
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngGetBigPatientIDOth(objPrincipal,out m_strhead,out m_strMaxNo, out m_intSour);
        }

       

        internal long m_lngCheckInputNoHave(string m_strMaxNo, out bool m_blHave)
        {
            //m_strMaxNo = "";
            //m_intSour = -1;
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngCheckInputNoHave(m_strMaxNo, out m_blHave);
        }

        internal long m_lngGetInputNoFree(string m_strInpatientNo, out string m_strHead, out string m_strMaxNo,out int m_intSour,int flag_int,out int count)
        {
            //m_strMaxNo = "";
            //m_intSour = -1;
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngGetBigPatientIDFree(objPrincipal, out m_strHead, out m_strMaxNo, out m_intSour, m_strInpatientNo,flag_int,out count);
        }

        internal long m_lngAddBigIDTableMax(int type, string main)
        {
           
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngAddBigIDTableMax(objPrincipal, type, main);
        
        }

        internal long m_lngDelInpatientNohis(string head, string main)
        {
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
            com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngDelInpatientNohis(objPrincipal, head, main);
        }

        internal long m_lngGetNativeplace(string m_strFindCode, out DataTable m_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngGetNativeplace(objPrincipal, m_strFindCode, out m_dtResult);
        }
    }	

}

