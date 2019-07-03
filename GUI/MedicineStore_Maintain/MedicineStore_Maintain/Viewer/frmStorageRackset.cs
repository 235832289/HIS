using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.MedicineStoreService;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmStorageRackset : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmStorageRackset()
        {
            InitializeComponent();
        }
        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_StorageRackSet();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    if (keyData == Keys.Enter)
        //    {
        //        System.Windows.Forms.SendKeys.Send("{tab}");
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}
        /// <summary>
        /// 1,药库货架 2,药房货架
        /// </summary>
        public string m_strStorageType = "1";
        public void m_mthSetShow(string m_strType)
        {
            this.m_strStorageType = m_strType.Trim();
            if (m_strStorageType == "1")
            {
                this.label2.Text = "药库名称";
                this.Text = "药库" + this.Text;
                this.m_lsvMedicineTypeSet.Columns[2].Text = "药库名称";
            }
            else if (m_strStorageType == "2")
            {
                this.label2.Text = "药房名称";
                this.Text = "药房" + this.Text;
                this.m_lsvMedicineTypeSet.Columns[2].Text = "药房名称";
            }
            this.Show();
        }
        private void frmStorageRackset_Load(object sender, EventArgs e)
        {
          ((clsCtl_StorageRackSet)objController).m_mthGetStorInfo();
          ((clsCtl_StorageRackSet)objController).m_mthGetMedicineRoomInfo(this.m_strStorageType,ref m_cboStorageid);
          ((clsCtl_StorageRackSet)objController).m_newClick();
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if (((clsCtl_StorageRackSet)objController).m_mthSerChack())
            {
                if (this.m_btnNew.Enabled)
                {
                    //修改
                    ((clsCtl_StorageRackSet)objController).m_mthEdit();
                }
                else
                {
                    //插入
                    ((clsCtl_StorageRackSet)objController).m_mthInsert();
                }
                
            }
        }

        private void m_lsvMedicineTypeSet_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_StorageRackSet)objController).m_mthVendorListDoubleClick();
        }
        private void m_btnNew_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageRackSet)objController).m_newClick();
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            ((clsCtl_StorageRackSet)objController).m_mthDel();
            ((clsCtl_StorageRackSet)objController).m_newClick();
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_lsvMedicineTypeSet_MouseUp(object sender, MouseEventArgs e)
        {
            ((clsCtl_StorageRackSet)objController).m_mthVendorListDoubleClick();
        }
        private void m_txtStoragerackname_Leave(object sender, EventArgs e)
        {
            ((clsCtl_StorageRackSet)objController).m_lngGetpywb(); 
        }

        private void m_txtStoragerackcode_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    m_txtStoragerackname.Focus();
                    break;
            }
        }

        private void m_txtStoragerackname_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyValue)
            {
                case 13:
                    m_cmdSave.Focus();
                    break;
            }
        }

    }
}