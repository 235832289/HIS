using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace  com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmChooseTestItem 的摘要说明。
	/// </summary>
	public class frmChooseTestItem : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton ra_selectBack;
		private System.Windows.Forms.RadioButton ra_selectAll;
		internal PinkieControls.ButtonXP btExit;
		internal PinkieControls.ButtonXP btOK;
		internal System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
        private int _row=0;
		public frmChooseTestItem(int row)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this._row =row;

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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btExit = new PinkieControls.ButtonXP();
			this.btOK = new PinkieControls.ButtonXP();
			this.ra_selectBack = new System.Windows.Forms.RadioButton();
			this.ra_selectAll = new System.Windows.Forms.RadioButton();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btExit);
			this.groupBox1.Controls.Add(this.btOK);
			this.groupBox1.Controls.Add(this.ra_selectBack);
			this.groupBox1.Controls.Add(this.ra_selectAll);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(521, 64);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			// 
			// btExit
			// 
			this.btExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btExit.DefaultScheme = true;
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btExit.Font = new System.Drawing.Font("宋体", 11F);
			this.btExit.Hint = "";
			this.btExit.Location = new System.Drawing.Point(392, 19);
			this.btExit.Name = "btExit";
			this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btExit.Size = new System.Drawing.Size(92, 32);
			this.btExit.TabIndex = 5;
			this.btExit.Text = "退出(ESC)";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btOK
			// 
			this.btOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btOK.DefaultScheme = true;
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btOK.Font = new System.Drawing.Font("宋体", 11F);
			this.btOK.Hint = "";
			this.btOK.Location = new System.Drawing.Point(240, 19);
			this.btOK.Name = "btOK";
			this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btOK.Size = new System.Drawing.Size(92, 32);
			this.btOK.TabIndex = 4;
			this.btOK.Text = "确定(&B)";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// ra_selectBack
			// 
			this.ra_selectBack.Location = new System.Drawing.Point(104, 25);
			this.ra_selectBack.Name = "ra_selectBack";
			this.ra_selectBack.Size = new System.Drawing.Size(80, 24);
			this.ra_selectBack.TabIndex = 3;
			this.ra_selectBack.Text = "反选";
			this.ra_selectBack.Click += new System.EventHandler(this.ra_selectBack_Click);
			// 
			// ra_selectAll
			// 
			this.ra_selectAll.Checked = true;
			this.ra_selectAll.Location = new System.Drawing.Point(24, 25);
			this.ra_selectAll.Name = "ra_selectAll";
			this.ra_selectAll.Size = new System.Drawing.Size(76, 20);
			this.ra_selectAll.TabIndex = 2;
			this.ra_selectAll.TabStop = true;
			this.ra_selectAll.Text = "全选";
			this.ra_selectAll.Click += new System.EventHandler(this.ra_selectAll_Click);
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.CheckBoxes = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4,
																						this.columnHeader5});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.GridLines = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.Location = new System.Drawing.Point(0, 64);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(521, 255);
			this.listView1.TabIndex = 1;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "编号";
			this.columnHeader1.Width = 72;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "项目名称";
			this.columnHeader2.Width = 170;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "规格";
			this.columnHeader3.Width = 116;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "单位";
			this.columnHeader4.Width = 65;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "单价";
			// 
			// frmChooseTestItem
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.btExit;
			this.ClientSize = new System.Drawing.Size(521, 319);
			this.Controls.Add(this.listView1);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmChooseTestItem";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "选择检验项目";
			this.Load += new System.EventHandler(this.frmChooseTestItem_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ra_selectAll_Click(object sender, System.EventArgs e)
		{
			m_mthSelectAll();
		}
		private void m_mthSelectAll()
		{
			for(int i=0;i<this.listView1.Items.Count;i++)
			{
				this.listView1.Items[i].Checked=true;
			}
		}
		private void m_mthSelectBack()
		{
			for(int i=0;i<this.listView1.Items.Count;i++)
			{
				if(this.listView1.Items[i].Checked)
				{
					this.listView1.Items[i].Checked =false;
				}
				else
				{
					this.listView1.Items[i].Checked =true;
				}
			}
		}

		private void ra_selectBack_Click(object sender, System.EventArgs e)
		{
		this.m_mthSelectBack();
		}
		public ListView ShowControl
		{
			get
			{
			return this.listView1;
			}
		}
		private int[] ret;
		private void btOK_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.CheckedItems.Count==0)
			{
				MessageBox.Show("请选择至少一个项目!","提示");
				return;
			}
		    ret =new int[this.listView1.CheckedItems.Count];
			for(int i=0;i<this.listView1.CheckedItems.Count;i++)
			{
				ret[i] =(int)this.listView1.CheckedItems[i].Tag;
			}
			this.DialogResult =DialogResult.OK;
		}

		private void frmChooseTestItem_Load(object sender, System.EventArgs e)
		{
			if(_row<this.listView1.Items.Count)
			{
				this.listView1.Items[_row].Checked =true;
			}
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	
		public int[] ChooseResult
		{
			get
			{
			return ret;
			}
		}
	}
}
