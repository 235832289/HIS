using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// 药房请领单查询界面
    /// </summary>
    public partial class frmAskQuery : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {   
         /// <summary>
         /// 构造函数
         /// </summary>
        public frmAskQuery()
        {
            InitializeComponent();
          
        }
        ///// <summary>
        ///// 析构函数
        ///// </summary>
        // ~frmAskQuery()
        //{
        //    frmMain.Dispose();
        //    m_dtAskMainInfo.Dispose();
        //    m_dtOutStorageMainInfo.Dispose();
        //}
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
        /// <summary>
        /// 药房请领主界面
        /// </summary>
        public frmAskForMedManage frmMain;
        /// <summary>
        /// 请领科室信息
        /// </summary>
        public DataTable m_dtAskDept = null;
        /// <summary>
        /// 出库部门
        /// </summary>
        public DataTable m_dtExportDept = null;
        /// <summary>
        /// 药房请领主表信息
        /// </summary>
        internal DataTable m_dtAskMainInfo = null;
        /// <summary>
        /// 药库出库主表金额
        /// </summary>
        internal DataTable m_dtAllMoney = null;
        /// <summary>
        /// 药库出库主表信息
        /// </summary>
        internal DataTable m_dtOutStorageMainInfo =null;
        /// <summary>
        /// 药品信息
        /// </summary>
        internal DataTable m_dtbMedicineInfo = null;
        /// <summary>
        /// 重写基类方法
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_AskQuery();
            objController.Set_GUI_Apperance(this);
        }
        private void frmAskQuery_Load(object sender, EventArgs e)
        {
            this.m_cboStatus.SelectedIndex = 0;
            this.m_cboAskDept.Item.Add("全部", string.Empty);
            if (this.m_dtAskDept != null)
            {
                foreach (DataRow dr in this.m_dtAskDept.Rows)
                {
                    this.m_cboAskDept.Item.Add(dr["deptname_vchr"].ToString(), dr["deptid_chr"].ToString());
                }
                this.m_dtAskDept.Dispose();
            }
            this.m_cboAskDept.SelectedIndex = 0;
            if (this.frmMain.Tag != null)
            {
                this.m_cboAskDept.FindKey(this.frmMain.Tag.ToString());

                this.m_cboAskDept.Enabled = false;

            }
            ((clsCtl_AskQuery)this.objController).m_mthGetExportDeptInfo();
            if (this.frmMain.strStorageType == "2" && this.frmMain.strStorageid != string.Empty)
            {
                this.m_cboExportDept.FindKey(this.frmMain.strStorageid);
                this.m_cboExportDept.Enabled = false;
            }
        }
        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            ((clsCtl_AskQuery)this.objController).m_mthGetAskInfoAndOutStorageInfoByConditions();
            this.Cursor = Cursors.Default;
        }

        private void m_txtMedName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_AskQuery)objController).m_mthShowQueryMedicineForm(this.m_txtMedName.Text);
            }
        }

        private void m_btnReSet_Click(object sender, EventArgs e)
        {
            if (this.m_cboAskDept.Enabled)
                this.m_cboAskDept.SelectedIndex = 0;
            this.m_txtMedName.Clear();
            if(this.m_cboExportDept.Enabled)
            this.m_cboExportDept.SelectedIndex = 0;
            this.m_cboStatus.SelectedIndex = 0;
            this.m_txtBillId.Clear();
        }

        private void m_txtBillId_KeyDown(object sender, KeyEventArgs e)
        {
            clsPub.m_mthSendTab(sender, e);
        }

        private void m_cboStatus_Enter(object sender, EventArgs e)
        {
            //clsPub.m_mthSendF4();
        }

        private void m_cboExportDept_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            { 
                this.m_btnQuery.Select();
            }
        }
    }
}