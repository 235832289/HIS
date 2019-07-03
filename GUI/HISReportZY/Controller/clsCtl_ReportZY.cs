using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Sybase.DataWindow;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 报表控制类
    /// </summary>
    public class clsCtl_ReportZY : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// Domain-Report
        /// </summary>
        private clsDcl_ReportZY objReport;
        /// <summary>
        /// 医院名称
        /// </summary>
        private string hospname = "";
        /// <summary>
        /// 医院名称
        /// </summary>
        public string HospitalName
        {
            get 
            {
                return hospname;
            }
            set
            {
                hospname = value;
            }
        }
        /// <summary>
        /// 数据库连接参数
        /// </summary>
        private string SQLParm = "";
        /// <summary>
        /// 登录员所属科室(病区)ID列表
        /// </summary>
        internal ArrayList objDeptIDArr = new ArrayList();
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_ReportZY()
        {
            objReport = new clsDcl_ReportZY();
            hospname = this.m_objComInfo.m_strGetHospitalTitle();
            this.m_mthGetSQLParm();
        }
        #endregion

        #region 获取数据库连接参数
        /// <summary>
        /// 获取数据库连接参数
        /// </summary>
        public void m_mthGetSQLParm()
        {
            string tmpfs = clsPublic.XMLFile;
            clsPublic.XMLFile = Application.StartupPath + @"\HISYB.xml";

            string Server = clsPublic.m_strReadXML("FOSHAN.LUNJIAO", "ServerName", "AnyOne");
            string DBname = clsPublic.m_strReadXML("FOSHAN.LUNJIAO", "DataBase", "AnyOne");
            string UserID = clsPublic.m_strReadXML("FOSHAN.LUNJIAO", "LogID", "AnyOne");
            string PassWord = clsPublic.m_strReadXML("FOSHAN.LUNJIAO", "LogPassWord", "AnyOne");

            SQLParm = "server=" + Server + ";database=" + DBname + ";uid=" + UserID + ";pwd=" + PassWord;

            clsPublic.XMLFile = tmpfs;

            #region 登录员所属科室(病区)ID列表
            clsDepartmentVO[] DeptVO;
            this.m_objComInfo.m_mthGetAllDeptArr(out DeptVO);
            if (DeptVO != null)
            {
                for (int i = 0; i < DeptVO.Length; i++)
                {
                    objDeptIDArr.Add(((clsDepartmentVO)DeptVO[i]).strDeptID);
                }
            }
            #endregion
        }
        #endregion
        
        #region (茶山)费用明细自费清单
        /// <summary>
        /// (茶山)费用明细自费清单
        /// </summary>
        /// <param name="DGV"></param>
        /// <param name="Zyh"></param>
        /// <param name="Name"></param>
        /// <param name="DateScope"></param>
        /// <param name="PrintEmp"></param>
        /// <param name="Type">0 全部 1 自费 2 记帐</param>
        public void m_mthRptSbBill_CS(DataGridView DGV, string Zyh, string Name, string DateScope, string PrintEmp, int Type)
        {
            DataStore dsRep = new DataStore();
            dsRep.LibraryList = clsPublic.PBLPath;
            dsRep.DataWindowObject = "d_bih_chargesum_cs";                        
            
            ArrayList DeptArr = new ArrayList();
            ArrayList RowArr = new ArrayList();

            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if (RowArr.IndexOf(i) >= 0)
                {
                    continue;
                }

                string itemid = DGV.Rows[i].Cells["colxmdm"].Value.ToString().Trim();
                string price = DGV.Rows[i].Cells["coldj"].Value.ToString().Trim();
                string scale = DGV.Rows[i].Cells["scale"].Value.ToString().Trim();
                decimal amount = clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colsl"].Value);
                decimal totalmoney = clsPublic.ConvertObjToDecimal(DGV.Rows[i].Cells["colje"].Value);

                if (Type == 1)
                {
                    if (scale != "100")
                    {
                        continue;
                    }
                }
                else if (Type == 2)
                {
                    if (scale == "100")
                    {
                        continue;
                    }
                }

                for (int j = i + 1; j < DGV.Rows.Count; j++)
                {
                    if (DGV.Rows[j].Cells["colxmdm"].Value.ToString().Trim() == itemid &&
                        DGV.Rows[j].Cells["coldj"].Value.ToString().Trim() == price &&
                        DGV.Rows[j].Cells["scale"].Value.ToString().Trim() == scale)
                    {
                        amount += clsPublic.ConvertObjToDecimal(DGV.Rows[j].Cells["colsl"].Value);
                        totalmoney += clsPublic.ConvertObjToDecimal(DGV.Rows[j].Cells["colje"].Value);                        

                        RowArr.Add(j);
                    }
                }

                if (amount == 0)
                {
                    continue;
                }

                string areaname = DGV.Rows[i].Cells["colszbq"].Value.ToString().Trim();
                if (DeptArr.IndexOf(areaname) == -1)
                {
                    DeptArr.Add(areaname);
                }

                int row = dsRep.InsertRow(0);
                dsRep.SetItemString(row, "colxmdm", DGV.Rows[i].Cells["colxmdm"].Value.ToString());
                dsRep.SetItemString(row, "colxmmc", DGV.Rows[i].Cells["colxmmc"].Value.ToString());
                dsRep.SetItemString(row, "colgg", DGV.Rows[i].Cells["colgg"].Value.ToString());
                dsRep.SetItemString(row, "coldw", DGV.Rows[i].Cells["coldw"].Value.ToString());
                dsRep.SetItemDecimal(row, "coldj", clsPublic.ConvertObjToDecimal(price));
                dsRep.SetItemDecimal(row, "colsl", amount);
                dsRep.SetItemDecimal(row, "colje", totalmoney);
                dsRep.SetItemString(row, "colzfbl", scale);
                if (scale == "100")
                {
                    dsRep.SetItemString(row, "colzfbz", "是");
                }
                else
                {
                    dsRep.SetItemString(row, "colzfbz", "否");
                }            
            }

            string DeptName = "";
            for (int i = 0; i < DeptArr.Count; i++)
            {
                DeptName += DeptArr[i].ToString() + "、";
            }

            if (DeptName != "")
            {
                DeptName = DeptName.Substring(0, DeptName.Length - 1);
            }
                        
            dsRep.Modify("t_title.text = '" + this.HospitalName + dsRep.Describe("t_title.text") + "'");
            dsRep.Modify("t_ksmc.text = '" + DeptName + "'");
            dsRep.Modify("t_zyh.text = '" + Zyh + "'");
            dsRep.Modify("t_xm.text = '" + Name + "'");
            dsRep.Modify("t_tjrq.text = '" + DateScope + "'");
            dsRep.Modify("t_dyr.text = '" + PrintEmp + "'");

            clsPublic.PrintDialog(dsRep);     
        }

        /// <summary>
        /// (茶山)费用明细自费清单
        /// </summary>
        /// <param name="RegID"></param>
        /// <param name="PayTypeID"></param>
        /// <param name="Zyh"></param>
        /// <param name="Name"></param>
        /// <param name="PrintEmp"></param>
        /// <param name="Type"></param>
        /// <param name="dwRep"></param>
        public void m_mthRptSbBill_CS(string RegID, string PayTypeID, string Zyh, string Name, string PrintEmp, int Type, DataWindowControl dwRep)
        {
            DataTable dt;
            clsDcl_Charge objCharge = new clsDcl_Charge();
            long l = objCharge.m_lngGetPatientFeeDetByPayType(RegID, PayTypeID, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();                
                ArrayList RowArr = new ArrayList();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    if (RowArr.IndexOf(i) >= 0)
                    {
                        continue;
                    }

                    string itemid = dr["itemcode_vchr"].ToString().Trim();
                    string price = dr["unitprice_dec"].ToString();
                    string scale = dr["precent_dec"].ToString();
                    decimal amount = clsPublic.ConvertObjToDecimal(dr["amount_dec"]);
                    decimal totalmoney = clsPublic.ConvertObjToDecimal(dr["totalmony"]);

                    if (Type == 1)
                    {
                        if (scale != "100")
                        {
                            continue;
                        }
                    }
                    else if (Type == 2)
                    {
                        if (scale == "100")
                        {
                            continue;
                        }
                    }

                    for (int j = i + 1; j < dt.Rows.Count; j++)
                    {
                        DataRow dr2 = dt.Rows[j];

                        if (dr2["itemcode_vchr"].ToString().Trim() == itemid &&
                            dr2["unitprice_dec"].ToString() == price &&
                            dr2["precent_dec"].ToString() == scale)
                        {
                            amount += clsPublic.ConvertObjToDecimal(dr2["amount_dec"]);
                            totalmoney += clsPublic.ConvertObjToDecimal(dr2["totalmony"]);

                            RowArr.Add(j);
                        }
                    }

                    if (amount == 0)
                    {
                        continue;
                    }

                    int row = dwRep.InsertRow(0);
                    dwRep.SetItemString(row, "colxmdm", dr["itemcode_vchr"].ToString().Trim());
                    dwRep.SetItemString(row, "colxmmc", dr["chargeitemname_chr"].ToString().Trim());
                    dwRep.SetItemString(row, "colgg", dr["itemspec_vchr"].ToString().Trim());
                    dwRep.SetItemString(row, "coldw", dr["unit_vchr"].ToString().Trim());
                    dwRep.SetItemDecimal(row, "coldj", clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]));
                    dwRep.SetItemDecimal(row, "colsl", amount);
                    dwRep.SetItemDecimal(row, "colje", totalmoney);
                    dwRep.SetItemString(row, "colzfbl", scale);
                    if (scale == "100")
                    {
                        dwRep.SetItemString(row, "colzfbz", "是");
                    }
                    else
                    {
                        dwRep.SetItemString(row, "colzfbz", "否");
                    }   
                }

                string DeptName = "";
                string DateScope = "";
                if (dt.Rows.Count > 0)
                {
                    DeptName = dt.Rows[0]["curarea"].ToString().Trim();

                    DataView dv = new DataView(dt);
                    dv.Sort = "chargeactive_dat asc";
                    DateScope = Convert.ToDateTime(dv[0]["chargeactive_dat"].ToString()).ToString("yyyy-MM-dd") + " ~ " + Convert.ToDateTime(dv[dv.Count - 1]["chargeactive_dat"].ToString()).ToString("yyyy-MM-dd");
                }

                dwRep.Modify("t_ksmc.text = '" + DeptName + "'");
                dwRep.Modify("t_zyh.text = '" + Zyh + "'");
                dwRep.Modify("t_xm.text = '" + Name + "'");
                dwRep.Modify("t_tjrq.text = '" + DateScope + "'");
                dwRep.Modify("t_dyr.text = '" + PrintEmp + "'");

                dwRep.SetRedrawOn();
                dwRep.Refresh();
            }
            objCharge = null;
        }
        #endregion

        #region 项目统计发生明细报表
        /// <summary>
        /// 项目统计发生明细报表
        /// </summary>
        /// <param name="CodeNo"></param>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="DeptIDArr"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public void m_lngRptItemDetailStat(string CodeNo, string BeginDate, string EndDate, ArrayList DeptIDArr, DataWindowControl dwRep)
        {
            dwRep.Modify("t_date.text = '统计时间: " + BeginDate + " ~ " + EndDate + "'");

            DataTable dt;
            long l = this.objReport.m_lngRptItemDetailStat(CodeNo, BeginDate, EndDate, DeptIDArr, out dt);
            if (l > 0)
            {
                dwRep.SetRedrawOff();
                dwRep.Retrieve(dt);

                if (dwRep.RowCount == 0)
                {
                    dwRep.InsertRow(0);
                }

                dwRep.SetRedrawOn();
            }
        }
        #endregion

        #region 获取功能科室核算实收统计数据
        /// <summary>
        /// 获取功能科室核算实收统计数据-主治医生
        /// </summary>
        /// <param name="objvalue_Param"></param>
        /// <param name="dtbResult"></param>
        /// <returns></returns>
        internal long m_lngGetGroupInComeByArea(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, ref DataTable dtbResult)
        {
            long lngRes = objReport.m_lngGetGroupInComeByDoctor(ref objvalue_Param, ref dtbResult);
            return lngRes;
        }

        internal void m_mthGetGroupInComeByDoctor(ref clsGroupInComeByDoctorOrArea_VO objvalue_Param, DataWindowControl dwRep, int p_intRptType, int p_intRptClass)
        {
            #region 两层
            StringBuilder sbdSQL = new StringBuilder("");
            string LogTitle = "";
            if (p_intRptType == 9)
            {
                if (p_intRptClass == 1)
                {
                    LogTitle = "功能科室专业组分类报表（主治医生）(按日结时间)";

                    sbdSQL.Append(@"select  nvl(td.usercode_chr, '<未定义>') as groupno,
                                            nvl(td.groupname_vchr, '<未定义>') as groupname,
                                            ta.totalsum,
                                            tc.groupid_chr,
                                            nvl(tc.groupname_chr, '未定义') as groupname_chr,
                                            tc.catsum
                                    from (select nvl(a.doctorgroupid_chr,'999')  as doctorgroupid_chr, 
                                                 sum(a.totalmoney_dec) as totalsum
                                            from t_opr_bih_chargeitementry a, t_opr_bih_charge b
                                            where a.chargeno_chr = b.chargeno_chr
                                                and b.status_int = 1
                                                and b.recflag_int = 1
                                                and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and b.recdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and b.recdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                            group by a.doctorgroupid_chr) ta,
                                        (select a.doctorgroupid_chr,
                                                tb.groupid_chr,
                                                tb.groupname_chr,
                                                sum(a.totalmoney_dec) as catsum
                                         from   t_opr_bih_chargeitementry a,
                                                t_opr_bih_charge b,
                                                (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                 from t_aid_rpt_def     a,
                                                      t_aid_rpt_gop_def b, 
                                                      t_aid_rpt_gop_rla c 
                                                 where a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr(+)
                                                   and b.groupid_chr = c.groupid_chr(+)
                                                   and a.rptid_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strRptID);
                    sbdSQL.Append(@"') tb
                                            where a.chargeno_chr = b.chargeno_chr
                                                and a.calccateid_chr = tb.typeid_chr(+)
                                                and b.status_int = 1
                                                and b.recflag_int = 1
                                                and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and b.recdate_dat >=
                                                    to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and b.recdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                            group by a.doctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                        t_bse_groupdesc td
                                        where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                                          and ta.doctorgroupid_chr = td.groupid_chr
                                        order by td.usercode_chr asc");

                }
                else
                {

                    LogTitle = "功能科室核算实收报表（开单医生）(按日结时间)";
                    sbdSQL.Append(@"select  nvl(td.usercode_chr, '<未定义>') as groupno,
                                            nvl(td.groupname_vchr, '<未定义>') as groupname,
                                            ta.totalsum,
                                            tc.groupid_chr,
                                            nvl(tc.groupname_chr, '未定义') as groupname_chr,
                                            tc.catsum
                                    from (select nvl(a.chargedoctorgroupid_chr,'999') as doctorgroupid_chr,
                                                 sum(a.totalmoney_dec) as totalsum
                                            from t_opr_bih_chargeitementry a,                                               
                                                 t_opr_bih_charge          c
                                            where a.chargeno_chr = c.chargeno_chr
                                              and c.status_int = 1
                                              and c.recflag_int = 1
                                              and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and c.recdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and c.recdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);

                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')     
                                            group by a.chargedoctorgroupid_chr) ta,
                                    (select nvl(a.chargedoctorgroupid_chr,'999') as doctorgroupid_chr,
                                            nvl(tb.groupid_chr,'999') as groupid_chr,
                                            nvl(tb.groupname_chr,'999') as groupname_chr,
                                            sum(a.totalmoney_dec) as catsum
                                     from t_opr_bih_chargeitementry a,                                    
                                          t_opr_bih_charge c,
                                          (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                            from t_aid_rpt_def     a,
                                                 t_aid_rpt_gop_def b,                       
                                                 t_aid_rpt_gop_rla c
                                            where a.rptid_chr = b.rptid_chr
                                              and b.rptid_chr = c.rptid_chr(+)
                                              and b.groupid_chr = c.groupid_chr(+)
                                              and a.rptid_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strRptID);
                    sbdSQL.Append(@"') tb
                                    where a.chargeno_chr = c.chargeno_chr
                                        and a.calccateid_chr = tb.typeid_chr(+)
                                        and c.status_int = 1
                                        and c.recflag_int = 1
                                        and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and c.recdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and c.recdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                        group by a.chargedoctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,       
                                    t_bse_groupdesc td
                                 where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                                   and ta.doctorgroupid_chr = td.groupid_chr(+)
                                 order by td.usercode_chr asc");
                }
            }
            else
            {
                if (p_intRptClass == 1)
                {
                    LogTitle = "功能科室专业组分类报表（主治医生）(按发票时间)";

                    sbdSQL.Append(@"select  nvl(td.usercode_chr, '<未定义>') as groupno,
                                            nvl(td.groupname_vchr, '<未定义>') as groupname,
                                            ta.totalsum,
                                            tc.groupid_chr,
                                            nvl(tc.groupname_chr, '未定义') as groupname_chr,
                                            tc.catsum
                                    from (select nvl(a.doctorgroupid_chr,'999')  as doctorgroupid_chr, 
                                                 sum(a.totalmoney_dec) as totalsum
                                            from t_opr_bih_chargeitementry a, t_opr_bih_charge b
                                            where a.chargeno_chr = b.chargeno_chr
                                                and b.status_int = 1
                                                and b.recflag_int = 1
                                                and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and b.operdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and b.operdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                            group by a.doctorgroupid_chr) ta,
                                        (select a.doctorgroupid_chr,
                                                tb.groupid_chr,
                                                tb.groupname_chr,
                                                sum(a.totalmoney_dec) as catsum
                                         from   t_opr_bih_chargeitementry a,
                                                t_opr_bih_charge b,
                                                (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                                 from t_aid_rpt_def     a,
                                                      t_aid_rpt_gop_def b, 
                                                      t_aid_rpt_gop_rla c 
                                                 where a.rptid_chr = b.rptid_chr
                                                   and b.rptid_chr = c.rptid_chr(+)
                                                   and b.groupid_chr = c.groupid_chr(+)
                                                   and a.rptid_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strRptID);
                    sbdSQL.Append(@"') tb
                                            where a.chargeno_chr = b.chargeno_chr
                                                and a.calccateid_chr = tb.typeid_chr(+)
                                                and b.status_int = 1
                                                and b.recflag_int = 1
                                                and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and b.operdate_dat >=
                                                    to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and b.operdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                            group by a.doctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,
                                        t_bse_groupdesc td
                                        where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                                          and ta.doctorgroupid_chr = td.groupid_chr
                                        order by td.usercode_chr asc");

                }
                else
                {
                    LogTitle = "功能科室核算实收报表（开单医生）(按发票时间)";
                    sbdSQL.Append(@"select  nvl(td.usercode_chr, '<未定义>') as groupno,
                                            nvl(td.groupname_vchr, '<未定义>') as groupname,
                                            ta.totalsum,
                                            tc.groupid_chr,
                                            nvl(tc.groupname_chr, '未定义') as groupname_chr,
                                            tc.catsum
                                    from (select nvl(a.chargedoctorgroupid_chr,'999') as doctorgroupid_chr,
                                                 sum(a.totalmoney_dec) as totalsum
                                            from t_opr_bih_chargeitementry a,                                               
                                                 t_opr_bih_charge          c
                                            where a.chargeno_chr = c.chargeno_chr
                                              and c.status_int = 1
                                              and c.recflag_int = 1
                                              and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and c.operdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and c.operdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);

                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')     
                                            group by a.chargedoctorgroupid_chr) ta,
                                    (select nvl(a.chargedoctorgroupid_chr,'999') as doctorgroupid_chr,
                                            nvl(tb.groupid_chr,'999') as groupid_chr,
                                            nvl(tb.groupname_chr,'999') as groupname_chr,
                                            sum(a.totalmoney_dec) as catsum
                                     from t_opr_bih_chargeitementry a,
                                          t_opr_bih_charge c,
                                          (select b.groupid_chr, b.groupname_chr, c.typeid_chr
                                            from t_aid_rpt_def     a,
                                                 t_aid_rpt_gop_def b,                       
                                                 t_aid_rpt_gop_rla c
                                            where a.rptid_chr = b.rptid_chr
                                              and b.rptid_chr = c.rptid_chr(+)
                                              and b.groupid_chr = c.groupid_chr(+)
                                              and a.rptid_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strRptID);
                    sbdSQL.Append(@"') tb
                                    where a.chargeno_chr = c.chargeno_chr
                                        and a.calccateid_chr = tb.typeid_chr(+)
                                        and c.status_int = 1
                                        and c.recflag_int = 1
                                        and a.createarea_chr = '");
                    sbdSQL.Append(objvalue_Param.m_strAreaID);
                    sbdSQL.Append(@"' and c.operdate_dat >=  to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchBeginDate);
                    sbdSQL.Append(@"','yyyy-mm-dd HH24:mi:ss')  and c.operdate_dat <= to_date('");
                    sbdSQL.Append(objvalue_Param.m_strSearchEndDate);
                    sbdSQL.Append(@"', 'yyyy-mm-dd HH24:mi:ss')
                                        group by a.chargedoctorgroupid_chr, tb.groupid_chr, tb.groupname_chr) tc,       
                                    t_bse_groupdesc td
                                 where ta.doctorgroupid_chr = tc.doctorgroupid_chr(+)
                                   and ta.doctorgroupid_chr = td.groupid_chr(+)
                                 order by td.usercode_chr asc");

                }
            }
            dwRep.SetRedrawOff();
            dwRep.Modify(@"catsum_t.text = '@groupname_chr'");
            dwRep.SetSqlSelect(sbdSQL.ToString());
            dwRep.Retrieve();
            if (dwRep.RowCount == 0)
            {
                dwRep.Modify(@"catsum_t.text = '收费类别'");
            }
            dwRep.Refresh();
            dwRep.SetRedrawOn();

            clsPublic.WriteSQLLog(LogTitle, sbdSQL.ToString());
            #endregion

        }

        /// <summary>
        /// 获取病区数据
        /// </summary>
        /// <param name="?"></param>
        /// <param name="?"></param>
        /// <returns></returns>
        internal long m_lngFindArea(string strFindCode, out clsBIHArea[] objItemArr)
        {
            long lngRes = objReport.m_lngFindArea(strFindCode, out objItemArr);
            return lngRes;
        }

        #endregion

        #region 台山自签单
        public DataTable m_dtInitText(string Inpatientid, int p_intType)
        {
            DataTable dt;
            long l = this.objReport.m_lngGetRegisterID(Inpatientid, out dt, p_intType);
            if (l > 0 && dt != null)
            {
                return dt;
            }
            return null;
        }

        internal long m_lngOwnCast(string RegisterID, string Typelist, DataWindowControl dw)
        {
            DataTable dt;
            long l = this.objReport.m_lngGetOwnCastItem(Typelist, RegisterID, out dt);
            if (l < 0 || dt == null || dt.Rows.Count == 0)
            {
                return -1;
            }

            dw.DataWindowObject = "d_bill_owncastbill";
            dw.Reset();
            dw.SetRedrawOff();
            dw.Modify("t_hospitalname.text='" + this.hospname.ToString() + "'");
            dw.Modify("t_printdate.text='" + DateTime.Now.ToString("yyyy年MM月dd日") + "'");
            dw.Retrieve(dt);
            dw.CalculateGroups();
            dw.SetRedrawOn();
            dw.Refresh();
            dw.PrintProperties.Preview = true;
            dw.PrintProperties.ShowPreviewRulers = true;
            return 1;
        }
        #endregion 

        #region 茶山护理工作量
        /// <summary>
        /// 茶山护理工作量
        /// </summary>
        /// <param name="dtmTmp"></param>
        /// <param name="m_strDepID"></param>
        /// <param name="dw"></param>
        /// <param name="p_arrSorce"></param>
        internal void m_mthGetNusingLog(DateTime dtmTmp, string m_strDepID, DataWindowControl dw,ArrayList p_arrSorce)
        {
            DataTable dt;
            long l = this.objReport.m_lngGetRptNursingLog(dtmTmp, m_strDepID, out dt);
            if (l < 0)
            {
                return;
            }
            DataTable dtPatCount = null;
            l = this.objReport.m_lngGetRptNusingPatientCount(dtmTmp, m_strDepID, out dtPatCount);
            if (l < 0)
            {
                return;
            }

            dw.DataWindowObject = "d_bih_nursinglog";
            dw.Reset();
            dw.SetRedrawOff();
            dw.Modify("t_month.text='" + dtmTmp.Month.ToString() + "月'");
            DataRow dr = null;
            DataRowView drv = null;
            ArrayList arrTmp = new ArrayList();
            DateTime dtm;
            DataView dtvTmp = new DataView(dtPatCount);
            dtvTmp.RowFilter = "flag = 1";
            //dtPatCount.DefaultView.RowFilter = "flag = 1";// 1 入院
            int intRow = dtvTmp.Count;
            int intInsertRow = dw.InsertRow(0);
            dw.SetItemString(intInsertRow, "colname", "入院人数(例)");
            dw.SetItemDecimal(intInsertRow, "colsorce", Convert.ToInt16(p_arrSorce[0]));
            int intPatientCount = 0;
            for (int i1 = 0; i1 < intRow; i1++)
            {
                drv = dtvTmp[i1];
                if (arrTmp.Contains(drv["inareaddate"]))
                {
                    continue;
                }
                dtm = Convert.ToDateTime(drv["inareaddate"]);
                dw.SetItemDecimal(intInsertRow, "coldate_" + dtm.Day.ToString(), Convert.ToInt16(drv["patientcount"]));
                intPatientCount += Convert.ToInt16(drv["patientcount"]);
            }
            dw.SetItemDecimal(intInsertRow, "colsum", intPatientCount);

            //dtPatCount.DefaultView.RowFilter = "flag = 0";// 0 出院
            arrTmp.Clear();
            intPatientCount = 0;
            dtvTmp.RowFilter = "flag = 0";
            intRow = dtvTmp.Count;
            intInsertRow = dw.InsertRow(0);
            dw.SetItemString(intInsertRow, "colname", "出院人数(例)");
            dw.SetItemDecimal(intInsertRow, "colsorce", Convert.ToInt16(p_arrSorce[1]));
            for (int i1 = 0; i1 < intRow; i1++)
            {
                drv = dtvTmp[i1];
                if (arrTmp.Contains(drv["inareaddate"]))
                {
                    continue;
                }
                dtm = Convert.ToDateTime(drv["inareaddate"]);
                dw.SetItemDecimal(intInsertRow, "coldate_" + dtm.Day.ToString(), Convert.ToInt16(drv["patientcount"]));
                intPatientCount += Convert.ToInt16(drv["patientcount"]);
            }
            dw.SetItemDecimal(intInsertRow, "colsum", intPatientCount);
            dtPatCount.Dispose();
            dtPatCount = null;
            dtvTmp.Dispose();
            dtvTmp = null;

            arrTmp.Clear();
            intRow = dt.Rows.Count;
            for (int i1 = 0; i1 < intRow; i1++)
            {
                dr = dt.Rows[i1];
                if (arrTmp.Contains(dr["seqid_chr"]))
                {
                    continue;
                }

                arrTmp.Add(dr["seqid_chr"]);
                DataRow[] drArr = dt.Select("seqid_chr = '" + dr["seqid_chr"].ToString() + "'", "chargedate");
                int row = dw.InsertRow(0);

                decimal dclSum = 0m;
                dw.SetItemString(row, "colname", dr["nurname_vchr"].ToString() + "(" + dr["nurunit_vchr"].ToString() + ")");
                dw.SetItemDecimal(row, "colsorce", Convert.ToInt16(dr["nurscore_int"]));
                for (int j = 0; j < drArr.Length; j++)
                {
                    dtm = Convert.ToDateTime(drArr[j]["chargedate"]);
                    dw.SetItemDecimal(row, "coldate_" + dtm.Day.ToString(), Convert.ToInt16(drArr[j]["execount"]));
                    dclSum += Convert.ToDecimal(drArr[j]["execount"]);
                }
                dw.SetItemDecimal(row, "colSum", dclSum);
            }

            dw.CalculateGroups();
            dw.SetRedrawOn();
            dw.Refresh();
            dw.PrintProperties.Preview = false;
            dw.PrintProperties.ShowPreviewRulers = false;
            dt.Dispose(); 
            dt = null;
        }
        #endregion 

    }

    /// <summary>
    /// 查找控制类
    /// </summary>
    public class clsCtl_CommonFind : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_CommonFind objSvc;
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.Reports.frmCommonFind m_objViewer;
        /// <summary>
        /// 入院登记处调用标志
        /// </summary>
        internal bool BlnInReg = false;

        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_CommonFind()
        {
            objSvc = new clsDcl_CommonFind();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmCommonFind)frmMDI_Child_Base_in;
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        public void m_mthFind()
        {
            string SqlWhereMZ = "", SqlWhereZY = "";
            this.m_mthGetsqlwhere(out SqlWhereZY, out SqlWhereMZ);

            //门诊
            SqlWhereMZ = SqlWhereMZ.Trim();

            if (SqlWhereMZ.StartsWith("or"))
            {
                SqlWhereMZ = SqlWhereMZ.Substring(2);
            }
            else if (SqlWhereMZ.StartsWith("and"))
            {
                SqlWhereMZ = SqlWhereMZ.Substring(3);
            }

            bool IsIncludeMZ = this.m_objViewer.chkMZ.Checked;

            //住院
            SqlWhereZY = SqlWhereZY.Trim();

            if (SqlWhereZY.StartsWith("or"))
            {
                SqlWhereZY = SqlWhereZY.Substring(2);
            }
            else if (SqlWhereZY.StartsWith("and"))
            {
                SqlWhereZY = SqlWhereZY.Substring(3);
            }

            if (!SqlWhereZY.Trim().StartsWith("(to_char"))
            {
                SqlWhereZY = "(" + SqlWhereZY + ")";
            }

            if (SqlWhereZY.Length > 8)
            {
                SqlWhereZY = " and " + SqlWhereZY;
            }
            else
            {
                SqlWhereZY = "";
            }

            clsPublic.PlayAvi("正在查找病人资料库，请稍候...");

            clsCommonQueryDate_VO CommonQueryDate_VO = new clsCommonQueryDate_VO();
            if (this.m_objViewer.chkInDate.Checked == false && this.m_objViewer.chkOutDate.Checked == false)
            {
                CommonQueryDate_VO.QueryType = 0;
            }
            else
            {
                if (this.m_objViewer.chkInDate.Checked && this.m_objViewer.chkOutDate.Checked)
                {
                    CommonQueryDate_VO.QueryType = 3;
                    CommonQueryDate_VO.BeginDate_In = this.m_objViewer.dtBegin_in.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    CommonQueryDate_VO.EndDate_In = this.m_objViewer.dtEnd_in.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                    CommonQueryDate_VO.BeginDate_Out = this.m_objViewer.dtBegin_out.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    CommonQueryDate_VO.EndDate_Out = this.m_objViewer.dtEnd_out.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                }
                else
                {
                    if (this.m_objViewer.chkInDate.Checked)
                    {
                        CommonQueryDate_VO.QueryType = 1;
                        CommonQueryDate_VO.BeginDate_In = this.m_objViewer.dtBegin_in.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                        CommonQueryDate_VO.EndDate_In = this.m_objViewer.dtEnd_in.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                    }
                    else if (this.m_objViewer.chkOutDate.Checked)
                    {
                        CommonQueryDate_VO.QueryType = 2;
                        CommonQueryDate_VO.BeginDate_Out = this.m_objViewer.dtBegin_out.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                        CommonQueryDate_VO.EndDate_Out = this.m_objViewer.dtEnd_out.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                    }
                }
            }

            DataTable dt = new DataTable();
            long l = this.objSvc.m_lngGetPatientinfo(SqlWhereZY, this.m_objViewer.Status, IsIncludeMZ, SqlWhereMZ, CommonQueryDate_VO, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                this.m_mthSetval(dt);
                clsPublic.CloseAvi();
            }
            else
            {
                this.m_objViewer.lsvPatient.BeginUpdate();
                this.m_objViewer.lsvPatient.Items.Clear();
                this.m_objViewer.lsvPatient.EndUpdate();
                clsPublic.CloseAvi();
                MessageBox.Show("没有找到满足查询条件的病人信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.lblInfo.Text = "找到满足条件的记录数： 0条";

                if (this.m_objViewer.txtCardNo.Text.Trim() != "")
                {
                    this.m_objViewer.txtCardNo.Focus();
                    this.m_objViewer.txtCardNo.SelectAll();
                }
                else if (this.m_objViewer.txtZyh.Text.Trim() != "")
                {
                    this.m_objViewer.txtZyh.Focus();
                    this.m_objViewer.txtZyh.SelectAll();
                }
                else if (this.m_objViewer.txtName.Text.Trim() != "")
                {
                    this.m_objViewer.txtName.Focus();
                    this.m_objViewer.txtName.SelectAll();
                }
            }
        }
        #endregion

        #region 得到查找条件
        /// <summary>
        /// 得到查找条件
        /// </summary>        
        private void m_mthGetsqlwhere(out string SqlWhereZY, out string SqlWhereMZ)
        {
            SqlWhereZY = "";
            SqlWhereMZ = "1 <> 1";
            string Match = "";

            if (this.m_objViewer.chkMatch.Checked)
            {
                Match = "%";
            }

            string Unlogic = "";
            bool Union = true;

            if (this.m_objViewer.chkUnionAnd.Checked)
            {
                Unlogic = "and";
            }
            else if (this.m_objViewer.chkUnionOr.Checked)
            {
                Unlogic = "or";
            }
            else
            {
                Union = false;
            }

            if (this.m_objViewer.txtZyh.Text.Trim() != "")
            {
                SqlWhereZY = "a.inpatientid_chr like '" + this.m_objViewer.txtZyh.Text.Trim() + Match + "'";
                if (!Union)
                {
                    return;
                }
            }

            if (this.m_objViewer.txtCardNo.Text.Trim() != "")
            {
                SqlWhereZY += Unlogic + " f.patientcardid_chr like '" + this.m_objViewer.txtCardNo.Text.Trim() + Match + "'";
                SqlWhereMZ = " f.patientcardid_chr like '" + this.m_objViewer.txtCardNo.Text.Trim() + Match + "'";
                if (!Union)
                {
                    return;
                }
            }

            if (this.m_objViewer.txtName.Text.Trim() != "")
            {
                SqlWhereZY += Unlogic + " b.lastname_vchr like '" + this.m_objViewer.txtName.Text.Trim() + Match + "'";

                if (SqlWhereMZ.Trim() == "1 <> 1")
                {
                    SqlWhereMZ = Unlogic + " b.lastname_vchr like '" + this.m_objViewer.txtName.Text.Trim() + Match + "'";
                }
                else
                {
                    SqlWhereMZ += Unlogic + " b.lastname_vchr like '" + this.m_objViewer.txtName.Text.Trim() + Match + "'";
                }
                if (!Union)
                {
                    return;
                }
            }
        }
        #endregion

        #region 隐式查找
        /// <summary>
        /// 隐式查找
        /// </summary>
        /// <param name="Val">值</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>
        /// <param name="type">类型 0 住院号 1 诊疗卡号 2 姓名</param>
        /// <param name="IsIncludeMZ">是否查找门诊信息 true 是 false 否</param>
        /// <returns>记录数</returns>
        public int m_mthFind(string Val, bool Ismatch, int type, bool IsIncludeMZ)
        {
            string SqlWhereZY = "", SqlWhereMZ = "";
            string Match = "";

            if (Ismatch)
            {
                Match = "%";
            }

            switch (type)
            {
                case 0:
                    SqlWhereZY = "a.inpatientid_chr like '" + Val + Match + "'";
                    SqlWhereMZ = "1 <> 1";
                    break;
                case 1:
                    SqlWhereZY += "f.patientcardid_chr like '" + Val + Match + "'";
                    SqlWhereMZ = "a.inpatientid_chr like '" + Val + Match + "'";
                    break;
                case 2:
                    SqlWhereZY += "b.lastname_vchr like '" + Val + Match + "'";
                    SqlWhereMZ = "a.inpatientid_chr like '" + Val + Match + "'";
                    break;
            }

            SqlWhereZY = " and " + SqlWhereZY;

            DataTable dt = new DataTable();
            long l = this.objSvc.m_lngGetPatientinfo(SqlWhereZY, this.m_objViewer.Status, IsIncludeMZ, SqlWhereMZ, null, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                this.m_mthSetval(dt);
            }
            else
            {
                return 0;
            }

            return dt.Rows.Count;
        }

        /// <summary>
        /// 隐式查找
        /// </summary>
        /// <param name="Name">姓名</param>
        /// <param name="Sex">性别</param>
        /// <param name="Type">入院类型(1 普通 2 留观)</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>
        /// <param name="IsIncludeMZ">是否查找门诊信息 true 是 false 否</param>
        /// <returns>记录数</returns>
        public int m_mthFind(string Name, string Sex, int Type, bool Ismatch, bool IsIncludeMZ)
        {
            string Match = "";

            if (Ismatch)
            {
                Match = "%";
            }

            string SqlWhereZY = " and b.lastname_vchr like '" + Name + Match + "' and b.sex_chr = '" + Sex + "' and a.inpatientnotype_int = " + Type.ToString();
            string SqlWhereMZ = "b.lastname_vchr like '" + Name + Match + "' and b.sex_chr = '" + Sex + "'";

            DataTable dt = new DataTable();
            long l = this.objSvc.m_lngGetPatientinfo(SqlWhereZY, this.m_objViewer.Status, IsIncludeMZ, SqlWhereMZ, null, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                this.m_mthSetval(dt);
            }
            else
            {
                return 0;
            }

            return dt.Rows.Count;
        }
        #endregion

        #region 显示结果
        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="dt"></param>
        private void m_mthSetval(DataTable dt)
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            this.m_objViewer.lsvPatient.BeginUpdate();
            this.m_objViewer.lsvPatient.Items.Clear();

            string status = "";
            string feestatus = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["feestatus_int"].ToString())
                {
                    case "0":
                        feestatus = "新";
                        break;
                    case "1":
                        feestatus = "待清";
                        break;
                    case "2":
                        feestatus = "清帐";
                        break;
                    case "3":
                        feestatus = "清帐";
                        break;
                    case "4":
                        feestatus = "呆帐清帐";
                        break;
                    case "5":
                        feestatus = "待清";
                        break;
                }

                switch (dt.Rows[i]["pstatus_int"].ToString())
                {
                    case "0":
                        status = "无床";
                        break;
                    case "1":
                        status = "在床";
                        break;
                    case "2":
                        status = "预出院";
                        if (dt.Rows[i]["feestatus_int"].ToString() != "5")
                        {
                            feestatus = "待结";
                        }
                        break;
                    case "3":
                        status = "出院";
                        break;
                    case "4":
                        status = "请假";
                        break;
                    case "999":
                        status = "门诊";
                        break;
                }

                ListViewItem lvitem = new ListViewItem((Convert.ToInt32(i + 1)).ToString());
                lvitem.SubItems.Add(status);

                if (status == "门诊")
                {
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add(dt.Rows[i]["lastname_vchr"].ToString().Trim());
                    lvitem.SubItems.Add(dt.Rows[i]["sex_chr"].ToString().Trim());
                    if (dt.Rows[i]["cssj"].ToString().Trim() == "")
                    {
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add("");
                    }
                    else
                    {
                        lvitem.SubItems.Add(clsPublic.CalcAge(Convert.ToDateTime(dt.Rows[i]["birth_dat"])));
                        lvitem.SubItems.Add(dt.Rows[i]["cssj"].ToString());
                    }
                    lvitem.SubItems.Add(dt.Rows[i]["homeaddress_vchr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["employer_vchr"].ToString());
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add(dt.Rows[i]["patientcardid_chr"].ToString());
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add(dt.Rows[i]["patientid_chr"].ToString());

                    lvitem.BackColor = clsPublic.CustomBackColor;
                }
                else
                {
                    lvitem.SubItems.Add(feestatus);
                    lvitem.SubItems.Add(dt.Rows[i]["inpatientid_chr"].ToString().Trim());
                    lvitem.SubItems.Add(dt.Rows[i]["inpatientcount_int"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["deptname_vchr"].ToString().Trim());
                    lvitem.SubItems.Add(dt.Rows[i]["lastname_vchr"].ToString().Trim());
                    lvitem.SubItems.Add(dt.Rows[i]["sex_chr"].ToString().Trim());
                    if (dt.Rows[i]["cssj"].ToString().Trim() == "")
                    {
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add("");
                    }
                    else
                    {
                        lvitem.SubItems.Add(clsPublic.CalcAge(Convert.ToDateTime(dt.Rows[i]["birth_dat"])));
                        lvitem.SubItems.Add(dt.Rows[i]["cssj"].ToString());
                    }
                    lvitem.SubItems.Add(dt.Rows[i]["homeaddress_vchr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["employer_vchr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["rysj"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["cysj"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["patientcardid_chr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["registerid_chr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["patientid_chr"].ToString());

                    lvitem.BackColor = Color.FromArgb(255, 255, 255);
                }


                lvitem.ImageIndex = 0;
                lvitem.Tag = dt.Rows[i];
                this.m_objViewer.lsvPatient.Items.Add(lvitem);
            }

            this.m_objViewer.lblInfo.Text = "找到满足条件的记录数： " + dt.Rows.Count.ToString() + "条";

            this.m_objViewer.lsvPatient.EndUpdate();
            this.m_objViewer.Cursor = Cursors.Default;

            if (dt.Rows.Count > 0)
            {
                this.m_objViewer.lsvPatient.Items[0].Selected = true;
                this.m_objViewer.lsvPatient.Focus();
            }
        }
        #endregion

        #region 浏览病区床位信息
        /// <summary>
        /// 浏览病区床位信息
        /// </summary>
        public void m_mthFindArea()
        {
            clsDcl_Charge objCharge = new clsDcl_Charge();
            DataTable dt = new DataTable();

            long l = objCharge.m_lngGetDeptArea(out dt, 2);
            if (l == 0)
            {
                return;
            }

            frmAreaBedInfo f = new frmAreaBedInfo(dt, 0);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.RegisterID = f.regid;
                this.m_objViewer.PatientID = f.pid;
                this.m_objViewer.Zyh = f.Zyh;
                this.m_objViewer.Zycs = f.Zycs;
                this.m_objViewer.PatName = f.patname;
                this.m_objViewer.InType = 1;

                clsPublic.m_mthWriteParm(f.regid, f.Zyh, f.CardNo);
                this.m_objViewer.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region 返回选择的病人信息
        /// <summary>
        /// 返回选择的病人信息
        /// </summary>
        public void m_mthGetPatientinfo()
        {
            if (this.m_objViewer.lsvPatient.Items.Count == 0 || this.m_objViewer.lsvPatient.SelectedItems.Count == 0)
            {
                return;
            }

            DataRow dr = (DataRow)(this.m_objViewer.lsvPatient.SelectedItems[0].Tag);

            if (dr["pstatus_int"].ToString() == "999")
            {
                if (!BlnInReg)
                {
                    MessageBox.Show("请选择住院病人！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //else
            //{
            //    string[] statusinfo = new string[5] { "下床", "在床", "预出院", "实际出院", "请假" };
            //    int statusno = int.Parse(dr["pstatus_int"].ToString());
            //    if (statusno != this.m_objViewer.Status)
            //    {
            //        MessageBox.Show("当前病人为【" + statusinfo[statusno] + "】状态，请重新选择。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}

            this.m_objViewer.RegisterID = dr["registerid_chr"].ToString();
            this.m_objViewer.PatientID = dr["patientid_chr"].ToString();
            this.m_objViewer.Zyh = dr["inpatientid_chr"].ToString();
            this.m_objViewer.Zycs = int.Parse(dr["inpatientcount_int"].ToString());
            this.m_objViewer.CardNo = dr["patientcardid_chr"].ToString();
            this.m_objViewer.PatName = dr["lastname_vchr"].ToString();
            this.m_objViewer.OutDate = dr["cysj"].ToString();
            this.m_objViewer.InType = int.Parse(dr["inpatientnotype_int"].ToString());

            clsPublic.m_mthWriteParm(this.m_objViewer.RegisterID, this.m_objViewer.Zyh, this.m_objViewer.CardNo);
            this.m_objViewer.DialogResult = DialogResult.OK;
        }
        #endregion
    }


}
