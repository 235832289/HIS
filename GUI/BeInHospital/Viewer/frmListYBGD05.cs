using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmListYBGD05 的摘要说明。
	/// </summary>
	public class frmListYBGD05 :  com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 自定义变量
		public static clsYBGD05_VO m_objYBGD05_VO=new clsYBGD05_VO();
		private clsCtl_YBGD05 m_objControl=new clsCtl_YBGD05();
		public DataTable m_dtbDetail=new DataTable();
		#endregion
		private System.Windows.Forms.ListView lsvCategory;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.TextBox txtCode;
		public System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ColumnHeader clmCode;
		private System.Windows.Forms.ColumnHeader clmName;
		private PinkieControls.ButtonXP cmdOK;
		private PinkieControls.ButtonXP cmdCancel;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmListYBGD05()
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
			this.lsvCategory = new System.Windows.Forms.ListView();
			this.clmCode = new System.Windows.Forms.ColumnHeader();
			this.clmName = new System.Windows.Forms.ColumnHeader();
			this.label1 = new System.Windows.Forms.Label();
			this.txtCode = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.cmdOK = new PinkieControls.ButtonXP();
			this.cmdCancel = new PinkieControls.ButtonXP();
			this.SuspendLayout();
			// 
			// lsvCategory
			// 
			this.lsvCategory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.clmCode,
																						  this.clmName});
			this.lsvCategory.FullRowSelect = true;
			this.lsvCategory.GridLines = true;
			this.lsvCategory.Location = new System.Drawing.Point(16, 32);
			this.lsvCategory.MultiSelect = false;
			this.lsvCategory.Name = "lsvCategory";
			this.lsvCategory.Size = new System.Drawing.Size(416, 244);
			this.lsvCategory.TabIndex = 0;
			this.lsvCategory.View = System.Windows.Forms.View.Details;
			this.lsvCategory.DoubleClick += new System.EventHandler(this.lsvCategory_DoubleClick);
			// 
			// clmCode
			// 
			this.clmCode.Text = "代码";
			this.clmCode.Width = 106;
			// 
			// clmName
			// 
			this.clmName.Text = "名称";
			this.clmName.Width = 289;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 19);
			this.label1.TabIndex = 1;
			this.label1.Text = "代码:";
			// 
			// txtCode
			// 
			this.txtCode.AutoSize = false;
			this.txtCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
			this.txtCode.Location = new System.Drawing.Point(48, 4);
			this.txtCode.Name = "txtCode";
			this.txtCode.Size = new System.Drawing.Size(100, 21);
			this.txtCode.TabIndex = 2;
			this.txtCode.Text = "";
			this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(196, 4);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(236, 23);
			this.txtName.TabIndex = 4;
			this.txtName.Text = "";
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(160, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(41, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "名称:";
			// 
			// cmdOK
			// 
			this.cmdOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdOK.DefaultScheme = true;
			this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdOK.Hint = "";
			this.cmdOK.Location = new System.Drawing.Point(224, 284);
			this.cmdOK.Name = "cmdOK";
			this.cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdOK.Size = new System.Drawing.Size(100, 32);
			this.cmdOK.TabIndex = 5;
			this.cmdOK.Text = "确定(&O)";
			this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdCancel.DefaultScheme = true;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdCancel.Hint = "";
			this.cmdCancel.Location = new System.Drawing.Point(332, 284);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdCancel.Size = new System.Drawing.Size(100, 32);
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "取消(&C)";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// frmListYBGD05
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(448, 321);
			this.ControlBox = false;
			this.Controls.Add(this.cmdCancel);
			this.Controls.Add(this.cmdOK);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtCode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.lsvCategory);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmListYBGD05";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "诊断分类列表";
			this.Load += new System.EventHandler(this.frmListYBGD05_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void cmdOK_Click(object sender, System.EventArgs e)
		{
			if(lsvCategory.Items.Count>0)
			{
				m_objYBGD05_VO=new clsYBGD05_VO();
				if(lsvCategory.SelectedItems.Count==0)
				{
					//m_objYBGD05_VO=((clsYBGD05_VO)lsvCategory.Items[0].Tag);
					m_objYBGD05_VO.m_strZDFL=((DataRow)lsvCategory.Items[0].Tag)["DMCODE"].ToString().Trim();
					m_objYBGD05_VO.m_strFLMC=((DataRow)lsvCategory.Items[0].Tag)["ZHSM"].ToString().Trim();

				}
				else
				{
					m_objYBGD05_VO.m_strZDFL=((DataRow)lsvCategory.SelectedItems[0].Tag)["DMCODE"].ToString().Trim();
					m_objYBGD05_VO.m_strFLMC=((DataRow)lsvCategory.SelectedItems[0].Tag)["ZHSM"].ToString().Trim();
				}
			}
			else
			{
				m_objYBGD05_VO=null;
			}
			Close();
		}

		private void frmListYBGD05_Load(object sender, System.EventArgs e)
		{
//			clsYBGD05_VO[] objYBGD05Arr=new clsYBGD05_VO[0];
			txtName_TextChanged(null,null);
//			m_objControl.m_lngGetYBGD05ByFilter("",out objYBGD05Arr);
//			if(objYBGD05Arr!=null)
//			{
//				lsvCategory.Items.Clear();
//				for(int i=0;i<objYBGD05Arr.Length;i++)
//				{
//					ListViewItem lviAdd=new ListViewItem(new string[]{objYBGD05Arr[i].m_strZDFL.Trim(),objYBGD05Arr[i].m_strFLMC.Trim()});
//					lviAdd.Tag=objYBGD05Arr[i];
//					lsvCategory.Items.Add(lviAdd);
//				}
//			}
		}

		private void txtCode_TextChanged(object sender, System.EventArgs e)
		{
			long lngRes=m_objControl.m_lngGetDetailByFilter("ZDFL||DMZH LIKE '"+txtCode.Text.Trim()+"%'",out m_dtbDetail);
			if(lngRes>=0)
			{
				lsvCategory.Items.Clear();
				for(int i=0;i<m_dtbDetail.Rows.Count;i++)
				{
					ListViewItem lviAdd=new ListViewItem(new string[]{m_dtbDetail.Rows[i]["DMCODE"].ToString().Trim(),m_dtbDetail.Rows[i]["ZHSM"].ToString().Trim()});
					lviAdd.Tag=m_dtbDetail.Rows[i];
					lsvCategory.Items.Add(lviAdd);
				}
			}
		}

		private void txtName_TextChanged(object sender, System.EventArgs e)
		{
			#region 原方法
//			clsYBGD05_VO[] objYBGD05Arr=new clsYBGD05_VO[0];
//			m_objControl.m_lngGetYBGD05ByFilter("FLMC LIKE '"+txtName.Text.ToUpper().Trim()+"%'",out objYBGD05Arr);
//			if(objYBGD05Arr!=null)
//			{
//				lsvCategory.Items.Clear();
//				for(int i=0;i<objYBGD05Arr.Length;i++)
//				{
//					ListViewItem lviAdd=new ListViewItem(new string[]{objYBGD05Arr[i].m_strZDFL.Trim(),objYBGD05Arr[i].m_strFLMC.Trim()});
//					lviAdd.Tag=objYBGD05Arr[i];
//					lsvCategory.Items.Add(lviAdd);
//				}
//			}
			#endregion

			long lngRes=m_objControl.m_lngGetDetailByFilter("ZHSM LIKE '"+txtName.Text.Trim()+"%'",out m_dtbDetail);
			if(lngRes>=0)
			{
				lsvCategory.Items.Clear();
				for(int i=0;i<m_dtbDetail.Rows.Count;i++)
				{
					ListViewItem lviAdd=new ListViewItem(new string[]{m_dtbDetail.Rows[i]["DMCODE"].ToString().Trim(),m_dtbDetail.Rows[i]["ZHSM"].ToString().Trim()});
					lviAdd.Tag=m_dtbDetail.Rows[i];
					lsvCategory.Items.Add(lviAdd);
				}
			}
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			m_objYBGD05_VO=null;
			Close();
		}

		private void lsvCategory_DoubleClick(object sender, System.EventArgs e)
		{
			cmdOK_Click(null,null);
		}
	}
}
