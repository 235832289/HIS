using System;
using System.Data;
using com.digitalwave.iCare.middletier.RIS;//RIS_Svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.gui.HIS.Reports
{	
	public class clsDcl_InvoiceManage: com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region ���캯��
		public clsDcl_InvoiceManage()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}
		#endregion 


		// ���﷢Ʊ����
		#region ��ӷ�Ʊ����		����		2004-8-23
		/// <summary>
		/// ��ӷ�Ʊ����
		/// </summary>
		/// <param name="p_objRecord">[������ص��ֶβ������]</param>
		/// <param name="p_strRecordID">��Ʊ������ˮ��</param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		public long m_lngDoAddNewT_opr_opinvoiceman(clsT_opr_opinvoiceman_VO p_objRecord,out string p_strRecordID)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngDoAddNewT_opr_opinvoiceman(objPrincipal,p_objRecord,out p_strRecordID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region ���Ϸ�Ʊ		����		2004-8-23
		/// <summary>
		/// ���Ϸ�Ʊ
		/// </summary>
		/// <param name="p_objRecord">[ֻ��Ҫm_strAPPID_CHR��m_strCANCELUSERID_CHR]</param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		public long m_lngModifyT_opr_opinvoiceman(clsT_opr_opinvoiceman_VO p_objRecord)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngModifyT_opr_opinvoiceman(objPrincipal,p_objRecord);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region ��ѯ���췢Ʊ		����		2004-8-23
		/// <summary>
		/// ��ѯ����ķ�Ʊ
		/// </summary>
		/// <param name="p_strStartapply_dat">��ѯ��������ʼ����ʱ��</param>
		/// <param name="p_strEndapply_dat">��ѯ��������������ʱ��</param>
		/// <param name="p_strAppid_chr">��ѯ����������</param>
		/// <param name="p_objResultArr"></param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		public long m_lngGetApplyInvoice(string p_strStartapply_dat,string p_strEndapply_dat,string p_strAppuserid_chr, out clsT_opr_opinvoiceman_VO[] p_objResultArr)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetApplyInvoice(objPrincipal,p_strStartapply_dat,p_strEndapply_dat,p_strAppuserid_chr,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ���ݷ�Ʊ������ˮ�Ų��Ҷ�Ӧ��¼��Ϣ
		/// </summary>
		/// <param name="p_strAppid_chr">��Ʊ������ˮ��</param>
		/// <param name="p_objResult"></param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		public long m_lngGetApplyInvoice(string p_strAppid_chr,out clsT_opr_opinvoiceman_VO p_objResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetApplyInvoice(objPrincipal,p_strAppid_chr,out p_objResult);
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ��ѯ����ķ�Ʊ
		/// </summary>
		/// <param name="p_strQueryCondition">��ѯ����</param>
		/// <param name="p_objResultArr"></param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		public long m_lngGetApplyInvoice(string p_strQueryCondition, out clsT_opr_opinvoiceman_VO[] p_objResultArr)
		{
			long lngRes=0;
			//ȷ��Sql����ѯ���ֺϷ�
			p_strQueryCondition = " 1=1 AND " + p_strQueryCondition;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetApplyInvoice(objPrincipal,p_strQueryCondition,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region ��ȡԱ����ˮ��	-����ְ����
		/// <summary>
		/// ��ȡԱ����ˮ��	-����ְ����
		/// </summary>
		/// <param name="p_strEmployeeNO">ְ����</param>
		/// <param name="p_strEmployeeID">ְ����ˮ�� [out����]</param>
		/// <returns></returns>
		public long m_lngGetEmployeeIDByNO(string p_strEmployeeNO, out string p_strEmployeeID)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetEmployeeIDByNO(objPrincipal,p_strEmployeeNO,out p_strEmployeeID);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ���ݹ��Ų�����		����		2004-8-23
		/// <summary>
		/// ���ݹ������Ա������
		/// </summary>
		/// <param name="p_strNO">����</param>
		/// <param name="p_strName">���ơ�[out������]</param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		public long m_lngGetEmployeeNameByNO(string p_strNO, out string p_strName)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetApplyName(objPrincipal,p_strNO,out p_strName);
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ���ݹ������Ա������
		/// </summary>
		/// <param name="p_strNO">����</param>
		/// <param name="p_dtResult">�������š�����2���ֶεı�[Appuserid_chr��AppuserName_chr]��[out ����]</param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		public long m_lngGetEmployeeNameByNO(string p_strNO, out DataTable p_dtResult)
		{
			long lngRes=0;
			p_dtResult = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetApplyName(objPrincipal,p_strNO,out p_dtResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 
		#region ��ȡְ������ -������ˮ��
		/// <summary>
		/// ������ˮ�����Ա������
		/// </summary>
		/// <param name="p_strID">��ˮ��</param>
		/// <param name="p_strEmployeeName">ְ�����ơ�[out ����]</param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		public long m_lngGetEmployeeNameByID(string p_strID, out string p_strEmployeeName)
		{
			long lngRes=0;
			p_strEmployeeName ="";
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetEmployeeNameByID(objPrincipal,p_strID,out p_strEmployeeName);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region	��鷢Ʊ�����Ƿ��Ѿ�������		����		2004-8-23	[ע�⣺�Ѿ����ϵķ�Ʊ������������]
		/// <summary>
		/// ��鷢Ʊ�����Ƿ��Ѿ�������
		/// </summary>
		/// <param name="p_strMinInvoiceNo">��ʼ��Ʊ��</param>
		/// <param name="p_strMaxInvoiceNo">������Ʊ��</param>
		/// <param name="IsUsed">�Ƿ��õı�־ [out ����]</param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		/// <remarks>
		/// ע�⣺
		///		�������������Ĭ�����Ѿ�ռ�ã�
		///		�� IsUsed = true
		/// </remarks>
		public long m_lngCheckInvoiceNOIsUsed(string p_strMinInvoiceNo,string p_strMaxInvoiceNo,out bool p_blnIsUsed)
		{
			p_blnIsUsed = true;
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngCheckInvoiceNOIsUsed(objPrincipal,p_strMinInvoiceNo,p_strMaxInvoiceNo,out p_blnIsUsed);
			return lngRes;
		}
		#endregion 

		#region ����Ӧ��Ʊ������ˮ���Ƿ�����
		/// <summary>
		/// ����Ӧ��Ʊ������ˮ���Ƿ�����
		/// </summary>
		/// <param name="p_strAppid_chr">��Ʊ������ˮ��</param>
		/// <param name="p_blnIsUsed">�Ƿ����� [out ����]</param>
		/// <returns>���ز����Ƿ�ɹ�����[С�ڵ��ڣ������ɹ������ڣ����ɹ�]</returns>
		public long m_lngCheckInvoiceNOIsCancel(string p_strAppid_chr,out bool p_blnIsUsed)
		{
			p_blnIsUsed = true;
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngCheckInvoiceNOIsCancel(objPrincipal,p_strAppid_chr,out p_blnIsUsed);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		//���﷢Ʊ�˻�
		#region ��÷�Ʊ��Ϣ		����		2004-8-27
		/// <summary>
		/// ���ݷ�Ʊ�Ż�����ﴦ����Ʊ��Ϣ [������Ч�ķ�Ʊ ��Ʊ״̬��1-��Ч��0-���ϡ�2-��Ʊ]
		/// </summary>
		/// <param name="p_strINVOICENO_VCHR">��Ʊ��</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		public long m_lngGetInfoByNoForReturn(string p_strINVOICENO_VCHR, out clsT_opr_outpatientrecipeinv_VO p_objResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetInfoByNoForReturn(objPrincipal,p_strINVOICENO_VCHR,out p_objResult);
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ��������Ż�÷�Ʊ��Ϣ [������Ч�ķ�Ʊ ��Ʊ״̬��1-��Ч��0-���ϡ�2-��Ʊ]
		/// </summary>
		/// <param name="p_NO_STR">����� [�����λ]</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		public long m_lngGetInfoBySeqidForReturn(string p_NO_STR, out clsT_opr_outpatientrecipeinv_VO p_objResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetInfoBySeqidForReturn(objPrincipal,p_NO_STR,out p_objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��Ʊ�˻�		����		2004-8-27
		/// <summary>
		/// ��Ʊ�˻�[��Ʊ]
		/// </summary>
		/// <param name="p_strINVOICENO_VCHR">��Ʊ��</param>
		/// <param name="p_strOPREMP_CHR">������ID</param>
		/// <returns></returns>
		public long m_lngReturnTicket(string p_strINVOICENO_VCHR,string p_strOPREMP_CHR, ref string Seqid)
		{
			long lngRes=0;
			try
			{
                com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                    (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			    lngRes = objSvc.m_lngReturnTicket(objPrincipal,p_strINVOICENO_VCHR,p_strOPREMP_CHR, ref Seqid);
			    objSvc.Dispose();
			}
			catch
			{
			
			}
			return lngRes;
		}
		#endregion

		//���﷢Ʊ�ָ�
		#region ��÷�Ʊ��Ϣ		����		2004-8-27
		/// <summary>
		/// ���ݷ�Ʊ�Ż�����ﴦ����Ʊ��Ϣ [�Ѿ���Ʊ�ķ�Ʊ ��Ʊ״̬��1-��Ч��0-���ϡ�2-��Ʊ]
		/// </summary>
		/// <param name="p_strINVOICENO_VCHR">��Ʊ��</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		public long m_lngGetInfoByNoForResume(string p_strINVOICENO_VCHR, out clsT_opr_outpatientrecipeinv_VO p_objResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetInfoByNoForResume(objPrincipal,p_strINVOICENO_VCHR,out p_objResult);
			objSvc.Dispose();
			return lngRes;
		}
		/// <summary>
		/// ��������Ż�÷�Ʊ��Ϣ [�Ѿ���Ʊ�ķ�Ʊ ��Ʊ״̬��1-��Ч��0-���ϡ�2-��Ʊ]
		/// </summary>
		/// <param name="p_NO_STR">����� [�����λ]</param>
		/// <param name="p_objResult"></param>
		/// <returns></returns>
		public long m_lngGetInfoBySeqidForResume(string p_NO_STR, out clsT_opr_outpatientrecipeinv_VO p_objResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetInfoBySeqidForResume(objPrincipal,p_NO_STR,out p_objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��Ʊ�ָ�		����		2004-8-27
		/// <summary>
		/// ��Ʊ�˻�[��Ʊ]
		/// </summary>
		/// <param name="p_strINVOICENO_VCHR">��Ʊ��</param>
		/// <param name="p_strOPREMP_CHR">������ID</param>
		/// <returns></returns>
		public long m_lngResumeTicket(string p_strINVOICENO_VCHR,string p_strOPREMP_CHR, ref string Seqid)
		{
			
			long lngRes=0;
			try
			{
                com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                    (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
				lngRes = objSvc.m_lngResumeTicket(objPrincipal,p_strINVOICENO_VCHR,p_strOPREMP_CHR, ref Seqid);
				objSvc.Dispose();
			}
			catch
			{
			
			}
			return lngRes;
		}
		#endregion

		#region ���ݿ��Ų����Ʊ��
		public long m_mthFindInvoiceByCardID(string strCardID,out DataTable dt,int flag,int p_intFlag)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_mthFindInvoiceByCardID(objPrincipal,strCardID,out dt,flag,p_intFlag);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��ȡ�����Ϣ
		public long m_mthGetInvoiceAuditingInfo(string strID, out DataTable dt,int flag)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_mthGetInvoiceAuditingInfo(objPrincipal,strID,out dt,flag);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ���������Ϣ
		
		public long m_mthAddInvoiceAuditingInfo(clsInvAuditing_VO objResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_mthAddInvoiceAuditingInfo(objPrincipal,objResult);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#region ��֤����
		public long m_mthGetEmployeeInfo(string strID, out DataTable dt,string strEx)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_mthGetEmployeeInfo(objPrincipal,strID,out dt,strEx);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

        #region �ж��Ƿ��Ʊ
        /// <summary>
        /// �ж��Ƿ��Ʊ
        /// </summary>
        /// <param name="seqid"></param>
        /// <returns></returns>
        public bool m_blnChecksplit(string invono)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));

            bool ret = objSvc.m_blnChecksplit(invono);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region �����ڲ����кŻ�ȡͬ��ַ�Ʊ����
        /// <summary>
        /// �����ڲ����кŻ�ȡͬ��ַ�Ʊ����
        /// </summary>
        /// <param name="seqid"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public long m_lngGetsplitinvoinfo(string seqid, out DataTable dtRecord)
        {
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                            (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));

            long ret = objSvc.m_lngGetsplitinvoinfo(seqid, out dtRecord);
            objSvc.Dispose();
            return ret;
        }
        #endregion

        #region ��ȡ�Һŷ�Ʊͳ������
        /// <summary>
        /// ��ȡ�Һŷ�Ʊͳ������
        /// </summary>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetRegisterStatData(string p_opratorId, string p_beginDate, string p_endDate, out DataTable p_dtbStat)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc));
            long LngArg = objSvc.m_lngGetRegisterStatData(p_objPrincipal, p_opratorId, p_beginDate, p_endDate, out p_dtbStat);
            return LngArg;
        }

        /// <summary>
        /// ��ȡ�Һŷ�Ʊ�ش�����
        /// </summary>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtbRePrint"></param>
        /// <returns></returns>
        public long m_lngGetBillRePrintData(string p_strOperatorId,
                                            string p_strStartDate,
                                            string p_strEndDate,
                                            out DataTable p_dtbRePrint)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc));
            long lngRes = objSvc.GetRegisterBillReprintByDate(p_objPrincipal, p_strOperatorId, p_strStartDate, p_strEndDate, out p_dtbRePrint);
            return lngRes;
        }

        /// <summary>
        /// ͨ����Ʊ�λ�ȡ�Һŷ�Ʊͳ������
        /// by huafeng.xiao
        /// </summary>
        /// <param name="p_dtbResult"></param>
        /// <returns></returns>
        public long m_lngGetRegisterStatDataByInvoArr(string p_opratorId, string p_beginDate, string p_endDate, out DataTable p_dtbStat)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc));
            long LngArg = objSvc.m_lngGetRegisterStatDataByInvoArr(p_objPrincipal, p_opratorId, p_beginDate, p_endDate, out p_dtbStat);
            return LngArg;
        }

        /// <summary>
        /// ��ȡ�Һŷ�Ʊ�ش�����
        /// by huafeng.xiao
        /// </summary>
        /// <param name="p_strOperatorId"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_dtbRePrint"></param>
        /// <returns></returns>
        public long m_lngGetBillRePrintDataInvoArr(string p_strOperatorId,
                                            string p_strStartDate,
                                            string p_strEndDate,
                                            out DataTable p_dtbRePrint)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc));
            long lngRes = objSvc.GetRegisterBillReprintByInvoArr(p_objPrincipal, p_strOperatorId, p_strStartDate, p_strEndDate, out p_dtbRePrint);
            return lngRes;
        }

        #region ������н���Ա����(�Һ���Ϣ��)
        public long m_lngGetCheckMan(out DataTable dtEmpAll)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc));
            long LngArg = objSvc.m_lngGetCheckMan(p_objPrincipal, out dtEmpAll);
            return LngArg;
        }
        #endregion

        #endregion //��ȡ�Һŷ�Ʊͳ������

    }
}
