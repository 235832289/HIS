using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{  
    /// <summary>
    /// ҩ��������ϸ
    /// </summary>
    public class clsCtl_AskForMedicineDetail : com.digitalwave.GUI_Base.clsController_Base
    {����
        /// <summary>
        /// ���캯��
        /// </summary>
        public clsCtl_AskForMedicineDetail()
        {
            m_objDomain = new clsDcl_AskForMedDetail();
        }
        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAskForMedDetail)frmMDI_Child_Base_in;
        }
        #endregion
        private frmAskForMedDetail m_objViewer;
        private clsDcl_AskForMedDetail m_objDomain;
        /// <summary>
        /// �����½����쵥
        /// </summary>
        public List<clsDS_Ask_VO> m_objMainVoList=null;
        /// <summary>
        /// ��ѯҩƷ�ֵ�ؼ�
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// ��ǰҩ������������Ϣ
        /// </summary>
        private clsDS_Ask_VO m_objCurrentMain = null;
        /// <summary>
        ///  ��ǰҩ�������ӱ���Ϣ
        /// </summary>
        private clsDS_Ask_Detail_VO[] m_objCurrentSubArr = null;
        #region �����µ�һ������ҩƷ��Ϣ
        /// <summary>
        /// �����µ�һ������ҩƷ��Ϣ
        /// </summary>
        internal void m_mthInsertNewMedicineInfo()
        {
            if (m_objViewer.m_dtApplyMedicine == null)
            {
                return;
            }
            if (this.m_objViewer.m_dtApplyMedicine.Rows.Count > 0)
            {
                DataRow drLast = this.m_objViewer.m_dtApplyMedicine.Rows[this.m_objViewer.m_dtApplyMedicine.Rows.Count - 1];
                if (drLast["MEDICINEID_CHR"] == DBNull.Value)
                {
                    this.m_objViewer.m_dgvDetail.Focus();
                    this.m_objViewer.m_dgvDetail.CurrentCell = this.m_objViewer.m_dgvDetail.Rows[this.m_objViewer.m_dtApplyMedicine.Rows.Count - 1].Cells[1];
                    this.m_objViewer.m_dgvDetail.CurrentCell.Selected = true;

                }
                else
                {
                    DataRow drNew = m_objViewer.m_dtApplyMedicine.NewRow();
                    m_objViewer.m_dtApplyMedicine.Rows.Add(drNew);
                    m_objViewer.m_dgvDetail.Focus();
                    m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail[1, m_objViewer.m_dgvDetail.RowCount - 1];
                    this.m_objViewer.m_dgvDetail.CurrentCell.Selected = true;
                }
            }
            else
            {
                DataRow drNew = m_objViewer.m_dtApplyMedicine.NewRow();
                m_objViewer.m_dtApplyMedicine.Rows.Add(drNew);
                m_objViewer.m_dgvDetail.Focus();
                m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail[1, m_objViewer.m_dgvDetail.RowCount - 1];
                this.m_objViewer.m_dgvDetail.CurrentCell.Selected = true;
            }

        }
        #endregion
        #region ��ʼ���ӱ���ΪDataGridView����Դ��DataTable
        /// <summary>
        /// ��ʼ���ӱ���ΪDataGridView����Դ��DataTable
        /// </summary>
        /// <param name="m_dtAskForMedDetail"></param>
        public void m_mthInitMedicineTable(ref DataTable m_dtAskForMedDetail)
        {
            m_dtAskForMedDetail = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("SERIESID_INT"), new DataColumn("SERIESID2_INT"), new DataColumn("MEDICINEID_CHR"),new DataColumn("assistcode_chr"), new DataColumn("MEDICINENAME_VCHR"),
                new DataColumn("MEDSPEC_VCHR"),new DataColumn("OPUNIT_CHR"),new DataColumn("OPAMOUNT_INT",typeof(double)),new DataColumn("IPUNIT_CHR"),new DataColumn("IPAMOUNT_INT",typeof(double)),new DataColumn("PACKQTY_DEC",typeof(string)),
            new DataColumn("UNIT_CHR"),new DataColumn("AMOUNT_INT",typeof(double)),new DataColumn("opchargeflg_int",typeof(Int16)),new DataColumn("ipchargeflg_int",typeof(Int16)),new DataColumn("productorid_chr"),new DataColumn("unitprice_mny",typeof(double)),new DataColumn("retailsum",typeof(double)),
            new DataColumn("requestamount_int",typeof(double)),new DataColumn("requestunit_chr",typeof(string)),new DataColumn("requestpackqty_dec",typeof(double))};
            m_dtAskForMedDetail.Columns.AddRange(dcColumns);
            //m_dtAskForMedDetail.Columns["retailsum"].Expression = " OPAMOUNT_INT * unitprice_mny ";
        }
        #endregion
        /// <summary>
        /// ��ȡҩƷ������Ϣ��
        /// </summary>
        /// <param name="m_dtMedInfo"></param>
        public void m_lngGetMedicineInfoForAsk(string m_strMedStoreid, out DataTable m_dtMedInfo)
        {
            m_dtMedInfo = new DataTable();
            this.m_objDomain.m_lngGetMedicineInfoForAsk(m_strMedStoreid, out m_dtMedInfo);            
        }

        /// <summary>
        /// ��ȡҩƷ������Ϣ��(��ʾ�����Ϣ)
        /// </summary>
        /// <param name="m_dtMedInfo"></param>
        public void m_lngGetMedicineInfoForAskWithStorageInfo(bool p_blnIsHospital, string m_strMedStoreid, out DataTable m_dtMedInfo)
        {
            m_dtMedInfo = new DataTable();
            this.m_objDomain.m_lngGetMedicineInfoForAskWithStorageInfo(p_blnIsHospital, m_strMedStoreid, out m_dtMedInfo);            
        }

        
        #region ��ʾҩƷ�ֵ���СԪ����Ϣ��ѯ����
        /// <summary>
        /// ��ʾҩƷ�ֵ���СԪ����Ϣ��ѯ����
        /// </summary>
        /// <param name="p_strSearchCon">��ѯ����</param>
        /// <param name="p_dtbMedicint">�ֵ�����</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable p_dtbMedicint)
        {
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvDetail.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvDetail.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint, true);
                m_ctlQueryMedicint.m_blnExtendForAsk = true;
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);

                m_ctlQueryMedicint.m_cbxShowZero.Checked = true;
            }
            else
            {
                m_ctlQueryMedicint.m_dtbMedicineInfo = p_dtbMedicint;
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvDetail.Location.X,
                rect.Y + m_objViewer.m_dgvDetail.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvDetail.Location.X,
                rect.Y + m_objViewer.m_dgvDetail.Location.Y - m_ctlQueryMedicint.Size.Height);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            //m_lngGetMedicineInfoForAsk(m_objViewer.m_strDrugStoreID, out m_objViewer.m_dtbMedicineInfo);
            m_lngGetMedicineInfoForAskWithStorageInfo(m_objViewer.m_blnIsHospital, m_objViewer.m_strDrugStoreID, out m_objViewer.m_dtbMedicineInfo);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicineInfo;
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        {
            long lngReturn = 1;
            return lngReturn;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvDetail.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvDetail.CurrentCell.ColumnIndex;

            if (m_objViewer.m_dtApplyMedicine != null)
            {
                //DataRow[] drOld = m_objViewer.m_dtApplyMedicine.Select("MEDICINEID_CHR = '" + MS_VO.m_strMedicineID + "'");
                //if (drOld != null && drOld.Length > 0 && Convert.ToString(m_objViewer.m_dgvDetail.Rows[intRowIndex].Cells["m_dgvtxtMedicineCode"].Value) != MS_VO.m_strMedicineCode)
                for (int i1 = 0; i1 < m_objViewer.m_dgvDetail.Rows.Count; i1++)
                {
                    if (i1 == intRowIndex)
                        continue;
                    if (Convert.ToString(m_objViewer.m_dgvDetail.Rows[i1].Cells["medicineid_chr"].Value) == MS_VO.m_strMedicineID)
                    {
                        MessageBox.Show("�����쵥��ѡ���ҩ", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail.Rows[intRowIndex].Cells["m_dgvtxtMedicineCode"];
                        m_objViewer.m_dgvDetail.Refresh();
                        m_objViewer.m_dgvDetail.Focus();
                        m_objViewer.m_dgvDetail.CurrentCell.Selected = true;
                        return;
                    }
                }

                DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvDetail.CurrentCell.OwningRow.DataBoundItem)).Row;
                drCurrent["assistcode_chr"] = MS_VO.m_strMedicineCode;
                drCurrent["MEDICINENAME_VCHr"] = MS_VO.m_strMedicineName;
                drCurrent["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
                drCurrent["OPUNIT_CHR"] = MS_VO.m_strOpUnit_chr;
                drCurrent["IPUNIT_CHR"] = MS_VO.m_strIpUnit_chr;
                drCurrent["MEDICINEID_CHR"] = MS_VO.m_strMedicineID;
                drCurrent["packqty_dec"] = MS_VO.m_strPackqty_dec;
                drCurrent["opchargeflg_int"] = MS_VO.m_intOpChargeflg_int;
                drCurrent["ipchargeflg_int"] = MS_VO.m_intIpchargeflg_int;
                drCurrent["productorid_chr"] = MS_VO.m_strManufacturer;
                drCurrent["unitprice_mny"] = MS_VO.m_dcmRetailPrice;
                drCurrent["requestpackqty_dec"] = MS_VO.m_dblREQUESTPACKQTY_DEC;
                drCurrent["requestunit_chr"] = MS_VO.m_strREQUESTUNIT_CHR;
                m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail.Rows[intRowIndex].Cells["requestamount_int"];
                if (MS_VO.m_strREQUESTUNIT_CHR != MS_VO.m_strOpUnit_chr)
                {
                    m_objViewer.m_dgvDetail.Rows[intRowIndex].Cells["requestunit_chr"].Style.ForeColor = System.Drawing.Color.Blue;
                    m_objViewer.m_dgvDetail.Rows[intRowIndex].Cells["requestamount_int"].Style.ForeColor = System.Drawing.Color.Blue;
                }
            }

            m_objViewer.m_dgvDetail.Refresh();
            m_objViewer.m_dgvDetail.Focus();
            m_objViewer.m_dgvDetail.CurrentCell.Selected = true;
        }
        #endregion
        #region ��ʾ����ҩƷѡ����
        /// <summary>
        /// ��ʾ����ҩƷѡ����
        /// </summary>
        /// <param name="p_strAmount"></param>
        internal long m_lngShowMedicineSelect(string p_strAmount)
        {
            long lngRes = -1;
            double dblAmount = 0d;
            if (!double.TryParse(p_strAmount, out dblAmount))
            {
                MessageBox.Show("��������Ϊ���ұ���Ϊ����", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else
            {
                if (dblAmount <= 0)
                {
                    MessageBox.Show("�������������", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            if (m_objViewer.m_dgvDetail.CurrentCell == null || m_objViewer.m_dtApplyMedicine == null)
            {
                return -1;
            }
            else
            {
                MessageBox.Show("û�е�ǰѡ��ҩƷ�����Ϣ", "ҩƷ����", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return -1;
            }
            return lngRes;
        }
        #endregion

        #region ��ս���
        /// <summary>
        /// ��ս���
        /// </summary>
        internal void m_mthClear()
        {
            m_objViewer.m_dtApplyMedicine.Rows.Clear();
          //  m_objViewer.m_cboAskDept.Text=string.Empty;
            m_objViewer.m_txtComment.Clear();
            m_objViewer.m_txtAskBillNo.Clear();
            m_objViewer.m_lngMainSEQ = 0;
            m_objViewer.m_datApplyDate.Value = clsPub.CurrentDateTimeNow;
            m_objCurrentMain = null;
            m_objCurrentSubArr = null;
            m_objViewer.m_txtAsker.AccessibleName = m_objViewer.LoginInfo.m_strEmpID;
            m_objViewer.m_txtAsker.Text = m_objViewer.LoginInfo.m_strEmpName;
            //m_objViewer.m_cboAskDept.Enabled = true;

            m_objViewer.IsCanModify = true;
            m_objViewer.m_btnSave.Enabled = true;
            m_objViewer.m_btnDelete.Enabled = true;
            m_objViewer.m_btnInsert.Enabled = true;
            m_objViewer.m_dgvDetail.Columns[1].ReadOnly = false;
            m_objViewer.m_dgvDetail.Columns[5].ReadOnly = false;
            m_objViewer.m_cboExportDept.Enabled = true;
        }
        #endregion
        #region ɾ��������ϸ
        /// <summary>
        /// ɾ��������ϸ
        /// </summary>
        /// <returns></returns>
        internal void m_mthDeleteDetail()
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS_INT != 1 && m_objCurrentMain.m_intSTATUS_INT != 2 && m_objCurrentMain.m_intSTATUS_INT != 0)
            {
                if (m_objCurrentMain.m_intSTATUS_INT == 3)
                {
                    MessageBox.Show("��ҩƷ�����¼ҩ���Ѿ���ˣ�����ɾ��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (m_objCurrentMain.m_intSTATUS_INT ==4)
                {
                    MessageBox.Show("��ҩƷ�����¼ҩ���Ѿ���ˣ�����ɾ��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (m_objViewer.m_dgvDetail.SelectedCells.Count == 0)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvDetail.SelectedCells[0].RowIndex;
            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvDetail.CurrentCell.OwningRow.DataBoundItem).Row;

            long lngSEQ = 0;
            if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngSEQ))
            {
                long lngRes = 0;
                //zhenwei.yang�޸�
                if (lngSEQ > 0)
                {
                    string strStatus = null;
                    lngRes = this.m_objDomain.m_lngQueryAskMedStatus(lngSEQ.ToString(), 1, out strStatus);
                    if (strStatus != "1" && strStatus != "2")
                    {
                        MessageBox.Show("�����쵥״̬�Ѹı�,�����޸�!", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        lngRes = 0;
                    }
                }

                lngRes = m_objDomain.m_lngDelMedDetail(lngSEQ);
                if (lngRes > 0)
                {
                    if (m_objCurrentSubArr != null)
                    {
                        List<clsDS_Ask_Detail_VO> lstDetail = new List<clsDS_Ask_Detail_VO>();
                        for (int iDe = 0; iDe < m_objCurrentSubArr.Length; iDe++)
                        {
                            if (m_objCurrentSubArr[iDe].m_lngSERIESID_INT != lngSEQ)
                            {
                                lstDetail.Add(m_objCurrentSubArr[iDe]);
                            }
                        }
                        m_objCurrentSubArr = null;
                        if (lstDetail.Count > 0)
                        {
                            m_objCurrentSubArr = lstDetail.ToArray();
                        }
                    }

                    m_objViewer.m_dtApplyMedicine.Rows.Remove(drCurrent);
                    m_objViewer.m_dtApplyMedicine.AcceptChanges();
                    m_objViewer.m_mthShowRetailMoney();
                    MessageBox.Show("ɾ���ɹ�", "ҩƷ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                m_objViewer.m_dtApplyMedicine.Rows.Remove(drCurrent);
                m_objViewer.m_dtApplyMedicine.AcceptChanges();
            }
        }
        #endregion
        #region ����ҩƷ������Ϣ
        /// <summary>
        /// ����ҩƷ������Ϣ
        /// </summary>
        /// <param name="p_blnWantHint">�Ƿ���ʾ��ʾ��Ϣ</param>
        /// <returns></returns>
        internal long m_lngSaveApplyMedInfo(bool p_blnWantHint)
        {
            #region ��Ч�Լ��
            //��ֹ�򿪶����˽��棬������ͬһ�ŵ���
            //if (m_objViewer.m_txtAskBillNo.Text.Length > 0 && m_objDomain.m_lngCheckStatus(m_objViewer.m_txtAskBillNo.Text) < 0)
            //{
            //    MessageBox.Show("��ҩƷ����״̬�Ѹı䣬�����޸ģ���ˢ�¡�", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return -1;
            //}
            //if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS_INT != 1 && m_objCurrentMain.m_intSTATUS_INT != 2 && m_objCurrentMain.m_intSTATUS_INT !=0 && p_blnWantHint)
            //{
            //    if (m_objCurrentMain.m_intSTATUS_INT == 3)
            //    {
            //        MessageBox.Show("��ҩƷ�����¼ҩ������ˣ������޸�", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return -1;
            //    }
            //    else if (m_objCurrentMain.m_intSTATUS_INT == 4)
            //    {
            //        MessageBox.Show("��ҩƷ�����¼ҩ������ˣ������޸�", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return -1;
            //    }
            //}

            if (string.IsNullOrEmpty(m_objViewer.m_cboAskDept.Text) && p_blnWantHint)
            {
                MessageBox.Show("����ѡ�����ò���", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            if (string.IsNullOrEmpty(m_objViewer.m_cboExportDept.Text) && p_blnWantHint)
            {
                MessageBox.Show("����ѡ����ⲿ��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            if ((m_objViewer.m_dtApplyMedicine == null || m_objViewer.m_dtApplyMedicine.Rows.Count == 0) && p_blnWantHint)
            {
                MessageBox.Show("����ѡ������ҩƷ", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (m_objViewer.m_dtApplyMedicine.Rows.Count == 1)//ֻ��һ���Զ���ӵĿ�����
            {
                if (m_objViewer.m_dtApplyMedicine.Rows[0]["MEDICINEID_CHR"] == DBNull.Value)
                {
                    MessageBox.Show("����ѡ������ҩƷ", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            if (this.m_objViewer.m_dgvDetail.Rows.Count > 0)
            {
                this.m_objViewer.m_dgvDetail.CurrentCell = this.m_objViewer.m_dgvDetail.Rows[0].Cells[0];
            }
            double dblAmount = 0d;
            DataRow drTemp = null;
            for (int iRow = 0; iRow < m_objViewer.m_dtApplyMedicine.Rows.Count; iRow++)
            {
                drTemp = m_objViewer.m_dtApplyMedicine.Rows[iRow];
                if (drTemp.RowState == DataRowState.Unchanged || drTemp.RowState == DataRowState.Deleted)
                {
                    continue;
                }
                if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["requestamount_int"] != DBNull.Value)
                {
                    if (!double.TryParse(drTemp["requestamount_int"].ToString(), out dblAmount))
                    {
                        MessageBox.Show("������������Ϊ����", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    else
                    {
                        //if (dblAmount <= 0)
                        //{
                        //    MessageBox.Show("�����������������", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return -1;
                        //}
                    }
                }
            }
            #endregion
            this.m_objViewer.m_dtApplyMedicine.AcceptChanges();
            long lngRes = 0;
          
            try
            {
                bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;

                clsDS_Ask_VO objMain = m_objGetMainISVO();
                DataRow[] drNew = m_objViewer.m_dtApplyMedicine.Select("MEDICINEID_CHR IS NOT NULL AND requestamount_int IS NOT NULL");
                if (drNew.Length == 0)
                {
                    MessageBox.Show("����¼��Ҫ�����ҩƷ�ٱ��棡", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                clsDS_Ask_Detail_VO[] objDetailArr = m_objGetDetailArr(drNew, objMain.m_lngSERIESID_INT);
                if (blnIsAddNew)
                {
                    lngRes = m_objDomain.m_lngAddNewAskMedInfo(ref objMain, ref objDetailArr);
                    if (lngRes > 0 && this.m_objMainVoList != null)
                    {

                        this.m_objMainVoList.Add(objMain);

                    }
                }
                else
                {
                    lngRes = m_objDomain.m_lngUpdateAskMedInfo(objMain, ref objDetailArr);
                    if (lngRes > 0 && this.m_objMainVoList != null)
                    {
                        foreach (clsDS_Ask_VO vo in m_objMainVoList)
                        {
                            if (vo.m_lngSERIESID_INT == objMain.m_lngSERIESID_INT)
                            {
                                m_objMainVoList.Remove(vo);
                            }
                        }
                        m_objMainVoList.Add(objMain);
                    }
                }

                if (lngRes > 0)
                {
                    m_objViewer.m_lngMainSEQ = objMain.m_lngSERIESID_INT;
                    m_objViewer.m_txtAskBillNo.Text = objMain.m_strASKID_VCHR;
                    m_objCurrentMain = objMain;
                    m_objCurrentSubArr = objDetailArr;

                    m_mthSetSeriesIDToUI(objDetailArr);

                    #region ȥ������
                    DataRow[] drNull = m_objViewer.m_dtApplyMedicine.Select("OPAMOUNT_INT IS  NULL");
                    if (drNull != null && drNull.Length > 0)
                    {
                        foreach (DataRow drDel in drNull)
                        {
                            m_objViewer.m_dtApplyMedicine.Rows.Remove(drDel);
                        }
                    }
                    #endregion

                    m_objViewer.m_dtApplyMedicine.AcceptChanges();


                    if (p_blnWantHint)
                    {
                        MessageBox.Show("����ɹ�", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("����ʧ��", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }


            }
            catch (Exception Ex)
            {
                string strExMessage = "����ʧ��" + Environment.NewLine + Ex.Message;
                return -1;
            }
            return lngRes;
        }

        /// <summary>
        /// ���½������ݵ����к�
        /// </summary>
        /// <param name="p_objDetailArr"></param>
        private void m_mthSetSeriesIDToUI(clsDS_Ask_Detail_VO[] p_objDetailArr)
        {
            if (m_objViewer.m_dtApplyMedicine != null && m_objViewer.m_dtApplyMedicine.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < m_objViewer.m_dtApplyMedicine.Rows.Count; iRow++)
                {
                    if (iRow < p_objDetailArr.Length)
                    {
                        m_objViewer.m_dtApplyMedicine.Rows[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        m_objViewer.m_dtApplyMedicine.Rows[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                    }
                }
            }
        }
        #endregion
        #region ��ȡ��������
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        private clsDS_Ask_VO m_objGetMainISVO()
        {
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsDS_Ask_VO();
                m_objCurrentMain.m_datASKDATE_DAT = Convert.ToDateTime(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objCurrentMain.m_intSTATUS_INT =1;
            }
            m_objCurrentMain.m_lngSERIESID_INT = this.m_objViewer.m_lngMainSEQ;
            m_objCurrentMain.m_strASKID_VCHR = this.m_objViewer.m_txtAskBillNo.Text;
            m_objCurrentMain.m_strASKDEPT_CHR = m_objViewer.m_cboAskDept.SelectItemValue.Trim() != string.Empty ? m_objViewer.m_cboAskDept.SelectItemValue.Trim() : this.m_objViewer.m_cboAskDept.AccessibleName;
            m_objCurrentMain.m_strAskDeptName = this.m_objViewer.m_cboAskDept.Text;
            m_objCurrentMain.m_strASKERID_CHR = m_objViewer.m_txtAsker.AccessibleName.ToString();
            m_objCurrentMain.m_strAskerName = this.m_objViewer.m_txtAsker.Text;
            m_objCurrentMain.m_strComment = m_objViewer.m_txtComment.Text;
            m_objCurrentMain.m_strEXPORTDEPT_CHR = m_objViewer.m_cboExportDept.SelectItemValue.Trim() != string.Empty ? m_objViewer.m_cboExportDept.SelectItemValue.Trim() : this.m_objViewer.m_cboExportDept.AccessibleName;
            m_objCurrentMain.m_strExportDeptName = this.m_objViewer.m_cboExportDept.Text;
            return m_objCurrentMain;
        }
          #endregion

        #region ��ȡ�ӱ�����
        /// <summary>
        ///  ��ȡ�ӱ�����
        /// </summary>
        /// <param name="p_drDetail"></param>
        /// <param name="p_lngMainSEQ"></param>
        /// <returns></returns>
        private clsDS_Ask_Detail_VO[] m_objGetDetailArr(DataRow[] p_drDetail, long p_lngMainSEQ)
        {
            clsDS_Ask_Detail_VO[] objDetailArr = null;
            if (p_drDetail == null || p_drDetail.Length == 0)
            {
                return null;
            }

            objDetailArr = new clsDS_Ask_Detail_VO[p_drDetail.Length];
            for (int iRow = 0; iRow < p_drDetail.Length; iRow++)
            {
                objDetailArr[iRow] = new clsDS_Ask_Detail_VO();
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = p_drDetail[iRow]["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCHR = p_drDetail[iRow]["MEDICINENAME_VCHR"].ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR_VCHR = p_drDetail[iRow]["MEDSPEC_VCHR"].ToString();
                objDetailArr[iRow].m_strOPUNIT_CHR = p_drDetail[iRow]["OPUNIT_CHR"].ToString();
                objDetailArr[iRow].m_dblOPAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["OPAMOUNT_INT"]);
                objDetailArr[iRow].m_strIPUNIT_CHR = p_drDetail[iRow]["IPUNIT_CHR"].ToString();
                objDetailArr[iRow].m_dblIPAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["IPAMOUNT_INT"]);
                objDetailArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(p_drDetail[iRow]["PACKQTY_DEC"]);
                objDetailArr[iRow].m_strPRODUCTORID_CHR = Convert.ToString(p_drDetail[iRow]["productorid_chr"]);
                objDetailArr[iRow].m_strREQUESTUNIT_CHR = Convert.ToString(p_drDetail[iRow]["requestunit_chr"]);
                objDetailArr[iRow].m_dblREQUESTPACKQTY_DEC = Convert.ToDouble(p_drDetail[iRow]["requestpackqty_dec"]);
                objDetailArr[iRow].m_dblREQUESTAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["requestamount_int"]);
            }
            return objDetailArr;
        }
        #endregion
        public void m_mthPrint()
        {
            DataStore ds = new DataStore();
            ds.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            ds.DataWindowObject = "d_op_askmedicine";
            
            ds.Modify("t_aksdept.text='"+this.m_objViewer.m_cboAskDept.Text+"'");
            ds.Modify("t_askid.text='" + this.m_objViewer.m_txtAskBillNo.Text + "'");
            ds.Modify("t_asktime.text='" + this.m_objViewer.m_datApplyDate.Text + "'");
            ds.Modify("t_asker.text='" + this.m_objViewer.m_txtAsker.Text + "'");
            if (m_objViewer.m_blnIsHospital)
            {
                ds.Modify("t_3.text = 'סԺ��λ'");
                ds.Modify("t_1.text='" + m_objComInfo.m_strGetHospitalTitle() + "סԺҩ�����쵥'");
            }
            else
            {
                ds.Modify("t_1.text='" + m_objComInfo.m_strGetHospitalTitle() + "����ҩ�����쵥'");
            }
            DataRow[] drArr = this.m_objViewer.m_dtApplyMedicine.Select("seriesid_int is not null and seriesid2_int is not null");
            for (int i = 0; i < drArr.Length; i++)
            {   
                int row=ds.InsertRow(0);
                ds.SetItemString(row, "RowNo", Convert.ToString(i + 1));
                ds.SetItemString(row, "MedCode", drArr[i]["assistcode_chr"].ToString());
                ds.SetItemString(row, "MedName", drArr[i]["MEDICINENAME_VCHR"].ToString());
                ds.SetItemString(row, "MedSepc", drArr[i]["MEDSPEC_VCHR"].ToString());
                ds.SetItemString(row, "OPAmount", drArr[i]["OPAMOUNT_INT"].ToString());
                ds.SetItemString(row, "OPUnit", drArr[i]["OPUNIT_CHR"].ToString());
                ds.SetItemString(row, "IPAmount", drArr[i]["AMOUNT_INT"].ToString());
                ds.SetItemString(row, "IPUnit", drArr[i]["UNIT_CHR"].ToString());
                ds.SetItemString(row, "Package", drArr[i]["PACKQTY_DEC"].ToString());
            }
            
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(ds);

        }

        internal void m_mthSetDetail(DataTable dtbSelected)
        {
            DataRow drNew = null;
            foreach (DataRow drDetail in dtbSelected.Rows)
            {
                drNew = m_objViewer.m_dtApplyMedicine.NewRow();
                m_objViewer.m_dtApplyMedicine.Rows.Add(drNew);
                drNew["assistcode_chr"] = drDetail["assistcode_chr"];
                drNew["medicineid_chr"] = drDetail["medicineid_chr"];
                drNew["medicinename_vchr"] = drDetail["medicinename_vchr"];
                drNew["medspec_vchr"] = drDetail["medspec_vchr"];
                drNew["opamount_int"] = drDetail["opamount_int"];
                drNew["opunit_chr"] = drDetail["opunit_chr"].ToString().Trim();
                drNew["ipamount_int"] = drDetail["ipamount_int"];
                drNew["packqty_dec"] = drDetail["packqty_dec"];
                drNew["ipunit_chr"] = drDetail["ipunit_chr"].ToString().Trim();
                drNew["amount_int"] = drDetail["amount_int"];
                drNew["unit_chr"] = drDetail["unit_chr"].ToString().Trim();
                drNew["opchargeflg_int"] = drDetail["opchargeflg_int"];
                drNew["ipchargeflg_int"] = drDetail["ipchargeflg_int"];
                drNew["productorid_chr"] = drDetail["productorid_chr"];
                drNew["unitprice_mny"] = drDetail["unitprice_mny"];
                drNew["requestunit_chr"] = drDetail["requestunit_chr"];
                drNew["requestpackqty_dec"] = drDetail["requestpackqty_dec"];
                drNew["requestamount_int"] = drDetail["requestamount_int"];
                m_objViewer.m_strStoreid = drDetail["drugstoreid_chr"].ToString();
                m_objViewer.m_strStorename = drDetail["medstorename_vchr"].ToString();

                if (m_objViewer.m_blnIsHospital)
                {
                    if (Convert.ToDouble(drDetail["ipchargeflg_int"]) == 0)//������λ
                    {
                        drNew["RetailSum"] = Convert.ToDouble(drDetail["opamount_int"]) * Convert.ToDouble(drDetail["unitprice_mny"]);
                    }
                    else
                    {
                        drNew["RetailSum"] = Convert.ToDouble(drDetail["ipamount_int"]) * Convert.ToDouble(drDetail["unitprice_mny"]) / Convert.ToDouble(drDetail["packqty_dec"]);
                    }
                }
                else
                {
                    if (Convert.ToDouble(drDetail["opchargeflg_int"]) == 0)//������λ
                    {
                        drNew["RetailSum"] = Convert.ToDouble(drDetail["opamount_int"]) * Convert.ToDouble(drDetail["unitprice_mny"]);
                    }
                    else
                    {
                        drNew["RetailSum"] = Convert.ToDouble(drDetail["ipamount_int"]) * Convert.ToDouble(drDetail["unitprice_mny"]) / Convert.ToDouble(drDetail["packqty_dec"]);
                    }
                }
            }
            
            m_objViewer.m_dgvDetail.Refresh();
            m_objViewer.m_dgvDetail.Rows.RemoveAt(m_objViewer.m_dgvDetail.CurrentCell.RowIndex);
            m_objViewer.m_cboAskDept.AccessibleName = m_objViewer.m_strStoreid;
            m_objViewer.m_cboAskDept.Text = m_objViewer.m_strStorename;
            m_objViewer.m_cboExportDept.Focus();
            m_objViewer.m_dtApplyMedicine.AcceptChanges();
            m_objViewer.m_mthShowRetailMoney();
        }

        /// <summary>
        /// ���ϵ���
        /// </summary>
        /// <param name="p_strBillID"></param>
        public long m_lngDeleteBill(string p_strBillID)
        {
            return m_objDomain.m_lngDeleteBill(p_strBillID);
        }
    }
}
