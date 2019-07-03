using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmMain 的摘要说明。
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem m_muDayPlan;
		private System.Windows.Forms.MenuItem m_muWeekPlan;
		private System.Windows.Forms.MenuItem m_muExit;
		private System.Windows.Forms.MenuItem m_muPatReg;
		private System.Windows.Forms.MenuItem m_muRegister;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem m_muChargeItem;
		private System.Windows.Forms.MenuItem m_muItemType;
		private System.Windows.Forms.MenuItem m_muUsag;
		private System.Windows.Forms.MenuItem m_muFeeType;
		private System.Windows.Forms.MenuItem m_muUsageItem;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem m_muOPDoc;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem m_muOPInvo;
		private System.Windows.Forms.MenuItem m_muPatRegFee;
		private System.Windows.Forms.MenuItem m_muRegChargeType;
		private System.Windows.Forms.MenuItem m_muRegType;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem m_muCookingMethod;
		private System.Windows.Forms.MenuItem m_muPatientPayType;
		private System.Windows.Forms.MenuItem m_muRecipeFequency;
		private System.Windows.Forms.MenuItem m_muHospitalInfo;
		private System.Windows.Forms.MenuItem m_muUsageType;
		private System.Windows.Forms.MenuItem m_muHISModuleDef;
		private System.Windows.Forms.MenuItem m_muErrorLog;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem m_muLoginInfo;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem m_muCheckOutReg;
		private System.Windows.Forms.MenuItem m_muQulReg;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem20;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.Windows.Forms.MenuItem menuItem25;
		private System.Windows.Forms.MenuItem menuItem26;
		private System.Windows.Forms.MenuItem menuItem27;
		private System.Windows.Forms.MenuItem menuItem28;
		private System.Windows.Forms.MenuItem menuItem29;
		private System.Windows.Forms.MenuItem menuItem30;
		private System.Windows.Forms.MenuItem menuItem31;
		private System.Windows.Forms.MenuItem menuItem32;
		private System.Windows.Forms.MenuItem menuItem33;
		private System.ComponentModel.IContainer components;

		public frmMain()
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.m_muPatReg = new System.Windows.Forms.MenuItem();
			this.m_muRegister = new System.Windows.Forms.MenuItem();
			this.m_muQulReg = new System.Windows.Forms.MenuItem();
			this.m_muCheckOutReg = new System.Windows.Forms.MenuItem();
			this.m_muExit = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.m_muDayPlan = new System.Windows.Forms.MenuItem();
			this.m_muWeekPlan = new System.Windows.Forms.MenuItem();
			this.m_muPatRegFee = new System.Windows.Forms.MenuItem();
			this.m_muRegChargeType = new System.Windows.Forms.MenuItem();
			this.m_muRegType = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.m_muCookingMethod = new System.Windows.Forms.MenuItem();
			this.m_muPatientPayType = new System.Windows.Forms.MenuItem();
			this.m_muRecipeFequency = new System.Windows.Forms.MenuItem();
			this.m_muHospitalInfo = new System.Windows.Forms.MenuItem();
			this.m_muHISModuleDef = new System.Windows.Forms.MenuItem();
			this.m_muErrorLog = new System.Windows.Forms.MenuItem();
			this.m_muLoginInfo = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.m_muChargeItem = new System.Windows.Forms.MenuItem();
			this.m_muItemType = new System.Windows.Forms.MenuItem();
			this.m_muUsag = new System.Windows.Forms.MenuItem();
			this.m_muFeeType = new System.Windows.Forms.MenuItem();
			this.m_muUsageItem = new System.Windows.Forms.MenuItem();
			this.m_muUsageType = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem25 = new System.Windows.Forms.MenuItem();
			this.menuItem29 = new System.Windows.Forms.MenuItem();
			this.menuItem32 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem26 = new System.Windows.Forms.MenuItem();
			this.menuItem27 = new System.Windows.Forms.MenuItem();
			this.menuItem28 = new System.Windows.Forms.MenuItem();
			this.menuItem30 = new System.Windows.Forms.MenuItem();
			this.menuItem31 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.m_muOPDoc = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.m_muOPInvo = new System.Windows.Forms.MenuItem();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.menuItem33 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem6,
																					  this.menuItem4,
																					  this.menuItem3,
																					  this.menuItem5,
																					  this.menuItem7});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.m_muPatReg,
																					  this.m_muRegister,
																					  this.m_muQulReg,
																					  this.m_muCheckOutReg,
																					  this.m_muExit,
																					  this.menuItem13});
			this.menuItem1.Text = "挂号";
			// 
			// m_muPatReg
			// 
			this.m_muPatReg.Index = 0;
			this.m_muPatReg.Text = "病人登记";
			this.m_muPatReg.Click += new System.EventHandler(this.m_muPatReg_Click);
			// 
			// m_muRegister
			// 
			this.m_muRegister.Index = 1;
			this.m_muRegister.Text = "挂        号";
			this.m_muRegister.Click += new System.EventHandler(this.m_muRegister_Click);
			// 
			// m_muQulReg
			// 
			this.m_muQulReg.Index = 2;
			this.m_muQulReg.Text = "挂号查询";
			this.m_muQulReg.Click += new System.EventHandler(this.m_muQulReg_Click);
			// 
			// m_muCheckOutReg
			// 
			this.m_muCheckOutReg.Index = 3;
			this.m_muCheckOutReg.Text = "挂号结帐";
			this.m_muCheckOutReg.Click += new System.EventHandler(this.m_muCheckOutReg_Click);
			// 
			// m_muExit
			// 
			this.m_muExit.Index = 4;
			this.m_muExit.Text = "退        出";
			this.m_muExit.Click += new System.EventHandler(this.m_muExit_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 5;
			this.menuItem13.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem14,
																					   this.menuItem16,
																					   this.menuItem15,
																					   this.menuItem17});
			this.menuItem13.Text = "报表";
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 0;
			this.menuItem14.Text = "门诊挂号医生收入报表";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 1;
			this.menuItem16.Text = "门诊挂号科室收入报表";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 2;
			this.menuItem15.Text = "门诊挂号人数安星期汇总分析图";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 3;
			this.menuItem17.Text = "门诊挂号人数安时段汇总分析图";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.m_muDayPlan,
																					  this.m_muWeekPlan,
																					  this.m_muPatRegFee,
																					  this.m_muRegChargeType,
																					  this.m_muRegType,
																					  this.menuItem8,
																					  this.m_muCookingMethod,
																					  this.m_muPatientPayType,
																					  this.m_muRecipeFequency,
																					  this.m_muHospitalInfo,
																					  this.m_muHISModuleDef,
																					  this.m_muErrorLog,
																					  this.m_muLoginInfo});
			this.menuItem2.Text = "维护";
			// 
			// m_muDayPlan
			// 
			this.m_muDayPlan.Index = 0;
			this.m_muDayPlan.Text = "日排班";
			this.m_muDayPlan.Click += new System.EventHandler(this.m_muDayPlan_Click);
			// 
			// m_muWeekPlan
			// 
			this.m_muWeekPlan.Index = 1;
			this.m_muWeekPlan.Text = "周排班";
			this.m_muWeekPlan.Click += new System.EventHandler(this.m_muWeekPlan_Click);
			// 
			// m_muPatRegFee
			// 
			this.m_muPatRegFee.Index = 2;
			this.m_muPatRegFee.Text = "挂号费用";
			this.m_muPatRegFee.Click += new System.EventHandler(this.m_muPatRegFee_Click);
			// 
			// m_muRegChargeType
			// 
			this.m_muRegChargeType.Index = 3;
			this.m_muRegChargeType.Text = "挂号费种";
			this.m_muRegChargeType.Click += new System.EventHandler(this.m_muRegChargeType_Click);
			// 
			// m_muRegType
			// 
			this.m_muRegType.Index = 4;
			this.m_muRegType.Text = "挂号种类";
			this.m_muRegType.Click += new System.EventHandler(this.m_muRegType_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 5;
			this.menuItem8.Text = "挂号费用维护";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// m_muCookingMethod
			// 
			this.m_muCookingMethod.Index = 6;
			this.m_muCookingMethod.Text = "煎制方法";
			this.m_muCookingMethod.Click += new System.EventHandler(this.m_muCookingMethod_Click);
			// 
			// m_muPatientPayType
			// 
			this.m_muPatientPayType.Index = 7;
			this.m_muPatientPayType.Text = "挂号身份";
			this.m_muPatientPayType.Click += new System.EventHandler(this.m_muPatientPayType_Click);
			// 
			// m_muRecipeFequency
			// 
			this.m_muRecipeFequency.Index = 8;
			this.m_muRecipeFequency.Text = "用药频率";
			this.m_muRecipeFequency.Click += new System.EventHandler(this.m_muRecipeFequency_Click);
			// 
			// m_muHospitalInfo
			// 
			this.m_muHospitalInfo.Index = 9;
			this.m_muHospitalInfo.Text = "医院基本信息";
			this.m_muHospitalInfo.Click += new System.EventHandler(this.m_muHospitalInfo_Click);
			// 
			// m_muHISModuleDef
			// 
			this.m_muHISModuleDef.Index = 10;
			this.m_muHISModuleDef.Text = "应用管理系统";
			this.m_muHISModuleDef.Click += new System.EventHandler(this.m_muHISModuleDef_Click);
			// 
			// m_muErrorLog
			// 
			this.m_muErrorLog.Index = 11;
			this.m_muErrorLog.Text = "系统错误信息记录";
			this.m_muErrorLog.Click += new System.EventHandler(this.m_muErrorLog_Click);
			// 
			// m_muLoginInfo
			// 
			this.m_muLoginInfo.Index = 12;
			this.m_muLoginInfo.Text = "用户登陆信息";
			this.m_muLoginInfo.Click += new System.EventHandler(this.m_muLoginInfo_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 2;
			this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.m_muChargeItem,
																					  this.m_muItemType,
																					  this.m_muUsag,
																					  this.m_muFeeType,
																					  this.m_muUsageItem,
																					  this.m_muUsageType,
																					  this.menuItem21,
																					  this.menuItem22,
																					  this.menuItem23,
																					  this.menuItem24,
																					  this.menuItem25,
																					  this.menuItem29,
																					  this.menuItem32});
			this.menuItem6.Text = "收费项目";
			// 
			// m_muChargeItem
			// 
			this.m_muChargeItem.Index = 0;
			this.m_muChargeItem.RadioCheck = true;
			this.m_muChargeItem.Text = "项目明细";
			this.m_muChargeItem.Click += new System.EventHandler(this.m_muChargeItem_Click);
			// 
			// m_muItemType
			// 
			this.m_muItemType.Index = 1;
			this.m_muItemType.Text = "项目类别";
			this.m_muItemType.Click += new System.EventHandler(this.m_muItemType_Click);
			// 
			// m_muUsag
			// 
			this.m_muUsag.Index = 2;
			this.m_muUsag.Text = "用法";
			this.m_muUsag.Click += new System.EventHandler(this.m_muUsag_Click);
			// 
			// m_muFeeType
			// 
			this.m_muFeeType.Index = 3;
			this.m_muFeeType.Text = "费用类型";
			this.m_muFeeType.Click += new System.EventHandler(this.m_muFeeType_Click);
			// 
			// m_muUsageItem
			// 
			this.m_muUsageItem.Index = 4;
			this.m_muUsageItem.Text = "用法项目维护";
			this.m_muUsageItem.Click += new System.EventHandler(this.m_muUsageItem_Click);
			// 
			// m_muUsageType
			// 
			this.m_muUsageType.Index = 5;
			this.m_muUsageType.Text = "收费项目用法";
			this.m_muUsageType.Click += new System.EventHandler(this.m_muUsageType_Click);
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 6;
			this.menuItem21.Text = "收费项目费用比例维护";
			this.menuItem21.Click += new System.EventHandler(this.menuItem21_Click);
			// 
			// menuItem22
			// 
			this.menuItem22.Index = 7;
			this.menuItem22.Text = "收费项目维护";
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 8;
			this.menuItem23.Text = "项目源维护";
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 9;
			this.menuItem24.Text = "药品药典ID维护";
			this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
			// 
			// menuItem25
			// 
			this.menuItem25.Index = 10;
			this.menuItem25.Text = "项目分类映射";
			this.menuItem25.Click += new System.EventHandler(this.menuItem25_Click);
			// 
			// menuItem29
			// 
			this.menuItem29.Index = 11;
			this.menuItem29.Text = "报表字段维护";
			this.menuItem29.Click += new System.EventHandler(this.menuItem29_Click);
			// 
			// menuItem32
			// 
			this.menuItem32.Index = 12;
			this.menuItem32.Text = "测试";
			this.menuItem32.Click += new System.EventHandler(this.menuItem32_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem9,
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem18,
																					  this.menuItem19,
																					  this.menuItem20,
																					  this.menuItem26,
																					  this.menuItem27,
																					  this.menuItem28,
																					  this.menuItem30,
																					  this.menuItem31,
																					  this.menuItem33});
			this.menuItem4.Text = "Test";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.Text = "AAA";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 1;
			this.menuItem10.Text = "门诊发票管理";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 2;
			this.menuItem11.Text = "门诊发票退票";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 3;
			this.menuItem12.Text = "门诊发票恢复";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 4;
			this.menuItem18.Text = "协定处方";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 5;
			this.menuItem19.Text = "价类管理";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 6;
			this.menuItem20.Text = "查看报告单";
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click_1);
			// 
			// menuItem26
			// 
			this.menuItem26.Index = 7;
			this.menuItem26.Text = "操作员日实收数";
			this.menuItem26.Click += new System.EventHandler(this.menuItem26_Click);
			// 
			// menuItem27
			// 
			this.menuItem27.Index = 8;
			this.menuItem27.Text = "收费处日结凭证";
			this.menuItem27.Click += new System.EventHandler(this.menuItem27_Click);
			// 
			// menuItem28
			// 
			this.menuItem28.Index = 9;
			this.menuItem28.Text = "收费处月结算表";
			this.menuItem28.Click += new System.EventHandler(this.menuItem28_Click);
			// 
			// menuItem30
			// 
			this.menuItem30.Index = 10;
			this.menuItem30.Text = "医保月结算表";
			this.menuItem30.Click += new System.EventHandler(this.menuItem30_Click);
			// 
			// menuItem31
			// 
			this.menuItem31.Index = 11;
			this.menuItem31.Text = "公费费用报表";
			this.menuItem31.Click += new System.EventHandler(this.menuItem31_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 4;
			this.menuItem3.MdiList = true;
			this.menuItem3.RadioCheck = true;
			this.menuItem3.Text = "窗口";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 5;
			this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.m_muOPDoc});
			this.menuItem5.Text = "医生工作站";
			// 
			// m_muOPDoc
			// 
			this.m_muOPDoc.Index = 0;
			this.m_muOPDoc.Text = "接诊";
			this.m_muOPDoc.Click += new System.EventHandler(this.m_muOPDoc_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 6;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.m_muOPInvo});
			this.menuItem7.Text = "收费处";
			// 
			// m_muOPInvo
			// 
			this.m_muOPInvo.Index = 0;
			this.m_muOPInvo.Text = "计价收费";
			this.m_muOPInvo.Click += new System.EventHandler(this.m_muOPInvo_Click);
			// 
			// toolTip1
			// 
			this.toolTip1.Active = false;
			this.toolTip1.AutomaticDelay = 100;
			this.toolTip1.AutoPopDelay = 10000;
			this.toolTip1.InitialDelay = 100;
			this.toolTip1.ReshowDelay = 1;
			// 
			// menuItem33
			// 
			this.menuItem33.Index = 12;
			this.menuItem33.Text = "报表";
			this.menuItem33.Click += new System.EventHandler(this.menuItem33_Click);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.BackColor = System.Drawing.SystemColors.ScrollBar;
			this.ClientSize = new System.Drawing.Size(576, 373);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "frmMain";
			this.Text = "门诊挂号系统";
			this.toolTip1.SetToolTip(this, "正在加载数据...请稍候！");
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;

		}
		#endregion
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}
		private ArrayList muWindow=new ArrayList();
		private void m_muWeekPlan_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmWeekPlan"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			this.toolTip1.Active=true;
			frmWeekPlan frm=new frmWeekPlan();
			frm.Show_MDI_Child(this);
			this.toolTip1.Active=false;
			this.Cursor=Cursors.Default;
		}

		private void m_muDayPlan_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmDayPlan"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			//			this.toolTip1.Active=true;
			frmDayPlan frm=new frmDayPlan();
			frm.Show_MDI_Child(this);
			//			this.toolTip1.Active=false;
			this.Cursor=Cursors.Default;
		}

		private void m_muExit_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void m_muRegister_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmRegister"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			this.toolTip1.Active=true;
			frmRegister frm=new frmRegister();
			frm.Show_MDI_Child(this);
			this.toolTip1.Active=false;
			this.Cursor=Cursors.Default;
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			Form1 frm=new Form1();
			frm.ShowDialog();
		}

		private void m_muChargeItem_Click(object sender, System.EventArgs e)
		{
			
		}

		private void m_muItemType_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmChargeCat"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmChargeCat frm=new frmChargeCat();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void m_muUsag_Click(object sender, System.EventArgs e)
		{ 
			if(FindWindow("frmUsage"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmUsage frm=new frmUsage();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}
		private bool FindWindow(string strText)
		{
			for(int i=0;i<this.MdiChildren.Length;i++)
			{
				string muText=this.MdiChildren[i].Name;
				if(strText==muText)
				{
					this.MdiChildren[i].Activate();
					return true;
				}
			}
			return false;
		}

		private void m_muFeeType_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmFeeType"))
			{
				return;
			}			  
			this.Cursor=Cursors.WaitCursor;
			frmFeeType frm=new frmFeeType();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void m_muUsageItem_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("FrmUsaGroup"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			FrmUsaGroup frm=new FrmUsaGroup();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void m_muOPDoc_Click(object sender, System.EventArgs e)
		{
			//			if(FindWindow("frmOPDoctor"))
			//			{
			//				return;
			//			}
			//			this.Cursor=Cursors.WaitCursor;
			//			frmOPDoctor frm=new frmOPDoctor();
			//			frm.Show_MDI_Child(this);
			//			this.Cursor=Cursors.Default;
			if(FindWindow("frmDoctorWorkstation"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmDoctorWorkstation frm=new frmDoctorWorkstation();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void m_muOPInvo_Click(object sender, System.EventArgs e)
		{
			//			if(FindWindow("frmOPInvo"))
			//			{
			//				return;
			//			}
			//			this.Cursor=Cursors.WaitCursor;
			//			frmOPInvo frm1=new frmOPInvo();
			//			frm1.Show_MDI_Child(this);
			//			this.Cursor=Cursors.Default;

			if(FindWindow("frmOPCharge"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmOPCharge frm=new frmOPCharge();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;


		}

		private void m_muPatRegFee_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmPatRegFee"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmPatRegFee frm=new frmPatRegFee();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void m_muPatReg_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmPatient"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			this.toolTip1.Active=true;
			com.digitalwave.iCare.gui.Patient.frmPatient frm=new com.digitalwave.iCare.gui.Patient.frmPatient();
			frm.Show_MDI_Child(this);
			this.toolTip1.Active=false;
			this.Cursor=Cursors.Default;
		}

		private void m_muRegChargeType_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmRegChargeType"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmRegChargeType frm=new frmRegChargeType();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void m_muRegType_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmRegType"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmRegType frm = new frmRegType();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
		
			this.Cursor=Cursors.WaitCursor;
			frmRegisterDetail objfrm = new frmRegisterDetail();
			this.Cursor = Cursors.Default;
			objfrm.ShowDialog();
		}

		private void m_muCookingMethod_Click(object sender, System.EventArgs e)
		{
			if (FindWindow("frmCMCookMethod"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmCMCookMethod frm = new frmCMCookMethod();
			//			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;
			frm.ShowDialog();
		}

	
		private void m_muPatientPayType_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmPatientPayType"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmPatientPayType frm=new frmPatientPayType();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void m_muRecipeFequency_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmRecipeFreq"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmRecipeFreq frm=new frmRecipeFreq();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void m_muHospitalInfo_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmHISInfoDefine"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmHISInfoDefine frm=new frmHISInfoDefine();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void m_muUsageType_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmUsageType"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmUsageType frm = new frmUsageType();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;		
		}

		private void m_muHISModuleDef_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmHISModuleDef"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmHISModuleDef frm = new frmHISModuleDef();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;		
		
		}

		private void m_muErrorLog_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmErrorLog"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmErrorLog frm = new frmErrorLog();
			frm.MdiParent=this;
			frm.Show();
			this.Cursor = Cursors.Default;		
		
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmInhospitalCard"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmInhospitalCard frm = new frmInhospitalCard();
			frm.MdiParent=this;
			frm.Show();
			this.Cursor = Cursors.Default;		
		}

		private void m_muLoginInfo_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmLoginInfo"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmLoginInfo frm = new frmLoginInfo();
			frm.MdiParent=this;
			frm.Show();
			this.Cursor = Cursors.Default;		
		
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			frmOPInvoiceAppMan frm = new frmOPInvoiceAppMan();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;	
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			frmOPInvoiceReturn frm = new frmOPInvoiceReturn();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;	
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			frmOPInvoiceRenew frm = new frmOPInvoiceRenew();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;		
		}


		private void m_muCheckOutReg_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmCheckOutRegReport"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmCheckOutRegReport frm=new frmCheckOutRegReport();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
			
		}

		private void m_muQulReg_Click(object sender, System.EventArgs e)
		{
			//			if(FindWindow("frmCancelRegister"))
			//			{
			//				return;
			//			}
			//			this.Cursor=Cursors.WaitCursor;
			//			frmCancelRegister frm=new frmCancelRegister();
			//			frm.Show_MDI_Child(this);
			//			this.Cursor=Cursors.Default;
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmRegisterReport"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmRegisterReport frm = new frmRegisterReport();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmRegisterReport"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmRegisterReport frm = new frmRegisterReport();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
			
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmRegisterReport"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmRegisterReport frm = new frmRegisterReport();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
			
		}

		private void menuItem17_Click(object sender, System.EventArgs e)
		{
		
			if(FindWindow("frmRegisterReport"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmRegisterReport frm = new frmRegisterReport();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void menuItem18_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmConcertrecipe"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmConcertrecipe frm = new frmConcertrecipe();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void menuItem19_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmChargeIns"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmChargeIns frm = new frmChargeIns();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;
		}

		private void menuItem20_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmChargeIns"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmChargeIns frm = new frmChargeIns();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;
		}

		private void menuItem21_Click(object sender, System.EventArgs e)
		{
			
				if(FindWindow("frmChargeMaintenance"))
				{
					return;
				}
			this.Cursor = Cursors.WaitCursor;
			frmChargeMaintenance frm = new frmChargeMaintenance();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;
		}

		private void menuItem22_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmChargeItem3"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmChargeItem3 frm = new frmChargeItem3();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;
		}

		private void menuItem23_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmChargeItemSource"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmChargeItemSource frm = new frmChargeItemSource();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;
		}

		private void menuItem20_Click_1(object sender, System.EventArgs e)
		{
			if(FindWindow("frmShowReports"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmShowReports frm = new frmShowReports();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;
		}

		private void menuItem24_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmMedicineSource"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmMedicineSource frm = new frmMedicineSource();
			frm.Show_MDI_Child(this);
			this.Cursor = Cursors.Default;
		}

		private void menuItem25_Click(object sender, System.EventArgs e)
		{
		
			if(FindWindow("frmItemCatMapping"))
			{
				return;
			}
			this.Cursor = Cursors.WaitCursor;
			frmItemCatMapping frm = new frmItemCatMapping();
			frm.Show();
			this.Cursor = Cursors.Default;
		}

		private void menuItem26_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmReckoningReport"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmReckoningReport frm = new frmReckoningReport();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void menuItem28_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmReckoningReport_month"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmReckoningReport_month frm = new frmReckoningReport_month();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void menuItem27_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmReckoningReport_AllDay"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmReckoningReport_AllDay frm = new frmReckoningReport_AllDay();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void menuItem29_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmReportMaintenance"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmReportMaintenance frm = new frmReportMaintenance();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void menuItem30_Click(object sender, System.EventArgs e)
		{
				if(FindWindow("frmMedicineProtectReport"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmMedicineProtectReport frm = new frmMedicineProtectReport();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void menuItem31_Click(object sender, System.EventArgs e)
		{
			if(FindWindow("frmPublicPayReport"))
			{
				return;
			}
			this.Cursor=Cursors.WaitCursor;
			frmPublicPayReport frm = new frmPublicPayReport();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		private void menuItem32_Click(object sender, System.EventArgs e)
		{
			clsCreatFile obj =new clsCreatFile();
			string[] objarr ={"200505060910583750","200505060911339062"};
			obj.RecipeArray =objarr;
			obj.m_mthCreatFile();
		}

		private void menuItem33_Click(object sender, System.EventArgs e)
		{
			
				if(FindWindow("frmDoctorUsingMedicineReport"))
				{
					return;
				}
			this.Cursor=Cursors.WaitCursor;
			frmDoctorUsingMedicineReport frm = new frmDoctorUsingMedicineReport();
			frm.Show_MDI_Child(this);
			this.Cursor=Cursors.Default;
		}

		
	}
}
