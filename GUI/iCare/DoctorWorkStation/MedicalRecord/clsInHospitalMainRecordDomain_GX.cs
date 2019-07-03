using System;
using System.IO;
using System.Text;
using com.digitalwave.InHospitalMainRecord;
using iCareData;
using System.Data;
using com.digitalwave.PatientManagerService;
using com.digitalwave.EMR_EmployeeManagerService;

namespace iCare
{
    /// <summary>
    /// clsInHospitalMainRecordDomain_GX 的摘要说明。
    /// </summary>
    public class clsInHospitalMainRecordDomain_GX
    {
        public clsInHospitalMainRecordDomain_GX()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 模糊查询获得麻醉方式
        /// <summary>
        ///模糊查询获得麻醉方式
        /// </summary>
        /// <returns></returns>
        public long m_lngGetAnaesthesiaModeLikeID(out clsAnaesthesiaModeInOperation[] p_objAnaesthesiaModeInOperation)
        {
            clsQuery8iServ m_objServ =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetAnaesthesiaModeLikeID(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, out p_objAnaesthesiaModeInOperation);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }
        #endregion

        #region 查询获得手术名称、编码
        /// <summary>
        /// 查询获得手术名称、编码
        /// </summary>
        /// <param name="P_dtbOp"></param>
        /// <returns></returns>
        public long m_lngGetOperationDesc(out DataTable P_dtbOp)
        {
            P_dtbOp = null;

            clsQuery8iServ objServ =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long lngRes = objServ.m_lngGetOperationDesc(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, out P_dtbOp);
            //objServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取转科情况
        /// <summary>
        /// 获取转科情况
        /// </summary>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_strInPatientDate">住院登记表中的住院日期</param>
        /// <param name="p_strRegisterID">住院登记号</param>
        /// <param name="p_objDeptInstance">转科情况</param>
        /// <returns></returns>
        public long m_lngGetInHospitalMainTransDeptInstance(string p_strPatientID, string p_strInPatientDate, out string p_strRegisterID, out clsInHospitalMainTransDeptInstance p_objDeptInstance)
        {
            p_strRegisterID = "";
            long lngRes = 0;

            clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));

            lngRes = objServ.m_lngGetRegisterIDByPatient(p_strPatientID, p_strInPatientDate, out p_strRegisterID);

            lngRes = m_lngGetInHospitalMainTransDeptInstance(p_strRegisterID, out p_objDeptInstance);
            //objServ.Dispose();
            return lngRes;
        }

