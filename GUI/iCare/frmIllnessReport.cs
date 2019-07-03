using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
namespace iCare
{
	/// <summary>
	/// frmIllnessReport 的摘要说明。
	/// </summary>
	public class frmIllnessReport : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private PinkieControls.ButtonXP btPreMonth;
		private PinkieControls.ButtonXP btNextMonth;
		private PinkieControls.ButtonXP btOK;
		private PinkieControls.ButtonXP btPrint;
		private PinkieControls.ButtonXP btExit;
		private CrystalDecisions.CrystalReports.Engine.ReportDocument m_objDocument;
		private const string c_strReportPath1=@"..\..\Templates\cry3DReport1.rpt";
		private const string c_strReportPath2=@"..\..\Templates\cry3DReport2.rpt";
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private bool flag =true;
		private PinkieControls.ButtonXP buttonXP1;
		private System.Windows.Forms.Button btSelectIllness;
		private System.Windows.Forms.Button btSelectIllness7;
		private PinkieControls.ButtonXP btSelectIllness34;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmIllnessReport()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIllnessReport));
			this.panel1 = new System.Windows.Forms.Panel();
			this.buttonXP1 = new PinkieControls.ButtonXP();
			this.btSelectIllness34 = new PinkieControls.ButtonXP();
			this.btSelectIllness = new System.Windows.Forms.Button();
			this.btExit = new PinkieControls.ButtonXP();
			this.btPrint = new PinkieControls.ButtonXP();
			this.btOK = new PinkieControls.ButtonXP();
			this.btNextMonth = new PinkieControls.ButtonXP();
			this.btPreMonth = new PinkieControls.ButtonXP();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.buttonXP1);
			this.panel1.Controls.Add(this.btSelectIllness34);
			this.panel1.Controls.Add(this.btSelectIllness);
			this.panel1.Controls.Add(this.btExit);
			this.panel1.Controls.Add(this.btPrint);
			this.panel1.Controls.Add(this.btOK);
			this.panel1.Controls.Add(this.btNextMonth);
			this.panel1.Controls.Add(this.btPreMonth);
			this.panel1.Controls.Add(this.listView1);
			this.panel1.Controls.Add(this.radioButton2);
			this.panel1.Controls.Add(this.radioButton1);
			this.panel1.Controls.Add(this.dateTimePicker2);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(5, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(240, 619);
			this.panel1.TabIndex = 1;
//			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// buttonXP1
			// 
			this.buttonXP1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.buttonXP1.DefaultScheme = true;
			this.buttonXP1.DialogResult = System.Windows.Forms.DialogResult.None;
			this.buttonXP1.Font = new System.Drawing.Font("宋体", 9F);
			this.buttonXP1.ForeColor = System.Drawing.Color.Black;
			this.buttonXP1.Hint = "";
			this.buttonXP1.Location = new System.Drawing.Point(152, 224);
			this.buttonXP1.Name = "buttonXP1";
			this.buttonXP1.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.buttonXP1.Size = new System.Drawing.Size(72, 24);
			this.buttonXP1.TabIndex = 10000026;
			this.buttonXP1.Text = "清空";
			this.buttonXP1.Click += new System.EventHandler(this.buttonXP1_Click);
			// 
			// btSelectIllness34
			// 
			this.btSelectIllness34.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btSelectIllness34.DefaultScheme = true;
			this.btSelectIllness34.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btSelectIllness34.Font = new System.Drawing.Font("宋体", 9F);
			this.btSelectIllness34.ForeColor = System.Drawing.Color.Black;
			this.btSelectIllness34.Hint = "";
			this.btSelectIllness34.Location = new System.Drawing.Point(152, 280);
			this.btSelectIllness34.Name = "btSelectIllness34";
			this.btSelectIllness34.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btSelectIllness34.Size = new System.Drawing.Size(72, 24);
			this.btSelectIllness34.TabIndex = 10000025;
			this.btSelectIllness34.Text = "选择疾病";
			this.btSelectIllness34.Visible = false;
			// 
			// btSelectIllness
			// 
			this.btSelectIllness.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btSelectIllness.Font = new System.Drawing.Font("宋体", 9F);
			this.btSelectIllness.Location = new System.Drawing.Point(152, 176);
			this.btSelectIllness.Name = "btSelectIllness";
			this.btSelectIllness.Size = new System.Drawing.Size(72, 24);
			this.btSelectIllness.TabIndex = 10000024;
			this.btSelectIllness.Text = "选择疾病";
			this.btSelectIllness.Click += new System.EventHandler(this.btSelectIllness_Click);
			// 
			// btExit
			// 
			this.btExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btExit.DefaultScheme = true;
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btExit.ForeColor = System.Drawing.Color.Black;
			this.btExit.Hint = "";
			this.btExit.Location = new System.Drawing.Point(64, 568);
			this.btExit.Name = "btExit";
			this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btExit.Size = new System.Drawing.Size(120, 32);
			this.btExit.TabIndex = 10000021;
			this.btExit.Text = "退出";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btPrint
			// 
			this.btPrint.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btPrint.DefaultScheme = true;
			this.btPrint.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btPrint.ForeColor = System.Drawing.Color.Black;
			this.btPrint.Hint = "";
			this.btPrint.Location = new System.Drawing.Point(64, 512);
			this.btPrint.Name = "btPrint";
			this.btPrint.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btPrint.Size = new System.Drawing.Size(120, 32);
			this.btPrint.TabIndex = 10000020;
			this.btPrint.Text = "打印";
			this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
			// 
			// btOK
			// 
			this.btOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btOK.DefaultScheme = true;
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btOK.ForeColor = System.Drawing.Color.Black;
			this.btOK.Hint = "";
			this.btOK.Location = new System.Drawing.Point(64, 456);
			this.btOK.Name = "btOK";
			this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btOK.Size = new System.Drawing.Size(120, 32);
			this.btOK.TabIndex = 10000019;
			this.btOK.Text = "确定";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btNextMonth
			// 
			this.btNextMonth.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btNextMonth.DefaultScheme = true;
			this.btNextMonth.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btNextMonth.Font = new System.Drawing.Font("宋体", 9F);
			this.btNextMonth.ForeColor = System.Drawing.Color.Black;
			this.btNextMonth.Hint = "";
			this.btNextMonth.Location = new System.Drawing.Point(144, 120);
			this.btNextMonth.Name = "btNextMonth";
			this.btNextMonth.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btNextMonth.Size = new System.Drawing.Size(80, 24);
			this.btNextMonth.TabIndex = 10000017;
			this.btNextMonth.Text = "下一个月->|";
			this.btNextMonth.Click += new System.EventHandler(this.btNextMonth_Click);
			// 
			// btPreMonth
			// 
			this.btPreMonth.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btPreMonth.DefaultScheme = true;
			this.btPreMonth.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btPreMonth.Font = new System.Drawing.Font("宋体", 9F);
			this.btPreMonth.ForeColor = System.Drawing.Color.Black;
			this.btPreMonth.Hint = "";
			this.btPreMonth.Location = new System.Drawing.Point(144, 72);
			this.btPreMonth.Name = "btPreMonth";
			this.btPreMonth.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btPreMonth.Size = new System.Drawing.Size(80, 24);
			this.btPreMonth.TabIndex = 10000016;
			this.btPreMonth.Text = "|<-上一个月";
			this.btPreMonth.Click += new System.EventHandler(this.btPreMonth_Click);
			// 
			// listView1
			// 
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1});
			this.listView1.GridLines = true;
			this.listView1.Location = new System.Drawing.Point(8, 176);
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(136, 232);
			this.listView1.TabIndex = 14;
			this.listView1.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "疾病名称";
			this.columnHeader1.Width = 131;
			// 
			// radioButton2
			// 
			this.radioButton2.Location = new System.Drawing.Point(120, 24);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(88, 24);
			this.radioButton2.TabIndex = 9;
			this.radioButton2.Text = "样式二";
			// 
			// radioButton1
			// 
			this.radioButton1.Checked = true;
			this.radioButton1.Location = new System.Drawing.Point(32, 24);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(72, 24);
			this.radioButton1.TabIndex = 8;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "样式一";
			this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.CustomFormat = "yyyy年MM月";
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new System.Drawing.Point(32, 120);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(96, 23);
			this.dateTimePicker2.TabIndex = 7;
			this.dateTimePicker2.Enter += new System.EventHandler(this.dateTimePicker2_Enter);
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "yyyy年MM月";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(32, 72);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(96, 23);
			this.dateTimePicker1.TabIndex = 4;
			this.dateTimePicker1.Enter += new System.EventHandler(this.dateTimePicker1_Enter);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 123);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 19);
			this.label2.TabIndex = 3;
			this.label2.Text = "到：";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 74);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 19);
			this.label1.TabIndex = 2;
			this.label1.Text = "从：";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.Add(this.crystalReportViewer1);
			this.panel2.Location = new System.Drawing.Point(248, 5);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(744, 619);
			this.panel2.TabIndex = 2;
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.crystalReportViewer1.DisplayGroupTree = false;
			this.crystalReportViewer1.DisplayToolbar = false;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, -24);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ReportSource = null;
			this.crystalReportViewer1.Size = new System.Drawing.Size(736, 664);
			this.crystalReportViewer1.TabIndex = 0;
			// 
			// frmIllnessReport
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(992, 629);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.panel2);
			this.Font = new System.Drawing.Font("宋体", 10.5F);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "frmIllnessReport";
			this.Text = "临床数据统计";
			this.Load += new System.EventHandler(this.frmIllnessReport_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
		private DataSet m_objCreateDS()
		{
			DataSet dsdsReport = new DataSet("dsReport");

			DataTable dttbReport = new DataTable("tbReport");

			DataColumn dctbReportPX = new DataColumn("PX",typeof(string));

			dttbReport.Columns.Add(dctbReportPX);

			DataColumn dctbReportPY = new DataColumn("PY",typeof(string));

			dttbReport.Columns.Add(dctbReportPY);

			DataColumn dctbReportValue = new DataColumn("Value",typeof(int));

			dttbReport.Columns.Add(dctbReportValue);

			dsdsReport.Tables.Add(dttbReport);

			return dsdsReport;
		}

		private void m_mthInitReport(int p_intType)
		{
	
			m_objDocument=new CrystalDecisions.CrystalReports.Engine.ReportDocument();

			try
			{
				Directory.SetCurrentDirectory(Application.StartupPath);
				if(p_intType==1)
					m_objDocument.Load(c_strReportPath1);
				else
					m_objDocument.Load(c_strReportPath2);
			}
			catch(Exception err)
			{
				string strMsg=err.Message.ToString();
			}
		}
		private void m_mthSetData(cls3DItem[] arrItems)
		{
			if(arrItems==null) return;

			DataSet objSet=m_objCreateDS();
			DataTable objDT=objSet.Tables["tbReport"];

			for(int i=0;i<arrItems.Length;i++)
			{
				DataRow objRow=objDT.NewRow();
				arrItems[i].ToDataRow(ref objRow);
				objDT.Rows.Add(objRow);
			}

			m_objDocument.SetDataSource(objSet);
			m_objDocument.Refresh();
			crystalReportViewer1.ReportSource=m_objDocument;
			crystalReportViewer1.Refresh();
		}
		
		private void frmIllnessReport_Load(object sender, System.EventArgs e)
		{
			com.digitalwave.common.ICD10.Tool.clsBindICD10 m_objIcd10Bind =new com.digitalwave.common.ICD10.Tool.clsBindICD10();
			m_objIcd10Bind.m_mthBindICD10(btSelectIllness,this.listView1,0,3,null,null);
			this.m_mthInitReport(1);
		}

		private void btSelectIllness_Click(object sender, System.EventArgs e)
		{
			

		}

		private void btOK_Click(object sender, System.EventArgs e)
		{
			if(this.dateTimePicker1.Value>this.dateTimePicker2.Value)
			{
			MessageBox.Show("开始日期不能大于结束日期！");
				return;
			}
			if(this.listView1.Items.Count==0)
			{
				MessageBox.Show("请选择疾病！");
				return;
			}
			ArrayList objArr =new ArrayList();
			DateTime datetime =dateTimePicker1.Value;
			while(datetime<=this.dateTimePicker2.Value)
			{
			clsDateValue dv =new clsDateValue();
			dv.strBegin=datetime.ToString("yyyy-MM-01 00:00:00");
			dv.strEnd=m_mthGetDaysInMonth(datetime);
			dv.strMonth=datetime.Month.ToString()+"月";
		    objArr.Add(dv);
			datetime=datetime.AddMonths(1);
			
			}
			cls3DItem[] obj3DItem=new cls3DItem[objArr.Count*this.listView1.Items.Count];

            //com.digitalwave.TemplateService.clsIllnessReportSvc objsvc =
            //    (com.digitalwave.TemplateService.clsIllnessReportSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.TemplateService.clsIllnessReportSvc));

			int location=0;
			Random rd =new Random(0);
			for(int i=0;i<objArr.Count;i++)
			{
				for(int i2=0;i2<this.listView1.Items.Count;i2++)
				{
				obj3DItem[location]=new cls3DItem();
				obj3DItem[location].m_strMonth=((clsDateValue)objArr[i]).strMonth;
				obj3DItem[location].m_strIllType=this.listView1.Items[i2].SubItems[0].Text.Trim();//this.listView1.Items[i2].SubItems[1].Text.Trim();
				string strIllnessName="";
					if(this.listView1.Items[i2].Tag!=null)
					{
					strIllnessName=this.listView1.Items[i2].Tag.ToString().Trim();
					}

					obj3DItem[location].m_intCount=rd.Next(100);
//				obj3DItem[location].m_intCount=objsvc.m_mthFindIllnessByDateTime(((clsDateValue)objArr[i]).strBegin,((clsDateValue)objArr[i]).strEnd,strIllnessName);
				location++;
				}
			}
			this.m_mthSetData(obj3DItem);
			
		}
		private string  m_mthGetDaysInMonth(DateTime datetime)
		{
		string ret;
			switch(datetime.Month)
			{
				case 2:
					if(datetime.Year/4==0)
					{
						ret= datetime.ToString("yyyy-MM-29 23:59:59");
					}
					else
					{
						ret= datetime.ToString("yyyy-MM-28 23:59:59");
					}
					break;
				
				case 4:
					ret= datetime.ToString("yyyy-MM-30 23:59:59");
					break;
				
				case 6:
					ret= datetime.ToString("yyyy-MM-30 23:59:59");
					break;
				
				case 9:
						ret= datetime.ToString("yyyy-MM-30 23:59:59");
					break;
				
				case 11:
						ret= datetime.ToString("yyyy-MM-30 23:59:59");
					break;
				default:
						ret= datetime.ToString("yyyy-MM-31 23:59:59");
					break;
			}
			return 	ret;
		}
		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if(this.radioButton1.Checked)
			{
				this.m_mthInitReport(1);
			}
			else
			{
				this.m_mthInitReport(0);
			}
			this.btOK_Click(null,null);
		}

		private void btPreMonth_Click(object sender, System.EventArgs e)
		{
			if(flag)
			{
			this.dateTimePicker1.Value=this.dateTimePicker1.Value.AddMonths(-1);
			}
			else
			{
				this.dateTimePicker2.Value=this.dateTimePicker2.Value.AddMonths(-1);
			}
		}

		private void btNextMonth_Click(object sender, System.EventArgs e)
		{
			if(flag)
			{
				this.dateTimePicker1.Value=this.dateTimePicker1.Value.AddMonths(1);
			}
			else
			{
			this.dateTimePicker2.Value=	this.dateTimePicker2.Value.AddMonths(1);
			}
		}

		private void dateTimePicker1_Enter(object sender, System.EventArgs e)
		{
		flag =true;
		}

		private void dateTimePicker2_Enter(object sender, System.EventArgs e)
		{
		flag =false;
		}

		private void btPrint_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_objDocument.PrintToPrinter(1,false,0,1);
			}
			catch
			{
			MessageBox.Show("没有安装打印机！");
			}
		}

		private void buttonXP1_Click(object sender, System.EventArgs e)
		{
			this.listView1.Items.Clear();
		}
		
	}
	public class clsDateValue
	{
		public string strBegin;
		public string strEnd;
		public string strMonth;
	}
	public class cls3DItem
	{
		public string m_strMonth="";
		public string m_strIllType="";
		public int m_intCount=0;

		public cls3DItem()
		{
		
		}

		public cls3DItem(string strMonth,string strIllType,int intCount)
		{
			m_strMonth=strMonth;
			m_strIllType=strIllType;
			m_intCount=intCount;
		}

		public void ToDataRow(ref System.Data.DataRow objRow)
		{
			if(objRow==null) return;
			objRow["PX"]=m_strMonth;
			objRow["PY"]=m_strIllType;
			objRow["Value"]=m_intCount;
		}
	}
}
