using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
    /// frmRecipeconfirmfalllist 的摘要说明。
	/// </summary>
	public class frmRecipeconfirmfalllist : com.digitalwave.GUI_Base.frmMDI_Child_Base
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
        private System.Windows.Forms.PictureBox pictureBox2;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
		private System.Windows.Forms.ToolTip toolTip;

        public frmRecipeconfirmfalllist()
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRecipeconfirmfalllist));
            this.lvPatlist = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
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
            this.columnHeader12,
            this.columnHeader13});
            this.lvPatlist.Font = new System.Drawing.Font("宋体", 10F);
            this.lvPatlist.FullRowSelect = true;
            this.lvPatlist.Location = new System.Drawing.Point(2, 41);
            this.lvPatlist.Name = "lvPatlist";
            this.lvPatlist.Size = new System.Drawing.Size(822, 405);
            this.lvPatlist.TabIndex = 1;
            this.lvPatlist.UseCompatibleStateImageBehavior = false;
            this.lvPatlist.View = System.Windows.Forms.View.Details;
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
            this.columnHeader5.Width = 119;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lvPatlist);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(2, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 454);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(252, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(304, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "处方审核未通过列表";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(2, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(804, 4);
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
            // columnHeader12
            // 
            this.columnHeader12.Text = "处方号";
            this.columnHeader12.Width = 93;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "未通过事由";
            this.columnHeader13.Width = 307;
            // 
            // frmRecipeconfirmfalllist
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(134)))), ((int)(((byte)(222)))));
            this.ClientSize = new System.Drawing.Size(834, 456);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRecipeconfirmfalllist";
            this.ShowInTaskbar = false;
            this.Text = "过敏患者列表";
            this.TopMost = true;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
                lv.SubItems.Add(dt.Rows[i]["createdate_dat"].ToString());				
				lv.SubItems.Add(dt.Rows[i]["outpatrecipeid_chr"].ToString().Trim());
                lv.SubItems.Add(dt.Rows[i]["confirmdesc_vchr"].ToString().Trim());
                               
				this.lvPatlist.Items.Add(lv);
			}
			lvPatlist.EndUpdate();
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
	
}
