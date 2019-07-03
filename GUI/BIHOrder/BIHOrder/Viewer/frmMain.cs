using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace Order
{
	/// <summary>
	/// frmMain 的摘要说明。
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView m_lvwPatient;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox m_txtArea;
		private com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			//m_objService=new clsBIHOrderService();
            
		}

		private clsBIHOrderService m_objService;

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
			this.m_lvwPatient = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.m_txtArea = new com.digitalwave.iCare.BIHOrder.Control.ctlFindTextBox();
			this.ctlDataGrid1 = new com.digitalwave.controls.datagrid.ctlDataGrid();
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// m_lvwPatient
			// 
			this.m_lvwPatient.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.columnHeader1,
																						   this.columnHeader2,
																						   this.columnHeader3,
																						   this.columnHeader4});
			this.m_lvwPatient.Location = new System.Drawing.Point(124, 60);
			this.m_lvwPatient.Name = "m_lvwPatient";
			this.m_lvwPatient.Size = new System.Drawing.Size(392, 252);
			this.m_lvwPatient.TabIndex = 0;
			this.m_lvwPatient.View = System.Windows.Forms.View.Details;
			// 
			// m_txtArea
			// 
			this.m_txtArea.Location = new System.Drawing.Point(32, 28);
			this.m_txtArea.Name = "m_txtArea";
			this.m_txtArea.TabIndex = 1;
			this.m_txtArea.Text = "textBox1";
			this.m_txtArea.m_evtInitListView += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_InitListView(this.m_txtArea_m_evtInitListView);
			this.m_txtArea.m_evtSelectItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnSelectItem(this.m_txtArea_m_evtSelectItem);
			this.m_txtArea.m_evtFindItem += new com.digitalwave.iCare.BIHOrder.Control.EventHandler_OnFindItem(this.m_txtArea_m_evtFindItem);
			// 
			// ctlDataGrid1
			// 
			this.ctlDataGrid1.AllowAddNew = true;
			this.ctlDataGrid1.AllowDelete = true;
			this.ctlDataGrid1.AutoAppendRow = true;
			this.ctlDataGrid1.AutoScroll = true;
			this.ctlDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
			this.ctlDataGrid1.CaptionText = "";
			this.ctlDataGrid1.CaptionVisible = false;
			this.ctlDataGrid1.ColumnHeadersVisible = true;
			this.ctlDataGrid1.FullRowSelect = false;
			this.ctlDataGrid1.Location = new System.Drawing.Point(48, 256);
			this.ctlDataGrid1.MultiSelect = false;
			this.ctlDataGrid1.Name = "ctlDataGrid1";
			this.ctlDataGrid1.ReadOnly = false;
			this.ctlDataGrid1.RowHeadersVisible = true;
			this.ctlDataGrid1.RowHeaderWidth = 35;
			this.ctlDataGrid1.SelectedRowBackColor = System.Drawing.Color.Purple;
			this.ctlDataGrid1.SelectedRowForeColor = System.Drawing.Color.White;
			this.ctlDataGrid1.Size = new System.Drawing.Size(188, 108);
			this.ctlDataGrid1.TabIndex = 2;
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(592, 401);
			this.Controls.Add(this.ctlDataGrid1);
			this.Controls.Add(this.m_txtArea);
			this.Controls.Add(this.m_lvwPatient);
			this.Name = "frmMain";
			this.Text = "frmMain";
			((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		private void m_mthRefreshPatientList()
		{
			m_lvwPatient.Items.Clear();

			string strAreaID=m_txtArea.Text.Trim();
			clsBIHBed[] arrBed;
			long ret=m_objService.m_lngGetAreaBeds(strAreaID,out arrBed);
			if((ret>0)&&(arrBed!=null) &&(arrBed.Length>0))
			{
				for(int i=0;i<arrBed.Length;i++)
				{
					ListViewItem lvi=new ListViewItem(arrBed[i].m_strBedName);
					if(arrBed[i].m_objPatient!=null)
					{
						lvi.SubItems.Add(arrBed[i].m_objPatient.m_strInHospitalNo);
						lvi.SubItems.Add(arrBed[i].m_objPatient.m_strPatientName);
						
					}
					m_lvwPatient.Items.Add(lvi);
				}
			}
		}

		private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
		{
			clsBIHArea[] arrArea;
			long ret=m_objService.m_lngFindArea(strFindCode,out arrArea);
			if((ret>0) && (arrArea!=null))
			{
				for(int i=0;i<arrArea.Length;i++)
				{
					ListViewItem lvi=lvwList.Items.Add(arrArea[i].m_strAreaName);
					lvi.Tag=arrArea[i];
				}
			}
		}

		private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
		{
			lvwList.Columns.Add("",100,HorizontalAlignment.Left);
			lvwList.Width=120;
		}

		private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
		{
			if(lviSelected!=null)
			{
				m_txtArea.Text=lviSelected.Text;
				m_txtArea.Tag=lviSelected.Tag ;
			}
		}

	}
}
