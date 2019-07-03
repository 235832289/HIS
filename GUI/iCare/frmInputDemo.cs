using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using com.digitalwave.Utility.Controls;


namespace iCare
{
	public class frmInputDemo : iCare.frmHRPBaseForm
	{
		private System.Windows.Forms.Panel pnlRecord;
		private System.Windows.Forms.Label lblSign;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpRecordTime;
		private System.Windows.Forms.Label lblRecordTime;
		private System.Windows.Forms.Label lblRecordContentTitle;
		private System.Windows.Forms.Label lblSignTitle;
		private System.Windows.Forms.TreeView trvTime;
		private System.Windows.Forms.ListBox m_lstShow;
		private com.digitalwave.Utility.Controls.ctlRichTextBox txtRecordContent;
		private System.ComponentModel.IContainer components = null;

		public frmInputDemo()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	txtRecordContent ,this.trvTime,this.pnlRecord ,});			

			m_lblForTitle.Text = "病 案 记 录";
		}
        //private com.digitalwave.Utility.Controls.clsBorderTool  m_objBorderTool;
		

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
			this.pnlRecord = new System.Windows.Forms.Panel();
			this.m_lstShow = new System.Windows.Forms.ListBox();
			this.lblSign = new System.Windows.Forms.Label();
			this.dtpRecordTime = new com.digitalwave.Utility.Controls.ctlTimePicker();
			this.lblRecordTime = new System.Windows.Forms.Label();
			this.lblRecordContentTitle = new System.Windows.Forms.Label();
			this.txtRecordContent = new com.digitalwave.Utility.Controls.ctlRichTextBox();
			this.lblSignTitle = new System.Windows.Forms.Label();
			this.trvTime = new System.Windows.Forms.TreeView();
			this.pnlRecord.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lblForTitle
			// 
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
			// pnlRecord
			// 
			this.pnlRecord.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.pnlRecord.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.m_lstShow,
																					this.lblSign,
																					this.dtpRecordTime,
																					this.lblRecordTime,
																					this.lblRecordContentTitle,
																					this.txtRecordContent,
																					this.lblSignTitle});
			this.pnlRecord.Location = new System.Drawing.Point(280, 144);
			this.pnlRecord.Name = "pnlRecord";
			this.pnlRecord.Size = new System.Drawing.Size(744, 612);
			this.pnlRecord.TabIndex = 6010;
			// 
			// m_lstShow
			// 
			this.m_lstShow.BackColor = System.Drawing.Color.Yellow;
			this.m_lstShow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_lstShow.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
			this.m_lstShow.ItemHeight = 14;
			this.m_lstShow.Location = new System.Drawing.Point(224, 56);
			this.m_lstShow.Name = "m_lstShow";
			this.m_lstShow.Size = new System.Drawing.Size(120, 72);
			this.m_lstShow.TabIndex = 518;
			this.m_lstShow.Visible = false;
			this.m_lstShow.DoubleClick += new System.EventHandler(this.m_lstShow_DoubleClick);
			// 
			// lblSign
			// 
			this.lblSign.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.lblSign.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblSign.ForeColor = System.Drawing.SystemColors.Window;
			this.lblSign.Location = new System.Drawing.Point(608, 440);
			this.lblSign.Name = "lblSign";
			this.lblSign.Size = new System.Drawing.Size(120, 19);
			this.lblSign.TabIndex = 6016;
			// 
			// dtpRecordTime
			// 
			this.dtpRecordTime.BorderColor = System.Drawing.Color.White;
			this.dtpRecordTime.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
			this.dtpRecordTime.DropButtonBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.dtpRecordTime.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
			this.dtpRecordTime.DropButtonForeColor = System.Drawing.Color.White;
			this.dtpRecordTime.flatFont = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpRecordTime.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.dtpRecordTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtpRecordTime.Location = new System.Drawing.Point(114, 19);
			this.dtpRecordTime.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
			this.dtpRecordTime.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
			this.dtpRecordTime.Name = "dtpRecordTime";
			this.dtpRecordTime.Size = new System.Drawing.Size(208, 26);
			this.dtpRecordTime.TabIndex = 125;
			this.dtpRecordTime.TextBackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.dtpRecordTime.TextForeColor = System.Drawing.Color.White;
			// 
			// lblRecordTime
			// 
			this.lblRecordTime.AutoSize = true;
			this.lblRecordTime.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.lblRecordTime.Location = new System.Drawing.Point(8, 23);
			this.lblRecordTime.Name = "lblRecordTime";
			this.lblRecordTime.Size = new System.Drawing.Size(88, 19);
			this.lblRecordTime.TabIndex = 6013;
			this.lblRecordTime.Text = "记录时间：";
			// 
			// lblRecordContentTitle
			// 
			this.lblRecordContentTitle.ForeColor = System.Drawing.Color.White;
			this.lblRecordContentTitle.Location = new System.Drawing.Point(8, 55);
			this.lblRecordContentTitle.Name = "lblRecordContentTitle";
			this.lblRecordContentTitle.Size = new System.Drawing.Size(84, 24);
			this.lblRecordContentTitle.TabIndex = 6010;
			this.lblRecordContentTitle.Text = "病案记录:";
			// 
			// txtRecordContent
			// 
			this.txtRecordContent.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(113)), ((System.Byte)(152)));
			this.txtRecordContent.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.txtRecordContent.ForeColor = System.Drawing.Color.White;
			this.txtRecordContent.Location = new System.Drawing.Point(10, 82);
			this.txtRecordContent.m_BlnPartControl = false;
			this.txtRecordContent.m_BlnReadOnly = false;
			this.txtRecordContent.m_ClrDST = System.Drawing.Color.Red;
			this.txtRecordContent.m_ClrOldPartInsertText = System.Drawing.Color.Yellow;
			this.txtRecordContent.m_IntCanModifyTime = 6;
			this.txtRecordContent.m_IntPartControlLength = 0;
			this.txtRecordContent.m_IntPartControlStartIndex = 0;
			this.txtRecordContent.m_StrUserID = "";
			this.txtRecordContent.m_StrUserName = "";
			this.txtRecordContent.Name = "txtRecordContent";
			this.txtRecordContent.Size = new System.Drawing.Size(714, 332);
			this.txtRecordContent.TabIndex = 135;
			this.txtRecordContent.Text = "";
			this.txtRecordContent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecordContent_KeyPress);
			// 
			// lblSignTitle
			// 
			this.lblSignTitle.ForeColor = System.Drawing.Color.White;
			this.lblSignTitle.Location = new System.Drawing.Point(552, 439);
			this.lblSignTitle.Name = "lblSignTitle";
			this.lblSignTitle.Size = new System.Drawing.Size(52, 20);
			this.lblSignTitle.TabIndex = 6011;
			this.lblSignTitle.Text = "签名:";
			// 
			// trvTime
			// 
			this.trvTime.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.trvTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.trvTime.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.trvTime.ForeColor = System.Drawing.SystemColors.Window;
			this.trvTime.ImageIndex = -1;
			this.trvTime.ItemHeight = 18;
			this.trvTime.Location = new System.Drawing.Point(4, 144);
			this.trvTime.Name = "trvTime";
			this.trvTime.SelectedImageIndex = -1;
			this.trvTime.ShowRootLines = false;
			this.trvTime.Size = new System.Drawing.Size(272, 612);
			this.trvTime.TabIndex = 111;
			// 
			// frmInputDemo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.AutoScroll = false;
			this.ClientSize = new System.Drawing.Size(952, 677);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.m_lsvBedNO,
																		  this.m_lsvPatientName,
																		  this.m_cboArea,
																		  this.m_txtBedNO,
																		  this.m_txtPatientName,
																		  this.m_lsvInPatientID,
																		  this.trvTime,
																		  this.pnlRecord,
																		  this.lblSex,
																		  this.lblAge,
																		  this.lblBedNoTitle,
																		  this.lblInHospitalNoTitle,
																		  this.lblNameTitle,
																		  this.lblSexTitle,
																		  this.lblAgeTitle,
																		  this.lblAreaTitle,
																		  this.txtInPatientID,
																		  this.m_lblForTitle});
			this.Name = "frmInputDemo";
			this.Text = "病案记录";
			this.Load += new System.EventHandler(this.frmInputDemo_Load);
			this.pnlRecord.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private string [] m_strLayer1Arr = new string[]{"消化系统","心血管系统","内分泌系统","血液淋巴系统","神经系统","泌尿生殖系统","呼吸系统","骨关节系统"};
		private string [] m_strLayer2Arr = new string[]{"心脏","主动脉","上腔静脉","下腔静脉","腹主动脉","股动脉"};
		private string [] m_strLayer3Arr = new string[]{"体征","疾病","检查"};
		private string [] m_strLayer4Arr = new string[]{"法洛四联症","房间隔缺损","风湿性心脏病","原发性心肌炎","室间隔缺损"};

		private enum enmShowType
		{
			Layer1,
			Layer2,
			Layer3,
			Layer4,
		}

		private enmShowType m_enmCurrentType = enmShowType.Layer4;

		private void txtRecordContent_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if(e.KeyChar != '.')
			{
				return;
			}

			Point pntPos;
			switch(m_enmCurrentType)
			{
				case enmShowType.Layer4:
					int intIndex = txtRecordContent.Text.LastIndexOf(' ');
					if(intIndex < 0)
						return;

					pntPos = txtRecordContent.GetPositionFromCharIndex(txtRecordContent.SelectionStart);
					pntPos.Offset(txtRecordContent.Location.X+2,txtRecordContent.Location.Y+2);

					UpdateLocation(pntPos,txtRecordContent);

					m_lstShow.Items.Clear();
					m_lstShow.Items.AddRange(m_strLayer1Arr);

					m_lstShow.Location = pntPos;
					m_lstShow.Visible = true;
					m_enmCurrentType = enmShowType.Layer1;
					break;
				case enmShowType.Layer1:
					pntPos = txtRecordContent.GetPositionFromCharIndex(txtRecordContent.TextLength);
					pntPos.Offset(txtRecordContent.Location.X+2,txtRecordContent.Location.Y+2);

					UpdateLocation(pntPos,txtRecordContent);

					m_lstShow.Items.Clear();
					m_lstShow.Items.AddRange(m_strLayer2Arr);

					m_lstShow.Location = pntPos;
					m_lstShow.Visible = true;
					m_enmCurrentType = enmShowType.Layer2;
					break;
				case enmShowType.Layer2:
					pntPos = txtRecordContent.GetPositionFromCharIndex(txtRecordContent.TextLength);
					pntPos.Offset(txtRecordContent.Location.X+2,txtRecordContent.Location.Y+2);

					UpdateLocation(pntPos,txtRecordContent);

					m_lstShow.Items.Clear();
					m_lstShow.Items.AddRange(m_strLayer3Arr);

					m_lstShow.Location = pntPos;
					m_lstShow.Visible = true;
					m_enmCurrentType = enmShowType.Layer3;
					break;
			}
		}

		private void UpdateLocation(Point p_pntPos,Control p_ctlControl)
		{
			Control ctlParent = p_ctlControl.Parent;

			if(ctlParent != null)
			{
				p_pntPos.Offset(ctlParent.Location.X,ctlParent.Location.Y);
				UpdateLocation(p_pntPos,ctlParent);
			}			
		}

		private void frmInputDemo_Load(object sender, System.EventArgs e)
		{
			m_lsvInPatientID.Visible = false;

			trvTime.Focus();
		}

		private void m_lstShow_DoubleClick(object sender, System.EventArgs e)
		{
			string strValue = m_lstShow.SelectedItem.ToString();

			Point pntPos;
			switch(m_enmCurrentType)
			{
				case enmShowType.Layer1:
					int intIndex = txtRecordContent.Text.LastIndexOf(' ');					
					txtRecordContent.Text = txtRecordContent.Text.Substring(0,intIndex)+strValue;
					
					m_lstShow.Visible = false;

					txtRecordContent.Focus();
					txtRecordContent.SelectionStart = txtRecordContent.TextLength;
					break;
				case enmShowType.Layer2:
					txtRecordContent.Text = txtRecordContent.Text.Remove(txtRecordContent.Text.Length-1,1)+strValue;					
					m_lstShow.Visible = false;

					txtRecordContent.Focus();
					txtRecordContent.SelectionStart = txtRecordContent.TextLength;
					break;
				case enmShowType.Layer3:
					pntPos = txtRecordContent.GetPositionFromCharIndex(txtRecordContent.TextLength);
					pntPos.Offset(txtRecordContent.Location.X+2,txtRecordContent.Location.Y+2);

					UpdateLocation(pntPos,txtRecordContent);

					m_lstShow.Items.Clear();
					m_lstShow.Items.AddRange(m_strLayer4Arr);

					m_lstShow.Location = pntPos;
					m_enmCurrentType = enmShowType.Layer4;
					break;
				case enmShowType.Layer4:
					txtRecordContent.Text = txtRecordContent.Text.Remove(txtRecordContent.Text.Length-1,1)+strValue;
					
					m_lstShow.Visible = false;

					txtRecordContent.Focus();
					txtRecordContent.SelectionStart = txtRecordContent.TextLength;
					break;
			}
		}

		protected override long m_lngSubAddNew()
		{
			return 0;
		}

		protected override long m_lngSubDelete()
		{
			return 0;
		}

		protected override long m_lngSubModify()
		{
			return 0;
		}

		protected override long m_lngSubPrint()
		{
			return 0;
		}

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
		
		}

		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return true;
			}
		}

		protected override bool m_BlnIsAddNew
		{
			get
			{
				return true;
			}
		}

		protected override iCare.enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser;
			}
		}
	}
}

