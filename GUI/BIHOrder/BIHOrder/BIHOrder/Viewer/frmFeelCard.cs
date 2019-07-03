using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;



namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmFeelCard : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        /// <summary>
        /// 打印的医嘱项目
        /// </summary>
        private clsBIHCanExecOrder[] arrExec; 

        public frmFeelCard()
        {
            InitializeComponent();
        }

        public frmFeelCard(clsBIHCanExecOrder[] arr)
        {
            arrExec = arr;
            InitializeComponent();
        }

        private void frmFeelCard_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dw_1.Reset();
            int newRow; 
            //DateTime executedate_dat, INPATIENT_DAT;
            //dw_1.Modify("area_name.text='" + this.LoginInfo.m_strInpatientAreaName + "'");
            //dw_1.Modify("execute_dat.text='" + DateTime.Now.ToString("yyyy.MM.dd") + "'");

            for (int i = 0; i < arrExec.Length; i++)
            {
                newRow = dw_1.InsertRow();
                dw_1.SetItemString(newRow, "area", arrExec[i].m_strCURAREAName);
                dw_1.SetItemString(newRow, "bed", arrExec[i].m_strCURBEDName);
                dw_1.SetItemString(newRow, "name", arrExec[i].m_strPatientName);
                dw_1.SetItemString(newRow, "sex", arrExec[i].m_strPatientSex);
                dw_1.SetItemString(newRow, "itemname", arrExec[i].m_strName);
                if (arrExec[i].m_intFEEL_INT == 2)
                {
                    dw_1.SetItemString(newRow, "feel1", "1");
                    //dw_1.SetItemString(newRow, "feel2", "0");
                }
                else if (arrExec[i].m_intFEEL_INT == 1)
                {
                    //dw_1.SetItemString(newRow, "feel1", "0");
                    dw_1.SetItemString(newRow, "feel2", "1");
                }
                
         
            }


            dw_1.AcceptText();
            //dw_1.Sort();
            //dw_1.CalculateGroups();
            //dw_1.Visible = true;
        }

        private void m_cmdPrintFeel_Click(object sender, EventArgs e)
        {
            try
            {
                DWPrintPreview printPreview = new DWPrintPreview(dw_1);
                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            try
            {
                dw_1.PrintDialog();
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
            
        }

    }
}