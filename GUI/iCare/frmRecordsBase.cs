//#define FunctionPrivilege
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using iCareData;
using System.Windows.Forms;
using com.digitalwave.controls;
using System.Drawing.Printing;
using System.Data;
using PrivilegeData;
using System.Drawing.Drawing2D;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.emr.AssistModuleVO;
namespace iCare
{
	public class frmRecordsBase : frmHRPBaseForm,PublicFunction
	{
        protected com.digitalwave.Controls.ctlDataGrid m_dtgRecordDetail;
		protected System.Windows.Forms.ContextMenu ctmRecordControl;
		protected System.Windows.Forms.MenuItem mniAppend;
		private System.Windows.Forms.MenuItem mniEdit;
		private System.Windows.Forms.MenuItem mniDelete;
		protected System.Windows.Forms.DataGridTableStyle dgtsStyles;
		protected System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
		protected System.Windows.Forms.TreeView m_trvInPatientDate;
		private System.Windows.Forms.MenuItem mniApprove;
		private System.Windows.Forms.MenuItem mniUnApprove;
		protected System.Windows.Forms.MenuItem m_mniAddBlank;
		protected System.Windows.Forms.MenuItem m_mniDeleteBlank;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  病程记录中特殊记录单的基窗体。
		/// 在此窗体处理保存、修改、删除、作废重做、保留痕迹、双划线功能清空界面的通用逻辑。
		/// 设置病程信息和获取病程信息的通用逻辑。
		/// 打印功能，读取已经删除的记录。
		/// Alex 2003-5-10
		/// </summary>
		public frmRecordsBase()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();
			m_trvInPatientDate.HideSelection=false;
			// TODO: Add any initialization after the InitializeComponent call
			m_objCurrentPatient = null;

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{m_dtgRecordDetail,m_trvInPatientDate});

			m_objRecordsDomain = m_objGetRecordsDomain();	
		
			m_dtbRecords = new DataTable("RecordDetail");	
			
			m_objPublicDomain = new clsPublicDomain();

