using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.TemplateUtility; 
namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOPSApply : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {        
        internal clsOutops_VO objOutops = new clsOutops_VO();
        public frmOPSApply(clsOutops_VO outopsvo)
        {
            InitializeComponent();
            objOutops = outopsvo;     
        }

        private int dirflag = 0;
        public frmOPSApply()
        {
            InitializeComponent();
            dirflag = 1;            
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_OPSApply();
            objController.Set_GUI_Apperance(this);
        }

        public clsOutops_VO clsOPS_VO
        {
            get
            {
                return objOutops;
            }
        }

        private bool opssave = false;
        public bool Opssave
        {
            get
            {
                return opssave;
            }
            set
            {
                opssave = value;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            contextMenuStrip.Show(btnFind, new Point(btnFind.Width, btnFind.Height));   
            //((clsCtl_OPSApply)this.objController).m_mthFind(0);
        }
        #region 模板

        #region 生成模板
        private com.digitalwave.iCare.gui.Security.clsController_Security objController_Security = null;
        private com.digitalwave.iCare.Template.Client.clsTemplateClient m_objTemplate;
        public void m_mthCreateTemplate()
        {
            this.m_objTemplate.m_mthCreateTemplate();
        }
        #endregion

        private void btnCreateTemplate_Click(object sender, System.EventArgs e)
        {
            m_mthCreateTemplate();
        }
        #endregion
        private void frmOPSApply_Load(object sender, EventArgs e)
        {
            #region 模板
            string m_strDeptID = "";
            string m_strEmpID = this.LoginInfo.m_strEmpID;
            com.digitalwave.GUI_Base.clsController_Base objCtlBase = new com.digitalwave.GUI_Base.clsController_Base();
            com.digitalwave.iCare.ValueObject.clsDepartmentVO[] objDept = null;
            objCtlBase.m_objComInfo.m_mthGetDepartmentByUserID(m_strEmpID, out objDept);
            if (objDept != null)
            {
                for (int i = 0; i < objDept.Length; i++)
                {
                    if (objDept[i].intInPatientOrOutPatient == 0)
                    {
                        m_strDeptID = objDept[i].strDeptID;
                        break;
                    }
                }
            }
            m_objTemplate = new com.digitalwave.iCare.Template.Client.clsTemplateClient(this, this.LoginInfo.m_strEmpID, m_strDeptID);
            #endregion 
            this.txtAppHint.ContextMenu = this.contextMenu1;

            if (dirflag == 1)
            {
                btnFind.Enabled = false;
                btnSave.Enabled = false;
                btnPrint.Enabled = false;
            }
            else
            {
                ((clsCtl_OPSApply)this.objController).m_mthInit();
                ((clsCtl_OPSApply)this.objController).m_mthInitvalue();
                if (objOutops.chrgitem.Trim() != "")
                {
                    this.btnItem.Enabled = false;
                }
            }

        }

        private void dtpbooking_ValueChanged(object sender, EventArgs e)
        {
            this.txtAppYear.Text = dtpbooking.Value.Year.ToString();
            this.txtAppMonth.Text = dtpbooking.Value.Month.ToString();            
            this.txtAppDay.Text = dtpbooking.Value.Day.ToString();
            this.txtAppHour.Text = dtpbooking.Value.Hour.ToString();
            this.txtAppMinute.Text = dtpbooking.Value.Minute.ToString();            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ((clsCtl_OPSApply)this.objController).m_mthFind(1);
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {            
            this.cboDepartment.Tag = ((clsCtl_OPSApply)this.objController).m_mthGetDeptID(cboDepartment.Text);
        }

        private void btnItem_Click(object sender, EventArgs e)
        {
            frmOPSFindchargeitem frm = new frmOPSFindchargeitem();
            frm.Paytype = objOutops.paytype;
            if(frm.ShowDialog() == DialogResult.OK)            
            {
                if (this.objOutops.chrgitem.Trim() == "")
                {                    
                    this.objOutops.chrgitem = frm.Chrgitemcode;
                    this.objOutops.chrgname = frm.Chrgitemname;
                    this.txtAppOPSName.Text = frm.Chrgitemname;
                }
                else
                {
                    if (this.objOutops.chrgitem != frm.Chrgitemcode)
                    {
                        if (MessageBox.Show("是否更改手术项目？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {                            
                            this.objOutops.chrgitem = frm.Chrgitemcode;
                            this.objOutops.chrgname = frm.Chrgitemname;
                            this.txtAppOPSName.Text = frm.Chrgitemname;
                        }
                    }
                }
            }            
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.objOutops.chrgitem.Trim() == "")
            {
                MessageBox.Show("请选择手术项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string bookingdate = ((clsCtl_OPSApply)this.objController).m_mthGetbookingdate();
            if (bookingdate.Trim() == "")
            {
                return;
            }

            this.objOutops.bookingdate = bookingdate;

            this.objOutops.deptid = this.cboDepartment.Tag.ToString();
            this.objOutops.deptname = this.cboDepartment.Text.ToString();

            this.objOutops.note = this.txtAppHint.Text.ToString().Trim();

            this.lblSave.Text = "已保存";
            this.Opssave = true;
            MessageBox.Show("申请信息已保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_OPSApply)this.objController).m_mthPrint();
        }

        private void ToolStripMenuItemApp_Click(object sender, EventArgs e)
        {
            ((clsCtl_OPSApply)this.objController).m_mthFind(0);
        }

        private void ToolStripMenuItemRep_Click(object sender, EventArgs e)
        {
             frmOPSFindreport objfrm = new frmOPSFindreport();
             objfrm.ShowDialog();
             objfrm = null;
                 
        }

        private void menu_CreatTemplate_Click(object sender, EventArgs e)
        {
            m_mthCreateTemplate();
        }

        private void menu_changeTemplate_Click(object sender, EventArgs e)
        {
            this.m_objTemplate.m_mthManageTemplate();
        }

        private void menu_Cut_Click(object sender, EventArgs e)
        {
            txtAppHint.Cut();
        }

        private void menu_Copy_Click(object sender, EventArgs e)
        {
            txtAppHint.Copy();

        }

        private void menuI_Paste_Click(object sender, EventArgs e)
        {
            txtAppHint.Paste();
            
        }

        private void menuI_Undo_Click(object sender, EventArgs e)
        {
            txtAppHint.m_mthUndo();

        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            m_objTemplate.m_mthUseTemplate();
        }       
                   
    }
}