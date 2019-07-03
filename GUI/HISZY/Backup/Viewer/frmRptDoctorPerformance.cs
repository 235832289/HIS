using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 住院医生绩效统计报表
    /// </summary>
    public partial class frmRptDoctorPerformance : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmRptDoctorPerformance()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        #region 外部接口    
        /// <summary>
        /// 报表类型 9 按日结时间统计
        /// </summary>
        private int RptType = 0;       
        /// <summary>
        /// 外部Show
        /// </summary>
        /// <param name="ParmVal"></param>
        public void m_mthShow(string ParmVal)     
        {
            RptType = int.Parse(ParmVal);          
            this.Show();
        }

        private string m_strRptID = "";
        private Dictionary<string, decimal> m_objGroup;

        /// <summary>
        /// 外部接口
        /// </summary>
        /// <param name="ParmVal"></param>
        /// <param name="RptID"></param>
        /// <param name="strTmp"></param>
        public void m_mthShowWithParm(string RptID, string strTmp)
        {
            this.m_strRptID = RptID;

            string[] strGroup = strTmp.Split('+');
            m_objGroup = new Dictionary<string, decimal>(strGroup.Length);
            string[] strItem = null;
            for (int i1 = 0; i1 < strGroup.Length; i1++)
            {
                strItem = strGroup[i1].Split('*');
                m_objGroup.Add(strItem[0], decimal.Parse(strItem[1]));
            }
            this.Show();

        }
        #endregion

        #region 变量
        /// <summary>
        /// 报表业务类

        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// 药费发票分类
        /// </summary>
        private string MedCatArr = "";
        /// <summary>
        /// 医生ID串
        /// </summary>
        private string DoctIDArr = "";
        /// <summary>
        /// 选择状态
        /// </summary>
        private bool SelectStatus = false;

        /// <summary>
        /// 抗菌药分类ID
        /// </summary>
        private string KangJunArr = "";

        /// <summary>
        ///  基本药分类ID
        /// </summary>
        private string JiBenArr = "";
        #endregion              

        private void frmRptDoctorPerformance_Load(object sender, EventArgs e)
        {                                            
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_doctorperformance";            
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + this.dwRep.Describe("t_title.text") + "'");

            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");

            //获取药费发票分类
            ArrayList CatArr = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("0020"), ";");
            for (int i = 0; i < CatArr.Count; i++)
            {
                MedCatArr += "'" + CatArr[i].ToString() + "',";
            }
            if (MedCatArr.Length > 0)
            {
                MedCatArr = MedCatArr.Substring(0, MedCatArr.Length - 1);
            }

            //获取药费抗菌分类
            ArrayList KJArr = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("3068"), "*");
            for (int i = 0; i < KJArr.Count; i++)
            {
                KangJunArr += "'" + KJArr[i].ToString() + "',";
            }
            if (KangJunArr.Length > 0)
            {
                KangJunArr = KangJunArr.Substring(0, KangJunArr.Length - 1);
            }

            //获取药费基本分类
            ArrayList JBArr = clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("3069"), "*");
            for (int i = 0; i < JBArr.Count; i++)
            {
                JiBenArr += "'" + JBArr[i].ToString() + "',";
            }
            if (JiBenArr.Length > 0)
            {
                JiBenArr = JiBenArr.Substring(0, JiBenArr.Length - 1);
            }


            this.cboDoct.SelectedIndex = 0;
            this.cboType.SelectedIndex = 0;
        }                   

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");
            int FeeType = this.cboType.SelectedIndex + 1;

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {                
                clsPublic.PlayAvi("findFILE.avi", "统计需要较长时间，请稍候...");
                this.objReport.m_mthRptDoctorPerformance(BeginDate, EndDate, this.LoginInfo.m_strEmpName, DoctIDArr, MedCatArr,KangJunArr, JiBenArr, FeeType,
                                                        this.dwRep, this.m_strRptID, this.m_objGroup);                
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();  
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwRep, null);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnDoct_Click(object sender, EventArgs e)
        {
            this.m_mthChooseDoctor();

            if (this.DoctIDArr != "")
            {
                SelectStatus = true;
                this.cboDoct.SelectedIndex = 1;
            }
        }

        #region 选择医生
        /// <summary>
        /// 选择医生
        /// </summary>
        private void m_mthChooseDoctor()
        {
            frmAidChooseDoct fDoct = new frmAidChooseDoct();
            if (fDoct.ShowDialog() == DialogResult.OK)
            {
                DoctIDArr = fDoct.DoctIDArr;               
            }
        }
        #endregion

        private void cboDoct_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectStatus)
            {                
                SelectStatus = false;
            }
            else
            {
                this.DoctIDArr = "";
                if (this.cboDoct.SelectedIndex == 1)
                {
                    this.m_mthChooseDoctor();
                }
            }
        }
    }
}