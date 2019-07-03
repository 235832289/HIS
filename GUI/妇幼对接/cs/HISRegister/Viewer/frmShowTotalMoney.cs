using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmShowTotalMoney 的摘要说明。
	/// </summary>
	public class frmShowTotalMoney  : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btOK;
		internal System.Windows.Forms.Label lbeTotal;
		internal System.Windows.Forms.Label lbeChargeUp;
		internal System.Windows.Forms.Label lbeSelfPay;
		internal System.Windows.Forms.Label lbeTitle;
		internal System.Windows.Forms.Label lbe1;
		internal System.Windows.Forms.Label lbe2;
		internal System.Windows.Forms.Label lbe3;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Panel panel5;
		private System.Windows.Forms.Panel panel6;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmShowTotalMoney()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.lbeTitle = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.btOK = new System.Windows.Forms.Button();
			this.lbeTotal = new System.Windows.Forms.Label();
			this.lbeChargeUp = new System.Windows.Forms.Label();
			this.lbeSelfPay = new System.Windows.Forms.Label();
			this.lbe1 = new System.Windows.Forms.Label();
			this.lbe2 = new System.Windows.Forms.Label();
			this.lbe3 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label1 = new System.Windows.Forms.Label();
			this.panel4 = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbeTitle
			// 
			this.lbeTitle.Font = new System.Drawing.Font("楷体_GB2312", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbeTitle.ForeColor = System.Drawing.Color.Black;
			this.lbeTitle.Location = new System.Drawing.Point(8, 8);
			this.lbeTitle.Name = "lbeTitle";
			this.lbeTitle.Size = new System.Drawing.Size(476, 32);
			this.lbeTitle.TabIndex = 0;
			this.lbeTitle.Text = "处方合计(N张)";
			this.lbeTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(37, 4);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 19);
			this.label2.TabIndex = 1;
			this.label2.Text = "总额";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(37, 4);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 19);
			this.label3.TabIndex = 2;
			this.label3.Text = "记账";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(37, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 19);
			this.label4.TabIndex = 3;
			this.label4.Text = "自付";
			// 
			// btOK
			// 
			this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btOK.Location = new System.Drawing.Point(134, 264);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(220, 28);
			this.btOK.TabIndex = 4;
			this.btOK.Text = "确定";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// lbeTotal
			// 
			this.lbeTotal.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lbeTotal.Location = new System.Drawing.Point(388, 224);
			this.lbeTotal.Name = "lbeTotal";
			this.lbeTotal.Size = new System.Drawing.Size(76, 20);
			this.lbeTotal.TabIndex = 5;
			// 
			// lbeChargeUp
			// 
			this.lbeChargeUp.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lbeChargeUp.Location = new System.Drawing.Point(148, 224);
			this.lbeChargeUp.Name = "lbeChargeUp";
			this.lbeChargeUp.Size = new System.Drawing.Size(76, 20);
			this.lbeChargeUp.TabIndex = 6;
			// 
			// lbeSelfPay
			// 
			this.lbeSelfPay.ForeColor = System.Drawing.SystemColors.Desktop;
			this.lbeSelfPay.Location = new System.Drawing.Point(272, 224);
			this.lbeSelfPay.Name = "lbeSelfPay";
			this.lbeSelfPay.Size = new System.Drawing.Size(72, 20);
			this.lbeSelfPay.TabIndex = 7;
			// 
			// lbe1
			// 
			this.lbe1.Location = new System.Drawing.Point(52, 76);
			this.lbe1.Name = "lbe1";
			this.lbe1.Size = new System.Drawing.Size(176, 144);
			this.lbe1.TabIndex = 8;
			// 
			// lbe2
			// 
			this.lbe2.Location = new System.Drawing.Point(272, 76);
			this.lbe2.Name = "lbe2";
			this.lbe2.Size = new System.Drawing.Size(72, 144);
			this.lbe2.TabIndex = 9;
			// 
			// lbe3
			// 
			this.lbe3.Location = new System.Drawing.Point(392, 76);
			this.lbe3.Name = "lbe3";
			this.lbe3.Size = new System.Drawing.Size(68, 144);
			this.lbe3.TabIndex = 10;
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.panel4);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Location = new System.Drawing.Point(132, 44);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(116, 28);
			this.panel1.TabIndex = 11;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.label4);
			this.panel2.Location = new System.Drawing.Point(248, 44);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(116, 28);
			this.panel2.TabIndex = 12;
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.label2);
			this.panel3.Location = new System.Drawing.Point(364, 44);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(116, 28);
			this.panel3.TabIndex = 13;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(52, 224);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(48, 20);
			this.label1.TabIndex = 14;
			this.label1.Text = "合计:";
			// 
			// panel4
			// 
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.label5);
			this.panel4.Location = new System.Drawing.Point(-1, -1);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(116, 28);
			this.panel4.TabIndex = 12;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label5.Location = new System.Drawing.Point(37, 4);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(34, 19);
			this.label5.TabIndex = 2;
			this.label5.Text = "记账";
			// 
			// panel5
			// 
			this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel5.Controls.Add(this.panel6);
			this.panel5.Controls.Add(this.label7);
			this.panel5.Location = new System.Drawing.Point(48, 44);
			this.panel5.Name = "panel5";
			this.panel5.Size = new System.Drawing.Size(84, 28);
			this.panel5.TabIndex = 13;
			// 
			// panel6
			// 
			this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel6.Controls.Add(this.label6);
			this.panel6.Location = new System.Drawing.Point(-1, -1);
			this.panel6.Name = "panel6";
			this.panel6.Size = new System.Drawing.Size(116, 28);
			this.panel6.TabIndex = 12;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(24, 4);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(34, 19);
			this.label6.TabIndex = 2;
			this.label6.Text = "序号";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label7.Location = new System.Drawing.Point(37, 4);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(34, 19);
			this.label7.TabIndex = 2;
			this.label7.Text = "记账";
			// 
			// frmShowTotalMoney
			// 
			this.AcceptButton = this.btOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.ClientSize = new System.Drawing.Size(488, 304);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.lbe3);
			this.Controls.Add(this.lbe2);
			this.Controls.Add(this.lbe1);
			this.Controls.Add(this.lbeSelfPay);
			this.Controls.Add(this.lbeChargeUp);
			this.Controls.Add(this.lbeTotal);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.lbeTitle);
			this.Controls.Add(this.panel5);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmShowTotalMoney";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmShowTotalMoney";
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btOK_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
