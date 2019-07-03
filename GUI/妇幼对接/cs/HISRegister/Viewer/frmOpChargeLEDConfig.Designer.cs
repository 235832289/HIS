namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmOpChargeLEDConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOpChargeLEDConfig));
            this.panel1 = new System.Windows.Forms.Panel();
            this.grouper1 = new com.digitalwave.controls.Grouper();
            this.buttonXP4 = new PinkieControls.ButtonXP();
            this.btnDel = new PinkieControls.ButtonXP();
            this.btnEdit = new PinkieControls.ButtonXP();
            this.btnAdd = new PinkieControls.ButtonXP();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.grouper1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Controls.Add(this.grouper1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 201);
            this.panel1.TabIndex = 0;
            // 
            // grouper1
            // 
            this.grouper1.BackgroundColor = System.Drawing.Color.Transparent;
            this.grouper1.BackgroundGradientColor = System.Drawing.Color.Transparent;
            this.grouper1.BackgroundGradientMode = com.digitalwave.controls.Grouper.GroupBoxGradientMode.None;
            this.grouper1.BorderColor = System.Drawing.Color.CornflowerBlue;
            this.grouper1.BorderThickness = 1F;
            this.grouper1.Controls.Add(this.buttonXP4);
            this.grouper1.Controls.Add(this.btnDel);
            this.grouper1.Controls.Add(this.btnEdit);
            this.grouper1.Controls.Add(this.btnAdd);
            this.grouper1.Controls.Add(this.listBox1);
            this.grouper1.Controls.Add(this.comboBox2);
            this.grouper1.Controls.Add(this.label1);
            this.grouper1.Controls.Add(this.comboBox1);
            this.grouper1.CustomGroupBoxColor = System.Drawing.Color.White;
            this.grouper1.ForeColor = System.Drawing.Color.Blue;
            this.grouper1.GroupImage = ((System.Drawing.Image)(resources.GetObject("grouper1.GroupImage")));
            this.grouper1.GroupTitle = "设 置";
            this.grouper1.Location = new System.Drawing.Point(7, 6);
            this.grouper1.Name = "grouper1";
            this.grouper1.Padding = new System.Windows.Forms.Padding(20);
            this.grouper1.PaintGroupBox = true;
            this.grouper1.RoundCorners = 10;
            this.grouper1.ShadowColor = System.Drawing.Color.LightGray;
            this.grouper1.ShadowControl = false;
            this.grouper1.ShadowThickness = 3;
            this.grouper1.Size = new System.Drawing.Size(403, 189);
            this.grouper1.TabIndex = 0;
            // 
            // buttonXP4
            // 
            this.buttonXP4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonXP4.DefaultScheme = true;
            this.buttonXP4.DialogResult = System.Windows.Forms.DialogResult.None;
            this.buttonXP4.Hint = "";
            this.buttonXP4.Location = new System.Drawing.Point(320, 152);
            this.buttonXP4.Name = "buttonXP4";
            this.buttonXP4.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.buttonXP4.Size = new System.Drawing.Size(67, 27);
            this.buttonXP4.TabIndex = 7;
            this.buttonXP4.Text = "关闭";
            this.buttonXP4.Click += new System.EventHandler(this.buttonXP4_Click);
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnDel.DefaultScheme = true;
            this.btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDel.Hint = "";
            this.btnDel.Location = new System.Drawing.Point(320, 117);
            this.btnDel.Name = "btnDel";
            this.btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnDel.Size = new System.Drawing.Size(67, 27);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "删除";
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnEdit.DefaultScheme = true;
            this.btnEdit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEdit.Hint = "";
            this.btnEdit.Location = new System.Drawing.Point(320, 82);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnEdit.Size = new System.Drawing.Size(67, 27);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "编辑";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.btnAdd.DefaultScheme = true;
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnAdd.Hint = "";
            this.btnAdd.Location = new System.Drawing.Point(320, 47);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Silver;
            this.btnAdd.Size = new System.Drawing.Size(67, 27);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "增加";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(20, 52);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(285, 130);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(226, 27);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(79, 22);
            this.comboBox2.TabIndex = 3;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(148, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "时显示消息";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(20, 27);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(127, 22);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // frmOpChargeLEDConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(417, 201);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.Name = "frmOpChargeLEDConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "收费引导屏消息设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmOpChargeLEDConfig_FormClosing);
            this.Load += new System.EventHandler(this.frmOpChargeLEDConfig_Load);
            this.panel1.ResumeLayout(false);
            this.grouper1.ResumeLayout(false);
            this.grouper1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private com.digitalwave.controls.Grouper grouper1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private PinkieControls.ButtonXP buttonXP4;
        private PinkieControls.ButtonXP btnDel;
        private PinkieControls.ButtonXP btnEdit;
        private PinkieControls.ButtonXP btnAdd;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;



    }
}