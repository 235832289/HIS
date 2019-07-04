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
        #region 变量/属性
        /// <summary>
        /// 数据库类型 SQL:sql; ORACLE:oracle
        /// </summary>
        private string m_strDbType = "sql";
        /// <summary>
        /// 获取或设置数据库类型 SQL:sql; ORACLE:oracle
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
        /// sql连接串
        /// </summary>
        private string m_strSqlConnStrType = @"server = {0}; initial catalog = {1}; user id = {2}; password = {3}";
        /// <summary>
        /// oracle连接串
        /// </summary>
        private string m_strOracleConnStrType = @"data source = {0};user = {1}; password = {2}";

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string m_strDbConnStr = string.Empty;
        /// <summary>
        /// 获取或设置数据库连接字符串
        /// </summary>
        public string m_StrDbConnStr
        {
            set 
            {
                m_strDbConnStr = value;
                //解析数据库连接串

            }
            get
            {
                return m_strDbConnStr;
            }
        }
        #endregion

        #region 构造器 
        /// <summary>
        /// 构造器
        /// </summary>
        public frmDbConfig()
        {
            InitializeComponent();
        }
        #endregion

        #region 构建数据库连接字符串
        /// <summary>
        /// 构建数据库连接字符串
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

        #region 保存配置
        /// <summary>
        /// 保存配置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnSave_Click(object sender, EventArgs e)
        {
            m_strDbConnStr = m_strCreateConnStr();
            m_strDbType = m_cboType.Text;
            //保存配置到INI文件
            try
            {
                clsIniFileIO.m_mthWriteIniFile("DbConfig.ini", "DbType", m_strDbType);
                clsIniFileIO.m_mthWriteIniFile("DbConfig.ini", "ConnectionString", m_strDbConnStr);
                MessageBox.Show("配置保存成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("配置保存失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 关闭窗体
        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region 比较字符串是否相等,不区分大小写
        /// <summary>
        /// 比较字符串是否相等,不区分大小写
        /// </summary>
        /// <param name="p_strA"></param>
        /// <param name="p_strB"></param>
        /// <returns></returns>
        private bool m_blnStringEqualsIgnoreCase(string p_strA, string p_strB)
        {
            return string.Compare(p_strA, p_strB, true) == 0 ? true : false; ;
        }
        #endregion

        #region 测试连接
        /// <summary>
        /// 测试连接
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
                MessageBox.Show("数据库连接成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("数据库连接成失败,请检查数据库连接配置!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
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