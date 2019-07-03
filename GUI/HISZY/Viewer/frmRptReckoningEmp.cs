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
    /// 收费员日结报表UI类
    /// </summary>
    public partial class frmRptReckoningEmp : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 报表业务类
        /// </summary>
        private clsCtl_Report objReport;
        /// <summary>
        /// 开始日期
        /// </summary>
        private string BeginDate = "";
        /// <summary>
        /// 结束日期
        /// </summary>
        private string EndDate = "";
        /// <summary>
        /// 是否可以日结
        /// </summary>
        private bool IsAllowRec = false;
        /// <summary>
        /// 监控标志
        /// </summary>
        private bool MonitorFlag = false;
        /// <summary>
        /// 收款员ID
        /// </summary>
        private string EmpID = "";
        /// <summary>
        /// 收款员姓名
        /// </summary>
        private string EmpName = "";
        /// <summary>
        /// 收款员工号
        /// </summary>
        private string EmpCode = "";
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmRptReckoningEmp()
        {
            InitializeComponent();
            objReport = new clsCtl_Report();
        }

        /// <summary>
        /// 外部接口
        /// </summary>
        public void mthShow()        
        {
            MonitorFlag = true;
            this.Show();
        }

        private void frmRptReckoningEmp_Load(object sender, EventArgs e)
        {
            this.dwRep.LibraryList = clsPublic.PBLPath;
            this.dwRep.DataWindowObject = "d_bih_reckoningemp";
            this.dwRep.InsertRow(0);
            dwRep.Modify("t_title.text = '" + this.objReport.HospitalName + "收费员缴款报表'");
            dwRep.Modify("t_dyrq.text = '" + DateTime.Now.ToString("yyyy/MM/dd") + "'");

            BeginDate = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:01";
            EndDate = DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59";

            if (MonitorFlag)
            {
                this.btnStat.Location = this.btnNoReck.Location;
                this.btnNoReck.Location = this.btnReck.Location;                
            }
            else
            {
                this.lblOperCode.Visible = false;
                this.txtOperCode.Visible = false;

                EmpID = this.LoginInfo.m_strEmpID;
                EmpName = this.LoginInfo.m_strEmpName;

                this.m_mthRefresh(BeginDate, EndDate);

                clsPublic.PlayAvi("findFILE.avi", "正在统计未结帐费用，请稍候...");
                this.objReport.m_mthRptReckoningEmp(EmpID, EmpName, false, "", this.dwRep);
                clsPublic.CloseAvi();

                if (this.dwRep.Describe("t_hjje_x.text").Trim() == "")
                {
                    IsAllowRec = false;
                }
                else
                {
                    IsAllowRec = true;
                }
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

        private void btnNoReck_Click(object sender, EventArgs e)
        {
            if (!this.m_blnGetEmpIDName())
            {
                return;
            }

            clsPublic.PlayAvi("findFILE.avi", "正在统计未结帐费用，请稍候...");
            this.objReport.m_mthRptReckoningEmp(EmpID, EmpName, false, "", this.dwRep);
            clsPublic.CloseAvi();

            if (this.dwRep.Describe("t_hjje_x.text").Trim() == "")
            {
                IsAllowRec = false;
                this.btnReck.Enabled = false;
            }
            else
            {
                IsAllowRec = true;
                this.btnReck.Enabled = true;
            }
        }

        private void btnReck_Click(object sender, EventArgs e)
        {
            if (!IsAllowRec)
            {
                MessageBox.Show("没有待日结的费用。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.dwRep.Describe("t_ssrq.text").Trim() != "")
            {
                return;
            }
            
            frmDayReckoningRemark fremark = new frmDayReckoningRemark();
            DialogResult dg = fremark.ShowDialog();
            if (dg == DialogResult.Yes || dg == DialogResult.OK)
            {
                string RemarkInfo = fremark.RemarkInfo;

                if (MessageBox.Show("请再次确认是否日结？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    string RecDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    clsDcl_Charge objCharge = new clsDcl_Charge();
                    long l = objCharge.m_lngDayReckoning(EmpID, RecDate, RemarkInfo);
                    if (l > 0)
                    {
                        this.m_mthRefresh(BeginDate, EndDate);
                        clsPublic.PlayAvi("findFILE.avi", "正在统计结帐费用，请稍候...");
                        this.objReport.m_mthRptReckoningEmp(EmpID, EmpName, true, RecDate, this.dwRep);
                        clsPublic.CloseAvi();
                        this.btnReck.Enabled = false;
                    }
                    else
                    {
                        MessageBox.Show("日结失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        #region 刷新
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>        
        public void m_mthRefresh(string BeginDate, string EndDate)
        {
            if (!this.m_blnGetEmpIDName())
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            DataTable dt;
            clsDcl_Charge objCharge = new clsDcl_Charge();

            long l = objCharge.m_lngGetDayReckoningTime(EmpID, BeginDate, EndDate, out dt);
            if (l > 0)
            {
                this.lvHistory.BeginUpdate();
                this.lvHistory.Items.Clear();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lv = new ListViewItem(Convert.ToString(i + 1));
                    lv.SubItems.Add(dt.Rows[i]["recdate"].ToString().Trim());
                    lv.Tag = dt.Rows[i]["recdate"].ToString().Trim();
                    this.lvHistory.Items.Add(lv);
                }               

                this.lvHistory.EndUpdate();
            }            

            this.Cursor = Cursors.Default;

            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("在指定的时间段内，该收款员没有日帐记录。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 获取收款员ID和姓名
        /// <summary>
        /// 获取收款员ID和姓名
        /// </summary>
        /// <returns></returns>
        public bool m_blnGetEmpIDName()
        {
            bool ret = true;

            if (MonitorFlag)
            {
                if (this.txtOperCode.Text.Trim() == "")
                {
                    MessageBox.Show("请输入收款员工号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.txtOperCode.Focus();
                    return false;
                }
                else
                {
                    if (EmpCode != this.txtOperCode.Text.Trim())
                    {
                        EmpCode = this.txtOperCode.Text.Trim();

                        clsDcl_Charge objCharge = new clsDcl_Charge();
                        long l = objCharge.m_lngGetEmployee(EmpCode, out EmpID, out EmpName);
                        objCharge = null;
                        if (l > 0)
                        {
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        #endregion

        private void lvHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvHistory.SelectedItems.Count == 0)
            {
                return;
            }
            else
            {
                string RecDate = this.lvHistory.SelectedItems[0].Tag.ToString();
                clsPublic.PlayAvi("findFILE.avi", "正在统计结帐费用，请稍候...");
                this.objReport.m_mthRptReckoningEmp(EmpID, EmpName, true, RecDate, this.dwRep);
                clsPublic.CloseAvi();
                this.btnReck.Enabled = false;
            }
        }                    

        private void btnStat_Click(object sender, EventArgs e)
        {
            if (this.dteBegin.Value > this.dteEnd.Value)
            {
                return;
            }
            else
            {
                BeginDate = this.dteBegin.Value.ToString("yyyy-MM-dd") + " 00:00:01";
                EndDate = this.dteEnd.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                this.m_mthRefresh(BeginDate, EndDate);
            }
        }

        private void btnRemark_Click(object sender, EventArgs e)
        {
            if (this.dwRep.RowCount == 0)
            {
                return;
            }

            string EmpID = this.dwRep.GetItemString(1, "col1");
            string RecTime = this.dwRep.GetItemString(1, "col2");
            string Remark = this.dwRep.GetItemString(1, "col3");
            if (RecTime == null || RecTime.Trim() == "")
            {
                //只能对已日结报表修改备注信息
                MessageBox.Show("无备注信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (EmpID != this.LoginInfo.m_strEmpID)
            {
                MessageBox.Show("只有本人才能修改备注信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmDayReckoningRemark f = new frmDayReckoningRemark();
            f.RemarkInfo = Remark;
            f.btnSkip.Visible = false;
            f.btnReturn.Text = "取消(&C)";
            if (f.ShowDialog() == DialogResult.Yes)
            {
                Remark = f.RemarkInfo;
                clsDcl_Charge objCharge = new clsDcl_Charge();
                long l = objCharge.m_lngUpdateDayRecRemark(EmpID, RecTime, Remark);
                if (l > 0)
                {
                    this.dwRep.SetItemString(1, "col3", Remark);
                    //修改备注
                    string remarkinfo_p = "";
                    clsPublic.m_mthConvertNewLineStrLbl(Remark, 50, ref remarkinfo_p);
                    this.dwRep.Modify("t_bz.text = '" + remarkinfo_p + "'"); 
                }
                else
                {
                    MessageBox.Show("修改备注失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
