using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmGetItemByUsage 的摘要说明。
	/// </summary>
	public class frmGetItemByUsage :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		internal PinkieControls.ButtonXP btSave;
		private System.Windows.Forms.Label label1;
		internal PinkieControls.ButtonXP btExit;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private com.digitalwave.controls.NumTextBox txtTimes;
		private System.Windows.Forms.RadioButton ra_selectBack;
		private System.Windows.Forms.RadioButton ra_selectAll;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private clsDomainControl_ChargeItem clsDomain =new clsDomainControl_ChargeItem();
		public frmGetItemByUsage()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		public frmGetItemByUsage(string strFind)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			_strFind =strFind;
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ra_selectAll = new System.Windows.Forms.RadioButton();
			this.txtTimes = new com.digitalwave.controls.NumTextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btExit = new PinkieControls.ButtonXP();
			this.btSave = new PinkieControls.ButtonXP();
			this.ra_selectBack = new System.Windows.Forms.RadioButton();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader8,
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader10,
																						this.columnHeader11});
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(232, 516);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView1_KeyDown);
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "ID";
			this.columnHeader8.Width = 0;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "助记码";
			this.columnHeader1.Width = 58;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "用法名称";
			this.columnHeader2.Width = 148;
			// 
			// listView2
			// 
			this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView2.CheckBoxes = true;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader5,
																						this.columnHeader6,
																						this.columnHeader7,
																						this.columnHeader9});
			this.listView2.FullRowSelect = true;
			this.listView2.GridLines = true;
			this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView2.Location = new System.Drawing.Point(240, 0);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(474, 438);
			this.listView2.TabIndex = 1;
			this.listView2.View = System.Windows.Forms.View.Details;
			this.listView2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView2_ItemCheck);
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "助记码";
			this.columnHeader3.Width = 86;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "项目名称";
			this.columnHeader4.Width = 135;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "规格";
			this.columnHeader5.Width = 134;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "价格";
			this.columnHeader6.Width = 49;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "数量";
			this.columnHeader7.Width = 50;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "ID";
			this.columnHeader9.Width = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ra_selectAll);
			this.groupBox1.Controls.Add(this.txtTimes);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.btExit);
			this.groupBox1.Controls.Add(this.btSave);
			this.groupBox1.Controls.Add(this.ra_selectBack);
			this.groupBox1.Location = new System.Drawing.Point(240, 438);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(474, 78);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			// 
			// ra_selectAll
			// 
			this.ra_selectAll.Checked = true;
			this.ra_selectAll.Font = new System.Drawing.Font("宋体", 12F);
			this.ra_selectAll.Location = new System.Drawing.Point(138, 22);
			this.ra_selectAll.Name = "ra_selectAll";
			this.ra_selectAll.Size = new System.Drawing.Size(126, 24);
			this.ra_selectAll.TabIndex = 1;
			this.ra_selectAll.TabStop = true;
			this.ra_selectAll.Text = "全选(Ctrl+A)";
			this.ra_selectAll.Click += new System.EventHandler(this.ra_selectAll_Click);
			// 
			// txtTimes
			// 
			this.txtTimes.Location = new System.Drawing.Point(66, 36);
			this.txtTimes.MaxLength = 2;
			this.txtTimes.Name = "txtTimes";
			this.txtTimes.SendTabKey = true;
			this.txtTimes.SetFocusColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
			this.txtTimes.Size = new System.Drawing.Size(62, 23);
			this.txtTimes.TabIndex = 0;
			this.txtTimes.Text = "1";
			this.txtTimes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTimes_KeyDown);
			this.txtTimes.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimes_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 38);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 19);
			this.label1.TabIndex = 5;
			this.label1.Text = "倍数:";
			// 
			// btExit
			// 
			this.btExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btExit.DefaultScheme = true;
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btExit.Hint = "";
			this.btExit.Location = new System.Drawing.Point(376, 32);
			this.btExit.Name = "btExit";
			this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btExit.Size = new System.Drawing.Size(80, 32);
			this.btExit.TabIndex = 4;
			this.btExit.Text = "退出(ESC)";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btSave
			// 
			this.btSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btSave.DefaultScheme = true;
			this.btSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btSave.Hint = "";
			this.btSave.Location = new System.Drawing.Point(272, 32);
			this.btSave.Name = "btSave";
			this.btSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btSave.Size = new System.Drawing.Size(80, 32);
			this.btSave.TabIndex = 3;
			this.btSave.Text = "确定(&S)";
			this.btSave.Click += new System.EventHandler(this.btSave_Click);
			// 
			// ra_selectBack
			// 
			this.ra_selectBack.Font = new System.Drawing.Font("宋体", 12F);
			this.ra_selectBack.Location = new System.Drawing.Point(138, 48);
			this.ra_selectBack.Name = "ra_selectBack";
			this.ra_selectBack.Size = new System.Drawing.Size(126, 24);
			this.ra_selectBack.TabIndex = 2;
			this.ra_selectBack.Text = "反选(Ctrl+B)";
			this.ra_selectBack.Click += new System.EventHandler(this.ra_selectBack_Click);
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "五笔码";
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "拼音码";
			// 
			// frmGetItemByUsage
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.btExit;
			this.ClientSize = new System.Drawing.Size(720, 517);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.listView2);
			this.Controls.Add(this.listView1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmGetItemByUsage";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "根据用法获取收费项目";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmGetItemByUsage_KeyDown);
			this.Load += new System.EventHandler(this.frmGetItemByUsage_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		private string _strFind ="";
		public string StrFind
		{
			set
			{
			_strFind =value;
			}
		}
		private	com.digitalwave.iCare.ValueObject.clsChargeItem_VO[] _ItemResult;
		public com.digitalwave.iCare.ValueObject.clsChargeItem_VO[] ItemResult
		{
			get
			{
			return _ItemResult;
			}
		}
		private void frmGetItemByUsage_Load(object sender, System.EventArgs e)
		{
			com.digitalwave.iCare.ValueObject.clsUsageType_VO[] objResult = null;
			long lngRes=clsDomain.m_lngGetUsage(out objResult,_strFind);
			m_mthLoadCat();
			if(lngRes>0 && objResult!=null)
			{
				
				for(int i=0;i<objResult.Length;i++)
				{
					ListViewItem lv =new ListViewItem(objResult[i].m_strUsageID);
					lv.SubItems.Add(objResult[i].m_strUsageCode);
					lv.SubItems.Add(objResult[i].m_strUsageName);
					lv.SubItems.Add(objResult[i].m_strUsageWBCODE);
					lv.SubItems.Add(objResult[i].m_strUsagePYCODE);
					this.listView1.Items.Add(lv);
				}
				if(	this.listView1.Items.Count>0)
				{
					this.listView1.Items[0].Selected =true;
					this.listView1.Focus();
				}
			}
		
		}
		#region 获取项目
		#region 加载项目分类
		private void m_mthLoadCat()
		{
			clsDcl_DoctorWorkstation clsDomain=new clsDcl_DoctorWorkstation();
			
			long l=clsDomain.m_mthRelationInfo(out this.dt_RelationInfo);
			if(l<0)
			{
				MessageBox.Show("加载关系表失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		#endregion
		private void m_mthFillItem(string strID)
		{
			com.digitalwave.iCare.ValueObject.clsChargeItem_VO[] objResult = null;
			long lngRes = clsDomain.m_lngFindItemByUsageID(strID,out objResult);
			this.listView2.Items.Clear();
			if((lngRes>0)&&(objResult != null))
			{
				for(int i=0; i<objResult.Length;i++)
				{
					ListViewItem lv =new ListViewItem(objResult[i].m_strItemCode);
					lv.SubItems.Add(objResult[i].m_strItemName);
					lv.SubItems.Add(objResult[i].m_strItemSpec);
					lv.SubItems.Add(objResult[i].m_fltItemPrice.ToString());
					lv.SubItems.Add(objResult[i].m_strUNITPRICE);
					lv.SubItems.Add(objResult[i].m_strItemID);
					string strTemp =m_mthRelationInfo(objResult[i].m_ItemOPInvType.m_strTypeID);
					lv.Checked=true;
					if(strTemp =="0001"||strTemp =="0002")
					{	
//						strTemp ="";
						if(objResult[i].m_strINSURANCEID_CHR.Trim()!="0")
						{
							lv.ForeColor =System.Drawing.Color.Red;
//							strTemp ="缺药";
							lv.Checked=false;
						}
						
					}
					if(objResult[i].m_intIFSTOP_INT!=0)
					{
						lv.ForeColor =System.Drawing.Color.Gray;
						lv.Checked=false;
					}
					lv.Tag =objResult[i];
					this.listView2.Items.Add(lv);
				}
			}
		}
		#endregion

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count>0)
			{
			this.m_mthFillItem(this.listView1.SelectedItems[0].Text);
			}
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count>0)
			{
				this.txtTimes.Focus();
			}
		}

		private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			listView1_DoubleClick(this.listView1,null);
			}
		}

		private void txtTimes_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.btSave_Click(null,null);
			}
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
			_ItemResult =new com.digitalwave.iCare.ValueObject.clsChargeItem_VO[this.listView2.CheckedItems.Count];
			for(int i=0;i<this.listView2.CheckedItems.Count;i++)
			{
				_ItemResult[i] =this.listView2.CheckedItems[i].Tag as com.digitalwave.iCare.ValueObject.clsChargeItem_VO;
				if(this.txtTimes.Text.Trim()!="")
				{
					try
					{
						float fltTemp =float.Parse(_ItemResult[i].m_strUNITPRICE)*int.Parse(this.txtTimes.Text);
						_ItemResult[i].m_strUNITPRICE=	fltTemp.ToString();
					}
					catch
					{
					
					}
				}
			}
			this.DialogResult =DialogResult.OK;
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private void txtTimes_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar=='.')
			{
			e.Handled =true;
			}
		}

		private void ra_selectAll_Click(object sender, System.EventArgs e)
		{
			m_mthSelectAll();
		}
		private void m_mthSelectAll()
		{
			for(int i=0;i<this.listView2.Items.Count;i++)
			{
				this.listView2.Items[i].Checked=true;
			}
		}
		private void m_mthSelectBack()
		{
			for(int i=0;i<this.listView2.Items.Count;i++)
			{
				if(this.listView2.Items[i].Checked)
				{
					this.listView2.Items[i].Checked =false;
				}
				else
				{
					this.listView2.Items[i].Checked =true;
				}
			}
		}

		private void ra_selectBack_Click(object sender, System.EventArgs e)
		{
			m_mthSelectBack();
		}

		private void frmGetItemByUsage_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.Control)
			{
				if(e.KeyCode==Keys.A)
				{
					this.ra_selectAll.Checked =true;
					m_mthSelectAll();
				}
				if(e.KeyCode==Keys.B)
				{
					this.ra_selectBack.Checked =true;
					m_mthSelectBack();
				}
			}
		}

		private void listView2_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if(this.listView2.Items[e.Index].ForeColor==Color.Gray)
			{
				e.NewValue =CheckState.Unchecked;
			}
		}
		#region 查找对应表信息
		private DataTable dt_RelationInfo;
		private string m_mthRelationInfo(string strCatID)
		{
			string str="0005";//默认其他
			for(int i=0;i<this.dt_RelationInfo.Rows.Count;i++)
			{
				if(strCatID==this.dt_RelationInfo.Rows[i]["CATID_CHR"].ToString().Trim())
				{
					str=this.dt_RelationInfo.Rows[i]["GROUPID_CHR"].ToString().Trim();
					break;
				}
			}
			return str;
		}
		#endregion
	}
}
