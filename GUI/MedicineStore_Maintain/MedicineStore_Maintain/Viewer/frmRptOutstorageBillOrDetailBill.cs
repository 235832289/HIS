using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 出库单据/出库单据明细表
    /// </summary>
    public partial class frmRptOutstorageBillOrDetailBill : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        /// <summary>
        /// 0001-西药库;0002-中药库
        /// </summary>
        private string[] strStorageArr;
        /// <summary>
        /// 0-药房;1-药库
        /// </summary>
        private int intDsOrMs;
        /// <summary>
        /// 药库名
        /// </summary>
        private DataTable m_dtStorageName;
        /// <summary>
        /// 出库类别
        /// </summary>
        private DataTable m_objTable = null;
        /// <summary>
        /// 0-出库单据 默认值;1-出库单据明细表
        /// </summary>
        private int m_strBillid = 0;
        /// <summary>
        /// 0-药房;1-药库 全部权限
        /// </summary>
        private int intMS;
        #endregion

        #region 全部药房/药库窗体
        /// <summary>
        /// 0-全部药房;1-全部药库
        /// </summary>
        /// <param name="p_strMS">0-药房;1-药库</param>
        /// <param name="p_strBillid">0-出库单据 默认值;1-出库单据明细表</param>
        public void m_mthShow(string p_strMS, string p_strBillid)
        {
            intMS = Convert.ToInt32(p_strMS);
            m_strBillid = Convert.ToInt32(p_strBillid);
            this.Show();
        }
        #endregion

        #region 药房/药库窗体窗体显示(限制)
        /// <summary>
        /// 药房/药库窗体窗体显示(限制)
        /// </summary>
        /// <param name="p_strDsOrMs">0-药房;1-药库</param>
        /// <param name="p_strBillid">0-出库单据 默认值;1-出库单据明细表</param>
        /// <param name="p_strStorageid">药房或药库ID</param>
        public void m_mthShowid(string p_strDsOrMs, string p_strBillid, string p_strStorageid)
        {
            intDsOrMs = Convert.ToInt32(p_strDsOrMs);
            m_strBillid = Convert.ToInt32(p_strBillid);
            strStorageArr = p_strStorageid.Split('*');
            this.Show();
        }
        #endregion

        #region 窗体控制对象
        /// <summary>
        /// 窗体控制对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.MedicineStore_Maintain.clsCtl_RptOutstorageBillOrDetailBill();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRptOutstorageBillOrDetailBill()
        {
            InitializeComponent();
        }
        #endregion

        #region 初始化窗体
        /// <summary>
        /// 初始化窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRptOutstorageBillOrDetailBill_Load(object sender, EventArgs e)
        {
            if (intMS == 1)
            {
                intDsOrMs = 1;
            }
            if (m_strBillid == 1)
            {
                this.Text = "出库单据报表的明细表";
            }
            else
            {
                this.Text = "出库单据报表";
            }
            if (intDsOrMs == 0)
            {
                this.label4.Text = "借调部门：";
                this.Text += "(药房)";
            }
            else
            {
                this.label4.Text = " 供货商：";
                this.Text += "(药库)";
            }
            this.m_dtpBeginDat.Text = DateTime.Today.ToString("yyyy年MM月dd日");
            this.m_dtpEndDat.Text = DateTime.Today.ToString("yyyy年MM月dd日");

            m_objTable = new DataTable();
            m_dtStorageName = new DataTable();
            ((clsCtl_RptOutstorageBillOrDetailBill)this.objController).m_mthGetStorageName(intDsOrMs, out m_dtStorageName);
            ((clsCtl_RptOutstorageBillOrDetailBill)objController).m_mthGetInitDw(intDsOrMs,m_strBillid);
            ((clsCtl_RptOutstorageBillOrDetailBill)objController).m_mthGetVendorTable(intDsOrMs);
            ((clsCtl_RptOutstorageBillOrDetailBill)objController).m_mthGetOutstorageType(out m_objTable);
            if (m_dtStorageName.Rows.Count > 0)
            {
                if (strStorageArr != null && strStorageArr.Length > 0)
                {
                    this.m_cboStorageName.Items.Clear();

                    for (int i1 = 0; i1 < strStorageArr.Length; i1++)
                    {
                        for (int j2 = 0; j2 < m_dtStorageName.Rows.Count; j2++)
                        {
                            if (m_dtStorageName.Rows[j2]["storageid_chr"].ToString() == strStorageArr[i1].ToString())
                            {
                                this.m_cboStorageName.Item.Add(m_dtStorageName.Rows[j2]["storagename_vchr"].ToString(), m_dtStorageName.Rows[j2]["storageid_chr"].ToString());
                            }
                        }
                    }
                    this.m_cboStorageName.SelectedIndex = 0;
                }
                else
                {
                    this.m_cboStorageName.Items.Clear();

                    this.m_cboStorageName.Item.Add("全部", "0000");

                    for (int k = 0; k < m_dtStorageName.Rows.Count; k++)
                    {
                        this.m_cboStorageName.Item.Add(m_dtStorageName.Rows[k]["storagename_vchr"].ToString(), m_dtStorageName.Rows[k]["storageid_chr"].ToString());
                    }
                    this.m_cboStorageName.SelectedIndex = 0;
                }
            }

            if (m_objTable != null && m_objTable.Rows.Count > 0)
            {
                this.m_cboOutStorageType.Items.Clear();

                this.m_cboOutStorageType.Item.Add("全部", "0000");

                for (int i = 0; i < m_objTable.Rows.Count; i++)
                {
                    m_cboOutStorageType.Item.Add(m_objTable.Rows[i]["typename_vchr"].ToString(), m_objTable.Rows[i]["typecode_vchr"].ToString());
                }

                m_cboOutStorageType.SelectedIndex = 0;
            }
        }
        #endregion

        #region 事件
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptOutstorageBillOrDetailBill)this.objController).m_mthSelectOutstorageBill(intDsOrMs,m_strBillid);
        }

        private void m_cmdExcel_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptOutstorageBillOrDetailBill)this.objController).m_mthExploreData();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptOutstorageBillOrDetailBill)this.objController).m_mthPrint();
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 方法
        private void m_mthKeyPressToTAB(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_RptOutstorageBillOrDetailBill)objController).m_mthGetVendor(this.m_txtVendor.Text.Trim());
            }
        }
        #endregion
    }
}