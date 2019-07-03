using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// frmAllergiclist 的摘要说明。
	/// </summary>
	public class frmAllergiclist : com.digitalwave.GUI_Base.frmMDI_Child_Base
	{
		internal System.Windows.Forms.ListView lvPatlist;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.ImageList imageList;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.Label label1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.Panel panel2;
		private com.digitalwave.controls.ctlRichTextBox txtmed;
		private com.digitalwave.controls.ctlRichTextBox txtdesc;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ToolTip toolTip;
	
		public frmAllergiclist()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAllergiclist));
            this.lvPatlist = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdesc = new com.digitalwave.controls.ctlRichTextBox();
            this.txtmed = new com.digitalwave.controls.ctlRichTextBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvPatlist
            // 
            this.lvPatlist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvPatlist.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11});
            this.lvPatlist.Font = new System.Drawing.Font("宋体", 10F);
            this.lvPatlist.FullRowSelect = true;
            this.lvPatlist.Location = new System.Drawing.Point(2, 41);
            this.lvPatlist.Name = "lvPatlist";
            this.lvPatlist.Size = new System.Drawing.Size(422, 405);
            this.lvPatlist.TabIndex = 1;
            this.lvPatlist.UseCompatibleStateImageBehavior = false;
            this.lvPatlist.View = System.Windows.Forms.View.Details;
            this.lvPatlist.SelectedIndexChanged += new System.EventHandler(this.lvPatlist_SelectedIndexChanged);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "序号";
            this.columnHeader6.Width = 41;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "诊疗卡号";
            this.columnHeader1.Width = 88;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "姓名";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "性别";
            this.columnHeader3.Width = 46;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "年龄";
            this.columnHeader4.Width = 52;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "接诊时间";
            this.columnHeader5.Width = 126;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "病人ID";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "处方ID";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "过敏药";
            this.columnHeader9.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "过敏描述";
            this.columnHeader10.Width = 0;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "状态";
            this.columnHeader11.Width = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lvPatlist);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 454);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(64, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "护士站皮试、注射过程中过敏人员列表";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 44);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(377, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(19, 18);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            this.toolTip.SetToolTip(this.pictureBox2, "关闭");
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnOK);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtdesc);
            this.panel2.Controls.Add(this.txtmed);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(430, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(402, 454);
            this.panel2.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.Control;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.Location = new System.Drawing.Point(316, 419);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "关闭(&C)";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.SystemColors.Control;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnOK.Location = new System.Drawing.Point(185, 419);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 28);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "医生确认(&O)";
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(8, 148);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "过敏信息：";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "过敏药品:";
            // 
            // txtdesc
            // 
            this.txtdesc.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdesc.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtdesc.Location = new System.Drawing.Point(9, 168);
            this.txtdesc.m_BlnIgnoreUserInfo = true;
            this.txtdesc.m_BlnPartControl = false;
            this.txtdesc.m_BlnReadOnly = false;
            this.txtdesc.m_BlnUnderLineDST = false;
            this.txtdesc.m_ClrDST = System.Drawing.Color.Red;
            this.txtdesc.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtdesc.m_IntCanModifyTime = 500;
            this.txtdesc.m_IntPartControlLength = 0;
            this.txtdesc.m_IntPartControlStartIndex = 0;
            this.txtdesc.m_StrUserID = "";
            this.txtdesc.m_StrUserName = "";
            this.txtdesc.Name = "txtdesc";
            this.txtdesc.Size = new System.Drawing.Size(387, 248);
            this.txtdesc.TabIndex = 1;
            this.txtdesc.Text = "";
            // 
            // txtmed
            // 
            this.txtmed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtmed.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtmed.Location = new System.Drawing.Point(9, 36);
            this.txtmed.m_BlnIgnoreUserInfo = true;
            this.txtmed.m_BlnPartControl = false;
            this.txtmed.m_BlnReadOnly = false;
            this.txtmed.m_BlnUnderLineDST = false;
            this.txtmed.m_ClrDST = System.Drawing.Color.Red;
            this.txtmed.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.txtmed.m_IntCanModifyTime = 500;
            this.txtmed.m_IntPartControlLength = 0;
            this.txtmed.m_IntPartControlStartIndex = 0;
            this.txtmed.m_StrUserID = "";
            this.txtmed.m_StrUserName = "";
            this.txtmed.Name = "txtmed";
            this.txtmed.Size = new System.Drawing.Size(387, 104);
            this.txtmed.TabIndex = 0;
            this.txtmed.Text = "";
            // 
            // frmAllergiclist
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(834, 456);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAllergiclist";
            this.ShowInTaskbar = false;
            this.Text = "过敏患者列表";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}

		public void m_mthRefresh(DataTable dt)
		{
			int rowno = 0;
			string Birthday = "";
			lvPatlist.BeginUpdate();
			lvPatlist.Items.Clear();
			for(int i=0; i<dt.Rows.Count; i++)
			{			
				rowno = i + 1;
				Birthday = dt.Rows[i]["birth_dat"].ToString().Trim();
				ListViewItem lv = new ListViewItem(rowno.ToString());
				lv.SubItems.Add(dt.Rows[i]["patientcardid_chr"].ToString().Trim());
				lv.SubItems.Add(dt.Rows[i]["name_vchr"].ToString().Trim());
				lv.SubItems.Add(dt.Rows[i]["sex_chr"].ToString().Trim());
				lv.SubItems.Add(CalcAge(Convert.ToDateTime(Birthday)));
				lv.SubItems.Add(dt.Rows[i]["create_dat"].ToString());
				lv.SubItems.Add(dt.Rows[i]["patientid_chr"].ToString().Trim());
				lv.SubItems.Add(dt.Rows[i]["outpatrecipeid_chr"].ToString().Trim());
				lv.SubItems.Add(dt.Rows[i]["allergicmed_vchr"].ToString().Trim());
				lv.SubItems.Add(dt.Rows[i]["allergicdesc_vchr"].ToString().Trim());
				lv.SubItems.Add(dt.Rows[i]["status_int"].ToString());

				if(dt.Rows[i]["status_int"].ToString()=="1")
				{
					lv.SubItems[i].ForeColor = Color.FromArgb(0,200,0);
				}				
				else
				{
					lv.SubItems[i].ForeColor = Color.FromArgb(255,0,0);
				}

				this.lvPatlist.Items.Add(lv);
			}
			lvPatlist.EndUpdate();
		}

		private string PatientID = "";
		private string RecipeID = "";
		private void lvPatlist_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(lvPatlist.SelectedItems.Count > 0)
			{
                for (int i=0; i<lvPatlist.Items.Count; i++)
                {
                    lvPatlist.Items[i].BackColor = Color.FromArgb(255, 255, 255);
                }
                lvPatlist.SelectedItems[0].BackColor = Color.FromArgb(99, 134, 222);
				PatientID = lvPatlist.SelectedItems[0].SubItems[6].Text;
				RecipeID = lvPatlist.SelectedItems[0].SubItems[7].Text;
				txtmed.Text = lvPatlist.SelectedItems[0].SubItems[8].Text;
				txtdesc.Text = lvPatlist.SelectedItems[0].SubItems[9].Text;

				string status = lvPatlist.SelectedItems[0].SubItems[10].Text;
				if(status=="1")
				{
					txtmed.Enabled = false;
					txtdesc.Enabled = false;
					btnOK.Enabled = false;
				}
				else
				{
					txtmed.Enabled = true;
					txtdesc.Enabled = true;
					btnOK.Enabled = true;
				}
			}		
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(PatientID!="")
			{
				if(MessageBox.Show("是否确认该患者的过敏信息？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					string allergicmed = txtmed.Text.Trim();
					string allergicdesc = txtdesc.Text.Trim();
					clsDcl_DoctorWorkstation objDoctor = new clsDcl_DoctorWorkstation();			
					long ret = objDoctor.m_lngUpdateallergic(PatientID, RecipeID, allergicmed, allergicdesc);
					if(ret > 0)
					{
						MessageBox.Show("确认成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
					objDoctor = null;
				}
			}
		}

		private void btnClose_Click(object sender, System.EventArgs e)
		{		
			this.Hide();
		}

		#region 计算年龄
		/// <summary>
		/// 计算年龄
		/// </summary>
		/// <param name="dteBirth">出生日期</param>
		/// <returns></returns>
		private static string CalcAge(DateTime dteBirth)
		{
			int intAge = 0;
			string strAge = "";
			Ages age = Ages.Year;
			age = CalcAge(dteBirth,out intAge);
			switch(age)
			{
				case Ages.Year:
					strAge = intAge.ToString();
					break;
				case Ages.Month:
					strAge = intAge.ToString() + "个月";
					break;
				case Ages.Day:
					strAge = intAge.ToString() + "天";
					break;
			}
			return strAge;
		}						
		
		private static Ages CalcAge(DateTime dteBirth,out int intAge)
		{
			Ages age = Ages.Year;
			intAge = 0;
			com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc objSvc = 
				(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsOPDoctorPlanSvc));
			DateTime dteNow = DateTime.Now;
			int intYear = dteBirth.Year;
			int intMonth = dteBirth.Month;
			int intDay = dteBirth.Day;

			if((dteNow.Year - intYear) >0)
			{
				intAge = dteNow.Year - intYear;
				age = Ages.Year;
			}
			else if((dteNow.Month - intMonth)>0)
			{
				intAge = dteNow.Month - intMonth;
				age = Ages.Month;
			}
			else
			{
				intAge = dteNow.Day - intDay;
				age = Ages.Day;
			}

			return age;
		}
		#endregion
	}

	#region 年龄ENUM
	/// <summary>
	/// 年龄
	/// </summary>
	public enum Ages
	{
		/// <summary>
		/// 年
		/// </summary>
		Year,
		/// <summary>
		/// 月
		/// </summary>
		Month,
		/// <summary>
		/// 日
		/// </summary>
		Day
	}
	#endregion
}
