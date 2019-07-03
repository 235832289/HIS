using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.IO.Ports;
using com.digitalwave.iCare.middletier.LIS;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmMK3Operation : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// 串口
        /// </summary>
        private SerialPort Com = new SerialPort();
        /// <summary>
        /// 样本号数组
        /// </summary>
        internal string[] m_strSampleArr = null;

        private string m_strStyle = null;
        /// <summary>
        /// 孔号数组
        /// </summary>
        private string[] m_strHoleArr = new string[96];

        int intCustomize = 0;

        clsCtl_MK3Operation m_objController;
        /// <summary>
        /// 仪器型号
        /// </summary>
        internal string m_strDeviceModel;
        /// <summary>
        /// 仪器ID
        /// </summary>
        internal string m_strDeviceId;
        /// <summary>
        /// 检验项目名称
        /// </summary>
        internal string m_strCheckItemName;
        int intState = -1;
        SerialPort com1 = new SerialPort();
        /// <summary>
        /// 所用串口
        /// </summary>
        internal string m_strPortName;
        /// <summary>
        /// Textbox控件链表
        /// </summary>
        internal List<Control.ctlLISMK3TextBox> m_lstTextBos = null;
        /// <summary>
        /// label控件链表
        /// </summary>
        internal List<System.Windows.Forms.Control> m_lstLbl = null;

        private int idx = 0;

        private string m_strFistLab = null;
        /// <summary>
        /// 检验项目ID
        /// </summary>
        internal string m_strCheckItemID = null;
        /// <summary>
        /// 仪器型号ID
        /// </summary>
        internal string m_strDeviceModelId = null;
        /// <summary>
        /// NC次数
        /// </summary>
        int intNCTime = 1;
        /// <summary>
        /// PC次数
        /// </summary>
        int intPCTime = 1;
        internal int intPlateResult = 0;

        /// <summary>
        /// Cutoff值
        /// </summary>
        internal string m_strCutoff = null;

        /// <summary>
        /// 阴性对照值
        /// </summary>
        internal string m_strContrastNC = null;

        /// <summary>
        /// 阳性对照值
        /// </summary>
        internal string m_strContrastPC = null;

        /// <summary>
        /// S/CO值
        /// </summary>
        internal string m_strSExceptCO = null;

        /// <summary>
        /// 阴阳性判断公式
        /// </summary>
        internal string m_strJudgNcAndPc = null;

        /// <summary>
        /// 检验项目名称
        /// </summary>
        internal string m_strPlanChaName = null;


        #endregion

        #region 构造函数
        public frmMK3Operation()
        {
            InitializeComponent();
        }
        #endregion

        #region 创建控制层
        public override void CreateController()
        {
            m_objController = new clsCtl_MK3Operation();
            m_objController.Set_GUI_Apperance(this);
            objController = m_objController;
        }
        #endregion

        private void m_btnOnLine_Click(object sender, EventArgs e)
        {
            if (intState > 0)
            {
                return;
            }
            long lngRes = 0;
            lngRes = m_objController.m_lngStartWork();
            if (lngRes == 1)
            {
                m_txtState.Text = "连机成功";
                intState = 1;
            }
        }

        private void frmMK3Operation_Load(object sender, EventArgs e)
        {

            m_lstTextBos = new List<com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox>();
            m_lstLbl = new List<System.Windows.Forms.Control>();
            //m_rabDefaultLayout.Checked = true;

            m_rabCustomLayout.Checked = true;
            m_rabSet.Checked = true;
            try
            {
                string strConfigFilePath = Application.StartupPath + "\\MK3.config";
                System.Configuration.ConfigXmlDocument appConfig = new System.Configuration.ConfigXmlDocument();
                appConfig.Load(strConfigFilePath);
                m_strDeviceModel = appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"strDeviceModel\"]").Attributes["value"].Value.Trim();
                m_strDeviceId = appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"strDeviceId\"]").Attributes["value"].Value.Trim();
                m_strPortName = appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"strPortName\"]").Attributes["value"].Value.Trim();
                m_strDeviceModelId = appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"strDeviceModelID\"]").Attributes["value"].Value.Trim();

                m_lstTextBos.AddRange(new Control.ctlLISMK3TextBox[] { m_txtSample01, m_txtSample02, m_txtSample03, m_txtSample04, m_txtSample05, m_txtSample06, m_txtSample07, m_txtSample08, m_txtSample09, m_txtSample10, m_txtSample11,
                    m_txtSample12, m_txtSample13, m_txtSample14, m_txtSample15, m_txtSample16, m_txtSample17, m_txtSample18, m_txtSample19, m_txtSample20, m_txtSample21, m_txtSample22, m_txtSample23,
                    m_txtSample24, m_txtSample25, m_txtSample26, m_txtSample27, m_txtSample28, m_txtSample29, m_txtSample30, m_txtSample31, m_txtSample32, m_txtSample33, m_txtSample34, m_txtSample35, m_txtSample36,
                    m_txtSample37, m_txtSample38, m_txtSample39, m_txtSample40, m_txtSample41, m_txtSample42, m_txtSample43, m_txtSample44, m_txtSample45, m_txtSample46, m_txtSample47, m_txtSample48, m_txtSample49, m_txtSample50
                    , m_txtSample51, m_txtSample52, m_txtSample53, m_txtSample54, m_txtSample55, m_txtSample56, m_txtSample57, m_txtSample58, m_txtSample59, m_txtSample60, m_txtSample61, m_txtSample62, m_txtSample63, m_txtSample64,
                    m_txtSample65, m_txtSample66, m_txtSample67, m_txtSample68, m_txtSample69, m_txtSample70, m_txtSample71, m_txtSample72, m_txtSample73, m_txtSample74, m_txtSample75, m_txtSample76, m_txtSample77, m_txtSample78, m_txtSample79, m_txtSample80,
                    m_txtSample81, m_txtSample82, m_txtSample83, m_txtSample84, m_txtSample85, m_txtSample86, m_txtSample87, m_txtSample88, m_txtSample89, m_txtSample90, m_txtSample91, m_txtSample92, m_txtSample93, m_txtSample94, m_txtSample95, m_txtSample96});
                if (m_lstTextBos != null && m_lstTextBos.Count > 0)
                {
                    foreach (Control.ctlLISMK3TextBox ctl in m_lstTextBos)
                    {
                        ctl.Click += new EventHandler(ctl_Click);
                        ctl.Leave += new EventHandler(ctl_Leave);
                        ctl.ReadOnly = true;


                    }
                }


                m_lstLbl.AddRange(new System.Windows.Forms.Control[] {m_lblSample01, m_lblSample02, m_lblSample03, m_lblSample04, m_lblSample05, m_lblSample06, m_lblSample07, m_lblSample08, m_lblSample09, m_lblSample10, m_lblSample11, m_lblSample12, m_lblSample13, m_lblSample14, m_lblSample15, m_lblSample16,
                    m_lblSample17, m_lblSample18, m_lblSample19, m_lblSample20, m_lblSample21, m_lblSample22, m_lblSample23, m_lblSample24, m_lblSample25, m_lblSample26, m_lblSample27, m_lblSample28, m_lblSample29, m_lblSample30, m_lblSample31, m_lblSample32, m_lblSample33,
                    m_lblSample34, m_lblSample35, m_lblSample36, m_lblSample37, m_lblSample38, m_lblSample39, m_lblSample40, m_lblSample41, m_lblSample42, m_lblSample43, m_lblSample44, m_lblSample45, m_lblSample46, m_lblSample47, m_lblSample48, m_lblSample49, m_lblSample50,
                    m_lblSample51, m_lblSample52, m_lblSample53, m_lblSample54, m_lblSample55, m_lblSample56, m_lblSample57, m_lblSample58, m_lblSample59, m_lblSample60, m_lblSample61, m_lblSample62, m_lblSample63, m_lblSample64, m_lblSample65, m_lblSample66, m_lblSample67,
                    m_lblSample68, m_lblSample69, m_lblSample70, m_lblSample71, m_lblSample72, m_lblSample73, m_lblSample74, m_lblSample75, m_lblSample76, m_lblSample77, m_lblSample78, m_lblSample79, m_lblSample80, m_lblSample81, m_lblSample82, m_lblSample83, m_lblSample84,
                    m_lblSample85, m_lblSample86, m_lblSample87, m_lblSample88, m_lblSample89, m_lblSample90, m_lblSample91, m_lblSample92, m_lblSample93, m_lblSample94, m_lblSample95, m_lblSample96});

            }
            catch
            {
                MessageBox.Show("初始化失败！,请重新启动", "酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            m_objController.GetInstrumentSerialSetting();
            m_objController.m_mthGetAllCheckItemCustomInfo();
            m_objController.m_mthGetDeviceCheckItem();
            m_objController.m_mthGetAllItemLayoutInfo();
            m_objController.m_mthGetAllPlateResult();
            m_mthSetNewControl();
            m_dwPrint.LibraryList = Application.StartupPath + @"\pb_lis.pbl";
            m_dwPrint.DataWindowObject = "d_lis_mk3_result";
        }

        void ctl_Leave(object sender, EventArgs e)
        {
            int tmp = 0;
            Control.ctlLISMK3TextBox ctl = sender as Control.ctlLISMK3TextBox;
            if (ctl == null)
                return;
            if (string.IsNullOrEmpty(ctl.Text))
                return;
            bool blnSure = false;
            try
            {
                if (!int.TryParse(ctl.Text, out tmp))
                {
                    return;
                }

            }
            catch
            {
                return;
            }
            //if (ctl.m_strItmeID != m_cboItem.SelectedValue.ToString() && ctl.m_strItmeID != null)
            //{
            //    blnSure = MessageBox.Show(this, "所选项目同已有项目不同,是否继续", "MK3酶标仪信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK;
            //    if (!blnSure)
            //        return;
            //}
            string m_strSampleType = null;
            if (m_rabBlk.Checked)
            {
                m_strSampleType = Control.ctlLISMK3TextBox.m_enmSampleType.Blk.ToString();
            }
            if (m_rabNeg.Checked)
            {
                m_strSampleType = Control.ctlLISMK3TextBox.m_enmSampleType.Neg.ToString();
            }
            if (m_rabPos.Checked)
            {
                m_strSampleType = Control.ctlLISMK3TextBox.m_enmSampleType.Pos.ToString();
            }
            if (m_rabQC.Checked)
            {
                m_strSampleType = Control.ctlLISMK3TextBox.m_enmSampleType.QC.ToString();
            }
            if (m_rabSmp.Checked)
            {
                m_strSampleType = Control.ctlLISMK3TextBox.m_enmSampleType.Smp.ToString();
            }
            if (m_rabNone.Checked)
            {
                m_strSampleType = Control.ctlLISMK3TextBox.m_enmSampleType.None.ToString();
            }
            blnSure = false;
            //if (ctl.m_enmSelceType.ToString() != m_strSampleType)
            //{
            //    if (ctl.m_enmSelceType.ToString().ToLower() != "none")
            //    {
            //        blnSure = MessageBox.Show(this, "所选样本类型同已有的不同,是否继续", "MK3酶标仪信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK;
            //        if (!blnSure)
            //        {
            //            return;
            //        }
            //    }
            //}
            ctl.m_strItmeID = m_cboItem.SelectedValue.ToString();
            if (tmp >= 1000)
            {
                ctl.m_strSampleID = tmp.ToString();
                ctl.Text = tmp.ToString();
            }
            else
            {
                ctl.m_strSampleID = tmp.ToString("000");
                ctl.Text = tmp.ToString("000");
            }
            int idxSample = m_lstTextBos.IndexOf(ctl);
            switch (m_strSampleType)
            {
                case "None":
                    ctl.m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.None;
                    break;
                case "Smp":
                    ctl.m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.Smp;
                    m_lstLbl[idxSample].Text = "Smp" + ctl.Text;
                    break;
                case "QC":
                    ctl.m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.QC;
                    m_lstLbl[idxSample].Text = "QC";

                    break;
                case "Pos":
                    ctl.m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.Pos;
                    m_lstLbl[idxSample].Text = "PC";
                    break;
                case "Neg":
                    ctl.m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.Neg;
                    m_lstLbl[idxSample].Text = "NC";
                    break;
                case "Blk":
                    ctl.m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.Blk;
                    m_lstLbl[idxSample].Text = "Blk";
                    break;
            }
        }


        void ctl_Click(object sender, EventArgs e)
        {
            if (!m_rabCustomLayout.Checked)
                return;
            if (m_rabInPut.Checked)
            {

                return;
            }
            Control.ctlLISMK3TextBox ctl = sender as Control.ctlLISMK3TextBox;
            if (ctl == null)
                return;
            int idxNext = m_lstTextBos.IndexOf(ctl);
            if (m_rabEnd.Checked)
            {
                m_rabStart.Checked = true;
                int intStartSample = Convert.ToInt32(m_txtStartNO.Text);
                int idxStart = 0;
                int idxEnd = 0;
                if (idx > idxNext)
                {
                    idxStart = idxNext;
                    idxEnd = idx;
                }
                else
                {
                    idxStart = idx;
                    idxEnd = idxNext;

                }
                if (m_rabCalcu.Checked)
                {
                    if (string.IsNullOrEmpty(m_cboCutoff.Text))
                    {
                        return;
                    }
                    m_mthCalc(idxStart, idxEnd);
                }
                else
                {

                    if (string.IsNullOrEmpty(m_txtStartNO.Text))
                        return;
                    if (!m_rabNone.Checked)
                    {
                        if (m_lstTextBos[idxNext].m_enmSelceType.ToString() != "None")
                        {
                            m_lstLbl[idx].Text = m_strFistLab;
                            return;
                        }
                    }
                    string m_strCheckItemID = m_cboItem.SelectedValue.ToString();
                    DataView drTemp = null;
                    DataTable dtResult = null;
                    if (m_objController.m_dtResult == null)
                        return;
                    int iR;
                    int iG;
                    int iB;
                    string strColor = null;
                    string[] m_strColorArr = null;
                    for (; idxStart <= idxEnd; idxStart++)
                    {
                        if (m_rabNone.Checked)
                        {

                            m_lstTextBos[idxStart].Text = "";
                            m_lstTextBos[idxStart].m_strItmeID = null;
                            m_lstTextBos[idxStart].m_strSampleID = null;
                            m_lstTextBos[idxStart].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.None;
                            m_lstTextBos[idxStart].BackColor = Color.White;
                            m_lstLbl[idxStart].Text = "";

                        }
                        else
                        {
                            if (m_lstTextBos[idxStart].m_enmSelceType.ToString() != "None")
                            {
                                continue;
                            }
                            dtResult = m_objController.m_dtResult.Copy();
                            drTemp = dtResult.DefaultView;
                            drTemp.RowFilter = "check_item_id_chr='" + m_strCheckItemID + "'";
                            if (drTemp.Count > 0)
                            {

                                strColor = drTemp[0]["check_item_color_vchr"].ToString().Trim();
                                m_strColorArr = strColor.Split(new char[] { ':', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                                if (m_strColorArr != null)
                                {
                                    if (m_strColorArr.Length == 3)
                                    {
                                        iR = Convert.ToInt32(m_strColorArr[0]);
                                        iG = Convert.ToInt32(m_strColorArr[1]);
                                        iB = Convert.ToInt32(m_strColorArr[2]);
                                        m_lstTextBos[idxStart].BackColor = Color.FromArgb(iR, iG, iB);

                                    }
                                }

                            }

                            m_lstTextBos[idxStart].m_strItmeID = m_strCheckItemID;
                            m_lstTextBos[idxStart].m_strCheckItemName = m_cboItem.Text;
                            if (intStartSample >= 1000)
                            {

                                m_lstTextBos[idxStart].Text = intStartSample.ToString();
                                m_lstTextBos[idxStart].m_strSampleID = intStartSample.ToString();

                            }
                            else
                            {

                                m_lstTextBos[idxStart].Text = intStartSample.ToString("000");
                                m_lstTextBos[idxStart].m_strSampleID = intStartSample.ToString("000");

                            }
                            if (m_rabQC.Checked)
                            {
                                m_lstTextBos[idxStart].m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.QC;
                                m_lstTextBos[idxStart].Text = "QC";
                                m_lstTextBos[idxStart].m_strSampleID = "QC";


                            }
                            if (m_rabNeg.Checked)
                            {
                                m_lstTextBos[idxStart].m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.Neg;
                                m_lstTextBos[idxStart].Text = "NC" + intNCTime.ToString();
                                m_lstTextBos[idxStart].m_strSampleID = "NC" + intNCTime.ToString();

                                intNCTime++;
                            }
                            if (m_rabPos.Checked)
                            {
                                m_lstTextBos[idxStart].m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.Pos;
                                m_lstTextBos[idxStart].Text = "PC" + intPCTime.ToString();
                                m_lstTextBos[idxStart].m_strSampleID = "PC" + intPCTime.ToString();

                                intPCTime++;
                            }

                            if (m_rabBlk.Checked)
                            {
                                m_lstTextBos[idxStart].m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.Blk;
                                m_lstTextBos[idxStart].Text = "Blk";
                                m_lstTextBos[idxStart].m_strSampleID = "Blk";

                            }
                            m_lstLbl[idxStart].Text = m_lstTextBos[idxStart].m_enmSelceType.ToString();
                            if (m_rabSmp.Checked)
                            {
                                m_lstTextBos[idxStart].m_enmSelceType = Control.ctlLISMK3TextBox.m_enmSampleType.Smp;
                                m_lstLbl[idxStart].Text = m_lstTextBos[idxStart].m_enmSelceType.ToString() + m_lstTextBos[idxStart].m_strSampleID;
                                intStartSample++;
                            }

                        }
                        m_lstTextBos[idxStart].Tag = "";
                    }
                    this.m_txtStartNO.Text = intStartSample.ToString();
                    m_mthCalc();
                }
            }
            else
            {
                idx = m_lstTextBos.IndexOf(ctl);
                m_strFistLab = m_lstLbl[idx].Text;
                m_lstLbl[idx].Text = "Start";
                m_rabEnd.Checked = true;
            }
        }


        private void m_btnStart_Click(object sender, EventArgs e)
        {
            m_txtState.Text = "";
            if (intState < 0)
            {
                m_txtState.Text = "尚未连机,请先连机";
                return;
            }
            if (intState == 3)
            {
                return;
            }
            long lngRes = 0;
            m_objController.m_lngStratComputer();
        }

        private void m_btnReadPlate_Click(object sender, EventArgs e)
        {
            intPCTime = 1;
            intNCTime = 1;
            if (m_lstTextBos.Count <= 0)
                return;
            m_strCheckItemID = m_cboItem.SelectedValue.ToString();
            m_txtState.Text = "";

            if (intState == -1)
            {
                m_txtState.Text = "请连接仪器";
                return;
            }
            if (m_objController.intState != 1)
            {
                m_txtState.Text = "请启动计算机控制";
                return;
            }
            long lngRes = 0;
            lngRes = m_objController.m_mthGetCheckItemCustomOrder();
            if (lngRes < 0 && m_objController.m_objCheckItemCustomOrder == null)
            {
                MessageBox.Show(this, "请设置仪器通讯命令", " MK3酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //m_objCheckItemCustomArr[0].
            m_strCheckItemName = m_cboItem.Text;
            Cursor.Current = Cursors.WaitCursor;

            m_objController.m_mthAOrder();
            Cursor.Current = Cursors.Default;
        }

        private void frmMK3Operation_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_btnExit_Click(null, null);
        }

        private void m_btnClear_Click(object sender, EventArgs e)
        {
            intNCTime = 1;
            intPCTime = 1;
            if (m_lstTextBos.Count <= 0 || m_lstLbl.Count <= 0)
            {
                return;
            }
            for (int i = 0; i < m_lstTextBos.Count; i++)
            {
                m_lstTextBos[i].Text = "";
                m_lstTextBos[i].m_strItmeID = null;
                m_lstTextBos[i].m_strSampleID = null;

                m_lstTextBos[i].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.None;
                m_lstTextBos[i].BackColor = Color.White;
                m_lstLbl[i].ForeColor = Color.Black;
                m_lstLbl[i].Text = "";

            }
        }

        private void m_rabCustomLayout_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_rabCustomLayout.Checked)
            {
                m_panlCustom.Enabled = true;
                m_rabSmp.Checked = true;
                m_rabStart.Checked = true;
                m_panDefault.Enabled = false;
            }
            else
            {
                m_panDefault.Enabled = true;
            }
        }

        private void m_rabDefaultLayout_CheckedChanged(object sender, EventArgs e)
        {
            if (this.m_rabDefaultLayout.Checked)
            {
                m_panlCustom.Enabled = false;
                m_rabDefaultQC.Checked = true;
                m_cboLayout.SelectedIndex = 0;
            }
            else
            {
                m_panlCustom.Enabled = true;
            }
        }

        private void m_rabInPut_CheckedChanged(object sender, EventArgs e)
        {
            if (m_lstTextBos.Count <= 0)
                return;
            if (m_rabInPut.Checked)
            {
                for (int i = 0; i < m_lstTextBos.Count; i++)
                {
                    //if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() != "neg" && m_lstTextBos[i].m_enmSelceType.ToString().ToLower() != "pos")
                    //{
                    //    m_lstTextBos[i].ReadOnly = false;
                    //}
                    m_lstTextBos[i].ReadOnly = false;
                }
            }
            else
            {
                for (int i = 0; i < m_lstTextBos.Count; i++)
                {
                    m_lstTextBos[i].ReadOnly = true;
                }
            }
        }

        private void m_cboItem_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (m_objController.m_dtResult != null)   //获取阴阳性判断公式
            {
                DataTable dtItemTabl = m_objController.m_dtResult.Copy();

                DataView dtCheckItem = dtItemTabl.DefaultView;
                dtCheckItem.RowFilter = "check_item_name_vchr='" + m_cboItem.Text + "'";

                m_strJudgNcAndPc = dtCheckItem[0]["CHECK_ITEM_FORMULA_VCHR"].ToString().Trim();

            }

            intNCTime = 1;
            intPCTime = 1;
            if (m_lstTextBos.Count <= 0)
                return;
            string strStartNum = null;
            for (int i = 0; i < m_lstTextBos.Count; i++)
            {
                if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "smp")
                {
                    if (i < 1)
                        return;
                    if (m_lstTextBos[i - 1].m_enmSelceType.ToString().ToLower() != "smp")
                    {
                        strStartNum = m_lstTextBos[i].m_strSampleID;
                    }
                }
            }
            if (strStartNum == null)
                return;
            int intNum;
            try
            {
                if (int.TryParse(strStartNum, out intNum))
                {
                    m_txtStartNO.Text = intNum.ToString();
                }
            }
            catch
            {
                return;
            }
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            long lngRes = 0;
            m_txtState.Text = "";
            lngRes = m_objController.m_lngFinishWork();
            if (lngRes == 1)
            {
                intState = -1;
            }
        }



        private void m_btnSave_Click(object sender, EventArgs e)
        {
            if (m_objController.m_dtLayoutName != null)
            {
                DataTable m_dtLayoutInfo = m_objController.m_dtLayoutName;
                DataView dvTemp = m_dtLayoutInfo.DefaultView;
                dvTemp.RowFilter = "layoutname_vchr='" + m_txtLayout.Text + "'";
                if (dvTemp != null && dvTemp.Count > 0)
                {
                    MessageBox.Show(this, "该布局名称已有请重新输入", "MK3酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_txtLayout.Text = "";
                    m_txtLayout.Focus();
                    return;
                }
            }
            List<clslisItemLayout> m_lstItemLayout = new List<clslisItemLayout>();
            clslisItemLayout objTemp = null;
            if (m_lstTextBos.Count > 0)
            {
                for (int i = 0; i < m_lstTextBos.Count; i++)
                {
                    if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() != "none")
                    {
                        objTemp = new clslisItemLayout();
                        objTemp.m_strCheckitemname_vchr = m_lstTextBos[i].m_strCheckItemName;
                        objTemp.m_strLayoutname_vchr = m_txtLayout.Text;
                        objTemp.m_strSampleid_vchr = m_lstTextBos[i].m_strSampleID;
                        objTemp.m_strSampleType_chr = m_lstTextBos[i].m_enmSelceType.ToString();
                        objTemp.m_strCheckItemID = m_lstTextBos[i].m_strItmeID;
                        objTemp.m_strControlidx_chr = i.ToString();
                        m_lstItemLayout.Add(objTemp);
                    }
                }
                if (m_lstItemLayout.Count > 0)
                {
                    m_objController.m_mthAddItemLayout(m_lstItemLayout.ToArray());
                }
            }

        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            m_objController.m_mthDeleteItemLayout();
        }

        private void m_cboLayout_SelectedIndexChanged(object sender, EventArgs e)
        {
            m_btnClear_Click(null, null);
            if (m_objController.m_dtLayoutInfo == null)
                return;
            DataTable m_dtLayoutInfo = m_objController.m_dtLayoutInfo;
            DataView dvTemp = m_dtLayoutInfo.DefaultView;
            dvTemp.RowFilter = "layoutname_vchr='" + m_cboLayout.Text + "'";
            if (dvTemp != null && dvTemp.Count > 0)
            {
                int idx;
                DataView drTemp = null;
                DataTable dtResult = null;
                if (m_objController.m_dtResult == null)
                    return;
                string m_strCheckItemID = null;
                int iR;
                int iG;
                int iB;
                string strColor = null;
                string[] m_strColorArr = null;
                for (int i = 0; i < dvTemp.Count; i++)
                {
                    idx = Convert.ToInt32(dvTemp[i]["controlidx_chr"].ToString().Trim());
                    switch (dvTemp[i]["sampletype_chr"].ToString().ToLower().Trim())
                    {
                        case "blk":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Blk;
                            m_lstLbl[idx].Text = "Blk";
                            break;
                        case "neg":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Neg;
                            m_lstLbl[idx].Text = "NC";
                            break;
                        case "pos":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Pos;
                            m_lstLbl[idx].Text = "PC";
                            break;
                        case "qc":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.QC;
                            m_lstLbl[idx].Text = "QC";
                            break;
                        case "smp":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Smp;
                            m_lstLbl[idx].Text = "Smp" + dvTemp[i]["sampleid_vchr"].ToString().Trim();
                            break;
                    }
                    dtResult = m_objController.m_dtResult.Copy();
                    drTemp = dtResult.DefaultView;
                    m_strCheckItemID = dvTemp[i]["check_item_id_chr"].ToString().Trim();
                    drTemp.RowFilter = "check_item_id_chr='" + m_strCheckItemID + "'";
                    if (drTemp.Count > 0)
                    {

                        strColor = drTemp[0]["check_item_color_vchr"].ToString().Trim();
                        m_strColorArr = strColor.Split(new char[] { ':', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        if (m_strColorArr != null)
                        {
                            if (m_strColorArr.Length == 3)
                            {
                                iR = Convert.ToInt32(m_strColorArr[0]);
                                iG = Convert.ToInt32(m_strColorArr[1]);
                                iB = Convert.ToInt32(m_strColorArr[2]);
                                m_lstTextBos[idx].BackColor = Color.FromArgb(iR, iG, iB);

                            }
                        }

                    }
                    m_lstTextBos[idx].m_strCheckItemName = dvTemp[i]["checkitemname_vchr"].ToString().Trim();
                    m_lstTextBos[idx].m_strSampleID = dvTemp[i]["sampleid_vchr"].ToString().Trim();
                    m_lstTextBos[idx].m_strItmeID = dvTemp[i]["check_item_id_chr"].ToString().Trim();
                    m_lstTextBos[idx].Text = dvTemp[i]["sampleid_vchr"].ToString().Trim();
                }
            }
            m_txtLayout.Text = m_cboLayout.Text;
        }

        private void m_btnSure_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtStartNO.Text) || string.IsNullOrEmpty(m_txtEndNum.Text))
                return;
            int intTemp = Convert.ToInt32(m_txtStartNO.Text);
            int intEndNum = Convert.ToInt32(m_txtEndNum.Text);
            if (intEndNum < intTemp)
            {
                MessageBox.Show(this, "结束号码必须大于开始号码", "MK3酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (m_lstTextBos.Count <= 0)
                return;
            for (int i = 0; i < m_lstTextBos.Count; i++)
            {
                if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "smp" || m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "none")
                {

                    if (i < 1)
                    {
                        return;
                    }
                    if (m_lstTextBos[i - 1].m_enmSelceType.ToString().ToLower() != "smp" && m_lstTextBos[i - 1].m_enmSelceType.ToString().ToLower() != "none")
                    {
                        intTemp = Convert.ToInt32(m_txtStartNO.Text);
                    }

                    if (intTemp > 1000)
                    {
                        m_lstTextBos[i].m_strSampleID = intTemp.ToString();

                    }
                    else
                    {
                        m_lstTextBos[i].m_strSampleID = intTemp.ToString("000");

                    }
                    m_lstTextBos[i].Text = m_lstTextBos[i].m_strSampleID;
                    m_lstLbl[i].ForeColor = Color.Black;
                    m_lstLbl[i].Text = "Smp" + m_lstTextBos[i].m_strSampleID;
                    m_lstTextBos[i].BackColor = m_lstTextBos[i - 1].BackColor;

                    if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "none")
                    {
                        m_lstTextBos[i].m_strItmeID = m_lstTextBos[i - 1].m_strItmeID;
                        m_lstTextBos[i].m_strCheckItemName = m_lstTextBos[i - 1].m_strCheckItemName;

                    }
                    m_lstTextBos[i].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Smp;
                    if (intTemp > intEndNum)
                    {
                        m_lstTextBos[i].Text = "";
                        m_lstTextBos[i].m_strItmeID = null;
                        m_lstTextBos[i].m_strSampleID = null;
                        m_lstTextBos[i].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.None;
                        m_lstLbl[i].Text = "";
                    }
                    intTemp++;
                }
            }
        }



        private void m_txtStartNO_Leave(object sender, EventArgs e)
        {
            int intNO;
            try
            {
                intNO = Convert.ToInt32(m_txtStartNO.Text);
            }
            catch
            {
                MessageBox.Show(this, "只能输入数字", "MK3酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtStartNO.Text = "1";
                m_txtStartNO.Focus();
            }
        }

        private void m_txtEndNum_Leave(object sender, EventArgs e)
        {
            int intNO;
            try
            {
                intNO = Convert.ToInt32(m_txtEndNum.Text);
            }
            catch
            {
                MessageBox.Show(this, "只能输入数字", "MK3酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_txtEndNum.Text = "1";
                m_txtEndNum.Focus();
            }
        }

        private void m_btnDefaultSure_Click(object sender, EventArgs e)
        {
            string strStartNO = m_txtStartNO.Text;
            m_btnClear_Click(null, null);
            if (m_lstTextBos.Count <= 0)
                return;

            DataView drTemp = null;
            if (m_objController.m_dtResult == null)
                return;
            DataTable dtResult = m_objController.m_dtResult.Copy();
            drTemp = dtResult.DefaultView;
            string m_strCheckItemID = m_cboItem.SelectedValue.ToString();
            drTemp.RowFilter = "check_item_id_chr='" + m_strCheckItemID + "'";
            if (drTemp.Count > 0)
            {
                string strColor = null;
                strColor = drTemp[0]["check_item_color_vchr"].ToString().Trim();
                string[] m_strColorArr = strColor.Split(new char[] { ':', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (m_strColorArr != null)
                {
                    if (m_strColorArr.Length == 3)
                    {
                        int iR = Convert.ToInt32(m_strColorArr[0]);
                        int iG = Convert.ToInt32(m_strColorArr[1]);
                        int iB = Convert.ToInt32(m_strColorArr[2]);
                        for (int i = 0; i < m_lstTextBos.Count; i++)
                        {
                            m_lstTextBos[i].BackColor = Color.FromArgb(iR, iG, iB);
                        }
                    }
                }

            }

            m_lstTextBos[0].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Blk;
            m_lstTextBos[0].m_strCheckItemName = m_cboItem.Text;
            m_lstTextBos[0].m_strItmeID = m_cboItem.SelectedValue.ToString();
            m_lstTextBos[0].m_strSampleID = "Blk";
            m_lstTextBos[0].Text = "Blk";
            m_lstLbl[0].Text = m_lstTextBos[0].m_strSampleID;

            m_lstTextBos[1].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Neg;
            m_lstTextBos[1].m_strCheckItemName = m_cboItem.Text;
            m_lstTextBos[1].m_strItmeID = m_cboItem.SelectedValue.ToString();
            m_lstTextBos[1].m_strSampleID = "NC1";
            m_lstTextBos[1].Text = "NC1";
            m_lstLbl[1].Text = m_lstTextBos[1].m_strSampleID;

            m_lstTextBos[2].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Pos;
            m_lstTextBos[2].m_strCheckItemName = m_cboItem.Text;
            m_lstTextBos[2].m_strItmeID = m_cboItem.SelectedValue.ToString();
            m_lstTextBos[2].m_strSampleID = "PC1";
            m_lstTextBos[2].Text = "PC1";
            m_lstLbl[2].Text = m_lstTextBos[2].m_strSampleID;
            if (m_rabDefaultQC.Checked)
            {

                m_lstTextBos[3].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.QC;
                m_lstTextBos[3].m_strCheckItemName = m_cboItem.Text;
                m_lstTextBos[3].m_strItmeID = m_cboItem.SelectedValue.ToString();
                m_lstTextBos[3].m_strSampleID = "QC";
                m_lstTextBos[3].Text = "QC";
                m_lstLbl[3].Text = m_lstTextBos[3].m_strSampleID;
            }
            int intSampleNO = 1;
            for (int i = 4; i < m_lstTextBos.Count; i++)
            {
                m_lstTextBos[i].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Smp;
                m_lstTextBos[i].m_strCheckItemName = m_cboItem.Text;
                m_lstTextBos[i].m_strItmeID = m_cboItem.SelectedValue.ToString();
                if (intSampleNO < 1000)
                {
                    m_lstTextBos[i].m_strSampleID = intSampleNO.ToString("000");
                }
                else
                {
                    m_lstTextBos[i].m_strSampleID = intSampleNO.ToString();
                }
                m_lstTextBos[i].Text = m_lstTextBos[i].m_strSampleID;
                intSampleNO++;
                m_lstLbl[i].Text = "Smp" + m_lstTextBos[i].m_strSampleID;
            }

        }

        #region 动态生成控件
        /// <summary>
        /// 动态生成控件
        /// </summary>
        public void m_mthSetNewControl()
        {
            if (m_objController.m_dtResult == null)
            {
                return;
            }
            DataTable dtCheckItem = m_objController.m_dtResult.Copy();
            DataRow drTemp = null;
            int intLabWidth = 35;
            int intLabHeight = 12;
            int intTxtWidth = 73;
            int intTxtHeight = 21;
            int intLabXStart = 1;
            int intYStart = 1;
            int intRowSpace = 10;
            int intCount = 0;
            int intTxtXStart;
            int iR;
            int iG;
            int iB;
            string strColor = null;
            string[] m_strColorArr = null;
            for (int i = 0; i < dtCheckItem.Rows.Count; i++)
            {
                drTemp = dtCheckItem.Rows[i];
                strColor = drTemp["check_item_color_vchr"].ToString().Trim();
                Label lab = new Label();
                lab.Width = intLabWidth;
                lab.Height = intLabHeight;
                lab.Text = drTemp["check_item_name_vchr"].ToString().Trim();
                TextBox txt = new TextBox();
                txt.Height = intTxtHeight;
                txt.Width = intTxtWidth;
                txt.ReadOnly = true;
                m_strColorArr = strColor.Split(new char[] { ':', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                if (m_strColorArr != null)
                {
                    if (m_strColorArr.Length == 3)
                    {
                        iR = Convert.ToInt32(m_strColorArr[0]);
                        iG = Convert.ToInt32(m_strColorArr[1]);
                        iB = Convert.ToInt32(m_strColorArr[2]);
                        txt.BackColor = Color.FromArgb(iR, iG, iB);

                    }
                }
                int intY = intYStart + (intTxtHeight + intRowSpace) * intCount;
                intTxtXStart = intLabXStart + intLabWidth + 1;
                lab.Location = new Point(intLabXStart, intY);
                txt.Location = new Point(intTxtXStart, intY);
                m_panlist.Controls.Add(lab);
                m_panlist.Controls.Add(txt);
                intCount++;
            }
        }
        #endregion


        private void m_btnSavePalteResult_Click(object sender, EventArgs e)
        {
            //if (string.IsNullOrEmpty(m_txtPlateName.Text))
            //{
            //    return;
            //}
            //if (m_lstTextBos.Count <= 0)
            //{
            //    return;
            //}
            //string m_strPlateName = m_txtPlateName.Text;
            //List<clslisPlateResult> m_lstPlateResultArr = new List<clslisPlateResult>();
            //clslisPlateResult objTemp = null;
            //for (int i = 0; i < m_lstTextBos.Count; i++)
            //{
            //    if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() != "none")
            //    {
            //        objTemp = new clslisPlateResult();
            //        objTemp.m_strCheck_Item_Id = m_lstTextBos[i].m_strItmeID;
            //        objTemp.m_strCheckitemname_vchr = m_lstTextBos[i].m_strCheckItemName;
            //        objTemp.m_strControlidx_chr = i.ToString();
            //        objTemp.m_strSample_Result_2_vchr = m_lstLbl[i].Text;
            //        objTemp.m_strSample_Result_vchr = m_lstTextBos[i].Text;
            //        objTemp.m_strSampleid_vchr = m_lstTextBos[i].m_strSampleID;
            //        objTemp.m_strSampletype_chr = m_lstTextBos[i].m_enmSelceType.ToString();
            //        m_lstPlateResultArr.Add(objTemp);
            //    }
            //}
            //if (m_lstPlateResultArr.Count > 0)
            //{
            //    intPlateResult = 1;
            //   
            //    m_objController.m_mthQueryPlateName();
            //}
            m_mthCalc();
            m_objController.m_mthInsertPlateResult();
        }

        private void m_btnQueryPlateResult_Click(object sender, EventArgs e)
        {
            intPlateResult = 0;
            m_objController.m_mthQueryPlateName();
        }

        private void m_btnDeletePlateResult_Click(object sender, EventArgs e)
        {
            m_objController.m_mthDeletePlateResult();
            m_btnQueryPlateResult_Click(null, null);
        }

        private void m_dgPlateResult_DoubleClick(object sender, EventArgs e)
        {
            m_btnClear_Click(null, null);
            long lngRes = 0;
            DataTable dtResult = null;
            lngRes = m_objController.m_mlngQueryPlateResult(out dtResult);
            if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
            {
                DataRow drTemp = null;
                int idx;
                DataView dvTemp = null;
                DataTable dResult = null;
                if (m_objController.m_dtResult == null)
                    return;
                string m_strCheckItemID = null;
                int iR;
                int iG;
                int iB;
                string strColor = null;
                string[] m_strColorArr = null;
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    drTemp = dtResult.Rows[i];
                    idx = Convert.ToInt32(drTemp["controlidx_chr"].ToString().Trim());
                    m_lstTextBos[idx].m_strCheckItemName = drTemp["checkitemname_vchr"].ToString().Trim();
                    m_lstTextBos[idx].m_strSampleID = drTemp["sampleid_vchr"].ToString().Trim();
                    m_lstTextBos[idx].m_strItmeID = drTemp["check_item_id"].ToString().Trim();
                    m_lstTextBos[idx].Text = drTemp["sample_result_vchr"].ToString().Trim();


                    m_lstTextBos[idx].Tag = drTemp["sample_result_sc_vchr"].ToString().Trim();  // 获取s/co值
                    m_strCutoff = drTemp["sample_result_cutoff_vchr"].ToString().Trim(); // 获取cutoff值
                    m_strContrastNC = drTemp["sample_result_contrastnc_vchr"].ToString().Trim();  //获取阴性对照值
                    m_strContrastPC = drTemp["sample_result_contrastpc_vchr"].ToString().Trim();  //获取阳性对照值
                    m_strPlanChaName = m_dgPlateResult.Rows[m_dgPlateResult.CurrentRow.Index].Cells["m_chProjectName"].Value.ToString(); //获取检验项目名称
                    m_cboItem.SelectedText = drTemp["checkitemname_vchr"].ToString().Trim();

                    m_txtPlateName.Text = m_dgPlateResult.Rows[m_dgPlateResult.CurrentRow.Index].Cells["m_chPlateName"].Value.ToString(); //获取测试版号值

                    switch (drTemp["sampletype_chr"].ToString().ToLower().Trim())
                    {
                        case "blk":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Blk;
                            m_lstLbl[idx].Text = "Blk";
                            break;
                        case "neg":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Neg;
                            m_lstLbl[idx].Text = m_lstTextBos[idx].m_strSampleID;
                            break;
                        case "pos":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Pos;
                            m_lstLbl[idx].Text = "PC";
                            break;
                        case "qc":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.QC;
                            m_lstLbl[idx].Text = drTemp["sample_result_2_vchr"].ToString().Trim();
                            break;
                        case "smp":
                            m_lstTextBos[idx].m_enmSelceType = com.digitalwave.iCare.gui.LIS.Control.ctlLISMK3TextBox.m_enmSampleType.Smp;
                            //m_lstLbl[idx].Text = "Smp" + dvTemp[i]["sampleid_vchr"].ToString().Trim();
                            if (drTemp["sample_result_2_vchr"].ToString().Trim().Contains("+"))
                            {
                                m_lstLbl[idx].Text = drTemp["sampleid_vchr"].ToString().Trim() + "(+)";
                                m_lstLbl[idx].ForeColor = Color.Red;
                            }
                            else
                            {
                                m_lstLbl[idx].Text = drTemp["sampleid_vchr"].ToString().Trim() + "(-)";
                                m_lstLbl[idx].ForeColor = Color.Black;
                            }
                            break;
                    }
                    dResult = m_objController.m_dtResult.Copy();
                    dvTemp = dResult.DefaultView;
                    m_strCheckItemID = drTemp["check_item_id"].ToString().Trim();
                    dvTemp.RowFilter = "check_item_id_chr='" + m_strCheckItemID + "'";
                    if (dvTemp.Count > 0)
                    {

                        strColor = dvTemp[0]["check_item_color_vchr"].ToString().Trim();
                        m_strColorArr = strColor.Split(new char[] { ':', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        if (m_strColorArr != null)
                        {
                            if (m_strColorArr.Length == 3)
                            {
                                iR = Convert.ToInt32(m_strColorArr[0]);
                                iG = Convert.ToInt32(m_strColorArr[1]);
                                iB = Convert.ToInt32(m_strColorArr[2]);
                                m_lstTextBos[idx].BackColor = Color.FromArgb(iR, iG, iB);

                            }
                        }
                    }
                }
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            if (m_lstTextBos.Count <= 0)
                return;
            m_dwPrint.SetRedrawOff();
            m_dwPrint.Refresh();

            long lngRes = 0;
            DataTable dtResult = null;
            lngRes = m_objController.m_mthGetCheckItemCustomRes(out dtResult);

            if (lngRes > 0 && dtResult != null && dtResult.Rows.Count > 0)
            {
                DataRow drTemp = null;
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    drTemp = dtResult.Rows[i];
                    if (drTemp["seq_int"].ToString().Trim() == "1")
                    {
                        m_dwPrint.Modify("t_negativejudge.text='" + drTemp["conditions_vchr"].ToString().Replace("CUTOFF", m_strJudgNcAndPc) + "'");
                    }
                    else
                    {
                        m_dwPrint.Modify("t_positivejudge.text='" + drTemp["conditions_vchr"].ToString().Replace("CUTOFF", m_strJudgNcAndPc) + "'");
                    }
                }
            }

            string strName = LoginInfo.m_strEmpName;
            string strDate = DateTime.Now.ToString();
            string strHospitalName = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalName;

            m_dwPrint.Modify("t_hospital.text='" + strHospitalName + "'");
            m_dwPrint.Modify("t_operationname.text='" + strName + "'");
            m_dwPrint.Modify("t_operationtime.text='" + strDate + "'");
            if (m_txtPlateName.Text.ToString().Length > 17)
            {
                m_dwPrint.Modify("t_testno.text='" + m_txtPlateName.Text.ToString().Substring(0, 17) + "~r" + m_txtPlateName.Text.ToString().Substring(17) + "'");
            }
            else
            {
                m_dwPrint.Modify("t_testno.text='" + m_txtPlateName.Text + "'");
            }
            //m_dwPrint.Modify("t_testproject.text='" + m_strPlanChaName + "'");

            if (m_strPlanChaName.Length > 17)
            {
                m_dwPrint.Modify("t_testproject.text='" + m_strPlanChaName.Substring(0, 17) + "~r" + m_strPlanChaName.Substring(17) + "'");

            }
            else
            {
                m_dwPrint.Modify("t_testproject.text='" + m_strPlanChaName + "'");
            }
            m_dwPrint.Modify("t_instrumentnumber.text='" + m_strDeviceModel + "'");
            m_dwPrint.Modify("t_wavelength.text='450'");

            m_dwPrint.Modify("t_cotoff.text='" + m_strCutoff + "'");
            m_dwPrint.Modify("t_negativecon.text='" + m_strContrastNC + "'");
            m_dwPrint.Modify("t_positivecon.text='" + m_strContrastPC + "'");

            string strTemp = null;
            string strtxtName = "t_smp";
            string strResult = null;
            int j;
            for (int i = 0; i < m_lstTextBos.Count; i++)
            {
                if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() != "none")
                {
                    j = i + 1;
                    strTemp = j.ToString();
                    strTemp = strTemp.PadLeft(2, '0');
                    strtxtName = strtxtName + strTemp + ".text";

                    if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "blk")
                    {
                        m_dwPrint.Modify("t_blankcon.text='" + m_lstTextBos[i].Text + "'");
                    }

                    if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "qc")
                    {
                        strResult = "QC" + "\r\n" + m_lstTextBos[i].Text + "\r\n" + m_lstTextBos[i].Tag.ToString() + "\r\n" + m_lstLbl[i].Text;
                    }
                    else
                    {
                        if (m_lstLbl[i].Text.ToString().Trim().Contains("(+)") || m_lstLbl[i].Text.ToString().Trim().Contains("(-)"))
                        {
                            strResult = m_lstLbl[i].Text.ToString().Trim().Substring(0, m_lstLbl[i].Text.ToString().Trim().Length - 3) +
                                "\r\n" + m_lstTextBos[i].Text.ToString() + "\r\n" +
                                 m_lstTextBos[i].Tag.ToString() + "\r\n" +
                                m_lstLbl[i].Text.ToString().Trim().Substring(m_lstLbl[i].Text.ToString().Trim().Length - 3);
                        }
                        else
                        {
                            strResult = m_lstLbl[i].Text + "\r\n" + m_lstTextBos[i].Text + "\r\n" + m_lstTextBos[i].Tag.ToString();
                        }
                    }
                    m_dwPrint.Modify("" + strtxtName + "='" + strResult + "'");
                    strtxtName = "t_smp";
                }
            }
            try
            {
                m_dwPrint.SetRedrawOff();
                m_dwPrint.Refresh();
                m_dwPrint.Print();
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }

        #region 重新计算结果
        /// <summary>
        /// 重新计算结果
        /// </summary>
        /// <param name="idxStart"></param>
        /// <param name="idxEnd"></param>
        private void m_mthCalc(int idxStart, int idxEnd)
        {
            List<clslisPlateResult> m_lstNC = new List<clslisPlateResult>();
            List<clslisPlateResult> m_lstPC = new List<clslisPlateResult>();
            List<clslisPlateResult> m_lstCutoff = new List<clslisPlateResult>();
            clslisPlateResult objTemp = null;
            string strCheckItemID = null;
            string strResult = null;
            string strFormula = null;
            double dblNC;
            double dblPC;
            DataView dtCheckItem = null;
            string strNCFormula;
            string strPCFormula;
            string m_strNC = null;
            string m_strPC = null;
            double dblResult = 0;
            for (int i = idxEnd; i >= 0; i--)
            {
                dtCheckItem = m_objController.m_dtResult.DefaultView;
                if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "neg" || m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "pos")
                {
                    if (strCheckItemID == m_lstTextBos[i].m_strItmeID)
                    {
                        if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "neg")
                        {
                            objTemp = new clslisPlateResult();
                            objTemp.m_strCheck_Item_Id = m_lstTextBos[i].m_strItmeID;
                            //m_mthContrast(m_lstTextBos[i].m_strItmeID, m_lstTextBos[i].Text, "neg_maxvalue_vchr", "neg_minvalue_vchr", out strResult);
                            //if (string.IsNullOrEmpty(strResult))
                            //{
                            //    continue;
                            //}
                            objTemp.m_strSample_Result_vchr = m_lstTextBos[i].Text;
                            objTemp.m_strSampleid_vchr = m_lstTextBos[i].m_strSampleID;
                            m_lstNC.Add(objTemp);
                            strResult = null;
                        }
                        if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "pos")
                        {
                            objTemp = new clslisPlateResult();
                            objTemp.m_strCheck_Item_Id = m_lstTextBos[i].m_strItmeID;
                            //m_mthContrast(m_lstTextBos[i].m_strItmeID, m_lstTextBos[i].Text, "pos_maxvalue_vchr", "pos_minvalue_vchr", out strResult);
                            //if (string.IsNullOrEmpty(strResult))
                            //{
                            //    continue;
                            //}
                            objTemp.m_strSample_Result_vchr = m_lstTextBos[i].Text;
                            objTemp.m_strSampleid_vchr = m_lstTextBos[i].m_strSampleID;
                            m_lstPC.Add(objTemp);
                            strResult = null;
                        }
                    }
                    else
                    {
                        if (m_lstNC.Count <= 0 || m_lstPC.Count <= 0)
                        {
                            continue;
                        }

                        strFormula = m_cboCutoff.Text;


                        dtCheckItem.RowFilter = "check_item_id_chr='" + m_lstNC[0].m_strCheck_Item_Id + "'";
                        strNCFormula = dtCheckItem[0]["more_neg_formula_vchr"].ToString().Trim();
                        strPCFormula = dtCheckItem[0]["more_pos_formula_vchr"].ToString().Trim();
                        if (string.IsNullOrEmpty(strFormula) || string.IsNullOrEmpty(strNCFormula) || string.IsNullOrEmpty(strPCFormula))
                            return;
                        m_objController.m_mthCalcContrast(strNCFormula, m_lstNC, out dblNC);
                        m_mthContrast(m_lstNC[0].m_strCheck_Item_Id, dblNC.ToString(), "neg_maxvalue_vchr", "neg_minvalue_vchr", out m_strNC);

                        m_strContrastNC = m_strNC;  //计算阴性对照值

                        m_objController.m_mthCalcContrast(strPCFormula, m_lstPC, out dblPC);
                        m_mthContrast(m_lstPC[0].m_strCheck_Item_Id, dblPC.ToString(), "pos_maxvalue_vchr", "pos_minvalue_vchr", out m_strPC);

                        m_strContrastPC = m_strPC;  //计算阳性对照值

                        if (string.IsNullOrEmpty(m_strNC) || string.IsNullOrEmpty(m_strPC))
                        {
                            return;
                        }
                        m_objController.m_mthCalculator(strFormula, m_strNC, m_strPC, out dblResult);
                        objTemp = new clslisPlateResult();
                        objTemp.m_strCheck_Item_Id = m_lstTextBos[i].m_strItmeID;
                        objTemp.m_strSample_Result_2_vchr = dblResult.ToString();

                        m_strCutoff = dblResult.ToString();  //计算s/co值

                        m_lstCutoff.Add(objTemp);
                        m_lstNC.Clear();
                        m_lstPC.Clear();
                    }
                }
                if (i == 0)
                {
                    if (m_lstNC.Count <= 0 || m_lstPC.Count <= 0)
                    {
                        continue;
                    }

                    strFormula = m_cboCutoff.Text;

                    dtCheckItem.RowFilter = "check_item_id_chr='" + m_lstNC[0].m_strCheck_Item_Id + "'";
                    strNCFormula = dtCheckItem[0]["more_neg_formula_vchr"].ToString().Trim();
                    strPCFormula = dtCheckItem[0]["more_pos_formula_vchr"].ToString().Trim();
                    if (string.IsNullOrEmpty(strFormula) || string.IsNullOrEmpty(strNCFormula) || string.IsNullOrEmpty(strPCFormula))
                        return;
                    m_objController.m_mthCalcContrast(strNCFormula, m_lstNC, out dblNC);
                    if (Convert.ToInt32(dblNC) != 0)
                    {
                        m_mthContrast(m_lstNC[0].m_strCheck_Item_Id, dblNC.ToString(), "neg_maxvalue_vchr", "neg_minvalue_vchr", out m_strNC);
                    }
                    m_strContrastNC = m_strNC;  //计算阴性对照值

                    m_objController.m_mthCalcContrast(strPCFormula, m_lstPC, out dblPC);
                    if (Convert.ToInt32(dblPC) != 0)
                    {
                        m_mthContrast(m_lstPC[0].m_strCheck_Item_Id, dblPC.ToString(), "pos_maxvalue_vchr", "pos_minvalue_vchr", out m_strPC);
                    }
                    m_strContrastPC = m_strPC;  //计算阳性对照值

                    if (string.IsNullOrEmpty(m_strNC) || string.IsNullOrEmpty(m_strPC))
                    {
                        return;
                    }
                    m_objController.m_mthCalculator(strFormula, m_strNC, m_strPC, out dblResult);
                    objTemp = new clslisPlateResult();
                    objTemp.m_strCheck_Item_Id = m_lstTextBos[i].m_strItmeID;
                    objTemp.m_strSample_Result_2_vchr = dblResult.ToString();

                    m_strCutoff = dblResult.ToString();  //计算s/co值

                    m_lstCutoff.Add(objTemp);
                    m_lstNC.Clear();
                    m_lstPC.Clear();
                }
                if (!string.IsNullOrEmpty(m_lstTextBos[i].m_strItmeID))
                {
                    strCheckItemID = m_lstTextBos[i].m_strItmeID;
                }
            }
            if (m_lstCutoff.Count <= 0)
            {
                return;
            }
            string strResult2 = null;
            for (int i = idx; i <= idxEnd; i++)
            {

                if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "smp")
                {
                    for (int j = 0; j < m_lstCutoff.Count; j++)
                    {
                        if (m_lstTextBos[i].m_strItmeID == m_lstCutoff[j].m_strCheck_Item_Id)
                        {
                            m_objController.m_blnResultJudge(m_lstTextBos[i].m_strItmeID, m_lstTextBos[i].Text, m_lstCutoff[j].m_strSample_Result_2_vchr, out strResult2);
                            if (strResult2 == "阴性(-)")
                            {
                                m_lstLbl[i].Text = m_lstTextBos[i].m_strSampleID + "(-)";
                                m_lstLbl[i].ForeColor = Color.Black;
                            }
                            else
                            {
                                m_lstLbl[i].Text = m_lstTextBos[i].m_strSampleID + "(+)";
                                m_lstLbl[i].ForeColor = Color.Red;
                            }
                        }
                    }
                }

                if (dblResult != 0)
                {
                    try
                    {
                        double dblSExcepValue = Convert.ToDouble(m_lstTextBos[i].Text.ToString().Trim());

                        double dblGetValue = dblSExcepValue / dblResult;

                        m_lstTextBos[i].Tag = dblGetValue.ToString("#0.000");

                    }
                    catch
                    {
                        m_lstTextBos[i].Tag = " ";
                    }
                }
                else
                {
                    m_lstTextBos[i].Tag = " ";
                }

            }
        }
        #endregion

        #region  计算结果
        /// <summary>
        ///  计算结果
        /// </summary>
        /// <param name="idxStart"></param>
        /// <param name="idxEnd"></param>
        public void m_mthCalc()
        {
            List<clslisPlateResult> m_lstNC = new List<clslisPlateResult>();
            List<clslisPlateResult> m_lstPC = new List<clslisPlateResult>();
            List<clslisPlateResult> m_lstCutoff = new List<clslisPlateResult>();
            clslisPlateResult objTemp = null;
            string strCheckItemID = null;
            string strResult = null;
            string strFormula = null;
            double dblNC;
            double dblPC;
            DataView dtCheckItem = null;
            string strNCFormula;
            string strPCFormula;
            string m_strNC = null;
            string m_strPC = null;
            double dblResult = 0;


            DataTable dtItemTabl = m_objController.m_dtResult.Copy();
            for (int i = m_lstTextBos.Count - 1; i >= 0; i--)
            {
                dtCheckItem = dtItemTabl.DefaultView;
                if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "neg")
                {
                    objTemp = new clslisPlateResult();
                    objTemp.m_strCheck_Item_Id = m_lstTextBos[i].m_strItmeID;

                    objTemp.m_strSample_Result_vchr = m_lstTextBos[i].Text;
                    objTemp.m_strSampleid_vchr = m_lstTextBos[i].m_strSampleID;
                    m_lstNC.Add(objTemp);
                    strResult = null;
                }
                if (m_lstTextBos[i].m_enmSelceType.ToString().ToLower() == "pos")
                {
                    objTemp = new clslisPlateResult();
                    objTemp.m_strCheck_Item_Id = m_lstTextBos[i].m_strItmeID;

                    objTemp.m_strSample_Result_vchr = m_lstTextBos[i].Text;
                    objTemp.m_strSampleid_vchr = m_lstTextBos[i].m_strSampleID;
                    m_lstPC.Add(objTemp);
                    strResult = null;
                }

                if (i == 0)
                {
                    if (m_lstNC.Count <= 0 || m_lstPC.Count <= 0)
                    {
                        continue;
                    }

                    strFormula = m_cboCutoff.Text;

                    dtCheckItem.RowFilter = "check_item_id_chr='" + m_lstNC[0].m_strCheck_Item_Id + "'";
                    strNCFormula = dtCheckItem[0]["more_neg_formula_vchr"].ToString().Trim();
                    strPCFormula = dtCheckItem[0]["more_pos_formula_vchr"].ToString().Trim();
                    strFormula = dtCheckItem[0]["check_item_formula_vchr"].ToString().Trim();
                    if (string.IsNullOrEmpty(strNCFormula) || string.IsNullOrEmpty(strPCFormula))
                        return;
                    m_objController.m_mthCalcContrast(strNCFormula, m_lstNC, out dblNC);
                    if (dblNC.ToString().Length != 0)
                    {
                        m_mthContrast(m_lstNC[0].m_strCheck_Item_Id, dblNC.ToString(), "neg_maxvalue_vchr", "neg_minvalue_vchr", out m_strNC);
                    }
                    m_strContrastNC = m_strNC;  //计算阴性对照值

                    m_objController.m_mthCalcContrast(strPCFormula, m_lstPC, out dblPC);
                    if (dblPC.ToString().Length != 0)
                    {
                        m_mthContrast(m_lstPC[0].m_strCheck_Item_Id, dblPC.ToString(), "pos_maxvalue_vchr", "pos_minvalue_vchr", out m_strPC);
                    }
                    m_strContrastPC = m_strPC;  //计算阳性对照值

                    if (string.IsNullOrEmpty(m_strNC) || string.IsNullOrEmpty(m_strPC))
                    {
                        return;
                    }
                    m_objController.m_mthCalculator(strFormula, m_strNC, m_strPC, out dblResult);
                    objTemp = new clslisPlateResult();
                    objTemp.m_strCheck_Item_Id = m_lstTextBos[i].m_strItmeID;
                    objTemp.m_strSample_Result_2_vchr = dblResult.ToString();


                    m_strCutoff = dblResult.ToString();  ////计算s/co值


                    m_lstCutoff.Add(objTemp);
                    m_lstNC.Clear();
                    m_lstPC.Clear();
                }
            }

            for (int i = m_lstTextBos.Count - 1; i >= 0; i--)
            {
                if (dblResult != 0)
                {
                    try
                    {
                        double dblSExcepValue = Convert.ToDouble(m_lstTextBos[i].Text.ToString().Trim());

                        double dblGetValue = dblSExcepValue / dblResult;

                        m_lstTextBos[i].Tag = dblGetValue.ToString("#0.000");

                    }
                    catch
                    {
                        m_lstTextBos[i].Tag = " ";
                    }
                }
                else
                {
                    m_lstTextBos[i].Tag = " ";
                }
            }
        }
        #endregion

        #region 获取阴,阳对照值
        /// <summary>
        /// 获取阴,阳对照值
        /// </summary>
        /// <param name="p_strCheckItemID"></param>
        /// <param name="p_strTemp"></param>
        /// <param name="p_strColumnMaxValue"></param>
        /// <param name="p_strColumnMinValue"></param>
        /// <param name="p_strResult"></param>
        private void m_mthContrast(string p_strCheckItemID, string p_strTemp, string p_strColumnMaxValue, string p_strColumnMinValue, out string p_strResult)
        {
            DataTable dtItemTabl = m_objController.m_dtResult.Copy();
            p_strResult = null;
            if (m_objController.m_dtResult == null)
                return;
            DataView dtCheckItem = dtItemTabl.DefaultView;
            dtCheckItem.RowFilter = "check_item_id_chr='" + p_strCheckItemID + "'";
            double dblTemp = Convert.ToDouble(p_strTemp);
            double dblMaxValue;
            double dblMinValue;
            if (!string.IsNullOrEmpty(dtCheckItem[0][p_strColumnMaxValue].ToString()))
            {
                dblMaxValue = Convert.ToDouble(dtCheckItem[0][p_strColumnMaxValue].ToString().Trim());
                if (dblTemp > dblMaxValue)
                {
                    dblTemp = dblMaxValue;
                }
            }
            if (!string.IsNullOrEmpty(dtCheckItem[0][p_strColumnMinValue].ToString()))
            {
                dblMinValue = Convert.ToDouble(dtCheckItem[0][p_strColumnMinValue].ToString().Trim());
                if (dblTemp < dblMinValue)
                {
                    dblTemp = dblMinValue;
                }
            }
            p_strResult = dblTemp.ToString();
        }
        #endregion

        private void m_btnInputStock_Click(object sender, EventArgs e)
        {
            m_objController.m_mthInputStock();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_objController.m_mthDataTreatment();
        }
    }
}