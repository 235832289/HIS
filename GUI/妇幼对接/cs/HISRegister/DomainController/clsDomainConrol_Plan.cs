using System;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.HIS; //HIS_SVC.DLL
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 排班数据控制类 Create by Sam 2004-6-3
	/// </summary>
	public class clsDomainConrol_Plan:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainConrol_Plan()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
        //公共信息
		#region 查询一级科室
		/// <summary>
		/// 查询一级科室
		/// </summary>
		public long m_lngGetDepList(out DataTable p_objResultArr)
		{
			p_objResultArr =null;
			
			long lngRes = 0;
//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
            lngRes = objSvc.m_lngGetOPDeptForPlan(objPrincipal, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 查询全部科室 
		public long m_lngGetDep(out System.Data.DataTable dt)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
            lngRes = objSvc.m_lngGetOPDeptForPlan(objPrincipal, out dt);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 根据父科室ID取回子科室信息
		/// <summary>
		/// 根据父科室ID取回子科室信息
		/// </summary>
		public long m_lngGetChildDepList(string strDepID,out clsDepartmentVO[] p_objResultArr)
		{
			p_objResultArr = new clsDepartmentVO[0];
			
			long lngRes = 0;
//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
            lngRes = objSvc.lng_getChildrenDep(objPrincipal, strDepID, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 根据科室ID取回医生信息
		/// <summary>
		/// 根据科室ID取回医生信息
		/// </summary>
		public long m_lngGetDocByDepID(string strDepID,out clsEmployeeVO[] p_objResultArr)
		{
			p_objResultArr = new clsEmployeeVO[0];
			
			long lngRes = 0;
//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
            lngRes = objSvc.m_lngGetEmployeeList(objPrincipal, null, strDepID, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion
		
		#region 查找挂号类型
		/// <summary>
		/// 查找挂号类型
		/// </summary>
		public long m_lngGetRegType(out clsRegisterType_VO[] p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr=new clsRegisterType_VO[0];
//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetRegType(objPrincipal, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 根据ID查找科室，返回科室名
		/// <summary>
		/// 查找科室，返回科室名
		/// </summary>
		public string m_lngGetDepName(string strDepID)
		{
			long lngRes = 0;
			clsDepartmentVO[] p_objResultArr=new clsDepartmentVO[0];
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsGetBase objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsGetBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsGetBase));
            lngRes = objSvc.m_lngGetDeptList(objPrincipal, strDepID, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			if (lngRes>0)
			{
				if(p_objResultArr.Length>0)
                   return p_objResultArr[0].strDeptName;
			}
			
			return "";
		}
		#endregion
		//日排班
		#region 根据科室ID和日期取回日排班信息
		/// <summary>
		/// 根据科室ID和日期取回日排班信息
		/// </summary>
		public long m_lngGetDayPlan(string strDate,string strDepID,out clsOPDoctorPlan_VO[] p_objResultArr)
		{
			p_objResultArr = new clsOPDoctorPlan_VO[0];
			
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetPlanByDateAndDep(objPrincipal, strDate, strDepID, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 新增日排班信息
		/// <summary>
		/// 新增日排班信息
		/// </summary>
		public long m_lngAddDayPlan(clsOPDoctorPlan_VO p_objResultArr,out string strPlanID)
		{
			strPlanID="";
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngDoAddNewDayPlan(base.objPrincipal, p_objResultArr, out strPlanID);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 修改日排班信息
		/// <summary>
		/// 修改日排班信息
		/// </summary>
		public long m_lngUPDateDayPlan(clsOPDoctorPlan_VO p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngDoUpdDayPlanByID(objPrincipal, p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 删除日排班信息
		/// <summary>
		/// 删除日排班信息
		/// </summary>
		public long m_lngDelDayPlan(string strPlanID)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngDeleteDayPlanByID(objPrincipal, strPlanID);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 查找日排班信息
		/// <summary>
		/// 查找日排班信息
		/// </summary>
		public long m_lngCheckDayPlan(string strDate,string strPerio,string strDocID,
			out clsOPDoctorPlan_VO p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr=new clsOPDoctorPlan_VO();
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetDocPlan(base.objPrincipal, strDate, strPerio, strDocID, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion
		//周排班
		#region 根据科室ID和周取回周排班信息
		/// <summary>
		/// 根据科室ID和周取回周排班信息
		/// </summary>
		public long m_lngGetWeekPlan(string strWeek,string strDepID,out clsOPDoctorWkPlan_VO[] p_objResultArr)
		{
			p_objResultArr = new clsOPDoctorWkPlan_VO[0];
			
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetPlanByWeekAndDep(objPrincipal, strWeek, strDepID, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 根据周取回周排班信息
		/// <summary>
		/// 根据周取回周排班信息
		/// </summary>
		public long m_lngGetPlanByWeekAndDepAll(string strWeek,out clsOPDoctorWkPlan_VO[] p_objResultArr)
		{
            p_objResultArr = new clsOPDoctorWkPlan_VO[0];
			
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetPlanByWeekAndDepAll(objPrincipal, strWeek, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 根据周取回周排班信息
		/// <summary>
		/// 根据周取回周排班信息
		/// </summary>
		public long m_lngGetPlanByDateAndDepAll(string strDate,out clsOPDoctorPlan_VO[] objPlan)
		{
            objPlan = new clsOPDoctorPlan_VO[0];
			
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetPlanByDateAndDepAll(objPrincipal, strDate, out objPlan);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion
		
		#region 新增周排班信息
		/// <summary>
		/// 新增周排班信息
		/// </summary>
		public long m_lngAddWeekPlan(clsOPDoctorWkPlan_VO p_objResultArr,out string strPlanID)
		{
			strPlanID="";
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngDoAddNewWeekPlan(base.objPrincipal, p_objResultArr, out strPlanID);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion
		#region 修改周排班信息
		/// <summary>
		/// 修改周排班信息
		/// </summary>
		public long m_lngUPDateWeekPlan(clsOPDoctorWkPlan_VO p_objResultArr)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngDoUpdWeekPlanByID(objPrincipal, p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 删除周排班信息
		/// <summary>
		/// 删除周排班信息
		/// </summary>
		public long m_lngDelWeekPlan(string strPlanID)
		{
			long lngRes = 0;
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngDeleteWeekPlanByID(objPrincipal, strPlanID);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 查找周排班信息
		/// <summary>
		/// 查找周排班信息
		/// </summary>
		public long m_lngCheckWeekPlan(string strWeek,string strPerio,string strDocID,
			out clsOPDoctorWkPlan_VO p_objResultArr)
		{
			long lngRes = 0;
			p_objResultArr=new clsOPDoctorWkPlan_VO();
			//			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetDocWeekPlan(base.objPrincipal, strWeek, strPerio, strDocID, out p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion
 
		#region 导入周计划
		public long m_lngCreatePlan(DateTime startDate,DateTime endDate,string strEmp)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngCreatePlan(p_objPrincipal, startDate, endDate, strEmp);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 应用周计划到每天
		public long m_lngAppWeekPlan(clsOPDoctorWkPlan_VO p_objResultArr)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngAppWeek(p_objPrincipal, p_objResultArr);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 获得所有的部门信息
		public long m_lngGetDept(out DataTable dtbResult)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetDept(p_objPrincipal, out dtbResult);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion

		#region 获得所有的员工信息
		public long m_lngGetEmployee(string strDepID,out clsEmployeeVO[] dtbResult)
		{
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
            lngRes = objSvc.m_lngGetOPDoctorListForReg(p_objPrincipal, strDepID, out dtbResult);
            objSvc.Dispose();
            objSvc = null;
			
			return lngRes;
		}
		#endregion
	}
}
