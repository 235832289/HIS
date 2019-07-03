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
    /// 身份实收分类统计报表
    /// </summary>
    public partial class frmRptPayTypeClass : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmRptPayTypeClass()
        {
            InitializeComponent();

            objReport = new clsCtl_Report();
        }

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
        /// <summary>
        /// 报表标题
        /// </summary>
        private string RptTitle = "住院身份实收分类统计报表";
        /// <summary>
        /// 数据视图
        /// </summary>
        private DataView DV = new DataView();
        /// <summary>
        /// 哈希
        /// </summary>
        private Hashtable HasPay = new Hashtable();
        /// <summary>
        /// 科室(病区)名称
        /// </summary>
        private string DeptName = "全院";
        #endregion              

        #region 获取身份列表
        /// <summary>
        /// 获取身份列表
        /// </summary>
        public void m_mthGetPayTypeList()
        {
            DataTable dt;
            clsDcl_Charge objCharge = new clsDcl_Charge();            
            long l = objCharge.m_lngGetPayTypeInfo(out dt);
            if (l > 0)
            {
                DV = new DataView(dt);

                HasPay.Add("全部", "%");
                HasPay.Add("普通", "0");
                HasPay.Add("公费", "1");
                HasPay.Add("医保", "2");
                HasPay.Add("特困", "3");
                HasPay.Add("离休", "4");
                HasPay.Add("本院", "5");

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    if (!HasPay.ContainsKey(dr["paytypename_vchr"].ToString().Trim()))
                    {
                        HasPay.Add(dr["paytypename_vchr"].ToString().Trim(), dr["paytypeid_chr"].ToString().Trim());
                    }
                }

            }
        }
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
                                  
            this.dwRep.LibraryList = clsPublic.PBLPath;            
            this.dwRep.DataWindowObject = "d_bih_paytypeclass";
            this.dwRep.Modify("t_title.text = '" + RptTitle + "'");

            this.m_mthGetPayTypeList();
            this.cboPayType.SelectedIndex = 0;     
        }
        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="ParmVal"></param>
        internal string str_parmval = "";
        public void m_mthShow(string ParmVal)
        {
            str_parmval = ParmVal;
            this.Show();
        }
        #endregion
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
            this.dwRep.DataWindowObject = "d_bih_paytypeclass";
            this.dwRep.Modify("t_title.text = '" + RptTitle + "'");
            this.dwRep.Modify("t_dept.text = '科室：" + DeptName + "'");
            this.dwRep.Modify("t_paytype.text = '身份：" + this.cboPayTypeID.Text + "'"); 
            this.dwRep.PrintProperties.Preview = false;
            this.dwRep.SetTransaction(pbTrans);

            string SubPayTypeID = "";
            string PayTypeName = this.cboPayTypeID.Text.Trim();
            if (this.cboPayType.SelectedIndex == 0)
            {
                if (PayTypeName != "全部")
                {                   
                    DV.RowFilter = "internalflag_int = " + HasPay[PayTypeName].ToString();

                    for (int i = 0; i < DV.Count; i++)
                    {
                        DataRow dr = DV[i].Row;

                        SubPayTypeID += "a.paytypeid_chr = '" + dr["paytypeid_chr"].ToString() + "' or ";                        
                    }

                    SubPayTypeID = SubPayTypeID.Trim();
                    SubPayTypeID = " and (" + SubPayTypeID.Substring(0, SubPayTypeID.Length - 2) + ")";
                }
            }
            else if (this.cboPayType.SelectedIndex == 1)
            {                
                SubPayTypeID = " and a.paytypeid_chr = '" + HasPay[PayTypeName].ToString() + "' ";                
            }

            this.objReport.m_mthRptPayTypeClass(BeginDate, EndDate, SubPayTypeID, DeptIDArr, this.dwRep);
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

                volExcel[1] = new clsVolDatawindowToExcel(3);
                volExcel[1].m_rowheight[0] = 20;
                volExcel[1].m_title_text[0] = this.dwRep.Describe("t_dept.text");
                volExcel[1].m_HorizontalAlignment[0] = "L";
                volExcel[1].m_firstcommn[0] = "B1";
                volExcel[1].m_endcommn[0] = "D1";

                volExcel[1].m_rowheight[1] = 20;
                volExcel[1].m_title_text[1] = this.dwRep.Describe("t_paytype.text");
                volExcel[1].m_HorizontalAlignment[0] = "L";
                volExcel[1].m_firstcommn[1] = "D1";
                volExcel[1].m_endcommn[1] = "E1";

                volExcel[1].m_rowheight[2] = 20;
                volExcel[1].m_title_text[2] = this.dwRep.Describe("t_date.text");
                volExcel[1].m_HorizontalAlignment[2] = "L";
                volExcel[1].m_firstcommn[2] = "F1";
                volExcel[1].m_endcommn[2] = "ALL";

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

        private void cboPayType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cboPayTypeID.Items.Clear();

            if (this.cboPayType.SelectedIndex == 0)
            {
                this.cboPayTypeID.Items.Add("全部");
                this.cboPayTypeID.Items.Add("普通");
                this.cboPayTypeID.Items.Add("公费");
                this.cboPayTypeID.Items.Add("医保");
                this.cboPayTypeID.Items.Add("特困");
                this.cboPayTypeID.Items.Add("离休");
                this.cboPayTypeID.Items.Add("本院");               
            }
            else if (this.cboPayType.SelectedIndex == 1)
            {
                DV.RowFilter = "1=1";
                for (int i = 0; i < DV.Count; i++)
                {
                    DataRow dr = DV[i].Row;

                    this.cboPayTypeID.Items.Add(dr["paytypename_vchr"].ToString().Trim());
                }
            }

            if (this.cboPayTypeID.Items.Count > 0)
            {
                this.cboPayTypeID.SelectedIndex = 0;
            }
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIDArr = fDept.DeptIDArr;
                DeptName = fDept.DeptName;
            }
        }                       
    }
}