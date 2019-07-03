using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.IntensiveTendRecordService;
using com.digitalwave.Utility.Controls;
using iCare.iCareBaseForm;
using com.digitalwave.Emr.Signature_gui;
namespace iCare
{
	/// <summary>
	/// 病情、护理措施、效果及签名
	/// </summary>
	public class frmIntensiveTend_FContent :   frmDiseaseTrackBase
	{
		private System.Windows.Forms.Label lblEmployeeSign;
		protected System.Windows.Forms.ListView m_lsvEmployee;
		private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.Label lblRecordContentTitle;
		private com.digitalwave.controls.ctlRichTextBox m_txtRecordContent;
		private PinkieControls.ButtonXP m_cmdOK;
		private PinkieControls.ButtonXP m_cmdCancel;
		private clsEmployeeSignTool m_objSignTool;
		private bool blnNewRecord;
		private string strRecordInPatientID;
		private string strRecordInPatientDate;
		private string strRecordCreateDate;
		protected clsTemplatesetInvoke m_objTempTool;
		private System.Windows.Forms.ToolTip m_ttpTextInfo;
		private System.ComponentModel.IContainer components;
        private PinkieControls.ButtonXP cmdSign;
		private frmHRPBaseForm objHRPBaseForm;
        private TextBox txtSign;
        //定义签名类
        private clsEmrSignToolCollection m_objSign;
		public frmIntensiveTend_FContent(bool blnNew,string p_strInPatientID,string p_strInPatientDate,string p_strCreateDate)
		{
			//
			// Windows 窗体设计器支持所必需的
			//
			InitializeComponent();

			//
			// TODO: 在 InitializeComponent 调用后添加任何构造函数代码
			//
//			m_lblSign.Text=MDIParent.OperatorName;
//			m_mthSetRichTextBoxAttribInControl(this);
            //m_objBorderTool=new clsBorderTool(Color.White);
            //m_objSignTool = new clsEmployeeSignTool(m_lsvEmployee);
            //m_objSignTool.m_mthAddControl(m_txtSign);
            m_objSign = new clsEmrSignToolCollection();
            m_objSign.m_mthBindEmployeeSign(cmdSign , txtSign, 2, true, clsEMRLogin.LoginInfo.m_strEmpID);
            
			//初始化变量值
			blnNewRecord=blnNew;
			strRecordInPatientID=p_strInPatientID;
			strRecordInPatientDate=p_strInPatientDate;
			strRecordCreateDate=p_strCreateDate;
			m_mthSetRichTextBoxAttribInControl(this);
			//右键菜单
			m_objTempTool = new clsTemplatesetInvoke();
			objHRPBaseForm = new frmHRPBaseForm();
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
            this.lblEmployeeSign = new System.Windows.Forms.Label();
            this.m_lsvEmployee = new System.Windows.Forms.ListView();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.lblRecordContentTitle = new System.Windows.Forms.Label();
            this.m_txtRecordContent = new com.digitalwave.controls.ctlRichTextBox();
            this.m_cmdOK = new PinkieControls.ButtonXP();
            this.m_cmdCancel = new PinkieControls.ButtonXP();
            this.m_ttpTextInfo = new System.Windows.Forms.ToolTip(this.components);
            this.cmdSign = new PinkieControls.ButtonXP();
            this.txtSign = new System.Windows.Forms.TextBox();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_trvCreateDate
            // 
            this.m_trvCreateDate.LineColor = System.Drawing.Color.Black;
            this.m_trvCreateDate.Location = new System.Drawing.Point(546, -5);
            this.m_trvCreateDate.Size = new System.Drawing.Size(3, 3);
            this.m_trvCreateDate.Visible = false;
            // 
            // lblCreateDateTitle
            // 
            this.lblCreateDateTitle.Location = new System.Drawing.Point(10, 14);
            // 
            // m_dtpCreateDate
            // 
            this.m_dtpCreateDate.Location = new System.Drawing.Point(84, 14);
            // 
            // m_dtpGetDataTime
            // 
            this.m_dtpGetDataTime.Location = new System.Drawing.Point(484, -21);
            this.m_dtpGetDataTime.Size = new System.Drawing.Size(3, 22);
            // 
            // m_lblGetDataTime
            // 
            this.m_lblGetDataTime.AutoSize = false;
            this.m_lblGetDataTime.Location = new System.Drawing.Point(600, 46);
            this.m_lblGetDataTime.Size = new System.Drawing.Size(3, 3);
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(542, -19);
            this.lblSex.Size = new System.Drawing.Size(3, 3);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(526, 48);
            this.lblAge.Size = new System.Drawing.Size(3, 6);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.AutoSize = false;
            this.lblBedNoTitle.Location = new System.Drawing.Point(490, -21);
            this.lblBedNoTitle.Size = new System.Drawing.Size(3, 3);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.AutoSize = false;
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(386, -19);
            this.lblInHospitalNoTitle.Size = new System.Drawing.Size(3, 3);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.AutoSize = false;
            this.lblNameTitle.Location = new System.Drawing.Point(478, -23);
            this.lblNameTitle.Size = new System.Drawing.Size(3, 3);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.AutoSize = false;
            this.lblSexTitle.Location = new System.Drawing.Point(486, -19);
            this.lblSexTitle.Size = new System.Drawing.Size(3, 3);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.AutoSize = false;
            this.lblAgeTitle.Location = new System.Drawing.Point(612, -19);
            this.lblAgeTitle.Size = new System.Drawing.Size(3, 3);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.AutoSize = false;
            this.lblAreaTitle.Location = new System.Drawing.Point(498, -31);
            this.lblAreaTitle.Size = new System.Drawing.Size(3, 3);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(478, 54);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(135, 119);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(526, -17);
            this.txtInPatientID.Size = new System.Drawing.Size(3, 23);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(529, -27);
            this.m_txtPatientName.Size = new System.Drawing.Size(3, 23);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(406, -27);
            this.m_txtBedNO.Size = new System.Drawing.Size(3, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(544, -17);
            this.m_cboArea.Size = new System.Drawing.Size(3, 23);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(334, 50);
            this.m_lsvPatientName.Size = new System.Drawing.Size(136, 119);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(478, 14);
            this.m_lsvBedNO.Size = new System.Drawing.Size(135, 119);
            this.m_lsvBedNO.Visible = false;
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(554, -23);
            this.m_cboDept.Size = new System.Drawing.Size(3, 23);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.AutoSize = false;
            this.lblDept.Location = new System.Drawing.Point(488, -17);
            this.lblDept.Size = new System.Drawing.Size(3, 3);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(574, 14);
            this.m_cmdNewTemplate.Size = new System.Drawing.Size(98, 36);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Location = new System.Drawing.Point(438, -27);
            this.m_cmdNext.Size = new System.Drawing.Size(28, 24);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Location = new System.Drawing.Point(376, -21);
            this.m_cmdPre.Size = new System.Drawing.Size(28, 24);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(594, -19);
            this.m_lblForTitle.Size = new System.Drawing.Size(3, 3);
            this.m_lblForTitle.Visible = true;
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(463, -50);
            this.m_tipMain.SetToolTip(this.m_cmdModifyPatientInfo, "点击查看和修改患者详细信息(快捷键Alt+P)");
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            // 
            // lblEmployeeSign
            // 
            this.lblEmployeeSign.AutoSize = true;
            this.lblEmployeeSign.BackColor = System.Drawing.SystemColors.Control;
            this.lblEmployeeSign.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblEmployeeSign.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblEmployeeSign.Location = new System.Drawing.Point(200, 382);
            this.lblEmployeeSign.Name = "lblEmployeeSign";
            this.lblEmployeeSign.Size = new System.Drawing.Size(42, 14);
            this.lblEmployeeSign.TabIndex = 10000028;
            this.lblEmployeeSign.Text = "签名:";
            this.lblEmployeeSign.Visible = false;
            // 
            // m_lsvEmployee
            // 
            this.m_lsvEmployee.BackColor = System.Drawing.Color.White;
            this.m_lsvEmployee.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lsvEmployee.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.m_lsvEmployee.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lsvEmployee.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_lsvEmployee.FullRowSelect = true;
            this.m_lsvEmployee.GridLines = true;
            this.m_lsvEmployee.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_lsvEmployee.Location = new System.Drawing.Point(86, 254);
            this.m_lsvEmployee.Name = "m_lsvEmployee";
            this.m_lsvEmployee.Size = new System.Drawing.Size(119, 120);
            this.m_lsvEmployee.TabIndex = 10000027;
            this.m_lsvEmployee.UseCompatibleStateImageBehavior = false;
            this.m_lsvEmployee.View = System.Windows.Forms.View.Details;
            this.m_lsvEmployee.Visible = false;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Width = 100;
            // 
            // lblRecordContentTitle
            // 
            this.lblRecordContentTitle.AutoSize = true;
            this.lblRecordContentTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblRecordContentTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblRecordContentTitle.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblRecordContentTitle.Location = new System.Drawing.Point(9, 41);
            this.lblRecordContentTitle.Name = "lblRecordContentTitle";
            this.lblRecordContentTitle.Size = new System.Drawing.Size(70, 14);
            this.lblRecordContentTitle.TabIndex = 10000024;
            this.lblRecordContentTitle.Text = "记录内容:";
            // 
            // m_txtRecordContent
            // 
            this.m_txtRecordContent.AccessibleDescription = "记录内容";
            this.m_txtRecordContent.BackColor = System.Drawing.Color.White;
            this.m_txtRecordContent.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_txtRecordContent.ForeColor = System.Drawing.SystemColors.WindowText;
            this.m_txtRecordContent.ImeMode = System.Windows.Forms.ImeMode.On;
            this.m_txtRecordContent.Location = new System.Drawing.Point(9, 68);
            this.m_txtRecordContent.m_BlnIgnoreUserInfo = false;
            this.m_txtRecordContent.m_BlnPartControl = false;
            this.m_txtRecordContent.m_BlnReadOnly = false;
            this.m_txtRecordContent.m_BlnUnderLineDST = false;
            this.m_txtRecordContent.m_ClrDST = System.Drawing.Color.Red;
            this.m_txtRecordContent.m_ClrOldPartInsertText = System.Drawing.Color.Black;
            this.m_txtRecordContent.m_IntCanModifyTime = 6;
            this.m_txtRecordContent.m_IntPartControlLength = 0;
            this.m_txtRecordContent.m_IntPartControlStartIndex = 0;
            this.m_txtRecordContent.m_StrUserID = "";
            this.m_txtRecordContent.m_StrUserName = "";
            this.m_txtRecordContent.Name = "m_txtRecordContent";
            this.m_txtRecordContent.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.m_txtRecordContent.Size = new System.Drawing.Size(771, 298);
            this.m_txtRecordContent.TabIndex = 15;
            this.m_txtRecordContent.Text = "";
            // 
            // m_cmdOK
            // 
            this.m_cmdOK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdOK.DefaultScheme = true;
            this.m_cmdOK.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdOK.Hint = "";
            this.m_cmdOK.Location = new System.Drawing.Point(602, 376);
            this.m_cmdOK.Name = "m_cmdOK";
            this.m_cmdOK.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdOK.Size = new System.Drawing.Size(74, 36);
            this.m_cmdOK.TabIndex = 25;
            this.m_cmdOK.Text = "确定";
            this.m_cmdOK.Click += new System.EventHandler(this.m_cmdOK_Click);
            // 
            // m_cmdCancel
            // 
            this.m_cmdCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancel.DefaultScheme = true;
            this.m_cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_cmdCancel.Hint = "";
            this.m_cmdCancel.Location = new System.Drawing.Point(696, 376);
            this.m_cmdCancel.Name = "m_cmdCancel";
            this.m_cmdCancel.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancel.Size = new System.Drawing.Size(75, 36);
            this.m_cmdCancel.TabIndex = 30;
            this.m_cmdCancel.Text = "取消";
            this.m_cmdCancel.Click += new System.EventHandler(this.m_cmdCancel_Click);
            // 
            // m_ttpTextInfo
            // 
            this.m_ttpTextInfo.AutomaticDelay = 200;
            // 
            // cmdSign
            // 
            this.cmdSign.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.cmdSign.DefaultScheme = true;
            this.cmdSign.DialogResult = System.Windows.Forms.DialogResult.None;
            this.cmdSign.Hint = "";
            this.cmdSign.Location = new System.Drawing.Point(9, 375);
            this.cmdSign.Name = "cmdSign";
            this.cmdSign.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.cmdSign.Size = new System.Drawing.Size(74, 26);
            this.cmdSign.TabIndex = 25;
            this.cmdSign.Text = "签名：";
            // 
            // txtSign
            // 
            this.txtSign.AccessibleDescription = "签名";
            this.txtSign.Location = new System.Drawing.Point(86, 376);
            this.txtSign.Name = "txtSign";
            this.txtSign.Size = new System.Drawing.Size(181, 23);
            this.txtSign.TabIndex = 10000029;
            // 
            // frmIntensiveTend_FContent
            // 
            this.AccessibleDescription = "病情、护理措施、效果";
            this.ClientSize = new System.Drawing.Size(796, 425);
            this.Controls.Add(this.lblEmployeeSign);
            this.Controls.Add(this.lblRecordContentTitle);
            this.Controls.Add(this.m_cmdOK);
            this.Controls.Add(this.m_cmdCancel);
            this.Controls.Add(this.m_lsvEmployee);
            this.Controls.Add(this.m_txtRecordContent);
            this.Controls.Add(this.txtSign);
            this.Controls.Add(this.cmdSign);
            this.MaximizeBox = false;
            this.Name = "frmIntensiveTend_FContent";
            this.Text = "病情、护理措施、效果及签名";
            this.Load += new System.EventHandler(this.frmIntensiveTend_FContent_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.m_dtpGetDataTime, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.m_trvCreateDate, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.cmdSign, 0);
            this.Controls.SetChildIndex(this.m_dtpCreateDate, 0);
            this.Controls.SetChildIndex(this.lblCreateDateTitle, 0);
            this.Controls.SetChildIndex(this.txtSign, 0);
            this.Controls.SetChildIndex(this.m_txtRecordContent, 0);
            this.Controls.SetChildIndex(this.m_lsvEmployee, 0);
            this.Controls.SetChildIndex(this.m_cmdCancel, 0);
            this.Controls.SetChildIndex(this.m_cmdOK, 0);
            this.Controls.SetChildIndex(this.lblRecordContentTitle, 0);
            this.Controls.SetChildIndex(this.lblEmployeeSign, 0);
            this.Controls.SetChildIndex(this.m_lblGetDataTime, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		public override int m_IntFormID
		{
			get
			{
				return 106;
			}
		}

		#region 方法
		// <summary>
		/// 清空特殊记录信息，并重置记录控制状态为不控制。
		/// </summary>
		private  void m_mthClearRecordInfo()
		{
			//清空记录内容			
			m_txtRecordContent.m_mthClearText();	
            //m_objSignTool.m_mthSetDefaulEmployee();
			m_dtpCreateDate.Value=DateTime.Now;
			m_mthSetModifyControl(null,true);
            MDIParent.m_mthSetDefaulEmployee(txtSign);
		}
		
		/// <summary>
		/// 保存
		/// </summary>
		/// <returns></returns>
		private long m_lngSave()
		{
			long lngRes=0;
			try
			{
				//获取服务器时间
				string strTimeNow=new clsPublicDomain().m_strGetServerTime();
				//从界面获取表单值		
                clsCourseDiseasesRecord objContent = new clsCourseDiseasesRecord();
				objContent.m_strInPatientID=strRecordInPatientID;
				objContent.m_dtmInPatientDate=DateTime.Parse(strRecordInPatientDate);
				objContent.m_dtmOpenDate=DateTime.Parse(strTimeNow);
				objContent.m_dtmCreateDate=m_dtpCreateDate.Value;
				objContent.m_strDiseasesRecordContent=m_txtRecordContent.Text;
                //objContent.m_strRecordContent_Right = m_txtRecordContent.m_strGetRightText();
				objContent.m_strDiseasesRecordContentXml=m_txtRecordContent.m_strGetXmlText();
				objContent.m_strClass=GetClassWith(m_dtpCreateDate.Value);
                objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                objContent.m_strCreateUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
				clsIntensiveTendRecordService objserv=new clsIntensiveTendRecordService();
                //电子签名 
                //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strInPatientID.Trim() + "-" + objContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"); ;
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                    return -1;
				lngRes=objserv.m_lngAddNewRecordContent(objContent);
			}
			catch (Exception ex)
			{
				string strMsg=ex.Message;
			}
			return lngRes;
		}
		/// <summary>
		/// 修改
		/// </summary>
		/// <returns></returns>
		private long m_lngModify()
		{
			long lngRes=0;
			try
			{
				//从界面获取表单值		
                clsCourseDiseasesRecord objContent = new clsCourseDiseasesRecord();
				objContent.m_strInPatientID=strRecordInPatientID;
				objContent.m_dtmInPatientDate=DateTime.Parse(strRecordInPatientDate);
				objContent.m_dtmOpenDate=DateTime.Now;
				objContent.m_dtmCreateDate=DateTime.Parse(strRecordCreateDate);
				objContent.m_strDiseasesRecordContent=m_txtRecordContent.Text;
				objContent.m_strDiseasesRecordContentXml=m_txtRecordContent.m_strGetXmlText ();
				//签名
                //foreach(Control ctlSub in this.Controls)
                //{
                //    if(ctlSub.Name=="m_txtSign")
                //    {
                objContent.m_strModifyUserID = ((clsEmrEmployeeBase_VO)txtSign.Tag).m_strEMPNO_CHR;
                //    }
                //}

				clsIntensiveTendRecordService objserv=new clsIntensiveTendRecordService();
                //电子签名 
                //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20
                clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
                objSign_VO.m_strFORMID_VCHR = this.Name;
                objSign_VO.m_strFORMRECORDID_VCHR = objContent.m_strInPatientID.Trim() + "-" + objContent.m_dtmInPatientDate.ToString("yyyy-MM-dd HH:mm:ss"); 
                objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
                objSign_VO.m_strRegisterId = m_objBaseCurrentPatient.m_StrRegisterId;
                clsCheckSignersController objCheck = new clsCheckSignersController();
                if (objCheck.m_lngSign(objContent, objSign_VO) == -1)
                    return -1;
				lngRes=objserv.m_lngModifyRecordContent(objContent);
			}
			catch (Exception ex)
			{
				string strMsg=ex.Message;
			}
			return lngRes;
		}
		/// <summary>
		/// 获取
		/// </summary>
		private void m_GetDataFromDB()
		{
			long lngRes=0;
 			try
			{
				string[] DataArr;
				clsIntensiveTendRecordService objserv=new clsIntensiveTendRecordService();
				lngRes=objserv.m_lngGetRecordContent(strRecordInPatientID,strRecordInPatientDate,strRecordCreateDate,out DataArr);
				//赋值到表单
				m_txtRecordContent.m_mthSetNewText(DataArr[3],DataArr[4]);	
				m_dtpCreateDate.Value=DateTime.Parse(DataArr[0]);
				m_mthAddSignToTextBoxByEmpNo(new TextBoxBase[] { txtSign, }, new string[] {DataArr[1] }, new bool[] { false });
					
				m_mthSetModifyControl(DataArr[1],false);
			}
			catch (Exception ex)
			{
				string strMsg=ex.Message;
			}
 		}

		private string GetClassWith(DateTime dt)
        {
            //佛二每天早上8:00统计（全天统计一次，不分班次）--wf20080116
            DateTime dtClass = DateTime.Parse(dt.ToString("yyyy-MM-dd HH:mm:00"));
            DateTime dt0 = DateTime.Parse(dtClass.ToString("yyyy-MM-dd 08:00:00"));//每天早8点开始统计
            if (dtClass > dt0)
                return dtClass.ToString("yyyy-MM-dd");
            else
                return dtClass.AddDays(-1).ToString("yyyy-MM-dd");
            #region 屏蔽
            /*
            try
			{
				DateTime dtClass= DateTime.Parse(dt.ToString("yyyy-MM-dd HH:mm:00"));
				DateTime dt0=DateTime.Parse(dtClass.ToString("yyyy-MM-dd 00:00:00"));
				DateTime dt1=dt0.AddHours(1);
				DateTime dt2=dt0.AddHours(8);
				DateTime dt3=dt0.AddHours(18);
				DateTime dt4=dt0.AddHours(25);
				DateTime dt5=dt0.AddHours(31);
				if (dtClass>dt1 && dtClass<=dt2)
					return dt1.AddDays(-1).ToString("yyy-MM-dd")+"-2";
				if (dtClass>dt2 && dtClass<=dt3)
					return dt2.ToString("yyy-MM-dd")+"-0";
				if (dtClass>dt3 && dtClass<=dt4)
					return dt3.ToString("yyy-MM-dd")+"-1";
			
			}
			catch (Exception exp)
			{
				string strError=exp.Message;
				return "";
			}
			return "";
		*/
            #endregion
        }
		#endregion ;
		/// <summary>
		/// 确定事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_cmdOK_Click(object sender, System.EventArgs e)
		{
			if (blnNewRecord)
			{
				if (m_lngSave()>0)
				{
					this.DialogResult = DialogResult.Yes;
					this.Close();
				}

			}
			else
			{
				if (m_lngModify()>0)
				{
					this.DialogResult = DialogResult.Yes;
					this.Close();
				}			
			}
		
		}
		/// <summary>
		/// 取消事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void m_cmdCancel_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.None;
			this.Close();
		}
		/// <summary>
		/// 启动事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frmIntensiveTend_FContent_Load(object sender, System.EventArgs e)
		{

            if (blnNewRecord)
                //初始化
                m_mthClearRecordInfo();
            else
                m_GetDataFromDB();
			//右键菜单
			m_mthAddRichTemplateInContainer(this);	

		}

		#region ctlRichTextBox的双划线、其他属性设置
			private readonly DateTime m_dtmEmptyDate = new DateTime(1900,1,1);
        //protected clsBorderTool m_objBorderTool;
		/// <summary>
		/// 设置双划线
		/// </summary>
		protected void m_mthSetRichTextBoxDoubleStrike()
		{
			//获取RichTextBox        
			//ctlRichTextBox objRichTextBox = (ctlRichTextBox)m_ctmRichTextBoxMenu.SourceControl;
		
			//objRichTextBox.m_mthSelectionDoubleStrikeThough(true);
			if(m_txtFocusedRichTextBox!=null)
				m_txtFocusedRichTextBox.m_mthSelectionDoubleStrikeThough(true);			
		}

		/// <summary>
		/// 设置RichTextBox属性。（右键菜单、用户姓名、用户ID、颜色等）。
		/// </summary>
		/// <param name="p_objRichTextBox"></param>
		protected void m_mthSetRichTextBoxAttrib(com.digitalwave.controls.ctlRichTextBox p_objRichTextBox)
		{
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{	p_objRichTextBox });
			//设置右键菜单			
//						p_objRichTextBox.ContextMenu=m_cmuRichTextBoxMenu;
			p_objRichTextBox.GotFocus += new EventHandler(m_txtRichTextBox_GotFocus);
		
			//			ctlRichTextBox.m_ClrDefaultViewText=Color.Black;

			//设置其他属性			
			p_objRichTextBox.m_StrUserID = MDIParent.OperatorID;
			p_objRichTextBox.m_StrUserName = MDIParent.strOperatorName;
			p_objRichTextBox.m_ClrOldPartInsertText = Color.Black;
			p_objRichTextBox.m_ClrDST = Color.Red;
			p_objRichTextBox.ForeColor=SystemColors.WindowText;
		}

		protected void m_mthSetRichTextBoxAttribInControl(Control p_ctlControl)
		{
			if(p_ctlControl.GetType().Name=="ctlRichTextBox")
			{
				m_mthSetRichTextBoxAttrib((com.digitalwave.controls.ctlRichTextBox)p_ctlControl);
			}

			if(p_ctlControl.HasChildren && p_ctlControl.GetType().Name !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextBoxAttribInControl(subcontrol);						
				} 	
			}	
		}
		private void mniDoubleStrikeOutDelete_Click(object sender, System.EventArgs e)
		{
			m_mthSetRichTextBoxDoubleStrike();
		}
		private com.digitalwave.controls.ctlRichTextBox m_txtFocusedRichTextBox=null;//存放当前获得焦点的RichTextBox
		private void m_txtRichTextBox_GotFocus(object sender, System.EventArgs e)
		{
			m_txtFocusedRichTextBox=((com.digitalwave.controls.ctlRichTextBox)(sender));
		}

