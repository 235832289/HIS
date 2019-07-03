namespace com.digitalwave.iCare.gui.LIS
{
    partial class ctlQCBatchQuery
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
            this.m_chkDeviceSeleted = new System.Windows.Forms.CheckBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtQCSampleLotNO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_cmdCheckItemSelect = new System.Windows.Forms.Button();
            this.m_txtQCCheckItem = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtQCBatchSeq = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmdQuery = new PinkieControls.ButtonXP();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dtpQCDate = new System.Windows.Forms.DateTimePicker();
            this.m_chkQCDateSelected = new System.Windows.Forms.CheckBox();
            this.m_cboDevice = new com.digitalwave.iCare.gui.LIS.ctlLISDeviceComboBox();
            this.m_cboWorkGroup = new com.digitalwave.iCare.gui.LIS.ctlWorkGroupCombox();
            this.SuspendLayout();
            // 
            // m_chkDeviceSeleted
            // 
            this.m_chkDeviceSeleted.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkDeviceSeleted.AutoSize = true;
            this.m_chkDeviceSeleted.Location = new System.Drawing.Point(232, 60);
            this.m_chkDeviceSeleted.Name = "m_chkDeviceSeleted";
            this.m_chkDeviceSeleted.Size = new System.Drawing.Size(15, 14);
            this.m_chkDeviceSeleted.TabIndex = 67;
            this.m_chkDeviceSeleted.UseVisualStyleBackColor = true;
            this.m_chkDeviceSeleted.CheckedChanged += new System.EventHandler(this.m_chkDeviceSeleted_CheckedChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(19, 60);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(77, 14);
            this.label21.TabIndex = 65;
            this.label21.Text = "检测仪器：";
            // 
            // m_txtQCSampleLotNO
            // 
            this.m_txtQCSampleLotNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtQCSampleLotNO.Location = new System.Drawing.Point(91, 104);
            this.m_txtQCSampleLotNO.MaxLength = 20;
            this.m_txtQCSampleLotNO.Name = "m_txtQCSampleLotNO";
            this.m_txtQCSampleLotNO.Size = new System.Drawing.Size(159, 23);
            this.m_txtQCSampleLotNO.TabIndex = 64;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(91, 14);
            this.label4.TabIndex = 63;
            this.label4.Text = "质控品批号：";
            // 
            // m_cmdCheckItemSelect
            // 
            this.m_cmdCheckItemSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdCheckItemSelect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.m_cmdCheckItemSelect.Location = new System.Drawing.Point(227, 80);
            this.m_cmdCheckItemSelect.Name = "m_cmdCheckItemSelect";
            this.m_cmdCheckItemSelect.Size = new System.Drawing.Size(23, 22);
            this.m_cmdCheckItemSelect.TabIndex = 62;
            this.m_cmdCheckItemSelect.Text = "┅";
            this.m_cmdCheckItemSelect.UseVisualStyleBackColor = true;
            this.m_cmdCheckItemSelect.Click += new System.EventHandler(this.m_cmdCheckItemSelect_Click);
            // 
            // m_txtQCCheckItem
            // 
            this.m_txtQCCheckItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtQCCheckItem.Location = new System.Drawing.Point(91, 80);
            this.m_txtQCCheckItem.Name = "m_txtQCCheckItem";
            this.m_txtQCCheckItem.Size = new System.Drawing.Size(136, 23);
            this.m_txtQCCheckItem.TabIndex = 61;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 60;
            this.label3.Text = "质控项目：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 58;
            this.label2.Text = "工作组：";
            // 
            // m_txtQCBatchSeq
            // 
            this.m_txtQCBatchSeq.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtQCBatchSeq.BackColor = System.Drawing.SystemColors.Window;
            this.m_txtQCBatchSeq.Location = new System.Drawing.Point(91, 8);
            this.m_txtQCBatchSeq.MaxLength = 6;
            this.m_txtQCBatchSeq.Name = "m_txtQCBatchSeq";
            this.m_txtQCBatchSeq.Size = new System.Drawing.Size(159, 23);
            this.m_txtQCBatchSeq.TabIndex = 57;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 14);
            this.label1.TabIndex = 56;
            this.label1.Text = "序号：";
            // 
            // m_cmdQuery
            // 
            this.m_cmdQuery.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmdQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdQuery.DefaultScheme = true;
            this.m_cmdQuery.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdQuery.Hint = "";
            this.m_cmdQuery.Location = new System.Drawing.Point(92, 160);
            this.m_cmdQuery.Name = "m_cmdQuery";
            this.m_cmdQuery.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdQuery.Size = new System.Drawing.Size(160, 32);
            this.m_cmdQuery.TabIndex = 68;
            this.m_cmdQuery.Text = "查询";
            this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 14);
            this.label5.TabIndex = 69;
            this.label5.Text = "质控月份：";
            // 
            // m_dtpQCDate
            // 
            this.m_dtpQCDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_dtpQCDate.CustomFormat = "yyyy-MM";
            this.m_dtpQCDate.Enabled = false;
            this.m_dtpQCDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_dtpQCDate.Location = new System.Drawing.Point(91, 128);
            this.m_dtpQCDate.Name = "m_dtpQCDate";
            this.m_dtpQCDate.Size = new System.Drawing.Size(136, 23);
            this.m_dtpQCDate.TabIndex = 70;
            // 
            // m_chkQCDateSelected
            // 
            this.m_chkQCDateSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_chkQCDateSelected.AutoSize = true;
            this.m_chkQCDateSelected.Location = new System.Drawing.Point(232, 132);
            this.m_chkQCDateSelected.Name = "m_chkQCDateSelected";
            this.m_chkQCDateSelected.Size = new System.Drawing.Size(15, 14);
            this.m_chkQCDateSelected.TabIndex = 71;
            this.m_chkQCDateSelected.UseVisualStyleBackColor = true;
            this.m_chkQCDateSelected.CheckedChanged += new System.EventHandler(this.m_chkQCDateSelected_CheckedChanged);
            // 
            // m_cboDevice
            // 
            this.m_cboDevice.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cboDevice.Enabled = false;
            this.m_cboDevice.FormattingEnabled = true;
            this.m_cboDevice.Location = new System.Drawing.Point(91, 56);
            this.m_cboDevice.Name = "m_cboDevice";
            this.m_cboDevice.Size = new System.Drawing.Size(136, 22);
            this.m_cboDevice.TabIndex = 66;
            // 
            // m_cboWorkGroup
            // 
            this.m_cboWorkGroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cboWorkGroup.FormattingEnabled = true;
            this.m_cboWorkGroup.Location = new System.Drawing.Point(91, 32);
            this.m_cboWorkGroup.Name = "m_cboWorkGroup";
            this.m_cboWorkGroup.Size = new System.Drawing.Size(159, 22);
            this.m_cboWorkGroup.TabIndex = 59;
            this.m_cboWorkGroup.Value = -1;
            // 
            // ctlQCBatchQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_chkQCDateSelected);
            this.Controls.Add(this.m_dtpQCDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_cmdQuery);
            this.Controls.Add(this.m_chkDeviceSeleted);
            this.Controls.Add(this.m_cboDevice);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.m_txtQCSampleLotNO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cmdCheckItemSelect);
            this.Controls.Add(this.m_txtQCCheckItem);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_cboWorkGroup);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtQCBatchSeq);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Name = "ctlQCBatchQuery";
            this.Size = new System.Drawing.Size(260, 198);
            this.Load += new System.EventHandler(this.ctlQCBatchQuery_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox m_chkDeviceSeleted;
        private ctlLISDeviceComboBox m_cboDevice;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox m_txtQCSampleLotNO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button m_cmdCheckItemSelect;
        private System.Windows.Forms.TextBox m_txtQCCheckItem;
        private System.Windows.Forms.Label label3;
        private ctlWorkGroupCombox m_cboWorkGroup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtQCBatchSeq;
        private System.Windows.Forms.Label label1;
        private PinkieControls.ButtonXP m_cmdQuery;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker m_dtpQCDate;
        private System.Windows.Forms.CheckBox m_chkQCDateSelected;
    }
}
