using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 增加退药同方号的判断逻辑
    /// </summary>
    public partial class frmConfirmOrderBack : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 病人姓名
        /// </summary>
        internal string m_strPatientName = "";
        /// <summary>
        /// 操作名称	{例如：停止、重整等}
        /// </summary>
        internal string m_strOperateName = "";
        /// <summary>
        /// 医嘱ＩＤ
        /// </summary>
        internal string m_strOrderID = "";
        /// <summary>
        /// 医嘱名称
        /// </summary>
        internal string m_strOrderName = "";
        public frmConfirmOrderBack()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数	
        /// </summary>
        /// <param name="m_strOrderID">医嘱ＩＤ</param>
        public frmConfirmOrderBack(string p_strOrderID,string p_strOrderName)
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();

            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            m_strOrderID = p_strOrderID;
            m_strOrderName = p_strOrderName;

        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.BIHOrder.clsCtl_ConfirmOrderBack();
            objController.Set_GUI_Apperance(this);
        }
        private void m_cmdOk_Click(object sender, EventArgs e)
        {

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmConfirmOrderBack_Load(object sender, EventArgs e)
        {
            ((clsCtl_ConfirmOrderBack)this.objController).LoadData();
        }
    }
}