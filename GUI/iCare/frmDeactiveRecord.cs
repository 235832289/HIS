using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;
using com.digitalwave.Utility.Controls;
using iCareData;

namespace iCare
{
	public class frmDeactiveRecord : iCare.frmHRPBaseForm
	{
		private System.Windows.Forms.Label lblInPatientDateTitle;
		private System.Windows.Forms.Label m_lblInPatientDate;
		private System.Windows.Forms.Label label1;
		private com.digitalwave.Utility.Controls.ctlComboBox m_cboFormType;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ListView m_lsvDeactiveInfo;
		private PinkieControls.ButtonXP m_cmdSearch;
		private PinkieControls.ButtonXP m_cmdCancle;
		private System.ComponentModel.IContainer components = null;

		public frmDeactiveRecord()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			m_objDeactiveDomain = new clsDeactiveRecordDomain();

            //m_objBorderTool = new clsBorderTool(Color.White);
            //m_objBorderTool.m_mthChangedControlsArrayBorder(new Control[]{this.m_lsvDeactiveInfo});	
            
			clsDeactiveFormInfo [] objFormArr;

			long lngRes = m_objDeactiveDomain.m_lngGetDeactiveFormInfo(out objFormArr);

			if(lngRes > 0 && objFormArr != null)
			{
				m_cboFormType.AddRangeItems(objFormArr);

				if(objFormArr.Length > 0)
					m_cboFormType.SelectedIndex = 0;
			}
		}

		private clsDeactiveRecordDomain m_objDeactiveDomain;

        //private com.digitalwave.Utility.Controls.clsBorderTool m_objBorderTool;		

