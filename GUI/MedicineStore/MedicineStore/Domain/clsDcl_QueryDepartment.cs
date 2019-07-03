using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.emr.HospitalManagerService;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 科室查询
    /// </summary>
    public class clsDcl_QueryDepartment : com.digitalwave.GUI_Base.clsDomainController_Base
    {
        #region 根据员工ID获取所属科室/病区列表
        /// <summary>
        /// 根据员工ID获取所属科室/病区列表
        /// 此方法只获取所属临床科室列表 
        /// </summary>
        /// <param name="p_strEmployeeID">员工ID</param>
        /// <param name="p_dtbValue">所属临床科室列表 </param>
        /// <returns></returns>
        internal long m_lngGetDeptAreaInfo(string p_strEmployeeID, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            clsHospitalManagerService objSvc = (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
            lngRes = objSvc.m_lngGetDeptAreaInfo(objPrincipal, p_strEmployeeID, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 获取所有科室＆病区,根据attributeid
        /// <summary>
        /// 获取所有科室＆病区,根据attributeid
        /// </summary>
        /// <param name="p_strAttributeid">0000001 = 部门；000002 ＝ 科室；0000003 ＝ 病区</param>
        /// <param name="p_dtbValue">科室＆病区</param>
        /// <returns></returns>
        internal long m_lngGetAllDeptInfoByAttributeid(string p_strAttributeid, out DataTable p_dtbValue)
        {
            long lngRes = 0;
            clsHospitalManagerService objSvc = (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
            lngRes = objSvc.m_lngGetAllDeptInfoByAttributeid(objPrincipal, p_strAttributeid, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 获取所有科室＆病区
        /// <summary>
        /// 获取所有科室＆病区
        /// </summary>
        /// <param name="p_dtbValue">科室＆病区</param>
        /// <returns></returns>
        internal long m_lngGetAllDeptInfo(out DataTable p_dtbValue)
        {
            long lngRes = 0;
            clsHospitalManagerService objSvc = (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
            lngRes = objSvc.m_lngGetAllDeptInfo(objPrincipal, out p_dtbValue);
            return lngRes;
        }
        #endregion

        #region 获取所有类型的科室
        /// <summary>
        /// 获取所有类型的科室
        /// </summary>
        /// <param name="p_dtbValue">所有类型的科室</param>
        /// <returns></returns>
        internal long m_lngGetAllAttributeDeptInfo(out DataTable p_dtbValue)
        {
            long lngRes = 0;
            clsHospitalManagerService objSvc = (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
            lngRes = objSvc.m_lngGetAllAttributeDeptInfo(objPrincipal, out p_dtbValue);
            return lngRes;
        }
        #endregion
    }
}