		/// <summary>
		/// 设置窗体中控件输入文本的颜色
		/// </summary>
		/// <param name="p_ctlControl"></param>
		/// <param name="p_clrColor"></param>
		private void m_mthSetRichTextModifyColor(Control p_ctlControl,System.Drawing.Color p_clrColor)
		{
			#region 设置控件输入文本的颜色,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")			
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_ClrOldPartInsertText = p_clrColor;				
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextModifyColor(subcontrol,p_clrColor);					
				} 	
			}						
			#endregion			
		}
		
		
		private void m_mthSetRichTextCanModifyLast(Control p_ctlControl,bool p_blnCanModifyLast )
		{
			#region 设置控件输入文本的是否最后修改,Jacky-2003-3-24	
			string strTypeName = p_ctlControl.GetType().Name;			
			if(strTypeName=="ctlRichTextBox")
			{				
				((com.digitalwave.controls.ctlRichTextBox)p_ctlControl).m_BlnCanModifyLast = p_blnCanModifyLast;
			}
			
			if(p_ctlControl.HasChildren && strTypeName !="DataGrid" )
			{									
				foreach(Control subcontrol in p_ctlControl.Controls)
				{										
					m_mthSetRichTextCanModifyLast(subcontrol,p_blnCanModifyLast);					
				} 	
			}						
			#endregion			
		}
	
		#endregion ctlRichTextBox的双划线、其他属性设置
		#region 通用右键菜单实现 
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_txtControl"></param>
		protected void m_mthAddRichTemplate(RichTextBox p_txtControl)
		{
			m_objTempTool.m_mthAddTextBox(this,p_txtControl,m_strGetCurFormName(),p_txtControl.Name);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_ctlContainer"></param>
		protected virtual void m_mthAddRichTemplateInContainer(Control p_ctlContainer)
		{
			foreach(Control ctlChild in p_ctlContainer.Controls)
			{
				if(ctlChild.Name == "" && ctlChild.GetType().FullName != "System.Windows.Forms.TabPage")
					continue;
				switch(ctlChild.GetType().FullName)
				{
					case "com.digitalwave.controls.ctlRichTextBox":
						m_mthAddRichTemplate((RichTextBox)ctlChild);
						m_mthAddRichTextInfo((com.digitalwave.controls.ctlRichTextBox)ctlChild);
						break;
					case "System.Windows.Forms.RichTextBox":
					case "iCare.CustomForm.ctlRichTextBox":
						m_mthAddRichTemplate((RichTextBox)ctlChild);
						break;
					default:
						m_mthAddRichTemplateInContainer(ctlChild);
						break;
				}				
			}
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="p_ctlTextBox"></param>
		protected void m_mthAddRichTextInfo(com.digitalwave.controls.ctlRichTextBox p_ctlTextBox)
		{
			p_ctlTextBox.m_evtMouseEnterDeleteText += new EventHandler(m_mthHandleMouseEnterDeleteText);
			p_ctlTextBox.m_evtMouseEnterInsertText += new EventHandler(m_mthHandleMouseEnterInsertText);
			p_ctlTextBox.MouseLeave += new EventHandler(m_mthHandleMouseLeaveControl);
		}

		/// <summary>
		/// 获取当前表单名,自定义表单特殊处理
		/// </summary>
		/// <returns></returns>
		private string m_strGetCurFormName()
		{
			string strFormName = this.Name;
			//			if(this is iCare.CustomForm.frmCustomFormBase)
			//				strFormName = ((iCare.CustomForm.frmCustomFormBase)this).m_strGetCurFormName();
			return strFormName;
		}
		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="p_objSender"></param>
		/// <param name="p_objArg"></param>
		private void m_mthHandleMouseEnterDeleteText(object p_objSender,EventArgs p_objArg)
		{
			com.digitalwave.controls.clsDoubleStrikeThoughEventArg objArg = (com.digitalwave.controls.clsDoubleStrikeThoughEventArg)p_objArg;

			string strInfo = "用户姓名 : "+
				objArg.m_strUserName+"\r\n删除时间 : ";

			if(objArg.m_dtmDeleteTime != m_dtmEmptyDate && objArg.m_dtmDeleteTime != DateTime.MinValue)
			{
				strInfo += objArg.m_dtmDeleteTime.ToLongDateString()+" "+objArg.m_dtmDeleteTime.ToLongTimeString();				
			}	
			else
			{
				strInfo += "----年--月--日 --:--:--";
			}
			
			m_ttpTextInfo.SetToolTip((Control)p_objSender,strInfo);
		}
		/// <summary>
		/// 新增信息
		/// </summary>
		/// <param name="p_objSender"></param>
		/// <param name="p_objArg"></param>
		private void m_mthHandleMouseEnterInsertText(object p_objSender,EventArgs p_objArg)
		{
			com.digitalwave.controls.clsInsertEventArg objArg = (com.digitalwave.controls.clsInsertEventArg)p_objArg;
			
			if(objArg.m_intUserSeq == 1)
			{
				return;
			}
			
			string strInfo = "用户姓名 : "+
				objArg.m_strUserName+"\r\n添加时间 : ";

			if(objArg.m_dtmInsertTime != m_dtmEmptyDate && objArg.m_dtmInsertTime != DateTime.MinValue)
			{
				strInfo += objArg.m_dtmInsertTime.ToLongDateString()+" "+objArg.m_dtmInsertTime.ToLongTimeString();				
			}	
			else
			{
				strInfo += "----年--月--日 --:--:--";
			}
			
			m_ttpTextInfo.SetToolTip((Control)p_objSender,strInfo);
		}
		/// <summary>
		/// 通用右键 离开事件
		/// </summary>
		/// <param name="p_objSender"></param>
		/// <param name="p_objArg"></param>
		private void m_mthHandleMouseLeaveControl(object p_objSender,EventArgs p_objArg)
			#endregion
		{
			m_ttpTextInfo.RemoveAll();
		}

		/// <summary>
		/// 设置是否控制修改（修改留痕迹）。
		/// </summary>
		/// <param name="p_objRecordContent"></param>
		/// <param name="p_blnReset"></param>
		protected void m_mthSetModifyControl(string p_strModifyUserID,
			bool p_blnReset)
		{
			//根据书写规范设置具体窗体的书写控制，由子窗体重载实现
			if(p_strModifyUserID!=null)
			{
				m_mthSetRichTextModifyColor(this,Color.Red);
				m_mthSetRichTextCanModifyLast(this,m_blnGetCanModifyLast(p_strModifyUserID));
			}
		}

		private bool m_blnGetCanModifyLast(string p_strModifyUserID)
		{			
			if(p_strModifyUserID==null || p_strModifyUserID.Trim() == MDIParent.OperatorID.Trim())
				return true;
			else 
				return false;
		}

		protected override void m_mthSetSelectedDeletedRecord(clsPatient p_objSelectedPatient,
			string p_strOpenDate)
		{
			//检查参数
			if(p_objSelectedPatient==null|| p_strOpenDate==null ||p_strOpenDate=="")
				return;

            clsCourseDiseasesRecord objContent;

            clsIntensiveTendRecordService objITRServ =
                (clsIntensiveTendRecordService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsIntensiveTendRecordService));

			//获取记录
			long lngRes = objITRServ.m_lngGetDelRecordContentWithInpatient(p_objSelectedPatient.m_StrInPatientID,p_objSelectedPatient.m_ObjInBedInfo.m_ObjLastSessionInfo.m_DtmInDate.ToString("yyyy-MM-dd HH:mm:ss"),p_strOpenDate ,out objContent);
            //objITRServ.Dispose();
			if(lngRes <= 0 || objContent == null)
				return;
            
           
			//设置当前记录及记录时间 
			m_objCurrentPatient=  p_objSelectedPatient;
			txtInPatientID.Text=this.m_objCurrentPatient.m_StrHISInPatientID;
					
			m_mthSetDeletedGUIFromContent(objContent);
		
		}

		protected override void m_mthSetDeletedGUIFromContent(iCareData.clsTrackRecordContent p_objContent)
		{
            clsCourseDiseasesRecord objContent = (clsCourseDiseasesRecord)p_objContent;
			//把表单值赋值到界面，由子窗体重载实现			

			this.m_mthClearRecordInfo();		
			//赋值到表单
			m_txtRecordContent.m_mthSetNewText(objContent.m_strDiseasesRecordContent,objContent.m_strDiseasesRecordContentXml);	
			m_dtpCreateDate.Value=objContent.m_dtmCreateDate;
			clsEmployee objEmployee=new clsEmployee(objContent.m_strModifyUserID);
			if(objEmployee !=null)
			{
				txtSign.Text=objEmployee.m_StrLastName;
				txtSign.Tag=objEmployee;
			}
			this.txtSign.Enabled = false;
			this.m_dtpCreateDate.Enabled = false;
        }
        protected override void m_mthPerformSessionChanged(clsEmrPatientSessionInfo_VO p_objSelectedSession, int p_intIndex)
        {
            if (p_objSelectedSession == null) return;
            base.m_mthPerformSessionChanged(p_objSelectedSession, p_intIndex);
            if (blnNewRecord)
                //初始化
                m_mthClearRecordInfo();
            else
                m_GetDataFromDB();
            m_mthAddFormStatusForClosingSave();
        }
	}
}
