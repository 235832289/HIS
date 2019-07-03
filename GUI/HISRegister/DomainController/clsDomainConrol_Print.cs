using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 获取打印的数据源。
	/// </summary>

	public class clsDomainConrol_Print:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainConrol_Print()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		public long m_lngGetPrintSource(string RegisterID,out System.Data.DataTable dtbSource)
		{
			dtbSource = new System.Data.DataTable();
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngGetCurRegisterByID(objPrincipal, RegisterID, out dtbSource);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#region 挂号员结帐数据 （结帐）
		/// <summary>
		/// 挂号员结帐数据
		/// </summary>
		/// <param name="dtTolSource">返回有效数据</param>
		/// <param name="date">结帐日期</param>
		/// <param name="strempno">结帐人ID</param>
		/// <param name="dtRestoreDetail">返回退号数据</param>
		/// <returns></returns>
		public long m_lngEndReport(out DataTable dtTolSource,string date,string strempno,out DataTable dtRestoreDetail)
		{
			dtTolSource = new System.Data.DataTable();
			dtRestoreDetail = new System.Data.DataTable();
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngEndReport(objPrincipal, out dtTolSource, date, strempno, out dtRestoreDetail);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

		#region 挂号员结帐数据 （历史）
		/// <summary>
		/// 挂号员结帐数据
		/// </summary>
		/// <param name="dtTolSource">返回有效数据</param>
		/// <param name="date">结帐日期</param>
		/// <param name="strempno">结帐人ID</param>
		/// <param name="dtRestoreDetail">返回退号数据</param>
		/// <returns></returns>
		public long m_lngHistoryReport(out DataTable dtTolSource,string date,string strempno,out DataTable dtRestoreDetail)
		{
			dtTolSource = new System.Data.DataTable();
			dtRestoreDetail = new System.Data.DataTable();
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngHistoryReport(objPrincipal, out dtTolSource, date, strempno, out dtRestoreDetail);
            objSvc.Dispose();
            objSvc = null;
			 
			return lngRes;
		}
		#endregion


		#region 历史查询
		public long m_lngGetHistory(string startDate,string endDate,string checkMan,out DataTable dt)
		{
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long LngArg = objSvc.m_lngGetHistorRegister(p_objPrincipal, startDate, endDate, checkMan, out dt);
            objSvc.Dispose();
            objSvc = null;
			return LngArg;
		}
		#endregion

		public long m_lngGetCheckOutSource(string RegisterID,out System.Data.DataTable dtbSource,string date,out System.Data.DataTable dtbSourcedetail,out string strregno)
		{
			dtbSource = new System.Data.DataTable();
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngGetCheckOutRep(objPrincipal, out dtbSource, date, out dtbSourcedetail, out strregno);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}

		public long m_lngGetCheckMan(out DataTable dtCheckMan)
		{
			dtCheckMan = new System.Data.DataTable();
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngGetCheckMan(objPrincipal, out dtCheckMan);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}

		public long m_lngGetCheckOutSourceP(string RegisterID,out System.Data.DataTable dtbSource,string date,string regemp,out System.Data.DataTable dtbSourcedetail,out string strregno)
		{
			dtbSource = new System.Data.DataTable();
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngGetCheckOutRegP(objPrincipal, out dtbSource, date, regemp, out dtbSourcedetail, out strregno);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}

        //挂号日结(旧,停用)
		public long m_lngGetCheckOutReg(string checkoutdate,string checkoutempid,DataTable dtTolSource,DataTable dtRestoreDetail1)
		{
			//dtbSource = new System.Data.DataTable();
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngCheckOut(objPrincipal, checkoutdate, checkoutempid, dtTolSource, dtRestoreDetail1);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
        }

        #region 挂号日结(新)
        /// <summary>
        /// 挂号结帐(新)
        /// </summary>
        /// <param name="OperID">收款员ID</param>
        /// <param name="CheckDate">结帐时间</param>
        /// <returns></returns>
        public long m_lngGetCheckOutReg(string OperID, out string CheckDate)
		{			
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				                                                (com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));

            long l = objSvc.m_lngCheckOut(OperID, out CheckDate);
            objSvc.Dispose();
            objSvc = null;
			return l;
        }
        #endregion

        #region 检查挂号员在当天是否结过帐
        /// <summary>
		/// 检查挂号员在当天是否结过帐
		/// </summary>
		/// <param name="checkoutdate"></param>
		/// <param name="checkoutempid"></param>
		/// <returns></returns>
		public long m_lngCheckEnd(string checkoutempid,string checkoutdate)
		{
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngCheckEnd(objPrincipal, checkoutempid, checkoutdate);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}

		#endregion
		
		#region 历史数据 张国良 2004-9-9
		/// <summary>
		/// 历史数据 张国良 2004-9-9
		/// </summary>
		/// <param name="empID"></param>
		/// <param name="p_fromtDate"></param>
		/// <param name="p_toDate"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngQulHistory(string empID,string p_fromtDate,string p_toDate,out clscheckoutreg_VO[] p_objResultArr )
		{
			//dtbSource = new System.Data.DataTable();
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngQulHistory(objPrincipal, empID, p_fromtDate, p_toDate, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;

			return lngRes;
		}
		#endregion

		

		public long m_lngGetCheckOutHis(out System.Data.DataTable dtbSource,string CHECKOUTDATE,string CHECKOUTREGID,out System.Data.DataTable dtbSourcedetail)
		{
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngGetCheckOutH(objPrincipal, out dtbSource, CHECKOUTDATE, CHECKOUTREGID, out dtbSourcedetail);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		
		#region 门诊挂号报表  张国良  2004-9-10
		/// <summary>
		/// 门诊挂号报表  张国良  2004-9-10
		/// </summary>
		/// <param name="p_strFirstDate"></param>
		/// <param name="p_strLastDate"></param>
		/// <param name="p_strempno"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngFindByDateReport(string p_strFirstDate,string p_strLastDate,out System.Data.DataTable p_tabReport )
		{
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngFindByDateReport(objPrincipal, p_strFirstDate, p_strLastDate, out p_tabReport);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

		#region 门诊挂号报表2  张国良  2004-9-10
		/// <summary>
		/// 门诊挂号报表  张国良  2004-9-10
		/// </summary>
		/// <param name="p_strFirstDate"></param>
		/// <param name="p_strLastDate"></param>
		/// <param name="p_strempno"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngFindByDateReport2(string p_strFirstDate,string p_strLastDate,out System.Data.DataTable p_tabReport )
		{
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngFindByDateReport2(objPrincipal, p_strFirstDate, p_strLastDate, out p_tabReport);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

		#region 门诊科室人次日报表 2005-03-02
		/// <summary>
		/// 门诊科室人次日报表 2005-03-02
		/// </summary>
		/// <param name="p_strFirstDate"></param>
		/// <param name="p_strLastDate"></param>
		/// <param name="p_tabReport"></param>
		/// <returns></returns>
        public long m_lngDepIncomerpt(string p_strFirstDate, string p_strLastDate, out System.Data.DataTable p_tabReport, out DataTable p_depdt)
		{
			com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));
            long lngRes = objSvc.m_lngDepIncomerpt(objPrincipal, p_strFirstDate, p_strLastDate, out p_tabReport, out p_depdt);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

        #region 调用中间件方法，返回数据表（门诊科室挂号统计图）
        /// <summary>
        /// 调用中间件方法，返回数据表（门诊科室挂号统计图）
        /// </summary>
        /// <param name="m_dtpStartDate"></param>
        /// <param name="m_dtpEndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_GetRegReportPicture(string m_dtpStartDate, string m_dtpEndDate, out System.Data.DataTable dt)
        {
            long lngRes = 0;
          //  dt = null;
            com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));

            lngRes = objSvc.m_lngGetRegReportPicture(objPrincipal, m_dtpStartDate, m_dtpEndDate, out dt);
            objSvc.Dispose();
            objSvc = null;
           
            return lngRes;

        }
        #endregion 调用中间件方法，返回数据表

        #region 调用中间件方法，返回数据表(门诊医生挂号统计图)
        /// <summary>
        /// 调用中间件方法，返回数据表(门诊医生挂号统计图)
        /// </summary>
        /// <param name="m_dtpStartDate"></param>
        /// <param name="m_dtpEndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_GetRegReportDoctPicture(string m_dtpStartDate, string m_dtpEndDate, out System.Data.DataTable dt)
        {
            long lngRes = 0;
            //  dt = null;
            com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));

            lngRes = objSvc.m_lngGetRegReportDoctPicture(objPrincipal, m_dtpStartDate, m_dtpEndDate, out dt);
            objSvc.Dispose();
            objSvc = null;

            return lngRes;

        }
         #endregion 调用中间件方法，返回数据表

        #region 获取指定挂号员的发票信息(未结、已结)
        /// <summary>
        /// 获取指定挂号员的发票信息(未结、已结)
        /// </summary>
        /// <param name="EmpID"></param>
        /// <param name="BalDate"></param>
        /// <param name="Flag">0 未结 1 已结</param>
        /// <param name="dt"></param>
        /// <returns></returns>        
        public long m_lngGetRegisterInvoInfo(string EmpID, string BalDate, int Flag, out DataTable dt)
        {            
            com.digitalwave.iCare.middletier.HIS.clsRegisterSvc objSvc =
                                                                   (com.digitalwave.iCare.middletier.HIS.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsRegisterSvc));

            long l = objSvc.m_lngGetRegisterInvoInfo(EmpID, BalDate, Flag, out dt);
            objSvc.Dispose();
            objSvc = null;

            return l;
        }
        #endregion

    }
}
