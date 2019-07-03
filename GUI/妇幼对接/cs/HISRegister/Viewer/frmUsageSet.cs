using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmUsageSet 的摘要说明。
	/// </summary>
	public class frmUsageSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.ListView m_lvw;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private PinkieControls.ButtonXP m_btnSave;
		private PinkieControls.ButtonXP m_btnDel;
		private System.Windows.Forms.GroupBox groupBox1;
		internal System.Windows.Forms.ComboBox m_cmbType;
		private System.Windows.Forms.Label m_lblREMARK_VCHR;
		private System.Windows.Forms.GroupBox groupBox2;
		internal System.Windows.Forms.ListView m_lvw2;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmUsageSet()
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
            this.m_lvw = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_btnSave = new PinkieControls.ButtonXP();
            this.m_btnDel = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_lblREMARK_VCHR = new System.Windows.Forms.Label();
            this.m_cmbType = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_lvw2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lvw
            // 
            this.m_lvw.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lvw.FullRowSelect = true;
            this.m_lvw.GridLines = true;
            this.m_lvw.HideSelection = false;
            this.m_lvw.Location = new System.Drawing.Point(16, 16);
            this.m_lvw.MultiSelect = false;
            this.m_lvw.Name = "m_lvw";
            this.m_lvw.Size = new System.Drawing.Size(288, 512);
            this.m_lvw.TabIndex = 7;
            this.m_lvw.UseCompatibleStateImageBehavior = false;
            this.m_lvw.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "用法编号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "用法名称";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 200;
            // 
            // m_btnSave
            // 
            this.m_btnSave.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnSave.DefaultScheme = true;
            this.m_btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnSave.Hint = "";
            this.m_btnSave.Location = new System.Drawing.Point(336, 272);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnSave.Size = new System.Drawing.Size(96, 24);
            this.m_btnSave.TabIndex = 9;
            this.m_btnSave.Text = "->";
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnDel
            // 
            this.m_btnDel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnDel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btnDel.DefaultScheme = true;
            this.m_btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btnDel.Hint = "";
            this.m_btnDel.Location = new System.Drawing.Point(336, 304);
            this.m_btnDel.Name = "m_btnDel";
            this.m_btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btnDel.Size = new System.Drawing.Size(96, 24);
            this.m_btnDel.TabIndex = 10;
            this.m_btnDel.Text = "<-";
            this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(8, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 536);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "所有用法";
            // 
            // m_lblREMARK_VCHR
            // 
            this.m_lblREMARK_VCHR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_lblREMARK_VCHR.AutoSize = true;
            this.m_lblREMARK_VCHR.Location = new System.Drawing.Point(316, 244);
            this.m_lblREMARK_VCHR.Name = "m_lblREMARK_VCHR";
            this.m_lblREMARK_VCHR.Size = new System.Drawing.Size(42, 14);
            this.m_lblREMARK_VCHR.TabIndex = 49;
            this.m_lblREMARK_VCHR.Text = "分类:";
            this.m_lblREMARK_VCHR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cmbType
            // 
            this.m_cmbType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbType.Items.AddRange(new object[] {
            "注射",
            "治疗",
            "手术",
            "输血",
            "其他"});
            this.m_cmbType.Location = new System.Drawing.Point(360, 240);
            this.m_cmbType.Name = "m_cmbType";
            this.m_cmbType.Size = new System.Drawing.Size(64, 22);
            this.m_cmbType.TabIndex = 0;
            this.m_cmbType.SelectedValueChanged += new System.EventHandler(this.m_cmbType_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.m_lvw2);
            this.groupBox2.Location = new System.Drawing.Point(440, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(568, 536);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "分类方法";
            // 
            // m_lvw2
            // 
            this.m_lvw2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.m_lvw2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.m_lvw2.FullRowSelect = true;
            this.m_lvw2.GridLines = true;
            this.m_lvw2.HideSelection = false;
            this.m_lvw2.Location = new System.Drawing.Point(8, 24);
            this.m_lvw2.MultiSelect = false;
            this.m_lvw2.Name = "m_lvw2";
            this.m_lvw2.Size = new System.Drawing.Size(552, 504);
            this.m_lvw2.TabIndex = 9;
            this.m_lvw2.UseCompatibleStateImageBehavior = false;
            this.m_lvw2.View = System.Windows.Forms.View.Details;
            this.m_lvw2.DoubleClick += new System.EventHandler(this.m_lvw2_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "用法编号";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 80;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "用法名称";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 150;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "分类";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 70;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "所属单据名称";
            this.columnHeader8.Width = 230;
            // 
            // frmUsageSet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1016, 541);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.m_btnSave);
            this.Controls.Add(this.m_btnDel);
            this.Controls.Add(this.m_lblREMARK_VCHR);
            this.Controls.Add(this.m_lvw);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.m_cmbType);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.KeyPreview = true;
            this.Name = "frmUsageSet";
            this.Text = "用法项目设置";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmUsageSet_KeyDown);
            this.Load += new System.EventHandler(this.frmUsageSet_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlUsageSet();
			objController.Set_GUI_Apperance(this);
		}


		public new void Show_MDI_Child(Form frmMDI_Parent)
		{
			this.ShowDialog();
		}


		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//((clsControlUsageSet)this.objController).m_selectByCondition();
		
		}

		private void frmUsageSet_Load(object sender, System.EventArgs e)
		{
			((clsControlUsageSet)this.objController).m_GetUsageList();
			//((clsControlUsageSet)this.objController).m_GetSetUsageList();
			this.m_cmbType.SelectedIndex=0;
((clsControlUsageSet)this.objController).m_selectByCondition();
		}

		private void m_btnSave_Click(object sender, System.EventArgs e)
		{
			if (this.m_lvw.SelectedItems.Count == 1)
			{
				((clsControlUsageSet)this.objController).insertType1();
			}
		}

		

		private void m_btnDel_Click(object sender, System.EventArgs e)
		{
			if (this.m_lvw2.SelectedItems.Count==1)
			{
				((clsControlUsageSet)this.objController).m_delSet();
			}
		}

		private void frmUsageSet_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				this.Close();
			}
		}

		private void m_cmbType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		    ((clsControlUsageSet)this.objController).m_selectByCondition();
		}

		private void m_lvw2_DoubleClick(object sender, System.EventArgs e)
		{
			int index = m_cmbType.SelectedIndex + 1;
			if(this.m_lvw2.SelectedItems.Count>0)
			{
				string strOrderIdGroup = this.m_lvw2.SelectedItems[0].Tag.ToString() ; 
				string strUSAGEID_CHR = this.m_lvw2.SelectedItems[0].SubItems[0].Text.Trim().PadLeft(4,'0');
				string strUSAGEOrderName = this.m_lvw2.SelectedItems[0].SubItems[4].Text.Trim();
				
				frmUseOrderSet frmOrder = new frmUseOrderSet(index, strUSAGEID_CHR,strOrderIdGroup,strUSAGEOrderName);
				frmOrder.Text = "用法["+this.m_lvw2.SelectedItems[0].SubItems[2].Text.Trim()+"]单据配置";
				frmOrder.ShowDialog();
				string str = "";
				for(int i=0;i<frmOrder.m_lsvUse.Items.Count;++i)
				{
					str += frmOrder.m_lsvUse.Items[i].SubItems[1].Text.Trim()+",";
				}
				if(str.EndsWith(","))
					str = str.Substring (0,str.Length -1);
				this.m_lvw2.SelectedItems[0].SubItems[4].Text = str;
					
			}
		}

	}
}
