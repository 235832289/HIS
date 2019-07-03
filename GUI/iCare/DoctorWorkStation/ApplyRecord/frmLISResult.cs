using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.LIS;
using 	com.digitalwave.iCare.ValueObject;
namespace iCare.DoctorWorkStation
{
	/// <summary>
	/// 检验结果
	/// </summary>
	public class frmLISResult : iCare.iCareBaseForm.frmBaseForm
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.ListView listView2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DateTimePicker dateTimePicker1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.DateTimePicker dateTimePicker2;
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmLISResult()
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
				objPatient = null;
			}
			base.Dispose( disposing );
		}
		clsPatient objPatient=null;
		public clsPatient SetPatientInfo
		{
			set
			{
			objPatient=value;
				if(objPatient!=null)
				{
				this.textBox1.Text=objPatient.m_StrName;
				}
			}
		}
		private string strResult;
		public string Result
		{
			get
			{
			return  strResult;
			}
		}
		#region Windows 窗体设计器生成的代码
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLISResult));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.panel4 = new System.Windows.Forms.Panel();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(8, 8);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(184, 400);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.Click += new System.EventHandler(this.listView1_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "检验内容";
            this.columnHeader1.Width = 177;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dateTimePicker2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(648, 160);
            this.panel1.TabIndex = 1;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Enabled = false;
            this.dateTimePicker2.Location = new System.Drawing.Point(504, 16);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker2.TabIndex = 508;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(416, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 19);
            this.label3.TabIndex = 507;
            this.label3.Text = "检查日期：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Location = new System.Drawing.Point(16, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 104);
            this.groupBox1.TabIndex = 506;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "检验意见";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(8, 19);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(480, 77);
            this.textBox2.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(280, 16);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(120, 23);
            this.dateTimePicker1.TabIndex = 505;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(208, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 19);
            this.label2.TabIndex = 504;
            this.label2.Text = "申请日期：";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(544, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 32);
            this.button2.TabIndex = 503;
            this.button2.Text = "取消";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(544, 64);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 32);
            this.button1.TabIndex = 502;
            this.button1.Text = "确定";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 16);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(112, 23);
            this.textBox1.TabIndex = 501;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(16, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 19);
            this.label1.TabIndex = 500;
            this.label1.Text = "当前病人:";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(8, 176);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 416);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.listView2);
            this.panel3.Location = new System.Drawing.Point(216, 176);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(440, 296);
            this.panel3.TabIndex = 3;
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listView2.GridLines = true;
            this.listView2.Location = new System.Drawing.Point(8, 8);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(424, 280);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.DoubleClick += new System.EventHandler(this.listView2_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目名称";
            this.columnHeader2.Width = 101;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "单位";
            this.columnHeader3.Width = 86;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "结果值";
            this.columnHeader4.Width = 86;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "参考范围";
            this.columnHeader5.Width = 83;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "标志";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.listBox1);
            this.panel4.Location = new System.Drawing.Point(216, 480);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(440, 112);
            this.panel4.TabIndex = 4;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(8, 8);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(424, 88);
            this.listBox1.TabIndex = 0;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            // 
            // frmLISResult
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(664, 597);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 10.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLISResult";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "检验结果";
            this.Load += new System.EventHandler(this.frmLISResult_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void frmLISResult_Load(object sender, System.EventArgs e)
		{
			if(objPatient==null)
			{
				return;
			}

            com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc objA =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplicationSvc));

			com.digitalwave.iCare.ValueObject.clsLISPatientCheckResultInfoVO[] LisVO=null;
			objA.m_lngGetResultInfo(null,objPatient.m_StrInPatientID,objPatient.m_DtmSelectedInDate.ToString(),null,out LisVO);
			if(LisVO!=null)
			{
				ListViewItem lv;
				clsLisApplMainVO AMVO;
				for(int i=0;i<LisVO.Length;i++)
				{
					AMVO =LisVO[i].m_objApp;
					if(AMVO!=null)
					{
						lv=new ListViewItem(AMVO.m_strCheckContent);
						lv.Tag=LisVO[i];
						this.listView1.Items.Add(lv);
					}

				}
			}
            //objA.Dispose();
			objA = null;
		}

		private void listView1_Click(object sender, System.EventArgs e)
		{
			if(this.listView1.SelectedItems.Count<=0)
			{
			return;
			}
			clsLISPatientCheckResultInfoVO obj =(clsLISPatientCheckResultInfoVO)this.listView1.SelectedItems[0].Tag;
			if(obj==null)
			{
			return;
			}
			clsLisApplMainVO AMVO=obj.m_objApp;
			if(AMVO!=null)
			{
				try
				{
					this.dateTimePicker1.Value=DateTime.Parse(AMVO.m_strAppl_Dat.ToString());
				}
				catch
				{
					this.dateTimePicker1.Value=DateTime.Now;
				}
			}
			///////////////////////////////////////////
			clsT_OPR_LIS_APP_REPORT_VO LARVO =obj.m_objAppReport;
			if(LARVO!=null)
			{
			textBox2.Text =LARVO.m_strSUMMARY_VCHR;
				try
				{
					this.dateTimePicker2.Value=DateTime.Parse(LARVO.m_strREPORT_DAT.ToString());
				}
				catch
				{
					this.dateTimePicker2.Value=DateTime.Now;
				}
			}
///////////////////////////////////
			clsCheckResult_VO[] CRVO =obj.m_objResults;
			if(CRVO!=null)
			{
				ListViewItem lv;
				listView2.Items.Clear();
				for(int i=0;i<CRVO.Length;i++)
				{
					if(CRVO[i] == null)
						continue;

					lv=new ListViewItem(CRVO[i].m_strCheck_Item_Name);
					lv.SubItems.Add(CRVO[i].m_strUnit);
					lv.SubItems.Add(CRVO[i].m_strResult);
					lv.SubItems.Add(CRVO[i].m_strRefrange);
					switch(CRVO[i].m_strUnit.Trim())
					{
						case "H":
							lv.SubItems.Add("偏高");
							lv.BackColor=Color.Red;
							break;
						case "L":
							lv.SubItems.Add("偏低");
							lv.BackColor=Color.Yellow;
							break;
						default:
						lv.SubItems.Add("");
							break;
					}
				
				listView2.Items.Add(lv);

				}
			}

		}

		private void listView2_DoubleClick(object sender, System.EventArgs e)
		{
			if(listView2.SelectedItems.Count>0)
			{
                ListViewItem item = this.listView2.SelectedItems[0];
                this.listBox1.Items.Add(item.SubItems[0].Text.Trim() + item.SubItems[2].Text.Trim() + item.SubItems[1].Text.Trim());
            }
		}

		private void listBox1_DoubleClick(object sender, System.EventArgs e)
		{
			if(this.listBox1.SelectedIndex>-1)
			{
				this.listBox1.Items.RemoveAt(this.listBox1.SelectedIndex);
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			for(int i=0;i<listBox1.Items.Count;i++)
			{
				if(i>0) strResult+="，";
				strResult+=listBox1.Items[i].ToString();
//			strResult +=i.ToString()+"、"+listBox1.Items[0].ToString();
			}
			this.DialogResult=DialogResult.OK;
		}
		
	}
}
