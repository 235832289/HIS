using System;
using System.Collections.Generic;
using System.Collections;
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
    /// 
    /// </summary>
    public partial class frmRptActualReceiveDetail : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 科室ID数组
        /// </summary>
        private ArrayList DeptIDArr = new ArrayList();
        /// <summary>
        /// 科室名称
        /// </summary>
        private string DeptName = "";
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// PB事务
        /// </summary>
        private Transaction pbTrans;
        #endregion              

        #region 外部接口
        /// <summary>
        /// 自定义报表ID
        /// </summary>
        private string RptID = "0000";
        /// <summary>
        /// 外部Show
        /// </summary>
        /// <param name="ParmVal"></param>
        internal string str_parmval = "";
        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            RptID = ParmVal;
           string[] str_Arr = ParmVal.Split('★');
           if (str_Arr.Length >= 1)
           {
               RptID = str_Arr[0];
           }
            this.Show();
        }
        #endregion


     
        #region 设置报表
        /// <summary>
        /// 设置报表
        /// </summary>
        private void m_mthSetReport()
        {
            this.dwRep.DataWindowObject = null;
            this.dwRep.DataWindowObject = "d_bih_deptincomeentry_cross2";            
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + this.dwRep.Describe("t_title.text") + "'");

            this.dwRep.PrintProperties.Preview = false;
            this.dwRep.SetTransaction(pbTrans);
        }
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmRptActualReceiveDetail()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                if (fDept.DeptIDArr.Count==0)
                {
                    MessageBox.Show("请选择病区！", "系统提示",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (fDept.DeptIDArr.Count >1)
                {
                    MessageBox.Show("实收明细报表只能选择一个病区进行统计！","系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                DeptIDArr = fDept.DeptIDArr;
                DeptName = fDept.DeptName;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.dteRq1.Value.ToString("yyyy-MM-dd"), this.dteRq2.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }
            if (DeptIDArr.Count == 0)
            {
                MessageBox.Show("请选择病区！","系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            
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
                clsPublic.PlayAvi("findFILE.avi", "正在统计科室实收费用明细，请稍候...");
                this.objReport.m_mthRptDeptIncomeEntry(BeginDate, EndDate, DeptIDArr, DeptName, RptID, this.dwRep);
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh(); 
        }

        private void frmRptActualReceiveDetail_Load(object sender, EventArgs e)
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsVolDatawindowToExcel[] volExcl = new clsVolDatawindowToExcel[2];
                volExcl[0] = new clsVolDatawindowToExcel(1);
                volExcl[0].m_firstcommn[0] = "A1";
                volExcl[0].m_endcommn[0] = "ALL";
                volExcl[0].m_title_text[0] = dwRep.Describe("t_title.text");
                volExcl[0].m_rowheight[0] = 20;
                volExcl[0].m_HorizontalAlignment[0] = "0";

                volExcl[1] = new clsVolDatawindowToExcel(2);
                volExcl[1].m_firstcommn[0] = "A1";
                volExcl[1].m_endcommn[0] = "F1";
                volExcl[1].m_title_text[0] = dwRep.Describe("t_ks.text");
                volExcl[1].m_rowheight[0] = 20;
                volExcl[1].m_HorizontalAlignment[0] = "L";

                volExcl[1].m_firstcommn[1] = "G1";
                volExcl[1].m_endcommn[1] = "ALL";
                volExcl[1].m_title_text[1] = dwRep.Describe("t_date.text");
                volExcl[1].m_rowheight[1] = 20;
                volExcl[1].m_HorizontalAlignment[1] = "L";

                clsPublic.ExportDataWindow(this.dwRep, volExcl);
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwRep, true);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPreview_Click_1(object sender, EventArgs e)
        {
            this.dwRep.PrintProperties.Preview = !this.dwRep.PrintProperties.Preview;
            this.dwRep.PrintProperties.ShowPreviewRulers = this.dwRep.PrintProperties.Preview;
        }
    }
}