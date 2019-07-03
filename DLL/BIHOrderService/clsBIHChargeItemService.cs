using System;
using System.Data;
using Oracle.DataAccess.Client;
using com.digitalwave.iCare.middletier.HRPService;
using com.digitalwave.iCare.ValueObject;
using System.EnterpriseServices;
using com.digitalwave.security;//PrivilegeSystemService.dll
using com.digitalwave.Utility;//Utility.dll

namespace com.digitalwave.iCare.middletier.BIHOrderServer
{
	/// <summary>
	/// clsBIHChargeItemService 的摘要说明。
	/// </summary>
	[System.EnterpriseServices.Transaction(System.EnterpriseServices.TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsBIHChargeItemService:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		[AutoComplete]
		private string m_strCreateChargeID()
		{
			long lngRes =0;
			string strSql=@"select Max(PChargeID_Chr) MaxID from T_Opr_Bih_PatientCharge";
			DataTable objDT=new DataTable();
			try
			{
				lngRes =new clsHRPTableService().DoGetDataTable(strSql,ref objDT);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if((lngRes>0) && (objDT!=null))
			{
				if(objDT.Rows.Count<=0)
				{
					return ((long)1).ToString().Trim().PadLeft(18,'0');
				}
				else
				{
					long id=clsConverter.ToLong(objDT.Rows[0]["MaxID"]);
					id++;
					return id.ToString().Trim().PadLeft(18,'0');
				}
			}
			else
			{

				return "";
			}
		}

		[AutoComplete]
		public long m_lngAddPatientCharge(clsBIHPatientCharge objCharge)
		{
//				insert into T_Opr_Bih_PatientCharge(	
//					PChargeID_Chr,PatientID_Chr,RegisterID_Chr,
//					OrderID_Chr,    OrderExecType_Int,  OrderExecID_Chr ,
//					CalCCateID_Chr, InvCateID_Chr,      ChargeItemID_Chr,   ChargeItemName_Chr, Unit_Vchr,  UnitPrice_Dec ,
//					AMount_Dec,		DisCount_Dec,   IsMepay_Int ,	 ,     ,
//					Creator_Chr,    Create_Dat,		Status_Int,		PStatus_Int	)
//				values( ?,?,? )";	//, 
//						?,?,?
//						?,?,?,?,?,?,
//						?,?,?,?,?	)"	;//,
//						?,?,1,?					)
//			
				string strSql= @"
				insert into T_Opr_Bih_PatientCharge(	
					PChargeID_Chr,PatientID_Chr,RegisterID_Chr,Active_Dat ,
					OrderID_Chr,    OrderExecType_Int,  OrderExecID_Chr ,
					CalCCateID_Chr, InvCateID_Chr,      ChargeItemID_Chr,   ChargeItemName_Chr, Unit_Vchr,  UnitPrice_Dec ,
					AMount_Dec,		DisCount_Dec ,		IsMepay_Int , Des_VChr , CreateType_Int,
					Creator_Chr,    Create_Dat,		Status_Int,		PStatus_Int   ,CLACAREA_CHR,   CREATEAREA_CHR
					)				
					values( ?,?,? , SysDate ,
						?,?,?,
						?,?,?,?,?,?,
						?,?	,? ,? , ? ,
						?,?,1,?   ,?,?	)
				";
			//to_date('[DateTimeNowValue]','yyyy-mm-dd hh24:mi:ss') ,
			string strID=m_strCreateChargeID();
			if(strID=="") return 0;
			objCharge.m_strPChargeID=strID;

			strSql=strSql.Replace("[DateTimeNowValue]",DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

			//
			OracleParameter[] arrParam=new OracleParameter[22];
			for(int i=0;i<arrParam.Length;i++) 
				arrParam[i]=new OracleParameter();

			
			int n=-1;
			n++;arrParam[n].Value=objCharge.m_strPChargeID;
			n++;arrParam[n].Value=objCharge.m_strPatientID;
			n++;arrParam[n].Value=objCharge.m_strRegisterID;

			n++;arrParam[n].Value=objCharge.m_strOrderID;
			n++;arrParam[n].Value=objCharge.m_intOrderExecType;arrParam[n].OracleDbType=OracleDbType.Int32;
			n++;arrParam[n].Value=objCharge.m_strOrderExecID;

			n++;arrParam[n].Value=objCharge.m_strCalcCateID;
			n++;arrParam[n].Value=objCharge.m_strInvCateID;
			n++;arrParam[n].Value=objCharge.m_strChargeItemID;
			n++;arrParam[n].Value=objCharge.m_strChargeItemName;
			n++;arrParam[n].Value=objCharge.m_strUnit;
			n++;arrParam[n].Value=objCharge.m_dmlUnitPrice;arrParam[n].OracleDbType=OracleDbType.Decimal;

			n++;arrParam[n].Value=objCharge.m_dmlAmount;arrParam[n].OracleDbType=OracleDbType.Decimal;
			n++;arrParam[n].Value=objCharge.m_dmlDiscount;arrParam[n].OracleDbType=OracleDbType.Decimal;
			n++;arrParam[n].Value=objCharge.m_intIsMepay;arrParam[n].OracleDbType=OracleDbType.Int32;
			n++;arrParam[n].Value=objCharge.m_strDes;
			n++;arrParam[n].Value=objCharge.m_intCreateType;arrParam[n].OracleDbType=OracleDbType.Int32;

			n++;arrParam[n].Value=objCharge.m_strCreator;
			n++;arrParam[n].Value=objCharge.m_dtCreateDate;arrParam[n].OracleDbType=OracleDbType.Date;
			n++;arrParam[n].Value=objCharge.m_intPStatus;arrParam[n].OracleDbType=OracleDbType.Int32;

            n++; arrParam[n].Value = objCharge.m_strClacArea; arrParam[n].OracleDbType = OracleDbType.NVarchar2;
            n++; arrParam[n].Value = objCharge.m_strCreateArea; arrParam[n].OracleDbType = OracleDbType.NVarchar2;

			long lngAff=0;
			long lngRes =0;
			try
			{
				lngRes=new clsHRPTableService().lngExecuteParameterSQL(strSql,ref lngAff,
					arrParam[0],arrParam[1],arrParam[2],arrParam[3],arrParam[4],arrParam[5] ,
					arrParam[6],arrParam[7],arrParam[8],arrParam[9],arrParam[10],arrParam[11],
					arrParam[12],arrParam[13],arrParam[14] ,arrParam[15] ,arrParam[16],
					arrParam[17],arrParam[18],arrParam[19],arrParam[20],arrParam[21]);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;

		}
		[AutoComplete]
		public long m_mthModifyPatientCharge(clsBIHPatientCharge objCharge)
		{
			string strSql= @"
				update T_Opr_Bih_PatientCharge
				set PatientID_Chr = ?,	RegisterID_Chr =?,	
					OrderID_Chr=?,		OrderExecType_Int=?,  OrderExecID_Chr=? ,
					CalCCateID_Chr=?,	InvCateID_Chr=?,      ChargeItemID_Chr=?,   ChargeItemName_Chr=?,	Unit_Vchr=?,  UnitPrice_Dec=? ,
					AMount_Dec=?,		DisCount_Dec=?,		  IsMepay_Int =?,		Des_VChr =? ,			CreateType_Int=?, 
					Creator_Chr=?,		Create_Dat=?,		  Status_Int=1,			PStatus_Int=?　　　,CLACAREA_CHR=?
				where PChargeID_Chr = ? 

				";
			//
			OracleParameter[] arrParam=new OracleParameter[21];
			for(int i=0;i<arrParam.Length;i++) arrParam[i]=new OracleParameter();
			
			int n=-1;

			n++;arrParam[n].Value=objCharge.m_strPatientID;
			n++;arrParam[n].Value=objCharge.m_strRegisterID;

			n++;arrParam[n].Value=objCharge.m_strOrderID;
			n++;arrParam[n].Value=objCharge.m_intOrderExecType;arrParam[n].OracleDbType=OracleDbType.Int32;
			n++;arrParam[n].Value=objCharge.m_strOrderExecID;

			n++;arrParam[n].Value=objCharge.m_strCalcCateID;
			n++;arrParam[n].Value=objCharge.m_strInvCateID;
			n++;arrParam[n].Value=objCharge.m_strChargeItemID;
			n++;arrParam[n].Value=objCharge.m_strChargeItemName;
			n++;arrParam[n].Value=objCharge.m_strUnit;
			n++;arrParam[n].Value=objCharge.m_dmlUnitPrice;arrParam[n].OracleDbType=OracleDbType.Decimal;

			n++;arrParam[n].Value=objCharge.m_dmlAmount;arrParam[n].OracleDbType=OracleDbType.Decimal;
			n++;arrParam[n].Value=objCharge.m_dmlDiscount;arrParam[n].OracleDbType=OracleDbType.Decimal;
			n++;arrParam[n].Value=objCharge.m_intIsMepay;arrParam[n].OracleDbType=OracleDbType.Int32;
			n++;arrParam[n].Value=objCharge.m_strDes;
			n++;arrParam[n].Value=objCharge.m_intCreateType;arrParam[n].OracleDbType=OracleDbType.Int32;

			n++;arrParam[n].Value=objCharge.m_strCreator;
			n++;arrParam[n].Value=objCharge.m_dtCreateDate;arrParam[n].OracleDbType=OracleDbType.Date;
			n++;arrParam[n].Value=objCharge.m_intPStatus;arrParam[n].OracleDbType=OracleDbType.Int32;
            n++; arrParam[n].Value = objCharge.m_strClacArea; 

			n++;arrParam[n].Value=objCharge.m_strPChargeID;

			long lngAff =0;
			long lngRes =0;
			try
			{
				lngRes =new clsHRPTableService().lngExecuteParameterSQL(strSql,ref lngAff,
					arrParam[0],arrParam[1],arrParam[2],arrParam[3],arrParam[4],arrParam[5],
					arrParam[6],arrParam[7],arrParam[8],arrParam[9],arrParam[10],arrParam[11],
					arrParam[12],arrParam[13],arrParam[14],arrParam[15],arrParam[16],arrParam[17],
					arrParam[18],arrParam[19],arrParam[20]);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		[AutoComplete]
		public long m_mthDeletePatientCharge(string strChargeID)
		{
			string strSql=@"update T_Opr_Bih_PatientCharge Set Status_Int=0 Where PChargeID_Chr='" + strChargeID.Trim() + "' ";
			long lngRes =0;
			try
			{
				lngRes=new clsHRPTableService().DoExcute(strSql);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if(lngRes>0)
				return 1;
			else
				return 0;
		}

		[AutoComplete]
		public long m_lngGetChargeItem(string strItemID,out clsBIHChargeItem objItem)
		{
			string strSql="select A.*,A.ITEMPRICE_MNY ItemPrice from T_BSE_ChargeItem A Where A.ItemID_Chr='" + strItemID.Trim() + "' ";
			DataTable objDT=new DataTable();
			long lngRes =0;
			try
			{
				lngRes =new clsHRPTableService().DoGetDataTable(strSql,ref objDT);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if((lngRes>0) && (objDT!=null) && (objDT.Rows.Count>0))
			{
				objItem=m_objGetChargeItemFromRow(objDT.Rows[0]);
				return 1;
			}
			else
			{
				objItem=null;
				return 0;
			}
		}
		[AutoComplete]
		public long m_mthFindChargeItem(string strCode,out clsBIHChargeItem[] arrItem)
		{
			string strSql= @"
					SELECT   *,
							DECODE (ipchargeflg_int,
									1, ROUND (itemprice_mny / packqty_dec, 4),
									0, itemprice_mny,
									ROUND (itemprice_mny / packqty_dec, 4)
									) itemprice
						FROM t_bse_chargeitem 
					WHERE ROWNUM < 50
						AND (   (UPPER (TRIM (itemcode_vchr)) LIKE '[FindString]%')
							OR (UPPER (TRIM (itempycode_chr)) LIKE '[FindString]%')
							OR (UPPER (TRIM (itemwbcode_chr)) LIKE '[FindString]%')
							OR (UPPER (TRIM (itemname_vchr)) LIKE '%[FindString]%')
							)
					ORDER BY itemcode_vchr";

			strSql=strSql.Replace("[FindString]",strCode.ToUpper().Trim());
			DataTable objDT=new DataTable();
			long lngRes =0;
			try
			{
				lngRes=new clsHRPTableService().DoGetDataTable(strSql,ref objDT);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if((lngRes>0) && (objDT!=null))
			{
				arrItem=new clsBIHChargeItem[objDT.Rows.Count];

				for(int i=0;i<arrItem.Length;i++)
				{
					DataRow objRow=objDT.Rows[i];
					arrItem[i]= m_objGetChargeItemFromRow(objRow);
				}

				return 1;
			}
			else
			{
				arrItem=null;
				return 0;
			}
		}

        [AutoComplete]
        public long m_mthFindChargeItemWithYB(string strCode, out clsBIHChargeItem[] arrItem)
        {
            int m_intLessMedControl = -1;
            string m_strIPNOQTYFLAG="0";
            long lngRes = -1;
            DataTable objDT = new DataTable();
            string strSql = "select a.setstatus_int,a.setid_chr from t_sys_setting a where a.setid_chr in ('1025')";
            try
            {
                lngRes = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
                if (objDT.Rows.Count > 0)
                {
                    if (objDT.Rows[0]["setstatus_int"].ToString().Equals("0"))
                    {
                        m_intLessMedControl = 0;
                    }
                    else
                    {
                        m_intLessMedControl = 1;
                    }
                }
                strSql = @"
					SELECT   a.*,
							DECODE (a.ipchargeflg_int,
									1, ROUND (a.itemprice_mny / a.packqty_dec, 4),
									0, a.itemprice_mny,
									ROUND (a.itemprice_mny / a.packqty_dec, 4)
									) itemprice,
                             b.typename_vchr MedicareTypeName,
                             c.IPNOQTYFLAG_INT
						FROM t_bse_chargeitem a,T_AID_MEDICARETYPE b
                             ,T_BSE_MEDICINE c                             
					WHERE
                         a.INPINSURANCETYPE_VCHR=b.typeid_chr(+)
                         and a.ITEMSRCID_VCHR=c.medicineid_chr(+)
                         and ( c.IPNOQTYFLAG_INT IN ([IPNOQTYFLAG_INT]) or c.IPNOQTYFLAG_INT is null)
                         and a.IFSTOP_INT=0
                        and  ROWNUM < 50
						AND (   (UPPER (TRIM (itemcode_vchr)) LIKE '[FindString]%')
							OR (UPPER (TRIM (itempycode_chr)) LIKE '[FindString]%')
							OR (UPPER (TRIM (itemwbcode_chr)) LIKE '[FindString]%')
							OR (UPPER (TRIM (itemname_vchr)) LIKE '%[FindString]%')
							)
					ORDER BY itemcode_vchr";
                if (m_intLessMedControl == 0)
                {
                    m_strIPNOQTYFLAG = "0";
                }
                else
                {
                    m_strIPNOQTYFLAG = "0,1";
                }
                strSql = strSql.Replace("[FindString]", strCode.Trim().ToUpper());
                strSql = strSql.Replace("[IPNOQTYFLAG_INT]", m_strIPNOQTYFLAG.Trim());
            
                lngRes = new clsHRPTableService().DoGetDataTable(strSql, ref objDT);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            if ((lngRes > 0) && (objDT != null))
            {
                arrItem = new clsBIHChargeItem[objDT.Rows.Count];

                for (int i = 0; i < arrItem.Length; i++)
                {
                    DataRow objRow = objDT.Rows[i];
                    arrItem[i] = new clsBIHChargeItem();

                    arrItem[i].m_strItemID = clsConverter.ToString(objRow["ItemID_Chr"]).Trim();
                    arrItem[i].m_strItemName = clsConverter.ToString(objRow["ItemName_VChr"]).Trim();
                    arrItem[i].m_strItemCode = clsConverter.ToString(objRow["ItemCode_VChr"]).Trim();
                    arrItem[i].m_strPYCode = clsConverter.ToString(objRow["ItemPYCode_Chr"]).Trim();
                    arrItem[i].m_strWBCode = clsConverter.ToString(objRow["ItemWBCode_Chr"]).Trim();

                    arrItem[i].m_strItemSrcID = clsConverter.ToString(objRow["ItemSrcID_VChr"]).Trim();
                    arrItem[i].m_strSpec = clsConverter.ToString(objRow["ItemSpec_VChr"]).Trim();
                    arrItem[i].m_strUnit = clsConverter.ToString(objRow["ItemIpUnit_Chr"]).Trim();
                    arrItem[i].m_strItemIPCalcType = clsConverter.ToString(objRow["ItemIpCalcType_Chr"]).Trim();
                    arrItem[i].m_strItemIPInvType = clsConverter.ToString(objRow["ItemIpInvType_Chr"]).Trim();
                    arrItem[i].m_dmlPrice = clsConverter.ToDecimal(objRow["ItemPrice"]);
                    arrItem[i].m_intIsRich = clsConverter.ToInt(objRow["IsRich_Int"]); 
                    arrItem[i].m_strINSURACEDESC_VCHR = clsConverter.ToString(objRow["MedicareTypeName"].ToString().Trim());//医保信息ID
                    if (!objRow["ITEMSRCTYPE_INT"].ToString().Trim().Equals(""))
                    {
                        arrItem[i].m_intITEMSRCTYPE_INT = clsConverter.ToInt(objRow["ITEMSRCTYPE_INT"].ToString().Trim());
                    }
                    if (!objRow["IPNOQTYFLAG_INT"].ToString().Trim().Equals(""))
                    {
                        arrItem[i].m_intIPNOQTYFLAG_INT = clsConverter.ToInt(objRow["IPNOQTYFLAG_INT"].ToString().Trim());
                    } 
                    arrItem[i].m_dmlDOSAGE_DEC = clsConverter.ToDecimal(objRow["DOSAGE_DEC"].ToString().Trim()); 
                }

                return 1;
            }
            else
            {
                arrItem = null;
                return 0;
            }
        }

		[AutoComplete]
		private clsBIHChargeItem m_objGetChargeItemFromRow(DataRow objRow)
		{
			clsBIHChargeItem objItem=new clsBIHChargeItem();

			objItem.m_strItemID=clsConverter.ToString(objRow["ItemID_Chr"]).Trim();
			objItem.m_strItemName=clsConverter.ToString(objRow["ItemName_VChr"]).Trim();
			objItem.m_strItemCode=clsConverter.ToString(objRow["ItemCode_VChr"]).Trim();
			objItem.m_strPYCode=clsConverter.ToString(objRow["ItemPYCode_Chr"]).Trim();
			objItem.m_strWBCode=clsConverter.ToString(objRow["ItemWBCode_Chr"]).Trim();
					
			objItem.m_strItemSrcID=clsConverter.ToString(objRow["ItemSrcID_VChr"]).Trim();
			objItem.m_strSpec=clsConverter.ToString(objRow["ItemSpec_VChr"]).Trim();
			objItem.m_strUnit=clsConverter.ToString(objRow["ItemIpUnit_Chr"]).Trim();
			objItem.m_strItemIPCalcType=clsConverter.ToString(objRow["ItemIpCalcType_Chr"]).Trim();
			objItem.m_strItemIPInvType=clsConverter.ToString(objRow["ItemIpInvType_Chr"]).Trim();
			objItem.m_dmlPrice=clsConverter.ToDecimal(objRow["ItemPrice"]);
			objItem.m_intIsRich=clsConverter.ToInt(objRow["IsRich_Int"]);
           
			return objItem;
		}
	}
}
