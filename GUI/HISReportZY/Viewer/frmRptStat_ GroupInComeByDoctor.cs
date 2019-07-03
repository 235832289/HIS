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

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// 功能科室专业组分类报表

    /// </summary>
    public partial class frmRptStat__GroupInComeByDoctor : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 字段
        /// <summary>
        /// 将要跳转的下一个控件

        /// </summary>
        Control m_ctlNext = null;
        /// <summary>
        /// 参与跳转的控件数组

        /// </summary>
        private Control[] m_ctlControlsArr = null;
        /// <summary>
        /// 控件激活标志

        /// </summary>
        private bool m_blnCtlActivate = false;

        /// <summary>
        /// 报表类型 9 按日结时间统计

        /// </summary>
        private int m_intRptType = 0;

        /// <summary>
        /// 自定义报表ID
        /// </summary>
        private string m_strRptID = "";

        /// <summary>
        /// 报表种类--1:主治医生；2：开单医生

        /// </summary>
        private int m_intRptClass = 1;
        /// <summary>
        /// 报表统计条件
        /// </summary>
        private clsGroupInComeByDoctorOrArea_VO objvalue_Param = new clsGroupInComeByDoctorOrArea_VO();

        /// <summary>
        /// 科室ID数组
        /// </summary>
        private ArrayList DeptIDArr = new ArrayList();

        /// <summary>
        /// 科室名称
        /// </summary>
        private string m_strDeptName = string.Empty;
        /// <summary>
        /// PB事务
        /// </summary>
        private Transaction pbTrans;

        #endregion

        #region 构造函数

        public frmRptStat__GroupInComeByDoctor()
        {
            InitializeComponent();
            //clsPublic objPublic = new clsPublic();
            m_ctlControlsArr = new Control[] {m_dtpSearchBeginDate,m_dtpSearchEndDate};
            //设置控件的Enter事件
            m_mthSetNextControl(ref m_ctlControlsArr);
            m_dtpSearchBeginDate.Text = DateTime.Now.ToString("yyyy年MM月dd");
            m_dtpSearchEndDate.Text = DateTime.Now.ToString("yyyy年MM月dd");

            m_mthSelectAllText(panel1);
        }
        #endregion

        #region 事件

        /// <summary>
        /// 窗体的Load事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRptStat__GroupInComeByDoctor_Load(object sender, EventArgs e)
        {

            #region 两层事务处理

            string ServerName = string.Empty;
            string UserID = string.Empty;
            string Pwd = string.Empty;
            clsPublic.m_mthGetICareParm(out ServerName, out UserID, out Pwd);

            pbTrans = new Transaction();
            pbTrans.Dbms = Sybase.DataWindow.DbmsType.Oracle9i;
            pbTrans.ServerName = ServerName;
            pbTrans.UserId = UserID;
            pbTrans.Password = Pwd;
            pbTrans.AutoCommit = true;
            pbTrans.Connect();
            #endregion

            this.m_dwRep.LibraryList = clsPublic.PBLPath;
            //m_dwRep.DataWindowObject = "d_groupincomebydoctor";
            m_dwRep.DataWindowObject = "d_groupincomebyarea";
            if (m_intRptClass == 1)
            {
                this.m_dwRep.Modify("t_title.text = '功能科室专业组分类报表'");
                this.Text = "功能科室专业组分类报表";
            }
            else
            {
                this.m_dwRep.Modify("t_title.text = '功能科室核算实收报表'");
                this.Text = "功能科室核算实收报表";
            }
            m_dwRep.Modify(@"t_area.text = '科室：'");
            m_dwRep.Modify(@"t_date.text = '统计时间： 从 " +
                DateTime.Now.ToString("yyyy-MM-dd") + " 至 " +
                DateTime.Now.ToString("yyyy-MM-dd") + @"'");
            m_dwRep.Modify(@"t_print.text = ''");
            m_dwRep.Modify(@"catsum_t.text = '收费类别'");
            this.m_dwRep.SetTransaction(pbTrans);
            this.m_dwRep.Refresh();

        }

        /// <summary>
        /// 窗体的Shown事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmRptStat__GroupInComeByDoctor_Shown(object sender, EventArgs e)
        {
            m_dtpSearchBeginDate.Focus();
        }

        /// <summary>
        /// 退出按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// 病区按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIDArr = fDept.DeptIDArr;
                string strDeptName = fDept.DeptName.Trim();
                int intIndex = strDeptName.IndexOf(" ");
                if (intIndex == -1)
                {
                    m_strDeptName = strDeptName;
                }
                else
                {
                    m_strDeptName = strDeptName.Substring(0, intIndex);
                }


                m_dwRep.Modify(@"t_area.text = '科室：" + m_strDeptName + @"'");
            }

        }


        /// <summary>
        /// 检索按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnSelect_Click(object sender, EventArgs e)
        {
            if ((m_dtpSearchBeginDate.Text.Trim().Length == 11) && (m_dtpSearchEndDate.Text.Trim().Length == 11))
            {
                if ((Convert.ToDateTime(m_dtpSearchBeginDate.Text)) > (Convert.ToDateTime(m_dtpSearchEndDate.Text)))
                {
                    MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_dtpSearchBeginDate.Focus();
                    return;
                }
                else
                {
                    objvalue_Param.m_strRptID = m_strRptID;

                    if (DeptIDArr != null && DeptIDArr.Count > 0)
                    {
                        objvalue_Param.m_strAreaID = DeptIDArr[0].ToString().Trim();
                    }
                    else
                    {
                        objvalue_Param.m_strAreaID = string.Empty;
                        MessageBox.Show("请输入病区！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }


                    objvalue_Param.m_strSearchBeginDate = Convert.ToDateTime(m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd 00:00:00");
                    objvalue_Param.m_strSearchEndDate = Convert.ToDateTime(m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd 23:59:59");

                    m_dwRep.DataWindowObject = null;
                    m_dwRep.DataWindowObject = "d_groupincomebyarea";
                    m_dwRep.PrintProperties.Preview = false;
                    m_dwRep.SetTransaction(pbTrans);


                    m_mthGetStatData();
                }
            }
            else
            {
                return;
            }
        }



        /// <summary>
        /// 预览按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnPreview_Click(object sender, EventArgs e)
        {
            m_dwRep.PrintProperties.Preview = !m_dwRep.PrintProperties.Preview;

            m_dwRep.PrintProperties.ShowPreviewRulers = m_dwRep.PrintProperties.Preview;//显示预览标尺
            m_dwRep.PrintProperties.PreviewZoom = 100;//缩放比例

        }

        /// <summary>
        /// 导出的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnExport_Click(object sender, EventArgs e)
        {
            if (m_dwRep.RowCount > 0)
            {
                clsPublic.ExportDataWindow(m_dwRep, null);
            }

        }

        /// <summary>
        /// 打印按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            //m_dwRep.Modify(@"t_print.text = '打印时间：" + DateTime.Now.ToString("yyyy-MM-dd") + @"'");
            //m_dwRep.Refresh();
            //m_dwRep.SetRedrawOn();
            clsPublic.ChoosePrintDialog(m_dwRep, true);            
            
        }


        private void m_dtpSearchBeginDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_ctlNext.Focus();
            }

        }

        private void m_dtpSearchEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_ctlNext.Focus();
            }

        }

        #endregion

        #region 方法

        /// <summary>
        /// 建立控制器

        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_ReportZY();
        }

        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        /// <param name="ParmVal"></param>
        public void m_mthShow(string ParmVal,string p_strRptClass)
        {
            m_intRptType = int.Parse(clsPublic.m_strGettoken(ref ParmVal, ";"));
            m_strRptID = clsPublic.m_strGettoken(ref ParmVal, ";");
            int.TryParse(p_strRptClass, out m_intRptClass);
            this.Show();
        }
        #endregion

        #region 设置控件的Enter事件

        /// <summary>
        /// 设置下一个焦点控件


        /// </summary>
        internal void m_mthSetNextControl(ref Control[] p_ctlControls)
        {
            if (p_ctlControls == null)
            {
                return;
            }

            for (int iCtl = 0; iCtl < p_ctlControls.Length; iCtl++)
            {
                p_ctlControls[iCtl].Enter += new EventHandler(clsCtl_Public_Enter);
            }
        }

        /// <summary>
        /// 设定当前控件的下一个控件

        /// </summary>
        /// <param name="sender"></param>
        private void clsCtl_Public_Enter(object sender, EventArgs e)
        {
            int ctlIndex;
            for (ctlIndex = 0; ctlIndex < m_ctlControlsArr.Length; ctlIndex++)
            {
                if (m_ctlControlsArr[ctlIndex].Name == (sender as Control).Name)
                    break;
            }

            if (ctlIndex == m_ctlControlsArr.Length - 1)
                m_ctlNext = m_dtpSearchBeginDate;
            else
                m_ctlNext = m_ctlControlsArr[ctlIndex + 1];

        }

        /// <summary>
        /// 获取统计数据
        /// </summary>
        private void m_mthGetStatData()
        {
            if (m_intRptClass == 1)
            {
                this.m_dwRep.Modify("t_title.text = '功能科室专业组分类报表'");
            }
            else
            {
                this.m_dwRep.Modify("t_title.text = '功能科室核算实收报表'");
            }

            m_dwRep.Modify(@"t_area.text = '科室：" + m_strDeptName + @"'");
            m_dwRep.Modify(@"t_date.text = '统计时间： 从 " +
                Convert.ToDateTime(objvalue_Param.m_strSearchBeginDate).ToString("yyyy-MM-dd") + " 至 " +
                Convert.ToDateTime(objvalue_Param.m_strSearchEndDate).ToString("yyyy-MM-dd") + @"'");
            m_dwRep.SetRedrawOff();
            m_dwRep.Modify(@"t_print.text = ''");
            m_dwRep.Modify(@"t_print.text = '打印时间：" + DateTime.Now.ToString("yyyy-MM-dd") + @"'");
            

            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在进行数据统计，请稍候...");
                ((clsCtl_ReportZY)objController).m_mthGetGroupInComeByDoctor(ref objvalue_Param, m_dwRep, m_intRptType,m_intRptClass);
            }
            finally
            {
                clsPublic.CloseAvi();
                m_dwRep.Refresh();
            }

        }


        #region 文本框全选


        /// <summary>
        /// 文本框全选


        /// </summary>
        /// <param name="p_ctlParent">父控件</param>
        internal void m_mthSelectAllText(System.Windows.Forms.Control p_ctlParent)
        {
            if (p_ctlParent.HasChildren)
            {
                foreach (System.Windows.Forms.Control currentCtl in p_ctlParent.Controls)
                {
                    if (currentCtl is System.Windows.Forms.TextBoxBase)
                    {
                        currentCtl.GotFocus += new EventHandler(currentCtl_GotFocus);
                    }
                }
            }
        }

        private void currentCtl_GotFocus(object sender, EventArgs e)
        {
            if (sender is System.Windows.Forms.TextBoxBase)
                (sender as System.Windows.Forms.TextBoxBase).SelectAll();
        }
        #endregion


        #endregion






        #endregion 方法

    }
}