using System;
using System.Windows.Forms;
using com.digitalwave.Emr.StaticObject;

namespace iCare
{
	/// <summary>
	/// 登录信息:在系统登录后初始化电子病历的相关信息
	/// </summary>
	public class clsEMRLogin : MarshalByRefObject
	{
        //private System.Windows.Forms.Timer tmGetMsg;
		private string m_strDoctorID;

		public clsEMRLogin()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
            //this.tmGetMsg = new System.Windows.Forms.Timer();
			
            //this.tmGetMsg.Enabled = false;
            //this.tmGetMsg.Interval = 300000;
            //this.tmGetMsg.Tick += new System.EventHandler(this.tmGetMsg_Tick);
		}

		public void m_mthInit(Form p_frmMDI,com.digitalwave.iCare.ValueObject.clsLoginInfo p_objLoginInfo)
		{
			s_frmMDI = p_frmMDI;
			m_objLoginInfo = p_objLoginInfo;

			clsLoginContext objLogin = clsLoginContext.s_ObjLoginContext;
			objLogin.m_StrEmployeeID = p_objLoginInfo.m_strEmpNo;
            MDIParent.m_mthClearAll();
            m_objCurDeptOfEmpArr = null;
			new clsForWholeHosInfoManager().m_lngGetDepartmentByUserID(p_objLoginInfo.m_strEmpID,out m_objCurDeptOfEmpArr);

			m_mthGetCurrentHospitalInfo();

            #region 设置全局员工变量，新员工类，该静态类会被外部其他模块调用到，要保证正确赋值 tfzhang 2006－04－07
            iCareData.clsEmrEmployeeBase_VO m_objEmployeeTemp;
            com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objsrv = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
            long lngRes = objsrv.m_lngGetEmpByID(m_objLoginInfo.m_strEmpID, out m_objEmployeeTemp);
            //未保存状态 用于签名集合
            m_objEmployeeTemp.m_intSTATUS_INT = 0;
            com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentEmployee = m_objEmployeeTemp; 
            #endregion


			iCare.CustomForm.clsExteriorFunctionInterface.m_ObjUserInfo = p_objLoginInfo;
			iCare.CustomForm.clsExteriorFunctionInterface.m_ObjCurDeptOfEmpArr = m_objCurDeptOfEmpArr;

            //获取修改时限 小时
            if (clsEMR_StaticObject.s_IntCanModifyTime <= 0)
            {
                com.digitalwave.PublicMiddleTier.clsPublicMiddleTier objPM =
                    (com.digitalwave.PublicMiddleTier.clsPublicMiddleTier)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PublicMiddleTier.clsPublicMiddleTier));

