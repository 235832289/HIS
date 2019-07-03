using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmCasehistoryItemConfig 的摘要说明。
	/// </summary>
	public class frmCasehistoryItemConfig : System.Windows.Forms.Form
	{
		private	clsDomainControl_ChargeItem clsDomain;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		internal PinkieControls.ButtonXP btRight;
		internal PinkieControls.ButtonXP btLeft;
		internal PinkieControls.ButtonXP btRight2;
		internal PinkieControls.ButtonXP btLeft2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCasehistoryItemConfig()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			clsDomain=new clsDomainControl_ChargeItem();
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
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.btRight = new PinkieControls.ButtonXP();
			this.btLeft = new PinkieControls.ButtonXP();
			this.btRight2 = new PinkieControls.ButtonXP();
			this.btLeft2 = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.listView1.FullRowSelect = true;
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(160, 328);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "分类名称";
			this.columnHeader1.Width = 132;
			// 
			// listView2
			// 
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader2});
			this.listView2.FullRowSelect = true;
			this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView2.HideSelection = false;
			this.listView2.Location = new System.Drawing.Point(272, 0);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(244, 160);
			this.listView2.TabIndex = 1;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "不显示分类";
			this.columnHeader2.Width = 206;
			// 
			// listView3
			// 
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader3});
			this.listView3.FullRowSelect = true;
			this.listView3.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView3.HideSelection = false;
			this.listView3.Location = new System.Drawing.Point(272, 168);
			this.listView3.MultiSelect = false;
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(244, 160);
			this.listView3.TabIndex = 2;
			this.listView3.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "在辅助检查显示分类";
			this.columnHeader3.Width = 215;
			// 
			// btRight
			// 
			this.btRight.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btRight.DefaultScheme = true;
			this.btRight.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btRight.Hint = "";
			this.btRight.Location = new System.Drawing.Point(180, 44);
			this.btRight.Name = "btRight";
			this.btRight.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btRight.Size = new System.Drawing.Size(72, 24);
			this.btRight.TabIndex = 3;
			this.btRight.Text = "→";
			this.btRight.Click += new System.EventHandler(this.btRight_Click);
			// 
			// btLeft
			// 
			this.btLeft.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btLeft.DefaultScheme = true;
			this.btLeft.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btLeft.Hint = "";
			this.btLeft.Location = new System.Drawing.Point(180, 92);
			this.btLeft.Name = "btLeft";
			this.btLeft.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btLeft.Size = new System.Drawing.Size(72, 24);
			this.btLeft.TabIndex = 4;
			this.btLeft.Text = "←";
			this.btLeft.Click += new System.EventHandler(this.btLeft_Click);
			// 
			// btRight2
			// 
			this.btRight2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btRight2.DefaultScheme = true;
			this.btRight2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btRight2.Hint = "";
			this.btRight2.Location = new System.Drawing.Point(180, 232);
			this.btRight2.Name = "btRight2";
			this.btRight2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btRight2.Size = new System.Drawing.Size(72, 24);
			this.btRight2.TabIndex = 5;
			this.btRight2.Text = "→";
			this.btRight2.Click += new System.EventHandler(this.btRight2_Click);
			// 
			// btLeft2
			// 
			this.btLeft2.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btLeft2.DefaultScheme = true;
			this.btLeft2.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btLeft2.Hint = "";
			this.btLeft2.Location = new System.Drawing.Point(180, 272);
			this.btLeft2.Name = "btLeft2";
			this.btLeft2.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btLeft2.Size = new System.Drawing.Size(72, 24);
			this.btLeft2.TabIndex = 6;
			this.btLeft2.Text = "←";
			this.btLeft2.Click += new System.EventHandler(this.btLeft2_Click);
			// 
			// frmCasehistoryItemConfig
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(516, 329);
			this.Controls.Add(this.btLeft2);
			this.Controls.Add(this.btRight2);
			this.Controls.Add(this.btLeft);
			this.Controls.Add(this.btRight);
			this.Controls.Add(this.listView3);
			this.Controls.Add(this.listView2);
			this.Controls.Add(this.listView1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "frmCasehistoryItemConfig";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "病历";
			this.Load += new System.EventHandler(this.frmCasehistoryItemConfig_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmCasehistoryItemConfig_Load(object sender, System.EventArgs e)
		{
			this.m_mthLoadData();
		}
		#region
		private void m_mthLoadData()
		{
			 clsChargeItemEXType_VO[] objResult=null;
			long l=clsDomain.m_GetEXType("2",out objResult);
			if(l>0&&objResult!=null)
			{
				ListViewItem lv;
				for(int i=0;i<objResult.Length;i++)
				{
				lv =new ListViewItem(objResult[i].m_strTypeName);
				lv.Tag =objResult[i].m_strTypeID;
				this.listView1.Items.Add(lv);
				}
			}
			DataTable dt;
			l =clsDomain.m_mthGetCASEHISCHR("",out dt);
			if(l>0&&dt.Rows.Count>0)
			{
				ListViewItem lv;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					lv =new ListViewItem(dt.Rows[i]["TYPENAME_VCHR"].ToString().Trim());
					lv.Tag =dt.Rows[i]["TYPEID_CHR"].ToString().Trim();
					if(dt.Rows[i]["SEQID_CHR"].ToString().Trim()=="1")
					{
						this.listView2.Items.Add(lv);
					}
					else
					{
						this.listView3.Items.Add(lv);
					}
				}
			}
		}
		#endregion

		private void btRight_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count==0)
			{
				return;
			}
			string strID =this.listView1.SelectedItems[0].Tag.ToString();
			bool temp =false;
			for(int i=0;i<this.listView2.Items.Count;i++)
			{
				if(strID ==this.listView2.Items[i].Tag.ToString())
				{
				temp  =true;
				break;
				}
			}
			if(!temp)
			{
				for(int i2=0;i2<this.listView3.Items.Count;i2++)
				{
					if(strID ==this.listView3.Items[i2].Tag.ToString())
					{
						temp  =true;
						break;
					}
				}
			}
			if(temp)
			{
				MessageBox.Show("分类已经存在");
				return ;
			}
			else
			{
				long l =clsDomain.m_mthInsertCASEHISCHR("1",strID,this.listView1.SelectedItems[0].Text);
				if(l>0)
				{
					ListViewItem lv =new ListViewItem(listView1.SelectedItems[0].Text);
					lv.Tag =strID;
					this.listView2.Items.Add(lv);
				}
				else
				{
				MessageBox.Show("保存失败");
				}
			}
		}

		private void btLeft_Click(object sender, System.EventArgs e)
		{
			if(this.listView2.SelectedItems.Count==0)
			{
				return;
			}
			string strID =this.listView2.SelectedItems[0].Tag.ToString();
			long l =clsDomain.m_mthDeleteCASEHISCHR("1",strID);
			if(l>0)
			{
				this.listView2.SelectedItems[0].Remove();
			}
			else
			{
				MessageBox.Show("删除失败");
			}
		}

		private void btRight2_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count==0)
			{
				return;
			}
			string strID =this.listView1.SelectedItems[0].Tag.ToString();
			bool temp =false;
			for(int i=0;i<this.listView2.Items.Count;i++)
			{
				if(strID ==this.listView2.Items[i].Tag.ToString())
				{
					temp  =true;
					break;
				}
			}
			if(!temp)
			{
				for(int i2=0;i2<this.listView3.Items.Count;i2++)
				{
					if(strID ==this.listView3.Items[i2].Tag.ToString())
					{
						temp  =true;
						break;
					}
				}
			}
			if(temp)
			{
				MessageBox.Show("分类已经存在");
				return ;
			}
			else
			{
				long l =clsDomain.m_mthInsertCASEHISCHR("2",strID,this.listView1.SelectedItems[0].Text);
				if(l>0)
				{
					ListViewItem lv =new ListViewItem(listView1.SelectedItems[0].Text);
					lv.Tag =strID;
					this.listView3.Items.Add(lv);
				}
				else
				{
					MessageBox.Show("保存失败");
				}
			}
		}

		private void btLeft2_Click(object sender, System.EventArgs e)
		{
			if(this.listView3.SelectedItems.Count==0)
			{
				return;
			}
			string strID =this.listView3.SelectedItems[0].Tag.ToString();
			long l =clsDomain.m_mthDeleteCASEHISCHR("2",strID);
			if(l>0)
			{
				this.listView3.SelectedItems[0].Remove();
			}
			else
			{
				MessageBox.Show("删除失败");
			}
		}
	}
}
