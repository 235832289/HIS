using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 调转——界面表示层
	/// 作者： 徐斌辉
	/// 创建时间： 2004-09-09
	/// </summary>
	public class frmBIHRecall : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
	{
		#region 控件申明

		private System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Label m_lblBEDID_CHR;
		internal System.Windows.Forms.Label m_lblAREAID_CHR;
		internal System.Windows.Forms.Label m_lblDEPTID_CHR;
		internal System.Windows.Forms.Label m_lblPatientName;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox m_txtDES;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private PinkieControls.ButtonXP cmdRecall;
		private PinkieControls.ButtonXP cmdCancel;
		internal System.Windows.Forms.ListView lsvAreaInfo;
		private System.Windows.Forms.ColumnHeader ColumnNum;
		private System.Windows.Forms.ColumnHeader ColumnName;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;		

		internal string m_strRegisterID ="";	//入院登记流水号(200409010001)
		internal string m_strSourceDeptID ="";	//源科室id
		internal string m_strSourceAreaID ="";	//源病区id
		internal string m_strSourceBedID ="";
		internal System.Windows.Forms.TextBox m_txtAREAID_CHR;	//源病床id
		internal bool m_IsOK;//操作是否成功
		#endregion 

		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		/// <param name="p_strRegisterID">入院登记流水号(200409010001)</param>
		/// <param name="p_strSourceDeptID">出院时科室</param>
		/// <param name="p_strSourceAreaID">出院时病区</param>
		/// <param name="p_strSourceBedID">出院时病床</param>
		public frmBIHRecall(string p_strRegisterID,string p_strSourceDeptID,string p_strSourceAreaID,string p_strSourceBedID)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			m_strRegisterID =p_strRegisterID;
			m_strSourceDeptID =p_strSourceDeptID;
			m_strSourceAreaID =p_strSourceAreaID;
			m_strSourceBedID =p_strSourceBedID;
			
			//操作是否成功
			m_IsOK =false;
			#region 临时控件
			//Dept
//			lsvDeptInfo = new ListView();
//			this.lsvDeptInfo.DoubleClick += new System.EventHandler(this.lsvDeptInfo_DoubleClick);
//			this.lsvDeptInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvDeptInfo_KeyDown);
//			this.lsvDeptInfo.Leave += new System.EventHandler(this.lsvDeptInfo_Leave);
			//Area
			lsvAreaInfo = new ListView();
			this.lsvAreaInfo.DoubleClick += new System.EventHandler(this.lsvAreaInfo_DoubleClick);
			this.lsvAreaInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvAreaInfo_KeyDown);
			this.lsvAreaInfo.Leave += new System.EventHandler(this.lsvAreaInfo_Leave);
			#endregion
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
		#endregion 

		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.label10 = new System.Windows.Forms.Label();
			this.m_lblBEDID_CHR = new System.Windows.Forms.Label();
			this.m_lblAREAID_CHR = new System.Windows.Forms.Label();
			this.m_lblDEPTID_CHR = new System.Windows.Forms.Label();
			this.m_lblPatientName = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtDES = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdRecall = new PinkieControls.ButtonXP();
			this.cmdCancel = new PinkieControls.ButtonXP();
			this.m_txtAREAID_CHR = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label10.Location = new System.Drawing.Point(256, 98);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(63, 19);
			this.label10.TabIndex = 53;
			this.label10.Text = "召回病区";
			// 
			// m_lblBEDID_CHR
			// 
			this.m_lblBEDID_CHR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lblBEDID_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblBEDID_CHR.Location = new System.Drawing.Point(344, 16);
			this.m_lblBEDID_CHR.Name = "m_lblBEDID_CHR";
			this.m_lblBEDID_CHR.Size = new System.Drawing.Size(120, 21);
			this.m_lblBEDID_CHR.TabIndex = 47;
			// 
			// m_lblAREAID_CHR
			// 
			this.m_lblAREAID_CHR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lblAREAID_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblAREAID_CHR.Location = new System.Drawing.Point(344, 52);
			this.m_lblAREAID_CHR.Name = "m_lblAREAID_CHR";
			this.m_lblAREAID_CHR.Size = new System.Drawing.Size(120, 21);
			this.m_lblAREAID_CHR.TabIndex = 46;
			// 
			// m_lblDEPTID_CHR
			// 
			this.m_lblDEPTID_CHR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lblDEPTID_CHR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblDEPTID_CHR.Location = new System.Drawing.Point(112, 51);
			this.m_lblDEPTID_CHR.Name = "m_lblDEPTID_CHR";
			this.m_lblDEPTID_CHR.Size = new System.Drawing.Size(120, 21);
			this.m_lblDEPTID_CHR.TabIndex = 49;
			// 
			// m_lblPatientName
			// 
			this.m_lblPatientName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lblPatientName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lblPatientName.Location = new System.Drawing.Point(112, 15);
			this.m_lblPatientName.Name = "m_lblPatientName";
			this.m_lblPatientName.Size = new System.Drawing.Size(120, 21);
			this.m_lblPatientName.TabIndex = 48;
			// 
			// label6
			// 
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label6.Location = new System.Drawing.Point(67, 201);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(24, 38);
			this.label6.TabIndex = 45;
			this.label6.Text = "备注";
			// 
			// m_txtDES
			// 
			this.m_txtDES.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtDES.Location = new System.Drawing.Point(96, 132);
			this.m_txtDES.Multiline = true;
			this.m_txtDES.Name = "m_txtDES";
			this.m_txtDES.Size = new System.Drawing.Size(512, 208);
			this.m_txtDES.TabIndex = 30;
			this.m_txtDES.Text = "";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label4.Location = new System.Drawing.Point(256, 57);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 19);
			this.label4.TabIndex = 40;
			this.label4.Text = "出院病区";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.Location = new System.Drawing.Point(256, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 19);
			this.label3.TabIndex = 39;
			this.label3.Text = "出院病床";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.Location = new System.Drawing.Point(28, 58);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 19);
			this.label2.TabIndex = 38;
			this.label2.Text = "出院科室";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.Location = new System.Drawing.Point(57, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 19);
			this.label1.TabIndex = 37;
			this.label1.Text = "姓名";
			// 
			// cmdRecall
			// 
			this.cmdRecall.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdRecall.DefaultScheme = true;
			this.cmdRecall.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdRecall.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdRecall.Hint = "";
			this.cmdRecall.Location = new System.Drawing.Point(496, 24);
			this.cmdRecall.Name = "cmdRecall";
			this.cmdRecall.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdRecall.Size = new System.Drawing.Size(96, 31);
			this.cmdRecall.TabIndex = 40;
			this.cmdRecall.Text = "召回(F2)";
			this.cmdRecall.Click += new System.EventHandler(this.cmdRecall_Click);
			// 
			// cmdCancel
			// 
			this.cmdCancel.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.cmdCancel.DefaultScheme = true;
			this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.None;
			this.cmdCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.cmdCancel.Hint = "";
			this.cmdCancel.Location = new System.Drawing.Point(496, 80);
			this.cmdCancel.Name = "cmdCancel";
			this.cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.cmdCancel.Size = new System.Drawing.Size(96, 31);
			this.cmdCancel.TabIndex = 6;
			this.cmdCancel.Text = "关闭(Esc)";
			this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
			// 
			// m_txtAREAID_CHR
			// 
			this.m_txtAREAID_CHR.Location = new System.Drawing.Point(344, 88);
			this.m_txtAREAID_CHR.MaxLength = 20;
			this.m_txtAREAID_CHR.Name = "m_txtAREAID_CHR";
			this.m_txtAREAID_CHR.Size = new System.Drawing.Size(120, 26);
			this.m_txtAREAID_CHR.TabIndex = 20;
			this.m_txtAREAID_CHR.Text = "";
			this.m_txtAREAID_CHR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtAREAID_CHR_KeyDown);
			// 
			// frmBIHRecall
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(8, 19);
			this.ClientSize = new System.Drawing.Size(664, 357);
			this.Controls.Add(this.m_txtAREAID_CHR);
			this.Controls.Add(this.m_lblBEDID_CHR);
			this.Controls.Add(this.m_lblAREAID_CHR);
			this.Controls.Add(this.m_lblDEPTID_CHR);
			this.Controls.Add(this.m_lblPatientName);
			this.Controls.Add(this.cmdRecall);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.m_txtDES);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.cmdCancel);
			this.Font = new System.Drawing.Font("宋体", 12F);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmBIHRecall";
			this.Text = "";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmBIHRecall_KeyDown);
			this.Load += new System.EventHandler(this.frmBIHRecall_Load);
			this.ResumeLayout(false);

		}
		#endregion

		public override void CreateController()
		{
			this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_BIHRecall();
			objController.Set_GUI_Apperance(this);
		}

		#region 事件
		private void cmdRecall_Click(object sender, System.EventArgs e)
		{
			this.Cursor =Cursors.WaitCursor;
			((clsCtl_BIHRecall)this.objController).m_cmdRecall();
			this.Cursor =Cursors.Default;
		}

		private void cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		#region 科室、病区、床号
		private void m_txtDEPTID_CHR_Leave(object sender, System.EventArgs e)
		{
			m_txtAREAID_CHR.Text ="";
			//载入科室对应的病区
			((clsCtl_BIHRecall)this.objController).LoadAreaID();
		}

