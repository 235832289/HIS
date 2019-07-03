using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;

namespace iCare
{
	/// <summary>
	/// Summary description for frmInPatMedRecChoose.
	/// </summary>
	public class frmInPatMedRecChoose : System.Windows.Forms.Form
	{
		private PinkieControls.ButtonXP m_cmdOK;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private PinkieControls.ButtonXP m_cmdCancel;

		//病历类型数组
		private clsInpatMedRec_Type[] m_objTypeArr= null;
		private System.Windows.Forms.ListView m_lsvChoose;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private clsInpatMedRecDomain m_objDomain = null;

		public frmInPatMedRecChoose()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_objDomain = new clsInpatMedRecDomain();

			if(frmOutlookBar.s_TrnInPatMed == null)//load to memory
			{
				frmOutlookBar frm = new frmOutlookBar();
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmInPatMedRecChoose));
			this.m_cmdOK = new PinkieControls.ButtonXP();
			this.m_cmdCancel = new PinkieControls.ButtonXP();
			this.m_lsvChoose = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// m_cmdOK
			// 
			this.m_cmdOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.m_cmdOK.DefaultScheme = true;
			this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_cmdOK.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cmdOK.Hint = "";
			this.m_cmdOK.Location = new System.Drawing.Point(45, 416);
			this.m_cmdOK.Name = "m_cmdOK";
			this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdOK.Size = new System.Drawing.Size(84, 28);
			this.m_cmdOK.TabIndex = 0;
			this.m_cmdOK.Text = "确  定";
			this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
			// 
			// m_cmdCancel
			// 
			this.m_cmdCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(192)));
			this.m_cmdCancel.DefaultScheme = true;
			this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F);
			this.m_cmdCancel.Hint = "";
			this.m_cmdCancel.Location = new System.Drawing.Point(181, 416);
			this.m_cmdCancel.Name = "m_cmdCancel";
			this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdCancel.Size = new System.Drawing.Size(84, 28);
			this.m_cmdCancel.TabIndex = 1;
			this.m_cmdCancel.Text = "取  消";
			this.m_cmdCancel.Click += new System.EventHandler(this.button1_Click);
			// 
			// m_lsvChoose
			// 
			this.m_lsvChoose.Alignment = System.Windows.Forms.ListViewAlignment.Left;
			this.m_lsvChoose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lsvChoose.BackColor = System.Drawing.SystemColors.Window;
			this.m_lsvChoose.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.columnHeader1});
			this.m_lsvChoose.GridLines = true;
			this.m_lsvChoose.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvChoose.LabelWrap = false;
			this.m_lsvChoose.Location = new System.Drawing.Point(12, 12);
			this.m_lsvChoose.MultiSelect = false;
			this.m_lsvChoose.Name = "m_lsvChoose";
			this.m_lsvChoose.Size = new System.Drawing.Size(288, 396);
			this.m_lsvChoose.TabIndex = 3;
			this.m_lsvChoose.View = System.Windows.Forms.View.Details;
			this.m_lsvChoose.DoubleClick += new System.EventHandler(this.m_lsvChoose_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 284;
			// 
			// frmInPatMedRecChoose
			// 
			this.AcceptButton = this.m_cmdOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.BackColor = System.Drawing.Color.Silver;
			this.CancelButton = this.m_cmdCancel;
			this.ClientSize = new System.Drawing.Size(310, 455);
			this.Controls.Add(this.m_lsvChoose);
			this.Controls.Add(this.m_cmdOK);
			this.Controls.Add(this.m_cmdCancel);
			this.Font = new System.Drawing.Font("宋体", 12F);
			this.ForeColor = System.Drawing.Color.Black;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmInPatMedRecChoose";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "选择病历类型";
			this.Load += new System.EventHandler(this.frmInPatMedRecChoose_Load);
			this.ResumeLayout(false);

		}
		#endregion

		

		private void frmInPatMedRecChoose_Load(object sender, System.EventArgs e)
		{
			m_lsvChoose.BeginUpdate();
			m_lsvChoose.Items.Clear();
			m_objDomain.m_lngGetAllFormID(out m_objTypeArr);
			if(m_objTypeArr != null)
			{
				for(int i=0; i < m_objTypeArr.Length; i++)
				{
					ListViewItem item = new ListViewItem(m_objTypeArr[i].m_strTypeName);
					item.Tag = m_objTypeArr[i];
					m_lsvChoose.Items.Add(item);
				}
			}
			m_lsvChoose.EndUpdate();
			m_lsvChoose.Invalidate();
		}

		private string m_strResult = "";

		public string m_StrResult
		{
			get{return m_strResult;}
		}

		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if(m_lsvChoose.SelectedItems.Count <= 0)
				return;
			clsInpatMedRec_Type objType = m_lsvChoose.SelectedItems[0].Tag as clsInpatMedRec_Type;
			if(objType != null)
			{
				new clsMainMenuFunction().m_mthOpenMedicalRecord("iCare." + objType.m_strTypeID);
				//添加病历上的元素到树节点
				clsInpatMedRec_Type_Item[] objType_ItemArr;
				long lngRes = new clsInpatMedRecDomain().m_lngGetType_ItemRecord(objType.m_strTypeID,out objType_ItemArr);				
				if(lngRes > 0 && objType_ItemArr != null && objType_ItemArr.Length > 0)
				{
					frmOutlookBar.s_TrnInPatMed.Nodes.Clear();
					for(int i=1;i<objType_ItemArr.Length;i++)
					{
						TreeNode trnParent = m_trnFindParent(frmOutlookBar.s_TrnInPatMed,objType_ItemArr[i]);
						m_mthAddItemNode(trnParent,objType_ItemArr[i]);
					}
				}
			}
			this.Close();
		}

		private TreeNode m_trnFindParent(TreeNode p_trnParent,clsInpatMedRec_Type_Item p_objItem)
		{	
			for(int i=0;i<p_trnParent.Nodes.Count;i++)
			{
				if(p_objItem.m_strItemName.StartsWith(p_trnParent.Nodes[i].Text+">>"))
				{
					p_objItem.m_strItemName = p_objItem.m_strItemName.Remove(0,p_trnParent.Nodes[i].Text.Length+2);
					return m_trnFindParent(p_trnParent.Nodes[i],p_objItem);
				}
			}

			return p_trnParent;
		}

		private void m_mthAddItemNode(TreeNode p_trnParent,clsInpatMedRec_Type_Item p_objItem)
		{
			int intIndex = p_objItem.m_strItemName.IndexOf(">>");
			while(intIndex > 0)
			{
				TreeNode trnItem =  p_trnParent.Nodes.Add(p_objItem.m_strItemName.Substring(0,intIndex));
				p_objItem.m_strItemName = p_objItem.m_strItemName.Remove(0,intIndex+2);
				p_trnParent = trnItem;
				intIndex = p_objItem.m_strItemName.IndexOf(">>");
				if(intIndex < 0)
				{
					break;
				}
			}
			TreeNode trnNew = p_trnParent.Nodes.Add(p_objItem.m_strItemName);
			trnNew.Tag = p_objItem.m_strItemID;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void m_lsvChoose_DoubleClick(object sender, System.EventArgs e)
		{
			m_cmdOK.PerformClick();
		}
	}
}
