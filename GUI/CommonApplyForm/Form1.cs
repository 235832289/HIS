using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.GLS_WS
{
	/// <summary>
	/// Form1 的摘要说明。
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.Button button9;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
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
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.button5 = new System.Windows.Forms.Button();
			this.button6 = new System.Windows.Forms.Button();
			this.button7 = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.button8 = new System.Windows.Forms.Button();
			this.button9 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(24, 24);
			this.button1.Name = "button1";
			this.button1.TabIndex = 0;
			this.button1.Text = "Open";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(24, 64);
			this.button2.Name = "button2";
			this.button2.TabIndex = 1;
			this.button2.Text = "New";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(24, 104);
			this.button3.Name = "button3";
			this.button3.TabIndex = 2;
			this.button3.Text = "OpenWithVO";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(24, 144);
			this.button4.Name = "button4";
			this.button4.TabIndex = 3;
			this.button4.Text = "SaveWithVO";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(128, 24);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(104, 24);
			this.button5.TabIndex = 4;
			this.button5.Text = "PrintPreview";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(128, 64);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(80, 23);
			this.button6.TabIndex = 5;
			this.button6.Text = "Print";
			this.button6.Click += new System.EventHandler(this.button6_Click);
			// 
			// button7
			// 
			this.button7.Location = new System.Drawing.Point(128, 112);
			this.button7.Name = "button7";
			this.button7.TabIndex = 6;
			this.button7.Text = "Dictionary";
			this.button7.Click += new System.EventHandler(this.button7_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 184);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 23);
			this.label1.TabIndex = 7;
			this.label1.Text = "示例,可删除Form1.cs";
			// 
			// button8
			// 
			this.button8.Location = new System.Drawing.Point(128, 152);
			this.button8.Name = "button8";
			this.button8.TabIndex = 8;
			this.button8.Text = "Delete";
			this.button8.Click += new System.EventHandler(this.button8_Click);
			// 
			// button9
			// 
			this.button9.Location = new System.Drawing.Point(232, 152);
			this.button9.Name = "button9";
			this.button9.TabIndex = 9;
			this.button9.Text = "GetVO";
			this.button9.Click += new System.EventHandler(this.button9_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(328, 221);
			this.Controls.Add(this.button9);
			this.Controls.Add(this.button8);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.button7);
			this.Controls.Add(this.button6);
			this.Controls.Add(this.button5);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			com.digitalwave.GLS_WS.clsApplyForm m = new com.digitalwave.GLS_WS.clsApplyForm();
			m.OpenForm("1");
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			com.digitalwave.GLS_WS.clsApplyForm m = new com.digitalwave.GLS_WS.clsApplyForm();
			m.OpenForm(null);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			clsApplyRecord vo = new clsApplyRecord();
			//vo.m_strApplyTitle = "CT检查";
			vo.m_strName = "张三";
			vo.m_strTypeID = "1";
			com.digitalwave.GLS_WS.clsApplyForm m = new com.digitalwave.GLS_WS.clsApplyForm();
			m.OpenWithVO(vo);
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			clsApplyRecord vo = new clsApplyRecord();
			vo.m_strApplyTitle = "CT检查";
			com.digitalwave.GLS_WS.clsApplyForm m = new com.digitalwave.GLS_WS.clsApplyForm();
			m.SaveWithVO(vo);
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			com.digitalwave.GLS_WS.clsApplyForm m = new com.digitalwave.GLS_WS.clsApplyForm();
			m.PintPreview("1");
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			com.digitalwave.GLS_WS.clsApplyForm m = new com.digitalwave.GLS_WS.clsApplyForm();
			m.Print("1");
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			com.digitalwave.GLS_WS.clsApplyForm m = new com.digitalwave.GLS_WS.clsApplyForm();
			m.ShowDictionary();
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			com.digitalwave.GLS_WS.clsApplyForm m = new com.digitalwave.GLS_WS.clsApplyForm();
			m.Delete("1");
		}

		private void button9_Click(object sender, System.EventArgs e)
		{
			DateTime d1 = DateTime.Parse("2000-12-12");		
			DateTime d2 = DateTime.Now;

			com.digitalwave.GLS_WS.clsApplyForm m = new com.digitalwave.GLS_WS.clsApplyForm();
			m.Delete("1");

			MessageBox.Show(m.GetApplyRecordByDate(d1,d2,null).Length.ToString());
			//MessageBox.Show(m.GetAllCheckTypes().Length.ToString());

		}
	}
}
