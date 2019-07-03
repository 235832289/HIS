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
    /// <summary>
    /// 项目汇总UI类

    /// </summary>
    public partial class frmQueryCharge_ItemSum : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private DataGridView DGV = new DataGridView();
        private string Zyh = "";
        private string PatName = "";
        private string DateScope = "";
        private string DeptName = "";
        /// <summary>
        /// 构造函数

        /// </summary>
        /// <param name="dgv"></param>
        public frmQueryCharge_ItemSum(DataGridView dgv, string zyh, string name, string datescope, string deptname)
        {
            InitializeComponent();
            DGV = dgv;
            Zyh = zyh;
            PatName = name;
            DateScope = datescope;
            DeptName = deptname;
        }

        /// <summary>
        /// 让利启用开关
        /// </summary>
        internal int intDiffCostOn = 0;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQueryCharge_ItemSum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void frmQueryCharge_ItemSum_Load(object sender, EventArgs e)
        {
            int no = 1;
            ArrayList RowArr = new ArrayList();
            this.intDiffCostOn = clsPublic.m_intGetSysParm("9002");
            if (intDiffCostOn == 1)
            {
                this.dtItem.Columns["colDiffCostMny"].Width = 80;
                this.dtItem.Columns["colRequiredPay"].Width = 80;
            }
            else
            {
                this.dtItem.Columns["colDiffCostMny"].Width = 0;
                this.dtItem.Columns["colRequiredPay"].Width = 0;
            }
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                if (RowArr.IndexOf(i) >= 0)
                {
                    continue;
                }

                string itemid = this.DGV.Rows[i].Cells["colxmdm"].Value.ToString().Trim();
                string price = this.DGV.Rows[i].Cells["coldj"].Value.ToString().Trim();
                decimal amount = clsPublic.ConvertObjToDecimal(this.DGV.Rows[i].Cells["colsl"].Value);
                decimal dec_amountTemp = 0;//临时变量
                decimal totalmoney = clsPublic.ConvertObjToDecimal(this.DGV.Rows[i].Cells["colje"].Value);
                decimal factmoney = clsPublic.ConvertObjToDecimal(this.DGV.Rows[i].Cells["facttotal"].Value);
                decimal decTotalDiff = clsPublic.ConvertObjToDecimal(this.DGV.Rows[i].Cells["colTotalDiffCost"].Value);//让利总金额
                decimal decRequiredPay = clsPublic.ConvertObjToDecimal(this.DGV.Rows[i].Cells["colRequiredPay"].Value);//实付总金额
                for (int j = i + 1; j < DGV.Rows.Count; j++)
                {
                    if (this.DGV.Rows[j].Cells["colxmdm"].Value.ToString().Trim() == itemid &&
                        this.DGV.Rows[j].Cells["coldj"].Value.ToString().Trim() == price)
                    {
                        dec_amountTemp = clsPublic.ConvertObjToDecimal(this.DGV.Rows[j].Cells["colsl"].Value);
                        amount += dec_amountTemp;
                        totalmoney += clsPublic.ConvertObjToDecimal(this.DGV.Rows[j].Cells["colje"].Value);
                        factmoney += clsPublic.ConvertObjToDecimal(this.DGV.Rows[j].Cells["facttotal"].Value);
                        if (this.intDiffCostOn == 1)
                        {
                            decTotalDiff += clsPublic.ConvertObjToDecimal(this.DGV.Rows[j].Cells["colTotalDiffCost"].Value);
                            decRequiredPay += clsPublic.ConvertObjToDecimal(this.DGV.Rows[j].Cells["colRequiredPay"].Value);
                        }
                        RowArr.Add(j);
                    }
                }

                if (amount == 0 && decRequiredPay == 0)
                {
                    continue;
                }

                string[] sarr = new string[13];
                sarr[0] = no.ToString();
                sarr[1] = itemid;
                sarr[2] = this.DGV.Rows[i].Cells["colxmmc"].Value.ToString().Trim();
                sarr[3] = amount.ToString();
                sarr[4] = totalmoney.ToString("0.00");
                sarr[5] = price;
                sarr[6] = this.DGV.Rows[i].Cells["scale"].Value.ToString().Trim();
                sarr[7] = factmoney.ToString("0.00");
                sarr[8] = this.DGV.Rows[i].Cells["colgg"].Value.ToString().Trim();
                sarr[9] = this.DGV.Rows[i].Cells["coldw"].Value.ToString().Trim();
                sarr[10] = this.DGV.Rows[i].Cells["colfpfl"].Value.ToString().Trim();

                if (this.intDiffCostOn == 1)
                {
                    sarr[11] = decTotalDiff.ToString("0.00");
                    sarr[12] = decRequiredPay.ToString("0.00");
                }
                int row = this.dtItem.Rows.Add(sarr);

                if (Math.IEEERemainder(Convert.ToDouble(no), 2) == 0)
                {
                    this.dtItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }

                no++;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsCtl_Report objReport = new clsCtl_Report();
            objReport.m_mthRptChargeSum(this.dtItem, DeptName, Zyh, PatName, DateScope, this.LoginInfo.m_strEmpNo, 1);
            objReport = null;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            clsCtl_Report objReport = new clsCtl_Report();
            objReport.m_mthRptChargeSum(this.dtItem, DeptName, Zyh, PatName, DateScope, this.LoginInfo.m_strEmpNo, 2);
            objReport = null;
        }
    }
}