using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;

namespace iCare
{
    public class frmnHospitalMainRecordCharge :Form
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
            this.m_txtInpatientID = new System.Windows.Forms.TextBox();
            this.m_txtInhosiptalTime = new System.Windows.Forms.TextBox();
            this.m_btnSelect = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_dtgChargeInfo = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgChargeInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // m_txtInpatientID
            // 
            this.m_txtInpatientID.Location = new System.Drawing.Point(75, 8);
            this.m_txtInpatientID.Name = "m_txtInpatientID";
            this.m_txtInpatientID.Size = new System.Drawing.Size(100, 21);
            this.m_txtInpatientID.TabIndex = 1;
            // 
            // m_txtInhosiptalTime
            // 
            this.m_txtInhosiptalTime.Location = new System.Drawing.Point(75, 33);
            this.m_txtInhosiptalTime.Name = "m_txtInhosiptalTime";
            this.m_txtInhosiptalTime.Size = new System.Drawing.Size(100, 21);
            this.m_txtInhosiptalTime.TabIndex = 2;
            // 
            // m_btnSelect
            // 
            this.m_btnSelect.Location = new System.Drawing.Point(190, 8);
            this.m_btnSelect.Name = "m_btnSelect";
            this.m_btnSelect.Size = new System.Drawing.Size(63, 43);
            this.m_btnSelect.TabIndex = 3;
            this.m_btnSelect.Text = "查询";
            this.m_btnSelect.UseVisualStyleBackColor = true;
            this.m_btnSelect.Click += new System.EventHandler(this.m_btnSelect_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "住院次数：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "住院号：";
            // 
            // m_dtgChargeInfo
            // 
            this.m_dtgChargeInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dtgChargeInfo.Location = new System.Drawing.Point(16, 69);
            this.m_dtgChargeInfo.Name = "m_dtgChargeInfo";
            this.m_dtgChargeInfo.RowTemplate.Height = 23;
            this.m_dtgChargeInfo.Size = new System.Drawing.Size(240, 319);
            this.m_dtgChargeInfo.TabIndex = 5;
            // 
            // frmnHospitalMainRecordCharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(268, 400);
            this.Controls.Add(this.m_dtgChargeInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btnSelect);
            this.Controls.Add(this.m_txtInhosiptalTime);
            this.Controls.Add(this.m_txtInpatientID);
            this.MaximizeBox = false;
            this.Name = "frmnHospitalMainRecordCharge";
            this.Text = "首页过渡期病人住院费用";
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgChargeInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox m_txtInpatientID;
        private System.Windows.Forms.TextBox m_txtInhosiptalTime;
        private System.Windows.Forms.Button m_btnSelect;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView m_dtgChargeInfo;
        private clsInHospitalMainRecordDomain m_objDomain;
        private clsInHospitalMainCharge[] objChargeArr = null;
        public frmnHospitalMainRecordCharge()
        {
            InitializeComponent();
            m_objDomain = new clsInHospitalMainRecordDomain();
        }

        private void m_btnSelect_Click(object sender, EventArgs e)
        {
            //DataTable dtResult = new DataTable();
            //m_objDomain.m_lngGetOldPatientCharge(m_txtInpatientID.Text.ToString().Trim(), m_txtInhosiptalTime.Text.ToString().Trim(), out dtResult);
            //this.m_dtgChargeInfo.DataSource = dtResult;
           
        }
    }
}