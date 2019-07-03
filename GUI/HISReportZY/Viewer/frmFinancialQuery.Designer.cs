using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmFinancialQuery
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("财务分类");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("编码");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("项目名称");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("项目内涵");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("除外内容");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("计价单位");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("说明");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("省定价格");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("三档");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("二档");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("一档");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("市定价格", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("价格（元）", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode12});
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.btnSelect = new PinkieControls.ButtonXP();
            this.btnExport = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.treeView2 = new System.Windows.Forms.TreeView();
            this.multiColHeaderDgv2 = new com.digitalwave.iCare.gui.HIS.MultiColHeaderDgv();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFind);
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(939, 44);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(16, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 21;
            this.label1.Text = "查 询：";
            // 
            // txtFind
            // 
            this.txtFind.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtFind.Location = new System.Drawing.Point(104, 4);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(168, 29);
            this.txtFind.TabIndex = 20;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            this.txtFind.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFind_KeyPress);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSelect.DefaultScheme = true;
            this.btnSelect.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSelect.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSelect.Hint = "";
            this.btnSelect.Location = new System.Drawing.Point(292, 4);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSelect.Size = new System.Drawing.Size(76, 32);
            this.btnSelect.TabIndex = 16;
            this.btnSelect.Text = "检索(&S)";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.DefaultScheme = true;
            this.btnExport.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnExport.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExport.Hint = "";
            this.btnExport.Location = new System.Drawing.Point(752, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnExport.Size = new System.Drawing.Size(76, 32);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "导出(&E)";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(846, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(76, 32);
            this.btnClose.TabIndex = 19;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // treeView2
            // 
            this.treeView2.Location = new System.Drawing.Point(454, 26);
            this.treeView2.Name = "treeView2";
            treeNode1.Name = "Node0";
            treeNode1.Text = "财务分类";
            treeNode2.Name = "Node1";
            treeNode2.Text = "编码";
            treeNode3.Name = "Node3";
            treeNode3.Text = "项目名称";
            treeNode4.Name = "Node4";
            treeNode4.Text = "项目内涵";
            treeNode5.Name = "Node5";
            treeNode5.Text = "除外内容";
            treeNode6.Name = "Node6";
            treeNode6.Text = "计价单位";
            treeNode7.Name = "Node7";
            treeNode7.Text = "说明";
            treeNode8.Name = "Node9";
            treeNode8.Text = "省定价格";
            treeNode9.Name = "Node11";
            treeNode9.Text = "三档";
            treeNode10.Name = "Node12";
            treeNode10.Text = "二档";
            treeNode11.Name = "Node13";
            treeNode11.Text = "一档";
            treeNode12.Name = "Node10";
            treeNode12.Text = "市定价格";
            treeNode13.Name = "Node8";
            treeNode13.Text = "价格（元）";
            this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode13});
            this.treeView2.Size = new System.Drawing.Size(20, 202);
            this.treeView2.TabIndex = 3;
            this.treeView2.Visible = false;
            // 
            // multiColHeaderDgv2
            // 
            this.multiColHeaderDgv2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.multiColHeaderDgv2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.multiColHeaderDgv2.DefaultCellStyle = dataGridViewCellStyle1;
            this.multiColHeaderDgv2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.multiColHeaderDgv2.Location = new System.Drawing.Point(0, 44);
            this.multiColHeaderDgv2.myColHeaderTreeView = this.treeView2;
            this.multiColHeaderDgv2.Name = "multiColHeaderDgv2";
            this.multiColHeaderDgv2.RowHeadersWidth = 70;
            this.multiColHeaderDgv2.RowTemplate.Height = 23;
            this.multiColHeaderDgv2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.multiColHeaderDgv2.Size = new System.Drawing.Size(939, 509);
            this.multiColHeaderDgv2.TabIndex = 0;
            this.multiColHeaderDgv2.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.multiColHeaderDgv2_RowStateChanged);
            // 
            // frmFinancialQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 553);
            this.Controls.Add(this.multiColHeaderDgv2);
            this.Controls.Add(this.panel1);
            this.Name = "frmFinancialQuery";
            this.Text = "项目价格查询";
            this.Load += new System.EventHandler(this.frmFinancialQuery_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.multiColHeaderDgv2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        internal PinkieControls.ButtonXP btnSelect;
        internal PinkieControls.ButtonXP btnExport;
        internal PinkieControls.ButtonXP btnClose;
        private com.digitalwave.iCare.gui.HIS.MultiColHeaderDgv multiColHeaderDgv2;
        private System.Windows.Forms.TreeView treeView2;
        private Label label1;
        private TextBox txtFind;
    }
}