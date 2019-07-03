using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace iCare
{
	/// <summary>
	/// 查询用Listview
	/// </summary>
	public class frmQueryListview : System.Windows.Forms.Form
	{
		internal System.Windows.Forms.TextBox m_txtInput;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label m_lblHintText;
        internal System.Windows.Forms.ListView m_lsvDetail;
        internal Button m_cmdLast;
        internal Button m_cmdNext;
		private System.ComponentModel.IContainer components;
        internal LinkLabel m_lklCustom;
        /// <summary>
        /// 用于Listview分页显示时记录当前索引
        /// </summary>
        internal int m_intCurrentIndex;

		public frmQueryListview()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQueryListview));
            this.m_txtInput = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblHintText = new System.Windows.Forms.Label();
            this.m_lsvDetail = new System.Windows.Forms.ListView();
            this.m_cmdLast = new System.Windows.Forms.Button();
            this.m_cmdNext = new System.Windows.Forms.Button();
            this.m_lklCustom = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // m_txtInput
            // 
            this.m_txtInput.Location = new System.Drawing.Point(32, 0);
            this.m_txtInput.Name = "m_txtInput";
            this.m_txtInput.Size = new System.Drawing.Size(106, 23);
            this.m_txtInput.TabIndex = 0;
            this.m_txtInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.This_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // label1
            // 
            this.label1.ImageIndex = 0;
            this.label1.ImageList = this.imageList1;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 24);
            this.label1.TabIndex = 1;
            // 
            // m_lblHintText
            // 
            this.m_lblHintText.Location = new System.Drawing.Point(140, 0);
            this.m_lblHintText.Name = "m_lblHintText";
            this.m_lblHintText.Size = new System.Drawing.Size(362, 23);
            this.m_lblHintText.TabIndex = 2;
            this.m_lblHintText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lsvDetail
            // 
            this.m_lsvDetail.FullRowSelect = true;
            this.m_lsvDetail.GridLines = true;
            this.m_lsvDetail.Location = new System.Drawing.Point(0, 24);
            this.m_lsvDetail.MultiSelect = false;
            this.m_lsvDetail.Name = "m_lsvDetail";
            this.m_lsvDetail.Size = new System.Drawing.Size(504, 164);
            this.m_lsvDetail.TabIndex = 3;
            this.m_lsvDetail.UseCompatibleStateImageBehavior = false;
            this.m_lsvDetail.View = System.Windows.Forms.View.Details;
            this.m_lsvDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.This_KeyDown);
            // 
            // m_cmdLast
            // 
            this.m_cmdLast.Location = new System.Drawing.Point(419, 0);
            this.m_cmdLast.Name = "m_cmdLast";
            this.m_cmdLast.Size = new System.Drawing.Size(29, 23);
            this.m_cmdLast.TabIndex = 4;
            this.m_cmdLast.Text = "<<";
            this.m_cmdLast.UseVisualStyleBackColor = true;
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(454, 0);
            this.m_cmdNext.Name = "m_cmdNext";
            this.m_cmdNext.Size = new System.Drawing.Size(29, 23);
            this.m_cmdNext.TabIndex = 4;
            this.m_cmdNext.Text = ">>";
            this.m_cmdNext.UseVisualStyleBackColor = true;
            // 
            // m_lklCustom
            // 
            this.m_lklCustom.AccessibleDescription = "可自定义任何操作";
            this.m_lklCustom.AutoSize = true;
            this.m_lklCustom.Location = new System.Drawing.Point(336, 3);
            this.m_lklCustom.Name = "m_lklCustom";
            this.m_lklCustom.Size = new System.Drawing.Size(77, 14);
            this.m_lklCustom.TabIndex = 5;
            this.m_lklCustom.TabStop = true;
            this.m_lklCustom.Text = "linkLabel1";
            this.m_lklCustom.Visible = false;
            // 
            // frmQueryListview
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(504, 189);
            this.Controls.Add(this.m_lklCustom);
            this.Controls.Add(this.m_cmdNext);
            this.Controls.Add(this.m_cmdLast);
            this.Controls.Add(this.m_lsvDetail);
            this.Controls.Add(this.m_lblHintText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtInput);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmQueryListview";
            this.Load += new System.EventHandler(this.frmQueryListview_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void frmQueryListview_Load(object sender, System.EventArgs e)
		{
		
		}

		private void This_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				this.Close();
			}
		}
	}
}
