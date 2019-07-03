using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmItemAndMedSortRelation 的摘要说明。
	/// </summary>
	public class frmItemAndMedSortRelation : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal PinkieControls.ButtonXP m_BtnSave;
		internal com.digitalwave.iCare.gui.HIS.exComboBox comboBox1;
		internal com.digitalwave.iCare.gui.HIS.exComboBox comboBox2;
		internal com.digitalwave.iCare.gui.HIS.exComboBox m_cmbMedSort;
		internal com.digitalwave.controls.datagrid2.ctlDataGrid m_dgRelation;
		internal PinkieControls.ButtonXP buttonXP1;
		private System.Windows.Forms.Panel panel1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmItemAndMedSortRelation()
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
			com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
			com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
			com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
			com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
			com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo5 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
			com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo6 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
			com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo7 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
			com.digitalwave.controls.datagrid2.clsColumnInfo clsColumnInfo8 = new com.digitalwave.controls.datagrid2.clsColumnInfo();
			this.comboBox2 = new com.digitalwave.iCare.gui.HIS.exComboBox();
			this.comboBox1 = new com.digitalwave.iCare.gui.HIS.exComboBox();
			this.m_BtnSave = new PinkieControls.ButtonXP();
			this.m_cmbMedSort = new com.digitalwave.iCare.gui.HIS.exComboBox();
			this.m_dgRelation = new com.digitalwave.controls.datagrid2.ctlDataGrid();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.panel1 = new System.Windows.Forms.Panel();
			((System.ComponentModel.ISupportInitialize)(this.m_dgRelation)).BeginInit();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// comboBox2
			// 
			this.comboBox2.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.Location = new System.Drawing.Point(392, 148);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(100, 22);
			this.comboBox2.TabIndex = 26;
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(356, 200);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(100, 22);
			this.comboBox1.TabIndex = 25;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// m_BtnSave
			// 
			this.m_BtnSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_BtnSave.DefaultScheme = true;
			this.m_BtnSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_BtnSave.Hint = "";
			this.m_BtnSave.Location = new System.Drawing.Point(4, 104);
			this.m_BtnSave.Name = "m_BtnSave";
			this.m_BtnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_BtnSave.Size = new System.Drawing.Size(96, 44);
			this.m_BtnSave.TabIndex = 12;
			this.m_BtnSave.Text = "保存(&S)";
			this.m_BtnSave.Click += new System.EventHandler(this.buttonXP1_Click);
			// 
			// m_cmbMedSort
			// 
			this.m_cmbMedSort.BackColor = System.Drawing.Color.LightGoldenrodYellow;
			this.m_cmbMedSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbMedSort.Location = new System.Drawing.Point(268, 168);
			this.m_cmbMedSort.Name = "m_cmbMedSort";
			this.m_cmbMedSort.Size = new System.Drawing.Size(100, 22);
			this.m_cmbMedSort.TabIndex = 27;
			this.m_cmbMedSort.Leave += new System.EventHandler(this.m_cmbMedSort_Leave);
			this.m_cmbMedSort.SelectedIndexChanged += new System.EventHandler(this.m_cmbMedSort_SelectedIndexChanged);
			// 
			// m_dgRelation
			// 
			this.m_dgRelation.AllowAddNew = false;
			this.m_dgRelation.AllowDelete = false;
			this.m_dgRelation.AutoAppendRow = false;
			this.m_dgRelation.AutoScroll = true;
			this.m_dgRelation.BackgroundColor = System.Drawing.SystemColors.Window;
			this.m_dgRelation.CaptionText = "";
			this.m_dgRelation.CaptionVisible = false;
			this.m_dgRelation.ColumnHeadersVisible = true;
			clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "MEDICINETYPENAME_VCHR";
			clsColumnInfo1.ColumnWidth = 150;
			clsColumnInfo1.Enabled = false;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "药品分类";
			clsColumnInfo1.ReadOnly = true;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "itemcatname_vchr";
			clsColumnInfo2.ColumnWidth = 150;
			clsColumnInfo2.Enabled = true;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "收费项目名称";
			clsColumnInfo2.ReadOnly = false;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo3.BackColor = System.Drawing.Color.White;
			clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
			clsColumnInfo3.ColumnIndex = 2;
			clsColumnInfo3.ColumnName = "medstorename_vchr";
			clsColumnInfo3.ColumnWidth = 100;
			clsColumnInfo3.Enabled = true;
			clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo3.HeadText = "门诊药房";
			clsColumnInfo3.ReadOnly = false;
			clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo4.BackColor = System.Drawing.Color.White;
			clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
			clsColumnInfo4.ColumnIndex = 3;
			clsColumnInfo4.ColumnName = "medstorename_vchr1";
			clsColumnInfo4.ColumnWidth = 100;
			clsColumnInfo4.Enabled = true;
			clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo4.HeadText = "住院药房";
			clsColumnInfo4.ReadOnly = false;
			clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo5.BackColor = System.Drawing.Color.White;
			clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
			clsColumnInfo5.ColumnIndex = 4;
			clsColumnInfo5.ColumnName = "medicinetypeid_chr";
			clsColumnInfo5.ColumnWidth = 0;
			clsColumnInfo5.Enabled = false;
			clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo5.HeadText = "medicinetypeid_chr";
			clsColumnInfo5.ReadOnly = true;
			clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo6.BackColor = System.Drawing.Color.White;
			clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
			clsColumnInfo6.ColumnIndex = 5;
			clsColumnInfo6.ColumnName = "ITEMCATID_CHR";
			clsColumnInfo6.ColumnWidth = 0;
			clsColumnInfo6.Enabled = false;
			clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo6.HeadText = "ITEMCATID_CHR";
			clsColumnInfo6.ReadOnly = true;
			clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo7.BackColor = System.Drawing.Color.White;
			clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
			clsColumnInfo7.ColumnIndex = 6;
			clsColumnInfo7.ColumnName = "OUTMEDSTOREID_CHR";
			clsColumnInfo7.ColumnWidth = 0;
			clsColumnInfo7.Enabled = false;
			clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo7.HeadText = "OUTMEDSTOREID_CHR";
			clsColumnInfo7.ReadOnly = true;
			clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo8.BackColor = System.Drawing.Color.White;
			clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid2.enum_DataType.System_String;
			clsColumnInfo8.ColumnIndex = 7;
			clsColumnInfo8.ColumnName = "INMEDSTOREID_CHR";
			clsColumnInfo8.ColumnWidth = 0;
			clsColumnInfo8.Enabled = false;
			clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo8.HeadText = "INMEDSTOREID_CHR";
			clsColumnInfo8.ReadOnly = true;
			clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
			this.m_dgRelation.Columns.Add(clsColumnInfo1);
			this.m_dgRelation.Columns.Add(clsColumnInfo2);
			this.m_dgRelation.Columns.Add(clsColumnInfo3);
			this.m_dgRelation.Columns.Add(clsColumnInfo4);
			this.m_dgRelation.Columns.Add(clsColumnInfo5);
			this.m_dgRelation.Columns.Add(clsColumnInfo6);
			this.m_dgRelation.Columns.Add(clsColumnInfo7);
			this.m_dgRelation.Columns.Add(clsColumnInfo8);
			this.m_dgRelation.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_dgRelation.FullRowSelect = false;
			this.m_dgRelation.Location = new System.Drawing.Point(0, 0);
			this.m_dgRelation.MultiSelect = false;
			this.m_dgRelation.Name = "m_dgRelation";
			this.m_dgRelation.ReadOnly = false;
			this.m_dgRelation.RowHeadersVisible = false;
			this.m_dgRelation.RowHeaderWidth = 35;
			this.m_dgRelation.SelectedRowBackColor = System.Drawing.Color.LightCyan;
			this.m_dgRelation.SelectedRowForeColor = System.Drawing.Color.White;
			this.m_dgRelation.Size = new System.Drawing.Size(504, 269);
			this.m_dgRelation.TabIndex = 12;
			// 
			// buttonXP1
			// 
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(4, 196);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(96, 44);
			this.buttonXP1.TabIndex = 28;
			this.buttonXP1.Text = "退出(ESC)";
			this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click_1);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.m_BtnSave);
			this.panel1.Controls.Add(this.buttonXP1);
			this.panel1.Location = new System.Drawing.Point(504, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(104, 269);
			this.panel1.TabIndex = 29;
			// 
			// frmItemAndMedSortRelation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(612, 269);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.m_dgRelation);
			this.Controls.Add(this.m_cmbMedSort);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.MaximizeBox = false;
			this.Name = "frmItemAndMedSortRelation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "收费项目与药品分类关联设置";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmItemAndMedSortRelation_Closing);
			this.Load += new System.EventHandler(this.frmItemAndMedSortRelation_Load);
			((System.ComponentModel.ISupportInitialize)(this.m_dgRelation)).EndInit();
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlItemAndMedSortRelation();
			objController.Set_GUI_Apperance(this);
		}

		private void m_BtnAddRelateion_Click(object sender, System.EventArgs e)
		{
			((clsControlItemAndMedSortRelation)this.objController).AddRelation();
		}

		private void m_BtnDelRelation_Click(object sender, System.EventArgs e)
		{
			((clsControlItemAndMedSortRelation)this.objController).DelRelation();
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			((clsControlItemAndMedSortRelation)this.objController).SaveRelation();
		}

		private void frmItemAndMedSortRelation_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		
		}

		private void frmItemAndMedSortRelation_Load(object sender, System.EventArgs e)
		{
			m_dgRelation.m_mthAddEnterToSpaceColumn(1);
			m_dgRelation.m_mthAddEnterToSpaceColumn(2);
			m_dgRelation.m_mthAddEnterToSpaceColumn(3);
			((clsControlItemAndMedSortRelation)this.objController).InitFrm();
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.m_dgRelation.Columns[1]).DataGridTextBoxColumn.TextBox.Enter+=new EventHandler(TextBox_Enter);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.m_dgRelation.Columns[2]).DataGridTextBoxColumn.TextBox.Enter+=new EventHandler(TextBox_Enter);
			((com.digitalwave.controls.datagrid2.clsColumnInfo)this.m_dgRelation.Columns[3]).DataGridTextBoxColumn.TextBox.Enter+=new EventHandler(TextBox_Enter);
		}
		TextBox objBox=null;
		private void TextBox_Enter(object sender, EventArgs e)
		{
			objBox=(TextBox)sender;
			objBox.BackColor=System.Drawing.Color.DarkSeaGreen;
			switch(this.m_dgRelation.CurrentCell.ColumnNumber)
			{
				case 1:
					objBox.Controls.Add(m_cmbMedSort);
					m_cmbMedSort.Dock=DockStyle.Fill;
					m_cmbMedSort.Text=objBox.Text;
					break;
				case 2:
					objBox.Controls.Add(comboBox2);
					comboBox2.Dock=DockStyle.Fill;
					comboBox2.Text=objBox.Text;
					break;
				case 3:
					objBox.Controls.Add(comboBox1);
					comboBox1.Dock=DockStyle.Fill;
					comboBox1.Text=objBox.Text;
					break;
			}

		}

		private void m_cmbMedSort_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.m_dgRelation.RowCount>0)
			{
				for(int i1=0;i1<this.m_dgRelation.RowCount;i1++)
				{
					if(m_cmbMedSort.SelectItemText.Trim()==this.m_dgRelation[i1,1].ToString().Trim()&&this.m_dgRelation[i1,1].ToString().Trim()!=""&&i1!=this.m_dgRelation.CurrentCell.RowNumber)
					{
						clsMain main=new clsMain();
						main.m_mthShowWarning(this.m_cmbMedSort,"你选择的收费项目已经存在!");
						this.m_dgRelation.Focus();
						this.m_dgRelation.CurrentCell=new DataGridCell(this.m_dgRelation.CurrentCell.RowNumber,1);
						return;
					}
				}
			}
			this.m_dgRelation[this.m_dgRelation.CurrentCell.RowNumber,1]=m_cmbMedSort.SelectItemText;
			this.m_dgRelation[this.m_dgRelation.CurrentCell.RowNumber,5]=m_cmbMedSort.SelectItemValue;
		}

		private void m_cmbMedSort_Leave(object sender, System.EventArgs e)
		{
		
		}

		private void comboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.m_dgRelation[this.m_dgRelation.CurrentCell.RowNumber,2]=comboBox2.SelectItemText;
			this.m_dgRelation[this.m_dgRelation.CurrentCell.RowNumber,6]=comboBox2.SelectItemValue;
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.m_dgRelation[this.m_dgRelation.CurrentCell.RowNumber,3]=comboBox1.SelectItemText;
			this.m_dgRelation[this.m_dgRelation.CurrentCell.RowNumber,7]=comboBox1.SelectItemValue;
		}

		private void buttonXP1_Click_1(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
