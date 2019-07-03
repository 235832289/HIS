using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using com.digitalwave.emr.DigitalSign;//����ǩ��
using iCareData;
using com.digitalwave.Emr.Signature_srv;
//using com.digitalwave.Emr.Signature_gui;
using iCare.Anaesthesia.Framework;
//using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.Emr.Signature_gui
{
    /// <summary>
    /// clsCommonUsePanelController ��ժҪ˵����
    /// </summary>
    public class clsCommonUsePanelController
    {
        #region ���캯��
        /// <summary>
        /// ���캯��
        /// </summary>
        public clsCommonUsePanelController(object objviewer)
        {
            //����viewer����
            m_objViewer = (frmCommonUsePanel)objviewer;
        }
        #endregion


        #region �ֶ�
        /// <summary>
        /// viewer����
        /// </summary>
        private frmCommonUsePanel m_objViewer;
        /// <summary>
        /// ǩ���б�
        /// </summary>
        private DataTable dt = new DataTable();
        /// <summary>
        /// ǩ���б���ͼ
        /// </summary>
        private DataView dv = new DataView();
        #endregion

        #region ����
        /// <summary>
        /// load����
        /// </summary>
        public void m_thLoad()
        {
            try
            {
                m_thGetEmployee();
                if (dt == null)
                {
                    throw new Exception("m_thGetEmployee()��ѯû�н����");
                }
                dv = dt.DefaultView;
                m_mthAddEmployeesToList();
                m_mthCheckSortConfig();

                if (!m_blnIsCustomSetting)
                {
                    m_objViewer.m_BlnIsShowLevel = m_blnIsShowEmpLevel();
                }
                m_objViewer.m_BlnIsShowAllEmployee = m_blnIsShowAllEmp();
                //������ʾ
                if (m_objViewer.m_intType == -10 || m_objViewer.m_intType == -9)
                {
                    m_objViewer.tlbAllhospital.Enabled = false;
                }
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
            }

        }


        internal bool m_blnIsCustomSetting = false;

        /// <summary>
        /// �Ƿ���ʾְ��
        /// </summary>
        /// <returns></returns>
        private bool m_blnIsShowEmpLevel()
        {
            bool blnReturnValue = true;
            //clsDigitalSign_domain objDomain = new clsDigitalSign_domain();
            int intReturn = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3015");
            //long lngRes = objDomain.m_lngGetSignConfig("3015", out intReturn);
            if (intReturn == 1)
            {
                blnReturnValue = true;
            }
            else
            {
                blnReturnValue = false;
            }
            return blnReturnValue;
        }

        /// <summary>
        /// �����������
        /// </summary>
        private void m_mthCheckSortConfig()
        {
            //clsDigitalSign_domain objDomain = new clsDigitalSign_domain();
            int intReturn = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3014");
            //long lngRes = objDomain.m_lngGetSignConfig("3014",out intReturn);
            if (intReturn == 1)
            {
                m_objViewer.m_BlnIsSortingByLevel = true;
            }
            else
            {
                m_objViewer.m_BlnIsSortingByLevel = false;
            }
        }

        /// <summary>
        /// ��ȡȫԺҽ����ʿ����
        /// </summary>
        public void m_thLoadbyAll()
        {
            try
            {
                if (m_objViewer.m_BlnIsShowAllEmployee)
                {
                    m_mthGetAllEmployee();
                }
                else
                {
                    m_thGetEmployeeAllDocAndNur();
                }
                dv = dt.DefaultView;
                m_mthAddEmployeesToList();
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
            }

        }

        /// <summary>
        /// �����ı��¼�
        /// </summary>
        public void m_thInputHChange()
        {
            try
            {
                string strFilter = m_objViewer.txtInput.Text.Trim();
                strFilter = strFilter.ToUpper();
                dv.RowFilter = " empno_chr like '" + strFilter + "%' or lastname_vchr like '" + strFilter + "%' or pycode_chr like '" + strFilter + "%'";
                m_mthAddEmployeesToList();

            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
            }

        }

        ///   <summary> 
        ///   ����DataTable�е�ָ���ֶ��ظ����� 
        ///   </summary> 
        ///   <param   name= "dt "> </param> 
        ///   <param   name= "FieldName "> </param> 
        ///   <returns> </returns> 
        private DataTable SelectDistinctByField(DataTable dt, string FieldName)
        {
            DataTable returnDt = new DataTable();
            returnDt = dt.Copy();//��ԭDataTable����һ���µ� 
            DataRow[] drs = returnDt.Select(" ", FieldName);//��DataTable��ָ�����ֶ����� 
            object LastValue = null;
            for (int i = 0; i < drs.Length; i++)
            {
                if ((LastValue == null) || (!(ColumnEqual(LastValue, drs[i][FieldName]))))
                {
                    LastValue = drs[i][FieldName];
                    continue;
                }

                drs[i].Delete();
            }

            return returnDt;
        }

        private bool ColumnEqual(object A, object B)
        {
            //   Compares   two   values   to   see   if   they   are   equal.   Also   compares   DBNULL.Value. 
            //   Note:   If   your   DataTable   contains   object   fields,   then   you   must   extend   this 
            //   function   to   handle   them   in   a   meaningful   way   if   you   intend   to   group   on   them. 

            if (A == DBNull.Value && B == DBNull.Value)   //     both   are   DBNull.Value 
                return true;
            if (A == DBNull.Value || B == DBNull.Value)   //     only   one   is   DBNull.Value 
                return false;
            return (A.Equals(B));     //   value   type   standard   comparison 
        }

        /// <summary>
        /// ��ȡǩ���б�
        /// </summary>
        public void m_thGetEmployee()
        {
            clsSignature_srv objDomain = null;
            //if (clsDBConnectionManager.IsDBAvailable)
            {
                objDomain = (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));
            }

            try
            {
                switch (m_objViewer.m_intType)
                {
                    case -1://ҽ��ǩ������ֵ

                        ////if (clsDBConnectionManager.IsDBAvailable)
                        //{
                            objDomain.m_lngGetEmployeeSignWithoutDept(null, 1, out dt);
                        //}
                        //else
                        //{
                        //    CacheManager cache = CacheFactory.GetCacheManager("EmployeeSign");
                        //    if (cache != null && cache.DataSource != null)
                        //    {
                        //        DataView view = ((DataTable)cache.DataSource).DefaultView;
                        //        view.RowFilter = "technicallevel_chr like '5%'";
                        //        dt = SelectDistinctByField(view.ToTable(), "empid_chr");
                        //    }
                        //}
                        break;
                    case -2://��ʿǩ������ֵ
                        //if (clsDBConnectionManager.IsDBAvailable)
                        //{
                            objDomain.m_lngGetEmployeeSignWithoutDept(null, 2, out dt);
                        //}
                        //else
                        //{
                        //    CacheManager cache = CacheFactory.GetCacheManager("EmployeeSign");
                        //    if (cache != null && cache.DataSource != null)
                        //    {
                        //        DataView view = ((DataTable)cache.DataSource).DefaultView;
                        //        view.RowFilter = "technicallevel_chr like '4%'";
                        //        dt = SelectDistinctByField(view.ToTable(), "empid_chr");
                        //    }
                        //}
                        break;
                    case -5://ȫ��Ա������ֵ
                        //if (clsDBConnectionManager.IsDBAvailable)
                        //{
                            objDomain.m_lngGetEmployeeSignWithoutDept(null, 0, out dt);
                        //}
                        //else
                        //{
                        //    CacheManager cache = CacheFactory.GetCacheManager("EmployeeSign");
                        //    if (cache != null && cache.DataSource != null)
                        //    {
                        //        DataView view = ((DataTable)cache.DataSource).DefaultView;
                        //        dt = SelectDistinctByField(view.ToTable(), "empid_chr");
                        //    }
                        //}
                        break;
                    case -3://�ض�����ҽ��ǩ������ֵ
                        //if (clsDBConnectionManager.IsDBAvailable)
                        //{
                            objDomain.m_lngGetEmployeeSignWithDept(null, 1, m_objViewer.m_StrDeptID, out dt);
                        //}
                        //else
                        //{
                        //    CacheManager cache = CacheFactory.GetCacheManager("EmployeeSign");
                        //    if (cache != null && cache.DataSource != null)
                        //    {
                        //        DataView view = ((DataTable)cache.DataSource).DefaultView;
                        //        view.RowFilter = "[deptid_chr] = '" + m_objViewer.m_StrDeptID + "' and technicallevel_chr like '5%'";
                        //        dt = SelectDistinctByField(view.ToTable(), "empid_chr");
                        //    }
                        //}
                        break;
                    case -4://�ض������»�ʿǩ������ֵ
                        //if (clsDBConnectionManager.IsDBAvailable)
                        //{
                            objDomain.m_lngGetEmployeeSignWithDept(null, 2, m_objViewer.m_StrDeptID, out dt);
                        //}
                        //else
                        //{
                        //    CacheManager cache = CacheFactory.GetCacheManager("EmployeeSign");
                        //    if (cache != null && cache.DataSource != null)
                        //    {
                        //        DataView view = ((DataTable)cache.DataSource).DefaultView;
                        //        view.RowFilter = "[deptid_chr] = '" + m_objViewer.m_StrDeptID + "' and technicallevel_chr like '4%'";
                        //        dt = SelectDistinctByField(view.ToTable(), "empid_chr");
                        //    }
                        //}
                        break;
                    case -7://Ա������������ҽ��ǩ������ֵ
                        objDomain.m_lngGetEmployeeSignWithEmployee(null, 1, m_objViewer.m_StrEmployeeID, out dt);
                        break;
                    case -8://Ա�����������»�ʿǩ������ֵ
                        objDomain.m_lngGetEmployeeSignWithEmployee(null, 2, m_objViewer.m_StrEmployeeID, out dt);
                        break;
                    case -9://Ա���������ſ�����ǩ������ֵ
                        //objDomain.m_lngGetDirectorSignWithEmployee(null, 10, m_objViewer.m_StrEmployeeID, out dt);
                        objDomain.m_lngGetEmployeeSignWithDept(null, 10, m_objViewer.m_StrDeptID, out dt);
                        break;
                    case -10://Ա���������Ż�ʿ��ǩ������ֵ
                        //objDomain.m_lngGetDirectorSignWithEmployee(null, 20, m_objViewer.m_StrEmployeeID, out dt);
                        objDomain.m_lngGetEmployeeSignWithDept(null, 20, m_objViewer.m_StrDeptID, out dt);
                        break;
                    case -11://Ա����������ȫ��Ա��ǩ������ֵ
                        objDomain.m_lngGetDirectorSignWithEmployee(null, 0, m_objViewer.m_StrEmployeeID, out dt);
                        break;

                    default://�ض�����ȫ��Ա��
                        //if (clsDBConnectionManager.IsDBAvailable)
                        //{
                            objDomain.m_lngGetEmployeeSignWithDept(null, 0, m_objViewer.m_StrDeptID, out dt);
                        //}
                        //else
                        //{
                        //    CacheManager cache = CacheFactory.GetCacheManager("EmployeeSign");
                        //    if (cache != null && cache.DataSource != null)
                        //    {
                        //        DataView view = ((DataTable)cache.DataSource).DefaultView;
                        //        view.RowFilter = "[deptid_chr] = '" + m_objViewer.m_StrDeptID + "'";
                        //        dt = SelectDistinctByField(view.ToTable(), "empid_chr");
                        //    }
                        //}
                        break;
                }
            }
            catch (Exception exp)
            {
                dt = null;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
                MessageBox.Show("�޷���ȡǩ��ֵ", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                //objDomain.Dispose();
            }
        }

        /// <summary>
        /// �Ƿ���ʾȫԺԱ��
        /// </summary>
        /// <returns></returns>
        private bool m_blnIsShowAllEmp()
        {
            //clsDigitalSign_domain objDomain = new clsDigitalSign_domain();
            int intConfig = com.digitalwave.Emr.StaticObject.clsEMR_StaticObject.s_intGetEmrSettingValue("3013");
            //long lngRes = objDomain.m_lngGetSignConfig("3013",out intConfig);
            //objDomain = null;
            if (intConfig == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// ��ȡ������ЧԱ��
        /// </summary>
        public void m_mthGetAllEmployee()
        {
            clsSignature_srv objDomain =
                (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

            try
            {
                long lngRes = objDomain.m_lngGetEmployeeSignWithoutDept(null, 0, out dt);
            }
            catch (Exception exp)
            {
                dt = null;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
                MessageBox.Show("�޷���ȡǩ��ֵ", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// ��ȡȫԺҽ����ʿǩ���б�
        /// </summary>
        public void m_thGetEmployeeAllDocAndNur()
        {
            clsSignature_srv objDomain =
                (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

            try
            {

                objDomain.m_lngGetEmployeeSignDocAndNur(null, out dt);

            }
            catch (Exception exp)
            {
                dt = null;
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
                MessageBox.Show("�޷���ȡǩ��ֵ", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                //objDomain.Dispose();
            }
        }
        /// <summary>
        /// ����б�
        /// </summary>
        /// <param name="dv">����ͼ</param>
        public void m_mthAddEmployeesToList()
        {
            try
            {
                m_objViewer.m_lsvItemList.Items.Clear();
                m_objViewer.m_lsvItemList.BeginUpdate();
                DataRowView drv = null;
                for (int i = 0; i < dv.Count; i++)
                {
                    drv = dv[i];
                    ListViewItem lsvItem = new ListViewItem(m_mthGetStr(drv[1].ToString()));//����
                    lsvItem.SubItems.Add(m_mthGetStr(drv[2].ToString()));//ְ��
                    lsvItem.SubItems.Add(m_mthGetStr(drv[0].ToString()));//����
                    lsvItem.SubItems.Add(m_mthGetStr(drv[3].ToString()));//������
                    lsvItem.SubItems.Add(m_mthGetStr(drv[4].ToString()));
                    lsvItem.SubItems.Add(m_mthGetStr(drv[5].ToString()));
                    lsvItem.SubItems.Add(m_mthGetStr(drv[6].ToString()));
                    lsvItem.SubItems.Add(m_mthGetStr(drv[7].ToString()));
                    m_objViewer.m_lsvItemList.Items.Add(lsvItem);
                }
                if (m_objViewer.m_lsvItemList.Items.Count > 1)
                    m_objViewer.m_lsvItemList.Items[0].Selected = true;
            }
            finally
            {
                m_objViewer.m_lsvItemList.EndUpdate();
            }

        }
        /// <summary>
        /// ѡ��ǩ����
        /// </summary>
        public void m_thSelectEmployee()
        {
            try
            {
                m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (m_objViewer.m_lsvItemList.Items.Count > 0 && m_objViewer.m_lsvItemList.SelectedItems.Count > 0)
                {
                    //�Ƿ������֤
                    if (m_objViewer.m_blnIsverify)
                    {
                        #region ��֤��ʽ
                        string strReturnSetting = string.Empty;
                        clsSignature_srv objServ =
                            (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                        long lngRes = objServ.m_lngGetConfigBySettingID("3002", out strReturnSetting);
                        //objServ.Dispose();
                        if (strReturnSetting != null)
                        {
                            switch (strReturnSetting)
                            {
                                case "0"://������֤
                                    break;
                                case "1"://������֤
                                    if (!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text, m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                                        return;
                                    break;
                                case "2"://key����֤
                                    if (!m_blnCheckEmployeeSignByKey(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text, m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                                        return;
                                    break;
                                case "3"://ָ����֤
                                    if (!m_blnCheckEmployeeSignByFinger(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text, m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                                        return;
                                    break;
                                default:
                                    break;

                            }
                        }
                        #endregion

                        if (m_objViewer.m_StrEmployeeID != m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text)
                        {
                            frmVerifyByPwd frmPwd = new frmVerifyByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text);
                            if (frmPwd.ShowDialog() != DialogResult.OK)
                            {
                                MessageBox.Show("�Բ���" + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text + " ǩ��������֤ʧ�ܡ�", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //string empId = string.Empty;
                            //DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(out empId);
                            //if (dlg == DialogResult.Yes && m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text == empId)
                            //{
                            //}
                            //else
                            //{
                            //    MessageBox.Show("�Բ���" + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text + " ǩ��������֤ʧ�ܡ�", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    return;
                            //}
                        }
                    }

                    //�޸�����Ӧ��TextBoxBaseΪ����������
                    if (m_objViewer.m_objSelectedControl is TextBoxBase)
                    {
                        //case "System.Windows.Forms.TextBox":
                        TextBoxBase txt = (TextBoxBase)(m_objViewer.m_objSelectedControl);
                        if (m_objViewer.m_BlnIsMultiSignAndNoTag)
                        {
                            if (txt.Text.Trim() != string.Empty) txt.Text += ";" + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text;
                            else txt.Text = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text;
                        }
                        else
                        {
                            clsEmrEmployeeBase_VO p_objEmployeeBase1 = new clsEmrEmployeeBase_VO();
                            //Ա��������Ϣ����С���ϣ�
                            p_objEmployeeBase1.m_strEMPID_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text;
                            p_objEmployeeBase1.m_strLASTNAME_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text;//����
                            p_objEmployeeBase1.m_strTECHNICALRANK_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text;//ְ��
                            p_objEmployeeBase1.m_strEMPNO_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[2].Text;//����
                            p_objEmployeeBase1.m_strPYCODE_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[3].Text;//������
                            p_objEmployeeBase1.m_strEMPKEY_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[6].Text;
                            p_objEmployeeBase1.m_strEMPPWD_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text;
                            p_objEmployeeBase1.m_strLEVEL_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text;
                            p_objEmployeeBase1.m_StrHistroyLevel = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text;
                            p_objEmployeeBase1.m_strTechnicalRank = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text;//ְ��
                            p_objEmployeeBase1.m_intSTATUS_INT = -9;
                            if (m_objViewer.m_BlnIsShowLevel)
                            {
                                p_objEmployeeBase1.m_blnIsShowTechnicalRank = true;
                                txt.Text = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text + " " + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text;
                            }
                            else
                            {
                                p_objEmployeeBase1.m_blnIsShowTechnicalRank = false;
                                txt.Text = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text;
                            }
                            txt.Tag = p_objEmployeeBase1;
                        }
                    }
                    else if (m_objViewer.m_objSelectedControl is ListView)
                    {
                        //case "System.Windows.Forms.ListView" :
                        ListView lsv = (ListView)(m_objViewer.m_objSelectedControl);
                        for (int i = 0; i < lsv.Items.Count; i++)
                        {
                            if (m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text == lsv.Items[i].SubItems[1].Text)//ID�Ƚ�
                            {
                                MessageBox.Show("�Բ���ǩ�������ظ���������ѡ��", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        //����
                        ListViewItem lviNewItem = null; // + "(" + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text + ")");
                        if (m_objViewer.m_BlnIsShowLevel)
                        {
                            lviNewItem = new ListViewItem(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text + " " + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text);
                        }
                        else
                        {
                            lviNewItem = new ListViewItem(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text);
                        }
                        //ID ����ظ���
                        lviNewItem.SubItems.Add(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text);
                        //���� ������
                        lviNewItem.SubItems.Add(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text);
                        lviNewItem.SubItems.Add(string.Empty);

                        clsEmrEmployeeBase_VO p_objEmployeeBase = new clsEmrEmployeeBase_VO();
                        //Ա��������Ϣ����С���ϣ�
                        p_objEmployeeBase.m_strEMPID_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text;
                        p_objEmployeeBase.m_strLASTNAME_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text;//����
                        p_objEmployeeBase.m_strTECHNICALRANK_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text;//ְ��
                        p_objEmployeeBase.m_strTechnicalRank = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text;//ְ��
                        p_objEmployeeBase.m_strEMPNO_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[2].Text;//����
                        p_objEmployeeBase.m_strPYCODE_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[3].Text;//������
                        p_objEmployeeBase.m_strEMPKEY_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[6].Text;
                        p_objEmployeeBase.m_strEMPPWD_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text;
                        p_objEmployeeBase.m_strLEVEL_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text;
                        p_objEmployeeBase.m_StrHistroyLevel = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text;
                        p_objEmployeeBase.m_intSTATUS_INT = -9;
                        p_objEmployeeBase.m_blnIsShowTechnicalRank = m_objViewer.m_BlnIsShowLevel;

                        lviNewItem.Tag = p_objEmployeeBase;

                        //��ְ֤�Ƹߵ���ǰ�� ����
                        lsv.Items.Add(lviNewItem);
                        if (m_objViewer.m_BlnIsSortingByLevel)
                        {
                            clsListViewColumnSorter lsvs = new clsListViewColumnSorter(false);
                            lsvs.m_IntColumn = 2;
                            lsv.ListViewItemSorter = lsvs;
                            lsv.Sort();
                        }
                    }

                    if (m_objViewer.chkMul.Checked == false)
                    {
                        m_objViewer.DialogResult = DialogResult.OK;
                        m_objViewer.Close();
                    }

                }

            }
            finally
            {
                m_objViewer.Cursor = System.Windows.Forms.Cursors.Default;
            }

        }
        /// <summary>
        /// key����֤ǩ����
        /// ������ѡ��ǩ����ʱ��ʹ��
        /// </summary>
        /// <param name="p_strEmployeeID"></param>
        /// <param name="p_strEmployeeName"></param>
        /// <returns></returns>
        private bool m_blnCheckEmployeeSignByKey(string p_strEmployeeID, string p_strEmployeeName)
        {
            try
            {

                //key������
                clsDigitalSign objsign = new clsDigitalSign();
                //��ȡ֤��
                clsSignCert_VO objCert = new clsSignCert_VO();
                long lngR = objsign.GetSpecifyCert(out objCert);
                if (objCert == null)
                {
                    MessageBox.Show("��ⲻ��Key�̡����ܼ������в���", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                //����֤�Ƿ�ǩ���ߵ�Key
                if (m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[6].Text.Trim() != objCert.m_strSerialNumber.Trim())
                {
                    MessageBox.Show("��⵽key��֤���ָ����ǩ���߲�һ�£�����ͨ����֤", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                //����ǩ��ʹ�������봰��
                string strContentTemp = null;
                strContentTemp = objsign.sign("1", 0);
                if (strContentTemp == null)
                {
                    MessageBox.Show("key��У��ʧ�ܣ���ȷ���Ѳ���key��!", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                //����
                return true;
            }
            catch (Exception exp)
            {
                //MessageBox.Show("δ�ܼ�⵽key��,ȷ���Ƿ����key��","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
                return false;
            }

        }

        /// <summary>
        /// ������֤ǩ����
        /// ������ѡ��ǩ����ʱ��ʹ��
        /// </summary>
        /// <param name="p_strEmployeeID"></param>
        /// <param name="p_strEmployeeName"></param>
        /// <returns></returns>
        private bool m_blnCheckEmployeeSignByPwd(string p_strEmployeeID, string p_strEmployeeName)
        {
            try
            {
                //				frmVerifyByPwd objCheck = new frmVerifyByPwd(p_strEmployeeID,p_strEmployeeName);
                //
                //				objCheck.ShowDialog(this);
                //
                //				if(objCheck.m_LngRes > 0 && objCheck.m_BlnIsPass)
                //				{
                //					return true;
                //				}
                //				else if(objCheck.m_LngRes > 0 && !objCheck.m_BlnIsPass)
                //				{
                //					MessageBox.Show("������֤ʧ�ܣ�����ͨ����֤��","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                //		
                //					return false;
                //				}
                //				else
                //				{
                return false;
                //				}
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
                return false;
            }

        }

        /// <summary>
        /// ָ����֤ǩ����
        /// ������ѡ��ǩ����ʱ��ʹ��
        /// </summary>
        /// <param name="p_strEmployeeID"></param>
        /// <param name="p_strEmployeeName"></param>
        /// <returns></returns>
        private bool m_blnCheckEmployeeSignByFinger(string p_strEmployeeID, string p_strEmployeeName)
        {
            try
            {
                //δʵ��
                return false;
            }
            catch (Exception exp)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
                return false;
            }

        }
        /// <summary>
        /// ���ֶν���trim����
        /// </summary>
        /// <param name="strin">����ֵ</param>
        /// <returns>����ֵ</returns>
        private string m_mthGetStr(string strin)
        {
            string strOut = "";
            try
            {
                if (strin == null)
                    return strOut;
                return strin.Trim();
            }
            catch
            {
                return strOut;
            }



        }

        #endregion

    }
}
