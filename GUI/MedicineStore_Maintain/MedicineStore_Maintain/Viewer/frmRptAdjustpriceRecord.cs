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
    /// 药品调价记录查询
    /// </summary>
    public partial class frmRptAdjustpriceRecord : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 全局变量
        internal DataTable m_dtMedince;
        private DataTable m_dtResult;
        /// <summary>
        /// 0-药房;1-药库
        /// </summary>
        private int intDsOrMs=0;
        /// <summary>
        /// 库房id数组
        /// </summary>
        private string[] m_strStorageArr;
        #endregion

        #region 药房/药库窗体显示
        /// <summary>
        /// 药房/药库窗体显示
        /// </summary>
        /// <param name="p_strDsOrMs">0-药房;1-药库</param>
        /// <param name=""></param>
        public void m_mthShow(string p_strDsOrMs, string p_strStorageid)
        {
            intDsOrMs = Convert.ToInt32(p_strDsOrMs);
            m_strStorageArr = p_strStorageid.Split('*');
            if (intDsOrMs == 0)
                this.Text = "药房药品调价记录查询";
            else if(intDsOrMs == 1)
                this.Text = "药库药品调价记录查询";
            this.Show();
        }
        #endregion

        #region 窗体控制对象
        /// <summary>
        /// 窗体控制对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.MedicineStore_Maintain.clsCtl_RptAdjustpriceRecord();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmRptAdjustpriceRecord()
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
        private void frmRptAdjustpriceRecord_Load(object sender, EventArgs e)
        {
            //if (intDsOrMs == 0)
            //{
            //    this.Text += "(药房)";
            //}
            //else
            //{
            //    this.Text += "(药库)";
            //}
            this.m_dgvAdjustPrice.AutoGenerateColumns = false;
            this.m_dtpBeginDat.Text = clsPublic.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00:00:00");
            this.m_dtpEndDat.Text = clsPublic.CurrentDateTimeNow.ToString("yyyy年MM月dd日 HH:mm:ss");
            ((clsCtl_RptAdjustpriceRecord)objController).m_mthGetStorageName(intDsOrMs, out m_dtResult);
            ((clsCtl_RptAdjustpriceRecord)objController).m_mthInitdw();
            if (m_dtResult.Rows.Count > 0)
            {
                if (m_strStorageArr != null && m_strStorageArr.Length > 0)
                {
                    this.m_cboStorageName.Items.Clear();

                    for (int i1 = 0; i1 < m_strStorageArr.Length; i1++)
                    {
                        for (int j2 = 0; j2 < m_dtResult.Rows.Count; j2++)
                        {
                            if (m_dtResult.Rows[j2]["storageid_chr"].ToString() == m_strStorageArr[i1].ToString())
                            {
                                this.m_cboStorageName.Item.Add(m_dtResult.Rows[j2]["storagename_vchr"].ToString(), m_dtResult.Rows[j2]["storageid_chr"].ToString());
                            }
                        }
                    }
                    this.m_cboStorageName.SelectedIndex = 0;
                }
                else
                {
                    this.m_cboStorageName.Items.Clear();

                    this.m_cboStorageName.Item.Add("全部", "0000");

                    for (int k = 0; k < m_dtResult.Rows.Count; k++)
                    {
                        this.m_cboStorageName.Item.Add(m_dtResult.Rows[k]["storagename_vchr"].ToString(), m_dtResult.Rows[k]["storageid_chr"].ToString());
                    }
                    this.m_cboStorageName.SelectedIndex = 0;
                }
            }            
        }
        #endregion

        #region 事件
        private void m_cmdQuery_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptAdjustpriceRecord)this.objController).m_mthSelectAdjustpriceRecord(intDsOrMs);
        }

        private void m_cmdExcel_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptAdjustpriceRecord)this.objController).m_mthExploreData();
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_RptAdjustpriceRecord)this.objController).m_mthPrint();
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
        private void m_mthEnterToTab(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            { SendKeys.Send("{TAB}"); }
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_RptAdjustpriceRecord)this.objController).m_mthShowMedince(this.m_txtMedicineCode.Text.Trim());
            }
        }
        #endregion
    }
}