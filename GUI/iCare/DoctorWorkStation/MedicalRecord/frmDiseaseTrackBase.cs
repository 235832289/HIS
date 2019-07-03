using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using HRP;
using com.digitalwave.emr.DigitalSign;
using com.digitalwave.Emr.Signature_gui;
using iCare.ICU.Espial;
using com.digitalwave.emr.AssistModuleVO;

namespace iCare
{
    /// <summary>
    ///  病程记录中特殊记录单的基窗体。
    /// 在此窗体处理保存、修改、删除、作废重做、保留痕迹、双划线功能清空界面的通用逻辑。
    /// 设置病程信息和获取病程信息的通用逻辑。
    /// 打印功能，读取已经删除的记录。
    /// </summary>
    public class frmDiseaseTrackBase : frmHRPBaseForm, PublicFunction
    {

        #region Designer generated code
        public System.Windows.Forms.TreeView m_trvCreateDate;
        protected System.Windows.Forms.Label lblCreateDateTitle;
        protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpCreateDate;
        protected System.Windows.Forms.ContextMenu m_cmuRichTextBoxMenu;
        protected System.Windows.Forms.MenuItem mniDoubleStrikeOutDelete;
        protected System.Drawing.Printing.PrintDocument m_pdtPintDocument;
        protected com.digitalwave.Utility.Controls.ctlTimePicker m_dtpGetDataTime;
        protected System.Windows.Forms.Label m_lblGetDataTime;
        private System.ComponentModel.IContainer components = null;







