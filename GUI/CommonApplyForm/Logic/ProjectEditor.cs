using System;
using System.Data;
using System.Text;
using com.digitalwave.GLS_WS.UI;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GLS_WS.VO;
using DigitalWave;
using System.Reflection;
using com.digitalwave.GLS_WS;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.common;
using com.digitalwave.GLS_WS.ApplyReportServer;

namespace com.digitalwave.GLS_WS.Logic
{
    /// <summary>
    /// ProjectEditor 的摘要说明。
    /// </summary>
    public class ProjectEditor
    {
        public string applyID = null;
        public bool isChanged = false;
        public DataSet dsForm = null;
        public clsLoginInfo loginInfo = null;
        /// <summary>
        /// 1-心电图；2-动态心电图；3-平板运动心电图
        /// </summary>
        public int m_intHeartType = 0;
        private string applyTypeID = "";	//保存打开一张单据,对应的检查类型

        //       private DataProcess dp()
        //       {
        //            com.digitalwave.GLS_WS.ApplyReportServer.DataProcess objSvc =
        //(com.digitalwave.GLS_WS.ApplyReportServer.DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.GLS_WS.ApplyReportServer.DataProcess));
        //            return objSvc;
        //       }

        public DataProcess dp
        {
            get
            {
                com.digitalwave.GLS_WS.ApplyReportServer.DataProcess objSvc =
    (com.digitalwave.GLS_WS.ApplyReportServer.DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.GLS_WS.ApplyReportServer.DataProcess));
                return objSvc;
            }
        }

        private frmProject frmUI;
        private frmSelectType frmSeTy;
        private clsApplyRecord currentVO = null;//当前打开的VO
        private ControlWalkHandle changeAction;
        private clsHRPTableService m_objHRPService;

        public ProjectEditor(frmProject form)
        {
            this.frmUI = form;
            this.loginInfo = com.digitalwave.GUI_Base.frmMDI_Child_Base.CurrentLoginInfo;

            //监测每个可编辑控件是否被改动
            changeAction = new ControlWalkHandle(MonitorChange);
            frmUI.WalkThroughControl(frmUI, changeAction);
            m_objHRPService = new clsHRPTableService();
        }

        public ProjectEditor(frmSelectType form)
        {
            this.frmSeTy = form;
            // dp = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));

        }

        public ProjectEditor()
        {
        }
        public void m_mthGetDataTableBySQL(string strSQL, ref DataTable dt)
        {
            dt = new DataTable();
            dt = dp.SqlSelect(strSQL);
        }
        /// <summary>
        /// 打开相应单据供新建或编辑
        /// </summary>
        /// <param name="orderID">如果为null,则为新建</param>		
        public void Open(string orderID)
        {
            applyID = orderID;
            bool blnCanReport = true;

            if (applyID == null)
            {
                //New Project
                frmUI.GetControl("btnSubmit").Enabled = false;

                if (loginInfo != null)
                {
                    frmUI.FindControl("txtDoctorName").Text = loginInfo.m_strEmpName;
                    frmUI.FindControl("txtDoctorNO").Text = loginInfo.m_strEmpNo;
                }
            }
            else
            {
                // Open Project		
                string sql = string.Empty;
                // sql = "select * from AR_COMMON_APPLY where ApplyID = " + applyID;
                #region sql
                sql = @"select a.requisitionID as applyid,
                               '0' as reportid,
                               '' as deposit,
                               '' as balance,
                               b.appdate as applydate,
                               a.patient_uid as checkno,
                               a.clinicalNum as clinicno,
                               a.inHospitalNum as bihno,
                               a.patientName as name,
                               a.patientSex as sex,
                               a.patientAge as age,
                               a.sentByDepartment as department,
                               a.hospitalDistrictNum as area,
                               a.bedNum as bedno,
                               a.patientTelephone as tel,
                               a.patientAddress as address,
                               '' as summary,
                               a.clinicalDiagnosis as diagnose,
                               a.examineParts as diagnosepart,
                               '' as diagnoseaim,
                               a.sentByDoctor as doctorname,
                               c.empno_chr as doctorno,
                               b.appdate as finishdate,
                               a.chargeDesc as chargedetail,
                               '' as extrano,
                               a.cardNumber as cardno,
                               0 as deleted,
                               null as whodeletes,
                               null as deleteddate,
                               nvl(a.examineType, '') || '检查申请单' as applytitle,
                               2 as typeid,
                               1 as submitted,
                               2 as chargestatus_int,
                               b.appdeptid as deptid_chr,
                               b.appdeptid as areaid_chr,
                               b.appdoctid as doctorid_chr,
                               1 status_int,
                               to_char(a.patientBirthday) as birthday_vchr,
                               a.chargestatus as chargestatus,
                               1 as isEaf
                          from eafInterface a
                         inner join eafapplication b
                            on a.requisitionid = b.appid
                          left join t_bse_employee c
                            on b.appdoctid = c.empid_chr
                         where b.classcode in ('0006', '0007') 
                           and a.requisitionID = {0}   
                        union all
                        select applyid,
                               reportid,
                               deposit,
                               balance,
                               applydate,
                               checkno,
                               clinicno,
                               bihno,
                               name,
                               sex,
                               age,
                               department,
                               area,
                               bedno,
                               tel,
                               address,
                               summary,
                               diagnose,
                               diagnosepart,
                               diagnoseaim,
                               doctorname,
                               doctorno,
                               finishdate,
                               chargedetail,
                               extrano,
                               cardno,
                               deleted,
                               whodeletes,
                               deleteddate,
                               applytitle,
                               typeid,
                               submitted,
                               chargestatus_int,
                               deptid_chr,
                               areaid_chr,
                               doctorid_chr,
                               status_int,
                               birthday_vchr,
                               0 as chargestatus, 
                               0 as isEaf 
                          from AR_COMMON_APPLY 
                         where applyid = {1} 
                        ";
                sql = string.Format(sql, applyID, applyID);
                #endregion

                DataTable ds = new DataTable();
                try
                {
                    ds = dp.SqlSelect(sql);
                }
                catch { }

                if (ds.Rows.Count < 1)
                {
                    frmUI.ShowAlert("找不到记录号为\"" + applyID + "\"的记录！");
                    return;
                }

                //已提交
                if (ds.Rows[0]["Submitted"].ToString() == "1")
                {
                    frmUI.GetControl("btnSave").Enabled = false;
                    frmUI.GetControl("btnSubmit").Enabled = false;
                    DisableControls();
                }

                this.applyTypeID = ds.Rows[0]["TypeID"].ToString();
                InitialCombo(applyTypeID);
                //显示相关报告的菜单
                ShowReportMenu(applyTypeID);

                //根据控件名与字段的对应关系,批量填充界面中的控件
                frmUI.DisplayText(new string[] { "txt", "cb", "dp" }, ds.Rows[0]);

                #region 将每一段开始都加上两个空格,并删除诊断
                //{Text="现病史\r\n既史\r\n过敏\r\n个人史\r\n体fdffd\n格\r\n辅助\r\n诊断\r\n处\r\n备"}
                string strTextCut = frmUI.GetControl("txtDiagnose").Text.Trim();//诊断
                string strText = frmUI.GetControl("txtSummary").Text.Trim();//病历摘要
                strText = strText.Replace("\r\n", "\t");
                char[] charArr = new char[] { '\t' };
                string[] str = strText.Split(charArr);
                string strResult = "";
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != strTextCut)
                    {
                        str[i] = "  " + str[i] + "\r\n";
                        strResult += str[i];
                    }
                }
                frmUI.GetControl("txtSummary").Text = strResult.Replace("\t", ""); ;
                #endregion

