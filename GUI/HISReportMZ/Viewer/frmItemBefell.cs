using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
//using CrystalDecisions.CrystalReports.Engine;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmItemBefell : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmItemBefell()
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
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_ItemBefell();
            objController.Set_GUI_Apperance(this);
        }

        private void frmItemBefell_Load(object sender, EventArgs e)
        {
            dataWindowControl1.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            dataWindowControl1.DataWindowObject = "d_bih_itembeflell";
            dataWindowControl1.Modify("t_title.text = '" + ((clsCtl_ItemBefell)this.objController).m_objComInfo.m_strGetHospitalTitle() + "门诊项目统计发生明细报表(按发票)'");
            //dataWindowControl1.Modify("t_title.text = '" + ((clsCtl_ItemBefell)this.objController).m_objComInfo.m_strGetHospitalTitle() + dataWindowControl1.Describe("t_title.text") + "'");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.dtp_star.Value.ToString("yyyy-MM-dd"), this.dtp_end.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }

            dataWindowControl1.Modify("t_dat.text= ' '");

            dataWindowControl1.Modify("t_itemname.text= ' '");
            dataWindowControl1.Modify("t_itemid.text= ' '");
            dataWindowControl1.Reset();
            ((clsCtl_ItemBefell)this.objController).m_GetItemEntry();
        }

        private void txt_Item_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_ItemBefell)this.objController).m_GetItem();
            } 
        }      

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dataWindowControl1, true);
        }
    }
}