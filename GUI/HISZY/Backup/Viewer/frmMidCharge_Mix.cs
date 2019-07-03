using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmMidCharge_Mix : Form
    {
        public frmMidCharge_Mix()
        {
            InitializeComponent();
        }

        #region 变量
        internal DataTable dtDayaccount = new DataTable();
        internal DataTable dtSource = new DataTable();
        internal DataTable dtSelected = new DataTable();

        /// <summary>
        /// 选择类型 1 按期帐 2 按明细
        /// </summary>
        private int intType = 1;
        #endregion

        #region 方法
        #region 获取期帐信息
        /// <summary>
        /// 获取期帐信息
        /// </summary>
        public void m_mthGetDayaccountsInfo()
        {
            for (int i = 0; i < this.dtDayaccount.Rows.Count; i++)
            {
                decimal d = 0;
                string[] s = new string[6];

                s[0] = "F";
                s[1] = this.dtDayaccount.Rows[i]["orderno_int"].ToString();
                s[2] = Convert.ToDateTime(this.dtDayaccount.Rows[i]["square_dat"].ToString()).ToString("yyyyMMddHHmm");
                s[3] = clsPublic.ConvertObjToDecimal(this.dtDayaccount.Rows[i]["charge_dec"]).ToString("0.00");

                d = clsPublic.ConvertObjToDecimal(this.dtDayaccount.Rows[i]["clearchg_dec"]);
                if (d != 0)
                {
                    s[4] = d.ToString("0.00");
                }
                else
                {
                    s[4] = "";
                }

                d = clsPublic.Round(clsPublic.ConvertObjToDecimal(this.dtDayaccount.Rows[i]["charge_dec"]), 2) - clsPublic.Round(clsPublic.ConvertObjToDecimal(this.dtDayaccount.Rows[i]["clearchg_dec"]), 2);
                if (d != 0)
                {
                    s[5] = d.ToString("0.00");
                }
                else
                {
                    s[5] = "";
                }

                int row = this.dtgMain.Rows.Add(s);
                this.dtgMain.Rows[row].Tag = this.dtDayaccount.Rows[i];
                
                this.dtgMain.Rows[row].DefaultCellStyle.BackColor = Color.White;
                this.dtgMain.Rows[row].Cells[0].ReadOnly = this.intType == 1 ? false : true;

                if (s[3] == s[4])
                {
                    this.dtgMain.Rows[row].Cells[0].ReadOnly = true;
                    this.dtgMain.Rows[row].DefaultCellStyle.ForeColor = Color.RoyalBlue;
                }
                else if (s[3] != s[4] && s[4] != "0" && s[4].Trim() != "")
                {
                    this.dtgMain.Rows[row].DefaultCellStyle.ForeColor = Color.SaddleBrown;
                }

                if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                {
                    this.dtgMain.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }
            }

            this.m_mthGetAccountsDetail(0);
        }
        #endregion

        #region 获取当前病人期帐明细
        /// <summary>
        /// 获取当前病人期帐明细
        /// </summary>
        /// <param name="CurrRow"></param>
        public void m_mthGetAccountsDetail(int CurrRow)
        {
            this.dtgDetail.Rows.Clear();
            DataView dv = new DataView(this.dtSource);
            DataRow dr = (DataRow)this.dtgMain.Rows[CurrRow].Tag;

            string dayaccountid = dr["dayaccountid_chr"].ToString();
            dv.RowFilter = "dayaccountid_chr = '" + dayaccountid + "'";
            dv.Sort = "chargeitemid_chr asc";

            int i = 1;
            string strChecked = this.dtgMain.Rows[CurrRow].Cells[0].Value.ToString();
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
                Color BCR = this.dtgMain.Rows[CurrRow].DefaultCellStyle.BackColor;
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

                int row = this.dtgDetail.Rows.Add(s);
                this.dtgDetail.Rows[row].Tag = drv.Row;
                this.dtgDetail.Rows[row].DefaultCellStyle.ForeColor = FCR;
                
                if (this.intType == 1 || blnReadOnly)
                {
                    this.dtgDetail.Rows[row].Cells[0].ReadOnly = true;
                }

                this.dtgDetail.Rows[row].Cells[0].Value = strChecked;

                if (blnClearAccountsReadonly)
                {
                    this.dtgDetail.Rows[row].Cells[0].ReadOnly = true;
                }

                if (Math.IEEERemainder(Convert.ToDouble(row + 1), 2) == 0)
                {
                    this.dtgDetail.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }
            }
        }
        #endregion
        #endregion

        private void frmMidCharge_Mix_Load(object sender, EventArgs e)
        {
            this.m_mthGetDayaccountsInfo();
        }

        private void rdoZq_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoZq.Checked)
            {
                this.intType = 1;
              
                for (int i = 0; i < this.dtgMain.Rows.Count; i++)
                {
                    DataRow dr = (DataRow)this.dtgMain.Rows[i].Tag;
                    if (dr["charge_dec"].ToString() == dr["clearchg_dec"].ToString())
                    {
                        this.dtgMain.Rows[i].Cells[0].ReadOnly = true;
                    }
                    else
                    {
                        this.dtgMain.Rows[i].Cells[0].ReadOnly = false;
                    }
                    this.dtgMain.Rows[i].Cells[0].Value = "F";
                }
                for (int i = 0; i < this.dtgDetail.Rows.Count; i++)
                {
                    this.dtgDetail.Rows[i].Cells[0].ReadOnly = true;
                    this.dtgDetail.Rows[i].Cells[0].Value = "F";
                }
            }
        }

        private void rdoMx_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoMx.Checked)
            {
                this.intType = 2;

                for (int i = 0; i < this.dtgMain.Rows.Count; i++)
                {
                    this.dtgMain.Rows[i].Cells[0].ReadOnly = true;
                    this.dtgMain.Rows[i].Cells[0].Value = "F";
                }
                for (int i = 0; i < this.dtgDetail.Rows.Count; i++)
                {

                    DataRow dr = (DataRow)this.dtgDetail.Rows[i].Tag;
                    if (dr["pstatus_int"].ToString() == "3")
                    {
                        this.dtgDetail.Rows[i].Cells[0].ReadOnly = true;
                    }
                    else
                    {
                        this.dtgDetail.Rows[i].Cells[0].ReadOnly = false;
                    }
                    this.dtgDetail.Rows[i].Cells[0].Value = "F";
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal totalsum = 0;

            if (this.rdoZq.Checked)
            {
                for (int i = this.dtgMain.Rows.Count - 1; i >= 0; i--)
                {
                    if (this.dtgMain.Rows[i].Cells[0].Value.ToString().ToUpper() == "T")
                    {
                        DataRow dr = (DataRow)this.dtgMain.Rows[i].Tag;

                        bool b = false;
                        for (int k = 0; k < this.dtgSum.Rows.Count; k++)
                        {
                            if (this.dtgSum.Rows[k].Cells["colbz"].Value.ToString() == "2")
                            {
                                if (dr["dayaccountid_chr"].ToString() == this.dtgSum.Rows[k].Cells["coldayaccountid"].Value.ToString())
                                {
                                    b = true;
                                    MessageBox.Show("该期帐的收费项目已添加。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                        }
                        if (b)
                        {
                            continue;
                        }

                        string[] s = new string[9];

                        s[0] = "F";
                        s[1] = Convert.ToString(this.dtgSum.Rows.Count + 1);
                        s[2] = "第" + dr["orderno_int"].ToString().Trim() + "期 - " + Convert.ToDateTime(dr["square_dat"].ToString()).ToString("yyyyMMddHHmm") ;
                        s[3] = "";
                        s[4] = "";
                        decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["charge_dec"]), 2) - clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["clearchg_dec"]), 2);
                        s[5] = d.ToString("0.00");
                        s[6] = "1"; //期帐
                        s[7] = "";
                        s[8] = dr["dayaccountid_chr"].ToString();

                        int row = this.dtgSum.Rows.Add(s);
                        this.dtgSum.Rows[row].Tag = dr;

                        if (Math.IEEERemainder(Convert.ToDouble(row + 1), 2) == 0)
                        {
                            this.dtgSum.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                        }

                        this.dtgMain.Rows.RemoveAt(i);
                        totalsum += d;
                    }
                }

                if (totalsum > 0)
                {
                    this.dtgDetail.Rows.Clear();
                }
            }

            if (this.rdoMx.Checked)
            {
                for (int i = this.dtgDetail.Rows.Count - 1; i >= 0; i--)
                {
                    if (this.dtgDetail.Rows[i].Cells[0].Value.ToString().ToUpper() == "T")
                    {
                        DataRow dr = (DataRow)this.dtgDetail.Rows[i].Tag;

                        bool b = false;
                        for (int k = 0; k < this.dtgSum.Rows.Count; k++)
                        {
                            if (this.dtgSum.Rows[k].Cells["colbz"].Value.ToString() == "1")
                            {
                                if (dr["dayaccountid_chr"].ToString() == this.dtgSum.Rows[k].Cells["coldayaccountid"].Value.ToString())
                                {
                                    b = true;
                                    MessageBox.Show("该收费项目的期帐已添加。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                            else
                            {
                                if (dr["pchargeid_chr"].ToString() == this.dtgSum.Rows[k].Cells["colpchargeid"].Value.ToString())
                                {
                                    b = true;
                                    MessageBox.Show("该收费项目已添加。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                            }
                        }
                        if (b)
                        {
                            continue;
                        }
                        
                        string[] s = new string[9];

                        s[0] = "F";
                        s[1] = Convert.ToString(this.dtgSum.Rows.Count + 1);
                        s[2] = dr["chargeitemname_chr"].ToString().Trim();
                        s[3] = dr["unitprice_dec"].ToString();
                        s[4] = dr["amount_dec"].ToString();
                        decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(dr["amount_dec"]), 2);
                        s[5] = d.ToString("0.00");
                        s[6] = "2"; //明细
                        s[7] = dr["pchargeid_chr"].ToString();
                        s[8] = dr["dayaccountid_chr"].ToString();

                        int row = this.dtgSum.Rows.Add(s);
                        this.dtgSum.Rows[row].Tag = dr;

                        if (Math.IEEERemainder(Convert.ToDouble(row + 1), 2) == 0)
                        {
                            this.dtgSum.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                        }

                        this.dtgDetail.Rows.RemoveAt(i);
                        totalsum += d;
                    }
                }
            }

            this.lblTotalSum.Text = Convert.ToDecimal(totalsum + clsPublic.ConvertObjToDecimal(this.lblTotalSum.Text)).ToString("0.00");
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (this.dtgSum.Rows.Count == 0)
            {
                return;
            }

            DataRow dr = null;
            for (int i = this.dtgSum.Rows.Count - 1; i >= 0; i--)
            {
                if (this.dtgSum.Rows[i].Cells[0].Value.ToString().ToUpper() == "T")
                {
                    dr = this.dtgSum.Rows[i].Tag as DataRow;

                    if (this.dtgSum.Rows[i].Cells["colbz"].Value.ToString() == "1")
                    {
                        decimal d = 0;
                        string[] s = new string[6];

                        s[0] = "F";
                        s[1] = dr["orderno_int"].ToString();
                        s[2] = Convert.ToDateTime(dr["square_dat"].ToString()).ToString("yyyyMMddHHmm");
                        s[3] = clsPublic.ConvertObjToDecimal(dr["charge_dec"]).ToString("0.00");

                        d = clsPublic.ConvertObjToDecimal(dr["clearchg_dec"]);
                        if (d != 0)
                        {
                            s[4] = d.ToString("0.00");
                        }
                        else
                        {
                            s[4] = "";
                        }

                        d = clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["charge_dec"]), 2) - clsPublic.Round(clsPublic.ConvertObjToDecimal(dr["clearchg_dec"]), 2);
                        if (d != 0)
                        {
                            s[5] = d.ToString("0.00");
                        }
                        else
                        {
                            s[5] = "";
                        }

                        int row = this.dtgMain.Rows.Add(s);
                        this.dtgMain.Rows[row].Tag = dr;

                        if (s[3] != s[4] && s[4] != "0" && s[4].Trim() != "")
                        {
                            this.dtgMain.Rows[row].DefaultCellStyle.ForeColor = Color.SaddleBrown;
                        }

                        if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                        {
                            this.dtgMain.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                        }
                    }
                    else if (this.dtgSum.Rows[i].Cells["colbz"].Value.ToString() == "2")
                    {
                        string[] s = new string[12];

                        s[0] = "F";
                        s[1] = Convert.ToString(this.dtgDetail.Rows.Count + 1);
                        s[2] = dr["orderno_int"].ToString();
                        s[3] = Convert.ToDateTime(dr["chargeactive_dat"].ToString()).ToString("yyyy-MM-dd");
                        s[4] = dr["ipinvoname"].ToString().Trim();
                        s[5] = dr["chargeitemname_chr"].ToString().Trim();
                        s[6] = dr["amount_dec"].ToString();
                        s[7] = dr["unitprice_dec"].ToString();

                        //费用
                        if (dr["pstatus_int"].ToString() == "3" || dr["pstatus_int"].ToString() == "4")
                        {
                            s[8] = Convert.ToDecimal(dr["totalmoney_dec"]).ToString("0.00");
                            s[9] = dr["precent_dec"].ToString();
                            s[10] = Convert.ToDecimal(dr["acctmoney_dec"]).ToString("0.00");
                        }
                        else
                        {
                            decimal d = clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(dr["amount_dec"]);
                            s[8] = d.ToString("0.00");
                            s[9] = dr["precent_dec"].ToString();

                            d = d * clsPublic.ConvertObjToDecimal(dr["precent_dec"]) / 100;
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
                        Color BCR = this.dtgMain.Rows[CurrRow].DefaultCellStyle.BackColor;
                        
                        //状态
                        string StatusID = dr["pstatus_int"].ToString();
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
                        s[11] = StatusName;
                       
                        int row = this.dtgDetail.Rows.Add(s);
                        this.dtgDetail.Rows[row].Tag = dr;
                        this.dtgDetail.Rows[row].DefaultCellStyle.ForeColor = FCR;
                        
                        if (Math.IEEERemainder(Convert.ToDouble(row + 1), 2) == 0)
                        {
                            this.dtgDetail.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                        }
                    }

                    this.dtgSum.Rows.RemoveAt(i);
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.dtgSum.Rows.Count == 0)
            {
                return;
            }

            DataView dv = new DataView(this.dtSource);
            this.dtSelected = this.dtSource.Clone();

            DataRow dr = null;
            for (int i = this.dtgSum.Rows.Count - 1; i >= 0; i--)
            {
                dr = this.dtgSum.Rows[i].Tag as DataRow;

                if (this.dtgSum.Rows[i].Cells["colbz"].Value.ToString() == "1")
                {
                    string dayaccountid = dr["dayaccountid_chr"].ToString();
                    dv.RowFilter = "dayaccountid_chr = '" + dayaccountid + "' and pstatus_int = 2";

                    foreach (DataRowView drv in dv)
                    {
                        this.dtSelected.Rows.Add(drv.Row.ItemArray);
                    }
                    this.dtSelected.AcceptChanges();
                }
                else if (this.dtgSum.Rows[i].Cells["colbz"].Value.ToString() == "2")
                {
                    string pchargeid = dr["pchargeid_chr"].ToString();
                    dv.RowFilter = "pchargeid_chr = '" + pchargeid + "' and pstatus_int = 2";

                    foreach (DataRowView drv2 in dv)
                    {
                        this.dtSelected.Rows.Add(drv2.Row.ItemArray);
                    }
                    this.dtSelected.AcceptChanges();
                }

            }

            if (this.dtSelected.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 当前行
        /// </summary>
        private int CurrRow = -1;
        private int HitTimes = 0;
        private bool BlnChecked = false;
        private void dtgMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                if (e.RowIndex != CurrRow)
                {
                    HitTimes = 1;
                    CurrRow = e.RowIndex;
                    this.m_mthGetAccountsDetail(CurrRow);
                }
                else
                {
                    HitTimes++;
                }

                if (e.ColumnIndex == 0)
                {
                    if (this.dtgMain.Rows[CurrRow].Cells[0].ReadOnly)
                    {
                        return;
                    }

                    if (HitTimes == 1)
                    {
                        BlnChecked = this.dtgMain.Rows[CurrRow].Cells[0].Value.ToString().ToUpper() == "T" ? false : true;
                    }
                    else if (HitTimes > 1)
                    {
                        BlnChecked = !BlnChecked;
                    }

                    for (int i = 0; i < this.dtgDetail.Rows.Count; i++)
                    {
                        this.dtgDetail.Rows[i].Cells[0].Value = BlnChecked == true ? "T" : "F";
                    }

                    if (e.RowIndex == (this.dtgMain.Rows.Count - 1))
                    {
                        SendKeys.Send("{UP}");
                    }
                    else
                    {
                        SendKeys.Send("{ENTER}");
                    }
                }
            }
        }

        private void dtgMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (CurrRow >= 0)
            {
                if (this.dtgMain.Rows[CurrRow].Cells[0].ReadOnly)
                {
                    return;
                }

                string ischecked = this.dtgMain.Rows[CurrRow].Cells[0].Value.ToString() == "T" ? "F" : "T";
                this.dtgMain.Rows[CurrRow].Cells[0].Value = ischecked;
                for (int i = 0; i < this.dtgDetail.Rows.Count; i++)
                {
                    this.dtgDetail.Rows[i].Cells[0].Value = ischecked;
                }

            }
        }

        private void dtgDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            else
            {
                if (e.ColumnIndex == 0)
                {
                    if (this.dtgDetail.Rows[e.ColumnIndex].Cells[0].ReadOnly)
                    {
                        return;
                    }
                    SendKeys.Send("{ENTER}");
                }
            }
        }

        private void dtgDetail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;

            if (row >= 0)
            {
                if (this.dtgDetail.Rows[row].Cells[0].ReadOnly)
                {
                    return;
                }

                string ischecked = this.dtgDetail.Rows[row].Cells[0].Value.ToString() == "T" ? "F" : "T";
                this.dtgDetail.Rows[row].Cells[0].Value = ischecked;
            }
        }

        private void dtgSum_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string ischecked = this.dtgSum.Rows[e.RowIndex].Cells[0].Value.ToString() == "T" ? "F" : "T";
            this.dtgSum.Rows[e.RowIndex].Cells[0].Value = ischecked;
        }

        
    }
}