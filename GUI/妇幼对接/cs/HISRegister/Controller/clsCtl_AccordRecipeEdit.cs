using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
using System.Collections;
using System.Text;
using System.Drawing;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 协定处方维护逻辑类
    /// </summary>
    public class clsCtl_AccordRecipeEdit : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量

        #region 西药用常量
        /// <summary>
        /// 方号
        /// </summary>
        internal int c_GroupNo = 0;
        /// <summary>
        /// 查询
        /// </summary>
        internal int c_Find = 1;
        /// <summary>
        /// 数量
        /// </summary>
        internal int c_Count = 2;
        /// <summary>
        /// 单位
        /// </summary>
        internal int c_Unit = 3;
        /// <summary>
        /// 名称
        /// </summary>
        internal int c_Name = 4;
        /// <summary>
        /// 规格
        /// </summary>
        internal int c_Spec = 5;
        /// <summary>
        /// 用法名称
        /// </summary>
        internal int c_UsageName = 6;
        /// <summary>
        /// 频率名称
        /// </summary>
        internal int c_FreName = 7;
        /// <summary>
        /// 天数
        /// </summary>
        internal int c_Day = 8;
        /// <summary>
        /// 单价
        /// </summary>
        internal int c_Price = 9;
        /// <summary>
        /// 总价
        /// </summary>
        internal int c_SumMoney = 10;
        /// <summary>
        /// 项目ID
        /// </summary>
        internal int c_ItemID = 11;
        /// <summary>
        /// 包装量
        /// </summary>
        internal int c_Packet = 12;
        /// <summary>
        /// 总数
        /// </summary>
        internal int c_Total = 13;
        /// <summary>
        /// 频率天数
        /// </summary>
        internal int c_FreDays = 14;
        /// <summary>
        /// 频率次数
        /// </summary>
        internal int c_FreTimes = 15;
        /// <summary>
        /// 用法ID
        /// </summary>
        internal int c_UsageID = 16;
        /// <summary>
        /// 频率ID
        /// </summary>
        internal int c_FreID = 17;
        /// <summary>
        /// 大单位
        /// </summary>

        internal int c_BigUnit = 18;
        /// <summary>
        /// 行号
        /// </summary>
        internal int c_RowNo = 19;
        /// <summary>
        /// 比例名
        /// </summary>
        internal int c_DiscountName = 20;
        /// <summary>
        /// 比例
        /// </summary>
        internal int c_Discount = 21;
        /// <summary>
        /// 大小单位标记
        /// </summary>
        internal int c_UnitFlag = 22;
        /// <summary>
        /// 剂量
        /// </summary>
        internal int c_Dosage = 23;
        /// <summary>
        /// 上限
        /// </summary>
        internal int c_MaxLimit = 24;
        /// <summary>
        /// 下限
        /// </summary>
        internal int c_MinLimit = 25;
        /// <summary>
        /// 是否计算
        /// </summary>
        internal int c_IsCal = 26;
        /// <summary>
        /// 发票分类
        /// </summary>
        internal int c_InvoiceType = 27;
        /// <summary>
        /// 附加项目ID
        /// </summary>
        internal int c_SubItemID = 28;
        /// <summary>
        /// 组标志
        /// </summary>
        internal int c_IsMain = 29;
        /// <summary>
        /// 附加项目原数量
        /// </summary>
        internal int c_PreCount = 30;
        /// <summary>
        /// 附加项目标志
        /// </summary>
        internal int c_Fage = 31;
        /// <summary>
        /// 英文名
        /// </summary>
        internal int c_EnglishName = 32;
        /// <summary>
        /// 皮试
        /// </summary>
        internal int c_PS = 33;
        /// <summary>
        /// 详细用法
        /// </summary>
        internal int c_UsageDetail = 34;
        /// <summary>
        /// 皮试标志 皮试标志 0--否 1--是
        /// </summary>
        internal int c_PSFlag = 35;
        /// <summary>
        /// 关联子项目
        /// </summary>
        internal int c_resubitem = 36;
        /// <summary>
        /// 主项目默认用量
        /// </summary>
        internal int c_MainItemNum = 37;
        /// <summary>
        /// 科备药标志名称
        /// </summary>
        internal int c_Deptmed = 38;
        /// <summary>
        /// 科备药标志ID
        /// </summary>
        internal int c_DeptmedID = 39;

        #endregion

        #region 中药常量
        /// <summary>
        /// 关联子项目
        /// </summary>
        internal int cm_resubitem = 25;
        /// <summary>
        /// 主项目默认用量
        /// </summary>
        internal int cm_MainItemNum = 26;
        /// <summary>
        /// 科备药标志名称
        /// </summary>
        internal int cm_Deptmed = 27;
        /// <summary>
        /// 科备药标志ID
        /// </summary>
        internal int cm_DeptmedID = 28;
        /// <summary>
        /// 详细用法
        /// </summary>
        internal int cm_UsageDetail = 29;

        #endregion

        #region 其他常数
        /// <summary>
        /// 查询0
        /// </summary>
        internal int o_Find = 0;
        /// <summary>
        /// 数量1
        /// </summary>
        internal int o_Count = 1;
        /// <summary>
        /// 名称2
        /// </summary>
        internal int o_Name = 2;
        /// <summary>
        /// 规格3
        /// </summary>
        internal int o_Spec = 3;
        /// <summary>
        /// 单位4
        /// </summary>
        internal int o_Unit = 4;
        /// <summary>
        /// 单价5
        /// </summary>
        internal int o_Price = 5;
        /// <summary>
        /// 总价6
        /// </summary>
        internal int o_SumMoney = 6;
        /// <summary>
        /// 项目ID7
        /// </summary>
        internal int o_ItemID = 7;
        /// <summary>
        /// 自定义价格
        /// </summary>
        internal int o_PriceFlag = 8;
        /// <summary>
        /// 行号9
        /// </summary>
        internal int o_RowNo = 9;
        /// <summary>
        /// 比例名10
        /// </summary>
        internal int o_DiscountName = 10;
        /// <summary>
        /// 比例值11
        /// </summary>
        internal int o_Discount = 11;
        /// <summary>
        /// 发票分类12
        /// </summary>
        internal int o_InvoiceType = 12;
        /// <summary>
        /// 附加项目ID13
        /// </summary>
        internal int o_OtherItemID = 13;
        /// <summary>
        /// 附加数量14
        /// </summary>
        internal int o_OtherCount = 14;
        /// <summary>
        /// 英文名15
        /// </summary>
        internal int o_EnglishName = 15;
        /// <summary>
        /// 预留16
        /// </summary>
        internal int o_Temp = 16;
        /// <summary>
        ///  申请单ID17
        /// </summary>
        internal int o_ApplyId = 17;
        /// <summary>
        /// 关联子项目
        /// </summary>
        internal int o_resubitem = 18;
        /// <summary>
        /// 主项目默认用量
        /// </summary>
        internal int o_MainItemNum = 19;
        /// <summary>
        /// 申请单标志
        /// </summary>
        internal int o_appflag = 20;
        /// <summary>
        /// 手术详细用法
        /// </summary>
        internal int o_UsageDetail = 21;

        /// <summary>
        /// 其他详细用法
        /// </summary>
        internal int o_UsageDetail2 = 20;
        /// <summary>
        /// 其他科备药标志名称
        /// </summary>
        internal int o_Deptmed = 21;
        /// <summary>
        /// 其他科备药标志ID
        /// </summary>
        internal int o_DeptmedID = 22;
        /// <summary>
        /// 手术治疗栏：用法ID
        /// </summary>
        internal int o_UsageID = 22;

        #endregion

        #region 检验检查
        /// <summary>
        /// 查询0
        /// </summary>
        internal int t_Find = 0;
        /// <summary>
        /// 数量1
        /// </summary>
        internal int t_Count = 1;

        /// <summary>
        /// 名称2
        /// </summary>
        internal int t_Name = 2;
        /// <summary>
        /// 规格3
        /// </summary>
        internal int t_Spec = 3;
        /// <summary>
        /// 检查/验类型名称4
        /// </summary>
        internal int t_PartName = 4;
        /// <summary>
        /// 单位5
        /// </summary>
        internal int t_Unit = 5;

        /// <summary>
        /// 单价6
        /// </summary>
        internal int t_Price = 6;
        /// <summary>
        /// 总价7
        /// </summary>
        internal int t_SumMoney = 7;
        /// <summary>
        /// 项目ID8
        /// </summary>
        internal int t_ItemID = 8;
        /// <summary>
        /// 自定义价格9
        /// </summary>
        internal int t_PriceFlag = 9;
        /// <summary>
        /// 行号10
        /// </summary>
        internal int t_RowNo = 10;
        /// <summary>
        /// 比例名11
        /// </summary>
        internal int t_DiscountName = 11;
        /// <summary>
        /// 比例值12
        /// </summary>
        internal int t_Discount = 12;
        /// <summary>
        /// 发票分类13
        /// </summary>
        internal int t_InvoiceType = 13;
        /// <summary>
        /// 附加项目ID14
        /// </summary>
        internal int t_OtherItemID = 14;
        /// <summary>
        /// 附加数量15
        /// </summary>
        internal int t_OtherCount = 15;
        /// <summary>
        /// 英文名16
        /// </summary>
        internal int t_EnglishName = 16;
        /// <summary>
        /// 样本ID17
        /// </summary>
        internal int t_Temp = 17;
        /// <summary>
        ///  申请单ID18
        /// </summary>
        internal int t_ApplyId = 18;
        /// <summary>
        /// 关联子项目
        /// </summary>
        internal int t_resubitem = 19;
        /// <summary>
        /// 主项目默认用量
        /// </summary>
        internal int t_MainItemNum = 20;
        /// <summary>
        /// 速诊标志名称
        /// </summary>
        internal int t_quick = 21;
        /// <summary>
        /// 速诊标志ID
        /// </summary>
        internal int t_quickid = 22;
        /// <summary>
        /// 检验详细用法
        /// </summary>
        internal int t_UsageDetail = 23;
        /// <summary>
        /// 检查详细用法
        /// </summary>
        internal int t_UsageDetail2 = 21;
        /// <summary>
        /// 检查栏－用法ID
        /// </summary>
        internal int t_UsageID = 22;
        /// <summary>
        /// 检验诊疗项目－主项目ID
        /// </summary>
        internal int t_lis_orderitem = 24;
        /// <summary>
        /// 检验诊疗项目－主项目默认用量
        /// </summary>
        internal int t_lis_ordernum = 25;
        /// <summary>
        /// 检验诊疗项目打折比例
        /// </summary>
        internal int t_lis_discount = 26;
        /// <summary>
        /// 检查诊疗项目－主项目ID
        /// </summary>
        internal int t_test_orderitem = 23;
        /// <summary>
        /// 检查诊疗项目－主项目默认用量
        /// </summary>
        internal int t_test_ordernum = 24;
        /// <summary>
        /// 手术治疗诊疗项目－主项目ID
        /// </summary>
        internal int t_ops_orderitem = 23;
        /// <summary>
        /// 手术治疗诊疗项目－主项目默认用量
        /// </summary>
        internal int t_ops_ordernum = 24;
        #endregion

        /// <summary>
        /// DoctorWorkstation-DoMain类
        /// </summary>
        private clsDcl_DoctorWorkstation objSvc;
        /// <summary>
        /// 判断那种计算方式 true 正常,false
        /// </summary>
        private bool CalFlag = true;
        /// <summary>
        /// 全局变量,记录datagrid的CellChange产生时的单位格
        /// </summary>
        private int colNo = 0;
        /// <summary>
        /// 全局变量,记录datagrid的CellChange产生时的单位格
        /// </summary>
        private int rowNo = 0;
        /// <summary>
        /// 片剂计算方法
        /// </summary>
        private bool Trochecalc = false;
        /// <summary>
        /// 在转页时不转变
        /// </summary>
        public bool b_IndexChangeFlag = true;
        /// <summary>
        /// 处方权限(0 无 1 有)
        /// </summary>
        internal string Recpur = "0";
        /// <summary>
        /// 神经性药物权限(0 无 1 有)
        /// </summary>
        private string Neurpur = "0";
        /// <summary>
        /// 毒麻药权限(0 无 1 有)
        /// </summary>
        private string Drugpur = "0";
        /// <summary>
        /// 判断是否显示缺药 true 显示,false不显示
        /// </summary>
        internal bool isShowLackMedicine = true;
        /// <summary>
        /// 精神性药物提示信息
        /// </summary>
        private string Neurpurhintinfo = "该药品为精神药物。\r\n\r\n①一类(如利他林)不能超过3天，请补手写处方；\r\n\r\n②二类（如安定类）不能超过7天，特殊情况不超过14天（请注明理由）。";
        /// <summary>
        /// 毒麻药物提示信息
        /// </summary>
        private string Drugpurhintinfo = "该药品为毒麻药物，请补手写处方。\r\n\r\n麻醉药品使用须知：\r\n\r\n  ①注射剂每张处方一次用量（限院内注射）；\r\n\r\n  ②控缓释制剂不能超过7天；\r\n\r\n  ③其它剂型不能超过3天。";

        private ArrayList OrderCatLisArr = new ArrayList();
        private ArrayList OrderCatTestArr = new ArrayList();
        private ArrayList OrderCatOpsArr = new ArrayList();
        #endregion

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_AccordRecipeEdit()
        {
            objSvc = new clsDcl_DoctorWorkstation();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 对象
        /// </summary>
        public com.digitalwave.iCare.gui.HIS.frmAccordRecipeEdit m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAccordRecipeEdit)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void m_mthInit()
        {
            CalFlag = objSvc.m_mthIsCanDo("0015");
            Trochecalc = objSvc.m_mthIsCanDo("0054");
            isShowLackMedicine = objSvc.m_mthIsCanDo("0012");

            OrderCatLisArr = this.m_Gettoken(this.objSvc.m_strGetSysparm("0010"), ";");
            OrderCatTestArr = this.m_Gettoken(this.objSvc.m_strGetSysparm("0011"), ";");
            OrderCatOpsArr = this.m_Gettoken(this.objSvc.m_strGetSysparm("0012"), ";");

            this.m_mthGetmedpurview();
            this.objSvc.m_mthGetmedpurview(this.m_objViewer.LoginInfo.m_strEmpID, out Neurpur, out Drugpur, out Recpur);

            //获取发票类型对应表，根据发票分类来对应。
            this.m_mthLoadCat();

            //把DataGrid的回车键转为空格键。
            this.m_mthSetDataGridEnterToSpace();

            this.m_objViewer.ctlDataGrid1.Controls.Add(this.m_objViewer.listView2);
            this.m_objViewer.ctlDataGrid1.Controls.Add(this.m_objViewer.listView3);
            this.m_objViewer.ctlDataGrid2.Controls.Add(this.m_objViewer.listView4);
            this.m_objViewer.listView5.Leave += new EventHandler(listView5_Leave);
            this.m_objViewer.listView5.DoubleClick += new EventHandler(listView5_DoubleClick);
            this.m_objViewer.listView5.KeyDown += new KeyEventHandler(listView5_KeyDown);

            this.m_mthNew();
        }
        #endregion

        #region 毒麻精神药品
        /// <summary>
        /// 毒麻精神药品权限 0-视毒麻药为普通药管理 1-对无毒麻权限的医生开药时只做提示 2-严格限制（无权限的不能开、有权限的开药时需录入病人身份证号、毒麻药需独自分处方）
        /// </summary>
        private int Medpurview = 0;
        /// <summary>
        /// 获取毒麻精神药品权限
        /// </summary>
        private void m_mthGetmedpurview()
        {
            DataTable dt;
            long ret = objSvc.m_lngGetWSParm("0049", out dt);		//0049 毒麻精神药品权限

            if (ret > 0 && dt.Rows.Count > 0)
            {
                Medpurview = Convert.ToInt32(dt.Rows[0]["SETSTATUS_INT"]);
            }
        }
        #endregion

        #region 建树
        /// <summary>
        /// 建树
        /// </summary>
        public void m_mthCreateTree(string EmpID)
        {
            DataTable dt;

            try
            {
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                long l = this.objSvc.m_lngFindAccordRecipe(EmpID, out dt);
                if (l > 0)
                {
                    this.m_objViewer.tv.BeginUpdate();
                    this.m_objViewer.tv.Nodes.Clear();

                    DataView DV = new DataView(dt);
                    DV.Sort = "recipename_chr asc";

                    ArrayList RecArr = new ArrayList();
                    DataRow dr = null;
                    for (int i = 0; i < DV.Count; i++)
                    {
                        dr = DV[i].Row;

                        AccordRecipeEdit objAR = new AccordRecipeEdit();
                        objAR.RecipeID_Chr = dr["recipeid_chr"].ToString().Trim();
                        objAR.Recipename_Chr = dr["recipename_chr"].ToString().Trim();
                        objAR.UserCode_Chr = dr["usercode_chr"].ToString().Trim();
                        objAR.PyCode_Chr = dr["pycode_chr"].ToString().Trim();
                        objAR.WbCode_Chr = dr["wbcode_chr"].ToString().Trim();
                        objAR.Privilege_Int = dr["privilege_int"].ToString();
                        objAR.Status_Int = dr["status_int"].ToString();
                        objAR.ReMark_Vchr = dr["diseasename_vchr"].ToString();
                        objAR.OrigeName = dr["recipename_chr"].ToString().Trim();
                        RecArr.Add(objAR);
                    }

                    this.m_objViewer.tv.Nodes.Add("协定处方模板列表");
                    TreeNode FirstNode = null;
                    TreeNode FindNode = this.m_objViewer.tv.Nodes[0];
                    FindNode.Tag = "root";
                    FindNode.Name = "root";
                    FindNode.ImageIndex = 1;
                    FindNode.SelectedImageIndex = 1;

                    int count = 0;
                    bool Exists = false;

                    foreach (AccordRecipeEdit objRecipe in RecArr)
                    {
                        FindNode = this.m_objViewer.tv.Nodes[0];

                        string[] SplitArr = objRecipe.LevelNameArr;

                        for (int i = 0; i < SplitArr.Length; i++)
                        {
                            Exists = false;
                            for (int j = 0; j < FindNode.Nodes.Count; j++)
                            {
                                if (SplitArr[i] == FindNode.Nodes[j].Text)
                                {
                                    Exists = true;
                                    FindNode = FindNode.Nodes[j];
                                    break;
                                }
                            }

                            if (Exists)
                            {
                                if (i == SplitArr.Length - 1)
                                {
                                    TreeNode tnAdd = new TreeNode(SplitArr[i].Trim());
                                    FindNode.Parent.Nodes.Add(tnAdd);
                                    tnAdd.Tag = objRecipe;
                                    tnAdd.ImageIndex = 0;
                                    tnAdd.SelectedImageIndex = 5;
                                    tnAdd.Name = "child->" + SplitArr[i].Trim();
                                }
                            }
                            else
                            {
                                TreeNode tnAdd = new TreeNode(SplitArr[i].Trim());
                                FindNode.Nodes.Add(tnAdd);
                                if (i == SplitArr.Length - 1)
                                {
                                    tnAdd.Tag = objRecipe;
                                    tnAdd.ImageIndex = 0;
                                    tnAdd.SelectedImageIndex = 5;
                                    tnAdd.Name = "child->" + SplitArr[i].Trim();
                                }
                                else
                                {
                                    tnAdd.ImageIndex = 2;
                                    tnAdd.SelectedImageIndex = 5;
                                    tnAdd.Name = "parent->" + SplitArr[i].Trim();
                                }
                                if (count == 0)
                                {
                                    FirstNode = tnAdd;
                                    count++;
                                }

                                FindNode = tnAdd;
                            }
                        }
                    }

                    this.m_objViewer.tv.EndUpdate();
                    this.m_objViewer.tv.SelectedNode = FirstNode;
                }
            }
            finally
            {
                this.m_objViewer.Cursor = Cursors.Default;
            }
        }

        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="FindStr"></param>
        /// <param name="ChildFlag"></param>
        public void m_mthFindTree(string FindStr, bool ChildFlag)
        {
            bool FindFlag = false;
            TreeNodeCollection nodes = this.m_objViewer.tv.Nodes;
            foreach (TreeNode n in nodes)
            {
                //递归查找树节点
                FindRecursive(n, FindStr.ToLower(), ChildFlag, ref FindFlag);
            }
        }

        /// <summary>
        /// 递归查找树节点
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="FindStr"></param>
        /// <param name="ChildFlag"></param>
        /// <param name="FindFlag"></param>
        private void FindRecursive(TreeNode treeNode, string FindStr, bool ChildFlag, ref bool FindFlag)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                //if (tn.Tag == null)
                //{
                //    continue;
                //}

                if (FindFlag)
                {
                    return;
                }

                if (ChildFlag)
                {
                    if (tn.Name.ToString().ToLower().StartsWith("child"))
                    {
                        AccordRecipeEdit objAR = tn.Tag as AccordRecipeEdit;
                        if (objAR.UserCode_Chr.ToLower().StartsWith(FindStr) || objAR.PyCode_Chr.ToLower().StartsWith(FindStr) ||
                            objAR.WbCode_Chr.ToLower().StartsWith(FindStr) || objAR.Recipename_Chr.ToLower().StartsWith(FindStr))
                        {
                            if (!tn.IsSelected)
                            {
                                this.m_objViewer.tv.SelectedNode = tn;
                            }

                            if (!tn.IsExpanded)
                            {
                                tn.Expand();
                            }

                            FindFlag = true;

                            return;
                        }
                        else
                        {
                            FindRecursive(tn, FindStr, ChildFlag, ref FindFlag);
                        }
                    }
                }
                else
                {
                    string tnName = tn.Name.ToString().ToLower().Replace("parent->", "").Replace("child->", "");
                    if (tnName.StartsWith(FindStr))
                    {
                        if (!tn.IsSelected)
                        {
                            this.m_objViewer.tv.SelectedNode = tn;
                        }

                        if (!tn.IsExpanded)
                        {
                            tn.Expand();
                        }

                        FindFlag = true;

                        return;
                    }
                    else
                    {
                        FindRecursive(tn, FindStr, ChildFlag, ref FindFlag);
                    }
                }
            }
        }
        #endregion

        #region 查找
        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="RecID"></param>
        public void m_mthFindChild(string RecID)
        {
            bool FindFlag = false;
            TreeNodeCollection nodes = this.m_objViewer.tv.Nodes;
            foreach (TreeNode n in nodes)
            {
                //递归查找树节点
                FindRecursiveChild(n, RecID, ref FindFlag);
            }
        }

        /// <summary>
        /// 递归查找树节点
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="RecID"></param>
        /// <param name="FindFlag"></param>
        private void FindRecursiveChild(TreeNode treeNode, string RecID, ref bool FindFlag)
        {
            foreach (TreeNode tn in treeNode.Nodes)
            {
                if (tn.Tag == null)
                {
                    continue;
                }

                if (FindFlag)
                {
                    return;
                }
                                
                if (((AccordRecipeEdit)tn.Tag).RecipeID_Chr == RecID)
                {
                    if (!tn.IsSelected)
                    {
                        this.m_objViewer.tv.SelectedNode = tn;
                    }

                    if (!tn.IsExpanded)
                    {
                        tn.Expand();
                    }

                    FindFlag = true;

                    return;
                }
                else
                {
                    FindRecursiveChild(tn, RecID, ref FindFlag);
                }
            }
        }
        #endregion

        #region 计算总的数量
        /// <summary>
        /// 西药的总数计算方法。有两种算法，可以根据配置选择算法。实际上第二种算法比例符合实际
        /// 无论那一种算法，一定要确保用药天数是频率的天数的倍数
        /// 西药单位知识：如阿莫西林这个药，一盒12粒，一粒有0.5克。这个盒是它的大单位，粒是它的小单位，
        /// 12是它的包装量，克就是剂量单位，0.5就是剂量比例。医生开处方时不会开多少粒这种说法的，
        /// 他只会说1克，或者2克这样说。所以我们要根据他输入的剂量来计算出，而第种算法又要分大单位
        /// 算法和小单位算法。
        /// 方法一：
        /// 大单位:（天数*剂量*频率次数）/(频率天数*剂量比例*包装量) 
        /// 小单位: （天数*剂量*频率次数）/(频率天数*剂量比例) 
        /// 方法二：
        /// 大单位:(剂量/剂量比例*包装量) 取比大于或等于结果的最小整数后再乘(天数/频率天数*频率次数)
        /// 小单位: (剂量/剂量比例) 取比大于或等于结果的最小整数后再乘(天数/频率天数*频率次数)
        ///  取比大于或等于结果的最小整数。例如1.001就等于2
        /// </summary>
        public void m_mthCalculateAmount()
        {
            rowNo = this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
            colNo = this.m_objViewer.ctlDataGrid1.CurrentCell.ColumnNumber;
            if (b_IndexChangeFlag && this.m_objViewer.ctlDataGrid1[rowNo, c_IsCal].ToString() == "0")
            {
                return;
            }
            b_IndexChangeFlag = true;
            decimal decSumCountTemp = clsConvertToDecimal.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Total]);
            if (this.m_objViewer.ctlDataGrid1[rowNo, c_ItemID].ToString() == "")//如果ID为空退出
            {
                return;
            }
            string ItemId = this.m_objViewer.ctlDataGrid1[rowNo, c_ItemID].ToString();
            int TempDay = (int)m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_FreDays]);//频次天数
            int Days = (int)m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Day]);//天数
            if (TempDay != 0 && Days % TempDay != 0)
            {
                MessageBox.Show("输入的天数应该是 " + TempDay.ToString() + " 的倍数", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                int i = (int)Math.Ceiling(Convert.ToDouble(Days / TempDay));
                colNo = 0;
                this.m_objViewer.ctlDataGrid1[rowNo, c_Day] = TempDay;
                this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(rowNo, c_Day);
            }
            else
            {
                if (TempDay != 0)
                {
                    Days = Days / TempDay;
                }
                else
                {
                    Days = 0;
                }
                decimal packet = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Packet]);
                if (packet == 0)
                {
                    packet = 1;
                }
                decimal d_Usage = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Dosage]);
                if (d_Usage == 0)
                {
                    d_Usage = 1;
                }
                decimal iii = 0;
                decimal price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Price]);

                #region 数量计算方法
                if (objSvc.m_blnCheckmedicament(ItemId))
                {
                    if (Trochecalc)
                    {//先算数量再算天数
                        decimal temp1 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_FreTimes]);
                        decimal temp2 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Count]);
                        iii = (decimal)Math.Ceiling((double)(temp2 / (d_Usage)));//什么时候都先用小单位来计算
                        iii = Days * iii * temp1;
                        if (m_objViewer.ctlDataGrid1[rowNo, c_UnitFlag].ToString().Trim() == "0")//如果用大单位来计算时就转成大单位
                        {
                            double dTemp = (double)(iii / packet);
                            iii = (decimal)Math.Ceiling(dTemp);
                        }
                    }
                    else
                    {
                        iii = (decimal)Math.Ceiling((double)(m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_FreTimes]) * Days * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Count]) / (packet * d_Usage)));
                        if (m_objViewer.ctlDataGrid1[rowNo, c_UnitFlag].ToString().Trim() == "1")//小单位
                        {
                            decimal temp1 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_FreTimes]);
                            decimal temp2 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Count]);
                            decimal temp3 = temp1 * Days * temp2 / d_Usage;
                            double temp4 = Math.Ceiling((double)temp3);
                            iii = decimal.Parse(temp4.ToString());
                        }
                    }
                }
                else
                {
                    if (CalFlag)
                    {//先算数量再算天数
                        decimal temp1 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_FreTimes]);
                        decimal temp2 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Count]);
                        iii = (decimal)Math.Ceiling((double)(temp2 / (d_Usage)));//什么时候都先用小单位来计算
                        iii = Days * iii * temp1;
                        if (m_objViewer.ctlDataGrid1[rowNo, c_UnitFlag].ToString().Trim() == "0")//如果用大单位来计算时就转成大单位
                        {
                            double dTemp = (double)(iii / packet);
                            iii = (decimal)Math.Ceiling(dTemp);
                        }
                    }
                    else
                    {
                        iii = (decimal)Math.Ceiling((double)(m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_FreTimes]) * Days * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Count]) / (packet * d_Usage)));
                        if (m_objViewer.ctlDataGrid1[rowNo, c_UnitFlag].ToString().Trim() == "1")//小单位
                        {
                            decimal temp1 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_FreTimes]);
                            decimal temp2 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Count]);
                            decimal temp3 = temp1 * Days * temp2 / d_Usage;
                            double temp4 = Math.Ceiling((double)temp3);
                            iii = decimal.Parse(temp4.ToString());
                        }
                    }
                }
                #endregion

                if (this.m_objViewer.ctlDataGrid1[rowNo, c_IsCal].ToString().Trim() == "1")
                {
                    this.m_objViewer.ctlDataGrid1[rowNo, c_Total] = iii;
                }
                else
                {
                    iii = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_Total]);
                }
            }
        }

        public void m_mthCalculateAmount(int p_intRow)
        {

            if (this.m_objViewer.ctlDataGrid1[p_intRow, c_ItemID].ToString() == "")//如果ID为空退出
            {
                return;
            }
            int TempDay = (int)m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_FreDays]);//频次天数

            int Days = (int)m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_Day]);//天数


            if (TempDay != 0)
            {
                Days = Days / TempDay;
            }
            else
            {
                Days = 0;
            }
            decimal packet = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_Packet]);
            if (packet == 0)
            {
                packet = 1;
            }
            decimal d_Usage = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_Dosage]);
            if (d_Usage == 0)
            {
                d_Usage = 1;
            }
            decimal iii = 0;
            decimal price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_Price]);
            if (CalFlag)
            {
                decimal temp1 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_FreTimes]);
                decimal temp2 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_Count]);
                iii = (decimal)Math.Ceiling((double)(temp2 / (d_Usage)));//什么时候都先用小单位来计算
                iii = Days * iii * temp1;
                if (m_objViewer.ctlDataGrid1[rowNo, c_UnitFlag].ToString().Trim() == "0")//如果用大单位来计算时就转成大单位
                {
                    double dTemp = (double)(iii / packet);
                    iii = (decimal)Math.Ceiling(dTemp);

                }
            }
            else
            {
                iii = (decimal)Math.Ceiling((double)(m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, 15]) * Days * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, 2]) / (packet * d_Usage)));
                if (m_objViewer.ctlDataGrid1[p_intRow, c_UnitFlag].ToString().Trim() == "1")//小单位
                {
                    decimal temp1 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_FreTimes]);
                    decimal temp2 = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_Count]);
                    decimal temp3 = temp1 * Days * temp2 / d_Usage;
                    double temp4 = Math.Ceiling((double)temp3);
                    iii = decimal.Parse(temp4.ToString());
                }
            }
            if (this.m_objViewer.ctlDataGrid1[p_intRow, c_IsCal].ToString().Trim() == "1")
            {
                this.m_objViewer.ctlDataGrid1[p_intRow, c_Total] = iii;
            }
            else
            {
                iii = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[p_intRow, c_Total]);
            }
        }

        /// <summary>
        /// 计算总数(中药)
        /// </summary>
        /// <param name="p_intRow"></param>
        public void m_mthCalculateAmount2(int p_intRow)
        {

            if (this.m_objViewer.ctlDataGrid2[p_intRow, 8].ToString() == "")//如果ID为空退出
            {
                return;
            }
            decimal decSumCountTemp = clsConvertToDecimal.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[p_intRow, 15]);
            double packet = (double)m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[p_intRow, 18]);
            if (packet == 0)
            {
                packet = 1;
            }
            double d_Usage = (double)m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[p_intRow, 12]);
            if (d_Usage == 0)
            {
                d_Usage = 1;
            }
            double temp = (double)m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[p_intRow, 1]);
            decimal iii = (decimal)Math.Ceiling(temp / (packet * d_Usage));
            this.m_objViewer.ctlDataGrid2[p_intRow, 15] = iii;

            decimal price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[p_intRow, 16]);

            if (m_objViewer.ctlDataGrid2[p_intRow, 17].ToString().Trim() == "1")
            {
                iii = (decimal)Math.Ceiling(temp / d_Usage);
                this.m_objViewer.ctlDataGrid2[p_intRow, 15] = iii;
                price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[p_intRow, 6]);
            }
            this.m_objViewer.ctlDataGrid2[p_intRow, 7] = iii * price;
        }
        #endregion

        #region 转换成数字
        /// <summary>
        /// 转换成数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public decimal m_mthConvertObjToDecimal(object obj)
        {
            try
            {
                if (obj != null && obj.ToString() != "")
                {
                    return Convert.ToDecimal(obj.ToString());

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return 0;
            }
        }
        public decimal m_mthConvertObjToDecimal(string str)
        {
            try
            {
                return Convert.ToDecimal(str.Trim());
            }
            catch
            {
                return 0;
            }
        }
        #endregion

        #region 查找用法
        public long m_mthFindUsage(string ID, int row)
        {
            string strItemID = this.m_objViewer.ctlDataGrid1[row, c_ItemID].ToString().Trim();
            string strReItemID = this.m_objViewer.ctlDataGrid1[row, c_resubitem].ToString().Trim();
            string strSubItemID = this.m_objViewer.ctlDataGrid1[row, c_SubItemID].ToString().Trim();
            bool blnSub = objSvc.m_blnIsSubChrgItem(strItemID, strReItemID);

            DataTable dt = null;
            long strRet = objSvc.m_mthFindUsage(ID, 1, out dt);
            if (strRet > 0 && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 1)
                {
                    m_objViewer.ctlDataGrid1[row, c_UsageName] = dt.Rows[0]["USAGENAME_VCHR"].ToString().Trim();

                    m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_FreName);
                    m_objViewer.ctlDataGrid1[row, c_UsageID] = dt.Rows[0]["USAGEID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, c_UsageName] = dt.Rows[0]["USAGENAME_VCHR"].ToString().Trim();

                    return 0;
                }
                else
                {
                    m_objViewer.listView2.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem lv = new ListViewItem(dt.Rows[i]["USAGEID_CHR"].ToString().Trim());//ID
                        lv.SubItems.Add(dt.Rows[i]["USERCODE_CHR"].ToString().Trim());//助记码
                        lv.SubItems.Add(dt.Rows[i]["USAGENAME_VCHR"].ToString().Trim());//名称
                        m_objViewer.listView2.Items.Add(lv);
                    }

                }
                return 1;
            }
            else
            {

                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid1.Columns[6]).DataGridTextBoxColumn.TextBox.SelectAll();
                return -1;

            }
        }
        #endregion

        #region 查找中药用法
        public long m_mthFindUsage2(string ID, int row)
        {
            DataTable dt = null;
            long strRet = objSvc.m_mthFindUsage(ID, 2, out dt);
            if (strRet > 0 && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 1)
                {
                    m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(row + 1, 0);
                    m_objViewer.ctlDataGrid2[row, 5] = dt.Rows[0]["USAGENAME_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 21] = dt.Rows[0]["USAGEID_CHR"].ToString().Trim();

                    //直接填充datagrid
                    return 0;
                }
                else
                {
                    m_objViewer.listView4.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem lv = new ListViewItem(dt.Rows[i]["USAGEID_CHR"].ToString().Trim());//ID
                        lv.SubItems.Add(dt.Rows[i]["USERCODE_CHR"].ToString().Trim());//助记码
                        lv.SubItems.Add(dt.Rows[i]["USAGENAME_VCHR"].ToString().Trim());//名称
                        m_objViewer.listView4.Items.Add(lv);
                    }

                    //填充listView

                }
                return 1;
            }
            else
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid2.Columns[5]).DataGridTextBoxColumn.TextBox.SelectAll();
                return -1;
            }
        }
        #endregion

        #region 天数回车事件
        public void m_mthDaysEnter(string str)
        {
            if (str.Trim() == "")
            {
                return;
            }
            else
            {
                int temp = this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
                SendKeys.SendWait("{Tab}");
            }
        }
        #endregion

        #region 控制列的跳转
        public void m_mthSetColNo1()
        {
            int col = this.m_objViewer.ctlDataGrid1.CurrentCell.ColumnNumber;
            int row = this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
            bool temp = false;
            //if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, c_IsMain]) > -1)
            //{
            //    temp = true;
            //}
            if (temp)//这些组合中的子项目的跳转方法。
            {
                if (col > 2 && col < 13)//直接跳到总数
                {
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Total);
                }
                if (col > 13)
                {
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row + 1, c_GroupNo);
                }
            }
            else
            {
                if (col > 2 && col < 6)
                {
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_UsageName);
                }
                if (col > 8 && col < 12)
                {
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Total);
                }
                if (col > 13)
                {
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row + 1, c_GroupNo);
                }
            }
        }

        public void m_mthSetColNo2()
        {
            int col = this.m_objViewer.ctlDataGrid2.CurrentCell.ColumnNumber;
            int row = this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber;

            if (col > 1 && col < 5)
            {
                this.m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(row, 5);
            }
            if (col > 5 && col < cm_Deptmed)
            {
                this.m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(row, cm_Deptmed);
            }
            if (col > cm_Deptmed)
            {
                this.m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(row + 1, 0);
            }

            if (this.m_objViewer.ctlDataGrid2.CurrentCell.ColumnNumber != cm_Deptmed)
            {
                //this.m_objViewer.cboDeptmed2.Hide();
            }
        }

        public void m_mthSetColNo6()
        {
            int row = this.m_objViewer.ctlDataGrid6.CurrentCell.RowNumber;
            bool isCouPrice = this.m_objViewer.ctlDataGrid6[row, o_PriceFlag].ToString().Trim() == "0";
            if (isCouPrice)//如果不是自定义价格的就直接跟到下一行
            {
                if (this.m_objViewer.ctlDataGrid6.CurrentCell.ColumnNumber > 1 && this.m_objViewer.ctlDataGrid6.CurrentCell.ColumnNumber < o_Deptmed)
                {
                    this.m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(row, o_Deptmed);
                }
                if (this.m_objViewer.ctlDataGrid6.CurrentCell.ColumnNumber > o_Deptmed)
                {
                    this.m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(row + 1, 0);
                }
            }
            else//跳到单价
            {
                if (this.m_objViewer.ctlDataGrid6.CurrentCell.ColumnNumber > o_Count && this.m_objViewer.ctlDataGrid6.CurrentCell.ColumnNumber < o_Price)
                {
                    this.m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(row, o_Price);
                }
                if (this.m_objViewer.ctlDataGrid6.CurrentCell.ColumnNumber > o_Price && this.m_objViewer.ctlDataGrid6.CurrentCell.ColumnNumber < o_Deptmed)
                {
                    this.m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(row, o_Deptmed);
                }
                if (this.m_objViewer.ctlDataGrid6.CurrentCell.ColumnNumber > o_Deptmed)
                {
                    this.m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(row + 1, 0);
                }
            }

            if (this.m_objViewer.ctlDataGrid6.CurrentCell.ColumnNumber != o_Deptmed)
            {
                //this.m_objViewer.cboDeptmed6.Hide();
            }
        }
        public void m_mthSetColNoLis()
        {
            int row = this.m_objViewer.ctlDataGridLis.CurrentCell.RowNumber;

            if (this.m_objViewer.ctlDataGridLis.CurrentCell.ColumnNumber > t_Count && this.m_objViewer.ctlDataGridLis.CurrentCell.ColumnNumber < t_PartName)
            {
                this.m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(row, t_PartName);
                return;
            }

            if (this.m_objViewer.ctlDataGridLis.CurrentCell.ColumnNumber > t_PartName && this.m_objViewer.ctlDataGridLis.CurrentCell.ColumnNumber < t_quick)
            {
                this.m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(row, t_quick);
            }
            else if (this.m_objViewer.ctlDataGridLis.CurrentCell.ColumnNumber > t_quick)
            {
                this.m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(row + 1, t_Find);
            }

            if (this.m_objViewer.ctlDataGridLis.CurrentCell.ColumnNumber != t_quick)
            {
                //this.m_objViewer.cboquick.Hide();
            }
        }
        public void m_mthSetColNoTest()
        {
            int row = this.m_objViewer.ctlDataGridTest.CurrentCell.RowNumber;

            if (this.m_objViewer.ctlDataGridTest.CurrentCell.ColumnNumber > t_Count && this.m_objViewer.ctlDataGridTest.CurrentCell.ColumnNumber < t_PartName)
            {
                this.m_objViewer.ctlDataGridTest.CurrentCell = new DataGridCell(row, t_PartName);
                return;
            }

            if (this.m_objViewer.ctlDataGridTest.CurrentCell.ColumnNumber > t_PartName)
            {
                this.m_objViewer.ctlDataGridTest.CurrentCell = new DataGridCell(row + 1, 0);
            }
        }
        public void m_mthSetColNoOps()
        {
            int row = this.m_objViewer.ctlDataGridOps.CurrentCell.RowNumber;

            if (this.m_objViewer.ctlDataGridOps.CurrentCell.ColumnNumber > 1)
            {
                this.m_objViewer.ctlDataGridOps.CurrentCell = new DataGridCell(row + 1, 0);
            }
        }
        #endregion

        #region 查找用服频率(西药)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public long m_mthFindFrequency(string ID, int row)
        {
            //修改
            DataTable dt = null;
            long strRet = objSvc.m_mthFindFrequency(ID, out dt);
            if (strRet > 0 && dt.Rows.Count > 0)
            {

                if (dt.Rows.Count == 1)
                {
                    m_objViewer.ctlDataGrid1[row, c_IsCal] = 1;
                    m_objViewer.ctlDataGrid1[row, c_FreID] = dt.Rows[0]["FREQID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, c_FreName] = dt.Rows[0]["FREQNAME_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, c_FreDays] = dt.Rows[0]["DAYS_INT"].ToString().Trim();
                    if (this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[row, c_Day]) % this.m_mthConvertObjToDecimal(dt.Rows[0]["DAYS_INT"]) != 0)
                    {
                        m_objViewer.ctlDataGrid1[row, c_Day] = dt.Rows[0]["DAYS_INT"].ToString().Trim();
                    }
                    m_objViewer.ctlDataGrid1[row, c_FreTimes] = dt.Rows[0]["TIMES_INT"].ToString().Trim();
                    m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Day);
                    m_objViewer.ctlDataGrid1[row, c_FreName] = dt.Rows[0]["FREQNAME_CHR"].ToString().Trim();

                    //直接填充datagrid
                    return 0;
                }
                else
                {
                    m_objViewer.listView3.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem lv = new ListViewItem(dt.Rows[i]["FREQID_CHR"].ToString().Trim());//ID
                        lv.SubItems.Add(dt.Rows[i]["USERCODE_CHR"].ToString().Trim());//助记码
                        lv.SubItems.Add(dt.Rows[i]["FREQNAME_CHR"].ToString().Trim());//名称
                        lv.SubItems.Add(dt.Rows[i]["TIMES_INT"].ToString().Trim());//次数
                        lv.SubItems.Add(dt.Rows[i]["DAYS_INT"].ToString().Trim());//天数
                        m_objViewer.listView3.Items.Add(lv);
                    }

                    //填充listView

                }
                return 1;
            }
            else
            {

                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid1.Columns[6]).DataGridTextBoxColumn.TextBox.SelectAll();
                return -1;

            }
        }
        #endregion

        #region 查找西药处方项目
        /// <summary>
        /// 根据查询内容查找药品
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindWMedicineByID(string ID, int row)
        {
            //修改
            DataTable dt = null;
            long strRet = objSvc.m_lngFindChargeItem(ID, 1, out dt);
            if (strRet > 0 && dt.Rows.Count > 0)
            {
                m_objViewer.listView1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (Medpurview == 2)
                    {
                        if (dt.Rows[i]["ISCHLORPROMAZINE_CHR"].ToString().ToUpper() == "T" || dt.Rows[i]["ISCHLORPROMAZINE2_CHR"].ToString().ToUpper() == "T")
                        {
                            if (Neurpur != "1")
                            {
                                continue;
                            }
                        }

                        if (dt.Rows[i]["ISANAESTHESIA_CHR"].ToString().ToUpper() == "T" || dt.Rows[i]["ispoison_chr"].ToString().ToUpper() == "T")
                        {
                            if (Drugpur != "1")
                            {
                                continue;
                            }
                        }
                    }

                    ListViewItem lv = new ListViewItem(dt.Rows[i]["TYPE"].ToString().Trim());//查询码
                    lv.SubItems.Add(dt.Rows[i]["ITEMNAME_VCHR"].ToString().Trim());//名称
                    lv.SubItems.Add(dt.Rows[i]["ITEMCOMMNAME_VCHR"].ToString().Trim());//通用名称
                    lv.SubItems.Add(dt.Rows[i]["ITEMENGNAME_VCHR"].ToString().Trim());// 英文名
                    lv.SubItems.Add(this.m_mthConvertToChType(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString()));// 发票分类名称
                    lv.SubItems.Add(dt.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim());//规格
                    lv.SubItems.Add(dt.Rows[i]["NMLDOSAGE_DEC"].ToString().Trim());//常用量
                    lv.SubItems.Add(dt.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim());//单位
                    if (dt.Rows[0]["opchargeflg_int"].ToString().Trim() == "0")//判断大小单位
                    {
                        lv.SubItems.Add(dt.Rows[i]["ITEMPRICE_MNY"].ToString().Trim());//大单位
                    }
                    else
                    {
                        lv.SubItems.Add(dt.Rows[i]["SubMoney"].ToString().Trim());//小单价
                    }
                    lv.SubItems.Add(dt.Rows[i]["PRECENT_DEC"].ToString().Trim());//比例
                    lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());//医保分类
                    lv.SubItems.Add("");
                    //if (dt.Rows[i]["NOQTYFLAG_INT"].ToString().Trim() == "0")
                    //{
                    //    lv.SubItems.Add("");//是否缺药
                    //}
                    //else
                    //{
                    //    if (!isShowLackMedicine)
                    //    {
                    //        continue;
                    //    }
                    //    if (m_mthRelationInfo(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim()) == "0001")
                    //    {
                    //        lv.SubItems.Add("缺药");
                    //        lv.ForeColor = Color.Red;
                    //    }
                    //    else
                    //    {
                    //        lv.SubItems.Add("库存不足");
                    //        lv.ForeColor = Color.MediumBlue;
                    //    }
                    //}
                    lv.SubItems.Add(m_mthRelationInfo(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim()));//门诊发票分类(大类)                        

                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                if (m_objViewer.listView1.Items.Count > 0)
                {
                    m_objViewer.listView1.Height = 175;
                    m_objViewer.listView1.Visible = true;
                    m_objViewer.listView1.Items[0].Selected = true;
                    m_objViewer.listView1.Select();
                    m_objViewer.listView1.Focus();
                }
                else
                {
                    MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
        }
        #endregion

        #region 查找对应表信息
        private DataTable dt_RelationInfo;
        private string m_mthRelationInfo(string strCatID)
        {
            string str = "0005";//默认其他
            for (int i = 0; i < this.dt_RelationInfo.Rows.Count; i++)
            {
                if (strCatID == this.dt_RelationInfo.Rows[i]["CATID_CHR"].ToString().Trim())
                {
                    str = this.dt_RelationInfo.Rows[i]["GROUPID_CHR"].ToString().Trim();
                    break;
                }
            }

            if (str == "0006")
            {
                str = "0005";
            }

            return str;
        }
        /// <summary>
        /// 根据ID转换成中文类别
        /// </summary>
        /// <param name="strTypeNo"></param>
        /// <returns></returns>
        private string m_mthConvertToChType(string strTypeNo)
        {
            string strRet = "";
            {
                for (int i = 0; i < objResult.Length; i++)
                {
                    if (strTypeNo == objResult[i].m_strTypeID.Trim())
                    {
                        strRet = objResult[i].m_strTypeName;
                        break;
                    }
                }
            }

            return strRet;
        }
        #endregion

        #region 加载项目分类
        private clsChargeItemEXType_VO[] objResult = null;
        private void m_mthLoadCat()
        {
            clsDomainControl_ChargeItem clsDomain = new clsDomainControl_ChargeItem();
            long l = clsDomain.m_GetEXType("2", out objResult);
            if (l < 0)
            {
                MessageBox.Show("加载项目分类失败!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            l = objSvc.m_mthRelationInfo(out this.dt_RelationInfo);
            if (l < 0)
            {
                MessageBox.Show("加载关系表失败!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 设置所有DataGrid的列回车转为空格键
        private void m_mthSetDataGridEnterToSpace()
        {
            //西药
            m_objViewer.ctlDataGrid1.m_mthAddEnterToSpaceColumn(c_GroupNo);
            m_objViewer.ctlDataGrid1.m_mthAddEnterToSpaceColumn(c_Find);
            m_objViewer.ctlDataGrid1.m_mthAddEnterToSpaceColumn(c_Count);
            m_objViewer.ctlDataGrid1.m_mthAddEnterToSpaceColumn(c_UsageName);
            m_objViewer.ctlDataGrid1.m_mthAddEnterToSpaceColumn(c_FreName);
            m_objViewer.ctlDataGrid1.m_mthAddEnterToSpaceColumn(c_Day);
            m_objViewer.ctlDataGrid1.m_mthAddEnterToSpaceColumn(c_Total);
            //中药
            m_objViewer.ctlDataGrid2.m_mthAddEnterToSpaceColumn(0);
            m_objViewer.ctlDataGrid2.m_mthAddEnterToSpaceColumn(1);
            m_objViewer.ctlDataGrid2.m_mthAddEnterToSpaceColumn(5);
            //其他
            m_objViewer.ctlDataGrid6.m_mthAddEnterToSpaceColumn(0);
            m_objViewer.ctlDataGrid6.m_mthAddEnterToSpaceColumn(1);
            m_objViewer.ctlDataGrid6.m_mthAddEnterToSpaceColumn(o_Price);

            //检验诊疗项目
            m_objViewer.ctlDataGridLis.m_mthAddEnterToSpaceColumn(0);
            m_objViewer.ctlDataGridLis.m_mthAddEnterToSpaceColumn(1);
            m_objViewer.ctlDataGridLis.m_mthAddEnterToSpaceColumn(t_PartName);
            m_objViewer.ctlDataGridLis.m_mthAddEnterToSpaceColumn(t_quick);
            //检查诊疗项目
            m_objViewer.ctlDataGridTest.m_mthAddEnterToSpaceColumn(0);
            m_objViewer.ctlDataGridTest.m_mthAddEnterToSpaceColumn(1);
            m_objViewer.ctlDataGridTest.m_mthAddEnterToSpaceColumn(t_PartName);
            //手术治疗诊疗项目
            m_objViewer.ctlDataGridOps.m_mthAddEnterToSpaceColumn(0);
            m_objViewer.ctlDataGridOps.m_mthAddEnterToSpaceColumn(1);
        }
        #endregion

        #region 频次和用法的ListViewKeyDown处理
        public void m_mthListViewKeyDown2(System.Windows.Forms.KeyEventArgs e)
        {//修改
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthListViewDoubleClick2();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView2.Visible = false;
                this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, 6);
            }
        }
        public void m_mthListView4KeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthListViewDoubleClick4();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView4.Visible = false;
                this.m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 5);
            }
        }
        public void m_mthListViewKeyDown3(System.Windows.Forms.KeyEventArgs e)//频次
        {
            //修改
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthListViewDoubleClick3();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView3.Visible = false;
                this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, 7);
            }
        }
        //双击事件
        public void m_mthListViewDoubleClick2()
        {
            int row = m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
            string strItemID = this.m_objViewer.ctlDataGrid1[row, c_ItemID].ToString().Trim();
            string strReItemID = this.m_objViewer.ctlDataGrid1[row, c_resubitem].ToString().Trim();
            string strSubItemID = this.m_objViewer.ctlDataGrid1[row, c_SubItemID].ToString().Trim();
            bool blnSub = objSvc.m_blnIsSubChrgItem(strItemID, strReItemID);
            //修改				
            string strUsageID = m_objViewer.ctlDataGrid1[row, c_UsageID].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_UsageID] = m_objViewer.listView2.SelectedItems[0].SubItems[0].Text.Trim();
            m_objViewer.ctlDataGrid1[row, c_UsageName] = m_objViewer.listView2.SelectedItems[0].SubItems[2].Text.Trim();

            m_objViewer.listView2.Hide();
            m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_FreName);
        }
        public void m_mthListViewDoubleClick4()
        {
            int row = m_objViewer.ctlDataGrid2.CurrentCell.RowNumber;
            string strUsageID = m_objViewer.ctlDataGrid2[row, 21].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 21] = m_objViewer.listView4.SelectedItems[0].SubItems[0].Text.Trim();
            m_objViewer.ctlDataGrid2[row, 5] = m_objViewer.listView4.SelectedItems[0].SubItems[2].Text.Trim();
            m_objViewer.listView4.Hide();
            m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(row + 1, 0);
        }
        public void m_mthListViewDoubleClick3()//频次
        {
            //修改
            int row = m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
            m_objViewer.ctlDataGrid1[row, c_FreID] = m_objViewer.listView3.SelectedItems[0].SubItems[0].Text.Trim();
            m_objViewer.ctlDataGrid1[row, c_FreName] = m_objViewer.listView3.SelectedItems[0].SubItems[2].Text.Trim();
            m_objViewer.ctlDataGrid1[row, c_FreTimes] = m_objViewer.listView3.SelectedItems[0].SubItems[3].Text.Trim();
            m_objViewer.ctlDataGrid1[row, c_FreDays] = m_objViewer.listView3.SelectedItems[0].SubItems[4].Text.Trim();
            if (this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[row, c_Day]) % this.m_mthConvertObjToDecimal(m_objViewer.listView3.SelectedItems[0].SubItems[4].Text) != 0)
            {
                m_objViewer.ctlDataGrid1[row, c_Day] = m_objViewer.listView3.SelectedItems[0].SubItems[4].Text.Trim();
            }

            m_objViewer.ctlDataGrid1[row, c_IsCal] = 1;
            m_objViewer.listView3.Hide();
            m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Day);
        }
        #endregion

        #region listViewKeyDown处理
        public void m_mthListViewKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            switch (this.m_objViewer.tabControl1.SelectedIndex)
            {
                case 0:
                    m_mthKeyDown1(e);
                    break;
                case 1:
                    m_mthKeyDown2(e);
                    break;
                case 2:
                    m_mthKeyDown3(e);
                    break;
                case 3:
                    m_mthKeyDown4(e);
                    break;
                case 4:
                    m_mthKeyDown5(e);
                    break;
                case 5:
                    m_mthKeyDown6(e);
                    break;

            }
        }
        private void m_mthKeyDown1(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView1.Height = 0;
                this.m_objViewer.listView1.Visible = false;
                this.m_objViewer.ctlDataGrid1.Select();
                this.m_objViewer.ctlDataGrid1.Focus();
                this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_Find);
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthListViewDoubleClick();
            }
        }
        private void m_mthKeyDown2(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView1.Height = 0;
                this.m_objViewer.listView1.Visible = false;
                this.m_objViewer.ctlDataGrid2.Select();
                this.m_objViewer.ctlDataGrid2.Focus();
                this.m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 0);
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthListViewDoubleClick();
            }
        }
        private void m_mthKeyDown3(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView1.Height = 0;
                this.m_objViewer.listView1.Visible = false;

                this.m_objViewer.ctlDataGridLis.Select();
                this.m_objViewer.ctlDataGridLis.Focus();
                this.m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGridLis.CurrentCell.RowNumber, 0);
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthListViewDoubleClick();
            }
        }
        private void m_mthKeyDown4(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView1.Height = 0;
                this.m_objViewer.listView1.Visible = false;

                this.m_objViewer.ctlDataGridTest.Select();
                this.m_objViewer.ctlDataGridTest.Focus();
                this.m_objViewer.ctlDataGridTest.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGridTest.CurrentCell.RowNumber, 0);
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthListViewDoubleClick();
            }
        }
        private void m_mthKeyDown5(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView1.Height = 0;
                this.m_objViewer.listView1.Visible = false;
                this.m_objViewer.ctlDataGridOps.Select();

                this.m_objViewer.ctlDataGridOps.Focus();
                this.m_objViewer.ctlDataGridOps.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGridOps.CurrentCell.RowNumber, 0);
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthListViewDoubleClick();
            }
        }
        private void m_mthKeyDown6(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView1.Height = 0;
                this.m_objViewer.listView1.Visible = false;
                this.m_objViewer.ctlDataGrid6.Select();
                this.m_objViewer.ctlDataGrid6.Focus();
                this.m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, 0);
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.m_mthListViewDoubleClick();
            }
        }
        #endregion

        #region listView(查询结果)双击事件
        /// <summary>
        /// listView(查询结果)双击事件
        /// </summary>
        public void m_mthListViewDoubleClick()
        {
            if (m_objViewer.listView1.SelectedItems.Count > 0 || m_objViewer.listView1.SelectedItems[0].ForeColor != Color.Red)
            {
                string TabPageName = this.m_objViewer.tabControl1.SelectedTab.Name.ToString();

                if (TabPageName == "tabPage1")
                {
                    string strChrgCode = this.m_objViewer.listView1.SelectedItems[0].SubItems[12].Text;
                    if (strChrgCode != null && strChrgCode != "")
                    {
                        int index = int.Parse(strChrgCode) - 1;
                        this.m_objViewer.tabControl1.SelectedIndex = index;
                    }
                }
                switch (TabPageName)
                {
                    case "tabPage1":
                        m_mthDoubleClick1();
                        break;
                    case "tabPage2":
                        m_mthDoubleClick2();
                        break;
                    case "tabPage3":
                        m_mthDoubleClick3();
                        break;
                    case "tabPage4":
                        m_mthDoubleClick4();
                        break;
                    case "tabPage5":
                        m_mthDoubleClick5();
                        break;
                    case "tabPage6":
                        m_mthDoubleClick6();
                        break;
                }
            }
        }
        private void m_mthDoubleClick1()
        {
            int row = rowNo;
            DataRow dr = (DataRow)m_objViewer.listView1.SelectedItems[0].Tag;
            m_mthFillDataGridByRow(dr, row);
        }
        private void m_mthFillDataGridByRow(DataRow dr, int row)
        {
            #region 精神性、毒麻药处理
            if (Medpurview == 1)
            {
                if (dr["ISCHLORPROMAZINE_CHR"].ToString().ToUpper() == "T" || dr["ISCHLORPROMAZINE2_CHR"].ToString().ToUpper() == "T")
                {
                    if (Neurpur != "1")
                    {
                        MessageBox.Show(Neurpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                if (dr["ISANAESTHESIA_CHR"].ToString().ToUpper() == "T" || dr["ispoison_chr"].ToString().ToUpper() == "T")
                {
                    if (Drugpur != "1")
                    {
                        MessageBox.Show(Drugpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else if (Medpurview == 2)
            {
                if (dr["ISCHLORPROMAZINE_CHR"].ToString().ToUpper() == "T" || dr["ISCHLORPROMAZINE2_CHR"].ToString().ToUpper() == "T")
                {
                    if (Neurpur != "1")
                    {
                        MessageBox.Show(Neurpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                if (dr["ISANAESTHESIA_CHR"].ToString().ToUpper() == "T" || dr["ispoison_chr"].ToString().ToUpper() == "T")
                {
                    if (Drugpur != "1")
                    {
                        MessageBox.Show(Drugpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            #endregion

            #region
            string strCurrItem = m_objViewer.ctlDataGrid1[row, c_ItemID].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
            
            m_objViewer.ctlDataGrid1[row, c_Count] = dr["ADULTDOSAGE_DEC"].ToString().Trim();

            m_objViewer.ctlDataGrid1[row, c_Unit] = dr["DOSAGEUNIT_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_Name] = dr["ITEMNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_Spec] = dr["ITEMSPEC_VCHR"].ToString().Trim();

            m_objViewer.ctlDataGrid1[row, c_Price] = dr["SubMoney"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_BigUnit] = dr["ITEMIPUNIT_CHR"].ToString().Trim();
            if (dr["opchargeflg_int"].ToString().Trim() == "0")//判断大小单位
            {
                m_objViewer.ctlDataGrid1[row, c_Price] = dr["ITEMPRICE_MNY"].ToString().Trim();//大单价
                m_objViewer.ctlDataGrid1[row, c_BigUnit] = dr["ITEMOPUNIT_CHR"].ToString().Trim();
            }
            m_objViewer.ctlDataGrid1[row, c_ItemID] = dr["ITEMID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_Packet] = dr["PACKQTY_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_DiscountName] = dr["PRECENT_DEC"].ToString().Trim() + "%";//比例
            m_objViewer.ctlDataGrid1[row, c_Discount] = dr["PRECENT_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_UnitFlag] = dr["opchargeflg_int"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_Dosage] = m_mthConvertObjToDecimal(dr["DOSAGE_DEC"]);
            m_objViewer.ctlDataGrid1[row, c_MaxLimit] = dr["MAXDOSAGE_DEC"].ToString().Trim();//上限
            m_objViewer.ctlDataGrid1[row, c_MinLimit] = dr["MINDOSAGE_DEC"].ToString().Trim();//下限
            m_objViewer.ctlDataGrid1[row, c_IsCal] = 1;
            m_objViewer.ctlDataGrid1[row, c_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();//发票分类
            string tempUsageID = m_objViewer.ctlDataGrid1[row, 16].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_UsageName] = dr["USAGENAME_VCHR"].ToString().Trim();//默认用法名称
            m_objViewer.ctlDataGrid1[row, c_UsageID] = dr["USAGEID_CHR"].ToString().Trim();//默认用法ID
            m_objViewer.ctlDataGrid1[row, c_EnglishName] = dr["ITEMENGNAME_VCHR"].ToString().Trim();//英文名			

            this.m_objViewer.ctlDataGrid1[row, c_FreName] = dr["freqname"].ToString();
            this.m_objViewer.ctlDataGrid1[row, c_FreDays] = m_mthConvertObjToDecimal(dr["freqdays"]);
            this.m_objViewer.ctlDataGrid1[row, c_FreTimes] = m_mthConvertObjToDecimal(dr["freqtimes"]);
            this.m_objViewer.ctlDataGrid1[row, c_FreID] = dr["freqid"].ToString();

            try
            {
                m_objViewer.ctlDataGrid1[row, c_PSFlag] = dr["HYPE_INT"].ToString().Trim();//皮试标志
                if (dr["HYPE_INT"].ToString().Trim() == "1")//如果此药要皮试则默认为皮试
                {
                    m_objViewer.ctlDataGrid1[row, c_PS] = 1;
                    this.m_objViewer.ctlDataGrid1.m_mthFormatCell(row, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Red);
                }
                else
                {
                    this.m_objViewer.ctlDataGrid1.m_mthFormatCell(row, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Black);
                }

                this.m_objViewer.ctlDataGrid1[row, c_Deptmed] = "";
                this.m_objViewer.ctlDataGrid1[row, c_DeptmedID] = "";
                if (dr["DEPTPREP_INT"].ToString() != "1")
                {
                    this.m_objViewer.ctlDataGrid1[row, c_DeptmedID] = "*";  //不允许科室自备                   
                }
            }
            catch
            {

            }

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Count);
            m_objViewer.ctlDataGrid1[row, c_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_IsMain] = -4;

            #endregion
        }
        private void m_mthDoubleClick2()
        {
            int row = rowNo;
            DataRow dr = (DataRow)m_objViewer.listView1.SelectedItems[0].Tag;
            m_mthFillDataGridByRow2(dr, row);

        }
        private void m_mthFillDataGridByRow2(DataRow dr, int row)
        {
            #region 精神性、毒麻药处理
            if (Medpurview == 1)
            {
                if (dr["ISCHLORPROMAZINE_CHR"].ToString().ToUpper() == "T" || dr["ISCHLORPROMAZINE2_CHR"].ToString().ToUpper() == "T")
                {
                    if (Neurpur != "1")
                    {
                        MessageBox.Show(Neurpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

                if (dr["ISANAESTHESIA_CHR"].ToString().ToUpper() == "T" || dr["ispoison_chr"].ToString().ToUpper() == "T")
                {
                    if (Drugpur != "1")
                    {
                        MessageBox.Show(Drugpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else if (Medpurview == 2)
            {
                if (dr["ISCHLORPROMAZINE_CHR"].ToString().ToUpper() == "T" || dr["ISCHLORPROMAZINE2_CHR"].ToString().ToUpper() == "T")
                {
                    if (Neurpur != "1")
                    {
                        MessageBox.Show(Neurpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                if (dr["ISANAESTHESIA_CHR"].ToString().ToUpper() == "T" || dr["ispoison_chr"].ToString().ToUpper() == "T")
                {
                    if (Drugpur != "1")
                    {
                        MessageBox.Show(Drugpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }
            }
            #endregion

            m_objViewer.ctlDataGrid2[row, 0] = dr["ITEMCODE_VCHR"].ToString().Trim();

            m_objViewer.ctlDataGrid2[row, 1] = dr["ADULTDOSAGE_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 11] = dr["ADULTDOSAGE_DEC"].ToString().Trim();

            m_objViewer.ctlDataGrid2[row, 2] = dr["DOSAGEUNIT_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 3] = dr["ITEMNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 4] = dr["ITEMSPEC_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 5] = dr["usagename_vchr"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 6] = dr["SubMoney"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 8] = dr["ITEMID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 10] = dr["PRECENT_DEC"].ToString().Trim() + "%";//比例
            m_objViewer.ctlDataGrid2[row, 11] = dr["PRECENT_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 13] = dr["MAXDOSAGE_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 14] = dr["MINDOSAGE_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 16] = dr["ITEMPRICE_MNY"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 17] = dr["opchargeflg_int"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 18] = dr["PACKQTY_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 19] = 0;
            m_objViewer.ctlDataGrid2[row, 20] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();//发票分类
            m_objViewer.ctlDataGrid2[row, 21] = dr["USAGEID_CHR"].ToString().Trim();    //用法ID
            m_objViewer.ctlDataGrid2[row, 24] = dr["ITEMENGNAME_VCHR"].ToString().Trim();//英文名

            try
            {
                m_objViewer.listView1.Height = 0;
                m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(row, 1);
                m_objViewer.ctlDataGrid2[row, 0] = dr["ITEMCODE_VCHR"].ToString().Trim();
            }
            catch
            {
            }
        }
        private void m_mthDoubleClick3()
        {
            int row = rowNo;
            DataRow dr = (DataRow)m_objViewer.listView1.SelectedItems[0].Tag;

            m_mthFillDataGridByRowLis(dr, row);
        }
        private void m_mthFillDataGridByRowLis(DataRow dr, int row)
        {
            string strCurrItem = m_objViewer.ctlDataGridLis[row, t_ItemID].ToString().Trim();
            m_objViewer.ctlDataGridLis[row, t_Find] = dr["USERCODE_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridLis[row, t_Name] = dr["NAME_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridLis[row, t_Spec] = dr["itemspec_vchr"].ToString().Trim();//规格
            m_objViewer.ctlDataGridLis[row, t_PartName] = dr["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGridLis[row, t_Unit] = dr["itemunit"].ToString().Trim();
            m_objViewer.ctlDataGridLis[row, t_ItemID] = dr["ORDERDICID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridLis[row, t_PriceFlag] = dr["LISAPPLYUNITID_CHR"].ToString().Trim(); //用自定价格列记录申请单元ID        
            m_objViewer.ctlDataGridLis[row, t_InvoiceType] = this.m_mthConvertToChType(dr["ITEMOPINVTYPE_CHR"].ToString());
            m_objViewer.ctlDataGridLis[row, t_EnglishName] = dr["ENGNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGridLis[row, t_Temp] = dr["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridLis[row, t_Count] = 1;

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(row, t_Count);
        }

        private void m_mthDoubleClick4()
        {
            int row = rowNo;
            DataRow dr = (DataRow)m_objViewer.listView1.SelectedItems[0].Tag;

            m_mthFillDataGridByRowTest(dr, row);
        }

        private void m_mthFillDataGridByRowTest(DataRow dr, int row)
        {
            string strCurrItem = m_objViewer.ctlDataGridTest[row, t_ItemID].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_Find] = dr["USERCODE_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_Name] = dr["NAME_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_Spec] = dr["itemspec_vchr"].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_PartName] = dr["partname"].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_Unit] = dr["itemunit"].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_Price] = "";
            m_objViewer.ctlDataGridTest[row, t_ItemID] = dr["ORDERDICID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_PriceFlag] = dr["APPLYTYPEID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_DiscountName] = "";//比例
            m_objViewer.ctlDataGridTest[row, t_Discount] = "";
            m_objViewer.ctlDataGridTest[row, t_InvoiceType] = this.m_mthConvertToChType(dr["ITEMOPINVTYPE_CHR"].ToString());
            m_objViewer.ctlDataGridTest[row, t_EnglishName] = dr["ENGNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_Temp] = dr["partid_vchr"].ToString().Trim();
            m_objViewer.ctlDataGridTest[row, t_Count] = 1;
            m_objViewer.ctlDataGridTest[row, t_UsageID] = dr["usageid_chr"].ToString().Trim();

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGridTest.CurrentCell = new DataGridCell(row, t_Count);
        }

        private void m_mthDoubleClick5()
        {
            int row = rowNo;
            DataRow dr = (DataRow)m_objViewer.listView1.SelectedItems[0].Tag;
            m_mthFillDataGridByRowOps(dr, row);
        }

        private void m_mthFillDataGridByRowOps(DataRow dr, int row)
        {
            string strCurrItem = m_objViewer.ctlDataGridOps[row, o_ItemID].ToString().Trim();
            m_objViewer.ctlDataGridOps[row, o_Find] = dr["USERCODE_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridOps[row, o_Name] = dr["NAME_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridOps[row, o_Spec] = dr["itemspec_vchr"].ToString().Trim();
            m_objViewer.ctlDataGridOps[row, o_Unit] = dr["itemunit"].ToString().Trim();
            m_objViewer.ctlDataGridOps[row, o_Price] = "";
            m_objViewer.ctlDataGridOps[row, o_ItemID] = dr["ORDERDICID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGridOps[row, o_PriceFlag] = dr["APPLYTYPEID_CHR"].ToString().Trim();  //用自定义价格列存申请单类型
            m_objViewer.ctlDataGridOps[row, o_DiscountName] = "";//比例
            m_objViewer.ctlDataGridOps[row, o_Discount] = "";
            m_objViewer.ctlDataGridOps[row, o_InvoiceType] = this.m_mthConvertToChType(dr["ITEMOPINVTYPE_CHR"].ToString());
            m_objViewer.ctlDataGridOps[row, o_EnglishName] = dr["ENGNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGridOps[row, o_Count] = 1;
            m_objViewer.ctlDataGridOps[row, o_UsageID] = dr["usageid_chr"].ToString().Trim();

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGridOps.CurrentCell = new DataGridCell(row, o_Count);
        }

        private void m_mthDoubleClick6()
        {
            int row = rowNo;
            DataRow dr = (DataRow)m_objViewer.listView1.SelectedItems[0].Tag;
            m_mthFillDataGridByRow6(dr, row);
        }

        private void m_mthFillDataGridByRow6(DataRow dr, int row)
        {
            string strCurrItem = m_objViewer.ctlDataGrid6[row, o_ItemID].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_Name] = dr["ITEMNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_Spec] = dr["ITEMSPEC_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_Unit] = dr["ITEMOPUNIT_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_Price] = dr["ITEMPRICE_MNY"].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_ItemID] = dr["ITEMID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_PriceFlag] = dr["SELFDEFINE_INT"].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_DiscountName] = dr["PRECENT_DEC"].ToString().Trim() + "%";//比例
            m_objViewer.ctlDataGrid6[row, o_Discount] = dr["PRECENT_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid6[row, o_EnglishName] = dr["ITEMENGNAME_VCHR"].ToString().Trim();

            this.m_objViewer.ctlDataGrid6[row, o_Deptmed] = "";
            this.m_objViewer.ctlDataGrid6[row, o_DeptmedID] = "";
            if (dr["DEPTPREP_INT"].ToString() != "1")
            {
                this.m_objViewer.ctlDataGrid6[row, o_DeptmedID] = "*";  //不允许科室自备                   
            }

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(row, o_Count);
        }
        #endregion

        #region 查找中药处方项目
        /// <summary>
        /// 根据查询内容查找药品
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindCMedicineByID(string ID, int row)
        {
            DataTable dt = null;
            long strRet = objSvc.m_lngFindChargeItem(ID, 2, out dt);
            if (strRet > 0 && dt.Rows.Count > 0)
            {

                if (dt.Rows.Count == 1)
                {
                    //if (dt.Rows[0]["NOQTYFLAG_INT"].ToString().Trim() != "0")
                    //{
                    //    if (MessageBox.Show("缺药!是否继续?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    //    {
                    //        return;
                    //    }
                    //}

                    if (Medpurview == 1)
                    {
                        if (dt.Rows[0]["ISCHLORPROMAZINE_CHR"].ToString().ToUpper() == "T" || dt.Rows[0]["ISCHLORPROMAZINE2_CHR"].ToString().ToUpper() == "T")
                        {
                            if (Neurpur != "1")
                            {
                                MessageBox.Show(Neurpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }

                        if (dt.Rows[0]["ISANAESTHESIA_CHR"].ToString().ToUpper() == "T" || dt.Rows[0]["ispoison_chr"].ToString().ToUpper() == "T")
                        {
                            if (Drugpur != "1")
                            {
                                MessageBox.Show(Drugpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    else if (Medpurview == 2)
                    {
                        if (dt.Rows[0]["ISCHLORPROMAZINE_CHR"].ToString().ToUpper() == "T" || dt.Rows[0]["ISCHLORPROMAZINE2_CHR"].ToString().ToUpper() == "T")
                        {
                            if (Neurpur != "1")
                            {
                                MessageBox.Show(Neurpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }

                        if (dt.Rows[0]["ISANAESTHESIA_CHR"].ToString().ToUpper() == "T" || dt.Rows[0]["ispoison_chr"].ToString().ToUpper() == "T")
                        {
                            if (Drugpur != "1")
                            {
                                MessageBox.Show(Drugpurhintinfo, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return;
                            }
                        }
                    }

                    m_mthFillDataGridByRow2(dt.Rows[0], row);
                    //直接填充datagrid
                }
                else
                {
                    m_objViewer.listView1.Items.Clear();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (Medpurview == 2)
                        {
                            if (dt.Rows[i]["ISCHLORPROMAZINE_CHR"].ToString().ToUpper() == "T" || dt.Rows[i]["ISCHLORPROMAZINE2_CHR"].ToString().ToUpper() == "T")
                            {
                                if (Neurpur != "1")
                                {
                                    continue;
                                }
                            }

                            if (dt.Rows[i]["ISANAESTHESIA_CHR"].ToString().ToUpper() == "T" || dt.Rows[i]["ispoison_chr"].ToString().ToUpper() == "T")
                            {
                                if (Drugpur != "1")
                                {
                                    continue;
                                }
                            }
                        }

                        ListViewItem lv = new ListViewItem(dt.Rows[i]["TYPE"].ToString().Trim());//查询码
                        lv.SubItems.Add(dt.Rows[i]["ITEMNAME_VCHR"].ToString().Trim());//名称
                        lv.SubItems.Add(dt.Rows[i]["ITEMCOMMNAME_VCHR"].ToString().Trim());//通用名称
                        lv.SubItems.Add(dt.Rows[i]["ITEMENGNAME_VCHR"].ToString().Trim());// 英文名
                        lv.SubItems.Add(this.m_mthConvertToChType(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString()));// 发票分类名称
                        lv.SubItems.Add(dt.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim());//规格
                        lv.SubItems.Add(dt.Rows[i]["NMLDOSAGE_DEC"].ToString().Trim());//常用量
                        lv.SubItems.Add(dt.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim());//单位
                        lv.SubItems.Add(dt.Rows[i]["SubMoney"].ToString().Trim());//单价
                        lv.SubItems.Add(dt.Rows[i]["PRECENT_DEC"].ToString().Trim());//比例
                        lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());//医保分类
                        lv.SubItems.Add("");
                        //if (dt.Rows[i]["NOQTYFLAG_INT"].ToString().Trim() == "0")
                        //{
                        //    lv.SubItems.Add("");//是否缺药
                        //}
                        //else
                        //{
                        //    if (!isShowLackMedicine)
                        //    {
                        //        continue;
                        //    }
                        //    else
                        //    {
                        //        lv.SubItems.Add("缺药");
                        //        lv.ForeColor = Color.Red;
                        //    }
                        //}

                        lv.Tag = dt.Rows[i];
                        m_objViewer.listView1.Items.Add(lv);
                    }
                    m_objViewer.listView1.Height = 175;
                    m_objViewer.listView1.Visible = true;
                    m_objViewer.listView1.Items[0].Selected = true;
                    m_objViewer.listView1.Select();
                    m_objViewer.listView1.Focus();
                    //填充listView
                }
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid2.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
        }
        #endregion

        #region 检验类型
        /// <summary>
        /// 检验类型
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public long m_lngGetLisSampletyType(string ID, int row)
        {
            DataTable dt = null;
            long strRet = objSvc.m_lngGetLisSampletyType(ID, "PYCODE_CHR", out dt);
            if (strRet > 0 && dt.Rows.Count > 0)
            {

                if (dt.Rows.Count == 1)
                {
                    m_objViewer.ctlDataGridLis[row, t_PartName] = dt.Rows[0]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGridLis[row, t_Temp] = dt.Rows[0]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(row + 1, 0);

                    return 0;
                }
                else
                {
                    this.m_objViewer.ctlDataGridLis.Controls.Add(m_objViewer.listView5);
                    m_objViewer.listView5.Items.Clear();
                    m_objViewer.listView5.Columns[2].Text = "拼音码";
                    this.objDataGrid = this.m_objViewer.ctlDataGridLis;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem lv = new ListViewItem(dt.Rows[i]["SAMPLE_TYPE_ID_CHR"].ToString().Trim());//ID
                        lv.SubItems.Add(dt.Rows[i]["PYCODE_CHR"].ToString().Trim());//助记码
                        lv.SubItems.Add(dt.Rows[i]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim());//名称
                        m_objViewer.listView5.Items.Add(lv);
                    }

                }
                return 1;
            }
            else
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGridLis.Columns[t_PartName]).DataGridTextBoxColumn.TextBox.SelectAll();

                return -1;

            }
        }
        #endregion

        #region 查找检查部位
        /// <summary>
        /// 查找检查部位
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        public long m_mthLoadCheckPart(string ID, int row)
        {
            long strRet = 0;
            DataTable dt = null;
            com.digitalwave.controls.datagrid.ctlDataGrid dg = new com.digitalwave.controls.datagrid.ctlDataGrid();

            dg = m_objViewer.ctlDataGridTest;
            string applyid = this.m_objViewer.ctlDataGridTest[row, t_PriceFlag].ToString();
            strRet = objSvc.m_mthLoadCheckPartOrder(applyid, ID, out dt);

            if (strRet > 0 && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 1)
                {
                    dg[row, t_PartName] = dt.Rows[0]["PARTNAME"].ToString().Trim();
                    dg[row, t_Temp] = dt.Rows[0]["PARTID"].ToString().Trim();
                    dg.CurrentCell = new DataGridCell(row + 1, 0);
                    dg[row, t_PartName] = dt.Rows[0]["PARTNAME"].ToString().Trim();
                    //直接填充datagrid
                    return 0;
                }
                else
                {
                    dg.Controls.Add(m_objViewer.listView5);
                    m_objViewer.listView5.Items.Clear();
                    m_objViewer.listView5.Columns[2].Text = "助记码";
                    this.objDataGrid = dg;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        ListViewItem lv = new ListViewItem(dt.Rows[i]["PARTID"].ToString().Trim());//ID
                        lv.SubItems.Add(dt.Rows[i]["ASSISTCODE_CHR"].ToString().Trim());//助记码
                        lv.SubItems.Add(dt.Rows[i]["PARTNAME"].ToString().Trim());//名称
                        m_objViewer.listView5.Items.Add(lv);
                    }

                    //填充listView

                }
                return 1;
            }
            else
            {
                ((com.digitalwave.controls.datagrid.clsColumnInfo)dg.Columns[t_PartName]).DataGridTextBoxColumn.TextBox.SelectAll();
                return -1;
            }
        }
        #endregion

        #region listView5的事件处理
        private void listView5_Leave(object sender, EventArgs e)
        {
            this.m_objViewer.listView5.Hide();
        }
        private com.digitalwave.controls.datagrid.ctlDataGrid objDataGrid;
        private void listView5_DoubleClick(object sender, EventArgs e)
        {
            int rorTemp = objDataGrid.CurrentCell.RowNumber;
            if (this.m_objViewer.listView5.SelectedItems.Count == 0)
            {
                objDataGrid.CurrentCell = new DataGridCell(rorTemp, t_PartName);
                return;
            }

            objDataGrid[rorTemp, t_PartName] = this.m_objViewer.listView5.SelectedItems[0].SubItems[2].Text;
            objDataGrid[rorTemp, t_Temp] = this.m_objViewer.listView5.SelectedItems[0].Text;
            objDataGrid.CurrentCell = new DataGridCell(rorTemp + 1, 0);
        }

        private void listView5_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.listView5_DoubleClick(null, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.m_objViewer.listView5.Hide();
                this.objDataGrid.CurrentCell = new DataGridCell(objDataGrid.CurrentCell.RowNumber, t_PartName);
            }
        }
        #endregion

        #region 查找诊疗检验项目
        /// <summary>
        /// 查找诊疗检验项目
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindOrderLisByID(string ID, int row)
        {
            DataTable dt = null;

            long l = objSvc.m_lngFindRecipeOrderByID(ID, OrderCatLisArr, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                m_objViewer.listView1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lv = new ListViewItem(dt.Rows[i]["usercode_chr"].ToString().Trim()); //用户编码
                    lv.SubItems.Add(dt.Rows[i]["NAME_CHR"].ToString().Trim());//名称
                    lv.SubItems.Add(dt.Rows[i]["COMMNAME_VCHR"].ToString().Trim());//通用名称
                    lv.SubItems.Add(dt.Rows[i]["ENGNAME_VCHR"].ToString().Trim());// 英文名
                    lv.SubItems.Add(this.m_mthConvertToChType(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString()));// 发票分类名称 
                    lv.SubItems.Add(dt.Rows[i]["itemspec_vchr"].ToString().Trim());//规格
                    lv.SubItems.Add("1");//常用量
                    lv.SubItems.Add(dt.Rows[i]["itemunit"].ToString().Trim());//单位
                    lv.SubItems.Add(dt.Rows[i]["totalmny"].ToString().Trim());//单价
                    lv.SubItems.Add("");//比例
                    lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());//医保分类
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                m_objViewer.listView1.Items[0].Selected = true;
                m_objViewer.listView1.Select();
                m_objViewer.listView1.Focus();
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGridLis.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
        }
        #endregion

        #region 获取分隔字符串数值
        /// <summary>
        /// 获取分隔字符串数值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public ArrayList m_Gettoken(string str, string sign)
        {
            ArrayList val = null;
            if (str == null)
                return val;
            if (str.Trim() == "")
            {
                return val;
            }

            int pos = 0;
            val = new ArrayList();

            do
            {
                pos = str.IndexOf(sign);
                if (pos > 0)
                {
                    val.Add(str.Substring(0, pos));
                    str = str.Substring(pos + 1);
                }
                else
                {
                    val.Add(str);
                }
            } while (pos > 0);

            return val;
        }
        #endregion

        #region 查找诊疗检查项目
        /// <summary>
        /// 查找诊疗检查项目
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindExamineChargeByOrderID(string ID, int row)
        {
            DataTable dt = null;

            long l = objSvc.m_lngFindRecipeOrderByID(ID, OrderCatTestArr, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                m_objViewer.listView1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lv = new ListViewItem(dt.Rows[i]["usercode_chr"].ToString().Trim()); //项目ID
                    lv.SubItems.Add(dt.Rows[i]["NAME_CHR"].ToString().Trim());//名称
                    lv.SubItems.Add(dt.Rows[i]["COMMNAME_VCHR"].ToString().Trim());//通用名称
                    lv.SubItems.Add(dt.Rows[i]["ENGNAME_VCHR"].ToString().Trim());// 英文名
                    lv.SubItems.Add(this.m_mthConvertToChType(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString()));// 发票分类名称 
                    lv.SubItems.Add(dt.Rows[i]["itemspec_vchr"].ToString().Trim());//规格
                    lv.SubItems.Add("1");//常用量
                    lv.SubItems.Add(dt.Rows[i]["itemunit"].ToString().Trim());//单位
                    lv.SubItems.Add(dt.Rows[i]["totalmny"].ToString().Trim());//单价
                    lv.SubItems.Add("");//比例
                    lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());//医保分类
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                m_objViewer.listView1.Items[0].Selected = true;
                m_objViewer.listView1.Select();
                m_objViewer.listView1.Focus();
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGridTest.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
        }
        #endregion

        #region 查找诊疗手术项目
        /// <summary>
        /// 查找诊疗手术项目
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindOPSChargeByOrderID(string ID, int row)
        {
            DataTable dt = null;

            long l = objSvc.m_lngFindRecipeOrderByID(ID, OrderCatOpsArr, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                m_objViewer.listView1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lv = new ListViewItem(dt.Rows[i]["usercode_chr"].ToString().Trim());//项目ID
                    lv.SubItems.Add(dt.Rows[i]["NAME_CHR"].ToString().Trim());//名称
                    lv.SubItems.Add(dt.Rows[i]["COMMNAME_VCHR"].ToString().Trim());//通用名称
                    lv.SubItems.Add(dt.Rows[i]["ENGNAME_VCHR"].ToString().Trim());// 英文名
                    lv.SubItems.Add(this.m_mthConvertToChType(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString()));// 发票分类名称 
                    lv.SubItems.Add(dt.Rows[i]["itemspec_vchr"].ToString().Trim());//规格
                    lv.SubItems.Add("1");//常用量
                    lv.SubItems.Add(dt.Rows[i]["itemunit"].ToString().Trim());//单位
                    lv.SubItems.Add(dt.Rows[i]["totalmny"].ToString().Trim());//单价
                    lv.SubItems.Add("");//比例
                    lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());//医保分类
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                m_objViewer.listView1.Items[0].Selected = true;
                m_objViewer.listView1.Select();
                m_objViewer.listView1.Focus();
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGridOps.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
        }
        #endregion

        #region 查找其他项目
        /// <summary>
        /// 查找检验项目
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindOtherChargeByID(string ID, int row)
        {
            DataTable dt = null;
            long strRet = objSvc.m_lngFindChargeItem(ID, 6, out dt);
            if (strRet > 0 && dt.Rows.Count > 0)
            {
                m_objViewer.listView1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ListViewItem lv = new ListViewItem(dt.Rows[i]["TYPE"].ToString().Trim());//项目ID                    
                    lv.SubItems.Add(dt.Rows[i]["ITEMNAME_VCHR"].ToString().Trim());//名称
                    lv.SubItems.Add(dt.Rows[i]["ITEMCOMMNAME_VCHR"].ToString().Trim());//通用名称
                    lv.SubItems.Add(dt.Rows[i]["ITEMENGNAME_VCHR"].ToString().Trim());// 英文名
                    lv.SubItems.Add(this.m_mthConvertToChType(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString()));// 发票分类名称
                    lv.SubItems.Add(dt.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim());//规格
                    lv.SubItems.Add("");//常用量
                    lv.SubItems.Add(dt.Rows[i]["ITEMOPUNIT_CHR"].ToString().Trim());//单位
                    lv.SubItems.Add(dt.Rows[i]["ITEMPRICE_MNY"].ToString().Trim());//单价
                    lv.SubItems.Add(dt.Rows[i]["PRECENT_DEC"].ToString().Trim());//比例
                    lv.SubItems.Add(dt.Rows[i]["ybtypename"].ToString().Trim());//医保分类
                    lv.SubItems.Add(dt.Rows[i]["SELFDEFINE_INT"].ToString().Trim());//是否自定义价格
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                m_objViewer.listView1.Items[0].Selected = true;
                m_objViewer.listView1.Select();
                m_objViewer.listView1.Focus();

            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid6.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
        }
        #endregion

        #region 新建
        /// <summary>
        /// 新建
        /// </summary>
        public void m_mthNew()
        {
            this.m_objViewer.txtRecName.Text = "";
            this.m_objViewer.txtUserCode.Text = "";
            this.m_objViewer.txtPyCode.Text = "";
            this.m_objViewer.txtWbCode.Text = "";
            this.m_objViewer.txtReMark.Text = "";
            this.m_objViewer.cboUseScope.SelectedIndex = 0;
            this.m_objViewer.cboStatus.SelectedIndex = 0;

            this.m_mthDeleteAllRows();
            this.m_objViewer.tabControl1.SelectedIndex = 0;

            this.m_objViewer.btnSave.Tag = "";

            this.m_objViewer.txtRecName.Focus();
        }

        /// <summary>
        /// 清空所有行
        /// </summary>
        private void m_mthDeleteAllRows()
        {
            this.m_objViewer.ctlDataGrid1.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid2.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid6.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridLis.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridTest.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridOps.m_mthDeleteAllRow();
        }
        #endregion

        #region 删除无效明细行
        /// <summary>
        /// 删除无效明细行
        /// </summary>
        public void m_mthDeleteInvalidRow()
        {
            for (int i = this.m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
            {
                if (this.m_objViewer.ctlDataGrid1[i, c_ItemID] == null || this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString() == "")
                {
                    this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                }
            }

            for (int i = this.m_objViewer.ctlDataGrid2.RowCount - 1; i >= 0; i--)
            {
                if (this.m_objViewer.ctlDataGrid2[i, 8] == null || this.m_objViewer.ctlDataGrid2[i, 8].ToString() == "")
                {
                    this.m_objViewer.ctlDataGrid2.m_mthDeleteRow(i);
                }
            }

            for (int i = this.m_objViewer.ctlDataGrid6.RowCount - 1; i >= 0; i--)
            {
                if (this.m_objViewer.ctlDataGrid6[i, 7] == null || this.m_objViewer.ctlDataGrid6[i, 7].ToString() == "")
                {
                    this.m_objViewer.ctlDataGrid6.m_mthDeleteRow(i);
                }
            }

            for (int i = this.m_objViewer.ctlDataGridLis.RowCount - 1; i >= 0; i--)
            {
                if (this.m_objViewer.ctlDataGridLis[i, t_ItemID] == null || this.m_objViewer.ctlDataGridLis[i, t_ItemID].ToString() == "")
                {
                    this.m_objViewer.ctlDataGridLis.m_mthDeleteRow(i);
                }
            }

            for (int i = this.m_objViewer.ctlDataGridTest.RowCount - 1; i >= 0; i--)
            {
                if (this.m_objViewer.ctlDataGridTest[i, t_ItemID] == null || this.m_objViewer.ctlDataGridTest[i, t_ItemID].ToString() == "")
                {
                    this.m_objViewer.ctlDataGridTest.m_mthDeleteRow(i);
                }
            }

            for (int i = this.m_objViewer.ctlDataGridOps.RowCount - 1; i >= 0; i--)
            {
                if (this.m_objViewer.ctlDataGridOps[i, o_ItemID] == null || this.m_objViewer.ctlDataGridOps[i, o_ItemID].ToString() == "")
                {
                    this.m_objViewer.ctlDataGridOps.m_mthDeleteRow(i);
                }
            }
        }
        #endregion

        #region 保存
        /// <summary>
        /// 保存
        /// </summary>
        public void m_mthSave()
        {
            #region 有效性检验
            if (this.m_objViewer.txtRecName.Text.Trim() == "")
            {
                MessageBox.Show("请输入协定处方名称。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.m_mthDeleteInvalidRow();

            ArrayList objRecEntryArr = new ArrayList();

            //西药
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, c_Count].ToString().Trim() == "" || this.m_objViewer.ctlDataGrid1[i, c_Count].ToString().Trim() == "0")
                {
                    MessageBox.Show("西药栏第" + Convert.ToString(i + 1) + "行的剂量输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (this.m_objViewer.ctlDataGrid1[i, c_UsageName].ToString().Trim() == "")
                {
                    MessageBox.Show("西药栏第" + Convert.ToString(i + 1) + "行的用法输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (this.m_objViewer.ctlDataGrid1[i, c_FreName].ToString().Trim() == "")
                {
                    MessageBox.Show("西药栏第" + Convert.ToString(i + 1) + "行的频率输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (this.m_objViewer.ctlDataGrid1[i, c_Day].ToString().Trim() == "")
                {
                    MessageBox.Show("西药栏第" + Convert.ToString(i + 1) + "行的天数输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                clsAccordRecipePlus_VO AccordRecipePlus_VO = new clsAccordRecipePlus_VO();
                AccordRecipePlus_VO.ItemID = this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString();
                AccordRecipePlus_VO.RecNO = this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString();
                AccordRecipePlus_VO.Qty = this.m_objViewer.ctlDataGrid1[i, c_Count].ToString();
                AccordRecipePlus_VO.UsageID = this.m_objViewer.ctlDataGrid1[i, c_UsageID].ToString();
                AccordRecipePlus_VO.FreqID = this.m_objViewer.ctlDataGrid1[i, c_FreID].ToString();
                AccordRecipePlus_VO.Days = this.m_objViewer.ctlDataGrid1[i, c_Day].ToString();
                AccordRecipePlus_VO.Type = "0";
                AccordRecipePlus_VO.Class = "1";
                AccordRecipePlus_VO.RowNO = Convert.ToString(i + 1);

                objRecEntryArr.Add(AccordRecipePlus_VO);
            }

            //中药
            for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid2[i, 1].ToString().Trim() == "" || this.m_objViewer.ctlDataGrid2[i, 1].ToString().Trim() == "0")
                {
                    MessageBox.Show("中药栏第" + Convert.ToString(i + 1) + "行的数量输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (this.m_objViewer.ctlDataGrid2[i, 21].ToString().Trim() == "")
                {
                    MessageBox.Show("中药栏第" + Convert.ToString(i + 1) + "行的用法输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                clsAccordRecipePlus_VO AccordRecipePlus_VO = new clsAccordRecipePlus_VO();
                AccordRecipePlus_VO.ItemID = this.m_objViewer.ctlDataGrid2[i, 8].ToString();
                AccordRecipePlus_VO.Qty = this.m_objViewer.ctlDataGrid2[i, 1].ToString();
                AccordRecipePlus_VO.UsageID = this.m_objViewer.ctlDataGrid2[i, 21].ToString();
                AccordRecipePlus_VO.Type = "0";
                AccordRecipePlus_VO.Class = "2";
                AccordRecipePlus_VO.RowNO = Convert.ToString(i + 1);

                objRecEntryArr.Add(AccordRecipePlus_VO);
            }

            //检验
            for (int i = 0; i < this.m_objViewer.ctlDataGridLis.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGridLis[i, t_Count].ToString().Trim() == "" || this.m_objViewer.ctlDataGridLis[i, t_Count].ToString().Trim() == "0")
                {
                    MessageBox.Show("检验栏第" + Convert.ToString(i + 1) + "行的数量输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (this.m_objViewer.ctlDataGridLis[i, t_PartName].ToString().Trim() == "")
                {
                    MessageBox.Show("检验栏第" + Convert.ToString(i + 1) + "行的样本输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                clsAccordRecipePlus_VO AccordRecipePlus_VO = new clsAccordRecipePlus_VO();
                AccordRecipePlus_VO.ItemID = this.m_objViewer.ctlDataGridLis[i, t_ItemID].ToString();
                AccordRecipePlus_VO.Qty = this.m_objViewer.ctlDataGridLis[i, t_Count].ToString();
                AccordRecipePlus_VO.SampleID = this.m_objViewer.ctlDataGridLis[i, t_Temp].ToString();
                AccordRecipePlus_VO.Type = "1";
                AccordRecipePlus_VO.Class = "3";
                AccordRecipePlus_VO.RowNO = Convert.ToString(i + 1);

                objRecEntryArr.Add(AccordRecipePlus_VO);
            }

            //检查
            for (int i = 0; i < this.m_objViewer.ctlDataGridTest.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGridTest[i, t_Count].ToString().Trim() == "" || this.m_objViewer.ctlDataGridTest[i, t_Count].ToString().Trim() == "0")
                {
                    MessageBox.Show("检查栏第" + Convert.ToString(i + 1) + "行的数量输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                if (this.m_objViewer.ctlDataGridTest[i, t_PartName].ToString().Trim() == "")
                {
                    MessageBox.Show("检查栏第" + Convert.ToString(i + 1) + "行的部位输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                clsAccordRecipePlus_VO AccordRecipePlus_VO = new clsAccordRecipePlus_VO();
                AccordRecipePlus_VO.ItemID = this.m_objViewer.ctlDataGridTest[i, t_ItemID].ToString();
                AccordRecipePlus_VO.Qty = this.m_objViewer.ctlDataGridTest[i, t_Count].ToString();
                AccordRecipePlus_VO.PartID = this.m_objViewer.ctlDataGridTest[i, t_Temp].ToString();
                AccordRecipePlus_VO.Type = "1";
                AccordRecipePlus_VO.Class = "4";
                AccordRecipePlus_VO.RowNO = Convert.ToString(i + 1);

                objRecEntryArr.Add(AccordRecipePlus_VO);
            }

            //治疗(手术)
            for (int i = 0; i < this.m_objViewer.ctlDataGridOps.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGridOps[i, o_Count].ToString().Trim() == "" || this.m_objViewer.ctlDataGridOps[i, o_Count].ToString().Trim() == "0")
                {
                    MessageBox.Show("治疗(手术)栏第" + Convert.ToString(i + 1) + "行的数量输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                clsAccordRecipePlus_VO AccordRecipePlus_VO = new clsAccordRecipePlus_VO();
                AccordRecipePlus_VO.ItemID = this.m_objViewer.ctlDataGridOps[i, o_ItemID].ToString();
                AccordRecipePlus_VO.Qty = this.m_objViewer.ctlDataGridOps[i, o_Count].ToString();
                AccordRecipePlus_VO.Type = "1";
                AccordRecipePlus_VO.Class = "5";
                AccordRecipePlus_VO.RowNO = Convert.ToString(i + 1);

                objRecEntryArr.Add(AccordRecipePlus_VO);
            }

            //其他
            for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid6[i, o_Count].ToString().Trim() == "" || this.m_objViewer.ctlDataGrid6[i, o_Count].ToString().Trim() == "0")
                {
                    MessageBox.Show("其他栏第" + Convert.ToString(i + 1) + "行的数量输入不正确，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                clsAccordRecipePlus_VO AccordRecipePlus_VO = new clsAccordRecipePlus_VO();
                AccordRecipePlus_VO.ItemID = this.m_objViewer.ctlDataGrid6[i, o_ItemID].ToString();
                AccordRecipePlus_VO.Qty = this.m_objViewer.ctlDataGrid6[i, o_Count].ToString();
                AccordRecipePlus_VO.Type = "0";
                AccordRecipePlus_VO.Class = "6";
                AccordRecipePlus_VO.RowNO = Convert.ToString(i + 1);

                objRecEntryArr.Add(AccordRecipePlus_VO);
            }
            #endregion

            if (objRecEntryArr.Count == 0)
            {
                MessageBox.Show("请输入处方明细项目。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string PrivilegeFlag = "";
            if (this.m_objViewer.cboUseScope.SelectedIndex == 0)
            {
                PrivilegeFlag = "1";
            }
            else if (this.m_objViewer.cboUseScope.SelectedIndex == 1)
            {
                PrivilegeFlag = "2";
            }
            else if (this.m_objViewer.cboUseScope.SelectedIndex == 2)
            {
                PrivilegeFlag = "0";
            }

            string RecipeID = this.m_objViewer.btnSave.Tag.ToString();
            string RecipeID_Tmp = RecipeID;
            clsAccordRecipe_VO AccordRecipe_VO = new clsAccordRecipe_VO();
            AccordRecipe_VO.RecipeID = RecipeID;
            AccordRecipe_VO.RecipeName = this.m_objViewer.txtRecName.Text.Trim();
            AccordRecipe_VO.Privilege = PrivilegeFlag;
            AccordRecipe_VO.UserCode = this.m_objViewer.txtUserCode.Text.Trim();
            AccordRecipe_VO.PyCode = this.m_objViewer.txtPyCode.Text.Trim();
            AccordRecipe_VO.WbCode = this.m_objViewer.txtWbCode.Text.Trim();
            if (this.m_objViewer.cboStatus.SelectedIndex == 0)
            {
                AccordRecipe_VO.Status = "1";
            }
            else
            {
                AccordRecipe_VO.Status = "0";
            }
            AccordRecipe_VO.DiseaseName = this.m_objViewer.txtReMark.Text.Trim();
            AccordRecipe_VO.CreaterID = this.m_objViewer.LoginInfo.m_strEmpID;
            AccordRecipe_VO.Flag = "0";
            AccordRecipe_VO.DeptID = this.m_objViewer.LoginInfo.m_strDepartmentID;

            this.m_objViewer.Cursor = Cursors.WaitCursor;
            long l = this.objSvc.m_lngSaveAccordRecipe(AccordRecipe_VO, objRecEntryArr, out RecipeID);
            this.m_objViewer.Cursor = Cursors.Default;
            if (l > 0)
            {
                this.m_objViewer.btnSave.Tag = RecipeID;

                if (RecipeID_Tmp.Trim() == "")
                {
                    this.m_mthCreateTree(this.m_objViewer.LoginInfo.m_strEmpID);
                    this.m_mthFindChild(RecipeID);
                }
                else
                {
                    AccordRecipeEdit obj = new AccordRecipeEdit();                                    
                    obj.RecipeID_Chr = AccordRecipe_VO.RecipeID;
                    obj.Recipename_Chr = AccordRecipe_VO.RecipeName;
                    obj.UserCode_Chr = AccordRecipe_VO.UserCode;
                    obj.PyCode_Chr = AccordRecipe_VO.PyCode;
                    obj.WbCode_Chr = AccordRecipe_VO.WbCode;
                    obj.Privilege_Int = AccordRecipe_VO.Privilege;
                    obj.Status_Int = AccordRecipe_VO.Status;
                    obj.ReMark_Vchr = AccordRecipe_VO.DiseaseName;
                    obj.OrigeName = AccordRecipe_VO.RecipeName;
                    this.m_objViewer.CurrTn.Tag = obj;                    
                }

                #region 提示
                frmFlash flash = new frmFlash();
                flash.Information = "保存协定处方数据成功！";
                Point p = this.m_objViewer.btnSave.Parent.Parent.PointToScreen(this.m_objViewer.btnSave.Location);
                p.Offset(-50, -(flash.Height - this.m_objViewer.btnSave.Height));
                flash.Location = p;
                flash.Show();
                #endregion
                
            }
            else
            {
                MessageBox.Show("保存协定处方数据失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除
        /// </summary>
        public void m_mthDel(string RecipeID)
        {
            if (RecipeID.Trim() == "")
            {
                return;
            }

            if (MessageBox.Show("删除资料前请再次确认，是否删除？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            long l = this.objSvc.m_lngDelAccordRecipe(RecipeID);
            if (l > 0)
            {
                this.m_mthCreateTree(this.m_objViewer.LoginInfo.m_strEmpID);
                this.m_mthNew();
            }
            else
            {
                MessageBox.Show("删除协定处方失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region 显示
        /// <summary>
        /// 显示
        /// </summary>
        public void m_mthShow(string RecipeID)
        {
            if (RecipeID.Trim() == "")
            {
                return;
            }

            this.m_objViewer.btnSave.Tag = RecipeID;
            this.m_mthDeleteAllRows();
          
            int row = 0;
            int tabindex = 0;
            long l = 0;
            DataTable dt;
            DataRow dr;

            #region 其他
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 6, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGrid6.RowCount;
                    this.m_objViewer.ctlDataGrid6.m_mthAppendRow();

                    dr = dt.Rows[i];
                    m_objViewer.ctlDataGrid6[row, o_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_Name] = dr["ITEMNAME_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_Spec] = dr["ITEMSPEC_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_Unit] = dr["ITEMOPUNIT_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_Price] = dr["ITEMPRICE_MNY"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_ItemID] = dr["ITEMID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_PriceFlag] = dr["SELFDEFINE_INT"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_DiscountName] = dr["PRECENT_DEC"].ToString().Trim() + "%";//比例
                    m_objViewer.ctlDataGrid6[row, o_Discount] = dr["PRECENT_DEC"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_EnglishName] = dr["ITEMENGNAME_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid6[row, o_Count] = dr["recqty"].ToString().Trim();

                    m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(row, o_Count);
                    tabindex = 5;
                }
            }
            #endregion

            #region 治疗
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 5, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGridOps.RowCount;
                    this.m_objViewer.ctlDataGridOps.m_mthAppendRow();

                    dr = dt.Rows[i];
                    m_objViewer.ctlDataGridOps[row, o_Find] = dr["USERCODE_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridOps[row, o_Name] = dr["NAME_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridOps[row, o_Spec] = dr["itemspec_vchr"].ToString().Trim();
                    m_objViewer.ctlDataGridOps[row, o_Unit] = dr["itemunit"].ToString().Trim();
                    m_objViewer.ctlDataGridOps[row, o_Price] = "";
                    m_objViewer.ctlDataGridOps[row, o_ItemID] = dr["ORDERDICID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridOps[row, o_PriceFlag] = dr["APPLYTYPEID_CHR"].ToString().Trim();  //用自定义价格列存申请单类型
                    m_objViewer.ctlDataGridOps[row, o_DiscountName] = "";//比例
                    m_objViewer.ctlDataGridOps[row, o_Discount] = "";
                    m_objViewer.ctlDataGridOps[row, o_InvoiceType] = this.m_mthConvertToChType(dr["ITEMOPINVTYPE_CHR"].ToString());
                    m_objViewer.ctlDataGridOps[row, o_EnglishName] = dr["ENGNAME_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGridOps[row, o_Count] = dr["recqty"].ToString().Trim();
                    m_objViewer.ctlDataGridOps[row, o_UsageID] = dr["usageid_chr"].ToString().Trim();

                    m_objViewer.ctlDataGridOps.CurrentCell = new DataGridCell(row, o_Count);
                    tabindex = 4;
                }
            }
            #endregion

            #region 检查
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 4, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGridTest.RowCount;
                    this.m_objViewer.ctlDataGridTest.m_mthAppendRow();

                    dr = dt.Rows[i];
                    m_objViewer.ctlDataGridTest[row, t_Find] = dr["USERCODE_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_Name] = dr["NAME_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_Spec] = dr["itemspec_vchr"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_PartName] = dr["partname"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_Unit] = dr["itemunit"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_Price] = "";
                    m_objViewer.ctlDataGridTest[row, t_ItemID] = dr["ORDERDICID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_PriceFlag] = dr["APPLYTYPEID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_DiscountName] = "";//比例
                    m_objViewer.ctlDataGridTest[row, t_Discount] = "";
                    m_objViewer.ctlDataGridTest[row, t_InvoiceType] = this.m_mthConvertToChType(dr["ITEMOPINVTYPE_CHR"].ToString());
                    m_objViewer.ctlDataGridTest[row, t_EnglishName] = dr["ENGNAME_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_Temp] = dr["partid_vchr"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_Count] = dr["recqty"].ToString().Trim();
                    m_objViewer.ctlDataGridTest[row, t_UsageID] = dr["usageid_chr"].ToString().Trim();

                    m_objViewer.ctlDataGridTest.CurrentCell = new DataGridCell(row, t_Count);
                    tabindex = 3;
                }
            }
            #endregion

            #region 检验
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 3, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGridLis.RowCount;
                    this.m_objViewer.ctlDataGridLis.m_mthAppendRow();

                    dr = dt.Rows[i];
                    m_objViewer.ctlDataGridLis[row, t_Find] = dr["USERCODE_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridLis[row, t_Name] = dr["NAME_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridLis[row, t_Spec] = dr["itemspec_vchr"].ToString().Trim();//规格
                    m_objViewer.ctlDataGridLis[row, t_PartName] = dr["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGridLis[row, t_Unit] = dr["itemunit"].ToString().Trim();
                    m_objViewer.ctlDataGridLis[row, t_ItemID] = dr["ORDERDICID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridLis[row, t_PriceFlag] = dr["LISAPPLYUNITID_CHR"].ToString().Trim(); //用自定价格列记录申请单元ID        
                    m_objViewer.ctlDataGridLis[row, t_InvoiceType] = this.m_mthConvertToChType(dr["ITEMOPINVTYPE_CHR"].ToString());
                    m_objViewer.ctlDataGridLis[row, t_EnglishName] = dr["ENGNAME_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGridLis[row, t_Temp] = dr["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGridLis[row, t_Count] = dr["recqty"].ToString().Trim();

                    m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(row, t_Count);
                    tabindex = 2;
                }
            }
            #endregion

            #region 中药
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 2, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGrid2.RowCount;
                    this.m_objViewer.ctlDataGrid2.m_mthAppendRow();

                    dr = dt.Rows[i];
                    m_objViewer.ctlDataGrid2[row, 0] = dr["ITEMCODE_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 1] = dr["recqty"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 11] = dr["ADULTDOSAGE_DEC"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 2] = dr["DOSAGEUNIT_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 3] = dr["ITEMNAME_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 4] = dr["ITEMSPEC_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 5] = dr["usagename_vchr"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 6] = dr["SubMoney"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 8] = dr["ITEMID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 10] = dr["PRECENT_DEC"].ToString().Trim() + "%";//比例
                    m_objViewer.ctlDataGrid2[row, 11] = dr["PRECENT_DEC"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 13] = dr["MAXDOSAGE_DEC"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 14] = dr["MINDOSAGE_DEC"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 16] = dr["ITEMPRICE_MNY"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 17] = dr["opchargeflg_int"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 18] = dr["PACKQTY_DEC"].ToString().Trim();
                    m_objViewer.ctlDataGrid2[row, 19] = 0;
                    m_objViewer.ctlDataGrid2[row, 20] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();//发票分类
                    m_objViewer.ctlDataGrid2[row, 21] = dr["USAGEID_CHR"].ToString().Trim();    //用法ID
                    m_objViewer.ctlDataGrid2[row, 24] = dr["ITEMENGNAME_VCHR"].ToString().Trim();//英文名

                    try
                    {
                        m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(row, 1);
                        m_objViewer.ctlDataGrid2[row, 0] = dr["ITEMCODE_VCHR"].ToString().Trim();
                    }
                    catch
                    {
                    }
                    tabindex = 1;
                }
            }
            #endregion

            #region 西药
            l = this.objSvc.m_lngGetAccordRecipe(RecipeID, 1, out dt);
            if (l > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGrid1.RowCount;
                    this.m_objViewer.ctlDataGrid1.m_mthAppendRow();

                    dr = dt.Rows[i];
                    this.m_objViewer.ctlDataGrid1[row, c_GroupNo] = dr["recno"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Count] = dr["recqty"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Unit] = dr["DOSAGEUNIT_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Name] = dr["ITEMNAME_VCHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Spec] = dr["ITEMSPEC_VCHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Price] = dr["SubMoney"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_BigUnit] = dr["ITEMIPUNIT_CHR"].ToString().Trim();
                    if (dr["opchargeflg_int"].ToString().Trim() == "0")//判断大小单位
                    {
                        this.m_objViewer.ctlDataGrid1[row, c_Price] = dr["ITEMPRICE_MNY"].ToString().Trim();//大单价
                        this.m_objViewer.ctlDataGrid1[row, c_BigUnit] = dr["ITEMOPUNIT_CHR"].ToString().Trim();
                    }
                    this.m_objViewer.ctlDataGrid1[row, c_ItemID] = dr["ITEMID_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Packet] = dr["PACKQTY_DEC"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_DiscountName] = dr["PRECENT_DEC"].ToString().Trim() + "%";//比例
                    this.m_objViewer.ctlDataGrid1[row, c_Discount] = dr["PRECENT_DEC"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_UnitFlag] = dr["opchargeflg_int"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Dosage] = m_mthConvertObjToDecimal(dr["DOSAGE_DEC"]);
                    this.m_objViewer.ctlDataGrid1[row, c_MaxLimit] = dr["MAXDOSAGE_DEC"].ToString().Trim();//上限
                    this.m_objViewer.ctlDataGrid1[row, c_MinLimit] = dr["MINDOSAGE_DEC"].ToString().Trim();//下限
                    this.m_objViewer.ctlDataGrid1[row, c_IsCal] = 1;
                    this.m_objViewer.ctlDataGrid1[row, c_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();//发票分类
                    string tempUsageID = m_objViewer.ctlDataGrid1[row, 16].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_UsageName] = dr["USAGENAME_VCHR"].ToString().Trim();//默认用法名称
                    this.m_objViewer.ctlDataGrid1[row, c_UsageID] = dr["USAGEID_CHR"].ToString().Trim();//默认用法ID
                    this.m_objViewer.ctlDataGrid1[row, c_EnglishName] = dr["ITEMENGNAME_VCHR"].ToString().Trim();//英文名			

                    this.m_objViewer.ctlDataGrid1[row, c_FreName] = dr["freqname"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_FreDays] = m_mthConvertObjToDecimal(dr["freqdays"]);
                    this.m_objViewer.ctlDataGrid1[row, c_FreTimes] = m_mthConvertObjToDecimal(dr["freqtimes"]);
                    this.m_objViewer.ctlDataGrid1[row, c_FreID] = dr["freqid"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Day] = dr["recdays"].ToString();

                    try
                    {
                        this.m_objViewer.ctlDataGrid1[row, c_PSFlag] = dr["HYPE_INT"].ToString().Trim();//皮试标志
                        if (dr["HYPE_INT"].ToString().Trim() == "1")//如果此药要皮试则默认为皮试
                        {
                            m_objViewer.ctlDataGrid1[row, c_PS] = 1;
                            this.m_objViewer.ctlDataGrid1.m_mthFormatCell(row, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Red);
                        }
                        else
                        {
                            this.m_objViewer.ctlDataGrid1.m_mthFormatCell(row, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Black);
                        }
                    }
                    catch
                    {

                    }
                    tabindex = 0;
                }
            }
            #endregion

            this.m_objViewer.tabControl1.SelectedIndex = tabindex;
        }
        #endregion

        #region 生成协定处方
        /// <summary>
        /// 生成协定处方
        /// </summary>
        public void m_mthCreateAccordRecipe()
        {
            int row = 0;
            #region 西药
            for (int i = 0; i < this.m_objViewer.DataGrid1.RowCount; i++)
            {
                if ((this.m_objViewer.DataGrid1[i, c_SubItemID].ToString().Trim() != "" && !this.m_objViewer.DataGrid1[i, c_SubItemID].ToString().Trim().StartsWith("[PK]"))
                    || (this.m_objViewer.DataGrid1[i, c_resubitem].ToString().Trim() != "" && this.m_objViewer.DataGrid1[i, c_resubitem].ToString().Trim().StartsWith("[PK]")))
                {
                    continue;
                }

                this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                row = this.m_objViewer.ctlDataGrid1.RowCount - 1;

                this.m_objViewer.ctlDataGrid1[row, c_Find] = this.m_objViewer.DataGrid1[i, c_Find];
                this.m_objViewer.ctlDataGrid1[row, c_Count] = this.m_objViewer.DataGrid1[i, c_Count];
                this.m_objViewer.ctlDataGrid1[row, c_Unit] = this.m_objViewer.DataGrid1[i, c_Unit];
                this.m_objViewer.ctlDataGrid1[row, c_Name] = this.m_objViewer.DataGrid1[i, c_Name];
                this.m_objViewer.ctlDataGrid1[row, c_Spec] = this.m_objViewer.DataGrid1[i, c_Spec];

                this.m_objViewer.ctlDataGrid1[row, c_Price] = this.m_objViewer.DataGrid1[i, c_Price];
                this.m_objViewer.ctlDataGrid1[row, c_BigUnit] = this.m_objViewer.DataGrid1[i, c_BigUnit];

                this.m_objViewer.ctlDataGrid1[row, c_ItemID] = this.m_objViewer.DataGrid1[i, c_ItemID];
                this.m_objViewer.ctlDataGrid1[row, c_Packet] = this.m_objViewer.DataGrid1[i, c_Packet];
                this.m_objViewer.ctlDataGrid1[row, c_DiscountName] = this.m_objViewer.DataGrid1[i, c_DiscountName];//比例
                this.m_objViewer.ctlDataGrid1[row, c_Discount] = this.m_objViewer.DataGrid1[i, c_Discount];
                this.m_objViewer.ctlDataGrid1[row, c_UnitFlag] = this.m_objViewer.DataGrid1[i, c_UnitFlag];
                this.m_objViewer.ctlDataGrid1[row, c_Dosage] = this.m_objViewer.DataGrid1[i, c_Dosage];
                this.m_objViewer.ctlDataGrid1[row, c_MaxLimit] = this.m_objViewer.DataGrid1[i, c_MaxLimit];//上限
                this.m_objViewer.ctlDataGrid1[row, c_MinLimit] = this.m_objViewer.DataGrid1[i, c_MinLimit];//下限
                this.m_objViewer.ctlDataGrid1[row, c_IsCal] = this.m_objViewer.DataGrid1[i, c_IsCal];
                this.m_objViewer.ctlDataGrid1[row, c_InvoiceType] = this.m_objViewer.DataGrid1[i, c_InvoiceType];//发票分类

                this.m_objViewer.ctlDataGrid1[row, c_UsageName] = this.m_objViewer.DataGrid1[i, c_UsageName];//默认用法名称
                this.m_objViewer.ctlDataGrid1[row, c_UsageID] = this.m_objViewer.DataGrid1[i, c_UsageID];//默认用法ID
                this.m_objViewer.ctlDataGrid1[row, c_EnglishName] = this.m_objViewer.DataGrid1[i, c_EnglishName];//英文名			

                this.m_objViewer.ctlDataGrid1[row, c_FreName] = this.m_objViewer.DataGrid1[i, c_FreName];
                this.m_objViewer.ctlDataGrid1[row, c_FreDays] = this.m_objViewer.DataGrid1[i, c_FreDays];
                this.m_objViewer.ctlDataGrid1[row, c_FreTimes] = this.m_objViewer.DataGrid1[i, c_FreTimes];
                this.m_objViewer.ctlDataGrid1[row, c_FreID] = this.m_objViewer.DataGrid1[i, c_FreID];

                this.m_objViewer.ctlDataGrid1[row, c_PSFlag] = this.m_objViewer.DataGrid1[i, c_PSFlag];//皮试标志
                this.m_objViewer.ctlDataGrid1[row, c_PS] = this.m_objViewer.DataGrid1[i, c_PS];

                this.m_objViewer.ctlDataGrid1[row, c_Deptmed] = "";
                this.m_objViewer.ctlDataGrid1[row, c_DeptmedID] = "";

                this.m_objViewer.ctlDataGrid1[row, c_Find] = this.m_objViewer.DataGrid1[i, c_Find];
                this.m_objViewer.ctlDataGrid1[row, c_IsMain] = this.m_objViewer.DataGrid1[i, c_IsMain];

                this.m_objViewer.ctlDataGrid1[row, c_GroupNo] = this.m_objViewer.DataGrid1[i, c_GroupNo];
                this.m_objViewer.ctlDataGrid1[row, c_Day] = this.m_objViewer.DataGrid1[i, c_Day];
                this.m_objViewer.ctlDataGrid1[row, c_SumMoney] = this.m_objViewer.DataGrid1[i, c_SumMoney];
                this.m_objViewer.ctlDataGrid1[row, c_Total] = this.m_objViewer.DataGrid1[i, c_Total];
            }
            #endregion

            #region 中药
            for (int i = 0; i < this.m_objViewer.DataGrid2.RowCount; i++)
            {
                if ((this.m_objViewer.DataGrid2[i, 22].ToString().Trim() != "" && !this.m_objViewer.DataGrid2[i, 22].ToString().Trim().StartsWith("[PK]"))
                    || (this.m_objViewer.DataGrid2[i, cm_resubitem].ToString().Trim() != "" && !this.m_objViewer.DataGrid2[i, cm_resubitem].ToString().Trim().StartsWith("[PK]")))
                {
                    continue;
                }

                this.m_objViewer.ctlDataGrid2.m_mthAppendRow();
                row = this.m_objViewer.ctlDataGrid2.RowCount - 1;

                this.m_objViewer.ctlDataGrid2[row, 0] = this.m_objViewer.DataGrid2[i, 0];

                this.m_objViewer.ctlDataGrid2[row, 1] = this.m_objViewer.DataGrid2[i, 1];
                this.m_objViewer.ctlDataGrid2[row, 11] = this.m_objViewer.DataGrid2[i, 11];

                this.m_objViewer.ctlDataGrid2[row, 2] = this.m_objViewer.DataGrid2[i, 2];
                this.m_objViewer.ctlDataGrid2[row, 3] = this.m_objViewer.DataGrid2[i, 3];
                this.m_objViewer.ctlDataGrid2[row, 4] = this.m_objViewer.DataGrid2[i, 4];
                this.m_objViewer.ctlDataGrid2[row, 5] = this.m_objViewer.DataGrid2[i, 5];
                this.m_objViewer.ctlDataGrid2[row, 6] = this.m_objViewer.DataGrid2[i, 6];
                this.m_objViewer.ctlDataGrid2[row, 7] = this.m_objViewer.DataGrid2[i, 7];
                this.m_objViewer.ctlDataGrid2[row, 8] = this.m_objViewer.DataGrid2[i, 8];
                this.m_objViewer.ctlDataGrid2[row, 10] = this.m_objViewer.DataGrid2[i, 10];//比例
                this.m_objViewer.ctlDataGrid2[row, 11] = this.m_objViewer.DataGrid2[i, 11];
                this.m_objViewer.ctlDataGrid2[row, 13] = this.m_objViewer.DataGrid2[i, 13];
                this.m_objViewer.ctlDataGrid2[row, 14] = this.m_objViewer.DataGrid2[i, 14];
                this.m_objViewer.ctlDataGrid2[row, 16] = this.m_objViewer.DataGrid2[i, 16];
                this.m_objViewer.ctlDataGrid2[row, 17] = this.m_objViewer.DataGrid2[i, 17];
                this.m_objViewer.ctlDataGrid2[row, 18] = this.m_objViewer.DataGrid2[i, 18];
                this.m_objViewer.ctlDataGrid2[row, 19] = this.m_objViewer.DataGrid2[i, 19];
                this.m_objViewer.ctlDataGrid2[row, 20] = this.m_objViewer.DataGrid2[i, 20];//发票分类
                this.m_objViewer.ctlDataGrid2[row, 21] = this.m_objViewer.DataGrid2[i, 21];  //用法ID
                this.m_objViewer.ctlDataGrid2[row, 24] = this.m_objViewer.DataGrid2[i, 24];//英文名

                this.m_objViewer.ctlDataGrid2[row, 0] = this.m_objViewer.DataGrid2[i, 0];
            }
            #endregion

            #region 检验
            for (int i = 0; i < this.m_objViewer.DataGridLis.RowCount; i++)
            {
                this.m_objViewer.ctlDataGridLis.m_mthAppendRow();
                row = this.m_objViewer.ctlDataGridLis.RowCount - 1;

                this.m_objViewer.ctlDataGridLis[row, t_Find] = this.m_objViewer.DataGridLis[i, t_Find];
                this.m_objViewer.ctlDataGridLis[row, t_Name] = this.m_objViewer.DataGridLis[i, t_Name];
                this.m_objViewer.ctlDataGridLis[row, t_Spec] = this.m_objViewer.DataGridLis[i, t_Spec];//规格
                this.m_objViewer.ctlDataGridLis[row, t_PartName] = this.m_objViewer.DataGridLis[i, t_PartName];
                this.m_objViewer.ctlDataGridLis[row, t_Unit] = this.m_objViewer.DataGridLis[i, t_Unit];
                this.m_objViewer.ctlDataGridLis[row, t_ItemID] = this.m_objViewer.DataGridLis[i, t_ItemID];
                this.m_objViewer.ctlDataGridLis[row, t_PriceFlag] = this.m_objViewer.DataGridLis[i, t_PriceFlag]; //用自定价格列记录申请单元ID        
                this.m_objViewer.ctlDataGridLis[row, t_InvoiceType] = this.m_objViewer.DataGridLis[i, t_InvoiceType];
                this.m_objViewer.ctlDataGridLis[row, t_EnglishName] = this.m_objViewer.DataGridLis[i, t_EnglishName];
                this.m_objViewer.ctlDataGridLis[row, t_Temp] = this.m_objViewer.DataGridLis[i, t_Temp];
                this.m_objViewer.ctlDataGridLis[row, t_Count] = this.m_objViewer.DataGridLis[i, t_Count];

                this.m_objViewer.ctlDataGridLis[row, t_Price] = this.m_objViewer.DataGridLis[i, t_Price];
                this.m_objViewer.ctlDataGridLis[row, t_SumMoney] = this.m_objViewer.DataGridLis[i, t_SumMoney];
            }
            #endregion

            #region 检查
            for (int i = 0; i < this.m_objViewer.DataGridTest.RowCount; i++)
            {
                this.m_objViewer.ctlDataGridTest.m_mthAppendRow();
                row = this.m_objViewer.ctlDataGridTest.RowCount - 1;

                this.m_objViewer.ctlDataGridTest[row, t_Find] = this.m_objViewer.DataGridTest[i, t_Find];
                this.m_objViewer.ctlDataGridTest[row, t_Name] = this.m_objViewer.DataGridTest[i, t_Name];
                this.m_objViewer.ctlDataGridTest[row, t_Spec] = this.m_objViewer.DataGridTest[i, t_Spec];
                this.m_objViewer.ctlDataGridTest[row, t_PartName] = this.m_objViewer.DataGridTest[i, t_PartName];
                this.m_objViewer.ctlDataGridTest[row, t_Unit] = this.m_objViewer.DataGridTest[i, t_Unit];
                this.m_objViewer.ctlDataGridTest[row, t_Price] = this.m_objViewer.DataGridTest[i, t_Price];
                this.m_objViewer.ctlDataGridTest[row, t_ItemID] = this.m_objViewer.DataGridTest[i, t_ItemID];
                this.m_objViewer.ctlDataGridTest[row, t_PriceFlag] = this.m_objViewer.DataGridTest[i, t_PriceFlag];
                this.m_objViewer.ctlDataGridTest[row, t_DiscountName] = this.m_objViewer.DataGridTest[i, t_DiscountName];//比例
                this.m_objViewer.ctlDataGridTest[row, t_Discount] = this.m_objViewer.DataGridTest[i, t_Discount];
                this.m_objViewer.ctlDataGridTest[row, t_InvoiceType] = this.m_objViewer.DataGridTest[i, t_InvoiceType];
                this.m_objViewer.ctlDataGridTest[row, t_EnglishName] = this.m_objViewer.DataGridTest[i, t_EnglishName];
                this.m_objViewer.ctlDataGridTest[row, t_Temp] = this.m_objViewer.DataGridTest[i, t_Temp];
                this.m_objViewer.ctlDataGridTest[row, t_Count] = this.m_objViewer.DataGridTest[i, t_Count];
                this.m_objViewer.ctlDataGridTest[row, t_UsageID] = this.m_objViewer.DataGridTest[i, t_UsageID];

                this.m_objViewer.ctlDataGridTest[row, t_SumMoney] = this.m_objViewer.DataGridTest[i, t_SumMoney];
            }
            #endregion

            #region 治疗(手术)
            for (int i = 0; i < this.m_objViewer.DataGridOps.RowCount; i++)
            {
                this.m_objViewer.ctlDataGridOps.m_mthAppendRow();
                row = this.m_objViewer.ctlDataGridOps.RowCount - 1;

                this.m_objViewer.ctlDataGridOps[row, o_Find] = this.m_objViewer.DataGridOps[i, o_Find];
                this.m_objViewer.ctlDataGridOps[row, o_Name] = this.m_objViewer.DataGridOps[i, o_Name];
                this.m_objViewer.ctlDataGridOps[row, o_Spec] = this.m_objViewer.DataGridOps[i, o_Spec];
                this.m_objViewer.ctlDataGridOps[row, o_Unit] = this.m_objViewer.DataGridOps[i, o_Unit];
                this.m_objViewer.ctlDataGridOps[row, o_Price] = this.m_objViewer.DataGridOps[i, o_Price];
                this.m_objViewer.ctlDataGridOps[row, o_ItemID] = this.m_objViewer.DataGridOps[i, o_ItemID];
                this.m_objViewer.ctlDataGridOps[row, o_PriceFlag] = this.m_objViewer.DataGridOps[i, o_PriceFlag]; //用自定义价格列存申请单类型
                this.m_objViewer.ctlDataGridOps[row, o_DiscountName] = this.m_objViewer.DataGridOps[i, o_DiscountName];//比例
                this.m_objViewer.ctlDataGridOps[row, o_Discount] = this.m_objViewer.DataGridOps[i, o_Discount];
                this.m_objViewer.ctlDataGridOps[row, o_InvoiceType] = this.m_objViewer.DataGridOps[i, o_InvoiceType];
                this.m_objViewer.ctlDataGridOps[row, o_EnglishName] = this.m_objViewer.DataGridOps[i, o_EnglishName];
                this.m_objViewer.ctlDataGridOps[row, o_Count] = this.m_objViewer.DataGridOps[i, o_Count];
                this.m_objViewer.ctlDataGridOps[row, o_UsageID] = this.m_objViewer.DataGridOps[i, o_UsageID];

                this.m_objViewer.ctlDataGridOps[row, o_SumMoney] = this.m_objViewer.DataGridOps[i, o_SumMoney];
            }
            #endregion

            #region 其他(材料)
            for (int i = 0; i < this.m_objViewer.DataGrid6.RowCount; i++)
            {
                if ((this.m_objViewer.DataGrid6[i, o_OtherItemID].ToString().Trim() != "" && !this.m_objViewer.DataGrid6[i, o_OtherItemID].ToString().Trim().StartsWith("[PK]"))
                    || (this.m_objViewer.DataGrid6[i, o_resubitem].ToString().Trim() != "" && !this.m_objViewer.DataGrid6[i, o_resubitem].ToString().Trim().StartsWith("[PK]")))
                {
                    continue;
                }

                this.m_objViewer.ctlDataGrid6.m_mthAppendRow();
                row = this.m_objViewer.ctlDataGrid6.RowCount - 1;

                this.m_objViewer.ctlDataGrid6[row, o_Find] = this.m_objViewer.DataGrid6[i, o_Find];
                this.m_objViewer.ctlDataGrid6[row, o_Name] = this.m_objViewer.DataGrid6[i, o_Name];
                this.m_objViewer.ctlDataGrid6[row, o_Spec] = this.m_objViewer.DataGrid6[i, o_Spec];
                this.m_objViewer.ctlDataGrid6[row, o_Unit] = this.m_objViewer.DataGrid6[i, o_Unit];
                this.m_objViewer.ctlDataGrid6[row, o_Price] = this.m_objViewer.DataGrid6[i, o_Price];
                this.m_objViewer.ctlDataGrid6[row, o_ItemID] = this.m_objViewer.DataGrid6[i, o_ItemID];
                this.m_objViewer.ctlDataGrid6[row, o_PriceFlag] = this.m_objViewer.DataGrid6[i, o_PriceFlag];
                this.m_objViewer.ctlDataGrid6[row, o_DiscountName] = this.m_objViewer.DataGrid6[i, o_DiscountName]; //比例
                this.m_objViewer.ctlDataGrid6[row, o_Discount] = this.m_objViewer.DataGrid6[i, o_Discount];
                this.m_objViewer.ctlDataGrid6[row, o_InvoiceType] = this.m_objViewer.DataGrid6[i, o_InvoiceType];
                this.m_objViewer.ctlDataGrid6[row, o_EnglishName] = this.m_objViewer.DataGrid6[i, o_EnglishName];

                this.m_objViewer.ctlDataGrid6[row, o_Deptmed] = this.m_objViewer.DataGrid6[i, o_Deptmed];
                this.m_objViewer.ctlDataGrid6[row, o_DeptmedID] = this.m_objViewer.DataGrid6[i, o_DeptmedID];

                this.m_objViewer.ctlDataGrid6[row, o_Count] = this.m_objViewer.DataGrid6[i, o_Count];
                this.m_objViewer.ctlDataGrid6[row, o_SumMoney] = this.m_objViewer.DataGrid6[i, o_SumMoney]; 
            }
            #endregion
        }
        #endregion
    }

    #region 协定处方比较类
    /// <summary>
    /// 协定处方比较类
    /// </summary>
    public class AccordRecipeEdit : IComparable
    {
        /// <summary>
        /// 处方ID
        /// </summary>
        public string RecipeID_Chr = "";
        /// <summary>
        /// 简码
        /// </summary>
        public string UserCode_Chr = "";
        /// <summary>
        /// 拼音码
        /// </summary>
        public string PyCode_Chr = "";
        /// <summary>
        /// 五笔码
        /// </summary>
        public string WbCode_Chr = "";
        /// <summary>
        /// 1 个人 2 科室 0 公共
        /// </summary>
        public string Privilege_Int = "";
        /// <summary>
        /// 0 停用 1 启用
        /// </summary>
        public string Status_Int = "";
        /// <summary>
        /// 备注
        /// </summary>
        public string ReMark_Vchr = "";
        /// <summary>
        /// 输出名
        /// </summary>
        private string OutputName;
        /// <summary>
        /// 原始名称
        /// </summary>
        public string OrigeName;
        /// <summary>
        /// 索引ID
        /// </summary>
        public string IndexID;
        /// <summary>
        /// 组别层
        /// </summary>
        public string[] LevelNameArr;
        /// <summary>
        /// 处方名
        /// </summary>
        public string Recipename_Chr
        {
            set
            {
                OrigeName = value;
                LevelNameArr = value.Replace(">>", "-").Split('-');
                OutputName = LevelNameArr[LevelNameArr.Length - 1];
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < LevelNameArr.Length; i++)
                {
                    sb.Append(LevelNameArr[i]);
                }
                IndexID = sb.ToString();
            }
            get
            {
                return OutputName;
            }
        }

        /// <summary>
        /// 重写ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return OutputName;
        }
        #region IComparable 成员
        /// <summary>
        /// IComparable 成员
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            AccordRecipeEdit objTemp = obj as AccordRecipeEdit;
            return this.IndexID.CompareTo(objTemp.IndexID);
        }
        #endregion
    }
    #endregion
}
