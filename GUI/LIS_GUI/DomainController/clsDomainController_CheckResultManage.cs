using System;
using System.Data;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.common;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsDomainController_CheckResultManage 的摘要说明。
	/// 刘彬 2004.05.26
	/// </summary>
	public class clsDomainController_CheckResultManage:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsDomainController_CheckResultManage()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		#region 根据检验日期和仪器编号查询DeviceResultLog 童华 2004.11.08
		/// <summary>
		/// 根据检验日期和仪器编号查询DeviceResultLog
		/// </summary>
		/// <param name="p_strCheckDatFrom"></param>
		/// <param name="p_strCheckDatTo"></param>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns></returns>
		public long m_lngGetDeviceResultLogByCondition(string p_strCheckDatFrom,string p_strCheckDatTo,
			string p_strDeviceID,out clsResultLogVO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetDeviceResultLogByCondition(objPrincipal,p_strCheckDatFrom,p_strCheckDatTo,p_strDeviceID,out p_objResultArr);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据申请号得到对应样本的仪器关联 刘彬 2004.10.22
		/// <summary>
		/// 根据申请号得到对应样本的仪器关联
		/// </summary>
		/// <param name="p_strAppID"></param>
		/// <param name="p_objDRVOArr"></param>
		/// <returns></returns>
		public long m_lngGetDeviceRelationByAppID(
			string p_strAppID,out clsT_LIS_DeviceRelationVO[] p_objDRVOArr)
		{
			long lngRes = 0;
			p_objDRVOArr = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetDeviceRelationByAppID(objPrincipal,p_strAppID,out p_objDRVOArr);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 设置仪器样本重做标志 刘彬 2004.08.26
		/// <summary>
		/// 设置仪器样本重做标志
		/// </summary>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_intImportReq"></param>
		/// <returns></returns>
		public long m_lngSetDeviceSamplesRecheck(
			string p_strDeviceID,int p_intImportReq)
		{
			long lngRes = 0;

			com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
			lngRes = objSvc.m_lngSetDeviceSamplesRecheck(objPrincipal,p_strDeviceID,p_intImportReq);
			//			objSvc.Dispose();

			return lngRes;
		}
		#endregion


		#region 根据Imp_Req_int和仪器ID查询标本列表 童华 2004.08.20
		public long m_lngGetDeviceSampleListByCondition(string p_strImpReq,string p_strDeviceID,out clsResultLogVO[] p_objResultArr)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetDeviceSampleListByCondition(objPrincipal,p_strImpReq,p_strDeviceID,out p_objResultArr);
//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 新增融合后的仪器检验结果及日志信息 童华 2004.08.16
		public long m_lngAddNewDeviceCheckResultArrANDLog(clsDeviceReslutVO[] p_objDeviceResultArr,clsResultLogVO p_objResultLog)
		{
			long lngRes = 0;
			
			com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
			lngRes = objSvc.m_lngAddNewDeviceCheckResultArrANDLog(objPrincipal,p_objDeviceResultArr,p_objResultLog);
//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 根据仪器样本号，仪器ID和检验时间查询标本列表 童华 2004.08.16
		public long m_lngGetDeviceSampleListByCondition(string p_strDeviceSampleID,string p_strDeviceID,string p_strCheckDat,
			out clsResultLogVO[] p_objResultArr)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetDeviceSampleListByCondition(objPrincipal,p_strDeviceSampleID,p_strDeviceID,p_strCheckDat,out p_objResultArr);
//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 根据申请单号和报告组号查询批量打印信息列表
		public long m_lngGetLisBatchReportDetailByCondition(clsLisBatchReportList_VO[] p_objReportList,out clsLisBatchReportDetail_VO[] p_objResultArr)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetLisBatchReportDetailByCondition(objPrincipal,p_objReportList,out p_objResultArr);
//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 根据条件查询批量打印的报告单列表
		public long m_lngGetLisBatchReportListByCondition(string p_strFromSampleID,string p_strToSampleID,string p_strFromConfirmDat,
			string p_strToConfirmDat,string p_strReportGroupID,string p_strPatientType,out clsLisBatchReportList_VO[] p_objResultArr)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetLisBatchReportListByCondition(objPrincipal,p_strFromSampleID,p_strToSampleID,p_strFromConfirmDat,p_strToConfirmDat,
				p_strReportGroupID,p_strPatientType,out p_objResultArr);
//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 更新T_OPR_LIS_RESULT_IMPORT_REQ的状态 童华 2004.07.26
		public long m_lngSetResultImportReqStatus(string p_strDeviceID,string p_strDeviceSampleID,string p_strCheckDat,string p_strStatus)
		{
			long lngRes = 0;
			
			com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
			lngRes = objSvc.m_lngSetResultImportReqStatus(objPrincipal,p_strDeviceID,p_strDeviceSampleID,p_strCheckDat,p_strStatus);
			//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 根据条件查询T_OPR_LIS_RESULT_IMPORT_REQ表的信息 童华 2004.07.23
		public long m_lngGetResultImportReqByCondition(string p_strDeviceID,string p_strCheckDatFrom,string p_strCheckDatTo,
			out clsLisResultImportReq_VO[] p_objResultArr)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetResultImportReqByCondition(objPrincipal,p_strDeviceID,p_strCheckDatFrom,p_strCheckDatTo,out p_objResultArr);
//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 更新表T_OPR_LIS_RESULT_IMPORT_REQ的信息 童华 2004.07.23
		public long m_lngSetResultImportReq(clsLisResultImportReq_VO p_objRecord)
		{
			long lngRes = 0;
			
			com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
			lngRes = objSvc.m_lngSetResultImportReq(objPrincipal,p_objRecord);
//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 调整结束指针的位置 童华 2004.07.23
		public long m_lngSetResultImportReqEndPoint(clsLisResultImportReq_VO p_objRecord)
		{
			long lngRes = 0;
			
			com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
			lngRes = objSvc.m_lngSetResultImportReqEndPoint(objPrincipal,p_objRecord);
//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 根据条件查询批量打印报告单信息 童华 2004.07.22
		public long m_lngGetBatchReportDataByCondition(string p_strFromSampleID,string p_strToSampleID,string p_strFromConfirmDat,
			string p_strToConfirmDat,string p_strReportGroupID,out clsLisBatchReport_VO[] p_objResultArr)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetBatchReportDataByCondition(objPrincipal,p_strFromSampleID,p_strToSampleID,p_strFromConfirmDat,p_strToConfirmDat,
				p_strReportGroupID,out p_objResultArr);
//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 查询得到  CheckResultVO 刘彬 2004.06.04
		/// <summary>
		/// 查询得到  CheckResultVO
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strSampleID"></param>
		/// <param name="p_strCheckItemID"></param>
		/// <param name="p_objResultVO"></param>
		/// <returns></returns>
		
		public long m_lngGetCheckResultVO(string p_strSampleID,
			string p_strCheckItemID,out clsCheckResult_VO p_objResultVO)
		{
			long lngRes = 0;
			p_objResultVO = null;

            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetCheckResultVO(
				objPrincipal,p_strSampleID,p_strCheckItemID,out p_objResultVO);
			//			objSvc.Dispose();
			
			return lngRes;
		}
		#endregion

		#region 查询得到  CheckResultTable 刘彬 2004.06.04
		
		/// <summary>
		/// 查询得到  CheckResultTable 刘彬 2004.06.04
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strAppID"></param>
		/// <param name="p_strReportID"></param>
		/// <param name="p_strGroupID"></param>
		/// <param name="p_blnRealResult"></param>
		/// <param name="p_dtbResultList"></param>
		/// <returns></returns>
		public long m_lngGetCheckResultTable(string p_strAppID,string p_strOringinDate,bool p_blnRealResult,out DataTable p_dtbResultList)
		{
			long lngRes = 0;
			p_dtbResultList = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetCheckResultTable(objPrincipal, p_strAppID,p_strOringinDate,p_blnRealResult,out p_dtbResultList);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 以指定编号方式,根据指定的仪器编号,检验日期(trunc),和仪器样本编号查询绑定和提取数据 刘彬 2004.06.10
		/// <summary>
		/// 以指定编号方式,根据指定的仪器编号,检验日期(trunc),和仪器样本编号查询绑定和提取数据
		/// </summary>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_strDeviceSampleID"></param>
		/// <param name="p_strCheckDate"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns>
		/// 小于 0 : 查询失败; 
		/// 100: 无可绑定的仪器样本;  
		/// 300: 指定的仪器样本号存在,但无历史记录; 
		/// 350: 指定的仪器样本已被作废;
		/// 400:指定的仪器样本无原始数据; 
		/// 其它: 成功返回
		/// </returns>
		public long m_lngQueryBindAndGetDeviceDataByAppointment(
			string p_strDeviceID,string p_strDeviceSampleID,string p_strCheckDate,
			out clsDeviceReslutVO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngQueryBindAndGetDeviceDataByAppointment(
				objPrincipal,p_strDeviceID,p_strDeviceSampleID,p_strCheckDate,out p_objResultArr);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 以指定编号方式,根据指定的仪器编号,检验日期(trunc),和仪器样本编号查询绑定 刘彬 2004.06.10
		/// <summary>
		/// 以指定编号方式,根据指定的仪器编号,检验日期(trunc),和仪器样本编号查询绑定 刘彬 2004.06.10
		/// </summary>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_strDeviceSampleID"></param>
		/// <param name="p_strCheckDate"></param>
		/// <param name="p_objResultLogVO">以此到仪器结果表提取数据</param>
		/// <returns>
		/// 小于 0 : 查询失败;
		/// 100: 无可绑定的仪器样本;
		/// 300: 指定的仪器样本号存在,但无历史记录;
		/// 350: 指定的仪器样本已被作废;
		/// 其它: 成功返回
		/// </returns>
		public long m_lngQueryBindByAppointment(string p_strDeviceID,string p_strDeviceSampleID,string p_strCheckDate,out clsResultLogVO p_objResultLogVO)
		{
			long lngRes=0;
			p_objResultLogVO = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngQueryBindByAppointment(objPrincipal,p_strDeviceID,p_strDeviceSampleID,p_strCheckDate,out p_objResultLogVO);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion


		#region   根据指定的仪器编号,REQ ,查询 DeviceResultLog 和提取仪器数据 刘彬 2004.06.10
		/// <summary>
		///  根据指定的仪器编号,REQ ,查询 DeviceResultLog 和提取仪器数据 刘彬 2004.06.10	
		/// </summary>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_intImportReq"></param>
		/// <param name="p_objDeviceResultList"></param>
		/// <returns>
		/// 小于 0 : 查询失败; 
		/// 400:指定的仪器样本无原始数据
		/// 其它: 成功返回 
		/// </returns>
		public long m_lngGetDeviceData(
			string p_strDeviceID,int p_intImportReq,
			out clsDeviceReslutVO[] p_objDeviceResultList)
		{
			long lngRes=0;
			p_objDeviceResultList = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetDeviceData(objPrincipal,
			 p_strDeviceID, p_intImportReq, 
			out p_objDeviceResultList);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region  m_lngGetDeviceData 根据指定的仪器编号,检验日期,和仪器样本编号,及开始索引和结束索引提取仪器数据 刘彬 2004.06.10	
		public long m_lngGetDeviceData(string p_strDeviceID,string p_strDeviceSampleID,string p_strCheckDate,int p_intBeginIndex,int p_intEndIndex,
			out clsDeviceReslutVO[] p_objDeviceResultList)
		{
			long lngRes=0;
			p_objDeviceResultList = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetDeviceData(objPrincipal,
				p_strDeviceID, p_strDeviceSampleID, p_strCheckDate,p_intBeginIndex,p_intEndIndex,
				out p_objDeviceResultList);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion


		#region 根据report_group_id和application_id_chr查询报告单相关信息 刘彬 2004.06.04
		/// <summary>
		/// 根据report_group_id和application_id_chr查询报告单相关信息
		/// </summary>
		/// <param name="p_strReportGroupID">报告组ID</param>
		/// <param name="p_strApplID">申请单ID</param>
		/// <param name="p_blnConfirmed">是否审核</param>
		/// <param name="p_dtbReportInfo">返回报告单相关信息</param>
		/// <returns></returns>
		public long m_lngGetReportPrintInfo(string p_strReportGroupID,string p_strApplID,bool p_blnConfirmed,out clsPrintValuePara p_objPrintContent)
		{
			p_objPrintContent = null;
			long lngRes = 0;
			DataTable dtbReportInfo = null;
			DataTable dtbCheckResult = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetReportInfoByReportGroupIDAndApplicationID(objPrincipal,p_strReportGroupID,p_strApplID,p_blnConfirmed,out dtbReportInfo);
			if(lngRes >0)
			{
				lngRes = 0;
				lngRes = objSvc.m_lngGetCheckResultByReportGroupIDAndApplicationID(objPrincipal,p_strApplID,p_strReportGroupID,p_blnConfirmed,out dtbCheckResult);
			}
			if(lngRes >0)
			{
				p_objPrintContent = new clsPrintValuePara();
				p_objPrintContent.m_dtbBaseInfo = dtbReportInfo;
				p_objPrintContent.m_dtbResult = dtbCheckResult;
			}
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据report_group_id和application_id_chr查询报告单相关信息 刘彬 2004.06.04
		/// <summary>
		/// 根据report_group_id和application_id_chr查询报告单相关信息
		/// </summary>
		/// <param name="p_strReportGroupID">报告组ID</param>
		/// <param name="p_strApplID">申请单ID</param>
		/// <param name="p_blnConfirmed">是否审核</param>
		/// <param name="p_dtbReportInfo">返回报告单相关信息</param>
		/// <returns></returns>
		public long m_lngGetReportInfoByReportGroupIDAndApplicationID(string p_strReportGroupID,string p_strApplID,bool p_blnConfirmed,out DataTable p_dtbReportInfo)
		{
			long lngRes = 0;
			p_dtbReportInfo = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetReportInfoByReportGroupIDAndApplicationID(objPrincipal,p_strReportGroupID,p_strApplID,p_blnConfirmed,out p_dtbReportInfo);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据report_group_id和application_id_chr查询报告的结果记录 刘彬 2004.06.04
		/// <summary>
		/// 根据report_group_id和application_id_chr查询报告的结果记录
		/// </summary>
		/// <param name="strApplicationID">申请单ID</param>
		/// <param name="strReportGroupID">报告组ID</param>
		/// <param name="blnConfirmed">是否审核</param>
		/// <param name="dtbCheckResult">返回结果信息</param>
		/// <returns></returns>
		public long m_lngGetCheckResultByReportGroupIDAndApplicationID(	string p_strApplicationID,string p_strReportGroupID,bool p_blnConfirmed,out DataTable p_dtbCheckResult)
		{
			long lngRes = 0;
			p_dtbCheckResult = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngGetCheckResultByReportGroupIDAndApplicationID(objPrincipal,p_strApplicationID,p_strReportGroupID,p_blnConfirmed,out p_dtbCheckResult);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 向t_opr_lis_check_result表插入一条记录 刘彬 2004.06.4
//		public long m_lngAddNewCheckResult(com.digitalwave.iCare.ValueObject.clsCheckResult_VO p_objCheckResultVO)
//		{
//			long lngRes=0;
//			com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objSvc = 
//				(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
//			lngRes = objSvc.m_lngAddNewCheckResult(objPrincipal,p_objCheckResultVO);
//			//			objSvc.Dispose();
//			return lngRes;
//		}
		#endregion

		#region [U]向t_opr_lis_check_result表插入多条记录 刘彬 2004.06.4
		/// <summary>
		/// 调用本方法时,必需传入 p_strSampleIDArr 中的所有的样本的所有检验项目结果,且只能传入
		/// 在 p_strSampleIDArr 列表之中的样本的检验项目结果;
		/// </summary>
		/// <param name="p_objCheckResultList"></param>
		/// <param name="p_strSampleIDArr"></param>
		/// <returns></returns>
		public long m_lngAddCheckResultList(com.digitalwave.iCare.ValueObject.clsCheckResult_VO[] p_objCheckResultList,string[] p_strSampleIDArr,string p_strOriginDate)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
			lngRes = objSvc.m_lngAddCheckResultList(objPrincipal,p_objCheckResultList,p_strSampleIDArr,p_strOriginDate);
			//			objSvc.Dispose();			
			return lngRes;
		}
		#endregion

		//************************************************************************

		#region 以自动绑定方式,根据指定的仪器编号  查询绑定和提取数据 刘彬 2004.06.10
		/// <summary>
		/// 以指定编号方式,根据指定的仪器编号,检验日期(trunc),和仪器样本编号查询绑定和提取数据
		/// </summary>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_objResultArr"></param>
		/// <returns>
		/// 小于 0 : 查询失败; 
		/// 100: 无可绑定的仪器样本;
		/// 300: 指定的仪器样本号存在且未绑定,但无历史记录; 
		/// 400:指定的仪器样本无原始数据; 
		/// 其它: 成功返回
		/// </returns>
		public long m_lngQueryBindAndGetDeviceDataByAutoBind(string p_strDeviceID,out clsDeviceReslutVO[] p_objResultArr)
		{
			long lngRes=0;
			p_objResultArr = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngQueryBindAndGetDeviceDataByAutoBind(
				objPrincipal,p_strDeviceID,out p_objResultArr);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 以自动绑定方式,根据指定的仪器编号 查询绑定 刘彬 2004.06.10
		/// <summary>
		/// 以自动绑定方式,根据指定的仪器编号 查询绑定 刘彬 2004.06.10
		/// </summary>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_objResultLogVO">以此到仪器结果表提取数据</param>
		/// <returns>
		/// 小于 0 : 查询失败;
		/// 100: 无可绑定的仪器样本;
		/// 300: 可绑定的仪器样本号存在且未绑定,但无历史记录 
		/// 其它: 成功返回
		/// </returns>
		public long m_lngQueryBindByAutoBind(string p_strDeviceID,out clsResultLogVO p_objResultLogVO)
		{
			long lngRes=0;
			p_objResultLogVO = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc));
			lngRes = objSvc.m_lngQueryBindByAutoBind(objPrincipal,p_strDeviceID,out p_objResultLogVO);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion


        #region 查找指定病人，指定检验项目ID的检验结果
        /// <summary>
        /// 查找指定病人，指定检验项目ID的检验结果
        /// </summary>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_strExcItemID"> 需要特殊处理的项目ID</param>
        /// <param name="p_dtResult"></param>
        /// <returns></returns>
        public long m_lngQueryPatientExcItemResult(string p_strPatientID, string p_strExcItemID, out DataTable p_dtResult)
        {
            clsQueryCheckResultSvc objServ = (clsQueryCheckResultSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryCheckResultSvc));
            return objServ.m_lngQueryPatientExcItemResult(objPrincipal, p_strPatientID, p_strExcItemID, out p_dtResult);
        }

        #endregion
	}
}
