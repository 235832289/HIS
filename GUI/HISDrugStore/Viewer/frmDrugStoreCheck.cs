using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmDrugStoreCheck : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {   
        /// <summary>
        /// 门诊药房盘点界面
        /// </summary>
        public frmDrugStoreCheck()
        {
            InitializeComponent();
           
            //((clsCtl_DrugStoreCheck)objController).m_mthGetIsImmAccount(out m_blnIsImmAccount);
        }
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_DrugStoreCheck();
            objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// 药房id
        /// </summary>
        public string m_strStoreID = string.Empty;
        /// <summary>
        /// 药房对应的部门ID
        /// </summary>
        public string m_strStoreDeptID = string.Empty;
        /// <summary>
        /// 药房名称
        /// </summary>
        internal string m_strStoreName;
        /// <summary>
        /// 是否有药库管理员权限
        /// </summary>
        internal bool m_blnIsAdmin = false;
        internal DataTable m_dtMainTemp;
        internal DataTable m_dtSubTemp;
        /// <summary>
        /// 盘点模式，0为默认，1为广医三院
        /// </summary>
        internal int m_intCheckMode = 0;
        /// <summary>
        /// 单据状态，0-作废，1--新制，2-审核，3--入帐，
        /// </summary>
        private int m_intStatus = -1;
        /// <summary>
        /// 主表选中的行
        /// </summary>
        internal int m_intRowIndex = -1;
        /// <summary>
        /// 选中的单号 
        /// </summary>
        internal string m_strBillNo = string.Empty;
        /// <summary>
        /// 是否住院单位
        /// </summary>
        internal bool m_blnIsHospital;
        private void frmDrugStoreCheck_Load(object sender, EventArgs e)
        {
            m_datBegin.Text = clsPub.CurrentDateTimeNow.AddMonths(-1).ToString("yyyy年MM月dd日 00时00分00秒");
            m_datEnd.Text = clsPub.CurrentDateTimeNow.ToString("yyyy年MM月dd日 23时59分59秒");
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvMain.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            ((clsCtl_DrugStoreCheck)this.objController).m_mthGetCheckMode(out m_intCheckMode);
            ((clsCtl_DrugStoreCheck)this.objController).m_lngCheckIsHospital(m_strStoreID, out m_blnIsHospital);

            m_dgvDetail.AutoGenerateColumns = false;
            if (m_intCheckMode == 1)
            {
                m_dgvDetail.Columns["opunit_chr"].Visible = false;
                m_dgvDetail.Columns["ipunit_chr"].Visible = false;
                m_dgvDetail.Columns["oprealgross_int"].Visible = false;
                m_dgvDetail.Columns["iprealgross_int"].Visible = false;
                m_dgvDetail.Columns["opcheckgross_int"].Visible = false;
                m_dgvDetail.Columns["ipcheckgross_int"].Visible = false;
            }
            else
            {
                m_dgvDetail.Columns["unit_chr"].Visible = false;
                m_dgvDetail.Columns["realgross_int"].Visible = false;
                m_dgvDetail.Columns["checkgross_int"].Visible = false;
                m_dgvDetail.Columns["checkresult_int"].Visible = false;
            }
            m_btnFind.PerformClick();

            ((clsCtl_DrugStoreCheck)objController).m_mthCheckHasAdminRole(LoginInfo.m_strEmpID, out m_blnIsAdmin);
        }
        
        public void ShowThis(string p_strStoreID)
        {
            m_strStoreID = p_strStoreID;
            clsMedStore_VO objStore = clsPub.m_mthGetMedStoreNameByid(m_strStoreID);
            if (objStore != null)
            {
                m_strStoreDeptID = objStore.m_strDeptid;
                m_strStoreName = objStore.m_strMedStoreName;
                this.Text += "(" + m_strStoreName + ")";
            }
            this.Show();
        }

        private void m_btnNew_Click(object sender, EventArgs e)
        {
            ((clsCtl_DrugStoreCheck)this.objController).m_mthFrmDetail(0);
        }

        private void m_btnModify_Click(object sender, EventArgs e)
        {
            ((clsCtl_DrugStoreCheck)this.objController).m_mthFrmDetail(1);
        }

        private void m_btnFind_Click(object sender, EventArgs e)
        {            
            ((clsCtl_DrugStoreCheck)this.objController).m_mthGetStoreCheck();
        }

        private void m_dgvMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (m_dgvMain.CurrentCell == null || m_intRowIndex == m_dgvMain.CurrentCell.RowIndex)
                return;
            ((clsCtl_DrugStoreCheck)this.objController).m_mthGetStoreCheck_detail();
            m_intRowIndex = m_dgvMain.CurrentCell.RowIndex;
        }

        private void m_dgvMain_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_DrugStoreCheck)this.objController).m_mthFrmDetail(1);
        }

        private void m_dgvMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvMain.Rows.Count; iRow++)
            {
                m_dgvMain.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;

                //自动计算电脑数、实际数
                //if (m_dgvDetail.Rows[iRow].Cells["currentgross_int"].Value.ToString().Length > 0)
                //{
                //    if (m_blnIsHospital)
                //    {
                //        if (m_dgvDetail.Rows[iRow].Cells["ipchargeflg_int"].Value.ToString() == "0")
                //        {
                //            m_dgvDetail.Rows[iRow].Cells["opcurrentgross_int"].Value = m_dgvDetail.Rows[iRow].Cells["currentgross_int"].Value;
                //            m_dgvDetail.Rows[iRow].Cells["ipcurrentgross_int"].Value = 0;
                //            m_dgvDetail.Rows[iRow].Cells["opcheckgross_int"].Value = m_dgvDetail.Rows[iRow].Cells["checkgross_int"].Value;
                //            m_dgvDetail.Rows[iRow].Cells["ipcheckgross_int"].Value = 0;
                //        }
                //        else
                //        {
                //            m_dgvDetail.Rows[iRow].Cells["opcurrentgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["currentgross_int"].Value) / Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["packqty_dec"].Value));
                //            m_dgvDetail.Rows[iRow].Cells["ipcurrentgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["currentgross_int"].Value) % Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["packqty_dec"].Value));
                //            m_dgvDetail.Rows[iRow].Cells["opcheckgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["checkgross_int"].Value) / Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["packqty_dec"].Value));
                //            m_dgvDetail.Rows[iRow].Cells["ipcheckgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["checkgross_int"].Value) % Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["packqty_dec"].Value));
                //        }
                //    }
                //    else
                //    {
                //        if (m_dgvDetail.Rows[iRow].Cells["opchargeflg_int"].Value.ToString() == "0")
                //        {
                //            m_dgvDetail.Rows[iRow].Cells["opcurrentgross_int"].Value = m_dgvDetail.Rows[iRow].Cells["currentgross_int"].Value;
                //            m_dgvDetail.Rows[iRow].Cells["ipcurrentgross_int"].Value = 0;
                //            m_dgvDetail.Rows[iRow].Cells["opcheckgross_int"].Value = m_dgvDetail.Rows[iRow].Cells["checkgross_int"].Value;
                //            m_dgvDetail.Rows[iRow].Cells["ipcheckgross_int"].Value = 0;
                //        }
                //        else
                //        {
                //            m_dgvDetail.Rows[iRow].Cells["opcurrentgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["currentgross_int"].Value) / Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["packqty_dec"].Value));
                //            m_dgvDetail.Rows[iRow].Cells["ipcurrentgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["currentgross_int"].Value) % Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["packqty_dec"].Value));
                //            m_dgvDetail.Rows[iRow].Cells["opcheckgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["checkgross_int"].Value) / Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["packqty_dec"].Value));
                //            m_dgvDetail.Rows[iRow].Cells["ipcheckgross_int"].Value = (int)(Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["checkgross_int"].Value) % Convert.ToDouble(m_dgvDetail.Rows[iRow].Cells["packqty_dec"].Value));
                //        }
                //    }
                //}
            }
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_DrugStoreCheck)this.objController).m_mthDeleteCheckStore();
        }

        private void m_btnExam_Click(object sender, EventArgs e)
        {
            ((clsCtl_DrugStoreCheck)this.objController).m_mthCommitStoreCheck();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void m_btnAccount_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell != null && this.m_dgvMain.CurrentCell.ColumnIndex == 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["CHECKID_CHR"];
            }
          
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {
                Application.DoEvents();
                ((clsCtl_DrugStoreCheck)this.objController).m_lngCheckStatus(2, Convert.ToInt64(m_dgvMain.SelectedRows[0].Cells["m_txtSerialNo"].Value), out m_intStatus);
                if (m_intStatus != 2)
                {
                    MessageBox.Show("您所选择的盘点单不是审核状态,不能进行入帐！", "药品盘点", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }                
               
            }

            ((clsCtl_DrugStoreCheck)this.objController).m_mthInAccount();
        }
    }
}
