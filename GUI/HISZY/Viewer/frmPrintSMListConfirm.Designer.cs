namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmPrintSMListConfirm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOprName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAneMode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnConfirm = new PinkieControls.ButtonXP();
            this.btnSave = new PinkieControls.ButtonXP();
            this.label2 = new System.Windows.Forms.Label();
            this.txtANATime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gdvChargeItems = new System.Windows.Forms.DataGridView();
            this.checkBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.chargeItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.spec = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdvChargeItems)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "手术名称:";
            // 
            // txtOprName
            // 
            this.txtOprName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtOprName.Location = new System.Drawing.Point(82, 6);
            this.txtOprName.MaxLength = 300;
            this.txtOprName.Name = "txtOprName";
            this.txtOprName.Size = new System.Drawing.Size(527, 23);
            this.txtOprName.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 6;
            this.label5.Text = "麻醉方法:";
            // 
            // txtAneMode
            // 
            this.txtAneMode.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAneMode.Location = new System.Drawing.Point(82, 34);
            this.txtAneMode.MaxLength = 150;
            this.txtAneMode.Name = "txtAneMode";
            this.txtAneMode.Size = new System.Drawing.Size(258, 23);
            this.txtAneMode.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(403, 39);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "麻醉时间:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnConfirm.DefaultScheme = true;
            this.btnConfirm.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnConfirm.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConfirm.Hint = "";
            this.btnConfirm.Location = new System.Drawing.Point(515, 510);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnConfirm.Size = new System.Drawing.Size(70, 30);
            this.btnConfirm.TabIndex = 10;
            this.btnConfirm.Text = "退出";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.btnSave.DefaultScheme = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Hint = "";
            this.btnSave.Location = new System.Drawing.Point(403, 510);
            this.btnSave.Name = "btnSave";
            this.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSave.Size = new System.Drawing.Size(70, 30);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "确认";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(550, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "小时";
            // 
            // txtANATime
            // 
            this.txtANATime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtANATime.Location = new System.Drawing.Point(479, 34);
            this.txtANATime.MaxLength = 150;
            this.txtANATime.Name = "txtANATime";
            this.txtANATime.Size = new System.Drawing.Size(65, 23);
            this.txtANATime.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gdvChargeItems);
            this.groupBox1.Location = new System.Drawing.Point(9, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(600, 435);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择需要打印的费用";
            // 
            // gdvChargeItems
            // 
            this.gdvChargeItems.AllowUserToAddRows = false;
            this.gdvChargeItems.AllowUserToDeleteRows = false;
            this.gdvChargeItems.AllowUserToResizeRows = false;
            this.gdvChargeItems.BackgroundColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gdvChargeItems.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.gdvChargeItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.gdvChargeItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkBox,
            this.chargeItem,
            this.spec,
            this.amount,
            this.unit,
            this.price,
            this.usage});
            this.gdvChargeItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdvChargeItems.Location = new System.Drawing.Point(3, 17);
            this.gdvChargeItems.Name = "gdvChargeItems";
            this.gdvChargeItems.ReadOnly = true;
            this.gdvChargeItems.RowHeadersVisible = false;
            this.gdvChargeItems.RowTemplate.Height = 23;
            this.gdvChargeItems.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gdvChargeItems.Size = new System.Drawing.Size(594, 415);
            this.gdvChargeItems.TabIndex = 0;
            this.gdvChargeItems.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gdvChargeItems_CellClick);
            // 
            // checkBox
            // 
            this.checkBox.FalseValue = "0";
            this.checkBox.HeaderText = "选择";
            this.checkBox.Name = "checkBox";
            this.checkBox.ReadOnly = true;
            this.checkBox.TrueValue = "1";
            this.checkBox.Width = 40;
            // 
            // chargeItem
            // 
            this.chargeItem.HeaderText = "项目";
            this.chargeItem.Name = "chargeItem";
            this.chargeItem.ReadOnly = true;
            this.chargeItem.Width = 200;
            // 
            // spec
            // 
            this.spec.HeaderText = "规格";
            this.spec.Name = "spec";
            this.spec.ReadOnly = true;
            this.spec.Width = 80;
            // 
            // amount
            // 
            this.amount.HeaderText = "数量";
            this.amount.Name = "amount";
            this.amount.ReadOnly = true;
            this.amount.Width = 60;
            // 
            // unit
            // 
            this.unit.HeaderText = "单位";
            this.unit.Name = "unit";
            this.unit.ReadOnly = true;
            this.unit.Width = 50;
            // 
            // price
            // 
            this.price.HeaderText = "金额";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 80;
            // 
            // usage
            // 
            this.usage.HeaderText = "用法";
            this.usage.Name = "usage";
            this.usage.ReadOnly = true;
            this.usage.Width = 57;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox1.Location = new System.Drawing.Point(22, 510);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 18);
            this.checkBox1.TabIndex = 15;
            this.checkBox1.Text = "全选";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // frmPrintSMListConfirm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 550);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.txtOprName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtANATime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtAneMode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.Name = "frmPrintSMListConfirm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "手麻打印信息确认";
            this.Load += new System.EventHandler(this.frmPrintSMListConfirm_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdvChargeItems)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.TextBox txtOprName;
        internal System.Windows.Forms.TextBox txtAneMode;
        internal PinkieControls.ButtonXP btnConfirm;
        internal PinkieControls.ButtonXP btnSave;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.TextBox txtANATime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView gdvChargeItems;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn chargeItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn spec;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount;
        private System.Windows.Forms.DataGridViewTextBoxColumn unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn usage;
    }
}