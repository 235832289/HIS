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
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// �Զ��������쵥���Ʋ�
    /// </summary>
    public class clsCtl_GenerateAsk : com.digitalwave.GUI_Base.clsController_Base
    {
         /// <summary>
        /// �Զ��������쵥���Ʋ㹹�췽��
        /// </summary>
        public clsCtl_GenerateAsk()
        {
            m_objDomain = new clsDcl_GenerateAsk();
        }

        #region ���ô������
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmGenerateAsk)frmMDI_Child_Base_in;
        }
        #endregion

        #region ȫ�ֱ���
        /// <summary>
        /// ģ�������
        /// </summary>
        private clsDcl_GenerateAsk m_objDomain = null;
        /// <summary>
        /// ����
        /// </summary>
        private com.digitalwave.iCare.gui.HIS.frmGenerateAsk m_objViewer;
        /// <summary>
        /// ҩ�������Ϣ
        /// </summary>
        private clsValue_StorageBse_VO[] m_objStorageBseArr = null;
        /// <summary>
        /// ҩ��ID
        /// </summary>
        private string m_strStorageID = string.Empty;
        /// <summary>
        /// ҩ������
        /// </summary>
        private string m_strStorageName = string.Empty;
        /// <summary>
        /// ���⿪ʼ����
        /// </summary>
        private string m_strBeginDate = string.Empty;
        /// <summary>
        /// �����������
        /// </summary>
        private string m_strEndDate = string.Empty;
        /// <summary>
        /// ������ϸ���ݱ�
        /// </summary>  
        internal DataTable dtbResult = null;
        DataView dtvMedType = null;
        #endregion

        #region ��ʼ���ӱ���ΪDataGridView����Դ��DataTable
        /// <summary>
        /// ��ʼ���ӱ���ΪDataGridView����Դ��DataTable
        /// </summary>
        /// <param name="m_dtMedDetail"></param>
        public void m_mthInitMedicineTable(ref DataTable m_dtMedDetail)
        {
            dtbResult = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("IfCheck"),new DataColumn("drugstoreid_chr"), new DataColumn("assistcode_chr"), new DataColumn("medicineid_chr"),
                new DataColumn("medicinename_vchr"),new DataColumn("medspec_vchr"),new DataColumn("opamount_int",typeof(double)),new DataColumn("opunit_chr"),new DataColumn("ipamount_int",typeof(double)),new DataColumn("ipunit_chr",
                typeof(string)),new DataColumn("packqty_dec",typeof(double)),new DataColumn("unitprice_mny",typeof(double)),new DataColumn("askdate_dat",typeof(DateTime))};
            dtbResult.Columns.AddRange(dcColumns);
            dtbResult.PrimaryKey = new DataColumn[] { dtbResult.Columns["medicineid_chr"] };
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
                MessageBox.Show("����ѡ��ҩ��!", "��ܰ��ʾ...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
                m_strStorageName = m_objViewer.m_cboStorage.Text;
            
            DateTime dtBeginTime = DateTime.MinValue;
            if (!DateTime.TryParse(m_objViewer.m_datBeginDate.Text, out dtBeginTime))
            {
                MessageBox.Show("�����뿪ʼʱ�䡣", "��ܰ��ʾ...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_objViewer.m_datBeginDate.Focus();
                return;
            }
            DateTime dtEndTime = DateTime.MinValue;
            if (!DateTime.TryParse(m_objViewer.m_datEndDate.Text, out dtEndTime))
            {
                MessageBox.Show("���������ʱ�䡣", "��ܰ��ʾ...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_objViewer.m_datEndDate.Focus();
                return;
            }
            if (dtBeginTime > dtEndTime)
            {
                MessageBox.Show("��ʼʱ�䲻�ܴ��ڽ���ʱ�䡣", "��ܰ��ʾ...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                m_objViewer.m_datBeginDate.Focus();
                return;
            }
            m_strBeginDate = dtBeginTime.ToString("yyyy-MM-dd HH:mm:ss");
            m_strEndDate = dtEndTime.ToString("yyyy-MM-dd HH:mm:ss");                    

            long lngRes = 0;
            
            m_objViewer.m_dgvDrugStorage.DataSource = null;

            //if (dtbResult != null)
            //{
            //    dtbResult.Clear();
            //    dtbResult.Dispose();
            //    dtbResult = null;
            //}
            //if (dtbResult == null)
            //{
            //    m_mthInitMedicineTable(ref dtbResult);
            //}

            m_strStorageID = m_objStorageBseArr[m_objViewer.m_cboStorage.SelectedIndex].MEDICINEROOMID;
            //if (m_objViewer.m_blnIsHospital)
            //{
            //    lngRes = m_objDomain.m_lngGetNeapData(m_strStorageID, dtBeginTime, dtEndTime, ref dtbResult);
            //}
            //else
            //{
                lngRes = m_objDomain.m_mthGetOutStorageDetailData(m_objViewer.m_blnIsHospital, m_strStorageID, m_strBeginDate, m_strEndDate,m_objViewer.m_intGetRequestAmount, ref dtbResult);
            //}
            if ((lngRes > 0) && (dtbResult != null))
            {
                DataView dv = dtbResult.DefaultView;
                if (m_objViewer.m_cbLimit.Checked)
                    dv.RowFilter = "assistcode_chr is not null and isnull(currentgross_num,0) < neaplimit_int";
                else
                    dv.RowFilter = "assistcode_chr is not null";
                if (m_objViewer.txtTypecode.Text != "ȫ��" && m_objViewer.txtTypecode.Text != "")
                {
                    dv.RowFilter += " and medicinetypeid_chr = '" + m_objViewer.txtTypecode.Value + "'";
                }
                if (m_objViewer.m_cbkFilter.Checked)
                {
                    dv.RowFilter += " and useamount_int > isnull(currentgross_num,0)";
                }
                dtbResult = dv.ToTable();
                m_objViewer.m_dgvDrugStorage.DataSource = dtbResult;
            }
        }
        #endregion

        #region �������쵥
        /// <summary>
        /// �������쵥
        /// </summary>
        internal void m_mthGenerate()
        {
            //m_objViewer.m_btnQuery.PerformClick();//��ˢ������
            //if (m_objViewer.m_rbtDate.Checked)
            //{
            DataTable m_dtbResult = m_objViewer.m_dgvDrugStorage.DataSource as DataTable;
            if (m_dtbResult == null || m_dtbResult.Rows.Count <= 0) return;
            DataTable dtbSelected = m_dtbResult.Clone();
            m_dtbResult.PrimaryKey = new DataColumn[] { m_dtbResult.Columns["medicineid_chr"] };
            DataRow drSelect = null;
            for (int i1 = 0; i1 < m_objViewer.m_dgvDrugStorage.Rows.Count; i1++)
            {
                if (m_objViewer.m_dgvDrugStorage[0, i1].Value.ToString() == "T")
                {
                    drSelect = m_dtbResult.Rows.Find(m_objViewer.m_dgvDrugStorage["medicineid_chr", i1].Value);
                    dtbSelected.Rows.Add(drSelect.ItemArray);
                }
            }

            if (dtbSelected.Rows.Count > 0)
            {
                ShowAsk(dtbSelected);
            }
            m_dtbResult.Dispose();
            //}
            //else
            //{
            //    m_strStorageID = m_objStorageBseArr[m_objViewer.m_cboStorage.SelectedIndex].MEDICINEROOMID;
            //    //��ȡ��ҩ�������������������ҩƷ
            //    DataTable dtbAmount = new DataTable();
            //    m_objDomain.m_mthGetNeapData(m_strStorageID, ref dtbAmount);
            //    if(dtbAmount.Rows.Count > 0)
            //    {
            //        ShowAsk(dtbAmount);
            //    }
            //}
        }

        /// <summary>
        /// ��ʾ�������쵥
        /// </summary>
        /// <param name="p_dtbData"></param>
        private void ShowAsk(DataTable p_dtbData)
        {
            frmAskForMedDetail frmDetail = new frmAskForMedDetail();
            frmDetail.m_blnIsHospital = m_objViewer.m_blnIsHospital;
            DataTable dtbExportDept = new DataTable();
            m_objDomain.m_lngGetExportDept(out dtbExportDept);
            DataTable dtbApplyDept = new DataTable();
            m_objDomain.m_lngGetApplyDept(out dtbApplyDept);
            frmDetail.dtExportDept = dtbExportDept;
            frmDetail.dtApplyDept = dtbApplyDept;
            ((clsCtl_AskForMedicineDetail)frmDetail.objController).m_objMainVoList = new List<com.digitalwave.iCare.ValueObject.clsDS_Ask_VO>();
            frmDetail.m_btnNext.Enabled = false;
            frmDetail.IsCanModify = true;            
            frmDetail.MdiParent = m_objViewer.MdiParent;
            frmDetail.Show();
            frmDetail.m_strDrugStoreID = m_objStorageBseArr[m_objViewer.m_cboStorage.SelectedIndex].MEDICINEROOMID;
            frmDetail.m_cboAskDept.SelectedValue = frmDetail.m_strDrugStoreID;
            frmDetail.m_cboAskDept.SelectedText = m_objStorageBseArr[m_objViewer.m_cboStorage.SelectedIndex].MEDICINEROOMNAME;
            frmDetail.m_cboAskDept.Enabled = false;
            frmDetail.SetDetail(p_dtbData);
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
            if (m_objViewer.m_strStorageid != "0000")
            {
                for (int i1 = 0; i1 < m_objStorageBseArr.Length; i1++)
                {
                    if (m_objStorageBseArr[i1].MEDICINEROOMID == m_objViewer.m_strStorageid)
                    {
                        m_objViewer.m_cboStorage.SelectedIndex = i1;
                        m_objViewer.m_cboStorage.Enabled = false;
                        break;
                    }
                }
            }
        }
        #endregion

        internal void m_mthInitialType()
        {           
            DataTable dtRoom;
            DataTable dtRoomToid = new DataTable();
            DataTable dtVonder;
            DataTable dtMedType;
            m_objDomain.m_lngGetExptypeAndVendor(true, out dtRoom, out dtVonder, out dtMedType);
            dtvMedType = new DataView(dtMedType);
            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("�������", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            this.m_objViewer.txtTypecode.m_dtbDataSourse = null;
            string m_strDeptID = string.Empty;
            if (m_objViewer.m_strStorageid != "0000")
            {
                m_objDomain.m_lngGetDeptIDForStore(m_objViewer.m_strStorageid, out m_strDeptID);
                if (dtRoom.Rows.Count > 0)
                {
                    dtRoomToid = dtRoom.Clone();
                    DataRow dr = null;
                    int iRowCount = dtRoom.Rows.Count;
                    dtRoomToid.BeginLoadData();                    
                    for (int j = 0; j < iRowCount; j++)
                    {
                        dr = dtRoom.Rows[j];
                        if (m_strDeptID == dr["medicineroomid"].ToString().Trim())
                        {
                            dtRoomToid.LoadDataRow(dr.ItemArray, true);
                        }
                    }                  
                    dtRoomToid.EndLoadData();
                    dtRoomToid.AcceptChanges();
                }
            }

            this.m_objViewer.txtTypecode.m_listView.Items.Clear();
            this.dtvMedType.RowFilter = "medicineroomid='" + m_strDeptID + "'";

            DataTable dtValue = dtvMedType.ToTable();
            DataRow drTmp = dtValue.NewRow();
            drTmp["medicinetypeid_chr"] = "";
            drTmp["medicinetypename_vchr"] = "ȫ��";
            drTmp["medicineroomid"] = "-1";
            dtValue.BeginLoadData();
            dtValue.Rows.Add(drTmp);
            dtValue.EndLoadData();

            this.m_objViewer.txtTypecode.m_dtbDataSourse = dtValue;
            this.m_objViewer.txtTypecode.m_mthFillData();
        }

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

        internal long m_lngGetRequestAmount(out int p_intGetRequestAmount)
        {
            return m_objDomain.m_lngGetRequestAmount(out p_intGetRequestAmount);
        }
    }
}
