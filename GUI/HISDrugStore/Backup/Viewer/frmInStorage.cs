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
    /// ҩ����⴦��
    /// </summary>
    public partial class frmInStorage : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {   
        /// <summary>
        /// constructor
        /// </summary>
        public frmInStorage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ����״̬��0-���ϣ�1--���ƣ�2-��ˣ�3--���ʣ�
        /// </summary>
        private int m_intStatus = -1;
        /// <summary>
        /// ���洫���ҩ��id
        /// </summary>
        public string[] m_strMedStoreArr=null;
        /// <summary>
        /// ���洫���ҩ��id(��Ӧ�Ĳ���ID��
        /// </summary>
        public string[] m_strMedStoreDeptIDArr = null;
        /// <summary>
        /// ��ǰѡ�еĵ���
        /// </summary>
        internal string m_strBillID = string.Empty;
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
        /// �Զ����������
        /// </summary>
        /// <param name="m_strMedStordid">��ʾ��ҩ��id</param>
        public void m_mthSetShow(string m_strMedStordid)
        {
            m_strMedStoreArr = m_strMedStordid.Split('*');
            m_strMedStoreDeptIDArr = m_strMedStoreArr.Clone() as string[];
            this.Show();
        }
        private void m_dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void m_btnNew_Click(object sender, EventArgs e)
        {
            frmInStorageMakeOrder objMakeOrder = new frmInStorageMakeOrder();
            objMakeOrder.m_blnIsHospital = m_blnIsHospital;
            objMakeOrder.frmMain = this;
            objMakeOrder.FormClosing+=new FormClosingEventHandler(objMakeOrder_FormClosing1);
            objMakeOrder.Show();

        }
        private void objMakeOrder_FormClosing1(object sender, FormClosingEventArgs e)
        {
            DataRow[] drNull = null;
            if (((frmInStorageMakeOrder)sender).m_dtInStorageMedicine != null && ((frmInStorageMakeOrder)sender).m_btnInsert.Enabled && ((frmInStorageMakeOrder)sender).m_blnClosed == false)
            {
                drNull = ((frmInStorageMakeOrder)sender).m_dtInStorageMedicine.Select("medicineid_chr is null and opamount_int is null");//ѡ�����õ�����
                if (drNull != null)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        ((frmInStorageMakeOrder)sender).m_dtInStorageMedicine.Rows.Remove(drTemp);
                    }
                }
                DataTable dtbNew = ((frmInStorageMakeOrder)sender).m_dtInStorageMedicine.GetChanges(DataRowState.Added);
                DataTable dtbEdit = ((frmInStorageMakeOrder)sender).m_dtInStorageMedicine.GetChanges(DataRowState.Modified);
                if ((dtbNew != null && dtbNew.Rows.Count > 0) || (dtbEdit != null && dtbEdit.Rows.Count > 0))
                {
                    DialogResult drResult = MessageBox.Show("��ǰ�������δ������Ƶ���¼��ȷ���˳�?", "ҩ������Ƶ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }

            if (this.IsDisposed) return;
            m_btnFind.PerformClick();
            //List<clsDS_Instorage_VO> m_objInstorageList=((frmInStorageMakeOrder)sender).m_objInstorageList;
            //DataTable dtSource = (DataTable)m_dgvMain.DataSource;
            //DataRow newRow;
            //for (int i = 0; i < m_objInstorageList.Count; i++)
            //{
            //    newRow = dtSource.NewRow();
            //    newRow["seriesid_int"] = m_objInstorageList[i].m_lngSERIESID_INT;
            //    newRow["indrugstoreid_vchr"] = m_objInstorageList[i].m_strINDRUGSTOREID_VCHR;
            //    newRow["medstorename_vchr"] = m_objInstorageList[i].m_strDRUGSTOREName;
            //    newRow["askid_vchr"] = m_objInstorageList[i].m_strASKID_VCHR;
            //    newRow["outstorageid_vchr"] = m_objInstorageList[i].m_strOUTSTORAGEID_VCHR;
            //    newRow["drugstoreid_chr"] = m_objInstorageList[i].m_strDRUGSTOREID_INT;
            //    newRow["comment_vchr"] = m_objInstorageList[i].m_strCOMMENT_VCHR;
            //    switch(m_objInstorageList[i].m_intSTATUS)
            //    {
            //        case 1: newRow["status"] = "����"; break;
            //        case 2: newRow["status"] = "���"; break;
            //    }
                
            //    //switch (m_objInstorageList[i].m_intFORMTYPE_INT)
            //    //{
            //    //    case 1: newRow["formtype_int"] = "ҩ����ⵥ"; break;
            //    //    case 2: newRow["formtype_int"] = "���쵥"; break;
            //    //    case 3: newRow["formtype_int"] = "������ҩ"; break;
            //    //    case 4: newRow["formtype_int"] = "ҩ�����"; break;
            //    //    case 5: newRow["formtype_int"] = "ҩ����ӯ"; break;
            //    //} 
            //    newRow["formtype_int"] = m_objInstorageList[i].m_intFORMTYPE_INT;
            //    newRow["typecode_vchr"] = m_objInstorageList[i].m_strTYPECODE_VCHR;
            //    newRow["typename_vchr"] = m_objInstorageList[i].m_strTYPENAME_VCHR;
            //    newRow["borrowdept_chr"] = m_objInstorageList[i].m_strBORROWDEPT_CHR;
            //    newRow["deptname_vchr"] = m_objInstorageList[i].m_strBORROWDEPTName_CHR;
            //    newRow["makeorder_dat"] = m_objInstorageList[i].m_datMAKEORDER_DAT;
            //    newRow["makerid_chr"] = m_objInstorageList[i].m_strMAKERID_CHR;
            //    newRow["makername"] = m_objInstorageList[i].m_strMakeName;
            //    newRow["drugstoreexam_date"] = m_objInstorageList[i].m_datDRUGSTOREEXAM_DATE;
            //    newRow["drugstoreexamid_chr"] = m_objInstorageList[i].m_strDRUGSTOREEXAMID_CHR;
            //    newRow["drugstoreexamname_chr"] = m_objInstorageList[i].m_strDRUGSTOREEXAMName;
            //    dtSource.Rows.InsertAt(newRow,0);
            //}
            //if (m_objInstorageList.Count != 0)
            //{
            //    this.m_dgvMain.Rows[this.m_dgvMain.Rows.Count - 1].Selected = true;
            //}
            //clsPub.m_mthDispose((Form)sender);
        }
        /// <summary>
        ///  �������Ʋ����
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_InStorage();
            this.objController.Set_GUI_Apperance(this);
        }
        private void frmInStorage_Load(object sender, EventArgs e)
        {
            this.m_datBegin.Text = clsPub.CurrentDateTimeNow.ToString("yyyy��MM��dd�� 00ʱ00��00��");
            this.m_datEnd.Text = clsPub.CurrentDateTimeNow.ToString("yyyy��MM��dd�� 23ʱ59��59��");
            this.m_dgvDetail.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvMain.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvDetail.AutoGenerateColumns = false;
            this.m_dgvMain.AutoGenerateColumns = false;

            ((clsCtl_InStorage)this.objController).m_lngCheckIsHospital(m_strMedStoreArr[0], out m_blnIsHospital);
            if (m_blnIsHospital)
            {
                m_dgvDetail.Columns["unit_chr"].HeaderText = "סԺ��λ";
            }
            this.m_cboInstorageType.SelectedIndex = 0;
            this.m_cboStatus.SelectedIndex = 0;
            //  this.m_bgwGetData.RunWorkerAsync();
            this.m_mthGetInitialData();
            ((clsCtl_InStorage)this.objController).m_mthBorrowDeptInfo();
            clsPub.m_lngCheckEmpHasRole(this.LoginInfo.m_strEmpID, out m_blnHasDSManageRole);

           // m_btnExam.Enabled = clsPub.m_blnCommitEnabled();
        }
        /// <summary>
        /// ҩ��������Ϣ
        /// </summary>
       public DataTable m_dtMedStoreInfo = new DataTable();
        /// <summary>
        /// ҩƷ������Ϣ��
        /// </summary>
        public DataTable m_dtMedicine = new DataTable();
        /// <summary>
        /// ���������Ϣ
        /// </summary>
        public DataTable m_dtBorrowDept;
        /// <summary>
        /// �������
        /// </summary>
        public DataTable m_dtInStoreType = new DataTable();
        /// <summary>
        /// �Ƿ���ҩ�������ɫ
        /// </summary>
        public bool m_blnHasDSManageRole = false;
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
                                //m_strMedStoreArr[j] = m_dtMedStoreInfo.Rows[i]["medstoreid_chr"].ToString();
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
            this.m_cboInstorageType.Items.Clear();
            this.m_cboInstorageType.Item.Add("ȫ��", string.Empty);
            if (this.m_dtInStoreType != null)
            {
                for (int i = 0; i < this.m_dtInStoreType.Rows.Count; i++)
                {
                    this.m_cboInstorageType.Item.Add(m_dtInStoreType.Rows[i]["TYPENAME_VCHR"].ToString(), m_dtInStoreType.Rows[i]["TYPECODE_VCHR"].ToString());
                }
            }
            this.m_cboInstorageType.SelectedIndex = 0;

           // m_btnFind.PerformClick();
            ((clsCtl_InStorage)this.objController).m_mthGetCurrentDayInstoragenfo();
        }
        /// <summary>
        /// ��ȡ��ʼ������
        /// </summary>
        private void m_mthGetInitialData()
        {
            clsPub.m_lngGetMedStoreInfo(out this.m_dtMedStoreInfo);
           // clsPub.m_mthGetMedBaseInfo(m_strMedStoreArr[0], out this.m_dtMedicine);
            clsPub.m_lngGetTypeCode(0, out this.m_dtInStoreType);
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
                                //m_strMedStoreArr[j] = m_dtMedStoreInfo.Rows[i]["medstoreid_chr"].ToString();
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
            this.m_cboInstorageType.Items.Clear();
            this.m_cboInstorageType.Item.Add("ȫ��", string.Empty);
            if (this.m_dtInStoreType != null)
            {
                for (int i = 0; i < this.m_dtInStoreType.Rows.Count; i++)
                {
                    this.m_cboInstorageType.Item.Add(m_dtInStoreType.Rows[i]["TYPENAME_VCHR"].ToString(), m_dtInStoreType.Rows[i]["TYPECODE_VCHR"].ToString());
                }
            }
            this.m_cboInstorageType.SelectedIndex = 0;

            // m_btnFind.PerformClick();
            ((clsCtl_InStorage)this.objController).m_mthGetCurrentDayInstoragenfo();
        }
        private void m_bgwGetData_DoWork(object sender, DoWorkEventArgs e)
        {
            clsPub.m_lngGetMedStoreInfo(out this.m_dtMedStoreInfo);
           // clsPub.m_mthGetMedBaseInfo(m_strMedStoreArr[0],out this.m_dtMedicine);
            clsPub.m_lngGetTypeCode(0, out this.m_dtInStoreType);
        }

        private void m_dgvMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.m_dgvMain.CurrentCell == null)
                return;
            m_strBillID = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"].Value);
            ((clsCtl_InStorage)this.objController).m_lngGetInstorageDetailByID();
        }

        private void m_dgvDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            DateTime dtTemp;
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
                if (DateTime.TryParse(Convert.ToString(this.m_dgvDetail.Rows[iRow].Cells["validperiod_dat"].Value), out dtTemp))
                {

                    if (dtTemp.ToString("yyyy-MM-dd").Trim() == "0001-01-01")
                    {
                        this.m_dgvDetail.Rows[iRow].Cells["validperiod_dat"].Value = DBNull.Value;
                    }
                }
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

        private void m_dgvDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            DateTime dtTemp;
            for (int iRow = 0; iRow < this.m_dgvDetail.Rows.Count; iRow++)
            {
                m_dgvDetail.Rows[iRow].Cells[0].Value = iRow + 1;
                if (DateTime.TryParse(Convert.ToString(this.m_dgvDetail.Rows[iRow].Cells["validperiod_dat"].Value), out dtTemp))
                {

                    if (dtTemp.ToString("yyyy-MM-dd").Trim() == "0001-01-01")
                    {
                        this.m_dgvDetail.Rows[iRow].Cells["validperiod_dat"].Value = DBNull.Value;
                    }
                }
            }
        }

        private void m_btnFind_Click(object sender, EventArgs e)
        {
            m_lblRetailMoney.Text = string.Empty;
            ((clsCtl_InStorage)this.objController).m_mthGetInstoragenfoByconditions();
        }        

        private void m_dgvMain_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.m_dgvMain.CurrentCell == null || this.m_dgvMain.CurrentCell.RowIndex == -1) return;
            frmInStorageMakeOrder objMakeOrder = new frmInStorageMakeOrder();
            objMakeOrder.m_blnIsHospital = m_blnIsHospital;
            objMakeOrder.frmMain = this;
            //objMakeOrder.m_btnNext.Enabled = false;
            objMakeOrder.m_intFormType = Convert.ToInt16(this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtFormType"].Value);           
            objMakeOrder.m_lngMainSEQ = Convert.ToInt64(this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtSeq"].Value);           
            ((clsCtl_InStorage)this.objController).m_lngCheckStatus(0, objMakeOrder.m_lngMainSEQ, out m_intStatus);
            objMakeOrder.IsCanModify = m_intStatus == 1 ? true : false;
            //20080604:������������Ƶ�����£��ҵ���������3��4��6��3��ҩ���������Դ����������ҩ���� 4�����ҽ������Դ���ų���ҩ������Ĳ��ţ���6ҩ�����ҩ������
            //�����г���������������޸ģ���������һ�ɲ������޸ģ�������������
            //����ΰ�޸�:��ԭ�ȵ�3,4,6״̬�޸�Ϊ3,6
            if ((objMakeOrder.m_intFormType == 3 || objMakeOrder.m_intFormType == 6)&& m_intStatus == 1)
            {
                objMakeOrder.m_intCommitStatus = 2;
            }
            else if (m_intStatus == 2 || m_intStatus == 3)
            {
                objMakeOrder.m_intCommitStatus = 1;
            }
            
            objMakeOrder.m_datMakeDate.Value =Convert.ToDateTime(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtAskDate"].Value) ;
            objMakeOrder.m_txtMaker.Text = m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMakeName"].Value.ToString();
            objMakeOrder.m_txtMaker.Tag = m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMakeid"].Value.ToString();
            objMakeOrder.m_cboStatus.Text = m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["TYPENAME_VCHR"].Value.ToString();
            objMakeOrder.m_cboStatus.AccessibleName = m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["TYPECODE_VCHR"].Value.ToString();
            objMakeOrder.m_txtFromDept.Text = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtFromDept"].Value);
            objMakeOrder.m_txtFromDept.AccessibleName = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtFromDeptid"].Value);
            objMakeOrder.m_cboMedStore.Text = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMedStoreName"].Value);
            objMakeOrder.m_cboMedStore.AccessibleName = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtMedStoreid"].Value);
            //m_strBillID = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"].Value);
            objMakeOrder.m_txtBillId.Text = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"].Value);
            objMakeOrder.m_txtComment.Text = Convert.ToString(m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtComment"].Value);
            objMakeOrder.m_dtInStorageMedicine = (DataTable)this.m_dgvDetail.DataSource;
            objMakeOrder.FormClosing+=new FormClosingEventHandler(objMakeOrder_FormClosing1);
            objMakeOrder.Show();
        }

        private void m_btnModify_Click(object sender, EventArgs e)
        {
            if (this.IsDisposed || m_dgvMain.CurrentCell == null)
                return;
            m_dgvMain_CellDoubleClick(null, null);
        }

        private void objMakeOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (((frmInStorageMakeOrder)sender).m_intCommitStatus != 0 && ((frmInStorageMakeOrder)sender).m_blnSaved == true)
            //{
            //    int intRowIndex = 0;
            //    foreach(DataGridViewRow dgvr in m_dgvMain.Rows)
            //    {
            //        if (Convert.ToString(dgvr.Cells["m_txtBillNo"].Value) == ((frmInStorageMakeOrder)sender).m_txtBillId.Text)
            //        {
            //            intRowIndex = dgvr.Cells["m_txtBillNo"].RowIndex;
            //            m_dgvMain.Rows[intRowIndex].Cells["m_txtAskDate"].Value = ((frmInStorageMakeOrder)sender).m_datMakeDate.Value;
            //            m_dgvMain.Rows[intRowIndex].Cells["m_txtFormType"].Value = ((frmInStorageMakeOrder)sender).m_cboStatus.Text;
            //            m_dgvMain.Rows[intRowIndex].Cells["TYPECODE_VCHR"].Value = ((frmInStorageMakeOrder)sender).m_cboStatus.SelectItemValue != string.Empty ? ((frmInStorageMakeOrder)sender).m_cboStatus.SelectItemValue : ((frmInStorageMakeOrder)sender).m_cboStatus.AccessibleName;
            //            m_dgvMain.Rows[intRowIndex].Cells["TYPENAME_VCHR"].Value = ((frmInStorageMakeOrder)sender).m_cboStatus.Text;
            //            m_dgvMain.Rows[intRowIndex].Cells["m_txtFromDept"].Value = ((frmInStorageMakeOrder)sender).m_txtFromDept.Text;
            //            m_dgvMain.Rows[intRowIndex].Cells["m_txtFromDeptid"].Value = ((frmInStorageMakeOrder)sender).m_txtFromDept.StrItemId.Trim();
            //            m_dgvMain.Rows[intRowIndex].Cells["m_txtMedStoreName"].Value = ((frmInStorageMakeOrder)sender).m_cboMedStore.Text;
            //            m_dgvMain.Rows[intRowIndex].Cells["m_txtMedStoreid"].Value = ((frmInStorageMakeOrder)sender).m_cboMedStore.SelectItemValue != string.Empty ? ((frmInStorageMakeOrder)sender).m_cboMedStore.SelectItemValue : ((frmInStorageMakeOrder)sender).m_cboMedStore.AccessibleName;
            //            m_dgvMain.Rows[intRowIndex].Cells["m_txtComment"].Value = ((frmInStorageMakeOrder)sender).m_txtComment.Text;
            //            break;
            //        }
            //    }                
            //    //m_dgvMain.Rows[intRowIndex].Cells["m_txtStatus"].Value = "���";
            //}
        }

        private void m_dgvMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
            int m_intFormType = 0;
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {               
                if (this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value!=null&&this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                {
                    m_blnChecked = true;
                    m_intBillNo++;
                    //����Ƿ�����
                    ((clsCtl_InStorage)this.objController).m_lngCheckStatus(0, Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_intStatus);
                    if (m_intStatus != 1)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (m_intBillNo) + "����ⵥ��������״̬,���ܽ���ɾ����", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    //����Ƿ�����
                    ((clsCtl_InStorage)this.objController).m_lngCheckFormType(Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_intFormType);
                    if (m_intFormType == 3)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (m_intBillNo) + "����ⵥ��ҩ�������ĵ���,���ܽ���ɾ����", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else if (m_intFormType == 6)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (m_intBillNo) + "����ⵥ��ҩ�ⷢ��ҩ���ĵ���,���ܽ���ɾ����", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

            }
            if (!m_blnChecked)
            {
                MessageBox.Show("����ѡ��Ҫɾ������ⵥ","ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if(DialogResult.Cancel==MessageBox.Show("�Ƿ�ȷʵҪɾ����ѡ�����ⵥ", "ҩ�����", MessageBoxButtons.OKCancel, MessageBoxIcon.Information,MessageBoxDefaultButton.Button1))
            {
                return;
            }
            ((clsCtl_InStorage)this.objController).m_lngDelInstorage();
            
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
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {
                
                if (this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_dgvMain.Rows[i].Cells[0].Value.ToString() == "T")
                {
                    m_blnChecked = true;
                    m_intBillNo++;
                    //����Ƿ�����
                    ((clsCtl_InStorage)this.objController).m_lngCheckStatus(0, Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_intStatus);
                    if (m_intStatus != 1)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (m_intBillNo) + "����ⵥ��������״̬,���ܽ�����ˣ�", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }                    
                }
            }
            if (!m_blnChecked)
            {
                MessageBox.Show("����ѡ��Ҫ��˵���ⵥ��","ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_InStorage)this.objController).m_mthInstorageExam();
        }

        private void m_btnUnExam_Click(object sender, EventArgs e)
        {
            if (!this.m_blnHasDSManageRole)
            {
                MessageBox.Show("��ǰ�û�û��ҩ������Ȩ�ޣ���������", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.m_dgvMain.CurrentCell != null && this.m_dgvMain.CurrentCell.ColumnIndex == 0)
            {
                this.m_dgvMain.CurrentCell = this.m_dgvMain.Rows[this.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtBillNo"];
            }
            bool m_blnChecked = false;
            bool blnEnough=false;
            Application.DoEvents();
            int m_intBillNo=0;
            clsDS_StorageDetail_VO[] m_objDetailVoArr;
            for (int i = 0; i < this.m_dgvMain.Rows.Count; i++)
            {
              
                if (this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value != null && this.m_dgvMain.Rows[i].Cells["m_chkSelected"].Value.ToString() == "T")
                {
                    m_blnChecked =true;
                    m_intBillNo++;
                    //����Ƿ����
                    ((clsCtl_InStorage)this.objController).m_lngCheckStatus(0, Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_intStatus);
                    if (m_intStatus != 2)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (m_intBillNo) + "����ⵥ�������״̬,���ܽ�������", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    ((clsCtl_InStorage)this.objController).m_mthGetInstorageDetailVoArrByid(Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_objDetailVoArr);
                    for (int j = 0; j < m_objDetailVoArr.Length; j++)
                    {
                        blnEnough = false;
                        ((clsCtl_InStorage)this.objController).m_mthInstorageUnExamCheck(m_objDetailVoArr[j].m_strDRUGSTOREID_CHR, m_objDetailVoArr[j].m_strLOTNO_VCHR, m_objDetailVoArr[j].m_strMEDICINEID_CHR, m_objDetailVoArr[j].m_dtmINSTORAGEDATE_DAT, m_objDetailVoArr[j].m_dblOPREALGROSS_INT,out blnEnough);
                        if (blnEnough == false)
                        {
                            MessageBox.Show("����ѡ��ĵ�" + (m_intBillNo) + "����ⵥ����ҩƷ�Ѿ�����,���ܽ�������", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
            }
            if (!m_blnChecked)
            {
                MessageBox.Show("����ѡ��Ҫ�������ⵥ��", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_InStorage)this.objController).m_mthInstorageUnExam();
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
                    //����Ƿ����
                    ((clsCtl_InStorage)this.objController).m_lngCheckStatus(0, Convert.ToInt64(this.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value), out m_intStatus);
                    if (m_intStatus != 2)
                    {
                        MessageBox.Show("����ѡ��ĵ�" + (i + 1) + "����ⵥ�������״̬,���ܽ������ʣ�", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (!m_blnChecked)
            {
                MessageBox.Show("����ѡ��Ҫ���ʵ���ⵥ��", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ((clsCtl_InStorage)this.objController).m_mthInstorageAccount();
        }
     
        private void m_cboInstorageType_Enter(object sender, EventArgs e)
        {
            clsPub.m_mthSendF4();
        }

        private void Controls_KeyDown(object sender, KeyEventArgs e)
        {
            clsPub.m_mthSendTab(sender,e);
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

        private void m_dgvMain_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            return;
        }

        private void m_txtMedicineCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (this.m_dtMedicineInfo == null || this.m_dtMedicineInfo.Rows.Count == 0)
                {
                    clsPub.m_mthGetMedBaseInfo(m_strMedStoreArr[0], out m_dtMedicineInfo);
                }
                ((clsCtl_InStorage)objController).m_mthShowQueryMedicineForm(this.m_txtMedicineCode.Text, m_dtMedicineInfo);
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