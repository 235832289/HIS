using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using NullableDateControls;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 查询配药人员的处方信息
    /// </summary>
    public partial class frmTreatRecipeInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 获取药房名称
        /// </summary>
        private DataTable m_objTable;
        /// <summary>
        /// 获取配药员工
        /// </summary>
        private DataTable m_objResult;
        /// <summary>
        /// 保存药房ID
        /// </summary>
        public string[] m_strMedicineidArr;
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmTreatRecipeInfo()
        {
            InitializeComponent();
        }
        #endregion

        #region 窗体控制对象
        /// <summary>
        /// 窗体控制对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_TreatRecipeInfo();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 获取药房ID
        /// <summary>
        /// 获取药房ID
        /// </summary>
        /// <param name="m_strMedicineid"></param>
        public void m_mthSetShow(string m_strMedicineid)
        {
            m_strMedicineidArr = m_strMedicineid.Split('*');
            this.Show();
        }
        #endregion

        #region 初始化窗体
        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmTreatRecipeInfo_Load(object sender, EventArgs e)
        {
            this.m_dtpBegin.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            this.m_dtpEnd.Text = DateTime.Now.ToString("yyyy年MM月dd日");
            ((clsCtl_TreatRecipeInfo)this.objController).m_mthGetMedicineName(out  m_objTable);
            ((clsCtl_TreatRecipeInfo)this.objController).m_mthGetEmpData();

            if (m_objTable != null && m_objTable.Rows.Count > 0)
            {
                if (m_strMedicineidArr != null && m_strMedicineidArr.Length > 0)
                {
                    this.m_cboMedicineName.Items.Clear();

                    for (int i1 = 0; i1 < m_strMedicineidArr.Length; i1++)
                    {
                        if (m_strMedicineidArr[i1].ToString() == "10000")
                        {
                            this.m_cboMedicineName.Item.Add("全部", "10000");
                        }
                        for (int j2 = 0; j2 < m_objTable.Rows.Count; j2++)
                        {
                            if (m_objTable.Rows[j2]["medstoreid_chr"].ToString() == m_strMedicineidArr[i1].ToString())
                            {
                                this.m_cboMedicineName.Item.Add(m_objTable.Rows[j2]["medstorename_vchr"].ToString(), m_objTable.Rows[j2]["medstoreid_chr"].ToString());
                            }
                        }
                    }

                    this.m_cboMedicineName.SelectedIndex = 0;
                }
                else
                {
                    this.m_cboMedicineName.Items.Clear();

                    this.m_cboMedicineName.Item.Add("全部", "10000");

                    for (int k = 0; k < m_objTable.Rows.Count; k++)
                    {
                        this.m_cboMedicineName.Item.Add(m_objTable.Rows[k]["medstorename_vchr"].ToString(), m_objTable.Rows[k]["medstoreid_chr"].ToString());
                    }

                    this.m_cboMedicineName.SelectedIndex = 0;
                }
            }
        }
        #endregion

        #region 事件
        /// <summary>
        /// 查询配药员工和处方信息列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_TreatRecipeInfo)this.objController).m_mthSelectTreatEmpInfo();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 点击配药员工数据行事件
        /// <summary>
        /// 点击配药员工数据行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_lsvTreatEmp_SelectedIndexChanged(object sender, EventArgs e)
        {
            //((clsCtl_TreatRecipeInfo)objController).m_mthSelectRecipeInfo();
        }
        #endregion

        #region 点击处方信息数据行事件
        /// <summary>
        /// 点击处方信息数据行事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_lsvRecipeInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_TreatRecipeInfo)objController).m_mthSelectRecipeDetailInfo();
        }
        #endregion

        #region 方法
        private void m_cboMedicineName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_ctbEmpList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_dtpBegin_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_dtpEnd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_cboMedicineName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsCtl_TreatRecipeInfo)this.objController).m_mthGetEmpData();
        }
        #endregion

        private void m_txtCartNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool blnExists = false;
                if (this.m_txtCartNo.Text.Trim() != "")
                {
                    this.m_txtCartNo.Text = this.m_txtCartNo.Text.PadLeft(10, '0');
                    if (this.m_txtCartNo.Text.Trim().Length == 10)
                    {
                        ((clsCtl_TreatRecipeInfo)objController).m_mthShowSearchCartNoForm(this.m_txtCartNo.Text,out blnExists);
                    }
                    if (!blnExists)
                    {
                        SendKeys.Send("{TAB}");
                    }
                }
                else
                {
                    SendKeys.Send("{TAB}");
                }
            }
        }

        private void m_txtPatientName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_txtInvoiceno_Leave(object sender, EventArgs e)
        {
            this.m_txtInvoiceno.Text = this.m_txtInvoiceno.Text.Trim().ToUpper();
        }
    }
}