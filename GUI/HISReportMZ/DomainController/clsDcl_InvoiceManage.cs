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
		#region 构造函数
		public clsDcl_InvoiceManage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion 


		// 门诊发票管理
		#region 添加发票请领		徐斌辉		2004-8-23
		/// <summary>
		/// 添加发票请领
		/// </summary>
		/// <param name="p_objRecord">[作废相关的字段不必添加]</param>
		/// <param name="p_strRecordID">发票请求流水号</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
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

		#region 作废发票		徐斌辉		2004-8-23
		/// <summary>
		/// 作废发票
		/// </summary>
		/// <param name="p_objRecord">[只需要m_strAPPID_CHR、m_strCANCELUSERID_CHR]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
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

		#region 查询请领发票		徐斌辉		2004-8-23
		/// <summary>
		/// 查询请领的发票
		/// </summary>
		/// <param name="p_strStartapply_dat">查询条件：起始申请时间</param>
		/// <param name="p_strEndapply_dat">查询条件：结束申请时间</param>
		/// <param name="p_strAppid_chr">查询条件：工号</param>
		/// <param name="p_objResultArr"></param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
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
		/// 根据发票请求流水号查找对应记录信息
		/// </summary>
		/// <param name="p_strAppid_chr">发票请求流水号</param>
		/// <param name="p_objResult"></param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
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
		/// 查询请领的发票
		/// </summary>
		/// <param name="p_strQueryCondition">查询条件</param>
		/// <param name="p_objResultArr"></param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		public long m_lngGetApplyInvoice(string p_strQueryCondition, out clsT_opr_opinvoiceman_VO[] p_objResultArr)
		{
			long lngRes=0;
			//确保Sql语句查询部分合法
			p_strQueryCondition = " 1=1 AND " + p_strQueryCondition;
            com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsInvoiceManageSvc));
			lngRes = objSvc.m_lngGetApplyInvoice(objPrincipal,p_strQueryCondition,out p_objResultArr);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion 

		#region 获取员工流水号	-根据职工号
		/// <summary>
		/// 获取员工流水号	-根据职工号
		/// </summary>
		/// <param name="p_strEmployeeNO">职工号</param>
		/// <param name="p_strEmployeeID">职工流水号 [out参数]</param>
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
		#region 根据工号查名称		徐斌辉		2004-8-23
		/// <summary>
		/// 根据工号求得员工名称
		/// </summary>
		/// <param name="p_strNO">工号</param>
		/// <param name="p_strName">名称　[out　参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
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
		/// 根据工号求得员工名称
		/// </summary>
		/// <param name="p_strNO">工号</param>
		/// <param name="p_dtResult">包含工号、名称2个字段的表[Appuserid_chr、AppuserName_chr]　[out 参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
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
		#region 获取职工名称 -根据流水号
		/// <summary>
		/// 根据流水号求得员工名称
		/// </summary>
		/// <param name="p_strID">流水号</param>
		/// <param name="p_strEmployeeName">职工名称　[out 参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
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

		#region	检查发票区间是否已经被申请		徐斌辉		2004-8-23	[注意：已经作废的发票可以重新申请]
		/// <summary>
		/// 检查发票区间是否已经被申请
		/// </summary>
		/// <param name="p_strMinInvoiceNo">起始发票号</param>
		/// <param name="p_strMaxInvoiceNo">结束发票号</param>
		/// <param name="IsUsed">是否备用的标志 [out 参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
		/// <remarks>
		/// 注意：
		///		如果操作错误，则默认是已经占用；
		///		即 IsUsed = true
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

		#region 检查对应发票请求流水号是否被作废
		/// <summary>
		/// 检查对应发票请求流水号是否被作废
		/// </summary>
		/// <param name="p_strAppid_chr">发票请求流水号</param>
		/// <param name="p_blnIsUsed">是否被作废 [out 参数]</param>
		/// <returns>返回操作是否成功　　[小于等于０：不成功、大于０：成功]</returns>
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

		//门诊发票退回
		#region 获得发票信息		徐斌辉		2004-8-27
		/// <summary>
		/// 根据发票号获得门诊处方发票信息 [正常有效的发票 发票状态：1-有效、0-作废、2-退票]
		/// </summary>
		/// <param name="p_strINVOICENO_VCHR">发票号</param>
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
		/// 根据物理号获得发票信息 [正常有效的发票 发票状态：1-有效、0-作废、2-退票]
		/// </summary>
		/// <param name="p_NO_STR">物理号 [最大三位]</param>
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
		#region 发票退回		徐斌辉		2004-8-27
		/// <summary>
		/// 发票退回[退票]
		/// </summary>
		/// <param name="p_strINVOICENO_VCHR">发票号</param>
		/// <param name="p_strOPREMP_CHR">操作者ID</param>
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

		//门诊发票恢复
		#region 获得发票信息		徐斌辉		2004-8-27
		/// <summary>
		/// 根据发票号获得门诊处方发票信息 [已经退票的发票 发票状态：1-有效、0-作废、2-退票]
		/// </summary>
		/// <param name="p_strINVOICENO_VCHR">发票号</param>
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
		/// 根据物理号获得发票信息 [已经退票的发票 发票状态：1-有效、0-作废、2-退票]
		/// </summary>
		/// <param name="p_NO_STR">物理号 [最大三位]</param>
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
		#region 发票恢复		徐斌辉		2004-8-27
		/// <summary>
		/// 发票退回[退票]
		/// </summary>
		/// <param name="p_strINVOICENO_VCHR">发票号</param>
		/// <param name="p_strOPREMP_CHR">操作者ID</param>
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

		#region 根据卡号查出发票号
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
		#region 获取审核信息
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
		#region 增加审核信息
		
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
		#region 验证密码
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

        #region 判断是否分票
        /// <summary>
        /// 判断是否分票
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

        #region 根据内部序列号获取同组分发票数据
        /// <summary>
        /// 根据内部序列号获取同组分发票数据
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

        #region 获取挂号发票统计数据
        /// <summary>
        /// 获取挂号发票统计数据
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
        /// 获取挂号发票重打数据
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
        /// 通过发票段获取挂号发票统计数据
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
        /// 获取挂号发票重打数据
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

        #region 获得所有结帐员数据(挂号信息表)
        public long m_lngGetCheckMan(out DataTable dtEmpAll)
        {
            System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc objSvc =
                (com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.Reports.clsRegisterSvc));
            long LngArg = objSvc.m_lngGetCheckMan(p_objPrincipal, out dtEmpAll);
            return LngArg;
        }
        #endregion

        #endregion //获取挂号发票统计数据

    }
}