//		private void m_txtDEPTID_CHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
//			if(e.KeyCode==Keys.Enter)
//			{
//				m_txtAREAID_CHR.Focus();
//			}
//		}
		private void m_txtBEDID_CHR_Leave(object sender, System.EventArgs e)
		{
			
		}

		private void m_txtBEDID_CHR_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				m_txtDES.Focus();
			}
		}

		#endregion

		private void frmBIHRecall_Load(object sender, System.EventArgs e)
		{
			//初始化科室、病区、病床
//			((clsCtl_BIHRecall)this.objController).LoadDeptID();
//			((clsCtl_BIHRecall)this.objController).LoadAreaID();
		}
		#endregion

		private void frmBIHRecall_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			m_mthSetKeyTab(e);
			switch (e.KeyCode)
			{
				case Keys.Escape:
					if(MessageBox.Show("是否确定退出","提示",MessageBoxButtons.YesNo,MessageBoxIcon.None)==DialogResult.Yes)
					{
						this.Close();
					}
					break;
				case Keys.F2:
					cmdRecall_Click(sender,e);	
					break;
			}
		}
//		#region 部门查找
//		private void lsvDeptInfo_DoubleClick(object sender, System.EventArgs e)
//		{
//			if(this.lsvDeptInfo.SelectedItems.Count>0)
//			{
//				this.m_txtDEPTID_CHR.Text = this.lsvDeptInfo.SelectedItems[0].Text;
//				this.m_txtDEPTID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvDeptInfo.SelectedItems[0].Tag).m_strDEPTID_CHR;
//				this.lsvDeptInfo.Visible = false;
//				this.m_txtAREAID_CHR.Focus();
//			}
//		}
//		private void lsvDeptInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
//			if(e.KeyCode==Keys.Enter)
//			{
//				lsvDeptInfo_DoubleClick(null,null);
//			}
//		}
//		private void lsvDeptInfo_Leave(object sender, System.EventArgs e)
//		{
//			this.lsvDeptInfo.Visible = false;
//		}
//		#endregion
		#region 病区查找
		private void lsvAreaInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.lsvAreaInfo.SelectedItems.Count>0)
			{
				this.m_txtAREAID_CHR.Text = this.lsvAreaInfo.SelectedItems[0].SubItems[1].Text;
				this.m_txtAREAID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.SelectedItems[0].Tag).m_strDEPTID_CHR;
				this.lsvAreaInfo.Visible = false;
				this.m_txtDES.Focus();
			}
		}
		private void lsvAreaInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				lsvAreaInfo_DoubleClick(null,null);
			}
		}
		private void lsvAreaInfo_Leave(object sender, System.EventArgs e)
		{
			this.lsvAreaInfo.Visible = false;
		}
		#endregion

		private void m_txtAREAID_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				#region 控件处理

				#region 病区编号	glzhang	200.07.29
				this.ColumnNum = new System.Windows.Forms.ColumnHeader();
				this.ColumnNum.Text = "病区编号";
				this.ColumnNum.Width = 80;
				#endregion

				this.ColumnName = new System.Windows.Forms.ColumnHeader();
				this.ColumnName.Text = "病区名称 ";
				this.ColumnName.Width = 120;
				this.lsvAreaInfo.Size = new System.Drawing.Size(200, 144);
				
				this.lsvAreaInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  ColumnNum,this.ColumnName});
				this.lsvAreaInfo.View = System.Windows.Forms.View.Details;
				this.lsvAreaInfo.FullRowSelect = true;
				this.lsvAreaInfo.GridLines = true;
				((clsCtl_BIHRecall)this.objController).LoadAreaID();
				if(lsvAreaInfo.Items.Count<1)
					return;
				if(lsvAreaInfo.Items.Count==1)
				{
					this.m_txtAREAID_CHR.Text = this.lsvAreaInfo.Items[0].SubItems[1].Text;
					this.m_txtAREAID_CHR.Tag = ((com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO)this.lsvAreaInfo.Items[0].Tag).m_strDEPTID_CHR;
					this.m_txtDES.Focus();
					return;
				}
				this.Controls.Add(this.lsvAreaInfo);
				this.lsvAreaInfo.Location =new  System.Drawing.Point(288,112);
				#endregion
				this.lsvAreaInfo.Items[0].Selected = true;
				this.lsvAreaInfo.Show();
				this.lsvAreaInfo.BringToFront();
				this.lsvAreaInfo.Focus();
			}
		}

//		private void m_txtDEPTID_CHR_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
//		{
//			if(e.KeyCode==Keys.Enter)
//			{
//				#region 控件处理
//				this.ColumnName = new System.Windows.Forms.ColumnHeader();
//				this.ColumnName.Text = "";
//				this.ColumnName.Width = 280;
//				this.lsvDeptInfo.Size = new System.Drawing.Size(304, 144);
//				
//				this.lsvDeptInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
//																							  this.ColumnName});
//				this.lsvDeptInfo.View = System.Windows.Forms.View.Details;
//				this.lsvDeptInfo.GridLines = true;
//				((clsCtl_BIHRecall)this.objController).LoadDeptID();
//				if(lsvDeptInfo.Items.Count<1)
//					return;
//				this.Controls.Add(this.lsvDeptInfo);
//				this.lsvDeptInfo.Location =new  System.Drawing.Point(96,112);
//				#endregion
//				this.lsvDeptInfo.Show();
//				this.lsvDeptInfo.BringToFront();
//				this.lsvDeptInfo.Focus();
//			}
//		}
	}
}
