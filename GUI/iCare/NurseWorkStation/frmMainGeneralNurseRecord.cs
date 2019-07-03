using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Utility.Controls;
using com.digitalwave.controls;
using System.Data;
//using HRP;
using PrivilegeData;
using com.digitalwave.emr.AssistModuleVO;
namespace iCare
{
	public class frmMainGeneralNurseRecord : iCare.frmRecordsBase
	{
		private cltDataGridDSTRichTextBox clmContent;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn1;
		private System.Windows.Forms.DataGridTextBoxColumn dataGridTextBoxColumn2;
		private DataGridColumnStyle GridDateColumn;
		private PinkieControls.ButtonXP m_cmdThreeMeasure;
		private System.Windows.Forms.Panel panel1;
		private System.ComponentModel.IContainer components = null;

		

		public frmMainGeneralNurseRecord()
		{
			// This call is required by the Windows Form Designer.
			
			InitializeComponent();
            // 
            // dgtsStyles *******
            // 
            this.dgtsStyles.GridColumnStyles.AddRange(new System.Windows.Forms.DataGridColumnStyle[] {dataGridTextBoxColumn1,
																										
																										 this.clmContent,
																										 this.dataGridTextBoxColumn2});
            this.dgtsStyles.PreferredColumnWidth = 85;
            this.dgtsStyles.RowHeaderWidth = 15;
            //            *******
			clmContent.m_RtbBase.ScrollBars = RichTextBoxScrollBars.None;
			//分页设置
		
//			m_dtgRecordDetail.TableStyles.Add(DGStyle);
		}

		#region 有关打印的声明	
		/// <summary>
		/// 所有打印的数据
		/// </summary>
		private clsPrintData[] m_objPrintDataArr;
		private class clsPrintData
		{
			public string m_strContent;
			public string m_strContentXml;
			public string m_strSign;
//			public string m_strSignXml;
			public DateTime m_dtmFirstPrintDate;
			public string m_strCreateDate;
		}
		
		private com.digitalwave.controls.clsPrintRichTextContext m_objPrintContext;
		/// <summary>
		/// 标题的字体
		/// </summary>
		private Font m_fotTitleFont;
		/// <summary>
		/// 表头的字体
		/// </summary>
		private Font m_fotHeaderFont;
		/// <summary>
		/// 表内容的字体
		/// </summary>
		private Font m_fotSmallFont;
		/// <summary>
		/// 边框画笔
		/// </summary>
		private Pen m_GridPen;
		/// <summary>
		/// 刷子
		/// </summary>
		private SolidBrush m_slbBrush;
		/// <summary>
		/// 记录打印到第几页
		/// </summary>
		private int intNowPage;
		/// <summary>
		/// 当前打印的护理记录
		/// </summary>
		private int intCurrentRecord;
		/// <summary>
		/// 准备打印一条新记录(若存在上条记录,则上条记录打完)
		/// </summary>
		private bool blnBeginPrintNewRecord=true;		
		/// <summary>
		/// 获取坐标的类
		/// </summary>
		private clsPrintPageSettingForRecord m_objPageSetting;
		/// <summary>
		/// 打印的病人基本信息类
		/// </summary>
		private class clsEveryRecordPageInfo
		{
			public string strPatientName;
			public string strSex;
			public string strAge;
			public string strBedNo;
			public string strDeptName;
			public string strInPatientID;
//			public int intCurrentPage;
//			public int intTotalPages;
//			public string strPrintDate;
		}

		/// <summary>
		/// 格子的信息
		/// </summary>
		private enum enmRecordRectangleInfo
		{
			/// <summary>
			/// 格子的顶端
			/// </summary>
			TopY = 170,
			///<summary>
			/// 格子的左端
			/// </summary>
			LeftX = 20,
			/// <summary>
			/// 格子的右端
			/// </summary>
			RightX = 827-30,
			/// <summary>
			/// 格子每行的步长
			/// </summary>
			RowStep = 40,
			/// <summary>
			/// 格子的行数
			/// </summary>
			RowLinesNum = 21,
			/// <summary>
			/// 病程记录每行的pixel长度
			/// </summary>
			RecordLineLength=520,
			/// <summary>
			/// 列的数目
			/// </summary>
			ColumnsNum=3,
			/// <summary>
			/// 第一条间隔线(X)
			/// </summary>
			ColumnsMark1=160,
			/// <summary>
			/// 第二条间隔线(X)
			/// </summary>
			ColumnsMark2=680
				
		}
		
		/// <summary>
		/// 打印元素
		/// </summary>
		private enum enmItemDefination
		{
			//基本元素
			InPatientID_Title,
			InPatientID,
			Name_Title,
			Name,
			Sex_Title,
			Sex,
			Age_Title,
			Age,
			Dept_Name_Title,
			Dept_Name,
			BedNo_Title,
			BedNo,
            
			Page_HospitalName,
			Page_Name_Title,
			Page_Title,
			Page_Num,
			Page_Of,
			Page_Count,
					
