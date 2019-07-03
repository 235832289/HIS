using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
using Oracle.DataAccess.Client;

namespace CriticalValueService
{
    #region SqlHelper
    /// <summary>
    /// SqlHelper
    /// </summary>
    public class SqlHelper
    {
        #region ConnStr
        /// <summary>
        /// ConnStr
        /// </summary>
        /// <returns></returns>
        private string ConnStr(string dbKey)
        {
            string strConn = null;
            string strFile = Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName + @"\database.xml";
            if (!System.IO.File.Exists(strFile))
            {
                try
                {
                    strFile = System.AppDomain.CurrentDomain.BaseDirectory + @"\bin\database.xml";
                    if (!System.IO.File.Exists(strFile))
                    {
                        strFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\bin\database.xml";
                    }
                }
                catch
                {
                    strFile = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + @"\bin\database.xml";
                }
            }
            System.Xml.XmlDocument doc = new System.Xml.XmlDocument();
            doc.Load(strFile);

            System.Xml.XmlElement element = doc["configuration"]["DBMS"][dbKey];
            if (element == null)
            {
                element = doc["configuration"]["DBMS"][dbKey];
            }
            strConn = element.Attributes["connStr"].Value.Trim();
            element = null;
            doc = null;
            return strConn;
        }
        #endregion

        #region CreateParm

        /// <summary>
        /// 创建SQL参数
        /// </summary>
        /// <returns></returns>
        public IDataParameter CreateParm()
        {
            return CreateParm(1)[0];
        }

        /// <summary>
        /// 创建SQL参数
        /// </summary>
        /// <returns></returns>
        public IDataParameter[] CreateParm(int nums)
        {
            IDataParameter[] objParm = new OracleParameter[nums];
            for (int i = 0; i < nums; i++)
            {
                objParm[i] = new OracleParameter();
            }
            return objParm;
        }
        #endregion

        #region Get

