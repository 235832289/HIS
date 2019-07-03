using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmDifficultyReportOfMonth 的摘要说明。
	/// </summary>
	public class frmDifficultyReportOfMonth  :com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Data.DataTable dataTable1;
		private System.Data.DataColumn date;
		private System.Data.DataColumn PatientName;
		private System.Data.DataColumn DifficultyNo;
		private System.Data.DataColumn InvoiceNo;
		private System.Data.DataColumn RegisterCost;
		private System.Data.DataColumn CheckSelfPay;
		private System.Data.DataColumn CheckChargeUp;
		private System.Data.DataColumn CureSelfPay;
		private System.Data.DataColumn CureChargeUp;
		private System.Data.DataColumn MedicineSelfPay;
		private System.Data.DataColumn MedicineChargeUp;
		private System.Data.DataColumn SumChargeUp;
		private System.Data.DataColumn Operator;
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
		private System.Windows.Forms.Panel panel1;
		internal PinkieControls.ButtonXP btExit;
		internal PinkieControls.ButtonXP btOK;
		internal System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label2;
		internal System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.Label label1;
		internal System.Data.DataSet dataSet1;
		private System.Windows.Forms.Panel panel2;
		private System.Drawing.Printing.PrintDocument printDocument1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmDifficultyReportOfMonth()
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
			this.dataTable1 = new System.Data.DataTable();
			this.date = new System.Data.DataColumn();
			this.PatientName = new System.Data.DataColumn();
			this.DifficultyNo = new System.Data.DataColumn();
			this.InvoiceNo = new System.Data.DataColumn();
			this.RegisterCost = new System.Data.DataColumn();
			this.CheckSelfPay = new System.Data.DataColumn();
			this.CheckChargeUp = new System.Data.DataColumn();
			this.CureSelfPay = new System.Data.DataColumn();
			this.CureChargeUp = new System.Data.DataColumn();
			this.MedicineSelfPay = new System.Data.DataColumn();
			this.MedicineChargeUp = new System.Data.DataColumn();
			this.SumChargeUp = new System.Data.DataColumn();
			this.Operator = new System.Data.DataColumn();
			this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btExit = new PinkieControls.ButtonXP();
			this.btOK = new PinkieControls.ButtonXP();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.label2 = new System.Windows.Forms.Label();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.label1 = new System.Windows.Forms.Label();
			this.dataSet1 = new System.Data.DataSet();
			this.panel2 = new System.Windows.Forms.Panel();
			this.printDocument1 = new System.Drawing.Printing.PrintDocument();
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).BeginInit();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
			this.panel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// dataTable1
			// 
			this.dataTable1.Columns.AddRange(new System.Data.DataColumn[] {
																			  this.date,
																			  this.PatientName,
																			  this.DifficultyNo,
																			  this.InvoiceNo,
																			  this.RegisterCost,
																			  this.CheckSelfPay,
																			  this.CheckChargeUp,
																			  this.CureSelfPay,
																			  this.CureChargeUp,
																			  this.MedicineSelfPay,
																			  this.MedicineChargeUp,
																			  this.SumChargeUp,
																			  this.Operator});
			this.dataTable1.TableName = "Table1";
			// 
			// date
			// 
			this.date.ColumnName = "date";
			// 
			// PatientName
			// 
			this.PatientName.ColumnName = "PatientName";
			// 
			// DifficultyNo
			// 
			this.DifficultyNo.ColumnName = "DifficultyNo";
			// 
			// InvoiceNo
			// 
			this.InvoiceNo.ColumnName = "InvoiceNo";
			// 
			// RegisterCost
			// 
			this.RegisterCost.ColumnName = "RegisterCost";
			this.RegisterCost.DataType = typeof(System.Decimal);
			// 
			// CheckSelfPay
			// 
			this.CheckSelfPay.ColumnName = "CheckSelfPay";
			this.CheckSelfPay.DataType = typeof(System.Decimal);
			// 
			// CheckChargeUp
			// 
			this.CheckChargeUp.ColumnName = "CheckChargeUp";
			this.CheckChargeUp.DataType = typeof(System.Decimal);
			// 
			// CureSelfPay
			// 
			this.CureSelfPay.ColumnName = "CureSelfPay";
			this.CureSelfPay.DataType = typeof(System.Decimal);
			// 
			// CureChargeUp
			// 
			this.CureChargeUp.ColumnName = "CureChargeUp";
			this.CureChargeUp.DataType = typeof(System.Decimal);
			// 
			// MedicineSelfPay
			// 
			this.MedicineSelfPay.ColumnName = "MedicineSelfPay";
			this.MedicineSelfPay.DataType = typeof(System.Decimal);
			// 
			// MedicineChargeUp
			// 
			this.MedicineChargeUp.ColumnName = "MedicineChargeUp";
			this.MedicineChargeUp.DataType = typeof(System.Decimal);
			// 
			// SumChargeUp
			// 
			this.SumChargeUp.ColumnName = "SumChargeUp";
			this.SumChargeUp.DataType = typeof(System.Decimal);
			// 
			// Operator
			// 
			this.Operator.ColumnName = "Operator";
			// 
			// crystalReportViewer1
			// 
			this.crystalReportViewer1.ActiveViewIndex = -1;
			this.crystalReportViewer1.DisplayGroupTree = false;
			this.crystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.crystalReportViewer1.Location = new System.Drawing.Point(0, 0);
			this.crystalReportViewer1.Name = "crystalReportViewer1";
			this.crystalReportViewer1.ReportSource = null;
			this.crystalReportViewer1.Size = new System.Drawing.Size(788, 446);
			this.crystalReportViewer1.TabIndex = 3;
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.btExit);
			this.panel1.Controls.Add(this.btOK);
			this.panel1.Controls.Add(this.dateTimePicker2);
			this.panel1.Controls.Add(this.label2);
			this.panel1.Controls.Add(this.dateTimePicker1);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(790, 60);
			this.panel1.TabIndex = 2;
			// 
			// btExit
			// 
			this.btExit.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btExit.DefaultScheme = true;
			this.btExit.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btExit.Hint = "";
			this.btExit.Location = new System.Drawing.Point(524, 16);
			this.btExit.Name = "btExit";
			this.btExit.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btExit.Size = new System.Drawing.Size(104, 32);
			this.btExit.TabIndex = 5;
			this.btExit.Text = "退出";
			this.btExit.Click += new System.EventHandler(this.btExit_Click);
			// 
			// btOK
			// 
			this.btOK.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.btOK.DefaultScheme = true;
			this.btOK.DialogResult = System.Windows.Forms.DialogResult.None;
			this.btOK.Hint = "";
			this.btOK.Location = new System.Drawing.Point(372, 16);
			this.btOK.Name = "btOK";
			this.btOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.btOK.Size = new System.Drawing.Size(104, 32);
			this.btOK.TabIndex = 4;
			this.btOK.Text = "生成报表";
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.CustomFormat = "yyyy年MM月";
			this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker2.Location = new System.Drawing.Point(204, 20);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(108, 23);
			this.dateTimePicker2.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(176, 24);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(20, 19);
			this.label2.TabIndex = 2;
			this.label2.Text = "到";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.CustomFormat = "yyyy年MM月";
			this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dateTimePicker1.Location = new System.Drawing.Point(60, 20);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(108, 23);
			this.dateTimePicker1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(28, 24);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(27, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "从:";
			// 
			// dataSet1
			// 
			this.dataSet1.DataSetName = "NewDataSet";
			this.dataSet1.Locale = new System.Globalization.CultureInfo("zh-CN");
			this.dataSet1.Tables.AddRange(new System.Data.DataTable[] {
																		  this.dataTable1});
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Controls.Add(this.crystalReportViewer1);
			this.panel2.Location = new System.Drawing.Point(0, 72);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(790, 448);
			this.panel2.TabIndex = 4;
			// 
			// frmDifficultyReportOfMonth
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(792, 525);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel1);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.Name = "frmDifficultyReportOfMonth";
			this.Text = "禅城区特困门诊基本医疗服务费用减免统计表";
			this.Load += new System.EventHandler(this.frmDifficultyReportOfMonth_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataTable1)).EndInit();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
			this.panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion
		#region 变量
		clsDcl_DifficultyReport Domain=new clsDcl_DifficultyReport();
		ReportDocument rd=new ReportDocument();
		#endregion
		private void frmDifficultyReportOfMonth_Load(object sender, System.EventArgs e)
		{
			
		}
		#region 统计数据
		public void m_mthShowReport()
		{
			rd.Load("Report\\CryDifficultyReportOfMonth.rpt");
			DateTime date=DateTime.Parse(dateTimePicker1.Value.Year.ToString()+"-"+dateTimePicker1.Value.Month.ToString()+"-01 00:00:00");
			DateTime date1=DateTime.Parse(dateTimePicker2.Value.Year.ToString()+"-"+dateTimePicker2.Value.AddMonths(1).Month.ToString()+"-01 00:00:00");
			System.Data.DataTable dtReport=new System.Data.DataTable();
			System.Data.DataTable dt=new System.Data.DataTable();
			System.Data.DataTable dt1=new System.Data.DataTable();
			System.Data.DataTable dt2=new System.Data.DataTable();
			Domain.m_mthGetAllDataOfMonth(date,date1,out dt,out dt1,out dt2);
			if(dt1.Rows.Count>0)
			{
				dtReport.Columns.Add("month");
				for(int h1=0;h1<dt1.Rows.Count;h1++)
				{
					dtReport.Columns.Add(dt1.Rows[h1]["groupid_chr"].ToString(),typeof(int));
					dtReport.Columns.Add(dt1.Rows[h1]["groupid_chr"].ToString()+"temp",typeof(double));
				}
			}
			else
			{
				return;
			}
			

			if(dt.Rows.Count>0)
			{
				for(int i1=0;i1<dt.Rows.Count;i1++)
				{
					if(dtReport.Rows.Count>0)
					{
						for(int f2=0;f2<dtReport.Rows.Count;f2++)
						{
							if(dt.Rows[i1]["MONTH"].ToString()==dtReport.Rows[f2]["month"].ToString())
							{
								for(int k2=0;k2<dtReport.Columns.Count;k2++)
								{
									if(dtReport.Columns[k2].ColumnName==dt.Rows[i1]["groupid_chr"].ToString())
									{
										if(dtReport.Rows[f2][k2]==System.DBNull.Value)
											dtReport.Rows[f2][k2]=0;
										if(dtReport.Rows[f2][k2+1]==System.DBNull.Value)
											dtReport.Rows[f2][k2+1]=0;
										dtReport.Rows[f2][k2]=int.Parse(dtReport.Rows[f2][k2].ToString())+int.Parse(dt.Rows[i1]["TOTAILCOUNT"].ToString());
										dtReport.Rows[f2][k2+1]=Double.Parse(dtReport.Rows[f2][k2+1].ToString())+Double.Parse(dt.Rows[i1]["CHARGEUP"].ToString());
										f2=dtReport.Rows.Count;
										break;
									}
								}
								
							}
							if(f2==dtReport.Rows.Count-1)
							{
								System.Data.DataRow dtRow=dtReport.NewRow();

								dtRow["month"]=dt.Rows[i1]["MONTH"];
								for(int k2=1;k2<dtReport.Columns.Count;k2++)
								{
									dtRow[k2]=0;
								}
								for(int k2=1;k2<dtReport.Columns.Count;k2++)
								{
									if(dtReport.Columns[k2].ColumnName==dt.Rows[i1]["groupid_chr"].ToString())
									{
										dtRow[k2]=int.Parse(dt.Rows[i1]["TOTAILCOUNT"].ToString());
										dtRow[k2+1]=Double.Parse(dt.Rows[i1]["CHARGEUP"].ToString());
										break;
									}
								}
								dtReport.Rows.Add(dtRow);
								break;
							}
						}
					}
					else
					{
						System.Data.DataRow dtRow=dtReport.NewRow();
						for(int k2=1;k2<dtReport.Columns.Count;k2++)
						{
							dtRow[k2]=0;
						}
						dtRow["month"]=dt.Rows[0]["MONTH"];
						for(int k2=1;k2<dtReport.Columns.Count;k2++)
						{
							if(dtReport.Columns[k2].ColumnName==dt.Rows[0]["groupid_chr"].ToString())
							{
								dtRow[k2]=int.Parse(dt.Rows[i1]["TOTAILCOUNT"].ToString());
								dtRow[k2+1]=Double.Parse(dt.Rows[i1]["CHARGEUP"].ToString());
								break;
							}
						}
						dtReport.Rows.Add(dtRow);
			
					}
				}
				
			}
			dtReport.Columns[0].ColumnName="month";
			dtReport.Columns[1].ColumnName="data1Man";
			dtReport.Columns[2].ColumnName="data1Money";
			dtReport.Columns[3].ColumnName="data2Man";
			dtReport.Columns[4].ColumnName="data2Money";
			dtReport.Columns[5].ColumnName="data3Man";
			dtReport.Columns[6].ColumnName="data3Money";
			dtReport.Columns[7].ColumnName="data4Man";
			dtReport.Columns[8].ColumnName="data4Money";
			dtReport.Columns.Add("data5Man",typeof(int));
			dtReport.Columns.Add("data5Money",typeof(double));
			if(dtReport.Rows.Count>0)
			{
				for(int i1=0;i1<dtReport.Rows.Count;i1++)
				{
					dtReport.Rows[i1]["data1Man"]=0;
					dtReport.Rows[i1]["data1Money"]=0;
					if(dt2.Rows.Count>0)
					{
						for(int f2=0;f2<dt2.Rows.Count;f2++)
						{
							if(dtReport.Rows[i1]["month"].ToString().Trim()==dt2.Rows[f2]["MONTH"].ToString().Trim())
							{
								dtReport.Rows[i1]["data1Man"]=double.Parse(dtReport.Rows[i1]["data1Man"].ToString())+1;
								dtReport.Rows[i1]["data1Money"]=double.Parse(dtReport.Rows[i1]["data1Money"].ToString())+double.Parse(dt2.Rows[f2]["registercost"].ToString());
							}
						}
					}
					dtReport.Rows[i1]["data5Man"]=double.Parse(dtReport.Rows[i1]["data1Man"].ToString())+double.Parse(dtReport.Rows[i1]["data2Man"].ToString())+double.Parse(dtReport.Rows[i1]["data3Man"].ToString())+double.Parse(dtReport.Rows[i1]["data4Man"].ToString());
					dtReport.Rows[i1]["data5Money"]=double.Parse(dtReport.Rows[i1]["data1Money"].ToString())+double.Parse(dtReport.Rows[i1]["data2Money"].ToString())+double.Parse(dtReport.Rows[i1]["data3Money"].ToString())+double.Parse(dtReport.Rows[i1]["data4Money"].ToString());
				}
			}
			rd.SetDataSource(dtReport);
			rd.Refresh();
			crystalReportViewer1.ReportSource=rd;
		}
		#endregion

		private void btOK_Click(object sender, System.EventArgs e)
		{
			m_mthShowReport();
		}

		private void btExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
