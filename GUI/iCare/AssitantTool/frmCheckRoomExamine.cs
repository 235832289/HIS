using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using iCare;
using com.digitalwave.DiseaseTrackService;
//using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.Utility.SQLConvert;
namespace iCare
{
	/// <summary>
	/// 三级查房考核
	/// </summary>
	public class frmCheckRoomExamine : iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox m_txtPatientName;
		private System.Windows.Forms.TextBox m_txtSickArea;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox m_txtDinose;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.ListView m_lsvDetail;
		private System.Windows.Forms.Button m_cmdQuery;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.RadioButton m_rdiOutHospital;
		private System.Windows.Forms.RadioButton m_rdInhospital;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox m_txtDept;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox m_txtBedNo;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox m_txtInpatientNo;
		private System.Windows.Forms.ListView lsvInfo;
		private clsDepartmentManager m_objDepartmentManager=new clsDepartmentManager();
		private System.Windows.Forms.ColumnHeader patientName;
		private System.Windows.Forms.ColumnHeader HeaderName;
		private System.Windows.Forms.ColumnHeader BedName;
		private iCare.clsSystemContext m_objCurrentContext;
		private System.Windows.Forms.ColumnHeader inpatientID;
		private System.Windows.Forms.ColumnHeader dept;
		private System.Windows.Forms.ColumnHeader Area;
		private System.Windows.Forms.ColumnHeader BedID;
		private System.Windows.Forms.ColumnHeader OutDiognose;
		private System.Windows.Forms.ColumnHeader indiognose;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader Result;
		private System.Windows.Forms.Button m_txtClear;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

        /// <summary>
        /// 医院是否有病区
        /// </summary>
        private bool m_blnIsHasArea = true;

