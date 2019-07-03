using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmTurnMoney 的摘要说明。
	/// </summary>
	public class frmTurnMoney : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		private System.Windows.Forms.Label lbeSelfPay;
		private System.Windows.Forms.Label lbeSumMoney;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lbeChargeUp;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private com.digitalwave.controls.NumTextBox txtChargUp;
		internal PinkieControls.ButtonXP btOK;
		internal PinkieControls.ButtonXP btCancel;
		private com.digitalwave.controls.NumTextBox txtSelfPay;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmTurnMoney()
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
			this.lbeSelfPay = new System.Windows.Forms.Label();
			this.lbeSumMoney = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.lbeChargeUp = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.txtChargUp = new com.digitalwave.controls.NumTextBox();
			this.btOK = new PinkieControls.ButtonXP();
			this.btCancel = new PinkieControls.ButtonXP();
			this.txtSelfPay = new com.digitalwave.controls.NumTextBox();
			this.SuspendLayout();
			// 
			// lbeSelfPay
			// 
			this.lbeSelfPay.AutoSize = true;
			this.lbeSelfPay.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbeSelfPay.ForeColor = System.Drawing.Color.Maroon;
			this.lbeSelfPay.Location = new System.Drawing.Point(520, 90);
			this.lbeSelfPay.Name = "lbeSelfPay";
			this.lbeSelfPay.Size = new System.Drawing.Size(0, 40);
			this.lbeSelfPay.TabIndex = 9;
			// 
			// lbeSumMoney
			// 
			this.lbeSumMoney.AutoSize = true;
			this.lbeSumMoney.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbeSumMoney.Location = new System.Drawing.Point(204, 16);
			this.lbeSumMoney.Name = "lbeSumMoney";
			this.lbeSumMoney.Size = new System.Drawing.Size(0, 40);
			this.lbeSumMoney.TabIndex = 5;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(20, 90);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(192, 40);
			this.label4.TabIndex = 6;
			this.label4.Text = "原记帐金额:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(336, 90);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(192, 40);
			this.label2.TabIndex = 8;
			this.label2.Text = "原自付金额:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(20, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 40);
			this.label1.TabIndex = 4;
			this.label1.Text = "总  金  额:";
			// 
			// lbeChargeUp
			// 
			this.lbeChargeUp.AutoSize = true;
			this.lbeChargeUp.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lbeChargeUp.ForeColor = System.Drawing.Color.Maroon;
			this.lbeChargeUp.Location = new System.Drawing.Point(204, 90);
			this.lbeChargeUp.Name = "lbeChargeUp";
			this.lbeChargeUp.Size = new System.Drawing.Size(0, 40);
			this.lbeChargeUp.TabIndex = 7;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(16, 164);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(192, 40);
			this.label3.TabIndex = 10;
			this.label3.Text = "现记帐金额:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(336, 164);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(192, 40);
			this.label6.TabIndex = 11;
			this.label6.Text = "现自付金额:";
			// 
			// txtChargUp
			// 
			this.txtChargUp.Font = new System.Drawing.Font("宋体", 24F);
			this.txtChargUp.Location = new System.Drawing.Point(204, 160);
			this.txtChargUp.Name = "txtChargUp";
			this.txtChargUp.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtChargUp.Size = new System.Drawing.Size(116, 44);
			this.txtChargUp.TabIndex = 0;
			this.txtChargUp.Text = "";
			this.txtChargUp.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChargUp_KeyDown);
			this.txtChargUp.TextChanged += new System.EventHandler(this.txtChargUp_TextChanged);
			// 
			// btOK
			// 
			this.btOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btOK.DefaultScheme = true;
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btOK.Font = new System.Drawing.Font("宋体", 12F);
			this.btOK.Hint = "";
			this.btOK.Location = new System.Drawing.Point(100, 268);
			this.btOK.Name = "btOK";
			this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btOK.Size = new System.Drawing.Size(136, 48);
			this.btOK.TabIndex = 2;
			this.btOK.Text = "确定(&S)";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btCancel
			// 
			this.btCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btCancel.DefaultScheme = true;
			this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancel.Font = new System.Drawing.Font("宋体", 12F);
			this.btCancel.Hint = "";
			this.btCancel.Location = new System.Drawing.Point(400, 268);
			this.btCancel.Name = "btCancel";
			this.btCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btCancel.Size = new System.Drawing.Size(136, 48);
			this.btCancel.TabIndex = 3;
			this.btCancel.Text = "取消(ESC)";
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// txtSelfPay
			// 
			this.txtSelfPay.Font = new System.Drawing.Font("宋体", 24F);
			this.txtSelfPay.Location = new System.Drawing.Point(520, 160);
			this.txtSelfPay.Name = "txtSelfPay";
			this.txtSelfPay.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtSelfPay.Size = new System.Drawing.Size(116, 44);
			this.txtSelfPay.TabIndex = 1;
			this.txtSelfPay.Text = "";
			this.txtSelfPay.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChargUp_KeyDown);
			this.txtSelfPay.TextChanged += new System.EventHandler(this.txtChargUp_TextChanged);
			// 
			// frmTurnMoney
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.btCancel;
			this.ClientSize = new System.Drawing.Size(656, 345);
			this.Controls.Add(this.lbeSumMoney);
			this.Controls.Add(this.lbeChargeUp);
			this.Controls.Add(this.lbeSelfPay);
			this.Controls.Add(this.txtSelfPay);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.txtChargUp);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmTurnMoney";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "医保记账自付转换";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion
		#region 共公属性
		public decimal SumMondey
		{
			set
			{
			this.lbeSumMoney.Text =value.ToString("0.00");
			}
		}
		public decimal PersonMondey
		{
			set
			{
				this.lbeSelfPay.Text =value.ToString("0.00");
				this.txtSelfPay.Text =value.ToString("0.00");
			}
			get
			{
			return this.m_mthConvertObjToDecimal(this.txtSelfPay.Text);
			}
		}
		public decimal ChargeUpMondey
		{
			set
			{
				this.lbeChargeUp.Text =value.ToString("0.00");
				this.txtChargUp.Text =value.ToString("0.00");
			}
			get
			{
				return this.m_mthConvertObjToDecimal(this.txtChargUp.Text);
			}
		}
		#endregion
		private void btCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void txtChargUp_TextChanged(object sender, System.EventArgs e)
		{
			if(((TextBox)sender).Name=="txtChargUp")
			{
				this.txtSelfPay.TextChanged -= new System.EventHandler(this.txtChargUp_TextChanged);
				if(m_mthConvertObjToDecimal(txtChargUp.Text)<0)
				{
					this.txtChargUp.Text ="0";
				}
				if(m_mthConvertObjToDecimal(txtChargUp.Text)>m_mthConvertObjToDecimal(lbeSumMoney.Text))
				{
					this.txtChargUp.Text =this.lbeSumMoney.Text;
				}
				decimal decSelfPay =m_mthConvertObjToDecimal(lbeSumMoney.Text)-m_mthConvertObjToDecimal(txtChargUp.Text);
				this.txtSelfPay.Text =decSelfPay.ToString("0.00");
				this.txtSelfPay.TextChanged += new System.EventHandler(this.txtChargUp_TextChanged);
			}
			else
			{
					this.txtChargUp.TextChanged -= new System.EventHandler(this.txtChargUp_TextChanged);
				if(m_mthConvertObjToDecimal(txtSelfPay.Text)<0)
				{
					this.txtSelfPay.Text ="0";
				}
				if(m_mthConvertObjToDecimal(txtSelfPay.Text)>m_mthConvertObjToDecimal(lbeSumMoney.Text))
				{
					this.txtSelfPay.Text =this.lbeSumMoney.Text;
				}
				decimal decChargeUp =m_mthConvertObjToDecimal(lbeSumMoney.Text)-m_mthConvertObjToDecimal(txtSelfPay.Text);
				this.txtChargUp.Text =decChargeUp.ToString("0.00");
					this.txtChargUp.TextChanged += new System.EventHandler(this.txtChargUp_TextChanged);
			}
		}
		#region 转换成数字
		private decimal m_mthConvertObjToDecimal(object obj)
		{
			if( obj!=null&&obj.ToString()!="")
			{
				return Convert.ToDecimal(obj.ToString());

			}
			else
			{
				return 0;
			}
		}

		private void txtChargUp_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			SendKeys.SendWait("{Tab}");
			}
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			this.DialogResult =DialogResult.OK;
		}

		
	
		private decimal m_mthConvertObjToDecimal(string str)
		{
			try
			{
				return Convert.ToDecimal(str.Trim());
			}
			catch
			{
				return 0;
			}
		}
		#endregion
	}
}
