namespace com.digitalwave.iCare.gui.LIS
{
    partial class frmInputGroupBaseInfo
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
            this.trvList = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlGroupInfo = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkStopUse = new System.Windows.Forms.CheckBox();
            this.txtSummary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtASCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWBCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPYCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtGroupID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnRemoveItem = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.lsvGroupItem = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.lsvApplyUnitItem = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlGroupInfo.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trvList
            // 
            this.trvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.trvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvList.HideSelection = false;
            this.trvList.Location = new System.Drawing.Point(0, 0);
            this.trvList.Name = "trvList";
            this.trvList.Size = new System.Drawing.Size(233, 311);
            this.trvList.TabIndex = 0;
            this.trvList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvList_AfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnDelete);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 315);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(893, 73);
            this.panel1.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(680, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 36);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(588, 16);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(86, 36);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "删除";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Visible = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Location = new System.Drawing.Point(496, 16);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(86, 36);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "新增";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Visible = false;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlGroupInfo);
            this.splitContainer1.Size = new System.Drawing.Size(893, 315);
            this.splitContainer1.SplitterDistance = 237;
            this.splitContainer1.TabIndex = 2;
            // 
            // pnlGroupInfo
            // 
            this.pnlGroupInfo.Controls.Add(this.groupBox1);
            this.pnlGroupInfo.Controls.Add(this.btnDown);
            this.pnlGroupInfo.Controls.Add(this.btnUp);
            this.pnlGroupInfo.Controls.Add(this.btnRemoveItem);
            this.pnlGroupInfo.Controls.Add(this.btnAddItem);
            this.pnlGroupInfo.Controls.Add(this.lsvGroupItem);
            this.pnlGroupInfo.Controls.Add(this.lsvApplyUnitItem);
            this.pnlGroupInfo.Controls.Add(this.label7);
            this.pnlGroupInfo.Controls.Add(this.label8);
            this.pnlGroupInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGroupInfo.Location = new System.Drawing.Point(0, 0);
            this.pnlGroupInfo.Name = "pnlGroupInfo";
            this.pnlGroupInfo.Size = new System.Drawing.Size(648, 311);
            this.pnlGroupInfo.TabIndex = 1;
            this.pnlGroupInfo.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkStopUse);
            this.groupBox1.Controls.Add(this.txtSummary);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtASCode);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtWBCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPYCode);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtGroupName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtGroupID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Location = new System.Drawing.Point(8, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 128);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "录入组合基本信息";
            // 
            // chkStopUse
            // 
            this.chkStopUse.AutoSize = true;
            this.chkStopUse.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkStopUse.Location = new System.Drawing.Point(428, 33);
            this.chkStopUse.Name = "chkStopUse";
            this.chkStopUse.Size = new System.Drawing.Size(68, 18);
            this.chkStopUse.TabIndex = 12;
            this.chkStopUse.Text = "停  用";
            this.chkStopUse.UseVisualStyleBackColor = true;
            // 
            // txtSummary
            // 
            this.txtSummary.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtSummary.Location = new System.Drawing.Point(77, 88);
            this.txtSummary.MaxLength = 100;
            this.txtSummary.Name = "txtSummary";
            this.txtSummary.Size = new System.Drawing.Size(506, 23);
            this.txtSummary.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "备注";
            // 
            // txtASCode
            // 
            this.txtASCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtASCode.Location = new System.Drawing.Point(483, 59);
            this.txtASCode.MaxLength = 20;
            this.txtASCode.Name = "txtASCode";
            this.txtASCode.Size = new System.Drawing.Size(100, 23);
            this.txtASCode.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(428, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "助记码";
            // 
            // txtWBCode
            // 
            this.txtWBCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtWBCode.Location = new System.Drawing.Point(272, 59);
            this.txtWBCode.MaxLength = 20;
            this.txtWBCode.Name = "txtWBCode";
            this.txtWBCode.Size = new System.Drawing.Size(141, 23);
            this.txtWBCode.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "五笔码";
            // 
            // txtPYCode
            // 
            this.txtPYCode.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtPYCode.Location = new System.Drawing.Point(77, 59);
            this.txtPYCode.MaxLength = 20;
            this.txtPYCode.Name = "txtPYCode";
            this.txtPYCode.Size = new System.Drawing.Size(100, 23);
            this.txtPYCode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "拼音码";
            // 
            // txtGroupName
            // 
            this.txtGroupName.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtGroupName.Location = new System.Drawing.Point(272, 32);
            this.txtGroupName.MaxLength = 25;
            this.txtGroupName.Name = "txtGroupName";
            this.txtGroupName.Size = new System.Drawing.Size(141, 23);
            this.txtGroupName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(205, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "组合名称";
            // 
            // txtGroupID
            // 
            this.txtGroupID.Location = new System.Drawing.Point(77, 32);
            this.txtGroupID.Name = "txtGroupID";
            this.txtGroupID.ReadOnly = true;
            this.txtGroupID.Size = new System.Drawing.Size(100, 23);
            this.txtGroupID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "组合ID";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(412, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 13;
            this.label9.Text = "*";
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(559, 250);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(29, 57);
            this.btnDown.TabIndex = 8;
            this.btnDown.Text = "∨";
            this.btnDown.UseVisualStyleBackColor = true;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(559, 187);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(29, 57);
            this.btnUp.TabIndex = 7;
            this.btnUp.Text = "∧";
            this.btnUp.UseVisualStyleBackColor = true;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnRemoveItem
            // 
            this.btnRemoveItem.Location = new System.Drawing.Point(251, 250);
            this.btnRemoveItem.Name = "btnRemoveItem";
            this.btnRemoveItem.Size = new System.Drawing.Size(61, 23);
            this.btnRemoveItem.TabIndex = 6;
            this.btnRemoveItem.Text = "<<";
            this.btnRemoveItem.UseVisualStyleBackColor = true;
            this.btnRemoveItem.Click += new System.EventHandler(this.btnRemoveItem_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(251, 221);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(61, 23);
            this.btnAddItem.TabIndex = 5;
            this.btnAddItem.Text = ">>";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lsvGroupItem
            // 
            this.lsvGroupItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lsvGroupItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4});
            this.lsvGroupItem.FullRowSelect = true;
            this.lsvGroupItem.GridLines = true;
            this.lsvGroupItem.HideSelection = false;
            this.lsvGroupItem.Location = new System.Drawing.Point(318, 176);
            this.lsvGroupItem.MultiSelect = false;
            this.lsvGroupItem.Name = "lsvGroupItem";
            this.lsvGroupItem.Size = new System.Drawing.Size(235, 123);
            this.lsvGroupItem.TabIndex = 3;
            this.lsvGroupItem.UseCompatibleStateImageBehavior = false;
            this.lsvGroupItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "项目ID";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "项目名称";
            this.columnHeader4.Width = 156;
            // 
            // lsvApplyUnitItem
            // 
            this.lsvApplyUnitItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lsvApplyUnitItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvApplyUnitItem.FullRowSelect = true;
            this.lsvApplyUnitItem.GridLines = true;
            this.lsvApplyUnitItem.HideSelection = false;
            this.lsvApplyUnitItem.Location = new System.Drawing.Point(5, 177);
            this.lsvApplyUnitItem.Name = "lsvApplyUnitItem";
            this.lsvApplyUnitItem.Size = new System.Drawing.Size(240, 122);
            this.lsvApplyUnitItem.TabIndex = 1;
            this.lsvApplyUnitItem.UseCompatibleStateImageBehavior = false;
            this.lsvApplyUnitItem.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "项目ID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 162;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(5, 159);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(91, 14);
            this.label7.TabIndex = 2;
            this.label7.Text = "可用项目列表";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(315, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 14);
            this.label8.TabIndex = 4;
            this.label8.Text = "录入组合明细列表";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(771, 16);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(86, 36);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "关闭(&C)";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // frmInputGroupBaseInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 388);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "frmInputGroupBaseInfo";
            this.Text = "录入组合维护";
            this.Load += new System.EventHandler(this.frmInputGroupBaseInfo_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.pnlGroupInfo.ResumeLayout(false);
            this.pnlGroupInfo.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trvList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel pnlGroupInfo;
        private System.Windows.Forms.TextBox txtGroupID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPYCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGroupName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkStopUse;
        private System.Windows.Forms.TextBox txtSummary;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtASCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWBCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListView lsvGroupItem;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListView lsvApplyUnitItem;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnRemoveItem;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnExit;
    }
}