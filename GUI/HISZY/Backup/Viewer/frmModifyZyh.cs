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
    /// 修改住院号界面类
    /// </summary>
    public partial class frmModifyZyh : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        ///构造
        /// </summary>
        public frmModifyZyh()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="patientid">病人ID号</param>
        /// <param name="no">住院(留观)号</param>
        /// <param name="type">入院类型 1 普通 2 留观</param>
        public frmModifyZyh(string patientid, string no, int type)
        {
            InitializeComponent();
            pid = patientid;
            zyh = no;
            intype = type;
        }
        #endregion

        #region 变量与属性
        /// <summary>
        /// 病人入院登记流水号
        /// </summary>
        private string regid = "";
        /// <summary>
        /// 病人ID
        /// </summary>
        private string pid = "";
        /// <summary>
        /// 住院号
        /// </summary>
        private string zyh = "";
        /// <summary>
        /// 住院次数
        /// </summary>
        private int zycs = 0;
        /// <summary>
        /// 入院类型 1 普通住院 2 留观住院
        /// </summary>
        private int intype = 0;

        /// <summary>
        /// 病人入院登记流水号
        /// </summary>
        public string RegisterID
        {
            set
            {
                regid = value;
            }
            get
            {
                return regid;
            }
        }
        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientID
        {
            set
            {
                pid = value;
            }
            get
            {
                return pid;
            }
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string Zyh
        {
            set
            {
                zyh = value;
            }
            get
            {
                return zyh;
            }
        }
        /// <summary>
        /// 住院次数
        /// </summary>
        public int Zycs
        {
            set
            {
                zycs = value;
            }
            get
            {
                return zycs;
            }
        }

        #endregion

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_ModifyZyh();
            objController.Set_GUI_Apperance(this);
        }

        private void frmModifyZyh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_ModifyZyh)this.objController).m_mthFind(1);
        }

        private void frmModifyZyh_Load(object sender, EventArgs e)
        {
            ((clsCtl_ModifyZyh)this.objController).m_mthSetval(zyh, 1);
            ((clsCtl_ModifyZyh)this.objController).m_mthCheckHisinfo(pid, intype);
            this.cboType.SelectedIndex = 0;
            this.chkAuto.Checked = true;
            this.txtNewNO.Focus();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            ((clsCtl_ModifyZyh)this.objController).m_mthModifyNO();
        }

        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkAuto.Checked)
            {
                this.txtNewNO.Enabled = false;
                this.chkUnion.Checked = false;
            }
            else
            {
                this.txtNewNO.Enabled = true;
            }
        }

        private void chkUnion_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkUnion.Checked)
            {
                this.txtNewNO.Text = "";
                this.chkAuto.Checked = false;                
            }
        }

        private void btnFindOldNO_Click(object sender, EventArgs e)
        {
            ((clsCtl_ModifyZyh)this.objController).m_mthFind(2);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}