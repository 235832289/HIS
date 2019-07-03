namespace com.digitalwave.iCare.gui.HIS
{
    partial class frmCritialDeptList
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDeptFind = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDeptList = new System.Windows.Forms.DataGridView();
            this.col_status = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.col_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_dept = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptList)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtDeptFind);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(328, 44);
            this.panel1.TabIndex = 0;
            // 
            // txtDeptFind
            // 
            this.txtDeptFind.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDeptFind.Location = new System.Drawing.Point(112, 4);
            this.txtDeptFind.Name = "txtDeptFind";
            this.txtDeptFind.Size = new System.Drawing.Size(212, 31);
            this.txtDeptFind.TabIndex = 1;
            this.txtDeptFind.TextChanged += new System.EventHandler(this.txtDeptFind_TextChanged);
            this.txtDeptFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDeptFind_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找(代码/名称)：";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.chkSelectAll);
            this.panel2.Location = new System.Drawing.Point(0, 604);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 44);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(212, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 28);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(104, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(92, 28);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(8, 16);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(48, 16);
            this.chkSelectAll.TabIndex = 1;
            this.chkSelectAll.Text = "全选";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvDeptList);
            this.panel3.Location = new System.Drawing.Point(0, 48);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(328, 556);
            this.panel3.TabIndex = 2;
            // 
            // dgvDeptList
            // 
            this.dgvDeptList.AllowUserToAddRows = false;
            this.dgvDeptList.AllowUserToDeleteRows = false;
            this.dgvDeptList.AllowUserToResizeColumns = false;
            this.dgvDeptList.AllowUserToResizeRows = false;
            this.dgvDeptList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDeptList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_status,
            this.col_no,
            this.col_id,
            this.col_dept});
            this.dgvDeptList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDeptList.Location = new System.Drawing.Point(0, 0);
            this.dgvDeptList.Name = "dgvDeptList";
            this.dgvDeptList.RowHeadersVisible = false;
            this.dgvDeptList.RowTemplate.Height = 23;
            this.dgvDeptList.Size = new System.Drawing.Size(328, 556);
            this.dgvDeptList.TabIndex = 0;
            // 
            // col_status
            // 
            this.col_status.HeaderText = "状态";
            this.col_status.Name = "col_status";
            this.col_status.Width = 50;
            // 
            // col_no
            // 
            this.col_no.HeaderText = "NO.";
            this.col_no.Name = "col_no";
            this.col_no.Width = 50;
            // 
            // col_id
            // 
            this.col_id.HeaderText = "代码";
            this.col_id.Name = "col_id";
            this.col_id.Width = 60;
            // 
            // col_dept
            // 
            this.col_dept.HeaderText = "科室名称";
            this.col_dept.Name = "col_dept";
            this.col_dept.Width = 150;
            // 
            // frmCritialDeptList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 646);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCritialDeptList";
            this.Text = "选择科室/病区";
            this.Load += new System.EventHandler(this.frmCritialDeptList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDeptList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtDeptFind;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDeptList;
        private System.Windows.Forms.DataGridViewCheckBoxColumn col_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_no;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_dept;
    }
}