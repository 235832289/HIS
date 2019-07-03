using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.BIHOrderServer;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// frmBIHOrderGrid 的摘要说明。
	/// </summary>
	public class frmBIHOrderGrid : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		#region 自定义变量

		/// <summary>
		/// 父窗口,医嘱录入窗口
		/// </summary>
		public frmBIHOrderInput m_frmParent;

		/// <summary>
		/// 医嘱列表
		/// </summary>
		public ArrayList m_arlOrders;



		#endregion
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel1;
		private com.digitalwave.controls.datagrid.ctlDataGrid dtgOrders;
		private System.Windows.Forms.ListView lsvChargeItem;
		internal PinkieControls.ButtonXP m_cmdSub;
		private PinkieControls.ButtonXP m_cmdAdd;
		internal PinkieControls.ButtonXP buttonXP1;
		private PinkieControls.ButtonXP m_cmdDel;
		private System.Windows.Forms.ColumnHeader sCode;
		private System.Windows.Forms.ColumnHeader sName;
		private System.Windows.Forms.ColumnHeader sSpec;
		private System.Windows.Forms.ColumnHeader sPack;
		private System.Windows.Forms.ColumnHeader sPrice;
		private System.Windows.Forms.ImageList m_imgIcons;
		private System.Windows.Forms.Panel pnlInput;
		private System.ComponentModel.IContainer components;

		public frmBIHOrderGrid()
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
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo1 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo2 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo3 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo4 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo5 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo6 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo7 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo8 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			com.digitalwave.controls.datagrid.clsColumnInfo clsColumnInfo9 = new com.digitalwave.controls.datagrid.clsColumnInfo();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBIHOrderGrid));
			this.panel2 = new System.Windows.Forms.Panel();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.m_cmdDel = new PinkieControls.ButtonXP();
			this.m_cmdSub = new PinkieControls.ButtonXP();
			this.m_cmdAdd = new PinkieControls.ButtonXP();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dtgOrders = new com.digitalwave.controls.datagrid.ctlDataGrid();
			this.lsvChargeItem = new System.Windows.Forms.ListView();
			this.sCode = new System.Windows.Forms.ColumnHeader();
			this.sName = new System.Windows.Forms.ColumnHeader();
			this.sSpec = new System.Windows.Forms.ColumnHeader();
			this.sPack = new System.Windows.Forms.ColumnHeader();
			this.sPrice = new System.Windows.Forms.ColumnHeader();
			this.m_imgIcons = new System.Windows.Forms.ImageList(this.components);
			this.pnlInput = new System.Windows.Forms.Panel();
			this.panel2.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dtgOrders)).BeginInit();
			this.SuspendLayout();
			// 
			// panel2
			// 
			this.panel2.BackColor = System.Drawing.SystemColors.Control;
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.buttonXP1);
			this.panel2.Controls.Add(this.m_cmdDel);
			this.panel2.Controls.Add(this.m_cmdSub);
			this.panel2.Controls.Add(this.m_cmdAdd);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.panel2.Location = new System.Drawing.Point(0, 393);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(724, 56);
			this.panel2.TabIndex = 3;
			// 
			// buttonXP1
			// 
			this.buttonXP1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(628, 12);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(85, 28);
			this.buttonXP1.TabIndex = 85;
			this.buttonXP1.Text = "退出(F5)";
			// 
			// m_cmdDel
			// 
			this.m_cmdDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cmdDel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdDel.DefaultScheme = true;
			this.m_cmdDel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdDel.Hint = "";
			this.m_cmdDel.Location = new System.Drawing.Point(536, 12);
			this.m_cmdDel.Name = "m_cmdDel";
			this.m_cmdDel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdDel.Size = new System.Drawing.Size(85, 28);
			this.m_cmdDel.TabIndex = 84;
			this.m_cmdDel.Text = "删除(F2)";
			// 
			// m_cmdSub
			// 
			this.m_cmdSub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cmdSub.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdSub.DefaultScheme = true;
			this.m_cmdSub.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdSub.Hint = "";
			this.m_cmdSub.Location = new System.Drawing.Point(444, 12);
			this.m_cmdSub.Name = "m_cmdSub";
			this.m_cmdSub.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdSub.Size = new System.Drawing.Size(85, 28);
			this.m_cmdSub.TabIndex = 83;
			this.m_cmdSub.Text = "子医嘱(F5)";
			// 
			// m_cmdAdd
			// 
			this.m_cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_cmdAdd.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_cmdAdd.DefaultScheme = true;
			this.m_cmdAdd.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_cmdAdd.Hint = "";
			this.m_cmdAdd.Location = new System.Drawing.Point(352, 12);
			this.m_cmdAdd.Name = "m_cmdAdd";
			this.m_cmdAdd.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_cmdAdd.Size = new System.Drawing.Size(85, 28);
			this.m_cmdAdd.TabIndex = 82;
			this.m_cmdAdd.Text = "添加(F2)";
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.pnlInput);
			this.panel1.Controls.Add(this.dtgOrders);
			this.panel1.Controls.Add(this.lsvChargeItem);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(724, 393);
			this.panel1.TabIndex = 4;
			// 
			// dtgOrders
			// 
			this.dtgOrders.AllowAddNew = true;
			this.dtgOrders.AllowDelete = true;
			this.dtgOrders.AutoAppendRow = true;
			this.dtgOrders.AutoScroll = true;
			this.dtgOrders.BackgroundColor = System.Drawing.SystemColors.Window;
			this.dtgOrders.CaptionText = "";
			this.dtgOrders.CaptionVisible = false;
			this.dtgOrders.ColumnHeadersVisible = true;
			clsColumnInfo1.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo1.BackColor = System.Drawing.Color.White;
			clsColumnInfo1.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo1.ColumnIndex = 0;
			clsColumnInfo1.ColumnName = "Column1";
			clsColumnInfo1.ColumnWidth = 75;
			clsColumnInfo1.Enabled = true;
			clsColumnInfo1.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo1.HeadText = "长/临";
			clsColumnInfo1.ReadOnly = false;
			clsColumnInfo1.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo2.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo2.BackColor = System.Drawing.Color.White;
			clsColumnInfo2.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo2.ColumnIndex = 1;
			clsColumnInfo2.ColumnName = "Column9";
			clsColumnInfo2.ColumnWidth = 75;
			clsColumnInfo2.Enabled = true;
			clsColumnInfo2.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo2.HeadText = "查询";
			clsColumnInfo2.ReadOnly = false;
			clsColumnInfo2.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo3.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo3.BackColor = System.Drawing.Color.White;
			clsColumnInfo3.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo3.ColumnIndex = 2;
			clsColumnInfo3.ColumnName = "Column2";
			clsColumnInfo3.ColumnWidth = 75;
			clsColumnInfo3.Enabled = true;
			clsColumnInfo3.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo3.HeadText = "名称";
			clsColumnInfo3.ReadOnly = false;
			clsColumnInfo3.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo4.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo4.BackColor = System.Drawing.Color.White;
			clsColumnInfo4.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo4.ColumnIndex = 3;
			clsColumnInfo4.ColumnName = "Column3";
			clsColumnInfo4.ColumnWidth = 75;
			clsColumnInfo4.Enabled = true;
			clsColumnInfo4.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo4.HeadText = "剂量";
			clsColumnInfo4.ReadOnly = false;
			clsColumnInfo4.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo5.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo5.BackColor = System.Drawing.Color.White;
			clsColumnInfo5.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo5.ColumnIndex = 4;
			clsColumnInfo5.ColumnName = "Column4";
			clsColumnInfo5.ColumnWidth = 75;
			clsColumnInfo5.Enabled = true;
			clsColumnInfo5.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo5.HeadText = "领量";
			clsColumnInfo5.ReadOnly = false;
			clsColumnInfo5.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo6.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo6.BackColor = System.Drawing.Color.White;
			clsColumnInfo6.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo6.ColumnIndex = 5;
			clsColumnInfo6.ColumnName = "Column5";
			clsColumnInfo6.ColumnWidth = 75;
			clsColumnInfo6.Enabled = true;
			clsColumnInfo6.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo6.HeadText = "执行频率";
			clsColumnInfo6.ReadOnly = false;
			clsColumnInfo6.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo7.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo7.BackColor = System.Drawing.Color.White;
			clsColumnInfo7.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo7.ColumnIndex = 6;
			clsColumnInfo7.ColumnName = "Column6";
			clsColumnInfo7.ColumnWidth = 75;
			clsColumnInfo7.Enabled = true;
			clsColumnInfo7.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo7.HeadText = "用法";
			clsColumnInfo7.ReadOnly = false;
			clsColumnInfo7.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo8.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo8.BackColor = System.Drawing.Color.White;
			clsColumnInfo8.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo8.ColumnIndex = 7;
			clsColumnInfo8.ColumnName = "Column7";
			clsColumnInfo8.ColumnWidth = 75;
			clsColumnInfo8.Enabled = true;
			clsColumnInfo8.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo8.HeadText = "皮试";
			clsColumnInfo8.ReadOnly = false;
			clsColumnInfo8.TextFont = new System.Drawing.Font("宋体", 10F);
			clsColumnInfo9.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			clsColumnInfo9.BackColor = System.Drawing.Color.White;
			clsColumnInfo9.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			clsColumnInfo9.ColumnIndex = 8;
			clsColumnInfo9.ColumnName = "Column8";
			clsColumnInfo9.ColumnWidth = 75;
			clsColumnInfo9.Enabled = true;
			clsColumnInfo9.ForeColor = System.Drawing.Color.Black;
			clsColumnInfo9.HeadText = "父级医嘱";
			clsColumnInfo9.ReadOnly = true;
			clsColumnInfo9.TextFont = new System.Drawing.Font("宋体", 10F);
			this.dtgOrders.Columns.Add(clsColumnInfo1);
			this.dtgOrders.Columns.Add(clsColumnInfo2);
			this.dtgOrders.Columns.Add(clsColumnInfo3);
			this.dtgOrders.Columns.Add(clsColumnInfo4);
			this.dtgOrders.Columns.Add(clsColumnInfo5);
			this.dtgOrders.Columns.Add(clsColumnInfo6);
			this.dtgOrders.Columns.Add(clsColumnInfo7);
			this.dtgOrders.Columns.Add(clsColumnInfo8);
			this.dtgOrders.Columns.Add(clsColumnInfo9);
			this.dtgOrders.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dtgOrders.FullRowSelect = false;
			this.dtgOrders.Location = new System.Drawing.Point(0, 0);
			this.dtgOrders.MultiSelect = false;
			this.dtgOrders.Name = "dtgOrders";
			this.dtgOrders.ReadOnly = false;
			this.dtgOrders.RowHeadersVisible = true;
			this.dtgOrders.RowHeaderWidth = 35;
			this.dtgOrders.SelectedRowBackColor = System.Drawing.Color.Purple;
			this.dtgOrders.SelectedRowForeColor = System.Drawing.Color.White;
			this.dtgOrders.Size = new System.Drawing.Size(724, 277);
			this.dtgOrders.TabIndex = 0;
			this.dtgOrders.m_evtCurrentCellChanged += new System.EventHandler(this.dtgOrders_m_evtCurrentCellChanged);
			// 
			// lsvChargeItem
			// 
			this.lsvChargeItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.sCode,
																							this.sName,
																							this.sSpec,
																							this.sPack,
																							this.sPrice});
			this.lsvChargeItem.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.lsvChargeItem.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvChargeItem.GridLines = true;
			this.lsvChargeItem.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lsvChargeItem.Location = new System.Drawing.Point(0, 277);
			this.lsvChargeItem.MultiSelect = false;
			this.lsvChargeItem.Name = "lsvChargeItem";
			this.lsvChargeItem.Size = new System.Drawing.Size(724, 116);
			this.lsvChargeItem.SmallImageList = this.m_imgIcons;
			this.lsvChargeItem.TabIndex = 1;
			this.lsvChargeItem.View = System.Windows.Forms.View.Details;
			this.lsvChargeItem.Visible = false;
			// 
			// sCode
			// 
			this.sCode.Text = "编码";
			this.sCode.Width = 98;
			// 
			// sName
			// 
			this.sName.Text = "名称";
			this.sName.Width = 294;
			// 
			// sSpec
			// 
			this.sSpec.Text = "规格";
			this.sSpec.Width = 102;
			// 
			// sPack
			// 
			this.sPack.Text = "包装";
			this.sPack.Width = 77;
			// 
			// sPrice
			// 
			this.sPrice.Text = "单价";
			this.sPrice.Width = 82;
			// 
			// m_imgIcons
			// 
			this.m_imgIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.m_imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgIcons.ImageStream")));
			this.m_imgIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// pnlInput
			// 
			this.pnlInput.Location = new System.Drawing.Point(36, 24);
			this.pnlInput.Name = "pnlInput";
			this.pnlInput.Size = new System.Drawing.Size(676, 20);
			this.pnlInput.TabIndex = 2;
			// 
			// frmBIHOrderGrid
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(724, 449);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmBIHOrderGrid";
			this.Text = "";
			this.Resize += new System.EventHandler(this.frmBIHOrderGrid_Resize);
			this.panel2.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dtgOrders)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void frmBIHOrderGrid_Resize(object sender, System.EventArgs e)
		{
			this.Text=this.Width.ToString()+","+this.Height.ToString();
		}


		private void m_mthListChargeItems(string strFindCode,int m_intInputType)
		{
			ArrayList m_arlItems=new ArrayList();
			lsvChargeItem.Items.Clear();
			//组套
			clsBIHOrderGroup[] arrGroup;
			//clsBIHOrderGroupService m_objService2=new clsBIHOrderGroupService();
            clsBIHOrderGroupService m_objService2 = new clsDcl_GetSvcObject().m_GetOrderGroupSvcObject();
			long ret1=m_objService2.m_lngFindGroup(strFindCode,(this.m_frmParent.m_objCurrentDoctor==null?"": this.m_frmParent.m_objCurrentDoctor.m_strDoctorID),this.m_frmParent.m_ctlOrderDetail.m_strDeptID,-1,out arrGroup);
			if((ret1>0) && (arrGroup!=null) && (arrGroup.Length>0))
			{
				for(int i=0;i<arrGroup.Length;i++)
				{
					string strGroupCode=arrGroup[i].m_strGroupID;
					if(m_intInputType==1) strGroupCode=arrGroup[i].m_strWBCode;
					else if(m_intInputType==2) strGroupCode=arrGroup[i].m_strPYCode;

					//ListViewItem objItem=new ListViewItem(arrGroup[i].m_strName,c_intItem_Group);
					//用户编码
					ListViewItem objItem=new ListViewItem("",0);
					//组套名称
					objItem.SubItems.Add(arrGroup[i].m_strName);
					//备注
					objItem.SubItems.Add(arrGroup[i].m_strDes);
					objItem.Tag=arrGroup[i];
					m_arlItems.Add(objItem);
				}
			}
//
//			//基本项目
//			clsBIHOrderDic[] arrDic;
//			long ret2=m_objService.m_lngGetOrderDicByCode(strFindCode,out arrDic);
//			if((ret2>0) && (arrDic!=null) && (arrDic.Length>0))
//			{
//				for(int i=0;i<arrDic.Length;i++)
//				{
//					string strDicCode=arrDic[i].m_strUserCode;
//					if(m_intInputType==1) strDicCode=arrDic[i].m_strWBCode;
//					else if(m_intInputType==2) strDicCode=arrDic[i].m_strPYCode;
//
//					//ListViewItem objItem=new ListViewItem(strDicCode,c_intItem_Order);
//					//objItem.SubItems.Add(arrDic[i].m_strName);//项目名称
//					//ListViewItem objItem=new ListViewItem(arrDic[i].m_strName,c_intItem_Order);
//					//用户编码
//					ListViewItem objItem=new ListViewItem(arrDic[i].m_strUserCode,c_intItem_Order);
//					//项目名称
//					objItem.SubItems.Add(arrDic[i].m_strName);
//					//项目规格
//					objItem.SubItems.Add(arrDic[i].m_strSpec);
//					//包装
//					objItem.SubItems.Add(arrDic[i].m_StrPackage);
//					//住院单价
//					objItem.SubItems.Add(arrDic[i].m_dmlPrice.ToString("0.0000"));
//					objItem.Tag=arrDic[i];
//					m_arlItems.Add(objItem);
//				}
//			}			
//
//			if(m_arlItems.Count>0)
//			{
//				ListViewItem[] arrItem=(ListViewItem[])(m_arlItems.ToArray(typeof(ListViewItem)));
//				lvwList.Items.AddRange(arrItem);
//			}
//			else
//			{	//如果没有值则，报告没有查到，否则调转焦点
//				if(m_txtOrderName.Tag==null || m_txtOrderName.Tag.ToString().Trim()=="")
//				{
//					MessageBox.Show("没有找到对应的医嘱或组套，请输入其它的查询条件","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
//					m_txtOrderName.SelectAll();
//				}
//				else
//				{
//					m_txtExecuteFreq.Focus();
//				}
//			}
		}

		private void dtgOrders_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
			this.pnlInput.Left=dtgOrders.DisplayRectangle.Left;
			this.pnlInput.Top=dtgOrders.DisplayRectangle.Top;
		}
	}
}
