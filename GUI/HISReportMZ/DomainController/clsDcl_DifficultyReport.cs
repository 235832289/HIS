using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS.Reports

{
	/// <summary>
	/// clsDcl_DifficultyReport 的摘要说明。
	/// </summary>
	public class clsDcl_DifficultyReport:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_DifficultyReport()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 获取数据
		
		public long m_mthGetManiReportData(DateTime date,DateTime date2,out System.Data.DataTable dt,out System.Data.DataTable dt2)
		{

            dt = null;
            dt2 = null;
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsDifficultyReportSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsDifficultyReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsDifficultyReportSvc));
            lngRes = objSvc.m_mthGetManiReportData(objPrincipal, date, date2, out dt, out dt2);
            objSvc.Dispose();
            return lngRes;
						
			
		}
		#endregion

		#region 获取数据（特困月报表）
		
		public long m_mthGetAllDataOfMonth(DateTime date,DateTime date2,out System.Data.DataTable dt,out System.Data.DataTable dt1,out System.Data.DataTable dt2)
		{
		
			dt=null;
			dt2=null;
			long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsDifficultyReportOfMonthSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsDifficultyReportOfMonthSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsDifficultyReportOfMonthSvc));
			lngRes = objSvc.m_mthGetAllDataOfMonth(objPrincipal,date,date2,out dt,out dt1,out dt2);
			return lngRes;
		}
		#endregion
		#region 获取员工所属部门
		public long m_mthGetDepartmentByID(string strEmpID,out DataTable p_dt)
		{
			p_dt=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
			return	objSvc.m_mthGetDepartmentByID(objPrincipal,strEmpID, out p_dt);
		}
		#endregion
		#region 根据部门ID查找医生
		public long m_mthGetDocByDepID(string ID,out DataTable p_dt)
		{
			p_dt=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
			return	objSvc.m_mthGetDocByDepID(objPrincipal,ID, out p_dt);
		
		}
		#endregion
		#region 查找单个统计信息
		public long m_mthGetSingleWorkLoad(string m_strFlag,string strID,DateTime strBeginDate,DateTime strEndDate,int flag,out clsSingleWorkLoadSubItem_VO[] objSubArr)
		{
			objSubArr=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
            return objSvc.m_mthGetSingleWorkLoad(m_strFlag,strID, strBeginDate, strEndDate, flag, out objSubArr);
		
		}
		#endregion
        #region 根据员工ID和日期获取正方数和副方数
        /// <summary>
        /// 根据员工ID和日期获取正方数和副方数
        /// </summary>
        /// <param name="m_strID"></param>
        /// <param name="m_strBeginDate"></param>
        /// <param name="m_strEndDate"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        public long m_lngGetRecipeCountByIDAndDate(string m_strFlag,string m_strID, DateTime m_strBeginDate, DateTime m_strEndDate, out DataTable m_objTable)
        {
            long lngRes = -1;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
            lngRes = objSvc.m_lngGetRecipeCountByIDAndDate(objPrincipal,m_strFlag, m_strID, m_strBeginDate, m_strEndDate,out  m_objTable);
            return lngRes;

        }
         #endregion

		#region 统计收费员工作量报表
		/// <summary>
		/// 统计收费员工作量报表
		/// </summary>
		/// <param name="strBeginDate"></param>
		/// <param name="strEndDate"></param>
		/// <param name="objSubArr"></param>
		/// <returns></returns>
		public long m_mthGetCheckManWorkLoad(DateTime strBeginDate,DateTime strEndDate,out clsChargeWork_VO[] objSubArr)
		{
			objSubArr=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
			return	objSvc.m_mthGetCheckManWorkLoad(strBeginDate,strEndDate,out objSubArr);
		
		}
		#endregion

        #region 统计收费员工作量报表
        /// <summary>
        /// 统计收费员工作量报表
        /// </summary>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        /// <param name="objSubArr"></param>
        /// <returns></returns>
        public long m_mthGetCheckManWorkLoad(DateTime strBeginDate, DateTime strEndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));

            return objSvc.m_mthGetCheckManWorkLoad(strBeginDate, strEndDate, out dt);

        }
        #endregion

        #region 统计收费员工作量统计报表发票数(按姓名分组，如果收费员同名则补准，暂时与主报表一致稍后需要同一更改) @@@@@
        /// <summary>
        /// 统计收费员工作量统计报表发票数(按姓名分组，如果收费员同名则补准，暂时与主报表一致稍后需要同一更改) @@@@@
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetCheckinvoicenums(string BeginDate, string EndDate, out DataTable dt)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
            return objSvc.m_lngGetCheckinvoicenums(BeginDate, EndDate, out dt);
        }
        #endregion

        #region 查找单个统计信息NEW
        public long m_mthGetSingleWorkLoad_New(string m_strFlag,string strID,DateTime strBeginDate,DateTime strEndDate,int flag,out clsSingleWorkLoadSubItem_VO[] objSubArr,string p_identityId)
		{
			objSubArr=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
			return	objSvc.m_mthGetSingleWorkLoad_New(m_strFlag,strID,strBeginDate,strEndDate,flag,out objSubArr,p_identityId);
		
		}
		#endregion

		#region 获取组的工作量数据
        public long m_mthGetGroupWorkLoad(string m_strCheckManID,string m_strDeptID, DateTime strBeginDate, DateTime strEndDate, int flag, out clsSingleWorkLoadSubItem_VO[] objSubArr)
		{
			objSubArr=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
            return objSvc.m_mthGetGroupWorkLoad(m_strCheckManID,m_strDeptID, strBeginDate, strEndDate, flag, out objSubArr);
		}
		#endregion
		#region 获取正副方的记录数
		public long m_mthGetCount(out DataTable dt)
		{
			dt=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
			return	objSvc.m_mthGetCount(out dt);
		}
		#endregion

        #region 根据结帐时间统计正、副处方记录数
        /// <summary>
        /// 根据结帐时间统计正、副处方记录数
        /// </summary>
        /// <param name="m_strDeptID"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_mthGetCount(string m_strCheckManID,string m_strDeptID,string BeginDate, string EndDate, out DataTable m_dtZFS,out DataTable m_dtFFS)
        {
            m_dtZFS = null;
            m_dtFFS = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
            return objSvc.m_mthGetCount(m_strCheckManID, m_strDeptID, BeginDate, EndDate, out m_dtZFS,out m_dtFFS);
        }
        #endregion

        #region 根据结帐时间统计专业组－>医生就诊人数
        /// <summary>
        /// 根据结帐时间统计专业组－>医生就诊人数
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public long m_lngGetSeeDoctorPersonNums(string m_strCheckManID, string m_strDeptID, string BeginDate, string EndDate, out DataTable dt)
        {
            dt = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
            return objSvc.m_lngGetSeeDoctorPersonNums(m_strCheckManID,m_strDeptID, BeginDate, EndDate, out dt);
        }
        #endregion

        #region 获取报表字段的列
        public long m_mthReportColumns(out DataTable dt,string strEx)
		{
			dt=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
			return	objSvc.m_mthReportColumns(out dt,strEx);
		}
		#endregion
		#region 根据条件查找用药情况
		public long m_mthGetUsingMedicine(int Flag,out DataTable dt,string strID,DateTime date,DateTime date2,string strEx)
		{
			dt=null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsWaitDiagListManageSvc));
			return	objSvc.m_mthGetUsingMedicine(Flag,out dt,strID,date,date2,strEx);
		}
		#endregion
	}
}
