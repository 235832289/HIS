using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// ����ҩ���������
    /// </summary>
    public partial class frmAskForMedManage : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {   
        /// <summary>
        /// ���캯��
        /// </summary>
        public frmAskForMedManage()
        {
            InitializeComponent();
            m_intDaysToValidDate = Convert.ToInt32(this.objController.m_objComInfo.m_lonGetModuleInfo("5032"));

        }
        /// <summary>
        /// �ⷿ���ͱ�ʶ--1��ҩ����ˣ�2��ҩ�����
        /// </summary>
        public string strStorageType = string.Empty;
        /// <summary>
        /// �ⷿid��ʶ
        /// </summary>
        public string strStorageid =string.Empty;
        /// <summary>
        /// �����������������Ƚϣ��Ƿ��㹻
        /// </summary>
        internal Hashtable m_hstEnough = new Hashtable();
        /// <summary>
        /// 'ҩ��ҩƷ��ʧЧ���ض�ʱ������',Ĭ��30����λ����
        /// </summary>
        private int m_intDaysToValidDate = 30;
        /// <summary>
        /// �Ƿ�סԺҩ��
        /// </summary>
        internal bool m_blnIsHospital = false;

        //20081016����ʵ�ϣ���������סԺҩ����־m_blnIsHospital�����洫�����ʱ�Ѳ����ٴ�0000�ˣ���������������ҡ�
        /// <summary>
        /// ���ݲ���������ʾ����
        /// </summary>
        /// <param name="m_strStorageType">1��ҩ����ˣ�2��ҩ�����</param>
        /// <param name="m_strStorageid">��m_strStorageType=1ʱ��m_strStorageidΪҩ��id��m_strStorageid����0000ʱ��������ҩ������m_strStorageType=2ʱ��m_strStorageidΪҩ��id��m_strStorageid����0000ʱ��������ҩ��</param>
        public void m_mthSetShow(string m_strStorageType,string m_strStorageid)
        {
            strStorageType = m_strStorageType;
         
            if (m_strStorageType == "1")
            {
                this.m_btnStorageExam.Enabled = false;
                this.m_btnStorageExam.Width = 0;
                this.Separator4.Width = 0;
                if (m_strStorageid == "0000")
                {
                    this.m_dgvAskMedDetail.Columns["askunit_chr"].HeaderText = "��λ";
                    this.m_dgvOutStorageDetail.Columns["unit_chr"].HeaderText = "��λ";
                    this.Show();
                }
                else
                {
                    strStorageid = m_strStorageid;
                    clsMedStore_VO objReturnVo = clsPub.m_mthGetMedStoreNameByid(m_strStorageid);
                    if (objReturnVo == null)
                    {
                        MessageBox.Show("���õ�ҩ��id����ȷ��");
                        return;
                    }
                    else
                    {
                        if (objReturnVo.m_strDeptid == string.Empty)
                        {
                            MessageBox.Show(objReturnVo.m_strMedStoreName + "û�а���ҩ����,���Ȱ�ҩ�����ţ�");
                            return;
                        }
                    }
                    this.Tag = objReturnVo.m_strDeptid;
                    this.AccessibleName = objReturnVo.m_strDeptName;
                    this.Text = string.Format("{0}��ҩ����", objReturnVo.m_strMedStoreName);

                    ((clsCtl_AskForMedManage)this.objController).m_lngCheckIsHospital(strStorageid, out m_blnIsHospital);

                    if (m_blnIsHospital)
                    {
                        this.m_dgvAskMedDetail.Columns["askunit_chr"].HeaderText = "סԺ��λ";
                        this.m_dgvOutStorageDetail.Columns["unit_chr"].HeaderText = "סԺ��λ";
                    }
                    this.Show();
                }
            }
            else if (m_strStorageType == "2")
            {
         
                this.m_btnNew.Width = 0;
                this.m_btnModify.Width = 0;
                this.m_btnDelete.Width = 0;
                this.m_btnCommit.Width = 0;
                this.m_btnDrugStoreExam.Width = 0;
                this.Separator1.Visible = false ;
                this.Separator2.Visible = false;
                this.Separator3.Visible = false;
                this.Separator4.Visible = false;
                this.Separator5.Visible = false;
                this.toolStripSeparator6.Visible = false;
                this.m_btnAccount.Width = 0;
                this.Separator9.Visible = false;
                this.m_btnShowDelete.Width = 0;

                this.m_dgvAskMedDetail.Columns["askunit_chr"].HeaderText = "��λ";
                this.m_dgvOutStorageDetail.Columns["unit_chr"].HeaderText = "��λ";

                if (m_strStorageid == "0000")
                {
                    this.Text = "ҩ����ҩ���";
                    this.Show();
                }
                else
                {
                    strStorageid = m_strStorageid;
                    string m_strStorageName = clsPub.m_lngGetExportDeptByid(m_strStorageid);
                    if (m_strStorageName == string.Empty)
                    {
                        MessageBox.Show("���õ�ҩ��id����ȷ��");
                        return;
                    }
                    else
                    {
                        this.Text = string.Format("{0}��ҩ���", m_strStorageName);
                        this.m_dgvAskMedMain.DoubleClick-=new EventHandler(m_dgvAskMedMain_DoubleClick);
                        this.Show();
                    }
                }
            }

        }
        /// <summary>
        /// ��д���෽��
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_AskForMedManage();
            objController.Set_GUI_Apperance(this);
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.m_dgvAskMedDetail.Visible = this.tabControl1.SelectedIndex == 0 ? true : false;
            this.m_dgvOutStorageDetail.Visible = !this.m_dgvAskMedDetail.Visible;
            if (this.tabControl1.SelectedIndex == 1)
            {
                // this.label13.Visible = true;
                // this.label16.Visible = true;
                //this.label18.Visible = true;
                // this.label9.Visible = true;

                //   this.m_lblly.Visible = true;
                // this.m_lblRetailmoney.Visible = true;
                //this.m_lblRetailSubMoney.Visible = true;
                //  this.m_lblly.Visible = true;
                // this.m_lblBuyInSubMoney.Visible = true;
                // this.m_lblWholeSaleSubMoney.Visible = true;
                ((clsCtl_AskForMedManage)this.objController).m_mthGetSubMoney(this.m_dgvOutStorageDetail.DataSource as DataTable);
            }
            else
            {
                // this.label13.Visible = false;
                // this.label16.Visible = false;
                //this.label18.Visible = false;
                //this.label9.Visible = false;

                // this.m_lblly.Visible = false;
                // this.m_lblRetailmoney.Visible = false;
                //this.m_lblRetailSubMoney.Visible = false;
                // this.m_lblly.Visible = false;
                //   this.m_lblBuyInSubMoney.Visible = false;
                //this.m_lblWholeSaleSubMoney.Visible = false;
                ((clsCtl_AskForMedManage)this.objController).m_mthGetSubMoneyForAsk(this.m_dgvAskMedDetail.DataSource as DataTable);
            }
        }
        #region ����
        /// <summary>
        /// ��������б�
        /// </summary>
        public DataTable m_dtApplyDept;
        #endregion
        private void frmAskForMedManage_Load(object sender, EventArgs e)
        {
            this.m_dgvAskMedMain.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvOutStorageMain.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvAskMedDetail.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvOutStorageDetail.AlternatingRowsDefaultCellStyle.BackColor = clsPublic.CustomBackColor;
            this.m_dgvAskMedMain.AutoGenerateColumns = false;
            this.m_dgvAskMedDetail.AutoGenerateColumns = false;
            this.m_dgvOutStorageDetail.AutoGenerateColumns = false;
            this.m_dgvOutStorageMain.AutoGenerateColumns = false;
            //this.backWorker.RunWorkerAsync();
            if (this.strStorageType == string.Empty)
            {
                ((clsCtl_AskForMedManage)this.objController).m_mthGetCurrentDayAskInfo(string.Empty,string.Empty);
            }
            else
            {
                if (strStorageType == "1")
                {
                    ((clsCtl_AskForMedManage)this.objController).m_mthGetCurrentDayAskInfo(this.Tag == null ? string.Empty : this.Tag.ToString().Trim(), string.Empty);
                }
                else
                {
                    ((clsCtl_AskForMedManage)this.objController).m_mthGetCurrentDayAskInfo(string.Empty, this.strStorageid);
                }
            }
            ((clsCtl_AskForMedManage)this.objController).m_mthGetApplyDeptInfo(out m_dtApplyDept);
            ((clsCtl_AskForMedManage)this.objController).m_mthGetExportDeptInfo();


        }
        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
            GC.Collect();
            GC.Collect();
        }
        private void m_btnNew_Click(object sender, EventArgs e)
        {
            frmAskForMedDetail frmDetail = new frmAskForMedDetail();
            frmDetail.m_blnIsHospital = m_blnIsHospital;
            frmDetail.frmMain = this;
            frmDetail.dtExportDept=((clsCtl_AskForMedManage)this.objController).m_dtExportDept;
            ((clsCtl_AskForMedicineDetail)frmDetail.objController).m_objMainVoList = new List<com.digitalwave.iCare.ValueObject.clsDS_Ask_VO>();
            frmDetail.FormClosed += new FormClosedEventHandler(frmDetail_FormClosed);
            frmDetail.Show();
        }

        private void frmDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.IsDisposed) return;

            List<clsDS_Ask_VO> objListVo = ((clsCtl_AskForMedicineDetail)((frmAskForMedDetail)sender).objController).m_objMainVoList;
            DataTable dtSource = (DataTable)this.m_dgvAskMedMain.DataSource;
            DataRow TempRow;
            foreach (clsDS_Ask_VO vo in objListVo)
            {
                TempRow = dtSource.NewRow();
                TempRow["SERIESID_INT"] = vo.m_lngSERIESID_INT;
                TempRow["askdate_dat"] = vo.m_datASKDATE_DAT;
                TempRow["status_int"] = "�ύ";
                TempRow["askerid_chr"] = vo.m_strASKERID_CHR;
                TempRow["askername"] = vo.m_strAskerName;
                TempRow["askdept_chr"] = vo.m_strASKDEPT_CHR;
                TempRow["askdeptname"] = vo.m_strAskDeptName;
                TempRow["EXPORTDEPT_CHR"] = vo.m_strEXPORTDEPT_CHR;
                TempRow["EXPORTDEPTNAME"] = vo.m_strExportDeptName;
                TempRow["askid_vchr"] = vo.m_strASKID_VCHR;
                TempRow["comment_vchr"] = vo.m_strComment;
                dtSource.Rows.Add(TempRow);
            }
            dtSource.AcceptChanges();
            if (dtSource.Rows.Count > 0)
            {
                this.m_dgvAskMedMain.Rows[dtSource.Rows.Count - 1].Selected = true;
                this.m_dgvAskMedMain.CurrentCell = this.m_dgvAskMedMain.Rows[dtSource.Rows.Count - 1].Cells["m_txtBillNo"];
            }
            this.m_btnReturn.PerformClick();
        }
        
        private void m_btnModify_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex==1||this.m_dgvAskMedMain.SelectedRows.Count <= 0)
            {
                MessageBox.Show("����ѡ��һ��Ҫ�޸ĵ�ҩ�����쵥��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            m_dgvAskMedMain_DoubleClick(null, null);
        }
    
        private void m_dgvAskMedMain_DoubleClick(object sender, EventArgs e)
        {
            if (this.IsDisposed || this.m_dgvAskMedMain.CurrentCell == null)
                return;
            int m_intSeleRowIndex = this.m_dgvAskMedMain.CurrentCell.RowIndex;
            frmAskForMedDetail frmDetail = new frmAskForMedDetail();
            frmDetail.m_blnIsHospital = this.m_blnIsHospital;
            //frmDetail.m_btnNext.Enabled = false;
            frmDetail.frmMain = this;
            frmDetail.dtExportDept = ((clsCtl_AskForMedManage)this.objController).m_dtExportDept;
            //ToDoList:��Ӧ���ݽ������ж�״̬
            if (this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtStatus"].Value.ToString() == "�ύ"
                || this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtStatus"].Value.ToString() == "����")
            {
                frmDetail.IsCanModify = true;
            }
            else
            {
                frmDetail.IsCanModify = false;
            }
            frmDetail.m_dtApplyMedicine = (DataTable)this.m_dgvAskMedDetail.DataSource;
            frmDetail.m_lngMainSEQ = Convert.ToInt64(this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtSeq"].Value);
            frmDetail.m_cboAskDept.Text = this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtAskDeptName"].Value.ToString();
            frmDetail.m_cboAskDept.AccessibleName = this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtDeptid"].Value.ToString();
            frmDetail.m_txtAskBillNo.Text = this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtBillNo"].Value.ToString();
            frmDetail.m_datApplyDate.Value = Convert.ToDateTime(this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtAskDate"].Value.ToString());
            frmDetail.m_txtAsker.Text = this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtAskName"].Value.ToString();
            frmDetail.m_txtAsker.AccessibleName = this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtAskerid"].Value.ToString();
            frmDetail.m_txtComment.Text = this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtComment"].Value.ToString();
            frmDetail.m_cboExportDept.Text = this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtExportDeptName"].Value.ToString();
            frmDetail.m_cboExportDept.AccessibleName = this.m_dgvAskMedMain.Rows[m_intSeleRowIndex].Cells["m_txtExportDept"].Value.ToString();
            frmDetail.FormClosed += new FormClosedEventHandler(frmDetail_FormClosed1);
            frmDetail.Show();
        }
        private void frmDetail_FormClosed1(object sender, FormClosedEventArgs e)
        {
            foreach (DataGridViewRow dgvr in m_dgvAskMedMain.Rows)
            {
                if (Convert.ToString(dgvr.Cells["m_txtBillNo"].Value) == ((frmAskForMedDetail)sender).m_txtAskBillNo.Text)
                {
                    if (((frmAskForMedDetail)sender).m_intStatus == 0)
                    {
                        this.m_dgvAskMedMain.Rows.Remove(dgvr);
                        break;
                    }
                    else
                    {
                        int intRowIndex = dgvr.Cells["m_txtBillNo"].RowIndex;
                        this.m_dgvAskMedMain.Rows[intRowIndex].Cells["m_txtComment"].Value = ((frmAskForMedDetail)sender).m_txtComment.Text;
                        this.m_dgvAskMedMain.Rows[intRowIndex].Cells["m_txtAskName"].Value = ((frmAskForMedDetail)sender).m_txtAsker.Text;
                        this.m_dgvAskMedMain.Rows[intRowIndex].Cells["m_txtAskerid"].Value = ((frmAskForMedDetail)sender).m_txtAsker.AccessibleName;
                        this.m_dgvAskMedMain.Rows[intRowIndex].Cells["m_txtAskDate"].Value = ((frmAskForMedDetail)sender).m_datApplyDate.Value;
                        this.m_dgvAskMedMain.Rows[intRowIndex].Cells["m_txtAskDeptName"].Value = ((frmAskForMedDetail)sender).m_cboAskDept.Text;
                        this.m_dgvAskMedMain.Rows[intRowIndex].Cells["m_txtDeptid"].Value = ((frmAskForMedDetail)sender).m_cboAskDept.SelectItemValue.Trim() == string.Empty ? ((frmAskForMedDetail)sender).m_cboAskDept.AccessibleName : ((frmAskForMedDetail)sender).m_cboAskDept.SelectItemValue.Trim();
                        this.m_dgvAskMedMain.Rows[intRowIndex].Cells["m_txtExportDeptName"].Value = ((frmAskForMedDetail)sender).m_cboExportDept.Text;
                        this.m_dgvAskMedMain.Rows[intRowIndex].Cells["m_txtExportDept"].Value = ((frmAskForMedDetail)sender).m_cboExportDept.SelectItemValue.Trim() == string.Empty ? ((frmAskForMedDetail)sender).m_cboExportDept.AccessibleName : ((frmAskForMedDetail)sender).m_cboExportDept.SelectItemValue.Trim();
                        this.m_dgvAskMedMain.CurrentCell = dgvr.Cells["m_txtBillNo"];
                        m_dgvAskMedMain_CurrentCellChanged(m_dgvAskMedMain, null);
                        break;
                    }
                }
            }            
        }

        private void m_btnDelete_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1 || this.m_dgvAskMedMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("����ѡ��һ��Ҫɾ����ҩ�����쵥��", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //string m_strStatus = this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtStatus"].Value.ToString().Trim();
            long lngSeq = Convert.ToInt64(this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtSeq"].Value);
            int intStatus = 0;
            ((clsCtl_AskForMedManage)this.objController).m_lngCheckStatus(3, lngSeq, out intStatus);
            string m_strStatus = string.Empty;
            switch (intStatus)
            {
                case 0:
                    m_strStatus = "����";
                    break;
                case 1:
                    m_strStatus = "����";
                    break;
                case 2:
                    m_strStatus = "�ύ";
                    break;
                case 3:
                    m_strStatus = "ҩ�����";
                    break;
                case 4:
                    m_strStatus = "ҩ�����";
                    break;
                case 5:
                    m_strStatus = "����";
                    break;
            }

            if (m_strStatus == "����" || m_strStatus == "�ύ")
            {
                if (DialogResult.Yes == MessageBox.Show("�����쵥һ�������Ͻ����ָܻ����Ƿ������", "ҩ��������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2))
                {
                    ((clsCtl_AskForMedManage)this.objController).m_mthDeleteAskInfo(lngSeq);
                }
                this.m_btnReturn.PerformClick();
            }
            else {
                MessageBox.Show("�����쵥�Ѿ�" + m_strStatus + ",�������ϣ�", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void m_dgvAskMedMain_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.m_dgvAskMedMain.CurrentCell == null)
                return;
            ((clsCtl_AskForMedManage)this.objController).m_lngGetAskDetailInfoByid();
        }

        private void m_dgvAskMedMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvAskMedMain.Rows.Count; iRow++)
            {
                m_dgvAskMedMain.Rows[iRow].Cells[0].Value = iRow + 1;               
            }
        }

        private void m_dgvAskMedMain_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvAskMedMain.Rows.Count; iRow++)
            {
                m_dgvAskMedMain.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvOutStorageMain_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvOutStorageMain.Rows.Count; iRow++)
            {
                this.m_dgvOutStorageMain.Rows[iRow].Cells[0].Value = iRow + 1;
                this.m_dgvOutStorageMain.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                if (this.m_dgvOutStorageMain.Rows[iRow].Cells["m_txtStatus_int"].Value.ToString() == "5")
                {
                    this.m_dgvOutStorageMain.Rows[iRow].DefaultCellStyle.ForeColor = Color.Magenta;
                }
                else if (this.m_dgvOutStorageMain.Rows[iRow].Cells["m_txtStatus_int"].Value.ToString() == "4")
                {
                    this.m_dgvOutStorageMain.Rows[iRow].DefaultCellStyle.ForeColor = SystemColors.HotTrack;
                }

            }
        }

        private void m_dgvOutStorageMain_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvOutStorageMain.Rows.Count; iRow++)
            {
                this.m_dgvOutStorageMain.Rows[iRow].Cells[0].Value = iRow + 1;
                this.m_dgvOutStorageMain.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                if (this.m_dgvOutStorageMain.Rows[iRow].Cells["m_txtStatus_int"].Value.ToString() == "5")
                {
                    this.m_dgvOutStorageMain.Rows[iRow].DefaultCellStyle.ForeColor = Color.Magenta;
                }
                else if (this.m_dgvOutStorageMain.Rows[iRow].Cells["m_txtStatus_int"].Value.ToString() == "4")
                {
                    this.m_dgvOutStorageMain.Rows[iRow].DefaultCellStyle.ForeColor = SystemColors.HotTrack;
                }
            }
        }

        private void m_dgvOutStorageDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if(m_dgvOutStorageMain.CurrentCell == null)return;
            DateTime m_datMakeOrder = Convert.ToDateTime(m_dgvOutStorageMain.Rows[m_dgvOutStorageMain.CurrentCell.RowIndex].Cells["m_txtMakeOrderDate"].Value);
            for (int iRow = 0; iRow < this.m_dgvOutStorageDetail.Rows.Count; iRow++)
            {
                this.m_dgvOutStorageDetail.Rows[iRow].Cells[0].Value = iRow + 1;
                m_dgvOutStorageDetail.Rows[iRow].DefaultCellStyle.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                if (m_hstEnough.ContainsKey(m_dgvOutStorageDetail.Rows[iRow].Cells["medicineid_chr"].Value))
                {
                    if (Convert.ToInt16(m_hstEnough[m_dgvOutStorageDetail.Rows[iRow].Cells["medicineid_chr"].Value]) == 0)
                    {
                        m_dgvOutStorageDetail.Rows[iRow].DefaultCellStyle.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    }
                }

                this.m_dgvOutStorageDetail.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
                if (Convert.ToString(this.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtEffectDate"].Value) == "")
                    continue;
                if (Convert.ToDateTime(this.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtEffectDate"].Value).Date < m_datMakeOrder.Date)
                {
                    if (Convert.ToDateTime(this.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtEffectDate"].Value).ToString("yyyy-MM-dd").Trim() != "0001-01-01")
                    {
                        this.m_dgvOutStorageDetail.Rows[iRow].DefaultCellStyle.ForeColor = Color.Crimson;
                    }
                }
                else if (Convert.ToDateTime(this.m_dgvOutStorageDetail.Rows[iRow].Cells["m_dgvtxtEffectDate"].Value).AddDays(-m_intDaysToValidDate).Date < m_datMakeOrder.Date)
                {
                    this.m_dgvOutStorageDetail.Rows[iRow].DefaultCellStyle.ForeColor = SystemColors.HotTrack;
                }
            }
        }

        private void m_dgvOutStorageDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvOutStorageDetail.Rows.Count; iRow++)
            {
                this.m_dgvOutStorageDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_dgvAskMedDetail_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvAskMedDetail.Rows.Count; iRow++)
            {
                this.m_dgvAskMedDetail.Rows[iRow].Cells[0].Value = iRow + 1;
                if (Convert.ToString(m_dgvAskMedDetail.Rows[iRow].Cells["ENOUGH_CHR"].Value) == "����")
                    m_dgvAskMedDetail.Rows[iRow].DefaultCellStyle.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //this.m_dgvAskMedDetail.Rows[iRow].DefaultCellStyle.ForeColor = Color.Red;
                else
                    m_dgvAskMedDetail.Rows[iRow].DefaultCellStyle.Font = new System.Drawing.Font("����", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
                    //this.m_dgvAskMedDetail.Rows[iRow].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void m_dgvAskMedDetail_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            for (int iRow = 0; iRow < this.m_dgvAskMedDetail.Rows.Count; iRow++)
            {
                this.m_dgvAskMedDetail.Rows[iRow].Cells[0].Value = iRow + 1;
            }
        }

        private void m_btnCommit_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1 || this.m_dgvAskMedMain.SelectedRows.Count == 0)
            {
                MessageBox.Show("����ѡ��һ��Ҫ�ύ��ҩ�����쵥��", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string m_strStatus = this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtStatus"].Value.ToString().Trim();
            if (m_strStatus != "����")
            {
                MessageBox.Show("�����쵥�Ѿ�" + m_strStatus + ",�����ύ��", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (this.m_dgvAskMedDetail.RowCount == 0)
            {
                MessageBox.Show("�����쵥û���κ�����ҩƷ,�����ύ��", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;

            }
            if (DialogResult.Yes == MessageBox.Show("�Ƿ�ȷ���ύ�����쵥��", "ҩ��������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1))
            {
                ((clsCtl_AskForMedManage)this.objController).m_mthCommitAskInfo();
            }
        }

        private void m_btnStorageExam_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1 || this.m_dgvAskMedMain.SelectedRows.Count==0)
            {
                if (this.tabControl1.SelectedIndex == 1)
                {
                    DialogResult dr=MessageBox.Show("�㵱ǰѡ�����ҩ����ⵥҳ�棬�Ƿ��л���ҩ�����쵥ҳ�棿", "ҩ��������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        this.tabControl1.SelectedIndex = 0;
                    }
                    else
                    {
                        if (m_dgvAskMedMain.Rows.Count <= 0)
                            return;
                        if (MessageBox.Show("�Ƿ��ӡ��ϸ��Ϣ", "ҩ��������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            ((clsCtl_AskForMedManage)this.objController).m_mthPrint();
                        }
                    }
                }
                else if (this.m_dgvAskMedMain.SelectedRows.Count == 0)
                {
                    MessageBox.Show("����ѡ��һ��Ҫ����ҩ����˵�ҩ�����쵥��", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
            string m_strStatus = string.Empty;// this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtStatus"].Value.ToString().Trim();            
            long lngSeq = Convert.ToInt64(this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtSeq"].Value);
            ((clsCtl_AskForMedManage)objController).m_lngGetAskStatus(lngSeq, out m_strStatus);
            if (m_strStatus != "�ύ")
            {
                if (m_strStatus == "����")
                {
                    MessageBox.Show("�����쵥��û���ύ�����ܽ���ҩ����ˣ�", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (m_strStatus == "ҩ�����")
                {
                    MessageBox.Show("�����쵥ҩ���Ѿ����,�����ٽ���ҩ����ˣ�", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (m_strStatus == "ҩ�����")
                {
                    MessageBox.Show("�����쵥ҩ���Ѿ����,�����ٽ���ҩ����ˣ�", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }
                frmMakeOutStorageOrder frmStorageExam = new frmMakeOutStorageOrder();
                frmStorageExam.m_dtbMedicineInfo = clsPub.m_dtMedicineInfo;
                frmStorageExam.FormClosing += new FormClosingEventHandler(frmStorageExam_FormClosing);
                frmStorageExam.Text += "{"+this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtExportDeptName"].Value.ToString().Trim()+"}";
                frmStorageExam.Tag = this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtExportDept"].Value.ToString().Trim();
                frmStorageExam.AccessibleName = this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtExportDeptName"].Value.ToString().Trim();                    
                frmStorageExam.m_txtApplyDept.Text = this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtAskDeptName"].Value.ToString().Trim();
                frmStorageExam.m_txtApplyDept.AccessibleName = this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtDeptid"].Value.ToString().Trim();
                frmStorageExam.m_txtAskBillNo.Text = this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtBillNo"].Value.ToString().Trim();
                frmStorageExam.m_lngAskSeq = Convert.ToInt64(this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtSeq"].Value);
                frmStorageExam.m_strStorageID = frmStorageExam.Tag.ToString();
                frmStorageExam.m_blnNew = true;                
                frmStorageExam.Show();
            
        }
        private void frmStorageExam_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmMakeOutStorageOrder frmStorageExam = sender as frmMakeOutStorageOrder;
            if (frmStorageExam.m_lngMainSEQ > 0)
            {
                //((clsCtl_AskForMedManage)this.objController).m_mthExamAskInfo(3);
                clsMS_OutStorage_VO vo = ((clsCtl_MakeOutStorageOrder)frmStorageExam.objController).m_objCurrentMain;
                DataTable dtSource = (DataTable)this.m_dgvOutStorageMain.DataSource;
                DataRow TempRow;
                    TempRow = dtSource.NewRow();
                    TempRow["SERIESID_INT"] = vo.m_lngSERIESID_INT;
                    TempRow["askdate_dat"] = vo.m_dtmASKDATE_DAT;
                    TempRow["askstatus_int"] = 3;
                    TempRow["askstatusname"] = "ҩ�����";
                    TempRow["askerid_chr"] = vo.m_strASKERID_CHR;
                    TempRow["askername"] = vo.m_strASKERName;
                    TempRow["askdept_chr"] = vo.m_strASKDEPT_CHR;
                    TempRow["askdeptname"] = vo.m_strASKDEPTName;
                    TempRow["EXPORTDEPT_CHR"] = vo.m_strEXPORTDEPT_CHR;
                    TempRow["storagename"] = vo.m_strEXPORTDEPTName;
                    TempRow["askid_vchr"] = vo.m_strASKID_VCHR;
                    TempRow["outstorageid_vchr"] = vo.m_strOUTSTORAGEID_VCHR;
                    TempRow["comment_vchr"] = vo.m_strCOMMENT_VCHR;
                    TempRow["outstoragedate_dat"] = vo.m_dtmOutStorageDate;
                    TempRow["examerid_chr"] = vo.m_strEXAMERID_CHR;
                    TempRow["examername"] = vo.m_strEXAMERName;
                    TempRow["examdate_dat"] = vo.m_dtmEXAMDATE_DAT;
                    TempRow["askseriesid_int"] = frmStorageExam.m_lngAskSeq;
                    dtSource.Rows.Add(TempRow);
                dtSource.AcceptChanges();
                if (dtSource.Rows.Count > 0)
                {
                    this.m_dgvOutStorageMain.Rows[dtSource.Rows.Count - 1].Selected = true;
                    this.m_dgvOutStorageMain.CurrentCell = this.m_dgvOutStorageMain.Rows[dtSource.Rows.Count - 1].Cells["m_txtOutStorageid"];
                }
                this.m_btnReturn.PerformClick();
            }
        }

        private void m_dgvAskMedMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        private void m_dgvAskMedMain_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.toolTip1.Hide(this.m_dgvAskMedMain);
        }
        private void m_dgvOutStorageMain_CurrentCellChanged(object sender, EventArgs e)
        {
            ((clsCtl_AskForMedManage)this.objController).m_lngGetOutStorageDetailInfoByid();
        }

        private void m_dgvOutStorageDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_dgvOutStorageMain_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void m_dgvOutStorageMain_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            this.toolTip1.Hide(this.m_dgvOutStorageMain);
        }

        private void m_dgvAskMedMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 1 || e.RowIndex == -1)
                return;
            this.toolTip1.ToolTipTitle = "���쵥��ϸ��Ϣ:";
            string m_strTemp = this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtBillNo"].Value == null ? string.Empty : this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtBillNo"].Value.ToString();
            string m_strCaption = "���쵥�ݺ�:" + m_strTemp + "\r\n";
            m_strTemp = this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtStatus"].Value == null ? string.Empty : this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtStatus"].Value.ToString();
            m_strCaption += "����״̬:" + m_strTemp + "\r\n";
            m_strTemp = this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtAskName"].Value == null ? string.Empty : this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtAskName"].Value.ToString();
            m_strCaption += "�� �� ��:" + m_strTemp + "\r\n";
            m_strTemp = this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtAskDate"].Value == null ? string.Empty : Convert.ToDateTime(this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtAskDate"].Value).ToString("yyyy��MM��dd��");
            m_strCaption += "����ʱ��:" + m_strTemp + "\r\n";
            m_strTemp = this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtAskDeptName"].Value == null ? string.Empty : this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtAskDeptName"].Value.ToString();
            m_strCaption += "���첿��:" + m_strTemp + "\r\n";
            m_strTemp = this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtExportDeptName"].Value == null ? string.Empty : this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtExportDeptName"].Value.ToString();
            m_strCaption += "���ⲿ��:" + m_strTemp + "\r\n";
            m_strTemp = this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtCommiter"].Value == null ? string.Empty : this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtCommiter"].Value.ToString();
            m_strCaption += "�� �� ��:" + m_strTemp + "\r\n";
            if (this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtCommitDate"].Value.GetType() == typeof(DBNull))
                m_strTemp = string.Empty;
            else
                m_strTemp = Convert.ToDateTime(this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtCommitDate"].Value).ToString("yyyy��MM��dd��");
            m_strCaption += "�ύ����:" + m_strTemp + "\r\n";
            m_strTemp = this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtComment"].Value == null ? string.Empty : this.m_dgvAskMedMain.Rows[e.RowIndex].Cells["m_txtComment"].Value.ToString();
            m_strCaption += "��    ע:" + m_strTemp;
            this.toolTip1.SetToolTip(this.m_dgvAskMedMain, m_strCaption);
        }

        private void m_dgvOutStorageMain_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0||e.RowIndex==-1)
                return;
            this.toolTip1.ToolTipTitle = "���ⵥ��ϸ��Ϣ:";
            string m_strTemp = this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtAskid"].Value == null ? string.Empty : this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtAskid"].Value.ToString();
            string m_strCaption = "���쵥�ݺ�:" + m_strTemp + "\r\n";
            m_strTemp = this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtOutStorageid"].Value == null ? string.Empty : this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtOutStorageid"].Value.ToString();
            m_strCaption += "���ⵥ�ݺ�:" + m_strTemp + "\r\n";


            m_strTemp = this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtAskStausName"].Value == null ? string.Empty : this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtAskStausName"].Value.ToString();
            m_strCaption += "���쵥״̬:" + m_strTemp + "\r\n";

            m_strTemp = this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtAskDepName"].Value == null ? string.Empty : this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtAskDepName"].Value.ToString();
            m_strCaption += "���첿��:" + m_strTemp + "\r\n";

            m_strTemp = this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtStorageName"].Value == null ? string.Empty : this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtStorageName"].Value.ToString();
            m_strCaption += "���ⲿ��:" + m_strTemp + "\r\n";

            m_strTemp = this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtExamerName"].Value == null ? string.Empty : this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtExamerName"].Value.ToString();
            m_strCaption += "�� �� ��:" + m_strTemp + "\r\n";
            if (this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtExamDate"].Value.GetType() == typeof(DBNull))
                m_strTemp = string.Empty;
            else
                m_strTemp = Convert.ToDateTime(this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtExamDate"].Value).ToString("yyyy��MM��dd��");
            m_strCaption += "�������:" + m_strTemp + "\r\n";
            m_strTemp = this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtCommentvchr"].Value == (object)string.Empty ? string.Empty : this.m_dgvOutStorageMain.Rows[e.RowIndex].Cells["m_txtCommentvchr"].Value.ToString();
            m_strCaption += "��    ע:" + m_strTemp;
            this.toolTip1.SetToolTip(this.m_dgvOutStorageMain, m_strCaption);
        }

        private void m_btnDrugStoreExam_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0 || this.m_dgvOutStorageMain.SelectedRows.Count == 0)
            {
                if (this.tabControl1.SelectedIndex == 0)
                {
                    DialogResult dr = MessageBox.Show("�㵱ǰѡ�����ҩ�����쵥ҳ�棬�Ƿ��л���ҩ����ⵥҳ�棿", "ҩ��������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        this.tabControl1.SelectedIndex = 1;
                    }
                }
                else if (this.m_dgvOutStorageMain.SelectedRows.Count == 0)
                {
                    MessageBox.Show("����ѡ��һ��Ҫ����ҩ����˵�ҩ����ⵥ��", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
            
                
            long lngOutStorageSeqid = Convert.ToInt64(this.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtSeqid"].Value);
            long lngAskSeqid = Convert.ToInt64(this.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskSeqid"].Value);
            string m_strStatus = string.Empty;//20080721��Ϊ�����ݿ��ȡ״̬����ֹ�ظ�ҩ�����
            ((clsCtl_AskForMedManage)objController).m_lngGetAskStatus(lngAskSeqid,out m_strStatus);
            //this.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskStausName"].Value.ToString().Trim();
            if (m_strStatus != "ҩ�����")
            {
                if (m_strStatus == "ҩ�����")
                {
                    MessageBox.Show("��ҩ����ⵥҩ���Ѿ����,�����ٽ���ҩ����ˣ�", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("��ҩ����ⵥ��״̬��"+m_strStatus+",���ܽ���ҩ����ˣ�", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            clsPublic.PlayAvi("FindFile.avi","���ڽ���ҩ����ˣ����Ժ�.....");
            ((clsCtl_AskForMedManage)this.objController).m_mthDrugStoreExam(lngOutStorageSeqid, lngAskSeqid);
            clsPublic.CloseAvi();

        }

        private void frmQuery_FormClosing(object sender, FormClosingEventArgs e)
        {  
            frmAskQuery frmQuery=sender as frmAskQuery;
            if (frmQuery.m_dtAskMainInfo != null && frmQuery.m_dtOutStorageMainInfo != null)
            {

                this.m_dgvOutStorageMain.Tag = frmQuery.m_dtOutStorageMainInfo;
                this.m_dgvOutStorageMain.DataSource = frmQuery.m_dtOutStorageMainInfo;
                //for (int iRow = 0; iRow < this.m_dgvOutStorageMain.Rows.Count; iRow++)
                //{
                //    if (this.m_dgvOutStorageMain.Rows[iRow].Cells["m_txtStatus_int"].Value.ToString() == "4")
                //    {
                //        this.m_dgvOutStorageMain.Rows[iRow].DefaultCellStyle.ForeColor = Color.Magenta;
                //    }
                //}
                this.m_dgvOutStorageMain.Refresh();
                if (frmQuery.m_dtOutStorageMainInfo.Rows.Count == 0)
                {
                    this.m_dgvOutStorageDetail.DataSource = null;
                }
                this.m_dgvAskMedMain.Tag = frmQuery.m_dtAskMainInfo;
                this.m_dgvAskMedMain.DataSource = frmQuery.m_dtAskMainInfo;
                this.m_dgvAskMedMain.Refresh();
                if (frmQuery.m_dtAskMainInfo.Rows.Count == 0)
                {
                    this.m_dgvAskMedDetail.DataSource = null;
                }
                ((clsCtl_AskForMedManage)this.objController).ShowMainAskMoney();
                ((clsCtl_AskForMedManage)this.objController).ShowMainOutMoney();
            }
        }
        private void m_btnReturn_Click(object sender, EventArgs e)
        {
            if (this.strStorageType == string.Empty)
            {
                    ((clsCtl_AskForMedManage)this.objController).m_mthGetCurrentDayAskInfo(string.Empty, string.Empty);
            }
            else
            {
                if (strStorageType == "1")
                {
                    ((clsCtl_AskForMedManage)this.objController).m_mthGetCurrentDayAskInfo(this.Tag == null ? string.Empty : this.Tag.ToString().Trim(), string.Empty);
                }
                else
                {
                    ((clsCtl_AskForMedManage)this.objController).m_mthGetCurrentDayAskInfo(string.Empty, this.strStorageid);
                }
            }
        }

        private void m_btnFind_Click(object sender, EventArgs e)
        {
            frmAskQuery frmQuery = new frmAskQuery();
            if (clsPub.m_dtMedicineInfo == null)
            {
                if (m_dgvAskMedMain.SelectedRows.Count > 0)
                {
                    clsPub.m_mthGetMedBaseInfo(this.m_dgvAskMedMain.SelectedRows[0].Cells["m_txtExportDept"].Value.ToString());
                }
                else
                {
                    clsPub.m_mthGetMedBaseInfo(strStorageid);
                }
            }
            frmQuery.m_dtbMedicineInfo = clsPub.m_dtMedicineInfo;
            frmQuery.m_dtAskDept = this.m_dtApplyDept;
            frmQuery.frmMain = this;
            frmQuery.m_dtExportDept = ((clsCtl_AskForMedManage)this.objController).m_dtExportDept;
            frmQuery.FormClosing += new FormClosingEventHandler(frmQuery_FormClosing);
            frmQuery.ShowDialog();
        }

        private void m_dgvOutStorageMain_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void m_btnShowDelete_Click(object sender, EventArgs e)
        {
            if (this.m_btnShowDelete.Image == null)
            {
                this.m_btnShowDelete.Image = global::com.digitalwave.iCare.gui.HIS.Properties.Resources.CheckBoxHS;
                DataView dv = ((DataTable)this.m_dgvAskMedMain.Tag).DefaultView;
                dv.RowFilter = "1=1";
                ((clsCtl_AskForMedManage)this.objController).m_dtAskMainInfo = dv.ToTable();
                this.m_dgvAskMedMain.DataSource = ((clsCtl_AskForMedManage)this.objController).m_dtAskMainInfo;
                 
                if (this.m_dgvAskMedMain.Rows.Count == 0)
                    this.m_dgvAskMedDetail.DataSource = null;
                
            }
            else
            {
                this.m_btnShowDelete.Image = null;
                DataView dv = ((DataTable)this.m_dgvAskMedMain.Tag).DefaultView;
                dv.RowFilter = "status_int<>'����'";
                ((clsCtl_AskForMedManage)this.objController).m_dtAskMainInfo = dv.ToTable();
                this.m_dgvAskMedMain.DataSource = ((clsCtl_AskForMedManage)this.objController).m_dtAskMainInfo;
                if (this.m_dgvAskMedMain.Rows.Count == 0)
                    this.m_dgvAskMedDetail.DataSource = null;
            }
        }

        private void backWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            clsPub.m_mthGetMedBaseInfo(strStorageid);
        }

        private void backWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.backWorker.Dispose();
        }

        private void m_btnAccount_Click(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedIndex == 0 || this.m_dgvOutStorageMain.SelectedRows.Count == 0)
            {
                if (this.tabControl1.SelectedIndex == 0)
                {
                    DialogResult dr = MessageBox.Show("�㵱ǰѡ�����ҩ�����쵥ҳ�棬�Ƿ��л���ҩ����ⵥҳ�棿", "ҩ��������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    if (dr == DialogResult.Yes)
                    {
                        this.tabControl1.SelectedIndex = 1;
                    }
                }
                else if (this.m_dgvOutStorageMain.SelectedRows.Count == 0)
                {
                    MessageBox.Show("����ѡ��һ��Ҫ����ҩ����˵�ҩ����ⵥ��", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
            string m_strStatus = this.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskStausName"].Value.ToString().Trim();
            long lngAskSeqid = Convert.ToInt64(this.m_dgvOutStorageMain.SelectedRows[0].Cells["m_txtAskSeqid"].Value);
            if (m_strStatus != "ҩ�����")
            {
                if (m_strStatus == "����")
                {
                    MessageBox.Show("��ҩ����ⵥҩ���Ѿ�����,�����ٽ������ʣ�", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    MessageBox.Show("��ҩ����ⵥ��״̬��" + m_strStatus + ",�������ʣ�", "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            ((clsCtl_AskForMedManage)this.objController).m_mthDrugStoreInAccount(lngAskSeqid);
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_AskForMedManage)this.objController).m_mthPrint();
        }
    }
}