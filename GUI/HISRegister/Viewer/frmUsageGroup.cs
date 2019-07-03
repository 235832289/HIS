using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmUsageGroup 的摘要说明。
	/// </summary>
	public class frmUsageGroup :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.Panel panel2;
		private PinkieControls.ButtonXP m_btnDelAll;
		private PinkieControls.ButtonXP m_btnDel;
		private PinkieControls.ButtonXP m_btnAdd;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboUsage;
		private System.Windows.Forms.Panel panel3;
		internal System.Windows.Forms.DataGrid m_dg;
		private System.Windows.Forms.Label label3;
		internal com.digitalwave.iCare.gui.HIS.exComboBox m_cboCat;
		public System.Windows.Forms.ListView m_lvw;
		private System.ComponentModel.IContainer components;

		public frmUsageGroup()
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
			this.components = new System.ComponentModel.Container();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.m_btnDelAll = new PinkieControls.ButtonXP();
			this.m_btnDel = new PinkieControls.ButtonXP();
			this.m_btnAdd = new PinkieControls.ButtonXP();
			this.panel2 = new System.Windows.Forms.Panel();
			this.m_lvw = new System.Windows.Forms.ListView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.m_cboUsage = new com.digitalwave.iCare.gui.HIS.exComboBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.label3 = new System.Windows.Forms.Label();
			this.m_cboCat = new com.digitalwave.iCare.gui.HIS.exComboBox();
			this.m_dg = new System.Windows.Forms.DataGrid();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.panel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.m_dg)).BeginInit();
			this.SuspendLayout();
			// 
			// m_btnDelAll
			// 
			this.m_btnDelAll.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(216)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDelAll.DefaultScheme = true;
			this.m_btnDelAll.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDelAll.Hint = "";
			this.m_btnDelAll.Location = new System.Drawing.Point(240, 208);
			this.m_btnDelAll.Name = "m_btnDelAll";
			this.m_btnDelAll.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDelAll.Size = new System.Drawing.Size(32, 16);
			this.m_btnDelAll.TabIndex = 4;
			this.m_btnDelAll.Text = ">>";
			this.toolTip1.SetToolTip(this.m_btnDelAll, "删除全部");
			this.m_btnDelAll.Click += new System.EventHandler(this.m_btnDelAll_Click);
			// 
			// m_btnDel
			// 
			this.m_btnDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(216)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnDel.DefaultScheme = true;
			this.m_btnDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnDel.Hint = "";
			this.m_btnDel.Location = new System.Drawing.Point(240, 176);
			this.m_btnDel.Name = "m_btnDel";
			this.m_btnDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnDel.Size = new System.Drawing.Size(32, 16);
			this.m_btnDel.TabIndex = 3;
			this.m_btnDel.Text = ">";
			this.toolTip1.SetToolTip(this.m_btnDel, "删除");
			this.m_btnDel.Click += new System.EventHandler(this.m_btnDel_Click);
			// 
			// m_btnAdd
			// 
			this.m_btnAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(216)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnAdd.DefaultScheme = true;
			this.m_btnAdd.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnAdd.Hint = "";
			this.m_btnAdd.Location = new System.Drawing.Point(240, 144);
			this.m_btnAdd.Name = "m_btnAdd";
			this.m_btnAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnAdd.Size = new System.Drawing.Size(32, 16);
			this.m_btnAdd.TabIndex = 2;
			this.m_btnAdd.Text = "<";
			this.toolTip1.SetToolTip(this.m_btnAdd, "添加");
			this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.m_lvw);
			this.panel2.Controls.Add(this.panel1);
			this.panel2.Controls.Add(this.m_btnDelAll);
			this.panel2.Controls.Add(this.m_btnDel);
			this.panel2.Controls.Add(this.m_btnAdd);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(280, 469);
			this.panel2.TabIndex = 4;
			// 
			// m_lvw
			// 
			this.m_lvw.Dock = System.Windows.Forms.DockStyle.Left;
			this.m_lvw.FullRowSelect = true;
			this.m_lvw.HideSelection = false;
			this.m_lvw.Location = new System.Drawing.Point(0, 56);
			this.m_lvw.Name = "m_lvw";
			this.m_lvw.Size = new System.Drawing.Size(224, 413);
			this.m_lvw.TabIndex = 1;
			this.m_lvw.View = System.Windows.Forms.View.List;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.m_cboUsage);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(280, 56);
			this.panel1.TabIndex = 13;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(-40, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 19);
			this.label2.TabIndex = 13;
			this.label2.Text = "项目";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(24, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 19);
			this.label1.TabIndex = 12;
			this.label1.Text = "用法";
			// 
			// m_cboUsage
			// 
			this.m_cboUsage.Location = new System.Drawing.Point(80, 17);
			this.m_cboUsage.Name = "m_cboUsage";
			this.m_cboUsage.Size = new System.Drawing.Size(160, 22);
			this.m_cboUsage.TabIndex = 0;
			this.m_cboUsage.Text = "comboBox1";
			this.m_cboUsage.SelectedIndexChanged += new System.EventHandler(this.m_cboUsage_SelectedIndexChanged);
			// 
			// panel3
			// 
			this.panel3.Controls.Add(this.label3);
			this.panel3.Controls.Add(this.m_cboCat);
			this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel3.Location = new System.Drawing.Point(280, 0);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(504, 56);
			this.panel3.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new System.Drawing.Point(24, 19);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 19);
			this.label3.TabIndex = 17;
			this.label3.Text = "项目";
			// 
			// m_cboCat
			// 
			this.m_cboCat.Location = new System.Drawing.Point(72, 17);
			this.m_cboCat.Name = "m_cboCat";
			this.m_cboCat.Size = new System.Drawing.Size(160, 22);
			this.m_cboCat.TabIndex = 5;
			this.m_cboCat.SelectedIndexChanged += new System.EventHandler(this.m_cboCat_SelectedIndexChanged);
			// 
			// m_dg
			// 
			this.m_dg.CaptionVisible = false;
			this.m_dg.DataMember = "";
			this.m_dg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_dg.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.m_dg.Location = new System.Drawing.Point(280, 56);
			this.m_dg.Name = "m_dg";
			this.m_dg.ReadOnly = true;
			this.m_dg.Size = new System.Drawing.Size(504, 413);
			this.m_dg.TabIndex = 6;
			// 
			// frmUsageGroup
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(784, 469);
			this.Controls.Add(this.m_dg);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmUsageGroup";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "用法项目维护";
			this.Load += new System.EventHandler(this.frmUsageGroup_Load);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.m_dg)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsControlUsageItem();
			objController.Set_GUI_Apperance(this);
		}
		public override void Show_MDI_Child(Form frmMDI_Parent)
		{
//			this.MdiParent = frmMDI_Parent;
//			this.WindowState = FormWindowState.Normal;
			this.ShowDialog();
		}  

		private void frmUsageGroup_Load(object sender, System.EventArgs e)
		{
		   ((clsControlUsageItem)this.objController).m_GetUsage();
			((clsControlUsageItem)this.objController).m_FillCat();
			DataGridTableStyle dtsConstruct=new DataGridTableStyle();
			clsMain.m_SetTableStyle(dtsConstruct,"ID","ID",0);
			clsMain.m_SetTableStyle(dtsConstruct,"编号","Code",100);
			clsMain.m_SetTableStyle(dtsConstruct,"名称","Name",100);
			m_dg.TableStyles.Add(dtsConstruct);
		}

		private void m_cboUsage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		   ((clsControlUsageItem)this.objController).m_GetItemByUsageID();
		   ((clsControlUsageItem)this.objController).m_FillItemGrid();
		}

		private void m_cboCat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		   ((clsControlUsageItem)this.objController).m_FillItemGrid();
		}

		private void m_btnAdd_Click(object sender, System.EventArgs e)
		{
		   ((clsControlUsageItem)this.objController).m_Add();
		}

		private void m_btnDel_Click(object sender, System.EventArgs e)
		{
		   ((clsControlUsageItem)this.objController).m_Del(false);
		}

		private void m_btnDelAll_Click(object sender, System.EventArgs e)
		{
			((clsControlUsageItem)this.objController).m_Del(true);
		} 

	}
}
