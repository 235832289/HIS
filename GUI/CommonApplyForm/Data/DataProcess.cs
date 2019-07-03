using System;
using System.Data;
using DigitalWave;
using com.digitalwave.iCare.middletier.HRPService;

namespace com.digitalwave.GLS_WS.Data
{
	/// <summary>
	/// DataProcess 的摘要说明。
	/// </summary>
	public class DataProcess
	{
		
		private DbService service ;//= new DbService();
		private clsHRPTableService m_objHRPServ;

		public DataProcess()
		{
			service = (DbService)this.CreateService();	
			m_objHRPServ = new clsHRPTableService();
		}

		/// <summary>
		/// 返回检查申请单类型
		/// </summary>
		/// <returns></returns>
		public DataTable GetApplyList()
		{
			string sql = "select * from AR_APPLY_TYPELIST where Deleted <> 1 order by ORDERSEQ_INT";
//			return service.SqlSelect(sql);
			DataTable dtValue = new DataTable();
			m_objHRPServ.DoGetDataTable(sql,ref dtValue);
			return dtValue;
			
		}

		/// <summary>
		/// 取得数下一个数字型ID
		/// </summary>
		/// <param name="tableName"></param>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		public string GetNextID(string tableName,string fieldName)
		{
			string strNextID = "";
			string strMaxID = "";
			DataTable dtValue = new DataTable();
			long res=m_objHRPServ.DoGetDataTable("select max(" + fieldName + ") from " + tableName,ref dtValue);
			if(res>0 && dtValue.Rows.Count == 1)
			{
				strMaxID = dtValue.Rows[0][0].ToString();
                if (strMaxID.Trim() == string.Empty)
                {
                    strMaxID = "0";
                }
			}
			strNextID = ((int.Parse(strMaxID))+1).ToString();
			return strNextID;
		}
        public string GetApplyID()
        {
            string m_strMaxID = string.Empty;
            string strSQL = "select SEQ_AR_COMMON_APPLYID.NEXTVAL from dual";
            DataTable m_objTable = new DataTable();
            long lngRes = m_objHRPServ.DoGetDataTable(strSQL, ref m_objTable);
            if (lngRes > 0 && m_objTable.Rows.Count > 0)
            {
                m_strMaxID = m_objTable.Rows[0][0].ToString();

            }
            return m_strMaxID;
        }
 
		public DataTable SqlSelect(string sql)
		{
			DataTable dtValue = new DataTable();
//			return service.SqlSelect(sql);
			m_objHRPServ.DoGetDataTable(sql,ref dtValue);
			return dtValue;
		}

		public bool Update(string tableName, DataSet ds)
		{
			bool b = false;
			try
			{
				b = service.UpdateData(tableName, ds);
			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
			}
			return b;

		}

		public bool SqlExecute(string sql)
		{
//			return (service.SqlExecute(sql) >= 0);
			return (m_objHRPServ.DoExcute(sql) >= 0);
		}

		/// <summary>
		/// 返回一个检查类型对应的报表
		/// </summary>
		/// <param name="typeID"></param>
		/// <returns></returns>
		public DataTable GetReportForm(string typeID)
		{
			string sql = @"SELECT B.FORMDESC as FormTitle , A.FORMCLSNAME_C as FormName , A.FORMCLSNAME_P
							FROM
							AR_FORM B
							, AR_APPLYRELATINGREPORT A
							WHERE
								(A.FORMCLSNAME_C = B.FORMCLSNAME) AND ( A.FORMCLSNAME_P = '{0}')";
			DataTable ds = new DataTable();
			m_objHRPServ.DoGetDataTable( string.Format(sql,typeID),ref ds );
			return ds;
		}

		private object CreateService()
		{
			Type comType = typeof(DigitalWave.DbService);
			object comObj = com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(comType);
			return comObj;
		}
	 
		public DataTable ExecuteScalar(string sql)
		{
//			return service.ExecuteScalar(sql);
			DataTable ds = new DataTable();
			m_objHRPServ.DoGetDataTable(sql,ref ds);
			return ds;
		}
	}
}
