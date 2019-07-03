using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.IO;
using System.Data.OleDb;

namespace com.digitalwave.iCare.gui.HIS
{   
    /// <summary>
    /// ҩ����湫����
    /// </summary>
    public class clsPub
    {
        /// <summary>
        /// ҩƷ������Ϣ��
        /// </summary>
        public static DataTable m_dtMedicineInfo=null;
        /// <summary>
        /// ��ʼ�����������Ϣ
        /// </summary>
        public static long m_mthBorrowDeptInfo(out DataTable m_dtDept)
        {
            long lngRes = -1;
            m_dtDept = new DataTable();
            clsDcl_AskForMedicine m_objDomain = new clsDcl_AskForMedicine();
            lngRes = m_objDomain.m_lngGetApplyDept(out m_dtDept);
            return lngRes;
        }
        /// <summary>
        /// ��ȡҩƷ������Ϣ��
        /// </summary>
        /// <param name="m_dtMedInfo"></param>
        public static void m_mthGetMedBaseInfo(string m_strMedStoreid,out DataTable m_dtMedInfo)
        {
            m_dtMedInfo = new DataTable();
            clsDcl_AskForMedDetail m_objDomain = new clsDcl_AskForMedDetail();
            m_objDomain.m_lngGetMedicineInfo(m_strMedStoreid,out m_dtMedInfo);

        }
        /// <summary>
        /// ��ȡҩ������ҩƷ������Ϣ
        /// </summary>
        /// <param name="m_dtMedInfo"></param>
        public static void m_mthGetOutStorageMedBaseInfo(bool p_blnIsHospital,string m_strMedStoreid, out DataTable m_dtMedInfo)
        {
            m_dtMedInfo = new DataTable();
            clsDcl_AskForMedDetail m_objDomain = new clsDcl_AskForMedDetail();
            m_objDomain.m_lngGetOutStorageMedicineInfo(p_blnIsHospital,m_strMedStoreid, out m_dtMedInfo);

        }
        /// <summary>
        /// ��ȡҩƷ������Ϣ��
        /// </summary>
        public static void m_mthGetMedBaseInfo(string m_strMedStoreid)
        {
           // if (m_dtMedicineInfo != null) return;
            clsDcl_AskForMedDetail m_objDomain = new clsDcl_AskForMedDetail();
            m_objDomain.m_lngGetMedicineInfo(m_strMedStoreid,out m_dtMedicineInfo);
        }
        /// <summary>
        /// ��ȡҩƷ������Ϣ��(����ҩ������)
        /// </summary>
        /// <param name="m_dtMedInfo"></param>
        public static void m_mthGetMedBaseInfo(string m_strMedStoreid, string p_strStorageID,out DataTable m_dtMedInfo)
        {
            m_dtMedInfo = new DataTable();
            clsDcl_AskForMedDetail m_objDomain = new clsDcl_AskForMedDetail();
            m_objDomain.m_lngGetMedicineInfoWithStorageID(m_strMedStoreid, p_strStorageID, out m_dtMedInfo);

        }
        #region ��ȡ���ⲿ����Ϣ
        /// <summary>
        /// ��ȡ���ⲿ����Ϣ
        /// </summary>
        /// <param name="m_strStorageid"></param>
        /// <returns></returns>
        public static string m_lngGetExportDeptByid(string m_strStorageid)
        {
            long lngRes = 0;
            DataTable m_dtExportDept = new DataTable();
            com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC objSvc =
                (com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsAskForMedicine_Supported_SVC));
            lngRes = objSvc.m_lngGetExportDept(null, out m_dtExportDept);
            if (lngRes > 0 && m_dtExportDept.Rows.Count > 0)
            {
                string m_strFilter = "medicineroomid=" + m_strStorageid;
                DataRow[] drArr = m_dtExportDept.Select(m_strFilter);
                if (drArr != null && drArr.Length == 1)
                {
                    return  drArr[0]["medicineroomname"].ToString();;
                }
                else
                    return string.Empty;
            }
            else
                return string.Empty;
        }
        #endregion
        #region ��ȡ����ҩ��������Ϣ��
        /// <summary>
        ///  ��ȡ����ҩ��������Ϣ��
        /// </summary>
        /// <param name="m_dtMedStore"></param>
        /// <returns></returns>
        public static long m_lngGetMedStoreInfo(out DataTable m_dtMedStore)
        {
            long lngRes = 0;
            clsDcl_InStorageMakerOrder objDomain = new clsDcl_InStorageMakerOrder();
            lngRes = objDomain.m_lngGetMedStoreInfo(out m_dtMedStore);
            return lngRes;
        }
        #endregion
        /// <summary>
        /// ����ҩ��id��ȡҩ������
        /// </summary>
        /// <param name="m_strMedStoreid"></param>
        /// <returns></returns>
        public static clsMedStore_VO m_mthGetMedStoreNameByid(string m_strMedStoreid)
        {
            long lngRes = 0;
            clsMedStore_VO m_objReturnVo = new clsMedStore_VO();
            DataTable m_dtMedStore=new DataTable();
            clsDcl_InStorageMakerOrder objDomain = new clsDcl_InStorageMakerOrder();
            lngRes = objDomain.m_lngGetMedStoreInfo(out m_dtMedStore);
            if (lngRes > 0 && m_dtMedStore.Rows.Count > 0)
            {
                string m_strFilter = "medstoreid_chr=" + m_strMedStoreid;
                DataRow[] drArr = m_dtMedStore.Select(m_strFilter);
                if (drArr != null && drArr.Length == 1)
                {
                    m_objReturnVo.m_strMedStoreID = m_strMedStoreid;
                    m_objReturnVo.m_strMedStoreName=drArr[0]["medstorename_vchr"].ToString();
                    m_objReturnVo.m_strDeptid = drArr[0]["deptid_chr"]==DBNull.Value?string.Empty:drArr[0]["deptid_chr"].ToString();
                    m_objReturnVo.m_strDeptName = drArr[0]["deptname_vchr"] == DBNull.Value ? string.Empty : drArr[0]["deptname_vchr"].ToString();
                    return m_objReturnVo;
                }
                else
                    return null;
            }
            else
                return null;
        }
        /// <summary>
        /// ����F4��
        /// </summary>
        public static void m_mthSendF4()
        {
            System.Windows.Forms.SendKeys.Send("{F4}");
            System.Windows.Forms.SendKeys.Send("{Down}");
        }
        /// <summary>
        /// ����Tab��
        /// </summary>
        public static void m_mthSendTab(object sender, KeyEventArgs e)
        {  
            if(e.KeyCode==Keys.Enter)
            System.Windows.Forms.SendKeys.Send("{TAB}");
        }
        /// <summary>
        /// ǿ���ͷ�ģʽ������Դ
        /// </summary>
        /// <param name="objForm"></param>
        public static void m_mthDispose(Form objForm)
        {
            if (objForm == null) return;
            foreach (Control ctl in objForm.Controls)
            {
                Application.DoEvents();
                ctl.Dispose();
            }
            objForm.Dispose();
        }
        /// <summary>
        /// ��ȡ���������
        /// </summary>
        /// <param name="p_intType">0Ϊ��⣬1Ϊ����</param>
        /// <param name="p_dtStoreType"></param>
        internal static void m_lngGetTypeCode(Int16 p_intType, out DataTable p_dtStoreType)
        {
            p_dtStoreType = null;
            clsDcl_Instorage m_objDomain = new clsDcl_Instorage();
            m_objDomain.m_lngGetTypeCode(p_intType, out p_dtStoreType);
        }

