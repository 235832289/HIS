using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace iCare
{
	public class frmCheckRoomRecord : iCare.frmHRPBaseForm
	{
		private System.Windows.Forms.ColumnHeader clmEmployeeID;
		private System.Windows.Forms.ColumnHeader clmEmployeeName;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox txtDoc;
		private System.Windows.Forms.Label m_lblTitle2;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtRecord;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.Label lblTitle1;
		private System.Windows.Forms.ListView lsvDoc;
		private System.Windows.Forms.ListView m_lsvUpperDoc;
		private com.digitalwave.Utility.Controls.ctlBorderTextBox m_txtUpperDoc;
		private System.Windows.Forms.Label lblTitle;
		private System.ComponentModel.IContainer components = null;

		public frmCheckRoomRecord()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
            //指明医生工作站表单
            intFormType = 1;
			// TODO: Add any initialization after the InitializeComponent call
		}

		/// <summary>
		/// Clean up any resources being used.
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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblTitle1 = new System.Windows.Forms.Label();
			this.lsvDoc = new System.Windows.Forms.ListView();
			this.clmEmployeeID = new System.Windows.Forms.ColumnHeader();
			this.clmEmployeeName = new System.Windows.Forms.ColumnHeader();
			this.txtDoc = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_lblTitle2 = new System.Windows.Forms.Label();
			this.m_txtRecord = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.m_lsvUpperDoc = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.m_txtUpperDoc = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
			this.lblTitle = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Location = new System.Drawing.Point(240, 12);
			this.m_lblForTitle.Visible = true;
			// 
			// lblSex
			// 
			this.lblSex.Visible = true;
			// 
			// lblAge
			// 
			this.lblAge.Visible = true;
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Visible = true;
			// 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Visible = true;
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Visible = true;
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Visible = true;
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Visible = true;
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Visible = true;
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Location = new System.Drawing.Point(836, 104);
			this.m_lsvInPatientID.Size = new System.Drawing.Size(108, 124);
			this.m_lsvInPatientID.Visible = true;
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Visible = true;
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Visible = true;
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Visible = true;
			// 
			// m_cboArea
			// 
			this.m_cboArea.Visible = true;
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Visible = true;
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Visible = true;
			// 
			// lblTitle1
			// 
			this.lblTitle1.Location = new System.Drawing.Point(44, 296);
			this.lblTitle1.Name = "lblTitle1";
			this.lblTitle1.Size = new System.Drawing.Size(64, 16);
			this.lblTitle1.TabIndex = 501;
			this.lblTitle1.Text = "主管医师";
			// 
			// lsvDoc
			// 
			this.lsvDoc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lsvDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lsvDoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																					 this.clmEmployeeID,
																					 this.clmEmployeeName});
			this.lsvDoc.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lsvDoc.ForeColor = System.Drawing.Color.White;
			this.lsvDoc.FullRowSelect = true;
			this.lsvDoc.GridLines = true;
			this.lsvDoc.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.lsvDoc.Location = new System.Drawing.Point(112, 312);
			this.lsvDoc.Name = "lsvDoc";
			this.lsvDoc.Size = new System.Drawing.Size(120, 92);
			this.lsvDoc.TabIndex = 672;
			this.lsvDoc.View = System.Windows.Forms.View.Details;
			this.lsvDoc.Visible = false;
			// 
			// clmEmployeeID
			// 
			this.clmEmployeeID.Width = 0;
			// 
			// clmEmployeeName
			// 
			this.clmEmployeeName.Width = 100;
			// 
			// txtDoc
			// 
			this.txtDoc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtDoc.BorderColor = System.Drawing.Color.White;
			this.txtDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDoc.ForeColor = System.Drawing.SystemColors.Window;
			this.txtDoc.Location = new System.Drawing.Point(112, 288);
			this.txtDoc.Name = "txtDoc";
			this.txtDoc.Size = new System.Drawing.Size(120, 23);
			this.txtDoc.TabIndex = 671;
			this.txtDoc.Text = "";
			// 
			// m_lblTitle2
			// 
			this.m_lblTitle2.Location = new System.Drawing.Point(212, 160);
			this.m_lblTitle2.Name = "m_lblTitle2";
			this.m_lblTitle2.Size = new System.Drawing.Size(428, 20);
			this.m_lblTitle2.TabIndex = 673;
			this.m_lblTitle2.Text = "查房，听取病史汇报病亲自体检后，认为";
			// 
			// m_txtRecord
			// 
			this.m_txtRecord.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtRecord.BorderColor = System.Drawing.Color.White;
			this.m_txtRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtRecord.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_txtRecord.ForeColor = System.Drawing.Color.White;
			this.m_txtRecord.Location = new System.Drawing.Point(40, 200);
			this.m_txtRecord.Multiline = true;
			this.m_txtRecord.Name = "m_txtRecord";
			this.m_txtRecord.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.m_txtRecord.Size = new System.Drawing.Size(600, 88);
			this.m_txtRecord.TabIndex = 6051;
			this.m_txtRecord.Text = "";
			// 
			// m_lsvUpperDoc
			// 
			this.m_lsvUpperDoc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_lsvUpperDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lsvUpperDoc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							this.columnHeader1,
																							this.columnHeader2});
			this.m_lsvUpperDoc.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_lsvUpperDoc.ForeColor = System.Drawing.Color.White;
			this.m_lsvUpperDoc.FullRowSelect = true;
			this.m_lsvUpperDoc.GridLines = true;
			this.m_lsvUpperDoc.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.m_lsvUpperDoc.Location = new System.Drawing.Point(88, 184);
			this.m_lsvUpperDoc.Name = "m_lsvUpperDoc";
			this.m_lsvUpperDoc.Size = new System.Drawing.Size(120, 92);
			this.m_lsvUpperDoc.TabIndex = 672;
			this.m_lsvUpperDoc.View = System.Windows.Forms.View.Details;
			this.m_lsvUpperDoc.Visible = false;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Width = 0;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Width = 100;
			// 
			// m_txtUpperDoc
			// 
			this.m_txtUpperDoc.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.m_txtUpperDoc.BorderColor = System.Drawing.Color.White;
			this.m_txtUpperDoc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txtUpperDoc.ForeColor = System.Drawing.SystemColors.Window;
			this.m_txtUpperDoc.Location = new System.Drawing.Point(88, 160);
			this.m_txtUpperDoc.Name = "m_txtUpperDoc";
			this.m_txtUpperDoc.Size = new System.Drawing.Size(120, 23);
			this.m_txtUpperDoc.TabIndex = 671;
			this.m_txtUpperDoc.Text = "";
			// 
			// lblTitle
			// 
			this.lblTitle.Location = new System.Drawing.Point(44, 164);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(44, 16);
			this.lblTitle.TabIndex = 501;
			this.lblTitle.Text = "今日";
			// 
			// frmCheckRoomRecord
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(748, 469);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_lsvBedNO,
																		  this.m_lsvPatientName,
																		  this.m_cboArea,
																		  this.m_txtBedNO,
																		  this.m_txtPatientName,
																		  this.m_lsvInPatientID,
																		  this.m_lsvUpperDoc,
																		  this.lsvDoc,
																		  this.m_txtRecord,
																		  this.m_lblTitle2,
																		  this.txtDoc,
																		  this.lblSex,
																		  this.lblAge,
																		  this.lblBedNoTitle,
																		  this.lblInHospitalNoTitle,
																		  this.lblNameTitle,
																		  this.lblSexTitle,
																		  this.lblAgeTitle,
																		  this.lblAreaTitle,
																		  this.txtInPatientID,
																		  this.m_lblForTitle,
																		  this.lblTitle1,
																		  this.m_txtUpperDoc,
																		  this.lblTitle});
			this.Name = "frmCheckRoomRecord";
			this.Load += new System.EventHandler(this.frmCheckRoomRecord_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void frmCheckRoomRecord_Load(object sender, System.EventArgs e)
		{
			m_txtUpperDoc.Focus();
		}
	}
}

