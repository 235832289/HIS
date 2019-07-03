using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using ExpressionEvaluation;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmSTMain : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {

        #region 构造函数

        public frmSTMain()
        {
            string message = string.Empty;
            if (!clsST360Config.CurrentConfig.Load(out message))
            {
                MessageBox.Show(message);
                return;
            }     

            InitializeComponent();
        }
        #endregion

        #region 私有变量

        //普通样本序号
        private int m_maxCommon = 0;
        //标准品样本序号
        private int m_maxStandard = 0;
        //质控样本序号
        private int m_maxQuality = 0;

        private clsSTCheckProject m_selectProject;
        private clsSTCheckSample m_selectSample;
        private clsBoardTemplate m_selectTemplate;

        private clsST360Manager manager = new clsST360Manager();
        private enmSTSampleStyle m_sampleStyle = enmSTSampleStyle.NONE;

        private List<clsSTBoardItem> m_lstBoard = new List<clsSTBoardItem>();
        private List<ctlSTTextBox> m_lstSTTextBoxs = new List<ctlSTTextBox>();
        private List<clsDeviceReslutVO> m_lstCheckResults = new List<clsDeviceReslutVO>();
       
        #endregion

        #region 事件实现

        private void frmST360_Load(object sender, EventArgs e)
        {

            manager.DataChanged += new EventHandler<DataChangedEventArgs>(manager_DataChanged);

            foreach (clsSTBoardItem boardItem in manager.Data)
            {
                ctlSTTextBox stTextBox = new ctlSTTextBox(boardItem);
                stTextBox.Click += new EventHandler(BoardItem_Click);
                stTextBox.TextChanged += new EventHandler(stTextBox_TextChanged);
                m_lstSTTextBoxs.Add(stTextBox);
                m_flpContent.Controls.Add(stTextBox);
            }

            this.m_sampleStyle = enmSTSampleStyle.Common;
            this.m_txtBoardNO.Text = DateTime.Now.ToString("yyMMdd") + "01";
            m_cmdAnalysis.Enabled = false;
            m_cmdSubmitData.Enabled = false;
        }

        /// <summary>
        /// 数据改变事件实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void manager_DataChanged(object sender, DataChangedEventArgs e)
        {
            if (e.ShowStatus!=enmSTTextBoxShowStatus.None)
            {
                DisplayCheckResult(e.ShowStatus);
            }
        }

        private void stTextBox_TextChanged(object sender, EventArgs e)
        {
            ctlSTTextBox boardTextBox = sender as ctlSTTextBox;
            if (boardTextBox == null) return;

            if (boardTextBox.Text != string.Empty && boardTextBox.ShowStatus == enmSTTextBoxShowStatus.BoardStyle && this.m_sampleStyle == enmSTSampleStyle.Common)
            {
                boardTextBox.ReadOnly = false;
                try
                {
                    boardTextBox.BoardItem.BoardStyle.SampleStyleNo = int.Parse(boardTextBox.Text);
                }
                catch
                {
                    boardTextBox.BoardItem.BoardStyle.SampleStyleNo = 0;
                }
            }
        }

        /// <summary>
        /// 单击酶标仪孔事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardItem_Click(object sender, EventArgs e)
        {
            if (this.m_chkLockTemplate.Checked) return;

            ctlSTTextBox boardTextBox = sender as ctlSTTextBox;
            if (boardTextBox == null || !string.IsNullOrEmpty(boardTextBox.Text)) return;
            if (boardTextBox.ReadOnly) return;

            clsSTBoardItem boardItem = boardTextBox.BoardItem as clsSTBoardItem;
            if (boardItem == null) return;

            clsSTBoardStyle boardItemStyle = boardItem.BoardStyle;
            if (boardItemStyle.SampleStyle != enmSTSampleStyle.NONE) return;

            boardItemStyle.SampleStyle = this.m_sampleStyle;
            switch (this.m_sampleStyle)
            {
                case enmSTSampleStyle.Common:
                    boardItemStyle.SampleStyleNo = ++this.m_maxCommon;
                    break;
                case enmSTSampleStyle.Standard:
                    boardItemStyle.SampleStyleNo = ++this.m_maxStandard;
                    break;
                case enmSTSampleStyle.Quality:
                    boardItemStyle.SampleStyleNo = ++this.m_maxQuality;
                    break;
                default:
                    break;
            }
            boardTextBox.DoClick();
        }

        /// <summary>
        /// 读板事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdRead_Click(object sender, EventArgs e)
        {
            if (m_selectProject == null || m_selectProject.Name == string.Empty)
            {
                MessageBox.Show("请选择检验项目！");
                return;
            }

            if (m_selectTemplate == null || m_selectTemplate.TemplateName==string.Empty)
            {
                MessageBox.Show("请选择模板！");
                return;
            }

            string message=manager.ReadBoard();
            if (!string.IsNullOrEmpty(message))
	        {
                MessageBox.Show(message);
                return;
	        }
            this.m_cmdSubmitData.Enabled = true;
            this.m_cmdAnalysis.Enabled = true;
                
        }

        private void m_cboCheckProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsSTCheckProject project = m_cboCheckProjects.SelectProejct;
            if (project != null)
            {
                this.m_selectProject = project;
                this.m_txtTestWaveLength.Text = project.TestWaveLength;
                this.m_txtRefWaveLength.Text = project.RefWaveLength;
                this.m_txtBoardTime.Text = project.BoardTime;
                this.m_txtBoardFrequency.Text = project.BoardFrequence;
                this.m_txtBoardWay.Text = project.BoardWay;
                this.m_txtFormula.Text = project.Formula;

                manager.CheckProject = project;
            }
        }

        private void m_cboBatchNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsSTCheckSample sample = m_cboBatchNo.SelectSample;
            if (sample != null)
            {
                this.m_selectSample = sample;
                DateTime deadLine = DateTime.MinValue;
                try { deadLine = DateTime.Parse(sample.DeadLine); }
                catch { deadLine = DateTime.Now; }

                this.m_dtpSampleDeadLine.Value = deadLine;
                this.m_txtSampleProvider.Text = sample.Company;
            }
        }

        private void m_cboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            clsBoardTemplate template = m_cboTemplate.SelectTemplate;
            if (template != null)
            {
                manager.ChangedTemplate(template);
            }
            m_selectTemplate = template;

        }

        private void m_cmdClearTemplate_Click(object sender, EventArgs e)
        {

            m_maxCommon = 0;
            m_maxQuality = 0;
            m_maxStandard = 0;

            manager.ClearTemplate();
        }

        private void m_cmdClearData_Click(object sender, EventArgs e)
        {
            manager.ClearData();
        }

        private void m_cmdSaveTemplate_Click(object sender, EventArgs e)
        {
            string message;
            manager.SaveTemplate(out message);
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }
        }

        private void m_cmdAnalysis_Click(object sender, EventArgs e)
        {   
            if (m_selectProject == null || m_selectProject.Name == string.Empty)
            {
                MessageBox.Show("请选择检验项目！");
                return;
            }

            if (m_selectTemplate == null || m_selectTemplate.TemplateName == string.Empty)
            {
                MessageBox.Show("请选择模板！");
                return;
            }

            if (manager.IsDataNullOrEmpty)
            {
                MessageBox.Show("没有酶标检验项目结果！");
                return;
            }

            string message=string.Empty;
            manager.AnalysisData(out message);
            if (!string.IsNullOrEmpty(message))
            {
                MessageBox.Show(message);
                return;
            }

            this.m_txtNegative.Text = manager.ConstractValue.NegativeValue.ToString();
            this.m_txtPositive.Text = manager.ConstractValue.PositiveValue.ToString();
            this.m_txtBlank.Text = manager.ConstractValue.BlankValue.ToString();

            this.m_txtNegative.Enabled = false;
            this.m_txtPositive.Enabled = false;
            this.m_txtBlank.Enabled = false;
        }

        private void m_cmdSubmitData_Click(object sender, EventArgs e)
        {
            if (m_selectProject == null || m_selectProject.Name == string.Empty)
            {
                MessageBox.Show("请选择检验项目！");
                return;
            }

            if (m_selectTemplate == null || m_selectTemplate.TemplateName == string.Empty)
            {
                MessageBox.Show("请选择模板！");
                return;
            }

            if (m_lstCheckResults == null || m_lstCheckResults.Count == 0)
            {
                MessageBox.Show("没有酶标检验项目结果！");
                return;
            }

            if (MessageBox.Show(string.Format("仪器传送时间是：{0} \n   检验项目名称是：{1} \n  确认后数据将不能更改！", m_lstCheckResults[0].m_strCheckDat, m_selectProject.Name), "是否确认", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }


            string boardNo = m_txtBoardNO.Text;
            if (string.IsNullOrEmpty(boardNo))
            {
                MessageBox.Show("微孔板编号为空！");
                return;
            }

            string[] arrBoardNo = null;
            clsST360CheckResultSmp.s_object.m_lngFindBoardName(out arrBoardNo);

            if (arrBoardNo == null)
            {
                return;
            }

            foreach (string strboardNo in arrBoardNo)
            {
                if (strboardNo.Trim() == boardNo.Trim())
                {
                    MessageBox.Show("微孔板编号数据库中已存在！");
                    m_txtBoardNO.SelectAll();
                    return;
                }
            }

            foreach (clsDeviceReslutVO checkResult in m_lstCheckResults)
            {
                foreach (clsSTBoardItem boardItem in m_lstBoard)
                {
                    if (checkResult.m_strDeviceSampleID == boardItem.Sequence.ToString())
                    {
                        checkResult.m_strUnit = checkResult.m_strResult;
                        checkResult.m_strResult = boardItem.IsPositive ? "阳" : "阴";
                        checkResult.m_strDeviceCheckItemName = this.m_selectProject.EnglishName;
                    }
                }
            }

            foreach (clsDeviceReslutVO deviceResult in m_lstCheckResults)
            {
                clsST360Smp.s_object.m_lngUpdateDeviceResult(deviceResult);
            }


            DateTime dt = DateTime.Now;
            foreach (clsSTBoardItem boardItem in m_lstBoard)
            {

                clsDeviceReslutVO checkResult = FindDeviceReslut(boardItem);
                if (checkResult == null) continue;

                clsST360CheckResultVO checkResultVO = new clsST360CheckResultVO();

                checkResultVO.m_blnStatus = true;
                checkResultVO.m_dtModify = dt;
                checkResultVO.m_dtOperator = dt;
                checkResultVO.m_enmSampelType = boardItem.BoardStyle.SampleStyle;
                checkResultVO.m_intSampleId = boardItem.Sequence;
                checkResultVO.m_intTemplateNo = boardItem.BoardStyle.SampleStyleNo;
                checkResultVO.m_strBoardNo = boardNo;
                checkResultVO.m_strDeviceId = checkResult.m_strDeviceID;
                checkResultVO.m_strItemEnglishName = m_selectProject.EnglishName;
                checkResultVO.m_strItemName = m_selectProject.Name;
                checkResultVO.m_strOperatorId = this.LoginInfo.m_strEmpID;
                checkResultVO.m_strResultNum = boardItem.DataNum;
                checkResultVO.m_strResultText = boardItem.IsPositive ? "阳" : "阴";

                clsST360CheckResultSmp.s_object.m_lngInsert(checkResultVO);
            }

            MessageBox.Show("数据确认成功！");
            manager.ClearData();
        }       

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            frmHistorySearch histroySearch = new frmHistorySearch();
            if (histroySearch.ShowDialog() == DialogResult.Yes)
            {
                if (!string.IsNullOrEmpty(histroySearch.BoardNo))
                {

                    manager.ReadHistory(histroySearch.BoardNo);

                    this.m_cmdAnalysis.Enabled = false;
                    this.m_cmdSubmitData.Enabled = false;
                    m_lstCheckResults = null;
                }
            }
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdConfig_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 是否修改了对照值
        /// </summary>
        private void m_cmdModfifyConstract_Click(object sender, EventArgs e)
        {
            this.m_txtNegative.Enabled = true;
            this.m_txtPositive.Enabled = true;
            this.m_txtBlank.Enabled = true;

            this.m_cmdModfifyConstract.Visible = false;
            this.m_cmdSubmitModi.Visible = true;
        }

        /// <summary>
        /// 确认修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdSubmitModi_Click(object sender, EventArgs e)
        {
            manager.IsSelfConstractValue = true;
            clsSTConstract constract = new clsSTConstract();

            try { constract.NegativeValue = float.Parse(m_txtNegative.Text); }
            catch { constract.NegativeValue = 0; }

            try { constract.PositiveValue = float.Parse(m_txtPositive.Text); }
            catch { constract.PositiveValue = 0; }

            try { constract.BlankValue = float.Parse(m_txtBlank.Text); }
            catch { constract.BlankValue = 0; }

            manager.ConstractValue = constract;

            this.m_txtNegative.Enabled = false;
            this.m_txtPositive.Enabled = false;
            this.m_txtBlank.Enabled = false;

            this.m_cmdModfifyConstract.Visible = true;
            this.m_cmdSubmitModi.Visible = false;
        }


        #region 样本类型选择改变事件

        private void SampleStyleChanged(object sender)
        {
            RadioButton rdoButton = sender as RadioButton;
            if (rdoButton != null)
            {
                if (!rdoButton.Checked)
                {
                    return;
                }
                if (rdoButton != m_rdoBlank) { m_rdoBlank.Checked = false; }
                else { this.m_sampleStyle = enmSTSampleStyle.Blank; }

                if (rdoButton != m_rdoCommon) { m_rdoCommon.Checked = false; }
                else { this.m_sampleStyle = enmSTSampleStyle.Common; }

                if (rdoButton != m_rdoNegative) { m_rdoNegative.Checked = false; }
                else { this.m_sampleStyle = enmSTSampleStyle.Negative; }

                if (rdoButton != m_rdoPositive) { m_rdoPositive.Checked = false; }
                else { this.m_sampleStyle = enmSTSampleStyle.Positive; }

                if (rdoButton != m_rdoStandard) { m_rdoStandard.Checked = false; }
                else { this.m_sampleStyle = enmSTSampleStyle.Standard; }

                if (rdoButton != m_rdoQuality) { m_rdoQuality.Checked = false; }
                else { this.m_sampleStyle = enmSTSampleStyle.Quality; }
            }
        }

        private void m_rdoCommon_CheckedChanged(object sender, EventArgs e)
        {
            SampleStyleChanged(sender);
        }

        private void m_rdoBlank_CheckedChanged(object sender, EventArgs e)
        {
            SampleStyleChanged(sender);
        }

        private void m_rdoNegative_CheckedChanged(object sender, EventArgs e)
        {
            SampleStyleChanged(sender);
        }

        private void m_rdoPositive_CheckedChanged(object sender, EventArgs e)
        {
            SampleStyleChanged(sender);
        }

        private void m_rdoStandard_CheckedChanged(object sender, EventArgs e)
        {
            SampleStyleChanged(sender);
        }

        private void m_rdoQuality_CheckedChanged(object sender, EventArgs e)
        {
            SampleStyleChanged(sender);
        }

        #endregion

        #endregion

        #region 辅助方法

        /// <summary>
        /// 根据状态显示文本
        /// </summary>
        /// <param name="showStatus"></param>
        private void DisplayCheckResult(enmSTTextBoxShowStatus showStatus)
        {
            foreach (ctlSTTextBox stBox in m_lstSTTextBoxs)
            {
                stBox.ShowStatus = showStatus;
                stBox.ReadOnly = false;
            }

            foreach (clsSTBoardItem boardItem in manager.Data)
            {
                foreach (ctlSTTextBox box in m_lstSTTextBoxs)
                {
                    if (boardItem.Sequence==box.BoardItem.Sequence)
                    {
                        box.BoardItem = boardItem;
                    }
                }
            }

            foreach (ctlSTTextBox stBox in m_lstSTTextBoxs)
            {
                stBox.ReadOnly = true;
            }
        }

        private clsDeviceReslutVO FindDeviceReslut(clsSTBoardItem boardItem)
        {
            foreach (clsDeviceReslutVO checkResult in m_lstCheckResults)
            {
                if (checkResult.m_strDeviceSampleID == boardItem.Sequence.ToString())
                {
                    return checkResult;
                }
            }
            return null;
        }

        #endregion
    }
}