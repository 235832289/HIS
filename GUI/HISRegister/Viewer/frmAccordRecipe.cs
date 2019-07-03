using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace  com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmAccordRecipe 的摘要说明。
	/// </summary>
	public class frmAccordRecipe :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		private System.Windows.Forms.Panel panel1;
		internal PinkieControls.ButtonXP btExit;
		internal PinkieControls.ButtonXP btOK;
		internal System.Data.DataSet dataSet1;
		private System.Data.DataColumn dataColumn1;
		private System.Data.DataColumn dataColumn2;
		private System.Data.DataColumn dataColumn3;
		private System.Data.DataColumn dataColumn4;
		private System.Data.DataColumn dataColumn5;
		internal System.Data.DataTable m_dtMain;
		internal System.Data.DataTable dataTable1;
		internal System.Data.DataTable dataTable2;
		internal System.Data.DataTable dataTable3;
		internal System.Data.DataTable dataTable4;
		internal System.Data.DataTable dataTable5;
		internal System.Data.DataTable dataTable6;
		private System.Data.DataColumn dataColumn6;
		private System.Data.DataColumn dataColumn7;
		private System.Data.DataColumn dataColumn8;
		private System.Data.DataColumn dataColumn9;
		private System.Data.DataColumn dataColumn10;
		private System.Data.DataColumn dataColumn11;
		private System.Data.DataColumn dataColumn12;
		private System.Data.DataColumn dataColumn13;
		private System.Data.DataColumn dataColumn14;
		private System.Data.DataColumn dataColumn15;
		private System.Data.DataColumn dataColumn16;
		private System.Data.DataColumn dataColumn17;
		private System.Data.DataColumn dataColumn18;
		private System.Data.DataColumn dataColumn19;
		private System.Data.DataColumn dataColumn20;
		private System.Data.DataColumn dataColumn22;
		private System.Data.DataColumn dataColumn23;
		private System.Data.DataColumn dataColumn24;
		private System.Data.DataColumn dataColumn25;
		private System.Data.DataColumn dataColumn26;
		private System.Data.DataColumn dataColumn27;
		private System.Data.DataColumn dataColumn28;
		private System.Data.DataColumn dataColumn30;
		private System.Data.DataColumn dataColumn31;
		private System.Data.DataColumn dataColumn32;
		private System.Data.DataColumn dataColumn33;
		private System.Data.DataColumn dataColumn34;
		private System.Data.DataColumn dataColumn35;
		private System.Data.DataColumn dataColumn36;
		private System.Data.DataColumn dataColumn38;
		private System.Data.DataColumn dataColumn39;
		private System.Data.DataColumn dataColumn40;
		private System.Data.DataColumn dataColumn41;
		private System.Data.DataColumn dataColumn42;
		private System.Data.DataColumn dataColumn43;
		private System.Data.DataColumn dataColumn44;
		private System.Data.DataColumn dataColumn46;
		private System.Data.DataColumn dataColumn47;
		private System.Data.DataColumn dataColumn48;
		private System.Data.DataColumn dataColumn49;
		private System.Data.DataColumn dataColumn50;
		private System.Data.DataColumn dataColumn51;
		private System.Data.DataColumn dataColumn52;
		private System.Data.DataColumn dataColumn21;
		private System.Data.DataColumn dataColumn29;
		private System.Data.DataColumn dataColumn37;
		private System.Data.DataColumn dataColumn45;
		private System.Data.DataColumn dataColumn53;
		private System.Data.DataColumn dataColumn54;
		private System.Data.DataColumn dataColumn55;
		private System.Data.DataColumn dataColumn56;
		private System.Data.DataColumn dataColumn57;
		private System.Data.DataColumn dataColumn58;
		private System.Data.DataColumn dataColumn59;
		private System.Data.DataColumn dataColumn60;
		private System.Data.DataColumn dataColumn61;
		private System.Data.DataColumn dataColumn62;
		private System.Data.DataColumn dataColumn63;
		private System.Data.DataColumn dataColumn64;
		private System.Data.DataColumn dataColumn65;
		private System.Data.DataColumn dataColumn66;
		private System.Data.DataColumn dataColumn67;
		private System.Data.DataColumn dataColumn68;
		private System.Data.DataColumn dataColumn69;
		private System.Data.DataColumn dataColumn70;
		private System.Data.DataColumn dataColumn71;
		private System.Data.DataColumn dataColumn72;
		private System.Data.DataColumn dataColumn73;
		private System.Data.DataColumn dataColumn74;
		private System.Data.DataColumn dataColumn75;
		private System.Data.DataColumn dataColumn76;
		private System.Data.DataColumn dataColumn77;
		private System.Data.DataColumn dataColumn78;
		private System.Data.DataColumn dataColumn79;
		private System.Data.DataColumn dataColumn80;
		private System.Data.DataColumn dataColumn81;
		private System.Data.DataColumn dataColumn82;
		private System.Data.DataColumn dataColumn83;
		private System.Data.DataColumn dataColumn84;
		private System.Data.DataColumn dataColumn85;
		private System.Data.DataColumn dataColumn86;
		private System.Data.DataColumn dataColumn87;
		private System.Data.DataColumn dataColumn88;
		private System.Data.DataColumn dataColumn89;
		internal System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.RadioButton ra_selectBack;
		private System.Windows.Forms.RadioButton ra_selectAll;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Data.DataColumn dataColumn90;
		private System.Data.DataColumn dataColumn91;
		private System.Data.DataColumn dataColumn92;
		private System.Data.DataColumn dataColumn93;
		internal com.digitalwave.controls.exTextBox txtFind;
		internal System.Windows.Forms.ComboBox cmbFind;
		internal PinkieControls.ButtonXP btFind;
		internal System.Windows.Forms.TreeView treeView1;
		internal System.Windows.Forms.ImageList m_imgIcons;
		private System.Data.DataColumn dataColumn94;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.Label label7;
		internal System.Windows.Forms.TextBox txtRemark;
        private DataColumn dataColumn95;
        private DataColumn dataColumn96;
        private DataColumn dataColumn97;
        private DataColumn dataColumn98;
        private DataColumn dataColumn99;
		private System.ComponentModel.IContainer components;

		public frmAccordRecipe()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			this.cmbFind.SelectedIndex =0;
			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
		}
		DataTable m_dtAll=null;
		#region 自定义属性
		/// <summary>
		/// 获取全部数据
		/// </summary>
		public DataTable GetTableAll
		{
			get
			{
				return this.m_dtAll;
			}
			set
			{
				m_dtAll=value;
			}
		}
		/// <summary>
		/// 获取西药数据
		/// </summary>
		public DataTable GetTable1
		{
			get
			{
			return this.dataTable1;
			}
		}
		/// <summary>
		/// 获取中药数据
		/// </summary>
		public DataTable GetTable2
		{
			get
			{
				return this.dataTable2;
			}
		}
		/// <summary>
		/// 获取检验数据
		/// </summary>
		public DataTable GetTable3
		{
			get
			{
				return this.dataTable3;
			}
		}
		/// <summary>
		/// 获取检查(治疗)数据
		/// </summary>
		public DataTable GetTable4
		{
			get
			{
				return this.dataTable4;
			}
		}
		/// <summary>
		/// 获取手术数据
		/// </summary>
		public DataTable GetTable5
		{
			get
			{
				return this.dataTable5;
			}
		}
		/// <summary>
		/// 获取其他数据
		/// </summary>
		public DataTable GetTable6
		{
			get
			{
				return this.dataTable6;
			}
		}

        /// <summary>
        /// 判断是否允许选择缺药 true 允许, false 不允许
        /// </summary>
        internal bool LackMedicine = true;

        /// <summary>
        /// 附加提示信息
        /// </summary>
        internal string HintMsg = "";
		#endregion
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
		public override void CreateController()
		{
			this.objController=new com.digitalwave.iCare.gui.HIS.clsCtl_AccordRecipe();
			objController.Set_GUI_Apperance(this);
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccordRecipe));
            this.m_dtMain = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.dataColumn4 = new System.Data.DataColumn();
            this.dataColumn5 = new System.Data.DataColumn();
            this.dataColumn62 = new System.Data.DataColumn();
            this.dataColumn63 = new System.Data.DataColumn();
            this.dataColumn89 = new System.Data.DataColumn();
            this.dataSet1 = new System.Data.DataSet();
            this.dataTable1 = new System.Data.DataTable();
            this.dataColumn6 = new System.Data.DataColumn();
            this.dataColumn7 = new System.Data.DataColumn();
            this.dataColumn8 = new System.Data.DataColumn();
            this.dataColumn9 = new System.Data.DataColumn();
            this.dataColumn10 = new System.Data.DataColumn();
            this.dataColumn11 = new System.Data.DataColumn();
            this.dataColumn12 = new System.Data.DataColumn();
            this.dataColumn13 = new System.Data.DataColumn();
            this.dataColumn21 = new System.Data.DataColumn();
            this.dataColumn29 = new System.Data.DataColumn();
            this.dataColumn37 = new System.Data.DataColumn();
            this.dataColumn45 = new System.Data.DataColumn();
            this.dataColumn53 = new System.Data.DataColumn();
            this.dataColumn54 = new System.Data.DataColumn();
            this.dataColumn55 = new System.Data.DataColumn();
            this.dataColumn60 = new System.Data.DataColumn();
            this.dataColumn61 = new System.Data.DataColumn();
            this.dataColumn64 = new System.Data.DataColumn();
            this.dataColumn66 = new System.Data.DataColumn();
            this.dataColumn74 = new System.Data.DataColumn();
            this.dataColumn75 = new System.Data.DataColumn();
            this.dataColumn76 = new System.Data.DataColumn();
            this.dataColumn82 = new System.Data.DataColumn();
            this.dataColumn88 = new System.Data.DataColumn();
            this.dataColumn94 = new System.Data.DataColumn();
            this.dataColumn95 = new System.Data.DataColumn();
            this.dataTable2 = new System.Data.DataTable();
            this.dataColumn14 = new System.Data.DataColumn();
            this.dataColumn15 = new System.Data.DataColumn();
            this.dataColumn16 = new System.Data.DataColumn();
            this.dataColumn17 = new System.Data.DataColumn();
            this.dataColumn18 = new System.Data.DataColumn();
            this.dataColumn19 = new System.Data.DataColumn();
            this.dataColumn20 = new System.Data.DataColumn();
            this.dataColumn56 = new System.Data.DataColumn();
            this.dataColumn57 = new System.Data.DataColumn();
            this.dataColumn58 = new System.Data.DataColumn();
            this.dataColumn59 = new System.Data.DataColumn();
            this.dataColumn65 = new System.Data.DataColumn();
            this.dataColumn67 = new System.Data.DataColumn();
            this.dataColumn72 = new System.Data.DataColumn();
            this.dataColumn73 = new System.Data.DataColumn();
            this.dataColumn77 = new System.Data.DataColumn();
            this.dataColumn83 = new System.Data.DataColumn();
            this.dataColumn96 = new System.Data.DataColumn();
            this.dataTable3 = new System.Data.DataTable();
            this.dataColumn22 = new System.Data.DataColumn();
            this.dataColumn23 = new System.Data.DataColumn();
            this.dataColumn24 = new System.Data.DataColumn();
            this.dataColumn25 = new System.Data.DataColumn();
            this.dataColumn26 = new System.Data.DataColumn();
            this.dataColumn27 = new System.Data.DataColumn();
            this.dataColumn28 = new System.Data.DataColumn();
            this.dataColumn68 = new System.Data.DataColumn();
            this.dataColumn78 = new System.Data.DataColumn();
            this.dataColumn84 = new System.Data.DataColumn();
            this.dataColumn90 = new System.Data.DataColumn();
            this.dataColumn91 = new System.Data.DataColumn();
            this.dataTable4 = new System.Data.DataTable();
            this.dataColumn30 = new System.Data.DataColumn();
            this.dataColumn31 = new System.Data.DataColumn();
            this.dataColumn32 = new System.Data.DataColumn();
            this.dataColumn33 = new System.Data.DataColumn();
            this.dataColumn34 = new System.Data.DataColumn();
            this.dataColumn35 = new System.Data.DataColumn();
            this.dataColumn36 = new System.Data.DataColumn();
            this.dataColumn69 = new System.Data.DataColumn();
            this.dataColumn79 = new System.Data.DataColumn();
            this.dataColumn85 = new System.Data.DataColumn();
            this.dataColumn92 = new System.Data.DataColumn();
            this.dataColumn93 = new System.Data.DataColumn();
            this.dataTable5 = new System.Data.DataTable();
            this.dataColumn38 = new System.Data.DataColumn();
            this.dataColumn39 = new System.Data.DataColumn();
            this.dataColumn40 = new System.Data.DataColumn();
            this.dataColumn41 = new System.Data.DataColumn();
            this.dataColumn42 = new System.Data.DataColumn();
            this.dataColumn43 = new System.Data.DataColumn();
            this.dataColumn44 = new System.Data.DataColumn();
            this.dataColumn70 = new System.Data.DataColumn();
            this.dataColumn80 = new System.Data.DataColumn();
            this.dataColumn86 = new System.Data.DataColumn();
            this.dataTable6 = new System.Data.DataTable();
            this.dataColumn46 = new System.Data.DataColumn();
            this.dataColumn47 = new System.Data.DataColumn();
            this.dataColumn48 = new System.Data.DataColumn();
            this.dataColumn49 = new System.Data.DataColumn();
            this.dataColumn50 = new System.Data.DataColumn();
            this.dataColumn51 = new System.Data.DataColumn();
            this.dataColumn52 = new System.Data.DataColumn();
            this.dataColumn71 = new System.Data.DataColumn();
            this.dataColumn81 = new System.Data.DataColumn();
            this.dataColumn87 = new System.Data.DataColumn();
            this.dataColumn97 = new System.Data.DataColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btFind = new PinkieControls.ButtonXP();
            this.txtFind = new com.digitalwave.controls.exTextBox();
            this.cmbFind = new System.Windows.Forms.ComboBox();
            this.ra_selectBack = new System.Windows.Forms.RadioButton();
            this.ra_selectAll = new System.Windows.Forms.RadioButton();
            this.btExit = new PinkieControls.ButtonXP();
            this.btOK = new PinkieControls.ButtonXP();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.m_imgIcons = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.dataColumn98 = new System.Data.DataColumn();
            this.dataColumn99 = new System.Data.DataColumn();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable6)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtMain
            // 
            this.m_dtMain.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3,
            this.dataColumn4,
            this.dataColumn5,
            this.dataColumn62,
            this.dataColumn63,
            this.dataColumn89});
            this.m_dtMain.TableName = "dtMain";
            // 
            // dataColumn1
            // 
            this.dataColumn1.ColumnName = "Column1";
            // 
            // dataColumn2
            // 
            this.dataColumn2.ColumnName = "Column2";
            // 
            // dataColumn3
            // 
            this.dataColumn3.ColumnName = "Column3";
            // 
            // dataColumn4
            // 
            this.dataColumn4.ColumnName = "Column4";
            this.dataColumn4.DataType = typeof(decimal);
            // 
            // dataColumn5
            // 
            this.dataColumn5.ColumnName = "Column5";
            // 
            // dataColumn62
            // 
            this.dataColumn62.ColumnName = "Column6";
            // 
            // dataColumn63
            // 
            this.dataColumn63.ColumnName = "Column7";
            // 
            // dataColumn89
            // 
            this.dataColumn89.ColumnName = "Column8";
            this.dataColumn89.DataType = typeof(bool);
            this.dataColumn89.DefaultValue = true;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "NewDataSet";
            this.dataSet1.Locale = new System.Globalization.CultureInfo("zh-CN");
            this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
            this.m_dtMain,
            this.dataTable1,
            this.dataTable2,
            this.dataTable3,
            this.dataTable4,
            this.dataTable5,
            this.dataTable6});
            // 
            // dataTable1
            // 
            this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn6,
            this.dataColumn7,
            this.dataColumn8,
            this.dataColumn9,
            this.dataColumn10,
            this.dataColumn11,
            this.dataColumn12,
            this.dataColumn13,
            this.dataColumn21,
            this.dataColumn29,
            this.dataColumn37,
            this.dataColumn45,
            this.dataColumn53,
            this.dataColumn54,
            this.dataColumn55,
            this.dataColumn60,
            this.dataColumn61,
            this.dataColumn64,
            this.dataColumn66,
            this.dataColumn74,
            this.dataColumn75,
            this.dataColumn76,
            this.dataColumn82,
            this.dataColumn88,
            this.dataColumn94,
            this.dataColumn95});
            this.dataTable1.TableName = "Table1";
            // 
            // dataColumn6
            // 
            this.dataColumn6.ColumnName = "Column1";
            // 
            // dataColumn7
            // 
            this.dataColumn7.ColumnName = "Column2";
            // 
            // dataColumn8
            // 
            this.dataColumn8.ColumnName = "Column3";
            // 
            // dataColumn9
            // 
            this.dataColumn9.ColumnName = "Column4";
            // 
            // dataColumn10
            // 
            this.dataColumn10.ColumnName = "Column5";
            // 
            // dataColumn11
            // 
            this.dataColumn11.ColumnName = "Column6";
            // 
            // dataColumn12
            // 
            this.dataColumn12.ColumnName = "Column7";
            // 
            // dataColumn13
            // 
            this.dataColumn13.ColumnName = "Column8";
            // 
            // dataColumn21
            // 
            this.dataColumn21.ColumnName = "Column9";
            // 
            // dataColumn29
            // 
            this.dataColumn29.ColumnName = "Column10";
            // 
            // dataColumn37
            // 
            this.dataColumn37.ColumnName = "Column11";
            // 
            // dataColumn45
            // 
            this.dataColumn45.ColumnName = "Column12";
            // 
            // dataColumn53
            // 
            this.dataColumn53.ColumnName = "Column13";
            // 
            // dataColumn54
            // 
            this.dataColumn54.ColumnName = "Column14";
            // 
            // dataColumn55
            // 
            this.dataColumn55.ColumnName = "Column15";
            // 
            // dataColumn60
            // 
            this.dataColumn60.ColumnName = "Column16";
            // 
            // dataColumn61
            // 
            this.dataColumn61.ColumnName = "Column17";
            // 
            // dataColumn64
            // 
            this.dataColumn64.ColumnName = "Column18";
            // 
            // dataColumn66
            // 
            this.dataColumn66.ColumnName = "Column19";
            // 
            // dataColumn74
            // 
            this.dataColumn74.ColumnName = "Column20";
            // 
            // dataColumn75
            // 
            this.dataColumn75.ColumnName = "Column21";
            // 
            // dataColumn76
            // 
            this.dataColumn76.ColumnName = "Column22";
            // 
            // dataColumn82
            // 
            this.dataColumn82.ColumnName = "Column23";
            // 
            // dataColumn88
            // 
            this.dataColumn88.ColumnName = "Column24";
            // 
            // dataColumn94
            // 
            this.dataColumn94.ColumnName = "Column25";
            // 
            // dataColumn95
            // 
            this.dataColumn95.ColumnName = "Column26";
            // 
            // dataTable2
            // 
            this.dataTable2.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn14,
            this.dataColumn15,
            this.dataColumn16,
            this.dataColumn17,
            this.dataColumn18,
            this.dataColumn19,
            this.dataColumn20,
            this.dataColumn56,
            this.dataColumn57,
            this.dataColumn58,
            this.dataColumn59,
            this.dataColumn65,
            this.dataColumn67,
            this.dataColumn72,
            this.dataColumn73,
            this.dataColumn77,
            this.dataColumn83,
            this.dataColumn96});
            this.dataTable2.TableName = "Table2";
            // 
            // dataColumn14
            // 
            this.dataColumn14.ColumnName = "Column1";
            // 
            // dataColumn15
            // 
            this.dataColumn15.ColumnName = "Column2";
            // 
            // dataColumn16
            // 
            this.dataColumn16.ColumnName = "Column3";
            // 
            // dataColumn17
            // 
            this.dataColumn17.ColumnName = "Column4";
            // 
            // dataColumn18
            // 
            this.dataColumn18.ColumnName = "Column5";
            // 
            // dataColumn19
            // 
            this.dataColumn19.ColumnName = "Column6";
            // 
            // dataColumn20
            // 
            this.dataColumn20.ColumnName = "Column7";
            // 
            // dataColumn56
            // 
            this.dataColumn56.ColumnName = "Column8";
            // 
            // dataColumn57
            // 
            this.dataColumn57.ColumnName = "Column9";
            // 
            // dataColumn58
            // 
            this.dataColumn58.ColumnName = "Column10";
            // 
            // dataColumn59
            // 
            this.dataColumn59.ColumnName = "Column11";
            // 
            // dataColumn65
            // 
            this.dataColumn65.ColumnName = "Column12";
            // 
            // dataColumn67
            // 
            this.dataColumn67.ColumnName = "Column13";
            // 
            // dataColumn72
            // 
            this.dataColumn72.ColumnName = "Column14";
            // 
            // dataColumn73
            // 
            this.dataColumn73.ColumnName = "Column15";
            // 
            // dataColumn77
            // 
            this.dataColumn77.ColumnName = "Column16";
            // 
            // dataColumn83
            // 
            this.dataColumn83.ColumnName = "Column17";
            // 
            // dataColumn96
            // 
            this.dataColumn96.ColumnName = "Column18";
            // 
            // dataTable3
            // 
            this.dataTable3.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn22,
            this.dataColumn23,
            this.dataColumn24,
            this.dataColumn25,
            this.dataColumn26,
            this.dataColumn27,
            this.dataColumn28,
            this.dataColumn68,
            this.dataColumn78,
            this.dataColumn84,
            this.dataColumn90,
            this.dataColumn91});
            this.dataTable3.TableName = "Table3";
            // 
            // dataColumn22
            // 
            this.dataColumn22.ColumnName = "Column1";
            // 
            // dataColumn23
            // 
            this.dataColumn23.ColumnName = "Column2";
            // 
            // dataColumn24
            // 
            this.dataColumn24.ColumnName = "Column3";
            // 
            // dataColumn25
            // 
            this.dataColumn25.ColumnName = "Column4";
            // 
            // dataColumn26
            // 
            this.dataColumn26.ColumnName = "Column5";
            // 
            // dataColumn27
            // 
            this.dataColumn27.ColumnName = "Column6";
            // 
            // dataColumn28
            // 
            this.dataColumn28.ColumnName = "Column7";
            // 
            // dataColumn68
            // 
            this.dataColumn68.ColumnName = "Column8";
            // 
            // dataColumn78
            // 
            this.dataColumn78.ColumnName = "Column9";
            // 
            // dataColumn84
            // 
            this.dataColumn84.ColumnName = "Column10";
            // 
            // dataColumn90
            // 
            this.dataColumn90.ColumnName = "Column11";
            // 
            // dataColumn91
            // 
            this.dataColumn91.ColumnName = "Column12";
            // 
            // dataTable4
            // 
            this.dataTable4.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn30,
            this.dataColumn31,
            this.dataColumn32,
            this.dataColumn33,
            this.dataColumn34,
            this.dataColumn35,
            this.dataColumn36,
            this.dataColumn69,
            this.dataColumn79,
            this.dataColumn85,
            this.dataColumn92,
            this.dataColumn93,
            this.dataColumn98});
            this.dataTable4.TableName = "Table4";
            // 
            // dataColumn30
            // 
            this.dataColumn30.ColumnName = "Column1";
            // 
            // dataColumn31
            // 
            this.dataColumn31.ColumnName = "Column2";
            // 
            // dataColumn32
            // 
            this.dataColumn32.ColumnName = "Column3";
            // 
            // dataColumn33
            // 
            this.dataColumn33.ColumnName = "Column4";
            // 
            // dataColumn34
            // 
            this.dataColumn34.ColumnName = "Column5";
            // 
            // dataColumn35
            // 
            this.dataColumn35.ColumnName = "Column6";
            // 
            // dataColumn36
            // 
            this.dataColumn36.ColumnName = "Column7";
            // 
            // dataColumn69
            // 
            this.dataColumn69.ColumnName = "Column8";
            // 
            // dataColumn79
            // 
            this.dataColumn79.ColumnName = "Column9";
            // 
            // dataColumn85
            // 
            this.dataColumn85.ColumnName = "Column10";
            // 
            // dataColumn92
            // 
            this.dataColumn92.ColumnName = "Column11";
            // 
            // dataColumn93
            // 
            this.dataColumn93.ColumnName = "Column12";
            // 
            // dataTable5
            // 
            this.dataTable5.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn38,
            this.dataColumn39,
            this.dataColumn40,
            this.dataColumn41,
            this.dataColumn42,
            this.dataColumn43,
            this.dataColumn44,
            this.dataColumn70,
            this.dataColumn80,
            this.dataColumn86,
            this.dataColumn99});
            this.dataTable5.TableName = "Table5";
            // 
            // dataColumn38
            // 
            this.dataColumn38.ColumnName = "Column1";
            // 
            // dataColumn39
            // 
            this.dataColumn39.ColumnName = "Column2";
            // 
            // dataColumn40
            // 
            this.dataColumn40.ColumnName = "Column3";
            // 
            // dataColumn41
            // 
            this.dataColumn41.ColumnName = "Column4";
            // 
            // dataColumn42
            // 
            this.dataColumn42.ColumnName = "Column5";
            // 
            // dataColumn43
            // 
            this.dataColumn43.ColumnName = "Column6";
            // 
            // dataColumn44
            // 
            this.dataColumn44.ColumnName = "Column7";
            // 
            // dataColumn70
            // 
            this.dataColumn70.ColumnName = "Column8";
            // 
            // dataColumn80
            // 
            this.dataColumn80.ColumnName = "Column9";
            // 
            // dataColumn86
            // 
            this.dataColumn86.ColumnName = "Column10";
            // 
            // dataTable6
            // 
            this.dataTable6.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn46,
            this.dataColumn47,
            this.dataColumn48,
            this.dataColumn49,
            this.dataColumn50,
            this.dataColumn51,
            this.dataColumn52,
            this.dataColumn71,
            this.dataColumn81,
            this.dataColumn87,
            this.dataColumn97});
            this.dataTable6.TableName = "Table6";
            // 
            // dataColumn46
            // 
            this.dataColumn46.ColumnName = "Column1";
            // 
            // dataColumn47
            // 
            this.dataColumn47.ColumnName = "Column2";
            // 
            // dataColumn48
            // 
            this.dataColumn48.ColumnName = "Column3";
            // 
            // dataColumn49
            // 
            this.dataColumn49.ColumnName = "Column4";
            // 
            // dataColumn50
            // 
            this.dataColumn50.ColumnName = "Column5";
            // 
            // dataColumn51
            // 
            this.dataColumn51.ColumnName = "Column6";
            // 
            // dataColumn52
            // 
            this.dataColumn52.ColumnName = "Column7";
            // 
            // dataColumn71
            // 
            this.dataColumn71.ColumnName = "Column8";
            // 
            // dataColumn81
            // 
            this.dataColumn81.ColumnName = "Column9";
            // 
            // dataColumn87
            // 
            this.dataColumn87.ColumnName = "Column10";
            // 
            // dataColumn97
            // 
            this.dataColumn97.ColumnName = "Column11";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btFind);
            this.panel1.Controls.Add(this.txtFind);
            this.panel1.Controls.Add(this.cmbFind);
            this.panel1.Controls.Add(this.ra_selectBack);
            this.panel1.Controls.Add(this.ra_selectAll);
            this.panel1.Controls.Add(this.btExit);
            this.panel1.Controls.Add(this.btOK);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(0, 512);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(944, 56);
            this.panel1.TabIndex = 2;
            // 
            // btFind
            // 
            this.btFind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btFind.DefaultScheme = true;
            this.btFind.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btFind.Hint = "";
            this.btFind.Location = new System.Drawing.Point(296, 15);
            this.btFind.Name = "btFind";
            this.btFind.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btFind.Size = new System.Drawing.Size(104, 32);
            this.btFind.TabIndex = 2;
            this.btFind.Text = "查找(&F)";
            this.btFind.Click += new System.EventHandler(this.btFind_Click);
            // 
            // txtFind
            // 
            this.txtFind.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFind.Location = new System.Drawing.Point(152, 20);
            this.txtFind.MaxLength = 16;
            this.txtFind.Name = "txtFind";
            this.txtFind.SendTabKey = false;
            this.txtFind.SetFocusColor = System.Drawing.Color.White;
            this.txtFind.Size = new System.Drawing.Size(112, 23);
            this.txtFind.TabIndex = 1;
            this.txtFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyDown);
            // 
            // cmbFind
            // 
            this.cmbFind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFind.Items.AddRange(new object[] {
            "助记码",
            "名称",
            "拼音码",
            "五笔码",
            "备  注"});
            this.cmbFind.Location = new System.Drawing.Point(24, 20);
            this.cmbFind.Name = "cmbFind";
            this.cmbFind.Size = new System.Drawing.Size(120, 22);
            this.cmbFind.TabIndex = 0;
            this.cmbFind.SelectedIndexChanged += new System.EventHandler(this.cmbFind_SelectedIndexChanged);
            // 
            // ra_selectBack
            // 
            this.ra_selectBack.Font = new System.Drawing.Font("宋体", 12F);
            this.ra_selectBack.Location = new System.Drawing.Point(520, 20);
            this.ra_selectBack.Name = "ra_selectBack";
            this.ra_selectBack.Size = new System.Drawing.Size(80, 24);
            this.ra_selectBack.TabIndex = 4;
            this.ra_selectBack.Text = "反选";
            this.ra_selectBack.Click += new System.EventHandler(this.ra_selectBack_Click);
            // 
            // ra_selectAll
            // 
            this.ra_selectAll.Checked = true;
            this.ra_selectAll.Font = new System.Drawing.Font("宋体", 12F);
            this.ra_selectAll.Location = new System.Drawing.Point(440, 20);
            this.ra_selectAll.Name = "ra_selectAll";
            this.ra_selectAll.Size = new System.Drawing.Size(80, 24);
            this.ra_selectAll.TabIndex = 3;
            this.ra_selectAll.TabStop = true;
            this.ra_selectAll.Text = "全选";
            this.ra_selectAll.Click += new System.EventHandler(this.ra_selectAll_Click);
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(794, 15);
            this.btExit.Name = "btExit";
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(104, 32);
            this.btExit.TabIndex = 6;
            this.btExit.Text = "退出(ESC)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btOK.DefaultScheme = true;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOK.Hint = "";
            this.btOK.Location = new System.Drawing.Point(642, 15);
            this.btOK.Name = "btOK";
            this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOK.Size = new System.Drawing.Size(104, 32);
            this.btOK.TabIndex = 5;
            this.btOK.Text = "选择(F3)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(1, -2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(936, 58);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // listView2
            // 
            this.listView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView2.CheckBoxes = true;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader13,
            this.columnHeader12,
            this.columnHeader2});
            this.listView2.Font = new System.Drawing.Font("宋体", 10.5F);
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(232, 0);
            this.listView2.MultiSelect = false;
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(704, 432);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            this.listView2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView2_ItemCheck);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "状态";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "方号";
            this.columnHeader6.Width = 44;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "项目名称";
            this.columnHeader7.Width = 205;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "规格";
            this.columnHeader8.Width = 133;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "数量";
            this.columnHeader9.Width = 51;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "频率";
            this.columnHeader10.Width = 78;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "用法";
            this.columnHeader11.Width = 84;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "";
            this.columnHeader13.Width = 0;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "ID";
            this.columnHeader12.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "金额";
            // 
            // treeView1
            // 
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView1.HideSelection = false;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.m_imgIcons;
            this.treeView1.Location = new System.Drawing.Point(1, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 1;
            this.treeView1.Size = new System.Drawing.Size(226, 512);
            this.treeView1.TabIndex = 0;
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView1_KeyDown);
            // 
            // m_imgIcons
            // 
            this.m_imgIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imgIcons.ImageStream")));
            this.m_imgIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imgIcons.Images.SetKeyName(0, "");
            this.m_imgIcons.Images.SetKeyName(1, "");
            this.m_imgIcons.Images.SetKeyName(2, "");
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(704, 448);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "该协定处方总价:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumBlue;
            this.label2.Location = new System.Drawing.Point(832, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 23);
            this.label2.TabIndex = 5;
            this.label2.Text = "0";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.MediumBlue;
            this.label3.Location = new System.Drawing.Point(832, 478);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "0";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(704, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 23);
            this.label4.TabIndex = 6;
            this.label4.Text = "选中的项目总价:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(232, 440);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(704, 64);
            this.label5.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Location = new System.Drawing.Point(288, 496);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(408, 1);
            this.label6.TabIndex = 10;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(240, 464);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 23);
            this.label7.TabIndex = 11;
            this.label7.Text = "备注:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtRemark
            // 
            this.txtRemark.BackColor = System.Drawing.SystemColors.Control;
            this.txtRemark.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtRemark.Location = new System.Drawing.Point(288, 448);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.ReadOnly = true;
            this.txtRemark.Size = new System.Drawing.Size(408, 48);
            this.txtRemark.TabIndex = 12;
            this.txtRemark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // dataColumn98
            // 
            this.dataColumn98.ColumnName = "Column13";
            // 
            // dataColumn99
            // 
            this.dataColumn99.ColumnName = "Column11";
            // 
            // frmAccordRecipe
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(944, 573);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmAccordRecipe";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "处方模板";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmAccordRecipe_KeyDown);
            this.Load += new System.EventHandler(this.frmAccordRecipe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable6)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			((clsCtl_AccordRecipe)this.objController).m_mthGetAccordRecipeDetail();
		}
		private void frmAccordRecipe_Load(object sender, System.EventArgs e)
		{
            if (LackMedicine)
            {
                HintMsg = "  -  停用项目选择无效";
            }
            else
            {
                HintMsg = "  -  停用项目选择无效  -  缺药药品选择无效";
            }                      

//			this.listView1.Items[0].Selected=true;
//			this.listView1.Select();
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			((clsCtl_AccordRecipe)this.objController).m_mthSelectTemp();
			
		}

		private void frmAccordRecipe_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Escape)
			{
			this.Close();
			}
			if(e.KeyCode==Keys.F3)
			{
			this.btOK_Click(null,null);
			}
		}

		private void listView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.btOK_Click(null,null);
			}
		}

		private void listView2_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{            
			((clsCtl_AccordRecipe)this.objController).m_mthComputeSum(e.Index);

//			if(this.listView2.Items[e.Index].ForeColor==Color.Gray)
//			{
//				e.NewValue =CheckState.Unchecked;
//			}
//			if(this.listView2.Items[e.Index].BackColor!=Color.White)
//			{
//				bool temp =false;
//				if(e.NewValue==CheckState.Checked)
//				{
//					temp =true;
//				}
//				m_mthSelectItem(temp,this.listView2.Items[e.Index].Text.Trim(),e.Index);
//			}
		}
		private void m_mthSelectItem(bool temp,string strID,int index)
		{
			try
			{
				this.listView2.ItemCheck -= new System.Windows.Forms.ItemCheckEventHandler(this.listView2_ItemCheck);
				for(int i=0;i<this.listView2.Items.Count;i++)
				{
					if(i==index)
					{
						continue;
					}
					if(strID ==this.listView2.Items[i].Text.Trim())
					{
						this.listView2.Items[i].Checked=temp;
					}	
				}
				this.listView2.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.listView2_ItemCheck);
			}
			catch
			{
			
			}
		}

		private void ra_selectAll_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<this.listView2.Items.Count;i++)
			{
				if(this.listView2.Items[i].SubItems[7].Text.Trim() == "缺药")
				{
					if(this.listView2.Items[i].Checked)
						this.listView2.Items[i].Checked = false;
				}
				else
					this.listView2.Items[i].Checked = true;
			}

			((clsCtl_AccordRecipe)this.objController).m_mthComputeSum(999);
		}

		private void ra_selectBack_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<this.listView2.Items.Count;i++)
			{
				if(this.listView2.Items[i].SubItems[7].Text.Trim() == "缺药")
				{
					if(this.listView2.Items[i].Checked)
						this.listView2.Items[i].Checked = false;
					continue;
				}

				if(this.listView2.Items[i].Checked)
				{
					this.listView2.Items[i].Checked =false;
				}
				else
				{
					this.listView2.Items[i].Checked =true;
				}
			}

			((clsCtl_AccordRecipe)this.objController).m_mthComputeSum(999);
		}		

		private void cmbFind_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			switch(cmbFind.SelectedIndex)
			{
				case 0://助记码
					this.cmbFind.Tag ="USERCODE_CHR";
					this.txtFind.Tag ="";
					break;
				case 1://名称
					this.cmbFind.Tag ="RECIPENAME_CHR";
					this.txtFind.Tag ="%";
					break;
				case 2://拼音码
					this.cmbFind.Tag ="PYCODE_CHR";
					this.txtFind.Tag ="";
					break;
				case 3://五笔码
					this.cmbFind.Tag ="WBCODE_CHR";
					this.txtFind.Tag ="";
					break;
				case 4://备注
					this.cmbFind.Tag ="DISEASENAME_VCHR";
					this.txtFind.Tag ="%";
					break;
			}
		}
		private  int _UseFlag =0;
		public int UseFlag
		{
			set
			{
			this._UseFlag =value;
			}
		}
		private void btFind_Click(object sender, System.EventArgs e)
		{
			if(sender!=null)
			{
			cmbFind_SelectedIndexChanged(null,null);
			}
		((clsCtl_AccordRecipe)this.objController).m_mthFindAccordRecipe(_UseFlag);
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			this.treeView1.Tag =e.Node.Tag;
			((clsCtl_AccordRecipe)this.objController).m_mthGetAccordRecipeDetail();

		}

		private void treeView1_DoubleClick(object sender, System.EventArgs e)
		{
			this.btOK_Click(null,null);
		}

		private void treeView1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
			this.btOK_Click(null,null);
			}
		}

		private void txtFind_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				this.btFind_Click(null,null);
			}
		}

		private void listView2_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		
		#region 查询内容
		public string FindType
		{
			set
			{
			this.cmbFind.Tag =value;
			}
		}
		public int FindIndex
		{
			set
			{
				if(value <this.cmbFind.Items.Count)
				{
					this.cmbFind.SelectedIndex =value;
				}
				else
				{
				this.cmbFind.SelectedIndex =0;
				}
				this.btFind_Click(null,null);
			}
		}
		public string FindText
		{
			set
			{
			this.txtFind.Text =value;
		
			}
		}
		#endregion
	}
	class ListViewItemSort : IComparer 
	{
		private int col;
		public ListViewItemSort() 
		{
			col=0;
		}
		public ListViewItemSort(int column) 
		{
			col=column;
		}
		public int Compare(object x, object y) 
		{
			return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
		}
	}

}
