using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using Microsoft.VisualBasic;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 补期帐UI
    /// </summary>
    public partial class frmPatchDayAccount : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 构造
        /// </summary>
        public frmPatchDayAccount()
        {
            InitializeComponent();
            objSvc = new clsDcl_Charge();
        }

        /// <summary>
        /// 构造
        /// </summary>
        public frmPatchDayAccount(clsBihPatient_VO Patient_VO)
        {
            InitializeComponent();
            BihPatient_VO = Patient_VO;
            objSvc = new clsDcl_Charge();
        }

        #region 变量
        /// <summary>
        /// 住院病人资料VO
        /// </summary>
        private clsBihPatient_VO BihPatient_VO = null;
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_Charge objSvc;        
        /// <summary>
        /// 收费项目发票分类
        /// </summary>
        private DataTable dtChargeItemCat;
        /// <summary>
        /// 科室列表
        /// </summary>
        private DataTable dtDeptArea;
        /// <summary>
        /// 当前行号
        /// </summary>
        internal int CurrRowNo = -1;
        /// <summary>
        /// 修改标志
        /// </summary>
        private bool modifyflag = false;
        /// <summary>
        /// 修改标志
        /// </summary>
        public bool ModifyFlag
        {
            get
            {
                return modifyflag;
            }
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void m_mthInit()
        {
            //初始化主管医生
            //医生列表
            clsColumns_VO[] columArr = new clsColumns_VO[]{ new clsColumns_VO("工号","empno_chr",HorizontalAlignment.Left,50),
                                                            new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                                                            new clsColumns_VO("姓名","doctorname",HorizontalAlignment.Left,80),
                                                            new clsColumns_VO("","empid_chr",HorizontalAlignment.Left,0)
                                                          };

            string SqlSource = @"select empid_chr, empno_chr, pycode_chr, lastname_vchr as doctorname
                                   from t_bse_employee 
                                  where status_int = 1                                     
                               order by empno_chr";
            //and hasprescriptionright_chr = '1' 具有处方权限

            this.txtChargeDoctor.m_strSQL = SqlSource;
            this.txtChargeDoctor.m_mthInitListView(columArr);
            this.txtChargeDoctor.m_listView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            //初始化执行地点
            //地点列表
            columArr = new clsColumns_VO[]{ new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                                            new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                                            new clsColumns_VO("地点名称","deptname_vchr",HorizontalAlignment.Left,130),
                                            new clsColumns_VO("","deptid_chr",HorizontalAlignment.Left,0)
                                          };
            
            SqlSource = @"select deptid_chr, deptname_vchr, pycode_chr, code_vchr
                            from t_bse_deptdesc
                           where status_int = 1
                        order by code_vchr";

            this.txtApplyArea.m_strSQL = SqlSource;
            this.txtApplyArea.m_mthInitListView(columArr);
            this.txtApplyArea.m_listView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            //填充默认开单科室、开单人
            this.txtApplyArea.m_mthFindAndSelect(this.LoginInfo.m_strInpatientAreaID);
            this.txtChargeDoctor.m_mthFindAndSelect(this.LoginInfo.m_strEmpID);

            this.m_mthGetCat();

            this.m_mthGetDeptList();
        }
        #endregion

        #region 查找收费项目
        /// <summary>
        /// 查找收费项目
        /// </summary>
        /// <param name="FindStr"></param>
        public void m_mthFindChargeItem(string FindStr)
        {
            if (FindStr.Trim() == "")
            {
                return;
            }

            string PatType = this.BihPatient_VO.PayTypeID;
            if (PatType == "")
            {
                MessageBox.Show("请明确费别！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (FindStr.Trim().Length == 1 && (FindStr.Trim() == "?" || FindStr.Trim() == @"\"))
            {
                if (this.txtApplyArea.Value == null || this.txtApplyArea.Text.Trim() == "")
                {
                    MessageBox.Show("请选择开单地点。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtApplyArea.Focus();
                    return;
                }

                if (this.txtChargeDoctor.Value == null || this.txtChargeDoctor.Text.Trim() == "")
                {
                    MessageBox.Show("请选择开单医生。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtChargeDoctor.Focus();
                    return;
                }

                if (FindStr.Trim() == "?")
                {
                    frmUsageAddItem fItem = new frmUsageAddItem(this.BihPatient_VO.PayTypeID, this.txtApplyArea.Value.ToString());
                    if (fItem.ShowDialog() == DialogResult.OK)
                    {
                        this.m_mthAddItem(fItem.DrArr, fItem.Nums);
                    }
                }
                else if (FindStr.Trim() == @"\")
                {
                    frmItemGroup fItem = new frmItemGroup(this.BihPatient_VO.PayTypeID, this.txtApplyArea.Value.ToString());
                    if (fItem.ShowDialog() == DialogResult.OK)
                    {
                        this.m_mthAddItem(fItem.DrArr, fItem.Nums);
                    }
                }
            }
            else
            {
                this.lsvItem.BeginUpdate();
                this.lsvItem.Items.Clear();

                DataTable dt;
                long l = this.objSvc.m_lngFindChargeItem(FindStr, PatType, out dt);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string invocat = m_strConvertToChType(dt.Rows[i]["itemipinvtype_chr"].ToString().Trim());   //发票分类 flag_int = 4
                        ListViewItem lv = new ListViewItem(FindStr);
                        lv.SubItems.Add(dt.Rows[i]["itemcode_vchr"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["itemname_vchr"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["itemcommname_vchr"].ToString().Trim());
                        lv.SubItems.Add(invocat);
                        lv.SubItems.Add(dt.Rows[i]["itemspec_vchr"].ToString().Trim());
                        //如果已用的是最小单位,就用小单价和最小单位                      
                        if (dt.Rows[i]["ipchargeflg_int"].ToString().Trim() == "1")
                        {
                            lv.SubItems.Add(dt.Rows[i]["itemipunit_chr"].ToString().Trim());
                            lv.SubItems.Add(dt.Rows[i]["submoney"].ToString().Trim());
                        }
                        else
                        {
                            lv.SubItems.Add(dt.Rows[i]["itemunit_chr"].ToString().Trim());
                            lv.SubItems.Add(dt.Rows[i]["itemprice_mny"].ToString().Trim());
                        }

                        string PRECENT_DEC = "100";
                        if (dt.Rows[i]["precent_dec"].ToString().Trim() != "")
                        {
                            PRECENT_DEC = dt.Rows[i]["precent_dec"].ToString().Trim();
                        }
                        lv.SubItems.Add(PRECENT_DEC + "%"); //收费比例  
                        lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());

                        if (invocat.IndexOf("中") >= 0 || invocat.IndexOf("西") >= 0)
                        {
                            if (dt.Rows[i]["ipnoqtyflag_int"].ToString().Trim() != "0")
                            {
                                lv.SubItems.Add("缺药");
                                lv.ForeColor = Color.Red;
                            }
                            else
                            {
                                lv.SubItems.Add("");
                            }
                        }
                        else
                        {
                            lv.SubItems.Add("");
                        }

                        lv.Tag = dt.Rows[i];
                        this.lsvItem.Items.Add(lv);
                    }
                    this.panelItem.Height = 200;
                    this.lsvItem.Items[0].Selected = true;
                    this.lsvItem.Focus();
                }

                this.lsvItem.EndUpdate();
            }
        }
        #endregion

        #region 获取收费项目发票分类
        /// <summary>
        /// 获取收费项目发票分类
        /// </summary>
        private void m_mthGetCat()
        {
            long l = this.objSvc.m_lngGetChargeItemCat(4, out dtChargeItemCat);
        }
        #endregion

        #region 获取科室列表
        /// <summary>
        /// 获取科室列表
        /// </summary>
        private void m_mthGetDeptList()
        {
            long l = this.objSvc.m_lngGetDeptArea(out dtDeptArea, 1);
        }
        #endregion

        #region 根据ID转换成中文类别
        /// <summary>
        /// 根据ID转换成中文类别
        /// </summary>
        /// <param name="TypeNo"></param>
        /// <returns></returns>
        private string m_strConvertToChType(string TypeNo)
        {
            string Ret = "";

            for (int i = 0; i < dtChargeItemCat.Rows.Count; i++)
            {
                if (TypeNo == dtChargeItemCat.Rows[i]["typeid_chr"].ToString())
                {
                    Ret = dtChargeItemCat.Rows[i]["typename_vchr"].ToString();
                    break;
                }
            }

            return Ret;
        }
        #endregion

        #region 选择收费项目
        /// <summary>
        /// 选择收费项目
        /// </summary>        
        public void m_mthSelectItem()
        {
            if (this.lsvItem.Items.Count == 0 || this.lsvItem.SelectedItems.Count == 0)
            {
                return;
            }

            DataRow dr = this.lsvItem.SelectedItems[0].Tag as DataRow;

            string ItemName = dr["itemname_vchr"].ToString().Trim();
            string ItemSpe = dr["itemspec_vchr"].ToString().Trim();
            string ItemUnit, ItemPrice;
            if (dr["ipchargeflg_int"].ToString().Trim() == "1")
            {
                ItemUnit = dr["itemipunit_chr"].ToString().Trim();
                ItemPrice = dr["submoney"].ToString().Trim();
            }
            else
            {
                ItemUnit = dr["itemunit_chr"].ToString().Trim();
                ItemPrice = dr["itemprice_mny"].ToString().Trim();
            }

            string Precent = "100";
            if (dr["precent_dec"].ToString().Trim() != "")
            {
                Precent = dr["precent_dec"].ToString().Trim();
            }

            //填充主项目
            this.txtItemName.Text = ItemName;
            this.lblStandard.Text = ItemSpe;
            this.lblUnit.Text = ItemUnit;
            this.lblPrice.Text = ItemPrice;

            //填充默认执行地点
            string ApplyAreaID = "";
            if (this.txtApplyArea.Value != null)
            {
                ApplyAreaID = this.txtApplyArea.Value.ToString().Trim();
            }

            string ItemId = dr["itemid_chr"].ToString();
            string ExecAreaName = "";
            string ExecAreaID = this.objSvc.m_strGetChargeItemDefaultExecAreaID(ItemId, ApplyAreaID, out ExecAreaName);
            if (ExecAreaID == "")
            {
                this.m_mthLoadExecArea(1, null);
            }
            else
            {
                this.m_mthLoadExecArea(2, ItemId);
            }

            this.txtExecArea.m_mthFindAndSelect(ExecAreaID);

            this.txtItemName.Tag = dr;

            this.txtAmount.Focus();
        }
        #endregion

        #region 动态加载执行地点
        /// <summary>
        /// 动态加载执行地点
        /// </summary>
        /// <param name="Flag">1 全部科室 2 项目执行分类所对应的科室列表</param>
        /// <param name="ItemID"></param>
        public void m_mthLoadExecArea(int Flag, string ItemID)
        {
            string SqlSource = "";

            clsColumns_VO[] columArr = new clsColumns_VO[]{ new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                                                             new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                                                             new clsColumns_VO("地点名称","deptname_vchr",HorizontalAlignment.Left,130),
                                                             new clsColumns_VO("","deptid_chr",HorizontalAlignment.Left,0)
                                                           };

            if (Flag == 1)
            {
                SqlSource = @"select deptid_chr, deptname_vchr, pycode_chr, code_vchr
                                from t_bse_deptdesc
                               where status_int = 1
                            order by code_vchr";
            }
            else if (Flag == 2)
            {
                SqlSource = @"select a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr
                                from t_bse_deptdesc a,
                                     t_aid_bih_ocdeptlist b,
                                     t_bse_chargeitem c
                               where a.status_int = 1 
                                 and a.deptid_chr = b.clacarea_chr 
                                 and b.ordercateid_chr = c.ordercateid_chr
                                 and c.itemid_chr = '" + ItemID + @"' 
                            order by a.code_vchr";
            }

            this.txtExecArea.m_strSQL = SqlSource;
            this.txtExecArea.m_mthInitListView(columArr);
            this.txtExecArea.m_listView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));            
        }
        #endregion

        #region 根据科室病区ID获取名称
        /// <summary>
        /// 根据科室病区ID获取名称
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        private string m_strGetDeptName(string ID)
        {
            string DeptName = "";

            for (int i = 0; i < dtDeptArea.Rows.Count; i++)
            {
                if (dtDeptArea.Rows[i]["deptid_chr"].ToString().Trim() == ID.Trim())
                {
                    DeptName = dtDeptArea.Rows[i]["deptname_vchr"].ToString();
                    break;
                }
            }

            return DeptName;
        }
        #endregion

        #region 清空编辑栏
        /// <summary>
        /// 清空编辑栏
        /// </summary>
        public void m_mthClear()
        {
            this.txtItemName.Tag = null;
            this.txtItemName.Text = "";
            this.lblStandard.Text = "";
            this.lblUnit.Text = "";
            this.lblPrice.Text = "";
            this.txtAmount.Text = "";
            this.lblTotal.Text = "";
            this.txtExecArea.Value = null;
            this.txtExecArea.Text = "";

            this.txtItemName.Focus();
        }
        #endregion

        #region 添加项目
        /// <summary>
        /// 添加项目
        /// </summary>
        public void m_mthAddItem()
        {
            if (this.txtItemName.Tag == null)
            {
                return;
            }

            if (this.txtAmount.Text.Trim() == "-")
            {
                this.txtAmount.Text = "";
            }

            if (this.txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("请输入数量。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAmount.Focus();
                return;
            }

            if (!Microsoft.VisualBasic.Information.IsNumeric(this.txtAmount.Text.Trim()))
            {
                MessageBox.Show("数量输入错误，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtAmount.SelectAll();
                this.txtAmount.Focus();
                return;
            }

            if (this.lblTotal.Text.Trim() == "")
            {
                MessageBox.Show("金额不能为空。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.txtApplyArea.Value == null || this.txtApplyArea.Text.Trim() == "")
            {
                MessageBox.Show("请选择开单地点。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtApplyArea.Focus();
                return;
            }

            if (this.txtChargeDoctor.Value == null || this.txtChargeDoctor.Text.Trim() == "")
            {
                MessageBox.Show("请选择开单医生。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtChargeDoctor.Focus();
                return;
            }

            if (this.txtExecArea.Value == null || this.txtExecArea.Text.Trim() == "")
            {
                MessageBox.Show("请选择执行地点。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtExecArea.Focus();
                return;
            }

            DataRow dr = this.txtItemName.Tag as DataRow;

            string invocat = this.m_strConvertToChType(dr["itemipinvtype_chr"].ToString().Trim());
         
            string[] sItem = new string[17];

            sItem[0] = Convert.ToString(this.dtgItem.Rows.Count + 1);
            sItem[1] = this.txtExecArea.Text.Trim();
            sItem[2] = dr["itemcode_vchr"].ToString().Trim();
            sItem[3] = dr["itemname_vchr"].ToString().Trim();
            sItem[4] = dr["itemspec_vchr"].ToString().Trim();

            string ItemUnit, ItemPrice;
            if (dr["ipchargeflg_int"].ToString().Trim() == "1")
            {
                ItemUnit = dr["itemipunit_chr"].ToString().Trim();
                ItemPrice = dr["submoney"].ToString().Trim();
            }
            else
            {
                ItemUnit = dr["itemunit_chr"].ToString().Trim();
                ItemPrice = dr["itemprice_mny"].ToString().Trim();
            }
            sItem[5] = ItemUnit;
            sItem[6] = this.txtAmount.Text.Trim();
            sItem[7] = ItemPrice;
            sItem[8] = Convert.ToDecimal(this.lblTotal.Text).ToString("0.00");

            string Precent = "100";
            if (dr["precent_dec"].ToString().Trim() != "")
            {
                Precent = dr["precent_dec"].ToString().Trim();
            }
            sItem[9] = Precent;

            decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(sItem[8]) * clsPublic.ConvertObjToDecimal(sItem[9]) / 100, 2);
            sItem[10] = d.ToString("0.00");
            sItem[11] = this.txtApplyArea.Value;
            sItem[12] = this.txtChargeDoctor.Value;
            sItem[13] = this.txtExecArea.Value;
            sItem[14] = "0";  //0 新建 1 历史记录
            sItem[15] = invocat;
            sItem[16] = this.txtChargeDoctor.Text;

            int row = this.dtgItem.Rows.Add(sItem);
            this.dtgItem.Rows[row].Tag = dr;
            this.dtgItem.Rows[row].Selected = true;
            this.CurrRowNo = row;

            d += clsPublic.ConvertObjToDecimal(this.lblAllTotal.Text);
            this.lblAllTotal.Text = d.ToString("0.00");

            this.m_mthClear();
        }
        #endregion

        #region 批量添加项目
        /// <summary>
        /// 批量添加项目
        /// </summary>
        /// <param name="objArr"></param>
        /// <param name="Nums"></param>       
        public void m_mthAddItem(ArrayList objArr, int Nums)
        {
            for (int i = 0; i < objArr.Count; i++)
            {
                DataRow dr = objArr[i] as DataRow;

                string ExecAreaID = "";

                if (dr["areaid1"].ToString().Trim() == "")
                {
                    ExecAreaID = dr["areaid2"].ToString().Trim();
                }
                else
                {
                    ExecAreaID = dr["areaid1"].ToString().Trim();
                }

                string[] sItem = new string[17];

                sItem[0] = Convert.ToString(this.dtgItem.Rows.Count + 1);
                sItem[1] = this.m_strGetDeptName(ExecAreaID);
                sItem[2] = dr["itemcode_vchr"].ToString().Trim();
                sItem[3] = dr["itemname_vchr"].ToString().Trim();
                sItem[4] = dr["itemspec_vchr"].ToString().Trim();

                string ItemUnit, ItemPrice;
                if (dr["ipchargeflg_int"].ToString().Trim() == "1")
                {
                    ItemUnit = dr["itemipunit_chr"].ToString().Trim();
                    ItemPrice = dr["submoney"].ToString().Trim();
                }
                else
                {
                    ItemUnit = dr["itemunit_chr"].ToString().Trim();
                    ItemPrice = dr["itemprice_mny"].ToString().Trim();
                }
                sItem[5] = ItemUnit;
                sItem[6] = Convert.ToString(clsPublic.ConvertObjToDecimal(dr["amount"]) * Nums);
                sItem[7] = ItemPrice;

                decimal d = clsPublic.ConvertObjToDecimal(sItem[6]) * clsPublic.ConvertObjToDecimal(sItem[7]);

                sItem[8] = d.ToString("0.00");

                string Precent = "100";
                if (dr["precent_dec"].ToString().Trim() != "")
                {
                    Precent = dr["precent_dec"].ToString().Trim();
                }
                sItem[9] = Precent;
                sItem[10] = Convert.ToDecimal(d * clsPublic.ConvertObjToDecimal(sItem[9]) / 100).ToString("0.00");
                sItem[11] = this.txtApplyArea.Value;
                sItem[12] = this.txtChargeDoctor.Value;
                sItem[13] = ExecAreaID;
                sItem[14] = "0";  //0 新建 1 历史记录
                sItem[15] = this.m_strConvertToChType(dr["itemipinvtype_chr"].ToString().Trim());
                sItem[16] = this.txtChargeDoctor.Text;

                int row = this.dtgItem.Rows.Add(sItem);
                this.dtgItem.Rows[row].Tag = dr;
                this.dtgItem.Rows[row].Selected = true;
                this.CurrRowNo = row;

                d += clsPublic.ConvertObjToDecimal(this.lblAllTotal.Text);
                this.lblAllTotal.Text = d.ToString("0.00");
            }

            this.m_mthClear();
        }
        #endregion

        #region 删除项目
        /// <summary>
        /// 删除项目
        /// </summary>        
        public void m_mthDelItem()
        {
            int RowNo = this.CurrRowNo;

            if (RowNo < 0)
            {
                return;
            }

            DataRow dr = this.dtgItem.Rows[RowNo].Tag as DataRow;
            string ItemName = "";
            if (this.dtgItem.Rows[RowNo].Cells["flag"].Value.ToString() == "0")
            {
                ItemName = dr["itemname_vchr"].ToString().Trim();
            }
            else
            {
                ItemName = dr["chargeitemname_chr"].ToString().Trim();
            }

            if (MessageBox.Show("是否删除收费项目：【" + ItemName + "】?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                decimal d = clsPublic.ConvertObjToDecimal(this.lblAllTotal.Text) - clsPublic.ConvertObjToDecimal(this.dtgItem.Rows[RowNo].Cells["total"].Value);
                this.lblAllTotal.Text = d.ToString("0.00");

                this.dtgItem.Rows.RemoveAt(RowNo);
                if (RowNo >= this.dtgItem.Rows.Count)
                {
                    this.CurrRowNo = this.dtgItem.Rows.Count - 1;
                }
            }
        }
        #endregion

        #region 保存(补期帐)
        /// <summary>
        /// 保存(补期帐)
        /// </summary>
        public void m_mthSave()
        {
            if (this.dtgItem.Rows.Count == 0)
            {
                MessageBox.Show("请录入收费项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }                       

            frmAidDayAccountList f = new frmAidDayAccountList(this.BihPatient_VO.RegisterID);
            if (f.ShowDialog() == DialogResult.OK)
            {
                clsPublic.PlayAvi("findFILE.avi", "正在调整期帐信息，请稍候...");

                string DayAccountID = f.DayAccountID;
                string ActiveDat = f.ActiveDat;
                ArrayList PatientChargeArr = new ArrayList();

                for (int i = 0; i < this.dtgItem.Rows.Count; i++)
                {
                    clsBihPatientCharge_VO PatientCharge_VO = new clsBihPatientCharge_VO();

                    DataRow dr = this.dtgItem.Rows[i].Tag as DataRow;

                    PatientCharge_VO.DayaccountID = DayAccountID;
                    PatientCharge_VO.PatientID = this.BihPatient_VO.PatientID;
                    PatientCharge_VO.RegisterID = this.BihPatient_VO.RegisterID;
                    PatientCharge_VO.ClacArea = this.dtgItem.Rows[i].Cells["execareaid"].Value.ToString();
                    PatientCharge_VO.CreateArea = this.dtgItem.Rows[i].Cells["applyareaid"].Value.ToString();
                    PatientCharge_VO.CalcCateID = dr["itemipcalctype_chr"].ToString();
                    PatientCharge_VO.InvCateID = dr["itemipinvtype_chr"].ToString();
                    PatientCharge_VO.ChargeItemID = dr["itemid_chr"].ToString();
                    PatientCharge_VO.ChargeItemName = dr["itemname_vchr"].ToString();

                    if (dr["ipchargeflg_int"].ToString().Trim() == "1")
                    {
                        PatientCharge_VO.Unit = dr["itemipunit_chr"].ToString().Trim();
                        PatientCharge_VO.UnitPrice = clsPublic.ConvertObjToDecimal(dr["submoney"]);
                    }
                    else
                    {
                        PatientCharge_VO.Unit = dr["itemunit_chr"].ToString().Trim();
                        PatientCharge_VO.UnitPrice = clsPublic.ConvertObjToDecimal(dr["itemprice_mny"]);
                    }

                    PatientCharge_VO.Amount = clsPublic.ConvertObjToDecimal(this.dtgItem.Rows[i].Cells["amount"].Value);
                    PatientCharge_VO.Discount = clsPublic.ConvertObjToDecimal(this.dtgItem.Rows[i].Cells["scale"].Value);
                    PatientCharge_VO.Ismepay = 0;
                    PatientCharge_VO.Des = "";
                    PatientCharge_VO.CreateType = 4;
                    PatientCharge_VO.Creator = this.LoginInfo.m_strEmpID;
                    PatientCharge_VO.Operator = this.LoginInfo.m_strEmpID;
                    PatientCharge_VO.PStatus = 2;
                    PatientCharge_VO.Activator = this.dtgItem.Rows[i].Cells["applydoctorid"].Value.ToString();
                    PatientCharge_VO.ActivateType = 1;
                    PatientCharge_VO.IsRich = int.Parse(dr["isrich_int"].ToString());
                    PatientCharge_VO.CurAreaID = this.BihPatient_VO.AreaID;
                    PatientCharge_VO.CurBedID = this.BihPatient_VO.BedID;
                    PatientCharge_VO.DoctorID = this.BihPatient_VO.DoctorID;
                    PatientCharge_VO.Doctor = this.BihPatient_VO.DoctorName;
                    PatientCharge_VO.DoctorGroupID = this.BihPatient_VO.DoctorGroupID;
                    PatientCharge_VO.NeedConfirm = 0;
                    PatientCharge_VO.ActiveDat = ActiveDat;
                    PatientCharge_VO.TotalMoney_dec = clsPublic.Round(PatientCharge_VO.UnitPrice * PatientCharge_VO.Amount, 2);
                    PatientCharge_VO.AcctMoney_dec = PatientCharge_VO.TotalMoney_dec - clsPublic.Round(PatientCharge_VO.UnitPrice * PatientCharge_VO.Amount * PatientCharge_VO.Discount / 100, 2);
                    PatientCharge_VO.CHARGEDOCTORID_CHR = this.dtgItem.Rows[i].Cells["applydoctorid"].Value.ToString();
                    PatientCharge_VO.CHARGEDOCTOR_VCHR = this.dtgItem.Rows[i].Cells["colChargeDoctorName"].Value.ToString();

                    PatientChargeArr.Add(PatientCharge_VO);
                }

                long l = this.objSvc.m_lngPatchDayAccount(PatientChargeArr, DayAccountID);

                clsPublic.CloseAvi();

                if (l > 0)
                {
                    MessageBox.Show("补期帐成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.btnAdd.Enabled = false;
                    this.btnDel.Enabled = false;
                    this.btnSave.Enabled = false;
                    this.btnSave.Tag = DayAccountID;

                    modifyflag = true;
                }
                else
                {
                    MessageBox.Show("补期帐失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        #endregion

        private void frmPatchDayAccount_Load(object sender, EventArgs e)
        {
            this.panelItem.Height = 0;

            if (BihPatient_VO != null)
            {
                this.lblZyh.Text = BihPatient_VO.Zyh;
                this.lblName.Text = BihPatient_VO.Name;
                this.lblSex.Text = BihPatient_VO.Sex;
                this.lblArea.Text = BihPatient_VO.AreaName;
                this.lblBed.Text = BihPatient_VO.BedNO + "床";
                this.lblFee.Text = BihPatient_VO.BalanceMoney.ToString("###,##0.00");
                if (BihPatient_VO.BalanceMoney >= 0)
                {
                    this.lblFee.ForeColor = Color.Blue;
                }
                else
                {
                    this.lblFee.ForeColor = Color.Red;
                }                
            }

            this.m_mthInit();
        }

        private void frmPatchDayAccount_Activated(object sender, EventArgs e)
        {
            this.txtItemName.Focus();
        }

        private void frmPatchDayAccount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (this.panelItem.Height > 0)
                {
                    this.panelItem.Height = 0;
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void frmPatchDayAccount_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("是否退出补期帐窗口？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtApplyArea_ItemSelectedOK(object s, EventArgs e)
        {
            if (this.txtApplyArea.Value != null && this.txtApplyArea.Value.ToString().Trim() != "")
            {
                this.txtChargeDoctor.Focus();
            }
        }

        private void txtChargeDoctor_ItemSelectedOK(object s, EventArgs e)
        {
            if (this.txtChargeDoctor.Value != null && this.txtChargeDoctor.Value.ToString().Trim() != "")
            {
                this.txtItemName.Focus();
            }
        }

        private void dtgItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.CurrRowNo = e.RowIndex;
        }

        private void txtAmount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.txtAmount.Text.Trim() == "-")
                {
                    return;
                }

                this.lblTotal.Text = clsPublic.Round(clsPublic.ConvertObjToDecimal(this.txtAmount.Text) * clsPublic.ConvertObjToDecimal(this.lblPrice.Text), 2).ToString();
                if (this.txtExecArea.Value != null && this.txtExecArea.Value.ToString().Trim() != "")
                {
                    this.btnAdd.Focus();
                }
                else
                {
                    this.txtExecArea.Focus();
                }
            }
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            string val = this.txtAmount.Text.Trim();

            if (val == "")
            {
                return;
            }
            else
            {
                if (val != "-")
                {
                    if (!Microsoft.VisualBasic.Information.IsNumeric(val))
                    {
                        MessageBox.Show("数量输入错误，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtAmount.Text = "";
                        this.txtAmount.Focus();
                        return;
                    }

                    if (Convert.ToDecimal(val) == 0)
                    {
                        MessageBox.Show("数量必须是不等于0的整数，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.txtAmount.Text = "";
                        this.txtAmount.Focus();
                        return;
                    }
                }
            } 
        }

        private void txtExecArea_ItemSelectedOK(object s, EventArgs e)
        {
            if (this.txtExecArea.Value != null && this.txtExecArea.Value.ToString().Trim() != "")
            {
                this.btnAdd.Focus();
            } 
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (this.dtgItem.Rows.Count > 0)
            {
                if (this.btnSave.Tag == null || this.btnSave.Tag.ToString().Trim() == "")
                {
                    if (MessageBox.Show("录入的收费项目未补充到指定的帐期, 是否重新录入?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return;
                    }
                }                
            }
                        
            this.m_mthClear();
            this.CurrRowNo = -1;
            this.lblAllTotal.Text = "";
            this.dtgItem.Rows.Clear();

            this.btnAdd.Enabled = true;
            this.btnDel.Enabled = true;
            this.btnSave.Enabled = true;
            this.btnSave.Tag = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.m_mthAddItem();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.m_mthDelItem();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.m_mthSave();
        }

        private void txtItemName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthFindChargeItem(this.txtItemName.Text.Trim());
            }
        }

        private void lsvItem_DoubleClick(object sender, EventArgs e)
        {
            this.m_mthSelectItem();
        }

        private void lsvItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthSelectItem();
            } 
        }

        private void lsvItem_Leave(object sender, EventArgs e)
        {
            this.panelItem.Height = 0;
        }

        private void dtgItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0 && this.btnSave.Enabled)
            {
                clsParmItem_VO Item_VO = new clsParmItem_VO();

                Item_VO.ItemCode = this.dtgItem.Rows[row].Cells["itemcode"].Value.ToString();
                Item_VO.ItemName = this.dtgItem.Rows[row].Cells["itemname"].Value.ToString();
                Item_VO.ItemAmout = clsPublic.ConvertObjToDecimal(this.dtgItem.Rows[row].Cells["amount"].Value);
                Item_VO.DeptID = this.dtgItem.Rows[row].Cells["execareaid"].Value.ToString();
                Item_VO.DeptName = this.dtgItem.Rows[row].Cells["execarea"].Value.ToString();
                Item_VO.AllowNegative = true;

                frmAidEditItem fEdit = new frmAidEditItem(ref Item_VO);
                if (fEdit.ShowDialog() == DialogResult.OK)
                {
                    this.dtgItem.Rows[row].Cells["amount"].Value = Item_VO.ItemAmout;
                    this.dtgItem.Rows[row].Cells["execareaid"].Value = Item_VO.DeptID;
                    this.dtgItem.Rows[row].Cells["execarea"].Value = Item_VO.DeptName;

                    decimal d = clsPublic.ConvertObjToDecimal(this.dtgItem.Rows[row].Cells["price"].Value)
                                * clsPublic.ConvertObjToDecimal(this.dtgItem.Rows[row].Cells["amount"].Value);

                    this.dtgItem.Rows[row].Cells["total"].Value = d.ToString("0.00");
                    this.dtgItem.Rows[row].Cells["sbtotal"].Value = Convert.ToDecimal(d * clsPublic.ConvertObjToDecimal(this.dtgItem.Rows[row].Cells["scale"].Value) / 100).ToString("0.00");

                    decimal total = 0;
                    for (int i = 0; i < this.dtgItem.Rows.Count; i++)
                    {
                        total += clsPublic.ConvertObjToDecimal(this.dtgItem.Rows[i].Cells["total"].Value);
                    }
                    this.lblAllTotal.Text = total.ToString("0.00");
                }
            }
        }        
                
    }
}