        #region ��ȡ��ǰԱ���Ƿ���ҩ�������ɫ
        /// <summary>
        /// ��ȡ��ǰԱ���Ƿ���ҩ�������ɫ
        /// </summary>
        /// <param name="p_strEmpID">Ա��ID</param>
        /// <param name="p_blnHasRole">�Ƿ���ҩ�������ɫ</param>
        /// <returns></returns>
        internal static void m_lngCheckEmpHasRole(string p_strEmpID, out bool p_blnHasRole)
        {
            p_blnHasRole = false;
            clsDcl_Instorage m_objDomain = new clsDcl_Instorage();
            m_objDomain.m_lngCheckEmpHasRole(p_strEmpID, out p_blnHasRole);
        }
        #endregion

        /// <summary>
        /// �����������ƻ�ȡ���������ID
        /// </summary>        
        /// <param name="p_intFlag">0-��⣻1-����</param>
        /// <param name="p_strTypeName">��������</param>
        /// <param name="p_intTypeCode"></param>
        internal static void m_lngGetTypeCodeByName(int p_intFlag,string p_strTypeName, out int p_intTypeCode)
        {
            p_intTypeCode = 0;
            clsDcl_MakeOutStorageOrder m_objDomain = new clsDcl_MakeOutStorageOrder();
            m_objDomain.m_lngGetTypeCodeByName(p_intFlag, p_strTypeName, out p_intTypeCode);
        }

