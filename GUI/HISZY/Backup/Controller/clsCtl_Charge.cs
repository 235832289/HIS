using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 结算业务公用逻辑控制类
    /// </summary>
    public class clsCtl_Charge : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_Charge()
        {
            objSvc = new clsDcl_Charge();
        }
        #endregion

        #region 变量
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_Charge objSvc;
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmCharge m_objViewer;
        /// <summary>
        /// 员工DataTable
        /// </summary>
        private DataTable dtEmployee;
        /// <summary>
        /// 科室(病区)DataTable
        /// </summary>
        private DataTable dtDept;
        /// <summary>
        /// 收费项目发票分类
        /// </summary>
        private DataTable dtCat;
        /// <summary>
        /// 待结项目数据源
        /// </summary>
        internal DataTable dtSource;
        #endregion

        #region 检查发票号规则
        /// <summary>
        /// 检查发票号规则
        /// </summary>
        /// <returns>正确 true 错误 false</returns>
        public bool m_blnCheckInvoiceNoExpression(string CurrInvoNo)
        {
            string InvoExp = clsPublic.m_strReadXML("BeInHospital", "InvoiceNoExp", "AnyOne");
            Regex r = new Regex(InvoExp);
            Match m = r.Match(CurrInvoNo);
            if (m.Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show("当前发票号的编号规则不正确。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
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
            m_objViewer = (frmCharge)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void m_mthInit()
        {
            this.m_objViewer.ucPatientInfo.m_mthSetRedraw();
            if (this.m_objViewer.ChargeType == "1")
            {
                this.m_objViewer.ucPatientInfo.Status = 2;
            }
            else
            {
                this.m_objViewer.ucPatientInfo.Status = 9;
            }
            this.m_objViewer.ucPatientInfo.ShowFeeCheckStatusFlag = true;

            this.objSvc.m_lngGetEmployee(out dtEmployee);
            this.objSvc.m_lngGetDeptArea(out dtDept, 2);
            this.objSvc.m_lngGetChargeItemCat(4, out dtCat);

            this.m_objViewer.lblInfo.Visible = false;
            this.m_objViewer.lblDays.Visible = false;
        }
        #endregion

        #region 快捷
        /// <summary>
        /// 快捷
        /// </summary>
        /// <param name="key"></param>
        public void m_mthShortCut(KeyEventArgs key)
        {
            switch (key.KeyCode)
            {
                case Keys.F3:
                    this.m_mthFind();
                    break;
                case Keys.F8:
                    this.m_mthCharge();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        public void m_mthFind()
        {
            frmCommonFind f = new frmCommonFind("查找在院病人资料", this.m_objViewer.ucPatientInfo.Status);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.ucPatientInfo.m_mthFind(f.RegisterID, 3);
                if (this.m_objViewer.ucPatientInfo.IsChanged)
                {
                    this.m_mthGetData();
                }
            }
        }
        #endregion

        #region 定位
        #region 根据员工ID转换成姓名
        /// <summary>
        /// 根据员工ID转换成姓名
        /// </summary>
        /// <param name="EmpID"></param>
        /// <returns></returns>
        public string GetEmpName(string EmpID)
        {
            string Ret = "";

            for (int i = 0; i < dtEmployee.Rows.Count; i++)
            {
                if (EmpID == dtEmployee.Rows[i]["empid_chr"].ToString().Trim())
                {
                    Ret = dtEmployee.Rows[i]["lastname_vchr"].ToString();
                    break;
                }
            }

            return Ret;
        }
        #endregion

        #region 根据科室ID转换成科室名称
        /// <summary>
        /// 根据科室ID转换成科室名称
        /// </summary>
        /// <param name="DeptID"></param>
        /// <returns></returns>
        public string GetDeptName(string DeptID)
        {
            string Ret = "";

            for (int i = 0; i < dtDept.Rows.Count; i++)
            {
                if (DeptID == dtDept.Rows[i]["deptid_chr"].ToString().Trim())
                {
                    Ret = dtDept.Rows[i]["deptname_vchr"].ToString();
                    break;
                }
            }

            return Ret;
        }
        #endregion

        #region 根据发票分类ID转换成中文类别
        /// <summary>
        /// 根据发票分类ID转换成中文类别
        /// </summary>
        /// <param name="TypeNo"></param>
        /// <returns></returns>
        public string GetCatName(string TypeNo)
        {
            string Ret = "";

            for (int i = 0; i < dtCat.Rows.Count; i++)
            {
                if (TypeNo == dtCat.Rows[i]["typeid_chr"].ToString().Trim())
                {
                    Ret = dtCat.Rows[i]["typename_vchr"].ToString();
                    break;
                }
            }

            return Ret;
        }
        #endregion
        #endregion

        #region 自动检索待结费用
        /// <summary>
        /// 自动检索待结费用
        /// </summary>
        public void m_mthGetData()
        {
            if (this.m_objViewer.ChargeType == "1")
            {
                //this.m_objViewer.Cursor = Cursors.WaitCursor;
                //if (clsPublic.m_blnChargeContinueItem(this.m_objViewer.ucPatientInfo.RegisterID, this.m_objViewer.LoginInfo.m_strEmpID) == false)
                //{
                //    this.m_objViewer.Cursor = Cursors.Default;
                //    MessageBox.Show("数据结算异常，结帐终止。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    return;
                //}
                //this.m_objViewer.Cursor = Cursors.Default;
            }

            clsPublic.PlayAvi("findFILE.avi", "正在检索数据，请稍候...");

            this.m_objViewer.lvInvoiceCat.Items.Clear();
            this.m_objViewer.dtItem.Rows.Clear();
            this.m_objViewer.lblInfo.Visible = false;
            this.m_objViewer.lblDays.Visible = false;

            dtSource = null;
            long l = this.objSvc.m_lngGetFeeItemByActiveType(this.m_objViewer.ucPatientInfo.RegisterID, 888, "1", null, null, null, out dtSource);
            if (l > 0)
            {
                #region 显示发票分类
                //显示发票分类
                if (dtCat.Rows.Count > 0)
                {
                    ArrayList arrcat = new ArrayList();
                    DataView dvcat = new DataView(dtSource);

                    for (int i = 0; i < dtCat.Rows.Count; i++)
                    {
                        string invocatid = dtCat.Rows[i]["typeid_chr"].ToString().Trim();
                        decimal invosum = 0;

                        dvcat.RowFilter = "invcateid_chr = '" + invocatid + "'";
                        foreach (DataRowView drv in dvcat)
                        {
                            invosum += clsPublic.Round(clsPublic.ConvertObjToDecimal(drv["totalmony"]), 2);
                        }

                        if (invosum == 0)
                        {
                            continue;
                        }

                        clsInvoiceCat_VO invocat_vo = new clsInvoiceCat_VO();
                        invocat_vo.CatID = invocatid;
                        invocat_vo.CatName = dtCat.Rows[i]["typename_vchr"].ToString().Trim();
                        invocat_vo.CatSum = invosum;

                        arrcat.Add(invocat_vo);
                    }

                    for (int j = 0; j < arrcat.Count; j++)
                    {
                        clsInvoiceCat_VO invocat_vo = (clsInvoiceCat_VO)arrcat[j];

                        ListViewItem lvitem = new ListViewItem();
                        lvitem.Text = invocat_vo.CatName + "\r\n" + invocat_vo.CatSum.ToString("0.00");
                        lvitem.ImageIndex = 11;
                        lvitem.Tag = invocat_vo;
                        this.m_objViewer.lvInvoiceCat.Items.Add(lvitem);
                    }
                }
                #endregion

                //填充数据
                this.m_mthFillData(dtSource);
            }

            this.m_blnBatchCharge(true);

            if (this.m_objViewer.ucPatientInfo.FeeCheckStatus == 3)
            {
                this.m_objViewer.btnCheckStatus.Enabled = false;
            }
            else
            {
                this.m_objViewer.btnCheckStatus.Enabled = true;
            }

            clsPublic.CloseAvi();
        }

        #region 填充数据
        /// <summary>
        /// 填充数据
        /// </summary>
        /// <param name="dt"></param>
        public void m_mthFillData(DataTable dt)
        {
            #region 填充数据
            this.m_objViewer.dtItem.Rows.Clear();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string[] sarr = new string[20];

                sarr[0] = Convert.ToString(i + 1);

                if (dr["chargeactive_dat"].ToString().Trim() != "")
                {
                    sarr[1] = Convert.ToDateTime(dr["chargeactive_dat"].ToString()).ToString("yyyyMMdd");
                }
                else
                {
                    sarr[1] = "";
                }
                //费用类型 0 加收(滚费) 1 长嘱 2 临嘱 3 长嘱新开加 4 出院带药 7 补期帐 8 直收 9 补记帐
                string ordertype = dr["orderexectype_int"].ToString();
                if (ordertype == "0")
                {
                    ordertype = "加收";
                }
                else if (ordertype == "1")
                {
                    ordertype = "长嘱";
                }
                else if (ordertype == "2")
                {
                    ordertype = "临嘱";
                }
                else if (ordertype == "3")
                {
                    ordertype = "新开加";
                }
                else if (ordertype == "4")
                {
                    ordertype = "出院带药";
                }
                else if (ordertype == "7")
                {
                    ordertype = "补期帐";
                }
                else if (ordertype == "8")
                {
                    ordertype = "直收";
                }
                else if (ordertype == "9")
                {
                    ordertype = "补记帐";
                }

                sarr[2] = ordertype;
                sarr[3] = dr["recno"].ToString();
                sarr[4] = dr["itemcode_vchr"].ToString();
                sarr[5] = dr["chargeitemname_chr"].ToString();
                sarr[6] = dr["amount_dec"].ToString();

                decimal d = clsPublic.ConvertObjToDecimal(dr["amount_dec"]) * clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]);
                sarr[7] = d.ToString("0.00");
                sarr[8] = dr["unitprice_dec"].ToString();
                sarr[9] = dr["precent_dec"].ToString();

                d = d * clsPublic.ConvertObjToDecimal(dr["precent_dec"]) / 100;
                sarr[10] = d.ToString("0.00");
                sarr[11] = dr["spec_vchr"].ToString();
                sarr[12] = dr["unit_vchr"].ToString();
                sarr[13] = GetDeptName(dr["curareaid_chr"].ToString().Trim());
                sarr[14] = GetCatName(dr["invcateid_chr"].ToString().Trim());
                sarr[15] = GetEmpName(dr["doctorid_chr"].ToString().Trim());
                sarr[16] = GetEmpName(dr["activator_chr"].ToString().Trim());

                string activetype = dr["activatetype_int"].ToString();
                if (activetype == "1")
                {
                    activetype = "其它";
                }
                else if (activetype == "2")
                {
                    activetype = "补记帐";
                }
                else if (activetype == "3")
                {
                    activetype = "确认记帐";
                }
                else if (activetype == "4")
                {
                    activetype = "确认收费";
                }
                else if (activetype == "5")
                {
                    activetype = "直接收费";
                }
                sarr[17] = activetype;
                sarr[18] = GetDeptName(dr["createarea_chr"].ToString().Trim());
                sarr[19] = dr["execarea"].ToString();

                this.m_objViewer.dtItem.Rows.Add(sarr);

                if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                {
                    this.m_objViewer.dtItem.Rows[i].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }
            }

            if (dt.Rows.Count == 0)
            {
                this.m_objViewer.lblInfo.Visible = true;
            }
            #endregion
        }
        #endregion
        #endregion

        #region 自动补滚费
        /// <summary>
        /// 自动补滚费
        /// </summary>
        /// <param name="OnlyShow"></param>
        /// <returns></returns>
        public bool m_blnBatchCharge(bool OnlyShow)
        {
            //以诊金(或床位费)滚费最大时间->计算补记滚费次数

            string RegID = this.m_objViewer.ucPatientInfo.RegisterID;
            if (RegID == "")
            {
                return false;
            }

            //返回值
            long l = 0;

            //入院时间
            string inhospdate = this.m_objViewer.ucPatientInfo.BihPatient_VO.InHospitalDate;

            //滚费时间                
            DateTime dt1 = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:01");
            DateTime dt2 = Convert.ToDateTime(inhospdate.Substring(0, 10) + " 00:00:01");

            //获取最后滚费生成时间
            string FinallyDate = this.objSvc.GetDayAccountsMaxDate(RegID);
            if (FinallyDate != "")
            {
                dt2 = Convert.ToDateTime(FinallyDate.Substring(0, 10) + " 00:00:01");
            }
            else
            {
                dt2 = dt2.AddDays(-1);
            }

            TimeSpan ts = dt1.Subtract(dt2);

            if (ts.Days > 1)
            {
                if (OnlyShow)
                {
                    this.m_objViewer.lblDays.Visible = true;
                    this.m_objViewer.lblDays.Text = "未滚费天数：" + Convert.ToString(ts.Days - 1) + "天";
                    return true;
                }

                /***补滚费***/
                //每日滚费时刻(HH:mm:ss)
                string autoFeeTime = " 23:59:59"; /*读取参数设置*/
                string CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                try
                {
                    clsPublic.PlayAvi("findFILE.avi", "正在补滚费用，请稍候...");

                    for (int i = 1; i < ts.Days; i++)
                    {
                        string autoFeeDate = dt2.AddDays(i).ToString("yyyy-MM-dd") + autoFeeTime;
                        l = this.objSvc.AutoCharge(CreateTime, autoFeeDate, this.m_objViewer.LoginInfo.m_strEmpID, RegID, 2);
                        if (l < 0)
                        {
                            clsPublic.CloseAvi();
                            MessageBox.Show("补滚费用失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                    }

                    clsPublic.CloseAvi();
                    this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
                }
                catch (Exception ex)
                {
                    clsPublic.CloseAvi();
                    MessageBox.Show("补滚费用失败。" + ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 结帐处理:将待结转为待清,同时生成一笔期帐.(含补滚费)
        /// <summary>
        /// 结帐处理:将待结转为待清,同时生成一笔期帐.(含补滚费)
        /// </summary>
        public void m_mthCharge()
        {
            if (!this.m_blnBatchCharge(false))
            {
                return;
            }

            if (this.dtSource.Rows.Count == 0)
            {
                MessageBox.Show("该病人没有待结费用。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (MessageBox.Show("结帐收费项目前请再次确认？ [是]-确认 [否]-取消", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }
            }

            frmDayReckoningRemark fremark = new frmDayReckoningRemark();
            fremark.Text = "结帐备注";
            DialogResult dg = fremark.ShowDialog();
            if (dg == DialogResult.Yes || dg == DialogResult.OK)
            {
                clsBihDayAccounts_VO DayAccounts_VO = new clsBihDayAccounts_VO();
                DayAccounts_VO.RegisterID = this.m_objViewer.ucPatientInfo.RegisterID;
                DayAccounts_VO.PatientID = this.m_objViewer.ucPatientInfo.BihPatient_VO.PatientID;
                DayAccounts_VO.AreaID = this.m_objViewer.ucPatientInfo.BihPatient_VO.AreaID;
                DayAccounts_VO.Note = fremark.RemarkInfo;
                DayAccounts_VO.CurrAreaID = this.m_objViewer.ucPatientInfo.BihPatient_VO.AreaID;
                DayAccounts_VO.OperID = this.m_objViewer.LoginInfo.m_strEmpID;
                DayAccounts_VO.Type = "1";

                //计算总金额、自付金额和记帐金额
                decimal decTotalSum = 0;
                decimal decSbSum = 0;
                decimal decAcctSum = 0;

                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    decimal d = clsPublic.ConvertObjToDecimal(dtSource.Rows[i]["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(dtSource.Rows[i]["amount_dec"]);
                    decTotalSum += clsPublic.Round(d, 2);
                    decSbSum += clsPublic.Round(d * clsPublic.ConvertObjToDecimal(dtSource.Rows[i]["precent_dec"]) / 100, 2);
                }

                DayAccounts_VO.TotalSum = decTotalSum;
                DayAccounts_VO.SbSum = decSbSum;
                DayAccounts_VO.AcctSum = decAcctSum;

                long l = this.objSvc.m_lngBuildDayAccounts(DayAccounts_VO, this.m_objViewer.LoginInfo.m_strEmpID, int.Parse(this.m_objViewer.ChargeType));
                if (l > 0)
                {
                    //出院结帐立即腾出床位
                    if (this.m_objViewer.ChargeType == "1")
                    {
                        this.objSvc.m_lngClearBed(this.m_objViewer.ucPatientInfo.RegisterID);
                        this.objSvc.m_lngUpdatePatientChargeCheckStatus(this.m_objViewer.ucPatientInfo.RegisterID, "3");
                    }

                    MessageBox.Show("结帐成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
                }
            }
        }
        #endregion

        #region 补期帐
        /// <summary>
        /// 补期帐
        /// </summary>
        public void m_mthPatchDayAccount()
        {
            frmPatchDayAccount fP = new frmPatchDayAccount(this.m_objViewer.ucPatientInfo.BihPatient_VO);
            fP.ShowDialog();
            if (fP.ModifyFlag)
            {
                this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
            }
        }
        #endregion

        #region 更新费用核对状态
        /// <summary>
        /// 更新费用核对状态
        /// </summary>
        /// <param name="CheckStatus"></param>
        public void m_mthUpdateCheckStatus(string CheckStatus)
        {
            if (this.m_objViewer.ucPatientInfo.RegisterID.Trim() == "")
            {
                return;
            }

            this.m_objViewer.ucPatientInfo.FeeCheckStatus = int.Parse(CheckStatus);
            this.m_objViewer.ucPatientInfo.m_mthShowFeeCheckStatus();
            this.objSvc.m_lngUpdatePatientChargeCheckStatus(this.m_objViewer.ucPatientInfo.RegisterID, CheckStatus);
        }
        #endregion

    }
}
