using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.middletier.HI;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmOPCharge 的摘要说明。
	/// </summary>
	public class frmBreakInvoice : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		/// <summary>
		/// 当前选择的行号
		/// </summary>
		private int row =0;

		private int CurRow =0;
		private int CurCol =1;		
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		internal PinkieControls.ButtonXP btBreak;
		internal PinkieControls.ButtonXP btOK;
		internal PinkieControls.ButtonXP btExit;
		private com.digitalwave.controls.datagrid.ctlDataGrid ctlDataGrid1;
		private com.digitalwave.controls.NumTextBox txtPages;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.ComboBox cmbPayTpye;
		private System.Windows.Forms.Label label3;
		internal System.Windows.Forms.ComboBox cbopaycardtype;
		internal System.Windows.Forms.TextBox txtpaycardno;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmBreakInvoice(clsPatientChargeCal p_objPCVO)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			objPCVO=p_objPCVO;
			m_mthHandleMoney(objPCVO,false);
			InitializeComponent();
			this.ctlDataGrid1.Leave+=new EventHandler(ctlDataGrid1_Leave);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBreakInvoice));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btExit = new PinkieControls.ButtonXP();
            this.btOK = new PinkieControls.ButtonXP();
            this.btBreak = new PinkieControls.ButtonXP();
            this.txtPages = new com.digitalwave.controls.NumTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlDataGrid1 = new com.digitalwave.controls.datagrid.ctlDataGrid();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cmbPayTpye = new System.Windows.Forms.ComboBox();
            this.cbopaycardtype = new System.Windows.Forms.ComboBox();
            this.txtpaycardno = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btExit);
            this.groupBox1.Controls.Add(this.btOK);
            this.groupBox1.Controls.Add(this.btBreak);
            this.groupBox1.Controls.Add(this.txtPages);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1012, 64);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label3.Location = new System.Drawing.Point(860, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 14);
            this.label3.TabIndex = 6;
            this.label3.Text = "F3:向右  回车:向下";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label2.Location = new System.Drawing.Point(860, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "F1:向上  F2:向左";
            // 
            // btExit
            // 
            this.btExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btExit.DefaultScheme = true;
            this.btExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btExit.Font = new System.Drawing.Font("宋体", 11F);
            this.btExit.Hint = "";
            this.btExit.Location = new System.Drawing.Point(736, 18);
            this.btExit.Name = "btExit";
            this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btExit.Size = new System.Drawing.Size(84, 36);
            this.btExit.TabIndex = 3;
            this.btExit.Text = "退出(ESC)";
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // btOK
            // 
            this.btOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btOK.DefaultScheme = true;
            this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btOK.Font = new System.Drawing.Font("宋体", 11F);
            this.btOK.Hint = "";
            this.btOK.Location = new System.Drawing.Point(316, 18);
            this.btOK.Name = "btOK";
            this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btOK.Size = new System.Drawing.Size(84, 36);
            this.btOK.TabIndex = 2;
            this.btOK.Text = "确定(&S)";
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // btBreak
            // 
            this.btBreak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.btBreak.DefaultScheme = true;
            this.btBreak.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btBreak.Font = new System.Drawing.Font("宋体", 11F);
            this.btBreak.Hint = "";
            this.btBreak.Location = new System.Drawing.Point(164, 18);
            this.btBreak.Name = "btBreak";
            this.btBreak.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.btBreak.Size = new System.Drawing.Size(84, 36);
            this.btBreak.TabIndex = 1;
            this.btBreak.Text = "拆分(&B)";
            this.btBreak.Click += new System.EventHandler(this.btBreak_Click);
            // 
            // txtPages
            // 
            this.txtPages.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPages.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.txtPages.Location = new System.Drawing.Point(80, 26);
            this.txtPages.MaxLength = 2;
            this.txtPages.Name = "txtPages";
            this.txtPages.SendTabKey = false;
            this.txtPages.SetFocusColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.txtPages.Size = new System.Drawing.Size(48, 23);
            this.txtPages.TabIndex = 0;
            this.txtPages.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPages_KeyPress);
            this.txtPages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPages_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 4;
            this.label1.Text = "发票张数:";
            // 
            // ctlDataGrid1
            // 
            this.ctlDataGrid1.AllowAddNew = false;
            this.ctlDataGrid1.AllowDelete = false;
            this.ctlDataGrid1.AutoAppendRow = true;
            this.ctlDataGrid1.AutoScroll = true;
            this.ctlDataGrid1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.ctlDataGrid1.CaptionText = "";
            this.ctlDataGrid1.CaptionVisible = false;
            this.ctlDataGrid1.ColumnHeadersVisible = true;
            this.ctlDataGrid1.FullRowSelect = false;
            this.ctlDataGrid1.Location = new System.Drawing.Point(0, 68);
            this.ctlDataGrid1.MultiSelect = false;
            this.ctlDataGrid1.Name = "ctlDataGrid1";
            this.ctlDataGrid1.ReadOnly = false;
            this.ctlDataGrid1.RowHeadersVisible = false;
            this.ctlDataGrid1.RowHeaderWidth = 35;
            this.ctlDataGrid1.SelectedRowBackColor = System.Drawing.SystemColors.Desktop;
            this.ctlDataGrid1.SelectedRowForeColor = System.Drawing.Color.White;
            this.ctlDataGrid1.Size = new System.Drawing.Size(1012, 492);
            this.ctlDataGrid1.TabIndex = 1;
            this.ctlDataGrid1.m_evtCurrentCellChanged += new System.EventHandler(this.ctlDataGrid1_m_evtCurrentCellChanged);
            this.m_mthCreatStructure();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年MM月dd日";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(276, 144);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker1.TabIndex = 2;
            this.dateTimePicker1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dateTimePicker1_KeyDown);
            // 
            // cmbPayTpye
            // 
            this.cmbPayTpye.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPayTpye.Location = new System.Drawing.Point(308, 208);
            this.cmbPayTpye.Name = "cmbPayTpye";
            this.cmbPayTpye.Size = new System.Drawing.Size(120, 22);
            this.cmbPayTpye.TabIndex = 3;
            this.cmbPayTpye.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbPayTpye_KeyDown);
            // 
            // cbopaycardtype
            // 
            this.cbopaycardtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbopaycardtype.Location = new System.Drawing.Point(464, 208);
            this.cbopaycardtype.Name = "cbopaycardtype";
            this.cbopaycardtype.Size = new System.Drawing.Size(120, 22);
            this.cbopaycardtype.TabIndex = 4;
            this.cbopaycardtype.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbopaycardtype_KeyDown);
            // 
            // txtpaycardno
            // 
            this.txtpaycardno.Location = new System.Drawing.Point(612, 212);
            this.txtpaycardno.Name = "txtpaycardno";
            this.txtpaycardno.Size = new System.Drawing.Size(100, 23);
            this.txtpaycardno.TabIndex = 5;
            this.txtpaycardno.Enter += new System.EventHandler(this.txtpaycardno_Enter);
            this.txtpaycardno.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtpaycardno_KeyDown);
            // 
            // frmBreakInvoice
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.CancelButton = this.btExit;
            this.ClientSize = new System.Drawing.Size(1014, 562);
            this.Controls.Add(this.txtpaycardno);
            this.Controls.Add(this.cbopaycardtype);
            this.Controls.Add(this.cmbPayTpye);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.ctlDataGrid1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmBreakInvoice";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "分发票";
            this.Load += new System.EventHandler(this.frmBreakInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ctlDataGrid1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion
		#region 自定义属性 -- 赋值分类信息
		private clsPatientChargeCal objPCVO;
		/// <summary>
		/// 标志是否第一次显示
		/// </summary>
		public int ShowTimes
		{
			set
			{
			intTimes =value;

			}
		}
		private int intTimes=0;
		/// <summary>
		/// 生成分类结构
		/// 业务需求：这个窗口传入的只有一个发票分类的信，所以一定按一定的顺序取巧
		/// 实现发票分类，下面这个函数的引用放到了VS自动生成代码的模块中，所以签入后
		/// 会把它删除，要手工加上去，目前这个函数是放在266行。如果不知道放在那里，可以用VSS中看原来的代码放在那里。
		/// </summary>
		/// <param name="p_obj"></param>
		private void m_mthCreatStructure()
		{
			com.digitalwave.controls.datagrid.clsColumnInfo objColumn =null;
			objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
			objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			objColumn.BackColor = System.Drawing.Color.White;
			objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			objColumn.ColumnIndex = 0;
			objColumn.ColumnName = "AAA";
			objColumn.ColumnWidth = 45;
			objColumn.Enabled = false;
			objColumn.ForeColor = System.Drawing.Color.Black;
			objColumn.HeadText = "";
			objColumn.ReadOnly = true;
			objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(objColumn);
			//注意下面的代码执行顺序不能乱，要统一。
			if(m_mthConvertObjToDecimal(objPCVO.m_decXyf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decWestDrug";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "西药费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
			this.ctlDataGrid1.Columns.Add(objColumn);
			}
			if(m_mthConvertObjToDecimal(objPCVO.m_decZchyf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decPatientDrug";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "中成药";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
			
				this.ctlDataGrid1.Columns.Add(objColumn);
			}

			if(m_mthConvertObjToDecimal(objPCVO.m_decZcayf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decHerbalDrug";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "中草药";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			
			if(m_mthConvertObjToDecimal(objPCVO.m_decZjf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decExamineCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "诊查费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
				
			if(m_mthConvertObjToDecimal(objPCVO.m_decLgcwf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decBedCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "床位费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			

			if(m_mthConvertObjToDecimal(objPCVO.m_decCTf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decCTCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "CT费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			
			if(m_mthConvertObjToDecimal(objPCVO.m_decMRIf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decMRICost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "MRI费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			if(m_mthConvertObjToDecimal(objPCVO.m_decSxf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decBloodCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "输血费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			if(m_mthConvertObjToDecimal(objPCVO.m_decSyf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decOxygenCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "输氧费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			if(m_mthConvertObjToDecimal(objPCVO.m_decSsf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decOPSCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "手术费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
				
			if(m_mthConvertObjToDecimal(objPCVO.m_decTxfwf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decSpecialCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "特需服务费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}

            if (m_mthConvertObjToDecimal(objPCVO.m_decClf) != 0)
            {
                objColumn = new com.digitalwave.controls.datagrid.clsColumnInfo();
                objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
                objColumn.BackColor = System.Drawing.Color.White;
                objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
                objColumn.ColumnIndex = 0;
                objColumn.ColumnName = "m_strMaterialCost";
                objColumn.ColumnWidth = 75;
                objColumn.Enabled = true;
                objColumn.ForeColor = System.Drawing.Color.Black;
                objColumn.HeadText = "材料费";
                objColumn.ReadOnly = false;
                objColumn.TextFont = new System.Drawing.Font("宋体", 10F);

                this.ctlDataGrid1.Columns.Add(objColumn);
            }
			
			if(m_mthConvertObjToDecimal(objPCVO.m_decQtf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decOtherCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "其他";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			if(m_mthConvertObjToDecimal(objPCVO.m_decJcf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decInspectCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "检查费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			if(m_mthConvertObjToDecimal(objPCVO.m_decJyf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decTestCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "检验费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			if(m_mthConvertObjToDecimal(objPCVO.m_decZlf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decCureCost";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "治疗费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
			if(m_mthConvertObjToDecimal(objPCVO.m_decBCf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decBcf";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "B超费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
            if(m_mthConvertObjToDecimal(objPCVO.m_decGHf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decGHf";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "挂号费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
            if(m_mthConvertObjToDecimal(objPCVO.m_decPgjf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decPgjf";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "膀胱镜费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				this.ctlDataGrid1.Columns.Add(objColumn);
			}
            if(m_mthConvertObjToDecimal(objPCVO.m_decSngjf)!=0)
			{
				objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
				objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
				objColumn.BackColor = System.Drawing.Color.White;
				objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
				objColumn.ColumnIndex = 0;
				objColumn.ColumnName = "m_decSngjf";
				objColumn.ColumnWidth = 75;
				objColumn.Enabled = true;
				objColumn.ForeColor = System.Drawing.Color.Black;
				objColumn.HeadText = "输尿管镜费";
				objColumn.ReadOnly = false;
				objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
				this.ctlDataGrid1.Columns.Add(objColumn);
			}

			//记账
			objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
			objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			objColumn.BackColor = System.Drawing.Color.White;
			objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
			objColumn.ColumnIndex = 0;
			objColumn.ColumnName = "chargup";
			objColumn.ColumnWidth = 75;
			objColumn.Enabled = true;
			objColumn.ForeColor = System.Drawing.Color.Black;
			objColumn.HeadText = "记账金额";
			objColumn.ReadOnly = false;
			objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(objColumn);
			//自付金额
			objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
			objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			objColumn.BackColor = System.Drawing.Color.White;
			objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
			objColumn.ColumnIndex = 0;
			objColumn.ColumnName = "SelfPay";
			objColumn.ColumnWidth = 75;
			objColumn.Enabled = true;
			objColumn.ForeColor = System.Drawing.Color.Black;
			objColumn.HeadText = "自付金额";
			objColumn.ReadOnly = false;
			objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(objColumn);
			//总额
			objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
			objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			objColumn.BackColor = System.Drawing.Color.White;
			objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_Decimal;
			objColumn.ColumnIndex = 0;
			objColumn.ColumnName = "SumMoney";
			objColumn.ColumnWidth = 75;
			objColumn.Enabled = false;
			objColumn.ForeColor = System.Drawing.Color.Black;
			objColumn.HeadText = "总额";
			objColumn.ReadOnly = true;
			objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(objColumn);
			//发票日期
			objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
			objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			objColumn.BackColor = System.Drawing.Color.White;
			objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			objColumn.ColumnIndex = 0;
			objColumn.ColumnName = "BBB";
			objColumn.ColumnWidth = 125;
			objColumn.Enabled = true;
			objColumn.ForeColor = System.Drawing.Color.Black;
			objColumn.HeadText = "发票日期";
			objColumn.ReadOnly = true;
			objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(objColumn);
			//付款方式
			objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
			objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			objColumn.BackColor = System.Drawing.Color.White;
			objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			objColumn.ColumnIndex = 0;
			objColumn.ColumnName = "CCC";
			objColumn.ColumnWidth = 70;
			objColumn.Enabled = true;
			objColumn.ForeColor = System.Drawing.Color.Black;
			objColumn.HeadText = "付款方式";
			objColumn.ReadOnly = true;
			objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(objColumn);
			//支付卡种类
			objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
			objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			objColumn.BackColor = System.Drawing.Color.White;
			objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			objColumn.ColumnIndex = 0;
			objColumn.ColumnName = "DDD";
			objColumn.ColumnWidth = 70;
			objColumn.Enabled = true;
			objColumn.ForeColor = System.Drawing.Color.Black;
			objColumn.HeadText = "支付卡种类";
			objColumn.ReadOnly = true;
			objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(objColumn);
			//支/帐号
			objColumn =new com.digitalwave.controls.datagrid.clsColumnInfo();
			objColumn.Alignment = System.Windows.Forms.HorizontalAlignment.Left;
			objColumn.BackColor = System.Drawing.Color.White;
			objColumn.Column_Type = com.digitalwave.controls.datagrid.enum_DataType.System_String;
			objColumn.ColumnIndex = 0;
			objColumn.ColumnName = "EEE";
			objColumn.ColumnWidth = 120;
			objColumn.Enabled = true;
			objColumn.ForeColor = System.Drawing.Color.Black;
			objColumn.HeadText = "卡/帐号";
			objColumn.ReadOnly = true;
			objColumn.TextFont = new System.Drawing.Font("宋体", 10F);
			this.ctlDataGrid1.Columns.Add(objColumn);
		}
		#endregion
		#region 转换成数字
		public decimal m_mthConvertObjToDecimal(object obj)
		{
			try
			{
				if( obj!=null&&obj.ToString()!="")
				{
					return Convert.ToDecimal(obj.ToString());

				}
				else
				{
					return 0;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message);
				return 0;
			}
		}

		private void btBreak_Click(object sender, System.EventArgs e)
		{
			if(this.txtPages.Text.Trim()=="")
			{
			MessageBox.Show("请输入张数!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.txtPages.Focus();
			return;
			}
			int temppage =1;
			try
			{
			temppage =int.Parse(this.txtPages.Text);
			}
			catch
			{
			
			}
			this.txtPages.Text =temppage.ToString();
			m_mthBreakPages(temppage);

		}
	
		public decimal m_mthConvertObjToDecimal(string str)
		{
			try
			{
				return Convert.ToDecimal(str.Trim());
			}
			catch
			{
				return 0;
			}
		}
		#endregion
		#region 分页
		private void m_mthBreakPages(int pages)
		{
			this.dateTimePicker1.Hide();
			this.cmbPayTpye.Hide();
			this.ctlDataGrid1.m_mthDeleteAllRow();
			if(pages>1)
			{
				for(int i=0;i<pages;i++)
				{
					this.ctlDataGrid1.m_mthAppendRow();
					this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-4] =DateTime.Now.ToString("yyyy-MM-dd");
					this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-3] =cmbPayTpye.Text;
				}
				#region 填数据
				int col =1;
				decimal decTemp=0;//平均数
				decimal decTemp2=0;//平均数
                if (m_mthConvertObjToDecimal(objPCVO.m_decXyf) != 0)
                {
                    decTemp = objPCVO.m_decXyf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decXyf - decTemp2 * (pages - 1);
                    col++;
                }
                if (m_mthConvertObjToDecimal(objPCVO.m_decZchyf) != 0)
                {
                    decTemp = objPCVO.m_decZchyf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decZchyf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decZcayf) != 0)
                {
                    decTemp = objPCVO.m_decZcayf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decZcayf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decZjf) != 0)
                {
                    decTemp = objPCVO.m_decZjf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decZjf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decLgcwf) != 0)
                {
                    decTemp = objPCVO.m_decLgcwf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decLgcwf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decCTf) != 0)
                {
                    decTemp = objPCVO.m_decCTf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decCTf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decMRIf) != 0)
                {
                    decTemp = objPCVO.m_decMRIf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decMRIf - decTemp2 * (pages - 1);
                    col++;
                }
                if (m_mthConvertObjToDecimal(objPCVO.m_decSxf) != 0)
                {
                    decTemp = objPCVO.m_decSxf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decSxf - decTemp2 * (pages - 1);
                    col++;
                }
                if (m_mthConvertObjToDecimal(objPCVO.m_decSyf) != 0)
                {
                    decTemp = objPCVO.m_decSyf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decSyf - decTemp2 * (pages - 1);
                    col++;
                }
                if (m_mthConvertObjToDecimal(objPCVO.m_decSsf) != 0)
                {
                    decTemp = objPCVO.m_decSsf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decSsf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decTxfwf) != 0)
                {
                    decTemp = objPCVO.m_decTxfwf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decTxfwf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decClf) != 0)
                {
                    decTemp = objPCVO.m_decClf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decClf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decQtf) != 0)
                {
                    decTemp = objPCVO.m_decQtf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decQtf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decJcf) != 0)
                {

                    decTemp = objPCVO.m_decJcf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decJcf - decTemp2 * (pages - 1);
                    col++;
                }
                if (m_mthConvertObjToDecimal(objPCVO.m_decJyf) != 0)
                {
                    decTemp = objPCVO.m_decJyf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decJyf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decZlf) != 0)
                {
                    decTemp = objPCVO.m_decZlf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decZlf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decBCf) != 0)
                {
                    decTemp = objPCVO.m_decBCf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decBCf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decGHf) != 0)
                {
                    decTemp = objPCVO.m_decGHf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decGHf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decPgjf) != 0)
                {
                    decTemp = objPCVO.m_decPgjf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decPgjf - decTemp2 * (pages - 1);
                    col++;
                }

                if (m_mthConvertObjToDecimal(objPCVO.m_decSngjf) != 0)
                {
                    decTemp = objPCVO.m_decSngjf / pages;
                    decTemp2 = decimal.Parse(decTemp.ToString("0.00"));
                    for (int i = 0; i < pages - 1; i++)
                    {
                        this.ctlDataGrid1[i, col] = decTemp.ToString("0.00");
                    }
                    this.ctlDataGrid1[pages - 1, col] = objPCVO.m_decSngjf - decTemp2 * (pages - 1);
                    col++;
                }

				//记账
				if(m_mthConvertObjToDecimal(objPCVO.m_decChargeUpCost)!=0)
				{
					decTemp =objPCVO.m_decChargeUpCost/pages;
					decTemp2 =decimal.Parse(decTemp.ToString("0.00"));
					for(int i=0;i<pages-1;i++)
					{
						this.ctlDataGrid1[i,col] =decTemp.ToString("0.00");
//						this.ctlDataGrid1[i,col+1] =this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-2])-this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i,col]);
					}
					this.ctlDataGrid1[pages-1,col]=objPCVO.m_decChargeUpCost -decTemp2*(pages-1);
					col++;
				}
				int tempRow =0;
				while(tempRow<this.ctlDataGrid1.RowCount)
				{
					this.CurRow =tempRow;
					m_mthCalRowMoney();
					tempRow++;
				}
				this.CurRow =0;
				#endregion
				
			}
			this.ctlDataGrid1.m_mthAppendRow();
			this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,0]="合计:";	
			#region 填充总额
			int col2=1;
            if (m_mthConvertObjToDecimal(objPCVO.m_decXyf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decXyf;
                col2++;
            }
            if (m_mthConvertObjToDecimal(objPCVO.m_decZchyf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decZchyf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decZcayf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decZcayf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decZjf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decZjf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decLgcwf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decLgcwf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decCTf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decCTf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decMRIf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decMRIf;
                col2++;
            }
            if (m_mthConvertObjToDecimal(objPCVO.m_decSxf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decSxf;
                col2++;
            }
            if (m_mthConvertObjToDecimal(objPCVO.m_decSyf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decSyf;
                col2++;
            }
            if (m_mthConvertObjToDecimal(objPCVO.m_decSsf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decSsf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decTxfwf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decTxfwf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decClf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decClf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decQtf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decQtf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decJcf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decJcf;
                col2++;
            }
            if (m_mthConvertObjToDecimal(objPCVO.m_decJyf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decJyf;
                col2++;
            }
            if (m_mthConvertObjToDecimal(objPCVO.m_decZlf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decZlf;
                col2++;
            }

            if (m_mthConvertObjToDecimal(objPCVO.m_decBCf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decBCf;
                col2++;
            }
            if (m_mthConvertObjToDecimal(objPCVO.m_decGHf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decGHf;
                col2++;
            }
            if (m_mthConvertObjToDecimal(objPCVO.m_decPgjf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decPgjf;
                col2++;
            }
            if (m_mthConvertObjToDecimal(objPCVO.m_decSngjf) != 0)
            {
                this.ctlDataGrid1[pages, col2] = objPCVO.m_decSngjf;
                col2++;
            }

			this.ctlDataGrid1[pages,col2]=objPCVO.m_decChargeUpCost;
			col2++;
			this.ctlDataGrid1[pages,col2]=objPCVO.m_decPersonCost;
			col2++;
			this.ctlDataGrid1[pages,col2]=objPCVO.m_decTotalCost;
		
			#endregion
			this.ctlDataGrid1.CurrentCell =new DataGridCell(0,1);
		}
		#endregion

		private void frmBreakInvoice_Load(object sender, System.EventArgs e)
		{
			if(intTimes==0)
			{
				m_mthBreakPages(0);
				for(int i=1;i<this.ctlDataGrid1.Columns.Count;i++)
				{
					this.ctlDataGrid1.m_mthAddEnterToSpaceColumn(i);
					((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[i] ).DataGridTextBoxColumn.TextBox.KeyPress+=new KeyPressEventHandler(TextBox_KeyPress);
				}
				//加载处理方法1
				TextBox obj  =((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[this.ctlDataGrid1.Columns.Count-4] ).DataGridTextBoxColumn.TextBox;
				if(obj!=null)
				{
					this.ctlDataGrid1.Controls.Add(this.dateTimePicker1);
					obj.Enter+=new EventHandler(TextBox_Enter);
					this.dateTimePicker1.Leave+=new EventHandler(TextBox_Leave);
				}
				//加载处理方法2
				TextBox obj2  =((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[this.ctlDataGrid1.Columns.Count-3] ).DataGridTextBoxColumn.TextBox;
				if(obj2!=null)
				{
					this.ctlDataGrid1.Controls.Add(this.cmbPayTpye);
					obj2.Enter+=new EventHandler(TextBox_Enter2);
					this.cmbPayTpye.Leave+=new EventHandler(TextBox_Leave2);
				}
				//加载处理方法3
				TextBox obj3 = ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[this.ctlDataGrid1.Columns.Count-2] ).DataGridTextBoxColumn.TextBox;
				if(obj3!=null)
				{
					this.ctlDataGrid1.Controls.Add(this.cbopaycardtype);
					obj3.Enter+=new EventHandler(TextBox_Enter3);
					this.cbopaycardtype.Leave+=new EventHandler(TextBox_Leave3);
				}
				//加载处理方法4
				TextBox obj4 = ((com.digitalwave.controls.datagrid.clsColumnInfo)ctlDataGrid1.Columns[this.ctlDataGrid1.Columns.Count-1] ).DataGridTextBoxColumn.TextBox;
				if(obj4!=null)
				{
					this.ctlDataGrid1.Controls.Add(this.txtpaycardno);
					obj4.Enter+=new EventHandler(TextBox_Enter4);
					this.txtpaycardno.Leave+=new EventHandler(TextBox_Leave4);
				}

				this.cmbPayTpye.SelectedIndexChanged+=new EventHandler(cmbPayTpye_SelectedIndexChanged);
				this.cbopaycardtype.SelectedIndexChanged+=new EventHandler(cbopaycardtype_SelectedIndexChanged);
				this.dateTimePicker1.ValueChanged+=new EventHandler(dateTimePicker1_ValueChanged);
			}
		}
		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ctlDataGrid1_m_evtCurrentCellChanged(object sender, System.EventArgs e)
		{
			if(this.ctlDataGrid1.CurrentCell.ColumnNumber==this.ctlDataGrid1.Columns.Count-1)
			{
				return;
			}
			if(this.ctlDataGrid1.CurrentCell.ColumnNumber ==this.ctlDataGrid1.Columns.Count-6)
			{
			this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.Columns.Count-4);
			}
			if(this.ctlDataGrid1.CurrentCell.ColumnNumber ==this.ctlDataGrid1.Columns.Count-5)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.Columns.Count-6);
			}
			if(this.ctlDataGrid1.CurrentCell.RowNumber ==this.ctlDataGrid1.RowCount-1&&this.ctlDataGrid1.RowCount!=1)
			{
			this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber-1,this.ctlDataGrid1.CurrentCell.ColumnNumber);
			}
			this.m_mthCalMoney();
		}
		private void dateTimePicker1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter&&this.ctlDataGrid1.CurrentCell.RowNumber!=this.ctlDataGrid1.RowCount-2)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber+1,this.ctlDataGrid1.Columns.Count-4);
			}
			if(e.KeyCode==Keys.F1)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber-1,this.ctlDataGrid1.Columns.Count-4);
			}
			if(e.KeyCode==Keys.F2)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.Columns.Count-5);
			}
			if(e.KeyCode==Keys.F3)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.Columns.Count-3);
			}
		}

		#region 在文本框失去焦点时赋值
		
		private void TextBox_Leave(object sender, EventArgs e)
		{
			this.ctlDataGrid1[row,this.ctlDataGrid1.Columns.Count-4]=this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
		}
		private void TextBox_Leave2(object sender, EventArgs e)
		{
			this.ctlDataGrid1[row,this.ctlDataGrid1.Columns.Count-3]=this.cmbPayTpye.Text;	
		}
		private void TextBox_Leave3(object sender, EventArgs e)
		{
			this.ctlDataGrid1[row,this.ctlDataGrid1.Columns.Count-2]=this.cbopaycardtype.Text;	
		}
		private void TextBox_Leave4(object sender, EventArgs e)
		{
			this.ctlDataGrid1[row,this.ctlDataGrid1.Columns.Count-1]=this.txtpaycardno.Text;
			this.txtpaycardno.Text = "";
		}
		#endregion

		private void TextBox_Enter(object sender, EventArgs e)
		{
			row =this.ctlDataGrid1.CurrentCell.RowNumber;
			this.cmbPayTpye.Hide();
			this.cbopaycardtype.Hide();
			this.txtpaycardno.Hide();
			TextBox temp = sender as TextBox;
			try
			{
				if(temp.Text.Trim()!="")
				{
					this.dateTimePicker1.Value =DateTime.Parse(temp.Text);
				}
				this.dateTimePicker1.Bounds =temp.Bounds;
				this.dateTimePicker1.Show();
				this.dateTimePicker1.Focus();
				this.dateTimePicker1.Select();
				this.dateTimePicker1.BringToFront();
			
			}
			catch
			{
			
			}
		}
		private void TextBox_Enter2(object sender, EventArgs e)
		{
			row =this.ctlDataGrid1.CurrentCell.RowNumber;
			this.dateTimePicker1.Hide();
			this.cbopaycardtype.Hide();
			this.txtpaycardno.Hide();
			TextBox temp = sender as TextBox;
			try
			{
				if(temp.Text.Trim()!="")
				{
					this.cmbPayTpye.Text =temp.Text;
				}
				this.cmbPayTpye.Bounds =temp.Bounds;
				this.cmbPayTpye.Show();
				this.cmbPayTpye.Focus();
				this.cmbPayTpye.Select();
				this.cmbPayTpye.BringToFront();
			
			}
			catch
			{
			
			}
		}

		private void TextBox_Enter3(object sender, EventArgs e)
		{
			row = this.ctlDataGrid1.CurrentCell.RowNumber;
			this.cmbPayTpye.Hide();
			this.dateTimePicker1.Hide();
			this.txtpaycardno.Hide();
			TextBox temp = sender as TextBox;
			try
			{
				if(temp.Text.Trim()!="")
				{
					this.cbopaycardtype.Text = temp.Text;
				}
				this.cbopaycardtype.Bounds = temp.Bounds;
				this.cbopaycardtype.Show();
				this.cbopaycardtype.Focus();
				this.cbopaycardtype.Select();
				this.cbopaycardtype.BringToFront();
			}
			catch
			{
			}
		}

		private void TextBox_Enter4(object sender, EventArgs e)
		{
			row = this.ctlDataGrid1.CurrentCell.RowNumber;
			this.cmbPayTpye.Hide();
			this.dateTimePicker1.Hide();
			this.cbopaycardtype.Hide();
			TextBox temp = sender as TextBox;
			try
			{				
				this.txtpaycardno.Bounds = temp.Bounds;
				this.txtpaycardno.Show();
				this.txtpaycardno.Focus();
				this.txtpaycardno.Select();
				this.txtpaycardno.BringToFront();
			}
			catch
			{
			}
		}

		#region KeyPress事件
		private void TextBox_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			this.CurCol =this.ctlDataGrid1.CurrentCell.ColumnNumber;
			this.CurRow =this.ctlDataGrid1.CurrentCell.RowNumber;			
			TextBox tb =sender as TextBox;
			if((int)e.KeyChar>=46&&(int)e.KeyChar<=57&&(int)e.KeyChar!=47||(int)e.KeyChar==8)
			{
			
			}
			else
			{
				e.Handled=true;

			}
			if(e.KeyChar=='.')
			{
				if(tb.Text.Trim()=="")
				{
					tb.Text="0.";
					System.Windows.Forms.SendKeys.SendWait("{Right}");
					System.Windows.Forms.SendKeys.SendWait("{Right}");
					e.Handled=true;
				}
				if(tb.Text.IndexOf(".")>-1)
				{
					e.Handled=true;
				}
			}
		}
	

		private void txtPages_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter&&this.txtPages.Text.Trim()!="")
			{
			this.btBreak_Click(null,null);
			}
		}

		private void txtPages_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if((int)e.KeyChar>46&&(int)e.KeyChar<=57&&(int)e.KeyChar!=47||(int)e.KeyChar==8)
			{
			
			}
			else
			{
				e.Handled=true;

			}
		}
	#endregion

		private void btOK_Click(object sender, System.EventArgs e)
		{
			this.btOK.Focus();

			//标志位
			int pos = 0;
			//支付卡类型
			string paycardtype = "";
			//支付卡号/帐号
			string paycardno = "";

			m_Invoice =new ArrayList();
			//发票的张数
			int InvoiceCount =this.ctlDataGrid1.RowCount-1;
			if(InvoiceCount <2)
			{
				m_Invoice.Add(objPCVO);
			}
			else
			{
				clsPatientChargeCal[] tempArr =new clsPatientChargeCal[InvoiceCount];
				for(int i=0;i<InvoiceCount;i++)
				{
					paycardtype = this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-2].ToString().Trim();
					if(paycardtype != "")
					{
						pos = paycardtype.IndexOf("]");
						paycardtype = paycardtype.Substring(1, pos-1);
					}
					
					paycardno = this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-1].ToString().Trim();
				
					tempArr[i]= new clsPatientChargeCal();
					tempArr[i].m_strPatientTypeName=objPCVO.m_strPatientTypeName;
					tempArr[i].m_strDocNo=objPCVO.m_strDocNo;
					tempArr[i].m_strHospitalName=objPCVO.m_strHospitalName;
					tempArr[i].m_decChargeUpCost=this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-7]);
					tempArr[i].m_decPersonCost=this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-6]);
					tempArr[i].m_decTotalCost=this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-5]);
					tempArr[i].Paycardtype = paycardtype;
					tempArr[i].Paycardno = paycardno;
					tempArr[i].m_strSeriesNumber=objPCVO.m_strSeriesNumber;
					tempArr[i].m_strPatientID=objPCVO.m_strPatientID;
					tempArr[i].m_strPatientName=objPCVO.m_strPatientName;
					tempArr[i].m_strBalanceMode=objPCVO.m_strBalanceMode;
					tempArr[i].m_strPatientName=objPCVO.m_strPatientName;
					tempArr[i].m_strPayTypeIndex=this.cmbPayTpye.Items.IndexOf(this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-3]).ToString();
					tempArr[i].m_strDateOfReception=this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-4].ToString();//时间
					int col=1;
					if(m_mthConvertObjToDecimal(objPCVO.m_decXyf)!=0)
					{
                        tempArr[i].m_decXyf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
					if(m_mthConvertObjToDecimal(objPCVO.m_decZchyf)!=0)
					{
                        tempArr[i].m_decZchyf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}

					if(m_mthConvertObjToDecimal(objPCVO.m_decZcayf)!=0)
					{
                        tempArr[i].m_decZcayf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
			
					if(m_mthConvertObjToDecimal(objPCVO.m_decZjf)!=0)
					{
                        tempArr[i].m_decZjf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
				
					if(m_mthConvertObjToDecimal(objPCVO.m_decLgcwf)!=0)
					{
                        tempArr[i].m_decLgcwf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}			

					if(m_mthConvertObjToDecimal(objPCVO.m_decCTf)!=0)
					{
                        tempArr[i].m_decCTf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
			
					if(m_mthConvertObjToDecimal(objPCVO.m_decMRIf)!=0)
					{
                        tempArr[i].m_decMRIf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
					if(m_mthConvertObjToDecimal(objPCVO.m_decSxf)!=0)
					{
                        tempArr[i].m_decSxf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
					if(m_mthConvertObjToDecimal(objPCVO.m_decSyf)!=0)
					{
                        tempArr[i].m_decSyf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
					if(m_mthConvertObjToDecimal(objPCVO.m_decSsf)!=0)
					{
                        tempArr[i].m_decSsf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
				
					if(m_mthConvertObjToDecimal(objPCVO.m_decTxfwf)!=0)
					{
                        tempArr[i].m_decTxfwf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
			
					if(m_mthConvertObjToDecimal(objPCVO.m_decClf)!=0)
					{
                        tempArr[i].m_decClf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
					
					if(m_mthConvertObjToDecimal(objPCVO.m_decQtf)!=0)
					{
                        tempArr[i].m_decQtf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
					
					if(m_mthConvertObjToDecimal(objPCVO.m_decJcf)!=0)
					{
                        tempArr[i].m_decJcf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					
					}
					if(m_mthConvertObjToDecimal(objPCVO.m_decJyf)!=0)
					{
                        tempArr[i].m_decJyf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}
					if(m_mthConvertObjToDecimal(objPCVO.m_decZlf)!=0)
					{
                        tempArr[i].m_decZlf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
						col++;
					}

                    if (m_mthConvertObjToDecimal(objPCVO.m_decBCf) != 0)
                    {
                        tempArr[i].m_decBCf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
                        col++;
                    }
                    if (m_mthConvertObjToDecimal(objPCVO.m_decGHf) != 0)
                    {
                        tempArr[i].m_decGHf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
                        col++;
                    }
                    if (m_mthConvertObjToDecimal(objPCVO.m_decPgjf) != 0)
                    {
                        tempArr[i].m_decPgjf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
                        col++;
                    }
                    if (m_mthConvertObjToDecimal(objPCVO.m_decSngjf) != 0)
                    {
                        tempArr[i].m_decSngjf = this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i, col]);
                        col++;
                    }

					m_mthHandleMoney(tempArr[i],true);
					m_Invoice.Add(tempArr[i]);
				}
			}
			this.DialogResult =DialogResult.OK;
		}
		#region 获取发分发票后的集合
		private ArrayList m_Invoice;
		public ArrayList InvoiceInfoArr
		{
			get
			{
				return m_Invoice;
			}
		}
		#endregion
		#region 计算金额
		private string dd="";
		private void m_mthCalMoney()
		{
			if(this.CurCol==this.ctlDataGrid1.Columns.Count - 1)
			{
				return;
			}
			dd =this.ctlDataGrid1[0,this.ctlDataGrid1.Columns.Count - 4].ToString();
			decimal temp =0;
			for(int i=0;i<this.ctlDataGrid1.RowCount-2;i++)
			{
			temp+=this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i,this.CurCol]);
			}
			//剩下金额
			decimal temp2 =this.m_mthConvertObjToDecimal(this.ctlDataGrid1[this.ctlDataGrid1.RowCount-1,this.CurCol])-temp;
			m_mthCalSubMoney(this.ctlDataGrid1.RowCount-2,temp2);
		}
		//用递归的方法计算金额
		private void m_mthCalSubMoney(int p_row,decimal decMoney)
		{
			int temprow=0;
			if(decMoney>=0)
			{
				this.ctlDataGrid1[p_row,this.CurCol] =decMoney;
			}
			else
			{
			this.ctlDataGrid1[p_row,this.CurCol] =0;
			 temprow =this.CurRow;
			m_mthCalSubMoney(p_row-1,this.m_mthConvertObjToDecimal(this.ctlDataGrid1[p_row-1,this.CurCol])+decMoney);
			}
			m_mthA();
		}
		#endregion
		private void m_mthA()
		{
			
			for(int i=0;i<this.ctlDataGrid1.RowCount-1;i++)
			{
				//总价
				decimal temp=0;
				for(int i2=1;i2<this.ctlDataGrid1.Columns.Count-7;i2++)
				{
					temp +=this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i,i2]);
				}
				this.ctlDataGrid1[i,this.ctlDataGrid1.Columns.Count-5] =temp;
				//记账
				int tempCol =this.ctlDataGrid1.Columns.Count - 7;
				this.ctlDataGrid1[i,tempCol+1] =temp-this.m_mthConvertObjToDecimal(this.ctlDataGrid1[i,tempCol]);
			}
		}
		#region
		#endregion
		#region 计算每一张发票的总额
		private void m_mthCalRowMoney()
		{
			//总价
			decimal temp=0;
			for(int i=1;i<this.ctlDataGrid1.Columns.Count-6;i++)
			{
			temp +=this.m_mthConvertObjToDecimal(this.ctlDataGrid1[CurRow,i]);
			}
			this.ctlDataGrid1[CurRow,this.ctlDataGrid1.Columns.Count-5] =temp;
			//记账
			int tempCol =this.ctlDataGrid1.Columns.Count -7;
			if(this.m_mthConvertObjToDecimal(this.ctlDataGrid1[CurRow,tempCol])>temp)
			{
				this.ctlDataGrid1[CurRow,tempCol] =temp;
				int intTemp =this.CurCol;
				this.CurCol =tempCol;
				m_mthCalMoney();
				this.CurCol =intTemp;
			}
			this.ctlDataGrid1[CurRow,tempCol+1] =temp-this.m_mthConvertObjToDecimal(this.ctlDataGrid1[CurRow,tempCol]);
		}
		#endregion

		private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
		{
			this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.CurrentCell.ColumnNumber]=this.dateTimePicker1.Value.ToString("yyyy-MM-dd");
		}
		#region 处理金额
		/// <summary>
		/// 处理金额
		/// </summary>
		/// <param name="p_objPCVO"></param>
		/// <param name="flag">true 加 false减</param>
		internal void m_mthHandleMoney(clsPatientChargeCal p_objPCVO,bool flag)
		{
			if(flag)
			{
				// 检查费=CT费+MRI费
                p_objPCVO.m_decJcf += p_objPCVO.m_decCTf + p_objPCVO.m_decMRIf + p_objPCVO.m_decBCf + p_objPCVO.m_decPgjf + p_objPCVO.m_decSngjf;				
				// 治疗费=输血费+输氧费
                p_objPCVO.m_decZlf += p_objPCVO.m_decSxf + p_objPCVO.m_decSyf;				
			}
			else
			{
                // 检查费=CT费+MRI费
                p_objPCVO.m_decJcf -= p_objPCVO.m_decCTf + p_objPCVO.m_decMRIf + p_objPCVO.m_decBCf + p_objPCVO.m_decPgjf + p_objPCVO.m_decSngjf;
                // 治疗费=输血费+输氧费
                p_objPCVO.m_decZlf -= p_objPCVO.m_decSxf + p_objPCVO.m_decSyf;	
			}

		}
		#endregion

		private void ctlDataGrid1_Leave(object sender, EventArgs e)
		{
			this.m_mthCalMoney();
			
		}

		private void cmbPayTpye_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.CurrentCell.ColumnNumber]=this.cmbPayTpye.Text;
		}

		private void cmbPayTpye_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter&&this.ctlDataGrid1.CurrentCell.RowNumber!=this.ctlDataGrid1.RowCount-2)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber+1,this.ctlDataGrid1.Columns.Count-3);
			}
			if(e.KeyCode==Keys.F1)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber-1,this.ctlDataGrid1.Columns.Count-3);
			}
			if(e.KeyCode==Keys.F2)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.Columns.Count-4);
			}
			if(e.KeyCode==Keys.F3)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.Columns.Count-2);
			}
		}

		private void cbopaycardtype_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.ctlDataGrid1[this.ctlDataGrid1.CurrentCell.RowNumber, this.ctlDataGrid1.CurrentCell.ColumnNumber] = this.cbopaycardtype.Text;
		}

		private void cbopaycardtype_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter&&this.ctlDataGrid1.CurrentCell.RowNumber!=this.ctlDataGrid1.RowCount-2)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber+1,this.ctlDataGrid1.Columns.Count-2);
			}
			if(e.KeyCode==Keys.F1)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber-1,this.ctlDataGrid1.Columns.Count-2);
			}
			if(e.KeyCode==Keys.F2)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.Columns.Count-3);
			}	
			if(e.KeyCode==Keys.F3)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.Columns.Count-1);
			}
		}

		private void txtpaycardno_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter&&this.ctlDataGrid1.CurrentCell.RowNumber!=this.ctlDataGrid1.RowCount-2)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber+1,this.ctlDataGrid1.Columns.Count-1);				
			}
			if(e.KeyCode==Keys.F1)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber-1,this.ctlDataGrid1.Columns.Count-1);
			}
			if(e.KeyCode==Keys.F2)
			{
				this.ctlDataGrid1.CurrentCell =new DataGridCell(this.ctlDataGrid1.CurrentCell.RowNumber,this.ctlDataGrid1.Columns.Count-2);
			}				
		}

		private void txtpaycardno_Enter(object sender, System.EventArgs e)
		{
			this.txtpaycardno.Text = this.ctlDataGrid1[row,this.ctlDataGrid1.Columns.Count-1].ToString();
		}				
	}
}