        #region ��ȡ�Ƿ�������˰�ť
        /// <summary>
        /// ��ȡ�Ƿ�������˰�ť
        /// </summary>
        /// <returns></returns>
        public static bool m_blnCommitEnabled()
        {
            int p_intCommit = 0;
            clsDcl_InStorageMakerOrder m_objDomain = new clsDcl_InStorageMakerOrder();
            m_objDomain.m_lngGetCommitFlow(out p_intCommit);
            return p_intCommit == 0;
        }
        #endregion
        #region �����񵼳����ݵ�Excel
        /// <summary>
        /// �����񵼳����ݵ�Excel
        /// </summary>
        public static void m_mthExportToExcel(System.Windows.Forms.DataGridView dgv)
        {
            DataTable dtExport = new DataTable("dtExoprt");

            string strColName = "";
            int intSame = 1;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (dgv.Columns[i].Visible == false)
                {
                    continue;
                }

                strColName = dgv.Columns[i].HeaderText.Replace("(", "").Replace(")", "").Replace(".", "").Trim();
                if (strColName == "No")
                    strColName = "���";
                //��ֹ���������ж����������ɽ��˴�����̸�Ϊ�ݹ飩
                if (dtExport.Columns.Contains(strColName))
                {
                    strColName = strColName + intSame.ToString();
                    intSame++;
                }

                if (dgv.Columns[i].ValueType == null)
                {
                    dtExport.Columns.Add(strColName, typeof(string));
                }
                else if (dgv.Columns[i].ValueType.FullName.ToLower() == "system.numeric" || dgv.Columns[i].ValueType.FullName.ToLower() == "system.decimal")
                {
                    dtExport.Columns.Add(strColName, typeof(decimal));
                }
                else
                {
                    dtExport.Columns.Add(strColName, typeof(string));
                }
            }

            DataRow dr;
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dr = dtExport.NewRow();

