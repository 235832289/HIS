using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.Utility.Controls;

namespace iCare
{
	public class frmBeforeAnaSummary : iCare.frmManageRecordForm
	{
		private System.Windows.Forms.Button m_cmdCancel;
		private System.Windows.Forms.Button m_cmdOK;
		private System.Windows.Forms.GroupBox m_gpbA;
		private System.Windows.Forms.RadioButton m_rdbA2;
		private System.Windows.Forms.RadioButton m_rdbA1;
		private System.Windows.Forms.GroupBox m_gpbB;
		private System.Windows.Forms.RadioButton m_rdbB2;
		private System.Windows.Forms.RadioButton m_rdbB1;
		private System.Windows.Forms.GroupBox m_gpbC;
		private System.Windows.Forms.RadioButton m_rdbC2;
		private System.Windows.Forms.RadioButton m_rdbC1;
		private System.Windows.Forms.GroupBox m_gpbD;
		private System.Windows.Forms.GroupBox m_gpbE;
		private System.Windows.Forms.RadioButton m_rdbE5;
		private System.Windows.Forms.RadioButton m_rdbE1;
		private System.Windows.Forms.RadioButton m_rdbE2;
		private System.Windows.Forms.RadioButton m_rdbE3;
		private System.Windows.Forms.RadioButton m_rdbE4;
		private System.Windows.Forms.CheckBox m_chkE;
		private System.Windows.Forms.GroupBox m_gpbF;
		private System.Windows.Forms.RadioButton m_rdbF2;
		private System.Windows.Forms.RadioButton m_rdbF1;
		private System.Windows.Forms.RadioButton m_rdbD2;
		private System.Windows.Forms.RadioButton m_rdbD1;
		private System.ComponentModel.IContainer components = null;