			this.m_dtgRecordDetail.HeaderFont = m_FntHeaderFont;
			m_BlnNeedContextMenu = false;

	
		}

		/// <summary>
		/// 获取服务器时间的公共的Domain
		/// </summary>
		private clsPublicDomain m_objPublicDomain;
		/// <summary>
		///  病程记录的领域层实例
		/// </summary>
		protected clsRecordsDomain m_objRecordsDomain;
		/// <summary>
		/// 当前病人
		/// </summary>
		protected clsPatient m_objCurrentPatient;
		/// <summary>
		/// 改变控件边框工具
		/// </summary>
        //protected clsBorderTool m_objBorderTool;

		/// <summary>
		/// 打印报表的内容文档
		/// </summary>

		protected bool m_blnAlreadySetPrintTools = false;
		/// <summary>
		/// 记录集表格
		/// </summary>
		protected DataTable m_dtbRecords;
		/// <summary>
		/// 第一次打印数组
		/// </summary>
		private DateTime[] m_dtmFirstPrintDateArr;
		/// <summary>
		/// 是否第一次打印数组
		/// </summary>
		private bool[] m_blnIsFirstPrintArr;
		/// <summary>
		/// 
		/// </summary>
		private clsTransDataInfo[] m_objTransDataArr;

		/// <summary>
		/// 用于添加记录时暂时存放数据所用
		/// </summary>
		private DataTable m_dtbTempTable;
		/// <summary>
		/// 文字栏字体(虚函数)
		/// </summary>
		protected virtual Font m_FntHeaderFont
		{
			get
			{
				return new System.Drawing.Font("SimSun", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			}
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
			if(m_blnAlreadySetPrintTools)//释放打印变量
			{
				m_mthDisposePrintTools();
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
            this.m_dtgRecordDetail = new com.digitalwave.Controls.ctlDataGrid();
			this.dgtsStyles = new System.Windows.Forms.DataGridTableStyle();
			this.ctmRecordControl = new System.Windows.Forms.ContextMenu();
			this.mniAppend = new System.Windows.Forms.MenuItem();
			this.mniEdit = new System.Windows.Forms.MenuItem();
			this.mniDelete = new System.Windows.Forms.MenuItem();
			this.mniApprove = new System.Windows.Forms.MenuItem();
			this.mniUnApprove = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.m_mniAddBlank = new System.Windows.Forms.MenuItem();
			this.m_mniDeleteBlank = new System.Windows.Forms.MenuItem();
			this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
			this.m_trvInPatientDate = new System.Windows.Forms.TreeView();
			((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
			this.SuspendLayout();
			// 
			// lblSex
			// 
			this.lblSex.Location = new System.Drawing.Point(640, 96);
			this.lblSex.Name = "lblSex";
			// 
			// lblAge
			// 
			this.lblAge.Location = new System.Drawing.Point(752, 96);
			this.lblAge.Name = "lblAge";
			// 
			// lblBedNoTitle
			// 
			this.lblBedNoTitle.Location = new System.Drawing.Point(288, 96);
			this.lblBedNoTitle.Name = "lblBedNoTitle";
            // 
			// lblInHospitalNoTitle
			// 
			this.lblInHospitalNoTitle.Location = new System.Drawing.Point(812, 96);
			this.lblInHospitalNoTitle.Name = "lblInHospitalNoTitle";
			// 
			// lblNameTitle
			// 
			this.lblNameTitle.Location = new System.Drawing.Point(428, 96);
			this.lblNameTitle.Name = "lblNameTitle";
			// 
			// lblSexTitle
			// 
			this.lblSexTitle.Location = new System.Drawing.Point(588, 96);
			this.lblSexTitle.Name = "lblSexTitle";
			// 
			// lblAgeTitle
			// 
			this.lblAgeTitle.Location = new System.Drawing.Point(696, 96);
			this.lblAgeTitle.Name = "lblAgeTitle";
			// 
			// lblAreaTitle
			// 
			this.lblAreaTitle.Location = new System.Drawing.Point(40, 112);
			this.lblAreaTitle.Name = "lblAreaTitle";
			// 
			// m_lsvInPatientID
			// 
			this.m_lsvInPatientID.Location = new System.Drawing.Point(880, 116);
			this.m_lsvInPatientID.Name = "m_lsvInPatientID";
			// 
			// txtInPatientID
			// 
			this.txtInPatientID.Location = new System.Drawing.Point(880, 92);
			this.txtInPatientID.Name = "txtInPatientID";
			// 
			// m_txtPatientName
			// 
			this.m_txtPatientName.Location = new System.Drawing.Point(476, 92);
			this.m_txtPatientName.Name = "m_txtPatientName";
			// 
			// m_txtBedNO
			// 
			this.m_txtBedNO.Location = new System.Drawing.Point(336, 92);
			this.m_txtBedNO.Name = "m_txtBedNO";
			// 
			// m_cboArea
			// 
			this.m_cboArea.Location = new System.Drawing.Point(88, 108);
			this.m_cboArea.Name = "m_cboArea";
			// 
			// m_lsvPatientName
			// 
			this.m_lsvPatientName.Location = new System.Drawing.Point(476, 120);
			this.m_lsvPatientName.Name = "m_lsvPatientName";
			// 
			// m_lsvBedNO
			// 
			this.m_lsvBedNO.Location = new System.Drawing.Point(336, 120);
			this.m_lsvBedNO.Name = "m_lsvBedNO";
			// 
			// m_cboDept
			// 
			this.m_cboDept.Location = new System.Drawing.Point(88, 72);
			this.m_cboDept.Name = "m_cboDept";
			// 
			// lblDept
			// 
			this.lblDept.Location = new System.Drawing.Point(40, 80);
			this.lblDept.Name = "lblDept";
			// 
			// m_cmdNewTemplate
			// 
			this.m_cmdNewTemplate.Name = "m_cmdNewTemplate";
			// 
			// m_cmdNext
			// 
			this.m_cmdNext.Name = "m_cmdNext";
			// 
			// m_cmdPre
			// 
			this.m_cmdPre.Name = "m_cmdPre";
			// 
			// m_lblForTitle
			// 
			this.m_lblForTitle.Name = "m_lblForTitle";
			this.m_lblForTitle.Text = "读取多个记录类型的父类";
			this.m_lblForTitle.Visible = true;
			// 
			// m_dtgRecordDetail
			// 
			this.m_dtgRecordDetail.BackColor = System.Drawing.Color.White;
			this.m_dtgRecordDetail.BackgroundColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.Color.FromArgb(((System.Byte)(52)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_dtgRecordDetail.CaptionFont = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.m_dtgRecordDetail.CaptionText = "记录内容";
			this.m_dtgRecordDetail.CaptionVisible = false;
			this.m_dtgRecordDetail.DataMember = "";
			this.m_dtgRecordDetail.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtgRecordDetail.ForeColor = System.Drawing.Color.Black;
			this.m_dtgRecordDetail.HeaderFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_dtgRecordDetail.HeaderForeColor = System.Drawing.Color.Black;
			this.m_dtgRecordDetail.Location = new System.Drawing.Point(8, 140);
			this.m_dtgRecordDetail.Name = "m_dtgRecordDetail";
			this.m_dtgRecordDetail.ParentRowsForeColor = System.Drawing.Color.White;
			this.m_dtgRecordDetail.RowHeaderWidth = 1;
			this.m_dtgRecordDetail.Size = new System.Drawing.Size(992, 468);
			this.m_dtgRecordDetail.TabIndex = 5001;
			this.m_dtgRecordDetail.TableStyles.AddRange(new System.Windows.Forms.DataGridTableStyle[] {
																										  this.dgtsStyles});
			// 
			// dgtsStyles
			// 
			this.dgtsStyles.AllowSorting = false;
			this.dgtsStyles.DataGrid = this.m_dtgRecordDetail;
			this.dgtsStyles.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dgtsStyles.MappingName = "RecordDetail";
			this.dgtsStyles.ReadOnly = true;
			this.dgtsStyles.RowHeadersVisible = false;
			this.dgtsStyles.RowHeaderWidth = 1;
			// 
			// ctmRecordControl
			// 
			this.ctmRecordControl.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							 this.mniAppend,
																							 this.mniEdit,
																							 this.mniDelete,
																							 this.mniApprove,
																							 this.mniUnApprove,
																							 this.menuItem3,
																							 this.m_mniAddBlank,
																							 this.m_mniDeleteBlank});
			this.ctmRecordControl.Popup += new System.EventHandler(this.ctmRecordControl_Popup);
			// 
			// mniAppend
			// 
			this.mniAppend.Index = 0;
			this.mniAppend.Text = "添加记录";
			this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
			// 
			// mniEdit
			// 
			this.mniEdit.Index = 1;
			this.mniEdit.Text = "修改记录";
			this.mniEdit.Click += new System.EventHandler(this.mniEdit_Click);
			// 
			// mniDelete
			// 
			this.mniDelete.Index = 2;
			this.mniDelete.Text = "删除记录";
			this.mniDelete.Click += new System.EventHandler(this.mniDelete_Click);
			// 
			// mniApprove
			// 
			this.mniApprove.Index = 3;
			this.mniApprove.Text = "审  核";
			this.mniApprove.Click += new System.EventHandler(this.mniApprove_Click);
			// 
			// mniUnApprove
			// 
			this.mniUnApprove.Index = 4;
			this.mniUnApprove.Text = "退  审";
			this.mniUnApprove.Click += new System.EventHandler(this.mniUnApprove_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 5;
			this.menuItem3.Text = "-";
			// 
			// m_mniAddBlank
			// 
			this.m_mniAddBlank.Index = 6;
			this.m_mniAddBlank.Text = "添加空行";
			this.m_mniAddBlank.Click += new System.EventHandler(this.m_mniAddBlank_Click);
			// 
			// m_mniDeleteBlank
			// 
			this.m_mniDeleteBlank.Index = 7;
			this.m_mniDeleteBlank.Text = "删除空行";
			this.m_mniDeleteBlank.Click += new System.EventHandler(this.m_mniDeleteBlank_Click);
			// 
			// m_pdcPrintDocument
			// 
			this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
			this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
			this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);
			// 
			// m_trvInPatientDate
			// 
			this.m_trvInPatientDate.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(51)), ((System.Byte)(102)), ((System.Byte)(153)));
			this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.m_trvInPatientDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));
			this.m_trvInPatientDate.ForeColor = System.Drawing.SystemColors.Window;
			this.m_trvInPatientDate.HideSelection = false;
			this.m_trvInPatientDate.ImageIndex = -1;
			this.m_trvInPatientDate.Location = new System.Drawing.Point(60, 8);
			this.m_trvInPatientDate.Name = "m_trvInPatientDate";
			this.m_trvInPatientDate.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																						   new System.Windows.Forms.TreeNode("入院时间")});
			this.m_trvInPatientDate.SelectedImageIndex = -1;
			this.m_trvInPatientDate.ShowRootLines = false;
			this.m_trvInPatientDate.Size = new System.Drawing.Size(228, 60);
			this.m_trvInPatientDate.TabIndex = 5002;
			this.m_trvInPatientDate.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_trvInPatientDate_AfterSelect);
			// 
			// frmRecordsBase
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(7, 16);
			this.ClientSize = new System.Drawing.Size(1016, 653);
            this.Closing += new CancelEventHandler(frmRecordsBase_Closing);
			this.Controls.Add(this.m_trvInPatientDate);
			this.Controls.Add(this.m_dtgRecordDetail);
			this.Name = "frmRecordsBase";
			this.Text = "读取多个记录类型的父类";
			this.Load += new System.EventHandler(this.frmRecordsBase_Load);
			this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
			this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
			this.Controls.SetChildIndex(this.m_lblForTitle, 0);
			this.Controls.SetChildIndex(this.txtInPatientID, 0);
			this.Controls.SetChildIndex(this.lblAreaTitle, 0);
			this.Controls.SetChildIndex(this.lblAgeTitle, 0);
			this.Controls.SetChildIndex(this.lblSexTitle, 0);
			this.Controls.SetChildIndex(this.lblNameTitle, 0);
			this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
			this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
			this.Controls.SetChildIndex(this.lblAge, 0);
			this.Controls.SetChildIndex(this.lblSex, 0);
			this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
			this.Controls.SetChildIndex(this.m_txtPatientName, 0);
			this.Controls.SetChildIndex(this.m_txtBedNO, 0);
			this.Controls.SetChildIndex(this.m_cboArea, 0);
			this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
			this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
			this.Controls.SetChildIndex(this.lblDept, 0);
			this.Controls.SetChildIndex(this.m_cboDept, 0);
			this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
			this.Controls.SetChildIndex(this.m_cmdNext, 0);
			this.Controls.SetChildIndex(this.m_cmdPre, 0);
			((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
			this.ResumeLayout(false);

		}

        void frmRecordsBase_Closing(object sender, CancelEventArgs e)
        {
            if (m_frmCurrentSub != null)
            {
                m_frmCurrentSub.Close();
            }
        }
		#endregion

		#region ctlRichTextBox的双划线、其他属性设置	

		/// <summary>
		/// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
		/// </summary>
		/// <param name="p_objRichTextBox"></param>
		protected void m_mthSetRichTextBoxAttrib(ctlRichTextBox p_objRichTextBox)
		{			
			//设置其他属性			
			p_objRichTextBox.m_StrUserID = MDIParent.OperatorID;
			p_objRichTextBox.m_StrUserName = MDIParent.strOperatorName;
			p_objRichTextBox.m_ClrOldPartInsertText = Color.Black;
			p_objRichTextBox.m_ClrDST = Color.Red;
		}

		protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
		{
            if (p_ctlControl.GetType().FullName == "com.digitalwave.controls.ctlRichTextBox")
			{
				m_mthSetRichTextBoxAttrib((ctlRichTextBox)p_ctlControl);
			}

			if(p_ctlControl.HasChildren )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextBoxAttribInControl(subcontrol);						
				} 	
			}	
		}		
		#endregion ctlRichTextBox的双划线、其他属性设置

		protected void frmRecordsBase_Load(object sender, System.EventArgs e)
		{		
			frmLoadMethod();
		}
		protected virtual void frmLoadMethod()
		{
			m_mthInitDataTable(m_dtbRecords);
			m_dtgRecordDetail.DataSource = m_dtbRecords;
			m_mthSetRichTextBoxAttribInControl(this);
			m_mthSetQuickKeys();
		}

		#region OverRide Function

		protected override bool m_BlnCanTextChanged
		{
			get
			{
				return true;
			}
		}

		protected override enmFormState m_EnmCurrentFormState
		{
			get
			{
				return enmFormState.NowUser ;
			}
		}


		protected override long m_lngSubAddNew()
		{
			return (long)enmOperationResult.DB_Succeed;
		}
	
		protected override bool m_BlnIsAddNew
		{
			get
			{
				return false;
			}
		}
		
		protected override long m_lngSubModify()
		{
			return (long)enmOperationResult.DB_Succeed;
		}
		protected override long m_lngSubDelete()
		{
			return (long)enmOperationResult.DB_Succeed;
		}
		#endregion 

		/// <summary>
		///  清空界面
		/// </summary>
		protected void m_mthClearAll()
		{
			//清空病人基本信息
			m_mthClearPatientBaseInfo();
			//重置当前病人变量
			m_objCurrentPatient = null;
			//清空当前记录。
			m_mthClearPatientRecordInfo();

			m_trvInPatientDate.Nodes[0].Nodes.Clear();
		}

		/// <summary>
		///  清空病人记录所有信息。
		/// </summary>
		protected  virtual void m_mthClearPatientRecordInfo()
		{
			//清空DataGrid
			m_mthSetDataGridFirstRowFocus();

            if (m_dtgRecordDetail != null)
            {
                m_dtgRecordDetail.CurrentRowIndex = 0;
                m_dtbRecords.Rows.Clear();
            }
			//清空记录内容                       
			m_mthClearRecordInfo();
			
		}

		/// <summary>
		///  清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		protected virtual void m_mthClearRecordInfo()
		{
			//清空具体记录内容，由子窗体重载实现
		}

		/// <summary>
		/// 初始化具体表单的DataTable。
		/// 注意，DataTable的第一个Column必须是存放记录时间CreateDate的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate的字符串
		/// </summary>
		/// <param name="p_dtbRecordTable"></param>
		protected virtual void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{
			//由子窗体重载实现
		}

		/// <summary>
		///  设置病人表单信息
		/// </summary>
		/// <param name="p_objSelectedPatient"></param>
		protected override void m_mthSetPatientFormInfo(clsPatient p_objSelectedPatient)
		{
			try
			{
				//判断病人信息是否为null，如果是，直接返回。
				if(p_objSelectedPatient == null)
					return;   	
		
				//清空病人记录信息				
				m_mthClearPatientRecordInfo();

				//记录病人信息
				m_objCurrentPatient = p_objSelectedPatient;
		

                //m_trvInPatientDate.Nodes[0].Nodes.Clear();
                //TreeNode trnNewNode;
                //for(int i1=(p_objSelectedPatient.m_ObjInBedInfo.m_intGetSessionCount()-1);i1>=0;i1--)
                //{
                //    clsInBedSessionInfo objSession=p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(i1);
                //    //trnNewNode = new TreeNode(objSession.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"));
                //    trnNewNode = new TreeNode(objSession.m_DtmHISInDate.ToString("yyyy-MM-dd HH:mm:ss"));
                //    trnNewNode.Tag = objSession.m_DtmOutDate;//存放出院时间.
                //    m_trvInPatientDate.Nodes[0].Nodes.Add(trnNewNode);
                //}
                //m_trvInPatientDate.SelectedNode = null;
                ////选中默认节点
                //for(int i = 0; i < m_trvInPatientDate.Nodes[0].Nodes.Count; i++)
                //{
                //    if(m_trvInPatientDate.Nodes[0].Nodes[i].Text == p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"))
                //        m_trvInPatientDate.SelectedNode = m_trvInPatientDate.Nodes[0].Nodes[i];
                //}
                //if(m_trvInPatientDate.Nodes[0].Nodes.Count>0 && m_trvInPatientDate.SelectedNode == null)//本处需要此句调用默然选中树节点事件
                //    m_trvInPatientDate.SelectedNode=m_trvInPatientDate.Nodes[0].Nodes[0];



                //m_trvInPatientDate.ExpandAll();
				
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

        /// <summary>
        /// 仅设置病人的基本信息
        /// </summary>
        /// <param name="p_objSelectedPatient"></param>
        protected override void m_mthOnlySetPatientInfo(clsPatient p_objSelectedPatient)
        {
            //lblSex.Text = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_ObjPeopleInfo.m_StrSex;
            //lblAge.Text = p_objSelectedPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_ObjPeopleInfo.m_StrAge;

         }
        protected virtual void m_mthGetTransDataInfoArr( out clsTransDataInfo[] p_objTansDataInfoArr)
        {
            //string m_strInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrEMRInPatientID;
            //string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");
            p_objTansDataInfoArr = null;
            if (m_ObjCurrentEmrPatientSession == null)
            {
                return;
            }
           m_objRecordsDomain.m_lngGetTransDataInfoArr(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out p_objTansDataInfoArr);
           // m_objRecordsDomain.m_lngGetTransDataInfoArr(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, out p_objTansDataInfoArr);

        }
        #region 不用
        //茶山有摄入排出的护理表单用
        //protected virtual void m_mthGetTransDataInfoArr(string p_strFormID,out clsTransDataInfo[] p_objTansDataInfoArr)
        //{
        //    p_objTansDataInfoArr = null;
        //    if (m_ObjCurrentEmrPatientSession == null)
        //    {
        //        return;
        //    }
        //    m_objRecordsDomain.m_lngGetTransDataInfoArr(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"),p_strFormID, out p_objTansDataInfoArr);

        //}
        #endregion
        protected virtual void m_trvInPatientDate_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			try
			{
				//清空病人记录信息				
				m_mthClearPatientRecordInfo();

				if(m_trvInPatientDate.SelectedNode==null || m_trvInPatientDate.SelectedNode==m_trvInPatientDate.Nodes[0] || m_objCurrentPatient==null)
				{						
					return;
                }

                //设置病人当次住院的基本信息
                m_mthOnlySetPatientInfo(m_objCurrentPatient);
                m_objCurrentPatient.m_ObjPeopleInfo = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_ObjPeopleInfo;

                string m_strInPatientID = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrEMRInPatientID;
                string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");

                txtInPatientID.Text = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_StrHISInPatientID;
                m_objCurrentPatient.m_DtmSelectedInDate = DateTime.Parse(m_strInPatientDate);
                m_objCurrentPatient.m_StrHISInPatientID = txtInPatientID.Text;
                m_objCurrentPatient.m_DtmSelectedHISInDate = Convert.ToDateTime(m_trvInPatientDate.SelectedNode.Text);

                #region 获取病人当次入院登记号
                string strRegisterID = "";

                com.digitalwave.PatientManagerService.clsPatientManagerService objServ =
                    (com.digitalwave.PatientManagerService.clsPatientManagerService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.PatientManagerService.clsPatientManagerService));

                long lngRes = objServ.m_lngGetRegisterIDByPatient(m_objCurrentPatient.m_StrPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strRegisterID);
                if (!string.IsNullOrEmpty(strRegisterID))
                {
                    com.digitalwave.emr.BEDExplorer.frmHRPExplorer.objpCurrentPatient.m_strREGISTERID_CHR = strRegisterID;
                    m_objCurrentPatient.m_StrRegisterId = strRegisterID;
                    m_objBaseCurrentPatient.m_StrRegisterId = strRegisterID;
                } 
                #endregion

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

				//获取病人记录列表
				clsTransDataInfo[] objTansDataInfoArr;
                m_mthGetTransDataInfoArr(out objTansDataInfoArr);
                //long lngRes = m_objRecordsDomain.m_lngGetTransDataInfoArr(m_strInPatientID,m_strInPatientDate,out objTansDataInfoArr);

				if(objTansDataInfoArr == null)
				{
					return;
				} 
		
				//按记录时间(CreateDate)排序
				//modified by  thfzhang 2005-11-12 危重护理不需要排序
				if (this.Name!="frmIntensiveTendMain_FC")
					m_mthSortTransData(ref objTansDataInfoArr);

				DataTable dtbAddBlank;
				clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
				objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate,out dtbAddBlank);

				//添加记录到的DataTable
				object [][] objDataArr;
				for(int i1=0;i1<objTansDataInfoArr.Length;i1++)
				{ 
					if(dtbAddBlank !=null && dtbAddBlank.Rows.Count>0)
					{
						//查找记录之前有否空行记录,有插入空行
						foreach(DataRow drtAdd in dtbAddBlank.Rows) 
						{
							if(objTansDataInfoArr[i1].m_objRecordContent !=null)
							{
								if(objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(drtAdd["opendate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))
									//							if(objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse( drtAdd[2].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))
								{
									object[] objBlank = new object[5];
									objBlank[1] = 100;
									objBlank[2] = drtAdd[2].ToString();
									m_dtbRecords.Rows.Add(objBlank);
									for(int k3 = 0; k3 < (Int32.Parse( drtAdd[3].ToString())-1); k3++)
									{
										m_dtbRecords.Rows.Add(new object[]{});
									}
									break;
								}
							}
						}
					}
					
					objDataArr = m_objGetRecordsValueArr(objTansDataInfoArr[i1]);
					
					if(objDataArr==null)
						continue;
//						return;
                    m_dtbRecords.BeginLoadData();
					for(int j2=0;j2<objDataArr.Length;j2++)
					{
                        //m_dtbRecords.Rows.Add(objDataArr[j2]);	
                        m_dtbRecords.LoadDataRow(objDataArr[j2], true);
					}
                    m_dtbRecords.EndLoadData();
                    m_dtgRecordDetail.EnsureVisible(m_dtbRecords.Rows.Count - 1);
                    Application.DoEvents();
				}
				//显示datagrid(危重护理记录)
//				DisplayDataToDatagrid(m_dtbRecords);

//				if(m_dtbRecords.Rows.Count > 0)//处理像病程记录那样只有一个column的情况 alex 2003-05-29
//				{
//					m_dtgRecordDetail.CurrentCell = new DataGridCell(1,0);
//					m_dtgRecordDetail.CurrentCell = new DataGridCell(0,0);
//				}		

				if(m_dtbRecords.Rows.Count == 0 && !m_blnIfNewDeletedRecord)
				{
					m_mthAutoAddNewRecord();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}
		}

		/// <summary>
		/// 按记录顺序(CreateDate)把输入的p_objTansDataInfoArr排序
		/// </summary>
		/// <param name="p_objTansDataInfoArr"></param>
		protected void m_mthSortTransData(ref clsTransDataInfo[] p_objTansDataInfoArr)
		{
			ArrayList m_arlSort = new ArrayList(p_objTansDataInfoArr);
			m_arlSort.Sort();
			p_objTansDataInfoArr = (clsTransDataInfo[])m_arlSort.ToArray(typeof(clsTransDataInfo));
		}

		/// <summary>
		/// 获取添加到DataTable的数据
		/// </summary>
		/// <param name="p_objTransDataInfoArr"></param>
		/// <returns></returns>
		protected virtual object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			//由子窗体重载
			return null;
		}

		/// <summary>
		/// 获取病程记录的领域层实例
		/// </summary>
		/// <returns></returns>
		protected virtual clsRecordsDomain m_objGetRecordsDomain()
		{
			//获取病程记录的领域层实例，由子窗体重载实现
			return null;
		}

//		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
//		{
//			m_mthPrintPage(e);
//		}
//
//		private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//		{
//			m_mthBeginPrint(e);
//		}
//
//		private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
//		{
//			m_mthEndPrint(e);
//		}

		#region 在外部测试本打印的演示实例.	

				
//				System.Drawing.Printing.PrintDocument m_pdcPrintDocument;
//				private void m_mthfrmLoad()
//				{	
//					if(m_pdcPrintDocument==null)
//						this.m_pdcPrintDocument = new System.Drawing.Printing.PrintDocument();
//					this.m_pdcPrintDocument.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_BeginPrint);
//					this.m_pdcPrintDocument.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.m_pdcPrintDocument_EndPrint);
//					this.m_pdcPrintDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.m_pdcPrintDocument_PrintPage);		
//				}
		private void m_pdcPrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{			
			objPrintTool.m_mthPrintPage(e);

			if(this.Name != "frmMainGeneralNurseRecord" && this.Name != "frmSubDiseaseTrack" && !m_blnDirectPrint)
			{
				if(ppdPrintPreview != null)
					while(!ppdPrintPreview.m_blnHandlePrint(e))
						objPrintTool.m_mthPrintPage(e);
			}
		}
		
				private void m_pdcPrintDocument_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
				{
					objPrintTool.m_mthBeginPrint(e);				
				}
		
				private void m_pdcPrintDocument_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
				{
					objPrintTool.m_mthEndPrint(e);
				}
		

				protected infPrintRecord objPrintTool;
				protected virtual infPrintRecord m_objGetPrintTool()
				{
					return null;
				}
				//clsIntensiveTendMainPrintTool objPrintTool;
                protected virtual void m_mthDemoPrint_FromDataSource()
				{	
					objPrintTool=m_objGetPrintTool();//new clsIntensiveTendMainPrintTool();
					if(objPrintTool==null)
					{
//						clsPublicFunction.ShowInformationMessageBox("请重载m_objGetPrintTool()函数！");
						return;
					}
					objPrintTool.m_mthInitPrintTool(null);
                    if (m_objBaseCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
                        objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, DateTime.MinValue, DateTime.MinValue);
                    else
                    {
                        m_objBaseCurrentPatient.m_StrHISInPatientID = m_ObjCurrentEmrPatientSession.m_strHISInpatientId;
                        m_objBaseCurrentPatient.m_DtmSelectedHISInDate = m_ObjCurrentEmrPatientSession.m_dtmHISInpatientDate;
                        objPrintTool.m_mthSetPrintInfo(m_objBaseCurrentPatient, m_objCurrentPatient.m_DtmSelectedInDate, DateTime.MinValue);
                    }
								
					objPrintTool.m_mthInitPrintContent();						
				
					m_mthStartPrint();
				}
				
//				private void m_mthStartPrint()
//				{			
//					//PrintPreviewDialog ppdPrintPreview = new PrintPreviewDialog();
//					ppdPrintPreview.Document = m_pdcPrintDocument;
//					ppdPrintPreview.ShowDialog();
//				}
				protected override long m_lngSubPrint()//代替原窗体中的同名打印函数
				{			
					m_mthDemoPrint_FromDataSource();
					return 1;
				}
		#endregion 在外部测试本打印的演示实例.
		/// <summary>
		///  打印
		/// </summary>
		/// <returns></returns>
		protected  long m_lngSubPrint1()
		{
            if (m_objRecordsDomain == new clsRecordsDomain(enmRecordsType.IntensiveTend))
			{
				
			}
			
			if(m_objCurrentPatient != null)
			{				
				
				string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
				string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");
				//获取最新内容和首次打印时间
				long lngRes = m_objRecordsDomain.m_lngGetPrintInfo(m_strInPatientID,m_strInPatientDate,out m_objTransDataArr,out m_dtmFirstPrintDateArr,out m_blnIsFirstPrintArr);
				if(lngRes <= 0)
					return lngRes;   
			
				//按记录时间(CreateDate)排序 
				m_mthSortTransData(ref m_objTransDataArr);
			
				//设置表单内容到打印中
				m_mthSetPrintContent(m_objTransDataArr,m_dtmFirstPrintDateArr);
		      
			}
			//如果没有设置过打印变量，设置打印变量        
			if(!m_blnAlreadySetPrintTools)
			{
				m_mthInitPrintTool();
				m_blnAlreadySetPrintTools = true;
			}                     
		
			//开始打印
			m_mthStartPrint();
		
			return 1;
		}

		/// <summary>
		///  设置打印内容。
		/// </summary>
		/// <param name="p_objTransDataArr"></param>
		/// <param name="p_dtmFirstPrintDate"></param>
		protected virtual void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
			DateTime[] p_dtmFirstPrintDateArr)
		{
			//缺省不做任何动作，子窗体重载以提供操作。
		}

		/// <summary>
		///  初始化打印变量
		/// </summary>
		protected virtual void m_mthInitPrintTool()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//初始化内容包括所有打印使用到的变量：字体、画笔、画刷、打印类等。
		}

		/// <summary>
		///  释放打印变量
		/// </summary>
		protected virtual void m_mthDisposePrintTools()
		{
			//缺省不做任何动作，子窗体重载以提供操作
			//释放内容包括打印使用到的字体、画笔、画刷等使用系统资源的变量。
		}

		/// <summary>
		///  开始打印。
		/// </summary>
		/// 
		private PrintTool.frmPrintPreviewDialog ppdPrintPreview = new PrintTool.frmPrintPreviewDialog();
		protected virtual void m_mthStartPrint()
		{
			//缺省使用打印预览，子窗体重载提供新的实现			
			if(m_blnDirectPrint)
			{
				clsContinuousPrintTool objConinuePrintTool = objPrintTool as clsContinuousPrintTool;
				if(objConinuePrintTool != null)
				{
					objConinuePrintTool.m_mthSetContinuePrint(m_objBaseCurrentPatient.m_StrInPatientID,m_trvInPatientDate.SelectedNode.Text);
					if(objConinuePrintTool.m_blnHavePrintAllRecords())
					{
						clsPublicFunction.ShowInformationMessageBox("上一次打印已打印完全部记录，如需重新打印，请按打印预览！");
						return;
					}
				}
				m_pdcPrintDocument.Print();
			}
			else
			{
				ppdPrintPreview.Document = m_pdcPrintDocument;
				ppdPrintPreview.ShowDialog();
			}
		}

		/// <summary>
		///  打印开始后，在打印页之前的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected void m_mthBeginPrint(PrintEventArgs p_objPrintArg)
		{
			m_mthBeginPrintSub(p_objPrintArg);
		}

		/// <summary>
		///  打印开始后，在打印页之前的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected virtual void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
			//缺省不做任何动作，子窗体重载以提供操作
		}

		/// <summary>
		///  打印页
		/// </summary>
		/// <param name="p_objPrintPageArg"></param>
		protected void m_mthPrintPage(PrintPageEventArgs p_objPrintPageArg)
		{
			m_mthPrintPageSub(p_objPrintPageArg);
		}

		/// <summary>
		///  打印页
		/// </summary>
		/// <param name="p_objPrintPageArg"></param>
		protected virtual void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
			//缺省不做任何动作，子窗体重载以提供操作
		}

		/// <summary>
		///  打印结束时的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected void m_mthEndPrint(PrintEventArgs p_objPrintArg)
		{
			if(m_objCurrentPatient==null) return;//added-Jacky-2003-6-4
			//如果打印成功，查找有无需要更新的时间，如果有，更新时间。 
			string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
			string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss");
			if(!p_objPrintArg.Cancel && m_blnIsFirstPrintArr != null)
			{
				ArrayList arlRecordType = new ArrayList();
				ArrayList arlOpenDate = new ArrayList();
				int intUpdateIndex = -1;//若没有任何记录
				for(int i=0;i<m_blnIsFirstPrintArr.Length;i++)
				{
					if(m_blnIsFirstPrintArr[i])
					{    
						//更新记录，只需使用新的首次打印时间作为有效的输入参数。
						//存放记录类型
						arlRecordType.Add(m_objTransDataArr[i].m_intFlag);
						//存放记录的OpenDate
						arlOpenDate.Add(m_objTransDataArr[i].m_objRecordContent.m_dtmOpenDate);			
						intUpdateIndex = i;
					}
				}   

				if(intUpdateIndex >= 0)
				{
					m_objRecordsDomain.m_lngUpdateFirstPrintDate(m_strInPatientID,m_strInPatientDate,(int[])arlRecordType.ToArray(typeof(int)),(DateTime[])arlOpenDate.ToArray(typeof(DateTime)),m_dtmFirstPrintDateArr[intUpdateIndex]);
				}
				m_objTransDataArr = null;		
				m_blnIsFirstPrintArr = null;
			}                          
			m_mthEndPrintSub(p_objPrintArg);
		}

		/// <summary>
		///  打印结束时的操作
		/// </summary>
		/// <param name="p_objPrintArg"></param>
		protected virtual void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
			//由子窗体重载以提供操作
		}

		/// <summary>
		/// 本方法为虚函数，默认继承本窗体的所有子窗体都执行本虚函数，
		/// 观察项目记录单等特殊窗体重载本方法，在其子窗体中自行实现。
		/// </summary>
		/// <param name="p_intRecordType"></param>
		protected virtual void m_mthAddNewRecord(int p_intRecordType)
		{			
			if(m_objCurrentPatient == null || m_ObjCurrentEmrPatientSession == null)
			{
				MDIParent.ShowInformationMessageBox("请先选择一个病人!");
				return;
			}
			if(!m_blnCanShowNewForm)
            {
                if (m_frmCurrentSub != null)
                {
                    m_frmCurrentSub.Activate();
                    m_frmCurrentSub.WindowState = FormWindowState.Normal;
                }
                return;
            } 

			//获取添加记录的窗体
			frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType);
            frmAddNewForm.m_blnIsAddNew = true;

			if(frmAddNewForm == null)
				return;

			//添加控制
			//有问题顺序 // modify by tfzhang at 2005-12-8 19:13
			//m_mthShowSubForm(frmAddNewForm,p_intRecordType,false);
			frmAddNewForm.m_mthSetDiseaseTrackInfoForAddNew(m_objCurrentPatient);

			m_mthShowSubForm(frmAddNewForm,p_intRecordType,false);

			MDIParent.s_ObjSaveCue.m_mthAddFormStatus(frmAddNewForm);
		}

		protected void m_mthShowSubForm(frmDiseaseTrackBase p_frmSubForm,int p_intRecordType,bool p_blnRemoveOld)
		{
			p_frmSubForm.Closed += new EventHandler(m_mthSubFormClosed);
            p_frmSubForm.MaximizeBox = true;
			m_intCurrentFormType = p_intRecordType;
			m_blnCurrentFormRemoveOld = p_blnRemoveOld;
			m_blnCanShowNewForm = false;
			m_frmCurrentSub = p_frmSubForm;
            //p_frmSubForm.TopMost = true;
            p_frmSubForm.Show(this);
            p_frmSubForm.Activate();
		}

        protected frmDiseaseTrackBase m_frmCurrentSub = null;
		public frmDiseaseTrackBase m_FrmCurrentSub
		{
			get
			{
				return m_frmCurrentSub;
			}
			set
			{
				m_frmCurrentSub = value;
			}
		}
		private int m_intCurrentFormType;
		private bool m_blnCurrentFormRemoveOld;
		protected bool m_blnCanShowNewForm = true;
		private void m_mthSubFormClosed(object p_objSender,EventArgs p_objArg)
		{
			frmDiseaseTrackBase frmAddNewForm = (frmDiseaseTrackBase)p_objSender; 
			//显示窗体
			if(frmAddNewForm.DialogResult == DialogResult.Yes)
			{
				m_mthHandleSubFormClosedWithYes(frmAddNewForm);
			}			

			m_blnCanShowNewForm = true;
			m_frmCurrentSub = null;
		}
		protected virtual void m_mthHandleSubFormClosedWithYes(frmDiseaseTrackBase p_frmSubForm)
		{
			//获取用户添加的内容
			clsDiseaseTrackInfo objTrackInfo = p_frmSubForm.m_objGetDiseaseTrackInfo();
			clsTransDataInfo objDataInfo = new clsTransDataInfo();
			objDataInfo.m_intFlag = m_intCurrentFormType;
			objDataInfo.m_objRecordContent = objTrackInfo.m_ObjRecordContent;
			
			//设置内容到DataTable
			object [][] objDataArr = m_objGetRecordsValueArr(objDataInfo);  

			if(m_blnCurrentFormRemoveOld)
			{
				//从DataTable删除内容
				m_mthRemoveDataFromDataTable(m_intCurrentFormType,objTrackInfo.m_ObjRecordContent.m_dtmOpenDate);
			}
			
			//添加内容到DataTable
			m_mthAddDataToDataTable(objDataArr,objTrackInfo.m_ObjRecordContent.m_dtmCreateDate);
				
		}

		/// <summary>
		///  获取用户选择的记录的开始行位置
		/// </summary>
		/// <param name="p_intSelectRowIndex">返回索引</param>
		/// <returns></returns>
		protected virtual int m_intGetRecordStartRow(int p_intSelectRowIndex)
		{
			//以p_intSelectRow开始，从后往前循环DataTable
			//如果当前记录的第一个字段不为空
			//返回索引
			for(int i1=p_intSelectRowIndex;i1>=0;i1--)
			{
				if(m_dtbRecords.Rows[i1][1].ToString() != "")
				{
					return i1;
				}
			}
			return -1;
		}

        /// <summary>
        ///  获取用户选择的记录的开始行位置  病程记录用
        /// </summary>
        /// <param name="p_intSelectRowIndex">返回索引</param>
        /// <returns></returns>
        protected virtual int m_intGetRecordStartRows(int p_intSelectRowIndex)
        {
            //以p_intSelectRow开始，从后往前循环DataTable
            //如果当前记录的第一个字段不为空
            //返回索引
            for (int i1 = p_intSelectRowIndex; i1 >= 0; i1--)
            {
                if (m_dtbRecords.Rows[i1][0].ToString() != "")
                {
                    return i1;
                }
            }
            return -1;
        }
		/// <summary>
		/// 本方法为虚函数，默认继承本窗体的所有子窗体都执行本虚函数，
		/// 观察项目记录单等特殊窗体重载本方法，在其子窗体中自行实现。
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
		protected virtual void m_mthModifyRecord(int p_intRecordType,
			DateTime p_dtmOpenRecordTime)
		{
            if (!m_blnCanShowNewForm)
            {
                if (m_frmCurrentSub != null)
                {
                    m_frmCurrentSub.Activate();
                    m_frmCurrentSub.WindowState = FormWindowState.Normal;
                }
                return;
            }

			//获取添加记录的窗体
			frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType);
            frmAddNewForm.m_blnIsAddNew = false;
			//检查当前用户是否有权修改记录内容
			if(!m_lngCanYouDoIt())
			{
				clsPublicFunction.ShowInformationMessageBox("该单已被上级审核过，您无权修改！");
				return;
			}
			//有问题顺序 // modify by tfzhang at 2005-12-8 19:13
			//m_mthShowSubForm(frmAddNewForm,p_intRecordType,true);

			frmAddNewForm.m_mthSetDiseaseTrackInfo(m_objCurrentPatient,p_dtmOpenRecordTime);
			m_mthShowSubForm(frmAddNewForm,p_intRecordType,true);
			
			
			MDIParent.s_ObjSaveCue.m_mthAddFormStatus(frmAddNewForm);
		}

		/// <summary>
		/// 本方法为虚函数，默认继承本窗体的所有子窗体都执行本虚函数，
		/// 观察项目记录单等特殊窗体重载本方法，在其子窗体中自行实现。
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
		protected virtual void m_mthGetDeletedRecord(int p_intRecordType,
			DateTime p_dtmCreateRecordTime)
		{
            if (!m_blnCanShowNewForm)
            {
                if (m_frmCurrentSub != null)
                {
                    //显示已删除记录，关闭原有窗口时不提示保存
                    m_frmCurrentSub.m_trvCreateDate.SelectedNode = m_frmCurrentSub.m_trvCreateDate.Nodes[0];
                    m_frmCurrentSub.Close();
                }
            }

			//获取添加记录的窗体
			frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(p_intRecordType); 

			if(frmAddNewForm == null)
				return;

			frmAddNewForm.m_mthSetDeletedDiseaseTrackInfo(m_objCurrentPatient,p_dtmCreateRecordTime);

            m_mthShowSubForm(frmAddNewForm, p_intRecordType, false);

            //MDIParent.s_ObjSaveCue.m_mthAddFormStatus(frmAddNewForm);
            MDIParent.s_ObjSaveCue.m_mthRemoveForm(frmAddNewForm);
            frmAddNewForm.TopMost = true;
		}


        //infPrintRecord objPrintTool;
        protected override void m_mthSubPreviewInactiveRecord(IWin32Window p_infOwner, clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            if (p_objSelectedValue != null)
            {
                using (frmDiseaseTrackBase frmPreForm = m_frmGetRecordForm(-1))
                {
                    if (frmPreForm == null)
                        return;

                    frmPreForm.m_mthSetDeletedDiseaseTrackInfo(m_objCurrentPatient, p_objSelectedValue.m_DtmOpenDate);
                    frmPreForm.m_mthSetReadOnly();
                    frmPreForm.ShowDialog(p_infOwner);
                }
            }
        }

       
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_objDataArr"></param>
		protected void m_mthDeleteRecord(int p_intRecordType,
			object[] p_objDataArr)
		{
			//获取主要内容
			clsTrackRecordContent objContent = m_objGetRecordMainContent(p_intRecordType,p_objDataArr);
			objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
            objContent.m_strRegisterID = m_objCurrentPatient.m_StrRegisterId;
			objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_strDeActivedOperatorID = MDIParent.OperatorID;
			objContent.m_dtmDeActivedDate = DateTime.Parse(m_objPublicDomain.m_strGetServerTime());

			//修改记录
			clsPreModifyInfo objModifyInfo=null;
			//设置删除内容
			long lngRes = m_objRecordsDomain.m_lngDeleteRecord(p_intRecordType,objContent,out objModifyInfo);
		
			//根据结果做不同的处理
			switch((enmOperationResult)lngRes)
			{
				case enmOperationResult.DB_Succeed:
                    clsEMR_CaseAuditVO objAuditVO = m_objGetAuditCase();
                    objAuditVO.m_dtmCREATEDATE = objContent.m_dtmOpenDate;
                    m_mthDelAuditCase(objAuditVO);

					//删除选中节点		
					m_mthRemoveDataFromDataTable(p_intRecordType,objContent.m_dtmOpenDate);   
					break;
				case enmOperationResult.DB_Fail:
					clsPublicFunction.ShowInformationMessageBox("对不起,修改失败!");
					break;
				case enmOperationResult.Parameter_Error:
					clsPublicFunction.ShowInformationMessageBox("参数错误!");
					break;
				case enmOperationResult.Record_Already_Modify:
					if(objModifyInfo !=null)
						m_bolShowRecordModified(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;	
				case enmOperationResult.Record_Already_Delete:
					if(objModifyInfo !=null)
						m_mthShowRecordDeleted(objModifyInfo.m_strActionUserID,objModifyInfo.m_dtmActionTime.ToString("yyyy-MM-dd HH:mm:ss"));
					else m_mthShowDBError();
					break;
				default:
					break;
			}
		}

		/// <summary>
		/// 添加数据到DataTable
		/// </summary>
		/// <param name="p_objDataArr"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
		protected void m_mthAddDataToDataTable(object[][] p_objDataArr,
			DateTime p_dtmCreateRecordTime)
		{
			//查找插入点
			//循环DataTable的记录，获取记录的日期（第一字段）
			//如果有记录日期
			//比较已有日期与p_dtmCreateDate
			//如果已有日期比p_dtmCreateDate大
			//在这行记录前添加记录（数组），返回
		
			//没有找到比p_dtmCreateDate大的日期，往DataTable后添加	
			if(p_objDataArr==null)
				return;

			int m_intInsertIndex = -1;
			string m_strRecordTime = null;
			DataRow m_dtrNewRow;
			for(int i1=0;i1<m_dtbRecords.Rows.Count;i1++)
			{
				if(m_dtbRecords.Rows[i1][0].ToString() != "")
				{
					m_strRecordTime = m_dtbRecords.Rows[i1][0].ToString();
					if(DateTime.Parse(m_strRecordTime) > p_dtmCreateRecordTime)
					{
						m_intInsertIndex = i1;
						break;
					}
				}
			}
			if(m_intInsertIndex < 0)//没有找到比p_dtmOpenRecordTime大的日期，往DataTable后添加		
			{
				for(int i1=0;i1<p_objDataArr.Length;i1++)
				{				
					//m_dtbRecords.Rows.Add(p_objDataArr[i1]);
                    m_dtrNewRow = m_dtbRecords.NewRow();
                    m_dtrNewRow.ItemArray = p_objDataArr[i1];
                    m_dtbRecords.Rows.Add(m_dtrNewRow);
				}
			}
			else//否则，将p_dtmCreateDate 之后的记录放到内存中,先添加新增的记录，然后把内存中的记录，再添加回去
			{
				if(m_dtbTempTable == null)
				{
					m_dtbTempTable = m_dtbRecords.Clone();
				}
				while((m_intInsertIndex < m_dtbRecords.Rows.Count))//将p_dtmCreateDate 之后的记录放到内存中
				{
					m_mthSetDataGridFirstRowFocus();
					m_dtrNewRow = m_dtbTempTable.NewRow();
					m_dtrNewRow.ItemArray = m_dtbRecords.Rows[m_intInsertIndex].ItemArray;
					m_dtbTempTable.Rows.Add(m_dtrNewRow);
					m_dtbRecords.Rows.RemoveAt(m_intInsertIndex);
				}
				for(int i1=0;i1<p_objDataArr.Length;i1++)//新增的记录
				{
					m_dtrNewRow = m_dtbRecords.NewRow();
					m_dtrNewRow.ItemArray = p_objDataArr[i1];
					m_dtbRecords.Rows.Add(m_dtrNewRow);
				}
				for(int i1=0;i1<m_dtbTempTable.Rows.Count;i1++)//把内存中的记录，再添加回去
				{
					m_dtrNewRow = m_dtbRecords.NewRow();
					m_dtrNewRow.ItemArray = m_dtbTempTable.Rows[i1].ItemArray;
					m_dtbRecords.Rows.Add(m_dtrNewRow);
				}
				if(m_dtbTempTable != null)
				{
					m_dtbTempTable.Rows.Clear();
				}
            }
            if (m_dtbRecords != null && m_dtbRecords.Rows.Count > 0)
            {
                m_dtgRecordDetail.EnsureVisible(m_dtbRecords.Rows.Count - 1);
            }
		}

		/// <summary>
		/// 本方法为虚函数，默认继承本窗体的所有子窗体都执行本虚函数，
		/// 观察项目记录单等特殊窗体重载本方法，在其子窗体中自行实现。
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_dtmCreateRecordTime"></param>
		protected virtual void m_mthRemoveDataFromDataTable(int p_intRecordType,
			DateTime p_dtmOpenDate)
		{
			//根据p_dtmCreateDate和p_intRecordType查找对应的记录
			int intDeleteIndex = -1;
			//循环DataTable的记录，获取记录的日期（第一字段）和记录类型（第二个字段）
			//如果有记录日期和记录类型
			//如果日期与p_dtmCreateDate相同，记录类型与p_intRecordType相同
			//intDeleteIndex = 下标;
			//跳出循环
			for(int i1=0;i1<m_dtbRecords.Rows.Count;i1++)
			{
				if(m_dtbRecords.Rows[i1][2].ToString() != "" && m_dtbRecords.Rows[i1][1].ToString() != "")
				{
					if(DateTime.Parse(m_dtbRecords.Rows[i1][2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == p_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") && (int)m_dtbRecords.Rows[i1][1] == p_intRecordType)
					{
						intDeleteIndex = i1;
						break;
					}
				}
			}

			if(intDeleteIndex >= 0)
			{ 
				//根据intDeleteIndex循环删除记录
				//删除intDeleteIndex行
				
				//如果intDeleteIndex没有超出DataTable范围
				//获取记录，查看有无记录的日期
				//如果有，说明记录已经删除完毕，返回
						
				//如果无，继续删除行
				//intDeleteIndex超出范围(>=DataTable.Rows.Count)，返回

				m_mthSetDataGridFirstRowFocus();

				m_dtbRecords.Rows.RemoveAt(intDeleteIndex);

				//如果只有该条记录只有一行数据时，将不会执行此循环
				while((intDeleteIndex < m_dtbRecords.Rows.Count) && (m_dtbRecords.Rows[intDeleteIndex][2].ToString() == ""))
				{
					m_mthSetDataGridFirstRowFocus();
					m_dtbRecords.Rows.RemoveAt(intDeleteIndex);
				}
			}
		}

		/// <summary>
		/// 使得DataGrid的第一行获得焦点
		/// </summary>
		protected void m_mthSetDataGridFirstRowFocus()
		{
            if(this.IsHandleCreated)
			
			//modified, Jacky-2003-6-12
			m_dtgRecordDetail.CurrentCell = new DataGridCell(m_dtbRecords.Rows.Count,0);
		}
		/// <summary>
		/// 获取处理（添加和修改）记录的窗体。
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <returns></returns>
		protected virtual frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
			//由子窗体重载实现
			return null;
		}

		/// <summary>
		/// 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
		/// </summary>
		/// <param name="p_intRecordType"></param>
		/// <param name="p_objDataArr"></param>
		/// <returns></returns>
		protected virtual clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
			object[] p_objDataArr)
		{
			//由子窗体重载实现
			return null;
		}

		protected virtual void mniEdit_Click(object sender, System.EventArgs e)
		{
            //PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
			#if FunctionPrivilege
						if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.AddOrModify))
						{
							clsPublicFunction.s_mthShowNotPermitMessage();
							return;
						}			
			#endif

//			if(m_objCurrentContext.m_ObjControl.m_enmModifyCheck(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,this,enmFormState.NowUser)
//				== enmDBControlCheckResult.Disable)
//			{
//				clsPublicFunction.s_mthShowNotPermitMessage();
//				return;
//			}

			if(!m_blnCheckDataGridCurrentRow())
				return;
			this.Cursor=Cursors.WaitCursor;
            try
            {
                int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
                if (intSelectedRecordStartRow < 0)
                    return;

                string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
                int intRecordType = (int)m_dtbRecords.Rows[intSelectedRecordStartRow][1];
                if (intRecordType == 100)
                {
                    clsPublicFunction.ShowInformationMessageBox("该行是空行，请选择一条记录");
                    return;
                }
                else if (com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_StrCurrentHospitalNO != "450101001" && intRecordType == (int)enmDiseaseTrackType.FirstIllnessNote)
                    intRecordType = (int)enmDiseaseTrackType.FirstIllnessNote_F2;
                m_mthModifyRecord(intRecordType, DateTime.Parse(strOpenDate));
            }
            catch (Exception exp)//捕捉未知错误 Alex 2003-7-31
            {
                string strtemp = exp.Message;
                MessageBox.Show(exp.Message.ToString());
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}
		/// <summary>
		/// 删除记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual void mniDelete_Click(object sender, System.EventArgs e)
		{
            if (m_ObjCurrentEmrPatientSession == null)
            {
                return;
            }

			PrivilegeData.enmPrivilegeSF enmSF = (PrivilegeData.enmPrivilegeSF)Enum.Parse(typeof(PrivilegeData.enmPrivilegeSF),this.GetType().Name);
			#if FunctionPrivilege
						if(!clsPublicFunction.s_blnCheckCurrentPrivilege(enmSF,PrivilegeData.enmPrivilegeOperation.Delete))
						{
							clsPublicFunction.s_mthShowNotPermitMessage();
							return;
						}			
			#endif


            //if(m_objCurrentContext.m_ObjControl.m_enmDeleteCheck(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,this,enmFormState.NowUser)
            //    == enmDBControlCheckResult.Disable)
            //{
            //    clsPublicFunction.s_mthShowNotPermitMessage();
            //    return;
            //}	
	        
            if (m_blnReadOnly)
            {
                clsPublicFunction.ShowInformationMessageBox("此病历为只读，不能删除！");
                return;
            }
			
			if(!m_blnCheckDataGridCurrentRow())
				return;
			if(!m_lngCanYouDoIt())
			{
				clsPublicFunction.ShowInformationMessageBox("该单已被上级审核过，您无权删除！");
				return;
			}


			int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
			if(intSelectedRecordStartRow < 0)
				return;
			string strCreateDate = m_dtbRecords.Rows[intSelectedRecordStartRow][0].ToString();
			int intRecordType = (int)m_dtbRecords.Rows[intSelectedRecordStartRow][1];
			if (intRecordType == 100)
				return;
			if(!clsPublicFunction.s_blnAskForDelete())
				return ;

            //获取创建者ID
            clsTrackRecordContent objContent = m_objGetRecordMainContent(intRecordType, m_dtbRecords.Rows[intSelectedRecordStartRow].ItemArray);
                        
            string strCreateUserID ;
            try
            {
                 if ( objContent!=null && objContent.m_strCreateUserID != null)
                       strCreateUserID = objContent.m_strCreateUserID.Trim();
                   else            
                       strCreateUserID = "";
            }
            catch (Exception)
            {
                
                throw;
            }
           

            //权限判断
            string strDeptIDTemp = m_ObjCurrentEmrPatientSession.m_strAreaId;
            bool blnIsAllow = clsPublicFunction.IsAllowDelete(strDeptIDTemp, strCreateUserID, clsEMRLogin.LoginEmployee, intFormType);
            if (!blnIsAllow)
                return ;

            try
            {
			    this.Cursor=Cursors.WaitCursor;
			    m_mthDeleteRecord(intRecordType,m_dtbRecords.Rows[intSelectedRecordStartRow].ItemArray);

            }
            finally
            {
			    this.Cursor=Cursors.Default;

            }
		}



		/// <summary>
		/// 设置DataGrid内的控件触发的事件和右键菜单
		/// </summary>
		/// <param name="p_objControl"></param>
		protected void m_mthSetControl(DataGridTextBoxColumn p_objControl)
		{
			Control m_objControl;
			m_objControl = (DataGridTextBox)p_objControl.TextBox;
			m_objControl.ContextMenu = ctmRecordControl;
			m_objControl.DoubleClick += new EventHandler(m_mthTxtDoubleClick);
		}

		/// <summary>
		/// 设置DataGrid内的控件触发的事件和右键菜单
		/// </summary>
		/// <param name="p_objControl"></param>
        protected void m_mthSetControl(com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox p_objControl)
		{
			p_objControl.m_RtbBase.ContextMenu = ctmRecordControl;
			p_objControl.m_RtbBase.MouseDown += new MouseEventHandler(cltDataGridDSTRichTextBox_MouseDown);
		}

		protected void m_mthSetControl(com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox[] p_objControlArr)
		{
			foreach(com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox obj in p_objControlArr)
			{
				obj.m_RtbBase.ContextMenu = ctmRecordControl;
				obj.m_RtbBase.MouseDown += new MouseEventHandler(cltDataGridDSTRichTextBox_MouseDown);
			}
		}

		/// <summary>
		/// 双击DataGrid内的控件触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cltDataGridDSTRichTextBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			try
			{
				if(e.Clicks > 1)
				{
					int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
					if(intSelectedRecordStartRow < 0)
						return;
					string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
					int intRecordType = (int)m_dtbRecords.Rows[intSelectedRecordStartRow][1];
					m_mthModifyRecord(intRecordType,DateTime.Parse(strOpenDate));
				}
			}
			catch//捕捉未知错误 Alex 2003-7-31
			{
				
			}
		}

		/// <summary>
		/// 双击DataGrid内的控件触发的事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected virtual  void m_mthTxtDoubleClick(object sender,EventArgs e)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			try
			{
				int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
				if(intSelectedRecordStartRow < 0)
					return;
				string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
				int intRecordType = (int)m_dtbRecords.Rows[intSelectedRecordStartRow][1];
				m_mthModifyRecord(intRecordType,DateTime.Parse(strOpenDate));
			}
			catch(Exception exp)//捕捉未知错误 Alex 2003-7-31
			{
				string strErrorMessage=exp.Message;
			}
		}

		/// <summary>
		/// 处理之前判断DataGrid与DataTable的关系
		/// </summary>
		/// <returns></returns>
		protected virtual bool m_blnCheckDataGridCurrentRow()
		{
			try
			{
				if(m_dtbRecords.Rows.Count <=0)
					return false;
				if(m_dtgRecordDetail.CurrentCell.RowNumber  >= m_dtbRecords.Rows.Count)
				{
					return false;
				}
				return true;
			}
			catch//捕捉未知错误 Alex 2003-7-31
			{
				return false;
			}

		}

		#region DataControl  PublicFunction
		public void Save(){m_mthSave();}
		public void Delete()
        {
            //指明表单类型为医生工作站
            intFormType = 1;
            m_mthDelete();
        }
		public void Display(){}
		public void Display(string cardno,string sendcheckdate){}
		public void Print(){m_lngPrint();}
		public void Copy(){m_lngCopy();}
		public void Cut(){m_lngCut();}
		public void Paste(){m_lngPaste();}
		public void Redo(){}
		public void Undo(){}
		public void Verify()
		{
			//long lngRes=m_lngSignVerify(p_strFormID,p_strRecordID);
		}
		#endregion DataControl]

		protected virtual void m_mthSave()
		{
			return;
		}

		protected virtual void m_mthDelete()
		{
			return;
		}

		#region 添加键盘快捷键
		protected void m_mthSetQuickKeys()
		{			
			m_mthSetControlEvent(this);			
		}
		
		private void m_mthSetControlEvent(Control p_ctlControl)
		{
			#region 利用递归调用，读取并设置所有界面事件,Jacky-2003-2-21	
			string strTypeName = p_ctlControl.GetType().Name;
			if(strTypeName != "Lable" && strTypeName != "Button")
			{
				p_ctlControl.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_mthEvent_KeyDown);
				if(p_ctlControl.HasChildren && strTypeName !="DateTimePicker" && strTypeName !="ctlComboBox")
				{									
					foreach(Control subcontrol in p_ctlControl.Controls)
					{				
						string strSubTypeName = subcontrol.GetType().Name;
						if(strSubTypeName != "Lable" && strSubTypeName != "Button")												
							m_mthSetControlEvent(subcontrol);						
					} 	
				}				
			}			
			#endregion
		}
		
		protected virtual void m_mthEvent_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch(e.KeyCode)
			{//F1 112  帮助, F2 113 Save，F3  114 Del，F4 115 Print，F5 116 Refresh，F6 117 Search
				case Keys.Enter:// enter				
					break;
				case Keys.Up:
					break;		
				case Keys.F2://save
					this.Save(); 
					break;
				case Keys.F3://del
					break;
				case Keys.F4://print
					this.m_lngSubPrint();
					break;
				case Keys.F5://refresh
					m_mthClearAll();
					break;
				case Keys.F6://Search
					break;
			}	
		}

		#endregion

		private void ctmRecordControl_Popup(object sender, System.EventArgs e)
		{
			//暂时屏蔽权限校验 －－－－－－－－－（bhuang）
			bool blnEnable=true;
//			if(m_objCurrentPatient !=null && m_trvInPatientDate.SelectedNode.Tag !=null && m_trvInPatientDate.SelectedNode.Tag.GetType().Name=="DateTime")
//			{
//				//为1900-1-1的出院时间表明没有出院,可以修改记录
//				if( (DateTime)m_trvInPatientDate.SelectedNode.Tag ==DateTime.Parse("1900-1-1") )
//					blnEnable=true;
//				else
//				{//出院时间在6小时之内的,也可以修改记录
//					TimeSpan span=DateTime.Parse(m_objPublicDomain.m_strGetServerTime()) - ((DateTime)m_trvInPatientDate.SelectedNode.Tag);
//					if(span.TotalHours < 24*7)//不能写上<=,因为分钟没有计算在内
//						blnEnable=true;
//				}
//			}
//
//			if(!m_blnCanShowNewForm)
//				blnEnable = false;
//
			mniAppend.Enabled = blnEnable;
			mniEdit.Enabled = blnEnable;
			mniDelete.Enabled = blnEnable;
			mniApprove.Enabled = blnEnable;
			mniUnApprove.Enabled = blnEnable;
		}
		
		 void mniAppend_Click(object sender, System.EventArgs e)
		{
//			if(m_objCurrentContext.m_ObjControl.m_enmAddNewCheck(((clsDepartment)(this.m_cboDept.SelectedItem)).m_StrDeptID,this,enmFormState.NowUser)
//				== enmDBControlCheckResult.Disable)
//			{
//				clsPublicFunction.s_mthShowNotPermitMessage();
//				return;
//			}
		}

		#region 审核
		public clsApprove_FlowDomain  m_objApprove=new clsApprove_FlowDomain();		
		
		protected virtual bool m_lngCanYouDoIt()
		{
			int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
			if(intSelectedRecordStartRow < 0)
				return false;

			string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
			int intRecordType = (int)m_dtbRecords.Rows[intSelectedRecordStartRow][1];

			//获取记录的窗体
			string  strFormID = m_strGetFormID(intRecordType);

			return m_objApprove.lngCanYouDoIt(clsSystemContext.s_ObjCurrentContext.m_ObjEmployee.m_StrEmployeeID,strFormID,m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),strOpenDate,m_ObjCurrentEmrPatientSession.m_strAreaId);
		}		
		
		protected string m_strGetFormID(int p_intRecordType)
		{	
			switch((enmDiseaseTrackType)p_intRecordType)
			{
				#region 护士工作站
				case enmDiseaseTrackType.GeneralNurseRecord:
					return ((int)PrivilegeData.enmPrivilegeSF.frmGeneralNurseRecord).ToString();
				case enmDiseaseTrackType.WatchItem:
					return ((int)PrivilegeData.enmPrivilegeSF.frmSubWatchItemRecord).ToString();
				case enmDiseaseTrackType.IntensiveTend:
					return ((int)PrivilegeData.enmPrivilegeSF.frmIntensiveTend).ToString();
				case enmDiseaseTrackType.ICUIntensiveTend:
					return ((int)PrivilegeData.enmPrivilegeSF.frmSubICUIntensiveTend).ToString();
                case enmDiseaseTrackType.GeneralNurseRecord_GX:
                    return ((int)PrivilegeData.enmPrivilegeSF.frmGeneralNurseRecord_GX).ToString();
				#endregion

				#region 病程记录
				case enmDiseaseTrackType.GeneralDisease:
					return ((int)PrivilegeData.enmPrivilegeSF.frmGeneralDisease).ToString();
				case enmDiseaseTrackType.HandOver:
					return ((int)PrivilegeData.enmPrivilegeSF.frmHandOver).ToString();
				case enmDiseaseTrackType.TakeOver:
					return ((int)PrivilegeData.enmPrivilegeSF.frmTakeOver).ToString();
				case enmDiseaseTrackType.Consultation:
					return ((int)PrivilegeData.enmPrivilegeSF.frmConsultation).ToString();
				case enmDiseaseTrackType.Convey:
					return ((int)PrivilegeData.enmPrivilegeSF.frmConvey).ToString();
				case enmDiseaseTrackType.TurnIn:
					return ((int)PrivilegeData.enmPrivilegeSF.frmTurnIn).ToString();
				case enmDiseaseTrackType.DiseaseSummary:
					return ((int)PrivilegeData.enmPrivilegeSF.frmDiseaseSummary).ToString();
				case enmDiseaseTrackType.CheckRoom:
					return ((int)PrivilegeData.enmPrivilegeSF.frmCheckRoom).ToString();
				case enmDiseaseTrackType.CaseDiscuss:
					return ((int)PrivilegeData.enmPrivilegeSF.frmCaseDiscuss).ToString();
				case enmDiseaseTrackType.BeforeOperationDiscuss:
					return ((int)PrivilegeData.enmPrivilegeSF.frmBeforeOperationDiscuss).ToString();
				case enmDiseaseTrackType.DeadCaseDiscuss:
					return ((int)PrivilegeData.enmPrivilegeSF.frmDeadCaseDiscuss).ToString();
				case enmDiseaseTrackType.DeathCaseDiscuss:
					return ((int)PrivilegeData.enmPrivilegeSF.frmDeathCaseDiscuss).ToString();
				case enmDiseaseTrackType.AfterOperation:
					return ((int)PrivilegeData.enmPrivilegeSF.frmAfterOperation).ToString();
				case enmDiseaseTrackType.Dead:
					return ((int)PrivilegeData.enmPrivilegeSF.frmDeadRecord).ToString();
				case enmDiseaseTrackType.Death:
					return ((int)PrivilegeData.enmPrivilegeSF.frmDeathRecord).ToString();
				case enmDiseaseTrackType.OutHospital:
					return ((int)PrivilegeData.enmPrivilegeSF.frmOutHospital).ToString();
				case enmDiseaseTrackType.Save:
					return ((int)PrivilegeData.enmPrivilegeSF.frmSaveRecord).ToString();
				#endregion 
			}  			
		
			return "";
		}

		protected virtual void mniApprove_Click(object sender, System.EventArgs e)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			
			int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
			if(intSelectedRecordStartRow < 0)
				return;

			string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
			int intRecordType = (int)m_dtbRecords.Rows[intSelectedRecordStartRow][1];

			if(this.GetType().Name=="frmWatchItemTrack")
			{
				intRecordType = 3;	
			}
			//获取记录的窗体
			string  strFormID = m_strGetFormID(intRecordType);

			long lngEff=0;
            lngEff = m_objApprove.lngApproveDocument(clsSystemContext.s_ObjCurrentContext.m_ObjEmployee.m_StrEmployeeID, strFormID, m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), strOpenDate, m_ObjCurrentEmrPatientSession.m_strAreaId, ref lngEff);//((clsDepartment)this.m_cboDept.SelectedItem).m_StrDeptID,ref lngEff);
			
			#region 根据结果做不同的处理
				switch((enmApproveResult)lngEff)
				{
					case enmApproveResult.DB_Succeed:					
						clsPublicFunction.ShowInformationMessageBox("审核成功!");
						break;
					case enmApproveResult.System_Not_Define:					
						clsPublicFunction.ShowInformationMessageBox("系统没有定义该单的审核流程（应该在数据库中定义）!");
						break;
					case enmApproveResult.Document_Has_Been_Finished:					
						clsPublicFunction.ShowInformationMessageBox("单已经经过终审，不能再往下审核!");
						break;
					case enmApproveResult.No_Purview:					
						clsPublicFunction.ShowInformationMessageBox("该用户无权审核审核流中的该步骤!");
						break;
					case enmApproveResult.EmployeeID_Error:					
						clsPublicFunction.ShowInformationMessageBox("员工号错误!");
						break;
					case enmApproveResult.Not_Found_Approve_Info:					
						clsPublicFunction.ShowInformationMessageBox("没有找到该单进行审核的信息!");
						break;
					case enmApproveResult.Is_Top_Level:					
						clsPublicFunction.ShowInformationMessageBox("已经退回到最上一级!");
						break;
					case enmApproveResult.Document_Has_Been_Deleted:					
						clsPublicFunction.ShowInformationMessageBox("该单已经删除!");
						break;
					default:
						break;
				}
			#endregion 根据结果做不同的处理
			
		}

		protected virtual  void mniUnApprove_Click(object sender, System.EventArgs e)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			
			int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
			if(intSelectedRecordStartRow < 0)
				return;

			string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
			int intRecordType = (int)m_dtbRecords.Rows[intSelectedRecordStartRow][1];

			//获取记录的窗体
			string  strFormID = m_strGetFormID(intRecordType);

			long lngEff=0;
            lngEff = m_objApprove.lngUntreadDocumentOneLevel(clsSystemContext.s_ObjCurrentContext.m_ObjEmployee.m_StrEmployeeID, strFormID, m_objBaseCurrentPatient.m_StrInPatientID, m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), strOpenDate,m_ObjCurrentEmrPatientSession.m_strAreaId, ref lngEff);//((clsDepartment)this.m_cboDept.SelectedItem).m_StrDeptID,ref lngEff);
			
			#region 根据结果做不同的处理
			switch((enmApproveResult)lngEff)
			{
				case enmApproveResult.DB_Succeed:					
					clsPublicFunction.ShowInformationMessageBox("退审成功!");
					break;
				case enmApproveResult.System_Not_Define:					
					clsPublicFunction.ShowInformationMessageBox("系统没有定义该单的审核流程（应该在数据库中定义）!");
					break;
				case enmApproveResult.Document_Has_Been_Finished:					
					clsPublicFunction.ShowInformationMessageBox("单已经经过终审，不能再往下审核!");
					break;
				case enmApproveResult.No_Purview:					
					clsPublicFunction.ShowInformationMessageBox("该用户无权审核审核流中的该步骤!");
					break;
				case enmApproveResult.EmployeeID_Error:					
					clsPublicFunction.ShowInformationMessageBox("员工号错误!");
					break;
				case enmApproveResult.Not_Found_Approve_Info:					
					clsPublicFunction.ShowInformationMessageBox("没有找到该单进行审核的信息!");
					break;
				case enmApproveResult.Is_Top_Level:					
					clsPublicFunction.ShowInformationMessageBox("已经退回到最上一级!");
					break;
				case enmApproveResult.Document_Has_Been_Deleted:					
					clsPublicFunction.ShowInformationMessageBox("该单已经删除!");
					break;
				default:
					break;
			}
			#endregion 根据结果做不同的处理
		}		

		#endregion

		/// <summary>
		/// 不需要保存提示
		/// </summary>
		protected override void m_mthAddFormStatusForClosingSave()
		{
		}

		/// <summary>
		/// 打印前不需要提示保存
		/// </summary>
		/// <returns></returns>
		protected override DialogResult m_dlgHandleSaveBeforePrint()
		{
			return DialogResult.None;
		}

		/// <summary>
		/// 显示数据到datagrid(危重护理记录)
		/// </summary>
		protected virtual void DisplayDataToDatagrid(DataTable p_dtData)
		{
			return;
		}
		
		/// <summary>
		/// 病人没有记录，自动打开相应的病程记录
		/// </summary>
		protected virtual void m_mthAutoAddNewRecord()
		{
			return;
		}



		protected override void m_mthAddRichTemplateInContainer(Control p_ctlContainer)
		{
		}
		#region 设置分页（一般护理记录）
		#region  添加删除病程记录空行
		//添加空行
		private void m_mniAddBlank_Click(object sender, System.EventArgs e)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			int intRowsCount = 0;
			using(frmAddBlankInDiseaseTrack frmAddBlankdlg = new frmAddBlankInDiseaseTrack())
			{
				if(frmAddBlankdlg.ShowDialog() == DialogResult.OK)
					intRowsCount = frmAddBlankdlg.m_IntLineCount;
			}
			if (intRowsCount ==0)
				return;
			int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
			if(intSelectedRecordStartRow < 0)
				return;
			string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
			m_mthAddBlankToDiseaseTrack(strOpenDate,intRowsCount);
			
		}
		/// <summary>
		/// 增加空行记录到病程记录
		/// </summary>
		/// <param name="p_strOpenDate">记录打开日期</param>
		/// <param name="p_intRowsCount">添加的行数</param>
		private void m_mthAddBlankToDiseaseTrack(string p_strOpenDate, int p_intRowsCount)
		{
			object[][] objDataArr = new object[p_intRowsCount][];
			for(int i=0;i<objDataArr.Length;i++)
				objDataArr[i] = new object[5];
			bool blnAddnew = true;
			DataRow dtrNewRow;
			int intInsertIndex = -1;
			//循环DataTable的记录，获取记录的打开日期（第三字段）
			//如果有记录日期，如果日期与p_dtmOpenDate相同
			//intInsertIndex = 下标;
			//如果记录类型是旧空行记录,新空行记录不加入日期和类型标识,下标再加1
			//跳出循环
			for(int i1=0;i1<m_dtbRecords.Rows.Count;i1++)
			{
				if(m_dtbRecords.Rows[i1][2].ToString() != "")
				{
					if(DateTime.Parse(m_dtbRecords.Rows[i1][2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(p_strOpenDate).ToString("yyyy-MM-dd HH:mm:ss"))
					{
						intInsertIndex = i1;
						if (m_dtbRecords.Rows[i1][1].ToString() == "100")
						{
							intInsertIndex++;
							blnAddnew = false;
						}
						else
						{
							objDataArr[0][1] = 100;
							objDataArr[0][2] = p_strOpenDate;
						}
						break;
					}
				}
			}
			if (intInsertIndex == -1)  return;
			if(m_dtbTempTable == null)
			{
				m_dtbTempTable = m_dtbRecords.Clone();
			}
			while((intInsertIndex < m_dtbRecords.Rows.Count))
			{
				m_mthSetDataGridFirstRowFocus();
				dtrNewRow = m_dtbTempTable.NewRow();
				dtrNewRow.ItemArray = m_dtbRecords.Rows[intInsertIndex].ItemArray;
				m_dtbTempTable.Rows.Add(dtrNewRow);
				m_dtbRecords.Rows.RemoveAt(intInsertIndex);
			}
			for(int i1=0;i1<objDataArr.Length;i1++)//新增的记录
			{
				dtrNewRow = m_dtbRecords.NewRow();
				dtrNewRow.ItemArray = objDataArr[i1];
				m_dtbRecords.Rows.Add(dtrNewRow);
			}
			for(int i1=0;i1<m_dtbTempTable.Rows.Count;i1++)//把内存中的记录，再添加回去
			{
				dtrNewRow = m_dtbRecords.NewRow();
				dtrNewRow.ItemArray = m_dtbTempTable.Rows[i1].ItemArray;
				m_dtbRecords.Rows.Add(dtrNewRow);
			}
			if(m_dtbTempTable != null)
			{
				m_dtbTempTable.Rows.Clear();
			}
			clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
			//获取主要内容
			clsTrackRecordContent objContent = new clsTrackRecordContent();
			objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
			objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_dtmOpenDate = DateTime.Parse( p_strOpenDate);
			objContent.m_strRowsNumber = p_intRowsCount.ToString();
			if (blnAddnew)
			{
				objAddBlankDomain.m_lngAddNewBlankRecord(objContent);
			}
			else
			{
				DataTable dtbBlankRecord;
				objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate,out dtbBlankRecord);
				if (dtbBlankRecord != null && dtbBlankRecord.Rows.Count > 0)
				{
					foreach(System.Data.DataRow drtAdd in dtbBlankRecord.Rows)
					{
						if (DateTime.Parse(drtAdd[2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(p_strOpenDate).ToString("yyyy-MM-dd HH:mm:ss"))
						{
							objContent.m_strRowsNumber = Convert.ToString(Convert.ToInt32(drtAdd[3].ToString())+p_intRowsCount);
							break;
						}
					}
				}
				objAddBlankDomain.m_lngModifyBlankRecord(objContent);
			}
		}

		//删除空行
		private void m_mniDeleteBlank_Click(object sender, System.EventArgs e)
		{
			int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
			if(intSelectedRecordStartRow < 0)
				return;
			string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
			//根据p_dtmOpenDate查找对应的记录
			int intDeleteIndex = -1;
			//循环DataTable的记录，获取记录打开日期（第三个字段）和记录类型（第二个字段）
			//如果有记录日期和记录类型
			//如果有记录日期，如果日期与p_dtmOpenDate相同 ,并且记录类型与空行记录类型相同
			//intDeleteIndex = 下标;
			//跳出循环
			for(int i1=0;i1<m_dtbRecords.Rows.Count;i1++)
			{
				if(m_dtbRecords.Rows[i1][2].ToString() != "" && m_dtbRecords.Rows[i1][1].ToString() != "")
				{
					if(DateTime.Parse(m_dtbRecords.Rows[i1][2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(strOpenDate).ToString("yyyy-MM-dd HH:mm:ss") && (int)m_dtbRecords.Rows[i1][1] == 100)
					{
						intDeleteIndex = i1;
						break;
					}
				}
			}
			//删除的空行数
			int intBlankLine = 0;
			if(intDeleteIndex >= 0)
			{ 
				//根据intDeleteIndex循环删除记录
				//删除intDeleteIndex行
				
				//如果intDeleteIndex没有超出DataTable范围
				//获取记录，查看有无记录的日期
				//如果有，说明记录已经删除完毕，返回
						
				//如果无，继续删除行
				//intDeleteIndex超出范围(>=DataTable.Rows.Count)，返回

				m_mthSetDataGridFirstRowFocus();

				m_dtbRecords.Rows.RemoveAt(intDeleteIndex);
				intBlankLine++;

				//如果只有该条记录只有一行数据时，将不会执行此循环
				while((intDeleteIndex < m_dtbRecords.Rows.Count) && (m_dtbRecords.Rows[intDeleteIndex][2].ToString() == ""))
				{
					m_mthSetDataGridFirstRowFocus();
					m_dtbRecords.Rows.RemoveAt(intDeleteIndex);
					intBlankLine++;
				}
			}
			#region  从数据库获取空行数(No used)
//			DataTable dtbBlankRecord;
//			
//			objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate,out dtbBlankRecord);
//			
//			if (dtbBlankRecord != null && dtbBlankRecord.Rows.Count > 0)
//			{
//				foreach(System.Data.DataRow drtAdd in dtbBlankRecord.Rows)
//				{
//					if (DateTime.Parse(drtAdd[2].ToString()).ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(strOpenDate).ToString("yyyy-MM-dd HH:mm:ss"))
//					{
//						strBlankLine = drtAdd[3].ToString();
//						break;
//					}
//				}
//			}
			#endregion
			//获取主要内容
			clsTrackRecordContent objContent = new clsTrackRecordContent();
			objContent.m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
			objContent.m_dtmInPatientDate = m_objCurrentPatient.m_DtmSelectedInDate;
			objContent.m_dtmOpenDate = DateTime.Parse( strOpenDate);
			objContent.m_strRowsNumber = intBlankLine.ToString();

			clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
			objAddBlankDomain.m_lngDeleteBlankRecord(objContent);
		}
		#endregion

//		/// <summary>
//		/// 添加分页标志
//		/// </summary>
//		/// <param name="sender"></param>
//		/// <param name="e"></param>
//		private void mniPageAdd_Click(object sender, System.EventArgs e)
//		{
//			m_mthSetPagination("1");
//		}
//		/// <summary>
//		/// 删除分页标志
//		/// </summary>
//		/// <param name="sender"></param>
//		/// <param name="e"></param>
//		private void mniPageRemove_Click(object sender, System.EventArgs e)
//		{
//			m_mthSetPagination("0");
//		}
		/// <summary>
		/// 设置分页标志（1：分页   0：不分页）
		/// </summary>
		/// <param name="p_strIsAddPage"></param>
		protected void m_mthSetPagination(string p_strIsAddPage)
		{
			if(!m_blnCheckDataGridCurrentRow())
				return;
			int intSelectedRecordStartRow = m_intGetRecordStartRow(m_dtgRecordDetail.CurrentCell.RowNumber);
			if(intSelectedRecordStartRow < 0)
				return;
			try
			{
				string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
				int intRecordType = (int)m_dtbRecords.Rows[intSelectedRecordStartRow][1];
				//获取添加记录的窗体
				frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(intRecordType); 

				clsTrackRecordContent objContent = frmAddNewForm.m_objGetRecordContent(m_objCurrentPatient,strOpenDate);
				if(objContent != null)
				{
                    com.digitalwave.clsMainGeneralNurseRecordService.clsMainGeneralNurseRecordService objServ =
                        (com.digitalwave.clsMainGeneralNurseRecordService.clsMainGeneralNurseRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsMainGeneralNurseRecordService.clsMainGeneralNurseRecordService));

                    long lngRes = objServ.m_lngSetPagination(objContent, p_strIsAddPage);
					if(lngRes > 0)
					{
						objContent.m_StrPagination = p_strIsAddPage;
						clsTransDataInfo objDataInfo = new clsTransDataInfo();
						objDataInfo.m_intFlag = intRecordType;
						objDataInfo.m_objRecordContent = objContent;
						try
						{
							//清空病人记录信息				
							m_mthClearPatientRecordInfo();
						if(m_ObjCurrentEmrPatientSession == null || m_objCurrentPatient==null)
						{						
							return;
						}

                        m_objCurrentPatient.m_DtmSelectedInDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;

						//获取病人记录列表
						clsTransDataInfo[] objTansDataInfoArr;
                        //string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                        //string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss"); //m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
                        lngRes = m_objRecordsDomain.m_lngGetTransDataInfoArr(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out objTansDataInfoArr);

						if(lngRes <= 0 || objTansDataInfoArr == null)
						{
							return;
						} 
		
						//按记录时间(CreateDate)排序
						m_mthSortTransData(ref objTansDataInfoArr);

						DataTable dtbAddBlank;
						clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
						objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID,m_objCurrentPatient.m_DtmSelectedInDate,out dtbAddBlank);

						//添加记录到的DataTable
						object [][] objDataArr;
						for(int i1=0;i1<objTansDataInfoArr.Length;i1++)
						{
							//查找记录之前有否空行记录,有插入空行
							foreach(DataRow drtAdd in dtbAddBlank.Rows) 
							{
								if(objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse( drtAdd[2].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))
								{
									object[] objBlank = new object[5];
									objBlank[1] = 100;
									objBlank[2] = drtAdd[2].ToString();
									m_dtbRecords.Rows.Add(objBlank);
									for(int k3 = 0; k3 < (Int32.Parse( drtAdd[3].ToString())-1); k3++)
									{
										m_dtbRecords.Rows.Add(new object[]{});
									}
									break;
								}
							}
					
							objDataArr = m_objGetRecordsValueArr(objTansDataInfoArr[i1]);
					
							if(objDataArr==null)
								return;
							for(int j2=0;j2<objDataArr.Length;j2++)
							{
								m_dtbRecords.Rows.Add(objDataArr[j2]);	
							}
						}
						//				if(m_dtbRecords.Rows.Count > 0)//处理像病程记录那样只有一个column的情况 alex 2003-05-29
						//				{
						//					m_dtgRecordDetail.CurrentCell = new DataGridCell(1,0);
						//					m_dtgRecordDetail.CurrentCell = new DataGridCell(0,0);
						//				}		

						if(m_dtbRecords.Rows.Count == 0 && !m_blnIfNewDeletedRecord)
						{
							m_mthAutoAddNewRecord();
						}
					}
			catch(Exception ex)
			{
				MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
			}

						//更新到datatable
						//datagrid中进行标志

				
						//设置内容到DataTable 子窗体重载
	//					object [][] objDataArr = m_objGetRecordsValueArr(objDataInfo);  
				
						//从DataTable删除内容
	//					m_mthRemoveDataFromDataTable(intRecordType,objContent.m_dtmOpenDate);

						//添加内容到DataTable
	//					m_mthAddDataToDataTable(objDataArr,objContent.m_dtmCreateDate);
					}
				}
			
			}
			catch(Exception exp)
			{
				string strTemp=exp.Message;
			}

		}		

		#endregion ;

        /// <summary>
        /// 设置分页标志（1：分页   0：不分页）病程记录
        /// </summary>
        /// <param name="p_strIsAddPage"></param>
        protected void m_mthSetPaginations(string p_strIsAddPage)
        {
            if (!m_blnCheckDataGridCurrentRow())
                return;
            int intSelectedRecordStartRow = m_intGetRecordStartRows(m_dtgRecordDetail.CurrentCell.RowNumber);
            if (intSelectedRecordStartRow < 0)
                return;
            try
            {
                string strOpenDate = m_dtbRecords.Rows[intSelectedRecordStartRow][2].ToString();
                int intRecordType = (int)m_dtbRecords.Rows[intSelectedRecordStartRow][1];
                //获取添加记录的窗体
                frmDiseaseTrackBase frmAddNewForm = m_frmGetRecordForm(intRecordType);
                string getfromtype = frmAddNewForm.Text;
                clsTrackRecordContent objContent = frmAddNewForm.m_objGetRecordContent(m_objCurrentPatient, strOpenDate);
                if (objContent != null)
                {
                    com.digitalwave.clsSubDiseaseTrackServer.clsSubDiseaseTrackServer objServ =
                        (com.digitalwave.clsSubDiseaseTrackServer.clsSubDiseaseTrackServer)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.clsSubDiseaseTrackServer.clsSubDiseaseTrackServer));

                    long lngRes = objServ.m_lngSetPagination(objContent, p_strIsAddPage, getfromtype);
                    if (lngRes > 0)
                    {
                        objContent.m_StrPagination = p_strIsAddPage;
                        clsTransDataInfo objDataInfo = new clsTransDataInfo();
                        objDataInfo.m_intFlag = intRecordType;
                        objDataInfo.m_objRecordContent = objContent;
                        try
                        {
                            //清空病人记录信息				
                            m_mthClearPatientRecordInfo();
                            if (m_ObjCurrentEmrPatientSession == null || m_objCurrentPatient == null)
                            {
                                return;
                            }

                            m_objCurrentPatient.m_DtmSelectedInDate = m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate;

                            //获取病人记录列表
                            clsTransDataInfo[] objTansDataInfoArr;
                            //string m_strInPatientID = m_objCurrentPatient.m_StrInPatientID;
                            //string m_strInPatientDate = m_objCurrentPatient.m_ObjInBedInfo.m_objGetSessionByIndex(m_trvInPatientDate.Nodes[0].Nodes.Count - m_trvInPatientDate.SelectedNode.Index - 1).m_DtmEMRInDate.ToString("yyyy-MM-dd HH:mm:ss"); //m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss");
                            lngRes = m_objRecordsDomain.m_lngGetTransDataInfoArr(m_ObjCurrentEmrPatientSession.m_strEMRInpatientId, m_ObjCurrentEmrPatientSession.m_dtmEMRInpatientDate.ToString("yyyy-MM-dd HH:mm:ss"), out objTansDataInfoArr);

                            if (lngRes <= 0 || objTansDataInfoArr == null)
                            {
                                return;
                            }

                            //按记录时间(CreateDate)排序
                            m_mthSortTransData(ref objTansDataInfoArr);

                            DataTable dtbAddBlank;
                            clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
                            objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate, out dtbAddBlank);

                            //添加记录到的DataTable
                            object[][] objDataArr;
                            for (int i1 = 0; i1 < objTansDataInfoArr.Length; i1++)
                            {
                                //查找记录之前有否空行记录,有插入空行
                                foreach (DataRow drtAdd in dtbAddBlank.Rows)
                                {
                                    if (objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(drtAdd[2].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))
                                    {
                                        object[] objBlank = new object[5];
                                        objBlank[1] = 100;
                                        objBlank[2] = drtAdd[2].ToString();
                                        m_dtbRecords.Rows.Add(objBlank);
                                        for (int k3 = 0; k3 < (Int32.Parse(drtAdd[3].ToString()) - 1); k3++)
                                        {
                                            m_dtbRecords.Rows.Add(new object[] { });
                                        }
                                        break;
                                    }
                                }

                                objDataArr = m_objGetRecordsValueArr(objTansDataInfoArr[i1]);

                                if (objDataArr == null)
                                    return;
                                for (int j2 = 0; j2 < objDataArr.Length; j2++)
                                {
                                    m_dtbRecords.Rows.Add(objDataArr[j2]);
                                }
                            }
                            //				if(m_dtbRecords.Rows.Count > 0)//处理像病程记录那样只有一个column的情况 alex 2003-05-29
                            //				{
                            //					m_dtgRecordDetail.CurrentCell = new DataGridCell(1,0);
                            //					m_dtgRecordDetail.CurrentCell = new DataGridCell(0,0);
                            //				}		

                            if (m_dtbRecords.Rows.Count == 0 && !m_blnIfNewDeletedRecord)
                            {
                                m_mthAutoAddNewRecord();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
                        }

                        //更新到datatable
                        //datagrid中进行标志


                        //设置内容到DataTable 子窗体重载
                        //					object [][] objDataArr = m_objGetRecordsValueArr(objDataInfo);  

                        //从DataTable删除内容
                        //					m_mthRemoveDataFromDataTable(intRecordType,objContent.m_dtmOpenDate);

                        //添加内容到DataTable
                        //					m_mthAddDataToDataTable(objDataArr,objContent.m_dtmCreateDate);
                    }
                }

            }
            catch (Exception exp)
            {
                string strTemp = exp.Message;
            }

        }		

//		protected override void m_mthAssociateComboBoxItemEvent(Control p_ctlParent)
//		{}

        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            try
            {
                //清空病人记录信息
                if (m_dtgRecordDetail != null)
                {
                    m_mthClearPatientRecordInfo();
                }

                if (p_objSelectedSession == null || m_objCurrentPatient == null)
                {
                    return;
                }

                //设置病人当次住院的基本信息

                m_objCurrentPatient.m_DtmSelectedInDate = p_objSelectedSession.m_dtmEMRInpatientDate;
                m_objCurrentPatient.m_StrHISInPatientID = p_objSelectedSession.m_strHISInpatientId;
                m_objCurrentPatient.m_DtmSelectedHISInDate = p_objSelectedSession.m_dtmHISInpatientDate;

                m_objCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;
                m_objBaseCurrentPatient.m_StrRegisterId = p_objSelectedSession.m_strRegisterId;

                m_mthOnlySetPatientInfo(m_objCurrentPatient);

                m_mthIsReadOnly();
                if (!m_blnCanShowRecordContent())
                {
                    clsPublicFunction.ShowInformationMessageBox("该病案已归档，当前用户没有查阅权限");
                    return;
                }

                //获取病人记录列表
                clsTransDataInfo[] objTansDataInfoArr;
                m_mthGetTransDataInfoArr(out objTansDataInfoArr);

                if (objTansDataInfoArr == null)
                {
                    return;
                }

                //按记录时间(CreateDate)排序
                //modified by  thfzhang 2005-11-12 危重护理不需要排序
                if (this.Name != "frmIntensiveTendMain_FC")
                    m_mthSortTransData(ref objTansDataInfoArr);

                DataTable dtbAddBlank;
                clsDiseaseTrackAddBlankDomain objAddBlankDomain = new clsDiseaseTrackAddBlankDomain();
                objAddBlankDomain.m_lngGetBlankRecordContent(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate, out dtbAddBlank);

                //添加记录到的DataTable
                object[][] objDataArr;
                for (int i1 = 0; i1 < objTansDataInfoArr.Length; i1++)
                {
                    if (dtbAddBlank != null && dtbAddBlank.Rows.Count > 0)
                    {
                        //查找记录之前有否空行记录,有插入空行
                        foreach (DataRow drtAdd in dtbAddBlank.Rows)
                        {
                            if (objTansDataInfoArr[i1].m_objRecordContent != null)
                            {
                                if (objTansDataInfoArr[i1].m_objRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss") == DateTime.Parse(drtAdd["opendate"].ToString()).ToString("yyyy-MM-dd HH:mm:ss"))                               
                                {
                                    object[] objBlank = new object[5];
                                    objBlank[1] = 100;
                                    objBlank[2] = drtAdd[2].ToString();
                                    m_dtbRecords.Rows.Add(objBlank);
                                    for (int k3 = 0; k3 < (Int32.Parse(drtAdd[3].ToString()) - 1); k3++)
                                    {
                                        m_dtbRecords.Rows.Add(new object[] { });
                                    }
                                    break;
                                }
                            }
                        }
                    }

                    objDataArr = m_objGetRecordsValueArr(objTansDataInfoArr[i1]);

                    if (objDataArr == null)
                        continue;

                    m_dtbRecords.BeginLoadData();
                    for (int j2 = 0; j2 < objDataArr.Length; j2++)
                    {
                        m_dtbRecords.LoadDataRow(objDataArr[j2], true);
                    }
                    m_dtbRecords.EndLoadData();
                  
                }
                m_dtgRecordDetail.EnsureVisible(m_dtbRecords.Rows.Count - 1);
                Application.DoEvents();
                m_mthAfterLoadData();

                if (m_dtbRecords.Rows.Count == 0 && !m_blnIfNewDeletedRecord)
                {
                    m_mthAutoAddNewRecord();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\r\n" + ex.StackTrace);
            }
        }

        /// <summary>
        /// 显示数据至界面后由子类操作
        /// </summary>
        protected virtual void m_mthAfterLoadData()
        {
        }

        protected bool m_blnSubIsExists()
        {
            if (m_frmCurrentSub != null && m_frmCurrentSub.CanFocus)
            {
                //MessageBox.Show("注意：当前已有打开的未保存的编辑窗体，是否关闭后再重用！");
                return true;
            }
            return false;
        }
	}

}

