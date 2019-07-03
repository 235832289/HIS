using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmItemCollect : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmItemCollect()
        {
            InitializeComponent();
        }
        internal string str_parmval = "0";
        public void m_mthShow(string parmval)
        {
            str_parmval = parmval;
            this.Show();
        }


        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_ItemCollect();
            objController.Set_GUI_Apperance(this);
        }

        private void labItemName_Click(object sender, EventArgs e)
        {

        }

        private void m_comFind_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.dtp_star.Value.ToString("yyyy-MM-dd"), this.dtp_end.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }

            dataWindowControl1.Modify("t_dat.text= ' '");
            dataWindowControl1.Modify("t_itemname.text= ' '");
            dataWindowControl1.Modify("t_itemid.text= ' '");

            dataWindowControl1.Reset();
            ((clsCtl_ItemCollect)this.objController).m_GetItemCollect();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dataWindowControl1, true);
        }

        private void txt_Item_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_ItemCollect)this.objController).m_GetItem();
            } 

        }

        private void frmItemCollect_Load(object sender, EventArgs e)
        {
            dataWindowControl1.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            dataWindowControl1.DataWindowObject = "d_bih_itemcollect";
            dataWindowControl1.Modify("t_1.text = '" + ((clsCtl_ItemCollect)objController).m_objComInfo.m_strGetHospitalTitle() + "门诊单项消耗品报表(按发票)'");

        }
    }
}