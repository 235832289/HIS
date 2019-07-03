using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmLocatingDay 的摘要说明。
	/// </summary>
	public class frmLocatingDayFs : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.Label label3;
		private PinkieControls.ButtonXP btnEsc;
		private PinkieControls.ButtonXP btnReset;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ListView listView3;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLocatingDayFs()
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
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnReset = new PinkieControls.ButtonXP();
			this.btnEsc = new PinkieControls.ButtonXP();
			this.label3 = new System.Windows.Forms.Label();
			this.listView2 = new System.Windows.Forms.ListView();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.listView3 = new System.Windows.Forms.ListView();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader4,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader8});
			this.listView1.Enabled = false;
			this.listView1.FullRowSelect = true;
			this.listView1.Location = new System.Drawing.Point(8, 40);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(520, 40);
			this.listView1.TabIndex = 2;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "现金支付金额";
			this.columnHeader1.Width = 106;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "银行卡支付金额";
			this.columnHeader2.Width = 114;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "支票支付金额";
			this.columnHeader3.Width = 99;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "IC卡支付金额";
			this.columnHeader4.Width = 100;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "其它支付金额";
			this.columnHeader8.Width = 100;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("宋体", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label2.ForeColor = System.Drawing.Color.OrangeRed;
			this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label2.Location = new System.Drawing.Point(120, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(408, 24);
			this.label2.TabIndex = 1;
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label1.Location = new System.Drawing.Point(3, 4);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(120, 32);
			this.label1.TabIndex = 0;
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.listView3);
			this.panel1.Controls.Add(this.btnReset);
			this.panel1.Controls.Add(this.btnEsc);
			this.panel1.Controls.Add(this.label3);
			this.panel1.Controls.Add(this.listView2);
			this.panel1.Controls.Add(this.listView1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(536, 277);
			this.panel1.TabIndex = 1;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// btnReset
			// 
			this.btnReset.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnReset.DefaultScheme = true;
			this.btnReset.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnReset.Hint = "";
			this.btnReset.Location = new System.Drawing.Point(368, 160);
			this.btnReset.Name = "btnReset";
			this.btnReset.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnReset.Size = new System.Drawing.Size(128, 40);
			this.btnReset.TabIndex = 7;
			this.btnReset.Text = "刷新（F5）";
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnEsc
			// 
			this.btnEsc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btnEsc.DefaultScheme = true;
			this.btnEsc.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btnEsc.Hint = "";
			this.btnEsc.Location = new System.Drawing.Point(368, 224);
			this.btnEsc.Name = "btnEsc";
			this.btnEsc.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btnEsc.Size = new System.Drawing.Size(128, 40);
			this.btnEsc.TabIndex = 6;
			this.btnEsc.Text = "退出（ESC）";
			this.btnEsc.Click += new System.EventHandler(this.btnEsc_Click);
			// 
			// label3
			// 
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.label3.Location = new System.Drawing.Point(8, 128);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "发票号：";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// listView2
			// 
			this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader6,
																						this.columnHeader7});
			this.listView2.FullRowSelect = true;
			this.listView2.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView2.Location = new System.Drawing.Point(7, 152);
			this.listView2.MultiSelect = false;
			this.listView2.Name = "listView2";
			this.listView2.Size = new System.Drawing.Size(329, 120);
			this.listView2.TabIndex = 3;
			this.listView2.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "开始发票号";
			this.columnHeader6.Width = 130;
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "结束发票号";
			this.columnHeader7.Width = 130;
			// 
			// listView3
			// 
			this.listView3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.listView3.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader9,
																						this.columnHeader10,
																						this.columnHeader11,
																						this.columnHeader12,
																						this.columnHeader14});
			this.listView3.Enabled = false;
			this.listView3.FullRowSelect = true;
			this.listView3.Location = new System.Drawing.Point(8, 80);
			this.listView3.Name = "listView3";
			this.listView3.Size = new System.Drawing.Size(520, 40);
			this.listView3.TabIndex = 8;
			this.listView3.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "公费记帐金额";
			this.columnHeader9.Width = 105;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "特困记帐金额";
			this.columnHeader10.Width = 100;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "离休记帐金额";
			this.columnHeader11.Width = 115;
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "本院记帐金额";
			this.columnHeader12.Width = 100;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "其它记帐金额";
			this.columnHeader14.Width = 100;
			// 
			// frmLocatingDayFs
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(536, 277);
			this.Controls.Add(this.panel1);
			this.KeyPreview = true;
			this.MaximizeBox = false;
			this.Name = "frmLocatingDayFs";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "收费跟踪";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLocatingDay_KeyDown);
			this.Load += new System.EventHandler(this.frmLocatingDay_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region 变量
		clsDomainControl_Register Domain=new clsDomainControl_Register();
		string checkDate;//保存服务器时间
		private DataTable dtCheckOut=new DataTable();//保存返回的数据
		private DataTable dtStatistics;//生成统计表

		#endregion

		private void frmLocatingDay_Load(object sender, System.EventArgs e)
		{
			com.digitalwave.iCare.middletier.HIS.clsHisBase  HisBase=new com.digitalwave.iCare.middletier.HIS.clsHisBase();
			checkDate=HisBase.s_GetServerDate().ToShortDateString();
			label1.Text=this.LoginInfo.m_strEmpName+"合计金额:";
			m_GetAndFillData();
		
		}

		#region 获取数据
		private void m_GetAndFillData()
		{
			Domain.m_lngGetOneDayData(this.LoginInfo.m_strEmpID,checkDate,out dtCheckOut);
			#region 生成一个统计表
			dtStatistics=new DataTable();
			dtStatistics.Columns.Add("实收金额合计");
			dtStatistics.Columns.Add("实收现金合计");
			dtStatistics.Columns.Add("刷卡金额合计");
			dtStatistics.Columns.Add("支票金额合计");
			dtStatistics.Columns.Add("医保记账金额");
			dtStatistics.Columns.Add("公费记账金额");
			dtStatistics.Columns.Add("自费上缴金额");
			dtStatistics.Columns.Add("开票金额");
			dtStatistics.Columns.Add("退票金额合计");
			dtStatistics.Columns.Add("恢复金额合计");
			dtStatistics.Columns.Add("其它金额合计");

			dtStatistics.Columns.Add("IC卡支付金额");
			dtStatistics.Columns.Add("特困记帐金额");
			dtStatistics.Columns.Add("离休记帐金额");
			dtStatistics.Columns.Add("本院记帐金额");
			dtStatistics.Columns.Add("其它记帐金额");

		
			#endregion

			#region 统计数据
			DataRow StatisticsRow=dtStatistics.NewRow();
			StatisticsRow["实收金额合计"]=0.00;
			StatisticsRow["实收现金合计"]=0.00;
			StatisticsRow["刷卡金额合计"]=0.00;
			StatisticsRow["支票金额合计"]=0.00;
			StatisticsRow["医保记账金额"]=0.00;
			StatisticsRow["公费记账金额"]=0.00;
			StatisticsRow["自费上缴金额"]=0.00;

			StatisticsRow["开票金额"]=0.00;
			StatisticsRow["退票金额合计"]=0.00;
			StatisticsRow["恢复金额合计"]=0.00;
			StatisticsRow["其它金额合计"]=0.00;

			StatisticsRow["IC卡支付金额"]=0.00;
			StatisticsRow["特困记帐金额"]=0.00;
			StatisticsRow["离休记帐金额"]=0.00;
			StatisticsRow["本院记帐金额"]=0.00;
			StatisticsRow["其它记帐金额"]=0.00;
			if(dtCheckOut.Rows.Count>0)
			{
				for(int i1=0;i1<dtCheckOut.Rows.Count;i1++)
				{
					if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="1")//统计开票数,开票金额
					{
						StatisticsRow["开票金额"]=Convert.ToDouble(StatisticsRow["开票金额"].ToString())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
					}

					if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="2")//退票数,退票金额合计,所有的退票号
					{
						StatisticsRow["退票金额合计"]=Convert.ToDouble(StatisticsRow["退票金额合计"].ToString())-Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
					}

					if(dtCheckOut.Rows[i1]["STATUS_INT"].ToString().Trim()=="3")//恢复票数,恢复金额合计
					{
						StatisticsRow["恢复金额合计"]=Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
					}
					if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="0")//统计现金合计
					{
						StatisticsRow["实收现金合计"]=Convert.ToDouble(StatisticsRow["实收现金合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
					}
					if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="1")//刷卡合计
					{
						StatisticsRow["刷卡金额合计"]=Convert.ToDouble(StatisticsRow["刷卡金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
					}

					if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="2")//支票
					{
						StatisticsRow["支票金额合计"]=Convert.ToDouble(StatisticsRow["支票金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
					}
				
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="2")//医保记账金额及人次
					{
						StatisticsRow["医保记账金额"]=Convert.ToDouble(StatisticsRow["医保记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
					}
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="1")//公费记账金额及人次
					{
						StatisticsRow["公费记账金额"]=Convert.ToDouble(StatisticsRow["公费记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
					}
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="0")//自费上缴金额及人次
					{
						StatisticsRow["自费上缴金额"]=Convert.ToDouble(StatisticsRow["自费上缴金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());
					}



					#region 特困记账金额
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="3")
					{
						StatisticsRow["特困记帐金额"]=Convert.ToDouble(StatisticsRow["特困记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
					}

					#endregion

					#region 离休记账金额
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="4")
					{
							StatisticsRow["离休记帐金额"]=Convert.ToDouble(StatisticsRow["离休记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
					}

					#endregion

					#region 本院记账金额
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()=="5")
					{
						StatisticsRow["本院记账金额"]=Convert.ToDouble(StatisticsRow["本院记账金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
					}

					#endregion

					#region IC卡支付
				
					if(dtCheckOut.Rows[i1]["PAYTYPE_INT"].ToString().Trim()=="3")
					{
						StatisticsRow["IC卡支付金额"]=Convert.ToDouble(StatisticsRow["IC卡支付金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["TOTALSUM_MNY"].ToString());

					}

					#endregion

					#region 其它金额合计
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="0"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="1"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="2"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="3"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="4"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="5")
					{
							StatisticsRow["其它金额合计"]=Convert.ToDouble(StatisticsRow["其它金额合计"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["SBSUM_MNY"].ToString());
					
					}

					#endregion

					#region 其它记帐金额合计
					if(dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="0"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="1"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="2"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="3"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="4"&&dtCheckOut.Rows[i1]["INTERNALFLAG_INT"].ToString().Trim()!="5")
					{
						StatisticsRow["其它记帐金额"]=Convert.ToDouble(StatisticsRow["其它记帐金额"].ToString().Trim())+Convert.ToDouble(dtCheckOut.Rows[i1]["ACCTSUM_MNY"].ToString());
					
					}

					#endregion
				}
			}
			Double AvailabilityMoney=Convert.ToDouble(StatisticsRow["开票金额"].ToString().Trim())-Convert.ToDouble(StatisticsRow["退票金额合计"].ToString().Trim())+Convert.ToDouble(StatisticsRow["恢复金额合计"].ToString().Trim());
			StatisticsRow["实收金额合计"]=AvailabilityMoney.ToString();
			#endregion
			listView1.Items.Clear();
			string strMoney=clsMain.CurrencyToString(Math.Abs(float.Parse(StatisticsRow["实收金额合计"].ToString())));
			label2.Text=strMoney+"(￥"+StatisticsRow["实收金额合计"].ToString()+")";
			ListViewItem addItem=new ListViewItem("￥"+StatisticsRow["实收现金合计"].ToString());
			addItem.SubItems.Add("￥"+StatisticsRow["IC卡支付金额"].ToString());
			addItem.SubItems.Add("￥"+StatisticsRow["刷卡金额合计"].ToString());
			addItem.SubItems.Add("￥"+StatisticsRow["支票金额合计"].ToString());
			addItem.SubItems.Add("￥"+StatisticsRow["其它金额合计"].ToString());
			listView1.Items.Add(addItem);
			
			ListViewItem addItem1=new ListViewItem("￥"+StatisticsRow["公费记账金额"].ToString());
			addItem1.SubItems.Add("￥"+StatisticsRow["特困记帐金额"].ToString());
			addItem1.SubItems.Add("￥"+StatisticsRow["离休记帐金额"].ToString());
			addItem1.SubItems.Add("￥"+StatisticsRow["本院记帐金额"].ToString());
			addItem1.SubItems.Add("￥"+StatisticsRow["其它记帐金额"].ToString());
			listView3.Items.Add(addItem1);
			ArrayList arrList=new ArrayList();
			clsMain.m_Detach(dtCheckOut,"INVOICENO_VCHR",out arrList);
			ListViewItem newItem=null;
			string temsun="";
			listView2.Items.Clear();
			if(arrList.Count>0)
			{
				temsun=arrList[0].ToString();
				for(int i1=0;i1<arrList.Count;i1++)
				{
					if(arrList[i1].ToString()==",")
					{
						newItem=new ListViewItem(temsun);
						newItem.SubItems.Add(arrList[i1-1].ToString());
						listView2.Items.Add(newItem);
						temsun=arrList[i1+1].ToString();
					}

				}
				newItem=new ListViewItem(temsun);
				newItem.SubItems.Add(arrList[arrList.Count-1].ToString());
				listView2.Items.Add(newItem);
			}

		}


		#endregion

		private void btnEsc_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnReset_Click(object sender, System.EventArgs e)
		{
		    frmLocatingDay_Load(null,null);
		}

		private void frmLocatingDay_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.F5)
				frmLocatingDay_Load(null,null);
			if(e.KeyCode==Keys.Escape)
				this.Close();

		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}
	}
}
