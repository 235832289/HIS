using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmHistoryMedicine 的摘要说明。
	/// </summary>
	public class frmHistoryMedicine :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;
		private clsDcl_DoctorWorkstation objSvc=null;
		public frmHistoryMedicine(clsDcl_DoctorWorkstation p_objSvc)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			objSvc =p_objSvc;
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
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// listView2
			// 
			this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.listView2.BackColor = System.Drawing.SystemColors.Info;
			this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader7,
																						this.columnHeader8,
																						this.columnHeader9,
																						this.columnHeader11,
																						this.columnHeader2});
			this.listView2.Font = new System.Drawing.Font("宋体", 10.5F);
			this.listView2.FullRowSelect = true;
			this.listView2.GridLines = true;
			this.listView2.Location = new System.Drawing.Point(0, 0);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(600, 440);
			this.listView2.TabIndex = 4;
			this.listView2.View = System.Windows.Forms.View.Details;
			this.listView2.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView2_ColumnClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "编号";
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "项目名称";
			this.columnHeader7.Width = 190;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "规格";
			this.columnHeader8.Width = 121;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "数量";
			this.columnHeader9.Width = 52;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "单位";
			this.columnHeader11.Width = 52;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "类型";
			this.columnHeader2.Width = 100;
			// 
			// frmHistoryMedicine
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(600, 429);
			this.Controls.Add(this.listView2);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmHistoryMedicine";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "病人用药历史 --按ESC键退出";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmHistoryMedicine_KeyDown);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmHistoryMedicine_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}
		}
		/// <summary>
		/// 病人ID
		/// </summary>
		public string PatientID
		{
			set
			{
			m_mthGetUsingMedicineByPatientID(value); 
			}
		}
		private void m_mthGetUsingMedicineByPatientID(string strPatientID)
		{
		  System.Data.DataTable dt;
			long ret =objSvc.m_mthGetUsingMedicineByPatientID(out dt,strPatientID,"");
			if(ret>0&&dt.Rows.Count>0)
			{
				for(int i=0;i<dt.Rows.Count;i++)
				{
					ListViewItem lv=new ListViewItem(dt.Rows[i]["ITEMCODE_VCHR"].ToString().Trim());
					lv.SubItems.Add(dt.Rows[i]["ITEMNAME_VCHR"].ToString().Trim());
					lv.SubItems.Add(dt.Rows[i]["ITEMSPEC_VCHR"].ToString().Trim());
					lv.SubItems.Add(dt.Rows[i]["COUNT"].ToString().Trim());
					lv.SubItems.Add(dt.Rows[i]["ITEMOPUNIT_CHR"].ToString().Trim());
					lv.SubItems.Add(dt.Rows[i]["TYPENAME_VCHR"].ToString().Trim());
					this.listView2.Items.Add(lv);
				}
			}
		}

		private void listView2_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			this.listView2.ListViewItemSorter = new ListViewItemSort(e.Column);
			listView2.Sort();
		}

	}
}
