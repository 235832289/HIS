using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 医保结算UI类
    /// </summary>
    public partial class frmYB : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 数据库参数
        /// </summary>
        private string DSN = "";
        /// <summary>
        /// 医院编号
        /// </summary>
        private string HospCode = "";
        /// <summary>
        /// 病人姓名
        /// </summary>
        private string PatName = "";
        /// <summary>
        /// 住院号
        /// </summary>
        private string Zyh = "";
        /// <summary>
        /// 住院次数
        /// </summary>
        private int Zycs = 0;
        /// <summary>
        /// 总费用
        /// </summary>
        private decimal TotalMny = 0;
        /// <summary>
        /// 自付金额
        /// </summary>
        private decimal sbmny = 0;
        /// <summary>
        /// 自付金额
        /// </summary>
        public decimal SbMny
        {
            get
            {
                return sbmny;
            }
        }
        /// <summary>
        /// 医保返回数据集
        /// </summary>
        private DataTable dtyb = new DataTable();
        /// <summary>
        /// 医保返回数据集
        /// </summary>
        public DataTable dtYB
        {
            get
            {
                return dtyb;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmYB(string dsn, string hospcode, string patname, string zyh, int zycs, string total)
        {
            InitializeComponent();
            DSN = dsn;
            HospCode = hospcode;
            PatName = patname;
            Zyh = zyh;
            Zycs = zycs;
            TotalMny = clsPublic.ConvertObjToDecimal(total);
        }

        private void frmYB_Load(object sender, EventArgs e)
        {
            this.lblName.Text = PatName;
            this.lblZyh.Text = Zyh;
            this.lblZycs.Text = Zycs.ToString();
            this.lblTotal.Text = TotalMny.ToString();
            this.btnOk.Enabled = false;
            this.lblgwyyb.Visible = false;
        }

        /// <summary>
        /// 接收
        /// </summary>
        public void m_mthReceive()
        {
            this.Cursor = Cursors.WaitCursor;

            clsDcl_Charge objCharge = new clsDcl_Charge();

            //1 普通医保 2 公务员医保
            int YbType = 0;
            long l = objCharge.m_lngGetybjsmx(DSN, HospCode, Zyh, Zycs.ToString(), out dtyb, out YbType);

            if (l > 0)
            {
                if (YbType == 1 && dtyb.Rows.Count > 0)
                {
                    DataRow dr = dtyb.Rows[dtyb.Rows.Count - 1];

                    this.lblCbcwf.Text = dr["cbcwf"].ToString();
                    this.lblZfypf.Text = dr["zfyp"].ToString();
                    this.lblYlypf.Text = dr["ylyp"].ToString();
                    this.lblZcypf.Text = dr["zcyp"].ToString();
                    this.lblZcyf.Text = dr["zcyf"].ToString();
                    this.lblGxyqf.Text = dr["gxylf"].ToString();
                    this.lblQtf.Text = dr["qtfy"].ToString();
                    this.lblQfbzf.Text = dr["qfbzf"].ToString();
                    this.lblGz2f.Text = dr["grfd2"].ToString();
                    this.lblGz3f.Text = dr["grfd3"].ToString();
                    this.lblGz3f2.Text = dr["grfd3s"].ToString();
                    this.lblCzgxefy.Text = dr["grfdcg"].ToString();
                    this.lblLxbnrqjf.Text = dr["ylxma"].ToString();
                    this.lblLxbnrfqjf.Text = dr["ylxmb"].ToString();
                    this.lblLxjkclf.Text = dr["ylxmc"].ToString();

                    //自付合计
                    sbmny = clsPublic.ConvertObjToDecimal(dr["cbcwf"]) + clsPublic.ConvertObjToDecimal(dr["zfyp"]) + clsPublic.ConvertObjToDecimal(dr["ylyp"]) +
                            clsPublic.ConvertObjToDecimal(dr["zcyp"]) + clsPublic.ConvertObjToDecimal(dr["zcyf"]) + clsPublic.ConvertObjToDecimal(dr["gxylf"]) +
                            clsPublic.ConvertObjToDecimal(dr["qtfy"]) + clsPublic.ConvertObjToDecimal(dr["qfbzf"]) + clsPublic.ConvertObjToDecimal(dr["grfd2"]) +
                            clsPublic.ConvertObjToDecimal(dr["grfd3"]) + clsPublic.ConvertObjToDecimal(dr["grfd3s"]) + clsPublic.ConvertObjToDecimal(dr["grfdcg"]) +
                            clsPublic.ConvertObjToDecimal(dr["ylxma"]) + clsPublic.ConvertObjToDecimal(dr["ylxmb"]) + clsPublic.ConvertObjToDecimal(dr["ylxmc"]) +
                            clsPublic.ConvertObjToDecimal(dr["ylxmd"]) + clsPublic.ConvertObjToDecimal(dr["ylxme"]);

                    this.lblSB.Text = sbmny.ToString();
                    this.lblAcct.Text = Convert.ToString(TotalMny - sbmny);

                    this.btnOk.Enabled = true;
                    this.lblInfo.Text = "接收数据成功！";
                }
                else if (YbType == 2 && dtyb.Rows.Count > 0)
                {
                    DataRow dr = dtyb.Rows[dtyb.Rows.Count - 1];
                    this.lblgwyyb.Visible = true;

                    //sbmny = TotalMny - clsPublic.ConvertObjToDecimal(dtyb.Rows[dtyb.Rows.Count - 1]["ser_pay"]);
                    sbmny = clsPublic.ConvertObjToDecimal(dtyb.Rows[dtyb.Rows.Count - 1]["outofser"]);

                    this.lblSB.Text = sbmny.ToString();
                    this.lblAcct.Text = Convert.ToString(TotalMny - sbmny);

                    this.btnOk.Enabled = true;
                    this.lblInfo.Text = "接收数据成功！";
                }
                else
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("接收医保结算数据失败，请重新接收。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }                       

            this.Cursor = Cursors.Default;
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            this.m_mthReceive();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}