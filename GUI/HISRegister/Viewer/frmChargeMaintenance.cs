using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmChargeMaintenance 的摘要说明。
	/// </summary>
	public class frmChargeMaintenance : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
		private System.Windows.Forms.Panel panel1;
		internal PinkieControls.ButtonXP m_btFind;
		internal System.Windows.Forms.TextBox m_txtFind;
		internal System.Windows.Forms.ComboBox m_cmbFind;
		internal PinkieControls.ButtonXP btCancel;
		internal PinkieControls.ButtonXP btExit;
		internal PinkieControls.ButtonXP btSave;
        internal com.digitalwave.iCare.gui.HIS.exComboBox cmbCatType;
        internal Panel panel2;
        internal CheckBox checkBox1;
        internal Panel panel4;
        internal Panel panel3;
        internal CheckBox checkBox3;
        internal CheckBox checkBox2;
        internal DataGridView dataGridView1;
		/// <summary>
		/// 收费项目对应每种不同病人的收费比例
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmChargeMaintenance()
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btExit = new PinkieControls.ButtonXP();
            this.btSave = new PinkieControls.ButtonXP();
            this.btCancel = new PinkieControls.ButtonXP();
            this.m_btFind = new PinkieControls.ButtonXP();
            this.m_txtFind = new System.Windows.Forms.TextBox();
            this.m_cmbFind = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmbCatType = new com.digitalwave.iCare.gui.HIS.exComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.checkBox3);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.cmbCatType);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.btCancel);
            this.panel1.Controls.Add(this.m_btFind);
            this.panel1.Controls.Add(this.m_txtFind);
            this.panel1.Controls.Add(this.m_cmbFind);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 643);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1016, 78);
            this.panel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PowderBlue;
            this.panel4.Location = new System.Drawing.Point(584, 36);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(16, 12);
            this.panel4.TabIndex = 48;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.panel3.Location = new System.Drawing.Point(508, 36);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(16, 12);
            this.panel3.TabIndex = 46;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Location = new System.Drawing.Point(530, 33);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(54, 18);
            this.checkBox3.TabIndex = 47;
            this.checkBox3.Text = "住院";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Location = new System.Drawing.Point(455, 33);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(54, 18);
            this.checkBox2.TabIndex = 45;
            this.checkBox2.Text = "门诊";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.panel2.Location = new System.Drawing.Point(424, 36);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(16, 12);
            this.panel2.TabIndex = 44;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(371, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(54, 18);
            this.checkBox1.TabIndex = 43;
            this.checkBox1.Text = "共用";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(890, 26);
            this.btExit.Name = "btExit";
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(88, 32);
            this.btExit.TabIndex = 10;
            this.btExit.Text = "退出(ESC)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btSave
            // 
            this.btSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btSave.DefaultScheme = true;
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btSave.Hint = "";
            this.btSave.Location = new System.Drawing.Point(798, 26);
            this.btSave.Name = "btSave";
            this.btSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btSave.Size = new System.Drawing.Size(88, 32);
            this.btSave.TabIndex = 9;
            this.btSave.Text = "保存(F2)";
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btCancel.DefaultScheme = true;
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btCancel.Hint = "";
            this.btCancel.Location = new System.Drawing.Point(705, 26);
            this.btCancel.Name = "btCancel";
            this.btCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btCancel.Size = new System.Drawing.Size(88, 32);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "撤消(F7)";
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // m_btFind
            // 
            this.m_btFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.m_btFind.DefaultScheme = true;
            this.m_btFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_btFind.Hint = "";
            this.m_btFind.Location = new System.Drawing.Point(612, 27);
            this.m_btFind.Name = "m_btFind";
            this.m_btFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_btFind.Size = new System.Drawing.Size(88, 32);
            this.m_btFind.TabIndex = 6;
            this.m_btFind.Text = "查找(F3)";
            this.m_btFind.Click += new System.EventHandler(this.m_btFind_Click);
            // 
            // m_txtFind
            // 
            this.m_txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_txtFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.m_txtFind.Font = new System.Drawing.Font("宋体", 12F);
            this.m_txtFind.Location = new System.Drawing.Point(142, 30);
            this.m_txtFind.Name = "m_txtFind";
            this.m_txtFind.Size = new System.Drawing.Size(91, 26);
            this.m_txtFind.TabIndex = 5;
            this.m_txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtFind_KeyDown);
            // 
            // m_cmbFind
            // 
            this.m_cmbFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_cmbFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFind.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmbFind.Items.AddRange(new object[] {
            "按项目ID查找",
            "按项目名称查找",
            "按项目编码查找",
            "按拼音简码查找",
            "按五笔简码查找"});
            this.m_cmbFind.Location = new System.Drawing.Point(16, 31);
            this.m_cmbFind.Name = "m_cmbFind";
            this.m_cmbFind.Size = new System.Drawing.Size(119, 24);
            this.m_cmbFind.TabIndex = 4;
            this.m_cmbFind.SelectedIndexChanged += new System.EventHandler(this.m_cmbFind_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 1);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 40;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1016, 629);
            this.dataGridView1.TabIndex = 2;
            // 
            // cmbCatType
            // 
            this.cmbCatType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCatType.Font = new System.Drawing.Font("宋体", 12F);
            this.cmbCatType.Location = new System.Drawing.Point(237, 30);
            this.cmbCatType.Name = "cmbCatType";
            this.cmbCatType.Size = new System.Drawing.Size(127, 24);
            this.cmbCatType.TabIndex = 42;
            // 
            // frmChargeMaintenance
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(1016, 721);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.KeyPreview = true;
            this.Name = "frmChargeMaintenance";
            this.Text = "收费项目保险比例定义";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmChargeMaintenance_KeyDown);
            this.Load += new System.EventHandler(this.frmChargeMaintenance_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_ChargeMaintenance();
			objController.Set_GUI_Apperance(this);
		}

		private void m_cmbFind_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		((clsCtl_ChargeMaintenance)this.objController).m_cmbFind_SelectedIndexChanged();
		}

		private void frmChargeMaintenance_Load(object sender, System.EventArgs e)
		{
			((clsCtl_ChargeMaintenance)this.objController).m_mthFormLoad();
		}

		private void m_btFind_Click(object sender, System.EventArgs e)
		{
		((clsCtl_ChargeMaintenance)this.objController).m_mthFindChargeItem();
		}

		private void btCancel_Click(object sender, System.EventArgs e)
		{
		((clsCtl_ChargeMaintenance)this.objController).btCancel_Click();
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			((clsCtl_ChargeMaintenance)this.objController).m_mthCloseWindow();
		}

		private void btSave_Click(object sender, System.EventArgs e)
		{
		this.btSave.Enabled=false;
		((clsCtl_ChargeMaintenance)this.objController).m_mthSave();
		this.btSave.Enabled=true;
		}

		private void frmChargeMaintenance_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode == Keys.Escape)
			{
				if(MessageBox.Show("确认退出吗?","iCare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.No)
					return;
				this.Close();
			}
			switch(e.KeyCode)
			{
				case Keys.F2:
					this.btSave_Click(null,null);
					break;
				case Keys.F3:
						this.m_btFind_Click(null,null);
					break;
				case Keys.F7:
					this.btCancel_Click(null,null);
					break;
				case Keys.Escape:
						this.btExit_Click(null,null);
					break;
			}
		}

		private void m_txtFind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			((clsCtl_ChargeMaintenance)this.objController).m_mthFindChargeItem();
			}
		}

		private void dataGrid1_CurrentCellChanged(object sender, System.EventArgs e)
		{
            //try
            //{
            //    int row=this.dataGrid1.CurrentRowIndex;
            //    if(this.dataGrid1[row,0].ToString().Trim()=="")
            //    {
            //        this.dataGrid1.CurrentCell=new DataGridCell(row-1,2);
            //    }
            //}
            //catch
            //{
			
            //}
		}



		#region 权限窗口函数
		public void m_mthShow(string strCatID)
		{
		((clsCtl_ChargeMaintenance)this.objController).m_mthAddCat(strCatID);
		((clsCtl_ChargeMaintenance)this.objController).IsCanAddItem=true;//标志不能再添加选项
		this.Show();
		}
		#endregion

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            ((clsCtl_ChargeMaintenance)this.objController).m_mthGetCheck();
        }
	}
}