                frmUI.FindControl("lblTitle").Text = ds.Rows[0]["ApplyTitle"].ToString();

                //判断该申请单是否已收费
                clsCheckChargeInfo objCCI = new clsCheckChargeInfo();
                blnCanReport = objCCI.m_mthCheckIsCharge(applyID, ApplyOrigin.PACSS);

                if (ds.Rows[0]["isEaf"] != DBNull.Value && Convert.ToInt32(ds.Rows[0]["isEaf"]) == 1)
                {
                    if (Convert.ToInt32(ds.Rows[0]["chargestatus"]) == 1)
                        blnCanReport = true;
                }
            }

            this.isChanged = false;
            frmUI.Show();
            //未收费状态不写报告
            frmUI.GetControl("btnReport").Enabled = blnCanReport;
        }
        /// <summary>
        /// 打开相应单据供新建或编辑
        /// </summary>
        /// <param name="orderID">如果为null,则为新建</param>		
        public void m_mthOpen(string p_strTypeID, string p_strTypeName)
        {
            if (p_strTypeID != null)
            {
                //显示相关报告的菜单
                ShowReportMenu(p_strTypeID);

                //根据控件名与字段的对应关系,批量填充界面中的控件
                //				frmUI.DisplayText(new string[]{"txt","cb","dp"}, ds.Tables[0].Rows[0]);		
                if (p_strTypeName != null && p_strTypeName != "")
                    frmUI.FindControl("lblTitle").Text = p_strTypeName + "申请单";
            }

            this.isChanged = false;
            frmUI.Show();
        }

        /// <summary>
        /// 根据类型检查类型ID,初始化部位和目的列表
        /// </summary>
        private void InitialCombo(string typeID)
        {
            if (typeID == "") return;

            ComboBox cbPart = new ComboBox();
            ComboBox cbAim = new ComboBox();
            DataTable dsPart = new DataTable();
            DataTable dsAim = new DataTable();
            try
            {
                cbPart = (ComboBox)frmUI.GetControl("cbDIAGNOSEPART");
                cbAim = (ComboBox)frmUI.GetControl("cbDIAGNOSEAIM");
                dsPart = dp.SqlSelect("select * from AR_APPLY_PARTLIST where Deleted <> 1 AND TypeID =" + typeID);
                dsAim = dp.SqlSelect("select * from AR_APPLY_AimList  where Deleted <> 1 AND typeID =" + typeID);
            }
            catch { }

            foreach (DataRow dr in dsPart.Rows)
            {
                cbPart.Items.Add(dr["PartName"].ToString());
            }

            foreach (DataRow dr in dsAim.Rows)
            {
                cbAim.Items.Add(dr["AimText"].ToString());
            }
        }

        /// <summary>
        /// 用指定的VO填充窗体并打开
        /// </summary>
        /// <param name="vo"></param>
        public clsCheckType[] OpenWithVO(clsApplyRecord vo)
        {
            this.currentVO = vo;
            this.applyTypeID = vo.m_strTypeID;
            string strTitle = "";

            try
            {
                if ((this.applyTypeID != null) && (this.applyTypeID != ""))
                {
                    InitialCombo(this.applyTypeID);
                    if (vo.m_strApplyTitle == "")
                    {
                        DataTable title = dp.ExecuteScalar("SELECT typetext FROM ar_apply_typelist WHERE typeid=" + this.applyTypeID);
                        if (title is DBNull) strTitle = "";
                        else strTitle = title.Rows[0]["typetext"].ToString();
                        vo.m_strApplyTitle = strTitle + "申请单";
                    }
                }

                frmUI.FindControl("lblTitle").Text = vo.m_strApplyTitle;
                frmUI.FindControl("txtDEPOSIT").Text = vo.m_strDeposit;
                frmUI.FindControl("txtBALANCE").Text = vo.m_strBalance;
                frmUI.FindControl("txtCHECKNO").Text = vo.m_strCheckNO;
                frmUI.FindControl("txtCLINICNO").Text = vo.m_strClinicNO;
                frmUI.FindControl("txtBIHNO").Text = vo.m_strBIHNO;
                frmUI.FindControl("txtNAME").Text = vo.m_strName;
                frmUI.FindControl("cbSEX").Text = vo.m_strSex;
                frmUI.FindControl("txtAGE").Text = vo.m_strAge;
                frmUI.FindControl("cbAREA").Text = vo.m_strArea;
                frmUI.FindControl("txtBEDNO").Text = vo.m_strBedNO;
                frmUI.FindControl("txtTEL").Text = vo.m_strTel;
                frmUI.FindControl("txtADDRESS").Text = vo.m_strAddress;

                #region 将每一段开始都加上两个空格,并删除诊断
                //{Text="现病史\r\n既史\r\n过敏\r\n个人史\r\n体fdffd\n格\r\n辅助\r\n诊断\r\n处\r\n备"}
                string strTextCut = vo.m_strDiagnose.Trim();//诊断
                string strText = vo.m_strSummary.Trim();//病历摘要
                strText = strText.Replace("\r\n", "\t");
                char[] charArr = new char[] { '\t' };
                string[] str = strText.Split(charArr);
                string strResult = "";
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] != strTextCut)
                    {
                        str[i] = "  " + str[i] + "\r\n";
                        strResult += str[i];
                    }
                }
                frmUI.GetControl("txtSUMMARY").Text = strResult.Replace("\t", ""); ;
                #endregion

                //frmUI.FindControl("txtSUMMARY").Text	  = vo.m_strSummary;
                frmUI.FindControl("txtDIAGNOSE").Text = vo.m_strDiagnose;
                frmUI.FindControl("cbDIAGNOSEPART").Text = vo.m_strDiagnosePart;
                frmUI.FindControl("cbDIAGNOSEAIM").Text = vo.m_strDiagnoseAim;
                frmUI.FindControl("txtDOCTORNAME").Text = vo.m_strDoctorName;
                frmUI.FindControl("txtDOCTORNO").Text = vo.m_strDoctorNO;
                frmUI.FindControl("txtEXTRANO").Text = vo.m_strExtraNO;
                frmUI.FindControl("txtCARDNO").Text = vo.m_strCardNO;
                frmUI.FindControl("cbDEPARTMENT").Text = vo.m_strDepartment;
                if (frmUI.m_intFlag == 0)
                {
                    frmUI.FindControl("txtCHARGEDETAIL").Text = GetChargeInfo(vo);//vo.m_strChargeDetail;	
                }
                else
                {
                    frmUI.FindControl("txtCHARGEDETAIL").Text = vo.m_strChargeDetail;
                }
                (frmUI.FindControl("txtFINISHDATE") as DateTimePicker).Value = vo.m_datFinishDate;
                (frmUI.FindControl("dpAPPLYDATE") as DateTimePicker).Value = vo.m_datApplyDate;

                if (vo.m_intSubmitted == 1)
                {
                    frmUI.GetControl("btnSave").Enabled = false;
                    frmUI.GetControl("btnSubmit").Enabled = false;
                    DisableControls();
                }

                if (vo.m_strApplyID == null || vo.m_strApplyID == "")
                {
                    frmUI.GetControl("btnSubmit").Enabled = false;
                }

                //显示相关报告的菜单
                ShowReportMenu(vo.m_strTypeID);

                frmUI.ShowDialog();
            }
            catch { }

            return clsApplyForm.saveResult;
        }

        /// <summary>
        /// 直接把一个VO保存为相应检查申请单
        /// </summary>
        /// <param name="vo"></param>
        public clsCheckType[] SaveWithVO(clsApplyRecord vo)
        {
            clsCheckType[] checks = frmSelectType.ShowSelect(vo);
            try
            {
                string sql = @"select applyid, reportid, deposit, balance, applydate, checkno, clinicno,
                                   bihno, name, sex, age, department, area, bedno, tel, address, summary,
                                   diagnose, diagnosepart, diagnoseaim, doctorname, doctorno, finishdate,
                                   chargedetail, extrano, cardno, deleted, whodeletes, deleteddate,
                                   applytitle, typeid, submitted, chargestatus_int, deptid_chr,
                                   areaid_chr, doctorid_chr, status_int
                              from ar_common_apply
                             where 1 = 2";

                DataTable ds = dp.SqlSelect(sql);
                DataRow dr;



                if (checks == null)
                {
                    //保存被取消
                    return null;
                }

                DataRow[] newRows = new DataRow[checks.Length];

                int nextID = int.Parse(dp.GetNextID("AR_COMMON_APPLY", "ApplyID"));

                for (int i = 0; i < checks.Length; i++)
                {
                    newRows[i] = ds.NewRow();
                    dr = newRows[i];

                    dr["DEPOSIT"] = vo.m_strDeposit;
                    dr["BALANCE"] = vo.m_strBalance;
                    dr["CHECKNO"] = vo.m_strCheckNO;
                    dr["CLINICNO"] = vo.m_strClinicNO;
                    dr["BIHNO"] = vo.m_strBIHNO;
                    dr["NAME"] = vo.m_strName;
                    dr["SEX"] = vo.m_strSex;
                    dr["AGE"] = vo.m_strAge;
                    dr["AREA"] = vo.m_strArea;
                    dr["BEDNO"] = vo.m_strBedNO;
                    dr["TEL"] = vo.m_strTel;
                    dr["ADDRESS"] = vo.m_strAddress;
                    dr["SUMMARY"] = vo.m_strSummary;
                    dr["DIAGNOSE"] = vo.m_strDiagnose;
                    dr["DOCTORNAME"] = vo.m_strDoctorName;
                    dr["DOCTORNO"] = vo.m_strDoctorNO;
                    dr["EXTRANO"] = vo.m_strExtraNO;
                    dr["CARDNO"] = vo.m_strCardNO;
                    dr["DEPARTMENT"] = vo.m_strDepartment;
                    dr["CHARGEDETAIL"] = checks[i].m_strChargeDetail;
                    dr["FINISHDATE"] = null;
                    //					dr["FINISHDATE"]	= vo.m_datFinishDate;
                    dr["APPLYDATE"] = vo.m_datApplyDate;
                    dr["Deleted"] = 0;

                    dr["ApplyTitle"] = checks[i].m_strTypeName + "申请单";
                    dr["DIAGNOSEAIM"] = (checks[i].m_strCheckAim == "") ? "协助诊断" : checks[i].m_strCheckAim;
                    dr["DIAGNOSEPART"] = checks[i].m_strCheckPart;
                    dr["ApplyID"] = nextID.ToString();
                    dr["TypeID"] = int.Parse(checks[i].m_strTypeID);

                    dr["DEPTID_CHR"] = vo.m_strDeptID;
                    dr["AREAID_CHR"] = vo.m_strAreaID;
                    dr["DOCTORID_CHR"] = vo.m_strDoctorID;
                    dr["CHARGESTATUS_INT"] = vo.m_intChargeStatus;//繳費
                    dr["SUBMITTED"] = vo.m_intSubmitted;

                    checks[i].m_strApplyID = nextID.ToString();
                    long lngRes = m_lngSetCommon_Apply(dr, "1");
                    if (lngRes < 0)
                    {
                        MessageBox.Show("保存数据到数据库时出错！");
                        return null;
                    }
                    ds.Rows.Add(dr);

                    nextID++;
                }

                //				if (dp.Update("AR_COMMON_APPLY",ds))
                //				{
                ////					update ok
                //				}

                //SaveAttachRelation(vo, checks);
            }
            catch { }

            return checks;
        }

        private long m_lngSetCommon_Apply(DataRow dr, string strSqlType)
        {


            long lngEff = 0;
            //long lngRes = m_objHRPService.lngExecuteParameterSQL(strSQLSet,ref lngEff,objDPArr);
            com.digitalwave.GLS_WS.ApplyReportServer.clsApplyReportServer objSvc =
             (com.digitalwave.GLS_WS.ApplyReportServer.clsApplyReportServer)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.GLS_WS.ApplyReportServer.clsApplyReportServer));
            DataTable m_dtData = dr.Table;
            DataRow row1 = m_dtData.NewRow();
            for (int i = 0; i < m_dtData.Columns.Count; i++)
            {

                row1[i] = dr[i];

            }
            m_dtData.Rows.Add(row1);
            long lngRes = objSvc.m_lngSetCommon_Apply(m_dtData, strSqlType);
            return lngRes;
        }

        /// <summary>
        /// 根据VO保存信息，并返回申请单ID
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public clsCheckType GetIDWithVO(clsApplyRecord vo)
        {

            clsCheckType check = new clsCheckType();
            //try
            //{
            string strDiagnosePart = "";
            string sql = @"select applyid, reportid, deposit, balance, applydate, checkno, clinicno,
                                       bihno, name, sex, age, department, area, bedno, tel, address, summary,
                                       diagnose, diagnosepart, diagnoseaim, doctorname, doctorno, finishdate,
                                       chargedetail, extrano, cardno, deleted, whodeletes, deleteddate,
                                       applytitle, typeid, submitted, chargestatus_int, deptid_chr,
                                       areaid_chr, doctorid_chr, status_int
                                  from ar_common_apply
                                 where 1 = 2";

            #region 根据typeID获取检查部位
            //			string strSQLDiagnosePart = @"select PARTNAME from AR_APPLY_PARTLIST  "+
            //											"where Deleted != 1 and typeid="+vo.m_strTypeID+" order by PartID";
            //
            //			DataSet dsRecord = dp.SqlSelect(strSQLDiagnosePart);
            //			DataTable dtRecord  = dsRecord.Tables[0];
            //			if(dtRecord != null || dtRecord.Rows.Count>0)
            //			{
            //				for(int i=0;i<dtRecord.Rows.Count;i++)
            //				{
            //					if(i == dtRecord.Rows.Count-1)
            //					{
            //						strDiagnosePart += dtRecord.Rows[i]["EmployeeID"].ToString();
            //					}
            //					else
            //					{
            //						strDiagnosePart += dtRecord.Rows[i]["EmployeeID"].ToString() + ",";
            //					}
            //				}
            //			}
            #endregion
            DataTable ds = dp.SqlSelect(sql);
            DataRow dr;



            DataRow[] newRow = new DataRow[1];

            //int nextID = int.Parse( dp.GetNextID("AR_COMMON_APPLY","ApplyID") );
            int nextID = int.Parse(dp.GetApplyID());
            #region 根据TypeID获取申请单标题
            string strApplyTypeID = vo.m_strTypeID;
            string strApplyTitle = "";
            string strSQLGetApplyTitle = @"select TYPETEXT from ar_apply_typelist where TYPEID='" + strApplyTypeID + "'";
            DataTable dsRecord = dp.SqlSelect(strSQLGetApplyTitle);
            DataTable dtRecord = dsRecord;
            if (dtRecord != null || dtRecord.Rows.Count == 1)
            {
                strApplyTitle = dtRecord.Rows[0]["TYPETEXT"].ToString();
            }
            #endregion
            //			for (int i=0;i<checks.Length; i++)
            //			{
            newRow[0] = ds.NewRow();
            dr = newRow[0];

            dr["DEPOSIT"] = vo.m_strDeposit;
            dr["BALANCE"] = vo.m_strBalance;
            dr["CHECKNO"] = vo.m_strCheckNO;
            dr["CLINICNO"] = vo.m_strClinicNO;
            dr["BIHNO"] = vo.m_strBIHNO;
            dr["NAME"] = vo.m_strName;
            dr["SEX"] = vo.m_strSex;
            dr["AGE"] = vo.m_strAge;
            dr["AREA"] = vo.m_strArea;
            dr["BEDNO"] = vo.m_strBedNO;
            dr["TEL"] = vo.m_strTel;
            dr["ADDRESS"] = vo.m_strAddress;
            dr["SUMMARY"] = vo.m_strSummary;
            dr["DIAGNOSE"] = vo.m_strDiagnose;
            dr["DOCTORNAME"] = vo.m_strDoctorName;
            dr["DOCTORNO"] = vo.m_strDoctorNO;
            dr["EXTRANO"] = vo.m_strExtraNO;
            dr["CARDNO"] = vo.m_strCardNO;
            dr["DEPARTMENT"] = vo.m_strDepartment;
            dr["CHARGEDETAIL"] = GetChargeInfo(vo);
            dr["FINISHDATE"] = vo.m_datFinishDate;
            dr["APPLYDATE"] = vo.m_datApplyDate;
            dr["Deleted"] = 0;

            dr["ApplyTitle"] = strApplyTitle + "申请单";
            dr["DIAGNOSEAIM"] = (vo.m_strDiagnoseAim == "") ? "协助诊断" : vo.m_strDiagnoseAim;
            dr["DIAGNOSEPART"] = vo.m_strDiagnosePart;
            dr["ApplyID"] = nextID.ToString();
            dr["TypeID"] = vo.m_strTypeID;

            dr["DEPTID_CHR"] = vo.m_strDeptID;
            dr["AREAID_CHR"] = vo.m_strAreaID;
            dr["DOCTORID_CHR"] = vo.m_strDoctorID;
            dr["CHARGESTATUS_INT"] = vo.m_intChargeStatus;//繳費
            dr["SUBMITTED"] = vo.m_intSubmitted;


            check.m_strApplyID = nextID.ToString();
            check.m_strChargeDetail = vo.m_strChargeDetail;
            check.m_strCheckAim = vo.m_strDiagnoseAim;
            check.m_strCheckPart = vo.m_strDiagnosePart;
            check.m_strTypeID = vo.m_strTypeID;

            ds.Rows.Add(dr);
            nextID++;
            //			}

            long lngRes = m_lngSetCommon_Apply(dr, "1");
            if (lngRes < 0)
            {
                MessageBox.Show("保存失败！");
                return null;
            }
            //SaveAttachRelation(vo, checks);
            //}
            //catch{}

            return check;
        }

        /// <summary>
        /// 根据VO[]保存信息，并返回申请单ID
        /// </summary>
        /// <param name="vo"></param>
        /// <param name="p_hasAPPLYRLT">TypeID 对应 ATTACHTYPE_INT</param>
        /// <returns></returns>
        public clsCheckType[] opGetIDWithVO(clsApplyRecord[] vo, System.Collections.Hashtable p_hasAPPLYRLT)
        {
            System.Collections.Generic.Dictionary<string, clsApplyRecord> dict = new System.Collections.Generic.Dictionary<string, clsApplyRecord>(p_hasAPPLYRLT.Count);
            System.Collections.Generic.List<clsCheckType> objCheckType = new System.Collections.Generic.List<clsCheckType>(vo.Length);

            foreach (Object obj in p_hasAPPLYRLT.Values)
            {
                dict.Add(obj.ToString(), null);
            }

            int n = vo.Length;
            clsCheckType objType;

            #region 根据TypeID获取申请单标题
            string strApplyTypeID;
            string strApplyTitle = "";

            #endregion

            com.digitalwave.GLS_WS.ApplyReportServer.DataProcess objSvc2 =
(com.digitalwave.GLS_WS.ApplyReportServer.DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.GLS_WS.ApplyReportServer.DataProcess));

            for (int i1 = 0; i1 < n; i1++)
            {
                if (dict[p_hasAPPLYRLT[vo[i1].m_strTypeID].ToString()] == null)
                {
                    dict[p_hasAPPLYRLT[vo[i1].m_strTypeID].ToString()] = vo[i1];
                    dict[p_hasAPPLYRLT[vo[i1].m_strTypeID].ToString()].m_strApplyID = objSvc2.GetApplyID();

                    dict[p_hasAPPLYRLT[vo[i1].m_strTypeID].ToString()].m_strChargeDetail = GetChargeInfo(vo[i1]);
                }
                else
                {
                    dict[p_hasAPPLYRLT[vo[i1].m_strTypeID].ToString()].m_strChargeDetail += System.Environment.NewLine + GetChargeInfo(vo[i1]);
                    dict[p_hasAPPLYRLT[vo[i1].m_strTypeID].ToString()].m_strDiagnosePart += clsApplyForm.strSeparate + vo[i1].m_strDiagnosePart;
                }

                objType = new clsCheckType();
                objType.m_strApplyID = dict[p_hasAPPLYRLT[vo[i1].m_strTypeID].ToString()].m_strApplyID;
                objType.m_strChargeDetail = vo[i1].m_strChargeDetail;
                objType.m_strCheckAim = vo[i1].m_strDiagnoseAim;
                objType.m_strCheckPart = vo[i1].m_strDiagnosePart;
                objType.m_strTypeID = vo[i1].m_strTypeID;
                objType.objItem_VO = new clsChargeItem_VO();
                objType.objItem_VO.m_strItemID = vo[i1].m_objChargeItem.m_strItemID;
                objCheckType.Add(objType);

            }
            com.digitalwave.GLS_WS.ApplyReportServer.clsApplyReportServer objSvc =
 (com.digitalwave.GLS_WS.ApplyReportServer.clsApplyReportServer)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.GLS_WS.ApplyReportServer.clsApplyReportServer));

            clsApplyRecord[] objApply = new clsApplyRecord[dict.Keys.Count];
            n = 0;
            foreach (clsApplyRecord objDict in dict.Values)
            {
                objApply[n] = objDict;
                strApplyTypeID = objApply[n].m_strTypeID;
                string strSQLGetApplyTitle = @"select TYPETEXT from ar_apply_typelist where TYPEID='" + strApplyTypeID + "'";
                DataTable dsRecord = dp.SqlSelect(strSQLGetApplyTitle);
                DataTable dtRecord = dsRecord;
                if (dtRecord != null || dtRecord.Rows.Count == 1)
                {
                    strApplyTitle = dtRecord.Rows[0]["TYPETEXT"].ToString() + "申请单";
                }
                objApply[n].m_strApplyTitle = strApplyTitle;
                n++;
            }
            dict = null;



            long l = objSvc.m_lngAddCommonApply(objApply);
            objSvc.Dispose();
            if (l < 0)
            {
                MessageBox.Show("保存失败！");
                return null;
            }
            return objCheckType.ToArray();
        }

        /// <summary>
        /// 根据VO保存信息，并返回申请单ID
        /// </summary>
        /// <param name="vo"></param>
        /// <returns></returns>
        public clsCheckType[] GetIDWithVO(clsApplyRecord[] vo)
        {
            if (vo == null || vo.Length < 1)
            {
                return null;
            }
            clsCheckType[] check = new clsCheckType[vo.Length];

            string sql = @"select applyid, reportid, deposit, balance, applydate, checkno, clinicno,
                                       bihno, name, sex, age, department, area, bedno, tel, address, summary,
                                       diagnose, diagnosepart, diagnoseaim, doctorname, doctorno, finishdate,
                                       chargedetail, extrano, cardno, deleted, whodeletes, deleteddate,
                                       applytitle, typeid, submitted, chargestatus_int, deptid_chr,
                                       areaid_chr, doctorid_chr, status_int
                                  from ar_common_apply
                                 where 1 = 2";
            DataTable ds = dp.SqlSelect(sql);

            DataRow dr;

            DataRow[] newRow = new DataRow[1];

            int nextID = int.Parse(dp.GetApplyID());
            #region 根据TypeID获取申请单标题
            string strApplyTypeID = vo[0].m_strTypeID;
            string strApplyTitle = "";
            string strSQLGetApplyTitle = @"select TYPETEXT from ar_apply_typelist where TYPEID='" + strApplyTypeID + "'";
            DataTable dsRecord = dp.SqlSelect(strSQLGetApplyTitle);
            DataTable dtRecord = dsRecord;
            if (dtRecord != null || dtRecord.Rows.Count == 1)
            {
                strApplyTitle = dtRecord.Rows[0]["TYPETEXT"].ToString();
            }
            #endregion

            newRow[0] = ds.NewRow();
            dr = newRow[0];
            dr["DEPOSIT"] = vo[0].m_strDeposit;
            dr["BALANCE"] = vo[0].m_strBalance;
            dr["CHECKNO"] = vo[0].m_strCheckNO;
            dr["CLINICNO"] = vo[0].m_strClinicNO;
            dr["BIHNO"] = vo[0].m_strBIHNO;
            dr["NAME"] = vo[0].m_strName;
            dr["SEX"] = vo[0].m_strSex;
            dr["AGE"] = vo[0].m_strAge;
            dr["AREA"] = vo[0].m_strArea;
            dr["BEDNO"] = vo[0].m_strBedNO;
            dr["TEL"] = vo[0].m_strTel;
            dr["ADDRESS"] = vo[0].m_strAddress;
            dr["SUMMARY"] = vo[0].m_strSummary;
            dr["DIAGNOSE"] = vo[0].m_strDiagnose;
            dr["DOCTORNAME"] = vo[0].m_strDoctorName;
            dr["DOCTORNO"] = vo[0].m_strDoctorNO;
            dr["EXTRANO"] = vo[0].m_strExtraNO;
            dr["CARDNO"] = vo[0].m_strCardNO;
            dr["DEPARTMENT"] = vo[0].m_strDepartment;
            dr["FINISHDATE"] = vo[0].m_datFinishDate;
            dr["APPLYDATE"] = vo[0].m_datApplyDate;
            dr["Deleted"] = 0;

            dr["ApplyTitle"] = strApplyTitle + "申请单";
            dr["DIAGNOSEAIM"] = (vo[0].m_strDiagnoseAim == "") ? "协助诊断" : vo[0].m_strDiagnoseAim;

            dr["ApplyID"] = nextID.ToString();
            dr["TypeID"] = vo[0].m_strTypeID;

            dr["DEPTID_CHR"] = vo[0].m_strDeptID;
            dr["AREAID_CHR"] = vo[0].m_strAreaID;
            dr["DOCTORID_CHR"] = vo[0].m_strDoctorID;
            dr["CHARGESTATUS_INT"] = vo[0].m_intChargeStatus;//繳費
            dr["SUBMITTED"] = vo[0].m_intSubmitted;

            StringBuilder strChargeDetail = new StringBuilder();
            StringBuilder strDiagnosePart = new StringBuilder();

            for (int i = 0; i < vo.Length; i++)
            {
                strChargeDetail.Append(GetChargeInfo(vo[i])).Append(System.Environment.NewLine);
                strDiagnosePart.Append(vo[i].m_strDiagnosePart).Append(clsApplyForm.strSeparate);
                check[i] = new clsCheckType();
                check[i].m_strApplyID = nextID.ToString();
                check[i].m_strChargeDetail = vo[i].m_strChargeDetail;
                check[i].m_strCheckAim = vo[i].m_strDiagnoseAim;
                check[i].m_strCheckPart = vo[i].m_strDiagnosePart;
                check[i].m_strTypeID = vo[i].m_strTypeID;
                check[i].objItem_VO = new clsChargeItem_VO();
                check[i].objItem_VO.m_strItemID = vo[i].m_objChargeItem.m_strItemID;
            }
            dr["CHARGEDETAIL"] = strChargeDetail.ToString();
            dr["DIAGNOSEPART"] = strDiagnosePart.ToString();
            ds.Rows.Add(dr);

            long lngRes = m_lngSetCommon_Apply(dr, "1");
            if (lngRes < 0)
            {
                MessageBox.Show("保存失败！");
                return null;
            }

            return check;
        }




        /// <summary>
        /// 删除相应单据
        /// </summary>
        /// <param name="applyID"></param>
        public bool Delete(string applyID)
        {
            string deletedBy = "";
            string deletedDate = DateTime.Now.ToString();
            if (this.loginInfo != null)
            {
                deletedBy = this.loginInfo.m_strEmpID;
            }
            string sql = "update AR_COMMON_APPLY set Deleted = 1,WHODELETES = '{0}',DeletedDate = to_date('{1}','yyyy.mm.dd hh24:mi:ss') where ApplyID = {2}";
            return dp.SqlExecute(string.Format(sql, deletedBy, deletedDate, applyID));
        }


        public void PrintPreview()
        {
            string id = applyID;
            FormPrinter formPrint = new FormPrinter();
            formPrint.PrintPreview(this.GetChange());
            applyID = id;
        }

        //直接打印
        public void Print()
        {
            string id = this.applyID;
            FormPrinter formPrint = new FormPrinter();
            formPrint.Print(this.GetChange());
            this.applyID = id;
        }

        /// <summary>
        /// 保存检查单,返回单号列表.null时,表示保存被取消
        /// </summary>
        public clsCheckType[] Save()
        {
            clsCheckType[] checkTypes = null;
            DataTable ds = null;
            bool isNew = (this.applyID == null);

            //新建状态，弹出选择检查类型对话框
            if (isNew)
            {
                if (this.applyTypeID == "" || this.applyTypeID == null)
                {
                    checkTypes = frmSelectType.ShowSelect();
                }
                else
                {
                    //已指定检查单类型

                    if (frmUI.ShowPrompt("您确定要保存并发送吗？") != DialogResult.Yes)
                    {
                        return null;
                    }

                    checkTypes = new clsCheckType[1];
                    checkTypes[0] = new clsCheckType();
                    checkTypes[0].m_strTypeID = this.applyTypeID;
                    checkTypes[0].m_strCheckPart = frmUI.GetControl("cbDIAGNOSEPART").Text;
                    checkTypes[0].m_strCheckAim = frmUI.GetControl("cbDIAGNOSEAIM").Text;
                    checkTypes[0].m_strTypeName = frmUI.GetControl("lblTitle").Text.Replace("申请单", "");
                }

                if (checkTypes == null)
                {
                    return null;
                }
            }
            else
            {
                checkTypes = new clsCheckType[1];
                checkTypes[0] = new clsCheckType();
                checkTypes[0].m_strApplyID = this.applyID;
                checkTypes[0].m_strTypeID = this.applyTypeID;
            }

            if (!this.isChanged)
            {
                return checkTypes;
            }

            if (isNew)
            {
                bool success = true;
                //保存每一个新建的
                int i = 0;
                foreach (clsCheckType c in checkTypes)
                {
                    this.applyID = null;
                    ds = this.GetChange();
                    checkTypes[i].m_strApplyID = this.applyID;
                    ds.Rows[0]["ApplyTitle"] = c.m_strTypeName + "申请单";
                    ds.Rows[0]["DIAGNOSEPART"] = c.m_strCheckPart;
                    ds.Rows[0]["DIAGNOSEAIM"] = (c.m_strCheckAim == "") ? "协助诊断" : c.m_strCheckAim;
                    ds.Rows[0]["TypeID"] = int.Parse(c.m_strTypeID);

                    try
                    {
                        long lngRes = m_lngSetCommon_Apply(ds.Rows[0], "1");
                        if (lngRes < 0)
                        {
                            success = false;
                            break;
                        }
                    }
                    catch { }

                    i++;
                }

                if (success)
                {
                    //frmUI.ShowInfo("所有单据保存成功！");	
                    this.isChanged = false;
                    frmUI.Dispose();
                }
            }
            else
            {
                //保存当前编辑单据
                ds = this.GetChange();
                long lngRes = m_lngSetCommon_Apply(ds.Rows[0], "2");
                if (lngRes > 0)
                {
                    this.isChanged = false;
                    //frmUI.ShowInfo("保存成功！");
                }
            }

            if (!(this.applyTypeID == "" || this.applyTypeID == null))
            {
                if (this.currentVO != null)
                {
                    SaveAttachRelation(this.currentVO, checkTypes);
                }
                else
                {
                    clsDataQuery objDQ = new clsDataQuery();
                    clsApplyRecord objComVO = objDQ.objGetVO(applyID);
                    SaveAttachRelation(objComVO, checkTypes);
                }
            }

            return checkTypes;
        }


        /// <summary>
        /// 取得当前操作的数据集
        /// </summary>
        /// <returns></returns>
        public DataTable GetChange()
        {
            bool isNew = (this.applyID == null);
            string sql;
            DataRow dr;
            DataTable ds = new DataTable();

            try
            {
                if (isNew)
                {
                    sql = @"select applyid, reportid, deposit, balance, applydate, checkno, clinicno,
                                   bihno, name, sex, age, department, area, bedno, tel, address, summary,
                                   diagnose, diagnosepart, diagnoseaim, doctorname, doctorno, finishdate,
                                   chargedetail, extrano, cardno, deleted, whodeletes, deleteddate,
                                   applytitle, typeid, submitted, chargestatus_int, deptid_chr,
                                   areaid_chr, doctorid_chr, status_int
                              from ar_common_apply
                             where 1 = 2";
                }
                else
                {
                    sql = @"select applyid, reportid, deposit, balance, applydate, checkno, clinicno,
                                   bihno, name, sex, age, department, area, bedno, tel, address, summary,
                                   diagnose, diagnosepart, diagnoseaim, doctorname, doctorno, finishdate,
                                   chargedetail, extrano, cardno, deleted, whodeletes, deleteddate,
                                   applytitle, typeid, submitted, chargestatus_int, deptid_chr,
                                   areaid_chr, doctorid_chr, status_int
                              from AR_COMMON_APPLY where ApplyID =" + this.applyID; ;
                }

                ds = dp.SqlSelect(sql);

                if (isNew)
                {
                    //new 
                    applyID = dp.GetNextID("AR_COMMON_APPLY", "ApplyID");
                    dr = ds.NewRow();
                }
                else
                {
                    //edit
                    dr = ds.Rows[0];
                }

                dr["APPLYID"] = this.applyID;
                dr["ApplyTitle"] = frmUI.FindControl("lblTitle").Text;
                dr["DEPOSIT"] = frmUI.FindControl("txtDEPOSIT").Text;
                dr["BALANCE"] = frmUI.FindControl("txtBALANCE").Text;
                dr["APPLYDATE"] = (frmUI.FindControl("dpAPPLYDATE") as DateTimePicker).Value;
                dr["CHECKNO"] = frmUI.FindControl("txtCHECKNO").Text;
                dr["CLINICNO"] = frmUI.FindControl("txtCLINICNO").Text;
                dr["BIHNO"] = frmUI.FindControl("txtBIHNO").Text;
                dr["NAME"] = frmUI.FindControl("txtNAME").Text;
                dr["SEX"] = frmUI.FindControl("cbSEX").Text;
                dr["AGE"] = frmUI.FindControl("txtAGE").Text;
                dr["DEPARTMENT"] = frmUI.FindControl("cbDEPARTMENT").Text;
                dr["AREA"] = frmUI.FindControl("cbAREA").Text;
                dr["BEDNO"] = frmUI.FindControl("txtBEDNO").Text;
                dr["TEL"] = frmUI.FindControl("txtTEL").Text;
                dr["ADDRESS"] = frmUI.FindControl("txtADDRESS").Text;
                dr["SUMMARY"] = frmUI.FindControl("txtSUMMARY").Text;
                dr["DIAGNOSE"] = frmUI.FindControl("txtDIAGNOSE").Text;
                dr["DIAGNOSEPART"] = frmUI.FindControl("cbDIAGNOSEPART").Text;
                dr["DIAGNOSEAIM"] = frmUI.FindControl("cbDIAGNOSEAIM").Text;
                dr["DOCTORNAME"] = frmUI.FindControl("txtDOCTORNAME").Text;
                dr["DOCTORNO"] = frmUI.FindControl("txtDOCTORNO").Text;
                //				dr["FINISHDATE"]   = (frmUI.FindControl("txtFINISHDATE") as DateTimePicker).Value;
                dr["FINISHDATE"] = new DateTime(1900, 1, 1);
                dr["CHARGEDETAIL"] = frmUI.FindControl("txtCHARGEDETAIL").Text;
                dr["EXTRANO"] = frmUI.FindControl("txtEXTRANO").Text;
                dr["CARDNO"] = frmUI.FindControl("txtCARDNO").Text;
                dr["DELETED"] = 0;
                dr["TypeID"] = (this.applyTypeID == "") ? -1 : int.Parse(this.applyTypeID);

                //调用OpenWithVO或SaveWithVO
                if (this.currentVO != null)
                {
                    dr["DEPTID_CHR"] = this.currentVO.m_strDeptID;
                    dr["AREAID_CHR"] = this.currentVO.m_strAreaID;
                    dr["DOCTORID_CHR"] = this.currentVO.m_strDoctorID;
                    dr["CHARGESTATUS_INT"] = this.currentVO.m_intChargeStatus;
                    dr["SUBMITTED"] = this.currentVO.m_intSubmitted;
                }
                else if (isNew)	//调用OpenForm(null)新建单据
                {
                    dr["CHARGESTATUS_INT"] = 1;	//未繳費
                }

                if (isNew)
                {
                    ds.Rows.Add(dr);
                }

            }
            catch { }
            return ds;
        }


        /// <summary>
        /// 提交当前检查单
        /// </summary>
        public void Submit()
        {
            if (this.applyID == null)
            {
                return;
            }

            if (DialogResult.Yes != frmUI.ShowPrompt("你确认要提交吗?提交后将不能修改!"))
            {
                return;
            }

            string sql = "update AR_COMMON_APPLY set Submitted = 1 where ApplyID = " + this.applyID;

            if (dp.SqlExecute(sql))
            {
                frmUI.GetControl("btnSave").Enabled = false;
                frmUI.GetControl("btnSubmit").Enabled = false;
                DisableControls();
            }
        }

        /// <summary>
        /// 监测每个可编辑控件是否被改动
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        bool MonitorChange(Control c)
        {
            if ((c is TextBox) || (c is ComboBox) || (c is DateTimePicker))
            {
                c.TextChanged += new EventHandler(c_TextChanged);
            }
            return false;
        }


        private void c_TextChanged(object sender, EventArgs e)
        {
            this.isChanged = true;
        }

        void DisableControls()
        {
            Type type = frmUI.GetType();
            BindingFlags flags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.NonPublic |
                BindingFlags.Public;

            FieldInfo[] fields = type.GetFields(flags);
            foreach (FieldInfo f in fields)
            {
                object obj = f.GetValue(frmUI);
                if (obj is TextBox) (obj as TextBox).ReadOnly = true;
                if ((obj is DateTimePicker) ||
                    (obj is ComboBox))
                {
                    (obj as Control).Enabled = false;
                }


            }
        }

        private void ShowReportMenu(string typeID)
        {
            ContextMenu cm = (ContextMenu)frmUI.GetObject("cmReport");
            cm.MenuItems.Clear();

            if (typeID == "" || typeID == null)
            {
                return;
            }

            DataTable ds = dp.GetReportForm(typeID);

            foreach (DataRow dr in ds.Rows)
            {
                Logic.clsMenuItem mi = new Logic.clsMenuItem(dr["FormTitle"].ToString());
                mi.Tag = dr["FormName"].ToString();
                mi.Click += new EventHandler(mi_Click);
                cm.MenuItems.Add((MenuItem)mi);
            }
        }

        private void mi_Click(object sender, EventArgs e)
        {
            string typeName = "com.digitalwave.GLS_WS." + (sender as Logic.clsMenuItem).Tag.ToString();
            //下面调用相应的报告
            try
            {
                clsDataQuery objDQ = new clsDataQuery();
                clsApplyRecord objComVO = null;
                if (applyID != null)
                {
                    objComVO = objDQ.objGetVO(applyID);
                }
                if (objComVO == null)
                    return;
                clsTransApply_VOToReport_VO objTAR = new clsTransApply_VOToReport_VO(objComVO);
                iCareData.clsApplyReport_T_VO p_ApplyReport_T_VO = objTAR.objReport_T_VO();

                Assembly asbGLS = Assembly.LoadFrom(Application.StartupPath + "\\" + "GLS_WorkStation.dll");
                Object objForm = asbGLS.CreateInstance(typeName, false, BindingFlags.Public | BindingFlags.Instance, null, new object[] { p_ApplyReport_T_VO }, null, null);
                ((Form)objForm).Show();
            }
            catch { }
        }

        /// <summary>
        /// 格式化收费信息为文本
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private string GetChargeInfo(clsApplyRecord vo)
        {
            //			string fee = "数量：{0}    单位：{1}    项目名称：{2}    规格：{3}    单价：{4}   总价：{5}     收费比例：{6}";
            string fee = "{0}  {1}  {2}{3}  {4}元  {5}%";

            return string.Format(fee,
                vo.m_objChargeItem.m_strItemName,
                vo.m_objChargeItem.m_strSpec,
                vo.m_objChargeItem.m_decQty,
                vo.m_objChargeItem.m_strUnit,
                vo.m_objChargeItem.m_decTolPrice,
                vo.m_objChargeItem.m_decDiscount);

            //			return string.Format(fee, vo.m_objChargeItem.m_decQty,
            //									  vo.m_objChargeItem.m_strUnit,
            //									  vo.m_objChargeItem.m_strItemName,
            //									  vo.m_objChargeItem.m_strSpec,									 
            //									  vo.m_objChargeItem.m_decPrice,
            //									  vo.m_objChargeItem.m_decTolPrice,
            //									  vo.m_objChargeItem.m_decDiscount);

        }

        /// <summary>
        /// 保存关系关系到：T_OPR_ATTACHRELATION
        /// </summary>
        /// <param name="rs"></param>
        /// <param name="selTypes"></param>
        /// <returns></returns>
        private bool SaveAttachRelation(clsApplyRecord rs, clsCheckType[] selTypes)
        {
            bool blnExcResult = false;
            string strMaxID = "";
            string sqlGetID = @"SELECT Max(attarelaid_chr) FROM t_opr_attachrelation";
            try
            {
                DataTable id = dp.ExecuteScalar(sqlGetID);
                if (id is DBNull) strMaxID = "0";
                else strMaxID = id.Rows[0]["Max(attarelaid_chr)"].ToString();
                int nextID = int.Parse(strMaxID) + 1;

                string insertSql = @"INSERT INTO T_OPR_ATTACHRELATION
						       ( ATTARELAID_CHR , SYSFROM_INT , ATTACHTYPE_INT , SOURCEITEMID_VCHR , ATTACHID_VCHR )
								VALUES
								('{0}', {1}, {2}, '{3}', '{4}')";

                clsCheckType ck = selTypes[0];
                string sql = string.Format(insertSql, nextID.ToString().PadLeft(12, '0'),
                    rs.m_objAttachRelation.m_intSysFrom,
                    ck.m_strTypeID,
                    rs.m_objAttachRelation.m_strSourceItemID,
                    ck.m_strApplyID);
                blnExcResult = dp.SqlExecute(sql);
            }
            catch { }
            return blnExcResult;
        }

        /// <summary>
        /// 不保存直接打印或预览相应检查申请单
        /// </summary>
        /// <param name="vo"></param>
        public DataTable dsPrintVO(clsApplyRecord vo)
        {
            string sql = @"select applyid, reportid, deposit, balance, applydate, checkno, clinicno,
                                   bihno, name, sex, age, department, area, bedno, tel, address, summary,
                                   diagnose, diagnosepart, diagnoseaim, doctorname, doctorno, finishdate,
                                   chargedetail, extrano, cardno, deleted, whodeletes, deleteddate,
                                   applytitle, typeid, submitted, chargestatus_int, deptid_chr,
                                   areaid_chr, doctorid_chr, status_int
                              from ar_common_apply
                             where 1 = 2";

            DataTable ds = dp.SqlSelect(sql);
            DataRow dr;
            clsCheckType[] checks = frmSeTy.SelectType();

            if (checks == null)
            {
                return null;
            }

            DataRow[] newRows = new DataRow[checks.Length];

            try
            {
                int nextID = int.Parse(dp.GetNextID("AR_COMMON_APPLY", "ApplyID"));

                for (int i = 0; i < checks.Length; i++)
                {
                    newRows[i] = ds.NewRow();
                    dr = newRows[i];

                    dr["DEPOSIT"] = vo.m_strDeposit;
                    dr["BALANCE"] = vo.m_strBalance;
                    dr["CHECKNO"] = vo.m_strCheckNO;
                    dr["CLINICNO"] = vo.m_strClinicNO;
                    dr["BIHNO"] = vo.m_strBIHNO;
                    dr["NAME"] = vo.m_strName;
                    dr["SEX"] = vo.m_strSex;
                    dr["AGE"] = vo.m_strAge;
                    dr["AREA"] = vo.m_strArea;
                    dr["BEDNO"] = vo.m_strBedNO;
                    dr["TEL"] = vo.m_strTel;
                    dr["ADDRESS"] = vo.m_strAddress;
                    dr["SUMMARY"] = vo.m_strSummary;
                    dr["DIAGNOSE"] = vo.m_strDiagnose;
                    dr["DOCTORNAME"] = vo.m_strDoctorName;
                    dr["DOCTORNO"] = vo.m_strDoctorNO;
                    dr["EXTRANO"] = vo.m_strExtraNO;
                    dr["CARDNO"] = vo.m_strCardNO;
                    dr["DEPARTMENT"] = vo.m_strDepartment;
                    dr["CHARGEDETAIL"] = checks[i].m_strChargeDetail/*vo.m_strChargeDetail*/;
                    dr["FINISHDATE"] = vo.m_datFinishDate;
                    dr["APPLYDATE"] = vo.m_datApplyDate;
                    dr["Deleted"] = 0;

                    dr["ApplyTitle"] = checks[i].m_strTypeName + "申请单";
                    dr["DIAGNOSEAIM"] = (checks[i].m_strCheckAim == "") ? "协助诊断" : checks[i].m_strCheckAim;
                    dr["DIAGNOSEPART"] = checks[i].m_strCheckPart;
                    dr["ApplyID"] = nextID.ToString();
                    dr["TypeID"] = int.Parse(checks[i].m_strTypeID);

                    dr["DEPTID_CHR"] = vo.m_strDeptID;
                    dr["AREAID_CHR"] = vo.m_strAreaID;
                    dr["DOCTORID_CHR"] = vo.m_strDoctorID;
                    dr["CHARGESTATUS_INT"] = vo.m_intChargeStatus;//繳費
                    dr["SUBMITTED"] = vo.m_intSubmitted;


                    checks[i].m_strApplyID = nextID.ToString();
                    ds.Rows.Add(dr);

                    nextID++;
                }
            }
            catch { }
            return ds;
        }

    }
}
