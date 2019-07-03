using System;
using com.digitalwave.CommonUseServ;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for clsManageDocAndNurDomain.
	/// </summary>
	public class clsManageDocAndNurDomain
	{
        //private clsManageDocAndNurseService m_objServ;
		public clsManageDocAndNurDomain()
		{
            //m_objServ = new clsManageDocAndNurseService();
		}

		public long m_lngGetSpecialEmployeeInDept(int p_intFlag,out clsDocAndNur[] p_objArr)
		{
			p_objArr = null;

            clsManageDocAndNurseService m_objServ =
                (clsManageDocAndNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsManageDocAndNurseService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetSpecialEmployeeInDeptArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_intFlag,clsEMRLogin.LoginInfo.m_strEmpNo,out p_objArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		//这种写法是不健康的，因为返回long是为了界面可以根据long的值来Show一些相应的错误信息
		//而Domain是不允许有MessageBox.Show等任何与界面有关的操作的，这样才符合分层的思想。
		public clsDocAndNur[] m_objGetSpecialEmployeeInDept(int p_intFlag)
		{
            clsDocAndNur[] objArr = null;

            clsManageDocAndNurseService m_objServ =
                (clsManageDocAndNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsManageDocAndNurseService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetSpecialEmployeeInDeptArr(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_intFlag,clsEMRLogin.LoginInfo.m_strEmpNo,out objArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return objArr;
		}

		public long m_lngSave(bool[] p_blnArr,clsDocAndNur[] p_objArr)
		{
			//在这里不用判断p_blnArr或者p_objArr是否为空或者长度为0，因为传进来之前已经判断过
            clsManageDocAndNurseService m_objServ =
                (clsManageDocAndNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsManageDocAndNurseService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngSave(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_blnArr,p_objArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}

		public clsDocAndNur[] m_objGetSpecialEmployeeInDept(int p_intFlag,string p_strDeptID)
		{
            clsDocAndNur[] objArr = null;

            clsManageDocAndNurseService m_objServ =
                (clsManageDocAndNurseService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsManageDocAndNurseService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetSpecialEmployeeInDept(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_intFlag,p_strDeptID,out objArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return objArr;
		}

		
	}
}
