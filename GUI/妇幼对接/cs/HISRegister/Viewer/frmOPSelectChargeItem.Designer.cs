namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOPSelectChargeItem
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtgItem = new System.Windows.Forms.DataGridView();
            this.colChecked = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colRepNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewSpecification = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colOriPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNewPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFrequency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colUsage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemAttribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAttachid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.m_cmdCancel = new System.Windows.Forms.Button();
            this.m_cmdConfirm = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dtgItem);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(759, 418);
            this.panel1.TabIndex = 0;
            // 
            // dtgItem
            // 
            this.dtgItem.AllowUserToAddRows = false;
            this.dtgItem.AllowUserToDeleteRows = false;
            this.dtgItem.AllowUserToResizeRows = false;
            this.dtgItem.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dtgItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgItem.ColumnHeadersHeight = 26;
            this.dtgItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colChecked,
            this.colRepNo,
            this.colItemName,
            this.colState,
            this.colOriSpecification,
            this.colNewSpecification,
            this.colQuantity,
            this.colOriPrice,
            this.colNewPrice,
            this.colSum,
            this.colFrequency,
            this.colUsage,
            this.colItemAttribute,
            this.colItemID,
            this.colAttachid});
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtgItem.DefaultCellStyle = dataGridViewCellStyle13;
            this.dtgItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgItem.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dtgItem.Location = new System.Drawing.Point(0, 0);
            this.dtgItem.Margin = new System.Windows.Forms.Padding(0);
            this.dtgItem.MultiSelect = false;
            this.dtgItem.Name = "dtgItem";
            this.dtgItem.RowHeadersVisible = false;
            this.dtgItem.RowTemplate.Height = 23;
            this.dtgItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgItem.ShowCellErrors = false;
            this.dtgItem.ShowCellToolTips = false;
            this.dtgItem.ShowEditingIcon = false;
            this.dtgItem.ShowRowErrors = false;
            this.dtgItem.Size = new System.Drawing.Size(755, 414);
            this.dtgItem.TabIndex = 8;
            this.dtgItem.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItem_CellContentDoubleClick);
            this.dtgItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgItem_CellContentClick);
            // 
            // colChecked
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.NullValue = false;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.colChecked.DefaultCellStyle = dataGridViewCellStyle2;
            this.colChecked.FalseValue = "F";
            this.colChecked.HeaderText = "";
            this.colChecked.Name = "colChecked";
            this.colChecked.TrueValue = "T";
            this.colChecked.Width = 20;
            // 
            // colRepNo
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.colRepNo.DefaultCellStyle = dataGridViewCellStyle3;
            this.colRepNo.HeaderText = "方号";
            this.colRepNo.Name = "colRepNo";
            this.colRepNo.ReadOnly = true;
            this.colRepNo.Visible = false;
            this.colRepNo.Width = 42;
            // 
            // colItemName
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle4;
            this.colItemName.HeaderText = "项目名称";
            this.colItemName.Name = "colItemName";
            this.colItemName.ReadOnly = true;
            this.colItemName.Width = 193;
            // 
            // colState
            // 
            this.colState.HeaderText = "状态";
            this.colState.Name = "colState";
            this.colState.ReadOnly = true;
            this.colState.Width = 75;
            // 
            // colOriSpecification
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            this.colOriSpecification.DefaultCellStyle = dataGridViewCellStyle5;
            this.colOriSpecification.HeaderText = "规格";
            this.colOriSpecification.Name = "colOriSpecification";
            this.colOriSpecification.ReadOnly = true;
            this.colOriSpecification.Width = 90;
            // 
            // colNewSpecification
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.MediumBlue;
            this.colNewSpecification.DefaultCellStyle = dataGridViewCellStyle6;
            this.colNewSpecification.HeaderText = "新规格";
            this.colNewSpecification.Name = "colNewSpecification";
            this.colNewSpecification.ReadOnly = true;
            this.colNewSpecification.Visible = false;
            this.colNewSpecification.Width = 90;
            // 
            // colQuantity
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.colQuantity.DefaultCellStyle = dataGridViewCellStyle7;
            this.colQuantity.HeaderText = "数量";
            this.colQuantity.Name = "colQuantity";
            this.colQuantity.ReadOnly = true;
            this.colQuantity.Width = 50;
            // 
            // colOriPrice
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            this.colOriPrice.DefaultCellStyle = dataGridViewCellStyle8;
            this.colOriPrice.HeaderText = "单价";
            this.colOriPrice.Name = "colOriPrice";
            this.colOriPrice.ReadOnly = true;
            this.colOriPrice.Width = 75;
            // 
            // colNewPrice
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.MediumBlue;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.MediumBlue;
            this.colNewPrice.DefaultCellStyle = dataGridViewCellStyle9;
            this.colNewPrice.HeaderText = "新单价";
            this.colNewPrice.Name = "colNewPrice";
            this.colNewPrice.ReadOnly = true;
            this.colNewPrice.Visible = false;
            this.colNewPrice.Width = 75;
            // 
            // colSum
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.Black;
            this.colSum.DefaultCellStyle = dataGridViewCellStyle10;
            this.colSum.HeaderText = "金额";
            this.colSum.Name = "colSum";
            this.colSum.ReadOnly = true;
            this.colSum.Width = 80;
            // 
            // colFrequency
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.Black;
            this.colFrequency.DefaultCellStyle = dataGridViewCellStyle11;
            this.colFrequency.HeaderText = "频率";
            this.colFrequency.Name = "colFrequency";
            this.colFrequency.ReadOnly = true;
            this.colFrequency.Width = 52;
            // 
            // colUsage
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
            this.colUsage.DefaultCellStyle = dataGridViewCellStyle12;
            this.colUsage.HeaderText = "用法";
            this.colUsage.Name = "colUsage";
            this.colUsage.ReadOnly = true;
            // 
            // colItemAttribute
            // 
            this.colItemAttribute.HeaderText = "项目属性";
            this.colItemAttribute.Name = "colItemAttribute";
            this.colItemAttribute.ReadOnly = true;
            this.colItemAttribute.Visible = false;
            // 
            // colItemID
            // 
            this.colItemID.HeaderText = "项目ID";
            this.colItemID.Name = "colItemID";
            this.colItemID.Visible = false;
            this.colItemID.Width = 90;
            // 
            // colAttachid
            // 
            this.colAttachid.HeaderText = "目标申请单id";
            this.colAttachid.Name = "colAttachid";
            this.colAttachid.Visible = false;
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.Location = new System.Drawing.Point(538, 7);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Size = new System.Drawing.Size(106, 35);
            this.m_cmdCancel.TabIndex = 2;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.UseVisualStyleBackColor = true;
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_cmdConfirm
            // 
            this.m_cmdConfirm.Location = new System.Drawing.Point(114, 7);
            this.m_cmdConfirm.Name = "m_cmdConfirm";
            this.m_cmdConfirm.Size = new System.Drawing.Size(106, 35);
            this.m_cmdConfirm.TabIndex = 2;
            this.m_cmdConfirm.Text = "确定";
            this.m_cmdConfirm.UseVisualStyleBackColor = true;
            this.m_cmdConfirm.Click += new System.EventHandler(this.m_cmdConfirm_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cmdCancel);
            this.panel2.Controls.Add(this.m_cmdConfirm);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 418);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(759, 49);
            this.panel2.TabIndex = 1;
            // 
            // frmOPSelectChargeItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 467);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "frmOPSelectChargeItem";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "选择门诊结算项目";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgItem)).EndInit();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button m_cmdCancel;
        public System.Windows.Forms.Button m_cmdConfirm;
        public System.Windows.Forms.DataGridView dtgItem;
        private System.Windows.Forms.Panel panel2;
        internal System.Windows.Forms.DataGridViewCheckBoxColumn colChecked;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRepNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colState;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewSpecification;
        private System.Windows.Forms.DataGridViewTextBoxColumn colQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn colOriPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNewPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFrequency;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUsage;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemAttribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAttachid;

    }
}