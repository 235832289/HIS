using System;
using System.IO;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.GUI_Base; 
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_OPSApply : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        private clsDcl_DoctorWorkstation objSvc;       
        public clsCtl_OPSApply()
        {
            objSvc = new clsDcl_DoctorWorkstation();            
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmOPSApply m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOPSApply)frmMDI_Child_Base_in;
        }
        #endregion

        #region 变量
        /// <summary>
        /// 科室数组
        /// </summary>
        string[,] strDeptArr = null;
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void m_mthInit()
        {
            string Hospitalname = new com.digitalwave.iCare.common.clsCommmonInfo().m_strGetHospitalTitle();
            this.m_objViewer.lblAppTitle.Text = Hospitalname + "门诊手术申请单";           

            this.m_mthGetDepartment();

            m_mthSetTextBoxControlsBackColor(new Control[] { this.m_objViewer.txtAppYear, this.m_objViewer.txtAppMonth, this.m_objViewer.txtAppDay, this.m_objViewer.txtAppHour, this.m_objViewer.txtAppMinute, this.m_objViewer.txtAppHint });
        }
        #endregion

        #region 清空表单
        /// <summary>
        /// 清空表单
        /// </summary>
        /// <param name="Control"></param>
        public void m_mthClear(Control Ctl)
        {
            string Type = Ctl.GetType().FullName;

            if (Ctl.AccessibleName.Trim().ToUpper().StartsWith("T"))
            {
                switch (Type)
                {
                    case "System.Windows.Forms.TextBox":
                        Ctl.Text = "";
                        break;
                    case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                        Ctl.Text = "";
                        break;
                }
            }

            foreach (Control Ctlchild in Ctl.Controls)
            {
                m_mthClear(Ctlchild);
            }
        }
        #endregion

        //#region 查找
        ///// <summary>
        ///// 查找
        ///// </summary>
        //public void m_mthFind()
        //{
        //    int pos = 0;
        //    string deptid = this.m_objViewer.cboDept.Text;            
        //    if (deptid != "")
        //    {
        //        pos = deptid.IndexOf("]");
        //        deptid = deptid.Substring(1, pos - 1);
        //    }

        //    string year = this.m_objViewer.txtAppYear.Text.Trim();
        //    if (year.Length != 4)
        //    {
        //        MessageBox.Show("年份为4位数，如2006 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }

        //    string bookingdate = this.m_mthGetbookingdate();
             
        //    bool b = Microsoft.VisualBasic.Information.IsDate(bookingdate);
        //    if(!b)
        //    {
        //        MessageBox.Show("预约时间输入错误，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //        return;
        //    }

        //    this.m_objViewer.lvPatlist.BeginUpdate();
        //    this.m_objViewer.lvPatlist.Items.Clear();

        //    DataTable dtRecord = new DataTable();
        //    long ret = objSvc.m_lngGetOPSApply(out dtRecord, bookingdate, deptid, 0, 1);
        //    if (ret > 0 && dtRecord.Rows.Count > 0)
        //    {
        //        int rowno = 0;
        //        string statusid = "", statusname = "";
        //        DateTime dteBirth; 
        //        string age = "";
        //        for (int i = 0; i < dtRecord.Rows.Count; i++)
        //        {
        //            rowno = i + 1;
        //            ListViewItem lv = new ListViewItem(rowno.ToString());
        //            //状态
        //            statusid = dtRecord.Rows[i]["status_int"].ToString();
        //            switch (statusid)
        //            {
        //                case "0":
        //                    statusname = "新建";
        //                    break;
        //                case "1":
        //                    statusname = "已确认";
        //                    lv.BackColor = Color.FromArgb(0, 200, 0);
        //                    break;
        //                case "2":
        //                    statusname = "退回";
        //                    lv.BackColor = Color.FromArgb(200, 0, 0);
        //                    break;
        //            }
        //            lv.SubItems.Add(statusname);
        //            //申请单号
        //            lv.SubItems.Add(dtRecord.Rows[i]["applyid_vchr"].ToString());
        //            //姓名
        //            lv.SubItems.Add(dtRecord.Rows[i]["name_vchr"].ToString());
        //            //性别
        //            lv.SubItems.Add(dtRecord.Rows[i]["sex_chr"].ToString());
        //            //年龄
        //            dteBirth = Convert.ToDateTime(dtRecord.Rows[i]["birth_dat"].ToString());
        //            age = com.digitalwave.controls.clsArithmetic.CalcAge(dteBirth);
        //            lv.SubItems.Add(age);
        //            //申请时间
        //            lv.SubItems.Add(((DateTime)dtRecord.Rows[i]["opsbookingdate_dat"]).ToString("yyyy/MM/dd HH:mm"));

        //            lv.Tag = dtRecord.Rows[i];

        //            this.m_objViewer.lvPatlist.Items.Add(lv);
        //        }
        //    }

        //    this.m_objViewer.lvPatlist.EndUpdate();
           
        //}
        //#endregion

        #region 当前患者信息
        /// <summary>
        /// 当前患者信息
        /// </summary>
        public void m_mthInitvalue()
        {
            this.m_objViewer.txtAppName.Text    = this.m_objViewer.objOutops.name;
            this.m_objViewer.txtAppSex.Text     = this.m_objViewer.objOutops.sex;
            this.m_objViewer.txtAppAge.Text     = this.m_objViewer.objOutops.age;
            this.m_objViewer.txtAppCardNo.Text  = this.m_objViewer.objOutops.cardno;
            this.m_mthSetdeptposition(this.m_objViewer.objOutops.deptname);      
            this.m_objViewer.cboDepartment.Tag  = this.m_objViewer.objOutops.deptid;
            this.m_objViewer.txtAppDoctor.Text  = this.m_objViewer.objOutops.applydoctorname;
            this.m_objViewer.txtAppYear.Text    = DateTime.Now.Year.ToString();
            this.m_objViewer.txtAppMonth.Text   = DateTime.Now.Month.ToString();
            this.m_objViewer.txtAppDay.Text     = DateTime.Now.Day.ToString();
            this.m_objViewer.txtAppHour.Text    = DateTime.Now.Hour.ToString();
            this.m_objViewer.txtAppMinute.Text  = DateTime.Now.Minute.ToString();
            this.m_objViewer.txtAppDate.Text    = DateTime.Now.ToString("yyyy年MM月dd日");
            this.m_objViewer.lblSave.Text = "新单";
            this.m_objViewer.lblAppNO.Text = "NO: ";
            if (this.m_objViewer.objOutops.chrgitem.Trim() == "")
            {
                this.m_objViewer.txtAppOPSName.Text = "";
            }
            else
            {
                this.m_objViewer.txtAppOPSName.Text = this.m_objViewer.objOutops.chrgname;
            }
            this.m_objViewer.Opssave = false;
        }
        #endregion

        #region 赋值
        /// <summary>
        /// 赋值
        /// </summary>
        public void m_mthSetvalue()
        {
            //if (this.m_objViewer.lvPatlist.SelectedItems.Count > 0)
            //{
            DataRow dr = null;// (DataRow)(this.m_objViewer.lvPatlist.SelectedItems[0].Tag);

                //年龄
                DateTime dteBirth = Convert.ToDateTime(dr["birth_dat"].ToString());
                string age = com.digitalwave.controls.clsArithmetic.CalcAge(dteBirth);

                //预约时间
                string bookingdate = ((DateTime)dr["opsbookingdate_dat"]).ToString("yyyy-MM-dd HH:mm");

                this.m_objViewer.lblAppNO.Text      = "NO: " + dr["applyid_vchr"].ToString();
                this.m_objViewer.txtAppName.Text    = dr["name_vchr"].ToString();
                this.m_objViewer.txtAppSex.Text     = dr["sex_chr"].ToString();
                this.m_objViewer.txtAppAge.Text     = age;
                this.m_objViewer.txtAppCardNo.Text  = dr["patientcardid_chr"].ToString();
                this.m_mthSetdeptposition(dr["deptname_vchr"].ToString());
                this.m_objViewer.cboDepartment.Tag  = "";
                this.m_objViewer.txtAppOPSName.Text = dr["itemname_vchr"].ToString();
                this.m_objViewer.txtAppYear.Text    = bookingdate.Substring(0, 4);
                this.m_objViewer.txtAppMonth.Text   = bookingdate.Substring(5, 2);
                this.m_objViewer.txtAppDay.Text     = bookingdate.Substring(8, 2);
                this.m_objViewer.txtAppHour.Text    = bookingdate.Substring(11, 2);
                this.m_objViewer.txtAppMinute.Text  = bookingdate.Substring(14, 2);
                this.m_objViewer.txtAppHint.Text    = dr["note_vchr"].ToString();
                this.m_objViewer.txtAppDoctor.Text  = dr["lastname_vchr"].ToString();
                this.m_objViewer.txtAppDate.Text    = ((DateTime)dr["recorddate_dat"]).ToString("yyyy年MM月dd日");

                this.m_objViewer.lblSave.Text = "";
                this.m_objViewer.btnSave.Enabled = false;
                this.m_objViewer.btnEdit.Enabled = true;
            //}
        }
        #endregion

        #region 返回预约时间
        /// <summary>
        /// 返回预约时间
        /// </summary>
        /// <returns></returns>
        public string m_mthGetbookingdate()
        {
            string bookingdate = "";

            string year = this.m_objViewer.txtAppYear.Text.Trim();
            if (year.Length != 4)
            {
                MessageBox.Show("年份为4位数，如2006 。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return bookingdate;
            }

            string month = this.m_objViewer.txtAppMonth.Text.Trim();
            m_mthFormatstr(ref month);

            string day = this.m_objViewer.txtAppDay.Text.Trim();
            m_mthFormatstr(ref day);

            string hour = this.m_objViewer.txtAppHour.Text.Trim();
            m_mthFormatstr(ref hour);

            string minute = this.m_objViewer.txtAppMinute.Text.Trim();
            m_mthFormatstr(ref minute);

            bookingdate = year + "-" + month + "-" + day + " " + hour + ":" + minute;

            return bookingdate;
        }
        #endregion

        #region 月、日、小时、分钟补位取值
        /// <summary>
        /// 月、日、小时、分钟补位取值
        /// </summary>
        /// <param name="str"></param>
        private void m_mthFormatstr(ref string str)
        {
            if (str == "")
            {
                str = "01";
            }
            else
            {
                str = str.PadLeft(2, '0');
                str = str.Substring(str.Length - 2, 2);
            }            
        }
        #endregion

        #region 检索科室
        /// <summary>
        /// 检索科室
        /// </summary>
        public void m_mthGetDepartment()
        {           
            //暂时： 检索全部科室
            long ret = objSvc.m_lngGetDeptArr("", out strDeptArr);
            if (strDeptArr != null)
            {
                this.m_objViewer.cboDepartment.Items.Clear();
                for (int i = 0; i < strDeptArr.Length / 2; i++)
                {
                    this.m_objViewer.cboDepartment.Items.Add(strDeptArr[i, 1].ToString());
                }
            }
        }
        #endregion

        #region 获取科室ID
        /// <summary>
        /// 获取科室ID
        /// </summary>
        /// <param name="DeptName"></param>
        /// <returns></returns>
        public string m_mthGetDeptID(string DeptName)
        {
            string DeptID = "";
            long ret = objSvc.m_lngGetDeptArr("", out strDeptArr);
            if (strDeptArr != null)            
            {
                for (int i = 0; i < strDeptArr.Length / 2; i++)
                {
                    if (DeptName == strDeptArr[i, 1])
                    {
                        DeptID = strDeptArr[i, 0];                       
                        break;
                    }
                }
            }

            return DeptID;
        }
        #endregion

        #region CBO科室定位
        /// <summary>
        /// CBO科室定位
        /// </summary>
        /// <param name="DeptName"></param>
        private void m_mthSetdeptposition(string DeptName)
        {
            if (strDeptArr != null)
            {
                for (int i = 0; i < strDeptArr.Length / 2; i++)
                {
                    if (DeptName == strDeptArr[i, 1])
                    {
                       this.m_objViewer.cboDepartment.SelectedIndex = i;
                       break;
                    }
                }
            }
        }
        #endregion

        #region 打印
        /// <summary>
        /// 打印
        /// </summary>
        public void m_mthPrint()
        {
            frmOPCrytalReport fp = new frmOPCrytalReport(1);
            fp.TextName = this.m_objViewer.txtAppName.Text;
            fp.TextSex = this.m_objViewer.txtAppSex.Text;
            fp.TextAge = this.m_objViewer.txtAppAge.Text;
            fp.TextCard = this.m_objViewer.txtAppCardNo.Text;
            fp.TextDept = this.m_objViewer.cboDepartment.Text;
            fp.TextOP = this.m_objViewer.txtAppOPSName.Text;
            fp.Textyear = this.m_objViewer.txtAppYear.Text;
            fp.Textmonth = this.m_objViewer.txtAppMonth.Text;
            fp.Textday = this.m_objViewer.txtAppDay.Text;
            fp.Texttime = this.m_objViewer.txtAppHour.Text;
            fp.Textsecond = this.m_objViewer.txtAppMinute.Text;
            fp.TextTip = this.m_objViewer.txtAppHint.Text;
            fp.TextSinature = this.m_objViewer.txtAppDoctor.Text;
            fp.Textkaidantime = this.m_objViewer.txtAppDate.Text;

            fp.ShowDialog();        
        }
        #endregion

        #region 查找/修改预约时间
        /// <summary>
        /// 查找/修改预约时间
        /// </summary>
        /// <param name="p_type"></param>
        public void m_mthFind(int p_type)
        {
            frmOPSFindapply f = new frmOPSFindapply(p_type);
            f.ShowDialog();
        }
        #endregion

        #region 当TEXTBOX得到焦点时,设置背景色
        /// <summary>
        /// 当TEXTBOX得到焦点时,设置背景色
        /// </summary>
        /// <param name="p_objControlArr">TEXTBOX数组</param>
        /// <param name="p_objBGColor">Color</param>
        public void m_mthSetTextBoxControlsBackColor(System.Windows.Forms.Control[] p_objControlArr)
        {
            for (int i = 0; i < p_objControlArr.Length; i++)
            {
                p_objControlArr[i].Enter += new EventHandler(textBox_Enter);
                p_objControlArr[i].Leave += new EventHandler(textBox_Leave); 
            }
        }

        void textBox_Leave(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = System.Drawing.Color.White; 
        }

        void textBox_Enter(object sender, EventArgs e)
        {
            ((Control)sender).BackColor = System.Drawing.Color.Silver; 
        }
        #endregion 
    }
}
