using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Collections;


namespace com.digitalwave.iCare.gui.HIS
{
    class clsCtl_InPatientQuery : com.digitalwave.GUI_Base.clsController_Base
    {

        #region ����
        com.digitalwave.iCare.gui.HIS.clsDcl_InPatientQuery m_objServer = null;
        #endregion

        #region ���캯��
        public clsCtl_InPatientQuery()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            m_objServer = new com.digitalwave.iCare.gui.HIS.clsDcl_InPatientQuery();
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmInPatientQuery m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmInPatientQuery)frmMDI_Child_Base_in;
        }
        #endregion

        #region �����¼�
        public void m_txtAreaInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Add("�������", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("��������", 90, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 170;
        }
        public void m_txtAreaFindItem(string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBIHArea[] objItemArr;
            long lngRes = m_objServer.m_lngFindArea(strFindCode, out objItemArr);
            if (lngRes > 0 && objItemArr != null && objItemArr.Length > 0)
            {
                //��ȡ��Ȩ�޷��ʵĲ���ID����
                if (m_objViewer.LoginInfo != null)
                {
                    IList ilUsableAreaID = m_objViewer.LoginInfo.m_ilUsableAreaID;
                    objItemArr = (clsBIHArea[])(GetUsableAreaObject(objItemArr, ilUsableAreaID)).ToArray(typeof(clsBIHArea));
                }
                for (int i = 0; i < objItemArr.Length; i++)
                {
                    /** @update by xzf (05-09-20) 
                     * 
                     */
                    //@ListViewItem lvi=lvwList.Items.Add(objItemArr[i].m_strAreaID);
                    ListViewItem lvi = lvwList.Items.Add(objItemArr[i].code);
                    lvi.SubItems.Add(objItemArr[i].m_strAreaName);
                    lvi.Tag = objItemArr[i].m_strAreaID;
                    /* <<======================== */
                }
            }
        }

        public void m_txtAreaSelectItem(System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_objViewer.m_txtArea.Text = lviSelected.SubItems[1].Text;
                m_objViewer.m_txtArea.Tag = lviSelected.Tag;
               
                   setTheControlOrder(this.m_objViewer.m_txtArea.Name);
               
            }
        }

        #region ����Ȩ��
        /// <summary>
        /// ���˳���Ȩ�޵Ĳ���
        /// </summary>
        /// <param name="p_objArea">��������</param>
        /// <param name="p_ilUsableAreaID">��Ȩ���ʵĲ���ID����</param>
        /// <returns>��Ȩ���ʵĲ������󼯺�</returns>
        public ArrayList GetUsableAreaObject(clsBIHArea[] p_objArea, IList p_ilUsableAreaID)
        {
            ArrayList ilRes = new ArrayList();
            if (p_objArea == null || p_objArea.Length <= 0) return ilRes;

            //ȫ���Ŀɷ��ʵĲ�������
            for (int i1 = 0; i1 < p_objArea.Length; i1++)
            {
                if (p_objArea[i1] == null) continue;
                if (p_ilUsableAreaID.Contains(p_objArea[i1].m_strAreaID.Trim()))
                {
                    if (!(ilRes.Contains(p_objArea[i1])))
                        ilRes.Add(p_objArea[i1]);
                }
            }
            return ilRes;
        }

        /// <summary>
        /// ���˳���Ȩ�޵�סԺ��
        /// </summary>
        /// <param name="p_objItemArr">��Ժ�ǼǶ���	[����]</param>
        /// <param name="p_ilUsableAreaID">��Ȩ���ʵĲ���ID����</param>
        /// <returns>��Ȩ���ʵ���Ժ�ǼǶ��󼯺�</returns>
        public ArrayList GetUsableRegisterObject(clsT_Opr_Bih_Register_VO[] p_objItemArr, IList p_ilUsableAreaID)
        {
            ArrayList ilRes = new ArrayList();
            if (p_objItemArr == null || p_objItemArr.Length <= 0) return ilRes;

            //ȫ���Ŀɷ��ʵĲ�������
            for (int i1 = 0; i1 < p_objItemArr.Length; i1++)
            {
                if (p_objItemArr[i1] == null) continue;
                if (p_ilUsableAreaID.Contains(p_objItemArr[i1].m_strAREAID_CHR.Trim()))
                {
                    if (!(ilRes.Contains(p_objItemArr[i1])))
                        ilRes.Add(p_objItemArr[i1]);
                }
            }
            return ilRes;
        }
        #endregion
        #endregion



        internal void m_txtPatientDoctorFindItem(string strFindCode, ListView lvwList)
        {
            DataTable tempTable = new DataTable();
            com.digitalwave.iCare.ValueObject.clsEmployee_VO[] DataResultArr = null;
            long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetMainDoctor(this.m_objViewer.m_txtPatientDoctor.Text.ToString().Trim().ToUpper(), out DataResultArr);
            if (lngRes > 0 && DataResultArr.Length > 0)
            {
                for (int i = 0; i < DataResultArr.Length; i++)
                {
                    ListViewItem lvi = lvwList.Items.Add(DataResultArr[i].m_strEMPNO_CHR);
                    lvi.SubItems.Add(DataResultArr[i].m_strLASTNAME_VCHR);
                    lvi.Tag = DataResultArr[i].m_strEMPID_CHR;
                }
            }
        }

        internal void m_txtPatientDoctorInitListView(ListView lvwList)
        {
            lvwList.Columns.Add("���", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("ҽ��", 90, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 170;
        }

        internal void m_txtPatientDoctorSelectItem(ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_objViewer.m_txtPatientDoctor.Text = lviSelected.SubItems[1].Text;
                m_objViewer.m_txtPatientDoctor.Tag = lviSelected.Tag;
               
                    setTheControlOrder(this.m_objViewer.m_txtPatientDoctor.Name);
                
            }
        }

        #region ��ʼ��������
        /// <summary>
        /// ��ʼ��������
        /// </summary>
        public void InitializationComboBox()
        {
            ////��ʼ����Ժ��ʽ������
            ////��Ժ��ʽ{1=����;2=����;3=��Ժת��}
            //m_objViewer.m_cboTYPE_INT1.Items.Clear();
            //m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("", 0));
            //m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("1-����", 1));
            //m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("2-����", 2));
            //m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("3-��Ժת��", 3));
            //m_objViewer.m_cboTYPE_INT1.Items.Add(new clsComboBoxTextValue("4-����ת��", 4));

            //��ʼ������������
            //����{1=Σ;2=��;3=��ͨ}
            m_objViewer.m_cboSTATE_INT2.Items.Clear();
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("", 0));
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("1-Σ", 1));
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("2-��", 2));
            m_objViewer.m_cboSTATE_INT2.Items.Add(new clsComboBoxTextValue("3-��ͨ", 3));

            //����״̬{0=�´�;1=�ڴ�;2=Ԥ��Ժ;3=ʵ�ʳ�Ժ;4=���}
            m_objViewer.m_cboPSTATUS_INT.Items.Clear();
            m_objViewer.m_cboPSTATUS_INT.Items.Add(new clsComboBoxTextValue("", -1));
            m_objViewer.m_cboPSTATUS_INT.Items.Add(new clsComboBoxTextValue("0-�´�", 0));
            m_objViewer.m_cboPSTATUS_INT.Items.Add(new clsComboBoxTextValue("1-�ڴ�", 1));
            m_objViewer.m_cboPSTATUS_INT.Items.Add(new clsComboBoxTextValue("2-Ԥ��Ժ", 2));
            m_objViewer.m_cboPSTATUS_INT.Items.Add(new clsComboBoxTextValue("3-ʵ�ʳ�Ժ", 3));
            m_objViewer.m_cboPSTATUS_INT.Items.Add(new clsComboBoxTextValue("4-���", 4));
           
            //��ʼ���������������
            this.m_objServer.m_FillCboPatientType(m_objViewer.cobPaytypeid2);
            //��ע��Ϣ
            DataTable m_dtSpcMessage = new DataTable();
            long lngReg = m_objServer.m_lngGetSPECREMARKMessage(out m_dtSpcMessage);
            ////��ʼ���������������
            //m_objRegister.m_FillCboNationality(m_objViewer.txtNationality2);

            ////��ʼ���������������
            //m_objRegister.m_FillCboPatientRace(m_objViewer.txtRace2);

            //��ʼ������������
            //m_objRegister.m_FillCboPatientNativeplace(m_objViewer.txtNationality2);

            //��ʼ��ְҵ������
            //m_objRegister.m_FillCboPatienttxtOccupation(m_objViewer.txtOccupation2);

            ////��ʼ����ϵ������
            //m_objRegister.m_FillCboPatientRelation(m_objViewer.txtRelation2);

            ////��ʼ�����������
            //m_objRegister.m_FillCboMarried(m_objViewer.cobMarried2);

            ////��ʼ���Ա�������
            //m_objRegister.m_FillCboSex(m_objViewer.cboSex2);
        }
        #endregion

        internal void m_txtSPECREMARKFindItem(string strFindCode, ListView lvwList)
        {
            DataTable m_dtSpcMessage = new DataTable();
            long lngRes = m_objServer.m_lngGetSPECREMARKMessage(out m_dtSpcMessage);
            if (lngRes > 0 && m_dtSpcMessage.Rows.Count > 0)
            {
                clsSpecreMark_VO[] m_objSpecreMark_VO = new clsSpecreMark_VO[m_dtSpcMessage.Rows.Count];
                for (int i = 0; i < m_dtSpcMessage.Rows.Count; i++)
                {
                    m_objSpecreMark_VO[i] = new clsSpecreMark_VO();
                    m_objSpecreMark_VO[i].m_strREMARKID_CHR = m_dtSpcMessage.Rows[i]["REMARKID_CHR"].ToString().Trim();
                    m_objSpecreMark_VO[i].m_strREMARKNAME_VCHR = m_dtSpcMessage.Rows[i]["REMARKNAME_VCHR"].ToString().Trim();
                    m_objSpecreMark_VO[i].m_strUSERCODE_VCHR = m_dtSpcMessage.Rows[i]["USERCODE_VCHR"].ToString().Trim();
                    ListViewItem lvi = lvwList.Items.Add(m_objSpecreMark_VO[i].m_strUSERCODE_VCHR);
                    lvi.SubItems.Add(m_objSpecreMark_VO[i].m_strREMARKNAME_VCHR);
                    lvi.Tag = m_objSpecreMark_VO[i].m_strREMARKID_CHR;
                }
            }
        }

        internal void m_txtSPECREMARKInitListView(ListView lvwList)
        {
            lvwList.Columns.Add("����", 60, HorizontalAlignment.Left);
            lvwList.Columns.Add("��ע����", 90, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 170;
        }

        internal void m_txtSPECREMARKSelectItem(ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_objViewer.m_txtSPECREMARK.Text = lviSelected.SubItems[1].Text;
                m_objViewer.m_txtSPECREMARK.Tag = lviSelected.Tag;
                setTheControlOrder(this.m_objViewer.m_txtSPECREMARK.Name);
       
            }
        }

        internal void m_lngGetPatientByCondition()
        {

            string InPatientID_Chr = "", Name_VChr = "", AreaID_Chr = "", DOCTORID_CHR = "", PSTATUS_INT = "", STATE_INT = "", PayTypeID_Chr = "", REMARKID_CHR = "";
            DateTime m_dtStart = DateTime.MinValue, m_dtFinish = DateTime.MinValue;
            InPatientID_Chr = this.m_objViewer.txtINPatient1.Text.Trim();
            Name_VChr = this.m_objViewer.txtPatientName1.Text.Trim();
            if (this.m_objViewer.m_txtArea.Tag != null && !this.m_objViewer.m_txtArea.Text.Trim().Equals(""))
            {
                AreaID_Chr = (string)this.m_objViewer.m_txtArea.Tag;
            }
            if (this.m_objViewer.m_txtPatientDoctor.Tag != null && !this.m_objViewer.m_txtPatientDoctor.Text.Trim().Equals(""))
            {
                DOCTORID_CHR = (string)this.m_objViewer.m_txtPatientDoctor.Tag;
            }
            if (this.m_objViewer.m_cboPSTATUS_INT.SelectedIndex>0)
            {
                
                    PSTATUS_INT = (this.m_objViewer.m_cboPSTATUS_INT.SelectedIndex-1).ToString();
                
            }
            if (this.m_objViewer.m_cboSTATE_INT2.SelectedIndex>0)
            {
               
                    STATE_INT = (this.m_objViewer.m_cboSTATE_INT2.SelectedIndex).ToString();
                
            }
            if (this.m_objViewer.cobPaytypeid2.SelectedIndex > 0)
            {
                PayTypeID_Chr =((clsPatientPayTypeVO[])this.m_objViewer.cobPaytypeid2.Tag)[this.m_objViewer.cobPaytypeid2.SelectedIndex-1].m_strPAYTYPEID_CHR;
            }
            if (this.m_objViewer.m_txtSPECREMARK.Tag != null && !this.m_objViewer.m_txtSPECREMARK.Text.Trim().Equals(""))
            REMARKID_CHR = (string)this.m_objViewer.m_txtSPECREMARK.Tag;
            if (this.m_objViewer.m_cbInPatientDate.Checked)
            {
                m_dtStart = this.m_objViewer.m_dtpBeginDate.Value;
                m_dtFinish = this.m_objViewer.m_dtpEndDate.Value;
            }
            clsBIHPatientInfo[] m_ArrobjPatient;
            m_objServer.m_lngGetPatientByCondition(InPatientID_Chr, Name_VChr, AreaID_Chr, DOCTORID_CHR, PSTATUS_INT, STATE_INT, PayTypeID_Chr, REMARKID_CHR,m_dtStart, m_dtFinish,out m_ArrobjPatient);
            fillTheDatagridView(m_ArrobjPatient);
        }

        private void fillTheDatagridView(clsBIHPatientInfo[] m_ArrobjPatient)
        {
            this.m_objViewer.m_dgvPatientList.Rows.Clear();
            for (int i = 0; i < m_ArrobjPatient.Length; i++)
            {
                this.m_objViewer.m_dgvPatientList.Rows.Add();
                DataGridViewRow dataRow = this.m_objViewer.m_dgvPatientList.Rows[this.m_objViewer.m_dgvPatientList.RowCount-1];
                dataRow.Cells["m_dtvLASTNAME_VCHR"].Value = m_ArrobjPatient[i].m_strPatientName;
                dataRow.Cells["m_dtvINPATIENTID_CHR"].Value = m_ArrobjPatient[i].m_strInHospitalNo;
                dataRow.Cells["m_dtvAreaName"].Value = m_ArrobjPatient[i].m_strAreaName;
                dataRow.Cells["m_dtvSTATE_INT"].Value = m_ArrobjPatient[i].m_strSTATE_INT;
                dataRow.Cells["m_dtvPSTATUS_INT"].Value = m_ArrobjPatient[i].m_strInpatientState;
                dataRow.Cells["m_dtvDOCTOR_VCHR"].Value = m_ArrobjPatient[i].m_strDOCTOR_VCHR;
                dataRow.Cells["m_dtvSEX_CHR"].Value = m_ArrobjPatient[i].m_strSex;
                dataRow.Cells["m_dtveatdiccate"].Value = m_ArrobjPatient[i].m_strEatdiccate;
                dataRow.Cells["m_dtvnursecate"].Value = m_ArrobjPatient[i].m_strNursecate;
                dataRow.Cells["m_dtvPayTypeName_VChr"].Value = m_ArrobjPatient[i].m_strPayTypeName;
                dataRow.Cells["m_dtvREMARKNAME_VCHR"].Value = m_ArrobjPatient[i].m_strREMARKNAME_VCHR;
                dataRow.Tag = m_ArrobjPatient[i];
            }

//            ����������m_dtvLASTNAME_VCHR
//סԺ��    m_dtvINPATIENTID_CHR
//����      m_dtvAreaName
//����״̬  m_dtvSTATE_INT ����{1=Σ;2=��;3=��ͨ}
//סԺ״̬  m_dtvPSTATUS_INT {0=�´�;1=�ڴ�;2=Ԥ��Ժ;3=ʵ�ʳ�Ժ;4=���}
//����ҽʦ  m_dtvDOCTOR_VCHR
//�Ա�      m_dtvSEX_CHR
//��ʳ      m_dtveatdiccate
//������  m_dtvnursecate
//�������  m_dtvPayTypeName_VChr
//��ע��Ϣ   m_dtvREMARKNAME_VCHR
        }

        internal void IniAllControl()
        {
            this.m_objViewer.txtINPatient1.Tag = null;
            this.m_objViewer.txtINPatient1.Text = "";
            this.m_objViewer.txtPatientName1.Tag = null;
            this.m_objViewer.txtPatientName1.Text = "";
            this.m_objViewer.m_txtArea.Tag = null;
            this.m_objViewer.m_txtArea.Text = "";
            this.m_objViewer.m_txtPatientDoctor.Tag = null;
            this.m_objViewer.m_txtPatientDoctor.Text = "";
            this.m_objViewer.m_cboSTATE_INT2.Tag = null;
            this.m_objViewer.m_cboSTATE_INT2.Text = "";
            this.m_objViewer.m_cboPSTATUS_INT.Tag = null;
            this.m_objViewer.m_cboPSTATUS_INT.Text = "";
            this.m_objViewer.cobPaytypeid2.Tag = null;
            this.m_objViewer.cobPaytypeid2.Text = "";
            this.m_objViewer.m_txtSPECREMARK.Tag = null;
            this.m_objViewer.m_txtSPECREMARK.Text = "";
            this.m_objViewer.m_cbInPatientDate.Checked= false;
            this.m_objViewer.m_dtpBeginDate.Value = DateTime.Now;
            this.m_objViewer.m_dtpEndDate.Value=DateTime.Now;
            
//txtINPatient1
//txtPatientName1
//m_txtArea
//m_txtPatientDoctor
//m_cboSTATE_INT2
//m_cboPSTATUS_INT
//cobPaytypeid2
//m_txtSPECREMARK
//m_cbInPatientDate
        }

        internal void ViewTheDataWindow()
        {
            try
            {
            m_objViewer.dw_1.Reset();
            int newRow;
            //DateTime executedate_dat, INPATIENT_DAT;

            //m_objViewer.dw_1.Modify("area_name.text='" + this.m_objViewer.LoginInfo.m_strInpatientAreaName + "'");
            //m_objViewer.dw_1.Modify("execute_dat.text='" + DateTime.Now.ToString("yyyy.MM.dd") + "'");

            for (int i = 0; i <this.m_objViewer.m_dgvPatientList.RowCount; i++)
            {
                newRow = m_objViewer.dw_1.InsertRow();
                clsBIHPatientInfo m_objPatient=(clsBIHPatientInfo)this.m_objViewer.m_dgvPatientList.Rows[i].Tag;
                m_objViewer.dw_1.SetItemString(newRow, "column1", m_objPatient.m_strPatientName);
                m_objViewer.dw_1.SetItemString(newRow, "column2", m_objPatient.m_strInHospitalNo);
                m_objViewer.dw_1.SetItemString(newRow, "column3", m_objPatient.m_strAreaName);
                m_objViewer.dw_1.SetItemString(newRow, "column4", m_objPatient.m_strSTATE_INT);
                m_objViewer.dw_1.SetItemString(newRow, "column5", m_objPatient.m_strInpatientState);
                m_objViewer.dw_1.SetItemString(newRow, "column6", m_objPatient.m_strDOCTOR_VCHR);
                m_objViewer.dw_1.SetItemString(newRow, "column7", m_objPatient.m_strSex);
                m_objViewer.dw_1.SetItemString(newRow, "column8", m_objPatient.m_strEatdiccate);
                m_objViewer.dw_1.SetItemString(newRow, "column9", m_objPatient.m_strNursecate);
                m_objViewer.dw_1.SetItemString(newRow, "column10",m_objPatient.m_strPayTypeName);
                m_objViewer.dw_1.SetItemString(newRow, "column11", m_objPatient.m_strREMARKNAME_VCHR);
            }


            m_objViewer.dw_1.AcceptText();
            m_objViewer.dw_1.Sort();
            m_objViewer.dw_1.CalculateGroups();
            //m_objViewer.dw_1.Visible = true;
            
                DWPrintPreview printPreview = new DWPrintPreview(m_objViewer.dw_1);
                printPreview.ShowDialog();
            }
            catch (Exception ex)
            {
                DWErrorHandler.HandleDWException(ex);
            }
        }

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="m_strName">�ؼ���</param>
        public void setTheControlOrder(string m_strName)
        {

            switch (m_strName)
            {
                case "txtINPatient1":
                    if (this.m_objViewer.txtPatientName1.Enabled == true)
                    {
                        this.m_objViewer.txtPatientName1.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.txtPatientName1.Name);
                    }
                    break;
                case "txtPatientName1":
                    if (this.m_objViewer.m_txtArea.Enabled == true)
                    {
                        this.m_objViewer.m_txtArea.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.m_txtArea.Name);
                    }
                    break;
                case "m_txtArea":
                    if (this.m_objViewer.m_txtPatientDoctor.Enabled == true)
                    {
                        this.m_objViewer.m_txtPatientDoctor.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.m_txtPatientDoctor.Name);
                    }
                    break;
                case "m_txtPatientDoctor":
                    if (this.m_objViewer.m_cboSTATE_INT2.Enabled == true)
                    {
                        this.m_objViewer.m_cboSTATE_INT2.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.m_cboSTATE_INT2.Name);
                    }
                    break;
                case "m_cboSTATE_INT2":
                    if (this.m_objViewer.m_cboPSTATUS_INT.Enabled == true)
                    {
                        this.m_objViewer.m_cboPSTATUS_INT.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.m_cboPSTATUS_INT.Name);
                    }
                    break;
                case "m_cboPSTATUS_INT":
                    if (this.m_objViewer.cobPaytypeid2.Enabled == true)
                    {
                        this.m_objViewer.cobPaytypeid2.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.cobPaytypeid2.Name);
                    }
                    break;
                case "cobPaytypeid2":
                    if (this.m_objViewer.m_txtSPECREMARK.Enabled == true)
                    {
                        this.m_objViewer.m_txtSPECREMARK.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.m_txtSPECREMARK.Name);
                    }
                    break;
                case "m_txtSPECREMARK":
                    if (this.m_objViewer.m_cbInPatientDate.Enabled == true)
                    {
                        this.m_objViewer.m_cbInPatientDate.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.m_cbInPatientDate.Name);
                    }
                    break;
                case "m_cbInPatientDate":
                    if (this.m_objViewer.m_dtpBeginDate.Enabled == true)
                    {
                        this.m_objViewer.m_dtpBeginDate.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.m_dtpBeginDate.Name);
                    }
                    break;
                case "m_dtpBeginDate":
                    if (this.m_objViewer.m_dtpEndDate.Enabled == true)
                    {
                        this.m_objViewer.m_dtpEndDate.Focus();
                    }
                    else
                    {
                        setTheControlOrder(this.m_objViewer.m_dtpEndDate.Name);
                    }
                    break;
                default:
                    this.m_objViewer.m_cmdQuery.Focus();
                    break;

            }
        }
    }
}
