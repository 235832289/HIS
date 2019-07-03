namespace com.digitalwave.iCare.BIHOrder
{
    partial class frmExecuteOrdersProgress
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
            this.lblExecuteOrderNote = new System.Windows.Forms.Label();
            this.lblPatient_Lbl = new System.Windows.Forms.Label();
            this.lblPatientName = new System.Windows.Forms.Label();
            this.lblPhysicianOrder_Lbl = new System.Windows.Forms.Label();
            this.lblPhysicianOrder = new System.Windows.Forms.Label();
            this.lblOrderCount = new System.Windows.Forms.Label();
            this.lblOrderNum = new System.Windows.Forms.Label();
            this.lblOrderSuffix = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblExecuteOrderNote
            // 
            this.lblExecuteOrderNote.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblExecuteOrderNote.Location = new System.Drawing.Point(61, 64);
            this.lblExecuteOrderNote.Name = "lblExecuteOrderNote";
            this.lblExecuteOrderNote.Size = new System.Drawing.Size(331, 23);
            this.lblExecuteOrderNote.TabIndex = 0;
            this.lblExecuteOrderNote.Text = "正在执行患者：的医嘱：";
            this.lblExecuteOrderNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExecuteOrderNote.Visible = false;
            // 
            // lblPatient_Lbl
            // 
            this.lblPatient_Lbl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatient_Lbl.Location = new System.Drawing.Point(30, 50);
            this.lblPatient_Lbl.Name = "lblPatient_Lbl";
            this.lblPatient_Lbl.Size = new System.Drawing.Size(89, 23);
            this.lblPatient_Lbl.TabIndex = 1;
            this.lblPatient_Lbl.Text = "正在处理第";
            this.lblPatient_Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPatient_Lbl.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblPatientName
            // 
            this.lblPatientName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPatientName.ForeColor = System.Drawing.Color.DeepPink;
            this.lblPatientName.Location = new System.Drawing.Point(304, 50);
            this.lblPatientName.Name = "lblPatientName";
            this.lblPatientName.Size = new System.Drawing.Size(81, 23);
            this.lblPatientName.TabIndex = 2;
            this.lblPatientName.Text = "患者姓名";
            this.lblPatientName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPhysicianOrder_Lbl
            // 
            this.lblPhysicianOrder_Lbl.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPhysicianOrder_Lbl.Location = new System.Drawing.Point(30, 82);
            this.lblPhysicianOrder_Lbl.Name = "lblPhysicianOrder_Lbl";
            this.lblPhysicianOrder_Lbl.Size = new System.Drawing.Size(53, 23);
            this.lblPhysicianOrder_Lbl.TabIndex = 3;
            this.lblPhysicianOrder_Lbl.Text = "医嘱：";
            this.lblPhysicianOrder_Lbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPhysicianOrder
            // 
            this.lblPhysicianOrder.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPhysicianOrder.ForeColor = System.Drawing.Color.DeepPink;
            this.lblPhysicianOrder.Location = new System.Drawing.Point(81, 82);
            this.lblPhysicianOrder.Name = "lblPhysicianOrder";
            this.lblPhysicianOrder.Size = new System.Drawing.Size(337, 23);
            this.lblPhysicianOrder.TabIndex = 4;
            this.lblPhysicianOrder.Text = "医嘱内容";
            this.lblPhysicianOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblOrderCount
            // 
            this.lblOrderCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOrderCount.Font = new System.Drawing.Font("黑体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOrderCount.ForeColor = System.Drawing.Color.DeepPink;
            this.lblOrderCount.Location = new System.Drawing.Point(137, 9);
            this.lblOrderCount.Name = "lblOrderCount";
            this.lblOrderCount.Size = new System.Drawing.Size(148, 23);
            this.lblOrderCount.TabIndex = 5;
            this.lblOrderCount.Text = "共x条医嘱";
            this.lblOrderCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderNum
            // 
            this.lblOrderNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOrderNum.ForeColor = System.Drawing.Color.DeepPink;
            this.lblOrderNum.Location = new System.Drawing.Point(104, 50);
            this.lblOrderNum.Name = "lblOrderNum";
            this.lblOrderNum.Size = new System.Drawing.Size(40, 20);
            this.lblOrderNum.TabIndex = 6;
            this.lblOrderNum.Text = "x";
            this.lblOrderNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblOrderSuffix
            // 
            this.lblOrderSuffix.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblOrderSuffix.Location = new System.Drawing.Point(146, 50);
            this.lblOrderSuffix.Name = "lblOrderSuffix";
            this.lblOrderSuffix.Size = new System.Drawing.Size(174, 23);
            this.lblOrderSuffix.TabIndex = 7;
            this.lblOrderSuffix.Text = "条医嘱，患者姓名：";
            this.lblOrderSuffix.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmExecuteOrdersProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 147);
            this.ControlBox = false;
            this.Controls.Add(this.lblOrderSuffix);
            this.Controls.Add(this.lblOrderNum);
            this.Controls.Add(this.lblOrderCount);
            this.Controls.Add(this.lblPhysicianOrder);
            this.Controls.Add(this.lblPhysicianOrder_Lbl);
            this.Controls.Add(this.lblPatientName);
            this.Controls.Add(this.lblPatient_Lbl);
            this.Controls.Add(this.lblExecuteOrderNote);
            this.Name = "frmExecuteOrdersProgress";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "医嘱执行进度";
            this.Load += new System.EventHandler(this.frmExecuteOrdersProgress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblExecuteOrderNote;
        internal System.Windows.Forms.Label lblPatientName;
        internal System.Windows.Forms.Label lblPhysicianOrder;
        internal System.Windows.Forms.Label lblPatient_Lbl;
        internal System.Windows.Forms.Label lblPhysicianOrder_Lbl;
        internal System.Windows.Forms.Label lblOrderNum;
        internal System.Windows.Forms.Label lblOrderCount;
        internal System.Windows.Forms.Label lblOrderSuffix;

    }
}