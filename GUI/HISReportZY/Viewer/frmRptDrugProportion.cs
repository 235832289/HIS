using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmRptDrugProportion : Form
    {
        public frmRptDrugProportion()
        {
            InitializeComponent();
        }


        private ArrayList DeptIDArr = new ArrayList();
        private static clsLogText log = null;
        private static string strFileName = string.Empty;

        private string MedCatArr = string.Empty;
        private string KangJunArr = string.Empty;
        private string JiBenArr = string.Empty;
        private string ClArr = string.Empty;

        #region 方法

        void init()
        {
            ArrayList lstMedCatArr = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("0020"), ";");
            for (int i = 0; i < lstMedCatArr.Count; i++)
            {
                this.MedCatArr = this.MedCatArr + "'" + lstMedCatArr[i].ToString() + "',";
            }
            if (this.MedCatArr.Length > 0)
            {
                this.MedCatArr = this.MedCatArr.Substring(0, this.MedCatArr.Length - 1);
            }
            ArrayList lstKangJunArr = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("3068"), "*");
            for (int i = 0; i < lstKangJunArr.Count; i++)
            {
                this.KangJunArr = this.KangJunArr + "'" + lstKangJunArr[i].ToString() + "',";
            }
            if (this.KangJunArr.Length > 0)
            {
                this.KangJunArr = this.KangJunArr.Substring(0, this.KangJunArr.Length - 1);
            }
            ArrayList lstJiBenArr = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("3069"), "*");
            for (int i = 0; i < lstJiBenArr.Count; i++)
            {
                this.JiBenArr = this.JiBenArr + "'" + lstJiBenArr[i].ToString() + "',";
            }
            if (this.JiBenArr.Length > 0)
            {
                this.JiBenArr = this.JiBenArr.Substring(0, this.JiBenArr.Length - 1);
            }
            ArrayList lstClArr = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("3070"),"*");
            for (int i = 0; i < lstClArr.Count; i++)
            {
                this.ClArr = this.ClArr + "'" + lstClArr[i].ToString() + "',";
            }
            if (this.ClArr.Length > 0)
            {
                this.ClArr = this.ClArr.Substring(0, this.ClArr.Length - 1);
            }
        }


        void logOut(string txtStr)
        {
            log.Log2File(strFileName, txtStr);
        }
        #endregion

        #region  事件
        private void frmRptDrugProportion_Load(object sender, EventArgs e)
        {

            this.dwRep.LibraryList = Application.StartupPath + "\\pbreport.pbl";
            this.dwRep.DataWindowObject = "d_bih_proportion";

            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");

            log = new clsLogText();
            strFileName = Application.StartupPath + "\\log" + "\\log.txt";
        }

        private void btnDept_Click(object sender, EventArgs e)
        {

        }

        private void btnSelect_Click(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {

        }

        private void btnExport_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        #endregion

    }
}
