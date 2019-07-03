namespace com.digitalwave.iCare.gui.LIS
{
    partial class ctlQCDataEditor
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
            this.m_dtgEditor = new System.Windows.Forms.DataGridView();
            this.m_cmdAddRowPrev = new PinkieControls.ButtonXP();
            this.m_cmdAddRowAfter = new PinkieControls.ButtonXP();
            this.m_cmdDeleteRow = new PinkieControls.ButtonXP();
            this.m_cmdSave = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgEditor)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            this.m_dtgEditor.Size = new System.Drawing.Size(470, 489);
            this.m_dtgEditor.TabIndex = 4;
            this.m_dtgEditor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_dtgEditor_CellClick);
            this.m_dtgEditor.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.m_dtgEditor_CellValidating);
            // 
            // m_cmdAddRowPrev
            // 
            this.m_cmdAddRowPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAddRowPrev.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddRowPrev.DefaultScheme = true;
            this.m_cmdAddRowPrev.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddRowPrev.Hint = "";
            this.m_cmdAddRowPrev.Location = new System.Drawing.Point(37, 318);
            this.m_cmdAddRowPrev.Name = "m_cmdAddRowPrev";
            this.m_cmdAddRowPrev.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddRowPrev.Size = new System.Drawing.Size(96, 33);
            this.m_cmdAddRowPrev.TabIndex = 0;
            this.m_cmdAddRowPrev.Text = "插入（↑）";
            this.m_cmdAddRowPrev.Visible = false;
            this.m_cmdAddRowPrev.Click += new System.EventHandler(this.m_cmdAddRowPrev_Click);
            // 
            // m_cmdAddRowAfter
            // 
            this.m_cmdAddRowAfter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdAddRowAfter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAddRowAfter.DefaultScheme = true;
            this.m_cmdAddRowAfter.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAddRowAfter.Hint = "";
            this.m_cmdAddRowAfter.Location = new System.Drawing.Point(37, 357);
            this.m_cmdAddRowAfter.Name = "m_cmdAddRowAfter";
            this.m_cmdAddRowAfter.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAddRowAfter.Size = new System.Drawing.Size(96, 33);
            this.m_cmdAddRowAfter.TabIndex = 1;
            this.m_cmdAddRowAfter.Text = "插入（↓）";
            this.m_cmdAddRowAfter.Visible = false;
            this.m_cmdAddRowAfter.Click += new System.EventHandler(this.m_cmdAddRowAfter_Click);
            // 
            // m_cmdDeleteRow
            // 
            this.m_cmdDeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdDeleteRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdDeleteRow.DefaultScheme = true;
            this.m_cmdDeleteRow.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdDeleteRow.Hint = "";
            this.m_cmdDeleteRow.Location = new System.Drawing.Point(37, 118);
            this.m_cmdDeleteRow.Name = "m_cmdDeleteRow";
            this.m_cmdDeleteRow.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdDeleteRow.Size = new System.Drawing.Size(96, 33);
            this.m_cmdDeleteRow.TabIndex = 3;
            this.m_cmdDeleteRow.Text = "删除整行";
            this.m_cmdDeleteRow.Click += new System.EventHandler(this.m_cmdDeleteRow_Click);
            // 
            // m_cmdSave
            // 
            this.m_cmdSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSave.DefaultScheme = true;
            this.m_cmdSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSave.Hint = "";
            this.m_cmdSave.Location = new System.Drawing.Point(37, 57);
            this.m_cmdSave.Name = "m_cmdSave";
            this.m_cmdSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSave.Size = new System.Drawing.Size(96, 33);
            this.m_cmdSave.TabIndex = 2;
            this.m_cmdSave.Text = "保存";
            this.m_cmdSave.Click += new System.EventHandler(this.m_cmdSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmdAddRowAfter);
            this.panel1.Controls.Add(this.m_cmdSave);
            this.panel1.Controls.Add(this.m_cmdAddRowPrev);
            this.panel1.Controls.Add(this.m_cmdDeleteRow);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(470, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(166, 489);
            this.panel1.TabIndex = 5;
            // 
            // ctlQCDataEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_dtgEditor);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "ctlQCDataEditor";
            this.Size = new System.Drawing.Size(636, 489);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgEditor)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridView m_dtgEditor;
        private PinkieControls.ButtonXP m_cmdAddRowPrev;
        private PinkieControls.ButtonXP m_cmdAddRowAfter;
        private PinkieControls.ButtonXP m_cmdDeleteRow;
        private PinkieControls.ButtonXP m_cmdSave;
        private System.Windows.Forms.Panel panel1;

    }
}
