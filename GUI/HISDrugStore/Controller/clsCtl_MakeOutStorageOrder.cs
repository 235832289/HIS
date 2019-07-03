using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Windows.Forms;
using System.Collections;
using System.IO;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ҩ����˳���
    /// </summary>
    public class clsCtl_MakeOutStorageOrder : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// ���캯��
        /// </summary>
        public clsCtl_MakeOutStorageOrder()
        {
            m_objDomain = new clsDcl_MakeOutStorageOrder();
        }
        #region ȫ�ֱ���
        /// <summary>
        /// ģ�������
        /// </summary>
        private clsDcl_MakeOutStorageOrder m_objDomain = null;
        /// <summary>
        /// ����
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmMakeOutStorageOrder m_objViewer;
        /// <summary>
        /// ������������
        /// </summary>
        public long m_lngMainSEQ = 0;
        /// <summary>
        /// �������(0,�������ҩ������ɫ��� 1,������������)
        /// </summary>
        public long m_intCommitFolow = 1;
        /// <summary>
        /// ��ѯҩƷ�ֵ�ؼ�
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// ��ǰҩƷ����������Ϣ
        /// </summary>
        internal clsMS_OutStorage_VO m_objCurrentMain = null;
        /// <summary>
        /// ��ǰҩƷ�����ӱ���Ϣ
        /// </summary>
        private clsMS_OutStorageDetail_VO[] m_objCurrentSubArr = null;
        /// <summary>
        /// ���쵥������ϸ
        /// </summary>
        internal DataTable m_dtbRequestDetail;
        /// <summary>
        /// ���������Ŀ�����״̬
        /// </summary>
        private Hashtable m_hstUpdateEnough = new Hashtable();
        /// <summary>
        /// ����ҩƷ��������
        /// </summary>
        internal Hashtable m_hstAskAmount = new Hashtable();
        #endregion
        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMakeOutStorageOrder)frmMDI_Child_Base_in;

        }
        #endregion
        #region ��ʼ���ӱ���ΪDataGridView����Դ��DataTable
        /// <summary>
        /// ��ʼ���ӱ���ΪDataGridView����Դ��DataTable
        /// </summary>
        /// <param name="p_dtbMedicineTalbe"></param>
        internal void m_mthInitMedicineTable(ref DataTable p_dtbMedicineTalbe)
        {
            p_dtbMedicineTalbe = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("SERIESID_INT"), new DataColumn("SERIESID2_INT"), new DataColumn("MEDICINEID_CHR"), new DataColumn("MEDICINENAME_VCHr"),new DataColumn("medicinetypeid_chr"),
                new DataColumn("MEDSPEC_VCHR"),new DataColumn("OPUNIT_CHR"),new DataColumn("NETAMOUNT_INT",typeof(double)),new DataColumn("LOTNO_VCHR"),new DataColumn("INSTORAGEID_VCHR"),new DataColumn("CALLPRICE_INT",typeof(double)),
                new DataColumn("WHOLESALEPRICE_INT",typeof(double)),new DataColumn("RETAILPRICE_INT",typeof(double)),new DataColumn("VENDORID_CHR"),new DataColumn("vendorname_vchr"),new DataColumn("productorid_chr"),
                new DataColumn("inmoney",typeof(double)),new DataColumn("retailmoney",typeof(double)),new DataColumn("instoragedate_dat"),new DataColumn("validperiod_dat",typeof(DateTime)),new DataColumn("realgross_int",typeof(double)),new DataColumn("assistcode_chr"),
                new DataColumn("availagross_int",typeof(double)),new DataColumn("storageunit"),new DataColumn("askamount_int"),new DataColumn("originality_Amount"),new DataColumn("allrealgross",typeof(double)), new DataColumn("allavagross",typeof(double))};
            p_dtbMedicineTalbe.Columns.AddRange(dcColumns);

            p_dtbMedicineTalbe.Columns["inmoney"].Expression = "callprice_int * netamount_int";
            p_dtbMedicineTalbe.Columns["retailmoney"].Expression = "retailprice_int * netamount_int";
        }
        #endregion
        #region �����µ�һ��ҩƷ������Ϣ

        /// <summary>
        /// �����µ�һ��ҩƷ������Ϣ
        /// </summary>
        internal void m_mthInsertNewMedicineData()
        {
            if (m_objViewer.m_dtbOutMedicine == null)
            {
                return;
            }

            DataRow drNew = m_objViewer.m_dtbOutMedicine.NewRow();
            m_objViewer.m_dtbOutMedicine.Rows.Add(drNew);
            m_objViewer.m_dgvMedicineOutInfo.Focus();
            m_objViewer.m_dgvMedicineOutInfo.CurrentCell = m_objViewer.m_dgvMedicineOutInfo[1, m_objViewer.m_dgvMedicineOutInfo.RowCount - 1];


        }
        #endregion
        #region ��ʼ��ҩƷ�ֵ���СԪ�ؼ���Ϣ
        /// <summary>
        /// ��ʼ��ҩƷ�ֵ���СԪ�ؼ���Ϣ
        /// </summary>
        /// <param name="p_dtbMedicineInfo"></param>
        internal void m_mthInitMedicineInfo(ref DataTable p_dtbMedicineInfo)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetBaseMedicineWithGross(string.Empty, m_objViewer.Tag.ToString().Trim(), out p_dtbMedicineInfo);
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
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvMedicineOutInfo.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvMedicineOutInfo.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint,true);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                //m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineOutInfo.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineOutInfo.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineOutInfo.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineOutInfo.Location.Y - m_ctlQueryMedicint.Size.Height);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthInitMedicineInfo(ref m_objViewer.m_dtbMedicineInfo);
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicineInfo;
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        {
            long lngReturn = 1;

            double dblGrossTemp = 0d;
            clsDcl_MakeOutStorageOrder objSTDomain = new clsDcl_MakeOutStorageOrder();
            long lngRes = objSTDomain.m_lngGetAvailaGross(m_objViewer.Tag.ToString().Trim(), p_strMedicineID, out dblGrossTemp);
            if (dblGrossTemp <= 0)
            {
                MessageBox.Show("��ҩƷ���޿��ÿ��", "ҩ��������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_ctlQueryMedicint.Visible = true;
                m_ctlQueryMedicint.Focus();
                lngReturn = -1;
            }
            return lngReturn;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            int intRowIndex = m_objViewer.m_dgvMedicineOutInfo.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvMedicineOutInfo.CurrentCell.ColumnIndex;

            if (m_objViewer.m_dtbOutMedicine != null)
            {
                //DataRow[] drOld = m_objViewer.m_dtbOutMedicine.Select("MEDICINEID_CHR = '" + MS_VO.m_strMedicineID + "'");
                //if (drOld != null && drOld.Length > 0)
                //{
                //    MessageBox.Show("�����ⵥ��ѡ���ҩ", "ҩ�����", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    m_objViewer.m_dgvMedicineOutInfo.CurrentCell = m_objViewer.m_dgvMedicineOutInfo.Rows[intRowIndex].Cells["m_dgvtxtMedicineCode"];
                //}
                //else
                
                    DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvMedicineOutInfo.CurrentCell.OwningRow.DataBoundItem)).Row;
                    for (int i1 = 0; i1 < drCurrent.ItemArray.Length; i1++)
                    {
                        if (drCurrent.Table.Columns[i1].ColumnName.ToLower() != "inmoney" && drCurrent.Table.Columns[i1].ColumnName.ToLower() != "retailmoney")
                            drCurrent[i1] = drCurrent.Table.Columns[i1].DefaultValue;
                    }
                    m_objViewer.m_mthShowRetailMoney();

                    drCurrent["assistcode_chr"] = MS_VO.m_strMedicineCode;
                    drCurrent["MEDICINENAME_VCHr"] = MS_VO.m_strMedicineName;
                    drCurrent["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
                    drCurrent["OPUNIT_CHR"] = MS_VO.m_strMedicineUnit;
                    drCurrent["productorid_chr"] = MS_VO.m_strManufacturer;
                    drCurrent["MEDICINEID_CHR"] = MS_VO.m_strMedicineID;
                    drCurrent["medicinetypeid_chr"] = MS_VO.m_strMedicineTypeID;
                    if (m_hstAskAmount.Count > 0 && m_hstAskAmount.ContainsKey(MS_VO.m_strMedicineID))
                    {
                        drCurrent["askamount_int"] = Convert.ToDouble(m_hstAskAmount[MS_VO.m_strMedicineID]);
                    }
                    else
                    {
                        drCurrent["askamount_int"] = 0;
                    }
                    drCurrent["NETAMOUNT_INT"] = drCurrent["askamount_int"];
                    m_objViewer.m_dgvMedicineOutInfo.CurrentCell = m_objViewer.m_dgvMedicineOutInfo.Rows[intRowIndex].Cells["m_dgvtxtOutAmount"];
                
            }
            //m_objViewer.m_dgvMedicineOutInfo.Refresh();
            m_objViewer.m_dgvMedicineOutInfo.Focus();
            m_objViewer.m_dgvMedicineOutInfo.CurrentCell.Selected = true;
            System.Windows.Forms.SendKeys.SendWait("{RIGHT}");
            System.Windows.Forms.SendKeys.SendWait("{LEFT}");
        }
        #endregion

        #region ��ʾ����ҩƷѡ����
        /// <summary>
        /// ��ʾ����ҩƷѡ����
        /// </summary>
        /// <param name="p_strAmount"></param>
        internal long m_lngShowMedicineSelect(string p_strAmount)
        {
            double dblAmount = 0d;
            if (!double.TryParse(p_strAmount, out dblAmount))
            {
                MessageBox.Show("��������Ϊ���ұ���Ϊ����", "ҩ��������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else
            {
                //if (dblAmount <= 0)
                //{
                //    MessageBox.Show("�������������", "ҩ��������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //    return -1;
                //}
            }

            if (m_objViewer.m_dgvMedicineOutInfo.CurrentCell == null || m_objViewer.m_dtbOutMedicine == null)
            {
                return -1;
            }

            int intCurrentRow = m_objViewer.m_dgvMedicineOutInfo.CurrentCell.RowIndex;
            DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvMedicineOutInfo.CurrentCell.OwningRow.DataBoundItem)).Row;
            string strMedicineID = drCurrent["MEDICINEID_CHR"].ToString();
            clsMS_StorageDetail[] objDetail = null;
            clsDcl_MakeOutStorageOrder objSTDomain = new clsDcl_MakeOutStorageOrder();
            long lngRes = 0;

            //��鱾���ⵥ֮ǰ�Ƿ���¼����ͬҩƷ
            DataRowView dtvTemp = null;
            for (int iRow = 0; iRow < m_objViewer.m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                dtvTemp = m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].DataBoundItem as DataRowView;
                if (dtvTemp["MEDICINEID_CHR"].ToString() == strMedicineID && iRow != intCurrentRow)
                {
                    DialogResult drQ = MessageBox.Show("�����ⵥ��¼���ҩƷ�������" + (iRow + 1).ToString() + "�У���ȷ���ٴ�¼�뽫��֮�ϲ����Ƿ������", "ҩ��������", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drQ == DialogResult.No)
                    {
                        return -1;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            DataRow[] drOld = m_objViewer.m_dtbOutMedicine.Select("MEDICINEID_CHR = '" + strMedicineID + "'");

            Hashtable hstNetAmount = new Hashtable();
            bool blnHasMain = false;//�Ƿ����оɼ�¼������ǰ�Ƿ����޸�״̬


            if (m_objCurrentMain != null)
            {
                blnHasMain = true;
            }

            lngRes = objSTDomain.m_lngGetStorageMedicineDetail(strMedicineID, m_objViewer.Tag.ToString().Trim(), out objDetail);

            double dblAllRealGross = 0d;//��ʵ�ʿ��

            double dblAllAvaGross = 0d;//�ܿ��ÿ��


            //if (objDetail != null && objDetail.Length > 0)
            //{
            if (objDetail != null && objDetail.Length > 0)
            {
                for (int iGro = 0; iGro < objDetail.Length; iGro++)
                {
                    dblAllAvaGross += objDetail[iGro].m_dblAVAILAGROSS_INT;
                    dblAllRealGross += objDetail[iGro].m_dblREALGROSS_INT;
                }

                //if (dblAllAvaGross <= 0)
                //{
                //    MessageBox.Show("��ѡ��ҩƷû�п��ÿ�棡\n(��ʾ����ѡ����һ��ҩƷ��ɾ��ѡ�е�ҩƷ��)", "ҩ��������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return -1;
                //}

                if (blnHasMain)//��ǰ�����޸�״̬
                {
                    lngRes = m_objDomain.m_lngGetNetAmount(m_objCurrentMain.m_lngSERIESID_INT, strMedicineID, out hstNetAmount);

                    if (drOld != null && drOld.Length > 0)
                    {
                        dblAmount = 0d;
                        double dblTemp = 0d;
                        for (int iOld = 0; iOld < drOld.Length; iOld++)
                        {
                            if (double.TryParse(drOld[iOld]["NETAMOUNT_INT"].ToString(), out dblTemp))
                            {
                                dblAmount += dblTemp;

                                if (drOld[iOld]["CALLPRICE_INT"] == DBNull.Value || drOld[iOld]["VALIDPERIOD_DAT"] == DBNull.Value)
                                {
                                    continue;
                                }
                                string strKey = drOld[iOld]["lotno_vchr"].ToString().PadLeft(10, '0') + drOld[iOld]["instorageid_vchr"].ToString()
                                    + Convert.ToDateTime(drOld[iOld]["VALIDPERIOD_DAT"]).ToString("yyyy-MM-dd") + Convert.ToDouble(drOld[iOld]["CALLPRICE_INT"]).ToString("0.0000");

                                if (blnHasMain && hstNetAmount.Contains(strKey))
                                {
                                    double dblTempAmount = 0d;
                                    if (double.TryParse(hstNetAmount[strKey].ToString(), out dblTempAmount))
                                    {
                                        for (int iSD = 0; iSD < objDetail.Length; iSD++)
                                        {
                                            if (drOld[iOld]["lotno_vchr"].ToString() == objDetail[iSD].m_strLOTNO_VCHR && drOld[iOld]["instorageid_vchr"].ToString() == objDetail[iSD].m_strINSTORAGEID_VCHR
                                                && Convert.ToDateTime(drOld[iOld]["VALIDPERIOD_DAT"]) == objDetail[iSD].m_dtmVALIDPERIOD_DAT && Convert.ToDecimal(drOld[iOld]["CALLPRICE_INT"]) == objDetail[iSD].m_dcmCALLPRICE_INT)
                                            {
                                                objDetail[iSD].m_dblAVAILAGROSS_INT += dblTempAmount;
                                                break;
                                            }
                                        }
                                        //lngRes = objSTDomain.m_lngAddStorageDetailAvailaGross(dblTempAmount, drCurrent["MEDICINEID_CHR"].ToString(), drCurrent["LOTNO_VCHR"].ToString(), drCurrent["INSTORAGEID_VCHR"].ToString(), m_objViewer.m_strStorageID);
                                    }
                                }
                            }
                        }
                    }
                }
            }

                frmQueryMedicineInfo frmQMI = new frmQueryMedicineInfo(dblAmount);
                frmQMI.Icon = this.m_objViewer.Icon;
                frmQMI.Text = "ҩƷѡ���б�";
                frmQMI.ShowInTaskbar = false;
                frmQMI.m_mthSetMedicineVO(objDetail);
                frmQMI.ShowDialog();

                if (frmQMI.DialogResult == DialogResult.OK)
                {
                    int intFirstRowIndex = 0;//��ѡҩƷ��һ����DataTable�е�����
                    if (drOld != null && drOld.Length > 0)
                    {
                        for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
                        {
                            if (strMedicineID == m_objViewer.m_dtbOutMedicine.Rows[iRow]["MEDICINEID_CHR"].ToString())
                            {
                                intFirstRowIndex = iRow;
                                break;
                            }
                        }

                        foreach (DataRow drC in drOld)
                        {
                            m_objViewer.m_dtbOutMedicine.Rows.Remove(drC);
                        }
                    }
                    clsMS_StorageMedicineShow[] objValue = frmQMI.m_ObjOutMedicinArr;
                    m_mthSetOutMedicineVOToTable(objValue, dblAllRealGross, dblAllAvaGross, intFirstRowIndex);
                }
                else
                {
                    return -1;
                }
                //else
                //{
                //    if (drOld != null && drOld.Length > 0 && blnHasMain)
                //    {
                //        for (int iOld = 0; iOld < drOld.Length; iOld++)
                //        {
                //            if (hstNetAmount.Contains(drOld[iOld]["lotno_vchr"].ToString()))
                //            {
                //                double dblTempAmount = 0d;
                //                if (double.TryParse(hstNetAmount[drOld[iOld]["lotno_vchr"].ToString()].ToString(), out dblTempAmount))
                //                {
                //                    lngRes = objSTDomain.m_lngSubStorageDetailAvailaGross(dblTempAmount, drCurrent["MEDICINEID_CHR"].ToString(), drCurrent["LOTNO_VCHR"].ToString(), drCurrent["INSTORAGEID_VCHR"].ToString(), Convert.ToDouble(drCurrent["CALLPRICE_INT"]), Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]), m_objViewer.m_strStorageID);
                //                }
                //            }
                //        }
                //    }
                //}
            //}
            //else
            //{
            //    MessageBox.Show("��ѡ��ҩƷû�п��ÿ�棡\n(��ʾ����ѡ����һ��ҩƷ��ɾ��ѡ�е�ҩƷ��)", "ҩ��������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return -1;
            //}
            return lngRes;
        }
        #endregion

        #region ���ó���ҩƷ��Ϣ������

        /// <summary>
        /// ���ó���ҩƷ��Ϣ������
        /// </summary>
        /// <param name="p_objValue">����ҩƷ��Ϣ</param>
        /// <param name="p_dblAllRealGross">��ʵ�ʿ��</param>
        /// <param name="p_dblAllAvaGross">�ܿ��ÿ��</param>
        /// <param name="p_intFirstRowIndex">��ѡҩƷ��һ����DataTable�е�����</param>
        internal void m_mthSetOutMedicineVOToTable(clsMS_StorageMedicineShow[] p_objValue, double p_dblAllRealGross, double p_dblAllAvaGross, int p_intFirstRowIndex)
        {
            if (p_objValue == null || p_objValue.Length == 0)
            {
                return;
            }

            //DataRow drFirst = m_objViewer.m_dtbOutMedicine.Rows[m_objViewer.m_dgvMedicineOutInfo.CurrentCell.RowIndex];
            //m_mthAddDataToRow(drFirst, p_objValue[0]);

            int intRowsCount = m_objViewer.m_dtbOutMedicine.Rows.Count;

            //ȥ�����һ�п���

            //if (intRowsCount > 0 && m_objViewer.m_dtbOutMedicine.Rows[intRowsCount - 1]["availagross_int"] == DBNull.Value)
            //{
            //    m_objViewer.m_dtbOutMedicine.Rows.RemoveAt(intRowsCount - 1);
            //}
            //if (intRowsCount > 0)//ȥ������
            //{
            //    DataRow[] drNull = m_objViewer.m_dtbOutMedicine.Select("availagross_int is null");
            //    if (drNull != null && drNull.Length > 0)
            //    {
            //        foreach (DataRow drTemp in drNull)
            //        {
            //            m_objViewer.m_dtbOutMedicine.Rows.Remove(drTemp);
            //        }
            //    }
            //}

            //m_objViewer.m_dtbOutMedicine.BeginLoadData();
            for (int iRow = 0; iRow < p_objValue.Length; iRow++)
            {
                DataRow drNew = m_objViewer.m_dtbOutMedicine.NewRow();
                m_mthAddDataToRow(drNew, p_objValue[iRow], p_dblAllRealGross, p_dblAllAvaGross);
                m_objViewer.m_dtbOutMedicine.Rows.InsertAt(drNew, p_intFirstRowIndex);//Ҫ�����в�����ָ��λ��

                p_intFirstRowIndex++;
                //m_objViewer.m_dtbOutMedicine.LoadDataRow(drNew.ItemArray, true);
            }
            
            //m_objViewer.m_dtbOutMedicine.EndLoadData();
        }

        /// <summary>
        /// ���������ָ����
        /// </summary>
        /// <param name="p_drRow">������</param>
        /// <param name="p_objValue">����ҩƷ��Ϣ</param>
        /// <param name="p_dblAllRealGross">��ʵ�ʿ��</param>
        /// <param name="p_dblAllAvaGross">�ܿ��ÿ��</param>
        private void m_mthAddDataToRow(DataRow p_drRow, clsMS_StorageMedicineShow p_objValue, double p_dblAllRealGross, double p_dblAllAvaGross)
        {
            if (p_drRow == null || p_objValue == null)
            {
                return;
            }

            p_drRow["MEDICINEID_CHR"] = p_objValue.m_strMEDICINEID_CHR;
            p_drRow["MEDICINENAME_VCHR"] = p_objValue.m_strMEDICINENAME_VCHR;
            p_drRow["MEDSPEC_VCHR"] = p_objValue.m_strMEDSPEC_VCHR;
            p_drRow["storageunit"] = p_objValue.m_strOPUNIT_VCHR;
            p_drRow["OPUNIT_CHR"] = p_objValue.m_strOPUNIT_VCHR;
            p_drRow["NETAMOUNT_INT"] = p_objValue.m_dblOutAmount.ToString("0.00");
            p_drRow["LOTNO_VCHR"] = p_objValue.m_strLOTNO_VCHR;
            p_drRow["INSTORAGEID_VCHR"] = p_objValue.m_strINSTORAGEID_VCHR;
            p_drRow["CALLPRICE_INT"] = p_objValue.m_dcmCALLPRICE_INT.ToString("0.0000");
            p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmWHOLESALEPRICE_INT.ToString("0.0000");
            p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmRETAILPRICE_INT.ToString("0.0000");
            p_drRow["VENDORID_CHR"] = p_objValue.m_strVENDORID_CHR;
            p_drRow["vendorname_vchr"] = p_objValue.m_strVENDORName;
            p_drRow["productorid_chr"] = p_objValue.m_strPRODUCTORID_CHR;
            p_drRow["instoragedate_dat"] = p_objValue.m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
            p_drRow["validperiod_dat"] = p_objValue.m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd");
            p_drRow["realgross_int"] = p_objValue.m_dblREALGROSS_INT.ToString("0.00");
            p_drRow["assistcode_chr"] = p_objValue.m_strMEDICINECode;
            p_drRow["availagross_int"] = p_objValue.m_dblAVAILAGROSS_INT.ToString("0.00");
            //p_drRow["inmoney"] = (p_objValue.m_dblOutAmount * (double)p_objValue.m_dcmCALLPRICE_INT).ToString("0.0000");
            //p_drRow["retailmoney"] = (p_objValue.m_dblOutAmount * (double)p_objValue.m_dcmRETAILPRICE_INT).ToString("0.0000");
            p_drRow["allrealgross"] = p_dblAllRealGross.ToString("0.00");
            p_drRow["allavagross"] = p_dblAllAvaGross.ToString("0.00");
            p_drRow["medicinetypeid_chr"] = p_objValue.m_strMedicineTypeID_chr;
            if (m_hstAskAmount.Count > 0 && m_hstAskAmount.ContainsKey(p_objValue.m_strMEDICINEID_CHR))
            {
                p_drRow["askamount_int"] = Convert.ToDouble(m_hstAskAmount[p_objValue.m_strMEDICINEID_CHR]);
            }
            else
            {
                p_drRow["askamount_int"] = 0;
            }
            p_drRow.EndEdit();
        }
        #endregion
        #region ɾ��������ϸ
        /// <summary>
        /// ɾ��������ϸ
        /// </summary>
        /// <returns></returns>
        internal void m_mthDeleteDetail()
        {

            if (m_objViewer.m_dgvMedicineOutInfo.SelectedCells.Count == 0)
            {
                return;
            }
            int intRowIndex = m_objViewer.m_dgvMedicineOutInfo.SelectedCells[0].RowIndex;
            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvMedicineOutInfo.CurrentCell.OwningRow.DataBoundItem).Row;
            m_objViewer.m_dtbOutMedicine.Rows.Remove(drCurrent);

        }
        #endregion

        #region �ж��Ƿ����
        /// <summary>
        /// �ж��Ƿ����
        /// </summary>
        /// <param name="medicineid_chr">ҩƷID</param>
        /// <param name="lotno_vchr">����</param>
        /// <param name="instorageid_vchr">��ⵥ��</param>
        /// <param name="bolAdjustrice"></param>
        internal void m_mthGetAdjustrice(string medicineid_chr, string lotno_vchr, string instorageid_vchr, DateTime p_dtmValiDate, double p_dblInPrice, out bool bolAdjustrice)
        {
            if (m_objCurrentMain == null)
            {
                bolAdjustrice = false;
                return;
            }
            m_objDomain.m_mthGetAdjustrice(medicineid_chr, lotno_vchr, instorageid_vchr, p_dtmValiDate, p_dblInPrice, m_objCurrentMain.m_dtmASKDATE_DAT, out bolAdjustrice);

        }

        #endregion
        #region ����ҩƷ������Ϣ
        /// <summary>
        /// ����ҩƷ������Ϣ
        /// </summary>
        /// <param name="p_blnWantHint">�Ƿ���Ҫ��ʾ</param>
        /// <returns></returns>
        internal long m_lngSaveOutStorageInfo(bool p_blnWantHint)
        {
            #region ��Ч�Լ��
            //��ֹ�򿪶����˽��棬������ͬһ�ŵ���
            if (m_objDomain.m_lngCheckStatus(m_objViewer.m_txtAskBillNo.Text) < 0)
            {
                MessageBox.Show("�����쵥����ˣ������ٴ���ˣ���ˢ�¡�", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                return -1;
            }

            DateTime datOutTime;
            m_objDomain.m_mthGetAccountperiodTime(m_objViewer.m_strStorageID, out datOutTime);
            if (Convert.ToDateTime(m_objViewer.m_datMakeOrder.Text) < datOutTime)
            {
                MessageBox.Show("�Ƶ����ڲ���С���ϴ������ת�Ľ������ڡ�\r\n�ϴν�ת���������ǣ�" + datOutTime.ToString("yyyy��MM��dd�� HH:mm:ss"), "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //m_objViewer.m_datMakeOrder.Focus();
                return -1;
            }

            if (string.IsNullOrEmpty(m_objViewer.m_txtApplyDept.AccessibleName) && p_blnWantHint)
            {
                MessageBox.Show("����ѡ�����ò���", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            if (string.IsNullOrEmpty(m_objViewer.m_cboStatus.Text) && p_blnWantHint)
            {
                MessageBox.Show("������д��������", "ҩ������", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_cboStatus.Focus();
                return -1;
            }
            if ((m_objViewer.m_dtbOutMedicine == null || m_objViewer.m_dtbOutMedicine.Rows.Count == 0) && p_blnWantHint)
            {
                MessageBox.Show("����ѡ�����ҩƷ", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (m_objViewer.m_dtbOutMedicine.Rows.Count == 1)//ֻ��һ���Զ���ӵĿ�����
            {
                if (m_objViewer.m_dtbOutMedicine.Rows[0]["medicineid_chr"] == DBNull.Value)
                {
                    MessageBox.Show("����ѡ�����ҩƷ", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            double dblAmount = 0d;
            DataRow drTemp = null;
            for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
            {
                drTemp = m_objViewer.m_dtbOutMedicine.Rows[iRow];
                if (drTemp.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["availagross_int"] != DBNull.Value)
                {
                    if (!double.TryParse(drTemp["NETAMOUNT_INT"].ToString(), out dblAmount))
                    {
                        MessageBox.Show("������������Ϊ����", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    else
                    {
                        if (dblAmount <= 0)
                        {
                            //MessageBox.Show("������������Ϊ����������", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //return -1;
                        }
                        else
                        {
                            double dblOriAmount = 0d;
                            if (double.TryParse(drTemp["originality_Amount"].ToString(), out dblOriAmount))
                            {
                                if ((dblAmount - dblOriAmount) > Convert.ToDouble(drTemp["availagross_int"]))
                                {
                                    MessageBox.Show(drTemp["MEDICINENAME_VCHr"].ToString() + "�����������ܴ��ڿ��ÿ��", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return -1;
                                }
                            }
                            else if (dblAmount > Convert.ToDouble(drTemp["availagross_int"]))
                            {
                                MessageBox.Show(drTemp["MEDICINENAME_VCHr"].ToString() + "�����������ܴ��ڿ��ÿ��", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return -1;
                            }
                        }
                    }
                }
            }
            #endregion

            //����Ƿ����ظ���¼
            string strMedicineID = string.Empty;
            string strLotno = string.Empty;
            string strInstorageID = string.Empty;
            string strValidDate = string.Empty;
            double dblCallPrice = 0;
            for (int intRow = 0; intRow < m_objViewer.m_dtbOutMedicine.Rows.Count; intRow++)
            {
                //20080721������������0
                #region ȥ������
                DataRow[] drNull = m_objViewer.m_dtbOutMedicine.Select("MEDICINEID_CHR is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow drDel in drNull)
                    {
                        m_objViewer.m_dtbOutMedicine.Rows.Remove(drDel);
                    }
                }
                #endregion

                strMedicineID = Convert.ToString(m_objViewer.m_dtbOutMedicine.Rows[intRow]["MEDICINEID_CHR"]);
                strLotno = Convert.ToString(m_objViewer.m_dtbOutMedicine.Rows[intRow]["LOTNO_VCHR"]);
                strInstorageID = Convert.ToString(m_objViewer.m_dtbOutMedicine.Rows[intRow]["INSTORAGEID_VCHR"]);
                strValidDate = Convert.ToString(m_objViewer.m_dtbOutMedicine.Rows[intRow]["validperiod_dat"]);
                dblCallPrice = Convert.ToString(m_objViewer.m_dtbOutMedicine.Rows[intRow]["CALLPRICE_INT"]) == "" ? 0 : Convert.ToDouble(m_objViewer.m_dtbOutMedicine.Rows[intRow]["CALLPRICE_INT"]);

                m_objViewer.m_dtbOutMedicine.CaseSensitive = true;
                DataRow[] drOld = m_objViewer.m_dtbOutMedicine.Select("MEDICINEID_CHR = '" + strMedicineID + "' and LOTNO_VCHR = '"
                    + strLotno + "' and INSTORAGEID_VCHR = '" + strInstorageID
                    + "' and validperiod_dat = '" + strValidDate + "' and CALLPRICE_INT = " + dblCallPrice);
                if (drOld != null && drOld.Length > 1)
                {
                    DialogResult drResult = MessageBox.Show("�����ⵥ���ظ�ҩƷ(" + drOld[0][3].ToString() + "),�Ƿ��������", "ҩƷ������ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return -1;
                    }

                    double dblNetamount = 0;
                    for (int intDr = 0; intDr < drOld.Length; intDr++)
                    {
                        dblNetamount += Convert.ToDouble(drOld[intDr]["netamount_int"]);
                    }

                    drOld[0]["netamount_int"] = dblNetamount;
                    DataRow drNew = m_objViewer.m_dtbOutMedicine.NewRow();
                    drNew.ItemArray = drOld[0].ItemArray;
                    drNew[0] = drOld[0][0].ToString();
                    foreach (DataRow drDel in drOld)
                    {
                        m_objViewer.m_dtbOutMedicine.Rows.Remove(drDel);
                    }
                    m_objViewer.m_dtbOutMedicine.Rows.Add(drNew);

                }
            }
            long lngRes = 0;
            try
            {
                bool blnIsCommit = true;//m_objViewer.m_intCommitFolow == 1 ? true : false; ;
                bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;
                clsMS_OutStorage_VO objMain = m_objGetMainISVO();
                DataRow[] drNew = m_objViewer.m_dtbOutMedicine.Select(" NETAMOUNT_INT is not null");
                clsMS_OutStorageDetail_VO[] objDetailArr = m_objGetDetailArr(drNew, objMain.m_lngSERIESID_INT,m_dtbRequestDetail);
                lngRes = m_objDomain.m_lngSaveOutStorageByStorage(ref objMain, m_objCurrentSubArr, ref objDetailArr, blnIsCommit, blnIsAddNew, false);

                if (lngRes > 0)
                {
                    if (m_dtbRequestDetail.Rows.Count > 0)
                    {                        
                        lngRes = m_objDomain.m_lngUpdateEnoughState(Convert.ToInt64(m_dtbRequestDetail.Rows[0]["seriesid2_int"]), m_hstUpdateEnough);
                        if (lngRes < 0)
                            MessageBox.Show("�������쵥����״̬ʧ�ܣ�", "ע��...");
                    }
                    m_objViewer.m_lngMainSEQ = objMain.m_lngSERIESID_INT;
                    m_objViewer.m_txtOutStorageBillNo.Text = objMain.m_strOUTSTORAGEID_VCHR;
                    m_objCurrentMain = objMain;
                    m_objCurrentSubArr = objDetailArr;

                    m_mthSetSeriesIDToUI(objDetailArr);

                    //#region ȥ������
                    //DataRow[] drNull = m_objViewer.m_dtbOutMedicine.Select("availagross_int is null");
                    //if (drNull != null && drNull.Length > 0)
                    //{
                    //    foreach (DataRow drDel in drNull)
                    //    {
                    //        m_objViewer.m_dtbOutMedicine.Rows.Remove(drDel);
                    //    }
                    //}
                    //#endregion

                    //m_objViewer.m_dtbOutMedicine.AcceptChanges();

                    if (blnIsCommit)
                    {
                        m_objCurrentMain.m_intSTATUS = 2;
                        m_objViewer.m_btnStorageExam.Enabled = false;
                        m_objViewer.m_btnDelete.Enabled = false;
                        m_objViewer.m_btnInsert.Enabled = false;
                    }
                    if (p_blnWantHint)
                    {
                        MessageBox.Show("��˳ɹ�", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("���ʧ��", "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            catch (Exception Ex)
            {
                string strExMessage = "���ʧ��" + Environment.NewLine + Ex.Message;
                MessageBox.Show(strExMessage, "ҩƷ������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            return lngRes;
        }
        /// <summary>
        /// ���½������ݵ����к�
        /// </summary>
        /// <param name="p_objDetailArr">ҩƷ������ϸ</param>
        private void m_mthSetSeriesIDToUI(clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            if (m_objViewer.m_dtbOutMedicine != null && m_objViewer.m_dtbOutMedicine.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
                {
                    if (iRow < p_objDetailArr.Length)
                    {
                        m_objViewer.m_dtbOutMedicine.Rows[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        m_objViewer.m_dtbOutMedicine.Rows[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
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
        private clsMS_OutStorage_VO m_objGetMainISVO()
        {
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsMS_OutStorage_VO();                
            }
            m_objCurrentMain.m_dtmASKDATE_DAT = m_objViewer.m_datMakeOrder.Value;
            m_objCurrentMain.m_intSTATUS = 2;

            m_objCurrentMain.m_strASKID_VCHR = m_objViewer.m_txtAskBillNo.Text.Trim();
            m_objCurrentMain.m_strASKDEPT_CHR = m_objViewer.m_txtApplyDept.AccessibleName.Trim();
            m_objCurrentMain.m_strASKDEPTName = m_objViewer.m_txtApplyDept.Text;
            m_objCurrentMain.m_intOutStorageTYPE_INT = 1;//old
            //int m_intType;
            //m_objDomain.m_lngGetTypeCodeByName(1,"���ų���", out m_intType);
            //m_objCurrentMain.m_intOutStorageTYPE_INT = m_intType;
            //m_objCurrentMain.m_intOutStorageTYPE_INT = Convert.ToInt32(m_objViewer.m_cboStatus.AccessibleName);
            m_objCurrentMain.m_intFORMTYPE_INT = 1;
            m_objCurrentMain.m_strASKERID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            m_objCurrentMain.m_strASKERName = m_objViewer.LoginInfo.m_strEmpName;
            m_objCurrentMain.m_strCOMMENT_VCHR = m_objViewer.m_txtComment.Text;
            m_objCurrentMain.m_strSTORAGEID_CHR = m_objViewer.Tag.ToString().Trim();
            m_objCurrentMain.m_strEXPORTDEPT_CHR = m_objViewer.Tag.ToString().Trim();
            m_objCurrentMain.m_strEXPORTDEPTName = m_objViewer.AccessibleName.Trim();
            m_objCurrentMain.m_dtmEXAMDATE_DAT = m_objViewer.m_datMakeOrder.Value;
            m_objCurrentMain.m_dtmOutStorageDate = m_objViewer.m_datMakeOrder.Value;

            m_objCurrentMain.m_strEXAMERID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
            m_objCurrentMain.m_strEXAMERName = this.m_objViewer.LoginInfo.m_strEmpName;
            return m_objCurrentMain;
        }
        #endregion

        #region ��ȡ�ӱ�����
        /// <summary>
        /// ��ȡ�ӱ�����
        /// </summary>
        /// <param name="p_drDetail">�ӱ�����</param>
        /// <param name="p_lngMainSEQ">��������</param>
        /// <param name="p_dtbRequestDetail">���쵥��ϸ</param>
        /// <returns></returns>
        private clsMS_OutStorageDetail_VO[] m_objGetDetailArr(DataRow[] p_drDetail, long p_lngMainSEQ,DataTable p_dtbRequestDetail)
        {
            clsMS_OutStorageDetail_VO[] objDetailArr = null;
            if (p_drDetail == null || p_drDetail.Length == 0)
            {
                return null;
            }

            double dblRealAmount = 0;//��ҩƷ��ǰ�����

            objDetailArr = new clsMS_OutStorageDetail_VO[p_drDetail.Length];
            for (int iRow = 0; iRow < p_drDetail.Length; iRow++)
            {
                objDetailArr[iRow] = new clsMS_OutStorageDetail_VO();
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = p_drDetail[iRow]["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCH = p_drDetail[iRow]["MEDICINENAME_VCHR"].ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR = p_drDetail[iRow]["MEDSPEC_VCHR"].ToString();
                objDetailArr[iRow].m_strOPUNIT_CHR = p_drDetail[iRow]["OPUNIT_CHR"].ToString();
                objDetailArr[iRow].m_dblNETAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["NETAMOUNT_INT"]);
                objDetailArr[iRow].m_strMedicineTypeID_chr = p_drDetail[iRow]["medicinetypeid_chr"].ToString();
                clsMS_MedicineTypeVisionmSet clsTypeVO = new clsMS_MedicineTypeVisionmSet();
                m_objDomain.m_lngGetMedicineTypeVisionm(p_drDetail[iRow]["medicinetypeid_chr"].ToString(), out clsTypeVO);
                if (/*clsTypeVO != null && clsTypeVO.m_intLotno == 0 &&*/ p_drDetail[iRow]["LOTNO_VCHR"].ToString().Trim() == "")
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = p_drDetail[iRow]["LOTNO_VCHR"].ToString();
                }

                objDetailArr[iRow].m_strINSTORAGEID_VCHR = p_drDetail[iRow]["INSTORAGEID_VCHR"].ToString();
                objDetailArr[iRow].m_dcmCALLPRICE_INT = Convert.ToString(p_drDetail[iRow]["CALLPRICE_INT"]).Length == 0?0:Convert.ToDecimal(p_drDetail[iRow]["CALLPRICE_INT"]);
                objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToString(p_drDetail[iRow]["WHOLESALEPRICE_INT"]).Length == 0?0:Convert.ToDecimal(p_drDetail[iRow]["WHOLESALEPRICE_INT"]);
                objDetailArr[iRow].m_dcmRETAILPRICE_INT = Convert.ToString(p_drDetail[iRow]["RETAILPRICE_INT"]).Length == 0?0:Convert.ToDecimal(p_drDetail[iRow]["RETAILPRICE_INT"]);
                objDetailArr[iRow].m_strVENDORID_CHR = p_drDetail[iRow]["VENDORID_CHR"].ToString();
                objDetailArr[iRow].m_strVendorName = p_drDetail[iRow]["vendorname_vchr"].ToString();
                if (Convert.ToString(p_drDetail[iRow]["validperiod_dat"]).Length != 0)
                {
                    objDetailArr[iRow].m_dtmValidperiod_dat = Convert.ToDateTime(p_drDetail[iRow]["validperiod_dat"]).Date;
                }
                objDetailArr[iRow].m_strProductorID_chr = p_drDetail[iRow]["productorid_chr"].ToString();
                if (Convert.ToString(p_drDetail[iRow]["instoragedate_dat"]).Length != 0)
                {
                    objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(p_drDetail[iRow]["instoragedate_dat"]);
                }
                objDetailArr[iRow].m_strMedicineTypeID_chr = p_drDetail[iRow]["medicinetypeid_chr"].ToString();
                objDetailArr[iRow].m_dblRealGross = Convert.ToString(p_drDetail[iRow]["realgross_int"]).Length == 0?0:Convert.ToDouble(p_drDetail[iRow]["realgross_int"]);
                objDetailArr[iRow].m_intStatus = 1;
                objDetailArr[iRow].m_intRETURNNUM_INT = 0;
                objDetailArr[iRow].m_strTYPECODE_CHR = Convert.ToString(m_objViewer.m_cboStatus.AccessibleName);
                objDetailArr[iRow].m_dblAskAmount = Convert.ToString(p_drDetail[iRow]["askamount_int"]).Length == 0?0:Convert.ToDouble(p_drDetail[iRow]["askamount_int"]);
                //20091024:����ʱ��ȡÿ��ҩƷ�ĵ�ǰ�������ҩ�⣩
                m_objDomain.m_lngGetAllRealGross(m_objViewer.Tag.ToString().Trim(), objDetailArr[iRow].m_strMEDICINEID_CHR, out dblRealAmount);
                objDetailArr[iRow].m_dblOldGross = dblRealAmount;
            }
            m_hstUpdateEnough.Clear();

            double m_dblOutAmount = 0d;
            for (int i1 = 0; i1 < p_dtbRequestDetail.Rows.Count; i1++)
            {
                m_dblOutAmount = 0;
                for (int i2 = 0; i2 < objDetailArr.Length; i2++)
                {
                    if (objDetailArr[i2].m_strMEDICINEID_CHR == p_dtbRequestDetail.Rows[i1]["medicineid_chr"].ToString())
                    {
                        m_dblOutAmount += objDetailArr[i2].m_dblNETAMOUNT_INT; 
                    }                    
                }
                if (m_dblOutAmount >= Convert.ToDouble(p_dtbRequestDetail.Rows[i1]["opamount_int"]))
                {
                    if (!m_hstUpdateEnough.ContainsKey(p_dtbRequestDetail.Rows[i1]["medicineid_chr"].ToString()))
                        m_hstUpdateEnough.Add(p_dtbRequestDetail.Rows[i1]["medicineid_chr"].ToString(), "+");
                }
                else
                {
                    if (!m_hstUpdateEnough.ContainsKey(p_dtbRequestDetail.Rows[i1]["medicineid_chr"].ToString()))
                        m_hstUpdateEnough.Add(p_dtbRequestDetail.Rows[i1]["medicineid_chr"].ToString(), "-");
                }
            }
            return objDetailArr;
        }
        #endregion

        /// <summary>
        /// �����������ID����ȡ������ӱ���ϸ�Ӷ����������ϸ
        /// </summary>
        /// <param name="m_lngAskSeq">�������ID</param>
        /// <param name="m_dtbOutMedicine">������ϸ��</param>
        internal void m_mthLoadMedicineData(long m_lngAskSeq, DataTable p_dtbRequestDetail,ref DataTable m_dtbOutMedicine)
        {
            try
            {
                m_dtbRequestDetail = p_dtbRequestDetail;
                long lngRes = 0;
                DataTable m_dtDetail = new DataTable();                
                lngRes = this.m_objDomain.m_lngGetAskDetailInfoByid(m_objViewer.m_blnIsHospital,Convert.ToInt64(m_lngAskSeq), out m_dtDetail);
                string m_strMedicineID = string.Empty;
                string m_strMedicineTypeid = string.Empty;
                string m_strMedicineName = string.Empty;
                string m_strMedSpec = string.Empty;
                double m_dblOPAmount = 0; //��������
                double m_dblOPAmountTmp = 0;
                string m_strAssistCode = string.Empty;
                Hashtable m_htbSelected = new Hashtable();
                double m_dblAllRealAmount = 0;//��ʵ�ʿ��
                double m_dblAllAvalidAmount = 0;//�ܿ��ÿ��
                DataRow drNew = null;
                clsMS_StorageDetail[] objDetail = null;
                int m_intRowAmount = 0;//�����п���Ϊ0������ʾ��治��
                bool m_blnAddNotEnough = false;//�Ƿ�׷�ӿ�治��������¼
                int m_intPartNotEnough = 0;//����ҩƷ���ÿ�治��

                double m_dblAllAmount = 0;//20081230 �������������ͳ�����п��ÿ�棨����������
                for (int i1 = 0; i1 < m_dtDetail.Rows.Count; i1++)
                {                    
                    m_dblAllRealAmount = 0;
                    m_dblAllAvalidAmount = 0;
                    m_dblAllAmount = 0;
                    m_strMedicineID = Convert.ToString(m_dtDetail.Rows[i1]["medicineid_chr"]);
                    m_strMedicineTypeid = Convert.ToString(m_dtDetail.Rows[i1]["medicinetypeid_chr"]);
                    m_strMedicineName = Convert.ToString(m_dtDetail.Rows[i1]["medicinename_vchr"]);
                    //m_strMedSpec = Convert.ToString(m_dtDetail.Rows[i1]["medspec_vchr"]);
                    m_dblOPAmount = Convert.ToDouble(m_dtDetail.Rows[i1]["opamount_int"]);
                    m_strAssistCode = Convert.ToString(m_dtDetail.Rows[i1]["assistcode_chr"]);
                    m_dblOPAmountTmp = m_dblOPAmount;

                    if (!m_hstAskAmount.ContainsKey(m_strMedicineID))
                    {
                        m_hstAskAmount.Add(m_strMedicineID, m_dblOPAmount);
                    }
                    //20080530 ���ٿ��ǹ��
                    lngRes = m_objDomain.m_lngGetStorageMedicineDetailInfo(m_strMedicineID, m_objViewer.m_strStorageID, out objDetail); //m_strMedSpec, out objDetail);
                    if (lngRes > 0 && objDetail != null)
                    {
                        for (int i3 = 0; i3 < objDetail.Length; i3++)
                        {
                            m_dblAllAmount += objDetail[i3].m_dblAVAILAGROSS_INT;

                            if (objDetail[i3].m_dblAVAILAGROSS_INT <= 0)
                                continue;
                            m_dblAllRealAmount += objDetail[i3].m_dblREALGROSS_INT;
                            m_dblAllAvalidAmount += objDetail[i3].m_dblAVAILAGROSS_INT;
                        }
                        if (m_dblAllAvalidAmount <= 0)
                            m_intRowAmount += 1;
                    }

                    //m_blnAddNotEnough = (m_dblOPAmount > m_dblAllAvalidAmount);
                    m_blnAddNotEnough = (m_dblOPAmount > m_dblAllAmount);

                    if (lngRes > 0 && objDetail != null)
                    {
                        m_dtbOutMedicine.BeginLoadData();
                        if (objDetail != null && objDetail.Length > 0 && m_dblAllAmount > 0)
                        {
                            for (int i2 = 0; i2 < objDetail.Length; i2++)
                            {
                                if (objDetail[i2].m_dblAVAILAGROSS_INT <= 0)
                                {
                                    continue;
                                }                                

                                if (m_dblOPAmount == 0) break;
                                drNew = m_dtbOutMedicine.NewRow();
                                drNew["MEDICINEID_CHR"] = objDetail[i2].m_strMEDICINEID_CHR;
                                drNew["MEDICINENAME_VCHR"] = objDetail[i2].m_strMEDICINENAME_VCHR;
                                drNew["medicinetypeid_chr"] = objDetail[i2].m_strMEDICINETYPEID_CHR;
                                drNew["MEDSPEC_VCHR"] = objDetail[i2].m_strMEDSPEC_VCHR;
                                drNew["OPUNIT_CHR"] = objDetail[i2].m_strOPUNIT_VCHR;
                                if (m_dblOPAmount > objDetail[i2].m_dblAVAILAGROSS_INT)
                                {
                                    drNew["NETAMOUNT_INT"] = objDetail[i2].m_dblAVAILAGROSS_INT.ToString("0.00");
                                    m_dblOPAmount -= objDetail[i2].m_dblAVAILAGROSS_INT;
                                }
                                else
                                {
                                    drNew["NETAMOUNT_INT"] = m_dblOPAmount;
                                    m_dblOPAmount = 0;
                                }
                                drNew["realgross_int"] = objDetail[i2].m_dblREALGROSS_INT.ToString("0.00");
                                drNew["availagross_int"] = objDetail[i2].m_dblAVAILAGROSS_INT.ToString("0.00");
                                drNew["LOTNO_VCHR"] = objDetail[i2].m_strLOTNO_VCHR;
                                drNew["INSTORAGEID_VCHR"] = objDetail[i2].m_strINSTORAGEID_VCHR;
                                drNew["CALLPRICE_INT"] = objDetail[i2].m_dcmCALLPRICE_INT.ToString("0.0000");
                                drNew["WHOLESALEPRICE_INT"] = objDetail[i2].m_dcmWHOLESALEPRICE_INT.ToString("0.0000");
                                drNew["RETAILPRICE_INT"] = objDetail[i2].m_dcmRETAILPRICE_INT.ToString("0.0000");
                                drNew["VENDORID_CHR"] = objDetail[i2].m_strVENDORID_CHR;
                                drNew["vendorname_vchr"] = objDetail[i2].m_strVENDORName;
                                drNew["productorid_chr"] = objDetail[i2].m_strPRODUCTORID_CHR;
                                drNew["instoragedate_dat"] = objDetail[i2].m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
                                drNew["validperiod_dat"] = objDetail[i2].m_dtmVALIDPERIOD_DAT.Date;
                                drNew["assistcode_chr"] = objDetail[i2].m_strMEDICINECode;
                                drNew["seriesid_int"] = objDetail[i2].m_lngSERIESID_INT;
                                drNew["allrealgross"] = m_dblAllRealAmount.ToString("0.00");
                                drNew["allavagross"] = m_dblAllAvalidAmount.ToString("0.00");
                                drNew["askamount_int"] = Convert.ToDouble(m_dtDetail.Rows[i1]["opamount_int"]);//������
                                
                                m_dtbOutMedicine.LoadDataRow(drNew.ItemArray, true);
                            }
                        }
                        if (m_blnAddNotEnough)
                        {
                            m_intPartNotEnough += 1;
                            if (m_dblOPAmount == 0)
                                continue;
                            drNew = m_dtbOutMedicine.NewRow();
                            drNew["MEDICINEID_CHR"] = m_strMedicineID;
                            drNew["assistcode_chr"] = m_strAssistCode;
                            drNew["MEDICINENAME_VCHR"] = m_strMedicineName;
                            drNew["MEDSPEC_VCHR"] = m_strMedSpec;
                            drNew["NETAMOUNT_INT"] = 0;//20080722ȱҩĬ����ʾ0 m_dblOPAmountTmp - m_dblAllAvalidAmount;
                            drNew["askamount_int"] = Convert.ToDouble(m_dtDetail.Rows[i1]["opamount_int"]);//������
                            m_dtbOutMedicine.LoadDataRow(drNew.ItemArray, true);
                        }
                        m_dtbOutMedicine.EndLoadData();
                    }
                    else
                    {
                        m_dtbOutMedicine.BeginLoadData();
                        drNew = m_dtbOutMedicine.NewRow();
                        drNew["MEDICINEID_CHR"] = m_strMedicineID;
                        drNew["medicinetypeid_chr"] = m_strMedicineTypeid;
                        drNew["assistcode_chr"] = m_strAssistCode;
                        drNew["MEDICINENAME_VCHR"] = m_strMedicineName;
                        drNew["MEDSPEC_VCHR"] = m_strMedSpec;
                        drNew["NETAMOUNT_INT"] = 0;//20080722ȱҩĬ����ʾ0 m_dblOPAmount;
                        drNew["askamount_int"] = Convert.ToDouble(m_dtDetail.Rows[i1]["opamount_int"]);//������
                        m_dtbOutMedicine.LoadDataRow(drNew.ItemArray, true);
                        m_dtbOutMedicine.EndLoadData();
                        m_intRowAmount += 1;
                        continue;
                    }

                }
                if (m_intRowAmount == m_dtDetail.Rows.Count && m_intRowAmount > 0)
                {
                    MessageBox.Show("ȫ��ҩƷ���ÿ�治�㣡", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (m_intPartNotEnough == m_dtDetail.Rows.Count)
                {
                    MessageBox.Show("ȫ��ҩƷ���ÿ�治�㣡", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (m_intRowAmount < m_dtDetail.Rows.Count && m_intRowAmount > 0)
                {
                    MessageBox.Show("����ҩƷ���ÿ�治�㣡", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                
                else if (m_intPartNotEnough > 0)
                {
                    MessageBox.Show("����ҩƷ���ÿ�治�㣡", "ע��", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void m_mthPrintDirect()
        {
            /*
            Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();
            dsData.LibraryList = clsMedicineStoreFormFactory.PBLPath;

            DataTable dtb = new DataTable();
            clsDcl_MedicineOut m_objDo = new clsDcl_MedicineOut();
            m_objDo.m_lngGetOutStorageDetailReportForGY3Y(Convert.ToInt32(this.m_objViewer.m_dtbOutMedicine.Rows[0]["seriesid2_int"].ToString()), out dtb);
            dsData.DataWindowObject = "ms_outstoragedetail";
            string RoomName;
            this.m_objDomain.m_lngGetStoreRoomName(this.m_objViewer.m_strStorageID, out RoomName);
            dsData.Modify("t_title.text='" + m_objComInfo.m_strGetHospitalTitle() + RoomName + "����ƾ֤'");
            dsData.Modify("m_storagename.text='" + RoomName + "'");
            dsData.Modify("m_txtreceivedept.text='" + m_objViewer.m_txtApplyDept.Text + "'");
            dsData.Modify("m_txtman.text='" + m_objViewer.LoginInfo.m_strEmpName + "'");
            //dsData.Modify("m_txtman2.text='" + m_objViewer.LoginInfo.m_strEmpName + "'");
            dsData.Modify("m_txtman3.text='" + m_objViewer.LoginInfo.m_strEmpName + "'");
            //dsData.Modify("m_txtman4.text='" + m_objViewer.LoginInfo.m_strEmpName + "'");         
            dsData.Modify("m_txtoutputorder.text='" + m_objViewer.m_txtOutStorageBillNo.Text + "'");
            dsData.Modify("t_RowNum.text='" + dtb.Rows.Count + "'");
            dsData.PrintProperties.Preview = true;
            dsData.Retrieve(dtb);
            dsData.CalculateGroups();
            //dsData.Refresh();
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog_DataStore(dsData, true);
             */ // ��������Ժ�汾�Ĵ�ӡ

            Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();
            dsData.LibraryList = clsMedicineStoreFormFactory.PBLPath;

            DataTable p_OutDtbVal = new DataTable();
            int intPrintType;
            m_objDomain.m_lngGetPrinType(out intPrintType);
            this.m_objDomain.m_lngGetOutStorageDetailReport(Convert.ToInt32(this.m_objViewer.m_dtbOutMedicine.Rows[0]["seriesid2_int"].ToString()), intPrintType, out p_OutDtbVal);
            DataRow dro;
            DataTable dtb = new DataTable();
            int i_temp = 0;

            dsData.DataWindowObject = "outstorage_detailreport_lj";

            string RoomName;
            this.m_objDomain.m_lngGetStoreRoomName(this.m_objViewer.m_strStorageID, out RoomName);



            if (intPrintType == 0)
            {
                dtb = p_OutDtbVal.Clone();
                for (int i_low = 0; i_low < p_OutDtbVal.Rows.Count; i_low++)
                {
                    i_temp++;
                    dtb.ImportRow(p_OutDtbVal.Rows[i_low]);
                    //ҩƷ�Ͳ��ϲ��ܴ���ͬһ��
                    if (((i_low + 1) >= p_OutDtbVal.Rows.Count) || ((p_OutDtbVal.Rows[i_low]["medicinetypesetid"].ToString()) != (p_OutDtbVal.Rows[i_low + 1]["medicinetypesetid"].ToString())))
                    {
                        int ros = 7 - i_temp % 7;
                        if (ros != 7)
                        {
                            int i_valCount = dtb.Rows.Count + ros;
                            for (int i = 0; i < ros; i++)
                            {
                                dro = dtb.NewRow();
                                dtb.Rows.Add(dro);
                            }
                            i_temp = 0;
                        }
                    }
                }
                dsData.DataWindowObject = "outstorage_detailreport_lj";
                dsData.Modify("t_titel.text='" + m_objComInfo.m_strGetHospitalTitle() + "ҩƷ���ε�'");
            }
            if (intPrintType == 1)
            {
                dtb = p_OutDtbVal.Copy();
                dsData.DataWindowObject = "outstorage_detailreport_cs";
                dsData.Modify("t_titel.text='" + m_objComInfo.m_strGetHospitalTitle() + "���ⵥ(" + RoomName + ")'");
                decimal douBug = Convert.ToDecimal(m_objViewer.m_lblRetailSubMoney.Text.Replace("Ԫ", ""));
                string mmm = new Money(douBug).ToString();
                dsData.Modify("t_bigwrith.text='" + mmm + "'");

                dtb.Columns.Add("group_int", typeof(System.Int32));
                int intGroup = 0;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    if (i % 15 == 0)
                    {
                        intGroup++;
                    }
                    dtb.Rows[i]["group_int"] = intGroup;

                }

            }
            dsData.Modify("m_storagename.text='" + RoomName + "'");
            dsData.Modify("m_txtreceivedept.text='" + m_objViewer.m_txtApplyDept.Text + "'");
            dsData.Modify("m_txtman.text='" + m_objViewer.LoginInfo.m_strEmpName + "'");
            dsData.Modify("m_txtman2.text='" + m_objViewer.LoginInfo.m_strEmpName + "'");
            dsData.Modify("m_dtpdate.text='" + m_objViewer.m_datMakeOrder.Text + "'");
            dsData.Modify("m_txtoutputorder.text='" + m_objViewer.m_txtOutStorageBillNo.Text + "'");
            dsData.PrintProperties.Preview = true;
            dsData.Retrieve(dtb);
            dsData.CalculateGroups();
            //dsData.Refresh();
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog_DataStore(dsData, true);
        }

        internal void m_mthPrintPreview()
        {
            frmMedicineOutReport frmReport = new frmMedicineOutReport();
            DataTable p_OutDtbVal = new DataTable();
            clsDcl_MedicineOut m_objDo = new clsDcl_MedicineOut();
            m_objDo.m_lngGetOutStorageDetailReportForGY3Y(Convert.ToInt64(this.m_objViewer.m_dtbOutMedicine.Rows[0]["seriesid2_int"].ToString()), out p_OutDtbVal);
            string RoomName;
            this.m_objDomain.m_lngGetStoreRoomName(this.m_objViewer.m_strStorageID, out RoomName);
            frmReport.datWindow.DataWindowObject = "ms_outstoragedetail";
            frmReport.ReceiveDept = m_objViewer.m_txtApplyDept.Text;
            frmReport.OutputOrder = m_objViewer.m_txtOutStorageBillNo.Text;
            frmReport.Man = m_objViewer.LoginInfo.m_strEmpName;
            //frmReport.Man2 = "";
            //frmReport.Man3 = m_objViewer.LoginInfo.m_strEmpName;
            //frmReport.Man4 = m_objViewer.LoginInfo.m_strEmpName;
            frmReport.RoomName = RoomName;
            frmReport.dtb = p_OutDtbVal;
            frmReport.i_showType = 1;
            frmReport.ShowDialog();
        }

        #region ��Ԥ������
        /// <summary>
        ///��ӡ
        /// </summary>
        internal long m_purchasePrint(int i_showType)
        {
            //
            decimal decTMoney;
            decTMoney = Convert.ToDecimal(m_objViewer.m_lblRetailSubMoney.Text.Replace("Ԫ",""));
            string strAllInMoney = new Money(decTMoney).ToString();

            if (m_objCurrentSubArr == null)
            {
                MessageBox.Show("��Ǹ��û�����ݿɴ�ӡ��", "ҩƷ���", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
            int intPrintType;
            m_objDomain.m_lngGetPrinType(out intPrintType);
            frmMedicineOutReport frmReport = new frmMedicineOutReport();
            DataTable p_OutDtbVal = new DataTable();
            this.m_objDomain.m_lngGetOutStorageDetailReport(Convert.ToInt32(this.m_objViewer.m_dtbOutMedicine.Rows[0]["seriesid2_int"].ToString()), intPrintType, out p_OutDtbVal);
            DataRow dro;

            int i_temp = 0;
            DataTable dtb = new DataTable();

            string RoomName;
            this.m_objDomain.m_lngGetStoreRoomName(this.m_objViewer.m_strStorageID, out RoomName);


            if (intPrintType == 0)
            {
                dtb = p_OutDtbVal.Clone();
                for (int i_low = 0; i_low < p_OutDtbVal.Rows.Count; i_low++)
                {
                    i_temp++;
                    dtb.ImportRow(p_OutDtbVal.Rows[i_low]);
                    //ҩƷ�Ͳ��ϲ��ܴ���ͬһ��

                    if (((i_low + 1) >= p_OutDtbVal.Rows.Count) || ((p_OutDtbVal.Rows[i_low]["medicinetypesetid"].ToString()) != (p_OutDtbVal.Rows[i_low + 1]["medicinetypesetid"].ToString())))
                    {
                        int ros = 7 - i_temp % 7;
                        if (ros != 7)
                        {
                            int i_valCount = dtb.Rows.Count + ros;
                            for (int i = 0; i < ros; i++)
                            {
                                dro = dtb.NewRow();
                                dtb.Rows.Add(dro);
                            }
                            i_temp = 0;
                        }
                    }
                }
                frmReport.datWindow.DataWindowObject = "outstorage_detailreport_lj";
            }

            if (intPrintType == 1)
            {
                dtb = p_OutDtbVal.Copy();
                frmReport.datWindow.DataWindowObject = "outstorage_detailreport_cs";
            }

            frmReport.ReceiveDept = m_objViewer.m_txtApplyDept.Text;
            frmReport.OutputOrder = m_objViewer.m_txtOutStorageBillNo.Text;
            decimal douBug = Convert.ToDecimal(m_objViewer.m_lblRetailSubMoney.Text.Replace("Ԫ", ""));
            string mmm = new Money(douBug).ToString();
            frmReport.strBigwrith = mmm;
            frmReport.zDate = m_objViewer.m_datMakeOrder.Text;
            frmReport.Man = m_objViewer.LoginInfo.m_strEmpName;
            frmReport.RoomName = RoomName;
            frmReport.dtb = dtb;
            frmReport.i_showType = i_showType;
            frmReport.strAllInMoney = strAllInMoney;
            frmReport.ShowDialog();

            return 1;
        }
        #endregion

        #region �����񵼳����ݵ�Excel
        /// <summary>
        /// �����񵼳����ݵ�Excel
        /// </summary>
        internal void m_mthExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "����Excel�ļ���";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                //����б���
                for (int iOr = 0; iOr < m_objViewer.m_dgvMedicineOutInfo.ColumnCount; iOr++)
                {
                    if (m_objViewer.m_dgvMedicineOutInfo.Columns[iOr].Visible == false) continue;
                    if (iOr > 0)
                    {
                        str += "\t";
                    }
                    str += m_objViewer.m_dgvMedicineOutInfo.Columns[iOr].HeaderText.Replace("\n", "");
                }
                sw.WriteLine(str);
                //������ı�
                StringBuilder objStrBuilder = null;
                for (int iOr = 0; iOr < m_objViewer.m_dgvMedicineOutInfo.Rows.Count; iOr++)
                {
                    if (m_objViewer.m_dgvMedicineOutInfo.Columns[iOr].Visible == false) continue;
                    objStrBuilder = new StringBuilder();
                    for (int jOr = 0; jOr < m_objViewer.m_dgvMedicineOutInfo.Columns.Count; jOr++)
                    {
                        if (jOr > 0)
                        {
                            objStrBuilder.Append("\t");
                        }
                        if (m_objViewer.m_dgvMedicineOutInfo.Columns[iOr].Name == "m_dgvtxtOrderCode")
                        {
                            objStrBuilder.Append("'"+m_objViewer.m_dgvMedicineOutInfo.Rows[iOr].Cells[jOr].Value.ToString());
                        }
                        else
                        {
                            objStrBuilder.Append(m_objViewer.m_dgvMedicineOutInfo.Rows[iOr].Cells[jOr].Value.ToString());
                        }
                    }
                    sw.WriteLine(objStrBuilder);
                }
                MessageBox.Show("�����ɹ���", "ҩƷ�������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
        #endregion

        /// <summary>
        /// ��ȡ���ų������͵�ID
        /// </summary>
        /// <param name="m_intType"></param>
        internal void m_lngGetTypeCodeByName(out int m_intType)
        {
            m_objDomain.m_lngGetTypeCodeByName(1, "���ų���", out m_intType); 
        }
    }
}

