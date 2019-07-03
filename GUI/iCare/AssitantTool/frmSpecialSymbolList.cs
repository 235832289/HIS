using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;

namespace iCare.AssitantTool
{
	/// <summary>
	/// Summary description for frmSpecialSymbolList.
	/// </summary>
	public class frmSpecialSymbolList : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.ListView m_lsvItemList;
		private System.Windows.Forms.ColumnHeader m_clmSpecialSymbolValueID;
		private System.Windows.Forms.ColumnHeader m_clSpecialSymboValue;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		clsSpecialSymbolDomain m_objDomain=new clsSpecialSymbolDomain();

		public frmSpecialSymbolList()
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
		/// 传出的特殊字符
		/// </summary>
		private string m_strOutputSpectialSymbol = "";

		public string m_StrOutputSpectialSymbol
		{
			get
			{
				return m_strOutputSpectialSymbol;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmSpecialSymbolList));
			this.m_lsvItemList = new System.Windows.Forms.ListView();
			this.m_clmSpecialSymbolValueID = new System.Windows.Forms.ColumnHeader();
			this.m_clSpecialSymboValue = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// m_lsvItemList
			// 
			this.m_lsvItemList.BackColor = System.Drawing.Color.White;
			this.m_lsvItemList.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvItemList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.m_clmSpecialSymbolValueID,
																							this.m_clSpecialSymboValue});
			this.m_lsvItemList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_lsvItemList.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_lsvItemList.ForeColor = System.Drawing.Color.Black;
			this.m_lsvItemList.FullRowSelect = true;
			this.m_lsvItemList.GridLines = true;
			this.m_lsvItemList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvItemList.HideSelection = false;
			this.m_lsvItemList.Location = new System.Drawing.Point(0, 0);
			this.m_lsvItemList.MultiSelect = false;
			this.m_lsvItemList.Name = "m_lsvItemList";
			this.m_lsvItemList.Size = new System.Drawing.Size(162, 239);
			this.m_lsvItemList.TabIndex = 414;
			this.m_lsvItemList.View = System.Windows.Forms.View.Details;
			this.m_lsvItemList.DoubleClick += new System.EventHandler(this.m_lsvItemList_DoubleClick);
			// 
			// m_clmSpecialSymbolValueID
			// 
			this.m_clmSpecialSymbolValueID.Width = 0;
			// 
			// m_clSpecialSymboValue
			// 
			this.m_clSpecialSymboValue.Text = "";
			this.m_clSpecialSymboValue.Width = 162;
			// 
			// frmSpecialSymbolList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(162, 239);
			this.Controls.Add(this.m_lsvItemList);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmSpecialSymbolList";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "特殊符号列表";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.frmSpecialSymbolList_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmSpecialSymbolList_Load(object sender, System.EventArgs e)
		{
			m_lsvItemList.Items.Clear();
			clsSpecialSymbolValue[] objclsSpecialSymbolValue = null;
			m_objDomain.m_lngGetAlSpecialSymbolValue(out objclsSpecialSymbolValue);
			if(objclsSpecialSymbolValue != null)
				for(int i=0;i<objclsSpecialSymbolValue.Length;i++)
				{
					ListViewItem lviNew = m_lsvItemList.Items.Add(objclsSpecialSymbolValue[i].m_strDeptID);
					lviNew.SubItems.Add(objclsSpecialSymbolValue[i].m_strSpecialSymbolValue);
				}
			if (m_lsvItemList.Items.Count > 0)
				m_lsvItemList.Items[0].Selected = true;
		}

		private void m_lsvItemList_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvItemList.Items.Count>0 && m_lsvItemList.SelectedItems.Count > 0)
			{
			    m_strOutputSpectialSymbol = m_lsvItemList.SelectedItems[0].SubItems[1].Text;
			}
			this.Close();
		}
	}
}
