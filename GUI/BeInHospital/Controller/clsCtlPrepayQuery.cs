using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.middletier.baseInfo;//baseInfo_Svc.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// Ԥ�����ѯ
    /// ���ߣ�He Guiqiu
    /// ����ʱ��:2006-06-14
    /// </summary>
    public class clsCtlPrepayQuery : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDclPrepayQuery m_objDomain;
        private frmPrepayQuery m_objViewer;
        private DataTable m_dtPrint;
        private DataView m_rptView;

        public clsCtlPrepayQuery()
        {
            m_objDomain = new clsDclPrepayQuery();
            //m_objViewer = new frmPrepayQuery();
            m_dtPrint = new DataTable();

            //
        }

        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPrepayQuery)frmMDI_Child_Base_in;
        }
        #endregion

        public void ButtonFind_Click()
        {
            string condition = "";
            string strAreaId = "";
            bool bolCheck;

            //����
            bolCheck = this.m_objViewer.m_checkBoxDate.Checked;
            if (bolCheck == true)
            {
                string strFrom;
                strFrom = this.m_objViewer.m_dateTimePickerFrom.Value.ToString("yyyy-MM-dd HH:mm:ss");

                string strTo;
                strTo = this.m_objViewer.m_dateTimePickerTo.Value.ToString("yyyy-MM-dd HH:mm:ss");

                condition += @" and b.CREATE_DAT > to_date('" + strFrom + "', 'yyyy-MM-dd HH24:MI:SS')"
                           + @" and b.CREATE_DAT < to_date('" + strTo + "', 'yyyy-MM-dd HH24:MI:SS')";

            }

            //����
            //bolCheck = this.m_objViewer.m_checkBoxArea.Checked;
            //if (bolCheck == true)
            //{

            if (this.m_objViewer.m_deptIDArr != null && this.m_objViewer.m_deptIDArr.Count > 0)
            {
                strAreaId = "";
                for (int i = 0; i < this.m_objViewer.m_deptIDArr.Count; i++)
                {
                    strAreaId += "'" + this.m_objViewer.m_deptIDArr[i] + "',";
                }
                strAreaId = strAreaId.TrimEnd(",".ToCharArray());

                condition += @" and c.AREAID_CHR in (" + strAreaId + ")";
            }
            //}

            //�տ�Ա����
            bolCheck = this.m_objViewer.m_checkBoxCreater.Checked;
            if (bolCheck == true)
            {
                string strCreaterId;
                strCreaterId = this.m_objViewer.m_textBoxCreater.Text.Trim();

                condition += @" and e.EMPNO_CHR = '" + strCreaterId + "'";

            }

            //סԺ��
            bolCheck = this.m_objViewer.m_checkBoxInPatientId.Checked;
            if (bolCheck == true)
            {
                string strInPatientId;
                strInPatientId = this.m_objViewer.m_textBoxInPatientId.Text.Trim();

                condition += @" and c.INPATIENTID_CHR = '" + strInPatientId + "' ";

            }

            //Ԥ������
            bolCheck = this.m_objViewer.m_checkBoxPrepayInv.Checked;
            if (bolCheck == true)
            {
                string strPrepayInv;
                strPrepayInv = this.m_objViewer.m_textBoxPrepayInv.Text.Trim();

                condition += @" and b.PREPAYINV_VCHR = '" + strPrepayInv + "' ";
            }

            // ֧����ʽ
            if (this.m_objViewer.chkPayType.Checked && this.m_objViewer.cboPayType.SelectedIndex > 0)
            {
                int payTypeId = this.m_objViewer.cboPayType.SelectedIndex;
                if (payTypeId == 4)
                    payTypeId = 8;
                else if (payTypeId == 5)
                    payTypeId = 9;
                condition += @" and b.CUYCATE_INT = " + payTypeId;
            }

            if (condition == "")
            {
                if (strAreaId == "%")
                {
                    //�������ѡ����ȫԺ����û��ѡ���������������ѯ�������ݣ����ǲ����������Ҫ��
                    condition = " and 1=1 ";
                }
                else
                {
                    MessageBox.Show("��ѡ���ѯ��������", "��ʾ");
                    return;
                }
            }

            GetPrepayInfoBy(condition);
        }

        private void GetPrepayInfoBy(string p_strCondition)
        {
            this.m_objViewer.m_dataGridViewRs.Rows.Clear();
            long lngRes = 0;
            DataTable dtPrepayInfo = new DataTable();
            lngRes = m_objDomain.GetPrepayInfoBy(p_strCondition, out dtPrepayInfo);

            if (lngRes > 0 && dtPrepayInfo.Rows.Count > 0)
            {
                DataView dv = new DataView(dtPrepayInfo);
                dv = dtPrepayInfo.DefaultView;

                string strTemp;

                decimal sumMoney = 0;
                string[] s = null;
                int n = -1;
                foreach (DataRowView drv in dv)
                {
                    if (drv["MONEY_DEC"].ToString() != null)
                    {
                        sumMoney += decimal.Parse(drv["MONEY_DEC"].ToString());
                    }

                    s = new string[15];
                    n = -1;

                    //s[0] = i.ToString();
                    s[++n] = drv["INPATIENTID_CHR"].ToString().Trim();
                    s[++n] = drv["LASTNAME_VCHR"].ToString().Trim();
                    s[++n] = drv["SEX_CHR"].ToString().Trim();
                    s[++n] = drv["DEPTNAME_VCHR"].ToString().Trim();
                    s[++n] = drv["CREATE_DAT"].ToString();
                    s[++n] = drv["PREPAYINV_VCHR"].ToString().Trim();
                    s[++n] = drv["REPPRNBILLNO_VCHR"].ToString().Trim();
                    s[++n] = drv["MONEY_DEC"].ToString();

                    strTemp = drv["CUYCATE_INT"].ToString();
                    switch (strTemp)
                    {
                        case "1":
                            strTemp = "�ֽ�";
                            break;
                        case "2":
                            strTemp = "֧Ʊ";
                            break;
                        case "3":
                            strTemp = "���п�";
                            break;
                        case "6":
                            strTemp = "֧����";     // ����.֧����
                            break;
                        case "8":
                            strTemp = "΢��";
                            break;
                        case "9":
                            strTemp = "֧����";     // ����.֧����
                            break;
                        default:
                            strTemp = "΢��2";
                            break;
                    }
                    s[++n] = strTemp;

                    strTemp = drv["PAYTYPE_INT"].ToString();
                    switch (strTemp)
                    {
                        case "1":
                            strTemp = "����";
                            break;
                        case "2":
                            strTemp = "�˷�";
                            break;
                        case "3":
                            strTemp = "�ָ�";
                            break;
                        case "4":
                            strTemp = "�嵥";
                            break;
                        default:
                            strTemp = "";
                            break;
                    }
                    s[++n] = strTemp;
                    s[++n] = drv["CREATER"].ToString().Trim();

                    strTemp = drv["BALANCEFLAG_INT"].ToString();
                    switch (strTemp)
                    {
                        case "0":
                            strTemp = "δ����";
                            break;
                        case "1":
                            strTemp = "�ѽ���";
                            break;
                        default:
                            strTemp = "";
                            break;
                    }
                    s[++n] = strTemp;

                    strTemp = drv["UPTYPE_INT"].ToString();
                    switch (strTemp)
                    {
                        case "0":
                            strTemp = "����";
                            break;
                        case "1":
                            strTemp = "�ֹ�";
                            break;
                        default:
                            strTemp = "";
                            break;
                    }
                    s[++n] = strTemp;
                    s[++n] = drv["CONFIRMEMP"].ToString();
                    s[++n] = drv["PREPAYID_CHR"].ToString();

                    this.m_objViewer.m_dataGridViewRs.Rows.Add(s);
                }

                //��������
                string[] sum = new string[11];
                sum[0] = "��Ʊ������";
                sum[1] = dtPrepayInfo.Rows.Count.ToString();
                sum[5] = "�ܽ��";
                sum[6] = sumMoney.ToString();
                int newRow = this.m_objViewer.m_dataGridViewRs.Rows.Add(sum);

                //if (newRow > 0)
                //{
                //    DataGridViewRow dGridViewRow = new DataGridViewRow();
                //    dGridViewRow = this.m_objViewer.m_dataGridViewRs.Rows[newRow];
                //    Font newFont = new Font();
                //    newFont.Bold = true;

                //    dGridViewRow.Cells[0].Style.Font = newFont;
                //    dGridViewRow.Cells[1].Style.Font = newFont;
                //}

                //���ڴ�ӡ
                this.m_dtPrint = dtPrepayInfo;
                this.m_rptView = new DataView(this.m_dtPrint);

                this.m_objViewer.m_buttonPrint.Enabled = true;
            }
            else
            {
                MessageBox.Show("�����ݣ���������Ĳ�ѯ�������Ƿ���ȷ��", "��ʾ");
                this.m_objViewer.m_buttonPrint.Enabled = false;
                return;
            }

        }

        #region ���벡��
        /// <summary>
        /// ���벡��
        /// </summary>
        public void LoadArea()
        {
            //m_objViewer.lsvAreaInfo.Items.Clear();
            //com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO[] DataResultArr = null;
            //string strFilter = "WHERE ATTRIBUTEID = '0000003' AND STATUS_INT = 1 AND (shortno_chr LIKE '"
            //                   + m_objViewer.m_textBoxArea.Text.ToString().Trim()
            //                   + "%' or DEPTNAME_VCHR like '"
            //                   + m_objViewer.m_textBoxArea.Text.ToString().Trim()
            //                   + "%' or PYCODE_CHR like '"
            //                   + m_objViewer.m_textBoxArea.Text.ToString().Trim()
            //                   + "%' or WBCODE_CHR like '"
            //                   + m_objViewer.m_textBoxArea.Text.ToString().Trim() + "%')";
            //System.Windows.Forms.ListViewItem FindItem;
            //long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfo(strFilter, out DataResultArr);
            //if (lngRes > 0 && DataResultArr.Length > 0)
            //{
            //    #region �ڲ���������һ��ȫԺѡ��
            //    FindItem = new ListViewItem("");
            //    FindItem.SubItems.Add("ȫԺ");
            //    FindItem.Tag = "";
            //    m_objViewer.lsvAreaInfo.Items.Add(FindItem);
            //    #endregion

            //    for (int i = 0; i < DataResultArr.Length; i++)
            //    {
            //        FindItem = new ListViewItem(DataResultArr[i].m_strCODE_VCHR);
            //        FindItem.SubItems.Add(DataResultArr[i].m_strDEPTNAME_VCHR);
            //        FindItem.Tag = DataResultArr[i];
            //        m_objViewer.lsvAreaInfo.Items.Add(FindItem);
            //    }
            //}
        }
        #endregion

        #region ���û��ı���������ֶ�ʱ
        private void ColumnSortModeChanged()
        {
            DataGridViewColumn sortedCol = this.m_objViewer.m_dataGridViewRs.SortedColumn;
            if (sortedCol == null)
            {
                return;
            }

            string sortedColumn = sortedCol.Name.ToString();
            string sortOrder = this.m_objViewer.m_dataGridViewRs.SortOrder.ToString();

            if (sortedColumn != "" && sortOrder != "")
            {
                this.m_rptView = new DataView(m_dtPrint);
                if (sortOrder == "Ascending")
                {
                    this.m_rptView.Sort = sortedColumn + " Asc";
                }
                else
                {
                    this.m_rptView.Sort = sortedColumn + " Desc";
                }
            }
        }
        #endregion

        #region ��ӡ
        /// <summary>
        /// ��ӡ
        /// </summary>
        public void PrintResult()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer view = CreateViewer();
            if (view == null)
            {
                MessageBox.Show("û��ʲô����Ԥ��");
                return;
            }
            System.Windows.Forms.Form frm = new Form();
            frm.Height = 400;

            view.Location = new System.Drawing.Point(0, 0);
            frm.Width = 800;
            frm.Height = 600;
            view.Width = frm.Width;
            view.Height = frm.Height;
            view.DisplayGroupTree = false;

            frm.Text = "��ӡԤ��";
            view.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right | System.Windows.Forms.AnchorStyles.Bottom)));
            frm.Controls.Add(view);
            frm.ShowDialog();
        }

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CreateViewer()
        {
            CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
            crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();

            CrystalDecisions.CrystalReports.Engine.ReportDocument rptDoc =
                new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            //this.m_objViewer.m_dataGridViewRs.DataSource;
            rptDoc.Load(@".\Report\rptPrepay.rpt");
            //rptDoc.DataDefinition.FormulaFields["operatorname"].Text = "'"+this.m_objViewer.LoginInfo.m_strEmpName+"'";
            //rptDoc.DataDefinition.FormulaFields["areaname"].Text = "'" + this.m_objViewer.m_txtAREAID_CHR.Text + "'";
            //rptDoc.DataDefinition.FormulaFields["statdate"].Text = "'"��

            //����
            ColumnSortModeChanged();

            rptDoc.SetDataSource(this.m_rptView);


            //rptDoc.SetDataSource(m_dtPrint);
            //rptDoc.SetDataSource(this.m_objViewer.m_dataGridViewRs.DataSource); 
            crystalReportViewer1.ReportSource = rptDoc;
            return crystalReportViewer1;
        }

        #endregion

        #region �޸�֧������
        public void MondifyCuycate(DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
            {
                return;
            }

            string prepayId = this.m_objViewer.m_dataGridViewRs.Rows[rowIndex].Cells["PREPAYID_CHR"].Value.ToString();
            string cuycate = this.m_objViewer.m_dataGridViewRs.Rows[rowIndex].Cells["CUYCATE_INT"].Value.ToString();

            switch (cuycate)
            {
                case "�ֽ�":
                    cuycate = "1";
                    break;
                case "֧Ʊ":
                    cuycate = "2";
                    break;
                case "���п�":
                    cuycate = "3";
                    break;
                case "֧����":
                    cuycate = "6";
                    break;
                case "΢��":
                    cuycate = "8";
                    break;
                //case "֧����":
                //    cuycate = "9";
                //    break;
                case "΢��2":
                    cuycate = "4";
                    break;
                default:
                    cuycate = "4";
                    break;
            }

            this.m_objDomain.MondifyCuycate(cuycate, prepayId);

        }
        #endregion

        public bool IsAllowModify()
        {
            string setStatus;
            this.m_objDomain.GetSysSetting("1015", out setStatus);

            bool ret;
            if (setStatus == "1")
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }

        #region �ش�Ԥ����Ʊ
        /// <summary>
        /// �ش�Ԥ����Ʊ
        /// </summary>
        internal void RePrintInvoice()
        {
            if (this.m_objViewer.m_dataGridViewRs.SelectedRows.Count == 0)
            {
                MessageBox.Show("��ѡ����Ҫ�ش��Ԥ�����¼��");
                return;
            }

            string prepayId = this.m_objViewer.m_dataGridViewRs.SelectedRows[0].Cells["PREPAYID_CHR"].Value.ToString();
            string preInvoNo = this.m_objViewer.m_dataGridViewRs.SelectedRows[0].Cells["PREPAYINV_VCHR"].Value.ToString();
            string preStatus = this.m_objViewer.m_dataGridViewRs.SelectedRows[0].Cells["PAYTYPE_INT"].Value.ToString();
            if (preStatus == "����" || preStatus == "�ָ�")
            {
                // ����Ԥ��.΢��
                frmPrePayRepeatPrn fpprp = new frmPrePayRepeatPrn(preInvoNo, 0, this.m_objViewer.LoginInfo.m_strEmpID);
                if (fpprp.ShowDialog() == DialogResult.OK)
                {
                    string prntype = fpprp.PrnType;
                    string newno = fpprp.NewNo;
                    if (prntype == "1")
                    {
                        clsPBNetPrint.m_mthPrintPrepayBill(prepayId, "");
                    }
                    else if (prntype == "2")
                    {
                        clsDcl_PrePay dclPrepay = new clsDcl_PrePay();
                        long l = dclPrepay.m_lngSaveRepeatPrn(prepayId, preInvoNo, newno, this.m_objViewer.LoginInfo.m_strEmpID, "1");
                        if (l > 0)
                        {
                            clsPBNetPrint.m_mthPrintPrepayBill(prepayId, newno);
                            clsPublic.m_blnSaveCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, newno, 2);
                            clsPublic.m_blnWriteXML("BeInHospital", "CurrPrepayBillNo", "AnyOne", newno);
                        }
                        else
                        {
                            MessageBox.Show("�����ش���Ϣʧ�ܡ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        }
                        dclPrepay = null;
                    }
                    else if (prntype == "3")
                    {
                        clsPBNetPrint.m_mthPrintPrepayBill(prepayId, newno);
                    }
                }
            }
            else
            {
                MessageBox.Show("�����ش�");
            }
        }
        #endregion
    }
}