using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using com.digitalwave.iCare.middletier.HI;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmPrintInvoice 的摘要说明。
	/// </summary>
	public class frmPrintInvoice: com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private com.digitalwave.controls.exTextBox txtInvoice;
		private System.Windows.Forms.TextBox txtPrint;
		private System.Windows.Forms.Label label6;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPrintInvoice()
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
			this.label1 = new System.Windows.Forms.Label();
			this.txtInvoice = new com.digitalwave.controls.exTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPrint = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(52, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(321, 27);
			this.label1.TabIndex = 0;
			this.label1.Text = "是否打印发票?是(Enter)否(ESC)";
			// 
			// txtInvoice
			// 
			this.txtInvoice.Location = new System.Drawing.Point(120, 72);
			this.txtInvoice.MaxLength = 10;
			this.txtInvoice.Name = "txtInvoice";
			this.txtInvoice.ReadOnly = true;
			this.txtInvoice.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtInvoice.Size = new System.Drawing.Size(184, 23);
			this.txtInvoice.TabIndex = 1;
			this.txtInvoice.Text = "";
			this.txtInvoice.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtInvoice_KeyDown);
			this.txtInvoice.TextChanged += new System.EventHandler(this.exTextBox1_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.SystemColors.Control;
			this.label2.Location = new System.Drawing.Point(56, 76);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "发票号:";
			// 
			// txtPrint
			// 
			this.txtPrint.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtPrint.Location = new System.Drawing.Point(120, 108);
			this.txtPrint.MaxLength = 1;
			this.txtPrint.Name = "txtPrint";
			this.txtPrint.Size = new System.Drawing.Size(32, 26);
			this.txtPrint.TabIndex = 15;
			this.txtPrint.Text = "0";
			this.txtPrint.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.txtPrint.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPrint_KeyDown);
			this.txtPrint.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrint_KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.label6.Location = new System.Drawing.Point(156, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(113, 19);
			this.label6.TabIndex = 14;
			this.label6.Text = "0 成功   1 重打";
			// 
			// frmPrintInvoice
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(424, 147);
			this.Controls.Add(this.txtPrint);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtInvoice);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmPrintInvoice";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "打印发票";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPrintInvoice_KeyDown);
			this.Load += new System.EventHandler(this.frmPrintInvoice_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void exTextBox1_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void frmPrintInvoice_Load(object sender, System.EventArgs e)
		{
//			this.m_strReadInvoiceNO();
		}
		#region 存取发票号
		
		public void m_strReadInvoiceNO()
		{
			try
			{
                string patXML = Application.StartupPath + "\\LoginFile.xml";
				if(File.Exists(patXML))
				{
					string strCurrEmpNO = "AnyOne"; 
　　            XmlDocument doc=new XmlDocument(); 
　　            doc.Load(patXML); 
					XmlNode xn = doc.DocumentElement.SelectNodes(@"//register")[0];
					XmlNode xnCurr = xn.SelectSingleNode(@"//InvoiceNo[@key='" + strCurrEmpNO + @"']");
					if(xnCurr != null)
					{
						int maxint=Convert.ToInt32(xnCurr.Attributes["value"].Value.Substring(2,8))+1;
						this.txtInvoice.Text =xnCurr.Attributes["value"].Value.Substring(0,2)+maxint.ToString("00000000");
					}
					else
					{
						this.txtInvoice.Text = "DW00000001";
					}
					

				}
			}
			catch
			{
				this.txtInvoice.Text = "DW00000001";
			}
		

		}

		public  void m_mthSaveInvoiceNO()
		{
            string patXML = Application.StartupPath + "\\LoginFile.xml";
			try
			{
				if(File.Exists(patXML))
				{
					string strCurrEmpNO = "AnyOne"; 
					XmlDocument doc=new XmlDocument(); 
					doc.Load(patXML); 
					XmlNode xn = doc.DocumentElement.SelectNodes(@"//register")[0];
					XmlNode xnCurr = xn.SelectSingleNode(@"//InvoiceNo[@key='" + strCurrEmpNO + @"']");
					if(xnCurr != null)
					{
						xnCurr.Attributes["value"].Value = this.txtInvoice.Text;
					}
					doc.Save(patXML);
				}
			}
			catch
			{
				MessageBox.Show("\t保存发票号失败,\n请检查\""+Application.StartupPath+"\\"+patXML+"\"是否只读!","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}


		#endregion
		#region 打印
		private void m_mthPrint()
		{
            clsCalcPatientCharge objTemp = new clsCalcPatientCharge("", "", 0, _objPC.m_strHospitalName, 1, 100);
			objTemp.m_mthPrintCharge(_objPC);
		}
	
		#endregion
		#region 打印信息
		private clsPatientChargeCal _objPC;

		private void txtPrint_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar.ToString()=="0"||e.KeyChar.ToString()=="1")
			{
			
			}
			else
			{
				e.Handled =true;
			}
		}

		private void txtInvoice_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.txtInvoice.Text.Trim().Length!=10)
				{
					MessageBox.Show("发票号有误,请检查发票号.");
					return ;
				}
				this.m_mthPrint();
//				this.m_mthSaveInvoiceNO();
				this.txtPrint.Focus();
				this.txtPrint.SelectAll();
			}
			
		}

		private void txtPrint_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(txtPrint.Text=="1")
				{
					this.m_mthPrint();
					this.txtPrint.Text="0";
				}
				else
				{
				this.Close();
				}
			}
		}

		private void frmPrintInvoice_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
			this.Close();
			}
		}
		/// <summary>
		/// 打印信息
		/// </summary>
		public clsPatientChargeCal objPC
		{
			set
			{
			_objPC =value;
			this.txtInvoice.Text =_objPC.m_strInvoiceNO;
			}
			
		}
		#endregion
	}
}
