using System;
using iCareData ;
using com.digitalwave.TimeDirectionService ;
namespace iCare
{
	/// <summary>
	/// Summary description for clsTimeDirectionDomain.
	/// </summary>
	public class clsTimeDirectionDomain
	{
		public clsTimeDirectionDomain()
		{
			//
			// TODO: Add constructor logic here
			//

		}

		#region 得到所有的TimeDirectionTable,Domain层,刘颖源,2003-5-7 19:24:10
		//在此编写同类功能函数体
		public clsTimeDirectionTableValue[] lngGetAllTimeDirectionTable()
		{
			clsTimeDirectionTableValue[] objTimeDirectionTableArr=null;

            clsTimeDirectionService m_objServ =
                (clsTimeDirectionService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsTimeDirectionService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.lngGetAllTimeDirectionTable(out objTimeDirectionTableArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return(objTimeDirectionTableArr );
		}
		#endregion

		#region 得到所有的TimeDirectionField,Domain层,刘颖源,2003-5-7 19:24:10
		//在此编写同类功能函数体
		public clsTimeDirectionFieldValue[] lngGetAllTimeDirectionField(string p_strTableID)
		{
			clsTimeDirectionFieldValue[] objTimeDirectionFieldArr=null;

            clsTimeDirectionService m_objServ =
                (clsTimeDirectionService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsTimeDirectionService));

			long lngRes = 0;
            try
            {
                lngRes = m_objServ.lngGetAllTimeDirectionField (p_strTableID,out objTimeDirectionFieldArr);
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return(objTimeDirectionFieldArr );
		}
		#endregion

		#region 横表产生数据,刘颖源,2003-6-6 11:26:42
		public long lngGenerateTimeDirection(string p_strTableName,clsTimeDirectionFieldValue  [] p_objFields,
			string p_strDateTimeFiledName,string p_strBeginDate,string p_strEndDate,
			string p_strSpecailCondition,string[] p_strCondictionValues,
			string p_strSecialOrder,
			out clsTDParameterExplainValue[] p_objTDParameterExplain,out clsTDParameterDetailValue[] p_objTDParameterDetail,out DateTime p_objMinStartDate)
		{
			p_objTDParameterExplain=null;
			p_objTDParameterDetail=null;

            clsTimeDirectionService m_objServ =
                (clsTimeDirectionService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsTimeDirectionService));

			long lngRes = 0;
            try
            {
                p_objMinStartDate = DateTime.MinValue;
                string strStandardSQL = "Select  <DATETIME_FIELD_NAME>,<DATA_FIELD_NAMES> From <TABLE_NAME> " +
                                    " where (<DATETIME_FIELD_NAME> Between <BEGIN_DATE> And <END_DATE>) <SPECIAL_CONDITION> " +
                                    " Order By <DATETIME_FIELD_NAME><SPECIAL_ORDER>";
                if (p_objFields == null || p_objFields.Length <= 0) return (-1);
                string strFields = "";
                for (int i = 0; i < p_objFields.Length; i++)
                    strFields += (p_objFields[i].m_strF_DataFieldName + ",");
                if (strFields.Length > 0)
                    strFields = strFields.Substring(0, strFields.Length - 1);
                if (p_strBeginDate == null || p_strBeginDate == "")
                    p_strBeginDate = "TO_DATE('1900-01-01 00:00:00','yyyy-mm-dd hh24:mi:ss')";
                else
                    p_strBeginDate = "TO_DATE('" + p_strBeginDate + "','yyyy-mm-dd hh24:mi:ss')";
                if (p_strEndDate == null || p_strEndDate == "")
                    p_strEndDate = "TO_DATE('2099-12-31 23:59:59','yyyy-mm-dd hh24:mi:ss')";
                else
                    p_strEndDate = "TO_DATE('" + p_strEndDate + "','yyyy-mm-dd hh24:mi:ss')";
                string strSpecialCondiction = p_strSpecailCondition;
                if (strSpecialCondiction == null) strSpecialCondiction = "";
                strSpecialCondiction = strSpecialCondiction.Trim();
                strSpecialCondiction = strSpecialCondiction.Replace("<TABLE_NAME>", p_strTableName);
                strSpecialCondiction = strSpecialCondiction.Replace("<DATETIME_FIELD_NAME>", p_strDateTimeFiledName);
                if (strSpecialCondiction.Length > 5 && strSpecialCondiction.Substring(0, 5) != "where")			//不存在where 
                {
                    if (p_strCondictionValues != null && p_strCondictionValues.Length > 0)
                    {
                        for (int i = 0; i < p_strCondictionValues.Length; i++)
                        {
                            string strDateFormat = null;
                            string strTemp = "CONDICTION" + i.ToString("00");
                            if (p_strCondictionValues[i] != null && p_strCondictionValues[i] != "")
                            {
                                if (m_blnGetDateFormat(p_strCondictionValues[i], out strDateFormat))
                                    strSpecialCondiction = strSpecialCondiction.Replace("'" + strTemp + "'", strDateFormat);
                                else
                                    strSpecialCondiction = strSpecialCondiction.Replace(strTemp, p_strCondictionValues[i]);
                            }
                        }
                    }
                    if (strSpecialCondiction != null && strSpecialCondiction.Trim() != "")
                    {
                        strSpecialCondiction = strSpecialCondiction.Trim();
                        if (strSpecialCondiction.Substring(0, 3).ToLower() != "and")
                            strSpecialCondiction = " and " + strSpecialCondiction;
                    }
                }

                string strSpecialOrder = p_strSecialOrder;
                if (strSpecialOrder != null && strSpecialOrder.Trim() != "")
                {
                    strSpecialOrder = strSpecialOrder.Trim();
                    if (strSpecialOrder.Substring(0, 1) != ",")
                        strSpecialOrder = "," + strSpecialOrder;
                }

                strStandardSQL = strStandardSQL.Replace("<TABLE_NAME>", p_strTableName);
                strStandardSQL = strStandardSQL.Replace("<DATETIME_FIELD_NAME>", p_strDateTimeFiledName);
                strStandardSQL = strStandardSQL.Replace("<DATA_FIELD_NAMES>", strFields);
                strStandardSQL = strStandardSQL.Replace("<BEGIN_DATE>", p_strBeginDate);
                strStandardSQL = strStandardSQL.Replace("<END_DATE>", p_strEndDate);
                strStandardSQL = strStandardSQL.Replace("<SPECIAL_CONDITION>", strSpecialCondiction);
                strStandardSQL = strStandardSQL.Replace("<SPECIAL_ORDER>", strSpecialOrder);
                string[] strFieldNames = null;
                string[,] strRowValue = null;
                lngRes = m_objServ.lngGetAllAvailableParamenters(strStandardSQL, out strFieldNames, out strRowValue);
                p_objTDParameterExplain = new clsTDParameterExplainValue[p_objFields.Length];
                for (int i = 0; i < p_objFields.Length; i++)
                {
                    p_objTDParameterExplain[i] = new clsTDParameterExplainValue();
                    p_objTDParameterExplain[i].m_strP_Desc = p_objFields[i].m_strF_FieldDesc;
                    p_objTDParameterExplain[i].m_strP_ID = p_objFields[i].m_strT_ID + p_objFields[i].m_strF_ID;
                    //寻找最大最小值
                    p_objTDParameterExplain[i].m_strP_MaxValue = "0";
                    p_objTDParameterExplain[i].m_strP_MinValue = "1";
                    clsTimeDirectionMaxMinValueValue[] objMaxMinValue = null;
                    lngRes = m_objServ.lngGetFieldsMaxMinValue(int.Parse(p_objFields[i].m_strF_FieldType), p_strTableName, p_objFields[i].m_strF_DataFieldName, out objMaxMinValue);
                    if (objMaxMinValue != null && objMaxMinValue.Length > 0)
                    {
                        p_objTDParameterExplain[i].m_strP_MaxValue = objMaxMinValue[0].m_strMaxValue;
                        p_objTDParameterExplain[i].m_strP_MinValue = objMaxMinValue[0].m_strMinValue;
                    }

                }
                p_objTDParameterDetail = null;
                if (lngRes > 0 && strFieldNames != null && strFieldNames.Length > 0 && strRowValue != null && strRowValue.Length > 0)
                {
                    int intRowsNumber = strRowValue.Length / (p_objFields.Length + 1);		//加上一个ActiveDate,计算出记录集的行数
                    if (intRowsNumber <= 0) return (-1);
                    p_objTDParameterDetail = new clsTDParameterDetailValue[intRowsNumber * p_objFields.Length];		//分配行空间
                    for (int i = 0; i < intRowsNumber * p_objFields.Length; i++)
                    {
                        int intIndexRow = i / (p_objFields.Length);
                        int intIndexColumn = i % (p_objFields.Length);

                        p_objTDParameterDetail[i] = new clsTDParameterDetailValue();

                        p_objTDParameterDetail[i].m_strP_DateTime = strRowValue[intIndexRow, 0];
                        p_objMinStartDate = (DateTime.Parse(p_objTDParameterDetail[i].m_strP_DateTime) < p_objMinStartDate) ? DateTime.Parse(p_objTDParameterDetail[i].m_strP_DateTime) : p_objMinStartDate;
                        p_objTDParameterDetail[i].m_strP_Value = strRowValue[intIndexRow, intIndexColumn + 1].Trim();
                        p_objTDParameterDetail[i].m_strP_ID = p_objFields[intIndexColumn].m_strT_ID + p_objFields[intIndexColumn].m_strF_ID;
                    }


                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return(lngRes);
 
		}

		#endregion

		#region 竖表产生数据,刘颖源,2003-6-9 14:38:28
		public long lngGenerateTimeDirection1(string p_strTableName,string p_strTableID_Field,clsTimeDirectionFieldValue  [] p_objFields,
			string p_strDateTimeFiledName,string p_strBeginDate,string p_strEndDate,
			string p_strSpecailCondition,string[] p_strCondictionValues,
			string p_strSecialOrder,
			out clsTDParameterExplainValue[] p_objTDParameterExplain,out clsTDParameterDetailValue[] p_objTDParameterDetail,out DateTime p_objMinStartDate)
		{
			p_objTDParameterExplain=null;
			p_objTDParameterDetail=null;

            clsTimeDirectionService m_objServ =
                (clsTimeDirectionService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsTimeDirectionService));

			long lngRes = 0;
            try
            {
                p_objMinStartDate = DateTime.MinValue;
                string strStandardSQL = "Select  <DATETIME_FIELD_NAME>,<DATA_FIELD_NAMES>,<TARGET_ID_FIELD> as 'Target_ID' From <TABLE_NAME> " +
                    " where (<DATETIME_FIELD_NAME> Between <BEGIN_DATE> And <END_DATE>) <SPECIAL_CONDITION> " +
                    " Order By <DATETIME_FIELD_NAME><SPECIAL_ORDER>";
                if (p_objFields == null || p_objFields.Length <= 0 || p_strTableID_Field == null || p_strTableID_Field == "") return (-1);

                string strFields = p_objFields[0].m_strF_DataFieldName; ;
                if (strFields == "") return (-1);

                if (p_strBeginDate == null || p_strBeginDate == "")
                    p_strBeginDate = "TO_DATE('1900-01-01 00:00:00','yyyy-mm-dd hh24:mi:ss')";
                else
                    p_strBeginDate = "TO_DATE('" + p_strBeginDate + "','yyyy-mm-dd hh24:mi:ss')";
                if (p_strEndDate == null || p_strEndDate == "")
                    p_strEndDate = "TO_DATE('2099-12-31 23:59:59','yyyy-mm-dd hh24:mi:ss')";
                else
                    p_strEndDate = "TO_DATE('" + p_strEndDate + "','yyyy-mm-dd hh24:mi:ss')";
                string strSpecialCondiction = p_strSpecailCondition;
                if (strSpecialCondiction == null) strSpecialCondiction = "";
                strSpecialCondiction = strSpecialCondiction.Trim();
                strSpecialCondiction = strSpecialCondiction.Replace("<TABLE_NAME>", p_strTableName);
                strSpecialCondiction = strSpecialCondiction.Replace("<DATETIME_FIELD_NAME>", p_strDateTimeFiledName);
                if (strSpecialCondiction.Length > 5 && strSpecialCondiction.Substring(0, 5) != "where")			//不存在where 
                {
                    if (p_strCondictionValues != null && p_strCondictionValues.Length > 0)
                    {
                        for (int i = 0; i < p_strCondictionValues.Length; i++)
                        {
                            string strDateFormat = null;
                            string strTemp = "CONDICTION" + i.ToString("00");
                            if (p_strCondictionValues[i] != null && p_strCondictionValues[i] != "")
                            {
                                if (m_blnGetDateFormat(p_strCondictionValues[i], out strDateFormat))
                                    strSpecialCondiction = strSpecialCondiction.Replace("'" + strTemp + "'", strDateFormat);
                                else
                                    strSpecialCondiction = strSpecialCondiction.Replace(strTemp, p_strCondictionValues[i]);
                            }
                        }
                    }
                    if (strSpecialCondiction != null && strSpecialCondiction.Trim() != "")
                    {
                        strSpecialCondiction = strSpecialCondiction.Trim();
                        if (strSpecialCondiction.Substring(0, 3).ToLower() != "and")
                            strSpecialCondiction = " and " + strSpecialCondiction;
                    }
                }
                string strOrCondiction = "";
                for (int i = 0; i < p_objFields.Length; i++)
                    strOrCondiction += (p_objFields[i].m_strF_FieldCondiction + " or ");
                if (strOrCondiction.Length > 4)
                    strOrCondiction = strOrCondiction.Substring(0, strOrCondiction.Length - 4);

                strSpecialCondiction += " and (" + strOrCondiction + ") ";

                string strSpecialOrder = p_strSecialOrder;
                if (strSpecialOrder != null && strSpecialOrder.Trim() != "")
                {
                    strSpecialOrder = strSpecialOrder.Trim();
                    if (strSpecialOrder.Substring(0, 1) != ",")
                        strSpecialOrder = "," + strSpecialOrder;
                }

                strStandardSQL = strStandardSQL.Replace("<TABLE_NAME>", p_strTableName);
                strStandardSQL = strStandardSQL.Replace("<TARGET_ID_FIELD>", p_strTableID_Field);
                strStandardSQL = strStandardSQL.Replace("<DATETIME_FIELD_NAME>", p_strDateTimeFiledName);
                strStandardSQL = strStandardSQL.Replace("<DATA_FIELD_NAMES>", strFields);
                strStandardSQL = strStandardSQL.Replace("<BEGIN_DATE>", p_strBeginDate);
                strStandardSQL = strStandardSQL.Replace("<END_DATE>", p_strEndDate);
                strStandardSQL = strStandardSQL.Replace("<SPECIAL_CONDITION>", strSpecialCondiction);
                strStandardSQL = strStandardSQL.Replace("<SPECIAL_ORDER>", strSpecialOrder);
                string[] strFieldNames = null;
                string[,] strRowValue = null;
                lngRes = m_objServ.lngGetAllAvailableParamenters(strStandardSQL, out strFieldNames, out strRowValue);
                p_objTDParameterExplain = new clsTDParameterExplainValue[p_objFields.Length];
                for (int i = 0; i < p_objFields.Length; i++)
                {
                    p_objTDParameterExplain[i] = new clsTDParameterExplainValue();
                    p_objTDParameterExplain[i].m_strP_Desc = p_objFields[i].m_strF_FieldDesc;
                    p_objTDParameterExplain[i].m_strP_ID = p_objFields[i].m_strT_ID + p_objFields[i].m_strF_ID;
                    //寻找最大最小值
                    string strMaxMinSQL = "Select Max(" + strFields + ") as 'MaxValue', Min(" + strFields + ") as 'MinValue' From " + p_strTableName + " Where " + p_objFields[i].m_strF_FieldCondiction;
                    string[] strMaxMinFields = null;
                    string[,] strMaxMinRowValue = null;
                    long lngReturn = m_objServ.lngGetAllAvailableParamenters(strMaxMinSQL, out strMaxMinFields, out strMaxMinRowValue);
                    if (lngReturn > 0 && strMaxMinRowValue != null && strMaxMinRowValue.Length > 0)
                    {
                        p_objTDParameterExplain[i].m_strP_MaxValue = strMaxMinRowValue[0, 0];
                        p_objTDParameterExplain[i].m_strP_MinValue = strMaxMinRowValue[0, 1];
                    }
                }
                //对于每一列寻找最大最小值
                p_objMinStartDate = DateTime.MaxValue;

                p_objTDParameterDetail = null;
                if (lngRes > 0 && strFieldNames != null && strFieldNames.Length > 0 && strRowValue != null && strRowValue.Length > 0)
                {
                    int intRowsNumber = strRowValue.Length / 3;		//ActiveDate,Value,Targer_ID
                    if (intRowsNumber <= 0) return (-1);
                    p_objTDParameterDetail = new clsTDParameterDetailValue[intRowsNumber];		//分配行空间
                    for (int i = 0; i < intRowsNumber; i++)
                    {
                        int intIndexRow = i;
                        int intIndexColumn = i % (p_objFields.Length);
                        p_objTDParameterDetail[i] = new clsTDParameterDetailValue();
                        p_objTDParameterDetail[i].m_strP_DateTime = strRowValue[intIndexRow, 0];
                        p_objMinStartDate = (DateTime.Parse(p_objTDParameterDetail[i].m_strP_DateTime) < p_objMinStartDate) ? DateTime.Parse(p_objTDParameterDetail[i].m_strP_DateTime) : p_objMinStartDate;
                        p_objTDParameterDetail[i].m_strP_Value = strRowValue[intIndexRow, 1].Trim();
                        p_objTDParameterDetail[i].m_strP_ID = p_objFields[intIndexColumn].m_strT_ID + p_objFields[intIndexColumn].m_strF_ID;
                    }
                }
            }
            finally
            {
                //m_objServ.Dispose();
            }
			return(lngRes);
 
		}
		private bool m_blnGetDateFormat(string p_strValue,out string p_strResult)
		{
			p_strResult = p_strValue;
			try
			{
				p_strResult =  "to_date('"+DateTime.Parse(p_strValue).ToString("yyyy-MM-dd HH:mm:ss")+"','yyyy-mm-dd hh24:mi:ss')";
			}
			catch{return false;}
			return true;
		}

		#endregion

		#region 获得所有可选项,刘颖源,2003-6-6 11:26:42
		public long lngGetAllAvailableParamenters(string p_strSqlStatement,out string [] p_strFieldNames,out string [,] p_strRowValues)
		{
            clsTimeDirectionService m_objServ =
                (clsTimeDirectionService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsTimeDirectionService));

			long lngRes = 0;
            try
            {
                lngRes = (m_objServ.lngGetAllAvailableParamenters(p_strSqlStatement, out p_strFieldNames, out p_strRowValues));
            }
            finally
            {
                //m_objServ.Dispose();
            }
            return lngRes;
		}
		#endregion
	}
}
