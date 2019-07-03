using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmCheckCategory : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.TextBox txtCheckCategory;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.ListView lsvCheckCategory;
        private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Data.DataTable dtbCheckCategory;
        private System.Windows.Forms.GroupBox gbCheckCategory;
        private PinkieControls.ButtonXP btnNew;
        private PinkieControls.ButtonXP btnSave;
        private PinkieControls.ButtonXP btnDelete;
        private PinkieControls.ButtonXP btnClose;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmCheckCategory()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.gbCheckCategory = new System.Windows.Forms.GroupBox();
            this.txtCheckCategory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsvCheckCategory = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnNew = new PinkieControls.ButtonXP();
            this.btnSave = new PinkieControls.ButtonXP();
            this.btnDelete = new PinkieControls.ButtonXP();
            this.btnClose = new PinkieControls.ButtonXP();
            this.gbCheckCategory.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCheckCategory
            // 
            this.gbCheckCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbCheckCategory.Controls.Add(this.txtCheckCategory);
            this.gbCheckCategory.Controls.Add(this.label1);
            this.gbCheckCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gbCheckCategory.Location = new System.Drawing.Point(8, 8);
            this.gbCheckCategory.Name = "gbCheckCategory";
            this.gbCheckCategory.Size = new System.Drawing.Size(328, 64);
            this.gbCheckCategory.TabIndex = 10;
            this.gbCheckCategory.TabStop = false;
            this.gbCheckCategory.Text = "基本信息";
            // 
            // txtCheckCategory
            // 
            this.txtCheckCategory.Location = new System.Drawing.Point(80, 24);
            this.txtCheckCategory.MaxLength = 50;
            this.txtCheckCategory.Name = "txtCheckCategory";
            this.txtCheckCategory.Size = new System.Drawing.Size(224, 23);
            this.txtCheckCategory.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "检验类别";
            // 
            // lsvCheckCategory
            // 
            this.lsvCheckCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lsvCheckCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lsvCheckCategory.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvCheckCategory.FullRowSelect = true;
            this.lsvCheckCategory.HideSelection = false;
            this.lsvCheckCategory.Location = new System.Drawing.Point(8, 80);
            this.lsvCheckCategory.MultiSelect = false;
            this.lsvCheckCategory.Name = "lsvCheckCategory";
            this.lsvCheckCategory.Size = new System.Drawing.Size(328, 152);
            this.lsvCheckCategory.TabIndex = 11;
            this.lsvCheckCategory.UseCompatibleStateImageBehavior = false;
            this.lsvCheckCategory.View = System.Windows.Forms.View.Details;
            this.lsvCheckCategory.SelectedIndexChanged += new System.EventHandler(this.lsvCheckCategory_SelectedIndexChanged);
            this.lsvCheckCategory.Click += new System.EventHandler(this.lsvCheckCategory_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "检验类别号";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "检验类别";
            this.columnHeader2.Width = 100;
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnNew.DefaultScheme = true;
            this.btnNew.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNew.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnNew.Hint = "";
            this.btnNew.Location = new System.Drawing.Point(-40, 246);
            this.btnNew.Name = "btnNew";
            this.btnNew.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnNew.Size = new System.Drawing.Size(88, 28);
            this.btnNew.TabIndex = 105;
            this.btnNew.Text = "新增";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnSave.DefaultScheme = true;
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Hint = "";
            this.btnSave.Location = new System.Drawing.Point(56, 246);
            this.btnSave.Name = "btnSave";
            this.btnSave.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnSave.Size = new System.Drawing.Size(88, 28);
            this.btnSave.TabIndex = 103;
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnDelete.DefaultScheme = true;
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDelete.Hint = "";
            this.btnDelete.Location = new System.Drawing.Point(152, 246);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnDelete.Size = new System.Drawing.Size(88, 28);
            this.btnDelete.TabIndex = 104;
            this.btnDelete.Text = "删除";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btnClose.DefaultScheme = true;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnClose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnClose.Hint = "";
            this.btnClose.Location = new System.Drawing.Point(248, 246);
            this.btnClose.Name = "btnClose";
            this.btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btnClose.Size = new System.Drawing.Size(88, 28);
            this.btnClose.TabIndex = 106;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCheckCategory
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.ClientSize = new System.Drawing.Size(344, 285);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lsvCheckCategory);
            this.Controls.Add(this.gbCheckCategory);
            this.Name = "frmCheckCategory";
            this.Text = "检验类别录入";
            this.Load += new System.EventHandler(this.frmCheckCategory_Load);
            this.gbCheckCategory.ResumeLayout(false);
            this.gbCheckCategory.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
