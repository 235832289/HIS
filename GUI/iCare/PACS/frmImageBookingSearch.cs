using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using com.digitalwave.Utility.Controls;
using iCareData ;
using System.Windows.Forms;


namespace iCare
{
	public class frmImageBookingSearch : iCare.frmHRPBaseForm
	{
		private System.Windows.Forms.Label lblCheckRecord;
		private System.Windows.Forms.Label lblApplicationID;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtApplicationID;
		private System.Windows.Forms.Label lblBookingInfo;
		private System.Windows.Forms.Label lblBookingReplyDate;
		private com.digitalwave.Utility.Controls.ctlTimePicker dtpBookingReplyDate;
		protected com.digitalwave.Utility.Controls.ctlBorderTextBox txtBookingInfo;
		protected System.Windows.Forms.ListView lsvApplicationID;
		private System.Windows.Forms.ColumnHeader clmPatientName_BaseForm;
		private System.Windows.Forms.ListView lsvCheckRecord;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
        private Panel panel1;
		private System.ComponentModel.IContainer components = null;


		public frmImageBookingSearch()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.lsvCheckRecord});
		
		}

        //private clsBorderTool m_objBorderTool;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmImageBookingSearch));
            this.lblCheckRecord = new System.Windows.Forms.Label();
            this.lblBookingInfo = new System.Windows.Forms.Label();
            this.lblBookingReplyDate = new System.Windows.Forms.Label();
            this.dtpBookingReplyDate = new com.digitalwave.Utility.Controls.ctlTimePicker();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.txtApplicationID = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.txtBookingInfo = new com.digitalwave.Utility.Controls.ctlBorderTextBox();
            this.lsvApplicationID = new System.Windows.Forms.ListView();
            this.clmPatientName_BaseForm = new System.Windows.Forms.ColumnHeader();
            this.lsvCheckRecord = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_pnlNewBase.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(236, 201);
            this.lblSex.TabIndex = 4;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(219, 204);
            this.lblAge.Size = new System.Drawing.Size(56, 22);
            this.lblAge.TabIndex = 5;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(242, 200);
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(228, 200);
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(281, 203);
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(290, 191);
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(255, 206);
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(224, 226);
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(227, 184);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(108, 108);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(245, 200);
            this.txtInPatientID.Size = new System.Drawing.Size(108, 23);
            this.txtInPatientID.TabIndex = 2;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(262, 197);
            this.m_txtPatientName.Size = new System.Drawing.Size(96, 23);
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(231, 191);
            this.m_txtBedNO.Size = new System.Drawing.Size(84, 23);
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(164, 217);
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(231, 178);
            this.m_lsvPatientName.Size = new System.Drawing.Size(92, 114);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(231, 184);
            this.m_lsvBedNO.Size = new System.Drawing.Size(104, 104);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(203, 217);
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(214, 200);
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(258, 212);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(273, 223);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(243, 217);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(271, 194);
            this.m_lblForTitle.Text = "影像预约查询";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(621, 43);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(725, 37);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Controls.Add(this.txtApplicationID);
            this.m_pnlNewBase.Controls.Add(this.lblApplicationID);
            this.m_pnlNewBase.Location = new System.Drawing.Point(6, 8);
            this.m_pnlNewBase.Size = new System.Drawing.Size(794, 60);
            this.m_pnlNewBase.Visible = true;
            this.m_pnlNewBase.Controls.SetChildIndex(this.m_ctlPatientInfo, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.lblApplicationID, 0);
            this.m_pnlNewBase.Controls.SetChildIndex(this.txtApplicationID, 0);
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(792, 29);
            // 
            // lblCheckRecord
            // 
            this.lblCheckRecord.AllowDrop = true;
            this.lblCheckRecord.AutoSize = true;
            this.lblCheckRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblCheckRecord.ForeColor = System.Drawing.Color.Black;
            this.lblCheckRecord.Location = new System.Drawing.Point(3, 8);
            this.lblCheckRecord.Name = "lblCheckRecord";
            this.lblCheckRecord.Size = new System.Drawing.Size(70, 14);
            this.lblCheckRecord.TabIndex = 10000006;
            this.lblCheckRecord.Text = "申请记录:";
            // 
            // lblBookingInfo
            // 
            this.lblBookingInfo.AllowDrop = true;
            this.lblBookingInfo.AutoSize = true;
            this.lblBookingInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBookingInfo.ForeColor = System.Drawing.Color.Black;
            this.lblBookingInfo.Location = new System.Drawing.Point(6, 172);
            this.lblBookingInfo.Name = "lblBookingInfo";
            this.lblBookingInfo.Size = new System.Drawing.Size(70, 14);
            this.lblBookingInfo.TabIndex = 10000007;
            this.lblBookingInfo.Text = "预约信息:";
            // 
            // lblBookingReplyDate
            // 
            this.lblBookingReplyDate.AutoSize = true;
            this.lblBookingReplyDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblBookingReplyDate.Location = new System.Drawing.Point(432, 500);
            this.lblBookingReplyDate.Name = "lblBookingReplyDate";
            this.lblBookingReplyDate.Size = new System.Drawing.Size(112, 16);
            this.lblBookingReplyDate.TabIndex = 10000012;
            this.lblBookingReplyDate.Text = "预约答复日期:";
            this.lblBookingReplyDate.Visible = false;
            // 
            // dtpBookingReplyDate
            // 
            this.dtpBookingReplyDate.BorderColor = System.Drawing.Color.Black;
            this.dtpBookingReplyDate.CustomFormat = "yyyy年MM月dd日 HH:mm:ss";
            this.dtpBookingReplyDate.DropButtonBackColor = System.Drawing.Color.Gainsboro;
            this.dtpBookingReplyDate.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.dtpBookingReplyDate.DropButtonForeColor = System.Drawing.Color.Black;
            this.dtpBookingReplyDate.flatFont = new System.Drawing.Font("宋体", 12F);
            this.dtpBookingReplyDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtpBookingReplyDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBookingReplyDate.Location = new System.Drawing.Point(544, 500);
            this.dtpBookingReplyDate.m_BlnOnlyTime = false;
            this.dtpBookingReplyDate.m_EnmVisibleFlag = com.digitalwave.Utility.Controls.ctlTimePicker.enmDateTimeFlag.Second;
            this.dtpBookingReplyDate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpBookingReplyDate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpBookingReplyDate.Name = "dtpBookingReplyDate";
            this.dtpBookingReplyDate.ReadOnly = true;
            this.dtpBookingReplyDate.Size = new System.Drawing.Size(212, 22);
            this.dtpBookingReplyDate.TabIndex = 9;
            this.dtpBookingReplyDate.TextBackColor = System.Drawing.Color.White;
            this.dtpBookingReplyDate.TextForeColor = System.Drawing.Color.Black;
            this.dtpBookingReplyDate.Visible = false;
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AllowDrop = true;
            this.lblApplicationID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblApplicationID.ForeColor = System.Drawing.Color.Black;
            this.lblApplicationID.Location = new System.Drawing.Point(326, 31);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(70, 27);
            this.lblApplicationID.TabIndex = 10000017;
            this.lblApplicationID.Text = "申请单号:";
            this.lblApplicationID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtApplicationID
            // 
            this.txtApplicationID.AccessibleDescription = "检查费";
            this.txtApplicationID.BackColor = System.Drawing.Color.White;
            this.txtApplicationID.BorderColor = System.Drawing.Color.Transparent;
            this.txtApplicationID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtApplicationID.ForeColor = System.Drawing.Color.Black;
            this.txtApplicationID.Location = new System.Drawing.Point(399, 31);
            this.txtApplicationID.Name = "txtApplicationID";
            this.txtApplicationID.Size = new System.Drawing.Size(200, 23);
            this.txtApplicationID.TabIndex = 6;
            this.txtApplicationID.Leave += new System.EventHandler(this.txtApplicationID_Leave);
            this.txtApplicationID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtApplicationID_KeyDown);
            // 
            // txtBookingInfo
            // 
            this.txtBookingInfo.AccessibleDescription = "检查费";
            this.txtBookingInfo.BackColor = System.Drawing.Color.White;
            this.txtBookingInfo.BorderColor = System.Drawing.Color.Transparent;
            this.txtBookingInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBookingInfo.ForeColor = System.Drawing.Color.Black;
            this.txtBookingInfo.Location = new System.Drawing.Point(6, 192);
            this.txtBookingInfo.Multiline = true;
            this.txtBookingInfo.Name = "txtBookingInfo";
            this.txtBookingInfo.ReadOnly = true;
            this.txtBookingInfo.Size = new System.Drawing.Size(756, 296);
            this.txtBookingInfo.TabIndex = 8;
            // 
            // lsvApplicationID
            // 
            this.lsvApplicationID.BackColor = System.Drawing.Color.White;
            this.lsvApplicationID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lsvApplicationID.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clmPatientName_BaseForm});
            this.lsvApplicationID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvApplicationID.ForeColor = System.Drawing.Color.Black;
            this.lsvApplicationID.FullRowSelect = true;
            this.lsvApplicationID.GridLines = true;
            this.lsvApplicationID.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lsvApplicationID.Location = new System.Drawing.Point(406, 65);
            this.lsvApplicationID.Name = "lsvApplicationID";
            this.lsvApplicationID.Size = new System.Drawing.Size(200, 128);
            this.lsvApplicationID.TabIndex = 10000019;
            this.lsvApplicationID.UseCompatibleStateImageBehavior = false;
            this.lsvApplicationID.View = System.Windows.Forms.View.Details;
            this.lsvApplicationID.Visible = false;
            this.lsvApplicationID.DoubleClick += new System.EventHandler(this.lsvApplicationID_DoubleClick);
            this.lsvApplicationID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lsvApplicationID_KeyDown);
            this.lsvApplicationID.Leave += new System.EventHandler(this.lsvApplicationID_Leave);
            // 
            // clmPatientName_BaseForm
            // 
            this.clmPatientName_BaseForm.Text = "";
            this.clmPatientName_BaseForm.Width = 120;
            // 
            // lsvCheckRecord
            // 
            this.lsvCheckRecord.BackColor = System.Drawing.Color.White;
            this.lsvCheckRecord.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lsvCheckRecord.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lsvCheckRecord.ForeColor = System.Drawing.Color.Black;
            this.lsvCheckRecord.FullRowSelect = true;
            this.lsvCheckRecord.GridLines = true;
            this.lsvCheckRecord.HideSelection = false;
            this.lsvCheckRecord.Location = new System.Drawing.Point(6, 27);
            this.lsvCheckRecord.MultiSelect = false;
            this.lsvCheckRecord.Name = "lsvCheckRecord";
            this.lsvCheckRecord.Size = new System.Drawing.Size(756, 140);
            this.lsvCheckRecord.TabIndex = 7;
            this.lsvCheckRecord.UseCompatibleStateImageBehavior = false;
            this.lsvCheckRecord.View = System.Windows.Forms.View.Details;
            this.lsvCheckRecord.SelectedIndexChanged += new System.EventHandler(this.lsvCheckRecord_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "申请日期";
            this.columnHeader1.Width = 165;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "类型";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "预约";
            this.columnHeader3.Width = 65;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 1;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCheckRecord);
            this.panel1.Controls.Add(this.lsvCheckRecord);
            this.panel1.Controls.Add(this.lblBookingInfo);
            this.panel1.Controls.Add(this.txtBookingInfo);
            this.panel1.Controls.Add(this.lblBookingReplyDate);
            this.panel1.Controls.Add(this.dtpBookingReplyDate);
            this.panel1.Location = new System.Drawing.Point(6, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 535);
            this.panel1.TabIndex = 10000020;
            // 
            // frmImageBookingSearch
            // 
            this.ClientSize = new System.Drawing.Size(812, 615);
            this.Controls.Add(this.lsvApplicationID);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmImageBookingSearch";
            this.Text = "影像预约查询";
            this.Load += new System.EventHandler(this.frmImageBookingSearch_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.lsvApplicationID, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.m_pnlNewBase.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		//Member Define
		private clsPatient m_objSelectedPatient=null;
		private string m_strInPatientID;

		private string m_strInPatientDate;

		private ImageBooking[] m_ImageBookingArr;

		private clsImageReportDomain mImageReportDomain=new clsImageReportDomain();

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{

			try
			{
				ListViewItem lviNewItem;

				m_objSelectedPatient=p_objSelectedPatient;

				m_strInPatientID = p_objSelectedPatient.m_StrInPatientID;
				m_strInPatientDate = p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
				
				//先清除控件中的现有数据。
				InitControls();
				this.lsvCheckRecord.Items.Clear();
				this.lsvApplicationID.Items.Clear();

				//获取病人的检查记录
				//加载当前病人的申请记录
				mImageReportDomain.m_lngGetImageBookingByPatientID(m_strInPatientID,out m_ImageBookingArr);
				
				if (m_ImageBookingArr!=null)
				{
					foreach(ImageBooking m_ImageBooking in m_ImageBookingArr)
					{
						if(m_ImageBooking == null)
							continue;

//						//当数据库中申请日期为空时，界面中也显示为空。不显示成默认的日期
//						if(m_ImageBooking.m_dteRequestDateTime!=DateTime.MinValue )
//							lviNewItem = new ListViewItem(new string[]{m_ImageBooking.m_dteRequestDateTime.ToString(),
//																	  m_ImageBooking.m_strCheckType,m_ImageBooking.HasBooking,
//																	  m_ImageBooking.m_strApplicationID});
//						else
//							lviNewItem = new ListViewItem(new string[]{"",
//																	  m_ImageBooking.m_strCheckType,m_ImageBooking.HasBooking,
//																	  m_ImageBooking.m_strApplicationID});
						if(m_ImageBooking.m_dteRequestDateTime!=DateTime.MinValue )
						{
							string[] m_strItem;
							m_strItem=new String[4];
							m_strItem[0]=m_ImageBooking.m_dteRequestDateTime.ToString("yyyy-MM-dd HH:mm:ss");
							switch(m_ImageBooking.m_strCheckType)
							{
								case "0":
									m_strItem[1]="DR";
									break;
								case "1":
									m_strItem[1]="CT";
									break;
								case "2":
									m_strItem[1]="B超";
									break;
								default:
									m_strItem[1]="未知类型";
									break;
							}
							m_strItem[2]=m_ImageBooking.HasBooking ;
							m_strItem[3]=m_ImageBooking.m_strApplicationID;

							lviNewItem = new ListViewItem(m_strItem);
						}
						else
							continue;
						
						this.lsvCheckRecord.Items.Add(lviNewItem);
						
						lviNewItem.Tag =m_ImageBooking;

						//
						lviNewItem = new ListViewItem(new string[]{m_ImageBooking.m_strApplicationID});
						this.lsvApplicationID.Items.Add(lviNewItem);
					
					}
				}

			}

			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			

		}
	
		private void InitControls()
		{
			this.dtpBookingReplyDate.Value=DateTime.Parse("1900-01-01");
			this.txtApplicationID.Text ="";
			this.txtBookingInfo.Text ="";
		}

		private void lsvCheckRecord_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				ImageBooking m_ImageBooking;
				if (this.lsvCheckRecord.SelectedItems.Count>0 && this.lsvCheckRecord.SelectedItems[0].Tag!=null)
				{
					m_ImageBooking=(ImageBooking)this.lsvCheckRecord.SelectedItems[0].Tag;
				
					//当无预约时，隐藏预约回复日期
					if (m_ImageBooking.HasBooking=="无")
                    {
						this.lblBookingReplyDate.Visible=false;
						this.dtpBookingReplyDate.Visible=false;
					}
					else
					{
						this.lblBookingReplyDate.Visible=true;
						this.dtpBookingReplyDate.Visible=true;
					}


					if (m_ImageBooking.m_dteBookingReplyDate==DateTime.MinValue)
					{
						this.dtpBookingReplyDate.Value=DateTime.Parse("1900-01-01");
						//this.dtpBookingReplyDate.Text="";
					}
					else
                        this.dtpBookingReplyDate.Value  =m_ImageBooking.m_dteBookingReplyDate ;

					this.txtApplicationID.Text =m_ImageBooking.m_strApplicationID;
					this.txtBookingInfo.Text =m_ImageBooking.m_strBookingInfo ;
		
				}
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void txtApplicationID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter				
					
					m_mthGetApplicationIDList_Pat_ID(txtApplicationID.Text);
			
					if(this.lsvApplicationID.Items.Count==1 && (txtApplicationID.Text==lsvApplicationID.Items[0].SubItems[0].Text))
					{
						lsvApplicationID.Items[0].Selected=true;
						lsvApplicationID_DoubleClick(null,null);
						break;
					}
					break;
				case 40://Arrow Down
				{
					this.lsvApplicationID.Focus();
					if(lsvApplicationID.Visible==true)
					{
						lsvApplicationID.Items[0].Selected =true;
						lsvApplicationID.Items[0].Focused  =true;
					}
					break;
				}
			}	
		}

		private void txtApplicationID_Leave(object sender, System.EventArgs e)
		{
			if(!lsvApplicationID.Focused)
				lsvApplicationID.Visible = false;
		}

		/// <summary>
		/// 显示检验号列表，这里的BarCode相当于检验号Pat_ID
		/// </summary>
		/// <param name="p_strDoctorNameLike">检验号</param>
		private void m_mthGetApplicationIDList_Pat_ID(string p_strApplicationIDLike)
		{
	
			if(p_strApplicationIDLike.Length == 0)
			{
				lsvApplicationID.Visible = false;
				return;
			}

			string[] strApplicationIDArr; 
			mImageReportDomain.m_lngGetImageBookingList(txtApplicationID.Text ,m_ImageBookingArr, out strApplicationIDArr);

			if(strApplicationIDArr == null)
			{
				lsvApplicationID.Visible = false;
				return;
			}

			lsvApplicationID.Items.Clear();

			for(int i=0;i<strApplicationIDArr.Length;i++)
			{
				ListViewItem lviApplicationID = new ListViewItem(
					new string[]{
									strApplicationIDArr[i]
								});
				lviApplicationID.Tag = strApplicationIDArr[i];

				lsvApplicationID.Items.Add(lviApplicationID);
			}

			lsvApplicationID.BringToFront();
			lsvApplicationID.Visible = true;
		}

		private void lsvApplicationID_DoubleClick(object sender, System.EventArgs e)
		{
			try
			{		
				ImageBooking mTempImageBooking;
				bool m_bnlSearched=false;

				////////////////////////////

				if(lsvApplicationID.SelectedItems.Count <= 0)
					return;

				txtApplicationID.Text = lsvApplicationID.SelectedItems[0].SubItems[0].Text;

				lsvApplicationID.Visible = false;

				foreach(ListViewItem lviCheckRecord in lsvCheckRecord.Items)
				{
					mTempImageBooking=(ImageBooking)lviCheckRecord.Tag;

					if (mTempImageBooking!=null && mTempImageBooking.m_strApplicationID==txtApplicationID.Text)
					{
						this.lsvCheckRecord.Focus();
						lviCheckRecord.Selected=true;
						this.lsvCheckRecord_SelectedIndexChanged(lsvCheckRecord,new System.EventArgs());
						m_bnlSearched=true;
						break;
					}

				}

				if (m_bnlSearched==false)
				{
					MessageBox.Show("对不起，没有找到与这个申请单号相关的数据。");
				}
			}
			catch(System.Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
		}

		private void lsvApplicationID_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyValue)
			{
				case 13:// enter				
				{			
					lsvApplicationID_DoubleClick(null,null);						
					break;
				}
				
			}	
		}

		private void lsvApplicationID_Leave(object sender, System.EventArgs e)
		{
			this.lsvApplicationID.Visible=false;
		}

		private void frmImageBookingSearch_Load(object sender, System.EventArgs e)
		{
			lsvCheckRecord.Focus();
		}

		/// <summary>
		/// 不需要保存提示
		/// </summary>
		protected override void m_mthAddFormStatusForClosingSave()
		{
		}
	}
}

