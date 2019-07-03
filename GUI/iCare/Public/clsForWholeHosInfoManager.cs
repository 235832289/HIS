using com.digitalwave.iCare.common;
using com.digitalwave.iCare.ValueObject;
using iCareData;
using System.Data;

namespace iCare
{
	/// <summary>
	/// clsForWholeHosInfoManageServ ��ժҪ˵����
	/// </summary>
	public class clsForWholeHosInfoManager
	{
		/// <summary>
		/// ���캯��
		/// </summary>
		public clsForWholeHosInfoManager()
		{}
		#region Dept
		/// <summary>
		/// ��ȡȫԺ�����������סԺ���Ŀ���
		/// </summary>
		/// <param name="p_objDeptArr"></param>
		public void m_mthGetAllDeptInfo(out clsDepartmentVO[] p_objDeptArr)
		{
			p_objDeptArr = null;
			new  clsCommmonInfo().m_mthGetDepInfoByDepID("",out p_objDeptArr);
		}
		/// <summary>
		/// ���ݿ���ID��ȡ����
		/// </summary>
		/// <param name="strDepID"></param>
		/// <param name="p_objDeptArr"></param>
		public void m_mthGetAreaInfoByDepID(string strDepID,out clsDepartmentVO[] p_objDeptArr)
		{
			p_objDeptArr = null;
			new  clsCommmonInfo().m_mthGetDepInfoByDepID(strDepID,out p_objDeptArr);
		}

		/// <summary>
		/// ģ�����ҿ���
		/// </summary>
		/// <param name="p_strLike"></param>
		/// <param name="p_strDeptArr"></param>
		/// <returns></returns>
		public long m_lngGetDeptAreaByLike(string p_strLike,out clsDeptAreaInfo_Value[] p_strDeptArr)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetDeptAreaByLike(p_strLike, out p_strDeptArr, "");
            //objServ.Dispose();
            return lngRes;
		}
		
