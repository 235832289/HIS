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
	/// סԺ�Ǽ��߼����Ʋ�
	/// ���ߣ� ����
	/// ����ʱ�䣺 2004-09-06
	/// </summary>
	public class clsDcl_Register: com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region ���캯��
		public clsDcl_Register()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion

		//T_OPR_BIH_REGISTER(סԺ�Ǽ�)
		#region ����
		/// <summary>
		/// ����סԺ�Ǽ�
		/// </summary>
		/// <param name="p_strRecordID">��ˮ�� [out ����]</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewBihRegister(out string p_strRecordID,clsT_Opr_Bih_Register_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewBihRegister(objPrincipal,out p_strRecordID,p_objRecord);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region ��ѯ
		/// <summary>
		/// ������Ժ�Ǽ���ˮ����õڼ�����Ժ
		/// </summary>
		/// <param name="p_strRegisterid_chr">��Ժ�Ǽ���ˮ��</param>
		/// <param name="intOrder">������ [out ����]</param>
		/// <returns></returns>
		public int m_intGetBihOrderByRegisterID(string p_strRegisterid_chr)
		{
			int intOrder =0;
			long lngRes = 0;
			clsT_Opr_Bih_Register_VO p_objResult = null;
			try
			{
				lngRes=m_lngGetBinRegisterByRegisterID(p_strRegisterid_chr,out p_objResult);
			}
			catch
			{
                intOrder = 0;
			}
			if(lngRes>0 && p_objResult!=null && p_objResult.m_strREGISTERID_CHR!=null)
			{
				intOrder =p_objResult.m_intINPATIENTCOUNT_INT;
			}
			return intOrder;
		}
		/// <summary>
		/// ��ѯ���е�סԺ�Ǽǣ���Ч�ģ�
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetAllBihRegisterInfo(out clsT_Opr_Bih_Register_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Register_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetAllBihRegisterInfo(objPrincipal,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ����סԺ�� ��ѯסԺ�Ǽǡ�[��Ч�ļ�¼]
		/// </summary>
		/// <param name="p_strInpatientid_chr">סԺ��</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBinRegisterByInpatientID(string p_strInpatientid_chr, out clsT_Opr_Bih_Register_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Register_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinRegisterByInpatientID(objPrincipal,p_strInpatientid_chr,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ��ȡסԺ�ŵ����һ��סԺ�Ǽ���ˮ�ţ�û�����ȡΪ�մ�
		/// 		/// </summary>
		/// <param name="p_strInpatientid_chr">סԺ��</param>
		/// <param name="p_strRegisterid_chr">סԺ�Ǽ���ˮ�� [out ����]</param>
		/// <returns></returns>
		public long m_lngGetRegisteridByInpatientID(string p_strInpatientid_chr, out string p_strRegisterid_chr)
		{
			long lngRes=0;
			p_strRegisterid_chr = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetRegisteridByInpatientID(objPrincipal,p_strInpatientid_chr,out p_strRegisterid_chr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ��ȡסԺ�ŵ�סԺ�Ǽ���ˮ�ţ�û�����ȡΪ������
		/// </summary>
		/// <param name="p_strInpatientid_chr">סԺ��</param>
		/// <param name="p_strRegisterid_chr">סԺ�Ǽ���ˮ�� [out ����]</param>
		/// <returns></returns>
		public long m_lngGetRegisteridByInpatientID(string p_strInpatientid_chr, out string[] p_strRegisteridArr)
		{
			long lngRes=0;
			p_strRegisteridArr = new string[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetRegisteridByInpatientID(objPrincipal,p_strInpatientid_chr,out p_strRegisteridArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ����סԺ��ˮ�� ��ѯסԺ�Ǽǡ�[��Ч�ļ�¼]
		/// </summary>
		/// <param name="p_strRegisterid_chr">סԺ��ˮ��</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		public long m_lngGetBinRegisterByRegisterID(string p_strRegisterid_chr, out clsT_Opr_Bih_Register_VO p_objResult)
		{
			long lngRes=0;
			p_objResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinRegisterByRegisterID(objPrincipal,p_strRegisterid_chr,out p_objResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ����������סԺ�Ǽǲ�ѯ
		/// </summary>
		/// <param name="p_strQueryCondition">��ѯ����</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihRegisterInfo(string p_strQueryCondition, out clsT_Opr_Bih_Register_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Register_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihRegisterInfo(objPrincipal,p_strQueryCondition,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region �޸�
		#region  �޸ġ����޸�סԺ�Ǽǵļ�¼״̬��-1��ʷ��0��Ч��1��Ч��
		/// <summary>
		/// �޸�סԺ�Ǽǵļ�¼״̬��-1��ʷ��0��Ч��1��Ч��
		/// </summary>
		/// <param name="p_strRegisterid_chr">��ˮ��</param>
		/// <param name="p_intStatus_int">״̬��-1��ʷ��0��Ч��1��Ч��</param>
		/// <param name="p_strOPERATORID_CHR">������ID</param>
		/// <returns></returns>
		public long m_lngModifyBihRegisterByRegisterID(string p_strRegisterid_chr,int p_intStatus_int,string p_strOPERATORID_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihRegisterByRegisterID(objPrincipal,p_strRegisterid_chr,p_intStatus_int,p_strOPERATORID_CHR);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region  �޸ġ�����Ժ���ҡ���Ժ�����������š���Ժ״̬
		/// <summary>
		///  �޸ġ�����Ժ���ҡ���Ժ�����������š���Ժ״̬
		/// </summary>
		/// <param name="p_strRegisterid_chr">��ˮ��</param>
		/// <param name="p_strDEPTID_CHR">��Ժ����</param>
		/// <param name="p_strAREAID_CHR">��Ժ����</param>
		/// <param name="p_strBEDID_CHR">����</param>
		/// <param name="intPSTATUS_INT">{0=δ�ϴ�;1=���ϴ�;2=Ԥ��Ժ;3=ʵ�ʳ�Ժ}</param>
		/// <param name="p_strOPERATORID_CHR">������</param>
		/// <returns></returns>
		public long m_lngModifyBedInfoByRegisterID(string p_strRegisterid_chr,string p_strDEPTID_CHR,string p_strAREAID_CHR,string p_strBEDID_CHR,int intPSTATUS_INT,string p_strOPERATORID_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			
			try
			{
				lngRes = objSvc.m_lngModifyBedInfoByRegisterID(objPrincipal,p_strRegisterid_chr,p_strDEPTID_CHR,p_strAREAID_CHR,p_strBEDID_CHR,intPSTATUS_INT,p_strOPERATORID_CHR,System.DateTime.Now.ToString());
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region
		public long m_lngModifyBihRegisterPSTATUS_INTByRegisterID(string p_strRegisterid_chr,int intPSTATUS_INT,string p_strOPERATORID_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihRegisterPSTATUS_INTByRegisterID(objPrincipal,p_strRegisterid_chr,intPSTATUS_INT,p_strOPERATORID_CHR,System.DateTime.Now.ToString());
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��SQL�����޸�סԺ�Ǽ���Ϣ
		/// <summary>
		/// ��SQL�����޸�סԺ�Ǽ���Ϣ
		/// </summary>
		/// <param name="p_strSQLUpdate">Update��SQL���</param>
		/// <returns></returns>
		public long m_lngModifyBihRegisterInfo(string p_strSQLUpdate)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihRegisterInfo(objPrincipal,p_strSQLUpdate);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion
		#region ��֤
		/// <summary>
		///  ��֤סԺ���Ƿ����[��Ч]�ǼǼ�¼
		/// </summary>
		/// <param name="p_strInpatientid_chr">סԺ��</param>
		/// <param name="IsRegisterd">�Ƿ���� [out ����]</param>
		/// <returns></returns>
		public long m_lngCheckIsRegisterdByInpatientID(string p_strInpatientid_chr,out bool IsRegisterd)
		{
			long lngRes=0;
			IsRegisterd = false;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngCheckIsRegisterdByInpatientID(objPrincipal,p_strInpatientid_chr,out IsRegisterd);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		
		#region ����סԺ��
		/// <summary>
		/// ����סԺ�� 
		/// </summary>
		/// <param name="p_strInpatientid_chr">סԺ�� [out ����]</param>
		/// <returns></returns>
		public long m_lngGetInpatientID(out string p_strInpatientid_chr)
		{
			long lngRes=0;
			p_strInpatientid_chr = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			
			try
			{
				lngRes = objSvc.m_lngGetInpatientID(objPrincipal,out p_strInpatientid_chr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		

		#region	��ȡסԺ�����б�	glzhang	2005.08.05
		/// <summary>
		/// ��ȡסԺ�����б�	glzhang	2005.08.05
		/// </summary>
		/// <param name="p_strFind">��ѯ�ַ���</param>
		/// <param name="p_dtbResult">�����</param>
		public long m_lngGetInHosPatienList(string p_strFind,out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult = new DataTable();
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetInHosPatienList(objPrincipal,p_strFind,out p_dtbResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		
		#region	������Ժ	glzhang	2005.08.30
		/// <summary>
		/// ������Ժ	glzhang	2005.08.30
		/// </summary>
		/// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
		/// <param name="p_strPatientID">����ID</param>
		/// <param name="p_strPatientID">סԺ��</param>
		/// <param name="p_strInHospitalDate">��Ժ����</param>
		/// <param name="p_intStatus">��Ժ����</param>
		/// <returns></returns>
			public long m_lngModifyCancelPatient(string p_strRegisterID,string p_strPatientID,string p_strInPatientID,string p_strInHospitalDate,int p_intStatus)
			{
				long lngRes=0;
				com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
					(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
				try
				{
					lngRes = objSvc.m_lngModifyCancelPatient(objPrincipal,p_strRegisterID,p_strPatientID,p_strInPatientID,p_strInHospitalDate,p_intStatus);
				}
				catch
				{
					return 0;
				}
				objSvc.Dispose();
				return lngRes;
			}
		#endregion

		#region	���ݲ���ID��ȡ�����������	glzhang	2005.09.29
		/// <summary>
		/// ���ݲ���ID��ȡ�����������	glzhang	2005.09.29
		/// </summary>
		/// <param name="p_strPatientID">����ID</param>
		/// <param name="p_strDiag">�������</param>
		/// <returns></returns>
		public long m_lngFindDiagByPatientID(string p_strPatientID,out string p_strDiag)
		{
			p_strDiag="";
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngFindDiagByPatientID(objPrincipal,p_strPatientID,out p_strDiag);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region	��ȡ����ת�벡����Ϣ�б�	glzhang	2005.10.10
		/// <summary>
		/// ��ȡ����ת�벡����Ϣ�б�	glzhang	2005.10.10
		/// </summary>
		/// <param name="p_dtbResult">�����</param>
		public long m_lngGetTurnInPatienList(out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult = new DataTable();
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetTurnInPatienList(objPrincipal,out p_dtbResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ���ݲ���ID��ȡ������Ժ��Ϣ,��������д��Ժ�Ǽǿ�ʱ���ж� glzhang	2005.10.12
		/// <summary>
		/// ���ݲ���ID��ȡ������Ժ��Ϣ,��������д��Ժ�Ǽǿ�ʱ���ж� glzhang	2005.10.12
		/// </summary>
		/// <param name="p_strInPatientID">����ID</param>
		/// <param name="p_intFlag">��־:0=��Ժ������ת��Ĳ�����Ϣ,��������Ժ�Ǽǿ�ʹ��;1=��Ժ������ת��Ĳ�����Ϣ,��Ժʱʹ��</param>
		/// <param name="p_dtbResult">�����</param>
		/// <returns></returns>
		public long m_lngGetPatientInHospitalInfo(string p_strInPatientID,int p_intFlag,out DataTable p_dtbResult)
		{
			long lngRes=0;
			p_dtbResult=null;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInHospitalInfo(objPrincipal,p_strInPatientID,p_intFlag,out p_dtbResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region	����ת�벡����Ժ	glzhang	2005.10.10
		/// <summary>
		/// ����ת�벡����Ժ	glzhang	2005.10.10
		/// </summary>
		/// <param name="p_strRegisterID"></param>
		/// <returns></returns>
		public long m_lngPatientTurnIn(string p_strRegisterID,string p_strArearID,string p_strOperatorID,string p_strInPatientID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngPatientTurnIn(objPrincipal,p_strRegisterID,p_strArearID,p_strOperatorID,p_strInPatientID);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �޸Ĳ���סԺ�� glzhag	glzhang 2006.01.20
		/// <summary>
		/// �޸Ĳ���סԺ�� glzhag	glzhang 2006.01.20
		/// </summary>
		/// <param name="p_strOldInPatientID">��סԺ��</param>
		/// <param name="p_strNewInPatientID">��סԺ��</param>
		/// <returns></returns>
		public long m_lngModifyInPatientID(string p_strOldInPatientID,string p_strNewInPatientID)
		{
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			return objSvc.m_lngModifyInPatientID(objPrincipal,p_strOldInPatientID,p_strNewInPatientID);
		}
		#endregion

        #region	�Ż�ȡԤ�������	glzhang	2005.03.06
        /// <summary>
        /// ��ȡԤ�������	glzhang	2005.03.06
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <returns></returns>
        public long m_lngGetPrepayMoney(string p_strRegisterID, out DataTable p_dtbResult)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            lngRes = objSvc.m_lngGetPrepayMoney(objPrincipal, p_strRegisterID, out p_dtbResult);
            return lngRes;
        }
        #endregion

		//T_Opr_Bih_Leave(��Ժ��¼)
		#region ����
		/// <summary>
		/// ��Ժ---���ӳ�Ժ��¼
		/// </summary>
		/// <param name="p_strRecordID">��ˮ��[200409010001] [out ����]</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewBihLeave(out string p_strRecordID,clsT_Opr_Bih_Leave_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewBihLeave(objPrincipal,out p_strRecordID,p_objRecord);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region ����
		/// <summary>
		/// ��ѯ���еĳ�Ժ��¼����Ч�ģ�
		/// </summary>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetAllBihLeaveInfo(out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetAllBihLeaveInfo(objPrincipal,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ������Ժ�Ǽ���ˮ�Ų�ѯ��Ч�ĳ�Ժ�ǼǼ�¼ {ԭ����ֻ��һ����Ч�ļ�¼}
		/// </summary>
		/// <param name="p_strRegisterid_chr">��Ժ�Ǽ���ˮ��</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBinLeaveByRegisterID(string p_strRegisterid_chr, out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinLeaveByRegisterID(objPrincipal,p_strRegisterid_chr,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ������������Ժ��¼��ѯ
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strQueryCondition">��ѯ����</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihLeaveInfo(string p_strQueryCondition, out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihLeaveInfo(objPrincipal,p_strQueryCondition,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region �޸� | ɾ��
		/// <summary>
		/// �޸ĳ�Ժ�ļ�¼״̬��-1��ʷ��0��Ч��1��Ч��	������ˮ��
		/// </summary>
		/// <param name="p_strID">��Ժ��ˮ��</param>
		/// <param name="p_intStatus_int">״̬��-1��ʷ��0��Ч��1��Ч��</param>
		/// <param name="p_strOPERATORID_CHR">������ID</param>
		/// <returns></returns>
		public long m_lngModifyBihLeaveSTATUS_INTByID(string p_strID,int p_intStatus_int,string p_strOPERATORID_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihLeaveSTATUS_INTByID(objPrincipal,p_strID,p_intStatus_int,p_strOPERATORID_CHR);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ��SQL�����޸ĳ�Ժ�Ǽ���Ϣ
		/// </summary>
		/// <param name="p_strSQLUpdate">Update��SQL���</param>
		/// <returns></returns>
		public long m_lngModifyBihLeaveInfo(string p_strSQLUpdate)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBihLeaveInfo(objPrincipal,p_strSQLUpdate);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region ��֤
		/// <summary>
		/// ��֤ĳ��Ժ��ˮ���Ƿ����[��Ч]��Ժ��¼
		/// </summary>
		/// <param name="p_strRegisterid_chr">��Ժ�Ǽ���ˮ��</param>
		/// <param name="IsLeaveHospital">�Ƿ��Ժ [out ����]</param>
		/// <returns></returns>
		public long m_lngCheckIsLeaveHospitalByRegisterID(string p_strRegisterid_chr,out bool IsLeaveHospital)
		{
			long lngRes=0;
			IsLeaveHospital = false;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngCheckIsLeaveHospitalByRegisterID(objPrincipal,p_strRegisterid_chr,out IsLeaveHospital);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		//�ۺ� 
		#region ��ȡסԺ�ŵ����һ��סԺ��״̬ [�״���Ժ����Ժ���ѳ�Ժ]  
		/// <summary>
		/// ��ȡסԺ�ŵ����һ��סԺ��״̬ [�״���Ժ����Ժ���ѳ�Ժ] 
		/// </summary>
		/// <param name="p_strInpatientid_chr">סԺ��</param>
		/// <param name="p_intBihState">סԺ״̬ {1-�״���Ժ��2-��Ժ��3-�ѳ�Ժ} [ out ���� ]</param>
		/// <returns></returns>
		public long m_lngGetBihState(string p_strInpatientid_chr, out int p_intBihState)
		{
			long lngRes=0;
			p_intBihState = 0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihState(objPrincipal,p_strInpatientid_chr,out p_intBihState);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region ��ȡסԺ��ˮ�ŵ�סԺ״̬ [�״���Ժ����Ժ���ѳ�Ժ]  
		/// <summary>
		/// ��ȡסԺ��ˮ�ŵ�סԺ״̬ [�״���Ժ����Ժ���ѳ�Ժ] 
		/// </summary>
		/// <param name="p_strRegisterid_chr">סԺ��ˮ��</param>
		/// <param name="p_intBihState">סԺ״̬ {1-�״���Ժ��2-��Ժ��3-�ѳ�Ժ} [ out ���� ]</param>
		/// <returns></returns>
		public long m_lngGetBihStateByRegisterID(string p_strRegisterid_chr, out int p_intBihState)
		{
			long lngRes=0;
			p_intBihState =0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihStateByRegisterID(objPrincipal,p_strRegisterid_chr,out p_intBihState);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region ��ȡĳסԺ�ŵ�����[��Ч��]��Ժ��¼
		/// <summary>
		/// ��ȡĳסԺ�ŵ�����[��Ч��]��Ժ��¼
		/// </summary>
		/// <param name="p_strInpatientid_chr">סԺ��</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihLeaveByInpatientID(string p_strInpatientid_chr,out clsT_Opr_Bih_Leave_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Leave_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihLeaveByInpatientID(objPrincipal,p_strInpatientid_chr,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region  ��ȡĳסԺ�ŵ�����[��Ч��]��ת��¼
		/// <summary>
		///  ��ȡĳסԺ�ŵ�����[��Ч��]��ת��¼
		/// </summary>
		/// <param name="p_strInpatientid_chr">סԺ��</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihTransferByInpatientID(string p_strInpatientid_chr,string p_strFilter,out clsT_Opr_Bih_Transfer_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihTransferByInpatientID(objPrincipal,p_strInpatientid_chr,p_strFilter,out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region	����סԺ������¼	glzhang	2005.09.14
		/// <summary>
		/// ����סԺ������¼ glzhang	2005.09.14
		/// </summary>
		/// <param name="p_strRegisterid_chr">ID</param>
		/// <param name="p_strFilter">��ѯ�ַ���</param>
		/// <param name="p_objResultArr">�����</param>
		/// <param name="p_intFlag">������־:0=����סԺ������¼;1=����סԺ������¼</param>
		/// <returns></returns>
		public long m_lngGetBinTransferByRegisterID(string p_strRegisterid_chr,string p_strFilter,out clsT_Opr_Bih_Transfer_VO[] p_objResultArr,int p_intFlag)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinTransferByRegisterID(objPrincipal, p_strRegisterid_chr,p_strFilter, out p_objResultArr,p_intFlag);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		//Add by jli 2005-03-03
		#region ��ȡ��Ժ�ٻ�����
		public long m_lngGetRecallLimit()
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lnggetrecalllimitdays(objPrincipal);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ��ȡ���һ��סԺ����
		public long m_lngGetLastLeaveDate(string strregisterid,out DateTime dtleave)
		{
			long lngRes=0;
			dtleave=DateTime.Now;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lnggetlastleavedate(objPrincipal,strregisterid,out dtleave);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region �ж��Ƿ�����ٻ�
		public long m_lngIfCanRecall(string strregisterid)
		{
			DateTime dtLast=DateTime.Now;
			try
			{
				long lngRes=m_lngGetLastLeaveDate(strregisterid,out dtLast);
			}
			catch
			{
			}
		    TimeSpan ts=DateTime.Now-dtLast;
		    if(ts.Days<=m_lngGetRecallLimit())
		    {
		     	return 0;
		    }
		    else
		    {
		     	return -1;
		    }

		}
		#endregion

		//Add End
		//T_Opr_Bih_Transfer(סԺ��ת��¼)
		#region ����
		/// <summary>
		/// ����סԺ��ת��¼
		/// </summary>
		/// <param name="p_strRecordID">סԺ��ת��ˮ�� [out ����]</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewBinTransfer(out string p_strRecordID,clsT_Opr_Bih_Transfer_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewBinTransfer(objPrincipal,out p_strRecordID, p_objRecord);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ����
		/// <summary>
		/// ������Ժ�Ǽ���ˮ�Ų�ѯת����¼ {�����ˣɣĵ��Σ����ת��}
		/// </summary>
		/// <param name="p_strRegisterid_chr">��Ժ�Ǽ���ˮ��</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBinTransferByRegisterID(string p_strRegisterid_chr,string p_strFilter,out clsT_Opr_Bih_Transfer_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinTransferByRegisterID(objPrincipal, p_strRegisterid_chr,p_strFilter, out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ����ת����ˮ�Ų�ѯ��Ӧ��¼����Ϣ
		/// </summary>
		/// <param name="p_strTransferID">ת����ˮ��</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		public long m_lngGetBinTransferByTransferID(string p_strTransferID, out clsT_Opr_Bih_Transfer_VO p_objResult)
		{
			long lngRes=0;
			p_objResult =null;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBinTransferByTransferID(objPrincipal, p_strTransferID, out p_objResult);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ����������ת����ѯ
		/// </summary>
		/// <param name="p_strQueryCondition">��ѯ����</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetBihTransferInfo(string p_strQueryCondition, out clsT_Opr_Bih_Transfer_VO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = new clsT_Opr_Bih_Transfer_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetBihTransferInfo(objPrincipal, p_strQueryCondition, out p_objResultArr);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		//���˻�����Ϣ
		#region ����
		#region ���Ӳ��˻�������
		/// <summary>
		/// ���Ӳ��˻�������
		/// </summary>
		/// <param name="p_strRecordID">��ˮ��</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewPatient(out string p_strRecordID,clsPatient_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = null;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewPatient(objPrincipal,out p_strRecordID,p_objRecord);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region ���Ӳ��˻�������������
		/// <summary>
		/// ���Ӳ��˻�������������
		/// </summary>
		/// <param name="p_strRecordID">��ˮ��</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewPatientIdx(out string p_strRecordID,clsclsPatientIdxVO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewPatientIndexInfo(objPrincipal,out p_strRecordID,p_objRecord);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		

		#region  ���Ӳ��˿���¼
		/// <summary>
		/// ���Ӳ��˿���¼
		/// </summary>
		/// <param name="p_strRecordID"></param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewPatientCard(out string p_strRecordID,clsPatientCardVO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			clsPatientSvc objSvc = (clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			
			try
			{
				lngRes = objSvc.m_lngAddNewPatientCard(objPrincipal,out p_strRecordID,p_objRecord);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion		
		#region ��ѯ
		#region ����סԺ��
		/// <summary>
		/// ����סԺ�Ż�ȡ���˻�����Ϣ
		/// </summary>
		/// <param name="p_strInpatientid_chr">סԺ��</param>
		/// <param name="objPatientVO"></param>
		/// <returns></returns>
		public long m_lngGetPatientInfoByInpatientID(string p_strInpatientid_chr,out clsPatient_VO objPatientVO)
		{
			long lngRes=0;
			objPatientVO =null;
			clsPatient_VO[] p_objResultArr;
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoByInpatientID(objPrincipal,p_strInpatientid_chr,out p_objResultArr);
			
				if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
					objPatientVO =p_objResultArr[0];
				objSvc.Dispose();
			}
			catch
			{
				return 0;
			}
			return lngRes;
		}
		#endregion 

		#region ���ݲ��˱��
		/// <summary>
		/// �������ƿ��Ż�ȡ���˻�����Ϣ
		/// </summary>
		/// <param name="strPatientID">���ƿ���</param>
		/// <param name="objPatientVO"></param>
		/// <returns></returns>
		public long m_lngGetPatientInfoByPatientID(string strPatientID,out clsPatient_VO objPatientVO)
		{
			long lngRes=0;
			objPatientVO =null;
			clsPatient_VO[] p_objResultArr;
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngShowOneRecord(objPrincipal,strPatientID,out p_objResultArr);
				if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
					objPatientVO =p_objResultArr[0];
				objSvc.Dispose();
			}
			catch
			{
				return 0;
			}
			return lngRes;
		}
		#endregion 

		#region �������֤��
		/// <summary>
		/// �������֤�Ż�ȡ���˻�����Ϣ
		/// </summary>
		/// <param name="p_strIDCARD_CHR">���֤��</param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetPatientInfoByIDCARD(string p_strIDCARD_CHR, out clsPatient_VO objPatientVO)
		{
			long lngRes=0;
			objPatientVO =null;
			clsPatient_VO[] p_objResultArr;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoByIDCARD(objPrincipal,p_strIDCARD_CHR,out p_objResultArr);
				if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
					objPatientVO =p_objResultArr[0];
				objSvc.Dispose();
			}
			catch
			{
				return 0;
			}
			return lngRes;
		}
		#endregion 

		#region ����ҽ�����
		/// <summary>
		/// ����ҽ����Ż�ȡ���˻�����Ϣ
		/// </summary>
		/// <param name="p_strInsuranceID">���˱��</param>
		/// <returns></returns>
		public long m_lngGetPatientInfoByInsuranceID(string p_strInsuranceID, out clsPatient_VO objPatientVO)
		{
			long lngRes=0;
			objPatientVO =null;
			clsPatient_VO[] p_objResultArr;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientInfoByInsuranceID(objPrincipal,p_strInsuranceID,out p_objResultArr);
				if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
					objPatientVO =p_objResultArr[0];
				objSvc.Dispose();
			}
			catch
			{
				return 0;
			}
			return lngRes;
		}
		#endregion	

		#region ���ݲ������Ż�ò��˱��
		public string m_strGetPatientIDByPatientcardid(string p_strPatientcardid)
		{
			string strPatientID ="";
			if(p_strPatientcardid.Trim()=="")
				return strPatientID;
			
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				objSvc.m_lngGetPatientIDByPatientcardid(objPrincipal,p_strPatientcardid,out strPatientID);
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
		
			return strPatientID;
		}
		#endregion		

		#region ���ݲ��˱�Ż�ò�������
		/// <summary>
		/// ���ݲ��˱�Ż�ò�������
		/// </summary>
		/// <param name="p_strPatientID">���˱��</param>
		/// <returns></returns>
		public string m_strGetPatientcardidByPatientID(string p_strPatientID)
		{
			string strPatientcardid ="";
			if(p_strPatientID.Trim()=="")
				return strPatientcardid;
			
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				objSvc.m_lngGetPatientcardidByPatientID(objPrincipal,p_strPatientID,out strPatientcardid);
			
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
		
			return strPatientcardid;
		}
		#endregion			

        #region ����סԺ�Ǽ���ˮ��
        /// <summary>
        /// ����סԺ�Ǽ���ˮ��
        /// </summary>
        /// <param name="p_strREGISTERID_CHR">סԺ��</param>
        /// <param name="objPatientVO"></param>
        /// <returns></returns>
        public long m_lngGetPatientInfoByREGISTERID_CHR(string p_strREGISTERID_CHR, out clsPatient_VO objPatientVO)
        {
            long lngRes = 0;
            objPatientVO = null;
            
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objSvc.m_lngGetPatientInfoByREGISTERID_CHR(objPrincipal, p_strREGISTERID_CHR, out objPatientVO);

                objSvc.Dispose();
            }
            catch
            {
                return 0;
            }
            return lngRes;
        }
        #endregion 
		#endregion 
		#region �޸�
		#region  �޸Ĳ��˻�����Ϣ
		/// <summary>
		/// �޸Ĳ��˻�����Ϣ
		/// </summary>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngModifyPatient(clsPatient_VO p_objRecord)
		{
			long lngRes=0;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			
			try
			{
				lngRes = objSvc.m_lngModifyPatient(objPrincipal,p_objRecord);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion	
	
		#region  �޸Ĳ��˻�������������
		/// <summary>
		/// �޸�������
		/// </summary>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngModifyPatientIdx(clsclsPatientIdxVO p_objRecord)
		{
			long lngRes=0;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngModifyPatientIdx(objPrincipal,p_objRecord);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion		

		#region �޸Ĳ��˿���
		/// <summary>
		/// �޸Ĳ��˿���
		/// </summary>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngModifyPatientCard(clsPatientCardVO p_objRecord)
		{
			long lngRes=0;
			clsPatientSvc objSvc = 
				(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngModifyPatientCard(objPrincipal,p_objRecord);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion		
		#endregion		
		#region ��ʼ��
		#region ��ʼ���������������
		/// <summary>
		/// ��ʼ���������������
		/// </summary>
		/// <param name="p_cboName">������ID</param>
		public void m_FillCboPatientType(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			long lngRes;
			clsPatientPayTypeVO[] objPatientTypeVO;
			clsPatientSvc objSvc =(clsPatientSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
                lngRes = objSvc.m_GetBIHPatientType(objPrincipal, out objPatientTypeVO);
			}
			catch
			{
				return;
			}
			if(lngRes<=0)
				return;
			for(int i=0;i<objPatientTypeVO.Length;i++)
			{
				p_cboName.Items.Add(objPatientTypeVO[i].m_strPAYTYPENAME_VCHR.ToString());
			}
			p_cboName.Tag=objPatientTypeVO;
			objSvc.Dispose();
		}
		#endregion		

		#region ��ʼ���������������
		/// <summary>
		/// ��ʼ������������
		/// </summary>
		/// <param name="p_cboName">������ID</param>
		public void m_FillCboNationality(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(2,out objResultArr);
			if(objResultArr.Length == 0) 
				return;
			for(int i=0;i< objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion	
	
		#region ��ʼ���������������
		/// <summary>
		/// ��ʼ���������������
		/// </summary>
		/// <param name="p_cboName">������ID</param>
		public void m_FillCboPatientRace(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(1,out objResultArr);
			if(objResultArr.Length == 0) 
				return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region ��ʼ������������
		/// <summary>
		/// ��ʼ������������
		/// </summary>
		/// <param name="p_cboName">������ID</param>
		public void m_FillCboPatientNativeplace(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			p_cboName.Items.Add("");

			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(3,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region ��ʼ��ְҵ������
		/// <summary>
		/// ��ʼ��ְҵ������
		/// </summary>
		/// <param name="p_cboName">������ID</param>
		public void m_FillCboPatienttxtOccupation(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(9,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region ��ʼ����ϵ������
		/// <summary>
		/// ��ʼ����ϵ������
		/// </summary>
		/// <param name="p_cboName">������ID</param>
		public void m_FillCboPatientRelation(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			p_cboName.Items.Add("");

			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(4,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region ��ʼ�����������
		/// <summary>
		/// ��ʼ�����������
		/// </summary>
		/// <param name="p_cboName">������ID</param>
		public void m_FillCboMarried(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();
			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(5,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion

		#region ��ʼ���Ա�������
		/// <summary>
		/// ��ʼ���Ա�������
		/// </summary>
		/// <param name="p_cboName">������ID</param>
		public void m_FillCboSex(ComboBox p_cboName)
		{
			p_cboName.Items.Clear();

			clsCommmonInfo clscommanInfo = new clsCommmonInfo();
			clsAIDDICT_VO[] objResultArr = null;
			clscommanInfo.m_mthGetAID_DICT_InfoArr(10,out objResultArr);
			if(objResultArr.Length == 0) return;
			for(int i=0;i<objResultArr.Length;i++)
			{
				p_cboName.Items.Add(objResultArr[i].m_strDICTNAME_VCHR);
			}
		}
		#endregion
		#endregion		
		#region ��֤���˱���Ƿ����
		public bool IsExistPatientID(string p_strPatientID)
		{
			bool IsExist =false;
			long lngRes=0;
			clsPatient_VO[] p_objResultArr = null;
			clsPatientSvc objSvc = (clsPatientSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientSvc));
			try
			{
				lngRes = objSvc.m_lngShowOneRecord(objPrincipal,p_strPatientID,out p_objResultArr);
			}
			catch
			{
				lngRes = 0;
			}
			if(lngRes>0 && p_objResultArr!= null && p_objResultArr.Length >0)
				IsExist =true;
			objSvc.Dispose();
	
			return IsExist;		
		}
		#endregion 

		//��λ��Ϣ
		#region ���ݲ����š����š����޸Ĳ���״̬ {1=�մ�;2=ռ��;3=ԤԼռ��;4=����ռ��}
		/// <summary>
		///  ���ݲ����š����š����޸Ĳ���״̬ {1=�մ�;2=ռ��;3=ԤԼռ��;4=����ռ��}
		/// </summary>
		/// <param name="p_strAreaID_chr">������</param>
		/// <param name="p_strCode_chr">����</param>
		/// <param name="p_intStatus_int">����״̬ {1=�մ�;2=ռ��;3=ԤԼռ��;4=����ռ��}</param>
		/// <returns></returns>
		public long m_lngModifyBedByCode_chr(string p_strAreaID_chr,string p_strCode_chr,int p_intStatus_int )
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngModifyBedByAreaIDCode(objPrincipal,p_strAreaID_chr,p_strCode_chr,p_intStatus_int);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��֤�մ�	[���ݲ����š�����]
		/// <summary>
		/// ��֤��Ӧ�����š������Ƿ�մ�
		/// </summary>
		/// <param name="p_strAreaID_chr">������</param>
		/// <param name="p_strCode_chr">����</param>
		/// <returns></returns>
		public bool IsEmptyBedByAreaIDAndCode(string p_strAreaID_chr,string p_strCode_chr)
		{
			bool IsEmptyBed =false;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngCheckIsEmptyBedByAreaIDAndCode(objPrincipal,p_strAreaID_chr,p_strCode_chr,out IsEmptyBed);
		    
			}
			catch
			{
			}objSvc.Dispose();
			return IsEmptyBed;	
		}
		#endregion

		//��������
		#region ��ȡְԱ����
		#region ��ȡְ������	���ݹ���
		/// <summary>
		/// ���ݹ������Ա������
		/// </summary>
		/// <param name="p_strNo">����</param>
		/// <returns>��������</returns>
		public string m_GetEmployeeNameByNo(string p_strNo)
		{	
			string p_strName="";

			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsInvoiceManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetApplyName(objPrincipal,p_strNo,out p_strName);
			
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
			return p_strName;
		}
		#endregion
		#region ��ȡְԱ����	������ˮ��
		/// <summary>
		/// ��ȡְԱ����	������ˮ��
		/// </summary>
		/// <param name="p_strID">��ˮ��</param>
		/// <returns></returns>
		public string m_GetEmployeeNameByID(string p_strID)
		{
			string p_strName ="";
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetEmployeeNameByID(objPrincipal, p_strID, out p_strName);
			
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
			return p_strName;
		}
		#endregion
		#endregion
		#region ��ȡ��������
		/// <summary>
		/// ��ѯĳ����ID��Ӧ�Ĳ�������
		/// </summary>
		/// <param name="p_strID">����ID</param>
		/// <returns></returns>
		public string m_DeptIDToName(string p_strID)
		{
			string strName="";
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngDeptIDToName(objPrincipal,p_strID,out strName);
			
			}
			catch
			{
				return "";
			}
			objSvc.Dispose();
			return strName;
		}
		#endregion		
		#region ��ȡ������Ϣ
		public long m_lngGetAreaInfo(string p_strFilter,out com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] p_objRecordArr)
		{
			long lngRes=0;
			p_objRecordArr = new clsT_BSE_DEPTDESC_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetAreaInfo(objPrincipal,p_strFilter,out p_objRecordArr);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ����Ԥ����
		/// <summary>
		/// ����Ԥ�����շ�
		/// </summary>
		/// <param name="p_strRecordID">��ˮ��</param>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewPrePay(out string p_strRecordID,clsT_opr_bih_prepay_VO p_objRecord)
		{
			long lngRes=0;
			p_strRecordID = "";
			com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
			try
			{
				lngRes = objSvc.m_lngAddNewPrePay(objPrincipal,out p_strRecordID,p_objRecord);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ȡ���������Ժ�Ǽ���ˮ��
		/// <summary>
		/// ��ȡ���������Ժ�Ǽ���ˮ��
		/// </summary>
		/// <param name="p_strRegisterID">��Ժ�Ǽ���ˮ��</param>
		/// <param name="p_dblBalanceMoney">���� [out ���� double����]</param>
		/// <returns></returns>
		public long m_lngGetBalanceMoneyByRegisterID(string p_strRegisterID,out double p_dblBalanceMoney)
		{
			long lngRes=0;
			p_dblBalanceMoney = 0;
			com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBIHChargeSvc));
			try
			{
				lngRes = objSvc.m_lngGetBalanceMoneyByRegisterID(p_strRegisterID,out p_dblBalanceMoney);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ȡ��ǰδͣ�ĳ���ҽ��
		/// <summary>
		/// ��ȡ��ǰδֹͣ[���]�ĳ���ҽ��	������Ժ�Ǽ�ID	
		/// ҵ��˵��: {����=1-����; ִ��״̬=1-�ύ;2-ִ��;5- ���ִ��;}
		/// </summary>
		/// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
		/// <param name="p_objResultArr">ҽ��Vo����[out ����]</param>
		/// <returns></returns>
		/// <remark>
		/// ִ������	{1=����;2=��ʱ;}
		/// ִ��״̬	{-1����ҽ��;0-����;1-�ύ;2-ִ��;3-ֹͣ;4-����;5- ���ִ��;6-���ֹͣ;}
		/// </remark>
		public long m_lngGetNotStopLongOrderByRegisterID(string p_strRegisterID,out clsBIHOrder[] p_objResultArr)
		{			
			long lngRes=0;
			p_objResultArr = new clsBIHOrder[0];
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
			try
			{
				lngRes = objSvc.m_lngGetNotStopLongOrderByRegisterID2(objPrincipal, p_strRegisterID,out p_objResultArr);
			
			}
			catch
			{
				return 0;
			}return lngRes;
		}
		#endregion
		#region ֹͣ����ҽ��
		/// <summary>
		/// ֹͣ����ҽ��	
		/// ִ��״̬	{-1����ҽ��;0-����;1-�ύ;2-ִ��;3-ֹͣ;4-����;5- ���ִ��;6-���ֹͣ;}
		/// ҵ��˵����	ֻ���״̬��1-�ύ��2-ִ��
		/// </summary>
		/// <param name="p_objItemArr">ҽ������Vo [����]</param>
		/// <param name="p_strDoctorID">ִ����ID</param>
		/// <param name="p_strDoctorName">ִ��������</param>
		/// <returns></returns>
        //public long m_lngStopOrder(clsBIHOrder[] p_objItemArr,string p_strDoctorID,string p_strDoctorName)
        //{
        //    long lngRes=0;
        //    com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
        //    try
        //    {
        //        lngRes = objSvc.m_lngStopOrder(objPrincipal,p_objItemArr,p_strDoctorID,p_strDoctorName);	
        //    }
        //    catch
        //    {
        //        return 0;
        //    }return lngRes;
        //}
		#endregion
		#region ���ֹͣҽ��
		/// <summary>
		/// ���ֹͣ
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strOrderIDArr">[����]	ҽ��ID</param>
		/// <param name="p_strHandlersID">������ID</param>
		/// <param name="p_strHandlers">����������</param>
		/// <returns></returns>
		/// <remarks>
		/// �����������ҽ��,��Ʒ�	{ͬ���ţ��÷����Ʒ�}
		/// </remarks>
		public long m_lngAuditingForStop(string[] p_strOrderIDArr,string p_strHandlersID,string p_strHandlers)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
			try
			{
				lngRes = objSvc.m_lngAuditingForStop(objPrincipal,p_strOrderIDArr,p_strHandlersID,p_strHandlers);
			
			}
			catch
			{
				return 0;
			}return lngRes;
		}
		#endregion
		#region ֹͣ[���]
		/// <summary>
		/// ֹͣ[���] ��һ��������ִ��
		/// �ô�:	һ�������Զ�ֹͣҽ��
		/// </summary>
		/// <param name="p_objOrderArr">ҽ�����ݶ���</param>
		/// <param name="p_strHandlersID"></param>
		/// <param name="p_strHandlers"></param>
		/// <returns></returns>
        //public long m_lngStopANDAuditingOrder(clsBIHOrder[] p_objOrderArr,string p_strHandlersID,string p_strHandlers)
        //{
        //    long lngRes=0;
        //    com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
        //    try
        //    {
        //        lngRes = objSvc.m_lngStopANDAuditingOrder(objPrincipal,p_objOrderArr,p_strHandlersID,p_strHandlers);			
        //    }
        //    catch
        //    {
        //        return 0;
        //    }return lngRes;
        //}
		#endregion
		#region �ж��Ƿ����δ���ֹͣ������ҽ��
		/// <summary>
		/// �ж��Ƿ����δ���ֹͣ������ҽ��
		/// </summary>
		/// <param name="p_strRegisterID">��Ժ�Ǽ���ˮ��</param>
		/// <returns></returns>
		public bool m_blnExistNotCheckConfreqOrder(string p_strRegisterID)
		{
			bool p_blnExist =false;
			long lngRes=0;
			com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService objSvc =(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderExecuteService));
			try
			{
				lngRes = objSvc.m_lngJudgeExistNotCheckConfreqOrder(objPrincipal,p_strRegisterID,out p_blnExist);
			
			}
			catch
			{
				return false;
			}objSvc.Dispose();
			return p_blnExist;
		}
		#endregion
		#region �жϽ�����Ժ�������Ժ�Ĳ��ˣ��Ƿ�©���մ�λ��|���
		/// <summary>
		/// �ж��Ƿ�Խ�����Ժ�������Ժ�Ĳ��ˣ���ȡ�˴�λ��
		/// ����: {0-û���շ�;1-�Ѿ��շ�;2-���ǽ�����Ժ�Ĳ���;}
		/// </summary>
		/// <param name="p_strRegisterID">��Ժ�Ǽ���ˮ��</param>
		/// <returns>{0-û���շ�;1-�Ѿ��շ�;2-���ǽ�����Ժ�Ĳ���;}</returns>
		public long m_lngChargeBedForTodayPatient(string p_strRegisterID)
		{
			bool p_blnExist =false;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngChargeBedForTodayPatient(objPrincipal,p_strRegisterID,out p_blnExist);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			if (lngRes>0)
			{
				if (lngRes==2)	
					return 2;	//���ǽ�����Ժ�Ĳ���	
				if (p_blnExist) 
					return 1;	//�Ѿ��շ�
				else
					return 0;	//û���շ�
			}
			return 0;
		}
		/// <summary>
		/// �ж��Ƿ�Խ�����Ժ�������Ժ�Ĳ��ˣ���ȡ�����
		/// ����: {0-û���շ�;1-�Ѿ��շ�;2-���ǽ�����Ժ�Ĳ���;}
		/// </summary>
		/// <param name="p_strRegisterID">��Ժ�Ǽ���ˮ��</param>
		/// <returns>{0-û���շ�;1-�Ѿ��շ�;2-���ǽ�����Ժ�Ĳ���;}</returns>
		public long m_lngChargeDiagnosisForTodayPatient(string p_strRegisterID)
		{
			bool p_blnExist =false;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngChargeDiagnosisForTodayPatient(objPrincipal,p_strRegisterID,out p_blnExist);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			if (lngRes>0)
			{
				if (lngRes==2)	
					return 2;	//���ǽ�����Ժ�Ĳ���	
				if (p_blnExist) 
					return 1;	//�Ѿ��շ�
				else
					return 0;	//û���շ�
			}
			return 0;
		}
		#endregion

        #region ���ݲ�����Ժ�Ǽ�ID�ж��Ƿ���δֹͣ�ĳ���ҽ��
        /// <summary>
        /// ���ݲ�����Ժ�Ǽ�ID�ж��Ƿ���δֹͣ�ĳ���ҽ��
        /// </summary>
        /// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
        /// <param name="p_blnHaveStop"></param>
        /// <returns></returns>
        public long m_lngGetNotStopLongOrderByRegisterID3(string p_strRegisterID, out bool p_blnHaveStop)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            return objSvc.m_lngGetNotStopLongOrderByRegisterID(objPrincipal, p_strRegisterID, out p_blnHaveStop);
        }
        #endregion

        #region ֹͣ����ҽ��
        /// <summary>
        /// ֹͣ����ҽ��
        /// </summary>
        /// <param name="p_strRegisterID">��Ժ�Ǽ�ID</param>
        /// <param name="strHandlerID"></param>
        /// <param name="p_strHandlerName"></param>
        /// <returns></returns>
        public long m_lngStopANDAuditingOrderByRegID(string p_strRegisterID, string strHandlerID, string p_strHandlerName)
        {
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface objSvc = (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderInterface));
            return objSvc.m_lngStopANDAuditingOrderByRegID(objPrincipal, p_strRegisterID, strHandlerID, p_strHandlerName);
        }
        #endregion

		//���񷽷�
		#region ��Ժ�Ǽ�
		/// <summary>
		/// ��Ժ�Ǽ�
		/// </summary>
		/// <param name="intBihState">סԺ״̬[1���״���Ժ����2��Ժ����3���ٴ���Ժ��]</param>
		/// <param name="objPatientVO">[clsPatient_VO]</param>
		/// <param name="objBIHVO">[clsT_Opr_Bih_Register_VO]</param>
		/// <returns></returns>
		public long m_lngRegisterHospital(int intBihState, clsPatient_VO objPatientVO ,ref clsT_Opr_Bih_Register_VO objBIHVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngRegisterHospital(objPrincipal,intBihState,objPatientVO,ref objBIHVO);
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion		

        #region �޸�סԺ��Ϣ
        /// <summary>
        /// �޸�סԺ��Ϣ
        /// </summary>
        /// <param name="intBihState"></param>
        /// <param name="objPatientVO"></param>
        /// <param name="objBIHVO"></param>
        /// <returns></returns>
        public long m_lngChangeRegisterHospital(int intBihState, clsPatient_VO objPatientVO, ref clsT_Opr_Bih_Register_VO objBIHVO)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
            try
            {
                lngRes = objSvc.m_lngChangeRegisterHospital2(objPrincipal, intBihState, objPatientVO, ref objBIHVO);
            }
            catch
            {
                return 0;
            } objSvc.Dispose();
            return lngRes;
        }
        #endregion		

		#region ��ת
		/// <summary>
		/// ��ת
		/// </summary>
		/// <param name="objPatientVO">[clsT_Opr_Bih_Transfer_VO]</param>
		/// <returns></returns>
		public long m_lngTransferInHospital(clsT_Opr_Bih_Transfer_VO objPatientVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngTransferInHospital(objPrincipal,objPatientVO);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ת
		/// <summary>
		/// ��ת
		/// </summary>
		/// <param name="objPatientVO">[clsT_Opr_Bih_Transfer_VO]</param>
		/// <returns></returns>
		public long m_lngTransferInHospital(clsT_Opr_Bih_Transfer_VO objPatientVO,string p_strCASEDOCTOR_CHR)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngTransferInHospital(objPrincipal,objPatientVO,p_strCASEDOCTOR_CHR);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		
		#region ��Ժ
		/// <summary>
		/// ��Ժ
		/// </summary>
		/// <param name="objPatientVO">[clsT_Opr_Bih_Leave_VO]</param>
		/// <returns></returns>
		public long m_lngLeaveHospital(clsT_Opr_Bih_Leave_VO objPatientVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngLeaveHospital(objPrincipal,objPatientVO);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 
		public bool m_lngIshasAdvice(string p_strRegisterID)
		{
			bool bolHasAdvice = false;
			int Count= 0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			long lngRes = 0;
			try
			{
				 lngRes = objSvc.m_lngIshasAdvice(p_strRegisterID,out Count);
			
			}
			catch
			{
				return false;
			}if(lngRes>0&&Count>0)
			{
				bolHasAdvice = true;
			}
			return bolHasAdvice;
		}
		#endregion
		#region ��Ժ�ٻ�
		/// <summary>
		/// ��Ժ�ٻ�
		/// </summary>
		/// <param name="objPatientVO">[clsT_Opr_Bih_Transfer_VO]</param>
		/// <returns></returns>
		public long m_lngRecallHospital(clsT_Opr_Bih_Transfer_VO objPatientVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngRecallHospital(objPrincipal,objPatientVO);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		
		#region ����סԺ�Ǽ�ID��ѯ��ת��Ϣ
		public long m_lngGetTransferInfoByRegisterID(string p_strRegisterID,out com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Transfer_VO p_objResult)
		{
			long lngRes=0;
			p_objResult =null;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			
			try
			{
				lngRes = objSvc.m_lngGetTransferInfoByRegisterID(objPrincipal,p_strRegisterID,out p_objResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��õ��Ӳ���������Ϣ
		#region ��������סԺ�Ǽ���Ϣ
		public long m_lngGetPatientRegisterInfoByID(string p_strRegisterID,out com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Register_VO objResult)
		{
			long lngRes=0;
			objResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientRegisterInfoByID(objPrincipal,p_strRegisterID,out objResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ô�λ��Ϣ
		public long m_lngGetBedInfoByID(string p_strBedID,out com.digitalwave.iCare.ValueObject.clsT_Bse_Bed_VO objResult)
		{
			long lngRes=0;
			objResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetBedInfoByID(objPrincipal,p_strBedID,out objResult);
			
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ò�����Ϣ
		public long m_lngGetAreaInfoByID(string p_strAreaID,out com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO objResult)
		{
			long lngRes=0;
			objResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetAreaInfoByID(objPrincipal,p_strAreaID,out objResult);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion
		#region ��ȡ���߻�������
		public long m_lngGetPatientCareInfo(string p_strResgisterID,out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetPatientCareInfo(objPrincipal,p_strResgisterID,out dtbResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region 
		public long m_lngGetSpChargeItemIDType(out DataTable dtbResult)
		{
			long lngRes=0;
			dtbResult = null;
			com.digitalwave.iCare.middletier.HIS.clsBedManageSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBedManageSvc));
			try
			{
				lngRes = objSvc.m_lngGetSpChargeItemIDType(out dtbResult);
			}
			catch
			{
				return 0;
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ȡ����ҽʦ��Ϣ
		public long m_lngGetMainDoctor(string p_strFilter,out com.digitalwave.iCare.ValueObject.clsEmployee_VO[] p_objRecordArr)
		{
			long lngRes=0;
			p_objRecordArr = new clsEmployee_VO[0];
			com.digitalwave.iCare.middletier.HIS.clsPatientQuerySVC objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsPatientQuerySVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPatientQuerySVC));
			try
			{
				lngRes = objSvc.m_lngGetMainDoctor(objPrincipal,p_strFilter,out p_objRecordArr);
			
			}
			catch
			{
				return 0;
			}objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region �ж�סԺ���Ƿ��ظ�
		public bool IsExistInptientID(string InpatientID)
		{
			bool IsExist = false;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
			
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				IsExist= objSvc.IsExistInptientID(InpatientID);
			}
			catch
			{
			}
			return IsExist;
		}
		#endregion
		#region �ж�ҽ�����Ƿ��ظ�
		public bool m_lngCheckInsuranceNum(string insuranceID,string PatientID)
		{
			bool IsExist = false;
			long lngRes = 0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
			
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes= objSvc.m_lngCheckInsuranceNum(insuranceID,PatientID,out IsExist);
				if(lngRes>0)
				{
					return IsExist;
				}
			}
			catch
			{
				return false;
			}
			return false;
		}
		#endregion
		#region סԺ���״̬ add by wjqin (05-12-15)
		/// <summary>
		/// סԺ���״̬
		/// </summary>
		/// <param name="m_intISHOSNUMATUO"></param>
		/// <returns></returns>
		public long m_lngGetISHOSNUMATUO(out int m_intISHOSNUMATUO)
		{
			m_intISHOSNUMATUO=0;
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBihRegisterSvc));
			try
			{
				lngRes = objSvc.m_lngGetISHOSNUMATUO(objPrincipal,out m_intISHOSNUMATUO);
			}
			catch
			{
				return 0;		
			}
			objSvc.Dispose();
			return lngRes;
		}
		#endregion		

        // ��Ժ�Ǽ�ʹ��

        #region ���סԺ�ţ���ͨ��Ժ��
        public long  m_lngGetBigPatientIDNor(ref string m_strHead,out string m_strMaxNo, out int m_intSour)
        {
            m_strMaxNo = "";
            m_intSour = -1;
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngGetBigPatientIDNor(objPrincipal,out m_strHead, out m_strMaxNo, out m_intSour);

        }
        #endregion

        internal long m_lngGetBigPatientIDOth(ref string m_strhead, out string m_strMaxNo, out int m_intSour)
        {
            m_strMaxNo = "";
            m_intSour = -1;
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngGetBigPatientIDOth(objPrincipal,out m_strhead,out m_strMaxNo, out m_intSour);
        }

       

        internal long m_lngCheckInputNoHave(string m_strMaxNo, out bool m_blHave)
        {
            //m_strMaxNo = "";
            //m_intSour = -1;
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngCheckInputNoHave(m_strMaxNo, out m_blHave);
        }

        internal long m_lngGetInputNoFree(string m_strInpatientNo, out string m_strHead, out string m_strMaxNo,out int m_intSour,int flag_int,out int count)
        {
            //m_strMaxNo = "";
            //m_intSour = -1;
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngGetBigPatientIDFree(objPrincipal, out m_strHead, out m_strMaxNo, out m_intSour, m_strInpatientNo,flag_int,out count);
        }

        internal long m_lngAddBigIDTableMax(int type, string main)
        {
           
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
               com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngAddBigIDTableMax(objPrincipal, type, main);
        
        }

        internal long m_lngDelInpatientNohis(string head, string main)
        {
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
            com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngDelInpatientNohis(objPrincipal, head, main);
        }

        internal long m_lngGetNativeplace(string m_strFindCode, out DataTable m_dtResult)
        {
            com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc)
                com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsBeINpatientNOSvc));
            return objSvc.m_lngGetNativeplace(objPrincipal, m_strFindCode, out m_dtResult);
        }
    }	

}

