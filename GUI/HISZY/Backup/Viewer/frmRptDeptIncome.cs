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
    /// 科室收入UI
    /// </summary>
    public partial class frmRptDeptIncome : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造

        /// </summary>
        public frmRptDeptIncome()
        {
            InitializeComponent();

            objReport = new clsCtl_Report();
        }

        #region 外部接口
        /// <summary>
        /// 报表类型 1 开单科室实收 2 执行科室实收
        /// </summary>
        private int RptType = 0;
        /// <summary>
        /// 自定义报表ID
        /// </summary>
        private string RptID = "";
        /// <summary>
        /// 表头
        /// </summary>
        private string RptTitle = "";
        /// <summary>
        /// 报表格式类型 1 正常 2 横向变纵向
        /// </summary>
        private string RptStyle = "1";
        /// <summary>
        /// 外部Show
        /// </summary>
        /// <param name="ParmVal"></param>
        internal string str_parmval = "";
        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            string[] str_Arr = ParmVal.Split('★');
            if (str_Arr.Length >= 1)
            {
                RptType = int.Parse(clsPublic.m_strGettoken(ref str_Arr[0], ";"));
                RptID = clsPublic.m_strGettoken(ref str_Arr[0], ";");
                RptStyle = clsPublic.m_strGettoken(ref str_Arr[0], ";");
                if (RptStyle != "1" && RptStyle != "2")
                {
                    RptStyle = "1";
                }
            }

            
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

        private void frmRptDeptIncome_Load(object sender, EventArgs e)
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
                        
             if (RptType == 0 || RptType == 90)
            {
                RptTitle = "住院科室实收分类统计报表";
            }
            else if (RptType == 1 || RptType == 91)
            {
                RptTitle = "住院开单科室实收分类统计报表";
            }
            else if (RptType == 2 || RptType == 92)
            {
                RptTitle = "住院执行科室实收分类统计报表";
            }
            else if (RptType == 3)
            {
                RptTitle = "住院科室业务收入分类统计报表";
            }
            else if (RptType == 4)
            {
                RptTitle = "在院病人欠费统计报表";
            }
            else if (RptType == 5)
            {
                RptTitle = "开单科室业务收入分类统计报表";
            }
            else if (RptType == 6)
            {
                RptTitle = "执行科室业务收入分类统计报表";
            }

            this.Text = RptTitle;
                        
            this.dwRep.LibraryList = clsPublic.PBLPath;
            if (RptType == 0 || RptType == 3 || RptType == 4 || RptType == 90)
            {
                if (this.RptStyle == "1")
                {
                    this.dwRep.DataWindowObject = "d_bih_deptincome_all";
                }
                else if (this.RptStyle == "2")
                {
                    this.dwRep.DataWindowObject = "d_bih_deptincome_direction";
                }
            }
            else if (RptType == 5 || RptType == 6)
            {
                this.dwRep.DataWindowObject = "d_bih_deptincome_all";
            }
            else
            {
                this.dwRep.DataWindowObject = "d_bih_deptincome";
            }
            this.dwRep.Modify("t_title.text = '" + RptTitle + "'");                                
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
            if (!clsPublic.m_blnCheckDateRange(str_parmval, this.dteRq1.Value.ToString("yyyy-MM-dd"), this.dteRq2.Value.ToString("yyyy-MM-dd")))
            {
                return;
            }

            
            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }                          

            clsPublic.PlayAvi("findFILE.avi", "正在统计费用数据，请稍候...");
            this.dwRep.DataWindowObject = null;
            if (RptType == 0 || RptType == 3 || RptType == 4 || RptType == 90)
            {
                if (this.RptStyle == "1")
                {
                    this.dwRep.DataWindowObject = "d_bih_deptincome_all";
                }
                else if (this.RptStyle == "2")
                {
                    this.dwRep.DataWindowObject = "d_bih_deptincome_direction";
                }
            }
            else if (RptType == 5 || RptType == 6)
            {
                this.dwRep.DataWindowObject = "d_bih_deptincome_all";
            }
            else
            {
                this.dwRep.DataWindowObject = "d_bih_deptincome";
            }
            this.dwRep.Modify("t_title.text = '" + RptTitle + "'");
            this.dwRep.PrintProperties.Preview = false;
            this.dwRep.SetTransaction(pbTrans);            
            this.objReport.m_mthRptDeptIncome(RptType, RptID, RptStyle, BeginDate, EndDate, DeptIDArr, this.dwRep);
            clsPublic.CloseAvi();

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
                volExcel[0].m_rowheight[0] = 20;
                volExcel[0].m_title_text[0] = this.dwRep.Describe("t_title.text");
                volExcel[0].m_HorizontalAlignment[0] = "0";
                volExcel[0].m_firstcommn[0] = "A1";
                volExcel[0].m_endcommn[0] = "ALL";

                volExcel[1] = new clsVolDatawindowToExcel(1);
                volExcel[1].m_rowheight[0] = 20;
                volExcel[1].m_title_text[0] = this.dwRep.Describe("t_date.text");
                volExcel[1].m_HorizontalAlignment[0] = "L";
                volExcel[1].m_firstcommn[0] = "B1";
                volExcel[1].m_endcommn[0] = "ALL";

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