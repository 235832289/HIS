using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// ͳ�Ʋ�ѯ�߼����Ʋ�
	/// ���ߣ� ����
	/// ����ʱ�䣺 2004-09-23
	/// </summary>
	public class clsDcl_StatQuery: com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region ���캯��
		public clsDcl_StatQuery()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		//����|��������������Աͳ��
		#region ͳ�Ʋ�����-[ʱ��Ρ����ҡ�����]
		#region �ܲ�����
		/// <summary>
		/// ͳ�Ʋ�����-[ʱ��Ρ����ҡ�����]
		/// �ܲ�����	{�޸�ʱ��}
		/// </summary>
		/// <param name="p_strDeptID">����ID</param>
		/// <param name="p_strAreaID">����ID</param>
		/// <param name="p_strStartDateTime">��ʼʱ��</param>
		/// <param name="p_strEndDateTime">����ʱ��</param>
		/// <returns></returns>
		public int m_intStatPatientNumberAll(string p_strDeptID,string p_strAreaID,string p_strStartDateTime ,string p_strEndDateTime)
		{
			int p_intNumber =0;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngStatPatientNumberAll(objPrincipal,p_strDeptID,p_strAreaID,p_strStartDateTime ,p_strEndDateTime,out p_intNumber);
		    
			}
			catch
			{
			}objSvc.Dispose();
			return p_intNumber;
		}
		#endregion
		#region ������-���ݲ���	(��Σ�����ء���ͨ)
		/// <summary>
		/// ͳ�Ʋ�����-[ʱ��Ρ����ҡ�����]
		/// ������-���ݲ���	(��Σ�����ء���ͨ)
		/// </summary>
		/// <param name="p_strDeptID">����ID</param>
		/// <param name="p_strAreaID">����ID</param>
		/// <param name="p_strStartDateTime">��ʼʱ��</param>
		/// <param name="p_strEndDateTime">����ʱ��</param>
		/// <param name="intState">����	[1����Σ��2�����أ�3����ͨ��]</param>
		/// <returns></returns>
		public int m_intStatPatientNumberByState(string p_strDeptID,string p_strAreaID,string p_strStartDateTime,string p_strEndDateTime,int intState)
		{
			int p_intNumber =0;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngStatPatientNumberByState(objPrincipal,p_strDeptID,p_strAreaID,p_strStartDateTime ,p_strEndDateTime,intState,out p_intNumber);
		    
			}
			catch
			{
			}objSvc.Dispose();
			return p_intNumber;
		}
		#endregion

		#region ������
		/// <summary>
		/// ͳ�Ʋ�����-[ʱ��Ρ����ҡ�����]
		/// ������	{��Ժʱ��}
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strDeptID">����ID</param>
		/// <param name="p_strAreaID">����ID</param>
		/// <param name="p_strStartDateTime">��ʼʱ��</param>
		/// <param name="p_strEndDateTime">����ʱ��</param>
		/// <param name="p_intNumber">[Out ����]</param>
		/// <returns></returns>
		public long m_lngStatPatientNumberAdd(string p_strDeptID,string p_strAreaID,string p_strStartDateTime ,string p_strEndDateTime)
		{
			return 0;
		}
		#endregion
		#region ����
		#endregion
		#region ת��
		#endregion

		#region ������
		#endregion
		#region ��Ժ
		#endregion
		#region תԺ
		#endregion
		#region ר��
		#endregion
		#region ����
		#endregion
		#endregion

		#region ͳ�Ʋ�����Ϣ-[ʱ��Ρ����ҡ�����]
		#region ����Σ�ز���
		#endregion
		#region ȡ��Σ�ز���
		#endregion
		#region ����Σ�ز���
		#endregion

		#region ��Ʋ���
		#endregion
		#region ���Ʋ���
		#endregion
		#endregion

		//ȫԺ�����������ͳ��

		//�������ҡ�����ͳ�Ʊ��� ������ID���������ơ��������ơ�����������������Ժ����������ת������������ת�����������ճ�Ժ��������������������������Ժ���������տ��Ŵ�λ����ͳ��ʱ�䣩
		#region ���ҡ�����ͳ�Ʊ��� 
		/// <summary>
		/// ���ҡ�����ͳ�Ʊ��� ������ID���������ơ��������ơ�����������������Ժ����������ת������������ת�����������ճ�Ժ��������������������������Ժ���������տ��Ŵ�λ����ͳ��ʱ�䣩
		/// </summary>
		/// <param name="p_strDeptID">����ID</param>
		/// <param name="strDateTime">ͳ��ʱ��</param>
		/// <param name="p_dtbResult">out ���������صı���</param>
		/// <returns></returns>
		public long m_lngRepDeptByDate(string p_strDeptID,DateTime p_dtFromTime,DateTime p_dtToTime,out DataTable p_dtbResult)
		{
			p_dtbResult =new DataTable();
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			
		    lngRes = objSvc.m_lngRepDeptByDate(objPrincipal,p_strDeptID,p_dtFromTime,p_dtToTime,out p_dtbResult);
			
		    objSvc.Dispose();
			return lngRes;		
		}
		#endregion

		#region ͳ����ϸ��Ϣ
		/// <summary>
		/// ͳ����ϸ��Ϣ
		/// </summary>
		/// <param name="AreaID">����ID</param>
		/// <param name="dtStatTime">ͳ��ʱ��</param>
		/// <param name="Type_int">0:��Ժ1��ת��2:ת��3����Ժ</param>
		/// <param name="dtbResult">���ؽ��</param>
		/// <returns></returns>
		public long GetSickRoomLogDetail(string AreaID,System.DateTime dtStatTime,int Type_int,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.GetSickRoomLogDetail(AreaID,dtStatTime,Type_int,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;		
		}
		#endregion

		#region ͳ��ȫԺ������������	glzlahgn	2005.07.26
		/// <summary>
		/// ͳ��ȫԺ������������ ������ID���������ơ��������ơ�����������������Ժ����������ת������������ת�����������ճ�Ժ��������������������������Ժ���������տ��Ŵ�λ����ͳ��ʱ�䣩glzlahgn	2005.07.26
		/// </summary>
		/// <param name="p_strDeptID">����ID</param>
		/// <param name="strDateTime">ͳ��ʱ��</param>
		/// <param name="p_dtbResult">out ���������صı���</param>
		/// <returns></returns>
		public long m_lngRepAllDeptByDate(string p_strDeptID,string strDateTime,out DataTable p_dtbResult)
		{
			p_dtbResult =new DataTable();
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngRepAllDeptByDate(objPrincipal,p_strDeptID,strDateTime,out p_dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;		
		}
		#endregion
           
        #region ������Ժ��ͳ�Ʊ�  liuyingrui 2006.05.08
        /// <summary>
        /// ������Ժ��ͳ�Ʊ�  liuyingrui 2006.05.08
        /// </summary>
        /// <param name="dtStartTime">ͳ����ʼʱ��</param>
        /// <param name="dtEndTime">ͳ����ֹʱ��</param>
        /// <returns></returns>
        public long GetPatientBihStatistics(DateTime dtStartime, DateTime dtEndTime, object strPaytypeId, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
            try
            {
                //change
                //lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                //--------------->
                if (strPaytypeId == null )
                {
                    lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
  
                }
                else if (((string)strPaytypeId).Equals("0000"))
                {
                    lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                }
                else
                {
                    lngRes = objSvc.GetPatientBihStatistics(objPrincipal, dtStartime, dtEndTime, strPaytypeId.ToString(), out dtbResult);

                }
                /*<--------------------*/
            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
           #endregion

        #region  ���˳�Ժ��ͳ�Ʊ� 2006.11.18
        /// <summary>
        ///  ���˳�Ժ��ͳ�Ʊ� 2006.11.18
        /// </summary>
        /// <param name="dtStartTime">ͳ����ʼʱ��</param>
        /// <param name="dtEndTime">ͳ����ֹʱ��</param>
        /// <returns></returns>
        public long GetPatientLeftStatistics(DateTime dtStartime, DateTime dtEndTime,object strPaytypeId, out DataTable dtbResult)
        {
            long lngRes = 0;
            dtbResult = null;
            com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
            try
            {
                //change
                //lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                //--------------------------------->
                if (strPaytypeId == null)
                {
                    lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                }
                else if (strPaytypeId.Equals("0000"))
                {
                    lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, out dtbResult);
                }
                else
                {
                    lngRes = objSvc.GetPatientLeftStatistics(objPrincipal, dtStartime, dtEndTime, strPaytypeId.ToString(), out dtbResult);
                }
                //<---------------------------------

            }
            catch
            {
                return 0;
            }
            objSvc.Dispose();
            return lngRes;
        }
        #endregion

        #region ͳ��ȫԺ������ϸ��Ϣ	glzhang	2005.07.26
        /// <summary>
		/// ͳ��ȫԺ������ϸ��Ϣ	glzhang	2005.07.26
		/// </summary>
		/// <param name="AreaID">����ID</param>
		/// <param name="dtStatTime">ͳ��ʱ��</param>
		/// <param name="Type_int">0:��Ժ1��ת��2:ת��3����Ժ</param>
		/// <param name="dtbResult">���ؽ��</param>
		/// <returns></returns>
        public long GetAllSickRoomLogDetail(string AreaID, System.DateTime p_dtStatTime, DateTime p_dtToTime, int Type_int, out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
		
            lngRes = objSvc.GetAllSickRoomLogDetail(AreaID, p_dtStatTime,p_dtToTime, Type_int, out dtbResult);
			
			objSvc.Dispose();
			return lngRes;		
		}
		#endregion

		#region  ��ȡһ���嵥������Ϣ
		public long m_lngGetPatientInfoForDailyCharge(System.DateTime p_dtStatTime,string p_strAreaID,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoForDailyCharge(p_dtStatTime,p_strAreaID,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region  ��ȡһ���嵥������Ϣ
		public long m_lngGetPatientInfoForDailyCharge(System.DateTime p_dtStatTime,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoForDailyCharge(p_dtStatTime,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ͳ�Ʋ�������Ƿ����Ϣ
		public long m_lngGetPatientDebt(int type,string AreaID,string registerId,System.DateTime p_StaticTime,string InpatientID,string PatientCardID,out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientDebt(type,AreaID,registerId,p_StaticTime,InpatientID,PatientCardID,out p_dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		public long m_lngGetPatientDebt(string AreaID,string registerId,System.DateTime p_StaticTime,string InpatientID,string PatientCardID,out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientDebt(AreaID,registerId,p_StaticTime,InpatientID,PatientCardID,out p_dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ͳ�Ʋ���ҽ��������Ϣ
		public long m_lngGetPatientDebtDetail(string[] types,System.DateTime StatDate,System.DateTime DateEnd,string Registerid,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			
			try
			{
				lngRes = objSvc.m_lngGetPatientDebtDetail(types,StatDate,DateEnd,Registerid,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		public long m_lngGetPatientDebtDetail(System.DateTime StatDate,System.DateTime DateEnd,string Registerid,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientDebtDetail(StatDate,DateEnd,Registerid,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ȡ�����շ���Ŀ����
		public long m_lngGetChargeItemTypesByConfigGroupID(string p_reportid,string p_groupid,out string[] types)
		{
			long lngRes=0;
			types = new string[0];
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetChargeItemTypesByConfigGroupID(p_reportid,p_groupid,out types);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region  ��ȡ��������
		public long m_lngGetDailyDebtConfig(string p_strReportID,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.GetDailyDebtConfig(p_strReportID,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region  ��ȡ���˷���һ���嵥
		public long m_lngGetDailyChargeInfo(string p_strreportid,string p_strRegisterID,System.DateTime p_dtStatTime,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			try
			{
				lngRes = objSvc.m_lngGetDailyChargeInfo(p_strreportid,p_strRegisterID,p_dtStatTime,out dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region  ͨ��סԺ�Ǽ�ID��ȡ����Ƿ������Ϣ
		public long m_lngGetPatientDebtByRegisterID(string p_strRegisterid_chr,out string p_strDebt)
		{
			long lngRes=0;
			p_strDebt = "";
			com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihStatQuerySvc));
			
			try
			{
				lngRes = objSvc.m_lngGetPatientDebtByRegisterID(p_strRegisterid_chr,out p_strDebt);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
	}
}
