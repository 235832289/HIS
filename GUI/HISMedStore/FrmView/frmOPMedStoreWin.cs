using System;
using System.Drawing;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HI;
using LEDInterface.LianCheng;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 门诊发药窗口
    /// </summary>
    public class frmOPMedStoreWin : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {

        #region 控件信息
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.NumericUpDown m_nudRefershTime;
        private System.Windows.Forms.Label label3;
        internal PinkieControls.ButtonXP m_cmdRefersh;
        internal System.Windows.Forms.ListView m_lsvMedicineDetail;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.ListView m_lsvOpRecDetail;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        internal System.Windows.Forms.Timer m_timer;
        internal System.Drawing.Printing.PrintDocument PrintDocu;
        internal System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP m_cmdFind;
        internal SourceLibrary.Windows.Forms.TextBoxTypedNumeric m_txtRegisterNo;
        private System.Windows.Forms.Label label7;
        internal SourceLibrary.Windows.Forms.TextBoxTyped m_txtPatient;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private PinkieControls.ButtonXP buttonXP1;
        internal System.Windows.Forms.GroupBox gbItem;
        private System.Windows.Forms.ColumnHeader 项目规格;
        internal System.Windows.Forms.RadioButton rdbWest;
        internal System.Windows.Forms.RadioButton rdbChina;
        internal com.digitalwave.controls.datagrid.ctlDataGrid dgpatienothre;
        internal com.digitalwave.controls.datagrid.ctlDataGrid dgpatienOpsre;
        internal com.digitalwave.controls.datagrid.ctlDataGrid dgpatientest;
        internal com.digitalwave.controls.datagrid.ctlDataGrid dgpatientcnkre;
        internal System.Windows.Forms.ComboBox cbWindows;
        private System.ComponentModel.IContainer components;

        #region 变量
        internal System.Windows.Forms.GroupBox groupBox3;
        internal PinkieControls.ButtonXP btnOther;
        internal PinkieControls.ButtonXP btnSendMed;
        internal PinkieControls.ButtonXP btnPrint;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        internal System.Windows.Forms.DateTimePicker DateTimeMana;
        internal System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox2;
        internal PinkieControls.ButtonXP btnSend;
        private System.Windows.Forms.Label label8;
        internal System.Windows.Forms.Label CullMoney;
        internal System.Windows.Forms.Label MedMoney;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label multiMoney;
        internal System.Windows.Forms.Label label11;
        internal com.digitalwave.controls.datagrid.ctlDataGrid m_DgMed;
        internal PinkieControls.ButtonXP btnOtherSend;
        internal System.Windows.Forms.Panel pnlotherSend;
        internal System.Windows.Forms.Panel pnl1;
        internal com.digitalwave.controls.datagrid.ctlDataGrid DgItem;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        internal System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        internal System.Windows.Forms.Label ChinaMoney;
        internal System.Windows.Forms.Label WestMoney11;
        internal System.Windows.Forms.Label WestMoney;
        internal System.Windows.Forms.Label ChAndEN;
        internal System.Windows.Forms.Label CheckMoney;
        private System.Windows.Forms.ImageList imageList1;
        internal System.Windows.Forms.Label label9;
        internal System.Windows.Forms.Label PatientType;
        private System.Windows.Forms.Label label13;
        internal System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.Label m_txtMedStore;
        internal PinkieControls.ButtonXP btnPrintqe;
        internal System.Windows.Forms.DateTimePicker dateTimePicker1;
        internal System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        internal System.Windows.Forms.TextBox textBox1;
        internal System.Windows.Forms.CheckBox checkBox2;
        internal System.Windows.Forms.RadioButton radMat;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        internal PinkieControls.ButtonXP btnDosage;
        internal PinkieControls.ButtonXP buttonXP3;
        internal System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        internal System.Drawing.Printing.PrintDocument printDocument1;
        /// <summary>
        /// 保存药房窗口信息
        /// </summary>
        DataTable dtwindowsMessage;
        /// <summary>
        /// 保存窗体的状态信息
        /// </summary>
        public clsStatusWindows_VO statusWindows = new clsStatusWindows_VO();
        /// <summary>
        /// 保存窗体标题名称
        /// </summary>
        internal string m_strFormText = string.Empty;
        private Panel panel8;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        private Panel panel9;
        private Label label23;
        internal com.digitalwave.controls.ctlTextBoxFind m_txtDep;
        private Panel panel10;
        private Panel panel11;
        internal CheckBox checkBox4;
        internal CheckBox checkBox3;
        private PinkieControls.ButtonXP buttonXP4;
        internal PinkieControls.ButtonXP buttonXP5;
        internal Panel panel12;
        private Panel panel13;
        private Label label25;
        private Label label24;
        internal TextBox textBox3;
        internal TextBox textBox2;
        private Button button1;
        private Button button2;
        private ColumnHeader columnHeader9;
        private PinkieControls.ButtonXP buttonXP6;
        private ColumnHeader colMedStore;
        private ColumnHeader colPei;
        private ColumnHeader colfa;
        private Timer timerChangeDate;
        internal PinkieControls.ButtonXP m_btnPrint;
        internal PrintPreviewDialog m_PriviewDialogRecipe;
        internal PrintDocument m_printDocumentRecipe;
        internal PinkieControls.ButtonXP m_btnCall;
        internal PrintPreviewDialog PrintDialog;
        public clsMedStoreScreenConfigVo m_objScreenConfigVo;
        internal CheckBox m_chkCorlor;
        internal PinkieControls.ButtonXP m_btnPause;
        internal CheckBox m_chkShowScreen;
        private ToolTip toolTip1;
        internal Timer m_timerDispense;
        internal CheckBox m_chkTreatTip;
        internal PinkieControls.ButtonXP m_btnTreat;
        internal PrintDocument m_pdTreatTip;
        internal PrintPreviewDialog m_PriviewTreatTip;
        internal CheckBox m_chkHistory;
        internal PinkieControls.ButtonXP m_btnCaseHistory;
        internal PrintDocument m_objPDHistoryCase;
        internal PrintPreviewDialog m_PreDiagCaseHistory;
        internal TableLayoutPanel tableLayoutPanel1;
        private Label label19;
        internal TabControl tab;
        private TabPage tabPageNot;
        internal ListView m_lsvPatientDetial;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader1;
        internal TextBox m_txtSeqID;
        internal Label label20;
        private TabPage tabPageOk;
        internal Label label21;
        internal ListView listViewok;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader14;
        private TabPage tabPageBreak;
        internal ListView lisvBreak;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader8;
        internal Label label22;
        private Panel panel15;
        private Button CmdCancel3;
        private Button CmdSetEmp3;
        internal TextBox txtPsw3;
        internal TextBox txtEmpNo3;
        private Label label28;
        private Label label29;
        private Panel panel14;
        private Button CmdCancel2;
        private Button CmdSetEemp2;
        internal TextBox txtPsw2;
        internal TextBox txtEmpNo2;
        private Label label26;
        private Label label27;
        private Panel panel16;
        private Button CmdCancel4;
        private Button CmdSetEmp4;
        internal TextBox txtPsw4;
        internal TextBox txtEmpNo4;
        private Label label30;
        private Label label31;
        internal BackgroundWorker backgroundWorkerCall;
        internal ContextMenuStrip m_callcancel;
        private ToolStripMenuItem 取消叫号ToolStripMenuItem;
        private ToolStripMenuItem 叫号ToolStripMenuItem;
        private ToolStripMenuItem 锁定处方ToolStripMenuItem;
        private ToolStripMenuItem 取消锁定ToolStripMenuItem;
        internal com.digitalwave.controls.clsCardTextBox m_txtPatientCard;
        internal PinkieControls.ButtonXP btnPrintYD;
        internal CheckBox m_chkMedBag;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem tsmiDrugInfo;
        internal ContextMenuStrip ctmsSend;
        private ToolStripMenuItem tsmiDrugInfo2;
        internal Label lblWechatCode;
        internal TabPage tabPageLED;
        internal ListView lvLED;
        private ColumnHeader columnHeader22;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private ColumnHeader columnHeader23;
        internal TextBox txtWechatCode;
        public Font m_objScreenFont;
        #endregion
        #endregion 控件信息

        /// <summary>
        /// 门诊发药窗口
        /// </summary>
        public frmOPMedStoreWin()
        {
            //
            // Windows 窗体设计器支持所必需的
            //
            InitializeComponent();
            //
            // TODO: 在 InitializeComponent 调用后添加任何构造函数代码
            //
            #region 获取功能开关设置
            if (this.objController.m_objComInfo.m_lonGetModuleInfo("0034") == "0")
            {
                this.statusWindows.isAutoPrint = false;
            }
            else
            {
                this.statusWindows.isAutoPrint = true;
            }
            if (this.objController.m_objComInfo.m_lonGetModuleInfo("0044") == "0")
            {
                this.statusWindows.statusToneAnd = 0;
            }
            else
            {
                this.statusWindows.statusToneAnd = 1;
            }
            if (this.objController.m_objComInfo.m_lonGetModuleInfo("8010") == "0")
            {
                this.statusWindows.m_intOmitDispense = 0;
            }
            else
            {
                this.statusWindows.m_intOmitDispense = 1;
            }
            if (this.objController.m_objComInfo.m_lonGetModuleInfo("8011") == "0")
            {
                this.statusWindows.m_intDiscriminateSendWindows = 0;
            }
            else
            {
                this.statusWindows.m_intDiscriminateSendWindows = 1;
            }
            if (this.objController.m_objComInfo.m_lonGetModuleInfo("8100") == "1")
            {
                m_strAutoPrintRecipe = "1";
            }
            this.m_intSettingCount = Convert.ToInt16(this.objController.m_objComInfo.m_lonGetModuleInfo("0402"));
            this.m_strSecondLevelMode = this.objController.m_objComInfo.m_lonGetModuleInfo("9100");
            this.m_strSubtractMode = this.objController.m_objComInfo.m_lonGetModuleInfo("0401");
            #endregion
        }
        #region 界面控制（配药同发药窗口的不同来实现）
        /// <summary>
        /// 界面控制（配药同发药窗口的不同来实现）
        /// </summary>
        /// <param name="intStatus">窗口类型</param>
        private void m_mthShowGUI(int intStatus)
        {

            switch (intStatus)
            {
                case 1:
                    btnSendMed.Text = "退处方(&S)";
                    btnOtherSend.Visible = false;
                    panel11.Visible = true;
                    btnOther.Visible = false;
                    this.Text = "药房配药";
                    buttonXP5.Text = "默认配药(&D)";
                    tab.TabPages[0].Text = "未配";
                    tab.TabPages[1].Text = "已配";
                    buttonXP6.Text = "自动配药";
                    this.m_btnCall.Enabled = false;
                    this.m_btnPause.Enabled = false;
                    this.m_txtSeqID.Focus();
                    break;
                case 2:
                    btnSendMed.Text = "发药(&S)";
                    btnOtherSend.Text = "其它发药(&O)";
                    this.Text = "药房发药";
                    buttonXP5.Text = "默认发药(&D)";
                    //buttonXP5.Enabled = false;
                    btnOtherSend.Visible = false;
                    panel11.Visible = true;
                    btnOther.Visible = false;
                    tab.TabPages[0].Text = "未发";
                    tab.TabPages[1].Text = "已发";
                    btnDosage.Enabled = false;
                    btnDosage.Text = "放弃";//放弃叫号
                    tab.TabPages.RemoveAt(2);
                    tab.SelectedIndex = 0;
                    buttonXP6.Text = "自动发药";
                    this.m_btnCall.Enabled = true;
                    this.m_btnPause.Enabled = true;
                    this.m_chkShowScreen.Enabled = true;
                    this.m_txtSeqID.Dock = DockStyle.Top;
                    this.m_txtSeqID.Focus();
                    //((clsControlOPMedStore)this.objController).m_objfrmSmallScreen = frmSmallScreen.SmallScreenForm(string.Empty);
                    ((clsControlOPMedStore)this.objController).m_mthInitPreviewLEDRefreshTime();
                    break;
                case 3:
                    this.Text = "门诊审核处方";
                    tab.TabPages[0].Text = "未审核";
                    tab.TabPages[1].Text = "已审核";
                    buttonXP5.Text = "默认审核(&D)";
                    this.btnSendMed.Text = "退处方(&S)";
                    this.btnOther.Visible = false;
                    this.btnOtherSend.Visible = false;
                    this.btnPrint.Visible = false;
                    this.btnPrintqe.Visible = false;
                    this.buttonXP3.Visible = false;
                    this.btnDosage.Text = "审核处方(&P)";
                    buttonXP6.Text = "自动审核";
                    this.btnDosage.Width = 100;
                    this.btnDosage.Location = new Point(270, 16);
                    this.btnSendMed.Width = 100;
                    this.btnSendMed.Location = new Point(400, 16);
                    this.m_btnCall.Width = 100;
                    this.m_btnCall.Location = new Point(530, 16);
                    this.checkBox2.Visible = false;
                    this.checkBox1.Visible = false;
                    //this.label19.Visible = false;
                    this.label1.Visible = false;
                    this.m_txtMedStore.Visible = false;
                    this.label14.Visible = false;
                    this.cbWindows.Visible = false;
                    this.label4.Visible = false;

                    panel5.Controls.Add(DateTimeMana);
                    DateTimeMana.Width += 20;
                    Label lableDate = new Label();
                    lableDate.Text = "日期：";
                    lableDate.TextAlign = ContentAlignment.MiddleCenter;
                    panel5.Controls.Add(lableDate);

                    lableDate.Location = new Point(1, 11);
                    panel9.Visible = true;
                    this.panel5.Controls.Add(panel9);
                    panel9.Location = new Point(220, 5);
                    panel9.BringToFront();
                    this.DateTimeMana.Location = new Point(70, 11);
                    this.label2.Location = new Point(400, 11);
                    this.m_nudRefershTime.Location = new Point(480, 11);
                    this.label3.Location = new Point(530, 11);
                    this.m_cmdRefersh.Location = new Point(560, 4);
                    this.m_lsvOpRecDetail.Visible = false;
                    this.groupBox4.Visible = false;
                    m_lsvMedicineDetail.Location = new Point(8, 80);
                    m_lsvMedicineDetail.Height += 96;
                    m_mthShowLsv(m_lsvPatientDetial);
                    m_mthShowLsv(listViewok);
                    m_mthShowLsv(lisvBreak);
                    this.m_lsvPatientDetial.CheckBoxes = true;
                    this.panel2.Controls.Add(panel8);
                    Point p = textBox1.Location;
                    p.Offset(30, 0);
                    panel8.Location = p;
                    panel8.Visible = true;
                    panel8.BringToFront();
                    panel10.Visible = false;
                    panel11.Visible = false;
                    this.m_btnPause.Enabled = false;
                    this.m_btnCall.Enabled = false;
                    break;
            }
        }

        #endregion
        private void m_mthShowLsv(ListView Lisv)
        {
            Lisv.Columns[0].Text = "处方号";
            Lisv.Columns[0].Width = 210;
            Lisv.Columns[1].Text = "诊断科室";
            Lisv.Columns[1].Width = 100;
            Lisv.Columns[2].Text = "诊断医生";
            Lisv.Columns.Add("病人名称", 100);
            Lisv.Columns.Add("就诊卡号", 115);
            Lisv.Columns.Add("诊断", 120);
        }
        public string m_strAutoPrintRecipe = "0";
        string m_strWindowsID = "";
        #region 根据传入的药房ID查找资料
        /// <summary>
        /// 根据传入的药房ID查找资料
        /// </summary>
        /// <param name="strint">1-配药窗口，2-发药窗口</param>
        /// <param name="strStorageID">药房ID</param>
        /// <param name="strWindowsID">窗口ID</param>
        public void sendDataAndShow(string strint, string strStorageID, string strWindowsID)
        {
            m_strWindowsID = strWindowsID;
            clsDomainControlMedStore Domain = new clsDomainControlMedStore();
            DataTable dtstroageMessage;
            try
            {
                statusWindows.statusTone = int.Parse(strint);
            }
            catch
            {
                MessageBox.Show("传入值的类型不正确！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            long lngRes = 1;
            System.Windows.Forms.HorizontalAlignment Alignment = new HorizontalAlignment();
            if (statusWindows.statusTone != 3)
            {
                //窗口类型 0-发药窗口 1-配药窗口
                lngRes = Domain.m_lngGetStorageMessage(strStorageID, out dtstroageMessage, out dtwindowsMessage, statusWindows.statusTone == 2 ? 0 : statusWindows.statusTone);
                if (dtstroageMessage.Rows.Count == 0)
                {
                    MessageBox.Show("传入药房ID不正确！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (dtwindowsMessage.Rows.Count == 0)
                {
                    MessageBox.Show("传入窗口ＩＤ不正确！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                if (lngRes == 1)
                {
                    statusWindows.strLoginName = this.LoginInfo.m_strEmpName;
                    statusWindows.strLoginName = this.LoginInfo.m_strEmpID;
                    statusWindows.strStorageID = strStorageID;
                    statusWindows.strWindowID = strWindowsID;
                    statusWindows.m_strDeptid = dtstroageMessage.Rows[0]["deptid_chr"].ToString();
                    statusWindows.strStorageName = dtstroageMessage.Rows[0]["MEDSTORENAME_VCHR"].ToString();
                    statusWindows.intUrgence = int.Parse(dtstroageMessage.Rows[0]["URGENCE_INT"].ToString());
                    m_txtMedStore.Text = dtstroageMessage.Rows[0]["MEDSTORENAME_VCHR"].ToString();
                    if (statusWindows.intUrgence == 1)
                    {
                        ((clsControlOPMedStore)this.objController).m_mthGetMedStore();
                    }

                    if (dtstroageMessage.Rows[0]["MEDICNETYPE"].ToString() == "西药")
                    {
                        rdbWest.Checked = true;
                        m_txtMedStore.Tag = 1;
                        m_lsvMedicineDetail.Columns.Insert(2, "剂量", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(3, "单位", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(4, "用法", 130, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(5, "频率", 130, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(6, "天数", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(7, "总数", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(8, "单位", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(9, "单价", 110, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(10, "金额", 140, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(11, "编码", 120, Alignment);

                    }
                    else if (dtstroageMessage.Rows[0]["MEDICNETYPE"].ToString() == "中药")
                    {
                        rdbChina.Checked = true;
                        m_lsvMedicineDetail.Columns.Insert(2, "剂量", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(3, "单位", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(4, "用法", 130, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(5, "频率", 130, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(6, "天(服)数", 130, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(7, "总数", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(8, "单位", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(9, "单价", 110, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(10, "金额", 140, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(11, "编码", 120, Alignment);
                        m_txtMedStore.Tag = 2;
                    }
                    else
                    {
                        this.radMat.Checked = true;
                        m_lsvMedicineDetail.Columns.Insert(2, "总数", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(3, "单位", 80, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(4, "单价", 110, Alignment);
                        m_lsvMedicineDetail.Columns.Insert(5, "金额", 140, Alignment);
                        m_txtMedStore.Tag = 5;
                    }
                    if (dtwindowsMessage.Rows.Count > 0)
                    {
                        for (int i1 = 0; i1 < dtwindowsMessage.Rows.Count; i1++)
                        {
                            cbWindows.Items.Add(dtwindowsMessage.Rows[i1]["WINDOWNAME_VCHR"].ToString());
                            if (dtwindowsMessage.Rows[i1]["WINDOWID_CHR"].ToString().Trim() == strWindowsID)
                            {
                                cbWindows.SelectedIndex = i1;
                                statusWindows.strWindowID = dtwindowsMessage.Rows[i1]["WINDOWID_CHR"].ToString();
                                statusWindows.strWindowName = dtwindowsMessage.Rows[i1]["WINDOWNAME_VCHR"].ToString();
                            }
                        }
                    }
                }
            }
            else
            {
                m_lsvMedicineDetail.Columns.Insert(2, "剂量", 80, Alignment);
                m_lsvMedicineDetail.Columns.Insert(3, "单位", 80, Alignment);
                m_lsvMedicineDetail.Columns.Insert(4, "用法", 130, Alignment);
                m_lsvMedicineDetail.Columns.Insert(5, "频率", 130, Alignment);
                m_lsvMedicineDetail.Columns.Insert(6, "天数", 80, Alignment);
                m_lsvMedicineDetail.Columns.Insert(7, "总数", 80, Alignment);
                m_lsvMedicineDetail.Columns.Insert(8, "单位", 80, Alignment);
                m_lsvMedicineDetail.Columns.Insert(9, "单价", 110, Alignment);
                m_lsvMedicineDetail.Columns.Insert(10, "金额", 140, Alignment);
                m_lsvMedicineDetail.Columns.Insert(11, "编码", 120, Alignment);
            }

            this.Show();
        }
        #endregion

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器修改
        /// 此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOPMedStoreWin));
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo5 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo6 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo7 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo8 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo9 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo10 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo11 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo12 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo13 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo14 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo15 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo16 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo17 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo18 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo19 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo20 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo21 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo22 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo23 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo24 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo25 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo26 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo27 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo28 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo29 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo30 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo31 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo32 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo33 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo34 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo35 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo36 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo37 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo38 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo39 = new com.digitalwave.controls.datagrid.clsColumnInfo();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.m_timer = new System.Windows.Forms.Timer(this.components);
            this.PrintDocu = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.PrintDialog = new System.Windows.Forms.PrintPreviewDialog();
            this.timerChangeDate = new System.Windows.Forms.Timer(this.components);
            this.m_PriviewDialogRecipe = new System.Windows.Forms.PrintPreviewDialog();
            this.m_printDocumentRecipe = new System.Drawing.Printing.PrintDocument();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.m_txtSeqID = new System.Windows.Forms.TextBox();
            this.m_timerDispense = new System.Windows.Forms.Timer(this.components);
            this.m_pdTreatTip = new System.Drawing.Printing.PrintDocument();
            this.m_PriviewTreatTip = new System.Windows.Forms.PrintPreviewDialog();
            this.m_objPDHistoryCase = new System.Drawing.Printing.PrintDocument();
            this.m_PreDiagCaseHistory = new System.Windows.Forms.PrintPreviewDialog();
            this.backgroundWorkerCall = new System.ComponentModel.BackgroundWorker();
            this.m_callcancel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.取消叫号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.叫号ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.锁定处方ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.取消锁定ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDrugInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.panel12 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.CmdCancel4 = new System.Windows.Forms.Button();
            this.CmdSetEmp4 = new System.Windows.Forms.Button();
            this.txtPsw4 = new System.Windows.Forms.TextBox();
            this.txtEmpNo4 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.panel15 = new System.Windows.Forms.Panel();
            this.CmdCancel3 = new System.Windows.Forms.Button();
            this.CmdSetEmp3 = new System.Windows.Forms.Button();
            this.txtPsw3 = new System.Windows.Forms.TextBox();
            this.txtEmpNo3 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.panel14 = new System.Windows.Forms.Panel();
            this.CmdCancel2 = new System.Windows.Forms.Button();
            this.CmdSetEemp2 = new System.Windows.Forms.Button();
            this.txtPsw2 = new System.Windows.Forms.TextBox();
            this.txtEmpNo2 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.panel13 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.buttonXP4 = new PinkieControls.ButtonXP();
            this.panel8 = new System.Windows.Forms.Panel();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel9 = new System.Windows.Forms.Panel();
            this.m_txtDep = new com.digitalwave.controls.ctlTextBoxFind();
            this.m_cmdRefersh = new PinkieControls.ButtonXP();
            this.label23 = new System.Windows.Forms.Label();
            this.pnlotherSend = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnl1 = new System.Windows.Forms.Panel();
            this.multiMoney = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.MedMoney = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.CullMoney = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSend = new PinkieControls.ButtonXP();
            this.DgItem = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.m_DgMed = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.panel6 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtWechatCode = new System.Windows.Forms.TextBox();
            this.lblWechatCode = new System.Windows.Forms.Label();
            this.btnPrintYD = new PinkieControls.ButtonXP();
            this.btnDosage = new PinkieControls.ButtonXP();
            this.m_btnCaseHistory = new PinkieControls.ButtonXP();
            this.m_btnTreat = new PinkieControls.ButtonXP();
            this.m_btnPrint = new PinkieControls.ButtonXP();
            this.buttonXP5 = new PinkieControls.ButtonXP();
            this.panel11 = new System.Windows.Forms.Panel();
            this.m_btnPause = new PinkieControls.ButtonXP();
            this.m_btnCall = new PinkieControls.ButtonXP();
            this.buttonXP3 = new PinkieControls.ButtonXP();
            this.btnPrintqe = new PinkieControls.ButtonXP();
            this.btnOtherSend = new PinkieControls.ButtonXP();
            this.btnPrint = new PinkieControls.ButtonXP();
            this.btnOther = new PinkieControls.ButtonXP();
            this.btnSendMed = new PinkieControls.ButtonXP();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_chkMedBag = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_chkHistory = new System.Windows.Forms.CheckBox();
            this.m_chkTreatTip = new System.Windows.Forms.CheckBox();
            this.m_chkCorlor = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_chkShowScreen = new System.Windows.Forms.CheckBox();
            this.radMat = new System.Windows.Forms.RadioButton();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.m_txtMedStore = new System.Windows.Forms.Label();
            this.rdbWest = new System.Windows.Forms.RadioButton();
            this.rdbChina = new System.Windows.Forms.RadioButton();
            this.cbWindows = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_nudRefershTime = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lsvMedicineDetail = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.项目规格 = new System.Windows.Forms.ColumnHeader();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.PatientType = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.CheckMoney = new System.Windows.Forms.Label();
            this.ChinaMoney = new System.Windows.Forms.Label();
            this.ChAndEN = new System.Windows.Forms.Label();
            this.WestMoney = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.WestMoney11 = new System.Windows.Forms.Label();
            this.m_lsvOpRecDetail = new System.Windows.Forms.ListView();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.colMedStore = new System.Windows.Forms.ColumnHeader();
            this.colPei = new System.Windows.Forms.ColumnHeader();
            this.colfa = new System.Windows.Forms.ColumnHeader();
            this.gbItem = new System.Windows.Forms.GroupBox();
            this.dgpatientcnkre = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.dgpatientest = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.dgpatienOpsre = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.dgpatienothre = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tab = new System.Windows.Forms.TabControl();
            this.tabPageNot = new System.Windows.Forms.TabPage();
            this.m_lsvPatientDetial = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label20 = new System.Windows.Forms.Label();
            this.tabPageOk = new System.Windows.Forms.TabPage();
            this.label21 = new System.Windows.Forms.Label();
            this.listViewok = new System.Windows.Forms.ListView();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.ctmsSend = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiDrugInfo2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPageBreak = new System.Windows.Forms.TabPage();
            this.lisvBreak = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.label22 = new System.Windows.Forms.Label();
            this.tabPageLED = new System.Windows.Forms.TabPage();
            this.lvLED = new System.Windows.Forms.ListView();
            this.columnHeader22 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader23 = new System.Windows.Forms.ColumnHeader();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.DateTimeMana = new System.Windows.Forms.DateTimePicker();
            this.label19 = new System.Windows.Forms.Label();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel10 = new System.Windows.Forms.Panel();
            this.m_txtPatientCard = new com.digitalwave.controls.clsCardTextBox();
            this.m_txtRegisterNo = new SourceLibrary.Windows.Forms.TextBoxTypedNumeric();
            this.label17 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.m_txtPatient = new SourceLibrary.Windows.Forms.TextBoxTyped();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonXP1 = new PinkieControls.ButtonXP();
            this.m_cmdFind = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonXP6 = new PinkieControls.ButtonXP();
            this.m_callcancel.SuspendLayout();
            this.panel12.SuspendLayout();
            this.panel16.SuspendLayout();
            this.panel15.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel13.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel9.SuspendLayout();
            this.pnlotherSend.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.pnl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DgMed)).BeginInit();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel11.SuspendLayout();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRefershTime)).BeginInit();
            this.panel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgpatientcnkre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpatientest)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpatienOpsre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpatienothre)).BeginInit();
            this.panel2.SuspendLayout();
            this.tab.SuspendLayout();
            this.tabPageNot.SuspendLayout();
            this.tabPageOk.SuspendLayout();
            this.ctmsSend.SuspendLayout();
            this.tabPageBreak.SuspendLayout();
            this.tabPageLED.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            // 
            // m_timer
            // 
            this.m_timer.Enabled = true;
            this.m_timer.Interval = 10000;
            this.m_timer.Tick += new System.EventHandler(this.m_timer_Tick);
            // 
            // PrintDocu
            // 
            this.PrintDocu.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocu_PrintPage);
            this.PrintDocu.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.PrintDocu_BeginPrint);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(398, 298);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            this.printDocument1.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.printDocument1_BeginPrint);
            // 
            // PrintDialog
            // 
            this.PrintDialog.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.PrintDialog.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.PrintDialog.ClientSize = new System.Drawing.Size(398, 298);
            this.PrintDialog.Document = this.PrintDocu;
            this.PrintDialog.Enabled = true;
            this.PrintDialog.Icon = ((System.Drawing.Icon)(resources.GetObject("PrintDialog.Icon")));
            this.PrintDialog.Name = "PrintDialog";
            this.PrintDialog.ShowIcon = false;
            this.PrintDialog.Visible = false;
            // 
            // timerChangeDate
            // 
            this.timerChangeDate.Enabled = true;
            this.timerChangeDate.Interval = 1000;
            this.timerChangeDate.Tick += new System.EventHandler(this.timerChangeDate_Tick);
            // 
            // m_PriviewDialogRecipe
            // 
            this.m_PriviewDialogRecipe.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.m_PriviewDialogRecipe.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.m_PriviewDialogRecipe.ClientSize = new System.Drawing.Size(398, 298);
            this.m_PriviewDialogRecipe.Document = this.m_printDocumentRecipe;
            this.m_PriviewDialogRecipe.Enabled = true;
            this.m_PriviewDialogRecipe.Icon = ((System.Drawing.Icon)(resources.GetObject("m_PriviewDialogRecipe.Icon")));
            this.m_PriviewDialogRecipe.Name = "m_PriviewDialogRecipe";
            this.m_PriviewDialogRecipe.Visible = false;
            // 
            // m_printDocumentRecipe
            // 
            this.m_printDocumentRecipe.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_printDocumentRecipe_PrintPage);
            this.m_printDocumentRecipe.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_printDocumentRecipe_BeginPrint);
            // 
            // m_txtSeqID
            // 
            this.m_txtSeqID.BackColor = System.Drawing.Color.White;
            this.m_txtSeqID.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_txtSeqID.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtSeqID.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.m_txtSeqID.Location = new System.Drawing.Point(0, 0);
            this.m_txtSeqID.MaxLength = 18;
            this.m_txtSeqID.Name = "m_txtSeqID";
            this.m_txtSeqID.Size = new System.Drawing.Size(207, 26);
            this.m_txtSeqID.TabIndex = 1;
            this.toolTip1.SetToolTip(this.m_txtSeqID, "请在这里输入流水号！！");
            this.m_txtSeqID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSeqID_KeyDown);
            // 
            // m_timerDispense
            // 
            this.m_timerDispense.Tick += new System.EventHandler(this.m_timerDispense_Tick);
            // 
            // m_pdTreatTip
            // 
            this.m_pdTreatTip.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdTreatTip_PrintPage);
            this.m_pdTreatTip.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdTreatTip_BeginPrint);
            // 
            // m_PriviewTreatTip
            // 
            this.m_PriviewTreatTip.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.m_PriviewTreatTip.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.m_PriviewTreatTip.ClientSize = new System.Drawing.Size(398, 298);
            this.m_PriviewTreatTip.Document = this.m_pdTreatTip;
            this.m_PriviewTreatTip.Enabled = true;
            this.m_PriviewTreatTip.Icon = ((System.Drawing.Icon)(resources.GetObject("m_PriviewTreatTip.Icon")));
            this.m_PriviewTreatTip.Name = "m_PriviewTreatTip";
            this.m_PriviewTreatTip.Visible = false;
            // 
            // m_objPDHistoryCase
            // 
            this.m_objPDHistoryCase.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_objPDHistoryCase_PrintPage);
            this.m_objPDHistoryCase.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_objPDHistoryCase_BeginPrint);
            // 
            // m_PreDiagCaseHistory
            // 
            this.m_PreDiagCaseHistory.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.m_PreDiagCaseHistory.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.m_PreDiagCaseHistory.ClientSize = new System.Drawing.Size(398, 298);
            this.m_PreDiagCaseHistory.Document = this.m_objPDHistoryCase;
            this.m_PreDiagCaseHistory.Enabled = true;
            this.m_PreDiagCaseHistory.Icon = ((System.Drawing.Icon)(resources.GetObject("m_PreDiagCaseHistory.Icon")));
            this.m_PreDiagCaseHistory.Name = "m_PreDiagCaseHistory";
            this.m_PreDiagCaseHistory.Visible = false;
            // 
            // backgroundWorkerCall
            // 
            this.backgroundWorkerCall.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerCall_DoWork);
            // 
            // m_callcancel
            // 
            this.m_callcancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_callcancel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.取消叫号ToolStripMenuItem,
            this.叫号ToolStripMenuItem,
            this.锁定处方ToolStripMenuItem,
            this.取消锁定ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.tsmiDrugInfo});
            this.m_callcancel.Name = "m_callcancel";
            this.m_callcancel.Size = new System.Drawing.Size(159, 120);
            // 
            // 取消叫号ToolStripMenuItem
            // 
            this.取消叫号ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("取消叫号ToolStripMenuItem.Image")));
            this.取消叫号ToolStripMenuItem.Name = "取消叫号ToolStripMenuItem";
            this.取消叫号ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.取消叫号ToolStripMenuItem.Text = "取消叫号";
            this.取消叫号ToolStripMenuItem.Click += new System.EventHandler(this.取消叫号ToolStripMenuItem_Click);
            // 
            // 叫号ToolStripMenuItem
            // 
            this.叫号ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("叫号ToolStripMenuItem.Image")));
            this.叫号ToolStripMenuItem.Name = "叫号ToolStripMenuItem";
            this.叫号ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.叫号ToolStripMenuItem.Text = "叫    号";
            this.叫号ToolStripMenuItem.Visible = false;
            // 
            // 锁定处方ToolStripMenuItem
            // 
            this.锁定处方ToolStripMenuItem.Name = "锁定处方ToolStripMenuItem";
            this.锁定处方ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.锁定处方ToolStripMenuItem.Text = "锁定处方";
            this.锁定处方ToolStripMenuItem.Visible = false;
            // 
            // 取消锁定ToolStripMenuItem
            // 
            this.取消锁定ToolStripMenuItem.Name = "取消锁定ToolStripMenuItem";
            this.取消锁定ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.取消锁定ToolStripMenuItem.Text = "取消锁定";
            this.取消锁定ToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(155, 6);
            // 
            // tsmiDrugInfo
            // 
            this.tsmiDrugInfo.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDrugInfo.Image")));
            this.tsmiDrugInfo.Name = "tsmiDrugInfo";
            this.tsmiDrugInfo.Size = new System.Drawing.Size(158, 22);
            this.tsmiDrugInfo.Text = "合理用药提示";
            this.tsmiDrugInfo.Click += new System.EventHandler(this.tsmiDrugInfo_Click);
            // 
            // panel12
            // 
            this.panel12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel12.BackColor = System.Drawing.Color.DimGray;
            this.panel12.Controls.Add(this.panel16);
            this.panel12.Controls.Add(this.panel15);
            this.panel12.Controls.Add(this.panel14);
            this.panel12.Controls.Add(this.panel13);
            this.panel12.Location = new System.Drawing.Point(1171, 250);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(207, 380);
            this.panel12.TabIndex = 19;
            this.panel12.Visible = false;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.Color.White;
            this.panel16.Controls.Add(this.CmdCancel4);
            this.panel16.Controls.Add(this.CmdSetEmp4);
            this.panel16.Controls.Add(this.txtPsw4);
            this.panel16.Controls.Add(this.txtEmpNo4);
            this.panel16.Controls.Add(this.label30);
            this.panel16.Controls.Add(this.label31);
            this.panel16.Location = new System.Drawing.Point(1, 283);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(205, 95);
            this.panel16.TabIndex = 3;
            // 
            // CmdCancel4
            // 
            this.CmdCancel4.BackColor = System.Drawing.Color.White;
            this.CmdCancel4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmdCancel4.ForeColor = System.Drawing.Color.Black;
            this.CmdCancel4.Location = new System.Drawing.Point(110, 64);
            this.CmdCancel4.Name = "CmdCancel4";
            this.CmdCancel4.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel4.TabIndex = 7;
            this.CmdCancel4.Text = "取消(&c)";
            this.CmdCancel4.UseVisualStyleBackColor = false;
            this.CmdCancel4.Click += new System.EventHandler(this.CmdCancel4_Click);
            // 
            // CmdSetEmp4
            // 
            this.CmdSetEmp4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmdSetEmp4.ForeColor = System.Drawing.Color.Black;
            this.CmdSetEmp4.Location = new System.Drawing.Point(25, 64);
            this.CmdSetEmp4.Name = "CmdSetEmp4";
            this.CmdSetEmp4.Size = new System.Drawing.Size(75, 23);
            this.CmdSetEmp4.TabIndex = 6;
            this.CmdSetEmp4.Text = "设置(&s)";
            this.CmdSetEmp4.UseVisualStyleBackColor = true;
            this.CmdSetEmp4.Click += new System.EventHandler(this.CmdSetEmp4_Click);
            // 
            // txtPsw4
            // 
            this.txtPsw4.BackColor = System.Drawing.Color.White;
            this.txtPsw4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPsw4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPsw4.ForeColor = System.Drawing.Color.Black;
            this.txtPsw4.Location = new System.Drawing.Point(84, 39);
            this.txtPsw4.MaxLength = 20;
            this.txtPsw4.Name = "txtPsw4";
            this.txtPsw4.PasswordChar = '＊';
            this.txtPsw4.Size = new System.Drawing.Size(102, 16);
            this.txtPsw4.TabIndex = 4;
            this.txtPsw4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPsw4_KeyDown);
            // 
            // txtEmpNo4
            // 
            this.txtEmpNo4.BackColor = System.Drawing.Color.White;
            this.txtEmpNo4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmpNo4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEmpNo4.ForeColor = System.Drawing.Color.Black;
            this.txtEmpNo4.Location = new System.Drawing.Point(85, 16);
            this.txtEmpNo4.MaxLength = 10;
            this.txtEmpNo4.Name = "txtEmpNo4";
            this.txtEmpNo4.Size = new System.Drawing.Size(101, 16);
            this.txtEmpNo4.TabIndex = 3;
            this.txtEmpNo4.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpNo4_KeyDown);
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.ForeColor = System.Drawing.Color.Black;
            this.label30.Location = new System.Drawing.Point(33, 41);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(49, 14);
            this.label30.TabIndex = 1;
            this.label30.Text = "密码：";
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.ForeColor = System.Drawing.Color.Black;
            this.label31.Location = new System.Drawing.Point(4, 17);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(77, 14);
            this.label31.TabIndex = 0;
            this.label31.Text = "<F4>工号：";
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.Color.White;
            this.panel15.Controls.Add(this.CmdCancel3);
            this.panel15.Controls.Add(this.CmdSetEmp3);
            this.panel15.Controls.Add(this.txtPsw3);
            this.panel15.Controls.Add(this.txtEmpNo3);
            this.panel15.Controls.Add(this.label28);
            this.panel15.Controls.Add(this.label29);
            this.panel15.Location = new System.Drawing.Point(1, 189);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(205, 95);
            this.panel15.TabIndex = 2;
            // 
            // CmdCancel3
            // 
            this.CmdCancel3.BackColor = System.Drawing.Color.White;
            this.CmdCancel3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmdCancel3.ForeColor = System.Drawing.Color.Black;
            this.CmdCancel3.Location = new System.Drawing.Point(110, 64);
            this.CmdCancel3.Name = "CmdCancel3";
            this.CmdCancel3.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel3.TabIndex = 7;
            this.CmdCancel3.Text = "取消(&c)";
            this.CmdCancel3.UseVisualStyleBackColor = false;
            this.CmdCancel3.Click += new System.EventHandler(this.CmdCancel3_Click);
            // 
            // CmdSetEmp3
            // 
            this.CmdSetEmp3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmdSetEmp3.ForeColor = System.Drawing.Color.Black;
            this.CmdSetEmp3.Location = new System.Drawing.Point(25, 64);
            this.CmdSetEmp3.Name = "CmdSetEmp3";
            this.CmdSetEmp3.Size = new System.Drawing.Size(75, 23);
            this.CmdSetEmp3.TabIndex = 6;
            this.CmdSetEmp3.Text = "设置(&s)";
            this.CmdSetEmp3.UseVisualStyleBackColor = true;
            this.CmdSetEmp3.Click += new System.EventHandler(this.CmdSetEmp3_Click);
            // 
            // txtPsw3
            // 
            this.txtPsw3.BackColor = System.Drawing.Color.White;
            this.txtPsw3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPsw3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPsw3.ForeColor = System.Drawing.Color.Black;
            this.txtPsw3.Location = new System.Drawing.Point(84, 39);
            this.txtPsw3.MaxLength = 20;
            this.txtPsw3.Name = "txtPsw3";
            this.txtPsw3.PasswordChar = '＊';
            this.txtPsw3.Size = new System.Drawing.Size(102, 16);
            this.txtPsw3.TabIndex = 4;
            this.txtPsw3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPsw3_KeyDown);
            // 
            // txtEmpNo3
            // 
            this.txtEmpNo3.BackColor = System.Drawing.Color.White;
            this.txtEmpNo3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmpNo3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEmpNo3.ForeColor = System.Drawing.Color.Black;
            this.txtEmpNo3.Location = new System.Drawing.Point(85, 16);
            this.txtEmpNo3.MaxLength = 10;
            this.txtEmpNo3.Name = "txtEmpNo3";
            this.txtEmpNo3.Size = new System.Drawing.Size(101, 16);
            this.txtEmpNo3.TabIndex = 3;
            this.txtEmpNo3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpNo3_KeyDown);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label28.ForeColor = System.Drawing.Color.Black;
            this.label28.Location = new System.Drawing.Point(19, 41);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(63, 14);
            this.label28.TabIndex = 1;
            this.label28.Text = "密　码：";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label29.ForeColor = System.Drawing.Color.Black;
            this.label29.Location = new System.Drawing.Point(5, 17);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(77, 14);
            this.label29.TabIndex = 0;
            this.label29.Text = "<F3>工号：";
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.Color.White;
            this.panel14.Controls.Add(this.CmdCancel2);
            this.panel14.Controls.Add(this.CmdSetEemp2);
            this.panel14.Controls.Add(this.txtPsw2);
            this.panel14.Controls.Add(this.txtEmpNo2);
            this.panel14.Controls.Add(this.label26);
            this.panel14.Controls.Add(this.label27);
            this.panel14.Location = new System.Drawing.Point(1, 95);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(205, 95);
            this.panel14.TabIndex = 1;
            // 
            // CmdCancel2
            // 
            this.CmdCancel2.BackColor = System.Drawing.Color.White;
            this.CmdCancel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmdCancel2.ForeColor = System.Drawing.Color.Black;
            this.CmdCancel2.Location = new System.Drawing.Point(110, 64);
            this.CmdCancel2.Name = "CmdCancel2";
            this.CmdCancel2.Size = new System.Drawing.Size(75, 23);
            this.CmdCancel2.TabIndex = 7;
            this.CmdCancel2.Text = "取消(&c)";
            this.CmdCancel2.UseVisualStyleBackColor = false;
            this.CmdCancel2.Click += new System.EventHandler(this.CmdCancel2_Click);
            // 
            // CmdSetEemp2
            // 
            this.CmdSetEemp2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CmdSetEemp2.ForeColor = System.Drawing.Color.Black;
            this.CmdSetEemp2.Location = new System.Drawing.Point(25, 64);
            this.CmdSetEemp2.Name = "CmdSetEemp2";
            this.CmdSetEemp2.Size = new System.Drawing.Size(75, 23);
            this.CmdSetEemp2.TabIndex = 6;
            this.CmdSetEemp2.Text = "设置(&s)";
            this.CmdSetEemp2.UseVisualStyleBackColor = true;
            this.CmdSetEemp2.Click += new System.EventHandler(this.CmdSetEemp2_Click);
            // 
            // txtPsw2
            // 
            this.txtPsw2.BackColor = System.Drawing.Color.White;
            this.txtPsw2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPsw2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPsw2.ForeColor = System.Drawing.Color.Black;
            this.txtPsw2.Location = new System.Drawing.Point(84, 39);
            this.txtPsw2.MaxLength = 20;
            this.txtPsw2.Name = "txtPsw2";
            this.txtPsw2.PasswordChar = '＊';
            this.txtPsw2.Size = new System.Drawing.Size(102, 16);
            this.txtPsw2.TabIndex = 4;
            this.txtPsw2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPsw2_KeyDown);
            // 
            // txtEmpNo2
            // 
            this.txtEmpNo2.BackColor = System.Drawing.Color.White;
            this.txtEmpNo2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmpNo2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEmpNo2.ForeColor = System.Drawing.Color.Black;
            this.txtEmpNo2.Location = new System.Drawing.Point(85, 16);
            this.txtEmpNo2.MaxLength = 10;
            this.txtEmpNo2.Name = "txtEmpNo2";
            this.txtEmpNo2.Size = new System.Drawing.Size(101, 16);
            this.txtEmpNo2.TabIndex = 3;
            this.txtEmpNo2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtEmpNo2_KeyDown);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.ForeColor = System.Drawing.Color.Black;
            this.label26.Location = new System.Drawing.Point(33, 41);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(49, 14);
            this.label26.TabIndex = 1;
            this.label26.Text = "密码：";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.ForeColor = System.Drawing.Color.Black;
            this.label27.Location = new System.Drawing.Point(5, 17);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(77, 14);
            this.label27.TabIndex = 0;
            this.label27.Text = "<F2>工号：";
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.Color.White;
            this.panel13.Controls.Add(this.button2);
            this.panel13.Controls.Add(this.button1);
            this.panel13.Controls.Add(this.textBox3);
            this.panel13.Controls.Add(this.textBox2);
            this.panel13.Controls.Add(this.label25);
            this.panel13.Controls.Add(this.label24);
            this.panel13.Location = new System.Drawing.Point(1, 1);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(205, 95);
            this.panel13.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(110, 64);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "取消(&c)";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(25, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "设置(&s)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.White;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(85, 39);
            this.textBox3.MaxLength = 20;
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '＊';
            this.textBox3.Size = new System.Drawing.Size(102, 16);
            this.textBox3.TabIndex = 4;
            this.textBox3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox3_KeyDown);
            this.textBox3.Leave += new System.EventHandler(this.textBox3_Leave);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.White;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(85, 16);
            this.textBox2.MaxLength = 10;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(101, 16);
            this.textBox2.TabIndex = 3;
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(31, 41);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(49, 14);
            this.label25.TabIndex = 1;
            this.label25.Text = "密码：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(3, 17);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(77, 14);
            this.label24.TabIndex = 0;
            this.label24.Text = "<F1>工号：";
            // 
            // buttonXP4
            // 
            this.buttonXP4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXP4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.buttonXP4.DefaultScheme = true;
            this.buttonXP4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP4.Hint = "";
            this.buttonXP4.Location = new System.Drawing.Point(1302, 688);
            this.buttonXP4.Name = "buttonXP4";
            this.buttonXP4.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP4.Size = new System.Drawing.Size(75, 32);
            this.buttonXP4.TabIndex = 30;
            this.buttonXP4.Text = "默认设置";
            this.buttonXP4.Click += new System.EventHandler(this.buttonXP4_Click);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.radioButton2);
            this.panel8.Controls.Add(this.radioButton1);
            this.panel8.Location = new System.Drawing.Point(276, 691);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(460, 23);
            this.panel8.TabIndex = 29;
            this.panel8.Visible = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(57, 2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(53, 18);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "反选";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(4, 1);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(53, 18);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "全选";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.m_txtDep);
            this.panel9.Controls.Add(this.label23);
            this.panel9.Location = new System.Drawing.Point(394, 689);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(158, 31);
            this.panel9.TabIndex = 17;
            // 
            // m_txtDep
            // 
            this.m_txtDep.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtDep.intHeight = 200;
            this.m_txtDep.IsEnterShow = true;
            this.m_txtDep.isHide = 4;
            this.m_txtDep.isTxt = 1;
            this.m_txtDep.isUpOrDn = 0;
            this.m_txtDep.isValuse = 4;
            this.m_txtDep.Location = new System.Drawing.Point(57, 5);
            this.m_txtDep.m_IsHaveParent = false;
            this.m_txtDep.m_strParentName = "";
            this.m_txtDep.Name = "m_txtDep";
            this.m_txtDep.nextCtl = this.m_cmdRefersh;
            this.m_txtDep.Size = new System.Drawing.Size(98, 24);
            this.m_txtDep.TabIndex = 3;
            this.m_txtDep.txtValuse = "";
            this.m_txtDep.VsLeftOrRight = 0;
            // 
            // m_cmdRefersh
            // 
            this.m_cmdRefersh.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_cmdRefersh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdRefersh.DefaultScheme = true;
            this.m_cmdRefersh.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdRefersh.Hint = "";
            this.m_cmdRefersh.Location = new System.Drawing.Point(869, 5);
            this.m_cmdRefersh.Name = "m_cmdRefersh";
            this.m_cmdRefersh.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdRefersh.Size = new System.Drawing.Size(98, 32);
            this.m_cmdRefersh.TabIndex = 5;
            this.m_cmdRefersh.Text = "手工刷新(&N)";
            this.m_cmdRefersh.Click += new System.EventHandler(this.m_cmdRefersh_Click);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(11, 9);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(49, 14);
            this.label23.TabIndex = 0;
            this.label23.Text = "科室：";
            // 
            // pnlotherSend
            // 
            this.pnlotherSend.Controls.Add(this.groupBox2);
            this.pnlotherSend.Location = new System.Drawing.Point(1007, 80);
            this.pnlotherSend.Name = "pnlotherSend";
            this.pnlotherSend.Size = new System.Drawing.Size(832, 472);
            this.pnlotherSend.TabIndex = 14;
            this.pnlotherSend.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnl1);
            this.groupBox2.Controls.Add(this.DgItem);
            this.groupBox2.Controls.Add(this.m_DgMed);
            this.groupBox2.Location = new System.Drawing.Point(25, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(840, 485);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // pnl1
            // 
            this.pnl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl1.Controls.Add(this.multiMoney);
            this.pnl1.Controls.Add(this.label11);
            this.pnl1.Controls.Add(this.MedMoney);
            this.pnl1.Controls.Add(this.label10);
            this.pnl1.Controls.Add(this.CullMoney);
            this.pnl1.Controls.Add(this.label8);
            this.pnl1.Controls.Add(this.btnSend);
            this.pnl1.Location = new System.Drawing.Point(8, 424);
            this.pnl1.Name = "pnl1";
            this.pnl1.Size = new System.Drawing.Size(829, 56);
            this.pnl1.TabIndex = 35;
            // 
            // multiMoney
            // 
            this.multiMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.multiMoney.ForeColor = System.Drawing.Color.OrangeRed;
            this.multiMoney.Location = new System.Drawing.Point(768, 16);
            this.multiMoney.Name = "multiMoney";
            this.multiMoney.Size = new System.Drawing.Size(56, 23);
            this.multiMoney.TabIndex = 14;
            this.multiMoney.Text = "0";
            this.multiMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label11.Location = new System.Drawing.Point(696, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 23);
            this.label11.TabIndex = 13;
            this.label11.Text = "余额：";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MedMoney
            // 
            this.MedMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.MedMoney.ForeColor = System.Drawing.Color.OrangeRed;
            this.MedMoney.Location = new System.Drawing.Point(640, 16);
            this.MedMoney.Name = "MedMoney";
            this.MedMoney.Size = new System.Drawing.Size(56, 23);
            this.MedMoney.TabIndex = 12;
            this.MedMoney.Text = "0";
            this.MedMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label10.Location = new System.Drawing.Point(536, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(112, 23);
            this.label10.TabIndex = 11;
            this.label10.Text = "药品金额：";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CullMoney
            // 
            this.CullMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CullMoney.ForeColor = System.Drawing.Color.OrangeRed;
            this.CullMoney.Location = new System.Drawing.Point(480, 16);
            this.CullMoney.Name = "CullMoney";
            this.CullMoney.Size = new System.Drawing.Size(56, 23);
            this.CullMoney.TabIndex = 10;
            this.CullMoney.Text = "0";
            this.CullMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label8.Location = new System.Drawing.Point(376, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 23);
            this.label8.TabIndex = 9;
            this.label8.Text = "当前金额：";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSend
            // 
            this.btnSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnSend.DefaultScheme = true;
            this.btnSend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSend.Hint = "";
            this.btnSend.Location = new System.Drawing.Point(264, 11);
            this.btnSend.Name = "btnSend";
            this.btnSend.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSend.Size = new System.Drawing.Size(99, 32);
            this.btnSend.TabIndex = 8;
            this.btnSend.Text = "发药(&S)";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // DgItem
            // 
            this.DgItem.AllowAddNew = false;
            this.DgItem.AllowDelete = false;
            this.DgItem.AutoAppendRow = false;
            this.DgItem.AutoScroll = true;
            this.DgItem.BackgroundColor = System.Drawing.SystemColors.Window;
            this.DgItem.CaptionText = "";
            this.DgItem.CaptionVisible = false;
            this.DgItem.ColumnHeadersVisible = true;
            clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo1.BackColor = System.Drawing.Color.White;
            clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo1.ColumnIndex = 0;
            clsColumnInfo1.ColumnName = "ITEMCODE_VCHR";
            clsColumnInfo1.ColumnWidth = 80;
            clsColumnInfo1.Enabled = false;
            clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo1.HeadText = "项目代码";
            clsColumnInfo1.ReadOnly = true;
            clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo2.BackColor = System.Drawing.Color.White;
            clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo2.ColumnIndex = 1;
            clsColumnInfo2.ColumnName = "ITEMNAME_VCHR";
            clsColumnInfo2.ColumnWidth = 212;
            clsColumnInfo2.Enabled = false;
            clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo2.HeadText = "项目名称";
            clsColumnInfo2.ReadOnly = true;
            clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo3.BackColor = System.Drawing.Color.White;
            clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo3.ColumnIndex = 2;
            clsColumnInfo3.ColumnName = "ITEMENGNAME_VCHR";
            clsColumnInfo3.ColumnWidth = 75;
            clsColumnInfo3.Enabled = false;
            clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo3.HeadText = "英文名称";
            clsColumnInfo3.ReadOnly = true;
            clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo4.BackColor = System.Drawing.Color.White;
            clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo4.ColumnIndex = 3;
            clsColumnInfo4.ColumnName = "ItemType";
            clsColumnInfo4.ColumnWidth = 40;
            clsColumnInfo4.Enabled = false;
            clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo4.HeadText = "类型";
            clsColumnInfo4.ReadOnly = true;
            clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo5.BackColor = System.Drawing.Color.White;
            clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo5.ColumnIndex = 4;
            clsColumnInfo5.ColumnName = "ITEMSPEC_VCHR";
            clsColumnInfo5.ColumnWidth = 150;
            clsColumnInfo5.Enabled = false;
            clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo5.HeadText = "规格";
            clsColumnInfo5.ReadOnly = true;
            clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo6.BackColor = System.Drawing.Color.White;
            clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo6.ColumnIndex = 5;
            clsColumnInfo6.ColumnName = "ITEMOPUNIT_CHR";
            clsColumnInfo6.ColumnWidth = 60;
            clsColumnInfo6.Enabled = false;
            clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo6.HeadText = "单位";
            clsColumnInfo6.ReadOnly = true;
            clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo7.BackColor = System.Drawing.Color.White;
            clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo7.ColumnIndex = 6;
            clsColumnInfo7.ColumnName = "submoney";
            clsColumnInfo7.ColumnWidth = 60;
            clsColumnInfo7.Enabled = false;
            clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo7.HeadText = "单价";
            clsColumnInfo7.ReadOnly = true;
            clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo8.BackColor = System.Drawing.Color.White;
            clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo8.ColumnIndex = 7;
            clsColumnInfo8.ColumnName = "ITEMPYCODE_CHR";
            clsColumnInfo8.ColumnWidth = 60;
            clsColumnInfo8.Enabled = false;
            clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo8.HeadText = "拼音码";
            clsColumnInfo8.ReadOnly = true;
            clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo9.BackColor = System.Drawing.Color.White;
            clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo9.ColumnIndex = 8;
            clsColumnInfo9.ColumnName = "ITEMWBCODE_CHR";
            clsColumnInfo9.ColumnWidth = 60;
            clsColumnInfo9.Enabled = false;
            clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo9.HeadText = "五笔码";
            clsColumnInfo9.ReadOnly = true;
            clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 10F);
            this.DgItem.Columns.Add(clsColumnInfo1);
            this.DgItem.Columns.Add(clsColumnInfo2);
            this.DgItem.Columns.Add(clsColumnInfo3);
            this.DgItem.Columns.Add(clsColumnInfo4);
            this.DgItem.Columns.Add(clsColumnInfo5);
            this.DgItem.Columns.Add(clsColumnInfo6);
            this.DgItem.Columns.Add(clsColumnInfo7);
            this.DgItem.Columns.Add(clsColumnInfo8);
            this.DgItem.Columns.Add(clsColumnInfo9);
            this.DgItem.FullRowSelect = true;
            this.DgItem.Location = new System.Drawing.Point(8, 232);
            this.DgItem.MultiSelect = false;
            this.DgItem.Name = "DgItem";
            this.DgItem.ReadOnly = false;
            this.DgItem.RowHeadersVisible = false;
            this.DgItem.RowHeaderWidth = 35;
            this.DgItem.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.DgItem.SelectedRowForeColor = System.Drawing.Color.White;
            this.DgItem.Size = new System.Drawing.Size(824, 192);
            this.DgItem.TabIndex = 36;
            this.DgItem.Visible = false;
            this.DgItem.m_evtDataGridKeyDown += new System.Windows.Forms.KeyEventHandler(this.DgItem_m_evtDataGridKeyDown);
            this.DgItem.Leave += new System.EventHandler(this.DgItem_Leave);
            // 
            // m_DgMed
            // 
            this.m_DgMed.AllowAddNew = true;
            this.m_DgMed.AllowDelete = true;
            this.m_DgMed.AutoAppendRow = false;
            this.m_DgMed.AutoScroll = true;
            this.m_DgMed.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_DgMed.CaptionText = "";
            this.m_DgMed.CaptionVisible = false;
            this.m_DgMed.ColumnHeadersVisible = true;
            clsColumnInfo10.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo10.BackColor = System.Drawing.Color.White;
            clsColumnInfo10.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo10.ColumnIndex = 0;
            clsColumnInfo10.ColumnName = "checkData";
            clsColumnInfo10.ColumnWidth = 75;
            clsColumnInfo10.Enabled = true;
            clsColumnInfo10.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo10.HeadText = "查询";
            clsColumnInfo10.ReadOnly = false;
            clsColumnInfo10.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo11.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo11.BackColor = System.Drawing.Color.White;
            clsColumnInfo11.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo11.ColumnIndex = 1;
            clsColumnInfo11.ColumnName = "ITEMENGNAME_VCHR";
            clsColumnInfo11.ColumnWidth = 212;
            clsColumnInfo11.Enabled = false;
            clsColumnInfo11.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo11.HeadText = "项目名称";
            clsColumnInfo11.ReadOnly = true;
            clsColumnInfo11.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo12.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo12.BackColor = System.Drawing.Color.White;
            clsColumnInfo12.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo12.ColumnIndex = 2;
            clsColumnInfo12.ColumnName = "ItemType";
            clsColumnInfo12.ColumnWidth = 60;
            clsColumnInfo12.Enabled = false;
            clsColumnInfo12.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo12.HeadText = "类型";
            clsColumnInfo12.ReadOnly = true;
            clsColumnInfo12.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo13.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo13.BackColor = System.Drawing.Color.White;
            clsColumnInfo13.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo13.ColumnIndex = 3;
            clsColumnInfo13.ColumnName = "ITEMSPEC_VCHR";
            clsColumnInfo13.ColumnWidth = 150;
            clsColumnInfo13.Enabled = false;
            clsColumnInfo13.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo13.HeadText = "规格";
            clsColumnInfo13.ReadOnly = false;
            clsColumnInfo13.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo14.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo14.BackColor = System.Drawing.Color.White;
            clsColumnInfo14.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo14.ColumnIndex = 4;
            clsColumnInfo14.ColumnName = "Qty_int";
            clsColumnInfo14.ColumnWidth = 60;
            clsColumnInfo14.Enabled = true;
            clsColumnInfo14.ForeColor = System.Drawing.Color.Red;
            clsColumnInfo14.HeadText = "数量";
            clsColumnInfo14.ReadOnly = false;
            clsColumnInfo14.TextFont = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Bold);
            clsColumnInfo15.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo15.BackColor = System.Drawing.Color.White;
            clsColumnInfo15.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo15.ColumnIndex = 5;
            clsColumnInfo15.ColumnName = "ITEMOPUNIT_CHR";
            clsColumnInfo15.ColumnWidth = 60;
            clsColumnInfo15.Enabled = false;
            clsColumnInfo15.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo15.HeadText = "单位";
            clsColumnInfo15.ReadOnly = true;
            clsColumnInfo15.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo16.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo16.BackColor = System.Drawing.Color.White;
            clsColumnInfo16.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo16.ColumnIndex = 6;
            clsColumnInfo16.ColumnName = "submoney";
            clsColumnInfo16.ColumnWidth = 85;
            clsColumnInfo16.Enabled = false;
            clsColumnInfo16.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo16.HeadText = "单价";
            clsColumnInfo16.ReadOnly = true;
            clsColumnInfo16.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo17.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo17.BackColor = System.Drawing.Color.White;
            clsColumnInfo17.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
            clsColumnInfo17.ColumnIndex = 7;
            clsColumnInfo17.ColumnName = "TolMoney";
            clsColumnInfo17.ColumnWidth = 85;
            clsColumnInfo17.Enabled = false;
            clsColumnInfo17.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo17.HeadText = "总价";
            clsColumnInfo17.ReadOnly = true;
            clsColumnInfo17.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo18.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo18.BackColor = System.Drawing.Color.White;
            clsColumnInfo18.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo18.ColumnIndex = 8;
            clsColumnInfo18.ColumnName = "ITEMID_CHR";
            clsColumnInfo18.ColumnWidth = 0;
            clsColumnInfo18.Enabled = false;
            clsColumnInfo18.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo18.HeadText = "ITEMID_CHR";
            clsColumnInfo18.ReadOnly = true;
            clsColumnInfo18.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo19.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo19.BackColor = System.Drawing.Color.White;
            clsColumnInfo19.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo19.ColumnIndex = 9;
            clsColumnInfo19.ColumnName = "ITEMSRCID_VCHR";
            clsColumnInfo19.ColumnWidth = 0;
            clsColumnInfo19.Enabled = true;
            clsColumnInfo19.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo19.HeadText = "ITEMSRCID_VCHR";
            clsColumnInfo19.ReadOnly = false;
            clsColumnInfo19.TextFont = new System.Drawing.Font("宋体", 10F);
            this.m_DgMed.Columns.Add(clsColumnInfo10);
            this.m_DgMed.Columns.Add(clsColumnInfo11);
            this.m_DgMed.Columns.Add(clsColumnInfo12);
            this.m_DgMed.Columns.Add(clsColumnInfo13);
            this.m_DgMed.Columns.Add(clsColumnInfo14);
            this.m_DgMed.Columns.Add(clsColumnInfo15);
            this.m_DgMed.Columns.Add(clsColumnInfo16);
            this.m_DgMed.Columns.Add(clsColumnInfo17);
            this.m_DgMed.Columns.Add(clsColumnInfo18);
            this.m_DgMed.Columns.Add(clsColumnInfo19);
            this.m_DgMed.Font = new System.Drawing.Font("宋体", 12F);
            this.m_DgMed.FullRowSelect = false;
            this.m_DgMed.Location = new System.Drawing.Point(11, 8);
            this.m_DgMed.MultiSelect = false;
            this.m_DgMed.Name = "m_DgMed";
            this.m_DgMed.ReadOnly = false;
            this.m_DgMed.RowHeadersVisible = false;
            this.m_DgMed.RowHeaderWidth = 35;
            this.m_DgMed.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.m_DgMed.SelectedRowForeColor = System.Drawing.Color.White;
            this.m_DgMed.Size = new System.Drawing.Size(826, 413);
            this.m_DgMed.TabIndex = 34;
            this.m_DgMed.m_evtDataGridTextBoxKeyDown += new com.digitalwave.controls.datagrid.clsDGTextKeyEventHandler(this.m_DgMed_m_evtDataGridTextBoxKeyDown);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.splitter1);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.panel2);
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1398, 678);
            this.panel6.TabIndex = 16;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(222, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1, 678);
            this.splitter1.TabIndex = 18;
            this.splitter1.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel4);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(222, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1176, 678);
            this.panel7.TabIndex = 17;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.groupBox3);
            this.panel4.Controls.Add(this.panel5);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1176, 678);
            this.panel4.TabIndex = 15;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.txtWechatCode);
            this.groupBox3.Controls.Add(this.lblWechatCode);
            this.groupBox3.Controls.Add(this.btnPrintYD);
            this.groupBox3.Controls.Add(this.btnDosage);
            this.groupBox3.Controls.Add(this.m_btnCaseHistory);
            this.groupBox3.Controls.Add(this.m_btnTreat);
            this.groupBox3.Controls.Add(this.m_btnPrint);
            this.groupBox3.Controls.Add(this.buttonXP5);
            this.groupBox3.Controls.Add(this.panel11);
            this.groupBox3.Controls.Add(this.buttonXP3);
            this.groupBox3.Controls.Add(this.btnPrintqe);
            this.groupBox3.Controls.Add(this.btnOtherSend);
            this.groupBox3.Controls.Add(this.btnPrint);
            this.groupBox3.Controls.Add(this.btnOther);
            this.groupBox3.Controls.Add(this.btnSendMed);
            this.groupBox3.Location = new System.Drawing.Point(2, 597);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 1, 3, 3);
            this.groupBox3.Size = new System.Drawing.Size(1158, 81);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            // 
            // txtWechatCode
            // 
            this.txtWechatCode.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.txtWechatCode.ForeColor = System.Drawing.Color.Red;
            this.txtWechatCode.Location = new System.Drawing.Point(684, 50);
            this.txtWechatCode.MaxLength = 30;
            this.txtWechatCode.Name = "txtWechatCode";
            this.txtWechatCode.Size = new System.Drawing.Size(182, 26);
            this.txtWechatCode.TabIndex = 26;
            this.txtWechatCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWechatCode.TextChanged += new System.EventHandler(this.txtWechatCode_TextChanged);
            this.txtWechatCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWechatCode_KeyDown);
            // 
            // lblWechatCode
            // 
            this.lblWechatCode.ForeColor = System.Drawing.Color.Maroon;
            this.lblWechatCode.Location = new System.Drawing.Point(679, 21);
            this.lblWechatCode.Name = "lblWechatCode";
            this.lblWechatCode.Size = new System.Drawing.Size(166, 22);
            this.lblWechatCode.TabIndex = 24;
            this.lblWechatCode.Text = "发药扫码处:";
            this.lblWechatCode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnPrintYD
            // 
            this.btnPrintYD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPrintYD.DefaultScheme = true;
            this.btnPrintYD.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintYD.Hint = "";
            this.btnPrintYD.Location = new System.Drawing.Point(585, 47);
            this.btnPrintYD.Name = "btnPrintYD";
            this.btnPrintYD.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrintYD.Size = new System.Drawing.Size(85, 30);
            this.btnPrintYD.TabIndex = 23;
            this.btnPrintYD.Text = "打药袋(&Y)";
            this.btnPrintYD.Click += new System.EventHandler(this.btnPrintYD_Click);
            // 
            // btnDosage
            // 
            this.btnDosage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnDosage.DefaultScheme = true;
            this.btnDosage.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDosage.Hint = "";
            this.btnDosage.Location = new System.Drawing.Point(170, 14);
            this.btnDosage.Name = "btnDosage";
            this.btnDosage.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDosage.Size = new System.Drawing.Size(85, 30);
            this.btnDosage.TabIndex = 15;
            this.btnDosage.Text = "配药(&P)";
            this.btnDosage.Click += new System.EventHandler(this.btnDosage_Click);
            // 
            // m_btnCaseHistory
            // 
            this.m_btnCaseHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnCaseHistory.DefaultScheme = true;
            this.m_btnCaseHistory.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnCaseHistory.Hint = "";
            this.m_btnCaseHistory.Location = new System.Drawing.Point(385, 48);
            this.m_btnCaseHistory.Name = "m_btnCaseHistory";
            this.m_btnCaseHistory.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCaseHistory.Size = new System.Drawing.Size(85, 30);
            this.m_btnCaseHistory.TabIndex = 22;
            this.m_btnCaseHistory.Text = "病历(&B)";
            this.m_btnCaseHistory.Click += new System.EventHandler(this.m_btnCaseHistory_Click);
            // 
            // m_btnTreat
            // 
            this.m_btnTreat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnTreat.DefaultScheme = true;
            this.m_btnTreat.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnTreat.Hint = "";
            this.m_btnTreat.Location = new System.Drawing.Point(170, 48);
            this.m_btnTreat.Name = "m_btnTreat";
            this.m_btnTreat.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnTreat.Size = new System.Drawing.Size(85, 30);
            this.m_btnTreat.TabIndex = 21;
            this.m_btnTreat.Text = "治疗单(&M)";
            this.m_btnTreat.Click += new System.EventHandler(this.m_btnTreat_Click);
            // 
            // m_btnPrint
            // 
            this.m_btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnPrint.DefaultScheme = true;
            this.m_btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPrint.Hint = "";
            this.m_btnPrint.Location = new System.Drawing.Point(485, 48);
            this.m_btnPrint.Name = "m_btnPrint";
            this.m_btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPrint.Size = new System.Drawing.Size(85, 30);
            this.m_btnPrint.TabIndex = 19;
            this.m_btnPrint.Text = "打处方(&L)";
            this.m_btnPrint.Click += new System.EventHandler(this.m_btnPrint_Click);
            // 
            // buttonXP5
            // 
            this.buttonXP5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.buttonXP5.DefaultScheme = true;
            this.buttonXP5.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP5.Hint = "";
            this.buttonXP5.Location = new System.Drawing.Point(270, 14);
            this.buttonXP5.Name = "buttonXP5";
            this.buttonXP5.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP5.Size = new System.Drawing.Size(100, 30);
            this.buttonXP5.TabIndex = 18;
            this.buttonXP5.Text = "默认配药(&D)";
            this.buttonXP5.Click += new System.EventHandler(this.buttonXP5_Click);
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.m_btnPause);
            this.panel11.Controls.Add(this.m_btnCall);
            this.panel11.Location = new System.Drawing.Point(2, 12);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(156, 36);
            this.panel11.TabIndex = 17;
            // 
            // m_btnPause
            // 
            this.m_btnPause.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnPause.DefaultScheme = true;
            this.m_btnPause.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnPause.Hint = "";
            this.m_btnPause.Location = new System.Drawing.Point(3, 2);
            this.m_btnPause.Name = "m_btnPause";
            this.m_btnPause.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnPause.Size = new System.Drawing.Size(70, 30);
            this.m_btnPause.TabIndex = 21;
            this.m_btnPause.Tag = "pause";
            this.m_btnPause.Text = "暂停(&P)";
            this.m_btnPause.TextChanged += new System.EventHandler(this.m_btnPause_TextChanged);
            this.m_btnPause.Click += new System.EventHandler(this.m_btnPause_Click);
            // 
            // m_btnCall
            // 
            this.m_btnCall.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_btnCall.DefaultScheme = true;
            this.m_btnCall.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnCall.Hint = "";
            this.m_btnCall.Location = new System.Drawing.Point(79, 2);
            this.m_btnCall.Name = "m_btnCall";
            this.m_btnCall.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnCall.Size = new System.Drawing.Size(70, 30);
            this.m_btnCall.TabIndex = 20;
            this.m_btnCall.Text = "叫号(&C)";
            this.m_btnCall.Click += new System.EventHandler(this.m_btnCall_Click);
            // 
            // buttonXP3
            // 
            this.buttonXP3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.buttonXP3.DefaultScheme = true;
            this.buttonXP3.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP3.Hint = "";
            this.buttonXP3.Location = new System.Drawing.Point(270, 48);
            this.buttonXP3.Name = "buttonXP3";
            this.buttonXP3.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP3.Size = new System.Drawing.Size(100, 30);
            this.buttonXP3.TabIndex = 16;
            this.buttonXP3.Text = "贴瓶单(&T)";
            this.buttonXP3.Click += new System.EventHandler(this.buttonXP3_Click);
            // 
            // btnPrintqe
            // 
            this.btnPrintqe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPrintqe.DefaultScheme = true;
            this.btnPrintqe.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrintqe.Hint = "";
            this.btnPrintqe.Location = new System.Drawing.Point(585, 14);
            this.btnPrintqe.Name = "btnPrintqe";
            this.btnPrintqe.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrintqe.Size = new System.Drawing.Size(85, 30);
            this.btnPrintqe.TabIndex = 13;
            this.btnPrintqe.Text = "注射单(&I)";
            this.btnPrintqe.Click += new System.EventHandler(this.btnPrintqe_Click);
            // 
            // btnOtherSend
            // 
            this.btnOtherSend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnOtherSend.DefaultScheme = true;
            this.btnOtherSend.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOtherSend.Hint = "";
            this.btnOtherSend.Location = new System.Drawing.Point(8, 16);
            this.btnOtherSend.Name = "btnOtherSend";
            this.btnOtherSend.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOtherSend.Size = new System.Drawing.Size(88, 32);
            this.btnOtherSend.TabIndex = 12;
            this.btnOtherSend.Text = "其它发药(&O)";
            this.btnOtherSend.Click += new System.EventHandler(this.btnOtherSend_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnPrint.DefaultScheme = true;
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnPrint.Hint = "";
            this.btnPrint.Location = new System.Drawing.Point(485, 14);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnPrint.Size = new System.Drawing.Size(85, 30);
            this.btnPrint.TabIndex = 10;
            this.btnPrint.Text = "发药单(&H)";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnOther
            // 
            this.btnOther.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnOther.DefaultScheme = true;
            this.btnOther.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnOther.Hint = "";
            this.btnOther.Location = new System.Drawing.Point(8, 16);
            this.btnOther.Name = "btnOther";
            this.btnOther.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnOther.Size = new System.Drawing.Size(88, 32);
            this.btnOther.TabIndex = 8;
            this.btnOther.Text = "其它明细(&D)";
            this.btnOther.Click += new System.EventHandler(this.btnOther_Click);
            // 
            // btnSendMed
            // 
            this.btnSendMed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnSendMed.DefaultScheme = true;
            this.btnSendMed.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSendMed.Hint = "";
            this.btnSendMed.Location = new System.Drawing.Point(385, 14);
            this.btnSendMed.Name = "btnSendMed";
            this.btnSendMed.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSendMed.Size = new System.Drawing.Size(85, 30);
            this.btnSendMed.TabIndex = 7;
            this.btnSendMed.Text = "发药(&S)";
            this.btnSendMed.Click += new System.EventHandler(this.btnSendMed_Click);
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel5.Controls.Add(this.m_chkMedBag);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.m_chkHistory);
            this.panel5.Controls.Add(this.m_chkTreatTip);
            this.panel5.Controls.Add(this.m_chkCorlor);
            this.panel5.Controls.Add(this.checkBox4);
            this.panel5.Controls.Add(this.checkBox3);
            this.panel5.Controls.Add(this.checkBox1);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Controls.Add(this.m_chkShowScreen);
            this.panel5.Controls.Add(this.radMat);
            this.panel5.Controls.Add(this.checkBox2);
            this.panel5.Controls.Add(this.label14);
            this.panel5.Controls.Add(this.m_txtMedStore);
            this.panel5.Controls.Add(this.m_cmdRefersh);
            this.panel5.Controls.Add(this.rdbWest);
            this.panel5.Controls.Add(this.rdbChina);
            this.panel5.Controls.Add(this.cbWindows);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Controls.Add(this.m_nudRefershTime);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Location = new System.Drawing.Point(2, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1157, 46);
            this.panel5.TabIndex = 13;
            // 
            // m_chkMedBag
            // 
            this.m_chkMedBag.BackColor = System.Drawing.Color.Transparent;
            this.m_chkMedBag.Location = new System.Drawing.Point(306, 4);
            this.m_chkMedBag.Margin = new System.Windows.Forms.Padding(0);
            this.m_chkMedBag.Name = "m_chkMedBag";
            this.m_chkMedBag.Size = new System.Drawing.Size(54, 21);
            this.m_chkMedBag.TabIndex = 29;
            this.m_chkMedBag.Text = "药袋";
            this.m_chkMedBag.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(679, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "药房";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_chkHistory
            // 
            this.m_chkHistory.Enabled = false;
            this.m_chkHistory.Location = new System.Drawing.Point(240, 24);
            this.m_chkHistory.Margin = new System.Windows.Forms.Padding(0);
            this.m_chkHistory.Name = "m_chkHistory";
            this.m_chkHistory.Size = new System.Drawing.Size(68, 21);
            this.m_chkHistory.TabIndex = 28;
            this.m_chkHistory.Text = "病历单";
            this.m_chkHistory.UseVisualStyleBackColor = true;
            // 
            // m_chkTreatTip
            // 
            this.m_chkTreatTip.Enabled = false;
            this.m_chkTreatTip.Location = new System.Drawing.Point(176, 24);
            this.m_chkTreatTip.Margin = new System.Windows.Forms.Padding(0);
            this.m_chkTreatTip.Name = "m_chkTreatTip";
            this.m_chkTreatTip.Size = new System.Drawing.Size(68, 21);
            this.m_chkTreatTip.TabIndex = 21;
            this.m_chkTreatTip.Text = "治疗单";
            this.m_chkTreatTip.UseVisualStyleBackColor = true;
            // 
            // m_chkCorlor
            // 
            this.m_chkCorlor.Checked = true;
            this.m_chkCorlor.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkCorlor.Location = new System.Drawing.Point(97, 24);
            this.m_chkCorlor.Margin = new System.Windows.Forms.Padding(0);
            this.m_chkCorlor.Name = "m_chkCorlor";
            this.m_chkCorlor.Size = new System.Drawing.Size(83, 21);
            this.m_chkCorlor.TabIndex = 26;
            this.m_chkCorlor.Text = "处方颜色 ";
            // 
            // checkBox4
            // 
            this.checkBox4.Enabled = false;
            this.checkBox4.Location = new System.Drawing.Point(240, 4);
            this.checkBox4.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(68, 21);
            this.checkBox4.TabIndex = 1;
            this.checkBox4.Text = "贴瓶单";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.Enabled = false;
            this.checkBox3.Location = new System.Drawing.Point(176, 4);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(68, 21);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "注射单";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(97, 4);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(83, 21);
            this.checkBox1.TabIndex = 12;
            this.checkBox1.Text = "显示退票";
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(634, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "窗口";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_chkShowScreen
            // 
            this.m_chkShowScreen.Enabled = false;
            this.m_chkShowScreen.Location = new System.Drawing.Point(2, 24);
            this.m_chkShowScreen.Margin = new System.Windows.Forms.Padding(0);
            this.m_chkShowScreen.Name = "m_chkShowScreen";
            this.m_chkShowScreen.Size = new System.Drawing.Size(98, 21);
            this.m_chkShowScreen.TabIndex = 27;
            this.m_chkShowScreen.Text = "预览电子屏";
            this.m_chkShowScreen.CheckedChanged += new System.EventHandler(this.m_chkShowScreen_CheckedChanged);
            // 
            // radMat
            // 
            this.radMat.Location = new System.Drawing.Point(176, 40);
            this.radMat.Name = "radMat";
            this.radMat.Size = new System.Drawing.Size(104, 24);
            this.radMat.TabIndex = 24;
            this.radMat.Text = "材料";
            // 
            // checkBox2
            // 
            this.checkBox2.Location = new System.Drawing.Point(2, 4);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(0);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(98, 21);
            this.checkBox2.TabIndex = 23;
            this.checkBox2.Text = "自动发药单";
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label14.Location = new System.Drawing.Point(355, 39);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 1);
            this.label14.TabIndex = 22;
            // 
            // m_txtMedStore
            // 
            this.m_txtMedStore.BackColor = System.Drawing.Color.Transparent;
            this.m_txtMedStore.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtMedStore.ForeColor = System.Drawing.Color.ForestGreen;
            this.m_txtMedStore.Location = new System.Drawing.Point(355, 15);
            this.m_txtMedStore.Name = "m_txtMedStore";
            this.m_txtMedStore.Size = new System.Drawing.Size(103, 22);
            this.m_txtMedStore.TabIndex = 21;
            this.m_txtMedStore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rdbWest
            // 
            this.rdbWest.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdbWest.Enabled = false;
            this.rdbWest.Location = new System.Drawing.Point(232, 43);
            this.rdbWest.Name = "rdbWest";
            this.rdbWest.Size = new System.Drawing.Size(56, 24);
            this.rdbWest.TabIndex = 8;
            this.rdbWest.Text = "西药";
            // 
            // rdbChina
            // 
            this.rdbChina.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.rdbChina.Enabled = false;
            this.rdbChina.Location = new System.Drawing.Point(288, 43);
            this.rdbChina.Name = "rdbChina";
            this.rdbChina.Size = new System.Drawing.Size(56, 24);
            this.rdbChina.TabIndex = 9;
            this.rdbChina.Text = "中药";
            // 
            // cbWindows
            // 
            this.cbWindows.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbWindows.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWindows.Location = new System.Drawing.Point(669, 11);
            this.cbWindows.Name = "cbWindows";
            this.cbWindows.Size = new System.Drawing.Size(72, 22);
            this.cbWindows.TabIndex = 11;
            this.cbWindows.SelectedIndexChanged += new System.EventHandler(this.cbWindows_SelectedIndexChanged);
            this.cbWindows.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbWindows_KeyDown);
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(848, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "秒";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_nudRefershTime
            // 
            this.m_nudRefershTime.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_nudRefershTime.Location = new System.Drawing.Point(807, 11);
            this.m_nudRefershTime.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.m_nudRefershTime.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.m_nudRefershTime.Name = "m_nudRefershTime";
            this.m_nudRefershTime.Size = new System.Drawing.Size(40, 23);
            this.m_nudRefershTime.TabIndex = 3;
            this.m_nudRefershTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_nudRefershTime.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_nudRefershTime.ValueChanged += new System.EventHandler(this.m_nudRefershTime_ValueChanged);
            this.m_nudRefershTime.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_nudRefershTime_KeyDown);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(743, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "刷新时间";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.m_lsvMedicineDetail);
            this.panel3.Controls.Add(this.groupBox4);
            this.panel3.Controls.Add(this.m_lsvOpRecDetail);
            this.panel3.Controls.Add(this.gbItem);
            this.panel3.Location = new System.Drawing.Point(-8, -32);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1190, 657);
            this.panel3.TabIndex = 12;
            // 
            // m_lsvMedicineDetail
            // 
            this.m_lsvMedicineDetail.Alignment = System.Windows.Forms.ListViewAlignment.SnapToGrid;
            this.m_lsvMedicineDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvMedicineDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.项目规格});
            this.m_lsvMedicineDetail.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvMedicineDetail.FullRowSelect = true;
            this.m_lsvMedicineDetail.GridLines = true;
            this.m_lsvMedicineDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvMedicineDetail.Location = new System.Drawing.Point(8, 176);
            this.m_lsvMedicineDetail.Name = "m_lsvMedicineDetail";
            this.m_lsvMedicineDetail.Size = new System.Drawing.Size(1159, 452);
            this.m_lsvMedicineDetail.SmallImageList = this.imageList1;
            this.m_lsvMedicineDetail.TabIndex = 3;
            this.m_lsvMedicineDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvMedicineDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "项目名称";
            this.columnHeader5.Width = 250;
            // 
            // 项目规格
            // 
            this.项目规格.Text = "项目规格";
            this.项目规格.Width = 200;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.PatientType);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.CheckMoney);
            this.groupBox4.Controls.Add(this.ChinaMoney);
            this.groupBox4.Controls.Add(this.ChAndEN);
            this.groupBox4.Controls.Add(this.WestMoney);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.WestMoney11);
            this.groupBox4.Location = new System.Drawing.Point(862, 72);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(306, 104);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label13.Location = new System.Drawing.Point(80, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(224, 1);
            this.label13.TabIndex = 20;
            // 
            // PatientType
            // 
            this.PatientType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PatientType.ForeColor = System.Drawing.Color.OrangeRed;
            this.PatientType.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PatientType.Location = new System.Drawing.Point(80, 16);
            this.PatientType.Name = "PatientType";
            this.PatientType.Size = new System.Drawing.Size(224, 23);
            this.PatientType.TabIndex = 19;
            this.PatientType.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label9.Location = new System.Drawing.Point(8, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 24);
            this.label9.TabIndex = 18;
            this.label9.Text = "病人类型";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label18.Location = new System.Drawing.Point(168, 72);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 23);
            this.label18.TabIndex = 16;
            this.label18.Text = "治疗费";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label16.Location = new System.Drawing.Point(168, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(56, 23);
            this.label16.TabIndex = 14;
            this.label16.Text = "中药费";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckMoney
            // 
            this.CheckMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CheckMoney.ForeColor = System.Drawing.Color.OrangeRed;
            this.CheckMoney.Location = new System.Drawing.Point(220, 72);
            this.CheckMoney.Name = "CheckMoney";
            this.CheckMoney.Size = new System.Drawing.Size(80, 23);
            this.CheckMoney.TabIndex = 17;
            this.CheckMoney.Text = "0";
            this.CheckMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChinaMoney
            // 
            this.ChinaMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChinaMoney.ForeColor = System.Drawing.Color.OrangeRed;
            this.ChinaMoney.Location = new System.Drawing.Point(220, 40);
            this.ChinaMoney.Name = "ChinaMoney";
            this.ChinaMoney.Size = new System.Drawing.Size(80, 23);
            this.ChinaMoney.TabIndex = 15;
            this.ChinaMoney.Text = "0";
            this.ChinaMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChAndEN
            // 
            this.ChAndEN.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ChAndEN.ForeColor = System.Drawing.Color.OrangeRed;
            this.ChAndEN.Location = new System.Drawing.Point(80, 72);
            this.ChAndEN.Name = "ChAndEN";
            this.ChAndEN.Size = new System.Drawing.Size(88, 23);
            this.ChAndEN.TabIndex = 13;
            this.ChAndEN.Text = "0";
            this.ChAndEN.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WestMoney
            // 
            this.WestMoney.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WestMoney.ForeColor = System.Drawing.Color.OrangeRed;
            this.WestMoney.Location = new System.Drawing.Point(80, 40);
            this.WestMoney.Name = "WestMoney";
            this.WestMoney.Size = new System.Drawing.Size(88, 23);
            this.WestMoney.TabIndex = 12;
            this.WestMoney.Text = "0";
            this.WestMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label12.Location = new System.Drawing.Point(8, 72);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 23);
            this.label12.TabIndex = 11;
            this.label12.Text = "中成药费";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WestMoney11
            // 
            this.WestMoney11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.WestMoney11.ForeColor = System.Drawing.SystemColors.Desktop;
            this.WestMoney11.Location = new System.Drawing.Point(8, 40);
            this.WestMoney11.Name = "WestMoney11";
            this.WestMoney11.Size = new System.Drawing.Size(72, 23);
            this.WestMoney11.TabIndex = 10;
            this.WestMoney11.Text = "西 药 费";
            this.WestMoney11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_lsvOpRecDetail
            // 
            this.m_lsvOpRecDetail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lsvOpRecDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader17,
            this.columnHeader9,
            this.columnHeader7,
            this.colMedStore,
            this.colPei,
            this.colfa});
            this.m_lsvOpRecDetail.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvOpRecDetail.FullRowSelect = true;
            this.m_lsvOpRecDetail.GridLines = true;
            this.m_lsvOpRecDetail.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvOpRecDetail.Location = new System.Drawing.Point(8, 80);
            this.m_lsvOpRecDetail.Name = "m_lsvOpRecDetail";
            this.m_lsvOpRecDetail.Size = new System.Drawing.Size(848, 96);
            this.m_lsvOpRecDetail.TabIndex = 4;
            this.m_lsvOpRecDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvOpRecDetail.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "门诊处方号";
            this.columnHeader10.Width = 175;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "医生";
            this.columnHeader11.Width = 105;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "科室";
            this.columnHeader12.Width = 100;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "配药人";
            this.columnHeader17.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.DisplayIndex = 5;
            this.columnHeader9.Text = "发药人";
            this.columnHeader9.Width = 75;
            // 
            // columnHeader7
            // 
            this.columnHeader7.DisplayIndex = 4;
            this.columnHeader7.Text = "总金额";
            this.columnHeader7.Width = 0;
            // 
            // colMedStore
            // 
            this.colMedStore.Text = "药房";
            // 
            // colPei
            // 
            this.colPei.Text = "配药窗口";
            this.colPei.Width = 120;
            // 
            // colfa
            // 
            this.colfa.Text = "发药窗口";
            this.colfa.Width = 120;
            // 
            // gbItem
            // 
            this.gbItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbItem.BackColor = System.Drawing.SystemColors.Window;
            this.gbItem.Controls.Add(this.dgpatientcnkre);
            this.gbItem.Controls.Add(this.dgpatientest);
            this.gbItem.Controls.Add(this.dgpatienOpsre);
            this.gbItem.Controls.Add(this.dgpatienothre);
            this.gbItem.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbItem.Location = new System.Drawing.Point(-208, 470);
            this.gbItem.Name = "gbItem";
            this.gbItem.Size = new System.Drawing.Size(1396, 173);
            this.gbItem.TabIndex = 8;
            this.gbItem.TabStop = false;
            this.gbItem.Text = "项目其它收费 ESC-退出";
            this.gbItem.Visible = false;
            // 
            // dgpatientcnkre
            // 
            this.dgpatientcnkre.AllowAddNew = false;
            this.dgpatientcnkre.AllowDelete = false;
            this.dgpatientcnkre.AutoAppendRow = true;
            this.dgpatientcnkre.AutoScroll = true;
            this.dgpatientcnkre.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgpatientcnkre.CaptionText = "检验处方明细";
            this.dgpatientcnkre.CaptionVisible = true;
            this.dgpatientcnkre.ColumnHeadersVisible = true;
            clsColumnInfo20.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo20.BackColor = System.Drawing.Color.White;
            clsColumnInfo20.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo20.ColumnIndex = 0;
            clsColumnInfo20.ColumnName = "项目名称";
            clsColumnInfo20.ColumnWidth = 200;
            clsColumnInfo20.Enabled = false;
            clsColumnInfo20.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo20.HeadText = "项目名称";
            clsColumnInfo20.ReadOnly = true;
            clsColumnInfo20.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo21.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo21.BackColor = System.Drawing.Color.White;
            clsColumnInfo21.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo21.ColumnIndex = 1;
            clsColumnInfo21.ColumnName = "执行部门";
            clsColumnInfo21.ColumnWidth = 120;
            clsColumnInfo21.Enabled = false;
            clsColumnInfo21.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo21.HeadText = "执行部门";
            clsColumnInfo21.ReadOnly = true;
            clsColumnInfo21.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo22.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo22.BackColor = System.Drawing.Color.White;
            clsColumnInfo22.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo22.ColumnIndex = 2;
            clsColumnInfo22.ColumnName = "价格";
            clsColumnInfo22.ColumnWidth = 75;
            clsColumnInfo22.Enabled = false;
            clsColumnInfo22.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo22.HeadText = "价格";
            clsColumnInfo22.ReadOnly = true;
            clsColumnInfo22.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo23.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo23.BackColor = System.Drawing.Color.White;
            clsColumnInfo23.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo23.ColumnIndex = 3;
            clsColumnInfo23.ColumnName = "折扣";
            clsColumnInfo23.ColumnWidth = 75;
            clsColumnInfo23.Enabled = false;
            clsColumnInfo23.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo23.HeadText = "折扣";
            clsColumnInfo23.ReadOnly = true;
            clsColumnInfo23.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo24.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo24.BackColor = System.Drawing.Color.White;
            clsColumnInfo24.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo24.ColumnIndex = 4;
            clsColumnInfo24.ColumnName = "总价";
            clsColumnInfo24.ColumnWidth = 90;
            clsColumnInfo24.Enabled = false;
            clsColumnInfo24.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo24.HeadText = "总价";
            clsColumnInfo24.ReadOnly = true;
            clsColumnInfo24.TextFont = new System.Drawing.Font("宋体", 10F);
            this.dgpatientcnkre.Columns.Add(clsColumnInfo20);
            this.dgpatientcnkre.Columns.Add(clsColumnInfo21);
            this.dgpatientcnkre.Columns.Add(clsColumnInfo22);
            this.dgpatientcnkre.Columns.Add(clsColumnInfo23);
            this.dgpatientcnkre.Columns.Add(clsColumnInfo24);
            this.dgpatientcnkre.FullRowSelect = false;
            this.dgpatientcnkre.Location = new System.Drawing.Point(16, 120);
            this.dgpatientcnkre.MultiSelect = false;
            this.dgpatientcnkre.Name = "dgpatientcnkre";
            this.dgpatientcnkre.ReadOnly = false;
            this.dgpatientcnkre.RowHeadersVisible = true;
            this.dgpatientcnkre.RowHeaderWidth = 35;
            this.dgpatientcnkre.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.dgpatientcnkre.SelectedRowForeColor = System.Drawing.Color.White;
            this.dgpatientcnkre.Size = new System.Drawing.Size(674, 80);
            this.dgpatientcnkre.TabIndex = 12;
            this.dgpatientcnkre.Visible = false;
            // 
            // dgpatientest
            // 
            this.dgpatientest.AllowAddNew = false;
            this.dgpatientest.AllowDelete = false;
            this.dgpatientest.AutoAppendRow = true;
            this.dgpatientest.AutoScroll = true;
            this.dgpatientest.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgpatientest.CaptionText = "检查处方明细";
            this.dgpatientest.CaptionVisible = true;
            this.dgpatientest.ColumnHeadersVisible = true;
            clsColumnInfo25.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo25.BackColor = System.Drawing.Color.White;
            clsColumnInfo25.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo25.ColumnIndex = 0;
            clsColumnInfo25.ColumnName = "项目名称";
            clsColumnInfo25.ColumnWidth = 200;
            clsColumnInfo25.Enabled = false;
            clsColumnInfo25.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo25.HeadText = "项目名称";
            clsColumnInfo25.ReadOnly = true;
            clsColumnInfo25.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo26.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo26.BackColor = System.Drawing.Color.White;
            clsColumnInfo26.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo26.ColumnIndex = 1;
            clsColumnInfo26.ColumnName = "执行部门";
            clsColumnInfo26.ColumnWidth = 120;
            clsColumnInfo26.Enabled = false;
            clsColumnInfo26.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo26.HeadText = "执行部门";
            clsColumnInfo26.ReadOnly = true;
            clsColumnInfo26.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo27.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo27.BackColor = System.Drawing.Color.White;
            clsColumnInfo27.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo27.ColumnIndex = 2;
            clsColumnInfo27.ColumnName = "价格";
            clsColumnInfo27.ColumnWidth = 75;
            clsColumnInfo27.Enabled = false;
            clsColumnInfo27.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo27.HeadText = "价格";
            clsColumnInfo27.ReadOnly = true;
            clsColumnInfo27.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo28.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo28.BackColor = System.Drawing.Color.White;
            clsColumnInfo28.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo28.ColumnIndex = 3;
            clsColumnInfo28.ColumnName = "折扣";
            clsColumnInfo28.ColumnWidth = 75;
            clsColumnInfo28.Enabled = false;
            clsColumnInfo28.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo28.HeadText = "折扣";
            clsColumnInfo28.ReadOnly = true;
            clsColumnInfo28.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo29.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo29.BackColor = System.Drawing.Color.White;
            clsColumnInfo29.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo29.ColumnIndex = 4;
            clsColumnInfo29.ColumnName = "总价";
            clsColumnInfo29.ColumnWidth = 90;
            clsColumnInfo29.Enabled = false;
            clsColumnInfo29.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo29.HeadText = "总价";
            clsColumnInfo29.ReadOnly = true;
            clsColumnInfo29.TextFont = new System.Drawing.Font("宋体", 10F);
            this.dgpatientest.Columns.Add(clsColumnInfo25);
            this.dgpatientest.Columns.Add(clsColumnInfo26);
            this.dgpatientest.Columns.Add(clsColumnInfo27);
            this.dgpatientest.Columns.Add(clsColumnInfo28);
            this.dgpatientest.Columns.Add(clsColumnInfo29);
            this.dgpatientest.FullRowSelect = false;
            this.dgpatientest.Location = new System.Drawing.Point(8, 80);
            this.dgpatientest.MultiSelect = false;
            this.dgpatientest.Name = "dgpatientest";
            this.dgpatientest.ReadOnly = false;
            this.dgpatientest.RowHeadersVisible = true;
            this.dgpatientest.RowHeaderWidth = 35;
            this.dgpatientest.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.dgpatientest.SelectedRowForeColor = System.Drawing.Color.White;
            this.dgpatientest.Size = new System.Drawing.Size(594, 88);
            this.dgpatientest.TabIndex = 11;
            this.dgpatientest.Visible = false;
            // 
            // dgpatienOpsre
            // 
            this.dgpatienOpsre.AllowAddNew = false;
            this.dgpatienOpsre.AllowDelete = false;
            this.dgpatienOpsre.AutoAppendRow = true;
            this.dgpatienOpsre.AutoScroll = true;
            this.dgpatienOpsre.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgpatienOpsre.CaptionText = "手术处方明细";
            this.dgpatienOpsre.CaptionVisible = true;
            this.dgpatienOpsre.ColumnHeadersVisible = true;
            clsColumnInfo30.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo30.BackColor = System.Drawing.Color.White;
            clsColumnInfo30.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo30.ColumnIndex = 0;
            clsColumnInfo30.ColumnName = "项目名称";
            clsColumnInfo30.ColumnWidth = 200;
            clsColumnInfo30.Enabled = false;
            clsColumnInfo30.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo30.HeadText = "项目名称";
            clsColumnInfo30.ReadOnly = true;
            clsColumnInfo30.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo31.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo31.BackColor = System.Drawing.Color.White;
            clsColumnInfo31.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo31.ColumnIndex = 1;
            clsColumnInfo31.ColumnName = "执行部门";
            clsColumnInfo31.ColumnWidth = 120;
            clsColumnInfo31.Enabled = false;
            clsColumnInfo31.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo31.HeadText = "执行部门";
            clsColumnInfo31.ReadOnly = true;
            clsColumnInfo31.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo32.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo32.BackColor = System.Drawing.Color.White;
            clsColumnInfo32.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo32.ColumnIndex = 2;
            clsColumnInfo32.ColumnName = "价格";
            clsColumnInfo32.ColumnWidth = 75;
            clsColumnInfo32.Enabled = false;
            clsColumnInfo32.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo32.HeadText = "价格";
            clsColumnInfo32.ReadOnly = true;
            clsColumnInfo32.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo33.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo33.BackColor = System.Drawing.Color.White;
            clsColumnInfo33.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo33.ColumnIndex = 3;
            clsColumnInfo33.ColumnName = "折扣";
            clsColumnInfo33.ColumnWidth = 75;
            clsColumnInfo33.Enabled = false;
            clsColumnInfo33.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo33.HeadText = "折扣";
            clsColumnInfo33.ReadOnly = true;
            clsColumnInfo33.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo34.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo34.BackColor = System.Drawing.Color.White;
            clsColumnInfo34.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo34.ColumnIndex = 4;
            clsColumnInfo34.ColumnName = "总价";
            clsColumnInfo34.ColumnWidth = 90;
            clsColumnInfo34.Enabled = false;
            clsColumnInfo34.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo34.HeadText = "总价";
            clsColumnInfo34.ReadOnly = true;
            clsColumnInfo34.TextFont = new System.Drawing.Font("宋体", 10F);
            this.dgpatienOpsre.Columns.Add(clsColumnInfo30);
            this.dgpatienOpsre.Columns.Add(clsColumnInfo31);
            this.dgpatienOpsre.Columns.Add(clsColumnInfo32);
            this.dgpatienOpsre.Columns.Add(clsColumnInfo33);
            this.dgpatienOpsre.Columns.Add(clsColumnInfo34);
            this.dgpatienOpsre.FullRowSelect = false;
            this.dgpatienOpsre.Location = new System.Drawing.Point(16, 72);
            this.dgpatienOpsre.MultiSelect = false;
            this.dgpatienOpsre.Name = "dgpatienOpsre";
            this.dgpatienOpsre.ReadOnly = false;
            this.dgpatienOpsre.RowHeadersVisible = true;
            this.dgpatienOpsre.RowHeaderWidth = 35;
            this.dgpatienOpsre.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.dgpatienOpsre.SelectedRowForeColor = System.Drawing.Color.White;
            this.dgpatienOpsre.Size = new System.Drawing.Size(602, 48);
            this.dgpatienOpsre.TabIndex = 10;
            this.dgpatienOpsre.Visible = false;
            // 
            // dgpatienothre
            // 
            this.dgpatienothre.AllowAddNew = false;
            this.dgpatienothre.AllowDelete = false;
            this.dgpatienothre.AutoAppendRow = true;
            this.dgpatienothre.AutoScroll = true;
            this.dgpatienothre.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgpatienothre.CaptionText = "其它处方明细";
            this.dgpatienothre.CaptionVisible = true;
            this.dgpatienothre.ColumnHeadersVisible = true;
            clsColumnInfo35.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo35.BackColor = System.Drawing.Color.White;
            clsColumnInfo35.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo35.ColumnIndex = 0;
            clsColumnInfo35.ColumnName = "项目名称";
            clsColumnInfo35.ColumnWidth = 200;
            clsColumnInfo35.Enabled = false;
            clsColumnInfo35.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo35.HeadText = "项目名称";
            clsColumnInfo35.ReadOnly = true;
            clsColumnInfo35.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo36.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo36.BackColor = System.Drawing.Color.White;
            clsColumnInfo36.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo36.ColumnIndex = 1;
            clsColumnInfo36.ColumnName = "价格";
            clsColumnInfo36.ColumnWidth = 75;
            clsColumnInfo36.Enabled = false;
            clsColumnInfo36.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo36.HeadText = "价格";
            clsColumnInfo36.ReadOnly = true;
            clsColumnInfo36.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo37.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo37.BackColor = System.Drawing.Color.White;
            clsColumnInfo37.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo37.ColumnIndex = 2;
            clsColumnInfo37.ColumnName = "数量";
            clsColumnInfo37.ColumnWidth = 75;
            clsColumnInfo37.Enabled = false;
            clsColumnInfo37.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo37.HeadText = "数量";
            clsColumnInfo37.ReadOnly = true;
            clsColumnInfo37.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo38.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo38.BackColor = System.Drawing.Color.White;
            clsColumnInfo38.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo38.ColumnIndex = 3;
            clsColumnInfo38.ColumnName = "折扣";
            clsColumnInfo38.ColumnWidth = 75;
            clsColumnInfo38.Enabled = false;
            clsColumnInfo38.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo38.HeadText = "折扣";
            clsColumnInfo38.ReadOnly = true;
            clsColumnInfo38.TextFont = new System.Drawing.Font("宋体", 10F);
            clsColumnInfo39.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
            clsColumnInfo39.BackColor = System.Drawing.Color.White;
            clsColumnInfo39.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
            clsColumnInfo39.ColumnIndex = 4;
            clsColumnInfo39.ColumnName = "总价";
            clsColumnInfo39.ColumnWidth = 90;
            clsColumnInfo39.Enabled = false;
            clsColumnInfo39.ForeColor = System.Drawing.Color.Black;
            clsColumnInfo39.HeadText = "总价";
            clsColumnInfo39.ReadOnly = true;
            clsColumnInfo39.TextFont = new System.Drawing.Font("宋体", 10F);
            this.dgpatienothre.Columns.Add(clsColumnInfo35);
            this.dgpatienothre.Columns.Add(clsColumnInfo36);
            this.dgpatienothre.Columns.Add(clsColumnInfo37);
            this.dgpatienothre.Columns.Add(clsColumnInfo38);
            this.dgpatienothre.Columns.Add(clsColumnInfo39);
            this.dgpatienothre.FullRowSelect = false;
            this.dgpatienothre.Location = new System.Drawing.Point(16, 56);
            this.dgpatienothre.MultiSelect = false;
            this.dgpatienothre.Name = "dgpatienothre";
            this.dgpatienothre.ReadOnly = false;
            this.dgpatienothre.RowHeadersVisible = true;
            this.dgpatienothre.RowHeaderWidth = 35;
            this.dgpatienothre.SelectedRowBackColor = System.Drawing.Color.Purple;
            this.dgpatienothre.SelectedRowForeColor = System.Drawing.Color.White;
            this.dgpatienothre.Size = new System.Drawing.Size(584, 80);
            this.dgpatienothre.TabIndex = 9;
            this.dgpatienothre.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.tab);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Controls.Add(this.splitter2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(222, 678);
            this.panel2.TabIndex = 11;
            // 
            // tab
            // 
            this.tab.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tab.Controls.Add(this.tabPageNot);
            this.tab.Controls.Add(this.tabPageOk);
            this.tab.Controls.Add(this.tabPageBreak);
            this.tab.Controls.Add(this.tabPageLED);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tab.ItemSize = new System.Drawing.Size(40, 20);
            this.tab.Location = new System.Drawing.Point(3, 0);
            this.tab.Name = "tab";
            this.tab.Padding = new System.Drawing.Point(0, 0);
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(215, 625);
            this.tab.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tab.TabIndex = 20;
            this.tab.TabStop = false;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_SelectedIndexChanged);
            // 
            // tabPageNot
            // 
            this.tabPageNot.Controls.Add(this.m_lsvPatientDetial);
            this.tabPageNot.Controls.Add(this.m_txtSeqID);
            this.tabPageNot.Controls.Add(this.label20);
            this.tabPageNot.Location = new System.Drawing.Point(4, 4);
            this.tabPageNot.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tabPageNot.Name = "tabPageNot";
            this.tabPageNot.Size = new System.Drawing.Size(207, 597);
            this.tabPageNot.TabIndex = 0;
            this.tabPageNot.Text = "未发";
            this.tabPageNot.UseVisualStyleBackColor = true;
            // 
            // m_lsvPatientDetial
            // 
            this.m_lsvPatientDetial.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader13,
            this.columnHeader1});
            this.m_lsvPatientDetial.ContextMenuStrip = this.m_callcancel;
            this.m_lsvPatientDetial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvPatientDetial.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvPatientDetial.FullRowSelect = true;
            this.m_lsvPatientDetial.GridLines = true;
            this.m_lsvPatientDetial.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.m_lsvPatientDetial.Location = new System.Drawing.Point(0, 26);
            this.m_lsvPatientDetial.MultiSelect = false;
            this.m_lsvPatientDetial.Name = "m_lsvPatientDetial";
            this.m_lsvPatientDetial.Size = new System.Drawing.Size(207, 547);
            this.m_lsvPatientDetial.TabIndex = 19;
            this.m_lsvPatientDetial.UseCompatibleStateImageBehavior = false;
            this.m_lsvPatientDetial.View = System.Windows.Forms.View.Details;
            this.m_lsvPatientDetial.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_lsvPatientDetial_MouseDoubleClick);
            this.m_lsvPatientDetial.SelectedIndexChanged += new System.EventHandler(this.m_lsvPatientDetial_SelectedIndexChanged);
            this.m_lsvPatientDetial.DoubleClick += new System.EventHandler(this.m_lsvPatientDetial_DoubleClick_1);
            this.m_lsvPatientDetial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvPatientDetial_KeyDown);
            this.m_lsvPatientDetial.Click += new System.EventHandler(this.m_lsvPatientDetial_Click);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 71;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "流水号";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 65;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "时间";
            this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "卡号";
            this.columnHeader1.Width = 100;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label20.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label20.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label20.Location = new System.Drawing.Point(0, 573);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(207, 24);
            this.label20.TabIndex = 17;
            this.label20.Text = "处方总数：";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageOk
            // 
            this.tabPageOk.Controls.Add(this.label21);
            this.tabPageOk.Controls.Add(this.listViewok);
            this.tabPageOk.Location = new System.Drawing.Point(4, 4);
            this.tabPageOk.Margin = new System.Windows.Forms.Padding(0);
            this.tabPageOk.Name = "tabPageOk";
            this.tabPageOk.Size = new System.Drawing.Size(207, 599);
            this.tabPageOk.TabIndex = 1;
            this.tabPageOk.Text = "己发";
            this.tabPageOk.UseVisualStyleBackColor = true;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label21.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label21.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label21.Location = new System.Drawing.Point(0, 575);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(207, 24);
            this.label21.TabIndex = 5;
            this.label21.Text = "处方总数：";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewok
            // 
            this.listViewok.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader18,
            this.columnHeader14});
            this.listViewok.ContextMenuStrip = this.ctmsSend;
            this.listViewok.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewok.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewok.FullRowSelect = true;
            this.listViewok.GridLines = true;
            this.listViewok.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewok.HideSelection = false;
            this.listViewok.Location = new System.Drawing.Point(0, 0);
            this.listViewok.Name = "listViewok";
            this.listViewok.Size = new System.Drawing.Size(207, 599);
            this.listViewok.TabIndex = 4;
            this.listViewok.UseCompatibleStateImageBehavior = false;
            this.listViewok.View = System.Windows.Forms.View.Details;
            this.listViewok.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewok_MouseDoubleClick);
            this.listViewok.SelectedIndexChanged += new System.EventHandler(this.listViewok_SelectedIndexChanged);
            this.listViewok.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listViewok_KeyDown);
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "姓名";
            this.columnHeader15.Width = 70;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "流水号";
            this.columnHeader16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader16.Width = 65;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "时间";
            this.columnHeader18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "卡号";
            this.columnHeader14.Width = 100;
            // 
            // ctmsSend
            // 
            this.ctmsSend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctmsSend.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiDrugInfo2});
            this.ctmsSend.Name = "m_callcancel";
            this.ctmsSend.Size = new System.Drawing.Size(159, 26);
            // 
            // tsmiDrugInfo2
            // 
            this.tsmiDrugInfo2.Image = ((System.Drawing.Image)(resources.GetObject("tsmiDrugInfo2.Image")));
            this.tsmiDrugInfo2.Name = "tsmiDrugInfo2";
            this.tsmiDrugInfo2.Size = new System.Drawing.Size(158, 22);
            this.tsmiDrugInfo2.Text = "合理用药提示";
            this.tsmiDrugInfo2.Click += new System.EventHandler(this.tsmiDrugInfo2_Click);
            // 
            // tabPageBreak
            // 
            this.tabPageBreak.Controls.Add(this.lisvBreak);
            this.tabPageBreak.Controls.Add(this.label22);
            this.tabPageBreak.Location = new System.Drawing.Point(4, 4);
            this.tabPageBreak.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tabPageBreak.Name = "tabPageBreak";
            this.tabPageBreak.Size = new System.Drawing.Size(207, 599);
            this.tabPageBreak.TabIndex = 2;
            this.tabPageBreak.Text = "退回";
            this.tabPageBreak.UseVisualStyleBackColor = true;
            // 
            // lisvBreak
            // 
            this.lisvBreak.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader6,
            this.columnHeader19,
            this.columnHeader8});
            this.lisvBreak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lisvBreak.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lisvBreak.FullRowSelect = true;
            this.lisvBreak.GridLines = true;
            this.lisvBreak.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lisvBreak.HideSelection = false;
            this.lisvBreak.Location = new System.Drawing.Point(0, 0);
            this.lisvBreak.MultiSelect = false;
            this.lisvBreak.Name = "lisvBreak";
            this.lisvBreak.Size = new System.Drawing.Size(207, 575);
            this.lisvBreak.TabIndex = 18;
            this.lisvBreak.UseCompatibleStateImageBehavior = false;
            this.lisvBreak.View = System.Windows.Forms.View.Details;
            this.lisvBreak.Click += new System.EventHandler(this.lisvBreak_Click);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "姓名";
            this.columnHeader4.Width = 70;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "流水号";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 65;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "时间";
            this.columnHeader19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "卡号";
            this.columnHeader8.Width = 100;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.label22.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label22.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label22.Location = new System.Drawing.Point(0, 575);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(207, 24);
            this.label22.TabIndex = 5;
            this.label22.Text = "处方总数：";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabPageLED
            // 
            this.tabPageLED.Controls.Add(this.lvLED);
            this.tabPageLED.Location = new System.Drawing.Point(4, 4);
            this.tabPageLED.Name = "tabPageLED";
            this.tabPageLED.Size = new System.Drawing.Size(207, 599);
            this.tabPageLED.TabIndex = 3;
            this.tabPageLED.Text = "LED屏  ";
            this.tabPageLED.UseVisualStyleBackColor = true;
            // 
            // lvLED
            // 
            this.lvLED.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader22,
            this.columnHeader20,
            this.columnHeader21,
            this.columnHeader23});
            this.lvLED.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLED.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lvLED.FullRowSelect = true;
            this.lvLED.GridLines = true;
            this.lvLED.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvLED.HideSelection = false;
            this.lvLED.Location = new System.Drawing.Point(0, 0);
            this.lvLED.MultiSelect = false;
            this.lvLED.Name = "lvLED";
            this.lvLED.Size = new System.Drawing.Size(207, 599);
            this.lvLED.TabIndex = 19;
            this.lvLED.UseCompatibleStateImageBehavior = false;
            this.lvLED.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "状态";
            this.columnHeader22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "姓名";
            this.columnHeader20.Width = 70;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "流水号";
            this.columnHeader21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader21.Width = 65;
            // 
            // columnHeader23
            // 
            this.columnHeader23.Text = "卡号";
            this.columnHeader23.Width = 100;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(3, 625);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(215, 23);
            this.textBox1.TabIndex = 17;
            this.textBox1.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.38384F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.61616F));
            this.tableLayoutPanel1.Controls.Add(this.DateTimeMana, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label19, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 648);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(215, 26);
            this.tableLayoutPanel1.TabIndex = 18;
            // 
            // DateTimeMana
            // 
            this.DateTimeMana.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.DateTimeMana.CalendarTitleBackColor = System.Drawing.Color.DimGray;
            this.DateTimeMana.CustomFormat = "yyyy年MM月dd日";
            this.DateTimeMana.Location = new System.Drawing.Point(84, 2);
            this.DateTimeMana.Margin = new System.Windows.Forms.Padding(0);
            this.DateTimeMana.Name = "DateTimeMana";
            this.DateTimeMana.Size = new System.Drawing.Size(129, 23);
            this.DateTimeMana.TabIndex = 13;
            this.DateTimeMana.ValueChanged += new System.EventHandler(this.DateTimeMana_ValueChanged);
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.Location = new System.Drawing.Point(5, 2);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(74, 22);
            this.label19.TabIndex = 14;
            this.label19.Text = "当前日期:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(0, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 674);
            this.splitter2.TabIndex = 14;
            this.splitter2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel10);
            this.panel1.Location = new System.Drawing.Point(0, 686);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1221, 40);
            this.panel1.TabIndex = 7;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.m_txtPatientCard);
            this.panel10.Controls.Add(this.m_txtRegisterNo);
            this.panel10.Controls.Add(this.label17);
            this.panel10.Controls.Add(this.label5);
            this.panel10.Controls.Add(this.label15);
            this.panel10.Controls.Add(this.label6);
            this.panel10.Controls.Add(this.dateTimePicker2);
            this.panel10.Controls.Add(this.m_txtPatient);
            this.panel10.Controls.Add(this.dateTimePicker1);
            this.panel10.Controls.Add(this.label7);
            this.panel10.Controls.Add(this.buttonXP1);
            this.panel10.Controls.Add(this.m_cmdFind);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(1217, 36);
            this.panel10.TabIndex = 18;
            // 
            // m_txtPatientCard
            // 
            this.m_txtPatientCard.Location = new System.Drawing.Point(65, 4);
            this.m_txtPatientCard.MaxLength = 50;
            this.m_txtPatientCard.Name = "m_txtPatientCard";
            this.m_txtPatientCard.PatientCard = "";
            this.m_txtPatientCard.PatientFlag = 0;
            this.m_txtPatientCard.Size = new System.Drawing.Size(88, 23);
            this.m_txtPatientCard.TabIndex = 1;
            this.m_txtPatientCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtPatientCard.YBCardText = "";
            this.m_txtPatientCard.CardKeyDown += new com.digitalwave.controls.clsCardTextBox.TxtKeyDownHandle(this.m_txtPatientCard1_CardKeyDown);
            // 
            // m_txtRegisterNo
            // 
            this.m_txtRegisterNo.EnableAutoValidation = false;
            this.m_txtRegisterNo.EnableEnterKeyValidate = true;
            this.m_txtRegisterNo.EnableEscapeKeyUndo = true;
            this.m_txtRegisterNo.EnableLastValidValue = true;
            this.m_txtRegisterNo.ErrorProvider = null;
            this.m_txtRegisterNo.ErrorProviderMessage = "Invalid value";
            this.m_txtRegisterNo.ForceFormatText = true;
            this.m_txtRegisterNo.Location = new System.Drawing.Point(325, 5);
            this.m_txtRegisterNo.MaxLength = 20;
            this.m_txtRegisterNo.Name = "m_txtRegisterNo";
            this.m_txtRegisterNo.NumericCharStyle = ((SourceLibrary.Windows.Forms.NumericCharStyle)((SourceLibrary.Windows.Forms.NumericCharStyle.DecimalSeparator | SourceLibrary.Windows.Forms.NumericCharStyle.NegativeSymbol)));
            this.m_txtRegisterNo.Size = new System.Drawing.Size(88, 23);
            this.m_txtRegisterNo.TabIndex = 5;
            this.m_txtRegisterNo.Text = "0";
            this.m_txtRegisterNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtRegisterNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtRegisterNo_KeyDown);
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(409, 5);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 23);
            this.label17.TabIndex = 28;
            this.label17.Text = "日期从";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(159, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 21;
            this.label5.Text = "病人姓名";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(586, 5);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 23);
            this.label15.TabIndex = 27;
            this.label15.Text = "到";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 20;
            this.label6.Text = "诊疗卡号";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarTitleBackColor = System.Drawing.Color.DimGray;
            this.dateTimePicker2.Location = new System.Drawing.Point(609, 5);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker2.TabIndex = 26;
            // 
            // m_txtPatient
            // 
            this.m_txtPatient.EnableAutoValidation = false;
            this.m_txtPatient.EnableEnterKeyValidate = true;
            this.m_txtPatient.EnableEscapeKeyUndo = true;
            this.m_txtPatient.EnableLastValidValue = true;
            this.m_txtPatient.ErrorProvider = null;
            this.m_txtPatient.ErrorProviderMessage = "Invalid value";
            this.m_txtPatient.ForceFormatText = true;
            this.m_txtPatient.Location = new System.Drawing.Point(221, 5);
            this.m_txtPatient.MaxLength = 5;
            this.m_txtPatient.Name = "m_txtPatient";
            this.m_txtPatient.Size = new System.Drawing.Size(57, 23);
            this.m_txtPatient.TabIndex = 2;
            this.m_txtPatient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPatient_KeyDown);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.DimGray;
            this.dateTimePicker1.Location = new System.Drawing.Point(464, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker1.TabIndex = 25;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(278, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 14);
            this.label7.TabIndex = 23;
            this.label7.Text = "流水号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonXP1
            // 
            this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.buttonXP1.DefaultScheme = true;
            this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP1.Hint = "";
            this.buttonXP1.Location = new System.Drawing.Point(795, 0);
            this.buttonXP1.Name = "buttonXP1";
            this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP1.Size = new System.Drawing.Size(64, 32);
            this.buttonXP1.TabIndex = 6;
            this.buttonXP1.Text = "返回(&R)";
            this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
            // 
            // m_cmdFind
            // 
            this.m_cmdFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdFind.DefaultScheme = true;
            this.m_cmdFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdFind.Hint = "";
            this.m_cmdFind.Location = new System.Drawing.Point(730, 0);
            this.m_cmdFind.Name = "m_cmdFind";
            this.m_cmdFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdFind.Size = new System.Drawing.Size(64, 32);
            this.m_cmdFind.TabIndex = 5;
            this.m_cmdFind.Text = "查询(&F)";
            this.m_cmdFind.Click += new System.EventHandler(this.m_cmdFind_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(304, -48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1072, 48);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // buttonXP6
            // 
            this.buttonXP6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXP6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.buttonXP6.DefaultScheme = true;
            this.buttonXP6.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP6.Hint = "";
            this.buttonXP6.Location = new System.Drawing.Point(1227, 688);
            this.buttonXP6.Name = "buttonXP6";
            this.buttonXP6.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.buttonXP6.Size = new System.Drawing.Size(71, 32);
            this.buttonXP6.TabIndex = 31;
            this.buttonXP6.Text = "自动配药";
            this.buttonXP6.Click += new System.EventHandler(this.buttonXP6_Click);
            // 
            // frmOPMedStoreWin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1378, 723);
            this.Controls.Add(this.panel12);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.buttonXP4);
            this.Controls.Add(this.panel9);
            this.Controls.Add(this.pnlotherSend);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonXP6);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "frmOPMedStoreWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "门诊发药窗口";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmOPMedStoreWin_Load);
            this.Activated += new System.EventHandler(this.frmOPMedStoreWin_Activated);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmOPMedStoreWin_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOPMedStoreWin_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmOPMedStoreWin_KeyDown);
            this.m_callcancel.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.panel16.ResumeLayout(false);
            this.panel16.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel9.ResumeLayout(false);
            this.panel9.PerformLayout();
            this.pnlotherSend.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.pnl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_DgMed)).EndInit();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel11.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_nudRefershTime)).EndInit();
            this.panel3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.gbItem.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgpatientcnkre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpatientest)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpatienOpsre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgpatienothre)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tab.ResumeLayout(false);
            this.tabPageNot.ResumeLayout(false);
            this.tabPageNot.PerformLayout();
            this.tabPageOk.ResumeLayout(false);
            this.ctmsSend.ResumeLayout(false);
            this.tabPageBreak.ResumeLayout(false);
            this.tabPageLED.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel10.ResumeLayout(false);
            this.panel10.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// 设置窗体对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsControlOPMedStore();
            this.objController.Set_GUI_Apperance(this);
        }
        /// <summary>
        /// 默认设置的个数，默认为1，最大为4
        /// </summary>
        public Int16 m_intSettingCount = 1;
        /// <summary>
        /// 设置门诊药房在哪个业务之后扣减药房库存,0-配药后,1-发药后;
        /// </summary>
        public string m_strSubtractMode = "0";
        /// <summary>
        /// 是否启用药房二级库存管理模式,0-不启用 1-启用;
        /// </summary>
        public string m_strSecondLevelMode = "0";
        private void frmOPMedStoreWin_Load(object sender, System.EventArgs e)
        {
            //this.m_txtScreenContent.Hide();
            //this.m_objPBScreen.Visible = false;
            this.m_strMedStoreCallUseMSMQ = this.objController.m_objComInfo.m_lonGetModuleInfo("0425");
            ((clsControlOPMedStore)this.objController).m_mthInitRefreshTime();
            //判断是不是发药窗口，如果是则初始化发药窗口显示屏的配置属性
            ////if (this.statusWindows.statusTone == 2)
            ////{
            ////    ((clsControlOPMedStore)this.objController).m_mthGetMedStoreScreenConfigVo(out this.m_objScreenConfigVo);
            ////}
            ((clsControlOPMedStore)this.objController).strEmpName = this.LoginInfo.m_strEmpName;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)m_DgMed.Columns[0]).DataGridTextBoxColumn.TextBox.MaxLength = 10;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)m_DgMed.Columns[0]).DataGridTextBoxColumn.TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)m_DgMed.Columns[4]).DataGridTextBoxColumn.TextBox.MaxLength = 4;
            ((com.digitalwave.controls.datagrid.clsColumnInfo)m_DgMed.Columns[4]).DataGridTextBoxColumn.TextBox.KeyPress += new KeyPressEventHandler(txtCount_KeyPress);
            //把datagrid的第一和第二列转换成空格
            m_DgMed.m_mthAddEnterToSpaceColumn(4);
            m_DgMed.m_mthAddEnterToSpaceColumn(0);
            m_DgMed.m_mthAddEnterToSpaceColumn(6);
            this.PrintDialog.PrintPreviewControl.Zoom = 1;
            this.printPreviewDialog1.PrintPreviewControl.Zoom = 1;
            this.m_txtRegisterNo.Text = "";
            //if(this.objController.m_objComInfo.m_mthGetHospitalNo()=="00001")
            //{
            this.label18.Text = "材料费";
            //}

            if (this.objController.m_objComInfo.m_lonGetModuleInfo("0039") == "1")
            {
                this.checkBox1.Checked = true;
                this.statusWindows.isBreakCheck = true;
            }
            else
            {
                this.checkBox1.Checked = false;
                this.statusWindows.isBreakCheck = false;
            }
            ToolStrip tlBar = null;
            ToolStripButton btn = null;
            foreach (System.Windows.Forms.Control c in PrintDialog.Controls)
            {
                if (c is ToolStrip)
                {
                    tlBar = (ToolStrip)c;
                    btn = (ToolStripButton)tlBar.Items[0];
                    btn.Click += new EventHandler(btn_Click);
                }
            }
            m_mthShowGUI(this.statusWindows.statusTone);
            if (this.statusWindows.statusTone == 3)
            {
                ((clsControlOPMedStore)this.objController).m_mthGetAllOutpatrecipe();
                ((clsControlOPMedStore)this.objController).m_mthFillDep();
            }
            ((clsControlOPMedStore)this.objController).m_mthInitPrintSendMedBillFlag();
            ((clsControlOPMedStore)this.objController).m_mthInitPrintSendMedBill();

            switch (this.m_intSettingCount)
            {
                case 1: this.panel14.Dispose(); this.panel15.Dispose(); this.panel16.Dispose();
                    this.panel12.Height = (int)(this.panel12.Height * 0.25f);
                    break;
                case 2: this.panel15.Dispose(); this.panel16.Dispose();
                    this.panel12.Height = (int)(this.panel12.Height * 0.50f);
                    break;
                case 3: this.panel16.Dispose();

                    this.panel12.Height = (int)(this.panel12.Height * 0.75f);
                    break;
            }
            Point PnlLocation = new Point(this.Width - this.panel12.Width, this.groupBox3.Location.Y - this.panel12.Height);
            this.panel12.Location = PnlLocation;
            ((clsControlOPMedStore)this.objController).m_mthInitialSaveEmpList();
            this.m_txtSeqID.Focus();
            this.m_strFormText = this.Text;

            // 合理用药服务地址
            ((clsControlOPMedStore)this.objController).DrugServiceUrl = clsPublic.m_strGetSysparm("0080");
            ((clsControlOPMedStore)this.objController).IsUseMedItf = (clsPublic.ConvertObjToDecimal(clsPublic.m_strGetSysparm("0082")) == 1 ? true : false);
            ((clsControlOPMedStore)this.objController).WechatWebUrl = clsPublic.m_strGetSysparm("1010");
            // Init.Led
            ((clsControlOPMedStore)this.objController).InitLed();
            if (this.statusWindows.statusTone != 1)
            {
                this.tab.TabPages.Remove(tabPageLED);
            }
            this.txtWechatCode.Text = string.Empty;
            this.txtWechatCode.Focus();
        }

        void btn_Click(object sender, EventArgs e)
        {
            try
            {
                ((clsControlOPMedStore)this.objController).m_mthReadIN();
            }
            catch
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        private void txtCount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            TextBox tb = sender as TextBox;
            if ((int)e.KeyChar >= 46 && (int)e.KeyChar <= 57 && (int)e.KeyChar != 47 || (int)e.KeyChar == 8)
            {

            }
            else
            {
                e.Handled = true;

            }
            if (e.KeyChar == '.')
            {
                if (tb.Text.Trim() == "")
                {
                    tb.Text = "0.";
                    System.Windows.Forms.SendKeys.SendWait("{Right}");
                    System.Windows.Forms.SendKeys.SendWait("{Right}");
                    e.Handled = true;
                }
                if (tb.Text.IndexOf(".") > -1)
                {
                    e.Handled = true;
                }
            }
        }

        private void m_cmdRefersh_Click(object sender, System.EventArgs e)
        {
            if (this.statusWindows.statusTone != 3)
            {
                ((clsControlOPMedStore)this.objController).m_mthGetPatientQueue();
            }
            else
            {
                ((clsControlOPMedStore)this.objController).m_mthGetAllOutpatrecipe();
            }
        }
        private void m_timer_Tick(object sender, System.EventArgs e)
        {
            if (this.statusWindows.statusTone != 3)
            {
                ((clsControlOPMedStore)this.objController).m_mthGetPatientQueue();
            }
            else
            {
                ((clsControlOPMedStore)this.objController).m_mthGetAllOutpatrecipe();
            }
        }

        private void m_nudRefershTime_ValueChanged(object sender, System.EventArgs e)
        {
            this.m_timer.Interval = Convert.ToInt32(this.m_nudRefershTime.Value) * 1000;
        }

        private void m_lsvPatientDetial_DoubleClick(object sender, System.EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthSelPatient();
        }

        private void m_lsvPatientDetial_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthSelPatient();
        }

        private void tab_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).ClearDe();
            if ((tab.SelectedIndex == 0 || tab.SelectedIndex == 1) && cbWindows.Enabled == true)
            {
                m_timer.Enabled = true;
            }
            else
            {
                m_timer.Enabled = false;
            }

        }

        private void PrintDocu_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_lngPrintClick(e);
        }

        private void m_txtPatientCard_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsControlOPMedStore)this.objController).m_lngAction();
            }
        }

        private void m_txtPatientCard_KeyDown_1(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsControlOPMedStore)this.objController).m_lngAction();
                m_txtPatient.Focus();
            }
        }

        private void m_cmdFind_Click(object sender, System.EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthFind();
        }

        private void buttonXP1_Click(object sender, System.EventArgs e)
        {
            m_timer.Enabled = true;
            m_cmdRefersh.Enabled = true;
            this.checkBox1.Enabled = true;
            this.cbWindows.Enabled = true;
            textBox1.Visible = false;
            this.tableLayoutPanel1.Dock = DockStyle.Bottom;
            this.tableLayoutPanel1.Visible = true;

            if (this.statusWindows.statusTone != 3)
            {
                ((clsControlOPMedStore)this.objController).m_mthGetPatientQueue();
            }
            else
            {
                ((clsControlOPMedStore)this.objController).m_mthGetAllOutpatrecipe();
            }
        }

        private void frmOPMedStoreWin_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                this.m_txtSeqID.Focus();
                this.m_txtSeqID.SelectAll();
            }
            if (e.KeyCode == Keys.Escape)
            {
                if (pnlotherSend.Visible == true)
                {
                    pnlotherSend.Visible = false;
                    return;
                }
                if (gbItem.Visible == true)
                {
                    gbItem.Visible = false;
                    return;
                }
                if (MessageBox.Show("是否要退出发药系统？", "icare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    this.Close();
            }
            if (this.statusWindows.statusTone == 2 && e.KeyCode == Keys.C)
            {
                this.m_btnCall.PerformClick();
            }

            if (e.KeyCode == Keys.F1)
            {
                ((clsControlOPMedStore)this.objController).m_intSaveEmpOrder = 0;
                this.buttonXP5_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2)
            {
                ((clsControlOPMedStore)this.objController).m_intSaveEmpOrder = 1;
                this.buttonXP5_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3)
            {
                ((clsControlOPMedStore)this.objController).m_intSaveEmpOrder = 2;
                this.buttonXP5_Click(null, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                ((clsControlOPMedStore)this.objController).m_intSaveEmpOrder = 3;
                this.buttonXP5_Click(null, null);
            }
            else if (e.KeyCode == Keys.F8)
            {
                this.txtWechatCode.Text = string.Empty;
                this.txtWechatCode.Focus();
            }
            else if (e.KeyCode == Keys.F9)
            {
                if (this.m_lsvPatientDetial.SelectedItems.Count > 0 && ((clsMedStorePatientListInfo)this.m_lsvPatientDetial.SelectedItems[0].Tag).m_objRecipeList != null && ((clsMedStorePatientListInfo)this.m_lsvPatientDetial.SelectedItems[0].Tag).m_objRecipeList.Count > 0)
                {
                    string recipeId = ((clsMedStorePatientListInfo)this.m_lsvPatientDetial.SelectedItems[0].Tag).m_objRecipeList[0].m_strOUTPATRECIPEID_CHR;
                    ((clsControlOPMedStore)this.objController).LedSocketMsg(1, recipeId);
                    if (clsControlOPMedStore.lstHungUpRecipeId == null) clsControlOPMedStore.lstHungUpRecipeId = new List<string>();
                    clsControlOPMedStore.lstHungUpRecipeId.Add(recipeId);
                    ((clsControlOPMedStore)this.objController).SetHungUpBackColor();
                }
            }
        }

        private void listViewok_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthSelPatient();
        }

        private void cbWindows_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            m_lsvOpRecDetail.Items.Clear();
            m_lsvMedicineDetail.Items.Clear();
            statusWindows.strWindowID = dtwindowsMessage.Rows[cbWindows.SelectedIndex]["WINDOWID_CHR"].ToString();

            ((clsControlOPMedStore)this.objController).m_mthGetPatientQueue();

        }

        private void btnSendMed_Click(object sender, System.EventArgs e)
        {
            switch (this.statusWindows.statusTone)
            {
                case 1:
                    ((clsControlOPMedStore)this.objController).m_ShowInput(2, sender);
                    break;
                case 2:
                    ((clsControlOPMedStore)this.objController).m_ShowInput(0, sender);
                    break;
                case 3:
                    if (m_lsvPatientDetial.CheckedItems.Count > 0)
                    {
                        ((clsControlOPMedStore)this.objController).m_ShowInput(4, sender);
                    }
                    else
                    {
                        MessageBox.Show("当前没有选中的处方！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                    break;
            }
        }

        private void btnPrint_Click(object sender, System.EventArgs e)
        {
            if (isSeleItem())
            {
                ((clsControlOPMedStore)this.objController).m_lngPrint((System.Windows.Forms.Control)sender);
            }
            else
            {
            }
        }

        private void buttonXP2_Click(object sender, System.EventArgs e)
        {
            if (MessageBox.Show("是否要退出发药系统？", "icare", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }

        private void btnOther_Click(object sender, System.EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_lngShowAll();
        }

        private void cbWindows_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

        }

        private void DateTimeMana_ValueChanged(object sender, System.EventArgs e)
        {
            m_lsvOpRecDetail.Items.Clear();
            m_lsvMedicineDetail.Items.Clear();
            try
            {
                statusWindows.strWindowID = dtwindowsMessage.Rows[cbWindows.SelectedIndex]["WINDOWID_CHR"].ToString();
            }
            catch
            {
            }
            if (this.statusWindows.statusTone != 3)
            {
                ((clsControlOPMedStore)this.objController).m_mthGetPatientQueue();
            }
            else
            {
                ((clsControlOPMedStore)this.objController).m_mthGetAllOutpatrecipe();
            }
        }

        private void m_txtPatient_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_txtRegisterNo.Focus();
            }
        }

        private void m_txtRegisterNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_cmdFind.Focus();
            }
        }

        private void btnOtherSend_Click(object sender, System.EventArgs e)
        {
            if (pnlotherSend.Visible == false)
            {
                ((clsControlOPMedStore)this.objController).findOtherDe();
            }
        }

        private void m_DgMed_m_evtDataGridTextBoxKeyDown(object sender, com.digitalwave.controls.datagrid.clsDGTextKeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.m_intColNumber == 0)
            {
                if (e.m_strText == "")
                {
                    m_DgMed.CurrentCell = new DataGridCell(m_DgMed.CurrentCell.RowNumber, 0);
                }
                else
                {
                    ((clsControlOPMedStore)this.objController).FindItemData(e.m_strText.Trim());
                    e.m_strText = "";
                }
            }
            if (e.KeyCode == Keys.Enter && e.m_intColNumber == 4)
            {
                if (e.m_strText == "" || e.m_strText == "0")
                {
                    m_DgMed.CurrentCell = new DataGridCell(m_DgMed.CurrentCell.RowNumber, 4);
                }
                else
                {
                    try
                    {
                        Double tolMoney = 0;
                        tolMoney = Convert.ToInt32(e.m_strText) * Convert.ToDouble(m_DgMed[m_DgMed.CurrentCell.RowNumber, 6].ToString());
                        m_DgMed[m_DgMed.CurrentCell.RowNumber, 7] = tolMoney.ToString();
                        m_DgMed.CurrentCell = new DataGridCell(m_DgMed.CurrentCell.RowNumber + 1, 0);
                        tolMoney = 0;
                        for (int i1 = 0; i1 < m_DgMed.RowCount; i1++)
                        {
                            if (m_DgMed[i1, 7].ToString().Trim() != "")
                            {
                                tolMoney += Convert.ToDouble(m_DgMed[i1, 7].ToString().Trim());
                            }
                        }
                        MedMoney.Text = tolMoney.ToString();
                        Double doMoney = Convert.ToDouble(Convert.ToDouble(CullMoney.Text)) - tolMoney;
                        multiMoney.Text = doMoney.ToString();
                    }
                    catch
                    {
                    }
                }
            }
        }

        private void DgItem_m_evtDataGridKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                ((clsControlOPMedStore)this.objController).SeleItems();
        }

        private void DgItem_Leave(object sender, System.EventArgs e)
        {
            if (DgItem.Visible == true)
                DgItem.Visible = false;
        }

        private void btnSend_Click(object sender, System.EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).OtherSendMed();
        }

        private void frmOPMedStoreWin_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (pnlotherSend.Visible == true)
            {
                m_DgMed.m_mthDeleteAllRow();
            }
        }

        private void tab_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
            {
                if (tab.SelectedIndex == 0)
                {
                    if (m_lsvPatientDetial.SelectedItems[0].Index != m_lsvPatientDetial.Items.Count - 1)
                    {
                        if (e.KeyCode == Keys.Down)
                        {
                            m_lsvPatientDetial.Items[m_lsvPatientDetial.SelectedItems[0].Index + 1].Selected = true;
                        }
                    }
                    if (m_lsvPatientDetial.SelectedItems[0].Index != 0)
                    {
                        if (e.KeyCode == Keys.Up)
                        {
                            m_lsvPatientDetial.Items[m_lsvPatientDetial.SelectedItems[0].Index - 1].Selected = true;
                        }
                    }

                }
                if (tab.SelectedIndex == 1)
                {
                    if (listViewok.SelectedItems[0].Index != listViewok.Items.Count - 1)
                    {
                        if (e.KeyCode == Keys.Down)
                        {
                            listViewok.Items[listViewok.SelectedItems[0].Index + 1].Selected = true;
                        }
                    }
                    if (listViewok.SelectedItems[0].Index != 0)
                    {
                        if (e.KeyCode == Keys.Up)
                        {
                            listViewok.Items[listViewok.SelectedItems[0].Index - 1].Selected = true;
                        }
                    }

                }
                ((clsControlOPMedStore)this.objController).m_mthSelPatient();

            }
        }

        private void m_lsvPatientDetial_Click_1(object sender, System.EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthSelPatient();
        }

        private void listViewok_Click(object sender, System.EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthSelPatient();
        }

        private void PrintDocu_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            ((clsControlOPMedStore)this.objController).m_ResetPage();
        }

        private void groupBox2_Enter(object sender, System.EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {

            ((clsControlOPMedStore)this.objController).m_mthGetPatientQueue();
            if (m_lsvPatientDetial.Items.Count == 0)
            {
                m_lsvOpRecDetail.Items.Clear();
                m_lsvMedicineDetail.Items.Clear();
                this.PatientType.Text = "";
                this.WestMoney.Text = "0";
                this.ChinaMoney.Text = "0";
                this.CheckMoney.Text = "0";
                this.ChAndEN.Text = "0";
            }

        }

        private void btnPrintqe_Click(object sender, System.EventArgs e)
        {
            if (isSeleItem())
            {
                ((clsControlOPMedStore)this.objController).m_mthPrintQF(((clsControlOPMedStore)this.objController).m_objSeleRow.m_strSID_INT, 2);
            }
            else
            {
            }
        }

        private void tabPageOk_Click(object sender, System.EventArgs e)
        {

        }

        private void btnDosage_Click(object sender, System.EventArgs e)
        {
            if (this.statusWindows.statusTone == 3)
            {
                if (m_lsvPatientDetial.CheckedItems.Count > 0)
                {
                    ((clsControlOPMedStore)this.objController).m_ShowInput(3, sender);
                }
                else
                {
                    MessageBox.Show("当前没有选中的处方！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                if (this.statusWindows.statusTone == 1)//配药窗口为配药功能
                {
                    ((clsControlOPMedStore)this.objController).m_ShowInput(1, sender);
                }
                else if (this.statusWindows.statusTone == 2)//发窗口为放弃功能
                {
                    if (this.m_lsvPatientDetial.SelectedItems.Count > 0)
                    {
                        clsMedStorePatientListInfo m_objPatientInfo = this.m_lsvPatientDetial.SelectedItems[0].Tag as clsMedStorePatientListInfo;
                        ((clsControlOPMedStore)this.objController).m_lngRecipeSendQuit(Convert.ToInt64(m_objPatientInfo.m_strSID_INT));
                    }
                    else
                    {
                        MessageBox.Show("请选择一个病人！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    }
                }
            }
        }

        private void btnPatrol_Click(object sender, System.EventArgs e)
        {
            //((clsControlOPMedStore)this.objController).m_mthPrintScout();
        }

        private void buttonXP3_Click(object sender, System.EventArgs e)
        {


            ((clsControlOPMedStore)this.objController).isAuto = false;
            if (isSeleItem())
            {
                //((Form)printPreviewDialog1).Icon = this.Icon;
                //printPreviewDialog1.ShowDialog();
                ((clsControlOPMedStore)this.objController).m_mthGetData();

            }
            else
            {
            }
        }
        internal bool isSeleItem()
        {

            switch (tab.SelectedIndex)
            {
                case 0:
                    if (m_lsvPatientDetial.Items.Count > 0)
                    {
                        if (m_lsvPatientDetial.SelectedIndices.Count == 0 || m_lsvOpRecDetail.Items.Count == 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case 1:
                    if (listViewok.Items.Count > 0)
                    {
                        if (listViewok.SelectedIndices.Count == 0 || m_lsvOpRecDetail.Items.Count == 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    break;
                case 2:
                    if (lisvBreak.Items.Count > 0)
                    {
                        if (lisvBreak.SelectedIndices.Count == 0 || m_lsvOpRecDetail.Items.Count == 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                    break;
            }
            return true;
        }

        private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthGetData();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthPrint(e);
        }

        private void lisvBreak_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthSelPatient();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                m_mthSele(true);
        }
        private void m_mthSele(bool SeleAll)
        {
            if (m_lsvPatientDetial.Items.Count > 0)
            {
                for (int i1 = 0; i1 < m_lsvPatientDetial.Items.Count; i1++)
                {
                    m_lsvPatientDetial.Items[i1].Checked = SeleAll;
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == false)
                m_mthSele(false);
        }

        private void buttonXP4_Click(object sender, EventArgs e)
        {
            panel12.Visible = true;
            textBox2.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthCancelSetDefault(1);
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendKeys.Send("{tab}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthGetName(1);
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {

        }

        private void buttonXP5_Click(object sender, EventArgs e)
        {
            if (this.tab.SelectedIndex == 0)
            {
                ((clsControlOPMedStore)this.objController).m_mthClick();
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                checkBox3.Enabled = true;
                checkBox4.Enabled = true;
                m_chkTreatTip.Enabled = true;
                this.m_chkHistory.Enabled = true;
                this.m_chkMedBag.Enabled = true;
                if (this.statusWindows.m_intOmitDispense == 1 && this.statusWindows.statusTone == 1)
                {
                    if (((clsControlOPMedStore)this.objController).SaveEmp[0].empID == null || ((clsControlOPMedStore)this.objController).SaveEmp[0].empID == string.Empty)
                    {
                        ((clsControlOPMedStore)this.objController).publiClass.m_mthShowWarning(this.m_lsvMedicineDetail, "请先设置默认的操作员，以便进行自动配药！！");
                    }
                }
            }
            else
            {
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox3.Enabled = false;
                checkBox4.Enabled = false;
                m_chkTreatTip.Checked = false;
                m_chkTreatTip.Enabled = false;
                this.m_chkHistory.Checked = false;
                this.m_chkHistory.Enabled = false;
                this.m_chkMedBag.Checked = false;
                this.m_chkMedBag.Enabled = false;
            }
        }

        private void buttonXP6_Click(object sender, EventArgs e)
        {
            frmAuto ShowFrm = new frmAuto(this, "1");
            ShowFrm.Show();
        }

        private void timerChangeDate_Tick(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthSetDate();
        }

        private void m_nudRefershTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsControlOPMedStore)this.objController).m_mthWriteRefreshTime();
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            btnPrint_Click(null, null);
            return;
            ((clsControlOPMedStore)this.objController).m_mthShowPrint();
        }

        private void m_printDocumentRecipe_BeginPrint(object sender, PrintEventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthBeginPrint();
        }

        private void m_printDocumentRecipe_PrintPage(object sender, PrintPageEventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthprint(e);
        }

        private void m_lsvPatientDetial_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (this.m_lsvOpRecDetail.Items.Count > 0)
            {
                this.m_btnPrint.Enabled = true;

            }
            else
            {
                this.m_btnPrint.Enabled = false;
            }
        }
        /// <summary>
        /// 保存当前叫号的病人对列
        /// </summary>
        public ArrayList m_objArrayList = new ArrayList();
        /// <summary>
        ///　临时变量
        /// </summary>
        private clsCallPatientVo m_objTempVo;
        /// <summary>
        /// 门诊配药房叫号是否启用MSMQ队列 0-否 1-是
        /// </summary>
        public string m_strMedStoreCallUseMSMQ = "0";
        /// <summary>
        /// 叫号语音
        /// </summary>
        private string m_strCallContent = string.Empty;
        internal bool m_blnIsCallFlag = false;
        #region 叫号
        //关于叫号规则更改后的说明，by dianliang.liang
        //发药窗口的叫号改为重叫号
        //当在发药窗叫号时，会修改t_opr_recipesend表中called_int  recalled_int  quit_int这三个字段，分别为0,1,0
        //当called_int=1,recalled_int=0,quit_int=0，表示正常叫号（配药时自动叫号）
        //当called_int=0,recalled_int=1,quit_int=0，表示重叫号（在发药房点击叫号）
        //当called_int=0,recalled_int=0,quit_int=1，表示已叫号，但病人不来取药，手功放弃叫号，会把该病人放到电子屏的队列最后面（并不是真正的下屏），并放到发药窗口待发药队列的最后面
        //当called_int=0,recalled_int=0,quit_int=0，才是真正的下屏
        private void m_btnCall_Click(object sender, EventArgs e)
        {
            this.m_btnCall.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            int m_intIsReCall = 0;
            if (this.m_lsvPatientDetial.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "请先选择一个病人！", "iCare系统温馨提示：", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                return;
            }

            clsMedStorePatientListInfo m_objPatientInfo = null;
            if (tab.SelectedTab.Text == "未发")
            {
                m_objPatientInfo = this.m_lsvPatientDetial.SelectedItems[0].Tag as clsMedStorePatientListInfo;
                m_intIsReCall = 0;
            }
            else if (tab.SelectedTab.Text == "已发")
            {
                m_objPatientInfo = this.listViewok.SelectedItems[0].Tag as clsMedStorePatientListInfo;
                m_intIsReCall = 1;
            }
            long lngRes = -1;
            //if (m_objPatientInfo.m_intCalled == 0)
            //{
            //    lngRes = ((clsControlOPMedStore)this.objController).m_lngUpdateRecipeSendCalledFlag(Convert.ToInt64(m_objPatientInfo.m_strSID_INT), m_intIsReCall);
            //    if (lngRes > 0)
            //    {
            //        m_objPatientInfo.m_intCalled = 1;
            //        if (tab.SelectedTab.Text == "未发")
            //        {
            //            this.m_lsvPatientDetial.SelectedItems[0].BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            //        }
            //        else if (tab.SelectedTab.Text == "已发")
            //        {
            //            this.listViewok.SelectedItems[0].BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            //        }
            //    }
            //}
            //lngRes = ((clsControlOPMedStore)this.objController).m_lngUpdateRecipeSendCurrentCallFlag(Convert.ToInt64(m_objPatientInfo.m_strSID_INT), this.statusWindows.strWindowID.Trim(), m_intIsReCall);
            lngRes = ((clsControlOPMedStore)this.objController).m_lngUpdateRecipeSendCalledFlag2(Convert.ToInt64(m_objPatientInfo.m_strSID_INT));
            if (lngRes > 0)
            {
                if (((clsControlOPMedStore)this.objController).m_strCallGroupFlag == "1")
                {
                    if (this.tab.SelectedTab.Text == "未发")
                    {
                        m_objPatientInfo.m_intCurrentCall = 1;
                        int intIndex = this.m_lsvPatientDetial.Items.Count;
                        ListViewItem lvi = this.m_lsvPatientDetial.SelectedItems[0];
                        this.m_lsvPatientDetial.Items.Remove(lvi);
                        this.m_lsvPatientDetial.Items.Insert(intIndex - 1, lvi);
                        this.m_lsvPatientDetial.Items[intIndex - 1].Tag = lvi.Tag;
                        this.m_lsvPatientDetial.Focus();
                        //this.m_lsvPatientDetial.Items[intIndex - 1].Selected = true;
                        if (intIndex > 0)
                        {
                            this.m_lsvPatientDetial.Items[0].Selected = true;
                            this.m_lsvPatientDetial.EnsureVisible(0);
                            this.m_lsvPatientDetial.Focus();
                        }
                    }
                    else if (this.tab.SelectedTab.Text == "已发")
                    {
                        m_objPatientInfo.m_intCurrentCall = 1;
                        int intIndex = this.listViewok.Items.Count;
                        ListViewItem lvi = this.listViewok.SelectedItems[0];
                        this.listViewok.Items.Remove(lvi);
                        this.listViewok.Items.Insert(intIndex - 1, lvi);
                        this.listViewok.Items[intIndex - 1].Tag = lvi.Tag;
                        this.listViewok.Focus();
                        //this.listViewok.Items[intIndex - 1].Selected = true;
                        if (intIndex > 0)
                        {
                            this.listViewok.Items[0].Selected = true;
                            this.listViewok.EnsureVisible(0);
                            this.listViewok.Focus();
                        }

                    }
                }
                else
                {
                    if (this.tab.SelectedTab.Text == "未发")
                    {
                        int intIndex = this.m_lsvPatientDetial.Items.Count;
                        if (intIndex > 0)
                        {
                            this.m_lsvPatientDetial.Items[0].Selected = true;
                            this.m_lsvPatientDetial.EnsureVisible(0);
                            this.m_lsvPatientDetial.Focus();
                        }
                    }
                    else if (this.tab.SelectedTab.Text == "已发")
                    {
                        int intIndex = this.listViewok.Items.Count;
                        if (intIndex > 0)
                        {
                            this.listViewok.Items[0].Selected = true;
                            this.listViewok.EnsureVisible(0);
                            this.listViewok.Focus();
                        }
                    }
                }
            }
            this.m_blnIsCallFlag = true;
            this.m_cmdRefersh.PerformClick();
            //this.m_blnIsCallFlag = false;
            this.Cursor = Cursors.Default;
            this.m_btnCall.Enabled = true;

            //    m_objTempVo = new clsCallPatientVo();
            //    m_objTempVo.m_strPatientName = this.m_lsvPatientDetial.SelectedItems[0].Text.Trim();
            //    m_objTempVo.m_strServerNo = this.m_lsvPatientDetial.SelectedItems[0].SubItems[1].Text.Trim();
            //    if (m_objArrayList.Count == 0)
            //    {
            //        m_objArrayList.Add(m_objTempVo);
            //    }
            //    else
            //    {
            //        for (int i = 0; i < m_objArrayList.Count; i++)
            //        {
            //            if (((clsCallPatientVo)m_objArrayList[i]).m_strServerNo == m_objTempVo.m_strServerNo)
            //            {
            //                break;
            //            }
            //            else
            //            {
            //                if (i == m_objArrayList.Count - 1)
            //                {
            //                    m_objArrayList.Add(m_objTempVo);
            //                }
            //            }

            //        }
            //    }

            //    string m_strWindowNo = this.cbWindows.Text.Trim().Substring(2, 1).Trim();
            //    string m_strPatientName = this.m_lsvPatientDetial.SelectedItems[0].Text.Trim();
            //    string m_strCallContent = "请" + m_strPatientName + "到" + m_strWindowNo + "号窗口取药";
            //    TTSClient.TTSClient.PlaySound(m_strCallContent);
            //    int m_objBmpCount = (int)Math.Ceiling(double.Parse(m_objArrayList.Count.ToString()) / 12);

            //    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen = frmSmallScreen.SmallScreenForm(this.m_lsvPatientDetial.SelectedItems[0].Text.Trim());
            //    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_objBmpArr = new Bitmap[m_objBmpCount];
            //    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_blnShowPreviewLED = this.m_chkShowScreen.Checked;
            //    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_strMedStoreID = this.statusWindows.strStorageID;
            //    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_strWindowID = this.statusWindows.strWindowID;
            //    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_intIndex = 0;
            //    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.timer1.Interval = ((clsControlOPMedStore)this.objController).m_intPreviewLEDRefreshTime * 1000;
            //    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_mthShowContent(this.cbWindows.Text.Trim(), this.m_lsvPatientDetial, m_objArrayList);
        }
        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmOPMedStoreWin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (((clsControlOPMedStore)this.objController).m_objfrmRecipeType != null)
            {
                ((clsControlOPMedStore)this.objController).m_objfrmRecipeType.Close();
            }
            if (((clsControlOPMedStore)this.objController).m_objfrmSmallScreen != null)
            {
                ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_mthCloseLED();
            }
            else
            {
                frmSmallScreen.SmallScreenFrm = null;
            }
            this.m_timer.Enabled = false;
        }

        private void m_btnPause_TextChanged(object sender, EventArgs e)
        {
            if (this.m_btnPause.Tag.ToString() == "pause")
            {
                this.m_btnCall.Enabled = true;
            }
            else if (this.m_btnPause.Tag.ToString() == "resume")
            {
                this.m_btnCall.Enabled = false;
            }
        }

        private void m_btnPause_Click(object sender, EventArgs e)
        {
            if (this.m_btnPause.Tag.ToString() == "pause")
            {
                this.m_btnPause.Tag = "resume";
                this.m_btnPause.Text = "继续(&M)";
                ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen = frmSmallScreen.SmallScreenForm(string.Empty);
                ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_mthPauseServer();
                if (this.m_chkShowScreen.Checked == true)
                {
                    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.ShowInTaskbar = false;
                    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.Opacity = 100;
                    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.Show();
                }



            }
            else
            {
                this.m_btnPause.Tag = "pause";
                this.m_btnPause.Text = "暂停(&P)";
                ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen = frmSmallScreen.SmallScreenForm(string.Empty);
                ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_mthGoOnServer();

            }
        }

        private void m_chkShowScreen_CheckedChanged(object sender, EventArgs e)
        {
            if (frmSmallScreen.SmallScreenFrm != null)
            {
                ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.m_blnShowPreviewLED = this.m_chkShowScreen.Checked ? true : false;
                if (this.m_chkShowScreen.Checked == false)
                {

                    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.Hide();
                }
                else
                {
                    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.ShowInTaskbar = false;
                    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.Opacity = 100;
                    ((clsControlOPMedStore)this.objController).m_objfrmSmallScreen.Show();
                }
            }
        }

        private void m_txtSeqID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (this.m_txtSeqID.Text.Trim() == string.Empty)
                {
                    ((clsControlOPMedStore)this.objController).publiClass.m_mthShowWarning(this.m_lsvPatientDetial, "请输入正确的流水号！！");
                }
                else if (this.m_txtSeqID.Text.Length == 10)
                {
                    string strCard = this.m_txtSeqID.Text;
                    if (this.statusWindows.statusTone == 2)
                    {
                        for (int i = 0; i < this.m_lsvPatientDetial.Items.Count; i++)
                        {
                            if (this.m_lsvPatientDetial.Items[i].SubItems[3].Text.Trim() == strCard)
                            {
                                this.m_lsvPatientDetial.Items[i].Selected = true;
                                clsOutpatientRecipe_VO objRecipe = (clsOutpatientRecipe_VO)this.m_lsvOpRecDetail.SelectedItems[0].Tag;
                                ((clsControlOPMedStore)this.objController).m_mthSend(this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName, objRecipe);
                                i = i - 1;
                            }
                        }
                        this.m_txtSeqID.Clear();
                        this.m_txtSeqID.Focus();
                    }
                }
                else if (this.m_txtSeqID.Text.Length <= 4)
                {
                    string m_strSerNO = this.m_txtSeqID.Text.PadLeft(4, '0');
                    this.m_txtSeqID.Text = m_strSerNO;
                    int intTemp = 0;
                    for (int i = 0; i < this.m_lsvPatientDetial.Items.Count; i++)
                    {
                        this.m_lsvPatientDetial.Items[i].BackColor = System.Drawing.Color.White;
                        if (this.m_lsvPatientDetial.Items[i].SubItems[1].Text.Trim() == m_strSerNO)
                        {
                            intTemp = 1;
                            this.m_lsvPatientDetial.Items[i].Selected = true;
                            this.m_lsvPatientDetial.Items[i].BackColor = System.Drawing.Color.LightBlue;
                            //this.m_lsvPatientDetial.Items[i].Focused = true;
                            //this.m_lsvOpRecDetail.Items[0].Selected = true;
                            this.m_lsvPatientDetial.Items[i].EnsureVisible();
                            #region 暂时屏蔽叫号功能 2008.7.9 chongkun.wu
                            //this.m_btnCall.PerformClick();
                            #endregion
                            this.m_txtSeqID.SelectAll();
                        }
                    }
                    if (intTemp == 0)
                    {
                        ((clsControlOPMedStore)this.objController).publiClass.m_mthShowWarning(this.m_lsvPatientDetial, "没有找到该流水号对应的病人信息！！");
                    }
                }
                else if (this.m_txtSeqID.Text.Length > 14)
                {
                    string strCardID = ((clsControlOPMedStore)this.objController).m_strGetCardID(this.m_txtSeqID.Text, "1");
                    if (strCardID == "")
                    {
                        strCardID = ((clsControlOPMedStore)this.objController).m_strGetCardID(this.m_txtSeqID.Text, "2");
                    }
                    if (strCardID != "")
                    {
                        this.m_txtSeqID.Text = strCardID;
                        SendKeys.Send("{ENTER}");
                    }
                }
            }
        }

        private void m_timerDispense_Tick(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthAutoDispenseAfterAutoPrint();
        }

        private void m_pdTreatTip_BeginPrint(object sender, PrintEventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_ResetPage();
            if (((clsControlOPMedStore)this.objController).m_objTreatTipPrint.PrintRecipeVOInfo.objTreatArr.Count <= 0)
            {
                e.Cancel = true;
            }
        }

        private void m_btnTreat_Click(object sender, EventArgs e)
        {
            if (isSeleItem())
            {
                ((clsControlOPMedStore)this.objController).m_lngPrintTreatTip((System.Windows.Forms.Control)sender);
            }
            else
            {
            }
        }
        private void m_pdTreatTip_PrintPage(object sender, PrintPageEventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthPrintTreatTip(e);
        }

        private void m_btnCaseHistory_Click(object sender, EventArgs e)
        {
            if (isSeleItem())
            {
                ((clsControlOPMedStore)this.objController).m_mthPrintCaseHistory((System.Windows.Forms.Control)sender);
            }
            else
            {
            }
        }

        private void m_objPDHistoryCase_BeginPrint(object sender, PrintEventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthBeginPrintCaseHistory(e);
        }

        private void m_objPDHistoryCase_PrintPage(object sender, PrintPageEventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthPrintCaseHistory(e);
        }

        private void m_lsvPatientDetial_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.statusWindows.statusTone == 1)
            {
                this.btnDosage_Click(null, null);
            }
        }

        private void m_lsvPatientDetial_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.statusWindows.statusTone == 1 && e.KeyCode == Keys.Enter && this.m_lsvPatientDetial.Focused == true)
            {
                this.btnDosage_Click(null, null);
            }
        }

        private void listViewok_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.statusWindows.statusTone == 1)
            {
                this.btnDosage_Click(null, null);
            }
        }

        private void listViewok_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.statusWindows.statusTone == 1 && e.KeyCode == Keys.Enter && this.listViewok.Focused == true)
            {
                this.btnDosage_Click(null, null);
            }
        }

        private void CmdCancel2_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthCancelSetDefault(2);
        }

        private void CmdCancel3_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthCancelSetDefault(3);
        }

        private void CmdCancel4_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthCancelSetDefault(4);
        }

        private void CmdSetEemp2_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthGetName(2);

        }

        private void CmdSetEmp3_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthGetName(3);
        }

        private void CmdSetEmp4_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_mthGetName(4);
        }

        private void txtEmpNo2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPsw2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmpNo3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void txtPsw3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtEmpNo4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void txtPsw4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void m_lsvPatientDetial_Click(object sender, EventArgs e)
        {
            if (this.m_lsvOpRecDetail.Items.Count > 0)
                this.m_lsvOpRecDetail.Items[0].Selected = true;
        }

        private void backgroundWorkerCall_DoWork(object sender, DoWorkEventArgs e)
        {
            int m_Number = 1;
            int m_Waite = 3000;
            if (!string.IsNullOrEmpty(this.objController.m_objComInfo.m_lonGetModuleInfo("0417")))
            {
                m_Number = Convert.ToInt16(this.objController.m_objComInfo.m_lonGetModuleInfo("0417"));
            }
            if (!string.IsNullOrEmpty(this.objController.m_objComInfo.m_lonGetModuleInfo("0415")))
            {
                m_Waite = Convert.ToInt16(this.objController.m_objComInfo.m_lonGetModuleInfo("0415"));
            }
            for (int i = 0; i < m_Number; i++)
            {
                TTSClient.TTSClient.PlaySound(m_strCallContent);
                System.Threading.Thread.Sleep(m_Waite * 1000);
            }
        }

        private void 取消叫号ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_lngCancleCalledFlag();
        }

        private void m_txtPatientCard1_CardKeyDown(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).m_lngAction();
            m_txtPatient.Focus();
        }

        internal void btnPrintYD_Click(object sender, EventArgs e)
        {
            if (isSeleItem())
            {
                ((clsControlOPMedStore)this.objController).m_mthPrintYD(false);
            }
        }

        private void m_lsvPatientDetial_DoubleClick_1(object sender, EventArgs e)
        {
            if (this.statusWindows.statusTone == 2)
            {
                if (this.m_lsvOpRecDetail.SelectedItems.Count > 0)
                {
                    clsOutpatientRecipe_VO objRecipe = (clsOutpatientRecipe_VO)this.m_lsvOpRecDetail.SelectedItems[0].Tag;
                    ((clsControlOPMedStore)this.objController).m_mthSend(this.LoginInfo.m_strEmpID, this.LoginInfo.m_strEmpName, objRecipe);
                }
                this.m_txtSeqID.Clear();
                this.m_txtSeqID.Focus();
            }
        }

        private void tsmiDrugInfo_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).UseMedItf();
        }

        private void tsmiDrugInfo2_Click(object sender, EventArgs e)
        {
            ((clsControlOPMedStore)this.objController).UseMedItf();
        }

        private void txtWechatCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.statusWindows.statusTone == 2)
                {
                    ((clsControlOPMedStore)this.objController).Barcode2Sendmed(this.txtWechatCode.Text.Trim());
                }
                else
                {
                    ((clsControlOPMedStore)this.objController).LedSocketMsg(0, this.txtWechatCode.Text.Trim());
                }
            }
        }

        private void txtWechatCode_TextChanged(object sender, EventArgs e)
        {
            if (this.txtWechatCode.Text.Trim().Length == 18)
            {
                if (this.statusWindows.statusTone == 2)
                {
                    ((clsControlOPMedStore)this.objController).Barcode2Sendmed(this.txtWechatCode.Text.Trim());
                }
                else
                {
                    ((clsControlOPMedStore)this.objController).LedSocketMsg(0, this.txtWechatCode.Text.Trim());
                }
            }
        }

        private void frmOPMedStoreWin_Activated(object sender, EventArgs e)
        {
            this.txtWechatCode.Focus();
        }


    }
}