                objPM.m_lngGetRTBChangeTime("3001", out strCanModifyTime);
            }
            else 
            {
                strCanModifyTime = clsEMR_StaticObject.s_IntCanModifyTime.ToString();
            }

			m_strDoctorID = p_objLoginInfo.m_strEmpNo;
		}

		#region MDI窗口
		private static Form s_frmMDI = null;
		public static Form s_FrmMDI
		{
			get{return s_frmMDI;}
		}
		#endregion
        
        /// <summary>
        /// 定时获取当前医生提醒信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void tmGetMsg_Tick(object sender, System.EventArgs e)
		{
            //暂时屏蔽 此步骤应该在中间件处理 thzhang 2006－04－01
            //System.Data.DataTable dtbMsg=new System.Data.DataTable();
            //string strSQL="SELECT * FROM T_TODAYMESSAGES WHERE DOCTORID='"+m_strDoctorID.Trim()+"'";
            //com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objServ = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
            //long lngRes=objServ.DoGetDataTable(strSQL,ref dtbMsg);
            ////收到消息后删除消息
            //strSQL = "DELETE FROM T_TODAYMESSAGES WHERE DOCTORID='"+m_strDoctorID.Trim()+"'";
            //lngRes = objServ.DoExcute(strSQL);
            ////objServ.Dispose();
            //if(dtbMsg.Rows.Count>0)
            //{
            //    string strMSG=dtbMsg.Rows[0]["DOCTORNAME"].ToString().Trim()+":您好!";
            //    for(int i=0;i<dtbMsg.Rows.Count;i++)
            //    {					
            //        strMSG=strMSG+"\n"+dtbMsg.Rows[i]["BENNAME"].ToString().Trim()+"床的患者【"+dtbMsg.Rows[i]["PATIENTNAME"].ToString().Trim()+"】";
            //        strMSG=strMSG+"\n"+dtbMsg.Rows[i]["TODAYMESSAGES"].ToString().Trim();					
            //    }
            //    tmGetMsg.Stop();
            //    clsPublicFunction.ShowInformationMessageBox(strMSG);
            //}
            //GC.Collect();
		}

		/// <summary>
		/// 获取当前医院名称及编码
		/// </summary>
		private void m_mthGetCurrentHospitalInfo()
		{
            if (clsEMR_StaticObject.s_StrCurrentHospitalName == string.Empty || clsEMR_StaticObject.s_StrCurrentHospitalNO == string.Empty)
            {
                com.digitalwave.DepartmentManagerService.clsDepartmentHandlerService objDeptMS =
                    (com.digitalwave.DepartmentManagerService.clsDepartmentHandlerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DepartmentManagerService.clsDepartmentHandlerService));

                long lngRes = objDeptMS.m_lngGetHospitalInfo(out m_strCurrentHospitalName, out m_strCurrentHospitalNO);
            }
            else 
            {
                m_strCurrentHospitalName = clsEMR_StaticObject.s_StrCurrentHospitalName;
                m_strCurrentHospitalNO = clsEMR_StaticObject.s_StrCurrentHospitalNO;
            }
		}
		/// <summary>
		/// 获取登录员工信息 旧
		/// </summary>
		private static com.digitalwave.iCare.ValueObject.clsLoginInfo m_objLoginInfo;
		/// <summary>
		/// 获取登录员工信息VO 新
		/// </summary>
		private static iCareData.clsEmrEmployeeBase_VO m_objLoginEmployee;
		/// <summary>
		/// 获取登录员工信息 旧 
		/// </summary>
		public static com.digitalwave.iCare.ValueObject.clsLoginInfo LoginInfo
		{
            get
            {
                if (m_objLoginInfo != null)
                    return m_objLoginInfo;
                else
                {
                    return new com.digitalwave.iCare.ValueObject.clsLoginInfo();

                }
            }
		}
		/// <summary>
		///  获取登录员工信息VO 新
		/// </summary>
		public static iCareData.clsEmrEmployeeBase_VO LoginEmployee
		{
			get
			{
				if (m_objLoginEmployee!=null)
                {
                    m_objLoginEmployee.m_intSTATUS_INT=0;
                    return m_objLoginEmployee;
                }
					
                else if (clsEMR_StaticObject.s_ObjCurrentEmployee != null)
                {
                    clsEMR_StaticObject.s_ObjCurrentEmployee.m_intSTATUS_INT = 0;
                    return clsEMR_StaticObject.s_ObjCurrentEmployee;
                }
                else
                { 
                    com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain objsrv = new com.digitalwave.emr.BEDExplorer.clsHospitalManagerDomain();
                    long lngRes = objsrv.m_lngGetEmpByID(m_objLoginInfo.m_strEmpID, out m_objLoginEmployee);
                    if (m_objLoginEmployee != null)
                    {
                        //未保存状态 用于签名集合
                        m_objLoginEmployee.m_intSTATUS_INT = 0;
                    }
                    return m_objLoginEmployee;
                }
			}
		}

		private static com.digitalwave.iCare.ValueObject.clsDepartmentVO[] m_objCurDeptOfEmpArr;
		/// <summary>
		/// 获取登录员工所属科室
		/// </summary>
		public static com.digitalwave.iCare.ValueObject.clsDepartmentVO[] m_ObjCurDeptOfEmpArr
		{
			get{return m_objCurDeptOfEmpArr;}
		}

		private static string m_strCurrentHospitalName;
		/// <summary>
		/// 获取当前医院名称
		/// </summary>
		public static string m_StrCurrentHospitalName
		{
			get{return m_strCurrentHospitalName;}
		}

		private static string m_strCurrentHospitalNO;
		/// <summary>
		/// 获取当前医院编码(行政区划代码(7位)+序号)
		/// </summary>
		public static string m_StrCurrentHospitalNO
		{
			get{return m_strCurrentHospitalNO;}
		}
		private static string strCanModifyTime;
		/// <summary>
		/// 获取修改时效
		/// </summary>
		public static string StrCanModifyTime
		{
			get{return strCanModifyTime;}
		}
		
	}
}
