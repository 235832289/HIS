using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using com.digitalwave.Utility;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.middletier.LIS;
using com.digitalwave.iCare.ValueObject;
using System.IO;
using System.Net;

namespace com.digitalwave.iCare.gui.LIS
{
    /// <summary>
    /// clsController_HandInputReport 的摘要说明。
    /// 刘彬 2004.05.24
    /// </summary>
    internal class clsController_HandInputReport : com.digitalwave.GUI_Base.clsController_Base
    {

        #region 私有成员

        private clsLIS_AppCheckReport[] m_objDefaultReports;//前次申请项目
        private clsLIS_AppApplyUnit[] m_objDefaultApplyUnits;//前次申请项目
        private bool m_blnUseDefault = false;//是否使用前次申请项目的值;
        private Hashtable m_hasSampleGroup = new Hashtable();
        private clsPrintReport m_objPrinter = new clsPrintReport();
        private frmHandInputReport m_objViewer;

        #endregion

        #region 属  性

        public DataTable m_dtbResult;
        public clsLISInfoVO m_objLISInfoVO;
        public static string c_strMessageBoxTitle = "iCare-整合报告处理";
        public static string c_strMessageDataErr = "操作失败!";
        private clsSampleGroup_VO[] m_arrSampleGroup = null;

        public clsSampleGroup_VO[] SampleGroups
        {
            get
            {
                if (m_arrSampleGroup == null)
                {
                    return new clsSampleGroup_VO[0];
                }
                return m_arrSampleGroup;
            }
        }


        /// <summary>
        /// 设置或获取 是否使用前次申请项目的值
        /// </summary>
        public bool m_BlnUseDefault
        {
            get
            {
                return this.m_blnUseDefault;
            }
            set
            {
                this.m_objDefaultReports = null;
                this.m_objDefaultApplyUnits = null;
                this.m_blnUseDefault = value;
            }
        }

        /// <summary>
        /// 需要特殊处理的项目的EnglishName， BG为ABO血型
        /// </summary>
        internal string m_strExcItemEnglishName = "BG";

        DataTable DataSourceItemRef { get; set; }
        DataTable DataSourceItemRefDept { get; set; }
        DataTable DataSourceItemRefYG { get; set; }

        /// <summary>
        /// 微信推送信息地址
        /// </summary>
        string WechatWebUrl { get; set; }
        /// <summary>
        /// RH血型历史值对比
        /// </summary>
        Dictionary<string, DataTable> DataSourceRH { get; set; }

        #endregion

        #region 构造函数

        public clsController_HandInputReport()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #endregion

