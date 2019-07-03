using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;
using System.Diagnostics;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// 打印报表类(医技和门诊打印也会调用)
    /// </summary>
    public class clsPrintReport
    {
        #region initalParameter
        public PrintDocument m_printDoc;
        public PrintPreviewDialog m_printPrev;
        public PrintDialog m_printDlg;
        private clsPrintValuePara m_objPrintInfo;
        private infPrintRecord m_objPrintTool;
        private DataStore dsReport; //baojian.mo (2007.11.26)add for 茶山五分类报表 
        private string m_strReportGroupID;
        private bool blnPrintView = false;

        private bool m_blnPrintWithDialog = false;
        public bool m_BlnPrintWithDialog
        {
            get { return this.m_blnPrintWithDialog; }
            set { this.m_blnPrintWithDialog = value; }
        }
        public clsPrintValuePara m_ObjPrintInfo
        {
            get { return this.m_objPrintInfo; }
            set
            {
                this.m_objPrintInfo = value;
                /*-----------------------------------*/
                //过滤项目根据条件(值为"\"的)
                /*-----------------------------------*/
                if (this.m_objPrintInfo != null && this.m_objPrintInfo.m_dtbResult != null)
                {
                    int i = 0;
                    while (i < this.m_objPrintInfo.m_dtbResult.Rows.Count)
                    {
                        DataRow dr = this.m_objPrintInfo.m_dtbResult.Rows[i];
                        if (dr["result_vchr"].ToString() == "\\")
                        {
                            this.m_objPrintInfo.m_dtbResult.Rows.Remove(dr);
                            continue;
                        }
                        i++;
                    }
                }
                string strFlag = null;
                long lngRes = m_lngGetCollocate(out strFlag, "4030");
                //if (this.m_strReportGroupID == "000005") //baojian.mo 新增DataWindow报表
                //{
                //    dsReport = new DataStore();
                //    this.m_mthLoadDWReport(dsReport, "d_opr_lis_resultofwfn", strFlag);
                //}
                // if (this.m_strReportGroupID == "000006")
                //{
                //    dsReport = new DataStore();
                //    this.m_mthLoadDWReport(dsReport, "d_opr_lis_resultofwjh", strFlag);
                //}
                //else
                //{
                this.m_mthSetPrintTool(strFlag);
                //}
            }
        }
        #endregion

        #region 构造函数
        public clsPrintReport()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_mthInit();
        }
        public clsPrintReport(string p_strReportGroupID, string p_strApplID, bool p_blnConfirmed)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_mthInit();
            m_mthGetPrintContentFromDB(p_strReportGroupID, p_strApplID, p_blnConfirmed);
            string strParmValue = null;
            long lngRes = m_lngGetCollocate(out strParmValue, "4030");
            m_mthSetPrintTool(strParmValue);
        }
        #endregion

        #region Init
        private void m_mthInit()
        {
            m_printDoc = new PrintDocument();
            m_printDoc.PrintPage += new PrintPageEventHandler(m_printDoc_PrintPage);
            m_printDoc.BeginPrint += new PrintEventHandler(m_printDoc_BeginPrint);
            m_printDoc.EndPrint += new PrintEventHandler(m_printDoc_EndPrint);
            blnPrintView = false;
        }
        #endregion

        #region 初始化报告信息查询条件

        /// <summary>
        /// 初始化报告信息查询条件
        /// </summary>
        /// <param name="reportGroupID">报告组ID</param>
        /// <param name="applicationId">申请单ID</param>
        /// <param name="blnConfirmed">是否审核</param>
        public void m_mthGetPrintContentFromDB(string reportGroupID, string applicationId, bool blnConfirmed)
        {
            try
            {
                long lngRes = 0;

                clsPrintValuePara objPrintInfo = null;
                clsReportObject objReportObject = null;

                clsDomainController_ApplicationManage objAppDomain = new clsDomainController_ApplicationManage();
                lngRes = objAppDomain.m_lngGetReportObject(applicationId, out objReportObject);

                if (objReportObject != null && objReportObject.bytReportObjectArr != null)
                {
                    System.IO.Stream stream = new System.IO.MemoryStream(objReportObject.bytReportObjectArr);
                    System.Runtime.Serialization.IFormatter formater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    objPrintInfo = formater.Deserialize(stream) as clsPrintValuePara;
                    stream.Close();
                }

                if (objPrintInfo == null)
                {
                    clsDomainController_CheckResultManage objDomain = new clsDomainController_CheckResultManage();
                    lngRes = 0;
                    lngRes = objDomain.m_lngGetReportPrintInfo(reportGroupID, applicationId, blnConfirmed, out objPrintInfo);
                }

                if (objPrintInfo != null)
                {
                    m_strReportGroupID = reportGroupID;
                    this.m_ObjPrintInfo = objPrintInfo;
                }
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex.Message);
            }
        }

        #endregion

        private void m_mthSetPrintTool(string p_strParmValue)
        {
            this.m_objPrintTool = clsPrintToolFactory.Create(this.m_strReportGroupID);
        }

        #region PrintEvents

        private void m_printDoc_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (m_objPrintTool != null)
            {
                this.m_objPrintTool.m_mthInitPrintTool(this.m_printDoc);
                this.m_objPrintTool.m_mthBeginPrint(this.m_ObjPrintInfo);
            }
        }

        private void m_printDoc_PrintPage(object sender, PrintPageEventArgs e)
        {
            if (m_objPrintTool != null)
            {
                this.m_objPrintTool.m_mthPrintPage(e);
            }
        }

        private void m_printDoc_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (blnPrintView)
            {
                long lngRes = 0;
                if (m_objPrintInfo != null && m_objPrintInfo.m_dtbBaseInfo != null)
                {
                    string strAppID = m_objPrintInfo.m_dtbBaseInfo.Rows[0]["application_id_chr"].ToString().Trim();
                    if (!string.IsNullOrEmpty(strAppID))
                    {
                        lngRes = m_mthWriteReportPrintState(strAppID);
                    }
                }
            }
            if (m_objPrintTool != null)
            {
                this.m_objPrintTool.m_mthEndPrint(e);
            }
        }

        #endregion

        #region 写报告打印状态
        /// <summary>
        /// 写报告打印状态
        /// </summary>
        /// <param name="p_strApplicaionID"></param>
        /// <returns></returns>
        public long m_mthWriteReportPrintState(string p_strApplicaionID)
        {
            long lngRes = 0;
            lngRes = new clsDomainController_ApplicationManage().m_lngUpdatePrinctTime(p_strApplicaionID);
            return lngRes;
        }
        #endregion

        #region 功能接口

        /// <summary>
        /// 打印预览
        /// </summary>
        public void m_mthPrintPreview()
        {
            try
            {
                blnPrintView = false;
                //if (int.Parse(this.m_strReportGroupID) > 4)
                //{
                //    if (dsReport != null)
                //    {
                //        com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(dsReport);
                //    }
                //}
                //else
                //{
                m_printPrev = new PrintPreviewDialog();
                m_printPrev.Document = m_printDoc;
                m_printPrev.PrintPreviewControl.Zoom = 1;
                ((Form)m_printPrev).WindowState = System.Windows.Forms.FormWindowState.Maximized;
                m_printPrev.ShowDialog();
                //}
            }
            catch
            {
                MessageBox.Show("打印预览失败！");
            }
        }

        public void m_mthPrint()
        {
            m_mthPrint(string.Empty);
        }

        /// <summary>
        /// 打印
        /// </summary>
        public void m_mthPrint(string printerName)
        {
            try
            {
                blnPrintView = true;
                //if (int.Parse(this.m_strReportGroupID) > 4)
                //{
                if (dsReport != null)
                {
                    this.dsReport.Print(false);
                    if (m_objPrintInfo != null)
                    {
                        string strAppID = m_objPrintInfo.m_dtbBaseInfo.Rows[0]["application_id_chr"].ToString().Trim();
                        if (!string.IsNullOrEmpty(strAppID))
                        {
                            long lngRes = m_mthWriteReportPrintState(strAppID);
                        }
                    }
                    return;
                }
                //}
                if (printerName != string.Empty) m_printDoc.PrinterSettings.PrinterName = printerName;
                if (this.m_blnPrintWithDialog)
                {
                    m_printDlg = new PrintDialog();
                    m_printDlg.Document = m_printDoc;
                    DialogResult dlgRes = m_printDlg.ShowDialog();
                    if (dlgRes == DialogResult.OK)
                    {                       
                        m_printDoc.Print();
                    }
                }
                else
                {
                    m_printDoc.Print();
                }
            }
            catch
            {
                //MessageBox.Show("打印失败！");
            }
        }

        #endregion

        #region 获取检验配置信息

        /// <summary>
        /// 获取检验配置信息
        /// </summary>
        /// <param name="p_strFlag"></param>
        /// <param name="p_strSetID"></param>
        /// <returns></returns>
        public long m_lngGetCollocate(out string p_strFlag, string p_strSetID)
        {
            p_strFlag = null;
            System.Security.Principal.IPrincipal objPrincipal = null;
            clsQueryApplicationSvc objApplicationSvc =
                                (clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryApplicationSvc));
            long lngRes = objApplicationSvc.m_lngGetCollocate(objPrincipal, out p_strFlag, p_strSetID);
            return lngRes;
        }

        #endregion

        #region 加载DataWindows报表
        /// <summary>
        /// 加载DataWindows报表   //修改datawindow  用pb_lis.pbl
        /// </summary>
        /// <param name="p_dsReport"></param>
        /// <param name="dwObject"></param>
        public void m_mthLoadDWReport(DataStore p_dsReport, string dwObject, string p_strParmValue)
        {
            DataTable m_dtbSample = new DataTable();
            DataTable m_dtbResult = new DataTable();
            m_dtbSample = this.m_objPrintInfo.m_dtbBaseInfo;
            m_dtbResult = this.m_objPrintInfo.m_dtbResult;
            dsReport.LibraryList = Application.StartupPath + "\\pb_lis.pbl";
            dsReport.DataWindowObject = dwObject;
            dsReport.InsertRow(0);

            //if (m_dtbSample.Rows[0]["report_print_chr"] != System.DBNull.Value)
            //{
            //    string strTime = m_dtbSample.Rows[0]["report_print_chr"].ToString().Trim();
            //    int intTime = Convert.ToInt32(strTime);
            //    if (intTime > 0)
            //    {
            //        string strTitle = m_dtbSample.Rows[0]["print_title_vchr"].ToString().Trim() + "(重打)";
            //        dsReport.Modify("col1_t.text='" + strTitle + "'");
            //    }
            //} 


            //住院号、门诊卡号、体检号
            string strPatientType = m_dtbSample.Rows[0]["patient_type_chr"].ToString().Trim();

            switch (strPatientType)
            {
                case "2":
                    dsReport.Modify("t_4_2.visible=true");
                    dsReport.Modify("t_4_1.visible=false");
                    dsReport.Modify("t_4_3.visible=false");
                    dsReport.Modify("st_bihno.text = '" + m_dtbSample.Rows[0]["patientcardid_chr"].ToString().Trim() + "'");
                    break;

                case "3":
                    dsReport.Modify("t_4_3.visible=true");
                    dsReport.Modify("t_4_2.visible=false");
                    dsReport.Modify("t_4_1.visible=false");
                    dsReport.Modify("st_bihno.text = '" + m_dtbSample.Rows[0]["patient_inhospitalno_chr"].ToString().Trim() + "'");
                    break;

                default:
                    dsReport.Modify("t_4_1.visible=true");
                    dsReport.Modify("t_4_2.visible=false");
                    dsReport.Modify("t_4_3.visible=false");
                    dsReport.Modify("st_bihno.text = '" + m_dtbSample.Rows[0]["patient_inhospitalno_chr"].ToString().Trim() + "'");
                    break;
            }


            #region 打印表头信息
            dsReport.Modify("p_1.filename = '" + Application.StartupPath + "\\Picture\\东莞茶山医院图标.jpg'"); //加医院图标
            //dsReport.Modify("col1_t.text='" + m_dtbSample.Rows[0]["print_title_vchr"].ToString().Trim() + "'");
            dsReport.Modify("st_name.text = '" + m_dtbSample.Rows[0]["patient_name_vchr"].ToString().Trim() + "'");
            dsReport.Modify("st_sex.text = '" + m_dtbSample.Rows[0]["sex_chr"].ToString().Trim() + "'");
            dsReport.Modify("st_age.text = '" + m_dtbSample.Rows[0]["age_chr"].ToString().Trim() + "'");
            //dsReport.Modify("st_bihno.text = '" + m_dtbSample.Rows[0]["patient_inhospitalno_chr"].ToString().Trim() + "'");
            dsReport.Modify("st_checkno.text = '" + m_dtbSample.Rows[0]["check_no_chr"].ToString().Trim() + "'");
            dsReport.Modify("st_dept.text = '" + m_dtbSample.Rows[0]["deptname_vchr"].ToString().Trim() + "'");
            //if (p_strParmValue == "1")
            //{
            //    dsReport.Modify("st_diagno.text = '" + m_dtbSample.Rows[0]["diagnose_vchr"].ToString().Trim() + "'");
            //}
            //else
            //{
            //    dsReport.Modify("t_7.visible=false");
            //}
            dsReport.Modify("st_bedno.text = '" + m_dtbSample.Rows[0]["bedno_chr"].ToString().Trim() + "'");
            dsReport.Modify("st_sample.text = '" + m_dtbSample.Rows[0]["sample_type_desc_vchr"].ToString().Trim() + "'");
            //dsReport.Modify("st_printtime.text = '" + DateTime.Now.ToLongTimeString() + "'");
            #endregion

            //打印结果数据
            DataRowView objDr = null;
            DataView dv = new DataView(m_dtbResult);
            dv.RowFilter = "is_graph_result_num = 0";
            dv.Sort = "sample_print_seq_int asc";
            int startRow = 21;
            for (int i1 = 0; i1 < dv.Count && startRow < 221; i1++)
            {
                objDr = dv[i1];
                dsReport.Modify("t_" + Convert.ToString(startRow++) + ".text = '" + objDr["device_check_item_name_vchr"].ToString().Trim() + "'");
                dsReport.Modify("t_" + Convert.ToString(startRow++) + ".text = '" + objDr["rptno_chr"].ToString().Trim() + "'");
                string strResult = objDr["result_vchr"].ToString().Trim();
                string strMin = objDr["min_val_dec"].ToString().Trim();
                string strMax = objDr["max_val_dec"].ToString().Trim();
                //本来有个abnormal_flag_chr字段可用的，但此例没有数据
                if (!string.IsNullOrEmpty(strMin) && !string.IsNullOrEmpty(strMax))
                {
                    if (decimal.Parse(strResult) > decimal.Parse(strMax))
                    {
                        strResult = strResult.PadRight(6, ' ') + "↑";
                    }
                    else if (decimal.Parse(strResult) < decimal.Parse(strMin))
                    {
                        if (strResult.Contains(">") || strResult.Contains("<"))
                            strResult = strResult.PadRight(6, ' ') + "↑";
                        else
                            strResult = strResult.PadRight(6, ' ') + "↓";
                    }
                    else
                    { }
                }
                dsReport.Modify("t_" + Convert.ToString(startRow++) + ".text = '" + strResult + "'");
                dsReport.Modify("t_" + Convert.ToString(startRow++) + ".text = '" + objDr["refrange_vchr"].ToString().Trim() + "'");
                dsReport.Modify("t_" + Convert.ToString(startRow++) + ".text = '" + objDr["unit_vchr"].ToString().Trim() + "'");
            }

            //打印图形数据
            dv.RowFilter = "is_graph_result_num = 1";
            dv.Sort = "sample_print_seq_int asc";
            Image img = null;
            System.IO.MemoryStream ms = null;
            for (int j2 = 0; j2 < dv.Count; j2++)
            {
                objDr = dv[j2];
                if (objDr["graph_img"] is System.DBNull)
                {
                    continue;
                }
                try
                {
                    ms = new System.IO.MemoryStream(objDr["graph_img"] as byte[]);
                    img = Image.FromStream(ms, true);
                    img.Save(@"D:\\code\\0001.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    img.Dispose();
                    dsReport.Modify("p_img.filename = 'D:\\code\\0001.jpg'");
                    break;
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    if (ms != null)
                        ms.Close();
                }
            }

            //打印页尾
            //dsReport.Modify("t_applyer.text = '" + m_dtbSample.Rows[0]["applyer"].ToString().Trim() + "'");
            //dsReport.Modify("t_acceptdate.text = '" + DateTime.Parse(m_dtbSample.Rows[0]["accept_dat"].ToString().Trim()).ToString("yyyy-MM-dd") + "'");
            dsReport.Modify("t_confirmdate.text = '" + DateTime.Parse(m_dtbSample.Rows[0]["confirm_dat"].ToString().Trim()).ToString("yyyy-MM-dd") + "'");
            dsReport.Modify("t_reportor.text = '" + m_dtbSample.Rows[0]["reportor"].ToString().Trim() + "'");
            dsReport.Modify("t_confirmer.text = '" + m_dtbSample.Rows[0]["confirmer"].ToString().Trim() + "'");
        }
        #endregion
    }

    /// <summary>
    /// clsPrintToolFactory 创建打印类
    /// </summary>
    internal class clsPrintToolFactory
    {
        public static infPrintRecord Create(string reportGroupId)
        {
            infPrintRecord printTool = null;
            switch (reportGroupId)
            {
                case "000001":
                    printTool = new clsMarrowReportPrintTool();
                    clsMarrowReportPrintTool.blnSurePrintDiagnose = true;
                    break;
                case "000002":
                    printTool = new clsGermReportPrinTool();
                    clsGermReportPrinTool.blnSurePrintDiagnose = true;
                    break;
                case "000004":
                    printTool = new clsGermReportPrinToolV2();
                    clsGermReportPrinToolV2.blnSurePrintDiagnose = true;
                    break;
                default:
                    string strFlag = null;
                    //4003:检验报告格式  0:默认格式 1:格式一 2:格式二
                    long lngRes = m_lngGetCollocate(out strFlag, "4003");
                    if (lngRes > 0)
                    {
                        if (strFlag != "")
                        {
                            switch (strFlag)
                            {
                                case "0":
                                    printTool = new clsUnifyReportPrint();
                                    clsUnifyReportPrint.blnSurePrintDiagnose = true;

                                    break;
                                //case "1":
                                //    printTool = new clsUnifyReportPrintForChildHospital();
                                //    clsUnifyReportPrintForChildHospital.blnSurePrintDiagnose = true;
                                //    break;
                                //case "2":
                                //    printTool = new clsUnifyReportPrintForChildHospital_B5();
                                //    clsUnifyReportPrintForChildHospital_B5.blnSurePrintDiagnose = true;
                                //    break;
                                default:
                                    printTool = new clsUnifyReportPrint();
                                    clsUnifyReportPrint.blnSurePrintDiagnose = true;
                                    break;
                            }
                        }
                    }
                    break;
            }

            return printTool;
        }

        public static long m_lngGetCollocate(out string p_strFlag, string p_strSetID)
        {
            p_strFlag = null;
            System.Security.Principal.IPrincipal objPrincipal = null;
            clsQueryApplicationSvc objApplicationSvc =
                                (clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryApplicationSvc));
            long lngRes = objApplicationSvc.m_lngGetCollocate(objPrincipal, out p_strFlag, p_strSetID);
            return lngRes;
        }
    }
}
