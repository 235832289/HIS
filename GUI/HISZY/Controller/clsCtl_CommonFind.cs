using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 查找控制类
    /// </summary>
    public class clsCtl_CommonFind : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_CommonFind objSvc;
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmCommonFind m_objViewer;
        /// <summary>
        /// 入院登记处调用标志
        /// </summary>
        internal bool BlnInReg = false;

        #endregion 

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_CommonFind()
        {
            objSvc = new clsDcl_CommonFind();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmCommonFind)frmMDI_Child_Base_in;
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        public void m_mthFind()
        {
            string SqlWhereMZ = "", SqlWhereZY = "";            
            this.m_mthGetsqlwhere(out SqlWhereZY, out SqlWhereMZ);

            //门诊
            SqlWhereMZ = SqlWhereMZ.Trim();           

            if (SqlWhereMZ.StartsWith("or"))
            {
                SqlWhereMZ = SqlWhereMZ.Substring(2);
            }
            else if (SqlWhereMZ.StartsWith("and"))
            {
                SqlWhereMZ = SqlWhereMZ.Substring(3);
            }

            bool IsIncludeMZ = this.m_objViewer.chkMZ.Checked;

            //住院
            SqlWhereZY = SqlWhereZY.Trim();

            if (SqlWhereZY.StartsWith("or"))
            {
                SqlWhereZY = SqlWhereZY.Substring(2);           
            }
            else if (SqlWhereZY.StartsWith("and"))
            {
                SqlWhereZY = SqlWhereZY.Substring(3);           
            }

            if (!SqlWhereZY.Trim().StartsWith("(to_char"))
            {
                SqlWhereZY = "(" + SqlWhereZY + ")";
            }

            if (SqlWhereZY.Length > 8)
            {
                SqlWhereZY = " and " + SqlWhereZY;
            }
            else
            {
                SqlWhereZY = "";
            }

            clsPublic.PlayAvi("正在查找病人资料库，请稍候...");

            clsCommonQueryDate_VO CommonQueryDate_VO = new clsCommonQueryDate_VO();
            if (this.m_objViewer.chkInDate.Checked == false && this.m_objViewer.chkOutDate.Checked == false)
            {
                CommonQueryDate_VO.QueryType = 0;
            }
            else
            {
                if (this.m_objViewer.chkInDate.Checked && this.m_objViewer.chkOutDate.Checked)
                {
                    CommonQueryDate_VO.QueryType = 3;
                    CommonQueryDate_VO.BeginDate_In = this.m_objViewer.dtBegin_in.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    CommonQueryDate_VO.EndDate_In = this.m_objViewer.dtEnd_in.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                    CommonQueryDate_VO.BeginDate_Out = this.m_objViewer.dtBegin_out.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                    CommonQueryDate_VO.EndDate_Out = this.m_objViewer.dtEnd_out.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                }
                else
                {
                    if (this.m_objViewer.chkInDate.Checked)
                    {
                        CommonQueryDate_VO.QueryType = 1;
                        CommonQueryDate_VO.BeginDate_In = this.m_objViewer.dtBegin_in.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                        CommonQueryDate_VO.EndDate_In = this.m_objViewer.dtEnd_in.Value.ToString("yyyy-MM-dd") + " 23:59:59";                        
                    }
                    else if (this.m_objViewer.chkOutDate.Checked)
                    {
                        CommonQueryDate_VO.QueryType = 2;                        
                        CommonQueryDate_VO.BeginDate_Out = this.m_objViewer.dtBegin_out.Value.ToString("yyyy-MM-dd") + " 00:00:00";
                        CommonQueryDate_VO.EndDate_Out = this.m_objViewer.dtEnd_out.Value.ToString("yyyy-MM-dd") + " 23:59:59";
                    }
                }
            }

            DataTable dt = new DataTable();
            long l = this.objSvc.m_lngGetPatientinfo(SqlWhereZY, this.m_objViewer.Status, IsIncludeMZ, SqlWhereMZ, CommonQueryDate_VO, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                this.m_mthSetval(dt);
                clsPublic.CloseAvi();
            }
            else
            {
                this.m_objViewer.lsvPatient.BeginUpdate();
                this.m_objViewer.lsvPatient.Items.Clear();
                this.m_objViewer.lsvPatient.EndUpdate();
                clsPublic.CloseAvi();
                MessageBox.Show("没有找到满足查询条件的病人信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.lblInfo.Text = "找到满足条件的记录数： 0条";

                if (this.m_objViewer.txtCardNo.Text.Trim() != "")
                {
                    this.m_objViewer.txtCardNo.Focus();
                    this.m_objViewer.txtCardNo.SelectAll();
                }
                else if (this.m_objViewer.txtZyh.Text.Trim() != "")
                {
                    this.m_objViewer.txtZyh.Focus();
                    this.m_objViewer.txtZyh.SelectAll();
                }
                else if (this.m_objViewer.txtName.Text.Trim() != "")
                {
                    this.m_objViewer.txtName.Focus();
                    this.m_objViewer.txtName.SelectAll();
                }
            }
        }
        #endregion

        #region 得到查找条件
        /// <summary>
        /// 得到查找条件
        /// </summary>        
        private void m_mthGetsqlwhere(out string SqlWhereZY, out string SqlWhereMZ)
        {
            SqlWhereZY = "";
            SqlWhereMZ = "1 <> 1";
            string Match = "";

            if (this.m_objViewer.chkMatch.Checked)
            {
                Match = "%";
            }

            string Unlogic = "";
            bool Union = true;

            if (this.m_objViewer.chkUnionAnd.Checked)
            {
                Unlogic = "and";
            }
            else if (this.m_objViewer.chkUnionOr.Checked)
            {
                Unlogic = "or";
            }
            else
            {
                Union = false;
            }                        

            if (this.m_objViewer.txtZyh.Text.Trim() != "")
            {
                SqlWhereZY = "a.inpatientid_chr like '" + this.m_objViewer.txtZyh.Text.Trim() + Match + "'";
                if (!Union)
                {
                    return;
                }
            }

            if (this.m_objViewer.txtCardNo.Text.Trim() != "")
            {
                SqlWhereZY += Unlogic + " f.patientcardid_chr like '" + this.m_objViewer.txtCardNo.Text.Trim() + Match + "'";
                SqlWhereMZ = " f.patientcardid_chr like '" + this.m_objViewer.txtCardNo.Text.Trim() + Match + "'";
                if (!Union)
                {
                    return;
                }
            }

            if (this.m_objViewer.txtName.Text.Trim() != "")
            {
                SqlWhereZY += Unlogic + " b.lastname_vchr like '" + this.m_objViewer.txtName.Text.Trim() + Match + "'";

                if (SqlWhereMZ.Trim() == "1 <> 1")
                {
                    SqlWhereMZ = Unlogic + " b.lastname_vchr like '" + this.m_objViewer.txtName.Text.Trim() + Match + "'";
                }
                else
                {
                    SqlWhereMZ += Unlogic + " b.lastname_vchr like '" + this.m_objViewer.txtName.Text.Trim() + Match + "'";
                }
                if (!Union)
                {
                    return;
                }
            }
        }
        #endregion

        #region 隐式查找
        /// <summary>
        /// 隐式查找
        /// </summary>
        /// <param name="Val">值</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>
        /// <param name="type">类型 0 住院号 1 诊疗卡号 2 姓名</param>
        /// <param name="IsIncludeMZ">是否查找门诊信息 true 是 false 否</param>
        /// <returns>记录数</returns>
        public int m_mthFind(string Val, bool Ismatch, int type, bool IsIncludeMZ)
        {
            string SqlWhereZY = "", SqlWhereMZ = "";
            string Match = "";
            
            if (Ismatch)
            {
                Match = "%";
            }

            switch (type)
            {
                case 0:
                    SqlWhereZY = "a.inpatientid_chr like '" + Val + Match + "'";
                    SqlWhereMZ = "1 <> 1";
                    break;
                case 1:
                    SqlWhereZY += "f.patientcardid_chr like '" + Val + Match + "'";
                    SqlWhereMZ = "a.inpatientid_chr like '" + Val + Match + "'";
                    break;
                case 2:
                    SqlWhereZY += "b.lastname_vchr like '" + Val + Match + "'";
                    SqlWhereMZ = "a.inpatientid_chr like '" + Val + Match + "'";
                    break;                
            }

            SqlWhereZY = " and " + SqlWhereZY;

            DataTable dt = new DataTable();
            long l = this.objSvc.m_lngGetPatientinfo(SqlWhereZY, this.m_objViewer.Status, IsIncludeMZ, SqlWhereMZ, null, out dt);            
            if (l > 0 && dt.Rows.Count > 0)
            {
                this.m_mthSetval(dt);                
            }
            else
            {
                return 0;
            }

            return dt.Rows.Count;
        }
        
        /// <summary>
        /// 隐式查找
        /// </summary>
        /// <param name="Name">姓名</param>
        /// <param name="Sex">性别</param>
        /// <param name="Type">入院类型(1 普通 2 留观)</param>
        /// <param name="Ismatch">是否模糊查找 true 是 false 否</param>
        /// <param name="IsIncludeMZ">是否查找门诊信息 true 是 false 否</param>
        /// <returns>记录数</returns>
        public int m_mthFind(string Name, string Sex, int Type, bool Ismatch, bool IsIncludeMZ)
        {            
            string Match = "";
            
            if (Ismatch)
            {
                Match = "%";
            }

            string SqlWhereZY = " and b.lastname_vchr like '" + Name + Match + "' and b.sex_chr = '" + Sex + "' and a.inpatientnotype_int = " + Type.ToString();
            string SqlWhereMZ = "b.lastname_vchr like '" + Name + Match + "' and b.sex_chr = '" + Sex + "'";
                        
            DataTable dt = new DataTable();
            long l = this.objSvc.m_lngGetPatientinfo(SqlWhereZY, this.m_objViewer.Status, IsIncludeMZ, SqlWhereMZ, null, out dt);            
            if (l > 0 && dt.Rows.Count > 0)
            {
                this.m_mthSetval(dt);                
            }
            else
            {
                return 0;
            }

            return dt.Rows.Count;
        }
        #endregion

        #region 显示结果
        /// <summary>
        /// 显示结果
        /// </summary>
        /// <param name="dt"></param>
        private void m_mthSetval(DataTable dt)
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            this.m_objViewer.lsvPatient.BeginUpdate();
            this.m_objViewer.lsvPatient.Items.Clear();

            string status = "";
            string feestatus = "";
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                switch (dt.Rows[i]["feestatus_int"].ToString())
                {
                    case "0":
                        feestatus = "新";
                        break;
                    case "1":
                        feestatus = "待清";
                        break;
                    case "2":
                        feestatus = "清帐";
                        break;
                    case "3":
                        feestatus = "清帐";
                        break;
                    case "4":
                        feestatus = "呆帐清帐";
                        break;
                    case "5":
                        feestatus = "待清";
                        break;
                }

                switch (dt.Rows[i]["pstatus_int"].ToString())
                {
                    case "0":
                        status = "无床";
                        break;
                    case "1":
                        status = "在床";
                        break;
                    case "2":
                        status = "预出院";
                        if (dt.Rows[i]["feestatus_int"].ToString() != "5")
                        {
                            feestatus = "待结";
                        }
                        break;
                    case "3":
                        status = "出院";
                        break;
                    case "4":
                        status = "请假";
                        break;      
                    case "999":
                        status = "门诊";
                        break;
                }                

                ListViewItem lvitem = new ListViewItem((Convert.ToInt32(i + 1)).ToString());
                lvitem.SubItems.Add(status);

                if (status == "门诊")
                {
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add(dt.Rows[i]["lastname_vchr"].ToString().Trim());
                    lvitem.SubItems.Add(dt.Rows[i]["sex_chr"].ToString().Trim());
                    if (dt.Rows[i]["cssj"].ToString().Trim() == "")
                    {
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add("");
                    }
                    else
                    {
                        lvitem.SubItems.Add(clsPublic.CalcAge(Convert.ToDateTime(dt.Rows[i]["birth_dat"])));
                        lvitem.SubItems.Add(dt.Rows[i]["cssj"].ToString());
                    }
                    lvitem.SubItems.Add(dt.Rows[i]["homeaddress_vchr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["employer_vchr"].ToString());
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add(dt.Rows[i]["patientcardid_chr"].ToString());
                    lvitem.SubItems.Add("");
                    lvitem.SubItems.Add(dt.Rows[i]["patientid_chr"].ToString());

                    lvitem.BackColor = clsPublic.CustomBackColor;
                }
                else
                {
                    lvitem.SubItems.Add(feestatus);
                    lvitem.SubItems.Add(dt.Rows[i]["inpatientid_chr"].ToString().Trim());
                    lvitem.SubItems.Add(dt.Rows[i]["inpatientcount_int"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["deptname_vchr"].ToString().Trim());
                    lvitem.SubItems.Add(dt.Rows[i]["lastname_vchr"].ToString().Trim());
                    lvitem.SubItems.Add(dt.Rows[i]["sex_chr"].ToString().Trim());
                    if (dt.Rows[i]["cssj"].ToString().Trim() == "")
                    {
                        lvitem.SubItems.Add("");
                        lvitem.SubItems.Add("");
                    }
                    else
                    {
                        lvitem.SubItems.Add(clsPublic.CalcAge(Convert.ToDateTime(dt.Rows[i]["birth_dat"])));
                        lvitem.SubItems.Add(dt.Rows[i]["cssj"].ToString());
                    }
                    lvitem.SubItems.Add(dt.Rows[i]["homeaddress_vchr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["employer_vchr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["rysj"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["cysj"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["patientcardid_chr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["registerid_chr"].ToString());
                    lvitem.SubItems.Add(dt.Rows[i]["patientid_chr"].ToString());

                    lvitem.BackColor = Color.FromArgb(255, 255, 255);
                }


                lvitem.ImageIndex = 0;
                lvitem.Tag = dt.Rows[i];
                this.m_objViewer.lsvPatient.Items.Add(lvitem);
            }

            this.m_objViewer.lblInfo.Text = "找到满足条件的记录数： " + dt.Rows.Count.ToString() + "条";

            this.m_objViewer.lsvPatient.EndUpdate();
            this.m_objViewer.Cursor = Cursors.Default;

            if (dt.Rows.Count > 0)
            {
                this.m_objViewer.lsvPatient.Items[0].Selected = true;
                this.m_objViewer.lsvPatient.Focus();
            }
        }
        #endregion

        #region 浏览病区床位信息
        /// <summary>
        /// 浏览病区床位信息
        /// </summary>
        public void m_mthFindArea()
        {
            clsDcl_Charge objCharge = new clsDcl_Charge();
            DataTable dt = new DataTable();

            long l = objCharge.m_lngGetDeptArea(out dt, 2);
            if (l == 0)
            {
                return;
            }

            frmAreaBedInfo f = new frmAreaBedInfo(dt, 0);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.RegisterID = f.regid;
                this.m_objViewer.PatientID = f.pid;
                this.m_objViewer.Zyh = f.Zyh;
                this.m_objViewer.Zycs = f.Zycs;
                this.m_objViewer.PatName = f.patname;
                this.m_objViewer.InType = 1;

                clsPublic.m_mthWriteParm(f.regid, f.Zyh, f.CardNo);                
                this.m_objViewer.DialogResult = DialogResult.OK;
            }
        }
        #endregion

        #region 返回选择的病人信息
        /// <summary>
        /// 返回选择的病人信息
        /// </summary>
        public void m_mthGetPatientinfo()
        {
            if (this.m_objViewer.lsvPatient.Items.Count == 0 || this.m_objViewer.lsvPatient.SelectedItems.Count == 0)
            {
                return;
            }

            DataRow dr = (DataRow)(this.m_objViewer.lsvPatient.SelectedItems[0].Tag);

            if (dr["pstatus_int"].ToString() == "999")
            {
                if (!BlnInReg)
                {
                    MessageBox.Show("请选择住院病人！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            //else
            //{
            //    string[] statusinfo = new string[5] { "下床", "在床", "预出院", "实际出院", "请假" };
            //    int statusno = int.Parse(dr["pstatus_int"].ToString());
            //    if (statusno != this.m_objViewer.Status)
            //    {
            //        MessageBox.Show("当前病人为【" + statusinfo[statusno] + "】状态，请重新选择。", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        return;
            //    }
            //}
       
            this.m_objViewer.RegisterID = dr["registerid_chr"].ToString();
            this.m_objViewer.PatientID = dr["patientid_chr"].ToString();
            this.m_objViewer.Zyh = dr["inpatientid_chr"].ToString();
            this.m_objViewer.Zycs = int.Parse(dr["inpatientcount_int"].ToString());
            this.m_objViewer.CardNo = dr["patientcardid_chr"].ToString();
            this.m_objViewer.PatName = dr["lastname_vchr"].ToString();
            this.m_objViewer.OutDate = dr["cysj"].ToString();
            this.m_objViewer.InType = int.Parse(dr["inpatientnotype_int"].ToString());

            clsPublic.m_mthWriteParm(this.m_objViewer.RegisterID, this.m_objViewer.Zyh, this.m_objViewer.CardNo);
            this.m_objViewer.DialogResult = DialogResult.OK;
        }
        #endregion               
    }
}
