using System;
using iCareData;
using com.digitalwave.GLS_WS.VO;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.GLS_WS.Logic
{
	/// <summary>
	/// clsTransApply_VOToReport_VO 的摘要说明。
	/// </summary>
	public class clsTransApply_VOToReport_VO
	{
		private clsApplyRecord objCurrentComApply_VO = null;

		public clsTransApply_VOToReport_VO()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 构造函数，接收当前申请单的VO和关联报告的窗体名
		/// </summary>
		/// <param name="objCommApply_VO">申请单的VO</param>
		public clsTransApply_VOToReport_VO(clsApplyRecord objCommApply_VO)
		{
			objCurrentComApply_VO = objCommApply_VO;
		}

		/// <summary>
		/// 转化VO
		/// </summary>
		/// <returns></returns>
		public clsApplyReport_T_VO objReport_T_VO()
		{
			clsApplyReport_T_VO objNewVO = new clsApplyReport_T_VO(); 
			objNewVO.m_StrDeptName = objCurrentComApply_VO.m_strDepartment;
			objNewVO.m_StrDeptID = objCurrentComApply_VO.m_strDeptID;
			objNewVO.m_StrAreaName = objCurrentComApply_VO.m_strArea;
			objNewVO.m_StrAreaID = objCurrentComApply_VO.m_strAreaID;
			objNewVO.m_StrPatientName = objCurrentComApply_VO.m_strName;
			objNewVO.m_StrPatientSex = objCurrentComApply_VO.m_strSex;
			objNewVO.m_StrPatientAge = objCurrentComApply_VO.m_strAge;
			objNewVO.m_StrInPatientID = objCurrentComApply_VO.m_strBIHNO;
			objNewVO.m_StrBedName = objCurrentComApply_VO.m_strBedNO;
			objNewVO.m_StrPatientCardID = objCurrentComApply_VO.m_strCardNO;
			objNewVO.m_StrClinicDiagnose = objCurrentComApply_VO.m_strDiagnose;
			objNewVO.m_StrOutPatientID = objCurrentComApply_VO.m_strClinicNO;
			objNewVO.m_DtmDeliverDate = objCurrentComApply_VO.m_datApplyDate;
			objNewVO.m_StrDeliverOrganism = objCurrentComApply_VO.m_strDiagnosePart;
			objNewVO.m_StrPathologyDiag = objCurrentComApply_VO.m_strDiagnose;
			objNewVO.m_StrDeliverDoctorName = objCurrentComApply_VO.m_strDoctorName;
			objNewVO.m_StrDeliverDoctorID = objCurrentComApply_VO.m_strDoctorID;
			objNewVO.m_StrCheckID = objCurrentComApply_VO.m_strCheckNO;
			objNewVO.m_StrAddress = objCurrentComApply_VO.m_strAddress;
			objNewVO.m_StrRelationCall = objCurrentComApply_VO.m_strTel;

			return objNewVO;
		}
	}
}
