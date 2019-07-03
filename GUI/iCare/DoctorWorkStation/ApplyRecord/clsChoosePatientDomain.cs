using System;
using com.digitalwave.emr.HospitalManagerService;
using com.digitalwave.iCare.common;
using System.Data;
using iCareData;

namespace iCare.DoctorWorkStation
{
	/// <summary>
	/// clsChoosePatientDomain 的摘要说明。
	/// </summary>
	public class clsChoosePatientDomain:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region 构造函数
		public clsChoosePatientDomain()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#endregion


		#region 科室
		/// <summary>
		/// 根据员工ID获取所属科室列表
		/// </summary>
		/// <param name="p_strEmployeeID">员工ID</param>
		/// <param name="p_objResultArr">科室数组</param>
		/// <returns></returns>
		public long m_lngGetDeptInfo(string p_strEmployeeID, out clsEmrDept_VO[] p_objResultArr)
		{
            p_objResultArr = null;
            clsHospitalManagerService objSvc =
                (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));	
			long lngRes=0;
            try
            {
                DataTable dtbResult = new DataTable();
                lngRes = objSvc.m_lngGetDeptInfo(objPrincipal, p_strEmployeeID, out dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    p_objResultArr = new clsEmrDept_VO[dtbResult.Rows.Count];
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        p_objResultArr[i1] = new clsEmrDept_VO();
                        p_objResultArr[i1].m_strDEPTID_CHR = Convert.ToString(dtbResult.Rows[i1]["DEPTID_CHR"]);
                        p_objResultArr[i1].m_strDEPTNAME_VCHR = Convert.ToString(dtbResult.Rows[i1]["DEPTNAME_VCHR"]);
                        p_objResultArr[i1].m_strADDRESS_VCHR = Convert.ToString(dtbResult.Rows[i1]["ADDRESS_VCHR"]);
                        p_objResultArr[i1].m_strSHORTNO_CHR = Convert.ToString(dtbResult.Rows[i1]["SHORTNO_CHR"]);
                    }
                }

            }
            catch (Exception exp)
            {
                string strErrMessage = exp.Message;
            }
            finally
            {
                //objSvc.Dispose();
            }
			return lngRes;
			
		}
		/// <summary>
		/// 获取指定科室信息
		/// </summary>
		/// <param name="p_strEmployeeID">科室ID</param>
		/// <param name="p_objResultArr">指定科室信息</param>
		/// <returns></returns>
		public long m_lngGetSpecialDeptInfo(string p_strDeptID, out clsEmrDept_VO p_objResult)
		{
			p_objResult=null;
            long lngRes = 0;
            clsHospitalManagerService objSvc =
                (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
			try
			{
				DataTable dtbResult=new DataTable();
				lngRes=objSvc.m_lngGetSpecialDeptInfo(objPrincipal,p_strDeptID,out dtbResult);
				if (lngRes>0&&dtbResult.Rows.Count>0)
				{
					p_objResult=new clsEmrDept_VO();
					p_objResult.m_strDEPTID_CHR =Convert.ToString(dtbResult.Rows[0]["DEPTID_CHR"]);
					p_objResult.m_strDEPTNAME_VCHR = Convert.ToString(dtbResult.Rows[0]["DEPTNAME_VCHR"]) ;
					p_objResult.m_strADDRESS_VCHR =Convert.ToString(dtbResult.Rows[0]["ADDRESS_VCHR"]) ;
					p_objResult.m_strSHORTNO_CHR =Convert.ToString(dtbResult.Rows[0]["SHORTNO_CHR"]) ;

			 
				}

			}
			catch (Exception exp)
			{
				string strErrMessage=exp.Message;
			}
            finally
            {
                //objSvc.Dispose();
            }
			return lngRes;
			
		}

   
		
		#endregion

		#region 病区
		/// <summary>
		/// 根据科室ID获取所属病区
		/// </summary>
		/// <param name="p_strDeptID">科室ID</param>
		/// <param name="p_objResultArr">病区数组</param>
		/// <returns></returns>
		public long m_lngGetAreaInfo(string p_strDeptID, out clsEmrDept_VO[] p_objResultArr)
		{
			p_objResultArr=null;	
			long lngRes=0;
            clsHospitalManagerService objSvc =
                    (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
			try
			{
				DataTable dtbResult=new DataTable();
				lngRes=objSvc.m_lngGetAreaInfo(objPrincipal,p_strDeptID,out dtbResult);
				if (lngRes>0&&dtbResult.Rows.Count>0)
				{
					p_objResultArr=new clsEmrDept_VO[dtbResult.Rows.Count];
					for (int i1=0;i1<dtbResult.Rows.Count;i1++)
					{
						p_objResultArr[i1]=new clsEmrDept_VO();
						p_objResultArr[i1].m_strDEPTID_CHR =Convert.ToString(dtbResult.Rows[i1]["DEPTID_CHR"]);
						p_objResultArr[i1].m_strDEPTNAME_VCHR = Convert.ToString(dtbResult.Rows[i1]["DEPTNAME_VCHR"]) ;
						p_objResultArr[i1].m_strADDRESS_VCHR =Convert.ToString(dtbResult.Rows[i1]["ADDRESS_VCHR"]) ;
						p_objResultArr[i1].m_strSHORTNO_CHR =Convert.ToString(dtbResult.Rows[i1]["SHORTNO_CHR"]) ;

					}
				}

			}
			catch (Exception exp)
			{
				string strErrMessage=exp.Message;
			}
            finally
            {
                //objSvc.Dispose();
            }
			return lngRes;
		}
	

		/// <summary>
		/// 获取指定病区信息
		/// </summary>
		/// <param name="p_strDeptID">病区ID</param>
		/// <param name="p_objResultArr">指定病区信息</param>
		/// <returns></returns>
		public long m_lngGetSpecialAreaInfo(string p_strDeptID, out clsEmrDept_VO p_objResult)
		{
			p_objResult=null;
            long lngRes = 0;
            clsHospitalManagerService objSvc =
                (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
			try
			{
				DataTable dtbResult=new DataTable();
				lngRes=objSvc.m_lngGetSpecialAreaInfo(objPrincipal,p_strDeptID,out dtbResult);
				if (lngRes>0&&dtbResult.Rows.Count>0)
				{
					p_objResult=new clsEmrDept_VO();
					p_objResult.m_strDEPTID_CHR =Convert.ToString(dtbResult.Rows[0]["DEPTID_CHR"]);
					p_objResult.m_strDEPTNAME_VCHR = Convert.ToString(dtbResult.Rows[0]["DEPTNAME_VCHR"]) ;
					p_objResult.m_strADDRESS_VCHR =Convert.ToString(dtbResult.Rows[0]["ADDRESS_VCHR"]) ;
					p_objResult.m_strSHORTNO_CHR =Convert.ToString(dtbResult.Rows[0]["SHORTNO_CHR"]) ;

				}

			}
			catch (Exception exp)
			{
				string strErrMessage=exp.Message;
			}
            finally
            {
                //objSvc.Dispose();
            }
			return lngRes;
		}
   
		#endregion

		
		public long m_lngGetAllPatientInArea(string p_strAreaID, out clsEmrPatient_VO[] p_objResultArr)
		{
			p_objResultArr=null;
            long lngRes = 0;
            clsHospitalManagerService objSvc =
                (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
			try
			{
				DataTable dtbResult;
				lngRes=objSvc.m_lngGetBedInfo(objPrincipal,p_strAreaID,true,out dtbResult);

                p_objResultArr = m_objPatientList(dtbResult);
			}
			catch (Exception exp)
			{
				string strErrMessage=exp.Message;
			}
            finally
            {
                //objSvc.Dispose();
            }
			return lngRes;
		}

        public long m_lngGetAllPatientInArea(string p_strAreaID, DateTime p_dtmOutDateStart, DateTime p_dtmOutDateEnd, out clsEmrPatient_VO[] p_objResultArr)
        {
            p_objResultArr = null;
            long lngRes = 0;
            clsHospitalManagerService objSvc =
                (clsHospitalManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsHospitalManagerService));
            try
            {
                DataTable dtbResult;
                lngRes = objSvc.m_lngGetOutPatientByAreaID(objPrincipal, p_strAreaID, p_dtmOutDateStart, p_dtmOutDateEnd, out dtbResult);

                p_objResultArr = m_objPatientList(dtbResult);
            }
            catch (Exception exp)
            {
                string strErrMessage = exp.Message;
            }
            finally
            {
                //objSvc.Dispose();
            }
            return lngRes;
        }

        /// <summary>
        /// 将数据转化为病人列表
        /// </summary>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        private clsEmrPatient_VO[] m_objPatientList(DataTable dtbResult)
        {
            if (dtbResult != null && dtbResult.Rows.Count > 0)
            {
                clsEmrPatient_VO[] objResultArr = new clsEmrPatient_VO[dtbResult.Rows.Count];
                int intAge = 0;//计算年龄的临时变量
                for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                {
                    if (dtbResult.Rows[i1]["registerid_chr"] == DBNull.Value)
                    {
                        continue;
                    }
                    //病人基本信息
                    objResultArr[i1] = new clsEmrPatient_VO();
                    objResultArr[i1].m_strINPATIENTID_CHR = dtbResult.Rows[i1]["emrinpatientid"].ToString();
                    objResultArr[i1].m_strLASTNAME_VCHR = dtbResult.Rows[i1]["LASTNAME_VCHR"].ToString();
                    objResultArr[i1].m_strSEX_CHR = dtbResult.Rows[i1]["SEX_CHR"].ToString();
                    objResultArr[i1].m_strBIRTH_DAT = dtbResult.Rows[i1]["BIRTH_DAT"].ToString();
                    objResultArr[i1].m_strHISInPatientID = dtbResult.Rows[i1]["hisinpatientid_chr"].ToString();
                    objResultArr[i1].m_strEMRInPatientID = dtbResult.Rows[i1]["emrinpatientid"].ToString();
                    objResultArr[i1].m_strPATIENTID_CHR = dtbResult.Rows[i1]["patientid_chr"].ToString();

                    #region 年龄处理
                    if (objResultArr[i1].m_strBIRTH_DAT.Trim().Length != 0)
                    {
                        objResultArr[i1].m_strAGELONG_CHR = com.digitalwave.Emr.StaticObject.clsConsts.s_strCalAge(objResultArr[i1].m_strBIRTH_DAT, Convert.ToDateTime(dtbResult.Rows[i1]["hisinpatientdate"]), out intAge);                        
                    }
                    else
                    {
                        objResultArr[i1].m_strAGELONG_CHR = "未知";
                    }
                    #endregion
                }
                return objResultArr;
            }
            else
            {
                return null;
            }
        }
		
	}
}
