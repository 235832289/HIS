namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmMedicineCryReport
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMedicineCryReport));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "全部",
            ""}, -1);
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_close = new System.Windows.Forms.Button();
            this.m_btnFind = new System.Windows.Forms.Button();
            this.m_ctlTBFindItem = new com.digitalwave.controls.ctlTextBoxFind();
            this.m_lsv = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.m_dtmEnd = new System.Windows.Forms.DateTimePicker();
            this.m_dtmStart = new System.Windows.Forms.DateTimePicker();
            this.m_cboState = new System.Windows.Forms.ComboBox();
            this.m_cboAsc = new System.Windows.Forms.ComboBox();
            this.m_cbocol = new System.Windows.Forms.ComboBox();
            this.m_cboRptSel = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.collapsibleSplitter1 = new com.digitalwave.Utility.Controls.CollapsibleSplitter();
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.m_close);
            this.panel1.Controls.Add(this.m_btnFind);
            this.panel1.Controls.Add(this.m_ctlTBFindItem);
            this.panel1.Controls.Add(this.m_lsv);
            this.panel1.Controls.Add(this.m_dtmEnd);
            this.panel1.Controls.Add(this.m_dtmStart);
            this.panel1.Controls.Add(this.m_cboState);
            this.panel1.Controls.Add(this.m_cboAsc);
            this.panel1.Controls.Add(this.m_cbocol);
            this.panel1.Controls.Add(this.m_cboRptSel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(139, 531);
            this.panel1.TabIndex = 0;
            // 
            // m_close
            // 
            this.m_close.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_close.FlatAppearance.BorderSize = 0;
            this.m_close.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_close.Image = ((System.Drawing.Image)(resources.GetObject("m_close.Image")));
            this.m_close.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_close.Location = new System.Drawing.Point(33, 500);
            this.m_close.Name = "m_close";
            this.m_close.Size = new System.Drawing.Size(71, 22);
            this.m_close.TabIndex = 16;
            this.m_close.Text = "  退出";
            this.m_close.UseVisualStyleBackColor = true;
            this.m_close.Click += new System.EventHandler(this.m_close_Click);
            // 
            // m_btnFind
            // 
            this.m_btnFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnFind.FlatAppearance.BorderSize = 0;
            this.m_btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnFind.Image = ((System.Drawing.Image)(resources.GetObject("m_btnFind.Image")));
            this.m_btnFind.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_btnFind.Location = new System.Drawing.Point(33, 471);
            this.m_btnFind.Name = "m_btnFind";
            this.m_btnFind.Size = new System.Drawing.Size(71, 22);
            this.m_btnFind.TabIndex = 15;
            this.m_btnFind.Text = "  查询";
            this.toolTip1.SetToolTip(this.m_btnFind, "查询");
            this.m_btnFind.UseVisualStyleBackColor = true;
            this.m_btnFind.Click += new System.EventHandler(this.m_btnFind_Click);
            // 
            // m_ctlTBFindItem
            // 
            this.m_ctlTBFindItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_ctlTBFindItem.intHeight = 150;
            this.m_ctlTBFindItem.IsEnterShow = false;
            this.m_ctlTBFindItem.isHide = 4;
            this.m_ctlTBFindItem.isTxt = 1;
            this.m_ctlTBFindItem.isUpOrDn = 0;
            this.m_ctlTBFindItem.isValuse = 4;
            this.m_ctlTBFindItem.Location = new System.Drawing.Point(9, 441);
            this.m_ctlTBFindItem.m_IsHaveParent = false;
            this.m_ctlTBFindItem.m_strParentName = "";
            this.m_ctlTBFindItem.Name = "m_ctlTBFindItem";
            this.m_ctlTBFindItem.nextCtl = this.m_btnFind;
            this.m_ctlTBFindItem.Size = new System.Drawing.Size(121, 22);
            this.m_ctlTBFindItem.TabIndex = 14;
            this.toolTip1.SetToolTip(this.m_ctlTBFindItem, "选择单个项目进行统计");
            this.m_ctlTBFindItem.txtValuse = "";
            this.m_ctlTBFindItem.VsLeftOrRight = 1;
            // 
            // m_lsv
            // 
            this.m_lsv.CheckBoxes = true;
            this.m_lsv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.m_lsv.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.m_lsv.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.m_lsv.Location = new System.Drawing.Point(9, 153);
            this.m_lsv.Name = "m_lsv";
            this.m_lsv.Size = new System.Drawing.Size(121, 145);
            this.m_lsv.TabIndex = 8;
            this.toolTip1.SetToolTip(this.m_lsv, "请选择统计的药房");
            this.m_lsv.UseCompatibleStateImageBehavior = false;
            this.m_lsv.View = System.Windows.Forms.View.Details;
            this.m_lsv.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.m_lsv_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "　　药房选择";
            this.columnHeader1.Width = 116;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ID";
            this.columnHeader2.Width = 0;
            // 
            // m_dtmEnd
            // 
            this.m_dtmEnd.Location = new System.Drawing.Point(9, 125);
            this.m_dtmEnd.Name = "m_dtmEnd";
            this.m_dtmEnd.Size = new System.Drawing.Size(121, 23);
            this.m_dtmEnd.TabIndex = 5;
            this.toolTip1.SetToolTip(this.m_dtmEnd, "统计结束时间");
            // 
            // m_dtmStart
            // 
            this.m_dtmStart.Location = new System.Drawing.Point(9, 83);
            this.m_dtmStart.Name = "m_dtmStart";
            this.m_dtmStart.Size = new System.Drawing.Size(121, 23);
            this.m_dtmStart.TabIndex = 3;
            this.toolTip1.SetToolTip(this.m_dtmStart, "统计开始时间");
            // 
            // m_cboState
            // 
            this.m_cboState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboState.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cboState.FormattingEnabled = true;
            this.m_cboState.Items.AddRange(new object[] {
            "全部",
            "未配",
            "已配",
            "已发"});
            this.m_cboState.Location = new System.Drawing.Point(9, 319);
            this.m_cboState.Name = "m_cboState";
            this.m_cboState.Size = new System.Drawing.Size(121, 22);
            this.m_cboState.TabIndex = 7;
            this.toolTip1.SetToolTip(this.m_cboState, "状态（包括未配，已配，已发以及全部）");
            // 
            // m_cboAsc
            // 
            this.m_cboAsc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboAsc.FormattingEnabled = true;
            this.m_cboAsc.Items.AddRange(new object[] {
            "升序",
            "降序"});
            this.m_cboAsc.Location = new System.Drawing.Point(9, 404);
            this.m_cboAsc.Name = "m_cboAsc";
            this.m_cboAsc.Size = new System.Drawing.Size(122, 22);
            this.m_cboAsc.TabIndex = 12;
            this.toolTip1.SetToolTip(this.m_cboAsc, "升序降序选择");
            // 
            // m_cbocol
            // 
            this.m_cbocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cbocol.FormattingEnabled = true;
            this.m_cbocol.Items.AddRange(new object[] {
            "药房药品发放明细清单",
            "药房药品发放汇总清单",
            "综合材料发放明细清单",
            "综合材料发放汇总清单"});
            this.m_cbocol.Location = new System.Drawing.Point(9, 367);
            this.m_cbocol.Name = "m_cbocol";
            this.m_cbocol.Size = new System.Drawing.Size(123, 22);
            this.m_cbocol.TabIndex = 10;
            this.toolTip1.SetToolTip(this.m_cbocol, "选择对报表的某列进行升降排序");
            // 
            // m_cboRptSel
            // 
            this.m_cboRptSel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboRptSel.FormattingEnabled = true;
            this.m_cboRptSel.Items.AddRange(new object[] {
            "药房药品发放明细清单",
            "药房药品发放汇总清单",
            "综合材料发放明细清单",
            "综合材料发放汇总清单"});
            this.m_cboRptSel.Location = new System.Drawing.Point(9, 37);
            this.m_cboRptSel.Name = "m_cboRptSel";
            this.m_cboRptSel.Size = new System.Drawing.Size(121, 22);
            this.m_cboRptSel.TabIndex = 1;
            this.toolTip1.SetToolTip(this.m_cboRptSel, "请选择要统计的报表类型\r\n");
            this.m_cboRptSel.SelectedIndexChanged += new System.EventHandler(this.m_cboRptSel_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "至";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 427);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 13;
            this.label5.Text = "单项目统计";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(33, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 11;
            this.label7.Text = "排序方式";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 304);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "状态选择";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 14);
            this.label6.TabIndex = 9;
            this.label6.Text = "排序列选择";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "统计时间";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "报表选择";
            // 
            // collapsibleSplitter1
            // 
            this.collapsibleSplitter1.AnimationDelay = 20;
            this.collapsibleSplitter1.AnimationStep = 20;
            this.collapsibleSplitter1.BorderStyle3D = System.Windows.Forms.Border3DStyle.Flat;
            this.collapsibleSplitter1.ControlToHide = null;
            this.collapsibleSplitter1.ExpandParentForm = false;
            this.collapsibleSplitter1.Location = new System.Drawing.Point(139, 0);
            this.collapsibleSplitter1.Name = "collapsibleSplitter1";
            this.collapsibleSplitter1.Size = new System.Drawing.Size(8, 531);
            this.collapsibleSplitter1.TabIndex = 3;
            this.collapsibleSplitter1.TabStop = false;
            this.toolTip1.SetToolTip(this.collapsibleSplitter1, "收缩查询面板");
            this.collapsibleSplitter1.UseAnimations = false;
            this.collapsibleSplitter1.VisualStyle = com.digitalwave.Utility.Controls.VisualStyles.Mozilla;
            this.collapsibleSplitter1.Click += new System.EventHandler(this.collapsibleSplitter1_Click);
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.DisplayGroupTree = false;
            this.crystalReportViewer1.DisplayStatusBar = false;
            this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalReportViewer1.Location = new System.Drawing.Point(147, 0);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.SelectionFormula = "";
            this.crystalReportViewer1.Size = new System.Drawing.Size(881, 531);
            this.crystalReportViewer1.TabIndex = 1;
            this.toolTip1.SetToolTip(this.crystalReportViewer1, "报表的预览");
            this.crystalReportViewer1.ViewTimeSelectionFormula = "";
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "提示";
            // 
            // frmMedicineCryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_close;
            this.ClientSize = new System.Drawing.Size(1028, 531);
            this.Controls.Add(this.crystalReportViewer1);
            this.Controls.Add(this.collapsibleSplitter1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMedicineCryReport";
            this.Text = "门诊药房统计报表";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMedicineCryReport_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private com.digitalwave.Utility.Controls.CollapsibleSplitter collapsibleSplitter1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox m_cboRptSel;
        private System.Windows.Forms.DateTimePicker m_dtmStart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker m_dtmEnd;
        private System.Windows.Forms.ComboBox m_cboState;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView m_lsv;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private com.digitalwave.controls.ctlTextBoxFind m_ctlTBFindItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox m_cbocol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button m_btnFind;
        private System.Windows.Forms.ComboBox m_cboAsc;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button m_close;
    }
}