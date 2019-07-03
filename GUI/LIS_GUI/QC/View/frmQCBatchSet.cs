using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmQCBatchSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private clsLisQCBatchVO objQCBatch;
        /// <summary>
        /// 获取或设置质控批类
        /// </summary>
        public clsLisQCBatchVO QCBatchVO
        {
            get { return objQCBatch; }
            set { objQCBatch = value; }
        }
        /// <summary>
        /// 质控批类Arr
        /// </summary>
        private clsLisQCBatchVO[] objQCBatchArr;
        /// <summary>
        /// 获取质控批类，
        /// 在一些模块中支持同时加多个质控批类（新质控管理）
        /// </summary>
        public clsLisQCBatchVO[] QCBatchVOArr
        {
            get { return objQCBatchArr; }
        }

        private bool blnCanReturnArr = false;
        /// <summary>
        /// 是否允许返回多个质控批类
        /// </summary>
        public bool M_blnCanReturnArr
        {
            get { return blnCanReturnArr; }
            set { blnCanReturnArr = value; }
        }

        /// <summary>
        /// 质控项目选择
        /// </summary>
        frmCheckItemSelector selector;   

        public frmQCBatchSet()
        {
            InitializeComponent();
        }

        #region == 一般设置 ==

        #region 快捷键设置

        private void m_mthShortCutKey(Keys p_eumKeyCode)
        {
            //if (p_eumKeyCode == Keys.Enter)
            //{
            //    if (this.m_cmdConfirm.Enabled == true
            //        && this.m_cmdConfirm.Visible == true)
            //    {
            //        this.m_cmdConfirm_Click(this.m_cmdConfirm, null);
            //    }
            //}
            //else if (p_eumKeyCode == Keys.F8)
            //{
            //    if (this.btnPrint.Enabled == true
            //        && this.btnPrint.Visible == true)
            //    {
            //        this.btnPrint_Click(this.btnPrint, null);
            //    }
            //}
            //else if (p_eumKeyCode == Keys.F3 && this.m_btnPreference.Enabled && m_btnPreference.Visible)//保存
            //{
            //    this.m_btnPreference_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F5 && this.m_btnPrintReport.Enabled && m_btnPrintReport.Visible)//读卡
            //{
            //    this.m_btnPrintReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F6 && this.m_btnPreviewReport.Enabled && m_btnPreviewReport.Visible)		//退出
            //{
            //    this.m_btnPreviewReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F9 && this.m_btnConfirmReport.Enabled && m_btnConfirmReport.Visible)		//清除
            //{
            //    this.m_btnConfirmReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F10 && this.m_btnSaveReport.Enabled && m_btnSaveReport.Visible)//手输和读卡机切换
            //{
            //    this.m_btnSaveReport_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F12 && this.m_btnDelete.Enabled && m_btnDelete.Visible)//手输和读卡机切换
            //{
            //    this.m_btnDelete_Click(null, null);
            //}
            //else if (p_eumKeyCode == Keys.F8 && this.m_btnNewApp.Enabled && m_btnNewApp.Visible)//手输和读卡机切换
            //{
            //    this.m_btnNewApp_Click(null, null);
            //}
            //			else if(p_eumKeyCode==Keys.F12 && this.m_btnInputSwitch.Enabled && m_btnInputSwitch.Visible)//手输和读卡机切换
            //			{
            //				this.m_btnInputSwitch_Click(null,null);
            //			}
        }

        #endregion

        private void frmQCBatch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            m_mthShortCutKey(e.KeyCode);
            base.m_mthSetKeyTab(e);
        }

        #endregion

        private void m_mthConstructVO()
        {
            clsLisQCBatchVO objBatch = objQCBatch;

            objBatch.m_intWorkGroupSeq = m_cboWorkGroup.Value;
            objBatch.m_strWorkGroupName = m_cboWorkGroup.Text;
            if (ctlLISDeviceComboBox1.SelectedValue != null && this.m_chkIsMachine.Checked)
            {
                objBatch.m_strDeviceId = ctlLISDeviceComboBox1.SelectedValue.ToString();
                objBatch.m_strDeviceName = ctlLISDeviceComboBox1.Text;
            }
            else { objQCBatch.m_strDeviceId = string.Empty; }

            objBatch.m_strCheckItemId = m_txtQCCheckItem.Tag as string;
            objBatch.m_strCheckItemName = m_txtQCCheckItem.Text;
            objBatch.m_strSampleLotNo = m_txtQCSampleLotNO.Text.Trim();
            objBatch.m_strSampleSource = m_cboQCSampleSource.Text;
            objBatch.m_strSampleVendor = m_cboQCSqmpleVendor.Text;
            objBatch.m_strReagent = m_cboReagentVendor.Text.Trim();
            objBatch.m_strReagentBatch = m_txtReagentLotNO.Text.Trim();
            objBatch.m_strCheckmethodName = m_cboCheckMethod.Text;

            try { objBatch.m_dblWaveLength = Convert.ToDouble(m_txtWaveLength.Text.Trim()); }
            catch { objBatch.m_dblWaveLength = DBAssist.NullDouble; }


            objBatch.m_strResultUnit = m_txtResultUnit.Text.Trim();
            objBatch.m_dtBegin = DateTime.Parse(m_dtpBeginDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            objBatch.m_dtEnd = DateTime.Parse(m_dtpEndDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
            objBatch.m_strOperatorId = m_txtAppDoct.m_StrEmployeeID;
            objBatch.m_strSummary = m_txtSummary.Text;
            //质控规则
            objBatch.m_strQCRules = m_strConstructXmlRules();
            objQCBatch.m_enmStatus = enmQCStatus.Natrural;
        }

        private void m_mthResetAll()
        {
            m_txtQCBatchSeq.Clear();
            try { m_cboWorkGroup.SelectedIndex = 0; }
            catch { }
            try
            {
                ctlLISDeviceComboBox1.SelectedIndex = 0;
                ctlLISDeviceComboBox1.Enabled = false;
                m_chkIsMachine.Checked = false;
            }
            catch { }
            m_txtQCCheckItem.Clear();
            m_txtQCCheckItem.Tag = null;
            m_txtQCSampleLotNO.Clear();
            try { m_cboQCSampleSource.SelectedIndex = 0; }
            catch { }
            try { m_cboQCSqmpleVendor.SelectedIndex = 0; }
            catch { }
            m_txtReagentLotNO.Clear();
            try { m_cboReagentVendor.SelectedIndex = 0; }
            catch { }
            try { m_cboCheckMethod.SelectedIndex = 0; }
            catch { }
            m_txtWaveLength.Clear();
            m_txtResultUnit.Clear();
            m_dtpBeginDate.Value = DateTime.Now;
            m_dtpEndDate.Value = DateTime.Now;
            m_txtAppDoct.m_StrEmployeeID = this.LoginInfo.m_strEmpID;
            m_txtSummary.Clear();
            m_dtgQCRules.DataSource = m_dtbGetRulesFromBase();

        }
        private void m_mthDisplayVO()
        {
            clsLisQCBatchVO objBatch = this.objQCBatch;

            m_txtQCBatchSeq.Text = DBAssist.ToString(objBatch.m_intSeq);
            m_cboWorkGroup.Value = objBatch.m_intWorkGroupSeq;
            if (objQCBatch.m_strDeviceId != string.Empty)
            {
                try { ctlLISDeviceComboBox1.SelectedValue = objBatch.m_strDeviceId; }
                catch { }
                this.m_chkIsMachine.Checked = true;
            }
            else
            {
                this.m_chkIsMachine.Checked = false;
            }
            m_txtQCCheckItem.Tag = objBatch.m_strCheckItemId;
            m_txtQCCheckItem.Text = objBatch.m_strCheckItemName;
            m_txtQCSampleLotNO.Text=objBatch.m_strSampleLotNo;
            m_cboQCSampleSource.Text=objBatch.m_strSampleSource;
            m_cboQCSqmpleVendor.Text=objBatch.m_strSampleVendor;
            m_txtReagentLotNO.Text=objBatch.m_strReagentBatch;
            m_cboReagentVendor.Text = objBatch.m_strReagent;
            m_cboCheckMethod.Text=objBatch.m_strCheckmethodName;
            m_txtWaveLength.Text=DBAssist.ToString(objBatch.m_dblWaveLength);
            m_txtResultUnit.Text=objBatch.m_strResultUnit;
            m_dtpBeginDate.Value=objBatch.m_dtBegin;
            m_dtpEndDate.Value=objBatch.m_dtEnd;            
            m_txtAppDoct.m_StrEmployeeID = objBatch.m_strOperatorId;            
            m_txtSummary.Text=objBatch.m_strSummary;

            //质控规则
            //...
            m_dtgQCRules.DataSource = m_dtbGetRulesFromVO();
        
        }

        private DataTable m_dtbGetRulesFromBase()
        {
            clsLisQCRuleVO[] rules = m_arrGetRulesFromBase();

            DataTable dtbRules=new DataTable();
            dtbRules.Columns.Add("ruleName",typeof(System.String));
            dtbRules.Columns.Add("ruleChoice", typeof(System.Boolean));
            dtbRules.Columns.Add("ruleWarning", typeof(System.Boolean));

            foreach (clsLisQCRuleVO vo in rules)
            {
                dtbRules.Rows.Add(vo.m_strName, vo.m_enmDefaultflag == enmQCRuleDefault.YEA ? true : false,
                                  vo.m_enmWarnType == enmQCRuleWarnLevel.Warning ? true : false);
            }
            return dtbRules;
        }

        /// <summary>
        /// 从规则基本表取规则列表
        /// </summary>
        /// <returns></returns>
        private static clsLisQCRuleVO[] m_arrGetRulesFromBase()
        {
            clsLisQCRuleVO[] rules = null;
            clsTmdQCRulesSmp.s_object.m_lngFind(out rules);
            return rules;
        }

        private DataTable m_dtbGetRulesFromVO()
        {
            clsLisQCBatchVO objBatch = this.objQCBatch;

            List<QualityControlRule> rules = m_arrGetRuelsFromVO();

            DataTable dtbRules = new DataTable();
            dtbRules.Columns.Add("ruleName", typeof(System.String));
            dtbRules.Columns.Add("ruleChoice", typeof(System.Boolean));
            dtbRules.Columns.Add("ruleWarning", typeof(System.Boolean));
            
            Hashtable hasRules=new Hashtable();

            if (rules != null)
            {
                foreach (QualityControlRule vo in rules)
                {
                    dtbRules.Rows.Add(vo.Name, true, vo.IsWarning);
                    hasRules.Add(vo.Name, "");
                }
            }
          

            foreach (clsLisQCRuleVO vo in m_arrGetRulesFromBase())
            {
                if(!hasRules.Contains(vo.m_strName))
                {
                    dtbRules.Rows.Add(vo.m_strName, false, vo.m_enmWarnType==enmQCRuleWarnLevel.Warning?true:false);
                }
            }
            
            return dtbRules;
        }
        
        private List<QualityControlRule> m_arrGetRuelsFromVO()
        {
            clsLisQCBatchVO objBatch = this.objQCBatch;
            QcParserXmlRules parser=new QcParserXmlRules(objBatch.m_strQCRules);
            return parser.RuleList;
        }

        private string m_strConstructXmlRules()
        {
            Hashtable hasChoice=new Hashtable();
            clsLisQCRuleVO[] rules = m_arrGetRulesFromBase();
            List<QualityControlRule> qcRules = new List<QualityControlRule>();
            for(int i=0;i<m_dtgQCRules.Rows.Count;i++)
            {
                if((bool)m_dtgQCRules.Rows[i].Cells[1].Value)
                {
                    hasChoice.Add(m_dtgQCRules.Rows[i].Cells[0].Value, (bool)m_dtgQCRules.Rows[i].Cells[2].Value);
                }
                
            }

            foreach (clsLisQCRuleVO vo in rules)
            {
                if(hasChoice.Contains(vo.m_strName))
                {
                    QualityControlRule rule = null;
                    QcParserXmlRules parser=new QcParserXmlRules(vo.m_strFormula);
                    if(parser.Rule!=null)
                    {
                        rule = parser.Rule;
                        rule.IsWarning = (bool)hasChoice[vo.m_strName];
                        rule.Name = vo.m_strName;
                        qcRules.Add(rule);
                    }
                }
            }

            return QcParserXmlRules.ParserRuleArrToXmlString(qcRules);
        }

        #region == 事件实现 ==
        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        // 选择质控项目
        private void button1_Click(object sender, EventArgs e)
        {
            selector = new frmCheckItemSelector();
            if (selector.ShowDialog() == DialogResult.OK)
            {
                this.m_txtQCCheckItem.Tag = selector.SelectedCheckItem.strID;
                this.m_txtQCCheckItem.Text = selector.SelectedCheckItem.strName;
            }
        }

        private bool m_blnCheckNum()
        {
            if (this.m_txtWaveLength.Text.Trim() != string.Empty)
            {
                double b;
                if (!double.TryParse(this.m_txtWaveLength.Text.Trim(),out b))
                {
                    MessageBox.Show("请输入数字!", "iCare");
                    this.m_txtWaveLength.Focus();
                    this.m_txtWaveLength.SelectAll();
                    return false;
                }
            }
            
            return true;
        }
        private void m_cmdConfirm_Click(object sender, EventArgs e)
        {
            long lngRes = 0;
            if (!this.m_blnCheckNum())
            {
                return;
            }
            this.m_mthConstructVO();

            if (string.IsNullOrEmpty(objQCBatch.m_strSampleLotNo))
            {
                MessageBox.Show("请输入质控批号！", "iCare");
                return;
            }

            int iSaveType = 1;

            if (this.objQCBatch.m_strCheckItemId == null ||
                this.objQCBatch.m_strCheckItemId == "")
            {
                if (string.IsNullOrEmpty(objQCBatch.m_strDeviceId))
                {
                    MessageBox.Show("请选择要做质控的仪器或项目", "iCare");
                    return;
                }
                if (M_blnCanReturnArr)
                {
                    clsLISCheckItemNode[] objArr = null;
                    clsTmdQCLisSmp.s_object.m_lngGetDeviceQCCheckItemByID(objQCBatch.m_strDeviceId, out objArr);
                    if (objArr == null || objArr.Length <= 0)
                    {
                        MessageBox.Show("请选设置该仪器的质控项目！", "iCare");
                        return;
                    }

                    objQCBatchArr = new clsLisQCBatchVO[objArr.Length];
                    clsLisQCBatchVO objTemp = null;
                    for (int index = 0; index < objArr.Length; index++)
                    {
                        objTemp = new clsLisQCBatchVO();
                        objQCBatch.m_mthCopyTo(objTemp);
                        objTemp.m_strCheckItemId = objArr[index].strID;
                        objTemp.m_strCheckItemName = objArr[index].strName;

                        objQCBatchArr[index] = objTemp;
                    }

                    iSaveType = 2;
                }
                else
                {
                    MessageBox.Show("请选择要做质控的项目", "iCare");
                    return;
                }
            }
            if (iSaveType == 2)
            {
                lngRes = clsTmdQCBatchSmp.s_object.m_lngInsertArr(ref objQCBatchArr);
            }
            else
            {
                if (m_txtQCBatchSeq.Text == string.Empty)
                {
                    lngRes = clsTmdQCBatchSmp.s_object.m_lngInsert(this.objQCBatch);
                }
                else
                {
                    lngRes = clsTmdQCBatchSmp.s_object.m_lngUpdate(this.objQCBatch);
                }
            }

            if (lngRes <= 0)
            {
                clsCommonDialog.m_mthShowDBError();
            }
            else
            {
                if (iSaveType != 2)
                {
                    objQCBatchArr = new clsLisQCBatchVO[] { objQCBatch };
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            //if (this.objQCBatch.m_strCheckItemId == null ||
            //    this.objQCBatch.m_strCheckItemId == "")
            //{
            //    MessageBox.Show("请选择要做质控的项目", "iCare");
            //    return;
            //}

            //if (m_txtQCBatchSeq.Text == string.Empty)
            //{
            //    lngRes = clsTmdQCBatchSmp.s_object.m_lngInsert(this.objQCBatch);
            //}
            //else
            //{
            //    lngRes = clsTmdQCBatchSmp.s_object.m_lngUpdate(this.objQCBatch);
            //}
            //if (lngRes <= 0)
            //{
            //    clsCommonDialog.m_mthShowDBError();
            //}
            //else
            //{
            //    this.DialogResult = DialogResult.OK;
            //    this.Close();
            //}
        }

        private void frmQCBatchSet_Load(object sender, EventArgs e)
        {
            if (this.objQCBatch == null)
            {
                this.objQCBatch = new clsLisQCBatchVO();
                this.m_mthResetAll();
            }
            else
            {
                m_mthDisplayVO();
            }
        }

        #endregion

        private void m_chkIsMachine_CheckedChanged(object sender, EventArgs e)
        {
            this.ctlLISDeviceComboBox1.Enabled = this.m_chkIsMachine.Checked;
        }

    }
}