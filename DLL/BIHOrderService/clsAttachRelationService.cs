using System;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HRPService;
using System.Data;
using System.EnterpriseServices;

namespace com.digitalwave.iCare.middletier.BIHOrderServer
{
	#region Attach relation factory
	/// <summary>
	/// clsAttachRelationService
	/// 医嘱-附加单据映射数据操作抽象类
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public abstract class clsAttachRelationService : com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		
		public clsAttachRelationService()
		{
		}
		[AutoComplete]
		public abstract long m_lngGetRelationByFilter(string p_strFilter,out clsVOProduct p_objValues);
		[AutoComplete]
		public abstract long m_lngInsertRelation(clsVOProduct p_objValues);
		[AutoComplete]
		public abstract long m_lngUpdateRelation(clsVOProduct p_objValues);
		[AutoComplete]
		public abstract long m_lngUpdateRelationByFilter(string p_strFilter,int p_intFilterType,clsVOProduct p_objValues);
	}

	/// <summary>
	/// 医嘱-附加单据映射数据操作类:使用字符串作为传递值
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsRelationService_STR:clsAttachRelationService
	{
		private clsRelation_StrArr m_objRelation=new clsRelation_StrArr();
		public clsRelationService_STR()
		{
		}
		[AutoComplete]
		public override long m_lngGetRelationByFilter(string p_strFilter, out clsVOProduct p_objValues)
		{
			p_objValues = null;
			if(m_objRelation.m_lngGetRelation(p_strFilter)>0)
			{
				p_objValues=m_objRelation;
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngInsertRelation(clsVOProduct p_objValues)
		{
			m_objRelation=(clsRelation_StrArr)p_objValues;
			return m_objRelation.m_lngInsertRelation();
		}

		[AutoComplete]
		public override long m_lngUpdateRelation(clsVOProduct p_objValues)
		{
			m_objRelation=(clsRelation_StrArr)p_objValues;
			return m_objRelation.m_lngUpdate();
		}

		[AutoComplete]
		public override long m_lngUpdateRelationByFilter(string p_strFilter,int p_intFilterType,clsVOProduct p_objValues)
		{
			m_objRelation=(clsRelation_StrArr)p_objValues;
			return m_objRelation.m_lngUpdateByFilter(p_strFilter,p_intFilterType);
		}

	}

	/// <summary>
	/// 医嘱-附加单据映射数据操作类:使用数据表作为传递值
	/// </summary>
	/// 
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsRelationService_DTB:clsAttachRelationService
	{
		private clsRelation_DTable m_objRelation=new clsRelation_DTable();
		public clsRelationService_DTB()
		{
		}

		[AutoComplete]
		public override long m_lngGetRelationByFilter(string p_strFilter, out clsVOProduct p_objValues)
		{
			p_objValues = null;
			if(m_objRelation.m_lngGetRelation(p_strFilter)>0)
			{
				p_objValues=m_objRelation;
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngInsertRelation(clsVOProduct p_objValues)
		{
			m_objRelation=(clsRelation_DTable)p_objValues;
			return m_objRelation.m_lngInsertRelation();
		}

		[AutoComplete]
		public override long m_lngUpdateRelation(clsVOProduct p_objValues)
		{
			m_objRelation=(clsRelation_DTable)p_objValues;
			return m_objRelation.m_lngUpdate();
		}

		[AutoComplete]
		public override long m_lngUpdateRelationByFilter(string p_strFilter,int p_intFilterType,clsVOProduct p_objValues)
		{
			m_objRelation=(clsRelation_DTable)p_objValues;
			return m_objRelation.m_lngUpdateByFilter(p_strFilter,p_intFilterType);
		}

	}
	
	/// <summary>
	/// 医嘱-附加单据映射数据操作类:使用VO数组作为传递值
	/// </summary>
	/// 
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsRelationService_VOS:clsAttachRelationService
	{
		private clsRelation_VOArr m_objRelation=new clsRelation_VOArr();
		public clsRelationService_VOS()
		{
		}

		[AutoComplete]
		public override long m_lngGetRelationByFilter(string p_strFilter, out clsVOProduct p_objValues)
		{
			p_objValues = null;
			if(m_objRelation.m_lngGetRelation(p_strFilter)>0)
			{
				p_objValues=m_objRelation;
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngInsertRelation(clsVOProduct p_objValues)
		{
			m_objRelation=(clsRelation_VOArr)p_objValues;
			return m_objRelation.m_lngInsertRelation();
		}

		[AutoComplete]
		public override long m_lngUpdateRelation(clsVOProduct p_objValues)
		{
			m_objRelation=(clsRelation_VOArr)p_objValues;
			return m_objRelation.m_lngUpdate();
		}

		[AutoComplete]
		public override long m_lngUpdateRelationByFilter(string p_strFilter,int p_intFilterType,clsVOProduct p_objValues)
		{
			m_objRelation=(clsRelation_VOArr)p_objValues;
			return m_objRelation.m_lngUpdateByFilter(p_strFilter,p_intFilterType);
		}
	}
	
	#endregion

	#region Attach relation product
	/// <summary>
	/// 数据库操作抽象类
	/// </summary>
	/// 
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public abstract class clsVOProduct
	{
		public clsVOProduct()
		{
		}
		protected string[,] strValuesArr=null;
		protected string strSELECT="SELECT * FROM T_OPR_ATTACHRELATION ";
		protected string strINSERT="INSERT INTO T_OPR_ATTACHRELATION(ATTARELAID_CHR,SYSFROM_INT,ATTACHTYPE_INT,SOURCEITEMID_VCHR,ATTACHID_VCHR) VALUES((SELECT CASE MAX(ATTARELAID_CHR)+1 WHEN MAX(ATTARELAID_CHR)+1 THEN TRIM(TO_CHAR(MAX(ATTARELAID_CHR)+1,'000000000000')) ELSE '000000000001' END FROM  T_OPR_ATTACHRELATION),";
		protected string strUPDATE="UPDATE T_OPR_ATTACHRELATION SET ";
		protected string strDELETE="DELETE FROM T_OPR_ATTACHRELATION ";

		[AutoComplete]
		public abstract long m_lngGetRelation(string p_strFilter);

		[AutoComplete]
		public abstract long m_lngInsertRelation();

		[AutoComplete]
		public abstract long m_lngUpdate();

		[AutoComplete]
		public abstract long m_lngUpdateByFilter(string p_strFilter,int p_intFilterType);

		[AutoComplete]
		public abstract long m_lngDelete();

		[AutoComplete]
		public abstract long m_lngDeleteByFilter(string p_strFilter,int p_intFilterType);
	}

	/// <summary>
	/// 以字符串传递值的数据库操作类
	/// </summary>
	/// 
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsRelation_StrArr:clsVOProduct
	{
		public string[,] m_strValues;

		public clsRelation_StrArr()
		{
			m_strValues=null;
		}

		public clsRelation_StrArr(string[,] p_strArr)
		{
			m_strValues=p_strArr;
		}

		[AutoComplete]
		public override long m_lngGetRelation(string p_strFilter)
		{
			string strSQL="";

			DataTable dtbRes=new DataTable();

			if(p_strFilter.Trim()=="")
			{
				strSQL=strSELECT;
			}
			else
			{
				strSQL=strSELECT +" WHERE "+p_strFilter.Trim();
			}

			long lngRes=new clsHRPTableService().DoGetDataTable(strSQL,ref dtbRes);

			if(lngRes>0 && dtbRes.Rows.Count>0)
			{
				m_strValues=new string[dtbRes.Rows.Count,5];
				for(int i=0;i<dtbRes.Rows.Count;i++)
				{
					for(int j=0;j<5;i++)
					{
						if(dtbRes.Rows[i][j]!=DBNull.Value)
						{
							m_strValues[i,j]=dtbRes.Rows[i][j].ToString().Trim();
						}
						else
						{
							m_strValues[i,j]="";
						}
					}
				}
				return 0;
			}
			return -1;
		}

		[AutoComplete]
		public override long m_lngInsertRelation()
		{
			if(m_strValues.GetLength(0)>0)
			{
				for(int i=0;i<m_strValues.GetLength(0);i++)
				{
					string strSQL=strINSERT;
					try
					{
						strSQL=strSQL+int.Parse(m_strValues[i,1]).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"0,";
					}
					try
					{
						strSQL=strSQL+int.Parse(m_strValues[i,2]).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"0,";
					}
					strSQL=strSQL+"'"+m_strValues[i,3]+"',";
					strSQL=strSQL+"'"+m_strValues[i,4]+"')";

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
						int iRes=new clsHRPTableService().intGetNewNumericID("ATTARELAID_CHR","T_OPR_ATTACHRELATION");
						m_strValues[i,0]=iRes.ToString().PadLeft(12,'0');
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngUpdate()
		{
			if(m_strValues.GetLength(0)>0)
			{
				for(int i=0;i<m_strValues.GetLength(0);i++)
				{
					string strSQL=strUPDATE;
					try
					{
						strSQL=strSQL+" SYSFROM_INT="+int.Parse(m_strValues[i,1]).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"SYSFROM_INT=0,";
					}
					try
					{
						strSQL=strSQL+"ATTACHTYPE_INT="+int.Parse(m_strValues[i,2]).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"ATTACHTYPE_INT=0,";
					}
					strSQL=strSQL+"SOURCEITEMID_VCHR='"+m_strValues[i,3]+"',";
					strSQL=strSQL+"ATTACHID_VCHR='"+m_strValues[i,4]+"'";
					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_strValues[i,0]+"'";

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngUpdateByFilter(string p_strFilter,int p_intFilterType)
		{
			if(p_strFilter.Trim()=="")
			{
				return -1;
			}
			
			if(m_strValues.GetLength(0)>0)
			{

				for(int i=0;i<m_strValues.GetLength(0);i++)
				{
					string strSQL=strUPDATE;
					try
					{
						strSQL=strSQL+" SYSFROM_INT="+int.Parse(m_strValues[i,1]).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"SYSFROM_INT=0,";
					}
					try
					{
						strSQL=strSQL+"ATTACHTYPE_INT="+int.Parse(m_strValues[i,2]).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"ATTACHTYPE_INT=0,";
					}
					strSQL=strSQL+"SOURCEITEMID_VCHR='"+m_strValues[i,3]+"',";
					strSQL=strSQL+"ATTACHID_VCHR='"+m_strValues[i,4]+"'";
					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_strValues[i,0]+"'"+((p_intFilterType==0)?" AND ":" OR ").ToString()+p_strFilter.Trim();

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngDelete()
		{
			if(m_strValues.GetLength(0)>0)
			{
				for(int i=0;i<m_strValues.GetLength(0);i++)
				{
					string strSQL=strDELETE;

					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_strValues[i,0]+"'";

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngDeleteByFilter(string p_strFilter, int p_intFilterType)
		{
			if(m_strValues.GetLength(0)>0)
			{
				for(int i=0;i<m_strValues.GetLength(0);i++)
				{
					string strSQL=strDELETE;

					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_strValues[i,0]+"'"+((p_intFilterType==0)?" AND ":" OR ").ToString()+p_intFilterType;

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}


	}

	/// <summary>
	/// 以VO数组传递值的数据库操作类
	/// </summary>
	/// 
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsRelation_VOArr:clsVOProduct
	{
		public clsT_OPR_ATTACHRELATION_VO[] m_objValues;

		public clsRelation_VOArr()
		{
			m_objValues=null;
		}
		public clsRelation_VOArr(clsT_OPR_ATTACHRELATION_VO[] p_objArr)
		{
			m_objValues=p_objArr;
		}

		[AutoComplete]
		public override long m_lngGetRelation(string p_strFilter)
		{
			string strSQL="";

			DataTable dtbRes=new DataTable();

			if(p_strFilter.Trim()=="")
			{
				strSQL=strSELECT;
			}
			else
			{
				strSQL=strSELECT +" WHERE "+p_strFilter.Trim();
			}

			long lngRes=new clsHRPTableService().DoGetDataTable(strSQL,ref dtbRes);

			if(lngRes>0 && dtbRes.Rows.Count>0)
			{
				m_objValues=new clsT_OPR_ATTACHRELATION_VO[dtbRes.Rows.Count];
				for(int i=0;i<dtbRes.Rows.Count;i++)
				{
					m_objValues[i]=new clsT_OPR_ATTACHRELATION_VO();
					//流水号
					if(dtbRes.Rows[i]["ATTARELAID_CHR"]!=DBNull.Value)
					{
						m_objValues[i].m_strATTARELAID_CHR=dtbRes.Rows[i]["ATTARELAID_CHR"].ToString().Trim();
					}
					else
					{
						m_objValues[i].m_strATTARELAID_CHR="";
					}

					//来源 {1=门诊;2=住院;3=电子病历;4=其它}
					if(dtbRes.Rows[i]["SYSFROM_INT"]!=DBNull.Value)
					{
						m_objValues[i].m_strSYSFROM_INT=dtbRes.Rows[i]["SYSFROM_INT"].ToString().Trim();
					}
					else
					{
						m_objValues[i].m_strSYSFROM_INT="";
					}

					//表单类型 {1=CT,2=MR,3=LIS,......}
					if(dtbRes.Rows[i]["ATTACHTYPE_INT"]!=DBNull.Value)
					{
						m_objValues[i].m_strATTACHTYPE_INT=dtbRes.Rows[i]["ATTACHTYPE_INT"].ToString().Trim();
					}
					else
					{
						m_objValues[i].m_strATTACHTYPE_INT="";
					}

					//源id {if (门诊) = 处方id; if (住院) = 医嘱id}
					if(dtbRes.Rows[i]["SOURCEITEMID_VCHR"]!=DBNull.Value)
					{
						m_objValues[i].m_strSOURCEITEMID_VCHR=dtbRes.Rows[i]["SOURCEITEMID_VCHR"].ToString().Trim();
					}
					else
					{
						m_objValues[i].m_strSOURCEITEMID_VCHR="";
					}

					//目标申请单id
					if(dtbRes.Rows[i]["ATTACHID_VCHR"]!=DBNull.Value)
					{
						m_objValues[i].m_strATTACHID_VCHR=dtbRes.Rows[i]["ATTACHID_VCHR"].ToString().Trim();
					}
					else
					{
						m_objValues[i].m_strATTACHID_VCHR="";
					}


				}
				return 0;
			}
			return -1;
		}

		[AutoComplete]
		public override long m_lngInsertRelation()
		{
			if(m_objValues.Length>0)
			{
				for(int i=0;i<m_objValues.Length;i++)
				{
					string strSQL=strINSERT;
					try
					{
						strSQL=strSQL+int.Parse(m_objValues[i].m_strSYSFROM_INT.Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"0,";
					}
					try
					{
						strSQL=strSQL+int.Parse(m_objValues[i].m_strATTACHTYPE_INT.Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"0,";
					}
					strSQL=strSQL+"'"+m_objValues[i].m_strSOURCEITEMID_VCHR.Trim()+"',";
					strSQL=strSQL+"'"+m_objValues[i].m_strATTACHID_VCHR.Trim()+"')";

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
						int iRes=new clsHRPTableService().intGetNewNumericID("ATTARELAID_CHR","T_OPR_ATTACHRELATION");
						m_objValues[i].m_strATTARELAID_CHR=iRes.ToString().PadLeft(12,'0');
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngUpdate()
		{
			if(m_objValues.Length>0)
			{
				for(int i=0;i<m_objValues.Length;i++)
				{
					string strSQL=strUPDATE;
					try
					{
						strSQL=strSQL+" SYSFROM_INT="+int.Parse(m_objValues[i].m_strSYSFROM_INT.Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"SYSFROM_INT=0,";
					}
					try
					{
						strSQL=strSQL+"ATTACHTYPE_INT="+int.Parse(m_objValues[i].m_strATTACHTYPE_INT.Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"ATTACHTYPE_INT=0,";
					}
					strSQL=strSQL+"SOURCEITEMID_VCHR='"+m_objValues[i].m_strSOURCEITEMID_VCHR.Trim()+"',";
					strSQL=strSQL+"ATTACHID_VCHR='"+m_objValues[i].m_strATTACHID_VCHR+"'";
					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_objValues[i].m_strATTARELAID_CHR+"'";

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngUpdateByFilter(string p_strFilter,int p_intFilterType)
		{
			if(p_strFilter.Trim()=="")
			{
				return -1;
			}
			
			if(m_objValues.Length>0)
			{

				for(int i=0;i<m_objValues.Length;i++)
				{
					string strSQL=strUPDATE;
					try
					{
						strSQL=strSQL+" SYSFROM_INT="+int.Parse(m_objValues[i].m_strSYSFROM_INT.Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"SYSFROM_INT=0,";
					}
					try
					{
						strSQL=strSQL+"ATTACHTYPE_INT="+int.Parse(m_objValues[i].m_strATTACHTYPE_INT.Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"ATTACHTYPE_INT=0,";
					}
					strSQL=strSQL+"SOURCEITEMID_VCHR='"+m_objValues[i].m_strSOURCEITEMID_VCHR.Trim()+"',";
					strSQL=strSQL+"ATTACHID_VCHR='"+m_objValues[i].m_strATTACHID_VCHR+"'";
					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_objValues[i].m_strATTARELAID_CHR+"'"+((p_intFilterType==0)?" AND ":" OR ").ToString()+p_strFilter.Trim();

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngDelete()
		{
			if(m_objValues.Length>0)
			{
				for(int i=0;i<m_objValues.Length;i++)
				{
					string strSQL=strDELETE;

					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_objValues[i].m_strATTARELAID_CHR.Trim()+"'";

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngDeleteByFilter(string p_strFilter, int p_intFilterType)
		{
			if(m_objValues.Length>0)
			{
				for(int i=0;i<m_objValues.Length;i++)
				{
					string strSQL=strDELETE;

					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_objValues[i].m_strATTARELAID_CHR.Trim()+"'"+((p_intFilterType==0)?" AND ":" OR ").ToString()+p_intFilterType;

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

	}

	/// <summary>
	/// 以数据表传递值的数据库操作类
	/// </summary>
	/// 
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsRelation_DTable:clsVOProduct
	{
		public DataTable m_dtbValues;

		public clsRelation_DTable()
		{
			m_dtbValues=null;
		}
		public clsRelation_DTable(DataTable p_dtbArr)
		{
			m_dtbValues=p_dtbArr;
		}

		[AutoComplete]
		public override long m_lngGetRelation(string p_strFilter)
		{
			string strSQL="";

			DataTable dtbRes=new DataTable();

			if(p_strFilter.Trim()=="")
			{
				strSQL=strSELECT;
			}
			else
			{
				strSQL=strSELECT +" WHERE "+p_strFilter.Trim();
			}

			long lngRes=new clsHRPTableService().DoGetDataTable(strSQL,ref dtbRes);

			if(lngRes>0 && dtbRes.Rows.Count>0)
			{
				m_dtbValues=new DataTable();
				m_dtbValues=dtbRes;
				return 0;
			}
			return -1;
		}

		[AutoComplete]
		public override long m_lngInsertRelation()
		{
			if(m_dtbValues.Rows.Count>0)
			{
				for(int i=0;i<m_dtbValues.Rows.Count;i++)
				{
					string strSQL=strINSERT;
					try
					{
						strSQL=strSQL+int.Parse(m_dtbValues.Rows[i]["SYSFROM_INT"].ToString().Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"0,";
					}
					try
					{
						strSQL=strSQL+int.Parse(m_dtbValues.Rows[i]["ATTACHTYPE_INT"].ToString().Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"0,";
					}
					strSQL=strSQL+"'"+m_dtbValues.Rows[i]["SOURCEITEMID_VCHR"].ToString().Trim()+"',";
					strSQL=strSQL+"'"+m_dtbValues.Rows[i]["ATTACHID_VCHR"].ToString().Trim()+"')";

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
						int iRes=new clsHRPTableService().intGetNewNumericID("ATTARELAID_CHR","T_OPR_ATTACHRELATION");
						m_dtbValues.Rows[i]["ATTARELAID_CHR"]=iRes.ToString().PadLeft(12,'0');
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngUpdate()
		{
			if(m_dtbValues.Rows.Count>0)
			{
				for(int i=0;i<m_dtbValues.Rows.Count;i++)
				{
					string strSQL=strUPDATE;
					try
					{
						strSQL=strSQL+" SYSFROM_INT="+int.Parse(m_dtbValues.Rows[i]["SYSFROM_INT"].ToString().Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"SYSFROM_INT=0,";
					}
					try
					{
						strSQL=strSQL+"ATTACHTYPE_INT="+int.Parse(m_dtbValues.Rows[i]["ATTACHTYPE_INT"].ToString().Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"ATTACHTYPE_INT=0,";
					}
					strSQL=strSQL+"SOURCEITEMID_VCHR='"+m_dtbValues.Rows[i]["SOURCEITEMID_VCHR"].ToString().Trim()+"',";
					strSQL=strSQL+"ATTACHID_VCHR='"+m_dtbValues.Rows[i]["ATTACHID_VCHR"]+"'";
					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_dtbValues.Rows[i]["ATTARELAID_CHR"]+"'";

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngUpdateByFilter(string p_strFilter,int p_intFilterType)
		{
			if(p_strFilter.Trim()=="")
			{
				return -1;
			}
			
			if(m_dtbValues.Rows.Count>0)
			{

				for(int i=0;i<m_dtbValues.Rows.Count;i++)
				{
					string strSQL=strUPDATE;
					try
					{
						strSQL=strSQL+" SYSFROM_INT="+int.Parse(m_dtbValues.Rows[i]["SYSFROM_INT"].ToString().Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"SYSFROM_INT=0,";
					}
					try
					{
						strSQL=strSQL+"ATTACHTYPE_INT="+int.Parse(m_dtbValues.Rows[i]["ATTACHTYPE_INT"].ToString().Trim()).ToString()+",";
					}
					catch
					{
						strSQL=strSQL+"ATTACHTYPE_INT=0,";
					}
					strSQL=strSQL+"SOURCEITEMID_VCHR='"+m_dtbValues.Rows[i]["SOURCEITEMID_VCHR"].ToString().Trim()+"',";
					strSQL=strSQL+"ATTACHID_VCHR='"+m_dtbValues.Rows[i]["ATTACHID_VCHR"]+"'";
					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_dtbValues.Rows[i]["ATTARELAID_CHR"]+"'"+((p_intFilterType==0)?" AND ":" OR ").ToString()+p_strFilter.Trim();

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngDelete()
		{
			if(m_dtbValues.Rows.Count>0)
			{
				for(int i=0;i<m_dtbValues.Rows.Count;i++)
				{
					string strSQL=strDELETE;

					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_dtbValues.Rows[i]["ATTARELAID_CHR"].ToString().Trim()+"'";

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

		[AutoComplete]
		public override long m_lngDeleteByFilter(string p_strFilter, int p_intFilterType)
		{
			if(m_dtbValues.Rows.Count>0)
			{
				for(int i=0;i<m_dtbValues.Rows.Count;i++)
				{
					string strSQL=strDELETE;

					strSQL=strSQL+" WHERE ATTARELAID_CHR='"+m_dtbValues.Rows[i]["ATTARELAID_CHR"].ToString().Trim()+"'"+((p_intFilterType==0)?" AND ":" OR ").ToString()+p_intFilterType;

					try
					{
						long lngRes=new clsHRPTableService().DoExcute(strSQL);
					}
					catch(Exception ex)
					{
						com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
						try
						{
							objLog.LogError(ex);
						}
						catch{}
					}
				}
				return 0;
			}
			else
			{
				return -1;
			}
		}

	}
	#endregion

	#region Operate with other tables
	/// <summary>
	/// Operate with other tables
	/// </summary>
	/// 
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(Enabled=true)]
	public class clsAddBillsOperate
	{
		/// <summary>
		/// Get an "ordercate" data by the specified ID.
		/// </summary>
		/// <param name="p_strOrderCateID">The specified ID</param>
		/// <param name="p_dtbOrderCate">The returned "ordercate" data</param>
		/// <returns></returns>
		/// 
		[AutoComplete]
		public long m_lngGetOrderCateByID(string p_strOrderCateID,out DataTable p_dtbOrderCate)
		{
			p_dtbOrderCate=new DataTable();

			if(p_strOrderCateID.Trim()=="")
			{
				return -1;
			}
			

			string strSQL=@"SELECT * FROM T_AID_BIH_ORDERCATE WHERE ORDERCATEID_CHR='"+p_strOrderCateID.Trim()+"'";

			long lngRes=new clsHRPTableService().DoGetDataTable(strSQL,ref p_dtbOrderCate);

			if(lngRes>=0 && p_dtbOrderCate.Rows.Count>0)
			{
				return lngRes;
			}
			else
			{
				return -1;
			}
		}

		/// <summary>
		/// Get patient's register data by specified filter.
		/// </summary>
		/// <param name="strFilter">Specified Filter</param>
		/// <param name="dtbRes">Result Datatable</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetRegisterInfoByFilter(string strFilter,out DataTable dtbRes)
		{
			long lngRes=-1;
			dtbRes=new DataTable();

			string strSQL=@"SELECT * FROM T_OPR_BIH_REGISTER ";

			if(strFilter.Trim()!="")
			{
				strSQL+=" WHERE "+strFilter.Trim();
			}

			lngRes=new clsHRPTableService().DoGetDataTable(strSQL,ref dtbRes);

			if(lngRes>0 && dtbRes.Rows.Count>0)
			{
				return lngRes;
			}
			else
			{
				return -1;
			}
		}
	}
	#endregion
}
