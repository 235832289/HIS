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
using System.Data.OleDb;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ҩ������ѯ���Ʋ�
    /// </summary>
    public class clsCtl_DrugStorageQuery : com.digitalwave.GUI_Base.clsController_Base
    {
        /// <summary>
        /// ҩ������ѯ���Ʋ㹹�췽��
        /// </summary>
        public clsCtl_DrugStorageQuery()
        {            
            m_objDomain = new clsDcl_DrugStorageQuery();
        }

        #region ȫ�ֱ���
        /// <summary>
        /// ģ�������
        /// </summary>
        private clsDcl_DrugStorageQuery m_objDomain = null;
        /// <summary>
        /// ����
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmDrugStorageQuery m_objViewer;
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
        /// ��ѯҩƷ��Ϣ
        /// </summary>
        private clsStorageDetail_SqlConditionQueryParam_VO m_value_Param = new clsStorageDetail_SqlConditionQueryParam_VO();
        /// <summary>
        /// ҩƷ��ϸ���ݱ�
        /// </summary>  
        internal DataTable dtbResult = null;
        /// <summary>
        /// ͳ����Ϣ
        /// </summary>
        private clsStorageDetail_Stat_VO m_objStatValue = new clsStorageDetail_Stat_VO();
        /// <summary>
        /// ͳ����Ϣ��ʱ��
        /// </summary>
        private DataTable dtbTem = new DataTable();
        /// <summary>
        /// ����
        /// </summary>
        private DataTable m_dtbStorageRack = new DataTable();
        
        /// <summary>
        /// 20080701 ����סԺҩ������ѯ
        /// </summary>
        bool m_blnIsHospital = false;
        
        #endregion

        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmDrugStorageQuery)frmMDI_Child_Base_in;
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
            clsPub.m_mthGetMedBaseInfo(m_objViewer.m_cboStorage.SelectItemValue, out m_objViewer.m_dtMedicineInfo);
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

            m_objViewer.m_blnFound = false;
            m_objViewer.fqn_OnLocateMedicine(MS_VO.m_strMedicineName, 1);
            if (m_objViewer.m_blnFound == false)
            {
                m_objViewer.m_btnQuery.PerformClick();
                m_objViewer.m_blnFound = false;
                m_objViewer.blnRestart = true;
                m_objViewer.fqn_OnLocateMedicine(MS_VO.m_strMedicineName, 1);
                if(m_objViewer.m_blnFound == false)
                    MessageBox.Show("��ǰ��ѯ����û�д�ҩƷ�Ŀ����������޸Ĳ�ѯ������", "��ܰ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.blnRestart = false;
            }
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
                    MessageBox.Show(objEx.Message, "ҩ����ѯ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
                    MessageBox.Show(objEx.Message, "ҩ����ѯ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
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
            m_objViewer.Text = "ҩ������ѯ(" + m_objViewer.m_cboStorage.Text + ")";
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
            if (m_objViewer.m_cboStorage.Text.Trim().Length == 0)
            {
                MessageBox.Show("����ѡ��ҩ��!", "����", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                m_value_Param.m_strStorageName = m_objViewer.m_cboStorage.SelectItemText;

            if (m_objViewer.m_datBeginDate.Text.Trim().Length < 11)
                m_objViewer.m_datBeginDate.Text = "";
            if (m_objViewer.m_datEndDate.Text.Trim().Length < 11)
                m_objViewer.m_datEndDate.Text = "";

            if (this.m_objViewer.m_chkValidDate.Checked&&(m_objViewer.m_datBeginDate.Text.Trim().Length == 11) && (m_objViewer.m_datEndDate.Text.Trim().Length == 11))
            {
                if ((Convert.ToDateTime(m_objViewer.m_datBeginDate.Text)) > (Convert.ToDateTime(m_objViewer.m_datEndDate.Text)))
                {
                    DialogResult tmpResult = MessageBox.Show("ʧЧ��ʼ���ڱ���С��ʧЧ�������ڣ�", "����", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    m_objViewer.m_datBeginDate.Focus();
                    return;
                }
            }

            long lngRes = 0;
            List<string> lstMedicineType = new List<string>();

            m_value_Param.m_strStorageID = "";
            m_value_Param.m_strMedicineTypeID = "";
            m_value_Param.m_strMedicineID = "";
            m_value_Param.m_strValidBeginDate = "";
            m_value_Param.m_strValidEndDate = "";
            m_value_Param.m_strAssistCode = "";
            m_value_Param.m_blnZeroGross = false;

            m_objViewer.m_dgvDrugStorage.DataSource = null;
            m_objViewer.intRecordCount = 0;
            m_objViewer.displayRecordNo();

            if (dtbResult != null)
            {
                dtbResult.Clear();
                dtbResult.Dispose();
                dtbResult = null;
            }

            
            m_objDomain.m_lngCheckIsHospital(m_objViewer.m_cboStorage.SelectItemValue, out m_blnIsHospital);


            m_objViewer.m_mthInitDataTable(m_blnIsHospital);
            m_value_Param.m_strStorageID = m_objViewer.m_cboStorage.SelectItemValue;
            if (this.m_objViewer.m_chkValidDate.Checked&&m_objViewer.m_datBeginDate.Text.Trim().Length == 11)
            {
                string strDate = m_objViewer.m_datBeginDate.Text;
                m_value_Param.m_strValidBeginDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd");
            }
            if (this.m_objViewer.m_chkValidDate.Checked&&m_objViewer.m_datEndDate.Text.Trim().Length == 11)
            {
                string strDate = m_objViewer.m_datEndDate.Text;
                m_value_Param.m_strValidEndDate = Convert.ToDateTime(strDate).ToString("yyyy-MM-dd");
            }

            if (m_objViewer.m_txtMedicineCode.Text.Trim().Length > 0)
            {
                if (m_objViewer.m_objMedicineBase.m_strMedicineID.Trim().Length > 0)
                    m_value_Param.m_strMedicineID = m_objViewer.m_objMedicineBase.m_strMedicineID.Trim();
                else
                {
                    m_value_Param.m_strAssistCode = m_objViewer.m_txtMedicineCode.Text + @"%";
                }
            }
            else
            {
                m_value_Param.m_strAssistCode = "";
            }

            //ҩƷ����
            if ((m_objViewer.m_cboMedicineType.Text.Trim().Length > 0) && (m_objViewer.m_cboMedicineType.Text.Trim() != "��������"))
            {                
               lstMedicineType.Add(objMedicineTypeArr[m_objViewer.m_cboMedicineType.SelectedIndex-1].m_strMedicineTypeID); 
            }
            else
                m_value_Param.m_strMedicineTypeID = "";

            m_value_Param.m_blnZeroGross = true;// radZeroStorage.Checked;
            dtbResult = new DataTable();//���ݿⷵ�صĽ����
            //com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objTypeVO = m_objViewer.m_cboMediciePreptype.SelectedItem as com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO;
            com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[] objTypeVOArr = new com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[m_objViewer.m_lsbMediciePreptype.SelectedItems.Count];
            for (int i1 = 0; i1 < m_objViewer.m_lsbMediciePreptype.SelectedItems.Count; i1++)
            {
                objTypeVOArr[i1] = (com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO)m_objViewer.m_lsbMediciePreptype.SelectedItems[i1];
            }

            lngRes = m_mthGetStorageDetailData(ref m_value_Param, out dtbResult, ref m_objStatValue, lstMedicineType, m_objViewer.m_rdbTotal.Checked, m_objViewer.m_txtProductor.Text.Trim(), objTypeVOArr);
            if ((lngRes > 0) && (dtbResult != null))
            {
                m_objViewer.m_dgvDrugStorage.DataSource = dtbResult;
                m_objViewer.intRecordCount = dtbResult.Rows.Count;
                m_objViewer.displayRecordNo();

                m_objViewer.m_lblCallSum.Text = m_objStatValue.m_decCallSumTotal.ToString("#,##0.0000");//������
                m_objViewer.m_lblRetailSum.Text = m_objStatValue.m_decRetailSumTotal.ToString("#,##0.0000");//���۽��
                //m_objViewer.m_lblWholesaleSum.Text = m_objStatValue.m_decWholesaleSumTotal.ToString("#,##0.00");//�������
            }

            string strFilter = string.Empty;
            if (m_objViewer.m_rdbNotZero.Checked)
            {
                if (dtbResult.Rows.Count > 0)
                {
                    strFilter = "realgross_int <> 0";
                    if (m_objViewer.m_rbtCanProvide.Checked)
                    {
                        strFilter += " and canprovide_int = 1";
                    }
                    else if (m_objViewer.m_rbtNotProvide.Checked)
                    {
                        strFilter += " and canprovide_int = 0";
                    }

                    DataRow[] rows = dtbResult.Select(strFilter);
                    dtbTem = dtbResult.Clone();
                    for (int intRow = 0; intRow < rows.Length; intRow++)
                    {
                        dtbTem.Rows.Add(rows[intRow].ItemArray);
                    }
                    m_objViewer.m_dgvDrugStorage.DataSource = dtbTem;
                    m_objViewer.intRecordCount = dtbTem.Rows.Count;
                    m_objViewer.displayRecordNo();
                }
                else
                {
                    dtbTem = dtbResult.Copy();
                    m_objViewer.m_dgvDrugStorage.DataSource = dtbTem;
                    m_objViewer.intRecordCount = dtbTem.Rows.Count;
                    m_objViewer.displayRecordNo();
                }
            }
            else
            {
                if (dtbResult.Rows.Count > 0)
                {                    
                    if (m_objViewer.m_rdbZero.Checked)
                    {
                        strFilter = "realgross_int = 0";
                    }
                    else if(m_objViewer.m_rbtNegative.Checked)
                    {
                        strFilter = "realgross_int < 0";
                    }

                    if (m_objViewer.m_rbtCanProvide.Checked)
                    {
                        if (strFilter.Length == 0)
                            strFilter += "canprovide_int = 1";
                        else
                            strFilter += " and canprovide_int = 1";
                    }
                    else if (m_objViewer.m_rbtNotProvide.Checked)
                    {
                        if (strFilter.Length == 0)
                            strFilter += "canprovide_int = 0";
                        else
                            strFilter += " and canprovide_int = 0";
                    }

                    DataRow[] rows = dtbResult.Select(strFilter);                  
                    dtbTem = dtbResult.Clone();
                    for (int intRow = 0; intRow < rows.Length; intRow++)
                    {
                        dtbTem.Rows.Add(rows[intRow].ItemArray);
                    }
                    m_objViewer.m_dgvDrugStorage.DataSource = dtbTem;
                    m_objViewer.intRecordCount = dtbTem.Rows.Count;
                    m_objViewer.displayRecordNo();
                }
                else
                {
                    dtbTem = dtbResult.Copy();
                    m_objViewer.m_dgvDrugStorage.DataSource = dtbTem;
                    m_objViewer.intRecordCount = dtbTem.Rows.Count;
                    m_objViewer.displayRecordNo();
                }
            }

            m_objViewer.m_dtbAmount.Rows.Clear();
            m_objViewer.m_dtbAmount = dtbResult.Clone();
        }
        #endregion
        
        #region ��ȡ�����ϸ����
        /// <summary>
        /// ��ȡ�����ϸ����
        /// </summary>
        /// <param name="objvalue_Param">��ѯ����</param>
        /// <param name="dtbResult">���صĽ����</param>
        /// <param name="m_objStatValue">ͳ������</param>
        /// <param name="lstMedicineType"></param>
        /// <param name="blnQueryFlag">��ѯ��־</param>
        /// <param name="p_strProductor">��������</param>
        /// <param name="p_objPrepTypeArr">����</param>
        /// <returns></returns>
        public long m_mthGetStorageDetailData(ref clsStorageDetail_SqlConditionQueryParam_VO objvalue_Param, out DataTable dtbResult, ref clsStorageDetail_Stat_VO m_objStatValue, List<string> lstMedicineType, bool blnQueryFlag,string p_strProductor,clsMEDICINEPREPTYPE_VO[] p_objPrepTypeArr)
        {
            long lngRes = 0;
            try
            {
                m_objStatValue.m_decCallSumTotal = 0;
                m_objStatValue.m_decRetailSumTotal = 0;
                m_objStatValue.m_decWholesaleSumTotal = 0;

                DataTable Query_dtbResult = new DataTable();//���ݿⷵ�صĽ����

                lngRes = m_objDomain.m_lngGetResultByConditionStorageDetail(ref objvalue_Param, lstMedicineType, ref Query_dtbResult, p_strProductor, p_objPrepTypeArr);
                
                if (lngRes > 0)
                {
                    DataColumn[] dcPrimaryKeyArr = new DataColumn[1];
                    dcPrimaryKeyArr[0] = Query_dtbResult.Columns["seriesid_int"];
                    Query_dtbResult.PrimaryKey = dcPrimaryKeyArr;
                    //DataColumn[] dcPrimaryKeyArr = new DataColumn[1];
                    //DataColumn dcPrimaryKey = new DataColumn();
                    //dcPrimaryKey.DataType = System.Type.GetType("System.Int64");
                    //dcPrimaryKey.ColumnName = "seriesid_int";

                    DataTable Stat_dtbResult = new DataTable();//��������ɵ�ͳ�Ʊ�

                    DataRow[] drArr = null;
                    //ͳ�Ʋ�ѯ
                    if (blnQueryFlag == true)
                    {
                        m_GroupSum(objvalue_Param.m_strStorageName, ref Query_dtbResult, ref Stat_dtbResult, ref m_objStatValue);
                        drArr=Stat_dtbResult.Select("","assistcode_chr");//,DataViewRowState.CurrentRows,lotno_vchr"
                        dtbResult = Stat_dtbResult.Clone();
                        for(int i1 = 0;i1< drArr.Length;i1++)
                        {
                            dtbResult.Rows.Add(drArr[i1].ItemArray);
                        }
                        Query_dtbResult = null;
                    }
                    else//��ϸ��ѯ
                    {
                        m_DetailQuery(objvalue_Param.m_strStorageName, ref Query_dtbResult, ref m_objStatValue);
                        drArr = Query_dtbResult.Select("", "assistcode_chr,lotno_vchr");
                        Query_dtbResult.PrimaryKey = null;
                        dtbResult = Query_dtbResult.Clone();
                        for (int i1 = 0; i1 < drArr.Length; i1++)
                        {
                            dtbResult.Rows.Add(drArr[i1].ItemArray);
                        }
                        //dtbResult = Query_dtbResult;
                    }
                    dtbResult.AcceptChanges();
                }
                else
                    dtbResult = null;

                return lngRes;
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "ҩ����ѯ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            dtbResult = null;
            return lngRes;

        }
        #endregion

        #region ��ϸ��ѯ����
        /// <summary>
        /// ��ϸ��ѯ����
        /// </summary>
        /// <param name="strMedicineStorageName">ҩ��</param>
        /// <param name="Query_dtbResult">��ʼ�Ľ����</param>
        /// <param name="m_objStatValue">������ͳ�Ʊ�</param>
        private void m_DetailQuery(string strMedicineStorageName, ref DataTable Query_dtbResult, ref clsStorageDetail_Stat_VO m_objStatValue)
        {
            DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEROOMNAME"), new DataColumn("retailsum", typeof(double)), new DataColumn("wholesalesum", typeof(double)) };
            Query_dtbResult.Columns.AddRange(drColumns);

            decimal m_decDBRealGross = 0;//�������¼�е�ʵ�ʿ��
            decimal m_decRetailPrice = 0;//����е����۵���
            decimal m_decWholesalePrice = 0;//����еĹ��뵥��
            decimal m_decWholesaleSum = 0;//ͳ�Ʊ��еĹ�����
            decimal m_decRetailSum = 0;//ͳ�Ʊ��е����۽��
            decimal m_decPackQty = 1;//��װ��λ
            DataRow m_dtbResultRow = null;

            m_objStatValue.m_decCallSumTotal = 0;
            m_objStatValue.m_decRetailSumTotal = 0;
            m_objStatValue.m_decWholesaleSumTotal = 0;

            for (int i1 = 0; i1 < Query_dtbResult.Rows.Count; i1++)
            {
                m_dtbResultRow = Query_dtbResult.Rows[i1];

                decimal.TryParse(m_dtbResultRow["IPREALGROSS_INT"].ToString(), out m_decDBRealGross);
                decimal.TryParse(m_dtbResultRow["opretailprice_int"].ToString(), out m_decRetailPrice);
                decimal.TryParse(m_dtbResultRow["opwholesaleprice_int"].ToString(), out m_decWholesalePrice);
                decimal.TryParse(m_dtbResultRow["packqty_dec"].ToString(), out m_decPackQty);
                if (m_decPackQty == 0) m_decPackQty = 1;

                m_decWholesaleSum = m_decDBRealGross * m_decWholesalePrice / m_decPackQty;
                m_decRetailSum = m_decDBRealGross * m_decRetailPrice / m_decPackQty;

                m_dtbResultRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                m_dtbResultRow["retailsum"] = m_decRetailSum;
                m_dtbResultRow["wholesalesum"] = m_decWholesaleSum;

                m_objStatValue.m_decCallSumTotal += m_decWholesaleSum;
                m_objStatValue.m_decRetailSumTotal += m_decRetailSum;

                m_dtbResultRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                m_dtbResultRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();
            }
        }
        #endregion

        #region ����ͳ�ƺ���
        /// <summary>
        /// ����ͳ������
        /// ����ҩƷID��MEDICINEID_CHR�����з���ͳ�ƣ�ҩƷID��ͬ�ļ�¼��Ϊһ�顣
        /// ��ÿ��ġ�ʵ�ʿ�桱�������ÿ�桱����������������۽�����������������ͼ��㡣
        /// ��ÿ���ͳ������д�����յ�ͳ�Ʊ�ͳ�Ʊ��С����뵥�ۡ��������۵��ۡ������������ۡ�����ƽ���۸�
        /// </summary>
        /// <param name="dtbResult">��ʼ�Ľ����</param>
        /// <param name="tmp_dtbResult">������ͳ�Ʊ�</param>
        private void m_GroupSum(string strMedicineStorageName, ref DataTable dtbResult, ref DataTable tmp_dtbResult, ref clsStorageDetail_Stat_VO m_objStatValue)
        {
            DataRow m_newRow = null, m_dtbResultRow = null;

            int i1;
            string m_strMedicineID = string.Empty;//���ڷ����ҩƷID
            string m_strDBMedicineID = string.Empty;//������б�ɸѡ��ҩƷID
            decimal m_decRealGrossSum = 0;//ÿ���ʵ�ʿ��ϼ�
            decimal m_decAvailGrossSum = 0;//ÿ��Ŀ��ÿ��ϼ�
            decimal m_decDBRealGross = 0;//�������¼�е�ʵ�ʿ��
            decimal m_decDBAvailGross = 0;//�������¼�еĿ��ÿ��
            decimal m_decEndamount = 0;
            decimal m_decCallSum = 0;//ͳ�Ʊ��еĹ�����
            decimal m_decRetailSum = 0;//ͳ�Ʊ��е����۽��
            decimal m_decWholesaleSum = 0;//ͳ�Ʊ��е��������
            decimal m_decCallPrice = 0;//ͳ�Ʊ��еĹ���ƽ������
            decimal m_decRetailPrice = 0;//ͳ�Ʊ��е�����ƽ������
            decimal m_decWholesalePrice = 0;//ͳ�Ʊ��е�����ƽ������
            decimal m_decPackQty = 1;//��װ��λ
            decimal m_decIPRealGrossSum = 0;//ÿ�����Сʵ�ʿ��ϼ�
            decimal m_decIPAvailGrossSum = 0;//ÿ�����С���ÿ��ϼ�
            decimal m_decDBIPRealGross = 0;//�������¼�е���Сʵ�ʿ��
            decimal m_decDBIPAvailGross = 0;//�������¼�е���С���ÿ��
            decimal m_decRealGross = 0;//����ʵ����
            decimal m_decAvailGross = 0;//���������
            decimal m_decDBRealGrossSum = 0;//������λʵ����
            decimal m_decDBAvailGrossSum = 0;//������λ������
            m_objStatValue.m_decCallSumTotal = 0;
            m_objStatValue.m_decRetailSumTotal = 0;
            m_objStatValue.m_decWholesaleSumTotal = 0;

            if (dtbResult.Rows.Count <= 1)
            {
                tmp_dtbResult = dtbResult.Copy();
                tmp_dtbResult.PrimaryKey = null;
                DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEROOMNAME"), new DataColumn("WHOLESALESUM", typeof(double)), new DataColumn("retailsum", typeof(double)) };
                tmp_dtbResult.Columns.AddRange(drColumns);

                if (dtbResult.Rows.Count == 1)
                {
                    m_dtbResultRow = tmp_dtbResult.Rows[0];

                    decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decRealGross);
                    decimal.TryParse(m_dtbResultRow["AVAILAGROSS_INT"].ToString(), out m_decAvailGross);
                    decimal.TryParse(m_dtbResultRow["OPREALGROSS_INT"].ToString(), out m_decDBRealGross);
                    decimal.TryParse(m_dtbResultRow["OPAVAILAGROSS_INT"].ToString(), out m_decDBAvailGross);
                    decimal.TryParse(m_dtbResultRow["IPREALGROSS_INT"].ToString(), out m_decDBIPRealGross);
                    decimal.TryParse(m_dtbResultRow["IPAVAILAGROSS_INT"].ToString(), out m_decDBIPAvailGross);
                    decimal.TryParse(m_dtbResultRow["packqty_dec"].ToString(), out m_decPackQty);
                    if (m_decPackQty == 0) m_decPackQty = 1;
                    decimal.TryParse(m_dtbResultRow["opretailprice_int"].ToString(), out m_decRetailPrice);
                    decimal.TryParse(m_dtbResultRow["opwholesaleprice_int"].ToString(), out m_decWholesalePrice);

                    m_decCallSum = m_decDBIPRealGross * m_decWholesalePrice / m_decPackQty;
                    m_decRetailSum = m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;

                    m_dtbResultRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                    m_dtbResultRow["WHOLESALESUM"] = m_decCallSum;
                    m_dtbResultRow["retailsum"] = m_decRetailSum;

                    m_objStatValue.m_decCallSumTotal += m_decCallSum;
                    m_objStatValue.m_decRetailSumTotal += m_decRetailSum;

                    m_dtbResultRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                    m_dtbResultRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();
                }
            }
            else if (dtbResult.Rows.Count > 1)
            {
                tmp_dtbResult = dtbResult.Clone();
                tmp_dtbResult.PrimaryKey = null;

                DataColumn[] drColumns = new DataColumn[] { new DataColumn("MEDICINEROOMNAME"), new DataColumn("retailsum", typeof(double)), new DataColumn("wholesalesum", typeof(double)) };
                tmp_dtbResult.Columns.AddRange(drColumns);

                m_dtbResultRow = dtbResult.Rows[0];

                m_strMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString().Trim();
                decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decRealGross);
                decimal.TryParse(m_dtbResultRow["AVAILAGROSS_INT"].ToString(), out m_decAvailGross);
                decimal.TryParse(m_dtbResultRow["OPREALGROSS_INT"].ToString(), out m_decDBRealGross);
                decimal.TryParse(m_dtbResultRow["OPAVAILAGROSS_INT"].ToString(), out m_decDBAvailGross);
                decimal.TryParse(m_dtbResultRow["IPREALGROSS_INT"].ToString(), out m_decDBIPRealGross);
                decimal.TryParse(m_dtbResultRow["IPAVAILAGROSS_INT"].ToString(), out m_decDBIPAvailGross);
                decimal.TryParse(m_dtbResultRow["packqty_dec"].ToString(), out m_decPackQty);
                if (m_decPackQty == 0) m_decPackQty = 1;
                decimal.TryParse(m_dtbResultRow["opretailprice_int"].ToString(), out m_decRetailPrice);
                decimal.TryParse(m_dtbResultRow["opwholesaleprice_int"].ToString(), out m_decWholesalePrice);

                m_decRealGrossSum = m_decRealGross;
                m_decAvailGrossSum = m_decAvailGross;
                m_decDBRealGrossSum = m_decDBRealGross;
                m_decDBAvailGrossSum = m_decDBAvailGross;
                m_decIPRealGrossSum = m_decDBIPRealGross;
                m_decIPAvailGrossSum = m_decDBIPAvailGross;

                m_decCallSum = m_decDBIPRealGross * m_decWholesalePrice / m_decPackQty;
                m_decRetailSum = m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;

                m_objStatValue.m_decCallSumTotal += m_decCallSum;
                m_objStatValue.m_decRetailSumTotal += m_decRetailSum;

                m_dtbResultRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                m_dtbResultRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();

                decimal dcmEndAmountTemp = 0m;
                for (i1 = 1; i1 < dtbResult.Rows.Count; i1++)
                {//����
                    m_dtbResultRow = dtbResult.Rows[i1];

                    //С��
                    m_strDBMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString().Trim();

                    decimal.TryParse(m_dtbResultRow["REALGROSS_INT"].ToString(), out m_decRealGross);
                    decimal.TryParse(m_dtbResultRow["AVAILAGROSS_INT"].ToString(), out m_decAvailGross);
                    decimal.TryParse(m_dtbResultRow["OPREALGROSS_INT"].ToString(), out m_decDBRealGross);
                    decimal.TryParse(m_dtbResultRow["OPAVAILAGROSS_INT"].ToString(), out m_decDBAvailGross);
                    decimal.TryParse(m_dtbResultRow["IPREALGROSS_INT"].ToString(), out m_decDBIPRealGross);
                    decimal.TryParse(m_dtbResultRow["IPAVAILAGROSS_INT"].ToString(), out m_decDBIPAvailGross);
                    decimal.TryParse(m_dtbResultRow["packqty_dec"].ToString(), out m_decPackQty);
                    if (m_decPackQty == 0) m_decPackQty = 1;
                    decimal.TryParse(m_dtbResultRow["opretailprice_int"].ToString(), out m_decRetailPrice);
                    decimal.TryParse(m_dtbResultRow["opwholesaleprice_int"].ToString(), out m_decWholesalePrice);

                    //�������յĺϼƽ��
                    m_objStatValue.m_decCallSumTotal += m_decDBIPRealGross * m_decWholesalePrice / m_decPackQty;
                    m_objStatValue.m_decRetailSumTotal += m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;

                    if (m_strMedicineID == m_strDBMedicineID)
                    {
                        m_decRealGrossSum += m_decRealGross;
                        m_decAvailGrossSum += m_decAvailGross;
                        m_decDBRealGrossSum += m_decDBRealGross;
                        m_decDBAvailGrossSum += m_decDBAvailGross;
                        m_decIPRealGrossSum += m_decDBIPRealGross;
                        m_decIPAvailGrossSum += m_decDBIPAvailGross;
                        m_decCallSum += m_decDBIPRealGross * m_decCallPrice / m_decPackQty;
                        m_decRetailSum += m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;
                    }//С��
                    else
                    {
                        m_dtbResultRow = dtbResult.Rows[i1 - 1];

                        m_newRow = tmp_dtbResult.NewRow();

                        m_newRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                        m_newRow["ASSISTCODE_CHR"] = m_dtbResultRow["ASSISTCODE_CHR"];//������
                        m_newRow["MEDICINENAME_VCHR"] = m_dtbResultRow["MEDICINENAME_VCHR"];//ҩƷ����
                        m_newRow["MEDSPEC_VCHR"] = m_dtbResultRow["MEDSPEC_VCHR"];//���
                        m_newRow["LOTNO_VCHR"] = m_dtbResultRow["LOTNO_VCHR"];//����
                        m_newRow["MEDICINETYPENAME_VCHR"] = m_dtbResultRow["MEDICINETYPENAME_VCHR"];//ҩƷ��������
                        m_newRow["REALGROSS_INT"] = m_decRealGrossSum;//ʵ�ʿ��
                        m_newRow["AVAILAGROSS_INT"] = m_decAvailGrossSum;//���ÿ��
                        m_newRow["OPREALGROSS_INT"] = m_decDBRealGrossSum;//����ʵ�ʿ��
                        m_newRow["OPAVAILAGROSS_INT"] = m_decDBAvailGrossSum;//�������ÿ��
                        m_newRow["IPREALGROSS_INT"] = m_decIPRealGrossSum;//��Сʵ�ʿ��
                        m_newRow["IPAVAILAGROSS_INT"] = m_decIPAvailGrossSum;//��С���ÿ��                        
                        m_newRow["storagerackid_chr"] = m_dtbResultRow["storagerackid_chr"];//����
                        m_newRow["unit_chr"] = m_dtbResultRow["unit_chr"].ToString().Trim();
                        m_newRow["ifstop_int"] = m_dtbResultRow["ifstop_int"];
                        m_newRow["noqtyflag_int"] = m_dtbResultRow["noqtyflag_int"];
                        m_newRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                        m_newRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();
                        m_newRow["productorid_chr"] = m_dtbResultRow["productorid_chr"];
                        m_newRow["pycode_chr"] = m_dtbResultRow["pycode_chr"];
                        m_newRow["wbcode_chr"] = m_dtbResultRow["wbcode_chr"];

                        /*if (m_decIPRealGrossSum == 0)
                            m_newRow["RETAILPRICE_INT"] = 0;//���۵���
                        else
                            m_newRow["RETAILPRICE_INT"] = m_decRetailSum / m_decIPRealGrossSum;//���۵���

                        if (m_decIPRealGrossSum == 0)
                            m_newRow["WHOLESALEPRICE_INT"] = 0;//���뵥��
                        else
                            m_newRow["WHOLESALEPRICE_INT"] = m_decCallSum / m_decIPRealGrossSum;//���뵥��
                        */
                        m_newRow["RETAILPRICE_INT"] = m_dtbResultRow["retailprice_int"];
                        m_newRow["WHOLESALEPRICE_INT"] = m_dtbResultRow["wholesaleprice_int"];

                        m_newRow["WHOLESALESUM"] = m_decCallSum;//������
                        m_newRow["RETAILSUM"] = m_decRetailSum;//���۽��
                        m_newRow["VALIDPERIOD_DAT"] = m_dtbResultRow["VALIDPERIOD_DAT"];//ʧЧ����
                        m_newRow["MEDICINEPREPTYPENAME_VCHR"] = m_dtbResultRow["MEDICINEPREPTYPENAME_VCHR"];//ҩƷ����
                        m_newRow["seriesid_int"] = m_dtbResultRow["seriesid_int"];
                        
                        //��������
                        tmp_dtbResult.Rows.Add(m_newRow);
                        m_newRow.AcceptChanges();

                        m_dtbResultRow = dtbResult.Rows[i1];

                        m_strMedicineID = m_dtbResultRow["MEDICINEID_CHR"].ToString();
                        //����m_decRealGrossSum��m_decAvailGrossSum��
                        m_decRealGrossSum = m_decRealGross;
                        m_decAvailGrossSum = m_decAvailGross;
                        m_decDBRealGrossSum = m_decDBRealGross;
                        m_decDBAvailGrossSum = m_decDBAvailGross;
                        m_decIPRealGrossSum = m_decDBIPRealGross;
                        m_decIPAvailGrossSum = m_decDBIPAvailGross;

                        m_decCallSum = m_decDBIPRealGross * m_decWholesalePrice / m_decPackQty;
                        m_decRetailSum = m_decDBIPRealGross * m_decRetailPrice / m_decPackQty;

                        m_decEndamount = dcmEndAmountTemp;

                    }//else
                    //�������һ����¼
                    if (i1 == dtbResult.Rows.Count - 1)
                    {
                        m_dtbResultRow = dtbResult.Rows[i1];

                        m_newRow = tmp_dtbResult.NewRow();

                        m_newRow["MEDICINEROOMNAME"] = strMedicineStorageName;
                        m_newRow["ASSISTCODE_CHR"] = m_dtbResultRow["ASSISTCODE_CHR"];//������
                        m_newRow["MEDICINENAME_VCHR"] = m_dtbResultRow["MEDICINENAME_VCHR"];//ҩƷ����
                        m_newRow["MEDSPEC_VCHR"] = m_dtbResultRow["MEDSPEC_VCHR"];//���
                        m_newRow["LOTNO_VCHR"] = m_dtbResultRow["LOTNO_VCHR"];//����
                        m_newRow["MEDICINETYPENAME_VCHR"] = m_dtbResultRow["MEDICINETYPENAME_VCHR"];//ҩƷ��������
                        m_newRow["REALGROSS_INT"] = m_decRealGrossSum;//ʵ�ʿ��
                        m_newRow["AVAILAGROSS_INT"] = m_decAvailGrossSum;//���ÿ��
                        m_newRow["OPREALGROSS_INT"] = m_decDBRealGrossSum;//����ʵ�ʿ��
                        m_newRow["OPAVAILAGROSS_INT"] = m_decDBAvailGrossSum;//�������ÿ��
                        m_newRow["IPREALGROSS_INT"] = m_decIPRealGrossSum;//��Сʵ�ʿ��
                        m_newRow["IPAVAILAGROSS_INT"] = m_decIPAvailGrossSum;//��С���ÿ��
                        m_newRow["storagerackid_chr"] = m_dtbResultRow["storagerackid_chr"];//����
                        m_newRow["unit_chr"] = m_dtbResultRow["unit_chr"].ToString().Trim();
                        m_newRow["ifstop_int"] = m_dtbResultRow["ifstop_int"];
                        m_newRow["noqtyflag_int"] = m_dtbResultRow["noqtyflag_int"];
                        m_newRow["opunit_chr"] = m_dtbResultRow["opunit_chr"].ToString().Trim();
                        m_newRow["ipunit_chr"] = m_dtbResultRow["ipunit_chr"].ToString().Trim();
                        m_newRow["productorid_chr"] = m_dtbResultRow["productorid_chr"];
                        m_newRow["pycode_chr"] = m_dtbResultRow["pycode_chr"];
                        m_newRow["wbcode_chr"] = m_dtbResultRow["wbcode_chr"];

                        /*if (m_decIPRealGrossSum == 0)
                            m_newRow["RETAILPRICE_INT"] = 0;//���۵���
                        else
                            m_newRow["RETAILPRICE_INT"] = m_decRetailSum / m_decIPRealGrossSum;//���۵���

                        if (m_decRealGrossSum == 0)
                            m_newRow["WHOLESALEPRICE_INT"] = 0;//���뵥��
                        else
                            m_newRow["WHOLESALEPRICE_INT"] = m_decCallSum / m_decIPRealGrossSum;//���뵥��
                        */
                        m_newRow["RETAILPRICE_INT"] = m_dtbResultRow["retailprice_int"];
                        m_newRow["WHOLESALEPRICE_INT"] = m_dtbResultRow["wholesaleprice_int"];

                        m_newRow["WHOLESALESUM"] = m_decCallSum;//������
                        m_newRow["RETAILSUM"] = m_decRetailSum;//���۽��
                        m_newRow["VALIDPERIOD_DAT"] = m_dtbResultRow["VALIDPERIOD_DAT"];//ʧЧ����
                        m_newRow["MEDICINEPREPTYPENAME_VCHR"] = m_dtbResultRow["MEDICINEPREPTYPENAME_VCHR"];//ҩƷ����
                        m_newRow["seriesid_int"] = m_dtbResultRow["seriesid_int"];
                        //��������
                        tmp_dtbResult.Rows.Add(m_newRow);
                        m_newRow.AcceptChanges();
                    }
                }
            }
        }
        #endregion

        #region �����񵼳����ݵ�Excel
        /// <summary>
        /// �����񵼳����ݵ�Excel
        /// </summary>
        internal void m_mthExportToExcel()
        {
            DataTable dtExport = new DataTable("dtExoprt");

            string strColName = "";
            int intSame = 1;
            for (int i = 0; i < m_objViewer.m_dgvDrugStorage.Columns.Count; i++)
            {               
                if (m_objViewer.m_dgvDrugStorage.Columns[i].Visible == false)
                {
                    continue;
                }

                strColName = m_objViewer.m_dgvDrugStorage.Columns[i].HeaderText.Replace("(", "").Replace(")", "").Replace(".", "").Replace("\n","").Trim();
               
                //��ֹ���������ж����������ɽ��˴�����̸�Ϊ�ݹ飩
                if (dtExport.Columns.Contains(strColName))
                {
                    strColName = strColName + intSame.ToString();
                    intSame++;
                }

                if (m_objViewer.m_dgvDrugStorage.Columns[i].ValueType == null)
                {
                    dtExport.Columns.Add(strColName, typeof(string));
                }
                else if (m_objViewer.m_dgvDrugStorage.Columns[i].ValueType.FullName.ToLower() == "system.numeric" || m_objViewer.m_dgvDrugStorage.Columns[i].ValueType.FullName.ToLower() == "system.decimal")
                {
                    dtExport.Columns.Add(strColName, typeof(decimal));
                }
                else
                {
                    dtExport.Columns.Add(strColName, typeof(string));
                }
            }

            DataRow dr;
            for (int i = 0; i < m_objViewer.m_dgvDrugStorage.Rows.Count; i++)
            {
                dr = dtExport.NewRow();

                int row = 0;
                for (int j = 0; j < m_objViewer.m_dgvDrugStorage.Columns.Count; j++)
                {                   
                    if (m_objViewer.m_dgvDrugStorage.Columns[j].Visible == false)
                    {
                        continue;
                    }
                    if (j == 6)
                    {
                        dr[row] = m_objViewer.m_dgvDrugStorage.Rows[i].Cells[j].FormattedValue;
                    }
                    else
                    {
                        dr[row] = m_objViewer.m_dgvDrugStorage.Rows[i].Cells[j].Value;
                    }
                    row++;
                }

                dtExport.Rows.Add(dr);
            }

            DataSet dsExport = new DataSet();
            dsExport.Tables.Add(dtExport);

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Excel files (*.xls)|*.xls";
            dialog.FilterIndex = 1;
            dialog.RestoreDirectory = true;
            bool b = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                b = m_mthExport(dsExport, dialog.FileName);
            }

            if (b)
            {
                MessageBox.Show("����Excel�ɹ���", "ҩƷ����ѯ��¼", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("����Excelʧ�ܡ�", "ҩƷ����ѯ��¼", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            dtExport.Dispose();
            dsExport.Tables.Clear();
            dsExport.Dispose();
            #region OldCode
            //SaveFileDialog saveFileDialog = new SaveFileDialog();
            //saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            //saveFileDialog.FilterIndex = 0;
            //saveFileDialog.RestoreDirectory = true;
            //saveFileDialog.CreatePrompt = true;
            //saveFileDialog.Title = "����Excel�ļ���";
            //if (saveFileDialog.ShowDialog() != DialogResult.OK)
            //{
            //    return;
            //}
            //Stream myStream;
            //myStream = saveFileDialog.OpenFile();
            //StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            //string str = "";
            //try
            //{
            //    //����б���
            //    for (int iOr = 0; iOr < m_objViewer.m_dgvDrugStorage.ColumnCount; iOr++)
            //    {
            //        if (iOr > 0)
            //        {
            //            str += "\t";
            //        }
            //        str += m_objViewer.m_dgvDrugStorage.Columns[iOr].HeaderText.Replace("\n","");
            //    }
            //    sw.WriteLine(str);
            //    //������ı�
            //    StringBuilder objStrBuilder = null;                
            //    for (int iOr = 0; iOr < m_objViewer.m_dgvDrugStorage.Rows.Count; iOr++)
            //    {
            //        objStrBuilder = new StringBuilder();
            //        for (int jOr = 0; jOr < m_objViewer.m_dgvDrugStorage.Columns.Count; jOr++)
            //        {
            //            if (jOr > 0)
            //            {
            //                objStrBuilder.Append("\t");
            //            }
            //            if (jOr == 6)
            //            {                            
            //                objStrBuilder.Append(m_objViewer.m_dgvDrugStorage.Rows[iOr].Cells[jOr].FormattedValue.ToString());
            //            }
            //            else
            //                objStrBuilder.Append(m_objViewer.m_dgvDrugStorage.Rows[iOr].Cells[jOr].Value.ToString());
            //        }
            //        sw.WriteLine(objStrBuilder);
            //    }
            //    MessageBox.Show("�����ɹ���", "ҩƷ����ѯ��¼", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    sw.Close();
            //    myStream.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
            //finally
            //{
            //    sw.Close();
            //    myStream.Close();
            //}
            #endregion
        }

        /// <summary>
        /// д��Excel
        /// </summary>
        /// <param name="dsSource"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private bool m_mthExport(DataSet dsSource, string fileName)
        {
            if ((fileName == null) || (fileName == ""))
            {
                return false;
            }
            if (!fileName.EndsWith(".xls"))
            {
                fileName = fileName + ".xls";
            }
            if (dsSource == null)
            {
                return false;
            }
            if (dsSource.Tables.Count < 1)
            {
                MessageBox.Show("����Դû���κα�!");
                return false;
            }
            if (File.Exists(fileName))
            {
                try
                {
                    File.Delete(fileName);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("�ļ��޷�д��!\n\n" + exception.ToString());
                    return true;
                }
            }

            string provider = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=Excel 8.0;";
            OleDbConnection connection = new OleDbConnection(string.Format(provider, fileName));
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            connection.Open();
            string format = "Create Table {0} ({1})";
            string str2 = "Insert Into {0} ({1}) values({2})";
            foreach (DataTable table in dsSource.Tables)
            {
                string str4;
                string str5;
                string str3 = str4 = str5 = "";
                foreach (DataColumn column in table.Columns)
                {
                    if (column.DataType == Type.GetType("System.String"))
                    {
                        str3 = str3 + column.ColumnName + " varchar,";
                    }
                    else if (column.DataType == Type.GetType("System.DateTime"))
                    {
                        str3 = str3 + column.ColumnName + " datetime,";
                    }
                    else
                    {
                        str3 = str3 + column.ColumnName + " number,";
                    }
                    str4 = str4 + column.ColumnName + ",";
                    str5 = str5 + "@" + column.ColumnName + ",";
                }
                if (str3.EndsWith(","))
                {
                    str3 = str3.TrimEnd(new char[] { ',' });
                    str4 = str4.Trim(new char[] { ',' });
                    str5 = str5.TrimEnd(new char[] { ',' });
                }
                command.CommandText = string.Format(format, table.TableName, str3);
                command.ExecuteNonQuery();
                command.CommandText = string.Format(str2, table.TableName, str4, str5);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    command.Parameters.Clear();
                    foreach (DataColumn column in table.Columns)
                    {
                        command.Parameters.AddWithValue("@" + column.ColumnName, table.Rows[i][column]);
                    }
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
            return true;
        }
        #endregion

        #region ��ӡ
        /// <summary>
        /// ��ӡ
        /// </summary>
        internal void m_mthPrint()
        {
            if (dtbTem == null || dtbTem.Rows.Count <= 0)
            {
                MessageBox.Show("û�пɴ�ӡ���ݣ�", "����ѯ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (m_objViewer.m_rdbDetail.Checked)
            {
                DataWindowControl m_dwcDrugQuery = new DataWindowControl();
                m_dwcDrugQuery.LibraryList = Application.StartupPath + "\\PB_OP.pbl";
                //if(m_objViewer.m_rdbTotal.Checked)
                //    m_dwcDrugQuery.DataWindowObject = "d_op_drugquerytotal";
                //else
                m_dwcDrugQuery.DataWindowObject = "d_op_drugquerydetail";


                m_dwcDrugQuery.SetRedrawOff();
                //DataTable dtbPrint = ((DataTable)m_objViewer.m_dgvDrugStorage.DataSource).Copy();
                DataTable dtbPrint = ((DataTable)m_objViewer.m_dgvDrugStorage.DataSource).Clone();
                DataRowView drv = null;
                for (int intRow = 0; intRow < this.m_objViewer.m_dgvDrugStorage.Rows.Count;intRow++ )
                {
                    drv = this.m_objViewer.m_dgvDrugStorage.Rows[intRow].DataBoundItem as DataRowView;
                    dtbPrint.Rows.Add(drv .Row.ItemArray);

                }

                DataTable dtbTemp = new DataTable();
                DataColumn[] dcColumns = new DataColumn[] { new DataColumn("medicineid_chr"), new DataColumn("assistcode_chr"), new DataColumn("medicinename_vchr"),new DataColumn("medspec_vchr"), new DataColumn("lotno_vchr"),
                new DataColumn("medicinetypename_vchr"),new DataColumn("realgross_int",typeof(double)),new DataColumn("availagross_int",typeof(double)),new DataColumn("opunit_chr"),new DataColumn("retailprice_int",typeof(double)),new DataColumn("wholesaleprice_int",
                typeof(double)),new DataColumn("validperiod_dat1",typeof(string)),new DataColumn("medicinepreptypename_vchr"),new DataColumn("productorid_chr"),new DataColumn("storagerackid_chr"),
                new DataColumn("storagerackname_vchr"),new DataColumn("retailsum",typeof(double)),new DataColumn("bca"),new DataColumn("cab",typeof(string)),new DataColumn("validperiod_dat",typeof(DateTime))};
                dtbTemp.Columns.AddRange(dcColumns);
                dtbTemp.Merge(dtbPrint, true, MissingSchemaAction.Ignore);
                //ĳЩҩƷ��Ч�ڳ�����Χ1753�꣬���ò�ת���ַ�������ʾ
                DataRow dr = null;
                for (int i1 = 0; i1 < dtbTemp.Rows.Count; i1++)
                {
                    dr = dtbTemp.Rows[i1];
                    dr["validperiod_dat1"] = Convert.ToDateTime(dr["validperiod_dat"]).ToString("yyyy-MM-dd");
                }
                dtbTemp.AcceptChanges();
                dtbTemp.Columns.Remove("validperiod_dat");

                m_dwcDrugQuery.Retrieve(dtbTemp);

                m_dwcDrugQuery.Refresh();
                m_dwcDrugQuery.SetRedrawOn();
                m_dwcDrugQuery.Modify("t_title.text = '" + base.m_objComInfo.m_strGetHospitalTitle() + "ҩ��ҩƷ���'");
                m_dwcDrugQuery.Modify("t_storename.text = 'ҩ����" + m_objViewer.m_cboStorage.Text + "'");
                m_dwcDrugQuery.Modify("t_drugtypename.text = 'ҩƷ���ͣ�" + m_objViewer.m_cboMedicineType.Text + "'");
                com.digitalwave.iCare.gui.MedicineStore.clsCtl_Public.PrintDialog(m_dwcDrugQuery);
            }
            else
            {
                frmStorageCheckReport frmCheckRep = new frmStorageCheckReport();
                frmCheckRep.m_blnUseByDS = true;
                frmCheckRep.datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
                frmCheckRep.datWindow.DataWindowObject = "ds_storagecheck";
                DataTable dtbTemp = ((DataTable)m_objViewer.m_dgvDrugStorage.DataSource).Copy();
                dtbTemp.Columns["medicinename_vchr"].ColumnName = "medicinename_vch";
                dtbTemp.Columns["REALGROSS_INT"].ColumnName = "currentgross_int";
                dtbTemp.Columns.Add("RetailMoney", typeof(double));

                DataTable dtbTmp;
                clsDcl_DrugStoreCheckDetail objDomain = new clsDcl_DrugStoreCheckDetail();
                objDomain.m_lngGetStoreCheck_DetailForPrint(0,m_blnIsHospital, out dtbTmp);
                //�����RetailMoney ʵ�̽�realmoney ӯ����balance
                dtbTmp.Columns.Add("RetailMoney", typeof(double));
                dtbTmp.Columns.Add("realmoney", typeof(double));
                dtbTmp.Columns.Add("balance", typeof(double));

                foreach (DataRow dr in dtbTemp.Rows)
                {
                    dr["RetailMoney"] = Convert.ToDouble(dr["RETAILSUM"]).ToString("F4");
                }

                dtbTmp.Merge(dtbTemp, true, MissingSchemaAction.Ignore);

                frmCheckRep.dtb = dtbTmp.DefaultView.ToTable();
                double dblTotalPrice = 0d;

                for (int i1 = 0; i1 < dtbTmp.Rows.Count; i1++)
                {
                    if (Convert.ToString(dtbTmp.Rows[i1]["RetailMoney"]).Length == 0) continue;
                    dblTotalPrice += Convert.ToDouble(dtbTmp.Rows[i1]["RetailMoney"]);
                }
                frmCheckRep.m_dblTotalPrice = dblTotalPrice;
                string strStorName = string.Empty; ;
                clsMedStore_VO objStore = clsPub.m_mthGetMedStoreNameByid(m_objViewer.m_strMedStoreArr[0]);
                if (objStore != null)
                {
                    strStorName = objStore.m_strMedStoreName;
                }
                frmCheckRep.strStorageName = strStorName;
                
                frmCheckRep.strCheckDate = DateTime.Now.ToString("yyyy��M��");
                frmCheckRep.strAskerName = m_objViewer.LoginInfo.m_strEmpName;
                frmCheckRep.strFhr = m_objViewer.LoginInfo.m_strEmpName;
                frmCheckRep.strExamerName = m_objViewer.LoginInfo.m_strEmpName;                

                frmCheckRep.m_strHospitalName = m_objComInfo.m_strGetHospitalTitle();
                frmCheckRep.ShowDialog();
            }
        }
        #endregion

        #region ����ҩ��ʵ�ʻ��ܰ󶨻���
        /// <summary>
        /// ����ҩ��ʵ�ʻ��ܰ󶨻���
        /// </summary>
        internal void m_mthBindStorageRack()
        {
            long lngRes = 0;
            m_objViewer.comculumn.DataSource = null;
            m_dtbStorageRack.Clear();
            
            if (m_objViewer.m_cboStorage.Text != "")
            {
                try
                {
                    lngRes = m_objDomain.m_lngGetStorageRack(m_objViewer.m_cboStorage.Text, out m_dtbStorageRack);

                    if (lngRes > 0)
                    {                        
                        if (m_dtbStorageRack.Rows.Count > 0)
                        {
                            m_objViewer.comculumn.DataSource = m_dtbStorageRack;
                            m_objViewer.comculumn.ValueMember = "storagerackid_chr";
                            m_objViewer.comculumn.DisplayMember = "STORAGERACKNAME_VCHR";                            
                        }
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "���ܼ��س���", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
        }
        #endregion

        #region �����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="p_dicStorageRack"></param>
        /// <returns></returns>
        internal long m_lngSaveStorageRack(Dictionary<string, string> p_dicStorageRack)
        {
            long lngRes = 0;

            if (p_dicStorageRack.Count > 0)
            {
                try
                {
                    lngRes = m_objDomain.m_lngSaveStorageRack(p_dicStorageRack);

                    if (lngRes > 0)
                    {
                        //MessageBox.Show("����������ϣ�", "��������", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "���ܱ������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return lngRes;
        }


        internal long m_lngSaveProvide(DataTable p_dtbAmount)//����ɹ����ɹ�
        {
            long lngRes = 0;

            if (p_dtbAmount.Rows.Count > 0)
            {
                try
                {
                    lngRes = m_objDomain.m_lngSaveProvide(p_dtbAmount);
                }
                catch (Exception objEx)
                {
                    MessageBox.Show(objEx.Message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            return lngRes;
        }
        #endregion

        #region ��ʾ�û��Ƿ���Ҫ����������Ҳ����Ϊ�ɹ��򲻿ɹ���
        DataRow m_rowAmount = null;
        Int64 m_intSeriesID = 0;
        string m_strCanProvide = "";
        string m_strCanProvideName = "";
        string strMedicineID = "";
        internal void m_mthEdit(int p_intIndex)
        {
            try
            {
                m_objViewer.m_blnEditing = true;
                m_rowAmount = ((DataRowView)(m_objViewer.m_dgvDrugStorage.CurrentCell.OwningRow.DataBoundItem)).Row;
                if (m_objViewer.m_dtbAmount.PrimaryKey.Length == 0)
                {
                    DataColumn[] dcPrimaryKeyArr = new DataColumn[1];
                    dcPrimaryKeyArr[0] = m_objViewer.m_dtbAmount.Columns["seriesid_int"];
                    m_objViewer.m_dtbAmount.PrimaryKey = dcPrimaryKeyArr;
                }
                m_intSeriesID = Convert.ToInt64(m_rowAmount["seriesid_int"]);
                m_strCanProvide = Convert.ToString(m_rowAmount["canprovide_int"]);
                //�Զ�����ı����ﵥλ�Ŀ��ÿ�����Ӧ��װ��λ���ÿ��ı仯��
                //if (p_intIndex == m_objViewer.m_dgvDrugStorage.Columns["colIPAvailaGross"].Index)
                //{
                //    if (m_blnIsHospital)
                //    {
                //        if (Convert.ToInt16(m_rowAmount["ipchargeflg_int"]) == 0)
                //        {
                //            m_rowAmount["opavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value);
                //            m_rowAmount["ipavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value) * Convert.ToDouble(m_rowAmount["packqty_dec"]);
                //        }
                //        else if ((Convert.ToInt16(m_rowAmount["ipchargeflg_int"]) == 1))
                //        {
                //            m_rowAmount["opavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value) / Convert.ToDouble(m_rowAmount["packqty_dec"]);
                //            m_rowAmount["ipavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value);
                //        }
                //    }
                //    else
                //    {
                //        if (Convert.ToInt16(m_rowAmount["opchargeflg_int"]) == 0)
                //        {
                //            m_rowAmount["opavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value);
                //            m_rowAmount["ipavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value) * Convert.ToDouble(m_rowAmount["packqty_dec"]);
                //        }
                //        else if ((Convert.ToInt16(m_rowAmount["opchargeflg_int"]) == 1))
                //        {
                //            m_rowAmount["opavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value) / Convert.ToDouble(m_rowAmount["packqty_dec"]);
                //            m_rowAmount["ipavailagross_int"] = Convert.ToDouble(m_objViewer.m_dgvDrugStorage.Rows[m_objViewer.m_dgvDrugStorage.CurrentCell.RowIndex].Cells["colIPAvailaGross"].Value);
                //        }
                //    }
                //}

                if (m_objViewer.m_dtbAmount.Rows.Contains(m_intSeriesID))
                {
                    m_objViewer.m_dtbAmount.Rows.Remove(m_objViewer.m_dtbAmount.Rows.Find(m_intSeriesID));
                }
                m_objViewer.m_dtbAmount.Rows.Add(m_rowAmount.ItemArray);

                m_strCanProvideName = m_objViewer.m_dgvDrugStorage.CurrentCell.Value.ToString() == "0" ? "���ɹ�" : "�ɹ�";
                strMedicineID = m_rowAmount["medicineid_chr"].ToString();
                DataView dvResult = dtbResult.DefaultView;
                dvResult.RowFilter = "medicineid_chr = '" + strMedicineID + "'";
                DataTable dtTemp = dvResult.ToTable();
                if (dtTemp.Rows.Count > 1 && p_intIndex == m_objViewer.m_dgvDrugStorage.Columns["colStorageProvide"].Index)
                {
                    if (MessageBox.Show("�Ƿ���Ҫ���������ŵ�ҩƷ��" + m_rowAmount["medicinename_vchr"].ToString() + "��Ҳ����Ϊ" + m_strCanProvideName + "��", "�ɹ�״̬����",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        for (int i1 = 0; i1 < m_objViewer.m_dgvDrugStorage.Rows.Count; i1++)
                        {
                            m_rowAmount = ((DataRowView)(m_objViewer.m_dgvDrugStorage.Rows[i1].Cells[0].OwningRow.DataBoundItem)).Row;
                            if (m_rowAmount["medicineid_chr"].ToString() == strMedicineID && Convert.ToInt64(m_rowAmount["seriesid_int"]) != m_intSeriesID)
                            {
                                m_objViewer.m_dgvDrugStorage.Rows[i1].Cells["colStorageProvide"].Value = m_strCanProvide;
                                if (m_objViewer.m_dtbAmount.Rows.Contains(Convert.ToInt64(m_rowAmount["seriesid_int"])))
                                {
                                    m_objViewer.m_dtbAmount.Rows.Remove(m_objViewer.m_dtbAmount.Rows.Find(Convert.ToInt64(m_rowAmount["seriesid_int"])));
                                }
                                m_objViewer.m_dtbAmount.Rows.Add(m_rowAmount.ItemArray);
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                m_objViewer.m_blnEditing = false;
            }
        }
        #endregion

        internal long m_lngSaveAmount(clsDS_StorageHistory_VO objHistory)
        {
            return m_objDomain.m_lngSaveAmount(objHistory);
        }

        internal long m_lngGetAmountBySeriesID(long p_intSeriesID, out clsDS_StorageHistory_VO objHistory)
        {
            return m_objDomain.m_lngGetAmountBySeriesID(p_intSeriesID, out objHistory);
        }

        #region ��ȡҩƷ�Ƽ�����
        /// <summary>
        /// ��ȡҩƷ�Ƽ�����
        /// </summary>
        internal void m_mthShowMedicinePreptype()
        {
            com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO[] objMPVO = null;
            m_objDomain.m_mthShowMedicinePreptype(m_objViewer.m_strMedStoreArr[0], out objMPVO);

            if (objMPVO != null && objMPVO.Length > 0)
            {
                m_objViewer.m_lsbMediciePreptype.Items.Clear();
                com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO objAll = new com.digitalwave.iCare.ValueObject.clsMEDICINEPREPTYPE_VO();
                objAll.m_intFLAGA_INT = 0;
                objAll.m_strMEDICINEPREPTYPE_CHR = string.Empty;
                objAll.m_strMEDICINEPREPTYPENAME_VCHR = "ȫ��";
                m_objViewer.m_lsbMediciePreptype.Items.Add(objAll);
                m_objViewer.m_lsbMediciePreptype.Items.AddRange(objMPVO);
                m_objViewer.m_lsbMediciePreptype.SelectedIndex = 0;
            }
        }
        #endregion
    }
}
