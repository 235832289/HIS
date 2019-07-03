using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ҩ��������Ʋ�
    /// </summary>
    public class clsCtl_AskForMedicine : com.digitalwave.GUI_Base.clsController_Base
    {   
        /// <summary>
        /// ҩ������������
        /// </summary>
        private frmAskForMedicine m_objViewer;
        /// <summary>
        /// ҩ����������������Ʋ�
        /// </summary>
        private clsDcl_AskForMedicine m_objDomain;
        private clsDcl_AskForMedDetail m_objDomainDetail;
        /// <summary>
        /// ���캯��
        /// </summary>
        public clsCtl_AskForMedicine()
        {
            m_objDomain = new clsDcl_AskForMedicine();
            m_objDomainDetail = new clsDcl_AskForMedDetail();
        }
        public void m_mthIniMedData()
        {
            //m_objDomainDetail.m_lngGetMedicineInfo(this.m_objViewer.strout m_dtMedicineInfo);
        }
        /// <summary>
        /// ҩƷ������Ϣ��
        /// </summary>
        private DataTable m_dtMedicineInfo = new DataTable();
        /// <summary>
        /// ҩ������������Ϣ
        /// </summary>
        internal DataTable m_dtAskMainInfo = new DataTable();
        /// <summary>
        /// ҩ�����������Ϣ
        /// </summary>
        internal DataTable m_dtOutStorageMainInfo = new DataTable();
        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAskForMedicine)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// ��ȡ���첿����Ϣ
        /// </summary>
        public void m_mthGetApplyDeptInfo(out DataTable m_dtDept)
        {
            long lngRes = -1;
            m_dtDept=new DataTable ();
            lngRes = this.m_objDomain.m_lngGetApplyDept(out m_dtDept);
          
        }
        /// <summary>
        /// ��ȡ���ⲿ����Ϣ
        /// </summary>
        public void m_mthGetExportDeptInfo()
        {
            long lngRes = -1;
            DataTable m_dtExportDept = new DataTable();
            lngRes = this.m_objDomain.m_lngGetExportDept(out m_dtExportDept);
            this.m_objViewer.m_cboExportDept.Item.Add("ȫ��", "0001");
            if (lngRes > 0 && m_dtExportDept != null)
            {
                for (int i = 0; i < m_dtExportDept.Rows.Count; i++)
                {
                    this.m_objViewer.m_cboExportDept.Item.Add(m_dtExportDept.Rows[i]["medicineroomname"].ToString(), m_dtExportDept.Rows[i]["medicineroomid"].ToString());
                }
            }
        }
        /// <summary>
        /// ҩƷ��ѯ�ؼ�
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null; 
        #region ��ʾҩƷ�ֵ���СԪ����Ϣ��ѯ����
        /// <summary>
        /// ��ʾҩƷ�ֵ���СԪ����Ϣ��ѯ����
        /// </summary>
        /// <param name="p_strSearchCon">��ѯ����</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(this.m_dtMedicineInfo);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedName.Location.X + m_objViewer.gradientPanel2.Location.X;
                Y = m_objViewer.m_txtMedName.Location.Y + m_objViewer.m_txtMedName.Size.Height + m_objViewer.gradientPanel2.Location.Y;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthIniMedData();
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_dtMedicineInfo;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }
            m_objViewer.m_txtMedName.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedName.Text = MS_VO.m_strMedicineName;
            m_objViewer.m_txtBillId.Focus();
        }
        #endregion
        /// <summary>
        /// ��������������ѯҩ������������Ϣ
        /// </summary>
        public void m_mthGetAskInfoByConditions()
        {
            m_dtAskMainInfo = new DataTable();
            int m_intStatus = this.m_objViewer.m_cboStatus.SelectedIndex - 1;
            string m_strExpDept = this.m_objViewer.m_cboExportDept.SelectItemValue == "0001" ? string.Empty : this.m_objViewer.m_cboExportDept.SelectItemValue;
             this.m_objDomain.m_lngGetAskInfo(this.m_objViewer.m_datBegin.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_datEnd.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_txtApplyDept.StrItemId, m_strExpDept, m_intStatus, this.m_objViewer.m_txtMedName.Text, this.m_objViewer.m_txtBillId.Text, out m_dtAskMainInfo);
        }
        /// <summary>
        /// ��ȡҩ����������������Ϣ
        /// </summary>
        public void m_mthGetCurrentDayAskInfo(string m_strAskDeptid,string m_strStorageid)
        {
            m_dtAskMainInfo = new DataTable();
            m_dtOutStorageMainInfo = new DataTable();
            this.m_objDomain.m_lngGetAskInfo(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"), clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"),m_strAskDeptid,m_strStorageid, out m_dtAskMainInfo, out m_dtOutStorageMainInfo);
            this.m_mthBindData();
        }
        /// <summary>
        /// ��������Ϣ
        /// </summary>
        public void m_mthBindData()
        {    
           // DataView dv = new DataView(this.m_dtAskMainInfo);
            this.m_objViewer.m_dgvMain.DataSource = m_dtAskMainInfo;

        }
        /// <summary>
        /// ����������ˮ�Ż�ȡ��ϸ����Ϣ
        /// </summary>
        public void m_lngGetAskDetailInfoByid()
        {
            long lngRes = 0;
            DataTable m_dtDetail=new DataTable ();
            string m_strSeq=this.m_objViewer.m_dgvMain.Rows[this.m_objViewer.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtSeq"].Value.ToString().Trim();
            lngRes = this.m_objDomain.m_lngGetAskDetailInfoByid(false,Convert.ToInt64(m_strSeq), out m_dtDetail);//false������ֵ����˽���û��ʹ��
            if (lngRes > 0)
            {
                this.m_objViewer.m_dgvDetail.DataSource = m_dtDetail;
            }
        }
        #region ɾ������ҩƷ��Ϣ
        /// <summary>
        /// ɾ������ҩƷ��Ϣ
        /// </summary>
        internal void m_mthDeleteAskInfo()
        {
            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMain.Rows.Count; iSe++)
            {
                if (m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value != null && Convert.ToBoolean(m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value))
                {
                    string strState = m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtStatus"].Value.ToString().Trim();
                    if (strState == "ҩ�����" || strState == "ҩ�����")//�����
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtSeq"].Value));
                        continue;
                    }
                lngCheckRowIndex.Add(Convert.ToInt64(m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtSeq"].Value));
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("������ѡ���¼����ˣ�������ɾ�����Ƿ������", "ҩ������", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("���ȴ�ѡ�����Ƶ�ҩ��������Ϣ", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("�Ƿ�����ѡ�м�¼��", "ҩ������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            long lngRes = m_objDomain.m_lngDeleAskInfo(lngCheckRowIndex.ToArray());
            if (lngRes > 0)
            {
                MessageBox.Show("ɾ���ɹ�", "ҩƷ���", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
                {
                    for (int j = 0; j < lngCheckRowIndex.Count; j++)
                    {
                        if (Convert.ToInt64(m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value)== lngCheckRowIndex[j])
                        {
                            m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "����";
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ɾ��ʧ��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region �ύ����ҩƷ��Ϣ
        /// <summary>
        /// �ύ����ҩƷ��Ϣ
        /// </summary>
        internal void m_mthCommitAskInfo()
        {
            List<clsDS_Ask_VO> m_objAskVoList = new List<clsDS_Ask_VO>();
            clsDS_Ask_VO TempVo;
            List<long> lngWrongRowIndex = new List<long>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMain.Rows.Count; iSe++)
            {
                if (m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value != null && Convert.ToBoolean(m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value))
                {
                    string strState = m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtStatus"].Value.ToString().Trim();
                    if (strState == "ҩ�����" || strState == "ҩ�����")//�����
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtSeq"].Value));
                        continue;
                    }
                    TempVo = new clsDS_Ask_VO();
                    TempVo.m_lngSERIESID_INT = Convert.ToInt64(m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtSeq"].Value);
                    TempVo.m_intSTATUS_INT = 2;
                    TempVo.m_strCOMMITER_CHR=this.m_objViewer.LoginInfo.m_strEmpID;
                    TempVo.m_datCOMMIT_DAT=clsPub.CurrentDateTimeNow;
                    m_objAskVoList.Add(TempVo);
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("������ѡ���¼����ˣ��������ύ���Ƿ������", "ҩ������", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (m_objAskVoList.Count == 0)
            {
                MessageBox.Show("���ѡ�����Ƶ�ҩ��������Ϣ", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("�Ƿ��ύѡ�м�¼��", "ҩ������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            long lngRes = m_objDomain.m_lngCommiteAskInfo(m_objAskVoList.ToArray());
            if (lngRes > 0)
            {
                MessageBox.Show("�ύ�ɹ�", "ҩƷ���", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
                {
                    for (int j = 0; j < m_objAskVoList.Count; j++)
                    {
                        if (Convert.ToInt64(m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value) == m_objAskVoList[j].m_lngSERIESID_INT)
                        {
                            m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "�ύ";
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("ɾ��ʧ��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
