using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 定义(设置)住院发票单据所打印之分类项目UI类
    /// </summary>
    public partial class frmDefInvoiceBillItems : Form
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmDefInvoiceBillItems()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 分类 2 门诊发票 4 住院发票
        /// </summary>
        private string CatScope = "4";

        /// <summary>
        /// 外部方法
        /// </summary>
        /// <param name="scope">2 门诊发票 4 住院发票</param>
        public void m_mthShow(string scope)
        {
            CatScope = scope;

            if (CatScope == "2")
            {
                this.Text = "门诊发票单据所打印的分类项目定义窗口";
            }
            else if (CatScope == "4")
            {
                this.Text = "住院发票单据所打印的分类项目定义窗口";
            }
            else if (CatScope == "5")
            {
                this.Text = "[新版本]住院发票单据所打印的分类项目定义窗口";
            }
            else if (CatScope == "8")
            {
                this.Text = "[新版本]门诊发票单据所打印的分类项目定义窗口";
            }

            this.ShowDialog();
        }

        private void frmDefInvoiceBillItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            int nums = 0;

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["ColPrtCtrl"].Value.ToString().Trim() != "")
                {
                    nums++;
                }
            }

            if (this.hasDef.Count != nums && blnSave == false)
            {
                if (MessageBox.Show("设置信息发生更改，是否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    this.m_blnSave();
                }
            }

            this.Close();
        }

        #region 变量
        private DataTable dtOrg = new DataTable();
        private Hashtable hasDef = new Hashtable();
        private bool blnSave = false;
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void m_mthInit()
        {
            string CatID = "";

            DataTable dt;

            clsDcl_Charge objCharge = new clsDcl_Charge();

            long l = 0;

            if (CatScope == "2")//旧版门诊
                l = objCharge.m_lngGetChargeItemCat(int.Parse(CatScope), out dtOrg);
            else if (CatScope == "4")//旧版住院
                l = objCharge.m_lngGetChargeItemCat(int.Parse(CatScope), out dtOrg);
            else if (CatScope == "8")//新版门诊
                l = objCharge.m_lngGetChargeItemCat(2, out dtOrg);
            else if (CatScope == "5")//新版住院
                l = objCharge.m_lngGetChargeItemCat(4, out dtOrg);

            if (l > 0)
            {
                if (CatScope == "8")
                {
                    l = objCharge.m_lngGetDefChargeCat("8", "%", out dt);
                }
                else if (CatScope == "5")
                {
                    l = objCharge.m_lngGetDefChargeCat("5", "%", out dt);
                }
                else
                    l = objCharge.m_lngGetDefChargeCat(CatScope, "%", out dt);

                if (l > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CatID = dt.Rows[i]["catid_chr"].ToString();

                        if (!hasDef.ContainsKey(CatID))
                        {
                            hasDef.Add(CatID, dt.Rows[i]);
                        }
                    }
                }                
            }            
        }
        #endregion

        #region 获取门诊、住院发票分类信息
        /// <summary>
        /// 获取门诊、住院发票分类信息
        /// </summary>
        public void m_mthGetIPInvoCat()
        {
            this.m_mthInit();

            if (dtOrg.Rows.Count == 0)
            {
                return;
            }

            string CatID = "";

            for (int i = 0; i < dtOrg.Rows.Count; i++)
            {
                CatID = dtOrg.Rows[i]["typeid_chr"].ToString();

                string[] s = new string[7];

                s[0] = Convert.ToString(i + 1);
                s[1] = CatID;
                s[2] = dtOrg.Rows[i]["typename_vchr"].ToString();

                if (hasDef.ContainsKey(CatID))
                {
                    DataRow dr = hasDef[CatID] as DataRow;

                    if (dr["type_int"].ToString() == "0")
                    {
                        s[3] = "普通型";
                    }
                    else if (dr["type_int"].ToString() == "1")
                    {
                        s[3] = "计算型";
                    }

                    if (dr["compexp_vchr"].ToString().Trim() == "*")
                    {
                        s[4] = "";
                    }
                    else
                    {
                        s[4] = dr["compexp_vchr"].ToString();
                    }                    
                    
                    s[5] = dr["prtclt_vchr"].ToString();

                    if (dr["status_int"].ToString() == "0")
                    {
                        s[6] = "停用";
                    }
                    else if (dr["status_int"].ToString() == "1")
                    {
                        s[6] = "启用";
                    }                 
                }
                else
                {                                        
                    s[3] = "普通型";
                    s[4] = "";
                    s[5] = "";
                    s[6] = "停用";
                }

                int row = this.dataGridView1.Rows.Add(s);
                this.dataGridView1.Rows[row].Tag = dtOrg.Rows[i];
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public bool m_blnSave()
        {
            this.dataGridView1.Refresh();

            ArrayList ChargeItemCatArr = new ArrayList();

            for (int i = 0; i < this.dataGridView1.Rows.Count; i++)
            {
                if (this.dataGridView1.Rows[i].Cells["ColPrtCtrl"].Value.ToString().Trim() != "")
                {
                    DataRow dr = this.dataGridView1.Rows[i].Tag as DataRow;

                    clsBihChargeItemCat_VO ChargeItemCat_VO = new clsBihChargeItemCat_VO();

                    ChargeItemCat_VO.Scope = CatScope;
                    ChargeItemCat_VO.CatID = dr["typeid_chr"].ToString();
                    ChargeItemCat_VO.CatName = dr["typename_vchr"].ToString();                    
                    ChargeItemCat_VO.Type = (this.dataGridView1.Rows[i].Cells["ColType"].Value.ToString().Trim() == "普通型" ? "0" : "1");
                    if (this.dataGridView1.Rows[i].Cells["ColComputeExp"].Value == null || this.dataGridView1.Rows[i].Cells["ColComputeExp"].Value.ToString().Trim() == "")
                    {
                        ChargeItemCat_VO.CompExp = "*";
                    }
                    else
                    {
                        ChargeItemCat_VO.CompExp = this.dataGridView1.Rows[i].Cells["ColComputeExp"].Value.ToString().Trim();
                    }
                    ChargeItemCat_VO.DispCtl = "*";
                    ChargeItemCat_VO.PrtClt = this.dataGridView1.Rows[i].Cells["ColPrtCtrl"].Value.ToString().Trim();
                    ChargeItemCat_VO.Status = (this.dataGridView1.Rows[i].Cells["ColStatus"].Value.ToString().Trim() == "停用" ? "0" : "1");

                    ChargeItemCatArr.Add(ChargeItemCat_VO);
                }
            }

            clsDcl_Charge objCharge = new clsDcl_Charge();

            long l = objCharge.m_lngSaveInvoiceSet(ChargeItemCatArr, CatScope);
            if (l > 0)
            {
                blnSave = true;
                MessageBox.Show("设置信息保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("保存设置信息失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }
        #endregion

        private void frmDefInvoiceBillItems_Load(object sender, EventArgs e)
        {
            this.m_mthGetIPInvoCat();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.m_blnSave();
        }
    }
}
