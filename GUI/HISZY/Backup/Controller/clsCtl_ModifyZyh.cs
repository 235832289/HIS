using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 修改住院号控制类
    /// </summary>
    public class clsCtl_ModifyZyh : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// 修改住院号控制类
        /// </summary>
        public clsCtl_ModifyZyh()
        {
            objSvc = new clsDcl_ModifyZyh();
        }

        #region 变量
        /// <summary>
        /// 住院号
        /// </summary>
        private string Zyh = "";
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_ModifyZyh objSvc;
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmModifyZyh m_objViewer;
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmModifyZyh)frmMDI_Child_Base_in;
        }
        #endregion

        #region 判断新号是否已存在
        /// <summary>
        /// 判断新号是否已存在
        /// </summary>
        /// <param name="newno"></param>
        /// <returns></returns>
        private bool m_blnCheckNewNO(string newno)
        {
            return this.objSvc.m_blnCheckNewNO(newno);
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="type">类型： 1 查找当前在院病人；2 查找历史住院病人</param>
        public void m_mthFind(int type)
        {
            string title = "";
            if (type == 1)
            {
                title = "查找在院病人资料";
            }
            else if (type == 2)
            {
                title = "查找出院病人资料";
            }
            else
            {
                return;
            }

            int tmp = 1;
            if (type == 2)
            {
                tmp = 3;
            }

            frmCommonFind ff = new frmCommonFind(title, tmp);            
            if (ff.ShowDialog() == DialogResult.OK)
            {                
                this.m_mthSetval(ff.Zyh, type);
                if (type == 1)
                {
                    this.m_mthCheckHisinfo(ff.PatientID, ff.InType);
                }
            }
        }
        #endregion

        #region 清空信息
        /// <summary>
        /// 清空信息
        /// </summary>
        /// <param name="type">1 在院 2 出院</param>
        private void m_mthClearinfo(int type)
        {
            if (type == 1)
            {
                this.m_objViewer.lblzyh1.Text = "";                
                this.m_objViewer.lblzycs1.Text = "";                
                this.m_objViewer.lblname1.Text = "";                
                this.m_objViewer.lblsex1.Text = "";                
                this.m_objViewer.lblbirthday1.Text = "";                
                this.m_objViewer.lblidcard1.Text = "";                
                this.m_objViewer.lbladdress1.Text = "";                
                this.m_objViewer.lblintype1.Text = "";                
                this.m_objViewer.lblindate1.Text = "";                
                this.m_objViewer.lblarea1.Text = "";                
                this.m_objViewer.lblbed1.Text = "";                
                this.m_objViewer.lblstatus1.Text = "";                
            }
            else if (type == 2)
            {                
                this.m_objViewer.lblzyh2.Text = "";             
                this.m_objViewer.lblzycs2.Text = "";             
                this.m_objViewer.lblname2.Text = "";             
                this.m_objViewer.lblsex2.Text = "";             
                this.m_objViewer.lblbirthday2.Text = "";             
                this.m_objViewer.lblidcard2.Text = "";             
                this.m_objViewer.lbladdress2.Text = "";             
                this.m_objViewer.lblintype2.Text = "";             
                this.m_objViewer.lblindate2.Text = "";             
                this.m_objViewer.lblarea2.Text = "";             
                this.m_objViewer.lblbed2.Text = "";             
                this.m_objViewer.lbloutarea.Text = "";
                this.m_objViewer.lbloutdate.Text = "";
            }
        }
        #endregion               

        #region 根据病人ID和当前入院性质(普通住院、留观住院)获取对应得(留观、住院)历史记录
        /// <summary>
        /// 根据病人ID和当前入院性质(普通住院、留观住院)获取对应得(留观、住院)历史记录
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="type"></param>        
        /// <returns></returns>
        public void m_mthCheckHisinfo(string pid, int type)
        {            
            DataTable dt = new DataTable();

            if (type == 1)
            {
                type = 2;
            }
            else if (type == 2)
            {
                type = 1;
            }

            long l = this.objSvc.m_lngGetHistoryinfoByPID(pid, type, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                string s = "";
                if (type == 1)
                {
                    s = "该病人有【" + dt.Rows.Count.ToString() + "】条普通入院历史记录，是否调出最近一次记录信息？";
                }
                else if (type == 2)
                {
                    s = "该病人有【" + dt.Rows.Count.ToString() + "】条留观入院历史记录，是否调出最近一次记录信息？";
                }

                if (MessageBox.Show(s, "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {                    
                    this.m_mthSetval(dt.Rows[0]["inpatientid_chr"].ToString().Trim(), 2);
                }
            }            
        }           
        #endregion

        #region 赋值
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="zyh">住院(留观)号</param>
        /// <param name="type">1 在院 2 出院</param>
        public void m_mthSetval(string zyh, int type)
        {            
            if (zyh.Trim() == "")
            {
                return;
            }                      

            #region 在院病人信息
            if (type == 1)
            {
                DataTable dt;
                long l = this.objSvc.m_lngGetPatientinfoByZyh(zyh, out dt, 1);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    this.m_mthClearinfo(1);
                    this.m_mthClearinfo(2);

                    this.m_objViewer.lblzyh1.Text = zyh;
                    //存入院登记流水号
                    this.m_objViewer.lblzyh1.Tag = dt.Rows[0]["registerid_chr"].ToString().Trim(); 
                    this.m_objViewer.lblzycs1.Text = dt.Rows[0]["inpatientcount_int"].ToString();                    
                    this.m_objViewer.lblname1.Text = dt.Rows[0]["lastname_vchr"].ToString().Trim();
                    //存病人ID
                    this.m_objViewer.lblname1.Tag = dt.Rows[0]["patientid_chr"].ToString().Trim();
                    this.m_objViewer.lblsex1.Text = dt.Rows[0]["sex_chr"].ToString().Trim();
                    this.m_objViewer.lblbirthday1.Text = Convert.ToDateTime(dt.Rows[0]["birth_dat"]).ToString("yyyy年MM月dd日");
                    this.m_objViewer.lblidcard1.Text = dt.Rows[0]["idcard_chr"].ToString().Trim();
                    this.m_objViewer.lbladdress1.Text = dt.Rows[0]["homeaddress_vchr"].ToString().Trim();
                    if (dt.Rows[0]["inpatientnotype_int"].ToString() == "1")
                    {
                        this.m_objViewer.lblintype1.Text = "普通住院";
                        this.m_objViewer.cboType.SelectedIndex = 0;
                        this.m_objViewer.cboType.Tag = "住院号";
                    }
                    else if (dt.Rows[0]["inpatientnotype_int"].ToString() == "2")
                    {
                        this.m_objViewer.lblintype1.Text = "留观住院";
                        this.m_objViewer.cboType.SelectedIndex = 2;
                        this.m_objViewer.cboType.Tag = "留观号";
                    }
                    else
                    {
                        this.m_objViewer.lblintype1.Text = "未知";
                    }
                    this.m_objViewer.lblindate1.Text = dt.Rows[0]["rysj"].ToString().Trim();
                    this.m_objViewer.lblarea1.Text = dt.Rows[0]["deptname_vchr"].ToString().Trim();
                    if (dt.Rows[0]["code_chr"].ToString().Trim() == "")
                    {
                        this.m_objViewer.lblstatus1.Text = "未安排床位";
                    }
                    else
                    {
                        this.m_objViewer.lblbed1.Text = dt.Rows[0]["code_chr"].ToString().Trim();
                        this.m_objViewer.lblstatus1.Text = "已安排床位";
                    }

                    if (this.m_objViewer.lblzycs1.Text == "1")
                    {
                        this.m_objViewer.txtNewNO.Enabled = true;
                    }
                    else
                    {
                        this.m_objViewer.txtNewNO.Enabled = false;
                    }
                }
            }
            #endregion

            #region 出院病人信息
            else if (type == 2)
            {
                DataTable dt;
                long l = this.objSvc.m_lngGetPatientinfoByZyh(zyh, out dt, 3);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    this.m_mthClearinfo(type);

                    this.m_objViewer.lblzyh2.Text = zyh;
                    //存出院病人编号
                    this.m_objViewer.lblzyh2.Tag = dt.Rows[0]["patientid_chr"].ToString().Trim();
                    this.m_objViewer.lblzycs2.Text = dt.Rows[0]["inpatientcount_int"].ToString();
                    this.m_objViewer.lblname2.Text = dt.Rows[0]["lastname_vchr"].ToString().Trim();
                    this.m_objViewer.lblsex2.Text = dt.Rows[0]["sex_chr"].ToString().Trim();
                    this.m_objViewer.lblbirthday2.Text = Convert.ToDateTime(dt.Rows[0]["birth_dat"]).ToString("yyyy年MM月dd日");
                    this.m_objViewer.lblidcard2.Text = dt.Rows[0]["idcard_chr"].ToString().Trim();
                    this.m_objViewer.lbladdress2.Text = dt.Rows[0]["homeaddress_vchr"].ToString().Trim();
                    if (dt.Rows[0]["inpatientnotype_int"].ToString() == "1")
                    {
                        this.m_objViewer.lblintype2.Text = "普通住院";
                        this.m_objViewer.lblintype2.Tag = "住院号";
                    }
                    else if (dt.Rows[0]["inpatientnotype_int"].ToString() == "2")
                    {
                        this.m_objViewer.lblintype2.Text = "留观住院";
                        this.m_objViewer.lblintype2.Tag = "留观号";
                    }
                    else
                    {
                        this.m_objViewer.lblintype2.Text = "未知";
                    }
                    this.m_objViewer.lblindate2.Text = dt.Rows[0]["rysj"].ToString().Trim();
                    this.m_objViewer.lblarea2.Text = dt.Rows[0]["deptname_vchr"].ToString().Trim();

                    this.m_objViewer.lbloutarea.Text = dt.Rows[0]["cybq"].ToString().Trim();
                    this.m_objViewer.lblbed2.Text = dt.Rows[0]["cybc"].ToString().Trim();
                    this.m_objViewer.lbloutdate.Text = dt.Rows[0]["cysj"].ToString().Trim();
                }
            }
            #endregion
        }
        #endregion

        #region 改号
        /// <summary>
        /// 改号
        /// </summary>
        public void m_mthModifyNO()
        {
            if (this.m_objViewer.lblzyh1.Text.Trim() == "")
            {
                MessageBox.Show("请查找当前在院病人！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            //修改类型 0 住院号->住院号 1 住院号->留观号 2 留观号->留观号 3 留观号->住院号
            int currtype = this.m_objViewer.cboType.SelectedIndex;
                        
            string orgtype = this.m_objViewer.cboType.Tag.ToString().Trim();
            if (orgtype == "住院号")
            {
                if (currtype == 2 || currtype == 3)
                {
                    MessageBox.Show("当前是普通住院病人，请重新选择修改类型。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.cboType.SelectedIndex = 0;
                    return;
                }                
            }
            else if (orgtype == "留观号")
            {
                if (currtype == 0 || currtype == 1)
                {
                    MessageBox.Show("当前是留观病人，请重新选择修改类型。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.cboType.SelectedIndex = 2;
                    return;
                }
            }                       

            //当前病人ID
            string currpatientid = this.m_objViewer.lblname1.Tag.ToString();
            //本次入院登记流水号
            string currregid = this.m_objViewer.lblzyh1.Tag.ToString();
            //本次住院号
            string currzyh = this.m_objViewer.lblzyh1.Text.Trim();
            //本次住院次数
            int currzycs = int.Parse(this.m_objViewer.lblzycs1.Text);
            //新号
            string newno = this.m_objViewer.txtNewNO.Text.Trim();
            //旧号病人ID
            string oldpatientid = "";
            //旧号
            string oldzyh = this.m_objViewer.lblzyh2.Text.Trim();
            //旧号住院次数
            int oldzycs = 0;
            //同一病人标志
            bool sameflag = false;
                           
            //提示信息
            string[] Hintinfo = new string[4] { "", "", "", ""};
            Hintinfo[1] = "是否改成【新】的住院(留观)号，请确认？";
            Hintinfo[2] = "是否【自动】生成新的住院(留观)号，请确认？";
            Hintinfo[3] = "是否【合并】到旧的住院(留观)号，请确认？";
            string[] Saveinfo = new string[2] { "", "" };
            Saveinfo[0] = "修改住院号成功！";
            Saveinfo[1] = "修改住院号失败。";

            //修改类型 1 新号 2 自动 3 合并
            int type = 0;
            //多次住院标志
            bool miflag = false;            
            if (currzycs > 1)
            {
                miflag = true;
            }
                              
            if (this.m_objViewer.chkAuto.Checked == false && newno == "" && oldzyh == "")
            {                            
                return;
            }

            if (this.m_objViewer.chkUnion.Checked)
            {
                if (oldzyh == "")
                {
                    MessageBox.Show("合并住院(留观)号前请找出旧号信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.m_objViewer.btnFindOldNO.Focus();
                    return;
                }
                else
                {
                    if (this.m_objViewer.lblintype2.Text == "普通住院")
                    {
                        if (currtype != 0 && currtype != 3)
                        {
                            MessageBox.Show("合并住院(留观)号前：修改成的类型必须与旧号类型相同，请重新指定修改类型。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.m_objViewer.cboType.Focus();
                            return;
                        }
                    }
                    else if (this.m_objViewer.lblintype2.Text == "留观住院")
                    {
                        if (currtype != 1 && currtype != 2)
                        {
                            MessageBox.Show("合并住院(留观)号前：修改成的类型必须与旧号类型相同，请重新指定修改类型。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            this.m_objViewer.cboType.Focus();
                            return;
                        }
                    }
                    type = 3;
                }
            }
            else
            {
                if (this.m_objViewer.chkAuto.Checked)
                {
                    type = 2;
                }
                else
                {
                    if (newno == "")
                    {
                        MessageBox.Show("请输入新住院(留观)号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        this.m_objViewer.btnFindOldNO.Focus();
                        return;
                    }
                    else
                    {
                        type = 1;
                    }
                }
            }

            string pid1 = this.m_objViewer.lblname1.Tag.ToString().Trim();
            string pid2 = this.m_objViewer.lblzyh1.Tag.ToString().Trim();

            string intype1 = this.m_objViewer.lblintype1.Text;
            string intype2 = this.m_objViewer.lblintype2.Text;
            if (intype2.Trim() != "" && intype1 != intype2 && pid1 == pid2)
            {
                if ((currtype == 1 || currtype == 3))
                {
                    if (!this.m_objViewer.chkUnion.Checked)
                    {
                        MessageBox.Show("同一病人只能使用合并住院(留观)号操作。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }

            int zycs1 = (this.m_objViewer.lblzycs1.Text.Trim() == "" ? 0 : int.Parse(this.m_objViewer.lblzycs1.Text.Trim()));
            int zycs2 = (this.m_objViewer.lblzycs2.Text.Trim() == "" ? 0 : int.Parse(this.m_objViewer.lblzycs2.Text.Trim()));
            if ((zycs1 > 1 && zycs2 == 0 && currtype != 1 && currtype != 3 ) || (zycs1 > 1 && zycs2 > 0 && intype1 == intype2 && pid1 == pid2))
            {
                MessageBox.Show("对同一多次住院的病人不能进行修改操作，请先退号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }           
            //else if (zycs1 > 1 && zycs2 > 0 && !this.m_objViewer.chkUnion.Checked)
            //{
            //    MessageBox.Show("只能合并住院(留观)号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (MessageBox.Show(Hintinfo[type], "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            if (type == 1)
            {
                if (this.m_blnCheckNewNO(newno))
                {
                    MessageBox.Show("新住院(留观)号已被使用，请重新输入新号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            else if (type == 3)
            {
                if (Convert.ToDateTime(this.m_objViewer.lbloutdate.Text) >= Convert.ToDateTime(this.m_objViewer.lblindate1.Text))
                {
                    MessageBox.Show("旧号的出院时间大于当前住院信息的入院时间，两号不能合并。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                newno = oldzyh;
                oldzycs = int.Parse(this.m_objViewer.lblzycs2.Text) + 1;
                oldpatientid = this.m_objViewer.lblzyh2.Tag.ToString().Trim();
                sameflag = (currpatientid == oldpatientid ? true : false);
            }

            if (this.objSvc.m_blnModifyNewNO(oldpatientid, currregid, currzyh, ref newno, oldzycs, miflag, sameflag, currtype, type, this.m_objViewer.LoginInfo.m_strEmpID))
            {
                MessageBox.Show(Saveinfo[0], "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.m_objViewer.lblzyh1.Text = newno;
                if (type == 3)
                {
                    this.m_objViewer.lblzycs1.Text = oldzycs.ToString();
                    this.m_objViewer.lblname1.Text = this.m_objViewer.lblname2.Text;
                    this.m_objViewer.lblname1.Tag = this.m_objViewer.lblzyh2.Tag;                    
                    this.m_objViewer.lblsex1.Text = this.m_objViewer.lblsex2.Text;
                    this.m_objViewer.lblbirthday1.Text = this.m_objViewer.lblbirthday2.Text;
                    this.m_objViewer.lblidcard1.Text = this.m_objViewer.lblidcard2.Text;
                    this.m_objViewer.lbladdress1.Text = this.m_objViewer.lbladdress2.Text;
                }
                if (currtype == 0 || currtype == 3)
                {
                    this.m_objViewer.lblintype1.Text = "普通住院";
                }
                else if (currtype == 1 || currtype == 2)
                {
                    this.m_objViewer.lblintype1.Text = "留观住院";
                }

                //顺德同时修改医保病人住院号
                if (clsPublic.m_strGetSysparm("1000") == "003")
                {
                    clsCtl_Report objRep = new clsCtl_Report();
                    objRep.m_mthModifyZyh_SDYB(currzyh, newno);
                }
            }
            else
            {
                MessageBox.Show(Saveinfo[1], "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }                                                                                                       
        }
        #endregion        
    }
}
