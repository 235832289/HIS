using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;
using com.digitalwave.iCare.ValueObject;
using Microsoft.VisualBasic;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 费用直收控制类
    /// </summary>
    public class clsCtl_DirCharge : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_Charge objSvc;
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmDirCharge m_objViewer;
        /// <summary>
        /// 费用源
        /// </summary>
        private DataTable dtSource;
        /// <summary>
        /// 收费项目发票分类
        /// </summary>
        private DataTable dtChargeItemCat;
        /// <summary>
        /// 当前费用单ID
        /// </summary>
        internal string CurrOrderID = "";
        /// <summary>
        /// 当前状态 0 - 待确认 4 - 直收
        /// </summary>
        internal int CurrOrderStatus = 0;
        /// <summary>
        /// 录入模式 0 收费项目 1 诊疗项目
        /// </summary>
        internal int ItemInputMode = 0;
        /// <summary>
        /// 列后缀
        /// </summary>
        private string colSuffix = "";
        /// <summary>
        /// 是否允许打折
        /// </summary>
        private bool IsAllowDiscount = false;
        /// <summary>
        /// 打折起点项目个数
        /// </summary>
        private int DiscountItemNus = 8;
        /// <summary>
        /// 打折比例
        /// </summary>
        private decimal DiscountScale = 80;
        /// <summary>
        /// 打折所对应发票分类(数组)
        /// </summary>
        private ArrayList DiscountInvoCatArr = new ArrayList();
        /// <summary>
        /// 是否修改标志
        /// </summary>
        internal bool IsModify = false;
        /// <summary>
        /// 操作员默认科室(病区)列表
        /// </summary>
        private ArrayList objEmpDefaultDeptArr = new ArrayList();
        /// <summary>
        /// 控制诊疗项目对应关联收费项目（一对多）是否摆药 false 不摆药 true 摆药
        /// </summary>
        private bool IsControlPutMed = false;
        /// <summary>
        /// 摆药标志
        /// </summary>
        private bool IsPutMedicineFlag = false;
        /// <summary>
        /// 是否允许显示缺药项目
        /// </summary>
        private bool IsAllowNoQty = false;
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_DirCharge()
        {
            objSvc = new clsDcl_Charge();
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
            m_objViewer = (frmDirCharge)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void m_mthInit()
        {
            this.m_objViewer.ucPatientInfo.Status = 9;

            this.m_mthGetCat();

            this.m_mthLoadHistory();

            this.m_objViewer.panelItem.Height = 0;

            //初始化主管医生
            //医生列表
            clsColumns_VO[] columArr = new clsColumns_VO[]{ new clsColumns_VO("工号","empno_chr",HorizontalAlignment.Left,50),
                                                            new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                                                            new clsColumns_VO("姓名","doctorname",HorizontalAlignment.Left,80),
                                                            new clsColumns_VO("","empid_chr",HorizontalAlignment.Left,0)
                                                          };

            string SqlSource = @"select empid_chr, empno_chr, pycode_chr, lastname_vchr as doctorname
                                   from t_bse_employee 
                                  where status_int = 1 and hasprescriptionright_chr = '1'                                     
                               order by empno_chr";

            this.m_objViewer.txtChargeDoctor.m_strSQL = SqlSource;
            this.m_objViewer.txtChargeDoctor.m_mthInitListView(columArr);
            this.m_objViewer.txtChargeDoctor.m_listView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            //初始化执行地点
            //地点列表
            columArr = new clsColumns_VO[]{ new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                                            new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                                            new clsColumns_VO("地点名称","deptname_vchr",HorizontalAlignment.Left,130),
                                            new clsColumns_VO("","deptid_chr",HorizontalAlignment.Left,0)
                                          };

            //            SqlSource = @"select a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr
            //                            from t_bse_deptdesc a,
            //                                 t_bse_deptemp b 
            //                           where a.deptid_chr = b.deptid_chr 
            //                             and a.status_int = 1 
            //                             and a.attributeid = '0000003' 
            //                             and b.empid_chr = '" + this.m_objViewer.LoginInfo.m_strEmpID + @"'    
            //                        order by a.code_vchr";                                                
            SqlSource = @"select deptid_chr, deptname_vchr, pycode_chr, code_vchr
                            from t_bse_deptdesc
                           where status_int = 1
                        order by code_vchr";

            this.m_objViewer.txtApplyArea.m_strSQL = SqlSource;
            this.m_objViewer.txtApplyArea.m_mthInitListView(columArr);
            this.m_objViewer.txtApplyArea.m_listView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));

            //补记帐是否显示缺药项目  flag 禁止 true 允许
            if (clsPublic.m_intGetSysParm("1052") == 1)
            {
                IsAllowNoQty = true;
            }

            //控制诊疗项目对应关联收费项目（一对多）是否摆药 false 不摆药 1 摆药
            if (clsPublic.m_intGetSysParm("1049") == 1)
            {
                IsControlPutMed = true;
            }

            //录入模式 0 收费项目 1 诊疗项目
            ItemInputMode = clsPublic.m_intGetSysParm("9001");
            if (ItemInputMode == 0)
            {
                this.m_objViewer.plOrder.Width = 0;
                this.m_objViewer.dtgOrderItem.Visible = false;
                this.m_objViewer.dtgItem.BringToFront();
            }
            else if (ItemInputMode == 1)
            {
                this.m_objViewer.plOrder.Width = 197;
                this.m_objViewer.txtExecArea.Enabled = false;
                this.m_objViewer.plExecArea.Visible = false;
                this.m_objViewer.dtgItem.Visible = false;
                this.m_objViewer.dtgOrderItem.BringToFront();
            }

            //获取操作员默认科室列表
            clsDepartmentVO[] objEmpDeptArr;
            this.m_objComInfo.m_mthGetDepartmentByUserID(this.m_objViewer.LoginInfo.m_strEmpID, out objEmpDeptArr);
            if (objEmpDeptArr != null)
            {
                for (int i = 0; i < objEmpDeptArr.Length; i++)
                {
                    objEmpDefaultDeptArr.Add(objEmpDeptArr[i].strDeptID);
                }
            }

            this.m_objViewer.btnNew_Click(null, null);
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

            this.m_objViewer.txtExecArea.m_strSQL = SqlSource;
            this.m_objViewer.txtExecArea.m_mthInitListView(columArr);
            this.m_objViewer.txtExecArea.m_listView.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        }
        #endregion

        #region 清空编辑栏
        /// <summary>
        /// 清空编辑栏
        /// </summary>
        public void m_mthClear()
        {
            this.m_objViewer.txtItemName.Tag = null;
            this.m_objViewer.txtItemName.Text = "";
            this.m_objViewer.lblStandard.Text = "";
            this.m_objViewer.lblUnit.Text = "";
            this.m_objViewer.lblPrice.Text = "";
            this.m_objViewer.txtAmount.Text = "";
            this.m_objViewer.lblTotal.Text = "";
            this.m_objViewer.txtExecArea.Value = null;
            this.m_objViewer.txtExecArea.Text = "";

            this.m_objViewer.txtItemName.Focus();
        }
        #endregion

        #region 建树
        /// <summary>
        /// 建树
        /// </summary>
        public void m_mthLoadHistory()
        {
            string RegId = this.m_objViewer.ucPatientInfo.RegisterID;

            this.m_objViewer.lblAllTotal.Text = "";
            this.m_objViewer.tvHistory.Nodes.Clear();

            //根节点id
            string rootId = "root";
            //根节点Text
            string rootName = "历史记录";

            //建根节点
            TreeNode tnRoot = new TreeNode(rootName);
            tnRoot.Tag = rootId;
            tnRoot.ImageIndex = 0;
            tnRoot.SelectedImageIndex = 0;
            this.m_objViewer.tvHistory.Nodes.Add(tnRoot);

            if (RegId == "")
            {
                return;
            }

            long l = this.objSvc.m_lngGetFeeItemByActiveType(RegId, 5, null, null, null, null, out dtSource);
            if (l > 0 && dtSource.Rows.Count > 0)
            {
                Hashtable has = new Hashtable();
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    string OrderID = dtSource.Rows[i]["orderid_chr"].ToString();
                    string Status = dtSource.Rows[i]["pstatus_int"].ToString();

                    if (!has.ContainsKey(OrderID))
                    {
                        has.Add(OrderID, OrderID + ";" + Status);
                    }
                }

                //节点id
                string tnId = "";
                //节点Text
                string tnName = "";

                ArrayList OrderArr = new ArrayList();
                OrderArr.AddRange(has.Values);
                OrderArr.Sort();

                for (int i = 0; i < OrderArr.Count; i++)
                {
                    string s = OrderArr[i].ToString();
                    string OrderId = clsPublic.m_strGettoken(ref s, ";");
                    string Status = clsPublic.m_strGettoken(ref s, ";");
                    Color clr = Color.Black;

                    tnId = OrderId;
                    string tmpName = "[" + Convert.ToString(i + 1) + "-" + OrderId.Substring(0, 8) + "." + OrderId.Substring(8, 2) + "]";
                    if (Status == "0")
                    {
                        tnName = tmpName + "保存";
                    }
                    else if (Status == "2")
                    {
                        tnName = tmpName + "待清";
                        clr = Color.Blue;
                    }
                    else if (Status == "3")
                    {
                        tnName = tmpName + "已清";
                        clr = Color.Blue;
                    }
                    else if (Status == "4")
                    {
                        tnName = tmpName + "收费";
                        clr = Color.Red;
                    }

                    TreeNode tn = new TreeNode(tnName);
                    tn.Tag = OrderId + ";" + Status;
                    tn.ImageIndex = 1;
                    tn.SelectedImageIndex = 1;
                    tn.ForeColor = clr;

                    tnRoot.Nodes.Add(tn);
                }

                this.m_objViewer.tvHistory.ExpandAll();
            }
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        public void m_mthFind()
        {
            frmCommonFind f = new frmCommonFind("查找在院病人资料", this.m_objViewer.ucPatientInfo.Status);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.ucPatientInfo.m_mthFind(f.RegisterID, 3);
                if (this.m_objViewer.ucPatientInfo.IsChanged)
                {
                    this.m_mthLoad();
                }
            }
        }
        #endregion

        #region 装载
        /// <summary>
        /// 装载
        /// </summary>
        public void m_mthLoad()
        {
            this.m_mthLoadHistory();
            this.m_objViewer.dtgItem.Rows.Clear();
            this.m_objViewer.dtgOrder.Rows.Clear();
            this.m_objViewer.dtgOrderItem.Rows.Clear();
            this.m_objViewer.lblAllTotal.Text = "";
            this.m_objViewer.txtApplyArea.m_mthFindAndSelect(this.m_objViewer.ucPatientInfo.BihPatient_VO.AreaID);
            this.m_objViewer.txtChargeDoctor.m_mthFindAndSelect(this.m_objViewer.ucPatientInfo.BihPatient_VO.DoctorID);
            this.m_mthClear();
            this.CurrOrderID = "";
        }
        #endregion

        #region 是否儿童.是则采用儿童价格
        /// <summary>
        /// 是否儿童.是则采用儿童价格
        /// </summary>
        internal bool IsChildPrice
        {
            get
            {
                if (this.m_objViewer.ucPatientInfo.BihPatient_VO == null)
                {
                    return false;
                }
                else
                {
                    if (new clsDcl_YB().IsUseChildPrice())
                        return new clsBrithdayToAge().IsChild(this.m_objViewer.ucPatientInfo.BihPatient_VO.m_dtmBirthDay);
                    else
                        return false;
                }
            }
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

            string PatType = this.m_objViewer.ucPatientInfo.BihPatient_VO.PayTypeID;
            if (PatType == "")
            {
                MessageBox.Show("请明确费别！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            this.m_objViewer.lsvItem.BeginUpdate();
            this.m_objViewer.lsvItem.Items.Clear();

            DataTable dt;

            #region 收费项目
            if (ItemInputMode == 0)
            {
                long l = this.objSvc.m_lngFindChargeItem(FindStr, PatType, out dt, this.IsChildPrice);
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
                                if (!IsAllowNoQty)
                                {
                                    continue;
                                }
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
                        this.m_objViewer.lsvItem.Items.Add(lv);
                    }
                }
                else
                {
                    MessageBox.Show("没找到满足条件的收费项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            #endregion

            #region 诊疗项目
            if (ItemInputMode == 1)
            {
                long l = this.objSvc.m_lngFindOrderByID(FindStr, out dt, this.IsChildPrice);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string invocat = m_strConvertToChType(dt.Rows[i]["itemipinvtype_chr"].ToString().Trim());   //发票分类 flag_int = 4
                        ListViewItem lv = new ListViewItem(FindStr);
                        lv.SubItems.Add(dt.Rows[i]["usercode_chr"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["name_chr"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["commname_vchr"].ToString().Trim());
                        lv.SubItems.Add(invocat);
                        lv.SubItems.Add(dt.Rows[i]["itemspec_vchr"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["itemunit"].ToString().Trim());
                        lv.SubItems.Add(dt.Rows[i]["totalmny"].ToString().Trim());
                        lv.SubItems.Add(""); //收费比例  
                        lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());

                        if (invocat.IndexOf("中") >= 0 || invocat.IndexOf("西") >= 0)
                        {
                            if (dt.Rows[i]["ipnoqtyflag_int"].ToString().Trim() != "0")
                            {
                                if (!IsAllowNoQty)
                                {
                                    continue;
                                }
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
                        this.m_objViewer.lsvItem.Items.Add(lv);
                    }
                }
                else
                {
                    MessageBox.Show("没找到满足条件的收费项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            #endregion

            if (this.m_objViewer.lsvItem.Items.Count > 0)
            {
                this.m_objViewer.panelItem.Height = 200;
                this.m_objViewer.lsvItem.Items[0].Selected = true;
                this.m_objViewer.lsvItem.Focus();
            }

            this.m_objViewer.lsvItem.EndUpdate();
        }
        #endregion

        #region 获取收费项目发票分类
        /// <summary>
        /// 获取收费项目发票分类
        /// </summary>
        public void m_mthGetCat()
        {
            long l = this.objSvc.m_lngGetChargeItemCat(4, out dtChargeItemCat);
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
            if (this.m_objViewer.lsvItem.Items.Count == 0 || this.m_objViewer.lsvItem.SelectedItems.Count == 0)
            {
                return;
            }

            DataRow dr = this.m_objViewer.lsvItem.SelectedItems[0].Tag as DataRow;

            #region 收费项目
            if (ItemInputMode == 0)
            {
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
                this.m_objViewer.txtItemName.Text = ItemName;
                this.m_objViewer.lblStandard.Text = ItemSpe;
                this.m_objViewer.lblUnit.Text = ItemUnit;
                this.m_objViewer.lblPrice.Text = ItemPrice;

                //填充默认执行地点
                string ApplyAreaID = "";
                if (this.m_objViewer.txtApplyArea.Value != null)
                {
                    ApplyAreaID = this.m_objViewer.txtApplyArea.Value.ToString().Trim();
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

                this.m_objViewer.txtExecArea.m_mthFindAndSelect(ExecAreaID);
            }
            #endregion

            #region 诊疗项目
            if (ItemInputMode == 1)
            {
                //填充主项目
                this.m_objViewer.txtItemName.Text = dr["name_chr"].ToString().Trim();
                this.m_objViewer.lblStandard.Text = dr["des_vchr"].ToString().Trim();
                this.m_objViewer.lblUnit.Text = dr["itemunit"].ToString().Trim();
                this.m_objViewer.lblPrice.Text = dr["totalmny"].ToString().Trim();
            }
            #endregion

            this.m_objViewer.txtItemName.Tag = dr;

            this.m_objViewer.txtAmount.Focus();
        }
        #endregion

        #region 添加项目
        /// <summary>
        /// 添加项目
        /// </summary>
        public void m_mthAddItem()
        {
            if (this.m_objViewer.txtItemName.Tag == null)
            {
                return;
            }

            if (this.m_objViewer.txtAmount.Text.Trim() == "" || this.m_objViewer.txtAmount.Text.Trim() == "0")
            {
                MessageBox.Show("请输入数量。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtAmount.Focus();
                return;
            }

            if (this.m_objViewer.lblTotal.Text.Trim() == "")
            {
                MessageBox.Show("金额不能为空。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.m_objViewer.txtApplyArea.Value == null || this.m_objViewer.txtApplyArea.Text.Trim() == "")
            {
                MessageBox.Show("请选择开单地点。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtApplyArea.Focus();
                return;
            }

            if (this.m_objViewer.txtChargeDoctor.Value == null || this.m_objViewer.txtChargeDoctor.Text.Trim() == "")
            {
                MessageBox.Show("请选择开单医生。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtChargeDoctor.Focus();
                return;
            }

            if (ItemInputMode == 0)
            {
                if (this.m_objViewer.txtExecArea.Value == null || this.m_objViewer.txtExecArea.Text.Trim() == "")
                {
                    MessageBox.Show("请选择执行地点。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.txtExecArea.Focus();
                    return;
                }
            }

            DataRow dr = this.m_objViewer.txtItemName.Tag as DataRow;

            string ApplyAreaID = this.m_objViewer.txtApplyArea.Value.ToString().Trim();

            if (ItemInputMode == 0)
            {
                string[] sItem = new string[19];

                sItem[0] = Convert.ToString(this.m_objViewer.dtgItem.Rows.Count + 1);
                sItem[1] = this.m_objViewer.txtExecArea.Text.Trim();
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
                sItem[6] = this.m_objViewer.txtAmount.Text.Trim();
                sItem[7] = ItemPrice;
                sItem[8] = Convert.ToDecimal(this.m_objViewer.lblTotal.Text).ToString("0.00");

                string Precent = "100";
                if (dr["precent_dec"].ToString().Trim() != "")
                {
                    Precent = dr["precent_dec"].ToString().Trim();
                }
                sItem[9] = Precent;

                decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(sItem[8]) * clsPublic.ConvertObjToDecimal(sItem[9]) / 100, 2);
                sItem[10] = d.ToString("0.00");
                sItem[11] = ApplyAreaID;
                sItem[12] = this.m_objViewer.txtChargeDoctor.Value;
                sItem[13] = this.m_objViewer.txtExecArea.Value;
                sItem[14] = "0";  //0 新建 1 历史记录
                sItem[15] = "";
                sItem[16] = "0";
                sItem[17] = "0";
                //摆药判断
                if (dr["putmedtype_int"].ToString().Trim() == "1")
                {
                    sItem[17] = "1";
                }
                sItem[18] = this.m_objViewer.txtChargeDoctor.Text;

                int row = this.m_objViewer.dtgItem.Rows.Add(sItem);
                this.m_objViewer.dtgItem.Rows[row].Tag = dr;
                this.m_objViewer.dtgItem.Rows[row].Selected = true;
                this.m_objViewer.CurrRowNo = row;

                d += clsPublic.ConvertObjToDecimal(this.m_objViewer.lblAllTotal.Text);
                this.m_objViewer.lblAllTotal.Text = d.ToString("0.00");
            }
            else if (ItemInputMode == 1)
            {
                string orderid = dr["orderdicid_chr"].ToString();
                DataTable dt;
                long l = this.objSvc.m_lngGetChargeItemByOrderID(orderid, this.m_objViewer.ucPatientInfo.BihPatient_VO.PayTypeID, out dt, this.IsChildPrice);
                if (l > 0)
                {
                    #region 添加主项目
                    int num = this.m_objViewer.dtgOrder.Rows.Count + 1;
                    string[] sarr = new string[4];
                    sarr[0] = num.ToString();
                    sarr[1] = dr["name_chr"].ToString().Trim();
                    sarr[2] = num.ToString() + "->" + orderid;
                    sarr[3] = "0";  //0 新建 1 历史记录

                    int row = this.m_objViewer.dtgOrder.Rows.Add(sarr);
                    this.m_objViewer.dtgOrder.Rows[row].Tag = dr;
                    this.m_objViewer.dtgOrder.Rows[row].Selected = false;
                    #endregion

                    #region 添加关联明细项目

                    //诊疗项目所对收费明细数目
                    int orderentrycount = dt.Rows.Count;
                    decimal ordertotal = 0;
                    this.m_objViewer.dtgOrderItem.Rows.Clear();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow dr2 = dt.Rows[i];

                        string ItemId = dr2["itemid_chr"].ToString();
                        string ExecAreaName = "";
                        string ExecAreaID = this.objSvc.m_strGetChargeItemDefaultExecAreaID(ItemId, ApplyAreaID, out ExecAreaName);
                        if (ExecAreaID.Trim() == "")
                        {
                            ExecAreaID = this.m_objViewer.ucPatientInfo.BihPatient_VO.AreaID;
                            ExecAreaName = this.m_objViewer.ucPatientInfo.BihPatient_VO.AreaName;
                        }

                        string[] sItem = new string[19];

                        #region Item控件
                        sItem[0] = Convert.ToString(this.m_objViewer.dtgItem.Rows.Count + 1);
                        sItem[1] = ExecAreaName;
                        sItem[2] = dr2["itemcode_vchr"].ToString().Trim();
                        sItem[3] = dr2["itemname_vchr"].ToString().Trim();
                        sItem[4] = dr2["itemspec_vchr"].ToString().Trim();

                        string ItemUnit, ItemPrice;
                        if (dr2["ipchargeflg_int"].ToString().Trim() == "1")
                        {
                            ItemUnit = dr2["itemipunit_chr"].ToString().Trim();
                            ItemPrice = dr2["submoney"].ToString().Trim();
                        }
                        else
                        {
                            ItemUnit = dr2["itemunit_chr"].ToString().Trim();
                            ItemPrice = dr2["itemprice_mny"].ToString().Trim();
                        }
                        decimal d = clsPublic.ConvertObjToDecimal(this.m_objViewer.txtAmount.Text) * clsPublic.ConvertObjToDecimal(dr2["totalqty_dec"]);
                        sItem[5] = ItemUnit;
                        sItem[6] = d.ToString("0.00");
                        sItem[7] = ItemPrice;

                        d = clsPublic.ConvertObjToDecimal(sItem[6]) * clsPublic.ConvertObjToDecimal(sItem[7]);
                        sItem[8] = d.ToString("0.00");

                        string Precent = "100";
                        if (dr2["precent_dec"].ToString().Trim() != "")
                        {
                            Precent = dr2["precent_dec"].ToString().Trim();
                        }
                        sItem[9] = Precent;

                        d = clsPublic.Round(clsPublic.ConvertObjToDecimal(sItem[8]) * clsPublic.ConvertObjToDecimal(sItem[9]) / 100, 2);
                        sItem[10] = d.ToString("0.00");
                        sItem[11] = ApplyAreaID;
                        sItem[12] = this.m_objViewer.txtChargeDoctor.Value;
                        sItem[13] = ExecAreaID;
                        sItem[14] = "0";  //0 新建 1 历史记录

                        sItem[15] = num.ToString() + "->" + orderid;
                        sItem[16] = "0";
                        sItem[17] = "0";

                        //摆药判断
                        if (dr2["putmedtype_int"].ToString().Trim() == "1")
                        {
                            if (orderentrycount == 1)
                            {
                                sItem[17] = "1";
                            }
                            else
                            {
                                if (IsControlPutMed)
                                {
                                    sItem[17] = "1";
                                }
                            }
                        }
                        sItem[18] = this.m_objViewer.txtChargeDoctor.Text;

                        row = this.m_objViewer.dtgItem.Rows.Add(sItem);
                        this.m_objViewer.dtgItem.Rows[row].Tag = dr2;
                        ordertotal += d;
                        #endregion

                        #region OrderItem控件
                        sItem[0] = Convert.ToString(i + 1);
                        row = this.m_objViewer.dtgOrderItem.Rows.Add(sItem);
                        this.m_objViewer.dtgOrderItem.Rows[row].Tag = dr2;
                        #endregion
                    }
                    this.m_objViewer.dtgOrderItem.Rows[0].Selected = false;

                    ordertotal += clsPublic.ConvertObjToDecimal(this.m_objViewer.lblAllTotal.Text);
                    this.m_objViewer.lblAllTotal.Text = ordertotal.ToString("0.00");

                    this.m_objViewer.dtgOrderItem.Rows[0].Selected = true;
                    this.m_objViewer.CurrRowNo = 0;
                    #endregion
                }
            }
            this.m_mthClear();
            IsModify = true;
        }
        #endregion

        #region 删除项目
        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="Type">1 删除主项 2 删除明细</param>
        public void m_mthDelItem(int Type)
        {
            if (Type == 1)
            {
                bool b = false;
                for (int i = 0; i < this.m_objViewer.dtgOrder.Rows.Count; i++)
                {
                    if (this.m_objViewer.dtgOrder.Rows[i].Selected)
                    {
                        string attachorderid = "";
                        string ordername = "";
                        DataRow dr = this.m_objViewer.dtgOrder.Rows[i].Tag as DataRow;

                        if (this.m_objViewer.dtgOrder.Rows[i].Cells["orderflag"].Value.ToString() == "0")
                        {
                            ordername = dr["name_chr"].ToString();
                            attachorderid = this.m_objViewer.dtgOrder.Rows[i].Cells["attachorderid"].Value.ToString();
                        }
                        else
                        {
                            ordername = dr["orderdicname_vchr"].ToString();
                            attachorderid = dr["attachorderid_vchr"].ToString();
                        }

                        if (MessageBox.Show("是否删除主收费项目(诊疗项目)：【" + ordername + "】,明细项目将一并删除? \r\n\r\n删除项目后请按[保存]键保存", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            for (int j = this.m_objViewer.dtgItem.Rows.Count - 1; j >= 0; j--)
                            {
                                if (this.m_objViewer.dtgItem.Rows[j].Cells["orderid"].Value.ToString().Trim() == attachorderid)
                                {
                                    this.m_objViewer.dtgItem.Rows.RemoveAt(j);
                                }
                            }

                            this.m_objViewer.dtgOrder.Rows.RemoveAt(i);
                            this.m_objViewer.dtgOrderItem.Rows.Clear();

                            this.m_objViewer.CurrRowNo = -1;
                        }

                        b = true;
                        break;
                    }
                }

                if (!b)
                {
                    MessageBox.Show("请选择主收费项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (Type == 2)
            {
                int RowNo = this.m_objViewer.CurrRowNo;

                if (RowNo < 0)
                {
                    return;
                }

                DataGridView dgrid = null;

                if (ItemInputMode == 0)
                {
                    dgrid = this.m_objViewer.dtgItem;
                    colSuffix = "";
                }
                else if (ItemInputMode == 1)
                {
                    dgrid = this.m_objViewer.dtgOrderItem;
                    colSuffix = "1";
                    if (RowNo > dgrid.Rows.Count - 1)
                    {
                        RowNo = 0;
                    }
                }

                if (dgrid == null || dgrid.Rows.Count == 0)
                {
                    return;
                }

                DataRow dr = dgrid.Rows[RowNo].Tag as DataRow;
                string ItemName = "";
                if (dgrid.Rows[RowNo].Cells["flag" + colSuffix].Value.ToString() == "0")
                {
                    ItemName = dr["itemname_vchr"].ToString().Trim();
                }
                else
                {
                    ItemName = dr["chargeitemname_chr"].ToString().Trim();
                }

                if (MessageBox.Show("是否删除收费项目：【" + ItemName + "】? \r\n\r\n删除项目后请按<保存>键保存当前记录", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (ItemInputMode == 1)
                    {
                        for (int i = 0; i < this.m_objViewer.dtgItem.Rows.Count; i++)
                        {
                            if (this.m_objViewer.dtgItem.Rows[i].Cells["itemcode"].Value.ToString().Trim() == dgrid.Rows[RowNo].Cells["itemcode" + colSuffix].Value.ToString().Trim() &&
                                this.m_objViewer.dtgItem.Rows[i].Cells["orderid"].Value.ToString().Trim() == dgrid.Rows[RowNo].Cells["orderid" + colSuffix].Value.ToString().Trim())
                            {
                                this.m_objViewer.dtgItem.Rows.RemoveAt(i);
                                break;
                            }
                        }
                    }

                    string attachorderid = dgrid.Rows[RowNo].Cells["orderid" + colSuffix].Value.ToString().Trim();
                    dgrid.Rows.RemoveAt(RowNo);

                    if (ItemInputMode == 1 && dgrid.Rows.Count == 0)
                    {
                        for (int i = 0; i < this.m_objViewer.dtgOrder.Rows.Count; i++)
                        {
                            if (this.m_objViewer.dtgOrder.Rows[i].Cells["attachorderid"].Value.ToString().Trim() == attachorderid)
                            {
                                this.m_objViewer.dtgOrder.Rows.RemoveAt(i);
                                break;
                            }
                        }
                    }

                    if (RowNo >= dgrid.Rows.Count)
                    {
                        this.m_objViewer.CurrRowNo = dgrid.Rows.Count - 1;
                    }
                }
                else
                {
                    return;
                }
            }

            decimal total = 0;
            for (int j = 0; j < this.m_objViewer.dtgItem.Rows.Count; j++)
            {
                total += clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgItem.Rows[j].Cells["total"].Value);
            }
            if (total > 0)
            {
                this.m_objViewer.lblAllTotal.Text = total.ToString("0.00");
            }
            else
            {
                this.m_objViewer.lblAllTotal.Text = "";
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        /// <returns></returns>
        public bool m_blnSave()
        {
            if (this.m_objViewer.dtgItem.Rows.Count == 0 && CurrOrderID == "")
            {
                return false;
            }

            if (CurrOrderID != "" && CurrOrderStatus == 4)
            {
                return false;
            }

            ArrayList OrderDicArr = new ArrayList();

            for (int i = 0; i < this.m_objViewer.dtgOrder.Rows.Count; i++)
            {
                clsBihOrderDic_VO OrderDic_VO = new clsBihOrderDic_VO();

                DataRow dr = this.m_objViewer.dtgOrder.Rows[i].Tag as DataRow;

                //0 新建 1 历史记录
                if (this.m_objViewer.dtgOrder.Rows[i].Cells["orderflag"].Value.ToString() == "0")
                {
                    OrderDic_VO.Type = 1;
                    OrderDic_VO.OrderQue = i + 1;
                    OrderDic_VO.OrderDicID = dr["orderdicid_chr"].ToString();
                    OrderDic_VO.OrderDicName = dr["name_chr"].ToString();
                    OrderDic_VO.Spec = dr["des_vchr"].ToString();
                    OrderDic_VO.Qty = 0;
                    OrderDic_VO.PriceMny = 0;
                    OrderDic_VO.TotalMny = 0;
                    OrderDic_VO.AttachOrderID = this.m_objViewer.dtgOrder.Rows[i].Cells["attachorderid"].Value.ToString();
                    OrderDic_VO.SbBaseMny = 0;
                }
                else
                {
                    OrderDic_VO.Type = 1;
                    OrderDic_VO.OrderQue = i + 1;
                    OrderDic_VO.OrderDicID = dr["orderdicid_chr"].ToString();
                    OrderDic_VO.OrderDicName = dr["orderdicname_vchr"].ToString();
                    OrderDic_VO.Spec = dr["spec_vchr"].ToString();
                    OrderDic_VO.Qty = 0;
                    OrderDic_VO.PriceMny = 0;
                    OrderDic_VO.TotalMny = 0;
                    OrderDic_VO.AttachOrderID = dr["attachorderid_vchr"].ToString();
                    OrderDic_VO.SbBaseMny = 0;
                }
                OrderDicArr.Add(OrderDic_VO);
            }

            ArrayList PatientChargeArr = new ArrayList();

            for (int i = 0; i < this.m_objViewer.dtgItem.Rows.Count; i++)
            {
                clsBihPatientCharge_VO PatientCharge_VO = new clsBihPatientCharge_VO();

                DataRow dr = this.m_objViewer.dtgItem.Rows[i].Tag as DataRow;

                //0 新建 1 历史记录
                if (this.m_objViewer.dtgItem.Rows[i].Cells["flag"].Value.ToString() == "0")
                {
                    PatientCharge_VO.PatientID = this.m_objViewer.ucPatientInfo.BihPatient_VO.PatientID;
                    PatientCharge_VO.RegisterID = this.m_objViewer.ucPatientInfo.RegisterID;
                    PatientCharge_VO.ClacArea = this.m_objViewer.dtgItem.Rows[i].Cells["execareaid"].Value.ToString();
                    PatientCharge_VO.CreateArea = this.m_objViewer.dtgItem.Rows[i].Cells["applyareaid"].Value.ToString();
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

                    PatientCharge_VO.Amount = clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgItem.Rows[i].Cells["amount"].Value);
                    PatientCharge_VO.Discount = clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgItem.Rows[i].Cells["scale"].Value);
                    PatientCharge_VO.Ismepay = 0;
                    PatientCharge_VO.Des = "";
                    PatientCharge_VO.CreateType = 4;
                    PatientCharge_VO.Creator = this.m_objViewer.LoginInfo.m_strEmpID;
                    PatientCharge_VO.Operator = this.m_objViewer.LoginInfo.m_strEmpID;
                    PatientCharge_VO.PStatus = 0;
                    PatientCharge_VO.Activator = this.m_objViewer.dtgItem.Rows[i].Cells["applydoctorid"].Value.ToString();
                    PatientCharge_VO.ActivateType = 5;
                    PatientCharge_VO.IsRich = int.Parse(dr["isrich_int"].ToString());
                    PatientCharge_VO.CurAreaID = this.m_objViewer.ucPatientInfo.BihPatient_VO.AreaID;
                    PatientCharge_VO.CurBedID = this.m_objViewer.ucPatientInfo.BihPatient_VO.BedID;
                    PatientCharge_VO.DoctorID = this.m_objViewer.ucPatientInfo.BihPatient_VO.DoctorID;
                    PatientCharge_VO.Doctor = this.m_objViewer.ucPatientInfo.BihPatient_VO.DoctorName;
                    PatientCharge_VO.DoctorGroupID = this.m_objViewer.ucPatientInfo.BihPatient_VO.DoctorGroupID;
                    PatientCharge_VO.NeedConfirm = 0;
                    PatientCharge_VO.ActiveDat = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    PatientCharge_VO.TotalMoney_dec = clsPublic.Round(PatientCharge_VO.UnitPrice * PatientCharge_VO.Amount, 2);
                    PatientCharge_VO.AcctMoney_dec = PatientCharge_VO.TotalMoney_dec - clsPublic.Round(PatientCharge_VO.UnitPrice * PatientCharge_VO.Amount * PatientCharge_VO.Discount / 100, 2);
                    PatientCharge_VO.AttachOrderID = this.m_objViewer.dtgItem.Rows[i].Cells["orderid"].Value.ToString();
                    PatientCharge_VO.AttachOrderBaseNum = 0;
                    PatientCharge_VO.SPEC_VCHR = dr["itemspec_vchr"].ToString();
                    PatientCharge_VO.PutMedicineFlag = int.Parse(clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgItem.Rows[i].Cells["putmedicineflag"].Value).ToString());
                    PatientCharge_VO.CHARGEDOCTORID_CHR = this.m_objViewer.dtgItem.Rows[i].Cells["applydoctorid"].Value.ToString();
                    PatientCharge_VO.CHARGEDOCTOR_VCHR = this.m_objViewer.dtgItem.Rows[i].Cells["colChargeDoctorName"].Value.ToString();
                    PatientCharge_VO.CHARGEDOCTORGROUPID_CHR = this.m_objViewer.LoginInfo.m_strGroupID;
                }
                else
                {
                    PatientCharge_VO.PatientID = dr["patientid_chr"].ToString();
                    PatientCharge_VO.RegisterID = dr["registerid_chr"].ToString();
                    PatientCharge_VO.ClacArea = this.m_objViewer.dtgItem.Rows[i].Cells["execareaid"].Value.ToString();
                    PatientCharge_VO.CreateArea = dr["createarea_chr"].ToString();
                    PatientCharge_VO.CalcCateID = dr["calccateid_chr"].ToString();
                    PatientCharge_VO.InvCateID = dr["invcateid_chr"].ToString();
                    PatientCharge_VO.ChargeItemID = dr["chargeitemid_chr"].ToString();
                    PatientCharge_VO.ChargeItemName = dr["chargeitemname_chr"].ToString();
                    PatientCharge_VO.Unit = dr["unit_vchr"].ToString();
                    PatientCharge_VO.UnitPrice = clsPublic.ConvertObjToDecimal(dr["unitprice_dec"]);
                    PatientCharge_VO.Amount = clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgItem.Rows[i].Cells["amount"].Value);
                    PatientCharge_VO.Discount = clsPublic.ConvertObjToDecimal(dr["discount_dec"]);
                    PatientCharge_VO.Ismepay = 0;
                    PatientCharge_VO.Des = "";
                    PatientCharge_VO.CreateType = 4;
                    PatientCharge_VO.Creator = dr["creator_chr"].ToString();
                    PatientCharge_VO.Operator = dr["operator_chr"].ToString();
                    PatientCharge_VO.PStatus = 0;
                    PatientCharge_VO.Activator = dr["activator_chr"].ToString();
                    PatientCharge_VO.ActivateType = 5;
                    PatientCharge_VO.IsRich = int.Parse(dr["isrich_int"].ToString());
                    PatientCharge_VO.CurAreaID = dr["curareaid_chr"].ToString();
                    PatientCharge_VO.CurBedID = dr["curbedid_chr"].ToString();
                    PatientCharge_VO.DoctorID = dr["doctorid_chr"].ToString();
                    PatientCharge_VO.Doctor = dr["doctor_vchr"].ToString();
                    PatientCharge_VO.DoctorGroupID = dr["doctorgroupid_chr"].ToString();
                    PatientCharge_VO.NeedConfirm = 0;
                    PatientCharge_VO.ActiveDat = Convert.ToDateTime(dr["chargeactive_dat"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                    PatientCharge_VO.TotalMoney_dec = clsPublic.Round(PatientCharge_VO.UnitPrice * PatientCharge_VO.Amount, 2);
                    PatientCharge_VO.AcctMoney_dec = PatientCharge_VO.TotalMoney_dec - clsPublic.Round(PatientCharge_VO.UnitPrice * PatientCharge_VO.Amount * PatientCharge_VO.Discount / 100, 2);
                    PatientCharge_VO.AttachOrderID = dr["attachorderid_vchr"].ToString();
                    PatientCharge_VO.AttachOrderBaseNum = clsPublic.ConvertObjToDecimal(dr["attachorderbasenum_dec"]);
                    PatientCharge_VO.SPEC_VCHR = dr["spec_vchr"].ToString();
                    PatientCharge_VO.PutMedicineFlag = int.Parse(dr["putmedicineflag_int"].ToString());
                    PatientCharge_VO.CHARGEDOCTORID_CHR = dr["chargedoctorid_chr"].ToString();
                    PatientCharge_VO.CHARGEDOCTOR_VCHR = dr["chargedoctor_vchr"].ToString();
                    PatientCharge_VO.CHARGEDOCTORGROUPID_CHR = dr["chargedoctorgroupid_chr"].ToString();
                }
                PatientChargeArr.Add(PatientCharge_VO);
            }

            long l = this.objSvc.m_lngGenPatientChargeByDir(OrderDicArr, PatientChargeArr, 8, ref CurrOrderID);
            if (l > 0)
            {
                this.m_mthLoadHistory();
                this.CurrOrderStatus = 0;
                this.m_objViewer.btnCharge.Enabled = true;
                IsModify = false;
            }
            else
            {
                MessageBox.Show("保存数据失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }
        #endregion

        #region 收费
        /// <summary>
        /// 收费
        /// </summary>
        public void m_mthCharge()
        {
            if (!this.m_objViewer.btnCharge.Enabled)
            {
                return;
            }

            if (!this.m_blnSave())
            {
                return;
            }

            if (CurrOrderID == "" || CurrOrderStatus == 4)
            {
                return;
            }

            DataTable ChargeDtSelect = new DataTable();
            ChargeDtSelect = dtSource.Clone();

            DataView dv = new DataView(dtSource);
            dv.RowFilter = "orderid_chr = '" + CurrOrderID + "'";
            foreach (DataRowView drv in dv)
            {
                ChargeDtSelect.Rows.Add(drv.Row.ItemArray);
            }
            ChargeDtSelect.AcceptChanges();

            frmReckoning frec = new frmReckoning(this.m_objViewer.InvoNo);
            frec.ChargeType = 4;
            frec.ChargeDetail = ChargeDtSelect;
            frec.objPatient = this.m_objViewer.ucPatientInfo;
            frec.DayChrgType = 2;
            frec.DayAccountsArr = null;
            if (frec.ShowDialog() == DialogResult.OK)
            {
                this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
                this.m_mthLoadHistory();
                this.m_objViewer.btnNew_Click(null, null);

                /***摆药接口***/
                ArrayList arrReg = new ArrayList();
                arrReg.Add(this.m_objViewer.ucPatientInfo.RegisterID);
                IPutMadicine iPut = PutMadicineFactory.GetInstanceForRecipeMed();
                //iPut.CreatePutMedDetail(arrReg, this.m_objViewer.LoginInfo.m_strEmpID);
                iPut.CreatePutMedDetailByDptType(arrReg, this.m_objViewer.LoginInfo.m_strEmpID, 1);
                /******/
            }
        }
        #endregion

        #region 退款
        /// <summary>
        /// 退款
        /// </summary>
        public void m_mthRefundment()
        {
            string RegID = this.m_objViewer.ucPatientInfo.RegisterID;

            if (RegID == "")
            {
                return;
            }

            frmInvoiceRefundment finvoref = new frmInvoiceRefundment(RegID, 4);
            finvoref.ShowDialog();
            if (finvoref.IsRefundment)
            {
                this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
            }
            this.m_mthLoadHistory();
            this.m_objViewer.btnNew_Click(null, null);
        }
        #endregion

        #region 重打发票
        /// <summary>
        /// 重打发票
        /// </summary>        
        public void m_mthRepeatPrt()
        {
            string RegID = this.m_objViewer.ucPatientInfo.RegisterID;

            if (RegID == "")
            {
                return;
            }

            frmInvoiceRepeatPrt finvoprt = new frmInvoiceRepeatPrt(RegID);
            finvoprt.ShowDialog();
        }
        #endregion

        #region 显示历史记录
        /// <summary>
        /// 显示历史记录
        /// </summary>
        /// <param name="OrderID"></param>
        public void m_mthShowHistory(string OrderID)
        {
            if (dtSource == null || dtSource.Rows.Count == 0)
            {
                return;
            }

            this.m_objViewer.dtgItem.Rows.Clear();
            this.m_objViewer.dtgOrder.Rows.Clear();
            this.m_objViewer.dtgOrderItem.Rows.Clear();
            decimal total = 0;

            if (ItemInputMode == 1)
            {
                DataTable dt;
                long l = this.objSvc.m_lngGetOrderDic(OrderID, out dt);
                if (l > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        #region 添加主项目
                        DataRow dr = dt.Rows[i];
                        string[] sarr = new string[4];
                        sarr[0] = Convert.ToString(i + 1);
                        sarr[1] = dr["orderdicname_vchr"].ToString().Trim();
                        sarr[2] = dr["attachorderid_vchr"].ToString();
                        sarr[3] = "1";  //0 新建 1 历史记录

                        int row = this.m_objViewer.dtgOrder.Rows.Add(sarr);
                        this.m_objViewer.dtgOrder.Rows[row].Tag = dr;
                        #endregion
                    }
                    this.m_objViewer.dtgOrder.Rows[0].Selected = false;
                }
            }

            DataRow[] drSelect;
            drSelect = dtSource.Select("orderid_chr = '" + OrderID + "'");
            for (int i = 0; i < drSelect.Length; i++)
            {
                DataRow dr = drSelect[i];

                string[] sItem = new string[19];

                sItem[0] = Convert.ToString(i + 1);
                sItem[1] = dr["execarea"].ToString().Trim();
                sItem[2] = dr["itemcode_vchr"].ToString().Trim();
                sItem[3] = dr["chargeitemname_chr"].ToString().Trim();
                sItem[4] = dr["itemspec_vchr"].ToString().Trim();
                sItem[5] = dr["unit_vchr"].ToString().Trim();
                sItem[6] = dr["amount_dec"].ToString().Trim();
                sItem[7] = dr["unitprice_dec"].ToString().Trim();
                sItem[8] = Convert.ToDecimal(dr["totalmoney_dec"]).ToString("0.00");
                sItem[9] = dr["precent_dec"].ToString();
                sItem[10] = Convert.ToDecimal(clsPublic.ConvertObjToDecimal(dr["totalmoney_dec"]) - clsPublic.ConvertObjToDecimal(dr["acctmoney_dec"])).ToString("0.00");
                sItem[11] = dr["createarea_chr"].ToString();
                sItem[12] = dr["activator_chr"].ToString();
                sItem[13] = dr["clacarea_chr"].ToString();
                sItem[14] = "1";  //0 新建 1 历史记录                
                sItem[15] = dr["attachorderid_vchr"].ToString();

                sItem[16] = "0";
                sItem[17] = dr["putmedicineflag_int"].ToString();
                sItem[18] = dr["chargedoctor_vchr"].ToString();

                int row = this.m_objViewer.dtgItem.Rows.Add(sItem);
                this.m_objViewer.dtgItem.Rows[row].Tag = dr;
                this.m_objViewer.dtgItem.Rows[row].Selected = true;
                this.m_objViewer.CurrRowNo = row;
                total += clsPublic.ConvertObjToDecimal(dr["totalmoney_dec"]);

                if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                {
                    this.m_objViewer.dtgItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                }
            }
            if (total != 0)
            {
                this.m_objViewer.lblAllTotal.Text = total.ToString("0.00");
            }

            if (this.m_objViewer.dtgOrder.Rows.Count > 0)
            {
                this.m_mthShowOrderEntry(this.m_objViewer.dtgOrder.Rows[0].Cells["attachorderid"].Value.ToString());
            }
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="row">当前行号</param>  
        public void m_mthModify(int row)
        {
            clsParmItem_VO Item_VO = new clsParmItem_VO();

            DataGridView dgrid = null;

            if (ItemInputMode == 0)
            {
                dgrid = this.m_objViewer.dtgItem;
                colSuffix = "";
            }
            else if (ItemInputMode == 1)
            {
                dgrid = this.m_objViewer.dtgOrderItem;
                colSuffix = "1";
            }

            Item_VO.ItemCode = dgrid.Rows[row].Cells["itemcode" + colSuffix].Value.ToString();
            Item_VO.ItemName = dgrid.Rows[row].Cells["itemname" + colSuffix].Value.ToString();
            Item_VO.ItemAmout = clsPublic.ConvertObjToDecimal(dgrid.Rows[row].Cells["amount" + colSuffix].Value);
            Item_VO.DeptID = dgrid.Rows[row].Cells["execareaid" + colSuffix].Value.ToString();
            Item_VO.DeptName = dgrid.Rows[row].Cells["execarea" + colSuffix].Value.ToString();
            Item_VO.AllowNegative = true;

            frmAidEditItem fEdit = new frmAidEditItem(ref Item_VO);
            if (fEdit.ShowDialog() == DialogResult.OK)
            {
                dgrid.Rows[row].Cells["amount" + colSuffix].Value = Item_VO.ItemAmout;
                dgrid.Rows[row].Cells["execareaid" + colSuffix].Value = Item_VO.DeptID;
                dgrid.Rows[row].Cells["execarea" + colSuffix].Value = Item_VO.DeptName;

                decimal d = clsPublic.ConvertObjToDecimal(dgrid.Rows[row].Cells["price" + colSuffix].Value)
                            * clsPublic.ConvertObjToDecimal(dgrid.Rows[row].Cells["amount" + colSuffix].Value);

                dgrid.Rows[row].Cells["total" + colSuffix].Value = d.ToString("0.00");
                dgrid.Rows[row].Cells["sbtotal" + colSuffix].Value = Convert.ToDecimal(d * clsPublic.ConvertObjToDecimal(dgrid.Rows[row].Cells["scale" + colSuffix].Value) / 100).ToString("0.00");

                if (ItemInputMode == 1)
                {
                    for (int j = 0; j < this.m_objViewer.dtgItem.Rows.Count; j++)
                    {
                        if (this.m_objViewer.dtgItem.Rows[j].Cells["itemcode"].Value.ToString().Trim() == dgrid.Rows[row].Cells["itemcode" + colSuffix].Value.ToString().Trim() &&
                            this.m_objViewer.dtgItem.Rows[j].Cells["orderid"].Value.ToString().Trim() == dgrid.Rows[row].Cells["orderid" + colSuffix].Value.ToString().Trim())
                        {
                            this.m_objViewer.dtgItem.Rows[j].Cells["amount"].Value = dgrid.Rows[row].Cells["amount" + colSuffix].Value;
                            this.m_objViewer.dtgItem.Rows[j].Cells["execareaid"].Value = dgrid.Rows[row].Cells["execareaid" + colSuffix].Value;
                            this.m_objViewer.dtgItem.Rows[j].Cells["execarea"].Value = dgrid.Rows[row].Cells["execarea" + colSuffix].Value;
                            this.m_objViewer.dtgItem.Rows[j].Cells["total"].Value = dgrid.Rows[row].Cells["total" + colSuffix].Value;
                            this.m_objViewer.dtgItem.Rows[j].Cells["sbtotal"].Value = dgrid.Rows[row].Cells["sbtotal" + colSuffix].Value;
                            break;
                        }
                    }
                }
            }

            decimal total = 0;
            for (int i = 0; i < this.m_objViewer.dtgItem.Rows.Count; i++)
            {
                total += clsPublic.ConvertObjToDecimal(this.m_objViewer.dtgItem.Rows[i].Cells["total"].Value);
            }
            this.m_objViewer.lblAllTotal.Text = total.ToString("0.00");
        }
        #endregion

        #region 显示诊疗项目明细
        /// <summary>
        /// 显示诊疗项目明细
        /// </summary>
        /// <param name="AttatchOrderID"></param>
        public void m_mthShowOrderEntry(string AttatchOrderID)
        {
            int rowno = 1;
            this.m_objViewer.dtgOrderItem.Rows.Clear();
            for (int i = 0; i < this.m_objViewer.dtgItem.Rows.Count; i++)
            {
                if (this.m_objViewer.dtgItem.Rows[i].Cells["orderid"].Value.ToString() == AttatchOrderID)
                {
                    string[] sItem = new string[16];

                    sItem[0] = Convert.ToString(rowno.ToString());
                    sItem[1] = this.m_objViewer.dtgItem.Rows[i].Cells["execarea"].Value.ToString();
                    sItem[2] = this.m_objViewer.dtgItem.Rows[i].Cells["itemcode"].Value.ToString();
                    sItem[3] = this.m_objViewer.dtgItem.Rows[i].Cells["itemname"].Value.ToString();
                    sItem[4] = this.m_objViewer.dtgItem.Rows[i].Cells["standard"].Value.ToString();
                    sItem[5] = this.m_objViewer.dtgItem.Rows[i].Cells["unit"].Value.ToString();
                    sItem[6] = this.m_objViewer.dtgItem.Rows[i].Cells["amount"].Value.ToString();
                    sItem[7] = this.m_objViewer.dtgItem.Rows[i].Cells["price"].Value.ToString();
                    sItem[8] = this.m_objViewer.dtgItem.Rows[i].Cells["total"].Value.ToString();
                    sItem[9] = this.m_objViewer.dtgItem.Rows[i].Cells["scale"].Value.ToString();
                    sItem[10] = this.m_objViewer.dtgItem.Rows[i].Cells["sbtotal"].Value.ToString();
                    sItem[11] = this.m_objViewer.dtgItem.Rows[i].Cells["applyareaid"].Value.ToString();
                    sItem[12] = this.m_objViewer.dtgItem.Rows[i].Cells["applydoctorid"].Value.ToString();
                    sItem[13] = this.m_objViewer.dtgItem.Rows[i].Cells["execareaid"].Value.ToString();
                    sItem[14] = this.m_objViewer.dtgItem.Rows[i].Cells["flag"].Value.ToString();  //0 新建 1 历史记录                      
                    sItem[15] = this.m_objViewer.dtgItem.Rows[i].Cells["orderid"].Value.ToString();

                    int row = this.m_objViewer.dtgOrderItem.Rows.Add(sItem);
                    this.m_objViewer.dtgOrderItem.Rows[row].Tag = this.m_objViewer.dtgItem.Rows[i].Tag;

                    if (Math.IEEERemainder(rowno, 2) == 0)
                    {
                        this.m_objViewer.dtgOrderItem.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }

                    rowno++;
                }
            }
        }
        #endregion
    }
}
