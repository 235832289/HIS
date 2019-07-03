using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    public partial class frmMedIcineCheckReport : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public string typeID;
        public frmMedIcineCheckReport()
        {
            InitializeComponent();

            this.m_dwRpt.LibraryList = clsPublic.PBLPath;
        }
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="str">typeID</param>
        /// <param name="p_strReportName">报表名称</param>
        public void showing(string str,string p_strReportName)
        {
            typeID = str;
            m_dwRpt.LibraryList = clsPublic.PBLPath;
            m_dwRpt.DataWindowObject = p_strReportName == "" ? "ms_checkreport" : "ms_checkreport_" + p_strReportName;
            this.Show();
            //((clsCtl_MedIcineCheckReport)objController).m_getMedIcineType();
        }
        public override void CreateController()
        {
            this.objController = new clsCtl_MedIcineCheckReport();
            objController.Set_GUI_Apperance(this);
        }
        private void frmMedIcineCheckReport_Load(object sender, EventArgs e)
        {
            ((clsCtl_MedIcineCheckReport)objController).m_loadDwrpt();
            ((clsCtl_MedIcineCheckReport)objController).m_mthGetMedicineTypeSet();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void cmdQuery_Click(object sender, EventArgs e)
        {

            ((clsCtl_MedIcineCheckReport)this.objController).m_getMedIcineCheck();
        
           
        }

        private void m_txtProviderName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_MedIcineCheckReport)objController).m_mthShowVendor(m_txtProviderName.Text);
                
                
                
            }
        }

        private void cmdLocal_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {
            m_dwRpt.Print();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void m_txtProviderName_MouseDown(object sender, MouseEventArgs e)
        {
            ((clsCtl_MedIcineCheckReport)objController).m_mthShowVendor(m_txtProviderName.Text);
        }
    }
}