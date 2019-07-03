using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmFeelCharge : Form
    {
        public frmFeelCharge()
        {
            InitializeComponent();
        }

        public frmFeelCharge(clsChargeForDisplay[] obj)
        {
            InitializeComponent();
            this.objFeelCharge = obj;
        }

        /// <summary>
        /// 费用列表明细
        /// </summary>
        internal clsChargeForDisplay[] objFeelCharge;

        internal List<clsChargeForDisplay> listFeelCharge;

        private void frmFeelCharge_Load(object sender, EventArgs e)
        {
            this.m_dtvChangeList.Rows.Clear();


            int k = 0;
            for (int i = 0; i < objFeelCharge.Length; i++)
            {

                k++;
                this.m_dtvChangeList.Rows.Add();
                DataGridViewRow row1 = this.m_dtvChangeList.Rows[this.m_dtvChangeList.RowCount - 1];
                row1.Cells["chkbox"].Value = "F";
                row1.Cells["seq"].Value = Convert.ToString(k);
                row1.Cells["chargeName"].Value = objFeelCharge[i].m_strName;
                row1.Cells["ITEMSPEC_VCHR"].Value = objFeelCharge[i].m_strSPEC_VCHR;
                row1.Cells["ChargeClass"].Value = "";
                switch (objFeelCharge[i].m_intType)
                {
                    case 0:
                        row1.Cells["ChargeClass"].Value = "主项目";
                        break;
                    case 1:
                        row1.Cells["ChargeClass"].Value = "辅助项目";
                        break;
                    case 2:
                        row1.Cells["ChargeClass"].Value = "用法带出";
                        break;
                    case 3:
                        row1.Cells["ChargeClass"].Value = "补充录入";
                        break;
                }

                row1.Cells["ChargePrice"].Value = objFeelCharge[i].m_dblPrice.ToString();
                row1.Cells["get_count"].Value = objFeelCharge[i].m_dblDrawAmount.ToString() + " " + objFeelCharge[i].m_strUNIT_VCHR;
                row1.Cells["countSum"].Value = objFeelCharge[i].m_dblMoney.ToString();
                switch (objFeelCharge[i].m_intCONTINUEUSETYPE_INT)
                {
                    case 1:
                        row1.Cells["xuClass"].Value = "首次用";
                        break;
                    case 0:
                        row1.Cells["xuClass"].Value = "连续用";
                        break;
                    default:
                        row1.Cells["xuClass"].Value = " -- ";
                        break;
                }

                row1.Cells["excuteDept"].Value = objFeelCharge[i].m_strClacareaName_chr;
                row1.Cells["YBClass"].Value = objFeelCharge[i].m_strYBClass;
                row1.Cells["IPNOQTYFLAG_INT"].Value = "";
                if (objFeelCharge[i].m_intITEMSRCTYPE_INT == 1)
                {
                    if (objFeelCharge[i].m_intIPNOQTYFLAG_INT == 1)
                    {
                        row1.Cells["IPNOQTYFLAG_INT"].Value = "缺药";
                        row1.DefaultCellStyle.ForeColor = System.Drawing.Color.Red;
                    }
                }

                row1.Tag = objFeelCharge[i];
            }
        }

        private void cmdCharge_Click(object sender, EventArgs e)
        {
            this.listFeelCharge = new List<clsChargeForDisplay>();
            for (int i1 = 0; i1 < this.m_dtvChangeList.Rows.Count; i1++)
            {
                if (this.m_dtvChangeList.Rows[i1].Cells["chkbox"].Value.ToString().ToUpper() == "T")
                {
                    listFeelCharge.Add((clsChargeForDisplay)this.m_dtvChangeList.Rows[i1].Tag);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}