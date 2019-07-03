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
    /// 出院医保统计报表
    /// </summary>
    public partial class frmRptYBOutSum : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造

        /// </summary>
        public frmRptYBOutSum()
        {
            InitializeComponent();

            objReport = new clsCtl_Report();
        }

        #region 变量
        /// <summary>
        /// 报表业务类

        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// PB事务
        /// </summary>
        private Transaction pbTrans;
        /// <summary>
        /// 科室ID数组
        /// </summary>
        private string DeptIDArr;
        /// <summary>
        /// 选择状态

        /// </summary>
        private bool SelectStatus = false;
        /// <summary>
        /// 医生默认科室
        /// </summary>
        private string DoctDefaultDeptID = "";
        #endregion     
        
        #region 外部接口
        /// <summary>
        /// 自定义报表ID
        /// </summary>
        private string RptID = "0000";
        /// <summary>
        /// 查询范围 0 不作限制 1 限制
        /// </summary>
        private string QueryScope = "0";
        /// <summary>
        /// 外部Show
        /// </summary>
        /// <param name="ParmVal"></param>
        //public void m_mthShow(string ParmVal)
        //{
        //    RptID = ParmVal;
        //    this.Show();
        //}
        /// <summary>
        /// 外部Show
        /// </summary>
        /// <param name="p_strRptCode"></param>
        /// <param name="p_strScope"></param>
        public void m_mthShow(string p_strRptID, string p_strScope)
        {
            RptID = p_strRptID;
            QueryScope = p_strScope;
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
            this.dwRep.DataWindowObject = "d_bih_yboutsum";            
            this.dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + this.dwRep.Describe("t_title.text") + "'");

            this.dwRep.PrintProperties.Preview = false;
            this.dwRep.SetTransaction(pbTrans);
        }
        #endregion
             
        private void frmRptYBOutSum_Load(object sender, EventArgs e)
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
            
            this.dteRq1.Value = Convert.ToDateTime(DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-01");

            this.cboDept.SelectedIndex = 0;
            this.cboDiseaseType.SelectedIndex = 0;

            if (this.QueryScope == "1")
            {
                for (int i = 0; i < this.objReport.objDeptIDArr.Count; i++)
                {
                    DoctDefaultDeptID += "'" + this.objReport.objDeptIDArr[i].ToString() + "',";
                }
                if (DoctDefaultDeptID.Trim() != "")
                {
                    DoctDefaultDeptID = DoctDefaultDeptID.Substring(0, DoctDefaultDeptID.Length - 1);
                }
            }
            this.lsvYB.BeginUpdate();
            DataTable dt = this.objReport.m_dtGetAllYBType();
            DataRow dr = null;
            for (int i1 = 0; i1 < dt.Rows.Count; i1++)
            {
                dr = dt.Rows[i1];
                ListViewItem tmpItem = new ListViewItem();
                tmpItem.Tag = dr;
                tmpItem.Text = dr["paytypename_vchr"].ToString();
                tmpItem.Checked = false;
                this.lsvYB.Items.Add(tmpItem);
            }
            this.lsvYB.EndUpdate();
            this.lsvYB.Height = 0;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.lsvYB.Height = 0;
            string strFilter = "";
            DataRow dr;
            foreach (ListViewItem obj in this.lsvYB.Items)
            {
                if (obj.Checked == true)
                {
                    dr = obj.Tag as DataRow;
                    if (dr["paytypeid_chr"].ToString() == "-1")
                    {
                        strFilter = "";
                        break;
                    }
                    strFilter += "'" + dr["paytypeid_chr"].ToString() + "',";
                }
            }
            if (strFilter.Trim().Length != 0)
            {
                strFilter = strFilter.TrimEnd(',');
                strFilter = "and a.paytypeid_chr in (" + strFilter + ")";
            }

            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int DiseaseType = this.cboDiseaseType.SelectedIndex;

            try
            {
                this.m_mthSetReport();

                if (this.QueryScope == "1")
                {
                    if (this.DoctDefaultDeptID.Trim() == "")
                    {
                        return;
                    }

                    if (this.DeptIDArr.Trim() == "")
                    {
                        this.DeptIDArr = this.DoctDefaultDeptID;
                    }
                }

                clsPublic.PlayAvi("findFILE.avi", "正在统计医保费用信息，请稍候...");
                this.objReport.m_mthRptYBOutSum(BeginDate, EndDate, RptID, DeptIDArr, DiseaseType, this.dwRep, strFilter);
            }
            finally
            {
                clsPublic.CloseAvi();
            }
            this.dwRep.Refresh();          
        }              

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount > 0)
            {
                clsVolDatawindowToExcel[] volExcel = new clsVolDatawindowToExcel[2];

                volExcel[0] = new clsVolDatawindowToExcel(1);
                volExcel[0].m_rowheight[0] = 20;
                volExcel[0].m_title_text[0] = this.dwRep.Describe("t_title.text");
                volExcel[0].m_HorizontalAlignment[0] = "0";
                volExcel[0].m_firstcommn[0] = "A1";
                volExcel[0].m_endcommn[0] = "ALL";

                volExcel[1] = new clsVolDatawindowToExcel(2);
                volExcel[1].m_rowheight[0] = 20;
                volExcel[1].m_title_text[0] = this.dwRep.Describe("t_date.text");
                volExcel[1].m_HorizontalAlignment[0] = "L";
                volExcel[1].m_firstcommn[0] = "B1";
                volExcel[1].m_endcommn[0] = "D1";

                volExcel[1].m_rowheight[1] = 20;
                volExcel[1].m_title_text[1] = "打印时间：" + DateTime.Now.ToString("yyyy年MM月dd日");
                volExcel[1].m_HorizontalAlignment[1] = "L";
                volExcel[1].m_firstcommn[1] = "F1";
                volExcel[1].m_endcommn[1] = "ALL";

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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 选择科室
        /// <summary>
        /// 选择科室
        /// </summary>
        private void m_mthChooseDept()
        {
            frmAidChooseDept fDept = null;
            if (this.QueryScope == "1" && this.DoctDefaultDeptID.Trim() != "")
            {
                fDept = new frmAidChooseDept(this.objReport.objDeptIDArr);
            }
            else
            {
                fDept = new frmAidChooseDept();
            }
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIDArr = fDept.DeptIDArr;
            }
        }
        #endregion

        private void btnDept_Click(object sender, EventArgs e)
        {
            this.m_mthChooseDept();

            if (this.DeptIDArr != "")
            {
                SelectStatus = true;
                this.cboDept.SelectedIndex = 1;
            }
        }

        private void cboDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SelectStatus)
            {
                SelectStatus = false;
            }
            else
            {
                this.DeptIDArr = "";
                if (this.cboDept.SelectedIndex == 1)
                {
                    this.m_mthChooseDept();
                }
            }
        }

        private void cmdYB_Click(object sender, EventArgs e)
        {
            this.lsvYB.Height = 270;
        }

        private void lsvYB_Leave(object sender, EventArgs e)
        {
            this.lsvYB.Height = -1;
        }              
    }
}