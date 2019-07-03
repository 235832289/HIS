using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Threading;
using System.Text.RegularExpressions;
using com.digitalwave.Utility;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS.Bill;
using com.digitalwave.iCare.middletier.CryptographyLib;
using System.Runtime.InteropServices;

namespace com.digitalwave.iCare.gui.HIS
{
    #region 住院公用方法类
    /// <summary>
    /// 住院公用方法类
    /// </summary>
    public class clsPublic
    {
        #region 变量
        /// <summary>
        /// XML文件名
        /// </summary>
        public static string XMLFile = Application.StartupPath + @"\LoginFile.xml";
        /// <summary>
        /// 视频文件播放窗口
        /// </summary>
        private static frmAnimation frmAvi = null;
        /// <summary>
        /// 自定义背景颜色
        /// </summary>
        public static Color CustomBackColor = Color.FromArgb(235, 240, 235); //Color.FromArgb(240, 245, 240); //Color.FromArgb(212, 222, 219);
        /// <summary>
        /// PB报表库文件路径
        /// </summary>
        public static string PBLPath = Application.StartupPath + "\\PBReport.pbl";
        #endregion

        #region API
        [DllImport("user32")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, int wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0xB;

        #region 启用/禁用.控件重绘
        /// <summary>
        /// 禁用重绘
        /// </summary>
        /// <param name="hwnd"></param>
        public static void SuspendLayout(IntPtr hwnd)
        {
            SendMessage(hwnd, WM_SETREDRAW, 0, IntPtr.Zero);
        }
        /// <summary>
        /// 启用重绘
        /// </summary>
        /// <param name="hwnd"></param>
        public static void ResumeLayout(IntPtr hwnd)
        {
            SendMessage(hwnd, WM_SETREDRAW, 1, IntPtr.Zero);
        }
        #endregion

        #endregion

        #region 播放视频
        /// <summary>
        /// 播放视频
        /// </summary>
        /// <param name="AviFileName">视频AVI文件名</param>
        /// <param name="MessageInfo">提示信息</param>
        public static void PlayAvi(string AviFileName, string MessageInfo)
        {
            frmAvi = new frmAnimation(AviFileName, MessageInfo);
            frmAvi.Show();
            frmAvi.Refresh();
            frmAvi.m_mthStart();
        }

        /// <summary>
        /// 播放视频
        /// </summary>
        /// <param name="MessageInfo">提示信息</param>
        public static void PlayAvi(string MessageInfo)
        {
            frmAvi = new frmAnimation("findFILE.avi", MessageInfo);
            frmAvi.Show();
            frmAvi.Refresh();
            frmAvi.m_mthStart();
        }
        #endregion

        #region 关闭视频
        /// <summary>
        /// 关闭视频
        /// </summary>
        public static void CloseAvi()
        {
            if (frmAvi != null)
            {
                frmAvi.Close();
                frmAvi = null;
            }
        }
        #endregion

        #region 计算年龄
        /// <summary>
        /// 计算年龄，根据返回的值得到是年，月或日
        /// </summary>
        /// <param name="dteBirth">出生日期</param>
        /// <param name="intAge">计算得到的年龄</param>
        /// <returns></returns>
        public static Age CalcAge(DateTime dteBirth, out int intAge)
        {
            Age age = Age.Year;
            intAge = 0;
            DateTime dteNow = DateTime.Now;
            int intYear = dteBirth.Year;
            int intMonth = dteBirth.Month;
            int intDay = dteBirth.Day;

            if ((dteNow.Year - intYear) > 0)
            {
                intAge = dteNow.Year - intYear;
                age = Age.Year;
            }
            else if ((dteNow.Month - intMonth) > 0)
            {
                intAge = dteNow.Month - intMonth;
                age = Age.Month;
            }
            else
            {
                intAge = dteNow.Day - intDay;
                age = Age.Day;
            }

            return age;

        }
        #endregion

        #region 计算年龄
        /// <summary>
        /// 计算年龄
        /// </summary>
        /// <param name="dteBirth">出生日期</param>
        /// <returns></returns>
        public static string CalcAge(DateTime dteBirth)
        {
            int intAge = 0;
            string strAge = "";
            Age age = Age.Year;
            age = CalcAge(dteBirth, out intAge);
            switch (age)
            {
                case Age.Year:
                    strAge = intAge.ToString();
                    break;
                case Age.Month:
                    strAge = intAge.ToString() + "个月";
                    break;
                case Age.Day:
                    strAge = intAge.ToString() + "天";
                    break;
            }
            return strAge;
        }
        #endregion

        #region 年龄
        /// <summary>
        /// 年龄
        /// </summary>
        public enum Age
        {
            /// <summary>
            /// 年
            /// </summary>
            Year,
            /// <summary>
            /// 月
            /// </summary>
            Month,
            /// <summary>
            /// 日
            /// </summary>
            Day
        }
        #endregion

        #region 将对象转换为数字
        /// <summary>
        /// 将对象转换为数字
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static decimal ConvertObjToDecimal(object obj)
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
        #endregion

        #region 将数值四舍五入
        /// <summary>
        /// 将数值四舍五入
        /// </summary>
        /// <param name="d">数值</param>
        /// <param name="decimals">小数位数</param>
        /// <returns></returns>
        public static decimal Round(decimal d, int decimals)
        {
            try
            {
                if (decimals < 1)
                {
                    return Convert.ToDecimal(Convert.ToInt32(d));
                }
                else
                {
                    string s = "0.";
                    for (int i = 0; i < decimals; i++)
                    {
                        s += "0";
                    }
                    return Convert.ToDecimal(d.ToString(s));
                }
            }
            catch
            {
                return d;
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
        public static string m_strReadXML(string parentnode, string childnode, string key)
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
        public static bool m_blnWriteXML(string parentnode, string childnode, string key, string val)
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

        #region 获取分隔字符串数值
        /// <summary>
        /// 获取分隔字符串数值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static ArrayList m_ArrGettoken(string str, string sign)
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

        /// <summary>
        /// 获取分隔字符串数值
        /// </summary>
        /// <param name="str"></param>
        /// <param name="sign"></param>
        /// <returns></returns>
        public static string m_strGettoken(ref string str, string sign)
        {
            string val = null;

            if (str.Trim() == "")
            {
                return val;
            }

            int pos = str.IndexOf(sign);

            if (pos > 0)
            {
                val = str.Substring(0, pos);
                str = str.Substring(pos + 1);
            }
            else
            {
                val = str;
            }

            return val;
        }
        #endregion

        #region 小写金额转大写
        /// <summary>
        /// 小写金额转大写
        /// </summary>
        /// <param name="money"></param>
        /// <returns></returns>
        public static string DoubleConvertToCurrency(double money)
        {
            string[] BigNumArr = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
            string[] UnitArr = { "分", "角", "圆", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟" };

            money = Math.Abs(money);

            string Money = money.ToString("0.00").Replace(".", "");

            int len = Money.Length;
            string s = "";
            string Result = "";

            for (int i = 1; i <= len; i++)
            {
                s = Money.Substring(len - i, 1);
                Result = string.Concat(BigNumArr[Int32.Parse(s)] + UnitArr[i - 1], Result);
            }

            Result = Result.Replace("拾零", "拾");
            Result = Result.Replace("零拾", "零");
            Result = Result.Replace("零佰", "零");
            Result = Result.Replace("零仟", "零");
            Result = Result.Replace("零万", "万");
            for (int i = 1; i <= 6; i++)
            {
                Result = Result.Replace("零零", "零");
            }
            Result = Result.Replace("零万", "零");
            Result = Result.Replace("零亿", "億");
            Result = Result.Replace("零零", "零");
            Result = Result.Replace("零角零分", "");
            Result = Result.Replace("零分", "");
            Result += "整";
            Result = Result.Replace("分整", "分");

            return Result;
        }
        #endregion

        #region 将数字转换为大写汉字
        /// <summary>
        /// 将数字转换为大写汉字
        /// </summary>
        /// <param name="m_strNumber">表示金额的字符串</param>
        /// <returns>返回大写的汉字金额</returns>
        public static string NumberToChineseNumber(string m_strNumber)
        {
            string m_strValue;
            switch (m_strNumber)
            {
                case "1":
                    m_strValue = "壹";
                    break;
                case "2":
                    m_strValue = "贰";
                    break;
                case "3":
                    m_strValue = "叁";
                    break;
                case "4":
                    m_strValue = "肆";
                    break;
                case "5":
                    m_strValue = "伍";
                    break;
                case "6":
                    m_strValue = "陆";
                    break;
                case "7":
                    m_strValue = "柒";
                    break;
                case "8":
                    m_strValue = "捌";
                    break;
                case "9":
                    m_strValue = "玖";
                    break;
                case "0":
                    m_strValue = "零";
                    break;
                default:
                    m_strValue = m_strNumber;
                    break;
            }
            return m_strValue;
        }
        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="setid">参数编号</param>
        /// <returns></returns>
        public static int m_intGetSysParm(string setid)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            int val = objSvc.m_intGetSysParm(setid);
            objSvc.Dispose();

            return val;
        }
        #endregion

        #region 获取当前按金单据号
        /// <summary>
        /// 获取当前按金单据号
        /// </summary>
        /// <returns></returns>
        public static string m_strGetCurrPrepayNo()
        {
            string prepayno = clsPublic.m_strReadXML("BeInHospital", "CurrPrepayBillNo", "AnyOne");

            try
            {
                prepayno = Convert.ToString(int.Parse(prepayno) + 1).PadLeft(7, '0');
            }
            catch
            {
                prepayno = "";
                MessageBox.Show("当前按金单据号设置错误，请重新设置。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return prepayno;
        }
        #endregion

        #region 判断按金单据号是否满足编号规则
        /// <summary>
        /// 判断按金单据号是否满足编号规则
        /// </summary>
        /// <param name="prepayno"></param>
        /// <returns></returns>
        public static bool m_blnCheckPrepayNoExpression(string prepayno)
        {
            bool Result = false;

            //获取规则表达式
            string PrepayNoExp = clsPublic.m_strReadXML("BeInHospital", "PrepayBillNoExp", "AnyOne");
            if (PrepayNoExp.Trim() == "")
            {
                return true;
            }

            Regex r = new Regex(PrepayNoExp);
            Match m = r.Match(prepayno);
            if (m.Success)
            {
                Result = true;
            }

            return Result;
        }
        #endregion

        #region 判断按金单据号是否已被使用
        /// <summary>
        /// 判断按金单据号是否已被使用
        /// </summary>
        /// <param name="prepayno"></param>
        /// <param name="pretype">预交类型：0 正常 1 手工</param>
        /// <returns></returns>
        public static bool m_blnCheckPrepayNoIsUsed(string prepayno, int pretype)
        {
            clsDcl_PrePay objPrepay = new clsDcl_PrePay();

            return objPrepay.m_blnCheckPrepayBillNo(prepayno, pretype);
        }
        #endregion

        #region 获取当前发票号
        /// <summary>
        /// 获取当前发票号
        /// </summary>
        /// <param name="OperID">收款员ID</param>
        /// <param name="Type">类型： 1 住院发票 2 押金单 3 门诊发票</param>
        /// <returns></returns>
        public static string m_strGetCurrInvoiceNo(string OperID, int Type)
        {
            string invono = "";

            clsDcl_Charge objCharge = new clsDcl_Charge();

            long l = objCharge.m_lngGetOperInvoNO(OperID, Type, out invono);

            int intNumLenght = 8;//预交金单号中数字长度长度
            intNumLenght = clsPublic.m_intGetSysParm("1085");

            if (invono == "")
            {
                if (Type == 1)
                {
                    invono = clsPublic.m_strReadXML("BeInHospital", "CurrInvoiceNo", "AnyOne");

                    try
                    {
                        invono = invono.Substring(0, 2) + Convert.ToString(Convert.ToDecimal(invono.Substring(2)) + 1).PadLeft(8, '0');
                    }
                    catch
                    {
                        invono = "";
                        MessageBox.Show("当前发票号设置错误，请重新设置。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Type == 2)
                {
                    invono = clsPublic.m_strReadXML("BeInHospital", "CurrPrepayBillNo", "AnyOne");

                    //try
                    //{
                    //    invono = Convert.ToString(int.Parse(invono) + 1).PadLeft(7, '0');
                    //}
                    //catch
                    //{
                    //    invono = "";
                    //    MessageBox.Show("当前按金单据号设置错误，请重新设置。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}

                    try
                    {
                        invono = Convert.ToString(int.Parse(invono) + 1).PadLeft(intNumLenght, '0');
                    }
                    catch
                    {
                        invono = "";
                        MessageBox.Show("当前按金单据号设置错误，请重新设置。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (Type == 3)
                {
                }
            }
            else
            {
                //if (Type == 2)
                //{
                //    invono = invono.PadLeft(7, '0');
                //}
                if (Type == 2)
                {
                    if (invono.Length < intNumLenght)
                    {
                        MessageBox.Show("当前使用的发票长度小于发票数字设置长度,请检查!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        invono = "";
                    }
                    else
                    {
                        string strHead = invono.Substring(0, invono.Length - intNumLenght);
                        string strLast = invono.Substring(invono.Length - intNumLenght);
                        invono = strHead + Convert.ToString((int.Parse(strLast) + 1)).PadLeft(intNumLenght, '0');
                    }
                }
            }

            return invono;
        }
        #endregion

        #region 保存当前发票号
        /// <summary>
        /// 保存当前发票号
        /// </summary>
        /// <param name="OperID">操作员ID</param>
        /// <param name="InvoNo">发票号(押金单号)</param>
        /// <param name="Type">类型： 1 住院发票 2 押金单 3 门诊发票</param>
        /// <returns>成功 true 失败 false</returns>
        public static bool m_blnSaveCurrInvoiceNo(string OperID, string InvoNo, int Type)
        {
            bool b = false;
            clsDcl_Charge objCharge = new clsDcl_Charge();

            long l = objCharge.m_lngRegOperInvoNO(OperID, InvoNo, Type);
            if (l > 0)
            {
                b = true;
            }

            return b;
        }
        #endregion

        #region 判断发票号是否满足编号规则
        /// <summary>
        /// 判断发票号是否满足编号规则
        /// </summary>
        /// <param name="invono"></param>
        /// <returns></returns>
        public static bool m_blnCheckInvoExpression(string invono)
        {
            bool Result = false;

            //获取规则表达式
            string InvoExp = clsPublic.m_strReadXML("BeInHospital", "InvoiceNoExp", "AnyOne");
            if (InvoExp.Trim() == "")
            {
                return true;
            }

            Regex r = new Regex(InvoExp);
            Match m = r.Match(invono);
            if (m.Success)
            {
                Result = true;
            }

            return Result;
        }
        #endregion

        #region 判断发票号是否已被使用
        /// <summary>
        /// 判断发票号是否已被使用
        /// </summary>
        /// <param name="invono"></param>
        /// <returns></returns>
        public static bool m_blnCheckInvoIsUsed(string invono)
        {
            clsDcl_Charge objCharge = new clsDcl_Charge();

            return objCharge.m_blnCheckInvoiceNo(invono);
        }
        #endregion

        #region 票据打印
        #region 打印押金单
        /// <summary>
        /// 打印押金单
        /// </summary>
        /// <param name="PrePayID"></param>
        /// <param name="RepNo">重打新号</param>
        public static void m_mthPrintPrepayBill(string PrePayID, string RepNo)
        {
            DataTable dtPrePay;
            clsDcl_PrePay objPrePay = new clsDcl_PrePay();
            long l = objPrePay.m_lngGetPrepayByPrePayID(PrePayID, out dtPrePay);
            if (l > 0 && dtPrePay.Rows.Count == 1)
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();

                dc = new DataColumn("发票电脑号", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("日期", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("发票印刷号", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("姓名", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("住院号", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("支付类型", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("病区名称", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("病区编号", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("小写金额", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("大写金额", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("收款员工号", typeof(string));
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                if (RepNo.Trim() == "")
                {
                    dr["发票电脑号"] = dtPrePay.Rows[0]["PREPAYINV_VCHR"].ToString();
                    dr["住院号"] = "";
                }
                else
                {
                    dr["发票电脑号"] = RepNo;
                    dr["住院号"] = "*REPEAT(" + dtPrePay.Rows[0]["PREPAYINV_VCHR"].ToString() + ")*";
                }
                dr["日期"] = Convert.ToDateTime(dtPrePay.Rows[0]["CREATE_DAT"].ToString()).ToString("yyyy-MM-dd HH:mm:ss");
                dr["发票印刷号"] = dtPrePay.Rows[0]["INPATIENTID_CHR"].ToString();
                dr["姓名"] = dtPrePay.Rows[0]["LASTNAME_VCHR"].ToString();

                string paytype = dtPrePay.Rows[0]["CUYCATE_INT"].ToString();
                if (paytype == "1")
                {
                    paytype = "现金";
                }
                else if (paytype == "2")
                {
                    paytype = "支票";
                }
                else if (paytype == "3")
                {
                    paytype = "银行卡";
                }
                else if (paytype == "4")
                {
                    paytype = "微信2";
                }
                else if (paytype == "5")
                {
                    paytype = "其他";
                }
                else if (paytype == "6")
                {
                    paytype = "支付宝";         // 线下.支付宝
                }
                else if (paytype == "8")
                {
                    paytype = "微信";
                }
                else if (paytype == "9")
                {
                    paytype = "支付宝";         // 线上.支付宝
                }
                else
                {
                    paytype = "现金";
                }
                dr["支付类型"] = paytype;
                dr["病区名称"] = "";
                dr["病区编号"] = "";
                double money = Convert.ToDouble(dtPrePay.Rows[0]["MONEY_DEC"].ToString());
                dr["小写金额"] = "￥" + money.ToString("###,##0.00");
                dr["大写金额"] = clsPublic.DoubleConvertToCurrency(money);
                dr["收款员工号"] = dtPrePay.Rows[0]["EMPNO_CHR"].ToString();

                dt.Rows.Add(dr);
                rptPrepayInvoice rptPrepayInvo = new rptPrepayInvoice();

                try
                {
                    rptPrepayInvo.SetDataSource(dt);
                    rptPrepayInvo.Refresh();
                    rptPrepayInvo.PrintToPrinter(1, false, 0, 0);
                    rptPrepayInvo.Close();
                }
                catch
                {
                    rptPrepayInvo.Close();
                    MessageBox.Show("打印出错,请检查是否安装打印机!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("获取预交金信息失败，打印任务取消。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        #region 打印住院发票
        /// <summary>
        /// 打印住院发票
        /// </summary>
        /// <param name="ChargeNo">结算号</param>
        /// <param name="RepNo">重打号</param>
        public static void m_mthPrintInvoiceBill(string ChargeNo, string RepNo)
        {
            DataTable dtInvoiceMain;
            DataTable dtInvoiceDet;
            DataTable dtPrepay;
            DataTable dtPayMode;
            DataTable dtItemDate;
            clsDcl_Charge objCharge = new clsDcl_Charge();
            long l = objCharge.m_lngGetInvoiceByChargeNo(ChargeNo, out dtInvoiceMain, out dtInvoiceDet, out dtPrepay, out dtPayMode, out dtItemDate);
            if (l > 0)
            {
                DataTable dt = new DataTable();
                DataColumn dc = new DataColumn();

                dc = new DataColumn("住院号", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("病区", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("年", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("月", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("日", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("发票号", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("姓名", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("住院日期", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("结算方式", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("西药", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("中成药", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("中草药", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("床位费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("诊查费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("检查费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("CT", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("MRI", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("X光", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("B超", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("心脑电图", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("护理费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("治疗费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("输血费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("输氧费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("手术费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("检验费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("微信2", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("特需服务费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("人民币大写", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("总额", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("记帐金额", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("个人缴费金额", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("已预收", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("补收", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("退款", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("欠费", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("收费单位", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("审核员", typeof(string));
                dt.Columns.Add(dc);
                dc = new DataColumn("收费员", typeof(string));
                dt.Columns.Add(dc);

                DataRow dr = dt.NewRow();
                dr["住院号"] = dtInvoiceMain.Rows[0]["inpatientid_chr"].ToString();
                dr["病区"] = dtInvoiceMain.Rows[0]["deptname_vchr"].ToString();
                dr["发票号"] = dtInvoiceMain.Rows[0]["invoiceno_vchr"].ToString();

                DateTime invdate = Convert.ToDateTime(dtInvoiceMain.Rows[0]["invdate_dat"].ToString());
                dr["年"] = invdate.Year.ToString();
                dr["月"] = invdate.Month.ToString();
                dr["日"] = invdate.Day.ToString();

                dr["姓名"] = dtInvoiceMain.Rows[0]["lastname_vchr"].ToString();
                dr["住院日期"] = Convert.ToDateTime(dtInvoiceMain.Rows[0]["inpatient_dat"].ToString()).ToString("yyyy-MM-dd");
                dr["结算方式"] = dtInvoiceMain.Rows[0]["paytypename_vchr"].ToString();

                dr["总额"] = dtInvoiceMain.Rows[0]["totalsum_mny"].ToString();
                #region 总额大写转换
                float fTotalmny = Convert.ToSingle(dtInvoiceMain.Rows[0]["totalsum_mny"].ToString());
                long lTotalmny = Decimal.ToInt64(Decimal.Truncate(Decimal.Multiply(new Decimal(fTotalmny), new decimal(100))));

                string space = "   ";
                string ChinaTotalmny = "";

                //十万
                ChinaTotalmny = clsPublic.NumberToChineseNumber(Convert.ToString(lTotalmny / (100000 * 100))) + space;
                //万
                lTotalmny = lTotalmny % (100000 * 100);
                ChinaTotalmny += clsPublic.NumberToChineseNumber(Convert.ToString(lTotalmny / (10000 * 100))) + space;
                //千
                lTotalmny = lTotalmny % (10000 * 100);
                ChinaTotalmny += clsPublic.NumberToChineseNumber(Convert.ToString(lTotalmny / (1000 * 100))) + space;
                //百
                lTotalmny = lTotalmny % (1000 * 100);
                ChinaTotalmny += clsPublic.NumberToChineseNumber(Convert.ToString(lTotalmny / (100 * 100))) + space;
                //十
                lTotalmny = lTotalmny % (100 * 100);
                ChinaTotalmny += clsPublic.NumberToChineseNumber(Convert.ToString(lTotalmny / (10 * 100))) + space;
                //元
                lTotalmny = lTotalmny % (10 * 100);
                ChinaTotalmny += clsPublic.NumberToChineseNumber(Convert.ToString(lTotalmny / (1 * 100))) + space;
                //角
                lTotalmny = lTotalmny % (1 * 100);
                ChinaTotalmny += clsPublic.NumberToChineseNumber(Convert.ToString(lTotalmny / (10))) + space;
                //分
                lTotalmny = lTotalmny % (10);
                ChinaTotalmny += clsPublic.NumberToChineseNumber(Convert.ToString(lTotalmny / (1)));
                #endregion

                dr["人民币大写"] = ChinaTotalmny;
                dr["记帐金额"] = dtInvoiceMain.Rows[0]["acctsum_mny"].ToString();
                dr["个人缴费金额"] = dtInvoiceMain.Rows[0]["sbsum_mny"].ToString();
                dr["收费员"] = dtInvoiceMain.Rows[0]["empno_chr"].ToString();

                dt.Rows.Add(dr);
                rptInChargeInvoice rptChargeInvoice = new rptInChargeInvoice();

                try
                {
                    rptChargeInvoice.SetDataSource(dt);
                    rptChargeInvoice.Refresh();
                    rptChargeInvoice.PrintToPrinter(1, false, 0, 0);
                    rptChargeInvoice.Close();
                }
                catch
                {
                    rptChargeInvoice.Close();
                    MessageBox.Show("打印出错,请检查是否安装打印机!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("获取预交金信息失败，打印任务取消。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
        #endregion

        #region 记录本次查询到的病人信息(入院登记流水号、住院号、诊疗卡号)到LoginFile.XML
        /// <summary>
        /// 记录本次查询到的病人信息(入院登记流水号、住院号、诊疗卡号)到LoginFile.XML
        /// </summary>
        public static void m_mthWriteParm(string RegID, string Zyh, string CardNo)
        {
            clsPublic.m_blnWriteXML("BeInHospital", "CurrRegisterID", "AnyOne", RegID);
            clsPublic.m_blnWriteXML("BeInHospital", "CurrInPatientID", "AnyOne", Zyh);
            clsPublic.m_blnWriteXML("BeInHospital", "CurrCardNo", "AnyOne", CardNo);
        }
        #endregion

        #region 读取前一次记录的病人信息(住院号)
        /// <summary>
        /// 读取前一次记录的病人信息(住院号)
        /// </summary>
        /// <returns></returns>
        public static string m_strReadParmZyh()
        {
            return clsPublic.m_strReadXML("BeInHospital", "CurrInPatientID", "AnyOne");
        }
        #endregion

        #region 读取前一次记录的病人信息(诊疗卡号)
        /// <summary>
        /// 读取前一次记录的病人信息(诊疗卡号)
        /// </summary>
        /// <returns></returns>
        public static string m_strReadParmCardNo()
        {
            return clsPublic.m_strReadXML("BeInHospital", "CurrCardNo", "AnyOne");
        }
        #endregion

        #region 数据窗口DataWindow/DataStore导出
        /// <summary>
        /// 数据窗口DataWindow导出
        /// </summary>
        /// <param name="DW"></param>
        public static void ExportDataWindow(Sybase.DataWindow.DataWindowControl DW)
        {
            SaveFileDialog FD = new SaveFileDialog();
            FD.Filter = "Excel 文档|*.xls";
            FD.Title = "导出";
            FD.ShowDialog();

            if (FD.FileName.Trim() != "")
            {
                DW.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
            }
        }

        /// <summary>
        /// DataStore导出
        /// </summary>
        /// <param name="DS"></param>
        public static void ExportDataStore(Sybase.DataWindow.DataStore DS)
        {
            SaveFileDialog FD = new SaveFileDialog();
            FD.Filter = "Excel 文档|*.xls";
            FD.Title = "导出";
            FD.ShowDialog();

            if (FD.FileName.Trim() != "")
            {
                DS.SaveAs(FD.FileName.Trim(), Sybase.DataWindow.FileSaveAsType.Excel, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
            }
        }
        #endregion

        #region 数据窗口DataWindow/DataStore导出成HTML,再转成EXCEL
        /// <summary>
        /// 数据窗口DataWindow/DataStore导出成HTML,再转成EXCEL
        /// </summary>
        /// <param name="DW"></param>
        /// <param name="volExcel"></param>
        public static void ExportDataWindow(Sybase.DataWindow.DataWindowControl DW, clsVolDatawindowToExcel[] volExcel)
        {
            SaveFileDialog FD = new SaveFileDialog();
            FD.Filter = "Excel 文档|*.xls";
            FD.Title = "导出";
            FD.ShowDialog();
            string filename = FD.FileName.Trim();

            if (filename != "")
            {
                DW.SaveAs(filename, Sybase.DataWindow.FileSaveAsType.HtmlTable, false, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                if (volExcel != null)
                {
                    //定义
                    object MissingValue = Type.Missing;

                    Excel.Application Excel_app = new Excel.ApplicationClass();
                    //打开Excel文挡
                    Excel.Workbook Excel_work = Excel_app.Workbooks.Open(filename, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue);
                    //获取当前工作列表
                    Excel.Worksheet mySheet = (Excel.Worksheet)Excel_work.Worksheets[1];

                    for (int i = volExcel.Length - 1; i >= 0; i--)
                    {
                        Excel.Range range = null;
                        range = (Excel.Range)mySheet.Rows.get_Item(1, Type.Missing);
                        //在顶行插入空行
                        range.Rows.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                        for (int j = 0; j < volExcel[i].m_title_text.Length; j++)
                        {
                            //合并行
                            if (volExcel[i].m_endcommn[j] == "ALL")
                            {
                                range = mySheet.get_Range(volExcel[i].m_firstcommn[j], mySheet.Cells[1, mySheet.UsedRange.Columns.Count]);
                            }
                            else
                            {
                                range = mySheet.get_Range(volExcel[i].m_firstcommn[j], volExcel[i].m_endcommn[j]);
                            }
                            range.Merge(MissingValue);

                            range.Value2 = volExcel[i].m_title_text[j];
                            if (volExcel[i].m_HorizontalAlignment[j] == "0")
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            }
                            else if (volExcel[i].m_HorizontalAlignment[j] == "L")
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            }
                            else
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            }
                            range.RowHeight = volExcel[i].m_rowheight[j];
                        }

                    }

                    mySheet.UsedRange.Rows.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    mySheet = null;
                    Excel_app.ActiveWorkbook.Close(true, filename.ToString(), null);
                    Excel_app.Workbooks.Close();
                    Excel_app.Quit();
                    Excel_app = null;
                }
            }
        }
        /// <summary>
        /// 数据窗口DataWindow/DataStore导出成HTML,再转成EXCEL
        /// </summary>
        /// <param name="DS"></param>
        /// <param name="volExcel"></param>
        public static void ExportDataStore(Sybase.DataWindow.DataStore DS, clsVolDatawindowToExcel[] volExcel)
        {
            SaveFileDialog FD = new SaveFileDialog();
            FD.Filter = "Excel 文档|*.xls";
            FD.Title = "导出";
            FD.ShowDialog();
            string filename = FD.FileName.Trim();

            if (filename != "")
            {
                DS.SaveAs(filename, Sybase.DataWindow.FileSaveAsType.HtmlTable, true, Sybase.DataWindow.FileSaveAsEncoding.Utf8);
                if (volExcel != null)
                {

                    //定义
                    object MissingValue = Type.Missing;
                    Excel.Application Excel_app = new Excel.ApplicationClass();

                    //打开Excel文挡
                    Excel.Workbook Excel_work = Excel_app.Workbooks.Open(filename, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue, MissingValue, MissingValue,
                     MissingValue);
                    //获取当前工作列表
                    Excel.Worksheet mySheet = (Excel.Worksheet)Excel_work.Worksheets[1];

                    for (int i = volExcel.Length - 1; i >= 0; i--)
                    {
                        Excel.Range range = null;
                        range = (Excel.Range)mySheet.Rows.get_Item(1, Type.Missing);
                        //在顶行插入空行
                        range.Rows.Insert(Excel.XlInsertShiftDirection.xlShiftDown, Type.Missing);
                        for (int j = 0; j < volExcel[i].m_title_text.Length; j++)
                        {
                            //合并行
                            if (volExcel[i].m_endcommn[j] == "ALL")
                            {
                                range = mySheet.get_Range(volExcel[i].m_firstcommn[j], mySheet.Cells[1, mySheet.UsedRange.Columns.Count]);
                            }
                            else
                            {
                                range = mySheet.get_Range(volExcel[i].m_firstcommn[j], volExcel[i].m_endcommn[j]);
                            }
                            range.Merge(MissingValue);

                            range.Value2 = volExcel[i].m_title_text[j];
                            if (volExcel[i].m_HorizontalAlignment[j] == "0")
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            }
                            else if (volExcel[i].m_HorizontalAlignment[j] == "L")
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                            }
                            else
                            {
                                range.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                            }
                            range.RowHeight = volExcel[i].m_rowheight[j];
                        }

                    }

                    mySheet.UsedRange.Rows.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    mySheet = null;
                    Excel_app.ActiveWorkbook.Close(true, filename.ToString(), null);
                    Excel_app.Workbooks.Close();
                    Excel_app.Quit();
                    Excel_app = null;
                }
            }
        }
        #endregion

        #region 数据窗口DataWindow/DataStore预览打印
        /// <summary>
        /// DataWindow预览打印
        /// </summary>
        /// <param name="DW"></param>
        public static void PrintDialog(Sybase.DataWindow.DataWindowControl DW)
        {
            frmPrintDialog PrintDialog = new frmPrintDialog(DW);
            PrintDialog.ShowDialog();
        }
        /// <summary>
        /// DataStore预览打印
        /// </summary>
        /// <param name="DS"></param>
        public static void PrintDialog(Sybase.DataWindow.DataStore DS)
        {
            frmPrintDialog PrintDialog = new frmPrintDialog(DS);
            PrintDialog.ShowDialog();
        }
        /// <summary>
        /// 指定类型的DataStore预览打印
        /// </summary>
        /// <param name="DS"></param>
        public static void PrintDialog(Sybase.DataWindow.DataStore DS, string strType, DataTable p_dtPutMed, string p_strEmpID)
        {
            frmPrintDialog PrintDialog = new frmPrintDialog(DS, strType, p_dtPutMed, p_strEmpID);
            PrintDialog.ShowDialog();
        }
        #endregion

        #region 数据窗口中普通字符串转换为换行字符串
        /// <summary>
        /// 数据窗口中普通字符串转换为换行字符串
        /// </summary>
        /// <param name="str">普通字符串</param>        
        /// <param name="len">一行字符数</param>
        /// <param name="newstr">换行字符串</param>
        public static void m_mthConvertNewLineStrLbl(string str, int len, ref string newstr)
        {
            if (str.Length <= len)
            {
                newstr += str;
            }
            else
            {
                newstr += str.Substring(0, len) + "~r~n";
                m_mthConvertNewLineStrLbl(str.Substring(len), len, ref newstr);
            }
        }

        /// <summary>
        /// 数据窗口中普通字符串转换为换行字符串
        /// </summary>
        /// <param name="str">普通字符串</param>        
        /// <param name="len">一行字符数</param>
        /// <param name="newstr">换行字符串</param>
        public static void m_mthConvertNewLineStrCol(string str, int len, ref string newstr)
        {
            if (str.Length <= len)
            {
                newstr += str;
            }
            else
            {
                newstr += str.Substring(0, len) + " ";
                m_mthConvertNewLineStrCol(str.Substring(len), len, ref newstr);
            }
        }
        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="parmcode">参数代码</param>
        /// <returns>值</returns>        
        public static string m_strGetSysparm(string parmcode)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            string s = objSvc.m_strGetSysparm(parmcode);
            objSvc.Dispose();

            return s;
        }
        #endregion

        #region 获取住院医保病人身份ID
        /// <summary>
        /// 获取住院医保病人身份ID
        /// </summary>
        /// <returns></returns>
        public static ArrayList m_mthGetYBPayID()
        {
            return clsPublic.m_ArrGettoken(clsPublic.m_strGetSysparm("0008"), ";");
        }
        #endregion

        #region 选择打印机打印
        /// <summary>
        /// 选择打印机打印
        /// </summary>
        /// <param name="DW">数据窗口</param>
        /// <param name="ShowPrintDialog">显示放弃打印窗口</param>
        public static void ChoosePrintDialog(Sybase.DataWindow.DataWindowControl DW, bool ShowCancelDialog)
        {
            PrintDialog pDiag = new PrintDialog();
            pDiag.UseEXDialog = true;
            pDiag.AllowSomePages = true;
            if (pDiag.ShowDialog() == DialogResult.OK)
            {
                DW.PrintProperties.PrinterName = pDiag.PrinterSettings.PrinterName;

                if (pDiag.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.SomePages)
                {
                    DW.PrintProperties.PageRange = pDiag.PrinterSettings.FromPage.ToString() + "-" + pDiag.PrinterSettings.ToPage.ToString();
                }

                DW.Print(ShowCancelDialog);
            }
            pDiag = null;
        }

        /// <summary>
        /// 选择打印机打印
        /// </summary>
        /// <param name="DS">数据存储</param>
        /// <param name="ShowCancelDialog">显示放弃打印窗口</param>
        public static void ChoosePrintDialog(Sybase.DataWindow.DataStore DS, bool ShowCancelDialog)
        {
            PrintDialog pDiag = new PrintDialog();
            pDiag.UseEXDialog = true;
            pDiag.AllowSomePages = true;
            if (pDiag.ShowDialog() == DialogResult.OK)
            {
                DS.PrintProperties.PrinterName = pDiag.PrinterSettings.PrinterName;

                if (pDiag.PrinterSettings.PrintRange == System.Drawing.Printing.PrintRange.SomePages)
                {
                    DS.PrintProperties.PageRange = pDiag.PrinterSettings.FromPage.ToString() + "-" + pDiag.PrinterSettings.ToPage.ToString();
                }

                DS.Print(ShowCancelDialog);
            }
            pDiag = null;
        }
        #endregion

        #region 设置快捷信息
        /// <summary>
        /// 设置快捷信息
        /// </summary>
        /// <param name="frmMdi"></param>
        /// <param name="Index"></param>
        /// <param name="Info"></param>
        public static void SetShortCutInfo(Form frmMdi, int Index, string Info)
        {
            StatusBar objInfoBar = new StatusBar();
            foreach (Control c in frmMdi.Controls)
            {
                if (c is StatusBar)
                {
                    objInfoBar = c as StatusBar;
                    break;
                }
            }

            if (objInfoBar != null)
            {
                objInfoBar.Panels[Index].Text = Info;
                objInfoBar.Panels[Index].ToolTipText = "";
            }
        }
        #endregion

        #region 获取连接ICARE库参数
        /// <summary>
        /// 获取连接ICARE库参数
        /// </summary>
        /// <param name="ServerName"></param>
        /// <param name="UserID"></param>
        /// <param name="Pwd"></param>
        public static void m_mthGetICareParm(out string ServerName, out string UserID, out string Pwd)
        {
            ServerName = "ICARE";
            UserID = "";
            Pwd = "";

            try
            {
                UserID = clsTextTool.s_strReadSecurityString("", "bytICare", "userid", com.digitalwave.iCare.middletier.CryptographyLib.clsSymmetricAlgorithm.enmSecurityStringType.ORACLE);
                com.digitalwave.iCare.middletier.CryptographyLib.clsSymmetricAlgorithm symmetricAlgorithm = new com.digitalwave.iCare.middletier.CryptographyLib.clsSymmetricAlgorithm();
                com.digitalwave.iCare.middletier.CryptographyLib.clsSymmetricAlgorithm.enmSymmetricAlgorithmType symmetricAlgorithmType = com.digitalwave.iCare.middletier.CryptographyLib.clsSymmetricAlgorithm.enmSymmetricAlgorithmType.RIJNDAEL;
                symmetricAlgorithm.m_strKey = "daXPc0JKOKOElQOBJRBV9Y81qE8qB3ceXNeynhFOc3c=";
                string password = clsTextTool.s_strReadSecurityString("", "bytICare", "password", com.digitalwave.iCare.middletier.CryptographyLib.clsSymmetricAlgorithm.enmSecurityStringType.ORACLE);
                Pwd = symmetricAlgorithm.m_strDecrypt(password, symmetricAlgorithmType);
            }
            catch
            {
                UserID = "ICARE";
                Pwd = "ICARE";
            }

            #region 旧
            //string tmpfs = clsPublic.XMLFile;
            //clsPublic.XMLFile = Application.StartupPath + @"\HISYB.xml";

            //if (clsPublic.m_strReadXML("ICARE", "ORAServerName", "AnyOne") != "")
            //{
            //    ServerName = clsPublic.m_strReadXML("ICARE", "ORAServerName", "AnyOne");
            //}
            //if (clsPublic.m_strReadXML("ICARE", "ORAUserID", "AnyOne") != "")
            //{
            //    UserID = clsPublic.m_strReadXML("ICARE", "ORAUserID", "AnyOne");
            //}
            //if (clsPublic.m_strReadXML("ICARE", "ORAPassWord", "AnyOne") != "")
            //{
            //    Pwd = clsPublic.m_strReadXML("ICARE", "ORAPassWord", "AnyOne");
            //}

            //clsPublic.XMLFile = tmpfs;
            #endregion
        }
        #endregion

        #region 收取连续性费用
        /// <summary>
        /// 收取连续性费用
        /// </summary>
        /// <param name="RegisterID">病人入院登记ID</param>
        /// <param name="EmpID">当前操作员ID</param>
        /// <returns>成功 true 失败 false</returns>
        public static bool m_blnChargeContinueItem(string RegisterID, string EmpID)
        {
            bool ret = false;
            clsDcl_Charge objCharge = new clsDcl_Charge();
            long l = objCharge.AutoChargeContinueItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), EmpID, RegisterID);
            if (l > 0)
            {
                ret = true;
            }
            return ret;
        }
        #endregion

        #region 输出数据源
        /// <summary>
        /// 输出数据源
        /// </summary>
        /// <param name="LogTitle">LOG标题</param>
        /// <param name="SQLExpression">SQL表达式</param>
        public static void WriteSQLLog(string LogTitle, string SQLExpression)
        {
            clsLogText log = new clsLogText();
            log.Log2File(@"d:\code\log.txt", "/******" + LogTitle + "******/ \r\n " + SQLExpression);
            log = null;
        }
        #endregion

        #region 11卡号特殊处理
        /// <summary>
        /// 11卡号特殊处理
        /// </summary>
        /// <param name="HospitalName">医院名称</param>
        /// <param name="objTxt">卡号编辑框</param>
        /// <param name="Flag">标志</param>
        public static void CardNo11Init(string HospitalName, System.Windows.Forms.TextBox objTxt, ref bool Flag)
        {
            if (HospitalName.Contains("茶山"))
            {
                objTxt.MaxLength = 11;
                Flag = true;
            }
            else
            {
                //objTxt.MaxLength = 10;
                Flag = true;
            }
        }

        /// <summary>
        /// 11卡号特殊处理
        /// </summary>
        /// <param name="HospitalName">医院名称</param>
        /// <param name="objTxt">卡号编辑框</param>
        /// <param name="Flag">标志</param>
        public static void CardNo11Init(string HospitalName, SourceLibrary.Windows.Forms.TextBoxTyped objTxt, ref bool Flag)
        {
            if (HospitalName.Contains("茶山"))
            {
                objTxt.MaxLength = 11;
                Flag = true;
            }
            else
            {
                //objTxt.MaxLength = 10;
                Flag = true;
            }
        }

        /// <summary>
        /// 获取卡号
        /// </summary>
        /// <param name="Val"></param>
        public static string CardNo11Value(string Val)
        {
            if (Val.Trim().Length > 10)
            {
                Val = Val.Trim().Substring(1, 10);
            }

            return Val;
        }
        #endregion

        #region 检查时间范围
        /// <summary>
        /// 检查时间范围: 主要用于检查查询时间段
        /// </summary>
        /// <param name="Days">限制天数</param>
        /// <param name="BeginDate">开始日期</param>
        /// <param name="EndDate">结束日期</param>
        /// <returns>true 在范围内 false 不在范围内</returns>
        public static bool m_blnCheckDateRange(string Days, string BeginDate, string EndDate)
        {
            bool b = true;

            Days = Days.Trim();

            int pos = Days.IndexOf("★");

            if (pos >= 0)
            {
                Days = Days.Remove(0, pos + 1);
                if (Days != "" && Microsoft.VisualBasic.Information.IsNumeric(Days))
                {
                    TimeSpan ts = Convert.ToDateTime(EndDate).Subtract(Convert.ToDateTime(BeginDate));

                    if (ts.Days > Convert.ToInt32(Days))
                    {
                        b = false;
                        MessageBox.Show("时间段超出了允许的范围。(系统当前允许的天数为: " + Days + "天内)", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

            return b;
        }
        #endregion

        #region 转换为单引号字符
        /// <summary>
        /// 转换为单引号字符
        /// </summary>
        /// <param name="OrgStr">原始字符串</param>
        /// <param name="Sign">分隔符</param>
        /// <returns></returns>
        public static string m_strConvertSingleQuoteMark(string OrgStr, string Sign)
        {
            string s = "";

            if (OrgStr.Trim() == "")
            {
                return s;
            }
            else
            {
                ArrayList ar = clsPublic.m_ArrGettoken(OrgStr, Sign);

                if (ar.Count > 0)
                {
                    for (int i = 0; i < ar.Count; i++)
                    {
                        s += "'" + ar[i].ToString() + "'" + Sign;
                    }

                    return s.Substring(0, s.Length - 1);
                }
            }

            return s;
        }
        #endregion

        #region 生成新发票号
        /// <summary>
        /// 生成新发票号
        /// </summary>        
        public static string m_strNextInvoiceNo(string InvoNo)
        {
            try
            {
                int maxint = Convert.ToInt32(InvoNo.Substring(2, 8)) + 1;
                InvoNo = InvoNo.Substring(0, 2) + maxint.ToString("00000000");
            }
            catch
            {
                InvoNo = "AA00000000";
            }

            return InvoNo;
        }

        #endregion

        #region 将DATATABLE导出成EXCEL
        /// <summary>
        /// 将DATATABLE导出成EXCEL
        /// </summary>
        /// <param name="DGV"></param>
        public static void m_mthDataTableExportToExcel(DataGridView DGV)
        {
            DataTable dtExport = new DataTable("dtExoprt");

            string strColName = "";
            for (int i = 0; i < DGV.Columns.Count; i++)
            {
                if (DGV.Columns[i].Visible == false)
                {
                    continue;
                }

                strColName = DGV.Columns[i].HeaderText.Replace("(", "").Replace(")", "").Trim();

                if (DGV.Columns[i].ValueType.FullName.ToLower() == "system.numeric" || DGV.Columns[i].ValueType.FullName.ToLower() == "system.decimal")
                {
                    dtExport.Columns.Add(strColName, typeof(decimal));
                }
                else
                {
                    dtExport.Columns.Add(strColName, typeof(string));
                }
            }

            DataRow dr;
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                dr = dtExport.NewRow();

                int row = 0;
                for (int j = 0; j < DGV.Columns.Count; j++)
                {
                    if (DGV.Columns[j].Visible == false)
                    {
                        continue;
                    }

                    dr[row] = DGV.Rows[i].Cells[j].Value;
                    row++;
                }

                dtExport.Rows.Add(dr);
            }

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add(dtExport);
            com.digitalwave.iCare.common.ExcelExporter excel = new com.digitalwave.iCare.common.ExcelExporter(dsExport);
            bool b = excel.m_mthExport();
            if (b)
            {
                MessageBox.Show("导出Excel成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("导出Excel失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            dtExport.Dispose();
            dsExport.Tables.Clear();
            dsExport.Dispose();
        }
        #endregion

        #region 通用审核窗
        /// <summary>
        /// 通用审核窗
        /// </summary>
        /// <param name="EmpID">出参：审核人ID</param> 
        /// <returns></returns>
        public static DialogResult m_dlgConfirm(out string EmpID)
        {
            EmpID = "";

            frmAuditing f = new frmAuditing();
            if (f.ShowDialog() == DialogResult.OK)
            {
                EmpID = f.EmpID;
                return DialogResult.Yes;
            }

            return DialogResult.No;
        }
        /// <summary>
        /// 通用审核窗
        /// </summary>
        /// <param name="EmpNo">入参：审核人工号</param>
        /// <param name="EmpID">出参：审核人ID</param> 
        /// <returns></returns>
        public static DialogResult m_dlgConfirm(string EmpNo, out string EmpID)
        {
            EmpID = "";

            frmAuditing f = new frmAuditing(EmpNo);
            if (f.ShowDialog() == DialogResult.OK)
            {
                EmpID = f.EmpID;
                return DialogResult.Yes;
            }

            return DialogResult.No;
        }
        /// <summary>
        /// 通用审核窗
        /// </summary>
        /// <param name="EmpID">出参：审核人ID</param>
        /// <param name="EmpName">出参：审核人姓名</param>
        /// <returns></returns>
        public static DialogResult m_dlgConfirm(out string EmpID, out string EmpName)
        {
            EmpID = "";
            EmpName = "";

            frmAuditing f = new frmAuditing();
            if (f.ShowDialog() == DialogResult.OK)
            {
                EmpID = f.EmpID;
                EmpName = f.EmpName;
                return DialogResult.Yes;
            }

            return DialogResult.No;
        }
        /// <summary>
        /// 通用审核窗
        /// </summary>
        /// <param name="EmpNo">入参：审核人工号</param>
        /// <param name="EmpID">出参：审核人ID</param>
        /// <param name="EmpName">出参：审核人姓名</param>
        /// <returns></returns>
        public static DialogResult m_dlgConfirm(string EmpNo, out string EmpID, out string EmpName)
        {
            EmpID = "";
            EmpName = "";

            frmAuditing f = new frmAuditing(EmpNo);
            f.txtEmpNo.Text = EmpNo;
            if (f.ShowDialog() == DialogResult.OK)
            {
                EmpID = f.EmpID;
                EmpName = f.EmpName;
                return DialogResult.Yes;
            }

            return DialogResult.No;
        }

        public static DialogResult m_dlgConfimByDefault(string EmpNo)
        {
            frmAuditing f = new frmAuditing(EmpNo, 2);
            if (f.ShowDialog() == DialogResult.OK)
            {
                return DialogResult.Yes;
            }
            return DialogResult.No;
        }
        
        #endregion

        #region 出生年月转年龄(汉字符终止)
        /// <summary>
        /// 出生年月转年龄(汉字符终止)
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string m_mthGetAge(string strInput)
        {
            string strAge = "";
            try
            {
                strAge = new clsBrithdayToAge().m_strGetAge(strInput);
                System.Text.ASCIIEncoding objAscii = new System.Text.ASCIIEncoding();
                byte[] s = objAscii.GetBytes(strAge);
                for (int i1 = 0; i1 < s.Length; i1++)
                {
                    if ((int)s[i1] == 63)
                    {
                        strAge = strAge.Substring(0, i1) + " " + strAge.Substring(i1, 1);
                        break;
                    }
                }
            }
            catch (Exception)
            { }
            
            return strAge;
        }
        #endregion

        #region 获取系统参数INT值
        /// <summary>
        /// 获取系统参数INT值
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="ParmCode"></param>
        /// <returns></returns>
        public static int m_intConvertParm(Hashtable hasValue, string ParmCode)
        {
            int intValue = -999;
            try
            {
                if (hasValue.Contains(ParmCode))
                {
                    intValue = int.Parse(hasValue[ParmCode].ToString());
                }
            }
            catch
            {
                MessageBox.Show("请创建参数： 代号 " + ParmCode, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return intValue;
        }
        #endregion

        #region 获取系统参数STRING值
        /// <summary>
        /// 获取系统参数STRING值
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="ParmCode"></param>
        /// <returns></returns>
        public static string m_strConvertParm(Hashtable hasValue, string ParmCode)
        {
            String strValue = "";
            try
            {
                if (hasValue.Contains(ParmCode))
                {
                    strValue = hasValue[ParmCode].ToString().Trim();
                }
            }
            catch
            {
                MessageBox.Show("请创建参数： 代号 " + ParmCode, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return strValue;
        }
        #endregion

        #region 获取系统参数BOOL值
        /// <summary>
        /// 获取系统参数BOOL值
        /// </summary>
        /// <param name="hasValue"></param>
        /// <param name="ParmCode"></param>
        /// <returns></returns>
        public static bool m_blnConvertParm(Hashtable hasValue, string ParmCode)
        {
            bool blnValue = false;
            try
            {
                if (hasValue.Contains(ParmCode))
                {
                    blnValue = hasValue[ParmCode].ToString().Trim() == "1";
                }
            }
            catch
            {
                MessageBox.Show("请创建参数： 代号 " + ParmCode, "系统信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return blnValue;
        }
        #endregion

        #region 获取系统参数
        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="setidarr">参数编号数组</param>
        /// <returns></returns>
        public static Hashtable m_hasGetSysSetting(ArrayList setidarr)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                             (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            Hashtable has = objSvc.m_hasGetSysSetting(setidarr);
            objSvc.Dispose();

            return has;
        }

        /// <summary>
        /// 获取系统参数
        /// </summary>
        /// <param name="parmcodearr">参数代码数组</param>
        /// <returns></returns>
        public static Hashtable m_hasGetSysParm(ArrayList parmcodearr)
        {
            com.digitalwave.iCare.middletier.HIS.clsCharge objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            Hashtable has = objSvc.m_hasGetSysParm(parmcodearr);
            objSvc.Dispose();

            return has;
        }
        #endregion

        #region 查询此病人是否用门诊处方未结费用(前提要到关联界面关联病人的门诊处方费用到住院中间表)
        /// <summary>
        ///  查询此病人是否用门诊处方未结费用(前提要到关联界面关联病人的门诊处方费用到住院中间表)
        /// </summary>
        /// <param name="p_strRegisterId">病人住院登记号</param>
        /// <param name="p_strMessage">返回病人未交费的处方号</param>
        /// <returns></returns>
        public static long m_lngSelectPatientNoPayRecipe(string p_strRegisterId, out string p_strMessage)
        {
            long lngRes = 0;
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery objSvc =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));

            lngRes = objSvc.m_lngSelectPatientNoPayRecipe(p_strRegisterId, out p_strMessage);
            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }

        #endregion
    }
    #endregion

    #region ListView比较排序类
    /// <summary>
    /// ListView比较排序类
    /// </summary>
    public class ListViewItemSort : IComparer
    {
        #region 变量
        /// <summary>
        /// 列号
        /// </summary>
        private int col = 0;

        /// <summary>
        /// 排序类型
        /// </summary>
        private SortOrder sort;
        #endregion

        #region ListView排序类
        /// <summary>
        /// ListView排序类
        /// </summary>
        /// <param name="column"></param>
        /// <param name="order"></param>
        /// <param name="lv"></param>
        public ListViewItemSort(int column, SortOrder order, ListView lv)
        {
            col = column;
            sort = order;

            string coltext = "";
            for (int i = 0; i < lv.Columns.Count; i++)
            {
                coltext = lv.Columns[i].Text;
                coltext = coltext.Replace("▲", "");
                coltext = coltext.Replace("▼", "");
                lv.Columns[i].Text = coltext;
            }

            if (order == SortOrder.Ascending)
            {
                lv.Columns[col].Text = lv.Columns[col].Text + "▲";
            }
            else if (order == SortOrder.Descending)
            {
                lv.Columns[col].Text = lv.Columns[col].Text + "▼";
            }
        }
        #endregion

        #region 比较函数
        /// <summary>
        /// 比较函数
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public int Compare(object x, object y)
        {
            int ret = 0;
            string coltext1 = ((ListViewItem)x).SubItems[col].Text;
            string coltext2 = ((ListViewItem)y).SubItems[col].Text;

            try
            {
                if (coltext1.IndexOf(".") >= 0 || coltext2.IndexOf(".") >= 0)
                {
                    ret = (Convert.ToDouble(coltext1) > Convert.ToDouble(coltext2) ? 1 : -1);
                }
                else
                {
                    ret = (Convert.ToInt32(coltext1) > Convert.ToInt32(coltext2) ? 1 : -1);
                }
            }
            catch
            {
                ret = String.Compare(coltext1, coltext2);	//转换有错,说明比较的两者类型不同.
            }

            if (sort != SortOrder.Ascending)
            {
                ret = -ret;
            }

            return ret;
        }
        #endregion
    }
    #endregion

    #region 分类VO
    /// <summary>
    /// 核算分类VO
    /// </summary>
    [Serializable]
    public class clsCheckCat_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 核算分类ID
        /// </summary>
        public string CatID = "";
        /// <summary>
        /// 核算分类名称
        /// </summary>
        public string CatName = "";
        /// <summary>
        /// 核算分类金额
        /// </summary>
        public decimal CatSum = 0;
    }

    /// <summary>
    /// 发票分类VO
    /// </summary>
    [Serializable]
    public class clsInvoiceCat_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 发票分类ID
        /// </summary>
        public string CatID = "";
        /// <summary>
        /// 发票分类名称
        /// </summary>
        public string CatName = "";
        /// <summary>
        /// 发票分类金额
        /// </summary>
        public decimal CatSum = 0;
    }
    #endregion

    #region 收费项目参数VO
    /// <summary>
    /// 收费项目参数VO
    /// </summary>
    [Serializable]
    public class clsParmItem_VO : com.digitalwave.iCare.ValueObject.clsICARE_BaseVO
    {
        /// <summary>
        /// 项目ID
        /// </summary>
        public string ItemID = "";
        /// <summary>
        /// 项目CODE
        /// </summary>
        public string ItemCode = "";
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ItemName = "";
        /// <summary>
        /// 数量
        /// </summary>
        public decimal ItemAmout = 0;
        /// <summary>
        /// 科室(病区)ID
        /// </summary>
        public string DeptID = "";
        /// <summary>
        /// 科室(病区)名称
        /// </summary>
        public string DeptName = "";
        /// <summary>
        /// 是否允许录入负数(数量)
        /// </summary>
        public bool AllowNegative = true;

        /// <summary>
        /// 挂号标志： 0 全部 1 已挂号 2 未挂号
        /// </summary>
        public string RegFlag = "";
        /// <summary>
        /// 处方标志： 0 全部 1 正方 2 副方
        /// </summary>
        public string RecFlag = "";
        /// <summary>
        /// 职称ID:  00 全部 ...
        /// </summary>
        public string DutyName = "";
        /// <summary>
        /// (每日)开始时间
        /// </summary>
        public string BeginTime = "00:00";
        /// <summary>
        /// (每日)结束时间
        /// </summary>
        public string EndTime = "23:59";
    }
    #endregion
}