        #region 设置窗体对象

        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmHandInputReport)frmMDI_Child_Base_in;
        }

        #endregion

        #region 初始化数据，控件

        public void m_mthInit()
        {
            this.m_mthGenerateResultDataTable();
            this.m_mthInitSampleGroupHas();
            long lngRes = 0;
            DataTable m_dtCheckCategory = null;
            lngRes = new clsDomainController_ApplicationManage().m_lngQueryCheckCategory(out m_dtCheckCategory);
            if (m_dtCheckCategory != null)
            {
                DataRow drTemp = m_dtCheckCategory.NewRow();
                drTemp["check_category_id_chr"] = "";
                drTemp["check_category_desc_vchr"] = "全部";
                m_dtCheckCategory.Rows.InsertAt(drTemp, 0);
                m_objViewer.m_cboCheckCategory.DisplayMember = "check_category_desc_vchr";
                m_objViewer.m_cboCheckCategory.ValueMember = "check_category_id_chr";
                m_objViewer.m_cboCheckCategory.DataSource = m_dtCheckCategory;
            }

            #region 检验项目参考信息
            clsQueryCheckItemSvc proxy = (clsQueryCheckItemSvc)clsObjectGenerator.objCreatorObjectByType(typeof(clsQueryCheckItemSvc));
            DataSourceItemRef = proxy.GetItemRef();
            DataSourceItemRefDept = proxy.GetCriticalValueRefLisDept(string.Empty);
            proxy = null;
            bizCriticalValue proxyYG = (bizCriticalValue)clsObjectGenerator.objCreatorObjectByType(typeof(bizCriticalValue));
            DataSourceItemRefYG = proxyYG.GetCriYG();
            proxyYG = null;
            #endregion

            #region Wechat

            string tmpStr = string.Empty;
            if (m_lngGetSysParm("1010", out tmpStr) > 0)
            {
                if (!string.IsNullOrEmpty(tmpStr) && tmpStr.Trim() != "")
                {
                    this.WechatWebUrl = tmpStr.Trim();
                }
            }

            #endregion
        }

        private void m_mthGenerateResultDataTable()
        {
            new clsDomainController_CheckResultManage().m_lngGetCheckResultTable("", "", false, out m_dtbResult);
            m_dtbResult.TableName = "dtbCheckResult";
            m_dtbResult.ColumnChanged += new DataColumnChangeEventHandler(m_mthResultListColumnChanged);
        }

        private void m_mthInitSampleGroupHas()
        {
            clsSampleGroup_VO[] objSampleGroupVOArr = null;
            new clsDomainController_SampleGroupManage().m_lngGetAllSampleGroup(out objSampleGroupVOArr);

            if (objSampleGroupVOArr != null && objSampleGroupVOArr.Length != 0)
            {
                for (int i = 0; i < objSampleGroupVOArr.Length; i++)
                {
                    m_hasSampleGroup.Add(objSampleGroupVOArr[i].strSampleGroupID, objSampleGroupVOArr[i].strSampleGroupName);
                }
            }
            else
            {
                objSampleGroupVOArr = new clsSampleGroup_VO[0];
            }

            this.m_arrSampleGroup = objSampleGroupVOArr;
        }

        #endregion


        #region 预览打印报告

        public void m_mthPreview()
        {
            m_objPrinter.m_mthGetPrintContentFromDB(m_objLISInfoVO.m_objReportVO.m_strREPORT_GROUP_ID_CHR,
                                                    m_objLISInfoVO.m_objAppMainVO.m_strAPPLICATION_ID, true);
            m_objPrinter.m_mthPrintPreview();
        }

        public void m_mthPrint()
        {
            this.m_objPrinter.m_mthGetPrintContentFromDB(this.m_objLISInfoVO.m_objReportVO.m_strREPORT_GROUP_ID_CHR,
                                                         this.m_objLISInfoVO.m_objAppMainVO.m_strAPPLICATION_ID, true);
            this.m_objPrinter.m_mthPrint();
        }

        #endregion

        #region 检验项目结果处理

        public void m_mthDataProcess(DataTable p_dtbResultList)
        {
            try
            {
                for (int i = 0; i < p_dtbResultList.Rows.Count; i++)
                {

                    #region 设置单位

                    p_dtbResultList.Rows[i]["UNIT_VCHR"] = p_dtbResultList.Rows[i]["item_unit_chr"];
                    p_dtbResultList.Rows[i]["device_check_item_name_vchr"] = p_dtbResultList.Rows[i]["device_item_name_vchr"];
                    if (p_dtbResultList.Rows[i]["resulttype_chr"].ToString() == "3")
                    {
                        p_dtbResultList.Rows[i]["IS_GRAPH_RESULT_NUM"] = 1;
                    }
                    else
                    {
                        p_dtbResultList.Rows[i]["IS_GRAPH_RESULT_NUM"] = 0;
                    }

                    #endregion

                }
                p_dtbResultList.AcceptChanges();
            }
            catch (Exception ex)
            {
                new clsLogText().LogError(ex);
            }
        }

        public void m_mthResultListColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            #region 中文标点到英文标点的转换
            if (e.Column.ColumnName.ToUpper() == "RESULT_VCHR")
            {
                string strResult1 = e.Row["result_vchr"].ToString();
                string strResult2 = strResult1.Trim().Replace("。", ".");
                if (strResult1 != strResult2)
                {
                    e.Row["result_vchr"] = strResult2;
                    return;
                }
            }
            #endregion

            string strResult = e.Row["result_vchr"].ToString().Trim();
            if (strResult.IndexOf("E+") < 0)
            {
                strResult = strResult.Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                strResult = strResult.Replace(">", "").Replace(">=", "").Replace("》", "").Replace(">>", "").Replace("＞", "").Replace("≥", "");
            }
            string strResultMin = string.Empty;
            if (e.Row["min_val_dec"] != System.DBNull.Value)
            {
                strResultMin = e.Row["min_val_dec"].ToString().Trim();
                if (strResultMin.IndexOf("E+") < 0)
                {
                    strResultMin = strResultMin.Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                    strResultMin = strResultMin.Replace(">", "").Replace(">=", "").Replace("》", "").Replace(">>", "").Replace("＞", "").Replace("≥", "");
                }
                else
                {
                    if (strResultMin.IndexOf(">") < 0) strResultMin = ">" + strResultMin;
                }
            }
            string strResultMax = string.Empty;
            if (e.Row["max_val_dec"] != System.DBNull.Value)
            {
                strResultMax = e.Row["max_val_dec"].ToString().Trim();
                if (strResultMax.IndexOf("E+") < 0)
                {
                    strResultMax = strResultMax.Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                    strResultMax = strResultMax.Replace(">", "").Replace(">=", "").Replace("》", "").Replace(">>", "").Replace("＞", "").Replace("≥", "");
                }
                else
                {
                    if (strResultMax.IndexOf("<") < 0) strResultMax = "<" + strResultMax;
                }
            }
            #region 变更异常标志
            try
            {
                if (e.Column.ColumnName.ToUpper() == "RESULT_VCHR")
                {
                    if (strResult.IndexOf("E+") >= 0)
                    {
                        string rinfo = string.Empty;
                        try
                        {
                            if (strResultMin.IndexOf("E+") >= 0 && strResultMax.IndexOf("E+") >= 0)
                            {
                                rinfo = CMPdata(strResult, strResultMin, strResultMax);
                            }
                            else
                            {
                                if (strResultMin.IndexOf("E+") >= 0)
                                    rinfo = CMPdata(strResult, strResultMin);
                                else if (strResultMax.IndexOf("E+") >= 0)
                                    rinfo = CMPdata(strResult, strResultMax);
                            }
                        }
                        catch { }
                        if (rinfo == "偏高")
                            rinfo = "H";
                        else if (rinfo == "偏低")
                            rinfo = "L";
                        else
                            rinfo = null;
                        e.Row["abnormal_flag_chr"] = rinfo;
                    }
                    else
                    {
                        if (e.Row["RESULTTYPE_CHR"].ToString().Trim() == "0")
                        {
                            bool blnDone = false;
                            if (e.Row["min_val_dec"] != System.DBNull.Value && !blnDone)
                            {
                                double dlbResult = double.Parse(strResult);
                                if (dlbResult < double.Parse(strResultMin))
                                {
                                    e.Row["abnormal_flag_chr"] = "L";
                                    blnDone = true;
                                }
                            }
                            if (e.Row["max_val_dec"] != System.DBNull.Value && !blnDone)
                            {
                                double dlbResult = double.Parse(strResult);
                                if (dlbResult > double.Parse(strResultMax))
                                {
                                    e.Row["abnormal_flag_chr"] = "H";
                                    blnDone = true;
                                }
                            }
                            if (!blnDone)
                            {
                                e.Row["abnormal_flag_chr"] = null;
                            }
                        }
                    }
                }
            }
            catch { }
            #endregion

            #region 变更警戒标示
            if (e.Row["alarm_low_val_vchr"] != System.DBNull.Value)
            {
                strResultMin = e.Row["alarm_low_val_vchr"].ToString().Trim();
                if (strResultMin.IndexOf("E+") < 0)
                {
                    strResultMin = strResultMin.Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                    strResultMin = strResultMin.Replace(">", "").Replace(">=", "").Replace("》", "").Replace(">>", "").Replace("＞", "").Replace("≥", "");
                }
                else
                {
                    if (strResultMin.IndexOf(">") < 0) strResultMin = ">" + strResultMin;
                }
            }
            if (e.Row["alarm_up_val_vchr"] != System.DBNull.Value)
            {
                strResultMax = e.Row["alarm_up_val_vchr"].ToString().Trim();
                if (strResultMax.IndexOf("E+") < 0)
                {
                    strResultMax = strResultMax.Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                    strResultMax = strResultMax.Replace(">", "").Replace(">=", "").Replace("》", "").Replace(">>", "").Replace("＞", "").Replace("≥", "");
                }
                else
                {
                    if (strResultMax.IndexOf("<") < 0) strResultMax = "<" + strResultMax;
                }
            }
            try
            {
                if (e.Column.ColumnName.ToUpper() == "RESULT_VCHR")
                {
                    if (strResult.IndexOf("E+") >= 0)
                    {
                        string rinfo = string.Empty;
                        try
                        {
                            if (strResultMin.IndexOf("E+") >= 0 && strResultMax.IndexOf("E+") >= 0)
                            {
                                rinfo = CMPdata(strResult, strResultMin, strResultMax);
                            }
                            else
                            {
                                if (strResultMin.IndexOf("E+") >= 0)
                                    rinfo = CMPdata(strResult, strResultMin);
                                else if (strResultMax.IndexOf("E+") >= 0)
                                    rinfo = CMPdata(strResult, strResultMax);
                            }
                        }
                        catch { }
                        if (rinfo == "偏高")
                            rinfo = "H";
                        else if (rinfo == "偏低")
                            rinfo = "L";
                        else
                            rinfo = null;
                        e.Row["alert_flag"] = rinfo;
                    }
                    else
                    {
                        if (e.Row["RESULTTYPE_CHR"].ToString().Trim() == "0")
                        {
                            bool blnDone = false;
                            if (e.Row["alarm_low_val_vchr"] != System.DBNull.Value && !blnDone)
                            {
                                if (double.Parse(strResult) < double.Parse(strResultMin))
                                {
                                    e.Row["alert_flag"] = "L";
                                    blnDone = true;
                                }
                            }
                            if (e.Row["alarm_up_val_vchr"] != System.DBNull.Value && !blnDone)
                            {
                                if (double.Parse(strResult) > double.Parse(strResultMax))
                                {
                                    e.Row["alert_flag"] = "H";
                                    blnDone = true;
                                }
                            }
                            if (!blnDone)
                            {
                                e.Row["alert_flag"] = null;
                            }
                        }
                    }
                }
            }
            catch { }
            #endregion
            if ((e.Column.ColumnName.ToUpper() == "RESULT_VCHR" && e.Row["result_vchr", DataRowVersion.Original] == e.ProposedValue)
                || (e.Column.ColumnName.ToUpper() == "GRAPH_IMG" && e.Row["graph_img", DataRowVersion.Original] == e.ProposedValue))
                return;
            #region 数据被更改
            if (e.Column.ColumnName.ToUpper() == "RESULT_VCHR" || e.Column.ColumnName.ToUpper() == "GRAPH_IMG")
            {
                e.Row["modify_flag"] = 1;
            }
            #endregion
            #region 计算项目
            try
            {
                if (e.Column.ColumnName.ToUpper() == "RESULT_VCHR" && e.Row["eff_caculate_id_chr"] != System.DBNull.Value)
                {
                    string strCaculateIDs = e.Row["eff_caculate_id_chr"].ToString().Trim();
                    string[] strCaculateIDArr = strCaculateIDs.Split(new char[] { '|' });
                    for (int i = 0; i < strCaculateIDArr.Length; i++)
                    {
                        string strCaculateID = strCaculateIDArr[i];
                        if (strCaculateID.Trim() != "")
                        {
                            DataTable dtbResult = ((DataView)this.m_objViewer.m_dtgResultList.DataSource).Table;
                            foreach (DataRow dtr in dtbResult.Rows)
                            {
                                if (dtr["check_item_id_chr"].ToString().Trim() == strCaculateID)
                                {
                                    string strFormula = dtr["formula_vchr"].ToString().Trim();
                                    object objResult = m_objDoCalculate(strFormula, null, dtbResult);
                                    if (objResult != null)
                                    {
                                        dtr["RESULT_VCHR"] = objResult.ToString();
                                    }
                                    else
                                    {
                                        dtr["RESULT_VCHR"] = null;
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
            }
            #endregion

            #region 计算比值

            if (e.Column.ColumnName.ToLower() == "result_vchr")
            {
                string checkItemId = e.Row["check_item_id_chr"].ToString().Trim();
                #region 比值1
                // 001915 FPSA     000338 TPSA      001916  FPSA/TPSA
                if (checkItemId == "001915" || checkItemId == "000338")
                {
                    decimal decResult = 0;
                    decimal.TryParse(e.Row["result_vchr"].ToString(), out decResult);
                    if (decResult > 0)
                    {
                        decimal decResult1 = 0;
                        decimal decResult2 = 0;
                        DataTable dtbResult = ((DataView)this.m_objViewer.m_dtgResultList.DataSource).Table;
                        foreach (DataRow dr2 in dtbResult.Rows)
                        {
                            if (dr2["check_item_id_chr"].ToString().Trim() == "001915")
                            {
                                decimal.TryParse(dr2["result_vchr"].ToString(), out decResult1);
                            }
                            else if (dr2["check_item_id_chr"].ToString().Trim() == "000338")
                            {
                                decimal.TryParse(dr2["result_vchr"].ToString(), out decResult2);
                            }
                        }
                        if (decResult2 > 0)
                        {
                            foreach (DataRow dr3 in dtbResult.Rows)
                            {
                                if (dr3["check_item_id_chr"].ToString().Trim() == "001916")
                                {
                                    dr3["result_vchr"] = com.digitalwave.iCare.gui.HIS.clsPublic.Round(decResult1 / decResult2, 2).ToString();
                                    //dr3["result_vchr"] = com.digitalwave.iCare.gui.HIS.clsPublic.Round((decResult1 / decResult2) * 100, 2).ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion
                #region 比值2
                // 001899  胃蛋白酶原I(PGI)     001900 胃蛋白酶原II(PGII)      001901  PGI/PGII
                else if (checkItemId == "001899" || checkItemId == "001900")
                {
                    decimal decResult = 0;
                    decimal.TryParse(e.Row["result_vchr"].ToString(), out decResult);
                    if (decResult > 0)
                    {
                        decimal decResult1 = 0;
                        decimal decResult2 = 0;
                        DataTable dtbResult = ((DataView)this.m_objViewer.m_dtgResultList.DataSource).Table;
                        foreach (DataRow dr2 in dtbResult.Rows)
                        {
                            if (dr2["check_item_id_chr"].ToString().Trim() == "001899")
                            {
                                decimal.TryParse(dr2["result_vchr"].ToString(), out decResult1);
                            }
                            else if (dr2["check_item_id_chr"].ToString().Trim() == "001900")
                            {
                                decimal.TryParse(dr2["result_vchr"].ToString(), out decResult2);
                            }
                        }
                        if (decResult2 > 0)
                        {
                            foreach (DataRow dr3 in dtbResult.Rows)
                            {
                                if (dr3["check_item_id_chr"].ToString().Trim() == "001901")
                                {
                                    dr3["result_vchr"] = com.digitalwave.iCare.gui.HIS.clsPublic.Round(decResult1 / decResult2, 2).ToString();
                                    break;
                                }
                            }
                        }
                    }
                }
                #endregion
                #region Rh血型与历史不一致时能提示
                // 000311 RH血型;   001368  RH血型 c
                else if (checkItemId == "000311" || checkItemId == "001368")
                {
                    string resultStr = e.Row["result_vchr"].ToString();
                    clsLisApplMainVO objLisApplVo = (clsLisApplMainVO)this.m_objViewer.m_dtgReportList.SelectedRows[0].Cells["Tag"].Value;
                    if (objLisApplVo != null && !string.IsNullOrEmpty(objLisApplVo.m_strAPPLICATION_ID))
                    {
                        if (DataSourceRH != null && DataSourceRH.Keys.Count > 5000) DataSourceRH = null;
                        if (DataSourceRH == null) DataSourceRH = new Dictionary<string, DataTable>();
                        DataTable dtRH = null;
                        if (DataSourceRH.ContainsKey(objLisApplVo.m_strAPPLICATION_ID))
                        {
                            dtRH = DataSourceRH[objLisApplVo.m_strAPPLICATION_ID];
                        }
                        else
                        {
                            dtRH = (new clsDomainController_ApplicationManage()).GetCheckItemHistoryValue(objLisApplVo.m_strAPPLICATION_ID, "'000311','001368'");
                            DataSourceRH.Add(objLisApplVo.m_strAPPLICATION_ID, dtRH);
                        }
                        if (dtRH != null && dtRH.Rows.Count > 0)
                        {
                            string rhInfo = string.Empty;
                            string rhName = string.Empty;
                            string rhRes = string.Empty;
                            bool isPass = false;
                            foreach (DataRow dr in dtRH.Rows)
                            {
                                rhName = dr["itemName"] == DBNull.Value ? "" : dr["itemName"].ToString().Trim();
                                if (dr["itemDate"] != DBNull.Value)
                                    rhInfo += Convert.ToDateTime(dr["itemDate"]).ToString("yyyy-MM-dd HH:mm") + "   ";
                                rhRes = dr["itemResult"] == DBNull.Value ? "" : dr["itemResult"].ToString().Trim();
                                rhInfo += rhRes + Environment.NewLine;

                                if (resultStr == rhRes) isPass = true;
                            }
                            if (isPass == false && rhInfo != string.Empty)
                            {
                                MessageBox.Show(rhInfo, rhName + " 历史值", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                #endregion
            }
            #endregion
        }

        private object m_objDoCalculate(string strFormula, object curValue, DataTable dtbValueSet)
        {
            object objResult = null;
            try
            {
                objResult = new com.digitalwave.iCare.common.clsExpressionEvaluate(strFormula, dtbValueSet, "check_item_id_chr", "RESULT_VCHR", curValue, 0, null).Evaluate();
            }
            catch (Exception ex)
            {
                try
                {
                    new com.digitalwave.Utility.clsLogText().LogError(ex);
                }
                catch { }
                objResult = null;
            }
            try
            {
                if (objResult != null && Microsoft.VisualBasic.Information.IsNumeric(objResult))
                {
                    double dblResult = double.Parse(objResult.ToString());
                    dblResult = Math.Round(dblResult, 2);
                    objResult = dblResult;
                }
            }
            catch
            {
                objResult = null;
            }
            return objResult;
        }

        #endregion

        #region 查询

        public long m_lngQuery(clsLISApplicationSchVO p_objSchVO, string p_strCheckCategory, out clsLisApplMainVO[] p_objAppVOArr)
        {
            p_objAppVOArr = null;
            long lngRes = 0;
            try
            {
                lngRes = new clsDomainController_ApplicationManage().m_lngGetAppInfoByModifDate(p_objSchVO, p_strCheckCategory, out p_objAppVOArr);
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }


        public long m_lngQueryByInHospitalNO(clsLISApplicationSchVO p_objSchVO, string p_strInHospitalNO, out clsLisApplMainVO[] p_objAppVOArr)
        {
            p_objAppVOArr = null;
            long lngRes = 0;
            try
            {
                lngRes = new clsDomainController_ApplicationManage().m_lngGetAppInfoByConditionAndInHospitalNO(
                    p_objSchVO, p_strInHospitalNO, out p_objAppVOArr);
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }
        #endregion

        #region 仪器关联
        public long m_lngDeleteCurrAppDR()
        {
            long lngRes = 0;
            try
            {
                clsDomainController_ApplicationManage objDomain = new clsDomainController_ApplicationManage();
                lngRes = objDomain.m_lngDeleteDeviceRelationByApplicationID(
                    m_objLISInfoVO.m_objAppMainVO.m_strAPPLICATION_ID,
                    m_objLISInfoVO.m_objAppMainVO.m_strOriginDate);
                if (lngRes > 0)
                {
                    m_objLISInfoVO.m_objDRVOArr.Clear();
                    if (this.m_dtbResult != null)
                    {
                        for (int i1 = 0; i1 < m_dtbResult.Rows.Count; i1++)
                        {
                            if (m_dtbResult.Rows[i1]["RAW_RESULT_VCHR"].ToString().Trim() != "")
                            {
                                m_dtbResult.Rows[i1]["RAW_RESULT_VCHR"] = "";
                                m_dtbResult.Rows[i1]["RESULT_VCHR"] = "";
                            }
                        }
                    }
                }
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }
        public long m_lngAddNewDeviceRelation(clsT_LIS_DeviceRelationVO p_objRelationVO)
        {
            long lngRes = m_lngAddDeviceRelation(p_objRelationVO);
            if (lngRes == 1)
            {
                this.m_objLISInfoVO.m_objDRVOArr.Add(p_objRelationVO);
                if (p_objRelationVO.m_intSTATUS_INT == 2)
                {
                    m_mthImportData(p_objRelationVO);
                }
            }
            else
            {
                p_objRelationVO.m_intSTATUS_INT = -1;
            }
            return lngRes;
        }
        public long m_lngAddDeviceRelation(clsT_LIS_DeviceRelationVO p_objRelationVO)
        {
            long lngRes = m_lngQueryBind(p_objRelationVO);
            if (lngRes == 0)
                return 0;
            try
            {
                lngRes = 0;
                lngRes = new clsDomainController_SampleManage().m_lngAddNewDeviceRelation(p_objRelationVO);
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }
        public bool m_blnDeleteRelation(clsT_LIS_DeviceRelationVO p_objRelation, out string p_strMessage)
        {
            p_strMessage = null;
            if (p_objRelation == null) { return true; }

            long lngRes = 0;
            lngRes = new clsDomainController_SampleManage().m_lngDeleteDeviceRelation(
                                            p_objRelation.m_strDEVICEID_CHR, p_objRelation.m_strRECEPTION_DAT, p_objRelation.m_strSEQ_ID_CHR);
            if (lngRes <= 0)
            {
                p_strMessage = "作废关联失败!";
                return false;
            }
            this.m_objLISInfoVO.m_objDRVOArr.Remove(p_objRelation);

            return true;
        }

        public long m_lngModifyBind(clsT_LIS_DeviceRelationVO p_objSourceVO, clsT_LIS_DeviceRelationVO p_objTargetVO)
        {
            long lngRes = this.m_lngQueryBind(p_objTargetVO);
            if (lngRes == 0) { return 0; }

            try
            {
                lngRes = 0;
                lngRes = new clsDomainController_SampleManage().m_lngModifyBind(p_objSourceVO, p_objTargetVO);
            }
            catch
            {
                lngRes = 0;
            }
            if (lngRes == 1)
            {
                this.m_objLISInfoVO.m_objDRVOArr.Remove(p_objSourceVO);
                this.m_objLISInfoVO.m_objDRVOArr.Add(p_objTargetVO);
                if (p_objTargetVO.m_intSTATUS_INT == 2)
                {
                    m_mthImportData(p_objTargetVO);
                }
            }
            return lngRes;
        }


        public void m_mthImportData(clsT_LIS_DeviceRelationVO p_objDRVO)
        {
            DataTable dtbResult = this.m_dtbResult;
            clsDeviceReslutVO[] objDeviceResultVOArr = null;
            if (p_objDRVO == null || p_objDRVO.m_intSTATUS_INT != 2) { return; }

            long lngRes = new clsDomainController_CheckResultManage().m_lngGetDeviceData(p_objDRVO.m_strDEVICEID_CHR,
                                                                                         p_objDRVO.m_intIMPORT_REQ_INT,
                                                                                         out objDeviceResultVOArr);

            if (objDeviceResultVOArr != null && objDeviceResultVOArr.Length > 0)
            {
                this.m_mthSetDeviceData(dtbResult, objDeviceResultVOArr);
            }
        }


        public void m_mthSetDeviceData(DataTable p_dtbResultList, clsDeviceReslutVO[] p_objDeviceResultVOArr)
        {
            if (p_dtbResultList == null)
                return;
            for (int i1 = 0; i1 < p_dtbResultList.Rows.Count; i1++)
            {
                for (int j2 = 0; j2 < p_objDeviceResultVOArr.Length; j2++)
                {
                    if (p_dtbResultList.Rows[i1]["device_check_item_name_vchr"].ToString().Trim() == p_objDeviceResultVOArr[j2].m_strDeviceCheckItemName.Trim())
                    {
                        if (p_dtbResultList.Rows[i1]["resulttype_chr"].ToString() == "3")
                        {
                            if (p_objDeviceResultVOArr[j2].bytGraph == null)
                            {
                                p_dtbResultList.Rows[i1]["graph_img"] = System.DBNull.Value;
                            }
                            else
                            {
                                p_dtbResultList.Rows[i1]["graph_img"] = p_objDeviceResultVOArr[j2].bytGraph;
                            }
                            p_dtbResultList.Rows[i1]["GRAPH_FORMAT_NAME_VCHR"] = p_objDeviceResultVOArr[j2].strGraphFormatName;
                        }
                        else
                        {
                            p_dtbResultList.Rows[i1]["RAW_RESULT_VCHR"] = p_objDeviceResultVOArr[j2].m_strResult;
                            p_dtbResultList.Rows[i1]["RESULT_VCHR"] = p_objDeviceResultVOArr[j2].m_strResult;
                            if (p_objDeviceResultVOArr[j2].m_strRefRange != "")
                            {
                                p_dtbResultList.Rows[i1]["REFRANGE_VCHR"] = p_objDeviceResultVOArr[j2].m_strRefRange;
                            }
                        }
                        if (m_objViewer.m_rtbCheckSummary.Text.Trim() == "")
                        {
                            m_objViewer.m_rtbCheckSummary.Text = p_objDeviceResultVOArr[j2].strDoctorExpress;
                        }
                        break;
                    }
                }
            }

            this.m_objViewer.m_lsvGraph.Items.Clear();
            this.m_objViewer.m_imgGraphList.Images.Clear();
            m_mthShowGraph(p_dtbResultList);
        }
        public void m_mthSetDeviceDataNoImport(DataTable p_dtbResultList, clsDeviceReslutVO[] p_objDeviceResultVOArr)
        {
            if (p_dtbResultList == null)
                return;
            for (int i1 = 0; i1 < p_dtbResultList.Rows.Count; i1++)
            {
                for (int j2 = 0; j2 < p_objDeviceResultVOArr.Length; j2++)
                {
                    if (p_dtbResultList.Rows[i1]["device_check_item_name_vchr"].ToString().Trim() == p_objDeviceResultVOArr[j2].m_strDeviceCheckItemName.Trim())
                    {
                        if (p_dtbResultList.Rows[i1]["resulttype_chr"].ToString() == "3")
                        {
                            if (p_dtbResultList.Rows[i1]["graph_img"] == DBNull.Value)
                            {
                                if (p_objDeviceResultVOArr[j2].bytGraph == null)
                                {
                                    p_dtbResultList.Rows[i1]["graph_img"] = System.DBNull.Value;
                                }
                                else
                                {
                                    p_dtbResultList.Rows[i1]["graph_img"] = p_objDeviceResultVOArr[j2].bytGraph;
                                }
                                p_dtbResultList.Rows[i1]["GRAPH_FORMAT_NAME_VCHR"] = p_objDeviceResultVOArr[j2].strGraphFormatName;
                            }
                        }
                        else
                        {
                            p_dtbResultList.Rows[i1]["RAW_RESULT_VCHR"] = p_objDeviceResultVOArr[j2].m_strResult;
                            if (p_dtbResultList.Rows[i1]["RESULT_VCHR"].ToString().Trim() == "")
                            {
                                p_dtbResultList.Rows[i1]["RESULT_VCHR"] = p_objDeviceResultVOArr[j2].m_strResult;
                            }
                        }
                        break;
                    }
                }
            }
        }
        private long m_lngQueryBind(clsT_LIS_DeviceRelationVO p_objRelationVO)
        {
            long lngRes = 0;
            string strDeviceID = p_objRelationVO.m_strDEVICEID_CHR;
            string strDeviceSampleID = p_objRelationVO.m_strDEVICE_SAMPLEID_CHR;
            string strCheckDate = p_objRelationVO.m_strCHECK_DAT;
            clsResultLogVO objResultLogVO = null;
            lngRes = 0;
            lngRes = new clsDomainController_CheckResultManage().m_lngQueryBindByAppointment(strDeviceID, strDeviceSampleID, strCheckDate, out objResultLogVO);
            /// 小于等于 0 : 查询失败;
            /// 1:成功且找到仪器样本;
            /// 100: 无可绑定的仪器样本;
            /// 300: 指定的仪器样本号无历史记录;
            /// 400: 指定的仪器样本号无结果;
            /// 其它: 成功返回
            if (lngRes == 100)
            {
                p_objRelationVO.m_intSTATUS_INT = 1;
            }
            else if (lngRes == 1)
            {
                p_objRelationVO.m_intSTATUS_INT = 2;
                p_objRelationVO.m_strCHECK_DAT = objResultLogVO.m_strCheckDat;
                p_objRelationVO.m_strDEVICEID_CHR = objResultLogVO.m_strDeviceID;
                p_objRelationVO.m_strDEVICE_SAMPLEID_CHR = objResultLogVO.m_strDeviceSampleID;
                p_objRelationVO.m_intIMPORT_REQ_INT = int.Parse(objResultLogVO.m_strIMPORT_REQ_INT);
            }
            else
            {
                return 0;
            }
            return 1;
        }
        #endregion

        #region 选定报告组

        public long m_lngSelectReport(string p_strAppID, string p_strOriginDate, out clsLISInfoVO p_objAppInfo)
        {
            p_objAppInfo = null;
            long lngRes = 0;
            clsDomainController_ApplicationManage objDomain = new clsDomainController_ApplicationManage();
            try
            {
                lngRes = objDomain.m_lngGetLISInfoByApplicationID(p_strAppID, p_strOriginDate, out p_objAppInfo);
                if (lngRes <= 0)
                {
                    p_objAppInfo = null;
                }
            }
            catch
            {
                p_objAppInfo = null;
                lngRes = 0;
            }
            this.m_objLISInfoVO = p_objAppInfo;
            return lngRes;
        }

        public long m_lngGetCheckItemResults(int p_intSampleStatus, string p_strAppID, string p_strOringinDate)
        {
            DataTable dtbResult = m_dtbResult;
            dtbResult.Rows.Clear();


            DataTable dtbResultSample = null;

            #region 提取数据

            if (p_intSampleStatus == 3)
            {
                long lngRes = new clsDomainController_CheckResultManage().m_lngGetCheckResultTable(
                    p_strAppID, p_strOringinDate, false, out dtbResultSample);
                if (lngRes <= 0 || dtbResultSample == null)
                {
                    return lngRes;
                }
                this.m_mthDataProcess(dtbResultSample);
            }
            if (p_intSampleStatus == 5 || p_intSampleStatus == 6)
            {
                long lngRes = new clsDomainController_CheckResultManage().m_lngGetCheckResultTable(
                    p_strAppID, p_strOringinDate, true, out dtbResultSample);
                if (lngRes <= 0 || dtbResultSample == null)
                {
                    return lngRes;
                }
            }
            #endregion

            #region 设置计算项目
            if (dtbResultSample != null)
            {
                foreach (DataRow dtr in dtbResultSample.Rows)
                {
                    if (dtr["is_calculated_chr"].ToString().Trim() == "1")
                    {
                        string strSampleGroupID = dtr["groupid_chr"].ToString().Trim();
                        string strFormula = dtr["formula_vchr"].ToString().Trim();
                        ArrayList arlItemID = null;
                        clsExpressionEvaluate.m_mthGetCheckItemIDArrInFromula(strFormula, out arlItemID);
                        if (arlItemID != null)
                        {
                            string[] strItemIDArr = (string[])arlItemID.ToArray(typeof(string));
                            for (int i = 0; i < strItemIDArr.Length; i++)
                            {
                                foreach (DataRow dtr2 in dtbResultSample.Rows)
                                {
                                    if (dtr2["check_item_id_chr"].ToString().Trim() == strItemIDArr[i].Trim()
                                        && dtr2["groupid_chr"].ToString().Trim() == strSampleGroupID)
                                    {
                                        string strEffItemID = dtr2["eff_caculate_id_chr"].ToString().Trim();
                                        strEffItemID = strEffItemID + "|" + dtr["check_item_id_chr"].ToString().Trim();
                                        dtr2["eff_caculate_id_chr"] = strEffItemID.Trim();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            dtbResultSample.AcceptChanges();
            if (dtbResultSample != null)
            {
                dtbResultSample.ColumnChanged += new DataColumnChangeEventHandler(m_mthResultListColumnChanged);
                foreach (DataRow dtr in dtbResultSample.Rows)
                {
                    dtr["result_vchr"] = dtr["result_vchr"];
                }
            }
            foreach (DataRow objRow in dtbResultSample.Rows)
            {
                dtbResult.ImportRow(objRow);
            }
            dtbResult.AcceptChanges();
            this.m_objViewer.m_dtgResultList.CurrentRowIndex = 0;
            m_mthShowGraph(dtbResult);
            return 1;
        }

        #region HJ500

        internal List<clsT_LIS_DeviceRelationVO> GetHJ500DeviceResult(string barCode, int sampleStatus, bool isForeImportData)
        {
            string Sql = string.Empty;
            List<clsT_LIS_DeviceRelationVO> dataDevice = new List<clsT_LIS_DeviceRelationVO>();
            try
            {
                Sql = @"select a.自定序号, a.检测时间, b.*
                          from JianCe a
                         inner join JianChaJieGuo b
                            on a.文件路径 = b.文件路径
                         where (a.状态 = '完成' or a.状态 = '打印')
                           and a.条码标识 = '{0}'";

                Sql = string.Format(Sql, barCode);
                DataTable dt = this.GetDataTable(Sql);
                if (dt != null && dt.Rows.Count > 0)
                {
                    string Hj500Config = Application.StartupPath + "\\hj500.xml";
                    if (File.Exists(Hj500Config))
                    {
                        DataTable dtConfig = null;
                        DataSet ds = new DataSet();
                        ds.ReadXml(Hj500Config);
                        if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                        {
                            dtConfig = ds.Tables[0];
                        }
                        else
                        {
                            return dataDevice;
                        }
                        List<string> lstField = new List<string>();
                        Dictionary<string, string> dicField = new Dictionary<string, string>();
                        for (int i = 0; i < dtConfig.Columns.Count; i++)
                        {
                            if (dtConfig.Columns[i].ColumnName == "dbConn")
                            {
                                continue;
                            }
                            else
                            {
                                if (dtConfig.Rows[0][i] != DBNull.Value && !string.IsNullOrEmpty(dtConfig.Rows[0][i].ToString()))
                                {
                                    lstField.Add(dtConfig.Columns[i].ColumnName);
                                    dicField.Add(dtConfig.Columns[i].ColumnName, dtConfig.Rows[0][i].ToString().Trim());
                                }
                            }
                        }
                        if (lstField.Count > 0)
                        {
                            clsDeviceReslutVO vo = null;
                            List<clsDeviceReslutVO> data = new List<clsDeviceReslutVO>();
                            DataRow drData = dt.Rows[0];
                            int idx = 0;
                            string info = "";
                            foreach (string fieldName in lstField)
                            {
                                vo = new clsDeviceReslutVO();
                                vo.m_strAbnormalFlag = "";
                                vo.m_strCheckDat = Convert.ToDateTime(drData["检测时间"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                                vo.m_strDeviceCheckItemName = dicField[fieldName];
                                vo.m_strDeviceID = "000048";
                                vo.m_strDeviceSampleID = drData["自定序号"].ToString();
                                vo.m_strIdx = Convert.ToString(++idx);
                                vo.m_strMaxVal = string.Empty;    //dtbResult.Rows[i]["MAX_VAL_DEC"].ToString().Trim();
                                vo.m_strMinVal = string.Empty;    //dtbResult.Rows[i]["MIN_VAL_DEC"].ToString().Trim();
                                //vo.m_strPstatus = dtbResult.Rows[i]["PSTATUS_INT"].ToString().Trim();
                                vo.m_strRefRange = string.Empty;    //dtbResult.Rows[i]["REFRANGE_VCHR"].ToString().Trim();
                                vo.m_strResult = drData[fieldName].ToString();
                                //vo.m_strUnit = dtbResult.Rows[i]["UNIT_VCHR"].ToString().Trim();
                                data.Add(vo);

                                info += vo.m_strDeviceCheckItemName + "    " + vo.m_strResult + Environment.NewLine;
                            }
                            //MessageBox.Show(info);
                            if (data.Count > 0)
                            {
                                if (sampleStatus == 3)
                                {
                                    this.m_mthSetDeviceData(this.m_dtbResult, data.ToArray());
                                }
                                else if (sampleStatus == 5 || sampleStatus == 6)
                                {
                                    if (isForeImportData)
                                    {
                                        this.m_mthSetDeviceData(this.m_dtbResult, data.ToArray());
                                    }
                                    else
                                    {
                                        this.m_mthSetDeviceDataNoImport(m_dtbResult, data.ToArray());
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常信息");
            }
            return dataDevice;
        }
        #endregion

        #region Dac.GetDataTable
        /// <summary>
        /// Dac.GetDataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            DataTable dtRecord = null;
            string Hj500Config = Application.StartupPath + "\\hj500.xml";
            if (File.Exists(Hj500Config))
            {
                DataTable dtConfig = null;
                DataSet ds = new DataSet();
                ds.ReadXml(Hj500Config);
                if (ds != null && ds.Tables != null && ds.Tables.Count > 0)
                {
                    dtConfig = ds.Tables[0];
                }
                else
                {
                    return dtRecord;
                }

                // 连接参数
                string conn = dtConfig.Rows[0]["dbConn"].ToString();
                SqlConnection con = new SqlConnection(conn);
                SqlCommand cmd = new SqlCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                cmd.CommandTimeout = 3000;
                try
                {
                    cmd.CommandText = sql;
                    SqlDataReader sqlReader = cmd.ExecuteReader();
                    dtRecord = new DataTable();
                    dtRecord.Load(sqlReader);
                    sqlReader.Close();
                }
                catch (System.Exception objEx)
                {
                    dtRecord = null;
                    throw objEx;
                }
                finally
                {
                    if (cmd != null)
                    {
                        cmd.Connection.Close();
                        cmd.Dispose();
                    }
                }
            }
            return dtRecord;
        }
        #endregion

        public long m_lngGetDeviceRelationAndData(string p_strAppID, int p_intSampleStatus, bool p_blnForceImportData, out clsT_LIS_DeviceRelationVO[] p_objDRVOArr)
        {
            p_objDRVOArr = null;
            long lngRes = 0;
            clsDomainController_CheckResultManage objDomain = new clsDomainController_CheckResultManage();
            try
            {
                lngRes = objDomain.m_lngGetDeviceRelationByAppID(p_strAppID, out p_objDRVOArr);
                if (lngRes <= 0)
                {
                    p_objDRVOArr = null;
                }
            }
            catch
            {
                p_objDRVOArr = null;
                lngRes = 0;
            }
            if (p_objDRVOArr != null)
            {
                for (int i = 0; i < p_objDRVOArr.Length; i++)
                {
                    if (p_objDRVOArr[i].m_intSTATUS_INT == 2)
                    {
                        clsDeviceReslutVO[] objDeviceResultVOArr = null;
                        long lngRes1 = new clsDomainController_CheckResultManage().m_lngGetDeviceData(
                            p_objDRVOArr[i].m_strDEVICEID_CHR,
                            p_objDRVOArr[i].m_intIMPORT_REQ_INT,
                            out objDeviceResultVOArr);

                        if (p_intSampleStatus == 3
                            && objDeviceResultVOArr != null
                            && objDeviceResultVOArr.Length > 0)
                        {
                            this.m_mthSetDeviceData(this.m_dtbResult, objDeviceResultVOArr);
                        }
                        if ((p_intSampleStatus == 5 ||
                            p_intSampleStatus == 6)
                            && objDeviceResultVOArr != null
                            && objDeviceResultVOArr.Length > 0)
                        {
                            if (p_blnForceImportData)
                            {
                                this.m_mthSetDeviceData(this.m_dtbResult, objDeviceResultVOArr);
                            }
                            else
                            {
                                this.m_mthSetDeviceDataNoImport(m_dtbResult, objDeviceResultVOArr);
                            }
                        }
                    }
                }
            }
            return lngRes;
        }

        #endregion

        #region Ottoman

        internal List<clsT_LIS_DeviceRelationVO> GetOttomanDeviceResult(string barCode, int sampleStatus, bool isForeImportData)
        {
            List<clsT_LIS_DeviceRelationVO> dataDevice = new List<clsT_LIS_DeviceRelationVO>();
            try
            {
                List<clsDeviceReslutVO> data = null;
                using (com.digitalwave.iCare.middletier.LIS.clsQueryLIS_Svc svc = (com.digitalwave.iCare.middletier.LIS.clsQueryLIS_Svc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryLIS_Svc)))
                {
                    //data = svc.GetOttomanCheckResult(barCode);
                }
                if (data != null && data.Count > 0)
                {
                    if (sampleStatus == 3)
                    {
                        this.m_mthSetDeviceData(this.m_dtbResult, data.ToArray());
                    }
                    else if (sampleStatus == 5 || sampleStatus == 6)
                    {
                        if (isForeImportData)
                        {
                            this.m_mthSetDeviceData(this.m_dtbResult, data.ToArray());
                        }
                        else
                        {
                            this.m_mthSetDeviceDataNoImport(m_dtbResult, data.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "异常信息");
            }
            return dataDevice;
        }
        #endregion

        #region 显示图形
        private void m_mthShowGraph(DataTable p_dtbResult)
        {
            DataTable dtbResult = p_dtbResult;
            int intImageIdx = 0;
            foreach (DataRow objRow in dtbResult.Rows)
            {
                this.m_objViewer.m_lsvGraph.BeginUpdate();
                if (objRow["resulttype_chr"].ToString() == "3" && objRow["graph_img"] != System.DBNull.Value)
                {
                    System.Windows.Forms.ListViewItem lvt = new ListViewItem(objRow["check_item_name_vchr"].ToString());

                    byte[] bytGraph = (byte[])objRow["graph_img"];
                    System.IO.MemoryStream ms = null;
                    try
                    {
                        ms = new System.IO.MemoryStream(bytGraph);
                        System.Drawing.Image img = Image.FromStream(ms, true);
                        string strFormat = objRow["graph_format_name_vchr"].ToString().Trim().ToLower();
                        System.Drawing.Bitmap bm = null;
                        System.Drawing.Graphics g = null;
                        System.IO.MemoryStream fs = null;
                        switch (strFormat)
                        {
                            case "lisb":
                                bm = new Bitmap(256, 256);
                                bm.MakeTransparent(Color.White);
                                g = System.Drawing.Graphics.FromImage(bm);
                                g.FillRectangle(Brushes.White, 0, 0, 118, 256);
                                g.FillRectangle(Brushes.White, 137, 0, 119, 256);
                                g.DrawImage(img, new System.Drawing.Rectangle(117, 0, 20, 256));
                                //								fs = System.IO.File.Open(@"LISTemp.bmp",System.IO.FileMode.Create,System.IO.FileAccess.Write);
                                fs = new System.IO.MemoryStream();
                                bm.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                                bm.Dispose();
                                img.Dispose();
                                img = Image.FromStream(fs, true);
                                //								fs.Close();
                                break;
                            default:
                                bm = new Bitmap(256, 256);
                                g = System.Drawing.Graphics.FromImage(bm);
                                g.DrawImage(img, new System.Drawing.Rectangle(0, 0, 256, 256));
                                //								fs = System.IO.File.Open(@"LISTemp.bmp",System.IO.FileMode.Create,System.IO.FileAccess.Write);
                                fs = new System.IO.MemoryStream();

                                bm.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                                //								fs.Close();
                                bm.Dispose();
                                img.Dispose();
                                //								img = Image.FromFile(@"LISTemp.bmp",true);
                                img = Image.FromStream(fs, true);
                                //								fs.Close();

                                break;
                        }
                        intImageIdx = this.m_objViewer.m_imgGraphList.Images.Add(img, Color.White);
                        if (intImageIdx != -1)
                        {
                            lvt.ImageIndex = intImageIdx;
                            this.m_objViewer.m_lsvGraph.Items.Add(lvt);
                        }
                    }
                    catch
                    {
                    }
                    finally
                    {
                        if (ms != null)
                            ms.Close();
                    }
                }
                this.m_objViewer.m_lsvGraph.EndUpdate();
                this.m_objViewer.m_lsvGraph.Refresh();
            }
        }
        #endregion

        #region [U]保存报告
        public long m_lngSaveReport(clsT_OPR_LIS_APP_REPORT_VO p_objReportVO)
        {
            bool blnConfirm = false;
            if (this.m_objLISInfoVO.m_objSampleVO.m_intSTATUS_INT == 6)
            {
                blnConfirm = true;
            }
            long lngRes1 = 0;
            lngRes1 = m_lngSaveReportInfo(p_objReportVO);
            if (lngRes1 == 1)
            {
                this.m_objLISInfoVO.m_objReportVO = p_objReportVO;
            }

            long lngRes2 = 0;
            lngRes2 = m_lngSaveResultInfo();
            if (lngRes2 == 1)
            {
                if (this.m_objLISInfoVO.m_objSampleVO.m_intSTATUS_INT == 3)
                    this.m_objLISInfoVO.m_objSampleVO.m_intSTATUS_INT = 5;
                if (this.m_objLISInfoVO.m_objAppMainVO.m_intSampleStatus == 3)
                    this.m_objLISInfoVO.m_objAppMainVO.m_intSampleStatus = 5;
            }
            if (lngRes1 <= 0 || lngRes2 <= 0)
                return 0;
            else if (blnConfirm)
            {
                long lngRes = 0;
                clsPrintValuePara objPrintInfo = null;
                clsDomainController_CheckResultManage objDomain = new clsDomainController_CheckResultManage();
                lngRes = objDomain.m_lngGetReportPrintInfo(this.m_objLISInfoVO.m_objReportVO.m_strREPORT_GROUP_ID_CHR,
                    this.m_objLISInfoVO.m_objAppMainVO.m_strAPPLICATION_ID, false,
                    out objPrintInfo);

                if (objPrintInfo != null)
                {
                    System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    formatter.Serialize(stream, objPrintInfo);
                    byte[] bytReportObjectArr = stream.GetBuffer();
                    stream.Close();

                    clsReportObject objReportObject = new clsReportObject();
                    objReportObject.strApplicationID = this.m_objLISInfoVO.m_objAppMainVO.m_strAPPLICATION_ID;
                    objReportObject.bytReportObjectArr = bytReportObjectArr;
                    clsDomainController_ApplicationManage objAppDomain = new clsDomainController_ApplicationManage();

                    lngRes = 0;
                    lngRes = objAppDomain.m_lngUpdatePEReg(objReportObject.strApplicationID);
                    lngRes = objAppDomain.m_lngUpdateReportObject(objReportObject);
                }
            }
            return 1;
        }

        private long m_lngSaveReportInfo(clsT_OPR_LIS_APP_REPORT_VO p_objReportVO)
        {
            long lngRes = 1;
            if (p_objReportVO.m_strREPORTOR_ID_CHR != this.m_objLISInfoVO.m_objReportVO.m_strREPORTOR_ID_CHR
                || p_objReportVO.m_strREPORT_DAT != this.m_objLISInfoVO.m_objReportVO.m_strREPORT_DAT
                || p_objReportVO.m_strSUMMARY_VCHR != this.m_objLISInfoVO.m_objReportVO.m_strSUMMARY_VCHR
                || p_objReportVO.m_strANNOTATION_VCHR != this.m_objLISInfoVO.m_objReportVO.m_strANNOTATION_VCHR
                || p_objReportVO.m_strXML_SUMMARY_VCHR != this.m_objLISInfoVO.m_objReportVO.m_strXML_SUMMARY_VCHR
                || p_objReportVO.m_strXML_ANNOTATION_VCHR != this.m_objLISInfoVO.m_objReportVO.m_strXML_ANNOTATION_VCHR)
            {
                clsT_OPR_LIS_APP_REPORT_VO[] objAppReportArr = new clsT_OPR_LIS_APP_REPORT_VO[1];
                objAppReportArr[0] = p_objReportVO;
                lngRes = 0;
                try
                {
                    lngRes = new clsDomainController_ApplicationManage().m_lngInsertAppReportRecord(objAppReportArr);
                }
                catch
                {
                    lngRes = 0;
                }
            }
            return lngRes;
        }
        private long m_lngSaveResultInfo()
        {
            long lngRes = 0;
            DataTable dtbResult = this.m_dtbResult;
            bool blnIsNewOrModify = false;
            System.Collections.Hashtable objHasSampleID = new Hashtable();
            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                if (dtbResult.Rows[i]["new_result"].ToString().Trim() == "1"
                    || dtbResult.Rows[i]["modify_flag"].ToString().Trim() == "1")
                {
                    blnIsNewOrModify = true;
                }
                if (!objHasSampleID.ContainsKey(dtbResult.Rows[i]["sample_id_chr"].ToString().Trim()))
                {
                    objHasSampleID.Add(dtbResult.Rows[i]["sample_id_chr"].ToString().Trim(), 1);
                }
            }

            // 需要特殊处理的项目的EnglishName， BG为ABO血型
            string strTemp = null;
            lngRes = m_lngExcItemManage(m_strExcItemEnglishName, dtbResult, out strTemp);
            if (lngRes <= 0)
                return lngRes;

            if (!blnIsNewOrModify)
                return 1;

            ArrayList arlVOArr = new ArrayList();
            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                clsCheckResult_VO objResult = new clsCheckResult_VO();
                #region
                if (dtbResult.Rows[i]["graph_img"] != DBNull.Value)
                {
                    objResult.m_byaGraph = (byte[])dtbResult.Rows[i]["graph_img"];
                }
                if (dtbResult.Rows[i]["IS_GRAPH_RESULT_NUM"] != DBNull.Value)
                {
                    objResult.intIsGraphResult = Convert.ToInt32(dtbResult.Rows[i]["IS_GRAPH_RESULT_NUM"].ToString().Trim());
                }
                objResult.strGraphFormatName = dtbResult.Rows[i]["graph_format_name_vchr"].ToString();
                objResult.m_intStatus = 1;
                objResult.m_strAbnormal_Flag = dtbResult.Rows[i]["ABNORMAL_FLAG_CHR"].ToString().Trim();
                //					objResult.m_strCheck_Dat = 1;
                //					objResult.m_strCheck_DeptID = 1;
                //					objResult.m_strCheck_Item_English_Name = 1;
                objResult.m_strCheck_Item_ID = dtbResult.Rows[i]["check_item_id_chr"].ToString().Trim();
                objResult.m_strCheck_Item_Name = dtbResult.Rows[i]["rptno_chr"].ToString().Trim();
                //					objResult.m_strChecker1 = 1;
                //					objResult.m_strChecker2 = 1;
                //					objResult.m_strClinicApp = 1;
                //					objResult.m_strConfirm_Dat = 1;
                //					objResult.m_strConfirm_Person = 1;
                objResult.m_strDevice_Check_Item_Name = dtbResult.Rows[i]["device_check_item_name_vchr"].ToString().Trim();
                //					objResult.m_strDeviceID = 1;
                objResult.m_strGroupID = dtbResult.Rows[i]["groupid_chr"].ToString().Trim();
                objResult.m_strMax_Val = dtbResult.Rows[i]["MAX_VAL_DEC"].ToString().Trim();
                //					objResult.m_strMemo = 1;
                objResult.m_strMin_Val = dtbResult.Rows[i]["MIN_VAL_DEC"].ToString().Trim();
                //					objResult.m_strModify_Dat = 1;
                objResult.m_strOperator_ID = this.m_strGetOprator();
                objResult.m_strPointliststr = null;
                objResult.m_strRefrange = dtbResult.Rows[i]["REFRANGE_VCHR"].ToString().Trim();
                objResult.m_strResult = dtbResult.Rows[i]["RESULT_VCHR"].ToString().Trim();
                objResult.m_strSample_ID = dtbResult.Rows[i]["sample_id_chr"].ToString().Trim(); ;
                //					objResult.m_strSummary = 1;
                objResult.m_strUnit = dtbResult.Rows[i]["UNIT_VCHR"].ToString().Trim();
                #endregion
                arlVOArr.Add(objResult);
            }
            clsCheckResult_VO[] objResultArr = (clsCheckResult_VO[])arlVOArr.ToArray(typeof(clsCheckResult_VO));

            string[] strSampleArr = new string[objHasSampleID.Count];
            objHasSampleID.Keys.CopyTo(strSampleArr, 0);

            lngRes = new clsDomainController_CheckResultManage().m_lngAddCheckResultList(objResultArr, strSampleArr, this.m_objLISInfoVO.m_objAppMainVO.m_strOriginDate);

            if (lngRes > 0)
            {
                this.m_dtbResult.AcceptChanges();
                #region 关标志
                for (int i = 0; i < dtbResult.Rows.Count; i++)
                {
                    dtbResult.Rows[i]["new_result"] = 0;
                    dtbResult.Rows[i]["modify_flag"] = 0;
                }
                #endregion
            }
            return lngRes;
        }

        /// <summary>
        /// 需要特殊处理的项目，如：血型等
        /// </summary>
        /// <param name="p_strExcItemArr"></param>
        /// <param name="p_dtResult"></param>
        /// <param name="p_strExcMsg"></param>
        /// <returns></returns>
        private long m_lngExcItemManage(string p_strExcItemEnglishName, DataTable p_dtResult, out string p_strExcMsg)
        {
            p_strExcMsg = string.Empty;
            long lngRes = 1;
            //if (string.IsNullOrEmpty(p_strExcItemEnglishName))
            //    return 1;

            if (m_objLISInfoVO == null || m_objLISInfoVO.m_objAppMainVO == null)
                return 1;

            List<string> lstEngName = new List<string>() { "BG", "RH" };
            foreach (string engName in lstEngName)
            {
                DataRow[] drArr = p_dtResult.Select("item_english_name = '" + engName + "'");
                if (drArr != null && drArr.Length > 0)
                {
                    string strCurrentResult = drArr[0]["RESULT_VCHR"].ToString().Trim();
                    string strExcItemID = drArr[0]["check_item_id_chr"].ToString().Trim();

                    if (strCurrentResult == "\\") continue;
                    DataTable dtResult = null;
                    lngRes = new clsDomainController_CheckResultManage().m_lngQueryPatientExcItemResult(m_objLISInfoVO.m_objAppMainVO.m_strPatientID, strExcItemID, out dtResult);
                    if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
                    {
                        DataRow dr = dtResult.Rows[0];
                        string strLastResult = dr["result_vchr"].ToString().Trim();
                        if (strLastResult == "\\") continue;
                        if (!string.IsNullOrEmpty(strLastResult))
                        {
                            if (strCurrentResult.CompareTo(strLastResult) != 0)
                            {
                                p_strExcMsg += dr["rptno_chr"].ToString().Trim() + " 最近一次检验结果为：" + strLastResult + "\r\n";
                            }
                        }
                    }
                }
            }
            if (p_strExcMsg != string.Empty)
            {
                string msg = p_strExcMsg + "与这次检验结果不相符，是否继续？";
                if (MessageBox.Show(msg, c_strMessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return 1;
            }
        }

        #endregion

        #region 确认报告

        /// <summary>
        /// 当前项目结果是否完整
        /// </summary>
        /// <returns></returns>
        public bool m_BlnResultIsFull()
        {
            bool blnRes = true;
            DataTable dtbResult = this.m_dtbResult;
            for (int i = 0; i < dtbResult.Rows.Count; i++)
            {
                if (dtbResult.Rows[i]["RESULT_VCHR"].ToString().Trim() == "" && dtbResult.Rows[i]["IS_GRAPH_RESULT_NUM"].ToString() != "1")
                {
                    blnRes = false;
                    break;
                }
            }
            return blnRes;
        }

        #region CheckSexAndAge
        /// <summary>
        /// 性别与年龄判断
        /// </summary>
        /// <returns></returns>
        bool CheckSexAndAge(DataRow drRef)
        {
            if (drRef["is_sex_related_chr"].ToString() == "1")
            {
                if (drRef["is_age_related_chr"].ToString() == "1" && this.m_objLISInfoVO.m_objSampleVO.m_strSEX_CHR == drRef["sex_vchr"].ToString())
                {
                    string[] ageArr = this.m_objLISInfoVO.m_objSampleVO.m_strAGE_CHR.Split(new char[] { ' ' });
                    if (ageArr != null && ageArr.Length == 2)
                    {
                        string[] fromAgeArr = drRef["from_age_dec"].ToString().Trim().Split(new char[] { ' ' });
                        int fromAge = 0;
                        int toAge = 0;
                        if (fromAgeArr[1].Trim() == ageArr[1].Trim())
                        {
                            if (fromAgeArr != null && fromAgeArr.Length == 2)
                            {
                                fromAge = int.Parse(fromAgeArr[0]);
                            }
                        }
                        string[] toAgeArr = drRef["to_age_dec"].ToString().Trim().Split(new char[] { ' ' });
                        if (fromAgeArr[1].Trim() == ageArr[1].Trim())
                        {
                            if (toAgeArr != null && toAgeArr.Length == 2)
                            {
                                toAge = int.Parse(toAgeArr[0]);
                            }
                        }
                        if (fromAge <= int.Parse(ageArr[0].Trim()) && int.Parse(ageArr[0].Trim()) <= toAge)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                string[] ageArr = this.m_objLISInfoVO.m_objSampleVO.m_strAGE_CHR.Split(new char[] { ' ' });
                if (ageArr != null && ageArr.Length == 2)
                {
                    string[] fromAgeArr = drRef["from_age_dec"].ToString().Trim().Split(new char[] { ' ' });
                    int fromAge = 0;
                    int toAge = 0;
                    if (fromAgeArr[1].Trim() == ageArr[1].Trim())
                    {
                        if (fromAgeArr != null && fromAgeArr.Length == 2)
                        {
                            fromAge = int.Parse(fromAgeArr[0]);
                        }
                    }
                    string[] toAgeArr = drRef["to_age_dec"].ToString().Trim().Split(new char[] { ' ' });
                    if (fromAgeArr[1].Trim() == ageArr[1].Trim())
                    {
                        if (toAgeArr != null && toAgeArr.Length == 2)
                        {
                            toAge = int.Parse(toAgeArr[0]);
                        }
                    }
                    if (fromAge <= int.Parse(ageArr[0].Trim()) && int.Parse(ageArr[0].Trim()) <= toAge)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        public long m_lngConfirmReport(string p_strConfirmID, DateTime p_strConfirmDate)
        {
            #region 作废未绑定的关联
            if (this.m_objLISInfoVO.m_objDRVOArr != null)
            {
                int i = 0;
                while (i < this.m_objLISInfoVO.m_objDRVOArr.Count)
                {
                    clsT_LIS_DeviceRelationVO objDRVO = (clsT_LIS_DeviceRelationVO)this.m_objLISInfoVO.m_objDRVOArr[i];
                    if (objDRVO.m_intSTATUS_INT == 1)
                    {
                        this.m_objLISInfoVO.m_objDRVOArr.Remove(objDRVO);
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            #endregion

            bool blnNew = true;
            //if (this.m_objLISInfoVO.m_objSampleVO.m_intSTATUS_INT == 3)
            //{
            //    blnNew = true;
            //}

            #region 危急值
            if (this.m_dtbResult != null && this.m_dtbResult.Rows.Count > 0)
            {
                bool isYes = false;
                bool isRef = false;
                bool isYG = false;  // 院感
                DataRow[] drrRef = null;
                EntityCriticalLis vo = null;
                List<EntityCriticalLis> lstVo = new List<EntityCriticalLis>();
                foreach (DataRow dr in this.m_dtbResult.Rows)
                {
                    isYes = false;
                    isRef = false;
                    try
                    {
                        if (dr["result_vchr"] != DBNull.Value && dr["resulttype_chr"].ToString().Trim() == "0")  // 数值型
                        {
                            #region 先找检验项目参考信息表
                            if (DataSourceItemRef != null && DataSourceItemRef.Rows.Count > 0)
                            {
                                drrRef = DataSourceItemRef.Select("trim(check_item_id_chr) = '" + dr["check_item_id_chr"].ToString().Trim() + "'");
                                if (drrRef != null && drrRef.Length > 0)
                                {
                                    isRef = true;
                                    string strResult = string.Empty;
                                    foreach (DataRow drRef in drrRef)
                                    {
                                        strResult = dr["result_vchr"].ToString();
                                        if (strResult.IndexOf("E+") < 0)
                                        {
                                            strResult = strResult.Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                                            strResult = strResult.Replace(">", "").Replace(">=", "").Replace(">>", "").Replace("》", "").Replace("＞", "").Replace("≥", "");
                                        }
                                        string strResultMin = string.Empty;
                                        if (drRef["crvalmin"] != System.DBNull.Value)
                                        {
                                            strResultMin = drRef["crvalmin"].ToString().Trim();
                                            if (strResultMin.IndexOf("E+") < 0)
                                            {
                                                strResultMin = strResultMin.Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                                                strResultMin = strResultMin.Replace(">", "").Replace(">=", "").Replace("》", "").Replace(">>", "").Replace("＞", "").Replace("≥", "");
                                            }
                                            else
                                            {
                                                if (strResultMin.IndexOf(">") < 0) strResultMin = ">" + strResultMin;
                                            }
                                        }
                                        string strResultMax = string.Empty;
                                        if (drRef["crvalmax"] != System.DBNull.Value)
                                        {
                                            strResultMax = drRef["crvalmax"].ToString().Trim();
                                            if (strResultMax.IndexOf("E+") < 0)
                                            {
                                                strResultMax = strResultMax.Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                                                strResultMax = strResultMax.Replace(">", "").Replace(">=", "").Replace("》", "").Replace(">>", "").Replace("＞", "").Replace("≥", "");
                                            }
                                            else
                                            {
                                                if (strResultMax.IndexOf("<") < 0) strResultMax = "<" + strResultMax;
                                            }
                                        }
                                        if (strResult.IndexOf("E+") >= 0)
                                        {
                                            string rinfo = string.Empty;
                                            try
                                            {
                                                if (strResultMin.IndexOf("E+") >= 0 && strResultMax.IndexOf("E+") >= 0)
                                                {
                                                    rinfo = CMPdata(strResult, strResultMin, strResultMax);
                                                }
                                                else
                                                {
                                                    if (strResultMin.IndexOf("E+") >= 0)
                                                        rinfo = CMPdata(strResult, strResultMin);
                                                    else if (strResultMax.IndexOf("E+") >= 0)
                                                        rinfo = CMPdata(strResult, strResultMax);
                                                }
                                            }
                                            catch { }
                                            if (rinfo == "偏高")
                                                rinfo = "H";
                                            else if (rinfo == "偏低")
                                                rinfo = "L";
                                            else
                                                rinfo = string.Empty;
                                            if (rinfo == "H" || rinfo == "L")
                                            {
                                                if (CheckSexAndAge(drRef))
                                                {
                                                    dr["alert_flag"] = "L";
                                                    dr["alarm_low_val_vchr"] = drRef["crvalmin"];
                                                    dr["alarm_up_val_vchr"] = drRef["crvalmax"];
                                                    isYes = true;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (drRef["crvalmin"] != DBNull.Value && !string.IsNullOrEmpty(drRef["crvalmin"].ToString().Trim()) && double.Parse(strResult) < double.Parse(strResultMin))
                                            {
                                                if (CheckSexAndAge(drRef))
                                                {
                                                    dr["alert_flag"] = "L";
                                                    dr["alarm_low_val_vchr"] = drRef["crvalmin"];
                                                    dr["alarm_up_val_vchr"] = drRef["crvalmax"];
                                                    isYes = true;
                                                }
                                            }
                                            if (drRef["crvalmax"] != DBNull.Value && !string.IsNullOrEmpty(drRef["crvalmax"].ToString().Trim()) && double.Parse(strResult) > double.Parse(strResultMax))
                                            {
                                                if (CheckSexAndAge(drRef))
                                                {
                                                    dr["alert_flag"] = "H";
                                                    dr["alarm_low_val_vchr"] = drRef["crvalmin"];
                                                    dr["alarm_up_val_vchr"] = drRef["crvalmax"];
                                                    isYes = true;
                                                }
                                            }
                                        }
                                        if (isYes)
                                        {
                                            if (DataSourceItemRefDept != null && DataSourceItemRefDept.Rows.Count > 0)
                                            {
                                                DataRow[] drr2 = DataSourceItemRefDept.Select("check_item_id_chr = '" + dr["check_item_id_chr"].ToString().Trim() + "' and seq_int = " + drRef["seq_int"].ToString());
                                                if (drr2 != null && drr2.Length > 0)
                                                {
                                                    isYes = false;
                                                    foreach (DataRow dr2 in drr2)
                                                    {
                                                        if (dr2["deptid_chr"].ToString() == dr["applyDeptId"].ToString())
                                                        {
                                                            isYes = true;
                                                            break;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        if (isYes)
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                            #endregion

                            #region 参考值中没有再找主记录
                            if (isYes == false && isRef == false)
                            {
                                string strResult = string.Empty;
                                strResult = dr["result_vchr"].ToString().Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                                strResult = strResult.Replace(">", "").Replace(">=", "").Replace(">>", "").Replace("》", "").Replace("＞", "").Replace("≥", "");
                                string strResultMin = string.Empty;
                                if (dr["alarm_low_val_vchr"] != System.DBNull.Value)
                                {
                                    strResultMin = dr["alarm_low_val_vchr"].ToString().Trim().Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                                    strResultMin = strResultMin.Replace(">", "").Replace(">=", "").Replace("》", "").Replace(">>", "").Replace("＞", "").Replace("≥", "");
                                }
                                string strResultMax = string.Empty;
                                if (dr["alarm_up_val_vchr"] != System.DBNull.Value)
                                {
                                    strResultMax = dr["alarm_up_val_vchr"].ToString().Trim().Replace("<", "").Replace("<=", "").Replace("<<", "").Replace("＜", "").Replace("≤", "");
                                    strResultMax = strResultMax.Replace(">", "").Replace(">=", "").Replace("》", "").Replace(">>", "").Replace("＞", "").Replace("≥", "");
                                }

                                if (strResult.IndexOf("E+") >= 0)
                                {
                                    string rinfo = string.Empty;
                                    try
                                    {
                                        if (strResultMin.IndexOf("E+") >= 0 && strResultMax.IndexOf("E+") >= 0)
                                        {
                                            rinfo = CMPdata(strResult, strResultMin, strResultMax);
                                        }
                                        else
                                        {
                                            if (strResultMin.IndexOf("E+") >= 0)
                                                rinfo = CMPdata(strResult, strResultMin);
                                            else if (strResultMax.IndexOf("E+") >= 0)
                                                rinfo = CMPdata(strResult, strResultMax);
                                        }
                                    }
                                    catch { }
                                    if (rinfo == "偏高")
                                        rinfo = "H";
                                    else if (rinfo == "偏低")
                                        rinfo = "L";
                                    else
                                        rinfo = string.Empty;
                                    if (rinfo == "H" || rinfo == "L")
                                    {
                                        dr["alert_flag"] = rinfo;
                                        isYes = true;
                                    }
                                }
                                else
                                {
                                    if (dr["alarm_low_val_vchr"] != DBNull.Value && !string.IsNullOrEmpty(dr["alarm_low_val_vchr"].ToString().Trim()) && double.Parse(strResult) < double.Parse(strResultMin))
                                    {
                                        dr["alert_flag"] = "L";
                                        isYes = true;
                                    }
                                    if (dr["alarm_up_val_vchr"] != DBNull.Value && !string.IsNullOrEmpty(dr["alarm_up_val_vchr"].ToString().Trim()) && double.Parse(strResult) > double.Parse(strResultMax))
                                    {
                                        dr["alert_flag"] = "H";
                                        isYes = true;
                                    }
                                }

                                if (isYes)
                                {
                                    if (DataSourceItemRefDept != null && DataSourceItemRefDept.Rows.Count > 0)
                                    {
                                        DataRow[] drr2 = DataSourceItemRefDept.Select("check_item_id_chr = '" + dr["check_item_id_chr"].ToString().Trim() + "'");
                                        if (drr2 != null && drr2.Length > 0)
                                        {
                                            isYes = false;
                                            foreach (DataRow dr2 in drr2)
                                            {
                                                if (dr2["deptid_chr"].ToString() == dr["applyDeptId"].ToString())
                                                {
                                                    isYes = true;
                                                    break;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                    }
                    catch
                    {
                        isYes = false;
                        continue;
                    }
                    if (isYes)
                    {
                        vo = new EntityCriticalLis();
                        vo.checkitemid = dr["check_item_id_chr"].ToString();
                        vo.checkitemname = dr["check_item_name_vchr"].ToString();
                        vo.checkitemengname = dr["item_english_name"].ToString();
                        vo.unit = dr["unit_vchr"].ToString();
                        vo.alarmlowval = dr["alarm_low_val_vchr"].ToString();
                        vo.alarmupval = dr["alarm_up_val_vchr"].ToString();
                        vo.resultvalue = dr["result_vchr"].ToString();
                        vo.alertflag = dr["alert_flag"].ToString();
                        if (string.IsNullOrEmpty(vo.checkitemname) && string.IsNullOrEmpty(vo.checkitemengname))
                        {
                            vo.checkitemname = dr[7].ToString();
                        }
                        lstVo.Add(vo);
                    }
                }
                #region 院感
                if (m_objViewer.m_rtbCheckSummary.Text.Trim() != string.Empty)
                {
                    #region 院感危急值
                    if (DataSourceItemRefYG != null && DataSourceItemRefYG.Rows.Count > 0)
                    {
                        string strResult = m_objViewer.m_rtbCheckSummary.Text.Trim();
                        if (strResult != "\\" && strResult.Length > 2)
                        {
                            foreach (DataRow dr3 in DataSourceItemRefYG.Rows)
                            {
                                if (strResult.IndexOf(dr3["refDesc"].ToString()) >= 0)
                                {
                                    isYG = true;
                                    vo = new EntityCriticalLis();
                                    vo.checkitemid = "99999";
                                    vo.checkitemname = "耐药菌结果";
                                    vo.resultvalue = dr3["refDesc"].ToString();
                                    lstVo.Add(vo);
                                    break;
                                }
                            }
                        }
                    }
                    #endregion
                }
                #endregion
                if (lstVo.Count > 0)
                {
                    EntityCriticalMain mainVo = new EntityCriticalMain();
                    mainVo.applyid = this.m_objLISInfoVO.m_objAppMainVO.m_strAPPLICATION_ID;
                    mainVo.applyitem = this.m_objLISInfoVO.m_objAppMainVO.m_strCheckContent;
                    mainVo.recorderid = this.m_objLISInfoVO.m_objReportVO.m_strREPORTOR_ID_CHR;  //p_strConfirmID; 1114. 危机值报告人由检验报告单审核人改为检验者。
                    mainVo.recorddate = p_strConfirmDate;
                    mainVo.patsubno = (isYG ? "YG" : "");
                    frmConfirmCriticalVal frmCC = new frmConfirmCriticalVal(mainVo, lstVo);
                    if (frmCC.ShowDialog() != DialogResult.OK)
                    {
                        // 1114 不做限制
                        //return -1;
                    }
                }
            }
            #endregion

            DateTime dtmConfirmDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            long lngRes = new clsDomainController_ApplicationManage().m_lngConfirmAppReport(
                this.m_objLISInfoVO.m_objAppMainVO.m_strAPPLICATION_ID, this.m_objLISInfoVO.m_objReportVO.m_strREPORT_GROUP_ID_CHR,
                p_strConfirmID, p_strConfirmDate);

            if (lngRes > 0)
            {
                this.m_objLISInfoVO.m_objReportVO.m_intSTATUS_INT = 2;
                this.m_objLISInfoVO.m_objReportVO.m_strCONFIRMER_ID_CHR = p_strConfirmID;
                this.m_objLISInfoVO.m_objReportVO.m_strCONFIRM_DAT = p_strConfirmDate.ToString("yyyy-MM-dd HH:mm:ss");

                this.m_objLISInfoVO.m_objSampleVO.m_intSTATUS_INT = 6;

                foreach (DataRow dr in this.m_dtbResult.Rows)
                {
                    dr["samplestatus"] = 6;
                }

                long lngRes1 = 0;
                clsPrintValuePara objPrintInfo = null;
                clsDomainController_CheckResultManage objDomain = new clsDomainController_CheckResultManage();
                lngRes1 = objDomain.m_lngGetReportPrintInfo(this.m_objLISInfoVO.m_objReportVO.m_strREPORT_GROUP_ID_CHR,
                    this.m_objLISInfoVO.m_objAppMainVO.m_strAPPLICATION_ID, false,
                    out objPrintInfo);

                if (objPrintInfo != null)
                {
                    System.Runtime.Serialization.IFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                    System.IO.MemoryStream stream = new System.IO.MemoryStream();
                    formatter.Serialize(stream, objPrintInfo);
                    byte[] bytReportObjectArr = stream.GetBuffer();
                    stream.Close();

                    clsReportObject objReportObject = new clsReportObject();
                    objReportObject.strApplicationID = this.m_objLISInfoVO.m_objAppMainVO.m_strAPPLICATION_ID;
                    objReportObject.bytReportObjectArr = bytReportObjectArr;
                    clsDomainController_ApplicationManage objAppDomain = new clsDomainController_ApplicationManage();

                    if (blnNew)
                    {
                        lngRes1 = 0;
                        lngRes1 = objAppDomain.m_lngInsertReportObject(objReportObject);
                    }
                    else
                    {
                        lngRes1 = 0;
                        lngRes1 = objAppDomain.m_lngUpdateReportObject(objReportObject);
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region		获取配置信息
        public long m_lngGetCollocate(out string p_strConfig, string p_strSetID)
        {
            p_strConfig = "";    //boajian.mo 2007/09/07 modify  加入"2-跳过采集不跳过核收"
            long lngRes = 0;
            try
            {
                lngRes = new clsDomainController_ApplicationManage().m_lngGetCollocate(out p_strConfig, p_strSetID);
                if (lngRes <= 0)
                {
                    return -1;
                }
            }
            catch
            {
                lngRes = 0;
                p_strConfig = "0";
            }
            return lngRes;
        }
        #endregion

        #region 作废申请单的样本
        public long m_lngBlankOutApplication(clsLisApplMainVO p_objApplMainVO, clsBlankOutApplicationVO p_objBlankOutInfo)
        {
            long lngRes = 0;
            lngRes = new clsDomainController_ApplicationManage().m_lngBlankOutApplication(p_objApplMainVO, p_objBlankOutInfo);
            return lngRes;
        }
        #endregion

        //*******************************************************************************************************

        #region 新增
        frmAppCheckContent frmCheckContent;
        public long m_lngNewApp(out clsLisApplMainVO p_objAppMainVO)
        {
            p_objAppMainVO = null;
            if (!m_blnCheckAppInfoValidate())
                return 0;

            clsLIS_App objAppInfo = m_objCollectAppInfo();

            if (!this.m_blnUseDefault || (this.m_objDefaultApplyUnits == null || this.m_objDefaultReports == null))
            {
                if (frmCheckContent == null)
                {
                    frmCheckContent = new frmAppCheckContent();
                }
                frmAppCheckContent frm = frmCheckContent;
                frm.m_mthClearChecked();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (frm.m_objController.m_objApps.Count == 0)
                        return 0;
                    if (frm.m_objController.m_objApps.Count > 1)
                    {
                        MessageBox.Show(this.m_objViewer, "您所选择的内容包含在不同的报告内,请重新选择!", c_strMessageBoxTitle);
                        return 0;
                    }

                    objAppInfo.m_ObjAppReports.AddRange(frm.m_objController.m_objAppReports);
                    objAppInfo.m_ObjAppApplyUnits.AddRange(frm.m_objController.m_objAppApplyUnits);
                }
                else
                    return 0;
            }
            else//使用前次值
            {
                for (int i = 0; i < this.m_objDefaultReports.Length; i++)
                {
                    clsLIS_AppCheckReport objReport = this.m_objDefaultReports[i];
                    objReport.m_ObjApp = null;
                    objReport.m_ObjDataVO.m_intSTATUS_INT = 1;
                    objReport.m_ObjDataVO.m_strAPPLICATION_ID_CHR = null;
                    objReport.m_ObjDataVO.m_strCONFIRM_DAT = null;
                    objReport.m_ObjDataVO.m_strMODIFY_DAT = null;
                    objReport.m_ObjDataVO.m_strOPERATOR_ID_CHR = null;
                    objReport.m_ObjDataVO.m_strREPORT_DAT = null;
                    objReport.m_ObjDataVO.m_strREPORTOR_ID_CHR = null;
                    objReport.m_ObjDataVO.m_strSUMMARY_VCHR = null;
                    objReport.m_ObjDataVO.m_strXML_SUMMARY_VCHR = null;
                    objReport.m_ObjDataVO.m_strANNOTATION_VCHR = null;
                    objReport.m_ObjDataVO.m_strXML_ANNOTATION_VCHR = null;
                }
                for (int i = 0; i < this.m_objDefaultApplyUnits.Length; i++)
                {
                    this.m_objDefaultApplyUnits[i].m_ObjDataVO.m_strAPPLICATION_ID_CHR = null;
                    this.m_objDefaultApplyUnits[i].m_ObjApp = null;
                }
                objAppInfo.m_ObjAppReports.AddArr(this.m_objDefaultReports);
                objAppInfo.m_ObjAppApplyUnits.AddArr(this.m_objDefaultApplyUnits);
            }
            if (this.m_blnUseDefault)
            {//保存为前次值
                this.m_objDefaultReports = new clsLIS_AppCheckReport[objAppInfo.m_ObjAppReports.Count];
                for (int i = 0; i < this.m_objDefaultReports.Length; i++)
                {
                    this.m_objDefaultReports[i] = objAppInfo.m_ObjAppReports[i];
                }

                this.m_objDefaultApplyUnits = new clsLIS_AppApplyUnit[objAppInfo.m_ObjAppApplyUnits.Count];
                for (int i = 0; i < this.m_objDefaultApplyUnits.Length; i++)
                {
                    this.m_objDefaultApplyUnits[i] = objAppInfo.m_ObjAppApplyUnits[i];
                }
            }

            foreach (clsLIS_AppCheckReport objReport in objAppInfo.m_ObjAppReports)
            {//为报告设置操作人员
                objReport.m_ObjDataVO.m_strOPERATOR_ID_CHR = this.m_strGetOprator();
            }
            #region 设置检验内容描述
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            foreach (clsLIS_AppApplyUnit obj in objAppInfo.m_ObjAppApplyUnits)
            {

                if (obj.m_ObjApplyUnit.m_ObjDataVO.strApplUnitName != null && obj.m_ObjApplyUnit.m_ObjDataVO.strApplUnitName.Trim() != "")
                {
                    sb.Append(obj.m_ObjApplyUnit.m_ObjDataVO.strApplUnitName + ",");
                }
            }
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            string strCheckContent = sb.ToString();

            objAppInfo.m_ObjDataVO.m_strCheckContent = strCheckContent;
            #endregion
            string strMessage = null;
            if (!m_blnSaveApp(objAppInfo, out strMessage))
            {
                MessageBox.Show(this.m_objViewer, strMessage, c_strMessageBoxTitle);
                return 0;
            }
            p_objAppMainVO = objAppInfo.m_ObjDataVO;
            p_objAppMainVO.m_strReportGroupID = objAppInfo.m_ObjAppReports[0].m_ObjDataVO.m_strREPORT_GROUP_ID_CHR;
            p_objAppMainVO.m_strReportDate = null;
            p_objAppMainVO.m_intReportStatus = 1;
            p_objAppMainVO.m_strSampleID = objAppInfo.m_ObjAppReports[0].m_ObjAppSampleGroups[0].m_ObjDataVO.m_strSAMPLE_ID_CHR;
            return 1;
        }
        private bool m_blnCheckAppInfoValidate()
        {
            if (this.m_objViewer.m_cboSampleType.SelectedValue == null)
            {
                MessageBox.Show("样本类型不能为空!", c_strMessageBoxTitle, MessageBoxButtons.OK);
                return false;
            }
            //			if(this.m_objViewer.m_txtPatientName.Text.Trim() == "")
            //			{
            //				MessageBox.Show("病人姓名不能为空!",c_strMessageBoxTitle,MessageBoxButtons.OK);
            //				return false;
            //			}
            return true;
        }

        private clsLIS_App m_objCollectAppInfo()
        {
            clsLisApplMainVO objAppVO = new clsLisApplMainVO();
            clsLIS_App objApp = new clsLIS_App(objAppVO);

            objApp.m_StrPatientCardID = m_objViewer.m_txtPatientCard.Text.Trim();
            if (this.m_objViewer.m_txtInhospNO.m_dtrPatient == null)
            {
                objApp.m_StrPatientID = "-1";
            }
            else
            {
                objApp.m_StrPatientID = this.m_objViewer.m_txtInhospNO.m_dtrPatient.strPatientID;
            }
            objApp.m_StrPatientInhospNO = this.m_objViewer.m_txtInhospNO.Text.Trim();
            objApp.m_StrPatientName = this.m_objViewer.m_txtPatientName.Text.Trim();
            objApp.m_StrSex = this.m_objViewer.m_cboSex.Text.Trim();
            if (this.m_objViewer.m_txtAge.Text.Trim() != null)
            {
                objApp.m_StrAge = this.m_objViewer.m_txtAge.Text.Trim() + " " + this.m_objViewer.m_cboAgeUnit.Text.Trim();
            }
            else
            {
                objApp.m_StrAge = null;
            }
            objApp.m_StrApplEmpID = this.m_objViewer.m_txtAppDoct.m_StrEmployeeID;
            objApp.m_StrApplDeptID = this.m_objViewer.m_txtAppDept.m_StrDeptID;
            objApp.m_StrBedNO = this.m_objViewer.m_txtBedNO.Text.Trim();
            objApp.m_StrPatientType = this.m_objViewer.m_cboPatientType.SelectedValue.ToString().Trim();
            if (this.m_objViewer.m_chkEmergency.Checked)
            {
                objApp.m_IntEmergency = 1;
            }
            else
            {
                objApp.m_IntEmergency = 0;
            }
            if (this.m_objViewer.m_chkSpecial.Checked)
            {
                objApp.m_IntSpecial = 1;
            }
            else
            {
                objApp.m_IntSpecial = 0;
            }
            objApp.m_StrDiagnose = this.m_objViewer.m_rtbDiagnose.Text.Trim();
            objApp.m_StrSummary = this.m_objViewer.m_rtbAppSummary.Text.Trim();
            objApp.m_StrApplicationFormNO = this.m_objViewer.m_txtCheckNO.Text.Trim();
            objApp.m_ObjDataVO.m_strSampleType = this.m_objViewer.m_cboSampleType.Text;
            objApp.m_ObjDataVO.m_strSampleTypeID = this.m_objViewer.m_cboSampleType.SelectedValue.ToString().Trim();
            objApp.m_StrOperatorID = this.m_strGetOprator();
            if (this.m_objViewer.m_txtPatientID.Text.Trim() != "")
            {
                objApp.m_StrPatientID = this.m_objViewer.m_txtPatientID.Text.Trim();
            }

            objApp.m_StrAppDat = this.m_objViewer.m_dtpAppDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            objApp.m_IntForm = 0;
            objApp.m_IntPStatus = 2;

            return objApp;
        }

        public bool m_blnSaveApp(clsLIS_App p_objApp, out string p_strMessage)
        {
            p_strMessage = "";

            #region 构造保存参数
            ArrayList arlRep = new ArrayList();
            ArrayList arlSam = new ArrayList();
            ArrayList arlItem = new ArrayList();
            ArrayList arlUnit = new ArrayList();
            ArrayList arlUnitItem = new ArrayList();

            foreach (clsLIS_AppCheckReport objRep in p_objApp.m_ObjAppReports)
            {
                arlRep.Add(objRep.m_ObjDataVO);
                foreach (clsLIS_AppSampleGroup objSam in objRep.m_ObjAppSampleGroups)
                {
                    arlSam.Add(objSam.m_ObjDataVO);
                    foreach (clsLIS_AppCheckItem objItem in objSam.m_ObjAppCheckItems)
                    {
                        arlItem.Add(objItem.m_ObjDataVO);
                    }
                }
            }
            foreach (clsLIS_AppApplyUnit objUnit in p_objApp.m_ObjAppApplyUnits)
            {
                arlUnit.Add(objUnit.m_ObjDataVO);
                arlUnitItem.AddRange(objUnit.m_ObjItemArr);
            }

            clsT_OPR_LIS_APP_REPORT_VO[] objRepArr = (clsT_OPR_LIS_APP_REPORT_VO[])arlRep.ToArray(typeof(clsT_OPR_LIS_APP_REPORT_VO));
            clsT_OPR_LIS_APP_SAMPLE_VO[] objSamArr = (clsT_OPR_LIS_APP_SAMPLE_VO[])arlSam.ToArray(typeof(clsT_OPR_LIS_APP_SAMPLE_VO));
            clsT_OPR_LIS_APP_CHECK_ITEM_VO[] objItemArr = (clsT_OPR_LIS_APP_CHECK_ITEM_VO[])arlItem.ToArray(typeof(clsT_OPR_LIS_APP_CHECK_ITEM_VO));
            clsT_OPR_LIS_APP_APPLY_UNIT_VO[] objUnitArr = (clsT_OPR_LIS_APP_APPLY_UNIT_VO[])arlUnit.ToArray(typeof(clsT_OPR_LIS_APP_APPLY_UNIT_VO));
            clsLisAppUnitItemVO[] objUnitItemArr = (clsLisAppUnitItemVO[])arlUnitItem.ToArray(typeof(clsLisAppUnitItemVO));

            #endregion

            //long lngRes = new clsDomainController_ApplicationManage().m_lngAddNewAppAndSampleInfo(p_objApp.m_ObjDataVO,
            //    objRepArr, objSamArr,objItemArr,objUnitArr,objUnitItemArr);
            clsLisApplMainVO m_ObjDataVO = p_objApp.m_ObjDataVO;
            long lngRes = new clsDomainController_ApplicationManage().m_lngAddNewAppAndSampleInfo(ref m_ObjDataVO,
               ref objRepArr, ref objSamArr, ref objItemArr, ref objUnitArr, ref objUnitItemArr);
            if (lngRes > 0)
            {
                if (objRepArr.Length > 0)
                {
                    p_objApp.m_ObjAppReports[0].m_ObjDataVO.m_strOPERATOR_ID_CHR = objRepArr[0].m_strOPERATOR_ID_CHR;
                }
                if (objSamArr.Length > 0)
                {
                    p_objApp.m_ObjAppReports[0].m_ObjAppSampleGroups[0].m_ObjDataVO.m_strSAMPLE_ID_CHR = objSamArr[0].m_strSAMPLE_ID_CHR;
                }

                //for(int i=0;i<p_objApp.m_ObjAppReports.Count;i++)
                //{
                //   clsLIS_AppCheckReport objRep2=p_objApp.m_ObjAppReports[i];
                //    objRep2=objRepArr[i];
                //    for(int j=0;j<objRep2.m_ObjAppSampleGroups.Count;j++)
                //    {
                //        clsLIS_AppSampleGroup objSam2=objRep2.m_ObjAppSampleGroups[j];
                //        objSam=objSamArr[j];
                //        for(int k=0;k<objSam2.m_ObjAppCheckItems.Count;k++)
                //        {
                //            clsLIS_AppCheckItem objItem2=objSam2.m_ObjAppCheckItems[k];
                //            objItem2.m_ObjDataVO=objItemArr[k];
                //        }
                //    }
                //}
                //for (int i = 0; i < p_objApp.m_ObjAppApplyUnits.Count; i++)
                //{
                //    clsLIS_AppApplyUnit objUnit2 = p_objApp.m_ObjAppApplyUnits[i];
                //    objUnit2.m_ObjDataVO = objUnitArr;
                //    objUnit2.m_ObjItemArr = objUnitItemArr;
                //}

                p_objApp.m_mthAcceptChanges();
                return true;
            }

            p_strMessage = c_strMessageDataErr;
            return false;
        }


        #endregion

        #region 删除
        public long m_lngDelete(string p_strAppID)
        {
            long lngRes = 0;
            try
            {
                lngRes = new clsDomainController_ApplicationManage().m_lngDeleteApp(p_strAppID, this.m_strGetOprator());
            }
            catch
            {
                lngRes = 0;
            }
            return lngRes;
        }

        #endregion

        #region ModifyApp
        public long m_lngSaveAppAndModifySample(clsLisApplMainVO p_objApp)
        {
            long lngRes = 0;

            lngRes = new clsDomainController_ApplicationManage().m_lngSetApplicationAndSamplePatientInfo(p_objApp);
            return lngRes;
        }


        #endregion

        public string m_strGetOprator()
        {
            return this.m_objViewer.LoginInfo.m_strEmpID;
        }

        #region 作废申请单
        /// <summary>
        /// 作废申请单
        /// </summary>
        /// <param name="p_strAppID"></param>
        /// <returns></returns>
        public long m_lngUpdateVoidApply(string p_strAppID, string p_strOperatorID)
        {
            long lngRes = 0;
            lngRes = new clsDomainController_ApplicationManage().m_lngUpdateVoidApply(p_strAppID, p_strOperatorID);
            return lngRes;
        }
        #endregion

        #region 通过申请单号判断是否审核
        /// <summary>
        /// 通过申请单号判断是否审核
        /// </summary>
        /// <param name="p_strApplicationID"></param>
        /// <param name="p_dtResult"></param>
        /// <param name="p_dtUnitResult"></param>
        /// <returns></returns>
        public long m_lnqQueryConfirmReport(string p_strApplicationID, out DataTable p_dtResult, out DataTable p_dtUnitResult)
        {
            long lngRes = 0;
            lngRes = new clsDomainController_ApplicationManage().m_lnqQueryConfirmReport(p_strApplicationID, out p_dtResult, out p_dtUnitResult);
            return lngRes;
        }
        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="p_strParmCode"></param>
        /// <param name="p_strParmValue"></param>
        /// <returns></returns>
        public long m_lngGetSysParm(string p_strParmCode, out string p_strParmValue)
        {
            p_strParmValue = "";
            long lngRes = 0;
            lngRes = new clsDomainController_ApplicationManage().m_lngGetSysParm(p_strParmCode, out p_strParmValue);
            return lngRes;
        }
        #endregion

        #region 取消审核
        /// <summary>
        /// 取消审核
        /// </summary>
        /// <param name="p_strAppID">申请单ID</param>
        /// <param name="p_strOperatorID">操作员工ID</param>
        /// <returns>大于0成功，否则失败</returns>
        public long m_lngCancelConfimReport(string p_strAppID, string p_strOperatorID)
        {
            long lngRes = 0;
            lngRes = new clsDomainController_ApplicationManage().m_lngCancelConfimReport(p_strAppID, p_strOperatorID);
            return lngRes;
        }
        #endregion

        #region 科学计数法比较

        public string CMPdata(string resstr, string cmpstr)
        {
            string result = string.Empty;
            string resFh = string.Empty;
            string cmpFh = string.Empty;
            Decimal resDec = 0;
            Decimal cmpDec = 0;

            if (resstr.Substring(0, 1) != "<" && resstr.Substring(0, 1) != ">")
            {
                resstr = "=" + resstr;
            }

            resstr = ToDBC(resstr);
            cmpstr = ToDBC(cmpstr);

            if (resstr != "" && cmpstr != "")
            {
                resDec = ChangeDataToD(resstr);
                resFh = resstr.Substring(0, 1);

                cmpDec = ChangeDataToD(cmpstr);
                cmpFh = cmpstr.Substring(0, 1);
            }
            else
            {
                return "无法判断";
            }

            if (resFh == ">" && cmpFh == ">")
            {
                if (resDec >= cmpDec)
                {
                    result = "正常";
                }
                else
                {
                    result = "无法判断";
                }
            }

            if (resFh == "<" && cmpFh == "<")
            {
                if (resDec <= cmpDec)
                {
                    result = "正常";
                }
                else
                {
                    result = "无法判断";
                }
            }

            if (resFh == "<" && cmpFh == ">")
            {
                if (resDec <= cmpDec)
                {
                    result = "偏低";
                }
                else
                {
                    result = "无法判断";
                }
            }

            if (resFh == ">" && cmpFh == "<")
            {
                if (resDec > cmpDec)
                {
                    result = "偏高";
                }
                else
                {
                    result = "无法判断";
                }
            }

            if (resFh == "=" && cmpFh == ">")
            {
                if (resDec <= cmpDec)
                {
                    result = "偏低";
                }
                else
                {
                    result = "无法判断";
                }
            }

            if (resFh == "=" && cmpFh == "<")
            {
                if (resDec > cmpDec)
                {
                    result = "偏高";
                }
                else
                {
                    result = "无法判断";
                }
            }

            return result;
        }

        public string CMPdata(string resstr, string cmpstr1, string cmpstr2)
        {
            string result = string.Empty;
            string resFh = string.Empty;
            string cmp1Fh = string.Empty;
            string cmp2Fh = string.Empty;
            Decimal resDec = 0;
            Decimal cmp1Dec = 0;
            Decimal cmp2Dec = 0;

            resstr = ToDBC(resstr);
            cmpstr1 = ToDBC(cmpstr1);
            cmpstr2 = ToDBC(cmpstr2);

            if (resstr != "" && cmpstr1 != "" && cmpstr2 != "")
            {
                resDec = ChangeDataToD(resstr);
                resFh = resstr.Substring(0, 1);

                cmp1Dec = ChangeDataToD(cmpstr1);
                cmp1Fh = cmpstr1.Substring(0, 1);
                cmp2Dec = ChangeDataToD(cmpstr2);
                cmp2Fh = cmpstr2.Substring(0, 1);

                if (cmp1Dec < cmp2Dec)
                {
                    cmp1Fh = "<";
                    cmp2Fh = ">";
                }
            }
            else
            {
                return "无法判断";
            }

            decimal DecMax = cmp1Dec > cmp2Dec ? cmp1Dec : cmp2Dec;
            DecMax = DecMax > resDec ? DecMax : resDec;

            decimal DecMin = cmp1Dec < cmp2Dec ? cmp1Dec : cmp2Dec;
            DecMin = DecMin < resDec ? DecMin : resDec;

            if (cmp1Fh == "<" && cmp2Fh == ">")
            {
                if (resFh == ">")
                {
                    if (DecMax == resDec)
                    {
                        result = "偏高";
                    }
                    else
                    {
                        result = "无法判断";
                    }
                }
                else if (resFh == "<")
                {
                    if (DecMin == resDec)
                    {
                        result = "偏低";
                    }
                    else
                    {
                        result = "无法判断";
                    }
                }
            }
            else
            {
                result = "无法判断";
            }

            return result;
        }

        private Decimal ChangeDataToD(string str)
        {
            Decimal dData = 0.0M;
            int i = str.Length;

            str = str.Trim();
            string strData = str.Substring(1, i - 1);
            strData = ToDBC(strData);
            strData = strData.Trim();

            if (strData.Contains("E"))
            {
                dData = Convert.ToDecimal(Decimal.Parse(strData.ToString(), System.Globalization.NumberStyles.Float));
            }
            return dData;
        }

        private static String ToDBC(String input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }
                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }
            return new String(c);
        }
        #endregion

        #region WechatPost
        /// <summary>
        /// WechatPost
        /// </summary>
        public void WechatPost(string applicationId)
        {
            try
            {
                if (string.IsNullOrEmpty(this.WechatWebUrl) || string.IsNullOrEmpty(applicationId)) return;
                clsDomainController_ApplicationManage doMain = new clsDomainController_ApplicationManage();
                DataTable dt = doMain.GetWechatSampleInfo(applicationId);
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];
                    if (doMain.IsWechatBanding(dr["patientcardid_chr"].ToString()))
                    {

                        string xmlData = string.Empty;
                        xmlData += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine;
                        xmlData += "<req>" + Environment.NewLine;
                        xmlData += string.Format("<eventNo>{0}</eventNo>", "41332004414") + Environment.NewLine;
                        xmlData += string.Format("<eventType>{0}</eventType>", "lisReportCompleted") + Environment.NewLine;
                        xmlData += "<eventData>" + Environment.NewLine;
                        xmlData += string.Format("<healthCardNo>{0}</healthCardNo>", dr["patientcardid_chr"].ToString()) + Environment.NewLine;
                        xmlData += string.Format("<patientId>{0}</patientId>", dr["patientid_chr"].ToString()) + Environment.NewLine;
                        xmlData += string.Format("<inpatientId>{0}</inpatientId>", dr["patient_inhospitalno_chr"].ToString()) + Environment.NewLine;
                        xmlData += string.Format("<clinicSeq>{0}</clinicSeq>", dr["patientid_chr"].ToString() + Convert.ToDateTime(dr["appl_dat"]).ToString("yyyyMMdd")) + Environment.NewLine;
                        xmlData += string.Format("<exameDate>{0}</exameDate>", Convert.ToDateTime(dr["accept_dat"]).ToString("yyyy-MM-dd HH:mm")) + Environment.NewLine;
                        xmlData += string.Format("<reportDate>{0}</reportDate>", Convert.ToDateTime(dr["confirm_dat"]).ToString("yyyy-MM-dd HH:mm")) + Environment.NewLine;
                        xmlData += string.Format("<reportId>{0}</reportId>", dr["application_id_chr"].ToString()) + Environment.NewLine;
                        xmlData += string.Format("<reportTitle>{0}</reportTitle>", dr["check_content_vchr"].ToString()) + Environment.NewLine;
                        xmlData += "</eventData>" + Environment.NewLine;
                        xmlData += "</req>" + Environment.NewLine;

                        byte[] dataArray = System.Text.Encoding.Default.GetBytes(xmlData);
                        //创建请求
                        HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.WechatWebUrl);
                        request.Method = "POST";
                        request.ContentLength = dataArray.Length;
                        //创建输入流
                        Stream dataStream = null;
                        try
                        {
                            dataStream = request.GetRequestStream();
                        }
                        catch
                        {
                            return;
                        }
                        //发送请求
                        dataStream.Write(dataArray, 0, dataArray.Length);
                        dataStream.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
