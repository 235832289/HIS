using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 病区一览
    /// </summary>
    public partial class frmAreaBedInfo : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        private DataTable dtReocrd = new DataTable();
        internal int CurrRow = -1;
        /// <summary>
        /// 病人入院登记流水号
        /// </summary>
        internal string regid = "";
        /// <summary>
        /// 病人ID
        /// </summary>
        internal string pid = "";
        /// <summary>
        /// 住院号
        /// </summary>
        internal string Zyh = "";
        /// <summary>
        /// 住院次数
        /// </summary>
        internal int Zycs = 0;
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        internal string CardNo = "";
        /// <summary>
        /// 病人姓名
        /// </summary>
        internal string patname = "";
        /// <summary>
        /// 科室(病区)显示范围 0 全部 1 所属
        /// </summary>
        internal int ShowScope = 0;
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="dt"></param>
        public frmAreaBedInfo(DataTable dt, int scope)
        {
            InitializeComponent();
            dtReocrd = dt;
            ShowScope = scope;
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_AreaBedInfo();
            objController.Set_GUI_Apperance(this);
        }

        private void frmAreaBedInfo_Load(object sender, EventArgs e)
        {
            ((clsCtl_AreaBedInfo)this.objController).m_mthLoadArea(dtReocrd);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void frmAreaBedInfo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void tvArea_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string areaid = e.Node.Tag.ToString();

            if (areaid.Trim() == "" || areaid.ToLower() == "root")
            {
                this.CurrRow = -1;
                return;
            }
            else
            {                
                ((clsCtl_AreaBedInfo)this.objController).m_mthShowBedInfo(areaid);
            }            
        }

        private void dgBed_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrRow = e.RowIndex;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ((clsCtl_AreaBedInfo)this.objController).m_mthGetZyh(CurrRow);
        }

        private void dgBed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ((clsCtl_AreaBedInfo)this.objController).m_mthGetZyh(CurrRow);
        }
    }
}