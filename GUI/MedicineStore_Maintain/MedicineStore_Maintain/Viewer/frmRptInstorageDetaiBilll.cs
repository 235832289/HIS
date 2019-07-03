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
    /// 
    /// </summary>
    public partial class frmRptInstorageDetaiBilll : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        private DataTable m_objTable = null;
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
        /// 0-药房;1-药库 全部权限
        /// </summary>
        private int intMS;
        #endregion

        #region 全部药房/药库窗体
        /// <summary>
        /// 0-全部药房;1-全部药库
        /// </summary>
        /// <param name="p_strMS">0-药房;1-药库</param>
        public void m_mthShow(string p_strMS)
        {
            intMS = Convert.ToInt32(p_strMS);
            this.Show();
        }
        #endregion

        #region 药房/药库窗体窗体显示(限制)
        /// <summary>
        /// 药房/药库窗体窗体显示(限制)
        /// </summary>
        /// <param name="p_strDsOrMs">0-药房;1-药库</param>
        /// <param name="p_strStorageid">药房或药库ID</param>
        public void m_mthShowid(string p_strDsOrMs, string p_strStorageid)
        {
            intDsOrMs = Convert.ToInt32(p_strDsOrMs);
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
            this.objController = new com.digitalwave.iCare.gui.MedicineStore_Maintain.clsCtl_RptInstorageDetailBill();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRptInstorageDetaiBilll()
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
        private void frmRptInstorageDetaiBilll_Load(object sender, EventArgs e)
        {
            this.m_dgvInstorageDetail.AutoGenerateColumns = false;
            if (intMS == 1)
            {
                intDsOrMs = 1;
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
            m_objTable = new DataTable();
            m_dtStorageName = new DataTable();
            this.m_dtpBeginDat.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            this.m_dtpEndDat.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
            ((clsCtl_RptInstorageDetailBill)this.objController).m_mthGetStorageName(intDsOrMs, out m_dtStorageName);
            ((clsCtl_RptInstorageDetailBill)objController).m_mthGetInstorageName(out m_objTable);
            ((clsCtl_RptInstorageDetailBill)objController).m_mthInitdw(intDsOrMs);
            ((clsCtl_RptInstorageDetailBill)objController).m_mthGetVendorTable(intDsOrMs);
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
                this.m_cboInStorageType.Items.Clear();

                this.m_cboInStorageType.Item.Add("全部", "0000");

                for (int i = 0; i < m_objTable.Rows.Count; i++)
                {
                    this.m_cboInStorageType.Item.Add(m_objTable.Rows[i]["typename_vchr"].ToString(), m_objTable.Rows[i]["typecode_vchr"].ToString());
                }

                this.m_cboInStorageType.SelectedIndex = 0;
            }
        }
        #endregion

        #region 事件
        private void m_txtVendor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_RptInstorageDetailBill)objController).m_mthGetVendorName(this.m_txtVendor.Text.ToString().Trim());
            }
        }

        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptInstorageDetailBill)this.objController).m_mthSelectInstorageDetailBill(intDsOrMs);
        }

        private void m_cmdExcel_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptInstorageDetailBill)this.objController).m_mthExploreData();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptInstorageDetailBill)this.objController).m_mthPrint();
        }

        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            //dw.PrintProperties.Preview = !dw.PrintProperties.Preview;
            //dw.PrintProperties.ShowPreviewRulers = !dw.PrintProperties.ShowPreviewRulers;
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(this.dw);
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 方法
        private void m_dtpBeginDat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_dtpEndDat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_cboInStorageType_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }
        #endregion
    }
}