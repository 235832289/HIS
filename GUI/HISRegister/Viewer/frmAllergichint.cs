using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmAllergichint 的摘要说明。
	/// </summary>
	public class frmAllergichint : System.Windows.Forms.Form
	{
		private System.Windows.Forms.PictureBox pictureBox1;
		internal com.digitalwave.controls.ctlRichTextBox txtInfo;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button m_cmdClose;
		private System.ComponentModel.IContainer components;

		public  string CONTENTTEXT
		{
			set
			{
				txtInfo.Text = value.Trim();
			}
			get
			{
			return 	txtInfo.Text.Trim();
				
			}
		}
		public frmAllergichint()
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllergichint));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtInfo = new com.digitalwave.controls.ctlRichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_cmdClose = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtInfo
            // 
            this.txtInfo.BackColor = System.Drawing.Color.White;
            this.txtInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfo.Location = new System.Drawing.Point(32, 24);
            this.txtInfo.m_BlnIgnoreUserInfo = true;
            this.txtInfo.m_BlnPartControl = false;
            this.txtInfo.m_BlnReadOnly = true;
            this.txtInfo.m_BlnUnderLineDST = false;
            this.txtInfo.m_ClrDST = System.Drawing.Color.Red;
            this.txtInfo.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtInfo.m_IntCanModifyTime = 500;
            this.txtInfo.m_IntPartControlLength = 0;
            this.txtInfo.m_IntPartControlStartIndex = 0;
            this.txtInfo.m_StrUserID = "";
            this.txtInfo.m_StrUserName = "";
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.ReadOnly = true;
            this.txtInfo.Size = new System.Drawing.Size(182, 32);
            this.txtInfo.TabIndex = 0;
            this.txtInfo.TabStop = false;
            this.txtInfo.Text = "dsfdsfdfdgdfg234234234234234sfsdfsdfsdffdfdfdfdffasdferer";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.m_cmdClose);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.txtInfo);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(217, 59);
            this.panel1.TabIndex = 2;
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_cmdClose.ForeColor = System.Drawing.Color.Transparent;
            this.m_cmdClose.Location = new System.Drawing.Point(144, -24);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Size = new System.Drawing.Size(36, 16);
            this.m_cmdClose.TabIndex = 4;
            this.m_cmdClose.Text = "close(&G)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(198, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "关闭");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(32, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "过敏信息:";
            // 
            // frmAllergichint
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(219, 61);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAllergichint";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "过敏提示窗口";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAllergichint_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		
		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Hide();		
		}

        private void frmAllergichint_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control )
            {
                if (e.KeyCode == Keys.G)
                {
                    this.Visible = false;
                }
            }
        }		
	}
}
