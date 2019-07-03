using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 补记帐UI类
    /// </summary>
    public partial class frmPatchCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 当前行号
        /// </summary>
        internal int CurrRowNo = -1;
        /// <summary>
        /// 住院号
        /// </summary>
        private string Zyh = "";
        /// <summary>
        /// 当前Tree.Tag
        /// </summary>
        private string CurrTag = "";

        /// <summary>
        /// 构造
        /// </summary>
        public frmPatchCharge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="p_Zyh">病人住院号</param>
        public frmPatchCharge(string p_Zyh)
        {
            InitializeComponent();
            Zyh = p_Zyh;
        }

        /// <summary>
        /// 1 护士站 2 住院处
        /// </summary>
        internal string Scope = "2";
        /// <summary>
        /// 外部Show
        /// </summary>
        /// <param name="p_Scope"></param>
        public void m_mthShow(string p_Scope)
        {
            Scope = p_Scope;

            this.Show();
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_PatchCharge();
            objController.Set_GUI_Apperance(this);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
                
        private void frmPatchCharge_Load(object sender, EventArgs e)
        {            
            this.ucPatientInfo.m_mthSetRedraw();
            ((clsCtl_PatchCharge)this.objController).m_mthInit();
            if (Zyh.Trim() != "")
            {
                this.ucPatientInfo.m_mthFind(Zyh, 2);
                if (this.ucPatientInfo.IsChanged)
                {
                    ((clsCtl_PatchCharge)this.objController).m_mthLoad();
                }
            }
        }

        private void frmPatchCharge_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (((clsCtl_PatchCharge)this.objController).IsModify)
            {
                if (MessageBox.Show("系统检测到你有未保存的数据，是否保存？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!((clsCtl_PatchCharge)this.objController).m_blnSave())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            //设置快捷信息
            clsPublic.SetShortCutInfo(this.MdiParent, 4, ""); 

            //if (MessageBox.Show("是否退出费用直收窗口？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            //{
            //    e.Cancel = true;
            //}
        }

        private void btnFind_Click(object sender, EventArgs e)
        {           
            ((clsCtl_PatchCharge)this.objController).m_mthFind();
        }

        private void frmPatchCharge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.panelItem.Height > 0)
                {
                    this.panelItem.Height = 0;
                    this.txtItemName.SelectAll();
                    this.txtItemName.Focus();                    
                }
                else
                {
                    if (MessageBox.Show("是否关闭该窗口？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                }
            }
            else if (e.KeyCode == Keys.F3)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthFind();
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.ucPatientInfo.m_mthShortCurFind();
            }
            else if (e.KeyCode == Keys.F6)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthDelItem(2);
            }
            else if (e.KeyCode == Keys.F8)
            {
                this.ucPatientInfo.m_mthLoadArea();
            }
            else if (e.KeyCode == Keys.F9)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthCommit();
            }
        }

        /// <summary>
        /// 新建
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btnNew_Click(object sender, EventArgs e)
        {
            if (((clsCtl_PatchCharge)this.objController).IsModify)
            {
                if (MessageBox.Show("数据已发生变化，是否保存？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    if (!((clsCtl_PatchCharge)this.objController).m_blnSave())
                    {
                        return;
                    }
                }
            }

            ((clsCtl_PatchCharge)this.objController).m_mthClear();
            this.CurrRowNo = -1;
            this.lblAllTotal.Text = "";            
            this.dtgItem.Rows.Clear();
            this.dtgOrder.Rows.Clear();
            this.dtgOrderItem.Rows.Clear();
            
            this.btnAdd.Enabled = true;
            this.btnDel.Enabled = true;
            this.btnClear.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnCommit.Enabled = true;
            this.tableLayoutPanel1.Enabled = true;

            ((clsCtl_PatchCharge)this.objController).CurrOrderID = "";
            ((clsCtl_PatchCharge)this.objController).CurrOrderStatus = 0;
        }

        private void ucPatientInfo_CardNOChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthLoad();
            }
        }

        private void ucPatientInfo_ZyhChanged()
        {
            if (this.ucPatientInfo.IsChanged)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthLoad();
            }
        }                                                     
          
        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthFindChargeItem(this.txtItemName.Text.Trim());
            }
        }

        private void lsvItem_Leave(object sender, EventArgs e)
        {
            this.panelItem.Height = 0;
        }

        private void lsvItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthSelectItem();
            }            
        }

        private void lsvItem_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_PatchCharge)this.objController).m_mthSelectItem();
        }               

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            string val = this.txtAmount.Text.Trim();

            if (val == "")
            {
                return;
            }
            else
            {
                if (val != "-")
                {
                    if (!Microsoft.VisualBasic.Information.IsNumeric(val))
                    {
                        MessageBox.Show("数量输入错误，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtAmount.Text = "";
                        this.txtAmount.Focus();
                        return;
                    }                    
                }                               
            }                    
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtAmount.Text.Trim() == "-")
                {
                    return;
                }

                this.lblTotal.Text = clsPublic.Round(clsPublic.ConvertObjToDecimal(this.txtAmount.Text) * clsPublic.ConvertObjToDecimal(this.lblPrice.Text), 2).ToString();

                if (((clsCtl_PatchCharge)this.objController).ItemInputMode == 0)
                {
                    if (this.txtExecArea.Value != null && this.txtExecArea.Value.ToString().Trim() != "")
                    {
                        //this.btnAdd.Focus();
                        ((clsCtl_PatchCharge)this.objController).m_mthAddItem();
                    }
                    else
                    {
                        this.txtExecArea.Focus();
                    }
                }
                else if (((clsCtl_PatchCharge)this.objController).ItemInputMode == 1)
                {
                    //this.btnAdd.Focus();
                    ((clsCtl_PatchCharge)this.objController).m_mthAddItem();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ((clsCtl_PatchCharge)this.objController).m_mthAddItem();
        }

        private void dtgItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrRowNo = e.RowIndex;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (((clsCtl_PatchCharge)this.objController).ItemInputMode == 0)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthDelItem(2);
            }
            else if (((clsCtl_PatchCharge)this.objController).ItemInputMode == 1)
            {
                contextMenuStrip.Show(this.btnDel, new Point(this.btnDel.Width, this.btnDel.Height));
            }            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (this.dtgItem.Rows.Count > 0)
            {
                if (MessageBox.Show("是否清除所有已录入的收费项目？\r\n\r\n删除项目后请按[保存]键保存", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.dtgItem.Rows.Clear();
                    this.dtgOrder.Rows.Clear();
                    this.dtgOrderItem.Rows.Clear();
                    this.lblAllTotal.Text = "";

                    ((clsCtl_PatchCharge)this.objController).m_mthClear();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ((clsCtl_PatchCharge)this.objController).m_blnSave();
        }

        private void tvHistory_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            CurrTag = e.Node.Tag.ToString(); 
        }               

        private void txtApplyArea_ItemSelectedOK(object s, EventArgs e)
        {
            if (this.txtApplyArea.Value != null && this.txtApplyArea.Value.ToString().Trim() != "")
            {
                this.txtChargeDoctor.Focus();
            }
        }

        private void txtChargeDoctor_ItemSelectedOK(object s, EventArgs e)
        {
            if (this.txtChargeDoctor.Value != null && this.txtChargeDoctor.Value.ToString().Trim() != "")
            {
                this.txtItemName.Focus();
            }
        }

        private void txtExecArea_ItemSelectedOK(object s, EventArgs e)
        {
            if (this.txtExecArea.Value != null && this.txtExecArea.Value.ToString().Trim() != "")
            {
                this.btnAdd.Focus();
            }            
        }

        private void btnCommit_Click(object sender, EventArgs e)
        {
            ((clsCtl_PatchCharge)this.objController).m_mthCommit();
        }

        private void tvHistory_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (CurrTag.Trim() == "")
            {
                return;
            }
            else if (CurrTag.ToLower() == "root")
            {
                this.tvHistory.ExpandAll();
            }
            else
            {
                this.lblAllTotal.Text = "";

                string tmp = CurrTag;
                string OrderID = clsPublic.m_strGettoken(ref tmp, ";");
                string Status = clsPublic.m_strGettoken(ref tmp, ";");

                ((clsCtl_PatchCharge)this.objController).CurrOrderID = OrderID;
                ((clsCtl_PatchCharge)this.objController).CurrOrderStatus = int.Parse(Status);
                ((clsCtl_PatchCharge)this.objController).m_mthShowHistory(OrderID);

                if (Status == "0")
                {
                    this.btnAdd.Enabled = true;
                    this.btnDel.Enabled = true;
                    this.btnClear.Enabled = true;
                    this.btnSave.Enabled = true;
                    this.btnCommit.Enabled = true;
                    this.tableLayoutPanel1.Enabled = true;
                }
                else
                {
                    this.btnAdd.Enabled = false;
                    this.btnDel.Enabled = false;
                    this.btnClear.Enabled = false;
                    this.btnSave.Enabled = false;
                    this.btnCommit.Enabled = false;
                    this.tableLayoutPanel1.Enabled = false;
                }
            }
        }

        private void dtgItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (e.RowIndex >= 0 && this.btnSave.Enabled)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthModify(e.RowIndex);                
            }
        }

        private void dtgOrderItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrRowNo = e.RowIndex;
        }

        private void dtgOrderItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && this.btnSave.Enabled)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthModify(e.RowIndex);
            }
        }       

        private void dtgOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ((clsCtl_PatchCharge)this.objController).m_mthShowOrderEntry(this.dtgOrder.Rows[e.RowIndex].Cells["attachorderid"].Value.ToString());                
            }
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ((clsCtl_PatchCharge)this.objController).m_mthDelItem(1);
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ((clsCtl_PatchCharge)this.objController).m_mthDelItem(2);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_PatchCharge)this.objController).m_mthPrintExtraCharge();
        }
                
    }
}