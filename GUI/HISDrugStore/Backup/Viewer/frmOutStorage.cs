using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ����
    /// </summary>
    public partial class frmOutStorage : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {  
        /// <summary>
        /// �Ƿ���ʾȱҩ��0-����ʾ��1-��ʾ
        /// </summary>
        public string m_strShowNoQuality = "1";
        /// <summary>
        /// ҩ��������Ϣ
        /// </summary>
        public DataTable m_dtMedStoreInfo = new DataTable();
        /// <summary>
        /// ҩƷ������Ϣ��
        /// </summary>
        public DataTable m_dtMedicine = new DataTable();
        /// <summary>
        /// ��ⲿ����Ϣ
        /// </summary>
        public DataTable m_dtInstoreDept;
        /// <summary>
        /// ��������
        /// </summary>
        public DataTable m_dtOutStoreType = new DataTable();
        /// <summary>
        /// ����״̬��0-���ϣ�1--���ƣ�2-��ˣ�3--���ʣ�
        /// </summary>
        private int m_intStatus = -1;
        /// <summary>
        /// ѡ���ĵ���
        /// </summary>
        internal string m_strBillNo = string.Empty;
        /// <summary>
        /// ҩƷ������Ϣ��
        /// </summary>
        internal DataTable m_dtMedicineInfo = null;
        /// <summary>
        /// �Ƿ�סԺ��λ
        /// </summary>
        internal bool m_blnIsHospital = false;
        /// <summary>
        /// ҩƷID��ҩƷ����
        /// </summary>
        internal string m_strMedicineID = string.Empty;
        /// <summary>
        /// ����
        /// </summary>
        public frmOutStorage()
        {
            InitializeComponent();
            this.m_strShowNoQuality = this.objController.m_objComInfo.m_lonGetModuleInfo("0407");
        }
        /// <summary>
        /// ���洫���ҩ��id
        /// </summary>
        public string[] m_strMedStoreArr = null;
        /// <summary>
        /// ���洫���ҩ��id(��Ӧ�Ĳ���ID��
        /// </summary>
        public string[] m_strMedStoreDeptIDArr = null;
        /// <summary>
        /// �Զ����������
        /// </summary>
        /// <param name="m_strMedStordid">��ʾ��ҩ��id</param>
        public void m_mthSetShow(string m_strMedStordid)
        {
            m_strMedStoreArr = m_strMedStordid.Split('*');
            m_strMedStoreDeptIDArr = m_strMedStoreArr.Clone() as string[];
            this.Show();
        }
        private void m_btnNew_Click(object sender, EventArgs e)
        {
            frmOutStorageMakerOrder objMakeOrder = new frmOutStorageMakerOrder();
            objMakeOrder.m_blnIsHospital = m_blnIsHospital;
            objMakeOrder.frmMain = this;
            objMakeOrder.FormClosing += new FormClosingEventHandler(frmOutStorage_FormClosing);
            objMakeOrder.Show();
        }

        private void frmOutStorage_FormClosing(object sender, FormClosingEventArgs e)
        {
            //List<clsDS_OutStorage_VO> m_objOutstorageList = ((frmOutStorageMakerOrder)sender).m_objOutstorageList;
            //DataTable dtSource = (DataTable)m_dgvMain.DataSource;
            //DataRow newRow;
            //for (int i = 0; i < m_objOutstorageList.Count; i++)
            //{
            //    newRow = dtSource.NewRow();
            //    newRow["seriesid_int"] = m_objOutstorageList[i].m_lngSERIESID_INT;
            //    newRow["outdrugstoreid_vchr"] = m_objOutstorageList[i].m_strOUTDRUGSTOREID_VCHR;
            //    newRow["medstorename_vchr"] = m_objOutstorageList[i].m_strDRUGSTOREName;
            //    newRow["INSTOREDEPT_CHR"] = m_objOutstorageList[i].m_strINSTOREDEPT_CHR;
            //    //newRow["outstorageid_vchr"] = m_objOutstorageList[i].m_strOUTSTORAGEID_VCHR;
            //    newRow["drugstoreid_chr"] = m_objOutstorageList[i].m_strDRUGSTOREID_CHR;
            //    newRow["comment_vchr"] = m_objOutstorageList[i].m_strCOMMENT_VCHR;
            //    switch (m_objOutstorageList[i].m_intSTATUS)
            //    {
            //        case 1: newRow["STATUS_INT"] = "����"; break;
            //        case 2: newRow["STATUS_INT"] = "���"; break;
            //    }
            //    //newRow["STATUS_INT"] = "����";
            //    //switch (m_objOutstorageList[i].m_intFORMTYPE_INT)
            //    //{
            //    //    case 1: newRow["formtype_int"] = "���˷�ҩ"; break;
            //    //    case 2: newRow["formtype_int"] = "�˿�"; break;
            //    //    case 3: newRow["formtype_int"] = "�̿�"; break;
            //    //    case 4: newRow["formtype_int"] = "����"; break;
            //    //    case 5: newRow["formtype_int"] = "ҩƷ����"; break;
            //    //    case 6: newRow["formtype_int"] = "ҩ�����"; break;
            //    //}
            //    newRow["formtype_int"] = m_objOutstorageList[i].m_intFORMTYPE_INT;
            //    newRow["typename_vchr"] = m_objOutstorageList[i].m_strTYPENAME_VCHR;
            //    newRow["INSTOREDEPT_CHR"] = m_objOutstorageList[i].m_strINSTOREDEPT_CHR;
            //    newRow["deptname_vchr"] = m_objOutstorageList[i].m_strINSTOREDEPTName_CHR;
            //    newRow["makeorder_dat"] = m_objOutstorageList[i].m_datMAKEORDER_DAT;
            //    newRow["makerid_chr"] = m_objOutstorageList[i].m_strMAKERID_CHR;
            //    newRow["makername"] = m_objOutstorageList[i].m_strMakeName;
            //    newRow["examdate_dat"] = m_objOutstorageList[i].m_datEXAM_DATE;
            //    newRow["examid_chr"] = m_objOutstorageList[i].m_strEXAMID_CHR;
            //    newRow["examname"] = m_objOutstorageList[i].m_strEXAMName;
            //    dtSource.Rows.InsertAt(newRow,0);
            //}
            //if (m_objOutstorageList.Count != 0)
            //{
            //    this.m_dgvMain.Rows[this.m_dgvMain.Rows.Count - 1].Selected = true;
            //    this.m_dgvMain.CurrentCell=this.m_dgvMain.Rows[this.m_dgvMain.Rows.Count - 1].Cells[2];
            //}
            ////clsPub.m_mthDispose((Form)sender);

            if (((frmOutStorageMakerOrder)sender).m_dtOutStorageMedicine != null && ((frmOutStorageMakerOrder)sender).m_btnDelete.Enabled)
            {                
                DialogResult drResult = MessageBox.Show("��ǰ�������δ������Ƶ���¼��ȷ���˳�?", "ҩ�������Ƶ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
            if (this.IsDisposed) return;
            m_btnFind.PerformClick();
        }
        /// <summary>
        ///  �������Ʋ����
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_OutStorage();
            this.objController.Set_GUI_Apperance(this);
        }

        private void frmOutStorage_Load(object sender, EventArgs e)
        {
            this.m_datBegin.Text = clsPub.CurrentDateTimeNow.ToString("yyyy��MM��dd�� 00ʱ00��00��");
            this.m_datEnd.Text = clsPub.CurrentDateTimeNow.ToString("yyyy��MM��dd�� 23ʱ59��59��");

            this.m_dgvDetail.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvMain.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvDetail.AutoGenerateColumns = false;
            this.m_dgvMain.AutoGenerateColumns = false;

            ((clsCtl_OutStorage)this.objController).m_lngCheckIsHospital(m_strMedStoreArr[0], out m_blnIsHospital);
            if (m_blnIsHospital)
            {
                m_dgvDetail.Columns["unit_chr"].HeaderText = "סԺ��λ";
            }

            this.m_cboStatus.SelectedIndex = 0;
            this.m_bgwGetData.RunWorkerAsync();
            //((clsCtl_OutStorage)this.objController).m_mthGetCurrentDayOutstoragenfo();
            ((clsCtl_OutStorage)this.objController).m_mthInstoreDeptInfo();

            m_btnExam.Enabled = clsPub.m_blnCommitEnabled();
        }
        internal void m_mthShowRetailMoney()
        {
            DataTable m_dtbDetail = (DataTable)this.m_dgvDetail.DataSource;
            m_lblRetailMoney.Text = "0.0000Ԫ";
            if (m_dtbDetail != null && m_dtbDetail.Rows.Count > 0)
            {
                double dblTemp = 0d;
                double dblTmp = 0d;
                for (int i1 = 0; i1 < m_dtbDetail.Rows.Count; i1++)
                {
                    double.TryParse(Convert.ToString(Convert.ToDouble(m_dtbDetail.Rows[i1]["ipamount_int"]) *( Convert.ToDouble(m_dtbDetail.Rows[i1]["OPRETAILPRICE_INT"]) / Convert.ToDouble(m_dtbDetail.Rows[i1]["PACKQTY_DEC"]))), out dblTmp);
                    dblTemp += Convert.ToDouble(dblTmp.ToString("F4"));
                }
                m_lblRetailMoney.Text = dblTemp.ToString("F4")+"Ԫ";
            }
            else
            {
                m_lblRetailMoney.Text = "0.0000Ԫ";
            }
        }

        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            clsPub.m_lngGetMedStoreInfo(out this.m_dtMedStoreInfo);
            if (m_strMedStoreArr!=null&&m_strMedStoreArr.Length >= 1)
            {
                clsPub.m_mthGetOutStorageMedBaseInfo(m_blnIsHospital,m_strMedStoreArr[0], out this.m_dtMedicine);
                if (this.m_strShowNoQuality == "0")
                {
                    DataView dv = this.m_dtMedicine.DefaultView;
                    dv.RowFilter = "noqtyflag_int=0";
                    this.m_dtMedicine = dv.ToTable();
                }

            }
            else
            {
                clsPub.m_mthGetMedBaseInfo(string.Empty, out m_dtMedicine);
            }
            clsPub.m_lngGetTypeCode(1, out this.m_dtOutStoreType);
        }

        private void m_bgwGetData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.m_cboMedStore.Item.Add("ȫ��", string.Empty);
            if (this.m_dtMedStoreInfo != null)
            {
                int intDeptIdIndex = 0;
                for (int i = 0; i < this.m_dtMedStoreInfo.Rows.Count; i++)
                {
                    if (this.m_strMedStoreArr != null)
                    {
                        for (int j = 0; j < m_strMedStoreArr.Length; j++)
                        {
                            if (m_strMedStoreArr[j].Trim() == m_dtMedStoreInfo.Rows[i]["medstoreid_chr"].ToString())
                            {
                                this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());
                                m_strMedStoreDeptIDArr[intDeptIdIndex] = m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString();
                                intDeptIdIndex++;
                            }
                        }
                    }
                    else
                    {
                        this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());
                    }
                }
            }
            this.m_cboMedStore.SelectedIndex = 0;
            if (m_cboMedStore.Items.Count > 0)
            {
                this.m_cboMedStore.SelectedIndex = m_cboMedStore.Items.Count - 1;
                this.Text += "(" + m_cboMedStore.SelectItemText + ")";
            }
            this.m_cboOutstorageType.Items.Clear();
            this.m_cboOutstorageType.Item.Add("ȫ��", string.Empty);
            if (this.m_dtOutStoreType != null)
            {
                for (int i = 0; i < this.m_dtOutStoreType.Rows.Count; i++)
                {
                    this.m_cboOutstorageType.Item.Add(m_dtOutStoreType.Rows[i]["TYPENAME_VCHR"].ToString(), m_dtOutStoreType.Rows[i]["TYPECODE_VCHR"].ToString());
                }
            }
            this.m_cboOutstorageType.SelectedIndex = 0;

            if (this.IsDisposed) return;
            m_btnFind.PerformClick();
        }

        private void m_dgvMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell == null)
                return;
            ((clsCtl_OutStorage)this.objController).m_lngGetOutstorageDetailByID();
            this.m_mthShowRetailMoney();
        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_btnFind_Click(object sender, EventArgs e)
        {
            ((clsCtl_OutStorage)this.objController).m_mthGetOutstoragenfoByconditions();
        }

        private void m_dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.m_dgvMain.CurrentCell == null || this.m_dgvMain.CurrentCell.RowIndex == -1) return;
            frmOutStorageMakerOrder objMakeOrder = new frmOutStorageMakerOrder();
            objMakeOrder.m_blnIsHospital = m_blnIsHospital;
            objMakeOrder.frmMain = this;
            
            //objMakeOrder.m_btnNext.Enabled = false;
            objMakeOrder.m_lngMainSEQ = Convert.ToInt64(this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtSeq"].Value);            
            ((clsCtl_OutStorage)this.objController).m_lngCheckStatus(1, objMakeOrder.m_lngMainSEQ, out m_intStatus);
            objMakeOrder.IsCanModify = m_intStatus == 1 ? true : false;
            objMakeOrder.m_blnIsCommit = (m_intStatus == 2 || m_intStatus == 3);
            objMakeOrder.m_intEditStatus = m_intStatus;
            //objMakeOrder.IsCanModify = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtStatus"].Value.ToString() == "����" ? true : false;
            objMakeOrder.m_datMakeDate.Value = Convert.ToDateTime(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtAskDate"].Value);
            objMakeOrder.m_txtMaker.Text = m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMakeName"].Value.ToString();
            objMakeOrder.m_txtMaker.Tag = m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMakeid"].Value.ToString();
            objMakeOrder.m_cboStatus.Text = m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["TYPENAME_VCHR"].Value.ToString();
            objMakeOrder.m_cboStatus.AccessibleName = m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["TYPECODE_VCHR"].Value.ToString();
            objMakeOrder.m_txtFromDept.Text = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtFromDept"].Value);
            objMakeOrder.m_txtFromDept.AccessibleName = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtFromDeptid"].Value);
            objMakeOrder.m_strOriginalDept = objMakeOrder.m_txtFromDept.AccessibleName;
            objMakeOrder.m_cboMedStore.Text = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMedStoreName"].Value);
            objMakeOrder.m_cboMedStore.AccessibleName = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMedStoreid"].Value);
            objMakeOrder.m_txtBillId.Text = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"].Value);
            m_strBillNo = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"].Value);
            objMakeOrder.m_txtComment.Text = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtComment"].Value);
            objMakeOrder.m_lblRetailMoney.Text = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["summoney"].Value);
            objMakeOrder.m_dtOutStorageMedicine = (DataTable)this.m_dgvDetail.DataSource;
            objMakeOrder.FormClosing += new FormClosingEventHandler(frmOutStorage_FormClosing);
            objMakeOrder.Show();
        }

        private void m_btnModify_Click(object sender, EventArgs e)
        {
            if (this.IsDisposed || this.m_dgvMain.CurrentCell == null)
                return;
            m_dgvMain_CellDoubleClick(null, null);
        }

        private void objMakeOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (((frmOutStorageMakerOrder)sender).IsCanModify == true)//������ֱ���˳�ʱ����bug��������ע�͵�20080110
            //{
                //m_dgvMain.Rows[m_dgvMain.CurrentCell.RowIndex].Cells["m_txtAskDate"].Value = ((frmOutStorageMakerOrder)sender).m_datMakeDate.Value;
                //m_dgvMain.Rows[m_dgvMain.CurrentCell.RowIndex].Cells["m_txtFormType"].Value = ((frmOutStorageMakerOrder)sender).m_cboStatus.Text;
                //m_dgvMain.Rows[m_dgvMain.CurrentCell.RowIndex].Cells["m_txtFromDept"].Value = ((frmOutStorageMakerOrder)sender).m_txtFromDept.Text;
                //m_dgvMain.Rows[m_dgvMain.CurrentCell.RowIndex].Cells["m_txtFromDeptid"].Value = ((frmOutStorageMakerOrder)sender).m_txtFromDept.StrItemId.Trim();
                //m_dgvMain.Rows[m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMedStoreName"].Value = ((frmOutStorageMakerOrder)sender).m_cboMedStore.Text;
                //m_dgvMain.Rows[m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMedStoreid"].Value = ((frmOutStorageMakerOrder)sender).m_cboMedStore.SelectItemValue.Trim();
                //m_dgvMain.Rows[m_dgvMain.CurrentCell.RowIndex].Cells["m_txtComment"].Value = ((frmOutStorageMakerOrder)sender).m_txtComment.Text;
            //}


        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell != null && this.m_dgvMain.CurrentCell.ColumnIndex == 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"];
            }
            bool m_blnChecked = false;
            Application.DoEvents();
            int m_intBillNo = 0;
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {

                if (this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                {
                    m_blnChecked = true;
                    m_intBillNo++;
                    //����Ƿ�����
                    ((clsCtl_OutStorage)this.objController).m_lngCheckStatus(1, Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_intStatus);
                    if (m_intStatus != 1)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (m_intBillNo) + "�ų��ⵥ��������״̬,���ܽ���ɾ����", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

            }
            if (!m_blnChecked)
            {
                MessageBox.Show("����ѡ��Ҫɾ���ĳ��ⵥ", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_OutStorage)this.objController).m_lngDelOutstorage();
        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_btnExam_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell != null && this.m_dgvMain.CurrentCell.ColumnIndex == 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"];
            }
            bool m_blnChecked = false;
            Application.DoEvents();
            int m_intBillNo = 0;
            int m_intStatus = -1;
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {

                if (this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_dgvMain.Rows[i].Cells[0].Value.ToString() == "T")
                {
                    m_blnChecked = true;
                    m_intBillNo++;
                    //����Ƿ�����
                    ((clsCtl_OutStorage)this.objController).m_lngCheckStatus(1, Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_intStatus);
                    if (m_intStatus != 1)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (m_intBillNo) + "�ų��ⵥ��������״̬,���ܽ�����ˣ�", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (!m_blnChecked)
            {
                MessageBox.Show("����ѡ��Ҫ��˵ĳ��ⵥ��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_OutStorage)this.objController).m_mthOutstorageExam();
        }

        private void m_btnUnExam_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell != null && this.m_dgvMain.CurrentCell.ColumnIndex == 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"];
            }
            bool m_blnChecked = false;
            Application.DoEvents();
            int m_intBillNo = 0;
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {

                if (this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                {
                    m_blnChecked = true;
                    m_intBillNo++;
                    //����Ƿ����
                    ((clsCtl_OutStorage)this.objController).m_lngCheckStatus(1, Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_intStatus);
                    if (m_intStatus != 2)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (m_intBillNo) + "�ų��ⵥ�������״̬,���ܽ�������", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (!m_blnChecked)
            {
                MessageBox.Show("����ѡ��Ҫ����ĳ��ⵥ��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_OutStorage)this.objController).m_mthOutstorageUnExam();
        }

        private void m_btnInAccount_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell != null && this.m_dgvMain.CurrentCell.ColumnIndex == 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"];
            }
            bool m_blnChecked = false;
            Application.DoEvents();
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {
                Application.DoEvents();
                if (this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                {
                    m_blnChecked = true;
                    //����Ƿ�����
                    ((clsCtl_OutStorage)this.objController).m_lngCheckStatus(1, Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_intStatus);
                    if (m_intStatus != 2)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (i+1) + "�ų��ⵥ�������״̬,���ܽ������ʣ�", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (!m_blnChecked)
            {
                MessageBox.Show("����ѡ��Ҫ���ʵĳ��ⵥ��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_OutStorage)this.objController).m_mthOutStorageInAccount();
        }

        private void m_cboInstorageType_Enter(object sender, EventArgs e)
        {
            clsPub.m_mthSendF4();
        }

        private void Controls_KeyDown(object sender, KeyEventArgs e)
        {
            clsPub.m_mthSendTab(sender, e);
        }

        private void m_txtBorrowDept_FocusNextControl(object sender, EventArgs e)
        {
            this.m_txtBillId.Focus();
        }

        private void m_lblSelected_Click(object sender, EventArgs e)
        {
            if (this.m_dgvMain.Rows.Count > 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[0].Cells["m_txtBillNo"];
                if (this.m_lblSelected.Text == "ȫѡ")
                {
                    m_lblSelected.Text = "��ѡ";
                    for (int iRow = 0; iRow < m_dgvMain.Rows.Count; iRow++)
                    {
                        m_dgvMain.Rows[iRow].Cells[0].Value = "T";
                    }
                }
                else if (m_lblSelected.Text == "��ѡ")
                {
                    m_lblSelected.Text = "ȫѡ";
                    for (int iRow = 0; iRow < m_dgvMain.Rows.Count; iRow++)
                    {
                        m_dgvMain.Rows[iRow].Cells[0].Value = "F";

                    }
                }
            }
        }

        private void m_lblSelected_MouseEnter(object sender, EventArgs e)
        {
            this.m_lblSelected.ForeColor = Color.Maroon;
            this.Cursor = Cursors.Hand;
        }

        private void m_lblSelected_MouseLeave(object sender, EventArgs e)
        {
            this.m_lblSelected.ForeColor = SystemColors.MenuHighlight;
            this.Cursor = Cursors.Default;
        }

        private void m_dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_dgvDetail_RowsAdded_1(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                this.m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;

                if (m_strMedicineID.Length > 0)
                {
                    if (m_rbtSingle.Checked)
                    {
                        if (Convert.ToString(m_dgvDetail.Rows[iRow].Cells["medicineid_chr"].Value).IndexOf(m_strMedicineID, 0) == 0)
                        {
                            m_dgvDetail.Rows[iRow].DefaultCellStyle.BackColor = SystemColors.Info;
                        }
                        else
                        {
                            if (iRow % 2 == 0)
                                m_dgvDetail.Rows[iRow].DefaultCellStyle.BackColor = Color.White;
                            else
                                m_dgvDetail.Rows[iRow].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                        }
                    }
                    else
                    {
                        if (Convert.ToString(m_dgvDetail.Rows[iRow].Cells["m_dgvtxtMedicineCode1"].Value).IndexOf(m_strMedicineID, 0) == 0)
                        {
                            m_dgvDetail.Rows[iRow].DefaultCellStyle.BackColor = SystemColors.Info;
                        }
                        else
                        {
                            if (iRow % 2 == 0)
                                m_dgvDetail.Rows[iRow].DefaultCellStyle.BackColor = Color.White;
                            else
                                m_dgvDetail.Rows[iRow].DefaultCellStyle.BackColor = clsPublic.CustomBackColor;
                        }
                    }
                }
            }
        }

        private void m_dgvDetail_RowsRemoved_1(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                this.m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_dtMedicineInfo == null || this.m_dtMedicineInfo.Rows.Count == 0)
                {
                    clsPub.m_mthGetMedBaseInfo(m_strMedStoreArr[0], out m_dtMedicineInfo);
                }
                ((clsCtl_OutStorage)objController).m_mthShowQueryMedicineForm(this.m_txtMedicineCode.Text, m_dtMedicineInfo);
            }
        }

        private void m_txtMedicineCode_TextChanged(object sender, EventArgs e)
        {
            if (m_txtMedicineCode.Text.Trim().Length == 0)
            {
                m_txtMedicineCode.Tag = string.Empty;
            }
        }

        private void splitter1_SplitterMoving(object sender, SplitterEventArgs e)
        {
            //20080730 ���Ų�ѯ�ؼ���bug���±������������
            ResumeLayout(false);
        }

        private void m_rbtSingle_CheckedChanged(object sender, EventArgs e)
        {
            m_txtMedicineCode.Clear();
            m_txtMedicineCode.Tag = "";
            m_txtMedicineCode.Focus();
        }
    }
}