			Print_Date_Title,
			Print_Date,
			//填充表格元素
			RecordDate,
			RecordTime,
			RecordContent,
			RecordSign1,
			RecordSign2
		
		}
	  
	
		#endregion

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainGeneralNurseRecord));
            this.clmContent = new com.digitalwave.Utility.Controls.cltDataGridDSTRichTextBox();
            this.dataGridTextBoxColumn1 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.dataGridTextBoxColumn2 = new System.Windows.Forms.DataGridTextBoxColumn();
            this.m_cmdThreeMeasure = new PinkieControls.ButtonXP();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).BeginInit();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_dtgRecordDetail
            // 
            this.m_dtgRecordDetail.AccessibleName = "DataGrid";
            this.m_dtgRecordDetail.AccessibleRole = System.Windows.Forms.AccessibleRole.Table;
            this.m_dtgRecordDetail.AllowSorting = false;
            this.m_dtgRecordDetail.BackgroundColor = System.Drawing.SystemColors.AppWorkspace;
            this.m_dtgRecordDetail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_dtgRecordDetail.CaptionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.m_dtgRecordDetail.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_dtgRecordDetail.DataSource = this.m_dtbRecords;
            this.m_dtgRecordDetail.Location = new System.Drawing.Point(8, 77);
            this.m_dtgRecordDetail.PreferredColumnWidth = 85;
            this.m_dtgRecordDetail.Size = new System.Drawing.Size(785, 544);
            // 
            // mniAppend
            // 
            this.mniAppend.Click += new System.EventHandler(this.mniAppend_Click);
            // 
            // m_trvInPatientDate
            // 
            this.m_trvInPatientDate.BackColor = System.Drawing.Color.White;
            this.m_trvInPatientDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_trvInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_trvInPatientDate.ForeColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.ItemHeight = 18;
            this.m_trvInPatientDate.LineColor = System.Drawing.Color.Black;
            this.m_trvInPatientDate.Location = new System.Drawing.Point(224, 187);
            this.m_trvInPatientDate.Size = new System.Drawing.Size(156, 60);
            this.m_trvInPatientDate.Visible = false;
            // 
            // lblSex
            // 
            this.lblSex.BackColor = System.Drawing.SystemColors.Control;
            this.lblSex.Location = new System.Drawing.Point(258, 176);
            this.lblSex.Size = new System.Drawing.Size(48, 24);
            this.lblSex.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.BackColor = System.Drawing.SystemColors.Control;
            this.lblAge.Location = new System.Drawing.Point(248, 161);
            this.lblAge.Size = new System.Drawing.Size(48, 24);
            this.lblAge.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(233, 176);
            this.lblBedNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(272, 176);
            this.lblInHospitalNoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(230, 181);
            this.lblNameTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(278, 184);
            this.lblSexTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(270, 188);
            this.lblAgeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(233, 173);
            this.lblAreaTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(236, 155);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(76, 104);
            this.m_lsvInPatientID.Visible = false;
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(236, 164);
            this.txtInPatientID.Size = new System.Drawing.Size(76, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.BorderColor = System.Drawing.Color.White;
            this.m_txtPatientName.Location = new System.Drawing.Point(236, 167);
            this.m_txtPatientName.Size = new System.Drawing.Size(104, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(256, 158);
            this.m_txtBedNO.Size = new System.Drawing.Size(56, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(224, 179);
            this.m_cboArea.Size = new System.Drawing.Size(116, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(236, 169);
            this.m_lsvPatientName.Size = new System.Drawing.Size(92, 104);
            this.m_lsvPatientName.Visible = false;
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(236, 155);
            this.m_lsvBedNO.Size = new System.Drawing.Size(60, 104);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(236, 161);
            this.m_cboDept.Size = new System.Drawing.Size(116, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(233, 162);
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(268, 218);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.m_cmdNext.Location = new System.Drawing.Point(268, 171);
            this.m_cmdNext.Size = new System.Drawing.Size(20, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(224, 173);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 16);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(268, 187);
            this.m_lblForTitle.Size = new System.Drawing.Size(4, 8);
            this.m_lblForTitle.Text = "一 般 护 理 记 录";
            this.m_lblForTitle.Visible = false;
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(429, 188);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(720, 36);
            this.m_cmdModifyPatientInfo.Size = new System.Drawing.Size(69, 28);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Location = new System.Drawing.Point(3, 7);
            this.m_pnlNewBase.Size = new System.Drawing.Size(794, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(792, 29);
            // 
            // clmContent
            // 
            this.clmContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clmContent.HeaderText = "记录内容";
            this.clmContent.m_BlnGobleSet = true;
            this.clmContent.m_BlnUnderLineDST = false;
            this.clmContent.MappingName = "clmContent";
            this.clmContent.NullText = "";
            this.clmContent.Width = 500;
            // 
            // dataGridTextBoxColumn1
            // 
            this.dataGridTextBoxColumn1.Format = "";
            this.dataGridTextBoxColumn1.FormatInfo = null;
            this.dataGridTextBoxColumn1.HeaderText = "记录日期";
            this.dataGridTextBoxColumn1.MappingName = "CreateDate";
            this.dataGridTextBoxColumn1.NullText = "";
            this.dataGridTextBoxColumn1.Width = 150;
            // 
            // dataGridTextBoxColumn2
            // 
            this.dataGridTextBoxColumn2.Format = "";
            this.dataGridTextBoxColumn2.FormatInfo = null;
            this.dataGridTextBoxColumn2.HeaderText = "签名";
            this.dataGridTextBoxColumn2.MappingName = "SignName";
            this.dataGridTextBoxColumn2.NullText = "";
            this.dataGridTextBoxColumn2.Width = 65;
            // 
            // m_cmdThreeMeasure
            // 
            this.m_cmdThreeMeasure.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdThreeMeasure.DefaultScheme = true;
            this.m_cmdThreeMeasure.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdThreeMeasure.Hint = "";
            this.m_cmdThreeMeasure.Location = new System.Drawing.Point(602, 36);
            this.m_cmdThreeMeasure.Name = "m_cmdThreeMeasure";
            this.m_cmdThreeMeasure.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdThreeMeasure.Size = new System.Drawing.Size(108, 28);
            this.m_cmdThreeMeasure.TabIndex = 10000006;
            this.m_cmdThreeMeasure.TabStop = false;
            this.m_cmdThreeMeasure.Text = "体 温 单";
            this.m_cmdThreeMeasure.Click += new System.EventHandler(this.m_cmdThreeMeasure_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 552);
            this.panel1.TabIndex = 10000007;
            // 
            // frmMainGeneralNurseRecord
            // 
            this.AccessibleDescription = "一般护理记录";
            this.AutoScroll = false;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 673);
            this.Controls.Add(this.m_cmdThreeMeasure);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMainGeneralNurseRecord";
            this.Text = "一般护理记录";
            this.Load += new System.EventHandler(this.frmMainGeneralNurseRecord_Load);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_trvInPatientDate, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_dtgRecordDetail, 0);
            this.Controls.SetChildIndex(this.m_cmdThreeMeasure, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            ((System.ComponentModel.ISupportInitialize)(this.m_dtgRecordDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_dtbRecords)).EndInit();
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void CreateDataGridStyle() 
		{


			PropertyDescriptorCollection pcol = this.BindingContext[m_dtbRecords].GetItemProperties();

			GridDateColumn = new ColumnStyle(pcol[0]);
			GridDateColumn.NullText="";
			GridDateColumn.HeaderText = "";
			GridDateColumn.MappingName = "PagiNation";
			GridDateColumn.Width = 10;
			dgtsStyles.GridColumnStyles.Add(GridDateColumn);
//			dgtsStyles.GridColumnStyles.Add(clmContent);
//			dgtsStyles.GridColumnStyles.Add(dataGridTextBoxColumn2);
		}


		// 清空特殊记录信息，并重置记录控制状态为不控制。
		protected override void m_mthClearRecordInfo()
		{			
			m_dtgRecordDetail.CurrentRowIndex=0;
			m_dtbRecords.Rows.Clear();
		}

		// 初始化具体表单的DataTable。
		// 注意，DataTable的第一个Column必须是存放记录时间的字符串，第二个Column必须是存放记录类型的int值，第三个Column必须是存放记录的OpenDate
		protected override void m_mthInitDataTable(DataTable p_dtbRecordTable)
		{
			//存放记录时间的字符串
			p_dtbRecordTable.Columns.Add("CreateDate");
		
			//存放记录类型的int值
			DataColumn dcRecordType = new DataColumn("RecordType",typeof(int));
			p_dtbRecordTable.Columns.Add(dcRecordType);
		
			//存放记录的OpenDate字符串
			p_dtbRecordTable.Columns.Add("OpenDate");  
		
			//存放记录的ModifyDate字符串
			p_dtbRecordTable.Columns.Add("ModifyDate"); 
		
			//存放显示内容
			p_dtbRecordTable.Columns.Add("clmContent",typeof(clsDSTRichTextBoxValue)); 

			//存放记录的签名字符串
			p_dtbRecordTable.Columns.Add("SignName"); 

			//存放记录的分页标志
			p_dtbRecordTable.Columns.Add("PagiNation");

            //存放记录创建者ID
            p_dtbRecordTable.Columns.Add("CreateUserID"); 

			//设置记录内容的右键菜单
			m_mthSetControl(clmContent);
			//设置记录日期的右键菜单
//			m_mthSetControl(dataGridTextBoxColumn1);
//				m_mthSetControl(GridDateColumn);
			//设置签名的右键菜单
			m_mthSetControl(dataGridTextBoxColumn2);
			clmContent.m_RtbBase.m_BlnReadOnly = true;
		}

		// 获取添加到DataTable的数据
		protected override object[][] m_objGetRecordsValueArr(clsTransDataInfo p_objTransDataInfo)
		{
			//根据不同的表单类型，获取对应的clsDiseaseTrackInfo
			clsDiseaseTrackInfo objTrackInfo = null;

			objTrackInfo = new clsGeneralNurseRecordInfo();

			//设置clsDiseaseTrackInfo的内容
			objTrackInfo.m_ObjRecordContent = p_objTransDataInfo.m_objRecordContent;
		
			//根据 clsDiseaseTrackInfo 获得的文本和Xml  
			string strText = objTrackInfo.m_strGetTrackText(); 
			string strXML = objTrackInfo.m_strGetTrackXml();

			int intCharPerLine = clmContent.Width/14-4;//jacky=2003-6-1

			
			//结合DataGrid每行的显示数目
			//生成每行内容的文本和Xml数组
			string [] strTextArr,strXmlArr;			

			com.digitalwave.controls.ctlRichTextBox.m_mthSplitXmlByBytes(strText.TrimEnd(new char[]{'\n','\r'}),strXML,64,out strTextArr,out strXmlArr);

		
			object [][] objData = new object[strTextArr.Length + 1][];
            int i;
			for(i=0;i<objData.Length - 1;i++)
			{
				objData[i] = new object[8];
			
				//设置值
				if(i==0)
				{
					//只在第一行记录才由以下信息
					//objData[i][0] = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss");//存放记录时间的字符串
					objData[i][0] = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate.ToString(MDIParent.s_ObjRecordDateTimeInfo.m_strGetRecordTimeFormat("frmGeneralNurseRecord"));//存放记录时间的字符串
					objData[i][1] =(int)objTrackInfo.m_enmGetTrackType() ;//存放记录类型的int值
					objData[i][2] =objTrackInfo.m_ObjRecordContent.m_dtmOpenDate.ToString("yyyy-MM-dd HH:mm:ss");//存放记录的OpenDate字符串
					objData[i][3] =objTrackInfo.m_ObjRecordContent.m_dtmModifyDate.ToString("yyyy-MM-dd HH:mm:ss") ;//存放记录的ModifyDate字符串  
					objData[i][6]=objTrackInfo.m_ObjRecordContent.m_StrPagination;
                    objData[i][7] = objTrackInfo.m_ObjRecordContent.m_strCreateUserID;
				}

				clsDSTRichTextBoxValue objclsDSTRichTextBoxValue=new clsDSTRichTextBoxValue();
				objclsDSTRichTextBoxValue.m_strText=strTextArr[i];						
				objclsDSTRichTextBoxValue.m_strDSTXml=strXmlArr[i];
				
				objData[i][4]=objclsDSTRichTextBoxValue;//记录内容	
			
//                if(i+1 == objData.Length)
////					objData[i][5]=objTrackInfo.m_ObjRecordContent.m_strModifyUserID;//签名
//                    objData[i][5]=objTrackInfo.m_strGetSignText();//签名
			}
            objData[i] = new object[8];
			objData[i][5]=objTrackInfo.m_strGetSignText();//签名
			return objData;
		

		}

		// 获取护理记录的领域层实例
		protected override clsRecordsDomain m_objGetRecordsDomain()
		{
            return new clsRecordsDomain(enmRecordsType.GeneralNurseRecord);
		}

		protected override infPrintRecord m_objGetPrintTool()
		{
			return new clsGeneralNurseRecordPrintTool();
		}

        //protected override void m_mthHandleSubFormClosedWithYes(frmDiseaseTrackBase p_frmSubForm)
        //{
 
        
        //        TreeNode trvTemp = m_trvInPatientDate.SelectedNode;
        //        m_trvInPatientDate.SelectedNode = null;
        //        m_trvInPatientDate.SelectedNode = trvTemp;
           
        //}
		// 获取处理（添加和修改）记录的窗体。
		protected override frmDiseaseTrackBase m_frmGetRecordForm(int p_intRecordType)
		{
            //switch((enmDiseaseTrackType)p_intRecordType)
            //{
            //    case enmDiseaseTrackType.GeneralNurseRecord:
					return new frmGeneralNurseRecord();
            //}  
		
            //return null;
		}

		// 获取记录的主要信息（必须获取的是CreateDate,OpenDate,LastModifyDate）
		protected override clsTrackRecordContent m_objGetRecordMainContent(int p_intRecordType,
			object[] p_objDataArr)
		{
			//根据 p_intRecordType 获取对应的 clsTrackRecordContent
			clsTrackRecordContent objContent = null;
			switch((enmDiseaseTrackType)p_intRecordType)
			{ 
				case enmDiseaseTrackType.GeneralNurseRecord:
					objContent = new clsGeneralNurseRecordContent();
					break;
			}
		
			if(m_objCurrentPatient !=null)
				objContent.m_strInPatientID=m_objCurrentPatient.m_StrInPatientID;
			else 
			{
				clsPublicFunction.ShowInformationMessageBox("当前病人为空!");
				return null;
			}
			objContent.m_dtmInPatientDate=m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmEMRInDate;
			objContent.m_dtmCreateDate = DateTime.Parse((string)p_objDataArr[0]);
			objContent.m_dtmOpenDate = DateTime.Parse((string)p_objDataArr[2]);
			objContent.m_dtmModifyDate = DateTime.Parse((string)p_objDataArr[3]);
            objContent.m_strCreateUserID = (string)p_objDataArr[7];   
		
			return objContent;
		}

		private void mniGeneralDisease_Click(object sender, System.EventArgs e)
		{
			m_mthAddNewRecord((int)enmDiseaseTrackType.GeneralDisease);
		}

		private void mniAppend_Click(object sender, System.EventArgs e)
		{			
#if FunctionPrivilege
			if(!clsPublicFunction.s_blnCheckCurrentPrivilege(PrivilegeData.enmPrivilegeSF.frmMainGeneralNurseRecord,PrivilegeData.enmPrivilegeOperation.AddOrModify))
			{
				clsPublicFunction.s_mthShowNotPermitMessage();
				return;
			}			
#endif
			m_mthAddNewRecord((int)enmDiseaseTrackType.GeneralNurseRecord);
		}

		#region 添加异常信息、设置分页
		private void frmMainGeneralNurseRecord_Load(object sender, System.EventArgs e)
		{
			System.Windows.Forms.MenuItem mniPageAdd=new System.Windows.Forms.MenuItem();
			mniPageAdd.Index = 0;
			mniPageAdd.Text = "设置";
			mniPageAdd.Click += new System.EventHandler(mniPageAdd_Click);
			System.Windows.Forms.MenuItem mniPageRemove=new System.Windows.Forms.MenuItem();
			mniPageRemove.Index = 1;
			mniPageRemove.Text = "清除";
			mniPageRemove.Click += new System.EventHandler(mniPageRemove_Click);
			System.Windows.Forms.MenuItem menuItem1=new System.Windows.Forms.MenuItem();
			menuItem1.Index = 5;
			menuItem1.Text = "-";
			System.Windows.Forms.MenuItem menuItem2=new System.Windows.Forms.MenuItem();
			menuItem2.Index = 6;
			menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] 
			{
				mniPageAdd,
				mniPageRemove
			});
			menuItem2.Text = "设置分页";
			
			System.Windows.Forms.MenuItem menuItem3=new System.Windows.Forms.MenuItem();
			menuItem3.Index = 7;
			menuItem3.Text = "-";
			System.Windows.Forms.MenuItem mniAbnormalInfo=new System.Windows.Forms.MenuItem();
			mniAbnormalInfo.Index = 3;
			mniAbnormalInfo.Text = "异常信息";
			mniAbnormalInfo.Click += new System.EventHandler(this.mniAbnormalInfo_Click);
			mniAbnormalInfo.Enabled = true;
			this.ctmRecordControl.MenuItems.Add(menuItem1);
			this.ctmRecordControl.MenuItems.Add(menuItem2);
			this.ctmRecordControl.MenuItems.Add(menuItem3);
			this.ctmRecordControl.MenuItems.Add(mniAbnormalInfo);
				CreateDataGridStyle();
		}
		private clsInPatientEvaluateDomain m_objInPatientEvaluateDomain=new clsInPatientEvaluateDomain();
		private void mniAbnormalInfo_Click(object sender, System.EventArgs e)
		{
			string strAbnormalInfo;
			if(txtInPatientID.Text.Trim()=="" || this.m_trvInPatientDate.SelectedNode==null || this.m_trvInPatientDate.SelectedNode==m_trvInPatientDate.Nodes[0])
				return;
            long lngRes = m_objInPatientEvaluateDomain.m_lngGetAbnormalInfo(m_objCurrentPatient.m_StrInPatientID, m_objCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"), out strAbnormalInfo);
			if(lngRes<=0)
			{
				if(lngRes==(long)iCareData.enmOperationResult.Not_permission)
					m_mthShowNotPermitted();
				else m_mthShowDBError();
			}
			else 
			{
				frmMessageForm frmmessageform=new frmMessageForm("异常信息:",strAbnormalInfo);
				frmmessageform.ShowDialog();
			}
		}
		/// <summary>
		/// 添加分页标志
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniPageAdd_Click(object sender, System.EventArgs e)
		{
			m_mthSetPagination("1");
		}
		/// <summary>
		/// 删除分页标志
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void mniPageRemove_Click(object sender, System.EventArgs e)
		{
			m_mthSetPagination("0");
		}
		#endregion 添加异常信息

		#region 打印
		// 设置打印内容。
		protected override void m_mthSetPrintContent(clsTransDataInfo[] p_objTransDataArr,
			DateTime[] p_dtmFirstPrintDate)
		{
			if(p_objTransDataArr==null || p_dtmFirstPrintDate==null ||p_objTransDataArr.Length !=p_dtmFirstPrintDate.Length)
			{
				clsPublicFunction.ShowInformationMessageBox("打印数据有误!");
				return;
			}			

			//根据不同的表单类型，获取对应的clsDiseaseTrackInfo
			clsDiseaseTrackInfo objTrackInfo=null;
			m_objPrintDataArr = new clsPrintData[p_objTransDataArr.Length];
			for(int i=0;i<p_objTransDataArr.Length;i++)
			{

				objTrackInfo = new clsGeneralNurseRecordInfo();
		
				//设置clsDiseaseTrackInfo的内容
				objTrackInfo.m_ObjRecordContent = p_objTransDataArr[i].m_objRecordContent;
		
				m_objPrintDataArr[i]=new clsPrintData();
				//根据 clsDiseaseTrackInfo 获得的文本和Xml
				m_objPrintDataArr[i].m_strCreateDate = objTrackInfo.m_ObjRecordContent.m_dtmCreateDate.ToString();
				m_objPrintDataArr[i].m_strContent = objTrackInfo.m_strGetTrackText(); 
				m_objPrintDataArr[i].m_strContentXml = objTrackInfo.m_strGetTrackXml();
				
				string strSignText=objTrackInfo.m_strGetSignText();

				m_objPrintDataArr[i].m_strSign =  strSignText;				
				
				m_objPrintDataArr[i].m_dtmFirstPrintDate=p_dtmFirstPrintDate[i];
			}
		}

		// 初始化打印变量
		protected override void m_mthInitPrintTool()
		{			
			m_fotTitleFont = new Font("SimSun", 20,FontStyle.Bold );
			m_fotHeaderFont = new Font("SimSun", 18);
			m_fotSmallFont = new Font("SimSun",12);
			
			m_GridPen = new Pen(Color.Black,1);
			m_slbBrush = new SolidBrush(Color.Black);
		
			m_objPageSetting = new clsPrintPageSettingForRecord();

			m_objPrintContext = new com.digitalwave.controls.clsPrintRichTextContext(Color.Black,m_fotSmallFont);

			intCurrentRecord=0;
			intNowPage=1;
			blnBeginPrintNewRecord=true;		
		}

		// 释放打印变量
		protected override void m_mthDisposePrintTools()
		{
			m_fotTitleFont.Dispose();
			m_fotHeaderFont.Dispose();
			m_fotSmallFont.Dispose();
			m_GridPen.Dispose();
			m_slbBrush.Dispose();
		}

		/// <summary>
		///  开始打印。
		/// </summary>
		protected override void m_mthStartPrint()
		{
			if(m_blnDirectPrint)
			{
				m_pdcPrintDocument.Print();
			}
			else
			{
				((clsGeneralNurseRecordPrintTool)objPrintTool).m_mthPrintPage();
				
			}
//			base.m_mthStartPrint();
		}

		// 打印开始后，在打印页之前的操作
		protected override void m_mthBeginPrintSub(PrintEventArgs p_objPrintArg)
		{
		
		}

		// 打印页
		protected override void m_mthPrintPageSub(PrintPageEventArgs p_objPrintPageArg)
		{
			try
			{
				p_objPrintPageArg.HasMorePages =false;
				m_mthPrintTitleInfo(p_objPrintPageArg);	//e
				m_mthPrintRectangleInfo(p_objPrintPageArg);	
				m_mthPrintHeaderInfo(p_objPrintPageArg);				
				m_mthAddDataToGrid(p_objPrintPageArg);
				
			}
			catch(Exception err)
			{
				clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" + err.StackTrace);

			}
		}

		// 打印结束时的操作
		protected override void m_mthEndPrintSub(PrintEventArgs p_objPrintArg)
		{
		
		}

		#region 标题文字部分
		/// <summary>
		/// 标题文字部分
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintTitleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			clsEveryRecordPageInfo objEveryRecordPageInfo=new clsEveryRecordPageInfo ();
			//************************************************
			objEveryRecordPageInfo.strAge =m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjPeopleInfo.m_IntAge.ToString() : "";
			objEveryRecordPageInfo.strPatientName=m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjPeopleInfo.m_StrFirstName :"";
			objEveryRecordPageInfo.strBedNo =m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastBedInfo.m_ObjBed.m_StrBedName :"";			
			objEveryRecordPageInfo.strDeptName= m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjInBedInfo.m_ObjLastDeptInfo.m_ObjDept.m_StrDeptName : "";			
			objEveryRecordPageInfo.strSex=m_objCurrentPatient!=null? m_objCurrentPatient.m_ObjPeopleInfo.m_StrSex:"";
			objEveryRecordPageInfo.strInPatientID=m_objCurrentPatient!=null? m_objCurrentPatient.m_StrInPatientID:"";
			

            
			e.Graphics.DrawString(clsSystemContext.s_ObjCurrentContext.m_ObjHospitalInfo.m_StrHospitalTitle,m_fotSmallFont ,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_HospitalName  ));
		
			e.Graphics.DrawString("一   般   护   理   记   录",m_fotTitleFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Page_Name_Title ));
			

			e.Graphics.DrawString("姓名:",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name_Title  ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strPatientName  ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Name ));
		
			e.Graphics.DrawString("性别:",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strSex ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Sex  ));

			e.Graphics.DrawString("年龄:",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strAge ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Age ));

			e.Graphics.DrawString("科室:",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strDeptName ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.Dept_Name ));

			e.Graphics.DrawString("床号:",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strBedNo ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.BedNo ));	
			
			e.Graphics.DrawString("住院号:",m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID_Title ));
			e.Graphics.DrawString(objEveryRecordPageInfo.strInPatientID ,m_fotSmallFont,m_slbBrush,m_objPageSetting.m_getCoordinatePoint((int)enmItemDefination.InPatientID ));	
		}
		#endregion		

		#region 画标题的栏目
		/// <summary>
		/// 画标题的栏目
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintHeaderInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{
			
			e.Graphics.DrawString("记录时间",m_fotHeaderFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+1,
				(int)enmRecordRectangleInfo.TopY+2);
		     
			e.Graphics.DrawString("护 理 记 录",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark1+185, (int)enmRecordRectangleInfo.TopY+2);
	
			e.Graphics.DrawString("签名",m_fotHeaderFont,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+
				(int)enmRecordRectangleInfo.ColumnsMark2+1,(int)enmRecordRectangleInfo.TopY+2);
		}
		#endregion

		#region 画格子
		/// <summary>
		///  画格子
		/// </summary>
		/// <param name="e"></param>
		private void m_mthPrintRectangleInfo(System.Drawing.Printing.PrintPageEventArgs e)
		{	
			//画格子横线
			for(int i1=0;i1<=(int)enmRecordRectangleInfo.RowLinesNum ;i1++)
			{
				e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX ,
					(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1,
					(int)enmRecordRectangleInfo.RightX,
					(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowStep)*i1);
			}

			//画格子竖线
			
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX,(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1,(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2,(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep);
			e.Graphics.DrawLine(m_GridPen,(int)enmRecordRectangleInfo.RightX ,(int)enmRecordRectangleInfo.TopY,
				(int)enmRecordRectangleInfo.RightX,(int)enmRecordRectangleInfo.TopY+((int)enmRecordRectangleInfo.RowLinesNum)*(int)enmRecordRectangleInfo.RowStep);
		}

						
		#endregion

		#region 填充数据到表格
		/// <summary>
		/// 填充数据到表格
		/// </summary>
		/// <param name="e"></param>
		private void m_mthAddDataToGrid(System.Drawing.Printing.PrintPageEventArgs e)
		{
			try
			{
				int intPrintLenth=(int) ((float)enmRecordRectangleInfo.RecordLineLength/17.5)+1; /*每行显示的汉字的数目*/				
				string strRecord="";
				string strRecordXML="";				
				DateTime dtmFlagTime;
			
				int intNowRow=1; /*记录该页当前的打印的行*/

				//页脚//////////////////////////////////////////////////////////////
				e.Graphics.DrawString("（第"+intNowPage.ToString()+"页）",m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2 ,
					(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*((int)enmRecordRectangleInfo.RowLinesNum+1)+10 );
      
				if(m_objCurrentPatient ==null || m_objPrintDataArr == null)	return;
				for(;intCurrentRecord<m_objPrintDataArr.Length;intCurrentRecord++)	//不作初始化
				{	
					#region 如果是新记录，打印日期，设置打印数据值
					if(blnBeginPrintNewRecord)
					{	
						//打印日期
						e.Graphics.DrawString(m_objPrintDataArr[intCurrentRecord].m_strCreateDate,m_fotSmallFont ,m_slbBrush,
							(int)enmRecordRectangleInfo.LeftX+1, 
							(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*intNowRow + 20);						

						strRecord =m_objPrintDataArr[intCurrentRecord].m_strContent;
						strRecordXML=m_objPrintDataArr[intCurrentRecord].m_strContentXml;
					
						//打印一条记录/////////////////////////////////////////////////////////////////////
						/*修改打印内容方式（以第一次打印时间为分割，该时间后的所有修改的痕迹都要保留，如从未打印过则显示正确的记录）*/				
						if(m_objPrintDataArr[intCurrentRecord].m_dtmFirstPrintDate==DateTime.MinValue)
							dtmFlagTime=DateTime.Parse(new clsPublicDomain().m_strGetServerTime());					
						else 
							dtmFlagTime=m_objPrintDataArr[intCurrentRecord].m_dtmFirstPrintDate;
											
						m_objPrintContext.m_mthSetContextWithCorrectBefore(strRecord,strRecordXML,dtmFlagTime);					
						
						com.digitalwave.controls.ctlRichTextBox.clsModifyUserInfo[] m_objModifyUserArr = m_objPrintContext.m_ObjModifyUserArr;

						for(int i=0;i< m_objModifyUserArr.Length;i++)
						{
							if(m_objModifyUserArr[i].m_clrText.ToArgb() == Color.White.ToArgb())
							{
								m_objModifyUserArr[i].m_clrText = Color.Black;
							}
						}

					}
					#endregion

					#region 将当前记录除签名外全部打完或中途换页跳出	
					while(m_objPrintContext.m_BlnHaveNextLine())//判断该条记录是否还有下一行
					{
						if(m_blnCheckPageChange(intNowRow,e)==true) //每打印一行之前都要检查是否换页
							return;

						m_objPrintContext.m_mthPrintLine((int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark1, 
							(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*intNowRow + 20,e.Graphics,intPrintLenth);
											

						//当至少有一行有数据没有打完时，当前行才增加
						if(m_objPrintContext.m_BlnHaveNextLine())
						{
							blnBeginPrintNewRecord=false;//当前记录没有打完
							intNowRow ++;//向下滚行
						}
					}					
					#endregion
					
					#region 签名
					e.Graphics.DrawString(m_objPrintDataArr[intCurrentRecord].m_strSign,m_fotSmallFont ,m_slbBrush,(int)enmRecordRectangleInfo.LeftX+(int)enmRecordRectangleInfo.ColumnsMark2+1, 
						(int)enmRecordRectangleInfo.TopY+(int)enmRecordRectangleInfo.RowStep*intNowRow + 20);//+8);					
					blnBeginPrintNewRecord=true;  //当前记录打完	
					intNowRow ++;//向下滚行
					#endregion
				}
			
				#region 打印完毕，ReSet(复位)操作
				if(intCurrentRecord==m_objPrintDataArr.Length)
				{				
					intCurrentRecord=0;//当前记录的序号复位，以备下一次打印操作
					blnBeginPrintNewRecord=true;//复位
					intNowPage=1;//复位						
				}
				#endregion

			}
			catch(Exception err)
			{
				clsPublicFunction.ShowInformationMessageBox(err.Message + "\r\n" +err.StackTrace);
			}
		}	

		/// <summary>
		/// 检查是否换页,true:换页，false:不换页
		/// </summary>
		/// <param name="p_intNowRow">当前打印行，第p_intNowRow行</param>
		/// <param name="e"></param>
		/// <returns></returns>
		private bool m_blnCheckPageChange(int p_intNowRow,System.Drawing.Printing.PrintPageEventArgs e)
		{
			//当当前行超过最后一行（即 >页总行数）时换页
			if(p_intNowRow>(int)enmRecordRectangleInfo.RowLinesNum-1/*除去表头1行外总有效行数*/) 
			{
				e.HasMorePages =true;
				intNowPage ++;

				return true;
			}
			else return false;
		}

		
		#endregion 
	
	    #region 定义打印各元素的坐标点
		protected class clsPrintPageSettingForRecord
		{	
			public clsPrintPageSettingForRecord(){}
			
			/// <summary>
			/// 获得坐标点
			/// </summary>
			/// <param name="p_intItemName">项目名称</param>
			/// <returns></returns>
			public PointF m_getCoordinatePoint(int p_intItemName)
			{
				PointF m_fReturnPoint;
				switch(p_intItemName)
				{   
                    
					case (int)enmItemDefination.Page_HospitalName:
						m_fReturnPoint = new PointF(320f,30f);
						break;
					case (int)enmItemDefination.Page_Name_Title:
						m_fReturnPoint = new PointF(225f,70f);
						break;
					case (int)enmItemDefination.Name_Title :
						m_fReturnPoint = new PointF(20f,120f);
						break;
					case (int)enmItemDefination.Name:
						m_fReturnPoint = new PointF(70f,120f);
						break;

					case (int)enmItemDefination.Sex_Title :
						m_fReturnPoint = new PointF(150f,120f);
						break;
					case (int)enmItemDefination.Sex :
						m_fReturnPoint = new PointF(200f,120f);
						break;

					case (int)enmItemDefination.Age_Title :
						m_fReturnPoint = new PointF(250f,120f);
						break;
					case (int)enmItemDefination.Age:
						m_fReturnPoint = new PointF(300f,120f);
						break;

					case (int)enmItemDefination.Dept_Name_Title:
						m_fReturnPoint = new PointF(350f,120f);
						break;
					case (int)enmItemDefination.Dept_Name :
						m_fReturnPoint = new PointF(400f,120f);
						break;
					
					case (int)enmItemDefination.BedNo_Title :
						m_fReturnPoint = new PointF(550f,120f);
						break;
					case (int)enmItemDefination.BedNo:
						m_fReturnPoint = new PointF(600f,120f);
						break;

					case (int)enmItemDefination.InPatientID_Title:
						m_fReturnPoint = new PointF(650f,120f);
						break;
					case (int)enmItemDefination.InPatientID :
						m_fReturnPoint = new PointF(710f,120f);
						break;
											
					default:
						m_fReturnPoint = new PointF(400f,400f);
						break;
	
				}
				return m_fReturnPoint;
			}
		}

	    #endregion
		#endregion 打印

		/// <summary>
		/// 获取当前病人的作废内容
		/// </summary>
		/// <param name="p_dtmRecordDate">记录日期</param>
		/// <param name="p_intFormID">窗体ID</param>
		protected override void m_mthGetDeactiveContent(DateTime p_dtmRecordDate,int p_intFormID)
		{			
			m_mthGetDeletedRecord(p_intFormID,p_dtmRecordDate);
		}

		private void m_cmdThreeMeasure_Click(object sender, System.EventArgs e)
		{
			if(m_objBaseCurrentPatient == null)
			{
				clsPublicFunction.ShowInformationMessageBox("请先选择病人！");
				return;
			}
			m_mthSwitchToSpecialForm(m_objBaseCurrentPatient);
		}

		/// <summary>
		/// 切换至特定表单
		/// </summary>
		/// <param name="p_objPatient"></param>
		private void m_mthSwitchToSpecialForm(clsPatient p_objPatient)
		{
			try
			{
				this.Cursor=Cursors.WaitCursor;
				Form frm;
//				frmThreeMeasureRecord frmChild;
//				frmThreeMeasureRecordGN frmChild;
				for(int i = 0; i < this.MdiParent.MdiChildren.Length; i++)
				{
//					frmChild = this.MdiParent.MdiChildren[i] as frmThreeMeasureRecord;
//					frmChild = this.MdiParent.MdiChildren[i] as frmThreeMeasureRecordGN;
					frm = this.MdiParent.MdiChildren[i];
					if((frm is frmThreeMeasureRecord) || (frm is frmThreeMeasureRecordGN))
					{
						frm.WindowState = FormWindowState.Normal;
						frm.WindowState = FormWindowState.Maximized;
						this.MdiParent.MdiChildren[i].Activate();
						this.Cursor=Cursors.Default;//Cursor得特别注意哦
						return;
					}
				}
				if(clsEMRLogin.m_StrCurrentHospitalNO == "450101001")//南宁
				{
					//				frmChild = new frmThreeMeasureRecord();
					frmThreeMeasureRecordGN frmChild = new frmThreeMeasureRecordGN();
					frmChild.MdiParent = this.MdiParent;
					frmChild.m_mthDisableSelectPatient(false);
					frmChild.Show(); 
					frmChild.m_mthSetPatient(p_objPatient);
				}
				else
				{
					frmThreeMeasureRecord frmChild = new frmThreeMeasureRecord();
					frmChild.MdiParent = this.MdiParent;
					frmChild.m_mthDisableSelectPatient(false);
					frmChild.Show(); 
					frmChild.m_mthSetPatient(p_objPatient);
				}
			}
			catch
			{}
            finally
            {
                this.Cursor = Cursors.Default;
            }
		}

        #region 作废重做
        protected override bool m_blnSubReuse(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            bool blnIsOK = false;
            if (m_blnSubIsExists())
            {
                return blnIsOK;
            }
            if (p_objSelectedValue != null)
            {
                m_mthGetDeletedRecord(-1, p_objSelectedValue.m_DtmOpenDate);
                blnIsOK = true;
            }
            return blnIsOK;
        }

        protected override clsInactiveRecordInfo_VO[] m_objSubGetAllInactiveInfo(clsInactiveRecordInfo_VO p_objSelectedValue)
        {
            clsInactiveRecordInfo_VO[] objArr = null;
            m_objGetRecordsDomain().m_lngGetAllInactiveInfo(null,p_objSelectedValue.m_StrInpatientId, p_objSelectedValue.m_DtmInpatientDate, out objArr);
            return objArr;
        }
        public override bool m_blnIsNewSetInactiveForm
        {
            get { return true; }
        }
        #endregion 作废重做

	}

}

