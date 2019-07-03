using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmMedStoreAreaRelation : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {　　
        /// <summary>
        /// 构造函数
        /// </summary>
        public frmMedStoreAreaRelation()
        {
            InitializeComponent();
        }
        ///<summary>
        ///设置窗体的控制类
        ///</summary>
        public override void CreateController()
        {
            this.objController = new clsControllMedStoreAreaRelation();
            this.objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// 设置是否有保存修改病区顺序号标志
        /// </summary>
        public bool m_blnSaved = true;
        private void frmMedStoreAreaRelation_Load(object sender, EventArgs e)
        {
            ((clsControllMedStoreAreaRelation)this.objController).m_mthLoadData();
        }

        private void buttonXP2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnAdd_Click(object sender, EventArgs e)
        {
            ((clsControllMedStoreAreaRelation)this.objController).m_mthAddArea();
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            ((clsControllMedStoreAreaRelation)this.objController).m_mthRemoveArea();
        }

        private void cboMedStoreType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((clsControllMedStoreAreaRelation)this.objController).m_mthMedStorChange();
        }

        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            ((clsControllMedStoreAreaRelation)this.objController).m_mthLoadData();
        }

        private void m_btnUp_Click(object sender, EventArgs e)
        {
            if (this.m_lsvCurrentArea.SelectedIndices.Count == 0)
                return;
                
            int m_intIndex = this.m_lsvCurrentArea.SelectedIndices[0];
            
            if (m_intIndex == 0)
            {
                return;
            }
            else
            {
                ListViewItem m_objTempItem = (ListViewItem)this.m_lsvCurrentArea.Items[m_intIndex-1].Clone();
                //ListViewItem m_objTempItem = new ListViewItem();
                //m_objTempItem.Text = this.m_lsvCurrentArea.Items[m_intIndex - 1].Text;
                //m_objTempItem.SubItems[1].Text = this.m_lsvCurrentArea.Items[m_intIndex - 1].SubItems[1].Text;
                //m_objTempItem.SubItems[2].Text = this.m_lsvCurrentArea.Items[m_intIndex - 1].SubItems[2].Text;
               //
                this.m_lsvCurrentArea.Items[m_intIndex - 1].Text = this.m_lsvCurrentArea.Items[m_intIndex].Text;
                this.m_lsvCurrentArea.Items[m_intIndex - 1].SubItems[1].Text= this.m_lsvCurrentArea.Items[m_intIndex].SubItems[1].Text;
                //this.m_lsvCurrentArea.Items[m_intIndex - 1].SubItems[2].Text = this.m_lsvCurrentArea.Items[m_intIndex].SubItems[2].Text;
               //
                this.m_lsvCurrentArea.Items[m_intIndex].Text = m_objTempItem.Text;
                this.m_lsvCurrentArea.Items[m_intIndex].SubItems[1].Text = m_objTempItem.SubItems[1].Text;
                //this.m_lsvCurrentArea.Items[m_intIndex].SubItems[2].Text = m_objTempItem.SubItems[2].Text;
                this.m_lsvCurrentArea.Items[m_intIndex - 1].Selected = true;
                this.m_blnSaved = false;

            }
        }

        private void m_lsvCurrentArea_ItemDrag(object sender, ItemDragEventArgs e)
        {
         
        }

        private void m_btnDown_Click(object sender, EventArgs e)
        {

            if (this.m_lsvCurrentArea.SelectedIndices.Count == 0)
                return;

            int m_intIndex = this.m_lsvCurrentArea.SelectedIndices[0];

            if (m_intIndex == this.m_lsvCurrentArea.Items.Count-1)
            {
                return;
            }
            else
            {
                ListViewItem m_objTempItem =(ListViewItem)this.m_lsvCurrentArea.Items[m_intIndex].Clone();
                //m_objTempItem.Text = this.m_lsvCurrentArea.Items[m_intIndex].Text;
                //m_objTempItem.SubItems[1].Text = this.m_lsvCurrentArea.Items[m_intIndex].SubItems[1].Text;
                //m_objTempItem.SubItems[2].Text = this.m_lsvCurrentArea.Items[m_intIndex].SubItems[2].Text;
                //
                this.m_lsvCurrentArea.Items[m_intIndex].Text = this.m_lsvCurrentArea.Items[m_intIndex+1].Text;
                this.m_lsvCurrentArea.Items[m_intIndex].SubItems[1].Text = this.m_lsvCurrentArea.Items[m_intIndex+1].SubItems[1].Text;
               // this.m_lsvCurrentArea.Items[m_intIndex].SubItems[2].Text = this.m_lsvCurrentArea.Items[m_intIndex+1].SubItems[2].Text;
                //
                this.m_lsvCurrentArea.Items[m_intIndex+1].Text = m_objTempItem.Text;
                this.m_lsvCurrentArea.Items[m_intIndex+1].SubItems[1].Text = m_objTempItem.SubItems[1].Text;
                //this.m_lsvCurrentArea.Items[m_intIndex+1].SubItems[2].Text = m_objTempItem.SubItems[2].Text;
                this.m_lsvCurrentArea.Items[m_intIndex+1].Selected = true;
                this.m_blnSaved = false;

            }
        }

        private void m_btnSave_Click(object sender, EventArgs e)
        {
            long lngRes = -1;
            lngRes=((clsControllMedStoreAreaRelation)this.objController).m_mthSaveOrderOfTable();
            if (lngRes > 0)
            {
                MessageBox.Show("调整顺序号操作成功！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.m_blnSaved = true;
            }
            else
            {
                MessageBox.Show("调整顺序号操作失败！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
         
            }
        }

        private void frmMedStoreAreaRelation_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.m_blnSaved == false)
            {
                if (DialogResult.OK == MessageBox.Show("病区顺序号已经修改，是否保存后退出！", "iCare系统温馨提示:", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1))
                {
                    m_btnSave.PerformClick();
                }
            }
        }

        private void m_btnLeft_Click(object sender, EventArgs e)
        {
            ((clsControllMedStoreAreaRelation)this.objController).m_mthRemoveArea();
        }

        private void m_btnRight_Click(object sender, EventArgs e)
        {
            ((clsControllMedStoreAreaRelation)this.objController).m_mthAddArea();
        }
    }
}