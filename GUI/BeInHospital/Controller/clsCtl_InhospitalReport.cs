using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;
using CrystalDecisions;
using CrystalDecisions.CrystalReports.Engine;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
	class clsCtl_InhospitalReport : com.digitalwave.GUI_Base.clsController_Base
	{
		com.digitalwave.iCare.gui.HIS.clsDcl_BedAdmin objSvc;
		private CrystalDecisions.CrystalReports.Engine.ReportDocument rptInHospitalLog;
		#region ���ô������
		com.digitalwave.iCare.gui.HIS.frmInhospitalReport m_objViewer;
		/// <summary>
		/// ���ô������
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmInhospitalReport)frmMDI_Child_Base_in;
		}
		#endregion
		/// <summary>
		/// ���캯��
		/// </summary>
		public clsCtl_InhospitalReport()
		{
			objSvc = new clsDcl_BedAdmin();
		}

        #region ������Ҷ�Ӧ�Ĳ���
        /// <summary>
        /// ������Ҷ�Ӧ�Ĳ���
        /// </summary>
        public void LoadAreaID()
        {
            m_objViewer.lsvAreaInfo.Items.Clear();
            com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] DataResultArr = null;
            string strFilter = "WHERE ATTRIBUTEID = '0000003' AND STATUS_INT = 1 AND (shortno_chr LIKE '"
                               + m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()
                               + "%' or DEPTNAME_VCHR like '"
                               + m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim()
                               + "%' or PYCODE_CHR like '" 
                               + m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim() 
                               + "%' or WBCODE_CHR like '" 
                               + m_objViewer.m_txtAREAID_CHR.Text.ToString().Trim() + "%')";
            System.Windows.Forms.ListViewItem FindItem;
            long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfo(strFilter, out DataResultArr);
            if (lngRes > 0 && DataResultArr.Length > 0)
            {
                #region �ڲ���������һ��ȫԺѡ��	glzhang	2005.07.26
                FindItem = new ListViewItem("");
                FindItem.SubItems.Add("ȫԺ");
                FindItem.Tag = "";
                m_objViewer.lsvAreaInfo.Items.Add(FindItem);
                #endregion

                for (int i = 0; i < DataResultArr.Length; i++)
                {
                    FindItem = new ListViewItem(DataResultArr[i].m_strCODE_VCHR);
                    FindItem.SubItems.Add(DataResultArr[i].m_strDEPTNAME_VCHR);
                    FindItem.Tag = DataResultArr[i];
                    m_objViewer.lsvAreaInfo.Items.Add(FindItem);
                }
            }
        }
        #endregion

        #region ��Ժ��־����
        /// <summary>
		/// ��Ժ��־����
		/// </summary>
		public void m_mthShowInHospitalLog()
		{
            string strAreaId = "";
       
            if (this.m_objViewer.m_deptIDArr != null && this.m_objViewer.m_deptIDArr.Count > 0)
            {
                for (int i = 0; i < this.m_objViewer.m_deptIDArr.Count; i++)
                {
                    strAreaId += "'" + this.m_objViewer.m_deptIDArr[i] + "',";
                }
                strAreaId = strAreaId.TrimEnd(",".ToCharArray());
            }
       

			this.m_objViewer.Cursor = Cursors.WaitCursor;
			DataTable dtbResult =new DataTable();
       
            long lngRes = objSvc.m_lngGetInhospitalReportData( 5,
                                                               strAreaId, 
                                                               this.m_objViewer.m_dtpBeginDate.Value, 
                                                               this.m_objViewer.m_dtpEndDate.Value, 
                                                               out dtbResult);
			if(lngRes>0)
			{
                
                this.m_objViewer.m_dgvIn.DataSource = dtbResult;
                
                this.m_objViewer.m_dgvIn.Columns["registerid_chr"].Visible = false;
                this.m_objViewer.m_dgvIn.Columns["sourceareaname"].Visible = false;
                this.m_objViewer.m_dgvIn.Columns["sourcebedno"].Visible = false;
                this.m_objViewer.m_dgvIn.Columns["charge_dec"].Visible = false;
                this.m_objViewer.m_dgvIn.Columns["clearchg_dec"].Visible = false;
                this.m_objViewer.m_dgvIn.Columns["modify_dat"].Visible = false;
                this.m_objViewer.m_dgvIn.Columns["birth_dat"].Visible = false;

                this.m_objViewer.m_dgvIn.Columns["lastname"].HeaderText = "����";
                this.m_objViewer.m_dgvIn.Columns["lastname"].DisplayIndex = 0;

                this.m_objViewer.m_dgvIn.Columns["sex"].HeaderText = "�Ա�";
                this.m_objViewer.m_dgvIn.Columns["sex"].Width = 60;
                this.m_objViewer.m_dgvIn.Columns["sex"].DisplayIndex = 1;

                this.m_objViewer.m_dgvIn.Columns["age"].HeaderText = "����";
                this.m_objViewer.m_dgvIn.Columns["age"].Width = 60;
                this.m_objViewer.m_dgvIn.Columns["age"].DisplayIndex = 2;

                this.m_objViewer.m_dgvIn.Columns["inpatientid"].HeaderText = "סԺ��";
                this.m_objViewer.m_dgvIn.Columns["inpatientid"].DisplayIndex = 3;

                this.m_objViewer.m_dgvIn.Columns["inpatientdate"].HeaderText = "��Ժ����";
                this.m_objViewer.m_dgvIn.Columns["inpatientdate"].Width = 150;
                this.m_objViewer.m_dgvIn.Columns["inpatientdate"].DisplayIndex = 4;

                this.m_objViewer.m_dgvIn.Columns["paytype"].HeaderText = "���㷽ʽ";
                this.m_objViewer.m_dgvIn.Columns["paytype"].DisplayIndex = 5;

                this.m_objViewer.m_dgvIn.Columns["targetareaname"].HeaderText = "����";
                this.m_objViewer.m_dgvIn.Columns["targetareaname"].DisplayIndex = 6;

                this.m_objViewer.m_dgvIn.Columns["targetbedno"].HeaderText = "����";
                this.m_objViewer.m_dgvIn.Columns["targetbedno"].Width = 60;
                this.m_objViewer.m_dgvIn.Columns["targetbedno"].DisplayIndex = 7;

                this.m_objViewer.m_dgvIn.Columns["money_dec"].HeaderText = "Ԥ����";
                this.m_objViewer.m_dgvIn.Columns["money_dec"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                this.m_objViewer.m_dgvIn.Columns["money_dec"].DisplayIndex = 8;

                this.m_objViewer.m_dgvIn.Columns["operatorname"].HeaderText = "�Ǽ���";
                this.m_objViewer.m_dgvIn.Columns["operatorname"].DisplayIndex = 9;
			}
			this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region ��Ժ��־����
        /// <summary>
		/// ��Ժ��־����
		/// </summary>
		public void m_mthShowOutHospitalLog()
		{
            string strAreaId = "";
            //if (this.m_objViewer.m_checkBoxArea.Checked == true)
            //{

                if (this.m_objViewer.m_deptIDArr != null && this.m_objViewer.m_deptIDArr.Count > 0)
                {
                    for (int i = 0; i < this.m_objViewer.m_deptIDArr.Count; i++)
                    {
                        strAreaId += "'" + this.m_objViewer.m_deptIDArr[i] + "',";
                    }
                    strAreaId = strAreaId.TrimEnd(",".ToCharArray());
                }
            //}

            this.m_objViewer.Cursor = Cursors.WaitCursor;
			DataTable dtbResult =new DataTable();
           
            long lngRes = objSvc.m_lngGetOuthospitalReportData(strAreaId,
                                                               this.m_objViewer.m_dtpBeginDate.Value,
                                                               this.m_objViewer.m_dtpEndDate.Value,
                                                               out dtbResult);
            if(lngRes>0)
			{
               
                this.m_objViewer.m_dgvOut.DataSource = dtbResult;

                this.m_objViewer.m_dgvOut.Columns["registerid_chr"].Visible = false;
                this.m_objViewer.m_dgvOut.Columns["sourceareaname"].Visible = false;
                this.m_objViewer.m_dgvOut.Columns["sourcebedno"].Visible = false;
                this.m_objViewer.m_dgvOut.Columns["money_dec"].Visible = false;
                this.m_objViewer.m_dgvOut.Columns["clearchg_dec"].Visible = false;
                this.m_objViewer.m_dgvOut.Columns["paytype"].Visible = false;
                this.m_objViewer.m_dgvOut.Columns["birth_dat"].Visible = false;

                this.m_objViewer.m_dgvOut.Columns["lastname"].HeaderText = "����";
                this.m_objViewer.m_dgvOut.Columns["lastname"].DisplayIndex = 0;

                this.m_objViewer.m_dgvOut.Columns["sex"].HeaderText = "�Ա�";
                this.m_objViewer.m_dgvOut.Columns["sex"].Width = 60;
                this.m_objViewer.m_dgvOut.Columns["sex"].DisplayIndex = 1;

                this.m_objViewer.m_dgvOut.Columns["age"].HeaderText = "����";
                this.m_objViewer.m_dgvOut.Columns["age"].Width = 60;
                this.m_objViewer.m_dgvOut.Columns["age"].DisplayIndex = 2;

                this.m_objViewer.m_dgvOut.Columns["inpatientid"].HeaderText = "סԺ��";
                this.m_objViewer.m_dgvOut.Columns["inpatientid"].DisplayIndex = 3;

                this.m_objViewer.m_dgvOut.Columns["inpatientdate"].HeaderText = "��Ժ����";
                this.m_objViewer.m_dgvOut.Columns["inpatientdate"].Width = 120;
                this.m_objViewer.m_dgvOut.Columns["inpatientdate"].DisplayIndex = 4;

                this.m_objViewer.m_dgvOut.Columns["modify_dat"].HeaderText = "��Ժ����";
                this.m_objViewer.m_dgvOut.Columns["modify_dat"].Width = 120;
                this.m_objViewer.m_dgvOut.Columns["modify_dat"].DisplayIndex = 5;

                this.m_objViewer.m_dgvOut.Columns["targetareaname"].HeaderText = "����";
                this.m_objViewer.m_dgvOut.Columns["targetareaname"].DisplayIndex = 6;

                this.m_objViewer.m_dgvOut.Columns["targetbedno"].HeaderText = "����";
                this.m_objViewer.m_dgvOut.Columns["targetbedno"].Width = 60;
                this.m_objViewer.m_dgvOut.Columns["targetbedno"].DisplayIndex = 7;

                this.m_objViewer.m_dgvOut.Columns["charge_dec"].HeaderText = "�ܽ��";
                this.m_objViewer.m_dgvOut.Columns["charge_dec"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                this.m_objViewer.m_dgvOut.Columns["charge_dec"].DisplayIndex = 8;

                this.m_objViewer.m_dgvOut.Columns["operatorname"].HeaderText = "����Ա";
                this.m_objViewer.m_dgvOut.Columns["operatorname"].DisplayIndex = 9;

			}
			this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region ת����־����
        /// <summary>
		/// ת����־����
		/// </summary>
		public void m_mthShowTransferArea()
		{
            string strAreaId = "";
            //if (this.m_objViewer.m_checkBoxArea.Checked == true)
            //{

                if (this.m_objViewer.m_deptIDArr != null && this.m_objViewer.m_deptIDArr.Count > 0)
                {
                    for (int i = 0; i < this.m_objViewer.m_deptIDArr.Count; i++)
                    {
                        strAreaId += "'" + this.m_objViewer.m_deptIDArr[i] + "',";
                    }
                    strAreaId = strAreaId.TrimEnd(",".ToCharArray());
                }
            //}

            this.m_objViewer.Cursor = Cursors.WaitCursor;
			DataTable dtbResult =new DataTable();
           
            long lngRes = objSvc.m_lngGetInhospitalReportData( 3,
                                                               strAreaId,
                                                               this.m_objViewer.m_dtpBeginDate.Value,
                                                               this.m_objViewer.m_dtpEndDate.Value,
                                                               out dtbResult);
            if(lngRes>0)
			{               
                this.m_objViewer.m_dgvTrArea.DataSource = dtbResult;

                this.m_objViewer.m_dgvTrArea.Columns["registerid_chr"].Visible = false;
                this.m_objViewer.m_dgvTrArea.Columns["inpatientdate"].Visible = false;
                this.m_objViewer.m_dgvTrArea.Columns["sourcebedno"].Visible = false;
                this.m_objViewer.m_dgvTrArea.Columns["targetbedno"].Visible = false;
                this.m_objViewer.m_dgvTrArea.Columns["charge_dec"].Visible = false;
                this.m_objViewer.m_dgvTrArea.Columns["money_dec"].Visible = false;
                this.m_objViewer.m_dgvTrArea.Columns["clearchg_dec"].Visible = false;
                this.m_objViewer.m_dgvTrArea.Columns["paytype"].Visible = false;
                this.m_objViewer.m_dgvTrArea.Columns["birth_dat"].Visible = false;

                this.m_objViewer.m_dgvTrArea.Columns["lastname"].HeaderText = "����";
                this.m_objViewer.m_dgvTrArea.Columns["lastname"].DisplayIndex = 0;

                this.m_objViewer.m_dgvTrArea.Columns["sex"].HeaderText = "�Ա�";
                this.m_objViewer.m_dgvTrArea.Columns["sex"].Width = 60;
                this.m_objViewer.m_dgvTrArea.Columns["sex"].DisplayIndex = 1;

                this.m_objViewer.m_dgvTrArea.Columns["age"].HeaderText = "����";
                this.m_objViewer.m_dgvTrArea.Columns["age"].Width = 60;
                this.m_objViewer.m_dgvTrArea.Columns["age"].DisplayIndex = 2;

                this.m_objViewer.m_dgvTrArea.Columns["inpatientid"].HeaderText = "סԺ��";
                this.m_objViewer.m_dgvTrArea.Columns["inpatientid"].DisplayIndex = 3;

                this.m_objViewer.m_dgvTrArea.Columns["sourceareaname"].HeaderText = "ԭ����";
                //this.m_objViewer.m_dgvOut.Columns["sourceareaname"].Width = 120;
                this.m_objViewer.m_dgvTrArea.Columns["sourceareaname"].DisplayIndex = 4;

                this.m_objViewer.m_dgvTrArea.Columns["targetareaname"].HeaderText = "�²���";
                this.m_objViewer.m_dgvTrArea.Columns["targetareaname"].DisplayIndex = 5;

                this.m_objViewer.m_dgvTrArea.Columns["modify_dat"].HeaderText = "����";
                this.m_objViewer.m_dgvTrArea.Columns["modify_dat"].Width = 120;
                this.m_objViewer.m_dgvTrArea.Columns["modify_dat"].DisplayIndex = 6;

                this.m_objViewer.m_dgvTrArea.Columns["operatorname"].HeaderText = "����Ա";
                this.m_objViewer.m_dgvTrArea.Columns["operatorname"].DisplayIndex = 7;
			}
			this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region ת����־����
        /// <summary>
		/// ת����־����
		/// </summary>
		public void m_mthShowTransferbedLog()
		{
            string strAreaId = "";
            //if (this.m_objViewer.m_checkBoxArea.Checked == true)
            //{

                if (this.m_objViewer.m_deptIDArr != null && this.m_objViewer.m_deptIDArr.Count > 0)
                {
                    for (int i = 0; i < this.m_objViewer.m_deptIDArr.Count; i++)
                    {
                        strAreaId += "'" + this.m_objViewer.m_deptIDArr[i] + "',";
                    }
                    strAreaId = strAreaId.TrimEnd(",".ToCharArray());
                }
            //}

            this.m_objViewer.Cursor = Cursors.WaitCursor;
			DataTable dtbResult =new DataTable();         
            long lngRes = objSvc.m_lngGetInhospitalReportData( 2,
                                                               strAreaId,
                                                               this.m_objViewer.m_dtpBeginDate.Value,
                                                               this.m_objViewer.m_dtpEndDate.Value,
                                                               out dtbResult);
        	if(lngRes>0)
			{
               
                this.m_objViewer.m_dgvTrBed.DataSource = dtbResult;

                this.m_objViewer.m_dgvTrBed.Columns["registerid_chr"].Visible = false;
                this.m_objViewer.m_dgvTrBed.Columns["inpatientdate"].Visible = false;
                this.m_objViewer.m_dgvTrBed.Columns["targetareaname"].Visible = false;
                this.m_objViewer.m_dgvTrBed.Columns["money_dec"].Visible = false;
                this.m_objViewer.m_dgvTrBed.Columns["clearchg_dec"].Visible = false;
                this.m_objViewer.m_dgvTrBed.Columns["charge_dec"].Visible = false;
                this.m_objViewer.m_dgvTrBed.Columns["paytype"].Visible = false;
                this.m_objViewer.m_dgvTrBed.Columns["birth_dat"].Visible = false;

                this.m_objViewer.m_dgvTrBed.Columns["lastname"].HeaderText = "����";
                this.m_objViewer.m_dgvTrBed.Columns["lastname"].DisplayIndex = 0;

                this.m_objViewer.m_dgvTrBed.Columns["sex"].HeaderText = "�Ա�";
                this.m_objViewer.m_dgvTrBed.Columns["sex"].Width = 60;
                this.m_objViewer.m_dgvTrBed.Columns["sex"].DisplayIndex = 1;

                this.m_objViewer.m_dgvTrBed.Columns["age"].HeaderText = "����";
                this.m_objViewer.m_dgvTrBed.Columns["age"].Width = 60;
                this.m_objViewer.m_dgvTrBed.Columns["age"].DisplayIndex = 2;

                this.m_objViewer.m_dgvTrBed.Columns["inpatientid"].HeaderText = "סԺ��";
                this.m_objViewer.m_dgvTrBed.Columns["inpatientid"].DisplayIndex = 3;

                this.m_objViewer.m_dgvTrBed.Columns["sourceareaname"].HeaderText = "����";
                //this.m_objViewer.m_dgvOut.Columns["sourceareaname"].Width = 120;
                this.m_objViewer.m_dgvTrBed.Columns["sourceareaname"].DisplayIndex = 4;

                this.m_objViewer.m_dgvTrBed.Columns["sourcebedno"].HeaderText = "ԭ����";
               this.m_objViewer.m_dgvTrBed.Columns["sourcebedno"].Width = 75;
                this.m_objViewer.m_dgvTrBed.Columns["sourcebedno"].DisplayIndex = 5;

                this.m_objViewer.m_dgvTrBed.Columns["targetbedno"].HeaderText = "�´���";
                this.m_objViewer.m_dgvTrBed.Columns["targetbedno"].Width = 75;
                this.m_objViewer.m_dgvTrBed.Columns["targetbedno"].DisplayIndex = 6;

                this.m_objViewer.m_dgvTrBed.Columns["modify_dat"].HeaderText = "��Ժ����";
                this.m_objViewer.m_dgvTrBed.Columns["modify_dat"].Width = 120;
                this.m_objViewer.m_dgvTrBed.Columns["modify_dat"].DisplayIndex = 7;

                this.m_objViewer.m_dgvTrBed.Columns["operatorname"].HeaderText = "����Ա";
                this.m_objViewer.m_dgvTrBed.Columns["operatorname"].DisplayIndex = 8;

			}
			this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion 

        public void PrintTransferbedLog()
		{           
            DataTable dt = (DataTable)this.m_objViewer.m_dgvTrBed.DataSource;
            DataView dv = new DataView(dt);

            if (this.m_objViewer.m_dgvTrBed.SortedColumn != null)
            {
                string strSortCol = this.m_objViewer.m_dgvTrBed.SortedColumn.Name;

                if (this.m_objViewer.m_dgvTrBed.SortOrder == SortOrder.Ascending)
                {
                    strSortCol += " asc";
                }
                else if (this.m_objViewer.m_dgvTrBed.SortOrder == SortOrder.Descending)
                {
                    strSortCol += " desc";
                }

                dv.Sort = strSortCol;
            }
            try
            {
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

                //ѡ���ӡ��
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    this.m_objViewer.m_dsPrint.DataWindowObject = "d_trbed_log";
                    this.m_objViewer.m_dsPrint.Retrieve(dv.ToTable());
                    this.m_objViewer.m_dsPrint.Modify("t_strsumpatient.text='��" + dv.Count.ToString() + "��'");
                    this.m_objViewer.m_dsPrint.Modify("t_strstat.text='" + this.m_objViewer.m_dtpBeginDate.Value.ToString("yyyy-MM-dd") + " 00:00:00  �� " + this.m_objViewer.m_dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "'");
                    this.m_objViewer.m_dsPrint.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    this.m_objViewer.m_dsPrint.Print();

                }
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
		}
		public void PrintTransferArea()
		{           
            DataTable dt = (DataTable)this.m_objViewer.m_dgvTrArea.DataSource;
            DataView dv = new DataView(dt);

            if (this.m_objViewer.m_dgvTrArea.SortedColumn != null)
            {
                string strSortCol = this.m_objViewer.m_dgvTrArea.SortedColumn.Name;

                if (this.m_objViewer.m_dgvTrArea.SortOrder == SortOrder.Ascending)
                {
                    strSortCol += " asc";
                }
                else if (this.m_objViewer.m_dgvTrArea.SortOrder == SortOrder.Descending)
                {
                    strSortCol += " desc";
                }

                dv.Sort = strSortCol;
            }

            try
            {
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

                //ѡ���ӡ��
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    this.m_objViewer.m_dsPrint.DataWindowObject = "d_trarea_log";
                    this.m_objViewer.m_dsPrint.Retrieve(dv.ToTable());
                    this.m_objViewer.m_dsPrint.Modify("t_strsumpatient.text='��" + dv.Count.ToString() + "��'");
                    this.m_objViewer.m_dsPrint.Modify("t_strstat.text='" + this.m_objViewer.m_dtpBeginDate.Value.ToString("yyyy-MM-dd") + " 00:00:00  �� " + this.m_objViewer.m_dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "'");
                    this.m_objViewer.m_dsPrint.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    this.m_objViewer.m_dsPrint.Print();

                }
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
		}
		public void PrintOutHospitalLog()
		{           
            DataTable dt = (DataTable)this.m_objViewer.m_dgvOut.DataSource;
            DataView dv = new DataView(dt);

            if (this.m_objViewer.m_dgvOut.SortedColumn != null)
            {
                string strSortCol = this.m_objViewer.m_dgvOut.SortedColumn.Name;

                if (this.m_objViewer.m_dgvOut.SortOrder == SortOrder.Ascending)
                {
                    strSortCol += " asc";
                }
                else if (this.m_objViewer.m_dgvOut.SortOrder == SortOrder.Descending)
                {
                    strSortCol += " desc";
                }

                dv.Sort = strSortCol;
            }
            try
            {
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

                //ѡ���ӡ��
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    this.m_objViewer.m_dsPrint.DataWindowObject = "d_out_log";
                    this.m_objViewer.m_dsPrint.Retrieve(dv.ToTable());
                    this.m_objViewer.m_dsPrint.Modify("t_strsumpatient.text='��" + dv.Count.ToString() + "��'");
                    this.m_objViewer.m_dsPrint.Modify("t_strstat.text='" + this.m_objViewer.m_dtpBeginDate.Value.ToString("yyyy-MM-dd") + " 00:00:00  �� " + this.m_objViewer.m_dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "'");
                    this.m_objViewer.m_dsPrint.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    this.m_objViewer.m_dsPrint.Print();
                    
                }
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
           
		}
		public void PrintInHospitalLog()
		{           
            DataTable dt = (DataTable)this.m_objViewer.m_dgvIn.DataSource;
            DataView dv = new DataView(dt);

            if (this.m_objViewer.m_dgvIn.SortedColumn != null)
            {
                string strSortCol = this.m_objViewer.m_dgvIn.SortedColumn.Name;

                if (this.m_objViewer.m_dgvIn.SortOrder == SortOrder.Ascending)
                {
                    strSortCol += " asc";
                }
                else if (this.m_objViewer.m_dgvIn.SortOrder == SortOrder.Descending)
                {
                    strSortCol += " desc";
                }

                dv.Sort = strSortCol;
            }
            try
            {
                System.Windows.Forms.PrintDialog pDialog = new PrintDialog();

                //ѡ���ӡ��
                if (pDialog.ShowDialog() == DialogResult.OK)
                {
                    this.m_objViewer.m_dsPrint.DataWindowObject = "d_inpatient_log";
                    this.m_objViewer.m_dsPrint.Retrieve(dv.ToTable());
                    this.m_objViewer.m_dsPrint.Modify("t_strsumpatient.text='��" + dv.Count.ToString() + "��'");
                    this.m_objViewer.m_dsPrint.Modify("t_strstat.text='" + this.m_objViewer.m_dtpBeginDate.Value.ToString("yyyy-MM-dd") + " 00:00:00  �� " + this.m_objViewer.m_dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "'");
                    this.m_objViewer.m_dsPrint.PrintProperties.PrinterName = pDialog.PrinterSettings.PrinterName;
                    this.m_objViewer.m_dsPrint.Print();

                }
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
		}

        public void m_mthExportByDs(DataTable dt, string strDataWindowObject)
        {
            if (dt.Rows.Count == 0)
            {
                return;
            }

            DataStore ds = new DataStore();
            ds.LibraryList = this.m_objViewer.m_dsPrint.LibraryList;
            ds.DataWindowObject = strDataWindowObject;
            ds.Retrieve(dt);
            ds.Modify("t_strsumpatient.text='��" + dt.Rows.Count.ToString() + "��'");
            ds.Modify("t_strstat.text='" + this.m_objViewer.m_dtpBeginDate.Value.ToString("yyyy-MM-dd") + " 00:00:00  �� " + this.m_objViewer.m_dtpEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59" + "'");

            clsPublic.ExportDataStore(ds, null);
        }
	}
}