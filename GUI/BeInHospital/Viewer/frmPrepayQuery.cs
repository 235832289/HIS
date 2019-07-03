using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{

    
      /// <summary>
    /// 预交金查询
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-14
    /// </summary>
    public partial class frmPrepayQuery : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        //支付类型列表
        internal System.Windows.Forms.ListView lsvCuycateInfo;
        private System.Windows.Forms.ColumnHeader ColumnNum;
        private System.Windows.Forms.ColumnHeader ColumnName;

        /// <summary>
        /// 科室ID数组
        /// </summary>
        internal ArrayList m_deptIDArr = new ArrayList();

        public frmPrepayQuery()
        {
            InitializeComponent();

            #region 创建住院病区列表控键
            //lsvAreaInfo = new ListView();
            //this.lsvAreaInfo.DoubleClick += new System.EventHandler(this.lsvAreaInfo_DoubleClick);
            //this.lsvAreaInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvAreaInfo_KeyDown);
            //this.lsvAreaInfo.Leave += new System.EventHandler(this.lsvAreaInfo_Leave);
            #endregion

        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlPrepayQuery();
            objController.Set_GUI_Apperance(this);
        }

        private void frmPrepayQuery_Load(object sender, EventArgs e)
        {
            this.m_dateTimePickerFrom.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00";
            this.m_dateTimePickerTo.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59";
        }

        #region 接收函数接口
        /// <summary>
        /// 
        /// </summary>
        internal string str_parmval = "0";

        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;

            this.Show();
        }
        #endregion

        private void m_buttonFind_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.m_dateTimePickerFrom.Value.ToString("yyyy-MM-dd"), this.m_dateTimePickerTo.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }  
            
            ((clsCtlPrepayQuery)this.objController).ButtonFind_Click();
        }

        private void m_buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       #region 病区查找
        //private void lsvAreaInfo_DoubleClick(object sender, System.EventArgs e)
        //{
        //    if (this.lsvAreaInfo.SelectedItems.Count > 0)
        //    {
        //        this.m_textBoxArea.Text = this.lsvAreaInfo.SelectedItems[0].SubItems[1].Text;
        //        if (this.lsvAreaInfo.SelectedItems[0].Index == 0)
        //        {
        //            this.m_textBoxArea.Tag = "%";
        //        }
        //        else
        //        {
        //            this.m_textBoxArea.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.SelectedItems[0].Tag).m_strDEPTID_CHR;
        //        }
        //        this.lsvAreaInfo.Visible = false;
        //    }
        //}
        //private void lsvAreaInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        lsvAreaInfo_DoubleClick(null, null);
        //    }
        //}
        //private void lsvAreaInfo_Leave(object sender, System.EventArgs e)
        //{
        //    this.lsvAreaInfo.Visible = false;
        //}
        #endregion

       #region 病区输入框事件
        //private void m_textBoxArea_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Enter)
        //    {
        //        #region 控件处理

        //        #region 病区编号	
        //        this.ColumnNum = new System.Windows.Forms.ColumnHeader();
        //        this.ColumnNum.Text = "病区编号";
        //        this.ColumnNum.Width = 80;
        //        #endregion

        //        this.ColumnName = new System.Windows.Forms.ColumnHeader();
        //        this.ColumnName.Text = "病区名称";
        //        this.ColumnName.Width = 120;
        //        this.lsvAreaInfo.Size = new System.Drawing.Size(180, 144);

        //        this.lsvAreaInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
        //                                                                                    ColumnNum,this.ColumnName});
        //        this.lsvAreaInfo.View = System.Windows.Forms.View.Details;
        //        this.lsvAreaInfo.FullRowSelect = true;
        //        this.lsvAreaInfo.GridLines = true;
        //        ((clsCtlPrepayQuery)this.objController).LoadArea();
        //        if (lsvAreaInfo.Items.Count < 1)
        //            return;
        //        if (lsvAreaInfo.Items.Count == 1)
        //        {
        //            this.lsvAreaInfo.Items[0].Selected = true;
        //            this.m_textBoxArea.Text = this.lsvAreaInfo.Items[0].SubItems[1].Text;
        //            this.m_textBoxArea.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.Items[0].Tag).m_strDEPTID_CHR;
        //            return;
        //        }
        //        this.Controls.Add(this.lsvAreaInfo);
        //        //this.tabPage1.Controls.Add(this.lsvAreaInfo);
        //        this.lsvAreaInfo.Location = new System.Drawing.Point(373, 38);
        //        #endregion
        //        this.lsvAreaInfo.Items[0].Selected = true;
        //        this.lsvAreaInfo.Show();
        //        this.lsvAreaInfo.BringToFront();
        //        this.lsvAreaInfo.Focus();
        //    }
        //}
        #endregion

        private void m_checkBoxDate_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.m_checkBoxDate.Checked;

            this.m_dateTimePickerFrom.Visible = isChecked;
            this.m_dateTimePickerTo.Visible = isChecked;
            this.m_labelTo.Enabled = isChecked;

            if (isChecked == true)
            {
                this.m_dateTimePickerFrom.Focus();
            }
        }

        private void m_checkBoxArea_CheckedChanged(object sender, EventArgs e)
        {
           
            if (this.m_checkBoxArea.Checked == true)
            {
                frmAidDeptList fDept = new frmAidDeptList();
                if (fDept.ShowDialog() == DialogResult.OK)
                {
                    m_deptIDArr = fDept.DeptIDArr;
                }
            }
        }

        private void m_checkBoxCreater_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.m_checkBoxCreater.Checked;
            this.m_textBoxCreater.Enabled = isChecked;

            if (isChecked == true)
            {
                this.m_textBoxCreater.Focus();
            }
        }

        private void m_checkBoxInPatientId_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.m_checkBoxInPatientId.Checked;
            this.m_textBoxInPatientId.Enabled = isChecked;

            if (isChecked == true)
            {
                this.m_textBoxInPatientId.Focus();
            }
        }

        private void m_checkBoxPrepayInv_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = this.m_checkBoxPrepayInv.Checked;
            this.m_textBoxPrepayInv.Enabled = isChecked;


            if (isChecked == true)
            {
                this.m_textBoxPrepayInv.Focus();
            }
        }

        private void m_buttonPrint_Click(object sender, EventArgs e)
        {
            ((clsCtlPrepayQuery)this.objController).PrintResult();
        }

        private void m_dataGridViewRs_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.RowIndex2 < this.m_dataGridViewRs.RowCount - 1
                && e.RowIndex1 < this.m_dataGridViewRs.RowCount - 1 
                && e.CellValue1 != null 
                && e.CellValue2 != null)
            {
                // Try to sort based on the cells in the current column.
                if (e.Column.Name == "MONEY_DEC")
                {
                    e.SortResult = System.Decimal.Compare(
                       decimal.Parse(e.CellValue1.ToString()), decimal.Parse(e.CellValue2.ToString()));
                }
                else
                {
                    e.SortResult = System.String.Compare(
                        e.CellValue1.ToString(), e.CellValue2.ToString());
                }
                

                // If the cells are equal, sort based on the CREATE_DAT column.
                if (e.SortResult == 0 && e.Column.Name != "CREATE_DAT")
                {
                    e.SortResult = System.String.Compare(
                        m_dataGridViewRs.Rows[e.RowIndex1].Cells["CREATE_DAT"].Value.ToString(),
                        m_dataGridViewRs.Rows[e.RowIndex2].Cells["CREATE_DAT"].Value.ToString());
                }

            }
            e.Handled = true;
        }

        private void m_dataGridViewRs_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            bool isAllowMod = ((clsCtlPrepayQuery)this.objController).IsAllowModify();
            if (!isAllowMod)
            {
                e.Cancel = true;
                return;
            }

            string balanceFlag = this.m_dataGridViewRs.Rows[e.RowIndex].Cells["BALANCEFLAG_INT"].Value.ToString();
            if (balanceFlag != "未结帐")
            {
                MessageBox.Show("该记录已结帐，不能再修改其支付类型。", "提示");
                e.Cancel = true;
                return;
               
            }

            if (MessageBox.Show("你真的要改变该单的支付类型吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

        }

        private void m_dataGridViewRs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            ((clsCtlPrepayQuery)this.objController).MondifyCuycate(e);
        }

        private void m_cmdArea_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                m_deptIDArr = fDept.DeptIDArr;
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            ((clsCtlPrepayQuery)this.objController).RePrintInvoice();
        }    
    }
}