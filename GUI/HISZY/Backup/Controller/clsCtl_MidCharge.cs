using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 中途结算逻辑控制类
    /// </summary>
    public class clsCtl_MidCharge : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_MidCharge()
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
        com.digitalwave.iCare.gui.HIS.frmMidCharge m_objViewer;

        /// <summary>
        /// 当前病人费用期帐明细
        /// </summary>
        private DataTable ChargeDt;

        /// <summary>
        /// 选择结算的费用明细
        /// </summary>
        private DataTable ChargeDtSelect;

        /// <summary>
        /// 结算类型 1 按期帐 2 按明细
        /// </summary>
        internal int intType = 1;

        /// <summary>
        /// 期帐DATATABLE
        /// </summary>
        private DataTable DayAccountDt;

        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMidCharge)frmMDI_Child_Base_in;
        }
        #endregion

        #region 快捷
        /// <summary>
        /// 快捷
        /// </summary>
        /// <param name="ky"></param>
        public void m_mthShortCut(KeyEventArgs ky)
        {
            switch (ky.KeyCode)
            {
                case Keys.F3:
                    this.m_mthFind();
                    break;
                case Keys.F4:
                    this.m_objViewer.chkAll.Checked = !(this.m_objViewer.chkAll.Checked);
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
                    this.m_mthReset();
                    this.m_mthGetDayaccountsInfo();
                }
            }
        }
        #endregion

        #region 重置
        /// <summary>
        /// 重置
        /// </summary>
        public void m_mthReset()
        {
            this.m_objViewer.lblTotalSum.Text = "";
            this.m_objViewer.lblSbSum.Text = "";
            this.m_objViewer.lblAcctSum.Text = "";
            this.m_objViewer.lvInvoiceCat.Items.Clear();
            if (ChargeDtSelect != null)
            {
                ChargeDtSelect.Rows.Clear();
            }
            this.m_objViewer.chkAll.Checked = false;
        }
        #endregion

        #region 全选期帐
        /// <summary>
        /// 全选期帐
        /// </summary>        
        public void m_mthAllSelect()
        {
            if (this.m_objViewer.dtgMain.Rows.Count == 0 || this.m_objViewer.rdoMx.Checked)
            {
                return;
            }

            if (this.m_objViewer.chkAll.Checked)
            {
                for (int i = 0; i < this.m_objViewer.dtgMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.dtgMain.Rows[i].Cells[0].ReadOnly)
                    {
                        continue;
                    }
                    else
                    {
                        if (this.m_objViewer.dtgMain.Rows[i].Selected)
                        {
                            for (int j = 0; j < this.m_objViewer.dtgDetail.Rows.Count; j++)
                            {
                                this.m_objViewer.dtgDetail.Rows[j].Cells[0].Value = "T";
                            }
                        }

                        this.m_objViewer.dtgMain.Rows[i].Cells[0].Value = "T";
                    }
                }

                this.m_mthGetCheckType(1);
            }
            else
            {
                for (int i = 0; i < this.m_objViewer.dtgMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.dtgMain.Rows[i].Selected)
                    {
                        for (int j = 0; j < this.m_objViewer.dtgDetail.Rows.Count; j++)
                        {
                            this.m_objViewer.dtgDetail.Rows[j].Cells[0].Value = "F";
                        }
                    }

                    this.m_objViewer.dtgMain.Rows[i].Cells[0].Value = "F";
                }

                this.m_mthReset();
            }
        }
        #endregion

        #region 获取期帐信息
        /// <summary>
        /// 获取期帐信息
        /// </summary>
        public void m_mthGetDayaccountsInfo()
        {
            string regid = this.m_objViewer.ucPatientInfo.RegisterID;

            if (regid == "")
            {
                return;
            }

            this.m_objViewer.dtgMain.Rows.Clear();
            this.m_objViewer.dtgDetail.Rows.Clear();
            ChargeDt = null;
            ChargeDtSelect = null;

            long l = this.objSvc.m_lngGetPatientDayaccountsByRegID(regid, out DayAccountDt);
            if (l > 0 && DayAccountDt.Rows.Count > 0)
            {
                l = this.objSvc.m_lngGetChargeInfoByID(regid, 1, out ChargeDt);
                if (l > 0)
                {
                    for (int i = 0; i < DayAccountDt.Rows.Count; i++)
                    {
                        decimal d = 0;
                        string[] s = new string[6];
                        
                        s[0] = "F";
                        s[1] = DayAccountDt.Rows[i]["orderno_int"].ToString();
                        s[2] = Convert.ToDateTime(DayAccountDt.Rows[i]["square_dat"].ToString()).ToString("yyyyMMddHHmm");
                        s[3] = clsPublic.ConvertObjToDecimal(DayAccountDt.Rows[i]["charge_dec"]).ToString("0.00");

                        d = clsPublic.ConvertObjToDecimal(DayAccountDt.Rows[i]["clearchg_dec"]);
                        if (d != 0)
                        {
                            s[4] = d.ToString("0.00");
                        }
                        else
                        {
                            s[4] = "";
                        }

                        d = clsPublic.Round(clsPublic.ConvertObjToDecimal(DayAccountDt.Rows[i]["charge_dec"]), 2) - clsPublic.Round(clsPublic.ConvertObjToDecimal(DayAccountDt.Rows[i]["clearchg_dec"]), 2);
                        if (d != 0)
                        {
                            s[5] = d.ToString("0.00");
                        }
                        else
                        {
                            s[5] = "";
                        }                                             
                        
                        int row = this.m_objViewer.dtgMain.Rows.Add(s);
                        this.m_objViewer.dtgMain.Rows[row].Tag = DayAccountDt.Rows[i];
                        
                        this.m_objViewer.dtgMain.Rows[row].DefaultCellStyle.BackColor = Color.White;
                        this.m_objViewer.dtgMain.Rows[row].Cells[0].ReadOnly = this.intType == 1 ? false : true;

                        if (s[3] == s[4])
                        {
                            this.m_objViewer.dtgMain.Rows[row].Cells[0].ReadOnly = true;
                            this.m_objViewer.dtgMain.Rows[row].DefaultCellStyle.ForeColor = Color.RoyalBlue;
                        }
                        else if (s[3] != s[4] && s[4] != "0" && s[4].Trim() != "")
                        {
                            this.m_objViewer.dtgMain.Rows[row].DefaultCellStyle.ForeColor = Color.SaddleBrown;
                        }

                        if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                        {
                            this.m_objViewer.dtgMain.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                        }
                    }
                }

                this.m_mthGetAccountsDetail(0);                
            }                           
        }
        #endregion

        #region 获取当前病人期帐明细
        /// <summary>
        /// 获取当前病人期帐明细
        /// </summary>
        /// <param name="CurrRow"></param>
        public void m_mthGetAccountsDetail(int CurrRow)
        {
            this.m_objViewer.dtgDetail.Rows.Clear();
            DataView dv = new DataView(ChargeDt);
            DataRow dr = (DataRow)this.m_objViewer.dtgMain.Rows[CurrRow].Tag;
            
            string dayaccountid = dr["dayaccountid_chr"].ToString();
            dv.RowFilter = "dayaccountid_chr = '" + dayaccountid + "'";
            dv.Sort = "chargeitemid_chr asc";

            int i = 1;            
            string strChecked = this.m_objViewer.dtgMain.Rows[CurrRow].Cells[0].Value.ToString();
            bool blnClearAccountsReadonly = (dr["charge_dec"].ToString() == dr["clearchg_dec"].ToString() ? true : false);

            foreach (DataRowView drv in dv)
            {
                string[] s = new string[12];

                s[0] = "F";
                s[1] = i.ToString();
                s[2] = drv["orderno_int"].ToString();
                s[3] = Convert.ToDateTime(drv["chargeactive_dat"].ToString()).ToString("yyyy-MM-dd");
                s[4] = drv["ipinvoname"].ToString().Trim();
                s[5] = drv["chargeitemname_chr"].ToString().Trim();
                s[6] = drv["amount_dec"].ToString();
                s[7] = drv["unitprice_dec"].ToString();
                
                //费用
                if (drv["pstatus_int"].ToString() == "3" || drv["pstatus_int"].ToString() == "4")
                {
                    s[8] = Convert.ToDecimal(drv["totalmoney_dec"]).ToString("0.00");
                    s[9] = drv["precent_dec"].ToString();
                    s[10] = Convert.ToDecimal(drv["acctmoney_dec"]).ToString("0.00");
                }
                else
                {
                    decimal d = clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]);
                    s[8] = d.ToString("0.00");
                    s[9] = drv["precent_dec"].ToString();

                    d = d * clsPublic.ConvertObjToDecimal(drv["precent_dec"]) / 100;
                    if (d != 0)
                    {
                        s[10] = d.ToString("0.00");
                    }
                    else
                    {
                        s[10] = "";
                    }
                }
                                
                //颜色
                Color FCR = Color.Black;
                Color BCR = this.m_objViewer.dtgMain.Rows[CurrRow].DefaultCellStyle.BackColor;
                //可用性
                bool blnReadOnly = false;
                //状态
                string StatusID = drv["pstatus_int"].ToString();
                string StatusName = "";
                if (StatusID == "0")
                {
                    StatusName = "待确认";
                    FCR = Color.FromArgb(200, 0, 0); 
                }
                else if (StatusID == "1")
                {
                    StatusName = "待结";
                    FCR = Color.FromArgb(200, 0, 0);                 
                }
                else if (StatusID == "2")
                {
                    StatusName = "待清";
                }
                else if (StatusID == "3")
                {
                    StatusName = "已清";
                    FCR = Color.RoyalBlue;                     
                    blnReadOnly = true;
                }
                else if (StatusID == "4")
                {
                    StatusName = "直收";
                    FCR = Color.RoyalBlue; 
                    blnReadOnly = true;
                }
                s[11] = StatusName;
                i++;
           
                int row = this.m_objViewer.dtgDetail.Rows.Add(s);
                this.m_objViewer.dtgDetail.Rows[row].Tag = drv;
                this.m_objViewer.dtgDetail.Rows[row].DefaultCellStyle.ForeColor = FCR;
                //this.m_objViewer.dtgDetail.Rows[row].DefaultCellStyle.BackColor = BCR;
                if (this.intType == 1 || blnReadOnly)
                {
                    this.m_objViewer.dtgDetail.Rows[row].Cells[0].ReadOnly = true;
                }
                             
                this.m_objViewer.dtgDetail.Rows[row].Cells[0].Value = strChecked;                

                if (blnClearAccountsReadonly)
                {
                    this.m_objViewer.dtgDetail.Rows[row].Cells[0].ReadOnly = true;                    
                }

                if (Math.IEEERemainder(Convert.ToDouble(row + 1), 2) == 0)
                {
                    this.m_objViewer.dtgDetail.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }               
            }
        }
        #endregion

        #region 获取费用发票分类
        /// <summary>
        /// 获取费用发票分类
        /// </summary>
        /// <param name="type">结算分类 1 按帐期 2 按明细</param>
        public void m_mthGetCheckType(int type)
        {
            DataView dv = new DataView(ChargeDt);
            ChargeDtSelect = ChargeDt.Clone();
             
            if (type == 1)
            {
                for (int i = 0; i < this.m_objViewer.dtgMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.dtgMain.Rows[i].Cells[0].Value.ToString().ToUpper() == "T")
                    {
                        DataRow dr = (DataRow)this.m_objViewer.dtgMain.Rows[i].Tag;
                        string dayaccountid = dr["dayaccountid_chr"].ToString();
                        dv.RowFilter = "dayaccountid_chr = '" + dayaccountid + "' and pstatus_int = 2";
                        
                        foreach (DataRowView drv in dv)
                        {
                            ChargeDtSelect.Rows.Add(drv.Row.ItemArray);
                        }
                        ChargeDtSelect.AcceptChanges();
                    }
                }   
            }
            else if (type == 2)
            {
                for (int i = 0; i < this.m_objViewer.dtgDetail.Rows.Count; i++)
                {
                    if (this.m_objViewer.dtgDetail.Rows[i].Cells[0].Value.ToString().ToUpper() == "T")
                    {
                        DataRowView drv = (DataRowView)this.m_objViewer.dtgDetail.Rows[i].Tag;
                        string pchargeid = drv["pchargeid_chr"].ToString();
                        dv.RowFilter = "pchargeid_chr = '" + pchargeid + "' and pstatus_int = 2";

                        foreach (DataRowView drv2 in dv)
                        {
                            ChargeDtSelect.Rows.Add(drv2.Row.ItemArray);
                        }
                        ChargeDtSelect.AcceptChanges();
                    }
                }
            }

            if (ChargeDtSelect.Rows.Count == 0)
            {
                this.m_mthReset();
                return;
            }

            //计算总金额、自付金额和记帐金额
            decimal decTotalSum = 0;
            decimal decSbSum = 0;
            decimal decAcctSum = 0;

            for (int i = 0; i < ChargeDtSelect.Rows.Count; i++)
            {
                if (ChargeDtSelect.Rows[i]["pstatus_int"].ToString() == "3" || ChargeDtSelect.Rows[i]["pstatus_int"].ToString() == "4")
                {
                    decTotalSum += clsPublic.ConvertObjToDecimal(ChargeDtSelect.Rows[i]["totalmoney_dec"]);
                    decSbSum += clsPublic.ConvertObjToDecimal(ChargeDtSelect.Rows[i]["totalmoney_dec"]) - clsPublic.ConvertObjToDecimal(ChargeDtSelect.Rows[i]["acctmoney_dec"]);
                }
                else
                {
                    decimal d = clsPublic.ConvertObjToDecimal(ChargeDtSelect.Rows[i]["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(ChargeDtSelect.Rows[i]["amount_dec"]);
                    decTotalSum += clsPublic.Round(d, 2);
                    decSbSum += clsPublic.Round(d * clsPublic.ConvertObjToDecimal(ChargeDtSelect.Rows[i]["precent_dec"]) / 100, 2);
                }
            }
            decAcctSum = decTotalSum - decSbSum;

            if (decTotalSum > 0)
            {
                this.m_objViewer.lblTotalSum.Text = decTotalSum.ToString("###,##0.00");
            }
            else
            {
                this.m_objViewer.lblTotalSum.Text = "";
            }

            if (decSbSum > 0)
            {
                this.m_objViewer.lblSbSum.Text = decSbSum.ToString("###,##0.00");
            }
            else
            {
                this.m_objViewer.lblSbSum.Text = "";
            }

            if (decAcctSum > 0)
            {
                this.m_objViewer.lblAcctSum.Text = decAcctSum.ToString("###,##0.00");
            }
            else
            {
                this.m_objViewer.lblAcctSum.Text = "";
            }

            //计算发票分类
            DataTable dtcat = new DataTable();
            long l = this.objSvc.m_lngGetChargeItemCat(4, out dtcat);
            if (l > 0 && dtcat.Rows.Count > 0)
            {
                ArrayList arrcat = new ArrayList();
                DataView dvcat = new DataView(ChargeDtSelect);

                for (int i = 0; i < dtcat.Rows.Count; i++)
                {
                    string invocatid = dtcat.Rows[i]["typeid_chr"].ToString().Trim();
                    decimal invosum = 0;                                                           

                    dvcat.RowFilter = "invcateid_chr = '" + invocatid + "'";
                    foreach (DataRowView drv in dvcat)
                    {
                        invosum += clsPublic.Round(clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]), 2); 
                    }

                    if (invosum == 0)
                    {
                        continue;
                    }

                    clsInvoiceCat_VO invocat_vo = new clsInvoiceCat_VO();
                    invocat_vo.CatID = invocatid;
                    invocat_vo.CatName = dtcat.Rows[i]["typename_vchr"].ToString().Trim();
                    invocat_vo.CatSum = invosum;

                    arrcat.Add(invocat_vo);
                }

                this.m_objViewer.lvInvoiceCat.Items.Clear();
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
        }
        #endregion             

        #region 结帐
        /// <summary>
        /// 结帐
        /// </summary>
        public void m_mthCharge()
        {                      
            if (ChargeDtSelect == null || ChargeDtSelect.Rows.Count == 0)
            {
                MessageBox.Show("请选择结帐项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region 获取帐期信息
            //结算类型 1 帐期 2 明细
            int DayChrgType = 0;
            ArrayList DayaccountsNoArr = new ArrayList();

            if (this.m_objViewer.rdoZq.Checked)
            {
                DayChrgType = 1;

                for (int i = 0; i < this.m_objViewer.dtgMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.dtgMain.Rows[i].Cells[0].Value.ToString().ToUpper() == "T")
                    {
                        DataRow dr = (DataRow)this.m_objViewer.dtgMain.Rows[i].Tag;
                        DayaccountsNoArr.Add(dr["dayaccountid_chr"].ToString());
                    }
                }
            }
            else if (this.m_objViewer.rdoMx.Checked)
            {
                DayChrgType = 2;

                //全选明细等同于按帐期结帐
                bool b = true;
                for (int i = 0; i < this.m_objViewer.dtgDetail.Rows.Count; i++)
                {
                    if (this.m_objViewer.dtgDetail.Rows[i].Cells[0].ReadOnly == true)
                    {
                        continue;
                    }

                    if (this.m_objViewer.dtgDetail.Rows[i].Cells[0].Value.ToString().ToUpper() == "F")
                    {
                        b = false;
                        break;
                    }
                }

                if (b)
                {
                    DayChrgType = 1;
                }

                for (int i = 0; i < this.m_objViewer.dtgMain.Rows.Count; i++)
                {
                    if (this.m_objViewer.dtgMain.Rows[i].Selected)
                    {
                        DataRow dr = (DataRow)this.m_objViewer.dtgMain.Rows[i].Tag;
                        DayaccountsNoArr.Add(dr["dayaccountid_chr"].ToString());
                    }
                }
            }
            else if (this.m_objViewer.rdoMix.Checked)
            {
                DayChrgType = 2;

                string id = "";
                Hashtable hasID = new Hashtable();
                for (int i = 0; i < this.ChargeDtSelect.Rows.Count; i++)
                {
                    id = this.ChargeDtSelect.Rows[i]["dayaccountid_chr"].ToString();
                    if (!hasID.ContainsKey(id))
                    {
                        hasID.Add(id, id);
                    }                   
                }
                if (hasID.Count > 0)
                {
                    DayaccountsNoArr.AddRange(hasID.Values);
                }
            }

            DataView dvDayAll = new DataView(ChargeDt);
            DataView dvDaySub = new DataView(ChargeDtSelect);
            ArrayList DayAccountsArr = new ArrayList();            
            for (int i = 0; i < DayaccountsNoArr.Count; i++)
            {
                string dayid = DayaccountsNoArr[i].ToString();

                clsBihDayAccounts_VO DayAccounts_VO = new clsBihDayAccounts_VO();
                DayAccounts_VO.AccountsID = dayid;
                DayAccounts_VO.ChargeEmp = this.m_objViewer.LoginInfo.m_strEmpID;

                dvDayAll.RowFilter = "dayaccountid_chr = '" + dayid + "'";
                dvDaySub.RowFilter = "dayaccountid_chr = '" + dayid + "' and pstatus_int = 2";
                                
                decimal decTotalSum = 0;
                decimal decSbSum = 0;
                decimal decAcctSum = 0;

                foreach (DataRowView drv in dvDayAll)
                {
                    decimal d = clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]);
                    decTotalSum += clsPublic.Round(d, 2);
                    decSbSum += clsPublic.Round(d * clsPublic.ConvertObjToDecimal(drv["precent_dec"]) / 100, 2);
                }
                decAcctSum = decTotalSum - decSbSum;

                DayAccounts_VO.TotalSum = decTotalSum;
                DayAccounts_VO.SbSum = decSbSum;
                DayAccounts_VO.AcctSum = decAcctSum;

                decTotalSum = 0;
                decSbSum = 0;
                decAcctSum = 0;

                foreach (DataRowView drv in dvDaySub)
                {
                    decimal d = clsPublic.ConvertObjToDecimal(drv["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(drv["amount_dec"]);
                    decTotalSum += clsPublic.Round(d, 2);
                    decSbSum += clsPublic.Round(d * clsPublic.ConvertObjToDecimal(drv["precent_dec"]) / 100, 2);                                     
                }
                decAcctSum = decTotalSum - decSbSum;
                                                
                DayAccounts_VO.ClearSbSum = decSbSum;
                DayAccounts_VO.ClearAcctSum = decAcctSum;

                DayAccountsArr.Add(DayAccounts_VO);
            }
                    
            #endregion                      

            frmReckoning frec = new frmReckoning();            
            frec.ChargeType = 1;
            frec.ChargeDetail = ChargeDtSelect;
            frec.objPatient = this.m_objViewer.ucPatientInfo;
            frec.DayChrgType = DayChrgType;            
            frec.DayAccountsArr = DayAccountsArr;
            if (frec.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
            }
        }
        #endregion

        #region 重打发票
        /// <summary>
        /// 重打发票
        /// </summary>        
        public void m_mthRepeatPrt()
        {
            string RegID = this.m_objViewer.ucPatientInfo.RegisterID;

            if (RegID == "")
            {
                return;
            }

            frmInvoiceRepeatPrt finvoprt = new frmInvoiceRepeatPrt(RegID);
            finvoprt.ShowDialog();
        }
        #endregion

        #region 退款
        /// <summary>
        /// 退款
        /// </summary>
        public void m_mthRefundment()
        {
            string RegID = this.m_objViewer.ucPatientInfo.RegisterID;

            if (RegID == "")
            {
                return;
            }

            frmInvoiceRefundment finvoref = new frmInvoiceRefundment(RegID, 1);
            finvoref.ShowDialog();
            if (finvoref.IsRefundment)
            {
                this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
            }
        }
        #endregion

        #region 组合选择结算
        /// <summary>
        /// 组合选择结算
        /// </summary>
        public void m_mthChargeMix()
        {            
            if (this.ChargeDt == null || this.ChargeDt.Rows.Count == 0)
            {
                this.m_objViewer.rdoZq.Checked = true;
                return;
            }

            frmMidCharge_Mix f = new frmMidCharge_Mix();
            f.dtDayaccount = this.DayAccountDt;
            f.dtSource = this.ChargeDt;
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.ChargeDtSelect = f.dtSelected;
                this.m_mthCharge();
            }

            this.m_objViewer.rdoZq.Checked = true;
        }
        #endregion
    }
}
