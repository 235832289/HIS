using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmAudingInvoice 的摘要说明。
	/// </summary>
	public class frmAudingInvoice : System.Windows.Forms.Form
	{
		private clsDcl_InvoiceManage m_objManage = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private com.digitalwave.controls.exTextBox txtID;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btExit;
		private com.digitalwave.controls.exTextBox txtName;
		private com.digitalwave.controls.exTextBox txtPS;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		public clsDcl_InvoiceManage DataServer
		{
			set
			{
			this.m_objManage =value;
			}
		}
		private string _strInv="";
		private string _strStatues ="";
		/// <summary>
		/// 用于PACS,验证成功,返回
		/// </summary>
		public bool m_blnUseByPacs = false;
        /// <summary>
        /// 用于门诊退票
        /// </summary>
        internal bool m_blnUseByInvoReturn = false;
        /// <summary>
        /// 原始开票人ID
        /// </summary>
        internal string m_strInvoCreatorID = string.Empty;
        /// <summary>
        /// 审核的限制权限，0-不限制，1-审核人与发票创建人不同则提示，2-审核人与发票创建人不同则卡死不通过
        /// </summary>
        internal string m_strLimitLevel = string.Empty;
		public frmAudingInvoice(string strInv,string strStatues)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_strInv =strInv;
			_strStatues =strStatues;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// p_blnUseByPacs为true用于PACS,验证成功,返回
		/// </summary>
		/// <param name="p_blnUseByPacs"></param>
		public frmAudingInvoice(bool p_blnUseByPacs)
		{
			m_blnUseByPacs = p_blnUseByPacs;
			InitializeComponent();
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btExit = new System.Windows.Forms.Button();
			this.btOK = new System.Windows.Forms.Button();
			this.txtPS = new com.digitalwave.controls.exTextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new com.digitalwave.controls.exTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtID = new com.digitalwave.controls.exTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(80, 52);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "工  号:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btExit);
			this.groupBox1.Controls.Add(this.btOK);
			this.groupBox1.Controls.Add(this.txtPS);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtName);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.txtID);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(16, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(408, 248);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "请输入工号和密码";
			// 
			// btExit
			// 
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btExit.Location = new System.Drawing.Point(232, 200);
			this.btExit.Name = "btExit";
			this.btExit.Size = new System.Drawing.Size(104, 32);
			this.btExit.TabIndex = 7;
			this.btExit.Text = "退出(ESC)";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btOK
			// 
			this.btOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btOK.Location = new System.Drawing.Point(56, 200);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(104, 32);
			this.btOK.TabIndex = 6;
			this.btOK.Text = "审核(&S)";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// txtPS
			// 
			this.txtPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtPS.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.txtPS.Location = new System.Drawing.Point(144, 152);
			this.txtPS.MaxLength = 16;
			this.txtPS.Name = "txtPS";
			this.txtPS.PasswordChar = '*';
			this.txtPS.SendTabKey = false;
			this.txtPS.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtPS.Size = new System.Drawing.Size(176, 26);
			this.txtPS.TabIndex = 5;
			this.txtPS.Text = "";
			this.txtPS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPS_KeyDown);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(80, 156);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 19);
			this.label3.TabIndex = 4;
			this.label3.Text = "密  码:";
			// 
			// txtName
			// 
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.Enabled = false;
			this.txtName.Location = new System.Drawing.Point(144, 100);
			this.txtName.MaxLength = 10;
			this.txtName.Name = "txtName";
			this.txtName.SendTabKey = false;
			this.txtName.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtName.Size = new System.Drawing.Size(176, 23);
			this.txtName.TabIndex = 3;
			this.txtName.Text = "";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(80, 104);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "姓  名:";
			// 
			// txtID
			// 
			this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtID.Location = new System.Drawing.Point(144, 48);
			this.txtID.MaxLength = 10;
			this.txtID.Name = "txtID";
			this.txtID.SendTabKey = false;
			this.txtID.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtID.Size = new System.Drawing.Size(176, 23);
			this.txtID.TabIndex = 1;
			this.txtID.Text = "";
			this.txtID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtID_KeyDown);
			// 
			// frmAudingInvoice
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.btExit;
			this.ClientSize = new System.Drawing.Size(440, 273);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmAudingInvoice";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "发票审核";
			this.Load += new System.EventHandler(this.frmAudingInvoice_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmAudingInvoice_Load(object sender, System.EventArgs e)
		{
			if(this.m_objManage==null)
			{
			this.m_objManage =new clsDcl_InvoiceManage();
			}
		}

		private void txtPS_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode ==Keys.Enter)
			{
			this.btOK.Focus();
			}
		}
		public string AudingName
		{
			get
			{
			return this.txtName.Text;
			}
		}
		private void btOK_Click(object sender, System.EventArgs e)
		{
			if(this.txtID.Tag==null)
			{
				MessageBox.Show("请输入工号");
				this.txtID.Focus();
				return;
			}
			if(this.txtPS.Tag.ToString().Trim()!=this.txtPS.Text.Trim())
			{
				MessageBox.Show("密码错误");
				this.txtPS.Focus();
				return;
			}
			//用于PACS,验证成功,返回
			if(m_blnUseByPacs)
			{
				this.DialogResult=DialogResult.OK;
				return;
			}
			//end
            //用于退票验证
            if (m_blnUseByInvoReturn)
            {
                if (!string.IsNullOrEmpty(m_strInvoCreatorID))
                {
                    if (m_strInvoCreatorID.Trim().CompareTo(this.txtID.Tag.ToString()) != 0)
                    {
                        switch (m_strLimitLevel)
                        {
                            case "0":
                                break;
                            case "1":
                                if (MessageBox.Show("发票不属于当前输入员工所开，是否确认审核?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
                                {
                                    return;
                                }
                                break;
                            case "2":
                                MessageBox.Show("发票不属于当前输入员工所开，不能审核当前发票", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            //break;
                            default:
                                break;
                        }
                    }
                }
            }
            //end
			if(MessageBox.Show("确认审核?","提示",MessageBoxButtons.YesNo)==DialogResult.No)
			{
			return;
			}
			clsInvAuditing_VO objVO =new clsInvAuditing_VO();
			objVO.strCF_DAT =DateTime.Now.ToString();
			objVO.strCFEMPID_CHR =this.txtID.Tag.ToString();
			objVO.strSEQID_CHR =_strInv;
			objVO.strSTATUS_INT =_strStatues;
			long ret =m_objManage.m_mthAddInvoiceAuditingInfo(objVO);
			if(ret >0)
			{
				MessageBox.Show("保存成功");
				this.DialogResult=DialogResult.OK;
			}
			else
			{
				MessageBox.Show("保存失败");
			}

		}

		private void txtID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(this.txtID.Text.Trim()=="")
				{
					MessageBox.Show("请输入工号");
					this.txtID.Focus();
					return;
				}
			    DataTable dt;
				long ret =m_objManage.m_mthGetEmployeeInfo(this.txtID.Text.Trim(),out dt,"");
				if(ret >0&&dt.Rows.Count>0)
				{
					this.txtName.Text =dt.Rows[0]["LASTNAME_VCHR"].ToString().Trim();
					this.txtID.Tag =dt.Rows[0]["empid_chr"].ToString().Trim();
                    //this.txtPS.Tag =dt.Rows[0]["psw_chr"].ToString().Trim();
                    clsSymmetricAlgorithm objAlgorithm = new clsSymmetricAlgorithm();
                    this.txtPS.Tag = objAlgorithm.m_strDecrypt(dt.Rows[0]["psw_chr"].ToString().Trim(), clsSymmetricAlgorithm.enmSymmetricAlgorithmType.DES);
					this.txtPS.Focus();
				}
				else
				{
					MessageBox.Show("输入的工号不正确");
					this.txtID.Focus();
					return;
				}
			}
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