//		[STAThread]
//		static void Main() 
//		{
//			Application.Run(new frmCheckCategory());
//		}

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.LIS.clsController_addCheckCategory();
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			if(txtCheckCategory.Text.ToString().Trim() == "")
			{
				MessageBox.Show("检验类别不能为空","检验类别",MessageBoxButtons.OK);
				txtCheckCategory.Focus();
				return;
			}
			int count = this.lsvCheckCategory.Items.Count;
			long m_lngRes = 0;
			string strCategory = txtCheckCategory.Text.ToString().Trim();
			string strCategoryID = null;
			if(this.btnSave.Text == "保存")
			{
				for(int i=0;i<count;i++)
				{
					if(this.txtCheckCategory.Text.ToString().Trim() == this.lsvCheckCategory.Items[i].SubItems[1].Text.ToString().Trim())
					{
						MessageBox.Show("检验类别不能相同","检验类别",MessageBoxButtons.OK);
						return;
					}
				}
				m_lngRes = ((clsController_addCheckCategory)this.objController).AddCheckCategory(strCategory,out strCategoryID);
				if(m_lngRes > 0)
				{
					ListViewItem objListViewItem = new ListViewItem();
					objListViewItem.Text = strCategoryID;
					objListViewItem.SubItems.Add(strCategory);
					lsvCheckCategory.Items.Add(objListViewItem);
				}
				Reset();
			}
			else if(this.btnSave.Text == "修改")
			{
				((clsController_addCheckCategory)this.objController).SetCheckCategory(this);
				Reset();
			}
		}

		private void frmCheckCategory_Load(object sender, System.EventArgs e)
		{
			((clsController_addCheckCategory)this.objController).QryAllCheckCategory(out dtbCheckCategory);
			int count = dtbCheckCategory.Rows.Count;
			if(count > 0)
			{
				for(int i=0;i<count;i++)
				{
					ListViewItem objListViewItem = new ListViewItem();
					objListViewItem.Text = dtbCheckCategory.Rows[i]["CHECK_CATEGORY_ID_CHR"].ToString();
					objListViewItem.SubItems.Add(dtbCheckCategory.Rows[i]["CHECK_CATEGORY_DESC_VCHR"].ToString());
					objListViewItem.Tag = dtbCheckCategory.Rows[i];
					lsvCheckCategory.Items.Add(objListViewItem);
				}
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(this.lsvCheckCategory.SelectedItems.Count > 0)
			{
				while(lsvCheckCategory.SelectedItems.Count>0)
				{
					string categoryID = lsvCheckCategory.SelectedItems[0].Text;
					((clsController_addCheckCategory)this.objController).DelCheckCategory(categoryID);
					lsvCheckCategory.SelectedItems[0].Remove();
				}
			}
		}

		private void lsvCheckCategory_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(this.lsvCheckCategory.SelectedItems.Count > 0)
			{
				this.txtCheckCategory.Text = this.lsvCheckCategory.SelectedItems[0].SubItems[1].Text.ToString().Trim();
				this.btnSave.Text = "修改";
			}
		}

		private void btnNew_Click(object sender, System.EventArgs e)
		{
			Reset();
		}

		private void Reset()
		{
			this.btnSave.Text = "保存";
			this.txtCheckCategory.Text = "";
		}

		private void lsvCheckCategory_Click(object sender, System.EventArgs e)
		{
			if(this.lsvCheckCategory.SelectedItems.Count > 0)
			{
				this.txtCheckCategory.Text = this.lsvCheckCategory.SelectedItems[0].SubItems[1].Text.ToString().Trim();
				this.btnSave.Text = "修改";
			}
		}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
	}
}
