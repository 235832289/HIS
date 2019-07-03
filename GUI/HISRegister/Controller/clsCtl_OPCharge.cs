using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using com.digitalwave.iCare.gui.LIS;
using com.digitalwave.iCare.middletier.HI;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// clsCtl_OPCharge 的摘要说明。
    /// </summary>
    public class clsCtl_OPCharge : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 需要检测库存的药品类型ID，中药是1，西药是2。。。
        /// </summary>
        private ArrayList m_objNeedCheckArr = null;
        /// <summary>
        /// 
        /// </summary>
        internal bool m_blnSecondStockLimitFlag = false;
        /// <summary>
        /// 自动扣减药房理论库存的方式 1 按入库时间；2 按有效期；3 先按入库时间再按有效期；4 先按有效期再按入库时间
        /// </summary>
        internal string m_strDeductType = "1";
        private clsDcl_OPCharge objSvc = null;
        /// <summary>
        /// 全局变量,如果已经收费处方就为false,否则为true
        /// </summary>
        public bool IsReadOnly = true;
        /// <summary>
        /// 西药房ID
        /// </summary>
        private string strWMedicineStoreID = "0001";
        /// <summary>
        /// 中药房ID
        /// </summary>
        private string strCMedicineStoreID = "0003";
        /// <summary>
        /// 西药窗口ID
        /// </summary>
        private string strWMedicineWindowID = "0001";
        /// <summary>
        /// 中药窗口ID
        /// </summary>
        private string strCMedicineWindowID = "0001";
        /// <summary>
        /// 材料库ID
        /// </summary>
        private string strMaterialStoreID = "0001";
        /// <summary>
        /// 材料窗口ID
        /// </summary>
        private string strMaterialWindowID = "0001";

        /// <summary>
        /// 发票规则
        /// </summary>
        private string strInvoiceExpression = "";
        /// <summary>
        /// 发药单打印机名称
        /// </summary>
        private string strSendMedicinePrinterName = "";
        /// <summary>
        /// 记录是那一家医院收费(只是慢病医院适用)
        /// </summary>
        public string strHopitalID = "0";
        /// <summary>
        /// 判断能否修改医生开的处方
        /// </summary>
        private bool IsCanModify = true;
        /// <summary>
        /// 判断是否可以修改医生所开处方正、副方属性
        /// </summary>
        private bool IsModifyrecipetype = false;
        /// <summary>
        /// 判断是否显示缺药 true 显示,false不显示
        /// </summary>
        private bool isShowLackMedicine = true;
        /// <summary>
        /// 判断是否结算收款员处方
        /// </summary>
        internal bool IsChargeReceiverRec = true;
        /// <summary>
        /// 是否能转账,true 能
        /// </summary>
        internal bool IsCanTurn = true;
        /// <summary>
        /// 是否能自定义比例,true 可以,false 不可以
        /// </summary>
        internal bool IsDiscount = true;
        /// <summary>
        /// 是否启用让利,1 可以,0 不可以
        /// 让利开关
        /// </summary>
        internal int intDiffPriceOn = 0;

        /// <summary>
        /// Hashtable对象，保存处方信息。在生成新计费对象时清空。
        /// </summary>
        internal Hashtable objHashTable = null;
        /// <summary>
        /// 关联项目ID列
        /// </summary>
        private const int ResubitemCol = 27;
        /// <summary>
        /// 项目带出基数列
        /// </summary>
        private const int ResubnumsCol = 28;
        /// <summary>
        /// 用法项目ID列
        /// </summary>
        private const int UsageitemCol = 29;
        /// <summary>
        /// 用法带出基数列
        /// </summary>
        private const int UsagenumsCol = 30;
        /// <summary>
        /// 科室自备药标志
        /// </summary>
        private const int Deptmed = 31;
        /// <summary>
        /// 诊疗项目ID
        /// </summary>
        private const int OrderID = 32;
        /// <summary>
        /// 诊疗项目基数
        /// </summary>
        private const int OrderNum = 33;
        /// <summary>
        /// 默认带出列
        /// </summary>
        private const int DefaultCol = 35;
        /// <summary>
        /// 让利总金额列 
        /// </summary>
        private const int intDiffPriceTotalCol = 37;
        /// <summary>
        /// 让利单价列 
        /// </summary>
        private const int intDiffUnitPriceCol = 38;
        /// <summary>
        /// 默认带出项目时是否删除上次计费项
        /// </summary>
        private bool IsChrgFlag = true;
        /// <summary>
        /// 主处方信息
        /// </summary>
        private ArrayList m_objMainRecipeList;
        /// <summary>
        /// 中药处方信息
        /// </summary>
        private ArrayList m_objCMSendList;
        /// <summary>
        /// 西药处方信息
        /// </summary>
        private ArrayList m_objWMSendList;
        /// <summary>
        /// XML文件名
        /// </summary>
        private string XMLFile = System.Windows.Forms.Application.StartupPath + @"\LoginFile.xml";

        /// <summary>
        /// 多张处方合计状态标志
        /// </summary>
        private bool Recsumflag = false;
        /// <summary>
        /// 医保数据库连接参数(DB2)
        /// </summary>
        private string DB2Parm = "";
        /// <summary>
        /// 医保数据库连接参数(SQL SERVER)
        /// </summary>
        private string SQLParm = "";
        /// <summary>
        /// DBF DBQ
        /// </summary>
        private string DBQ = "";
        /// <summary>
        /// (医保)医院代码
        /// </summary>
        private string Hospcode = "";
        /// <summary>
        /// (医保)费用类型
        /// </summary>
        private ArrayList arrPaytype;
        /// <summary>
        /// 医保用Hash表
        /// </summary>
        private Hashtable HasYB = null;
        /// <summary>
        /// 医保记帐单号
        /// </summary>
        internal string BillNO = "";
        /// <summary>
        /// 药房专用窗口是否可以接收所有科室处方 true 接收 false 禁止
        /// </summary>
        private bool Ismedwinpublic;
        /// <summary>
        /// 批量计算(如计算整张处方)控制
        /// </summary>
        private bool BathCalc = false;
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
        /// <summary>
        /// 001 佛山市 002 东莞市 003 佛山顺德区
        /// </summary>
        internal string YBType = "001";
        /// <summary>
        /// 收费处ID
        /// </summary>
        private string SDYBMzbm = "";
        /// <summary>
        /// 收费员录处方模式
        /// </summary>
        internal bool EmpInputMode = false;
        /// <summary>
        /// 凑整规则 0 不凑整 1 四舍五入到角 2 凑整到角 3 凑整到元
        /// </summary>
        internal string RoundingRule = "0";
        /// <summary>
        /// 凑整代码
        /// </summary>
        internal string RoundingCode = "";
        /// <summary>
        /// 是否是东莞市门诊医保身份（费别）
        /// </summary>
        internal bool IsDongGuanYBPatient = false;
        /// <summary>
        /// 东莞市门诊医保身份（费别）对应ID (数组)
        /// </summary>
        private ArrayList YBPayTypeArr = new ArrayList();
        /// <summary>
        /// 东莞市门诊医保病人：门诊医生工作站、收费处是否显示全自费的收费项目
        /// </summary>
        private bool YBIsShowSelfItem = false;
        /// <summary>
        /// 体检收费工作站 true 是 false 否
        /// </summary>
        internal bool PEWorkStationFlag = false;
        /// <summary>
        /// 体检号
        /// </summary>
        internal string PERegisterNoArr = "";

        /// <summary>
        /// 0077门诊收费处材料是否发送到材料房 0-否；1是
        /// </summary>
        private int m_intFlag = 0;
        /// <summary>
        /// 针对分院收费假死现象，药品是否发生到药房 1-正常发生，0-不发送
        /// </summary>
        private int m_intIsOrNotSendMed = 0;
        /// <summary>
        /// 选择交费的项目id
        /// </summary>
        internal Dictionary<string, List<string>> m_dicSelectChargeItemID = null;
        #endregion

        #region 读ini文件
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileStringA")]
        public static extern int GetPrivateProfileString(string lpApplicationName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        #endregion

        #region 判断发票是否能重复
        private bool isCanDo = false;
        /// <summary>
        /// 判断发票是否能重复
        /// </summary>
        public bool InvoiceCanRepeat
        {
            get
            {
                return isCanDo;
            }
        }
        private bool _IsPrintSendMedicineBill = false;
        /// <summary>
        /// 判断是否打印发药单
        /// </summary>
        public bool IsPrintSendMedicineBill
        {
            get
            {
                return _IsPrintSendMedicineBill;
            }
        }
        #endregion
        /// <summary>
        /// 是否显示收费员姓名信息 0-不显示;1-显示
        /// </summary>
        private string m_strShowOPChargeManInfo = string.Empty;
        public clsCtl_OPCharge()
        {
            objSvc = new clsDcl_OPCharge();
            objHashTable = new Hashtable();
            m_objMainRecipeList = new ArrayList();
            m_objCMSendList = new ArrayList(); ;
            m_objWMSendList = new ArrayList(); ;
            //
            // TODO: 在此处添加构造函数逻辑
            //
        }

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmOPCharge m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOPCharge)frmMDI_Child_Base_in;
        }
        #endregion

        #region 存取发票号
        //		private  string m_strConfigFilePath="InvoiceNO.bin";
        public void m_strReadMedwinID()
        {
            try
            {
                string patXML = Application.StartupPath + "\\LoginFile.xml";
                if (File.Exists(patXML))
                {
                    string strCurrEmpNO = "AnyOne";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(patXML);
                    XmlNode xn = doc.DocumentElement.SelectNodes(@"//register")[0];
                    XmlNode xnCurr = xn.SelectSingleNode(@"//WMedicinestore[@key='" + strCurrEmpNO + @"']");
                    if (xnCurr != null)
                    {
                        this.strWMedicineStoreID = xnCurr.Attributes["value"].Value.ToString();
                        this.strWMedicineWindowID = xnCurr.Attributes["windows"].Value.ToString();
                    }
                    xnCurr = xn.SelectSingleNode(@"//CMedicinestore[@key='" + strCurrEmpNO + @"']");
                    if (xnCurr != null)
                    {
                        this.strCMedicineStoreID = xnCurr.Attributes["value"].Value.ToString();
                        this.strCMedicineWindowID = xnCurr.Attributes["windows"].Value.ToString();
                    }
                    xnCurr = xn.SelectSingleNode(@"//MaterialStore[@key='" + strCurrEmpNO + @"']");
                    if (xnCurr != null)
                    {
                        this.strMaterialStoreID = xnCurr.Attributes["value"].Value.ToString();
                        this.strMaterialWindowID = xnCurr.Attributes["windows"].Value.ToString();
                    }
                    xn = doc.DocumentElement.SelectNodes(@"//Printer")[0];
                    xnCurr = xn.SelectSingleNode(@"//SendMedicine");
                    if (xnCurr != null)
                    {
                        this.strSendMedicinePrinterName = xnCurr.Attributes["PrinterName"].Value.ToString();
                    }
                    if (this.strInvoiceExpression.Trim() == "")
                    {
                        xn = doc.DocumentElement.SelectSingleNode("InvoiceExpression");
                        this.strInvoiceExpression = xn.InnerText;
                    }

                    #region 药品是否发送到药房 2011-9-5 by zxm
                    xnCurr = xn.SelectSingleNode(@"//IsOrNotSendMed[@key='" + strCurrEmpNO + @"']");
                    if (xnCurr != null)
                    {
                        this.m_intIsOrNotSendMed = Convert.ToInt32(xnCurr.Attributes["value"].Value.ToString().Trim());
                    }
                    #endregion


                }
            }
            catch
            {
            }
        }
        public string m_strReadInvoiceNO()
        {
            string invono = "";

            try
            {
                string patXML = Application.StartupPath + "\\LoginFile.xml";
                if (File.Exists(patXML))
                {
                    string strCurrEmpNO = "AnyOne";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(patXML);
                    XmlNode xn = doc.DocumentElement.SelectNodes(@"//register")[0];
                    XmlNode xnCurr = xn.SelectSingleNode(@"//InvoiceNo[@key='" + strCurrEmpNO + @"']");
                    if (xnCurr != null)
                    {
                        int maxint = Convert.ToInt32(xnCurr.Attributes["value"].Value.Substring(2, 8)) + 1;
                        invono = xnCurr.Attributes["value"].Value.Substring(0, 2) + maxint.ToString("00000000");
                    }
                    else
                    {
                        invono = "DW00000001";

                    }
                    if (this.strInvoiceExpression.Trim() == "")
                    {
                        xn = doc.DocumentElement.SelectSingleNode("InvoiceExpression");
                        this.strInvoiceExpression = xn.InnerText;
                    }
                }
            }
            catch
            {
                invono = "DW00000001";
            }

            return invono;
        }

        public void m_mthSaveInvoiceNO(string strInvoiceNO)
        {
            m_objViewer.m_txtInvoiceNO.Text = strInvoiceNO;
            string strTemp = "0000000000";
            try
            {
                int maxint = Convert.ToInt32(strInvoiceNO.Substring(2, 8)) - 1;
                strTemp = strInvoiceNO.Substring(0, 2) + maxint.ToString("00000000");
            }
            catch { }

            if (!(this.m_blnWriteXML("register", "InvoiceNo", "AnyOne", strTemp)))
            {
                MessageBox.Show("\t保存发票号失败,\n请检查\"" + XMLFile + "\"是否只读!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        #region 产生一个新的计费类对象
        public clsCalcPatientCharge objCalPatientCharge = null;
        /// <summary>
        /// 产生一个新的计费类对象
        /// </summary>
        public void m_mthCreatCalObj()
        {
            //把当前病人ID传递到查找处方信息控件。
            this.m_objViewer.txtLoadRecipeNO.PatientID = this.m_objViewer.m_PatientBasicInfo.PatientID;
            //把按钮变为可用状态。
            this.m_mthSetControlEnable(true);
            //把支付类型还原来默认状态
            this.m_objViewer.m_cmbPayMode.SelectedIndex = 0;
            //把处方类型还原来默认状态
            this.m_objViewer.m_cmbRecipeType.SelectedIndex = 0;
            //生成一个新的计费对象
            this.m_mthCreatNewCalobj();
            this.m_objViewer.btSave.Tag = null;
            //从计费类获取收费明细，收费明细保存了在收费类中的一个对象(VO)
            this.m_mthDisplayCharge();
            SumRecipeCount = 0;
            SumTotalMoney = 0;
            SumChargeUpMoney = 0;
            this.strSumChargeUpMoney = "";
            this.strSumPersonMoney = "";
            this.strSumTotalMoney = "";
            SumPersonMoney = 0;
            RecipeCountThisTime = 0;
        }
        /// <summary>
        /// 差生一个新的计费类
        /// </summary>
        private void m_mthCreatNewCalobj()
        {
            this.objHashTable.Clear();
            objCalPatientCharge = null;
            objCalPatientCharge = new clsCalcPatientCharge(m_objViewer.m_PatientBasicInfo.PatientID, m_objViewer.m_PatientBasicInfo.PayTypeID, m_objViewer.m_PatientBasicInfo.Limit, this.m_objComInfo.m_strGetHospitalTitle(), m_objViewer.m_PatientBasicInfo.PatientType, m_objViewer.m_PatientBasicInfo.Discount);
            if (this.m_objViewer.panel2.Controls.Count > 0)
            {
                this.objCalPatientCharge.GetDisplayControl = this.m_objViewer.panel2.Controls[0];
            }
            else
            {
                this.m_objViewer.panel2.Controls.Add(this.objCalPatientCharge.GetDisplayControl);
            }
            this.m_objViewer.ctlDataGrid1.m_mthDeleteAllRow();
            m_objViewer.numericUpDown1.Value = 1;
            // 设置计费类中的让利开关
            if (this.intDiffPriceOn == 1)
                objCalPatientCharge.ObjMain.m_blnDiffCostOn = true;
            else
                objCalPatientCharge.ObjMain.m_blnDiffCostOn = false;
        }
        #endregion

        #region 判断是否让利
        /// <summary>
        /// 判断是否让利
        /// </summary>
        /// <param name="rowNo"></param>
        /// <returns></returns>
        bool CheckIsDiff(int rowNo)
        {
            if (m_objViewer.ctlDataGrid1[rowNo, 10] != null && m_objViewer.ctlDataGrid1[rowNo, 10].ToString().Trim() != string.Empty)
                return blMedicine9003(m_objViewer.ctlDataGrid1[rowNo, 10].ToString());
            else
                return false;
        }
        /// <summary>
        /// 是否让利
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        bool CheckIsDiff(string itemId)
        {
            if (!string.IsNullOrEmpty(itemId))
                return blMedicine9003(itemId);
            else
                return false;
        }
        #endregion

        #region 查找药品
        /// <summary>
        /// 查找药品
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int m_mthFindMedicineByID(string strType, string ID)
        {
            int ret = 0;
            DataTable dt = null;
            string strpayID = "0001";
            if (this.m_objViewer.m_PatientBasicInfo.PayTypeID.Trim() != "")
            {
                strpayID = this.m_objViewer.m_PatientBasicInfo.PayTypeID.Trim();
            }
            long strRet = objSvc.m_mthFindMedicineByID(strType, ID, strpayID, out dt, this.m_objViewer.LoginInfo.m_strEmpID);
            if (strRet > 0 && dt.Rows.Count > 0)
            {
                if (dt.Rows.Count == 1 && blnSinglechrgitem)
                {
                    ret = dt.Rows.Count;
                    int row = m_objViewer.rowNO;
                    //					int row =m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
                    if (dt.Rows[0]["noqtyflag_int"].ToString().Trim() != "" && dt.Rows[0]["noqtyflag_int"].ToString().Trim() != "0" && m_mthIsMedicine(dt.Rows[0]["itemopinvtype_chr"].ToString().Trim()))
                    {
                        //if (isShowLackMedicine)
                        //{

                        //    if (MessageBox.Show("缺药!是否继续?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                        //    {
                        //        return 0;
                        //    }
                        //}
                        //else
                        //{
                        MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
                        return 0;
                        //}

                    }

                    //东莞门诊医保
                    if (!YBIsShowSelfItem && IsDongGuanYBPatient)
                    {
                        if (dt.Rows[0]["precent_dec"].ToString().Trim() == "100")
                        {
                            return ret;
                        }
                    }

                    string strCurrItem = m_objViewer.ctlDataGrid1[row, 10].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 0] = dt.Rows[0]["tempitemcode"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 2] = dt.Rows[0]["itemname_vchr"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 3] = m_mthConvertToChType(dt.Rows[0]["itemopinvtype_chr"].ToString().Trim());
                    m_objViewer.ctlDataGrid1[row, 4] = dt.Rows[0]["itemspec_vchr"].ToString().Trim();
                    //如果不是药品或其他项目，使用非药品单位
                    string strTemp = m_mthRelationInfo(dt.Rows[0]["itemopinvtype_chr"].ToString().Trim());
                    if (strTemp != "0001" && strTemp != "0002" && strTemp != "0005")//非药时取另一个单位
                    {
                        m_objViewer.ctlDataGrid1[row, 5] = dt.Rows[0]["unit"].ToString().Trim();
                        m_objViewer.ctlDataGrid1[row, 6] = dt.Rows[0]["itemprice_mny"].ToString().Trim();
                    }
                    else
                    {
                        if (/*m_mthIsMedicine(dt.Rows[0]["itemopinvtype_chr"].ToString().Trim()) && */dt.Rows[0]["opchargeflg_int"].ToString().Trim() == "1")
                        {
                            m_objViewer.ctlDataGrid1[row, 5] = dt.Rows[0]["itemipunit_chr"].ToString().Trim();
                            m_objViewer.ctlDataGrid1[row, 6] = dt.Rows[0]["submoney"].ToString().Trim();
                            m_objViewer.ctlDataGrid1[row, intDiffUnitPriceCol] = dt.Rows[0]["subtrademoney"].ToString().Trim();     // 批发单位单价
                        }
                        else
                        {
                            m_objViewer.ctlDataGrid1[row, 5] = dt.Rows[0]["itemopunit_chr"].ToString().Trim();
                            m_objViewer.ctlDataGrid1[row, 6] = dt.Rows[0]["itemprice_mny"].ToString().Trim();
                            m_objViewer.ctlDataGrid1[row, intDiffUnitPriceCol] = dt.Rows[0]["tradeprice_mny"].ToString().Trim();    // 批发单价
                        }
                    }
                    m_objViewer.ctlDataGrid1[row, 36] = dt.Rows[0]["opchargeflg_int"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 8] = dt.Rows[0]["itemopinvtype_chr"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 9] = m_mthRelationInfo(dt.Rows[0]["itemopinvtype_chr"].ToString().Trim());
                    if (m_objViewer.ctlDataGrid1[row, 9].ToString() != "0001" && m_objViewer.ctlDataGrid1[row, 9].ToString() != "0002")//非药时，取另一单位
                    {
                        m_objViewer.ctlDataGrid1[row, 5] = dt.Rows[0]["unit"].ToString().Trim();
                        m_objViewer.ctlDataGrid1[row, 6] = dt.Rows[0]["itemprice_mny"].ToString().Trim();
                    }

                    m_objViewer.ctlDataGrid1[row, 10] = dt.Rows[0]["itemid_chr"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 11] = dt.Rows[0]["selfdefine_int"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 15] = dt.Rows[0]["itemopcalctype_chr"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 16] = 0;
                    m_objViewer.ctlDataGrid1[row, 17] = "";
                    m_objViewer.ctlDataGrid1[row, 18] = "";
                    m_objViewer.ctlDataGrid1[row, 21] = dt.Rows[0]["dosageunit_chr"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, "colYbcode"] = dt.Rows[0]["insuranceid_chr"].ToString().Trim();

                    string strPRECENT_DEC = "100";
                    if (dt.Rows[0]["precent_dec"].ToString().Trim() != "")
                    {
                        strPRECENT_DEC = dt.Rows[0]["precent_dec"].ToString().Trim();
                    }
                    m_objViewer.ctlDataGrid1[row, 13] = strPRECENT_DEC + "%";
                    m_objViewer.ctlDataGrid1[row, 14] = this.m_mthConvertObjToDecimal(strPRECENT_DEC);

                    if (m_objViewer.ctlDataGrid1[row, 12].ToString().Trim() != "")
                    {
                        m_objViewer.IsSave = false;
                    }

                    m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, 1);
                    m_objViewer.ctlDataGrid1[row, 0] = dt.Rows[0]["tempitemcode"].ToString().Trim();
                }
                else
                {
                    this.m_objViewer.listView1.BeginUpdate();
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

                        ListViewItem lv = new ListViewItem(dt.Rows[i]["type"].ToString().Trim());////查询码
                        lv.SubItems.Add(dt.Rows[i]["itemcode_vchr"].ToString().Trim());//查询码
                        lv.SubItems.Add(dt.Rows[i]["itemname_vchr"].ToString().Trim());//名称
                        lv.SubItems.Add(dt.Rows[i]["itemengname_vchr"].ToString().Trim());// 英文名
                        lv.SubItems.Add(m_mthConvertToChType(dt.Rows[i]["itemopinvtype_chr"].ToString().Trim()));//类型
                        lv.SubItems.Add(dt.Rows[i]["itemspec_vchr"].ToString().Trim());//规格
                        //如果是西药而已用的是最小单位,就用小单价和住院最小单位
                        //string strTemp = m_mthRelationInfo(dt.Rows[i]["itemopinvtype_chr"].ToString().Trim());
                        //if (strTemp != "0001" && strTemp != "0002" && strTemp != "0005")//非药时取另一个单位
                        //{
                        //    lv.SubItems.Add(dt.Rows[i]["unit"].ToString().Trim());//单价
                        //    lv.SubItems.Add(dt.Rows[i]["itemprice_mny"].ToString().Trim());//单价
                        //}
                        //else
                        //{
                        //    if (m_mthIsMedicine(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString()) && dt.Rows[i]["OPCHARGEFLG_INT"].ToString().Trim() == "1")
                        //    {
                        //        lv.SubItems.Add(dt.Rows[i]["itemipunit_chr"].ToString().Trim());//单位
                        //        lv.SubItems.Add(dt.Rows[i]["submoney"].ToString().Trim());//单价
                        //    }
                        //    else
                        //    {
                        //        lv.SubItems.Add(dt.Rows[i]["itemopunit_chr"].ToString().Trim());//单位
                        //        lv.SubItems.Add(dt.Rows[i]["itemprice_mny"].ToString().Trim());//单价
                        //    }
                        //}
                        //如果不是药品或其他项目，使用非药品单位
                        string strTemp = m_mthRelationInfo(dt.Rows[i]["itemopinvtype_chr"].ToString().Trim());
                        if (strTemp != "0001" && strTemp != "0002" && strTemp != "0005")//非药时取另一个单位
                        {
                            lv.SubItems.Add(dt.Rows[i]["unit"].ToString().Trim());//单价
                            lv.SubItems.Add(dt.Rows[i]["itemprice_mny"].ToString().Trim());//单价
                        }
                        else  //如果是药品或其他项目，使用设定的门诊收费单位
                        {
                            if (/*m_mthIsMedicine(dt.Rows[i]["itemopinvtype_chr"].ToString().Trim()) && */dt.Rows[i]["opchargeflg_int"].ToString().Trim() == "1")
                            {
                                lv.SubItems.Add(dt.Rows[i]["itemipunit_chr"].ToString().Trim());//单位
                                lv.SubItems.Add(dt.Rows[i]["submoney"].ToString().Trim());//单价
                            }
                            else
                            {
                                lv.SubItems.Add(dt.Rows[i]["itemopunit_chr"].ToString().Trim());//单位
                                lv.SubItems.Add(dt.Rows[i]["itemprice_mny"].ToString().Trim());//单价
                            }
                        }
                        string strPRECENT_DEC = "100";
                        if (dt.Rows[i]["precent_dec"].ToString().Trim() != "")
                        {
                            strPRECENT_DEC = dt.Rows[i]["precent_dec"].ToString().Trim();
                        }
                        lv.SubItems.Add(strPRECENT_DEC + "%");//收费比例
                        lv.SubItems.Add("");
                        //if (dt.Rows[i]["noqtyflag_int"].ToString().Trim() != "" && dt.Rows[i]["noqtyflag_int"].ToString().Trim() != "0" && m_mthIsMedicine(dt.Rows[i]["itemopinvtype_chr"].ToString().Trim()))
                        //{
                        //    if (!isShowLackMedicine)
                        //    {
                        //        continue;
                        //    }

                        //    lv.SubItems.Add("缺药");
                        //    lv.ForeColor = Color.Red;
                        //    lv.SubItems.Add("");//是否缺药
                        //}
                        //else
                        //{
                        //    lv.SubItems.Add("");//是否缺药
                        //}
                        //						lv.SubItems.Add(dt.Rows[i]["ITEMOPINVTYPE_CHR"].ToString().Trim());//门诊发票核算类别
                        //						lv.SubItems.Add(dt.Rows[i]["ITEMCATID_CHR"].ToString().Trim());//收费项目分类ID
                        //						lv.SubItems.Add(dt.Rows[i]["SELFDEFINE_INT"].ToString().Trim());//是否自定义价格
                        lv.Tag = dt.Rows[i];
                        m_objViewer.listView1.Items.Add(lv);
                    }
                    this.m_objViewer.listView1.EndUpdate();
                    if (m_objViewer.listView1.Items.Count > 0)
                    {
                        m_objViewer.listView1.Height = 175;
                        m_objViewer.listView1.Visible = true;
                        m_objViewer.listView1.Items[0].Selected = true;
                        m_objViewer.listView1.Select();
                        m_objViewer.listView1.Focus();
                        //填充listView
                    }
                    else
                    {
                        MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
                    }
                }
            }
            else
            {
                MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
            }
            return ret;
        }

        public int m_mthFindMedicineByIDAcc(string strType, string ID)
        {
            int ret = 0;
            DataTable dt = null;
            string strpayID = "0001";
            if (this.m_objViewer.m_PatientBasicInfo.PayTypeID.Trim() != "")
            {
                strpayID = this.m_objViewer.m_PatientBasicInfo.PayTypeID.Trim();
            }
            long strRet = objSvc.m_mthFindMedicineByID(strType, ID, strpayID, out dt, this.m_objViewer.LoginInfo.m_strEmpID);
            if (strRet > 0 && dt.Rows.Count == 1)
            {
                ret = dt.Rows.Count;
                int row = m_objViewer.rowNO;
                if (dt.Rows[0]["NOQTYFLAG_INT"].ToString().Trim() != "0" && m_mthIsMedicine(dt.Rows[0]["ITEMOPINVTYPE_CHR"].ToString().Trim()))
                {
                    //if (isShowLackMedicine)
                    //{

                    //    if (MessageBox.Show("缺药!是否继续?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    //    {
                    //        return 0;
                    //    }
                    //}
                    //else
                    //{
                    MessageBox.Show("对不起！找不到任何收费项目。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ((com.digitalwave.controls.datagrid.clsColumnInfo)m_objViewer.ctlDataGrid1.Columns[0]).DataGridTextBoxColumn.TextBox.SelectAll();
                    return 0;
                    //}

                }
                string strCurrItem = m_objViewer.ctlDataGrid1[row, 10].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 0] = dt.Rows[0]["TempItemCode"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 2] = dt.Rows[0]["ITEMNAME_VCHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 3] = m_mthConvertToChType(dt.Rows[0]["ITEMOPINVTYPE_CHR"].ToString().Trim());
                m_objViewer.ctlDataGrid1[row, 4] = dt.Rows[0]["ITEMSPEC_VCHR"].ToString().Trim();
                //如果是西药而已用的是最小单位,就用小单价和住院最小单位
                if (m_mthIsMedicine(dt.Rows[0]["ITEMOPINVTYPE_CHR"].ToString().Trim()) && dt.Rows[0]["OPCHARGEFLG_INT"].ToString().Trim() == "1")
                {
                    m_objViewer.ctlDataGrid1[row, 5] = dt.Rows[0]["ITEMIPUNIT_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 6] = dt.Rows[0]["SUBMONEY"].ToString().Trim();
                }
                else
                {
                    m_objViewer.ctlDataGrid1[row, 5] = dt.Rows[0]["ITEMOPUNIT_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 6] = dt.Rows[0]["ITEMPRICE_MNY"].ToString().Trim();
                }
                m_objViewer.ctlDataGrid1[row, 8] = dt.Rows[0]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 9] = m_mthRelationInfo(dt.Rows[0]["ITEMOPINVTYPE_CHR"].ToString().Trim());
                if (m_objViewer.ctlDataGrid1[row, 9].ToString() != "0001" && m_objViewer.ctlDataGrid1[row, 9].ToString() != "0002")//非药时，取另一单位
                {
                    m_objViewer.ctlDataGrid1[row, 5] = dt.Rows[0]["Unit"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 6] = dt.Rows[0]["ITEMPRICE_MNY"].ToString().Trim();
                }

                m_objViewer.ctlDataGrid1[row, 10] = dt.Rows[0]["ITEMID_CHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 11] = dt.Rows[0]["SELFDEFINE_INT"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 15] = dt.Rows[0]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 16] = 0;
                m_objViewer.ctlDataGrid1[row, 17] = "";
                m_objViewer.ctlDataGrid1[row, 18] = "";
                m_objViewer.ctlDataGrid1[row, 21] = dt.Rows[0]["DOSAGEUNIT_CHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, "colYbcode"] = dt.Rows[0]["insuranceid_chr"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 36] = dt.Rows[0]["opchargeflg_int"].ToString().Trim();
                string strPRECENT_DEC = "100";
                if (dt.Rows[0]["PRECENT_DEC"].ToString().Trim() != "")
                {
                    strPRECENT_DEC = dt.Rows[0]["PRECENT_DEC"].ToString().Trim();
                }
                m_objViewer.ctlDataGrid1[row, 13] = strPRECENT_DEC + "%";
                m_objViewer.ctlDataGrid1[row, 14] = this.m_mthConvertObjToDecimal(strPRECENT_DEC);
                if (m_objViewer.ctlDataGrid1[row, 12].ToString().Trim() != "")
                {
                    m_objViewer.IsSave = false;
                }

                m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, 1);
                m_objViewer.ctlDataGrid1[row, 0] = dt.Rows[0]["TempItemCode"].ToString().Trim();
            }
            return ret;
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
            //			switch(strTypeNo)
            //			{
            //				case "0002":
            //					strRet="中药";
            //					break;
            //				case "0003":
            //					strRet="检验";
            //					break;
            //				case "0004":
            //					strRet="治疗";
            //					break;
            //				case "0005":
            //					strRet="其他";
            //					break;
            //				case "0006":
            //					strRet="手术";
            //					break;
            //				default:
            //				strRet="西药";
            //					break;
            //			}
            return strRet;
        }
        #endregion

        #region 加载项目分类
        private clsChargeItemEXType_VO[] objResult = null;
        public void m_mthLoadCat()
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

        #region 获取窗口名
        public void m_mthGetWindowName()
        {
            DataTable dtbWinName;
            objSvc.m_mthGetWindowName(out dtbWinName);
            DataRow[] dr = dtbWinName.Select("windowid_chr='" + m_objViewer.strEmergencyMedStoreTWindow + "'");
            if (dr != null && dr.Length > 0)
            {
                m_objViewer.strEmergencyTWinName = dr[0]["windowname_vchr"].ToString();
            }
            dr = null;
            dr = dtbWinName.Select("windowid_chr='" + m_objViewer.strEmergencyMedStoreSWindow + "'");
            if (dr != null && dr.Length > 0)
            {
                m_objViewer.strEmergencySWinName = dr[0]["windowname_vchr"].ToString();
            }
            dr = null;
            dr = dtbWinName.Select("windowid_chr='" + m_objViewer.strSpecialTWinName + "'");
            if (dr != null && dr.Length > 0)
            {
                m_objViewer.strSpecialTWinName = dr[0]["windowname_vchr"].ToString();
            }
            dr = null;
            dr = dtbWinName.Select("windowid_chr='" + m_objViewer.strSpecialSWinName + "'");
            if (dr != null && dr.Length > 0)
            {
                m_objViewer.strSpecialSWinName = dr[0]["windowname_vchr"].ToString();
            }
        }
        #endregion

        #region listview的双击事件
        public void m_mthListViewDoubleClick()
        {
            if (m_objViewer.listView1.SelectedItems.Count > 0 || m_objViewer.listView1.SelectedItems[0].ForeColor != Color.Red)
            {
                if (m_objViewer.listView1.SelectedItems[0].Tag == null)
                {
                    return;
                }

                DataRow dt = (DataRow)this.m_objViewer.listView1.SelectedItems[0].Tag;
                int row = m_objViewer.rowNO;

                string strCurrItem = m_objViewer.ctlDataGrid1[row, 10].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 0] = dt["tempitemcode"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 2] = dt["itemname_vchr"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 3] = m_mthConvertToChType(dt["itemopinvtype_chr"].ToString().Trim());
                m_objViewer.ctlDataGrid1[row, 4] = dt["itemspec_vchr"].ToString().Trim();
                //如果是西药而已用的是最小单位,就用小单价和住院最小单位
                string strTemp = m_mthRelationInfo(dt["itemopinvtype_chr"].ToString().Trim());
                if (strTemp != "0001" && strTemp != "0002" && strTemp != "0005")//非药时取另一个单位
                {
                    m_objViewer.ctlDataGrid1[row, 5] = dt["unit"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 6] = dt["itemprice_mny"].ToString().Trim();
                }
                else
                {
                    if (/*m_mthIsMedicine(dt["itemopinvtype_chr"].ToString().Trim()) && */dt["opchargeflg_int"].ToString().Trim() == "1")
                    {
                        m_objViewer.ctlDataGrid1[row, 5] = dt["itemipunit_chr"].ToString().Trim();
                        m_objViewer.ctlDataGrid1[row, 6] = dt["submoney"].ToString().Trim();
                        m_objViewer.ctlDataGrid1[row, intDiffUnitPriceCol] = dt["subtrademoney"].ToString().Trim();
                    }
                    else
                    {
                        m_objViewer.ctlDataGrid1[row, 5] = dt["itemopunit_chr"].ToString().Trim();
                        m_objViewer.ctlDataGrid1[row, 6] = dt["itemprice_mny"].ToString().Trim();
                        m_objViewer.ctlDataGrid1[row, intDiffUnitPriceCol] = dt["tradeprice_mny"].ToString().Trim();
                    }
                }
                m_objViewer.ctlDataGrid1[row, 8] = dt["itemopinvtype_chr"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 9] = strTemp; // m_mthRelationInfo(dt["itemopinvtype_chr"].ToString().Trim());
                //if (m_objViewer.ctlDataGrid1[row, 9].ToString() != "0001" && m_objViewer.ctlDataGrid1[row, 9].ToString() != "0002")//非药时，取另一单位
                //{
                //    m_objViewer.ctlDataGrid1[row, 5] = dt["unit"].ToString().Trim();
                //    m_objViewer.ctlDataGrid1[row, 6] = dt["itemprice_mny"].ToString().Trim();
                //}

                m_objViewer.ctlDataGrid1[row, 10] = dt["itemid_chr"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 11] = dt["selfdefine_int"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 15] = dt["itemopcalctype_chr"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 16] = 0;
                m_objViewer.ctlDataGrid1[row, 17] = "";
                m_objViewer.ctlDataGrid1[row, 18] = "";
                m_objViewer.ctlDataGrid1[row, 21] = dt["dosageunit_chr"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 36] = dt["opchargeflg_int"].ToString().Trim();
                string strPRECENT_DEC = "100";
                if (dt["precent_dec"].ToString().Trim() != "")
                {
                    strPRECENT_DEC = dt["precent_dec"].ToString().Trim();
                }
                m_objViewer.ctlDataGrid1[row, 13] = strPRECENT_DEC + "%";
                m_objViewer.ctlDataGrid1[row, 14] = strPRECENT_DEC;
                m_objViewer.ctlDataGrid1[row, "colYbcode"] = dt["insuranceid_chr"].ToString().Trim();

                //0040 判断是否调出关联项目 0-不调； 1-调
                if (this.objSvc.m_mthIsCanDo("0040") == 1)
                {
                    string strItemID = dt["itemid_chr"].ToString().Trim();
                    //自动调出关联的子收费项目			
                    if (strCurrItem != strItemID)
                    {
                        string strpayID = "0001";
                        if (this.m_objViewer.m_PatientBasicInfo.PayTypeID.Trim() != "")
                        {
                            strpayID = this.m_objViewer.m_PatientBasicInfo.PayTypeID.Trim();
                        }

                        string strReItemID = m_objViewer.ctlDataGrid1[row, ResubitemCol].ToString().Trim();
                        DataTable dtRecord = new DataTable();
                        bool blnStat = objSvc.m_blnCheckSubChargeItem(strpayID, strItemID, out dtRecord);

                        if (strReItemID.StartsWith("[PK]"))
                        {
                            m_mthGetChargeItemByItem(strReItemID.Replace("[PK]", ""), -1, null);
                        }

                        m_objViewer.ctlDataGrid1[row, ResubitemCol] = "";
                        m_objViewer.ctlDataGrid1[row, ResubnumsCol] = 0;

                        if (blnStat)
                        {
                            m_mthGetChargeItemByItem(row.ToString() + "->" + strItemID, 0, dtRecord);
                            m_objViewer.ctlDataGrid1[row, ResubitemCol] = "[PK]" + row.ToString() + "->" + strItemID;
                            m_objViewer.ctlDataGrid1[row, ResubnumsCol] = m_objViewer.ctlDataGrid1[row, 1];
                        }
                    }
                }

                m_objViewer.listView1.Height = 0;
                if (m_objViewer.ctlDataGrid1[row, 12].ToString().Trim() != "")
                {
                    m_objViewer.IsSave = false;
                }
                m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, 1);
            }
        }
        #endregion

        #region 剂量改变
        /// <summary>
        /// 剂量改变
        /// </summary>
        /// <param name="strChargeID"></param>
        /// <param name="decPrice"></param>
        /// <param name="ChargeTypeID"></param>
        /// <param name="decDosage"></param>
        /// <param name="rowNo"></param>
        public void m_mthDosageChange(string strChargeID, string decPrice, string ChargeTypeID, string decDosage, int rowNo)
        {
            if (this.objCalPatientCharge == null)
            {
                MessageBox.Show("请先输入病人资料!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (BathCalc)
            {
                return;
            }

            decimal price = m_mthConvertObjToDecimal(decPrice.Trim()), decTradePrice = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[rowNo, intDiffUnitPriceCol].ToString().Trim());
            //if (intDiffPriceOn == 1)// 批发价
            //    price = decTradePrice;
            decimal dosage = m_mthConvertObjToDecimal(decDosage.Trim());
            int row = 2000;

            if (m_objViewer.ctlDataGrid1[rowNo, 12] != null && m_objViewer.ctlDataGrid1[rowNo, 12].ToString().Trim() != "")
            {
                row = int.Parse(m_objViewer.ctlDataGrid1[rowNo, 12].ToString().Trim());
            }

            decimal discount = 100;
            if (m_objViewer.ctlDataGrid1[rowNo, 14] != null && m_objViewer.ctlDataGrid1[rowNo, 14].ToString().Trim() != "")
            {
                discount = Convert.ToDecimal(m_objViewer.ctlDataGrid1[rowNo, 14].ToString().Trim());
            }

            m_objViewer.ctlDataGrid1[rowNo, 1] = dosage;
            if (m_objViewer.ctlDataGrid1[rowNo, 8].ToString().Trim() == objCalPatientCharge.InvoiceCatID)
            {
                dosage = dosage * m_objViewer.numericUpDown1.Value;
                dosage = Math.Ceiling(dosage);
            }

            decimal temp = price * dosage, decDiffPriceTotal = (decTradePrice - price) * dosage;// 总让利金额
            m_objViewer.ctlDataGrid1[rowNo, 7] = m_mthConvertObjToDecimal(temp.ToString("0.00"));
            if (blMedicine9003(m_objViewer.ctlDataGrid1[rowNo, 10].ToString()))// 判断是否是药品  m_mthIsMedicine((m_objViewer.ctlDataGrid1[rowNo, 8].ToString().Trim()))
                m_objViewer.ctlDataGrid1[rowNo, intDiffPriceTotalCol] = m_mthConvertObjToDecimal(decDiffPriceTotal.ToString("0.00"));
            else
            {
                decTradePrice = price;
                m_objViewer.ctlDataGrid1[rowNo, intDiffPriceTotalCol] = 0;
            }

            string strcat = m_objViewer.ctlDataGrid1[rowNo, 15].ToString().Trim();
            if (this.intDiffPriceOn == 1)
                m_objViewer.ctlDataGrid1[rowNo, 12] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strChargeID, price, decTradePrice, ChargeTypeID, dosage, row, discount, strcat, true);
            else
                m_objViewer.ctlDataGrid1[rowNo, 12] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strChargeID, price, ChargeTypeID, dosage, row, discount, strcat, false);
            this.m_mthDisplayCharge();

            if (this.m_objViewer.ctlDataGrid1.CurrentCell.ColumnNumber == 6)
            {
                this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(rowNo, 7);
                this.m_objViewer.ctlDataGrid1[rowNo, 6] = decPrice;
            }
            else
            {
                if (this.m_objViewer.IsSendTabKey)
                {
                    SendKeys.SendWait("{Tab}");
                    if (this.m_objViewer.ctlDataGrid1[rowNo + 1, 0].ToString().Trim() != "")
                    {
                        SendKeys.SendWait("{Tab}");
                    }
                }
            }

            if (!Recsumflag)
            {
                this.m_mthIsOverFlow();
            }

            this.m_objViewer.ctlDataGrid1.Focus();
        }
        /// <summary>
        /// 显示费用明细
        /// </summary>
        private void m_mthDisplayCharge()
        {
            this.objCalPatientCharge.m_mthDisplayCharge();
        }
        #endregion

        #region 保存信息
        /// <summary>
        /// 只保存处方信息
        /// </summary>
        public void m_mthSaveRecipeOnly()
        {
            #region 判断保存条件
            for (int i = m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
            {
                if (m_objViewer.ctlDataGrid1.RowCount == 1 && m_objViewer.ctlDataGrid1[0, 10].ToString().Trim() == "")
                {
                    break;
                }
                if (m_objViewer.ctlDataGrid1[i, 12].ToString().Trim() == "")
                {
                    m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                }

            }
            if (this.m_objViewer.btSave.Tag != null)
            {
                MessageBox.Show("调历史处方无需保存!");
                return;
            }
            else
            {
                if (!this.IsChargeReceiverRec)
                {
                    MessageBox.Show("由于系统当前设置为不能结算收款员所开处方项目，所以不能保存当前处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            clsRecipeDetail_VO[] objRD_VO = new clsRecipeDetail_VO[m_objViewer.ctlDataGrid1.RowCount];
            int intLocation = 0;
            for (int i = 0; i < m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                objRD_VO[intLocation] = new clsRecipeDetail_VO();
                if (m_objViewer.ctlDataGrid1[i, 10] == null || m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() == "")
                {
                    continue;
                }
                if (m_objViewer.ctlDataGrid1[i, 1] == null || m_objViewer.ctlDataGrid1[i, 1].ToString().Trim() == "")
                {
                    MessageBox.Show("数量为空不能保存!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.m_objViewer.ctlDataGrid1.Select();
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(i, 1);
                    return;
                }
                objRD_VO[intLocation].decDiscount = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 14]);
                objRD_VO[intLocation].strRowNO = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 16]).ToString();
                objRD_VO[intLocation].decPrice = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 6]);
                objRD_VO[intLocation].decQuantity = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 1]);
                objRD_VO[intLocation].decSumMoney = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 7]);
                objRD_VO[intLocation].strCharegeItemID = m_objViewer.ctlDataGrid1[intLocation, 10].ToString().Trim();
                objRD_VO[intLocation].strUsageID = m_objViewer.ctlDataGrid1[intLocation, 17].ToString().Trim();
                objRD_VO[intLocation].strFrequencyID = m_objViewer.ctlDataGrid1[intLocation, 18].ToString().Trim();
                objRD_VO[intLocation].strDosage = m_objViewer.ctlDataGrid1[intLocation, 19].ToString().Trim();
                objRD_VO[intLocation].strDays = m_objViewer.ctlDataGrid1[intLocation, 20].ToString().Trim();
                objRD_VO[intLocation].strType = m_objViewer.ctlDataGrid1[intLocation, 9].ToString().Trim();
                objRD_VO[intLocation].strUint = m_objViewer.ctlDataGrid1[intLocation, 5].ToString().Trim();
                objRD_VO[intLocation].strApplyID = m_objViewer.ctlDataGrid1[intLocation, 22].ToString().Trim();
                objRD_VO[intLocation].strCMedicineUsage = m_objViewer.numericUpDown1.Tag.ToString();

                /***附加***/
                objRD_VO[intLocation].strHYPETEST_INT = m_objViewer.ctlDataGrid1[intLocation, 24].ToString().Trim();
                objRD_VO[intLocation].strDESC_VCHR = m_objViewer.ctlDataGrid1[intLocation, 25].ToString().Trim();
                objRD_VO[intLocation].m_strOutpatRecipeID = m_objViewer.ctlDataGrid1[intLocation, 26].ToString().Trim();
                objRD_VO[intLocation].m_strItemspec = m_objViewer.ctlDataGrid1[intLocation, 4].ToString().Trim();
                objRD_VO[intLocation].m_strDosageunit = m_objViewer.ctlDataGrid1[intLocation, 21].ToString().Trim();
                objRD_VO[intLocation].m_strATTACHPARENTID_VCHR = m_objViewer.ctlDataGrid1[intLocation, ResubitemCol].ToString().Trim();
                objRD_VO[intLocation].m_decAttachitembasenum = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, ResubnumsCol]);
                objRD_VO[intLocation].m_strUSAGEPARENTID_VCHR = m_objViewer.ctlDataGrid1[intLocation, UsageitemCol].ToString().Trim();
                objRD_VO[intLocation].m_decUsageitembasenum = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, UsagenumsCol]);
                objRD_VO[intLocation].m_strItemname = m_objViewer.ctlDataGrid1[intLocation, 2].ToString().Trim();
                if (m_objViewer.ctlDataGrid1[intLocation, Deptmed].ToString().Trim() == "1")
                {
                    objRD_VO[intLocation].m_intDeptmed = 1;
                }
                else
                {
                    objRD_VO[intLocation].m_intDeptmed = 0;
                }
                objRD_VO[intLocation].m_strOrderID = m_objViewer.ctlDataGrid1[intLocation, OrderID].ToString().Trim();
                objRD_VO[intLocation].m_decOrderBaseNum = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, OrderNum]);
                /******/

                intLocation++;
            }

            if (objRD_VO.Length == 0)
            {
                return;
            }
            if (objRD_VO[0].strCharegeItemID == null || objRD_VO[0].strCharegeItemID.Trim() == "")//第一行的项目ID为空表示没有收费项目
            {
                return;
            }
            #endregion

            #region 收集主处方信息
            clsOutPatientRecipe_VO OPR_VO = new clsOutPatientRecipe_VO();
            OPR_VO.m_strRecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strEmployeeID = "0000001";
            if (m_objViewer.LoginInfo != null)
            {
                strEmployeeID = m_objViewer.LoginInfo.m_strEmpID;
            }
            //			OPR_VO.m_strOperatorID=m_objViewer.LoginInfo.m_strEmpNo;
            OPR_VO.m_strOperatorID = strEmployeeID;//操作员ID,在未加入权限功能之前,先定义为"0001"
            OPR_VO.m_strRegisterID = m_objViewer.m_PatientBasicInfo.RegisterID;
            OPR_VO.m_strDoctorID = m_objViewer.m_PatientBasicInfo.DoctorID;
            OPR_VO.m_strDepID = m_objViewer.m_PatientBasicInfo.DeptID;
            OPR_VO.m_strCreateDate = m_objViewer.m_PatientBasicInfo.RegisterDate;
            OPR_VO.m_strPatientID = m_objViewer.m_PatientBasicInfo.PatientID;
            OPR_VO.m_intPStatus = 1;//新建
            OPR_VO.m_intType = int.Parse(m_objViewer.m_cmbRecipeType.Tag.ToString());
            OPR_VO.m_strPatientType = m_objViewer.m_PatientBasicInfo.PayTypeID;
            OPR_VO.strIDcard = this.m_objViewer.txtIDcard.Text.Trim();
            //if (OPR_VO.strIDcard == "" || (OPR_VO.strIDcard.Length != 15 && OPR_VO.strIDcard.Length != 18))
            //{
            //    MessageBox.Show("身份证号不能为空并且位数必须是15位或18位，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    this.m_objViewer.txtIDcard.Focus();
            //    return;
            //}  
            OPR_VO.strInsuranceID = this.m_objViewer.txtInsuranceID.Text.Trim();
            if (this.m_objViewer.btSave.Tag != null)
            {
                OPR_VO.m_strOutpatRecipeID = this.m_objViewer.btSave.Tag.ToString();
            }
            else
            {
                OPR_VO.m_strOutpatRecipeID = "";
            }
            #endregion

            string strRecipeID;
            long strRet = objSvc.m_mthAddRecipeMain(OPR_VO, out strRecipeID);
            if (strRet <= 0)
            {
                MessageBox.Show("对不起,保存信息失败。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("保存成功。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.m_mthSaveRecipeDetial(strRecipeID, objRD_VO);
            this.m_mthCreatCalObj();
            this.m_objViewer.txtLoadRecipeNO.m_mthClearText();
            this.m_objViewer.m_PatientBasicInfo.Clear();
            this.m_objViewer.txtIDcard.Text = "";
            this.m_objViewer.txtInsuranceID.Text = "";
            this.m_objViewer.cboProxyBoilMed.SelectedIndex = 0;
            this.m_mthCreatCalObj();
            this.m_objViewer.m_PatientBasicInfo.txtCardID.Focus();
        }
        #region 插入药品发送表
        /// <summary>
        /// 插入药品发送表
        /// </summary>
        /// <returns></returns>
        public long m_mthSaveMedicineSend()
        {
            long lngRes = 0;
            try
            {
                if (m_objMainRecipeList.Count > 0)
                    lngRes = objSvc.m_mthSaveMedicineSend(ref m_objMainRecipeList, ref m_objWMSendList, ref m_objCMSendList);
                if (lngRes > 0)
                {
                    m_objMainRecipeList.Clear();
                    m_objWMSendList.Clear();
                    m_objCMSendList.Clear();
                }
            }
            catch
            {
                m_objMainRecipeList.Clear();
                m_objWMSendList.Clear();
                m_objCMSendList.Clear();
            }
            return lngRes;

        }
        #endregion
        /// <summary>
        /// 保存处方
        /// </summary>
        public long m_mthSaveRecipe(clsPatientChargeCal[] p_objPC)
        {
            bool A = false;
            bool B = false;
            string m_strSerNO = string.Empty;
            ArrayList[] objArr1 = new ArrayList[p_objPC.Length];
            clsInvoice_VO[] objInvoice_VO = new clsInvoice_VO[p_objPC.Length];
            ArrayList[] objArr2 = new ArrayList[p_objPC.Length];
            ArrayList objMedicineSend = new ArrayList();
            //主处方信息
            ArrayList objMainRecipeArr = new ArrayList();
            //处方类型
            ArrayList objRecTypeArr = new ArrayList();
            //药房ID
            ArrayList objMedStoreArr = new ArrayList();
            //发药窗口ID
            ArrayList objMedWinArr = new ArrayList();
            System.Collections.Generic.Dictionary<string, clsMedStoreWindowsVo> m_gdicSpecialMedStore = new System.Collections.Generic.Dictionary<string, clsMedStoreWindowsVo>(5);// -- 固定 5 个。
            //排序号
            ArrayList objSortnoArr = new ArrayList();
            ArrayList objMedStoreType = new ArrayList();
            string pid = this.m_objViewer.m_PatientBasicInfo.PatientID;
            string docdeptid = this.m_objViewer.m_PatientBasicInfo.DeptID;
            clsMedStoreWindowsVo currentMedStoreWindow = null;
            System.Collections.Generic.List<clsMedStoreWindowsVo> m_glstMedStoreVo = new System.Collections.Generic.List<clsMedStoreWindowsVo>();
            string strMainRecipeID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            if (this.objHashTable.Count > 0)//把处方存放第一个处方ID
            {
                strMainRecipeID = ((clsOutPatientRecipe_VO)objHashTable[0]).m_strOutpatRecipeID;

                // 再次校验处方是否已缴费
                clsDcl_OPCharge dclCharge = new clsDcl_OPCharge();
                if (dclCharge.CheckRecipeIsCharge(strMainRecipeID))
                {
                    MessageBox.Show("该处方已经收费，不能重复收费。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                dclCharge = null;
            }

            #region 判断保存条件
            for (int i = m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
            {
                if (m_objViewer.ctlDataGrid1.RowCount == 1 && m_objViewer.ctlDataGrid1[0, 10].ToString().Trim() == "")
                {
                    break;
                }
                if (m_objViewer.ctlDataGrid1[i, 12].ToString().Trim() == "")
                {
                    m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                    continue;
                }
                if (m_objViewer.ctlDataGrid1[i, 26].ToString().Trim() == "")//如果处方为空则填充
                {
                    m_objViewer.ctlDataGrid1[i, 26] = strMainRecipeID;
                }
            }

            //同一种药多药房发检测
            bool mb = this.m_blnCheckmedproperty();

            //明细信息
            clsRecipeDetail_VO[] objRD_VO = new clsRecipeDetail_VO[m_objViewer.ctlDataGrid1.RowCount];
            int intLocation = 0;
            string strChrgItem = "";
            string strMedStoreID = "", strMedStoreIDCurr = "";
            string strMedStoretype = "1";
            string strMedWinID = "";
            int intSortno = 1;
            Hashtable has = new Hashtable();
            for (int i = 0; i < m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                objRD_VO[intLocation] = new clsRecipeDetail_VO();

                if (m_objViewer.ctlDataGrid1[i, 1] == null || m_objViewer.ctlDataGrid1[i, 1].ToString().Trim() == "")
                {
                    MessageBox.Show("剂量为空不能保存!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.m_objViewer.ctlDataGrid1.Select();
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(i, 1);
                    return -1;
                }
                //（收费）项目ID
                strChrgItem = m_objViewer.ctlDataGrid1[intLocation, 10].ToString().Trim();
                objRD_VO[intLocation].strRowNO = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 16]).ToString();
                objRD_VO[intLocation].decDiscount = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 14]);
                objRD_VO[intLocation].decPrice = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 6]);
                objRD_VO[intLocation].decQuantity = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 1]);
                objRD_VO[intLocation].decSumMoney = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 7]);
                objRD_VO[intLocation].strCharegeItemID = strChrgItem;
                objRD_VO[intLocation].strUsageID = m_objViewer.ctlDataGrid1[intLocation, 17].ToString().Trim();
                objRD_VO[intLocation].strFrequencyID = m_objViewer.ctlDataGrid1[intLocation, 18].ToString().Trim();
                objRD_VO[intLocation].strDosage = m_objViewer.ctlDataGrid1[intLocation, 19].ToString().Trim();
                objRD_VO[intLocation].strDays = m_objViewer.ctlDataGrid1[intLocation, 20].ToString().Trim();
                objRD_VO[intLocation].strType = m_objViewer.ctlDataGrid1[intLocation, 9].ToString().Trim();
                objRD_VO[intLocation].strApplyID = m_objViewer.ctlDataGrid1[intLocation, 22].ToString().Trim();
                objRD_VO[intLocation].strCMedicineUsage = m_objViewer.numericUpDown1.Tag.ToString();
                objRD_VO[intLocation].strHYPETEST_INT = m_objViewer.ctlDataGrid1[intLocation, 24].ToString().Trim();
                objRD_VO[intLocation].strDESC_VCHR = m_objViewer.ctlDataGrid1[intLocation, 25].ToString().Trim();
                objRD_VO[intLocation].m_strOutpatRecipeID = m_objViewer.ctlDataGrid1[intLocation, 26].ToString().Trim();
                objRD_VO[intLocation].m_strItemspec = m_objViewer.ctlDataGrid1[intLocation, 4].ToString().Trim();
                objRD_VO[intLocation].m_decDosage = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 19]);
                objRD_VO[intLocation].m_strDosageunit = m_objViewer.ctlDataGrid1[intLocation, 21].ToString().Trim();
                objRD_VO[intLocation].m_strATTACHPARENTID_VCHR = m_objViewer.ctlDataGrid1[intLocation, ResubitemCol].ToString().Trim();
                objRD_VO[intLocation].m_decAttachitembasenum = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, ResubnumsCol]);
                objRD_VO[intLocation].m_strUSAGEPARENTID_VCHR = m_objViewer.ctlDataGrid1[intLocation, UsageitemCol].ToString().Trim();
                objRD_VO[intLocation].m_decUsageitembasenum = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, UsagenumsCol]);
                objRD_VO[intLocation].m_strItemname = m_objViewer.ctlDataGrid1[intLocation, 2].ToString().Trim();
                objRD_VO[intLocation].strUint = m_objViewer.ctlDataGrid1[intLocation, 5].ToString().Trim();
                if (m_objViewer.ctlDataGrid1[intLocation, Deptmed].ToString().Trim() == "1")
                {
                    objRD_VO[intLocation].m_intDeptmed = 1;
                }
                else
                {
                    objRD_VO[intLocation].m_intDeptmed = 0;
                }
                objRD_VO[intLocation].m_strUnitFlag = m_objViewer.ctlDataGrid1[intLocation, 36].ToString().Trim();
                objRD_VO[intLocation].m_strOrderID = m_objViewer.ctlDataGrid1[intLocation, OrderID].ToString().Trim();
                objRD_VO[intLocation].m_decOrderBaseNum = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, OrderNum]);
                // 总让利金额
                if (this.intDiffPriceOn == 1)
                    objRD_VO[intLocation].m_decTolDiffPrice = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, intDiffPriceTotalCol]);

                if (objRD_VO[intLocation].m_decTolDiffPrice == 0)
                    objRD_VO[intLocation].BuyPrice = objRD_VO[intLocation].decPrice;
                else
                    objRD_VO[intLocation].BuyPrice = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, intDiffUnitPriceCol]);

                #region 生成发药参数

                if (objRD_VO[intLocation].m_intDeptmed == 1)
                {
                    strMedStoreIDCurr = "";
                    if (!has.ContainsKey(1))
                    {
                        has.Add(1, 1);
                    }
                }
                else
                {
                    if (!has.ContainsKey(0))
                    {
                        has.Add(0, 0);
                    }
                    //获取药房类型
                    strMedStoretype = objSvc.m_strGetOutSendMedStoretype(strChrgItem);

                    if (strMedStoretype.Trim() == "")
                    {
                        string UsageID = objRD_VO[intLocation].strUsageID;
                        if (UsageID != "")
                        {
                            if (WMUsageIDArr.IndexOf(UsageID) >= 0)
                            {
                                strMedStoretype = "1";//西药房
                            }
                            else if (CMUsageIDArr.IndexOf(UsageID) >= 0)
                            {
                                strMedStoretype = "2";//中药房
                            }
                            else if (MATUsageIDArr.IndexOf(UsageID) >= 0)
                            {
                                strMedStoretype = "3";
                            }
                        }
                    }
                    else
                    {
                        if (strMedStoretype.Trim() != "" && mb)
                        {
                            //中药房
                            strMedStoretype = "2";
                        }
                    }

                    switch (strMedStoretype)
                    {
                        case "1":
                            if (m_intIsOrNotSendMed == 1)
                            {
                                strMedStoreID = "";
                            }
                            else
                            {
                                strMedStoreID = this.m_strReadXML("register", "WMedicinestore", "AnyOne");//西药房ID
                            }
                            break;
                        case "2":
                            if (m_intIsOrNotSendMed == 1)
                            {
                                strMedStoreID = "";
                            }
                            else
                            {
                                strMedStoreID = this.m_strReadXML("register", "CMedicinestore", "AnyOne");//中药房ID
                            }
                            break;
                        case "3":
                            if (m_intIsOrNotSendMed == 1)
                            {
                                strMedStoreID = "";
                            }
                            else
                            {
                                if (m_intFlag == 1)
                                {
                                    strMedStoreID = this.m_strReadXML("register", "MaterialStore", "AnyOne");
                                }
                                else
                                {
                                    strMedStoreID = "";
                                }
                            }
                            break;
                        case "4": /* 中西药房发 -> 西药房发 */
                            if (m_intIsOrNotSendMed == 1)
                            {
                                strMedStoreID = "";
                            }
                            else
                            {
                                strMedStoreID = this.m_strReadXML("register", "WMedicinestore", "AnyOne");
                            }
                            break;
                        default:
                            strMedStoreID = "";
                            break;
                    }

                    //清空strMedStoreIDCurr，以防上次循环留下的药房ID而造成处方所有明细(包括挂号费等等)都往同一个药房发
                    strMedStoreIDCurr = "";

                    #region 下班后普通药房转急诊药房，但门诊普通药房和急诊药房合并后，无需转药房
                    if (m_objViewer.IsDetachWMedStore == 1)
                    {
                        long ret = objSvc.m_lngGetWorkStorage(strMedStoreID, out strMedStoreIDCurr);
                    }
                    #endregion

                    if (strMedStoreIDCurr.Trim() == "")
                    {
                        strMedStoreIDCurr = strMedStoreID;
                    }
                }
                if (strMedStoreIDCurr != "")
                {
                    bool blntmp = false;
                    //(是否合并门、急诊药房，如果分开，则走旧流程) || (中药也走旧流程)
                    if (m_objViewer.IsDetachWMedStore > 0 || strMedStoretype == "2" || strMedStoretype == "3")
                    {
                        //获取当天该患者相同药房窗口 yunjie.xie
                        //strMedWinID = this.m_strGetwinid(pid, strMedStoreIDCurr, out intSortno);
                        currentMedStoreWindow = null;
                        if (m_gdicSpecialMedStore.ContainsKey(strMedStoreIDCurr))
                        {
                            currentMedStoreWindow = m_gdicSpecialMedStore[strMedStoreIDCurr];
                        }
                        else
                        {
                            long l1 = this.objSvc.m_lngGetsendmedinfoBypid(pid, strMedStoreIDCurr, out currentMedStoreWindow);
                            m_gdicSpecialMedStore.Add(strMedStoreIDCurr, currentMedStoreWindow);
                        }

                        if (currentMedStoreWindow != null)
                        {
                            strMedWinID = currentMedStoreWindow.m_strWindowID;
                            intSortno = currentMedStoreWindow.m_intWindowOrderNo;
                        }

                        if (strMedWinID == "")
                        {
                            //同药房的药均发到同一窗口
                            for (int k = 0; k < objMedStoreArr.Count; k++)
                            {
                                if (objMedStoreArr[k].ToString() == strMedStoreIDCurr)
                                {
                                    strMedWinID = objMedWinArr[k].ToString().Trim();
                                    blntmp = true;
                                    break;
                                }
                            }

                            if (!blntmp)
                            {
                                //专门窗口优先
                                //objSvc.m_lngGetespecialwin(docdeptid, strMedStoreIDCurr, out strMedWinID, out intSortno); 
                                objSvc.m_lngGetespecialwinNew(docdeptid, strMedStoreIDCurr, out currentMedStoreWindow);

                                if (currentMedStoreWindow != null)
                                {
                                    strMedWinID = currentMedStoreWindow.m_strWindowID;
                                    intSortno = currentMedStoreWindow.m_intWindowOrderNo;
                                }
                                if (strMedWinID == "")
                                {
                                    //排队窗口
                                    //objSvc.lngGetWindowIDByStorage(strMedStoreIDCurr, out strMedWinID, out intSortno, Ismedwinpublic);
                                    objSvc.lngGetWindowIDByStorage(strMedStoreIDCurr, out currentMedStoreWindow);
                                    if (currentMedStoreWindow != null)
                                    {
                                        strMedWinID = currentMedStoreWindow.m_strWindowID;
                                        intSortno = currentMedStoreWindow.m_intWindowOrderNo;
                                    }
                                }
                            }
                        }

                        #region 判断窗口分配是否成功，并处理是否要将窗口加入数组中(合并门、急诊药房程序后，此处的代码移致后面)
                        //if (strMedWinID == null || strMedWinID.Trim() == "")
                        //{
                        //    //strMedWinID = " ";

                        //    MessageBox.Show("配发药窗口分配失败，请重新操作！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        //    //com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                        //    //objLogger.LogError("分配发药窗口失败 " + strMainRecipeID);
                        //    System.IO.StreamWriter sw = new System.IO.StreamWriter(@"d:\code\medstorewin.log", true);
                        //    sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  RecipeID = '" + strMainRecipeID
                        //                 + "'  ItemID = '" + strChrgItem + "' \r\n");
                        //    sw.Close();
                        //    sw.Dispose();

                        //    return -1;
                        //}

                        //for (int l = 0; l < objMedStoreArr.Count; l++)
                        //{
                        //    if (objMedStoreArr[l].ToString() == strMedStoreIDCurr && objMedWinArr[l].ToString() == strMedWinID)
                        //    {
                        //        blntmp = true;
                        //        break;
                        //    }
                        //}

                        //if (!blntmp)
                        //{
                        //    objRecTypeArr.Add(objRD_VO[intLocation].strType.ToString());
                        //    objMedStoreArr.Add(strMedStoreIDCurr);
                        //    objMedWinArr.Add(strMedWinID);
                        //    objSortnoArr.Add(intSortno);
                        //    objMedStoreType.Add(strMedStoretype);

                        //    m_glstMedStoreVo.Add(currentMedStoreWindow);
                        //}
                        //objRD_VO[intLocation].strMedstroeID = strMedStoreIDCurr;
                        //objRD_VO[intLocation].strWindowsID = strMedWinID;
                        //strMedWinID = "";
                        #endregion
                    }
                    else//合并药房(西药)
                    {
                        //同药房的药均发到同一窗口
                        for (int k = 0; k < objMedStoreArr.Count; k++)
                        {
                            if (objMedStoreArr[k].ToString() == strMedStoreIDCurr)
                            {
                                strMedWinID = objMedWinArr[k].ToString().Trim();
                                blntmp = true;
                                break;
                            }
                        }

                        if (!blntmp)
                        {
                            //急诊收费窗口并且是门诊西药房的药
                            if (m_objViewer.intChargeWindowType == 1 && strMedStoreIDCurr == "0001")
                            {
                                currentMedStoreWindow = new clsMedStoreWindowsVo();
                                currentMedStoreWindow.m_strWindowID = m_objViewer.strEmergencyMedStoreTWindow;
                                currentMedStoreWindow.m_strWindowName = m_objViewer.strEmergencyTWinName;
                                currentMedStoreWindow.m_strSendWindowID = m_objViewer.strEmergencyMedStoreSWindow;
                                currentMedStoreWindow.m_strSendWindowName = m_objViewer.strEmergencySWinName;
                                strMedWinID = currentMedStoreWindow.m_strWindowID;
                                intSortno = currentMedStoreWindow.m_intWindowOrderNo;
                            }
                            else//普通收费窗口
                            {
                                //急诊科病人或特定年龄病人发往专窗(并且是门诊西药房的药)
                                if ((DateTime.Now.AddYears(-m_objViewer.intSpecialPatientAge).CompareTo(DateTime.Parse(m_objViewer.m_PatientBasicInfo.PatientBirth)) >= 0 || docdeptid == m_objViewer.strEmergencyDeptID) && strMedStoreIDCurr == "0001")
                                //if (Convert.ToInt32(m_objViewer.m_PatientBasicInfo.PatientAge) > m_objViewer.intSpecialPatientAge || docdeptid == m_objViewer.strEmergencyDeptID)//急诊科或者特定年龄病人
                                {
                                    currentMedStoreWindow = new clsMedStoreWindowsVo();
                                    currentMedStoreWindow.m_strWindowID = m_objViewer.strSpecialMedStoreTWindow;
                                    currentMedStoreWindow.m_strWindowName = m_objViewer.strSpecialTWinName;
                                    currentMedStoreWindow.m_strSendWindowID = m_objViewer.strSpecialMedStoreSWindow;
                                    currentMedStoreWindow.m_strSendWindowName = m_objViewer.strSpecialSWinName;
                                    strMedWinID = currentMedStoreWindow.m_strWindowID;
                                    intSortno = currentMedStoreWindow.m_intWindowOrderNo;
                                }
                                else
                                {
                                    //普通收费处的普通病人，如果病人当天发过药的，获取当天该患者相同药房窗口
                                    //strMedWinID = this.m_strGetwinid(pid, strMedStoreIDCurr, out intSortno);

                                    currentMedStoreWindow = null;
                                    if (m_gdicSpecialMedStore.ContainsKey(strMedStoreIDCurr))
                                    {
                                        currentMedStoreWindow = m_gdicSpecialMedStore[strMedStoreIDCurr];
                                    }
                                    else
                                    {
                                        long l1 = this.objSvc.m_lngGetsendgeneralmedinfoBypid(pid, strMedStoreIDCurr, out currentMedStoreWindow);
                                        m_gdicSpecialMedStore.Add(strMedStoreIDCurr, currentMedStoreWindow);
                                    }


                                    //当天已发过药的窗口，不能是急诊窗或专窗，才能发往之前的窗口
                                    if (currentMedStoreWindow != null && currentMedStoreWindow.m_strSendWindowID != m_objViewer.strSpecialMedStoreSWindow && currentMedStoreWindow.m_strSendWindowID != m_objViewer.strEmergencyMedStoreSWindow)
                                    {
                                        strMedWinID = currentMedStoreWindow.m_strWindowID;
                                        intSortno = currentMedStoreWindow.m_intWindowOrderNo;
                                    }

                                    //如果获取当天已发过药的窗口不成功，则从当前处方同药房中获取，以达到窗口一致
                                    if (strMedWinID == "")
                                    {
                                        for (int k = 0; k < objMedStoreArr.Count; k++)
                                        {
                                            if (objMedStoreArr[k].ToString() == strMedStoreIDCurr)
                                            {
                                                strMedWinID = objMedWinArr[k].ToString().Trim();
                                                break;
                                            }
                                        }
                                    }

                                    //如果当天没有发过药(或者不符规则)，则按窗口按工作量分配
                                    //注意此时的分配规则受系统功能0057影响，如果专窗可以接收所有科室的处方，则普通收费处普通病人的处方有可能会发往专窗或急诊窗（急诊窗也是专窗）
                                    //objSvc.lngGetWindowIDByStorage(strMedStoreIDCurr, out strMedWinID, out intSortno, Ismedwinpublic);
                                    if (strMedWinID == "")
                                    {
                                        objSvc.lngGetWindowIDByStorage(strMedStoreIDCurr, out currentMedStoreWindow);
                                        if (currentMedStoreWindow != null)
                                        {
                                            strMedWinID = currentMedStoreWindow.m_strWindowID;
                                            intSortno = currentMedStoreWindow.m_intWindowOrderNo;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    #region 判断窗口分配是否成功，并处理是否要将窗口加入数组中(合并门、急诊药房程序后，上面的代码移致此处)
                    if (strMedWinID == null || strMedWinID.Trim() == "")
                    {
                        //strMedWinID = " ";

                        MessageBox.Show("配发药窗口分配失败，请重新操作！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                        //com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                        //objLogger.LogError("分配发药窗口失败 " + strMainRecipeID);
                        //System.IO.StreamWriter sw = new System.IO.StreamWriter(@"d:\code\medstorewin.log", true);
                        //sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  RecipeID = '" + strMainRecipeID
                        //             + "'  ItemID = '" + strChrgItem + "' \r\n");
                        //sw.Close();
                        //sw.Dispose();

                        return -1;
                    }

                    for (int l = 0; l < objMedStoreArr.Count; l++)
                    {
                        if (objMedStoreArr[l].ToString() == strMedStoreIDCurr && objMedWinArr[l].ToString() == strMedWinID)
                        {
                            blntmp = true;
                            break;
                        }
                    }

                    if (!blntmp)
                    {
                        objRecTypeArr.Add(objRD_VO[intLocation].strType.ToString());
                        objMedStoreArr.Add(strMedStoreIDCurr);
                        objMedWinArr.Add(strMedWinID);
                        objSortnoArr.Add(intSortno);
                        objMedStoreType.Add(strMedStoretype);

                        m_glstMedStoreVo.Add(currentMedStoreWindow);
                    }
                    objRD_VO[intLocation].strMedstroeID = strMedStoreIDCurr;
                    objRD_VO[intLocation].strWindowsID = strMedWinID;
                    strMedWinID = "";
                    #endregion
                }
                else
                {
                    objRD_VO[intLocation].strMedstroeID = " ";
                    objRD_VO[intLocation].strWindowsID = " ";
                }
                #endregion

                intLocation++;
            }

            if (objRD_VO[0].strCharegeItemID == null || objRD_VO[0].strCharegeItemID.Trim() == "")//第一行的项目ID为空表示没有收费项目
            {
                return -1;
            }

            Hashtable hasMed = new Hashtable();
            ArrayList objList = new ArrayList();
            clsDcl_DoctorWorkstation objSvcDoct = new clsDcl_DoctorWorkstation();
            DataTable dtTemp;
            DataView dvMedStore = null;
            string WMDrugStoreID = string.Empty;
            string CMDrugStoreID = string.Empty;
            if (objSvcDoct.m_lngGetMedStore(out dtTemp) > 0)
            {
                dvMedStore = new DataView(dtTemp);
            }
            for (int intI = 0; intI < objRD_VO.Length; intI++)
            {
                if (m_intIsOrNotSendMed == 1)
                {
                    break;
                }
                if (objRD_VO[intI].strType == "0001" || objRD_VO[intI].strType == "0002")
                {
                    MedDeduct_VO objMedVO = new MedDeduct_VO();
                    dvMedStore.RowFilter = "medstoreid_chr = '" + objRD_VO[intI].strMedstroeID + "'";
                    if (dvMedStore.Count > 0)
                    {
                        WMDrugStoreID = dvMedStore[0]["deptid_chr"].ToString().Trim();
                    }
                    else
                    {
                        WMDrugStoreID = string.Empty;
                    }
                    objMedVO.strRecipeID = objRD_VO[intI].m_strOutpatRecipeID;
                    // objMedVO.intRowNO = int.Parse(objRD_VO[intI].strBillNO);
                    objMedVO.strItemID = objRD_VO[intI].strCharegeItemID;
                    objMedVO.strItemName = objRD_VO[intI].m_strItemname;
                    objMedVO.decAmount = objRD_VO[intI].decQuantity;
                    //if (objRD_VO[intI].UnitType == "1" && clsPublic.ConvertObjToDecimal(objRD_VO[intI].UnitScale) > 0)
                    //{
                    //    decMidPackQty = clsPublic.ConvertObjToDecimal(objRD_VO[intI].UnitScale);
                    //}
                    //else
                    //{
                    //    decMidPackQty = 0;
                    //}
                    objMedVO.intUnitFlag = int.Parse(string.IsNullOrEmpty(objRD_VO[intI].m_strUnitFlag) ? "0" : objRD_VO[intI].m_strUnitFlag);
                    objMedVO.decMidPackQty = 0;
                    objMedVO.intMedType = objRD_VO[intI].strType == "0001" ? 1 : 2;
                    objMedVO.strExecDeptID = WMDrugStoreID;
                    // objMedVO.strExecDeptID = objRD_VO[intI].strType == "0001" ? WMDrugStoreID:CMDrugStoreID;
                    //if (decMidPackQty > 0)
                    //{
                    //    objMedVO.decAmount = objMedVO.decAmount * decMidPackQty;
                    //    objMedVO.decMidPackQty = decMidPackQty;
                    //    objMedVO.intUnitFlag = 2;
                    //}

                    objList.Add(objMedVO);

                    if (hasMed.ContainsKey(objMedVO.strItemID))
                    {
                        hasMed[objMedVO.strItemID] = decimal.Parse(hasMed[objMedVO.strItemID].ToString()) + objMedVO.decAmount;
                    }
                    else
                    {
                        hasMed.Add(objMedVO.strItemID, objMedVO.decAmount);
                    }
                }
            }
            MedDeduct_VO[] objMed = new MedDeduct_VO[objList.Count];
            for (int intI = 0; intI < objList.Count; intI++)
            {
                objMed[intI] = (MedDeduct_VO)objList[intI];
            }
            string strExecDeptIDArr = string.Empty;
            string strItemIDArr = string.Empty;
            for (int i = 0; i < objMed.Length; i++)
            {
                strExecDeptIDArr += "'" + objMed[i].strExecDeptID + "',";
                strItemIDArr += "'" + objMed[i].strItemID + "',";
            }
            Hashtable hasCompleteID = new Hashtable();
            DataTable dtMed = new DataTable();
            long ret1 = 0;
            if (!string.IsNullOrEmpty(strExecDeptIDArr) && !string.IsNullOrEmpty(strItemIDArr))
            {
                strExecDeptIDArr = strExecDeptIDArr.Substring(0, strExecDeptIDArr.Length - 1);
                strItemIDArr = strItemIDArr.Substring(0, strItemIDArr.Length - 1);
                ret1 = objSvcDoct.m_lngGetTheoryAmountByMedID(strExecDeptIDArr, strItemIDArr, this.m_strDeductType, out dtMed);
                if (ret1 > 0 && dtMed.Rows.Count > 0)
                {
                    decimal decTotal = 0;
                    for (int j = 0; j < objMed.Length; j++)
                    {
                        DataRow[] drr = dtMed.Select("itemid_chr = '" + objMed[j].strItemID + "' and drugstoreid_chr = '" + objMed[j].strExecDeptID + "'");

                        //重检测库存数
                        decTotal = 0;
                        for (int k = 0; k < drr.Length; k++)
                        {
                            if (objMed[j].intUnitFlag == 0)
                            {
                                //decTotal += clsPublic.ConvertObjToDecimal(drr[k]["jbsl"].ToString());
                                decTotal += clsPublic.ConvertObjToDecimal(drr[k]["zxsl"].ToString()) / clsPublic.ConvertObjToDecimal(drr[k]["packqty_dec"].ToString());
                            }
                            else
                            {
                                decTotal += clsPublic.ConvertObjToDecimal(drr[k]["zxsl"].ToString());
                            }
                        }

                        if (!hasCompleteID.ContainsKey(objMed[j].strItemID))
                        {
                            if (decimal.Parse(hasMed[objMed[j].strItemID].ToString()) > decTotal)
                            {
                                if (this.m_blnSecondStockLimitFlag)
                                {
                                    MessageBox.Show("药品：" + objMed[j].strItemName + "库存不足，请联系药房。(药房当前可用库存数: " + decTotal.ToString() + ")", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    return -1;
                                }
                            }

                            hasCompleteID.Add(objMed[j].strItemID, objMed[j].strItemID);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("当前药品无库存或不可供！请与管理员联系", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -1;
                }
            }
            #endregion

            #region 收集主处方信息

            int deptmed = 0;
            if (!has.ContainsKey(0) && has.ContainsKey(1))
            {
                deptmed = 1;
            }

            if (this.objHashTable.Count > 0)
            {
                foreach (clsOutPatientRecipe_VO o in objHashTable.Values)
                {
                    o.strIDcard = this.m_objViewer.txtIDcard.Text.Trim();
                    o.m_strPatientType = this.m_objViewer.m_PatientBasicInfo.PayTypeID;
                    o.strInsuranceID = this.m_objViewer.txtInsuranceID.Text.Trim();
                    o.intDeptmed = deptmed;
                    o.m_intPStatus = 2;
                    if (o.m_strDoctorID == null || o.m_strDoctorID.Trim() == "")
                    {
                        o.m_strDoctorID = m_objViewer.m_PatientBasicInfo.DoctorID.Trim();
                    }
                    o.IsProxyBoilMed = this.m_objViewer.cboProxyBoilMed.SelectedIndex;
                    objMainRecipeArr.Add(o);
                    m_objMainRecipeList.Add(o);
                }
            }

            if (objMainRecipeArr.Count == 0)
            {
                clsOutPatientRecipe_VO OPR_VO = new clsOutPatientRecipe_VO();
                OPR_VO.m_strRecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                OPR_VO.m_strOperatorID = m_objViewer.LoginInfo.m_strEmpID;//操作员ID
                OPR_VO.m_strRegisterID = m_objViewer.m_PatientBasicInfo.RegisterID.Trim();
                OPR_VO.m_strDoctorID = m_objViewer.m_PatientBasicInfo.DoctorID.Trim();
                OPR_VO.m_strDepID = m_objViewer.m_PatientBasicInfo.DeptID.Trim();
                OPR_VO.m_strCreateDate = m_objViewer.m_PatientBasicInfo.RegisterDate;
                OPR_VO.m_strPatientID = m_objViewer.m_PatientBasicInfo.PatientID.Trim();
                OPR_VO.m_intPStatus = 2;
                OPR_VO.m_intType = int.Parse(m_objViewer.m_cmbRecipeType.Tag.ToString());
                OPR_VO.m_strPatientType = m_objViewer.m_PatientBasicInfo.PayTypeID;
                OPR_VO.m_strRecipeType = "0";
                OPR_VO.intCreatetype = 1;
                OPR_VO.intDeptmed = deptmed;
                OPR_VO.strIDcard = this.m_objViewer.txtIDcard.Text.Trim();
                OPR_VO.strInsuranceID = this.m_objViewer.txtInsuranceID.Text.Trim();
                if (this.m_objViewer.btSave.Tag == null)
                {
                    OPR_VO.m_strOutpatRecipeID = strMainRecipeID;
                }
                else
                {
                    OPR_VO.m_strOutpatRecipeID = this.m_objViewer.btSave.Tag.ToString();
                }
                objMainRecipeArr.Add(OPR_VO);
                m_objMainRecipeList.Add(OPR_VO);

            }
            #endregion

            for (int i = 0; i < p_objPC.Length; i++)
            {
                if (i == 0)
                {
                    objArr2[0] = objCalPatientCharge.m_mthSaveInvoiceDetail2(p_objPC[0].m_strInvoiceNO, "");
                }
                else
                {
                    clsInvoiceTypeDetail_VO objDV = new clsInvoiceTypeDetail_VO();
                    objDV.m_strINVOICENO_VCHR = p_objPC[i].m_strInvoiceNO;
                    objDV.m_decSUM_MNY = 0;
                    objDV.m_strITEMCATID_CHR = ((clsInvoiceTypeDetail_VO)objArr2[0][0]).m_strITEMCATID_CHR;
                    objArr2[i] = new ArrayList();
                    objArr2[i].Add(objDV);
                }
                objArr1[i] = objCalPatientCharge.m_mthSaveInvoiceDetail(p_objPC[i].m_strInvoiceNO, p_objPC[i], "");
                objInvoice_VO[i] = new clsInvoice_VO();
                #region 收集发票信息
                //if (IsDongGuanYBPatient)
                //{
                //    objInvoice_VO[i].m_decACCTSUM_MNY = 0;
                //    objInvoice_VO[i].m_decSBSUM_MNY = p_objPC[i].m_decTotalCost;
                //}
                //else
                //{
                objInvoice_VO[i].m_decACCTSUM_MNY = p_objPC[i].m_decChargeUpCost;
                objInvoice_VO[i].m_decSBSUM_MNY = p_objPC[i].m_decPersonCost;
                //}

                objInvoice_VO[i].m_intSTATUS_INT = 1;
                if (p_objPC[i].m_strDateOfReception != null && p_objPC[i].m_strDateOfReception.ToString().Trim() != "")
                {
                    objInvoice_VO[i].m_strINVDATE_DAT = p_objPC[i].m_strDateOfReception;
                }
                else
                {
                    objInvoice_VO[i].m_strINVDATE_DAT = m_objViewer.m_PatientBasicInfo.RegisterDate;
                }

                objInvoice_VO[i].m_strINVOICENO_VCHR = p_objPC[i].m_strInvoiceNO;
                objInvoice_VO[i].m_strOPREMP_CHR = m_objViewer.LoginInfo.m_strEmpID;//操作员ID
                objInvoice_VO[i].m_strRECORDDATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objInvoice_VO[i].m_strRECORDEMP_CHR = m_objViewer.LoginInfo.m_strEmpID;//操作员ID
                objInvoice_VO[i].m_strSEQID_CHR = p_objPC[i].m_strSeriesNumber;
                objInvoice_VO[i].m_strBALANCEEMP_CHR = m_objViewer.LoginInfo.m_strEmpID;//操作员ID
                objInvoice_VO[i].m_strBALANCE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objInvoice_VO[i].m_intBALANCEFLAG_INT = 0;
                objInvoice_VO[i].m_decTOTALSUM_MNY = p_objPC[i].m_decTotalCost;
                objInvoice_VO[i].m_intPAYTYPE_INT = int.Parse(p_objPC[i].m_strPayTypeIndex);
                objInvoice_VO[i].m_strPATIENTID_CHR = this.m_objViewer.m_PatientBasicInfo.PatientID;
                objInvoice_VO[i].m_strPATIENTNAME_CHR = this.m_objViewer.m_PatientBasicInfo.PatientName;
                objInvoice_VO[i].m_strDEPTID_CHR = this.m_objViewer.m_PatientBasicInfo.DeptID;
                objInvoice_VO[i].m_strDEPTNAME_CHR = this.m_objViewer.m_PatientBasicInfo.DeptName;
                objInvoice_VO[i].m_strDOCTORID_CHR = this.m_objViewer.m_PatientBasicInfo.DoctorID;
                objInvoice_VO[i].m_strDOCTORNAME_CHR = this.m_objViewer.m_PatientBasicInfo.DoctorName;
                objInvoice_VO[i].m_strCONFIRMEMP_CHR = this.m_objViewer.m_PatientBasicInfo.DoctorID; //审核员暂定为处方医生
                objInvoice_VO[i].m_strCONFIRMDEPT_CHR = this.m_objViewer.m_PatientBasicInfo.DeptID;  //审核员暂定为处方医生所在当前科室
                objInvoice_VO[i].m_strPAYTYPEID_CHR = this.m_objViewer.m_PatientBasicInfo.PayTypeID;
                objInvoice_VO[i].m_strHospitalID_CHR = this.strHopitalID;
                objInvoice_VO[i].Paycardtype = p_objPC[i].Paycardtype;
                objInvoice_VO[i].Paycardno = p_objPC[i].Paycardno;
                objInvoice_VO[i].m_decTolDiffPrice = p_objPC[i].m_decTotalDiffCost;// 总让利金额

                if (this.PEWorkStationFlag)
                {
                    if (this.PERegisterNoArr.Length >= 12)
                    {
                        objInvoice_VO[i].RegNo = this.PERegisterNoArr.Substring(0, 12);
                    }
                }
                else
                {
                    objInvoice_VO[i].RegNo = "";
                }
                #endregion
            }

            #region 收集药品发送表信息
            clsMedrecipesend_VO objMRS_VO;
            for (int i = 0; i < objMedStoreArr.Count; i++)
            {
                objMRS_VO = new clsMedrecipesend_VO();
                objMRS_VO.m_strOUTPATRECIPEID_CHR = "";
                objMRS_VO.m_intPSTATUS_INT = 1;
                objMRS_VO.m_strRECIPETYPE_INT = objRecTypeArr[i].ToString().Trim();
                objMRS_VO.m_strSENDDATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                objMRS_VO.m_strSENDEMP_CHR = m_objViewer.LoginInfo.m_strEmpID;
                objMRS_VO.m_strMedstroeID_CHR = objMedStoreArr[i].ToString();
                //objMRS_VO.m_strWINDOWID_CHR = objMedWinArr[i].ToString();
                //objMRS_VO.Sortno = objSortnoArr[i].ToString();

                if (m_glstMedStoreVo[i] != null)
                {
                    objMRS_VO.m_strWINDOWID_CHR = m_glstMedStoreVo[i].m_strWindowID;
                    objMRS_VO.Sortno = m_glstMedStoreVo[i].m_intWindowOrderNo.ToString();
                    objMRS_VO.m_strSendWINDOWID_CHR = m_glstMedStoreVo[i].m_strSendWindowID;
                    objMRS_VO.m_strSendWINDOWName_VCHR = m_glstMedStoreVo[i].m_strSendWindowName;
                }


                objMRS_VO.m_strTREATDATE_DAT = "";
                objMRS_VO.m_strTREATEMP_CHR = "";
                //objMedicineSend.Add(objMRS_VO);//添加信息
                //if (objMRS_VO.m_strRECIPETYPE_INT == "0001" && (objMedStoreType[i].ToString() == "1" || objMedStoreType[i].ToString() == "4"))
                //{
                //    objSvc.m_mthGetSerNO(out m_strSerNO);
                //    objMRS_VO.m_strSerNO = m_strSerNO;
                //    m_objWMSendList.Add(objMRS_VO);
                //}
                //else
                //{
                //    m_objCMSendList.Add(objMRS_VO);
                //}


                if (objMRS_VO.m_strRECIPETYPE_INT == "0001" && (objMedStoreType[i].ToString() == "1" || objMedStoreType[i].ToString() == "4"))
                {
                    objMRS_VO.m_strFlag = "0";
                }
                else
                {
                    objMRS_VO.m_strFlag = "1";
                }
                objMedicineSend.Add(objMRS_VO);//添加信息
            }

            #endregion
            //增加一次校验
            if (objRD_VO[0].m_strOutpatRecipeID != ((clsOutPatientRecipe_VO)objMainRecipeArr[0]).m_strOutpatRecipeID)
            {
                for (int intI = 0; intI < objRD_VO.Length; intI++)
                {
                    objRD_VO[intI].m_strOutpatRecipeID = ((clsOutPatientRecipe_VO)objMainRecipeArr[0]).m_strOutpatRecipeID;
                }
            }
            string strIniFileName = Application.StartupPath + @"\ID.ini";
            string strOpChargeDeptId = null;
            if (File.Exists(strIniFileName))
            {
                StringBuilder isAutorun = new StringBuilder(128);
                GetPrivateProfileString("OpChargeDeptID", "DeptId", "", isAutorun, 128, strIniFileName);
                strOpChargeDeptId = isAutorun.ToString();
            }
            string strRecipeID;
            //ArrayList m_objMedicineSend;
            if (this.m_objViewer.blnFlag)
            {
                objMedicineSend = new ArrayList();
                //objRD_VO = new clsRecipeDetail_VO[0];
            }
            long strRet = objSvc.m_mthSaveAllData(objMainRecipeArr, out strRecipeID, objRD_VO, this.m_objViewer.numericUpDown1.Value, objInvoice_VO, objArr1, objArr2, objMedicineSend, strOpChargeDeptId, this.m_objViewer.blnFlag);
            if (strRet <= 0)
            {
                MessageBox.Show("对不起,保存信息失败。", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else
            {
                //for (int i = 0; i < m_objMedicineSend.Count; i++)
                //{
                //    clsMedrecipesend_VO m_objTemp = m_objMedicineSend[i] as clsMedrecipesend_VO;
                //    if (m_objTemp.m_strFlag == "0")
                //    {
                //        objSvc.m_mthGetSerNO(out m_strSerNO);
                //        m_objTemp.m_strSerNO = m_strSerNO;
                //        m_objWMSendList.Add(m_objTemp);
                //    }
                //    else
                //    {
                //        m_objCMSendList.Add(m_objTemp);
                //    }
                //}

                //objMedicineSend.Clear();
                //objMedicineSend.AddRange(m_objMedicineSend);
            }

            // 中药费 --> 中药处方发送
            this.m_objViewer.IsCmRecipe = false;
            for (int i = 0; i < p_objPC.Length; i++)
            {
                foreach (clsInvoiceTypeDetail_VO item in objArr1[i])
                {
                    if (item.m_strITEMCATID_CHR == "0003")
                    {
                        this.m_objViewer.IsCmRecipe = true;
                        break;
                    }
                }
            }

            this.m_objViewer.btSave.Tag = strRecipeID;
            return strRet;
        }

        private bool m_mthIsTheRightMedstore(string strWinID, ref DataTable dtbMedWindows)
        {
            bool blRes = false;
            if (dtbMedWindows == null)
            {
                return blRes;
            }
            DataView dv = dtbMedWindows.DefaultView;
            dv.RowFilter = "windowid_chr='" + strWinID + "'";
            if (dv.Count > 0)
            {
                blRes = true;
            }
            else
            {
                blRes = false;
            }
            dv.Dispose();
            dv = null;
            return blRes;
        }

        #region 扣减信息类VO
        /// <summary>
        /// 扣减信息类VO
        /// </summary>
        private class MedDeduct_VO
        {
            /// <summary>
            /// 处方号
            /// </summary>
            public string strRecipeID = string.Empty;
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
            /// 药品类型 1 西药 2 中药
            /// </summary>
            public int intMedType = 1;
            /// <summary>
            /// 执行科室ID
            /// </summary>
            public string strExecDeptID = string.Empty;
        }
        #endregion

        /// <summary>
        /// 保存处方明细
        /// </summary>
        /// <param name="strRecipeNo">主处方号</param>
        /// <param name="objRD_VO"></param>
        private void m_mthSaveRecipeDetial(string strRecipeNo, clsRecipeDetail_VO[] objRD_VO)
        {
            objSvc.m_mthSaveRecipeDetial(strRecipeNo, objRD_VO, m_objViewer.numericUpDown1.Value);
        }
        /// <summary>
        /// 保存处方收费明细
        /// </summary>
        /// <param name="strRecipeNo"></param>
        /// <param name="objRD_VO"></param>
        private void m_mthSaveRecipeChargeItemDetial(string strRecipeNo, clsRecipeDetail_VO[] objRD_VO)
        {
            objSvc.m_mthSaveRecipeChargeItemDetial(strRecipeNo, objRD_VO);
        }
        /// <summary>
        /// 保存处方发送记录
        /// </summary>
        /// <param name="strRecipeNo">处方号</param>
        /// <param name="strRECIPETYPE">类型ID</param>
        private void m_mthSaveRecipeSend(string strRecipeNo, string strRECIPETYPE)
        {
            clsMedrecipesend_VO objMRS_VO = new clsMedrecipesend_VO();
            objMRS_VO.m_strOUTPATRECIPEID_CHR = strRecipeNo;
            objMRS_VO.m_intPSTATUS_INT = 1;
            objMRS_VO.m_strRECIPETYPE_INT = strRECIPETYPE;
            objMRS_VO.m_strSENDDATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strEmployeeID = "0000001";
            if (m_objViewer.LoginInfo != null)
            {
                strEmployeeID = m_objViewer.LoginInfo.m_strEmpID;
            }
            objMRS_VO.m_strSENDEMP_CHR = strEmployeeID;

            objMRS_VO.m_strWINDOWID_CHR = this.strWMedicineWindowID;//初定"0003"以后再重新定(西药)
            if (strRECIPETYPE == "0002")
            {
                objMRS_VO.m_strWINDOWID_CHR = this.strCMedicineWindowID;//初定"0004"以后再重新定(中药)
            }
            objMRS_VO.m_strTREATDATE_DAT = "";
            objMRS_VO.m_strTREATEMP_CHR = "";
            objSvc.m_mthSaveRecipeSend(objMRS_VO);
        }
        #endregion

        #region 单独保存处方内容
        /// <summary>
        /// 单独保存处方内容
        /// </summary>
        public void m_mthSaveRecipe()
        {
            clsRecipeInfo_VO obj = this.m_objViewer.txtLoadRecipeNO.RecipeInfo;
            if (obj != null && obj.m_intPSTATUS_INT != 1)
            {
                MessageBox.Show("调历史处方无需保存!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (this.m_objViewer.btSave.Tag != null && this.EmpInputMode == false)
            {
                MessageBox.Show("调历史处方无需保存!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (!this.IsChargeReceiverRec)
                {
                    MessageBox.Show("由于系统当前设置为不能结算收款员所开处方项目，所以不能保存当前处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            string RecipeID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            if (this.m_objViewer.btSave.Tag != null)
            {
                RecipeID = this.m_objViewer.btSave.Tag.ToString();
            }

            //主处方信息
            ArrayList objMainRecipeArr = new ArrayList();

            #region 判断保存条件 明细信息
            for (int i = m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
            {
                if (m_objViewer.ctlDataGrid1.RowCount == 1 && m_objViewer.ctlDataGrid1[0, 10].ToString().Trim() == "")
                {
                    break;
                }
                if (m_objViewer.ctlDataGrid1[i, 12].ToString().Trim() == "")
                {
                    m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                    continue;
                }
                if (m_objViewer.ctlDataGrid1[i, 26].ToString().Trim() == "")//如果处方为空则填充
                {
                    m_objViewer.ctlDataGrid1[i, 26] = RecipeID;
                }
            }

            //明细信息
            clsRecipeDetail_VO[] objRD_VO = new clsRecipeDetail_VO[m_objViewer.ctlDataGrid1.RowCount];
            int intLocation = 0;
            Hashtable has = new Hashtable();
            for (int i = 0; i < m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                objRD_VO[intLocation] = new clsRecipeDetail_VO();

                if (m_objViewer.ctlDataGrid1[i, 1] == null || m_objViewer.ctlDataGrid1[i, 1].ToString().Trim() == "")
                {
                    MessageBox.Show("剂量为空不能保存!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.m_objViewer.ctlDataGrid1.Select();
                    this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(i, 1);
                    return;
                }
                //（收费）项目ID                
                objRD_VO[intLocation].strRowNO = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 16]).ToString();
                objRD_VO[intLocation].decDiscount = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 14]);
                objRD_VO[intLocation].decPrice = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 6]);
                objRD_VO[intLocation].decQuantity = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 1]);
                objRD_VO[intLocation].decSumMoney = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 7]);
                objRD_VO[intLocation].strCharegeItemID = m_objViewer.ctlDataGrid1[intLocation, 10].ToString().Trim();
                objRD_VO[intLocation].strUsageID = m_objViewer.ctlDataGrid1[intLocation, 17].ToString().Trim();
                objRD_VO[intLocation].strFrequencyID = m_objViewer.ctlDataGrid1[intLocation, 18].ToString().Trim();
                objRD_VO[intLocation].strDosage = m_objViewer.ctlDataGrid1[intLocation, 19].ToString().Trim();
                objRD_VO[intLocation].strDays = m_objViewer.ctlDataGrid1[intLocation, 20].ToString().Trim();
                objRD_VO[intLocation].strType = m_objViewer.ctlDataGrid1[intLocation, 9].ToString().Trim();
                objRD_VO[intLocation].strApplyID = m_objViewer.ctlDataGrid1[intLocation, 22].ToString().Trim();
                objRD_VO[intLocation].strCMedicineUsage = m_objViewer.numericUpDown1.Tag.ToString();
                objRD_VO[intLocation].strHYPETEST_INT = m_objViewer.ctlDataGrid1[intLocation, 24].ToString().Trim();
                objRD_VO[intLocation].strDESC_VCHR = m_objViewer.ctlDataGrid1[intLocation, 25].ToString().Trim();
                objRD_VO[intLocation].m_strOutpatRecipeID = m_objViewer.ctlDataGrid1[intLocation, 26].ToString().Trim();
                objRD_VO[intLocation].m_strItemspec = m_objViewer.ctlDataGrid1[intLocation, 4].ToString().Trim();
                objRD_VO[intLocation].m_decDosage = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, 19]);
                objRD_VO[intLocation].m_strDosageunit = m_objViewer.ctlDataGrid1[intLocation, 21].ToString().Trim();
                objRD_VO[intLocation].m_strATTACHPARENTID_VCHR = m_objViewer.ctlDataGrid1[intLocation, ResubitemCol].ToString().Trim();
                objRD_VO[intLocation].m_decAttachitembasenum = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, ResubnumsCol]);
                objRD_VO[intLocation].m_strUSAGEPARENTID_VCHR = m_objViewer.ctlDataGrid1[intLocation, UsageitemCol].ToString().Trim();
                objRD_VO[intLocation].m_decUsageitembasenum = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, UsagenumsCol]);
                objRD_VO[intLocation].m_strItemname = m_objViewer.ctlDataGrid1[intLocation, 2].ToString().Trim();
                objRD_VO[intLocation].strUint = m_objViewer.ctlDataGrid1[intLocation, 5].ToString().Trim();
                if (m_objViewer.ctlDataGrid1[intLocation, Deptmed].ToString().Trim() == "1")
                {
                    objRD_VO[intLocation].m_intDeptmed = 1;
                }
                else
                {
                    objRD_VO[intLocation].m_intDeptmed = 0;
                }

                objRD_VO[intLocation].m_strOrderID = m_objViewer.ctlDataGrid1[intLocation, OrderID].ToString().Trim();
                objRD_VO[intLocation].m_decOrderBaseNum = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, OrderNum]);
                // 总让利金额
                if (this.intDiffPriceOn == 1)
                    objRD_VO[intLocation].m_decTolDiffPrice = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, intDiffPriceTotalCol]);
                if (objRD_VO[intLocation].m_decTolDiffPrice == 0)
                    objRD_VO[intLocation].BuyPrice = objRD_VO[intLocation].decPrice;
                else
                    objRD_VO[intLocation].BuyPrice = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[intLocation, intDiffUnitPriceCol]);
                intLocation++;
            }
            if (objRD_VO[0].strCharegeItemID == null || objRD_VO[0].strCharegeItemID.Trim() == "")//第一行的项目ID为空表示没有收费项目
            {
                return;
            }
            #endregion

            #region 收集主处方信息
            clsOutPatientRecipe_VO OPR_VO = new clsOutPatientRecipe_VO();
            OPR_VO.m_strRecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            OPR_VO.m_strOperatorID = m_objViewer.LoginInfo.m_strEmpID;//操作员ID
            OPR_VO.m_strRegisterID = m_objViewer.m_PatientBasicInfo.RegisterID.Trim();
            OPR_VO.m_strDoctorID = m_objViewer.m_PatientBasicInfo.DoctorID.Trim();
            OPR_VO.m_strDepID = m_objViewer.m_PatientBasicInfo.DeptID.Trim();
            OPR_VO.m_strCreateDate = m_objViewer.m_PatientBasicInfo.RegisterDate;
            OPR_VO.m_strPatientID = m_objViewer.m_PatientBasicInfo.PatientID.Trim();
            OPR_VO.m_intPStatus = 1;
            OPR_VO.m_intType = int.Parse(m_objViewer.m_cmbRecipeType.Tag.ToString());
            OPR_VO.m_strPatientType = m_objViewer.m_PatientBasicInfo.PayTypeID;
            OPR_VO.m_strRecipeType = "0";
            OPR_VO.intCreatetype = 1;
            OPR_VO.intDeptmed = 0;
            OPR_VO.strIDcard = this.m_objViewer.txtIDcard.Text.Trim();
            OPR_VO.strInsuranceID = this.m_objViewer.txtInsuranceID.Text.Trim();
            OPR_VO.m_strOutpatRecipeID = RecipeID;
            OPR_VO.IsProxyBoilMed = this.m_objViewer.cboProxyBoilMed.SelectedIndex;

            objMainRecipeArr.Add(OPR_VO);
            m_objMainRecipeList.Add(OPR_VO);
            #endregion

            long l = this.objSvc.m_lngSaveRecipe(objMainRecipeArr, objRD_VO, this.m_objViewer.numericUpDown1.Value);
            if (l <= 0)
            {
                MessageBox.Show("对不起,保存处方信息失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                MessageBox.Show("保存处方信息成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            this.objHashTable.Clear();

            clsOutPatientRecipe_VO objTemp = new clsOutPatientRecipe_VO();
            objTemp.m_intPStatus = 1;
            objTemp.intCreatetype = 1;
            objTemp.m_strCaseHistoryID = "";
            objTemp.m_strDepID = this.m_objViewer.m_PatientBasicInfo.CurrentDeptID;
            objTemp.m_strCreateDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objTemp.m_strRecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objTemp.m_strDoctorID = this.m_objViewer.m_PatientBasicInfo.CurrentDoctorID;
            objTemp.m_strOutpatRecipeID = RecipeID;
            objTemp.m_strPatientType = this.m_objViewer.m_PatientBasicInfo.PayTypeID;
            objTemp.m_strRecipeType = "1";
            objTemp.m_strRegisterID = this.m_objViewer.m_PatientBasicInfo.RegisterID;
            objTemp.m_intType = int.Parse(m_objViewer.m_cmbRecipeType.Tag.ToString());
            objTemp.m_strPatientID = this.m_objViewer.m_PatientBasicInfo.PatientID.Trim();
            objTemp.strIDcard = this.m_objViewer.txtIDcard.Text.Trim();
            objTemp.strInsuranceID = this.m_objViewer.txtInsuranceID.Text.Trim();
            this.objHashTable.Add(0, objTemp);

            this.m_objViewer.btSave.Tag = RecipeID;
            this.EmpInputMode = true;
        }
        #endregion

        #region 保存发票信息
        /// <summary>
        /// 保存发票信息
        /// </summary>
        /// <param name="strRecipeNo">主处方号</param>
        public long m_mthSaveInvoicInfo(clsPatientChargeCal p_objPC, int flag)
        {
            //		clsPatientChargeCal objPC=this.objCalPatientCharge.m_mthGetChargeTypeDetail();

            clsPatientChargeCal objPC = p_objPC;
            clsInvoice_VO objIn_VO = new clsInvoice_VO();
            objIn_VO.m_decACCTSUM_MNY = objPC.m_decChargeUpCost;
            objIn_VO.m_decSBSUM_MNY = objPC.m_decPersonCost;
            objIn_VO.m_intSTATUS_INT = 1;
            if (p_objPC.m_strDateOfReception != null && p_objPC.m_strDateOfReception.ToString().Trim() != "")
            {
                objIn_VO.m_strINVDATE_DAT = p_objPC.m_strDateOfReception;
            }
            else
            {
                objIn_VO.m_strINVDATE_DAT = m_objViewer.m_PatientBasicInfo.RegisterDate;
            }

            objIn_VO.m_strINVOICENO_VCHR = objPC.m_strInvoiceNO;
            string strEmployeeID = "0000001";
            if (m_objViewer.LoginInfo != null)
            {

                strEmployeeID = m_objViewer.LoginInfo.m_strEmpID;
            }
            objIn_VO.m_strOPREMP_CHR = strEmployeeID;//m_objViewer.LoginInfo.m_strEmpName;//
            objIn_VO.m_strRECORDDATE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objIn_VO.m_strRECORDEMP_CHR = strEmployeeID;//m_objViewer.LoginInfo.m_strEmpName;
            objIn_VO.m_strSEQID_CHR = m_objViewer.m_PatientBasicInfo.RegisterNo;//这里在中间件重新定义它的值
            objIn_VO.m_strBALANCEEMP_CHR = strEmployeeID;
            objIn_VO.m_strBALANCE_DAT = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objIn_VO.m_intBALANCEFLAG_INT = 0;
            objIn_VO.m_decTOTALSUM_MNY = objPC.m_decTotalCost;
            objIn_VO.m_intPAYTYPE_INT = this.m_objViewer.m_cmbPayMode.SelectedIndex;
            objIn_VO.m_strPATIENTID_CHR = this.m_objViewer.m_PatientBasicInfo.PatientID;
            objIn_VO.m_strPATIENTNAME_CHR = this.m_objViewer.m_PatientBasicInfo.PatientName;
            objIn_VO.m_strDEPTID_CHR = this.m_objViewer.m_PatientBasicInfo.DeptID;
            objIn_VO.m_strDEPTNAME_CHR = this.m_objViewer.m_PatientBasicInfo.DeptName;
            objIn_VO.m_strDOCTORID_CHR = this.m_objViewer.m_PatientBasicInfo.DoctorID;
            objIn_VO.m_strDOCTORNAME_CHR = this.m_objViewer.m_PatientBasicInfo.DoctorName;
            objIn_VO.m_strCONFIRMEMP_CHR = "";
            objIn_VO.m_strPAYTYPEID_CHR = this.m_objViewer.m_PatientBasicInfo.PayTypeID;
            objIn_VO.m_strHospitalID_CHR = this.strHopitalID;
            if (flag > 0 && m_objViewer.m_txtInvoiceNO.Tag != null)
            {
                objIn_VO.m_strBASESEQID_CHR = m_objViewer.m_txtInvoiceNO.Tag.ToString();
            }
            else
            {
                objIn_VO.m_strBASESEQID_CHR = "";
            }
            if (this.m_objViewer.btSave.Tag != null)
            {
                objIn_VO.m_strSEQID_CHR = DateTime.Now.ToString("yyyyMMddhhmmssffff");
                m_objViewer.m_txtInvoiceNO.Tag = objIn_VO.m_strSEQID_CHR;
                objIn_VO.m_strOUTPATRECIPEID_CHR = this.m_objViewer.btSave.Tag.ToString();
            }
            else
            {
                return -1;
            }
            return objSvc.m_mthSaveInvoicInfo(objIn_VO);

        }
        public void m_mthSaveInvoiceDetail(clsPatientChargeCal p_objPC)
        {

            //			this.objCalPatientCharge.m_mthSaveInvoiceDetail(p_objPC.m_strInvoiceNO,p_objPC,m_objViewer.m_txtInvoiceNO.Tag.ToString());

        }

        public void m_mthSaveInvoiceDetail2(string strInvoiceNO)
        {
            //			this.objCalPatientCharge.m_mthSaveInvoiceDetail2(strInvoiceNO,m_objViewer.m_txtInvoiceNO.Tag.ToString());
            //			

        }
        #endregion

        #region 打印发票
        /// <summary>
        /// 打印发票
        /// </summary>
        /// <param name="p_objPC"></param>
        /// <param name="strInvoiceNO"></param>
        /// <returns></returns>
        public long m_mthPrintInvoice(clsPatientChargeCal p_objPC, out string strInvoiceNO)
        {
            strInvoiceNO = p_objPC.m_strInvoiceNO;
            clsPatientChargeCal objPC = p_objPC;
            objPC.m_strPatientID = m_objViewer.m_PatientBasicInfo.PatientID;
            objPC.m_strPatientCardID = m_objViewer.m_PatientBasicInfo.PatientCardID;
            objPC.m_strPatientName = m_objViewer.m_PatientBasicInfo.PatientName;
            //				objPC.m_strBalanceMode=m_objViewer.m_cmbPayMode.Text;
            string strEmployeeID = "0000001";
            if (m_objViewer.LoginInfo != null)
            {
                strEmployeeID = m_objViewer.LoginInfo.m_strEmpNo;
            }
            //				objPC.m_strAssessor=strEmployeeID;//m_objViewer.LoginInfo.m_strEmpName;
            //审核员改为： （科室代码）医生工号
            objPC.m_strAssessor = "(" + objSvc.m_strGetDeptNO(m_objViewer.m_PatientBasicInfo.DeptID) + ")" + m_objViewer.m_PatientBasicInfo.DoctorNo;
            if (this.m_strShowOPChargeManInfo == "1")
            {
                objPC.m_strCollector = strEmployeeID + "(" + this.m_objViewer.LoginInfo.m_strEmpName + ")"; ;//m_objViewer.LoginInfo.m_strEmpName;
            }
            else
            {
                objPC.m_strCollector = strEmployeeID;
            }
            objPC.m_strSeriesNumber = p_objPC.m_strSeriesNumber;
            //				if(this.m_objViewer.btSave.Tag!=null)
            //				{
            //					objPC.m_strSeriesNumber=this.m_objViewer.btSave.Tag.ToString();
            //				}
            if (this.m_objWMSendList.Count > 0)
            {
                objPC.m_strServerNo = ((clsMedrecipesend_VO)m_objWMSendList[0]).m_strSerNO;
            }
            if (p_objPC.m_strDateOfReception != null && p_objPC.m_strDateOfReception.ToString().Trim() != "")
            {
                objPC.m_strDateOfReception = p_objPC.m_strDateOfReception;
            }
            else
            {
                objPC.m_strDateOfReception = m_objViewer.m_PatientBasicInfo.RegisterDate;
            }
            //				objPC.m_strDateOfReception=p_objPC.m_strDateOfReception;
            objPC.m_strInvoiceNO = p_objPC.m_strInvoiceNO;
            objPC.m_strDocNo = m_objViewer.m_PatientBasicInfo.DoctorNo;
            objPC.m_strPatientTypeName = this.m_objViewer.m_PatientBasicInfo.txtType.Text;
            objPC.m_strSex = this.m_objViewer.m_PatientBasicInfo.txtSex.Text.Trim();
            objPC.m_strInsuranceID = this.m_objViewer.txtInsuranceID.Text.ToString().Trim();
            return this.objCalPatientCharge.m_mthPrintCharge(objPC);

        }
        #endregion

        #region 发票预览
        /// <summary>
        /// 发票预览
        /// </summary>
        /// <param name="p_objPC"></param>
        /// <returns></returns>
        public long m_mthPrintInvoicePreview(clsPatientChargeCal p_objPC)
        {
            clsPatientChargeCal objPC = p_objPC;
            objPC.m_strPatientID = m_objViewer.m_PatientBasicInfo.PatientID;
            objPC.m_strPatientName = m_objViewer.m_PatientBasicInfo.PatientName;
            objPC.m_strBalanceMode = m_objViewer.m_cmbPayMode.Text;
            string strEmployeeID = "0000001";
            objPC.m_strDocNo = m_objViewer.m_PatientBasicInfo.DoctorNo;
            if (m_objViewer.LoginInfo != null)
            {
                strEmployeeID = m_objViewer.LoginInfo.m_strEmpNo;

            }
            //			objPC.m_strAssessor=strEmployeeID;//m_objViewer.LoginInfo.m_strEmpName;
            //审核员改为： （科室代码）医生工号
            objPC.m_strAssessor = "(" + objSvc.m_strGetDeptNO(m_objViewer.m_PatientBasicInfo.DeptID) + ")" + m_objViewer.m_PatientBasicInfo.DoctorNo;
            if (this.m_strShowOPChargeManInfo == "1")
            {
                objPC.m_strCollector = strEmployeeID + "(" + this.m_objViewer.LoginInfo.m_strEmpName + ")"; ;//m_objViewer.LoginInfo.m_strEmpName;
            }
            else
            {
                objPC.m_strCollector = strEmployeeID;
            }
            objPC.m_strSeriesNumber = "";
            if (this.m_objViewer.btSave.Tag != null)
            {
                objPC.m_strSeriesNumber = this.m_objViewer.btSave.Tag.ToString();
            }
            objPC.m_strDateOfReception = m_objViewer.m_PatientBasicInfo.RegisterDate;
            objPC.m_strInvoiceNO = m_objViewer.m_txtInvoiceNO.Text.Trim();
            objPC.m_strHospitalName = this.m_objComInfo.m_strGetHospitalTitle();
            objPC.m_strPatientTypeName = this.m_objViewer.m_PatientBasicInfo.txtType.Text;
            return objCalPatientCharge.m_mthPrintChargePreview(objPC);


        }
        #endregion

        #region 删除单个项目
        public void m_mthDeleteRecipe(int row)
        {
            //		m_objViewer.ctlDataGrid1.m_mthDeleteRow(row);
            this.objCalPatientCharge.m_mthDelteChargeItem(row);
            this.m_mthDisplayCharge();
        }
        #endregion

        #region 更改服数
        /// <summary>
        /// 更改服数
        /// </summary>
        /// <param name="CurRow">datagrid当前的行号</param>
        /// <param name="ChaRow">收费类中的行号</param>
        public void m_mthChangeTimes(int CurRow, int ChaRow)
        {

            decimal price = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[CurRow, 6]);
            decimal dosage = m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[CurRow, 1]) * m_objViewer.numericUpDown1.Value;
            dosage = Math.Ceiling(dosage);
            decimal discount = 100;
            if (m_objViewer.ctlDataGrid1[CurRow, 14] != null && m_objViewer.ctlDataGrid1[CurRow, 14].ToString().Trim() != "")
            {
                discount = Convert.ToDecimal(m_objViewer.ctlDataGrid1[CurRow, 14].ToString().Trim());
            }
            //			decimal dosage=0;
            //			try
            //			{
            //			dosage=Convert.ToDecimal(m_objViewer.ctlDataGrid1[CurRow,1].ToString());
            //			dosage=dosage*m_objViewer.numericUpDown1.Value;
            //			}
            //			catch
            //			{
            //			dosage=0;
            //			} 
            //			decimal price=0;
            //			try
            //			{
            //			price =Convert.ToDecimal(m_objViewer.ctlDataGrid1[CurRow,6].ToString());
            //			}
            //			catch
            //			{
            //			price=0;
            //			}
            decimal summoney = dosage * price;
            summoney = m_mthConvertObjToDecimal(summoney.ToString("0.00"));
            m_objViewer.ctlDataGrid1[CurRow, 7] = summoney.ToString();

            //			((ChargeItem)this.objCalPatientCharge.m_ChargeItem[ChaRow]).decDosage=dosage;

            string strChargeID = m_objViewer.ctlDataGrid1[CurRow, 10].ToString().Trim();
            string ChargeTypeID = m_objViewer.ctlDataGrid1[CurRow, 8].ToString().Trim();
            string strcat = m_objViewer.ctlDataGrid1[CurRow, 15].ToString().Trim();
            if (this.intDiffPriceOn == 1)
                m_objViewer.ctlDataGrid1[CurRow, 12] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strChargeID, price, m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[CurRow, intDiffUnitPriceCol]), ChargeTypeID, dosage, ChaRow, discount, strcat, CheckIsDiff(CurRow));
            else
                m_objViewer.ctlDataGrid1[CurRow, 12] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(strChargeID, price, ChargeTypeID, dosage, ChaRow, discount, strcat, false);

            this.m_mthDisplayCharge();
            //			if(!p)
            //			{
            //				MessageBox.Show("请注意,病人药费已经超限额!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //			}
        }
        #endregion

        #region 查找病人处方记录
        //		/// <summary>
        //		/// 查找出病人的处方记录,并填充下拉框
        //		/// </summary>
        //		public void m_mthFindRecipeNoByPatientID()
        //		{
        //		clsRecipeInfo_VO[] objRI_VO=null;
        //		long ret =objSvc.m_mthFindRecipeNoByPatientID(m_objViewer.m_PatientBasicInfo.PatientID, out objRI_VO);
        //			m_objViewer.m_cmbRecipeNO.Items.Clear();
        //			if(ret>0&&objRI_VO!=null)
        //			{
        //				
        //				for(int i=0;i<objRI_VO.Length;i++)
        //				{
        //				m_objViewer.m_cmbRecipeNO.Items.Add(objRI_VO[i].m_strOUTPATRECIPEID_CHR.Trim());
        //				}
        //				m_objViewer.m_cmbRecipeNO.Tag=objRI_VO;
        //			}
        //		}
        #endregion

        #region 查找病人最后一次没有收费的处方号
        //业务需求：同一病人可能有多张处方，收完一张后打印发票，系统会提问用户是否继续调
        //出未收费的处方，如果“是”则继续调出。如果同一病人连续调出一张以上的处方来收费，为
        //了收费员一次性收钱的方便操作，要用一个小窗口弹出提未共有多少张处方，共多少钱，记账和
        //自付多少等信息。为此
        //下面定义的这几个变量是为了保存收费信息的合计
        /// <summary>
        /// 本次结账处方数
        /// </summary>
        public int RecipeCountThisTime = 0;
        /// <summary>
        /// 记录未结账处方数
        /// </summary>
        public int RecipeCount = 0;
        /// <summary>
        /// 未结处方总数
        /// </summary>
        public int SumRecipeCount = 0;
        /// <summary>
        /// 共结账总额
        /// </summary>
        public decimal SumTotalMoney = 0;
        /// <summary>
        /// 记账金额合计
        /// </summary>
        public decimal SumChargeUpMoney = 0;
        /// <summary>
        /// 自负金额合计
        /// </summary>
        public decimal SumPersonMoney = 0;
        /// <summary>
        /// 共结账总额
        /// </summary>
        public string strSumTotalMoney = "";
        /// <summary>
        /// 记账金额合计
        /// </summary>
        public string strSumChargeUpMoney = "";
        /// <summary>
        /// 自负金额合计
        /// </summary>
        public string strSumPersonMoney = "";
        /// <summary>
        /// 查找病人最后一次没有收费的处方号
        /// </summary>
        public void m_mthFindMaxRecipeNoByPatientID()
        {
            string strRecipe;
            string strstatus;
            string strSeqid = "";
            string strISgreen = "";
            DataTable dt;
            long ret = 0;
            ////先诊疗后结算病人处方查询
            //if (this.m_objViewer.m_PatientBasicInfo.m_strIsVip == "1")
            //{
            //    ret = objSvc.m_mthFindTreatRecipeNoByPatientID(m_objViewer.m_PatientBasicInfo.PatientID, out strRecipe,out strSeqid, out strstatus, out RecipeCount, out dt);
            //    this.m_objViewer.blnFlag = true;
            //}
            //else
            //{
            ret = objSvc.m_mthFindMaxRecipeNoByPatientID(m_objViewer.m_PatientBasicInfo.PatientID, out strRecipe, out strSeqid, out strstatus, out RecipeCount, out dt, out strISgreen);
            //}
            if (SumRecipeCount == 0)//如果为0代表重新开始查询病人处方数
            {
                SumRecipeCount = this.RecipeCount;
                //if(RecipeCount>1)
                //{
                //    MessageBox.Show("该病人共"+RecipeCount.ToString()+"未结处方");
                //}
            }
            if (!string.IsNullOrEmpty(strISgreen) && strISgreen == "1")
            {
                this.m_objViewer.blnFlag = true;
            }
            else
            {
                this.m_objViewer.blnFlag = false;
            }
            if (ret > 0 && strRecipe.Trim() != "")
            {
                this.m_objViewer.txtLoadRecipeNO.Text = strRecipe;
                this.m_objViewer.txtLoadRecipeNO.Tag = strSeqid;
                clsRecipeInfo_VO[] objRI_VO = null;
                long l = objSvc.m_mthFindRecipeDoctor(this.m_objViewer.m_PatientBasicInfo.PatientID, strRecipe, out objRI_VO);
                if (l > 0 && objRI_VO != null)
                {
                    this.m_objViewer.m_PatientBasicInfo.DoctorName = objRI_VO[0].m_strDoctorName;
                    this.m_objViewer.m_PatientBasicInfo.DoctorID = objRI_VO[0].m_strDoctorID;
                    this.m_objViewer.m_PatientBasicInfo.DoctorNo = objRI_VO[0].m_strDoctorNo;
                    this.m_objViewer.m_PatientBasicInfo.DeptName = objRI_VO[0].m_strDepName;
                    this.m_objViewer.m_PatientBasicInfo.DeptID = objRI_VO[0].m_strDepID;
                    this.m_objViewer.m_PatientBasicInfo.PayTypeName = objRI_VO[0].m_strPatientTypeName;
                    this.m_objViewer.m_PatientBasicInfo.PayTypeID = objRI_VO[0].m_strPatientTypeID;
                    this.m_objViewer.m_PatientBasicInfo.PatientType = objRI_VO[0].m_intINTERNALFLAG_INT;
                    this.m_objViewer.m_PatientBasicInfo.Limit = objRI_VO[0].decLimint;
                    this.m_objViewer.m_PatientBasicInfo.Discount = objRI_VO[0].decDiscount;
                    //正副方设置, 默认取第一条处方的属性
                    if (objRI_VO[0].m_strRECIPEFLAG_INT.Trim() == "2")
                    {
                        this.m_objViewer.m_cmbRecipeType.SelectedIndex = 1;
                    }
                    else
                    {
                        this.m_objViewer.m_cmbRecipeType.SelectedIndex = 0;
                    }
                }
                this.m_objViewer.btSave.Tag = strRecipe;
                this.m_mthCreatNewCalobj();
                //这里用了strstatus记录了同一次收费和处方数
                //业务需求：如果一个病人有多张未收钱的处方，现在的系统要求把同医生和同病人身份的处
                //方一起调出收费。
                int intTempCount = int.Parse(strstatus);
                if (intTempCount > 1)
                {
                    //业务需求：有一张以上处方时，要求询问用户时否调出，如果用户选择了“否”
                    //则获取第一张的处方号。然后循环明细列表，把不同处方号的数据删除。
                    if (MessageBox.Show("共有" + strstatus + "张同医生处方，是否一起调出?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        string strTempRecipeID = "";
                        if (dt.Rows.Count > 0)
                        {
                            strTempRecipeID = dt.Rows[0]["OUTPATRECIPEID_CHR"].ToString().Trim();
                        }
                        for (int i = dt.Rows.Count - 1; i > -1; i--)
                        {
                            if (dt.Rows[i]["OUTPATRECIPEID_CHR"].ToString().Trim() != strTempRecipeID)
                            {
                                dt.Rows[i].Delete();
                            }
                        }
                        dt.AcceptChanges();

                    }
                }
                //在填充数据到DataGrid中时，会把处方号保存到HashTalbe中去。函数内部也有说明。
                this.m_objViewer.IsSave = false;

                //再次初始化
                this.m_objViewer.m_blnIsSelectChargeItem = false;
                //  判断是先诊疗后结算的病人，然后选择缴费项目
                if (strISgreen == "1")
                {
                    frmOPSelectChargeItem objFrom = new frmOPSelectChargeItem(dt, strRecipe);
                    if (objFrom.ShowDialog() == DialogResult.OK)
                    {
                        DataTable dtbTemp = objFrom.m_dtbSelectTable;
                        List<string> lstOrderDicItemID = objFrom.m_lstOrderDicItemID;
                        if (dtbTemp.Rows.Count != dt.Rows.Count)//不相等，说明已经进行选择交费
                        {
                            //改变成为手工处方,并把之前的主处方的pstauts_int改为5
                            //m_mthSelectFeeDispose(dtbTemp, lstOrderDicItemID);
                            m_mthGetSelectChargeItemID(dtbTemp, lstOrderDicItemID);
                            this.m_objViewer.m_blnIsSelectChargeItem = true;
                            dt = dtbTemp;
                            //记录选择的收费项目
                        }

                    }
                }

                string strMedUsageID = "0021";
                DataTable dtKFUsageID = new DataTable();
                clsDcl_OPCharge objDcl = new clsDcl_OPCharge();
                objDcl.m_lngGetMedUsageID(strMedUsageID, ref dtKFUsageID);
                objDcl = null;

                List<string> lisKFUsageID = new List<string>();
                string[] strKFUsageIDArr = null;
                if (dtKFUsageID != null && dtKFUsageID.Rows.Count > 0)
                {
                    strKFUsageIDArr = dtKFUsageID.Rows[0][0].ToString().Split(';');
                    for (int k = 0; k < strKFUsageIDArr.Length; k++)
                    {
                        lisKFUsageID.Add(strKFUsageIDArr[k]);
                    }
                }

                DataView dvTemp = dt.DefaultView;
                dvTemp.Sort = "rowno_chr asc";
                DataTable dtTemp = dvTemp.ToTable();
                int intNumOfMedBag = 0;
                for (int j = 0; j < dtTemp.Rows.Count; j++)
                {
                    string strRowNo = dtTemp.Rows[j]["rowno_chr"].ToString().Trim();
                    string strCatID = dtTemp.Rows[j]["catid"].ToString().Trim();
                    string strUsageID = dtTemp.Rows[j]["usageid_chr"].ToString().Trim();
                    string strNextRowNo = "";
                    if (j + 1 < dt.Rows.Count)
                    {
                        strNextRowNo = dtTemp.Rows[j + 1]["catid"].ToString().Trim();
                    }

                    if (strRowNo == "0" && strCatID == "2" && lisKFUsageID.Contains(strUsageID))
                    {
                        ++intNumOfMedBag;
                    }
                    else if (strCatID == "2" && lisKFUsageID.Contains(strUsageID))
                    {
                        if (strRowNo != strNextRowNo)
                        {
                            ++intNumOfMedBag;
                        }
                    }
                }

                this.m_mthFillDataGrid(dt);

                if (intNumOfMedBag > 0)
                {
                    m_objViewer.ctlDataGrid1.Select();
                    m_objViewer.ctlDataGrid1.Focus();
                    m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(this.m_objViewer.ctlDataGrid1.RowCount, 0);
                    // SendKeys.SendWait("841257"); 加收药袋收费编码 --旧
                    SendKeys.SendWait("594957");  // 加收药袋收费编码 -- 新 代码反过来按键触发
                    SendKeys.SendWait("{ENTER}");
                    SendKeys.SendWait("{ENTER}");
                    string strTemp = intNumOfMedBag.ToString();
                    string strNumOfBag = "";
                    for (int i1 = strTemp.Length - 1; i1 >= 0; i1--)
                    {
                        strNumOfBag += strTemp[i1].ToString();
                    }
                    SendKeys.SendWait(strNumOfBag);
                    SendKeys.SendWait("{ENTER}");
                }

                if (IsCanModify)
                {
                    //this.m_objViewer.ctlDataGrid1.Enabled=false;
                    ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[0]).ReadOnly = true;
                    ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[1]).ReadOnly = true;
                    this.m_objViewer.btOK.Focus();
                }
                else
                {
                    this.m_objViewer.ctlDataGrid1.Enabled = true;
                    ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[0]).ReadOnly = false;
                    ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[1]).ReadOnly = false;
                    this.m_mthSetFocusOnDataGrid();
                }

                if (!IsModifyrecipetype)
                {
                    this.m_objViewer.m_PatientBasicInfo.txtType.Enabled = false;
                    this.m_objViewer.m_PatientBasicInfo.txtRegisterDept.Enabled = false;
                    this.m_objViewer.m_PatientBasicInfo.txtRegisterDoctor.Enabled = false;
                    this.m_objViewer.m_cmbRecipeType.Enabled = false;
                }

                if (!Recsumflag)
                {
                    this.m_mthIsOverFlow();
                }
            }
        }
        #endregion

        #region 根据处方号查找以往处方明细
        /// <summary>
        /// 根据处方号查找以往处方明细
        /// </summary>
        /// <param name="ID"></param>
        public void m_mthFindRecipeByID(string ID)
        {

            if (ID.Trim() == "")
            {
                return;
            }

            clsRecipeInfo_VO obj = this.m_objViewer.txtLoadRecipeNO.RecipeInfo;
            bool flag = false;
            if (obj.m_intPSTATUS_INT == 4)
            {
                flag = true;
            }

            this.m_mthFindRecipeDataByID(ID, flag);
            this.m_mthSetButtonEnable();
            if (!(obj.m_intPSTATUS_INT == 5))//m_intPSTATUS_INT == 5 是先诊疗后结算的处方
            {
                if (objSvc.m_blnCheckRecipeProperty(ID))
                {
                    MessageBox.Show("该处方为已收费(退票)的医生所开处方，不能复用。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.m_objViewer.btReUse.Enabled = false;
                }
            }
            else
            {
                //先诊后结算的处方调处方结算时，查出以前的缴费流水号
                string strSeqid = string.Empty;
                this.objSvc.m_lngGetRecipeByRecipeNo(ID, out strSeqid);
                this.m_objViewer.txtLoadRecipeNO.Tag = strSeqid;
                this.m_mthSetControlEnable(true);
            }


            if (flag && !IsModifyrecipetype)
            {
                this.m_objViewer.m_PatientBasicInfo.txtType.Enabled = false;
                this.m_objViewer.m_PatientBasicInfo.txtRegisterDept.Enabled = false;
                this.m_objViewer.m_PatientBasicInfo.txtRegisterDoctor.Enabled = false;
                this.m_objViewer.m_cmbRecipeType.Enabled = false;
            }
        }
        private void m_mthFindRecipeDataByID(string ID, bool flag)
        {
            this.OverFlowFlag = false;
            DataTable dt = null;

            //先诊疗后结算，选择缴费项目  ddy
            //再次初始化
            long ret = -1;
            this.m_objViewer.m_blnIsSelectChargeItem = false;
            //  判断是先诊疗后结算的病人，然后选择缴费项目
            if (this.m_objViewer.txtLoadRecipeNO.RecipeInfo.m_strIsGreen == "1")
            {
                ret = objSvc.m_mthFindRecipeByID(ID, out dt, true);
                frmOPSelectChargeItem objFrom = new frmOPSelectChargeItem(dt, ID);
                if (objFrom.ShowDialog() == DialogResult.OK)
                {
                    DataTable dtbTemp = objFrom.m_dtbSelectTable;
                    List<string> lstOrderDicItemID = objFrom.m_lstOrderDicItemID;
                    if (dtbTemp.Rows.Count != dt.Rows.Count)//不相等，说明已经进行选择交费
                    {
                        //改变成为手工处方,并把之前的主处方的pstauts_int改为5
                        //m_mthSelectFeeDispose(dtbTemp, lstOrderDicItemID);
                        m_mthGetSelectChargeItemID(dtbTemp, lstOrderDicItemID);
                        this.m_objViewer.m_blnIsSelectChargeItem = true;
                        dt = dtbTemp;
                        //记录选择的收费项目
                    }
                }
            }
            else
            {
                ret = objSvc.m_mthFindRecipeByID(ID, out dt, flag);
            }

            this.m_mthCreatNewCalobj();
            if (ret > 0 && dt.Rows.Count > 0)
            {
                this.m_mthFillDataGrid(dt);
            }
            this.m_objViewer.btSave.Tag = ID;
            if (IsCanModify && flag)
            {
                //this.m_objViewer.ctlDataGrid1.Enabled = false;
                ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[0]).ReadOnly = true;
                ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[1]).ReadOnly = true;
                this.m_objViewer.btOK.Focus();
            }
            else
            {
                this.m_objViewer.ctlDataGrid1.Enabled = true;
                ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[0]).ReadOnly = false;
                ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[1]).ReadOnly = false;
                this.m_mthSetFocusOnDataGrid();
            }

            this.OverFlowFlag = true;

            if (!Recsumflag)
            {
                this.m_mthIsOverFlow();
            }
        }
        /// <summary>
        /// 根据查出的处方明细填充datagrid
        /// </summary>
        /// <param name="dt"></param>
        private void m_mthFillDataGrid(DataTable dt)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }

            BathCalc = true;
            //临时处方号        
            string strTempRecipeID = "";

            for (int ii = 0; ii < dt.Rows.Count; ii++)
            {
                //也处方信息保存在HashTable中。
                if (strTempRecipeID != dt.Rows[ii]["OUTPATRECIPEID_CHR"].ToString().Trim())
                {
                    clsOutPatientRecipe_VO objTemp = new clsOutPatientRecipe_VO();
                    objTemp.m_intPStatus = 2;
                    objTemp.intCreatetype = 0;
                    objTemp.m_strCaseHistoryID = dt.Rows[ii]["casehisid_chr"].ToString().Trim();
                    objTemp.m_strDepID = dt.Rows[ii]["DIAGDEPT_CHR"].ToString().Trim();
                    objTemp.m_strCreateDate = dt.Rows[ii]["CREATEDATE_DAT"].ToString().Trim();
                    objTemp.m_strRecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    objTemp.m_strDoctorID = dt.Rows[ii]["DIAGDR_CHR"].ToString().Trim();
                    objTemp.m_strOutpatRecipeID = dt.Rows[ii]["OUTPATRECIPEID_CHR"].ToString().Trim();
                    objTemp.m_strPatientType = dt.Rows[ii]["PAYTYPEID_CHR"].ToString().Trim();
                    objTemp.m_strRecipeType = dt.Rows[ii]["TYPE_INT"].ToString().Trim();
                    objTemp.m_strRegisterID = dt.Rows[ii]["REGISTERID_CHR"].ToString().Trim();
                    objTemp.m_intType = int.Parse(dt.Rows[ii]["RECIPEFLAG_INT"].ToString());
                    objTemp.m_strPatientID = m_objViewer.m_PatientBasicInfo.PatientID.Trim();
                    objTemp.strIDcard = this.m_objViewer.txtIDcard.Text.Trim();
                    objTemp.strInsuranceID = this.m_objViewer.txtInsuranceID.Text.Trim();
                    strTempRecipeID = dt.Rows[ii]["OUTPATRECIPEID_CHR"].ToString().Trim();
                    this.objHashTable.Add(ii, objTemp);
                }
                //				decimal discount =this.objCalPatientCharge.m_mthGetDiscountByID(dt.Rows[ii]["ItemID"].ToString());
                decimal discount = this.m_mthConvertObjToDecimal(dt.Rows[ii]["DISCOUNT_DEC"]);
                string strUnit = dt.Rows[ii]["UNIT"].ToString();
                decimal decPrice = m_mthConvertObjToDecimal(dt.Rows[ii]["price"]);
                decimal decDiffPrice = 0;
                if (blMedicine9003(dt.Rows[ii]["ItemID"].ToString().Trim()))
                {
                    decDiffPrice = m_mthConvertObjToDecimal(dt.Rows[ii]["tradeprice_mny"]);// 批发价格
                }
                else
                {
                    decDiffPrice = decPrice;
                }
                if (string.IsNullOrEmpty(dt.Rows[ii]["tradeprice_mny"].ToString()))
                    decDiffPrice = decPrice;
                //判断是否是药和是否是用小单位计算。小单位计算是指：药能否分散出售，如一盒药有十粒，
                //如果能一粒一粒卖主不是小单位计算，反之按大单位计算。在收费项目中定义了。
                //判断是否时药则是按发票分类来定义
                if (m_mthIsMedicine(dt.Rows[ii]["InvType"].ToString().Trim()) && dt.Rows[ii]["OPCHARGEFLG_INT"].ToString().Trim() == "1")
                {
                    strUnit = dt.Rows[ii]["ITEMIPUNIT_CHR"].ToString().Trim();//单位
                    decPrice = this.m_mthConvertObjToDecimal(dt.Rows[ii]["SUBMONEY"]);//单价
                }
                if (blMedicine9003(dt.Rows[ii]["ItemID"].ToString().Trim()) && dt.Rows[ii]["OPCHARGEFLG_INT"].ToString().Trim() == "1")
                {
                    decDiffPrice = this.m_mthConvertObjToDecimal(dt.Rows[ii]["subtrademoney"]);// 批发单位价格
                }
                if (m_mthConvertObjToDecimal(dt.Rows[ii]["Times"]) > m_objViewer.numericUpDown1.Value)//中药服数赋值,把最大的值的赋给它
                {
                    m_objViewer.numericUpDown1.Value = m_mthConvertObjToDecimal(dt.Rows[ii]["Times"]);
                }
                this.m_objViewer.cboProxyBoilMed.SelectedIndex = (int)m_mthConvertObjToDecimal(dt.Rows[ii]["isproxyboilmed"]);

                //把数据放到DataGrid 中。
                object[] objNewRow ={
							dt.Rows[ii]["ITEMCODE_VCHR"].ToString(),//查询
							dt.Rows[ii]["quantity"].ToString(),//剂量
							dt.Rows[ii]["itemname"],//项目名称
							m_mthConvertToChType(dt.Rows[ii]["InvType"].ToString()),//类型
							dt.Rows[ii]["Dec"],//规格
							strUnit,//单位
							decPrice,//单价
							dt.Rows[ii]["SumMoney"],//总价
							dt.Rows[ii]["InvType"].ToString(),//门诊发票核算类别ID
							m_mthRelationInfo(dt.Rows[ii]["InvType"].ToString().Trim()),//收费项目分类ID
							dt.Rows[ii]["ItemID"].ToString(),//项目ID
							dt.Rows[ii]["SELFDEFINE"].ToString(),//自定价格
							ii.ToString(),//行号
							discount.ToString()+"%",
							discount,
						    dt.Rows[ii]["ITEMOPCALCTYPE_CHR"].ToString(),
						    dt.Rows[ii]["ROWNO_CHR"].ToString(),
							dt.Rows[ii]["USAGEID_CHR"].ToString(),
							dt.Rows[ii]["FREQID_CHR"].ToString(),
						   	dt.Rows[ii]["QTY_DEC"].ToString(),
							dt.Rows[ii]["DAYS_INT"].ToString(),
							dt.Rows[ii]["DOSAGEUNIT_CHR"].ToString(),
							dt.Rows[ii]["ATTACHID_VCHR"].ToString(),
					        m_mthConvertObjToDecimal(dt.Rows[ii]["SumMoney"])*discount/100,
						 	dt.Rows[ii]["HYPETEST_INT"].ToString(),
							dt.Rows[ii]["DESC_VCHR"].ToString(),
					        dt.Rows[ii]["OUTPATRECIPEID_CHR"].ToString(),
                            dt.Rows[ii]["ATTACHPARENTID_VCHR"].ToString(),
                            dt.Rows[ii]["attachitembasenum_dec"].ToString(),
                            dt.Rows[ii]["USAGEPARENTID_VCHR"].ToString(),
                            dt.Rows[ii]["usageitembasenum_dec"].ToString(),
                            dt.Rows[ii]["deptmed_int"].ToString(),
                            dt.Rows[ii]["orderid"].ToString(),
                            dt.Rows[ii]["ordernum"].ToString(),
                            dt.Rows[ii]["insuranceid_chr"].ToString()};

                m_objViewer.ctlDataGrid1.m_mthAppendRow(objNewRow);
                decimal temp = m_mthConvertObjToDecimal(dt.Rows[ii]["quantity"]);
                //decimal temp = m_mthConvertObjToDecimal(dt.Rows[ii]["discount_dec"]);

                if (dt.Rows[ii]["InvType"].ToString().Trim() == objCalPatientCharge.InvoiceCatID)
                {
                    temp = temp * this.m_mthConvertObjToDecimal(dt.Rows[ii]["Times"]);
                    temp = Math.Ceiling(temp);
                }
                if (dt.Rows[ii]["SUMUSAGE_VCHR"].ToString().Trim() != "")
                {
                    this.m_objViewer.numericUpDown1.Tag = dt.Rows[ii]["SUMUSAGE_VCHR"].ToString().Trim();
                }
                if (intDiffPriceOn == 1)// 若启用让利则按批发价格来算
                    m_objViewer.ctlDataGrid1[ii, 12] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[ii]["ItemID"].ToString(), decPrice, decDiffPrice, dt.Rows[ii]["InvType"].ToString(), temp, 2000, discount, dt.Rows[ii]["ITEMOPCALCTYPE_CHR"].ToString(), CheckIsDiff(dt.Rows[ii]["ItemID"].ToString()));
                else
                    m_objViewer.ctlDataGrid1[ii, 12] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[ii]["ItemID"].ToString(), decPrice, dt.Rows[ii]["InvType"].ToString(), temp, 2000, discount, dt.Rows[ii]["ITEMOPCALCTYPE_CHR"].ToString(), false);

                m_objViewer.ctlDataGrid1[ii, 36] = dt.Rows[ii]["opchargeflg_int"].ToString();
                //if (m_mthConvertObjToDecimal(dt.Rows[ii]["Times"]) > m_objViewer.numericUpDown1.Value)//中药服数赋值,把最大的值的赋给它
                //{
                //    m_objViewer.numericUpDown1.Value = m_mthConvertObjToDecimal(dt.Rows[ii]["Times"]);
                //}
                // 总让利金额
                if (intDiffPriceOn == 1)
                {
                    if (blMedicine9003(m_objViewer.ctlDataGrid1[ii, 10].ToString()))
                    {
                        if (!string.IsNullOrEmpty(temp.ToString()))
                        {
                            m_objViewer.ctlDataGrid1[ii, intDiffPriceTotalCol] = ((decDiffPrice - m_mthConvertObjToDecimal(m_objViewer.ctlDataGrid1[ii, 6].ToString().Trim())) * m_mthConvertObjToDecimal(dt.Rows[ii]["quantity"].ToString()) * m_objViewer.numericUpDown1.Value).ToString("0.00");
                        }
                        else
                        {
                            m_objViewer.ctlDataGrid1[ii, intDiffPriceTotalCol] = dt.Rows[ii]["toldiffprice_mny"].ToString();
                        }
                    }
                    else
                    {
                        m_objViewer.ctlDataGrid1[ii, intDiffPriceTotalCol] = 0;
                    }
                    //((m_mthConvertObjToDecimal(dt.Rows[ii]["tradeprice_mny"]) - m_mthConvertObjToDecimal(dt.Rows[ii]["price"])) * temp).ToString("0.00"); //this.objCalPatientCharge.m_mthGetChargeIetmPrice(dt.Rows[ii]["ItemID"].ToString(), decPrice, decDiffPrice, dt.Rows[ii]["InvType"].ToString(), temp, 2000, discount, dt.Rows[ii]["ITEMOPCALCTYPE_CHR"].ToString()); // dt.Rows[ii]["toldiffprice_mny"].ToString();
                }
                else
                {
                    m_objViewer.ctlDataGrid1[ii, intDiffPriceTotalCol] = 0;
                }
                m_objViewer.ctlDataGrid1[ii, intDiffUnitPriceCol] = decDiffPrice;

                this.m_objViewer.IsSave = false;
                this.m_objViewer.rowNO = ii;
            }
            this.m_mthDisplayCharge();

            m_objViewer.ctlDataGrid1.Select();
            m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(m_objViewer.ctlDataGrid1.RowCount, 0);

            BathCalc = false;
        }
        private void m_mthSetButtonEnable()
        {
            clsRecipeInfo_VO obj = this.m_objViewer.txtLoadRecipeNO.RecipeInfo;
            if (obj.m_strRECIPEFLAG_INT.Trim() == "2")//正副方设置
            {
                m_objViewer.m_cmbRecipeType.SelectedIndex = 1;
            }
            else
            {
                m_objViewer.m_cmbRecipeType.SelectedIndex = 0;
            }
            if (obj.m_intPSTATUS_INT == 1 || obj.m_intPSTATUS_INT == 4)
            {
                this.m_mthSetControlEnable(true);
            }
            else
            {
                this.m_mthSetControlEnable(false);
            }

            //m_objViewer.ctlDataGrid1.Enabled = !IsCanModify;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[0]).ReadOnly = IsCanModify;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[1]).ReadOnly = IsCanModify;
        }
        /// <summary>
        /// 设置控件是否可用
        /// </summary>
        /// <param name="flag"></param>
        private void m_mthSetControlEnable(bool flag)
        {
            m_objViewer.btOK.Enabled = flag;
            m_objViewer.btSave.Enabled = flag;
            this.m_objViewer.m_PatientBasicInfo.txtRegisterDept.Enabled = flag;
            this.m_objViewer.m_PatientBasicInfo.txtRegisterDoctor.Enabled = flag;
            IsReadOnly = flag;
            m_objViewer.btReUse.Enabled = !flag;
        }
        #endregion

        #region 设置光标在DataGrid控件
        private void m_mthClearEmptyRow()
        {
            for (int i = m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
            {
                //				if(m_objViewer.ctlDataGrid1.RowCount==1&&m_objViewer.ctlDataGrid1[0,12].ToString().Trim()=="")
                //				{
                //					break;
                //				}
                if (m_objViewer.ctlDataGrid1[i, 12].ToString().Trim() == "" || m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() == "")
                {
                    m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                }

            }
        }
        public void m_mthSetFocusOnDataGrid()
        {
            if (this.m_objViewer.ctlDataGrid1.Enabled == false)
            {
                this.m_objViewer.m_PatientBasicInfo.txtCardID.Focus();
                return;
            }
            m_mthClearEmptyRow();
            int row = m_objViewer.ctlDataGrid1.RowCount;
            m_objViewer.ctlDataGrid1.Select();
            m_objViewer.ctlDataGrid1.Focus();
            m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(row, 0);
            SendKeys.SendWait("{Right}");
            SendKeys.SendWait("{Left}");
        }
        #endregion

        #region 判断发票是否是当前操作者所领
        public bool IsOccupied(string InvoiceNO)
        {
            if (InvoiceNO.Trim() == "")
            {
                return true;
            }
            clsT_opr_opinvoiceman_VO[] p_objResultArr = new clsT_opr_opinvoiceman_VO[0];
            long lngRes = new clsDcl_InvoiceManage().m_lngGetApplyInvoice("", "", this.m_objViewer.LoginInfo.m_strEmpID, 0, out p_objResultArr);
            for (int i = 0; i < p_objResultArr.Length; i++)
            {
                if (int.Parse(InvoiceNO) > int.Parse(m_mtRemoveString(p_objResultArr[i].m_strINVOICENOFROM_VCHR)) && int.Parse(InvoiceNO) < int.Parse(m_mtRemoveString(p_objResultArr[i].m_strINVOICENOTO_VCHR)))
                {
                    return true;
                }
            }
            return false;

        }
        private string m_mtRemoveString(string str)
        {
            for (int i = str.Length - 1; i > -1; i--)
            {
                if (!char.IsNumber(str, i))
                {
                    str = str.Remove(i, 1);
                }
            }
            return str;
        }
        #endregion

        #region 转换成数字
        private decimal m_mthConvertObjToDecimal(object obj)
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
        private decimal m_mthConvertObjToDecimal(string str)
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

        #region 病人类型转变
        /// <summary>
        /// 病人类型型转变
        /// 业务需求:当改变病人身份时，要重新以病人身份ID生成一个新的计费类。
        /// 然后循环DataGrid的项目重新计算项目价钱。
        /// 计费类对象提供了方法（m_mthGetDiscountByID）。
        /// </summary>
        public void m_mthPatientTypeChanged()
        {
            objCalPatientCharge = null;
            objCalPatientCharge = new clsCalcPatientCharge(m_objViewer.m_PatientBasicInfo.PatientID, m_objViewer.m_PatientBasicInfo.PayTypeID, m_objViewer.m_PatientBasicInfo.Limit, this.m_objComInfo.m_strGetHospitalTitle(), m_objViewer.m_PatientBasicInfo.PatientType, m_objViewer.m_PatientBasicInfo.Discount);
            //加载右边的显示控件。
            if (this.m_objViewer.panel2.Controls.Count > 0)
            {
                this.objCalPatientCharge.GetDisplayControl = this.m_objViewer.panel2.Controls[0];
            }
            else
            {
                this.m_objViewer.panel2.Controls.Add(this.objCalPatientCharge.GetDisplayControl);
            }

            if (this.m_objViewer.chkDefaultItem.Checked)
            {
                IsChrgFlag = false;
                this.m_mthGetDefaultItem();
            }

            decimal discount;
            decimal count;
            //循环DataGrid的项目重新计算项目价钱(默认带出不计算)

            ArrayList objItemArr = new ArrayList();
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, 12] != null && this.m_objViewer.ctlDataGrid1[i, 12].ToString().Trim() != "" && this.m_objViewer.ctlDataGrid1[i, DefaultCol].ToString().Trim() != "&")
                {
                    objItemArr.Add(this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim());
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

                clsDcl_DoctorWorkstation objSvcDoct = new clsDcl_DoctorWorkstation();
                objSvcDoct.m_lngGetItemScaleByArr(this.m_objViewer.m_PatientBasicInfo.PayTypeID, strItemIDArr, ref hasItemScale);
                objSvcDoct = null;
            }


            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, 12] != null && this.m_objViewer.ctlDataGrid1[i, 12].ToString().Trim() != "" && this.m_objViewer.ctlDataGrid1[i, DefaultCol].ToString().Trim() != "&")
                {
                    discount = Convert.ToDecimal(hasItemScale[this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim()].ToString());
                    this.m_objViewer.ctlDataGrid1[i, 14] = discount;
                    this.m_objViewer.ctlDataGrid1[i, 13] = discount.ToString() + "%";
                    count = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]);
                    //如果是中草药的话，则要乘上服数来计算。
                    //因为每家医院的中草药的发票分类都不一样，因为在计费类定死了中草药的发票分类ID
                    if (this.m_objViewer.ctlDataGrid1[i, 8].ToString().Trim() == this.objCalPatientCharge.InvoiceCatID)
                    {
                        count = count * this.m_objViewer.numericUpDown1.Value;
                    }
                    string strcat = m_objViewer.ctlDataGrid1[i, 15].ToString().Trim();
                    if (this.intDiffPriceOn == 1)
                        m_objViewer.ctlDataGrid1[i, 12] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim(), m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 6]), m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 38]), this.m_objViewer.ctlDataGrid1[i, 8].ToString().Trim(), count, 2000, discount, strcat, CheckIsDiff(i));
                    else
                        m_objViewer.ctlDataGrid1[i, 12] = this.objCalPatientCharge.m_mthGetChargeIetmPrice(this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim(), m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 6]), this.m_objViewer.ctlDataGrid1[i, 8].ToString().Trim(), count, 2000, discount, strcat, false);
                    this.m_objViewer.ctlDataGrid1[i, 23] = discount / 100 * this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 7]);
                }
                else
                {
                    continue;
                }
            }

            this.m_mthSetcardtype();
            this.m_mthDisplayCharge();
        }
        #endregion

        #region 设置患者类型(卡/号)
        /// <summary>
        /// 设置患者类型(卡/号)
        /// </summary>
        public void m_mthSetcardtype()
        {
            switch (this.m_objViewer.m_PatientBasicInfo.PatientType)
            {
                case 1:
                    this.m_objViewer.lblCardtype.Text = "公费编号:";
                    break;
                case 2:
                    this.m_objViewer.lblCardtype.Text = "医保编号:";
                    break;
                case 3:
                    this.m_objViewer.lblCardtype.Text = "特困编号:";
                    break;
                case 4:
                    this.m_objViewer.lblCardtype.Text = "离休编号:";
                    break;
                case 5:
                    this.m_objViewer.lblCardtype.Text = "医疗证号:";
                    break;
                default:
                    this.m_objViewer.lblCardtype.Text = "普通:";
                    break;
            }

            if (this.m_objViewer.m_PatientBasicInfo.PatientID.Trim() != "")
            {
                this.m_objViewer.txtInsuranceID.Text = objSvc.m_strGetpatientidentityno(this.m_objViewer.m_PatientBasicInfo.PatientID, this.m_objViewer.m_PatientBasicInfo.PayTypeID);
            }
        }
        #endregion

        #region 检查发票号是否已用
        /// <summary>
        /// 检查发票号是否已用
        /// </summary>
        /// <returns></returns>
        public bool m_mthCheckInvoice()
        {
            if (this.m_objViewer.m_txtInvoiceNO.Text.Trim() == "")
            {
                MessageBox.Show("发票号不能为空!");
                this.m_objViewer.m_txtInvoiceNO.Select();
                this.m_objViewer.m_txtInvoiceNO.SelectAll();
                return true;
            }

            if (objSvc.m_mthCheckInvoice(this.m_objViewer.m_txtInvoiceNO.Text.Trim()))
            {
                if (!this.isCanDo)
                {
                    MessageBox.Show("发票号已经占用,请修改!", "ICare", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
                else
                {
                    if (MessageBox.Show("发票号已经占用,是否继续?", "ICare", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        this.m_objViewer.m_txtInvoiceNO.Select();
                        this.m_objViewer.m_txtInvoiceNO.SelectAll();
                        return true;
                    }
                }

            }
            return false;
        }
        #endregion

        #region 检查发票号是否是当前收费员申领
        /// <summary>
        /// 检查发票号是否是当前收费员申领
        /// </summary>
        /// <returns></returns>
        internal bool m_blnCheckInvoice()
        {
            if (clsPublic.m_intGetSysParm("0100") == 0)
            {
                return true;
            }
            bool blnPass = false;
            string strInvoiceNo = m_objViewer.m_txtInvoiceNO.Text.Trim();
            blnPass = objSvc.m_blnCheckInvoice(m_objViewer.LoginInfo.m_strEmpID, strInvoiceNo);
            if (!blnPass)
            {
                MessageBox.Show("输入的发票号不是您所申领", "注意", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                m_objViewer.m_txtInvoiceNO.SelectAll();
            }
            return blnPass;
        }
        #endregion

        #region 判断是否药品
        /// <summary>
        /// 判断是否药品和材料项目
        /// </summary>
        /// <param name="strCatID"></param>
        /// <returns></returns>
        public bool m_mthIsMedicine(string strCatID)
        {
            bool ret = false;
            if (objCalPatientCharge.m_mthIsMedicine(strCatID) > 0)
            {
                ret = true;
            }
            return ret;
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

        #region 查找对应表信息
        private DataTable dt_RelationInfo;
        /// <summary>
        /// 根据发票分类来区分分类。
        /// 业务需求：系统定死了几个分类来跟发票分类对应。0001-西药，0002-中草药，0003-检验，0004-检查，0005-手术\治疗，0005-其他
        /// 这样定义是为了，让明处方明细保存到对应的表中。有个界面维护关系。
        /// </summary>
        /// <param name="strCatID"></param>
        /// <returns></returns>
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
            return str;
        }
        #endregion

        #region 打印处方
        public void m_mthBeginPrint()
        {
            if (this.strSendMedicinePrinterName.Trim() != "")
            {
                this.m_objViewer.printDocument1.DefaultPageSettings.PrinterSettings.PrinterName = this.strSendMedicinePrinterName;
            }
            clsOutpatientPrintRecipe_VO obj_VO = new clsOutpatientPrintRecipe_VO();
            //中成,西
            decimal decWMedicineCost = 0;
            //中草药
            decimal decZCMedicineCost = 0;
            //检验
            decimal decCureCost = 0;
            //其他
            decimal decOther = 0;

            obj_VO.m_strAge = this.m_objViewer.m_PatientBasicInfo.PatientAge.Trim();
            obj_VO.m_strPatientType = this.m_objViewer.m_PatientBasicInfo.txtType.Text;
            obj_VO.m_strCardID = this.m_objViewer.m_PatientBasicInfo.PatientCardID.Trim();
            obj_VO.m_strDiagDeptID = this.m_objViewer.m_PatientBasicInfo.txtRegisterDept.Text.Trim();
            obj_VO.m_strDiagDrName = this.m_objViewer.m_PatientBasicInfo.txtRegisterDoctor.Text.Trim();
            obj_VO.m_strHospitalName = this.m_objComInfo.m_strGetHospitalTitle();
            obj_VO.m_strPatientName = this.m_objViewer.m_PatientBasicInfo.PatientName;
            if (this.m_objViewer.btSave.Tag != null)
            {
                obj_VO.m_strRecipeID = this.m_objViewer.btSave.Tag.ToString().Trim();
            }
            else
            {
                obj_VO.m_strRecipeID = "";
            }
            clsHISInfoDefine_VO objResult;
            long l = this.m_objComInfo.m_strGetHospitalInfo(out objResult);
            if (l > 0 && objResult != null)
            {
                obj_VO.m_strAddress = objResult.m_strADDRESS_VCHR + "+" + objResult.m_strPHONE_NUMBER_CHR + "/" + objResult.m_strPHONE_NUMBER2_CHR;
            }
            else
            {
                obj_VO.m_strAddress = "";
            }
            obj_VO.m_strRecipeType = this.m_objViewer.m_cmbRecipeType.Text;
            obj_VO.m_strdiagnose = "";
            obj_VO.m_strGOVCARD = this.m_objViewer.m_PatientBasicInfo.PatientGOVCARD;
            obj_VO.m_strINSURANCEID = this.m_objViewer.m_PatientBasicInfo.PatientINSURANCEID;
            string strEmployee = "0001";//员工ID
            if (this.m_objViewer.LoginInfo != null)
            {
                strEmployee = this.m_objViewer.LoginInfo.m_strEmpNo;
            }
            obj_VO.m_strRecordEmpID = strEmployee;//员工ID
            obj_VO.m_strRegisterID = this.m_objViewer.m_PatientBasicInfo.RegisterID;
            obj_VO.m_strPrintDate = this.m_objViewer.m_PatientBasicInfo.RegisterDate;
            obj_VO.m_strSex = this.m_objViewer.m_PatientBasicInfo.PatientSex;
            obj_VO.m_strSelfPay = "";
            obj_VO.m_strChargeUp = "";
            obj_VO.m_strRecipePrice = "";
            obj_VO.m_strSelfPay = "";
            if (this.m_objViewer.numericUpDown1.Tag != null)
            {
                obj_VO.m_strHerbalmedicineUsage = this.m_objViewer.numericUpDown1.Tag.ToString();
            }
            else
            {
                obj_VO.m_strHerbalmedicineUsage = "";
            }
            obj_VO.m_strTimes = this.m_objViewer.numericUpDown1.Value.ToString();
            int count = this.m_objViewer.ctlDataGrid1.RowCount;
            ArrayList objPRDArr = new ArrayList();
            int CMTemp = 0;//中药项目当前位置
            ArrayList objPRDArr2 = new ArrayList();
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, 12].ToString().Trim() != "")
                {
                    clsOutpatientPrintRecipeDetail_VO objRDVO = new clsOutpatientPrintRecipeDetail_VO();
                    objRDVO.m_strChargeName = this.m_objViewer.ctlDataGrid1[i, 2].ToString().Trim();
                    objRDVO.m_strCount = this.m_objViewer.ctlDataGrid1[i, 1].ToString().Trim();
                    objRDVO.m_strDosage = this.m_objViewer.ctlDataGrid1[i, 19].ToString().Trim() + this.m_objViewer.ctlDataGrid1[i, 21].ToString().Trim();
                    objRDVO.m_strUsage = this.m_mthFindUsageNameByID(this.m_objViewer.ctlDataGrid1[i, 17].ToString().Trim());
                    objRDVO.m_strPrice = this.m_objViewer.ctlDataGrid1[i, 6].ToString().Trim();
                    objRDVO.m_strRowNo = this.m_objViewer.ctlDataGrid1[i, 16].ToString().Trim();
                    objRDVO.m_strSpec = this.m_objViewer.ctlDataGrid1[i, 4].ToString().Trim();
                    objRDVO.m_strSumPrice = this.m_objViewer.ctlDataGrid1[i, 7].ToString().Trim();
                    objRDVO.m_strUnit = this.m_objViewer.ctlDataGrid1[i, 5].ToString().Trim();
                    objRDVO.m_strInvoiceCat = this.m_objViewer.ctlDataGrid1[i, 8].ToString().Trim();
                    //这里用天数记录自付比例
                    objRDVO.m_strDays = this.m_objViewer.ctlDataGrid1[i, 13].ToString().Trim();
                    switch (this.m_objViewer.ctlDataGrid1[i, 9].ToString().Trim())
                    {
                        case "0001":
                            objPRDArr.Add(objRDVO);
                            decWMedicineCost += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 7]);
                            break;
                        case "0002":
                            objRDVO.m_strDosage = this.m_objViewer.ctlDataGrid1[i, 1].ToString().Trim() + this.m_objViewer.ctlDataGrid1[i, 5].ToString().Trim();
                            objPRDArr2.Add(objRDVO);
                            decZCMedicineCost += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 7]);
                            break;
                        case "0003":
                            if (obj_VO.objinjectArr2 == null)
                            {
                                obj_VO.objinjectArr2 = new ArrayList();
                            }
                            obj_VO.objinjectArr2.Add(objRDVO);
                            decCureCost += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 7]);
                            break;
                        case "0006":
                            if (obj_VO.objinjectArr2 == null)
                            {
                                obj_VO.objinjectArr2 = new ArrayList();
                            }
                            obj_VO.objinjectArr2.Add(objRDVO);
                            decCureCost += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 7]);
                            break;
                        default:
                            if (obj_VO.objinjectArr == null)
                            {
                                obj_VO.objinjectArr = new ArrayList();
                            }
                            obj_VO.objinjectArr.Add(objRDVO);
                            decOther += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 7]);
                            break;
                    }

                }
            }
            obj_VO.m_strWMedicineCost = decWMedicineCost.ToString();
            obj_VO.m_strSelfPay = ((decimal)(decWMedicineCost + decOther + decCureCost)).ToString();
            obj_VO.m_strCMedicineCost = decOther.ToString();
            obj_VO.m_strZCMedicineCost = decZCMedicineCost.ToString();
            obj_VO.m_strCureCost = decCureCost.ToString();
            objPRDArr.Sort(0, objPRDArr.Count, null);
            obj_VO.objPRDArr = objPRDArr;
            objPRDArr2.Sort(0, objPRDArr2.Count, null);
            obj_VO.objPRDArr2 = objPRDArr2;
            objCalPatientCharge.UseFlag = 2;
            objCalPatientCharge.PrintRecipeVOInfo = obj_VO;

            //			objCalPatientCharge.m_mthPrintRecipe(e,obj_VO);


        }
        public void m_mthPrintRecipe(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (this.m_objViewer.m_PatientBasicInfo.PatientID.Trim() == "" || this.m_objViewer.ctlDataGrid1.RowCount == 0)
            {
                e.Cancel = true;
                return;
            }
            #region 收集数据
            //			clsOutpatientPrintRecipe_VO obj_VO=new clsOutpatientPrintRecipe_VO();
            //			obj_VO.m_strAge=this.m_objViewer.m_PatientBasicInfo.PatientAge.Trim();
            //			obj_VO.m_strCardID=this.m_objViewer.m_PatientBasicInfo.PatientCardID.Trim();
            //			obj_VO.m_strDiagDeptID=this.m_objViewer.m_PatientBasicInfo.txtRegisterDept.Text.Trim();
            //			obj_VO.m_strDiagDrName=this.m_objViewer.m_PatientBasicInfo.txtRegisterDoctor.Text.Trim();
            //			obj_VO.m_strHospitalName=this.m_objComInfo.m_strGetHospitalTitle();
            //			obj_VO.m_strPatientName=this.m_objViewer.m_PatientBasicInfo.PatientName;
            //			if(this.m_objViewer.btSave.Tag!=null)
            //			{
            //				obj_VO.m_strRecipeID=this.m_objViewer.btSave.Tag.ToString().Trim();
            //			}
            //			else
            //			{
            //			obj_VO.m_strRecipeID= "";
            //			}
            //			string strEmployee ="0001";//员工ID
            //			if(this.m_objViewer.LoginInfo!=null)
            //			{
            //				strEmployee =this.m_objViewer.LoginInfo.m_strEmpID;
            //			}
            //			obj_VO.m_strRecordEmpID=strEmployee;//员工ID
            //			obj_VO.m_strRegisterID=this.m_objViewer.m_PatientBasicInfo.RegisterID;
            //			obj_VO.m_strPrintDate=this.m_objViewer.m_PatientBasicInfo.RegisterDate;
            //			obj_VO.m_strSex=this.m_objViewer.m_PatientBasicInfo.PatientSex;
            //			clsPatientChargeCal objPC=this.objCalPatientCharge.m_mthGetChargeTypeDetail();
            //			obj_VO.m_strSelfPay=objPC.m_decPersonCost.ToString();//自付
            //			obj_VO.m_strChargeUp=objPC.m_decChargeUpCost.ToString();//记账
            //			obj_VO.m_strRecipePrice=objPC.m_decTotalCost.ToString();//总额
            //			int count=this.m_objViewer.ctlDataGrid1.RowCount;
            //			clsOutpatientPrintRecipeDetail_VO[] objPRDArr=new clsOutpatientPrintRecipeDetail_VO[count];
            //			
            //			for(int i=0;i<this.m_objViewer.ctlDataGrid1.RowCount;i++)
            //			{
            //				if(this.m_objViewer.ctlDataGrid1[i,12].ToString().Trim()!="")
            //				{
            //					objPRDArr[i]=new clsOutpatientPrintRecipeDetail_VO();
            //					objPRDArr[i].m_strChargeName=this.m_objViewer.ctlDataGrid1[i,2].ToString().Trim();
            //					objPRDArr[i].m_strCount=this.m_objViewer.ctlDataGrid1[i,1].ToString().Trim();
            //					objPRDArr[i].m_strPrice=this.m_objViewer.ctlDataGrid1[i,6].ToString().Trim();
            //					objPRDArr[i].m_strSumPrice=this.m_objViewer.ctlDataGrid1[i,7].ToString().Trim();
            //					objPRDArr[i].m_strUnit=this.m_objViewer.ctlDataGrid1[i,5].ToString().Trim();
            //					objPRDArr[i].m_strUsage="";
            //					
            //				}
            //			}
            //			
            //			obj_VO.objPRDArr=objPRDArr;
            //			clsPrintRecipe obj =new clsPrintRecipe(e,obj_VO);
            //			obj.m_mthBegionPrint();
            this.objCalPatientCharge.m_mthPrintRecipe(e, "");
            #endregion
        }
        #endregion

        #region 查找模板列表(查找协定处方)
        public void m_mthFindAccordRecipe(string strCode)
        {
            string strEmployeeID = this.m_objViewer.LoginInfo.m_strEmpID;
            frmAccordRecipe objForm = new frmAccordRecipe();
            objForm.UseFlag = 1;
            objForm.FindText = strCode;
            objForm.FindIndex = this.m_objViewer.m_cmbFind.SelectedIndex;
            if (objForm.ShowDialog() == DialogResult.OK)
            {
                int row = this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
                if ((this.m_objViewer.ctlDataGrid1[row, 10].ToString() != "" && this.m_objViewer.ctlDataGrid1[row, 1].ToString() != "") || (this.m_objViewer.ctlDataGrid1[row, 10] == null || this.m_objViewer.ctlDataGrid1[row, 10].ToString() == ""))
                {
                    if (this.m_objViewer.ctlDataGrid1[row, 12].ToString().Trim() != "")
                    {
                        int chrgrow = int.Parse(this.m_objViewer.ctlDataGrid1[row, 12].ToString());
                        this.m_mthDeleteRecipe(chrgrow);
                    }
                    this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(row);
                }

                this.OverFlowFlag = false;
                this.m_mthFillDataGrid(objForm);
                this.OverFlowFlag = true;
                if (!Recsumflag)
                {
                    this.m_mthIsOverFlow();
                }
            }
        }
        /// <summary>
        /// 用协定处方返回来的数据中填充DataGrid
        /// </summary>
        /// <param name="objForm"></param>
        private void m_mthFillDataGrid(frmAccordRecipe objForm)
        {

            DataTable dt = null;
            dt = objForm.GetTable1;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                //这里设置了为3000是为了在收费类内部找到相同的索引而产生一个新的项目。
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 12] = 3000;
                //这里只是调用原来的查询收费项目的方法来填充收费项目。
                int ret = m_mthFindMedicineByIDAcc("ITEMID_CHR", dt.Rows[i][5].ToString().Trim());
                //查询出来后，把数量等那边数据填充DataGrid，然后把状态标志为需求重新计算的状态。
                //再通到DataGrid的CellChanged事件来计算，同步到计费类中。
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 1] = dt.Rows[i][0].ToString().Trim();
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 17] = dt.Rows[i][9].ToString().Trim();//用法
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 18] = dt.Rows[i][11].ToString().Trim();//频率
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 19] = dt.Rows[i][17].ToString().Trim();//剂量
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 20] = dt.Rows[i][14].ToString().Trim();//天数
                this.m_objViewer.IsSave = false;
                this.m_objViewer.ctlDataGrid1_m_evtCurrentCellChanged(null, null);
                if (ret > 0)
                {
                    this.m_objViewer.rowNO++;
                }
            }

            dt = objForm.GetTable2;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 12] = 3000;
                int ret = m_mthFindMedicineByIDAcc("ITEMID_CHR", dt.Rows[i][5].ToString().Trim());
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 1] = dt.Rows[i][0].ToString().Trim();
                this.m_objViewer.IsSave = false;
                this.m_objViewer.ctlDataGrid1_m_evtCurrentCellChanged(null, null);
                if (ret > 0)
                {
                    this.m_objViewer.rowNO++;
                }
            }

            dt = objForm.GetTable3;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 12] = 3000;
                //				this.m_objViewer.rowNO =this.m_objViewer.ctlDataGrid1.RowCount-1;
                m_mthFindMedicineByIDAcc("ITEMID_CHR", dt.Rows[i][5].ToString().Trim());
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 1] = dt.Rows[i][0].ToString().Trim();
                this.m_objViewer.IsSave = false;
                this.m_objViewer.ctlDataGrid1_m_evtCurrentCellChanged(null, null);
                this.m_objViewer.rowNO++;
            }
            //////
            dt = objForm.GetTable4;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 12] = 3000;
                //				this.m_objViewer.rowNO =this.m_objViewer.ctlDataGrid1.RowCount-1;
                m_mthFindMedicineByIDAcc("ITEMID_CHR", dt.Rows[i][5].ToString().Trim());
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 1] = dt.Rows[i][0].ToString().Trim();
                this.m_objViewer.IsSave = false;
                this.m_objViewer.ctlDataGrid1_m_evtCurrentCellChanged(null, null);
                this.m_objViewer.rowNO++;
            }
            //////
            dt = objForm.GetTable5;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 12] = 3000;
                //				this.m_objViewer.rowNO =this.m_objViewer.ctlDataGrid1.RowCount-1;
                m_mthFindMedicineByIDAcc("ITEMID_CHR", dt.Rows[i][5].ToString().Trim());
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 1] = dt.Rows[i][0].ToString().Trim();
                this.m_objViewer.IsSave = false;
                this.m_objViewer.ctlDataGrid1_m_evtCurrentCellChanged(null, null);
                this.m_objViewer.rowNO++;
            }
            //////
            dt = objForm.GetTable6;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 12] = 3000;
                //				this.m_objViewer.rowNO =this.m_objViewer.ctlDataGrid1.RowCount-1;
                m_mthFindMedicineByIDAcc("ITEMID_CHR", dt.Rows[i][5].ToString().Trim());
                this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 1] = dt.Rows[i][0].ToString().Trim();
                this.m_objViewer.IsSave = false;
                this.m_objViewer.ctlDataGrid1_m_evtCurrentCellChanged(null, null);
                this.m_objViewer.rowNO++;
            }
            this.m_mthSetFocusOnDataGrid();
        }
        #endregion

        /// <summary>
        /// 指示是否收过手写处方
        /// </summary>
        public bool m_blnHandingRecipePayyed = false;

        #region 带出默认项目
        /// <summary>
        /// 一般公费病人加收诊金费，这就是默认收费项目，是跟病人身份的。可以维护默认收费项目
        /// </summary>
        public void m_mthGetDefaultItem()
        {
            this.OverFlowFlag = false;

            if (this.m_objViewer.m_PatientBasicInfo.PatientID.Trim() == "")
            {
                return;
            }

            string RecipeID = "";
            if (this.m_objViewer.btSave.Tag != null)
            {
                RecipeID = this.m_objViewer.btSave.Tag.ToString();
            }

            string RegisterID = this.m_objViewer.m_PatientBasicInfo.RegisterID.Trim();

            //病人类型
            string strPatientTypeID = m_objViewer.m_PatientBasicInfo.PayTypeID;
            ////是否挂号 1 已挂 ； 2 未挂
            //string strRegister = "2";
            //if (this.m_objViewer.m_PatientBasicInfo.RegisterID.Trim() != "" && this.m_objViewer.m_PatientBasicInfo.RegisterID != null)
            //{
            //    strRegister = "1";
            //}
            //if( !objSvc.m_blnCheckNormalReg(m_objViewer.m_PatientBasicInfo.RegisterID) )
            //{
            //    strRegister = "2";
            //}			

            //1 正方 ； 2 付方
            string strRecipeflag = m_objViewer.m_cmbRecipeType.Tag.ToString();

            //职称
            string strTechnicalRank = "";
            if (!string.IsNullOrEmpty(this.m_objViewer.m_PatientBasicInfo.DoctTechnicalRank))
            {
                strTechnicalRank = this.m_objViewer.m_PatientBasicInfo.DoctTechnicalRank;
            }
            else
            {
                strTechnicalRank = this.objSvc.m_strGetTechnicalRank(this.m_objViewer.m_PatientBasicInfo.DoctorID);
            }

            //是否专家 1 是 ； 2 不是
            string strExpert = "1";
            if (!objSvc.m_blnCheckExpert(m_objViewer.m_PatientBasicInfo.DoctorID))
            {
                strExpert = "2";
            }
            //删除先前默认项目
            m_mthGetChargeItemByItem(IsChrgFlag);

            m_mthClearEmptyRow();
            this.m_objViewer.rowNO = this.m_objViewer.ctlDataGrid1.RowCount;

            DataTable dt;

            long ret = objSvc.m_mthGetDefaultItem(out dt, strPatientTypeID, strRecipeflag, strTechnicalRank.Trim(), RecipeID, this.m_objViewer.m_PatientBasicInfo.RegisterID, this.m_objViewer.m_PatientBasicInfo.DeptID);
            if (ret > 0 && dt.Rows.Count > 0)
            {
                string[] strNoGHArr = clsPublic.m_strGetSysparm("0023").Split(';');
                string strSex = this.m_objViewer.m_PatientBasicInfo.PatientSex;
                int intAge = 1;
                try
                {
                    intAge = Convert.ToInt32(this.m_objViewer.m_PatientBasicInfo.PatientAge);
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

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["ITEMID_CHR"].ToString().Trim() == "0000006423" && blnIfChargeRegister == false)
                    {
                        continue;
                    }
                    else
                    {
                        this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                        m_mthGetChargeItemByItem(dt.Rows[i]["ITEMID_CHR"].ToString().Trim(), strPatientTypeID, 1);
                        this.m_objViewer.IsSave = false;
                        this.m_objViewer.ctlDataGrid1_m_evtCurrentCellChanged(null, null);
                        this.m_objViewer.rowNO++;
                    }
                }
                m_mthClearEmptyRow();
            }
            OverFlowFlag = true;
            if (!Recsumflag)
            {
                this.m_mthIsOverFlow();
            }
        }
        #endregion

        #region 是否选择
        /// <summary>
        ///填充选择框信息
        /// </summary>
        /// <param name="objControl">控件</param>
        /// <returns>true 显示控件,false不显示</returns>
        public bool m_mthGetFillDataToComboBox(com.digitalwave.iCare.gui.HIS.exComboBox objControl)
        {
            bool ret = true;
            if (objCHInfoVoArr == null)
            {
                ret = false;
            }
            else
            {
                for (int i = 0; i < objCHInfoVoArr.Length; i++)
                {
                    objControl.Item.Add(objCHInfoVoArr[i].strName, objCHInfoVoArr[i].strID);
                }
                objControl.SelectedIndex = 0;
            }
            return ret;
        }
        private clsChargeHospitalInfoVO[] objCHInfoVoArr = null;
        public void m_mthGetChooseHospitalInfo()
        {
            objSvc.m_mthGetChooseHospitalInfo(out this.objCHInfoVoArr);
        }
        #endregion

        #region 根据用法ID查用法名称
        private string m_mthFindUsageNameByID(string strID)
        {
            string ret = "";
            if (strID.Trim() != "")
            {
                DataTable dt;
                long l = objSvc.m_mthFindUsage(strID, out dt);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    ret = dt.Rows[0]["USAGENAME_VCHR"].ToString().Trim();
                }
            }
            return ret;
        }
        #endregion

        #region 根据频率ID查频率名称
        private string m_mthFindFreqNameByID(string strID)
        {
            string ret = "";
            if (strID.Trim() != "")
            {
                DataTable dt;
                long l = objSvc.m_mthFindFreq(strID, out dt);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    ret = dt.Rows[0]["FREQNAME_CHR"].ToString().Trim();
                }
            }
            return ret;
        }
        #endregion

        #region 加载系统配置
        /// <summary>
        /// 加载系统配置
        /// </summary>
        public void m_mthGetsysparm()
        {
            this.m_blnSecondStockLimitFlag = this.objSvc.m_mthIsCanDo("9101") == 1;
            this.m_strShowOPChargeManInfo = this.objSvc.m_mthIsCanDo("9009").ToString().Trim();
            this.isCanDo = this.objSvc.m_mthIsCanDo("0007") == 1;
            this._IsPrintSendMedicineBill = this.objSvc.m_mthIsCanDo("0009") == 1;
            this.IsCanModify = this.objSvc.m_mthIsCanDo("0010") == 1;
            this.IsModifyrecipetype = this.objSvc.m_mthIsCanDo("0053") == 1;
            this.IsChargeReceiverRec = this.objSvc.m_mthIsCanDo("0056") == 1;
            this.Ismedwinpublic = this.objSvc.m_mthIsCanDo("0057") == 1;
            this.isShowLackMedicine = objSvc.m_mthIsCanDo("0012") == 1;
            this.IsCanTurn = objSvc.m_mthIsCanDo("0013") == 1;
            this.m_objViewer.m_txtInvoiceNO.MaxLength = objSvc.m_mthIsCanDo("0014");
            this.IsDiscount = objSvc.m_mthIsCanDo("0016") == 1;
            this.m_objViewer.m_PatientBasicInfo.txtType.Enabled = objSvc.m_mthIsCanDo("0027") == 1;
            if (!this.m_objViewer.m_PatientBasicInfo.txtType.Enabled)
            {
                this.m_objViewer.m_PatientBasicInfo.txtType.BackColor = SystemColors.Control;
            }

            //体检收费工作站标志
            if (this.m_strReadXML("register", "PEWorkStation", "AnyOne") == "1")
            {
                PEWorkStationFlag = true;
            }

            clsDcl_DoctorWorkstation objDoct = new clsDcl_DoctorWorkstation();
            WMUsageIDArr = this.m_ArrGettoken(objDoct.m_strGetSysparm("1001"), ";");
            CMUsageIDArr = this.m_ArrGettoken(objDoct.m_strGetSysparm("1002"), ";");
            MATUsageIDArr = this.m_ArrGettoken(objDoct.m_strGetSysparm("1003"), ";");
            m_objNeedCheckArr = this.m_ArrGettoken(objDoct.m_strGetSysparm("1200"), ";");
            YBType = objDoct.m_strGetSysparm("1000");
            RoundingRule = objDoct.m_strGetSysparm("0015");
            RoundingCode = objDoct.m_strGetSysparm("0016");

            arrPaytype = this.m_ArrGettoken(objDoct.m_strGetSysparm("0001"), ";");

            this.YBIsShowSelfItem = (objSvc.m_mthIsCanDo("0066") == 1);
            this.YBPayTypeArr = this.m_ArrGettoken(objDoct.m_strGetSysparm("0031"), ";");
            this.m_objViewer.BirthInsuranceCode = objDoct.m_strGetSysparm("0084");
            objDoct = null;

            #region 获取连接医保前置数据库参数
            string xf = XMLFile;
            XMLFile = System.Windows.Forms.Application.StartupPath + @"\HISYB.xml";

            this.Hospcode = this.m_strReadXML("DONGGUAN.CHASHAN", "HospitalNO", "AnyOne");
            string DSN = this.m_strReadXML("DONGGUAN.CHASHAN", "DSN", "AnyOne");
            DBQ = this.m_strReadXML("DONGGUAN.CHASHAN", "DBQ", "AnyOne");

            SQLParm = DSN + DBQ;

            XMLFile = xf;
            #endregion

            m_intFlag = clsPublic.m_intGetSysParm("0077");//门诊收费处是否是否检索材料配药信息
            intDiffPriceOn = clsPublic.m_intGetSysParm("9002");// 让利启用开关
            if (intDiffPriceOn == 0)
                ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[intDiffPriceTotalCol]).ColumnWidth = 0;
            else
                ((com.digitalwave.controls.datagrid.clsColumnInfo)this.m_objViewer.ctlDataGrid1.Columns[intDiffPriceTotalCol]).ColumnWidth = 80;

        }
        #endregion

        #region 费用凑整
        /// <summary>
        /// 费用凑整
        /// </summary>
        /// <returns></returns>
        public bool m_blnRounding()
        {
            // 社保病人不凑整
            if (this.m_Isybcharge())
            {
                return true;
            }

            if (RoundingRule == "0")
            {
                return true;
            }

            string totalmny, acctmny, sbmny;
            objCalPatientCharge.m_mthGetchargeinfo(out acctmny, out sbmny, out totalmny);

            if (sbmny.Trim() == "")
            {
                return true;
            }

            decimal d = Convert.ToDecimal(sbmny);
            sbmny = d.ToString("0.00");

            int val = int.Parse(sbmny.Substring(sbmny.Length - 1, 1));
            if (val > 0)
            {
                int amount = 0;

                if (RoundingRule == "1")
                {
                    if (val < 5)
                    {
                        amount = -1 * val;
                    }
                    else
                    {
                        amount = 10 - val;
                    }
                }

                DataTable dt;
                long l = this.objSvc.m_lngGetRoundingItem(RoundingCode, out dt);
                if (l > 0 && dt.Rows.Count > 0)
                {
                    DataRow dr = dt.Rows[0];

                    for (int i = this.m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
                    {
                        if (this.m_objViewer.ctlDataGrid1[i, 10] == null || this.m_objViewer.ctlDataGrid1[i, 10].ToString() == "" || this.m_objViewer.ctlDataGrid1[i, 1].ToString() == "")
                        {
                            this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                        }
                    }

                    int row = this.m_objViewer.ctlDataGrid1.RowCount;
                    this.m_objViewer.ctlDataGrid1.m_mthAppendRow();

                    m_objViewer.ctlDataGrid1[row, 0] = dr["TempItemCode"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 1] = amount.ToString();
                    m_objViewer.ctlDataGrid1[row, 2] = dr["ITEMNAME_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 3] = m_mthConvertToChType(dr["ITEMOPINVTYPE_CHR"].ToString().Trim());
                    m_objViewer.ctlDataGrid1[row, 4] = dr["ITEMSPEC_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 5] = dr["itemunit_chr"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 6] = dr["ITEMPRICE_MNY"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 8] = dr["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 9] = m_mthRelationInfo(dr["ITEMOPINVTYPE_CHR"].ToString().Trim());
                    m_objViewer.ctlDataGrid1[row, 10] = dr["ITEMID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 11] = "";
                    m_objViewer.ctlDataGrid1[row, 15] = dr["ITEMOPCALCTYPE_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 16] = 0;
                    m_objViewer.ctlDataGrid1[row, 17] = "";
                    m_objViewer.ctlDataGrid1[row, 18] = "";
                    m_objViewer.ctlDataGrid1[row, 21] = "";
                    m_objViewer.ctlDataGrid1[row, "colYbcode"] = dr["insuranceid_chr"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 13] = "100%";
                    m_objViewer.ctlDataGrid1[row, 14] = 100;
                    m_objViewer.ctlDataGrid1[row, 12] = 3000;

                    this.m_mthDosageChange(dr["ITEMID_CHR"].ToString().Trim(), dr["ITEMPRICE_MNY"].ToString().Trim(), dr["ITEMOPINVTYPE_CHR"].ToString().Trim(), amount.ToString(), row);

                    objCalPatientCharge.m_mthModifyInvoCat();
                    this.m_mthDisplayCharge();
                }
            }

            return true;
        }
        #endregion

        #region 根据设置的费别判断是否使用医保结算
        /// <summary>
        /// 根据设置的费别判断是否使用医保结算
        /// </summary>
        /// <returns></returns>
        public bool m_Isybcharge()
        {
            if (this.arrPaytype == null)
            {
                return false;
            }

            return arrPaytype.Contains(this.m_objViewer.m_PatientBasicInfo.PayTypeID);
        }
        #endregion

        #region  获取药品让利金额
        /// <summary>
        /// 获取药品总让利金额 
        /// </summary>
        /// <returns></returns>
        internal decimal m_decGetTotalDiffPrice()
        {
            decimal decTotalMoney = 0;//总价

            string strType = string.Empty;//类型
            com.digitalwave.controls.datagrid.ctlDataGrid objGrid = m_objViewer.ctlDataGrid1;
            int intRowsCount = objGrid.RowCount;
            for (int i1 = 0; i1 < intRowsCount; i1++)
            {
                if (this.blMedicine9003(objGrid[i1, 10].ToString().Trim()))
                    decTotalMoney += m_mthConvertObjToDecimal(objGrid[i1, intDiffPriceTotalCol]);
            }
            decTotalMoney = Convert.ToDecimal(decTotalMoney.ToString("0.00"));
            return decTotalMoney;
        }
        #endregion

        #region 收集发药信息
        private clsReportSendMedStart_VO ReportSendMedStart = null;
        private clsReportSendMed_VO[] sendMedEN = null;
        private clsReportSendMed_VO[] sendMedCH = null;
        private clsContorlReportPrint objprint = null;
        public void m_mthBegionPrintMedicineSend()
        {
            if (this.strSendMedicinePrinterName.Trim() != "")
            {
                this.m_objViewer.printDocument2.DefaultPageSettings.PrinterSettings.PrinterName = this.strSendMedicinePrinterName;
            }
            objprint = new clsContorlReportPrint();
            ReportSendMedStart = new clsReportSendMedStart_VO();
            ReportSendMedStart.m_intFlag = 0;
            ReportSendMedStart.m_intIsShow = 1;
            ReportSendMedStart.m_strAge = this.m_objViewer.m_PatientBasicInfo.PatientAge + "岁";
            ReportSendMedStart.m_strDoctorName = this.m_objViewer.m_PatientBasicInfo.txtRegisterDoctor.Text;
            ReportSendMedStart.m_strname = this.m_objViewer.m_PatientBasicInfo.PatientName;
            ReportSendMedStart.m_strInternalCH = this.m_objViewer.m_PatientBasicInfo.txtType.Text;
            ReportSendMedStart.m_strInternalEN = this.m_objViewer.m_PatientBasicInfo.txtType.Text;
            ReportSendMedStart.m_strPatCardID = this.m_objViewer.m_PatientBasicInfo.PatientCardID;
            ReportSendMedStart.m_strPintdate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            ReportSendMedStart.m_strRegisterdate = this.m_objViewer.m_PatientBasicInfo.RegisterDate;
            ReportSendMedStart.m_strsex = this.m_objViewer.m_PatientBasicInfo.PatientSex;
            ReportSendMedStart.m_strSun = this.m_objViewer.numericUpDown1.Value.ToString();
            ReportSendMedStart.m_strTotalMoney = this.objCalPatientCharge.m_mthGetChargeTypeDetail().m_decTotalCost.ToString();
            if (this.m_objViewer.numericUpDown1.Tag != null)
            {
                ReportSendMedStart.m_strUseNameAll = this.m_objViewer.numericUpDown1.Tag.ToString();
            }

            int ECount = 0;
            int CCount = 0;

            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, 9].ToString().Trim() == "0001" || this.m_objViewer.ctlDataGrid1[i, 9].ToString().Trim() == "0006")
                {
                    if (objCalPatientCharge.m_mthIsMedicine(m_objViewer.ctlDataGrid1[i, 8].ToString().Trim()) == 2)//(在慢病中)如果是中成药就到中药房发药
                    {
                        CCount++;
                    }
                    else
                    {
                        ECount++;

                    }
                    continue;
                }
                if (this.m_objViewer.ctlDataGrid1[i, 9].ToString().Trim() == "0002")
                {
                    CCount++;
                }
            }
            sendMedEN = new clsReportSendMed_VO[ECount];
            sendMedCH = new clsReportSendMed_VO[CCount];
            ECount = 0;
            CCount = 0;
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                clsReportSendMed_VO temp = new clsReportSendMed_VO();
                temp.m_strdosage = this.m_objViewer.ctlDataGrid1[i, 19].ToString();
                temp.m_strdosageUnit = this.m_objViewer.ctlDataGrid1[i, 21].ToString();
                temp.m_strMedSpace = this.m_objViewer.ctlDataGrid1[i, 4].ToString();
                temp.m_strMedName = this.m_objViewer.ctlDataGrid1[i, 2].ToString();
                temp.m_strMedUnit = this.m_objViewer.ctlDataGrid1[i, 5].ToString();
                temp.m_strTotal = this.m_objViewer.ctlDataGrid1[i, 1].ToString();
                temp.m_strUseName = m_mthFindUsageNameByID(this.m_objViewer.ctlDataGrid1[i, 17].ToString());
                temp.m_strFREQIDName = m_mthFindFreqNameByID(this.m_objViewer.ctlDataGrid1[i, 18].ToString());

                if (this.m_objViewer.ctlDataGrid1[i, 9].ToString().Trim() == "0001" || this.m_objViewer.ctlDataGrid1[i, 9].ToString().Trim() == "0006")
                {
                    if (objCalPatientCharge.m_mthIsMedicine(m_objViewer.ctlDataGrid1[i, 8].ToString().Trim()) == 2)//(在慢病中)如果是中成药就到中药房发药
                    {
                        temp.m_strdosage = this.m_objViewer.ctlDataGrid1[i, 1].ToString();
                        temp.m_strMedType = "2";
                        sendMedCH[CCount] = temp;
                        CCount++;

                    }
                    else
                    {
                        temp.m_strMedType = "1";
                        sendMedEN[ECount] = temp;
                        ECount++;
                    }
                    continue;
                }
                if (this.m_objViewer.ctlDataGrid1[i, 9].ToString().Trim() == "0002")
                {
                    temp.m_strMedType = "3";
                    temp.m_strdosage = this.m_objViewer.ctlDataGrid1[i, 1].ToString();
                    sendMedCH[CCount] = temp;
                    CCount++;
                }
            }


        }
        public void m_mthEndPrintMedicineSend()
        {
            ReportSendMedStart = null;
            sendMedEN = null;
            sendMedCH = null;
            objprint = null;
        }
        #endregion

        #region 打印发药信息
        public void m_mthPrintMedicineSend(System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (sendMedEN.Length + sendMedCH.Length == 0)
            {
                e.Cancel = true;
            }
            else
            {
                objprint.m_lngPrint(e, ReportSendMedStart, sendMedEN, sendMedCH);
            }
        }
        #endregion

        #region 特困病人是否超额
        /// <summary>
        /// 是否显示真超额 true显示，false 不显示
        /// </summary>
        private bool OverFlowFlag = true;
        /// <summary>
        /// 特困病人是否超额
        /// </summary>
        /// <returns>true 超额,false 没有超额</returns>
        private bool m_mthIsOverFlow()
        {
            bool ret = false;
            //			if(this.m_objViewer.m_PatientBasicInfo.PatientType==3)
            //			{

            if (showOverFlow && this.m_objViewer.m_PatientBasicInfo.Limit > 0 && this.objCalPatientCharge.m_mthGetChargeTypeDetail().m_decTotalCost > this.m_objViewer.m_PatientBasicInfo.Limit && this.m_objViewer.m_PatientBasicInfo.PatientID.Trim() != "" && OverFlowFlag)
            {
                frmShowOverFlow objfrm = new frmShowOverFlow();
                objfrm.Left = 856;
                objfrm.Top = 668;
                objfrm.Show();
                ret = false;
            }
            //			}
            return ret;
        }
        #endregion

        #region 比例回车
        public void m_mthChangeDiscount(string strText, int p_row)
        {
            if (strText.Trim() == "")
            {
                MessageBox.Show("请输入比例!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.ctlDataGrid1[p_row, 13] = this.m_objViewer.ctlDataGrid1[p_row, 14].ToString().Trim() + "%";
                return;
            }
            decimal temp = this.m_mthConvertObjToDecimal(strText);
            if (temp < 0)
            {
                MessageBox.Show("比例值不能小于 0!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.ctlDataGrid1[p_row, 13] = this.m_objViewer.ctlDataGrid1[p_row, 14].ToString().Trim();
                return;
            }
            if (temp > 100)
            {
                MessageBox.Show("比例值不能超过100!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.ctlDataGrid1[p_row, 13] = this.m_objViewer.ctlDataGrid1[p_row, 14].ToString().Trim();
                return;
            }
            this.m_objViewer.ctlDataGrid1[p_row, 14] = temp;
            this.m_objViewer.IsSave = false;
            this.m_objViewer.ctlDataGrid1.CurrentCell = new DataGridCell(p_row, 14);

        }
        #endregion

        #region 根据用法查收费项目
        /// <summary>
        /// 是否显示超额
        /// </summary>
        private bool showOverFlow = true;

        //单条收费项目标志
        private bool blnSinglechrgitem = false;
        public void m_mthFindItemByUsage(string strID)
        {
            frmGetItemByUsage objfrm = new frmGetItemByUsage(strID);
            if (objfrm.ShowDialog() == DialogResult.OK)
            {
                showOverFlow = false;
                //				this.m_objViewer.rowNO=this.m_objViewer.ctlDataGrid1.RowCount-1;
                com.digitalwave.iCare.ValueObject.clsChargeItem_VO[] objResult = objfrm.ItemResult;
                if (objResult == null)
                {
                    return;
                }
                for (int i = 0; i < objResult.Length; i++)
                {
                    this.m_objViewer.ctlDataGrid1.m_mthAppendRow();
                    this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 12] = 3000;
                    blnSinglechrgitem = true;
                    int ret = m_mthFindMedicineByID("ITEMID_CHR", objResult[i].m_strItemID);
                    blnSinglechrgitem = false;
                    this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO, 1] = objResult[i].m_strUNITPRICE;
                    //					this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO,17] =dt.Rows[i][9].ToString().Trim();//用法
                    //					this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO,18] =dt.Rows[i][11].ToString().Trim();//频率
                    //					this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO,19] =dt.Rows[i][17].ToString().Trim();//剂量
                    //					this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO,20] =dt.Rows[i][14].ToString().Trim();//天数
                    this.m_objViewer.IsSave = false;
                    //					this.m_objViewer.ctlDataGrid1[this.m_objViewer.rowNO,12]=3000;
                    this.m_objViewer.ctlDataGrid1_m_evtCurrentCellChanged(null, null);
                    if (ret > 0)
                    {
                        this.m_objViewer.rowNO++;
                    }
                }
                showOverFlow = true;
                if (!Recsumflag)
                {
                    this.m_mthIsOverFlow();
                }
                this.m_mthSetFocusOnDataGrid();
            }
        }
        #endregion

        #region 判断发票号是否正确
        public bool m_mthInvoiceExpression()
        {
            Regex r = new Regex(this.strInvoiceExpression);
            Match m = r.Match(this.m_objViewer.m_txtInvoiceNO.Text);
            if (m.Success)
            {
                return false;
            }
            else
            {
                MessageBox.Show("发票号格式化不对!", "注意", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtInvoiceNO.Focus();
                return true;
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
                    if (this.m_objViewer.ctlDataGrid1[i, ResubitemCol].ToString().Trim() == strCurrItemID)
                    {
                        //删除计费类对应的项目
                        if (this.m_objViewer.ctlDataGrid1[i, 10].ToString() != "" && this.m_objViewer.ctlDataGrid1[i, 1].ToString() != "")
                        {
                            int row = int.Parse(this.m_objViewer.ctlDataGrid1[i, 12].ToString());
                            ((clsCtl_OPCharge)this.m_objViewer.objController).m_mthDeleteRecipe(row);
                        }
                        this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                    }
                }
            }
            //插入子项目
            else if (intType == 0)
            {
                int row = 0;

                foreach (DataRow dtRow in dtRecord.Rows)
                {
                    //停用提示
                    if (dtRow["IFSTOP_INT"].ToString() == "1")
                    {
                        MessageBox.Show("被搭配的项目" + "(" + dtRow["ITEMCODE_VCHR"].ToString() + ")" + dtRow["ITEMNAME_VCHR"].ToString() + "已停用，请通知管理员重新设置！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        continue;
                    }

                    row = m_objViewer.ctlDataGrid1.RowCount;
                    m_objViewer.ctlDataGrid1.m_mthAppendRow();
                    m_objViewer.ctlDataGrid1[row, 0] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 1] = m_mthConvertObjToDecimal(dtRow["totalqty_dec"]);
                    m_objViewer.ctlDataGrid1[row, 2] = dtRow["ITEMNAME_VCHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 3] = m_mthConvertToChType(dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim());
                    m_objViewer.ctlDataGrid1[row, 4] = dtRow["ITEMSPEC_VCHR"].ToString().Trim();
                    //如果是西药而已用的是最小单位,就用小单价和住院最小单位
                    if (m_mthIsMedicine(dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim()) && dtRow["OPCHARGEFLG_INT"].ToString().Trim() == "1")
                    {
                        m_objViewer.ctlDataGrid1[row, 5] = dtRow["ITEMIPUNIT_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGrid1[row, 6] = dtRow["SUBMONEY"].ToString().Trim();
                    }
                    else
                    {
                        m_objViewer.ctlDataGrid1[row, 5] = dtRow["ITEMOPUNIT_CHR"].ToString().Trim();
                        m_objViewer.ctlDataGrid1[row, 6] = dtRow["ITEMPRICE_MNY"].ToString().Trim();
                    }
                    m_objViewer.ctlDataGrid1[row, 8] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 9] = m_mthRelationInfo(dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim());
                    if (m_objViewer.ctlDataGrid1[row, 9].ToString() != "0001" && m_objViewer.ctlDataGrid1[row, 9].ToString() != "0002")//非药时，取另一单位
                    {
                        m_objViewer.ctlDataGrid1[row, 5] = dtRow["Unit"].ToString().Trim();
                        m_objViewer.ctlDataGrid1[row, 6] = dtRow["ITEMPRICE_MNY"].ToString().Trim();
                    }

                    m_objViewer.ctlDataGrid1[row, 10] = dtRow["ITEMID_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 11] = dtRow["SELFDEFINE_INT"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 15] = dtRow["ITEMOPCALCTYPE_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 16] = 0;
                    m_objViewer.ctlDataGrid1[row, 17] = "";
                    m_objViewer.ctlDataGrid1[row, 18] = "";
                    m_objViewer.ctlDataGrid1[row, 21] = dtRow["DOSAGEUNIT_CHR"].ToString().Trim();

                    string strPRECENT_DEC = "100";
                    if (dtRow["PRECENT_DEC"].ToString().Trim() != "")
                    {
                        strPRECENT_DEC = dtRow["PRECENT_DEC"].ToString().Trim();
                    }
                    m_objViewer.ctlDataGrid1[row, 13] = strPRECENT_DEC + "%";
                    m_objViewer.ctlDataGrid1[row, 14] = this.m_mthConvertObjToDecimal(strPRECENT_DEC);
                    m_objViewer.ctlDataGrid1[row, 12] = 2000;

                    this.m_objViewer.ctlDataGrid1[row, ResubitemCol] = strCurrItemID;
                    this.m_objViewer.ctlDataGrid1[row, ResubnumsCol] = m_objViewer.ctlDataGrid1[row, 1];
                }
                //算单项金额，显示总费用
                this.m_mthCalReItemTotal(strCurrItemID, 1);
            }
        }
        #endregion

        #region 调整关联项目的数量
        /// <summary>
        /// 调整关联项目的数量
        /// </summary>
        /// <param name="strCurrItemID"></param>
        /// <param name="strOldNum"></param>
        /// <param name="strNewNum"></param>
        public void m_mthAdjustReItemNum(string strCurrItemID, string strOldNum, string strNewNum)
        {
            if (!strCurrItemID.StartsWith("[PK]"))
            {
                return;
            }

            if (strOldNum == strNewNum)
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

            this.m_mthCalReItemTotal(strCurrItemID.Replace("[PK]", ""), Convert.ToDecimal(dscale));
        }

        private void m_mthCalReItemTotal(string strCurrItemID, decimal scale)
        {
            decimal orgNum = 0;
            this.m_objViewer.IsSendTabKey = true;
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, ResubitemCol].ToString().Trim() == strCurrItemID)
                {
                    orgNum = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, ResubnumsCol]);
                    this.m_objViewer.ctlDataGrid1[i, 1] = orgNum * scale;

                    //算单项金额，显示总费用
                    this.m_mthDosageChange(m_objViewer.ctlDataGrid1[i, 10].ToString().Trim(), m_objViewer.ctlDataGrid1[i, 6].ToString().Trim(),
                        m_objViewer.ctlDataGrid1[i, 8].ToString().Trim(), m_objViewer.ctlDataGrid1[i, 1].ToString().Trim(), i);

                    //自付
                    if (this.m_objViewer.ctlDataGrid1[i, 14].ToString().Trim() != "")
                    {
                        this.m_objViewer.ctlDataGrid1[i, 23] = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 14]) / 100 * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 7]);
                    }
                }
            }
        }
        #endregion

        #region 循环调出收费项目
        /// <summary>
        /// 循环调出收费项目
        /// </summary>
        /// <param name="strItemID"></param>
        /// <param name="strPatType"></param>
        /// <param name="Flag">1 默认带出项 2 体检收费项目</param>
        public void m_mthGetChargeItemByItem(string strItemID, string strPatType, int Flag)
        {
            long lngRet = 0;
            DataTable dtRecord = new DataTable();
            if (Flag == 1)
            {
                lngRet = objSvc.m_mthFindChrgItemByID(strItemID, strPatType, out dtRecord);
            }
            else if (Flag == 2)
            {
                lngRet = objSvc.m_lngGetPEChargeItemInfo(strItemID, strPatType, out dtRecord);
            }
            if (lngRet > 0 && dtRecord.Rows.Count == 1)
            {
                DataRow dtRow = dtRecord.Rows[0];

                int row = m_objViewer.ctlDataGrid1.RowCount;
                m_objViewer.ctlDataGrid1.m_mthAppendRow();
                m_objViewer.ctlDataGrid1[row, 0] = dtRow["ITEMCODE_VCHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 1] = m_mthConvertObjToDecimal(dtRow["itemnum"]);
                m_objViewer.ctlDataGrid1[row, 2] = dtRow["ITEMNAME_VCHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 3] = m_mthConvertToChType(dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim());
                m_objViewer.ctlDataGrid1[row, 4] = dtRow["ITEMSPEC_VCHR"].ToString().Trim();
                //如果是西药而已用的是最小单位,就用小单价和住院最小单位
                if (m_mthIsMedicine(dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim()) && dtRow["OPCHARGEFLG_INT"].ToString().Trim() == "1")
                {
                    m_objViewer.ctlDataGrid1[row, 5] = dtRow["ITEMIPUNIT_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 6] = dtRow["SUBMONEY"].ToString().Trim();

                }
                else
                {
                    m_objViewer.ctlDataGrid1[row, 5] = dtRow["ITEMOPUNIT_CHR"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 6] = dtRow["ITEMPRICE_MNY"].ToString().Trim();

                }
                if (blMedicine9003(m_objViewer.ctlDataGrid1[row, 10].ToString()))
                {
                    m_objViewer.ctlDataGrid1[row, intDiffUnitPriceCol] = string.IsNullOrEmpty(dtRow["subtrademoney"].ToString().Trim()) ? dtRow["SUBMONEY"].ToString().Trim() : dtRow["subtrademoney"].ToString().Trim();
                }
                else
                {
                    m_objViewer.ctlDataGrid1[row, intDiffUnitPriceCol] = string.IsNullOrEmpty(dtRow["tradeprice_mny"].ToString().Trim()) ? dtRow["ITEMPRICE_MNY"].ToString().Trim() : dtRow["tradeprice_mny"].ToString().Trim();
                }
                m_objViewer.ctlDataGrid1[row, 8] = dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 9] = m_mthRelationInfo(dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim());
                if (m_objViewer.ctlDataGrid1[row, 9].ToString() != "0001" && m_objViewer.ctlDataGrid1[row, 9].ToString() != "0002")//非药时，取另一单位
                {
                    m_objViewer.ctlDataGrid1[row, 5] = dtRow["Unit"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, 6] = dtRow["ITEMPRICE_MNY"].ToString().Trim();
                    m_objViewer.ctlDataGrid1[row, intDiffUnitPriceCol] = string.IsNullOrEmpty(dtRow["tradeprice_mny"].ToString().Trim()) ? dtRow["ITEMPRICE_MNY"].ToString().Trim() : dtRow["tradeprice_mny"].ToString().Trim();
                }

                m_objViewer.ctlDataGrid1[row, 10] = dtRow["ITEMID_CHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 11] = dtRow["SELFDEFINE_INT"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 15] = dtRow["ITEMOPCALCTYPE_CHR"].ToString().Trim();
                m_objViewer.ctlDataGrid1[row, 16] = 0;
                m_objViewer.ctlDataGrid1[row, 17] = "";
                m_objViewer.ctlDataGrid1[row, 18] = "";
                m_objViewer.ctlDataGrid1[row, 21] = dtRow["DOSAGEUNIT_CHR"].ToString().Trim();

                string strPRECENT_DEC = "100";
                if (dtRow["PRECENT_DEC"].ToString().Trim() != "")
                {
                    strPRECENT_DEC = dtRow["PRECENT_DEC"].ToString().Trim();
                }
                m_objViewer.ctlDataGrid1[row, 13] = strPRECENT_DEC + "%";
                m_objViewer.ctlDataGrid1[row, 14] = this.m_mthConvertObjToDecimal(strPRECENT_DEC);
                m_objViewer.ctlDataGrid1[row, 12] = 2000;

                this.m_objViewer.ctlDataGrid1[row, ResubitemCol] = "";
                this.m_objViewer.ctlDataGrid1[row, ResubnumsCol] = 0;
                this.m_objViewer.ctlDataGrid1[row, "colYbcode"] = dtRow["insuranceid_chr"].ToString().Trim();
                this.m_objViewer.ctlDataGrid1[row, DefaultCol] = "&";

                //算单项金额，显示总费用
                this.m_mthDosageChange(m_objViewer.ctlDataGrid1[row, 10].ToString().Trim(), m_objViewer.ctlDataGrid1[row, 6].ToString().Trim(),
                    m_objViewer.ctlDataGrid1[row, 8].ToString().Trim(), m_objViewer.ctlDataGrid1[row, 1].ToString().Trim(), row);

                //自付
                if (this.m_objViewer.ctlDataGrid1[row, 14].ToString().Trim() != "")
                {
                    this.m_objViewer.ctlDataGrid1[row, 23] = m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, 14]) / 100 * m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[row, 7]);
                }
            }
        }
        #endregion

        #region 循环调出默认带出项目
        /// <summary>
        /// 循环调出默认带出项目
        /// </summary>
        /// <param name="strItemID"></param>
        /// <param name="strPatType"></param>
        public void m_mthGetChargeItemByItem(bool blnFlag)
        {
            for (int i = this.m_objViewer.ctlDataGrid1.RowCount - 1; i >= 0; i--)
            {
                if (this.m_objViewer.ctlDataGrid1[i, DefaultCol].ToString().Trim() == "&")
                {
                    if (blnFlag)
                    {
                        //删除计费类对应的项目
                        if (this.m_objViewer.ctlDataGrid1[i, 10].ToString() != "" && this.m_objViewer.ctlDataGrid1[i, 1].ToString() != "")
                        {
                            int row = int.Parse(this.m_objViewer.ctlDataGrid1[i, 12].ToString());
                            ((clsCtl_OPCharge)this.m_objViewer.objController).m_mthDeleteRecipe(row);
                        }
                    }
                    this.m_objViewer.ctlDataGrid1.m_mthDeleteRow(i);
                }
            }
        }
        #endregion

        #region 变更接诊医生
        /// <summary>
        /// 变更接诊医生
        /// </summary>
        public void m_mthDoctorChanged()
        {
            if (objCalPatientCharge == null)
            {
                return;
            }

            if (objSvc.m_blnValidatePatientRecipeByDoctor(m_objViewer.m_PatientBasicInfo.PatientID, m_objViewer.m_PatientBasicInfo.DoctorID))
            {
                m_objViewer.m_cmbRecipeType.SelectedIndex = 1;
            }
            else
            {
                m_objViewer.m_cmbRecipeType.SelectedIndex = 0;
            }

            IsChrgFlag = true;
            if (this.m_objViewer.chkDefaultItem.Checked)
            {
                this.m_mthGetDefaultItem();
            }
            this.m_mthDisplayCharge();
        }
        #endregion

        #region 变更接诊医生
        /// <summary>
        /// 变更接诊医生
        /// </summary>
        public void m_mthRecipeChanged()
        {
            if (objCalPatientCharge == null)
            {
                return;
            }

            IsChrgFlag = true;
            if (this.m_objViewer.chkDefaultItem.Checked)
            {
                this.m_mthGetDefaultItem();
            }
            this.m_mthDisplayCharge();
        }
        #endregion

        #region 显示是否专家
        /// <summary>
        /// 显示是否专家
        /// </summary>
        /// <param name="strEmpID"></param>
        public void m_mthShowExpert(string strDocID)
        {
            if (objSvc.m_blnCheckExpert(strDocID))
            {
                this.m_objViewer.m_PatientBasicInfo.lbeDocType.Text = "专家";
            }
            else
            {
                this.m_objViewer.m_PatientBasicInfo.lbeDocType.Text = "普通";
            }
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
        /// 读取指定的属性值
        /// </summary>
        /// <param name="parentnode">父节点</param>
        /// <param name="childnode">子节点</param>
        /// <param name="key"></param>
        /// <param name="attributes">需要读取的属性</param>
        /// <returns></returns>
        public string m_strReadXMLAttr(string parentnode, string childnode, string key, string attributes)
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
                        strRet = xndC.Attributes[attributes].Value.ToString().Trim();
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

        #region 获取病人处方(含带出项目)费用信息
        /// <summary>
        /// 获取病人处方(含带出项目)费用信息
        /// </summary>
        /// <param name="Pid">病人ID</param>
        /// <param name="CheckRecNums">是否检测处方数</param>
        /// <param name="RecipeNums">处方数</param>
        /// <param name="TotalMny">合计金额</param>
        /// <param name="SbMny">自付金额</param>
        public void m_mthGetPatientRecipeFee(string Pid, string CardID, bool CheckRecNums, out int RecipeNums, out decimal TotalMny, out decimal SbMny)
        {
            RecipeNums = 0;
            TotalMny = 0;
            SbMny = 0;

            if (Pid.Trim() == "")
            {
                return;
            }

            try
            {
                DataTable dt = new DataTable();
                long l = 0;
                // 先诊疗后结算处方查询
                //if (this.m_objViewer.m_PatientBasicInfo.m_strIsVip == "1")
                // {
                //l = this.objSvc.m_lngGetTreatRecinfoBypid(Pid, out RecipeNums, out dt);
                //}
                //if (l > 0 && RecipeNums > 0)
                //{

                //}
                //else
                //{
                l = this.objSvc.m_lngGetAllrecinfoBypid(Pid, out RecipeNums, out dt);
                //}
                if (l > 0)
                {
                    if (RecipeNums == 0)
                    {
                        return;
                    }
                    else
                    {
                        if (RecipeNums == 1 && CheckRecNums)
                        {
                            return;
                        }

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            TotalMny += clsMZPublic.Round(clsMZPublic.ConvertObjToDecimal(dt.Rows[i]["SumMoney"]), 2);
                            SbMny += clsMZPublic.Round(clsMZPublic.ConvertObjToDecimal(dt.Rows[i]["SumMoney"]) * clsMZPublic.ConvertObjToDecimal(dt.Rows[i]["Discount_dec"]) / 100, 2);
                        }

                        if (!this.m_objViewer.chkDefaultItem.Checked)
                        {
                            return;
                        }

                        string RecID = "";
                        string Status = "";
                        string strSeqid = "";
                        string strISgreen = "";
                        int RecCount = 0;
                        l = this.objSvc.m_mthFindMaxRecipeNoByPatientID(Pid, out RecID, out strSeqid, out Status, out RecCount, out dt, out strISgreen);
                        if (l > 0 && RecID.Trim() != "")
                        {
                            if (strISgreen == "1")
                            {
                                this.m_objViewer.blnFlag = true;
                            }
                            else
                            {
                                this.m_objViewer.blnFlag = false;
                            }
                            clsRecipeInfo_VO[] objRI_VO;
                            l = this.objSvc.m_mthFindRecipeDoctor(Pid, RecID, out objRI_VO);
                            if (l > 0 && objRI_VO != null)
                            {
                                //病人类型
                                string PayTypeID = objRI_VO[0].m_strPatientTypeID;
                                //处方类型 1 正方 ； 2 付方
                                string RecipeFlag = ((objRI_VO[0].m_strRECIPEFLAG_INT.Trim() == "2") ? "2" : "1");
                                //是否挂号 1 已挂 ； 2 未挂
                                string IsReg = "2";
                                if (CheckRecNums)
                                {
                                    if (this.m_objViewer.m_PatientBasicInfo.RegisterID.Trim() != "" && this.m_objViewer.m_PatientBasicInfo.RegisterID != null)
                                    {
                                        IsReg = "1";
                                    }
                                }
                                else
                                {
                                    DataTable dtCard;
                                    l = this.objSvc.m_lngGetPatientInfoByCard(CardID, out dtCard);
                                    if (l > 0 && dtCard.Rows.Count > 0)
                                    {
                                        IsReg = "1";
                                    }
                                }

                                //是否专家
                                string DoctorID = objRI_VO[0].m_strDoctorID;
                                string IsExpert = "1";
                                if (!this.objSvc.m_blnCheckExpert(Pid))
                                {
                                    IsExpert = "2";
                                }

                                l = this.objSvc.m_mthGetDefaultItem(Pid, IsReg, RecipeFlag, IsExpert, out dt);
                                if (l > 0 && dt.Rows.Count > 0)
                                {
                                    for (int j = 0; j < dt.Rows.Count; j++)
                                    {
                                        string ItemID = dt.Rows[j]["ITEMID_CHR"].ToString().Trim();
                                        DataTable dtRecord;
                                        l = this.objSvc.m_mthFindChrgItemByID(ItemID, PayTypeID, out dtRecord);
                                        if (l > 0 && dtRecord.Rows.Count == 1)
                                        {
                                            DataRow dtRow = dtRecord.Rows[0];

                                            //单价
                                            decimal Price = 0;

                                            //如果是西药而已用的是最小单位,就用小单价和住院最小单位
                                            if (this.m_mthIsMedicine(dtRow["ITEMOPINVTYPE_CHR"].ToString().Trim()) && dtRow["OPCHARGEFLG_INT"].ToString().Trim() == "1")
                                            {
                                                Price = clsMZPublic.ConvertObjToDecimal(dtRow["SUBMONEY"]);
                                            }
                                            else
                                            {
                                                Price = clsMZPublic.ConvertObjToDecimal(dtRow["ITEMPRICE_MNY"]);
                                            }

                                            //数量
                                            decimal Amount = clsMZPublic.ConvertObjToDecimal(dtRow["itemnum"]);

                                            //比例
                                            decimal Precent = 100;
                                            if (dtRow["PRECENT_DEC"].ToString().Trim() != "")
                                            {
                                                Precent = clsMZPublic.ConvertObjToDecimal(dtRow["PRECENT_DEC"]);
                                            }

                                            decimal d = clsMZPublic.Round(Price * Amount, 2);
                                            TotalMny += d;
                                            SbMny += clsMZPublic.Round(d * Precent / 100, 2);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                RecipeNums = 0;
            }
        }
        #endregion

        #region 获取当天当前患者所有未结算处方信息
        /// <summary>
        /// 获取当天当前患者所有未结算处方信息
        /// </summary>
        /// <returns></returns>
        public int m_intGetallrecinfo()
        {
            int l = 0;
            RecipeCount = 0;
            DataTable dt = new DataTable();

            long ret = objSvc.m_lngGetAllrecinfoBypid(m_objViewer.m_PatientBasicInfo.PatientID, out RecipeCount, out dt);
            if (RecipeCount > 1)
            {
                decimal decTotal = 0;
                decimal decSbMny = 0;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    decTotal += clsPublic.Round(this.m_mthConvertObjToDecimal(dt.Rows[i]["SumMoney"]), 2);
                    decSbMny += clsPublic.Round(this.m_mthConvertObjToDecimal(dt.Rows[i]["SumMoney"]) * this.m_mthConvertObjToDecimal(dt.Rows[i]["Discount_dec"]) / 100, 2);
                }

                string SbMny = (decSbMny == 0 ? "" : decSbMny.ToString());
                string AcctMny = ((decTotal - decSbMny) == 0 ? "" : Convert.ToString(decTotal - decSbMny));

                frmShowpatallrecinfo f = new frmShowpatallrecinfo(RecipeCount.ToString(), AcctMny, SbMny, decTotal.ToString());
                if (f.ShowDialog() == DialogResult.OK)
                {
                    l = 1;
                }
                else
                {
                    l = -1;
                }

                RecipeCount = 0;
            }

            return l;
        }
        #endregion

        #region 发药时获取当天相同药房ID的窗口ID
        /// <summary>
        /// 发药时获取当天相同药房ID的窗口ID
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="medstoreid"></param>
        /// <returns></returns>
        private string m_strGetwinid(string pid, string medstoreid, out int waitno)
        {
            string winid = "";
            waitno = 1;
            DataTable dt = new DataTable();

            long ret = objSvc.m_lngGetsendmedinfoBypid(pid, medstoreid, out dt);
            if (dt.Rows.Count > 0)
            {
                winid = dt.Rows[0]["windowid_chr"].ToString().Trim();
                waitno = Convert.ToInt32(dt.Rows[0]["order_int"]) + 1;
            }

            return winid;
        }
        #endregion

        #region 检查一种药同时可以发中、西药房的设定
        /// <summary>
        /// 检查一种药同时可以发中、西药房的设定
        /// (一张处方里的药(物): 没有指定到西药房发，但同时存在中药房发和在中西药房发的，则判断只在中药房发。)
        /// </summary>
        /// <returns></returns>
        public bool m_blnCheckmedproperty()
        {
            bool b = false;

            if (this.m_objViewer.ctlDataGrid1.RowCount <= 0)
            {
                return b;
            }

            string itemid = "";
            string medtype = "";
            Hashtable has = new Hashtable();

            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                itemid = this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim();
                medtype = objSvc.m_strGetOutSendMedStoretype(itemid);

                if (medtype != null && medtype != "" && !has.ContainsKey(medtype))
                {
                    has.Add(medtype, medtype);
                }
            }

            if (has.Count > 0)
            {
                bool b1 = has.ContainsKey("1");
                bool b2 = has.ContainsKey("2");
                bool b4 = has.ContainsKey("4");

                //一张处方里的药(物): 没有指定到西药房发，但同时存在中药房发和在中西药房发的，则判断只在中药房发。
                if (!b1 && b2 && b4)
                {
                    b = true;
                }
            }

            return b;
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

        #region 创建DBF数据
        /// <summary>
        /// 创建DBF数据
        /// </summary>
        /// <param name="p_strDBFile"></param>
        /// <param name="p_total"></param>
        /// <returns></returns>
        public bool m_blnCreateDBFData(ref string p_strDBFile, decimal p_total)
        {
            string str = this.m_objViewer.txtIDcard.Text.Trim();
            if (str == "")
            {
                MessageBox.Show("该病人没有身份证号，请在收费主界面或病人资料登记处补录。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            if ((this.m_objViewer.btSave.Tag == null) || (this.m_objViewer.btSave.Tag.ToString() == string.Empty))
            {
                MessageBox.Show("医保病人结算前先保存处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            string str2 = string.Empty;
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if ((this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() != "") && (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]) > 0M))
                {
                    str2 = str2 + "'" + this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() + "',";
                }
            }
            Hashtable hashtable = new Hashtable();
            if (str2 == string.Empty)
            {
                return false;
            }
            str2 = str2.Substring(0, str2.Length - 1);
            this.objSvc.m_lngGetIPInvoCat(str2, out hashtable);
            string str3 = this.m_objViewer.btSave.Tag.ToString().Substring(8, 6);
            int num2 = 0;
            this.HasYB = new Hashtable();
            ArrayList objYBArr = new ArrayList();
            clsOPSB_VO sopsb_vo = null;
            for (int j = 0; j < this.m_objViewer.ctlDataGrid1.RowCount; j++)
            {
                if (((this.m_objViewer.ctlDataGrid1[j, 10].ToString().Trim() != "") && (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 1]) > 0M)) && !this.HasYB.ContainsKey(j))
                {
                    sopsb_vo = new clsOPSB_VO();
                    str2 = this.m_objViewer.ctlDataGrid1[j, 10].ToString().Trim();
                    string str4 = this.m_objViewer.ctlDataGrid1[j, "colYbcode"].ToString().Trim();
                    decimal num4 = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 1]);
                    decimal num5 = 0;
                    if (this.intDiffPriceOn == 0)
                    {
                        num5 = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 7]);
                    }
                    else
                    {
                        num5 = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 7]) - Math.Abs(clsPublic.Round(this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, intDiffPriceTotalCol]), 2));
                    }
                    for (int m = j + 1; m < this.m_objViewer.ctlDataGrid1.RowCount; m++)
                    {
                        if ((this.m_objViewer.ctlDataGrid1[m, "colYbcode"].ToString().Trim() == str4) && (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[m, 1]) > 0M))
                        {
                            num4 += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[m, 1]);
                            if (this.intDiffPriceOn == 0)
                            {
                                num5 += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[m, 7]);
                            }
                            else
                            {
                                num5 += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[m, 7]) - Math.Abs(clsPublic.Round(this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[m, intDiffPriceTotalCol]), 2));
                            }
                            this.HasYB.Add(m, j);
                        }
                    }
                    if (this.m_objViewer.ctlDataGrid1[j, 8].ToString().Trim() == "0003")
                    {
                        decimal num7 = 1M;
                        if (this.m_objViewer.numericUpDown1.Value > 1M)
                        {
                            num7 = this.m_objViewer.numericUpDown1.Value;
                        }
                        num4 *= num7;
                    }
                    num2++;
                    sopsb_vo.YYBH = this.Hospcode;
                    sopsb_vo.ZYH = this.m_objViewer.LoginInfo.m_strEmpNo + str3;
                    sopsb_vo.GMSFHM = str;
                    sopsb_vo.FYRQ = DateTime.Now.ToString("yyyyMMdd");
                    sopsb_vo.XMXH = num2;
                    sopsb_vo.XMBH = str4;
                    sopsb_vo.XMMC = this.m_objViewer.ctlDataGrid1[j, 2].ToString().Trim();
                    sopsb_vo.FLDM = hashtable[str2].ToString();
                    sopsb_vo.YPGG = this.m_objViewer.ctlDataGrid1[j, 4].ToString().Trim();
                    sopsb_vo.YPJX = "";
                    if (this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 6]) > 0 && this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, intDiffUnitPriceCol]) > 0)
                        sopsb_vo.JG = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, intDiffUnitPriceCol]); //6]); // col6: 零售单价
                    else
                        sopsb_vo.JG = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 6]); // 零售单价
                    sopsb_vo.MCYL = num4;
                    sopsb_vo.JE = num5;
                    objYBArr.Add(sopsb_vo);
                }
            }
            if (objYBArr.Count == 0)
            {
                return false;
            }
            p_strDBFile = this.DBQ + "A" + sopsb_vo.FYRQ + sopsb_vo.ZYH + this.m_objViewer.m_PatientBasicInfo.PatientName + ".dbf";
            if (File.Exists(p_strDBFile))
            {
                File.Delete(p_strDBFile);
            }
            if (this.objSvc.m_lngCreateDbf_OutPatient(this.SQLParm, p_strDBFile, objYBArr) <= 0L)
            {
                MessageBox.Show("生成医保DBF文件失败。", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 创建DBF数据
        /// </summary>
        /// <returns></returns>
        public bool m_blnCreateDBFData_bak(ref string p_strDBFile, decimal totalMoney)
        {
            string strIDCard = this.m_objViewer.txtIDcard.Text.Trim();
            if (strIDCard == "")
            {
                MessageBox.Show("该病人没有身份证号，请在收费主界面或病人资料登记处补录。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (this.m_objViewer.btSave.Tag == null || this.m_objViewer.btSave.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("医保病人结算前先保存处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            string strItemID = string.Empty;
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() != "" && this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]) > 0)
                {
                    strItemID += "'" + this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() + "',";
                }
            }

            Hashtable hasItemCat = new Hashtable();
            if (strItemID == string.Empty)
            {
                return false;
            }
            else
            {
                strItemID = strItemID.Substring(0, strItemID.Length - 1);
                this.objSvc.m_lngGetIPInvoCat(strItemID, out hasItemCat);
            }

            string strSubRecipeID = this.m_objViewer.btSave.Tag.ToString().Substring(8, 6);

            int intXmxh = 0;
            HasYB = new Hashtable();
            ArrayList objYBArr = new ArrayList();

            clsOPSB_VO objYB = null;
            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() != "" && this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]) > 0)
                {
                    if (HasYB.ContainsKey(i))
                    {
                        continue;
                    }

                    objYB = new clsOPSB_VO();

                    strItemID = this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim();
                    string ybcode = this.m_objViewer.ctlDataGrid1[i, "colYbcode"].ToString().Trim();
                    decimal qnt = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]);
                    decimal amt = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 7]);
                    string relrowno = i.ToString();

                    for (int j = i + 1; j < this.m_objViewer.ctlDataGrid1.RowCount; j++)
                    {
                        if (this.m_objViewer.ctlDataGrid1[j, "colYbcode"].ToString().Trim() == ybcode && this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 1]) > 0)
                        {
                            qnt += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 1]);
                            //amt += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 7]);
                            if (intDiffPriceOn == 0)
                                amt += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 7]);
                            else
                                amt += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 7]) + clsPublic.Round(this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, intDiffPriceTotalCol]), 2);// 减掉总让利金额
                            HasYB.Add(j, i);
                        }
                    }

                    /***中药发票分类固定＝0003｛＝this.objCalPatientCharge.InvoiceCatID｝***/
                    if (this.m_objViewer.ctlDataGrid1[i, 8].ToString().Trim() == "0003")
                    {
                        decimal fs = 1;
                        if (this.m_objViewer.numericUpDown1.Value > 1)
                        {
                            fs = this.m_objViewer.numericUpDown1.Value;
                        }
                        qnt = qnt * fs;
                    }
                    /******/
                    intXmxh++;

                    objYB.YYBH = this.Hospcode;
                    objYB.ZYH = this.m_objViewer.LoginInfo.m_strEmpNo + strSubRecipeID;
                    objYB.GMSFHM = strIDCard;
                    objYB.FYRQ = DateTime.Now.ToString("yyyyMMdd");
                    objYB.XMXH = intXmxh;
                    objYB.XMBH = ybcode;
                    objYB.XMMC = this.m_objViewer.ctlDataGrid1[i, 2].ToString().Trim();
                    objYB.FLDM = hasItemCat[strItemID].ToString();
                    objYB.YPGG = this.m_objViewer.ctlDataGrid1[i, 4].ToString().Trim();
                    objYB.YPJX = "";
                    if (this.intDiffPriceOn == 1)
                    {
                        if (blMedicine9003((m_objViewer.ctlDataGrid1[i, 10].ToString().Trim())))// 判断是否是药品
                        {
                            objYB.JG = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, intDiffUnitPriceCol]);
                            if (objYB.JG == 0)
                                objYB.JG = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 6]);
                        }
                        else
                            objYB.JG = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 6]);
                    }
                    else
                        objYB.JG = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 6]);
                    objYB.MCYL = qnt;
                    objYB.JE = amt;
                    // 20151102     objYB.JG = decimal.Round(amt / qnt, 4);//金额/数量。
                    objYBArr.Add(objYB);
                }
            }

            if (objYBArr.Count == 0)
            {
                return false;
            }

            // 20151102
            int k = -1;
            decimal dec = 0;
            decimal tmpMoney1 = 0;
            decimal tmpMoney2 = 0;
            foreach (clsOPSB_VO item in objYBArr)
            {
                ++k;
                dec += clsPublic.Round(item.JG * item.MCYL, 2);
                tmpMoney1 += dec;
                if (k != objYBArr.Count - 1) tmpMoney2 += dec;
            }
            if (totalMoney != tmpMoney1)
            {
                ((clsOPSB_VO)objYBArr[objYBArr.Count - 1]).JG = clsPublic.Round((totalMoney - tmpMoney2) / ((clsOPSB_VO)objYBArr[objYBArr.Count - 1]).MCYL, 4);
            }

            //decimal TempTotal = 0;
            //decimal AddedTotal = 0;
            //for (int k = 0; k < objYBArr.Count; k++)
            //{
            //    clsOPSB_VO vo =(clsOPSB_VO) objYBArr[k];
            //    TempTotal += vo.MCYL * vo.JG;
            //    AddedTotal += vo.JE;
            //}
            //decimal diff = AddedTotal - TempTotal;
            //if (diff != 0)
            //{
            //    if (diff > 0)//说明计算出来的 四舍五入之后金额少了 需要加上
            //    {
            //        clsOPSB_VO voTemp=(clsOPSB_VO)objYBArr[0];
            //        voTemp.JE += diff;
            //        voTemp.JG = decimal.Round(voTemp.JE / voTemp.MCYL, 4);//金额/数量
            //    }
            //    else
            //    {
            //        for (int k = 0; k < objYBArr.Count; k++)
            //        {
            //            clsOPSB_VO vo = (clsOPSB_VO)objYBArr[k];
            //            if (vo.JE + diff > 1)
            //            {
            //                vo.JE += diff;
            //                vo.JG = decimal.Round(vo.JE / vo.MCYL,4);//金额/数量
            //                break;
            //            }
            //        }
            //    }
            //}

            //A+年年年年月月日日＋医院业务流水号+姓名.dbf
            p_strDBFile = this.DBQ + "A" + objYB.FYRQ + objYB.ZYH + this.m_objViewer.m_PatientBasicInfo.PatientName + ".dbf";

            if (File.Exists(p_strDBFile))
            {
                File.Delete(p_strDBFile);
            }

            long l = this.objSvc.m_lngCreateDbf_OutPatient(this.SQLParm, p_strDBFile, objYBArr);
            if (l > 0)
            {
                //MessageBox.Show("生成医保DBF文件成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("生成医保DBF文件失败。", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        #endregion

        #region 新嵌入式社保接口验证
        /// <summary>
        /// 新嵌入式社保接口验证
        /// </summary>
        /// <returns></returns>
        public bool m_blnNewYbInterface()
        {
            string strIDCard = this.m_objViewer.txtIDcard.Text.Trim();
            if (strIDCard == "")
            {
                MessageBox.Show("该病人没有身份证号，请在收费主界面或病人资料登记处补录。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            if (this.m_objViewer.btSave.Tag == null || this.m_objViewer.btSave.Tag.ToString() == string.Empty)
            {
                MessageBox.Show("医保病人结算前先保存处方。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }
        #endregion

        #region 读取DBF文件信息
        /// <summary>
        /// 读取DBF文件信息
        /// </summary>
        /// <param name="p_strDBFile"></param>
        public bool m_blnReadDBFData(string p_strDBFile, out DataTable p_dtYB)
        {
            p_dtYB = new DataTable();

            long l = this.objSvc.m_lngGetResult_OutPatient(this.SQLParm, p_strDBFile, out p_dtYB);
            if (l > 0 && p_dtYB.Rows.Count > 0)
            {

            }
            else
            {
                return false;
            }

            return true;
        }
        #endregion

        #region 更新结算号
        /// <summary>
        /// 更新结算号
        /// </summary>
        /// <param name="p_strChargeNo"></param>
        public void m_mthUpdateChargeNo(string p_strChargeNo)
        {
            if (string.IsNullOrEmpty(this.m_objViewer.btSave.Tag.ToString()))
            {
                return;
            }

            this.objSvc.m_lngUpdateYBChargeNo(this.m_objViewer.btSave.Tag.ToString(), p_strChargeNo);
        }
        #endregion

        #region 传送收费信息到医保前置机
        /// <summary>
        /// 传送收费信息到医保前置机
        /// </summary>
        /// <returns></returns>
        public bool m_blnSendybdata(ref string BillNO)
        {
            bool ret = false;
            ArrayList objYBArr = new ArrayList();

            string YBCardNo = this.m_objViewer.txtInsuranceID.Text.Trim();
            if (YBCardNo == "")
            {
                MessageBox.Show("该病人没有医保卡号(或离休编号)，请在收费主界面或病人资料登记处补录。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            YBCardNo += "+" + this.m_objViewer.m_PatientBasicInfo.PatientName;

            HasYB = null;
            HasYB = new Hashtable();

            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() != "" && this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]) > 0)
                {
                    if (HasYB.ContainsKey(i))
                    {
                        continue;
                    }

                    clsYB_VO objYB = new clsYB_VO();

                    string ybcode = this.m_objViewer.ctlDataGrid1[i, "colYbcode"].ToString().Trim();
                    decimal qnt = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]);
                    decimal amt = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 7]);
                    string relrowno = i.ToString();

                    for (int j = i + 1; j < this.m_objViewer.ctlDataGrid1.RowCount; j++)
                    {
                        if (this.m_objViewer.ctlDataGrid1[j, "colYbcode"].ToString().Trim() == ybcode && this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 1]) > 0)
                        {
                            qnt += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 1]);
                            amt += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 7]);
                            HasYB.Add(j, i);
                        }
                    }

                    /***中药发票分类固定＝0003｛＝this.objCalPatientCharge.InvoiceCatID｝***/
                    if (this.m_objViewer.ctlDataGrid1[i, 8].ToString().Trim() == "0003")
                    {
                        decimal fs = 1;
                        if (this.m_objViewer.numericUpDown1.Value > 1)
                        {
                            fs = this.m_objViewer.numericUpDown1.Value;
                        }
                        qnt = qnt * fs;
                    }
                    /******/

                    objYB.Hoscode = Hospcode;
                    objYB.Billno = "";
                    objYB.XMCode = ybcode;
                    objYB.Asssign = "";

                    if (this.m_objViewer.ctlDataGrid1[i, 2].ToString().Trim().Length <= 15)
                    {
                        objYB.XMDes = this.m_objViewer.ctlDataGrid1[i, 2].ToString().Trim();
                    }
                    else
                    {
                        objYB.XMDes = this.m_objViewer.ctlDataGrid1[i, 2].ToString().Trim().Substring(0, 15);
                    }

                    if (this.m_objViewer.ctlDataGrid1[i, 5].ToString().Trim().Length <= 4)
                    {
                        objYB.XMUnt = this.m_objViewer.ctlDataGrid1[i, 5].ToString().Trim();
                    }
                    else
                    {
                        objYB.XMUnt = this.m_objViewer.ctlDataGrid1[i, 5].ToString().Trim().Substring(0, 4);
                    }
                    objYB.XMQnt = qnt;
                    objYB.XMPrc = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 6]);
                    objYB.XMAmt = amt;
                    objYB.Trndate = DateTime.Now.ToString("yyyy-MM-dd");
                    objYB.Trnflag = "F";
                    objYB.Memoa = YBCardNo;
                    objYB.UVersion = "";

                    objYBArr.Add(objYB);
                }
            }

            ArrayList objRecipeArr = new ArrayList();

            foreach (clsOutPatientRecipe_VO o in objHashTable.Values)
            {
                objRecipeArr.Add(o.m_strOutpatRecipeID);
            }

            long l = this.objSvc.m_lngSendybdata(DB2Parm, objRecipeArr, objYBArr, ref BillNO);
            if (l == 1)
            {
                ret = true;
            }

            return ret;
        }
        #endregion

        #region 读取医保数据并且填充到DATAGRID
        /// <summary>
        /// 读取医保数据并且填充到DATAGRID
        /// </summary>
        public void m_mthGetybdata(com.digitalwave.controls.datagrid.ctlDataGrid dg)
        {
            DataTable dt = new DataTable();

            long l = this.objSvc.m_lngGetybjsmx(DB2Parm, Hospcode, BillNO, out dt);
            if (l == 0)
            {
                return;
            }

            if (dg.RowCount == 0)
            {
                return;
            }

            this.m_objViewer.TolVal = 0;
            this.m_objViewer.YBVal = this.m_mthConvertObjToDecimal(dt.Rows[0]["zfyp"]) + this.m_mthConvertObjToDecimal(dt.Rows[0]["ylyp"]) +
                                     this.m_mthConvertObjToDecimal(dt.Rows[0]["zcyp"]) + this.m_mthConvertObjToDecimal(dt.Rows[0]["zcyf"]) +
                                     this.m_mthConvertObjToDecimal(dt.Rows[0]["gxylf"]) + this.m_mthConvertObjToDecimal(dt.Rows[0]["qtfy"]) +
                                     this.m_mthConvertObjToDecimal(dt.Rows[0]["lxqjf"]) + this.m_mthConvertObjToDecimal(dt.Rows[0]["lxfqjf"]) +
                                     this.m_mthConvertObjToDecimal(dt.Rows[0]["lxjkcl"]) + this.m_mthConvertObjToDecimal(dt.Rows[0]["ylxma"]) +
                                     this.m_mthConvertObjToDecimal(dt.Rows[0]["ylxmb"]) + this.m_mthConvertObjToDecimal(dt.Rows[0]["ylxmc"]) +
                                     this.m_mthConvertObjToDecimal(dt.Rows[0]["ylxmd"]) + this.m_mthConvertObjToDecimal(dt.Rows[0]["ylxme"]);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string itemcode = dt.Rows[i]["xmcode"].ToString().Trim();
                decimal ybval = this.m_mthConvertObjToDecimal(dt.Rows[i]["nrzamt"]);
                decimal tolval = this.m_mthConvertObjToDecimal(dt.Rows[i]["ylfamt"]);
                decimal scale = 100;

                if (tolval != 0)
                {
                    scale = 100 - Math.Floor((ybval / tolval) * 100);
                }

                this.m_objViewer.TolVal += tolval;

                for (int j = 0; j < dg.RowCount; j++)
                {
                    if (dg[j, 0].ToString().Trim() == itemcode)
                    {
                        decimal zje = this.m_mthConvertObjToDecimal(dg[j, 7]);
                        decimal zfje = Math.Round(zje * scale / 100, 2);
                        decimal ybje = zje - zfje;

                        dg[j, 13] = scale.ToString() + "%";
                        dg[j, 14] = scale;
                        dg[j, 23] = zfje.ToString("0.00");
                        dg[j, 32] = ybje.ToString("0.00");
                    }
                }

                this.m_objViewer.YBFlag = true;
            }
        }
        #endregion

        #region 传送或读取医保数据
        /// <summary>
        /// 传送或读取医保数据
        /// </summary>
        public bool m_blnYBStart(Label lblBillNO, com.digitalwave.controls.datagrid.ctlDataGrid dg)
        {
            if (this.m_objViewer.btSave.Tag != null && this.m_objViewer.btSave.Tag.ToString().Trim() != "")
            {
                string recno = this.m_objViewer.btSave.Tag.ToString().Trim();
                bool b = false;
                BillNO = "";

                long l = this.objSvc.m_lngGetybbillno(recno, ref BillNO);
                if (l > 0 && BillNO.Trim() != "")
                {
                    if (this.objSvc.m_blnCheckBillNo(DB2Parm, this.Hospcode, BillNO))
                    {
                        b = true;
                    }
                    else
                    {
                        l = this.objSvc.m_lngDelybdata(DB2Parm, BillNO);
                        if (l > 0)
                        {
                            bool b1 = this.m_blnSendybdata(ref BillNO);
                            if (!b1)
                            {
                                MessageBox.Show("传送收费信息到医保系统失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("传送收费信息到医保系统失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return false;
                        }
                    }
                }
                else
                {
                    bool b1 = this.m_blnSendybdata(ref BillNO);
                    if (!b1)
                    {
                        MessageBox.Show("传送收费信息到医保系统失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return false;
                    }
                }

                if (!this.objSvc.m_blnCheckSendRes(DB2Parm, this.Hospcode, BillNO))
                {
                    MessageBox.Show("请再次点击【医保结算】按钮！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                lblBillNO.Text = BillNO;
                dg.m_mthDeleteAllRow();

                for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
                {
                    if (this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() != "" && this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]) > 0)
                    {
                        int row = dg.RowCount;
                        dg.m_mthAppendRow();

                        dg[row, 0] = this.m_objViewer.ctlDataGrid1[i, "colYbcode"];
                        dg[row, 1] = this.m_objViewer.ctlDataGrid1[i, 1];
                        dg[row, 2] = this.m_objViewer.ctlDataGrid1[i, 2];
                        dg[row, 3] = this.m_objViewer.ctlDataGrid1[i, 3];
                        dg[row, 4] = this.m_objViewer.ctlDataGrid1[i, 4];
                        dg[row, 5] = this.m_objViewer.ctlDataGrid1[i, 5];
                        dg[row, 6] = this.m_objViewer.ctlDataGrid1[i, 6];
                        dg[row, 7] = this.m_objViewer.ctlDataGrid1[i, 7];
                        dg[row, 13] = this.m_objViewer.ctlDataGrid1[i, 13];
                        dg[row, 14] = this.m_objViewer.ctlDataGrid1[i, 14];
                        dg[row, 23] = this.m_objViewer.ctlDataGrid1[i, 23];
                    }
                }

                if (b)
                {
                    this.m_mthGetybdata(dg);
                }
            }
            else
            {
                MessageBox.Show("医保结算的处方需要预先手工保存，请保存该处方后再次结算。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            return true;
        }
        #endregion

        #region 更新自付比例
        /// <summary>
        /// 更新自付比例
        /// </summary>
        /// <param name="dg"></param>
        /// <returns></returns>
        public void m_mthYBEnd(com.digitalwave.controls.datagrid.ctlDataGrid dg)
        {
            for (int i = 0; i < dg.RowCount; i++)
            {
                this.m_objViewer.ctlDataGrid1[i, 13] = dg[i, 13];
                this.m_objViewer.ctlDataGrid1[i, 14] = dg[i, 14];
            }
        }
        #endregion

        #region 手工更改记帐单号
        /// <summary>
        /// 手工更改记帐单号
        /// </summary>
        /// <param name="BillNo"></param>
        /// <returns></returns>
        public bool m_blnModifyBillNo(out string BillNo)
        {
            BillNo = this.BillNO;
            string ErrMsg = "生成新的记帐单号失败。";
            bool ret = false;

            bool IsExist = this.objSvc.m_blnCheckBillNo(DB2Parm, this.Hospcode, BillNo);
            if (IsExist)
            {
                ErrMsg = "该笔费用已由医保中心结算，不能手工更改记帐单号。";
            }
            else
            {
                string NewBillNo = "";
                this.objSvc.m_mthGenBillNo(out NewBillNo);
                if (NewBillNo != "")
                {
                    long l = this.objSvc.m_lngModifyBillNo(BillNo, NewBillNo);
                    if (l > 0)
                    {
                        l = this.objSvc.m_lngModifyBillNo(DB2Parm, BillNo, NewBillNo);
                        if (l > 0)
                        {
                            this.BillNO = NewBillNo;
                            BillNo = NewBillNo;
                            ret = true;
                        }
                        else
                        {
                            l = this.objSvc.m_lngModifyBillNo(NewBillNo, BillNo);
                        }
                    }
                }
            }

            if (!ret)
            {
                MessageBox.Show(ErrMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return ret;
        }
        #endregion

        #region 获取分隔字符串数值
        /// <summary>
        /// 获取分隔字符串数值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public ArrayList m_ArrGettoken(string str, string sign)
        {
            ArrayList val = new ArrayList();

            if (str.Trim() == "")
            {
                return val;
            }

            int pos = 0;
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

        #region 顺德特定医保
        /// <summary>
        /// 顺德特定顺德医保
        /// </summary>
        /// <returns></returns>
        public bool m_blnSDTDYB()
        {
            ArrayList objYBArr = new ArrayList();

            if (this.m_objViewer.txtInsuranceID.Text.Trim() == "")
            {
                MessageBox.Show("该病人没有医保卡号(或离休编号)，请在收费主界面或病人资料登记处补录。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            string RecipeID = this.m_objViewer.btSave.Tag.ToString();
            HasYB = null;
            HasYB = new Hashtable();

            for (int i = 0; i < this.m_objViewer.ctlDataGrid1.RowCount; i++)
            {
                if (this.m_objViewer.ctlDataGrid1[i, 10].ToString().Trim() != "" && this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]) > 0)
                {
                    if (HasYB.ContainsKey(i))
                    {
                        continue;
                    }

                    clsSDTDMZYB_VO objYB = new clsSDTDMZYB_VO();

                    string ybcode = this.m_objViewer.ctlDataGrid1[i, "colYbcode"].ToString().Trim();
                    string invocate = this.m_objViewer.ctlDataGrid1[i, 8].ToString().Trim();
                    decimal amount = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 1]);
                    decimal price = this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[i, 6]);

                    for (int j = i + 1; j < this.m_objViewer.ctlDataGrid1.RowCount; j++)
                    {
                        if (this.m_objViewer.ctlDataGrid1[j, "colYbcode"].ToString().Trim() == ybcode && this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 1]) > 0)
                        {
                            amount += this.m_mthConvertObjToDecimal(this.m_objViewer.ctlDataGrid1[j, 1]);
                            HasYB.Add(j, i);
                        }
                    }

                    /***中药发票分类固定＝0003｛＝this.objCalPatientCharge.InvoiceCatID｝***/
                    if (invocate == "0003")
                    {
                        decimal fs = 1;
                        if (this.m_objViewer.numericUpDown1.Value > 1)
                        {
                            fs = this.m_objViewer.numericUpDown1.Value;
                        }
                        amount = amount * fs;
                    }
                    /******/

                    objYB.Yyid = RecipeID;
                    objYB.Xmbh = ybcode;
                    objYB.Fldm = invocate;

                    if (this.m_objViewer.ctlDataGrid1[i, 2].ToString().Trim().Length <= 25)
                    {
                        objYB.Zlxm = this.m_objViewer.ctlDataGrid1[i, 2].ToString().Trim();
                    }
                    else
                    {
                        objYB.Zlxm = this.m_objViewer.ctlDataGrid1[i, 2].ToString().Trim().Substring(0, 25);
                    }

                    objYB.Xmjg = price;
                    objYB.Xmsl = amount;
                    objYB.Zlfy = price * amount;
                    objYB.Xm = this.m_objViewer.m_PatientBasicInfo.PatientName;

                    objYBArr.Add(objYB);
                }
            }

            decimal YBMoney = 0;
            string OutMsg = "";
            long l = this.objSvc.m_lngSDTDMZYB(SQLParm, RecipeID, SDYBMzbm, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.txtInsuranceID.Text.Trim(), objYBArr, out YBMoney, out OutMsg);
            if (l == 0 || OutMsg.Trim() != "")
            {
                MessageBox.Show("特定医保结算失败。\r\n\r\n失败原因：" + OutMsg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            this.m_objViewer.YBVal = YBMoney;
            this.m_objViewer.YBFlag = true;

            return true;
        }
        #endregion

        #region 设置快捷信息
        /// <summary>
        /// 设置快捷信息
        /// </summary>
        /// <param name="frmMdi"></param>
        /// <param name="Index"></param>
        /// <param name="Info"></param>
        public void SetShortCutInfo(Form frmMdi, int Index, string Info)
        {
            StatusBar objInfoBar = new StatusBar();
            if (frmMdi != null)
            {
                foreach (Control c in frmMdi.Controls)
                {
                    if (c is StatusBar)
                    {
                        objInfoBar = c as StatusBar;
                        break;
                    }
                }
            }

            if (objInfoBar != null && objInfoBar.Panels.Count > 3)
            {
                objInfoBar.Panels[Index].Text = Info;
                objInfoBar.Panels[Index].ToolTipText = "";
            }
        }
        #endregion

        #region 判断是否是东莞市医保病人
        /// <summary>
        /// 判断是否是东莞市医保病人
        /// </summary>
        public void m_mthCheckYBPayType()
        {
            IsDongGuanYBPatient = false;
            if (YBPayTypeArr.Count > 0 && this.m_objViewer.m_PatientBasicInfo.PayTypeID.ToString().Trim() != "")
            {
                if (YBPayTypeArr.IndexOf(this.m_objViewer.m_PatientBasicInfo.PayTypeID) >= 0)
                {
                    IsDongGuanYBPatient = true;
                }
            }
        }
        #endregion


        public void m_mthGetPEDoctor()
        {
            if (!this.PEWorkStationFlag)
            {
                return;
            }

            string CardNo = this.m_objViewer.m_PatientBasicInfo.PatientCardID.Trim();
            if (CardNo == "")
            {
                return;
            }

            //string strDoctorID = "";
            clsEmployeeVO objDoctor;

            long l = this.objSvc.m_lngGetPEDoctor(CardNo, out objDoctor);

            if (l > 0 && objDoctor != null)
            {
                //this.m_objViewer.m_PatientBasicInfo.DoctorID = strDoctorID;
                //this.m_objViewer.m_PatientBasicInfo.m_FindLvw(strDoctorID);
                ////this.m_objViewer.m_PatientBasicInfo.m_GetlvwItem();
                //this.m_objViewer.m_PatientBasicInfo.m_lsvAllplan_DoubleClick(null, null);
                this.m_objViewer.m_PatientBasicInfo.m_mthFillDoc(objDoctor);
                this.m_mthSetFocusOnDataGrid();
            }
            else
            {
                MessageBox.Show(this.m_objViewer, "未找到体检登记者信息。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region (体检)加载体检人收费信息
        /// <summary>
        /// (体检)加载体检人收费信息
        /// </summary>
        public void m_mthLoadPEItem()
        {
            this.PERegisterNoArr = "";

            if (!this.PEWorkStationFlag)
            {
                return;
            }

            string CardNo = this.m_objViewer.m_PatientBasicInfo.PatientCardID.Trim();
            if (CardNo == "")
            {
                return;
            }

            DataTable dt;

            long l = this.objSvc.m_lngGetPEChargeItem(CardNo, out dt);
            if (l > 0)
            {
                if (dt == null || dt.Rows.Count == 0)
                {
                    return;
                }
                else
                {
                    string strPatientTypeID = "0001";
                    if (this.m_objViewer.m_PatientBasicInfo.PayTypeID.Trim() != "")
                    {
                        strPatientTypeID = this.m_objViewer.m_PatientBasicInfo.PayTypeID.Trim();
                    }

                    ArrayList objRegNo = new ArrayList();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        m_mthGetChargeItemByItem(dt.Rows[i]["ITEMID_CHR"].ToString().Trim(), strPatientTypeID, 2);
                        this.m_objViewer.IsSave = false;
                        this.m_objViewer.ctlDataGrid1_m_evtCurrentCellChanged(null, null);
                        this.m_objViewer.rowNO++;

                        if (objRegNo.IndexOf(dt.Rows[i]["regno_chr"].ToString().Trim()) < 0)
                        {
                            objRegNo.Add(dt.Rows[i]["regno_chr"].ToString().Trim());

                        }
                    }

                    if (objRegNo.Count > 0)
                    {
                        for (int j = 0; j < objRegNo.Count; j++)
                        {
                            this.PERegisterNoArr += objRegNo[j].ToString() + ";";
                        }
                        this.PERegisterNoArr = this.PERegisterNoArr.Substring(0, this.PERegisterNoArr.Length - 1);
                    }

                    this.m_mthSetFocusOnDataGrid();
                }
            }
        }
        #endregion

        #region (体检)自动发送检验申请单
        /// <summary>
        /// (体检)自动发送检验申请单
        /// </summary>
        public void m_mthAutoSendLisApplyBill()
        {
            string CardNo = this.m_objViewer.m_PatientBasicInfo.PatientCardID.Trim();
            if (CardNo == "")
            {
                return;
            }

            if (this.PERegisterNoArr.Trim() == "")
            {
                return;
            }

            DataTable dt;

            long l = this.objSvc.m_lngGetPELisItem(CardNo, out dt);
            if (l > 0)
            {
                string SampleTypeID = "";
                DataRow dr = null;
                ArrayList objTemp = new ArrayList();
                System.Collections.Generic.List<clsPERegGroup_VO> objPERegGroup = new System.Collections.Generic.List<clsPERegGroup_VO>();
                clsPERegGroup_VO objRegGroup;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dr = dt.Rows[i];

                    clsTestApplyItme_VO item_VO = new clsTestApplyItme_VO();
                    item_VO.m_decDiscount = 100;
                    item_VO.m_decPrice = m_mthConvertObjToDecimal(dr["price_dec"]);
                    item_VO.m_decQty = 1;
                    item_VO.m_decTolPrice = m_mthConvertObjToDecimal(dr["price_dec"]);
                    item_VO.m_strItemID = dr["lisappgroupid_vchr"].ToString().Trim();
                    item_VO.m_strItemName = dr["groupname_vchr"].ToString().Trim();
                    item_VO.m_strSpec = "";
                    item_VO.m_strUnit = "";
                    item_VO.m_strOutpatRecipeID = "";
                    item_VO.m_strRowNo = i.ToString();
                    item_VO.m_strOprDeptID = "";
                    item_VO.strPartID = dr["groupcode_chr"].ToString().Trim();
                    item_VO.m_strOutpatRecipeDeID = dr["groupcode_chr"].ToString().Trim();  //这里借用保存组合CODE
                    if (dr["lissampleid_vchr"].ToString().Trim() != "")
                    {
                        SampleTypeID = dr["lissampleid_vchr"].ToString().Trim();
                        item_VO.m_strSampleId = SampleTypeID;
                    }
                    objTemp.Add(item_VO);

                    objRegGroup = new clsPERegGroup_VO();
                    objRegGroup.Itemcode = dr["groupcode_chr"].ToString().Trim();
                    objRegGroup.RegNo = dr["regno_chr"].ToString().Trim();
                    objRegGroup.intStatus = 2;
                    objPERegGroup.Add(objRegGroup);

                }

                clsLisApplMainVO objLMVO = new clsLisApplMainVO();
                objLMVO.m_intEmergency = 0;
                objLMVO.m_intForm_int = 0;
                if (this.m_objViewer.m_PatientBasicInfo.PatientAge.IndexOf("月") >= 0)
                {
                    objLMVO.m_strAge = this.m_objViewer.m_PatientBasicInfo.PatientAge;
                }
                else
                {
                    objLMVO.m_strAge = this.m_objViewer.m_PatientBasicInfo.PatientAge + " 岁";
                }
                objLMVO.m_strAppl_DeptID = this.m_objViewer.m_PatientBasicInfo.DeptID;
                objLMVO.m_strAppl_EmpID = this.m_objViewer.m_PatientBasicInfo.DoctorID;
                objLMVO.m_strDiagnose = "";
                objLMVO.m_strOperator_ID = this.m_objViewer.LoginInfo.m_strEmpID;
                objLMVO.m_strPatient_Name = this.m_objViewer.m_PatientBasicInfo.PatientName;
                objLMVO.m_strPatientcardID = this.m_objViewer.m_PatientBasicInfo.PatientCardID;
                objLMVO.m_strPatientID = this.m_objViewer.m_PatientBasicInfo.PatientID;
                objLMVO.m_strPatientType = "2";
                objLMVO.m_strSex = this.m_objViewer.m_PatientBasicInfo.PatientSex;
                objLMVO.m_strPatient_inhospitalno_chr = this.PERegisterNoArr.Replace("'", "").Substring(0, 12);

                ArrayList objAttach = new ArrayList();
                clsTestApplyItme_VO[] itemArr_VO = (clsTestApplyItme_VO[])objTemp.ToArray(typeof(clsTestApplyItme_VO));
                if (itemArr_VO.Length > 0)
                {
                    objLMVO.m_strSampleTypeID = SampleTypeID;      //加入获取样本类型代码

                    frmLisAppl obj = new frmLisAppl();
                    if (obj.m_mthNewApp(objLMVO, itemArr_VO, false) == DialogResult.OK)
                    {
                        string ApplyID = "";
                        Hashtable hasTmp = new Hashtable();

                        clsLISAppResults[] objAppResult = obj.m_objGetMutiResults();
                        for (int j = 0; j < objAppResult.Length; j++)
                        {
                            for (int k = 0; k < objAppResult[j].m_strChargeIDs.Length; k++)
                            {
                                for (int k1 = 0; k1 < itemArr_VO.Length; k1++)
                                {
                                    if (objAppResult[j].m_ObjApplyUnitIDArr[k] == itemArr_VO[k1].m_strItemID)
                                    {
                                        ApplyID = objAppResult[j].m_StrApplicationID;

                                        if (hasTmp.ContainsKey(ApplyID))
                                        {
                                            continue;
                                        }
                                        else
                                        {
                                            hasTmp.Add(ApplyID, null);
                                        }

                                        clsATTACHRELATION_VO ATTACHRELATION_VO = new clsATTACHRELATION_VO();
                                        ATTACHRELATION_VO.strSYSFROM_INT = "7";
                                        ATTACHRELATION_VO.strATTACHTYPE_INT = "7";
                                        ATTACHRELATION_VO.strSOURCEITEMID_VCHR = this.PERegisterNoArr;
                                        ATTACHRELATION_VO.strATTACHID_VCHR = ApplyID;
                                        ATTACHRELATION_VO.strURGENCY_INT = "0";

                                        objAttach.Add(ATTACHRELATION_VO);
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("自动生成检验申请单失败，请手工重新发送。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }

                //更新收费标志
                l = this.objSvc.m_lngUpdatePEChargeFlag(clsPublic.m_ArrGettoken(this.PERegisterNoArr, ";"), objAttach, objPERegGroup);
                if (l == 0)
                {
                    MessageBox.Show("更新体检人收费标志失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        #endregion

        #region 重算明细处方，获取明细总金额
        /// <summary>
        /// 重算明细处方，获取明细总金额
        /// </summary>
        /// <param name="p_decTotalMoney"></param>
        /// <returns></returns>
        internal decimal m_decGetTotalPay()
        {
            decimal decTotalMoney = 0;//总价

            string strType = string.Empty;//类型
            decimal decPrice = 0;//价格
            decimal decQty = 0;//数量
            //decimal decPencent = 100;//比例
            decimal decDose = m_objViewer.numericUpDown1.Value; //服数
            decimal decSubTotal = 0;//单药品总价

            com.digitalwave.controls.datagrid.ctlDataGrid objGrid = m_objViewer.ctlDataGrid1;
            int intRowsCount = objGrid.RowCount;
            for (int i1 = 0; i1 < intRowsCount; i1++)
            {
                decSubTotal = 0;
                decQty = m_mthConvertObjToDecimal(objGrid[i1, 1]);
                decPrice = m_mthConvertObjToDecimal(objGrid[i1, 6]);
                //decPencent = m_mthConvertObjToDecimal(objGrid[i1, 14]);
                //decPencent /= 100;
                // *decPencent;
                strType = objGrid[i1, 9].ToString().Trim();
                //如果为中药，乘以服数
                if (strType == "0002")
                {
                    decimal cmQty = Math.Ceiling(decQty * decDose);
                    decSubTotal = cmQty * decPrice;
                    //decSubTotal *= decDose;
                }
                else
                {
                    decSubTotal = decQty * decPrice;
                }
                decSubTotal = Convert.ToDecimal(decSubTotal.ToString("0.00"));
                decTotalMoney += decSubTotal;
            }

            return decTotalMoney;
        }
        #endregion

        #region 处理选择交费项目
        /// <summary>
        /// 处理选择交费项目
        /// </summary>
        /// <param name="p_dtbChargeItemDetail">选择的收费项目明细</param>
        /// <param name="p_dtpDetailTableInfo">明细对应的</param>
        public long m_lngSelectFeeDispose()
        {
            /*
             * 1.生成一条新的主处方表记录,并把原来的处方表的pstauts_int状态改变 
             * 2.插入数据进入6个表中,如果有的话
             * 3.update检验检查的申请单，如果有的话,
             * 4.药品的如何处理
             * 5.新建一个表，记录本次修改信息的记录
             * 6、t_opr_outpatient_orderdic 诊疗项目表中插入检验、检查
             * *
             */

            long lngRes = -1;

            if (m_dicSelectChargeItemID == null || m_dicSelectChargeItemID.Count == 0)
            {
                return lngRes;
            }

            //原来的处方号
            string strOriginalRepcideID = this.m_objViewer.txtLoadRecipeNO.Text;
            //收集新的处方信息
            string strRecipeID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            clsOutPatientRecipe_VO OPR_VO = new clsOutPatientRecipe_VO();
            OPR_VO.m_strRecordDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            OPR_VO.m_strOperatorID = m_objViewer.LoginInfo.m_strEmpID;//操作员ID
            OPR_VO.m_strRegisterID = m_objViewer.m_PatientBasicInfo.RegisterID.Trim();
            OPR_VO.m_strDoctorID = m_objViewer.m_PatientBasicInfo.DoctorID.Trim();
            OPR_VO.m_strDepID = m_objViewer.m_PatientBasicInfo.DeptID.Trim();
            OPR_VO.m_strCreateDate = m_objViewer.m_PatientBasicInfo.RegisterDate;
            OPR_VO.m_strPatientID = m_objViewer.m_PatientBasicInfo.PatientID.Trim();
            OPR_VO.m_intPStatus = 1;
            OPR_VO.m_intType = int.Parse(m_objViewer.m_cmbRecipeType.Tag.ToString());
            OPR_VO.m_strPatientType = m_objViewer.m_PatientBasicInfo.PayTypeID;
            OPR_VO.m_strRecipeType = "0";
            OPR_VO.intCreatetype = 1;
            OPR_VO.intDeptmed = 0;
            OPR_VO.strIDcard = this.m_objViewer.txtIDcard.Text.Trim();
            OPR_VO.strInsuranceID = this.m_objViewer.txtInsuranceID.Text.Trim();
            OPR_VO.m_strOutpatRecipeID = strRecipeID;

            lngRes = this.objSvc.m_lngSelectFeeDispose(m_dicSelectChargeItemID, OPR_VO, strOriginalRepcideID);

            if (this.objHashTable.Count > 0)//把处方存放第一个处方ID
            {
                this.objHashTable.Clear();
            }

            this.objHashTable.Add(0, OPR_VO);

            return lngRes;
            //this.m_objViewer.txtLoadRecipeNO.Text = strRecipeID;
            //this.m_objViewer.btSave.Tag = strRecipeID;
        }
        #endregion

        #region 选择交费项目的id
        /// <summary>
        /// 选择交费项目的id
        /// </summary>
        /// <param name="p_dtbChargeItemDetail"></param>
        /// <param name="p_lstOrderDicItemID"></param>
        public void m_mthGetSelectChargeItemID(DataTable p_dtbChargeItemDetail, List<string> p_lstOrderDicItemID)
        {

            if (m_dicSelectChargeItemID != null)
            {
                m_dicSelectChargeItemID.Clear();
            }

            m_dicSelectChargeItemID = new Dictionary<string, List<string>>();

            List<string> lstItemIDWM = new List<string>();
            List<string> lstItemIDCM = new List<string>();
            //检验
            List<string> lstItemIDCheck = new List<string>();
            //检查
            List<string> lstItemIDTest = new List<string>();
            List<string> lstItemIDOps = new List<string>();
            List<string> lstItemIDOth = new List<string>();


            int intRowCount = p_dtbChargeItemDetail.Rows.Count;
            for (int i1 = 0; i1 < intRowCount; i1++)
            {
                DataRow dtrTmp = p_dtbChargeItemDetail.Rows[i1];

                string strTmp = dtrTmp["InvType"].ToString();
                string strType = m_mthRelationInfo(strTmp);
                string strItemID = dtrTmp["ItemID"].ToString();

                if (string.IsNullOrEmpty(strItemID))
                {
                    continue;
                }

                switch (strType)
                {
                    case "0001":
                        lstItemIDWM.Add(strItemID);
                        break;
                    case "0002":
                        lstItemIDCM.Add(strItemID);
                        break;
                    case "0003":
                        lstItemIDCheck.Add(strItemID);
                        break;
                    case "0004":
                        lstItemIDTest.Add(strItemID);
                        break;
                    case "0005":
                        lstItemIDOps.Add(strItemID);
                        break;
                    case "0006":
                        lstItemIDOth.Add(strItemID);
                        break;
                }
            }

            m_dicSelectChargeItemID.Add("cm", lstItemIDCM);
            m_dicSelectChargeItemID.Add("wm", lstItemIDWM);
            m_dicSelectChargeItemID.Add("test", lstItemIDTest);
            m_dicSelectChargeItemID.Add("check", lstItemIDCheck);
            m_dicSelectChargeItemID.Add("ops", lstItemIDOps);
            m_dicSelectChargeItemID.Add("oth", lstItemIDOth);
            //添加诊疗项目id
            m_dicSelectChargeItemID.Add("orderdic", p_lstOrderDicItemID);
        }

        #endregion

        #region 判断当前电脑是否发送中药处方信息到门诊中药房饮片机
        /// <summary>
        /// 判断当前电脑是否发送中药处方信息到门诊中药房饮片机
        /// </summary>
        internal void CheckCMachine()
        {
            DataTable dt1015 = new DataTable();
            clsDcl_OPCharge dcl = new clsDcl_OPCharge();
            dcl.m_lngGetMedUsageID("1015", ref dt1015);
            dcl = null;
            if (dt1015 != null && dt1015.Rows.Count > 0)
            {
                DataRow dr = dt1015.Rows[0];
                if (dr["status_int"].ToString() == "1")
                {
                    this.m_objViewer.HttpUri = dr["parmvalue_vchr"].ToString();
                    string ipAddrs = dr["note_vchr"] == DBNull.Value ? string.Empty : dr["note_vchr"].ToString().Trim();
                    if (ipAddrs != string.Empty)
                    {
                        string localIp = LocalIP();
                        string[] ips = ipAddrs.Split(';');
                        foreach (string ip in ips)
                        {
                            if (ip == localIp)
                            {
                                this.m_objViewer.IsRecipeHttpPost = true;
                                break;
                            }
                        }
                    }
                }
            }
        }

        string LocalIP()
        {
            string strHostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(strHostName);
            string strHostIP = ipEntry.AddressList[0].ToString();
            for (int i = 0; i < ipEntry.AddressList.Length; i++)
            {
                strHostIP = ipEntry.AddressList[i].ToString();
                if (strHostIP.Length <= 15)
                {
                    if ((strHostIP.Split('.')).Length == 4) break;
                }
            }
            return strHostIP;
        }
        #endregion
    }
}
