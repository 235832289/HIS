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

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 预缴金逻辑控制类
    /// </summary>
    public class clsCtl_PrePay : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_PrePay objSvc;
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmPrePay m_objViewer;
        /// <summary>
        /// 预交类型: 0 正常 1 手工
        /// </summary>
        internal string PreType = "0";
        /// <summary>
        /// 预交金收据号
        /// </summary>
        internal string PrepayBillNo = "";

        /// <summary>
        /// 正常预交是否打印收据
        /// </summary>
        private bool NorPrint = false;
        /// <summary>
        /// 手工预交是否打印收据
        /// </summary>
        private bool HandPrint = false;
        #endregion 

        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_PrePay()
        {
            objSvc = new clsDcl_PrePay();
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
            m_objViewer = (frmPrePay)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        public void m_mthInit()
        {            
            if (PreType == "0")
            {
                this.m_objViewer.lblpretype.Text = "正常预交";

                this.m_mthGetPrePayBillNo();//佛二需求，不作判断
                this.m_objViewer.lblInfo.Visible = true;
            }
            else if (PreType == "1")
            {
                this.m_objViewer.lblpretype.Text = "手工预交";

                this.m_objViewer.txtprebillno.Text = "";
                this.m_objViewer.lblInfo.Visible = false;
            }

            this.m_objViewer.txtMoney.Text = "";
            this.m_objViewer.cbopaytype.Text = "";
            this.m_objViewer.cbopaytype.SelectedIndex = -1;
            this.m_objViewer.txtnote.Text = "";

            this.m_objViewer.txtprebillno.Focus();
            this.m_objViewer.txtprebillno.SelectAll();
        }
        #endregion

        #region 获取打印设置
        /// <summary>
        /// 获取打印设置
        /// </summary>
        public void m_mthGetPrintParm()
        {
            NorPrint = clsPublic.m_intGetSysParm("1011") == 1 ? true : false;
            HandPrint = clsPublic.m_intGetSysParm("1012") == 1 ? true : false;
        }
        #endregion

        #region 获取预交金收据号
        /// <summary>
        /// 获取预交金收据号
        /// </summary>
        /// <returns></returns>
        public void m_mthGetPrePayBillNo()
        {
            PrepayBillNo = clsPublic.m_strGetCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, 2);
            if (PrepayBillNo == "")
            {
                return;
            }

            if (clsPublic.m_blnCheckPrepayNoExpression(PrepayBillNo))
            {
                //if (!clsPublic.m_blnCheckPrepayNoIsUsed(PrepayBillNo, int.Parse(PreType)))
                if (!clsPublic.m_blnCheckPrepayNoIsUsed(PrepayBillNo, 0))
                {
                    this.m_objViewer.txtprebillno.Text = PrepayBillNo;
                }
                else
                {
                    MessageBox.Show("当前预交金收据的编号已被使用，请输入新号(与当前打印票据号相同)。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);                   
                }
            }
            else
            {
                MessageBox.Show("当前预交金收据的编号规则不正确，请仔细检查。", "警告", MessageBoxButtons.OK, MessageBoxIcon.Information);               
            }            
        }
        #endregion              

        #region 保存预交金收据号
        /// <summary>
        /// 保存预交金收据号
        /// </summary>
        /// <param name="CurrNo"></param>
        /// <returns></returns>
        public bool m_blnSavePrePayBillNo(string CurrNo)
        {
            return clsPublic.m_blnWriteXML("BeInHospital", "CurrPrepayBillNo", "AnyOne", CurrNo);
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
                //this.m_objViewer.ucPatientInfo.m_mthShortCurFind();
                this.m_objViewer.ucPatientInfo.m_mthFind(f.RegisterID, 3);
                if (this.m_objViewer.ucPatientInfo.IsChanged)
                {
                    this.m_mthGetPrePayHistoryInfo();
                }
            }
            else
            {
                if (this.m_objViewer.InitFlag)
                {
                    this.m_objViewer.DirClose = true;
                }
                else
                {
                    if (this.m_objViewer != null)
                    {
                        this.m_objViewer.Close();
                    }
                }
            }
        }
        #endregion

        #region 显示
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="zyh"></param>
        public void m_mthShow(string zyh)
        {
            this.m_objViewer.ucPatientInfo.m_mthFind(zyh, 2);
            if (this.m_objViewer.ucPatientInfo.IsChanged)
            {
                this.m_mthGetPrePayHistoryInfo();
                this.m_mthInit();
            }
        }
        #endregion

        #region 切换预交类型
        /// <summary>
        /// 切换预交类型
        /// </summary>
        public void m_mthSwitch()
        {
            if (MessageBox.Show("当前为【" + this.m_objViewer.lblpretype.Text + "】状态，是否继续切换？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                return;
            }

            PreType = (PreType == "0" ? "1" : "0");
            this.m_mthInit();
        }
        #endregion

        #region 获取历史预交金信息
        /// <summary>
        /// 获取历史预交金信息
        /// </summary>
        public void m_mthGetPrePayHistoryInfo()
        {
            if (this.m_objViewer.ucPatientInfo.RegisterID == "")
            {
                return;
            }

            this.m_objViewer.dtgHistory.Rows.Clear();

            string RegID = this.m_objViewer.ucPatientInfo.RegisterID;
            
            DataTable dt ;
            long l = this.objSvc.m_lngGetPrepayByRegID(RegID, 1, out dt);
            if (l > 0 && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string[] s = new string[12];                                      

                    s[0] = Convert.ToString(i+1);
                    s[1] = dt.Rows[i]["prepayinv_vchr"].ToString();

                    string cuycate = dt.Rows[i]["cuycate_int"].ToString();
                    if (cuycate == "1")
                    {
                        cuycate = "现金";
                    }
                    else if (cuycate == "2")
                    {
                        cuycate = "支票";
                    }
                    else if (cuycate == "3")
                    {
                        cuycate = "银行卡";
                    }
                    else if (cuycate == "4")
                    {
                        cuycate = "其他";
                    }
                    else
                    {
                        cuycate = "现金";
                    }
                    s[2] = cuycate;

                    s[3] = clsPublic.ConvertObjToDecimal(dt.Rows[i]["money_dec"]).ToString("0.00");

                    Color FCR = Color.Black;
                    string status = dt.Rows[i]["paytype_int"].ToString();
                    if (status == "1")
                    {
                        status = "正常";
                    }
                    else if (status == "2")
                    {
                        status = "退款";
                        FCR = Color.Red;
                    }
                    else if (status == "3")
                    {
                        status = "恢复";
                        FCR = Color.FromArgb(0, 138, 89);
                    }
                    else if (status == "4")
                    {
                        status = "冲单";
                        FCR = Color.Firebrick;
                    }
                    s[4] = status;

                    s[5] = dt.Rows[i]["lastname_vchr"].ToString();
                    s[6] = Convert.ToDateTime(dt.Rows[i]["create_dat"].ToString()).ToString("yyyy/MM/dd HH:mm:ss");

                    string uptype = dt.Rows[i]["uptype_int"].ToString();
                    if (uptype == "0")
                    {
                        uptype = "正常";
                    }
                    else if (uptype == "1")
                    {
                        uptype = "手工";
                    }
                    s[7] = uptype;

                    int isrec = Convert.ToInt32(dt.Rows[i]["balanceflag_int"].ToString());
                    s[8] = (isrec == 1 ? "是" : "否");

                    int isclear = Convert.ToInt32(dt.Rows[i]["isclear_int"].ToString());
                    s[9] = (isclear == 1 ? "已清" : "未清");

                    s[10] = dt.Rows[i]["confirmemp"].ToString();
                    s[11] = dt.Rows[i]["des_vchr"].ToString();
                    if (dt.Rows[i]["originvono_vchr"].ToString().Trim() != "")
                    {
                        s[11] = "原始单号: " + dt.Rows[i]["originvono_vchr"].ToString().Trim() + "  " + s[11];
                    }
                    
                    int row = this.m_objViewer.dtgHistory.Rows.Add(s);
                    this.m_objViewer.dtgHistory.Rows[row].Tag = dt.Rows[i];                  
                    this.m_objViewer.dtgHistory.Rows[row].DefaultCellStyle.ForeColor = FCR;
                  
                    if (Math.IEEERemainder(Convert.ToDouble(i + 1), 2) == 0)
                    {
                        this.m_objViewer.dtgHistory.Rows[row].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                    }                    
                }

                if (this.m_objViewer.ucPatientInfo.BihPatient_VO.Status == 3)
                {
                    this.m_objViewer.btnNew.Enabled = false;
                    this.m_objViewer.btnCharge.Enabled = false;
                    this.m_objViewer.btnRefundment.Enabled = false;
                    this.m_objViewer.btnRepeatPrn.Enabled = false;
                    this.m_objViewer.tableLayoutPanel1.Enabled = false;
                }
                else
                {
                    this.m_objViewer.btnNew.Enabled = true;
                    this.m_objViewer.btnCharge.Enabled = true;
                    this.m_objViewer.btnRefundment.Enabled = true;
                    this.m_objViewer.btnRepeatPrn.Enabled = true;
                    this.m_objViewer.tableLayoutPanel1.Enabled = true;
                }
            }
        }
        #endregion

        #region 收费
        /// <summary>
        /// 收费
        /// </summary>
        public void m_mthCharge()
        {
            if (this.m_objViewer.ucPatientInfo.RegisterID == "")
            {
                return;
            }                      

            //取值
            string RegID = this.m_objViewer.ucPatientInfo.RegisterID;
            string Zyh = this.m_objViewer.ucPatientInfo.BihPatient_VO.Zyh;
            string CardNo = this.m_objViewer.ucPatientInfo.BihPatient_VO.CardNO;
            string BillNo = this.m_objViewer.txtprebillno.Text.Trim();
            string Money = this.m_objViewer.txtMoney.Text.Trim();
            string PayType = this.m_objViewer.cbopaytype.SelectedIndex.ToString();
            string Note = this.m_objViewer.txtnote.Text.Trim();

            //校验
            if (BillNo == "")
            {
                MessageBox.Show("请输入预交单号！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtprebillno.Focus();
                this.m_objViewer.txtprebillno.SelectAll();
                return;
            }

            if (Money == "")
            {
                MessageBox.Show("请输入预交金额！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtMoney.Focus();
                this.m_objViewer.txtMoney.SelectAll();
                return;
            }

            if (!Microsoft.VisualBasic.Information.IsNumeric(Money))
            {
                MessageBox.Show("金额必须是数字，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtMoney.Focus();
                this.m_objViewer.txtMoney.SelectAll();
                return;
            }

            if (Convert.ToDecimal(Money) <= 0)
            {
                MessageBox.Show("金额必须是正数，请重新输入！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtMoney.Focus();
                this.m_objViewer.txtMoney.SelectAll();
                return;
            }

            if (PayType == "-1")
            {
                MessageBox.Show("请选择支付类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.cbopaytype.Focus();
                return;
            }

            if (this.PreType == "0")
            {
                if (!clsPublic.m_blnCheckPrepayNoExpression(BillNo))
                {
                    MessageBox.Show("当前输入的预交单号不符合编码规则，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.txtprebillno.Focus();
                    this.m_objViewer.txtprebillno.SelectAll();
                    return;
                }
            }
            
            //if (clsPublic.m_blnCheckPrepayNoIsUsed(BillNo, int.Parse(PreType)))
            if (clsPublic.m_blnCheckPrepayNoIsUsed(BillNo, 0))
            {
                MessageBox.Show("当前输入的预交单号已经被使用，请重新输入。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtprebillno.Focus();
                this.m_objViewer.txtprebillno.SelectAll();
                return;
            }

            frmPrepayAlert fa = new frmPrepayAlert(this.m_objViewer.cbopaytype.Text.Substring(2), clsPublic.DoubleConvertToCurrency(double.Parse(Money)));
            if (fa.ShowDialog() == DialogResult.No)
            {
                return;
            }

            this.m_objViewer.Cursor = Cursors.WaitCursor;

            //赋值
            clsBihPrePay_VO PrePay_VO = new clsBihPrePay_VO();
            PrePay_VO.strPrePayInv = BillNo;
            PrePay_VO.strPatientID = this.m_objViewer.ucPatientInfo.BihPatient_VO.PatientID;
            PrePay_VO.strRegisterID = RegID;
            PrePay_VO.decMoney = clsPublic.ConvertObjToDecimal(Money);
            PrePay_VO.intPayType = 1;
            PrePay_VO.intCuyCate = int.Parse(PayType) + 1;
            PrePay_VO.strAreaID = this.m_objViewer.ucPatientInfo.BihPatient_VO.AreaID;
            PrePay_VO.strDes = Note;
            PrePay_VO.strCreatorID = this.m_objViewer.LoginInfo.m_strEmpID;
            PrePay_VO.intUpType = int.Parse(PreType);
            PrePay_VO.strPatientName = this.m_objViewer.ucPatientInfo.lblName.Text;
            PrePay_VO.strAreaName = this.m_objViewer.ucPatientInfo.txtArea.Text;
            
            //保存
            string PrePayID = "";
            long l = this.objSvc.m_lngAddPrePay(PrePay_VO, out PrePayID);
            if (l > 0)
            {                
                clsPublic.m_blnSaveCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, BillNo, 2);
                this.m_blnSavePrePayBillNo(BillNo);
                if (this.PreType == "0")
                {
                    //this.m_objViewer.txtprebillno.Text = Convert.ToString(int.Parse(BillNo) + 1);
                    this.m_objViewer.txtprebillno.Text = "";
                }
                else
                {
                    this.m_objViewer.txtprebillno.Text = "";
                }
                this.m_mthGetPrePayHistoryInfo();
                this.m_mthInit();                                

                try
                {
                    if (PreType == "0")
                    {
                        if (NorPrint)
                        {
                            clsPBNetPrint.m_mthPrintPrepayBill(PrePayID, "");
                        }
                    }
                    else if (PreType == "1")
                    {
                        if (HandPrint)
                        {
                            clsPBNetPrint.m_mthPrintPrepayBill(PrePayID, "");
                        }
                    }

                    this.m_objViewer.ucPatientInfo.m_mthFind(Zyh, 2);
                    //clsPublic.m_mthWriteParm(RegID, Zyh, CardNo);                    
                    this.m_objViewer.Cursor = Cursors.Default;

                    //MessageBox.Show("收费成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.m_objViewer.btnFind.Focus();
                }
                catch
                {
                    this.m_objViewer.Cursor = Cursors.Default;
                }
            }
            else
            {
                this.m_objViewer.Cursor = Cursors.Default;
                MessageBox.Show("保存数据失败！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        #endregion

        #region 重打
        /// <summary>
        /// 重打
        /// </summary>
        public void m_mthRepeatPrn()
        {           
            if (this.m_objViewer.dtgHistory.Rows.Count == 0)
            {
                return;
            }

            if (this.m_objViewer.dtgHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要重打的按金单据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow dr = this.m_objViewer.dtgHistory.SelectedRows[0].Tag as DataRow;

            if (dr["paytype_int"].ToString() == "2")
            {
                if (MessageBox.Show("该按金单已退票，是否确认重打？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }
                //MessageBox.Show("已退款的按金单据不能重打。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //return;
            }

            string prepayid = dr["prepayid_chr"].ToString();
            string oldno = dr["prepayinv_vchr"].ToString();

            frmPrePayRepeatPrn fpprp = new frmPrePayRepeatPrn(oldno, int.Parse(PreType));
            if (fpprp.ShowDialog() == DialogResult.OK)
            {
                string prntype = fpprp.PrnType;                
                string newno = fpprp.NewNo;

                if (prntype == "1")
                {
                    clsPBNetPrint.m_mthPrintPrepayBill(prepayid, "");
                    //clsInviocePrint_GD.m_mthPrintPrepayBill(prepayid, "");
                }
                else if (prntype == "2")
                {                    
                    long l = this.objSvc.m_lngSaveRepeatPrn(prepayid, oldno, newno, this.m_objViewer.LoginInfo.m_strEmpID, "1");
                    if (l > 0)
                    {
                       clsPBNetPrint.m_mthPrintPrepayBill(prepayid, newno);                                                
                        //clsInviocePrint_GD.m_mthPrintPrepayBill(prepayid, newno);
                        clsPublic.m_blnSaveCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, newno, 2);
                        this.m_blnSavePrePayBillNo(newno);

                       //this.m_objViewer.txtprebillno.Text = Convert.ToString(int.Parse(newno) + 1);
                        this.m_objViewer.txtprebillno.Text = "";//m_mthInit()方法会初始化
                        this.m_mthInit();
                    }
                    else
                    {
                        MessageBox.Show("保存重打信息失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }                        
                }
            }            
        }
        #endregion
             
        #region 退款、恢复和冲单
        /// <summary>
        /// 退款与恢复
        /// </summary>
        /// <param name="type">类型 2 退款 3 恢复 4 冲单</param>
        public void m_mthRefundmentAndResumeAndStrike(int type)
        {            
            if (this.m_objViewer.dtgHistory.Rows.Count == 0)
            {
                return;
            }

            string msg = "";
            if (type == 2)
            {               
                msg = "退款";
            }
            else if (type == 3)
            {               
                msg = "恢复";
            }
            else if (type == 4)
            {
                msg = "冲单";
            }

            if (this.m_objViewer.dtgHistory.SelectedRows.Count == 0)
            {
                MessageBox.Show("请选择需要" + msg + "的按金单据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataRow dr = this.m_objViewer.dtgHistory.SelectedRows[0].Tag as DataRow;

            if (dr["isclear_int"].ToString() == "1")
            {
                MessageBox.Show("该笔预交金已冲帐，请重新选择。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string prepayno = dr["prepayinv_vchr"].ToString();//票号
            string prepayid = "";//ID

            //该笔预交金状态 1 正常 2 退款 3 恢复 4 冲单
            int status = 1;
            if (type == 2)
            {
                for (int i = 0; i < this.m_objViewer.dtgHistory.Rows.Count; i++)
                {
                    DataRow tmpdr = this.m_objViewer.dtgHistory.Rows[i].Tag as DataRow;

                    if (prepayno == tmpdr["prepayinv_vchr"].ToString() && tmpdr["paytype_int"].ToString() == "2")
                    {
                        status = 2;
                        break;                        
                    }
                }

                if (status == 2)
                {
                    MessageBox.Show("该笔预交金已办理退款手续。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                prepayid = dr["prepayid_chr"].ToString();
            }
            else if (type == 3)
            {
                for (int i = 0; i < this.m_objViewer.dtgHistory.Rows.Count; i++)
                {
                    DataRow tmpdr = this.m_objViewer.dtgHistory.Rows[i].Tag as DataRow;

                    if (prepayno == tmpdr["prepayinv_vchr"].ToString() && tmpdr["paytype_int"].ToString() == "2")
                    {
                        prepayid = tmpdr["prepayid_chr"].ToString();
                        status = 2;
                    }
                    else if (prepayno == tmpdr["prepayinv_vchr"].ToString() && tmpdr["paytype_int"].ToString() == "3")
                    {
                        status = 3;
                        break;
                    }
                    else if (prepayno == tmpdr["prepayinv_vchr"].ToString() && tmpdr["paytype_int"].ToString() == "4")
                    {
                        status = 4;
                        break;
                    }
                }

                if (status == 1)
                {
                    MessageBox.Show("该笔预交金为正常收费(未退款)，不能办理恢复手续。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (status == 3)
                {
                    MessageBox.Show("该笔预交金已办理恢复手续。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (status == 4)
                {
                    MessageBox.Show("该笔预交金已办理冲单手续。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (type == 4)
            {
                for (int i = 0; i < this.m_objViewer.dtgHistory.Rows.Count; i++)
                {
                    DataRow tmpdr = this.m_objViewer.dtgHistory.Rows[i].Tag as DataRow;

                    if (prepayno == tmpdr["prepayinv_vchr"].ToString() && tmpdr["paytype_int"].ToString() == "2")
                    {
                        status = 2;
                        break;
                    }
                    else if ((prepayno == tmpdr["prepayinv_vchr"].ToString() || prepayno == tmpdr["originvono_vchr"].ToString()) && tmpdr["paytype_int"].ToString() == "4")
                    {
                        status = 4;
                        break;
                    }
                }

                if (status == 2)
                {
                    MessageBox.Show("该笔预交金已办理退款手续。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (status == 4)
                {
                    MessageBox.Show("该笔预交金已办理冲单手续。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                 prepayid = dr["prepayid_chr"].ToString();
            }
            
            //string prepayid = dr["prepayid_chr"].ToString();

            string ConfirmEmpID = "";
            DialogResult dlg = clsPublic.m_dlgConfirm(out ConfirmEmpID);
            if (dlg == DialogResult.Yes)
            {
                string BillNo = "";
                string CuyCate = "1";
                if (type == 4)
                {
                    frmPrePayNoInput fpp = new frmPrePayNoInput();
                    fpp.NewNo = PrepayBillNo;
                    if (fpp.ShowDialog() == DialogResult.OK)
                    {
                        BillNo = fpp.NewNo;
                        CuyCate = fpp.CuyCate;
                    }
                    else
                    {
                        MessageBox.Show("冲单必须输入单号。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                string NewPrePayID = "";
                long l = this.objSvc.m_lngRefundAndResumeAndStrikePrePay(prepayid, BillNo, this.m_objViewer.LoginInfo.m_strEmpID, ConfirmEmpID, type, CuyCate, out NewPrePayID);
                if (l > 0)
                {
                    if (type == 4)
                    {
                        clsPublic.m_blnSaveCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, BillNo, 2);
                        this.m_blnSavePrePayBillNo(BillNo);
                        this.m_objViewer.txtprebillno.Text = Convert.ToString(int.Parse(BillNo) + 1);

                        this.m_mthInit();
                        clsPBNetPrint.m_mthPrintPrepayBill(NewPrePayID, "");
                    }
                    else
                    {
                        MessageBox.Show(msg + "成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    this.m_mthGetPrePayHistoryInfo();
                    this.m_objViewer.ucPatientInfo.m_mthFind(this.m_objViewer.ucPatientInfo.BihPatient_VO.Zyh, 2);
                }
                else
                {
                    MessageBox.Show(msg + "失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion               
    }
}