		public frmCheckRoomExamine()
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();
			#region
			lsvInfo = new ListView();
			this.lsvInfo.SelectedIndexChanged += new System.EventHandler(this.lsvInfo_SelectedIndexChanged);
			this.lsvInfo.DoubleClick += new System.EventHandler(this.lsvInfo_DoubleClick);
			this.lsvInfo.Leave += new System.EventHandler(this.lsvInfo_Leave);
			this.lsvInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvInfo_KeyDown);
			HeaderName = new ColumnHeader();
			BedName = new ColumnHeader();
			HeaderName.Width=100;
			m_objCurrentContext =iCare.clsSystemContext.s_ObjCurrentContext;
			#endregion

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
				if (components != null) 
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
			this.label1 = new System.Windows.Forms.Label();
			this.m_txtPatientName = new System.Windows.Forms.TextBox();
			this.m_txtSickArea = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_txtDinose = new System.Windows.Forms.TextBox();
			this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
			this.m_lsvDetail = new System.Windows.Forms.ListView();
			this.patientName = new System.Windows.Forms.ColumnHeader();
			this.m_cmdQuery = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
			this.m_rdiOutHospital = new System.Windows.Forms.RadioButton();
			this.m_rdInhospital = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.m_txtInpatientNo = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.m_txtBedNo = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.m_txtDept = new System.Windows.Forms.TextBox();
			this.inpatientID = new System.Windows.Forms.ColumnHeader();
			this.dept = new System.Windows.Forms.ColumnHeader();
			this.Area = new System.Windows.Forms.ColumnHeader();
			this.BedID = new System.Windows.Forms.ColumnHeader();
			this.OutDiognose = new System.Windows.Forms.ColumnHeader();
			this.indiognose = new System.Windows.Forms.ColumnHeader();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.Result = new System.Windows.Forms.ColumnHeader();
			this.m_txtClear = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 112);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "病人姓名";
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Location = new System.Drawing.Point(80, 112);
			this.m_txtPatientName.Name = "m_txtPatientName";
			this.m_txtPatientName.Size = new System.Drawing.Size(118, 23);
			this.m_txtPatientName.TabIndex = 3;
			this.m_txtPatientName.Text = "";
			// 
			// m_txtSickArea
			// 
			this.m_txtSickArea.Location = new System.Drawing.Point(288, 48);
			this.m_txtSickArea.Name = "m_txtSickArea";
			this.m_txtSickArea.Size = new System.Drawing.Size(118, 23);
			this.m_txtSickArea.TabIndex = 4;
			this.m_txtSickArea.Text = "";
			this.m_txtSickArea.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtSickArea_KeyDown);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(216, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(68, 23);
			this.label2.TabIndex = 7;
			this.label2.Text = "住院病区";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 8;
			this.label3.Text = "入院时间";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 9;
			this.label4.Text = "入院诊断";
			// 
			// m_txtDinose
			// 
			this.m_txtDinose.AutoSize = false;
			this.m_txtDinose.Location = new System.Drawing.Point(80, 144);
			this.m_txtDinose.Name = "m_txtDinose";
			this.m_txtDinose.Size = new System.Drawing.Size(344, 64);
			this.m_txtDinose.TabIndex = 10;
			this.m_txtDinose.Text = "";
			// 
			// dateTimePicker1
			// 
			this.dateTimePicker1.Location = new System.Drawing.Point(80, 80);
			this.dateTimePicker1.Name = "dateTimePicker1";
			this.dateTimePicker1.Size = new System.Drawing.Size(120, 23);
			this.dateTimePicker1.TabIndex = 11;
			// 
			// m_lsvDetail
			// 
			this.m_lsvDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.patientName,
																						  this.inpatientID,
																						  this.dept,
																						  this.Area,
																						  this.BedID,
																						  this.OutDiognose,
																						  this.indiognose,
																						  this.columnHeader1,
																						  this.Result});
			this.m_lsvDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvDetail.FullRowSelect = true;
			this.m_lsvDetail.GridLines = true;
			this.m_lsvDetail.Location = new System.Drawing.Point(8, 280);
			this.m_lsvDetail.Name = "m_lsvDetail";
			this.m_lsvDetail.Size = new System.Drawing.Size(688, 232);
			this.m_lsvDetail.TabIndex = 12;
			this.m_lsvDetail.View = System.Windows.Forms.View.Details;
			this.m_lsvDetail.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_lsvDetail_KeyDown);
			this.m_lsvDetail.DoubleClick += new System.EventHandler(this.m_lsvDetail_DoubleClick);
			this.m_lsvDetail.Leave += new System.EventHandler(this.m_lsvDetail_Leave);
			this.m_lsvDetail.SelectedIndexChanged += new System.EventHandler(this.m_lsvDetail_SelectedIndexChanged);
			// 
			// patientName
			// 
			this.patientName.Text = "病人姓名";
			this.patientName.Width = 75;
			// 
			// m_cmdQuery
			// 
			this.m_cmdQuery.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_cmdQuery.Location = new System.Drawing.Point(8, 240);
			this.m_cmdQuery.Name = "m_cmdQuery";
			this.m_cmdQuery.TabIndex = 13;
			this.m_cmdQuery.Text = "查询";
			this.m_cmdQuery.Click += new System.EventHandler(this.m_cmdQuery_Click);
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(240, 80);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(32, 23);
			this.label5.TabIndex = 14;
			this.label5.Text = "至：";
			// 
			// dateTimePicker2
			// 
			this.dateTimePicker2.Location = new System.Drawing.Point(288, 80);
			this.dateTimePicker2.Name = "dateTimePicker2";
			this.dateTimePicker2.Size = new System.Drawing.Size(120, 23);
			this.dateTimePicker2.TabIndex = 15;
			// 
			// m_rdiOutHospital
			// 
			this.m_rdiOutHospital.Location = new System.Drawing.Point(288, 24);
			this.m_rdiOutHospital.Name = "m_rdiOutHospital";
			this.m_rdiOutHospital.TabIndex = 16;
			this.m_rdiOutHospital.Text = "出院病人";
			this.m_rdiOutHospital.CheckedChanged += new System.EventHandler(this.m_rdiOutHospital_CheckedChanged);
			// 
			// m_rdInhospital
			// 
			this.m_rdInhospital.Checked = true;
			this.m_rdInhospital.Location = new System.Drawing.Point(80, 24);
			this.m_rdInhospital.Name = "m_rdInhospital";
			this.m_rdInhospital.TabIndex = 17;
			this.m_rdInhospital.TabStop = true;
			this.m_rdInhospital.Text = "入院病人";
			this.m_rdInhospital.CheckedChanged += new System.EventHandler(this.m_rdInhospital_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.m_txtClear);
			this.groupBox1.Controls.Add(this.m_txtInpatientNo);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Controls.Add(this.m_txtBedNo);
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.m_txtDept);
			this.groupBox1.Controls.Add(this.dateTimePicker2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.m_txtSickArea);
			this.groupBox1.Controls.Add(this.m_rdInhospital);
			this.groupBox1.Controls.Add(this.m_txtPatientName);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.dateTimePicker1);
			this.groupBox1.Controls.Add(this.m_rdiOutHospital);
			this.groupBox1.Controls.Add(this.m_txtDinose);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(624, 224);
			this.groupBox1.TabIndex = 18;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "查询窗口";
			// 
			// m_txtInpatientNo
			// 
			this.m_txtInpatientNo.Location = new System.Drawing.Point(288, 112);
			this.m_txtInpatientNo.Name = "m_txtInpatientNo";
			this.m_txtInpatientNo.Size = new System.Drawing.Size(118, 23);
			this.m_txtInpatientNo.TabIndex = 23;
			this.m_txtInpatientNo.Text = "";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(224, 112);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 23);
			this.label8.TabIndex = 22;
			this.label8.Text = "住院号";
			// 
			// m_txtBedNo
			// 
			this.m_txtBedNo.Location = new System.Drawing.Point(464, 48);
			this.m_txtBedNo.Name = "m_txtBedNo";
			this.m_txtBedNo.Size = new System.Drawing.Size(118, 23);
			this.m_txtBedNo.TabIndex = 21;
			this.m_txtBedNo.Text = "";
			this.m_txtBedNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtBedNo_KeyDown);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(424, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(40, 23);
			this.label7.TabIndex = 20;
			this.label7.Text = "床号";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(40, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(40, 23);
			this.label6.TabIndex = 19;
			this.label6.Text = "科室";
			// 
			// m_txtDept
			// 
			this.m_txtDept.Location = new System.Drawing.Point(80, 48);
			this.m_txtDept.Name = "m_txtDept";
			this.m_txtDept.Size = new System.Drawing.Size(120, 23);
			this.m_txtDept.TabIndex = 18;
			this.m_txtDept.Text = "";
			this.m_txtDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtDept_KeyDown);
			// 
			// inpatientID
			// 
			this.inpatientID.Text = "住院号";
			this.inpatientID.Width = 88;
			// 
			// dept
			// 
			this.dept.Text = "科室";
			this.dept.Width = 63;
			// 
			// Area
			// 
			this.Area.Text = "病区";
			this.Area.Width = 66;
			// 
			// BedID
			// 
			this.BedID.Text = "床号";
			this.BedID.Width = 64;
			// 
			// OutDiognose
			// 
			this.OutDiognose.Text = "出院诊断";
			this.OutDiognose.Width = 100;
			// 
			// indiognose
			// 
			this.indiognose.Text = "入院诊断";
			this.indiognose.Width = 86;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "查房医师";
			this.columnHeader1.Width = 70;
			// 
			// Result
			// 
			this.Result.Text = "考核结果";
			this.Result.Width = 78;
			// 
			// m_txtClear
			// 
			this.m_txtClear.Location = new System.Drawing.Point(528, 192);
			this.m_txtClear.Name = "m_txtClear";
			this.m_txtClear.TabIndex = 24;
			this.m_txtClear.Text = "清空";
			this.m_txtClear.Click += new System.EventHandler(this.m_txtClear_Click);
			// 
			// frmCheckRoomExamine
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(736, 525);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.m_cmdQuery);
			this.Controls.Add(this.m_lsvDetail);
			this.Name = "frmCheckRoomExamine";
			this.Text = "三级查房考核";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// 应用程序的主入口点。
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmCheckRoomExamine());
		}
		private void m_lsvDetail_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_rdiOutHospital_CheckedChanged(object sender, System.EventArgs e)
		{
			this.label3.Text="出院时间";
			this.label4.Text="出院诊断";
		}

		private void m_rdInhospital_CheckedChanged(object sender, System.EventArgs e)
		{
			this.label3.Text="入院时间";
			this.label4.Text="入院诊断";
		}

		private void m_cmdQuery_Click(object sender, System.EventArgs e)
		{
			this.m_lsvDetail.Items.Clear();
			string filter="";
			if(this.m_txtDept.Tag!=null)
			{
				filter+=" and a.indeptid ='"+(string)this.m_txtDept.Tag+"'";
			}
			if(this.m_txtSickArea.Tag!=null)
			{
				filter+=" and a.area_id ='"+(string)this.m_txtSickArea.Tag+"'";
			}
			if(this.m_txtBedNo.Tag!=null)
			{
				filter+=" and a.inpatientid ='"+(string)this.m_txtBedNo.Tag+"'";
			}
			if(this.m_rdInhospital.Checked)
			{
				filter+=" and a.inpatientenddate ="+clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat (DateTime.Parse("1900-1-1 00:00:00")) +"and a.inpatientdate >"+clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(this.dateTimePicker1.Value)+" and a.inpatientdate <"+clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(this.dateTimePicker2.Value);
			}
			if(this.m_rdiOutHospital.Checked)
			{
				filter+=" and a.inpatientenddate <> "+clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat("1900-1-1 00:00:00")+" and a.inpatientenddate >"+clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(this.dateTimePicker1.Value)+" and a.inpatientenddate <"+clsDatabaseSQLConvert.s_strGetSQLDateTimeFormat(this.dateTimePicker2.Value);
			}
			DataTable dtbResult = new DataTable();

            com.digitalwave.DiseaseTrackService.clsSaveRecordService objServ =
                    (com.digitalwave.DiseaseTrackService.clsSaveRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.DiseaseTrackService.clsSaveRecordService));

            long lngRes = objServ.m_lngResGetCheckroomInfo(null, filter, out dtbResult);
			if(lngRes>0&&dtbResult.Rows.Count>0)
			{
				for(int i = 0;i<dtbResult.Rows.Count;i++)
				{
					System.Windows.Forms.ListViewItem lsvItem = new ListViewItem(dtbResult.Rows[i]["firstname"].ToString());
					lsvItem.SubItems.Add(dtbResult.Rows[i]["inpatientid"].ToString());
					lsvItem.SubItems.Add(dtbResult.Rows[i]["deptname"].ToString());
					lsvItem.SubItems.Add(dtbResult.Rows[i]["areaname"].ToString());
					lsvItem.SubItems.Add(dtbResult.Rows[i]["bed_id"].ToString());
					lsvItem.SubItems.Add(dtbResult.Rows[i]["OUTHOSPITALDIAGNOSE_RIGHT"].ToString());
					lsvItem.SubItems.Add(dtbResult.Rows[i]["INHOSPITALDIAGNOSE_RIGHT"].ToString());
					if(dtbResult.Rows[i]["主任医师"]!=System.DBNull.Value&&dtbResult.Rows[i]["主治医师"]!=System.DBNull.Value)
					{
						lsvItem.SubItems.Add(dtbResult.Rows[i]["checkroomdoctorid"].ToString());
						lsvItem.SubItems.Add("合格");
					}
					else
					{
						lsvItem.SubItems.Add(dtbResult.Rows[i]["checkroomdoctorid"].ToString());
						lsvItem.SubItems.Add("不合格");
					}
					lsvItem.Tag=dtbResult.Rows[i];
					this.m_lsvDetail.Items.Add(lsvItem);
				}
			}
		}
		private void lsvInfo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void m_txtDept_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				clsDepartment[] objDeptArr;
				objDeptArr=	m_objDepartmentManager.m_objGetAllInDeptArr1();
				this.HeaderName.Text="部门名称";
				this.lsvInfo.Name="Dept";
				this.lsvInfo.Columns.Clear();
				this.lsvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]{this.HeaderName});
				this.groupBox1.Controls.Add(this.lsvInfo);
				#region
				this.lsvInfo.Size = new System.Drawing.Size(152,200);
				this.lsvInfo.Location = new System.Drawing.Point(80,69);
				this.lsvInfo.View = System.Windows.Forms.View.Details;
				this.lsvInfo.GridLines = true;
				this.lsvInfo.Scrollable = true;
				this.lsvInfo.Items.Clear();
				if(objDeptArr.Length>0)
				{
					for(int i = 0;i< objDeptArr.Length;i++)
					{
						System.Windows.Forms.ListViewItem lsvItem = new ListViewItem(objDeptArr[i].m_StrDeptName);
						lsvItem.Tag = objDeptArr[i];
						this.lsvInfo.Items.Add(lsvItem);
					}
				}
				this.lsvInfo.Show();
				this.lsvInfo.Visible=true;
				this.lsvInfo.BringToFront();
				this.lsvInfo.Focus();
				#endregion
			}
		}

		private void m_txtSickArea_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.m_txtDept.Tag==null)
			{
				MessageBox.Show("必须选择科室" );
				return;
			}
			if(e.KeyCode==Keys.Enter)
			{
				clsInPatientArea[] objAreaArr;
				m_objDepartmentManager.m_lngGetAllAreaInDept((string)this.m_txtDept.Tag,out objAreaArr);
                if (objAreaArr == null || objAreaArr.Length <= 0)
                {
                    m_blnIsHasArea = false;
                    return;
                }
                else
                {
                    m_blnIsHasArea = true;
                }

				this.HeaderName.Text="病区名称";
				this.lsvInfo.Name="Area";
				this.lsvInfo.Columns.Clear();
				this.lsvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]{this.HeaderName});
				this.groupBox1.Controls.Add(this.lsvInfo);
				#region
				this.lsvInfo.Size = new System.Drawing.Size(152,200);
				this.lsvInfo.Location = new System.Drawing.Point(288,69);
				this.lsvInfo.View = System.Windows.Forms.View.Details;
				this.lsvInfo.GridLines = true;
				this.lsvInfo.Scrollable = true;
				this.lsvInfo.Items.Clear();
				if(objAreaArr.Length>0)
				{
					for(int i = 0;i< objAreaArr.Length;i++)
					{
						System.Windows.Forms.ListViewItem lsvItem = new ListViewItem(objAreaArr[i].m_StrAreaName);
						lsvItem.Tag = objAreaArr[i];
						this.lsvInfo.Items.Add(lsvItem);
					}
				}
				this.lsvInfo.Show();
				this.lsvInfo.Visible=true;
				this.lsvInfo.BringToFront();
				this.lsvInfo.Focus();
				#endregion
			}
		}

		private void m_txtBedNo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(this.m_txtSickArea.Tag==null && m_blnIsHasArea)
			{
				MessageBox.Show("必须选择病区" );
				return;
			}
			if(e.KeyCode==Keys.Enter)
			{
				clsPatient [] PatientArr= null;
                if (m_blnIsHasArea)
                {
                    PatientArr = m_objCurrentContext.m_ObjPatientManager.m_objGetPatientByLikeBedNO_InArea((string)this.m_txtSickArea.Tag, this.m_txtBedNo.Text.Trim());
                }
                else
                {
                    PatientArr = m_objCurrentContext.m_ObjPatientManager.m_objGetPatientByLikeBedNO_NoArea((string)this.m_txtDept.Tag, this.m_txtBedNo.Text.Trim());
                }
				this.BedName.Text = "床号";
				this.HeaderName.Text="病人名称";
				this.lsvInfo.Name="Bed";
				this.lsvInfo.Columns.Clear();
				this.lsvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]{this.BedName,this.HeaderName});
				this.lsvInfo.FullRowSelect = true;
				this.groupBox1.Controls.Add(this.lsvInfo);
				#region
				this.lsvInfo.Size = new System.Drawing.Size(152,200);
				this.lsvInfo.Location = new System.Drawing.Point(464,69);
				this.lsvInfo.View = System.Windows.Forms.View.Details;
				this.lsvInfo.GridLines = true;
				this.lsvInfo.Scrollable = true;
				this.lsvInfo.Items.Clear();
				if(PatientArr.Length>0)
				{
					for(int i = 0;i< PatientArr.Length;i++)
					{
						System.Windows.Forms.ListViewItem lsvItem = new ListViewItem(new string[]{PatientArr[i].m_strBedCode,PatientArr[i].m_StrName});
						lsvItem.Tag = PatientArr[i];
						this.lsvInfo.Items.Add(lsvItem);
					}
				}
				this.lsvInfo.Show();
				this.lsvInfo.Visible=true;
				this.lsvInfo.BringToFront();
				this.lsvInfo.Focus();
				#endregion
			}
		}

		private void m_lsvDetail_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.m_lsvDetail.SelectedItems.Count>0)
			{
				DataRow patientInfo = (DataRow)m_lsvDetail.SelectedItems[0].Tag;
				this.m_txtBedNo.Text=patientInfo["bed_id"].ToString();
				this.m_txtDept.Text=patientInfo["deptname"].ToString();
				this.m_txtSickArea.Text=patientInfo["areaname"].ToString();
				this.m_txtPatientName.Text = patientInfo["firstname"].ToString();
				this.m_txtInpatientNo.Text = patientInfo["inpatientid"].ToString();
				if(this.m_rdInhospital.Checked)
				{
					this.m_txtDinose.Text = patientInfo["INHOSPITALDIAGNOSE_RIGHT"].ToString();
				}
				else
				{
					this.m_txtDinose.Text = patientInfo["OUTHOSPITALDIAGNOSE_RIGHT"].ToString();
				}
				if(patientInfo["主治医师"]==System.DBNull.Value)
				{
					MessageBox.Show("不合格，因为没有上级主治医师查房");
				}
				else if(patientInfo["主任医师"]==System.DBNull.Value)
				{
					MessageBox.Show("不合格，因为没有上级主任医师查房");
				}
			}
		}
		private void lsvInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.lsvInfo.Name=="Dept")
			{
				if(this.lsvInfo.SelectedItems.Count>0)
				{
					this.m_txtDept.Tag = ((clsDepartment)this.lsvInfo.SelectedItems[0].Tag).m_strDeptNewID;
					this.m_txtDept.Text = ((clsDepartment)this.lsvInfo.SelectedItems[0].Tag).m_StrDeptName;
					this.lsvInfo.Visible=false;
				}
			}
			if(this.lsvInfo.Name=="Area")
			{
				if(this.lsvInfo.SelectedItems.Count>0)
				{
					this.m_txtSickArea.Tag = ((clsInPatientArea)this.lsvInfo.SelectedItems[0].Tag).m_StrAreaID;
					this.m_txtSickArea.Text = ((clsInPatientArea)this.lsvInfo.SelectedItems[0].Tag).m_StrAreaName;
					this.lsvInfo.Visible=false;
				}
			}
			if(this.lsvInfo.Name=="Bed")
			{
				if(this.lsvInfo.SelectedItems.Count>0)
				{
					this.m_txtBedNo.Tag = ((clsPatient)this.lsvInfo.SelectedItems[0].Tag).m_StrInPatientID;
					this.m_txtBedNo.Text = ((clsPatient)this.lsvInfo.SelectedItems[0].Tag).m_strBedCode;
					this.m_txtPatientName.Text = ((clsPatient)this.lsvInfo.SelectedItems[0].Tag).m_StrName;
					this.m_txtInpatientNo.Text = ((clsPatient)this.lsvInfo.SelectedItems[0].Tag).m_StrInPatientID;
					this.lsvInfo.Visible=false;
				}
			}
		}

		private void m_lsvDetail_Leave(object sender, System.EventArgs e)
		{
		}
		private void lsvInfo_Leave(object sender, System.EventArgs e)
		{
			this.lsvInfo.Visible=false;
		}
		private void clear()
		{
			this.m_txtBedNo.Text="";
			this.m_txtBedNo.Tag=null;
			this.m_txtDept.Text="";
			this.m_txtDept.Tag=null;
			this.m_txtSickArea.Text="";
			this.m_txtSickArea.Tag=null;
			this.m_txtPatientName.Text="";
			this.m_txtPatientName.Tag=null;
			this.m_txtInpatientNo.Text="";
			this.m_txtInpatientNo.Tag=null;
		}

		private void m_txtClear_Click(object sender, System.EventArgs e)
		{
			this.clear();
		}

		private void m_lsvDetail_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		
		}
		private void lsvInfo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				lsvInfo_DoubleClick(null,null);
			}
		}
	}
}