		public frmBeforeAnaSummary()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
 			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_gpbA = new System.Windows.Forms.GroupBox();
			this.m_rdbA2 = new System.Windows.Forms.RadioButton();
			this.m_rdbA1 = new System.Windows.Forms.RadioButton();
			this.m_gpbB = new System.Windows.Forms.GroupBox();
			this.m_rdbB2 = new System.Windows.Forms.RadioButton();
			this.m_rdbB1 = new System.Windows.Forms.RadioButton();
			this.m_gpbC = new System.Windows.Forms.GroupBox();
			this.m_rdbC2 = new System.Windows.Forms.RadioButton();
			this.m_rdbC1 = new System.Windows.Forms.RadioButton();
			this.m_gpbD = new System.Windows.Forms.GroupBox();
			this.m_rdbD2 = new System.Windows.Forms.RadioButton();
			this.m_rdbD1 = new System.Windows.Forms.RadioButton();
			this.m_gpbE = new System.Windows.Forms.GroupBox();
			this.m_rdbE3 = new System.Windows.Forms.RadioButton();
			this.m_rdbE5 = new System.Windows.Forms.RadioButton();
			this.m_rdbE1 = new System.Windows.Forms.RadioButton();
			this.m_rdbE2 = new System.Windows.Forms.RadioButton();
			this.m_rdbE4 = new System.Windows.Forms.RadioButton();
			this.m_chkE = new System.Windows.Forms.CheckBox();
			this.m_gpbF = new System.Windows.Forms.GroupBox();
			this.m_rdbF2 = new System.Windows.Forms.RadioButton();
			this.m_rdbF1 = new System.Windows.Forms.RadioButton();
			this.m_cmdCancel = new System.Windows.Forms.Button();
			this.m_cmdOK = new System.Windows.Forms.Button();
			this.m_gpbA.SuspendLayout();
			this.m_gpbB.SuspendLayout();
			this.m_gpbC.SuspendLayout();
			this.m_gpbD.SuspendLayout();
			this.m_gpbE.SuspendLayout();
			this.m_gpbF.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_gpbA
			// 
			this.m_gpbA.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.m_rdbA2,
																				 this.m_rdbA1});
			this.m_gpbA.Location = new System.Drawing.Point(8, 8);
			this.m_gpbA.Name = "m_gpbA";
			this.m_gpbA.Size = new System.Drawing.Size(152, 44);
			this.m_gpbA.TabIndex = 29221;
			this.m_gpbA.TabStop = false;
			this.m_gpbA.Text = "诊断";
			// 
			// m_rdbA2
			// 
			this.m_rdbA2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbA2.Location = new System.Drawing.Point(60, 16);
			this.m_rdbA2.Name = "m_rdbA2";
			this.m_rdbA2.Size = new System.Drawing.Size(72, 24);
			this.m_rdbA2.TabIndex = 29217;
			this.m_rdbA2.Text = "不明确";
			// 
			// m_rdbA1
			// 
			this.m_rdbA1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbA1.Location = new System.Drawing.Point(4, 16);
			this.m_rdbA1.Name = "m_rdbA1";
			this.m_rdbA1.Size = new System.Drawing.Size(56, 24);
			this.m_rdbA1.TabIndex = 29216;
			this.m_rdbA1.Text = "明确";
			// 
			// m_gpbB
			// 
			this.m_gpbB.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.m_rdbB2,
																				 this.m_rdbB1});
			this.m_gpbB.Location = new System.Drawing.Point(180, 8);
			this.m_gpbB.Name = "m_gpbB";
			this.m_gpbB.Size = new System.Drawing.Size(156, 44);
			this.m_gpbB.TabIndex = 29250;
			this.m_gpbB.TabStop = false;
			this.m_gpbB.Text = "术前准备";
			// 
			// m_rdbB2
			// 
			this.m_rdbB2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbB2.Location = new System.Drawing.Point(60, 16);
			this.m_rdbB2.Name = "m_rdbB2";
			this.m_rdbB2.Size = new System.Drawing.Size(72, 24);
			this.m_rdbB2.TabIndex = 29217;
			this.m_rdbB2.Text = "不充分";
			// 
			// m_rdbB1
			// 
			this.m_rdbB1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbB1.Location = new System.Drawing.Point(4, 16);
			this.m_rdbB1.Name = "m_rdbB1";
			this.m_rdbB1.Size = new System.Drawing.Size(56, 24);
			this.m_rdbB1.TabIndex = 29216;
			this.m_rdbB1.Text = "充分";
			// 
			// m_gpbC
			// 
			this.m_gpbC.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.m_rdbC2,
																				 this.m_rdbC1});
			this.m_gpbC.Location = new System.Drawing.Point(8, 60);
			this.m_gpbC.Name = "m_gpbC";
			this.m_gpbC.Size = new System.Drawing.Size(152, 44);
			this.m_gpbC.TabIndex = 29252;
			this.m_gpbC.TabStop = false;
			this.m_gpbC.Text = "术式";
			// 
			// m_rdbC2
			// 
			this.m_rdbC2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbC2.Location = new System.Drawing.Point(60, 16);
			this.m_rdbC2.Name = "m_rdbC2";
			this.m_rdbC2.Size = new System.Drawing.Size(72, 24);
			this.m_rdbC2.TabIndex = 29217;
			this.m_rdbC2.Text = "不确定";
			// 
			// m_rdbC1
			// 
			this.m_rdbC1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbC1.Location = new System.Drawing.Point(4, 16);
			this.m_rdbC1.Name = "m_rdbC1";
			this.m_rdbC1.Size = new System.Drawing.Size(56, 24);
			this.m_rdbC1.TabIndex = 29216;
			this.m_rdbC1.Text = "确定";
			// 
			// m_gpbD
			// 
			this.m_gpbD.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.m_rdbD2,
																				 this.m_rdbD1});
			this.m_gpbD.Location = new System.Drawing.Point(180, 60);
			this.m_gpbD.Name = "m_gpbD";
			this.m_gpbD.Size = new System.Drawing.Size(156, 44);
			this.m_gpbD.TabIndex = 29254;
			this.m_gpbD.TabStop = false;
			this.m_gpbD.Text = "术野";
			// 
			// m_rdbD2
			// 
			this.m_rdbD2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbD2.Location = new System.Drawing.Point(60, 16);
			this.m_rdbD2.Name = "m_rdbD2";
			this.m_rdbD2.Size = new System.Drawing.Size(56, 24);
			this.m_rdbD2.TabIndex = 29217;
			this.m_rdbD2.Text = "小";
			// 
			// m_rdbD1
			// 
			this.m_rdbD1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbD1.Location = new System.Drawing.Point(4, 16);
			this.m_rdbD1.Name = "m_rdbD1";
			this.m_rdbD1.Size = new System.Drawing.Size(64, 24);
			this.m_rdbD1.TabIndex = 29216;
			this.m_rdbD1.Text = "大";
			// 
			// m_gpbE
			// 
			this.m_gpbE.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.m_chkE,
																				 this.m_rdbE3,
																				 this.m_rdbE2,
																				 this.m_rdbE5,
																				 this.m_rdbE1,
																				 this.m_rdbE4});
			this.m_gpbE.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_gpbE.Location = new System.Drawing.Point(8, 112);
			this.m_gpbE.Name = "m_gpbE";
			this.m_gpbE.Size = new System.Drawing.Size(328, 48);
			this.m_gpbE.TabIndex = 29255;
			this.m_gpbE.TabStop = false;
			this.m_gpbE.Text = "ASA分级";
			// 
			// m_rdbE3
			// 
			this.m_rdbE3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbE3.Location = new System.Drawing.Point(96, 16);
			this.m_rdbE3.Name = "m_rdbE3";
			this.m_rdbE3.Size = new System.Drawing.Size(52, 22);
			this.m_rdbE3.TabIndex = 550;
			this.m_rdbE3.Text = "Ⅲ";
			// 
			// m_rdbE5
			// 
			this.m_rdbE5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbE5.Location = new System.Drawing.Point(196, 16);
			this.m_rdbE5.Name = "m_rdbE5";
			this.m_rdbE5.Size = new System.Drawing.Size(52, 22);
			this.m_rdbE5.TabIndex = 551;
			this.m_rdbE5.Text = "Ⅴ";
			// 
			// m_rdbE1
			// 
			this.m_rdbE1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbE1.Location = new System.Drawing.Point(4, 16);
			this.m_rdbE1.Name = "m_rdbE1";
			this.m_rdbE1.Size = new System.Drawing.Size(60, 22);
			this.m_rdbE1.TabIndex = 553;
			this.m_rdbE1.Text = "Ⅰ";
			// 
			// m_rdbE2
			// 
			this.m_rdbE2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbE2.Location = new System.Drawing.Point(48, 16);
			this.m_rdbE2.Name = "m_rdbE2";
			this.m_rdbE2.Size = new System.Drawing.Size(60, 22);
			this.m_rdbE2.TabIndex = 554;
			this.m_rdbE2.Text = "Ⅱ";
			// 
			// m_rdbE4
			// 
			this.m_rdbE4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbE4.Location = new System.Drawing.Point(148, 16);
			this.m_rdbE4.Name = "m_rdbE4";
			this.m_rdbE4.Size = new System.Drawing.Size(56, 22);
			this.m_rdbE4.TabIndex = 552;
			this.m_rdbE4.Text = "Ⅳ";
			// 
			// m_chkE
			// 
			this.m_chkE.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_chkE.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_chkE.Location = new System.Drawing.Point(252, 16);
			this.m_chkE.Name = "m_chkE";
			this.m_chkE.Size = new System.Drawing.Size(72, 24);
			this.m_chkE.TabIndex = 555;
			this.m_chkE.Text = "急症病";
			this.m_chkE.CheckedChanged += new System.EventHandler(this.m_chkE_CheckedChanged);
			// 
			// m_gpbF
			// 
			this.m_gpbF.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.m_rdbF2,
																				 this.m_rdbF1});
			this.m_gpbF.Location = new System.Drawing.Point(8, 164);
			this.m_gpbF.Name = "m_gpbF";
			this.m_gpbF.Size = new System.Drawing.Size(136, 44);
			this.m_gpbF.TabIndex = 29257;
			this.m_gpbF.TabStop = false;
			this.m_gpbF.Text = "术后ICU";
			// 
			// m_rdbF2
			// 
			this.m_rdbF2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbF2.Location = new System.Drawing.Point(60, 16);
			this.m_rdbF2.Name = "m_rdbF2";
			this.m_rdbF2.Size = new System.Drawing.Size(72, 24);
			this.m_rdbF2.TabIndex = 29217;
			this.m_rdbF2.Text = "不需要";
			// 
			// m_rdbF1
			// 
			this.m_rdbF1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_rdbF1.Location = new System.Drawing.Point(4, 16);
			this.m_rdbF1.Name = "m_rdbF1";
			this.m_rdbF1.Size = new System.Drawing.Size(56, 24);
			this.m_rdbF1.TabIndex = 29216;
			this.m_rdbF1.Text = "需要";
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdCancel.Location = new System.Drawing.Point(252, 176);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Size = new System.Drawing.Size(84, 28);
			this.m_cmdCancel.TabIndex = 29265;
			this.m_cmdCancel.Text = "取  消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdOK.Location = new System.Drawing.Point(148, 176);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Size = new System.Drawing.Size(84, 28);
			this.m_cmdOK.TabIndex = 29264;
			this.m_cmdOK.Text = "确  定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// frmBeforeAnaSummary
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(340, 213);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_cmdCancel,
																		  this.m_cmdOK,
																		  this.m_gpbF,
																		  this.m_gpbE,
																		  this.m_gpbD,
																		  this.m_gpbA,
																		  this.m_gpbC,
																		  this.m_gpbB});
			this.MaximizeBox = false;
			this.Name = "frmBeforeAnaSummary";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "麻醉前小结";
			this.Load += new System.EventHandler(this.frmBeforeAnaSummary_Load);
			this.m_gpbA.ResumeLayout(false);
			this.m_gpbB.ResumeLayout(false);
			this.m_gpbC.ResumeLayout(false);
			this.m_gpbD.ResumeLayout(false);
			this.m_gpbE.ResumeLayout(false);
			this.m_gpbF.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmBeforeAnaSummary_Load(object sender, System.EventArgs e)
		{
			m_rdbA1.Focus();
		}

		/// <summary>
		/// 设置调用窗体的信息
		/// </summary>
		/// <param name="p_objParentForm"></param>
		public void m_mthSetParentForm(Form p_objParentForm,Control p_objSelectedControl)
		{
			m_mthSetParentFormBase(p_objParentForm,p_objSelectedControl);
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			string strOutputString = m_strGetOutPutString();
			m_mthSetControlText(strOutputString);
			this.Close();
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#region 获得输出文字
		/// <summary>
		/// 获得输出文字
		/// </summary>
		/// <returns>输出文字</returns>
		private string m_strGetOutPutString()
		{
			StringBuilder stbOut = new StringBuilder("");
			stbOut.Append(m_gpbA.Text);
			if(m_rdbA1.Checked)
				stbOut.Append(m_rdbA1.Text);
			if(m_rdbA2.Checked)
				stbOut.Append(m_rdbA2.Text);
			stbOut.Append("，");
			stbOut.Append(m_gpbB.Text);
			if(m_rdbB1.Checked)
				stbOut.Append(m_rdbB1.Text);
			if(m_rdbB2.Checked)
				stbOut.Append(m_rdbB2.Text);
			stbOut.Append("，");
			stbOut.Append(m_gpbC.Text);
			if(m_rdbC1.Checked)
				stbOut.Append(m_rdbC1.Text);
			if(m_rdbC2.Checked)
				stbOut.Append(m_rdbC2.Text);
			stbOut.Append("，");
			stbOut.Append(m_gpbD.Text);
			if(m_rdbD1.Checked)
				stbOut.Append(m_rdbD1.Text);
			if(m_rdbD2.Checked)
				stbOut.Append(m_rdbD2.Text);
			stbOut.Append("，");
			stbOut.Append(m_gpbE.Text);
			if(m_rdbE1.Checked)
				stbOut.Append(m_rdbE1.Text);
			if(m_rdbE2.Checked)
				stbOut.Append(m_rdbE2.Text);
			if(m_rdbE3.Checked)
				stbOut.Append(m_rdbE3.Text);
			if(m_rdbE4.Checked)
				stbOut.Append(m_rdbE4.Text);
			if(m_rdbE5.Checked)
				stbOut.Append(m_rdbE5.Text);
			stbOut.Append("，");
			stbOut.Append(m_gpbF.Text);
			if(m_rdbF1.Checked)
				stbOut.Append(m_rdbF1.Text);
			if(m_rdbF2.Checked)
				stbOut.Append(m_rdbF2.Text);
			return stbOut.ToString();
		}

		#endregion

		private void m_chkE_CheckedChanged(object sender, System.EventArgs e)
		{
			if(m_chkE.Checked)
			{
				m_rdbE1.Text = "EⅠ";
				m_rdbE2.Text = "EⅡ";
				m_rdbE3.Text = "EⅢ";
				m_rdbE4.Text = "EⅣ";
				m_rdbE5.Text = "EⅤ";
			}
			else
			{
				m_rdbE1.Text = "Ⅰ";
				m_rdbE2.Text = "Ⅱ";
				m_rdbE3.Text = "Ⅲ";
				m_rdbE4.Text = "Ⅳ";
				m_rdbE5.Text = "Ⅴ";
			}
		}
	}
}

