using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.IO;
using com.digitalwave.Utility;
using com.digitalwave.iCare.common;
using Sybase.DataWindow;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ҩ������ѯ���Ʋ�
    /// </summary>
    public class clsCtl_StorageSet : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// ҩ������ѯ���Ʋ㹹�췽��
        /// </summary>
        public clsCtl_StorageSet()
        {
            m_objDomain = new clsDcl_StorageSet();
        }

        #region ȫ�ֱ���
        /// <summary>
        /// ģ�������
        /// </summary>
        private clsDcl_StorageSet m_objDomain = null;
        /// <summary>
        /// ����
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmStorageSet m_objViewer;
        /// <summary>
        /// ҩƷ��ѯ�ؼ�
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// ҩ�������Ϣ
        /// </summary>
        private clsValue_StorageBse_VO[] m_objStorageBseArr = null;
        /// <summary>
        /// ҩƷ��������
        /// </summary>
        private clsValue_MedicineType_VO[] m_objMedicineTypeArr = null;
        private clsValue_MedicineType_VO[] objMedicineTypeArr = null;
        /// <summary>
        /// ҩƷ��ϸ���ݱ�
        /// </summary>  
        internal DataTable dtbResult = null;
        /// <summary>
        /// ͳ����Ϣ��ʱ��
        /// </summary>
        private DataTable dtbTem = new DataTable();
        /// <summary>
        /// ȱҩ
        /// </summary>
        private DataTable m_dtbLack = new DataTable();
        /// <summary>
        /// ͣ��
        /// </summary>
        private DataTable m_dtbStop = new DataTable();
        #endregion

        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmStorageSet)frmMDI_Child_Base_in;
        }
        #endregion

        #region ��ʾҩƷ�ֵ���СԪ����Ϣ��ѯ����
        /// <summary>
        /// ��ʾҩƷ�ֵ���СԪ����Ϣ��ѯ����
        /// </summary>
        /// <param name="p_strSearchCon">��ѯ����</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable m_dtMedicineInfo)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_dtMedicineInfo);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedicineCode.Location.X + m_objViewer.gradientPanel1.Location.X;
                Y = m_objViewer.m_txtMedicineCode.Location.Y + m_objViewer.m_txtMedicineCode.Size.Height + m_objViewer.gradientPanel1.Location.Y;

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
            clsPub.m_mthGetMedBaseInfo(m_objViewer.m_strMedStoreArr[0], out m_objViewer.m_dtMedicineInfo);            
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtMedicineInfo;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }
            m_objViewer.m_txtMedicineCode.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedicineCode.Text = MS_VO.m_strMedicineName;
        }
        #endregion

        #region ��ȡҩ�������Ϣ
        /// <summary>
        /// ��ȡҩ�������Ϣ
        /// </summary>
        internal void m_mthShowStorage()
        {
            long lngRes = 0;
            clsValue_StorageBse_VO[] objStorageBseArr = null;
            if (m_objViewer.m_cboStorage.Items.Count == 0)
            {
                try
                {
                    if (m_objViewer.m_strMedStoreArr != null)
                    {
                        m_objDomain.m_lngGetResultByConditionStorageBse(out objStorageBseArr);
                        for (int i = 0; i < objStorageBseArr.Length; i++)
                        {
                            for (int j = 0; j < m_objViewer.m_strMedStoreArr.Length; j++)
                            {
                                if (m_objViewer.m_strMedStoreArr[j].Trim() == objStorageBseArr[i].MEDICINEROOMID)
                                    m_objViewer.m_cboStorage.Item.Add(objStorageBseArr[i].MEDICINEROOMNAME, objStorageBseArr[i].MEDICINEROOMID);
                            }
                        }
                        m_objViewer.m_cboStorage.SelectedIndex = 0;
                    }
                    else
                    {
                        //this.m_cboMedStore.Item.Add(m_dtMedStoreInfo.Rows[i]["MEDSTORENAME_VCHR"].ToString(), m_dtMedStoreInfo.Rows[i]["deptid_chr"].ToString());

                        lngRes = m_objDomain.m_lngGetResultByConditionStorageBse(out objStorageBseArr);

                        if (lngRes > 0)
                        {
                            m_objStorageBseArr = new clsValue_StorageBse_VO[objStorageBseArr.Length];
                            int m_index = 0;
                            for (int i1 = 0; i1 < objStorageBseArr.Length; i1++)
                            {
                                m_index = m_objViewer.m_cboStorage.Items.Add(objStorageBseArr[i1].MEDICINEROOMNAME);
                                m_objStorageBseArr[m_index] = objStorageBseArr[i1];
                            }
                            m_objViewer.m_cboStorage.SelectedIndex = 0;
                        }
                        else
                        {
                            m_objViewer.m_cboStorage.Items.Clear();
                        }
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                int m_index = 0;
                for (int i1 = 0; i1 < objStorageBseArr.Length; i1++)
                {
                    m_index = m_objViewer.m_cboStorage.Items.Add(objStorageBseArr[i1].MEDICINEROOMNAME);
                    m_objStorageBseArr[m_index] = objStorageBseArr[i1];
                }
                m_objViewer.m_cboStorage.SelectedIndex = 0;
            }
        }
        #endregion

        #region ��ȡҩƷ����
        /// <summary>
        /// ��ȡҩƷ����
        /// </summary>
        internal void m_mthShowMedicineType()
        {
            long lngRes = 0;

            m_objViewer.m_cboMedicineType.Items.Clear();
            if ((m_objViewer.m_cboMedicineType.Items.Count >= 0) && (objMedicineTypeArr == null))
            {
                m_objViewer.m_cboMedicineType.Items.Clear();
                try
                {
                    lngRes = m_objDomain.m_lngGetResultByConditionMedicineType(out objMedicineTypeArr);

                    if (lngRes > 0)
                    {
                        m_objMedicineTypeArr = new clsValue_MedicineType_VO[objMedicineTypeArr.Length + 1];
                        m_objViewer.m_cboMedicineType.Items.Add("��������");
                        int m_index = 0;
                        for (int i1 = 0; i1 < objMedicineTypeArr.Length; i1++)
                        {
                            m_index = m_objViewer.m_cboMedicineType.Items.Add(objMedicineTypeArr[i1].m_strMedicineTypeName);
                            m_objMedicineTypeArr[m_index] = objMedicineTypeArr[i1];
                        }
                        m_objViewer.m_cboMedicineType.SelectedIndex = 0;
                    }
                    else
                    {
                        m_objViewer.m_cboMedicineType.Items.Clear();
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "ҩ��������ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }

            }
            else if ((m_objViewer.m_cboMedicineType.Items.Count >= 0) && (objMedicineTypeArr != null))
            {
                m_objViewer.m_cboMedicineType.Items.Add("��������");
                int m_index = 0;
                for (int i1 = 0; i1 < objMedicineTypeArr.Length; i1++)
                {
                    m_index = m_objViewer.m_cboMedicineType.Items.Add(objMedicineTypeArr[i1].m_strMedicineTypeName);
                    m_objMedicineTypeArr[m_index] = objMedicineTypeArr[i1];
                }
                m_objViewer.m_cboMedicineType.SelectedIndex = 0;

            }
        }
        #endregion

        #region ��ȡҩƷ��ϸ����
        /// <summary>
        /// ��ȡҩƷ��ϸ����
        /// ʵ��ͳ�Ʋ�ѯ����ϸ��ѯ���ܡ�
        /// �ɰ�ҩƷ�������롢ƴ���롢����롢ҩƷ��ID��ҩƷ���ƽ���ģ����ѯ
        /// </summary>
        internal void m_mthQuery()
        {
            string m_strStorageID = string.Empty;
            string m_strMedicineID = string.Empty;
            string m_strAssistCode = string.Empty;
            string m_strMedicineTypeID = string.Empty;

            if (m_objViewer.m_cboStorage.Text.Trim().Length == 0)
            {
                MessageBox.Show("����ѡ��ҩ��!", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            long lngRes = 0;
            List<string> lstMedicineType = new List<string>();            

            m_objViewer.m_dgvDrugStorage.DataSource = null;

            if (dtbResult != null)
            {
                dtbResult.Clear();
                dtbResult.Dispose();
                dtbResult = null;
            }



            m_strStorageID = m_objViewer.m_cboStorage.SelectItemValue;
            
            if (m_objViewer.m_txtMedicineCode.Text.Trim().Length > 0)
            {
                if (m_objViewer.m_objMedicineBase.m_strMedicineID.Trim().Length > 0)
                    m_strMedicineID = m_objViewer.m_objMedicineBase.m_strMedicineID.Trim();
                else
                {
                    m_strAssistCode = m_objViewer.m_txtMedicineCode.Text + @"%";
                }
            }
            else
            {
                m_strAssistCode = "";
            }

            //ҩƷ����
            if ((m_objViewer.m_cboMedicineType.Text.Trim().Length > 0) && (m_objViewer.m_cboMedicineType.Text.Trim() != "��������"))
            {
                lstMedicineType.Add(objMedicineTypeArr[m_objViewer.m_cboMedicineType.SelectedIndex - 1].m_strMedicineTypeID);
            }
            else
                m_strMedicineTypeID = "";
            
            dtbResult = new DataTable();//���ݿⷵ�صĽ����

            lngRes = m_objDomain.m_mthGetStorageDetailData(m_strStorageID, m_strMedicineID, m_strAssistCode, m_strMedicineTypeID,
                out dtbResult,lstMedicineType,m_objViewer.m_blnIsHospital);
            if ((lngRes > 0) && (dtbResult != null))
            {
                m_objViewer.m_dgvDrugStorage.DataSource = dtbResult;               
            }
            m_objViewer.m_dtbModify.Rows.Clear();
            m_objViewer.m_dtbModify = dtbResult.Clone();
            m_mthFilterShow();
        }
        #endregion

        internal void m_mthFilterShow()
        {            
            if(dtbResult == null) return;
            DataTable m_dtbTemp = dtbResult.Copy();
            
            DataView dvResult = m_dtbTemp.DefaultView;            

            if (m_objViewer.m_rbtNormal.Checked)
            {
                dvResult.RowFilter = "ifstop_int = 0 and NOQTYFLAG_INT = 0";       
            }
            else if (m_objViewer.m_rbtStop.Checked)
            {
                dvResult.RowFilter = "ifstop_int = 1";
            }
            else if (m_objViewer.m_rbtLack.Checked)
            {
                dvResult.RowFilter = "NOQTYFLAG_INT = 1";
            }

            m_dtbTemp = dvResult.ToTable();
            m_objViewer.m_dgvDrugStorage.DataSource = m_dtbTemp;            
        }

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
                for (int iOr = 0; iOr < m_objViewer.m_dgvDrugStorage.ColumnCount; iOr++)
                {
                    if (m_objViewer.m_dgvDrugStorage.Columns[iOr].Visible == false)
                        continue;
                    if (iOr > 0)
                    {
                        str += "\t";
                    }
                    str += m_objViewer.m_dgvDrugStorage.Columns[iOr].HeaderText.Replace("\n", "");
                }
                sw.WriteLine(str);
                //������ı�
                StringBuilder objStrBuilder = null;
                for (int iOr = 0; iOr < m_objViewer.m_dgvDrugStorage.Rows.Count; iOr++)
                {                    
                    objStrBuilder = new StringBuilder();
                    for (int jOr = 0; jOr < m_objViewer.m_dgvDrugStorage.Columns.Count; jOr++)
                    {
                        if (m_objViewer.m_dgvDrugStorage.Columns[jOr].Visible == false)
                            continue;
                        if (jOr > 0)
                        {
                            objStrBuilder.Append("\t");
                        }
                        if (jOr == 0 || jOr == 1)
                        {
                            objStrBuilder.Append(m_objViewer.m_dgvDrugStorage.Rows[iOr].Cells[jOr].FormattedValue.ToString());
                        }
                        else
                            objStrBuilder.Append(m_objViewer.m_dgvDrugStorage.Rows[iOr].Cells[jOr].Value.ToString());
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

        #region ��ӡ
        /// <summary>
        /// ��ӡ
        /// </summary>
        internal void m_mthPrint()
        {
            return;//������δ�� 

            m_mthQuery();
            DataWindowControl m_dwcDrugQuery = new DataWindowControl();
            m_dwcDrugQuery.LibraryList = Application.StartupPath + "\\PB_OP.pbl";            
            m_dwcDrugQuery.DataWindowObject = "d_op_drugquerydetail";

            //datWindow.Modify("t_tile.text = '" + base.m_objComInfo.m_strGetHospitalTitle() + "(" + p_strStorageName + ")'");
            m_dwcDrugQuery.SetRedrawOff();            
            m_dwcDrugQuery.Retrieve(dtbResult);            
            m_dwcDrugQuery.Refresh();
            m_dwcDrugQuery.SetRedrawOn();
            m_dwcDrugQuery.Modify("t_storename.text = 'ҩ����" + m_objViewer.m_cboStorage.Text + "'");
            m_dwcDrugQuery.Modify("t_drugtypename.text = 'ҩƷ���ͣ�" + m_objViewer.m_cboMedicineType.Text + "'");
            com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(m_dwcDrugQuery);
        }
        #endregion

        #region ��ѡ��
        /// <summary>
        /// ��ѡ��
        /// </summary>
        internal void m_mthBindOption()
        {
            try
            {
                m_dtbLack.Columns.Add("NOQTYFLAG_INT",typeof(Int16));
                m_dtbLack.Columns.Add("noquatityname_vchr",typeof(string));
                DataRow dr = m_dtbLack.NewRow();
                dr["NOQTYFLAG_INT"] = 0;
                dr["noquatityname_vchr"] = "��ҩ";
                m_dtbLack.Rows.Add(dr);
                dr = m_dtbLack.NewRow();
                dr["NOQTYFLAG_INT"] = 1;
                dr["noquatityname_vchr"] = "ȱҩ";
                m_dtbLack.Rows.Add(dr);

                m_objViewer.colNoQuality.DataSource = m_dtbLack;
                m_objViewer.colNoQuality.ValueMember = "NOQTYFLAG_INT";
                m_objViewer.colNoQuality.DisplayMember = "noquatityname_vchr";

                m_dtbStop.Columns.Add("ifstop_int", typeof(Int16));
                m_dtbStop.Columns.Add("ifstopname_vchr", typeof(string));
                DataRow dr2 = m_dtbStop.NewRow();
                dr2["ifstop_int"] = 0;
                dr2["ifstopname_vchr"] = "����";
                m_dtbStop.Rows.Add(dr2);
                dr2 = m_dtbStop.NewRow();
                dr2["ifstop_int"] = 1;
                dr2["ifstopname_vchr"] = "ͣ��";
                m_dtbStop.Rows.Add(dr2);

                m_objViewer.colStop.DataSource = m_dtbStop;
                m_objViewer.colStop.ValueMember = "ifstop_int";
                m_objViewer.colStop.DisplayMember = "ifstopname_vchr";

            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "���س���", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }           
        }
        #endregion

        #region ����ȱҩ��ͣ��,����
        internal long m_lngSaveStorageSet(DataTable p_dtbModify)
        {
            long lngRes = 0;

            if (p_dtbModify.Rows.Count > 0)
            {
                try
                {
                    lngRes = m_objDomain.m_lngSaveStorageSet(p_dtbModify);

                    if (lngRes > 0)
                    {
                        //MessageBox.Show("�����޸���ϣ�", "ע��...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return lngRes;
        }
        #endregion

        #region �Ƿ�סԺҩ��
        /// <summary>
        /// �Ƿ�סԺҩ��
        /// </summary>
        /// <param name="p_strStorageid"></param>
        /// <param name="p_blnIsHospital"></param>
        internal long m_lngCheckIsHospital(string p_strStorageid, out bool p_blnIsHospital)
        {
            clsDcl_AskForMedicine objDom = new clsDcl_AskForMedicine();
            return objDom.m_lngCheckIsHospital(p_strStorageid, out p_blnIsHospital);
        }
        #endregion
    }
}
