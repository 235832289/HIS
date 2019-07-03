using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmPatRegFee 的摘要说明。
	/// </summary>
	public class frmPatRegFee : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		internal exDataGridSour.exDataGrid Grid;
		internal com.digitalwave.controls.ctlRegType ctlRegType;
		internal com.digitalwave.controls.ctlPatType ctlPatType;
		internal System.Windows.Forms.TextBox m_txtRegFee;
		internal System.Windows.Forms.TextBox m_txtDiagFee;
		private PinkieControls.ButtonXP m_bntAdd;
		private PinkieControls.ButtonXP m_bntSave;
		private PinkieControls.ButtonXP m_bntDel;
		internal System.Windows.Forms.ErrorProvider errorProvider1;
		private exDataGridSour.exColumn exColumn1;
		private exDataGridSour.exColumn exColumn2;
		private exDataGridSour.exColumn exColumn3;
		private exDataGridSour.exColumn exColumn4;
		private exDataGridSour.exColumn exColumn5;
		private exDataGridSour.exColumn exColumn6;
		private PinkieControls.ButtonXP m_btnEsc;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmPatRegFee()
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
			this.Grid = new exDataGridSour.exDataGrid();
			this.exColumn1 = new exDataGridSour.exColumn();
			this.exColumn2 = new exDataGridSour.exColumn();
			this.exColumn3 = new exDataGridSour.exColumn();
			this.exColumn4 = new exDataGridSour.exColumn();
			this.exColumn5 = new exDataGridSour.exColumn();
			this.exColumn6 = new exDataGridSour.exColumn();
			this.ctlRegType = new com.digitalwave.controls.ctlRegType();
			this.ctlPatType = new com.digitalwave.controls.ctlPatType();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtRegFee = new System.Windows.Forms.TextBox();
			this.m_txtDiagFee = new System.Windows.Forms.TextBox();
			this.m_bntAdd = new PinkieControls.ButtonXP();
			this.m_bntSave = new PinkieControls.ButtonXP();
			this.m_bntDel = new PinkieControls.ButtonXP();
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.m_btnEsc = new PinkieControls.ButtonXP();
			((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
			this.SuspendLayout();
			// 
			// Grid
			// 
			this.Grid.aFormatString = "";
			this.Grid.aRowHeight = 0;
			this.Grid.CaptionVisible = false;
			this.Grid.Col = 0;
			this.Grid.Columns.AddRange(new exDataGridSour.exColumn[] {
																		 this.exColumn1,
																		 this.exColumn2,
																		 this.exColumn3,
																		 this.exColumn4,
																		 this.exColumn5,
																		 this.exColumn6});
			this.Grid.corrDataBase = exDataGridSour.BingType.None;
			this.Grid.DataMember = "";
			this.Grid.goEnter = false;
			this.Grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.Grid.IsList = true;
			this.Grid.Location = new System.Drawing.Point(5, 8);
			this.Grid.Name = "Grid";
			this.Grid.PreferredRowHeight = 0;
			this.Grid.ReadOnly = true;
			this.Grid.Row = 0;
			this.Grid.Rows = 0;
			this.Grid.Size = new System.Drawing.Size(531, 312);
			this.Grid.TabIndex = 0;
			this.Grid.toolTip = "";
			this.Grid.tsAlternatingBackColor = System.Drawing.Color.Gainsboro;
			this.Grid.tsGridLineColor = System.Drawing.Color.BlanchedAlmond;
			this.Grid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_KeyDown);
			this.Grid.CurrentCellChanged += new System.EventHandler(this.Grid_CurrentCellChanged);
			// 
			// exColumn1
			// 
			this.exColumn1.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.exColumn1.AutoSize = false;
			this.exColumn1.BackColor = System.Drawing.Color.White;
			this.exColumn1.CanEdit = true;
			this.exColumn1.ForeColor = System.Drawing.Color.Black;
			this.exColumn1.Format = "";
			this.exColumn1.FormatInfo = null;
			this.exColumn1.HeaderText = "";
			this.exColumn1.Hide = true;
			this.exColumn1.indexKey = "";
			this.exColumn1.IsNum = false;
			this.exColumn1.IsNumAndOption = false;
			this.exColumn1.MappingName = "registertypeid_chr";
			this.exColumn1.NullText = "";
			this.exColumn1.Width = 0;
			// 
			// exColumn2
			// 
			this.exColumn2.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.exColumn2.AutoSize = false;
			this.exColumn2.BackColor = System.Drawing.Color.White;
			this.exColumn2.CanEdit = true;
			this.exColumn2.ForeColor = System.Drawing.Color.Black;
			this.exColumn2.Format = "";
			this.exColumn2.FormatInfo = null;
			this.exColumn2.HeaderText = "";
			this.exColumn2.Hide = true;
			this.exColumn2.indexKey = "";
			this.exColumn2.IsNum = false;
			this.exColumn2.IsNumAndOption = false;
			this.exColumn2.MappingName = "paytypeid_chr";
			this.exColumn2.NullText = "";
			this.exColumn2.Width = 0;
			// 
			// exColumn3
			// 
			this.exColumn3.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.exColumn3.AutoSize = true;
			this.exColumn3.BackColor = System.Drawing.Color.White;
			this.exColumn3.CanEdit = true;
			this.exColumn3.ForeColor = System.Drawing.Color.Black;
			this.exColumn3.Format = "";
			this.exColumn3.FormatInfo = null;
			this.exColumn3.HeaderText = "挂号类型";
			this.exColumn3.Hide = false;
			this.exColumn3.indexKey = "";
			this.exColumn3.IsNum = false;
			this.exColumn3.IsNumAndOption = false;
			this.exColumn3.MappingName = "registertypename_vchr";
			this.exColumn3.NullText = "";
			// 
			// exColumn4
			// 
			this.exColumn4.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.exColumn4.AutoSize = true;
			this.exColumn4.BackColor = System.Drawing.Color.White;
			this.exColumn4.CanEdit = true;
			this.exColumn4.ForeColor = System.Drawing.Color.Black;
			this.exColumn4.Format = "";
			this.exColumn4.FormatInfo = null;
			this.exColumn4.HeaderText = "病人类型";
			this.exColumn4.Hide = false;
			this.exColumn4.indexKey = "";
			this.exColumn4.IsNum = false;
			this.exColumn4.IsNumAndOption = false;
			this.exColumn4.MappingName = "paytypename_vchr";
			this.exColumn4.NullText = "";
			// 
			// exColumn5
			// 
			this.exColumn5.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.exColumn5.AutoSize = false;
			this.exColumn5.BackColor = System.Drawing.Color.White;
			this.exColumn5.CanEdit = true;
			this.exColumn5.ForeColor = System.Drawing.Color.Black;
			this.exColumn5.Format = "";
			this.exColumn5.FormatInfo = null;
			this.exColumn5.HeaderText = "挂号费";
			this.exColumn5.Hide = false;
			this.exColumn5.indexKey = "";
			this.exColumn5.IsNum = false;
			this.exColumn5.IsNumAndOption = false;
			this.exColumn5.MappingName = "regfee";
			this.exColumn5.NullText = "";
			this.exColumn5.Width = 80;
			// 
			// exColumn6
			// 
			this.exColumn6.Alignment = System.Windows.Forms.HorizontalAlignment.Center;
			this.exColumn6.AutoSize = false;
			this.exColumn6.BackColor = System.Drawing.Color.White;
			this.exColumn6.CanEdit = true;
			this.exColumn6.ForeColor = System.Drawing.Color.Black;
			this.exColumn6.Format = "";
			this.exColumn6.FormatInfo = null;
			this.exColumn6.HeaderText = "诊金";
			this.exColumn6.Hide = false;
			this.exColumn6.indexKey = "";
			this.exColumn6.IsNum = false;
			this.exColumn6.IsNumAndOption = false;
			this.exColumn6.MappingName = "diagfee";
			this.exColumn6.NullText = "";
			this.exColumn6.Width = 80;
			// 
			// ctlRegType
			// 
			this.ctlRegType.Location = new System.Drawing.Point(112, 342);
			this.ctlRegType.Name = "ctlRegType";
			this.ctlRegType.RegTypeID = "";
			this.ctlRegType.RegTypeName = "";
			this.ctlRegType.Size = new System.Drawing.Size(121, 22);
			this.ctlRegType.TabIndex = 1;
			this.ctlRegType.SelectedIndexChanged += new System.EventHandler(this.ctlRegType_SelectedIndexChanged);
			// 
			// ctlPatType
			// 
			this.ctlPatType.Location = new System.Drawing.Point(112, 382);
			this.ctlPatType.Name = "ctlPatType";
			this.ctlPatType.PatTypeID = "";
			this.ctlPatType.PatTypeName = "";
			this.ctlPatType.Size = new System.Drawing.Size(121, 22);
			this.ctlPatType.TabIndex = 2;
			this.ctlPatType.SelectedIndexChanged += new System.EventHandler(this.ctlPatType_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(40, 344);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 19);
			this.label1.TabIndex = 3;
			this.label1.Text = "挂号类型";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Location = new System.Drawing.Point(40, 384);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 19);
			this.label2.TabIndex = 4;
			this.label2.Text = "病人类型";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new System.Drawing.Point(296, 344);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(48, 19);
			this.label3.TabIndex = 5;
			this.label3.Text = "挂号费";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label4.Location = new System.Drawing.Point(296, 384);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(34, 19);
			this.label4.TabIndex = 6;
			this.label4.Text = "诊金";
			// 
			// m_txtRegFee
			// 
			this.m_txtRegFee.Location = new System.Drawing.Point(360, 342);
			this.m_txtRegFee.MaxLength = 10;
			this.m_txtRegFee.Name = "m_txtRegFee";
			this.m_txtRegFee.Size = new System.Drawing.Size(121, 23);
			this.m_txtRegFee.TabIndex = 7;
			this.m_txtRegFee.Text = "";
			this.m_txtRegFee.TextChanged += new System.EventHandler(this.m_txtRegFee_TextChanged);
			// 
			// m_txtDiagFee
			// 
			this.m_txtDiagFee.Location = new System.Drawing.Point(360, 382);
			this.m_txtDiagFee.MaxLength = 10;
			this.m_txtDiagFee.Name = "m_txtDiagFee";
			this.m_txtDiagFee.Size = new System.Drawing.Size(121, 23);
			this.m_txtDiagFee.TabIndex = 8;
			this.m_txtDiagFee.Text = "";
			this.m_txtDiagFee.TextChanged += new System.EventHandler(this.m_txtDiagFee_TextChanged);
			// 
			// m_bntAdd
			// 
			this.m_bntAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(216)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_bntAdd.DefaultScheme = true;
			this.m_bntAdd.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_bntAdd.Hint = "";
			this.m_bntAdd.Location = new System.Drawing.Point(16, 432);
			this.m_bntAdd.Name = "m_bntAdd";
			this.m_bntAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_bntAdd.Size = new System.Drawing.Size(112, 24);
			this.m_bntAdd.TabIndex = 9;
			this.m_bntAdd.Text = "新增  F2";
			this.m_bntAdd.Click += new System.EventHandler(this.m_bntAdd_Click);
			// 
			// m_bntSave
			// 
			this.m_bntSave.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(216)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_bntSave.DefaultScheme = true;
			this.m_bntSave.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_bntSave.Hint = "";
			this.m_bntSave.Location = new System.Drawing.Point(152, 432);
			this.m_bntSave.Name = "m_bntSave";
			this.m_bntSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_bntSave.Size = new System.Drawing.Size(112, 24);
			this.m_bntSave.TabIndex = 10;
			this.m_bntSave.Text = "保存 F3";
			this.m_bntSave.Click += new System.EventHandler(this.m_bntSave_Click);
			// 
			// m_bntDel
			// 
			this.m_bntDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(216)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_bntDel.DefaultScheme = true;
			this.m_bntDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_bntDel.Hint = "";
			this.m_bntDel.Location = new System.Drawing.Point(280, 432);
			this.m_bntDel.Name = "m_bntDel";
			this.m_bntDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_bntDel.Size = new System.Drawing.Size(112, 24);
			this.m_bntDel.TabIndex = 11;
			this.m_bntDel.Text = "删除 F4";
			this.m_bntDel.Click += new System.EventHandler(this.m_bntDel_Click);
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// m_btnEsc
			// 
			this.m_btnEsc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(216)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnEsc.DefaultScheme = true;
			this.m_btnEsc.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnEsc.Hint = "";
			this.m_btnEsc.Location = new System.Drawing.Point(416, 432);
			this.m_btnEsc.Name = "m_btnEsc";
			this.m_btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnEsc.Size = new System.Drawing.Size(112, 24);
			this.m_btnEsc.TabIndex = 12;
			this.m_btnEsc.Text = "退出 Esc";
			this.m_btnEsc.Click += new System.EventHandler(this.m_btnEsc_Click);
			// 
			// frmPatRegFee
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.CancelButton = this.m_btnEsc;
			this.ClientSize = new System.Drawing.Size(538, 479);
			this.Controls.Add(this.m_btnEsc);
			this.Controls.Add(this.m_bntDel);
			this.Controls.Add(this.m_bntSave);
			this.Controls.Add(this.m_bntAdd);
			this.Controls.Add(this.m_txtDiagFee);
			this.Controls.Add(this.m_txtRegFee);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.Grid);
			this.Controls.Add(this.ctlPatType);
			this.Controls.Add(this.ctlRegType);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmPatRegFee";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "门诊挂号费用维护";
			this.Load += new System.EventHandler(this.frmPatRegFee_Load);
			((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new clsControlPatRegFee();
			this.objController.Set_GUI_Apperance(this);
		}
		public override void Show_MDI_Child(Form frmMDI_Parent)
		{
//			this.MdiParent = frmMDI_Parent;
//			this.WindowState = FormWindowState.Normal;
			this.ShowDialog();
		}
		private void ctlRegType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.errorProvider1.SetError(ctlRegType,"");
		}

		private void ctlPatType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		   this.errorProvider1.SetError(ctlPatType,"");
		}

		private void m_txtRegFee_TextChanged(object sender, System.EventArgs e)
		{
		   this.errorProvider1.SetError(m_txtRegFee,"");
		}

		private void m_txtDiagFee_TextChanged(object sender, System.EventArgs e)
		{
		   this.errorProvider1.SetError(m_txtDiagFee,"");
		}

		private void frmPatRegFee_Load(object sender, System.EventArgs e)
		{
			ctlRegType.LoadData();
			ctlPatType.LoadData();
			((clsControlPatRegFee)this.objController).m_lngFindPatRegFee();
			this.Grid_CurrentCellChanged(null,null);
		}

		private void m_btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_bntAdd_Click(object sender, System.EventArgs e)
		{
		   ((clsControlPatRegFee)this.objController).Clear();
		}

		private void m_bntSave_Click(object sender, System.EventArgs e)
		{
			((clsControlPatRegFee)this.objController).m_SaveFee();
		}

		private void m_bntDel_Click(object sender, System.EventArgs e)
		{
		    ((clsControlPatRegFee)this.objController).m_Del();
		}

		private void Grid_CurrentCellChanged(object sender, System.EventArgs e)
		{
		    ((clsControlPatRegFee)this.objController).GridIndexChange();
		}

		private void Grid_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{
				case Keys.F2:
					this.m_bntAdd_Click(null,null);
                    break;
				case Keys.F3:
					this.m_bntSave_Click(null,null);
					break;
				case Keys.F4:
					this.m_bntDel_Click(null,null);
					break;
			}
		}

	}
}