                int row = 0;
                for (int j = 0; j < dgv.Columns.Count; j++)
                {                   
                    if (dgv.Columns[j].Visible == false)
                    {
                        continue;
                    }

                    dr[row] = dgv.Rows[i].Cells[j].Value;
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
                MessageBox.Show("����Excel�ɹ���", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("����Excelʧ�ܡ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

            dtExport.Dispose();
            dsExport.Tables.Clear();
            dsExport.Dispose();
        }

        /// <summary>
        /// д��Excel
        /// </summary>
        /// <param name="dsSource"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool m_mthExport(DataSet dsSource, string fileName)
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

        #region ��ȡ�м����������ǰʱ��
        /// <summary>
        /// ��ȡ�м����������ǰʱ��
        /// </summary>
        public static DateTime CurrentDateTimeNow
        {
            get
            {
                DateTime m_dtmDateTime = DateTime.Now;
                clsDcl_AskForMedDetail objDomain = new clsDcl_AskForMedDetail();
                objDomain.m_lngGetCurrentDateTime(out m_dtmDateTime);
                return m_dtmDateTime;
            }
        }
        #endregion
        /// <summary>
        /// ��excel�ļ���ȡ���ݱ�
        /// </summary>
        /// <param name="m_strFileName">excel�ļ���</param>
        /// <param name="m_strMsg">�쳣��Ϣ</param>
        /// <returns></returns>
        public static DataTable m_mthShowValues(string m_strFileName, out string m_strMsg)
        {
            m_strMsg = string.Empty;
            //���һ����Ԫ��
            string m_strArg = string.Empty;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook wb = null;
            System.Data.DataTable m_dtResult = null;
            object missing = System.Reflection.Missing.Value;
            try
            {
                wb = excel.Workbooks.Open(m_strFileName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                excel.Visible = false;
                Excel.Worksheet wbs = (Excel.Worksheet)wb.Worksheets.get_Item((object)1);
                Excel.Range workingrangecells = null;
                int m_intRowCount = 0;
                for (int i = 1; i <= wbs.Rows.Count; i++)
                {
                    workingrangecells = wbs.get_Range("A" + i.ToString(), System.Type.Missing);


                    if (workingrangecells.Value2 != null && workingrangecells.Value2.ToString() != string.Empty)
                        m_intRowCount++;
                    else
                    {
                        m_strArg = "H" + m_intRowCount.ToString();
                        break;
                    }
                }
                workingrangecells = wbs.get_Range(string.Format("A1:{0}", m_strArg), System.Type.Missing);

                System.Array objArr = (System.Array)workingrangecells.Cells.Value2;
                string[] strArr = ConvertToStringArray(objArr);
                if (strArr == null || strArr.Length == 0) return null;
                m_dtResult = new DataTable();
                DataColumn dtColumn = null;
                dtColumn = new DataColumn(strArr[0], typeof(string));
                m_dtResult.Columns.Add(dtColumn);
                dtColumn = new DataColumn(strArr[1], typeof(string));
                m_dtResult.Columns.Add(dtColumn);
                dtColumn = new DataColumn(strArr[2], typeof(string));
                m_dtResult.Columns.Add(dtColumn);
                dtColumn = new DataColumn(strArr[3], typeof(string));
                m_dtResult.Columns.Add(dtColumn);
                dtColumn = new DataColumn(strArr[4], typeof(string));
                m_dtResult.Columns.Add(dtColumn);
                dtColumn = new DataColumn(strArr[5], typeof(double));
                m_dtResult.Columns.Add(dtColumn);
                dtColumn = new DataColumn(strArr[6], typeof(double));
                m_dtResult.Columns.Add(dtColumn);
                dtColumn = new DataColumn(strArr[7], typeof(double));
                m_dtResult.Columns.Add(dtColumn);
                DataRow drTemp = null;
                for (int i = 8; i < strArr.Length; i++)
                {
                    drTemp = m_dtResult.NewRow();
                    drTemp[0] = strArr[i++];
                    drTemp[1] = strArr[i++];
                    drTemp[2] = strArr[i++];
                    drTemp[3] = strArr[i++];
                    drTemp[4] = strArr[i++];
                    drTemp[5] = Convert.ToDouble(strArr[i++]);
                    drTemp[6] = Convert.ToDouble(strArr[i++]);
                    drTemp[7] = Convert.ToDouble(strArr[i]);
                    m_dtResult.Rows.Add(drTemp);
                }
                stopExcel(excel);
            }
            catch (Exception ex)
            {
                stopExcel(excel);
                m_dtResult = null;
                m_strMsg = ex.Message.ToString();
            }

            return m_dtResult;

        }
        #region ת��Ϊ�ַ�������
        /// <summary>
        /// ת��Ϊ�ַ�������
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        static string[] ConvertToStringArray(System.Array values)
        {
            string[] newArray = new string[values.Length];

            int index = 0;
            for (int i = values.GetLowerBound(0); i <= values.GetUpperBound(0); i++)
            {
                for (int j = values.GetLowerBound(1); j <= values.GetUpperBound(1); j++)
                {
                    if (values.GetValue(i, j) == null)
                    {
                        newArray[index] = "";
                    }
                    else
                    {
                        newArray[index] = (string)values.GetValue(i, j).ToString();
                    }
                    index++;
                }
            }
            return newArray;
        }
        #endregion
        #region �ر�Excel.exe����
        /// <summary>
        /// �ر�Excel.exe����
        /// </summary>
        /// <param name="excel"></param>
        static void stopExcel(Excel.Application excel)
        {
            if (excel != null)
            {
                System.Diagnostics.Process[] pProcess;
                pProcess = System.Diagnostics.Process.GetProcessesByName("Excel");
                if (pProcess != null)
                {
                    if (pProcess.Length > 1)
                    {                        
                        pProcess[pProcess.Length - 1].Kill();
                    }
                    else
                    {
                        pProcess[0].Kill();
                    }
                }
            }
        }
        #endregion

        #region ��ȡ��������ǰʱ��
        /// <summary>
        /// ��ȡ��������ǰʱ��
        /// </summary>
        public static DateTime ServerDateTimeNow
        {
            get
            {
                DateTime m_dtmDateTime = DateTime.Now;
                clsDcl_AskForMedDetail m_objDomain = new clsDcl_AskForMedDetail();
                m_objDomain.m_lngGetSystemDateTime(out m_dtmDateTime);                
                return m_dtmDateTime;
            }
        }
        #endregion
    }
}
