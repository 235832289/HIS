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
	/// 单据配置
	/// </summary>
	public class frmUseOrderSet :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListView m_lsvAll;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private PinkieControls.ButtonXP m_cmdAdd;
		private PinkieControls.ButtonXP m_cmdSub;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		private int m_intTypeindex;
		private string m_strUsageID;
		private string m_strUSAGEOrderName;
		public System.Windows.Forms.ListView m_lsvUse;
        private PinkieControls.ButtonXP m_cmdClose;
        private ColumnHeader columnHeader5;
        private GroupBox groupBox3;
        private ColumnHeader columnHeader6;
		private string m_strOrderIdGroup;
		public frmUseOrderSet(int p_intTypeindex,string p_strUsageID,string p_strOrderIdGroup,string p_strUSAGEOrderName)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			m_intTypeindex = p_intTypeindex;
			m_strUsageID = p_strUsageID;
			m_strUSAGEOrderName = p_strUSAGEOrderName;
			m_strOrderIdGroup = p_strOrderIdGroup;

			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}

		/// <summary>
		/// 查询所有单据t_bse_nurseorder
		/// </summary>
		private void m_FillUsageORDERID()
		{
			clsUsageType_VO[] objResult;
			 clsDcl_ChargeItem objSvc= new clsDcl_ChargeItem();
			long lngRes=objSvc.m_lngFindAllORDERIDFromT_bse_nurseorder(out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem li = null;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					 li = new ListViewItem(objResult[i1].m_strUsageID);//单据ID
					li.SubItems.Add(objResult[i1].m_strUsageName);
                    if (objResult[i1].m_intFlag == 0)
                    {
                        li.SubItems.Add("门诊");
                    }
                    else if (objResult[i1].m_intFlag == 1)
                    {
                        li.SubItems.Add("住院");
                    }
					li.Tag = objResult[i1];
					this.m_lsvAll.Items.Add(li);
				}
			}
			if(m_lsvAll.Items.Count>0)
			{
				m_lsvAll.HideSelection = false;
				m_lsvAll.Items[0].Selected=true;
			}
		}
		/// <summary>
		/// 查询所属单据
		/// </summary>
		private void m_FillOwnerUsage(string p_strUsageID,int p_intTypeindex)
		{
			clsDomainControl_ChargeItem objsvc = new clsDomainControl_ChargeItem();
			DataTable dt = new DataTable();
			long res= objsvc.m_lngGetData("SELECT * FROM t_opr_setusage t1,t_bse_nurseorder t2 where t1.orderid_vchr=t2.orderid_int(+)  and t1.TYPE_INT="+p_intTypeindex.ToString() +" and t1.USAGEID_CHR='"+p_strUsageID+"'",out dt);
			if(res >0)
			{
				m_mthBindListViewByDataTable(dt,this.m_lsvUse);
			}

			#region bak
//			string[] strID = p_strOrderIdGroup.Split('|');
//			string[] strName = p_strUSAGEOrderName.Split(',');
//			ListViewItem li = null;
//			for(int i1=0;i1<strName.Length;i1++)
//			{
//				if(strID[i1] != "")
//				{
//					li = new ListViewItem(strID[i1]);//单据ID
//					li.SubItems.Add(strName[i1]);
//					this.m_lsvUse .Items.Add(li);
//				}
//			}			
//			if(m_lsvUse.Items.Count>0)
//			{
//				m_lsvUse.HideSelection = false;
//				m_lsvUse.Items[0].Selected=true;
//			}
			#endregion
		}
		#region 根据数据源绑定ListView,的代码框架
		/// <summary>
		/// 根据数据源绑定ListView,的代码框架
		/// </summary>
		/// <param name="p_dtSource">数据源</param>
		/// <param name="p_lsv">目标LV</param>
		public void m_mthBindListViewByDataTable(DataTable p_dtSource,ListView p_lsv)
		{
			p_lsv.Items.Clear();
			if (p_dtSource.Rows.Count > 0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<p_dtSource.Rows.Count;i1++)
				{
					if(p_dtSource.Rows[i1]["ORDERID_VCHR"].ToString().Trim() != "")
					{
						lvw=new ListViewItem(p_dtSource.Rows[i1]["ORDERID_VCHR"].ToString().Trim());
				
						lvw.SubItems.Add(p_dtSource.Rows[i1]["ORDERNAME_VCHR"].ToString().Trim());
                        if (p_dtSource.Rows[i1]["FLAG_INT"].ToString().Trim() != string.Empty)
                        {
                            if (int.Parse(p_dtSource.Rows[i1]["FLAG_INT"].ToString().Trim()) == 0)
                            {
                                lvw.SubItems.Add("门诊");
                            }
                            else if (int.Parse(p_dtSource.Rows[i1]["FLAG_INT"].ToString().Trim()) == 1)
                            {
                                lvw.SubItems.Add("住院");
                            }
                        }
						lvw.Tag=p_dtSource.Rows[i1];
						p_lsv.Items.Add(lvw);
					}
				}
			}
			if(p_lsv.Items.Count>0)
			{
				p_lsv.HideSelection = false;
				p_lsv.Items[0].Selected=true;
			}
		}
		#endregion 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUseOrderSet));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lsvAll = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lsvUse = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdAdd = new PinkieControls.ButtonXP();
            this.m_cmdSub = new PinkieControls.ButtonXP();
            this.m_cmdClose = new PinkieControls.ButtonXP();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_lsvAll);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(279, 439);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "所有单据类型";
            // 
            // m_lsvAll
            // 
            this.m_lsvAll.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader5});
            this.m_lsvAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvAll.FullRowSelect = true;
            this.m_lsvAll.GridLines = true;
            this.m_lsvAll.HideSelection = false;
            this.m_lsvAll.Location = new System.Drawing.Point(3, 19);
            this.m_lsvAll.Name = "m_lsvAll";
            this.m_lsvAll.Size = new System.Drawing.Size(273, 417);
            this.m_lsvAll.TabIndex = 0;
            this.m_lsvAll.UseCompatibleStateImageBehavior = false;
            this.m_lsvAll.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "单据编号";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "单据名称";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 138;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_lsvUse);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Location = new System.Drawing.Point(421, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(272, 439);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "所属单据";
            // 
            // m_lsvUse
            // 
            this.m_lsvUse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader6});
            this.m_lsvUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lsvUse.FullRowSelect = true;
            this.m_lsvUse.GridLines = true;
            this.m_lsvUse.HideSelection = false;
            this.m_lsvUse.Location = new System.Drawing.Point(3, 19);
            this.m_lsvUse.Name = "m_lsvUse";
            this.m_lsvUse.Size = new System.Drawing.Size(266, 417);
            this.m_lsvUse.TabIndex = 1;
            this.m_lsvUse.UseCompatibleStateImageBehavior = false;
            this.m_lsvUse.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "单据编号";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "单据名称";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 130;
            // 
            // m_cmdAdd
            // 
            this.m_cmdAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdAdd.DefaultScheme = true;
            this.m_cmdAdd.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdAdd.Hint = "";
            this.m_cmdAdd.Location = new System.Drawing.Point(303, 184);
            this.m_cmdAdd.Name = "m_cmdAdd";
            this.m_cmdAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdAdd.Size = new System.Drawing.Size(104, 32);
            this.m_cmdAdd.TabIndex = 2;
            this.m_cmdAdd.Text = "-->";
            this.m_cmdAdd.Click += new System.EventHandler(this.m_cmdAdd_Click);
            // 
            // m_cmdSub
            // 
            this.m_cmdSub.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdSub.DefaultScheme = true;
            this.m_cmdSub.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSub.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cmdSub.Hint = "";
            this.m_cmdSub.Location = new System.Drawing.Point(303, 236);
            this.m_cmdSub.Name = "m_cmdSub";
            this.m_cmdSub.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSub.Size = new System.Drawing.Size(104, 32);
            this.m_cmdSub.TabIndex = 3;
            this.m_cmdSub.Text = "<--";
            this.m_cmdSub.Click += new System.EventHandler(this.m_cmdSub_Click);
            // 
            // m_cmdClose
            // 
            this.m_cmdClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_cmdClose.DefaultScheme = true;
            this.m_cmdClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdClose.Hint = "";
            this.m_cmdClose.Location = new System.Drawing.Point(304, 285);
            this.m_cmdClose.Name = "m_cmdClose";
            this.m_cmdClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdClose.Size = new System.Drawing.Size(104, 32);
            this.m_cmdClose.TabIndex = 4;
            this.m_cmdClose.Text = "关闭(&ESC)";
            this.m_cmdClose.Click += new System.EventHandler(this.m_cmdClose_Click);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "单据分类";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 130;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.m_cmdClose);
            this.groupBox3.Controls.Add(this.m_cmdAdd);
            this.groupBox3.Controls.Add(this.m_cmdSub);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(696, 461);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "单据分类";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 130;
            // 
            // frmUseOrderSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(696, 461);
            this.Controls.Add(this.groupBox3);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmUseOrderSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单据配置";
            this.Load += new System.EventHandler(this.frmUseOrderSet_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmUseOrderSet_Load(object sender, System.EventArgs e)
		{
				m_FillUsageORDERID();
			   m_FillOwnerUsage(this.m_strUsageID,this.m_intTypeindex);
		}

		private void m_cmdAdd_Click(object sender, System.EventArgs e)
		{
			if(m_lsvAll.SelectedItems.Count>0)
			{
				for(int i1=0;i1<m_lsvUse.Items.Count;i1++)
				{
					if (this.m_lsvUse.Items[i1].SubItems[0].Text.ToString().Trim() == this.m_lsvAll.SelectedItems[0].SubItems[0].Text.ToString().Trim())
					{
						MessageBox.Show("该单据已存在！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
						m_lsvUse.Focus();
						for(int j=0;j<this.m_lsvUse.Items.Count;j++)
							this.m_lsvUse.Items[j].Selected = false;
						m_lsvUse.Items[i1].Selected=true;
						return;
					}
				}			
				this.m_strOrderIdGroup = this.m_lsvAll.SelectedItems[0].SubItems[0].Text.ToString().Trim();
				clsDomainControl_ChargeItem objSvc= new clsDomainControl_ChargeItem();
				long lngRes = objSvc.m_lngDoUpdUsageorderid_vchrByIDAndTypeId(this.m_intTypeindex,this.m_strUsageID,this.m_strOrderIdGroup,true);
				if(lngRes >0)
				{
					ListViewItem lvw;
					lvw=new ListViewItem(this.m_lsvAll.SelectedItems[0].SubItems[0].Text.ToString().Trim());
					lvw.SubItems.Add(this.m_lsvAll.SelectedItems[0].SubItems[1].Text.ToString().Trim());
                    lvw.SubItems.Add(this.m_lsvAll.SelectedItems[0].SubItems[2].Text.ToString().Trim());
					this.m_lsvUse.Items.Add(lvw);
				}
			}
		}

		private void m_cmdSub_Click(object sender, System.EventArgs e)
		{
			if(m_lsvUse.SelectedItems.Count>0)
			{
				int index=m_lsvUse.SelectedIndices[0];
				if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2)==DialogResult.No)
					return;
				string strId = this.m_lsvUse.SelectedItems[0].SubItems[0].Text.ToString().Trim();

				clsDomainControl_ChargeItem objSvc= new clsDomainControl_ChargeItem();
				long lngRes = objSvc.m_lngDoUpdUsageorderid_vchrByIDAndTypeId(this.m_intTypeindex,this.m_strUsageID,strId,false);
				if(lngRes>0)
				{
					m_strOrderIdGroup = strId;
					m_lsvUse.Items.Remove(m_lsvUse.SelectedItems[0]);
			
					if(m_lsvUse.Items.Count>0)
					{
						if(index>0)
							m_lsvUse.Items[index-1].Selected=true;
						else
							m_lsvUse.Items[index].Selected=true;
					}
				}
			}
		}

		private void m_cmdClose_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
