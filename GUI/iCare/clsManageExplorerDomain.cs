using System;
using System.Data;
using iCareData;
using com.digitalwave.iCare.common;
using com.digitalwave.emr.HospitalManagerService;

namespace iCare
{
	/// <summary>
	/// Summary description for clsManageExplorerDomain.
	/// </summary>
	public class clsManageExplorerDomain
	{
		public clsManageExplorerDomain()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public bool m_blnIDExists(string p_strID)
		{
			return false;
		}
		/// <summary>
		/// 获得该病区下的病床及病人
		/// </summary>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="p_strAreaID">病区ID</param>
		/// <returns></returns>
//		public long lngGetCurrentBedArr(string p_strDeptID,string p_strAreaID,out clsBedInfo[] p_objBedArr )
//		{
//			p_objBedArr= new clsBedInfo[5];
//			for(int i=0;i<5;i++)
//			{
//				p_objBedArr[i]= new clsBedInfo();
//				p_objBedArr[i].m_strBedID=i.ToString("0000000");
//				p_objBedArr[i].m_strBedName="Bed Name";
//				p_objBedArr[i].m_strBedInPatientID=(i*2).ToString("0000000");
//				p_objBedArr[i].m_strBedInPatientName="Patient Name";
////				p_objBedArr[i].m_strBedInPatientDate="1900-1-1";
//			}
//			p_objBedArr[2].m_strBedInPatientID="";
//			p_objBedArr[0].m_strBedInPatientID=null;
//
//			return 1;
//		}
        /// <summary>
        /// 根据员工ID获取所属科室列表
        /// </summary>
        /// <param name="p_strEmployeeID">员工ID</param>
        /// <param name="p_objResultArr">科室数组</param>
        /// <returns></returns>
        public long m_lngGetDeptInfo(string p_strEmployeeID, out clsEmrDept_VO[] p_objNewDeptArr,out clsDepartment[] p_objOldDeptArr)
        {
            p_objNewDeptArr = null;
            p_objOldDeptArr = null;
            long lngRes = 0;
            clsHospitalManagerService objSvc =
                (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
            try
            {
                DataTable dtbResult = new DataTable();
                lngRes = objSvc.m_lngGetDeptInfo(null, p_strEmployeeID, out dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objNewDeptArr = new clsEmrDept_VO[dtbResult.Rows.Count];
                    p_objOldDeptArr = new clsDepartment[dtbResult.Rows.Count];
                    for (int i1 = 0 ; i1 < dtbResult.Rows.Count ; i1++)
                    {
                        p_objNewDeptArr[i1] = new clsEmrDept_VO();
                        p_objNewDeptArr[i1].m_strDEPTID_CHR = dtbResult.Rows[i1]["DEPTID_CHR"].ToString().Trim();
                        p_objNewDeptArr[i1].m_strDEPTNAME_VCHR = dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString();
                        p_objNewDeptArr[i1].m_strADDRESS_VCHR = dtbResult.Rows[i1]["ADDRESS_VCHR"].ToString();
                        p_objNewDeptArr[i1].m_strSHORTNO_CHR = dtbResult.Rows[i1]["SHORTNO_CHR"].ToString();
                        if (p_objNewDeptArr[i1].m_strSHORTNO_CHR != null)
                            p_objNewDeptArr[i1].m_strSHORTNO_CHR = p_objNewDeptArr[i1].m_strSHORTNO_CHR.Trim();
                        p_objNewDeptArr[i1].m_intDEFAULT_INPATIENT_DEPT_INT = Convert.ToInt32(dtbResult.Rows[i1]["DEFAULT_INPATIENT_DEPT_INT"]);
                        p_objOldDeptArr[i1] = new clsDepartment(p_objNewDeptArr[i1].m_strDEPTID_CHR, p_objNewDeptArr[i1].m_strSHORTNO_CHR, p_objNewDeptArr[i1].m_strDEPTNAME_VCHR, p_objNewDeptArr[i1].m_strADDRESS_VCHR);
                    }
                }

            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
            }
            finally
            {
                // objSvc.Dispose();
            }
            return lngRes;

        }
	}

//	public class clsManageExplorerService
//	{
//	}
}
