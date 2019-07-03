using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public partial class frmCommonFind : com.digitalwave.GUI_Base.frmMDI_Child_Base 
    {
        #region 变量
        /// <summary>
        /// 窗口标题
        /// </summary>
        internal string Titleinfo = "";
        /// <summary>
        /// 病人入院登记流水号
        /// </summary>
        private string regid = "";
        /// <summary>
        /// 病人ID
        /// </summary>
        private string pid = "";
        /// <summary>
        /// 住院号
        /// </summary>
        private string zyh = "";
        /// <summary>
        /// 住院次数
        /// </summary>
        private int zycs = 0;
        /// <summary>
        /// 病人姓名
        /// </summary>
        private string patname = "";
        /// <summary>
        /// 状态 1 新入院 2 已安排床位 3 出院
        /// </summary>
        private string instatus = "";
        /// <summary>
        /// 出院时间
        /// </summary>
        private string outdate = "";
        /// <summary>
        /// 入院类型 1 普通住院 2 留观住院
        /// </summary>
        private int intype = 0;
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        private string cardno = "";
        #endregion

        #region 属性
        /// <summary>
        /// 病人入院登记流水号
        /// </summary>
        public string RegisterID
        {
            set
            {
                regid = value;
            }
            get
            {
                return regid;
            }
        }
        /// <summary>
        /// 病人ID
        /// </summary>
        public string PatientID
        {
            set
            {
                pid = value;
            }
            get
            {
                return pid;
            }
        }
        /// <summary>
        /// 住院号
        /// </summary>
        public string Zyh
        {
            set
            {
                zyh = value;
            }
            get
            {
                return zyh;
            }
        }
        /// <summary>
        /// 住院次数
        /// </summary>
        public int Zycs
        {
            set
            {
                zycs = value;
            }
            get
            {
                return zycs;
            }
        }
        /// <summary>
        /// 诊疗卡号
        /// </summary>
        public string CardNo
        {
            set
            {
                cardno = value;
            }
            get
            {
                return cardno;
            }
        }
        /// <summary>
        /// 病人姓名
        /// </summary>
        public string PatName
        {
            set
            {
                patname = value;
            }
            get
            {
                return patname;
            }
        }
        /// <summary>
        /// 状态 1 新入院 2 已安排床位 3 出院
        /// </summary>
        public string InStatus
        {
            set
            {
                instatus = value;
            }
            get
            {
                return instatus;
            }
        }
        /// <summary>
        /// 出院时间
        /// </summary>
        public string OutDate
        {
            set
            {
                outdate = value;
            }
            get
            {
                return outdate;
            }
        }
        /// <summary>
        /// 入院类型 1 普通住院 2 留观住院
        /// </summary>
        public int InType
        {
            set
            {
                intype = value;
            }
            get
            {
                return intype;
            }
        }
        /// <summary>
        /// 是否入院登记(调用)
        /// </summary>
        public bool IsBihReg
        {
            set
            {
                ((clsCtl_CommonFind)this.objController).BlnInReg = value;
            }
        }

        /// <summary>
        /// 窗体标题
        /// </summary>
        private string frmTitle = "";
        /// <summary>
        /// 查询状态 0 全部 1 在院 2 预出院 3 正式出院 4 请假 8 出院结算 9 预交款类型         
        /// </summary>
        internal int Status = 0;
        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public frmCommonFind()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="title">窗体标题</param>
        /// <param name="status">查找类型： 0 全部 1 在院 2 预出院 3 正式出院 9 预交款类型 </param>
        public frmCommonFind(string title, int status)
        {
            InitializeComponent();
            frmTitle = title;
            Status = status;
        }

        /// <summary>
        /// 创建控制类
        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.Reports.clsCtl_CommonFind();
            objController.Set_GUI_Apperance(this);
        }

        private void frmCommonFind_Load(object sender, EventArgs e)
        {
            if (frmTitle.Trim() != "")
            {
                this.Text = frmTitle;
            }
            if (Status == 3)
            {
                this.btnArea.Enabled = false;
            }

            if (this.lsvPatient.Items.Count > 0)
            {
                this.timer1.Enabled = true;
                this.timer1.Interval = 100;
            }

            this.chkInDate.Checked = true;
        }

        private void frmCommonFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();   
            }
            else if (e.KeyCode == Keys.F3)
            {
                ((clsCtl_CommonFind)this.objController).m_mthFind();
            }
            else if (e.KeyCode == Keys.F5)
            {
                this.m_ShortCutFind(1);                
            }
        }

        #region 快捷查找
        /// <summary>
        /// 快捷查找
        /// </summary>
        /// <param name="flag">1 根据住院号 2 根据诊疗卡号</param>
        private void m_ShortCutFind(int flag)
        {
            string tmpZyh = clsPublic.m_strReadParmZyh();
            string tmpCardNo = clsPublic.m_strReadParmCardNo();
            if (tmpZyh == "")
            {
                MessageBox.Show("对不起，没有历史查询记录。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int count = this.m_intFindByZyh(tmpZyh, false, false);
                
                if (flag == 2)
                {
                    this.txtZyh.Text = "";
                    this.txtCardNo.Text = tmpCardNo;
                }

                if (count == 0)
                {
                    MessageBox.Show("对不起，没有找到满足查找条件的病人信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }                
            }

            if (this.lsvPatient.Items.Count > 0)
            {
                this.lsvPatient.Items[0].Selected = true;
                this.lsvPatient.Focus();
            }
            else
            {
                if (flag == 1)
                {
                    this.txtZyh.Focus();
                    this.txtZyh.SelectAll();
                }
                else if (flag == 2)
                {                
                    this.txtCardNo.Focus();
                    this.txtCardNo.SelectAll();
                }
            }
        }
        #endregion
            
        private void btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_CommonFind)this.objController).m_mthFind();
        }

        private void lsvPatient_DoubleClick(object sender, EventArgs e)
        {
            ((clsCtl_CommonFind)this.objController).m_mthGetPatientinfo();
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            ((clsCtl_CommonFind)this.objController).m_mthFindArea();
        }

        private void lsvPatient_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == 0)
            {
                return;
            }
            else
            {
                lsvPatient.Sorting = (lsvPatient.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending);
                lsvPatient.ListViewItemSorter = new ListViewItemSort(e.Column, lsvPatient.Sorting, lsvPatient);
                lsvPatient.Sort();

                for (int i = 1; i <= lsvPatient.Items.Count; i++)
                {
                    lsvPatient.Items[i - 1].SubItems[0].Text = i.ToString();
                }
            }
        }

        private void chkUnionAnd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnionAnd.Checked)
            {
                if (chkUnionOr.Checked)
                {
                    chkUnionOr.Checked = false;
                }
            }
        }

        private void chkUnionOr_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUnionOr.Checked)
            {
                if (chkUnionAnd.Checked)
                {
                    chkUnionAnd.Checked = false;
                }
            }
        }

        #region 隐式查找
        /// <summary>
        /// 按住院号查找
        /// </summary>
        /// <param name="Zyh">住院号</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>
        /// <param name="IsIncludeMZ">是否查找门诊信息 true 是 false 否</param>
        /// <returns>记录数</returns>
        public int m_intFindByZyh(string Zyh, bool Ismatch, bool IsIncludeMZ)
        {
            this.txtZyh.Text = Zyh;
            this.chkMatch.Checked = Ismatch;
            this.chkMZ.Checked = IsIncludeMZ;
            return ((clsCtl_CommonFind)this.objController).m_mthFind(Zyh, Ismatch, 0, IsIncludeMZ);
        }

        /// <summary>
        /// 按住院号查找
        /// </summary>
        /// <param name="Zyh">住院号</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>        
        /// <returns>记录数</returns>
        public int m_intFindByZyh(string Zyh, bool Ismatch)
        {
            this.txtZyh.Text = Zyh;
            this.chkMatch.Checked = Ismatch;
            return ((clsCtl_CommonFind)this.objController).m_mthFind(Zyh, Ismatch, 0, false);
        }

        /// <summary>
        /// 按诊疗卡号查找
        /// </summary>
        /// <param name="Cardno">诊疗卡号</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>
        /// <param name="IsIncludeMZ">是否查找门诊信息 true 是 false 否</param>
        /// <returns>记录数</returns>
        public int m_intFindByCardno(string Cardno, bool Ismatch, bool IsIncludeMZ)
        {
            this.txtCardNo.Text = Cardno;
            this.chkMatch.Checked = Ismatch;
            this.chkMZ.Checked = IsIncludeMZ;
            return ((clsCtl_CommonFind)this.objController).m_mthFind(Cardno, Ismatch, 1, IsIncludeMZ);
        }

        /// <summary>
        /// 按诊疗卡号查找
        /// </summary>
        /// <param name="Cardno">诊疗卡号</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>        
        /// <returns>记录数</returns>
        public int m_intFindByCardno(string Cardno, bool Ismatch)
        {
            this.txtCardNo.Text = Cardno;
            this.chkMatch.Checked = Ismatch;
            return ((clsCtl_CommonFind)this.objController).m_mthFind(Cardno, Ismatch, 1, false);
        }

        /// <summary>
        /// 按姓名查找
        /// </summary>
        /// <param name="Name">姓名</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>
        /// <param name="IsIncludeMZ">是否查找门诊信息 true 是 false 否</param>
        /// <returns>记录数</returns>
        public int m_intFindByName(string Name, bool Ismatch, bool IsIncludeMZ)
        {
            this.txtName.Text = Name;
            this.chkMatch.Checked = Ismatch;
            this.chkMZ.Checked = IsIncludeMZ;
            return ((clsCtl_CommonFind)this.objController).m_mthFind(Name, Ismatch, 2, IsIncludeMZ);
        }

        /// <summary>
        /// 按姓名查找
        /// </summary>
        /// <param name="Name">姓名</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>        
        /// <returns>记录数</returns>
        public int m_intFindByName(string Name, bool Ismatch)
        {
            this.txtName.Text = Name;
            this.chkMatch.Checked = Ismatch;
            return ((clsCtl_CommonFind)this.objController).m_mthFind(Name, Ismatch, 2, false);
        }
        #endregion

        /// <summary>
        /// 按姓名、性别、入院类型(普通留观)查找
        /// </summary>
        /// <param name="Name">姓名</param>
        /// <param name="Sex">性别</param>
        /// <param name="Type">类型 1 普通 2 留观</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>
        /// <param name="IsIncludeMZ">是否查找门诊信息 true 是 false 否</param>
        /// <returns></returns>
        public int m_intFindByNameSexType(string Name, string Sex, int Type, bool Ismatch, bool IsIncludeMZ)
        {
            this.txtName.Text = Name;
            this.chkMatch.Checked = Ismatch;
            this.chkMZ.Checked = IsIncludeMZ;            
            return ((clsCtl_CommonFind)this.objController).m_mthFind(Name, Sex, Type, Ismatch, IsIncludeMZ);
        }

        /// <summary>
        /// 按姓名、性别、入院类型(普通留观)查找
        /// </summary>
        /// <param name="Name">姓名</param>
        /// <param name="Sex">性别</param>
        /// <param name="Type">类型 1 普通 2 留观</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>        
        /// <returns></returns>
        public int m_intFindByNameSexType(string Name, string Sex, int Type, bool Ismatch)
        {
            this.txtName.Text = Name;
            this.chkMatch.Checked = Ismatch;
            return ((clsCtl_CommonFind)this.objController).m_mthFind(Name, Sex, Type, Ismatch, false);
        }

        private void txtCardNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s = this.txtCardNo.Text.Trim();
                if (s != "")
                {
                    s = s.PadLeft(10, '0');
                    this.txtCardNo.Text = s;
                }
            }
        }

        private void lsvPatient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtl_CommonFind)this.objController).m_mthGetPatientinfo();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.lsvPatient.Items[0].Selected = true;
            this.lsvPatient.Focus();
            this.timer1.Enabled = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblZyh_MouseEnter(object sender, EventArgs e)
        {
            this.lblZyh.ForeColor = Color.FromArgb(255, 154, 0);
        }

        private void lblZyh_MouseLeave(object sender, EventArgs e)
        {
            this.lblZyh.ForeColor = Color.White;
        }

        private void lblZyh_Click(object sender, EventArgs e)
        {
            this.m_ShortCutFind(1);
        }

        private void lblCardNo_MouseEnter(object sender, EventArgs e)
        {
            this.lblCardNo.ForeColor = Color.FromArgb(255, 154, 0);
        }

        private void lblCardNo_MouseLeave(object sender, EventArgs e)
        {
            this.lblCardNo.ForeColor = Color.White;
        }

        private void lblCardNo_Click(object sender, EventArgs e)
        {
            this.m_ShortCutFind(2);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            ((clsCtl_CommonFind)this.objController).m_mthGetPatientinfo();
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            this.m_ShortCutFind(1);
        }

        private void chkInDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkInDate.Checked)
            {
                this.dtBegin_in.Enabled = true;
                this.dtEnd_in.Enabled = true;
            }
            else
            {
                this.dtBegin_in.Enabled = false;
                this.dtEnd_in.Enabled = false;
            }
        }

        private void chkOutDate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkOutDate.Checked)
            {
                this.dtBegin_out.Enabled = true;
                this.dtEnd_out.Enabled = true;
            }
            else
            {
                this.dtBegin_out.Enabled = false;
                this.dtEnd_out.Enabled = false;
            }
        }       
    }
}