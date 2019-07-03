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
	/// 统计查询逻辑控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-23
	/// </summary>
	public class clsDcl_StatQuery: com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region 构造函数
		public clsDcl_StatQuery()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		//科室|病区病人流动人员统计
		#region 统计病人数-[时间段、科室、病区]
		#region 总病人数
		/// <summary>
		/// 统计病人数-[时间段、科室、病区]
		/// 总病人数	{修改时间}
		/// </summary>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="p_strAreaID">病区ID</param>
		/// <param name="p_strStartDateTime">起始时间</param>
		/// <param name="p_strEndDateTime">结束时间</param>
		/// <returns></returns>
		public int m_intStatPatientNumberAll(string p_strDeptID,string p_strAreaID,string p_strStartDateTime ,string p_strEndDateTime)
		{
			int p_intNumber =0;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngStatPatientNumberAll(objPrincipal,p_strDeptID,p_strAreaID,p_strStartDateTime ,p_strEndDateTime,out p_intNumber);
		    
			}
			catch
			{
			}objSvc.Dispose();
			return p_intNumber;
		}
		#endregion
		#region 病人数-根据病情	(病危、病重、普通)
		/// <summary>
		/// 统计病人数-[时间段、科室、病区]
		/// 病人数-根据病情	(病危、病重、普通)
		/// </summary>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="p_strAreaID">病区ID</param>
		/// <param name="p_strStartDateTime">起始时间</param>
		/// <param name="p_strEndDateTime">结束时间</param>
		/// <param name="intState">病情	[1、病危；2、病重；3、普通；]</param>
		/// <returns></returns>
		public int m_intStatPatientNumberByState(string p_strDeptID,string p_strAreaID,string p_strStartDateTime,string p_strEndDateTime,int intState)
		{
			int p_intNumber =0;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngStatPatientNumberByState(objPrincipal,p_strDeptID,p_strAreaID,p_strStartDateTime ,p_strEndDateTime,intState,out p_intNumber);
		    
			}
			catch
			{
			}objSvc.Dispose();
			return p_intNumber;
		}
		#endregion

		#region 增加数
		/// <summary>
		/// 统计病人数-[时间段、科室、病区]
		/// 增加数	{入院时间}
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="p_strAreaID">病区ID</param>
		/// <param name="p_strStartDateTime">起始时间</param>
		/// <param name="p_strEndDateTime">结束时间</param>
		/// <param name="p_intNumber">[Out 参数]</param>
		/// <returns></returns>
		public long m_lngStatPatientNumberAdd(string p_strDeptID,string p_strAreaID,string p_strStartDateTime ,string p_strEndDateTime)
		{
			return 0;
		}
		#endregion
		#region 新入
		#endregion
		#region 转入
		#endregion

		#region 减少数
		#endregion
		#region 出院
		#endregion
		#region 转院
		#endregion
		#region 专科
		#endregion
		#region 死亡
		#endregion
		#endregion

		#region 统计病人信息-[时间段、科室、病区]
		#region 新增危重病人
		#endregion
		#region 取消危重病人
		#endregion
		#region 抢救危重病人
		#endregion

		#region 入科病人
		#endregion
		#region 出科病人
		#endregion
		#endregion

		//全院病人流动情况统计

		//报表：科室、病区统计报表 （科室ID、科室名称、病区名称、昨日人数、今日入院人数、今日转入人数、今日转出人数、今日出院人数、今日死亡人数、今日在院人数、今日开放床位数、统计时间）
		#region 科室、病区统计报表 
		/// <summary>
		/// 科室、病区统计报表 （科室ID、科室名称、病区名称、昨日人数、今日入院人数、今日转入人数、今日转出人数、今日出院人数、今日死亡人数、今日在院人数、今日开放床位数、统计时间）
		/// </summary>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="strDateTime">统计时间</param>
		/// <param name="p_dtbResult">out 参数，返回的表（）</param>
		/// <returns></returns>
		public long m_lngRepDeptByDate(string p_strDeptID,DateTime p_dtFromTime,DateTime p_dtToTime,out DataTable p_dtbResult)
		{
			p_dtbResult =new DataTable();
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			
		    lngRes = objSvc.m_lngRepDeptByDate(objPrincipal,p_strDeptID,p_dtFromTime,p_dtToTime,out p_dtbResult);
			
		    objSvc.Dispose();
			return lngRes;		
		}
		#endregion

		#region 统计详细信息
		/// <summary>
		/// 统计详细信息
		/// </summary>
		/// <param name="AreaID">病区ID</param>
		/// <param name="dtStatTime">统计时间</param>
		/// <param name="Type_int">0:入院1：转入2:转出3：出院</param>
		/// <param name="dtbResult">返回结果</param>
		/// <returns></returns>
		public long GetSickRoomLogDetail(string AreaID,System.DateTime dtStatTime,int Type_int,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.GetSickRoomLogDetail(AreaID,dtStatTime,Type_int,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;		
		}
		#endregion

		#region 统计全院病人流动报表	glzlahgn	2005.07.26
		/// <summary>
		/// 统计全院病人流动报表 （科室ID、科室名称、病区名称、昨日人数、今日入院人数、今日转入人数、今日转出人数、今日出院人数、今日死亡人数、今日在院人数、今日开放床位数、统计时间）glzlahgn	2005.07.26
		/// </summary>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="strDateTime">统计时间</param>
		/// <param name="p_dtbResult">out 参数，返回的表（）</param>
		/// <returns></returns>
		public long m_lngRepAllDeptByDate(string p_strDeptID,string strDateTime,out DataTable p_dtbResult)
		{
			p_dtbResult =new DataTable();
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngRepAllDeptByDate(objPrincipal,p_strDeptID,strDateTime,out p_dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;		
		}
		#endregion
           
        #region 病人入院单统计表  liuyingrui 2006.05.08
        /// <summary>
        /// 病人入院单统计表  liuyingrui 2006.05.08
        /// </summary>
        /// <param name="dtStartTime">统计起始时间</param>
        /// <param name="dtEndTime">统计终止时间</param>
        /// <returns></returns>
        public long GetPatientBihStatistics(DateTime dtStartime, DateTime dtEndTime, object strPaytypeId, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
            try
            {
                //change
                //lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                //--------------->
                if (strPaytypeId == null )
                {
                    lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
  
                }
                else if (((string)strPaytypeId).Equals("0000"))
                {
                    lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                }
                else
                {
                    lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, strPaytypeId.ToString(), out dtbResult);

                }
                /*<--------------------*/
            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
           #endregion

        #region  病人出院单统计表 2006.11.18
        /// <summary>
        ///  病人出院单统计表 2006.11.18
        /// </summary>
        /// <param name="dtStartTime">统计起始时间</param>
        /// <param name="dtEndTime">统计终止时间</param>
        /// <returns></returns>
        public long GetPatientLeftStatistics(DateTime dtStartime, DateTime dtEndTime,object strPaytypeId, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
            try
            {
                //change
                //lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                //--------------------------------->
                if (strPaytypeId == null)
                {
                    lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                }
                else if (strPaytypeId.Equals("0000"))
                {
                    lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                }
                else
                {
                    lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, strPaytypeId.ToString(), out dtbResult);
                }
                //<---------------------------------

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region 统计全院病区详细信息	glzhang	2005.07.26
        /// <summary>
		/// 统计全院病区详细信息	glzhang	2005.07.26
		/// </summary>
		/// <param name="AreaID">病区ID</param>
		/// <param name="dtStatTime">统计时间</param>
		/// <param name="Type_int">0:入院1：转入2:转出3：出院</param>
		/// <param name="dtbResult">返回结果</param>
		/// <returns></returns>
        public long GetAllSickRoomLogDetail(string AreaID, System.DateTime p_dtStatTime, DateTime p_dtToTime, int Type_int, out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
		
            lngRes = objSvc.GetAllSickRoomLogDetail(AreaID, p_dtStatTime,p_dtToTime, Type_int, out dtbResult);
			
			objSvc.Dispose();
			return lngRes;		
		}
		#endregion

		#region  获取一日清单病人信息
		public long m_lngGetPatientInfoForDailyCharge(System.DateTime p_dtStatTime,string p_strAreaID,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoForDailyCharge(p_dtStatTime,p_strAreaID,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region  获取一日清单病人信息
		public long m_lngGetPatientInfoForDailyCharge(System.DateTime p_dtStatTime,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoForDailyCharge(p_dtStatTime,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 统计病区病人欠费信息
		public long m_lngGetPatientDebt(int type,string AreaID,string registerId,System.DateTime p_StaticTime,string InpatientID,string PatientCardID,out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientDebt(type,AreaID,registerId,p_StaticTime,InpatientID,PatientCardID,out p_dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		public long m_lngGetPatientDebt(string AreaID,string registerId,System.DateTime p_StaticTime,string InpatientID,string PatientCardID,out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientDebt(AreaID,registerId,p_StaticTime,InpatientID,PatientCardID,out p_dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 统计病人医嘱费用信息
		public long m_lngGetPatientDebtDetail(string[] types,System.DateTime StatDate,System.DateTime DateEnd,string Registerid,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			
			try
			{
				lngRes = objSvc.m_lngGetPatientDebtDetail(types,StatDate,DateEnd,Registerid,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		public long m_lngGetPatientDebtDetail(System.DateTime StatDate,System.DateTime DateEnd,string Registerid,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientDebtDetail(StatDate,DateEnd,Registerid,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 获取报表收费项目类型
		public long m_lngGetChargeItemTypesByConfigGroupID(string p_reportid,string p_groupid,out string[] types)
		{
			long lngRes=0;
			types = new string[0];
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetChargeItemTypesByConfigGroupID(p_reportid,p_groupid,out types);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region  获取报表设置
		public long m_lngGetDailyDebtConfig(string p_strReportID,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.GetDailyDebtConfig(p_strReportID,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region  获取病人费用一日清单
		public long m_lngGetDailyChargeInfo(string p_strreportid,string p_strRegisterID,System.DateTime p_dtStatTime,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetDailyChargeInfo(p_strreportid,p_strRegisterID,p_dtStatTime,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region  通过住院登记ID获取病人欠费用信息
		public long m_lngGetPatientDebtByRegisterID(string p_strRegisterid_chr,out string p_strDebt)
		{
			long lngRes=0;
			p_strDebt = "";
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			
			try
			{
				lngRes = objSvc.m_lngGetPatientDebtByRegisterID(p_strRegisterid_chr,out p_strDebt);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
	}
}