        /// <summary>
        /// Clean up any resources being used.
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


        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCreateDateTitle = new System.Windows.Forms.Label();
            this.m_dtpCreateDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_trvCreateDate = new System.Windows.Forms.TreeView();
            this.m_cmuRichTextBoxMenu = new System.Windows.Forms.ContextMenu();
            this.mniDoubleStrikeOutDelete = new System.Windows.Forms.MenuItem();
            this.m_pdtPintDocument = new System.Drawing.Printing.PrintDocument();
            this.m_dtpGetDataTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.m_lblGetDataTime = new System.Windows.Forms.Label();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(32, 80);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(582, 86);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(80, 76);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(721, 80);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(80, 40);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(32, 48);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.ForeColor = System.Drawing.Color.Black;
            this.m_lblForTitle.Location = new System.Drawing.Point(272, 16);
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(448, 40);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.AutoSize = true;
            this.lblCreateDateTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCreateDateTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCreateDateTitle.Location = new System.Drawing.Point(268, 120);
            this.lblCreateDateTitle.Name = "lblCreateDateTitle";
            this.lblCreateDateTitle.Size = new System.Drawing.Size(70, 14);
            this.lblCreateDateTitle.TabIndex = 6068;
            this.lblCreateDateTitle.Text = "记录时间:";
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.BorderColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpCreateDate.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpCreateDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpCreateDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpCreateDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpCreateDate.Location = new System.Drawing.Point(348, 116);
            this.m_dtpCreateDate.m_BlnOnlyTime = false;
            this.m_dtpCreateDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpCreateDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpCreateDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpCreateDate.Name = "m_dtpCreateDate";
            this.m_dtpCreateDate.ReadOnly = false;
            this.m_dtpCreateDate.Size = new System.Drawing.Size(212, 22);
            this.m_dtpCreateDate.TabIndex = 11;
            this.m_dtpCreateDate.TextBackColor = System.Drawing.Color.White;
            this.m_dtpCreateDate.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.BackColor = System.Drawing.Color.White;
            this.m_trvCreateDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvCreateDate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_trvCreateDate.HideSelection = false;
            this.m_trvCreateDate.ItemHeight = 18;
            this.m_trvCreateDate.Location = new System.Drawing.Point(32, 112);
            this.m_trvCreateDate.Name = "m_trvCreateDate";
            this.m_trvCreateDate.Size = new System.Drawing.Size(212, 88);
            this.m_trvCreateDate.TabIndex = 10;
            this.m_trvCreateDate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvCreateDate_AfterSelect);
            // 
            // m_cmuRichTextBoxMenu
            // 
            this.m_cmuRichTextBoxMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mniDoubleStrikeOutDelete});
            // 
            // mniDoubleStrikeOutDelete
            // 
            this.mniDoubleStrikeOutDelete.Index = 0;
            this.mniDoubleStrikeOutDelete.Text = "双划线删除";
            this.mniDoubleStrikeOutDelete.Click += new System.EventHandler(this.mniDoubleStrikeOutDelete_Click);
            // 
            // m_pdtPintDocument
            // 
            this.m_pdtPintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdtPintDocument_PrintPage);
            this.m_pdtPintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdtPintDocument_EndPrint);
            this.m_pdtPintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdtPintDocument_BeginPrint);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.BorderColor = System.Drawing.Color.Black;
            this.m_dtpGetDataTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.m_dtpGetDataTime.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_dtpGetDataTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_dtpGetDataTime.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_dtpGetDataTime.flatFont = new System.Drawing.Font("宋体", 12F);
            this.m_dtpGetDataTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_dtpGetDataTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(352, 152);
            this.m_dtpGetDataTime.m_BlnOnlyTime = false;
            this.m_dtpGetDataTime.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.m_dtpGetDataTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.m_dtpGetDataTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.m_dtpGetDataTime.Name = "m_dtpGetDataTime";
            this.m_dtpGetDataTime.ReadOnly = false;
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(212, 22);
            this.m_dtpGetDataTime.TabIndex = 10000004;
            this.m_dtpGetDataTime.TextBackColor = System.Drawing.Color.White;
            this.m_dtpGetDataTime.TextForeColor = System.Drawing.Color.Black;
            this.m_dtpGetDataTime.Visible = false;
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.AutoSize = true;
            this.m_lblGetDataTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblGetDataTime.ForeColor = System.Drawing.Color.Black;
            this.m_lblGetDataTime.Location = new System.Drawing.Point(248, 152);
            this.m_lblGetDataTime.Name = "m_lblGetDataTime";
            this.m_lblGetDataTime.Size = new System.Drawing.Size(98, 14);
            this.m_lblGetDataTime.TabIndex = 6068;
            this.m_lblGetDataTime.Text = "获取数据时间:";
            this.m_lblGetDataTime.Visible = false;
            // 
            // frmDiseaseTrackBase
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(996, 733);
            this.Controls.Add(this.m_dtpGetDataTime);
            this.Controls.Add(this.lblCreateDateTitle);
            this.Controls.Add(this.m_trvCreateDate);
            this.Controls.Add(this.m_dtpCreateDate);
            this.Controls.Add(this.m_lblGetDataTime);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "frmDiseaseTrackBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDiseaseTrackBase_Load);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        #region 字段
        // 病程记录的领域层实例
        protected clsDiseaseTrackDomain m_objDiseaseTrackDomain;

        protected clsTrackRecordContent m_objReAddNewOld;

        // 保存当前显示的记录内容的变量
        protected clsTrackRecordContent m_objCurrentRecordContent;

        protected TreeNode m_trnRoot;
        /// <summary>
        /// 表单病人
        /// </summary>
        protected clsPatient m_objCurrentPatient;
        /// <summary>
        /// 日期
        /// </summary>
        protected string m_strOpenDate;

        protected clsBorderTool m_objBorderTool;

        // 打印报表的内容文档
        protected PrintDocument m_pdcPrintDocument;
        //第一次打印时间
        protected DateTime m_dtmFirstPrintDate;

        // 标记是否首次打印
        protected bool m_blnIsFirstPrint;

        protected bool m_blnAlreadySetPrintTools = false;

        public bool m_blnIsAddNew = false; //是否新添记录--wf20080121

        /// <summary>
        /// 是否可以触发树节点的选中事件
        /// </summary>
        protected bool m_blnCanTreeNodeAfterSelectEventTakePlace = true;

        /// <summary>
        /// 表单是否可以无痕迹修改。默认为true
        /// 此变量只能由checkbox来控制其状态
        /// </summary>
        bool m_blnIsModifyWithoutMark = true;

        protected override bool blnIsModifyWithoutMark
        {
            get { return m_blnIsModifyWithoutMark; }
        }

        protected bool m_blnCanShowDiseaseTrack = true;
        #endregion

        #region 属性
        /// <summary>
        /// 获取当前表单状态
        /// </summary>
        protected override enmFormState m_EnmCurrentFormState
        {
            get
            {
                return enmFormState.NowUser;
            }
        }

        /// <summary>
        /// 是否新添加记录。true，新添加；false，修改。
        /// </summary>
        protected override bool m_BlnIsAddNew
        {
            get
            {
                return m_objCurrentRecordContent == null;
            }
        }
        #endregion

        #region 构造函数
        public frmDiseaseTrackBase()
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();


            // TODO: Add any initialization after the InitializeComponent call
            m_objBorderTool = new clsBorderTool(Color.White);
            m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[] { m_trvCreateDate });
            if (m_trvCreateDate.Nodes.Count == 0)
                m_trvCreateDate.Nodes.Add("记录时间");
            m_trnRoot = m_trvCreateDate.Nodes[0];

            m_objDiseaseTrackDomain = m_objGetDiseaseTrackDomain();
        }
        #endregion

        #region 接口实现
        public void Save()
        {
            long m_lngRe = this.m_lngSave();
            if (m_lngRe > 0)
            {
                if (this.m_trvCreateDate.SelectedNode != null)
                {
                    this.m_trvCreateDate_AfterSelect(this.m_trvCreateDate, new System.Windows.Forms.TreeViewEventArgs(this.m_trvCreateDate.SelectedNode));
                }
                clsPublicFunction.ShowInformationMessageBox("保存成功！");
            }
            else
                clsPublicFunction.ShowInformationMessageBox("保存失败！");
        }

        public void Delete()
        {
            //指明表单类型为护理
            //if (this.Name == "frmConsultation" || this.Name == "frmOutHospital" || this.Name == "frmEMR_OutHospitalIn24Hours" || this.Name == "frmDeathRecordIn24Hours" || this.Name == "frmDeathCaseDiscuss")
            //    intFormType = 1;
            //else
            //    intFormType = 2;
            long m_lngRe = m_lngDelete();
            if (m_lngRe > 0)
            {
                //this.m_trvCreateDate.SelectedNode=this.m_trvCreateDate.Nodes[0];
                if (this.m_trvCreateDate.SelectedNode != null)
                {
                    this.m_trvCreateDate_AfterSelect(this.m_trvCreateDate, new System.Windows.Forms.TreeViewEventArgs(this.m_trvCreateDate.SelectedNode));
                }


            }

        }
        public void Display() { }
        public void Display(string strInPatientID, string strInPatientDate)
        {
        }
        public void Print()
        {
            this.m_lngPrint();
        }
        public void Copy() { m_lngCopy(); }
        public void Cut() { m_lngCut(); }
        public void Paste() { m_lngPaste(); }
        public void Verify()
        {
            try
            {
                //检查当前病人变量是否为null          
                if (m_objCurrentPatient == null)
                {
                    clsPublicFunction.ShowInformationMessageBox("未选定病人,无法验证!");
                }
                //检查当前记录是否为null
                if (m_objCurrentRecordContent == null)
                {
                    clsPublicFunction.ShowInformationMessageBox("未选定记录,无法验证!");
                }
                string strInPatientID = m_objCurrentRecordContent.m_strInPatientID;
                //string strInPatientDate = m_objCurrentRecordContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss");
                string strRecordID = strInPatientID.Trim() + "-" + m_objCurrentRecordContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                long lngRes = m_lngSignVerify(this.Name.Trim(), strRecordID);
            }
            catch (Exception exp)
            {
                MessageBox.Show("签名验证出现异常：" + exp.Message, "Message" + " 确认是否插入key盘", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void Redo() { }
        public void Undo() { }
        #endregion

        #region 初始化清空

        /// <summary>
        /// 是否允许修改记录时间等记录信息。
        /// </summary>
        /// <param name="p_blnEnable"></param>
        protected void m_mthEnableModify(bool p_blnEnable)
        {
            //设置记录时间的 Enable = p_blnEnable
            m_dtpCreateDate.Enabled = p_blnEnable;

            //设置具体记录的特殊控制
            m_mthEnableModifySub(p_blnEnable);
        }
        /// <summary>
        /// 清空界面
        /// </summary>
        protected void m_mthClearAll()
        {
            //清空病人基本信息            
            m_mthClearPatientBaseInfo();
            //清空时间列表树
            m_trnRoot.Nodes.Clear();

            //重置当前病人变量
            m_objCurrentPatient = null;

            //清空当前记录。
            m_mthClearPatientRecordInfo();
        }

        /// <summary>
        /// 清空病人记录所有信息。
        /// </summary>
        protected void m_mthClearPatientRecordInfo()
        {
            //把记录时间恢复到当前时间      
            m_dtpCreateDate.Value = DateTime.Now;

            m_mthEnableModify(true);

            //清空记录内容                       
            m_mthClearRecordInfo();

            //清空保存当前记录的变量
            m_objCurrentRecordContent = null;

            //清空（重置）辅助信息 
            m_objReAddNewOld = null;

            m_mthSetModifyControl(null, true);
        }

        /// <summary>
        /// 清空特殊记录信息，并重置记录控制状态为不控制。
        /// </summary>
        protected virtual void m_mthClearRecordInfo()
        {
            //清空具体记录内容，由子窗体重载实现
        }
        /// <summary>
        /// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
        /// </summary>
        /// <param name="p_blnEnable"></param>
        protected void m_mthEnablePatientSelect(bool p_blnEnable)
        {
            //设置病人选择信息的 Enable = p_blnEnable
            if (p_blnEnable == false)
            {
                m_lblForTitle.Visible = false;
                lblAreaTitle.Visible = false;
                m_cboArea.Visible = false;
                lblBedNoTitle.Visible = false;
                m_txtBedNO.Visible = false;
                lblNameTitle.Visible = false;
                m_txtPatientName.Visible = false;
                lblInHospitalNoTitle.Visible = false;
                txtInPatientID.Visible = false;
                m_trvCreateDate.Visible = false;
                lblSexTitle.Visible = false;
                lblSex.Visible = false;
                lblAgeTitle.Visible = false;
                lblAge.Visible = false;
                m_objBorderTool.m_mthUnChangedControlBorder(m_trvCreateDate);

                m_cboArea.Enabled = p_blnEnable;
                m_txtBedNO.ReadOnly = !p_blnEnable;
                m_txtPatientName.ReadOnly = !p_blnEnable;
                txtInPatientID.ReadOnly = !p_blnEnable;

                //设置时间列表树的 Enable = p_blnEnable			
                m_trvCreateDate.Enabled = p_blnEnable;

            }


            m_mthEnablePatientSelectSub(p_blnEnable);
        }


        /// <summary>
        /// 新增时设置默认信息
        /// </summary>
        /// <param name="p_objPatient"></param>
        public void m_mthSetDiseaseTrackInfoForAddNew(clsPatient p_objPatient)
        {
            //参数检查  
            if (p_objPatient == null)
                return;

            m_mthSetPatient(p_objPatient);

            m_mthSetDefaultValue(p_objPatient);

            m_mthEnablePatientSelect(false);

            m_mthAddFormStatusForClosingSave();
        }


        #endregion

        #region TreeView有关操作
        /// <summary>
        /// 设置TeeeView默认选择的节点
        /// </summary>
        protected virtual void m_mthSetNodeSelected()
        {
            if (m_trnRoot.Nodes.Count == 0)
                m_trvCreateDate.SelectedNode = m_trnRoot;
            else
                m_trvCreateDate.SelectedNode = m_trnRoot.Nodes[0];
        }
        /// <summary>
        /// 添加节点到时间列表树,并选中
        /// </summary>
        /// <param name="p_objContent"></param>
        protected virtual void m_mthAddNode(clsTrackRecordContent p_objContent)
        {
            if (p_objContent == null)
            {
                return;
            }
            string strCreateDate = p_objContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");
            TreeNode trnNode = new TreeNode(strCreateDate);
            trnNode.Tag = p_objContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");

            m_blnCanTreeNodeAfterSelectEventTakePlace = false;

            if (m_trnRoot.Nodes.Count == 0 || trnNode.Text.CompareTo(m_trnRoot.LastNode.Text) < 0)
            {
                m_trnRoot.Nodes.Add(trnNode);
                m_trvCreateDate.SelectedNode = m_trnRoot.LastNode;//
            }
            else
            {
                for (int i = 0; i < m_trnRoot.Nodes.Count; i++)
                {
                    if (trnNode.Text.CompareTo(m_trnRoot.Nodes[i].Text) > 0)
                    {
                        m_trnRoot.Nodes.Insert(i, trnNode);
                        m_trvCreateDate.SelectedNode = m_trnRoot.Nodes[i];//
                        break;
                    }
                }
            }
            m_blnCanTreeNodeAfterSelectEventTakePlace = true;
            m_dtpCreateDate.Enabled = false;
        }

        #endregion

        #region 虚函数
        /// <summary>
        /// 数据复用
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected virtual void m_mthDataShare(clsPatient p_objSelectedPatient)
        {
            return;
        }

        /// <summary>
        /// 从界面获取特殊记录的值。如果界面值出错，返回null。
        /// </summary>
        /// <returns></returns>
        protected virtual clsTrackRecordContent m_objGetContentFromGUI()
        {
            //从界面获取表单值，由子窗体重载实现			
            return null;
        }

        protected virtual void m_mthGetPCAnaesthetist(clsTrackRecordContent p_objContent)
        {
            //把表单值赋值到界面，由子窗体重载实现
        }

        /// <summary>
        /// 把特殊记录的值显示到界面上。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected virtual void m_mthSetGUIFromContent(clsTrackRecordContent p_objContent)
        {
            //把表单值赋值到界面，由子窗体重载实现
        }

        protected virtual void m_mthSetDeletedGUIFromContent(clsTrackRecordContent p_objContent)
        {
            //把表单值赋值到界面，由子窗体重载实现
        }
        /// <summary>
        /// 把选择时间记录内容重新整理为完全正确的内容。
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        protected virtual void m_mthReAddNewRecord(clsTrackRecordContent p_objRecordContent)
        {
            //把选择时间记录内容重新整理为完全正确的内容，由子窗体重载实现。
        }

        /// <summary>
        /// 是否允许修改特殊记录的记录信息。
        /// </summary>
        /// <param name="p_blnEnable"></param>
        protected virtual void m_mthEnableModifySub(bool p_blnEnable)
        {
            //具体记录的特殊控制,根据子窗体的需要重载实现
        }

        /// <summary>
        /// 设置修改控件信息
        /// 子窗体实现
        /// </summary>
        /// <param name="p_objRecordContent"></param>
        /// <param name="p_blnReset"></param>
        protected virtual void m_mthSetModifyControlSub(clsTrackRecordContent p_objRecordContent,
            bool p_blnReset)
        {
            //具体控制,根据子窗体的需要重载实现
        }

        /// <summary>
        /// 获取病程记录的领域层实例
        /// </summary>
        /// <returns></returns>
        protected virtual clsDiseaseTrackDomain m_objGetDiseaseTrackDomain()
        {
            //获取病程记录的领域层实例，由子窗体重载实现			
            return null;
        }

        /// <summary>
        /// 保存套装模板所关联的手术名称
        /// </summary>
        protected virtual void m_mthSaveTemplateSet_Associate()
        {
            return;
        }

        /// <summary>
        /// 获取当前的特殊病程记录信息
        /// </summary>
        /// <returns></returns>
        public virtual clsDiseaseTrackInfo m_objGetDiseaseTrackInfo()
        {
            //获取当前的特殊病程记录信息，由子窗体重载实现
            return null;
        }

        /// <summary>
        /// 控制是否可以选择病人和记录时间列表。在从病程记录窗体调用时需要使用。
        /// </summary>
        /// <param name="p_blnEnable"></param>
        protected virtual void m_mthEnablePatientSelectSub(bool p_blnEnable)
        {
            //由子窗体重载实现	
        }
        #endregion

        #region 获取指定病程记录内容
        /// <summary>
        /// 设置病人表单信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
        {
            //判断病人信息是否为null，如果是，直接返回。
            if (p_objSelectedPatient == null || m_objDiseaseTrackDomain == null)
                return;

            //清空病人记录信息
            m_mthClearPatientRecordInfo();

            //清空时间列表树的时间节点 
            //			m_trnRoot.Nodes.Clear();
            m_trvCreateDate.Nodes.Clear();
            m_trvCreateDate.Nodes.Add("记录时间");
            m_trnRoot = m_trvCreateDate.Nodes[0];

            //记录病人信息
            m_objCurrentPatient = p_objSelectedPatient;
            //若表单不需要时间列表，则避免执行以下语句
            if (this.Name != "frmMiniBooldSugarContent" || this.Name != "frmICUNurseRecordContent")
            {

                //获取病人记录列表
                //string[] strCreateTimeListArr;
                //string[] strOpenTimeListArr;
                //m_mthGetTimeList(p_objSelectedPatient, out strCreateTimeListArr, out strOpenTimeListArr);


                //对时间节点进行倒序排序
                //new clsSortTool().m_mthSortTreeNode(m_trnRoot, true);

                //设置TeeeView默认选择的节点
                //m_mthSetNodeSelected();

                //展开树显示所有时间节点。
                //m_trnRoot.Expand();

            }

            m_mthIsReadOnly();

            m_blnCanShowDiseaseTrack = m_blnCanShowRecordContent();

        }

        /// <summary>
        /// 获取病人记录列表
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="strCreateTimeListArr"></param>
        /// <param name="strOpenTimeListArr"></param>
        /// <returns></returns>
        protected virtual void m_mthGetTimeList(clsPatient p_objSelectedPatient, out string[] strCreateTimeListArr, out string[] strOpenTimeListArr)
        {
            strCreateTimeListArr = null;
            strOpenTimeListArr = null;
            if (p_objSelectedPatient == null || m_objDiseaseTrackDomain == null)
                return;

            long lngRes = m_objDiseaseTrackDomain.m_lngGetRecordTimeList(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strCreateTimeListArr, out strOpenTimeListArr);

            if (lngRes <= 0 || strCreateTimeListArr == null || strOpenTimeListArr == null || strOpenTimeListArr.Length != strCreateTimeListArr.Length)
            {
                m_mthSetNodeSelected();
                return;
            }

            //添加查询到的时间到时间树上 
            for (int i = strCreateTimeListArr.Length - 1; i >= 0; i--)
            {
                TreeNode trnRecordDate = new TreeNode(strCreateTimeListArr[i]);
                trnRecordDate.Tag = strOpenTimeListArr[i];
                m_trnRoot.Nodes.Add(trnRecordDate);
            }
        }

        /// <summary>
        /// 获取指定病程记录内容
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="p_strOpenDate"></param>
        /// <returns></returns>
        public virtual clsTrackRecordContent m_objGetRecordContent(clsPatient p_objSelectedPatient, string p_strOpenDate)
        {
            clsTrackRecordContent objContent;
            //获取记录
            m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_strOpenDate, out objContent);
            return objContent;
        }
        #region 不用
        /// <summary>
        /// 获取指定病程记录内容(茶山有摄入排出的护理表单用)
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_stFormID">表单ID</param>
        /// <returns></returns>
        //public virtual clsTrackRecordContent m_objGetRecordContent(clsPatient p_objSelectedPatient, string p_strOpenDate,string p_strFormID)
        //{
        //    clsTrackRecordContent objContent;
        //    //获取记录
        //    m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_strOpenDate,p_strFormID, out objContent);
        //    return objContent;
        //}
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="p_strOpenDate"></param>
        protected void m_mthUseReAddNew(clsPatient p_objSelectedPatient,
            string p_strOpenDate)
        {
            //检查参数
            if (p_objSelectedPatient == null)
            {
                m_mthShowNoPatient();
                return;
            }
            if (p_strOpenDate == null || p_strOpenDate == "")
            {
                clsPublicFunction.ShowInformationMessageBox("请选择要作废的记录对应的记录时间!");
                return;
            }

            clsTrackRecordContent objContent;
            //获取记录
            long lngRes = m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_strOpenDate, out objContent);

            if (lngRes <= 0 || objContent == null)
                return;

            m_objReAddNewOld = objContent;
            m_objCurrentRecordContent = null;

            //设置时间,并使之不能修改
            m_dtpCreateDate.Enabled = true;

            m_mthReAddNewRecord(objContent);


        }
        #endregion

        #region 设置选定内容到界面

        /// <summary>
        /// 设置选择了的记录信息。
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="p_strOpenDate"></param>
        protected void m_mthSetSelectedRecord(clsPatient p_objSelectedPatient, string p_strOpenDate)
        {
            //检查参数
            if (p_objSelectedPatient == null || p_strOpenDate == null || p_strOpenDate == "")
                return;

            clsTrackRecordContent objContent = m_objGetRecordContent(p_objSelectedPatient, p_strOpenDate); ;
            //获取记录
            //			long lngRes = m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_strOpenDate ,out objContent);


            if (objContent == null)
                return;


            //设置当前记录及记录时间 
            m_objCurrentPatient = p_objSelectedPatient;
            m_strOpenDate = p_strOpenDate;

            txtInPatientID.Text = this.m_objCurrentPatient.m_StrHISInPatientID;
            m_dtpCreateDate.Value = objContent.m_dtmCreateDate;
            m_objCurrentRecordContent = objContent;

            m_dtmCreatedDate = objContent.m_dtmOpenDate;
            if (objContent.m_intMarkStatus != 0)
            {
                chkModifyWithoutMatk.Checked = false;
                chkModifyWithoutMatk.Visible = false;
            }
            else
            {
                chkModifyWithoutMatk.Checked = true;
                chkModifyWithoutMatk.Visible = true;
            }
            m_mthImplementset(objContent);

            //			m_mthGetPCAnaesthetist(objContent);
            //
            //			m_mthSetGUIFromContent(objContent);
            //
            m_mthSetSign(objContent.m_strModifyUserID);

        }
        #region 不用
        /// <summary>
        /// 设置选择了的记录信息(茶山有摄入排出的护理表单用)。
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="p_strOpenDate"></param>
        /// <param name="p_strFormID"></param>
        //protected void m_mthSetSelectedRecord(clsPatient p_objSelectedPatient, string p_strOpenDate,string p_strFormID)
        //{
        //    //检查参数
        //    if (p_objSelectedPatient == null || p_strOpenDate == null || p_strOpenDate == "")
        //        return;

        //    clsTrackRecordContent objContent = m_objGetRecordContent(p_objSelectedPatient, p_strOpenDate,p_strFormID); ;
        //    //获取记录
        //    //			long lngRes = m_objDiseaseTrackDomain.m_lngGetRecordContent(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_strOpenDate ,out objContent);


        //    if (objContent == null)
        //        return;


        //    //设置当前记录及记录时间 
        //    m_objCurrentPatient = p_objSelectedPatient;
        //    m_strOpenDate = p_strOpenDate;

        //    txtInPatientID.Text = this.m_objCurrentPatient.m_StrHISInPatientID;
        //    m_dtpCreateDate.Value = objContent.m_dtmCreateDate;
        //    m_objCurrentRecordContent = objContent;

        //    m_dtmCreatedDate = objContent.m_dtmOpenDate;
        //    if (objContent.m_intMarkStatus != 0)
        //    {
        //        chkModifyWithoutMatk.Checked = false;
        //        chkModifyWithoutMatk.Visible = false;
        //    }
        //    else
        //    {
        //        chkModifyWithoutMatk.Checked = true;
        //        chkModifyWithoutMatk.Visible = true;
        //    }
        //    m_mthImplementset(objContent);

        //    //			m_mthGetPCAnaesthetist(objContent);
        //    //
        //    //			m_mthSetGUIFromContent(objContent);
        //    //
        //    m_mthSetSign(objContent.m_strModifyUserID);

        //}
        #endregion
        /// <summary>
        /// 实现相应表单设置
        /// 从m_mthSetSelectedRecord分离出来
        /// </summary>
        /// <param name="p_objContent"></param>
        private void m_mthImplementset(clsTrackRecordContent p_objContent)
        {
            m_mthGetPCAnaesthetist(p_objContent);

            m_mthSetGUIFromContent(p_objContent);

            //m_mthSetSign(p_objContent.m_strModifyUserID);

            m_mthEnableModify(true);

            m_mthSetModifyControl(p_objContent, false);
        }
        /// <summary>
        /// 设置病程记录信息，并显示修改。
        /// </summary>
        /// <param name="p_objPatient"></param>
        /// <param name="p_dtmRecordTime"></param>
        public void m_mthSetDiseaseTrackInfo(clsPatient p_objPatient,
            DateTime p_dtmRecordTime)
        {
            //参数检查  
            if (p_objPatient == null)
                return;
            m_mthSetPatient(p_objPatient);

            //设置记录信息
            m_mthSetSelectedRecord(p_objPatient, p_dtmRecordTime.ToString("yyyy-MM-dd HH:mm:ss"));

            //不允许用户修改记录的基本信息                        
            m_mthEnablePatientSelect(false);

            m_mthAddFormStatusForClosingSave();
        }
        #region 不用
        /// <summary>
        /// 设置病程记录信息，并显示修改(茶山有摄入排出的护理表单用)。
        /// </summary>
        /// <param name="p_objPatient"></param>
        /// <param name="p_dtmRecordTime"></param>
        /// <param name="p_dtmFormID">表单ID</param>
        //public void m_mthSetDiseaseTrackInfo(clsPatient p_objPatient,
        //    DateTime p_dtmRecordTime,string p_strFormID)
        //{
        //    //参数检查  
        //    if (p_objPatient == null)
        //        return;

        //    m_mthSetPatient(p_objPatient);

        //    //设置记录信息
        //    m_mthSetSelectedRecord(p_objPatient, p_dtmRecordTime.ToString("yyyy-MM-dd HH:mm:ss"),p_strFormID);

        //    //不允许用户修改记录的基本信息                        
        //    m_mthEnablePatientSelect(false);

        //    m_mthAddFormStatusForClosingSave();
        //}
        #endregion
        #endregion

        #region 保存记录
        /// <summary>
        /// 设置签名（旧）
        /// 以后逐渐使用新的签名
        /// 出于兼容考虑 保留
        /// </summary>
        /// <param name="p_strUserID"></param>
        protected virtual void m_mthSetSign(string p_strUserID)
        {
            foreach (Control ctlSub in this.Controls)
            {
                if (ctlSub.Name == "m_txtSign")
                {
                    clsEmployee objEmp = new clsEmployee(p_strUserID);
                    ctlSub.Text = objEmp.m_StrLastName;
                    ctlSub.Tag = objEmp;
                }
            }
        }
        /// <summary>
        /// 保存记录
        /// </summary>
        /// <returns></returns>
        protected override long m_lngSubAddNew()
        {
            long lngRes = 0;
            if (m_objReAddNewOld != null)
                lngRes = m_lngReAddNew();
            else
                lngRes = m_lngAddNewRecord();

            if (lngRes > 0 && com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_ObjCurrentEmployee.m_strTECHNICALRANK_CHR == "见习医师")
            {
                clsEMR_CaseAuditVO objAuditVO = m_objGetAuditCase();
                objAuditVO.m_dtmCREATEDATE = m_objCurrentRecordContent.m_dtmOpenDate;
                m_mthAddAuditCase(objAuditVO);
            }
            return lngRes;
        }

        #region 新建记录保存
        /// <summary>
        /// 添加新记录的数据库保存。
        /// </summary>
        /// <returns></returns>
        protected long m_lngAddNewRecord()
        {
            long lngRes = 0;
            try
            {
                //检查当前病人变量是否为null
                if (m_objCurrentPatient == null)
                {
                    m_mthShowNoPatient();
                    return -1;
                }
                //获取服务器时间
                string strTimeNow = new clsPublicDomain().m_strGetServerTime();
                //从界面获取记录信息
                //clsTrackRecordContent objContent = m_objGetContentFromGUI();     
                clsTrackRecordContent objContent = new clsTrackRecordContent();
                //新建保存肯定为无痕迹状态
                chkModifyWithoutMatk.Checked = true;
                //界面取值
                objContent = m_objGetContentFromGUI();

                //界面输入值出错           
                if (objContent == null)
                    return -1;

                //设置 clsTrackRecordContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
                m_mthSetSubCreatedDateInfo(ref objContent, true);
                objContent.m_intMarkStatus = 0; //新建表单可以无痕迹修改

                #region 多签名时验证所有签名者 并保存

                    //数字签名 
                    //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strInPatientID.Trim() + "-" +  objContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss"); 
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objCurrentPatient.m_StrRegisterId;

                if (objContent.objSignerArr != null)
                {
                    ArrayList objSignerArr = new ArrayList();
                    for (int i = 0; i < objContent.objSignerArr.Length; i++)
                    {
                        if (objContent.objSignerArr[i].controlName == "lsvSign" || objContent.objSignerArr[i].controlName == "txtSign")
                            objSignerArr.Add(objContent.objSignerArr[i].objEmployee);
                    }

                    clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                    if (objCheck.CheckSigner(objContent, objSign_VO) == -1)
                        return -1;

                }
                else
                {
                    objContent.m_strModifyUserID = MDIParent.OperatorID;
                    clsCheckSignersController objCheck = new clsCheckSignersController();
                    if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                        return -1;

                }
                #endregion


                //保存记录
                clsPreModifyInfo objModifyInfo = null;
                lngRes = m_objDiseaseTrackDomain.m_lngAddNewRecord(objContent, out objModifyInfo);

                //根据结果做不同的处理
                switch ((enmOperationResult)lngRes)
                {
                    case enmOperationResult.DB_Succeed:
                        m_mthSaveTemplateSet_Associate();

                        m_objCurrentRecordContent = objContent;
                        m_dtmCreatedDate = objContent.m_dtmOpenDate;
                        //添加节点到时间列表树,并选中
                        m_mthAddNode(m_objCurrentRecordContent);
                        break;

                    case enmOperationResult.DB_Fail:
                        clsPublicFunction.ShowInformationMessageBox("对不起,添加失败!");
                        break;
                    case enmOperationResult.Parameter_Error:
                        clsPublicFunction.ShowInformationMessageBox("参数错误!");
                        break;
                    case enmOperationResult.Record_Already_Exist:
                        m_mthShowRecordTimeDouble();
                        break;
                    //...
                }
            }

            catch (NullReferenceException ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
            }

            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
                MessageBox.Show(ex.Message, "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            //返回结果
            return lngRes;
        }
        #endregion

        #region 保存修改记录
        protected override long m_lngSubModify()
        {
            long lngRes = 0;
            try
            {
                //检查当前病人变量是否为null
                if (m_objCurrentPatient == null)
                {
                    m_mthShowNoPatient();
                    return -1;
                }

                //获取服务器时间
                string strTimeNow = new clsPublicDomain().m_strGetServerTime();
                //从界面获取记录信息
                clsTrackRecordContent objContent = m_objGetContentFromGUI();

                //界面输入值出错           
                if (objContent == null)
                    return -1;

                //设置 clsTrackRecordContent 的信息（使用服务器时间设置m_dtmModifyDate）	
                m_mthSetSubCreatedDateInfo(ref objContent, false);
                objContent.m_dtmOpenDate = m_objCurrentRecordContent.m_dtmOpenDate;
                objContent.m_strCreateUserID = m_objCurrentRecordContent.m_strCreateUserID;
                objContent.m_dtmCreateDate = m_objCurrentRecordContent.m_dtmCreateDate;

                #region 是否可以无痕迹修改
                if (chkModifyWithoutMatk.Checked)
                    objContent.m_intMarkStatus = 0;
                else
                    objContent.m_intMarkStatus = 1;
                #endregion
                //objContent.m_dtmModifyDate=DateTime.Parse(strTimeNow);
                ////设置已有记录的开始使用时间
                //objContent.m_bytIfConfirm=0;
                //objContent.m_bytStatus=0;
                //if ( this.Name != "frmICUNurseRecordContent")
                //{
                //    objContent.m_dtmCreateDate=m_dtpCreateDate.Value;
                //}
                //objContent.m_dtmInPatientDate=m_objCurrentPatient.m_DtmSelectedInDate;
                //objContent.m_strConfirmReason="";
                //objContent.m_strConfirmReasonXML="";
                //objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
                //objContent.m_strRegisterID = m_objCurrentRecordContent.m_strRegisterID;
                //objContent.m_strModifyUserID=MDIParent.OperatorID;




                #region 多签名时验证所有签名者
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strInPatientID.Trim() + "-" + objContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objCurrentPatient.m_StrRegisterId;

                //if (objContent.objSignerArr != null)//护理单签名不需要key验证 暂时
                if (objContent.objSignerArr != null &&
                    this.Name != "frmGeneralNurseRecord" &&
                    this.Name != "frmGeneralNurseRecord_GXCon" &&
                    this.Name != "frmGeneralNurseRecord_GXRec" &&
                    this.Name != "frmICUNurseRecord_GXCon" &&
                    this.Name != "frmIntensiveTend_GXContent" &&
                    this.Name != "frmIntensiveTend_GX" &&
                    this.Name != "frmVeinSpecialUseDrugCon" &&
                    this.Name != "frmIntakeAndOutputVolumeCon" &&
                    this.Name != "frmOXTIntravenousDripCon" &&
                    this.Name != "frmWaitLayRecord_AcadCon_GX" &&
                    this.Name != "frmVaginalExaminationRecord" &&
                    this.Name != "frmEMR_MicroBooldSugarCheckCon")
                {
                    ArrayList objSignerArr = new ArrayList();
                    for (int i = 0; i < objContent.objSignerArr.Length; i++)
                    {
                        if (objContent.objSignerArr[i].controlName == "lsvSign" || objContent.objSignerArr[i].controlName == "txtSign")
                            objSignerArr.Add(objContent.objSignerArr[i].objEmployee);
                    }
                    if (objContent.m_intMarkStatus == 0)
                    {
                        clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, true);
                        if (objCheck.CheckSigner(objContent, objSign_VO) == -1)
                            return -1;
                    }
                    else if (objContent.m_intMarkStatus != 0)
                    {
                        clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                        if (objCheck.CheckSigner(objContent, objSign_VO) == -1)
                            return -1;
                    }
                }
                else
                {
                    if (this.Name != "frmIntakeAndOutputVolumeCon" &&
                    this.Name != "frmOXTIntravenousDripCon" &&
                    this.Name != "frmWaitLayRecord_AcadCon_GX" &&
                    this.Name != "frmVaginalExaminationRecord" &&
                    this.Name != "frmEMR_MicroBooldSugarCheckCon")
                    {
                        objContent.m_strModifyUserID = MDIParent.OperatorID;
                    }
                    clsCheckSignersController objCheck = new clsCheckSignersController();
                    if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                        return -1;

                }
                #endregion

                //修改记录
                clsPreModifyInfo objModifyInfo = null;
                lngRes = m_objDiseaseTrackDomain.m_lngModifyRecord(m_objCurrentRecordContent, objContent, out objModifyInfo);

                //根据结果做不同的处理
                switch ((enmOperationResult)lngRes)
                {
                    case enmOperationResult.DB_Succeed:
                        m_objCurrentRecordContent = objContent;
                        m_dtmCreatedDate = objContent.m_dtmOpenDate;
                        if (objContent.m_intMarkStatus != 0 && chkModifyWithoutMatk.Visible)
                            chkModifyWithoutMatk.Visible = false;
                        break;
                    case enmOperationResult.DB_Fail:
                        clsPublicFunction.ShowInformationMessageBox("对不起,修改失败!");
                        break;
                    case enmOperationResult.Parameter_Error:
                        clsPublicFunction.ShowInformationMessageBox("参数错误!");
                        break;
                    case enmOperationResult.Record_Already_Modify:
                        if (objModifyInfo != null)
                            m_bolShowRecordModified(objModifyInfo.m_strActionUserID, objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        else m_mthShowDBError();
                        break;
                    case enmOperationResult.Record_Already_Delete:
                        if (objModifyInfo != null)
                            m_mthShowRecordDeleted(objModifyInfo.m_strActionUserID, objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
                        else m_mthShowDBError();
                        break;
                    //...
                }
            }
            catch (Exception ex)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(ex);
                MessageBox.Show(ex.Message, "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            //返回结果
            return lngRes;
        }

        #endregion

        #region 作废重做的数据库保存。
        /// <summary>
        /// 设置子窗体的创建时间基类时间等，为了适合用RegisterId与新业务要求用
        /// </summary>
        /// <param name="p_objContent"></param>
        protected virtual void m_mthSetSubCreatedDateInfo(ref clsTrackRecordContent p_objContent, bool p_blnIsAddNew)
        {
            if (p_objContent != null)
            {
                string strTimeNow = new clsPublicDomain().m_strGetServerTime();
                if (p_blnIsAddNew)
                {
                    p_objContent.m_dtmOpenDate = DateTime.Parse(strTimeNow);
                    if (this.Name != "frmICUNurseRecordContent" && this.Name != "frmOXTIntravenousDripCon"
                        && this.Name != "frmWaitLayRecord_AcadCon_GX" && this.Name != "frmIntakeAndOutputVolumeCon"
                        && this.Name != "frmIntakeAndOutputVolumeSummary" && this.Name != "frmEMR_MicroBooldSugarCheckCon")
                    {
                        p_objContent.m_dtmCreateDate = m_dtpCreateDate.Value;
                    }
                    if (this.Name != "frmVeinSpecialUseDrugCon" && this.Name != "frmICUNurseRecord_GXCon"
                        && this.Name != "frmGeneralNurseRecord_GXCon" && this.Name != "frmGeneralNurseRecord_GXRec"
                        && this.Name != "frmGeneralNurseRecord_CSCon" && this.Name != "frmGeneralNurseRecord_CSRec"
                        && this.Name != "frmGeneralNurseRecord" && this.Name != "frmIntensiveTend_GX"
                        && this.Name != "frmICUNurseRecordContent" && this.Name != "frmOXTIntravenousDripCon"
                        && this.Name != "frmWaitLayRecord_AcadCon_GX" && this.Name != "frmIntakeAndOutputVolumeCon"
                        && this.Name != "frmIntakeAndOutputVolumeSummary" && this.Name != "frmEMR_MicroBooldSugarCheckCon"
                        && this.Name != "frmOperationRequisition")
                    {
                        p_objContent.m_strCreateUserID = MDIParent.OperatorID;
                    }
                }
                p_objContent.m_dtmModifyDate = DateTime.Parse(strTimeNow);
                p_objContent.m_bytIfConfirm = 0;
                p_objContent.m_bytStatus = 0;
                p_objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
                p_objContent.m_strConfirmReason = "";
                p_objContent.m_strConfirmReasonXML = "";
                p_objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                p_objContent.m_strRegisterID = m_objCurrentPatient.m_StrRegisterId;
            }
        }
        /// <summary>
        /// 作废重做的数据库保存。
        /// </summary>
        /// <returns></returns>
        protected long m_lngReAddNew()
        {
            //检查当前病人变量是否为null
            if (m_objCurrentPatient == null)
            {
                m_mthShowNoPatient();
                return -1;
            }


            //获取服务器时间
            string strTimeNow = new clsPublicDomain().m_strGetServerTime();
            //从界面获取记录信息
            clsTrackRecordContent objContent = m_objGetContentFromGUI();

            //界面输入值出错           
            if (objContent == null)
                return -1;

            //设置 clsTrackRecordContent 的信息（使用服务器时间设置m_dtmOpenDate和m_dtmModifyDate）
            m_mthSetSubCreatedDateInfo(ref objContent, true);
            //objContent.m_strModifyUserID=MDIParent.OperatorID;

            //作废重做记录
            clsPreModifyInfo objModifyInfo = null;

            #region 多签名时验证所有签名者
            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strInPatientID.Trim() + "-" +  objContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_objCurrentPatient.m_StrRegisterId;
            if (objContent.objSignerArr != null)
            {
                ArrayList objSignerArr = new ArrayList();
                for (int i = 0; i < objContent.objSignerArr.Length; i++)
                {
                    if (objContent.objSignerArr[i].controlName == "lsvSign" || objContent.objSignerArr[i].controlName == "txtSign")
                        objSignerArr.Add(objContent.objSignerArr[i].objEmployee);
                }
                clsCheckSignersController objCheck = new clsCheckSignersController(objSignerArr, false);
                if (objCheck.CheckSigner(objContent, objSign_VO) == -1)
                    return -1;
            }
            else
            {
                objContent.m_strModifyUserID = MDIParent.OperatorID;
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                    return -1;

            }
            #endregion

            long lngRes = m_objDiseaseTrackDomain.m_lngReAddNewRecord(m_objReAddNewOld, objContent, out objModifyInfo);

            //根据结果做不同的处理
            switch ((enmOperationResult)lngRes)
            {
                case enmOperationResult.DB_Succeed:
                    m_objCurrentRecordContent = objContent;
                    m_dtmCreatedDate = objContent.m_dtmOpenDate;
                    m_objReAddNewOld = null;
                    break;
                case enmOperationResult.DB_Fail:
                    clsPublicFunction.ShowInformationMessageBox("对不起,修改失败!");
                    break;
                case enmOperationResult.Parameter_Error:
                    clsPublicFunction.ShowInformationMessageBox("参数错误!");
                    break;
                case enmOperationResult.Record_Already_Modify:
                    if (objModifyInfo != null)
                        m_bolShowRecordModified(objModifyInfo.m_strActionUserID, objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    else m_mthShowDBError();
                    break;
                case enmOperationResult.Record_Already_Delete:
                    if (objModifyInfo != null)
                        m_mthShowRecordDeleted(objModifyInfo.m_strActionUserID, objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    else m_mthShowDBError();
                    break;
                //...
            }

            //返回结果
            return lngRes;

        }
        #endregion

        #endregion

        #region 删除记录
        /// <summary>
        /// 重写获取记录创建者属性
        /// 返回指定记录创建者ID
        /// </summary>
        protected override string m_StrRecorder_ID
        {
            get
            {
                return m_objCurrentRecordContent.m_strCreateUserID.Trim();
            }
        }
        protected override long m_lngSubDelete()
        {
            //检查当前病人变量是否为null          
            if (m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
            {
                m_mthShowNoPatient();
                return -1;
            }
            //检查当前记录是否为null
            if (m_objCurrentRecordContent == null)
            {
                return -1;
            }

            //获取服务器时间      
            string strTimeNow = new clsPublicDomain().m_strGetServerTime();
            //设置 m_objCurrentRecordContent 的信息（使用服务器时间设置m_dtmDeActivedDate）
            m_objCurrentRecordContent.m_dtmDeActivedDate = DateTime.Parse(strTimeNow);
            m_objCurrentRecordContent.m_strDeActivedOperatorID = MDIParent.OperatorID;

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, m_objCurrentRecordContent.m_strCreateUserID, clsEMRLogin.LoginEmployee, intFormType);
            if (!blnIsAllow)
                return -1;

            //删除记录
            clsPreModifyInfo objModifyInfo = null;
            long lngRes = m_objDiseaseTrackDomain.m_lngDeleteRecord(m_objCurrentRecordContent, out objModifyInfo);

            //根据结果做不同的处理
            switch ((enmOperationResult)lngRes)
            {
                case enmOperationResult.DB_Succeed:
                    clsEMR_CaseAuditVO objAuditVO = m_objGetAuditCase();
                    objAuditVO.m_dtmCREATEDATE = m_objCurrentRecordContent.m_dtmOpenDate;
                    m_mthDelAuditCase(objAuditVO);

                    m_objCurrentRecordContent = null;
                    m_dtmCreatedDate = DateTime.Now;

                    m_blnCanTreeNodeAfterSelectEventTakePlace = false;
                    //删除选中节点 
                    m_trvCreateDate.SelectedNode.Remove();
                    //清空记录信息   
                    m_mthClearPatientRecordInfo();
                    //选中根节点
                    m_trvCreateDate.SelectedNode = m_trnRoot;
                    m_blnCanTreeNodeAfterSelectEventTakePlace = true;
                    break;
                case enmOperationResult.DB_Fail:
                    clsPublicFunction.ShowInformationMessageBox("对不起,删除失败!");
                    break;
                case enmOperationResult.Parameter_Error:
                    clsPublicFunction.ShowInformationMessageBox("参数错误!");
                    break;
                case enmOperationResult.Record_Already_Modify:
                    if (objModifyInfo != null)
                        m_bolShowRecordModified(objModifyInfo.m_strActionUserID, objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    else m_mthShowDBError();
                    break;
                case enmOperationResult.Record_Already_Delete:
                    if (objModifyInfo != null)
                        m_mthShowRecordDeleted(objModifyInfo.m_strActionUserID, objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
                    else m_mthShowDBError();
                    break;
            }

            //返回结果
            return lngRes;
        }

        #endregion

        #region ctlRichTextBox的双划线、其他属性设置
        /// <summary>
        /// 痕迹控制
        /// 当表单在可无痕迹修改时效内。通过控制chkModifyWithoutMatk来
        /// 达到控制是否有、无痕迹修改
        /// </summary>
        /// <returns></returns>
        protected override bool m_mthModifyWithoutMark()
        {

            bool blnRes = chkModifyWithoutMatk.Checked;
            if (chkModifyWithoutMatk.Checked == false)
            {

                //提示签名
                if (MessageBox.Show("如果要进行有痕迹修改，当前已做修改的数据将丢失，要继续？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    //重新load内容
                    m_blnIsModifyWithoutMark = false;
                    m_mthImplementset(m_objCurrentRecordContent);
                }
                else
                    blnRes = !blnRes;
            }
            else
            {
                //提示签名
                if (MessageBox.Show("如果要进行无痕迹修改，当前已做修改的数据将丢失，并需要逐一验证每个签名者，要继续？", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.OK)
                {
                    //重新load内容
                    m_blnIsModifyWithoutMark = true;
                    m_mthImplementset(m_objCurrentRecordContent);
                }
                else
                    blnRes = !blnRes;

            }
            return blnRes;

        }
        /// <summary>
        /// 设置双划线
        /// </summary>
        protected void m_mthSetRichTextBoxDoubleStrike()
        {
            //获取RichTextBox        
            //ctlRichTextBox objRichTextBox = (ctlRichTextBox)m_ctmRichTextBoxMenu.SourceControl;

            //objRichTextBox.m_mthSelectionDoubleStrikeThough(true);
            if (m_txtFocusedRichTextBox != null)
            {
                if (m_txtFocusedRichTextBox is com.digitalwave.Utility.Controls.ctlRichTextBox)
                    ((com.digitalwave.Utility.Controls.ctlRichTextBox)m_txtFocusedRichTextBox).m_mthSelectionDoubleStrikeThough(true);
                else if (m_txtFocusedRichTextBox is com.digitalwave.controls.ctlRichTextBox)
                    ((com.digitalwave.controls.ctlRichTextBox)m_txtFocusedRichTextBox).m_mthSelectionDoubleStrikeThough(true);
            }
        }

        /// <summary>
        /// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
        /// </summary>
        /// <param name="p_objRichTextBox"></param>
        protected void m_mthSetRichTextBoxAttrib(Control p_objRichTextBox)
        {
            if (p_objRichTextBox.GetType().FullName == "com.digitalwave.controls.ctlRichTextBox")
            {
                m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[] { (com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox });
                //设置右键菜单			
                //			p_objRichTextBox.ContextMenu=m_cmuRichTextBoxMenu;
                ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);

                //设置其他属性	
                if (this.Name == "frmGeneralNurseRecord"
                        || this.Name == "frmGeneralNurseRecord_GXRec"
                        || this.Name == "frmSubICUIntensiveTend"
                        || this.Name == "frmSubWatchItemRecord"
                        || this.Name == "frmSubICUBreath"
                        || this.Name == "frmPostPartum_AcadCon"
                        || this.Name == "frmIntensiveTend_GXContent"
                        || this.Name == "frmQuickeningTutelar_AcadCon"
                        || this.Name == "frmCardiovascularTend_GX"
                        || this.Name == "frmICUNurseRecord_GXCon"
                        || this.Name == "frmIntensiveTend"
                        || this.Name == "frmIntensiveTend_FC"
                        || this.Name == "frmIntensiveTend_FContent"
                        || this.Name == "frmIntensiveTend_GX"
                        || this.Name == "frmIntensiveTend_GXContent"
                        || this.Name == "frmSurgeryICUWardshipEdit"
                        || this.Name == "frmVeinSpecialUseDrugCon"
                        || this.Name == "frmWaitLayRecord_AcadCon"
                        || this.Name == "frmConsultation"
                        || this.Name == "frmDeathCaseDiscuss"
                        || this.Name == "frmDeathRecord"
                        || this.Name == "frmDeathRecordIn24Hours"
                        || this.Name == "frmEMR_OutHospitalIn24Hours"
                        || this.Name == "frmOutHospital")
                {
                    ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserID = clsEMRLogin.LoginEmployee.m_strEMPNO_CHR.Trim();
                    ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserName = clsEMRLogin.LoginEmployee.m_strLASTNAME_VCHR.Trim();


                }
                else
                {
                    ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserID = clsEMRLogin.LoginEmployee.m_strEMPID_CHR.Trim();
                    ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_StrUserName = clsEMRLogin.LoginEmployee.m_strLASTNAME_VCHR.Trim();

                }

                ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_ClrOldPartInsertText = Color.Black;
                ((com.digitalwave.controls.ctlRichTextBox)p_objRichTextBox).m_ClrDST = Color.Red;
            }
        }

        protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
        {
            if (p_ctlControl.GetType().FullName == "com.digitalwave.controls.ctlRichTextBox")
            {
                m_mthSetRichTextBoxAttrib((com.digitalwave.controls.ctlRichTextBox)p_ctlControl);
            }

            if (p_ctlControl.HasChildren && p_ctlControl.GetType().Name != "DataGrid")
            {
                foreach (Control subcontrol in p_ctlControl.Controls)
                {
                    m_mthSetRichTextBoxAttribInControl(subcontrol);
                }
            }
        }

        private void mniDoubleStrikeOutDelete_Click(object sender, System.EventArgs e)
        {
            m_mthSetRichTextBoxDoubleStrike();
        }
        private Control m_txtFocusedRichTextBox = null;//存放当前获得焦点的RichTextBox
        private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
        {
            m_txtFocusedRichTextBox = ((Control)(sender));
        }

        #endregion ctlRichTextBox的双划线、其他属性设置

        #region 麻醉、打印相关



        protected void m_mthSetFormViewStyle()
        {
            if (!MDIParent.s_bolIAnaSystem)
                return;

            this.BackColor = SystemColors.Control;
            this.ForeColor = SystemColors.ControlText;
            foreach (Control m_objControl in this.Controls)
            {
                m_mthSetControlViewStyle(m_objControl);

            }
        }

        protected void m_mthSetControlViewStyle(Control p_objControl)
        {
            //如果不是麻醉科登录则退出设置
            if (!MDIParent.s_bolIAnaSystem)
                return;

            switch (p_objControl.GetType().FullName)
            {
                case "Label":
                case "Button":
                case "CheckBox":
                case "RadioButton":
                case "GroupBox":
                case "TabControl":
                case "System.Windows.Forms.TabPage":
                    {
                        p_objControl.ForeColor = SystemColors.ControlText;
                        p_objControl.BackColor = SystemColors.Control;

                        break;

                    }

                case "System.Windows.Forms.TreeView":
                    {
                        p_objControl.ForeColor = SystemColors.ControlText;
                        p_objControl.BackColor = SystemColors.Info;

                        break;
                    }
                case "System.Windows.Forms.ListView":
                    {
                        p_objControl.ForeColor = SystemColors.ControlText;
                        p_objControl.BackColor = SystemColors.Info;

                        foreach (ListViewItem m_lvi in ((ListView)p_objControl).Items)
                        {
                            m_lvi.ForeColor = SystemColors.ControlText;
                            m_lvi.BackColor = SystemColors.Info;
                        }
                        break;
                    }

                case "com.digitalwave.Utility.Controls.ctlBorderTextBox":
                    {
                        ((ctlBorderTextBox)p_objControl).ForeColor = SystemColors.ControlText;
                        ((ctlBorderTextBox)p_objControl).BackColor = SystemColors.Info;
                        ((ctlBorderTextBox)p_objControl).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        ((ctlBorderTextBox)p_objControl).BorderColor = SystemColors.Control;

                        break;

                    }
                case "com.digitalwave.Utility.Controls.ctlTimePicker":
                    ((ctlTimePicker)p_objControl).ForeColor = SystemColors.ControlText;
                    ((ctlTimePicker)p_objControl).BackColor = SystemColors.Info;
                    ((ctlTimePicker)p_objControl).BorderColor = SystemColors.ControlText;
                    ((ctlTimePicker)p_objControl).DropButtonBackColor = SystemColors.Control;
                    ((ctlTimePicker)p_objControl).DropButtonForeColor = SystemColors.ControlText;
                    ((ctlTimePicker)p_objControl).TextBackColor = SystemColors.Info;
                    ((ctlTimePicker)p_objControl).TextForeColor = SystemColors.ControlText;

                    break;

                case "com.digitalwave.Utility.Controls.ctlComboBox":
                    {
                        ((ctlComboBox)p_objControl).ForeColor = SystemColors.ControlText;
                        ((ctlComboBox)p_objControl).BackColor = SystemColors.Info;
                        ((ctlComboBox)p_objControl).BorderColor = SystemColors.ControlText;
                        ((ctlComboBox)p_objControl).DropButtonBackColor = SystemColors.Control;
                        ((ctlComboBox)p_objControl).DropButtonForeColor = SystemColors.ControlText;

                        ((ctlComboBox)p_objControl).ListBackColor = SystemColors.Info;
                        ((ctlComboBox)p_objControl).ListForeColor = SystemColors.ControlText;
                        ((ctlComboBox)p_objControl).ListSelectedBackColor = SystemColors.Control;
                        ((ctlComboBox)p_objControl).ListSelectedForeColor = SystemColors.ControlText;
                        ((ctlComboBox)p_objControl).TextBackColor = SystemColors.Info;
                        ((ctlComboBox)p_objControl).TextForeColor = SystemColors.ControlText;


                        break;
                    }

                case "com.digitalwave.Utility.Controls.ctlRichTextBox":
                    {
                        ((ctlRichTextBox)p_objControl).ForeColor = SystemColors.ControlText;
                        ((ctlRichTextBox)p_objControl).BackColor = SystemColors.Info;
                        ((ctlRichTextBox)p_objControl).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        ((ctlRichTextBox)p_objControl).m_ClrOldPartInsertText = SystemColors.WindowText;
                        //					
                        break;
                    }

                case "com.digitalwave.controls.ctlRichTextBox":
                    {
                        ((com.digitalwave.controls.ctlRichTextBox)p_objControl).ForeColor = SystemColors.ControlText;
                        ((com.digitalwave.controls.ctlRichTextBox)p_objControl).BackColor = SystemColors.Info;
                        ((com.digitalwave.controls.ctlRichTextBox)p_objControl).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                        ((com.digitalwave.controls.ctlRichTextBox)p_objControl).m_ClrOldPartInsertText = SystemColors.WindowText;
                        //					
                        break;
                    }
                default:
                    {
                        p_objControl.ForeColor = SystemColors.ControlText;
                        p_objControl.BackColor = SystemColors.Control;
                        break;
                    }

            }

            foreach (Control m_ctlSub in p_objControl.Controls)
            {
                m_mthSetControlViewStyle(m_ctlSub);

            }

        }

        #region 打印
        private void m_pdtPintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_mthPrintPage(e);
        }

        private void m_pdtPintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_mthBeginPrint(e);
        }

        private void m_pdtPintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            m_mthEndPrint(e);
        }

        protected override long m_lngSubPrint()
        {
            //检查是否有打印内容，如果有，打印有内容报表，否则打印空报表——空报表不赋值。
            if (m_objCurrentRecordContent != null)
            {
                //检查内容是否最新，获取最新内容和首次打印时间   
                clsTrackRecordContent objNewTrackInfo;
                long lngRes = m_objDiseaseTrackDomain.m_lngGetPrintInfo(m_objCurrentRecordContent.m_strInPatientID, m_objCurrentRecordContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objCurrentRecordContent.m_dtmModifyDate, out objNewTrackInfo, out m_dtmFirstPrintDate, out m_blnIsFirstPrint);
                if (lngRes <= 0)
                    return lngRes;

                //如果以有内容是最新内容，把当前内容记录到objNewTrackInfo中
                if (objNewTrackInfo == null)
                {
                    objNewTrackInfo = m_objCurrentRecordContent;
                }

                //设置表单内容到打印中
                m_mthSetPrintContent(objNewTrackInfo, m_dtmFirstPrintDate);
            }

            //如果没有设置过打印变量，设置打印变量        
            if (!m_blnAlreadySetPrintTools)
            {
                m_mthInitPrintTool();
                m_blnAlreadySetPrintTools = true;
            }

            //开始打印
            m_mthStartPrint();

            return 1;
        }

        /// <summary>
        ///  设置打印内容。
        /// </summary>
        /// <param name="p_objContent"></param>
        protected virtual void m_mthSetPrintContent(clsTrackRecordContent p_objContent, DateTime p_dtmFirstPrintDate)
        {
            //缺省不做任何动作，子窗体重载以提供操作。
        }

        /// <summary>
        /// 初始化打印变量
        /// </summary>
        protected virtual void m_mthInitPrintTool()
        {
            //缺省不做任何动作，子窗体重载以提供操作
            //初始化内容包括所有打印使用到的变量：字体、画笔、画刷、打印类等。
        }

        /// <summary>
        /// 释放打印变量
        /// </summary>
        protected virtual void m_mthDisposePrintTools()
        {
            //缺省不做任何动作，子窗体重载以提供操作
            //释放内容包括打印使用到的字体、画笔、画刷等使用系统资源的变量。
        }

        /// <summary>
        /// 开始打印。
        /// </summary>
        protected virtual void m_mthStartPrint()
        {
            //缺省使用打印预览，子窗体重载提供新的实现
            if (m_blnDirectPrint)
            {
                m_pdcPrintDocument.Print();
            }
            else
            {
                PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
                ppdPrintPreview.Document = m_pdcPrintDocument;
                ppdPrintPreview.ShowDialog();
            }
        }

        /// <summary>
        /// 打印开始后，在打印页之前的操作
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        protected void m_mthBeginPrint(PrintEventArgs p_objPrintArg)
        {
            m_mthBeginPrintSub(p_objPrintArg);
        }

        /// <summary>
        /// 打印开始后，在打印页之前的操作
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        protected virtual void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
        {
            //缺省不做任何动作，子窗体重载以提供操作
        }

        /// <summary>
        /// 打印页
        /// </summary>
        /// <param name="p_objPrintPageArg"></param>
        protected void m_mthPrintPage(PrintPageEventArgs p_objPrintPageArg)
        {
            m_mthPrintPageSub(p_objPrintPageArg);
        }

        /// <summary>
        /// 打印页
        /// </summary>
        /// <param name="p_objPrintPageArg"></param>
        protected virtual void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
        {

        }

        /// <summary>
        /// 打印结束时的操作
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        protected void m_mthEndPrint(PrintEventArgs p_objPrintArg)
        {
            //如果打印成功，并且不是打印空报表，并且需要更新首次打印时间，更新首次打印时间。
            if (!p_objPrintArg.Cancel)
            {
                m_mthUpdateFirstPrintDate();
            }

            m_mthEndPrintSub(p_objPrintArg);
        }

        protected void m_mthUpdateFirstPrintDate()
        {
            if (m_objCurrentRecordContent != null && m_blnIsFirstPrint)
            {
                m_objDiseaseTrackDomain.m_lngUpdateFirstPrintDate(m_objCurrentRecordContent.m_strInPatientID, m_objCurrentRecordContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"), m_objCurrentRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss"), m_dtmFirstPrintDate);
                m_blnIsFirstPrint = false;
            }
        }

        /// <summary>
        /// 打印结束时的操作
        /// </summary>
        /// <param name="p_objPrintArg"></param>
        protected virtual void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
        {
            //由子窗体重载以提供操作
        }

        #endregion 打印

        // 显示已经删除的记录让用户选择，并把用户选择的内容重新整理为完全正确的内容，显示在界面。
        protected void m_mthLoadDeleteRecord()
        {
            //			frmSelectDeleteRecord frmSel = new frmSelectDeleteRecord(m_objDomain,m_objCurrentPatient,m_strReloadFormTitle(),MDIParent.OperatorID);
            //		
            //			if(frmSel.ShowDialog() == DialogResult.OK)
            //			{   
            //			
            //				clsTrackRecordContent objContent = frmSel.m_objGetDeleteRecord();              
            //			
            //				if(objContent == null)
            //					return;   
            //				         
            //				//提示会覆盖当前内容
            //				//如果用户不覆盖
            //				//return;
            //		              
            //				m_mthClearPatientRecordInfo();                     
            //			                             
            //				m_mthReAddNewRecord(objContent);
            //			}
        }

        // 获取选择已经删除记录的窗体标题
        public virtual string m_strReloadFormTitle()
        {
            //由子窗体重载实现
            return "";
        }

        protected virtual void m_trvCreateDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (m_blnCanTreeNodeAfterSelectEventTakePlace == false)
                return;

            m_mthRecordChangedToSave();

            m_mthClearPatientRecordInfo();



            if (m_trvCreateDate.SelectedNode == m_trnRoot)
            {
                m_mthSelectRootNode();
                if (m_objCurrentPatient != null)
                {
                    //设置病人当次住院的基本信息
                    m_mthOnlySetPatientInfo(m_objCurrentPatient);
                    //if (m_trvCreateDate.Nodes[0].Text != "记录时间")
                    //    m_objCurrentPatient.m_ObjPeopleInfo = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvCreateDate.Nodes[0].Nodes.Count - m_trvCreateDate.SelectedNode.Index - 1).m_ObjPeopleInfo;

                    m_mthSetDefaultValue(m_objCurrentPatient);
                }

                //当前处于新增记录状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
                chkModifyWithoutMatk.Visible = false;
                chkModifyWithoutMatk.Checked = true;
            }
            else if (m_trvCreateDate.SelectedNode.Tag != null)
            {
                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                if (!m_blnCanShowDiseaseTrack)
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                m_mthSetSelectedRecord(m_objCurrentPatient, m_trvCreateDate.SelectedNode.Tag.ToString());

                //当前处于修改记录状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);
            }

            m_mthAddFormStatusForClosingSave();
        }

        /// <summary>
        /// 当选择根节点时,设置特殊的默认值(若子窗体需要,则重载实现)
        /// </summary>
        protected virtual void m_mthSelectRootNode()
        {
        }

        /// <summary>
        /// 设置各种类型的默认值
        /// </summary>
        /// <param name="p_objPatient"></param>
        protected virtual void m_mthSetDefaultValue(clsPatient p_objPatient)
        {
            if (m_objCurrentPatient == null)
            {
                m_objCurrentPatient = p_objPatient;
            }
            m_mthSetSpecialPatientTemplateSet(m_objCurrentPatient);
            m_mthDataShare(m_objCurrentPatient);

            //默认值
            new clsDefaultValueTool(this, p_objPatient).m_mthSetDefaultValue();
        }

        //屏蔽归档提示
        protected override void m_mthPromtForArchiving(bool p_blnIfReadOnly, string p_strTimeRemaing)
        {
        }

        private void frmDiseaseTrackBase_Load(object sender, System.EventArgs e)
        {
            if (m_BlnNeedContextMenu)
                m_mthAddRichTemplateInContainer(this);
        }

        #region 判断当前用户是否连接GE仪器
        protected bool m_blnCurrApparatus()
        {
            string strGENo = "";
            bool blnIsExist = false;
            new clsBedGEMaintenanceDomain().m_mthGetBedGEinf(MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID, ref strGENo, ref blnIsExist);
            return blnIsExist;
        }
        #endregion 判断当前用户是否连接GE仪器

        #region 从监护仪获取数据
        /// <summary>
        /// 获取显示监护仪数据由子窗体实现具体显示功能
        /// </summary>
        protected virtual void GetData()
        {
        }

        #region 菲利普仪器数据
        protected void m_mthGetICUDataByTime(string p_strStartTime, out clsCMSData p_objCMSData, out clsVentilatorData p_objVentilatorData, string[] p_strTypeArry)
        {
            //病区ID用最后三位，不然会超过long的最大范围
            //string strLongBedID = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptID+m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID.Substring(4)+m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastRoomInfo.m_ObjRoom.m_StrRoomID+m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID;
            string strLongBedID = MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptID + MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID;
            strLongBedID = strLongBedID.PadRight(17, '0');
            //new clsICUDataUtil(MDIParent.s_ObjCurrentPatient.m_StrInPatientID,strLongBedID).m_mthGetICUDataByTime("",p_dtmStart,out p_objCMSData,out p_objVentilatorData);
            new clsICUDataUtil(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, strLongBedID).m_mthGetICUNumericParmatByTime(p_strStartTime, MDIParent.s_ObjCurrentPatient.m_DtmLastInDate.ToString(), out p_objCMSData, out p_objVentilatorData, p_strTypeArry);
        }
        #endregion 菲利普仪器数据

        #region 获取ICU GE数据
        protected void m_mthGetICUGEDataByTime(string p_strStart, out clsGECMSData p_objGECMSData)
        {
            p_objGECMSData = null;
            string strLongBedID = MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptID + MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID.Substring(4) + MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastRoomInfo.m_ObjRoom.m_StrRoomID + MDIParent.s_ObjCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedID;
            //			new clsICUDataUtil(MDIParent.s_ObjCurrentPatient.m_StrInPatientID,strLongBedID).m_mthGetICUGEDataByTime(MDIParent.s_ObjCurrentPatient.m_StrInPatientID,p_dtmStart,out p_objGECMSData);
            new clsICUDataUtil(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, strLongBedID).m_mthGetICUGEDataByTime(MDIParent.s_ObjCurrentPatient.m_StrInPatientID, p_strStart, MDIParent.s_ObjCurrentPatient.m_DtmLastInDate.ToString(), out p_objGECMSData);
        }
        #endregion 获取ICU GE数据

        #endregion 从监护仪获取数据

        protected virtual void m_mthSelectDeptOrArea(ref int p_intDetpIndex, ref int p_intAreaIndex, clsPatient p_objPatient)
        {
            p_intDetpIndex = -1;
            p_intAreaIndex = -1;

            for (int i = 0; i < m_cboDept.GetItemsCount(); i++)
            {
                if (((clsDepartment)m_cboDept.GetItem(i)).m_StrDeptID == p_objPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjDept.m_ObjDept.m_StrDeptID)
                {
                    p_intDetpIndex = i;
                    break;
                }
            }

            for (int i = 0; i < m_cboArea.GetItemsCount(); i++)
            {
                if (((clsInPatientArea)m_cboArea.GetItem(i)).m_StrAreaID == p_objPatient.m_ObjInBedInfo.m_ObjLastAreaInfo.m_ObjArea.m_StrAreaID)
                {
                    p_intAreaIndex = i;
                    break;
                }
            }

        }

        protected void m_mthThisAddRichTextInfo(Control p_ctlChild)
        {
            foreach (Control ctlChild in p_ctlChild.Controls)
            {
                m_mthAddRichTextInfo(ctlChild);

                if (ctlChild.HasChildren)
                {
                    m_mthThisAddRichTextInfo(ctlChild);
                }
            }
        }
        //protected override string m_StrRecorder_ID
        //{
        //    get
        //    {
        //        clsTrackRecordContent objContent = m_objGetRecordContent(m_objCurrentPatient, m_trvCreateDate.SelectedNode.Tag.ToString()); ;              
        //         return objContent.m_strCreateUserID;
        //    }
        //}
        #endregion

        
        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            m_objCurrentPatient = m_objBaseCurrentPatient;

            if (m_objCurrentPatient == null)
            {
                return;
            }

            m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
            m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;
            m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
            m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

            m_mthIsReadOnly();
            if (!m_blnCanShowRecordContent())
            {
                clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                return;
            }

            m_mthSetPatientFormInfo(m_objCurrentPatient);
            //获取病人记录列表
            string[] strCreateTimeListArr;
            string[] strOpenTimeListArr;
            m_mthGetTimeList(m_objCurrentPatient, out strCreateTimeListArr, out strOpenTimeListArr);
            //对时间节点进行倒序排序
            new clsSortTool().m_mthSortTreeNode(m_trnRoot, true);

            //设置TeeeView默认选择的节点
            m_mthSetNodeSelected();

            //展开树显示所有时间节点。
            m_trnRoot.Expand();
            if (m_blnIsAddNew || strOpenTimeListArr == null)
            {
                //设置病人当次住院的基本信息
                m_mthSetDefaultValue(m_objCurrentPatient);
                //当前处于新增记录状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.AddNew);
            }
            else
            {
                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                if (!m_blnCanShowDiseaseTrack)
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                m_mthSetSelectedRecord(m_objCurrentPatient, strCreateTimeListArr[0]);

                //当前处于修改记录状态
                MDIParent.m_mthChangeFormText(this, MDIParent.enmFormEditStatus.Modify);
            }
            m_mthAddFormStatusForClosingSave();

        }

        #region 删除记录查询
        /// <summary>
        /// 设置删除后的病程记录信息，并显示修改。
        /// </summary>
        /// <param name="p_objPatient"></param>
        /// <param name="p_dtmRecordTime"></param>
        public void m_mthSetDeletedDiseaseTrackInfo(clsPatient p_objPatient,
            DateTime p_dtmRecordTime)
        {
            //参数检查  
            if (p_objPatient == null)
                return;

            m_mthSetPatient(p_objPatient);

            //设置记录信息
            m_mthSetSelectedDeletedRecord(p_objPatient, p_dtmRecordTime.ToString("yyyy-MM-dd HH:mm:ss"));

            m_mthEnablePatientSelect(false);

            m_mthAddFormStatusForClosingSave();

            //			m_mthEnablePatientSelectSub(false);
        }
        /// <summary>
        /// 设置删除记录容到界面
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        /// <param name="p_strOpenDate"></param>
        protected virtual void m_mthSetSelectedDeletedRecord(clsPatient p_objSelectedPatient,
            string p_strOpenDate)
        {
            //检查参数
            if (p_objSelectedPatient == null || p_strOpenDate == null || p_strOpenDate == "")
                return;

            clsTrackRecordContent objContent;
            //获取记录
            //long lngRes = m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(p_objSelectedPatient.m_StrInPatientID,m_trvCreateDate.SelectedNode.Tag.ToString(),p_strOpenDate ,out objContent);
            long lngRes = m_objDiseaseTrackDomain.m_lngGetDeleteRecordContent(p_objSelectedPatient.m_StrInPatientID, p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"), p_strOpenDate, out objContent);

            if (lngRes <= 0 || objContent == null)
                return;


            //设置当前记录及记录时间 
            m_objCurrentPatient = p_objSelectedPatient;
            txtInPatientID.Text = this.m_objCurrentPatient.m_StrHISInPatientID;
            //			m_dtpCreateDate.Value=objContent.m_dtmCreateDate;

            //这一句如果不注释的话，m_BlnIsAddNew就会变成true了，那么就不是新添记录了
            //			m_objCurrentRecordContent=objContent;

            m_mthSetDeletedGUIFromContent(objContent);

            //			m_mthSetModifyControl(objContent,false);		

        }
        /// <summary>
        /// 设置整个窗体为只读,此时不需要保存提示
        /// </summary>
        public virtual void m_mthSetReadOnly()
        {
            MDIParent.s_ObjSaveCue.m_mthRemoveForm(this);
        }
        #endregion 删除记录查询
    }
}


