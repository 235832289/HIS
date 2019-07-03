namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmRecipeConfirm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSex = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCardno = new com.digitalwave.controls.clsCardTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvDetails = new System.Windows.Forms.DataGridView();
            this.colRecipeno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNAME = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colrecipedeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colpatientdeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.dgvRecipe = new System.Windows.Forms.DataGridView();
            this.colCheckED = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRepNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPatientID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coldeid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colstatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.comCancel = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.trvRecipe = new System.Windows.Forms.TreeView();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.txtSex);
            this.groupBox1.Controls.Add(this.btnConfirm);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtCardno);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(988, 56);
            this.groupBox1.TabIndex = 30;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(819, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(81, 31);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSex
            // 
            this.txtSex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSex.Location = new System.Drawing.Point(464, 20);
            this.txtSex.Name = "txtSex";
            this.txtSex.Size = new System.Drawing.Size(100, 21);
            this.txtSex.TabIndex = 6;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirm.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Location = new System.Drawing.Point(694, 16);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(81, 31);
            this.btnConfirm.TabIndex = 6;
            this.btnConfirm.Text = "确认";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // txtName
            // 
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Location = new System.Drawing.Point(281, 20);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(100, 21);
            this.txtName.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("楷体_GB2312", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(416, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "性别：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("楷体_GB2312", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(234, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "姓名：";
            // 
            // txtCardno
            // 
            this.txtCardno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCardno.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCardno.Location = new System.Drawing.Point(107, 20);
            this.txtCardno.MaxLength = 50;
            this.txtCardno.Name = "txtCardno";
            this.txtCardno.PatientCard = "";
            this.txtCardno.PatientFlag = 0;
            this.txtCardno.Size = new System.Drawing.Size(100, 21);
            this.txtCardno.TabIndex = 2;
            this.txtCardno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCardno.YBCardText = "";
            this.txtCardno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCardno_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("楷体_GB2312", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(55, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "卡号：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvDetails);
            this.groupBox2.Controls.Add(this.splitter2);
            this.groupBox2.Controls.Add(this.dgvRecipe);
            this.groupBox2.Controls.Add(this.splitter1);
            this.groupBox2.Controls.Add(this.trvRecipe);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Location = new System.Drawing.Point(0, 56);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(988, 497);
            this.groupBox2.TabIndex = 31;
            this.groupBox2.TabStop = false;
            // 
            // dgvDetails
            // 
            this.dgvDetails.AllowUserToAddRows = false;
            this.dgvDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRecipeno,
            this.colNAME,
            this.colDec,
            this.colItid,
            this.colCount,
            this.colPrice,
            this.colrecipedeid,
            this.colpatientdeid});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDetails.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvDetails.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.dgvDetails.Location = new System.Drawing.Point(561, 17);
            this.dgvDetails.MultiSelect = false;
            this.dgvDetails.Name = "dgvDetails";
            this.dgvDetails.ReadOnly = true;
            this.dgvDetails.RowHeadersVisible = false;
            this.dgvDetails.RowTemplate.Height = 23;
            this.dgvDetails.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetails.Size = new System.Drawing.Size(424, 477);
            this.dgvDetails.TabIndex = 5;
            // 
            // colRecipeno
            // 
            this.colRecipeno.HeaderText = "方号";
            this.colRecipeno.Name = "colRecipeno";
            this.colRecipeno.ReadOnly = true;
            this.colRecipeno.Visible = false;
            // 
            // colNAME
            // 
            this.colNAME.HeaderText = "项目名称";
            this.colNAME.Name = "colNAME";
            this.colNAME.ReadOnly = true;
            // 
            // colDec
            // 
            this.colDec.HeaderText = "规格";
            this.colDec.Name = "colDec";
            this.colDec.ReadOnly = true;
            // 
            // colItid
            // 
            this.colItid.HeaderText = "项目ID";
            this.colItid.Name = "colItid";
            this.colItid.ReadOnly = true;
            this.colItid.Visible = false;
            // 
            // colCount
            // 
            this.colCount.HeaderText = "数量";
            this.colCount.Name = "colCount";
            this.colCount.ReadOnly = true;
            // 
            // colPrice
            // 
            this.colPrice.HeaderText = "单价";
            this.colPrice.Name = "colPrice";
            this.colPrice.ReadOnly = true;
            // 
            // colrecipedeid
            // 
            this.colrecipedeid.HeaderText = "项目明细ID";
            this.colrecipedeid.Name = "colrecipedeid";
            this.colrecipedeid.ReadOnly = true;
            this.colrecipedeid.Visible = false;
            // 
            // colpatientdeid
            // 
            this.colpatientdeid.HeaderText = "父项目明细ID";
            this.colpatientdeid.Name = "colpatientdeid";
            this.colpatientdeid.ReadOnly = true;
            this.colpatientdeid.Visible = false;
            // 
            // splitter2
            // 
            this.splitter2.Location = new System.Drawing.Point(558, 17);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 477);
            this.splitter2.TabIndex = 4;
            this.splitter2.TabStop = false;
            // 
            // dgvRecipe
            // 
            this.dgvRecipe.AllowUserToAddRows = false;
            this.dgvRecipe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCheckED,
            this.colRepNo,
            this.colItemName,
            this.colItemID,
            this.colPatientID,
            this.colType,
            this.coldeid,
            this.colstatus});
            this.dgvRecipe.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecipe.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecipe.Dock = System.Windows.Forms.DockStyle.Left;
            this.dgvRecipe.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvRecipe.Location = new System.Drawing.Point(248, 17);
            this.dgvRecipe.MultiSelect = false;
            this.dgvRecipe.Name = "dgvRecipe";
            this.dgvRecipe.ReadOnly = true;
            this.dgvRecipe.RowHeadersVisible = false;
            this.dgvRecipe.RowTemplate.Height = 23;
            this.dgvRecipe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecipe.ShowCellErrors = false;
            this.dgvRecipe.ShowCellToolTips = false;
            this.dgvRecipe.ShowEditingIcon = false;
            this.dgvRecipe.ShowRowErrors = false;
            this.dgvRecipe.Size = new System.Drawing.Size(310, 477);
            this.dgvRecipe.TabIndex = 3;
            this.dgvRecipe.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecipe_CellContentClick);
            // 
            // colCheckED
            // 
            this.colCheckED.FalseValue = "F";
            this.colCheckED.HeaderText = "";
            this.colCheckED.Name = "colCheckED";
            this.colCheckED.ReadOnly = true;
            this.colCheckED.TrueValue = "T";
            this.colCheckED.Width = 20;
            // 
            // colRepNo
            // 
            this.colRepNo.HeaderText = "方号";
            this.colRepNo.Name = "colRepNo";
            this.colRepNo.ReadOnly = true;
            this.colRepNo.Visible = false;
            // 
            // colItemName
            // 
            this.colItemName.HeaderText = "项目名称";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 185;
            // 
            // colItemID
            // 
            this.colItemID.HeaderText = "项目ID";
            this.colItemID.Name = "colItemID";
            this.colItemID.ReadOnly = true;
            this.colItemID.Visible = false;
            // 
            // colPatientID
            // 
            this.colPatientID.HeaderText = "项目父ID";
            this.colPatientID.Name = "colPatientID";
            this.colPatientID.ReadOnly = true;
            this.colPatientID.Visible = false;
            // 
            // colType
            // 
            this.colType.HeaderText = "类型";
            this.colType.Name = "colType";
            this.colType.ReadOnly = true;
            this.colType.Visible = false;
            // 
            // coldeid
            // 
            this.coldeid.HeaderText = "明细ID";
            this.coldeid.Name = "coldeid";
            this.coldeid.ReadOnly = true;
            this.coldeid.Visible = false;
            // 
            // colstatus
            // 
            this.colstatus.HeaderText = "状态";
            this.colstatus.Name = "colstatus";
            this.colstatus.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comCancel});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // comCancel
            // 
            this.comCancel.Name = "comCancel";
            this.comCancel.Size = new System.Drawing.Size(152, 22);
            this.comCancel.Text = "取消确认";
            this.comCancel.Click += new System.EventHandler(this.comCancel_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(245, 17);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 477);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // trvRecipe
            // 
            this.trvRecipe.BackColor = System.Drawing.SystemColors.ControlLight;
            this.trvRecipe.Dock = System.Windows.Forms.DockStyle.Left;
            this.trvRecipe.Location = new System.Drawing.Point(3, 17);
            this.trvRecipe.Name = "trvRecipe";
            this.trvRecipe.Size = new System.Drawing.Size(242, 477);
            this.trvRecipe.TabIndex = 1;
            this.trvRecipe.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trvRecipe_AfterSelect);
            // 
            // frmRecipeConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(988, 553);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmRecipeConfirm";
            this.Text = "费用确认(检验、检查、手术申请单、材料等)";
            this.Load += new System.EventHandler(this.frmRecipeConfirm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipe)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Splitter splitter1;
        internal System.Windows.Forms.TreeView trvRecipe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal com.digitalwave.controls.clsCardTextBox txtCardno;
        internal System.Windows.Forms.TextBox txtSex;
        internal System.Windows.Forms.TextBox txtName;
        internal System.Windows.Forms.DataGridView dgvRecipe;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        internal System.Windows.Forms.DataGridView dgvDetails;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRecipeno;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNAME;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDec;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colrecipedeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colpatientdeid;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colCheckED;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPatientID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn coldeid;
        private System.Windows.Forms.DataGridViewTextBoxColumn colstatus;
        private System.Windows.Forms.ToolStripMenuItem comCancel;
        internal System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

    }
}