        /// <summary>
        /// 获取病人出院时间，暂时先在各个窗体查询
        /// </summary>
        /// <returns></returns>
        public long m_lngGetInHospitalMainTransDeptInstance(string p_strRegisterID, out clsInHospitalMainTransDeptInstance p_objDeptInstance)
        {
            long lngRes = 0;

            clsInHospitalMainRecordServ_GX objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));                

            lngRes = objServ.m_lngGetInHospitalMainTransDeptInstance(p_strRegisterID, out p_objDeptInstance);
            //objServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 获得该次住院的住院病案首页的生成时间
        /// <summary>
        /// 获得该次住院的住院病案首页的生成时间
        /// 空则为没有生成过
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <returns></returns>
        public long m_lngGetOpenDateInfo(string p_strRegisterID, out DateTime[] p_dtmOpenDate)
        {
            p_dtmOpenDate = null;
            if (p_strRegisterID == null || p_strRegisterID == "")
                return -1;

            clsInHospitalMainRecordServ_GX m_objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

            string m_strXML = "";
            int m_intRows = 0;
            long lngRes = m_objServ.m_lngGetOpenDateInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID, out p_dtmOpenDate);
            //m_objServ.Dispose();
            return lngRes;
        }

        #endregion

        #region 从数据库获得记录
        /// <summary>
        /// 从数据库获得记录
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_objMain"></param>
        /// <returns></returns>
        public long m_lngGetInfo(string p_strRegisterID, string p_strOpenDate, bool p_blnIsSumit, out clsInHospitalMainRecord_GX_Collection p_objCollection)
        {
            p_objCollection = null;
            if (p_strRegisterID == null || p_strRegisterID == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            clsInHospitalMainRecordServ_GX m_objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

            long m_lngRes = m_objServ.m_lngGetInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID, p_strOpenDate, p_blnIsSumit, out p_objCollection);
            //m_objServ.Dispose();
            return m_lngRes;
        }

        /// <summary>
        /// 获取已删除记录
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_objCollection"></param>
        /// <returns></returns>
        public long m_lngGetDeletedInfo(string p_strRegisterID, string p_strOpenDate, out clsInHospitalMainRecord_GX_Collection p_objCollection)
        {
            p_objCollection = null;
            if (p_strRegisterID == null || p_strRegisterID == "")
                return -1;
            if (p_strOpenDate == null || p_strOpenDate == "")
                return -1;

            clsInHospitalMainRecordServ_GX m_objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

            long m_lngRes = m_objServ.m_lngGetDelInfo(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID, p_strOpenDate, out p_objCollection);
            //m_objServ.Dispose();
            return m_lngRes;
        }

        #endregion

        #region 模糊查询员工
        /// <summary>
        /// 模糊查询员工
        /// </summary>
        /// <param name="p_strSome"></param>
        /// <param name="p_lsvEmp"></param>
        /// <returns></returns>
        public long m_lngGetEmpArrByIDOrNameLike(string p_strSome, out System.Windows.Forms.ListViewItem[] p_lsvEmpItemArr)
        {
            p_lsvEmpItemArr = null;

            clsEMR_EmployeeManagerService m_objServ =
                (clsEMR_EmployeeManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_EmployeeManagerService));

            DataTable dtValue = null;
            long m_lngRes = m_objServ.m_lngGetEmpArrByIDOrNameLike(p_strSome, out dtValue);

            if (m_lngRes > 0 && dtValue.Rows.Count > 0)
            {
                p_lsvEmpItemArr = new System.Windows.Forms.ListViewItem[dtValue.Rows.Count];
                for (int i = 0; i < dtValue.Rows.Count; i++)
                {
                    p_lsvEmpItemArr[i] = new System.Windows.Forms.ListViewItem(dtValue.Rows[i][1].ToString());
                    p_lsvEmpItemArr[i].SubItems.Add(dtValue.Rows[i][2].ToString());
                }
            }
            //m_objServ.Dispose();
            return m_lngRes;
        }
        #endregion

        #region 保存内容
        public long m_lngDoSave(clsInHospitalMainRecord_GX_Collection p_objCollection, bool p_bolIfAddNew)
        {
            long lngRes = 0;
            try
            {
                clsInHospitalMainRecordServ_GX m_objServ =
                    (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

                if (p_bolIfAddNew)//新增
                    lngRes = m_objServ.m_lngAddNew(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objCollection);
                else//修改
                    lngRes = m_objServ.m_lngModify(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_objCollection);
                //m_objServ.Dispose();
            }
            catch (Exception ex)
            {
                clsPublicFunction.ShowInformationMessageBox(ex.Message);
                return -1;
            }
            return lngRes;
        }
        #endregion

        #region 获得最后修改时间,修改人
        /// <summary>
        /// 获得最后修改时间,修改人
        /// 如果返回空，表示该记录已被删除
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_strLastModifyDate"></param>
        /// <param name="p_strLastModifyUserID"></param>
        /// <returns></returns>
        public long m_lngGetLastModifyDateAndUser(long p_lngEMR_SEQ, out string p_strLastModifyUserID, out DateTime p_dtmLastModifyDate)
        {
            p_dtmLastModifyDate = DateTime.MinValue;
            p_strLastModifyUserID = null;

            clsInHospitalMainRecordServ_GX m_objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

            long lngRes = m_objServ.m_lngGetLastModifyDateInfo(p_lngEMR_SEQ, out p_strLastModifyUserID, out p_dtmLastModifyDate);
            //m_objServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 获得最后删除时间,删除人
        /// <summary>
        /// 获得最后删除时间,删除人
        /// 如果返回空，表示该记录已被删除
        /// </summary>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strDeactivedDate"></param>
        /// <param name="p_strDeactivedUserID"></param>
        /// <returns></returns>
        public long m_lngGetDeactivedDateAndUser(string p_strRegisterID, out DateTime p_dtmDeactivedDate, out string p_strDeactivedUserID)
        {
            p_dtmDeactivedDate = DateTime.MinValue;
            p_strDeactivedUserID = null;

            clsInHospitalMainRecordServ_GX m_objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

            long lngRes = m_objServ.m_lngGetDeactivedDateAndUser(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID, out p_dtmDeactivedDate, out p_strDeactivedUserID);
            //m_objServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        /// <param name="p_strTableName"></param>
        /// <param name="p_strInPatientID"></param>
        /// <param name="p_strInPatientDate"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_strOperatorID"></param>
        /// <returns></returns>
        public long m_lngDeleteRecord(long p_lngEMR_SEQ, string p_strOperatorID)
        {
            long lngRes = 0;
            if (p_strOperatorID == null || p_strOperatorID == "")
                return -1;

            clsInHospitalMainRecordServ_GX m_objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

            lngRes = m_objServ.m_lngDeleteRecord(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_lngEMR_SEQ, p_strOperatorID);
            //m_objServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取同步表中的病人收费信息
        /// <summary>
        /// 获取同步表中的病人收费信息
        /// </summary>
        /// <param name="p_strInPatientID">住院号</param>
        /// <param name="p_strInPatientDate">入院时间</param>
        /// <param name="p_objContent">暂存收费信息</param>
        /// <returns></returns>
        public long m_lngGetCost(string p_strInPatientID,
            string p_strInPatientDate,
            out clsInHospitalMainRecord_GXContent p_objContent)
        {
            clsInHospitalMainRecordServ_GX m_objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

           long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetCost(p_strInPatientID, p_strInPatientDate, out p_objContent);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }
        #endregion

        #region 获取同步表中的病人手术信息
        /// <summary>
        /// 获取同步表中的病人收费信息
        /// </summary>
        /// <param name="p_strInPatientID">住院号</param>
        /// <param name="p_strInPatientDate">入院时间</param>
        /// <param name="p_objContent">暂存收费信息</param>
        /// <returns></returns>
        public long m_lngGetOpInfo(string p_strInPatientID,
            string p_strInPatientDate,
            out DataTable p_dtbOpResult)
        {
            clsInHospitalMainRecordServ_GX m_objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

           long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngGetOpInfo(p_strInPatientID, p_strInPatientDate, out p_dtbOpResult);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }
        #endregion

        #region 查询第一次打印时间
        /// <summary>
        /// 查询第一次打印时间
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <param name="p_strFirstPrintDate"></param>
        /// <returns></returns>		
        public long m_strGetFirstPrintDate(string p_strRegisterID, out string p_strFirstPrintDate)
        {
            p_strFirstPrintDate = "";
            DateTime dtmFPD = DateTime.MinValue;

            clsInHospitalMainRecordServ_GX objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

            long lngRes = objServ.m_lngGetFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID, out dtmFPD);
            if (dtmFPD != DateTime.MinValue && dtmFPD != new DateTime(1900, 1, 1))
                p_strFirstPrintDate = dtmFPD.ToString("yyyy-MM-dd HH:mm:ss");
            //objServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 更新当前病人当次住院的首次打印时间
        /// <summary>
        /// 更新当前病人当次住院的首次打印时间
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <returns></returns>		
        public long m_lngUpdateFirstPrintDate(string p_strRegisterID)
        {//更新第一次打印时间

            clsInHospitalMainRecordServ_GX m_objServ =
                (clsInHospitalMainRecordServ_GX)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsInHospitalMainRecordServ_GX));

           long m_lngRes = 0;
            try
            {
                m_lngRes = m_objServ.m_lngUpdateFirstPrintDate(clsLoginContext.s_ObjLoginContext.m_ObjPrincial, p_strRegisterID);
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return m_lngRes;
        }
        #endregion

        #region 获取查询出的病人信息
        /// <summary>
        /// 获取查询出的病人信息
        /// </summary>
        /// <param name="p_strPatientID"></param>
        /// <param name="p_objPatient"></param>
        public void m_mthInitPatientInfo(string p_strPatientID,string p_strPatientName, out clsPatient p_objPatient)
        {
            p_objPatient = null;
            if (p_strPatientID == null)
                return;

            clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));

            string strEMRID = null;
            long m_lngRes = objServ.m_lngGetEMRIDByHISID(p_strPatientID, out strEMRID);
            if (strEMRID != null)
            {
                clsPeopleInfo objPeo = new clsPeopleInfo();
                objPeo.m_StrLastName = p_strPatientName;
                p_objPatient = new clsPatient(strEMRID, p_strPatientID.Trim(), objPeo);
            }
        }
        #endregion

        #region 获取军惠ICD10表信息
        /// <summary>
        /// 获取军惠ICD10表信息
        /// </summary>
        /// <param name="P_dtbICD"></param>
        /// <returns></returns>		
        public long m_lngGetICDFrom8i(out DataTable P_dtbICD)
        {
            P_dtbICD = null;

            clsQuery8iServ objServ =
                (clsQuery8iServ)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQuery8iServ));

            long lngRes = objServ.m_lngGetICDFrom8i(out P_dtbICD);
            //objServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取所有员工ID及姓名
        /// <summary>
        /// 获取所有员工ID及姓名
        /// </summary>
        /// <param name="P_dtbEmp"></param>
        /// <returns></returns>		
        public long m_lngGetAllEmp(out DataTable P_dtbEmp)
        {
            P_dtbEmp = null;

            clsEMR_EmployeeManagerService objServ =
                (clsEMR_EmployeeManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_EmployeeManagerService));

            long lngRes = objServ.m_lngGetAllEmp(out P_dtbEmp);
            //objServ.Dispose();
            return lngRes;
        }
        #endregion

        #region 获取所有员工ID及姓名
        /// <summary>
        /// 获取所有员工ID及姓名
        /// </summary>
        /// <param name="P_dtbEmp"></param>
        /// <returns></returns>		
        public long m_lngGetCurrentDeptEmp(string p_strDeptID, out DataTable P_dtbEmp)
        {
            P_dtbEmp = null;

            clsEMR_EmployeeManagerService objServ =
                (clsEMR_EmployeeManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsEMR_EmployeeManagerService));

            long lngRes = objServ.m_lngGetEmployeeByDeptID(null,p_strDeptID,out P_dtbEmp);
            return lngRes;
        }
        #endregion

        #region 病案首页查询

        /// <summary>
        /// 病案首页查询
        /// </summary>
        /// <param name="p_strDeptId">部门ID</param>
        /// <param name="p_strPatantId">病人ID</param>
        /// <param name="p_dtbResult">返回查询结果</param>
        /// <returns></returns>
         public long m_lngHospitalQuery(string p_strDeptId, string p_strPatantId, out DataTable p_dtbResult)
        {
            p_dtbResult = null;

            clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));

            long lngRes = objServ.m_lngHospitalQuery(p_strDeptId, p_strPatantId, out p_dtbResult);
            return lngRes;
        }

        #endregion


        #region 获取病人入院登记号
        /// <summary>
        /// 获取病人入院登记号
        /// </summary>
        /// <param name="p_strPatientID">病人ID</param>
        /// <param name="p_strInDate">HIS入院日期</param>
        /// <param name="p_strRegisterID">入院登记号</param>
        /// <returns></returns>
        public long m_lngGetRegisterIDByPatient(string p_strPatientID, string p_strInDate, out string p_strRegisterID)
        {
            string strRegisterID = "";
            long lngRes = 0;

            clsPatientManagerService objServ =
                (clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsPatientManagerService));

            lngRes = objServ.m_lngGetRegisterIDByPatient(p_strPatientID, p_strInDate, out p_strRegisterID);
            return lngRes;
        }
        #endregion
    }
}
