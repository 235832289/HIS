using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using com.digitalwave.emr.DigitalSign;//电子签名
using iCareData;
using com.digitalwave.Emr.Signature_srv;
//using com.digitalwave.Emr.Signature_gui;
using iCare.Anaesthesia.Framework;
//using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.Emr.Signature_gui
{
    /// <summary>
    /// clsCommonUsePanelController 的摘要说明。
    /// </summary>
    public class clsCommonUsePanelController
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCommonUsePanelController(object objviewer)
        {
            //设置viewer对象
            m_objViewer = (frmCommonUsePanel)objviewer;
        }
        #endregion


        #region 字段
        /// <summary>
        /// viewer对象
        /// </summary>
        private frmCommonUsePanel m_objViewer;
        /// <summary>
        /// 签名列表
        /// </summary>
        private DataTable dt = new DataTable();
        /// <summary>
        /// 签名列表视图
        /// </summary>
        private DataView dv = new DataView();
        #endregion

        #region 方法
        /// <summary>
        /// load方法
        /// </summary>
        public void m_thLoad()
        {
            try
            {
                m_thGetEmployee();
                if (dt == null)
                {
                    throw new Exception("m_thGetEmployee()查询没有结果！");
                }
                dv = dt.DefaultView;
                m_mthAddEmployeesToList();
                m_mthCheckSortConfig();

                if (!m_blnIsCustomSetting)
                {
                    m_objViewer.m_BlnIsShowLevel = m_blnIsShowEmpLevel();
                }
                m_objViewer.m_BlnIsShowAllEmployee = m_blnIsShowAllEmp();
                //限制显示
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
        /// 是否显示职称
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
        /// 检查排序配置
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
        /// 获取全院医生护士方法
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
        /// 输入框改变事件
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
        ///   过滤DataTable中的指定字段重复的行 
        ///   </summary> 
        ///   <param   name= "dt "> </param> 
        ///   <param   name= "FieldName "> </param> 
        ///   <returns> </returns> 
        private DataTable SelectDistinctByField(DataTable dt, string FieldName)
        {
            DataTable returnDt = new DataTable();
            returnDt = dt.Copy();//将原DataTable复制一个新的 
            DataRow[] drs = returnDt.Select(" ", FieldName);//将DataTable按指定的字段排序 
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
        /// 获取签名列表
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
                    case -1://医生签名常用值

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
                    case -2://护士签名常用值
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
                    case -5://全部员工常用值
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
                    case -3://特定部门医生签名常用值
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
                    case -4://特定部门下护士签名常用值
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
                    case -7://员工所属部门下医生签名常用值
                        objDomain.m_lngGetEmployeeSignWithEmployee(null, 1, m_objViewer.m_StrEmployeeID, out dt);
                        break;
                    case -8://员工所属部门下护士签名常用值
                        objDomain.m_lngGetEmployeeSignWithEmployee(null, 2, m_objViewer.m_StrEmployeeID, out dt);
                        break;
                    case -9://员工所属部门科主任签名常用值
                        //objDomain.m_lngGetDirectorSignWithEmployee(null, 10, m_objViewer.m_StrEmployeeID, out dt);
                        objDomain.m_lngGetEmployeeSignWithDept(null, 10, m_objViewer.m_StrDeptID, out dt);
                        break;
                    case -10://员工所属部门护士长签名常用值
                        //objDomain.m_lngGetDirectorSignWithEmployee(null, 20, m_objViewer.m_StrEmployeeID, out dt);
                        objDomain.m_lngGetEmployeeSignWithDept(null, 20, m_objViewer.m_StrDeptID, out dt);
                        break;
                    case -11://员工所属部门全部员工签名常用值
                        objDomain.m_lngGetDirectorSignWithEmployee(null, 0, m_objViewer.m_StrEmployeeID, out dt);
                        break;

                    default://特定部门全部员工
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
                MessageBox.Show("无法获取签名值", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                //objDomain.Dispose();
            }
        }

        /// <summary>
        /// 是否显示全院员工
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
        /// 获取所有有效员工
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
                MessageBox.Show("无法获取签名值", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 获取全院医生护士签名列表
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
                MessageBox.Show("无法获取签名值", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            finally
            {
                //objDomain.Dispose();
            }
        }
        /// <summary>
        /// 填充列表
        /// </summary>
        /// <param name="dv">表视图</param>
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
                    ListViewItem lsvItem = new ListViewItem(m_mthGetStr(drv[1].ToString()));//姓名
                    lsvItem.SubItems.Add(m_mthGetStr(drv[2].ToString()));//职称
                    lsvItem.SubItems.Add(m_mthGetStr(drv[0].ToString()));//工号
                    lsvItem.SubItems.Add(m_mthGetStr(drv[3].ToString()));//助记码
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
        /// 选择签名者
        /// </summary>
        public void m_thSelectEmployee()
        {
            try
            {
                m_objViewer.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                if (m_objViewer.m_lsvItemList.Items.Count > 0 && m_objViewer.m_lsvItemList.SelectedItems.Count > 0)
                {
                    //是否身份验证
                    if (m_objViewer.m_blnIsverify)
                    {
                        #region 验证方式
                        string strReturnSetting = string.Empty;
                        clsSignature_srv objServ =
                            (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                        long lngRes = objServ.m_lngGetConfigBySettingID("3002", out strReturnSetting);
                        //objServ.Dispose();
                        if (strReturnSetting != null)
                        {
                            switch (strReturnSetting)
                            {
                                case "0"://无需验证
                                    break;
                                case "1"://密码验证
                                    if (!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text, m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                                        return;
                                    break;
                                case "2"://key盘验证
                                    if (!m_blnCheckEmployeeSignByKey(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text, m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text))
                                        return;
                                    break;
                                case "3"://指纹验证
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
                                MessageBox.Show("对不起，" + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text + " 签名密码认证失败。", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                            //string empId = string.Empty;
                            //DialogResult dlg = com.digitalwave.iCare.gui.HIS.clsPublic.m_dlgConfirm(out empId);
                            //if (dlg == DialogResult.Yes && m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text == empId)
                            //{
                            //}
                            //else
                            //{
                            //    MessageBox.Show("对不起，" + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text + " 签名密码认证失败。", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //    return;
                            //}
                        }
                    }

                    //修改以适应以TextBoxBase为基类的输入框
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
                            //员工基本信息（最小集合）
                            p_objEmployeeBase1.m_strEMPID_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text;
                            p_objEmployeeBase1.m_strLASTNAME_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text;//姓名
                            p_objEmployeeBase1.m_strTECHNICALRANK_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text;//职称
                            p_objEmployeeBase1.m_strEMPNO_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[2].Text;//工号
                            p_objEmployeeBase1.m_strPYCODE_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[3].Text;//助记码
                            p_objEmployeeBase1.m_strEMPKEY_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[6].Text;
                            p_objEmployeeBase1.m_strEMPPWD_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text;
                            p_objEmployeeBase1.m_strLEVEL_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text;
                            p_objEmployeeBase1.m_StrHistroyLevel = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text;
                            p_objEmployeeBase1.m_strTechnicalRank = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text;//职称
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
                            if (m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text == lsv.Items[i].SubItems[1].Text)//ID比较
                            {
                                MessageBox.Show("对不起，签名不能重复，请重新选择！", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                        //名称
                        ListViewItem lviNewItem = null; // + "(" + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text + ")");
                        if (m_objViewer.m_BlnIsShowLevel)
                        {
                            lviNewItem = new ListViewItem(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text + " " + m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text);
                        }
                        else
                        {
                            lviNewItem = new ListViewItem(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text);
                        }
                        //ID 检查重复用
                        lviNewItem.SubItems.Add(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text);
                        //级别 排序用
                        lviNewItem.SubItems.Add(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text);
                        lviNewItem.SubItems.Add(string.Empty);

                        clsEmrEmployeeBase_VO p_objEmployeeBase = new clsEmrEmployeeBase_VO();
                        //员工基本信息（最小集合）
                        p_objEmployeeBase.m_strEMPID_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text;
                        p_objEmployeeBase.m_strLASTNAME_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text;//姓名
                        p_objEmployeeBase.m_strTECHNICALRANK_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text;//职称
                        p_objEmployeeBase.m_strTechnicalRank = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[1].Text;//职称
                        p_objEmployeeBase.m_strEMPNO_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[2].Text;//工号
                        p_objEmployeeBase.m_strPYCODE_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[3].Text;//助记码
                        p_objEmployeeBase.m_strEMPKEY_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[6].Text;
                        p_objEmployeeBase.m_strEMPPWD_VCHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text;
                        p_objEmployeeBase.m_strLEVEL_CHR = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text;
                        p_objEmployeeBase.m_StrHistroyLevel = m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[7].Text;
                        p_objEmployeeBase.m_intSTATUS_INT = -9;
                        p_objEmployeeBase.m_blnIsShowTechnicalRank = m_objViewer.m_BlnIsShowLevel;

                        lviNewItem.Tag = p_objEmployeeBase;

                        //保证职称高的在前面 排序
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
        /// key盘验证签名者
        /// 适用于选择签名的时候使用
        /// </summary>
        /// <param name="p_strEmployeeID"></param>
        /// <param name="p_strEmployeeName"></param>
        /// <returns></returns>
        private bool m_blnCheckEmployeeSignByKey(string p_strEmployeeID, string p_strEmployeeName)
        {
            try
            {

                //key操作类
                clsDigitalSign objsign = new clsDigitalSign();
                //获取证书
                clsSignCert_VO objCert = new clsSignCert_VO();
                long lngR = objsign.GetSpecifyCert(out objCert);
                if (objCert == null)
                {
                    MessageBox.Show("检测不到Key盘。不能继续进行操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                //先验证是否签名者的Key
                if (m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[6].Text.Trim() != objCert.m_strSerialNumber.Trim())
                {
                    MessageBox.Show("检测到key盘证书和指定的签名者不一致，不能通过验证", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                //虚拟签名使弹出密码窗口
                string strContentTemp = null;
                strContentTemp = objsign.sign("1", 0);
                if (strContentTemp == null)
                {
                    MessageBox.Show("key盘校验失败，请确认已插入key盘!", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

                //返回
                return true;
            }
            catch (Exception exp)
            {
                //MessageBox.Show("未能检测到key盘,确认是否插入key盘","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(exp);
                return false;
            }

        }

        /// <summary>
        /// 密码验证签名者
        /// 适用于选择签名的时候使用
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
                //					MessageBox.Show("密码验证失败，不能通过验证。","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
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
        /// 指纹验证签名者
        /// 适用于选择签名的时候使用
        /// </summary>
        /// <param name="p_strEmployeeID"></param>
        /// <param name="p_strEmployeeName"></param>
        /// <returns></returns>
        private bool m_blnCheckEmployeeSignByFinger(string p_strEmployeeID, string p_strEmployeeName)
        {
            try
            {
                //未实现
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
        /// 对字段进行trim处理
        /// </summary>
        /// <param name="strin">传入值</param>
        /// <returns>传出值</returns>
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
