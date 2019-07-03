using System;
using com.digitalwave.DataShareService;
using System.Data;

namespace iCare
{
	/// <summary>
	/// Summary description for clsGeneralDiseaseRecordShareDomain.
	/// </summary>
	public class clsGeneralDiseaseRecordShareDomain
	{
        //private clsGeneralDiseaseRecordShareService m_objServ;
		public clsGeneralDiseaseRecordShareDomain()
		{
			//
			// TODO: Add constructor logic here
			//
            //m_objServ = new clsGeneralDiseaseRecordShareService();
		}

		/// <summary>
		/// 获取首次病程记录的内容
		/// </summary>
		/// <param name="p_strInPaitentID"></param>
		/// <param name="p_strInPatientDate"></param>
		/// <param name="p_stuShare"></param>
		/// <returns></returns>
		public long m_lngGetFirstDiseaseInfoShareValue(string p_strInPaitentID,string p_strInPatientDate,out stuFirstDiseaseInfoShare p_stuShare)
		{
			p_stuShare.m_strRecord = "";
			p_stuShare.m_strMain = "";
			p_stuShare.m_strDiagnose = "";
			p_stuShare.m_strDiagnoseDist = "";
			p_stuShare.m_strTreatPlan = "";
			p_stuShare.m_strDiffDiagnose = "";

			DataTable dtResult;

            clsGeneralDiseaseRecordShareService m_objServ =
                (clsGeneralDiseaseRecordShareService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsGeneralDiseaseRecordShareService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.m_lngGetFirstDiseaseInfoShareValue(clsLoginContext.s_ObjLoginContext.m_ObjPrincial,p_strInPaitentID,p_strInPatientDate,out dtResult);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			if(lngRes < 0) return lngRes;

			if(dtResult.Rows.Count != 1) return 0;
			
			#region old
//			p_stuShare.m_strRecord = dtResult.Rows[0]["RECORDCONTENT_RIGHT"].ToString().Trim();
//
//			int intIndex1 = p_stuShare.m_strRecord.IndexOf("初步诊断：");
//			int intIndex2 = p_stuShare.m_strRecord.IndexOf("诊断依据：");
//			int intIndex3 = p_stuShare.m_strRecord.IndexOf("鉴别诊断：");
//			int intIndex4 = p_stuShare.m_strRecord.IndexOf("治疗计划：");
//
//			p_stuShare.m_strMain = (intIndex1==-1) ? "" : p_stuShare.m_strRecord.Substring(0,intIndex1-1).TrimEnd();
//			p_stuShare.m_strDiagnose = (intIndex1==-1 || intIndex2==-1 || intIndex1 > intIndex2) ? "" :p_stuShare.m_strRecord.Substring(intIndex1+5,intIndex2 - (intIndex1+5) - 1).TrimEnd();
//			p_stuShare.m_strDiagnoseDist = (intIndex2==-1 || intIndex3==-1 || intIndex2 > intIndex3) ? "" :p_stuShare.m_strRecord.Substring(intIndex2+5,intIndex3 - (intIndex2+5) -1).TrimEnd();
//			p_stuShare.m_strDiffDiagnose = (intIndex3==-1 || intIndex4==-1 || intIndex3 > intIndex4) ? "" :p_stuShare.m_strRecord.Substring(intIndex3+5,intIndex4 - (intIndex3+5) - 1).TrimEnd();
//			p_stuShare.m_strTreatPlan = (intIndex4==-1) ? "" : p_stuShare.m_strRecord.Substring(intIndex4+5).TrimEnd();
			#endregion old

			p_stuShare.m_strMain=dtResult.Rows[0]["MostlyContent_Right"].ToString().Trim();
			p_stuShare.m_strDiagnose=dtResult.Rows[0]["OriginalDiagnose_Right"].ToString().Trim();
			p_stuShare.m_strDiagnoseDist=dtResult.Rows[0]["ThereunderDiagnose_Right"].ToString().Trim();
			p_stuShare.m_strDiffDiagnose=dtResult.Rows[0]["DiagnoseDiffe_Right"].ToString().Trim();
			p_stuShare.m_strTreatPlan=dtResult.Rows[0]["CurePlan_Right"].ToString().Trim();

			return 1;
		}		

		/// <summary>
		/// 存放数据的结构体
		/// </summary>
		public struct stuFirstDiseaseInfoShare
		{
			public string m_strRecord;	//首次病程记录内容
			public string m_strMain;	//主要内容
			public string m_strDiagnose;//诊断
			public string m_strDiagnoseDist;//诊断依据
			public string m_strDiffDiagnose;//鉴别诊断
			public string m_strTreatPlan;//诊疗计划
		}
	}
}
