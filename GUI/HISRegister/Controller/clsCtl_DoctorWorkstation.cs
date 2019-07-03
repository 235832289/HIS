using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml;
using com.digitalwave.GLS_WS;
using com.digitalwave.GLS_WS.ApplyReportServer;
using com.digitalwave.iCare.gui.LIS;
using com.digitalwave.iCare.middletier.HI;
using com.digitalwave.iCare.ValueObject;
//using LisI = com.digitalwave.iCare.gui.LIS_NewAppInterface_Agent;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// clsCtl_DoctorWorkstation 的摘要说明。
    /// </summary>
    public class clsCtl_DoctorWorkstation : com.digitalwave.GUI_Base.clsController_Base
    {

        public clsCtl_DoctorWorkstation()
        {
            objSvc = new clsDcl_DoctorWorkstation();
            dp = (DataProcess)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(DataProcess));
        }

        #region 常量定义

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
        /// <summary>
        /// 项目总让利
        /// </summary>
        internal int c_intDiffPrice = 40;
        /// <summary>
        ///项目单位让利
        /// </summary>
        internal int c_intDiffUnitPrice = 41;

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
        /// <summary>
        /// 药房二级库存管理限制标准 false-不严格、只提示 true-严格控制、库存不足不允许通过
        /// </summary>
        internal bool SecondStockLimitFlag = false;
        /// <summary>
        /// 是否使用药房二级库存管理
        /// </summary>
        internal bool SecondStockUseFlag = false;
        /// <summary>
        /// 大小单位标记
        /// </summary>
        internal int cm_UnitFlag = 20;
        /// <summary>
        /// 自动扣减药房理论库存的方式 1 按入库时间；2 按有效期；3 先按入库时间再按有效期；4 先按有效期再按入库时间
        /// </summary>
        private string strDeductType = "1";
        /// <summary>
        /// 西药库ID
        /// </summary>
        internal string WMDrugStoreID = "";
        /// <summary>
        /// 西药库-科室ID
        /// </summary>
        internal string WMDrugStoreDeptID = "";
        /// <summary>
        /// 西药库Name
        /// </summary>
        internal string WMDrugStoreName = "";
        /// <summary>
        /// 中药库ID
        /// </summary>
        internal string CMDrugStoreID = "";
        /// <summary>
        /// 中药库ID-科室ID
        /// </summary>
        internal string CMDrugStoreDeptID = "";
        /// <summary>
        /// 中药库Name
        /// </summary>
        internal string CMDrugStoreName = "";
        /// <summary>
        /// 材料库ID
        /// </summary>
        internal string MaterialStoreID = "";
        /// <summary>
        /// 材料库ID-科室ID
        /// </summary>
        internal string MaterialStoreDeptID = "";
        /// <summary>
        /// 材料库Name
        /// </summary>
        internal string MaterialStoreName = "";
        /// <summary>
        /// 药房视图
        /// </summary>
        private DataView dvMedStore;
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
        /// <summary>
        /// 检查收费明细
        /// </summary>
        internal int t_test_ChargeDetial = 23;
        /// <summary>
        /// 检查收费明细
        /// </summary>
        internal int t_test4_ChargeDetial = 25;
        #endregion

        #region 应用参数
        /// <summary>
        /// 手术申请数组
        /// </summary>
        internal ArrayList OPSApplyarr = new ArrayList();
        /// <summary>
        /// 保存检验申请单元与收费项目对应关系
        /// </summary>
        DataTable dtApply = null;
        /// <summary>
        /// 精神性药物提示信息
        /// </summary>
        private string Neurpurhintinfo = "该药品为精神药物。\r\n\r\n①一类(如利他林)不能超过3天，请补手写处方；\r\n\r\n②二类（如安定类）不能超过7天，特殊情况不超过14天（请注明理由）。";
        /// <summary>
        /// 毒麻药物提示信息
        /// </summary>
        private string Drugpurhintinfo = "该药品为毒麻药物，请补手写处方。\r\n\r\n麻醉药品使用须知：\r\n\r\n  ①注射剂每张处方一次用量（限院内注射）；\r\n\r\n  ②控缓释制剂不能超过7天；\r\n\r\n  ③其它剂型不能超过3天。";
        /// <summary>
        /// 禁忌药品
        /// </summary>
        private int intNo = 0;
        private clsDcl_DoctorWorkstation objSvc = null;
        private int colNo = 0;//全局变量,记录datagrid的CellChange产生时的单位格
        private int rowNo = 0;
        /// <summary>
        /// 标志是否计算总数(true 计算,false不计算),在手工改动总数后就不计算,改变剂量和改变频率或天数时就计算
        /// </summary>
        public bool IsCalculateAmount = true;

        private com.digitalwave.GLS_WS.ApplyReportServer.DataProcess dp;
        /// <summary>
        /// 科备药前景色
        /// </summary>
        private Color dfc = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// 科备药背景色
        /// </summary>
        private Color dbc = Color.FromArgb(99, 143, 97);
        /// <summary>
        /// 正常前景色
        /// </summary>
        private Color nfc = Color.FromArgb(0, 0, 0);
        /// <summary>
        /// 正常背景色
        /// </summary>
        private Color nbc = Color.FromArgb(255, 255, 255);
        /// <summary>
        /// XML文件名
        /// </summary>
        private string XMLFile = Application.StartupPath + @"\LoginFile.xml";
        /// <summary>
        /// 药典备注显示信息窗口
        /// </summary>
        frmCodexRemark frmRemark = null;
        /// <summary>
        /// 处方类型对应药品属性哈西表 
        /// </summary>
        private Hashtable hasRecipeDefMedProperty = new Hashtable();
        /// <summary>
        /// 诊疗项目对应哈西表
        /// </summary>
        internal Hashtable hasOrderID = new Hashtable();
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
        /// 东莞市门诊医保身份（费别）对应ID (数组)
        /// </summary>
        private ArrayList YBPayTypeArr = new ArrayList();
        /// <summary>
        /// 是否是东莞市门诊医保身份（费别）
        /// </summary>
        internal bool IsDongGuanYBPatient = false;
        /// <summary>
        /// 东莞市门诊医保病人：门诊医生工作站、收费处是否显示全自费的收费项目
        /// </summary>
        private bool YBIsShowSelfItem = false;
        /// <summary>
        /// 系统内部申请单分类 TypeID 对应 分类
        /// </summary>
        internal System.Collections.Generic.Dictionary<string, string> objAID_APPLY_RLT = null;
        /// <summary>
        /// 特殊用法对应西药房ID数组
        /// </summary>
        private ArrayList WMUsageIDArr = new ArrayList();
        /// <summary>
        /// 特殊用法对应中药房ID数组
        /// </summary>
        private ArrayList CMUsageIDArr = new ArrayList();
        /// <summary>
        /// 特殊用法对应材料发放处ID数组
        /// </summary>
        private ArrayList MATUsageIDArr = new ArrayList();
        #endregion

        /// <summary>
        /// 欠费弹窗对象
        /// </summary>
        public frmDebtMessage frmDM = null;

        /// <summary>
        /// 欠费提醒窗口是否已显示
        /// </summary>
        public bool blnIfDMShow = false;

        /// <summary>
        /// (西药)片剂哈希表
        /// </summary>
        internal Hashtable hasMedPiece = new Hashtable();

        /// <summary>
        /// 易制毒数组
        /// </summary>
        List<string> DataProduceDrugs { get; set; }

        /// <summary>
        /// 微信推送信息地址
        /// </summary>
        string WechatWebUrl { get; set; }

        /// <summary>
        /// 是否启用东莞市预约平台通知功能
        /// </summary>
        bool IsUseDgPlatformNotice { get; set; }

        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmDoctorWorkstation m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmDoctorWorkstation)frmMDI_Child_Base_in;
        }
        #endregion

        #region 产生一个新的计费类对象
        public clsCalcPatientCharge objCalPatientCharge = null;
        /// <summary>
        /// 产生一个新的计费类对象
        /// </summary>
        public void m_mthCreatCalObj()
        {
            this.m_objViewer.btDel.Text = "作废(&Z)";
            this.m_objViewer.lbeFlag.Text = "";
            objCalPatientCharge = new clsCalcPatientCharge(m_objViewer.m_PatInfo.PatientID, m_objViewer.m_PatInfo.PayTypeID, m_objViewer.m_PatInfo.Limit, this.m_objComInfo.m_strGetHospitalTitle(), m_objViewer.m_PatInfo.PatientType, m_objViewer.m_PatInfo.Discount);
            OPSApplyarr = new ArrayList();
            this.m_mthCalculateTotalMoney();
        }
        #endregion

        #region 初始化窗体
        /// <summary>
        /// 初始化窗体
        /// </summary>
        public void m_mthIniComponent()
        {
            if (this.m_objViewer.LoginInfo != null)
            {
                //在病人信息控件保存登录医生的ID和用户名。
                this.m_objViewer.m_PatInfo.CurrentDoctorID = this.m_objViewer.LoginInfo.m_strEmpID;
                this.m_objViewer.m_PatInfo.CurrentDoctorName = this.m_objViewer.LoginInfo.m_strEmpName;
                this.m_objViewer.m_PatInfo.CurrentDoctorNo = this.m_objViewer.LoginInfo.m_strEmpNo;
                this.m_objViewer.m_PatInfo.CurrentDeptID = this.m_objViewer.LoginInfo.m_strDepartmentID;
                this.m_objViewer.m_PatInfo.CurrentDeptName = this.m_objViewer.LoginInfo.m_strdepartmentName;
                this.m_objViewer.m_PatInfo.HospitalName = this.m_objComInfo.m_strGetHospitalTitle();
                this.m_objViewer.m_PatInfo.CurrentDoctTechnicalRank = this.m_objViewer.LoginInfo.m_strTechnicalRank;

                com.digitalwave.iCare.ValueObject.clsDepartmentVO[] objDept = null;
                this.m_objComInfo.m_mthGetDepartmentByUserID(this.m_objViewer.LoginInfo.m_strEmpID, out objDept);
                this.m_objViewer.m_PatInfo.objDeptList = objDept;
            }
            //读出系统配置，保存在变量中。
            this.m_mthIsCanDo();
            //获取当前医生的候诊列表
            this.m_GetWaitReg();
            //加载部门信息
            this.m_mthLoadDepartment();
            //获取当前医生的接诊列表
            this.m_mthSelectPat(0);
            //获取发票类型对应表，根据发票分类来对应。
            this.m_mthLoadCat();
            //生成一个新的计费类
            this.m_mthCreatCalObj();
            //把DataGrid的回车键转为空格键。
            this.m_mthSetDataGridEnterToSpace();
            //加载中药用法
            this.m_objViewer.cmbCooking.LoadData();
            //加载处方的类型，例如小儿处方或成人。
            this.m_mthGetRecipeTypeInfo();
            this.m_objViewer.txtLoadRecipeNo1.UseFlag = 2;
            //			this.m_objViewer.cmbCooking.SelectedIndex=0;
            this.m_objViewer.m_cmbFind.SelectedIndex = 2;
            this.m_objViewer.m_cmbRecipeType.SelectedIndex = 0;
            this.m_objViewer.lbeFlag.Text = "";
            this.m_objViewer.ctlDataGrid1.Controls.Add(this.m_objViewer.listView2);
            this.m_objViewer.ctlDataGrid1.Controls.Add(this.m_objViewer.listView3);
            this.m_objViewer.ctlDataGrid2.Controls.Add(this.m_objViewer.listView4);
            this.m_objViewer.listView5.Leave += new EventHandler(listView5_Leave);
            this.m_objViewer.listView5.DoubleClick += new EventHandler(listView5_DoubleClick);
            this.m_objViewer.listView5.KeyDown += new KeyEventHandler(listView5_KeyDown);
            //微调由2003升级到2005时panel2高度BUG
            if (this.m_objViewer.LoginInfo.m_strEmpNo != "0001")
            {
                this.m_objViewer.panel2.Height += 20;
            }
            //判断是否能开申请单
            this.m_mthCanCreatApplyBill();

            //检验、检查、手术治疗项目录入方式
            if (ItemInputMode == 0)
            {
                this.m_objViewer.ctlDataGridLis.Visible = false;
                this.m_objViewer.ctlDataGridTest.Visible = false;
                this.m_objViewer.ctlDataGridOps.Visible = false;
            }
            else if (ItemInputMode == 1)
            {
                this.m_objViewer.ctlDataGrid3.Visible = false;
                this.m_objViewer.ctlDataGrid4.Visible = false;
                this.m_objViewer.ctlDataGrid5.Visible = false;
            }

            //把焦点设在卡号上
            this.m_objViewer.m_PatInfo.txtCardID.Select();
            //控制处方权(相应TABPAGE)
            this.m_mthSetTabPage();
            //允许卡号输入的长度大于10
            this.m_objViewer.m_PatInfo.txtCardID.MaxLength = 18;

            // 易制毒数据源
            DataProduceDrugs = new List<string>();
            DataTable dtP = objSvc.GetProduceDrugs();
            if (dtP != null && dtP.Rows.Count > 0)
            {
                foreach (DataRow dr in dtP.Rows)
                {
                    DataProduceDrugs.Add(dr["itemid_chr"].ToString());
                }
            }
        }
        #endregion

        #region 加载部门
        /// <summary>
        /// 加载部门
        /// </summary>
        private void m_mthLoadDepartment()
        {
            clsDepartmentVO[] objArr;
            m_objComInfo.m_mthGetDepartmentByUserID(this.m_objViewer.LoginInfo.m_strEmpID, out objArr);
            if (objArr != null)
            {
                for (int i = 0; i < objArr.Length; i++)
                {
                    this.m_objViewer.cmbDeparment.Item.Add(objArr[i].strDeptName, objArr[i].strDeptID);
                }
                this.m_objViewer.cmbDeparment.SelectedIndex = 0;
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
            //检验
            m_objViewer.ctlDataGrid3.m_mthAddEnterToSpaceColumn(0);
            m_objViewer.ctlDataGrid3.m_mthAddEnterToSpaceColumn(1);
            m_objViewer.ctlDataGrid3.m_mthAddEnterToSpaceColumn(t_Price);
            m_objViewer.ctlDataGrid3.m_mthAddEnterToSpaceColumn(t_PartName);
            m_objViewer.ctlDataGrid3.m_mthAddEnterToSpaceColumn(t_quick);
            //检查
            m_objViewer.ctlDataGrid4.m_mthAddEnterToSpaceColumn(0);
            m_objViewer.ctlDataGrid4.m_mthAddEnterToSpaceColumn(1);
            m_objViewer.ctlDataGrid4.m_mthAddEnterToSpaceColumn(t_Price);
            m_objViewer.ctlDataGrid4.m_mthAddEnterToSpaceColumn(t_PartName);
            //手术
            m_objViewer.ctlDataGrid5.m_mthAddEnterToSpaceColumn(0);
            m_objViewer.ctlDataGrid5.m_mthAddEnterToSpaceColumn(1);
            m_objViewer.ctlDataGrid5.m_mthAddEnterToSpaceColumn(o_Price);
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

        #region 查找西药处方项目
        /// <summary>
        /// 根据查询内容查找药品
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindWMedicineByID(string ID, int row)
        {//修改
            DataTable dt = null;
            string strTempPatientTypeID = "0001";
            if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
            {
                strTempPatientTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
            }
            //获取药房
            string m_strRealMedStoreID = string.Empty;
            string m_strMedStoreID = this.m_strReadXML("register", "WMedicinestore", "AnyOne");
            m_strRealMedStoreID = this.m_strGetDurgStoreID(m_strMedStoreID);

            long strRet = objSvc.m_mthFindWMedicineByID(this.m_objViewer.m_cmbFind.Tag.ToString(), strFind + ID, strTempPatientTypeID, out dt, this.m_objViewer.LoginInfo.m_strEmpID, m_strRealMedStoreID);

            if (strRet > 0 && dt.Rows.Count > 0)
            {

                //				if(dt.Rows.Count==1&&isShowLackMedicine)
                //				{
                //					if(m_objViewer.ctlDataGrid1[row,c_ItemID].ToString().Trim()!="")
                //					{
                //						this.m_objViewer.alertLight1.m_mthDeleteItem(m_objViewer.ctlDataGrid1[row,c_ItemID].ToString().Trim());
                //					}
                //					
                //					if(dt.Rows[0]["NOQTYFLAG_INT"].ToString().Trim()!="0")
                //					{
                //						if(MessageBox.Show("缺药!是否继续?","ICare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
                //						{
                //							return;
                //						}
                //					}					
                //					m_mthFillDataGridByRow(dt.Rows[0],row);
                //				}
                //				else
                //				{
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

                    //东莞门诊医保
                    if (!YBIsShowSelfItem && IsDongGuanYBPatient)
                    {
                        if (dt.Rows[i]["precent_dec"].ToString().Trim() == "100")
                        {
                            continue;
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
                // }
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid1.Columns[1]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
        }
        #endregion

        #region 添加收费项目到计费类
        /// <summary>
        /// 添加收费项目到计费类
        /// </summary>
        /// <param name="p_row">当前datagrid的行</param>
        /// <param name="p_Location">确定是那一个datagrid</param>
        public void m_mthAddItemToCulateClass(int p_row, int p_Location)
        {
            decimal price = 0;
            decimal dosage = 0;
            int row = 3000;
            decimal discount = 100;
            string strInvoice = "";
            switch (p_Location)
            {
                case 2://中药
                    price = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[p_row, 5]);
                    dosage = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[p_row, 14]);
                    if (m_objViewer.ctlDataGrid2[p_row, 8] != null && m_objViewer.ctlDataGrid2[p_row, 8].ToString().Trim() != "")
                    {
                        row = int.Parse(m_objViewer.ctlDataGrid2[p_row, 8].ToString().Trim());
                    }

                    if (m_objViewer.ctlDataGrid2[p_row, 10] != null && m_objViewer.ctlDataGrid2[p_row, 10].ToString().Trim() != "")
                    {
                        discount = Convert.ToDecimal(m_objViewer.ctlDataGrid2[p_row, 10].ToString().Trim());
                    }
                    m_objViewer.ctlDataGrid2[p_row, 8] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(m_objViewer.ctlDataGrid2[p_row, 7].ToString().Trim(), price, "", dosage, row, discount, "", false);
                    break;
                case 3://检验
                    price = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid3[p_row, t_Price]);
                    dosage = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid3[p_row, t_Count]);
                    if (m_objViewer.ctlDataGrid3[p_row, t_RowNo] != null && m_objViewer.ctlDataGrid3[p_row, t_RowNo].ToString().Trim() != "")
                    {
                        row = int.Parse(m_objViewer.ctlDataGrid3[p_row, t_RowNo].ToString().Trim());
                    }

                    if (m_objViewer.ctlDataGrid3[p_row, t_Discount] != null && m_objViewer.ctlDataGrid3[p_row, t_Discount].ToString().Trim() != "")
                    {
                        discount = Convert.ToDecimal(m_objViewer.ctlDataGrid3[p_row, t_Discount].ToString().Trim());
                    }
                    strInvoice = m_objViewer.ctlDataGrid3[p_row, t_InvoiceType].ToString().Trim();
                    m_objViewer.ctlDataGrid3[p_row, t_RowNo] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(m_objViewer.ctlDataGrid3[p_row, t_ItemID].ToString().Trim(), price, strInvoice, dosage, row, discount, "", false);
                    break;
                case 4://检查
                    price = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid4[p_row, t_Price]);
                    dosage = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid4[p_row, t_Count]);
                    if (m_objViewer.ctlDataGrid4[p_row, t_RowNo] != null && m_objViewer.ctlDataGrid4[p_row, t_RowNo].ToString().Trim() != "")
                    {
                        row = int.Parse(m_objViewer.ctlDataGrid4[p_row, t_RowNo].ToString().Trim());
                    }

                    if (m_objViewer.ctlDataGrid4[p_row, t_Discount] != null && m_objViewer.ctlDataGrid4[p_row, t_Discount].ToString().Trim() != "")
                    {
                        discount = Convert.ToDecimal(m_objViewer.ctlDataGrid4[p_row, t_Discount].ToString().Trim());
                    }
                    strInvoice = m_objViewer.ctlDataGrid4[p_row, t_InvoiceType].ToString().Trim();
                    m_objViewer.ctlDataGrid4[p_row, t_RowNo] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(m_objViewer.ctlDataGrid4[p_row, t_ItemID].ToString().Trim(), price, strInvoice, dosage, row, discount, "", false);
                    break;
                case 5://手术
                    price = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid5[p_row, o_Price]);
                    dosage = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid5[p_row, o_Count]);
                    if (m_objViewer.ctlDataGrid5[p_row, o_RowNo] != null && m_objViewer.ctlDataGrid5[p_row, o_RowNo].ToString().Trim() != "")
                    {
                        row = int.Parse(m_objViewer.ctlDataGrid5[p_row, o_RowNo].ToString().Trim());
                    }
                    if (m_objViewer.ctlDataGrid5[p_row, o_Discount] != null && m_objViewer.ctlDataGrid5[p_row, o_Discount].ToString().Trim() != "")
                    {
                        discount = Convert.ToDecimal(m_objViewer.ctlDataGrid5[p_row, o_Discount].ToString().Trim());
                    }
                    strInvoice = m_objViewer.ctlDataGrid5[p_row, o_InvoiceType].ToString().Trim();
                    m_objViewer.ctlDataGrid5[p_row, o_RowNo] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(m_objViewer.ctlDataGrid5[p_row, o_ItemID].ToString().Trim(), price, strInvoice, dosage, row, discount, "", false);
                    break;
                case 6://其他
                    price = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid6[p_row, o_Price]);
                    dosage = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid6[p_row, o_Count]);
                    if (m_objViewer.ctlDataGrid6[p_row, o_RowNo] != null && m_objViewer.ctlDataGrid6[p_row, o_RowNo].ToString().Trim() != "")
                    {
                        row = int.Parse(m_objViewer.ctlDataGrid6[p_row, o_RowNo].ToString().Trim());
                    }

                    if (m_objViewer.ctlDataGrid6[p_row, o_Discount] != null && m_objViewer.ctlDataGrid6[p_row, o_Discount].ToString().Trim() != "")
                    {
                        discount = Convert.ToDecimal(m_objViewer.ctlDataGrid6[p_row, o_Discount].ToString().Trim());
                    }
                    strInvoice = m_objViewer.ctlDataGrid6[p_row, o_InvoiceType].ToString().Trim();
                    m_objViewer.ctlDataGrid6[p_row, o_RowNo] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(m_objViewer.ctlDataGrid6[p_row, o_ItemID].ToString().Trim(), price, strInvoice, dosage, row, discount, "", false);
                    break;
            }
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
            string strTempPatientTypeID = "0001";
            if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
            {
                strTempPatientTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
            }

            //获取药房
            string m_strRealMedStoreID = string.Empty;
            string m_strMedStoreID = this.m_strReadXML("register", "CMedicinestore", "AnyOne");
            m_strRealMedStoreID = this.m_strGetDurgStoreID(m_strMedStoreID);

            long strRet = objSvc.m_mthFindCMedicineByID(this.m_objViewer.m_cmbFind.Tag.ToString(), strFind + ID, strTempPatientTypeID, out dt, this.m_objViewer.LoginInfo.m_strEmpID, m_strRealMedStoreID);
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

                    //东莞门诊医保
                    if (!YBIsShowSelfItem && IsDongGuanYBPatient)
                    {
                        if (dt.Rows[0]["precent_dec"].ToString().Trim() == "100")
                        {
                            return;
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

                        //东莞门诊医保
                        if (!YBIsShowSelfItem && IsDongGuanYBPatient)
                        {
                            if (dt.Rows[i]["precent_dec"].ToString().Trim() == "100")
                            {
                                continue;
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
                        // lv.SubItems.Add(dt.Rows[i]["SUBTRADEMONEY"].ToString().Trim());// 批发单价
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
                    if (m_objViewer.listView1.Items.Count > 0)
                    {
                        m_objViewer.listView1.Items[0].Selected = true;
                    }
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

        #region 查找检验项目
        /// <summary>
        /// 查找检验项目
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindTestChargeByID(string ID, int row)
        {
            DataTable dt = null;
            string strTempPatientTypeID = "0001";
            if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
            {
                strTempPatientTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
            }
            long strRet = objSvc.m_mthFindTestChargeByID(this.m_objViewer.m_cmbFind.Tag.ToString(), strFind + ID, strTempPatientTypeID, out dt, this.m_objViewer.LoginInfo.m_strEmpID);
            if (strRet > 0 && dt.Rows.Count > 0)
            {

                //				if(dt.Rows.Count==1)
                //				{
                //							
                //				m_mthFillDataGridByRow3(dt.Rows[0],row);
                //										
                //					//直接填充datagrid
                //				}
                //				else
                //				{
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
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                if (m_objViewer.listView1.Items.Count > 0)
                {
                    m_objViewer.listView1.Items[0].Selected = true;
                }
                m_objViewer.listView1.Select();
                m_objViewer.listView1.Focus();
                //填充listView
                //				}
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid3.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
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
                    ListViewItem lv = new ListViewItem(ID);//项目ID
                    lv.SubItems.Add(dt.Rows[i]["NAME_CHR"].ToString().Trim());//名称
                    lv.SubItems.Add(dt.Rows[i]["COMMNAME_VCHR"].ToString().Trim());//通用名称
                    lv.SubItems.Add(dt.Rows[i]["ENGNAME_VCHR"].ToString().Trim());// 英文名
                    lv.SubItems.Add("检验费");// 发票分类名称
                    lv.SubItems.Add("");//规格
                    lv.SubItems.Add("1");//常用量
                    lv.SubItems.Add("次");//单位
                    lv.SubItems.Add(dt.Rows[i]["totalmny"].ToString().Trim());//单价
                    lv.SubItems.Add("");//比例
                    lv.SubItems.Add("");//医保分类
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                if (m_objViewer.listView1.Items.Count > 0)
                {
                    m_objViewer.listView1.Items[0].Selected = true;
                }
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

        #region 查找检查项目
        /// <summary>
        /// 查找检验项目
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindExamineChargeByID(string ID, int row)
        {
            DataTable dt = null;
            string strTempPatientTypeID = "0001";
            if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
            {
                strTempPatientTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
            }
            long strRet = objSvc.m_mthFindExamineChargeByID(this.m_objViewer.m_cmbFind.Tag.ToString(), strFind + ID, strTempPatientTypeID, out dt, this.m_objViewer.LoginInfo.m_strEmpID);
            if (strRet > 0 && dt.Rows.Count > 0)
            {

                //				if(dt.Rows.Count==1)
                //				{
                //								
                //						m_mthFillDataGridByRow4(dt.Rows[0],row);
                //										
                //					//直接填充datagrid
                //				}
                //				else
                //				{
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
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                if (m_objViewer.listView1.Items.Count > 0)
                {
                    m_objViewer.listView1.Items[0].Selected = true;
                }
                m_objViewer.listView1.Select();
                m_objViewer.listView1.Focus();
                //填充listView
                //				}
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid4.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
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
                    ListViewItem lv = new ListViewItem(ID); //项目ID
                    lv.SubItems.Add(dt.Rows[i]["NAME_CHR"].ToString().Trim());//名称
                    lv.SubItems.Add(dt.Rows[i]["COMMNAME_VCHR"].ToString().Trim());//通用名称
                    lv.SubItems.Add(dt.Rows[i]["ENGNAME_VCHR"].ToString().Trim());// 英文名
                    lv.SubItems.Add("检查费");// 发票分类名称
                    lv.SubItems.Add("");//规格
                    lv.SubItems.Add("1");//常用量
                    lv.SubItems.Add("次");//单位
                    lv.SubItems.Add(dt.Rows[i]["totalmny"].ToString().Trim());//单价
                    lv.SubItems.Add("");//比例
                    lv.SubItems.Add("");//医保分类
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                if (m_objViewer.listView1.Items.Count > 0)
                {
                    m_objViewer.listView1.Items[0].Selected = true;
                }
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

        #region 查找手术项目
        /// <summary>
        /// 查找检验项目
        /// </summary>
        /// <param name="ID">查找内容</param>
        /// <param name="row">行号</param>
        public void m_mthFindOPSChargeByID(string ID, int row)
        {
            DataTable dt = null;
            string strTempPatientTypeID = "0001";
            if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
            {
                strTempPatientTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
            }
            long strRet = objSvc.m_mthFindOPSChargeByID(this.m_objViewer.m_cmbFind.Tag.ToString(), strFind + ID, strTempPatientTypeID, out dt, this.m_objViewer.LoginInfo.m_strEmpID);
            if (strRet > 0 && dt.Rows.Count > 0)
            {

                //				if(dt.Rows.Count==1)
                //				{
                //								
                //					m_mthFillDataGridByRow5(dt.Rows[0],row);
                //										
                //					//直接填充datagrid
                //				}
                //				else
                //				{
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
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                if (m_objViewer.listView1.Items.Count > 0)
                {
                    m_objViewer.listView1.Items[0].Selected = true;
                }
                m_objViewer.listView1.Select();
                m_objViewer.listView1.Focus();
                //填充listView
                //				}
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid5.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
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
                    ListViewItem lv = new ListViewItem(ID);//项目ID
                    lv.SubItems.Add(dt.Rows[i]["NAME_CHR"].ToString().Trim());//名称
                    lv.SubItems.Add(dt.Rows[i]["COMMNAME_VCHR"].ToString().Trim());//通用名称
                    lv.SubItems.Add(dt.Rows[i]["ENGNAME_VCHR"].ToString().Trim());// 英文名
                    lv.SubItems.Add("治疗费");// 发票分类名称
                    lv.SubItems.Add("");//规格
                    lv.SubItems.Add("1");//常用量
                    lv.SubItems.Add("次");//单位
                    lv.SubItems.Add(dt.Rows[i]["totalmny"].ToString().Trim());//单价
                    lv.SubItems.Add("");//比例
                    lv.SubItems.Add("");//医保分类
                    lv.Tag = dt.Rows[i];
                    m_objViewer.listView1.Items.Add(lv);
                }
                m_objViewer.listView1.Height = 175;
                m_objViewer.listView1.Visible = true;
                if (m_objViewer.listView1.Items.Count > 0)
                {
                    m_objViewer.listView1.Items[0].Selected = true;
                }
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
            string strTempPatientTypeID = "0001";
            if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
            {
                strTempPatientTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
            }
            long strRet = objSvc.m_mthFindOtherChargeByID(this.m_objViewer.m_cmbFind.Tag.ToString(), strFind + ID, strTempPatientTypeID, out dt, this.m_objViewer.LoginInfo.m_strEmpID);
            if (strRet > 0 && dt.Rows.Count > 0)
            {
                //				if(dt.Rows.Count==1)
                //				{
                //						
                //					m_mthFillDataGridByRow6(dt.Rows[0],row);
                //										
                //					//直接填充datagrid
                //				}
                //				else
                //				{
                m_objViewer.listView1.Items.Clear();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //东莞门诊医保
                    if (!YBIsShowSelfItem && IsDongGuanYBPatient)
                    {
                        if (dt.Rows[i]["precent_dec"].ToString().Trim() == "100")
                        {
                            continue;
                        }
                    }

                    ListViewItem lv = new ListViewItem(dt.Rows[i]["TYPE"].ToString().Trim());//项目ID
                    //						lv.SubItems.Add(dt.Rows[i]["ITEMCODE_VCHR"].ToString().Trim());//查询码
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
                if (m_objViewer.listView1.Items.Count > 0)
                {
                    m_objViewer.listView1.Items[0].Selected = true;
                }
                m_objViewer.listView1.Select();
                m_objViewer.listView1.Focus();
                //填充listView
                //				}
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid6.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            rowNo = row;
        }
        #endregion

        #region listViewKeyDown处理
        public void m_mthListViewKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            switch (this.m_objViewer.tabControl1.SelectedIndex)
            {
                case 3:
                    m_mthKeyDown1(e);
                    break;
                case 4:
                    m_mthKeyDown2(e);
                    break;
                case 5:
                    m_mthKeyDown3(e);
                    break;
                case 6:
                    m_mthKeyDown4(e);
                    break;
                case 7:
                    m_mthKeyDown5(e);
                    break;
                case 8:
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
                //				SendKeys.SendWait("{Right}");
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
                if (ItemInputMode == 0)
                {
                    this.m_objViewer.ctlDataGrid3.Select();
                    this.m_objViewer.ctlDataGrid3.Focus();
                    this.m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, 0);
                }
                else if (ItemInputMode == 1)
                {
                    this.m_objViewer.ctlDataGridLis.Select();
                    this.m_objViewer.ctlDataGridLis.Focus();
                    this.m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGridLis.CurrentCell.RowNumber, 0);
                }
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
                if (ItemInputMode == 0)
                {
                    this.m_objViewer.ctlDataGrid4.Select();
                    this.m_objViewer.ctlDataGrid4.Focus();
                    this.m_objViewer.ctlDataGrid4.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, 0);
                }
                else if (ItemInputMode == 1)
                {
                    this.m_objViewer.ctlDataGridTest.Select();
                    this.m_objViewer.ctlDataGridTest.Focus();
                    this.m_objViewer.ctlDataGridTest.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGridTest.CurrentCell.RowNumber, 0);
                }
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
                if (ItemInputMode == 0)
                {
                    this.m_objViewer.ctlDataGrid5.Select();
                    this.m_objViewer.ctlDataGrid5.Focus();
                    this.m_objViewer.ctlDataGrid5.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, 0);
                }
                else if (ItemInputMode == 1)
                {
                    this.m_objViewer.ctlDataGridOps.Select();
                    this.m_objViewer.ctlDataGridOps.Focus();
                    this.m_objViewer.ctlDataGridOps.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGridOps.CurrentCell.RowNumber, 0);
                }
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

                if (TabPageName == "tabPage5")
                {
                    string strChrgCode = this.m_objViewer.listView1.SelectedItems[0].SubItems[12].Text;
                    if (strChrgCode != null && strChrgCode != "")
                    {
                        int index = int.Parse(strChrgCode) + 2;
                        this.m_objViewer.tabControl1.SelectedIndex = index;
                    }
                }
                switch (TabPageName)
                {
                    case "tabPage5":
                        m_mthDoubleClick1();
                        break;
                    case "tabPage6":
                        m_mthDoubleClick2();
                        break;
                    case "tabPage7":
                        m_mthDoubleClick3();
                        break;
                    case "tabPage8":
                        m_mthDoubleClick4();
                        break;
                    case "tabPage9":
                        m_mthDoubleClick5();
                        break;
                    case "tabPage10":
                        m_mthDoubleClick6();
                        break;
                }
                this.m_mthCalculateTotalMoney();
            }
        }
        private void m_mthDoubleClick1()
        {
            int row = rowNo;
            if (m_objViewer.ctlDataGrid1[row, c_ItemID].ToString().Trim() != "")
            {
                this.m_objViewer.alertLight1.m_mthDeleteItem(m_objViewer.ctlDataGrid1[row, c_ItemID].ToString().Trim());
            }
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
            string key = row.ToString() + "->" + strCurrItem;

            if (this.hasMedPiece.ContainsKey(key))
            {
                this.hasMedPiece.Remove(key);
            }

            m_objViewer.ctlDataGrid1[row, c_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
            if (this.m_mthConvertObjToDecimal(this.m_objViewer.m_PatInfo.PatientAge) >= 12)
            {
                m_objViewer.ctlDataGrid1[row, c_Count] = dr["ADULTDOSAGE_DEC"].ToString().Trim();
            }
            else//儿童
            {
                m_objViewer.ctlDataGrid1[row, c_Count] = dr["CHILDDOSAGE_DEC"].ToString().Trim();
            }
            m_objViewer.ctlDataGrid1[row, c_Unit] = dr["DOSAGEUNIT_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_Name] = dr["ITEMNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_Spec] = dr["ITEMSPEC_VCHR"].ToString().Trim();

            m_objViewer.ctlDataGrid1[row, c_Price] = dr["SubMoney"].ToString().Trim();
            m_objViewer.ctlDataGrid1[row, c_intDiffUnitPrice] = dr["SUBTRADEMONEY"].ToString().Trim();// 项目批发价
            m_objViewer.ctlDataGrid1[row, c_BigUnit] = dr["ITEMIPUNIT_CHR"].ToString().Trim();
            if (dr["opchargeflg_int"].ToString().Trim() == "0")//判断大小单位
            {
                m_objViewer.ctlDataGrid1[row, c_Price] = dr["ITEMPRICE_MNY"].ToString().Trim();//大单价
                m_objViewer.ctlDataGrid1[row, c_BigUnit] = dr["ITEMOPUNIT_CHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, c_intDiffUnitPrice] = dr["TRADEPRICE_MNY"].ToString().Trim();// 项目单位批发价
            }

            if (!blMedicine9003(dr["ITEMID_CHR"].ToString().Trim()))
            {
                m_objViewer.ctlDataGrid1[row, c_intDiffUnitPrice] = m_objViewer.ctlDataGrid1[row, c_Price];
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

                if (this.m_objViewer.ctlDataGrid1[row, c_DeptmedID].ToString().Trim() == "1")
                {
                    this.m_objViewer.ctlDataGrid1.m_mthSetRowColor(row, nfc, nbc);
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

            //按西药栏第一行项目药品属性自动指定处方类型
            if (row == 0)
            {
                this.m_mthSetRecipeType(row);
            }

            string strItemID = dr["ITEMID_CHR"].ToString().Trim();

            if (this.IsTabu)
            {
                m_mthFindTabuByID(dr["ITEMID_CHR"].ToString().Trim(), dr["ITEMNAME_VCHR"].ToString().Trim());
            }

            //自动添加用法频率
            if (this.m_mthAutoAddData(row))
            {
                string strSubItemID = this.m_objViewer.ctlDataGrid1[row, c_SubItemID].ToString().Trim();
                if (tempUsageID != "")//如果不为空时更新附加项目
                {
                    if (tempUsageID != dr["USAGEID_CHR"].ToString().Trim() && strSubItemID.StartsWith("[PK]"))//如果用法ID与原来的相同不作处理
                    {
                        m_mthGetChargeItemByUsageID(m_objViewer.ctlDataGrid1[row, c_UsageID].ToString().Trim(), true, strSubItemID.Replace("[PK]", ""), row);
                        m_mthGetChargeItemByUsageID(dr["USAGEID_CHR"].ToString().Trim(), false, strSubItemID.Replace("[PK]", ""), row);
                    }
                }
                else//判断原来没有用法ID的直接添加
                {
                    if (dr["USAGEID_CHR"].ToString().Trim() != "" && strItemID != "")
                    {
                        m_objViewer.ctlDataGrid1[row, c_SubItemID] = "[PK]" + row.ToString() + "->" + strItemID;
                        m_mthGetChargeItemByUsageID(dr["USAGEID_CHR"].ToString().Trim(), false, row.ToString() + "->" + strItemID, row);
                    }
                }
            }

            // xiong
            //自动调出关联的子收费项目			
            if (strCurrItem != strItemID)
            {
                string strReItemID = m_objViewer.ctlDataGrid1[row, c_resubitem].ToString().Trim();
                DataTable dtRecord = new DataTable();
                bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                if (strReItemID.StartsWith("[PK]"))
                {
                    m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                m_objViewer.ctlDataGrid1[row, c_resubitem] = "";
                m_objViewer.ctlDataGrid1[row, c_MainItemNum] = 0;

                if (blnStat)
                {
                    m_mthGetChargeItemByItem(row.ToString() + "->" + strItemID, 0, dtRecord);
                    m_objViewer.ctlDataGrid1[row, c_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                    m_objViewer.ctlDataGrid1[row, c_MainItemNum] = m_objViewer.ctlDataGrid1[row, c_Count];
                }
            }
            //显示药典备注
            this.m_mthCodexRemarkInfo(strItemID, 1);

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Count);
            m_objViewer.ctlDataGrid1[row, c_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();

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
            if (this.m_mthConvertObjToDecimal(this.m_objViewer.m_PatInfo.PatientAge) >= 12)
            {
                m_objViewer.ctlDataGrid2[row, 1] = dr["ADULTDOSAGE_DEC"].ToString().Trim();
                m_objViewer.ctlDataGrid2[row, 11] = dr["ADULTDOSAGE_DEC"].ToString().Trim();
            }
            else//儿童
            {
                m_objViewer.ctlDataGrid2[row, 1] = dr["CHILDDOSAGE_DEC"].ToString().Trim();
                m_objViewer.ctlDataGrid2[row, 11] = dr["CHILDDOSAGE_DEC"].ToString().Trim();
            }
            //  m_objViewer.ctlDataGrid2[row, 2] = dr["DOSAGEUNIT_CHR"].ToString().Trim();
            //中药需要显示门诊收费单位，而不是剂量单位 
            m_objViewer.ctlDataGrid2[row, 2] = dr["itemipunit_chr"].ToString().Trim();//itemipunit_chr
            m_objViewer.ctlDataGrid2[row, 3] = dr["ITEMNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 4] = dr["ITEMSPEC_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 5] = dr["usagename_vchr"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 6] = dr["SubMoney"].ToString().Trim();
            m_objViewer.ctlDataGrid2[row, 31] = dr["SUBTRADEMONEY"].ToString().Trim();// 单位批发价
            m_objViewer.ctlDataGrid2[row, 32] = dr["TRADEPRICE_MNY"].ToString().Trim();// 大批发价
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
                //显示药典备注
                this.m_mthCodexRemarkInfo(dr["ITEMID_CHR"].ToString().Trim(), 2);

                m_objViewer.listView1.Height = 0;
                m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(row, 1);
                m_objViewer.ctlDataGrid2[row, 0] = dr["ITEMCODE_VCHR"].ToString().Trim();

                if (this.m_objViewer.ctlDataGrid2[row, cm_DeptmedID].ToString().Trim() == "1")
                {
                    this.m_objViewer.ctlDataGrid2.m_mthSetRowColor(row, nfc, nbc);
                }
                this.m_objViewer.ctlDataGrid2[row, cm_Deptmed] = "";
                this.m_objViewer.ctlDataGrid2[row, cm_DeptmedID] = "";
                if (dr["DEPTPREP_INT"].ToString() != "1")
                {
                    this.m_objViewer.ctlDataGrid2[row, cm_DeptmedID] = "*";  //不允许科室自备                   
                }
            }
            catch
            {
            }
        }
        private void m_mthDoubleClick3()
        {
            int row = rowNo;
            DataRow dr = (DataRow)m_objViewer.listView1.SelectedItems[0].Tag;

            if (ItemInputMode == 0)
            {
                m_mthFillDataGridByRow3(dr, row);
            }
            else if (ItemInputMode == 1)
            {
                m_mthFillDataGridByRowLis(dr, row);
            }
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

            //自动调出关联的子收费项目
            string strItemID = dr["ORDERDICID_CHR"].ToString().Trim();
            if (strCurrItem != strItemID)
            {
                string StypeID = dr["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                string strReItemID = m_objViewer.ctlDataGridLis[row, t_resubitem].ToString().Trim();

                string PayTypeID = "0001";
                if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
                {
                    PayTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
                }

                decimal decScale = 1;
                bool blnCheckDiscount = false;
                if (IsAllowDiscount)
                {
                    blnCheckDiscount = this.objSvc.m_blnCheckOrderDiscount(strItemID, DiscountInvoCatArr, 1, DiscountItemNus);
                    if (blnCheckDiscount)
                    {
                        decScale = DiscountScale / 100;
                    }
                }

                decimal TotalMny = 0;
                decimal SbMny = 0;
                DataTable dtRecord;
                long l = this.objSvc.m_lngGetChargeItemByOrderID(strItemID, PayTypeID, out dtRecord);
                if (strReItemID.StartsWith("[PK]"))
                {
                    m_mthGetChargeItemByOrderItem(strReItemID.Replace("[PK]", ""), "", "", -1, null, "lis", out TotalMny, out SbMny, 1, 0);
                    this.hasOrderID.Remove("lis->" + strReItemID.Replace("[PK]", ""));
                }

                m_objViewer.ctlDataGridLis[row, t_resubitem] = "";
                m_objViewer.ctlDataGridLis[row, t_MainItemNum] = 0;

                if (l > 0 && dtRecord.Rows.Count > 0)
                {
                    m_mthGetChargeItemByOrderItem(row.ToString() + "->" + strItemID, dr["itemid_chr"].ToString(), dr["usageid_chr"].ToString(), 0, dtRecord, "lis", out TotalMny, out SbMny, decScale, 1);
                    m_objViewer.ctlDataGridLis[row, t_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                    m_objViewer.ctlDataGridLis[row, t_MainItemNum] = m_objViewer.ctlDataGridLis[row, t_Count];

                    //修改为折上折比例
                    if (decScale != 1)
                    {
                        for (int i = 0; i < dtRecord.Rows.Count; i++)
                        {
                            dtRecord.Rows[i]["precent_dec"] = m_mthConvertObjToDecimal(dtRecord.Rows[i]["precent_dec"]) * decScale;
                        }
                    }

                    clsOrder_VO Order_VO = new clsOrder_VO();
                    Order_VO.OrderDR = dr;
                    Order_VO.EntryDT = dtRecord;
                    hasOrderID.Add("lis->" + row.ToString() + "->" + strItemID, Order_VO);

                    m_objViewer.ctlDataGridLis[row, t_Price] = TotalMny.ToString();
                    m_objViewer.ctlDataGridLis[row, t_SumMoney] = SbMny.ToString();
                    if (TotalMny != SbMny)
                    {
                        m_objViewer.ctlDataGridLis[row, t_DiscountName] = "打折";
                    }
                    m_objViewer.ctlDataGridLis[row, t_Discount] = SbMny; //记录基数金额
                }
            }

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(row, t_Count);

        }
        private void m_mthFillDataGridByRow3(DataRow dr, int row)
        {
            string strCurrItem = m_objViewer.ctlDataGrid3[row, t_ItemID].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_Name] = dr["ITEMNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_Spec] = dr["ITEMSPEC_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_PartName] = dr["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_Unit] = dr["ITEMOPUNIT_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_Price] = dr["ITEMPRICE_MNY"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_ItemID] = dr["ITEMID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_PriceFlag] = dr["SELFDEFINE_INT"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_DiscountName] = dr["PRECENT_DEC"].ToString().Trim() + "%";//比例
            m_objViewer.ctlDataGrid3[row, t_Discount] = dr["PRECENT_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_EnglishName] = dr["ITEMENGNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_Temp] = dr["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid3[row, t_Count] = 1;

            //自动调出关联的子收费项目
            string strItemID = dr["ITEMID_CHR"].ToString().Trim();
            if (strCurrItem != strItemID)
            {
                string StypeID = dr["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                string strReItemID = m_objViewer.ctlDataGrid3[row, t_resubitem].ToString().Trim();
                DataTable dtRecord = new DataTable();
                bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                if (strReItemID.StartsWith("[PK]"))
                {
                    m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                m_objViewer.ctlDataGrid3[row, t_resubitem] = "";
                m_objViewer.ctlDataGrid3[row, t_MainItemNum] = 0;

                if (blnStat)
                {
                    m_mthGetChargeItemByItem(row.ToString() + "->" + strItemID, 0, dtRecord);
                    m_objViewer.ctlDataGrid3[row, t_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                    m_objViewer.ctlDataGrid3[row, t_MainItemNum] = m_objViewer.ctlDataGrid3[row, t_Count];
                }
            }

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(row, t_Count);
            m_mthAddItemToCulateClass(row, 3);
        }
        private void m_mthDoubleClick4()
        {
            int row = rowNo;
            DataRow dr = (DataRow)m_objViewer.listView1.SelectedItems[0].Tag;

            if (ItemInputMode == 0)
            {
                m_mthFillDataGridByRow4(dr, row);
            }
            else if (ItemInputMode == 1)
            {
                m_mthFillDataGridByRowTest(dr, row);
            }
        }

        private void m_mthFillDataGridByRow4(DataRow dr, int row)
        {
            string strCurrItem = m_objViewer.ctlDataGrid4[row, t_ItemID].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_Name] = dr["ITEMNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_Spec] = dr["ITEMSPEC_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_PartName] = dr["partname"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_Unit] = dr["ITEMOPUNIT_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_Price] = dr["ITEMPRICE_MNY"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_ItemID] = dr["ITEMID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_PriceFlag] = dr["SELFDEFINE_INT"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_DiscountName] = dr["PRECENT_DEC"].ToString().Trim() + "%";//比例
            m_objViewer.ctlDataGrid4[row, t_Discount] = dr["PRECENT_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_EnglishName] = dr["ITEMENGNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_Temp] = dr["itemchecktype_chr"].ToString().Trim();
            m_objViewer.ctlDataGrid4[row, t_Count] = 1;
            m_objViewer.ctlDataGrid4[row, t_UsageID] = dr["usageid_chr"].ToString().Trim();

            //自动调出关联的子收费项目
            string strItemID = dr["ITEMID_CHR"].ToString().Trim();
            if (strCurrItem != strItemID)
            {
                string strReItemID = m_objViewer.ctlDataGrid4[row, t_resubitem].ToString().Trim();
                DataTable dtRecord = new DataTable();
                bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                if (strReItemID.StartsWith("[PK]"))
                {
                    m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                m_objViewer.ctlDataGrid4[row, t_resubitem] = "";
                m_objViewer.ctlDataGrid4[row, t_MainItemNum] = 0;

                if (blnStat)
                {
                    m_mthGetChargeItemByItem(row.ToString() + "->" + strItemID, 0, dtRecord);
                    m_objViewer.ctlDataGrid4[row, t_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                    m_objViewer.ctlDataGrid4[row, t_MainItemNum] = m_objViewer.ctlDataGrid4[row, t_Count];
                }
            }

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGrid4.CurrentCell = new DataGridCell(row, t_Count);
            m_mthAddItemToCulateClass(row, 4);
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

            //自动调出关联的子收费项目
            string strItemID = dr["ORDERDICID_CHR"].ToString().Trim();
            if (strCurrItem != strItemID)
            {
                string strReItemID = m_objViewer.ctlDataGridTest[row, t_resubitem].ToString().Trim();
                string PayTypeID = "0001";
                if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
                {
                    PayTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
                }

                decimal TotalMny = 0;
                decimal SbMny = 0;
                DataTable dtRecord;
                long l = this.objSvc.m_lngGetChargeItemByOrderID(strItemID, PayTypeID, out dtRecord);
                if (strReItemID.StartsWith("[PK]"))
                {
                    m_mthGetChargeItemByOrderItem(strReItemID.Replace("[PK]", ""), null, null, -1, null, "test", out TotalMny, out SbMny, 1, 0);
                    this.hasOrderID.Remove("test->" + strReItemID.Replace("[PK]", ""));
                }

                m_objViewer.ctlDataGridTest[row, t_resubitem] = "";
                m_objViewer.ctlDataGridTest[row, t_MainItemNum] = 0;

                if (l > 0 && dtRecord.Rows.Count > 0)
                {
                    m_mthGetChargeItemByOrderItem(row.ToString() + "->" + strItemID, dr["itemid_chr"].ToString(), dr["usageid_chr"].ToString(), 0, dtRecord, "test", out TotalMny, out SbMny, 1, 1);
                    m_objViewer.ctlDataGridTest[row, t_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                    m_objViewer.ctlDataGridTest[row, t_MainItemNum] = m_objViewer.ctlDataGridTest[row, t_Count];

                    clsOrder_VO Order_VO = new clsOrder_VO();
                    Order_VO.OrderDR = dr;
                    Order_VO.EntryDT = dtRecord;
                    hasOrderID.Add("test->" + row.ToString() + "->" + strItemID, Order_VO);

                    m_objViewer.ctlDataGridTest[row, t_Price] = TotalMny.ToString();
                    m_objViewer.ctlDataGridTest[row, t_SumMoney] = SbMny.ToString();
                    if (TotalMny != SbMny)
                    {
                        m_objViewer.ctlDataGridTest[row, t_DiscountName] = "打折";
                    }
                    m_objViewer.ctlDataGridTest[row, t_Discount] = SbMny;
                }
            }

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGridTest.CurrentCell = new DataGridCell(row, t_Count);
        }

        private void m_mthDoubleClick5()
        {
            int row = rowNo;
            DataRow dr = (DataRow)m_objViewer.listView1.SelectedItems[0].Tag;

            if (ItemInputMode == 0)
            {
                m_mthFillDataGridByRow5(dr, row);
            }
            else if (ItemInputMode == 1)
            {
                m_mthFillDataGridByRowOps(dr, row);
            }
        }

        private void m_mthFillDataGridByRow5(DataRow dr, int row)
        {
            string strCurrItem = m_objViewer.ctlDataGrid5[row, o_ItemID].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_Name] = dr["ITEMNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_Spec] = dr["ITEMSPEC_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_Unit] = dr["ITEMOPUNIT_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_Price] = dr["ITEMPRICE_MNY"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_ItemID] = dr["ITEMID_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_PriceFlag] = dr["SELFDEFINE_INT"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_DiscountName] = dr["PRECENT_DEC"].ToString().Trim() + "%";//比例
            m_objViewer.ctlDataGrid5[row, o_Discount] = dr["PRECENT_DEC"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_EnglishName] = dr["ITEMENGNAME_VCHR"].ToString().Trim();
            m_objViewer.ctlDataGrid5[row, o_Count] = 1;
            m_objViewer.ctlDataGrid5[row, o_UsageID] = dr["usageid_chr"].ToString().Trim();

            //自动调出关联的子收费项目
            string strItemID = dr["ITEMID_CHR"].ToString().Trim();
            if (strCurrItem != strItemID)
            {
                string strReItemID = m_objViewer.ctlDataGrid5[row, o_resubitem].ToString().Trim();
                DataTable dtRecord = new DataTable();
                bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                if (strReItemID.StartsWith("[PK]"))
                {
                    m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                m_objViewer.ctlDataGrid5[row, o_resubitem] = "";
                m_objViewer.ctlDataGrid5[row, o_MainItemNum] = 0;

                if (blnStat)
                {
                    m_mthGetChargeItemByItem(row.ToString() + "->" + strItemID, 0, dtRecord);
                    m_objViewer.ctlDataGrid5[row, o_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                    m_objViewer.ctlDataGrid5[row, o_MainItemNum] = m_objViewer.ctlDataGrid5[row, o_Count];
                }
            }

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGrid5.CurrentCell = new DataGridCell(row, o_Count);
            m_mthAddItemToCulateClass(row, 5);
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

            //自动调出诊疗项目-收费项目
            string strItemID = dr["ORDERDICID_CHR"].ToString().Trim();
            if (strCurrItem != strItemID)
            {
                string strReItemID = m_objViewer.ctlDataGridOps[row, o_resubitem].ToString().Trim();
                string PayTypeID = "0001";
                if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
                {
                    PayTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
                }

                decimal TotalMny = 0;
                decimal SbMny = 0;
                DataTable dtRecord;
                long l = this.objSvc.m_lngGetChargeItemByOrderID(strItemID, PayTypeID, out dtRecord);
                if (strReItemID.StartsWith("[PK]"))
                {
                    m_mthGetChargeItemByOrderItem(strReItemID.Replace("[PK]", ""), null, null, -1, null, "ops", out TotalMny, out SbMny, 1, 0);
                    this.hasOrderID.Remove("ops->" + strReItemID.Replace("[PK]", ""));
                }

                m_objViewer.ctlDataGridOps[row, o_resubitem] = "";
                m_objViewer.ctlDataGridOps[row, o_MainItemNum] = 0;

                if (l > 0 && dtRecord.Rows.Count > 0)
                {
                    m_mthGetChargeItemByOrderItem(row.ToString() + "->" + strItemID, dr["itemid_chr"].ToString(), dr["usageid_chr"].ToString(), 0, dtRecord, "ops", out TotalMny, out SbMny, 1, 1);
                    m_objViewer.ctlDataGridOps[row, o_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                    m_objViewer.ctlDataGridOps[row, o_MainItemNum] = m_objViewer.ctlDataGridOps[row, o_Count];

                    clsOrder_VO Order_VO = new clsOrder_VO();
                    Order_VO.OrderDR = dr;
                    Order_VO.EntryDT = dtRecord;
                    hasOrderID.Add("ops->" + row.ToString() + "->" + strItemID, Order_VO);

                    m_objViewer.ctlDataGridOps[row, o_Price] = TotalMny.ToString();
                    m_objViewer.ctlDataGridOps[row, o_SumMoney] = SbMny.ToString();
                    if (TotalMny != SbMny)
                    {
                        m_objViewer.ctlDataGridOps[row, o_DiscountName] = "打折";
                    }
                    m_objViewer.ctlDataGridOps[row, o_Discount] = SbMny; //记录基数金额
                }
            }

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

            if (this.m_objViewer.ctlDataGrid6[row, o_DeptmedID].ToString().Trim() == "1")
            {
                this.m_objViewer.ctlDataGrid6.m_mthSetRowColor(row, nfc, nbc);
            }
            this.m_objViewer.ctlDataGrid6[row, o_Deptmed] = "";
            this.m_objViewer.ctlDataGrid6[row, o_DeptmedID] = "";
            if (dr["DEPTPREP_INT"].ToString() != "1")
            {
                this.m_objViewer.ctlDataGrid6[row, o_DeptmedID] = "*";  //不允许科室自备                   
            }

            //自动调出关联的子收费项目
            string strItemID = dr["ITEMID_CHR"].ToString().Trim();
            if (strCurrItem != strItemID)
            {
                string strReItemID = m_objViewer.ctlDataGrid6[row, o_resubitem].ToString().Trim();
                DataTable dtRecord = new DataTable();
                bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                if (strReItemID.StartsWith("[PK]"))
                {
                    m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                }

                m_objViewer.ctlDataGrid6[row, o_resubitem] = "";
                m_objViewer.ctlDataGrid6[row, o_MainItemNum] = 0;

                if (blnStat)
                {
                    m_mthGetChargeItemByItem(row.ToString() + "->" + strItemID, 0, dtRecord);
                    m_objViewer.ctlDataGrid6[row, o_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                    m_objViewer.ctlDataGrid6[row, o_MainItemNum] = m_objViewer.ctlDataGrid6[row, o_Count];
                }
            }

            m_objViewer.listView1.Height = 0;
            m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(row, o_Count);
            m_mthAddItemToCulateClass(row, 6);
        }
        #endregion

        #region 计数总额
        public void m_mthCalculateTotalMoney()
        {
            //修改
            decimal temp = 0, dmlDifftemp = 0;

            //西药
            decimal decTotalMoney = 0;
            for (int i = 0; i < m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (m_objViewer.ctlDataGrid1[i, c_RowNo].ToString() != "")
                {
                    temp = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[i, c_Price]) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[i, c_Total]);
                    temp = m_mthConvertObjToDecimal(temp.ToString("0.00"));
                    m_objViewer.ctlDataGrid1[i, c_SumMoney] = temp;

                    // 总差价计算
                    dmlDifftemp = (m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[i, c_intDiffUnitPrice]) - m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[i, c_Price])) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[i, c_Total]);
                    dmlDifftemp = m_mthConvertObjToDecimal(dmlDifftemp.ToString("0.00"));
                    m_objViewer.ctlDataGrid1[i, c_intDiffPrice] = dmlDifftemp;
                }
                else
                {
                    continue;
                }
                decTotalMoney += temp;
            }
            //显示西药总额
            if (decTotalMoney != 0)
            {
                this.m_objViewer.AA.Text = decTotalMoney.ToString("0.00");
            }
            else
            {
                this.m_objViewer.AA.Text = "";
            }

            //中药
            decTotalMoney = 0; dmlDifftemp = 0;
            for (int i = 0; i < m_objViewer.ctlDataGrid2.RowCount; i++)
            {
                if (m_objViewer.ctlDataGrid2[i, 9].ToString() != "")
                {
                    if (m_objViewer.ctlDataGrid2[i, 17].ToString().Trim() == "1")
                    {
                        temp = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 6]) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 15]);
                        dmlDifftemp = (m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 31]) - m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 6])) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 15]);// 总让利金额
                    }
                    else
                    {
                        temp = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 16]) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 15]);
                        dmlDifftemp = (m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 32]) - m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 16])) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 15]);// 总让利金额
                    }

                    temp = m_mthConvertObjToDecimal(temp.ToString("0.00"));
                    dmlDifftemp = m_mthConvertObjToDecimal(dmlDifftemp.ToString("0.00"));
                    m_objViewer.ctlDataGrid2[i, 7] = temp;
                    m_objViewer.ctlDataGrid2[i, 30] = dmlDifftemp;// 总让利金额
                }
                else
                {
                    continue;
                }
                decTotalMoney += temp;
            }
            //显示中药总额
            if (decTotalMoney != 0)
            {
                this.m_objViewer.BB.Text = decTotalMoney.ToString("0.00");
            }
            else
            {
                this.m_objViewer.BB.Text = "";
            }

            //检验
            decTotalMoney = 0;
            for (int i = 0; i < m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                if (m_objViewer.ctlDataGrid3[i, t_RowNo].ToString() != "")
                {
                    temp = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid3[i, t_Count]) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid3[i, t_Price]);
                    temp = m_mthConvertObjToDecimal(temp.ToString("0.00"));
                    m_objViewer.ctlDataGrid3[i, t_SumMoney] = temp;
                }
                else
                {
                    continue;
                }
                decTotalMoney += temp;
            }
            if (decTotalMoney != 0)
            {
                this.m_objViewer.CC.Text = decTotalMoney.ToString("0.00");
            }
            else
            {
                this.m_objViewer.CC.Text = "";
            }

            //检查
            decTotalMoney = 0;
            for (int i = 0; i < m_objViewer.ctlDataGrid4.RowCount; i++)
            {
                if (m_objViewer.ctlDataGrid4[i, t_RowNo].ToString() != "")
                {
                    temp = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid4[i, t_Count]) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid4[i, t_Price]);
                    temp = m_mthConvertObjToDecimal(temp.ToString("0.00"));
                    m_objViewer.ctlDataGrid4[i, t_SumMoney] = temp;
                }
                else
                {
                    continue;
                }
                decTotalMoney += temp;
            }
            if (decTotalMoney != 0)
            {
                this.m_objViewer.DD.Text = decTotalMoney.ToString("0.00");
            }
            else
            {
                this.m_objViewer.DD.Text = "";
            }

            //手术
            decTotalMoney = 0;
            for (int i = 0; i < m_objViewer.ctlDataGrid5.RowCount; i++)
            {
                if (m_objViewer.ctlDataGrid5[i, o_RowNo].ToString() != "")
                {
                    temp = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid5[i, o_Count]) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid5[i, o_Price]);
                    temp = m_mthConvertObjToDecimal(temp.ToString("0.00"));
                    m_objViewer.ctlDataGrid5[i, o_SumMoney] = temp;
                }
                else
                {
                    continue;
                }
                decTotalMoney += temp;
            }
            if (decTotalMoney != 0)
            {
                this.m_objViewer.EE.Text = decTotalMoney.ToString("0.00");
            }
            else
            {
                this.m_objViewer.EE.Text = "";
            }

            //其他
            decTotalMoney = 0;
            for (int i = 0; i < m_objViewer.ctlDataGrid6.RowCount; i++)
            {
                if (m_objViewer.ctlDataGrid6[i, o_RowNo].ToString() != "")
                {
                    temp = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid6[i, o_Count]) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid6[i, o_Price]);
                    temp = m_mthConvertObjToDecimal(temp.ToString("0.00"));
                    m_objViewer.ctlDataGrid6[i, o_SumMoney] = temp;
                }
                else
                {
                    continue;
                }
                decTotalMoney += temp;
            }
            if (decTotalMoney != 0)
            {
                this.m_objViewer.FF.Text = decTotalMoney.ToString("0.00");
            }
            else
            {
                this.m_objViewer.FF.Text = "";
            }

            if (objCalPatientCharge != null)
            {
                //发票信息VO
                clsPatientChargeCal objPC = this.objCalPatientCharge.m_mthGetChargeTypeDetail();

                if (objPC.m_decTotalCost != 0)
                {
                    this.m_objViewer.lbeSumMoney.Text = objPC.m_decTotalCost.ToString();
                }
                else
                {
                    this.m_objViewer.lbeSumMoney.Text = "";
                }
                if (objPC.m_decChargeUpCost != 0)
                {
                    this.m_objViewer.lbeChargeUp.Text = objPC.m_decChargeUpCost.ToString();
                }
                else
                {
                    this.m_objViewer.lbeChargeUp.Text = "";
                }
                if (objPC.m_decPersonCost != 0)
                {
                    this.m_objViewer.lbeSelfPay.Text = objPC.m_decPersonCost.ToString();
                }
                else
                {
                    this.m_objViewer.lbeSelfPay.Text = "";
                }
                // 社保记账计算(具体计算方式写在计费类里 clsFoShan2.m_mthGetSumMoney())
                if (objPC.m_decSbPay != 0)
                {
                    this.m_objViewer.lbeSbAccPay.Text = objPC.m_decSbPay.ToString("0.00");
                }
                else
                {
                    this.m_objViewer.lbeSbAccPay.Text = "";
                }
                // 提交后加收提示
                if (this.m_objViewer.lbeFlag.Text == "4")
                {
                    // 补收诊金提示
                    if (this.m_objViewer.btSave.Tag != null)
                    {
                        ShowHospitalFee(this.m_objViewer.btSave.Tag.ToString().Trim());
                    }
                }
            }
        }
        #endregion

        #region 转换成数字
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

            if (!blnSub)
            {
                if (strUsageID != "" && m_objViewer.ctlDataGrid1[row, c_SubItemID].ToString().Trim() != "" && strSubItemID.StartsWith("[PK]"))
                {
                    if (strUsageID != m_objViewer.listView2.SelectedItems[0].SubItems[0].Text.Trim())
                    {
                        this.m_mthGetChargeItemByUsageID(strUsageID, true, strSubItemID.Replace("[PK]", ""), row);
                        this.m_mthGetChargeItemByUsageID(m_objViewer.listView2.SelectedItems[0].SubItems[0].Text.Trim(), false, strSubItemID.Replace("[PK]", ""), row);
                    }
                }
                else
                {
                    if (strUsageID == "" && strItemID != "")
                    {
                        m_objViewer.ctlDataGrid1[row, c_SubItemID] = "[PK]" + row.ToString() + "->" + strItemID;
                        m_mthGetChargeItemByUsageID(m_objViewer.listView2.SelectedItems[0].SubItems[0].Text.Trim(), false, row.ToString() + "->" + strItemID, row);
                    }
                }
            }
            //this.IsCalculateAmount=true;
            m_objViewer.listView2.Hide();
            m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_FreName);
            m_mthChangeUsage(row);
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
            //			this.IsCalculateAmount=true;
            m_objViewer.ctlDataGrid1[row, c_IsCal] = 1;
            m_objViewer.listView3.Hide();
            m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Day);
            m_mthChangeFrequency(row);
        }
        #endregion

        #region 查找用服频率(西药)
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
                    m_mthChangeFrequency(row);
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
                    if (!blnSub && strItemID != "")
                    {
                        if (m_objViewer.ctlDataGrid1[row, c_UsageID] != null && m_objViewer.ctlDataGrid1[row, c_UsageID].ToString().Trim() != "" && strSubItemID.StartsWith("[PK]"))//如果不为空时更新附加项目
                        {
                            if (m_objViewer.ctlDataGrid1[row, c_UsageID].ToString().Trim() != dt.Rows[0]["USAGEID_CHR"].ToString().Trim())//如果用法ID与原来的相同不作处理
                            {
                                m_mthGetChargeItemByUsageID(m_objViewer.ctlDataGrid1[row, c_UsageID].ToString().Trim(), true, strSubItemID.Replace("[PK]", ""), row);
                                m_mthGetChargeItemByUsageID(dt.Rows[0]["USAGEID_CHR"].ToString().Trim(), false, strSubItemID.Replace("[PK]", ""), row);
                            }
                        }
                        else//判断原来没有用法ID的直接添加
                        {
                            m_objViewer.ctlDataGrid1[row, c_SubItemID] = "[PK]" + row.ToString() + "->" + strItemID;
                            m_mthGetChargeItemByUsageID(dt.Rows[0]["USAGEID_CHR"].ToString().Trim(), false, row.ToString() + "->" + strItemID, row);
                        }
                    }
                    m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_FreName);
                    m_objViewer.ctlDataGrid1[row, c_UsageID] = dt.Rows[0]["USAGEID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, c_UsageName] = dt.Rows[0]["USAGENAME_VCHR"].ToString().Trim();
                    m_mthChangeUsage(row);
                    //直接填充datagrid
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
                m_mthChangeDay(temp);
            }
        }
        #endregion

        #region 方号回车
        /// <summary>
        /// 方号回车
        /// 西药处方要分组，一张处方可能有多组药。其中每组有一个主项目，主项目用黄色显示。
        /// 第一次输入不同的方号那个就是主项目，当再输入一个同方号的药品就认为依懒于主项目
        /// 其用法和频率，天数都要相同，而且不能让用户修改。用户不能修改主项目的方号，只能删除。
        /// 输入空字符和0则认为不处合这个药。
        /// </summary>
        /// <param name="str">方号</param>
        /// <param name="row">当前的行索引</param>
        /// <param name="strPre">原来的方号</param>
        /// <param name="flag">标志，如果正常回车就是0</param>
        public void m_mthSetRowNo(string str, int row, string strPre, int flag)
        {
            if (!str.Trim().Equals(strPre.Trim()) && this.m_objViewer.ctlDataGrid1[row, c_RowNo].ToString().Trim() != "")
            {
                if (this.m_objViewer.ctlDataGrid1[row, c_IsMain].ToString().Trim() == "-1")
                {
                    MessageBox.Show("对不起,组合的主项目不能更改方号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Find);
                    this.m_objViewer.ctlDataGrid1[row, c_GroupNo] = strPre;
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_GroupNo);
                    return;
                }
                else
                {
                    //更改方号
                    for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
                    {
                        if (str == this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim() && this.m_objViewer.ctlDataGrid1[i, c_IsMain].ToString().Trim() == "-1")
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_IsMain] = i;
                            this.m_mthAutoAddData(row);
                        }
                    }
                    this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -1;
                    m_mthFormatDataGrid();
                    m_mthShowOverLimit();
                }
            }
            //-4代表不组合,-1 主组合,其他存放父组合的行号
            if (str.Trim() == "" || str.Trim() == "0")
            {
                this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -4;//代表不组合
                if (flag == 0)
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Find);
                return;
            }
            else
            {
                if (row == 0)//如果在第一行，就把第一行赋值为-1（主组合）
                {
                    this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -1;//表示主组合
                    m_mthFormatDataGrid();
                    m_mthShowOverLimit();
                }
                else
                {
                    bool tmepFlag = false;
                    for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
                    {
                        if (i == row)
                        {
                            continue;
                        }
                        if (this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim() == str.Trim() && this.m_objViewer.ctlDataGrid1[i, c_IsMain].ToString().Trim() == "-1")
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_IsMain] = i;//把父组合的行号记录
                            break;
                        }
                        else
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -1;//表示主组合
                            m_mthFormatDataGrid();
                            tmepFlag = true;
                        }
                    }
                    if (tmepFlag && flag < 1)
                    {
                        m_mthShowOverLimit();
                    }
                }
                if (flag == 0)
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Find);
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
                bool blnMedPiece = false;
                string key = rowNo + "->" + ItemId;
                if (hasMedPiece.ContainsKey(key))
                {
                    blnMedPiece = hasMedPiece[key].ToString() == "T" ? true : false;
                }
                else
                {
                    //xiong
                    blnMedPiece = objSvc.m_blnCheckmedicament(ItemId);
                    hasMedPiece.Add(key, (blnMedPiece == true ? "T" : "F"));
                }

                if (blnMedPiece)
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

                //用法加收统一改变数量
                string strSubItem = m_objViewer.ctlDataGrid1[rowNo, c_SubItemID].ToString();
                if (strSubItem.StartsWith("[PK]"))
                {
                    m_mthChangeTimeForDefaultItem(strSubItem.Replace("[PK]", ""), Days * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_FreTimes]), rowNo, 0);
                }

                //附加项目统一改变数量
                string strReSubItem = m_objViewer.ctlDataGrid1[rowNo, c_resubitem].ToString();
                if (strReSubItem.StartsWith("[PK]"))
                {
                    m_mthChangeTimeForDefaultItem(strReSubItem.Replace("[PK]", ""), Days * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[rowNo, c_FreTimes]), rowNo, 1);
                }

                if ((iii > 0 && decSumCountTemp != iii) || (this.m_objViewer.ctlDataGrid1[rowNo, c_IsCal].ToString().Trim() == "0"))
                {
                    int row = 3000;
                    if (this.m_objViewer.ctlDataGrid1[rowNo, c_RowNo].ToString().Trim() != "")
                    {
                        row = int.Parse(m_objViewer.ctlDataGrid1[rowNo, c_RowNo].ToString().Trim());
                    }
                    decimal discount = 100;
                    if (m_objViewer.ctlDataGrid1[rowNo, c_Discount] != null && m_objViewer.ctlDataGrid1[rowNo, c_Discount].ToString().Trim() != "")
                    {
                        discount = Convert.ToDecimal(m_objViewer.ctlDataGrid1[rowNo, c_Discount].ToString().Trim());
                    }
                    string strInvoiceType = m_objViewer.ctlDataGrid1[rowNo, c_InvoiceType].ToString().Trim();
                    int intTemp = this.objCalPatientCharge.m_mthGetChargeIetmPrice(m_objViewer.ctlDataGrid1[rowNo, c_ItemID].ToString(), price, strInvoiceType, iii, row, discount, "", false);
                    this.m_objViewer.ctlDataGrid1[rowNo, c_RowNo] = intTemp;
                    //					objRowNoArr[rowNo]=intTemp;
                }
            }
            colNo = this.m_objViewer.ctlDataGrid1.CurrentCell.ColumnNumber;
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

            if (iii > 0)
            {

                int row = 3000;
                if (m_objViewer.ctlDataGrid1[p_intRow, c_RowNo] != null && m_objViewer.ctlDataGrid1[p_intRow, c_RowNo].ToString().Trim() != "" && m_objViewer.ctlDataGrid1[p_intRow, c_RowNo].ToString().Trim() != "-1")
                {
                    row = int.Parse(m_objViewer.ctlDataGrid1[p_intRow, c_RowNo].ToString().Trim());
                }
                decimal discount = 100;
                if (m_objViewer.ctlDataGrid1[p_intRow, c_Discount] != null && m_objViewer.ctlDataGrid1[p_intRow, c_Discount].ToString().Trim() != "")
                {
                    discount = Convert.ToDecimal(m_objViewer.ctlDataGrid1[p_intRow, c_Discount].ToString().Trim());
                }
                string strInvoiceType = m_objViewer.ctlDataGrid1[p_intRow, c_InvoiceType].ToString().Trim();
                this.m_objViewer.ctlDataGrid1[p_intRow, c_RowNo] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(m_objViewer.ctlDataGrid1[p_intRow, c_ItemID].ToString(), price, strInvoiceType, iii, row, discount, "", false);
                //					objRowNoArr[p_intRow]=int.Parse(this.m_objViewer.ctlDataGrid1[p_intRow,19].ToString());
                //在这里添加调用总额代码
            }
            colNo = this.m_objViewer.ctlDataGrid1.CurrentCell.ColumnNumber;

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
            double temp = (double)this.m_objViewer.numericUpDown1.Value * (double)m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[p_intRow, 1]);
            decimal iii = (decimal)Math.Ceiling(temp / (packet * d_Usage));
            this.m_objViewer.ctlDataGrid2[p_intRow, 15] = iii;

            decimal price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[p_intRow, 16]);
            decimal decDiffprice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[p_intRow, 33]);// 批发大单价
            if (m_objViewer.ctlDataGrid2[p_intRow, 17].ToString().Trim() == "1")
            {
                iii = (decimal)Math.Ceiling(temp / d_Usage);
                this.m_objViewer.ctlDataGrid2[p_intRow, 15] = iii;
                price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[p_intRow, 6]);
                decDiffprice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[p_intRow, 32]);// 批发单位单价
            }
            this.m_objViewer.ctlDataGrid2[p_intRow, 7] = iii * price;
            this.m_objViewer.ctlDataGrid2[p_intRow, 30] = iii * (price - decDiffprice);// 总差价
            if (iii > 0 && decSumCountTemp != iii)
            {
                int row = 3000;
                if (m_objViewer.ctlDataGrid2[p_intRow, 9] != null && m_objViewer.ctlDataGrid2[p_intRow, 9].ToString().Trim() != "" && m_objViewer.ctlDataGrid2[p_intRow, 9].ToString().Trim() != "-1")
                {
                    row = int.Parse(m_objViewer.ctlDataGrid2[p_intRow, 9].ToString().Trim());
                }
                decimal discount = 100;
                if (m_objViewer.ctlDataGrid2[p_intRow, 11] != null && m_objViewer.ctlDataGrid2[p_intRow, 11].ToString().Trim() != "")
                {
                    discount = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[p_intRow, 11].ToString().Trim());
                }
                string strInvoiceType = m_objViewer.ctlDataGrid2[rowNo, 20].ToString().Trim();
                this.m_objViewer.ctlDataGrid2[p_intRow, 9] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(m_objViewer.ctlDataGrid2[p_intRow, 8].ToString(), price, strInvoiceType, iii, row, discount, "", false);
                //在这里添加调用总额代码
            }


        }
        #endregion

        #region 控制列的跳转
        public void m_mthSetColNo1()
        {
            int col = this.m_objViewer.ctlDataGrid1.CurrentCell.ColumnNumber;
            int row = this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
            bool temp = false;
            if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, c_IsMain]) > -1)
            {
                temp = true;
            }
            if (temp)//这些组合中的子项目的跳转方法。
            {
                if (col > 2 && col < 13)//直接跳到总数
                {
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Total);
                }
                if (col > 13 && col < c_Deptmed)
                {
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Deptmed);
                }
                if (col > c_Deptmed)
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
                if (col > 13 && col < c_Deptmed)
                {
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Deptmed);
                }
                if (col > c_Deptmed)
                {
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row + 1, c_GroupNo);
                }
            }

            if (this.m_objViewer.ctlDataGrid1.CurrentCell.ColumnNumber != c_Deptmed)
            {
                this.m_objViewer.cboDeptmed1.Hide();
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
                this.m_objViewer.cboDeptmed2.Hide();
            }
        }
        public void m_mthSetColNo3()
        {
            int row = this.m_objViewer.ctlDataGrid3.CurrentCell.RowNumber;
            bool isCouPrice = this.m_objViewer.ctlDataGrid3[row, t_PriceFlag].ToString().Trim() == "0";
            if (this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber > t_Count && this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber < t_PartName)
            {
                this.m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(row, t_PartName);
                return;
            }
            if (isCouPrice)//如果不是自定义价格的就直接跟到下一行
            {
                if (this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber > t_PartName && this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber < t_quick)
                {
                    this.m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(row, t_quick);
                }
                else if (this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber > t_quick)
                {
                    this.m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(row + 1, t_Find);
                }
            }
            else//跳到单价
            {
                if (this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber > t_PartName && this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber < t_Price)
                {
                    this.m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(row, t_Price);
                }
                if (this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber > t_Price && this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber < t_quick)
                {
                    this.m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(row, t_quick);
                }
                else if (this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber > t_quick)
                {
                    this.m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(row + 1, 0);
                }

            }

            if (this.m_objViewer.ctlDataGrid3.CurrentCell.ColumnNumber != t_quick)
            {
                this.m_objViewer.cboquick.Hide();
            }
        }
        public void m_mthSetColNo4()
        {
            int row = this.m_objViewer.ctlDataGrid4.CurrentCell.RowNumber;
            bool isCouPrice = this.m_objViewer.ctlDataGrid4[row, t_PriceFlag].ToString().Trim() == "0";
            if (this.m_objViewer.ctlDataGrid4.CurrentCell.ColumnNumber > t_Count && this.m_objViewer.ctlDataGrid4.CurrentCell.ColumnNumber < t_PartName)
            {
                this.m_objViewer.ctlDataGrid4.CurrentCell = new DataGridCell(row, t_PartName);
                return;
            }
            if (isCouPrice)//如果不是自定义价格的就直接跟到下一行
            {
                if (this.m_objViewer.ctlDataGrid4.CurrentCell.ColumnNumber > t_PartName)
                {
                    this.m_objViewer.ctlDataGrid4.CurrentCell = new DataGridCell(row + 1, t_Find);
                }
            }
            else//跳到单价
            {
                if (this.m_objViewer.ctlDataGrid4.CurrentCell.ColumnNumber > t_PartName && this.m_objViewer.ctlDataGrid4.CurrentCell.ColumnNumber < t_Price)
                {
                    this.m_objViewer.ctlDataGrid4.CurrentCell = new DataGridCell(row, t_Price);
                }
                if (this.m_objViewer.ctlDataGrid4.CurrentCell.ColumnNumber > t_Price)
                {
                    this.m_objViewer.ctlDataGrid4.CurrentCell = new DataGridCell(row + 1, 0);
                }

            }
        }
        public void m_mthSetColNo5()
        {
            int row = this.m_objViewer.ctlDataGrid5.CurrentCell.RowNumber;
            bool isCouPrice = this.m_objViewer.ctlDataGrid5[row, o_PriceFlag].ToString().Trim() == "0";
            if (isCouPrice)//如果不是自定义价格的就直接跟到下一行
            {
                if (this.m_objViewer.ctlDataGrid5.CurrentCell.ColumnNumber > 1)
                {
                    this.m_objViewer.ctlDataGrid5.CurrentCell = new DataGridCell(row + 1, 0);
                }
            }
            else//跳到单价
            {
                if (this.m_objViewer.ctlDataGrid5.CurrentCell.ColumnNumber > o_Count && this.m_objViewer.ctlDataGrid5.CurrentCell.ColumnNumber < o_Price)
                {
                    this.m_objViewer.ctlDataGrid5.CurrentCell = new DataGridCell(row, o_Price);
                }
                if (this.m_objViewer.ctlDataGrid5.CurrentCell.ColumnNumber > o_Price)
                {
                    this.m_objViewer.ctlDataGrid5.CurrentCell = new DataGridCell(row + 1, 0);
                }

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
                this.m_objViewer.cboDeptmed6.Hide();
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
                this.m_objViewer.cboquick.Hide();
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

        #region 保存数据(没有统一事务，已经取消)

        #region
        /****************************
		public void m_mthSaveData()
		{
			if(this.m_objViewer.m_PatInfo.PatientID==null||this.m_objViewer.m_PatInfo.PatientID=="")
			{
				MessageBox.Show("请先输入病人信息才能保存!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.m_objViewer.m_PatInfo.txtCardID.Focus();
				return;
			}
			if(this.m_objViewer.m_PatInfo.DeptID.Trim()=="")
			{
				MessageBox.Show("请输入部门!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.m_objViewer.m_PatInfo.txtRegisterDept.Focus();
				return;
			}
			if(this.m_objViewer.m_PatInfo.DoctorID.Trim()=="")
			{
				MessageBox.Show("请选择医生!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.m_objViewer.m_PatInfo.txtRegisterDoctor.Focus();
				return;
			}
			 //把空DataGrid的空行去掉
			this.m_mthCheckCanSave();
			string strRecipeID="";
			if(this.m_objViewer.btSave.Tag==null||this.m_objViewer.btSave.Tag.ToString()=="")
			{
				
				long strRet=this.m_mthSaveMainRecipe(out strRecipeID);
				if(strRet<=0)
				{
					MessageBox.Show("对不起,保存信息失败。","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				this.m_objViewer.btSave.Tag=strRecipeID;
				this.m_mthSavePublicData(strRecipeID,true);
				this.m_mthSaveRecipeDetail(strRecipeID);
			}
			else//更新
			{
				long strRet=this.m_mthSaveMainRecipe(out strRecipeID);
				if(strRet<=0)
				{
					MessageBox.Show("对不起,保存信息失败。","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
					return;
				}
				this.m_mthSavePublicData(this.m_objViewer.btSave.Tag.ToString(),false);
				this.m_mthDeleteRecipeDetail(this.m_objViewer.btSave.Tag.ToString());
				this.m_mthSaveRecipeDetail(this.m_objViewer.btSave.Tag.ToString());
			}
			MessageBox.Show("保存成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.m_objViewer.lbeFlag.Text ="0";
		}
        ****************************/
        #endregion

        #region 保存数据(统一保存)
        /// <summary>
        /// 保存数据(统一保存)
        /// </summary>
        /// <returns>-2 病历、处方同时为空，不保存  -1 保存失败  0 成功</returns>
        public int m_mthSaveAllData()
        {
            int ret = -1;

            if (this.m_objViewer.m_PatInfo.PatientID == null || this.m_objViewer.m_PatInfo.PatientID == "")
            {
                MessageBox.Show("请先输入病人信息才能保存!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_PatInfo.txtCardID.Focus();
                return ret;
            }
            if (this.m_objViewer.m_PatInfo.DeptID.Trim() == "")
            {
                MessageBox.Show("请输入部门!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_PatInfo.txtRegisterDept.Focus();
                return ret;
            }
            if (this.m_objViewer.m_PatInfo.DoctorID.Trim() == "")
            {
                MessageBox.Show("请选择医生!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_PatInfo.txtRegisterDoctor.Focus();
                return ret;
            }

            //把空DataGrid的空行去掉
            this.m_mthCheckCanSave();

            #region 检查是否存在缺药项目
            if (HashItemNoStock != null && HashItemNoStock.Count > 0)
            {
                string ItemID = "";
                string msg = "";
                string Ent = "\r\n\r\n";
                //for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
                //{
                //    ItemID = this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString().Trim();
                //    if (HashItemNoStock.ContainsKey(ItemID))
                //    {
                //        msg += "西药栏第" + Convert.ToString(i + 1) + "行：【" + this.m_objViewer.ctlDataGrid1[i, c_Name].ToString().Trim() + "】缺药;" + Ent;
                //    }
                //}

                //for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
                //{
                //    ItemID = this.m_objViewer.ctlDataGrid2[i, 8].ToString().Trim();
                //    if (HashItemNoStock.ContainsKey(ItemID))
                //    {
                //        msg += "中药栏第" + Convert.ToString(i + 1) + "行：【" + this.m_objViewer.ctlDataGrid1[i, 3].ToString().Trim() + "】缺药;" + Ent;
                //    }
                //}

                if (msg != "")
                {
                    MessageBox.Show(msg, "缺药提示...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return ret;
                }
            }
            #endregion

            #region 项目调整修改检查
            if (HashItemCompare != null && HashItemCompare.Count > 0)
            {
                #region 判断
                string ItemID = "";
                string msg = "";
                string Ent = "\r\n\r\n";
                #region 西药
                for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
                {
                    ItemID = this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString().Trim();

                    clsItemCompare_VO ItemCompare_VO = HashItemCompare[ItemID] as clsItemCompare_VO;

                    if (ItemCompare_VO == null)
                    {
                        continue;
                    }

                    if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != this.m_objViewer.ctlDataGrid1[i, c_Spec].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的规格已变动，请重新录入！" + Ent;
                        }
                    }

                    if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != this.m_objViewer.ctlDataGrid1[i, c_Unit].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的剂量单位已变动，请重新录入！" + Ent;
                        }
                    }
                    //if (ItemCompare_VO.N_ItemPrice.ToString().Trim() != "")
                    //{
                    //    if (this.m_mthConvertObjToDecimal(ItemCompare_VO.N_ItemPrice) != this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Price]))
                    //    {
                    //        msg += "【" + ItemCompare_VO.ItemName + "】的单价已变动，请重新录入！" + Ent; 
                    //    }
                    //}
                }
                #endregion
                #region 中药
                for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
                {
                    ItemID = this.m_objViewer.ctlDataGrid2[i, 8].ToString().Trim();

                    clsItemCompare_VO ItemCompare_VO = HashItemCompare[ItemID] as clsItemCompare_VO;

                    if (ItemCompare_VO == null)
                    {
                        continue;
                    }

                    if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != this.m_objViewer.ctlDataGrid2[i, 4].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的规格已变动，请重新录入！" + Ent;
                        }
                    }

                    if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != this.m_objViewer.ctlDataGrid2[i, 2].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的单位已变动，请重新录入！" + Ent;
                        }
                    }

                    //if (ItemCompare_VO.N_ItemPrice.ToString().Trim() != "")
                    //{
                    //    if (this.m_mthConvertObjToDecimal(ItemCompare_VO.N_ItemPrice) != this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 6]))
                    //    {
                    //        msg += "【" + ItemCompare_VO.ItemName + "】的单价已变动，请重新录入！" + Ent;
                    //    }
                    //}               
                }
                #endregion
                #region 检验
                for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
                {
                    ItemID = this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim();

                    clsItemCompare_VO ItemCompare_VO = HashItemCompare[ItemID] as clsItemCompare_VO;

                    if (ItemCompare_VO == null)
                    {
                        continue;
                    }

                    if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != this.m_objViewer.ctlDataGrid3[i, t_Spec].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的规格已变动，请重新录入！" + Ent;
                        }
                    }
                    if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != this.m_objViewer.ctlDataGrid3[i, t_Unit].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的单位已变动，请重新录入！" + Ent;
                        }
                    }
                    //if (ItemCompare_VO.N_ItemPrice.ToString().Trim() != "")
                    //{
                    //    if (this.m_mthConvertObjToDecimal(ItemCompare_VO.N_ItemPrice) != this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Price]))
                    //    {
                    //        msg += "【" + ItemCompare_VO.ItemName + "】的单价已变动，请重新录入！" + Ent;  
                    //    }
                    //}
                }
                #endregion
                #region 检查
                for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
                {
                    ItemID = this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString().Trim();

                    clsItemCompare_VO ItemCompare_VO = HashItemCompare[ItemID] as clsItemCompare_VO;

                    if (ItemCompare_VO == null)
                    {
                        continue;
                    }

                    if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != this.m_objViewer.ctlDataGrid4[i, t_Spec].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的规格已变动，请重新录入！" + Ent;
                        }
                    }
                    if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != this.m_objViewer.ctlDataGrid4[i, t_Unit].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的单位已变动，请重新录入！" + Ent;
                        }
                    }
                    //if (ItemCompare_VO.N_ItemPrice.ToString().Trim() != "")
                    //{
                    //    if (this.m_mthConvertObjToDecimal(ItemCompare_VO.N_ItemPrice) != this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Price]))
                    //    {
                    //        msg += "【" + ItemCompare_VO.ItemName + "】的单价已变动，请重新录入！" + Ent; 
                    //    }
                    //}
                }
                #endregion
                #region 手术治疗
                for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
                {
                    ItemID = this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString().Trim();

                    clsItemCompare_VO ItemCompare_VO = HashItemCompare[ItemID] as clsItemCompare_VO;

                    if (ItemCompare_VO == null)
                    {
                        continue;
                    }

                    if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != this.m_objViewer.ctlDataGrid5[i, o_Spec].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的规格已变动，请重新录入！" + Ent;
                        }
                    }
                    if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != this.m_objViewer.ctlDataGrid5[i, o_Unit].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的单位已变动，请重新录入！" + Ent;
                        }
                    }
                    //if (ItemCompare_VO.N_ItemPrice.ToString().Trim() != "")
                    //{
                    //    if (this.m_mthConvertObjToDecimal(ItemCompare_VO.N_ItemPrice) != this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Price]))
                    //    {
                    //        msg += "【" + ItemCompare_VO.ItemName + "】的单价已变动，请重新录入！" + Ent;
                    //    }
                    //}
                }
                #endregion
                #region 其他
                for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
                {
                    ItemID = this.m_objViewer.ctlDataGrid6[i, o_ItemID].ToString().Trim();

                    clsItemCompare_VO ItemCompare_VO = HashItemCompare[ItemID] as clsItemCompare_VO;

                    if (ItemCompare_VO == null)
                    {
                        continue;
                    }

                    if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemStandard.ToString().Trim() != this.m_objViewer.ctlDataGrid6[i, o_Spec].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的规格已变动，请重新录入！" + Ent;
                        }
                    }
                    if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != "")
                    {
                        if (ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() != this.m_objViewer.ctlDataGrid6[i, o_Unit].ToString().Trim())
                        {
                            msg += "【" + ItemCompare_VO.ItemName + "】的单位已变动，请重新录入！" + Ent;
                        }
                    }
                    //if (ItemCompare_VO.N_ItemPrice.ToString().Trim() != "")
                    //{
                    //    if (this.m_mthConvertObjToDecimal(ItemCompare_VO.N_ItemPrice) != this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, o_Price]))
                    //    {
                    //        msg += "【" + ItemCompare_VO.ItemName + "】的单价已变动，请重新录入！" + Ent;
                    //    }
                    //}
                }
                #endregion

                if (msg != "")
                {
                    MessageBox.Show(msg, "请调整项目属性", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return ret;
                }
                #endregion
            }
            #endregion

            //检查病历的有效性 true： 有效；	false： 空病历
            bool blnCase = this.m_blnCheckCase();

            //检查处方的有效性 true： 有效；	false： 空处方
            bool blnRec = false;
            if (this.m_mthConvertObjToDecimal(this.m_objViewer.lbeSumMoney.Text) != 0)
            {
                blnRec = true;
            }

            //病历、处方同时为空，不保存
            if (!blnCase && !blnRec)
            {
                return -2;
            }

            #region 检查同一处方中是否含受限的不同药品类型
            if (this.m_blnCheckmedproperty())
            {
                return ret;
            }
            #endregion

            #region 检查同一处方中是否同时包含：普通、毒类、麻类、精神一和二类药品
            if (Medpurview == 2)
            {
                //检查同一处方中是否同时包含：普通、毒类、麻类、精神一和二类药品
                string typeid = "";
                if (this.m_blnCheckmedproperty(out typeid))
                {
                    return ret;
                }
                else
                {
                    if (typeid != "0")
                    {
                        SpeicalLimitRecipeID = SpeicalLimitRecipeID.Replace("；", ";").Trim();
                        if (SpeicalLimitRecipeID != "")
                        {
                            ArrayList RecipeIDArr = this.m_Gettoken(SpeicalLimitRecipeID, ";");
                            if (RecipeIDArr.IndexOf(typeid) >= 0)
                            {
                                if (this.m_objViewer.m_PatInfo.IDcard.Trim() == "" || this.m_objViewer.m_PatInfo.PatientHomeAddress.Trim() == "" || this.m_objViewer.m_PatInfo.PatientTelephoneNo.Trim() == "" || this.m_objViewer.objCaseHistory.txtDiag.Text.Trim() == "")
                                {
                                    string[] hintinfo = new string[5] { "普通", "毒性", "麻醉", "精神一类", "精神二类" };
                                    MessageBox.Show("该处方含" + hintinfo[int.Parse(typeid)] + "药僁，请通过Alt+C快捷方式补录患者的【身份证号】、【家庭住址】、【电话】以及病历中的【诊断信息】后然后保存处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return ret;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            #region 检查西药处方同一方号下用药频率是否相同
            if (m_objViewer.ctlDataGrid1.RowCount > 0)
            {
                for (int i = 0; i < m_objViewer.ctlDataGrid1.RowCount; i++)
                {
                    if (m_objViewer.ctlDataGrid1[i, "Column32"].ToString().Trim() != "")
                    {
                        string strCheckNum = m_objViewer.ctlDataGrid1[i, "Column32"].ToString();
                        string strFreq = m_objViewer.ctlDataGrid1[i, "Column15"].ToString();
                        for (int i1 = 0; i1 < m_objViewer.ctlDataGrid1.RowCount; i1++)
                        {
                            if (strCheckNum == m_objViewer.ctlDataGrid1[i1, "Column32"].ToString())
                            {
                                if (strFreq != m_objViewer.ctlDataGrid1[i1, "Column15"].ToString())
                                {
                                    MessageBox.Show("同一方号中存在用药频率不同的药品，请更改后保存！", "提示");
                                    return -1;
                                }
                            }
                        }
                    }
                }
            }
            #endregion

            string strRecipeID = "";
            lstDrug.Clear();

            //主处方信息		
            clsOutPatientRecipe_VO OPR_VO = null;
            this.m_mthGetMainRecipeData(out OPR_VO);

            //病历VO
            clsOutpatientCaseHis_VO CH_VO = null;
            this.m_mthGetCaseHistory(out CH_VO, "", "1");

            //0、诊断
            clsOutpatientDiagRec_VO DR_VO = null;
            //			this.m_mthGetDiagnoses(out DR_VO,"");
            //1、西药
            // clsOutpatientPWMRecipeDe_VO[] PWM_VO = null;
            m_objPutPWM_VO = null;
            if (!this.m_mthGetWMRecipeData(out m_objPutPWM_VO, ""))
            {
                return -1;
            }
            //2、中药
            //clsOutpatientCMRecipeDe_VO[] CM_VO = null;
            m_objPutCM_VO = null;
            if (!this.m_mthGetCMRecipeData(out m_objPutCM_VO, ""))
            {
                return -1;
            }
            //3、检验
            clsOutpatientCHKRecipeDe_VO[] CHK_VO = null;
            if (!this.m_mthGetTestRecipeData(out CHK_VO, ""))
            {
                return -1;
            }
            //4、检查
            clsOutpatientTestRecipeDe_VO[] TR_VO = null;
            if (!this.m_mthGetExamineRecipeData(out TR_VO, ""))
            {
                return -1;
            }
            //5、手术治疗
            clsOutpatientOPSRecipeDe_VO[] OP_VO = null;
            if (!this.m_mthGetOPRecipeData(out OP_VO, ""))
            {
                return -1;
            }
            //6、其他
            clsOutpatientOtherRecipeDe_VO[] Other_VO = null;
            if (!this.m_mthGetOtherRecipeData(out Other_VO, ""))
            {
                return -1;
            }
            //7、诊疗项目
            clsOutpatientOrderRecipeDe_VO[] Order_VO = null;
            if (!this.m_mthGetOrderRecipeData(out Order_VO, ""))
            {
                return -1;
            }

            //处方状态	 true 新建	false 更新
            bool IsModify = false;
            if (this.m_objViewer.btSave.Tag == null || this.m_objViewer.btSave.Tag.ToString() == "")
            {
                IsModify = true;
            }

            //病历状态	 true 新建	false 更新
            bool blnCashStatus = false;
            string strCaseHisID = this.m_objViewer.objCaseHistory.CaseHistoryID.Trim();
            if (strCaseHisID == "")
            {
                blnCashStatus = true;
            }

            if (blnRec)
            {
                // 合理用药接口
                int secuLevel = 0;
                //if (lstDrug.Count > 0 && this.IsUseMedItf && !this.IsRecipePut)   171227 调整，发现医生通过点结诊自动提交实现开超权限抗生素。
                if (lstDrug.Count > 0 && this.IsUseMedItf)
                {
                    using (Hisitf.RationalDrugUseItf itf = new Hisitf.RationalDrugUseItf())
                    {
                        if (itf.CheckDrugUse(1, this.DrugServiceUrl, GetDrugPatInfo(), lstDrug, ref secuLevel) == false)
                        {
                            return -1;
                        }
                        OPR_VO.SecuLevel = secuLevel;
                        this.m_objViewer.btPutIn.Tag = secuLevel;
                    }
                }
                if (this.IsRecipePut && this.m_objViewer.btPutIn.Tag != null)
                {
                    OPR_VO.SecuLevel = Convert.ToInt32(this.m_objViewer.btPutIn.Tag);
                }

                //blnCase: true 保存病历和处方； false 只保存处方
                long l = objSvc.m_mthSaveAllData(OPR_VO, CH_VO, DR_VO, m_objPutPWM_VO, m_objPutCM_VO, CHK_VO, TR_VO, OP_VO, Other_VO, Order_VO, out strRecipeID, out strCaseHisID, IsModify, blnCashStatus, blnCase);
                if (l > 0)
                {
                    if (IsShowMessageBox)
                    {
                        this.m_mthShowsavemsg("保存成功！");
                    }
                    IsShowMessageBox = true;
                    this.m_objViewer.btSave.Tag = strRecipeID;
                    this.m_objViewer.objCaseHistory.CaseHistoryID = strCaseHisID;
                    this.m_objViewer.lbeFlag.Text = "0";
                    ret = 0;
                }
                else
                {
                    MessageBox.Show("数据保存失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.m_objViewer.btSave.Tag = null;
                    ret = -1;
                }
                return ret;
            }

            //只保存病历			
            if (blnCase)
            {
                long lngRet = objSvc.m_lngSaveCaseHis(CH_VO, blnCashStatus, ref strCaseHisID);
                if (lngRet > 0)
                {
                    if (IsShowMessageBox)
                    {
                        this.m_mthShowsavemsg("保存成功！");
                    }
                    this.m_objViewer.objCaseHistory.CaseHistoryID = strCaseHisID;
                    ret = 0;
                }
                else
                {
                    ret = -1;
                    MessageBox.Show("保存病历资料失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }

            //释放检查项目缺药哈希表
            if (HashItemNoStock != null)
            {
                HashItemNoStock = null;
            }

            //释放项目检查哈希表
            if (HashItemCompare != null)
            {
                HashItemCompare = null;
            }

            return ret;
        }
        #endregion

        #region 检查保存条件
        private void m_mthCheckCanSave()
        {
            for (int i1 = this.m_objViewer.ctlDataGrid1.RowCount - 1; i1 >= 0; i1--)
            {
                if (this.m_objViewer.ctlDataGrid1[i1, c_ItemID] == null || this.m_objViewer.ctlDataGrid1[i1, c_ItemID].ToString() == "")
                {
                    this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i1);
                }
            }
            for (int i2 = this.m_objViewer.ctlDataGrid2.RowCount - 1; i2 >= 0; i2--)
            {
                if (this.m_objViewer.ctlDataGrid2[i2, 8] == null || this.m_objViewer.ctlDataGrid2[i2, 8].ToString() == "")
                {
                    this.m_objViewer.ctlDataGrid2.m_mthDeleteRow(i2);
                }
            }
            for (int i3 = this.m_objViewer.ctlDataGrid3.RowCount - 1; i3 >= 0; i3--)
            {
                if (this.m_objViewer.ctlDataGrid3[i3, t_ItemID] == null || this.m_objViewer.ctlDataGrid3[i3, t_ItemID].ToString() == "")
                {
                    this.m_objViewer.ctlDataGrid3.m_mthDeleteRow(i3);
                }
            }
            for (int i4 = this.m_objViewer.ctlDataGrid4.RowCount - 1; i4 >= 0; i4--)
            {
                if (this.m_objViewer.ctlDataGrid4[i4, t_ItemID] == null || this.m_objViewer.ctlDataGrid4[i4, t_ItemID].ToString() == "")
                {
                    this.m_objViewer.ctlDataGrid4.m_mthDeleteRow(i4);
                }
            }
            for (int i5 = this.m_objViewer.ctlDataGrid5.RowCount - 1; i5 >= 0; i5--)
            {
                if (this.m_objViewer.ctlDataGrid5[i5, 7] == null || this.m_objViewer.ctlDataGrid5[i5, 7].ToString() == "")
                {
                    this.m_objViewer.ctlDataGrid5.m_mthDeleteRow(i5);
                }
            }
            for (int i6 = this.m_objViewer.ctlDataGrid6.RowCount - 1; i6 >= 0; i6--)
            {
                if (this.m_objViewer.ctlDataGrid6[i6, 7] == null || this.m_objViewer.ctlDataGrid6[i6, 7].ToString() == "")
                {
                    this.m_objViewer.ctlDataGrid6.m_mthDeleteRow(i6);
                }
            }
            for (int ilis = this.m_objViewer.ctlDataGridLis.RowCount - 1; ilis >= 0; ilis--)
            {
                if (this.m_objViewer.ctlDataGridLis[ilis, t_ItemID] == null || this.m_objViewer.ctlDataGridLis[ilis, t_ItemID].ToString() == "" || this.m_objViewer.ctlDataGridLis[ilis, t_SumMoney] == null)
                {
                    this.m_objViewer.ctlDataGridLis.m_mthDeleteRow(ilis);
                }
            }
            for (int itest = this.m_objViewer.ctlDataGridTest.RowCount - 1; itest >= 0; itest--)
            {
                if (this.m_objViewer.ctlDataGridTest[itest, t_ItemID] == null || this.m_objViewer.ctlDataGridTest[itest, t_ItemID].ToString() == "" || this.m_objViewer.ctlDataGridTest[itest, t_SumMoney] == null)
                {
                    this.m_objViewer.ctlDataGridTest.m_mthDeleteRow(itest);
                }
            }
            for (int iops = this.m_objViewer.ctlDataGridOps.RowCount - 1; iops >= 0; iops--)
            {
                if (this.m_objViewer.ctlDataGridOps[iops, o_ItemID] == null || this.m_objViewer.ctlDataGridOps[iops, o_ItemID].ToString() == "" || this.m_objViewer.ctlDataGridOps[iops, o_SumMoney] == null)
                {
                    this.m_objViewer.ctlDataGridOps.m_mthDeleteRow(iops);
                }
            }
        }
        #endregion

        #region 判断病历信息是否为空（是否填写病历）
        /// <summary>
        /// 判断病历信息是否为空（是否填写病历）
        /// </summary>
        /// <returns></returns>
        private bool m_blnCheckCase()
        {
            string ID = this.m_objViewer.objCaseHistory.CaseHistoryID;
            if (ID.Trim() != "")
            {
                return true;
            }
            else
            {
                string AidCheck = this.m_objViewer.objCaseHistory.AidCheck.Trim();
                string AnaPhyLaXis = this.m_objViewer.objCaseHistory.Anaphylaxis.Trim();
                string Diag = this.m_objViewer.objCaseHistory.Diag.Trim();
                string DiagCurr = this.m_objViewer.objCaseHistory.DiagCurr.Trim();
                string DiagHis = this.m_objViewer.objCaseHistory.DiagHis.Trim();
                string DiagMain = this.m_objViewer.objCaseHistory.DiagMain.Trim();
                string ReMark = this.m_objViewer.objCaseHistory.ReMark.Trim();
                string TreatMent = this.m_objViewer.objCaseHistory.Treatment.Trim();
                string ExamineResult = this.m_objViewer.objCaseHistory.ExamineResult.Trim();
                string PRIHIS = this.m_objViewer.objCaseHistory.PersonHis.Trim();
                string CALDEPT_VCHR = this.m_objViewer.objCaseHistory.ChangeDepartment.Trim();

                if (AidCheck == "" && AnaPhyLaXis == "" && Diag == "" && DiagCurr == "" && DiagHis == "" && DiagMain == "" &&
                   ReMark == "" && TreatMent == "" && ExamineResult == "" && PRIHIS == "" && CALDEPT_VCHR == "")
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region  获取信息
        /// <summary>
        /// 获得病历信息
        /// </summary>
        private void m_mthGetCaseHistory(out clsOutpatientCaseHis_VO Case_VO, string CaseID, string EditFlag)
        {
            Case_VO = new clsOutpatientCaseHis_VO();

            //EditFlag: -1 历史； 0 删除； 1 新建
            Case_VO.m_intStatus = int.Parse(EditFlag);

            Case_VO.m_strCaseHisID = this.m_objViewer.objCaseHistory.CaseHistoryID;
            Case_VO.m_strDiagDeptID = this.m_objViewer.m_PatInfo.DeptID;//这里有疑问
            string strEmployeeID = "0000001";
            if (this.m_objViewer.LoginInfo != null)
            {
                strEmployeeID = this.m_objViewer.LoginInfo.m_strEmpID;
            }
            Case_VO.m_strDiagDrID = strEmployeeID;//this.m_objViewer.LoginInfo.m_strEmpID//操作员ID
            Case_VO.m_strModifyDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Case_VO.m_strPatientID = this.m_objViewer.m_PatInfo.PatientID;
            Case_VO.m_strRecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Case_VO.m_strRecordEmpID = strEmployeeID;//this.m_objViewer.LoginInfo.m_strEmpID//操作员ID
            Case_VO.m_strRegisterID = this.m_objViewer.m_PatInfo.RegisterID;
            Case_VO.strAidCheck = this.m_objViewer.objCaseHistory.AidCheck.Replace("'", "’");
            Case_VO.strAidCheck_XML = "";
            Case_VO.strAnaPhyLaXis = this.m_objViewer.objCaseHistory.Anaphylaxis.Replace("'", "’");
            Case_VO.strDiag = this.m_objViewer.objCaseHistory.Diag.Replace("'", "’");
            Case_VO.strDiag_XML = "";
            Case_VO.strDiagCurr = this.m_objViewer.objCaseHistory.DiagCurr.Replace("'", "’");
            Case_VO.strDiagCurr_XML = "";
            Case_VO.strDiagHis = this.m_objViewer.objCaseHistory.DiagHis.Replace("'", "’");
            Case_VO.strDiagHis_XML = "";
            Case_VO.strDiagMain = this.m_objViewer.objCaseHistory.DiagMain.Replace("'", "’");
            Case_VO.strDiagMain_XML = "";
            Case_VO.strReMark = this.m_objViewer.objCaseHistory.ReMark.Replace("'", "’");
            Case_VO.strReMark_XML = "";
            Case_VO.strTreatMent = this.m_objViewer.objCaseHistory.Treatment.Replace("'", "’");
            Case_VO.strTreatMent_XML = "";
            Case_VO.strExamineResult = this.m_objViewer.objCaseHistory.ExamineResult.Replace("'", "’");
            Case_VO.strExamineResult_XML = "";
            Case_VO.m_strPRIHIS_VCHR = this.m_objViewer.objCaseHistory.PersonHis.Replace("'", "’");
            Case_VO.m_strPRIHIS_XML_VCHR = "";
            Case_VO.strCALDEPT_VCHR = this.m_objViewer.objCaseHistory.ChangeDepartment.Replace("'", "’");
            Case_VO.strCALDEPT_VCHR_XML = "";
            Case_VO.strParentCaseHistoryID = this.m_objViewer.objCaseHistory.ParentCaseHistoryID;
            Case_VO.objIllnessArr = this.m_objViewer.objCaseHistory.ICD10;
        }
        //		/// <summary>
        //		/// 获得诊断信息
        //		/// </summary>
        //		private void m_mthGetDiagnoses(out clsOutpatientDiagRec_VO Diag_VO,string DiagID)
        //		{
        //			Diag_VO=new clsOutpatientDiagRec_VO();
        //			Diag_VO.m_strCurePrinciple=this.m_objViewer.m_txtCurePrin.Text;
        //			Diag_VO.m_strCureStd=this.m_objViewer.m_txtCureSTD.Text;
        //			Diag_VO.m_strDefend=this.m_objViewer.m_txtDefend.Text;
        //			Diag_VO.m_strDiagDeptID=this.m_objViewer.m_PatInfo.DeptID;//这里有疑问
        //			string strEmployeeID ="0000001";
        //			if(this.m_objViewer.LoginInfo!=null)
        //			{
        //				strEmployeeID=this.m_objViewer.LoginInfo.m_strEmpID;
        //			}	
        //			Diag_VO.m_strDiagDrID=strEmployeeID;//this.m_objViewer.LoginInfo.m_strEmpID//操作员ID
        //			Diag_VO.m_strDiagImport=this.m_objViewer.m_txtDiagPort.Text;
        //			Diag_VO.m_strDiagMemo=this.m_objViewer.m_txtDiagDesc.Text;
        //			Diag_VO.m_strDiagStd=this.m_objViewer.m_txtDiagSTD.Text;
        //			Diag_VO.m_strOutpatientDiagRecID=DiagID;
        //			Diag_VO.m_strPatientID=this.m_objViewer.m_PatInfo.PatientID;
        //			Diag_VO.m_strRecordDate=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        //			Diag_VO.m_strRecordEmpID=strEmployeeID;//this.m_objViewer.LoginInfo.m_strEmpID//操作员ID
        //			Diag_VO.m_strRegisterID=this.m_objViewer.m_PatInfo.RegisterID;
        //		}
        /// <summary>
        /// 获得主处方信息
        /// </summary>
        /// <param name="OPR_VO"></param>
        private void m_mthGetMainRecipeData(out clsOutPatientRecipe_VO OPR_VO)
        {
            OPR_VO = new clsOutPatientRecipe_VO();
            OPR_VO.m_strRecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strEmployeeID = "0000001";
            if (this.m_objViewer.LoginInfo != null)
            {
                strEmployeeID = this.m_objViewer.LoginInfo.m_strEmpID;
            }
            OPR_VO.m_strOperatorID = strEmployeeID;//操作员ID,在未加入权限功能之前,先定义为"0001"
            if (this.m_objViewer.btSave.Tag != null)
            {
                OPR_VO.m_strOutpatRecipeID = this.m_objViewer.btSave.Tag.ToString().Trim();
            }
            OPR_VO.m_strRegisterID = m_objViewer.m_PatInfo.RegisterID;
            OPR_VO.m_strDoctorID = m_objViewer.m_PatInfo.DoctorID;
            OPR_VO.m_strDepID = m_objViewer.m_PatInfo.DeptID;
            OPR_VO.m_strCreateDate = m_objViewer.m_PatInfo.RegisterDate;
            OPR_VO.m_strPatientID = m_objViewer.m_PatInfo.PatientID;
            OPR_VO.m_intPStatus = 0;//新建
            if (this.m_objViewer.cmbRecipeType.Items.Count > 0)
            {
                OPR_VO.m_strRecipeType = ((clsRecipeType_VO)this.m_objViewer.cmbRecipeType.SelectedItem).TYPE_INT;
            }
            else
            {
                OPR_VO.m_strRecipeType = "";
            }
            // 正负方 --> 处方提交时判断、更新该字段
            //OPR_VO.m_intType=int.Parse(this.objSvc.m_strGetRecipeType(m_objViewer.m_PatInfo.PatientID, m_objViewer.m_PatInfo.DoctorID));
            OPR_VO.m_strPatientType = this.m_objViewer.m_PatInfo.PayTypeID;
            OPR_VO.m_strCaseHistoryID = this.m_objViewer.objCaseHistory.CaseHistoryID;
            OPR_VO.intCreatetype = 0;

            #region 外送药品判断: 一张处方里只能包含饮片,否则不能代煎
            // 是否代煎药
            bool isProxyBoilMed = this.m_objViewer.cboProxyBoilMed.SelectedIndex > 0 ? true : false;
            if (isProxyBoilMed)
            {
                string chargeItemId = string.Empty;
                List<string> lstChargeItemId = new List<string>();
                for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
                {
                    chargeItemId = this.m_objViewer.ctlDataGrid2[i, 8].ToString();
                    if (lstChargeItemId.IndexOf(chargeItemId) < 0) lstChargeItemId.Add(chargeItemId);
                }
                if (lstChargeItemId.Count > 0)
                {
                    if (this.objSvc.CheckRecipeSlices(lstChargeItemId) == false)
                    {
                        MessageBox.Show("处方中存在非饮片药材，不能办理外送代煎。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.cboProxyBoilMed.SelectedIndex = 0;
                    }
                }
            }
            #endregion

            OPR_VO.IsProxyBoilMed = this.m_objViewer.cboProxyBoilMed.SelectedIndex;

        }
        /// <summary>
        /// 获得西药处方信息
        /// </summary>
        /// <param name="ID"></param>
        private bool m_mthGetWMRecipeData(out clsOutpatientPWMRecipeDe_VO[] PWM_VO, string ID)
        {
            Hisitf.EntityDrugUse drugVo = null;

            PWM_VO = new clsOutpatientPWMRecipeDe_VO[this.m_objViewer.ctlDataGrid1.RowCount];
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                PWM_VO[i] = new clsOutpatientPWMRecipeDe_VO();
                PWM_VO[i].m_decDays = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Day]);
                PWM_VO[i].m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Discount]);
                PWM_VO[i].m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Price]);
                PWM_VO[i].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Count]);
                PWM_VO[i].m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_SumMoney]);
                PWM_VO[i].m_decTolDiffPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_intDiffPrice]);// 差价
                PWM_VO[i].m_decTolQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Total]);
                PWM_VO[i].m_strFrequency = this.m_objViewer.ctlDataGrid1[i, c_FreID].ToString().Trim();
                PWM_VO[i].m_strItemID = this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString().Trim();
                PWM_VO[i].m_strOutpatRecipeID = ID;
                PWM_VO[i].m_strRowNo = this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim();
                if (this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim() == "")
                {
                    PWM_VO[i].m_strRowNo = "0";
                }
                PWM_VO[i].m_strRowNo2 = i.ToString();
                PWM_VO[i].m_strUnit = this.m_objViewer.ctlDataGrid1[i, c_BigUnit].ToString().Trim();
                PWM_VO[i].m_strUsageID = this.m_objViewer.ctlDataGrid1[i, c_UsageID].ToString().Trim();
                PWM_VO[i].m_strHYPETEST_INT = this.m_objViewer.ctlDataGrid1[i, c_PS].ToString().Trim();
                PWM_VO[i].m_strDESC_VCHR = this.m_objViewer.ctlDataGrid1[i, c_UsageDetail].ToString().Trim();
                PWM_VO[i].m_strUSAGEPARENTID_VCHR = this.m_objViewer.ctlDataGrid1[i, c_SubItemID].ToString().Trim();
                PWM_VO[i].m_strATTACHPARENTID_VCHR = this.m_objViewer.ctlDataGrid1[i, c_resubitem].ToString().Trim();
                PWM_VO[i].m_strItemspec = this.m_objViewer.ctlDataGrid1[i, c_Spec].ToString().Trim();
                PWM_VO[i].m_decDosage = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Dosage]);
                PWM_VO[i].m_strDosageunit = this.m_objViewer.ctlDataGrid1[i, c_Unit].ToString().Trim();
                PWM_VO[i].m_decAttachitembasenum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_MainItemNum]);
                PWM_VO[i].m_strItemname = this.m_objViewer.ctlDataGrid1[i, c_Name].ToString().Trim();
                if (this.m_objViewer.ctlDataGrid1[i, c_DeptmedID].ToString().Trim() == "1")
                {
                    PWM_VO[i].m_intDeptmed = 1;
                }
                else
                {
                    PWM_VO[i].m_intDeptmed = 0;
                }

                if (PWM_VO[i].m_decQty == 0)
                {
                    MessageBox.Show("西药栏第" + Convert.ToString(i + 1) + "行药品【" + PWM_VO[i].m_strItemname + "】用量为0，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (PWM_VO[i].m_decDays == 0 || PWM_VO[i].m_decDays.ToString().Trim().Length > 3)
                {
                    MessageBox.Show("西药栏第" + Convert.ToString(i + 1) + "行药品【" + PWM_VO[i].m_strItemname + "】天数不正确，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                if (PWM_VO[i].m_strFrequency == "")
                {
                    MessageBox.Show("西药栏第" + Convert.ToString(i + 1) + "行药品【" + PWM_VO[i].m_strItemname + "】频率为空，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                // PWM_VO[i].m_strExecDeptID = WMDrugStoreDeptID;
                if (this.m_objViewer.ctlDataGrid1[i, c_UnitFlag].ToString().Trim() == "1")
                {
                    PWM_VO[i].UnitType = "0";
                    PWM_VO[i].UnitScale = "";
                }
                else
                {
                    PWM_VO[i].UnitType = "2";
                    PWM_VO[i].UnitScale = this.m_objViewer.ctlDataGrid1[i, c_Packet].ToString().Trim();
                }

                #region use drug
                drugVo = new Hisitf.EntityDrugUse();
                drugVo.drug = PWM_VO[i].m_strItemID;
                drugVo.drugName = PWM_VO[i].m_strItemname;
                drugVo.specification = PWM_VO[i].m_strItemspec;
                drugVo.package = this.m_objViewer.ctlDataGrid1[i, c_Packet].ToString();
                drugVo.quantity = PWM_VO[i].m_decTolQty.ToString();//.m_decQty.ToString();
                drugVo.packUnit = this.m_objViewer.ctlDataGrid1[i, c_BigUnit].ToString();
                drugVo.unitPrice = PWM_VO[i].m_decPrice.ToString();
                drugVo.amount = PWM_VO[i].m_decTolPrice.ToString();
                drugVo.groupNo = PWM_VO[i].m_strRowNo;
                drugVo.firstUse = "false";   // ?
                drugVo.prepForm = "";   // 剂型?
                drugVo.adminRoute = this.m_objViewer.ctlDataGrid1[i, c_UsageName].ToString();
                drugVo.adminFrequency = this.m_objViewer.ctlDataGrid1[i, c_FreName].ToString();
                drugVo.adminDose = PWM_VO[i].m_decQty.ToString() + PWM_VO[i].m_strDosageunit;    // +单位? 

                lstDrug.Add(drugVo);
                #endregion
            }

            return true;
        }

        #region GetDrugPatInfo
        /// <summary>
        /// GetDrugPatInfo
        /// </summary>
        /// <returns></returns>
        Hisitf.EntityDrugUse GetDrugPatInfo()
        {
            Hisitf.EntityDrugUse patVo = new Hisitf.EntityDrugUse();
            patVo.departID = this.m_objViewer.m_PatInfo.DeptID;
            patVo.department = this.m_objViewer.m_PatInfo.DeptName;
            patVo.presType = ((clsRecipeType_VO)this.m_objViewer.cmbRecipeType.SelectedItem).TYPENAME_VCHR;
            patVo.presSource = "门诊";
            patVo.presDatetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            patVo.payType = this.m_objViewer.m_PatInfo.PayTypeName;
            patVo.patientNo = this.m_objViewer.m_PatInfo.PatientCardID;
            if (this.m_objViewer.btSave.Tag != null)    // 未保存没有处方号，传?
            {
                patVo.presNo = this.m_objViewer.btSave.Tag.ToString().Trim();
            }
            else
            {
                patVo.presNo = DateTime.Now.ToString("yyyyMMddHHmmss") + this.m_objViewer.m_PatInfo.PatientID;
            }
            patVo.name = this.m_objViewer.m_PatInfo.PatientName;
            patVo.diagnose = this.m_objViewer.objCaseHistory.Diag.Replace("'", "’");
            patVo.address = this.m_objViewer.m_PatInfo.PatientHomeAddress;
            patVo.IDCard = this.m_objViewer.m_PatInfo.IDcard;
            patVo.phoneNo = this.m_objViewer.m_PatInfo.PatientTelephoneNo;
            patVo.age = this.m_objViewer.m_PatInfo.PatientAge;
            patVo.sex = this.m_objViewer.m_PatInfo.PatientSex;  // ? M F 男
            patVo.allergyList = this.m_objViewer.objCaseHistory.Anaphylaxis.Replace("'", "’");
            patVo.docID = this.m_objViewer.m_PatInfo.DoctorID;
            patVo.docName = this.m_objViewer.m_PatInfo.DoctorName;
            patVo.docTitle = this.m_objViewer.m_PatInfo.DoctTechnicalRank;
            patVo.totalAmount = this.m_objViewer.AA.Text;
            patVo.drugSensivity = "false";      // 菌检

            return patVo;
        }
        #endregion

        /// <summary>
        /// 获得中药处方明细
        /// </summary>
        /// <param name="CM_VO"></param>
        /// <param name="ID"></param>
        private bool m_mthGetCMRecipeData(out clsOutpatientCMRecipeDe_VO[] CM_VO, string ID)
        {
            Hisitf.EntityDrugUse voDrug = null;
            CM_VO = new clsOutpatientCMRecipeDe_VO[this.m_objViewer.ctlDataGrid2.RowCount];
            for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
            {
                CM_VO[i] = new clsOutpatientCMRecipeDe_VO();
                CM_VO[i].m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 11]);
                CM_VO[i].m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 6]);
                CM_VO[i].m_decMIN_QTY_DEC = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 1]);
                CM_VO[i].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 15]);
                CM_VO[i].m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 7]);
                CM_VO[i].m_decTolDiffPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 30]);// 总让利金额
                CM_VO[i].m_strItemID = this.m_objViewer.ctlDataGrid2[i, 8].ToString();
                CM_VO[i].m_strUnit = this.m_objViewer.ctlDataGrid2[i, 2].ToString();
                CM_VO[i].m_strOutpatRecipeID = ID;
                CM_VO[i].m_strRowNo = this.m_objViewer.ctlDataGrid2[i, 19].ToString().Trim();
                CM_VO[i].m_strRowNo2 = i.ToString();
                CM_VO[i].m_strUsageID = this.m_objViewer.ctlDataGrid2[i, 21].ToString();
                CM_VO[i].m_intTimes = (int)this.m_objViewer.numericUpDown1.Value;
                CM_VO[i].m_strCMedicineUsage = this.m_objViewer.cmbCooking.Text;
                CM_VO[i].m_strItemname = this.m_objViewer.ctlDataGrid2[i, 3].ToString();
                CM_VO[i].m_strItemspec = this.m_objViewer.ctlDataGrid2[i, 4].ToString();
                if (this.m_objViewer.ctlDataGrid2[i, cm_DeptmedID].ToString().Trim() == "1")
                {
                    CM_VO[i].m_intDeptmed = 1;
                }
                else
                {
                    CM_VO[i].m_intDeptmed = 0;
                }
                CM_VO[i].m_strUsageDetail = this.m_objViewer.ctlDataGrid2[i, cm_UsageDetail].ToString();

                //CM_VO[i].m_strExecDeptID = CMDrugStoreDeptID;
                //CM_VO[i].m_strExecDeptName = this.CMDrugStoreName;
                if (CM_VO[i].m_decMIN_QTY_DEC == 0)
                {
                    MessageBox.Show("中药栏第" + Convert.ToString(i + 1) + "行药品【" + CM_VO[i].m_strItemname + "】数量为0，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                #region use drug
                voDrug = new Hisitf.EntityDrugUse();
                voDrug.drug = CM_VO[i].m_strItemID;
                voDrug.drugName = CM_VO[i].m_strItemname;
                voDrug.specification = CM_VO[i].m_strItemspec;
                voDrug.package = this.m_objViewer.ctlDataGrid2[i, 18].ToString();
                voDrug.quantity = CM_VO[i].m_decQty.ToString();
                voDrug.packUnit = CM_VO[i].m_strUnit;
                voDrug.unitPrice = CM_VO[i].m_decPrice.ToString();
                voDrug.amount = CM_VO[i].m_decTolPrice.ToString();
                voDrug.groupNo = "1";   //CM_VO[i].m_strRowNo2;
                voDrug.firstUse = "false";
                voDrug.adminRoute = this.m_objViewer.ctlDataGrid2[i, 5].ToString();
                voDrug.adminFrequency = "1";
                voDrug.adminDose = voDrug.quantity + voDrug.packUnit;    // +单位? 

                lstDrug.Add(voDrug);
                #endregion
            }
            return true;
        }
        /// <summary>
        /// 获得检验信息
        /// </summary>
        /// <param name="CHK_VO"></param>
        /// <param name="ID"></param>
        private bool m_mthGetTestRecipeData(out clsOutpatientCHKRecipeDe_VO[] CHK_VO, string ID)
        {
            CHK_VO = new clsOutpatientCHKRecipeDe_VO[this.m_objViewer.ctlDataGrid3.RowCount];
            for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                CHK_VO[i] = new clsOutpatientCHKRecipeDe_VO();
                CHK_VO[i].m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Discount]);
                CHK_VO[i].m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Price]);
                CHK_VO[i].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Count]);
                CHK_VO[i].m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_SumMoney]);
                CHK_VO[i].m_strItemID = this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString();
                CHK_VO[i].strApplyID = this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString();
                CHK_VO[i].strSampletypeID = this.m_objViewer.ctlDataGrid3[i, t_Temp].ToString();
                CHK_VO[i].m_strOutpatRecipeID = ID;
                CHK_VO[i].m_strRowNo = i.ToString();
                CHK_VO[i].m_strOprDeptID = "";
                CHK_VO[i].m_strUSAGEPARENTID_VCHR = this.m_objViewer.ctlDataGrid3[i, t_OtherItemID].ToString().Trim();
                CHK_VO[i].m_strATTACHPARENTID_VCHR = this.m_objViewer.ctlDataGrid3[i, t_resubitem].ToString().Trim();
                if (this.m_objViewer.ctlDataGrid3[i, t_quickid].ToString().Trim() == "1")
                {
                    CHK_VO[i].m_strQuickflag_CHR = "1";
                }
                else
                {
                    CHK_VO[i].m_strQuickflag_CHR = "0";
                }
                CHK_VO[i].m_decAttachitembasenum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_MainItemNum]);
                CHK_VO[i].m_decUsageitembasenum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_OtherCount]);
                CHK_VO[i].m_strItemname = this.m_objViewer.ctlDataGrid3[i, t_Name].ToString().Trim();
                CHK_VO[i].m_strItemspec = this.m_objViewer.ctlDataGrid3[i, t_Spec].ToString().Trim();
                CHK_VO[i].m_strItemunit = this.m_objViewer.ctlDataGrid3[i, t_Unit].ToString().Trim();
                CHK_VO[i].m_strUsagedetail = this.m_objViewer.ctlDataGrid3[i, t_UsageDetail].ToString().Trim();
                CHK_VO[i].m_intDeptmed = 0;
                CHK_VO[i].m_strOrderID = this.m_objViewer.ctlDataGrid3[i, t_lis_orderitem].ToString().Trim();
                CHK_VO[i].m_decOrderBaseNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_lis_ordernum]);

                if (CHK_VO[i].m_decQty == 0)
                {
                    MessageBox.Show("检验栏第" + Convert.ToString(i + 1) + "行项目【" + CHK_VO[i].m_strItemname + "】数量为0，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 获得检查信息
        /// </summary>
        /// <param name="TR_VO"></param>
        /// <param name="ID"></param>
        private bool m_mthGetExamineRecipeData(out clsOutpatientTestRecipeDe_VO[] TR_VO, string ID)
        {
            TR_VO = new clsOutpatientTestRecipeDe_VO[this.m_objViewer.ctlDataGrid4.RowCount];
            for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
            {
                TR_VO[i] = new clsOutpatientTestRecipeDe_VO();
                TR_VO[i].m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Discount]);
                TR_VO[i].m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Price]);
                TR_VO[i].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Count]);
                TR_VO[i].m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_SumMoney]);
                TR_VO[i].m_strItemID = this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString();
                if (this.m_objViewer.ctlDataGrid4[i, t_ApplyId].ToString().Trim() != "")
                {
                    TR_VO[i].strApplyID = this.m_objViewer.ctlDataGrid4[i, t_ApplyId].ToString();
                }
                else
                {
                    TR_VO[i].strApplyID = dp.GetNextID("AR_COMMON_APPLY", "ApplyID");
                }
                TR_VO[i].strPartID = this.m_objViewer.ctlDataGrid4[i, t_Temp].ToString();
                TR_VO[i].m_strOutpatRecipeID = ID;
                TR_VO[i].m_strRowNo = i.ToString();
                TR_VO[i].m_strOprDeptID = "";
                TR_VO[i].m_strUSAGEPARENTID_VCHR = this.m_objViewer.ctlDataGrid4[i, t_OtherItemID].ToString().Trim();
                TR_VO[i].m_strATTACHPARENTID_VCHR = this.m_objViewer.ctlDataGrid4[i, t_resubitem].ToString().Trim();
                TR_VO[i].m_decAttachitembasenum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_MainItemNum]);
                TR_VO[i].m_decUsageitembasenum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_OtherCount]);
                TR_VO[i].m_strItemname = this.m_objViewer.ctlDataGrid4[i, t_Name].ToString().Trim();
                TR_VO[i].m_strItemspec = this.m_objViewer.ctlDataGrid4[i, t_Spec].ToString().Trim();
                TR_VO[i].m_strItemunit = this.m_objViewer.ctlDataGrid4[i, t_Unit].ToString().Trim();
                TR_VO[i].m_strUsagedetail = this.m_objViewer.ctlDataGrid4[i, t_UsageDetail2].ToString().Trim();
                TR_VO[i].m_intDeptmed = 0;
                TR_VO[i].m_strUsageID = this.m_objViewer.ctlDataGrid4[i, t_UsageID].ToString().Trim();
                TR_VO[i].m_strOrderID = this.m_objViewer.ctlDataGrid4[i, t_test_orderitem].ToString().Trim();
                TR_VO[i].m_decOrderBaseNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_test_ordernum]);

                if (TR_VO[i].m_decQty == 0)
                {
                    MessageBox.Show("检查栏第" + Convert.ToString(i + 1) + "行项目【" + TR_VO[i].m_strItemname + "】数量为0，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// 获得手术信息
        /// </summary>
        /// <param name="OP_VO"></param>
        /// <param name="ID"></param>
        private bool m_mthGetOPRecipeData(out clsOutpatientOPSRecipeDe_VO[] OP_VO, string ID)
        {
            OP_VO = new clsOutpatientOPSRecipeDe_VO[this.m_objViewer.ctlDataGrid5.RowCount];
            for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
            {
                OP_VO[i] = new clsOutpatientOPSRecipeDe_VO();
                OP_VO[i].m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Discount]);
                OP_VO[i].m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Price]);
                OP_VO[i].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Count]);
                OP_VO[i].m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_SumMoney]);
                OP_VO[i].m_strItemID = this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString();
                OP_VO[i].strApplyID = this.m_objViewer.ctlDataGrid5[i, o_ApplyId].ToString();
                OP_VO[i].m_strOutpatRecipeID = ID;
                OP_VO[i].m_strRowNo = i.ToString();
                OP_VO[i].m_strOprDeptID = "";
                OP_VO[i].m_strUSAGEPARENTID_VCHR = this.m_objViewer.ctlDataGrid5[i, o_OtherItemID].ToString().Trim();
                OP_VO[i].m_strATTACHPARENTID_VCHR = this.m_objViewer.ctlDataGrid5[i, o_resubitem].ToString().Trim();
                OP_VO[i].m_decAttachitembasenum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_MainItemNum]);
                OP_VO[i].m_decUsageitembasenum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_OtherCount]);
                OP_VO[i].m_strItemname = this.m_objViewer.ctlDataGrid5[i, o_Name].ToString().Trim();
                OP_VO[i].m_strItemspec = this.m_objViewer.ctlDataGrid5[i, o_Spec].ToString().Trim();
                OP_VO[i].m_strItemunit = this.m_objViewer.ctlDataGrid5[i, o_Unit].ToString().Trim();
                OP_VO[i].m_strUsagedetail = this.m_objViewer.ctlDataGrid5[i, o_UsageDetail].ToString().Trim();
                OP_VO[i].m_intDeptmed = 0;
                OP_VO[i].m_strUsageID = this.m_objViewer.ctlDataGrid5[i, o_UsageID].ToString().Trim();
                OP_VO[i].m_strOrderID = this.m_objViewer.ctlDataGrid5[i, t_ops_orderitem].ToString().Trim();
                OP_VO[i].m_decOrderBaseNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, t_ops_ordernum]);

                if (OP_VO[i].m_decQty == 0)
                {
                    MessageBox.Show("手术治疗栏第" + Convert.ToString(i + 1) + "行项目【" + OP_VO[i].m_strItemname + "】数量为0，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }
        private bool m_mthGetOtherRecipeData(out clsOutpatientOtherRecipeDe_VO[] Other_VO, string ID)
        {
            Other_VO = new clsOutpatientOtherRecipeDe_VO[this.m_objViewer.ctlDataGrid6.RowCount];
            for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
            {
                Other_VO[i] = new clsOutpatientOtherRecipeDe_VO();
                Other_VO[i].m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, o_Discount]);
                Other_VO[i].m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, o_Price]);
                Other_VO[i].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, o_Count]);
                Other_VO[i].m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, o_SumMoney]);
                Other_VO[i].m_strItemID = this.m_objViewer.ctlDataGrid6[i, o_ItemID].ToString();
                Other_VO[i].strApplyID = this.m_objViewer.ctlDataGrid6[i, o_ApplyId].ToString();
                Other_VO[i].m_strOutpatRecipeID = ID;
                Other_VO[i].m_strRowNo = i.ToString();
                Other_VO[i].m_strUSAGEPARENTID_VCHR = this.m_objViewer.ctlDataGrid6[i, o_OtherItemID].ToString().Trim(); ;
                Other_VO[i].m_strATTACHPARENTID_VCHR = this.m_objViewer.ctlDataGrid6[i, o_resubitem].ToString().Trim();
                Other_VO[i].m_decAttachitembasenum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, o_MainItemNum]);
                Other_VO[i].m_decUsageitembasenum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, o_OtherCount]);
                Other_VO[i].m_strItemname = this.m_objViewer.ctlDataGrid6[i, o_Name].ToString().Trim();
                Other_VO[i].m_strItemspec = this.m_objViewer.ctlDataGrid6[i, o_Spec].ToString().Trim();
                Other_VO[i].m_strItemunit = this.m_objViewer.ctlDataGrid6[i, o_Unit].ToString().Trim();
                Other_VO[i].m_strUsagedetail = this.m_objViewer.ctlDataGrid6[i, o_UsageDetail2].ToString().Trim();
                if (this.m_objViewer.ctlDataGrid6[i, o_DeptmedID].ToString().Trim() == "1")
                {
                    Other_VO[i].m_intDeptmed = 1;
                }
                else
                {
                    Other_VO[i].m_intDeptmed = 0;
                }

                if (Other_VO[i].m_decQty == 0)
                {
                    MessageBox.Show("其他栏第" + Convert.ToString(i + 1) + "行项目【" + Other_VO[i].m_strItemname + "】数量为0，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        #region 获取仓库ID
        /// <summary>
        /// 获取仓库ID
        /// </summary>
        public void m_mthGetStoreID()
        {
            if (dvMedStore.Count == 0)
            {
                return;
            }

            this.WMDrugStoreID = this.m_strReadXML("register", "WMedicinestore", "AnyOne");
            dvMedStore.RowFilter = "medstoreid_chr = '" + this.WMDrugStoreID + "'";
            if (dvMedStore.Count > 0)
            {
                this.WMDrugStoreDeptID = dvMedStore[0]["deptid_chr"].ToString().Trim();
                this.WMDrugStoreName = dvMedStore[0]["medstorename_vchr"].ToString().Trim();
                // m_strNormalWMDrugStoreId = WMDrugStoreDeptID;
                // m_strNormalWMDrugStoreName = WMDrugStoreName;
            }

            this.CMDrugStoreID = this.m_strReadXML("register", "CMedicinestore", "AnyOne");
            dvMedStore.RowFilter = "medstoreid_chr = '" + this.CMDrugStoreID + "'";
            if (dvMedStore.Count > 0)
            {
                this.CMDrugStoreDeptID = dvMedStore[0]["deptid_chr"].ToString().Trim();
                this.CMDrugStoreName = dvMedStore[0]["medstorename_vchr"].ToString().Trim();
                //m_strNormalCMDrugStoreId = this.CMDrugStoreDeptID;
                //m_strNormalCMDrugStoreName = this.CMDrugStoreName;
            }

            this.MaterialStoreID = this.m_strReadXML("register", "MaterialStore", "AnyOne");
            dvMedStore.RowFilter = "medstoreid_chr = '" + this.MaterialStoreID + "'";
            if (dvMedStore.Count > 0)
            {
                this.MaterialStoreDeptID = dvMedStore[0]["deptid_chr"].ToString().Trim();
                this.MaterialStoreName = dvMedStore[0]["medstorename_vchr"].ToString().Trim();
            }

            dvMedStore.RowFilter = "1=1";
        }
        #endregion

        private bool m_mthGetOrderRecipeData(out clsOutpatientOrderRecipeDe_VO[] Order_VO, string ID)
        {
            if (ItemInputMode == 0)
            {
                Order_VO = null;
                return true;
            }

            int index = 0;

            Order_VO = new clsOutpatientOrderRecipeDe_VO[this.m_objViewer.ctlDataGridLis.RowCount + this.m_objViewer.ctlDataGridTest.RowCount + this.m_objViewer.ctlDataGridOps.RowCount];

            //检验
            for (int i = 0; i < this.m_objViewer.ctlDataGridLis.RowCount; i++)
            {
                Order_VO[index] = new clsOutpatientOrderRecipeDe_VO();
                Order_VO[index].m_strOutpatRecipeID = ID;
                Order_VO[index].m_strRowNo = i.ToString();
                Order_VO[index].m_strTableIndex = "3";
                Order_VO[index].m_strOrderID = this.m_objViewer.ctlDataGridLis[i, t_ItemID].ToString();
                Order_VO[index].m_strOrderName = this.m_objViewer.ctlDataGridLis[i, t_Name].ToString().Trim();
                Order_VO[index].m_strOrderSpec = this.m_objViewer.ctlDataGridLis[i, t_Spec].ToString().Trim();
                Order_VO[index].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Count]);
                Order_VO[index].m_strAttachID = this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString();
                Order_VO[index].m_strSampleID = this.m_objViewer.ctlDataGridLis[i, t_Temp].ToString();
                Order_VO[index].m_strCheckPartID = "";
                Order_VO[index].m_decPriceMny = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Price]);
                Order_VO[index].m_decTotalMny = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_SumMoney]);
                Order_VO[index].m_strAttachOrderID = this.m_objViewer.ctlDataGridLis[i, t_resubitem].ToString();
                Order_VO[index].m_decAttachOrderBaseNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_MainItemNum]);
                Order_VO[index].m_decSbBaseMny = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Discount]);

                if (Order_VO[index].m_decQty == 0)
                {
                    MessageBox.Show("检验栏第" + Convert.ToString(i + 1) + "行项目【" + Order_VO[index].m_strOrderName + "】数量为0，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                index++;
            }

            //检查        
            for (int i = 0; i < this.m_objViewer.ctlDataGridTest.RowCount; i++)
            {
                Order_VO[index] = new clsOutpatientOrderRecipeDe_VO();
                Order_VO[index].m_strOutpatRecipeID = ID;
                Order_VO[index].m_strRowNo = i.ToString();
                Order_VO[index].m_strTableIndex = "4";
                Order_VO[index].m_strOrderID = this.m_objViewer.ctlDataGridTest[i, t_ItemID].ToString();
                Order_VO[index].m_strOrderName = this.m_objViewer.ctlDataGridTest[i, t_Name].ToString().Trim();
                Order_VO[index].m_strOrderSpec = this.m_objViewer.ctlDataGridTest[i, t_Spec].ToString().Trim();
                Order_VO[index].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Count]);
                Order_VO[index].m_strAttachID = this.m_objViewer.ctlDataGridTest[i, t_ApplyId].ToString();
                Order_VO[index].m_strSampleID = "";
                Order_VO[index].m_strCheckPartID = this.m_objViewer.ctlDataGridTest[i, t_Temp].ToString();
                Order_VO[index].m_decPriceMny = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Price]);
                Order_VO[index].m_decTotalMny = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_SumMoney]);
                Order_VO[index].m_strAttachOrderID = this.m_objViewer.ctlDataGridTest[i, t_resubitem].ToString();
                Order_VO[index].m_decAttachOrderBaseNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_MainItemNum]);
                Order_VO[index].m_decSbBaseMny = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Discount]);

                if (Order_VO[index].m_decQty == 0)
                {
                    MessageBox.Show("检查栏第" + Convert.ToString(i + 1) + "行项目【" + Order_VO[index].m_strOrderName + "】数量为0，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                index++;
            }

            //手术治疗
            for (int i = 0; i < this.m_objViewer.ctlDataGridOps.RowCount; i++)
            {
                Order_VO[index] = new clsOutpatientOrderRecipeDe_VO();
                Order_VO[index].m_strOutpatRecipeID = ID;
                Order_VO[index].m_strRowNo = i.ToString();
                Order_VO[index].m_strTableIndex = "5";
                Order_VO[index].m_strOrderID = this.m_objViewer.ctlDataGridOps[i, o_ItemID].ToString();
                Order_VO[index].m_strOrderName = this.m_objViewer.ctlDataGridOps[i, o_Name].ToString().Trim();
                Order_VO[index].m_strOrderSpec = this.m_objViewer.ctlDataGridOps[i, o_Spec].ToString().Trim();
                Order_VO[index].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Count]);
                Order_VO[index].m_strAttachID = "";
                Order_VO[index].m_strSampleID = "";
                Order_VO[index].m_strCheckPartID = "";
                Order_VO[index].m_decPriceMny = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Price]);
                Order_VO[index].m_decTotalMny = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_SumMoney]);
                Order_VO[index].m_strAttachOrderID = this.m_objViewer.ctlDataGridOps[i, o_resubitem].ToString();
                Order_VO[index].m_decAttachOrderBaseNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_MainItemNum]);
                Order_VO[index].m_decSbBaseMny = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Discount]);

                if (Order_VO[index].m_decQty == 0)
                {
                    MessageBox.Show("手术治疗栏第" + Convert.ToString(i + 1) + "行项目【" + Order_VO[index].m_strOrderName + "】数量为0，请修改！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                index++;
            }

            return true;
        }

        #endregion

        #region 保存数据
        private long m_mthSaveMainRecipe(out string strRecipeID)
        {
            this.m_objViewer.btSave.Enabled = false;
            strRecipeID = "";
            clsOutPatientRecipe_VO OPR_VO = null;
            this.m_mthGetMainRecipeData(out OPR_VO);
            this.m_objViewer.btSave.Enabled = true;
            //			return objSvc.m_mthSaveRecipeMain(OPR_VO,out strRecipeID);
            return 0;
        }
        private void m_mthSavePublicData(string strRecipeID, bool IsNew)
        {
            this.m_mthSaveCaseHistory(strRecipeID, IsNew);
            this.m_mthSaveDiagnoses(strRecipeID, IsNew);
        }
        /// <summary>
        /// 保存病历
        /// </summary>
        private void m_mthSaveCaseHistory(string ID, bool IsNew)
        {
            clsOutpatientCaseHis_VO CH_VO = null;
            this.m_mthGetCaseHistory(out CH_VO, ID, "1");
            bool temp = true;
            if (this.m_objViewer.objCaseHistory.CaseHistoryID != "")
            {
                temp = false;
            }

            //			objSvc.m_mthSaveCaseHistory(CH_VO,temp);
            this.m_objViewer.objCaseHistory.CaseHistoryID = CH_VO.m_strCaseHisID;
        }

        /// <summary>
        /// 伪删除病历
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="p_EditFlag">1 新建病历 0 伪删除病历</param>
        public void m_mthDelCashHistory(string p_EditFlag)
        {
            clsOutpatientCaseHis_VO CH_VO = null;
            this.m_mthGetCaseHistory(out CH_VO, "", p_EditFlag);

            string strCashID = "";
            long lngRet = objSvc.m_lngSaveCaseHis(CH_VO, false, ref strCashID);
            if (lngRet > 0)
            {
                this.m_mthClearCaseHistory();
            }
            else
            {
                MessageBox.Show("删除病历失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 保存诊断
        /// </summary>
        private void m_mthSaveDiagnoses(string ID, bool IsNew)
        {
            //			clsOutpatientDiagRec_VO  DR_VO=null;
            //			this.m_mthGetDiagnoses(out DR_VO,ID);
            //			objSvc.m_mthSaveDiagnoses(DR_VO,IsNew);
        }
        private void m_mthSaveRecipeDetail(string ID)
        {
            this.m_mthSaveDetail1(ID);
            this.m_mthSaveDetail2(ID);
            this.m_mthSaveDetail3(ID);
            this.m_mthSaveDetail4(ID);
            this.m_mthSaveDetail5(ID);
            this.m_mthSaveDetail6(ID);
        }
        private void m_mthSaveDetail1(string ID)
        {
            clsOutpatientPWMRecipeDe_VO[] PWM_VO = null;
            this.m_mthGetWMRecipeData(out PWM_VO, ID);
            if (PWM_VO.Length > 0)
            {
                //				objSvc.m_mthSaveDetail1(PWM_VO);
            }
        }
        private void m_mthSaveDetail2(string ID)
        {
            clsOutpatientCMRecipeDe_VO[] CM_VO = null;
            this.m_mthGetCMRecipeData(out CM_VO, ID);
            if (CM_VO.Length > 0)
            {
                //				objSvc.m_mthSaveDetail2(CM_VO);
            }
        }
        private void m_mthSaveDetail3(string ID)
        {
            clsOutpatientCHKRecipeDe_VO[] CHK_VO = null;
            this.m_mthGetTestRecipeData(out CHK_VO, ID);
            if (CHK_VO.Length > 0)
            {
                //				objSvc.m_mthSaveDetail3(CHK_VO);
            }
        }
        private void m_mthSaveDetail4(string ID)
        {
            clsOutpatientTestRecipeDe_VO[] TR_VO = null;
            this.m_mthGetExamineRecipeData(out TR_VO, ID);
            if (TR_VO.Length > 0)
            {
                //				objSvc.m_mthSaveDetail4(TR_VO);
            }
        }
        private void m_mthSaveDetail5(string ID)
        {
            clsOutpatientOPSRecipeDe_VO[] OP_VO = null;
            this.m_mthGetOPRecipeData(out OP_VO, ID);
            if (OP_VO.Length > 0)
            {
                //				objSvc.m_mthSaveDetail5(OP_VO);
            }
        }
        private void m_mthSaveDetail6(string ID)
        {
            clsOutpatientOtherRecipeDe_VO[] Other_VO = null;
            this.m_mthGetOtherRecipeData(out Other_VO, ID);
            if (Other_VO.Length > 0)
            {
                //				objSvc.m_mthSaveDetail6(Other_VO);
            }
        }
        #endregion

        #region 更新数据
        private long m_mthUpdateMainRecipe()
        {
            return 1;
        }
        #endregion

        #endregion

        #region 删除数据
        public void m_mthDeleteData(string ID)
        {
            this.m_mthDeletePublicData(ID);
        }
        /// <summary>
        /// 删除主处方
        /// </summary>
        /// <returns></returns>
        private long m_mthDeleteMainRecipe()
        {
            return 1;
        }
        #region 删除诊断和病历
        /// <summary>
        /// 删除诊断和病历
        /// </summary>
        private void m_mthDeletePublicData(string ID)
        {
            this.m_mthDeleteCaseHistory(ID);
            this.m_mthDeleteDiagnoses(ID);
        }
        /// <summary>
        /// 删除病历
        /// </summary>
        private void m_mthDeleteCaseHistory(string ID)
        {

        }
        /// <summary>
        /// 删除诊断
        /// </summary>
        private void m_mthDeleteDiagnoses(string ID)
        {

        }
        #endregion
        #region 删除处方明细
        private void m_mthDeleteRecipeDetail(string ID)
        {
            objSvc.m_mthDeleteRecipeDetail(ID);
        }
        #endregion
        #endregion

        #region 清空所有数据
        public void m_mthClearAllData()
        {
            this.m_objViewer.ctlDataGrid1.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid2.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid3.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid4.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid5.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid6.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridLis.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridTest.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridOps.m_mthDeleteAllRow();
            this.m_objViewer.btSave.Tag = null;
            this.m_objViewer.btPutIn.Tag = null;
            hasOrderID = null;
            hasOrderID = new Hashtable();
            hasMedPiece = null;
            hasMedPiece = new Hashtable();
            this.m_mthClearCaseHistory();
            //清空中药用法
            this.m_objViewer.cmbCooking.Text = "";
            this.m_objViewer.cmbCooking.SelectedIndex = -1;
            //中药服数为1
            this.m_objViewer.numericUpDown1.Value = 1;
            // 外送代煎
            this.m_objViewer.cboProxyBoilMed.SelectedIndex = 0;
            this.m_mthCreatCalObj();
            this.m_objViewer.m_PatInfo.txtCardID.Focus();
        }
        public void m_mthClearAllData2()
        {
            this.m_objViewer.ctlDataGrid1.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid2.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid3.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid4.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid5.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid6.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridLis.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridTest.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridOps.m_mthDeleteAllRow();
            this.m_objViewer.btSave.Tag = null;
            hasOrderID = null;
            hasOrderID = new Hashtable();
            hasMedPiece = null;
            hasMedPiece = new Hashtable();
            //清空中药用法
            this.m_objViewer.cmbCooking.Text = "";
            this.m_objViewer.cmbCooking.SelectedIndex = -1;
            this.m_objViewer.numericUpDown1.Value = 1;
            // 外送代煎
            this.m_objViewer.cboProxyBoilMed.SelectedIndex = 0;
            this.m_mthCreatCalObj();
            this.m_objViewer.tabControl1.SelectedIndex = 3;
            this.m_mthSetFocus();
        }
        private void m_mthClearCaseHistory()
        {
            //清空病历信息，这里的病历输入是另外一个窗。
            this.m_objViewer.objCaseHistory.m_mthClearData();

        }
        #endregion

        #region 显示处方号
        /// <summary>
        /// 显示处方号
        /// </summary>
        public void m_mthGetRepiceNo()
        {
            //			if(this.m_objViewer.m_PatInfo.PatientID.Trim()=="")
            //			{
            //			return;
            //			}
            //			DataTable dt=null;
            //			long strRet=objSvc.m_mthGetRepiceNo(this.m_objViewer.radioButton1.Tag.ToString(),out dt,this.m_objViewer.m_PatInfo.PatientID);
            //			this.m_objViewer.cmbRipecNo.Items.Clear();
            //			if(strRet>0&&dt.Rows.Count>0)
            //			{
            //				for(int i=0;i<dt.Rows.Count;i++)
            //				{
            //					this.m_objViewer.cmbRipecNo.Items.Add(dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim());
            //				}
            //			}

        }
        #endregion

        #region 根据处方号查找以往处方明细
        /// <summary>
        ///  标志处方是否已经收费 true 为已经收费, false 为未收费
        /// </summary>
        private bool m_bFalg;
        /// <summary>
        /// 根据处方号查找以往处方明细
        /// </summary>
        /// <param name="obj"></param>
        public void m_mthFindRecipeByID(clsRecipeInfo_VO obj)
        {
            string ID = obj.m_strOUTPATRECIPEID_CHR;

            #region 判断处方的状态
            //if(obj.m_intPSTATUS_INT==0||obj.m_intPSTATUS_INT==4)
            //{
            //    m_bFalg =false;
            //}
            //else
            //{
            //    m_bFalg =true;
            //}

            /* 更改：由于医生工作站只能查看到由医生所开的处方，所以复用时只能从TMP中读取 */
            m_bFalg = false;
            /****/
            #endregion

            //赋值给一个隐藏了的lable控件，为了用它的TextChange事件来判断控钮的可用状态
            this.m_objViewer.lbeFlag.Text = obj.m_intPSTATUS_INT.ToString();
            if (ID.Trim() == "")
            {
                return;
            }
            m_objViewer.numericUpDown1.Value = 1;//初始化服数为1;	

            objCalPatientCharge = new clsCalcPatientCharge(m_objViewer.m_PatInfo.PatientID, m_objViewer.m_PatInfo.PayTypeID, m_objViewer.m_PatInfo.Limit, this.m_objComInfo.m_strGetHospitalTitle(), m_objViewer.m_PatInfo.PatientType, m_objViewer.m_PatInfo.Discount);
            OPSApplyarr = new ArrayList();
            this.m_mthFindChageItemByID(ID, m_bFalg);
            this.m_objViewer.btSave.Tag = ID;
            this.m_mthFormatDataGrid();
        }

        /// <summary>
        /// 通过处方ID查找历史处方信息
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="flag"></param>
        public void m_mthFindChageItemByID(string ID, bool flag)
        {
            //非复用历史处方时清空所有处方控件信息
            if (!blnReUseRecipeByCase)
            {
                this.m_objViewer.ctlDataGrid1.m_mthDeleteAllRow();
                this.m_objViewer.ctlDataGrid2.m_mthDeleteAllRow();
                this.m_objViewer.ctlDataGrid3.m_mthDeleteAllRow();
                this.m_objViewer.ctlDataGrid4.m_mthDeleteAllRow();
                this.m_objViewer.ctlDataGrid5.m_mthDeleteAllRow();
                this.m_objViewer.ctlDataGrid6.m_mthDeleteAllRow();
                this.m_objViewer.ctlDataGridLis.m_mthDeleteAllRow();
                this.m_objViewer.ctlDataGridTest.m_mthDeleteAllRow();
                this.m_objViewer.ctlDataGridOps.m_mthDeleteAllRow();
            }

            //比较
            string FindCol = "itemid_chr";
            string FindID = "";
            string FindPayTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
            DataTable FindDt = new DataTable();

            if (HashItemCompare != null)
            {
                HashItemCompare = null;
            }
            HashItemCompare = new Hashtable();

            if (HashItemNoStock != null)
            {
                HashItemNoStock = null;
            }
            HashItemNoStock = new Hashtable();

            if (FindPayTypeID == "")
            {
                FindPayTypeID = "0001";
            }

            //修改
            decimal temp = 100;
            DataTable dt = null;
            long ret = 0;
            decimal dosage = 0;
            ret = objSvc.m_mthFindRecipeDetail1(ID, out dt, flag);//西药

            int intTemp = 0;//主组合的行号
            int row = 0;
            string ItemID = "";

            if (ret > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ItemID = dt.Rows[i]["ITEMID_CHR"].ToString();
                    //if (dt.Rows[i]["NOQTYFLAG_INT"].ToString() == "1")
                    //{
                    //    if (!HashItemNoStock.ContainsKey(ItemID))
                    //    {
                    //        HashItemNoStock.Add(ItemID, "1");
                    //    }
                    //    MessageBox.Show("提示：  \r\n\r\n" + "【" + dt.Rows[i]["ITEMNAME_VCHR"].ToString() + "】" + "目前药房暂时缺药，请选择其他相同功效的药物。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    row = this.m_objViewer.ctlDataGrid1.RowCount;
                    this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                    string strRowTemp = "";
                    if (dt.Rows[i]["ROWNO_CHR"].ToString().Trim() == "0")
                    {
                        this.m_objViewer.ctlDataGrid1[row, 0] = "";
                        this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -4;
                    }
                    else
                    {
                        this.m_objViewer.ctlDataGrid1[row, c_GroupNo] = dt.Rows[i]["ROWNO_CHR"].ToString().Trim();
                    }
                    if (row - 1 > -1)
                    {
                        strRowTemp = this.m_objViewer.ctlDataGrid1[row - 1, c_GroupNo].ToString().Trim();

                    }
                    if (strRowTemp == "")
                    {
                        strRowTemp = "0";
                    }
                    if (strRowTemp == dt.Rows[i]["ROWNO_CHR"].ToString().Trim())
                    {
                        if (dt.Rows[i]["ROWNO_CHR"].ToString().Trim() != "0")
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_IsMain] = intTemp;
                        }
                        else
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -4;
                        }
                    }
                    else
                    {
                        intTemp = i;
                        this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -1;
                    }

                    this.m_objViewer.ctlDataGrid1[row, c_Find] = dt.Rows[i]["ITEMCODE_VCHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Count] = m_mthConvertObjToDecimal(dt.Rows[i]["QTY_DEC"]);
                    dosage = m_mthConvertObjToDecimal(dt.Rows[i]["TOLQTY_DEC"]);
                    this.m_objViewer.ctlDataGrid1[row, c_Unit] = dt.Rows[i]["DOSAGEUNIT_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Name] = dt.Rows[i]["ITEMNAME_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Spec] = dt.Rows[i]["ITEMSPEC_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_UsageName] = dt.Rows[i]["USAGENAME_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_FreName] = dt.Rows[i]["FREQNAME_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Day] = m_mthConvertObjToDecimal(dt.Rows[i]["DAYS_INT"]);
                    this.m_objViewer.ctlDataGrid1[row, c_Price] = m_mthConvertObjToDecimal(dt.Rows[i]["UNITPRICE_MNY"]);
                    this.m_objViewer.ctlDataGrid1[row, c_BigUnit] = dt.Rows[i]["UNITID_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_SumMoney] = m_mthConvertObjToDecimal(dt.Rows[i]["TOLPRICE_MNY"]);
                    this.m_objViewer.ctlDataGrid1[row, c_ItemID] = dt.Rows[i]["ITEMID_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Packet] = m_mthConvertObjToDecimal(dt.Rows[i]["PACKQTY_DEC"]);
                    this.m_objViewer.ctlDataGrid1[row, c_Total] = m_mthConvertObjToDecimal(dt.Rows[i]["TOLQTY_DEC"]);
                    this.m_objViewer.ctlDataGrid1[row, c_FreDays] = m_mthConvertObjToDecimal(dt.Rows[i]["DAYS"]);
                    this.m_objViewer.ctlDataGrid1[row, c_FreTimes] = m_mthConvertObjToDecimal(dt.Rows[i]["TIMES_INT"]);
                    this.m_objViewer.ctlDataGrid1[row, c_UsageID] = dt.Rows[i]["USAGEID_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_FreID] = dt.Rows[i]["FREQID_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_UnitFlag] = dt.Rows[i]["opchargeflg_int"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Dosage] = dt.Rows[i]["DOSAGE_DEC"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_EnglishName] = dt.Rows[i]["itemengname_vchr"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_PS] = dt.Rows[i]["HYPETEST_INT"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_PSFlag] = dt.Rows[i]["HYPE_INT"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_UsageDetail] = dt.Rows[i]["DESC_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_IsCal] = 1;
                    this.m_objViewer.ctlDataGrid1[row, c_SubItemID] = dt.Rows[i]["USAGEPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_resubitem] = dt.Rows[i]["ATTACHPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_MainItemNum] = m_mthConvertObjToDecimal(dt.Rows[i]["attachitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid1[row, c_InvoiceType] = dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    temp = 100;
                    temp = m_mthConvertObjToDecimal(dt.Rows[i]["DISCOUNT_DEC"].ToString());
                    this.m_objViewer.ctlDataGrid1[row, c_DiscountName] = temp.ToString() + "%";
                    this.m_objViewer.ctlDataGrid1[row, c_Discount] = temp;
                    decimal price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Price]);
                    int int_Temp = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i]["ITEMID_CHR"].ToString(), price,
                    dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim(), dosage, 3000, temp, "", false);
                    this.m_objViewer.ctlDataGrid1[row, c_RowNo] = int_Temp;
                    if (Isdeptmed)
                    {
                        this.m_objViewer.ctlDataGrid1[row, c_DeptmedID] = dt.Rows[i]["deptmed_int"].ToString();
                        if (dt.Rows[i]["deptmed_int"].ToString() == "1")
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_Deptmed] = "是";
                            this.m_objViewer.ctlDataGrid1.m_mthSetRowColor(row, dfc, dbc);
                        }
                    }

                    #region 西药项目(调价等)更改检测
                    FindID = dt.Rows[i]["ITEMID_CHR"].ToString();
                    //获取药房
                    string m_strRealMedStoreID = string.Empty;
                    string m_strMedStoreID = this.m_strReadXML("register", "WMedicinestore", "AnyOne");
                    m_strRealMedStoreID = this.m_strGetDurgStoreID(m_strMedStoreID);
                    ret = objSvc.m_mthFindWMedicineByID(FindCol, FindID, FindPayTypeID, out FindDt, this.m_objViewer.LoginInfo.m_strEmpID, m_strRealMedStoreID);
                    if (ret > 0 && FindDt.Rows.Count == 1)
                    {
                        clsItemCompare_VO ItemCompare_VO = new clsItemCompare_VO();
                        ItemCompare_VO.ItemID = FindID;
                        ItemCompare_VO.ItemName = dt.Rows[i]["ITEMNAME_VCHR"].ToString();
                        if (dt.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim() != FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemStandard = dt.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim();
                            ItemCompare_VO.N_ItemStandard = FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim();
                        }
                        if (dt.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim() != FindDt.Rows[0]["DOSAGEUNIT_CHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemDosageUnit = dt.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                            ItemCompare_VO.N_ItemDosageUnit = FindDt.Rows[0]["DOSAGEUNIT_CHR"].ToString().Trim();
                        }

                        if (FindDt.Rows[0]["opchargeflg_int"].ToString().Trim() == "0")//判断大小单位
                        {
                            if (this.m_mthConvertObjToDecimal(dt.Rows[i]["UNITPRICE_MNY"]) != this.m_mthConvertObjToDecimal(FindDt.Rows[0]["ITEMPRICE_MNY"]))
                            {
                                ItemCompare_VO.O_ItemPrice = dt.Rows[i]["UNITPRICE_MNY"].ToString().Trim();
                                ItemCompare_VO.N_ItemPrice = FindDt.Rows[0]["ITEMPRICE_MNY"].ToString().Trim();
                            }
                        }
                        else
                        {
                            if (this.m_mthConvertObjToDecimal(dt.Rows[i]["UNITPRICE_MNY"]) != this.m_mthConvertObjToDecimal(FindDt.Rows[0]["SubMoney"]))
                            {
                                ItemCompare_VO.O_ItemPrice = dt.Rows[i]["UNITPRICE_MNY"].ToString().Trim();
                                ItemCompare_VO.N_ItemPrice = FindDt.Rows[0]["SubMoney"].ToString().Trim();
                            }
                        }
                        if (!HashItemCompare.ContainsKey(FindID))
                        {
                            HashItemCompare.Add(FindID, ItemCompare_VO);
                        }
                    }
                    #endregion
                }
            }
            //中药明细			
            ret = objSvc.m_mthFindRecipeDetail2(ID, out dt, flag);
            if (ret > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ItemID = dt.Rows[i]["ITEMID"].ToString();
                    //if (dt.Rows[i]["NOQTYFLAG_INT"].ToString() == "1")
                    //{
                    //    if (!HashItemNoStock.ContainsKey(ItemID))
                    //    {
                    //        HashItemNoStock.Add(ItemID, "2");
                    //    }
                    //    MessageBox.Show("提示：  \r\n\r\n" + "【" + dt.Rows[i]["ITEMNAME"].ToString() + "】" + "目前药房暂时缺药，请选择其他相同功效的药物。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    row = this.m_objViewer.ctlDataGrid2.RowCount;
                    this.m_objViewer.ctlDataGrid2.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid2[row, 0] = dt.Rows[i]["ITEMCODE_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 1] = m_mthConvertObjToDecimal(dt.Rows[i]["MIN_QTY_DEC"]);
                    this.m_objViewer.ctlDataGrid2[row, 2] = dt.Rows[i]["UNIT"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 3] = dt.Rows[i]["ITEMNAME"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 4] = dt.Rows[i]["DEC"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 5] = dt.Rows[i]["USAGENAME_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 6] = m_mthConvertObjToDecimal(dt.Rows[i]["price"]);
                    this.m_objViewer.ctlDataGrid2[row, 7] = m_mthConvertObjToDecimal(dt.Rows[i]["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid2[row, 8] = dt.Rows[i]["ITEMID"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 12] = m_mthConvertObjToDecimal(dt.Rows[i]["DOSAGE_DEC"]);
                    this.m_objViewer.ctlDataGrid2[row, 13] = m_mthConvertObjToDecimal(dt.Rows[i]["MAXDOSAGE_DEC"]);
                    this.m_objViewer.ctlDataGrid2[row, 14] = m_mthConvertObjToDecimal(dt.Rows[i]["MINDOSAGE_DEC"]);
                    //					this.m_objViewer.ctlDataGrid2[row,15]=m_mthConvertObjToDecimal(dt.Rows[i]["QUANTITY"]);
                    this.m_objViewer.ctlDataGrid2[row, 16] = dt.Rows[i]["itemprice_mny"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 17] = dt.Rows[i]["OPCHARGEFLG_INT"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 18] = dt.Rows[i]["PACKQTY_DEC"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 19] = dt.Rows[i]["ROWNO_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 20] = dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid2[row, 21] = dt.Rows[i]["USAGEID_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid2[row, 24] = dt.Rows[i]["itemengname_vchr"].ToString();
                    this.m_objViewer.cmbCooking.Text = dt.Rows[i]["SUMUSAGE_VCHR"].ToString();
                    temp = 100;
                    temp = m_mthConvertObjToDecimal(dt.Rows[i]["DISCOUNT_DEC"].ToString());
                    this.m_objViewer.ctlDataGrid2[row, 10] = temp.ToString() + "%";
                    this.m_objViewer.ctlDataGrid2[row, 11] = temp;
                    //					this.m_objViewer.numericUpDown1.Value=m_mthConvertObjToDecimal(dt.Rows[i]["Times"]);
                    this.m_objViewer.ctlDataGrid2[row, 9] = "-1";
                    this.m_objViewer.ctlDataGrid2[row, cm_UsageDetail] = dt.Rows[i]["UsageDetail_vchr"].ToString();

                    if (Isdeptmed)
                    {
                        this.m_objViewer.ctlDataGrid2[row, cm_DeptmedID] = dt.Rows[i]["deptmed_int"].ToString();
                        if (dt.Rows[i]["deptmed_int"].ToString() == "1")
                        {
                            this.m_objViewer.ctlDataGrid2[row, cm_Deptmed] = "是";
                            this.m_objViewer.ctlDataGrid2.m_mthSetRowColor(row, dfc, dbc);
                        }
                    }

                    m_mthCalculateAmount2(i);
                    //					this.m_objViewer.ctlDataGrid2[i,8]=objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i]["ITEMID"].ToString(),m_mthConvertObjToDecimal(dt.Rows[i]["PRICE"]),"",m_mthConvertObjToDecimal(dt.Rows[i]["MIN_QTY_DEC"])*m_mthConvertObjToDecimal(dt.Rows[i]["Times"]),3000,temp,"");
                    this.m_objViewer.numericUpDown1.Value = m_mthConvertObjToDecimal(dt.Rows[i]["Times"]);

                    #region 中药项目(调价等)更改检测
                    FindID = dt.Rows[i]["ITEMID"].ToString();
                    //获取药房
                    string m_strRealMedStoreID = string.Empty;
                    string m_strMedStoreID = this.m_strReadXML("register", "WMedicinestore", "AnyOne");
                    m_strRealMedStoreID = this.m_strGetDurgStoreID(m_strMedStoreID);
                    ret = objSvc.m_mthFindCMedicineByID(FindCol, FindID, FindPayTypeID, out FindDt, this.m_objViewer.LoginInfo.m_strEmpID, m_strRealMedStoreID);
                    if (ret > 0 && FindDt.Rows.Count == 1)
                    {
                        clsItemCompare_VO ItemCompare_VO = new clsItemCompare_VO();
                        ItemCompare_VO.ItemID = FindID;
                        ItemCompare_VO.ItemName = dt.Rows[i]["ITEMNAME"].ToString();
                        if (dt.Rows[i]["DEC"].ToString().Trim() != FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemStandard = dt.Rows[i]["DEC"].ToString().Trim();
                            ItemCompare_VO.N_ItemStandard = FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim();
                        }
                        if (dt.Rows[i]["UNIT"].ToString().Trim() != FindDt.Rows[0]["DOSAGEUNIT_CHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemDosageUnit = dt.Rows[i]["UNIT"].ToString().Trim();
                            ItemCompare_VO.N_ItemDosageUnit = FindDt.Rows[0]["DOSAGEUNIT_CHR"].ToString().Trim();
                        }
                        if (this.m_mthConvertObjToDecimal(dt.Rows[i]["price"]) != this.m_mthConvertObjToDecimal(FindDt.Rows[0]["SubMoney"]))
                        {
                            ItemCompare_VO.O_ItemPrice = dt.Rows[i]["price"].ToString().Trim();
                            ItemCompare_VO.N_ItemPrice = FindDt.Rows[0]["SubMoney"].ToString().Trim();
                        }
                        if (!HashItemCompare.ContainsKey(FindID))
                        {
                            HashItemCompare.Add(FindID, ItemCompare_VO);
                        }
                    }
                    #endregion
                }
            }
            //检验			
            ret = objSvc.m_mthFindRecipeDetail3(ID, out dt, flag);//
            if (ret > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGrid3.RowCount;
                    this.m_objViewer.ctlDataGrid3.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid3[row, t_Find] = dt.Rows[i]["ITEMCODE_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_Count] = m_mthConvertObjToDecimal(dt.Rows[i]["quantity"]);
                    this.m_objViewer.ctlDataGrid3[row, t_Name] = dt.Rows[i]["ITEMNAME"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_Spec] = dt.Rows[i]["DEC"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_Unit] = dt.Rows[i]["UNIT"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_Price] = m_mthConvertObjToDecimal(dt.Rows[i]["PRICE"]);
                    this.m_objViewer.ctlDataGrid3[row, t_SumMoney] = m_mthConvertObjToDecimal(dt.Rows[i]["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid3[row, t_ItemID] = dt.Rows[i]["ITEMID"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_PriceFlag] = dt.Rows[i]["SELFDEFINE"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_PartName] = dt.Rows[i]["sample_type_desc_vchr"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_Temp] = dt.Rows[i]["sampleid_vchr"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_OtherItemID] = dt.Rows[i]["USAGEPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_OtherCount] = m_mthConvertObjToDecimal(dt.Rows[i]["usageitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid3[row, t_resubitem] = dt.Rows[i]["ATTACHPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid3[row, t_MainItemNum] = m_mthConvertObjToDecimal(dt.Rows[i]["attachitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid3[row, t_UsageDetail] = dt.Rows[i]["itemusagedetail_vchr"].ToString();

                    temp = 100;
                    temp = m_mthConvertObjToDecimal(dt.Rows[i]["DISCOUNT_DEC"].ToString());
                    this.m_objViewer.ctlDataGrid3[row, t_DiscountName] = temp.ToString() + "%";
                    this.m_objViewer.ctlDataGrid3[row, t_Discount] = temp;
                    this.m_objViewer.ctlDataGrid3[row, t_InvoiceType] = dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid3[row, t_EnglishName] = dt.Rows[i]["itemengname_vchr"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid3[row, t_ApplyId] = "";
                    this.m_objViewer.ctlDataGrid3[row, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i]["ITEMID"].ToString(),
                    m_mthConvertObjToDecimal(dt.Rows[i]["PRICE"]), dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dt.Rows[i]["quantity"]), 3000, temp, "", false);

                    this.m_objViewer.ctlDataGrid3[row, t_quickid] = dt.Rows[i]["QUICKFLAG_INT"].ToString().Trim();
                    if (dt.Rows[i]["QUICKFLAG_INT"].ToString().Trim() == "1")
                    {
                        this.m_objViewer.ctlDataGrid3[row, t_quick] = "是";
                        this.m_objViewer.ctlDataGrid3.m_mthSetRowColor(row, Color.FromArgb(255, 255, 255), Color.FromArgb(250, 89, 69));
                    }

                    #region 检验项目(调价等)更改检测
                    FindID = dt.Rows[i]["ITEMID"].ToString();
                    ret = objSvc.m_mthFindTestChargeByID(FindCol, FindID, FindPayTypeID, out FindDt, this.m_objViewer.LoginInfo.m_strEmpID);
                    if (ret > 0 && FindDt.Rows.Count == 1)
                    {
                        clsItemCompare_VO ItemCompare_VO = new clsItemCompare_VO();
                        ItemCompare_VO.ItemID = FindID;
                        ItemCompare_VO.ItemName = dt.Rows[i]["ITEMNAME"].ToString();
                        if (dt.Rows[i]["DEC"].ToString().Trim() != FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemStandard = dt.Rows[i]["DEC"].ToString().Trim();
                            ItemCompare_VO.N_ItemStandard = FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim();
                        }
                        if (dt.Rows[i]["UNIT"].ToString().Trim() != FindDt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemDosageUnit = dt.Rows[i]["UNIT"].ToString().Trim();
                            ItemCompare_VO.N_ItemDosageUnit = FindDt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim();
                        }
                        if (this.m_mthConvertObjToDecimal(dt.Rows[i]["price"]) != this.m_mthConvertObjToDecimal(FindDt.Rows[0]["ITEMPRICE_MNY"]))
                        {
                            ItemCompare_VO.O_ItemPrice = dt.Rows[i]["price"].ToString().Trim();
                            ItemCompare_VO.N_ItemPrice = FindDt.Rows[0]["ITEMPRICE_MNY"].ToString().Trim();
                        }
                        if (!HashItemCompare.ContainsKey(FindID))
                        {
                            HashItemCompare.Add(FindID, ItemCompare_VO);
                        }
                    }
                    #endregion
                }
            }
            //检查
            ret = objSvc.m_mthFindRecipeDetail4(ID, out dt, flag);
            if (ret > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGrid4.RowCount;
                    this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid4[row, t_Find] = dt.Rows[i]["ITEMCODE_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_Count] = m_mthConvertObjToDecimal(dt.Rows[i]["quantity"]);
                    this.m_objViewer.ctlDataGrid4[row, t_Name] = dt.Rows[i]["ITEMNAME"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_Spec] = dt.Rows[i]["DEC"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_Unit] = dt.Rows[i]["UNIT"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_Price] = m_mthConvertObjToDecimal(dt.Rows[i]["PRICE"]);
                    this.m_objViewer.ctlDataGrid4[row, t_SumMoney] = m_mthConvertObjToDecimal(dt.Rows[i]["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid4[row, t_ItemID] = dt.Rows[i]["ITEMID"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_PriceFlag] = dt.Rows[i]["SELFDEFINE"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_PartName] = dt.Rows[i]["partname"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_Temp] = dt.Rows[i]["CHECKPARTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_OtherItemID] = dt.Rows[i]["USAGEPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_OtherCount] = m_mthConvertObjToDecimal(dt.Rows[i]["usageitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid4[row, t_resubitem] = dt.Rows[i]["ATTACHPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_MainItemNum] = m_mthConvertObjToDecimal(dt.Rows[i]["attachitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid4[row, t_UsageDetail2] = dt.Rows[i]["itemusagedetail_vchr"].ToString();
                    this.m_objViewer.ctlDataGrid4[row, t_UsageID] = dt.Rows[i]["usageid_chr"].ToString();

                    temp = 100;
                    temp = m_mthConvertObjToDecimal(dt.Rows[i]["DISCOUNT_DEC"].ToString());
                    this.m_objViewer.ctlDataGrid4[row, t_DiscountName] = temp.ToString() + "%";
                    this.m_objViewer.ctlDataGrid4[row, t_Discount] = temp;
                    this.m_objViewer.ctlDataGrid4[row, t_InvoiceType] = dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid4[row, t_EnglishName] = dt.Rows[i]["itemengname_vchr"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid4[row, t_ApplyId] = "";
                    this.m_objViewer.ctlDataGrid4[row, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i]["ITEMID"].ToString(),
                    m_mthConvertObjToDecimal(dt.Rows[i]["PRICE"]), dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dt.Rows[i]["quantity"]), 3000, temp, "", false);

                    #region 检查项目(调价等)更改检测
                    FindID = dt.Rows[i]["ITEMID"].ToString();
                    ret = objSvc.m_mthFindExamineChargeByID(FindCol, FindID, FindPayTypeID, out FindDt, this.m_objViewer.LoginInfo.m_strEmpID);
                    if (ret > 0 && FindDt.Rows.Count == 1)
                    {
                        clsItemCompare_VO ItemCompare_VO = new clsItemCompare_VO();
                        ItemCompare_VO.ItemID = FindID;
                        ItemCompare_VO.ItemName = dt.Rows[i]["ITEMNAME"].ToString();
                        if (dt.Rows[i]["DEC"].ToString().Trim() != FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemStandard = dt.Rows[i]["DEC"].ToString().Trim();
                            ItemCompare_VO.N_ItemStandard = FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim();
                        }
                        if (dt.Rows[i]["UNIT"].ToString().Trim() != FindDt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemDosageUnit = dt.Rows[i]["UNIT"].ToString().Trim();
                            ItemCompare_VO.N_ItemDosageUnit = FindDt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim();
                        }
                        if (this.m_mthConvertObjToDecimal(dt.Rows[i]["price"]) != this.m_mthConvertObjToDecimal(FindDt.Rows[0]["ITEMPRICE_MNY"]))
                        {
                            ItemCompare_VO.O_ItemPrice = dt.Rows[i]["price"].ToString().Trim();
                            ItemCompare_VO.N_ItemPrice = FindDt.Rows[0]["ITEMPRICE_MNY"].ToString().Trim();
                        }
                        if (!HashItemCompare.ContainsKey(FindID))
                        {
                            HashItemCompare.Add(FindID, ItemCompare_VO);
                        }
                    }
                    #endregion
                }
            }
            //手术
            ret = objSvc.m_mthFindRecipeDetail5(ID, out dt, flag);
            if (ret > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGrid5.RowCount;
                    this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid5[row, o_Find] = dt.Rows[i]["ITEMCODE_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid5[row, o_Count] = m_mthConvertObjToDecimal(dt.Rows[i]["quantity"]);
                    this.m_objViewer.ctlDataGrid5[row, o_Name] = dt.Rows[i]["ITEMNAME"].ToString();
                    this.m_objViewer.ctlDataGrid5[row, o_Spec] = dt.Rows[i]["DEC"].ToString();
                    this.m_objViewer.ctlDataGrid5[row, o_Unit] = dt.Rows[i]["UNIT"].ToString();
                    this.m_objViewer.ctlDataGrid5[row, o_Price] = m_mthConvertObjToDecimal(dt.Rows[i]["PRICE"]);
                    this.m_objViewer.ctlDataGrid5[row, o_SumMoney] = m_mthConvertObjToDecimal(dt.Rows[i]["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid5[row, o_ItemID] = dt.Rows[i]["ITEMID"].ToString();
                    this.m_objViewer.ctlDataGrid5[row, o_PriceFlag] = dt.Rows[i]["SELFDEFINE"].ToString();
                    this.m_objViewer.ctlDataGrid5[row, o_OtherItemID] = dt.Rows[i]["USAGEPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid5[row, o_OtherCount] = m_mthConvertObjToDecimal(dt.Rows[i]["usageitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid5[row, o_resubitem] = dt.Rows[i]["ATTACHPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid5[row, o_MainItemNum] = m_mthConvertObjToDecimal(dt.Rows[i]["attachitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid5[row, o_UsageDetail] = dt.Rows[i]["itemusagedetail_vchr"].ToString();
                    this.m_objViewer.ctlDataGrid5[row, o_UsageID] = dt.Rows[i]["usageid_chr"].ToString();

                    temp = 100;
                    temp = m_mthConvertObjToDecimal(dt.Rows[i]["DISCOUNT_DEC"].ToString());
                    this.m_objViewer.ctlDataGrid5[row, o_DiscountName] = temp.ToString() + "%";
                    this.m_objViewer.ctlDataGrid5[row, o_Discount] = temp;
                    this.m_objViewer.ctlDataGrid5[row, o_InvoiceType] = dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid5[row, o_EnglishName] = dt.Rows[i]["itemengname_vchr"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid5[row, o_ApplyId] = "";
                    this.m_objViewer.ctlDataGrid5[row, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i]["ITEMID"].ToString(),
                    m_mthConvertObjToDecimal(dt.Rows[i]["PRICE"]), dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dt.Rows[i]["quantity"]), 3000, temp, "", false);

                    #region 手术治疗项目(调价等)更改检测
                    FindID = dt.Rows[i]["ITEMID"].ToString();
                    ret = objSvc.m_mthFindOPSChargeByID(FindCol, FindID, FindPayTypeID, out FindDt, this.m_objViewer.LoginInfo.m_strEmpID);
                    if (ret > 0 && FindDt.Rows.Count == 1)
                    {
                        clsItemCompare_VO ItemCompare_VO = new clsItemCompare_VO();
                        ItemCompare_VO.ItemID = FindID;
                        ItemCompare_VO.ItemName = dt.Rows[i]["ITEMNAME"].ToString();
                        if (dt.Rows[i]["DEC"].ToString().Trim() != FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemStandard = dt.Rows[i]["DEC"].ToString().Trim();
                            ItemCompare_VO.N_ItemStandard = FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim();
                        }
                        if (dt.Rows[i]["UNIT"].ToString().Trim() != FindDt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemDosageUnit = dt.Rows[i]["UNIT"].ToString().Trim();
                            ItemCompare_VO.N_ItemDosageUnit = FindDt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim();
                        }
                        if (this.m_mthConvertObjToDecimal(dt.Rows[i]["price"]) != this.m_mthConvertObjToDecimal(FindDt.Rows[0]["ITEMPRICE_MNY"]))
                        {
                            ItemCompare_VO.O_ItemPrice = dt.Rows[i]["price"].ToString().Trim();
                            ItemCompare_VO.N_ItemPrice = FindDt.Rows[0]["ITEMPRICE_MNY"].ToString().Trim();
                        }
                        if (!HashItemCompare.ContainsKey(FindID))
                        {
                            HashItemCompare.Add(FindID, ItemCompare_VO);
                        }
                    }
                    #endregion
                }
            }
            //其他
            ret = objSvc.m_mthFindRecipeDetail6(ID, out dt, flag);
            if (ret > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row = this.m_objViewer.ctlDataGrid6.RowCount;
                    this.m_objViewer.ctlDataGrid6.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid6[row, o_Find] = dt.Rows[i]["ITEMCODE_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_Count] = m_mthConvertObjToDecimal(dt.Rows[i]["quantity"]);
                    this.m_objViewer.ctlDataGrid6[row, o_Name] = dt.Rows[i]["ITEMNAME"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_Spec] = dt.Rows[i]["DEC"].ToString();
                    //this.m_objViewer.ctlDataGrid6[row, o_Unit] = dt.Rows[i]["UNIT"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_Unit] = dt.Rows[i]["itemopunit_chr"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_Price] = m_mthConvertObjToDecimal(dt.Rows[i]["PRICE"]);
                    this.m_objViewer.ctlDataGrid6[row, o_SumMoney] = m_mthConvertObjToDecimal(dt.Rows[i]["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid6[row, o_ItemID] = dt.Rows[i]["ITEMID"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_PriceFlag] = dt.Rows[i]["SELFDEFINE"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_OtherItemID] = dt.Rows[i]["USAGEPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_OtherCount] = m_mthConvertObjToDecimal(dt.Rows[i]["usageitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid6[row, o_resubitem] = dt.Rows[i]["ATTACHPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_MainItemNum] = m_mthConvertObjToDecimal(dt.Rows[i]["attachitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid6[row, o_UsageDetail2] = dt.Rows[i]["itemusagedetail_vchr"].ToString();

                    temp = 100;
                    temp = m_mthConvertObjToDecimal(dt.Rows[i]["DISCOUNT_DEC"].ToString());
                    this.m_objViewer.ctlDataGrid6[row, o_DiscountName] = temp.ToString() + "%";
                    this.m_objViewer.ctlDataGrid6[row, o_Discount] = temp;
                    this.m_objViewer.ctlDataGrid6[row, o_InvoiceType] = dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid6[row, o_EnglishName] = dt.Rows[i]["itemengname_vchr"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid6[row, o_ApplyId] = dt.Rows[i]["ATTACHID_VCHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid6[row, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i]["ITEMID"].ToString(),
                    m_mthConvertObjToDecimal(dt.Rows[i]["PRICE"]), dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dt.Rows[i]["quantity"]), 3000, temp, "", false);

                    if (Isdeptmed)
                    {
                        this.m_objViewer.ctlDataGrid6[row, o_DeptmedID] = dt.Rows[i]["deptmed_int"].ToString();
                        if (dt.Rows[i]["deptmed_int"].ToString() == "1")
                        {
                            this.m_objViewer.ctlDataGrid6[row, o_Deptmed] = "是";
                            this.m_objViewer.ctlDataGrid6.m_mthSetRowColor(row, dfc, dbc);
                        }
                    }

                    #region 其他项目(调价等)更改检测
                    FindID = dt.Rows[i]["ITEMID"].ToString();
                    ret = objSvc.m_mthFindOtherChargeByID(FindCol, FindID, FindPayTypeID, out FindDt, this.m_objViewer.LoginInfo.m_strEmpID);
                    if (ret > 0 && FindDt.Rows.Count == 1)
                    {
                        clsItemCompare_VO ItemCompare_VO = new clsItemCompare_VO();
                        ItemCompare_VO.ItemID = FindID;
                        ItemCompare_VO.ItemName = dt.Rows[i]["ITEMNAME"].ToString();
                        if (dt.Rows[i]["DEC"].ToString().Trim() != FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemStandard = dt.Rows[i]["DEC"].ToString().Trim();
                            ItemCompare_VO.N_ItemStandard = FindDt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim();
                        }
                        if (dt.Rows[i]["UNIT"].ToString().Trim() != FindDt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim())
                        {
                            ItemCompare_VO.O_ItemDosageUnit = dt.Rows[i]["UNIT"].ToString().Trim();
                            ItemCompare_VO.N_ItemDosageUnit = FindDt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim();
                        }
                        if (this.m_mthConvertObjToDecimal(dt.Rows[i]["price"]) != this.m_mthConvertObjToDecimal(FindDt.Rows[0]["ITEMPRICE_MNY"]))
                        {
                            ItemCompare_VO.O_ItemPrice = dt.Rows[i]["price"].ToString().Trim();
                            ItemCompare_VO.N_ItemPrice = FindDt.Rows[0]["ITEMPRICE_MNY"].ToString().Trim();
                        }
                        if (!HashItemCompare.ContainsKey(FindID))
                        {
                            HashItemCompare.Add(FindID, ItemCompare_VO);
                        }
                    }
                    #endregion
                }
            }
            //显示总金额
            this.m_mthCalculateTotalMoney();
            this.m_mthFormatDataGrid();

            //显示调整信息
            if (this.HashItemCompare.Count > 0)
            {
                string msg = "";
                string Ent = "\r\n\r\n";
                ArrayList ItemCompArr = new ArrayList();
                ItemCompArr.AddRange(this.HashItemCompare.Values);
                for (int i = 0; i < ItemCompArr.Count; i++)
                {
                    clsItemCompare_VO ItemCompare_VO = ItemCompArr[i] as clsItemCompare_VO;
                    if (ItemCompare_VO.O_ItemStandard.ToString().Trim() != "" || ItemCompare_VO.O_ItemDosageUnit.ToString().Trim() != "" || ItemCompare_VO.O_ItemPrice.ToString().Trim() != "")
                    {
                        msg += "【" + ItemCompare_VO.ItemName + "】" + Ent;
                        if (ItemCompare_VO.O_ItemStandard.ToString().Trim() != "")
                        {
                            msg += "规格:" + ItemCompare_VO.O_ItemStandard.ToString().Trim() + " -> " + ItemCompare_VO.N_ItemStandard.ToString().Trim() + Ent;
                        }
                        if (ItemCompare_VO.O_ItemDosageUnit.ToString().Trim() != "")
                        {
                            msg += "单位:" + ItemCompare_VO.O_ItemDosageUnit.ToString().Trim() + " -> " + ItemCompare_VO.N_ItemDosageUnit.ToString().Trim() + Ent;
                        }
                        if (ItemCompare_VO.O_ItemPrice.ToString().Trim() != "")
                        {
                            msg += "单价:" + ItemCompare_VO.O_ItemPrice.ToString().Trim() + " -> " + ItemCompare_VO.N_ItemPrice.ToString().Trim() + Ent;
                        }
                    }
                }

                if (msg != "")
                {
                    msg += "请医生重新录入已变动的收费项目，谢谢！";
                    MessageBox.Show(msg, "收费项目变动提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region 快捷键功能
        /// <summary>
        /// 快捷键功能
        /// </summary>
        /// <param name="e"></param>
        public void m_mthFormKeyDown(System.Windows.Forms.KeyEventArgs e)
        {
            if (e.Alt)
            {
                this.m_objViewer.HandleInput = true;
                //				if(e.KeyCode==Keys.Z)
                //				{
                //					this.m_objViewer.m_PatInfo.txtType.Select();
                //					this.m_objViewer.m_PatInfo.txtType.SelectAll();
                //				}

                if (e.KeyCode == Keys.C)
                {
                    string pid = this.m_objViewer.m_PatInfo.PatientID.Trim();

                    if (Isregpatinfo == 0)
                    {
                        return;
                    }
                    else if (Isregpatinfo == 2)
                    {
                        if (pid == "")
                        {
                            return;
                        }
                    }

                    com.digitalwave.iCare.gui.Patient.frmPatient frm = new com.digitalwave.iCare.gui.Patient.frmPatient();
                    frm.LoginInfo = this.m_objViewer.LoginInfo;
                    frm.PID = pid;
                    frm.btnParticular_Click(null, null);
                    DialogResult drt = frm.ShowDialog();

                    if (drt == DialogResult.OK)
                    {
                        this.m_objViewer.m_PatInfo.m_mthGetPatientInfoByID(frm.m_strPatientID);
                    }
                    if (drt == DialogResult.Yes)
                    {
                        //if(frm.m_strPatientID.Trim()==this.m_objViewer.PatientID.Trim())//如果是同一病人直接更新数据
                        //{
                        //    this.m_objViewer.m_PatInfo.PatientBirth = frm.PatientInfo.m_strBIRTH_DAT;
                        //    DateTime dt = DateTime.Parse(frm.PatientInfo.m_strBIRTH_DAT);
                        //    int year = DateTime.Now.Year - dt.Year;
                        //    this.m_objViewer.m_PatInfo.PatientAge = year.ToString();
                        //    this.m_objViewer.m_PatInfo.PatientHomeAddress = frm.PatientInfo.m_strHOMEADDRESS_VCHR;
                        //    this.m_objViewer.m_PatInfo.PatientName = frm.PatientInfo.m_strFIRSTNAME_VCHR;
                        //    this.m_objViewer.m_PatInfo.PatientSex = frm.PatientInfo.m_strSEX_CHR;
                        //    this.m_objViewer.m_PatInfo.PatientTelephoneNo = frm.PatientInfo.m_strHOMEPHONE_VCHR;

                        //    string strCardID = this.m_objViewer.m_PatInfo.PatientCardID;
                        //    for(int i=0; i<this.m_objViewer.m_dtgTake.RowCount; i++)
                        //    {
                        //        if(this.m_objViewer.m_dtgTake[i,2].ToString().Trim()==strCardID)
                        //        {										
                        //            this.m_objViewer.m_dtgTake[i,3] = this.m_objViewer.m_PatInfo.PatientName;
                        //            this.m_objViewer.m_dtgTake[i,4] = this.m_objViewer.m_PatInfo.PatientSex;
                        //            this.m_objViewer.m_dtgTake[i,5] = this.m_objViewer.m_PatInfo.PatientAge;								
                        //            break;
                        //        }
                        //    }
                        //}
                        //else
                        //{
                        this.m_objViewer.m_PatInfo.m_mthGetPatientInfoByID(frm.m_strPatientID);//不同病人则重新加载
                        //}
                    }

                    frm.Close();
                }
            }
            if (e.Control)
            {
                this.m_objViewer.HandleInput = true;
                if (e.KeyCode == Keys.A)
                {
                    if (this.m_objViewer.m_PatInfo.PatientID.Trim() != "")
                    {
                        frmDoctYBSpecDea fyb = new frmDoctYBSpecDea();
                        if (fyb.ShowDialog() == DialogResult.OK)
                        {
                            if (this.m_objViewer.objCaseHistory.txtDiag.Text.Trim() != "")
                            {
                                this.m_objViewer.objCaseHistory.txtDiag.Text += "; " + fyb.DiseaseName;
                            }
                            else
                            {
                                this.m_objViewer.objCaseHistory.txtDiag.Text = fyb.DiseaseName;
                            }
                            this.m_objViewer.objCaseHistory.m_objIcd10Bind_OnReturnData(fyb.ObjICD10);
                        }
                    }
                }
                else if (e.KeyCode == Keys.T)
                {
                    this.m_mthShowTestApply(-1);
                }
                else if (e.KeyCode == Keys.M)  //详细用法
                {
                    #region 西药
                    if (this.m_objViewer.tabControl1.SelectedIndex == 3 && this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_ItemID].ToString().Trim() != "")
                    {
                        //皮试药标志
                        bool blnPsFlag = false;
                        if (this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_PSFlag].ToString().Trim() == "1")
                        {
                            blnPsFlag = true;
                        }

                        frmMedicineUsageDetail frmTemp = new frmMedicineUsageDetail(blnPsFlag);
                        frmTemp.Tag = this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_GroupNo].ToString().Trim();
                        frmTemp.MedicineName = this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_Name].ToString().Trim();
                        frmTemp.Check = this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_PS].ToString().Trim();
                        frmTemp.UsageDetail = this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_UsageDetail].ToString().Trim();
                        frmTemp.lbeMedicine.Tag = this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_ItemID].ToString().Trim();
                        if (frmTemp.ShowDialog() == DialogResult.OK)
                        {
                            if (frmTemp.Tag.ToString() == "")
                            {
                                this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_PS] = frmTemp.Check;
                                //皮试以红色显示
                                if (frmTemp.Check == "1")
                                {
                                    this.m_objViewer.ctlDataGrid1.m_mthFormatCell(this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Red);
                                }
                                else
                                {
                                    this.m_objViewer.ctlDataGrid1.m_mthFormatCell(this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Black);
                                }

                                this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_UsageDetail] = frmTemp.UsageDetail.Replace("'", " ");
                            }
                            else
                            {
                                for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
                                {
                                    if (this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim() == frmTemp.Tag.ToString())
                                    {
                                        this.m_objViewer.ctlDataGrid1[i, c_PS] = frmTemp.Check;
                                        //皮试以红色显示
                                        if (frmTemp.Check == "1")
                                        {
                                            this.m_objViewer.ctlDataGrid1.m_mthFormatCell(i, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Red);
                                        }
                                        else
                                        {
                                            this.m_objViewer.ctlDataGrid1.m_mthFormatCell(i, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Black);
                                        }

                                        this.m_objViewer.ctlDataGrid1[i, c_UsageDetail] = frmTemp.UsageDetail.Replace("'", " ");
                                    }
                                }
                            }
                        }
                    }
                    #endregion
                    #region 中药
                    else if (this.m_objViewer.tabControl1.SelectedIndex == 4 && this.m_objViewer.ctlDataGrid2[this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 8].ToString().Trim() != "")
                    {
                        frmMedicineUsageDetail frmTemp = new frmMedicineUsageDetail(false);
                        frmTemp.MedicineName = this.m_objViewer.ctlDataGrid2[this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 3].ToString().Trim();
                        frmTemp.Check = "0";
                        frmTemp.UsageDetail = this.m_objViewer.ctlDataGrid2[this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, cm_UsageDetail].ToString().Trim();
                        frmTemp.lbeMedicine.Tag = this.m_objViewer.ctlDataGrid2[this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 8].ToString().Trim();
                        if (frmTemp.ShowDialog() == DialogResult.OK)
                        {
                            this.m_objViewer.ctlDataGrid2[this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, cm_UsageDetail] = frmTemp.UsageDetail.Replace("'", " ");
                        }
                    }
                    #endregion
                    #region 检验
                    else if (this.m_objViewer.tabControl1.SelectedIndex == 5 && this.m_objViewer.ctlDataGrid3[this.m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_ItemID].ToString().Trim() != "")
                    {
                        frmMedicineUsageDetail frmTemp = new frmMedicineUsageDetail(false);
                        frmTemp.MedicineName = this.m_objViewer.ctlDataGrid3[this.m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_Name].ToString().Trim();
                        frmTemp.Check = "0";
                        frmTemp.UsageDetail = this.m_objViewer.ctlDataGrid3[this.m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_UsageDetail].ToString().Trim();
                        frmTemp.lbeMedicine.Tag = this.m_objViewer.ctlDataGrid3[this.m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_ItemID].ToString().Trim();
                        if (frmTemp.ShowDialog() == DialogResult.OK)
                        {
                            this.m_objViewer.ctlDataGrid3[this.m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_UsageDetail] = frmTemp.UsageDetail.Replace("'", " ");
                        }
                    }
                    #endregion
                    #region 检查
                    else if (this.m_objViewer.tabControl1.SelectedIndex == 6 && this.m_objViewer.ctlDataGrid4[this.m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, t_ItemID].ToString().Trim() != "")
                    {
                        frmMedicineUsageDetail frmTemp = new frmMedicineUsageDetail(false);
                        frmTemp.MedicineName = this.m_objViewer.ctlDataGrid4[this.m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, t_Name].ToString().Trim();
                        frmTemp.Check = "0";
                        frmTemp.UsageDetail = this.m_objViewer.ctlDataGrid4[this.m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, t_UsageDetail2].ToString().Trim();
                        frmTemp.lbeMedicine.Tag = this.m_objViewer.ctlDataGrid4[this.m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, t_ItemID].ToString().Trim();
                        if (frmTemp.ShowDialog() == DialogResult.OK)
                        {
                            this.m_objViewer.ctlDataGrid4[this.m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, t_UsageDetail2] = frmTemp.UsageDetail.Replace("'", " ");
                        }
                    }
                    #endregion
                    #region 手术治疗
                    else if (this.m_objViewer.tabControl1.SelectedIndex == 7 && this.m_objViewer.ctlDataGrid5[this.m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, o_ItemID].ToString().Trim() != "")
                    {
                        frmMedicineUsageDetail frmTemp = new frmMedicineUsageDetail(false);
                        frmTemp.MedicineName = this.m_objViewer.ctlDataGrid5[this.m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, o_Name].ToString().Trim();
                        frmTemp.Check = "0";
                        frmTemp.UsageDetail = this.m_objViewer.ctlDataGrid5[this.m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, o_UsageDetail].ToString().Trim();
                        frmTemp.lbeMedicine.Tag = this.m_objViewer.ctlDataGrid5[this.m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, o_ItemID].ToString().Trim();
                        if (frmTemp.ShowDialog() == DialogResult.OK)
                        {
                            this.m_objViewer.ctlDataGrid5[this.m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, o_UsageDetail] = frmTemp.UsageDetail.Replace("'", " ");
                        }
                    }
                    #endregion
                    #region 其他
                    else if (this.m_objViewer.tabControl1.SelectedIndex == 8 && this.m_objViewer.ctlDataGrid6[this.m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, o_ItemID].ToString().Trim() != "")
                    {
                        frmMedicineUsageDetail frmTemp = new frmMedicineUsageDetail(false);
                        frmTemp.MedicineName = this.m_objViewer.ctlDataGrid6[this.m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, o_Name].ToString().Trim();
                        frmTemp.Check = "0";
                        frmTemp.UsageDetail = this.m_objViewer.ctlDataGrid6[this.m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, o_UsageDetail2].ToString().Trim();
                        frmTemp.lbeMedicine.Tag = this.m_objViewer.ctlDataGrid6[this.m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, o_ItemID].ToString().Trim();
                        if (frmTemp.ShowDialog() == DialogResult.OK)
                        {
                            this.m_objViewer.ctlDataGrid6[this.m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, o_UsageDetail2] = frmTemp.UsageDetail.Replace("'", " ");
                        }
                    }
                    #endregion
                }
                else if (e.KeyCode == Keys.U)
                {
                    this.m_mthApplyCheck();
                }
                else if (e.KeyCode == Keys.D)
                {
                    if (this.m_objViewer.m_cmbRecipeType.SelectedIndex == this.m_objViewer.m_cmbRecipeType.Items.Count - 1)
                    {
                        this.m_objViewer.m_cmbRecipeType.SelectedIndex = 0;
                    }
                    else
                    {
                        this.m_objViewer.m_cmbRecipeType.SelectedIndex += 1;
                    }
                }
                else if (e.KeyCode == Keys.K)
                {
                    if (this.m_objViewer.cmbRecipeType.SelectedIndex == this.m_objViewer.cmbRecipeType.Items.Count - 1)
                    {
                        this.m_objViewer.cmbRecipeType.SelectedIndex = 0;
                    }
                    else
                    {
                        this.m_objViewer.cmbRecipeType.SelectedIndex += 1;
                    }
                }
                else if (e.KeyCode == Keys.Q)
                {
                    if (ItemInputMode == 0)
                    {
                        m_mthCreatTemplat();
                    }
                    else if (ItemInputMode == 1)
                    {
                        this.m_mthCreateAccordRecipe();
                    }
                }
                else if (e.KeyCode == Keys.N)
                {
                    this.m_mthShowPriceInfo();
                }
                else if (e.KeyCode == Keys.S)
                {
                    frmShowReports obj = new frmShowReports();
                    obj.ReadOnly = true;
                    obj.PatientCardID = this.m_objViewer.m_PatInfo.PatientCardID;
                    obj.PatientID = this.m_objViewer.m_PatInfo.PatientID;
                    obj.PatientName = this.m_objViewer.m_PatInfo.PatientName;
                    obj.PatientSex = this.m_objViewer.m_PatInfo.PatientSex;
                    obj.PatientAge = this.m_objViewer.m_PatInfo.PatientAge;
                    obj.ShowDialog();

                }
                else if (e.KeyCode == Keys.W)
                {
                    frmOPLog obj = new frmOPLog();
                    obj.DoctorID = this.m_objViewer.LoginInfo.m_strEmpID;
                    obj.Show_MDI_Child(this.m_objViewer.MdiParent);

                }
                else if (e.KeyCode == Keys.I)
                {
                    this.m_mthOpenInHospitalCard();
                }
                else if (e.KeyCode == Keys.L)
                {
                    if (this.m_objViewer.m_PatInfo.PatientID.Trim() != "")
                    {
                        frmHistoryMedicine objTemp = new frmHistoryMedicine(this.objSvc);
                        objTemp.PatientID = this.m_objViewer.m_PatInfo.PatientID;
                        objTemp.ShowDialog();
                    }
                }
                else if (e.KeyCode == Keys.G)
                {
                    if (this.m_objViewer.m_PatInfo.Hypersusceptibility.Trim() != "")
                    {
                        if (this.m_objViewer.frmAllergich != null)
                        {
                            this.m_objViewer.frmAllergich.Show();
                        }
                    }
                }
                else if (e.KeyCode == Keys.F)
                {
                    string name = this.m_objViewer.m_PatInfo.txtPatient.Text.Trim();
                    if (name != "")
                    {
                        frmShowPatient fsp = new frmShowPatient();
                        fsp.m_SetPatientName = name;
                        if (fsp.ShowDialog() == DialogResult.OK)
                        {
                            string CardID = fsp.m_GetCardID;
                            this.m_objViewer.m_PatInfo.txtCardID.Text = CardID;
                            this.m_objViewer.m_PatInfo.m_mthGetPatientInfoByCard(CardID);
                        }
                    }
                }

                e.Handled = true;
                return;
            }
            switch (e.KeyCode)
            {
                case Keys.F1:
                    frmHelp objhelp = new frmHelp();
                    objhelp.SetObj = this;
                    objhelp.ShowDialog();
                    break;
                case Keys.F2:
                    this.m_mthSetFocus();
                    break;
                case Keys.F3:
                    if (this.m_objViewer.btSave.Enabled == true)//保存
                    {
                        this.m_objViewer.btSave.Enabled = false;
                        this.m_mthSaveAllData();
                        this.m_objViewer.btSave.Enabled = true;
                    }
                    break;
                case Keys.F4:
                    this.m_mthChangePage();
                    break;
                case Keys.F5:
                    if (this.m_objViewer.m_cmbFind.SelectedIndex == this.m_objViewer.m_cmbFind.Items.Count - 1)
                    {
                        this.m_objViewer.m_cmbFind.SelectedIndex = 0;
                    }
                    else
                    {
                        this.m_objViewer.m_cmbFind.SelectedIndex += 1;
                    }
                    break;
                //				case Keys.F6:
                //					if(this.m_objViewer.m_cmbRecipeType.SelectedIndex==this.m_objViewer.m_cmbRecipeType.Items.Count-1)
                //					{
                //						this.m_objViewer.m_cmbRecipeType.SelectedIndex=0;
                //					}
                //					else
                //					{
                //						this.m_objViewer.m_cmbRecipeType.SelectedIndex+=1;
                //					}
                //					break;
                case Keys.F7:
                    this.m_objViewer.txtLoadRecipeNo1.m_mthSetFoucs();
                    break;
                case Keys.F8:
                    if (this.m_objViewer.cmbCooking.SelectedIndex == this.m_objViewer.cmbCooking.Items.Count - 1)
                    {
                        this.m_objViewer.cmbCooking.SelectedIndex = 0;
                    }
                    else
                    {
                        this.m_objViewer.cmbCooking.SelectedIndex += 1;
                    }
                    break;
                case Keys.F9:

                    this.m_mthShowMedicineInfo();//显示药品信息
                    break;
                case Keys.F10:
                    this.m_objViewer.m_PatInfo.txtType.Select();
                    this.m_objViewer.m_PatInfo.txtType.SelectAll();
                    break;
                case Keys.F11:
                    this.m_objViewer.numericUpDown1.UpButton();
                    break;
                case Keys.F12:
                    this.m_objViewer.numericUpDown1.DownButton();
                    break;
                case Keys.Escape:
                    if (this.m_objViewer.listView1.Focused || this.m_objViewer.listView2.Focused ||
                        this.m_objViewer.listView3.Focused || this.m_objViewer.listView4.Focused ||
                        this.m_objViewer.listView5.Focused)
                    {
                        return;
                    }

                    this.m_objViewer.Close();
                    break;

            }
        }
        private void m_mthChangePage()
        {
            if (this.m_objViewer.tabControl1.SelectedIndex == this.m_objViewer.tabControl1.TabCount - 1)
            {
                this.m_objViewer.tabControl1.SelectedIndex = 0;
            }
            else
            {
                this.m_objViewer.tabControl1.SelectedIndex += 1;
            }
        }
        /// <summary>
        /// 在转页时不转变
        /// </summary>
        public bool b_IndexChangeFlag = true;
        public void m_mthSetFocus()
        {
            //			b_IndexChangeFlag =true;
            this.m_objViewer.btReGroup.Enabled = false;
            switch (this.m_objViewer.tabControl1.SelectedIndex)
            {
                case 0:

                    break;

                case 1:

                    break;

                case 2:
                    this.m_objViewer.objCaseHistory.m_mthSetFouces();
                    break;
                case 3:

                    this.m_objViewer.btReGroup.Enabled = true;
                    for (int i1 = this.m_objViewer.ctlDataGrid1.RowCount - 1; i1 >= 0; i1--)
                    {
                        if (this.m_objViewer.ctlDataGrid1[i1, 11].ToString() == "" && this.m_objViewer.ctlDataGrid1.RowCount != 1)
                        {
                            this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i1);
                        }
                    }
                    int row = m_objViewer.ctlDataGrid1.RowCount;
                    m_objViewer.ctlDataGrid1.Select();
                    m_objViewer.ctlDataGrid1.Focus();
                    m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, 0);
                    SendKeys.SendWait("{Right}");
                    SendKeys.SendWait("{Left}");
                    break;
                case 4:
                    for (int i2 = this.m_objViewer.ctlDataGrid2.RowCount - 1; i2 >= 0; i2--)
                    {
                        if (this.m_objViewer.ctlDataGrid2[i2, 7].ToString() == "" && this.m_objViewer.ctlDataGrid2.RowCount != 1)
                        {
                            this.m_objViewer.ctlDataGrid2.m_mthDeleteRow(i2);
                        }
                    }
                    int row2 = m_objViewer.ctlDataGrid2.RowCount;
                    m_objViewer.ctlDataGrid2.Select();
                    m_objViewer.ctlDataGrid2.Focus();
                    m_objViewer.ctlDataGrid2.CurrentCell = new DataGridCell(row2, 0);
                    break;
                case 5:
                    if (ItemInputMode == 0)
                    {
                        for (int i3 = this.m_objViewer.ctlDataGrid3.RowCount - 1; i3 >= 0; i3--)
                        {
                            if (this.m_objViewer.ctlDataGrid3[i3, 7].ToString() == "" && this.m_objViewer.ctlDataGrid3.RowCount != 1)
                            {
                                this.m_objViewer.ctlDataGrid3.m_mthDeleteRow(i3);
                            }
                        }
                        int row3 = m_objViewer.ctlDataGrid3.RowCount;
                        m_objViewer.ctlDataGrid3.Select();
                        m_objViewer.ctlDataGrid3.Focus();
                        m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(row3, 0);
                    }
                    else if (ItemInputMode == 1)
                    {
                        for (int i3 = this.m_objViewer.ctlDataGridLis.RowCount - 1; i3 >= 0; i3--)
                        {
                            if (this.m_objViewer.ctlDataGridLis[i3, t_ItemID].ToString() == "" && this.m_objViewer.ctlDataGridLis.RowCount != 1)
                            {
                                this.m_objViewer.ctlDataGridLis.m_mthDeleteRow(i3);
                            }
                        }
                        int rowLis = m_objViewer.ctlDataGridLis.RowCount;
                        m_objViewer.ctlDataGridLis.Select();
                        m_objViewer.ctlDataGridLis.Focus();
                        m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(rowLis, 0);
                    }
                    break;
                case 6:
                    if (ItemInputMode == 0)
                    {
                        for (int i4 = this.m_objViewer.ctlDataGrid4.RowCount - 1; i4 >= 0; i4--)
                        {
                            if (this.m_objViewer.ctlDataGrid4[i4, t_ItemID].ToString() == "" && this.m_objViewer.ctlDataGrid4.RowCount != 1)
                            {
                                this.m_objViewer.ctlDataGrid4.m_mthDeleteRow(i4);
                            }
                        }

                        int row4 = m_objViewer.ctlDataGrid4.RowCount;
                        m_objViewer.ctlDataGrid4.Select();
                        m_objViewer.ctlDataGrid4.Focus();
                        m_objViewer.ctlDataGrid4.CurrentCell = new DataGridCell(row4, t_Find);
                    }
                    else if (ItemInputMode == 1)
                    {
                        for (int i4 = this.m_objViewer.ctlDataGridTest.RowCount - 1; i4 >= 0; i4--)
                        {
                            if (this.m_objViewer.ctlDataGridTest[i4, t_ItemID].ToString() == "" && this.m_objViewer.ctlDataGridTest.RowCount != 1)
                            {
                                this.m_objViewer.ctlDataGridTest.m_mthDeleteRow(i4);
                            }
                        }

                        int row4 = m_objViewer.ctlDataGridTest.RowCount;
                        m_objViewer.ctlDataGridTest.Select();
                        m_objViewer.ctlDataGridTest.Focus();
                        m_objViewer.ctlDataGridTest.CurrentCell = new DataGridCell(row4, t_Find);
                    }
                    break;
                case 7:
                    if (ItemInputMode == 0)
                    {
                        for (int i5 = this.m_objViewer.ctlDataGrid5.RowCount - 1; i5 >= 0; i5--)
                        {
                            if (this.m_objViewer.ctlDataGrid5[i5, 7].ToString().Trim() == "" && this.m_objViewer.ctlDataGrid5.RowCount != 1)
                            {
                                this.m_objViewer.ctlDataGrid5.m_mthDeleteRow(i5);
                            }
                        }
                        int row5 = m_objViewer.ctlDataGrid5.RowCount;
                        m_objViewer.ctlDataGrid5.Select();
                        m_objViewer.ctlDataGrid5.Focus();
                        m_objViewer.ctlDataGrid5.CurrentCell = new DataGridCell(row5, 0);
                    }
                    else
                    {
                        for (int i5 = this.m_objViewer.ctlDataGridOps.RowCount - 1; i5 >= 0; i5--)
                        {
                            if (this.m_objViewer.ctlDataGridOps[i5, 7].ToString().Trim() == "" && this.m_objViewer.ctlDataGridOps.RowCount != 1)
                            {
                                this.m_objViewer.ctlDataGridOps.m_mthDeleteRow(i5);
                            }
                        }
                        int row5 = m_objViewer.ctlDataGridOps.RowCount;
                        m_objViewer.ctlDataGridOps.Select();
                        m_objViewer.ctlDataGridOps.Focus();
                        m_objViewer.ctlDataGridOps.CurrentCell = new DataGridCell(row5, 0);
                    }
                    break;
                case 8:
                    for (int i6 = this.m_objViewer.ctlDataGrid6.RowCount - 1; i6 >= 0; i6--)
                    {
                        if (this.m_objViewer.ctlDataGrid6[i6, 7].ToString() == "" && this.m_objViewer.ctlDataGrid6.RowCount != 1)
                        {
                            this.m_objViewer.ctlDataGrid6.m_mthDeleteRow(i6);
                        }
                    }
                    int row6 = m_objViewer.ctlDataGrid6.RowCount;
                    m_objViewer.ctlDataGrid6.Select();
                    m_objViewer.ctlDataGrid6.Focus();
                    m_objViewer.ctlDataGrid6.CurrentCell = new DataGridCell(row6, 0);
                    break;

            }
        }

        #endregion

        #region 更改中药服数
        /// <summary>
        /// 更改中药服数后，再重新计算数量并更新到计费类。
        /// </summary>
        public void m_mthChangeCMTimes()
        {
            for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
            {

                decimal price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 6]);
                this.m_objViewer.ctlDataGrid2[i, 7] = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 15]) * price * this.m_objViewer.numericUpDown1.Value;
                this.m_mthCalculateAmount2(i);
            }
            this.m_mthCalculateTotalMoney();
        }
        #endregion

        #region 查找模板列表
        /// <summary>
        /// 调协定处方，传入查询条件。返回结果后填充到DataGrid
        /// </summary>
        /// <param name="strCode"></param>
        public void m_mthFindAccordRecipe(string strCode)
        {

            string strEmployeeID = "0000001";
            if (this.m_objViewer.LoginInfo != null)
            {
                strEmployeeID = this.m_objViewer.LoginInfo.m_strEmpID;
            }

            frmAccordRecipe objForm = new frmAccordRecipe();
            objForm.DesktopLocation = new Point(40, 30);
            objForm.FindText = strCode;
            objForm.FindIndex = m_objViewer.m_cmbFind.SelectedIndex;
            objForm.LackMedicine = this.isShowLackMedicine;
            if (objForm.ShowDialog() == DialogResult.OK)
            {
                this.IsShowOverFlow = false;
                this.m_mthFillDataGrid(objForm);
                this.IsShowOverFlow = true;
                this.m_mthIsOverFlow();
                this.m_mthCalculateTotalMoney();
                //DataGrid的Bug,要发送虚拟键才能显示光标
                SendKeys.SendWait("{Up}");
                SendKeys.SendWait("{Down}");
            }

        }
        #region 清除DataGrid的空行
        private void m_mthClearDataEmptyRow()
        {
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, 11].ToString().Trim() == "")
                {
                    this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid2[i, 8].ToString().Trim() == "")
                {
                    this.m_objViewer.ctlDataGrid2.m_mthDeleteRow(i);
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim() == "")
                {
                    this.m_objViewer.ctlDataGrid3.m_mthDeleteRow(i);
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString().Trim() == "")
                {
                    this.m_objViewer.ctlDataGrid4.m_mthDeleteRow(i);
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid5[i, 7].ToString().Trim() == "")
                {
                    this.m_objViewer.ctlDataGrid5.m_mthDeleteRow(i);
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid6[i, 7].ToString().Trim() == "")
                {
                    this.m_objViewer.ctlDataGrid6.m_mthDeleteRow(i);
                }
            }
        }
        #endregion
        private decimal m_mthGetMaxGroupID()
        {
            decimal ret = 0;
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (ret < m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_GroupNo]))
                {
                    ret = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_GroupNo]);
                }
            }
            return ret;

        }
        private void m_mthFillDataGrid(frmAccordRecipe objForm)
        {
            //have
            m_mthClearDataEmptyRow();
            decimal temp = 100;
            DataTable dt = null;
            int B = 0;
            int C = 0;
            int D = 0;
            int E = 0;
            int F = 0;
            string strTemp = "";
            int intGroup = -4;
            string groupID = m_mthGetMaxGroupID().ToString();
            int location = 0;

            if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage5))
            {
                dt = objForm.GetTable1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                    int A = this.m_objViewer.ctlDataGrid1.RowCount - 1;
                    if (dt.Rows[i][23].ToString().Trim() != "")
                    {
                        if (strTemp != dt.Rows[i][23].ToString().Trim())
                        {
                            intGroup = -1;

                            if (groupID.Trim() == "")
                            {
                                groupID = "0";
                            }
                            groupID = (int.Parse(groupID) + 1).ToString();
                            strTemp = dt.Rows[i][23].ToString().Trim();
                            location = A;
                        }
                        else
                        {
                            intGroup = location;
                        }

                    }
                    else
                    {
                        intGroup = -4;
                        groupID = "";
                    }
                    this.m_objViewer.ctlDataGrid1[A, c_Count] = m_mthConvertObjToDecimal(dt.Rows[i][17]);
                    this.m_objViewer.ctlDataGrid1[A, c_Unit] = dt.Rows[i][3].ToString();//剂量单位
                    this.m_objViewer.ctlDataGrid1[A, c_Name] = dt.Rows[i][1].ToString();//项目名称
                    this.m_objViewer.ctlDataGrid1[A, c_Spec] = dt.Rows[i][2].ToString();
                    this.m_objViewer.ctlDataGrid1[A, c_UsageName] = dt.Rows[i][10].ToString();//用法名称
                    this.m_objViewer.ctlDataGrid1[A, c_FreName] = dt.Rows[i][12].ToString();//频率名称
                    this.m_objViewer.ctlDataGrid1[A, c_Day] = m_mthConvertObjToDecimal(dt.Rows[i][20]);//天数
                    if (dt.Rows[i][8].ToString().Trim() == "1")
                    {
                        this.m_objViewer.ctlDataGrid1[A, c_Price] = m_mthConvertObjToDecimal(dt.Rows[i][4]);
                        this.m_objViewer.ctlDataGrid1[A, c_BigUnit] = dt.Rows[i][15].ToString();
                    }
                    else
                    {
                        this.m_objViewer.ctlDataGrid1[A, c_Price] = m_mthConvertObjToDecimal(dt.Rows[i][7]);
                        this.m_objViewer.ctlDataGrid1[A, c_BigUnit] = dt.Rows[i][16].ToString();
                    }

                    this.m_objViewer.ctlDataGrid1[A, c_ItemID] = dt.Rows[i][5].ToString();
                    this.m_objViewer.ctlDataGrid1[A, c_Packet] = m_mthConvertObjToDecimal(dt.Rows[i][6]);
                    this.m_objViewer.ctlDataGrid1[A, c_FreDays] = dt.Rows[i][14].ToString();//频率天数
                    this.m_objViewer.ctlDataGrid1[A, c_FreTimes] = dt.Rows[i][13].ToString();//频率次数
                    this.m_objViewer.ctlDataGrid1[A, c_UsageID] = dt.Rows[i][9].ToString();//用法ID
                    this.m_objViewer.ctlDataGrid1[A, c_FreID] = dt.Rows[i][11].ToString();//频率ID
                    this.rowNo = A;
                    this.m_objViewer.ctlDataGrid1[A, c_GroupNo] = groupID;
                    this.m_objViewer.ctlDataGrid1[A, c_IsMain] = intGroup;
                    this.m_objViewer.ctlDataGrid1[A, c_InvoiceType] = dt.Rows[i][18].ToString();//发票分类
                    this.m_objViewer.ctlDataGrid1[A, c_Dosage] = dt.Rows[i][19].ToString();//剂量数
                    this.m_objViewer.ctlDataGrid1[A, c_Find] = dt.Rows[i][21].ToString();//编号
                    this.m_objViewer.ctlDataGrid1[A, c_EnglishName] = dt.Rows[i][22].ToString();//英文名
                    this.m_objViewer.ctlDataGrid1[A, c_PSFlag] = dt.Rows[i][24].ToString();//皮试标志
                    if (dt.Rows[i][24].ToString().Trim() == "1")//如果此药要皮试则默认为皮试
                    {
                        this.m_objViewer.ctlDataGrid1[A, c_PS] = 1;
                        this.m_objViewer.ctlDataGrid1.m_mthFormatCell(A, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Red);
                    }
                    this.m_objViewer.ctlDataGrid1[A, c_IsCal] = 1;
                    temp = 100;
                    if (objCalPatientCharge != null)
                    {
                        temp = objCalPatientCharge.m_mthGetDiscountByID(dt.Rows[i][5].ToString());
                    }
                    m_objViewer.ctlDataGrid1[A, c_DiscountName] = temp.ToString() + "%";
                    m_objViewer.ctlDataGrid1[A, c_Discount] = temp;
                    m_objViewer.ctlDataGrid1[A, c_UnitFlag] = dt.Rows[i][8].ToString();
                    decimal dectime = 1;//频率天数
                    if (m_mthConvertObjToDecimal(dt.Rows[i][14]) > 0)
                    {
                        dectime = m_mthConvertObjToDecimal(dt.Rows[i][14]);
                    }
                    //总剂量
                    decimal decSum = m_mthConvertObjToDecimal(dt.Rows[i][17]) * m_mthConvertObjToDecimal(dt.Rows[i][13]) * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[A, c_Day]) / dectime;
                    decimal iii = 0;//总数
                    //包装量
                    decimal packet = m_mthConvertObjToDecimal(dt.Rows[i][6]);
                    //剂量比例
                    decimal decDosage = m_mthConvertObjToDecimal(dt.Rows[i][19]);
                    decimal Days = 0;
                    if (CalFlag)
                    {
                        Days = m_mthConvertObjToDecimal(dt.Rows[i][20]) / dectime;
                        decimal temp2 = m_mthConvertObjToDecimal(dt.Rows[i][17]);
                        iii = (decimal)Math.Ceiling((double)(temp2 / (decDosage)));
                        iii = Days * iii * this.m_mthConvertObjToDecimal(dt.Rows[i][13]);
                        if (dt.Rows[i][8].ToString().Trim() == "0")
                        {
                            iii = (decimal)Math.Ceiling((double)(iii / (packet)));
                        }
                        this.m_objViewer.ctlDataGrid1[A, c_Total] = iii;
                    }
                    else
                    {
                        if (dt.Rows[i][8].ToString().Trim() == "1")//用最小单位收费
                        {
                            iii = (decimal)Math.Ceiling((double)(decSum / decDosage));
                            this.m_objViewer.ctlDataGrid1[A, c_Total] = iii;
                            this.m_objViewer.ctlDataGrid1[A, c_SumMoney] = iii * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[A, c_Price]);

                        }
                        else//大单位
                        {

                            if (packet == 0)
                            {
                                packet = 1;
                            }

                            iii = (decimal)Math.Ceiling((double)(decSum / (packet * decDosage)));
                            this.m_objViewer.ctlDataGrid1[A, c_Total] = iii;
                        }
                        this.m_objViewer.ctlDataGrid1[A, c_SumMoney] = iii * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[A, c_Price]);

                    }
                    int int_Temp = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i][5].ToString(), m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[A, c_Price]),
                    dt.Rows[i][18].ToString(), m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[A, c_Total]), 3000, temp, "", false);
                    string strSubItem = dt.Rows[i][5].ToString();
                    this.m_objViewer.ctlDataGrid1[A, c_SubItemID] = "[PK]" + A.ToString() + "->" + strSubItem;
                    this.m_objViewer.ctlDataGrid1[A, c_RowNo] = int_Temp;
                    //根据用法带出收费项目，只有非组合项目和主组合项目才带出收费项目，同一组药的用法只带出一次
                    if (intGroup == -1 || intGroup == -4)
                    {
                        this.m_mthGetChargeItemByUsageID(dt.Rows[i][9].ToString().Trim(), false, A.ToString() + "->" + strSubItem, A);
                    }
                    decimal decTimesTemp = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[A, c_Day]) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[A, c_FreTimes]);
                    this.m_mthChangeTimeForDefaultItem(A.ToString() + "->" + strSubItem, decTimesTemp, A, 0);

                    //项目带项目
                    string strItemID = dt.Rows[i][5].ToString().Trim();
                    DataTable dtRecord = new DataTable();
                    bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                    if (blnStat)
                    {
                        m_mthGetChargeItemByItem(A.ToString() + "->" + strItemID, 0, dtRecord);
                        m_objViewer.ctlDataGrid1[A, c_resubitem] = "[PK]" + A.ToString() + "->" + strItemID;
                        m_objViewer.ctlDataGrid1[A, c_MainItemNum] = m_objViewer.ctlDataGrid1[A, c_Count];
                    }

                    if (dt.Rows[i][25].ToString() != "1")
                    {
                        this.m_objViewer.ctlDataGrid1[A, c_DeptmedID] = "*";
                    }
                }
            }

            if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage6))
            {
                dt = objForm.GetTable2;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.m_objViewer.ctlDataGrid2.m_mthAppendRow();
                    B = this.m_objViewer.ctlDataGrid2.RowCount - 1;
                    this.m_objViewer.ctlDataGrid2[B, 0] = dt.Rows[i][15].ToString();//名称
                    this.m_objViewer.ctlDataGrid2[B, 1] = m_mthConvertObjToDecimal(dt.Rows[i][11]);//剂量
                    this.m_objViewer.ctlDataGrid2[B, 3] = dt.Rows[i][1].ToString();//名称
                    this.m_objViewer.ctlDataGrid2[B, 4] = dt.Rows[i][2].ToString();//规格
                    this.m_objViewer.ctlDataGrid2[B, 2] = dt.Rows[i][3].ToString();//单位
                    this.m_objViewer.ctlDataGrid2[B, 5] = dt.Rows[i][14];//用法
                    this.m_objViewer.ctlDataGrid2[B, 21] = dt.Rows[i][13];//用法ID
                    this.m_objViewer.ctlDataGrid2[B, 6] = m_mthConvertObjToDecimal(dt.Rows[i][4]);//单价
                    this.m_objViewer.ctlDataGrid2[B, 8] = dt.Rows[i][5].ToString();//ID
                    this.m_objViewer.ctlDataGrid2[B, 12] = dt.Rows[i][10].ToString();//常量
                    this.m_objViewer.ctlDataGrid2[B, 13] = 0;//上限
                    this.m_objViewer.ctlDataGrid2[B, 14] = 0;//下限
                    this.m_objViewer.ctlDataGrid2[B, 9] = -1;//行号
                    this.m_objViewer.ctlDataGrid2[B, 16] = dt.Rows[i][7].ToString();
                    this.m_objViewer.ctlDataGrid2[B, 17] = dt.Rows[i][8].ToString();//大小单位标记
                    this.m_objViewer.ctlDataGrid2[B, 18] = dt.Rows[i][6].ToString();//包装量
                    this.m_objViewer.ctlDataGrid2[B, 20] = dt.Rows[i][12].ToString();//发票分类
                    this.m_objViewer.ctlDataGrid2[B, 24] = dt.Rows[i][15].ToString();//英文名
                    temp = 100;
                    if (objCalPatientCharge != null)
                    {
                        temp = objCalPatientCharge.m_mthGetDiscountByID(dt.Rows[i][5].ToString());
                    }
                    m_objViewer.ctlDataGrid2[B, 10] = temp.ToString() + "%";
                    m_objViewer.ctlDataGrid2[B, 11] = temp;
                    this.m_mthCalculateAmount2(B);
                    //				this.m_objViewer.ctlDataGrid2[i,8]=objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i][5].ToString(),m_mthConvertObjToDecimal(dt.Rows[i][4]),"",m_mthConvertObjToDecimal(dt.Rows[i][0]),3000,temp,"");                

                    if (dt.Rows[i][17].ToString() != "1")
                    {
                        this.m_objViewer.ctlDataGrid2[B, cm_DeptmedID] = "*";
                    }
                }
            }

            if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage7))
            {
                dt = objForm.GetTable3;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.m_objViewer.ctlDataGrid3.m_mthAppendRow();
                    C = this.m_objViewer.ctlDataGrid3.RowCount - 1;
                    this.m_objViewer.ctlDataGrid3[C, t_Find] = dt.Rows[i][8].ToString();
                    this.m_objViewer.ctlDataGrid3[C, t_Count] = m_mthConvertObjToDecimal(dt.Rows[i][0]);
                    this.m_objViewer.ctlDataGrid3[C, t_Name] = dt.Rows[i][1].ToString();
                    this.m_objViewer.ctlDataGrid3[C, t_Spec] = dt.Rows[i][2].ToString();
                    this.m_objViewer.ctlDataGrid3[C, t_Unit] = dt.Rows[i][3].ToString();
                    this.m_objViewer.ctlDataGrid3[C, t_Price] = m_mthConvertObjToDecimal(dt.Rows[i][4]);
                    //				this.m_objViewer.ctlDataGrid3[i,6]=m_mthConvertObjToDecimal(dt.Rows[i]["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid3[C, t_ItemID] = dt.Rows[i][5].ToString();
                    this.m_objViewer.ctlDataGrid3[C, t_PriceFlag] = dt.Rows[i][6].ToString();
                    this.m_objViewer.ctlDataGrid3[C, t_InvoiceType] = dt.Rows[i][7].ToString();//发票分类
                    this.m_objViewer.ctlDataGrid3[C, t_EnglishName] = dt.Rows[i][9].ToString();//英文名
                    this.m_objViewer.ctlDataGrid3[C, t_PartName] = dt.Rows[i][10].ToString();//样本类型
                    this.m_objViewer.ctlDataGrid3[C, t_Temp] = dt.Rows[i][11].ToString();//样本类型ID
                    temp = 100;
                    if (objCalPatientCharge != null)
                    {
                        temp = objCalPatientCharge.m_mthGetDiscountByID(dt.Rows[i][5].ToString());
                    }
                    m_objViewer.ctlDataGrid3[C, t_DiscountName] = temp.ToString() + "%";
                    m_objViewer.ctlDataGrid3[C, t_Discount] = temp;
                    this.m_objViewer.ctlDataGrid3[C, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i][5].ToString(), m_mthConvertObjToDecimal(dt.Rows[i][4]),
                    dt.Rows[i][7].ToString(), m_mthConvertObjToDecimal(dt.Rows[i][0]), 3000, temp, "", false);

                    //项目带项目
                    string strItemID = dt.Rows[i][5].ToString().Trim();
                    DataTable dtRecord = new DataTable();
                    bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                    if (blnStat)
                    {
                        m_mthGetChargeItemByItem(C.ToString() + "->" + strItemID, 0, dtRecord);
                        m_objViewer.ctlDataGrid3[C, t_resubitem] = "[PK]" + C.ToString() + "->" + strItemID;
                        m_objViewer.ctlDataGrid3[C, t_MainItemNum] = m_objViewer.ctlDataGrid3[C, t_Count];
                    }
                }
            }

            if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage8))
            {
                dt = objForm.GetTable4;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                    D = this.m_objViewer.ctlDataGrid4.RowCount - 1;
                    this.m_objViewer.ctlDataGrid4[D, t_Find] = dt.Rows[i][8].ToString();
                    this.m_objViewer.ctlDataGrid4[D, t_Count] = m_mthConvertObjToDecimal(dt.Rows[i][0]);
                    this.m_objViewer.ctlDataGrid4[D, t_Name] = dt.Rows[i][1].ToString();
                    this.m_objViewer.ctlDataGrid4[D, t_Spec] = dt.Rows[i][2].ToString();
                    this.m_objViewer.ctlDataGrid4[D, t_Unit] = dt.Rows[i][3].ToString();//单位
                    this.m_objViewer.ctlDataGrid4[D, t_Price] = dt.Rows[i][4].ToString();//单价
                    this.m_objViewer.ctlDataGrid4[D, t_SumMoney] = m_mthConvertObjToDecimal(dt.Rows[i][4]) * m_mthConvertObjToDecimal(dt.Rows[i][0]);
                    //				this.m_objViewer.ctlDataGrid4[i,6]=m_mthConvertObjToDecimal(dt.Rows[i]["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid4[D, t_ItemID] = dt.Rows[i][5].ToString();
                    this.m_objViewer.ctlDataGrid4[D, t_PriceFlag] = dt.Rows[i][6].ToString();
                    this.m_objViewer.ctlDataGrid4[D, t_InvoiceType] = dt.Rows[i][7].ToString();//发票分类
                    this.m_objViewer.ctlDataGrid4[D, t_EnglishName] = dt.Rows[i][9].ToString();//英文名
                    this.m_objViewer.ctlDataGrid4[D, t_PartName] = dt.Rows[i][10].ToString();//部位
                    this.m_objViewer.ctlDataGrid4[D, t_Temp] = dt.Rows[i][11].ToString();//部位ID
                    this.m_objViewer.ctlDataGrid4[D, t_UsageID] = dt.Rows[i][12].ToString();//用法ID
                    temp = 100;
                    if (objCalPatientCharge != null)
                    {
                        temp = objCalPatientCharge.m_mthGetDiscountByID(dt.Rows[i][5].ToString());
                    }
                    m_objViewer.ctlDataGrid4[D, t_DiscountName] = temp.ToString() + "%";
                    m_objViewer.ctlDataGrid4[D, t_Discount] = temp;
                    this.m_objViewer.ctlDataGrid4[D, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i][5].ToString(), m_mthConvertObjToDecimal(dt.Rows[i][4]),
                    dt.Rows[i][7].ToString(), m_mthConvertObjToDecimal(dt.Rows[i][0]), 3000, temp, "", false);

                    //项目带项目
                    string strItemID = dt.Rows[i][5].ToString().Trim();
                    DataTable dtRecord = new DataTable();
                    bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                    if (blnStat)
                    {
                        m_mthGetChargeItemByItem(D.ToString() + "->" + strItemID, 0, dtRecord);
                        m_objViewer.ctlDataGrid4[D, t_resubitem] = "[PK]" + D.ToString() + "->" + strItemID;
                        m_objViewer.ctlDataGrid4[D, t_MainItemNum] = m_objViewer.ctlDataGrid4[D, t_Count];
                    }
                }
            }

            if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage9))
            {
                dt = objForm.GetTable5;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                    E = this.m_objViewer.ctlDataGrid5.RowCount - 1;
                    this.m_objViewer.ctlDataGrid5[E, o_Find] = dt.Rows[i][8].ToString();
                    this.m_objViewer.ctlDataGrid5[E, o_Count] = m_mthConvertObjToDecimal(dt.Rows[i][0]);
                    this.m_objViewer.ctlDataGrid5[E, o_Name] = dt.Rows[i][1].ToString();
                    this.m_objViewer.ctlDataGrid5[E, o_Spec] = dt.Rows[i][2].ToString();
                    this.m_objViewer.ctlDataGrid5[E, o_Unit] = dt.Rows[i][3].ToString();
                    this.m_objViewer.ctlDataGrid5[E, o_Price] = m_mthConvertObjToDecimal(dt.Rows[i][4]);
                    //				this.m_objViewer.ctlDataGrid5[i,6]=m_mthConvertObjToDecimal(dt.Rows[i]["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid5[E, o_ItemID] = dt.Rows[i][5].ToString();
                    this.m_objViewer.ctlDataGrid5[E, o_PriceFlag] = dt.Rows[i][6].ToString();
                    this.m_objViewer.ctlDataGrid5[E, o_InvoiceType] = dt.Rows[i][7].ToString();//发票分类
                    this.m_objViewer.ctlDataGrid5[E, o_Temp] = dt.Rows[i][9].ToString();//英文名
                    this.m_objViewer.ctlDataGrid5[E, o_UsageID] = dt.Rows[i][10].ToString();//用法ID
                    temp = 100;
                    if (objCalPatientCharge != null)
                    {
                        temp = objCalPatientCharge.m_mthGetDiscountByID(dt.Rows[i][5].ToString());
                    }
                    m_objViewer.ctlDataGrid5[E, 10] = temp.ToString() + "%";
                    m_objViewer.ctlDataGrid5[E, 11] = temp;
                    this.m_objViewer.ctlDataGrid5[E, 9] = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i][5].ToString(), m_mthConvertObjToDecimal(dt.Rows[i][4]),
                    dt.Rows[i][7].ToString(), m_mthConvertObjToDecimal(dt.Rows[i][0]), 3000, temp, "", false);

                    //项目带项目
                    string strItemID = dt.Rows[i][5].ToString().Trim();
                    DataTable dtRecord = new DataTable();
                    bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                    if (blnStat)
                    {
                        m_mthGetChargeItemByItem(E.ToString() + "->" + strItemID, 0, dtRecord);
                        m_objViewer.ctlDataGrid5[E, o_resubitem] = "[PK]" + E.ToString() + "->" + strItemID;
                        m_objViewer.ctlDataGrid5[E, o_MainItemNum] = m_objViewer.ctlDataGrid5[E, o_Count];
                    }
                }
            }

            dt = objForm.GetTable6;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.m_objViewer.ctlDataGrid6.m_mthAppendRow();
                F = this.m_objViewer.ctlDataGrid6.RowCount - 1;
                this.m_objViewer.ctlDataGrid6[F, 0] = dt.Rows[i][8].ToString();
                this.m_objViewer.ctlDataGrid6[F, 1] = m_mthConvertObjToDecimal(dt.Rows[i][0]);
                this.m_objViewer.ctlDataGrid6[F, 2] = dt.Rows[i][1].ToString();
                this.m_objViewer.ctlDataGrid6[F, 3] = dt.Rows[i][2].ToString();
                this.m_objViewer.ctlDataGrid6[F, 4] = dt.Rows[i][3].ToString();
                this.m_objViewer.ctlDataGrid6[F, 5] = m_mthConvertObjToDecimal(dt.Rows[i][4]);
                //				this.m_objViewer.ctlDataGrid5[i,6]=m_mthConvertObjToDecimal(dt.Rows[i]["SUMMONEY"]);
                this.m_objViewer.ctlDataGrid6[F, 7] = dt.Rows[i][5].ToString();
                this.m_objViewer.ctlDataGrid6[F, 8] = dt.Rows[i][6].ToString();
                this.m_objViewer.ctlDataGrid6[F, 12] = dt.Rows[i][7].ToString();//发票分类
                this.m_objViewer.ctlDataGrid6[F, 15] = dt.Rows[i][9].ToString();//英文名
                temp = 100;
                if (objCalPatientCharge != null)
                {
                    temp = objCalPatientCharge.m_mthGetDiscountByID(dt.Rows[i][5].ToString());
                }
                m_objViewer.ctlDataGrid6[F, 10] = temp.ToString() + "%";
                m_objViewer.ctlDataGrid6[F, 11] = temp;
                this.m_objViewer.ctlDataGrid6[F, 9] = objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[i][5].ToString(), m_mthConvertObjToDecimal(dt.Rows[i][4]),
                dt.Rows[i][7].ToString(), m_mthConvertObjToDecimal(dt.Rows[i][0]), 3000, temp, "", false);

                //项目带项目
                string strItemID = dt.Rows[i][5].ToString().Trim();
                DataTable dtRecord = new DataTable();
                bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                if (blnStat)
                {
                    m_mthGetChargeItemByItem(F.ToString() + "->" + strItemID, 0, dtRecord);
                    m_objViewer.ctlDataGrid6[F, o_resubitem] = "[PK]" + F.ToString() + "->" + strItemID;
                    m_objViewer.ctlDataGrid6[F, o_MainItemNum] = m_objViewer.ctlDataGrid6[F, o_Count];
                }

                if (dt.Rows[i][10].ToString() != "1")
                {
                    this.m_objViewer.ctlDataGrid6[F, o_DeptmedID] = "*";
                }
            }

            this.m_mthSetFocus();
        }
        #endregion

        #region 显示药品详细信息
        /// <summary>
        /// 关联药品基本信息表和药典表显示药品的信息。弹出一个窗口显示
        /// </summary>
        private void m_mthShowMedicineInfo()
        {
            // 1 西药 2 中药 3 检验
            int Flag = 0;
            string ID = "";
            if (this.m_objViewer.tabControl1.SelectedIndex == 3)
            {
                ID = this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_ItemID].ToString().Trim();
                Flag = 1;
            }
            else if (this.m_objViewer.tabControl1.SelectedIndex == 4)
            {
                ID = this.m_objViewer.ctlDataGrid2[this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 8].ToString().Trim();
                Flag = 2;
            }
            else if (this.m_objViewer.tabControl1.SelectedIndex == 5)
            {
                ID = this.m_objViewer.ctlDataGrid3[this.m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_ItemID].ToString().Trim();
                Flag = 3;
            }

            if (ID.Trim() == "")
            {
                return;
            }

            string strText = "";
            string strRemark = "";

            if (Flag == 1 || Flag == 2)
            {
                objSvc.m_mthGetMedicineInfo(ID, out strText, out strRemark);
            }
            else if (Flag == 3)
            {
                DataTable dt;
                long l = this.objSvc.m_lngGetLisItemClinicMeaning(ID, out dt);
                if (l > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        strText += "【" + dt.Rows[i]["check_item_name_vchr"].ToString().Trim() + "】 " + dt.Rows[i]["clinic_meaning_vchr"].ToString().Trim() + "\r\n\r\n";
                    }
                }
            }

            frmMedicineInfo obj = new frmMedicineInfo();
            obj.SetText = strText;
            obj.ShowDialog();
        }
        #endregion

        #region 调出申请检验界面
        private int testApplyFlag = -1;
        public void m_mthShowTestApply(int introw)
        {
            testApplyFlag = introw;
            if (this.m_objViewer.m_PatInfo.PatientID.Trim() == "")
            {
                MessageBox.Show("请先输入病人资料!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_PatInfo.txtCardID.Focus();
                return;
            }
            int[] ret = new int[0];
            if (introw > -1)
            {
                frmChooseTestItem objfrmChooseItem = new frmChooseTestItem(introw);
                ListViewItem lv;
                for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim() == "")
                    {
                        continue;
                    }
                    lv = new ListViewItem(this.m_objViewer.ctlDataGrid3[i, t_Find].ToString().Trim());
                    lv.SubItems.Add(this.m_objViewer.ctlDataGrid3[i, t_Name].ToString().Trim());
                    lv.SubItems.Add(this.m_objViewer.ctlDataGrid3[i, t_Spec].ToString().Trim());
                    lv.SubItems.Add(this.m_objViewer.ctlDataGrid3[i, t_Unit].ToString().Trim());
                    lv.SubItems.Add(this.m_objViewer.ctlDataGrid3[i, t_Price].ToString().Trim());
                    lv.Tag = i;
                    lv.Checked = false;
                    objfrmChooseItem.ShowControl.Items.Add(lv);
                }
                if (objfrmChooseItem.ShowDialog() == DialogResult.OK)
                {
                    ret = objfrmChooseItem.ChooseResult;
                    objfrmChooseItem.Close();
                }
                else
                {
                    return;
                }
            }
            clsTestApplyItme_VO[] itemArr_VO;
            m_mthGetChargeInfo(out itemArr_VO, ret);
            frmLisAppl obj = new frmLisAppl();
            obj.evnRequestChargeInfo += new dlgRequestChargeInfoEventHandler(obj_evnRequestChargeInfo);
            #region 收费病人基本数据
            clsLisApplMainVO objLMVO;
            m_mthGetPatientInfo(out objLMVO);
            #endregion
            if (obj.m_mthNewApp(objLMVO, itemArr_VO, true) == DialogResult.OK)
            {
                clsLISAppResults objAppResult = obj.m_objGetAppResults();
                for (int i = this.m_objViewer.ctlDataGrid3.RowCount - 1; i > -1; i--)
                {
                    if (introw > -1)
                    {
                        this.m_objViewer.ctlDataGrid3[introw, t_ApplyId] = objAppResult.m_StrApplicationID;
                        this.m_objViewer.ctlDataGrid3[introw, t_PartName] = objAppResult.m_strSampleTypeName;
                        this.m_objViewer.ctlDataGrid3[introw, t_Temp] = objAppResult.m_strSampleTypeID;
                    }
                    else
                    {
                        if (this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim() == "1")
                        {
                            this.m_objViewer.ctlDataGrid3[i, t_ApplyId] = objAppResult.m_StrApplicationID;
                            this.m_objViewer.ctlDataGrid3[i, t_PartName] = objAppResult.m_strSampleTypeName;
                            this.m_objViewer.ctlDataGrid3[i, t_Temp] = objAppResult.m_strSampleTypeID;
                        }
                    }
                }
            }
            this.m_mthSetFocus();
        }
        /// <summary>
        /// 获取病人信息
        /// </summary>
        /// <param name="objLMVO"></param>
        private void m_mthGetPatientInfo(out clsLisApplMainVO objLMVO)
        {
            objLMVO = new clsLisApplMainVO();
            objLMVO.m_intEmergency = 0;
            objLMVO.m_intForm_int = 0;
            if (this.m_objViewer.m_PatInfo.PatientAge.IndexOf("月") >= 0)
            {
                objLMVO.m_strAge = this.m_objViewer.m_PatInfo.PatientAge;
            }
            else
            {
                objLMVO.m_strAge = this.m_objViewer.m_PatInfo.PatientAge + " 岁";
            }

            string strEmployeeID = "0000001";
            if (this.m_objViewer.LoginInfo != null)
            {
                strEmployeeID = this.m_objViewer.LoginInfo.m_strEmpID;
            }

            objLMVO.m_strAppl_DeptID = this.m_objViewer.m_PatInfo.DeptID;
            objLMVO.m_strAppl_EmpID = this.m_objViewer.m_PatInfo.DoctorID;
            //objLMVO.m_strDiagnose = this.m_objViewer.objCaseHistory.Diag + "\n" + this.m_objViewer.objCaseHistory.ChangeDepartment;
            objLMVO.m_strDiagnose = this.m_objViewer.objCaseHistory.Diag;
            objLMVO.m_strOperator_ID = strEmployeeID;
            objLMVO.m_strPatient_Name = this.m_objViewer.m_PatInfo.PatientName;
            objLMVO.m_strPatientcardID = this.m_objViewer.m_PatInfo.PatientCardID;
            objLMVO.m_strPatientID = this.m_objViewer.m_PatInfo.PatientID;
            objLMVO.m_strPatientType = "2";
            objLMVO.m_strSex = this.m_objViewer.m_PatInfo.PatientSex;
            //急诊标志
            objLMVO.m_intEmergency = this.m_objViewer.URGENCY_INT;
            objLMVO.m_strBirthDay = this.m_objViewer.m_PatInfo.PatientBirth;
        }
        /// <summary>
        /// 获取检查信息
        /// </summary>
        /// <param name="itemArr_VO"></param>
        /// <param name="ret"></param>
        private void m_mthGetChargeInfo(out clsTestApplyItme_VO[] itemArr_VO, int[] ret)
        {
            itemArr_VO = new clsTestApplyItme_VO[ret.Length];
            for (int i = 0; i < ret.Length; i++)
            {
                itemArr_VO[i] = new clsTestApplyItme_VO();
                itemArr_VO[i].m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[ret[i], t_Discount]);
                itemArr_VO[i].m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[ret[i], t_Price]);
                itemArr_VO[i].m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[ret[i], t_Count]);
                itemArr_VO[i].m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[ret[i], t_SumMoney]);
                itemArr_VO[i].m_strItemID = objSvc.m_mthGetResourceIDByItemID(m_objViewer.ctlDataGrid3[ret[i], t_ItemID].ToString());
                itemArr_VO[i].m_strItemName = this.m_objViewer.ctlDataGrid3[ret[i], t_Name].ToString();
                itemArr_VO[i].m_strSpec = this.m_objViewer.ctlDataGrid3[ret[i], t_Spec].ToString();
                itemArr_VO[i].m_strUnit = this.m_objViewer.ctlDataGrid3[ret[i], t_Unit].ToString();
                itemArr_VO[i].m_strOutpatRecipeID = "";
                itemArr_VO[i].m_strRowNo = ret[i].ToString();
                itemArr_VO[i].m_strOprDeptID = "";
            }
        }
        #endregion

        #region 根据申请单的项目源ID查找收费项目
        private void m_mthFindChargeItemByApplyBillID(string ID, out clsTestApplyItme_VO objTestApply)
        {
            //have,但没有循环
            objTestApply = new clsTestApplyItme_VO();
            DataTable dt = null;
            long strRet = objSvc.m_mthFindChargeItemByApplyBillID(ID, out dt);
            if (strRet > 0 && dt.Rows.Count > 0)
            {
                int row = m_objViewer.ctlDataGrid3.RowCount;
                //					m_objViewer.ctlDataGrid3.m_mthAppendRow();

                objTestApply.m_decTolPrice = 0;
                objTestApply.m_strOutpatRecipeID = "";
                objTestApply.m_strRowNo = "";
                objTestApply.m_strOprDeptID = "";
                //

                DataRow objRow = m_objViewer.ctlDataGrid3.NewRow();
                objRow[t_Find] = dt.Rows[0]["ITEMCODE_VCHR"].ToString().Trim();
                objRow[t_Count] = objTestApply.m_decQty = 1;
                objRow[t_Name] = objTestApply.m_strItemName = dt.Rows[0]["ITEMNAME_VCHR"].ToString().Trim();
                objRow[t_Spec] = objTestApply.m_strSpec = dt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim();
                objRow[t_Unit] = objTestApply.m_strUnit = dt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim();
                objRow[t_Price] = objTestApply.m_decPrice = m_mthConvertObjToDecimal(dt.Rows[0]["ITEMPRICE_MNY"].ToString().Trim());
                objRow[t_ItemID] = objTestApply.m_strItemID = dt.Rows[0]["ITEMID_CHR"].ToString().Trim();
                objRow[t_PriceFlag] = dt.Rows[0]["SELFDEFINE_INT"].ToString().Trim();
                decimal temp = 100;
                if (objCalPatientCharge != null)
                {
                    temp = objCalPatientCharge.m_mthGetDiscountByID(dt.Rows[0]["ITEMID_CHR"].ToString().Trim());
                }
                objRow[t_DiscountName] = temp.ToString() + "%";
                objRow[t_Discount] = objTestApply.m_decDiscount = temp;
                decimal price = this.m_mthConvertObjToDecimal(dt.Rows[0]["ITEMPRICE_MNY"]);
                objRow[t_RowNo] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[0]["ITEMID_CHR"].ToString().Trim(), price, "", 1, 3000, temp, "", false);
                objRow[t_ApplyId] = 1;
                m_objViewer.ctlDataGrid3.m_mthAppendRow(objRow);
            }
            else
            {
                objTestApply.m_decDiscount = 0;
                objTestApply.m_decPrice = 0;
                objTestApply.m_decQty = 0;
                objTestApply.m_decTolPrice = 0;
                objTestApply.m_strItemID = "";
                objTestApply.m_strItemName = "";
                objTestApply.m_strSpec = "";
                objTestApply.m_strUnit = "";
                objTestApply.m_strOutpatRecipeID = "";
                objTestApply.m_strRowNo = "";
                objTestApply.m_strOprDeptID = "";
                MessageBox.Show("找不到对应的收费项目,请检查数据的完整性!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        #endregion

        #region 打印功能
        private clsPrintCaseHistory objCaseHistoryPrint = null;
        public void m_mthEndPrint()
        {
            this.objCaseHistoryPrint = null;
        }
        public void m_mthBeginPrint()
        {
            if (this.m_objViewer.btPrint.Tag.ToString() == "2")
            {
                #region 收集数据
                ArrayList objArrTemp = new ArrayList();
                DataTable dtTemp;
                long ret = objSvc.m_mthGetUnDisplayCat(out dtTemp, "1");
                if (ret > 0 && dtTemp.Rows.Count > 0)
                {
                    for (int i = 0; i < dtTemp.Rows.Count; i++)
                    {
                        objArrTemp.Add(dtTemp.Rows[i]["TYPEID_CHR"].ToString().Trim());
                    }

                }

                clsOutpatientPrintCaseHis_VO objPrintCaseHis_VO = new clsOutpatientPrintCaseHis_VO();
                objPrintCaseHis_VO.m_strAge = this.m_objViewer.m_PatInfo.PatientAge.Trim();
                this.m_objComInfo.m_lngGetEmpSign(this.m_objViewer.LoginInfo.m_strEmpID, out objPrintCaseHis_VO.objDocImage);
                objPrintCaseHis_VO.m_strCardID = this.m_objViewer.m_PatInfo.PatientCardID.Trim();
                objPrintCaseHis_VO.m_strDiagDeptID = this.m_objViewer.m_PatInfo.DeptName.Trim();
                objPrintCaseHis_VO.m_strDiagDrName = this.m_objViewer.m_PatInfo.DoctorName.Trim();
                objPrintCaseHis_VO.m_strHospitalName = this.m_objComInfo.m_strGetHospitalTitle();
                objPrintCaseHis_VO.m_strPatientName = this.m_objViewer.m_PatInfo.PatientName;
                if (this.m_objViewer.btSave.Tag == null)
                {
                    objPrintCaseHis_VO.m_strRecipeID = "";
                }
                else
                {
                    objPrintCaseHis_VO.m_strRecipeID = this.m_objViewer.btSave.Tag.ToString().Trim();
                }
                string strEmployee = "0001";//员工ID
                if (this.m_objViewer.LoginInfo != null)
                {
                    strEmployee = this.m_objViewer.LoginInfo.m_strEmpID;
                }
                objPrintCaseHis_VO.m_strRecordEmpID = strEmployee;//员工ID
                objPrintCaseHis_VO.m_strRegisterID = this.m_objViewer.m_PatInfo.RegisterID;
                objPrintCaseHis_VO.m_strPrintDate = this.m_objViewer.m_PatInfo.RegisterDate;
                objPrintCaseHis_VO.m_strSex = this.m_objViewer.m_PatInfo.PatientSex;
                objPrintCaseHis_VO.strAidCheck = this.m_objViewer.objCaseHistory.AidCheck;
                objPrintCaseHis_VO.strAnaPhyLaXis = this.m_objViewer.objCaseHistory.Anaphylaxis;
                objPrintCaseHis_VO.strDiag = this.m_objViewer.objCaseHistory.Diag;
                objPrintCaseHis_VO.strDiagCurr = this.m_objViewer.objCaseHistory.DiagCurr;
                objPrintCaseHis_VO.strDiagHis = this.m_objViewer.objCaseHistory.DiagHis;
                objPrintCaseHis_VO.strDiagMain = this.m_objViewer.objCaseHistory.DiagMain;
                objPrintCaseHis_VO.strReMark = this.m_objViewer.objCaseHistory.ReMark;
                objPrintCaseHis_VO.strChangeDeparement = this.m_objViewer.objCaseHistory.ChangeDepartment;
                objPrintCaseHis_VO.strTreatMent = this.m_objViewer.objCaseHistory.Treatment;
                objPrintCaseHis_VO.strExamineResult = this.m_objViewer.objCaseHistory.ExamineResult;
                objPrintCaseHis_VO.m_strPRIHIS_VCHR = this.m_objViewer.objCaseHistory.PersonHis;
                objPrintCaseHis_VO.strParentID = this.m_objViewer.objCaseHistory.ParentCaseHistoryID;
                #region

                clsDcl_ShowReports objCase = new clsDcl_ShowReports();
                DataTable dt;
                long l = objCase.m_mthGetRecipeInfoByCaseHistoryID(this.m_objViewer.objCaseHistory.CaseHistoryID, out dt);
                objPrintCaseHis_VO.objItemArr = new ArrayList();
                objPrintCaseHis_VO.objItemArr2 = new ArrayList();
                if (l > 0 && dt.Rows.Count > 0)
                {
                    string strTempID = dt.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["SEQID_CHR"].ToString().Trim() == "1")
                        {
                            continue;
                        }
                        if (strTempID != dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim())
                        {
                            clsOutpatientPrintRecipeDetail_VO objSpilt = null;

                            if (objPrintCaseHis_VO.objItemArr.Count > 0)
                            {
                                objPrintCaseHis_VO.objItemArr.Add(objSpilt);
                            }
                            if (objPrintCaseHis_VO.objItemArr2.Count > 0)
                            {
                                objPrintCaseHis_VO.objItemArr2.Add(objSpilt);
                            }
                            strTempID = dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim();
                        }
                        clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();
                        objtemp.m_strChargeName = dt.Rows[i]["ITEMNAME"].ToString().Trim();
                        objtemp.m_strCount = dt.Rows[i]["QUANTITY"].ToString().Trim() + dt.Rows[i]["UNIT"].ToString().Trim();
                        objtemp.m_strPrice = "";
                        objtemp.m_strSumPrice = "";
                        objtemp.m_strUnit = dt.Rows[i]["UNIT"].ToString().Trim();
                        objtemp.m_strFrequency = dt.Rows[i]["FREQNAME_CHR"].ToString().Trim();
                        objtemp.m_strDosage = dt.Rows[i]["QTY_DEC"].ToString().Trim() + dt.Rows[i]["DOSAGEUNIT_CHR"].ToString().Trim();
                        objtemp.m_strDays = dt.Rows[i]["DAYS_INT"].ToString().Trim() + "天";
                        objtemp.m_strSpec = dt.Rows[i]["DEC"].ToString().Trim();
                        objtemp.m_strUsage = dt.Rows[i]["USAGENAME_VCHR"].ToString().Trim();
                        objtemp.m_strRowNo = dt.Rows[i]["ROWNO_CHR"].ToString().Trim();
                        objtemp.m_strInvoiceCat = dt.Rows[i]["invtype"].ToString().Trim();
                        if (dt.Rows[i]["SEQID_CHR"].ToString().Trim() == "2")
                        {
                            objPrintCaseHis_VO.objItemArr2.Add(objtemp);
                        }
                        else
                        {
                            objPrintCaseHis_VO.objItemArr.Add(objtemp);
                        }
                    }
                }

                #endregion
                objCaseHistoryPrint = new clsPrintCaseHistory(objPrintCaseHis_VO);
                #endregion
            }
            else
            {
                clsOutpatientPrintRecipe_VO obj_VO = new clsOutpatientPrintRecipe_VO();
                obj_VO.m_strWMedicineCost = this.m_objViewer.AA.Text;
                obj_VO.m_strZCMedicineCost = this.m_objViewer.BB.Text;
                decimal decCureCost = this.m_mthConvertObjToDecimal(m_objViewer.CC.Text) + this.m_mthConvertObjToDecimal(m_objViewer.DD.Text) + this.m_mthConvertObjToDecimal(m_objViewer.EE.Text) + this.m_mthConvertObjToDecimal(m_objViewer.FF.Text);
                obj_VO.m_strCureCost = decCureCost.ToString();
                obj_VO.m_strAge = this.m_objViewer.m_PatInfo.PatientAge.Trim();
                obj_VO.m_strIDcardno = this.m_objViewer.m_PatInfo.IDcard.Trim();
                obj_VO.m_strPatientType = this.m_objViewer.m_PatInfo.txtType.Text;
                obj_VO.m_strCardID = this.m_objViewer.m_PatInfo.PatientCardID.Trim();
                obj_VO.m_strDiagDeptID = this.m_objViewer.m_PatInfo.DeptName.Trim();
                obj_VO.m_strDiagDrName = this.m_objViewer.m_PatInfo.txtRegisterDoctor.Text.Trim();
                obj_VO.m_strHospitalName = this.m_objComInfo.m_strGetHospitalTitle();
                obj_VO.m_strPatientName = this.m_objViewer.m_PatInfo.PatientName;
                obj_VO.m_strRecipeID = this.m_objViewer.btSave.Tag.ToString().Trim();
                obj_VO.m_strAddress = this.m_objViewer.m_PatInfo.PatientTelephoneNo + this.m_objViewer.m_PatInfo.PatientHomeAddress;
                obj_VO.m_strRecipeType = this.m_objViewer.m_cmbRecipeType.Text;
                obj_VO.m_strdiagnose = this.m_objViewer.objCaseHistory.Diag;
                this.m_objComInfo.m_lngGetEmpSign(this.m_objViewer.m_PatInfo.DoctorID, out obj_VO.objImage);
                obj_VO.m_strGOVCARD = "";
                obj_VO.m_strINSURANCEID = "";
                switch (this.m_objViewer.m_PatInfo.PatientType)
                {
                    case 1:
                        obj_VO.m_strGOVCARD = this.m_objViewer.m_PatInfo.PatientGOVCARD;
                        break;
                    case 2:
                        obj_VO.m_strINSURANCEID = this.m_objViewer.m_PatInfo.PatientINSURANCEID;
                        break;
                    case 3:
                        obj_VO.m_strINSURANCEID = this.m_objViewer.m_PatInfo.PatientDIFFICULTYNO;
                        break;
                }

                string strEmployee = "0001";//员工ID
                if (this.m_objViewer.LoginInfo != null)
                {
                    strEmployee = this.m_objViewer.LoginInfo.m_strEmpNo;
                }
                obj_VO.m_strRecordEmpID = strEmployee;//员工ID
                obj_VO.m_strRegisterID = this.m_objViewer.m_PatInfo.RegisterID;
                obj_VO.m_strPrintDate = this.m_objViewer.m_PatInfo.RegisterDate;
                obj_VO.m_strSex = this.m_objViewer.m_PatInfo.PatientSex;
                obj_VO.m_strSelfPay = this.m_objViewer.lbeSelfPay.Text.Trim();
                obj_VO.m_strChargeUp = this.m_objViewer.lbeChargeUp.Text.Trim();
                obj_VO.m_strRecipePrice = this.m_objViewer.lbeSumMoney.Text.Trim();
                obj_VO.m_strSelfPay = this.m_objViewer.lbeSelfPay.Text.Trim();
                obj_VO.m_strHerbalmedicineUsage = this.m_objViewer.cmbCooking.Text;
                obj_VO.m_strTimes = this.m_objViewer.numericUpDown1.Value.ToString();
                obj_VO.m_strPayType = this.m_objViewer.m_PatInfo.PayTypeID;

                this.m_mthClearDataEmptyRow();
                int count = this.m_objViewer.ctlDataGrid1.RowCount;
                obj_VO.objinjectArr2 = new ArrayList();
                ArrayList objPRDArr = new ArrayList();
                int rowTemp = 0;
                for (int d1 = 0; d1 < this.m_objViewer.ctlDataGrid1.RowCount; d1++)
                {
                    if (this.m_objViewer.ctlDataGrid1[d1, c_ItemID].ToString().Trim() != "")
                    {
                        clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();
                        if (this.m_objViewer.ctlDataGrid1[d1, c_EnglishName].ToString().Trim() == "" || IsPrintEnglish)
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid1[d1, c_Name].ToString().Trim();
                        }
                        else
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid1[d1, c_EnglishName].ToString().Trim();
                        }

                        objtemp.m_strCount = this.m_objViewer.ctlDataGrid1[d1, c_Total].ToString().Trim() + this.m_objViewer.ctlDataGrid1[d1, c_BigUnit].ToString().Trim();
                        objtemp.m_strPrice = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[d1, c_Price]).ToString("0.00");
                        objtemp.m_strSumPrice = this.m_objViewer.ctlDataGrid1[d1, c_SumMoney].ToString().Trim();
                        objtemp.m_strUnit = this.m_objViewer.ctlDataGrid1[d1, c_Unit].ToString().Trim();
                        objtemp.m_strFrequency = this.m_objViewer.ctlDataGrid1[d1, c_FreName].ToString().Trim();
                        objtemp.m_strDosage = this.m_objViewer.ctlDataGrid1[d1, c_Count].ToString().Trim() + this.m_objViewer.ctlDataGrid1[d1, c_Unit].ToString().Trim();
                        objtemp.m_strDays = this.m_objViewer.ctlDataGrid1[d1, c_Day].ToString().Trim();
                        objtemp.m_strSpec = this.m_objViewer.ctlDataGrid1[d1, c_Spec].ToString().Trim();
                        objtemp.m_strUsage = this.m_objViewer.ctlDataGrid1[d1, c_UsageName].ToString().Trim();
                        objtemp.m_strUsageDetail = this.m_objViewer.ctlDataGrid1[d1, c_UsageDetail].ToString().Trim();
                        objtemp.m_strRowNo = this.m_objViewer.ctlDataGrid1[d1, c_GroupNo].ToString().Trim();
                        objtemp.m_strInvoiceCat = this.m_objViewer.ctlDataGrid1[d1, c_InvoiceType].ToString().Trim();
                        if (objtemp.m_strRowNo == "" || objtemp.m_strRowNo == "0")
                        {
                            objtemp.m_strRowNo = "0" + rowTemp.ToString();
                            rowTemp++;
                        }
                        if (this.m_objViewer.ctlDataGrid1[d1, c_DeptmedID].ToString().Trim() == "1")
                        {
                            objtemp.m_strDeptmedInfo = "【KB】";
                        }
                        else
                        {
                            objtemp.m_strDeptmedInfo = "";
                        }

                        if (this.m_objViewer.objUsageArr.IndexOf(this.m_objViewer.ctlDataGrid1[d1, c_UsageID].ToString().Trim()) > -1)
                        {
                            obj_VO.objinjectArr2.Add(objtemp);
                        }
                        objPRDArr.Add(objtemp);

                    }
                }

                ArrayList objPRDArr2 = new ArrayList();
                for (int d2 = 0; d2 < this.m_objViewer.ctlDataGrid2.RowCount; d2++)
                {
                    if (this.m_objViewer.ctlDataGrid2[d2, 9].ToString().Trim() != "")
                    {
                        clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();

                        if (this.m_objViewer.ctlDataGrid2[d2, 24].ToString().Trim() == "" || IsPrintEnglish)
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid2[d2, 3].ToString().Trim();
                        }
                        else
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid2[d2, 24].ToString().Trim();
                        }
                        objtemp.m_strDosage = this.m_objViewer.ctlDataGrid2[d2, 1].ToString().Trim() + this.m_objViewer.ctlDataGrid2[d2, 2].ToString().Trim();
                        objtemp.m_strPrice = this.m_objViewer.ctlDataGrid2[d2, 6].ToString().Trim();
                        objtemp.m_strSumPrice = this.m_objViewer.ctlDataGrid2[d2, 7].ToString().Trim();
                        objtemp.m_strUsage = this.m_objViewer.ctlDataGrid2[d2, 5].ToString().Trim();
                        objtemp.m_strRowNo = this.m_objViewer.ctlDataGrid2[d2, 19].ToString().Trim();
                        objtemp.m_strInvoiceCat = this.m_objViewer.ctlDataGrid2[d2, 20].ToString().Trim();
                        if (this.m_objViewer.ctlDataGrid2[d2, cm_DeptmedID].ToString().Trim() == "1")
                        {
                            objtemp.m_strDeptmedInfo = "【KB】";
                        }
                        else
                        {
                            objtemp.m_strDeptmedInfo = "";
                        }
                        objPRDArr2.Add(objtemp);
                    }
                }
                obj_VO.objinjectArr = new ArrayList();
                for (int d3 = 0; d3 < this.m_objViewer.ctlDataGrid3.RowCount; d3++)
                {
                    if (this.m_objViewer.ctlDataGrid3[d3, t_RowNo].ToString().Trim() != "")
                    {
                        clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();
                        if (this.m_objViewer.ctlDataGrid3[d3, t_EnglishName].ToString().Trim() == "" || IsPrintEnglish)
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid3[d3, t_Name].ToString().Trim();
                        }
                        else
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid3[d3, t_EnglishName].ToString().Trim();
                        }

                        objtemp.m_strCount = this.m_objViewer.ctlDataGrid3[d3, t_Count].ToString().Trim() + this.m_objViewer.ctlDataGrid3[d3, t_Unit].ToString().Trim();
                        objtemp.m_strPrice = this.m_objViewer.ctlDataGrid3[d3, t_Price].ToString().Trim();
                        objtemp.m_strSumPrice = this.m_objViewer.ctlDataGrid3[d3, t_SumMoney].ToString().Trim();
                        objtemp.m_strUnit = this.m_objViewer.ctlDataGrid3[d3, t_Unit].ToString().Trim();
                        objtemp.m_strInvoiceCat = this.m_objViewer.ctlDataGrid3[d3, t_InvoiceType].ToString().Trim();
                        objtemp.m_strFrequency = "";
                        objtemp.m_strDosage = "";
                        objtemp.m_strDays = "";
                        objtemp.m_strUsage = "";
                        objtemp.m_strRowNo = d3.ToString();
                        obj_VO.objinjectArr.Add(objtemp);
                    }
                }
                for (int d4 = 0; d4 < this.m_objViewer.ctlDataGrid4.RowCount; d4++)
                {
                    if (this.m_objViewer.ctlDataGrid4[d4, t_RowNo].ToString().Trim() != "")
                    {
                        clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();
                        if (this.m_objViewer.ctlDataGrid4[d4, t_EnglishName].ToString().Trim() == "" || IsPrintEnglish)
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid4[d4, t_Name].ToString().Trim();
                        }
                        else
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid4[d4, t_EnglishName].ToString().Trim();
                        }
                        objtemp.m_strCount = this.m_objViewer.ctlDataGrid4[d4, t_Count].ToString().Trim() + this.m_objViewer.ctlDataGrid4[d4, t_Unit].ToString().Trim();
                        objtemp.m_strPrice = this.m_objViewer.ctlDataGrid4[d4, t_Price].ToString().Trim();
                        objtemp.m_strSumPrice = this.m_objViewer.ctlDataGrid4[d4, t_SumMoney].ToString().Trim();
                        objtemp.m_strUnit = this.m_objViewer.ctlDataGrid4[d4, t_Unit].ToString().Trim();
                        objtemp.m_strInvoiceCat = this.m_objViewer.ctlDataGrid4[d4, t_InvoiceType].ToString().Trim();
                        objtemp.m_strFrequency = "";
                        objtemp.m_strDosage = "";
                        objtemp.m_strDays = "";
                        objtemp.m_strUsage = "";
                        objtemp.m_strRowNo = d4.ToString();
                        obj_VO.objinjectArr.Add(objtemp);
                    }

                }
                for (int d5 = 0; d5 < this.m_objViewer.ctlDataGrid5.RowCount; d5++)
                {
                    if (this.m_objViewer.ctlDataGrid5[d5, 9].ToString().Trim() != "")
                    {
                        clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();
                        if (this.m_objViewer.ctlDataGrid5[d5, o_EnglishName].ToString().Trim() == "" || IsPrintEnglish)
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid5[d5, o_Name].ToString().Trim();
                        }
                        else
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid5[d5, o_EnglishName].ToString().Trim();
                        }

                        objtemp.m_strCount = this.m_objViewer.ctlDataGrid5[d5, o_Count].ToString().Trim() + this.m_objViewer.ctlDataGrid5[d5, o_Unit].ToString().Trim();
                        objtemp.m_strPrice = this.m_objViewer.ctlDataGrid5[d5, o_Price].ToString().Trim();
                        objtemp.m_strSumPrice = this.m_objViewer.ctlDataGrid5[d5, o_SumMoney].ToString().Trim();
                        objtemp.m_strUnit = this.m_objViewer.ctlDataGrid5[d5, o_Unit].ToString().Trim();
                        objtemp.m_strInvoiceCat = this.m_objViewer.ctlDataGrid5[d5, o_InvoiceType].ToString().Trim();
                        objtemp.m_strFrequency = "";
                        objtemp.m_strDosage = "";
                        objtemp.m_strDays = "";
                        objtemp.m_strUsage = "";
                        objtemp.m_strRowNo = d5.ToString();
                        obj_VO.objinjectArr.Add(objtemp);
                    }

                }
                for (int d6 = 0; d6 < this.m_objViewer.ctlDataGrid6.RowCount; d6++)
                {
                    if (this.m_objViewer.ctlDataGrid6[d6, 9].ToString().Trim() != "")
                    {
                        clsOutpatientPrintRecipeDetail_VO objtemp = new clsOutpatientPrintRecipeDetail_VO();
                        if (this.m_objViewer.ctlDataGrid6[d6, o_EnglishName].ToString().Trim() == "" || IsPrintEnglish)
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid6[d6, o_Name].ToString().Trim();
                        }
                        else
                        {
                            objtemp.m_strChargeName = this.m_objViewer.ctlDataGrid6[d6, o_EnglishName].ToString().Trim();
                        }
                        objtemp.m_strCount = this.m_objViewer.ctlDataGrid6[d6, o_Count].ToString().Trim() + this.m_objViewer.ctlDataGrid6[d6, o_Unit].ToString().Trim();
                        objtemp.m_strPrice = this.m_objViewer.ctlDataGrid6[d6, o_Price].ToString().Trim();
                        objtemp.m_strSumPrice = this.m_objViewer.ctlDataGrid6[d6, o_SumMoney].ToString().Trim();
                        objtemp.m_strUnit = this.m_objViewer.ctlDataGrid6[d6, o_Unit].ToString().Trim();
                        objtemp.m_strInvoiceCat = this.m_objViewer.ctlDataGrid6[d6, o_InvoiceType].ToString().Trim();
                        objtemp.m_strFrequency = "";
                        objtemp.m_strDosage = "";
                        objtemp.m_strDays = "";
                        objtemp.m_strUsage = "";
                        objtemp.m_strRowNo = d6.ToString();
                        if (this.m_objViewer.ctlDataGrid6[d6, o_DeptmedID].ToString().Trim() == "1")
                        {
                            objtemp.m_strDeptmedInfo = "【KB】";
                        }
                        else
                        {
                            objtemp.m_strDeptmedInfo = "";
                        }
                        obj_VO.objinjectArr.Add(objtemp);
                    }

                }
                //				objPRDArr.Sort(0,objPRDArr.Count,null);
                objPRDArr2.Sort(0, objPRDArr2.Count, null);
                obj_VO.objinjectArr2.Sort(0, obj_VO.objinjectArr2.Count, null);
                obj_VO.objPRDArr = objPRDArr;
                obj_VO.objPRDArr2 = objPRDArr2;
                if (this.m_objViewer.cmbRecipeType.SelectedIndex > -1)
                {
                    objCalPatientCharge.RecipeTypeInfo = this.m_objViewer.cmbRecipeType.SelectedItem as clsRecipeType_VO;
                }

                objCalPatientCharge.PrintRecipeVOInfo = obj_VO;
            }

        }

        public void m_mthPrint(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (this.m_objViewer.btPrint.Tag == null)
            {
                e.Cancel = true;
                return;
            }
            if (this.m_objViewer.btPrint.Tag.ToString() == "2")
            {
                objCaseHistoryPrint.m_mthBegionPrint(e);
            }
            else
            {
                #region 收集数据
                objCalPatientCharge.m_mthPrintRecipe(e, this.m_objViewer.btPrint.Tag.ToString());
                #endregion
            }

        }
        public void m_mthShowPrint()
        {
            if (this.m_objViewer.btPrint.Tag.ToString() == "1" || this.m_objViewer.btPrint.Tag.ToString() == "3")
            {
                if (this.m_objViewer.btSave.Tag == null)
                {
                    MessageBox.Show("请先保存处方数据或处方为空，打印终止。", "ICare系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            if (this.m_objViewer.btPrint.Tag.ToString() == "2")
            {
                if (this.m_objViewer.objCaseHistory.CaseHistoryID.Trim() == "")
                {
                    MessageBox.Show("请先保存病历数据或无病历，打印终止。", "ICare系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            try
            {
                if (this.m_objViewer.cmbRecipeType.SelectedIndex > -1)
                {
                    ((clsRecipeType_VO)this.m_objViewer.cmbRecipeType.SelectedItem).REMARK_VCHR = "开始打印";
                }
                //PrintPreviewControl pcc=null;
                //foreach(System.Windows.Forms.Control c in this.m_objViewer.printPreviewDialog1.Controls)
                //{
                //    if(c is PrintPreviewControl)
                //    {
                //        pcc=(PrintPreviewControl)c;
                //    }
                //}
                //pcc.Zoom=1;
                this.m_objViewer.printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                this.m_objViewer.printPreviewDialog1.ShowDialog();
            }
            catch
            {
                MessageBox.Show("请先连接打印机!");
            }
        }
        #endregion

        #region 判断剂量是否超标(西药)
        public bool m_mthIsOverflow(int row, string strValue)
        {
            //		decimal max=this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row,23]);
            //		decimal min=this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row,24]);
            //			if(this.m_mthConvertObjToDecimal(strValue)>max&&max!=0)
            //			{
            //				if(MessageBox.Show("请注意,剂量超过了上限!是否继续?","ICare",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
            //				{
            //				this.m_objViewer.ctlDataGrid1[row,1]=this.m_objViewer.ctlDataGrid1[row,22];
            //				return false;
            //				}
            //				else
            //				{
            //				return true;
            //				}
            //			}
            //			if(this.m_mthConvertObjToDecimal(strValue)<min&&min!=0)
            //			{
            //				if(MessageBox.Show("请注意,剂量超过了下限!是否继续?","ICare",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
            //				{
            //					this.m_objViewer.ctlDataGrid1[row,1]=this.m_objViewer.ctlDataGrid1[row,22];
            //					return false;
            //				}
            //				else
            //				{
            //					return true;
            //				}
            //			}
            return true;
        }
        #endregion

        #region 判断剂量是否超标(中药)
        public bool m_mthIsOverflow2(int row, string strValue)
        {
            //			decimal max=this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[row,12]);
            //			decimal min=this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row,13]);
            //			if(this.m_mthConvertObjToDecimal(strValue)>max&&max!=0)
            //			{
            //				if(MessageBox.Show("请注意,剂量超过了上限!是否继续?","ICare",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
            //				{
            //					this.m_objViewer.ctlDataGrid2[row,1]=this.m_objViewer.ctlDataGrid2[row,11];
            //					return false;
            //				}
            //				else
            //				{
            //					return true;
            //				}
            //			}
            //			if(this.m_mthConvertObjToDecimal(strValue)<min&&min!=0)
            //			{
            //				if(MessageBox.Show("请注意,剂量超过了下限!是否继续?","ICare",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
            //				{
            //					this.m_objViewer.ctlDataGrid2[row,1]=this.m_objViewer.ctlDataGrid1[row,11];
            //					return false;
            //				}
            //				else
            //				{
            //					return true;
            //				}
            //			}
            return true;
        }
        #endregion

        #region 作废处方
        public void m_mthDelRecipe(string p_statues)
        {
            long l = objSvc.m_mthDelRecipe(this.m_objViewer.btSave.Tag.ToString().Trim(), "-1");
            if (l == 2)
            {
                MessageBox.Show("该处方已经结账,不能作废!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.lbeFlag.Text = "2";
                return;
            }
            if (l == -3)
            {
                MessageBox.Show("药品（或材料）已配或已发,不能作废!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (l == -5)
            {
                MessageBox.Show("存在已做的检验,不能作废!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (l == -7)
            {
                MessageBox.Show("存在已做的检查,不能作废!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (l != -4)
            {
                if (p_statues == "0")
                {
                    //只清空处方内容
                    this.m_mthClearAllData2();
                }
                else
                {
                    //清空处方和病历内容
                    this.m_mthClearAllData();
                }
            }
            else
            {
                MessageBox.Show("作废处方失败!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 根据用法查找附加的收费项目,并放入其他页的收费项目
        /// <summary>
        /// 根据用法查找附加的收费项目,并放入其他页的收费项目
        /// </summary>
        /// <param name="strItemID">项目ID</param>
        /// <param name="flag">true 时删除原来的附加项目,false 时新增项目</param>
        /// <param name="strID">原来的ID</param>
        /// <param name="p_introw">传入原来的行号,代表不把原来的行删除</param>
        public void m_mthGetChargeItemByUsageID(string strItemID, bool flag, string strID, int p_introw)
        {
            if (flag)
            {
                #region
                if (strID == "")
                {
                    return;
                }
                for (int i = this.m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
                {
                    if (i == p_introw)
                    {
                        continue;
                    }
                    if (strID == this.m_objViewer.ctlDataGrid1[i, c_SubItemID].ToString().Trim())
                    {
                        if (this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                    }
                }
                for (int i = this.m_objViewer.ctlDataGrid2.RowCount - 1; i >= 0; i--)
                {
                    if (strID == this.m_objViewer.ctlDataGrid2[i, 22].ToString().Trim())
                    {
                        if (this.m_objViewer.ctlDataGrid2[i, 9].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid2[i, 9].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid2.m_mthDeleteRow(i);
                    }
                }
                for (int i = this.m_objViewer.ctlDataGrid3.RowCount - 1; i >= 0; i--)
                {
                    if (strID == this.m_objViewer.ctlDataGrid3[i, t_OtherItemID].ToString().Trim())
                    {
                        if (this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid3.m_mthDeleteRow(i);
                    }
                }
                for (int i = this.m_objViewer.ctlDataGrid4.RowCount - 1; i >= 0; i--)
                {
                    if (strID == this.m_objViewer.ctlDataGrid4[i, t_OtherItemID].ToString().Trim())
                    {
                        if (this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid4.m_mthDeleteRow(i);
                    }
                }
                for (int i = this.m_objViewer.ctlDataGrid5.RowCount - 1; i >= 0; i--)
                {
                    if (strID == this.m_objViewer.ctlDataGrid5[i, o_OtherItemID].ToString().Trim())
                    {
                        if (this.m_objViewer.ctlDataGrid5[i, 9].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid5[i, 9].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid5.m_mthDeleteRow(i);
                    }
                }
                for (int c = this.m_objViewer.ctlDataGrid6.RowCount - 1; c >= 0; c--)
                {
                    if (strID == this.m_objViewer.ctlDataGrid6[c, o_OtherItemID].ToString().Trim())
                    {
                        if (this.m_objViewer.ctlDataGrid6[c, 9].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid6[c, 9].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid6.m_mthDeleteRow(c);

                    }
                }
                //这里加入删除附加收费项目
                #endregion 删除原来的项目
            }
            else
            {
                if (strItemID == "")
                {
                    return;
                }
                DataTable dt = null;
                long strRet = objSvc.m_mthGetChargeItemByUsageID(strItemID, this.m_objViewer.m_PatInfo.PayTypeID, out dt);
                if (strRet > 0 && dt.Rows.Count > 0)
                {
                    this.m_objViewer.ctlDataGrid1[p_introw, c_Fage] = "1";
                    int tempRow = 0;
                    decimal temp = 0;
                    DataRow dtrTemp = null;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        dtrTemp = dt.Rows[i];
                        int intFlag = 1;
                        if (dtrTemp["continueusetype_int"].ToString().Trim() != "0")
                        {
                            intFlag = -1;
                        }

                        switch (m_mthRelationInfo(dtrTemp["itemopinvtype_chr"].ToString()))
                        {
                            case "0001":
                                tempRow = this.m_objViewer.ctlDataGrid1.RowCount;
                                this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Find] = dtrTemp["itemcode_vchr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Count] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Unit] = dtrTemp["clinictype_int"].ToString() == "2" ? dtrTemp["dosageunit_chr"].ToString() : dtrTemp["opchargeflg_int"].ToString().Trim() == "0" ? dtrTemp["itemopunit_chr"].ToString().Trim() : dtrTemp["itemipunit_chr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Name] = dtrTemp["itemname_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Spec] = dtrTemp["itemspec_vchr"].ToString();
                                if (dtrTemp["opchargeflg_int"].ToString().Trim() == "0")
                                {
                                    this.m_objViewer.ctlDataGrid1[tempRow, c_Price] = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]);
                                    m_objViewer.ctlDataGrid1[tempRow, c_BigUnit] = dtrTemp["itemopunit_chr"].ToString().Trim();//大单位
                                }
                                else
                                {
                                    decimal decTemp = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]) / m_mthConvertObjToDecimal(dtrTemp["packqty_dec"]);
                                    this.m_objViewer.ctlDataGrid1[tempRow, c_Price] = decTemp.ToString("0.0000");
                                    m_objViewer.ctlDataGrid1[tempRow, c_BigUnit] = dtrTemp["itemipunit_chr"].ToString().Trim();//小单位

                                }
                                this.m_objViewer.ctlDataGrid1[tempRow, c_SumMoney] = 0;
                                this.m_objViewer.ctlDataGrid1[tempRow, c_ItemID] = dtrTemp["itemid_chr"].ToString();
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Packet] = m_mthConvertObjToDecimal(dtrTemp["packqty_dec"]);

                                this.m_objViewer.ctlDataGrid1[tempRow, c_GroupNo] = this.m_objViewer.ctlDataGrid1[p_introw, c_GroupNo];
                                this.m_objViewer.ctlDataGrid1[tempRow, c_UsageName] = this.m_objViewer.ctlDataGrid1[p_introw, c_UsageName];
                                this.m_objViewer.ctlDataGrid1[tempRow, c_FreName] = this.m_objViewer.ctlDataGrid1[p_introw, c_FreName];
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Day] = this.m_objViewer.ctlDataGrid1[p_introw, c_Day];
                                this.m_objViewer.ctlDataGrid1[tempRow, c_FreDays] = this.m_objViewer.ctlDataGrid1[p_introw, c_FreDays];
                                this.m_objViewer.ctlDataGrid1[tempRow, c_FreTimes] = this.m_objViewer.ctlDataGrid1[p_introw, c_FreTimes];
                                this.m_objViewer.ctlDataGrid1[tempRow, c_UsageID] = this.m_objViewer.ctlDataGrid1[p_introw, c_UsageID];
                                this.m_objViewer.ctlDataGrid1[tempRow, c_FreID] = this.m_objViewer.ctlDataGrid1[p_introw, c_FreID];
                                temp = 100;
                                //if (objCalPatientCharge != null)
                                //{
                                //    temp = objCalPatientCharge.m_mthGetDiscountByID(dtrTemp["ITEMID_CHR"].ToString());
                                //}
                                if (dtrTemp["precent_dec"].ToString().Trim() != string.Empty)
                                {
                                    temp = Convert.ToDecimal(dtrTemp["precent_dec"].ToString());
                                }
                                m_objViewer.ctlDataGrid1[tempRow, c_DiscountName] = temp.ToString() + "%";
                                m_objViewer.ctlDataGrid1[tempRow, c_Discount] = temp;
                                this.m_objViewer.ctlDataGrid1[tempRow, c_UnitFlag] = dtrTemp["opchargeflg_int"].ToString();
                                this.m_objViewer.ctlDataGrid1[tempRow, c_EnglishName] = dtrTemp["itemengname_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Dosage] = dtrTemp["dosage_dec"].ToString();
                                this.m_objViewer.ctlDataGrid1[tempRow, c_IsCal] = 1;
                                this.m_objViewer.ctlDataGrid1[tempRow, c_InvoiceType] = dtrTemp["itemopinvtype_chr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid1[tempRow, c_SubItemID] = strID;
                                this.m_objViewer.ctlDataGrid1[tempRow, c_IsMain] = p_introw;
                                this.m_objViewer.ctlDataGrid1[tempRow, c_PreCount] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]) * intFlag;

                                if (dtrTemp["deptprep_int"].ToString() != "1")
                                {
                                    this.m_objViewer.ctlDataGrid1[tempRow, c_DeptmedID] = "*";
                                }

                                m_mthCalculateAmount(tempRow);
                                break;
                            case "0002"://暂时屏蔽 2005-9-29
                                //								tempRow =this.m_objViewer.ctlDataGrid2.RowCount;
                                //								this.m_objViewer.ctlDataGrid2.m_mthAppendRow();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,0]=dtrTemp["ITEMCODE_VCHR"].ToString().Trim();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,1]=m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                //								this.m_objViewer.ctlDataGrid2[tempRow,2]=dtrTemp["DOSAGEUNIT_CHR"].ToString();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,3]=dtrTemp["ITEMNAME_VCHR"].ToString();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,4]=dtrTemp["ITEMSPEC_VCHR"].ToString();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,5]="";
                                //								this.m_objViewer.ctlDataGrid2[tempRow,6]=m_mthConvertObjToDecimal(dtrTemp["ITEMPRICE_MNY"]);
                                //								this.m_objViewer.ctlDataGrid2[tempRow,7]=0;
                                ////									this.m_objViewer.ctlDataGrid2[tempRow,7]=m_mthConvertObjToDecimal(dtrTemp["SUMMONEY"]);
                                //								this.m_objViewer.ctlDataGrid2[tempRow,8]=dtrTemp["ITEMID_CHR"].ToString();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,12]=m_mthConvertObjToDecimal(dtrTemp["DOSAGE_DEC"]);
                                //								this.m_objViewer.ctlDataGrid2[tempRow,16]=dtrTemp["itemprice_mny"].ToString();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,17]=dtrTemp["OPCHARGEFLG_INT"].ToString();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,18]=dtrTemp["PACKQTY_DEC"].ToString();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,20]=dtrTemp["ITEMOPINVTYPE_CHR"].ToString().Trim();
                                //								this.m_objViewer.ctlDataGrid2[tempRow,24]=dtrTemp["itemengname_vchr"].ToString().Trim();
                                //								temp =100;
                                //								if(objCalPatientCharge!=null)
                                //								{
                                //									temp=objCalPatientCharge.m_mthGetDiscountByID(dtrTemp["ITEMID_CHR"].ToString());
                                //								}
                                //								m_objViewer.ctlDataGrid2[tempRow,10]=temp.ToString()+"%";
                                //								m_objViewer.ctlDataGrid2[tempRow,11]=temp;
                                //								this.m_objViewer.ctlDataGrid2[tempRow,9]="-1";
                                //								this.m_objViewer.ctlDataGrid2[tempRow,22]=strID;
                                //								this.m_objViewer.ctlDataGrid2[tempRow,23]=m_mthConvertObjToDecimal(dtrTemp["qty_dec"])*intFlag;
                                //								m_mthCalculateAmount2(i);
                                break;
                            case "0003":
                                tempRow = this.m_objViewer.ctlDataGrid3.RowCount;
                                this.m_objViewer.ctlDataGrid3.m_mthAppendRow();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_Find] = dtrTemp["itemcode_vchr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_Count] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                this.m_objViewer.ctlDataGrid3[tempRow, t_Name] = dtrTemp["itemname_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_Spec] = dtrTemp["itemspec_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_Unit] = dtrTemp["itemunit_chr"].ToString();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_Price] = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]);
                                this.m_objViewer.ctlDataGrid3[tempRow, t_SumMoney] = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]) * m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                this.m_objViewer.ctlDataGrid3[tempRow, t_ItemID] = dtrTemp["itemid_chr"].ToString();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_PriceFlag] = dtrTemp["selfdefine_int"].ToString();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_OtherItemID] = strID;
                                this.m_objViewer.ctlDataGrid3[tempRow, t_OtherCount] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]) * intFlag;
                                this.m_objViewer.ctlDataGrid3[tempRow, t_EnglishName] = dtrTemp["itemengname_vchr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_PartName] = dtrTemp["sample_type_desc_vchr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_Temp] = dtrTemp["sample_type_id_chr"].ToString().Trim();
                                temp = 100;
                                //if (objCalPatientCharge != null)
                                //{
                                //    temp = objCalPatientCharge.m_mthGetDiscountByID(dtrTemp["ITEMID_CHR"].ToString());
                                //}
                                if (dtrTemp["precent_dec"].ToString().Trim() != string.Empty)
                                {
                                    temp = Convert.ToDecimal(dtrTemp["precent_dec"].ToString());
                                }
                                m_objViewer.ctlDataGrid3[tempRow, t_DiscountName] = temp.ToString() + "%";
                                m_objViewer.ctlDataGrid3[tempRow, t_Discount] = temp;
                                this.m_objViewer.ctlDataGrid3[tempRow, t_InvoiceType] = dtrTemp["itemopinvtype_chr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid3[tempRow, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtrTemp["itemid_chr"].ToString(),
                                m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]), dtrTemp["itemopinvtype_chr"].ToString().Trim(), m_mthConvertObjToDecimal(dtrTemp["qty_dec"]), 3000, temp, "", false);
                                break;
                            case "0004":

                                tempRow = this.m_objViewer.ctlDataGrid4.RowCount;
                                this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_Find] = dtrTemp["itemcode_vchr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_Count] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                this.m_objViewer.ctlDataGrid4[tempRow, t_Name] = dtrTemp["itemname_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_Spec] = dtrTemp["itemspec_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_Unit] = dtrTemp["itemunit_chr"].ToString();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_Price] = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]);
                                this.m_objViewer.ctlDataGrid4[tempRow, t_SumMoney] = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]) * m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                this.m_objViewer.ctlDataGrid4[tempRow, t_ItemID] = dtrTemp["itemid_chr"].ToString();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_PriceFlag] = dtrTemp["selfdefine_int"].ToString();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_OtherItemID] = strID;
                                this.m_objViewer.ctlDataGrid4[tempRow, t_OtherCount] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]) * intFlag;
                                this.m_objViewer.ctlDataGrid4[tempRow, t_EnglishName] = dtrTemp["itemengname_vchr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_PartName] = dtrTemp["partname"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_Temp] = dtrTemp["itemchecktype_chr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_UsageID] = dtrTemp["usageid_chr"].ToString().Trim();
                                temp = 100;
                                //if (objCalPatientCharge != null)
                                //{
                                //    temp = objCalPatientCharge.m_mthGetDiscountByID(dtrTemp["ITEMID_CHR"].ToString());
                                //}
                                if (dtrTemp["precent_dec"].ToString().Trim() != string.Empty)
                                {
                                    temp = Convert.ToDecimal(dtrTemp["precent_dec"].ToString());
                                }
                                m_objViewer.ctlDataGrid4[tempRow, t_DiscountName] = temp.ToString() + "%";
                                m_objViewer.ctlDataGrid4[tempRow, t_Discount] = temp;
                                this.m_objViewer.ctlDataGrid4[tempRow, t_InvoiceType] = dtrTemp["itemopinvtype_chr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid4[tempRow, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtrTemp["itemid_chr"].ToString(),
                                m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]), dtrTemp["itemopinvtype_chr"].ToString().Trim(), m_mthConvertObjToDecimal(dtrTemp["qty_dec"]), 3000, temp, "", false);
                                break;
                            case "0006":
                                tempRow = this.m_objViewer.ctlDataGrid5.RowCount;
                                this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                                this.m_objViewer.ctlDataGrid5[tempRow, o_Find] = dtrTemp["itemcode_vchr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid5[tempRow, o_Count] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                this.m_objViewer.ctlDataGrid5[tempRow, o_Name] = dtrTemp["itemname_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid5[tempRow, o_Spec] = dtrTemp["itemspec_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid5[tempRow, o_Unit] = dtrTemp["itemunit_chr"].ToString();
                                this.m_objViewer.ctlDataGrid5[tempRow, o_Price] = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]);
                                this.m_objViewer.ctlDataGrid5[tempRow, o_SumMoney] = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]) * m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                this.m_objViewer.ctlDataGrid5[tempRow, o_ItemID] = dtrTemp["itemid_chr"].ToString();
                                this.m_objViewer.ctlDataGrid5[tempRow, o_PriceFlag] = dtrTemp["selfdefine_int"].ToString();
                                this.m_objViewer.ctlDataGrid5[tempRow, o_OtherItemID] = strID;
                                this.m_objViewer.ctlDataGrid5[tempRow, o_OtherCount] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]) * intFlag;
                                this.m_objViewer.ctlDataGrid5[tempRow, o_EnglishName] = dtrTemp["itemengname_vchr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid5[tempRow, o_UsageID] = dtrTemp["usageid_chr"].ToString().Trim();
                                temp = 100;
                                //if (objCalPatientCharge != null)
                                //{
                                //    temp = objCalPatientCharge.m_mthGetDiscountByID(dtrTemp["ITEMID_CHR"].ToString());
                                //}
                                if (dtrTemp["precent_dec"].ToString().Trim() != string.Empty)
                                {
                                    temp = Convert.ToDecimal(dtrTemp["precent_dec"].ToString());
                                }
                                m_objViewer.ctlDataGrid5[tempRow, o_DiscountName] = temp.ToString() + "%";
                                m_objViewer.ctlDataGrid5[tempRow, o_Discount] = temp;
                                this.m_objViewer.ctlDataGrid5[tempRow, o_InvoiceType] = dtrTemp["itemopinvtype_chr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid5[tempRow, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtrTemp["itemid_chr"].ToString(),
                                m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]), dtrTemp["itemopinvtype_chr"].ToString().Trim(), m_mthConvertObjToDecimal(dtrTemp["qty_dec"]), 3000, temp, "", false);
                                break;
                            default://其他
                                tempRow = this.m_objViewer.ctlDataGrid6.RowCount;
                                this.m_objViewer.ctlDataGrid6.m_mthAppendRow();
                                this.m_objViewer.ctlDataGrid6[tempRow, o_Find] = dtrTemp["itemcode_vchr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid6[tempRow, o_Count] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                this.m_objViewer.ctlDataGrid6[tempRow, o_Name] = dtrTemp["itemname_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid6[tempRow, o_Spec] = dtrTemp["itemspec_vchr"].ToString();
                                this.m_objViewer.ctlDataGrid6[tempRow, o_Unit] = dtrTemp["opchargeflg_int"].ToString() == "0" ? dtrTemp["itemopunit_chr"].ToString() : dtrTemp["itemipunit_chr"].ToString();

                                //this.m_objViewer.ctlDataGrid6[tempRow, o_Unit] = dtrTemp["ITEMOPUNIT_CHR"].ToString();
                                this.m_objViewer.ctlDataGrid6[tempRow, o_Price] = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]);
                                this.m_objViewer.ctlDataGrid6[tempRow, o_SumMoney] = m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]) * m_mthConvertObjToDecimal(dtrTemp["qty_dec"]);
                                this.m_objViewer.ctlDataGrid6[tempRow, o_ItemID] = dtrTemp["itemid_chr"].ToString();
                                this.m_objViewer.ctlDataGrid6[tempRow, o_PriceFlag] = dtrTemp["selfdefine_int"].ToString();
                                this.m_objViewer.ctlDataGrid6[tempRow, o_OtherItemID] = strID;
                                this.m_objViewer.ctlDataGrid6[tempRow, o_OtherCount] = m_mthConvertObjToDecimal(dtrTemp["qty_dec"]) * intFlag;
                                this.m_objViewer.ctlDataGrid6[tempRow, o_EnglishName] = dtrTemp["itemengname_vchr"].ToString().Trim();
                                temp = 100;
                                //if (objCalPatientCharge != null)
                                //{
                                //xiong
                                //temp = objCalPatientCharge.m_mthGetDiscountByID(dtrTemp["ITEMID_CHR"].ToString());                                    
                                //}
                                if (dtrTemp["precent_dec"].ToString().Trim() != string.Empty)
                                {
                                    temp = Convert.ToDecimal(dtrTemp["precent_dec"].ToString());
                                }

                                m_objViewer.ctlDataGrid6[tempRow, o_DiscountName] = temp.ToString() + "%";
                                m_objViewer.ctlDataGrid6[tempRow, o_Discount] = temp;
                                this.m_objViewer.ctlDataGrid6[tempRow, o_InvoiceType] = dtrTemp["itemopinvtype_chr"].ToString().Trim();
                                this.m_objViewer.ctlDataGrid6[tempRow, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtrTemp["itemid_chr"].ToString(),
                                m_mthConvertObjToDecimal(dtrTemp["itemprice_mny"]), dtrTemp["itemopinvtype_chr"].ToString().Trim(), m_mthConvertObjToDecimal(dtrTemp["qty_dec"]), 3000, temp, "", false);

                                if (dtrTemp["deptprep_int"].ToString() != "1")
                                {
                                    this.m_objViewer.ctlDataGrid6[tempRow, o_DeptmedID] = "*";
                                }

                                break;
                        }
                    }

                }
                else
                {
                    this.m_objViewer.ctlDataGrid1[p_introw, 31] = "";
                }

                //这时加入附加项目
            }



            //			DataTable dt=null;
            //			long strRet=objSvc.m_mthGetChargeItemByUsageID(strID,out dt);
            //			if(strRet>0&&dt.Rows.Count>0)
            //			{
            //				int count =this.m_objViewer.ctlDataGrid6.RowCount;
            //				if(flag)
            //				{
            //					for(int ii=0;ii<dt.Rows.Count;ii++)
            //					{
            //						for(int c=this.m_objViewer.ctlDataGrid6.RowCount-1;c>=0;c--)
            //						{
            //							if(dt.Rows[ii]["ITEMID"].ToString().Trim()==this.m_objViewer.ctlDataGrid6[c,7].ToString().Trim())
            //							{
            //								if(this.m_objViewer.ctlDataGrid6[c,9].ToString().Trim()!="")
            //								{
            //									objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid6[c,9].ToString()));
            //								}
            //								this.m_objViewer.ctlDataGrid6.m_mthDeleteRow(c);
            //								break;
            //							}
            //						}
            //						//这里加入删除附加收费项目
            //					}
            //				}
            //				else
            //				{
            //					for(int i=0;i<dt.Rows.Count;i++)
            //					{
            //						this.m_objViewer.ctlDataGrid6.m_mthAppendRow();
            //						this.m_objViewer.ctlDataGrid6[i+count,1]=m_mthConvertObjToDecimal(dtrTemp["quantity"]);
            //						this.m_objViewer.ctlDataGrid6[i+count,2]=dtrTemp["ITEMNAME"].ToString();
            //						this.m_objViewer.ctlDataGrid6[i+count,3]=dtrTemp["DEC"].ToString();
            //						this.m_objViewer.ctlDataGrid6[i+count,4]=dtrTemp["UNIT"].ToString();
            //						this.m_objViewer.ctlDataGrid6[i+count,5]=m_mthConvertObjToDecimal(dtrTemp["PRICE"]);
            //						this.m_objViewer.ctlDataGrid6[i+count,6]=m_mthConvertObjToDecimal(dtrTemp["SUMMONEY"]);
            //						this.m_objViewer.ctlDataGrid6[i+count,7]=dtrTemp["ITEMID"].ToString().Trim();
            //						this.m_objViewer.ctlDataGrid6[i+count,8]=dtrTemp["SELFDEFINE"].ToString();
            //						decimal temp =100;
            //						if(objCalPatientCharge!=null)
            //						{
            //							temp=objCalPatientCharge.m_mthGetDiscountByID(dtrTemp["ITEMID"].ToString());
            //						}
            //						m_objViewer.ctlDataGrid6[i+count,10]=temp.ToString()+"%";
            //						m_objViewer.ctlDataGrid6[i+count,11]=temp;
            //						this.m_objViewer.ctlDataGrid6[i+count,9]=objCalPatientCharge.m_mthGetChargeIetmPrice(dtrTemp["ITEMID"].ToString(),m_mthConvertObjToDecimal(dtrTemp["PRICE"]),"",1,3000,temp,"");
            //
            //					}
            //				}
            //			}
        }
        #endregion

        #region 病人类型转变
        /// <summary>
        /// 病人类型转变
        /// </summary>
        public void m_mthPatientTypeChanged()
        {
            //修改
            objCalPatientCharge = null;
            OPSApplyarr = new ArrayList();
            objCalPatientCharge = new clsCalcPatientCharge(m_objViewer.m_PatInfo.PatientID, m_objViewer.m_PatInfo.PayTypeID, m_objViewer.m_PatInfo.Limit, this.m_objComInfo.m_strGetHospitalTitle(), m_objViewer.m_PatInfo.PatientType, m_objViewer.m_PatInfo.Discount);
            decimal discount;
            decimal count;
            string strItemID;
            decimal price;

            ArrayList objItemArr = new ArrayList();
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, c_RowNo] != null && this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid2[i, 9] != null && this.m_objViewer.ctlDataGrid2[i, 9].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid2[i, 8].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid3[i, t_RowNo] != null && this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid4[i, t_RowNo] != null && this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid5[i, 9] != null && this.m_objViewer.ctlDataGrid5[i, 9].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid5[i, 7].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid6[i, 9] != null && this.m_objViewer.ctlDataGrid6[i, 9].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid6[i, 7].ToString().Trim());
                }
            }

            Hashtable hasItemScale = new Hashtable();
            if (objItemArr.Count > 0)
            {
                //string[] strItemIDArr = new string[objItemArr.Count];
                //for (int i = 0; i < objItemArr.Count; i++)
                //{
                //    strItemIDArr[i] = objItemArr[i].ToString();
                //}

                string[] strItemIDArr = (string[])objItemArr.ToArray(typeof(string));
                this.objSvc.m_lngGetItemScaleByArr(this.m_objViewer.m_PatInfo.PayTypeID, strItemIDArr, ref hasItemScale);
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, c_RowNo] != null && this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString().Trim() != "")
                {
                    strItemID = this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString().Trim();
                    discount = Convert.ToDecimal(hasItemScale[strItemID].ToString());
                    this.m_objViewer.ctlDataGrid1[i, c_Discount] = discount;
                    this.m_objViewer.ctlDataGrid1[i, c_DiscountName] = discount.ToString() + "%";
                    count = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Total]);
                    price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Price]);
                    m_objViewer.ctlDataGrid1[i, c_RowNo] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strItemID, price, this.m_objViewer.ctlDataGrid1[i, c_InvoiceType].ToString().Trim(), count, 3000, discount, "", false);

                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid2[i, 9] != null && this.m_objViewer.ctlDataGrid2[i, 9].ToString().Trim() != "")
                {
                    strItemID = this.m_objViewer.ctlDataGrid2[i, 8].ToString().Trim();
                    discount = Convert.ToDecimal(hasItemScale[strItemID].ToString());
                    this.m_objViewer.ctlDataGrid2[i, 11] = discount;
                    this.m_objViewer.ctlDataGrid2[i, 10] = discount.ToString() + "%";
                    count = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 1]) * this.m_objViewer.numericUpDown1.Value;

                    price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 6]);
                    m_objViewer.ctlDataGrid2[i, 9] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strItemID, price, this.m_objViewer.ctlDataGrid2[i, 20].ToString().Trim(), count, 3000, discount, "", false);

                }
            }
            ////////////////////////3333
            Hashtable hlis = new Hashtable();
            for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid3[i, t_RowNo] != null && this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString().Trim() != "")
                {
                    decimal scale = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_lis_discount]);
                    strItemID = this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim();
                    discount = Convert.ToDecimal(hasItemScale[strItemID].ToString()) * scale;
                    this.m_objViewer.ctlDataGrid3[i, t_Discount] = discount;
                    this.m_objViewer.ctlDataGrid3[i, t_DiscountName] = discount.ToString() + "%";
                    count = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Count]);
                    price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Price]);
                    m_objViewer.ctlDataGrid3[i, t_RowNo] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strItemID, price, this.m_objViewer.ctlDataGrid3[i, t_InvoiceType].ToString().Trim(), count, 3000, discount, "", false);

                    if (ItemInputMode == 1)
                    {
                        string id = this.m_objViewer.ctlDataGrid3[i, t_lis_orderitem].ToString().Trim();
                        clsOrder_VO Order_VO = hasOrderID["lis->" + id] as clsOrder_VO;
                        DataTable dt = Order_VO.EntryDT;

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["ITEMID_CHR"].ToString() == strItemID)
                            {
                                dt.Rows[j]["precent_dec"] = Convert.ToString(discount);

                                decimal d = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Price]) * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_lis_ordernum]) * discount / 100;
                                if (hlis.ContainsKey(id))
                                {
                                    hlis[id] = m_mthConvertObjToDecimal(hlis[id]) + m_mthConvertObjToDecimal(d.ToString("0.00"));
                                }
                                else
                                {
                                    hlis.Add(id, d);
                                }
                                break;
                            }
                        }
                    }
                }
            }

            if (ItemInputMode == 1)
            {
                for (int i = 0; i < this.m_objViewer.ctlDataGridLis.RowCount; i++)
                {
                    string id = this.m_objViewer.ctlDataGridLis[i, t_resubitem].ToString().Trim().Replace("[PK]", "");
                    if (hlis.ContainsKey(id))
                    {
                        decimal basemny = m_mthConvertObjToDecimal(hlis[id]);
                        this.m_objViewer.ctlDataGridLis[i, t_Discount] = basemny;
                        this.m_objViewer.ctlDataGridLis[i, t_SumMoney] = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Count]) * basemny;
                        if (m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Price]) != basemny)
                        {
                            this.m_objViewer.ctlDataGridLis[i, t_DiscountName] = "打折";
                        }
                        else
                        {
                            this.m_objViewer.ctlDataGridLis[i, t_DiscountName] = "";
                        }
                    }
                }
            }

            /////////////////////4444444
            Hashtable htest = new Hashtable();
            for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid4[i, t_RowNo] != null && this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString().Trim() != "")
                {
                    strItemID = this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString().Trim();
                    discount = Convert.ToDecimal(hasItemScale[strItemID].ToString());
                    this.m_objViewer.ctlDataGrid4[i, t_Discount] = discount;
                    this.m_objViewer.ctlDataGrid4[i, t_DiscountName] = discount.ToString() + "%";
                    count = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Count]);
                    price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Price]);
                    m_objViewer.ctlDataGrid4[i, t_RowNo] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strItemID, price, this.m_objViewer.ctlDataGrid4[i, t_InvoiceType].ToString().Trim(), count, 3000, discount, "", false);

                    if (ItemInputMode == 1)
                    {
                        string id = this.m_objViewer.ctlDataGrid4[i, t_test_orderitem].ToString().Trim();
                        clsOrder_VO Order_VO = hasOrderID["test->" + id] as clsOrder_VO;
                        DataTable dt = Order_VO.EntryDT;

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["ITEMID_CHR"].ToString() == strItemID)
                            {
                                dt.Rows[j]["precent_dec"] = Convert.ToString(discount);

                                decimal d = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Price]) * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_test_ordernum]) * discount / 100;
                                if (htest.ContainsKey(id))
                                {
                                    htest[id] = m_mthConvertObjToDecimal(htest[id]) + m_mthConvertObjToDecimal(d.ToString("0.00"));
                                }
                                else
                                {
                                    htest.Add(id, d);
                                }
                                break;
                            }
                        }
                    }
                }
            }

            if (ItemInputMode == 1)
            {
                for (int i = 0; i < this.m_objViewer.ctlDataGridTest.RowCount; i++)
                {
                    string id = this.m_objViewer.ctlDataGridTest[i, t_resubitem].ToString().Trim().Replace("[PK]", "");
                    if (htest.ContainsKey(id))
                    {
                        decimal basemny = m_mthConvertObjToDecimal(htest[id]);
                        this.m_objViewer.ctlDataGridTest[i, t_Discount] = basemny;
                        this.m_objViewer.ctlDataGridTest[i, t_SumMoney] = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Count]) * basemny;
                        if (m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Price]) != basemny)
                        {
                            this.m_objViewer.ctlDataGridTest[i, t_DiscountName] = "打折";
                        }
                        else
                        {
                            this.m_objViewer.ctlDataGridTest[i, t_DiscountName] = "";
                        }
                    }
                }
            }

            /////////////////////555
            Hashtable hops = new Hashtable();
            for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid5[i, 9] != null && this.m_objViewer.ctlDataGrid5[i, 9].ToString().Trim() != "")
                {
                    strItemID = this.m_objViewer.ctlDataGrid5[i, 7].ToString().Trim();
                    discount = Convert.ToDecimal(hasItemScale[strItemID].ToString());
                    this.m_objViewer.ctlDataGrid5[i, 11] = discount;
                    this.m_objViewer.ctlDataGrid5[i, 10] = discount.ToString() + "%";
                    count = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, 1]);
                    price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, 5]);
                    m_objViewer.ctlDataGrid5[i, 9] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strItemID, price, this.m_objViewer.ctlDataGrid5[i, 12].ToString().Trim(), count, 3000, discount, "", false);

                    if (ItemInputMode == 1)
                    {
                        string id = this.m_objViewer.ctlDataGrid5[i, t_ops_orderitem].ToString().Trim();
                        clsOrder_VO Order_VO = hasOrderID["ops->" + id] as clsOrder_VO;
                        DataTable dt = Order_VO.EntryDT;

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            if (dt.Rows[j]["ITEMID_CHR"].ToString() == strItemID)
                            {
                                dt.Rows[j]["precent_dec"] = Convert.ToString(discount);

                                decimal d = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Price]) * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, t_ops_ordernum]) * discount / 100;
                                if (hops.ContainsKey(id))
                                {
                                    hops[id] = m_mthConvertObjToDecimal(hops[id]) + m_mthConvertObjToDecimal(d.ToString("0.00"));
                                }
                                else
                                {
                                    hops.Add(id, d);
                                }
                                break;
                            }
                        }
                    }
                }
            }

            if (ItemInputMode == 1)
            {
                for (int i = 0; i < this.m_objViewer.ctlDataGridOps.RowCount; i++)
                {
                    string id = this.m_objViewer.ctlDataGridOps[i, o_resubitem].ToString().Trim().Replace("[PK]", "");
                    if (hops.ContainsKey(id))
                    {
                        decimal basemny = m_mthConvertObjToDecimal(hops[id]);
                        this.m_objViewer.ctlDataGridOps[i, o_Discount] = basemny;
                        this.m_objViewer.ctlDataGridOps[i, o_SumMoney] = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Count]) * basemny;
                        if (m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Price]) != basemny)
                        {
                            this.m_objViewer.ctlDataGridOps[i, o_DiscountName] = "打折";
                        }
                        else
                        {
                            this.m_objViewer.ctlDataGridOps[i, o_DiscountName] = "";
                        }
                    }
                }
            }

            ///////////////////66666666666
            for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid6[i, 9] != null && this.m_objViewer.ctlDataGrid6[i, 9].ToString().Trim() != "")
                {
                    strItemID = this.m_objViewer.ctlDataGrid6[i, 7].ToString().Trim();
                    discount = Convert.ToDecimal(hasItemScale[strItemID].ToString());
                    this.m_objViewer.ctlDataGrid6[i, 11] = discount;
                    this.m_objViewer.ctlDataGrid6[i, 10] = discount.ToString() + "%";
                    count = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, 1]);
                    price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, 5]);
                    m_objViewer.ctlDataGrid6[i, 9] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strItemID, price, this.m_objViewer.ctlDataGrid6[i, 12].ToString().Trim(), count, 3000, discount, "", false);

                }
            }

        }
        #endregion

        #region 根据项目ID查出禁忌药品
        /// <summary>
        /// 根据项目ID查出禁忌药品
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="strItemName"></param>
        private void m_mthFindTabuByID(string ID, string strItemName)
        {
            DataTable dt;
            long l = this.objSvc.m_mthFindTabuByID(ID, out dt);
            DataRow dr;
            if (l > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i][0].ToString().Trim() == "" && dt.Rows.Count == 1)
                    {
                        dr = this.m_objViewer.alertLight1.CopyDataRow;
                        dr[0] = intNo;
                        dr[1] = ID;
                        dr[2] = strItemName;
                        dr[3] = "";
                        dr[4] = "";
                        dr[5] = -1;
                        this.m_objViewer.alertLight1.AddRow = dr;

                    }
                    else
                    {
                        if (dt.Rows[i][0].ToString().Trim() == "")
                        {
                            continue;
                        }
                        dr = this.m_objViewer.alertLight1.CopyDataRow;
                        dr[0] = intNo;
                        dr[1] = ID;
                        dr[2] = strItemName;
                        dr[3] = dt.Rows[i][0].ToString().Trim();
                        dr[4] = dt.Rows[i][1].ToString().Trim();
                        dr[5] = -1;
                        this.m_objViewer.alertLight1.AddRow = dr;
                    }
                }
            }
            else
            {
                dr = this.m_objViewer.alertLight1.CopyDataRow;
                dr[0] = intNo;
                dr[1] = ID;
                dr[2] = strItemName;
                dr[3] = "";
                dr[4] = "";
                dr[5] = -1;
                this.m_objViewer.alertLight1.AddRow = dr;
            }
            intNo++;

        }
        #endregion

        #region 获取候诊挂号
        /// <summary>
        /// 获取候诊挂号
        /// </summary>
        public void m_GetWaitReg()
        {
            DataTable dtSource = new DataTable();

            string strDoctor = "";
            string strDep = "";
            if (this.m_objViewer.ra_Person.Checked || this.m_objViewer.ra_both.Checked)
            {
                strDoctor = this.m_objViewer.LoginInfo.m_strEmpID;
                if (this.m_objViewer.ra_both.Checked)
                {
                    strDep = this.m_objViewer.cmbDeparment.SelectItemValue;
                }
            }
            else
            {
                strDep = this.m_objViewer.cmbDeparment.SelectItemValue;
            }

            objSvc.m_lngGetWaitReg(strDoctor, strDep, out dtSource);
            this.m_objViewer.m_dtgWaitReg.m_mthSetDataTable(dtSource);

        }

        public void m_GetWaitReg(string strDocID, string strDeptID, string strDeptName)
        {
            DataTable dtSource = new DataTable();

            this.m_objViewer.ra_both.Checked = true;
            this.m_objViewer.cmbDeparment.Text = strDeptName;

            objSvc.m_lngGetWaitReg(strDocID, strDeptID, out dtSource);
            this.m_objViewer.m_dtgWaitReg.m_mthSetDataTable(dtSource);
        }
        #endregion

        #region 获取就诊挂号
        /// <summary>
        /// 获取就诊挂号
        /// </summary>
        /// <param name="strBeginDate"></param>
        /// <param name="strEndDate"></param>
        public void m_GetTakeReg(string strBeginDate, string strEndDate)
        {
            DataTable dtSource = new DataTable();

            string strDoctor;
            //strDoctor = this.m_objViewer.LoginInfo.m_strEmpID;
            try
            {
                strDoctor = this.m_objViewer.LoginInfo.m_strEmpID;
            }
            catch
            {
                strDoctor = "0000001";
            }
            long strRet = objSvc.m_lngGetTakeGeg(strDoctor, strBeginDate, strEndDate, out dtSource);
            if (strRet > 0 && dtSource.Rows.Count > 0)
            {
                for (int i = 0; i < dtSource.Rows.Count; i++)
                {
                    if (dtSource.Rows[i]["PSTATUS_INT"].ToString().Trim() == "1")
                    {
                        dtSource.Rows[i]["STATE"] = "就诊中";
                    }
                    else
                    {
                        dtSource.Rows[i]["STATE"] = "结诊";
                    }
                }

                this.m_objViewer.lblPersonTimes.Text = dtSource.Rows.Count.ToString();
            }
            else
            {
                this.m_objViewer.lblPersonTimes.Text = "";
            }

            this.m_objViewer.m_dtgTake.m_mthSetDataTable(dtSource);
            this.m_mthFormatTakeGrid();
        }
        #endregion

        #region 转入就诊
        /// <summary>
        /// 转入就诊
        /// </summary>
        public void m_AddNewTake()
        {
            if (this.m_objViewer.m_dtgWaitReg.RowCount == 0)
            {
                return;
            }

            //this.m_objViewer.m_PatInfo.m_mthGetPatientInfoByCard(this.m_objViewer.m_dtgWaitReg[this.m_objViewer.m_dtgWaitReg.CurrentCell.RowNumber, 3].ToString().Trim());
            this.m_objViewer.m_PatInfo.m_mthGetPatientInfoByRegID(this.m_objViewer.m_dtgWaitReg[this.m_objViewer.m_dtgWaitReg.CurrentCell.RowNumber, 10].ToString().Trim());
            this.m_objViewer.m_dtgWaitReg.m_mthDeleteRow(this.m_objViewer.m_dtgWaitReg.CurrentCell.RowNumber);

        }
        #endregion

        #region 保存记录到接诊表
        /// <summary>
        /// 保存记录到接诊表
        /// </summary>
        /// <returns></returns>
        public bool m_blnInsertData()
        {
            clsTakeDiagrec objvo = new clsTakeDiagrec();
            objvo.m_strREGISTERID_CHR = this.m_objViewer.m_PatInfo.RegisterID;
            objvo.m_strTAKEDIAGDEPT_CHR = this.m_objViewer.m_PatInfo.DeptID;
            objvo.m_strPatientID = this.m_objViewer.m_PatInfo.PatientID;
            if (this.m_objViewer.m_PatInfo.PatientID.Trim() == "")
            {
                return false;
            }

            int Flag = 0;
            string NO = "";
            if (this.m_objViewer.m_PatInfo.RegisterID.Trim() != "")
            {
                NO = this.m_objViewer.m_PatInfo.RegisterID;
                Flag = 1;
            }
            else
            {
                NO = this.m_objViewer.m_PatInfo.PatientCardID;
                Flag = 2;
            }

            //int intRet = m_intGetPatientStatus(this.m_objViewer.m_PatInfo.PatientCardID);
            int intRet = m_intGetPatientStatus(NO, Flag);
            if (intRet == 0)
            {

                this.m_objViewer.txtLoadRecipeNo1.m_mthClearText();
                m_mthClearAllData();
                this.m_mthCreatCalObj();
                try
                {
                    objvo.m_strTAKEDIAGDR_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
                }
                catch
                {
                    objvo.m_strTAKEDIAGDR_CHR = "0000001";
                }
                objvo.m_strTAKEDIAGTIME_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string ID = "";
                long lngarg = objSvc.m_lngAddNewTake(objvo, out ID);
                if (lngarg > 0)
                {
                    objvo.m_strTAKEDIAGRECID_CHR = ID;
                    this.m_objViewer.m_dtgTake.m_mthAppendRow(new Object[] { "" });
                    int row = this.m_objViewer.m_dtgTake.RowCount - 1;
                    this.m_objViewer.m_PatInfo.TakeDiagRecID = objvo.m_strTAKEDIAGRECID_CHR.ToString().Trim();
                    this.m_objViewer.m_dtgTake[row, 0] = objvo.m_strTAKEDIAGRECID_CHR;
                    this.m_objViewer.m_dtgTake[row, 1] = objvo.m_strREGISTERID_CHR;
                    this.m_objViewer.m_dtgTake[row, 2] = this.m_objViewer.m_PatInfo.PatientCardID;
                    this.m_objViewer.m_dtgTake[row, 3] = this.m_objViewer.m_PatInfo.PatientName;
                    this.m_objViewer.m_dtgTake[row, 4] = this.m_objViewer.m_PatInfo.PatientSex;
                    this.m_objViewer.m_dtgTake[row, 5] = this.m_objViewer.m_PatInfo.PatientAge;
                    this.m_objViewer.m_dtgTake[row, 6] = this.m_objViewer.m_PatInfo.PayTypeName;
                    this.m_objViewer.m_dtgTake[row, 7] = objvo.m_strTAKEDIAGTIME_DAT;
                    this.m_objViewer.m_dtgTake[row, 9] = "就诊中";
                    this.m_objViewer.m_dtgTake[row, 10] = 1;

                    //把病人过敏药放在病历中去。
                    this.m_objViewer.objCaseHistory.Anaphylaxis = this.m_objViewer.m_PatInfo.Hypersusceptibility;

                    this.m_objViewer.lblPersonTimes.Text = this.m_objViewer.m_dtgTake.RowCount.ToString();
                }
                this.m_objViewer.tabControl1.SelectedIndex = 2;
            }
            else if (intRet == 1)
            {
                //调出当天最后一次病历
                this.m_mthGetPatientCaseHistory(this.m_objViewer.m_PatInfo.PatientID);
                //把病人过敏药放在病历中去。
                this.m_objViewer.objCaseHistory.Anaphylaxis = this.m_objViewer.m_PatInfo.Hypersusceptibility;

                //这里是“是否继续接诊后？”用户选择是的操作，用下面这个变量赋值为“0”作标记。
                //如果标记为“0”时不再插入就诊列表。
                objvo.m_strTAKEDIAGDEPT_CHR = "0";
                long lngarg = objSvc.m_lngAddNewTake(objvo, out objvo.m_strTAKEDIAGRECID_CHR);
                this.m_mthClearAllData2();
            }
            else if (intRet == 2)
            {
                this.m_mthClearAllData();
                this.m_objViewer.tabControl1.SelectedIndex = 1;
                this.m_objViewer.lbeTimes.Text = "0";
                this.m_objViewer.m_PatInfo.Clear();
                this.m_objViewer.m_PatInfo.Focus();
                this.m_objViewer.m_mthDisableIsVip();
                return false;
            }
            this.m_objViewer.lbeTimes.Text = (objSvc.m_mthGetPatientSeeDocTimes(this.m_objViewer.m_PatInfo.PatientID)).ToString();
            this.m_mthFormatTakeGrid();
            return true;
        }
        #endregion

        #region 判断病人就诊状态
        /// <summary>
        /// 如果该病人正在就诊返回false,否则为true;
        /// </summary>
        /// <param name="strCardID"></param>
        /// <param name="Flag">1 挂号ID 2 诊疗卡号</param>
        /// <returns>返回值： 0 第一次接诊； 1 复诊（继续接诊-是） 2 复诊（继续接诊-否）</returns>
        private int m_intGetPatientStatus(string NO, int Flag)
        {
            int intRet = 0;
            int temp = -1;
            for (int i = 0; i < this.m_objViewer.m_dtgTake.RowCount; i++)
            {
                if (Flag == 1)
                {
                    if (this.m_objViewer.m_dtgTake[i, 1].ToString().Trim() == NO)
                    {
                        temp = i;
                        break;
                    }
                }
                else if (Flag == 2)
                {
                    if (this.m_objViewer.m_dtgTake[i, 2].ToString().Trim() == NO)
                    {
                        temp = i;
                        break;
                    }
                }
            }
            if (temp < 0)
            {
                intRet = 0;
            }
            else
            {
                if (MessageBox.Show("是否继续接诊?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string strWaitID = this.m_objViewer.m_dtgTake[temp, 0].ToString().Trim();
                    long lngarg = objSvc.m_mthContinueTake(strWaitID, 1);
                    if (lngarg > 0)
                    {
                        this.m_objViewer.m_dtgTake[temp, 10] = 1;
                        this.m_objViewer.m_dtgTake[temp, 9] = "就诊中";
                        this.m_objViewer.m_dtgTake[temp, 8] = "";
                        this.m_objViewer.tabControl1.SelectedIndex = 3;
                        this.m_mthSetFocus();

                        this.m_objViewer.m_PatInfo.TakeDiagRecID = this.m_objViewer.m_dtgTake[temp, 0].ToString().Trim(); ;
                    }
                    intRet = 1;
                }
                else
                {
                    intRet = 2;
                }
            }
            return intRet;
        }
        #endregion

        #region 结束就诊
        /// <summary>
        /// 结束就诊
        /// </summary>
        /// <param name="m_IsEnd"></param>
        public void m_EndTakeReg(int m_IsEnd)
        {
            int row = this.m_objViewer.m_dtgTake.CurrentCell.RowNumber;
            bool b_Temp = false;
            if (this.m_objViewer.m_PatInfo.PatientID != "")
            {
                string tempTakeID = "";
                string tempState = "";
                for (int i = 0; i < this.m_objViewer.m_dtgTake.RowCount; i++)
                {
                    tempTakeID = this.m_objViewer.m_dtgTake[i, 0].ToString().Trim();
                    tempState = this.m_objViewer.m_dtgTake[i, 10].ToString().Trim();
                    if (this.m_objViewer.m_PatInfo.TakeDiagRecID == tempTakeID && tempState != "2")
                    {
                        row = i;
                        b_Temp = true;
                        break;
                    }
                }
            }
            //没找到满足条件的患者
            if (!b_Temp)
            {
                return;
            }

            string strWaitID = this.m_objViewer.m_dtgTake[row, 0].ToString().Trim();
            string strRegisterID = this.m_objViewer.m_dtgTake[row, 1].ToString().Trim();
            string strState = this.m_objViewer.m_dtgTake[row, 10].ToString().Trim();

            if (strState == "2")
            {
                return;
            }
            if (m_IsEnd == 1)
            {
                if (MessageBox.Show("是否要结束就诊?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                if (b_Temp)
                {
                    if (this.m_objViewer.btSave.Tag == null)//如果未保存则保存。
                    {
                        //在这插入提交调用
                        IsShowMessageBox = false;
                        if (!this.m_mthPutIn(true))
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (this.m_objViewer.lbeFlag.Text == "0")
                        {
                            //在这插入提交调用
                            IsShowMessageBox = false;
                            if (!this.m_mthPutIn(true))
                            {
                                return;
                            }
                        }
                    }
                }
            }
            long lngarg = objSvc.m_lngEndTakeReg(strRegisterID, strWaitID);
            if (lngarg > 0)
            {
                this.m_objViewer.m_dtgTake[row, 10] = 2;
                this.m_objViewer.m_dtgTake[row, 9] = "结诊";
                this.m_objViewer.m_dtgTake[row, 8] = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                // 东莞市预约平台消息通知.完成就医通知
                this.DgPlatformPost(3);
            }
            this.m_mthFormatTakeGrid();
            this.m_mthClearAllData();
            if (this.m_objViewer.frmAllergich != null)
            {
                this.m_objViewer.frmAllergich.Hide();
            }
            this.m_objViewer.m_PatInfo.Clear();
            this.m_objViewer.m_mthDisableIsVip();
            this.m_objViewer.m_PatInfo.txtCardID.Focus();
        }

        #endregion

        #region 退回候诊
        /// <summary>
        /// 退回候诊
        /// </summary>
        public void m_mthReturnWait()
        {
            int row = this.m_objViewer.m_dtgTake.CurrentCell.RowNumber;
            if (this.m_objViewer.m_PatInfo.PatientCardID != "")
            {
                string tempCardID = "";
                string tempState = "";
                for (int i = 0; i < this.m_objViewer.m_dtgTake.RowCount; i++)
                {
                    tempCardID = this.m_objViewer.m_dtgTake[i, 2].ToString().Trim();
                    tempState = this.m_objViewer.m_dtgTake[i, 9].ToString().Trim();
                    if (this.m_objViewer.m_PatInfo.PatientCardID == tempCardID && tempState != "2")
                    {
                        row = i;
                        break;
                    }
                }
            }

            string strWaitID = this.m_objViewer.m_dtgTake[row, 0].ToString().Trim();
            string strRegisterID = this.m_objViewer.m_dtgTake[row, 1].ToString().Trim();
            string strState = this.m_objViewer.m_dtgTake[row, 10].ToString().Trim();
            if (strState == "2")
            {
                return;
            }
            if (MessageBox.Show("是否要退回候诊?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }
            long lngarg = objSvc.m_lngReturnWait(strRegisterID, strWaitID);
            if (lngarg > 0)
            {
                this.m_objViewer.m_dtgTake.m_mthDeleteRow(row);
                this.m_GetWaitReg();
                this.m_objViewer.m_PatInfo.Clear();
                this.m_objViewer.m_mthDisableIsVip();
                this.m_mthClearAllData();
                this.m_objViewer.m_PatInfo.txtCardID.Focus();
            }
            this.m_mthFormatTakeGrid();
        }
        #endregion

        #region 读出药房所对应的窗口ID
        /// <summary>
        /// 读出药房所对应的窗口ID
        /// </summary>
        /// <param name="flag">1 西药房, 2 中药房</param>
        /// <returns></returns>
        private string m_mthGetMedcine(int flag)
        {
            string type = "";
            if (flag == 1)
            {
                type = "WMedicinestore";
            }
            else if (flag == 2)
            {
                type = "CMedicinestore";
            }

            return this.m_strReadXML("register", type, "AnyOne");
        }

        private string m_mthGetMedicineStoreByID(string strID)
        {
            string ret = "";
            clsDcl_ItemCatMapping obj = new clsDcl_ItemCatMapping();
            DataTable dt;
            long l = obj.m_mthMedstoreInfo(out dt, strID);
            if (l > 0 && dt.Rows.Count > 0)
            {
                ret = dt.Rows[0]["MEDSTORENAME_VCHR"].ToString().Trim();
            }
            return ret;
        }
        #endregion

        #region 获取注射治疗ID
        /// <summary>
        /// 获取注射治疗ID
        /// </summary>
        /// <param name="objArr"></param>
        public void m_mthGetinjectInfo(out ArrayList objArr)
        {
            objArr = new ArrayList();
            DataTable dt;
            long ret = objSvc.m_mthGetinjectInfo(out dt);
            if (ret > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    objArr.Add(dt.Rows[i]["USAGEID_CHR"].ToString());
                }
            }


        }
        #endregion

        #region 查找当天病历
        /// <summary>
        /// 查找当天病历
        /// </summary>
        /// <param name="p_dr"></param>
        private void m_mthFillCaseHistory(DataRow p_dr)
        {
            this.m_objViewer.objCaseHistory.DiagMain = p_dr["DIAGMAIN_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.DiagCurr = p_dr["DIAGCURR_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.DiagHis = p_dr["DIAGHIS_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.AidCheck = p_dr["AIDCHECK_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.Diag = p_dr["DIAG_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.Anaphylaxis = p_dr["ANAPHYLAXIS_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.Treatment = p_dr["TREATMENT_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.ReMark = p_dr["REMARK_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.ExamineResult = p_dr["BODYCHECK_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.PersonHis = p_dr["PRIHIS_VCHR"].ToString();
            this.m_objViewer.objCaseHistory.CaseHistoryID = p_dr["CASEHISID_CHR"].ToString();
            this.m_objViewer.objCaseHistory.ParentCaseHistoryID = p_dr["PARCASEHISID_CHR"].ToString();
            this.m_objViewer.objCaseHistory.ChangeDepartment = p_dr["CALDEPT_VCHR"].ToString();
            clsICD10_VO[] objArrTemp;
            long l = objSvc.m_mthIllnessInfo(p_dr["CASEHISID_CHR"].ToString(), out objArrTemp);
            if (l > 0 && objArrTemp != null)
            {
                ArrayList objArrList = new ArrayList();
                objArrList.AddRange(objArrTemp);
                this.m_objViewer.objCaseHistory.ICD10 = objArrList;
            }
            if (this.m_objViewer.objCaseHistory.ParentCaseHistoryID.Trim() != "")
            {
                this.m_objViewer.objCaseHistory.CaseHistoryStatus = 1;
            }
            else
            {
                this.m_objViewer.objCaseHistory.CaseHistoryStatus = 0;
            }
        }
        public void m_mthGetPatientCaseHistory(string strPateintID)
        {
            DataTable dt;
            long ret = objSvc.m_mthGetMaxCaseHistory(strPateintID, this.m_objViewer.LoginInfo.m_strEmpID, out dt);//病历
            if (ret > 0 && dt.Rows.Count > 0)
            {
                m_mthFillCaseHistory(dt.Rows[0]);


                //				this.m_objViewer.objCaseHistory.CaseHistoryID =dt.Rows[0]["CASEHISID_CHR"].ToString();
                //				this.m_objViewer.objCaseHistory.DiagMain=dt.Rows[0]["DIAGMAIN_VCHR"].ToString();
                //				this.m_objViewer.objCaseHistory.DiagCurr=dt.Rows[0]["DIAGCURR_VCHR"].ToString();
                //				this.m_objViewer.objCaseHistory.DiagHis=dt.Rows[0]["DIAGHIS_VCHR"].ToString();
                //				this.m_objViewer.objCaseHistory.AidCheck=dt.Rows[0]["AIDCHECK_VCHR"].ToString();
                //				this.m_objViewer.objCaseHistory.Diag=dt.Rows[0]["DIAG_VCHR"].ToString();
                //				this.m_objViewer.objCaseHistory.Anaphylaxis=dt.Rows[0]["ANAPHYLAXIS_VCHR"].ToString();
                //				this.m_objViewer.objCaseHistory.Treatment=dt.Rows[0]["TREATMENT_VCHR"].ToString();
                //				this.m_objViewer.objCaseHistory.ReMark=dt.Rows[0]["REMARK_VCHR"].ToString();
                //				this.m_objViewer.objCaseHistory.ExamineResult=dt.Rows[0]["BODYCHECK_VCHR"].ToString();
                //				this.m_objViewer.objCaseHistory.DiagMain =dt.Rows[0]["CASEHISID_CHR"].ToString();
                //				this.m_objViewer.objCaseHistory.ParentCaseHistoryID =dt.Rows[0]["PARCASEHISID_CHR"].ToString();
            }
            else
            {
                this.m_mthClearCaseHistory();
            }
        }
        #endregion

        #region 判断是否能开申请单
        /// <summary>
        /// 判断是否能开申请单
        /// </summary>
        private void m_mthCanCreatApplyBill()
        {
            DataTable dt;
            long ret = objSvc.m_lngGetWSParm("0004", out dt);		//0004 判断是否能开申请单
            if (ret > 0 && dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() == "0")
                {
                    this.m_objViewer.piclis.Enabled = false;
                    this.m_objViewer.picris.Enabled = false;
                    this.m_objViewer.picops.Enabled = false;

                    this.m_objViewer.label11.ForeColor = Color.FromArgb(132, 130, 132);
                    this.m_objViewer.label12.ForeColor = Color.FromArgb(132, 130, 132);
                    this.m_objViewer.label13.ForeColor = Color.FromArgb(132, 130, 132);
                }
                else
                {
                    this.m_objViewer.piclis.Enabled = true;
                    this.m_objViewer.picris.Enabled = true;
                    this.m_objViewer.picops.Enabled = true;

                    this.m_objViewer.label11.ForeColor = Color.FromArgb(0, 0, 0);
                    this.m_objViewer.label12.ForeColor = Color.FromArgb(0, 0, 0);
                    this.m_objViewer.label13.ForeColor = Color.FromArgb(0, 0, 0);
                }
            }
        }
        #endregion

        #region 格式化就诊列表
        /// <summary>
        /// 格式化就诊列表
        /// </summary>
        public void m_mthFormatTakeGrid()
        {
            this.m_objViewer.m_dtgTake.m_mthFormatReset(); //192,255,255
            Color bg = System.Drawing.Color.FromArgb(((System.Byte)(222)), ((System.Byte)(239)), ((System.Byte)(165)));
            Color fo = Color.Black;
            for (int i = 0; i < this.m_objViewer.m_dtgTake.RowCount; i++)
            {
                //				this.m_objViewer.m_dtgTake[i,5]=m_mthDealWithDateTime(this.m_objViewer.m_dtgTake[i,5].ToString(),1);
                //				this.m_objViewer.m_dtgTake[i,6]=m_mthDealWithDateTime(this.m_objViewer.m_dtgTake[i,6].ToString(),2);
                //				this.m_objViewer.m_dtgTake[i,7]=m_mthDealWithDateTime(this.m_objViewer.m_dtgTake[i,7].ToString(),2);
                if (this.m_objViewer.m_dtgTake[i, 10].ToString() == "1")
                {
                    this.m_objViewer.m_dtgTake.m_mthSetRowColor(i, fo, bg);
                }
            }
        }
        #endregion

        #region 组套
        public void m_mthGroup()
        {
            //			int temp =new Random().Next(1,244);
            //			switch(this.m_objViewer.tabControl1.SelectedIndex)
            //			{
            //					case 3:
            //						for(int ii=0;ii<this.m_objViewer.ctlDataGrid1.RowCount;ii++)
            //						{
            //						this.m_objViewer.ctlDataGrid1[ii,26] =int.Parse(this.m_objViewer.ctlDataGrid1[ii,26].ToString().Trim())*-1;
            //						}
            //						int[] arr =this.m_objViewer.ctlDataGrid1.m_arrSelectRows();
            //						this.m_objViewer.ctlDataGrid1.m_mthClearSelectedRow();
            //						if(arr.Length==0)
            //						{
            //							return;
            //						}
            //						for(int i=0;i<arr.Length;i++)
            //						{
            //							this.m_objViewer.ctlDataGrid1[arr[i],26] =-temp;
            //						}
            //						int beginValue =1;
            //						for(int ii=0;ii<this.m_objViewer.ctlDataGrid1.RowCount;ii++)
            //						{
            //							if(this.m_objViewer.ctlDataGrid1[ii,26].ToString().Trim()==""||int.Parse(this.m_objViewer.ctlDataGrid1[ii,26].ToString().Trim())>=0)
            //							{
            //								continue;
            //							}
            //							string strValue =this.m_objViewer.ctlDataGrid1[ii,26].ToString().Trim();
            //							this.m_objViewer.ctlDataGrid1[ii,26]=0;
            //							bool flag =false;
            //							for(int i2=ii+1;i2<this.m_objViewer.ctlDataGrid1.RowCount;i2++)
            //							{
            //								
            //								if(strValue ==this.m_objViewer.ctlDataGrid1[i2,26].ToString().Trim())
            //								{
            //									this.m_objViewer.ctlDataGrid1[ii,26] =beginValue;
            //									this.m_objViewer.ctlDataGrid1[i2,26] =beginValue;
            //									flag =true;
            //								}
            //							}
            //							if(flag)
            //							{
            //							beginValue++;
            //							}
            //						}
            //					break;
            //				case 4:
            //					for(int ii=0;ii<this.m_objViewer.ctlDataGrid2.RowCount;ii++)
            //					{
            //						this.m_objViewer.ctlDataGrid2[ii,19] =int.Parse(this.m_objViewer.ctlDataGrid2[ii,19].ToString().Trim())*-1;
            //					}
            //					int[] arr2 =this.m_objViewer.ctlDataGrid2.m_arrSelectRows();
            //					this.m_objViewer.ctlDataGrid2.m_mthClearSelectedRow();
            //					if(arr2.Length==0)
            //					{
            //						return;
            //					}
            //					for(int i=0;i<arr2.Length;i++)
            //					{
            //						this.m_objViewer.ctlDataGrid2[arr2[i],19] =-temp;
            //					}
            //					int beginValue2 =1;
            //					for(int ii=0;ii<this.m_objViewer.ctlDataGrid2.RowCount;ii++)
            //					{
            //						if(this.m_objViewer.ctlDataGrid2[ii,19].ToString().Trim()==""||int.Parse(this.m_objViewer.ctlDataGrid2[ii,19].ToString().Trim())>=0)
            //						{
            //							continue;
            //						}
            //						string strValue =this.m_objViewer.ctlDataGrid2[ii,19].ToString().Trim();
            //						this.m_objViewer.ctlDataGrid2[ii,19]=0;
            //						bool flag =false;
            //						for(int i2=ii+1;i2<this.m_objViewer.ctlDataGrid2.RowCount;i2++)
            //						{
            //								
            //							if(strValue ==this.m_objViewer.ctlDataGrid2[i2,19].ToString().Trim())
            //							{
            //								this.m_objViewer.ctlDataGrid2[ii,19] =beginValue2;
            //								this.m_objViewer.ctlDataGrid2[i2,19] =beginValue2;
            //								flag =true;
            //							}
            //						}
            //						if(flag)
            //						{
            //							beginValue2++;
            //						}
            //					}
            //					break;
            //			
            //			}

            //			m_mthFormatDataGrid();
        }
        public void m_mthFormatDataGrid()
        {

            this.m_objViewer.ctlDataGrid1.BeginUpdate();
            //			this.m_objViewer.ctlDataGrid1.m_mthFormatReset();

            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {

                if (this.m_objViewer.ctlDataGrid1[i, c_IsMain].ToString().Trim() == "-1")
                {
                    Color tempColor = System.Drawing.Color.FromArgb(((System.Byte)(250)), ((System.Byte)(255)), ((System.Byte)(200)));
                    this.m_objViewer.ctlDataGrid1.m_mthSetRowColor(i, Color.Black, tempColor);
                }
                if (this.m_objViewer.ctlDataGrid1[i, c_PSFlag].ToString().Trim() == "1")//把皮试药突出显示
                {
                    this.m_objViewer.ctlDataGrid1.m_mthFormatCell(i, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Red);
                }

            }

            this.m_objViewer.ctlDataGrid1.EndUpdate();
        }

        #endregion

        #region 显示超标
        /// <summary>
        /// 显示超标
        /// </summary>
        private void m_mthShowOverLimit()
        {
            ArrayList objTempArr = new ArrayList();
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                Object o = this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim();
                if (!objTempArr.Contains(o))
                {
                    objTempArr.Add(o);
                }
            }
            if (objTempArr.Count > this.MaxGroupCount && MaxGroupCount > 0)
            {
                System.Windows.Forms.Control con = this.m_objViewer.ActiveControl;
                frmShowOverFlow objfrm = new frmShowOverFlow();
                System.Reflection.Assembly assembly = typeof(clsCtl_DoctorWorkstation).Assembly;
                objfrm.BackgroundImage = new Bitmap(assembly.GetManifestResourceStream("com.digitalwave.iCare.gui.HIS.Print.BGImage.bmp"));
                objfrm.Left = 856;
                objfrm.Top = 668;
                objfrm.Show();
                con.Focus();

            }

        }
        #endregion

        #region 取消组套
        /// <summary>
        /// 取消组套
        /// </summary>
        public void m_mthCancelGroup()
        {
            switch (this.m_objViewer.tabControl1.SelectedIndex)
            {
                case 3:
                    this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, 26] = 0;
                    break;
                case 4:
                    this.m_objViewer.ctlDataGrid2[this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 19] = 0;
                    break;

            }
            //			m_mthFormatDataGrid();
        }
        #endregion

        #region 时间处理
        /// <summary>
        /// 时间处理
        /// </summary>
        /// <param name="strDateTime"></param>
        /// <param name="flag">1为短时间, 2为精确到分</param>
        /// <returns></returns>
        private string m_mthDealWithDateTime(string strDateTime, int flag)
        {
            string ret = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                DateTime temp = DateTime.Parse(strDateTime);
                if (flag == 1)
                {
                    ret = temp.ToString("yyyy-MM-dd");
                }
                else
                {
                    ret = temp.ToString("yyyy-MM-dd hh:ss");
                }
            }
            catch
            {

            }
            return ret;
        }
        #endregion

        #region 判断能否更改医生
        /// <summary>
        /// 判断能否更改医生 true 不能改变,false能改变
        /// </summary>
        public bool isCanChangeDoctor = false;
        /// <summary>
        /// 判断是否显示缺药 true 显示,false不显示
        /// </summary>
        internal bool isShowLackMedicine = true;
        /// <summary>
        /// 判断那种计算方式 true 正常,false
        /// </summary>
        private bool CalFlag = true;
        private string strFind = "";
        /// <summary>
        /// 是否能开申请
        /// </summary>
        private bool CanApply = false;
        /// <summary>
        /// 是否产生配伍禁忌
        /// </summary>
        private bool IsTabu = false;
        /// <summary>
        ///  提交时是否发送检验单
        /// </summary>
        private bool IsSendTestApply = false;
        /// <summary>
        /// 提交时是否发送检查单
        /// </summary>
        private bool IsSendCheckApply = false;
        /// <summary>
        /// 是否打印英文名(true 不打印，false 打印)
        /// </summary>
        private bool IsPrintEnglish = false;
        /// <summary>
        /// 最多组数 0 时不作提示
        /// </summary>
        private int MaxGroupCount = 0;
        /// <summary>
        /// 自动发送手术申请单
        /// </summary>
        private bool Isautosendops = false;
        /// <summary>
        /// 神经性药物权限(0 无 1 有)
        /// </summary>
        private string Neurpur = "0";
        /// <summary>
        /// 毒麻药权限(0 无 1 有)
        /// </summary>
        private string Drugpur = "0";
        /// <summary>
        /// 处方权限(0 无 1 有)
        /// </summary>
        internal string Recpur = "0";
        /// <summary>
        /// 病人资料补登记
        /// </summary>
        private int Isregpatinfo = 0;
        /// <summary>
        /// 片剂计算方法
        /// </summary>
        private bool Trochecalc = false;
        /// <summary>
        /// 是否启用科室自备药
        /// </summary>
        internal bool Isdeptmed = false;
        /// <summary>
        /// 医保特种病患者身份ID
        /// </summary>
        internal string YBSpecialPayTypeID = "";
        /// <summary>
        /// 医保特种病特定处方类型ID
        /// </summary>
        internal int YBSpecialRecTypeID = -1;
        /// <summary>
        /// 限定补录患者身份信息的处方类型(多个时以分号隔开)
        /// </summary>
        internal string SpeicalLimitRecipeID = "";
        /// <summary>
        /// 写处方限定(药品类型，多个以分号隔开，合并用加号)
        /// </summary>
        internal string SpeicalLimitMedpropertyID = "";
        /// <summary>
        /// 是否显示药典备注窗口
        /// </summary>
        private bool IsShowCodexRemarkFrm = false;

        private ArrayList OrderCatLisArr = new ArrayList();
        private ArrayList OrderCatTestArr = new ArrayList();
        private ArrayList OrderCatOpsArr = new ArrayList();
        string DrugServiceUrl = string.Empty;
        bool IsUseMedItf = false;
        bool IsRecipePut = false;
        System.Collections.Generic.List<Hisitf.EntityDrugUse> lstDrug = new System.Collections.Generic.List<Hisitf.EntityDrugUse>();

        #region 获取系统参数与功能设置[旧，停用]
        //private void m_mthIsCanDo()
        //{
        //    CanApply = objSvc.m_mthIsCanDo("0020");
        //    isCanChangeDoctor = objSvc.m_mthIsCanDo("0011");
        //    isShowLackMedicine = objSvc.m_mthIsCanDo("0012");
        //    CalFlag = objSvc.m_mthIsCanDo("0015");
        //    IsTabu = objSvc.m_mthIsCanDo("0022");
        //    IsSendTestApply = objSvc.m_mthIsCanDo("0024");
        //    IsSendCheckApply = objSvc.m_mthIsCanDo("0025");
        //    if (IsSendCheckApply == true)
        //    {
        //        long l = objSvc.m_lngGetAPPLY_RLT(out this.objAID_APPLY_RLT);
        //        if (l < 0)
        //        {
        //            MessageBox.Show(this.m_objViewer, "获取申请单分类出错，请与管理员联系！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //            return;
        //        }
        //    }
        //    IsPrintEnglish = !objSvc.m_mthIsCanDo("0030");
        //    clsDcl_OPCharge objOPDCl = new clsDcl_OPCharge();
        //    MaxGroupCount = objOPDCl.m_mthIsCanDo("0029");
        //    if (objSvc.m_mthIsCanDo("0019"))
        //    {
        //        strFind = "%";
        //    }

        //    Isautosendops = objSvc.m_mthIsCanDo("0047");
        //    Trochecalc = objSvc.m_mthIsCanDo("0054");
        //    Isdeptmed = objSvc.m_mthIsCanDo("0055");
        //    IsShowCodexRemarkFrm = objSvc.m_mthIsCanDo("0059");
        //    IsAllowDiscount = objSvc.m_mthIsCanDo("4008");
        //    YBIsShowSelfItem = objSvc.m_mthIsCanDo("0066");

        //    YBSpecialPayTypeID = this.objSvc.m_strGetSysparm("0001");
        //    YBSpecialRecTypeID = int.Parse(this.objSvc.m_strGetSysparm("0002"));
        //    SpeicalLimitRecipeID = this.objSvc.m_strGetSysparm("0003");
        //    SpeicalLimitMedpropertyID = this.objSvc.m_strGetSysparm("0007");

        //    OrderCatLisArr = this.m_Gettoken(this.objSvc.m_strGetSysparm("0010"), ";");
        //    OrderCatTestArr = this.m_Gettoken(this.objSvc.m_strGetSysparm("0011"), ";");
        //    OrderCatOpsArr = this.m_Gettoken(this.objSvc.m_strGetSysparm("0012"), ";");
        //    DiscountInvoCatArr = this.m_Gettoken(this.objSvc.m_strGetSysparm("0013"), ";");
        //    YBPayTypeArr = this.m_Gettoken(this.objSvc.m_strGetSysparm("0031"), ";");

        //    this.m_mthGetmedpurview();

        //    this.m_mthGetmednoqtyflag();

        //    this.m_mthGetrecalculateflag();

        //    this.m_mthGetregpatinfo();

        //    this.m_mthGetMedPropertyLimit();

        //    this.m_mthGetItemInputMode();

        //    this.m_mthGetDiscountInfo();

        //    this.objSvc.m_mthGetmedpurview(this.m_objViewer.LoginInfo.m_strEmpID, out Neurpur, out Drugpur, out Recpur);
        //}
        #endregion

        #region 获取系统参数与功能设置
        private void m_mthIsCanDo()
        {
            string[] strSettingArr = new string[]
            {
                "0020", "0011", "0012", "0015", "0022", 
                "0024", "0025", "0030", "0029", "0019", 
                "0047", "0054", "0055", "0059", "4008", 
                "0066", "0049", "0051", "0052", "0050",
                "0064", "9000", "4006","9100","0201","9101"
            };
            Hashtable hasSetting = null;
            long lngRes = objSvc.m_lngGetSysSetting(strSettingArr, out hasSetting);
            if (lngRes > 0 && hasSetting != null)
            {
                CanApply = m_intConvertByString(hasSetting["0020"].ToString()) == 1 ? true : false;
                isCanChangeDoctor = m_intConvertByString(hasSetting["0011"].ToString()) == 1 ? true : false;
                isShowLackMedicine = m_intConvertByString(hasSetting["0012"].ToString()) == 1 ? true : false;
                CalFlag = m_intConvertByString(hasSetting["0015"].ToString()) == 1 ? true : false;
                IsTabu = m_intConvertByString(hasSetting["0022"].ToString()) == 1 ? true : false;
                IsSendTestApply = m_intConvertByString(hasSetting["0024"].ToString()) == 1 ? true : false;
                IsSendCheckApply = m_intConvertByString(hasSetting["0025"].ToString()) == 1 ? true : false;
                IsPrintEnglish = !(m_intConvertByString(hasSetting["0030"].ToString()) == 1 ? true : false);
                MaxGroupCount = m_intConvertByString(hasSetting["0029"].ToString());
                strFind = m_intConvertByString(hasSetting["0019"].ToString()) == 1 ? "%" : strFind;
                Isautosendops = m_intConvertByString(hasSetting["0047"].ToString()) == 1 ? true : false;
                Trochecalc = m_intConvertByString(hasSetting["0054"].ToString()) == 1 ? true : false;
                Isdeptmed = m_intConvertByString(hasSetting["0055"].ToString()) == 1 ? true : false;
                IsShowCodexRemarkFrm = m_intConvertByString(hasSetting["0059"].ToString()) == 1 ? true : false;
                IsAllowDiscount = m_intConvertByString(hasSetting["4008"].ToString()) == 1 ? true : false;
                YBIsShowSelfItem = m_intConvertByString(hasSetting["0066"].ToString()) == 1 ? true : false;
                Medpurview = m_intConvertByString(hasSetting["0049"].ToString());
                Noqtyflag = m_intConvertByString(hasSetting["0051"].ToString()) == 1 ? true : false;
                Recalculateflag = m_intConvertByString(hasSetting["0052"].ToString()) == 1 ? true : false;
                Isregpatinfo = m_intConvertByString(hasSetting["0050"].ToString());
                MedPropertyLimit = m_intConvertByString(hasSetting["0064"].ToString());
                ItemInputMode = m_intConvertByString(hasSetting["9000"].ToString());
                //------------------------------------
                // MedPropertyLimit = m_intConvertByString(hasSetting["4006"].ToString());????
                DiscountItemNus = m_intConvertByString(hasSetting["4006"].ToString());
                //-------------------------------------
                SecondStockUseFlag = m_intConvertByString(hasSetting["9100"].ToString()) == 1 ? true : false;
                //  this.strDeductType = m_intConvertByString(hasSetting["0201"].ToString()).ToString();
                SecondStockLimitFlag = m_intConvertByString(hasSetting["9101"].ToString()) == 1 ? true : false;

            }
            hasSetting = null;
            if (IsSendCheckApply)
            {
                long l = objSvc.m_lngGetAPPLY_RLT(out objAID_APPLY_RLT);
                if (l < 0)
                {
                    MessageBox.Show(this.m_objViewer, "获取申请单分类出错，请与管理员联系！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            string[] strParamArr = new string[] 
            {
                "0010", "0011", "0012", "0013", "0031", "1001", "1002", "1003", "1010", "1016"  
            };
            Hashtable hasParam = null;
            lngRes = objSvc.m_lngGetSysparm(strParamArr, out hasParam);
            if (lngRes > 0 && hasParam != null)
            {
                OrderCatLisArr = new ArrayList(hasParam["0010"].ToString().Split(';'));
                OrderCatTestArr = new ArrayList(hasParam["0011"].ToString().Split(';'));
                OrderCatOpsArr = new ArrayList(hasParam["0012"].ToString().Split(';'));
                DiscountInvoCatArr = new ArrayList(hasParam["0013"].ToString().Split(';'));
                YBPayTypeArr = new ArrayList(hasParam["0031"].ToString().Split(';'));
                WMUsageIDArr = new ArrayList(hasParam["1001"].ToString().Split(';'));
                CMUsageIDArr = new ArrayList(hasParam["1002"].ToString().Split(';'));
                MATUsageIDArr = new ArrayList(hasParam["1003"].ToString().Split(';'));
                WechatWebUrl = hasParam["1010"].ToString();
                int parm1016 = 0;
                int.TryParse(hasParam["1016"].ToString(), out parm1016);
                if (parm1016 == 1) this.IsUseDgPlatformNotice = true;
            }

            DataTable dtTemp;
            if (this.objSvc.m_lngGetMedStore(out dtTemp) > 0)
            {
                dvMedStore = new DataView(dtTemp);
            }

            // 合理用药服务地址
            this.DrugServiceUrl = clsPublic.m_strGetSysparm("0080");
            this.IsUseMedItf = (clsPublic.ConvertObjToDecimal(clsPublic.m_strGetSysparm("0082")) == 1 ? true : false);

            objSvc.m_mthGetmedpurview(this.m_objViewer.LoginInfo.m_strEmpID, out Neurpur, out Drugpur, out Recpur);
            m_mthGetStoreID();//获取药房设置
        }
        #endregion

        #region 字符串转化为整型
        /// <summary>
        /// 字符串转化为整型
        /// </summary>
        /// <param name="p_strValue"></param>
        /// <returns></returns>
        private int m_intConvertByString(string p_strValue)
        {
            int intValue = 0;
            if (string.IsNullOrEmpty(p_strValue))
            {
                return intValue;
            }
            Int32.TryParse(p_strValue, out intValue);
            return intValue;
        }
        #endregion
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

            if (ItemInputMode == 1)
            {
                if (str == "0006")
                {
                    str = "0005";
                }
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

        #region 自动添加数据
        /// <summary>
        /// 这里就是输入组合的子项时，自动添加频率和用法的。
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool m_mthAutoAddData(int row)
        {
            bool ret = true;
            if (this.m_objViewer.ctlDataGrid1[row, c_IsMain].ToString().Trim() != "")
            {
                int tempRow = int.Parse(this.m_objViewer.ctlDataGrid1[row, c_IsMain].ToString());

                if (tempRow > -1)
                {
                    ret = false;
                    this.m_objViewer.ctlDataGrid1[row, c_UsageName] = this.m_objViewer.ctlDataGrid1[tempRow, c_UsageName];
                    this.m_objViewer.ctlDataGrid1[row, c_FreName] = this.m_objViewer.ctlDataGrid1[tempRow, c_FreName];
                    this.m_objViewer.ctlDataGrid1[row, c_Day] = this.m_objViewer.ctlDataGrid1[tempRow, c_Day];
                    this.m_objViewer.ctlDataGrid1[row, c_FreDays] = this.m_objViewer.ctlDataGrid1[tempRow, c_FreDays];
                    this.m_objViewer.ctlDataGrid1[row, c_FreTimes] = this.m_objViewer.ctlDataGrid1[tempRow, c_FreTimes];
                    this.m_objViewer.ctlDataGrid1[row, c_UsageID] = this.m_objViewer.ctlDataGrid1[tempRow, c_UsageID];
                    this.m_objViewer.ctlDataGrid1[row, c_FreID] = this.m_objViewer.ctlDataGrid1[tempRow, c_FreID];
                }
            }
            return ret;
        }
        #endregion

        #region 更改用法
        private void m_mthChangeUsage(int row)
        {
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (i == row)
                {
                    continue;
                }
                if (this.m_objViewer.ctlDataGrid1[row, c_GroupNo].Equals(this.m_objViewer.ctlDataGrid1[i, c_GroupNo]) && this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim() != "")
                {
                    this.m_objViewer.ctlDataGrid1[i, c_UsageName] = this.m_objViewer.ctlDataGrid1[row, c_UsageName];
                    this.m_objViewer.ctlDataGrid1[i, c_UsageID] = this.m_objViewer.ctlDataGrid1[row, c_UsageID];
                }
            }
        }
        #endregion

        #region  更改频率
        private void m_mthChangeFrequency(int row)
        {
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (i == row)
                {
                    continue;
                }
                if (this.m_objViewer.ctlDataGrid1[row, c_GroupNo].Equals(this.m_objViewer.ctlDataGrid1[i, c_GroupNo]) && this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim() != "")
                {
                    this.m_objViewer.ctlDataGrid1[i, c_FreName] = this.m_objViewer.ctlDataGrid1[row, c_FreName];
                    this.m_objViewer.ctlDataGrid1[i, c_FreDays] = this.m_objViewer.ctlDataGrid1[row, c_FreDays];
                    this.m_objViewer.ctlDataGrid1[i, c_FreTimes] = this.m_objViewer.ctlDataGrid1[row, c_FreTimes];
                    this.m_objViewer.ctlDataGrid1[i, c_FreID] = this.m_objViewer.ctlDataGrid1[row, c_FreID];
                    this.m_objViewer.ctlDataGrid1[i, c_Day] = this.m_objViewer.ctlDataGrid1[row, c_Day];
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(i, c_Day);
                }

            }
            this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Day);
            //			for(int i=row+1;i<this.m_objViewer.ctlDataGrid1.RowCount;i++)
            //			{
            //				if(this.m_objViewer.ctlDataGrid1[row,26].Equals(this.m_objViewer.ctlDataGrid1[i,26]))
            //				{
            //					this.m_objViewer.ctlDataGrid1[i,6]=this.m_objViewer.ctlDataGrid1[row,6];
            //					this.m_objViewer.ctlDataGrid1[i,13]=this.m_objViewer.ctlDataGrid1[row,13];
            //					this.m_objViewer.ctlDataGrid1[i,14]=this.m_objViewer.ctlDataGrid1[row,14];
            //					this.m_objViewer.ctlDataGrid1[i,16]=this.m_objViewer.ctlDataGrid1[row,16];
            //					this.m_objViewer.ctlDataGrid1.CurrentCell =new DataGridCell(i,7);
            //				}
            //				else
            //				{
            //					break;
            //				}
            //			}
            //			this.m_objViewer.ctlDataGrid1.CurrentCell =new DataGridCell(row,8);
        }
        #endregion

        #region 更改天数
        private void m_mthChangeDay(int row)
        {
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (i == row)
                {
                    continue;
                }
                if (this.m_objViewer.ctlDataGrid1[row, c_GroupNo].Equals(this.m_objViewer.ctlDataGrid1[i, c_GroupNo]) && this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim() != "")
                {
                    this.m_objViewer.ctlDataGrid1[i, c_Day] = this.m_objViewer.ctlDataGrid1[row, c_Day];
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(i, c_Total);
                }

            }
            this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, c_Total);
        }
        #endregion

        #region 新处方
        public void m_mthNewRecipe()
        {
            if (this.m_objViewer.btSave.Tag == null && this.m_mthConvertObjToDecimal(this.m_objViewer.lbeSumMoney.Text) != 0)
            {
                if (MessageBox.Show("原处方没有保存,是否保存?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    this.m_mthSaveAllData();
                }
            }
            this.m_mthClearAllData2();
        }
        #endregion

        #region 删除组合
        private void m_mthDeleteGroupItem(int row)
        {
            if (this.m_objViewer.ctlDataGrid1[row, c_Fage].ToString().Trim() == "1")
            {
                //				if(MessageBox.Show("此项目含有附加项目,\n   是否删除附加项目?","ICare",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
                //				{
                m_mthGetChargeItemByUsageID("", true, this.m_objViewer.ctlDataGrid1[row, c_SubItemID].ToString().Trim().Replace("[PK]", ""), row);
                //				}
            }
        }
        public void m_mthDeleteGroup(int row)
        {
            if (this.m_objViewer.ctlDataGrid1[row, c_ItemID].ToString().Trim() == "")
            {
                return;
            }
            string strTempRow = this.m_objViewer.ctlDataGrid1[row, c_RowNo].ToString().Trim();
            int tempRow = -4;
            if (this.m_objViewer.ctlDataGrid1[row, c_IsMain].ToString().Trim() != "")//获取是否组合
            {
                tempRow = int.Parse(this.m_objViewer.ctlDataGrid1[row, c_IsMain].ToString());
            }
            DialogResult drTemp;

            if (tempRow == -1)//组合
            {
                drTemp = MessageBox.Show("要删除此项目是组合的主项目\n   是否删除全组项目?", "ICare", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }
            else//非组合
            {
                drTemp = MessageBox.Show("是否删除此项目?", "ICare", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            }

            if (drTemp == DialogResult.Cancel)
            {
                return;
            }
            this.m_mthDeleteGroupItem(row);//删除附加项目
            if (tempRow == -1)
            {

                if (drTemp == DialogResult.Yes)
                {
                    //取得组号
                    string strTemp = this.m_objViewer.ctlDataGrid1[row, c_GroupNo].ToString().Trim();
                    for (int i = this.m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
                    {
                        if (strTemp == this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim())
                        {
                            strTempRow = this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString().Trim();
                            if (strTempRow != "" && strTempRow != "-1")
                            {
                                this.objCalPatientCharge.m_mthDelteChargeItem(int.Parse(strTempRow));//从计费类删除对应的项目
                            }
                            this.m_objViewer.alertLight1.m_mthDeleteItem(this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString().Trim());//删除药品禁忌项目
                            //							m_mthRowDelete(i);
                            this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                        }
                    }
                }
                else
                {
                    string strtemp = this.m_objViewer.ctlDataGrid1[row, c_GroupNo].ToString().Trim();
                    if (strTempRow != "" && strTempRow != "-1")
                    {
                        this.objCalPatientCharge.m_mthDelteChargeItem(int.Parse(strTempRow));
                    }
                    this.m_objViewer.alertLight1.m_mthDeleteItem(this.m_objViewer.ctlDataGrid1[row, c_ItemID].ToString().Trim());
                    //					m_mthRowDelete(row);
                    this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(row);
                    m_mthSetMainGroup(strtemp);
                }
            }
            else
            {
                if (strTempRow != "" && strTempRow != "-1")
                {
                    this.objCalPatientCharge.m_mthDelteChargeItem(int.Parse(strTempRow));
                }
                this.m_objViewer.alertLight1.m_mthDeleteItem(this.m_objViewer.ctlDataGrid1[row, c_ItemID].ToString().Trim());
                //				m_mthRowDelete(row);
                this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(row);
            }
        }

        /// <summary>
        /// 把最前一个项目设为主项目
        /// </summary>
        /// <param name="str"></param>
        private void m_mthSetMainGroup(string str)
        {
            for (int i2 = 0; i2 < this.m_objViewer.ctlDataGrid1.RowCount; i2++)
            {
                if (str == this.m_objViewer.ctlDataGrid1[i2, c_GroupNo].ToString().Trim())
                {
                    this.m_objViewer.ctlDataGrid1[i2, c_IsMain] = -1;
                    m_mthFormatDataGrid();
                    break;
                }
            }
        }
        #endregion

        #region 内部类
        private class clsSubClass : IComparable
        {
            public string M0;
            public string M1;
            public string M2;
            public string M3;
            public string M4;
            public string M5;
            public string M6;
            public string M7;
            public string M8;
            public string M9;
            public string M10;
            public string M11;
            public string M12;
            public string M13;
            public string M14;
            public string M15;
            public string M16;
            public string M17;
            public string M18;
            public string M19;
            public string M20;
            public string M21;
            public string M22;
            public string M23;
            public string M24;
            public string M25;
            public string M26;
            public string M27;
            public string M28;
            public string M29;
            public string M30;
            public string M31;
            public string M32;
            public string M33;
            public string M34;
            public string M35;
            #region IComparable 成员

            public int CompareTo(object obj)
            {
                if (obj is clsSubClass)
                {
                    return M0.CompareTo(((clsSubClass)obj).M0);
                }
                return 0;
            }

            #endregion
        }
        #endregion

        #region 重组
        public void m_mthReGroup()
        {
            ArrayList objArrTemp = new ArrayList();
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString().Trim() == "")
                {
                    this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                    continue;
                }
                clsSubClass obj = new clsSubClass();
                obj.M0 = this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim() + i.ToString();
                if (this.m_objViewer.ctlDataGrid1[i, c_GroupNo].ToString().Trim() == "")
                {
                    obj.M0 = "0" + i.ToString();
                }
                obj.M1 = this.m_objViewer.ctlDataGrid1[i, 1].ToString().Trim();
                obj.M2 = this.m_objViewer.ctlDataGrid1[i, 2].ToString().Trim();
                obj.M3 = this.m_objViewer.ctlDataGrid1[i, 3].ToString().Trim();
                obj.M4 = this.m_objViewer.ctlDataGrid1[i, 4].ToString().Trim();
                obj.M5 = this.m_objViewer.ctlDataGrid1[i, 5].ToString().Trim();
                obj.M6 = this.m_objViewer.ctlDataGrid1[i, 6].ToString().Trim();
                obj.M7 = this.m_objViewer.ctlDataGrid1[i, 7].ToString().Trim();
                obj.M8 = this.m_objViewer.ctlDataGrid1[i, 8].ToString().Trim();
                obj.M9 = this.m_objViewer.ctlDataGrid1[i, 9].ToString().Trim();
                obj.M10 = this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim();
                obj.M11 = this.m_objViewer.ctlDataGrid1[i, 11].ToString().Trim();
                obj.M12 = this.m_objViewer.ctlDataGrid1[i, 12].ToString().Trim();
                obj.M13 = this.m_objViewer.ctlDataGrid1[i, 13].ToString().Trim();
                obj.M14 = this.m_objViewer.ctlDataGrid1[i, 14].ToString().Trim();
                obj.M15 = this.m_objViewer.ctlDataGrid1[i, 15].ToString().Trim();
                obj.M16 = this.m_objViewer.ctlDataGrid1[i, 16].ToString().Trim();
                obj.M17 = this.m_objViewer.ctlDataGrid1[i, 17].ToString().Trim();
                obj.M18 = this.m_objViewer.ctlDataGrid1[i, 18].ToString().Trim();
                obj.M19 = this.m_objViewer.ctlDataGrid1[i, 19].ToString().Trim();
                obj.M20 = this.m_objViewer.ctlDataGrid1[i, 20].ToString().Trim();
                obj.M21 = this.m_objViewer.ctlDataGrid1[i, 21].ToString().Trim();
                obj.M22 = this.m_objViewer.ctlDataGrid1[i, 22].ToString().Trim();
                obj.M23 = this.m_objViewer.ctlDataGrid1[i, 23].ToString().Trim();
                obj.M24 = this.m_objViewer.ctlDataGrid1[i, 24].ToString().Trim();
                obj.M25 = this.m_objViewer.ctlDataGrid1[i, 25].ToString().Trim();
                obj.M26 = this.m_objViewer.ctlDataGrid1[i, 26].ToString().Trim();
                obj.M27 = this.m_objViewer.ctlDataGrid1[i, 27].ToString().Trim();
                obj.M28 = this.m_objViewer.ctlDataGrid1[i, 28].ToString().Trim();
                obj.M29 = this.m_objViewer.ctlDataGrid1[i, 29].ToString().Trim();
                obj.M30 = this.m_objViewer.ctlDataGrid1[i, 30].ToString().Trim();
                obj.M31 = this.m_objViewer.ctlDataGrid1[i, 31].ToString().Trim();
                obj.M32 = this.m_objViewer.ctlDataGrid1[i, 32].ToString().Trim();
                obj.M33 = this.m_objViewer.ctlDataGrid1[i, 33].ToString().Trim();
                obj.M34 = this.m_objViewer.ctlDataGrid1[i, 34].ToString().Trim();
                obj.M35 = this.m_objViewer.ctlDataGrid1[i, 35].ToString().Trim();
                objArrTemp.Add(obj);
            }
            objArrTemp.Sort(0, objArrTemp.Count, null);
            int i2 = 0;
            //				this.m_objViewer.ctlDataGrid1.m_mthDeleteAllRow();
            foreach (clsSubClass obj in objArrTemp)
            {
                //					this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                string strTemp = obj.M0.Substring(0, obj.M0.Length - 1);
                if (strTemp == "0")
                {
                    this.m_objViewer.ctlDataGrid1[i2, 0] = "";
                }
                else
                {
                    this.m_objViewer.ctlDataGrid1[i2, 0] = strTemp;
                }
                this.m_objViewer.ctlDataGrid1[i2, 1] = obj.M1;
                this.m_objViewer.ctlDataGrid1[i2, 2] = obj.M2;
                this.m_objViewer.ctlDataGrid1[i2, 3] = obj.M3;
                this.m_objViewer.ctlDataGrid1[i2, 4] = obj.M4;
                this.m_objViewer.ctlDataGrid1[i2, 5] = obj.M5;
                this.m_objViewer.ctlDataGrid1[i2, 6] = obj.M6;
                this.m_objViewer.ctlDataGrid1[i2, 7] = obj.M7;
                this.m_objViewer.ctlDataGrid1[i2, 8] = obj.M8;
                this.m_objViewer.ctlDataGrid1[i2, 9] = obj.M9;
                this.m_objViewer.ctlDataGrid1[i2, 10] = obj.M10;
                this.m_objViewer.ctlDataGrid1[i2, 11] = obj.M11;
                this.m_objViewer.ctlDataGrid1[i2, 12] = obj.M12;
                this.m_objViewer.ctlDataGrid1[i2, 13] = obj.M13;
                this.m_objViewer.ctlDataGrid1[i2, 14] = obj.M14;
                this.m_objViewer.ctlDataGrid1[i2, 15] = obj.M15;
                this.m_objViewer.ctlDataGrid1[i2, 16] = obj.M16;
                this.m_objViewer.ctlDataGrid1[i2, 17] = obj.M17;
                this.m_objViewer.ctlDataGrid1[i2, 18] = obj.M18;
                this.m_objViewer.ctlDataGrid1[i2, 19] = obj.M19;
                this.m_objViewer.ctlDataGrid1[i2, 20] = obj.M20;
                this.m_objViewer.ctlDataGrid1[i2, 21] = obj.M21;
                this.m_objViewer.ctlDataGrid1[i2, 22] = obj.M22;
                this.m_objViewer.ctlDataGrid1[i2, 23] = obj.M23;
                this.m_objViewer.ctlDataGrid1[i2, 24] = obj.M24;
                this.m_objViewer.ctlDataGrid1[i2, 25] = obj.M25;
                this.m_objViewer.ctlDataGrid1[i2, 26] = obj.M26;
                this.m_objViewer.ctlDataGrid1[i2, 27] = obj.M27;
                this.m_objViewer.ctlDataGrid1[i2, 28] = obj.M28;
                this.m_objViewer.ctlDataGrid1[i2, 29] = obj.M29;
                this.m_objViewer.ctlDataGrid1[i2, 30] = obj.M30;
                this.m_objViewer.ctlDataGrid1[i2, 31] = obj.M31;
                this.m_objViewer.ctlDataGrid1[i2, 32] = obj.M32;
                this.m_objViewer.ctlDataGrid1[i2, 33] = obj.M33;
                this.m_objViewer.ctlDataGrid1[i2, 34] = obj.M34;
                this.m_objViewer.ctlDataGrid1[i2, 35] = obj.M35;
                i2++;

            }
            this.m_objViewer.ctlDataGrid1.m_mthFormatReset();
            this.m_mthFormatDataGrid();
        }
        #endregion

        #region 改变天次时,默认项目也随之改变
        private void m_mthChangeTimeForDefaultItem(string strID, decimal days, int p_introw, int p_Flag)
        {
            //p_Flag: 0 用法附加； 1 关联带出

            decimal TempNum = 0;
            string TempID = "";

            for (int i = this.m_objViewer.ctlDataGrid2.RowCount - 1; i >= 0; i--)
            {
                if (p_Flag == 0)
                {
                    TempID = this.m_objViewer.ctlDataGrid2[i, 22].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 23]) * days;
                }
                else if (p_Flag == 1)
                {
                    //temp
                    TempID = this.m_objViewer.ctlDataGrid2[i, 22].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid2[i, 23]) * days;
                }

                if (strID == TempID)
                {
                    if (TempNum > 0)
                    {
                        this.m_objViewer.ctlDataGrid2[i, 1] = TempNum;
                        m_mthCalculateAmount2(i);
                    }
                }
            }
            for (int i = this.m_objViewer.ctlDataGrid3.RowCount - 1; i >= 0; i--)
            {
                if (p_Flag == 0)
                {
                    TempID = this.m_objViewer.ctlDataGrid3[i, t_OtherItemID].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid3[i, t_OtherCount]) * days;
                }
                else if (p_Flag == 1)
                {
                    TempID = this.m_objViewer.ctlDataGrid3[i, t_resubitem].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid3[i, t_MainItemNum]) * days;
                }

                if (strID == TempID)
                {
                    decimal decSumCounttemp = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid3[i, t_Count]);
                    if (TempNum > 0 && decSumCounttemp != TempNum)
                    {
                        this.m_objViewer.ctlDataGrid3[i, t_Count] = TempNum;
                        m_mthAddItemToCulateClass(i, 3);
                    }
                }
            }
            for (int i = this.m_objViewer.ctlDataGrid4.RowCount - 1; i >= 0; i--)
            {
                if (p_Flag == 0)
                {
                    TempID = this.m_objViewer.ctlDataGrid4[i, t_OtherItemID].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid4[i, t_OtherCount]) * days;
                }
                else if (p_Flag == 1)
                {
                    TempID = this.m_objViewer.ctlDataGrid4[i, t_resubitem].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid4[i, t_MainItemNum]) * days;
                }

                if (strID == TempID)
                {
                    decimal decSumCounttemp = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid4[i, t_Count]);
                    if (TempNum > 0 && decSumCounttemp != TempNum)
                    {
                        this.m_objViewer.ctlDataGrid4[i, t_Count] = TempNum;
                        m_mthAddItemToCulateClass(i, 4);
                    }
                }
            }
            for (int i = this.m_objViewer.ctlDataGrid5.RowCount - 1; i >= 0; i--)
            {
                if (p_Flag == 0)
                {
                    TempID = this.m_objViewer.ctlDataGrid5[i, o_OtherItemID].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid5[i, o_OtherCount]) * days;
                }
                else if (p_Flag == 1)
                {
                    TempID = this.m_objViewer.ctlDataGrid5[i, o_resubitem].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid5[i, o_MainItemNum]) * days;
                }

                if (strID == TempID)
                {
                    decimal decSumCounttemp = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid5[i, 1]);
                    if (TempNum > 0 && decSumCounttemp != TempNum)
                    {
                        this.m_objViewer.ctlDataGrid5[i, 1] = TempNum;
                        m_mthAddItemToCulateClass(i, 5);
                    }
                }
            }
            for (int i = this.m_objViewer.ctlDataGrid6.RowCount - 1; i >= 0; i--)
            {
                if (p_Flag == 0)
                {
                    TempID = this.m_objViewer.ctlDataGrid6[i, o_OtherItemID].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid6[i, o_OtherCount]) * days;
                }
                else if (p_Flag == 1)
                {
                    TempID = this.m_objViewer.ctlDataGrid6[i, o_resubitem].ToString().Trim();
                    TempNum = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid6[i, o_MainItemNum]) * days;
                }

                if (strID == TempID)
                {
                    decimal decSumCounttemp = this.m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid6[i, 1]);
                    if (TempNum > 0 && decSumCounttemp != TempNum)
                    {
                        this.m_objViewer.ctlDataGrid6[i, 1] = TempNum;
                        m_mthAddItemToCulateClass(i, 6);
                    }
                }
            }
            this.m_mthCalculateTotalMoney();
        }
        #endregion

        #region 病人是否超额
        private bool IsShowOverFlow = true;
        /// <summary>
        /// 病人是否超额
        /// </summary>
        /// <returns>true 超额,false 没有超额</returns>
        public bool m_mthIsOverFlow()
        {
            bool ret = false;
            System.Windows.Forms.Control con = this.m_objViewer.ActiveControl;
            if (this.m_mthConvertObjToDecimal(this.m_objViewer.lbeSumMoney.Text) > this.m_objViewer.m_PatInfo.Limit && this.m_objViewer.m_PatInfo.Limit > 0 && this.m_objViewer.m_PatInfo.PatientID.Trim() != "" && IsShowOverFlow)
            {
                frmShowOverFlow objfrm = new frmShowOverFlow();
                objfrm.Left = 856;
                objfrm.Top = 668;
                objfrm.Show();
                con.Focus();
                ret = false;
            }
            return ret;
        }
        #endregion

        #region 调出药典窗口
        /// <summary>
        /// 调出药典窗口
        /// </summary>
        /// <param name="p_row"></param>
        public void m_mthGetMedicineByCodex(int p_row)
        {
            com.digitalwave.controls.UCMedFind objUC = new com.digitalwave.controls.UCMedFind();
            objUC.PatientType = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
            objUC.Tag = p_row;
            objUC.OnSelected += new com.digitalwave.controls.Selected(objUC_OnSelected);
            objUC.ShowDialog();
        }
        private void objUC_OnSelected(object sender, EventArgs e)
        {
            DataRow dr = ((com.digitalwave.controls.UCMedFind)sender).CurDataRow;
            int row = (int)((com.digitalwave.controls.UCMedFind)sender).Tag;
            if (dr != null)
            {
                //if (dr["NOQTYFLAG_INT"].ToString() == "1")
                //{
                //    if (MessageBox.Show("目前药房暂时缺药，请选择其他相同功效的药物。", "系统提示", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.Retry)
                //    {
                //        return;
                //    }
                //}

                if (dr["ITEMOPINVTYPE_CHR"].ToString().Trim() != objCalPatientCharge.InvoiceCatID)//西药
                {
                    this.m_mthFillDataGridByRow(dr, row);
                }
                else//中药
                {
                    this.m_mthFillDataGridByRow2(dr, row);
                }
                ((com.digitalwave.controls.UCMedFind)sender).Close();
            }

        }

        #endregion

        #region 提交
        /// <summary>
        /// 提交用西药明细VO
        /// </summary>
        private clsOutpatientPWMRecipeDe_VO[] m_objPutPWM_VO = null;
        /// <summary>
        /// 提交用中药明细VO
        /// </summary>    
        private clsOutpatientCMRecipeDe_VO[] m_objPutCM_VO = null;
        /// <summary>
        /// 药品存在标志
        /// </summary>
        private bool m_blnExistsMed = false;
        public bool m_mthPutIn(bool isCheckMed)
        {
            if (this.m_objViewer.objCaseHistory.Diag.Trim() == "")
            {
                this.m_objViewer.Cursor = Cursors.Default;
                MessageBox.Show("必须填写诊断才能提交！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (IsShowMessageBox)
            {
                if (MessageBox.Show("是否要提交处方?提交后将不能修改", "提交确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return false;
                }
            }

            // 更新体重
            objSvc.UpdatePatientWeight(this.m_objViewer.m_PatInfo.PatientID, this.m_objViewer.txtWeight.Text);

            // 检验费用重算
            if (Recalculateflag)
            {
                this.m_mthRecalculate();
            }

            // 医保特种 病校验
            if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() == this.YBSpecialPayTypeID)
            {
                if (!this.m_blnCheckYBSpecialDeaChargeItem())
                {
                    return false;
                }
            }

            IsShowMessageBox = true;
            this.m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;

            //this.m_mthSendTestApplyBill();//　旧的检验申请单发送，失败会造成丢单
            if (m_mthSendTestApplyBill_New() < 0)
            {
                MessageBox.Show("检验申请单发送失败。", "提示");
                this.m_objViewer.Cursor = Cursors.Default;
                return false;
            }
            //this.m_mthSendCheckApplyBill();//　检查申请单
            if (!m_mthSendCheckApplyBill_new())
            {
                this.m_objViewer.Cursor = Cursors.Default;
                return false;
            }

            IsShowMessageBox = false;

            //保存失败
            try
            {
                this.IsRecipePut = isCheckMed;
                if (this.m_mthSaveAllData() == -1)
                {
                    this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
                    return false;
                }
            }
            finally
            {
                this.IsRecipePut = false;
            }

            #region 易制毒处方判断

            bool isHavePreDrug = false;
            if (this.m_objPutPWM_VO != null && this.m_objPutPWM_VO.Length > 0 && DataProduceDrugs.Count > 0)
            {
                foreach (clsOutpatientPWMRecipeDe_VO item in this.m_objPutPWM_VO)
                {
                    if (DataProduceDrugs.IndexOf(item.m_strItemID) >= 0)
                    {
                        isHavePreDrug = true;
                        break;
                    }
                }
            }
            if (clsPublic.ConvertObjToDecimal(((clsRecipeType_VO)this.m_objViewer.cmbRecipeType.SelectedItem).TYPE_INT) == 7)
            {
                if (isHavePreDrug == false)
                {
                    MessageBox.Show("易制毒处方：没有易制毒药品，不能提交。", "系统提示");
                    this.m_objViewer.Cursor = Cursors.Default;
                    return false;
                }
            }
            else
            {
                if (isHavePreDrug)
                {
                    MessageBox.Show("易制毒药品，处方类型需要选择【易制毒】", "系统提示");
                    this.m_objViewer.Cursor = Cursors.Default;
                    return false;
                }
            }

            #endregion

            ArrayList objArr = new ArrayList();
            ArrayList objArrTemp = new ArrayList();

            if (ItemInputMode == 0)
            {
                //检验
                for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim() != "")
                    {
                        if (objArrTemp.IndexOf(this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim()) > -1)
                        {
                            continue;
                        }
                        clsATTACHRELATION_VO objTemp = new clsATTACHRELATION_VO();
                        objTemp.strATTACHID_VCHR = this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim();
                        objTemp.strATTACHTYPE_INT = "3";
                        objTemp.strSOURCEITEMID_VCHR = this.m_objViewer.btSave.Tag.ToString().Trim();
                        objTemp.strSYSFROM_INT = "1";
                        objTemp.strURGENCY_INT = this.m_objViewer.URGENCY_INT.ToString();
                        objArr.Add(objTemp);
                        objArrTemp.Add(this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim());
                    }
                }

                //检查
                for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid4[i, t_ApplyId].ToString().Trim() != "")
                    {
                        if (objArrTemp.IndexOf(this.m_objViewer.ctlDataGrid4[i, t_ApplyId].ToString().Trim()) > -1)
                        {
                            continue;
                        }
                        string strTemp = (this.m_mthGetCaseHistory()).Replace("\r\n", "").Trim();
                        if (strTemp == "" || this.m_objViewer.objCaseHistory.Diag.Trim() == "")
                        {
                            this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
                            MessageBox.Show("提交检查申请单前请填写病历摘要与诊断。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }

                        clsATTACHRELATION_VO objTemp = new clsATTACHRELATION_VO();
                        objTemp.strATTACHID_VCHR = this.m_objViewer.ctlDataGrid4[i, t_ApplyId].ToString().Trim();
                        objTemp.strATTACHTYPE_INT = "1";
                        objTemp.strSOURCEITEMID_VCHR = this.m_objViewer.btSave.Tag.ToString().Trim();
                        objTemp.strSYSFROM_INT = "1";
                        objTemp.strURGENCY_INT = this.m_objViewer.URGENCY_INT.ToString();
                        objTemp.strChargeDetail = this.m_objViewer.ctlDataGrid4[i, t_test4_ChargeDetial].ToString().Trim();
                        objTemp.strDiagnosePart = this.m_objViewer.ctlDataGrid4[i, t_PartName].ToString().Trim();
                        objArr.Add(objTemp);
                        //objArrTemp.Add(this.m_objViewer.ctlDataGrid4[i, t_ApplyId].ToString().Trim());
                    }
                }

                //治疗
                for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid5[i, o_ApplyId].ToString().Trim() != "")
                    {
                        if (objArrTemp.IndexOf(this.m_objViewer.ctlDataGrid5[i, o_ApplyId].ToString().Trim()) > -1)
                        {
                            continue;
                        }
                        string strTemp = (this.m_mthGetCaseHistory()).Replace("\r\n", "").Trim();
                        if (strTemp == "" || this.m_objViewer.objCaseHistory.Diag.Trim() == "")
                        {
                            this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
                            MessageBox.Show("提交检查(治疗)申请单前请填写病历摘要与诊断。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }

                        clsATTACHRELATION_VO objTemp = new clsATTACHRELATION_VO();
                        objTemp.strATTACHID_VCHR = this.m_objViewer.ctlDataGrid5[i, o_ApplyId].ToString().Trim();
                        objTemp.strATTACHTYPE_INT = "1";
                        objTemp.strSOURCEITEMID_VCHR = this.m_objViewer.btSave.Tag.ToString().Trim();
                        objTemp.strSYSFROM_INT = "1";
                        objTemp.strURGENCY_INT = this.m_objViewer.URGENCY_INT.ToString();
                        objArr.Add(objTemp);
                        objArrTemp.Add(this.m_objViewer.ctlDataGrid5[i, o_ApplyId].ToString().Trim());
                    }
                }
            }
            else if (ItemInputMode == 1)
            {
                //检验
                for (int i = 0; i < this.m_objViewer.ctlDataGridLis.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim() != "")
                    {
                        if (objArrTemp.IndexOf(this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim()) > -1)
                        {
                            continue;
                        }
                        clsATTACHRELATION_VO objTemp = new clsATTACHRELATION_VO();
                        objTemp.strATTACHID_VCHR = this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim();
                        objTemp.strATTACHTYPE_INT = "3";
                        objTemp.strSOURCEITEMID_VCHR = this.m_objViewer.btSave.Tag.ToString().Trim();
                        objTemp.strSYSFROM_INT = "1";
                        objTemp.strURGENCY_INT = this.m_objViewer.URGENCY_INT.ToString();
                        objArr.Add(objTemp);
                        objArrTemp.Add(this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim());
                    }
                }

                //检查
                for (int i = 0; i < this.m_objViewer.ctlDataGridTest.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGridTest[i, t_ApplyId].ToString().Trim() != "")
                    {
                        if (objArrTemp.IndexOf(this.m_objViewer.ctlDataGridTest[i, t_ApplyId].ToString().Trim()) > -1)
                        {
                            continue;
                        }
                        string strTemp = (this.m_mthGetCaseHistory()).Replace("\r\n", "").Trim();
                        if (strTemp == "" || this.m_objViewer.objCaseHistory.Diag.Trim() == "")
                        {
                            this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
                            MessageBox.Show("提交检查申请单前请填写病历摘要与诊断。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }

                        clsATTACHRELATION_VO objTemp = new clsATTACHRELATION_VO();
                        objTemp.strATTACHID_VCHR = this.m_objViewer.ctlDataGridTest[i, t_ApplyId].ToString().Trim();
                        objTemp.strATTACHTYPE_INT = "1";
                        objTemp.strSOURCEITEMID_VCHR = this.m_objViewer.btSave.Tag.ToString().Trim();
                        objTemp.strSYSFROM_INT = "1";
                        objTemp.strURGENCY_INT = this.m_objViewer.URGENCY_INT.ToString();
                        objTemp.strDiagnosePart = this.m_objViewer.ctlDataGridTest[i, t_PartName].ToString().Trim();
                        objTemp.strChargeDetail = this.m_objViewer.ctlDataGridTest[i, t_test_ChargeDetial].ToString().Trim();
                        objArr.Add(objTemp);
                        //并单~
                        //objArrTemp.Add(this.m_objViewer.ctlDataGridTest[i, t_ApplyId].ToString().Trim());
                    }
                }

                //治疗
                for (int i = 0; i < this.m_objViewer.ctlDataGridOps.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGridOps[i, o_ApplyId].ToString().Trim() != "")
                    {
                        if (objArrTemp.IndexOf(this.m_objViewer.ctlDataGridOps[i, o_ApplyId].ToString().Trim()) > -1)
                        {
                            continue;
                        }
                        string strTemp = (this.m_mthGetCaseHistory()).Replace("\r\n", "").Trim();
                        if (strTemp == "" || this.m_objViewer.objCaseHistory.Diag.Trim() == "")
                        {
                            this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
                            MessageBox.Show("提交检查(治疗)申请单前请填写病历摘要与诊断。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }

                        clsATTACHRELATION_VO objTemp = new clsATTACHRELATION_VO();
                        objTemp.strATTACHID_VCHR = this.m_objViewer.ctlDataGridOps[i, o_ApplyId].ToString().Trim();
                        objTemp.strATTACHTYPE_INT = "1";
                        objTemp.strSOURCEITEMID_VCHR = this.m_objViewer.btSave.Tag.ToString().Trim();
                        objTemp.strSYSFROM_INT = "1";
                        objTemp.strURGENCY_INT = this.m_objViewer.URGENCY_INT.ToString();
                        objArr.Add(objTemp);
                        objArrTemp.Add(this.m_objViewer.ctlDataGridOps[i, o_ApplyId].ToString().Trim());
                    }
                }
            }

            //是否自动提交手术申请单
            if (Isautosendops)
            {
                string itemcode = "";
                for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
                {
                    itemcode = this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString().Trim();
                    if (itemcode != "" && this.m_objViewer.ctlDataGrid5[i, o_appflag].ToString().Trim() == "")
                    {
                        if (!this.objSvc.m_blnChkopsitem(itemcode))
                        {
                            continue;
                        }
                        clsOutops_VO objOutops_VO = new clsOutops_VO();
                        objOutops_VO.pid = this.m_objViewer.m_PatInfo.PatientID;
                        objOutops_VO.cardno = this.m_objViewer.m_PatInfo.PatientCardID;
                        objOutops_VO.recipeid = this.m_objViewer.btSave.Tag.ToString();
                        objOutops_VO.name = this.m_objViewer.m_PatInfo.PatientName;
                        objOutops_VO.sex = this.m_objViewer.m_PatInfo.PatientSex;
                        objOutops_VO.age = this.m_objViewer.m_PatInfo.PatientAge;
                        objOutops_VO.paytype = this.m_objViewer.m_PatInfo.PayTypeID;
                        objOutops_VO.deptid = this.m_objViewer.m_PatInfo.CurrentDeptID;
                        objOutops_VO.deptname = this.m_objViewer.m_PatInfo.CurrentDeptName;
                        objOutops_VO.applydoctorID = this.m_objViewer.m_PatInfo.CurrentDoctorID;
                        objOutops_VO.applydoctorname = this.m_objViewer.m_PatInfo.CurrentDoctorName;
                        objOutops_VO.chrgitem = this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString().Trim();
                        objOutops_VO.chrgname = this.m_objViewer.ctlDataGrid5[i, o_Name].ToString().Trim();
                        objOutops_VO.status = "0";
                        objOutops_VO.bookingdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                        objOutops_VO.note = "";

                        OPSApplyarr.Add(objOutops_VO);
                        this.m_objViewer.ctlDataGrid5[i, o_appflag] = "T";
                    }
                }
            }

            #region 药品扣减信息
            ArrayList MedDeductInfoArr = new ArrayList();
            if (!this.m_blnGetMedDeduct(out MedDeductInfoArr))
            {
                this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
                return false;
            }
            //if ((this.m_objPutPWM_VO == null || this.m_objPutPWM_VO.Length == 0) && (this.m_objPutCM_VO == null || this.m_objPutCM_VO.Length == 0))
            //{
            //    this.m_blnExistsMed = false;
            //}
            //else
            //{
            //    this.m_blnExistsMed = true;
            //}
            //if (this.m_blnExistsMed && MedDeductInfoArr.Count == 0)
            //{
            //    MessageBox.Show("生成药品扣减信息异常，请重新提交。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}
            #endregion

            if (this.m_objViewer.btSave.Tag != null)
            {
                string recipeId = this.m_objViewer.btSave.Tag.ToString().Trim();
                long l = objSvc.m_mthPutIn(recipeId, objArr, OPSApplyarr);
                if (l > 0)
                {
                    this.m_objViewer.lbeFlag.Text = "4";
                    // 补收诊金提示
                    if (this.m_objViewer.btSave.Tag != null)
                    {
                        ShowHospitalFee(this.m_objViewer.btSave.Tag.ToString().Trim());
                    }
                    // 微信消息推送
                    this.WechatPost();

                    // 1 正方; 2 付方
                    DataTable dtRecipe = null;
                    objSvc.m_lngGetRecipeMainInfo(recipeId, out dtRecipe);
                    string recipeFlag = dtRecipe.Rows[0]["recipeflag_int"].ToString();

                    if (Convert.ToInt32(recipeFlag) == 1)
                    {
                        // 东莞市预约平台消息通知.签到
                        this.DgPlatformPost(1);
                        // 东莞市预约平台消息通知.就医登记
                        this.DgPlatformPost(2, recipeId);
                    }
                }
                else
                {
                    MessageBox.Show("提交失败!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            this.m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            return true;
        }
        #endregion

        #region 补收诊金提示
        /// <summary>
        /// 补收诊金提示
        /// </summary>
        /// <param name="recipeId"></param>
        void ShowHospitalFee(string recipeId)
        {
            try
            {
                // 挂号ID
                string RegisterID = this.m_objViewer.m_PatInfo.RegisterID;
                // 病人类型
                string payTypeID = this.m_objViewer.m_PatInfo.PayTypeID;
                // 1 正方; 2 付方
                DataTable dtRecipe = null;
                objSvc.m_lngGetRecipeMainInfo(recipeId, out dtRecipe);
                string recipeFlag = dtRecipe.Rows[0]["recipeflag_int"].ToString();
                if (Convert.ToInt32(recipeFlag) != 1) return;

                // 职称
                clsDcl_OPCharge opSvc = new clsDcl_OPCharge();
                string strTechnicalRank = string.Empty;
                if (!string.IsNullOrEmpty(this.m_objViewer.m_PatInfo.DoctTechnicalRank))
                {
                    strTechnicalRank = this.m_objViewer.m_PatInfo.DoctTechnicalRank;
                }
                else
                {
                    strTechnicalRank = opSvc.m_strGetTechnicalRank(this.m_objViewer.m_PatInfo.DoctorID);
                }
                DataTable dtItem;
                long ret = opSvc.m_mthGetDefaultItem(out dtItem, payTypeID, recipeFlag, strTechnicalRank.Trim(), recipeId, RegisterID, this.m_objViewer.m_PatInfo.DeptID);
                if (ret > 0 && dtItem.Rows.Count > 0)
                {
                    string[] strNoGHArr = clsPublic.m_strGetSysparm("0023").Split(';');
                    string strSex = this.m_objViewer.m_PatInfo.PatientSex;
                    int intAge = 1;
                    try
                    {
                        intAge = Convert.ToInt32(this.m_objViewer.m_PatInfo.PatientAge);
                    }
                    catch
                    { }
                    int intMaleAge = Convert.ToInt32(strNoGHArr[0]);
                    int intFemaleAge = Convert.ToInt32(strNoGHArr[1]);
                    bool blnIfChargeRegister = true;

                    if (strSex == "男" && intAge >= intMaleAge)
                    {
                        blnIfChargeRegister = false;
                    }
                    if (strSex == "女" && intAge >= intFemaleAge)
                    {
                        blnIfChargeRegister = false;
                    }

                    List<string> lstItemId = new List<string>();
                    foreach (DataRow dr in dtItem.Rows)
                    {
                        if (dr["itemid_chr"].ToString().Trim() == "0000006423" && blnIfChargeRegister == false) continue;
                        lstItemId.Add(dr["itemid_chr"].ToString().Trim());
                    }
                    List<EntityItem> data = CalcPlusItem(opSvc, lstItemId, payTypeID);
                    if (data.Count > 0)
                    {
                        decimal total = this.m_objViewer.lbeSumMoney.Text.Trim() == "" ? 0 : Convert.ToDecimal(this.m_objViewer.lbeSumMoney.Text);
                        decimal accTotal = this.m_objViewer.lbeSbAccPay.Text.Trim() == "" ? 0 : Convert.ToDecimal(this.m_objViewer.lbeSbAccPay.Text);
                        foreach (EntityItem item in data)
                        {
                            total += item.total;
                            accTotal += item.acctTotal;
                        }
                        decimal selfTotal = total - accTotal;
                        this.m_objViewer.lbeSumMoney.Text = total.ToString("0.00");
                        this.m_objViewer.lbeSbAccPay.Text = accTotal == 0 ? "" : accTotal.ToString("0.00");
                        this.m_objViewer.lbeSelfPay.Text = selfTotal == 0 ? "" : selfTotal.ToString("0.00");

                        // 不再弹出界面显示
                        //frmShowPlusItem frm = new frmShowPlusItem(data, total, total - accTotal);
                        //frm.TopMost = true;
                        //frm.Show();
                    }
                }
                opSvc = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public class EntityItem
        {
            public string itemCode { get; set; }
            public string itemName { get; set; }
            public decimal price { get; set; }
            public decimal amount { get; set; }
            public decimal percent { get; set; }
            public decimal total { get; set; }
            public decimal selfTotal { get; set; }
            public decimal acctTotal { get; set; }
        }

        List<EntityItem> CalcPlusItem(clsDcl_OPCharge opSvc, List<string> lstItemId, string payTypeId)
        {
            EntityItem vo = null;
            List<EntityItem> data = new List<EntityItem>();
            foreach (string itemId in lstItemId)
            {
                DataTable dtRecord = new DataTable();
                opSvc.m_mthFindChrgItemByID(itemId, payTypeId, out dtRecord);
                if (dtRecord != null && dtRecord.Rows.Count == 1)
                {
                    DataRow dr = dtRecord.Rows[0];
                    vo = new EntityItem();
                    vo.itemCode = dr["itemcode_vchr"].ToString().Trim();
                    vo.itemName = dr["itemname_vchr"].ToString().Trim();
                    //如果是西药而已用的是最小单位,就用小单价和住院最小单位
                    if (objCalPatientCharge.m_mthIsMedicine(dr["itemopinvtype_chr"].ToString().Trim()) > 0 && dr["opchargeflg_int"].ToString().Trim() == "1")
                    {
                        vo.price = clsPublic.ConvertObjToDecimal(dr["submoney"].ToString().Trim());
                    }
                    else
                    {
                        vo.price = clsPublic.ConvertObjToDecimal(dr["itemprice_mny"].ToString().Trim());
                    }
                    vo.amount = clsPublic.ConvertObjToDecimal(dr["itemnum"]);
                    vo.percent = dr["precent_dec"] == DBNull.Value ? 100 : clsPublic.ConvertObjToDecimal(dr["precent_dec"]);
                    vo.total = clsPublic.Round(vo.price * vo.amount, 2);
                    vo.selfTotal = clsPublic.Round(vo.price * vo.amount * vo.percent / 100, 2);
                    vo.acctTotal = vo.total - vo.selfTotal;
                    data.Add(vo);
                }
            }
            return data;
        }

        #endregion

        #region 生成扣减信息

        #region 扣减信息类VO
        /// <summary>
        /// 扣减信息类VO
        /// </summary>
        private class MedDeduct_VO
        {
            /// <summary>
            /// 行号
            /// </summary>
            public int intRowNO = 0;
            /// <summary>
            /// 药品收费项目ID
            /// </summary>
            public string strItemID = string.Empty;
            /// <summary>
            /// 药品收费项目名称
            /// </summary>
            public string strItemName = string.Empty;
            /// <summary>
            /// 开药数量
            /// </summary>
            public decimal decAmount = 0;
            /// <summary>
            /// 中间包装量
            /// </summary>
            public decimal decMidPackQty = 0;
            /// <summary>
            /// 单位标志 0 基本单位 1 最小单位 2 中间单位
            /// </summary>
            public int intUnitFlag = 1;
            /// <summary>
            /// 药品项目的执行药房ID
            /// </summary>
            public string m_strMedStoreID;
            /// <summary>
            /// 执行科室ID
            /// </summary>
            public string strExecDeptID = string.Empty;
            /// <summary>
            /// 用法ID
            /// </summary>
            public string strUsageID = string.Empty;

        }
        #endregion

        /// <summary>
        /// 生成扣减信息
        /// </summary>
        /// <param name="p_arrMedDeductInfo"></param>
        /// <returns></returns>
        private bool m_blnGetMedDeduct(out ArrayList p_arrMedDeductInfo)
        {
            string strExecDeptID = string.Empty;
            DataTable dtMed = null;

            p_arrMedDeductInfo = new ArrayList();

            if (!this.SecondStockUseFlag)
            {
                return true;
            }

            if ((this.m_objPutPWM_VO == null || this.m_objPutPWM_VO.Length == 0) && (this.m_objPutCM_VO == null || this.m_objPutCM_VO.Length == 0))
            {
                return true;
            }

            //说明： 暂时不考虑非药房
            decimal decMidPackQty = 0;
            Hashtable hasMed = new Hashtable();
            MedDeduct_VO[] objMed = null;
            System.Collections.Generic.List<MedDeduct_VO> objMedDeductList = new System.Collections.Generic.List<MedDeduct_VO>();

            if (this.m_objPutPWM_VO != null && this.m_objPutPWM_VO.Length > 0)
            {
                //strExecDeptID = this.m_objPutPWM_VO[0].m_strExecDeptID;
                objMed = new MedDeduct_VO[this.m_objPutPWM_VO.Length];

                for (int i = 0; i < this.m_objPutPWM_VO.Length; i++)
                {
                    objMed[i] = new MedDeduct_VO();

                    objMed[i].intRowNO = int.Parse(this.m_objPutPWM_VO[i].m_strRowNo2);
                    objMed[i].strItemID = this.m_objPutPWM_VO[i].m_strItemID;
                    objMed[i].strItemName = this.m_objPutPWM_VO[i].m_strItemname;
                    objMed[i].decAmount = this.m_objPutPWM_VO[i].m_decTolQty;
                    if (this.m_objPutPWM_VO[i].UnitType == "1" && clsPublic.ConvertObjToDecimal(this.m_objPutPWM_VO[i].UnitScale) > 0)
                    {
                        decMidPackQty = clsPublic.ConvertObjToDecimal(this.m_objPutPWM_VO[i].UnitScale);
                    }
                    else
                    {
                        decMidPackQty = 0;
                    }
                    objMed[i].intUnitFlag = (this.m_objPutPWM_VO[i].UnitType == "0" ? 1 : 0);
                    objMed[i].decMidPackQty = 0;
                    objMed[i].strUsageID = this.m_objPutPWM_VO[i].m_strUsageID;
                    if (decMidPackQty > 0)
                    {
                        objMed[i].decAmount = objMed[i].decAmount * decMidPackQty;
                        objMed[i].intUnitFlag = 2;
                        objMed[i].decMidPackQty = decMidPackQty;
                    }

                    if (hasMed.ContainsKey(objMed[i].strItemID))
                    {
                        hasMed[objMed[i].strItemID] = decimal.Parse(hasMed[objMed[i].strItemID].ToString()) + objMed[i].decAmount;
                    }
                    else
                    {
                        hasMed.Add(objMed[i].strItemID, objMed[i].decAmount);
                    }
                }
            }
            if (objMed != null && objMed.Length > 0)//添加西药
            {
                objMedDeductList.AddRange(objMed);
                objMed = null;
            }

            if (this.m_objPutCM_VO != null && this.m_objPutCM_VO.Length > 0 && (this.m_objViewer.cboProxyBoilMed.SelectedIndex == 0))
            {
                // strExecDeptID = this.m_objPutCM_VO[0].m_strExecDeptID;
                objMed = new MedDeduct_VO[this.m_objPutCM_VO.Length];

                for (int i = 0; i < this.m_objPutCM_VO.Length; i++)
                {
                    objMed[i] = new MedDeduct_VO();
                    objMed[i].intRowNO = int.Parse(this.m_objPutCM_VO[i].m_strRowNo2);
                    objMed[i].strItemID = this.m_objPutCM_VO[i].m_strItemID;
                    objMed[i].strItemName = this.m_objPutCM_VO[i].m_strItemname;
                    objMed[i].decAmount = this.m_objPutCM_VO[i].m_decQty;
                    objMed[i].intUnitFlag = (this.m_objViewer.ctlDataGrid2[objMed[i].intRowNO, 17].ToString().Trim() == "1" ? 1 : 0);
                    objMed[i].decMidPackQty = 0;
                    objMed[i].strUsageID = this.m_objPutCM_VO[i].m_strUsageID;
                    if (hasMed.ContainsKey(objMed[i].strItemID))
                    {
                        hasMed[objMed[i].strItemID] = decimal.Parse(hasMed[objMed[i].strItemID].ToString()) + objMed[i].decAmount;
                    }
                    else
                    {
                        hasMed.Add(objMed[i].strItemID, objMed[i].decAmount);
                    }
                }
            }
            if (objMed != null && objMed.Length > 0)//添加中药
            {
                objMedDeductList.AddRange(objMed);
                objMed = null;
            }

            // 无需判断库存
            if (objMedDeductList == null || objMedDeductList.Count == 0)
            {
                return true;
            }

            #region 获取药房

            string strItemIDArr = string.Empty;//收费项目ID组
            string strTmpItemID = string.Empty;//临时变量
            string strMedStoretype = string.Empty;//药品类型
            string strMedStoreID = string.Empty;//药房ID
            string strMedStoreIDCurr = string.Empty;//药房ID组
            for (int intI = 0; intI < objMedDeductList.Count; intI++)
            {
                strTmpItemID = ((MedDeduct_VO)objMedDeductList[intI]).strItemID;
                strItemIDArr += "'" + strTmpItemID + "',";
                strMedStoretype = objSvc.m_strGetOutSendMedStoretype(strTmpItemID);

                if (strMedStoretype.Trim() == "")
                {
                    string UsageID = ((MedDeduct_VO)objMedDeductList[intI]).strUsageID;//objRD_VO[intLocation].strUsageID;
                    if (UsageID != "")
                    {
                        if (WMUsageIDArr.IndexOf(UsageID) >= 0)
                        {
                            strMedStoretype = "1";
                        }
                        else if (CMUsageIDArr.IndexOf(UsageID) >= 0)
                        {
                            strMedStoretype = "2";
                        }
                        else if (MATUsageIDArr.IndexOf(UsageID) >= 0)
                        {
                            strMedStoretype = "3";
                        }
                    }
                }

                switch (strMedStoretype)
                {
                    case "1":
                        strMedStoreID = this.m_strReadXML("register", "WMedicinestore", "AnyOne");
                        break;
                    case "2":
                        strMedStoreID = this.m_strReadXML("register", "CMedicinestore", "AnyOne");
                        break;
                    case "3":
                        strMedStoreID = this.m_strReadXML("register", "MaterialStore", "AnyOne");
                        break;
                    case "4": /* 中西药房发 -> 西药房发 */
                        strMedStoreID = this.m_strReadXML("register", "WMedicinestore", "AnyOne");
                        break;
                    default:
                        strMedStoreID = "";
                        break;
                }
                strMedStoreIDCurr = this.m_strGetDurgStoreID(strMedStoreID);

                if (!string.IsNullOrEmpty(strMedStoreIDCurr))
                {
                    ((MedDeduct_VO)objMedDeductList[intI]).strExecDeptID = strMedStoreIDCurr.Trim();
                    strExecDeptID += "'" + strMedStoreIDCurr.Trim() + "',";
                }
                // long ret = objSvc.m_lngGetWorkStorage(strMedStoreID, out strMedStoreIDCurr);
                //if (strMedStoreIDCurr.Trim() == "")
                //{
                //    //strMedStoreIDCurr = strMedStoreID;
                //    dvMedStore.RowFilter = "medstoreid_chr = '" + strMedStoreID + "'";
                //    if (dvMedStore.Count > 0)
                //    {
                //        ((MedDeduct_VO)objMedDeductList[intI]).strExecDeptID = dvMedStore[0]["deptid_chr"].ToString().Trim();
                //        strExecDeptID += "'" + dvMedStore[0]["deptid_chr"].ToString().Trim() + "',";
                //    }
                //}
                //else
                //{
                //    dvMedStore.RowFilter = "medstoreid_chr = '" + strMedStoreIDCurr + "'";
                //    if (dvMedStore.Count > 0)
                //    {
                //        ((MedDeduct_VO)objMedDeductList[intI]).strExecDeptID = dvMedStore[0]["deptid_chr"].ToString().Trim();
                //        strExecDeptID += "'" + dvMedStore[0]["deptid_chr"].ToString().Trim() + "',";
                //    }
                //}
            }

            #endregion

            strItemIDArr = strItemIDArr.Substring(0, strItemIDArr.Length - 1);
            strExecDeptID = strExecDeptID.Substring(0, strExecDeptID.Length - 1);
            Hashtable hasCompleteID = new Hashtable();
            long ret1 = this.objSvc.m_lngGetTheoryAmountByMedID(strExecDeptID, strItemIDArr, this.strDeductType, out dtMed);
            if (ret1 > 0 && dtMed.Rows.Count > 0)
            {
                decimal decTotal = 0;
                for (int j = 0; j < objMedDeductList.Count; j++)
                {
                    DataRow[] drr = dtMed.Select("itemid_chr = '" + ((MedDeduct_VO)objMedDeductList[j]).strItemID + "' and drugstoreid_chr = '" + ((MedDeduct_VO)objMedDeductList[j]).strExecDeptID + "'");
                    if (drr == null || drr.Length == 0) continue;

                    //重检测库存数
                    decTotal = 0;
                    for (int k = 0; k < drr.Length; k++)
                    {
                        if (((MedDeduct_VO)objMedDeductList[j]).intUnitFlag == 0)
                        {
                            decTotal += clsPublic.ConvertObjToDecimal(drr[k]["zxsl"].ToString()) / clsPublic.ConvertObjToDecimal(drr[k]["packqty_dec"].ToString());
                        }
                        else
                        {
                            decTotal += clsPublic.ConvertObjToDecimal(drr[k]["zxsl"].ToString());
                        }
                    }

                    if (!hasCompleteID.ContainsKey(((MedDeduct_VO)objMedDeductList[j]).strItemID))
                    {
                        if (decimal.Parse(hasMed[((MedDeduct_VO)objMedDeductList[j]).strItemID].ToString()) > decTotal)
                        {
                            if (this.SecondStockLimitFlag)
                            {
                                MessageBox.Show("药品：" + drr[0]["medcode"].ToString() + " " + ((MedDeduct_VO)objMedDeductList[j]).strItemName + "库存不足或不可供，请联系药房。(药房当前可用库存数： " + decTotal.ToString("0.00") + ")", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return false;
                            }
                        }

                        hasCompleteID.Add(((MedDeduct_VO)objMedDeductList[j]).strItemID, ((MedDeduct_VO)objMedDeductList[j]).strItemID);
                    }
                    /////

                    //生成扣减信息
                    decTotal = 0;
                    decimal decAmount = 0;
                    bool b = false;
                    for (int k = 0; k < drr.Length; k++)
                    {
                        if (((MedDeduct_VO)objMedDeductList[j]).intUnitFlag == 0)
                        {
                            //decAmount = clsPublic.ConvertObjToDecimal(drr[k]["jbsl"].ToString());
                            decAmount = clsPublic.ConvertObjToDecimal(drr[k]["zxsl"].ToString()) / clsPublic.ConvertObjToDecimal(drr[k]["packqty_dec"].ToString());
                        }
                        else
                        {
                            decAmount = clsPublic.ConvertObjToDecimal(drr[k]["zxsl"].ToString());
                        }

                        if (decAmount <= 0)
                        {
                            continue;
                        }

                        clsMedDeduct_VO MedDeduct_VO = new clsMedDeduct_VO();
                        MedDeduct_VO.RecipeID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        MedDeduct_VO.DSSeriesID = drr[k]["seriesid_int"].ToString();
                        MedDeduct_VO.DrugStoreID = strExecDeptID;
                        MedDeduct_VO.MedicineID = drr[k]["medicineid_chr"].ToString();
                        MedDeduct_VO.MedicineName = ((MedDeduct_VO)objMedDeductList[j]).strItemName;
                        MedDeduct_VO.LotNo = drr[k]["lotno_vchr"].ToString();
                        MedDeduct_VO.PackQty = clsPublic.ConvertObjToDecimal(drr[k]["packqty_dec"]);
                        MedDeduct_VO.strRowNO2 = ((MedDeduct_VO)objMedDeductList[j]).intRowNO.ToString();
                        MedDeduct_VO.StorageRackID = drr[k]["storagerackid_chr"].ToString();
                        MedDeduct_VO.ChargeType = ((MedDeduct_VO)objMedDeductList[j]).intUnitFlag;
                        MedDeduct_VO.MidPackQty = ((MedDeduct_VO)objMedDeductList[j]).decMidPackQty;

                        decTotal += decAmount;
                        if (decTotal >= ((MedDeduct_VO)objMedDeductList[j]).decAmount)
                        {
                            MedDeduct_VO.Amount = ((MedDeduct_VO)objMedDeductList[j]).decAmount - (decTotal - decAmount);
                            p_arrMedDeductInfo.Add(MedDeduct_VO);

                            if (((MedDeduct_VO)objMedDeductList[j]).intUnitFlag == 0)
                            {
                                //drr[k]["jbsl"] = clsPublic.ConvertObjToDecimal(drr[k]["jbsl"].ToString()) - MedDeduct_VO.Amount;
                                drr[k]["zxsl"] = clsPublic.ConvertObjToDecimal(drr[k]["zxsl"].ToString()) - (MedDeduct_VO.Amount * clsPublic.ConvertObjToDecimal(drr[k]["packqty_dec"].ToString()));
                            }
                            else
                            {
                                drr[k]["zxsl"] = clsPublic.ConvertObjToDecimal(drr[k]["zxsl"].ToString()) - MedDeduct_VO.Amount;
                            }

                            b = true;
                            break;
                        }
                        else
                        {
                            MedDeduct_VO.Amount = decAmount;
                            p_arrMedDeductInfo.Add(MedDeduct_VO);

                            //if (objMed[j].intUnitFlag == 0)
                            //{
                            //    drr[k]["jbsl"] = 0;
                            //}
                            //else
                            //{
                            drr[k]["zxsl"] = 0;
                            //}
                        }
                    }

                    if (!b)
                    {
                        clsMedDeduct_VO MedDeduct_VO = new clsMedDeduct_VO();
                        MedDeduct_VO.RecipeID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        MedDeduct_VO.DSSeriesID = "-999";
                        MedDeduct_VO.DrugStoreID = strExecDeptID;
                        MedDeduct_VO.MedicineID = this.objSvc.m_strGetMedicineIDByChargeItemID(((MedDeduct_VO)objMedDeductList[j]).strItemID);
                        MedDeduct_VO.MedicineName = ((MedDeduct_VO)objMedDeductList[j]).strItemName;
                        MedDeduct_VO.LotNo = "*";
                        MedDeduct_VO.PackQty = clsPublic.ConvertObjToDecimal(drr[0]["packqty_dec"]);
                        MedDeduct_VO.strRowNO2 = ((MedDeduct_VO)objMedDeductList[j]).intRowNO.ToString();
                        MedDeduct_VO.Amount = ((MedDeduct_VO)objMedDeductList[j]).decAmount - decTotal;
                        MedDeduct_VO.StorageRackID = "*";
                        MedDeduct_VO.ChargeType = ((MedDeduct_VO)objMedDeductList[j]).intUnitFlag;
                        MedDeduct_VO.MidPackQty = ((MedDeduct_VO)objMedDeductList[j]).decMidPackQty;
                        p_arrMedDeductInfo.Add(MedDeduct_VO);
                    }
                }
            }
            else
            {
                MessageBox.Show("当前药品无库存(缺药或不可供)！请与管理员联系", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (p_arrMedDeductInfo.Count == 0)
            {
                MessageBox.Show("扣减表信息生成异常，请重新【提交】。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            return true;
        }
        #endregion

        #region 获取药房ID
        /// <summary>
        /// 判断药房是否需要转
        /// huafeng.xiao
        /// 2009年12月1日18:01:29
        /// </summary>
        /// <param name="p_strStoreID">当前药房ID，默认可以取空，从loginfile读取</param>
        /// <param name="p_strNewStoreID">返回需要转的药房ID</param>
        private string m_strGetDurgStoreID(string strMedStoreID)
        {
            DataTable dtTemp;
            DataView dvMedStore = null;
            string strDrugStore = string.Empty;
            string strMedStoreIDCurr = string.Empty;
            if (objSvc.m_lngGetMedStore(out dtTemp) > 0)
            {
                dvMedStore = new DataView(dtTemp);
            }
            if (this.m_objViewer.IsDetachWMedStore == 1)
            {
                long ret = objSvc.m_lngGetWorkStorage(strMedStoreID, out strMedStoreIDCurr);
            }
            if (strMedStoreIDCurr.Trim() == "")
            {
                //strMedStoreIDCurr = strMedStoreID;
                dvMedStore.RowFilter = "medstoreid_chr = '" + strMedStoreID + "'";
                if (dvMedStore.Count > 0)
                {
                    strDrugStore = dvMedStore[0]["deptid_chr"].ToString().Trim();
                }
            }
            else
            {
                dvMedStore.RowFilter = "medstoreid_chr = '" + strMedStoreIDCurr + "'";
                if (dvMedStore.Count > 0)
                {
                    strDrugStore = dvMedStore[0]["deptid_chr"].ToString().Trim();
                    //strExecDeptID += "'" + dvMedStore[0]["deptid_chr"].ToString().Trim() + "',";
                }
            }
            return strDrugStore;
        }
        #endregion

        #region 生成模板
        /// <summary>
        /// 由收费项目生成协定处方，循环所有DataGrid取数据然后调出生成界面
        /// </summary>
        private void m_mthCreatTemplat()
        {
            frmCreatConcertreCipeByItem objfrm = new frmCreatConcertreCipeByItem();
            DataRow dr;

            for (int d1 = 0; d1 < this.m_objViewer.ctlDataGrid1.RowCount; d1++)
            {
                if (this.m_objViewer.ctlDataGrid1[d1, c_ItemID].ToString().Trim() != "")
                {
                    if (this.m_objViewer.ctlDataGrid1[d1, c_FreID].ToString().Trim() == "")
                    {
                        MessageBox.Show("频率不能为空，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    if (this.m_objViewer.ctlDataGrid1[d1, c_Total].ToString().Trim() == "")
                    {
                        MessageBox.Show("总数不能为空，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //用法带出项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid1[d1, c_SubItemID].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid1[d1, c_SubItemID].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    //关联子项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid1[d1, c_resubitem].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid1[d1, c_resubitem].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    dr = objfrm.RowData;
                    dr["ROWNO_CHR"] = this.m_objViewer.ctlDataGrid1[d1, c_GroupNo].ToString().Trim();
                    dr["Code"] = this.m_objViewer.ctlDataGrid1[d1, c_Find].ToString().Trim();
                    dr["ITEMNAME_VCHR"] = this.m_objViewer.ctlDataGrid1[d1, c_Name].ToString().Trim();
                    dr["ITEMSPEC_VCHR"] = this.m_objViewer.ctlDataGrid1[d1, c_Spec].ToString().Trim();
                    dr["ItemType"] = this.m_mthConvertToChType(this.m_objViewer.ctlDataGrid1[d1, c_InvoiceType].ToString());
                    dr["ITEMPRICE_MNY"] = this.m_objViewer.ctlDataGrid1[d1, c_Price].ToString().Trim();
                    dr["DOSAGEQTY_DEC"] = this.m_objViewer.ctlDataGrid1[d1, c_Count].ToString().Trim();
                    dr["DosageUnit"] = this.m_objViewer.ctlDataGrid1[d1, c_Unit].ToString().Trim();
                    dr["QTY_DEC"] = this.m_objViewer.ctlDataGrid1[d1, c_Total].ToString().Trim();
                    dr["ITEMOPUNIT_CHR"] = this.m_objViewer.ctlDataGrid1[d1, c_BigUnit].ToString().Trim();
                    dr["usagename_vchr"] = this.m_objViewer.ctlDataGrid1[d1, c_UsageName].ToString().Trim();
                    dr["freqname_chr"] = this.m_objViewer.ctlDataGrid1[d1, c_FreName].ToString().Trim();
                    dr["DAYS_INT"] = this.m_objViewer.ctlDataGrid1[d1, c_Day].ToString().Trim();
                    dr["tolMeny"] = this.m_objViewer.ctlDataGrid1[d1, c_SumMoney].ToString().Trim();
                    dr["ITEMID_CHR"] = this.m_objViewer.ctlDataGrid1[d1, c_ItemID].ToString().Trim();
                    dr["FREQID_CHR"] = this.m_objViewer.ctlDataGrid1[d1, c_FreID].ToString().Trim();
                    dr["DOSETYPE_CHR"] = this.m_objViewer.ctlDataGrid1[d1, c_UsageID].ToString().Trim();
                    dr["FLAG_INT"] = "2";
                    dr["PARTORTYPE_VCHR"] = "";
                    dr["PARTORTYPENAME_VCHR"] = "";

                    objfrm.RowData = dr;
                }
            }

            for (int d1 = 0; d1 < this.m_objViewer.ctlDataGrid2.RowCount; d1++)
            {
                if (this.m_objViewer.ctlDataGrid2[d1, 8].ToString().Trim() != "")
                {
                    if (this.m_objViewer.ctlDataGrid2[d1, 15].ToString().Trim() == "")
                    {
                        MessageBox.Show("总数不能为空，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //关联子项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid2[d1, cm_resubitem].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid2[d1, cm_resubitem].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    dr = objfrm.RowData;
                    dr["ROWNO_CHR"] = "";
                    dr["Code"] = this.m_objViewer.ctlDataGrid2[d1, 0].ToString().Trim();
                    dr["ITEMNAME_VCHR"] = this.m_objViewer.ctlDataGrid2[d1, 3].ToString().Trim();
                    dr["ITEMSPEC_VCHR"] = this.m_objViewer.ctlDataGrid2[d1, 4].ToString().Trim();
                    dr["ItemType"] = this.m_mthConvertToChType(this.m_objViewer.ctlDataGrid2[d1, 20].ToString());
                    dr["ITEMPRICE_MNY"] = this.m_objViewer.ctlDataGrid2[d1, 6].ToString().Trim();
                    dr["DOSAGEQTY_DEC"] = this.m_objViewer.ctlDataGrid2[d1, 1].ToString().Trim();
                    dr["DosageUnit"] = this.m_objViewer.ctlDataGrid2[d1, 2].ToString().Trim();
                    dr["QTY_DEC"] = this.m_objViewer.ctlDataGrid2[d1, 15].ToString().Trim();
                    dr["ITEMOPUNIT_CHR"] = this.m_objViewer.ctlDataGrid2[d1, 2].ToString().Trim();
                    dr["usagename_vchr"] = this.m_objViewer.ctlDataGrid2[d1, 5].ToString().Trim();
                    dr["freqname_chr"] = "";
                    dr["DAYS_INT"] = "1";
                    dr["tolMeny"] = this.m_objViewer.ctlDataGrid2[d1, 7].ToString().Trim();
                    dr["ITEMID_CHR"] = this.m_objViewer.ctlDataGrid2[d1, 8].ToString().Trim();
                    dr["FREQID_CHR"] = "";
                    dr["DOSETYPE_CHR"] = this.m_objViewer.ctlDataGrid2[d1, 21].ToString().Trim();
                    dr["FLAG_INT"] = "2";
                    dr["PARTORTYPE_VCHR"] = "";
                    dr["PARTORTYPENAME_VCHR"] = "";
                    objfrm.RowData = dr;
                }
            }

            for (int d1 = 0; d1 < this.m_objViewer.ctlDataGrid3.RowCount; d1++)
            {
                if (this.m_objViewer.ctlDataGrid3[d1, t_ItemID].ToString().Trim() != "")
                {
                    if (this.m_objViewer.ctlDataGrid3[d1, t_Count].ToString().Trim() == "")
                    {
                        MessageBox.Show("总数不能为空，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //用法带出项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid3[d1, t_OtherItemID].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid3[d1, t_OtherItemID].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    //关联子项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid3[d1, t_resubitem].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid3[d1, t_resubitem].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    dr = objfrm.RowData;
                    dr["ROWNO_CHR"] = "";
                    dr["Code"] = this.m_objViewer.ctlDataGrid3[d1, t_Find].ToString().Trim();
                    dr["ITEMNAME_VCHR"] = this.m_objViewer.ctlDataGrid3[d1, t_Name].ToString().Trim();
                    dr["ITEMSPEC_VCHR"] = this.m_objViewer.ctlDataGrid3[d1, t_Spec].ToString().Trim();
                    dr["ItemType"] = this.m_mthConvertToChType(this.m_objViewer.ctlDataGrid3[d1, t_InvoiceType].ToString());
                    dr["ITEMPRICE_MNY"] = this.m_objViewer.ctlDataGrid3[d1, t_Price].ToString().Trim();
                    dr["DOSAGEQTY_DEC"] = this.m_objViewer.ctlDataGrid3[d1, t_Count].ToString().Trim();
                    dr["DosageUnit"] = this.m_objViewer.ctlDataGrid3[d1, t_Unit].ToString().Trim();
                    dr["QTY_DEC"] = this.m_objViewer.ctlDataGrid3[d1, t_Count].ToString().Trim();
                    dr["ITEMOPUNIT_CHR"] = this.m_objViewer.ctlDataGrid3[d1, t_Unit].ToString().Trim();
                    dr["usagename_vchr"] = "";
                    dr["freqname_chr"] = "";
                    dr["DAYS_INT"] = "1";
                    dr["tolMeny"] = this.m_objViewer.ctlDataGrid3[d1, t_SumMoney].ToString().Trim();
                    dr["ITEMID_CHR"] = this.m_objViewer.ctlDataGrid3[d1, t_ItemID].ToString().Trim();
                    dr["FREQID_CHR"] = "";
                    dr["DOSETYPE_CHR"] = "";
                    dr["FLAG_INT"] = "0";
                    dr["PARTORTYPE_VCHR"] = this.m_objViewer.ctlDataGrid3[d1, t_Temp].ToString().Trim();
                    dr["PARTORTYPENAME_VCHR"] = this.m_objViewer.ctlDataGrid3[d1, t_PartName].ToString().Trim();
                    objfrm.RowData = dr;
                }

            }
            for (int d1 = 0; d1 < this.m_objViewer.ctlDataGrid4.RowCount; d1++)
            {
                if (this.m_objViewer.ctlDataGrid4[d1, t_ItemID].ToString().Trim() != "")
                {
                    if (this.m_objViewer.ctlDataGrid4[d1, t_Count].ToString().Trim() == "")
                    {
                        MessageBox.Show("总数不能为空，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //用法带出项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid4[d1, t_OtherItemID].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid4[d1, t_OtherItemID].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    //关联子项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid4[d1, t_resubitem].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid4[d1, t_resubitem].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    dr = objfrm.RowData;
                    dr["ROWNO_CHR"] = "";
                    dr["Code"] = this.m_objViewer.ctlDataGrid4[d1, t_Find].ToString().Trim();
                    dr["ITEMNAME_VCHR"] = this.m_objViewer.ctlDataGrid4[d1, t_Name].ToString().Trim();
                    dr["ITEMSPEC_VCHR"] = this.m_objViewer.ctlDataGrid4[d1, t_Spec].ToString().Trim();
                    dr["ItemType"] = this.m_mthConvertToChType(this.m_objViewer.ctlDataGrid4[d1, t_InvoiceType].ToString());
                    dr["ITEMPRICE_MNY"] = this.m_objViewer.ctlDataGrid4[d1, t_Price].ToString().Trim();
                    dr["DOSAGEQTY_DEC"] = this.m_objViewer.ctlDataGrid4[d1, t_Count].ToString().Trim();
                    dr["DosageUnit"] = this.m_objViewer.ctlDataGrid4[d1, t_Unit].ToString().Trim();
                    dr["QTY_DEC"] = this.m_objViewer.ctlDataGrid4[d1, t_Count].ToString().Trim();
                    dr["ITEMOPUNIT_CHR"] = this.m_objViewer.ctlDataGrid4[d1, t_Unit].ToString().Trim();
                    dr["usagename_vchr"] = "";
                    dr["freqname_chr"] = "";
                    dr["DAYS_INT"] = "1";
                    dr["tolMeny"] = this.m_objViewer.ctlDataGrid4[d1, t_SumMoney].ToString().Trim();
                    dr["ITEMID_CHR"] = this.m_objViewer.ctlDataGrid4[d1, t_ItemID].ToString().Trim();
                    dr["FREQID_CHR"] = "";
                    dr["DOSETYPE_CHR"] = "";
                    dr["FLAG_INT"] = "1";
                    dr["PARTORTYPE_VCHR"] = this.m_objViewer.ctlDataGrid4[d1, t_Temp].ToString().Trim();
                    dr["PARTORTYPENAME_VCHR"] = this.m_objViewer.ctlDataGrid4[d1, t_PartName].ToString().Trim();
                    objfrm.RowData = dr;
                }

            }
            for (int d1 = 0; d1 < this.m_objViewer.ctlDataGrid5.RowCount; d1++)
            {
                if (this.m_objViewer.ctlDataGrid5[d1, t_ItemID].ToString().Trim() != "")
                {
                    if (this.m_objViewer.ctlDataGrid5[d1, o_Count].ToString().Trim() == "")
                    {
                        MessageBox.Show("总数不能为空，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //用法带出项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid5[d1, o_OtherItemID].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid5[d1, o_OtherItemID].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    //关联子项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid5[d1, o_resubitem].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid5[d1, o_resubitem].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    dr = objfrm.RowData;
                    dr["ROWNO_CHR"] = "";
                    dr["Code"] = this.m_objViewer.ctlDataGrid5[d1, o_Find].ToString().Trim();
                    dr["ITEMNAME_VCHR"] = this.m_objViewer.ctlDataGrid5[d1, o_Name].ToString().Trim();
                    dr["ITEMSPEC_VCHR"] = this.m_objViewer.ctlDataGrid5[d1, o_Spec].ToString().Trim();
                    dr["ItemType"] = this.m_mthConvertToChType(this.m_objViewer.ctlDataGrid5[d1, o_InvoiceType].ToString());
                    dr["ITEMPRICE_MNY"] = this.m_objViewer.ctlDataGrid5[d1, o_Price].ToString().Trim();
                    dr["DOSAGEQTY_DEC"] = this.m_objViewer.ctlDataGrid5[d1, o_Count].ToString().Trim();
                    dr["DosageUnit"] = this.m_objViewer.ctlDataGrid5[d1, o_Unit].ToString().Trim();
                    dr["QTY_DEC"] = this.m_objViewer.ctlDataGrid5[d1, o_Count].ToString().Trim();
                    dr["ITEMOPUNIT_CHR"] = this.m_objViewer.ctlDataGrid5[d1, o_Unit].ToString().Trim();
                    dr["usagename_vchr"] = "";
                    dr["freqname_chr"] = "";
                    dr["DAYS_INT"] = "1";
                    dr["tolMeny"] = this.m_objViewer.ctlDataGrid5[d1, o_SumMoney].ToString().Trim();
                    dr["ITEMID_CHR"] = this.m_objViewer.ctlDataGrid5[d1, o_ItemID].ToString().Trim();
                    dr["FREQID_CHR"] = "";
                    dr["DOSETYPE_CHR"] = "";
                    dr["FLAG_INT"] = "2";
                    dr["PARTORTYPE_VCHR"] = "";
                    dr["PARTORTYPENAME_VCHR"] = "";
                    objfrm.RowData = dr;
                }

            }
            for (int d1 = 0; d1 < this.m_objViewer.ctlDataGrid6.RowCount; d1++)
            {
                if (this.m_objViewer.ctlDataGrid6[d1, o_ItemID].ToString().Trim() != "")
                {
                    if (this.m_objViewer.ctlDataGrid6[d1, 1].ToString().Trim() == "")
                    {
                        MessageBox.Show("总数不能为空，请检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }

                    //用法带出项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid6[d1, o_OtherItemID].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid6[d1, o_OtherItemID].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    //关联子项目不作为协定处方
                    if (this.m_objViewer.ctlDataGrid6[d1, o_resubitem].ToString().Trim() != "" && !(this.m_objViewer.ctlDataGrid6[d1, o_resubitem].ToString().Trim().StartsWith("[PK]")))
                    {
                        continue;
                    }

                    dr = objfrm.RowData;
                    dr["ROWNO_CHR"] = "";
                    dr["Code"] = this.m_objViewer.ctlDataGrid6[d1, 0].ToString().Trim();
                    dr["ITEMNAME_VCHR"] = this.m_objViewer.ctlDataGrid6[d1, 2].ToString().Trim();
                    dr["ITEMSPEC_VCHR"] = this.m_objViewer.ctlDataGrid6[d1, 3].ToString().Trim();
                    dr["ItemType"] = this.m_mthConvertToChType(this.m_objViewer.ctlDataGrid6[d1, 12].ToString());
                    dr["ITEMPRICE_MNY"] = this.m_objViewer.ctlDataGrid6[d1, 5].ToString().Trim();
                    dr["DOSAGEQTY_DEC"] = this.m_objViewer.ctlDataGrid6[d1, 1].ToString().Trim();
                    dr["DosageUnit"] = this.m_objViewer.ctlDataGrid6[d1, 4].ToString().Trim();
                    dr["QTY_DEC"] = this.m_objViewer.ctlDataGrid6[d1, 1].ToString().Trim();
                    dr["ITEMOPUNIT_CHR"] = this.m_objViewer.ctlDataGrid6[d1, 4].ToString().Trim();
                    dr["usagename_vchr"] = "";
                    dr["freqname_chr"] = "";
                    dr["DAYS_INT"] = "1";
                    dr["tolMeny"] = this.m_objViewer.ctlDataGrid6[d1, 6].ToString().Trim();
                    dr["ITEMID_CHR"] = this.m_objViewer.ctlDataGrid6[d1, 7].ToString().Trim();
                    dr["FREQID_CHR"] = "";
                    dr["DOSETYPE_CHR"] = "";
                    dr["FLAG_INT"] = "2";
                    dr["PARTORTYPE_VCHR"] = "";
                    dr["PARTORTYPENAME_VCHR"] = "";
                    objfrm.RowData = dr;
                }

            }
            objfrm.ShowDialog();
        }

        #endregion

        #region 查找处方类型信息
        /// <summary>
        /// 查找处方类型信息
        /// </summary>
        private void m_mthGetRecipeTypeInfo()
        {
            clsRecipeType_VO[] objRTVO = null;
            long ret = objSvc.m_mthGetRecipeTypeInfo(out objRTVO, "");
            if (ret > 0 && objRTVO != null)
            {
                for (int i = 0; i < objRTVO.Length; i++)
                {
                    ArrayList MedProArr = new ArrayList();

                    MedProArr = this.m_Gettoken(objRTVO[i].MedProperty, ";");

                    if (MedProArr == null)
                    {
                        continue;
                    }

                    for (int j = 0; j < MedProArr.Count; j++)
                    {
                        string medpro = MedProArr[j].ToString();
                        if (!hasRecipeDefMedProperty.ContainsKey(medpro))
                        {
                            hasRecipeDefMedProperty.Add(medpro, objRTVO[i].TYPE_INT);
                        }
                    }
                }

                this.m_objViewer.cmbRecipeType.Items.AddRange(objRTVO);
                m_mthGetRecipeTypeIndex();
            }
        }
        #endregion

        #region 根据西药第一行项目指定处方类型
        /// <summary>
        /// 根据西药第一行项目指定处方类型
        /// </summary>
        /// <param name="row"></param>
        public void m_mthSetRecipeType(int row)
        {
            string ItemID = "";
            string TypeID = "0";

            if (this.m_objViewer.ctlDataGrid1.RowCount == 0)
            {
                m_mthGetRecipeTypeIndex();
                return;
            }
            else if (this.m_objViewer.ctlDataGrid1.RowCount == 1)
            {
                ItemID = m_objViewer.ctlDataGrid1[0, c_ItemID].ToString().Trim();
            }
            else if (this.m_objViewer.ctlDataGrid1.RowCount >= 2)
            {
                ItemID = m_objViewer.ctlDataGrid1[row, c_ItemID].ToString().Trim();
            }

            if (ItemID == null || ItemID == "")
            {
                m_mthGetRecipeTypeIndex();
            }
            else
            {
                TypeID = this.m_Getmedproperty(ItemID, 1);

                if (hasRecipeDefMedProperty.ContainsKey(TypeID))
                {
                    int RecipeType = int.Parse(hasRecipeDefMedProperty[TypeID].ToString());
                    this.m_objViewer.cmbRecipeType.SelectedIndex = RecipeType;
                }
                else
                {
                    m_mthGetRecipeTypeIndex();
                }
            }
        }
        #endregion

        #region 开检查单
        /// <summary>
        /// 开检查单
        /// </summary>
        public void m_mthApplyCheck()
        {
            if (this.m_objViewer.m_PatInfo.PatientID.Trim() == "")
            {
                MessageBox.Show("请先输入病人资料!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_PatInfo.txtCardID.Focus();
                return;
            }

            com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();
            clsApplyRecord objApplyVO;
            m_mthFillApplyInfo(out objApplyVO);
            clsCheckType[] objCTArr = objfrm.SaveWithVO(objApplyVO);
            m_mthFillCheckInfo(objCTArr);
        }
        private void m_mthFillCheckInfo(clsCheckType[] objCTArr)
        {
            if (objCTArr != null && objCTArr.Length > 0)
            {
                for (int i2 = 0; i2 < objCTArr.Length; i2++)
                {
                    int i = this.m_objViewer.ctlDataGrid4.RowCount;
                    clsChargeItem_VO objChargeItem = objCTArr[i2].objItem_VO;
                    if (objChargeItem == null)
                    {
                        continue;
                    }
                    this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid4[i, t_Find] = objChargeItem.m_strItemCode;
                    this.m_objViewer.ctlDataGrid4[i, t_Count] = 1;
                    this.m_objViewer.ctlDataGrid4[i, t_Name] = objChargeItem.m_strItemName;
                    this.m_objViewer.ctlDataGrid4[i, t_Spec] = objChargeItem.m_strItemSpec;
                    this.m_objViewer.ctlDataGrid4[i, t_Unit] = objChargeItem.m_ItemUnit.m_strUnitID;
                    this.m_objViewer.ctlDataGrid4[i, t_Price] = objChargeItem.m_fltItemPrice;
                    this.m_objViewer.ctlDataGrid4[i, t_SumMoney] = objChargeItem.m_fltItemPrice;
                    this.m_objViewer.ctlDataGrid4[i, t_ItemID] = objChargeItem.m_strItemID;
                    this.m_objViewer.ctlDataGrid4[i, t_PriceFlag] = objChargeItem.m_intSELFDEFINE_INT;
                    decimal temp = 100;
                    temp = objCalPatientCharge.m_mthGetDiscountByID(objChargeItem.m_strItemID);
                    m_objViewer.ctlDataGrid4[i, t_DiscountName] = temp.ToString() + "%";
                    m_objViewer.ctlDataGrid4[i, t_Discount] = temp;
                    this.m_objViewer.ctlDataGrid4[i, t_InvoiceType] = objChargeItem.m_ItemOPInvType.m_strTypeID;
                    this.m_objViewer.ctlDataGrid4[i, t_EnglishName] = objChargeItem.m_strITEMENGNAME_VCHR;
                    this.m_objViewer.ctlDataGrid4[i, t_ApplyId] = objCTArr[i2].m_strApplyID;
                    this.m_objViewer.ctlDataGrid4[i, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(objChargeItem.m_strItemID,
                    m_mthConvertObjToDecimal(objChargeItem.m_fltItemPrice), objChargeItem.m_ItemOPInvType.m_strTypeID.Trim(), 1, 3000, temp, "", false);
                }
                this.m_objViewer.tabControl1.TabIndex = 6;
                this.m_mthSetFocus();
            }
        }
        private void m_mthFillApplyInfo(out clsApplyRecord objApplyVO)
        {
            objApplyVO = new clsApplyRecord();
            objApplyVO.m_datApplyDate = DateTime.Now;
            objApplyVO.m_strAddress = this.m_objViewer.m_PatInfo.PatientHomeAddress;
            objApplyVO.m_strAge = this.m_objViewer.m_PatInfo.PatientAge;
            objApplyVO.m_strCardNO = this.m_objViewer.m_PatInfo.PatientCardID;
            objApplyVO.m_strDiagnose = this.m_objViewer.objCaseHistory.Diag;
            objApplyVO.m_strDoctorName = this.m_objViewer.m_PatInfo.DoctorName;
            objApplyVO.m_strDoctorNO = this.m_objViewer.m_PatInfo.DoctorNo;
            objApplyVO.m_strDoctorID = this.m_objViewer.m_PatInfo.DoctorID;
            objApplyVO.m_strName = this.m_objViewer.m_PatInfo.PatientName;
            objApplyVO.m_strSex = this.m_objViewer.m_PatInfo.PatientSex;
            objApplyVO.m_strTel = this.m_objViewer.m_PatInfo.PatientTelephoneNo;
            objApplyVO.m_strSummary = this.m_mthGetCaseHistory();
            objApplyVO.m_objAttachRelation.m_intSysFrom = 1;
            objApplyVO.m_strDeptID = this.m_objViewer.m_PatInfo.DeptID;
            objApplyVO.m_strDepartment = this.m_objViewer.m_PatInfo.DeptName;
            objApplyVO.m_intSubmitted = 1;
            objApplyVO.BirthDay = string.IsNullOrEmpty(this.m_objViewer.m_PatInfo.PatientBirth) ? "" : Convert.ToDateTime(this.m_objViewer.m_PatInfo.PatientBirth).ToString("yyyy-MM-dd");
        }
        #endregion

        #region 根据项目开申请单
        /// <summary>
        /// 标志是否提示保存消息,true提示,false不提示
        /// </summary>
        private bool IsShowMessageBox = true;
        /// <summary>
        /// 调阅(保存)检查申请单
        /// </summary>
        /// <param name="p_row">行号</param>
        /// <param name="AppType">类型 4 检查 5 治疗</param>
        public void m_mthApplyCheckByItem(int p_row, int AppType)
        {
            if (!CanApply || this.m_objViewer.lbeFlag.Text == "4")
            {
                return;
            }
            if (this.m_objViewer.m_PatInfo.PatientID.Trim() == "")
            {
                MessageBox.Show("请先输入病人资料!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_PatInfo.txtCardID.Focus();
                return;
            }

            DataTable dt;
            string strTypeID = "";
            string strPartName = "";
            string strItemID = "";

            if (AppType == 4)
            {
                if (this.m_objViewer.ctlDataGrid4[p_row, t_RowNo].ToString().Trim() == "")
                {
                    return;
                }
                strItemID = this.m_objViewer.ctlDataGrid4[p_row, t_ItemID].ToString().Trim();
                strPartName = this.m_objViewer.ctlDataGrid4[p_row, t_PartName].ToString();
            }
            else if (AppType == 5)
            {
                if (this.m_objViewer.ctlDataGrid5[p_row, o_RowNo].ToString().Trim() == "")
                {
                    return;
                }
                strItemID = this.m_objViewer.ctlDataGrid5[p_row, o_ItemID].ToString().Trim();
                strPartName = "";
            }

            long l = objSvc.m_mthGetApplyTypeByID(strItemID, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                strTypeID = dt.Rows[0]["APPLY_TYPE_INT"].ToString().Trim();
            }
            if (strTypeID == "" || strTypeID == "-1")
            {
                return;
            }

            IsShowMessageBox = false;
            this.m_mthSaveAllData();
            if (this.m_objViewer.btSave.Tag == null)
            {
                return;
            }

            clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();

            if (AppType == 4)
            {
                item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[p_row, t_Discount]);
                item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[p_row, t_Price]);
                item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[p_row, t_Count]);
                item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[p_row, t_SumMoney]);
                item_VO.m_strItemID = this.m_objViewer.ctlDataGrid4[p_row, t_ItemID].ToString();
                item_VO.m_strItemName = this.m_objViewer.ctlDataGrid4[p_row, t_Name].ToString();
                item_VO.m_strSpec = this.m_objViewer.ctlDataGrid4[p_row, t_Spec].ToString();
                item_VO.m_strUnit = this.m_objViewer.ctlDataGrid4[p_row, t_Unit].ToString();
            }
            else if (AppType == 5)
            {
                item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[p_row, o_Discount]);
                item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[p_row, o_Price]);
                item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[p_row, o_Count]);
                item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[p_row, o_SumMoney]);
                item_VO.m_strItemID = this.m_objViewer.ctlDataGrid5[p_row, o_ItemID].ToString();
                item_VO.m_strItemName = this.m_objViewer.ctlDataGrid5[p_row, o_Name].ToString();
                item_VO.m_strSpec = this.m_objViewer.ctlDataGrid5[p_row, o_Spec].ToString();
                item_VO.m_strUnit = this.m_objViewer.ctlDataGrid5[p_row, o_Unit].ToString();
            }

            item_VO.m_strOutpatRecipeID = "";
            item_VO.m_strRowNo = p_row.ToString();
            item_VO.m_strOprDeptID = "";

            com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();
            clsApplyRecord objApplyVO;
            m_mthFillApplyInfo(out objApplyVO);
            objApplyVO.m_strTypeID = strTypeID;
            objApplyVO.m_objChargeItem = item_VO;
            objApplyVO.m_intChargeStatus = 1;
            objApplyVO.m_strDiagnosePart = strPartName;
            objApplyVO.m_objAttachRelation.m_strSourceItemID = this.m_objViewer.btSave.Tag.ToString().Trim();
            clsCheckType[] objCTArr = objfrm.OpenWithVO(objApplyVO);

            if (objCTArr != null && objCTArr.Length > 0)
            {
                if (AppType == 4)
                {
                    this.m_objViewer.ctlDataGrid4[p_row, t_ApplyId] = objCTArr[0].m_strApplyID;
                }
                else if (AppType == 5)
                {
                    this.m_objViewer.ctlDataGrid5[p_row, o_ApplyId] = objCTArr[0].m_strApplyID;
                }
            }
        }
        #endregion

        #region 获取病历信息
        private string m_mthGetCaseHistory()
        {
            string ret = "";
            ret = this.m_objViewer.objCaseHistory.DiagMain + "\r\n";
            ret += this.m_objViewer.objCaseHistory.DiagCurr + "\r\n";
            ret += this.m_objViewer.objCaseHistory.DiagHis + "\r\n";
            ret += this.m_objViewer.objCaseHistory.Anaphylaxis + "\r\n";
            ret += this.m_objViewer.objCaseHistory.PersonHis + "\r\n";
            ret += this.m_objViewer.objCaseHistory.ExamineResult + "\r\n";
            ret += this.m_objViewer.objCaseHistory.AidCheck + "\r\n";
            //ret +=this.m_objViewer.objCaseHistory.Diag+"\r\n";
            ret += this.m_objViewer.objCaseHistory.Treatment + "\r\n";
            ret += this.m_objViewer.objCaseHistory.ReMark;
            return ret;
        }
        #endregion

        #region 删除申请单
        public void m_mthDelApplyBill(int row)
        {
            if (this.m_objViewer.ctlDataGrid4[row, t_ApplyId].ToString().Trim() == "")
            {
                return;
            }
            if (MessageBox.Show("此项目已经开了申请单,是否删除申请单?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();
            if (!objfrm.Delete(this.m_objViewer.ctlDataGrid4[row, t_ApplyId].ToString().Trim()))
            {
                MessageBox.Show("对不起,删除失败!");
            }
        }
        #endregion

        #region 加载处方类型
        /// <summary>
        /// 加载处方类型，医生开处方时，儿科医生多数开儿科类型的处方，内科开的是一般处方类型。
        /// 所以方便医生操作和减少医生操作失误，在配置文件保存了ComboBox的index，加载窗口时读出index的值
        /// </summary>
        public void m_mthGetRecipeTypeIndex()
        {
            try
            {
                string patXML = Application.StartupPath + "\\LoginFile.xml";
                if (File.Exists(patXML))
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(patXML);
                    XmlNode xn = doc.DocumentElement.SelectSingleNode("RecipeType");
                    if (xn != null)
                    {
                        string index = xn.InnerText;
                        if (index.Trim() != "")
                        {
                            int intIndex = int.Parse(index);
                            if (intIndex < this.m_objViewer.cmbRecipeType.Items.Count)
                            {
                                this.m_objViewer.cmbRecipeType.SelectedIndex = intIndex;
                            }
                        }
                    }
                    else
                    {
                        this.m_objViewer.cmbRecipeType.SelectedIndex = 0;
                    }
                }
            }
            catch
            {
                this.m_objViewer.cmbRecipeType.SelectedIndex = 0;
            }
            this.m_objViewer.cmbRecipeType.ForeColor = Color.Black;
        }
        #endregion

        #region 显示急诊处方
        /// <summary>
        /// 显示急诊处方
        /// </summary>
        /// <param name="intFlag">0 默认 1 显示急诊</param>
        public void m_mthShowRecipeEmer(int intFlag)
        {
            if (intFlag == 1)
            {
                try
                {
                    string patXML = Application.StartupPath + "\\LoginFile.xml";
                    if (File.Exists(patXML))
                    {
                        XmlDocument doc = new XmlDocument();
                        doc.Load(patXML);
                        XmlNode xn = doc.DocumentElement.SelectSingleNode("RecipeTypeEmer");
                        if (xn != null)
                        {
                            string index = xn.InnerText;
                            if (index.Trim() != "")
                            {
                                int intIndex = int.Parse(index);
                                if (intIndex < this.m_objViewer.cmbRecipeType.Items.Count)
                                {
                                    this.m_objViewer.cmbRecipeType.SelectedIndex = intIndex;
                                    this.m_objViewer.cmbRecipeType.ForeColor = Color.Red;
                                }
                            }
                        }
                        else
                        {
                            this.m_objViewer.cmbRecipeType.SelectedIndex = 0;
                            this.m_objViewer.cmbRecipeType.ForeColor = Color.Black;
                        }
                    }
                }
                catch
                {
                    this.m_objViewer.cmbRecipeType.SelectedIndex = 0;
                    this.m_objViewer.cmbRecipeType.ForeColor = Color.Black;
                }
            }
            else if (intFlag == 0)
            {
                m_mthGetRecipeTypeIndex();
            }
        }
        #endregion

        #region 检验事件处理
        /// <summary>
        /// 打开开检验申请的界面，选择一个检验项目时会产生这个事件，产生这个事件后，根据返回的申请单元ID，查出对应的收费
        /// 项目，然后填充到DataGrid。再把这些收费项目通过事件的参数传递回到申请界面。（双向传递数据）
        /// </summary>
        /// <param name="e"></param>
        private void obj_evnRequestChargeInfo(clsRequestChargeInfoEventArgs e)
        {
            if (testApplyFlag < 0)
            {
                for (int i = this.m_objViewer.ctlDataGrid3.RowCount - 1; i > -1; i--)
                {
                    if (this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim() == "1")
                    {
                        if (this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString().Trim() != "")
                        {
                            this.objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid3.m_mthDeleteRow(i);
                    }
                }
                string[] strArr = e.ApplyUnitIDArr;
                clsTestApplyItme_VO[] itemArr_VO = new clsTestApplyItme_VO[strArr.Length];
                for (int i = 0; i < strArr.Length; i++)
                {
                    this.m_mthFindChargeItemByApplyBillID(strArr[i].Trim(), out itemArr_VO[i]);
                }
                e.ChargeInfoArr = itemArr_VO;
                this.m_objViewer.tabControl1.SelectedIndex = 5;
            }
        }
        #endregion

        #region 提交发送检验申请单
        /// <summary>
        /// 提交时自动发送检验申请单
        /// </summary>
        private void m_mthSendTestApplyBill()
        {
            if (!this.IsSendTestApply)
            {
                return;
            }

            if (ItemInputMode == 0)
            {
                ArrayList objTemp = new ArrayList();
                string strTypeID = "";
                for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim() == "")
                    {
                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_SumMoney]);
                        item_VO.m_strItemID = objSvc.m_mthGetResourceIDByItemID(m_objViewer.ctlDataGrid3[i, t_ItemID].ToString());
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGrid3[i, t_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGrid3[i, t_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGrid3[i, t_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";
                        item_VO.strPartID = m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim();
                        item_VO.m_strOutpatRecipeDeID = m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim();//这里借用保存项目ID
                        if (m_objViewer.ctlDataGrid3[i, t_Temp].ToString().Trim() != "")
                        {
                            strTypeID = m_objViewer.ctlDataGrid3[i, t_Temp].ToString().Trim();
                        }
                        objTemp.Add(item_VO);
                    }
                }
                clsTestApplyItme_VO[] itemArr_VO = (clsTestApplyItme_VO[])objTemp.ToArray(typeof(clsTestApplyItme_VO));
                #region 收费病人基本数据
                clsLisApplMainVO objLMVO;
                m_mthGetPatientInfo(out objLMVO);
                #endregion
                if (itemArr_VO.Length > 0)
                {

                    //				DataTable dt;
                    //				long l =objSvc.m_mthGetApplyTypeByID(itemArr_VO[0].m_strOutpatRecipeDeID,out dt);
                    //				if(l>0&&dt.Rows.Count>0)
                    //				{
                    //					strTypeID =dt.Rows[0]["ITEMCHECKTYPE_CHR"].ToString().Trim();
                    //				}
                    objLMVO.m_strSampleTypeID = strTypeID;//加入获取样本类型代码
                }
                else
                {
                    return;
                }
                frmLisAppl obj = new frmLisAppl();
                if (obj.m_mthNewApp(objLMVO, itemArr_VO, false) == DialogResult.OK)
                {
                    //暂时注释
                    clsLISAppResults[] objAppResult = (clsLISAppResults[])obj.m_objGetMutiResults();
                    for (int i2 = 0; i2 < objAppResult.Length; i2++)
                    {
                        for (int i3 = 0; i3 < objAppResult[i2].m_strChargeIDs.Length; i3++)
                        {
                            for (int i = this.m_objViewer.ctlDataGrid3.RowCount - 1; i > -1; i--)
                            {
                                if (this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim() == "" && objAppResult[i2].m_strChargeIDs[i3] == this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim())
                                {
                                    this.m_objViewer.ctlDataGrid3[i, t_ApplyId] = objAppResult[i2].m_StrApplicationID;
                                    //暂时注释 2005-9-26
                                    //this.m_objViewer.ctlDataGrid3[i,t_PartName]=objAppResult.m_strSampleTypeName;
                                    //this.m_objViewer.ctlDataGrid3[i,t_Temp]=objAppResult.m_strSampleTypeID;
                                }

                            }
                        }
                    }
                }
            }
            else if (ItemInputMode == 1)
            {
                ArrayList objTemp = new ArrayList();
                string strTypeID = "";
                for (int i = 0; i < this.m_objViewer.ctlDataGridLis.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim() == "")
                    {
                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGridLis[i, t_PriceFlag].ToString(); ;//objSvc.m_mthGetResourceIDByItemID(m_objViewer.ctlDataGrid3[i, t_ItemID].ToString());
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGridLis[i, t_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGridLis[i, t_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGridLis[i, t_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";
                        item_VO.strPartID = m_objViewer.ctlDataGridLis[i, t_ItemID].ToString().Trim();
                        item_VO.m_strOutpatRecipeDeID = m_objViewer.ctlDataGridLis[i, t_ItemID].ToString().Trim();//这里借用保存项目ID
                        if (m_objViewer.ctlDataGridLis[i, t_Temp].ToString().Trim() != "")
                        {
                            strTypeID = m_objViewer.ctlDataGridLis[i, t_Temp].ToString().Trim();
                            item_VO.m_strSampleId = strTypeID;//保存重新选择的样本类型 2014.2.12
                        }
                        objTemp.Add(item_VO);
                    }
                }
                clsTestApplyItme_VO[] itemArr_VO = (clsTestApplyItme_VO[])objTemp.ToArray(typeof(clsTestApplyItme_VO));
                #region 收费病人基本数据
                clsLisApplMainVO objLMVO;
                m_mthGetPatientInfo(out objLMVO);
                #endregion
                if (itemArr_VO.Length > 0)
                {
                    objLMVO.m_strSampleTypeID = strTypeID;//加入获取样本类型代码
                }
                else
                {
                    return;
                }

                frmLisAppl obj = new frmLisAppl();
                if (obj.m_mthNewApp(objLMVO, itemArr_VO, false) == DialogResult.OK)
                {
                    //暂时注释
                    clsLISAppResults[] objAppResult = obj.m_objGetMutiResults();
                    for (int i2 = 0; i2 < objAppResult.Length; i2++)
                    {
                        for (int i3 = 0; i3 < objAppResult[i2].m_strChargeIDs.Length; i3++)
                        {
                            for (int i = this.m_objViewer.ctlDataGridLis.RowCount - 1; i > -1; i--)
                            {
                                //从判断－>收费项目 改为 ->申请单元
                                //if (this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim() == "" && objAppResult[i2].m_strChargeIDs[i3] == this.m_objViewer.ctlDataGridLis[i, t_ItemID].ToString().Trim())
                                if (this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim() == "" && objAppResult[i2].m_ObjApplyUnitIDArr[i3] == this.m_objViewer.ctlDataGridLis[i, t_PriceFlag].ToString().Trim())
                                {
                                    this.m_objViewer.ctlDataGridLis[i, t_ApplyId] = objAppResult[i2].m_StrApplicationID;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 带返回值的检验申请单发送方法
        /// </summary>
        /// <returns></returns>
        private int m_mthSendTestApplyBill_New()
        {
            if (!this.IsSendTestApply)
            {
                return 1;
            }

            //LisI.clsLisApplInterface_Agent objLAI = new LisI.clsLisApplInterface_Agent();
            if (ItemInputMode == 0)
            {
                ArrayList objTemp = new ArrayList();
                string strTypeID = "";
                for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim() == "")
                    {
                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_SumMoney]);
                        item_VO.m_strItemID = objSvc.m_mthGetResourceIDByItemID(m_objViewer.ctlDataGrid3[i, t_ItemID].ToString());
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGrid3[i, t_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGrid3[i, t_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGrid3[i, t_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";
                        item_VO.strPartID = m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim();
                        item_VO.m_strOutpatRecipeDeID = m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim();//这里借用保存项目ID
                        if (m_objViewer.ctlDataGrid3[i, t_Temp].ToString().Trim() != "")
                        {
                            strTypeID = m_objViewer.ctlDataGrid3[i, t_Temp].ToString().Trim();
                        }
                        else
                        {
                            MessageBox.Show(item_VO.m_strItemName + " : 需要录入检验样本。", "不能提交", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        objTemp.Add(item_VO);
                    }
                }
                clsTestApplyItme_VO[] itemArr_VO = (clsTestApplyItme_VO[])objTemp.ToArray(typeof(clsTestApplyItme_VO));
                #region 收费病人基本数据
                clsLisApplMainVO objLMVO;
                m_mthGetPatientInfo(out objLMVO);
                #endregion
                if (itemArr_VO.Length > 0)
                {

                    //				DataTable dt;
                    //				long l =objSvc.m_mthGetApplyTypeByID(itemArr_VO[0].m_strOutpatRecipeDeID,out dt);
                    //				if(l>0&&dt.Rows.Count>0)
                    //				{
                    //					strTypeID =dt.Rows[0]["ITEMCHECKTYPE_CHR"].ToString().Trim();
                    //				}
                    objLMVO.m_strSampleTypeID = strTypeID;//加入获取样本类型代码
                }
                else
                {
                    return 1;
                }

                //if (objLAI.m_mthNewApp(objLMVO, itemArr_VO, true) > 0)
                //{
                //    //暂时注释
                //    clsLISAppResults[] objAppResult = objLAI.m_objGetMutiResults();
                //    for (int i2 = 0; i2 < objAppResult.Length; i2++)
                //    {
                //        for (int i3 = 0; i3 < objAppResult[i2].m_strChargeIDs.Length; i3++)
                //        {
                //            for (int i = this.m_objViewer.ctlDataGrid3.RowCount - 1; i > -1; i--)
                //            {
                //                if (this.m_objViewer.ctlDataGrid3[i, t_ApplyId].ToString().Trim() == "" && objAppResult[i2].m_strChargeIDs[i3] == this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim())
                //                {
                //                    this.m_objViewer.ctlDataGrid3[i, t_ApplyId] = objAppResult[i2].m_StrApplicationID;
                //                    //暂时注释 2005-9-26
                //                    //this.m_objViewer.ctlDataGrid3[i,t_PartName]=objAppResult.m_strSampleTypeName;
                //                    //this.m_objViewer.ctlDataGrid3[i,t_Temp]=objAppResult.m_strSampleTypeID;
                //                }

                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    return -1;
                //}
            }
            else if (ItemInputMode == 1)
            {
                clsDcl_DoctorWorkstation domain = new clsDcl_DoctorWorkstation();
                ArrayList objTemp = new ArrayList();
                string strTypeID = "";
                for (int i = 0; i < this.m_objViewer.ctlDataGridLis.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim() == "")
                    {
                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridLis[i, t_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGridLis[i, t_PriceFlag].ToString();   // --> 申请单元ID 
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGridLis[i, t_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGridLis[i, t_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGridLis[i, t_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = this.m_objViewer.btSave.Tag.ToString();
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";
                        item_VO.strPartID = m_objViewer.ctlDataGridLis[i, t_ItemID].ToString().Trim();              //  --> 诊疗项目字典ID
                        item_VO.m_strOutpatRecipeDeID = m_objViewer.ctlDataGridLis[i, t_ItemID].ToString().Trim();  //这里借用保存项目ID --> 诊疗项目字典ID
                        if (m_objViewer.ctlDataGridLis[i, t_Temp].ToString().Trim() != "")
                        {
                            strTypeID = m_objViewer.ctlDataGridLis[i, t_Temp].ToString().Trim();
                            item_VO.m_strSampleId = strTypeID;//保存重新选择的样本类型 2014.2.12
                        }
                        else
                        {
                            MessageBox.Show(item_VO.m_strItemName + " : 需要录入检验样本。", "不能提交", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }
                        objTemp.Add(item_VO);
                    }
                }
                domain = null;

                clsTestApplyItme_VO[] itemArr_VO = (clsTestApplyItme_VO[])objTemp.ToArray(typeof(clsTestApplyItme_VO));
                #region 收费病人基本数据
                clsLisApplMainVO objLMVO;
                m_mthGetPatientInfo(out objLMVO);
                #endregion
                if (itemArr_VO.Length > 0)
                {
                    objLMVO.m_strSampleTypeID = strTypeID;//加入获取样本类型代码
                }
                else
                {
                    return 1;
                }

                clsBIHLis lis = new clsBIHLis();
                if (lis.m_mthNewApp(objLMVO, itemArr_VO, true))
                {
                    clsLISAppResults[] objAppResult = lis.m_objGetMutiResults();
                    for (int i = 0; i < this.m_objViewer.ctlDataGridLis.RowCount; i++)
                    {
                        if (this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim() == "")
                        {
                            bool isOk = false;
                            for (int j = 0; j < objAppResult.Length; j++)
                            {
                                for (int k = 0; k < objAppResult[j].m_ObjApplyUnitIDArr.Length; k++)
                                {
                                    if (objAppResult[j].m_ObjApplyUnitIDArr[k].Trim() == this.m_objViewer.ctlDataGridLis[i, t_PriceFlag].ToString().Trim())
                                    {
                                        this.m_objViewer.ctlDataGridLis[i, t_ApplyId] = objAppResult[j].m_StrApplicationID;
                                        isOk = true;
                                        break;
                                    }
                                }
                                if (isOk) break;
                            }
                        }
                    }
                }
                else
                {
                    return -1;
                }

                //if (objLAI.m_mthNewApp(objLMVO, itemArr_VO, true) > 0)
                //{
                //    // 暂时注释
                //    clsLISAppResults[] objAppResult = objLAI.m_objGetMutiResults();
                //    for (int i2 = 0; i2 < objAppResult.Length; i2++)
                //    {
                //        for (int i3 = 0; i3 < objAppResult[i2].m_strChargeIDs.Length; i3++)
                //        {
                //            for (int i = this.m_objViewer.ctlDataGridLis.RowCount - 1; i > -1; i--)
                //            {
                //                // 从判断－>收费项目 改为 ->申请单元
                //                if (this.m_objViewer.ctlDataGridLis[i, t_ApplyId].ToString().Trim() == "" && objAppResult[i2].m_ObjApplyUnitIDArr[i3] == this.m_objViewer.ctlDataGridLis[i, t_PriceFlag].ToString().Trim())
                //                {
                //                    this.m_objViewer.ctlDataGridLis[i, t_ApplyId] = objAppResult[i2].m_StrApplicationID;
                //                }
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    return -1;
                //}
            }
            return 1;
        }
        #endregion

        #region 提交发送检查申请单
        private void m_mthSendCheckApplyBill()
        {
            if (!this.IsSendCheckApply)
            {
                return;
            }
            if (ItemInputMode == 0)
            {
                com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();

                clsApplyRecord objApplyVO;
                m_mthFillApplyInfo(out objApplyVO);

                //检查项目
                System.Collections.Generic.List<clsApplyRecord> glstApplyVO = new System.Collections.Generic.List<clsApplyRecord>();
                Hashtable hasTmp = new Hashtable();
                int intRowCount = this.m_objViewer.ctlDataGrid4.RowCount;
                clsApplyRecord objTestApply;
                for (int i = 0; i < intRowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid4[i, t_ApplyId].ToString().Trim() == "")
                    {
                        m_mthFillApplyInfo(out objTestApply);
                        string strTypeID = "";
                        DataTable dt;
                        long l = objSvc.m_mthGetApplyTypeByID(this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString(), out dt);
                        if (l > 0 && dt.Rows.Count > 0)
                        {
                            strTypeID = dt.Rows[0]["APPLY_TYPE_INT"].ToString().Trim();
                            objTestApply.m_strDiagnosePart = this.m_objViewer.ctlDataGrid4[i, t_PartName].ToString();
                        }
                        if (strTypeID == "" || strTypeID == "-1")
                        {
                            continue;
                        }


                        if (!hasTmp.ContainsKey(strTypeID))
                        {
                            hasTmp.Add(strTypeID, this.objAID_APPLY_RLT[strTypeID].ToString());
                        }

                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString();
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGrid4[i, t_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGrid4[i, t_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGrid4[i, t_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";

                        objTestApply.m_strTypeID = strTypeID;
                        objTestApply.m_objChargeItem = item_VO;
                        objTestApply.m_intChargeStatus = 1;
                        objTestApply.m_objAttachRelation.m_strSourceItemID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        glstApplyVO.Add(objTestApply);
                    }
                }
                if (glstApplyVO != null && glstApplyVO.Count > 0)
                {
                    clsCheckType[] objCTArr2 = objfrm.opGetIDWithVO(glstApplyVO.ToArray(), hasTmp);
                    glstApplyVO = null;
                    int intCTCount = objCTArr2.Length;
                    for (int i1 = 0; i1 < intRowCount; i1++)
                    {
                        for (int i2 = 0; i2 < intCTCount; i2++)
                        {
                            if (this.m_objViewer.ctlDataGrid4[i1, t_ItemID].ToString() == objCTArr2[i2].objItem_VO.m_strItemID)
                            {
                                this.m_objViewer.ctlDataGrid4[i1, t_ApplyId] = objCTArr2[i2].m_strApplyID;
                                this.m_objViewer.ctlDataGrid4[i1, t_test4_ChargeDetial] = objCTArr2[i2].m_strChargeDetail;
                                break;
                            }
                        }
                    }
                }

                //治疗项目
                for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid5[i, o_ApplyId].ToString().Trim() == "")
                    {
                        string strTypeID = "";
                        DataTable dt;
                        long l = objSvc.m_mthGetApplyTypeByID(this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString(), out dt);
                        if (l > 0 && dt.Rows.Count > 0)
                        {
                            strTypeID = dt.Rows[0]["APPLY_TYPE_INT"].ToString().Trim();
                            objApplyVO.m_strDiagnosePart = "";
                        }
                        if (strTypeID == "" || strTypeID == "-1")
                        {
                            continue;
                        }

                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString();
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGrid5[i, o_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGrid5[i, o_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGrid5[i, o_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";

                        objApplyVO.m_strTypeID = strTypeID;
                        objApplyVO.m_objChargeItem = item_VO;
                        objApplyVO.m_intChargeStatus = 1;
                        objApplyVO.m_objAttachRelation.m_strSourceItemID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        clsCheckType objCTArr = objfrm.GetIDWithVO(objApplyVO);
                        if (objCTArr != null)
                        {
                            this.m_objViewer.ctlDataGrid5[i, o_ApplyId] = objCTArr.m_strApplyID;
                        }
                    }
                }
            }
            else if (ItemInputMode == 1)
            {
                com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();

                clsApplyRecord objApplyVO;
                m_mthFillApplyInfo(out objApplyVO);
                System.Collections.Generic.List<clsApplyRecord> glstApplyVO = new System.Collections.Generic.List<clsApplyRecord>();
                int intRowCount = this.m_objViewer.ctlDataGridTest.RowCount;
                //检查项目
                Hashtable hasTmp = new Hashtable();
                clsApplyRecord objTestApply;
                for (int i = 0; i < intRowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGridTest[i, t_ApplyId].ToString().Trim() == "")
                    {
                        m_mthFillApplyInfo(out objTestApply);
                        string strTypeID = this.m_objViewer.ctlDataGridTest[i, t_PriceFlag].ToString();

                        objTestApply.m_strDiagnosePart = this.m_objViewer.ctlDataGridTest[i, t_PartName].ToString();

                        if (strTypeID == "" || strTypeID == "-1")
                        {
                            continue;
                        }

                        if (!hasTmp.ContainsKey(strTypeID))
                        {
                            hasTmp.Add(strTypeID, this.objAID_APPLY_RLT[strTypeID].ToString());
                        }

                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGridTest[i, t_ItemID].ToString();
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGridTest[i, t_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGridTest[i, t_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGridTest[i, t_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";

                        objTestApply.m_strTypeID = strTypeID;
                        objTestApply.m_objChargeItem = item_VO;
                        objTestApply.m_intChargeStatus = 1;
                        objTestApply.m_objAttachRelation.m_strSourceItemID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        glstApplyVO.Add(objTestApply);
                        objTestApply = null;
                    }
                }

                if (glstApplyVO != null && glstApplyVO.Count > 0)
                {
                    clsCheckType[] objCTArr2 = objfrm.opGetIDWithVO(glstApplyVO.ToArray(), hasTmp);
                    glstApplyVO = null;
                    int intCTCount = objCTArr2.Length;

                    for (int i1 = 0; i1 < intRowCount; i1++)
                    {
                        for (int i2 = 0; i2 < intCTCount; i2++)
                        {
                            if (objCTArr2[i2].objItem_VO.m_strItemID == this.m_objViewer.ctlDataGridTest[i1, t_ItemID].ToString())
                            {
                                this.m_objViewer.ctlDataGridTest[i1, t_ApplyId] = objCTArr2[i2].m_strApplyID;
                                this.m_objViewer.ctlDataGridTest[i1, t_test_ChargeDetial] = objCTArr2[i2].m_strChargeDetail;
                                break;
                            }
                        }
                    }
                }

                //治疗项目
                for (int i = 0; i < this.m_objViewer.ctlDataGridOps.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGridOps[i, o_ApplyId].ToString().Trim() == "")
                    {
                        string strTypeID = this.m_objViewer.ctlDataGridOps[i, o_PriceFlag].ToString();

                        objApplyVO.m_strDiagnosePart = "";

                        if (strTypeID == "" || strTypeID == "-1")
                        {
                            continue;
                        }

                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGridOps[i, o_ItemID].ToString();
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGridOps[i, o_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGridOps[i, o_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGridOps[i, o_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";

                        objApplyVO.m_strTypeID = strTypeID;
                        objApplyVO.m_objChargeItem = item_VO;
                        objApplyVO.m_intChargeStatus = 1;
                        objApplyVO.m_objAttachRelation.m_strSourceItemID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        clsCheckType objCTArr = objfrm.GetIDWithVO(objApplyVO);
                        if (objCTArr != null)
                        {
                            this.m_objViewer.ctlDataGridOps[i, o_ApplyId] = objCTArr.m_strApplyID;
                        }
                    }
                }
            }
        }

        private bool m_mthSendCheckApplyBill_new()
        {
            if (!this.IsSendCheckApply)
            {
                return true;
            }
            clsApplyInterface objRisSend = new clsApplyInterface();
            if (ItemInputMode == 0)
            {
                com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();

                clsApplyRecord objApplyVO;
                m_mthFillApplyInfo(out objApplyVO);

                //检查项目
                System.Collections.Generic.List<clsApplyRecord> glstApplyVO = new System.Collections.Generic.List<clsApplyRecord>();
                Hashtable hasTmp = new Hashtable();
                int intRowCount = this.m_objViewer.ctlDataGrid4.RowCount;
                clsApplyRecord objTestApply;
                for (int i = 0; i < intRowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid4[i, t_ApplyId].ToString().Trim() == "")
                    {
                        m_mthFillApplyInfo(out objTestApply);
                        string strTypeID = "";
                        DataTable dt;
                        long l = objSvc.m_mthGetApplyTypeByID(this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString(), out dt);
                        if (l > 0 && dt.Rows.Count > 0)
                        {
                            strTypeID = dt.Rows[0]["APPLY_TYPE_INT"].ToString().Trim();
                            objTestApply.m_strDiagnosePart = this.m_objViewer.ctlDataGrid4[i, t_PartName].ToString();
                        }
                        if (strTypeID == "" || strTypeID == "-1")
                        {
                            continue;
                        }


                        if (!hasTmp.ContainsKey(strTypeID))
                        {
                            hasTmp.Add(strTypeID, this.objAID_APPLY_RLT[strTypeID].ToString());
                        }

                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString();
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGrid4[i, t_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGrid4[i, t_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGrid4[i, t_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";

                        objTestApply.m_strTypeID = strTypeID;
                        objTestApply.m_objChargeItem = item_VO;
                        objTestApply.m_intChargeStatus = 1;
                        objTestApply.m_objAttachRelation.m_strSourceItemID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        glstApplyVO.Add(objTestApply);
                    }
                }
                if (glstApplyVO != null && glstApplyVO.Count > 0)
                {
                    clsCheckType[] objCTArr2 = objRisSend.opGetIDWithVO(glstApplyVO.ToArray(), hasTmp);
                    if (objCTArr2 == null)
                    {
                        MessageBox.Show("检查提交失败。", "提示");
                        return false;
                    }
                    glstApplyVO = null;
                    int intCTCount = objCTArr2.Length;
                    for (int i1 = 0; i1 < intRowCount; i1++)
                    {
                        for (int i2 = 0; i2 < intCTCount; i2++)
                        {
                            if (this.m_objViewer.ctlDataGrid4[i1, t_ItemID].ToString() == objCTArr2[i2].objItem_VO.m_strItemID)
                            {
                                this.m_objViewer.ctlDataGrid4[i1, t_ApplyId] = objCTArr2[i2].m_strApplyID;
                                this.m_objViewer.ctlDataGrid4[i1, t_test4_ChargeDetial] = objCTArr2[i2].m_strChargeDetail;
                                break;
                            }
                        }
                    }
                }

                //治疗项目
                for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid5[i, o_ApplyId].ToString().Trim() == "")
                    {
                        string strTypeID = "";
                        DataTable dt;
                        long l = objSvc.m_mthGetApplyTypeByID(this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString(), out dt);
                        if (l > 0 && dt.Rows.Count > 0)
                        {
                            strTypeID = dt.Rows[0]["APPLY_TYPE_INT"].ToString().Trim();
                            objApplyVO.m_strDiagnosePart = "";
                        }
                        if (strTypeID == "" || strTypeID == "-1")
                        {
                            continue;
                        }

                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString();
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGrid5[i, o_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGrid5[i, o_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGrid5[i, o_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";

                        objApplyVO.m_strTypeID = strTypeID;
                        objApplyVO.m_objChargeItem = item_VO;
                        objApplyVO.m_intChargeStatus = 1;
                        objApplyVO.m_objAttachRelation.m_strSourceItemID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        clsCheckType objCTArr = objfrm.GetIDWithVO(objApplyVO);
                        if (objCTArr != null)
                        {
                            this.m_objViewer.ctlDataGrid5[i, o_ApplyId] = objCTArr.m_strApplyID;
                        }
                    }
                }
            }
            else if (ItemInputMode == 1)
            {
                com.digitalwave.GLS_WS.clsApplyForm objfrm = new com.digitalwave.GLS_WS.clsApplyForm();

                clsApplyRecord objApplyVO;
                m_mthFillApplyInfo(out objApplyVO);
                System.Collections.Generic.List<clsApplyRecord> glstApplyVO = new System.Collections.Generic.List<clsApplyRecord>();
                int intRowCount = this.m_objViewer.ctlDataGridTest.RowCount;
                //检查项目
                Hashtable hasTmp = new Hashtable();
                clsApplyRecord objTestApply;
                for (int i = 0; i < intRowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGridTest[i, t_ApplyId].ToString().Trim() == "")
                    {
                        m_mthFillApplyInfo(out objTestApply);
                        string strTypeID = this.m_objViewer.ctlDataGridTest[i, t_PriceFlag].ToString();

                        objTestApply.m_strDiagnosePart = this.m_objViewer.ctlDataGridTest[i, t_PartName].ToString();

                        if (strTypeID == "" || strTypeID == "-1")
                        {
                            continue;
                        }

                        if (!hasTmp.ContainsKey(strTypeID))
                        {
                            hasTmp.Add(strTypeID, this.objAID_APPLY_RLT[strTypeID].ToString());
                        }

                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridTest[i, t_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGridTest[i, t_ItemID].ToString();
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGridTest[i, t_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGridTest[i, t_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGridTest[i, t_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";

                        objTestApply.m_strTypeID = strTypeID;
                        objTestApply.m_objChargeItem = item_VO;
                        objTestApply.m_intChargeStatus = 1;
                        objTestApply.m_objAttachRelation.m_strSourceItemID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        glstApplyVO.Add(objTestApply);
                        objTestApply = null;
                    }
                }

                if (glstApplyVO != null && glstApplyVO.Count > 0)
                {
                    clsCheckType[] objCTArr2 = objRisSend.opGetIDWithVO(glstApplyVO.ToArray(), hasTmp);
                    if (objCTArr2 == null)
                    {
                        MessageBox.Show("检查提交失败。", "提示");
                        return false;
                    }
                    glstApplyVO = null;
                    int intCTCount = objCTArr2.Length;

                    for (int i1 = 0; i1 < intRowCount; i1++)
                    {
                        for (int i2 = 0; i2 < intCTCount; i2++)
                        {
                            if (objCTArr2[i2].objItem_VO.m_strItemID == this.m_objViewer.ctlDataGridTest[i1, t_ItemID].ToString())
                            {
                                this.m_objViewer.ctlDataGridTest[i1, t_ApplyId] = objCTArr2[i2].m_strApplyID;
                                this.m_objViewer.ctlDataGridTest[i1, t_test_ChargeDetial] = objCTArr2[i2].m_strChargeDetail;
                                break;
                            }
                        }
                    }
                }

                //治疗项目
                for (int i = 0; i < this.m_objViewer.ctlDataGridOps.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGridOps[i, o_ApplyId].ToString().Trim() == "")
                    {
                        string strTypeID = this.m_objViewer.ctlDataGridOps[i, o_PriceFlag].ToString();

                        objApplyVO.m_strDiagnosePart = "";

                        if (strTypeID == "" || strTypeID == "-1")
                        {
                            continue;
                        }

                        clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                        item_VO.m_decDiscount = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Discount]);
                        item_VO.m_decPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Price]);
                        item_VO.m_decQty = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_Count]);
                        item_VO.m_decTolPrice = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGridOps[i, o_SumMoney]);
                        item_VO.m_strItemID = this.m_objViewer.ctlDataGridOps[i, o_ItemID].ToString();
                        item_VO.m_strItemName = this.m_objViewer.ctlDataGridOps[i, o_Name].ToString();
                        item_VO.m_strSpec = this.m_objViewer.ctlDataGridOps[i, o_Spec].ToString();
                        item_VO.m_strUnit = this.m_objViewer.ctlDataGridOps[i, o_Unit].ToString();
                        item_VO.m_strOutpatRecipeID = "";
                        item_VO.m_strRowNo = i.ToString();
                        item_VO.m_strOprDeptID = "";

                        objApplyVO.m_strTypeID = strTypeID;
                        objApplyVO.m_objChargeItem = item_VO;
                        objApplyVO.m_intChargeStatus = 1;
                        objApplyVO.m_objAttachRelation.m_strSourceItemID = this.m_objViewer.btSave.Tag.ToString().Trim();
                        clsCheckType objCTArr = objfrm.GetIDWithVO(objApplyVO);
                        if (objCTArr != null)
                        {
                            this.m_objViewer.ctlDataGridOps[i, o_ApplyId] = objCTArr.m_strApplyID;
                        }
                    }
                }
            }
            return true;
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
                    if (ItemInputMode == 0)
                    {
                        m_objViewer.ctlDataGrid3[row, t_PartName] = dt.Rows[0]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGrid3[row, t_Temp] = dt.Rows[0]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGrid3.CurrentCell = new DataGridCell(row + 1, 0);
                    }
                    else if (ItemInputMode == 1)
                    {
                        m_objViewer.ctlDataGridLis[row, t_PartName] = dt.Rows[0]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Temp] = dt.Rows[0]["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(row + 1, 0);
                    }

                    return 0;
                }
                else
                {
                    if (ItemInputMode == 0)
                    {
                        this.m_objViewer.ctlDataGrid3.Controls.Add(m_objViewer.listView5);
                        m_objViewer.listView5.Items.Clear();
                        m_objViewer.listView5.Columns[2].Text = "拼音码";
                        this.objDataGrid = this.m_objViewer.ctlDataGrid3;
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            ListViewItem lv = new ListViewItem(dt.Rows[i]["SAMPLE_TYPE_ID_CHR"].ToString().Trim());//ID
                            lv.SubItems.Add(dt.Rows[i]["PYCODE_CHR"].ToString().Trim());//助记码
                            lv.SubItems.Add(dt.Rows[i]["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim());//名称
                            m_objViewer.listView5.Items.Add(lv);
                        }
                    }
                    else if (ItemInputMode == 1)
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
                }
                return 1;
            }
            else
            {
                if (ItemInputMode == 0)
                {
                    ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid3.Columns[t_PartName]).DataGridTextBoxColumn.TextBox.SelectAll();
                }
                else if (ItemInputMode == 1)
                {
                    ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGridLis.Columns[t_PartName]).DataGridTextBoxColumn.TextBox.SelectAll();
                }
                return -1;

            }
        }
        #endregion

        #region 查找检查部位
        public long m_mthLoadCheckPart(string ID, int row)
        {
            long strRet = 0;
            string strItemID = "";
            DataTable dt = null;
            com.digitalwave.controls.datagrid.ctlDataGrid dg = new com.digitalwave.controls.datagrid.ctlDataGrid();

            if (ItemInputMode == 0)
            {
                dg = m_objViewer.ctlDataGrid4;
                strItemID = dg[row, t_ItemID].ToString().Trim();
                strRet = objSvc.m_mthLoadCheckPart(strItemID, ID, out dt);
            }
            else if (ItemInputMode == 1)
            {
                dg = m_objViewer.ctlDataGridTest;
                string id = "test->" + row.ToString() + "->" + dg[row, t_ItemID].ToString().Trim();
                clsOrder_VO Order_VO = hasOrderID[id] as clsOrder_VO;
                strRet = objSvc.m_mthLoadCheckPartOrder(Order_VO.OrderDR["APPLYTYPEID_CHR"].ToString(), ID, out dt);
            }

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
            objDataGrid.CurrentCell = new DataGridCell(rorTemp, t_PartName + 1);
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

        #region 打开住院申请卡
        private void m_mthOpenInHospitalCard()
        {
            if (this.m_objViewer.m_PatInfo.PatientID.Trim() == "")
            {
                return;
            }
            frmInhospitalCard objfrmCard = new frmInhospitalCard();
            objfrmCard.DataServer = this.objSvc;
            objfrmCard.PatientID = this.m_objViewer.m_PatInfo.PatientID;
            objfrmCard.Diag = this.m_objViewer.objCaseHistory.Diag;
            objfrmCard.ICDCode = this.m_objViewer.objCaseHistory.ICDCode;
            objfrmCard.ICDName = this.m_objViewer.objCaseHistory.ICDName;
            objfrmCard.InsuranceNo = this.m_objViewer.m_PatInfo.PatientINSURANCEID;
            objfrmCard.PatientName = this.m_objViewer.m_PatInfo.PatientName;
            objfrmCard.Sex = this.m_objViewer.m_PatInfo.PatientSex;
            objfrmCard.BirthDay = this.m_objViewer.m_PatInfo.PatientBirth;
            objfrmCard.DoctorID = this.m_objViewer.LoginInfo.m_strEmpID;
            objfrmCard.DoctorName = this.m_objViewer.LoginInfo.m_strEmpName;
            objfrmCard.DoctorNo = this.m_objViewer.LoginInfo.m_strEmpNo;
            objfrmCard.Age = this.m_objViewer.m_PatInfo.PatientAge;
            objfrmCard.InhospitalDate = DateTime.Now.ToString();
            objfrmCard.HospitalTitle = this.m_objComInfo.m_strGetHospitalTitle();
            objfrmCard.LoginInfo = this.m_objViewer.LoginInfo;
            objfrmCard.ShowDialog();
        }
        #endregion

        #region 显示调价信息
        /// <summary>
        /// 显示调价信息
        /// </summary>
        private void m_mthShowPriceInfo()
        {
            string strItemID = "";
            string strName = "";
            string strPrice = "";
            string strItemCode = "";
            switch (this.m_objViewer.tabControl1.SelectedIndex)
            {

                case 3:
                    strItemID = this.m_objViewer.ctlDataGrid1[m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_ItemID].ToString();
                    strName = this.m_objViewer.ctlDataGrid1[m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_Name].ToString();
                    strPrice = this.m_objViewer.ctlDataGrid1[m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_Price].ToString();
                    strItemCode = this.m_objViewer.ctlDataGrid1[m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_Find].ToString();

                    break;
                case 4:
                    strItemID = this.m_objViewer.ctlDataGrid2[m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 8].ToString();
                    strName = this.m_objViewer.ctlDataGrid2[m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 3].ToString();
                    strPrice = this.m_objViewer.ctlDataGrid2[m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 6].ToString();
                    strItemCode = this.m_objViewer.ctlDataGrid2[m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 0].ToString();
                    break;
                case 5:
                    strItemID = this.m_objViewer.ctlDataGrid3[m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_ItemID].ToString();
                    strName = this.m_objViewer.ctlDataGrid3[m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_Name].ToString();
                    strPrice = this.m_objViewer.ctlDataGrid3[m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_Price].ToString();
                    strItemCode = this.m_objViewer.ctlDataGrid3[m_objViewer.ctlDataGrid3.CurrentCell.RowNumber, t_Find].ToString();
                    break;
                case 6:
                    strItemID = this.m_objViewer.ctlDataGrid4[m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, t_ItemID].ToString();
                    strName = this.m_objViewer.ctlDataGrid4[m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, t_Name].ToString();
                    strPrice = this.m_objViewer.ctlDataGrid4[m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, t_Price].ToString();
                    strItemCode = this.m_objViewer.ctlDataGrid4[m_objViewer.ctlDataGrid4.CurrentCell.RowNumber, t_Find].ToString();
                    break;
                case 7:
                    strItemID = this.m_objViewer.ctlDataGrid5[m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, o_ItemID].ToString();
                    strName = this.m_objViewer.ctlDataGrid5[m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, o_Name].ToString();
                    strPrice = this.m_objViewer.ctlDataGrid5[m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, o_Price].ToString();
                    strItemCode = this.m_objViewer.ctlDataGrid5[m_objViewer.ctlDataGrid5.CurrentCell.RowNumber, o_Find].ToString();
                    break;
                case 8:
                    strItemID = this.m_objViewer.ctlDataGrid6[m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, o_ItemID].ToString();
                    strName = this.m_objViewer.ctlDataGrid6[m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, o_Name].ToString();
                    strPrice = this.m_objViewer.ctlDataGrid6[m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, o_Price].ToString();
                    strItemCode = this.m_objViewer.ctlDataGrid6[m_objViewer.ctlDataGrid6.CurrentCell.RowNumber, o_Find].ToString();
                    break;

            }
            frmChangePriceInfo frmObj = new frmChangePriceInfo();
            frmObj.ItemCode = strItemCode;
            frmObj.ItemID = strItemID;
            frmObj.ItemName = strName;
            frmObj.ItemPrice = strPrice;
            frmObj.ShowDialog();
        }
        #endregion

        #region 递规获取收费项目及关联项目(暂停)
        /// <summary>
        /// 递规获取收费项目及关联项目
        /// </summary>
        /// <param name="strCurrItemID">当前收费项目</param>		
        /// <param name="intCurrRow">当前行号</param>
        /// <param name="intType">类型: -1 删除	0 插入</param>
        private void m_mthGetChargeItemByItem(string strCurrItemID, int intCurrRow, int intType, DataRow dtRow, ref bool blnFlag)
        {
            if (blnFlag)
            {
                //删除子项目
                if (intType == -1)
                {
                    for (int i = this.m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
                    {
                        if (i == intCurrRow)
                        {
                            continue;
                        }
                        if (strCurrItemID == this.m_objViewer.ctlDataGrid1[i, c_resubitem].ToString().Trim())
                        {
                            if (this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString().Trim() != "")
                            {
                                objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString()));
                            }
                            this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                        }
                    }
                    /*
                     * 中药缺省
                     **/
                    for (int i = this.m_objViewer.ctlDataGrid3.RowCount - 1; i >= 0; i--)
                    {
                        if (strCurrItemID == this.m_objViewer.ctlDataGrid3[i, t_resubitem].ToString().Trim())
                        {
                            if (this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString().Trim() != "")
                            {
                                objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString()));
                            }
                            this.m_objViewer.ctlDataGrid3.m_mthDeleteRow(i);
                        }
                    }
                    for (int i = this.m_objViewer.ctlDataGrid4.RowCount - 1; i >= 0; i--)
                    {
                        if (strCurrItemID == this.m_objViewer.ctlDataGrid4[i, t_resubitem].ToString().Trim())
                        {
                            if (this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString().Trim() != "")
                            {
                                objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString()));
                            }
                            this.m_objViewer.ctlDataGrid4.m_mthDeleteRow(i);
                        }
                    }
                    for (int i = this.m_objViewer.ctlDataGrid5.RowCount - 1; i >= 0; i--)
                    {
                        if (strCurrItemID == this.m_objViewer.ctlDataGrid5[i, 18].ToString().Trim())
                        {
                            if (this.m_objViewer.ctlDataGrid5[i, 9].ToString().Trim() != "")
                            {
                                objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid5[i, 9].ToString()));
                            }
                            this.m_objViewer.ctlDataGrid5.m_mthDeleteRow(i);
                        }
                    }
                    for (int c = this.m_objViewer.ctlDataGrid6.RowCount - 1; c >= 0; c--)
                    {
                        if (strCurrItemID == this.m_objViewer.ctlDataGrid6[c, 18].ToString().Trim())
                        {
                            if (this.m_objViewer.ctlDataGrid6[c, 9].ToString().Trim() != "")
                            {
                                objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid6[c, 9].ToString()));
                            }
                            this.m_objViewer.ctlDataGrid6.m_mthDeleteRow(c);

                        }
                    }
                }
                //插入子项目
                else if (intType == 0)
                {
                    int tempRow = 0;
                    decimal temp = 0;

                    int intFlag = 1;
                    if (dtRow["CONTINUEUSETYPE_INT"].ToString().Trim() != "0")
                    {
                        intFlag = -1;
                    }
                    switch (m_mthRelationInfo(dtRow["ITEMOPINVTYPE_CHR"].ToString()))
                    {
                        case "0001":
                            tempRow = this.m_objViewer.ctlDataGrid1.RowCount;
                            this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Count] = m_mthConvertObjToDecimal(dtRow["qty_int"]);
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Unit] = dtRow["DOSAGEUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            if (dtRow["opchargeflg_int"].ToString().Trim() == "0")
                            {
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                                m_objViewer.ctlDataGrid1[tempRow, c_BigUnit] = dtRow["ITEMOPUNIT_CHR"].ToString().Trim();//大单位
                            }
                            else
                            {
                                decimal decTemp = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) / m_mthConvertObjToDecimal(dtRow["PACKQTY_DEC"]);
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Price] = decTemp.ToString("0.0000");
                                m_objViewer.ctlDataGrid1[tempRow, c_BigUnit] = dtRow["ITEMIPUNIT_CHR"].ToString().Trim();//小单位

                            }
                            this.m_objViewer.ctlDataGrid1[tempRow, c_SumMoney] = 0;
                            this.m_objViewer.ctlDataGrid1[tempRow, c_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Packet] = m_mthConvertObjToDecimal(dtRow["PACKQTY_DEC"]);

                            this.m_objViewer.ctlDataGrid1[tempRow, c_GroupNo] = this.m_objViewer.ctlDataGrid1[intCurrRow, c_GroupNo];
                            this.m_objViewer.ctlDataGrid1[tempRow, c_UsageName] = this.m_objViewer.ctlDataGrid1[intCurrRow, c_UsageName];
                            this.m_objViewer.ctlDataGrid1[tempRow, c_FreName] = this.m_objViewer.ctlDataGrid1[intCurrRow, c_FreName];
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Day] = this.m_objViewer.ctlDataGrid1[intCurrRow, c_Day];
                            this.m_objViewer.ctlDataGrid1[tempRow, c_FreDays] = this.m_objViewer.ctlDataGrid1[intCurrRow, c_FreDays];
                            this.m_objViewer.ctlDataGrid1[tempRow, c_FreTimes] = this.m_objViewer.ctlDataGrid1[intCurrRow, c_FreTimes];
                            this.m_objViewer.ctlDataGrid1[tempRow, c_UsageID] = this.m_objViewer.ctlDataGrid1[intCurrRow, c_UsageID];
                            this.m_objViewer.ctlDataGrid1[tempRow, c_FreID] = this.m_objViewer.ctlDataGrid1[intCurrRow, c_FreID];
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid1[tempRow, c_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid1[tempRow, c_Discount] = temp;
                            this.m_objViewer.ctlDataGrid1[tempRow, c_UnitFlag] = dtRow["opchargeflg_int"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_EnglishName] = dtRow["itemengname_vchr"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Dosage] = dtRow["DOSAGE_DEC"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_IsCal] = 1;
                            this.m_objViewer.ctlDataGrid1[tempRow, c_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid1[tempRow, c_IsMain] = intCurrRow;
                            this.m_objViewer.ctlDataGrid1[tempRow, c_PreCount] = m_mthConvertObjToDecimal(dtRow["qty_dec"]) * intFlag;
                            m_mthCalculateAmount(tempRow);
                            break;
                        case "0002":

                            break;
                        case "0003":
                            tempRow = this.m_objViewer.ctlDataGrid3.RowCount;
                            this.m_objViewer.ctlDataGrid3.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Count] = m_mthConvertObjToDecimal(dtRow["qty_int"]);
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid3[tempRow, t_SumMoney] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["qty_dec"]);
                            this.m_objViewer.ctlDataGrid3[tempRow, t_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_OtherCount] = m_mthConvertObjToDecimal(dtRow["qty_dec"]) * intFlag;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_PartName] = dtRow["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Temp] = dtRow["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid3[tempRow, t_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid3[tempRow, t_Discount] = temp;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                                m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["qty_dec"]), 3000, temp, "", false);
                            break;
                        case "0004":

                            tempRow = this.m_objViewer.ctlDataGrid4.RowCount;
                            this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Count] = m_mthConvertObjToDecimal(dtRow["qty_int"]);
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid4[tempRow, t_SumMoney] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["qty_dec"]);
                            this.m_objViewer.ctlDataGrid4[tempRow, t_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_OtherCount] = m_mthConvertObjToDecimal(dtRow["qty_dec"]) * intFlag;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_PartName] = dtRow["itemchecktype_chr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Temp] = dtRow["PARTNAME"].ToString().Trim();

                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid4[tempRow, t_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid4[tempRow, t_Discount] = temp;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                                m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["qty_dec"]), 3000, temp, "", false);
                            break;
                        case "0006":
                            tempRow = this.m_objViewer.ctlDataGrid5.RowCount;
                            this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Count] = m_mthConvertObjToDecimal(dtRow["qty_int"]);
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid5[tempRow, o_SumMoney] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["qty_dec"]);
                            this.m_objViewer.ctlDataGrid5[tempRow, o_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_OtherCount] = m_mthConvertObjToDecimal(dtRow["qty_dec"]) * intFlag;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid5[tempRow, o_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid5[tempRow, o_Discount] = temp;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                                m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["qty_dec"]), 3000, temp, "", false);
                            break;
                        default://其他
                            tempRow = this.m_objViewer.ctlDataGrid6.RowCount;
                            this.m_objViewer.ctlDataGrid6.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Count] = m_mthConvertObjToDecimal(dtRow["qty_int"]);
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid6[tempRow, o_SumMoney] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["qty_dec"]);
                            this.m_objViewer.ctlDataGrid6[tempRow, o_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid6[tempRow, o_OtherCount] = m_mthConvertObjToDecimal(dtRow["qty_dec"]) * intFlag;
                            this.m_objViewer.ctlDataGrid6[tempRow, o_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid6[tempRow, o_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid6[tempRow, o_Discount] = temp;
                            this.m_objViewer.ctlDataGrid6[tempRow, o_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                                m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["qty_dec"]), 3000, temp, "", false);
                            break;
                    }
                }
                strCurrItemID = dtRow["ItemID_Chr"].ToString();
            }

            DataTable dtRecord = new DataTable();
            if (objSvc.m_blnCheckSubChargeItem(strCurrItemID, out dtRecord))
            {
                blnFlag = true;
                foreach (DataRow dRow in dtRecord.Rows)
                {
                    m_mthGetChargeItemByItem(strCurrItemID, intCurrRow, intType, dRow, ref blnFlag);
                }
            }
        }
        #endregion

        #region 循环获取收费项目及关联项目
        /// <summary>
        /// 循环获取收费项目及关联项目
        /// </summary>
        /// <param name="strCurrItemID">当前收费项目</param>		
        /// <param name="intCurrRow">当前行号</param>
        /// <param name="intType">类型: -1 删除	0 插入</param>
        public void m_mthGetChargeItemByItem(string strCurrItemID, int intType, DataTable dtRecord)
        {
            //删除子项目
            if (intType == -1)
            {
                for (int i = this.m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
                {
                    if (this.m_objViewer.ctlDataGrid1[i, c_resubitem].ToString().Trim() == strCurrItemID)
                    {
                        if (this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                    }
                }

                for (int i = this.m_objViewer.ctlDataGrid2.RowCount - 1; i >= 0; i--)
                {
                    if (this.m_objViewer.ctlDataGrid2[i, cm_resubitem].ToString().Trim() == strCurrItemID)
                    {
                        if (this.m_objViewer.ctlDataGrid2[i, 9].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid2[i, 9].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid2.m_mthDeleteRow(i);
                    }
                }

                for (int i = this.m_objViewer.ctlDataGrid3.RowCount - 1; i >= 0; i--)
                {
                    if (this.m_objViewer.ctlDataGrid3[i, t_resubitem].ToString().Trim() == strCurrItemID)
                    {
                        if (this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid3.m_mthDeleteRow(i);
                    }
                }
                for (int i = this.m_objViewer.ctlDataGrid4.RowCount - 1; i >= 0; i--)
                {
                    if (this.m_objViewer.ctlDataGrid4[i, t_resubitem].ToString().Trim() == strCurrItemID)
                    {
                        if (this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid4.m_mthDeleteRow(i);
                    }
                }
                for (int i = this.m_objViewer.ctlDataGrid5.RowCount - 1; i >= 0; i--)
                {
                    if (this.m_objViewer.ctlDataGrid5[i, o_resubitem].ToString().Trim() == strCurrItemID)
                    {
                        if (this.m_objViewer.ctlDataGrid5[i, 9].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid5[i, 9].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid5.m_mthDeleteRow(i);
                    }
                }
                for (int c = this.m_objViewer.ctlDataGrid6.RowCount - 1; c >= 0; c--)
                {
                    if (this.m_objViewer.ctlDataGrid6[c, o_resubitem].ToString().Trim() == strCurrItemID)
                    {
                        if (this.m_objViewer.ctlDataGrid6[c, 9].ToString().Trim() != "")
                        {
                            objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid6[c, 9].ToString()));
                        }
                        this.m_objViewer.ctlDataGrid6.m_mthDeleteRow(c);
                    }
                }
            }
            //插入子项目
            else if (intType == 0)
            {
                foreach (DataRow dtRow in dtRecord.Rows)
                {
                    //停用提示
                    if (dtRow["IFSTOP_INT"].ToString() == "1")
                    {
                        MessageBox.Show("被搭配的项目" + "(" + dtRow["ITEMCODE_VCHR"].ToString() + ")" + dtRow["ITEMNAME_VCHR"].ToString() + "已停用，请通知管理员重新设置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        continue;
                    }

                    //缺药
                    //if (dtRow["NOQTYFLAG_INT"].ToString() == "1")
                    //{
                    //    if (Noqtyflag)
                    //    {
                    //        if (MessageBox.Show("被搭配的项目" + "(" + dtRow["ITEMCODE_VCHR"].ToString() + ")" + dtRow["ITEMNAME_VCHR"].ToString() + "目前缺药，是否继续开该种药？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    //        {
                    //            continue;
                    //        }
                    //    }
                    //    else
                    //    {
                    //        continue;
                    //    }
                    //}

                    //子项目用于所有主项目
                    if (dtRow["usescope_int"].ToString() == "1")
                    {
                        if (this.m_blnCheckreitem(dtRow["itemid_chr"].ToString().Trim()))
                        {
                            continue;
                        }
                    }

                    int tempRow = 0;
                    decimal temp = 0;

                    int intFlag = 1;
                    if (dtRow["CONTINUEUSETYPE_INT"].ToString().Trim() != "0")
                    {
                        intFlag = -1;
                    }

                    switch (m_mthRelationInfo(dtRow["ITEMOPINVTYPE_CHR"].ToString()))
                    {
                        case "0001":
                            tempRow = this.m_objViewer.ctlDataGrid1.RowCount;
                            this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Count] = m_mthConvertObjToDecimal(dtRow["qty_int"]);
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Unit] = dtRow["DOSAGEUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_MainItemNum] = this.m_objViewer.ctlDataGrid1[tempRow, c_Count];
                            this.m_objViewer.ctlDataGrid1[tempRow, c_resubitem] = strCurrItemID; //关联项目主ID
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            if (dtRow["opchargeflg_int"].ToString().Trim() == "0")
                            {
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                                m_objViewer.ctlDataGrid1[tempRow, c_BigUnit] = dtRow["ITEMOPUNIT_CHR"].ToString().Trim();//大单位
                            }
                            else
                            {
                                decimal decTemp = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) / m_mthConvertObjToDecimal(dtRow["PACKQTY_DEC"]);
                                this.m_objViewer.ctlDataGrid1[tempRow, c_Price] = decTemp.ToString("0.0000");
                                m_objViewer.ctlDataGrid1[tempRow, c_BigUnit] = dtRow["ITEMIPUNIT_CHR"].ToString().Trim();//小单位

                            }
                            this.m_objViewer.ctlDataGrid1[tempRow, c_SumMoney] = 0;
                            this.m_objViewer.ctlDataGrid1[tempRow, c_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Packet] = m_mthConvertObjToDecimal(dtRow["PACKQTY_DEC"]);
                            this.m_objViewer.ctlDataGrid1[tempRow, c_GroupNo] = "";
                            this.m_objViewer.ctlDataGrid1[tempRow, c_UsageName] = dtRow["usagename_vchr"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_FreName] = dtRow["freqname_chr"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Day] = m_mthConvertObjToDecimal(dtRow["days_int"]);
                            this.m_objViewer.ctlDataGrid1[tempRow, c_FreDays] = dtRow["fdays"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_FreTimes] = dtRow["times_int"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_UsageID] = dtRow["usageid_chr"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_FreID] = dtRow["subfreqid_chr"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Total] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid1[tempRow, c_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid1[tempRow, c_Discount] = temp;
                            this.m_objViewer.ctlDataGrid1[tempRow, c_UnitFlag] = dtRow["opchargeflg_int"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_EnglishName] = dtRow["itemengname_vchr"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_Dosage] = dtRow["DOSAGE_DEC"].ToString();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_IsCal] = 1;
                            this.m_objViewer.ctlDataGrid1[tempRow, c_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid1[tempRow, c_IsMain] = "-4";
                            this.m_objViewer.ctlDataGrid1[tempRow, c_PreCount] = m_mthConvertObjToDecimal(dtRow["qty_dec"]) * intFlag;

                            if (dtRow["DEPTPREP_INT"].ToString() != "1")
                            {
                                this.m_objViewer.ctlDataGrid1[tempRow, c_DeptmedID] = "*";
                            }

                            m_mthCalculateAmount(tempRow);
                            break;
                        case "0002":
                            tempRow = this.m_objViewer.ctlDataGrid2.RowCount;
                            this.m_objViewer.ctlDataGrid2.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid2[tempRow, 0] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid2[tempRow, 1] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid2[tempRow, 2] = dtRow["DOSAGEUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid2[tempRow, 3] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid2[tempRow, 4] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid2[tempRow, 5] = "";
                            this.m_objViewer.ctlDataGrid2[tempRow, 6] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid2[tempRow, 7] = 0;
                            this.m_objViewer.ctlDataGrid2[tempRow, 8] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid2[tempRow, 12] = m_mthConvertObjToDecimal(dtRow["DOSAGE_DEC"]);
                            this.m_objViewer.ctlDataGrid2[tempRow, 16] = dtRow["itemprice_mny"].ToString();
                            this.m_objViewer.ctlDataGrid2[tempRow, 17] = dtRow["OPCHARGEFLG_INT"].ToString();
                            this.m_objViewer.ctlDataGrid2[tempRow, 18] = dtRow["PACKQTY_DEC"].ToString();
                            this.m_objViewer.ctlDataGrid2[tempRow, 20] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid2[tempRow, 24] = dtRow["itemengname_vchr"].ToString().Trim();
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid2[tempRow, 10] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid2[tempRow, 11] = temp;
                            this.m_objViewer.ctlDataGrid2[tempRow, 9] = "-1";
                            this.m_objViewer.ctlDataGrid2[tempRow, cm_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid2[tempRow, cm_MainItemNum] = this.m_objViewer.ctlDataGrid2[tempRow, 1];
                            this.m_objViewer.ctlDataGrid2[tempRow, 23] = m_mthConvertObjToDecimal(dtRow["qty_dec"]) * intFlag;

                            if (dtRow["DEPTPREP_INT"].ToString() != "1")
                            {
                                this.m_objViewer.ctlDataGrid2[tempRow, cm_DeptmedID] = "*";
                            }

                            m_mthCalculateAmount2(tempRow);
                            break;
                        case "0003":
                            tempRow = this.m_objViewer.ctlDataGrid3.RowCount;
                            this.m_objViewer.ctlDataGrid3.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Count] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid3[tempRow, t_SumMoney] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid3[tempRow, t_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_OtherCount] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * intFlag;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_PartName] = dtRow["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Temp] = dtRow["SAMPLE_TYPE_ID_CHR"].ToString().Trim();
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid3[tempRow, t_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid3[tempRow, t_Discount] = temp;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_MainItemNum] = this.m_objViewer.ctlDataGrid3[tempRow, t_Count];
                            this.m_objViewer.ctlDataGrid3[tempRow, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                            m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["totalqty_dec"]), 3000, temp, "", false);
                            break;
                        case "0004":
                            tempRow = this.m_objViewer.ctlDataGrid4.RowCount;
                            this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Count] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid4[tempRow, t_SumMoney] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid4[tempRow, t_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_OtherCount] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * intFlag;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_PartName] = dtRow["PARTNAME"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Temp] = dtRow["itemchecktype_chr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_MainItemNum] = this.m_objViewer.ctlDataGrid4[tempRow, t_Count];
                            this.m_objViewer.ctlDataGrid4[tempRow, t_UsageID] = dtRow["usageid_chr"].ToString().Trim();
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid4[tempRow, t_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid4[tempRow, t_Discount] = temp;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                            m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["totalqty_dec"]), 3000, temp, "", false);
                            break;
                        case "0006":
                            tempRow = this.m_objViewer.ctlDataGrid5.RowCount;
                            this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Count] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid5[tempRow, o_SumMoney] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid5[tempRow, o_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_OtherCount] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * intFlag;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_UsageID] = dtRow["usageid_chr"].ToString().Trim();
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid5[tempRow, o_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid5[tempRow, o_Discount] = temp;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_MainItemNum] = this.m_objViewer.ctlDataGrid5[tempRow, o_Count];
                            this.m_objViewer.ctlDataGrid5[tempRow, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                            m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["totalqty_dec"]), 3000, temp, "", false);
                            break;
                        default://其他
                            tempRow = this.m_objViewer.ctlDataGrid6.RowCount;
                            this.m_objViewer.ctlDataGrid6.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Count] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid6[tempRow, o_SumMoney] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid6[tempRow, o_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_resubitem] = strCurrItemID;
                            this.m_objViewer.ctlDataGrid6[tempRow, o_OtherCount] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * intFlag;
                            this.m_objViewer.ctlDataGrid6[tempRow, o_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            temp = 100;
                            //此获取比例方法已过时，会提升数据库的连接数。
                            if (objCalPatientCharge != null)
                            {
                                temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            }
                            m_objViewer.ctlDataGrid6[tempRow, o_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid6[tempRow, o_Discount] = temp;
                            this.m_objViewer.ctlDataGrid6[tempRow, o_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid6[tempRow, o_MainItemNum] = this.m_objViewer.ctlDataGrid6[tempRow, o_Count];
                            this.m_objViewer.ctlDataGrid6[tempRow, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                            m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["totalqty_dec"]), 3000, temp, "", false);

                            if (dtRow["DEPTPREP_INT"].ToString() != "1")
                            {
                                this.m_objViewer.ctlDataGrid6[tempRow, o_DeptmedID] = "*";
                            }
                            break;
                    }
                }
            }
        }
        #endregion

        #region 项目带项目： 如果子项目用于全部主项目，则只带出一次
        /// <summary>
        /// 项目带项目： 如果子项目用于全部主项目，则只带出一次
        /// </summary>
        /// <param name="itemid"></param>
        /// <returns></returns>
        private bool m_blnCheckreitem(string itemid)
        {
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString().Trim() == itemid)
                {
                    if (this.m_objViewer.ctlDataGrid1[i, c_resubitem].ToString().Trim() != "")
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid2[i, 8].ToString().Trim() == itemid)
                {
                    if (this.m_objViewer.ctlDataGrid2[i, cm_resubitem].ToString().Trim() != "")
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim() == itemid)
                {
                    if (this.m_objViewer.ctlDataGrid3[i, t_resubitem].ToString().Trim() != "" || this.m_objViewer.ctlDataGrid3[i, t_lis_orderitem].ToString().Trim() != "")
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString().Trim() == itemid)
                {
                    if (this.m_objViewer.ctlDataGrid4[i, t_resubitem].ToString().Trim() != "" || this.m_objViewer.ctlDataGrid4[i, t_test_orderitem].ToString().Trim() != "")
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString().Trim() == itemid)
                {
                    if (this.m_objViewer.ctlDataGrid5[i, o_resubitem].ToString().Trim() != "" || this.m_objViewer.ctlDataGrid5[i, t_ops_orderitem].ToString().Trim() != "")
                    {
                        return true;
                    }
                }
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid6[i, o_ItemID].ToString().Trim() == itemid)
                {
                    if (this.m_objViewer.ctlDataGrid6[i, o_resubitem].ToString().Trim() != "")
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        #endregion

        #region 判断主项目（拥有关联项目）的数量是否变化
        /// <summary>
        /// 判断主项目（拥有关联项目）的数量是否变化
        /// </summary>
        /// <param name="strCurrItemID"></param>
        /// <param name="strOldNum"></param>
        /// <param name="strNewNum"></param>
        public void m_mthCheckMainItemNum(string strCurrItemID, string strOldNum, string strNewNum, string OrderType)
        {
            if (!strCurrItemID.StartsWith("[PK]"))
            {
                return;
            }

            double dnum = 0;
            double dscale = 0;

            if (strOldNum.Trim() == "" || strOldNum.Trim() == "0")
            {
                dnum = 1;
            }
            else
            {
                dnum = Convert.ToDouble(strOldNum);
            }

            dscale = Math.Ceiling((Convert.ToDouble(strNewNum) / dnum));

            if (OrderType == null || OrderType.Trim() == "")
            {
                this.m_mthChangeSubItemNums(strCurrItemID.Replace("[PK]", ""), Convert.ToDecimal(dscale));
            }
            else
            {
                this.m_mthChangeOrderSubItemNums(strCurrItemID.Replace("[PK]", ""), Convert.ToDecimal(dscale), OrderType);
            }
        }

        /// <summary>
        /// 判断主项目（拥有关联项目）的数量是否变化
        /// 不取整
        /// </summary>
        /// <param name="strCurrItemID"></param>
        /// <param name="strOldNum"></param>
        /// <param name="strNewNum"></param>
        /// <param name="OrderType"></param>
        /// <param name="accessibleParameter">辅助参数</param>
        public void m_mthCheckMainItemNum(string strCurrItemID, string strOldNum, string strNewNum, string OrderType, string accessibleParameter)
        {
            if (!strCurrItemID.StartsWith("[PK]"))
            {
                return;
            }

            double dnum = 0;
            double dscale = 0;

            if (strOldNum.Trim() == "" || strOldNum.Trim() == "0")
            {
                dnum = 1;
            }
            else
            {
                dnum = Convert.ToDouble(strOldNum);
            }

            dscale = (Convert.ToDouble(strNewNum) / dnum);

            if (OrderType == null || OrderType.Trim() == "")
            {
                this.m_mthChangeSubItemNums(strCurrItemID.Replace("[PK]", ""), Convert.ToDecimal(dscale));
            }
            else
            {
                this.m_mthChangeOrderSubItemNums(strCurrItemID.Replace("[PK]", ""), Convert.ToDecimal(dscale), OrderType);
            }
        }
        #endregion

        #region 调整关联项目的数量
        /// <summary>
        /// 调整关联项目的数量
        /// </summary>
        /// <param name="strCurrItemID"></param>
        /// <param name="scale"></param>
        private void m_mthChangeSubItemNums(string strCurrItemID, decimal scale)
        {
            decimal orgNum = 0;

            //			for(int i=0; i<this.m_objViewer.ctlDataGrid1.RowCount; i++)
            //			{
            //				if(this.m_objViewer.ctlDataGrid1[i,c_resubitem].ToString().Trim() == strCurrItemID)
            //				{	
            //					orgNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i,c_MainItemNum]);
            //					this.m_objViewer.ctlDataGrid1[i,c_Count] = orgNum * scale; 
            //				}
            //			}
            /*
            * 中药同西药
            **/
            for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid3[i, t_resubitem].ToString().Trim() == strCurrItemID)
                {
                    orgNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_MainItemNum]);
                    this.m_objViewer.ctlDataGrid3[i, t_Count] = orgNum * scale;
                    this.m_mthAddItemToCulateClass(i, 3);
                }
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid4[i, t_resubitem].ToString().Trim() == strCurrItemID)
                {
                    orgNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_MainItemNum]);
                    this.m_objViewer.ctlDataGrid4[i, t_Count] = orgNum * scale;
                    this.m_mthAddItemToCulateClass(i, 4);
                }
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid5[i, o_resubitem].ToString().Trim() == strCurrItemID)
                {
                    orgNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, o_MainItemNum]);
                    this.m_objViewer.ctlDataGrid5[i, o_Count] = orgNum * scale;
                    this.m_mthAddItemToCulateClass(i, 5);
                }
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid6[i, o_resubitem].ToString().Trim() == strCurrItemID)
                {
                    orgNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, o_MainItemNum]);
                    this.m_objViewer.ctlDataGrid6[i, o_Count] = orgNum * scale;
                    this.m_mthAddItemToCulateClass(i, 6);
                }
            }
        }
        #endregion

        #region 调整诊疗项目-收费项目的数量
        /// <summary>
        /// 调整诊疗项目-收费项目的数量
        /// </summary>
        /// <param name="strCurrItemID"></param>
        /// <param name="scale"></param>
        private void m_mthChangeOrderSubItemNums(string strCurrItemID, decimal scale, string OrderType)
        {
            decimal orgNum = 0;

            switch (OrderType.ToLower())
            {
                case "lis":
                    clsOrder_VO Order_VO = hasOrderID["lis->" + strCurrItemID] as clsOrder_VO;
                    DataTable dt = Order_VO.EntryDT;

                    for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
                    {
                        if (this.m_objViewer.ctlDataGrid3[i, t_lis_orderitem].ToString().Trim() == strCurrItemID)
                        {
                            orgNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_lis_ordernum]);
                            this.m_objViewer.ctlDataGrid3[i, t_Count] = orgNum * scale;
                            this.m_mthAddItemToCulateClass(i, 3);

                            string itemid = this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                if (dt.Rows[j]["ITEMID_CHR"].ToString() == itemid)
                                {
                                    dt.Rows[j]["totalqty_dec"] = Convert.ToString(orgNum * scale);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case "test":
                    Order_VO = hasOrderID["test->" + strCurrItemID] as clsOrder_VO;
                    dt = Order_VO.EntryDT;

                    for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
                    {
                        if (this.m_objViewer.ctlDataGrid4[i, t_test_orderitem].ToString().Trim() == strCurrItemID)
                        {
                            orgNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_test_ordernum]);
                            this.m_objViewer.ctlDataGrid4[i, t_Count] = orgNum * scale;
                            this.m_mthAddItemToCulateClass(i, 4);

                            string itemid = this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                if (dt.Rows[j]["ITEMID_CHR"].ToString() == itemid)
                                {
                                    dt.Rows[j]["totalqty_dec"] = Convert.ToString(orgNum * scale);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case "ops":
                    Order_VO = hasOrderID["ops->" + strCurrItemID] as clsOrder_VO;
                    dt = Order_VO.EntryDT;

                    for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
                    {
                        if (this.m_objViewer.ctlDataGrid5[i, t_ops_orderitem].ToString().Trim() == strCurrItemID)
                        {
                            orgNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, t_ops_ordernum]);
                            this.m_objViewer.ctlDataGrid5[i, o_Count] = orgNum * scale;
                            this.m_mthAddItemToCulateClass(i, 5);

                            string itemid = this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString();
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                if (dt.Rows[j]["ITEMID_CHR"].ToString() == itemid)
                                {
                                    dt.Rows[j]["totalqty_dec"] = Convert.ToString(orgNum * scale);
                                    break;
                                }
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region 复用病历时同时复用该病历的所有有效处方
        private bool blnReUseRecipeByCase = false;
        /// <summary>
        /// 项目比较哈希表
        /// </summary>       
        private Hashtable HashItemCompare;
        /// <summary>
        /// 项目缺药(无库存)哈希表
        /// </summary>
        private Hashtable HashItemNoStock;
        /// <summary>
        /// 复用病历时同时复用该病历的所有有效处方
        /// </summary>
        /// <param name="strCaseID"></param>
        public void m_mthReUseRecipe(string strCaseID)
        {
            DataTable dtRecord = new DataTable();
            if (objSvc.m_blnGetRecipeIDByCaseID(strCaseID, out dtRecord))
            {
                objCalPatientCharge = new clsCalcPatientCharge(m_objViewer.m_PatInfo.PatientID, m_objViewer.m_PatInfo.PayTypeID, m_objViewer.m_PatInfo.Limit, this.m_objComInfo.m_strGetHospitalTitle(), m_objViewer.m_PatInfo.PatientType, m_objViewer.m_PatInfo.Discount);
                OPSApplyarr = new ArrayList();
                if (dtRecord.Rows.Count > 1)
                {
                    blnReUseRecipeByCase = true;
                    this.m_objViewer.ctlDataGrid1.m_mthDeleteAllRow();
                    this.m_objViewer.ctlDataGrid2.m_mthDeleteAllRow();
                    this.m_objViewer.ctlDataGrid3.m_mthDeleteAllRow();
                    this.m_objViewer.ctlDataGrid4.m_mthDeleteAllRow();
                    this.m_objViewer.ctlDataGrid5.m_mthDeleteAllRow();
                    this.m_objViewer.ctlDataGrid6.m_mthDeleteAllRow();
                    this.m_objViewer.ctlDataGridLis.m_mthDeleteAllRow();
                }

                for (int i = 0; i < dtRecord.Rows.Count; i++)
                {
                    m_mthFindChageItemByID(dtRecord.Rows[i]["outpatrecipeid_chr"].ToString(), false);
                }

                blnReUseRecipeByCase = false;
                this.m_objViewer.btSave.Tag = null;
                this.m_objViewer.btPutIn.Tag = null;
                m_mthSetFocus();
            }
        }
        #endregion

        #region 获取门诊医生工作站处方书写限定
        /// <summary>
        /// 门诊医生工作站处方书写限定 0 不处理 1 只提示 2 限定(强制分方)
        /// </summary>
        private int MedPropertyLimit = 0;
        ///// <summary>
        ///// 获取门诊医生工作站处方书写限定
        ///// </summary>
        //public void m_mthGetMedPropertyLimit()
        //{
        //    DataTable dt = null;

        //    long ret = objSvc.m_lngGetWSParm("0064", out dt);		//0064 门诊医生工作站处方书写限定 0 不处理 1 只提示 2 限定(强制分方)
        //    if (ret > 0 && dt.Rows.Count > 0)
        //    {
        //        MedPropertyLimit = int.Parse(dt.Rows[0]["SETSTATUS_INT"].ToString().Trim());
        //    }
        //}
        #endregion

        #region 获取打折信息
        ///// <summary>
        ///// 获取打折信息
        ///// </summary>
        //public void m_mthGetDiscountInfo()
        //{
        //    DataTable dt = null;

        //    long ret = objSvc.m_lngGetWSParm("4006", out dt);
        //    if (ret > 0 && dt.Rows.Count > 0)
        //    {
        //        DiscountItemNus = int.Parse(dt.Rows[0]["SETSTATUS_INT"].ToString().Trim());

        //        ret = objSvc.m_lngGetWSParm("4007", out dt);
        //        if (ret > 0 && dt.Rows.Count > 0)
        //        {
        //            DiscountScale = int.Parse(dt.Rows[0]["SETSTATUS_INT"].ToString().Trim());
        //        }
        //    }
        //}
        #endregion

        #region 获取门诊医生工作站药品处方天数设置
        /// <summary>
        /// 获取门诊医生工作站药品处方天数设置
        /// </summary>
        public int m_intGetMedDays()
        {
            int Days = 0;
            DataTable dt = null;

            long ret = objSvc.m_lngGetWSParm("0037", out dt);		//0037 获取门诊医生工作站药品处方天数设置
            if (ret > 0 && dt.Rows.Count > 0)
            {
                Days = int.Parse(dt.Rows[0]["SETSTATUS_INT"].ToString().Trim());
            }

            return Days;
        }
        #endregion

        #region 按时间段查询
        /// <summary>
        /// 当前查询模式
        /// </summary>
        public void m_mthSelectMode()
        {
            if (this.m_objViewer.llblDate.Text.Trim() == "按时间段查询>>")
            {
                this.m_objViewer.llblDate.Text = "<<返回当天";
                this.m_objViewer.lblBegin.Visible = true;
                this.m_objViewer.lblEnd.Visible = true;
                this.m_objViewer.dtpBegin.Visible = true;
                this.m_objViewer.dtpEnd.Visible = true;
                this.m_objViewer.btnSelect.Visible = true;
            }
            else
            {
                this.m_objViewer.llblDate.Text = "按时间段查询>>";
                this.m_objViewer.lblBegin.Visible = false;
                this.m_objViewer.lblEnd.Visible = false;
                this.m_objViewer.dtpBegin.Visible = false;
                this.m_objViewer.dtpEnd.Visible = false;
                this.m_objViewer.btnSelect.Visible = false;

                this.m_mthSelectPat(0);
                this.m_mthClearAllData();
            }
        }

        /// <summary>
        /// 查询就诊患者信息
        /// </summary>
        /// <param name="p_intFlag">0 当天； 1 时间段</param>
        public void m_mthSelectPat(int p_intFlag)
        {
            string m_strCurrDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
            string m_strBeginDate = this.m_objViewer.dtpBegin.Value.ToString("yyyy-MM-dd");
            string m_strEndDate = this.m_objViewer.dtpEnd.Value.ToString("yyyy-MM-dd");

            if (p_intFlag == 0)
            {
                this.m_GetTakeReg(m_strCurrDate, m_strCurrDate);
            }
            else if (p_intFlag == 1)
            {
                this.m_GetTakeReg(m_strBeginDate, m_strEndDate);
            }
        }

        #endregion

        #region 处理检验同标本下附加收费问题(暂停)
        /// <summary>
        /// 处理检验同标本下附加收费问题(暂停)
        /// </summary>
        public void m_mthGetchrgitemLisadd(int row, int flag)
        {
            string ItemID = m_objViewer.ctlDataGrid3[row, t_ItemID].ToString().Trim();
            string StypeID = m_objViewer.ctlDataGrid3[row, t_Temp].ToString().Trim();
            string ReItemID = m_objViewer.ctlDataGrid3[row, t_resubitem].ToString().Trim();

            for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                string tmpItemID = m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim();
                string tmpStypeID = m_objViewer.ctlDataGrid3[i, t_Temp].ToString().Trim();
                string tmpReItemID = m_objViewer.ctlDataGrid3[i, t_resubitem].ToString().Trim();

                if (i == row)
                {
                    continue;
                }

                //删除添加
                if (flag == 0)
                {
                    if (ReItemID.StartsWith("[PK]") && tmpReItemID.StartsWith("[PK]") && StypeID == tmpStypeID)
                    {
                        m_mthGetChargeItemByItem(ReItemID.Replace("[PK]", ""), -1, null);
                        m_objViewer.ctlDataGrid3[row, t_resubitem] = "[LK]" + i.ToString() + "->" + tmpItemID;
                        m_objViewer.ctlDataGrid3[row, t_MainItemNum] = 0;
                        break;
                    }

                    if (ReItemID.StartsWith("[PK]") && tmpReItemID.StartsWith("[LK]") && ReItemID.Replace("[PK]", "") == tmpReItemID.Replace("[LK]", "") && StypeID != tmpStypeID)
                    {
                        DataTable dtRecord = new DataTable();
                        bool blnStat = objSvc.m_blnCheckSubChargeItem(tmpItemID, out dtRecord);
                        if (blnStat)
                        {
                            m_mthGetChargeItemByItem(i.ToString() + "->" + tmpItemID, 0, dtRecord);
                            m_objViewer.ctlDataGrid3[i, t_resubitem] = "[PK]" + i.ToString() + "->" + tmpItemID;
                            m_objViewer.ctlDataGrid3[i, t_MainItemNum] = m_objViewer.ctlDataGrid3[i, t_Count];
                            break;
                        }
                    }

                    if (ReItemID.StartsWith("[LK]") && tmpReItemID.StartsWith("[PK]") && ReItemID.Replace("[LK]", "") == tmpReItemID.Replace("[PK]", "") && StypeID != tmpStypeID)
                    {
                        DataTable dtRecord = new DataTable();
                        bool blnStat = objSvc.m_blnCheckSubChargeItem(ItemID, out dtRecord);
                        if (blnStat)
                        {
                            m_mthGetChargeItemByItem(row.ToString() + "->" + ItemID, 0, dtRecord);
                            m_objViewer.ctlDataGrid3[row, t_resubitem] = "[PK]" + row.ToString() + "->" + ItemID;
                            m_objViewer.ctlDataGrid3[row, t_MainItemNum] = m_objViewer.ctlDataGrid3[row, t_Count];
                            break;
                        }
                    }
                }
                else if (flag == 1) //直接添加
                {
                    if (ReItemID.StartsWith("[PK]") && tmpReItemID.StartsWith("[LK]") && ReItemID.Replace("[PK]", "") == tmpReItemID.Replace("[LK]", "") && StypeID == tmpStypeID)
                    {
                        DataTable dtRecord = new DataTable();
                        bool blnStat = objSvc.m_blnCheckSubChargeItem(tmpItemID, out dtRecord);
                        if (blnStat)
                        {
                            m_mthGetChargeItemByItem(i.ToString() + "->" + ItemID, 0, dtRecord);
                            m_objViewer.ctlDataGrid3[i, t_resubitem] = "[PK]" + i.ToString() + "->" + tmpItemID;
                            m_objViewer.ctlDataGrid3[i, t_MainItemNum] = m_objViewer.ctlDataGrid3[i, t_Count];
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region 获取处方审核未通过信息列表(根据当前医生ID检索/默认为当天数据)
        /// <summary>
        /// 获取处方审核未通过信息列表(根据当前医生ID检索/默认为当天数据)
        /// </summary>
        public void m_mthGetrecipeconfirmfalllist()
        {
            DataTable dtRecord = new DataTable();

            long ret = objSvc.m_lngGetrecipeconfirmfall(this.m_objViewer.LoginInfo.m_strEmpID, out dtRecord);
            if (ret > 0 && dtRecord.Rows.Count > 0)
            {
                this.m_objViewer.frmRecconf.m_mthRefresh(dtRecord);
                this.m_objViewer.frmRecconf.Show();
            }
        }
        #endregion

        #region 获取过敏信息列表(根据当前医生ID检索/默认为当天数据)
        /// <summary>
        /// 获取过敏信息列表(根据当前医生ID检索/默认为当天数据)
        /// </summary>
        public void m_mthGetAllergiclist()
        {
            DataTable dtRecord = new DataTable();

            long ret = objSvc.m_lngGetAllergiclist(out dtRecord, this.m_objViewer.LoginInfo.m_strEmpID, "0");
            if (ret > 0 && dtRecord.Rows.Count > 0)
            {
                objSvc.m_lngGetAllergiclist(out dtRecord, this.m_objViewer.LoginInfo.m_strEmpID, "%");
                this.m_objViewer.frmAllergicl.m_mthRefresh(dtRecord);
                this.m_objViewer.frmAllergicl.Show();
            }
        }
        #endregion

        #region 时间间隔属性
        /// <summary>
        /// 属性: 记时器时间间隔(过敏)
        /// </summary>
        public int Timerinterval
        {
            get
            {
                int ti = 0;
                DataTable dt;
                long ret = objSvc.m_lngGetWSParm("0041", out dt);		//0043 记时器时间间隔(过敏)
                if (ret > 0 && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() != "0")
                    {
                        ti = Convert.ToInt32(dt.Rows[0]["SETSTATUS_INT"]);
                    }
                }

                return ti;
            }
        }

        /// <summary>
        /// 属性: 记时器时间间隔(处方审核未通过)
        /// </summary>
        public int Timerinterval_rec
        {
            get
            {
                int ti = 0;
                DataTable dt;
                long ret = objSvc.m_lngGetWSParm("0046", out dt);		//0046 记时器时间间隔(处方审核未通过)
                if (ret > 0 && dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() != "0")
                    {
                        ti = Convert.ToInt32(dt.Rows[0]["SETSTATUS_INT"]);
                    }
                }

                return ti;
            }
        }

        /// <summary>
        /// 属性: 记时器时间间隔(显示药典备注时间)
        /// </summary>
        public int ShowCodexRemarkFrmTimerinterval
        {
            get
            {
                int ti = 0;
                //DataTable dt;
                //long ret = objSvc.m_lngGetWSParm("0060", out dt);		//0043 记时器时间间隔(显示药典备注时间)
                //if (ret > 0 && dt.Rows.Count > 0)
                //{
                //    if (dt.Rows[0]["SETSTATUS_INT"].ToString().Trim() != "0")
                //    {
                //        ti = Convert.ToInt32(dt.Rows[0]["SETSTATUS_INT"]);
                //    }
                //}
                string s = this.m_strReadXML("register", "MedInfoRefreshTime", "AnyOne");
                if (s.Trim() != "")
                {
                    ti = Convert.ToInt32(s);
                }

                return ti;
            }
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
        //private void m_mthGetmedpurview()
        //{
        //    DataTable dt;
        //    long ret = objSvc.m_lngGetWSParm("0049", out dt);		//0049 毒麻精神药品权限

        //    if (ret > 0 && dt.Rows.Count > 0)
        //    {
        //        Medpurview = Convert.ToInt32(dt.Rows[0]["SETSTATUS_INT"]);
        //    }
        //}
        #endregion

        #region 获取补登记患者信息设置
        ///// <summary>
        ///// 获取补登记患者信息设置
        ///// </summary>
        //private void m_mthGetregpatinfo()
        //{
        //    DataTable dt;
        //    long ret = objSvc.m_lngGetWSParm("0050", out dt);		//0050 获取补登记患者信息设置 

        //    if (ret > 0 && dt.Rows.Count > 0)
        //    {
        //        Isregpatinfo = Convert.ToInt32(dt.Rows[0]["SETSTATUS_INT"]);
        //    }
        //}
        #endregion

        #region 门诊医生工作站关联项目带出时缺药限制
        /// <summary>
        /// 门诊医生工作站关联项目带出时缺药限制 false-缺药时子项目不带出 true-缺药时子项目带出，但给出缺药提示信息
        /// </summary>
        private bool Noqtyflag = false;
        /// <summary>
        /// 门诊医生工作站关联项目带出时缺药限制 0-缺药时子项目不带出 1-缺药时子项目带出，但给出缺药提示信息
        /// </summary>
        //private void m_mthGetmednoqtyflag()
        //{
        //    DataTable dt;
        //    long ret = objSvc.m_lngGetWSParm("0051", out dt);		//0051 门诊医生工作站关联项目带出时缺药限制 

        //    if (ret > 0 && dt.Rows.Count > 0)
        //    {
        //        if (dt.Rows[0]["SETSTATUS_INT"].ToString() == "0")
        //        {
        //            Noqtyflag = false;
        //        }
        //        else if (dt.Rows[0]["SETSTATUS_INT"].ToString() == "1")
        //        {
        //            Noqtyflag = true;
        //        }
        //    }
        //}
        #endregion

        #region 门诊医生工作站处方提交时是否重算费用
        /// <summary>
        /// 门诊医生工作站处方提交时是否重算费用 false 不计算 true 计算
        /// </summary>
        private bool Recalculateflag = false;
        /// <summary>
        /// 门诊医生工作站处方提交时是否重算费用 0 不计算 1 计算
        /// </summary>
        //private void m_mthGetrecalculateflag()
        //{
        //    DataTable dt;
        //    long ret = objSvc.m_lngGetWSParm("0052", out dt);		//0052 门诊医生工作站处方提交时是否重算费用

        //    if (ret > 0 && dt.Rows.Count > 0)
        //    {
        //        if (dt.Rows[0]["SETSTATUS_INT"].ToString() == "0")
        //        {
        //            Recalculateflag = false;
        //        }
        //        else if (dt.Rows[0]["SETSTATUS_INT"].ToString() == "1")
        //        {
        //            Recalculateflag = true;
        //        }
        //    }
        //}
        #endregion

        #region 检验、检查、手术治疗录入模式 0 收费项目 1 诊疗项目
        /// <summary>
        /// 检验、检查、手术治疗录入模式 0 收费项目 1 诊疗项目
        /// </summary>
        internal int ItemInputMode = 0;
        ///// <summary>
        ///// 检验、检查、手术治疗录入模式 0 收费项目 1 诊疗项目
        ///// </summary>
        //private void m_mthGetItemInputMode()
        //{
        //    DataTable dt;
        //    long ret = objSvc.m_lngGetWSParm("9000", out dt);		//9000 检验、检查、手术治疗录入模式 0 收费项目 1 诊疗项目

        //    if (ret > 0 && dt.Rows.Count > 0)
        //    {
        //        ItemInputMode = Convert.ToInt32(dt.Rows[0]["SETSTATUS_INT"]);
        //    }
        //}
        #endregion

        #region 手术申请
        /// <summary>
        /// 手术申请
        /// </summary>
        /// <param name="rowno"></param>
        /// <param name="chrgitemcode"></param>
        /// <param name="chrgitemname"></param>
        public void m_mthOPSApply(int rowno, string chrgitemcode, string chrgitemname)
        {
            if (this.m_objViewer.m_PatInfo.PatientID.Trim() != "")
            {
                clsOutops_VO objOutops_VO = new clsOutops_VO();
                objOutops_VO.pid = this.m_objViewer.m_PatInfo.PatientID;
                objOutops_VO.cardno = this.m_objViewer.m_PatInfo.PatientCardID;
                if (this.m_objViewer.btSave.Tag == null)
                {
                    objOutops_VO.recipeid = "";
                }
                else
                {
                    objOutops_VO.recipeid = this.m_objViewer.btSave.Tag.ToString();
                }
                objOutops_VO.name = this.m_objViewer.m_PatInfo.PatientName;
                objOutops_VO.sex = this.m_objViewer.m_PatInfo.PatientSex;
                objOutops_VO.age = this.m_objViewer.m_PatInfo.PatientAge;
                objOutops_VO.paytype = this.m_objViewer.m_PatInfo.PayTypeID;
                objOutops_VO.deptid = this.m_objViewer.m_PatInfo.CurrentDeptID;
                objOutops_VO.deptname = this.m_objViewer.m_PatInfo.CurrentDeptName;
                objOutops_VO.applydoctorID = this.m_objViewer.m_PatInfo.CurrentDoctorID;
                objOutops_VO.applydoctorname = this.m_objViewer.m_PatInfo.CurrentDoctorName;
                objOutops_VO.chrgitem = chrgitemcode;
                objOutops_VO.chrgname = chrgitemname;
                objOutops_VO.status = "0";

                frmOPSApply frmops = new frmOPSApply(objOutops_VO);
                frmops.ShowDialog();
                if (frmops.Opssave)
                {
                    objOutops_VO = frmops.clsOPS_VO;

                    if (rowno < 0)
                    {
                        int row5 = this.m_objViewer.ctlDataGrid5.RowCount;
                        DataTable dtRecord = new DataTable();
                        long ret = objSvc.m_mthFindOPSChargeByID(objOutops_VO.chrgitem, objOutops_VO.paytype, out dtRecord);
                        if (ret > 0 && dtRecord.Rows.Count == 1)
                        {
                            this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid5[row5, o_RowNo] = 3000;
                            this.m_objViewer.ctlDataGrid5[row5, o_appflag] = "T";
                            this.m_mthFillDataGridByRow5(dtRecord.Rows[0], row5);
                            this.m_mthCalculateTotalMoney();
                            this.m_objViewer.tabControl1.SelectedIndex = 7;
                            this.m_mthSetFocus();
                            rowNo = row5;
                        }
                    }
                    else
                    {
                        this.m_objViewer.ctlDataGrid5[rowno, o_appflag] = "T";
                    }

                    OPSApplyarr.Add(objOutops_VO);
                }
            }
            else
            {
                frmOPSApply frmops = new frmOPSApply();
                frmops.ShowDialog();
            }
        }
        #endregion

        #region 动态显示保存/确认成功窗口
        /// <summary>
        /// 动态显示保存/确认成功窗口
        /// </summary>
        /// <param name="info"></param>
        public void m_mthShowsavemsg(string info)
        {
            frmSavemsg fs = new frmSavemsg(info);
            fs.StartPosition = FormStartPosition.Manual;
            fs.Location = new Point(862, 628);
            fs.Show();
        }
        #endregion

        #region 获取检验申请单元
        /// <summary>
        /// 获取检验申请单元
        /// </summary>
        /// <returns></returns>
        public string[] m_strGetapplyunit()
        {
            string[] appunit = null;
            string chrgitemid = "";
            string appitemid = "";
            dtApply = null;

            DataRow dr;
            dtApply = new DataTable();
            dtApply.Columns.Add("chrgitemid", typeof(string));
            dtApply.Columns.Add("appitemid", typeof(string));

            Hashtable has = new Hashtable();

            for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim() != "" && this.m_objViewer.ctlDataGrid3[i, t_ItemID] != null)
                {
                    chrgitemid = this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim();
                    if (!has.ContainsKey(chrgitemid))
                    {
                        appitemid = objSvc.m_mthGetResourceIDByItemID(chrgitemid);
                        has.Add(chrgitemid, appitemid);

                        dr = dtApply.NewRow();
                        dr[0] = chrgitemid;
                        dr[1] = appitemid;
                        dtApply.Rows.Add(dr);
                    }
                }
            }

            if (has.Count > 0)
            {
                ArrayList ar = new ArrayList();
                ar.AddRange(has.Values);
                appunit = (string[])ar.ToArray(typeof(string));
            }

            return appunit;
        }
        #endregion

        #region 重算(主要针对检验->项目带项目)
        /// <summary>
        /// 重算(主要针对检验->项目带项目)
        /// </summary>
        public void m_mthRecalculate()
        {
            if (this.m_objViewer.m_PatInfo.PatientID == null || this.m_objViewer.m_PatInfo.PatientID.Trim() == "")
            {
                return;
            }

            string[] appitemarr = this.m_strGetapplyunit();
            if (appitemarr == null || appitemarr.Length == 0)
            {
                return;
            }

            ArrayList Itemidarr = clsLIS_ApplyUnitsCarver.m_mthMakeResult(appitemarr);
            if (Itemidarr == null || Itemidarr.Count == 0)
            {
                return;
            }

            //强行转换到检验页面(Datagrid存在BUG, 以便带出手术治疗项目)
            if (this.m_objViewer.tabControl1.SelectedIndex == 7 || this.m_objViewer.tabControl1.SelectedIndex == 8)
            {
                this.m_objViewer.tabControl1.SelectedIndex = 5;
            }

            for (int i = 0; i < Itemidarr.Count; i++)
            {
                ArrayList id = new ArrayList();
                ArrayList num = new ArrayList();
                ArrayList location = new ArrayList();
                string[] itemarr = (string[])Itemidarr[i];

                for (int j = 0; j < itemarr.Length; j++)
                {
                    string appid = itemarr[j].ToString().Trim();
                    DataRow[] dr = dtApply.Select("appitemid = '" + appid + "'");
                    for (int m = 0; m < dr.Length; m++)
                    {
                        string chrgid = dr[m]["chrgitemid"].ToString();

                        for (int k = 0; k < this.m_objViewer.ctlDataGrid3.RowCount; k++)
                        {
                            if (this.m_objViewer.ctlDataGrid3[k, t_ItemID].ToString().Trim() == chrgid)
                            {
                                string ReItemID = this.m_objViewer.ctlDataGrid3[k, t_resubitem].ToString().Trim();
                                if (ReItemID.StartsWith("[PK]"))
                                {
                                    m_mthGetChargeItemByItem(ReItemID.Replace("[PK]", ""), -1, null);

                                    id.Add(chrgid);
                                    num.Add(m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[k, t_Count]));
                                    location.Add(k);
                                    break;
                                }
                            }
                        }
                    }
                }

                //找出同组中最大数量的项目来带出附加项目
                if (id.Count > 0)
                {
                    int pos = 0;
                    decimal val = 0;
                    decimal tmp = 0;
                    for (int l = 0; l < id.Count; l++)
                    {
                        tmp = (decimal)num[l];
                        if (val < tmp)
                        {
                            val = tmp;
                            pos = l;
                        }
                    }

                    int row = Convert.ToInt32(location[pos]);
                    DataTable dtRecord = new DataTable();
                    bool blnStat = objSvc.m_blnCheckSubChargeItem(id[pos].ToString(), out dtRecord);
                    if (blnStat)
                    {
                        m_mthGetChargeItemByItem(row.ToString() + "->" + id[pos].ToString(), 0, dtRecord);
                        m_mthCheckMainItemNum(this.m_objViewer.ctlDataGrid3[row, t_resubitem].ToString(), this.m_objViewer.ctlDataGrid3[row, t_MainItemNum].ToString(), val.ToString(), null);
                    }
                }
            }

            this.m_objViewer.tabControl1.SelectedIndex = 8;
        }
        #endregion

        #region 检查同一处方中是否同时包含：普通、毒类、麻类、精神一和二类药品
        /// <summary>
        /// 检查同一处方中是否同时包含：普通、毒类、麻类、精神一和二类药品
        /// 检查同一处方中是否同时包含：中草药、 西药、中成药
        /// </summary>
        /// <returns></returns>
        private bool m_blnCheckmedproperty(out string typeid)
        {
            typeid = "0";
            string itemid = "";
            Hashtable has = new Hashtable();

            //西药
            for (int i1 = 0; i1 < this.m_objViewer.ctlDataGrid1.RowCount; i1++)
            {
                itemid = this.m_objViewer.ctlDataGrid1[i1, c_ItemID].ToString().Trim();
                if (itemid != "")
                {
                    typeid = this.m_Getmedproperty(itemid, 1);
                    if (!has.ContainsKey(typeid))
                    {
                        has.Add(typeid, typeid);
                    }
                }
            }

            //中药
            for (int i2 = 0; i2 < this.m_objViewer.ctlDataGrid2.RowCount; i2++)
            {
                itemid = this.m_objViewer.ctlDataGrid2[i2, 8].ToString().Trim();
                if (itemid != "")
                {
                    typeid = this.m_Getmedproperty(itemid, 1);
                    if (!has.ContainsKey(typeid))
                    {
                        has.Add(typeid, typeid);
                    }
                }
            }

            string[] hintinfo = new string[5] { "普通", "毒性", "麻醉", "精神一类", "精神二类" };

            if (has.Count > 0)
            {
                string msg = "";
                string ent = "\r\n\r\n";
                for (int i = 0; i < 5; i++)
                {
                    bool b = has.ContainsKey(i.ToString());
                    if (b)
                    {
                        for (int j = i + 1; j < 5; j++)
                        {
                            bool c = has.ContainsKey(j.ToString());
                            if (c)
                            {
                                msg += hintinfo[i] + "药品和" + hintinfo[j] + "药品" + ent;
                            }
                        }
                    }
                }

                if (msg != "")
                {
                    MessageBox.Show("该处方中同时存在:" + ent + msg + ent + "请仔细检查。" + ent, "警告...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 检查同一处方中是否同时包含：中草药、 西药、中成药
        /// </summary>        
        /// <returns></returns>
        private bool m_blnCheckmedproperty()
        {
            if (MedPropertyLimit == 0)
            {
                return false;
            }

            SpeicalLimitMedpropertyID = SpeicalLimitMedpropertyID.Replace("；", ";").Trim();
            ArrayList MedIDArr;
            if (SpeicalLimitMedpropertyID != "")
            {
                MedIDArr = this.m_Gettoken(SpeicalLimitMedpropertyID, ";");
            }
            else
            {
                return false;
            }

            string itemid = "";
            string medid = "";
            Hashtable has = new Hashtable();

            //西药
            for (int i1 = 0; i1 < this.m_objViewer.ctlDataGrid1.RowCount; i1++)
            {
                itemid = this.m_objViewer.ctlDataGrid1[i1, c_ItemID].ToString().Trim();
                if (itemid != "")
                {
                    medid = this.m_Getmedproperty(itemid, 2);
                    //暂时简化处理
                    if (medid == "3" || medid == "4")
                    {
                        medid = "3+4";
                    }
                    if (!has.ContainsKey(medid))
                    {
                        has.Add(medid, medid);
                    }
                }
            }

            //中药
            for (int i2 = 0; i2 < this.m_objViewer.ctlDataGrid2.RowCount; i2++)
            {
                itemid = this.m_objViewer.ctlDataGrid2[i2, 8].ToString().Trim();
                if (itemid != "")
                {
                    medid = this.m_Getmedproperty(itemid, 2);
                    //暂时简化处理
                    if (medid == "3" || medid == "4")
                    {
                        medid = "3+4";
                    }
                    if (!has.ContainsKey(medid))
                    {
                        has.Add(medid, medid);
                    }
                }
            }

            if (has.Count > 0)
            {
                int jsq = 0;
                string msg = "";

                for (int i = 0; i < MedIDArr.Count; i++)
                {
                    medid = MedIDArr[i].ToString();

                    if (has.ContainsKey(medid))
                    {
                        string s = "";
                        if (medid == "1")
                        {
                            s = "中草药";
                        }
                        else if (medid == "2")
                        {
                            s = "西药";
                        }
                        else if (medid == "3+4")
                        {
                            s = "中成药";
                        }
                        else
                        {
                            s = "其他药";
                        }

                        jsq++;

                        if (jsq == 1)
                        {
                            msg = s;
                        }
                        else
                        {
                            msg += " 与 " + s;
                        }
                    }
                }

                if (jsq > 1)
                {
                    if (MedPropertyLimit == 1)
                    {
                        if (MessageBox.Show("根据国家卫生部、国家中医医管理局制订的《处方管理办法（试行）》中“第十条码 处方书写必须符合下列规则：（五）西药、中成药、中药饮片要分别开具处方。” \r\n\r\n该处方中同时存在: " + msg + "\r\n\r\n是否继续保存处方？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        {
                            return true;
                        }
                    }
                    if (MedPropertyLimit == 2)
                    {
                        MessageBox.Show("根据国家卫生部、国家中医医管理局制订的《处方管理办法（试行）》中“第十条码 处方书写必须符合下列规则：（五）西药、中成药、中药饮片要分别开具处方。” \r\n\r\n该处方中同时存在: " + msg + "\r\n\r\n请仔细检查。", "警告...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// 返回药品属性
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="flag">1 返回：0 普通；1 毒性；2 麻醉；3 精神一类；4 精神二类； 2 返回：1 中草药 2 西药 3 中成中 4 中成西</param>
        /// <returns></returns>
        private string m_Getmedproperty(string itemid, int flag)
        {
            DataTable dt = new DataTable();

            long ret = objSvc.m_lngGetmedproperty(itemid, out dt);
            if (ret > 0 && dt.Rows.Count == 1)
            {
                if (flag == 1)
                {
                    string a = dt.Rows[0]["ispoison_chr"].ToString().Trim().ToUpper();
                    string b = dt.Rows[0]["isanaesthesia_chr"].ToString().Trim().ToUpper();
                    string c = dt.Rows[0]["ischlorpromazine_chr"].ToString().Trim().ToUpper();
                    string d = dt.Rows[0]["ischlorpromazine2_chr"].ToString().Trim().ToUpper();

                    if (a == "T")
                    {
                        return "1";
                    }

                    if (b == "T")
                    {
                        return "2";
                    }

                    if (c == "T")
                    {
                        return "3";
                    }

                    if (d == "T")
                    {
                        return "4";
                    }
                }
                else if (flag == 2)
                {
                    return dt.Rows[0]["medicinetypeid_chr"].ToString().Trim();
                }
            }

            return "0";
        }
        #endregion

        #region LoginFile.XML读写操作
        /// <summary>
        /// 读操作
        /// </summary>
        /// <param name="parentnode"></param>
        /// <param name="childnode"></param>
        /// <param name="key"></param>
        public string m_strReadXML(string parentnode, string childnode, string key)
        {
            string strRet = "";

            try
            {
                if (File.Exists(XMLFile))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(XMLFile);

                    XmlNode xndP = xdoc.DocumentElement.SelectNodes(@"//" + parentnode)[0];
                    XmlNode xndC = xndP.SelectSingleNode(@"//" + childnode + @"[@key='" + key + @"']");

                    if (xndP != null)
                    {
                        strRet = xndC.Attributes["value"].Value.ToString().Trim();
                    }
                }
            }
            catch
            {
                strRet = "";
            }
            return strRet;
        }

        /// <summary>
        /// 写操作
        /// </summary>
        /// <param name="parentnode"></param>
        /// <param name="childnode"></param>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public bool m_blnWriteXML(string parentnode, string childnode, string key, string val)
        {
            bool blnRet = false;
            try
            {
                if (File.Exists(XMLFile))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(XMLFile);

                    XmlNode xndP = xdoc.DocumentElement.SelectNodes(@"//" + parentnode)[0];
                    XmlNode xndC = xndP.SelectSingleNode(@"//" + childnode + @"[@key='" + key + @"']");

                    if (xndP != null && xndC != null)
                    {
                        xndC.Attributes["value"].Value = val;
                        xdoc.Save(XMLFile);
                        blnRet = true;
                    }
                }
            }
            catch
            {
                blnRet = false;
            }
            return blnRet;
        }
        #endregion

        #region 特病医保时检验处方数据的有效性
        /// <summary>
        /// 特病医保时检验处方数据的有效性
        /// </summary>
        /// <returns></returns>
        public bool m_blnCheckYBSpecialDeaChargeItem()
        {
            //if (this.m_objViewer.cmbRecipeType.SelectedIndex != this.YBSpecialRecTypeID)
            //{
            //    MessageBox.Show("请注意：当前患者是特种病医保，请选择相应的处方类(如：特定处方)。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    return false;
            //}

            if (this.m_objViewer.objCaseHistory.ICD10 == null || this.m_objViewer.objCaseHistory.ICD10.Count == 0)
            {
                MessageBox.Show("请注意：当前患者是特种病医保，请在病历下方录入ICD10。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            ArrayList arrDeaCode = new ArrayList();
            ArrayList arrItemID = new ArrayList();
            ArrayList arrICD10 = this.m_objViewer.objCaseHistory.ICD10;
            Hashtable hasdea = new Hashtable();

            for (int i = 0; i < arrICD10.Count; i++)
            {
                clsICD10_VO icd10 = (clsICD10_VO)arrICD10[i];
                DataTable dt;
                long l = this.objSvc.m_lngGetYBSpeciaTypeDiseaseByICD10(icd10.strICDCODE_VCHR, out dt);
                if (l > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        string deacode = dt.Rows[j]["deacode_chr"].ToString();
                        if (hasdea.ContainsKey(deacode))
                        {
                            continue;
                        }
                        arrDeaCode.Add(deacode);
                        hasdea.Add(deacode, null);
                    }
                }
                else
                {
                    MessageBox.Show("特种病医保ICD10数据维护错误。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            if (arrDeaCode.Count == 0)
            {
                MessageBox.Show("请注意：当前患者是特种病医保，但病历下方的ICD10没有对应的医保特种疾病，请仔细检查。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            for (int i = 0; i < arrDeaCode.Count; i++)
            {
                string deacode = arrDeaCode[i].ToString();
                DataTable dt;
                long l = this.objSvc.m_lngGetYBSpecChargeItemByDeacode(deacode, out dt);
                if (l > 0)
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        arrItemID.Add(dt.Rows[j]["itemid_chr"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("特种病医保收费项目数据维护错误。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            }

            //收费项目维护为空，默认为不判断
            if (arrItemID.Count > 0)
            {
                string itemid = "";
                ArrayList MedList = new ArrayList();

                for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
                {
                    itemid = this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString();
                    if (arrItemID.IndexOf(itemid) < 0)
                    {
                        MedList.Add("西药栏: " + this.m_objViewer.ctlDataGrid1[i, c_Name].ToString());
                    }
                }

                for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
                {
                    itemid = this.m_objViewer.ctlDataGrid2[i, 8].ToString();
                    if (arrItemID.IndexOf(itemid) < 0)
                    {
                        MedList.Add("中药栏: " + this.m_objViewer.ctlDataGrid2[i, 3].ToString());
                    }
                }

                for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
                {
                    itemid = this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString();
                    if (arrItemID.IndexOf(itemid) < 0)
                    {
                        MedList.Add("检验栏: " + this.m_objViewer.ctlDataGrid3[i, t_Name].ToString());
                    }
                }

                for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
                {
                    itemid = this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString();
                    if (arrItemID.IndexOf(itemid) < 0)
                    {
                        MedList.Add("检查栏: " + this.m_objViewer.ctlDataGrid4[i, t_Name].ToString());
                    }
                }

                for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
                {
                    itemid = this.m_objViewer.ctlDataGrid5[i, o_ItemID].ToString();
                    if (arrItemID.IndexOf(itemid) < 0)
                    {
                        MedList.Add("手术/治疗栏: " + this.m_objViewer.ctlDataGrid5[i, o_Name].ToString());
                    }
                }

                for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
                {
                    itemid = this.m_objViewer.ctlDataGrid6[i, o_ItemID].ToString();
                    if (arrItemID.IndexOf(itemid) < 0)
                    {
                        MedList.Add("其他栏: " + this.m_objViewer.ctlDataGrid6[i, o_Name].ToString());
                    }
                }

                if (MedList.Count > 0)
                {
                    string msg = "下列药品(项目)不属于指定的特种病范围：";

                    for (int i = 0; i < MedList.Count; i++)
                    {
                        msg += "\r\n\r\n" + Convert.ToString(i + 1) + "、" + MedList[i].ToString().Trim();
                    }

                    msg += "\r\n\r\n请确认是否继续使用该批药品(项目)？";

                    if (MessageBox.Show(msg, "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region 药典备注信息
        /// <summary>
        /// 药典备注信息
        /// </summary>
        /// <param name="ItemID">药品代码</param>
        /// <param name="MedClass">药品分类 1 西药 2 中药</param>
        private void m_mthCodexRemarkInfo(string ItemID, int MedClass)
        {
            if (!IsShowCodexRemarkFrm)
            {
                return;
            }

            string Context, Remark;

            objSvc.m_mthGetMedicineInfo(ItemID, out Context, out Remark);

            if (frmRemark != null)
            {
                frmRemark = null;
            }

            if (Remark.Trim() != "")
            {
                frmRemark = new frmCodexRemark(Remark, ShowCodexRemarkFrmTimerinterval);
                frmRemark.StartPosition = FormStartPosition.Manual;
                if (MedClass == 1)
                {
                    frmRemark.Location = new Point(12, 580);
                }
                else if (MedClass == 2)
                {
                    frmRemark.Location = new Point(12, 540);
                }
                frmRemark.Show();
                this.m_objViewer.Focus();
            }
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

        #region 检查收费项目比例是否变动
        /// <summary>
        /// 检查收费项目比例是否变动
        /// </summary>
        public void m_mthCheckItemDiscount()
        {
            if (objCalPatientCharge == null)
            {
                return;
            }

            bool b = false;

            ArrayList objItemArr = new ArrayList();
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, c_RowNo] != null && this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid2[i, 9] != null && this.m_objViewer.ctlDataGrid2[i, 9].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid2[i, 8].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid3[i, t_RowNo] != null && this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid4[i, t_RowNo] != null && this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid5[i, 9] != null && this.m_objViewer.ctlDataGrid5[i, 9].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid5[i, 7].ToString().Trim());
                }
            }
            for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid6[i, 9] != null && this.m_objViewer.ctlDataGrid6[i, 9].ToString().Trim() != "")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid6[i, 7].ToString().Trim());
                }
            }

            Hashtable hasItemScale = new Hashtable();
            if (objItemArr.Count > 0)
            {
                //string[] strItemIDArr = new string[objItemArr.Count];
                //for (int i = 0; i < objItemArr.Count; i++)
                //{
                //    strItemIDArr[i] = objItemArr[i].ToString();
                //}
                string[] strItemIDArr = (string[])objItemArr.ToArray(typeof(string));

                this.objSvc.m_lngGetItemScaleByArr(this.m_objViewer.m_PatInfo.PayTypeID, strItemIDArr, ref hasItemScale);
            }

            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, c_RowNo] != null && this.m_objViewer.ctlDataGrid1[i, c_RowNo].ToString().Trim() != "")
                {
                    if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Discount]) != this.m_mthConvertObjToDecimal(hasItemScale[this.m_objViewer.ctlDataGrid1[i, c_ItemID].ToString().Trim()].ToString()))
                    {
                        b = true;
                        break;
                    }
                }
            }

            if (!b)
            {
                for (int i = 0; i < this.m_objViewer.ctlDataGrid2.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid2[i, 9] != null && this.m_objViewer.ctlDataGrid2[i, 9].ToString().Trim() != "")
                    {
                        if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid2[i, 11]) != this.m_mthConvertObjToDecimal(hasItemScale[this.m_objViewer.ctlDataGrid2[i, 8].ToString().Trim()].ToString()))
                        {
                            b = true;
                            break;
                        }
                    }
                }
            }

            if (!b)
            {
                for (int i = 0; i < this.m_objViewer.ctlDataGrid3.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid3[i, t_RowNo] != null && this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString().Trim() != "")
                    {
                        if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid3[i, t_Discount]) != this.m_mthConvertObjToDecimal(hasItemScale[this.m_objViewer.ctlDataGrid3[i, t_ItemID].ToString().Trim()].ToString()))
                        {
                            b = true;
                            break;
                        }
                    }
                }
            }

            if (!b)
            {
                for (int i = 0; i < this.m_objViewer.ctlDataGrid4.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid4[i, t_RowNo] != null && this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString().Trim() != "")
                    {
                        if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid4[i, t_Discount]) != this.m_mthConvertObjToDecimal(hasItemScale[this.m_objViewer.ctlDataGrid4[i, t_ItemID].ToString().Trim()].ToString()))
                        {
                            b = true;
                            break;
                        }
                    }
                }
            }

            if (!b)
            {
                for (int i = 0; i < this.m_objViewer.ctlDataGrid5.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid5[i, 9] != null && this.m_objViewer.ctlDataGrid5[i, 9].ToString().Trim() != "")
                    {
                        if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid5[i, 11]) != this.m_mthConvertObjToDecimal(hasItemScale[this.m_objViewer.ctlDataGrid5[i, 7].ToString().Trim()].ToString()))
                        {
                            b = true;
                            break;
                        }
                    }
                }
            }

            if (!b)
            {
                for (int i = 0; i < this.m_objViewer.ctlDataGrid6.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid6[i, 9] != null && this.m_objViewer.ctlDataGrid6[i, 9].ToString().Trim() != "")
                    {
                        if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid6[i, 11]) != this.m_mthConvertObjToDecimal(hasItemScale[this.m_objViewer.ctlDataGrid6[i, 7].ToString().Trim()].ToString()))
                        {
                            b = true;
                            break;
                        }
                    }
                }
            }

            //如果项目自付比例改变
            if (b)
            {
                this.m_mthPatientTypeChanged();
            }
        }
        #endregion

        #region 复用医生选择的处方项目
        /// <summary>
        /// 复用医生选择的处方项目
        /// </summary>
        /// <param name="hasItem"></param>
        public void m_mthReUseRecipeItem(Hashtable hasItem, Hashtable hasEntry)
        {
            this.m_objViewer.ctlDataGrid1.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid2.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid3.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid4.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid5.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGrid6.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridLis.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridTest.m_mthDeleteAllRow();
            this.m_objViewer.ctlDataGridOps.m_mthDeleteAllRow();
            hasOrderID = null;
            hasOrderID = new Hashtable();
            hasMedPiece = null;
            hasMedPiece = new Hashtable();

            //修改
            decimal temp = 100;
            decimal dosage = 0;

            int intTemp = 0;//主组合的行号
            int row = 0;
            string ItemID = "";
            string ItemSpec = "";
            string ItemUnit = "";
            string ItemPrice = "";

            // 获取药房
            string wmedStoreId = this.m_strGetDurgStoreID(this.m_strReadXML("register", "WMedicinestore", "AnyOne"));
            string cmedStoreId = this.m_strGetDurgStoreID(this.m_strReadXML("register", "CMedicinestore", "AnyOne"));

            #region 西药
            if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage5) && hasItem.ContainsKey("1"))
            {
                ArrayList ItemArr = hasItem["1"] as ArrayList;

                for (int i = 0; i < ItemArr.Count; i++)
                {
                    DataRow dr = ItemArr[i] as DataRow;

                    ItemID = dr["ITEMID_CHR"].ToString();

                    #region 库存判断
                    if (this.objSvc.IsHaveDrugStock(ItemID, wmedStoreId) == false)
                    {
                        MessageBox.Show(dr["ITEMNAME_VCHR"].ToString() + "，不能复用，原因：库存不足或停用。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                    #endregion

                    #region 西药项目调价等变动
                    ItemSpec = dr["spec"].ToString();
                    ItemUnit = dr["dosageunit"].ToString();
                    if (dr["opchargeflg_int"].ToString().Trim() == "0")//判断大小单位
                    {
                        ItemPrice = dr["ITEMPRICE_MNY"].ToString();
                    }
                    else
                    {
                        ItemPrice = dr["SubMoney"].ToString();
                    }
                    #endregion

                    row = this.m_objViewer.ctlDataGrid1.RowCount;
                    this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                    string strRowTemp = "";
                    if (dr["ROWNO_CHR"].ToString().Trim() == "0")
                    {
                        this.m_objViewer.ctlDataGrid1[row, 0] = "";
                        this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -4;
                    }
                    else
                    {
                        this.m_objViewer.ctlDataGrid1[row, c_GroupNo] = dr["ROWNO_CHR"].ToString().Trim();
                    }
                    if (row - 1 > -1)
                    {
                        strRowTemp = this.m_objViewer.ctlDataGrid1[row - 1, c_GroupNo].ToString().Trim();

                    }
                    if (strRowTemp == "")
                    {
                        strRowTemp = "0";
                    }
                    if (strRowTemp == dr["ROWNO_CHR"].ToString().Trim())
                    {
                        if (dr["ROWNO_CHR"].ToString().Trim() != "0")
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_IsMain] = intTemp;
                        }
                        else
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -4;
                        }
                    }
                    else
                    {
                        intTemp = i;
                        this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -1;
                    }

                    this.m_objViewer.ctlDataGrid1[row, c_Find] = dr["ITEMCODE_VCHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_Count] = m_mthConvertObjToDecimal(dr["QTY_DEC"]);
                    dosage = m_mthConvertObjToDecimal(dr["TOLQTY_DEC"]);
                    this.m_objViewer.ctlDataGrid1[row, c_Unit] = ItemUnit;
                    this.m_objViewer.ctlDataGrid1[row, c_Name] = dr["ITEMNAME_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Spec] = ItemSpec;
                    this.m_objViewer.ctlDataGrid1[row, c_UsageName] = dr["USAGENAME_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_FreName] = dr["FREQNAME_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Day] = m_mthConvertObjToDecimal(dr["DAYS_INT"]);
                    this.m_objViewer.ctlDataGrid1[row, c_Price] = m_mthConvertObjToDecimal(ItemPrice);
                    this.m_objViewer.ctlDataGrid1[row, c_BigUnit] = dr["UNITID_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_SumMoney] = m_mthConvertObjToDecimal(dr["TOLPRICE_MNY"]);
                    this.m_objViewer.ctlDataGrid1[row, c_ItemID] = dr["ITEMID_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Packet] = m_mthConvertObjToDecimal(dr["PACKQTY_DEC"]);
                    this.m_objViewer.ctlDataGrid1[row, c_Total] = m_mthConvertObjToDecimal(dr["TOLQTY_DEC"]);
                    this.m_objViewer.ctlDataGrid1[row, c_FreDays] = m_mthConvertObjToDecimal(dr["DAYS"]);
                    this.m_objViewer.ctlDataGrid1[row, c_FreTimes] = m_mthConvertObjToDecimal(dr["TIMES_INT"]);
                    this.m_objViewer.ctlDataGrid1[row, c_UsageID] = dr["USAGEID_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_FreID] = dr["FREQID_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_UnitFlag] = dr["opchargeflg_int"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_Dosage] = dr["DOSAGE_DEC"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_EnglishName] = dr["itemengname_vchr"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_PS] = dr["HYPETEST_INT"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_PSFlag] = dr["HYPE_INT"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_UsageDetail] = dr["DESC_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_IsCal] = 1;
                    this.m_objViewer.ctlDataGrid1[row, c_SubItemID] = dr["USAGEPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_resubitem] = dr["ATTACHPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid1[row, c_MainItemNum] = m_mthConvertObjToDecimal(dr["attachitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid1[row, c_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid1[row, c_intDiffUnitPrice] = dr["TRADEPRICE_MNY"].ToString().Trim();    // 项目批发价
                    this.m_objViewer.ctlDataGrid1[row, c_intDiffUnitPrice] = dr["SUBTRADEMONEY"].ToString().Trim();     // 项目单位批发价
                    temp = 100;
                    temp = m_mthConvertObjToDecimal(dr["DISCOUNT_DEC"].ToString());
                    this.m_objViewer.ctlDataGrid1[row, c_DiscountName] = temp.ToString() + "%";
                    this.m_objViewer.ctlDataGrid1[row, c_Discount] = temp;
                    decimal price = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_Price]);
                    int int_Temp = objCalPatientCharge.m_mthGetChargeIetmPrice(dr["ITEMID_CHR"].ToString(), price,
                    dr["ITEMOPINVTYPE_CHR"].ToString().Trim(), dosage, 3000, temp, "", false);
                    this.m_objViewer.ctlDataGrid1[row, c_RowNo] = int_Temp;
                    if (Isdeptmed)
                    {
                        this.m_objViewer.ctlDataGrid1[row, c_DeptmedID] = dr["deptmed_int"].ToString();
                        if (dr["deptmed_int"].ToString() == "1")
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_Deptmed] = "是";
                            this.m_objViewer.ctlDataGrid1.m_mthSetRowColor(row, dfc, dbc);
                        }
                    }
                }
            }
            #endregion

            #region 中药明细
            if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage6) && hasItem.ContainsKey("2"))
            {
                ArrayList ItemArr = hasItem["2"] as ArrayList;

                for (int i = 0; i < ItemArr.Count; i++)
                {
                    DataRow dr = ItemArr[i] as DataRow;

                    ItemID = dr["itemid"].ToString();

                    #region 库存判断
                    if (this.objSvc.IsHaveDrugStock(ItemID, cmedStoreId) == false && this.m_objViewer.cboProxyBoilMed.SelectedIndex == 0)
                    {
                        MessageBox.Show(dr["ITEMNAME_VCHR"].ToString() + "，不能复用，原因：库存不足或停用。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        continue;
                    }
                    #endregion

                    #region 中药项目调价等变动
                    ItemSpec = dr["spec"].ToString();
                    ItemUnit = dr["DOSAGEUNIT"].ToString();
                    ItemPrice = dr["SubMoney"].ToString();
                    #endregion

                    row = this.m_objViewer.ctlDataGrid2.RowCount;
                    this.m_objViewer.ctlDataGrid2.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid2[row, 0] = dr["ITEMCODE_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 1] = m_mthConvertObjToDecimal(dr["MIN_QTY_DEC"]);
                    this.m_objViewer.ctlDataGrid2[row, 2] = ItemUnit;
                    this.m_objViewer.ctlDataGrid2[row, 3] = dr["ITEMNAME"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 4] = ItemSpec;
                    this.m_objViewer.ctlDataGrid2[row, 5] = dr["USAGENAME_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 6] = m_mthConvertObjToDecimal(ItemPrice);
                    this.m_objViewer.ctlDataGrid2[row, 7] = m_mthConvertObjToDecimal(dr["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid2[row, 8] = dr["ITEMID"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 12] = m_mthConvertObjToDecimal(dr["DOSAGE_DEC"]);
                    this.m_objViewer.ctlDataGrid2[row, 13] = m_mthConvertObjToDecimal(dr["MAXDOSAGE_DEC"]);
                    this.m_objViewer.ctlDataGrid2[row, 14] = m_mthConvertObjToDecimal(dr["MINDOSAGE_DEC"]);
                    //this.m_objViewer.ctlDataGrid2[row,15]=m_mthConvertObjToDecimal(dr["QUANTITY"]);
                    this.m_objViewer.ctlDataGrid2[row, 16] = dr["itemprice_mny"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 17] = dr["OPCHARGEFLG_INT"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 18] = dr["PACKQTY_DEC"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 19] = dr["ROWNO_CHR"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 20] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid2[row, 21] = dr["USAGEID_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid2[row, 24] = dr["itemengname_vchr"].ToString();
                    this.m_objViewer.ctlDataGrid2[row, 31] = dr["SUBTRADEMONEY"].ToString().Trim();         // 单位批发价
                    this.m_objViewer.ctlDataGrid2[row, 32] = dr["TRADEPRICE_MNY"].ToString().Trim();        // 大批发价
                    this.m_objViewer.cmbCooking.Text = dr["SUMUSAGE_VCHR"].ToString();
                    temp = 100;
                    temp = m_mthConvertObjToDecimal(dr["DISCOUNT_DEC"].ToString());
                    this.m_objViewer.ctlDataGrid2[row, 10] = temp.ToString() + "%";
                    this.m_objViewer.ctlDataGrid2[row, 11] = temp;
                    //this.m_objViewer.numericUpDown1.Value=m_mthConvertObjToDecimal(dr["Times"]);
                    this.m_objViewer.ctlDataGrid2[row, 9] = "-1";
                    this.m_objViewer.ctlDataGrid2[row, cm_UsageDetail] = dr["UsageDetail_vchr"].ToString();

                    if (Isdeptmed)
                    {
                        this.m_objViewer.ctlDataGrid2[row, cm_DeptmedID] = dr["deptmed_int"].ToString();
                        if (dr["deptmed_int"].ToString() == "1")
                        {
                            this.m_objViewer.ctlDataGrid2[row, cm_Deptmed] = "是";
                            this.m_objViewer.ctlDataGrid2.m_mthSetRowColor(row, dfc, dbc);
                        }
                    }

                    m_mthCalculateAmount2(i);
                    //this.m_objViewer.ctlDataGrid2[i,8]=objCalPatientCharge.m_mthGetChargeIetmPrice(dr["ITEMID"].ToString(),m_mthConvertObjToDecimal(dr["PRICE"]),"",m_mthConvertObjToDecimal(dr["MIN_QTY_DEC"])*m_mthConvertObjToDecimal(dr["Times"]),3000,temp,"");
                    this.m_objViewer.numericUpDown1.Value = m_mthConvertObjToDecimal(dr["Times"]);
                }
            }
            #endregion

            if (ItemInputMode == 0)
            {
                #region 检验
                if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage7) && hasItem.ContainsKey("3"))
                {
                    ArrayList ItemArr = hasItem["3"] as ArrayList;

                    for (int i = 0; i < ItemArr.Count; i++)
                    {
                        DataRow dr = ItemArr[i] as DataRow;

                        ItemID = dr["itemid"].ToString();

                        #region 检验项目调价等变动
                        ItemSpec = dr["spec"].ToString();
                        ItemUnit = dr["itemunit_chr"].ToString();
                        ItemPrice = dr["itemprice_mny"].ToString();
                        #endregion

                        row = this.m_objViewer.ctlDataGrid3.RowCount;
                        this.m_objViewer.ctlDataGrid3.m_mthAppendRow();
                        this.m_objViewer.ctlDataGrid3[row, t_Find] = dr["ITEMCODE_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid3[row, t_Count] = m_mthConvertObjToDecimal(dr["quantity"]);
                        this.m_objViewer.ctlDataGrid3[row, t_Name] = dr["ITEMNAME"].ToString();
                        this.m_objViewer.ctlDataGrid3[row, t_Spec] = ItemSpec;
                        this.m_objViewer.ctlDataGrid3[row, t_Unit] = ItemUnit;
                        this.m_objViewer.ctlDataGrid3[row, t_Price] = m_mthConvertObjToDecimal(ItemPrice);
                        this.m_objViewer.ctlDataGrid3[row, t_SumMoney] = m_mthConvertObjToDecimal(dr["SUMMONEY"]);
                        this.m_objViewer.ctlDataGrid3[row, t_ItemID] = dr["ITEMID"].ToString();
                        this.m_objViewer.ctlDataGrid3[row, t_PriceFlag] = dr["SELFDEFINE"].ToString();
                        this.m_objViewer.ctlDataGrid3[row, t_PartName] = dr["sample_type_desc_vchr"].ToString();
                        this.m_objViewer.ctlDataGrid3[row, t_Temp] = dr["sampleid_vchr"].ToString();
                        this.m_objViewer.ctlDataGrid3[row, t_OtherItemID] = dr["USAGEPARENTID_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid3[row, t_OtherCount] = m_mthConvertObjToDecimal(dr["usageitembasenum_dec"]);
                        this.m_objViewer.ctlDataGrid3[row, t_resubitem] = dr["ATTACHPARENTID_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid3[row, t_MainItemNum] = m_mthConvertObjToDecimal(dr["attachitembasenum_dec"]);
                        this.m_objViewer.ctlDataGrid3[row, t_UsageDetail] = dr["itemusagedetail_vchr"].ToString();

                        temp = 100;
                        temp = m_mthConvertObjToDecimal(dr["DISCOUNT_DEC"].ToString());
                        this.m_objViewer.ctlDataGrid3[row, t_DiscountName] = temp.ToString() + "%";
                        this.m_objViewer.ctlDataGrid3[row, t_Discount] = temp;
                        this.m_objViewer.ctlDataGrid3[row, t_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                        this.m_objViewer.ctlDataGrid3[row, t_EnglishName] = dr["itemengname_vchr"].ToString().Trim();
                        this.m_objViewer.ctlDataGrid3[row, t_ApplyId] = "";
                        this.m_objViewer.ctlDataGrid3[row, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dr["ITEMID"].ToString(),
                        m_mthConvertObjToDecimal(dr["PRICE"]), dr["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dr["quantity"]), 3000, temp, "", false);

                        this.m_objViewer.ctlDataGrid3[row, t_quickid] = dr["QUICKFLAG_INT"].ToString().Trim();
                        if (dr["QUICKFLAG_INT"].ToString().Trim() == "1")
                        {
                            this.m_objViewer.ctlDataGrid3[row, t_quick] = "是";
                            this.m_objViewer.ctlDataGrid3.m_mthSetRowColor(row, Color.FromArgb(255, 255, 255), Color.FromArgb(250, 89, 69));
                        }
                    }
                }
                #endregion

                #region 检查
                if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage8) && hasItem.ContainsKey("4"))
                {
                    ArrayList ItemArr = hasItem["4"] as ArrayList;

                    for (int i = 0; i < ItemArr.Count; i++)
                    {
                        DataRow dr = ItemArr[i] as DataRow;

                        ItemID = dr["itemid"].ToString();

                        #region 检查项目调价等变动
                        ItemSpec = dr["spec"].ToString();
                        ItemUnit = dr["itemunit_chr"].ToString();
                        ItemPrice = dr["itemprice_mny"].ToString();
                        #endregion

                        row = this.m_objViewer.ctlDataGrid4.RowCount;
                        this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                        this.m_objViewer.ctlDataGrid4[row, t_Find] = dr["ITEMCODE_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid4[row, t_Count] = m_mthConvertObjToDecimal(dr["quantity"]);
                        this.m_objViewer.ctlDataGrid4[row, t_Name] = dr["ITEMNAME"].ToString();
                        this.m_objViewer.ctlDataGrid4[row, t_Spec] = ItemSpec;
                        this.m_objViewer.ctlDataGrid4[row, t_Unit] = ItemUnit;
                        this.m_objViewer.ctlDataGrid4[row, t_Price] = m_mthConvertObjToDecimal(ItemPrice);
                        this.m_objViewer.ctlDataGrid4[row, t_SumMoney] = m_mthConvertObjToDecimal(dr["SUMMONEY"]);
                        this.m_objViewer.ctlDataGrid4[row, t_ItemID] = dr["ITEMID"].ToString();
                        this.m_objViewer.ctlDataGrid4[row, t_PriceFlag] = dr["SELFDEFINE"].ToString();
                        this.m_objViewer.ctlDataGrid4[row, t_PartName] = dr["partname"].ToString();
                        this.m_objViewer.ctlDataGrid4[row, t_Temp] = dr["CHECKPARTID_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid4[row, t_OtherItemID] = dr["USAGEPARENTID_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid4[row, t_OtherCount] = m_mthConvertObjToDecimal(dr["usageitembasenum_dec"]);
                        this.m_objViewer.ctlDataGrid4[row, t_resubitem] = dr["ATTACHPARENTID_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid4[row, t_MainItemNum] = m_mthConvertObjToDecimal(dr["attachitembasenum_dec"]);
                        this.m_objViewer.ctlDataGrid4[row, t_UsageDetail2] = dr["itemusagedetail_vchr"].ToString();
                        this.m_objViewer.ctlDataGrid4[row, t_UsageID] = dr["usageid_chr"].ToString();

                        temp = 100;
                        temp = m_mthConvertObjToDecimal(dr["DISCOUNT_DEC"].ToString());
                        this.m_objViewer.ctlDataGrid4[row, t_DiscountName] = temp.ToString() + "%";
                        this.m_objViewer.ctlDataGrid4[row, t_Discount] = temp;
                        this.m_objViewer.ctlDataGrid4[row, t_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                        this.m_objViewer.ctlDataGrid4[row, t_EnglishName] = dr["itemengname_vchr"].ToString().Trim();
                        this.m_objViewer.ctlDataGrid4[row, t_ApplyId] = "";
                        this.m_objViewer.ctlDataGrid4[row, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dr["ITEMID"].ToString(),
                        m_mthConvertObjToDecimal(dr["PRICE"]), dr["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dr["quantity"]), 3000, temp, "", false);
                    }
                }
                #endregion

                #region 手术治疗
                if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage9) && hasItem.ContainsKey("5"))
                {
                    ArrayList ItemArr = hasItem["5"] as ArrayList;

                    for (int i = 0; i < ItemArr.Count; i++)
                    {
                        DataRow dr = ItemArr[i] as DataRow;

                        ItemID = dr["itemid"].ToString();

                        #region 手术治疗项目调价等变动
                        ItemSpec = dr["spec"].ToString();
                        ItemUnit = dr["itemunit_chr"].ToString();
                        ItemPrice = dr["itemprice_mny"].ToString();
                        #endregion

                        row = this.m_objViewer.ctlDataGrid5.RowCount;
                        this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                        this.m_objViewer.ctlDataGrid5[row, o_Find] = dr["ITEMCODE_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid5[row, o_Count] = m_mthConvertObjToDecimal(dr["quantity"]);
                        this.m_objViewer.ctlDataGrid5[row, o_Name] = dr["ITEMNAME"].ToString();
                        this.m_objViewer.ctlDataGrid5[row, o_Spec] = ItemSpec;
                        this.m_objViewer.ctlDataGrid5[row, o_Unit] = ItemUnit;
                        this.m_objViewer.ctlDataGrid5[row, o_Price] = m_mthConvertObjToDecimal(ItemPrice);
                        this.m_objViewer.ctlDataGrid5[row, o_SumMoney] = m_mthConvertObjToDecimal(dr["SUMMONEY"]);
                        this.m_objViewer.ctlDataGrid5[row, o_ItemID] = dr["ITEMID"].ToString();
                        this.m_objViewer.ctlDataGrid5[row, o_PriceFlag] = dr["SELFDEFINE"].ToString();
                        this.m_objViewer.ctlDataGrid5[row, o_OtherItemID] = dr["USAGEPARENTID_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid5[row, o_OtherCount] = m_mthConvertObjToDecimal(dr["usageitembasenum_dec"]);
                        this.m_objViewer.ctlDataGrid5[row, o_resubitem] = dr["ATTACHPARENTID_VCHR"].ToString();
                        this.m_objViewer.ctlDataGrid5[row, o_MainItemNum] = m_mthConvertObjToDecimal(dr["attachitembasenum_dec"]);
                        this.m_objViewer.ctlDataGrid5[row, o_UsageDetail] = dr["itemusagedetail_vchr"].ToString();
                        this.m_objViewer.ctlDataGrid5[row, o_UsageID] = dr["usageid_chr"].ToString();

                        temp = 100;
                        temp = m_mthConvertObjToDecimal(dr["DISCOUNT_DEC"].ToString());
                        this.m_objViewer.ctlDataGrid5[row, o_DiscountName] = temp.ToString() + "%";
                        this.m_objViewer.ctlDataGrid5[row, o_Discount] = temp;
                        this.m_objViewer.ctlDataGrid5[row, o_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                        this.m_objViewer.ctlDataGrid5[row, o_EnglishName] = dr["itemengname_vchr"].ToString().Trim();
                        this.m_objViewer.ctlDataGrid5[row, o_ApplyId] = "";
                        this.m_objViewer.ctlDataGrid5[row, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dr["ITEMID"].ToString(),
                        m_mthConvertObjToDecimal(dr["PRICE"]), dr["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dr["quantity"]), 3000, temp, "", false);
                    }
                }

                #endregion
            }
            else if (ItemInputMode == 1)
            {
                #region 检验
                if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage7) && hasItem.ContainsKey("lis"))
                {
                    ArrayList ItemArr = hasItem["lis"] as ArrayList;

                    for (int i = 0; i < ItemArr.Count; i++)
                    {
                        DataRow dr = ItemArr[i] as DataRow;

                        row = this.m_objViewer.ctlDataGridLis.RowCount;
                        this.m_objViewer.ctlDataGridLis.m_mthAppendRow();
                        m_objViewer.ctlDataGridLis[row, t_Find] = dr["USERCODE_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Name] = dr["ORDERDICNAME_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Spec] = dr["SPEC_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_PartName] = dr["SAMPLE_TYPE_DESC_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Unit] = "次";
                        m_objViewer.ctlDataGridLis[row, t_ItemID] = dr["ORDERDICID_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_PriceFlag] = dr["LISAPPLYUNITID_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Discount] = m_mthConvertObjToDecimal(dr["SBBASEMNY_DEC"]);
                        m_objViewer.ctlDataGridLis[row, t_InvoiceType] = "检验费";
                        m_objViewer.ctlDataGridLis[row, t_EnglishName] = dr["ENGNAME_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Temp] = dr["sampleid_vchr"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Count] = m_mthConvertObjToDecimal(dr["QTY_DEC"]);
                        m_objViewer.ctlDataGridLis[row, t_resubitem] = dr["ATTACHORDERID_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_MainItemNum] = m_mthConvertObjToDecimal(dr["ATTACHORDERBASENUM_DEC"]);
                        m_objViewer.ctlDataGridLis[row, t_Price] = m_mthConvertObjToDecimal(dr["pricemny_dec"]);
                        m_objViewer.ctlDataGridLis[row, t_SumMoney] = m_mthConvertObjToDecimal(dr["TOTALMNY_DEC"]);
                        if (m_mthConvertObjToDecimal(dr["SBBASEMNY_DEC"]) != m_mthConvertObjToDecimal(dr["pricemny_dec"]))
                        {
                            m_objViewer.ctlDataGridLis[row, t_DiscountName] = "打折";//比例
                        }

                        decimal decScale = 1;
                        bool blnCheckDiscount = false;
                        if (IsAllowDiscount)
                        {
                            blnCheckDiscount = this.objSvc.m_blnCheckOrderDiscount(dr["ORDERDICID_CHR"].ToString().Trim(), DiscountInvoCatArr, 1, DiscountItemNus);
                            if (blnCheckDiscount)
                            {
                                decScale = DiscountScale / 100;
                            }
                        }

                        DataTable dt = hasEntry[dr["ATTACHORDERID_VCHR"].ToString().Trim()] as DataTable;
                        clsOrder_VO Order_VO = new clsOrder_VO();
                        Order_VO.OrderDR = dr;
                        Order_VO.EntryDT = dt;
                        hasOrderID.Add("lis->" + dr["ATTACHORDERID_VCHR"].ToString().Trim().Replace("[PK]", ""), Order_VO);

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            dr = dt.Rows[j] as DataRow;

                            ItemID = dr["itemid_chr"].ToString();

                            #region 检验项目调价等变动
                            ItemSpec = dr["spec"].ToString();
                            ItemUnit = dr["itemunit_chr"].ToString();
                            ItemPrice = dr["itemprice_mny"].ToString();
                            #endregion

                            row = this.m_objViewer.ctlDataGrid3.RowCount;
                            this.m_objViewer.ctlDataGrid3.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid3[row, t_Find] = dr["ITEMCODE_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[row, t_Count] = m_mthConvertObjToDecimal(dr["quantity"]);
                            this.m_objViewer.ctlDataGrid3[row, t_Name] = dr["ITEMNAME"].ToString();
                            this.m_objViewer.ctlDataGrid3[row, t_Spec] = ItemSpec;
                            this.m_objViewer.ctlDataGrid3[row, t_Unit] = ItemUnit;
                            this.m_objViewer.ctlDataGrid3[row, t_Price] = m_mthConvertObjToDecimal(ItemPrice);
                            this.m_objViewer.ctlDataGrid3[row, t_SumMoney] = m_mthConvertObjToDecimal(dr["SUMMONEY"]);
                            this.m_objViewer.ctlDataGrid3[row, t_ItemID] = ItemID;
                            this.m_objViewer.ctlDataGrid3[row, t_PriceFlag] = dr["SELFDEFINE"].ToString();
                            this.m_objViewer.ctlDataGrid3[row, t_PartName] = dr["sample_type_desc_vchr"].ToString();
                            this.m_objViewer.ctlDataGrid3[row, t_Temp] = dr["sampleid_vchr"].ToString();
                            this.m_objViewer.ctlDataGrid3[row, t_OtherItemID] = dr["USAGEPARENTID_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[row, t_OtherCount] = m_mthConvertObjToDecimal(dr["usageitembasenum_dec"]);
                            this.m_objViewer.ctlDataGrid3[row, t_lis_orderitem] = dr["ORDERID_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[row, t_lis_ordernum] = m_mthConvertObjToDecimal(dr["ORDERBASENUM_DEC"]);
                            this.m_objViewer.ctlDataGrid3[row, t_UsageDetail] = dr["itemusagedetail_vchr"].ToString();
                            this.m_objViewer.ctlDataGrid3[row, t_lis_discount] = decScale;

                            temp = 100;
                            temp = m_mthConvertObjToDecimal(dr["DISCOUNT_DEC"].ToString());
                            this.m_objViewer.ctlDataGrid3[row, t_DiscountName] = temp.ToString() + "%";
                            this.m_objViewer.ctlDataGrid3[row, t_Discount] = temp;
                            this.m_objViewer.ctlDataGrid3[row, t_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[row, t_EnglishName] = dr["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[row, t_ApplyId] = "";
                            this.m_objViewer.ctlDataGrid3[row, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(ItemID,
                            m_mthConvertObjToDecimal(dr["PRICE"]), dr["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dr["quantity"]), 3000, temp, "", false);

                            this.m_objViewer.ctlDataGrid3[row, t_quickid] = dr["QUICKFLAG_INT"].ToString().Trim();
                            if (dr["QUICKFLAG_INT"].ToString().Trim() == "1")
                            {
                                this.m_objViewer.ctlDataGrid3[row, t_quick] = "是";
                                this.m_objViewer.ctlDataGrid3.m_mthSetRowColor(row, Color.FromArgb(255, 255, 255), Color.FromArgb(250, 89, 69));
                            }
                        }
                    }
                }
                #endregion

                #region 检查
                if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage8) && hasItem.ContainsKey("test"))
                {
                    ArrayList ItemArr = hasItem["test"] as ArrayList;

                    for (int i = 0; i < ItemArr.Count; i++)
                    {
                        DataRow dr = ItemArr[i] as DataRow;

                        row = this.m_objViewer.ctlDataGridTest.RowCount;
                        this.m_objViewer.ctlDataGridTest.m_mthAppendRow();
                        m_objViewer.ctlDataGridTest[row, t_Find] = dr["USERCODE_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Name] = dr["ORDERDICNAME_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Spec] = dr["SPEC_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_PartName] = dr["partname"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Unit] = "次";
                        m_objViewer.ctlDataGridTest[row, t_ItemID] = dr["ORDERDICID_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_PriceFlag] = dr["APPLYTYPEID_CHR"].ToString().Trim();  //用自定义价格列存申请单类型
                        m_objViewer.ctlDataGridTest[row, t_Discount] = m_mthConvertObjToDecimal(dr["SBBASEMNY_DEC"]);
                        m_objViewer.ctlDataGridTest[row, t_InvoiceType] = "检查费";
                        m_objViewer.ctlDataGridTest[row, t_EnglishName] = dr["ENGNAME_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Temp] = dr["checkpartid_vchr"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Count] = m_mthConvertObjToDecimal(dr["QTY_DEC"]);
                        m_objViewer.ctlDataGridTest[row, t_UsageID] = dr["usageid_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_resubitem] = dr["ATTACHORDERID_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_MainItemNum] = m_mthConvertObjToDecimal(dr["ATTACHORDERBASENUM_DEC"]);
                        m_objViewer.ctlDataGridTest[row, t_Price] = m_mthConvertObjToDecimal(dr["pricemny_dec"]);
                        m_objViewer.ctlDataGridTest[row, t_SumMoney] = m_mthConvertObjToDecimal(dr["TOTALMNY_DEC"]);
                        if (m_mthConvertObjToDecimal(dr["SBBASEMNY_DEC"]) != m_mthConvertObjToDecimal(dr["pricemny_dec"]))
                        {
                            m_objViewer.ctlDataGridTest[row, t_DiscountName] = "打折";//比例
                        }

                        DataTable dt = hasEntry[dr["ATTACHORDERID_VCHR"].ToString().Trim()] as DataTable;
                        clsOrder_VO Order_VO = new clsOrder_VO();
                        Order_VO.OrderDR = dr;
                        Order_VO.EntryDT = dt;
                        hasOrderID.Add("test->" + dr["ATTACHORDERID_VCHR"].ToString().Trim().Replace("[PK]", ""), Order_VO);

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            dr = dt.Rows[j] as DataRow;

                            ItemID = dr["itemid_chr"].ToString();

                            #region 检查项目调价等变动
                            ItemSpec = dr["spec"].ToString();
                            ItemUnit = dr["itemunit_chr"].ToString();
                            ItemPrice = dr["itemprice_mny"].ToString();
                            #endregion

                            row = this.m_objViewer.ctlDataGrid4.RowCount;
                            this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid4[row, t_Find] = dr["ITEMCODE_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[row, t_Count] = m_mthConvertObjToDecimal(dr["quantity"]);
                            this.m_objViewer.ctlDataGrid4[row, t_Name] = dr["ITEMNAME"].ToString();
                            this.m_objViewer.ctlDataGrid4[row, t_Spec] = ItemSpec;
                            this.m_objViewer.ctlDataGrid4[row, t_Unit] = ItemUnit;
                            this.m_objViewer.ctlDataGrid4[row, t_Price] = m_mthConvertObjToDecimal(ItemPrice);
                            this.m_objViewer.ctlDataGrid4[row, t_SumMoney] = m_mthConvertObjToDecimal(dr["SUMMONEY"]);
                            this.m_objViewer.ctlDataGrid4[row, t_ItemID] = ItemID;
                            this.m_objViewer.ctlDataGrid4[row, t_PriceFlag] = dr["SELFDEFINE"].ToString();
                            this.m_objViewer.ctlDataGrid4[row, t_PartName] = dr["partname"].ToString();
                            this.m_objViewer.ctlDataGrid4[row, t_Temp] = dr["CHECKPARTID_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[row, t_OtherItemID] = dr["USAGEPARENTID_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[row, t_OtherCount] = m_mthConvertObjToDecimal(dr["usageitembasenum_dec"]);
                            this.m_objViewer.ctlDataGrid4[row, t_test_orderitem] = dr["ORDERID_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[row, t_test_ordernum] = m_mthConvertObjToDecimal(dr["ORDERBASENUM_DEC"]);
                            this.m_objViewer.ctlDataGrid4[row, t_UsageDetail2] = dr["itemusagedetail_vchr"].ToString();
                            this.m_objViewer.ctlDataGrid4[row, t_UsageID] = dr["usageid_chr"].ToString();

                            temp = 100;
                            temp = m_mthConvertObjToDecimal(dr["DISCOUNT_DEC"].ToString());
                            this.m_objViewer.ctlDataGrid4[row, t_DiscountName] = temp.ToString() + "%";
                            this.m_objViewer.ctlDataGrid4[row, t_Discount] = temp;
                            this.m_objViewer.ctlDataGrid4[row, t_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[row, t_EnglishName] = dr["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[row, t_ApplyId] = "";
                            this.m_objViewer.ctlDataGrid4[row, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(ItemID,
                            m_mthConvertObjToDecimal(dr["PRICE"]), dr["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dr["quantity"]), 3000, temp, "", false);
                        }
                    }
                }
                #endregion

                #region 手术治疗
                if (this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage9) && hasItem.ContainsKey("ops"))
                {
                    ArrayList ItemArr = hasItem["ops"] as ArrayList;

                    for (int i = 0; i < ItemArr.Count; i++)
                    {
                        DataRow dr = ItemArr[i] as DataRow;

                        row = this.m_objViewer.ctlDataGridOps.RowCount;
                        this.m_objViewer.ctlDataGridOps.m_mthAppendRow();
                        m_objViewer.ctlDataGridOps[row, o_Find] = dr["USERCODE_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_Name] = dr["ORDERDICNAME_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_Spec] = dr["SPEC_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_Unit] = "次";
                        m_objViewer.ctlDataGridOps[row, o_Price] = "";
                        m_objViewer.ctlDataGridOps[row, o_ItemID] = dr["ORDERDICID_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_PriceFlag] = dr["APPLYTYPEID_CHR"].ToString().Trim();  //用自定义价格列存申请单类型                        
                        m_objViewer.ctlDataGridOps[row, o_Discount] = m_mthConvertObjToDecimal(dr["SBBASEMNY_DEC"]);
                        m_objViewer.ctlDataGridOps[row, o_InvoiceType] = "治疗费";
                        m_objViewer.ctlDataGridOps[row, o_EnglishName] = dr["ENGNAME_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_Count] = m_mthConvertObjToDecimal(dr["QTY_DEC"]);
                        m_objViewer.ctlDataGridOps[row, o_UsageID] = dr["usageid_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_resubitem] = dr["ATTACHORDERID_VCHR"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_MainItemNum] = m_mthConvertObjToDecimal(dr["ATTACHORDERBASENUM_DEC"]);
                        m_objViewer.ctlDataGridOps[row, o_Price] = m_mthConvertObjToDecimal(dr["pricemny_dec"]);
                        m_objViewer.ctlDataGridOps[row, o_SumMoney] = m_mthConvertObjToDecimal(dr["TOTALMNY_DEC"]);
                        if (m_mthConvertObjToDecimal(dr["SBBASEMNY_DEC"]) != m_mthConvertObjToDecimal(dr["pricemny_dec"]))
                        {
                            m_objViewer.ctlDataGridOps[row, o_DiscountName] = "打折";//比例
                        }

                        DataTable dt = hasEntry[dr["ATTACHORDERID_VCHR"].ToString().Trim()] as DataTable;
                        clsOrder_VO Order_VO = new clsOrder_VO();
                        Order_VO.OrderDR = dr;
                        Order_VO.EntryDT = dt;
                        hasOrderID.Add("ops->" + dr["ATTACHORDERID_VCHR"].ToString().Trim().Replace("[PK]", ""), Order_VO);

                        for (int j = 0; j < dt.Rows.Count; j++)
                        {
                            dr = dt.Rows[j] as DataRow;

                            ItemID = dr["itemid_chr"].ToString();

                            #region 手术治疗项目调价等变动
                            ItemSpec = dr["spec"].ToString();
                            ItemUnit = dr["itemunit_chr"].ToString();
                            ItemPrice = dr["itemprice_mny"].ToString();
                            #endregion

                            row = this.m_objViewer.ctlDataGrid5.RowCount;
                            this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid5[row, o_Find] = dr["ITEMCODE_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[row, o_Count] = m_mthConvertObjToDecimal(dr["quantity"]);
                            this.m_objViewer.ctlDataGrid5[row, o_Name] = dr["ITEMNAME"].ToString();
                            this.m_objViewer.ctlDataGrid5[row, o_Spec] = ItemSpec;
                            this.m_objViewer.ctlDataGrid5[row, o_Unit] = ItemUnit;
                            this.m_objViewer.ctlDataGrid5[row, o_Price] = m_mthConvertObjToDecimal(ItemPrice);
                            this.m_objViewer.ctlDataGrid5[row, o_SumMoney] = m_mthConvertObjToDecimal(dr["SUMMONEY"]);
                            this.m_objViewer.ctlDataGrid5[row, o_ItemID] = ItemID;
                            this.m_objViewer.ctlDataGrid5[row, o_PriceFlag] = dr["SELFDEFINE"].ToString();
                            this.m_objViewer.ctlDataGrid5[row, o_OtherItemID] = dr["USAGEPARENTID_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[row, o_OtherCount] = m_mthConvertObjToDecimal(dr["usageitembasenum_dec"]);
                            this.m_objViewer.ctlDataGrid5[row, t_ops_orderitem] = dr["ORDERID_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[row, t_ops_ordernum] = m_mthConvertObjToDecimal(dr["ORDERBASENUM_DEC"]);
                            this.m_objViewer.ctlDataGrid5[row, o_UsageDetail] = dr["itemusagedetail_vchr"].ToString();
                            this.m_objViewer.ctlDataGrid5[row, o_UsageID] = dr["usageid_chr"].ToString();

                            temp = 100;
                            temp = m_mthConvertObjToDecimal(dr["DISCOUNT_DEC"].ToString());
                            this.m_objViewer.ctlDataGrid5[row, o_DiscountName] = temp.ToString() + "%";
                            this.m_objViewer.ctlDataGrid5[row, o_Discount] = temp;
                            this.m_objViewer.ctlDataGrid5[row, o_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[row, o_EnglishName] = dr["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[row, o_ApplyId] = "";
                            this.m_objViewer.ctlDataGrid5[row, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(ItemID,
                            m_mthConvertObjToDecimal(dr["PRICE"]), dr["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dr["quantity"]), 3000, temp, "", false);
                        }
                    }
                }

                #endregion
            }

            #region 其他
            if (hasItem.ContainsKey("6"))
            {
                ArrayList ItemArr = hasItem["6"] as ArrayList;

                for (int i = 0; i < ItemArr.Count; i++)
                {
                    DataRow dr = ItemArr[i] as DataRow;

                    ItemID = dr["itemid"].ToString();

                    #region 其他项目调价等变动
                    ItemSpec = dr["spec"].ToString();
                    //ItemUnit = dr["itemunit_chr"].ToString();
                    //ItemPrice = dr["itemprice_mny"].ToString();

                    if (dr["opchargeflg_int"].ToString().Trim() == "0") // 判断大小单位
                    {
                        if (clsPublic.ConvertObjToDecimal(dr["price"]) != clsPublic.ConvertObjToDecimal(dr["itemprice_mny"]))
                        {
                            ItemPrice = dr["itemprice_mny"].ToString();
                        }
                        else
                        {
                            ItemPrice = dr["price"].ToString();
                        }
                        ItemUnit = dr["itemopunit_chr"].ToString();
                    }
                    else
                    {
                        if (clsPublic.ConvertObjToDecimal(dr["price"]) != clsPublic.ConvertObjToDecimal(dr["submoney"]))
                        {
                            ItemPrice = dr["submoney"].ToString();
                        }
                        else
                        {
                            ItemPrice = dr["price"].ToString();
                        }
                        ItemUnit = dr["itemipunit_chr"].ToString();
                    }

                    #endregion

                    row = this.m_objViewer.ctlDataGrid6.RowCount;
                    this.m_objViewer.ctlDataGrid6.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid6[row, o_Find] = dr["ITEMCODE_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_Count] = m_mthConvertObjToDecimal(dr["quantity"]);
                    this.m_objViewer.ctlDataGrid6[row, o_Name] = dr["ITEMNAME"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_Spec] = ItemSpec;
                    this.m_objViewer.ctlDataGrid6[row, o_Unit] = ItemUnit;
                    this.m_objViewer.ctlDataGrid6[row, o_Price] = m_mthConvertObjToDecimal(ItemPrice);
                    this.m_objViewer.ctlDataGrid6[row, o_SumMoney] = m_mthConvertObjToDecimal(dr["SUMMONEY"]);
                    this.m_objViewer.ctlDataGrid6[row, o_ItemID] = dr["ITEMID"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_PriceFlag] = dr["SELFDEFINE"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_OtherItemID] = dr["USAGEPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_OtherCount] = m_mthConvertObjToDecimal(dr["usageitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid6[row, o_resubitem] = dr["ATTACHPARENTID_VCHR"].ToString();
                    this.m_objViewer.ctlDataGrid6[row, o_MainItemNum] = m_mthConvertObjToDecimal(dr["attachitembasenum_dec"]);
                    this.m_objViewer.ctlDataGrid6[row, o_UsageDetail2] = dr["itemusagedetail_vchr"].ToString();

                    temp = 100;
                    temp = m_mthConvertObjToDecimal(dr["DISCOUNT_DEC"].ToString());
                    this.m_objViewer.ctlDataGrid6[row, o_DiscountName] = temp.ToString() + "%";
                    this.m_objViewer.ctlDataGrid6[row, o_Discount] = temp;
                    this.m_objViewer.ctlDataGrid6[row, o_InvoiceType] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid6[row, o_EnglishName] = dr["itemengname_vchr"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid6[row, o_ApplyId] = dr["ATTACHID_VCHR"].ToString().Trim();
                    this.m_objViewer.ctlDataGrid6[row, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dr["ITEMID"].ToString(),
                    m_mthConvertObjToDecimal(dr["PRICE"]), dr["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dr["quantity"]), 3000, temp, "", false);

                    if (Isdeptmed)
                    {
                        this.m_objViewer.ctlDataGrid6[row, o_DeptmedID] = dr["deptmed_int"].ToString();
                        if (dr["deptmed_int"].ToString() == "1")
                        {
                            this.m_objViewer.ctlDataGrid6[row, o_Deptmed] = "是";
                            this.m_objViewer.ctlDataGrid6.m_mthSetRowColor(row, dfc, dbc);
                        }
                    }
                }

            }
            #endregion

            //显示总金额
            this.m_mthCalculateTotalMoney();
            this.m_mthFormatDataGrid();
        }
        #endregion

        #region 根据医生处方权控制TABPAGE
        /// <summary>
        /// 根据医生处方权控制TABPAGE
        /// </summary>              
        public void m_mthSetTabPage()
        {
            //参数：0065－是否启用控制处方页 0 停用 1 启用
            if (!this.objSvc.m_mthIsCanDo("0065"))
            {
                return;
            }

            DataTable dt;
            long l = this.objSvc.m_lngGetDoctorRecipePurview(this.m_objViewer.LoginInfo.m_strEmpID, out dt);
            if (l > 0)
            {
                if (dt.Rows.Count == 0)
                {
                    // 西药处方页                    
                    this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage5);
                    // 中药处方页                    
                    this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage6);
                    // 检验处方页                    
                    this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage7);
                    // 检查处方页                    
                    this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage8);
                    // 手术/治疗处方页                    
                    this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage9);
                }
                else
                {
                    // 1 西药权限、2 中药权限、3 检查权限、4 检验权限、5 手术/治疗权限

                    ArrayList IdArr = new ArrayList();

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        IdArr.Add(dt.Rows[i]["purview_chr"].ToString());
                    }

                    int index = -1;

                    index = IdArr.IndexOf("1");
                    if (index == -1)
                    {
                        this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage5);
                    }

                    index = IdArr.IndexOf("2");
                    if (index == -1)
                    {
                        this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage6);
                    }

                    index = IdArr.IndexOf("3");
                    if (index == -1)
                    {
                        this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage7);
                    }

                    index = IdArr.IndexOf("4");
                    if (index == -1)
                    {
                        this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage8);
                    }

                    index = IdArr.IndexOf("5");
                    if (index == -1)
                    {
                        this.m_objViewer.tabControl1.TabPages.Remove(this.m_objViewer.tabPage9);
                    }
                }
            }
        }
        #endregion

        #region 循环获取诊疗项目－收费项目
        /// <summary>
        /// 循环获取诊疗项目－收费项目
        /// </summary>
        /// <param name="CurrItemID">当前收费项目</param>	
        /// <param name="MainItemID">主收费项目ID</param>	
        /// <param name="MainUsageID">主收费项目默认用法</param>	
        /// <param name="intCurrRow">当前行号</param>
        /// <param name="Type">类型: -1 删除 0 插入</param>        
        /// <param name="OrderFlag">"lis 检验 test 检查 ops 手术治疗诊疗项目"</param>   
        /// <param name="BaseNums">"主诊疗项目基数"</param>   
        public void m_mthGetChargeItemByOrderItem(string CurrItemID, string MainItemID, string MainUsageID, int Type, DataTable dtRecord, string OrderFlag, out decimal TotalMny, out decimal SbMny, decimal DiscountScale, decimal BaseNums)
        {
            TotalMny = 0;
            SbMny = 0;
            ArrayList DelDrArr = new ArrayList();

            //用法带出的主收费ID
            string OtherItemID = "";

            switch (OrderFlag.ToLower())
            {
                case "lis":
                    if (Type == -1)
                    {
                        for (int i = this.m_objViewer.ctlDataGrid3.RowCount - 1; i >= 0; i--)
                        {
                            if (this.m_objViewer.ctlDataGrid3[i, t_lis_orderitem].ToString().Trim() == CurrItemID)
                            {
                                OtherItemID = m_objViewer.ctlDataGrid3[i, t_OtherItemID].ToString().Trim();
                                if (OtherItemID.StartsWith("[PK]"))
                                {
                                    this.m_mthGetChargeItemByUsageID("", true, OtherItemID.Replace("[PK]", ""), -1);
                                }

                                if (this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString().Trim() != "")
                                {
                                    objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid3[i, t_RowNo].ToString()));
                                }
                                this.m_objViewer.ctlDataGrid3.m_mthDeleteRow(i);
                            }
                        }
                    }
                    else if (Type == 0)
                    {
                        foreach (DataRow dtRow in dtRecord.Rows)
                        {
                            //子项目用于所有主项目
                            if (dtRow["usescope_int"].ToString() == "1")
                            {
                                if (this.m_blnCheckreitem(dtRow["itemid_chr"].ToString().Trim()))
                                {
                                    DelDrArr.Add(dtRow);
                                    continue;
                                }
                            }

                            decimal d = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums;
                            int tempRow = 0;
                            decimal temp = 0;
                            tempRow = this.m_objViewer.ctlDataGrid3.RowCount;
                            this.m_objViewer.ctlDataGrid3.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Count] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid3[tempRow, t_SumMoney] = d.ToString("0.00");
                            this.m_objViewer.ctlDataGrid3[tempRow, t_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_lis_orderitem] = CurrItemID;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_OtherCount] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_PartName] = "";
                            this.m_objViewer.ctlDataGrid3[tempRow, t_Temp] = "";
                            this.m_objViewer.ctlDataGrid3[tempRow, t_lis_discount] = DiscountScale;

                            temp = 100;
                            //if (objCalPatientCharge != null)
                            //{
                            //    temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            //}
                            if (dtRow["precent_dec"].ToString().Trim() != string.Empty)
                            {
                                temp = Convert.ToDecimal(dtRow["precent_dec"].ToString());
                            }
                            temp = temp * DiscountScale;
                            m_objViewer.ctlDataGrid3[tempRow, t_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid3[tempRow, t_Discount] = temp;
                            this.m_objViewer.ctlDataGrid3[tempRow, t_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid3[tempRow, t_lis_ordernum] = this.m_objViewer.ctlDataGrid3[tempRow, t_Count];
                            this.m_objViewer.ctlDataGrid3[tempRow, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                            m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums, 3000, temp, "", false);

                            TotalMny += m_mthConvertObjToDecimal(d.ToString("0.00"));
                            d = d * temp / 100;
                            SbMny += m_mthConvertObjToDecimal(d.ToString("0.00"));

                            //用法带出
                            if (dtRow["ITEMID_CHR"].ToString() == MainItemID && (MainUsageID != null || MainUsageID.Trim() != ""))
                            {
                                m_objViewer.ctlDataGrid3[tempRow, t_OtherItemID] = "[PK]" + tempRow.ToString() + "->" + MainItemID;
                                m_mthGetChargeItemByUsageID(MainUsageID.Trim(), false, tempRow.ToString() + "->" + MainItemID, tempRow);
                            }
                        }
                    }
                    break;
                case "test":
                    if (Type == -1)
                    {
                        for (int i = this.m_objViewer.ctlDataGrid4.RowCount - 1; i >= 0; i--)
                        {
                            if (this.m_objViewer.ctlDataGrid4[i, t_test_orderitem].ToString().Trim() == CurrItemID)
                            {
                                OtherItemID = m_objViewer.ctlDataGrid4[i, t_OtherItemID].ToString().Trim();
                                if (OtherItemID.StartsWith("[PK]"))
                                {
                                    this.m_mthGetChargeItemByUsageID("", true, OtherItemID.Replace("[PK]", ""), -1);
                                }

                                if (this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString().Trim() != "")
                                {
                                    objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid4[i, t_RowNo].ToString()));
                                }
                                this.m_objViewer.ctlDataGrid4.m_mthDeleteRow(i);
                            }
                        }
                    }
                    else if (Type == 0)
                    {
                        foreach (DataRow dtRow in dtRecord.Rows)
                        {
                            //子项目用于所有主项目
                            if (dtRow["usescope_int"].ToString() == "1")
                            {
                                if (this.m_blnCheckreitem(dtRow["itemid_chr"].ToString().Trim()))
                                {
                                    DelDrArr.Add(dtRow);
                                    continue;
                                }
                            }

                            decimal d = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums;
                            int tempRow = 0;
                            decimal temp = 0;
                            tempRow = this.m_objViewer.ctlDataGrid4.RowCount;
                            this.m_objViewer.ctlDataGrid4.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Count] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid4[tempRow, t_SumMoney] = d.ToString("0.00");
                            this.m_objViewer.ctlDataGrid4[tempRow, t_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_test_orderitem] = CurrItemID;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_OtherCount] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_test_ordernum] = this.m_objViewer.ctlDataGrid4[tempRow, t_Count];

                            temp = 100;
                            //if (objCalPatientCharge != null)
                            //{
                            //    temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            //}
                            if (dtRow["precent_dec"].ToString().Trim() != string.Empty)
                            {
                                temp = Convert.ToDecimal(dtRow["precent_dec"].ToString());
                            }
                            m_objViewer.ctlDataGrid4[tempRow, t_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid4[tempRow, t_Discount] = temp;
                            this.m_objViewer.ctlDataGrid4[tempRow, t_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid4[tempRow, t_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                            m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums, 3000, temp, "", false);

                            TotalMny += m_mthConvertObjToDecimal(d.ToString("0.00"));
                            d = d * temp / 100;
                            SbMny += m_mthConvertObjToDecimal(d.ToString("0.00"));

                            //用法带出
                            if (dtRow["ITEMID_CHR"].ToString() == MainItemID && (MainUsageID != null || MainUsageID.Trim() != ""))
                            {
                                m_objViewer.ctlDataGrid4[tempRow, t_OtherItemID] = "[PK]" + tempRow.ToString() + "->" + MainItemID;
                                m_mthGetChargeItemByUsageID(MainUsageID.Trim(), false, tempRow.ToString() + "->" + MainItemID, tempRow);
                            }
                        }
                    }
                    break;
                case "ops":
                    if (Type == -1)
                    {
                        for (int i = this.m_objViewer.ctlDataGrid5.RowCount - 1; i >= 0; i--)
                        {
                            if (this.m_objViewer.ctlDataGrid5[i, t_ops_orderitem].ToString().Trim() == CurrItemID)
                            {
                                OtherItemID = m_objViewer.ctlDataGrid5[i, o_OtherItemID].ToString().Trim();
                                if (OtherItemID.StartsWith("[PK]"))
                                {
                                    this.m_mthGetChargeItemByUsageID("", true, OtherItemID.Replace("[PK]", ""), -1);
                                }

                                if (this.m_objViewer.ctlDataGrid5[i, 9].ToString().Trim() != "")
                                {
                                    objCalPatientCharge.m_mthDelteChargeItem(int.Parse(this.m_objViewer.ctlDataGrid5[i, 9].ToString()));
                                }
                                this.m_objViewer.ctlDataGrid5.m_mthDeleteRow(i);
                            }
                        }
                    }
                    else if (Type == 0)
                    {
                        foreach (DataRow dtRow in dtRecord.Rows)
                        {
                            //子项目用于所有主项目
                            if (dtRow["usescope_int"].ToString() == "1")
                            {
                                if (this.m_blnCheckreitem(dtRow["itemid_chr"].ToString().Trim()))
                                {
                                    DelDrArr.Add(dtRow);
                                    continue;
                                }
                            }

                            decimal d = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums;
                            int tempRow = 0;
                            decimal temp = 0;
                            tempRow = this.m_objViewer.ctlDataGrid5.RowCount;
                            this.m_objViewer.ctlDataGrid5.m_mthAppendRow();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Find] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Count] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Name] = dtRow["ITEMNAME_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Spec] = dtRow["ITEMSPEC_VCHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Unit] = dtRow["ITEMUNIT_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_Price] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                            this.m_objViewer.ctlDataGrid5[tempRow, o_SumMoney] = m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]) * m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                            this.m_objViewer.ctlDataGrid5[tempRow, o_ItemID] = dtRow["ITEMID_CHR"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_PriceFlag] = dtRow["SELFDEFINE_INT"].ToString();
                            this.m_objViewer.ctlDataGrid5[tempRow, t_ops_orderitem] = CurrItemID;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_OtherCount] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_EnglishName] = dtRow["itemengname_vchr"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[tempRow, o_UsageID] = dtRow["usageid_chr"].ToString().Trim();
                            temp = 100;
                            //if (objCalPatientCharge != null)
                            //{
                            //    temp = objCalPatientCharge.m_mthGetDiscountByID(dtRow["ITEMID_CHR"].ToString());
                            //}
                            if (dtRow["precent_dec"].ToString().Trim() != string.Empty)
                            {
                                temp = Convert.ToDecimal(dtRow["precent_dec"].ToString());
                            }
                            m_objViewer.ctlDataGrid5[tempRow, o_DiscountName] = temp.ToString() + "%";
                            m_objViewer.ctlDataGrid5[tempRow, o_Discount] = temp;
                            this.m_objViewer.ctlDataGrid5[tempRow, o_InvoiceType] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                            this.m_objViewer.ctlDataGrid5[tempRow, t_ops_ordernum] = this.m_objViewer.ctlDataGrid5[tempRow, o_Count];
                            this.m_objViewer.ctlDataGrid5[tempRow, o_RowNo] = objCalPatientCharge.m_mthGetChargeIetmPrice(dtRow["ITEMID_CHR"].ToString(),
                            m_mthConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]), dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim(), m_mthConvertObjToDecimal(dtRow["totalqty_dec"]) * BaseNums, 3000, temp, "", false);

                            TotalMny += m_mthConvertObjToDecimal(d.ToString("0.00"));
                            d = d * temp / 100;
                            SbMny += m_mthConvertObjToDecimal(d.ToString("0.00"));

                            //用法带出
                            if (dtRow["ITEMID_CHR"].ToString() == MainItemID && (MainUsageID != null || MainUsageID.Trim() != ""))
                            {
                                m_objViewer.ctlDataGrid5[tempRow, o_OtherItemID] = "[PK]" + tempRow.ToString() + "->" + MainItemID;
                                m_mthGetChargeItemByUsageID(MainUsageID.Trim(), false, tempRow.ToString() + "->" + MainItemID, tempRow);
                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            for (int i = 0; i < DelDrArr.Count; i++)
            {
                dtRecord.Rows.Remove((DataRow)DelDrArr[i]);
            }
        }
        #endregion

        #region 调用协定处方
        /// <summary>
        /// 调用协定处方
        /// </summary>
        public void m_mthGetAccordRecipe(string FindStr)
        {
            //have
            frmAccordRecipeList f = new frmAccordRecipeList(true, FindStr);
            if (f.ShowDialog() == DialogResult.OK)
            {
                this.IsShowOverFlow = false;

                int row = 0;
                decimal temp = 100;
                this.m_mthClearDataEmptyRow();

                DataRow dr = null;

                ArrayList objItemArr = new ArrayList();

                for (int i = 0; i < f.ItemArr1.Count; i++)
                {
                    dr = f.ItemArr1[i] as DataRow;
                    objItemArr.Add(dr["itemid_chr"].ToString());
                }
                for (int i = 0; i < f.ItemArr2.Count; i++)
                {
                    dr = f.ItemArr2[i] as DataRow;
                    objItemArr.Add(dr["itemid_chr"].ToString());
                }
                for (int i = 0; i < f.ItemArr6.Count; i++)
                {
                    dr = f.ItemArr6[i] as DataRow;
                    objItemArr.Add(dr["itemid_chr"].ToString());
                }
                Hashtable hasItemScale = new Hashtable();
                if (objItemArr.Count > 0)
                {
                    //string[] strItemIDArr = new string[objItemArr.Count];
                    //for (int i = 0; i < objItemArr.Count; i++)
                    //{
                    //    strItemIDArr[i] = objItemArr[i].ToString();
                    //}  
                    string[] strItemIDArr = (string[])objItemArr.ToArray(typeof(string));
                    this.objSvc.m_lngGetItemScaleByArr(this.m_objViewer.m_PatInfo.PayTypeID, strItemIDArr, ref hasItemScale);
                }


                #region 西药
                if (f.ItemArr1.Count > 0 && this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage5))
                {
                    int MaxGroupNo = 0;
                    for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
                    {
                        if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_GroupNo]) > 0)
                        {
                            if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_GroupNo]) > MaxGroupNo)
                            {
                                MaxGroupNo = int.Parse(this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, c_GroupNo]).ToString());
                            }
                        }
                    }

                    Hashtable hasRecNo = new Hashtable();
                    for (int i = 0; i < f.ItemArr1.Count; i++)
                    {
                        dr = f.ItemArr1[i] as DataRow;

                        bool IsGroup = false;
                        string RecNO = dr["recno"].ToString().Trim();
                        if (RecNO != "")
                        {
                            IsGroup = true;

                            if (hasRecNo.ContainsKey(RecNO))
                            {
                                IsGroup = false;
                            }
                            else
                            {
                                hasRecNo.Add(RecNO, null);
                            }

                            if (IsGroup)
                            {
                                MaxGroupNo++;
                            }
                        }

                        this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                        row = this.m_objViewer.ctlDataGrid1.RowCount - 1;

                        this.m_objViewer.ctlDataGrid1[row, c_Count] = m_mthConvertObjToDecimal(dr["recqty"]);
                        this.m_objViewer.ctlDataGrid1[row, c_Unit] = dr["dosageunit_chr"].ToString();//剂量单位
                        this.m_objViewer.ctlDataGrid1[row, c_Name] = dr["itemname_vchr"].ToString();//项目名称
                        this.m_objViewer.ctlDataGrid1[row, c_Spec] = dr["itemspec_vchr"].ToString();
                        this.m_objViewer.ctlDataGrid1[row, c_UsageName] = dr["usagename_vchr"].ToString();//用法名称
                        this.m_objViewer.ctlDataGrid1[row, c_FreName] = dr["freqname"].ToString();//频率名称
                        this.m_objViewer.ctlDataGrid1[row, c_Day] = m_mthConvertObjToDecimal(dr["recdays"]);//天数
                        if (dr["opchargeflg_int"].ToString() == "1")
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_Price] = m_mthConvertObjToDecimal(dr["submoney"]);
                            this.m_objViewer.ctlDataGrid1[row, c_BigUnit] = dr["itemipunit_chr"].ToString();
                        }
                        else
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_Price] = m_mthConvertObjToDecimal(dr["itemprice_mny"]);
                            this.m_objViewer.ctlDataGrid1[row, c_BigUnit] = dr["itemopunit_chr"].ToString();
                        }

                        this.m_objViewer.ctlDataGrid1[row, c_ItemID] = dr["itemid_chr"].ToString();
                        this.m_objViewer.ctlDataGrid1[row, c_Packet] = m_mthConvertObjToDecimal(dr["packqty_dec"]);
                        this.m_objViewer.ctlDataGrid1[row, c_FreDays] = dr["freqdays"].ToString();//频率天数
                        this.m_objViewer.ctlDataGrid1[row, c_FreTimes] = dr["freqtimes"].ToString();//频率次数
                        this.m_objViewer.ctlDataGrid1[row, c_UsageID] = dr["usageid_chr"].ToString();//用法ID
                        this.m_objViewer.ctlDataGrid1[row, c_FreID] = dr["freqid"].ToString();//频率ID
                        this.rowNo = row;

                        if (RecNO != "")
                        {
                            if (IsGroup)
                            {
                                this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -1;
                            }
                            else
                            {
                                this.m_objViewer.ctlDataGrid1[row, c_IsMain] = row;
                            }
                            this.m_objViewer.ctlDataGrid1[row, c_GroupNo] = MaxGroupNo.ToString();
                        }
                        else
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_IsMain] = -4;
                        }

                        this.m_objViewer.ctlDataGrid1[row, c_InvoiceType] = dr["itemopinvtype_chr"].ToString();//发票分类
                        this.m_objViewer.ctlDataGrid1[row, c_Dosage] = dr["dosage_dec"].ToString();//剂量数
                        this.m_objViewer.ctlDataGrid1[row, c_Find] = dr["itemcode_vchr"].ToString();//编号
                        this.m_objViewer.ctlDataGrid1[row, c_EnglishName] = dr["itemengname_vchr"].ToString();//英文名
                        this.m_objViewer.ctlDataGrid1[row, c_PSFlag] = dr["hype_int"].ToString();//皮试标志
                        if (dr["hype_int"].ToString().Trim() == "1")//如果此药要皮试则默认为皮试
                        {
                            this.m_objViewer.ctlDataGrid1[row, c_PS] = 1;
                            this.m_objViewer.ctlDataGrid1.m_mthFormatCell(row, c_UsageName, this.m_objViewer.ctlDataGrid1.Font, Color.White, Color.Red);
                        }
                        this.m_objViewer.ctlDataGrid1[row, c_IsCal] = 1;
                        //temp = 100;
                        //if (objCalPatientCharge != null)
                        //{
                        //    temp = objCalPatientCharge.m_mthGetDiscountByID(dr["itemid_chr"].ToString());
                        //}

                        temp = Convert.ToDecimal(hasItemScale[dr["itemid_chr"].ToString()].ToString());
                        m_objViewer.ctlDataGrid1[row, c_DiscountName] = temp.ToString() + "%";
                        m_objViewer.ctlDataGrid1[row, c_Discount] = temp;
                        m_objViewer.ctlDataGrid1[row, c_UnitFlag] = dr["opchargeflg_int"].ToString();
                        decimal dectime = 1;//频率天数
                        if (m_mthConvertObjToDecimal(dr["freqdays"]) > 0)
                        {
                            dectime = m_mthConvertObjToDecimal(dr["freqdays"]);
                        }
                        //总剂量
                        decimal decSum = m_mthConvertObjToDecimal(dr["freqdays"]) * m_mthConvertObjToDecimal(dr["freqtimes"]) * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, c_Day]) / dectime;
                        decimal iii = 0;//总数
                        //包装量
                        decimal packet = m_mthConvertObjToDecimal(dr["packqty_dec"]);
                        //剂量比例
                        decimal decDosage = m_mthConvertObjToDecimal(dr["dosage_dec"]);
                        decimal Days = 0;
                        if (CalFlag)
                        {
                            Days = m_mthConvertObjToDecimal(dr["recdays"]) / dectime;
                            decimal temp2 = m_mthConvertObjToDecimal(dr["recqty"]);
                            iii = (decimal)Math.Ceiling((double)(temp2 / (decDosage)));
                            iii = Days * iii * this.m_mthConvertObjToDecimal(dr["freqtimes"]);
                            if (dr["opchargeflg_int"].ToString().Trim() == "0")
                            {
                                iii = (decimal)Math.Ceiling((double)(iii / (packet)));
                            }
                            this.m_objViewer.ctlDataGrid1[row, c_Total] = iii;
                        }
                        else
                        {
                            if (dr["opchargeflg_int"].ToString().Trim() == "1")//用最小单位收费
                            {
                                iii = (decimal)Math.Ceiling((double)(decSum / decDosage));
                                this.m_objViewer.ctlDataGrid1[row, c_Total] = iii;
                                this.m_objViewer.ctlDataGrid1[row, c_SumMoney] = iii * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, c_Price]);

                            }
                            else//大单位
                            {

                                if (packet == 0)
                                {
                                    packet = 1;
                                }

                                iii = (decimal)Math.Ceiling((double)(decSum / (packet * decDosage)));
                                this.m_objViewer.ctlDataGrid1[row, c_Total] = iii;
                            }
                            this.m_objViewer.ctlDataGrid1[row, c_SumMoney] = iii * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, c_Price]);

                        }
                        int int_Temp = objCalPatientCharge.m_mthGetChargeIetmPrice(dr["itemid_chr"].ToString(), m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, c_Price]),
                        dr["itemopinvtype_chr"].ToString(), m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, c_Total]), 3000, temp, "", false);
                        string strSubItem = dr["itemid_chr"].ToString();
                        this.m_objViewer.ctlDataGrid1[row, c_SubItemID] = "[PK]" + row.ToString() + "->" + strSubItem;
                        this.m_objViewer.ctlDataGrid1[row, c_RowNo] = int_Temp;

                        if (RecNO != "")
                        {
                            if (IsGroup)
                            {
                                this.m_mthGetChargeItemByUsageID(dr["usageid_chr"].ToString().Trim(), false, row.ToString() + "->" + strSubItem, row);
                            }
                        }
                        else
                        {
                            this.m_mthGetChargeItemByUsageID(dr["usageid_chr"].ToString().Trim(), false, row.ToString() + "->" + strSubItem, row);
                        }

                        decimal decTimesTemp = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, c_Day]) * m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[row, c_FreTimes]);
                        this.m_mthChangeTimeForDefaultItem(row.ToString() + "->" + strSubItem, decTimesTemp, row, 0);

                        //项目带项目
                        string strItemID = dr["itemid_chr"].ToString().Trim();
                        DataTable dtRecord = new DataTable();
                        bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                        if (blnStat)
                        {
                            m_mthGetChargeItemByItem(row.ToString() + "->" + strItemID, 0, dtRecord);
                            m_objViewer.ctlDataGrid1[row, c_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                            m_objViewer.ctlDataGrid1[row, c_MainItemNum] = m_objViewer.ctlDataGrid1[row, c_Count];
                        }

                        this.m_objViewer.ctlDataGrid1[row, c_DeptmedID] = "*";
                    }
                }
                #endregion

                #region 中药
                if (f.ItemArr2.Count > 0 && this.m_objViewer.tabControl1.TabPages.Contains(this.m_objViewer.tabPage6))
                {
                    for (int i = 0; i < f.ItemArr2.Count; i++)
                    {
                        dr = f.ItemArr2[i] as DataRow;

                        this.m_objViewer.ctlDataGrid2.m_mthAppendRow();
                        row = this.m_objViewer.ctlDataGrid2.RowCount - 1;
                        this.m_objViewer.ctlDataGrid2[row, 0] = dr["itemcode_vchr"].ToString();//名称
                        this.m_objViewer.ctlDataGrid2[row, 1] = m_mthConvertObjToDecimal(dr["recqty"]);//剂量
                        this.m_objViewer.ctlDataGrid2[row, 3] = dr["itemname_vchr"].ToString();//名称
                        this.m_objViewer.ctlDataGrid2[row, 4] = dr["itemspec_vchr"].ToString();//规格
                        this.m_objViewer.ctlDataGrid2[row, 2] = dr["dosageunit_chr"].ToString();//单位
                        this.m_objViewer.ctlDataGrid2[row, 5] = dr["usagename_vchr"].ToString();//用法
                        this.m_objViewer.ctlDataGrid2[row, 21] = dr["usageid_chr"].ToString();//用法ID
                        this.m_objViewer.ctlDataGrid2[row, 6] = m_mthConvertObjToDecimal(dr["submoney"]);//单价
                        this.m_objViewer.ctlDataGrid2[row, 8] = dr["itemid_chr"].ToString();//ID
                        this.m_objViewer.ctlDataGrid2[row, 12] = dr["dosage_dec"].ToString();//常量
                        this.m_objViewer.ctlDataGrid2[row, 13] = 0;//上限
                        this.m_objViewer.ctlDataGrid2[row, 14] = 0;//下限
                        this.m_objViewer.ctlDataGrid2[row, 9] = -1;//行号
                        this.m_objViewer.ctlDataGrid2[row, 16] = dr["itemprice_mny"].ToString();
                        this.m_objViewer.ctlDataGrid2[row, 17] = dr["opchargeflg_int"].ToString();//大小单位标记
                        this.m_objViewer.ctlDataGrid2[row, 18] = dr["packqty_dec"].ToString();//包装量
                        this.m_objViewer.ctlDataGrid2[row, 20] = dr["itemopinvtype_chr"].ToString();//发票分类 
                        this.m_objViewer.ctlDataGrid2[row, 24] = dr["itemcode_vchr"].ToString();//英文名
                        //temp = 100;
                        //if (objCalPatientCharge != null)
                        //{
                        //    temp = objCalPatientCharge.m_mthGetDiscountByID(dr["itemid_chr"].ToString());
                        //}
                        temp = Convert.ToDecimal(hasItemScale[dr["itemid_chr"].ToString()].ToString());
                        m_objViewer.ctlDataGrid2[row, 10] = temp.ToString() + "%";
                        m_objViewer.ctlDataGrid2[row, 11] = temp;
                        this.m_mthCalculateAmount2(row);

                        this.m_objViewer.ctlDataGrid2[row, cm_DeptmedID] = "*";
                    }
                }
                #endregion

                #region 检验
                if (f.ItemArr3.Count > 0)
                {
                    this.m_mthAddOrderItem(f.ItemArr3, 1);
                }
                #endregion

                #region 检查
                if (f.ItemArr4.Count > 0)
                {
                    this.m_mthAddOrderItem(f.ItemArr4, 2);
                }
                #endregion

                #region 手术治疗
                if (f.ItemArr5.Count > 0)
                {
                    this.m_mthAddOrderItem(f.ItemArr5, 3);
                }
                #endregion

                #region 其他

                if (f.ItemArr6.Count > 0)
                {
                    for (int i = 0; i < f.ItemArr6.Count; i++)
                    {
                        dr = f.ItemArr6[i] as DataRow;

                        this.m_objViewer.ctlDataGrid6.m_mthAppendRow();
                        row = this.m_objViewer.ctlDataGrid6.RowCount - 1;
                        this.m_objViewer.ctlDataGrid6[row, 0] = dr["itemcode_vchr"].ToString();
                        this.m_objViewer.ctlDataGrid6[row, 1] = m_mthConvertObjToDecimal(dr["recqty"]);
                        this.m_objViewer.ctlDataGrid6[row, 2] = dr["itemname_vchr"].ToString();
                        this.m_objViewer.ctlDataGrid6[row, 3] = dr["itemspec_vchr"].ToString();
                        this.m_objViewer.ctlDataGrid6[row, 4] = dr["itemopunit_chr"].ToString();
                        this.m_objViewer.ctlDataGrid6[row, 5] = m_mthConvertObjToDecimal(dr["itemprice_mny"]);
                        this.m_objViewer.ctlDataGrid6[row, 7] = dr["itemid_chr"].ToString();
                        this.m_objViewer.ctlDataGrid6[row, 8] = dr["selfdefine_int"].ToString();
                        this.m_objViewer.ctlDataGrid6[row, 12] = dr["itemopinvtype_chr"].ToString();//发票分类
                        this.m_objViewer.ctlDataGrid6[row, 15] = dr["itemengname_vchr"].ToString();//英文名
                        //temp = 100;
                        //if (objCalPatientCharge != null)
                        //{
                        //    temp = objCalPatientCharge.m_mthGetDiscountByID(dr["itemid_chr"].ToString());
                        //}
                        temp = Convert.ToDecimal(hasItemScale[dr["itemid_chr"].ToString()].ToString());
                        m_objViewer.ctlDataGrid6[row, 10] = temp.ToString() + "%";
                        m_objViewer.ctlDataGrid6[row, 11] = temp;
                        this.m_objViewer.ctlDataGrid6[row, 9] = objCalPatientCharge.m_mthGetChargeIetmPrice(dr["itemid_chr"].ToString(), m_mthConvertObjToDecimal(dr["itemprice_mny"]),
                        dr["itemopinvtype_chr"].ToString(), m_mthConvertObjToDecimal(dr["recqty"]), 3000, temp, "", false);

                        //项目带项目
                        string strItemID = dr["itemid_chr"].ToString().Trim();
                        DataTable dtRecord = new DataTable();
                        bool blnStat = objSvc.m_blnCheckSubChargeItem(strItemID, out dtRecord);

                        if (blnStat)
                        {
                            m_mthGetChargeItemByItem(row.ToString() + "->" + strItemID, 0, dtRecord);
                            m_objViewer.ctlDataGrid6[row, o_resubitem] = "[PK]" + row.ToString() + "->" + strItemID;
                            m_objViewer.ctlDataGrid6[row, o_MainItemNum] = m_objViewer.ctlDataGrid6[row, o_Count];
                        }

                        this.m_objViewer.ctlDataGrid6[row, o_DeptmedID] = "*";
                    }
                }
                #endregion

                this.m_mthSetFocus();
                this.IsShowOverFlow = true;
                this.m_mthIsOverFlow();
                this.m_mthCalculateTotalMoney();
                this.m_mthFormatDataGrid();
                //DataGrid的Bug,要发送虚拟键才能显示光标
                SendKeys.SendWait("{Up}");
                SendKeys.SendWait("{Down}");
            }
        }
        #endregion

        #region 批添加检验栏诊疗项目
        /// <summary>
        /// 批添加检验栏诊疗项目
        /// </summary>
        /// <param name="DrArr"></param>        
        /// <param name="Type">类型 1 检验 2 检查 3 治疗</param>
        public void m_mthAddOrderItem(ArrayList DrArr, int Type)
        {
            int row = 0;
            long l = 0;
            decimal Nums = 0;
            string OrderID = "";
            string CatID = "";

            DataRow dr;
            for (int i = 0; i < DrArr.Count; i++)
            {
                dr = DrArr[i] as DataRow;

                OrderID = dr["orderdicid_chr"].ToString();
                CatID = dr["ordercateid_chr"].ToString();
                Nums = m_mthConvertObjToDecimal(dr["recqty"]);

                if (Type == 1)
                {
                    if (OrderCatLisArr.IndexOf(CatID) == -1)
                    {
                        continue;
                    }
                    else
                    {

                        for (int i1 = this.m_objViewer.ctlDataGridLis.RowCount - 1; i1 >= 0; i1--)
                        {
                            if (this.m_objViewer.ctlDataGridLis[i1, t_ItemID].ToString() == "")
                            {
                                this.m_objViewer.ctlDataGridLis.m_mthDeleteRow(i1);
                            }
                        }

                        row = m_objViewer.ctlDataGridLis.RowCount;

                        this.m_objViewer.ctlDataGridLis.m_mthAppendRow();
                        m_objViewer.ctlDataGridLis[row, t_Find] = dr["usercode_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Name] = dr["name_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Spec] = dr["itemspec_vchr"].ToString();
                        m_objViewer.ctlDataGridLis[row, t_PartName] = dr["sample_type_desc_vchr"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Unit] = dr["itemunit"].ToString();
                        m_objViewer.ctlDataGridLis[row, t_ItemID] = OrderID;
                        m_objViewer.ctlDataGridLis[row, t_PriceFlag] = dr["lisapplyunitid_chr"].ToString().Trim(); //用自定价格列记录申请单元ID        
                        m_objViewer.ctlDataGridLis[row, t_InvoiceType] = dr["itemopinvtype_chr"].ToString();
                        m_objViewer.ctlDataGridLis[row, t_EnglishName] = dr["engname_vchr"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Temp] = dr["sample_type_id_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridLis[row, t_Count] = Nums;

                        string PayTypeID = "0001";
                        if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
                        {
                            PayTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
                        }

                        string strReItemID = m_objViewer.ctlDataGridLis[row, t_resubitem].ToString().Trim();

                        decimal decScale = 1;
                        bool blnCheckDiscount = false;
                        if (IsAllowDiscount)
                        {
                            blnCheckDiscount = this.objSvc.m_blnCheckOrderDiscount(OrderID, DiscountInvoCatArr, 1, DiscountItemNus);
                            if (blnCheckDiscount)
                            {
                                decScale = DiscountScale / 100;
                            }
                        }

                        decimal TotalMny = 0;
                        decimal SbMny = 0;
                        DataTable dtRecord;
                        l = this.objSvc.m_lngGetChargeItemByOrderID(OrderID, PayTypeID, out dtRecord);
                        if (strReItemID.StartsWith("[PK]"))
                        {
                            m_mthGetChargeItemByOrderItem(strReItemID.Replace("[PK]", ""), "", "", -1, null, "lis", out TotalMny, out SbMny, 1, 0);
                            this.hasOrderID.Remove("lis->" + strReItemID.Replace("[PK]", ""));
                        }

                        m_objViewer.ctlDataGridLis[row, t_resubitem] = "";
                        m_objViewer.ctlDataGridLis[row, t_MainItemNum] = 0;

                        if (l > 0 && dtRecord.Rows.Count > 0)
                        {
                            m_mthGetChargeItemByOrderItem(row.ToString() + "->" + OrderID, dr["itemid_chr"].ToString(), dr["usageid_chr"].ToString(), 0, dtRecord, "lis", out TotalMny, out SbMny, decScale, Nums);
                            m_objViewer.ctlDataGridLis[row, t_resubitem] = "[PK]" + row.ToString() + "->" + OrderID;
                            m_objViewer.ctlDataGridLis[row, t_MainItemNum] = m_objViewer.ctlDataGridLis[row, t_Count];

                            //修改为折上折比例
                            if (decScale != 1)
                            {
                                for (int j = 0; j < dtRecord.Rows.Count; j++)
                                {
                                    dtRecord.Rows[i]["precent_dec"] = m_mthConvertObjToDecimal(dtRecord.Rows[i]["precent_dec"]) * decScale;
                                }
                            }

                            clsOrder_VO Order_VO = new clsOrder_VO();
                            Order_VO.OrderDR = dr;
                            Order_VO.EntryDT = dtRecord;
                            if (!hasOrderID.ContainsKey("lis->" + row.ToString() + "->" + OrderID))
                            {
                                hasOrderID.Add("lis->" + row.ToString() + "->" + OrderID, Order_VO);
                            }
                            m_objViewer.ctlDataGridLis[row, t_Price] = TotalMny.ToString();
                            m_objViewer.ctlDataGridLis[row, t_SumMoney] = SbMny.ToString();
                            if (TotalMny != SbMny)
                            {
                                m_objViewer.ctlDataGridLis[row, t_DiscountName] = "打折";
                            }
                            m_objViewer.ctlDataGridLis[row, t_Discount] = SbMny; //记录基数金额
                        }


                        m_objViewer.ctlDataGridLis.CurrentCell = new DataGridCell(row, t_Find);

                    }
                }
                else if (Type == 2)
                {
                    if (OrderCatTestArr.IndexOf(CatID) == -1)
                    {
                        continue;
                    }
                    else
                    {

                        for (int i1 = this.m_objViewer.ctlDataGridTest.RowCount - 1; i1 >= 0; i1--)
                        {
                            if (this.m_objViewer.ctlDataGridTest[i1, t_ItemID].ToString() == "")
                            {
                                this.m_objViewer.ctlDataGridTest.m_mthDeleteRow(i1);
                            }
                        }

                        row = m_objViewer.ctlDataGridTest.RowCount;

                        this.m_objViewer.ctlDataGridTest.m_mthAppendRow();
                        m_objViewer.ctlDataGridTest[row, t_Find] = dr["usercode_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Name] = dr["name_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Spec] = dr["itemspec_vchr"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_PartName] = dr["partname"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Unit] = dr["itemunit"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Price] = "";
                        m_objViewer.ctlDataGridTest[row, t_ItemID] = OrderID;
                        m_objViewer.ctlDataGridTest[row, t_PriceFlag] = dr["applytypeid_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_DiscountName] = "";//比例
                        m_objViewer.ctlDataGridTest[row, t_Discount] = "";
                        m_objViewer.ctlDataGridTest[row, t_InvoiceType] = dr["itemopinvtype_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_EnglishName] = dr["engname_vchr"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Temp] = dr["partid_vchr"].ToString().Trim();
                        m_objViewer.ctlDataGridTest[row, t_Count] = Nums;
                        m_objViewer.ctlDataGridTest[row, t_UsageID] = dr["usageid_chr"].ToString().Trim();

                        string strReItemID = m_objViewer.ctlDataGridTest[row, t_resubitem].ToString().Trim();
                        string PayTypeID = "0001";
                        if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
                        {
                            PayTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
                        }

                        decimal TotalMny = 0;
                        decimal SbMny = 0;
                        DataTable dtRecord;
                        l = this.objSvc.m_lngGetChargeItemByOrderID(OrderID, PayTypeID, out dtRecord);
                        if (strReItemID.StartsWith("[PK]"))
                        {
                            m_mthGetChargeItemByOrderItem(strReItemID.Replace("[PK]", ""), null, null, -1, null, "test", out TotalMny, out SbMny, 1, 0);
                            this.hasOrderID.Remove("test->" + strReItemID.Replace("[PK]", ""));
                        }

                        m_objViewer.ctlDataGridTest[row, t_resubitem] = "";
                        m_objViewer.ctlDataGridTest[row, t_MainItemNum] = 0;

                        if (l > 0 && dtRecord.Rows.Count > 0)
                        {
                            m_mthGetChargeItemByOrderItem(row.ToString() + "->" + OrderID, dr["itemid_chr"].ToString(), dr["usageid_chr"].ToString(), 0, dtRecord, "test", out TotalMny, out SbMny, 1, Nums);
                            m_objViewer.ctlDataGridTest[row, t_resubitem] = "[PK]" + row.ToString() + "->" + OrderID;
                            m_objViewer.ctlDataGridTest[row, t_MainItemNum] = m_objViewer.ctlDataGridTest[row, t_Count];

                            clsOrder_VO Order_VO = new clsOrder_VO();
                            Order_VO.OrderDR = dr;
                            Order_VO.EntryDT = dtRecord;
                            hasOrderID.Add("test->" + row.ToString() + "->" + OrderID, Order_VO);

                            m_objViewer.ctlDataGridTest[row, t_Price] = TotalMny.ToString();
                            m_objViewer.ctlDataGridTest[row, t_SumMoney] = SbMny.ToString();
                            if (TotalMny != SbMny)
                            {
                                m_objViewer.ctlDataGridTest[row, t_DiscountName] = "打折";
                            }
                            m_objViewer.ctlDataGridTest[row, t_Discount] = SbMny;
                        }

                        m_objViewer.ctlDataGridTest.CurrentCell = new DataGridCell(row, t_Find);
                    }

                }
                else if (Type == 3)
                {
                    if (OrderCatOpsArr.IndexOf(CatID) == -1)
                    {
                        continue;
                    }
                    else
                    {

                        for (int i1 = this.m_objViewer.ctlDataGridOps.RowCount - 1; i1 >= 0; i1--)
                        {
                            if (this.m_objViewer.ctlDataGridOps[i1, o_ItemID].ToString() == "")
                            {
                                this.m_objViewer.ctlDataGridOps.m_mthDeleteRow(i1);
                            }
                        }

                        row = m_objViewer.ctlDataGridOps.RowCount;

                        this.m_objViewer.ctlDataGridOps.m_mthAppendRow();
                        m_objViewer.ctlDataGridOps[row, o_Find] = dr["usercode_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_Name] = dr["name_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_Spec] = dr["itemspec_vchr"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_Unit] = dr["itemunit"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_Price] = "";
                        m_objViewer.ctlDataGridOps[row, o_ItemID] = OrderID;
                        m_objViewer.ctlDataGridOps[row, o_PriceFlag] = dr["applytypeid_chr"].ToString().Trim();  //用自定义价格列存申请单类型
                        m_objViewer.ctlDataGridOps[row, o_DiscountName] = "";//比例
                        m_objViewer.ctlDataGridOps[row, o_Discount] = "";
                        m_objViewer.ctlDataGridOps[row, o_InvoiceType] = dr["itemopinvtype_chr"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_EnglishName] = dr["engname_vchr"].ToString().Trim();
                        m_objViewer.ctlDataGridOps[row, o_Count] = Nums;
                        m_objViewer.ctlDataGridOps[row, o_UsageID] = dr["usageid_chr"].ToString().Trim();

                        string strReItemID = m_objViewer.ctlDataGridOps[row, o_resubitem].ToString().Trim();
                        string PayTypeID = "0001";
                        if (this.m_objViewer.m_PatInfo.PayTypeID.Trim() != "")
                        {
                            PayTypeID = this.m_objViewer.m_PatInfo.PayTypeID.Trim();
                        }

                        decimal TotalMny = 0;
                        decimal SbMny = 0;
                        DataTable dtRecord;
                        l = this.objSvc.m_lngGetChargeItemByOrderID(OrderID, PayTypeID, out dtRecord);
                        if (strReItemID.StartsWith("[PK]"))
                        {
                            m_mthGetChargeItemByOrderItem(strReItemID.Replace("[PK]", ""), null, null, -1, null, "ops", out TotalMny, out SbMny, 1, 0);
                            this.hasOrderID.Remove("ops->" + strReItemID.Replace("[PK]", ""));
                        }

                        m_objViewer.ctlDataGridOps[row, o_resubitem] = "";
                        m_objViewer.ctlDataGridOps[row, o_MainItemNum] = 0;

                        if (l > 0 && dtRecord.Rows.Count > 0)
                        {
                            m_mthGetChargeItemByOrderItem(row.ToString() + "->" + OrderID, dr["itemid_chr"].ToString(), dr["usageid_chr"].ToString(), 0, dtRecord, "ops", out TotalMny, out SbMny, 1, Nums);
                            m_objViewer.ctlDataGridOps[row, o_resubitem] = "[PK]" + row.ToString() + "->" + OrderID;
                            m_objViewer.ctlDataGridOps[row, o_MainItemNum] = m_objViewer.ctlDataGridOps[row, o_Count];

                            clsOrder_VO Order_VO = new clsOrder_VO();
                            Order_VO.OrderDR = dr;
                            Order_VO.EntryDT = dtRecord;
                            hasOrderID.Add("ops->" + row.ToString() + "->" + OrderID, Order_VO);

                            m_objViewer.ctlDataGridOps[row, o_Price] = TotalMny.ToString();
                            m_objViewer.ctlDataGridOps[row, o_SumMoney] = SbMny.ToString();
                            if (TotalMny != SbMny)
                            {
                                m_objViewer.ctlDataGridOps[row, o_DiscountName] = "打折";
                            }
                            m_objViewer.ctlDataGridOps[row, o_Discount] = SbMny; //记录基数金额
                        }

                        m_objViewer.ctlDataGridOps.CurrentCell = new DataGridCell(row, o_Find);
                    }
                }
            }
        }
        #endregion

        #region 生成协定处方
        /// <summary>
        /// 生成协定处方
        /// </summary>
        public void m_mthCreateAccordRecipe()
        {
            this.m_mthClearDataEmptyRow();

            int row = 0;
            int location = -1;

            if (this.m_objViewer.ctlDataGrid1.RowCount > 0)
            {
                location = 0;
            }
            else if (this.m_objViewer.ctlDataGrid2.RowCount > 0)
            {
                location = 1;
            }
            else if (this.m_objViewer.ctlDataGridLis.RowCount > 0)
            {
                location = 2;
            }
            else if (this.m_objViewer.ctlDataGridTest.RowCount > 0)
            {
                location = 3;
            }
            else if (this.m_objViewer.ctlDataGridOps.RowCount > 0)
            {
                location = 4;
            }
            else if (this.m_objViewer.ctlDataGrid6.RowCount > 0)
            {
                location = 5;
            }

            if (location < 0)
            {
                MessageBox.Show("当前没有处方信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmAccordRecipeEdit f = new frmAccordRecipeEdit(this.m_objViewer.ctlDataGrid1, this.m_objViewer.ctlDataGrid2, this.m_objViewer.ctlDataGridLis, this.m_objViewer.ctlDataGridTest, this.m_objViewer.ctlDataGridOps, this.m_objViewer.ctlDataGrid6, location);
            f.ShowDialog();
        }
        #endregion

        #region 判断是否是东莞市医保病人
        /// <summary>
        /// 判断是否是东莞市医保病人
        /// </summary>
        public void m_mthCheckYBPayType()
        {
            IsDongGuanYBPatient = false;

            if (YBPayTypeArr.Count > 0 && this.m_objViewer.m_PatInfo.PayTypeID.ToString().Trim() != "")
            {
                if (YBPayTypeArr.IndexOf(this.m_objViewer.m_PatInfo.PayTypeID) >= 0)
                {
                    IsDongGuanYBPatient = true;
                }
            }
        }
        #endregion

        #region 检查是否非本人处方
        /// <summary>
        /// 检查是否非本人处方
        /// </summary>
        /// <param name="p_strRecipeID"></param>
        /// <returns></returns>
        public bool m_blnCheckRecipe(string p_strRecipeID)
        {
            DataTable dt;
            long l = this.objSvc.m_lngGetRecipeMainInfo(p_strRecipeID, out dt);
            if (l > 0)
            {
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["diagdr_chr"].ToString().Trim() != this.m_objViewer.LoginInfo.m_strEmpID)
                    {
                        MessageBox.Show("非本人处方，不能操作。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }
            }
            return true;
        }
        #endregion

        #region 先诊疗后结算---结算接口
        /// <summary>
        /// 先诊疗后结算---结算接口
        /// </summary>
        public void m_mthPayBillTrade()
        {
            //组合xml，供一体机接口调用
            string strPateintID = this.m_objViewer.LoginInfo.m_strEmpID;
            string strRegisterID = this.m_objViewer.m_PatInfo.RegisterID;
            string strTotalMny = Convert.ToDecimal(this.m_objViewer.lbeSumMoney.Text.ToString()).ToString("#.00");
            string strSelMny = string.Empty;
            if (string.IsNullOrEmpty(this.m_objViewer.lbeSelfPay.Text.ToString()))
            {
                strSelMny = "0";
            }
            else
            {
                strSelMny = Convert.ToDecimal(this.m_objViewer.lbeSelfPay.Text.ToString()).ToString("#.00");
            }
            string strSBMny = string.Empty;
            if (string.IsNullOrEmpty(this.m_objViewer.lbeSbAccPay.Text.ToString()))
            {
                strSBMny = "0";
            }
            else
            {
                strSBMny = Convert.ToDecimal(this.m_objViewer.lbeSbAccPay.Text.ToString()).ToString("#.00");
            }
            string strJSRQ = DateTime.Now.ToShortDateString();
            string strOutPatientRecipe = "";
            if (this.m_objViewer.btSave.Tag != null)
            {
                strOutPatientRecipe = this.m_objViewer.btSave.Tag.ToString().Trim();
            }
            else
            {
                MessageBox.Show("处方号为空");
            }
            string strINput = @"<Request>
                            <RegisterArea>0001598</RegisterArea>
                            <PatientID>" + strPateintID + @"</PatientID>
                            <GZZFFS>1</GZZFFS>
                            <TreaID>" + strRegisterID + @"</TreaID>
                            <Item>
                                <JZJLH></JZJLH>
                                <SDYWH></SDYWH>
                                <YLFYZE>" + strTotalMny + @"</YLFYZE >
                                <JBYLTCZF>" + strSBMny + @"</JBYLTCZF>
                                <GRZFZE>" + strSelMny + @"</GRZFZE>
                                <TreaID>" + strRegisterID + @"</TreaID>
                                <JSRQ>" + strJSRQ + @"</JSRQ>
                                <JISFS></JISFS>
                                <RegID>" + strRegisterID + @"</RegID>
                                <CFID>" + strOutPatientRecipe + @"</CFID>
                                <ZFYY></ZFYY>
                                <JZLB>1</JZLB>
                            </Item>
                            <UserID>" + this.m_objViewer.LoginInfo.m_strEmpNo + @"</UserID>
                        </Request>";
            //反射
            string path = Application.StartupPath + @"\HISTreatMentFirst.dll";
            System.Reflection.Assembly a = System.Reflection.Assembly.LoadFrom(path);
            System.Reflection.MethodInfo m = a.GetType("com.digitalwave.iCare.gui.HIS.clsPcteCtl").GetMethod("strPayBillTrade");
            object sss = m.Invoke(System.Activator.CreateInstance(a.GetType("com.digitalwave.iCare.gui.HIS.clsPcteCtl")), new object[] { strINput });
            MessageBox.Show(sss.ToString(), "提示");
            try
            {
                //  clsControlDoctorCharge obj = new clsControlDoctorCharge();
                //   obj.strPayBillTrade(strINput);
            }
            catch (Exception objEX)
            {
                com.digitalwave.Utility.clsLogText obj = new com.digitalwave.Utility.clsLogText();
                obj.LogError(objEX);
            }
        }
        #endregion

        #region 显示病人欠费弹窗
        /// <summary>
        /// 显示病人欠费弹窗
        /// </summary>
        /// <param name="p_strCard"></param>
        public void m_mthShowDebtMessage(string p_strCard)
        {
            DataTable dtResult = new DataTable();
            this.objSvc.m_lngGetVipDebtByCard(p_strCard, out dtResult);
            if (dtResult.Rows.Count != 0)
            {
                frmDM = new frmDebtMessage(dtResult);
                frmDM.Show();
                blnIfDMShow = true;
            }
        }
        #endregion

        #region 判断是某个药品的药品类型是否在9003中
        /// <summary>
        /// 判断是某个药品的药品类型是否在9003中
        /// </summary>
        /// <param name="p_strMedicineId"></param>
        /// <returns></returns>
        public bool blMedicine9003(string p_strMedicineId)
        {
            bool blMedicine = false;
            blMedicine = objSvc.blMedicine9003(p_strMedicineId);
            return blMedicine;
        }
        #endregion

        #region GetDrugInfo
        /// <summary>
        /// GetDrugInfo
        /// </summary>
        internal void GetDrugInfo()
        {
            string itemId = string.Empty;
            if (this.m_objViewer.tabControl1.SelectedTab == this.m_objViewer.tabPage5)
            {
                itemId = this.m_objViewer.ctlDataGrid1[this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber, c_ItemID].ToString().Trim();
            }
            else if (this.m_objViewer.tabControl1.SelectedTab == this.m_objViewer.tabPage6)
            {
                itemId = this.m_objViewer.ctlDataGrid2[this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber, 8].ToString().Trim();
            }
            if (!string.IsNullOrEmpty(itemId) && this.IsUseMedItf)
            {
                using (Hisitf.RationalDrugUseItf itf = new Hisitf.RationalDrugUseItf())
                {
                    itf.GetMedInfo(this.DrugServiceUrl, itemId);
                }
            }
        }
        #endregion

        #region WechatPost
        /// <summary>
        /// WechatPost
        /// </summary>
        public void WechatPost()
        {
            if (string.IsNullOrEmpty(this.m_objViewer.m_PatInfo.PatientCardID)) return;
            if (string.IsNullOrEmpty(this.WechatWebUrl)) return;

            if (this.objSvc.IsWechatBanding(this.m_objViewer.m_PatInfo.PatientCardID))
            {
                try
                {
                    string xmlData = string.Empty;
                    xmlData += "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + Environment.NewLine;
                    xmlData += "<req>" + Environment.NewLine;
                    xmlData += string.Format("<eventNo>{0}</eventNo>", "41332004413") + Environment.NewLine;
                    xmlData += string.Format("<eventType>{0}</eventType>", "outpatientPay") + Environment.NewLine;
                    xmlData += "<eventData>" + Environment.NewLine;
                    xmlData += string.Format("<clinicSeq>{0}</clinicSeq>", this.m_objViewer.m_PatInfo.PatientID + DateTime.Now.ToString("yyyyMMdd")) + Environment.NewLine;
                    xmlData += string.Format("<clinicTime>{0}</clinicTime>", DateTime.Now.ToString("yyyy-MM-dd HH:mm")) + Environment.NewLine;
                    xmlData += string.Format("<deptId>{0}</deptId>", this.m_objViewer.m_PatInfo.DeptID) + Environment.NewLine;
                    xmlData += string.Format("<deptName>{0}</deptName>", this.m_objViewer.m_PatInfo.DeptName) + Environment.NewLine;
                    xmlData += string.Format("<doctorId>{0}</doctorId>", this.m_objViewer.m_PatInfo.DoctorID) + Environment.NewLine;
                    xmlData += string.Format("<doctorName>{0}</doctorName>", this.m_objViewer.m_PatInfo.DoctorName) + Environment.NewLine;
                    xmlData += string.Format("<patientId>{0}</patientId>", this.m_objViewer.m_PatInfo.PatientID) + Environment.NewLine;
                    xmlData += string.Format("<patientName>{0}</patientName>", this.m_objViewer.m_PatInfo.PatientName) + Environment.NewLine;
                    xmlData += string.Format("<healthCardNo>{0}</healthCardNo>", this.m_objViewer.m_PatInfo.PatientCardID) + Environment.NewLine;
                    xmlData += string.Format("<phone>{0}</phone>", "") + Environment.NewLine;
                    xmlData += string.Format("<settleCode>{0}</settleCode>", this.m_objViewer.m_PatInfo.PayTypeID) + Environment.NewLine;
                    xmlData += string.Format("<settleType>{0}</settleType>", this.m_objViewer.m_PatInfo.PayTypeName) + Environment.NewLine;
                    xmlData += "</eventData>" + Environment.NewLine;
                    xmlData += "</req>" + Environment.NewLine;

                    byte[] dataArray = System.Text.Encoding.Default.GetBytes(xmlData);
                    //创建请求
                    HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(this.WechatWebUrl);
                    request.Method = "POST";
                    request.ContentLength = dataArray.Length;
                    //创建输入流
                    Stream dataStream = null;
                    try
                    {
                        dataStream = request.GetRequestStream();
                    }
                    catch
                    {
                        return;
                    }
                    //发送请求
                    dataStream.Write(dataArray, 0, dataArray.Length);
                    dataStream.Close();
                }
                catch
                {

                }
            }
        }
        #endregion

        #region DgPlatformPost

        /// <summary>
        /// 平台已发.CardNo
        /// </summary>
        List<string> lstPlatPostCardNo = new List<string>();

        /// <summary>
        /// 东莞市预约平台POST信息 (1.患者签到; 2. 门诊登记; 3.完成就医通知)
        /// </summary>
        /// <param name="typeId">1.患者签到; 2. 门诊登记; 3.完成就医通知</param>
        internal void DgPlatformPost(int typeId)
        {
            DgPlatformPost(typeId, "");
        }
        /// <summary>
        /// 东莞市预约平台POST信息 (1.患者签到; 2. 门诊登记; 3.完成就医通知)
        /// </summary>
        /// <param name="typeId">1.患者签到; 2. 门诊登记; 3.完成就医通知</param>
        internal void DgPlatformPost(int typeId, string recipeId)
        {
            if (this.IsUseDgPlatformNotice == false) return;

            string cardNo = this.m_objViewer.m_PatInfo.PatientCardID;
            if (string.IsNullOrEmpty(cardNo)) return;

            bool is900581 = false;
            string request = string.Empty;
            string response = string.Empty;
            DataTable dt = null;
            //if (this.objSvc.IsWechatBanding(cardNo))
            //{
            try
            {
                decimal bookingNo = 0;
                string psOrderNum = string.Empty;
                string doctCode = string.Empty;
                string regDate = DateTime.Now.ToString("yyyy-MM-dd");
                if (this.objSvc.IsWechatPlatformBooking(cardNo, regDate, recipeId, out bookingNo, out psOrderNum, out doctCode))
                {
                    WechatService wechatSvc = new WechatService();
                    if (typeId == 1)    // 患者签到
                    {
                        if (lstPlatPostCardNo.IndexOf(cardNo) < 0)
                        {
                            lstPlatPostCardNo.Add(cardNo);
                            request = "<request>" + Environment.NewLine;
                            request += string.Format("<regDate>{0}</regDate>", regDate) + Environment.NewLine;
                            request += string.Format("<psOrderNum>{0}</psOrderNum>", psOrderNum) + Environment.NewLine;
                            request += string.Format("<patName>{0}</patName>", this.m_objViewer.m_PatInfo.PatientName) + Environment.NewLine;
                            request += "</request>";
                            response = wechatSvc.DgPlatFormAccess("900521", request);
                        }
                    }
                    else if (typeId == 2)   // 门诊登记
                    {
                        string deptCode = this.objSvc.GetDeptCode(this.m_objViewer.m_PatInfo.DeptID);
                        request = "<request>" + Environment.NewLine;
                        request += string.Format("<deptCode>{0}</deptCode>", deptCode) + Environment.NewLine;
                        request += string.Format("<recipeNo>{0}</recipeNo>", recipeId) + Environment.NewLine;
                        request += string.Format("<bookingNo>{0}</bookingNo>", bookingNo) + Environment.NewLine;
                        request += string.Format("<psOrderNum>{0}</psOrderNum>", psOrderNum) + Environment.NewLine;
                        request += string.Format("<doctCode>{0}</doctCode>", doctCode) + Environment.NewLine;
                        request += "</request>";
                        response = wechatSvc.DgPlatFormAccess("900581", request);
                        if (!string.IsNullOrEmpty(response) && clsPublic.ConvertObjToDecimal(response.Split('|')[0]) == 0) // 成功
                        {
                            dt = this.objSvc.GetTodayRegInfo(recipeId);
                            if (dt != null && dt.Rows.Count > 0)
                            {
                                this.objSvc.UpdateTodayPlatformSendDate(Convert.ToDecimal(dt.Rows[0]["serno"].ToString()));
                            }
                        }
                        is900581 = true;
                    }
                    else if (typeId == 3)   // 完成就医通知
                    {
                        request = "<request>" + Environment.NewLine;
                        request += string.Format("<doctCode>{0}</doctCode>", doctCode) + Environment.NewLine;
                        request += string.Format("<regDate>{0}</regDate>", regDate) + Environment.NewLine;
                        request += string.Format("<psOrderNum>{0}</psOrderNum>", psOrderNum) + Environment.NewLine;
                        request += string.Format("<patName>{0}</patName>", this.m_objViewer.m_PatInfo.PatientName) + Environment.NewLine;
                        request += "</request>";
                        response = wechatSvc.DgPlatFormAccess("900541", request);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Output(ex.Message + Environment.NewLine + response);
            }
            //}
            if (typeId == 2 && is900581 == false)
            {
                try
                {
                    if (this.objSvc.UpdateTodayPlatformRecipe(this.m_objViewer.LoginInfo.m_strEmpID, recipeId))
                    {
                        dt = this.objSvc.GetTodayRegInfo(recipeId);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            DataRow dr = dt.Rows[0];
                            request = "<request>" + Environment.NewLine;
                            request += string.Format("<patName>{0}</patName>", dr["patName"].ToString()) + Environment.NewLine;
                            request += string.Format("<idNo>{0}</idNo>", dr["idNo"].ToString()) + Environment.NewLine;
                            request += string.Format("<cardNo>{0}</cardNo>", dr["cardNo"].ToString()) + Environment.NewLine;
                            request += string.Format("<sex>{0}</sex>", dr["sex"].ToString()) + Environment.NewLine;
                            request += string.Format("<contactTel>{0}</contactTel>", dr["contactTel"].ToString()) + Environment.NewLine;
                            request += string.Format("<deptCode>{0}</deptCode>", dr["deptCode"].ToString()) + Environment.NewLine;
                            request += string.Format("<recipeNo>{0}</recipeNo>", recipeId) + Environment.NewLine;
                            request += string.Format("<psOrderNum>{0}</psOrderNum>", dr["subscribeno"].ToString()) + Environment.NewLine;
                            request += string.Format("<doctCode>{0}</doctCode>", dr["doctCode"].ToString()) + Environment.NewLine;
                            request += "</request>";
                            WechatService wechatSvc = new WechatService();
                            response = wechatSvc.DgPlatFormAccess("900581", request);
                            if (!string.IsNullOrEmpty(response) && clsPublic.ConvertObjToDecimal(response.Split('|')[0]) == 0) // 成功
                            {
                                this.objSvc.UpdateTodayPlatformSendDate(Convert.ToDecimal(dr["serno"].ToString()));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Output(ex.Message + Environment.NewLine + response);
                }
            }
        }
        #endregion

        #region 预约

        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]
            public string lpData;
        }

        [System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint = "SendMessage")]
        static extern int SendMessage(
        int hWnd,  //  handle  to  destination  window  
        int Msg,  //  message  
        int wParam,  //  first  message  parameter  
        ref  COPYDATASTRUCT lParam  //  second  message  parameter  
        );
        [System.Runtime.InteropServices.DllImport("User32.dll", EntryPoint = "FindWindow")]
        static extern int FindWindow(string lpClassName, string lpWindowName);

        /// <summary>
        /// 预约
        /// </summary>
        internal void RegBooking()
        {
            int WINDOW_HANDLER = FindWindow(null, "weCare医院信息服务平台");
            if (WINDOW_HANDLER == 0)
            {
                MessageBox.Show("不能打开预约界面，请联系信息科。");
            }
            else
            {
                string funcCode = this.m_objViewer.MdiParent.Text + "-->" + "start" + "-->" + "Registration.Ui.frmRegisterB|预约挂号|registration.ui.dll|Show";
                byte[] sarr = System.Text.Encoding.Default.GetBytes(funcCode);
                int len = sarr.Length;

                COPYDATASTRUCT cds;
                cds.dwData = (IntPtr)100;
                cds.lpData = funcCode;
                cds.cbData = len + 1;
                SendMessage(WINDOW_HANDLER, 0x004A, 0, ref  cds);
            }
        }
        #endregion
    }

    #region 本地类

    #region 项目变动比较类
    /// <summary>
    /// 项目变动比较类
    /// </summary>
    public class clsItemCompare_VO
    {
        public string ItemID = "";
        public string ItemName = "";
        public string O_ItemStandard = "";
        public string N_ItemStandard = "";
        public string O_ItemDosageUnit = "";
        public string N_ItemDosageUnit = "";
        public string O_ItemPrice = "";
        public string N_ItemPrice = "";
    }
    #endregion

    #region 诊疗项目类
    /// <summary>
    /// 诊疗项目类
    /// </summary>
    public class clsOrder_VO
    {
        /// <summary>
        /// 主诊疗项目DR
        /// </summary>
        public DataRow OrderDR = null;
        /// <summary>
        /// 明细收费项目信息
        /// </summary>
        public DataTable EntryDT = null;
    }
    #endregion

    #endregion
}