		private frmHRPBaseForm m_objBaseForm = null;

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
            this.lblInPatientDateTitle = new System.Windows.Forms.Label();
            this.m_lblInPatientDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cboFormType = new com.digitalwave.Utility.Controls.ctlComboBox();
            this.m_lsvDeactiveInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_cmdSearch = new PinkieControls.ButtonXP();
            this.m_cmdCancle = new PinkieControls.ButtonXP();
            this.m_pnlNewBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSex
            // 
            this.lblSex.Location = new System.Drawing.Point(273, 201);
            this.lblSex.Visible = false;
            // 
            // lblAge
            // 
            this.lblAge.Location = new System.Drawing.Point(481, 201);
            this.lblAge.Visible = false;
            // 
            // lblBedNoTitle
            // 
            this.lblBedNoTitle.Location = new System.Drawing.Point(433, 169);
            this.lblBedNoTitle.Visible = false;
            // 
            // lblInHospitalNoTitle
            // 
            this.lblInHospitalNoTitle.Location = new System.Drawing.Point(21, 229);
            this.lblInHospitalNoTitle.Visible = false;
            // 
            // lblNameTitle
            // 
            this.lblNameTitle.Location = new System.Drawing.Point(21, 201);
            this.lblNameTitle.Visible = false;
            // 
            // lblSexTitle
            // 
            this.lblSexTitle.Location = new System.Drawing.Point(225, 201);
            this.lblSexTitle.Visible = false;
            // 
            // lblAgeTitle
            // 
            this.lblAgeTitle.Location = new System.Drawing.Point(433, 201);
            this.lblAgeTitle.Visible = false;
            // 
            // lblAreaTitle
            // 
            this.lblAreaTitle.Location = new System.Drawing.Point(225, 169);
            this.lblAreaTitle.Visible = false;
            // 
            // m_lsvInPatientID
            // 
            this.m_lsvInPatientID.Location = new System.Drawing.Point(77, 212);
            this.m_lsvInPatientID.Size = new System.Drawing.Size(112, 104);
            // 
            // txtInPatientID
            // 
            this.txtInPatientID.Location = new System.Drawing.Point(77, 225);
            this.txtInPatientID.Visible = false;
            // 
            // m_txtPatientName
            // 
            this.m_txtPatientName.Location = new System.Drawing.Point(77, 197);
            this.m_txtPatientName.Visible = false;
            // 
            // m_txtBedNO
            // 
            this.m_txtBedNO.Location = new System.Drawing.Point(481, 168);
            this.m_txtBedNO.Size = new System.Drawing.Size(92, 23);
            this.m_txtBedNO.Visible = false;
            // 
            // m_cboArea
            // 
            this.m_cboArea.Location = new System.Drawing.Point(273, 165);
            this.m_cboArea.Visible = false;
            // 
            // m_lsvPatientName
            // 
            this.m_lsvPatientName.Location = new System.Drawing.Point(81, 184);
            // 
            // m_lsvBedNO
            // 
            this.m_lsvBedNO.Location = new System.Drawing.Point(485, 156);
            this.m_lsvBedNO.Size = new System.Drawing.Size(92, 104);
            // 
            // m_cboDept
            // 
            this.m_cboDept.Location = new System.Drawing.Point(77, 165);
            this.m_cboDept.Visible = false;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(21, 169);
            this.lblDept.Visible = false;
            // 
            // m_cmdNewTemplate
            // 
            this.m_cmdNewTemplate.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdNewTemplate.Location = new System.Drawing.Point(627, 137);
            // 
            // m_cmdNext
            // 
            this.m_cmdNext.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdNext.Location = new System.Drawing.Point(48, 145);
            // 
            // m_cmdPre
            // 
            this.m_cmdPre.Font = new System.Drawing.Font("宋体", 12F);
            this.m_cmdPre.Location = new System.Drawing.Point(24, 145);
            // 
            // m_lblForTitle
            // 
            this.m_lblForTitle.Location = new System.Drawing.Point(4, 4);
            this.m_lblForTitle.Text = "删 除 记 录 查 询";
            // 
            // chkModifyWithoutMatk
            // 
            this.chkModifyWithoutMatk.Location = new System.Drawing.Point(555, 153);
            // 
            // m_cmdModifyPatientInfo
            // 
            this.m_cmdModifyPatientInfo.Location = new System.Drawing.Point(406, -31);
            // 
            // m_pnlNewBase
            // 
            this.m_pnlNewBase.Size = new System.Drawing.Size(740, 60);
            this.m_pnlNewBase.Visible = true;
            // 
            // m_ctlPatientInfo
            // 
            this.m_ctlPatientInfo.m_BlnIsShowPatientAge = true;
            this.m_ctlPatientInfo.m_BlnIsShowPatientName = true;
            this.m_ctlPatientInfo.m_BlnIsShowSex = true;
            this.m_ctlPatientInfo.Size = new System.Drawing.Size(738, 29);
            // 
            // lblInPatientDateTitle
            // 
            this.lblInPatientDateTitle.AutoSize = true;
            this.lblInPatientDateTitle.BackColor = System.Drawing.SystemColors.Control;
            this.lblInPatientDateTitle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInPatientDateTitle.ForeColor = System.Drawing.Color.Black;
            this.lblInPatientDateTitle.Location = new System.Drawing.Point(225, 229);
            this.lblInPatientDateTitle.Name = "lblInPatientDateTitle";
            this.lblInPatientDateTitle.Size = new System.Drawing.Size(70, 14);
            this.lblInPatientDateTitle.TabIndex = 10000001;
            this.lblInPatientDateTitle.Text = "住院日期:";
            this.lblInPatientDateTitle.Visible = false;
            // 
            // m_lblInPatientDate
            // 
            this.m_lblInPatientDate.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblInPatientDate.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_lblInPatientDate.ForeColor = System.Drawing.Color.Black;
            this.m_lblInPatientDate.Location = new System.Drawing.Point(296, 229);
            this.m_lblInPatientDate.Name = "m_lblInPatientDate";
            this.m_lblInPatientDate.Size = new System.Drawing.Size(231, 19);
            this.m_lblInPatientDate.TabIndex = 10000001;
            this.m_lblInPatientDate.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(17, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 14);
            this.label1.TabIndex = 10000001;
            this.label1.Text = "记录类型:";
            // 
            // m_cboFormType
            // 
            this.m_cboFormType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(229)))), ((int)(((byte)(232)))));
            this.m_cboFormType.BorderColor = System.Drawing.Color.Black;
            this.m_cboFormType.DropButtonBackColor = System.Drawing.SystemColors.Control;
            this.m_cboFormType.DropButtonCursor = System.Windows.Forms.Cursors.Hand;
            this.m_cboFormType.DropButtonForeColor = System.Drawing.Color.Black;
            this.m_cboFormType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cboFormType.flatFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFormType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.m_cboFormType.ForeColor = System.Drawing.Color.Black;
            this.m_cboFormType.ListBackColor = System.Drawing.Color.White;
            this.m_cboFormType.ListForeColor = System.Drawing.SystemColors.WindowText;
            this.m_cboFormType.ListSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.m_cboFormType.ListSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.m_cboFormType.Location = new System.Drawing.Point(97, 72);
            this.m_cboFormType.m_BlnEnableItemEventMenu = false;
            this.m_cboFormType.Name = "m_cboFormType";
            this.m_cboFormType.SelectedIndex = -1;
            this.m_cboFormType.SelectedItem = null;
            this.m_cboFormType.SelectionStart = 0;
            this.m_cboFormType.Size = new System.Drawing.Size(356, 23);
            this.m_cboFormType.TabIndex = 10000002;
            this.m_cboFormType.TextBackColor = System.Drawing.Color.White;
            this.m_cboFormType.TextForeColor = System.Drawing.Color.Black;
            // 
            // m_lsvDeactiveInfo
            // 
            this.m_lsvDeactiveInfo.BackColor = System.Drawing.Color.White;
            this.m_lsvDeactiveInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.m_lsvDeactiveInfo.ForeColor = System.Drawing.Color.Black;
            this.m_lsvDeactiveInfo.FullRowSelect = true;
            this.m_lsvDeactiveInfo.GridLines = true;
            this.m_lsvDeactiveInfo.Location = new System.Drawing.Point(20, 104);
            this.m_lsvDeactiveInfo.Name = "m_lsvDeactiveInfo";
            this.m_lsvDeactiveInfo.Size = new System.Drawing.Size(728, 324);
            this.m_lsvDeactiveInfo.TabIndex = 44;
            this.m_lsvDeactiveInfo.UseCompatibleStateImageBehavior = false;
            this.m_lsvDeactiveInfo.View = System.Windows.Forms.View.Details;
            this.m_lsvDeactiveInfo.DoubleClick += new System.EventHandler(this.m_lsvDeactiveInfo_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "记录日期";
            this.columnHeader1.Width = 260;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "删除者";
            this.columnHeader2.Width = 180;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "删除时间";
            this.columnHeader3.Width = 260;
            // 
            // m_cmdSearch
            // 
            this.m_cmdSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdSearch.DefaultScheme = true;
            this.m_cmdSearch.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdSearch.ForeColor = System.Drawing.Color.Black;
            this.m_cmdSearch.Hint = "";
            this.m_cmdSearch.Location = new System.Drawing.Point(456, 70);
            this.m_cmdSearch.Name = "m_cmdSearch";
            this.m_cmdSearch.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdSearch.Size = new System.Drawing.Size(68, 28);
            this.m_cmdSearch.TabIndex = 10000004;
            this.m_cmdSearch.Text = "查询";
            this.m_cmdSearch.Click += new System.EventHandler(this.m_cmdSearch_Click);
            // 
            // m_cmdCancle
            // 
            this.m_cmdCancle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(216)))));
            this.m_cmdCancle.DefaultScheme = true;
            this.m_cmdCancle.DialogResult = System.Windows.Forms.DialogResult.None;
            this.m_cmdCancle.ForeColor = System.Drawing.Color.Black;
            this.m_cmdCancle.Hint = "";
            this.m_cmdCancle.Location = new System.Drawing.Point(532, 70);
            this.m_cmdCancle.Name = "m_cmdCancle";
            this.m_cmdCancle.Scheme = PinkieControls.ButtonXP.Schemes.Blue;
            this.m_cmdCancle.Size = new System.Drawing.Size(68, 28);
            this.m_cmdCancle.TabIndex = 10000005;
            this.m_cmdCancle.Text = "关闭";
            this.m_cmdCancle.Click += new System.EventHandler(this.m_cmdCancle_Click);
            // 
            // frmDeactiveRecord
            // 
            this.ClientSize = new System.Drawing.Size(764, 444);
            this.Controls.Add(this.m_lsvDeactiveInfo);
            this.Controls.Add(this.m_cmdCancle);
            this.Controls.Add(this.m_cmdSearch);
            this.Controls.Add(this.lblInPatientDateTitle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_cboFormType);
            this.Controls.Add(this.m_lblInPatientDate);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDeactiveRecord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "删除记录查询";
            this.Load += new System.EventHandler(this.frmDeactiveRecord_Load);
            this.Controls.SetChildIndex(this.m_pnlNewBase, 0);
            this.Controls.SetChildIndex(this.m_cmdModifyPatientInfo, 0);
            this.Controls.SetChildIndex(this.chkModifyWithoutMatk, 0);
            this.Controls.SetChildIndex(this.m_lblInPatientDate, 0);
            this.Controls.SetChildIndex(this.m_cboFormType, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.m_lblForTitle, 0);
            this.Controls.SetChildIndex(this.lblDept, 0);
            this.Controls.SetChildIndex(this.lblAreaTitle, 0);
            this.Controls.SetChildIndex(this.lblAgeTitle, 0);
            this.Controls.SetChildIndex(this.lblSexTitle, 0);
            this.Controls.SetChildIndex(this.lblNameTitle, 0);
            this.Controls.SetChildIndex(this.lblInHospitalNoTitle, 0);
            this.Controls.SetChildIndex(this.lblBedNoTitle, 0);
            this.Controls.SetChildIndex(this.lblAge, 0);
            this.Controls.SetChildIndex(this.lblSex, 0);
            this.Controls.SetChildIndex(this.m_txtPatientName, 0);
            this.Controls.SetChildIndex(this.m_txtBedNO, 0);
            this.Controls.SetChildIndex(this.m_cboArea, 0);
            this.Controls.SetChildIndex(this.m_cboDept, 0);
            this.Controls.SetChildIndex(this.m_lsvInPatientID, 0);
            this.Controls.SetChildIndex(this.m_lsvPatientName, 0);
            this.Controls.SetChildIndex(this.m_lsvBedNO, 0);
            this.Controls.SetChildIndex(this.lblInPatientDateTitle, 0);
            this.Controls.SetChildIndex(this.m_cmdNewTemplate, 0);
            this.Controls.SetChildIndex(this.m_cmdNext, 0);
            this.Controls.SetChildIndex(this.m_cmdPre, 0);
            this.Controls.SetChildIndex(this.txtInPatientID, 0);
            this.Controls.SetChildIndex(this.m_cmdSearch, 0);
            this.Controls.SetChildIndex(this.m_cmdCancle, 0);
            this.Controls.SetChildIndex(this.m_lsvDeactiveInfo, 0);
            this.m_pnlNewBase.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void m_cmdCancle_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		protected override void m_mthSetPatientFormInfo(iCare.clsPatient p_objSelectedPatient)
		{
			m_lblInPatientDate.Text = p_objSelectedPatient.m_DtmSelectedInDate.ToString("yyyy年MM月dd日 HH:mm:ss");

			m_lsvDeactiveInfo.Items.Clear();
		}

		private void m_cmdSearch_Click(object sender, System.EventArgs e)
		{
			m_mthSearch();
		}		

		private void m_mthSearch()
		{
			clsDeactiveFormInfo objFormInfo = (clsDeactiveFormInfo)m_cboFormType.SelectedItem;

			if(objFormInfo == null || m_objBaseCurrentPatient == null)
				return;

			m_cboFormType.Tag = objFormInfo;

			clsDeactiveInfo [] objDeactiveInfoArr;
			long lngRes = m_objDeactiveDomain.m_lngGetDeactiveInfo(m_objBaseCurrentPatient.m_StrInPatientID,m_objBaseCurrentPatient.m_DtmSelectedInDate.ToString("yyyy-MM-dd HH:mm:ss"),objFormInfo.m_intFormID,out objDeactiveInfoArr);

            if (lngRes <= 0 || objDeactiveInfoArr == null || objDeactiveInfoArr.Length <= 0)
            {
                clsPublicFunction.ShowInformationMessageBox("未找到已删除的记录！");
                return;
            }
			else if(lngRes > 0)
			{
				m_lsvDeactiveInfo.Items.Clear();

				if(objDeactiveInfoArr != null)
				{
					for(int i=0;i<objDeactiveInfoArr.Length;i++)
					{
						ListViewItem lviDeactiveInfo = new ListViewItem(
							new string[]{
											objDeactiveInfoArr[i].m_dtmCreateDate.ToString("yyyy年MM月dd日 HH:mm:ss"),
											objDeactiveInfoArr[i].m_strDeactiveUserName,
											objDeactiveInfoArr[i].m_dtmDeactiveDate.ToString("yyyy年MM月dd日 HH:mm:ss")
										});
						lviDeactiveInfo.Tag = objDeactiveInfoArr[i];

						m_lsvDeactiveInfo.Items.Add(lviDeactiveInfo);
					}

					m_mthChangeListViewLastColumnWidth(m_lsvDeactiveInfo,15);
				}
			}
		}

		private void m_lsvDeactiveInfo_DoubleClick(object sender, System.EventArgs e)
		{
			if(m_lsvDeactiveInfo.SelectedItems.Count == 0)
				return;

			clsDeactiveInfo objDeactiveInfo = (clsDeactiveInfo)m_lsvDeactiveInfo.SelectedItems[0].Tag;
			clsDeactiveFormInfo objFormInfo = (clsDeactiveFormInfo)m_cboFormType.Tag;
				
			m_objBaseCurrentPatient.m_DtmSelectedInDate = objDeactiveInfo.m_dtmSelectedInDate;

			frmHRPBaseForm objBaseForm = m_objBaseForm;
           
			if(objBaseForm == null)
			{
				Type typForm = Type.GetType(objFormInfo.m_strMainFormClassName);
				//如果没有不需参数的构造函数则爆
				objBaseForm =  (frmHRPBaseForm)Activator.CreateInstance(typForm);
				objBaseForm.m_BlnIfNewDeletedRecord = true;
				objBaseForm.MdiParent = clsEMRLogin.s_FrmMDI;
                this.MdiParent = clsEMRLogin.s_FrmMDI;
				objBaseForm.WindowState = FormWindowState.Maximized;
                objBaseForm.Show();
                objBaseForm.TopMost = true;
			}

            bool blnIsRecordBase = false;
            frmRecordsBase frmRB = null;
            if (objBaseForm is frmDiseaseTrackBase)
            {
                for (int i = 0; i < clsEMRLogin.s_FrmMDI.MdiChildren.Length; i++)
                {
                    if (clsEMRLogin.s_FrmMDI.MdiChildren[i] is frmRecordsBase)
                    {
                        if (((frmRecordsBase)clsEMRLogin.s_FrmMDI.MdiChildren[i]).m_FrmCurrentSub != null
                            && ((frmRecordsBase)clsEMRLogin.s_FrmMDI.MdiChildren[i]).m_FrmCurrentSub.Equals(objBaseForm))
                        {
                            frmRB = (frmRecordsBase)clsEMRLogin.s_FrmMDI.MdiChildren[i];
                            blnIsRecordBase = true;
                        }
                    }
                }
            }
            
            if (!blnIsRecordBase)
            {
                objBaseForm.m_mthSetDeactiveContent(m_objBaseCurrentPatient, objDeactiveInfo.m_dtmPrimaryDate, objFormInfo.m_intFormID);
                MDIParent.s_ObjSaveCue.m_mthRemoveForm(objBaseForm);
            }
            else if(frmRB != null)
            {
                frmRB.m_mthSetDeactiveContent(m_objBaseCurrentPatient, objDeactiveInfo.m_dtmPrimaryDate, objFormInfo.m_intFormID);
            }
            //objBaseForm.Close();
            this.Close();
           // this.Dispose();
		
			
		}	

		public void m_mthSetForm(frmHRPBaseForm p_objBaseForm)
		{
			m_objBaseForm = null;

			for(int i=0;i<m_cboFormType.GetItemsCount();i++)
			{
				clsDeactiveFormInfo objFormInfo = (clsDeactiveFormInfo)m_cboFormType.GetItem(i);

				if(objFormInfo.m_intFormID == p_objBaseForm.m_IntFormID)
				{
					m_cboFormType.SelectedIndex = i;
					m_objBaseForm = p_objBaseForm;
					break;
				}
			}

			m_cboFormType.Enabled = false;

			m_mthSearch();
		}

		private void frmDeactiveRecord_Load(object sender, System.EventArgs e)
		{
			m_cboFormType.Focus();
		}

		public void m_mthSetForm(frmHRPBaseForm p_objBaseForm,clsPatient p_objPatient)
		{
			if(p_objPatient != null)
			{
				this.m_mthSetPatient(p_objPatient);

                m_mthSetIfCanSelectPatient(false);
                //m_cboDept.Enabled = false;
                //m_cboArea.Enabled = false;
                //m_txtBedNO.Enabled = false;
                //m_txtPatientName.Enabled = false;
                //txtInPatientID.Enabled = false;
			}

			m_mthSetForm(p_objBaseForm);
		}
        protected override void m_mthIsReadOnly()
        {
            m_blnReadOnly = false;
            m_strTimeRemain = "";
        }

		/// <summary>
		/// 不需要保存提示
		/// </summary>
		protected override void m_mthAddFormStatusForClosingSave()
		{
		}

		/// <summary>
		/// 查找病人
		/// </summary>
		/// <returns></returns>
		protected override clsPatient [] m_objGetPatient()
		{
			if(m_cboArea.GetItemsCount() > 0)
			{
				if(m_cboArea.SelectedItem==null)
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择病区!");
					return null;
				}
				return m_objCurrentContext.m_ObjPatientManager.m_objGetInPatientByAreaIDLike(((clsInPatientArea)m_cboArea.SelectedItem).m_StrAreaID,txtInPatientID.Text);
			}
			else if(m_cboDept.GetItemsCount() > 0)
			{
				if(m_cboDept.SelectedItem == null)
				{
					clsPublicFunction.ShowInformationMessageBox("请先选择科室!");
					return null;
				}
				return m_objCurrentContext.m_ObjPatientManager.m_objGetInPatientByDeptIDLike((clsDepartment)m_cboDept.SelectedItem,txtInPatientID.Text);
			}
			else
				return null;
		}
	}
}

