using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;

namespace com.digitalwave.iCare.gui.DataCollection
{
    public partial class frmDbConfig : Form
    {
        #region ����/����
        /// <summary>
        /// ���ݿ����� SQL:sql; ORACLE:oracle
        /// </summary>
        private string m_strDbType = "sql";
        /// <summary>
        /// ��ȡ���������ݿ����� SQL:sql; ORACLE:oracle
        /// </summary>
        public string m_StrDbType
        {
            set
            {
                m_strDbType = value;
                m_cboType.Text = m_strDbType;
            }
            get 
            {
                return m_strDbType;
            }
        }
        /// <summary>
        /// sql���Ӵ�
        /// </summary>
        private string m_strSqlConnStrType = @"server = {0}; initial catalog = {1}; user id = {2}; password = {3}";
        /// <summary>
        /// oracle���Ӵ�
        /// </summary>
        private string m_strOracleConnStrType = @"data source = {0};user = {1}; password = {2}";

        /// <summary>
        /// ���ݿ������ַ���
        /// </summary>
        private string m_strDbConnStr = string.Empty;
        /// <summary>
        /// ��ȡ���������ݿ������ַ���
        /// </summary>
        public string m_StrDbConnStr
        {
            set 
            {
                m_strDbConnStr = value;
                //�������ݿ����Ӵ�

            }
            get
            {
                return m_strDbConnStr;
            }
        }
        #endregion

        #region ������ 
        /// <summary>
        /// ������
        /// </summary>
        public frmDbConfig()
        {
            InitializeComponent();
        }
        #endregion

        #region �������ݿ������ַ���
        /// <summary>
        /// �������ݿ������ַ���
        /// </summary>
        /// <returns></returns>
        private string m_strCreateConnStr()
        {
            string strConnStr = string.Empty;
            string strDbType = string.Empty;

            StringBuilder sbIp = new StringBuilder(16);
            sbIp = sbIp.Append(m_txtIp1.Text.Trim()).Append(".").Append(m_txtIp2.Text.Trim()).Append(".").Append(m_txtIp3.Text.Trim()).Append(".").Append(m_txtIp4.Text.Trim());
            string strIp = sbIp.ToString().Trim();
            string strUser = m_txtUser.Text.Trim();
            string strPwd = m_txtPwd.Text.Trim();
            string strDataBase = m_txtDataBase.Text.Trim();

            strDbType = m_cboType.Text;
            if (m_blnStringEqualsIgnoreCase(strDbType, "sql"))
            {
                strConnStr = string.Format(m_strSqlConnStrType, strIp, strDataBase, strUser, strPwd);
            }
            else if (m_blnStringEqualsIgnoreCase(strDbType, "oracle"))
            {
                strConnStr = string.Format(m_strOracleConnStrType, strDataBase, strUser, strPwd);
            }

            return strConnStr;
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_strDbConnStr = m_strCreateConnStr();
            m_strDbType = m_cboType.Text;
            //�������õ�INI�ļ�
            try
            {
                clsIniFileIO.m_mthWriteIniFile("DbConfig.ini", "DbType", m_strDbType);
                clsIniFileIO.m_mthWriteIniFile("DbConfig.ini", "ConnectionString", m_strDbConnStr);
                MessageBox.Show("���ñ���ɹ�!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("���ñ���ʧ��!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region �رմ���
        /// <summary>
        /// �رմ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region �Ƚ��ַ����Ƿ����,�����ִ�Сд
        /// <summary>
        /// �Ƚ��ַ����Ƿ����,�����ִ�Сд
        /// </summary>
        /// <param name="p_strA"></param>
        /// <param name="p_strB"></param>
        /// <returns></returns>
        private bool m_blnStringEqualsIgnoreCase(string p_strA, string p_strB)
        {
            return string.Compare(p_strA, p_strB, true) == 0 ? true : false; ;
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnTest_Click(object sender, EventArgs e)
        {
            DbConnection dbConn = null;
            string strDbType = m_cboType.Text;
            if (m_blnStringEqualsIgnoreCase(strDbType, "sql"))
            {
                dbConn = new System.Data.SqlClient.SqlConnection();
            }
            else if (m_blnStringEqualsIgnoreCase(strDbType, "oracle"))
            {
                dbConn = new System.Data.OracleClient.OracleConnection();
            }
            dbConn.ConnectionString = m_strCreateConnStr();
            try
            {
                dbConn.Open();
                MessageBox.Show("���ݿ����ӳɹ�!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("���ݿ����ӳ�ʧ��,�������ݿ���������!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (dbConn != null)
                {
                    if (dbConn.State == ConnectionState.Open)
                    {
                        dbConn.Close();
                    }
                    dbConn = null;
                }
            }
        }
        #endregion

        private void m_txtIp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Decimal || e.KeyCode == Keys.Enter)
            {
                TextBox objTxt = sender as TextBox;
                string strText = objTxt.Text;
                objTxt.Text = strText.Replace(".", "");
                SendKeys.Send("{Tab}");
            }
        }

        private void m_txtIp_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Decimal || e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{Tab}");
            }
        }

        private void m_txtIp_Enter(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox objTxt = sender as TextBox;
                objTxt.SelectAll();
            }
        }

        private void m_cboType_Validating(object sender, CancelEventArgs e)
        {
            string strText = m_cboType.Text.Trim();
            if (strText.Length > 0)
            {
                strText = strText.Remove(0, 1).Insert(0, char.ToUpper(strText[0]).ToString());
            }
            m_cboType.Text = strText;
        }
    }
}