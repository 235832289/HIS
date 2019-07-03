using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.middletier.HI;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// clsControlChargeCheck 的摘要说明。
    /// </summary>
    public class clsControlChargeCheck : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsControlChargeCheck()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 设置窗体对象
        public com.digitalwave.iCare.gui.HIS.frmChargeCheck m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmChargeCheck)frmMDI_Child_Base_in;
        }
        #endregion

        #region 变量
        clsDomainControl_Register Domain = new clsDomainControl_Register();
        /// <summary>
        /// 保存返回的发票信息
        /// </summary>
        internal DataTable dtChargeCheck = null;
        /// <summary>
        /// 保存符合条件的发票信息
        /// </summary>
        DataTable dtFindCharge = null;
        /// <summary>
        /// 是否启用让利,1 可以,0 不可以
        /// 让利开关
        /// </summary>
        internal int intDiffPriceOn = 0;

        #endregion

        #region 初始化窗体
        private System.Data.DataView m_dvRegister = new System.Data.DataView();
        public void m_frmLoad()
        {

            decimal totalACCTSUM = 0;
            decimal totalSBSUM = 0;
            decimal totalSUM = 0;
            string strDateStart = this.m_objViewer.m_datFirstdate.Value.ToShortDateString();
            string strDateEnd = this.m_objViewer.m_datLastdate.Value.ToShortDateString();
            if (this.m_objViewer.Scope == "0")
            {
                Domain.m_lngGetChargeByDate(strDateStart, strDateEnd, out dtChargeCheck, this.m_objViewer.blnOnlySelectVip, this.m_objViewer.chkWechatRePrt.Checked);
            }
            else if (this.m_objViewer.Scope == "1")
            {
                Domain.m_lngGetChargeByempid(strDateStart, strDateEnd, this.m_objViewer.LoginInfo.m_strEmpID, out dtChargeCheck, this.m_objViewer.blnOnlySelectVip, this.m_objViewer.chkWechatRePrt.Checked);
            }
            intDiffPriceOn = clsPublic.m_intGetSysParm("9002"); // 让利启用开关
            #region 改变表的列名
            int n = -1;
            dtChargeCheck.Columns[++n].ColumnName = "诊疗卡号";
            dtChargeCheck.Columns[++n].ColumnName = "发票编号";
            dtChargeCheck.Columns[++n].ColumnName = "重打发票号";
            dtChargeCheck.Columns[++n].ColumnName = "流水号";
            dtChargeCheck.Columns[++n].ColumnName = "病人身份";
            dtChargeCheck.Columns[++n].ColumnName = "病人名称";
            dtChargeCheck.Columns[++n].ColumnName = "性别";
            dtChargeCheck.Columns[++n].ColumnName = "支付类型";
            dtChargeCheck.Columns[++n].ColumnName = "发票日期";
            dtChargeCheck.Columns[++n].ColumnName = "发票状态";
            dtChargeCheck.Columns[++n].ColumnName = "科室名称";
            dtChargeCheck.Columns[++n].ColumnName = "医生名称";
            dtChargeCheck.Columns[++n].ColumnName = "缴费状态";
            dtChargeCheck.Columns[++n].ColumnName = "记录时间";
            dtChargeCheck.Columns[++n].ColumnName = "收费员";
            dtChargeCheck.Columns[++n].ColumnName = "结帐员";
            dtChargeCheck.Columns[++n].ColumnName = "记帐金额";
            dtChargeCheck.Columns[++n].ColumnName = "自付金额";
            dtChargeCheck.Columns[++n].ColumnName = "合计金额";
            dtChargeCheck.Columns[++n].ColumnName = "处方号";
            ++n;
            dtChargeCheck.Columns[++n].ColumnName = "工作单位";
            // 总让利金额,实付金额
            if (intDiffPriceOn == 1)
            {
                dtChargeCheck.Columns[++n].ColumnName = "药品已让利";
                dtChargeCheck.Columns[++n].ColumnName = "实付金额";
            }

            #endregion
            if (dtChargeCheck.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtChargeCheck.Rows.Count; i1++)
                {
                    totalACCTSUM += Convert.ToDecimal(dtChargeCheck.Rows[i1]["记帐金额"].ToString());
                    totalSBSUM += Convert.ToDecimal(dtChargeCheck.Rows[i1]["自付金额"].ToString());
                    if (dtChargeCheck.Rows[i1]["合计金额"].ToString() != string.Empty)
                    {
                        totalSUM += Convert.ToDecimal(dtChargeCheck.Rows[i1]["合计金额"].ToString());
                    }
                    else
                    {
                        totalSUM += 0;
                    }
                }
                DataRow newRow = dtChargeCheck.NewRow();
                newRow["诊疗卡号"] = "总发票数";
                newRow["发票编号"] = dtChargeCheck.Rows.Count.ToString();
                newRow["结帐员"] = "总金额";
                newRow["记帐金额"] = totalACCTSUM;
                newRow["自付金额"] = totalSBSUM;
                newRow["合计金额"] = totalSUM;
                dtChargeCheck.Rows.Add(newRow);
            }
            this.m_dvRegister = dtChargeCheck.DefaultView;
            this.m_objViewer.DgChargeCheck.SetDataBinding(m_dvRegister, null);
            this.m_objViewer.DgChargeCheck.Tag = "dtChargeCheck";
            this.m_objViewer.DgChargeCheck.RowHeaderWidth = 10;
            this.m_objViewer.DgChargeCheck.m_SetDgrStyle();
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["发票日期"].Width += 6;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["诊疗卡号"].Width = 80;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["流水号"].Width = 100;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["记录时间"].Width = 120;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["性别"].Width = 40;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["科室名称"].Width = 120;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["收费员"].Width = 60;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["结帐员"].Width = 60;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["发票编号"].Width = 80;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["工作单位"].Width = 0;
            this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["重打发票号"].Width = 80;
            if (intDiffPriceOn == 1)
            {
                this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["药品已让利"].Width = 90;
            }
            #region 填充Combox
            if (this.m_objViewer.m_cboFildName.Items.Count == 0)
            {
                int j6 = 0;
                m_objViewer.m_cboSub1.Items.Add("");
                m_objViewer.m_cboSub2.Items.Add("");
                foreach (DataColumn dc in dtChargeCheck.Columns)
                {
                    j6++;
                    if (dc.ColumnName.IndexOf("ID") >= 0)
                    {
                        continue;
                    }
                    if (dc.ColumnName == "流水号" || dc.ColumnName == "性别" || dc.ColumnName == "记帐金额" || dc.ColumnName == "自付金额" || dc.ColumnName == "合计金额")
                        continue;
                    else if (j6 <= 20)
                    {
                        this.m_objViewer.m_cboFildName.Items.Add(dc.ColumnName);
                        this.m_objViewer.m_cboSub1.Items.Add(dc.ColumnName);
                        this.m_objViewer.m_cboSub2.Items.Add(dc.ColumnName);
                    }
                    if (this.m_objViewer.m_cboFildName.Items.Count > 0)
                    {
                        this.m_objViewer.m_cboFildName.SelectedIndex = 0;
                        this.m_objViewer.m_cboSub1.SelectedIndex = 0;
                        this.m_objViewer.m_cboSub2.SelectedIndex = 0;
                    }
                }
            }
            #endregion
        }
        #endregion
        #region 根据字段查询数据
        //public void m_mthGetChargeInfoByField(string[] m_strArr)
        //{
        //    decimal totalACCTSUM = 0;
        //    decimal totalSBSUM = 0;
        //    decimal totalSUM = 0;
        //    string strDateStart = this.m_objViewer.m_datFirstdate.Value.ToShortDateString();
        //    string strDateEnd = this.m_objViewer.m_datLastdate.Value.ToShortDateString();
        //    if (this.m_objViewer.Scope == "0")
        //    {
        //       // Domain.m_lngGetChargeByDate(strDateStart, strDateEnd, out dtChargeCheck);
        //        Domain.m_lngGetChargeByCondition(m_strArr, out dtChargeCheck);
        //    }
        //    else if (this.m_objViewer.Scope == "1")
        //    {
        //       // Domain.m_lngGetChargeByempid(strDateStart, strDateEnd, this.m_objViewer.LoginInfo.m_strEmpID, out dtChargeCheck);'
        //        Domain.m_lngGetChargeByEmpid(m_strArr, this.m_objViewer.LoginInfo.m_strEmpID, out dtChargeCheck);
        //    }
        //    #region 改变表的列名
        //    dtChargeCheck.Columns[0].ColumnName = "诊疗卡号";
        //    dtChargeCheck.Columns[1].ColumnName = "发票编号";
        //    dtChargeCheck.Columns[2].ColumnName = "流水号";
        //    dtChargeCheck.Columns[3].ColumnName = "病人身份";
        //    dtChargeCheck.Columns[4].ColumnName = "病人名称";
        //    dtChargeCheck.Columns[5].ColumnName = "性别";
        //    dtChargeCheck.Columns[6].ColumnName = "支付类型";
        //    dtChargeCheck.Columns[7].ColumnName = "发票日期";
        //    dtChargeCheck.Columns[8].ColumnName = "发票状态";
        //    dtChargeCheck.Columns[9].ColumnName = "科室名称";
        //    dtChargeCheck.Columns[10].ColumnName = "医生名称";
        //    dtChargeCheck.Columns[11].ColumnName = "缴费状态";
        //    dtChargeCheck.Columns[12].ColumnName = "记录时间";
        //    dtChargeCheck.Columns[13].ColumnName = "收费员";
        //    dtChargeCheck.Columns[14].ColumnName = "结帐员";
        //    dtChargeCheck.Columns[15].ColumnName = "记帐金额";
        //    dtChargeCheck.Columns[16].ColumnName = "自付金额";
        //    dtChargeCheck.Columns[17].ColumnName = "合计金额";
        //    dtChargeCheck.Columns[20].ColumnName = "工作单位";

        //    #endregion
        //    if (dtChargeCheck.Rows.Count > 0)
        //    {
        //        for (int i1 = 0; i1 < dtChargeCheck.Rows.Count; i1++)
        //        {
        //            totalACCTSUM += Convert.ToDecimal(dtChargeCheck.Rows[i1]["记帐金额"].ToString());
        //            totalSBSUM += Convert.ToDecimal(dtChargeCheck.Rows[i1]["自付金额"].ToString());
        //            totalSUM += Convert.ToDecimal(dtChargeCheck.Rows[i1]["合计金额"].ToString());
        //        }
        //        DataRow newRow = dtChargeCheck.NewRow();
        //        newRow["诊疗卡号"] = "总发票数";
        //        newRow["发票编号"] = dtChargeCheck.Rows.Count.ToString();
        //        newRow["结帐员"] = "总金额";
        //        newRow["记帐金额"] = totalACCTSUM;
        //        newRow["自付金额"] = totalSBSUM;
        //        newRow["合计金额"] = totalSUM;
        //        dtChargeCheck.Rows.Add(newRow);
        //    }
        //    this.m_dvRegister = dtChargeCheck.DefaultView;
        //    this.m_objViewer.DgChargeCheck.SetDataBinding(m_dvRegister, null);
        //    this.m_objViewer.DgChargeCheck.Tag = "dtChargeCheck";
        //    this.m_objViewer.DgChargeCheck.RowHeaderWidth = 10;
        //    this.m_objViewer.DgChargeCheck.m_SetDgrStyle();
        //    this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["诊疗卡号"].Width = 80;
        //    this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["流水号"].Width = 100;
        //    this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["记录时间"].Width = 120;
        //    this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["性别"].Width = 40;
        //    this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["科室名称"].Width = 120;
        //    this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["收费员"].Width = 60;
        //    this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["结帐员"].Width = 60;
        //    this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["发票编号"].Width = 80;
        //    this.m_objViewer.DgChargeCheck.TableStyles[0].GridColumnStyles["工作单位"].Width = 0;
        //    #region 填充Combox
        //    if (this.m_objViewer.m_cboFildName.Items.Count == 0)
        //    {
        //        int j6 = 0;
        //        foreach (DataColumn dc in dtChargeCheck.Columns)
        //        {
        //            j6++;
        //            if (dc.ColumnName.IndexOf("ID") >= 0)
        //            {
        //                continue;
        //            }
        //            if (dc.ColumnName == "流水号" || dc.ColumnName == "性别" || dc.ColumnName == "记帐金额" || dc.ColumnName == "自付金额" || dc.ColumnName == "合计金额")
        //                continue;
        //            else if (j6 <= 20)
        //                this.m_objViewer.m_cboFildName.Items.Add(dc.ColumnName);
        //            if (this.m_objViewer.m_cboFildName.Items.Count > 0)
        //                this.m_objViewer.m_cboFildName.SelectedIndex = 0;
        //        }
        //    }
        //    #endregion
        //}
        #endregion

        #region 查找数据
        DataView m_dvRegisterfind = new DataView();

        public void m_mthFindCharge()
        {
            if (this.m_objViewer.m_cboFildName.Text == "")
            {
                MessageBox.Show("请选择你要查找的字段！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_cboFildName.Focus();
                return;
            }
            if (this.m_objViewer.m_txtValuse.Text == "")
            {
                MessageBox.Show("请输入你要查找的内容！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtValuse.Focus();
                return;
            }
            try
            {
                dtFindCharge = dtChargeCheck.Clone();
            }
            catch
            {
            }
            dtFindCharge.Clear();
            for (int i1 = 0; i1 < dtChargeCheck.Rows.Count; i1++)
            {
                if (dtChargeCheck.Rows[i1][this.m_objViewer.m_cboFildName.Text].ToString().IndexOf(this.m_objViewer.m_txtValuse.Text.Trim(), 0) == 0
                    && (this.m_objViewer.m_cboSub1.SelectedIndex == 0 || dtChargeCheck.Rows[i1][this.m_objViewer.m_cboSub1.Text].ToString().IndexOf(this.m_objViewer.m_txtVal1.Text.Trim(), 0) == 0)
                    && (this.m_objViewer.m_cboSub2.SelectedIndex == 0 || dtChargeCheck.Rows[i1][this.m_objViewer.m_cboSub2.Text].ToString().IndexOf(this.m_objViewer.m_txtVal2.Text.Trim(), 0) == 0))
                {
                    DataRow AddRow = dtFindCharge.NewRow();
                    AddRow["诊疗卡号"] = dtChargeCheck.Rows[i1]["诊疗卡号"];
                    AddRow["发票编号"] = dtChargeCheck.Rows[i1]["发票编号"];
                    AddRow["流水号"] = dtChargeCheck.Rows[i1]["流水号"];
                    AddRow["病人身份"] = dtChargeCheck.Rows[i1]["病人身份"];
                    AddRow["病人名称"] = dtChargeCheck.Rows[i1]["病人名称"];
                    AddRow["性别"] = dtChargeCheck.Rows[i1]["性别"];
                    AddRow["支付类型"] = dtChargeCheck.Rows[i1]["支付类型"];
                    AddRow["发票日期"] = dtChargeCheck.Rows[i1]["发票日期"];
                    AddRow["发票状态"] = dtChargeCheck.Rows[i1]["发票状态"];
                    AddRow["科室名称"] = dtChargeCheck.Rows[i1]["科室名称"];
                    AddRow["医生名称"] = dtChargeCheck.Rows[i1]["医生名称"];
                    AddRow["缴费状态"] = dtChargeCheck.Rows[i1]["缴费状态"];
                    AddRow["记录时间"] = dtChargeCheck.Rows[i1]["记录时间"];
                    AddRow["收费员"] = dtChargeCheck.Rows[i1]["收费员"];
                    AddRow["结帐员"] = dtChargeCheck.Rows[i1]["结帐员"];
                    AddRow["记帐金额"] = dtChargeCheck.Rows[i1]["记帐金额"];
                    AddRow["自付金额"] = dtChargeCheck.Rows[i1]["自付金额"];
                    AddRow["合计金额"] = dtChargeCheck.Rows[i1]["合计金额"];
                    AddRow["处方号"] = dtChargeCheck.Rows[i1]["处方号"];
                    AddRow["重打发票号"] = dtChargeCheck.Rows[i1]["重打发票号"];

                    dtFindCharge.Rows.Add(AddRow);
                }
            }
            if (dtFindCharge.Rows.Count > 0)
            {
                double totalACCTSUM = 0.0000;
                double totalSBSUM = 0.0000;
                double totalSUM = 0.0000;
                for (int i1 = 0; i1 < dtFindCharge.Rows.Count; i1++)
                {
                    totalACCTSUM += Convert.ToDouble(dtFindCharge.Rows[i1]["记帐金额"].ToString());
                    totalSBSUM += Convert.ToDouble(dtFindCharge.Rows[i1]["自付金额"].ToString());
                    if (dtFindCharge.Rows[i1]["合计金额"].ToString() != string.Empty)
                    {
                        totalSUM += Convert.ToDouble(dtFindCharge.Rows[i1]["合计金额"].ToString());
                    }
                    else
                    {
                        totalSUM += 0;
                    }
                }
                DataRow newRow = dtFindCharge.NewRow();
                newRow["诊疗卡号"] = "总发票数";
                newRow["发票编号"] = dtFindCharge.Rows.Count.ToString();
                newRow["结帐员"] = "总金额";
                newRow["记帐金额"] = Double.Parse(totalACCTSUM.ToString("0.0000"));
                newRow["自付金额"] = Double.Parse(totalSBSUM.ToString("0.0000"));
                newRow["合计金额"] = Double.Parse(totalSUM.ToString("0.0000"));
                dtFindCharge.Rows.Add(newRow);
                m_dvRegisterfind = dtFindCharge.DefaultView;
                this.m_objViewer.DgChargeCheck.SetDataBinding(m_dvRegisterfind, null);
                this.m_objViewer.DgChargeCheck.Tag = "dtFindCharge";
                //				this.m_objViewer.buttonXP1.Enabled=false;
            }
            else
            {
                this.m_objViewer.DgChargeCheck.SetDataBinding(null, null);
            }
        }
        #endregion

        #region 返回所有的处方编号
        public string[] m_mthGetAll()
        {
            string[] strArry = null;
            if ((string)this.m_objViewer.DgChargeCheck.Tag == "dtFindCharge")
            {
                if (dtFindCharge.Rows.Count - 1 > 0)
                {
                    strArry = new string[dtFindCharge.Rows.Count - 1];
                    for (int i1 = 0; i1 < dtFindCharge.Rows.Count - 1; i1++)
                    {
                        strArry[i1] = dtFindCharge.Rows[i1]["处方号"].ToString();
                    }
                }
            }
            else
            {
                if (dtChargeCheck.Rows.Count - 1 > 0)
                {
                    strArry = new string[dtChargeCheck.Rows.Count - 1];
                    for (int i1 = 0; i1 < dtChargeCheck.Rows.Count - 1; i1++)
                    {
                        strArry[i1] = dtChargeCheck.Rows[i1]["处方号"].ToString();
                    }
                }
            }
            return strArry;
        }
        #endregion

        #region 显示发票分类明细数据
        /// <summary>
        /// 显示发票分类明细数据
        /// </summary>
        public void m_mthShowChargeDe()
        {
            if (dtChargeCheck.Rows.Count == 0 || this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber < 0)
            {
                return;
            }

            DataTable dtChargeDe = new DataTable();
            this.m_objViewer.LsvChargeDe.Items.Clear();

            string strINVOICENO = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 1].ToString();
            string strSEQID = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 3].ToString();

            if (strINVOICENO == "" || strSEQID == "")
                return;
            Domain.m_lngGetChargeDe(strINVOICENO, strSEQID, out  dtChargeDe);
            double totalMoney = 0.00, decMoney = 0;

            if (dtChargeDe.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtChargeDe.Rows.Count; i1++)
                {
                    ListViewItem addItem = new ListViewItem(dtChargeDe.Rows[i1]["TYPENAME_VCHR"].ToString());
                    decMoney = Convert.ToDouble(dtChargeDe.Rows[i1]["TOLFEE_MNY"].ToString());
                    if (string.Compare("0022", dtChargeDe.Rows[i1]["typeid_chr"].ToString()) == 0)
                    {
                        decMoney = Math.Abs(decMoney) * -1;//取负值
                    }
                    totalMoney += decMoney;
                    addItem.SubItems.Add("￥" + decMoney.ToString());
                    this.m_objViewer.LsvChargeDe.Items.Add(addItem);
                }
            }
            ListViewItem addItem1 = new ListViewItem("合计金额");
            addItem1.SubItems.Add("￥" + totalMoney.ToString());
            this.m_objViewer.LsvChargeDe.Items.Add(addItem1);
            this.m_objViewer.LsvChargeDe.Visible = true;
            this.m_objViewer.listView1.Visible = false;
        }
        #endregion

        #region IsOver
        public bool m_blisOver()
        {
            bool Over = false;
            if (this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 14].ToString() == "已结帐")
            {
                Over = true;
            }
            return Over;
        }
        #endregion

        #region 修改发票的支付类型

        public void m_mthModifiyType()
        {
            if (dtChargeCheck.Rows.Count == 0 && this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber < 0)
                return;

            DataTable dtChargeDe = new DataTable();
            this.m_objViewer.LsvChargeDe.Items.Clear();
            bool IsOver = false;

            string strINVOICENO = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 1].ToString();
            string strSEQID = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 3].ToString();
            if (this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 12].ToString() == "已结帐")
            {
                IsOver = true;
            }

            if (strINVOICENO == "" || strSEQID == "" || IsOver)
                return;
            if (MessageBox.Show("是否要修改支付类型？", "Icare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            long lngRes = Domain.m_lngModifiyType(this.m_objViewer.m_cobChang.SelectedIndex.ToString(), strINVOICENO, strSEQID, this.m_objViewer.LoginInfo.m_strEmpID);
            if ((string)this.m_objViewer.DgChargeCheck.Tag == "dtChargeCheck")
            {
                m_dvRegister[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["支付类型"] = this.m_objViewer.m_cobChang.Text;
            }
            else
            {
                m_dvRegisterfind[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["支付类型"] = this.m_objViewer.m_cobChang.Text; ;
            }
            this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 7] = this.m_objViewer.m_cobChang.Text; ;
        }
        #endregion

        #region 显示处方明细数据

        public void m_mthShowRecipeDe()
        {
            if (dtChargeCheck.Rows.Count == 0 && this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber < 0)
                return;

            DataTable dtChargeDe = new DataTable();
            this.m_objViewer.LsvChargeDe.Items.Clear();

            string strSEQID = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 3].ToString();
            if (strSEQID == "")
                return;
            this.m_objViewer.listView1.Items.Clear();
            Domain.m_lngGetRecipeDate(strSEQID, out  dtChargeDe);

            double MoneyAll = 0;
            string dblsbsum_mnyAll = "0";
            string dblACCTSUM_MNYAll = "0";
            if (dtChargeDe.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtChargeDe.Rows.Count; i1++)
                {
                    double totalMoney = 0;
                    ListViewItem addItem = new ListViewItem(dtChargeDe.Rows[i1]["NAME"].ToString().Trim());
                    addItem.SubItems.Add(dtChargeDe.Rows[i1]["DEC"].ToString().Trim());
                    addItem.SubItems.Add(dtChargeDe.Rows[i1]["PDCAREA_VCHR"].ToString().Trim());
                    addItem.SubItems.Add(dtChargeDe.Rows[i1]["UINT"].ToString().Trim());
                    addItem.SubItems.Add(dtChargeDe.Rows[i1]["PRICE"].ToString().Trim());
                    addItem.SubItems.Add(dtChargeDe.Rows[i1]["COUNT"].ToString().Trim());
                    totalMoney = double.Parse(dtChargeDe.Rows[i1]["COUNT"].ToString()) * double.Parse(dtChargeDe.Rows[i1]["PRICE"].ToString());
                    totalMoney = Convert.ToDouble(totalMoney.ToString("0.00"));
                    MoneyAll += totalMoney;
                    addItem.SubItems.Add(totalMoney.ToString().Trim());
                    addItem.SubItems.Add(dtChargeDe.Rows[i1]["DOCTORNAME_CHR"].ToString().Trim());
                    this.m_objViewer.listView1.Items.Add(addItem);

                    dblsbsum_mnyAll = double.Parse(dtChargeDe.Rows[i1]["sbsum_mny"].ToString()).ToString("0.00");
                    dblACCTSUM_MNYAll = double.Parse(dtChargeDe.Rows[i1]["ACCTSUM_MNY"].ToString()).ToString("0.00");
                }
            }
            ListViewItem addItem1 = new ListViewItem("自付金额");
            addItem1.SubItems.Add(dblsbsum_mnyAll);
            addItem1.SubItems.Add("记帐金额");
            addItem1.SubItems.Add(dblACCTSUM_MNYAll);
            addItem1.SubItems.Add("合计:");
            addItem1.SubItems.Add("");

            addItem1.SubItems.Add(MoneyAll.ToString());
            this.m_objViewer.listView1.Items.Add(addItem1);
            this.m_objViewer.listView1.Items[this.m_objViewer.listView1.Items.Count - 1].ForeColor = System.Drawing.Color.Red;
            this.m_objViewer.listView1.Items[this.m_objViewer.listView1.Items.Count - 1].Font = new System.Drawing.Font("宋体", 12);
            this.m_objViewer.listView1.Visible = true;
            this.m_objViewer.LsvChargeDe.Visible = false;
        }
        #endregion

        #region 开始打印
        clsOutpatientPrintRecipe_VO obj_VO = new clsOutpatientPrintRecipe_VO();
        clsPrintRecipeDetail objPrint = null;
        bool isOtherPage = false;
        public void m_mthBegionPrint(System.Drawing.Printing.PrintEventArgs e)
        {
            if (dtChargeCheck.Rows.Count == 0 && this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber < 0)
            {
                e.Cancel = true;
                return;
            }
            string strSEQID = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 3].ToString();
            DataTable dtChargeDe = new DataTable();
            DataView dv;
            if ((string)this.m_objViewer.DgChargeCheck.Tag == "dtChargeCheck")
            {
                dv = m_dvRegister;
                //strSEQID=m_dvRegister[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["流水号"].ToString();
            }
            else
            {
                dv = m_dvRegisterfind;
                //strSEQID=m_dvRegisterfind[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["流水号"].ToString();

            }
            if (strSEQID == "")
            {
                e.Cancel = true;
                return;
            }
            Domain.m_lngGetRecipeDate(strSEQID, out  dtChargeDe);//获取明细数据

            obj_VO.m_strHospitalName = this.m_objComInfo.m_strGetHospitalTitle();
            obj_VO.m_strPrintDate = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 13].ToString(); //dv[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["记录时间"].ToString();//打印时间
            obj_VO.m_strCardID = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 0].ToString();  //dv[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["诊疗卡号"].ToString();//打印时间
            obj_VO.strInvoiceNO = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 1].ToString(); //dv[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["发票编号"].ToString();//打印时间
            obj_VO.m_strPatientName = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 5].ToString(); //dv[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["病人名称"].ToString();//打印时间
            obj_VO.m_strPatientType = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 4].ToString();  //dv[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["病人身份"].ToString();//打印时间
            //			obj_VO.m_strPrintDate =dv[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["记录时间"].ToString();//打印时间
            //			obj_VO.m_strPrintDate =dv[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["记录时间"].ToString();//打印时间
            obj_VO.m_strChargeUp = "";
            obj_VO.m_strSelfPay = "";
            obj_VO.m_strEmployer = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 20].ToString(); // dv[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["工作单位"].ToString();
            obj_VO.m_strDiagDrName = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 11].ToString();  //dv[this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber]["医生名称"].ToString();
            ArrayList objItemArr = new ArrayList();
            decimal MoneyAll = 0;
            if (dtChargeDe.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dtChargeDe.Rows.Count; i1++)
                {
                    clsOutpatientPrintRecipeDetail_VO objDetail = new clsOutpatientPrintRecipeDetail_VO();
                    decimal totalMoney = 0;
                    objDetail.m_strChargeName = dtChargeDe.Rows[i1]["NAME"].ToString().Trim();
                    objDetail.m_strSpec = dtChargeDe.Rows[i1]["DEC"].ToString().Trim();
                    objDetail.m_strFrequency = dtChargeDe.Rows[i1]["PDCAREA_VCHR"].ToString().Trim();//这里用了频率存放了生产地
                    objDetail.m_strUnit = dtChargeDe.Rows[i1]["UINT"].ToString().Trim();
                    objDetail.m_strPrice = dtChargeDe.Rows[i1]["PRICE"].ToString().Trim();
                    objDetail.m_strCount = dtChargeDe.Rows[i1]["COUNT"].ToString().Trim();
                    if (dtChargeDe.Rows[i1]["NAME"].ToString().IndexOf("挂号费") != -1)
                    {
                        obj_VO.m_strRegisterFee = ((decimal)(clsConvertToDecimal.m_mthConvertObjToDecimal(dtChargeDe.Rows[i1]["COUNT"]) * clsConvertToDecimal.m_mthConvertObjToDecimal(dtChargeDe.Rows[i1]["PRICE"]))).ToString("0.00");
                    }
                    if (dtChargeDe.Rows[i1]["NAME"].ToString().IndexOf("诊金") != -1)
                    {
                        obj_VO.m_strTreatFee = ((decimal)(clsConvertToDecimal.m_mthConvertObjToDecimal(dtChargeDe.Rows[i1]["COUNT"]) * clsConvertToDecimal.m_mthConvertObjToDecimal(dtChargeDe.Rows[i1]["PRICE"]))).ToString("0.00");
                    }
                    totalMoney = clsConvertToDecimal.m_mthConvertObjToDecimal(dtChargeDe.Rows[i1]["COUNT"]) * clsConvertToDecimal.m_mthConvertObjToDecimal(dtChargeDe.Rows[i1]["PRICE"]);
                    totalMoney = Convert.ToDecimal(totalMoney.ToString("0.00"));
                    objDetail.m_strSumPrice = totalMoney.ToString("0.00");
                    MoneyAll += totalMoney;
                    objDetail.m_decTolDiffPrice = clsConvertToDecimal.m_mthConvertObjToDecimal(dtChargeDe.Rows[i1]["toldiffprice_mny"]);// 总让利金额
                    objItemArr.Add(objDetail);
                }
                if (dtChargeDe.Rows[0]["ACCTSUM_MNY"] != null && dtChargeDe.Rows[0]["ACCTSUM_MNY"].ToString().Trim() != string.Empty)
                {
                    obj_VO.m_strChargeUp = double.Parse(dtChargeDe.Rows[0]["ACCTSUM_MNY"].ToString()).ToString("0.00");
                }
                if (dtChargeDe.Rows[0]["sbsum_mny"] != null && dtChargeDe.Rows[0]["sbsum_mny"].ToString().Trim() != string.Empty)
                {
                    obj_VO.m_strSelfPay = double.Parse(dtChargeDe.Rows[0]["sbsum_mny"].ToString()).ToString("0.00");
                }
                obj_VO.strCheckOutName = dtChargeDe.Rows[0]["LASTNAME_VCHR"].ToString();
            }
            obj_VO.objPRDArr = objItemArr;
            obj_VO.m_strRecipePrice = MoneyAll.ToString("0.00");
            obj_VO.m_strINSURANCEID = Domain.m_strGetpatientidentityno(obj_VO.strInvoiceNO);
            isOtherPage = false;
            currRows = 0;
        }
        #endregion

        #region 打印
        int currRows = 0;
        public void m_mthPrint(System.Drawing.Printing.PrintPageEventArgs e)
        {
            objPrint = new clsPrintRecipeDetail(e, obj_VO);
            objPrint.m_mthBegionPrint(isOtherPage, ref currRows, this.intDiffPriceOn == 1);
            isOtherPage = true;
        }
        #endregion

        #region 重打发票
        /// <summary>
        /// 重打发票
        /// </summary>
        /// <param name="seqid"></param>
        /// <param name="invono"></param>
        public void m_mthReprintinvo()
        {
            if (dtChargeCheck.Rows.Count == 0 || this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber < 0)
            {
                return;
            }

            string seqid = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 3].ToString();

            if (seqid == "")
            {
                return;
            }

            this.m_objViewer.Cursor = Cursors.WaitCursor;
            clsCalcPatientCharge objCalPatientCharge = new clsCalcPatientCharge(this.m_objComInfo.m_strGetHospitalTitle());
            com.digitalwave.Utility.clsLogText objlog = new com.digitalwave.Utility.clsLogText();
            objlog.LogError(this.m_objComInfo.m_strGetHospitalTitle());
            objCalPatientCharge.m_mthReprintinvoice(seqid, this.m_objViewer.LoginInfo.m_strEmpID, 0);
            this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region 显示医保记帐单号
        /// <summary>
        /// 显示医保记帐单号
        /// </summary>
        public void m_mthShowBillNo()
        {
            if (dtChargeCheck.Rows.Count == 0 || this.m_objViewer.DgChargeCheck.CurrentCell.RowNumber < 0)
            {
                return;
            }

            //发票号
            string InvoNo = this.m_objViewer.DgChargeCheck[this.m_objViewer.DgChargeCheck.CurrentRowIndex, 1].ToString();
            string BillNo = Domain.m_strGetBillNoByInvoNo(InvoNo);
            if (BillNo.Trim() != "")
            {
                this.m_objViewer.lblBillNo.Text = "医保记帐单号：" + BillNo;
            }
            else
            {
                this.m_objViewer.lblBillNo.Text = "";
            }

        }
        #endregion
    }
}
