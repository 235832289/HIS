using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// ctlLISApplyUnitProperty 的摘要说明。
	/// </summary>
	public class ctlLISApplyUnitProperty : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.ListView m_lsvValue;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.TextBox m_txtProperty;
		private System.Windows.Forms.ComboBox m_cboValue;
		private System.Windows.Forms.Button m_btnRemove;
		private System.Windows.Forms.Button m_btnAdd;
		private System.Windows.Forms.Button m_btnUp;
		private System.Windows.Forms.Button m_btnDown;
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ctlLISApplyUnitProperty()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化

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

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.m_txtProperty = new System.Windows.Forms.TextBox();
			this.m_cboValue = new System.Windows.Forms.ComboBox();
			this.m_lsvValue = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.m_btnRemove = new System.Windows.Forms.Button();
			this.m_btnAdd = new System.Windows.Forms.Button();
			this.m_btnUp = new System.Windows.Forms.Button();
			this.m_btnDown = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_txtProperty
			// 
			this.m_txtProperty.BackColor = System.Drawing.SystemColors.Info;
			this.m_txtProperty.Location = new System.Drawing.Point(8, 8);
			this.m_txtProperty.Name = "m_txtProperty";
			this.m_txtProperty.ReadOnly = true;
			this.m_txtProperty.Size = new System.Drawing.Size(168, 21);
			this.m_txtProperty.TabIndex = 0;
			this.m_txtProperty.Text = "";
			// 
			// m_cboValue
			// 
			this.m_cboValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboValue.Location = new System.Drawing.Point(8, 36);
			this.m_cboValue.Name = "m_cboValue";
			this.m_cboValue.Size = new System.Drawing.Size(168, 20);
			this.m_cboValue.TabIndex = 1;
			// 
			// m_lsvValue
			// 
			this.m_lsvValue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lsvValue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						 this.columnHeader1});
			this.m_lsvValue.FullRowSelect = true;
			this.m_lsvValue.GridLines = true;
			this.m_lsvValue.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvValue.HideSelection = false;
			this.m_lsvValue.Location = new System.Drawing.Point(252, 8);
			this.m_lsvValue.MultiSelect = false;
			this.m_lsvValue.Name = "m_lsvValue";
			this.m_lsvValue.Size = new System.Drawing.Size(220, 72);
			this.m_lsvValue.TabIndex = 2;
			this.m_lsvValue.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 198;
			// 
			// m_btnRemove
			// 
			this.m_btnRemove.Location = new System.Drawing.Point(188, 36);
			this.m_btnRemove.Name = "m_btnRemove";
			this.m_btnRemove.Size = new System.Drawing.Size(48, 23);
			this.m_btnRemove.TabIndex = 3;
			this.m_btnRemove.Text = "<<";
			this.m_btnRemove.Click += new System.EventHandler(this.m_btnRemove_Click);
			// 
			// m_btnAdd
			// 
			this.m_btnAdd.Location = new System.Drawing.Point(188, 8);
			this.m_btnAdd.Name = "m_btnAdd";
			this.m_btnAdd.Size = new System.Drawing.Size(48, 23);
			this.m_btnAdd.TabIndex = 4;
			this.m_btnAdd.Text = ">>";
			this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
			// 
			// m_btnUp
			// 
			this.m_btnUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnUp.Location = new System.Drawing.Point(476, 8);
			this.m_btnUp.Name = "m_btnUp";
			this.m_btnUp.Size = new System.Drawing.Size(20, 28);
			this.m_btnUp.TabIndex = 5;
			this.m_btnUp.Text = "↑";
			this.m_btnUp.Click += new System.EventHandler(this.m_btnUp_Click);
			// 
			// m_btnDown
			// 
			this.m_btnDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnDown.Location = new System.Drawing.Point(476, 48);
			this.m_btnDown.Name = "m_btnDown";
			this.m_btnDown.Size = new System.Drawing.Size(20, 28);
			this.m_btnDown.TabIndex = 6;
			this.m_btnDown.Text = "↓";
			this.m_btnDown.Click += new System.EventHandler(this.m_btnDown_Click);
			// 
			// ctlLISApplyUnitProperty
			// 
			this.Controls.Add(this.m_btnDown);
			this.Controls.Add(this.m_btnUp);
			this.Controls.Add(this.m_btnRemove);
			this.Controls.Add(this.m_btnAdd);
			this.Controls.Add(this.m_txtProperty);
			this.Controls.Add(this.m_cboValue);
			this.Controls.Add(this.m_lsvValue);
			this.Name = "ctlLISApplyUnitProperty";
			this.Size = new System.Drawing.Size(508, 88);
			this.ResumeLayout(false);

		}
		#endregion

		public void m_mthInitProperty(clsUnitProperty_VO p_objProperty,clsUnitPropertyValue_VO[] p_objPropertyValueList)
		{
			this.m_lsvValue.Items.Clear();
			this.m_cboValue.Items.Clear();
			this.m_txtProperty.Text = p_objProperty.m_strPROPERTY_NAME_VCHR;
			this.m_txtProperty.Tag = p_objProperty;
			this.m_cboValue.Items.AddRange(p_objPropertyValueList);
		}
		public void m_mthSetValues(string[] p_strValues)
		{
			this.m_lsvValue.Items.Clear();
			foreach(string strValue in p_strValues)
			{
				foreach(clsUnitPropertyValue_VO objValueVO in this.m_cboValue.Items)
				{
					if(objValueVO.m_strVALUE_ID_CHR == strValue)
					{
						ListViewItem lvi = new ListViewItem();
						lvi.Text = objValueVO.m_strVLAUE_VCHR;
						lvi.Tag = objValueVO;
						this.m_lsvValue.Items.Add(lvi);
						break;
					}
				}
			}
		}

		public clsUnitPropertyRelate_VO[] m_objValues
		{
			set
			{
				this.m_lsvValue.Items.Clear();
				foreach(clsUnitPropertyRelate_VO objValue in value)
				{
					foreach(clsUnitPropertyValue_VO objValueVO in this.m_cboValue.Items)
					{
						if(objValueVO.m_strVALUE_ID_CHR == objValue.m_strVALUE_ID_CHR)
						{
							ListViewItem lvi = new ListViewItem();
							lvi.Text = objValueVO.m_strVLAUE_VCHR;
							lvi.Tag = objValueVO;
							this.m_lsvValue.Items.Add(lvi);
							break;
						}
					}
				}
			}
			get
			{
				ArrayList arl = new ArrayList();
				foreach(ListViewItem lvi in this.m_lsvValue.Items)
				{
					clsUnitPropertyRelate_VO objVO = new clsUnitPropertyRelate_VO();
					clsUnitPropertyValue_VO objValue = (clsUnitPropertyValue_VO)lvi.Tag;
					objVO.m_strVALUE_ID_CHR = objValue.m_strVALUE_ID_CHR;
					objVO.m_strUNIT_PROPERTY_ID_CHR = objValue.m_strPROPERTY_ID_CHR;
					objVO.m_intPRIORITY_NUM = lvi.Index;
					arl.Add(objVO);
				}
				return (clsUnitPropertyRelate_VO[])arl.ToArray(typeof(clsUnitPropertyRelate_VO));
			}
		}

		public void m_mthAddValue(string p_strValue)
		{
			foreach(clsUnitPropertyValue_VO objValueVO in this.m_cboValue.Items)
			{
				if(objValueVO.m_strVALUE_ID_CHR == p_strValue)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = objValueVO.m_strVLAUE_VCHR;
					lvi.Tag = objValueVO;
					break;
				}
			}
		}
		public void m_mthAddValue(clsUnitPropertyRelate_VO p_objValue)
		{
			foreach(clsUnitPropertyValue_VO objValueVO in this.m_cboValue.Items)
			{
				if(objValueVO.m_strVALUE_ID_CHR == p_objValue.m_strVALUE_ID_CHR)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = objValueVO.m_strVLAUE_VCHR;
					lvi.Tag = objValueVO;
					this.m_lsvValue.Items.Add(lvi);
					break;
				}
			}
		}

		public void m_mthClearValues()
		{
			this.m_lsvValue.Items.Clear();
		}
		public void m_mthClearAll()
		{
			this.m_txtProperty.Clear();
			this.m_txtProperty.Tag = null;
			this.m_cboValue.Items.Clear();
			this.m_lsvValue.Items.Clear();
		}



		private void m_btnAdd_Click(object sender, System.EventArgs e)
		{
			if(this.m_cboValue.SelectedItem != null)
			{
				clsUnitPropertyValue_VO objValueVO = (clsUnitPropertyValue_VO)this.m_cboValue.SelectedItem;
				bool isAdded = false;
				foreach(ListViewItem objLvi in this.m_lsvValue.Items)
				{
					if((objLvi.Tag as clsUnitPropertyValue_VO) == objValueVO)
					{
						isAdded = true;
						break;
					}
				}
				if(!isAdded)
				{
					ListViewItem lvi = new ListViewItem();
					lvi.Text = objValueVO.m_strVLAUE_VCHR;
					lvi.Tag = objValueVO;
					this.m_lsvValue.Items.Add(lvi);
				}
			}
		}

		private void m_btnRemove_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvValue.SelectedItems.Count != 0)
			{
				int intNext = -1;
				if(this.m_lsvValue.SelectedItems[0].Index == this.m_lsvValue.Items.Count -1)
				{
					if(this.m_lsvValue.SelectedItems[0].Index == 0)
						intNext = -1;
					else
						intNext = this.m_lsvValue.SelectedItems[0].Index -1;
				}
				else
				{
					intNext = this.m_lsvValue.SelectedItems[0].Index;
				}
				this.m_lsvValue.SelectedItems[0].Remove();
				if(intNext >=0 )
				{
					this.m_lsvValue.Items[intNext].Selected = true;
				}
			}
		}

		private void m_btnUp_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvValue.SelectedItems.Count == 0)
				return;
			if(this.m_lsvValue.SelectedItems[0].Index == 0)
				return;
			ListViewItem lvi = this.m_lsvValue.SelectedItems[0];
			int intIdx = lvi.Index -1;
			lvi.Remove();
			this.m_lsvValue.Items.Insert(intIdx,lvi);
			lvi.Focused = true;
		}

		private void m_btnDown_Click(object sender, System.EventArgs e)
		{
			if(this.m_lsvValue.SelectedItems.Count == 0)
				return;

			ListViewItem lvi = this.m_lsvValue.SelectedItems[0];
			int intIdx = lvi.Index + 1;
			if(intIdx  == this.m_lsvValue.Items.Count)
				return;
			lvi.Remove();
			this.m_lsvValue.Items.Insert(intIdx,lvi);
			lvi.Focused = true;
		}
	}
}
