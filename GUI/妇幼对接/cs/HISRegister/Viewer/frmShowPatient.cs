using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmShowPatient 的摘要说明。
	/// </summary>
	public class frmShowPatient : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.GroupBox groupBox1;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private Panel panel1;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmShowPatient()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShowPatient));
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Beige;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 29);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(658, 184);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "诊疗卡号";
            this.columnHeader1.Width = 80;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "年龄";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 216);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "家庭住址";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "电话";
            this.columnHeader6.Width = 110;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "身份证号";
            this.columnHeader7.Width = 150;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 30);
            this.panel1.TabIndex = 1;
            // 
            // frmShowPatient
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
            this.ClientSize = new System.Drawing.Size(664, 216);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "frmShowPatient";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowPatient";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmShowPatient_KeyDown);
            this.Load += new System.EventHandler(this.frmShowPatient_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		#region 变量
		string strPatientName="";
		string strSex="";
		string strBirth="";
		#endregion

		private void frmShowPatient_Load(object sender, System.EventArgs e)
		{
			clsDomainControl_Register domain=new clsDomainControl_Register();
			if(strPatientName!="")
			{
				DataTable dt =new DataTable();
				domain.m_lngFindPatient(strPatientName,strSex,strBirth,out dt);
				int Age=0;
				if(dt.Rows.Count>0)
				{
					for(int i1=0;i1<dt.Rows.Count;i1++)
					{
						ListViewItem newItem=new ListViewItem(dt.Rows[i1]["PATIENTCARDID_CHR"].ToString());
						newItem.SubItems.Add(dt.Rows[i1]["LASTNAME_VCHR"].ToString().Trim());
						newItem.SubItems.Add(dt.Rows[i1]["SEX_CHR"].ToString().Trim());
						try
						{
							DateTime brith=DateTime.Parse(dt.Rows[i1]["BIRTH_DAT"].ToString());
							Age=DateTime.Now.Year-brith.Year;

						}
						catch
						{
						}
						newItem.SubItems.Add(Age.ToString().Trim());
                        newItem.SubItems.Add(dt.Rows[i1]["HOMEADDRESS_VCHR"].ToString().Trim());
                        newItem.SubItems.Add(dt.Rows[i1]["HOMEPHONE_VCHR"].ToString().Trim());
                        newItem.SubItems.Add(dt.Rows[i1]["IDCARD_CHR"].ToString().Trim());
						newItem.Tag=dt.Rows[i1];
						listView1.Items.Add(newItem);
					}
					listView1.Items[0].Selected=true;
				}
			}
		}

		private void frmShowPatient_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if(e.KeyCode==Keys.Enter)
			{
				if(listView1.SelectedItems[0].Tag!=null)
				{
					DataRow seleRow=(DataRow)listView1.SelectedItems[0].Tag;
					_m_GetCardID=seleRow["PATIENTCARDID_CHR"].ToString().Trim();
					this.DialogResult=DialogResult.OK;
				}
			}
			if(e.KeyCode==Keys.Escape)
			{
				this.Close();
			}
		}

		public string m_SetPatientName
		{
			set
			{
				strPatientName=value;
			}
		}
		public string  m_SetPatientBirth
		{
			set
			{
				strBirth=value;
			}
		}
		public string m_SetSex
		{
			set
			{
				strSex=value;
			}
		}
		private string _m_GetCardID;
		public string m_GetCardID
		{
			set
			{
				_m_GetCardID=value;
			}
			get 
			{
				return _m_GetCardID;
			}
		}
	}
}
