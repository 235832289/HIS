using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using iCareData;
using com.digitalwave.Utility.Controls;


namespace iCare
{
	/// <summary>
	/// Summary description for frmOpenStatistics.
	/// </summary>
	public class frmOpenStatistics : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListView m_lsvExistingQuery;
		private System.Windows.Forms.Button m_cmdOpenCondition;
		private System.Windows.Forms.Button m_cmdCancel;
		protected com.digitalwave.Utility.Controls.ctlComboBox m_cboStaticDefinition;
		private System.Windows.Forms.ColumnHeader clmQueryID;
		private System.Windows.Forms.ColumnHeader clmQueryName;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmOpenStatistics()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_objHighLight.m_mthAddControlInContainer(this);
			m_mthLoadStaticDefinition();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//

            //m_objBorderTool=new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_lsvExistingQuery});
		}

		#region 成员变量
		private clsIntelligentStatisticsDomain m_objDomain=new clsIntelligentStatisticsDomain();
		private clsStatisticDefinitionValue [] m_objStatisticDefinitionArr=null;
		string m_strStaticID=null;
		string m_strQueryID=null;
		private ctlHighLightFocus m_objHighLight = new ctlHighLightFocus(clsHRPColor.s_ClrHightLight);
        //private clsBorderTool m_objBorderTool;
		#endregion
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOpenStatistics));
			this.label1 = new System.Windows.Forms.Label();
			this.m_lsvExistingQuery = new System.Windows.Forms.ListView();
			this.clmQueryID = new System.Windows.Forms.ColumnHeader();
			this.clmQueryName = new System.Windows.Forms.ColumnHeader();
			this.m_cmdOpenCondition = new System.Windows.Forms.Button();
			this.m_cmdCancel = new System.Windows.Forms.Button();
			this.m_cboStaticDefinition = new com.digitalwave.Utility.Controls.ctlComboBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(16, 268);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(88, 23);
			this.label1.TabIndex = 9;
			this.label1.Text = "统计类型：";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// m_lsvExistingQuery
			// 
			this.m_lsvExistingQuery.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvExistingQuery.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_lsvExistingQuery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								 this.clmQueryID,
																								 this.clmQueryName});
			this.m_lsvExistingQuery.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvExistingQuery.ForeColor = System.Drawing.Color.White;
			this.m_lsvExistingQuery.FullRowSelect = true;
			this.m_lsvExistingQuery.GridLines = true;
			this.m_lsvExistingQuery.HoverSelection = true;
			this.m_lsvExistingQuery.Location = new System.Drawing.Point(20, 20);
			this.m_lsvExistingQuery.MultiSelect = false;
			this.m_lsvExistingQuery.Name = "m_lsvExistingQuery";
			this.m_lsvExistingQuery.Size = new System.Drawing.Size(420, 228);
			this.m_lsvExistingQuery.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.m_lsvExistingQuery.TabIndex = 100;
			this.m_lsvExistingQuery.View = System.Windows.Forms.View.Details;
			// 
			// clmQueryID
			// 
			this.clmQueryID.Text = "查询ID";
			this.clmQueryID.Width = 150;
			// 
			// clmQueryName
			// 
			this.clmQueryName.Text = "查询说明";
			this.clmQueryName.Width = 270;
			// 
			// m_cmdOpenCondition
			// 
			this.m_cmdOpenCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdOpenCondition.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdOpenCondition.Location = new System.Drawing.Point(304, 264);
			this.m_cmdOpenCondition.Name = "m_cmdOpenCondition";
			this.m_cmdOpenCondition.Size = new System.Drawing.Size(64, 32);
			this.m_cmdOpenCondition.TabIndex = 120;
			this.m_cmdOpenCondition.Text = "打开";
			this.m_cmdOpenCondition.Click += new System.EventHandler(this.m_cmdOpenCondition_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cmdCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_cmdCancel.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdCancel.Location = new System.Drawing.Point(376, 264);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Size = new System.Drawing.Size(64, 32);
			this.m_cmdCancel.TabIndex = 130;
			this.m_cmdCancel.Text = "取消";
			this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
			// 
			// m_cboStaticDefinition
			// 
			this.m_cboStaticDefinition.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboStaticDefinition.BorderColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboStaticDefinition.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.m_cboStaticDefinition.DropButtonForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboStaticDefinition.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboStaticDefinition.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cboStaticDefinition.ForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.ListBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboStaticDefinition.ListForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.ListSelectedBackColor = System.Drawing.Color.Blue;
			this.m_cboStaticDefinition.ListSelectedForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.Location = new System.Drawing.Point(104, 264);
			this.m_cboStaticDefinition.Name = "m_cboStaticDefinition";
			this.m_cboStaticDefinition.SelectedIndex = -1;
			this.m_cboStaticDefinition.SelectedItem = null;
			this.m_cboStaticDefinition.Size = new System.Drawing.Size(192, 26);
			this.m_cboStaticDefinition.TabIndex = 110;
			this.m_cboStaticDefinition.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_cboStaticDefinition.TextForeColor = System.Drawing.Color.White;
			this.m_cboStaticDefinition.SelectedIndexChanged += new System.EventHandler(this.m_cboStaticDefinition_SelectedIndexChanged);
			// 
			// frmOpenStatistics
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.CancelButton = this.m_cmdCancel;
			this.ClientSize = new System.Drawing.Size(460, 317);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_cboStaticDefinition,
																		  this.m_cmdCancel,
																		  this.m_cmdOpenCondition,
																		  this.m_lsvExistingQuery,
																		  this.label1});
			this.ForeColor = System.Drawing.Color.White;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOpenStatistics";
			this.Text = "打开查询条件";
			this.ResumeLayout(false);

		}
		#endregion
	
	

		private void m_mthLoadStaticDefinition()
		{
			m_cboStaticDefinition.ClearItem();
			long lngRes=m_objDomain.m_lngGetAllStatisticDefinition(out m_objStatisticDefinitionArr);
			if(lngRes<=0 || m_objStatisticDefinitionArr==null) return;
			for(int i=0;i<m_objStatisticDefinitionArr.Length;i++)
			{
				m_cboStaticDefinition.AddItem(m_objStatisticDefinitionArr[i].m_strStatisticDesc);
			}
		}
		private void m_mthLoadExistingQuery()
		{
			if(m_cboStaticDefinition.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择统计类型。");
				return;
			}
			//下面开始LOAD数据库中的查询
			m_lsvExistingQuery.Items.Clear();
			clsStatisticQueryModeValue[] objStaticQueryMode;
			long lngRes=m_objDomain.m_lngGetStatisticQueryMode(m_objStatisticDefinitionArr[m_cboStaticDefinition.SelectedIndex].m_strStatistic_ID,out objStaticQueryMode);
			if(lngRes<=0 || objStaticQueryMode==null || objStaticQueryMode.Length==0) return;
			ListViewItem[] objLsvItemArr=new ListViewItem[objStaticQueryMode.Length];
			for(int i=0;i<objStaticQueryMode.Length;i++)
			{
				objLsvItemArr[i]=new ListViewItem(new string[]{objStaticQueryMode[i].m_strQueryID,objStaticQueryMode[i].m_strModeDesc});
			}
			m_lsvExistingQuery.Items.AddRange(objLsvItemArr);
		}
		private bool m_blnGetFromUIAndClose()
		{
			if(m_cboStaticDefinition.SelectedIndex==-1)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择统计类型。");
				return false;
			}
			if(m_lsvExistingQuery.SelectedItems.Count==0)
			{
				clsPublicFunction.ShowInformationMessageBox("你还没选择要打开的查询。");
				return false;
			}
			if(m_lsvExistingQuery.SelectedItems.Count>1)
			{
				clsPublicFunction.ShowInformationMessageBox("一次只能选择一条查询。");
				return false;
			}
			m_strStaticID=m_objStatisticDefinitionArr[m_cboStaticDefinition.SelectedIndex].m_strStatistic_ID;
			m_strQueryID=m_lsvExistingQuery.SelectedItems[0].Text;
			this.DialogResult=DialogResult.OK;
			this.Close();
			return true;
			//暂时还没有中间件
//			m_strQueryID= m_lsvExistingQuery.SelectedIndices[0];
		}

		public bool m_blnGetQueryToOpen(out string p_strStaticID, out string p_strQueryID)
		{
			p_strQueryID=m_strQueryID;
			p_strStaticID=m_strStaticID;
			return true;
		}

		private void m_cmdOpenCondition_Click(object sender, System.EventArgs e)
		{
			m_blnGetFromUIAndClose();
		}

		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult=DialogResult.Cancel;
			this.Close();
		}

		private void m_cboStaticDefinition_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			m_mthLoadExistingQuery();
		}


	}
}
