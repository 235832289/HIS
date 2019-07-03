using System.Drawing;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
    partial class frmByDept
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
            this.txtVal = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtDept = new System.Windows.Forms.DataGridView();
            this.colZt = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colKsmc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtDept)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtVal);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 40);
            this.panel1.TabIndex = 0;
            // 
            // txtVal
            // 
            this.txtVal.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVal.Location = new System.Drawing.Point(140, 4);
            this.txtVal.Name = "txtVal";
            this.txtVal.Size = new System.Drawing.Size(148, 23);
            this.txtVal.TabIndex = 1;
            this.txtVal.TextChanged += new System.EventHandler(this.txtVal_TextChanged);
            this.txtVal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVal_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "查找(代码/名称)";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCancel);
            this.panel2.Controls.Add(this.btnOk);
            this.panel2.Controls.Add(this.chkAll);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 516);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(296, 41);
            this.panel2.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(204, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "放弃";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(120, 8);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "确定";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(8, 12);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(48, 16);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "全选";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dtDept);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 40);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(296, 476);
            this.panel3.TabIndex = 2;
            // 
            // dtDept
            // 
            this.dtDept.AllowUserToAddRows = false;
            this.dtDept.AllowUserToDeleteRows = false;
            this.dtDept.AllowUserToResizeRows = false;
            this.dtDept.BackgroundColor = System.Drawing.Color.White;
            this.dtDept.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtDept.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtDept.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colZt,
            this.colNo,
            this.colDm,
            this.colKsmc});
            this.dtDept.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtDept.Location = new System.Drawing.Point(0, 0);
            this.dtDept.MultiSelect = false;
            this.dtDept.Name = "dtDept";
            this.dtDept.RowHeadersVisible = false;
            this.dtDept.RowTemplate.Height = 23;
            this.dtDept.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtDept.Size = new System.Drawing.Size(296, 476);
            this.dtDept.TabIndex = 10;
            // 
            // colZt
            // 
            this.colZt.FalseValue = "F";
            this.colZt.HeaderText = "状态";
            this.colZt.Name = "colZt";
            this.colZt.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colZt.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colZt.TrueValue = "T";
            this.colZt.Width = 45;
            // 
            // colNo
            // 
            this.colNo.HeaderText = "NO.";
            this.colNo.Name = "colNo";
            this.colNo.ReadOnly = true;
            this.colNo.Width = 45;
            // 
            // colDm
            // 
            this.colDm.HeaderText = "代码";
            this.colDm.Name = "colDm";
            this.colDm.ReadOnly = true;
            this.colDm.Width = 70;
            // 
            // colKsmc
            // 
            this.colKsmc.HeaderText = "科室名称";
            this.colKsmc.Name = "colKsmc";
            this.colKsmc.ReadOnly = true;
            this.colKsmc.Width = 130;
            // 
            // frmByDept
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 557);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "frmByDept";
            this.Text = "选择科室";
            this.Load += new System.EventHandler(this.frmByDept_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtDept)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dtDept;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colZt;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDm;
        private System.Windows.Forms.DataGridViewTextBoxColumn colKsmc;
    }
}