		/// <summary>
		/// ģ�����ҿ���
		/// </summary>
		/// <param name="p_strLike"></param>
		/// <param name="p_strDeptArr"></param>
		/// <returns></returns>
		public long m_lngGetDeptAreaByLike(string p_strLike,out string[,] p_strDeptArr)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetDeptAreaByLike(p_strLike,out p_strDeptArr,"");
            //objServ.Dispose();
            return lngRes;
		}
		/// <summary>
		/// ���ݿ���ȡ����
		/// </summary>
		/// <param name="p_strLike"></param>
		/// <param name="p_strDeptArr"></param>
		/// <param name="p_strDeptID"></param>
		/// <returns></returns>
		public long m_lngGetAreaByLike(string p_strLike,out clsDeptAreaInfo_Value[] p_strDeptArr,string p_strDeptID)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetDeptAreaByLike(p_strLike,out p_strDeptArr,p_strDeptID);
            //objServ.Dispose();
            return lngRes;
		}
		
		/// <summary>
		/// ���ݿ���ȡ����
		/// </summary>
		/// <param name="p_strLike"></param>
		/// <param name="p_strDeptArr"></param>
		/// <param name="p_strDeptID"></param>
		/// <returns></returns>
		public long m_lngGetAreaByLike(string p_strLike,out string[,] p_strDeptArr,string p_strDeptID)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetDeptAreaByLike(p_strLike,out p_strDeptArr,p_strDeptID);
            //objServ.Dispose();
            return lngRes;
		}
		/// <summary>
		/// ��ȡԱ����������
		/// </summary>
		/// <param name="strEmpID"></param>
		/// <param name="p_objDeptArr"></param>
		/// <returns></returns>
		public long m_lngGetDepartmentByUserID(string strEmpID,out com.digitalwave.iCare.ValueObject.clsDepartmentVO[] p_objDeptArr)
		{
			p_objDeptArr = null;
			DataTable dtResult = null;

            com.digitalwave.DepartmentManagerService.clsDepartmentManagerService objServ =
                (com.digitalwave.DepartmentManagerService.clsDepartmentManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DepartmentManagerService.clsDepartmentManagerService));

			long lngRes = objServ.m_lngGetDepartmentByUserID(null,strEmpID,out dtResult);
            //objServ.Dispose();
			if(lngRes > 0 && dtResult.Rows.Count > 0)
			{
				p_objDeptArr = new com.digitalwave.iCare.ValueObject.clsDepartmentVO[dtResult.Rows.Count];
				for(int i=0;i<dtResult.Rows.Count;i++)
				{
					p_objDeptArr[i] = new clsDepartmentVO();
					p_objDeptArr[i].strDeptID = dtResult.Rows[i]["deptid_chr"].ToString().Trim();
					p_objDeptArr[i].strDeptName = dtResult.Rows[i]["deptname_vchr"].ToString().Trim();
					try
					{
						p_objDeptArr[i].intCategory = int.Parse(dtResult.Rows[i]["category_int"].ToString());
					}
					catch{p_objDeptArr[i].intCategory = 0;}
					try
					{
					p_objDeptArr[i].intInPatientOrOutPatient = int.Parse(dtResult.Rows[i]["inpatientoroutpatient_int"].ToString());
					}
					catch{p_objDeptArr[i].intInPatientOrOutPatient = 0;}
					p_objDeptArr[i].strATTRIBUTEID = dtResult.Rows[i]["attributeid"].ToString().Trim();
					p_objDeptArr[i].strPARENTID = dtResult.Rows[i]["parentid"].ToString().Trim();
					p_objDeptArr[i].strShortNo = dtResult.Rows[i]["shortno_chr"].ToString().Trim();
				}
			}
			return lngRes;
		}
		#endregion Dept

		#region Patient

		#region Old
		/// <summary>
		/// ���ݲ���ID��ȡ���ˣ����������סԺ����Ϣ
		/// </summary>
		/// <param name="strPatientID"></param>
		/// <param name="p_objPatientVOArr"></param>
		public void m_mthPatientByPatientID(string strPatientID,out clsPatientVO[] p_objPatientVOArr)
		{
			p_objPatientVOArr = null;
			new  clsCommmonInfo().m_mthGetPatientInfo(strPatientID,out p_objPatientVOArr,true);
		}
		/// <summary>
		/// ���ݲ��˿��Ż�ȡ���ˣ����������סԺ����Ϣ
		/// </summary>
		/// <param name="strCardID"></param>
		/// <param name="p_objPatientVOArr"></param>
		public void m_mthPatientByPatientCardID(string strCardID,out clsPatientVO[] p_objPatientVOArr)
		{
			p_objPatientVOArr = null;
			new  clsCommmonInfo().m_mthGetPatientInfo(strCardID,out p_objPatientVOArr,false);
		}
		#endregion Old

		#region New �������ҵ���Ϣ
		/// <summary>
		/// ���ݲ��˱��ȡ������Ϣ
		/// </summary>
		/// <param name="strPatientID"></param>
		/// <param name="p_objPatientArr"></param>
		public void m_mthGetPatientByID(string strPatientID,out  clsPatientInfo_Value p_objPatient)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetPatientByID(strPatientID,out p_objPatient);
            //objServ.Dispose();
		}
		/// <summary>
		/// ����סԺ��ȡ������Ϣ
		/// </summary>
		/// <param name="strInPatientID"></param>
		/// <param name="p_objPatientArr"></param>
		public void m_mthGetPatientByInPatID(string strInPatientID,out  clsPatientInfo_Value p_objPatient)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetPatientByInPatID(strInPatientID,out p_objPatient);
            //objServ.Dispose();
		}
		/// <summary>
		/// ���ݲ��˿���ȡ������Ϣ
		/// </summary>
		/// <param name="strCardID"></param>
		/// <param name="p_objPatientArr"></param>
		public void m_mthGetPatientByCardID(string strCardID,out  clsPatientInfo_Value p_objPatient)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetPatientByCardID(strCardID,out p_objPatient);
            //objServ.Dispose();
		}
		/// <summary>
		/// ģ�����Ҳ�������
		/// </summary>
		/// <param name="p_strLike"></param>
		/// <param name="p_strNameArr"></param>
		/// <returns></returns>
		public long m_lngGetPatientNameByLike(string p_strLike,out string[,] p_strNameArr)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetPatientNameByLike(p_strLike,out p_strNameArr);
            //objServ.Dispose();
            return lngRes;
		}
		#endregion

		#endregion Patient

		#region Bed
		/// <summary>
		/// ģ�����Ҵ���
		/// </summary>
		/// <param name="p_strLike"></param>
		/// <param name="p_strNameArr"></param>
		/// <returns></returns>
		public long m_lngGetBedNameByLike(string p_strLike,out string[,] p_strNameArr)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetBedNameByLike(p_strLike,out p_strNameArr);
            //objServ.Dispose();
            return lngRes;
		}
		#endregion Bed

		#region Employee
		/// <summary>
		/// ģ������Ա��
		/// </summary>
		/// <param name="p_strLike"></param>
		/// <param name="p_strNameArr"></param>
		/// <returns></returns>
		public long m_lngGetEmployeeNameByLike(string p_strLike,out string[,] p_strNameArr)
		{
            com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ objServ =
                (com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsWholeHosPatientManageServ));

            long lngRes = objServ.m_lngGetEmployeeNameByLike(p_strLike,out p_strNameArr);
            //objServ.Dispose();
            return lngRes;
		}
		#endregion Employee
			
	}
}
