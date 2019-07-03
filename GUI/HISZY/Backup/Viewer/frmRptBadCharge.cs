using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sybase.DataWindow;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 呆帐结算统计UI
    /// </summary>
    public partial class frmRptBadCharge : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmRptBadCharge()
        {
            InitializeComponent();

            objReport = new clsCtl_Report();
        }

        #region 外部接口
        /// <summary>
        /// 自定义报表ID
        /// </summary>
        private string RptID = "";
        /// <summary>
        /// 外部Show
        /// </summary>
        /// <param name="ParmVal"></param>
        public void m_mthShow(string ParmVal)
        {
            RptID = ParmVal;            
            this.Show();
        }
        #endregion

        #region 变量
        /// <summary>
        /// 科室ID数组
        /// </summary>
        private ArrayList DeptIDArr = new ArrayList();        
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// PB事务
        /// </summary>
        private Transaction pbTrans;
        #endregion              

        #region 设置报表
        /// <summary>
        /// 设置报表
        /// </summary>
        private void m_mthSetReport()
        {
            this.dwRep.DataWindowObject = null;
            this.dwRep.DataWindowObject = "d_bih_badcharge";            
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + this.dwRep.Describe("t_title.text") + "'");

            this.dwRep.PrintProperties.Preview = false;
            this.dwRep.SetTransaction(pbTrans);
        }
        #endregion

        private void frmRptBadCharge_Load(object sender, EventArgs e)
        {
            #region 两层事务处理，稍后改回三层。

            string ServerName = "";
            string UserID = "";
            string Pwd = "";
            clsPublic.m_mthGetICareParm(out ServerName, out UserID, out Pwd);

            pbTrans = new Transaction();
            pbTrans.Dbms = Sybase.DataWindow.DbmsType.Oracle9i;            
            pbTrans.ServerName = ServerName;
            pbTrans.UserId = UserID;
            pbTrans.Password = Pwd;
            pbTrans.AutoCommit = true;
            pbTrans.Connect();
            #endregion
                                 
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.m_mthSetReport();                            
        } 

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIDArr = fDept.DeptIDArr;
            }
        }               

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                this.m_mthSetReport();
                clsPublic.PlayAvi("findFILE.avi", "正在统计费用信息，请稍候...");
                this.objReport.m_mthRptBadCharge(BeginDate, EndDate, RptID, DeptIDArr, this.dwRep);
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
                clsVolDatawindowToExcel[] volExcel = new clsVolDatawindowToExcel[2];
                volExcel[0] = new clsVolDatawindowToExcel(1);
                volExcel[0].m_firstcommn[0] = "A1";
                volExcel[0].m_endcommn[0] = "ALL";
                volExcel[0].m_title_text[0] = this.dwRep.Describe("t_title.text");
                volExcel[0].m_HorizontalAlignment[0] = "0";
                volExcel[0].m_rowheight[0] = 20;

                volExcel[1] = new clsVolDatawindowToExcel(1);
                volExcel[1].m_firstcommn[0] = "A1";
                volExcel[1].m_endcommn[0] = "ALL";
                volExcel[1].m_title_text[0] = this.dwRep.Describe("t_date.text");
                volExcel[1].m_HorizontalAlignment[0] = "L";
                volExcel[1].m_rowheight[0] = 20;

                clsPublic.ExportDataWindow(this.dwRep, volExcel);
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
    }
}