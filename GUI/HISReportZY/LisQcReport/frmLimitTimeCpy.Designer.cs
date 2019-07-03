namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmLimitTimeCpy
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnCpy = new PinkieControls.ButtonXP();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxGroup = new System.Windows.Forms.ComboBox();
            this.txtSearchName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvItem = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvCpyItem = new System.Windows.Forms.DataGridView();
            this.antiID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anti_cname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCpyItem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnCpy);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.cbxGroup);
            this.panel3.Controls.Add(this.txtSearchName);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(712, 76);
            this.panel3.TabIndex = 1;
            // 
            // btnCpy
            // 
            this.btnCpy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnCpy.DefaultScheme = true;
            this.btnCpy.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnCpy.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCpy.Hint = "";
            this.btnCpy.Location = new System.Drawing.Point(372, 28);
            this.btnCpy.Name = "btnCpy";
            this.btnCpy.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnCpy.Size = new System.Drawing.Size(324, 36);
            this.btnCpy.TabIndex = 175;
            this.btnCpy.Text = "复制";
            this.btnCpy.Click += new System.EventHandler(this.btnCpy_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 16;
            this.label5.Text = "专业组：";
            // 
            // cbxGroup
            // 
            this.cbxGroup.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxGroup.FormattingEnabled = true;
            this.cbxGroup.Items.AddRange(new object[] {
            ""});
            this.cbxGroup.Location = new System.Drawing.Point(88, 16);
            this.cbxGroup.Name = "cbxGroup";
            this.cbxGroup.Size = new System.Drawing.Size(200, 22);
            this.cbxGroup.TabIndex = 17;
            this.cbxGroup.SelectedIndexChanged += new System.EventHandler(this.cbxGroup_SelectedIndexChanged);
            // 
            // txtSearchName
            // 
            this.txtSearchName.Font = new System.Drawing.Font("宋体", 10.5F);
            this.txtSearchName.Location = new System.Drawing.Point(86, 48);
            this.txtSearchName.MaxLength = 50;
            this.txtSearchName.Name = "txtSearchName";
            this.txtSearchName.Size = new System.Drawing.Size(202, 23);
            this.txtSearchName.TabIndex = 6;
            this.txtSearchName.TextChanged += new System.EventHandler(this.txtSearchName_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F);
            this.label4.Location = new System.Drawing.Point(8, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 5;
            this.label4.Text = "名称检索:";
            // 
            // dgvItem
            // 
            this.dgvItem.AllowUserToAddRows = false;
            this.dgvItem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItem.Location = new System.Drawing.Point(0, 0);
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.ReadOnly = true;
            this.dgvItem.RowHeadersWidth = 25;
            this.dgvItem.RowTemplate.Height = 23;
            this.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvItem.Size = new System.Drawing.Size(372, 496);
            this.dgvItem.TabIndex = 3;
            this.dgvItem.DoubleClick += new System.EventHandler(this.dgvItem_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(372, 496);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvCpyItem);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(372, 76);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(340, 496);
            this.panel2.TabIndex = 5;
            // 
            // dgvCpyItem
            // 
            this.dgvCpyItem.AllowUserToAddRows = false;
            this.dgvCpyItem.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCpyItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCpyItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.antiID,
            this.anti_cname});
            this.dgvCpyItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCpyItem.Location = new System.Drawing.Point(0, 0);
            this.dgvCpyItem.Name = "dgvCpyItem";
            this.dgvCpyItem.ReadOnly = true;
            this.dgvCpyItem.RowHeadersVisible = false;
            this.dgvCpyItem.RowTemplate.Height = 23;
            this.dgvCpyItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCpyItem.Size = new System.Drawing.Size(340, 496);
            this.dgvCpyItem.TabIndex = 2;
            this.dgvCpyItem.DoubleClick += new System.EventHandler(this.dgvCpyItem_DoubleClick);
            this.dgvCpyItem.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCpyItem_CellMouseDoubleClick);
            // 
            // antiID
            // 
            this.antiID.HeaderText = "项目编码";
            this.antiID.Name = "antiID";
            this.antiID.ReadOnly = true;
            this.antiID.Width = 120;
            // 
            // anti_cname
            // 
            this.anti_cname.HeaderText = "项目名称";
            this.anti_cname.Name = "anti_cname";
            this.anti_cname.ReadOnly = true;
            this.anti_cname.Width = 200;
            // 
            // frmLimitTimeCpy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 572);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLimitTimeCpy";
            this.Text = "出报告时间复制";
            this.Load += new System.EventHandler(this.frm_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItem)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCpyItem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        internal System.Windows.Forms.ComboBox cbxGroup;
        internal System.Windows.Forms.TextBox txtSearchName;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.DataGridView dgvItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridView dgvCpyItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn antiID;
        private System.Windows.Forms.DataGridViewTextBoxColumn anti_cname;
        internal PinkieControls.ButtonXP btnCpy;
    }
}