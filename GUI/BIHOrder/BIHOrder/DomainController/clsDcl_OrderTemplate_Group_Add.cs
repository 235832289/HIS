using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// clsDcl_OrderTemplate_Group_Add  
	/// </summary>
	public class clsDcl_OrderTemplate_Group_Add:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDcl_OrderTemplate_Group_Add()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		/// <summary>
		/// 同方下的父项目ID
		/// </summary>
		private string m_strParentID="";
		//事务
		#region 整体保存医嘱组套成员
		/// <summary>
		/// 整体保存医嘱组套成员
		/// </summary>
		/// <param name="p_dtDataName"></param>
		/// <param name="p_objResult"></param>
		public long m_lngSaveOrderGroupDetail(DataTable p_dtDataName,ref clsT_aid_bih_ordergroup_VO p_objResult,string[] strArr)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc));
            lngRes = objSvc.m_lngSaveOrderGroupDetail(objPrincipal, p_dtDataName, ref p_objResult, strArr);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		#endregion

        #region 整体保存医嘱组套成员
        /// <summary>
        /// 整体保存医嘱组套成员
        /// </summary>
        /// <param name="p_dtDataName"></param>
        /// <param name="p_objResult"></param>
        public long m_lngSaveOrderGroupDetailNew(clsT_aid_bih_ordergroup_VO dtResult, clsT_aid_bih_ordergroup_detail_VO[] m_objGroupVoList)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc objSvc = (com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc));
            lngRes = objSvc.m_lngSaveOrderGroupDetailNew(objPrincipal, dtResult, m_objGroupVoList);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
        #endregion

		/// <summary>
		/// 查询医嘱组套成员－医嘱组套流水号
		/// </summary>
		/// <param name="p_strGroupID">医嘱组套流水号</param>
		/// <param name="p_dtResult">【返回DataTable out参数】</param>
		/// <returns></returns>
		public long m_lngGetOrderGroupDetailByGroupID(string p_strGroupID, out DataTable p_dtResult)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc));
            lngRes = objSvc.m_lngGetOrderGroupDetailByGroupID(objPrincipal, p_strGroupID, out p_dtResult);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;
		}
		
		public long m_lngGetOrderGroupByID(string m_strGroupID,out clsT_aid_bih_ordergroup_VO p_objResult)
		{
			long lngRes=0;
			com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc objSvc =(com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsDoctorAdviceSvc));
            lngRes = objSvc.m_lngGetOrderGroupByID(objPrincipal, m_strGroupID, out p_objResult);
            objSvc.Dispose();
            objSvc = null;
			return lngRes;

		}

		/// <summary>
		/// 医嘱记录向 医嘱组套成员的转换
		/// </summary>
		/// <param name="objItem"></param>
		/// <param name="p_dtResult"></param>
		/// <returns></returns>
		public long m_InitValueOrderGroupDetail(clsBIHOrder objItem,ref DataTable drDataResult,bool ifParent,bool blnSame)
		{
			DataRow drDataRow;
			drDataRow=drDataResult.NewRow();
		    //MessageBox.Show(drDataResult.Columns.Count.ToString());
			long lngRes=0;
			/*
			//if(drDataRow["DETAILID_CHR"]!=System.DBNull.Value && drDataRow["DETAILID_CHR"]!=null)
				//objItem.m_strDETAILID_CHR =drDataRow["DETAILID_CHR"].ToString().Trim();
			   
			//if(drDataRow["GROUPID_CHR"]!=System.DBNull.Value && drDataRow["GROUPID_CHR"]!=null)
				//objItem.m_strGROUPID_CHR =drDataRow["GROUPID_CHR"].ToString().Trim();
			if(drDataRow["ORDERDICID_CHR"]!=System.DBNull.Value && drDataRow["ORDERDICID_CHR"]!=null)
				//objItem.m_strORDERDICID_CHR =drDataRow["ORDERDICID_CHR"].ToString().Trim();
				drDataRow["ORDERDICID_CHR"]=objItem.m_strOrderDicID.ToString().Trim();
			//if(drDataRow["FREQID_CHR"]!=System.DBNull.Value && drDataRow["FREQID_CHR"]!=null)
				//objItem.m_strFREQID_CHR =drDataRow["FREQID_CHR"].ToString().Trim();
               
			if(drDataRow["DOSAGE_DEC"]!=System.DBNull.Value && drDataRow["DOSAGE_DEC"]!=null)
				//objItem.m_fltDOSAGE_DEC =Convert.ToSingle(drDataRow["DOSAGE_DEC"].ToString());
				drDataRow["DOSAGE_DEC"]=objItem.m_dmlDosage.ToString().Trim();
			if(drDataRow["DOSAGEUNIT_CHR"]!=System.DBNull.Value && drDataRow["DOSAGEUNIT_CHR"]!=null)
				//objItem.m_strDOSAGEUNIT_CHR =drDataRow["DOSAGEUNIT_CHR"].ToString().Trim();
				drDataRow["DOSAGEUNIT_CHR"]=objItem.m_strDosageUnit.ToString().Trim();
			if(drDataRow["USE_DEC"]!=System.DBNull.Value && drDataRow["USE_DEC"]!=null)
				//objItem.m_fltUSE_DEC =Convert.ToSingle(drDataRow["USE_DEC"].ToString());
				drDataRow["USE_DEC"]=objItem.m_dmlUse.ToString().Trim();
			if(drDataRow["USEUNIT_CHR"]!=System.DBNull.Value && drDataRow["USEUNIT_CHR"]!=null)
				//objItem.m_strUSEUNIT_CHR =drDataRow["USEUNIT_CHR"].ToString().Trim();
				drDataRow["USEUNIT_CHR"]=objItem.m_strUseunit.ToString().Trim();
			if(drDataRow["GET_DEC"]!=System.DBNull.Value && drDataRow["GET_DEC"]!=null)
				//objItem.m_fltGET_DEC =Convert.ToSingle(drDataRow["GET_DEC"].ToString());
				drDataRow["GET_DEC"]=objItem.m_dmlGet.ToString().Trim();
			if(drDataRow["GETUNIT_CHR"]!=System.DBNull.Value && drDataRow["GETUNIT_CHR"]!=null)
				//objItem.m_strGETUNIT_CHR =drDataRow["GETUNIT_CHR"].ToString().Trim();
				drDataRow["GETUNIT_CHR"]=objItem.m_strGetunit.ToString().Trim();
			if(drDataRow["DOSETYPE_CHR"]!=System.DBNull.Value && drDataRow["DOSETYPE_CHR"]!=null)
				//objItem.m_strDOSETYPE_CHR =drDataRow["DOSETYPE_CHR"].ToString().Trim();
				drDataRow["DOSETYPE_CHR"]=objItem.m_strDosetypeID.ToString().Trim();
			if(drDataRow["ENTRUST_VCHR"]!=System.DBNull.Value && drDataRow["ENTRUST_VCHR"]!=null)
				//objItem.m_strENTRUST_VCHR =drDataRow["ENTRUST_VCHR"].ToString().Trim();
				drDataRow["ENTRUST_VCHR"]=objItem.m_strEntrust.ToString().Trim();
			if(drDataRow["ISRICH_INT"]!=System.DBNull.Value && drDataRow["ISRICH_INT"]!=null)
				//objItem.m_intISRICH_INT =Convert.ToInt32(drDataRow["ISRICH_INT"].ToString());
				drDataRow["ISRICH_INT"]=objItem.m_intIsRich.ToString().Trim();
			//父诊疗项目id
			if(drDataRow["PARENTID_CHR"]!=System.DBNull.Value && drDataRow["PARENTID_CHR"]!=null)
				//objItem.m_strPARENTID_CHR =drDataRow["PARENTID_CHR"].ToString().Trim();
				drDataRow["PARENTID_CHR"]=objItem.m_strParentID.ToString().Trim();
		//	if(drDataRow["IFPARENTID_INT"]!=System.DBNull.Value && drDataRow["IFPARENTID_INT"]!=null)
				//objItem.m_intIFPARENTID_INT =Convert.ToInt32(drDataRow["IFPARENTID_INT"].ToString());
		   */
			/*
				drDataRow["ORDERDICID_CHR"]=objItem.m_strOrderDicID.ToString().Trim();
			
				drDataRow["DOSAGE_DEC"]=objItem.m_dmlDosage.ToString().Trim();
			
				drDataRow["DOSAGEUNIT_CHR"]=objItem.m_strDosageUnit.ToString().Trim();
		
				drDataRow["USE_DEC"]=objItem.m_dmlUse.ToString().Trim();
			
				drDataRow["USEUNIT_CHR"]=objItem.m_strUseunit.ToString().Trim();
			
				drDataRow["GET_DEC"]=objItem.m_dmlGet.ToString().Trim();
			
				drDataRow["GETUNIT_CHR"]=objItem.m_strGetunit.ToString().Trim();
			
				drDataRow["DOSETYPE_CHR"]=objItem.m_strDosetypeID.ToString().Trim();
			
				drDataRow["ENTRUST_VCHR"]=objItem.m_strEntrust.ToString().Trim();
			
				drDataRow["ISRICH_INT"]=objItem.m_intIsRich.ToString().Trim();
			
				drDataRow["PARENTID_CHR"]=objItem.m_strParentID.ToString().Trim();
				*/
			drDataRow["ORDERDICID_CHR"]=objItem.m_strOrderDicID;
			drDataRow["DOSAGE_DEC"]=objItem.m_dmlDosage;
            drDataRow["DOSAGEUNIT_CHR"]=objItem.m_strDosageUnit;
			drDataRow["USE_DEC"]=objItem.m_dmlUse;	
			drDataRow["USEUNIT_CHR"]=objItem.m_strUseunit;
			drDataRow["GET_DEC"]=objItem.m_dmlGet;
			drDataRow["GETUNIT_CHR"]=objItem.m_strGetunit;
			drDataRow["DOSETYPE_CHR"]=objItem.m_strDosetypeID;
			drDataRow["ENTRUST_VCHR"]=objItem.m_strEntrust;
			drDataRow["ISRICH_INT"]=objItem.m_intIsRich;
			drDataRow["FREQID_CHR"]=objItem.m_strExecFreqID;
			if(ifParent)
			{
				drDataRow["IFPARENTID_INT"]=1;
				m_strParentID =objItem.m_strOrderDicID;
			}
			else
			{
				drDataRow["IFPARENTID_INT"]=0;
				if(blnSame)
				  drDataRow["PARENTID_CHR"]=m_strParentID.ToString().Trim();
			}
//			drDataRow["PARENTID_CHR"]=objItem.m_strParentID;
			
				
			drDataResult.Rows.Add(drDataRow);
			return lngRes;
		}

        /// <summary>
        /// 获取当前用户是否具有全院允许维护公共医嘱嘱套的角色
        /// </summary>
        /// <param name="m_strEmpID">当前员工号</param>
        /// <param name="m_blSystemRole"></param>
        public long GetTheSystemRole(string m_strEmpID, out bool m_blSystemRole)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService objSvc =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));
            lngRes = objSvc.GetTheSystemRole(m_strEmpID, out  m_blSystemRole);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }


        internal long m_lngGetTheOrderGroupName(string m_strNAME_CHR, out bool m_blSame)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService objSvc =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderGroupService));
            lngRes = objSvc.m_lngGetTheOrderGroupName(m_strNAME_CHR, out m_blSame);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
    }
}
