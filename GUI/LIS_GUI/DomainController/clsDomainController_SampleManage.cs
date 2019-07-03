using System;
using System.Data;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
//using com.digitalwave.iCare.gui.Security;//Security_GUI.dll //alex 2004-5-12
namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// Summary description for clsDomainController_SampleManage.
	/// 刘彬 2004.05.10
	/// </summary>
	public class clsDomainController_SampleManage:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		#region xing.chen add for
        //public long m_lngFindItemNameByApplicationID(string strAppID,out string strItemName)
        //{
        //    strItemName = "";
        //    long lngRes = 0;
        //    com.digitalwave.iCare.middletier.LIS.clsApplicationSvc objSvc = (com.digitalwave.iCare.middletier.LIS.clsApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsApplicationSvc));
        //    lngRes = objSvc.m_lngFindItemNameByApplicationID(this.objPrincipal,strAppID,out strItemName);
        //    return lngRes;
        //}
		#endregion

		#region		xing.chen add for 根据标本号查询标本状态
		public long m_lngFindStatusBySampleID(string strSampleID,out int intStatus)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngFindStatusBySampleID(this.objPrincipal,strSampleID,out intStatus);
			return lngRes;
		}
		#endregion

		#region	[U]xing.chen add for 修改样本号
		public long m_lngModifyBarCode(string strSampleID,string strAppID)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngModifyBarCode(this.objPrincipal,strSampleID,strAppID);
			return lngRes;
		}
		#endregion

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsDomainController_SampleManage()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		#endregion

		#region 更新样本标志位 刘彬 2004.10.31
		/// <summary>
		/// 更新样本标志位
		///  刘彬 2004.10.31
		/// </summary>
		/// <param name="p_strSampleIDArr"></param>
		/// <param name="p_intSourceStatus"></param>
		/// <param name="p_intTargetStatus"></param>
		/// <returns>
		/// 小于等于0:出错;
		///1:成功。
		/// </returns>
		public long m_lngUpdateSampleFlag(string[] p_strSampleIDArr,int p_intSourceStatus,int p_intTargetStatus)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngUpdateSampleFlag(objPrincipal,p_strSampleIDArr,p_intSourceStatus,p_intTargetStatus);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 标本接收
		#region [U]根据BarCode查询待接收的样本信息
        /// <summary>
        /// 根据BarCode查询待接收的样本信息
        /// </summary>
		public long m_mthGetUnReceivedSampleByBarCode(string p_strBarCode,out clsSampleReceive_VO p_objRecord)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_mthGetUnReceivedSampleByBarCode(objPrincipal,p_strBarCode,out p_objRecord);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

        #region 根据条件查询已采集,但未接收的标本信息
        /// <summary>
        /// 根据条件查询已采集,但未接收的标本信息
        /// </summary>
        /// <param name="p_strDatFrom"></param>
        /// <param name="p_strDatTo"></param>
        /// <param name="p_strSampleType"></param>
        /// <param name="p_strAcceptEmp"></param>
        /// <param name="p_strPatientName"></param>
        /// <param name="p_strPatientCardID"></param>
        /// <param name="p_strBarCode"></param>
        /// <param name="p_strCheckCategory"></param>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        public long m_lngGetUnReceivedSampleByCondition(string p_strDatFrom, string p_strDatTo, string p_strSampleType,
            string p_strAcceptEmp, string p_strPatientName, string p_strPatientCardID, string p_strBarCode, string p_strCheckCategory,string p_strSendPeopleID, string p_strInPatientNum,out clsSampleUnReceive_VO[] p_objResultArr)
        {
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
            return objSvc.m_lngGetUnReceivedSampleByCondition(objPrincipal, p_strDatFrom, p_strDatTo, p_strSampleType, p_strAcceptEmp, p_strPatientName, p_strPatientCardID, p_strBarCode, p_strCheckCategory, p_strSendPeopleID, p_strInPatientNum, out p_objResultArr);
        }
        #endregion

		#region 根据条件查询已接收的标本信息
		public long m_lngGetReceivedSampleByCondition(string p_strDatFrom,string p_strDatTo,string p_strSampleType,
			string p_strAcceptEmp,string p_strPatientName,string p_strPatientCardID,string p_strBarCode,string p_strCheckCategory,string p_strSendPeopleID,string p_strInPatientNum,out clsSampleReceive_VO[] p_objResultArr)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetReceivedSampleByCondition(objPrincipal,p_strDatFrom,p_strDatTo,p_strSampleType,p_strAcceptEmp,p_strPatientName,p_strPatientCardID,p_strBarCode,p_strCheckCategory,p_strSendPeopleID,p_strInPatientNum, out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

        #region 返回自定义组所有申请单元(限树深度为三层)
        /// <summary>
        /// 返回自定义组所有申请单元
        /// baojian.mo 2007.09.11 add
        /// </summary>
        /// <param name="p_strCheckCategory">自定义申请组名称</param>
        /// <param name="p_dtbDetail"></param>
        /// <returns></returns>
        public long m_lngGetAppuserGroupDetail(string p_strCheckCategory, out DataTable p_dtbDetail)
        {
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
            return objSvc.m_lngGetAppuserGroupDetail(objPrincipal,p_strCheckCategory, out p_dtbDetail);
        }
        #endregion

        #region 接收标本或退回
        public long m_lngReceiveSample(int p_intStatus, string p_strSampleID, string p_strReceiveDat, string p_strReceiveEmp, string p_strSendPeopleID)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
            lngRes = objSvc.m_lngReceiveSample(objPrincipal, p_intStatus, p_strSampleID, p_strReceiveDat, p_strReceiveEmp, p_strSendPeopleID);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion

		#region 仪器样本插队处理 童华 2004.08.27
		#region 新增一条记录
		public long m_lngAddNewSampleInterpose(clsLisSampleInterposeVO p_objRecord)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngAddNewSampleInterpose(objPrincipal,p_objRecord);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据仪器ID查询插队记录
		public long m_lngGetSampleInterposeByDeviceID(string p_strDeviceID,out clsLisSampleInterposeVO p_objResult)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetSampleInterposeByDeviceID(objPrincipal,p_strDeviceID,out p_objResult);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据仪器ID更新插队记录
		public long m_lngSetSampleInterpose(clsLisSampleInterposeVO p_objRecord)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngSetSampleInterpose(objPrincipal,p_objRecord);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 插队处理
		public long m_lngSampleInterpose(clsLisSampleInterposeVO p_objRecord)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngSampleInterpose(objPrincipal,p_objRecord);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion
		#endregion

		#region 更新表T_OPR_LIS_DEVICE_RELATION 童华 2004.07.26
		public long m_lngSetLisDeviceRelation(clsT_LIS_DeviceRelationVO p_objRecord)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngSetLisDeviceRelation(objPrincipal,p_objRecord);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据条件查询仪器与样本之间的关系 童华 2004.07.26
		public long m_lngGetDeviceRelationVOArrByCondition(string p_strDeviceID,string p_strCheckDatFrom,string p_strCheckDatTo,
			out clsT_LIS_DeviceRelationVO[] p_objResultArr)
		{
			long lngRes=0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetDeviceRelationVOArrByCondition(objPrincipal,p_strDeviceID,p_strCheckDatFrom,p_strCheckDatTo,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region [U]增加一个样本,同时修改申请样本组 刘彬 2004.07.21
		/// <summary>
		/// 增加一个样本,同时修改申请样本组
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strAppID"></param>
		/// <param name="p_objRecordVO"></param>
		/// <returns></returns>
		public long m_lngAddNewSampleAndModifyAppSampleGroup(
			string p_strAppID,ref clsT_OPR_LIS_SAMPLE_VO p_objRecordVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngAddNewSampleAndModifyAppSampleGroup(objPrincipal,
			 p_strAppID,ref p_objRecordVO);
			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 核收仪器标本 童华 2004.07.07
		public long m_lngReceptSample(clsT_OPR_LIS_SAMPLE_VO p_objSampleVO,clsT_LIS_DeviceRelationVO p_objDeviceRelationVO)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngReceptSample(objPrincipal,p_objSampleVO,p_objDeviceRelationVO);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据BarCode判断该标本是否已经核收 童华 2004.07.07
		public long m_lngGetReceptedSampleInfoByBarCode(string p_strBarCode,out clsT_OPR_LIS_SAMPLE_VO p_objRecord)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetReceptedSampleInfoByBarCode(objPrincipal,p_strBarCode,out p_objRecord);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据日期范围查询已核收的标本 童华 2004.07.07
		public long m_lngGetReceptedSampleByDateRange(string p_strDeviceID,string p_strFromDat,string p_strToDat,out DataTable p_dtbResult)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetReceptedSampleByDateRange(objPrincipal,p_strDeviceID,p_strFromDat,p_strToDat,out p_dtbResult);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据采样日期查询未核收的标本信息 童华 2004.07.07
		public long m_lngGetNotReceptSampleBySamplingDat(string p_strFromDat,string p_strToDat,out DataTable p_dtbResult)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetAllNotReceptSample(objPrincipal,p_strFromDat,p_strToDat,out p_dtbResult);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据标本的BarCode查询相应的标本组信息 童华 2004.07.06
		public long m_lngGetSampleInfoByBarCode(string p_strBarCode,out DataTable p_dtbResult)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetSampleInfoByBarCode(objPrincipal,p_strBarCode,out p_dtbResult);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 获取所有的标本类型信息 童华 2004.06.29
		public long m_lngGetSampleTypeArr(out clsSampleType_VO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetSampleTypeArr(objPrincipal,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据标本ID查询标本信息 童华 2004.06.21
		public long m_lngGetSampleVOArrBySampleID(string p_strSampleID,out clsT_OPR_LIS_SAMPLE_VO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetSampleVOArrBySampleID(objPrincipal,p_strSampleID,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据BarCode 得到样本VO 刘彬 2004.07.6
		public long m_lngGetSampleVOByBarcode(string p_strBarCode,out clsT_OPR_LIS_SAMPLE_VO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetSampleVOByBarcode(objPrincipal,p_strBarCode,out p_objResultArr);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion


		#region 根据标本ID查询标本和仪器标本的关系VO 童华 2004.06.21
		public long m_lngGetDeviceRelationVOArrBySampleID(string p_strSampleID,out clsT_LIS_DeviceRelationVO[] p_objResultArr)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSvc.m_lngGetDeviceRelationVOArrBySampleID(objPrincipal,p_strSampleID,out p_objResultArr);
//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region m_lngModifyBind 删除仪器一个关联并增加一个关联 刘彬 2004.05.26
		/// <summary>
		/// 删除仪器关联
		/// </summary>
		/// <param name="p_objSourceVO"></param>
		/// <param name="p_objTargetVO"></param>
		/// <returns></returns>
		public long m_lngModifyBind(clsT_LIS_DeviceRelationVO p_objSourceVO,clsT_LIS_DeviceRelationVO p_objTargetVO)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngModifyBind(objPrincipal,p_objSourceVO,p_objTargetVO);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion


		#region m_lngAddNewDeviceRelation  为表 t_opr_lis_device_relation  新增 记录时用 刘彬 2004.06.9
		/// <summary>
		/// 为表 t_opr_lis_device_relation  新增 记录时用 刘彬 2004.06.9
		/// </summary>
		/// <param name="p_objRecord"></param>
		/// <returns></returns>
		public long m_lngAddNewDeviceRelation(clsT_LIS_DeviceRelationVO p_objRecord)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngAddNewDeviceRelation(objPrincipal,p_objRecord);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region m_lngDeleteDeviceRelation 删除仪器关联 刘彬 2004.05.26
		/// <summary>
		/// 删除仪器关联
		/// </summary>
		/// <param name="p_strDeviceID"></param>
		/// <param name="p_strRelationDate"></param>
		/// <param name="p_strSeq"></param>
		/// <returns></returns>
		public long m_lngDeleteDeviceRelation(string p_strDeviceID,string p_strRelationDate,string p_strSeq)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngDeleteDeviceRelation(objPrincipal,p_strDeviceID,p_strRelationDate,p_strSeq);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region m_lngDeleteDeviceRelation 删除仪器关联 刘彬 2004.05.26
		/// <summary>
		/// 删除仪器关联
		/// </summary>
		/// <param name="p_objRelation"></param>
		/// <param name="p_blnReleaseDeviceSample"></param>
		/// <returns></returns>
		public long m_lngDeleteDeviceRelation(clsT_LIS_DeviceRelationVO p_objRelation,bool p_blnReleaseDeviceSample)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngDeleteDeviceRelation(objPrincipal,p_objRelation);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region m_lngInsertSampleRecord  为表 t_opr_lis_sample 新增,修改,删除 记录时用 刘彬 2004.05.26

		/// <summary>
		/// 为表 t_opr_lis_sample 新增,修改,删除 记录时用 ;
		/// 刘彬 2004.05.26
		/// </summary>
		/// <param name="p_objRecordVOArr"></param>
		/// <returns></returns>		
		public long m_lngInsertSampleRecord(clsT_OPR_LIS_SAMPLE_VO [] p_objRecordVOArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
			lngRes = objSvc.m_lngInsertSampleRecord(objPrincipal,p_objRecordVOArr);
			//			objSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 根据SampleID,GroupID（无子组）,查询结果项 刘彬 2004.05.11
		/// <summary>
		/// 根据SampleID,GroupID（基本检验组）查询结果项
		/// </summary>
		/// <param name="p_strGroupID"></param>
		/// <param name="p_strSmapleID"></param>
		/// <param name="p_dtbPrintResult">
		/// modify_dat
		/// groupid_chr
		/// check_item_id_chr
		/// sample_id_chr
		/// result_vchr
		/// unit_vchr 
		/// device_check_item_name_vchr
		/// refrange_vchr
		/// check_item_name_vchr
		/// check_item_english_name_vchr
		/// min_val_dec
		/// max_val_dec
		/// abnormal_flag_chr
		/// check_dat
		/// clinicapp_vchr
		/// memo_vchr
		/// confirm_dat
		/// deviceid_chr
		/// pointliststr_vchr
		/// summary_vchr
		/// graph_img
		/// status_int
		/// checker1_chr
		/// checker2_chr
		/// confirm_person_chr
		/// operator_id_chr
		/// check_deptid_chr
		/// print_ord_int
		/// </param>
		/// <returns></returns>
		public long m_lngGetPrintResult(string p_strSampleID,string p_strGroupID,out System.Data.DataTable p_dtbPrintResult)
		{
			long lngRes=0;
			p_dtbPrintResult=null;
            com.digitalwave.iCare.middletier.LIS.clsQueryCheckResultSvc objResultSvc = null;
            //objResultSvc=new com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc();
            com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc objSvc =
              (com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsCheckResultSvc));
          
			lngRes=objResultSvc.m_lngGetPrintResult(objPrincipal,p_strGroupID,p_strSampleID,out p_dtbPrintResult);
			//objResultSvc.Dispose();
			return lngRes;

           
		}
		#endregion

		#region 审核标本 刘彬 2004.05.11
		/// <summary>
		/// 审核标本 
		/// 刘彬 2004.05.11
		/// </summary>
		/// <param name="p_strSampleID"></param>
		/// <returns></returns>
		public long m_lngAuditingSample(string p_strSampleID)
		{
			long lngRes=0;
            //com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc=null;
            //objSvc=new com.digitalwave.iCare.middletier.LIS.clsSampleSvc();
            com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc =
               (com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
           
			lngRes=objSvc.m_lngAuditingSample(objPrincipal,p_strSampleID);
			//objResultSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 得到所有检验样品类型 刘彬 2004.05.13
		/// <summary>
		/// 得到所有检验样品类型
		/// 刘彬 2004.05.13
		/// </summary>
		/// <param name="p_dtbSampleTypeList">
		/// SAMPLE_TYPE_ID_CHR
		/// SAMPLE_TYPE_DESC_VCHR
		/// PYCODE_CHR
		/// WBCODE_CHR
		/// STDCODE1_CHR
		/// STDCODE2_CHR
		/// </param>
		/// <returns></returns>
		public long m_lngGetSampleTypeList(out System.Data.DataTable p_dtbSampleTypeList)
		{
			long lngRes = 0;
			p_dtbSampleTypeList = null;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSampleSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			System.Security.Principal.IPrincipal objPrincipal = null;
			lngRes = objSampleSvc.m_lngGetSampleTypeList(objPrincipal, out p_dtbSampleTypeList);
			//			objSampleSvc.Dispose();
			return lngRes;
		}
		#endregion

        #region 获取所有的检型类别
        /// <summary>
        /// 获取所有的检型类别
        /// baojian.mo 2007.09.10
        /// </summary>
        /// <param name="p_dtbCheckCategory"></param>
        /// <returns></returns>
        public long m_lngGetCheckCategoryList(out DataTable p_dtbCheckCategory)
        {
            long lngRes = 0;
            p_dtbCheckCategory = null;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSampleSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
            System.Security.Principal.IPrincipal objPrincipal = null;
            lngRes = objSampleSvc.m_lngGetCheckCategoryList(objPrincipal, out p_dtbCheckCategory);            
            return lngRes;
        }
        #endregion

        #region 根据样品类型ID获取样品状态 刘彬 2004.05.13
        /// <summary>
		/// 根据样品类型ID获取样品状态
		/// 刘彬 2004.05.13
		/// </summary>
		/// <param name="strSampleTypeID"></param>
		/// <param name="dtbSampleState">
		/// character_desc_vchr
		/// </param>
		/// <returns></returns>
		public long m_lngGetStateBySampleType(string p_strSampleTypeID,out System.Data.DataTable p_dtbSampleState)
		{
			p_dtbSampleState = null;
			long lngRes = 0;
			System.Security.Principal.IPrincipal p_objPrincipal = null;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSampleSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSampleSvc.m_lngGetSampleState(p_objPrincipal,p_strSampleTypeID,out p_dtbSampleState);
			//			objSampleSvc.Dispose();
			return lngRes;
		}
		#endregion

		#region 得到所有的样本状态信息列表 刘彬 2004.05.27
		/// <summary>
		/// 得到所有的样本状态信息列表
		///  刘彬 2004.05.27
		/// </summary>
		/// <param name="p_dtbSampleState">
		/// table:t_aid_lis_sample_character
		/// column:
		/// character_desc_vchr
		/// pycode_chr
		/// wbcode_chr
		/// sample_type_id_chr
		/// </param>
		/// <returns></returns>
		public long m_lngGetSampleStateList(out System.Data.DataTable p_dtbSampleState)
		{
			p_dtbSampleState = null;
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc objSampleSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
			lngRes = objSampleSvc.m_lngGetSampleState(objPrincipal,out p_dtbSampleState);
			//			objSampleSvc.Dispose();
			return lngRes;
		}
		#endregion

        #region 不曾调用的函数
             #region 根据各条件组合查询得到样本列表 刘彬 2004.05.10
        /// <summary>
        /// 根据各条件组合查询得到样本列表
        /// 刘彬 2004.05.10
        /// </summary>
        /// <param name="p_intDevice">
        /// 0: 手工和仪器
        /// 1：仪器
        /// 2：手工
        /// </param>
        /// <param name="p_strDeviceID">可为空</param>
        /// <param name="p_intAuditing">
        /// 0：已审核和未审核
        /// 1：未审核
        /// 2：已审核
        /// </param>
        /// <param name="p_strCheckDate_Begin">可为空</param>
        /// <param name="p_strCheckDate_End">可为空</param>
        /// <param name="p_dtbSampleList">承载结果数据
        /// sample_id_chr
        /// barcode_vchr
        /// groupid_chr
        /// check_date_dat
        /// status_int
        /// application_form_no_chr
        /// patient_name_vchr
        /// sex_chr
        /// age_chr
        /// diagnose_vchr
        /// appl_empid_chr
        /// appl_deptid_chr
        /// </param>
        /// <returns>>0 时有效</returns>
        //        public long m_lngGetSampleList(int p_intDevice,string p_strDeviceID,int p_intAuditing, string p_strCheckDate_Begin, string p_strCheckDate_End,out DataTable p_dtbSampleList)
        //        {
        //            long lngRes = 0;
        //            p_dtbSampleList = null;

        //            com.digitalwave.iCare.middletier.LIS.clsSampleSvc objSvc = 
        //                (com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
        //            lngRes = objSvc.m_lngGetSampleList(objPrincipal, p_intDevice, p_strDeviceID, p_intAuditing,  p_strCheckDate_Begin,  p_strCheckDate_End,out  p_dtbSampleList);
        ////			objSvc.Dispose();
        //            return lngRes;
        //        }
        #endregion
        #endregion
        
        #region 查找病区
        /// <summary>
        /// 查找病区	根据输入字符串
        /// </summary>
        /// <param name="strCode">输入字符串</param>
        /// <param name="p_objResultArr">病区对象	[out 参数]</param>
        public long m_lngFindArea(string strCode, out clsBIHArea[] p_objResultArr)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSampleSvc =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSampleSvc.m_lngFindArea(strCode, out p_objResultArr);
            //			objSampleSvc.Dispose();
            return lngRes;

         
        }
        #endregion

        #region 修改采样人员
        /// <summary>
        /// 修改采样人员
        /// </summary>
        /// <param name="p_strEmpId"></param>
        /// <param name="p_strSampleId"></param>
        /// <returns></returns>
        public long m_lngInsertCollector(string p_strEmpId, string p_strSampleId, string p_strApplicationID)
        {
            long lngRes = 0;
            clsSampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
            lngRes = objSvc.m_lngInsertCollector(objPrincipal, p_strEmpId, p_strSampleId, p_strApplicationID);
            return lngRes;
        }
        #endregion

        #region 获取样本状态
        /// <summary>
        /// 获取样本状态
        /// </summary>
        /// <param name="p_strSampleID"></param>
        /// <param name="p_intStatus"></param>
        /// <returns></returns>
        public long m_lngQuerySampleStatus(string p_strSampleID, out int p_intStatus,out string p_strIsSampleBack)
        {
            long lngRes = 0;
            clsQuerySampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQuerySampleSvc));
            lngRes = objSvc.m_lngQuerySampleStatus(p_strSampleID, out p_intStatus, out p_strIsSampleBack);
            return lngRes;
        }
        #endregion

        #region 插入样本回馈表信息
        /// <summary>
        /// 插入样本回馈表信息
        /// </summary>
        /// <param name="p_objSampleFeedBack"></param>
        /// <returns></returns>
        public long m_lngInsertSampleFeedBack(clslissample_feedback p_objSampleFeedBack)
        {
            long lngRes = 0;
            clsSampleSvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsSampleSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsSampleSvc));
            lngRes = objSvc.m_lngInsertSampleFeedBack(p_objSampleFeedBack);
            return lngRes;
        }
        #endregion

    }
}
