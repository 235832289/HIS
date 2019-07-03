using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.LIS
{
    partial class ctlQCDataEditorNew
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。

        /// </summary>
        private void InitializeComponent()
        {
            this.m_txtDeviceSampleID = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblDeviceSampleID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.m_dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.m_cmdAddRowAfter = new PinkieControls.ButtonXP();
            this.m_cmdDataImpot = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.m_cmdAddRowPrev = new PinkieControls.ButtonXP();
            this.m_cmdDeleteRow = new PinkieControls.ButtonXP();
            this.m_dtgEditor = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtDeviceSampleID
            // 
            this.m_txtDeviceSampleID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtDeviceSampleID.Location = new System.Drawing.Point(24, 148);
            this.m_txtDeviceSampleID.MaxLength = 20;
            this.m_txtDeviceSampleID.Name = "m_txtDeviceSampleID";
            this.m_txtDeviceSampleID.Size = new System.Drawing.Size(96, 23);
            this.m_txtDeviceSampleID.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtDeviceSampleID);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_lblDeviceSampleID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_dtpEndDate);
            this.panel1.Controls.Add(this.m_dtpStartDate);
            this.panel1.Controls.Add(this.m_cmdAddRowAfter);
            this.panel1.Controls.Add(this.m_cmdDataImpot);
            this.panel1.Controls.Add(this.m_cmdSave);
            this.panel1.Controls.Add(this.m_cmdAddRowPrev);
            this.panel1.Controls.Add(this.m_cmdDeleteRow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(502, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(134, 489);
            this.panel1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(59, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "到";
            // 
            // m_lblDeviceSampleID
            // 
            this.m_lblDeviceSampleID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblDeviceSampleID.AutoSize = true;
            this.m_lblDeviceSampleID.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_lblDeviceSampleID.Location = new System.Drawing.Point(4, 123);
            this.m_lblDeviceSampleID.Name = "m_lblDeviceSampleID";
            this.m_lblDeviceSampleID.Size = new System.Drawing.Size(84, 14);
            this.m_lblDeviceSampleID.TabIndex = 5;
            this.m_lblDeviceSampleID.Text = "仪器标本号:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "导入数据时间:";
            // 
            // m_dtpEndDate
            // 
            this.m_dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtpEndDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpEndDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.m_dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpEndDate.Location = new System.Drawing.Point(23, 87);
            this.m_dtpEndDate.Name = "m_dtpEndDate";
            this.m_dtpEndDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpEndDate.TabIndex = 4;
            // 
            // m_dtpStartDate
            // 
            this.m_dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtpStartDate.CustomFormat = "yyyy-MM-dd";
            this.m_dtpStartDate.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.m_dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpStartDate.Location = new System.Drawing.Point(23, 39);
            this.m_dtpStartDate.Name = "m_dtpStartDate";
            this.m_dtpStartDate.Size = new System.Drawing.Size(96, 23);
            this.m_dtpStartDate.TabIndex = 4;
            // 
            // m_cmdAddRowAfter
            // 
            this.m_cmdAddRowAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAddRowAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddRowAfter.DefaultScheme = true;
            this.m_cmdAddRowAfter.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddRowAfter.Hint = "";
            this.m_cmdAddRowAfter.Location = new System.Drawing.Point(23, 392);
            this.m_cmdAddRowAfter.Name = "m_cmdAddRowAfter";
            this.m_cmdAddRowAfter.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddRowAfter.Size = new System.Drawing.Size(96, 33);
            this.m_cmdAddRowAfter.TabIndex = 1;
            this.m_cmdAddRowAfter.Text = "插入（↓）";
            this.m_cmdAddRowAfter.Visible = false;
            this.m_cmdAddRowAfter.Click += new System.EventHandler(this.m_cmdAddRowAfter_Click);
            // 
            // m_cmdDataImpot
            // 
            this.m_cmdDataImpot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDataImpot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDataImpot.DefaultScheme = true;
            this.m_cmdDataImpot.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDataImpot.Hint = "";
            this.m_cmdDataImpot.Location = new System.Drawing.Point(23, 188);
            this.m_cmdDataImpot.Name = "m_cmdDataImpot";
            this.m_cmdDataImpot.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDataImpot.Size = new System.Drawing.Size(96, 33);
            this.m_cmdDataImpot.TabIndex = 2;
            this.m_cmdDataImpot.Text = "导入数据";
            this.m_cmdDataImpot.Click += new System.EventHandler(this.m_cmdDataImpot_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(23, 243);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(96, 33);
            this.m_cmdSave.TabIndex = 2;
            this.m_cmdSave.Text = "保存";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // m_cmdAddRowPrev
            // 
            this.m_cmdAddRowPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAddRowPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddRowPrev.DefaultScheme = true;
            this.m_cmdAddRowPrev.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddRowPrev.Hint = "";
            this.m_cmdAddRowPrev.Location = new System.Drawing.Point(23, 353);
            this.m_cmdAddRowPrev.Name = "m_cmdAddRowPrev";
            this.m_cmdAddRowPrev.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddRowPrev.Size = new System.Drawing.Size(96, 33);
            this.m_cmdAddRowPrev.TabIndex = 0;
            this.m_cmdAddRowPrev.Text = "插入（↑）";
            this.m_cmdAddRowPrev.Visible = false;
            this.m_cmdAddRowPrev.Click += new System.EventHandler(this.m_cmdAddRowPrev_Click);
            // 
            // m_cmdDeleteRow
            // 
            this.m_cmdDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDeleteRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDeleteRow.DefaultScheme = true;
            this.m_cmdDeleteRow.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDeleteRow.Hint = "";
            this.m_cmdDeleteRow.Location = new System.Drawing.Point(23, 298);
            this.m_cmdDeleteRow.Name = "m_cmdDeleteRow";
            this.m_cmdDeleteRow.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDeleteRow.Size = new System.Drawing.Size(96, 33);
            this.m_cmdDeleteRow.TabIndex = 3;
            this.m_cmdDeleteRow.Text = "删除整行";
            this.m_cmdDeleteRow.Click += new System.EventHandler(this.m_cmdDeleteRow_Click);
            // 
            // m_dtgEditor
            // 
            this.m_dtgEditor.AllowUserToResizeColumns = false;
            this.m_dtgEditor.AllowUserToResizeRows = false;
            this.m_dtgEditor.BackgroundColor = System.Drawing.SystemColors.Window;
            this.m_dtgEditor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgEditor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtgEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dtgEditor.Location = new System.Drawing.Point(0, 0);
            this.m_dtgEditor.MultiSelect = false;
            this.m_dtgEditor.Name = "m_dtgEditor";
            this.m_dtgEditor.RowTemplate.Height = 23;
            this.m_dtgEditor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.m_dtgEditor.Size = new System.Drawing.Size(502, 489);
            this.m_dtgEditor.TabIndex = 7;
            this.m_dtgEditor.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.m_dtgEditor_CellValidating);
            this.m_dtgEditor.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.m_dtgEditor_RowsAdded);
            this.m_dtgEditor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtgEditor_CellClick);
            this.m_dtgEditor.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtgEditor_CellEnter);
            // 
            // ctlQCDataEditorNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_dtgEditor);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "ctlQCDataEditorNew";
            this.Size = new System.Drawing.Size(636, 489);
            this.Load += new System.EventHandler(this.ctlQCDataEditorNew_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgEditor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private PinkieControls.ButtonXP m_cmdAddRowAfter;
        private PinkieControls.ButtonXP m_cmdSave;
        private PinkieControls.ButtonXP m_cmdAddRowPrev;
        private PinkieControls.ButtonXP m_cmdDeleteRow;
        private PinkieControls.ButtonXP m_cmdDataImpot;
        public System.Windows.Forms.DateTimePicker m_dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.DateTimePicker m_dtpEndDate;
        private System.Windows.Forms.Label m_lblDeviceSampleID;
        private System.Windows.Forms.TextBox m_txtDeviceSampleID;
        private DataGridView m_dtgEditor;
    }
}
