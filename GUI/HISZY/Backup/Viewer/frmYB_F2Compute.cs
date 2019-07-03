using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 滚费UI类
    /// </summary>
    public partial class frmYB_F2Compute : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 滚费时间
        /// </summary>
        private string CreateTime = "";
        /// <summary>
        /// 定时任务执行时间
        /// </summary>
        private string StartTime = "";
        /// <summary>
        /// 构造
        /// </summary>
        public frmYB_F2Compute()
        {
            InitializeComponent();
        }                     
                
        #region 生成医保统筹费用
        /// <summary>
        /// 生成医保统筹费用
        /// </summary>
        public void m_mthBuild()
        {
            clsPublic.PlayAvi("findFILE.avi", "正在生成医保试算费用，请稍候...");
            string ErrMsg = "";
            try
            {
                ArrayList PayIDArr = clsPublic.m_mthGetYBPayID();

                DataTable dt;
                clsDcl_CommonFind objComm = new clsDcl_CommonFind();
                clsDcl_Charge objCharge = new clsDcl_Charge();

                long l = objComm.m_lngGetBihPatient(out dt);
                if (l > 0)
                {
                    int row = 1;                    
                    this.lvHistory.Items.Clear();
                    clsCtl_YBCharge objYB = new clsCtl_YBCharge();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr = dt.Rows[i];
                        if (PayIDArr.IndexOf(dr["paytypeid_chr"].ToString()) >= 0)
                        {
                            decimal TotalMoney = 0;
                            decimal InsuredMoney = 0;
                            string StrErr = "";

                            if (objYB.m_blnBudget(dr["registerid_chr"].ToString(), dr["zyh"].ToString(), int.Parse(dr["zycs"].ToString()), out TotalMoney, out InsuredMoney, out StrErr))
                            {
                                //更新
                                objCharge.m_lngUpdateInsuredSum(dr["registerid_chr"].ToString(), InsuredMoney);

                                ListViewItem lv = new ListViewItem(row.ToString());

                                lv.SubItems.Add(dr["deptname_vchr"].ToString());
                                lv.SubItems.Add(dr["bed_no"].ToString());
                                lv.SubItems.Add(dr["zyh"].ToString());
                                lv.SubItems.Add(dr["inpatientcount_int"].ToString());
                                lv.SubItems.Add(dr["lastname_vchr"].ToString());
                                lv.SubItems.Add(InsuredMoney.ToString());
                                lv.SubItems.Add("成功");

                                lv.ImageIndex = 0;
                                this.lvHistory.Items.Add(lv);
                                row++;
                            }
                            else
                            {
                                ErrMsg += StrErr + "\r\n\r\n";
                            }
                        }
                    }
                }
            }
            catch
            { }
            finally
            {
                clsPublic.CloseAvi();
                if(ErrMsg.Trim().Length>0)
                {
                    MessageBox.Show("试算失败。" + ErrMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }   
            clsPublic.CloseAvi();
        }
        #endregion

        private void frmAutoCharge_Load(object sender, EventArgs e)
        {            
            StartTime = clsPublic.m_strGetSysparm("0019");                           
        }      

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            this.m_mthBuild();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (StartTime == "")
            {
                if (CreateTime.Substring(11, 8) == "05:00:00")
                {
                    this.m_mthBuild();
                }
            }
            else
            {
                if (CreateTime.Substring(11, 8) == StartTime)
                {
                    this.m_mthBuild();
                }
            }        
        }
    }
}