        #region GetDataTable
        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            return GetDataTable(sql, new List<IDataParameter>());
        }
        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, IDataParameter parm)
        {
            return GetDataTable(sql, new List<IDataParameter>() { parm });
        }
        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parm"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, IDataParameter[] parm)
        {
            return (new Dac()).GetDataTable(ConnStr("onlineDB"), sql, parm);
        }
        /// <summary>
        /// GetDataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="lstParm"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql, List<IDataParameter> lstParm)
        {
            return this.GetDataTable(sql, lstParm.ToArray());
        }
        #endregion

        #endregion

        #region Exec
        /// <summary>
        /// ExecSql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecSql(string sql)
        {
            return ExecSql(sql, new List<IDataParameter>());
        }
        /// <summary>
        /// ExecSql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objParm"></param>
        /// <returns></returns>
        public int ExecSql(string sql, IDataParameter parm)
        {
            return ExecSql(sql, new List<IDataParameter>() { parm });
        }
        /// <summary>
        /// ExecSql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="objParm"></param>
        /// <returns></returns>
        public int ExecSql(string sql, params IDataParameter[] objParm)
        {
            if (objParm == null)
                return ExecSql(sql, new List<IDataParameter>());
            else
                return (new Dac()).ExecSql(ConnStr("onlineDB"), sql, 0, objParm);
        }
        /// <summary>
        /// ExecSql
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="lstParm"></param>
        /// <returns></returns>
        public int ExecSql(string sql, List<IDataParameter> lstParm)
        {
            return (new Dac()).ExecSql(ConnStr("onlineDB"), sql, 0, ((lstParm == null || lstParm.Count == 0) ? null : lstParm.ToArray()));
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {

        }
        #endregion
    }
    #endregion

    #region Dac
    /// <summary>
    /// Dac
    /// </summary>
    public class Dac
    {
        #region 获取绑定参数
        /// <summary>
        /// 获取绑定参数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        private string GetParam(string sql)
        {
            int intPara = 1;
            for (int idx = sql.IndexOf("?"); idx > 0; idx = sql.IndexOf("?"))
            {
                sql = sql.Substring(0, idx) + ":" + (intPara++) + sql.Substring(idx + 1, sql.Length - idx - 1);
            }
            return sql;
        }

        /// <summary>
        /// 获取绑定参数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="loop"></param>
        /// <returns></returns>
        private string GetParam(string sql, int loop)
        {
            int intPara = 1;
            for (int idx = sql.IndexOf("?"); idx > 0; idx = sql.IndexOf("?"))
            {
                sql = sql.Substring(0, idx) + ":" + loop.ToString() + (intPara++) + sql.Substring(idx + 1, sql.Length - idx - 1);
            }
            return sql;
        }
        #endregion

        #region SqlCommand
        /// <summary>
        /// SqlCommand
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal OracleCommand GetSqlCommand(string conn, CommandType type)
        {
            OracleConnection con = new OracleConnection(conn);
            OracleCommand cmd = new OracleCommand();

            con.Open();
            cmd.Connection = con;
            cmd.CommandType = type;
            cmd.CommandTimeout = 3000;

            return cmd;
        }
        #endregion

        #region 获取DataTable

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string conn, string sql)
        {
            DataTable dtRecord = null;
            GetDataTable(conn, sql, ref dtRecord);
            return dtRecord;
        }

        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="dtRecord"></param>
        /// <returns></returns>
        public int GetDataTable(string conn, string sql, ref DataTable dtRecord)
        {
            OracleCommand cmd = GetSqlCommand(conn, CommandType.Text);
            int intAffectedRows = 0;

            try
            {
                cmd.CommandText = GetParam(sql);
                OracleDataAdapter Adapter = new OracleDataAdapter();
                Adapter.SelectCommand = cmd;
                Log.OutPut(sql);

                dtRecord = new DataTable();
                Adapter.Fill(dtRecord);
                if (dtRecord != null)
                {
                    for (int i = 0; i < dtRecord.Columns.Count; i++)
                    {
                        dtRecord.Columns[i].ColumnName = dtRecord.Columns[i].ColumnName.ToLower();
                    }
                }
            }
            catch (System.Exception objEx)
            {
                intAffectedRows = -1;
                throw objEx;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return intAffectedRows;
        }
        #endregion

        #region 获取DataTable带参数

        /// <summary>
        /// 获取DataTable带参数
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="objParams"></param>
        /// <returns></returns>
        public DataTable GetDataTable(string conn, string sql, params IDataParameter[] objParams)
        {
            DataTable dtRecord = null;
            GetDataTable(conn, sql, ref dtRecord, objParams);
            return dtRecord;
        }

        /// <summary>
        /// 获取DataTable带参数
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="dtRecord"></param>
        /// <param name="objParams"></param>
        /// <returns></returns>
        public int GetDataTable(string conn, string sql, ref DataTable dtRecord, params IDataParameter[] objParams)
        {
            OracleCommand cmd = GetSqlCommand(conn, CommandType.Text);
            int intAffectedRows = 0;

            try
            {
                cmd.CommandText = GetParam(sql);
                if (objParams != null)
                {
                    for (int i = 0; i < objParams.Length; i++)
                    {
                        if (objParams[i].Value == null)
                        {
                            objParams[i].Value = System.DBNull.Value;
                        }
                        ((OracleParameter)objParams[i]).ParameterName = (i + 1).ToString();
                        cmd.Parameters.Add((OracleParameter)objParams[i]);
                    }
                }
                OracleDataAdapter Adapter = new OracleDataAdapter();
                Adapter.SelectCommand = cmd;
                Log.OutPut(sql);
                Log.OutPutParm(objParams);

                dtRecord = new DataTable();
                Adapter.Fill(dtRecord);
                for (int i = 0; i < dtRecord.Columns.Count; i++)
                {
                    dtRecord.Columns[i].ColumnName = dtRecord.Columns[i].ColumnName.ToLower();
                }
            }
            catch (System.Exception objEx)
            {
                intAffectedRows = -1;
                throw objEx;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return intAffectedRows;
        }
        #endregion

        #region 执行SQL
        /// <summary>
        /// 执行SQL
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecSql(string conn, string sql)
        {
            OracleCommand cmd = GetSqlCommand(conn, CommandType.Text);
            int intAffectedRows = 0;

            try
            {
                cmd.CommandText = GetParam(sql);
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                intAffectedRows = cmd.ExecuteNonQuery();
            }
            catch (System.Exception objEx)
            {
                intAffectedRows = -1;
                throw objEx;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return intAffectedRows;
        }

        /// <summary>
        /// ExecSQL
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int ExecSql(OracleCommand cmd, string sql)
        {
            int intAffectedRows = 0;

            try
            {
                cmd.CommandText = GetParam(sql);
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                intAffectedRows = cmd.ExecuteNonQuery();
            }
            catch (System.Exception objEx)
            {
                intAffectedRows = -1;
                throw objEx;
            }

            return intAffectedRows;
        }
        #endregion

        #region 执行SQL带参数
        /// <summary>
        /// 执行SQL带参数
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <param name="objParams"></param>
        /// <returns></returns>
        public int ExecSql(string conn, string sql, int step, params IDataParameter[] objParams)
        {
            OracleCommand cmd = GetSqlCommand(conn, CommandType.Text);
            int intAffectedRows = 0;

            try
            {
                cmd.CommandText = GetParam(sql);
                if (objParams != null)
                {
                    for (int i = 0; i < objParams.Length; i++)
                    {
                        if (objParams[i].Value == null)
                        {
                            objParams[i].Value = System.DBNull.Value;
                        }
                        ((OracleParameter)objParams[i]).ParameterName = (i + 1 + step * 10).ToString();
                        cmd.Parameters.Add((OracleParameter)objParams[i]);
                    }
                }
                Log.OutPut(sql);
                Log.OutPutParm(objParams);
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                intAffectedRows = cmd.ExecuteNonQuery();
            }
            catch (System.Exception objEx)
            {
                intAffectedRows = -1;
                throw objEx;
            }
            finally
            {
                if (cmd != null)
                {
                    cmd.Connection.Close();
                    cmd.Dispose();
                }
            }
            return intAffectedRows;
        }

        /// <summary>
        /// ExecSQL
        /// </summary>
        /// <param name="cmd"></param>
        /// <param name="sql"></param>
        /// <param name="objParams"></param>
        /// <returns></returns>
        public int ExecSql(OracleCommand cmd, string sql, int step, params IDataParameter[] objParams)
        {
            int intAffectedRows = 0;

            try
            {
                cmd.CommandText = GetParam(sql);
                if (objParams != null)
                {
                    for (int i = 0; i < objParams.Length; i++)
                    {
                        if (objParams[i].Value == null)
                        {
                            objParams[i].Value = System.DBNull.Value;
                        }
                        ((OracleParameter)objParams[i]).ParameterName = (i + 1 + step * 10).ToString();
                        cmd.Parameters.Add((OracleParameter)objParams[i]);
                    }
                }
                Log.OutPut(sql);
                Log.OutPutParm(objParams);
                if (cmd.Connection.State == ConnectionState.Closed)
                {
                    cmd.Connection.Open();
                }
                intAffectedRows = cmd.ExecuteNonQuery();
            }
            catch (System.Exception objEx)
            {
                intAffectedRows = -1;
                throw objEx;
            }

            return intAffectedRows;
        }
        #endregion
    }
    #endregion
}
