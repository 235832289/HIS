using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 历史数据
	/// 张国良  2004-09-09 
	/// </summary>
	public class frmHistoryCheckOut : System.Windows.Forms.Form
	{
		internal PinkieControls.ButtonXP m_btnQulReg;
		internal System.Windows.Forms.DateTimePicker m_datLastdate;
		internal System.Windows.Forms.DateTimePicker m_datFirstdate;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label13;
		internal PinkieControls.ButtonXP m_btnOk;
		internal PinkieControls.ButtonXP m_btnClose;
		clsDomainConrol_Print m_clsDcrl = new clsDomainConrol_Print();
		private string str_employeeNo,str_empNo;
		internal System.Windows.Forms.ListView m_lvw;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		string strCheckOutDate;
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmHistoryCheckOut(string p_employeeNo,string empNo)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
			str_employeeNo=p_employeeNo;
			str_empNo = empNo;
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
			this.m_btnQulReg = new PinkieControls.ButtonXP();
			this.m_datLastdate = new System.Windows.Forms.DateTimePicker();
			this.m_datFirstdate = new System.Windows.Forms.DateTimePicker();
			this.label11 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.m_btnOk = new PinkieControls.ButtonXP();
			this.m_btnClose = new PinkieControls.ButtonXP();
			this.m_lvw = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// m_btnQulReg
			// 
			this.m_btnQulReg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnQulReg.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnQulReg.DefaultScheme = true;
			this.m_btnQulReg.DialogResult = System.Windows.Forms.DialogResult.None;
			this.m_btnQulReg.Hint = "";
			this.m_btnQulReg.Location = new System.Drawing.Point(400, 416);
			this.m_btnQulReg.Name = "m_btnQulReg";
			this.m_btnQulReg.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnQulReg.Size = new System.Drawing.Size(72, 24);
			this.m_btnQulReg.TabIndex = 45;
			this.m_btnQulReg.Text = "查询(&Q)";
			this.m_btnQulReg.Click += new System.EventHandler(this.m_btnQulReg_Click);
			// 
			// m_datLastdate
			// 
			this.m_datLastdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_datLastdate.Location = new System.Drawing.Point(240, 416);
			this.m_datLastdate.Name = "m_datLastdate";
			this.m_datLastdate.Size = new System.Drawing.Size(136, 23);
			this.m_datLastdate.TabIndex = 44;
			// 
			// m_datFirstdate
			// 
			this.m_datFirstdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_datFirstdate.Location = new System.Drawing.Point(80, 416);
			this.m_datFirstdate.Name = "m_datFirstdate";
			this.m_datFirstdate.Size = new System.Drawing.Size(128, 23);
			this.m_datFirstdate.TabIndex = 43;
			this.m_datFirstdate.Value = new System.DateTime(2004, 9, 8, 0, 0, 0, 0);
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label11.Location = new System.Drawing.Point(8, 416);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(64, 23);
			this.label11.TabIndex = 46;
			this.label11.Text = "查询时间";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
			this.label13.Location = new System.Drawing.Point(224, 416);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(16, 23);
			this.label13.TabIndex = 47;
			this.label13.Text = "至";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// m_btnOk
			// 
			this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnOk.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnOk.DefaultScheme = true;
			this.m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.m_btnOk.Hint = "";
			this.m_btnOk.Location = new System.Drawing.Point(480, 416);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnOk.Size = new System.Drawing.Size(64, 24);
			this.m_btnOk.TabIndex = 48;
			this.m_btnOk.Text = "确定(&O)";
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// m_btnClose
			// 
			this.m_btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnClose.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(212)), ((System.Byte)(208)), ((System.Byte)(200)));
			this.m_btnClose.DefaultScheme = true;
			this.m_btnClose.DialogResult = System.Windows.Forms.DialogResult.No;
			this.m_btnClose.Hint = "";
			this.m_btnClose.Location = new System.Drawing.Point(552, 416);
			this.m_btnClose.Name = "m_btnClose";
			this.m_btnClose.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
			this.m_btnClose.Size = new System.Drawing.Size(72, 24);
			this.m_btnClose.TabIndex = 49;
			this.m_btnClose.Text = "关闭(&C)";
			// 
			// m_lvw
			// 
			this.m_lvw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.m_lvw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					this.columnHeader1,
																					this.columnHeader4,
																					this.columnHeader5});
			this.m_lvw.FullRowSelect = true;
			this.m_lvw.GridLines = true;
			this.m_lvw.HideSelection = false;
			this.m_lvw.Location = new System.Drawing.Point(8, 8);
			this.m_lvw.Name = "m_lvw";
			this.m_lvw.Size = new System.Drawing.Size(656, 384);
			this.m_lvw.TabIndex = 51;
			this.m_lvw.View = System.Windows.Forms.View.Details;
			this.m_lvw.SelectedIndexChanged += new System.EventHandler(this.m_lvw_SelectedIndexChanged);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "";
			this.columnHeader1.Width = 0;
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "结帐日期";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 335;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "结帐员编号";
			this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader5.Width = 314;
			// 
			// frmHistoryCheckOut
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(680, 445);
			this.Controls.Add(this.m_lvw);
			this.Controls.Add(this.m_btnClose);
			this.Controls.Add(this.m_btnOk);
			this.Controls.Add(this.m_btnQulReg);
			this.Controls.Add(this.m_datLastdate);
			this.Controls.Add(this.m_datFirstdate);
			this.Controls.Add(this.label11);
			this.Controls.Add(this.label13);
			this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmHistoryCheckOut";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "结帐历史数据查询";
			this.Load += new System.EventHandler(this.frmHistoryCheckOut_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmHistoryCheckOut_Load(object sender, System.EventArgs e)
		{
			m_datFirstdate.Value=System.Convert.ToDateTime(System.DateTime.Now.Year.ToString()+"-"+System.DateTime.Now.Month.ToString()+"-1");
			m_GetQulHistor(m_datFirstdate.Value.ToShortDateString(),m_datLastdate.Value.ToShortDateString());

		}
		#region 按时间段查询 张国良  2004-09-09
		/// <summary>
		/// 按时间段查询
		/// </summary>
		/// <param name="str_Firstdate"></param>
		/// <param name="str_Lastdate"></param>
		private void m_GetQulHistor(string str_Firstdate,string str_Lastdate)
		{
			
			long lngRes;
			clscheckoutreg_VO[] m_objResultArr;
			lngRes=m_clsDcrl.m_lngQulHistory(str_employeeNo,str_Firstdate,str_Lastdate,out m_objResultArr);
			if(lngRes>0 && m_objResultArr.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<m_objResultArr.Length;i1++)
				{
					if(m_objResultArr[i1].m_strCHECKOUTDATE_DAT!="")
					{
						lvw=new ListViewItem();
						//lvw.SubItems.Add(m_objResultArr[i1].m_strMINREGNO_CHR);		
						lvw.SubItems.Add(m_objResultArr[i1].m_strCHECKOUTDATE_DAT);
						lvw.SubItems.Add(str_empNo);
						m_lvw.Items.Add(lvw);
					}
				}
			}
			
		}
		#endregion

		private void m_btnQulReg_Click(object sender, System.EventArgs e)
		{
			m_lvw.Items.Clear();
			m_GetQulHistor(m_datFirstdate.Value.ToShortDateString(),m_datLastdate.Value.ToShortDateString());

		}

		/// <summary>
		/// 外部调用接口
		/// </summary>
		/// <returns></returns>
		public string m_mthSelectItem()
		{
			
			//m_lvwSelectUser.Items.Clear();
			if(this.ShowDialog()==DialogResult.OK)
			{
				
			}
			else
			{
				strCheckOutDate=null;
			}
			return strCheckOutDate;
		}
		/// <summary>
		/// 选择记录
		/// </summary>
		/// <returns></returns>
		private void m_lvw_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			if(m_lvw.SelectedIndices.Count>0)
			{
				strCheckOutDate=m_lvw.SelectedItems[0].SubItems[1].Text.Trim();
				m_btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;		
				//MessageBox.Show(strCheckOutDate);			
			}
		}

		private void m_btnOk_Click(object sender, System.EventArgs e)
		{
			this.Close();
		
		}
	}
}
