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
    ///病人入院单统计表　liuyingrui 2005-05-08
    /// </summary>
    public partial class frmBIHRegisterStatistics : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        public int m_intStartTime = 0;
        public int m_intEndTime = 0;
        
        //统计类型 0 入院 1 出院
        private string showType = "0";
        
        public frmBIHRegisterStatistics()
        {
            InitializeComponent();
        }
       
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_BIHRegisterStatistics();
            objController.Set_GUI_Apperance(this);
        }
        internal string str_parmval = "0";

        public void showWith(string type)
        {
            
            this.showType = type;
            str_parmval = type;
            string[] strArr = type.Split('★');
            if (strArr.Length >= 1)
            {
                this.showType = strArr[0];
            }

            this.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmBIHRegisterStatistics_Load(object sender, EventArgs e)
        {
            this.m_dtpStatDate.Focus();
            // add 2007-4-18
            ((clsCtl_BIHRegisterStatistics)objController).m_FillCboPatientType();
        }

        private void btnGenerRpt_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.m_dtpStatDate.Value.ToString("yyyy-MM-dd"), this.m_dtpEnd.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }
            if (this.showType == "1")
            {
                ((clsCtl_BIHRegisterStatistics)objController).m_mthShowBIHLeftStatistics();
            }
            else
            {
                ((clsCtl_BIHRegisterStatistics)objController).m_mthShowBIHStatistics();
            }
            
            this.btnPrintRpt.Focus();
        }

        private void btnPrintRpt_Click(object sender, EventArgs e)
        {
            ((clsCtl_BIHRegisterStatistics)objController).m_mthPrintReportDoc();
        }

        private void m_dtpStatDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_intStartTime++;
                switch (m_intStartTime)
                {
                    case 1: SendKeys.Send("{right}"); break;
                    case 2: SendKeys.Send("{right}"); break;
                    case 3: this.m_dtpEnd.Focus(); break;
                    default: m_intStartTime = 0; break;
                }
      
  
            }
        }

        private void m_dtpEnd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_intEndTime++;
                switch (m_intEndTime)
                {
                    case 1: SendKeys.Send("{right}"); break;
                    case 2: SendKeys.Send("{right}"); break;
                    case 3: this.btnGenerRpt.Focus(); break;
                    default: m_intEndTime = 0; break;
                }


            }
        }
    }
}