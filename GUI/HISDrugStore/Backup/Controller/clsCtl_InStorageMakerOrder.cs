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
    /// ҩ������Ƶ����Ʋ�
    /// </summary>
    public class clsCtl_InStorageMakerOrder : com.digitalwave.GUI_Base.clsController_Base
    {   
        /// <summary>
        /// contructor
        /// </summary>
        public clsCtl_InStorageMakerOrder()
        {
            m_objDomain = new clsDcl_InStorageMakerOrder();
        }
        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmInStorageMakeOrder)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// �Ƶ�������
        /// </summary>
        private frmInStorageMakeOrder m_objViewer;
        private clsDcl_InStorageMakerOrder m_objDomain;
        /// <summary>
        /// ��ѯҩƷ�ֵ�ؼ�
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// ��ǰҩ�����������Ϣ
        /// </summary>
        private clsDS_Instorage_VO  m_objCurrentMain = null;
        /// <summary>
        ///  ��ǰҩ������ӱ���Ϣ
        /// </summary>
        private clsDS_Instorage_Detail[] m_objCurrentSubArr = null;
        #region ��ʼ�����������Ϣ
        /// <summary>
        /// ��ʼ�����������Ϣ
        /// </summary>
        public void m_mthBorrowDeptInfo()
        {
            long lngRes = -1;
            DataTable m_dtDept = new DataTable();
            lngRes=clsPub.m_mthBorrowDeptInfo(out m_dtDept);
            if (lngRes > 0)
            {
                this.m_objViewer.m_txtFromDept.m_mthInitDeptData(m_dtDept);
            }
        }
        #endregion
        #region �����µ�һ������ҩƷ��Ϣ
        /// <summary>
        /// �����µ�һ������ҩƷ��Ϣ
        /// </summary>
        internal void m_mthInsertNewMedicineInfo()
        {
            if (m_objViewer.m_dtInStorageMedicine == null)
            {
                return;
            }
            m_objViewer.m_datValidPeriod.Clear();
            m_objViewer.m_dtInStorageMedicine.AcceptChanges();
            DataRow drNew = m_objViewer.m_dtInStorageMedicine.NewRow();
            m_objViewer.m_dtInStorageMedicine.Rows.Add(drNew);
            m_objViewer.m_dgvDetail.Focus();
            m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail[1, m_objViewer.m_dgvDetail.RowCount - 1];
        }
        #endregion
        #region ��ʼ���ӱ���ΪDataGridView����Դ��DataTable
        /// <summary>
        /// ��ʼ���ӱ���ΪDataGridView����Դ��DataTable
        /// </summary>
        /// <param name="m_dtMedDetail"></param>
        public void m_mthInitMedicineTable(ref DataTable m_dtMedDetail)
        {
            m_dtMedDetail = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("SERIESID_INT"), new DataColumn("SERIESID2_INT"), new DataColumn("MEDICINEID_CHR"),new DataColumn("assistcode_chr"),new DataColumn("medicinetypeid_chr"), new DataColumn("MEDICINENAME_VCHR"),
                new DataColumn("MEDSPEC_VCHR"),new DataColumn("OPUNIT_CHR"),new DataColumn("OPAMOUNT_INT",typeof(double)),new DataColumn("IPUNIT_CHR"),new DataColumn("IPAMOUNT_INT",typeof(double)),new DataColumn("PACKQTY_DEC",
                typeof(double)),new DataColumn("OPWHOLESALEPRICE_INT",typeof(double)),new DataColumn("IPWHOLESALEPRICE_INT",typeof(double)),new DataColumn("OPRETAILPRICE_INT",typeof(double)),new DataColumn("IPRETAILPRICE_INT",typeof(double)),
                new DataColumn("LOTNO_VCHR",typeof(string)),new DataColumn("VALIDPERIOD_DAT",typeof(string)),new DataColumn("STATUS",typeof(string)),new DataColumn("instoreid_vchr",typeof(string)),new DataColumn("instoragedate_dat",typeof(DateTime)),
                new DataColumn("productorid_chr",typeof(string)),new DataColumn("retailmoney",typeof(double)),new DataColumn("AMOUNT_INT",typeof(double)),new DataColumn("UNIT_CHR"), new DataColumn("WHOLESALEPRICE_INT",typeof(double)),
                new DataColumn("RETAILPRICE_INT",typeof(double)),new DataColumn("opchargeflg_int"),new DataColumn("ipchargeflg_int")};
            m_dtMedDetail.Columns.AddRange(dcColumns);
            m_dtMedDetail.Columns["retailmoney"].Expression = "OPRETAILPRICE_INT / PACKQTY_DEC * IPAMOUNT_INT";
        }
        #endregion
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
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
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
           clsPub.m_mthGetMedBaseInfo(m_objViewer.frmMain.m_strMedStoreArr[0], out m_objViewer.m_dtMedicine);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtMedicine;
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

            if (m_objViewer.m_dtInStorageMedicine != null)
            {
                DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvDetail.CurrentCell.OwningRow.DataBoundItem)).Row;
               //���һЩ���ݣ���ֹ�޸�ҩƷʱ����
                for (int i1 = 0; i1 < drCurrent.Table.Columns.Count; i1++)
                {
                    if (drCurrent.Table.Columns[i1].ColumnName.ToLower() != "retailmoney")
                        drCurrent[i1] = drCurrent.Table.Columns[i1].DefaultValue;
                }
                m_objViewer.m_mthShowRetailMoney();

                drCurrent["assistcode_chr"] = MS_VO.m_strMedicineCode;
                drCurrent["MEDICINENAME_VCHr"] = MS_VO.m_strMedicineName;
                drCurrent["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
                drCurrent["OPUNIT_CHR"] = MS_VO.m_strOpUnit_chr;
                drCurrent["IPUNIT_CHR"] = MS_VO.m_strIpUnit_chr;
                drCurrent["MEDICINEID_CHR"] = MS_VO.m_strMedicineID;
                drCurrent["medicinetypeid_chr"] = MS_VO.m_strMedicineTypeID;
                drCurrent["packqty_dec"] = MS_VO.m_strPackqty_dec;
                drCurrent["OPWHOLESALEPRICE_INT"]=MS_VO.m_dcmTradePrice;

                decimal m_dcmPrice = 0;
                m_objDomain.m_lngGetRetailPrice(MS_VO.m_strMedicineID, out m_dcmPrice);
                MS_VO.m_dcmRetailPrice = m_dcmPrice;

                drCurrent["OPRETAILPRICE_INT"] = MS_VO.m_dcmRetailPrice;
                drCurrent["productorid_chr"] = MS_VO.m_strManufacturer;
                double dblUnitPrice = 0d;
                double dblPackQty = 0d;
                if (double.TryParse(drCurrent["packqty_dec"].ToString(), out dblPackQty) && double.TryParse(drCurrent["OPWHOLESALEPRICE_INT"].ToString(), out dblUnitPrice))
                {
                    drCurrent["IPWHOLESALEPRICE_INT"] = ((double)(dblUnitPrice / dblPackQty)).ToString("0.0000");
                }
                if (double.TryParse(drCurrent["packqty_dec"].ToString(), out dblPackQty) && double.TryParse(drCurrent["OPRETAILPRICE_INT"].ToString(), out dblUnitPrice))
                {
                    drCurrent["IPRETAILPRICE_INT"] = ((double)(dblUnitPrice / dblPackQty)).ToString("0.0000");
                }
                m_objViewer.m_dgvDetail.CurrentCell = m_objViewer.m_dgvDetail.Rows[intRowIndex].Cells["m_txtLotsNo"];
                drCurrent["opchargeflg_int"] = MS_VO.m_intOpChargeflg_int;
                drCurrent["ipchargeflg_int"] = MS_VO.m_intIpchargeflg_int;
                if (m_objViewer.m_blnIsHospital)
                {
                    drCurrent["unit_chr"] = MS_VO.m_intIpchargeflg_int == 0 ? MS_VO.m_strOpUnit_chr : MS_VO.m_strIpUnit_chr;
                    drCurrent["RETAILPRICE_INT"] = MS_VO.m_intIpchargeflg_int == 0 ? drCurrent["OPRETAILPRICE_INT"] : drCurrent["IPRETAILPRICE_INT"];
                }
                else
                {
                    drCurrent["unit_chr"] = MS_VO.m_intOpChargeflg_int == 0 ? MS_VO.m_strOpUnit_chr : MS_VO.m_strIpUnit_chr;
                    drCurrent["RETAILPRICE_INT"] = MS_VO.m_intOpChargeflg_int == 0 ? drCurrent["OPRETAILPRICE_INT"] : drCurrent["IPRETAILPRICE_INT"];
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

            if (m_objViewer.m_dgvDetail.CurrentCell == null || m_objViewer.m_dtInStorageMedicine == null)
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
        #region ����ҩ������Ƶ���ϸ��Ϣ
        /// <summary>
        /// ����ҩ������Ƶ���ϸ��Ϣ
        /// </summary>
        /// <param name="p_blnWantHint">�Ƿ���ʾ��ʾ��Ϣ</param>
        /// <returns></returns>
        internal long m_lngSaveInstorageMedInfo(bool p_blnWantHint)
        {
            #region ��Ч�Լ��
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS != 1 && m_objCurrentMain.m_intSTATUS != 2 && m_objCurrentMain.m_intSTATUS != 0 && p_blnWantHint)
            {
                if (m_objCurrentMain.m_intSTATUS == 2)
                {
                    MessageBox.Show("��ҩ����ⵥ��¼����ˣ������޸�", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (m_objCurrentMain.m_intSTATUS == 3)
                {
                    MessageBox.Show("��ҩ����ⵥ��¼�����ʣ������޸�", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            if (string.IsNullOrEmpty(m_objViewer.m_cboStatus.Text) && p_blnWantHint)
            {
                MessageBox.Show("������д�������", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_cboStatus.Focus();
                return -1;
            }
            if (m_objViewer.m_txtFromDept.Text.Trim().Length == 0 || (Convert.ToString(m_objViewer.m_txtFromDept.StrItemId).Length == 0 && m_objViewer.m_txtFromDept.AccessibleName == null))
            {
                MessageBox.Show("������д��Դ����", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_txtFromDept.Focus();
                return -1;
            }
            if (string.IsNullOrEmpty(m_objViewer.m_cboMedStore.Text) && p_blnWantHint)
            {
                MessageBox.Show("������д����ҩ������", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_cboMedStore.Focus();
                return -1;
            }
            if ((m_objViewer.m_dtInStorageMedicine == null || m_objViewer.m_dtInStorageMedicine.Rows.Count == 0) && p_blnWantHint)
            {
                MessageBox.Show("������д���ҩƷ��Ϣ", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                return -1;
            }
            else if (m_objViewer.m_dtInStorageMedicine.Rows.Count == 1)//ֻ��һ���Զ���ӵĿ�����
            {
                if (m_objViewer.m_dtInStorageMedicine.Rows[0]["MEDICINEID_CHR"] == DBNull.Value)
                {
                    MessageBox.Show("������д���ҩƷ��Ϣ", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            this.m_objViewer.m_dgvDetail.EndEdit();
            if (m_objViewer.m_dtInStorageMedicine.Rows.Count > 0)
            {
                this.m_objViewer.m_dgvDetail.CurrentCell = this.m_objViewer.m_dgvDetail.Rows[0].Cells[0];
            }
            double dblAmount = 0d;
            DataRow drTemp = null;
            decimal dcmInputPrice = 0;
            decimal dcmGetPrice = 0;
            for (int iRow = 0; iRow < m_objViewer.m_dtInStorageMedicine.Rows.Count; iRow++)
            {
                drTemp = m_objViewer.m_dtInStorageMedicine.Rows[iRow];
                if (drTemp["MEDICINEID_CHR"] == DBNull.Value)
                {
                    continue;
                }
                if (drTemp.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                //if (Convert.ToString(drTemp["VALIDPERIOD_DAT"]) == string.Empty)
                //{                   
                //    MessageBox.Show("��Ч�ڱ�����д", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return -1;                    
                //}
                if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["OPAMOUNT_INT"] != DBNull.Value)
                {
                    if (!double.TryParse(drTemp["OPAMOUNT_INT"].ToString(), out dblAmount))
                    {
                        MessageBox.Show("�����������Ϊ����", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }

                    if (drTemp["IPAMOUNT_INT"] != DBNull.Value && drTemp["OPRETAILPRICE_INT"] != DBNull.Value)
                    {  
                        m_objDomain.m_lngGetRetailPrice(Convert.ToString(drTemp["MEDICINEID_CHR"]), out dcmGetPrice);
                        dcmInputPrice = Convert.ToDecimal(drTemp["OPRETAILPRICE_INT"]);
                        if (dcmGetPrice != dcmInputPrice)
                        {
                            MessageBox.Show(Convert.ToString(drTemp["MEDICINENAME_VCHr"]) + "����⵽���۵����Ѿ����ۣ����ܱ��棡\n(��ʾ�����Խ���ҩƷɾ�����������룬���ҩƷ���봦����ѡ���ҩƷ)", "ҩƷ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return -1;
                        }                        
                    }
                }
                else if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["OPAMOUNT_INT"] == DBNull.Value)
                {
                    MessageBox.Show("�����������Ϊ��", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.m_objViewer.m_dgvDetail.Focus();
                    this.m_objViewer.m_dgvDetail.CurrentCell = this.m_objViewer.m_dgvDetail.Rows[iRow].Cells["amount_int"];
                    return -1;
                }

                for (int i1 = 0; i1 < iRow; i1++)
                {
                    if (Convert.ToString(drTemp["MEDICINEID_CHR"])!=string.Empty&&Convert.ToString(drTemp["MEDICINEID_CHR"]) == Convert.ToString(m_objViewer.m_dtInStorageMedicine.Rows[i1]["MEDICINEID_CHR"]) &&
                        Convert.ToString(drTemp["LOTNO_VCHR"]) == Convert.ToString(m_objViewer.m_dtInStorageMedicine.Rows[i1]["LOTNO_VCHR"]))
                    {
                        MessageBox.Show("��ͬҩƷ�����Ų�����ͬ", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.m_objViewer.m_dgvDetail.Focus();
                        this.m_objViewer.m_dgvDetail.CurrentCell = this.m_objViewer.m_dgvDetail.Rows[iRow].Cells["m_txtLotsNo"];
                        return -1;
                    }
        
                }

            }
            #endregion
            this.m_objViewer.m_dtInStorageMedicine.AcceptChanges();
            long lngRes = 0;

            try
            {
                bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;

                clsDS_Instorage_VO objMain = m_objGetMainISVO();
                DataRow[] drNew = m_objViewer.m_dtInStorageMedicine.Select("MEDICINEID_CHR IS NOT NULL AND OPAMOUNT_INT IS NOT NULL AND IPAMOUNT_INT IS NOT NULL");
                clsDS_Instorage_Detail[] objDetailArr = m_objGetDetailArr(drNew, objMain.m_lngSERIESID_INT);
                if(objDetailArr == null)
                {
                    return -1;
                }
                if (objDetailArr.Length == 0)
                {
                    MessageBox.Show("�����ϸ����Ϊ�գ�", "ҩ������Ƶ�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                if (blnIsAddNew)
                {
                    lngRes = m_objDomain.m_lngAddNewInstorage(ref objMain, ref objDetailArr, m_objViewer.m_intCommitFolow,m_objViewer.LoginInfo.m_strEmpID);
                }
                else
                {
                    //�޸�֮ǰ�����ж�zhenwei.yang
                    string strState = null;
                    lngRes = m_objDomain.m_lngQueryInstorageState(m_objViewer.m_lngMainSEQ.ToString(), 0, out strState);
                    if (strState != "1")
                    {
                        MessageBox.Show("��ⵥ״̬�Ѹı�,�޷��޸�", "ҩƷ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    else {
                        lngRes = 0;
                    }

                    lngRes = m_objDomain.m_lngUpdateInStorageInfo(objMain, ref objDetailArr, m_objViewer.m_intCommitFolow, m_objViewer.LoginInfo.m_strEmpID);
                }

                if (lngRes > 0)
                {
                    m_objViewer.m_lngMainSEQ = objMain.m_lngSERIESID_INT;
                    m_objViewer.m_txtBillId.Text = objMain.m_strINDRUGSTOREID_VCHR;
                    m_objCurrentMain = objMain;
                    m_objCurrentSubArr = objDetailArr;
                    if(m_objViewer.m_intCommitFolow == 1)
                    {
                        m_objCurrentMain.m_intSTATUS = 2;
                    }
                    m_mthSetSeriesIDToUI(objDetailArr);

                    #region ȥ������
                    DataRow[] drNull = m_objViewer.m_dtInStorageMedicine.Select("OPAMOUNT_INT IS  NULL");
                    if (drNull != null && drNull.Length > 0)
                    {
                        foreach (DataRow drDel in drNull)
                        {
                            m_objViewer.m_dtInStorageMedicine.Rows.Remove(drDel);
                        }
                    }
                    #endregion

                    m_objViewer.m_dtInStorageMedicine.AcceptChanges();
                    if (p_blnWantHint)
                    {
                        if (blnIsAddNew)
                        {
                            this.m_objViewer.m_objInstorageList.Add(m_objCurrentMain);
                        }
                        else
                        {
                            for (int i1 = 0; i1 < this.m_objViewer.m_objInstorageList.Count; i1++)
                            {
                                clsDS_Instorage_VO clsIsVo = m_objViewer.m_objInstorageList[i1];
                                if (clsIsVo.m_lngSERIESID_INT ==m_objCurrentMain.m_lngSERIESID_INT)
                                {
                                    m_objViewer.m_objInstorageList.Remove(clsIsVo);
                                }
                            }
                            this.m_objViewer.m_objInstorageList.Add(m_objCurrentMain);
                            //foreach (clsDS_Instorage_VO var in m_objViewer.m_objInstorageList)
                            //{
                            //    if (var.m_lngSERIESID_INT == m_objCurrentMain.m_lngSERIESID_INT)
                            //    {
                            //        m_objViewer.m_objInstorageList.Remove(var);
                            //    }
                            //}
                            //this.m_objViewer.m_objInstorageList.Add(m_objCurrentMain);
                        }
                       this.m_objViewer.m_blnSaved = true;
                        MessageBox.Show(blnIsAddNew ? "����ɹ���" : "�޸ĳɹ���", "ҩ������Ƶ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    if (m_objViewer.m_intCommitFolow == 1)
                    {
                        m_objViewer.m_btnInsert.Enabled = false;
                       // m_objViewer.m_btnNext.Enabled = false;
                        //m_objViewer.m_btnSave.Enabled = false;
                        m_objViewer.m_btnDelete.Enabled = false;
                        m_objViewer.m_dgvDetail.ReadOnly = true;
                        //m_objViewer.m_txtComment.ReadOnly = true;
                        m_objViewer.m_intCommitStatus = 1;
                    }
                }
                else
                {
                    MessageBox.Show("����ʧ�ܣ�", "ҩ������Ƶ�", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }


            }
            catch (Exception Ex)
            {
                //string strExMessage = "����ʧ��" + Environment.NewLine + Ex.Message;
                //return -1;
                MessageBox.Show(Ex.Message, "ע��...");
            }
            return lngRes;
        }
        #region ��ȡ��������
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        private clsDS_Instorage_VO m_objGetMainISVO()
        {
            bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;
            if (m_objCurrentMain == null || blnIsAddNew)
            {
                m_objCurrentMain = new clsDS_Instorage_VO();
                this.m_objViewer.m_datMakeDate.Value = clsPub.ServerDateTimeNow;//ȡ������ʱ����ǽ���ʱ��
                m_objCurrentMain.m_datMAKEORDER_DAT = Convert.ToDateTime(this.m_objViewer.m_datMakeDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objCurrentMain.m_intSTATUS = m_objViewer.m_intCommitFolow == 1 ? 2 : 1;

            }
            //1��ҩ����ⵥ 2�����쵥 3��������ҩ4��ҩ����� 5��ҩ����ӯ 
            //switch (this.m_objViewer.m_cboStatus.Text.Trim())
            //{
            //    case "ҩ����ⵥ": m_objCurrentMain.m_intFORMTYPE_INT = 1; break;
            //    case "���쵥": m_objCurrentMain.m_intFORMTYPE_INT = 2; break;
            //    case "������ҩ": m_objCurrentMain.m_intFORMTYPE_INT = 3; break;
            //    case "ҩ�����": m_objCurrentMain.m_intFORMTYPE_INT = 4; break;
            //    case "ҩ����ӯ": m_objCurrentMain.m_intFORMTYPE_INT = 5; break;
            //    default: m_objCurrentMain.m_intFORMTYPE_INT = -1; break;
            //}
            //1��������� 2��ҩ���������(��Դ�����Ǳ�ҩ��)  3��ҩ���������Դ����������ҩ���� 4�����ҽ������Դ���ų���ҩ������Ĳ��ţ� 5����ӯ��
            string strMedStoreID = m_objViewer.m_cboMedStore.SelectItemValue != string.Empty ? m_objViewer.m_cboMedStore.SelectItemValue : m_objViewer.m_cboMedStore.AccessibleName;            
            string m_strDeptCode = m_objViewer.m_txtFromDept.StrItemId.Trim() != string.Empty ? m_objViewer.m_txtFromDept.StrItemId.Trim() : m_objViewer.m_txtFromDept.AccessibleName;
            
            if (strMedStoreID == m_strDeptCode)
            {
                this.m_objCurrentMain.m_intFORMTYPE_INT = 2;
            }
            else if (this.m_objViewer.frmMain.m_dtMedStoreInfo != null)
            {
                int m_intRowsCount = this.m_objViewer.frmMain.m_dtMedStoreInfo.Rows.Count;
                DataRow dr;
                for (int i = 0; i < m_intRowsCount; i++)
                {
                    dr = this.m_objViewer.frmMain.m_dtMedStoreInfo.Rows[i];
                    if (dr["deptid_chr"].ToString() == m_strDeptCode)
                    {
                        this.m_objCurrentMain.m_intFORMTYPE_INT = 3;
                        break;
                    }
                    if (i == m_intRowsCount - 1)
                        this.m_objCurrentMain.m_intFORMTYPE_INT = 4;

                }
            }
            else
            {
                this.m_objCurrentMain.m_intFORMTYPE_INT = 4;
            }
            if (this.m_objViewer.m_intFormType != -1)
            {
                this.m_objCurrentMain.m_intFORMTYPE_INT = this.m_objViewer.m_intFormType;
            }


            // m_objCurrentMain.m_intFORMTYPE_INT = 1;
            m_objCurrentMain.m_strTYPECODE_VCHR = m_objViewer.m_cboStatus.SelectItemValue != string.Empty ? m_objViewer.m_cboStatus.SelectItemValue : m_objViewer.m_cboStatus.AccessibleName;
            m_objCurrentMain.m_strTYPENAME_VCHR = m_objViewer.m_cboStatus.SelectItemText;
            m_objCurrentMain.m_lngSERIESID_INT = this.m_objViewer.m_lngMainSEQ;
            m_objCurrentMain.m_strMAKERID_CHR = this.m_objViewer.m_txtMaker.Tag.ToString();
            m_objCurrentMain.m_strMakeName = this.m_objViewer.m_txtMaker.Text.Trim();
            m_objCurrentMain.m_strBORROWDEPT_CHR = m_strDeptCode;
            m_objCurrentMain.m_strBORROWDEPTName_CHR = m_objViewer.m_txtFromDept.Text;
            m_objCurrentMain.m_strDRUGSTOREID_INT = strMedStoreID;
            m_objCurrentMain.m_strDRUGSTOREName = m_objViewer.m_cboMedStore.Text;
            m_objCurrentMain.m_strCOMMENT_VCHR = m_objViewer.m_txtComment.Text;
            m_objCurrentMain.m_strINDRUGSTOREID_VCHR = this.m_objViewer.m_txtBillId.Text;
            if (m_objViewer.m_intCommitFolow == 1)
            {
                m_objCurrentMain.m_strDRUGSTOREEXAMID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
                m_objCurrentMain.m_datDRUGSTOREEXAM_DATE = clsPub.ServerDateTimeNow;
                m_objCurrentMain.m_strDRUGSTOREEXAMName = this.m_objViewer.LoginInfo.m_strEmpName;
            }
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
        private clsDS_Instorage_Detail[] m_objGetDetailArr(DataRow[] p_drDetail, long p_lngMainSEQ)
        {
            clsDS_Instorage_Detail[] objDetailArr = null;
            if (p_drDetail == null || p_drDetail.Length == 0)
            {
                return null;
            }
            objDetailArr = new clsDS_Instorage_Detail[p_drDetail.Length];
            string m_strLotno = string.Empty;
            DateTime m_datValidDate = DateTime.MinValue;
            for (int iRow = 0; iRow < p_drDetail.Length; iRow++)
            {
                objDetailArr[iRow] = new clsDS_Instorage_Detail();
                //if (p_drDetail[iRow]["SERIESID_INT"] != System.DBNull.Value)
                //{
                //    objDetailArr[iRow].m_lngSERIESID_INT = long.Parse(p_drDetail[iRow]["SERIESID_INT"].ToString());
                //}
                //else
                //{
                    objDetailArr[iRow].m_lngSERIESID_INT = -1;
                //}
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = p_drDetail[iRow]["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strMedicineTypeid = p_drDetail[iRow]["medicinetypeid_chr"].ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCHR = p_drDetail[iRow]["MEDICINENAME_VCHR"].ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR = p_drDetail[iRow]["MEDSPEC_VCHR"].ToString();
                objDetailArr[iRow].m_strOPUNIT_CHR = p_drDetail[iRow]["OPUNIT_CHR"].ToString();
                objDetailArr[iRow].m_dblOPAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["OPAMOUNT_INT"]);
                objDetailArr[iRow].m_strIPUNIT_CHR = p_drDetail[iRow]["IPUNIT_CHR"].ToString();
                objDetailArr[iRow].m_dblIPAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["IPAMOUNT_INT"]);
                objDetailArr[iRow].m_dblPACKQTY_DEC = Convert.ToDouble(p_drDetail[iRow]["PACKQTY_DEC"]);

                objDetailArr[iRow].m_dblOPRETAILPRICE_INT = Convert.ToDouble(p_drDetail[iRow]["OPRETAILPRICE_INT"]);
                //�û������������ţ�Ҫ��ϵͳ�Զ��ѿ��ӵ�����������ļ�¼
                if (Convert.ToString(p_drDetail[iRow]["LOTNO_VCHR"]).Trim() == string.Empty)
                {
                    m_objDomain.m_lngGetDefaultLotno(m_objCurrentMain.m_strDRUGSTOREID_INT, objDetailArr[iRow].m_strMEDICINEID_CHR,
                        objDetailArr[iRow].m_dblOPRETAILPRICE_INT, out m_strLotno, out m_datValidDate);
                    if(m_strLotno.Length == 0)
                    {
                        MessageBox.Show("��ǰҩ�������ڻ������ۼ�Ϊ��" + objDetailArr[iRow].m_dblOPRETAILPRICE_INT.ToString() + "��ҩƷ��" +
                            objDetailArr[iRow].m_strMEDICINENAME_VCHR + "�����ֶ��������ż���Ч�ڣ�", "��ܰ��ʾ...", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                    objDetailArr[iRow].m_strLOTNO_VCHR = m_strLotno;
                    objDetailArr[iRow].m_datVALIDPERIOD_DAT = m_datValidDate;
                }
                else
                {
                    //20100106�����жϣ�ͬһ�����ŵ�ҩƷ�����������ۼ۸���ͬ
                    bool blnExist = false;
                    m_objDomain.m_lngCheckDiffPrice(m_objCurrentMain.m_strDRUGSTOREID_INT, objDetailArr[iRow].m_strMEDICINEID_CHR,
                        p_drDetail[iRow]["LOTNO_VCHR"].ToString(), objDetailArr[iRow].m_dblOPRETAILPRICE_INT, out blnExist);
                    if(blnExist)
                    {
                        MessageBox.Show("ҩƷ��" +objDetailArr[iRow].m_strMEDICINENAME_VCHR + "������ͬһ�����Ŵ��ڲ�ͬ�۸����޸����ţ�", "��ܰ��ʾ...", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return null;
                    }
                    objDetailArr[iRow].m_strLOTNO_VCHR = p_drDetail[iRow]["LOTNO_VCHR"].ToString();
                    objDetailArr[iRow].m_datVALIDPERIOD_DAT = p_drDetail[iRow]["VALIDPERIOD_DAT"].ToString().Trim() == string.Empty ? DateTime.MinValue : Convert.ToDateTime(p_drDetail[iRow]["VALIDPERIOD_DAT"].ToString());
                }

                objDetailArr[iRow].m_dblOPWHOLESALEPRICE_INT = Convert.ToDouble(p_drDetail[iRow]["OPWHOLESALEPRICE_INT"]);
                objDetailArr[iRow].m_dblIPWHOLESALEPRICE_INT = Convert.ToDouble(p_drDetail[iRow]["IPWHOLESALEPRICE_INT"]);
                
                objDetailArr[iRow].m_dblIPRETAILPRICE_INT = Convert.ToDouble(p_drDetail[iRow]["IPRETAILPRICE_INT"]);
                objDetailArr[iRow].m_intSTATUS = 1;

                objDetailArr[iRow].m_strINSTOREID_VCHR = p_drDetail[iRow]["instoreid_vchr"].ToString();
                if(p_drDetail[iRow]["instoragedate_dat"].ToString() != "")
                    objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(p_drDetail[iRow]["instoragedate_dat"]);
                objDetailArr[iRow].m_strPRODUCTORID_CHR = p_drDetail[iRow]["productorid_chr"].ToString();
            }
            return objDetailArr;
        }
        #endregion
        /// <summary>
        /// ���½������ݵ����к�
        /// </summary>
        /// <param name="p_objDetailArr"></param>
        private void m_mthSetSeriesIDToUI(clsDS_Instorage_Detail[] p_objDetailArr)
        {
            if (m_objViewer.m_dtInStorageMedicine != null && m_objViewer.m_dtInStorageMedicine.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < m_objViewer.m_dtInStorageMedicine.Rows.Count; iRow++)
                {
                    if (iRow < p_objDetailArr.Length)
                    {
                        m_objViewer.m_dtInStorageMedicine.Rows[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        m_objViewer.m_dtInStorageMedicine.Rows[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                        m_objViewer.m_dtInStorageMedicine.Rows[iRow]["LOTNO_VCHR"] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        if (Convert.ToDateTime(p_objDetailArr[iRow].m_datVALIDPERIOD_DAT).ToString("yyyy-MM-dd") != "0001-01-01")
                        {
                            m_objViewer.m_dtInStorageMedicine.Rows[iRow]["VALIDPERIOD_DAT"] = p_objDetailArr[iRow].m_datVALIDPERIOD_DAT.ToString("yyyy-MM-dd");
                        }
                    }
                }
            }
          
        }
        #endregion
        #region ��ս���
        /// <summary>
        /// ��ս���
        /// </summary>
        internal void m_mthClear()
        {
            m_objViewer.m_datValidPeriod.Visible = false;
            m_objViewer.m_dtInStorageMedicine.Rows.Clear();
            //m_objViewer.m_cboMedStore.SelectedIndex=-1;
            m_objViewer.m_cboStatus.SelectedIndex = -1;
            m_objViewer.m_txtFromDept.Clear();
            m_objViewer.m_txtComment.Clear();
            m_objViewer.m_txtBillId.Clear();
            m_objViewer.m_lngMainSEQ = 0;
            m_objViewer.m_datMakeDate.Value = clsPub.CurrentDateTimeNow;
            m_objCurrentMain = null;
            m_objCurrentSubArr = null;
            m_objViewer.m_lblRetail.Text = string.Empty;
            this.m_objViewer.m_intFormType = -1;
            m_objViewer.m_txtComment.ReadOnly = false;
            m_objViewer.m_intCommitStatus = 0;
            m_objViewer.m_btnSave.Enabled = true;
            m_objViewer.m_btnInsert.Enabled = true;
            m_objViewer.m_btnDelete.Enabled = true;
            m_objViewer.m_cboMedStore.Enabled = true;
            m_objViewer.m_txtFromDept.AccessibleName = string.Empty;
            m_objViewer.m_txtMaker.Tag = m_objViewer.LoginInfo.m_strEmpID;
            m_objViewer.m_txtMaker.Text = m_objViewer.LoginInfo.m_strEmpName;
            m_objViewer.m_dgvDetail.Enabled = true;
            m_objViewer.m_dgvDetail.ReadOnly = false;
            m_objViewer.m_txtFromDept.Enabled = true;
            for (int i1 = 0; i1 < m_objViewer.m_dgvDetail.Columns.Count; i1++)
            {
                if (i1 == 1 || i1 == 5 || i1 == 6 || i1 == 7)
                {
                    m_objViewer.m_dgvDetail.Columns[i1].ReadOnly = false;
                }
                else
                {
                    m_objViewer.m_dgvDetail.Columns[i1].ReadOnly = true;
                }
            }

            //m_objViewer.m_dgvDetail.Columns[1].ReadOnly = false;
            //m_objViewer.m_dgvDetail.Columns[5].ReadOnly = false;
            //m_objViewer.m_dgvDetail.Columns[6].ReadOnly = false;
            //m_objViewer.m_dgvDetail.Columns[7].ReadOnly = false;
            m_objViewer.m_dgvDetail.SelectionMode = DataGridViewSelectionMode.CellSelect;           
            m_objViewer.m_cboStatus.Focus();
        }
             #endregion
        #region ɾ��ҩ�������ϸ
        /// <summary>
        /// ɾ��ҩ�������ϸ
        /// </summary>
        /// <returns></returns>
        internal void m_mthDeleteDetail(bool p_blnWantHint)
        {
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS != 1 && m_objCurrentMain.m_intSTATUS != 0 && p_blnWantHint)
            {
                if (m_objCurrentMain.m_intSTATUS == 2)
                {
                    MessageBox.Show("��ҩ����ⵥ��¼����ˣ������޸�", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (m_objCurrentMain.m_intSTATUS == 3)
                {
                    MessageBox.Show("��ҩ����ⵥ��¼�����ʣ������޸�", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //�ж���ⵥ��״̬�Ƿ��޸�zhenwei.yang
                if (lngSEQ > 0)
                {
                    string p_strState = null;
                    lngRes = m_objDomain.m_lngQueryInstorageState(lngSEQ.ToString(), 1, out p_strState);
                    if (p_strState != "1")
                    {
                        MessageBox.Show("��ⵥ״̬�Ѹı�,�޷��޸�", "ҩƷ���", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                
                lngRes = m_objDomain.m_lngDelInstorageDetail(lngSEQ);
                if (lngRes > 0)
                {
                    if (m_objCurrentSubArr != null)
                    {
                        List<clsDS_Instorage_Detail> lstDetail = new List<clsDS_Instorage_Detail>();
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

                    m_objViewer.m_dtInStorageMedicine.Rows.Remove(drCurrent);
                    m_objViewer.m_mthShowRetailMoney();
                    MessageBox.Show("ɾ���ɹ�", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                m_objViewer.m_dtInStorageMedicine.Rows.Remove(drCurrent);
            }
        }
        #endregion

        internal void m_mthSetDetail(DataTable dtbSelected)
        {
            DataRow drNew = null;
            foreach(DataRow drDetail in dtbSelected.Rows)
            {
                drNew = m_objViewer.m_dtInStorageMedicine.NewRow();
                m_objViewer.m_dtInStorageMedicine.Rows.Add(drNew);
                drNew["assistcode_chr"] = drDetail["assistcode_chr"];
                drNew["medicineid_chr"] = drDetail["medicineid_chr"];
                drNew["medicinename_vchr"] = drDetail["medicinename_vchr"];
                drNew["medspec_vchr"] = drDetail["medspec_vchr"];                
                drNew["opamount_int"] = drDetail["opamount_int"];
                drNew["opunit_chr"] = drDetail["opunit_chr"];
                drNew["ipamount_int"] = drDetail["ipamount_int"];
                drNew["packqty_dec"] = drDetail["packqty_dec"];
                drNew["ipunit_chr"] = drDetail["ipunit_chr"];
                drNew["productorid_chr"] = drDetail["productorid_chr"];
                m_objViewer.m_strStoreid = drDetail["drugstoreid_chr"].ToString();
                m_objViewer.m_strStorename = drDetail["medstorename_vchr"].ToString(); ;
            }
            m_objViewer.m_dtInStorageMedicine.AcceptChanges();
            m_objViewer.m_dgvDetail.Refresh();
            m_objViewer.m_dgvDetail.Rows.RemoveAt(m_objViewer.m_dgvDetail.CurrentCell.RowIndex);
            m_objViewer.m_cboMedStore.AccessibleName = m_objViewer.m_strStoreid;
            m_objViewer.m_cboMedStore.Text = m_objViewer.m_strStorename;
            m_objViewer.m_mthShowRetailMoney();
        }
        #region ���������ж��Ƿ������Ӧ��ҩƷ�����ϸ��Ϊ��⸺�����
        /// <summary>
        /// ���������ж��Ƿ������Ӧ��ҩƷ�����ϸ��Ϊ��⸺�����
        /// </summary>
        /// <param name="m_strDurgStoreid"></param>
        /// <param name="m_strLotNo"></param>
        /// <param name="m_strMedicineid"></param>
        /// <param name="m_dblOPAmount"></param>
        /// <param name="m_blnExisted"></param>
        /// <returns></returns>
        public bool m_blnJudgeMedicineExisted(double m_dblOPAmount,double m_dblIPAmount)
        {   
            string m_strDurgStoreid=this.m_objViewer.m_cboMedStore.SelectItemValue;           
            string m_strMedicineid = this.m_objViewer.m_dgvDetail.Rows[this.m_objViewer.m_dgvDetail.CurrentCell.RowIndex].Cells["medicineid_chr"].Value.ToString();
            string m_strLotNo = this.m_objViewer.m_dgvDetail.Rows[this.m_objViewer.m_dgvDetail.CurrentCell.RowIndex].Cells["m_txtLotsNo"].Value.ToString();
            double m_dblOpRetailPrice = 0;
            double.TryParse(this.m_objViewer.m_dgvDetail.Rows[this.m_objViewer.m_dgvDetail.CurrentCell.RowIndex].Cells["ColOPRETAILPRICE_INT"].Value.ToString(), out m_dblOpRetailPrice);
            DateTime m_datValidDate = DateTime.MinValue;
            if (m_strLotNo == "")
            {
                m_objDomain.m_lngGetDefaultLotno(m_strDurgStoreid, m_strMedicineid,m_dblOpRetailPrice, out m_strLotNo,out m_datValidDate);
            }
            bool m_blnExisted = false;
            long lngRes = 0;
            lngRes = this.m_objDomain.m_lngJudgeMedicineExisted(m_strDurgStoreid, m_strLotNo, m_strMedicineid, ref m_dblOPAmount,ref m_dblIPAmount, out m_blnExisted);
            if (lngRes > 0)
            {
                if (m_blnExisted)
                {
                    if (m_dblOPAmount == 1)
                    {
                        MessageBox.Show("��ҩƷ�������㹻�Ŀ����������������������룡","ע��...");
                        return false;
                    }
                    else
                        return true;
                }
                else
                {
                    MessageBox.Show("��ҩƷ��������Ӧ�Ŀ���¼�����������룡", "ע��...");
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region ��ȡ�����������
        /// <summary>
        /// ��ȡ�����������
        /// </summary>
        /// <param name="p_intCommitFolw">�����������</param>
        /// <returns></returns>
        internal void m_mthGetCommitFlow(out int p_intCommitFolw)
        {
            long lngRes = m_objDomain.m_lngGetCommitFlow(out p_intCommitFolw);
        }
        #endregion

        public void m_mthPrint()
        {
            DataStore ds = new DataStore();
            ds.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
            ds.DataWindowObject = "ms_rptinstoragemakeorder";
            ds.Modify("texttitlename.text='" + m_objComInfo.m_strGetHospitalTitle() + "ҩƷ���ƾ֤'");
            ds.Modify("t_strfromdept.text='" + this.m_objViewer.m_txtFromDept.Text + "'");
            ds.Modify("t_strbillid.text='" + this.m_objViewer.m_txtBillId.Text + "'");
            ds.Modify("t_count.text='" + this.m_objViewer.m_dtInStorageMedicine.Rows.Count.ToString() + "'");
            ds.Modify("t_strexameid_chr.text='" + this.m_objViewer.LoginInfo.m_strEmpName.ToString() + "'");

            DataTable dtTemp = new DataTable();
            dtTemp.Columns.Add("medicineno_vchr",typeof(string));
            dtTemp.Columns.Add("medicinename_vchr",typeof(String));
            dtTemp.Columns.Add("medspec_vchr",typeof(String));
            dtTemp.Columns.Add("unit_chr",typeof(String));
            dtTemp.Columns.Add("amount_int", typeof(string));
            dtTemp.Columns.Add("retailprice_int", typeof(string));
            dtTemp.Columns.Add("totalretailprice", typeof(string));
            dtTemp.Columns.Add("productorid_chr",typeof(string));
            dtTemp.Columns.Add("validperiod_dat",typeof(string));

            int intRowCount = m_objViewer.m_dtInStorageMedicine.Rows.Count;
            double sumretailprice = 0d;
            double sumtotalretailprice = 0d;
            DataRow dr = null;
            DataRow drTemp = null;
            for (int i = 0; i < intRowCount; i++)
            {
                drTemp = dtTemp.NewRow();
                dr = m_objViewer.m_dtInStorageMedicine.Rows[i];
                drTemp["medicineno_vchr"] = Convert.ToString(i + 1);
                drTemp["medicinename_vchr"] = dr["medicinename_vchr"].ToString();
                drTemp["medspec_vchr"] = dr["medspec_vchr"].ToString();
                drTemp["unit_chr"] = dr["unit_chr"].ToString();
                drTemp["amount_int"] = Convert.ToDouble(dr["amount_int"]).ToString("0.00");
                drTemp["retailprice_int"] = Convert.ToDouble(dr["retailprice_int"]).ToString("0.0000");
                drTemp["totalretailprice"] = Convert.ToDouble(Math.Round(Convert.ToDouble(dr["opretailprice_int"]) * Convert.ToDouble(dr["ipamount_int"]) / Convert.ToDouble(dr["packqty_dec"]),4)).ToString("F4");
                if (dr["productorid_chr"] != DBNull.Value)
                {
                    drTemp["productorid_chr"] = dr["productorid_chr"].ToString();
                }
                else
                {
                    drTemp["productorid_chr"] = "";
 
                }
                if (dr["validperiod_dat"] != DBNull.Value)
                {
                    drTemp["validperiod_dat"] = Convert.ToDateTime(dr["validperiod_dat"]).ToString("yyyy-MM-dd");
                }
                else
                {
                    drTemp["validperiod_dat"] = "";
                }
                dtTemp.Rows.Add(drTemp.ItemArray);
                sumretailprice += Convert.ToDouble(dr["retailprice_int"]);
                sumtotalretailprice += Convert.ToDouble(drTemp["totalretailprice"]);//Convert.ToDouble(dr["retailprice_int"]) * Convert.ToDouble(dr["amount_int"].ToString()));
            }
            dtTemp.AcceptChanges();
            dr = null;
            drTemp = null;

            ds.Reset();
            ds.Modify("t_sumretailprice.text='" + sumretailprice.ToString("0.0000") + "'");
            ds.Modify("t_sumtotalretailprice.text='" + sumtotalretailprice.ToString("0.0000") + "'");
            ds.Retrieve(dtTemp);
            
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(ds);

        }

        internal long m_lngUpdateTypeAndDept()
        {
            long lngRes = -1;
            if (string.IsNullOrEmpty(m_objViewer.m_cboStatus.Text))
            {
                MessageBox.Show("������д�������", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_cboStatus.Focus();
                return -1;
            }
            if (m_objViewer.m_txtFromDept.Text.Trim().Length == 0 || (Convert.ToString(m_objViewer.m_txtFromDept.StrItemId).Length == 0 && m_objViewer.m_txtFromDept.AccessibleName == null))
            {
                MessageBox.Show("������д��Դ����", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_txtFromDept.Focus();
                return -1;
            }
            //1��������� 2��ҩ���������(��Դ�����Ǳ�ҩ��)  3��ҩ���������Դ����������ҩ���� 4�����ҽ������Դ���ų���ҩ������Ĳ��ţ� 5����ӯ��6��ҩ�ⷢ��ҩ��
            string strMedStoreID = m_objViewer.m_cboMedStore.SelectItemValue != string.Empty ? m_objViewer.m_cboMedStore.SelectItemValue : m_objViewer.m_cboMedStore.AccessibleName;
            string m_strDeptCode = m_objViewer.m_txtFromDept.StrItemId.Trim() != string.Empty ? m_objViewer.m_txtFromDept.StrItemId.Trim() : m_objViewer.m_txtFromDept.AccessibleName;

            int m_intFormType_int = -1;
            m_intFormType_int = m_objViewer.m_intFormType;
            if (m_intFormType_int != 6)
            {
                if (strMedStoreID == m_strDeptCode)
                {
                    m_intFormType_int = 2;
                }
                else if (this.m_objViewer.frmMain.m_dtMedStoreInfo != null)
                {
                    int m_intRowsCount = this.m_objViewer.frmMain.m_dtMedStoreInfo.Rows.Count;
                    DataRow dr;
                    for (int i = 0; i < m_intRowsCount; i++)
                    {
                        dr = this.m_objViewer.frmMain.m_dtMedStoreInfo.Rows[i];
                        if (dr["deptid_chr"].ToString() == m_strDeptCode)
                        {
                            m_intFormType_int = 3;
                            break;
                        }
                        if (i == m_intRowsCount - 1)
                            m_intFormType_int = 4;
                    }
                }
                else
                {
                    m_intFormType_int = 4;
                }
            }
            string m_strTypeCode = m_objViewer.m_cboStatus.SelectItemValue != string.Empty ? m_objViewer.m_cboStatus.SelectItemValue : m_objViewer.m_cboStatus.AccessibleName;
            
            return m_objDomain.m_lngUpdateTypeAndDept(m_objViewer.m_intCommitStatus, m_objViewer.m_txtBillId.Text, m_intFormType_int, m_strTypeCode, m_strDeptCode,m_objViewer.m_txtComment.Text.Replace("'","''").Trim());            
        }

        internal void LoadBill(string p_strBillID)
        {
            clsDS_Instorage_VO m_objMain = null;
            long lngRes = 0;
            lngRes = m_objDomain.m_lngLoadBill(m_objViewer.m_blnIsHospital,p_strBillID, out m_objMain, out m_objViewer.m_dtInStorageMedicine);
            if (lngRes > 0)
            {
                m_objViewer.m_datMakeDate.Value = m_objMain.m_datMAKEORDER_DAT;
                m_objViewer.m_txtMaker.Text = m_objMain.m_strMakeName;
                m_objViewer.m_cboStatus.Text = m_objMain.m_strTYPENAME_VCHR;
                m_objViewer.m_txtFromDept.Text = m_objMain.m_strBORROWDEPTName_CHR;
                m_objViewer.m_cboMedStore.Text = m_objMain.m_strDRUGSTOREName;
                m_objViewer.m_txtBillId.Text = m_objMain.m_strINDRUGSTOREID_VCHR;
                m_objViewer.m_txtComment.Text = m_objMain.m_strCOMMENT_VCHR;

                m_objViewer.m_btnSave.Enabled = false;
                m_objViewer.m_btnInsert.Enabled = false;
                m_objViewer.m_btnNext.Enabled = false;
                m_objViewer.m_btnDelete.Enabled = false;
                m_objViewer.m_datMakeDate.Enabled = false;
                m_objViewer.m_cboStatus.Enabled = false;
                m_objViewer.m_txtFromDept.Enabled = false;
                m_objViewer.m_cboMedStore.Enabled = false;
                m_objViewer.m_txtComment.ReadOnly = true;
                m_objViewer.m_txtMaker.Enabled = false;
                m_objViewer.m_txtBillId.Enabled = false;

                m_objViewer.m_dgvDetail.DataSource = m_objViewer.m_dtInStorageMedicine;                
            }
            else
            {
                MessageBox.Show("�Ҳ�����ҩ����ⵥ��", "ע��...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
