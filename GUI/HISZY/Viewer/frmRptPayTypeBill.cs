using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 按身份打清单
    /// </summary>
    public partial class frmRptPayTypeBill : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造

        /// </summary>
        public frmRptPayTypeBill()
        {
            InitializeComponent();

            objReport = new clsCtl_Report();
        }

        #region 变量
        /// <summary>
        /// 报表业务类

        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// PB事务
        /// </summary>
        private Transaction pbTrans;
        /// <summary>
        /// 报表标题
        /// </summary>
        private string RptTitle = "费用明细清单";       
        /// <summary>
        /// 哈希
        /// </summary>
        private Hashtable HasPay = new Hashtable();
        #endregion              

        #region 获取身份列表
        /// <summary>
        /// 获取身份列表
        /// </summary>
        public void m_mthGetPayTypeList()
        {
            DataTable dt;
            clsDcl_Charge objCharge = new clsDcl_Charge();            
            long l = objCharge.m_lngGetPayTypeInfo(out dt);
            if (l > 0)
            {               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    if (!HasPay.ContainsKey(dr["paytypename_vchr"].ToString().Trim()))
                    {
                        HasPay.Add(dr["paytypename_vchr"].ToString().Trim(), dr["paytypeid_chr"].ToString().Trim());
                        this.cboPayTypeID.Items.Add(dr["paytypename_vchr"].ToString().Trim());
                    }
                }

                if (HasPay.Count > 0)
                {
                    this.cboPayTypeID.SelectedIndex = 0;
                }
            }
        }
        #endregion

        private void frmRptPayTypeBill_Load(object sender, EventArgs e)
        {           
            this.dwRep.LibraryList = clsPublic.PBLPath;            
            this.dwRep.DataWindowObject = "d_bih_chargesum_cs";
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + "住院病人费用清单'");

            this.m_mthGetPayTypeList();
            this.cboType.SelectedIndex = 0;
            this.txtZyh.Tag = "";
            this.txtZyh.Focus();  
        }

        private void frmRptPayTypeBill_Activated(object sender, EventArgs e)
        {
            this.txtZyh.Focus();
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {           
            string RegID = this.txtZyh.Tag.ToString().Trim();
            if (RegID == "")
            {
                MessageBox.Show("请输入正确的住院号.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string PayTypeID = HasPay[this.cboPayTypeID.Text.Trim()].ToString();
           
            clsPublic.PlayAvi("findFILE.avi", "正在统计费用数据，请稍候...");          
            this.dwRep.Modify("t_ksmc.text = ''");
            this.dwRep.Modify("t_zyh.text = ''");
            this.dwRep.Modify("t_xm.text = ''");
            this.dwRep.Modify("t_tjrq.text = ''");
            this.dwRep.Modify("t_dyr.text = ''");

            this.dwRep.PrintProperties.Preview = false;
            this.dwRep.Reset();
            this.objReport.m_mthRptSbBill_CS(RegID, PayTypeID, this.txtZyh.Text.Trim(), this.lblName.Text, this.LoginInfo.m_strEmpNo, this.cboType.SelectedIndex, this.dwRep);            
            clsPublic.CloseAvi();          
        }              

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }       

        private void btnFind_Click(object sender, EventArgs e)
        {
            frmCommonFind f = new frmCommonFind("查找病人资料", 0);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.txtZyh.Text = f.Zyh;
                this.lblZycs.Text = f.Zycs.ToString();
                this.lblName.Text = f.PatName;
            }
        }

        private void txtZyh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string zyh = this.txtZyh.Text.Trim();

                if (zyh == "")
                {
                    MessageBox.Show("请输入住院号.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                clsDcl_CommonFind objFind = new clsDcl_CommonFind();
                DataTable dt;
                long l = objFind.m_lngGetPatientinfoByZyh(zyh, out dt);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    DataRow Dr;
                    if (dt.Rows.Count == 1)
                    {
                        Dr = dt.Rows[0];
                    }
                    else
                    {
                        frmAidChooseZyh f = new frmAidChooseZyh(dt);
                        if (f.ShowDialog() == DialogResult.OK)
                        {
                            Dr = f.DR;
                        }
                        else
                        {
                            return;
                        }
                    }

                    this.txtZyh.Tag = Dr["registerid_chr"].ToString();
                    this.lblZycs.Text = Dr["inpatientcount_int"].ToString();
                    this.lblName.Text = Dr["lastname_vchr"].ToString();                    
                }
                else
                {
                    this.txtZyh.Tag = "";
                    this.lblZycs.Text = "";
                    this.lblName.Text = ""; 
                    MessageBox.Show("没有找到满足条件的病人记录.", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.txtZyh.SelectAll();
                    this.txtZyh.Focus();
                }
            }
        }  

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }              
    }
}