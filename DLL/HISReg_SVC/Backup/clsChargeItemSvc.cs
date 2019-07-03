using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;

namespace com.digitalwave.iCare.middletier.HIS
{
	/// <summary>
	/// 收费项目以及各相关项目Svc Create By Sam 2004-6-9
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsChargeItemSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsChargeItemSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		//收费项目
		#region SQL
		//把收费项目明细中的所有项连接起来
		const string strSelect="SELECT a.itemid_chr, a.itemname_vchr, a.itemcode_vchr, a.itempycode_chr," +
			"a.itemwbcode_chr, a.itemsrcid_vchr, a.itemsrctype_int, a.itemspec_vchr,"+
			"a.itemprice_mny, a.itemunit_chr,a.itemopunit_chr, a.itemipunit_chr,"+
			"a.itemopcalctype_chr, a.itemipcalctype_chr, a.itemopinvtype_chr," +
			"a.itemipinvtype_chr, a.dosage_dec, a.dosageunit_chr, a.isgroupitem_int," +
			"a.itemcatid_chr, a.usageid_chr, Cat.itemcatname_vchr, OPCal.typename_vchr,"+
			"Usage.usagename_vchr,OPCal.typename_vchr OPCal,IPCal.typename_vchr IPCal,"+
			"OPInv.typename_vchr OPInv,IPInv.typename_vchr IPInv,OPUnit.unitname_chr OPUnit,"+
			"IPUnit.unitname_chr IPUnit,ItemUnit.unitname_chr ItemUnit,DosageUnit.unitname_chr DosageUnit "+
			"FROM t_bse_chargeitem a,t_bse_chargeitemcat Cat,t_bse_chargeitemextype OPCal, " +
			"t_bse_usagetype Usage,t_bse_chargeitemextype IPCal,t_bse_chargeitemextype OPInv,"+
			"t_bse_chargeitemextype IPInv,t_Aid_Unit OPUnit,t_Aid_Unit IPUnit,t_Aid_Unit ItemUnit, "+
			"t_Aid_Unit DosageUnit " +
			" Where a.itemcatid_chr=Cat.itemcatid_chr(+) And a.itemopcalctype_chr=OPCal.typeid_chr(+) "+
			" And a.itemopinvtype_chr=OPInv.typeid_chr(+) And a.itemopunit_chr=OPUnit.unitid_chr(+) " +
			" And a.itemipcalctype_chr=IPCal.typeid_chr(+) And a.itemipinvtype_chr=IPInv.typeid_chr(+) "+
			" And a.itemipunit_chr=IPUnit.unitid_chr(+) And a.itemunit_chr=ItemUnit.unitid_chr(+) And " +
			" a.usageid_chr=Usage.usageid_chr(+) And a.dosageunit_chr=DosageUnit.unitid_chr(+) ";
		#endregion
		#region 新增收费项目
		/// <summary>
		/// 新增收费项目(GroupID不为空时，需增加组的关系）
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <param name="p_strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewChargeItem(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItem_VO objResult,out string p_strID)
		{
			long lngRes = 0;
			p_strID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoAddNewChargeItem");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			lngRes=objHRPSvc.lngGenerateID(10,"itemid_chr","t_bse_chargeitem",out p_strID);
			if(lngRes<0)
				return -1;
			string strSQL= @"Insert Into t_bse_chargeitem  
				(ITEMID_CHR,ITEMNAME_VCHR,ITEMCODE_VCHR,ITEMPYCODE_CHR,ITEMWBCODE_CHR, 
				ITEMSPEC_VCHR,ITEMPRICE_MNY,ITEMUNIT_CHR,ITEMOPUNIT_CHR,ITEMIPUNIT_CHR, 
				ITEMOPCALCTYPE_CHR,ITEMIPCALCTYPE_CHR,ITEMOPINVTYPE_CHR,ITEMIPINVTYPE_CHR,DOSAGE_DEC, 
				DOSAGEUNIT_CHR,ITEMCATID_CHR,USAGEID_CHR,ITEMOPCODE_CHR,INSURANCEID_CHR,SELFDEFINE_INT,PACKQTY_DEC,TRADEPRICE_MNY,POFLAG_INT,ISRICH_INT,OPCHARGEFLG_INT,ITEMENGNAME_VCHR,IFSTOP_INT, 
                PDCAREA_VCHR,IPCHARGEFLG_INT,INSURANCETYPE_VCHR,APPLY_TYPE_INT,ITEMBIHCTYPE_CHR,ITEMCHECKTYPE_CHR,ITEMCOMMNAME_VCHR,ORDERCATEID_CHR,FREQID_CHR,INPINSURANCETYPE_VCHR,ORDERCATEID1_CHR,ISSELFPAY_CHR,KEEPUSE_INT, ischargemate) Values (?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?, ?)";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(42,out objLisAddItemRefArr);
				objLisAddItemRefArr[0].Value = p_strID;
				objLisAddItemRefArr[1].Value = objResult.m_strItemName;
				objLisAddItemRefArr[2].Value = objResult.m_strItemCode;
				objLisAddItemRefArr[3].Value = objResult.m_strItemPYCode;
				objLisAddItemRefArr[4].Value = objResult.m_strItemWBCode;
				objLisAddItemRefArr[5].Value = objResult.m_strItemSpec;
				objLisAddItemRefArr[6].Value = objResult.m_fltItemPrice;
				objLisAddItemRefArr[7].Value = objResult.m_ItemUnit.m_strUnitID;
				objLisAddItemRefArr[8].Value = objResult.m_ItemOPUnit.m_strUnitID;
				objLisAddItemRefArr[9].Value = objResult.m_ItemIPUnit.m_strUnitID;
				objLisAddItemRefArr[10].Value = objResult.m_ItemOPCalcType.m_strTypeID;
				objLisAddItemRefArr[11].Value = objResult.m_ItemIPCalcType.m_strTypeID;
				objLisAddItemRefArr[12].Value = objResult.m_ItemOPInvType.m_strTypeID;
				objLisAddItemRefArr[13].Value = objResult.m_ItemIPInvType.m_strTypeID;
				objLisAddItemRefArr[14].Value = objResult.m_strDosage;
				objLisAddItemRefArr[15].Value = objResult.m_DosageUnit.m_strUnitID;
				objLisAddItemRefArr[16].Value = objResult.m_ItemCat.m_strItemCatID;
				objLisAddItemRefArr[17].Value = objResult.m_Usage.m_strUsageID;
				objLisAddItemRefArr[18].Value = objResult.m_strITEMOPCODE_CHR;
				objLisAddItemRefArr[19].Value = objResult.m_strINSURANCEID_CHR;//
				objLisAddItemRefArr[20].Value = objResult.m_intSELFDEFINE_INT;//
				objLisAddItemRefArr[21].Value = objResult.m_decPACKQTY_DEC;//
				objLisAddItemRefArr[22].Value = objResult.m_fltTradePrice;//
				objLisAddItemRefArr[23].Value = objResult.m_intPOFLAG_INT;//
				objLisAddItemRefArr[24].Value = objResult.m_intISRICH_INT;//
				objLisAddItemRefArr[25].Value = objResult.m_intOPCHARGEFLG_INT;//
				objLisAddItemRefArr[26].Value = objResult.m_strEnglishName;//
				objLisAddItemRefArr[27].Value = objResult.m_intStopFlag;//
				objLisAddItemRefArr[28].Value = objResult.m_strProducing;//
				objLisAddItemRefArr[29].Value = objResult.m_intIPCHARGEFLG_INT;//
				objLisAddItemRefArr[30].Value = objResult.m_strINSURANCETYPE;//
				objLisAddItemRefArr[31].Value = objResult.m_strAPPLY_TYPE_INT;//
				objLisAddItemRefArr[32].Value = objResult.m_strITEMBIHCTYPE_CHR;//
				objLisAddItemRefArr[33].Value = objResult.strCheckPartID;
                objLisAddItemRefArr[34].Value = objResult.m_strCommName;
                objLisAddItemRefArr[35].Value = objResult.m_strORDERCATEID;
                objLisAddItemRefArr[36].Value = objResult.m_strDefaultFreq;
                objLisAddItemRefArr[37].Value = objResult.m_strINPINSURANCETYPE;
                objLisAddItemRefArr[38].Value = objResult.m_strOrderCateID;
                objLisAddItemRefArr[39].Value = objResult.m_strISSELFPAY_CHR;
                objLisAddItemRefArr[40].Value = objResult.m_intKeepUse;
                objLisAddItemRefArr[41].Value = objResult.isChargeMate;
				long lngRecEff = -1;
				//往表增加记录
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);

								if(lngRes<0)
									return -1;
				strSQL="select PAYTYPEID_CHR from T_BSE_PATIENTPAYTYPE where ISUSING_NUM =1";
				DataTable dt =new DataTable();
				long l=objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				if(l>0&&dt.Rows.Count>0)
				{
					for(int i=0;i<dt.Rows.Count;i++)
					{
					    strSQL="insert into T_AID_INSCHARGEITEM(PRECENT_DEC,ITEMID_CHR,COPAYID_CHR)values ('100','"+p_strID+"','"+dt.Rows[i][0].ToString().Trim()+"')";
					    l=objHRPSvc.DoExcute(strSQL);                        					
					}
				
				}
                #region 插入诊疗项目数据
                string newbihID = "";
                strSQL = @"select lpad(seq_ORDERDICID.NEXTVAL,10,'0') p_strRecordID   from dual";
                DataTable dtbih = new DataTable();
                try
                {
                    lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbih);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
  
                if (dtbih.Rows.Count > 0)
                {
                    newbihID = dtbih.Rows[0]["p_strRecordID"].ToString().Trim();
                }


                strSQL = @"insert into t_bse_bih_orderdic(ORDERDICID_CHR,NAME_CHR,DES_VCHR,USERCODE_CHR,WBCODE_CHR,PYCODE_CHR,ORDERCATEID_CHR,ITEMID_CHR,NULLITEMUSEUNIT_CHR,NULLITEMDOSETYPEID_CHR,ENGNAME_VCHR,COMMNAME_VCHR,STATUS_INT) values('" + newbihID + "','" + objResult.m_strItemName + "','收费项目自动生成','" + objResult.m_strItemCode + "','" + objResult.m_strItemWBCode + "','" + objResult.m_strItemPYCode + "','" + objResult.m_strOrderCateID + "','" + p_strID + "','" + objResult.m_DosageUnit.m_strUnitName + "','" + objResult.m_Usage.m_strUsageID + "','" + objResult.m_strEnglishName + "','" + objResult.m_strCommName + "',"+(objResult.m_intStopFlag==0?1:0)+")";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

                string newbihDeID = "";
                strSQL = @"select lpad(seq_ocmapid.NEXTVAL,18,'0') p_strRecordID  from dual";
                DataTable m_objTable = new DataTable();
                try
                {
                    lngRes=objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                    if (m_objTable.Rows.Count > 0)
                    {
                        newbihDeID = m_objTable.Rows[0][0].ToString();
                    }
                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }

                strSQL = @"INSERT INTO t_aid_bih_orderdic_charge
            (ocmapid_chr, orderdicid_chr, itemid_chr, qty_int, type_int
            ) VALUES('" + newbihDeID + "','" + newbihID + "','" + p_strID + "',1," + objResult.m_intBIHTYPE_INT + ")";
                try
                {
                    lngRes = objHRPSvc.DoExcute(strSQL);

                }
                catch (Exception objEx)
                {
                    string strTmp = objEx.Message;
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
                #endregion
				objHRPSvc.Dispose();
				 
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 修改收费项目
		/// <summary>
		/// 修改收费项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdChargeItemByID(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItem_VO objResult,string strOperatorID)
		{
			long lngRes = 0;
			//p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoAddNewChargeItem");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}	
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL= @"Update t_bse_chargeitem Set 
				 ITEMNAME_VCHR=?,ITEMCODE_VCHR=?, 
				ITEMPYCODE_CHR=?,itemwbcode_chr=?,
				ITEMSPEC_VCHR=?,ITEMPRICE_MNY=?,
				ITEMUNIT_CHR=?,ITEMOPUNIT_CHR=?,
				ITEMIPUNIT_CHR=?,
				ITEMOPCALCTYPE_CHR=?, 
				ITEMIPCALCTYPE_CHR=?,
				ITEMOPINVTYPE_CHR=?, 
				ITEMIPINVTYPE_CHR=?,
				DOSAGE_DEC=?, 
				DOSAGEUNIT_CHR=?, 
				ITEMCATID_CHR=?,
				USAGEID_CHR=?, 
				ITEMOPCODE_CHR=?, 
				INSURANCEID_CHR=?, 
				SELFDEFINE_INT=?, 
				PACKQTY_DEC=?, 
				TRADEPRICE_MNY=?,
                POFLAG_INT=?, 
				ISRICH_INT=?, 
				ITEMENGNAME_VCHR=?, 
				IFSTOP_INT=?, 
				PDCAREA_VCHR=?, 
				IPCHARGEFLG_INT=?, 
				OPCHARGEFLG_INT=?,
				INSURANCETYPE_VCHR=?, 
				APPLY_TYPE_INT=?,
				ITEMCHECKTYPE_CHR=?,
				ITEMBIHCTYPE_CHR=?,
                ITEMCOMMNAME_VCHR=? ,
                ORDERCATEID_CHR=? ,
                FREQID_CHR=?,
                INPINSURANCETYPE_VCHR=?,
                ORDERCATEID1_CHR=?,
                ISSELFPAY_CHR=?,
                KEEPUSE_INT=?, 
                ischargemate = ? 
				Where itemid_chr=? ";
			System.Data.IDataParameter[] objLisAddItemRefArr = null;
			objHRPSvc.CreateDatabaseParameter(42,out objLisAddItemRefArr);
			objLisAddItemRefArr[0].Value = objResult.m_strItemName;
			objLisAddItemRefArr[1].Value = objResult.m_strItemCode;
			objLisAddItemRefArr[2].Value = objResult.m_strItemPYCode;
			objLisAddItemRefArr[3].Value = objResult.m_strItemWBCode;
			objLisAddItemRefArr[4].Value = objResult.m_strItemSpec;
			objLisAddItemRefArr[5].Value = objResult.m_fltItemPrice;
			objLisAddItemRefArr[6].Value = objResult.m_ItemUnit.m_strUnitID;
			objLisAddItemRefArr[7].Value = objResult.m_ItemOPUnit.m_strUnitID;
			objLisAddItemRefArr[8].Value = objResult.m_ItemIPUnit.m_strUnitID;
			objLisAddItemRefArr[9].Value = objResult.m_ItemOPCalcType.m_strTypeID;
			objLisAddItemRefArr[10].Value = objResult.m_ItemIPCalcType.m_strTypeID;
			objLisAddItemRefArr[11].Value = objResult.m_ItemOPInvType.m_strTypeID;
			objLisAddItemRefArr[12].Value = objResult.m_ItemIPInvType.m_strTypeID;
			objLisAddItemRefArr[13].Value = objResult.m_strDosage;
			objLisAddItemRefArr[14].Value = objResult.m_DosageUnit.m_strUnitID;
			objLisAddItemRefArr[15].Value = objResult.m_ItemCat.m_strItemCatID;
			objLisAddItemRefArr[16].Value = objResult.m_Usage.m_strUsageID;
			objLisAddItemRefArr[17].Value = objResult.m_strITEMOPCODE_CHR;
			objLisAddItemRefArr[18].Value = objResult.m_strINSURANCEID_CHR;
			objLisAddItemRefArr[19].Value = objResult.m_intSELFDEFINE_INT;
			objLisAddItemRefArr[20].Value = objResult.m_decPACKQTY_DEC;
			objLisAddItemRefArr[21].Value = objResult.m_fltTradePrice;
			objLisAddItemRefArr[22].Value = objResult.m_intPOFLAG_INT;
			objLisAddItemRefArr[23].Value = objResult.m_intISRICH_INT;
			objLisAddItemRefArr[24].Value = objResult.m_strEnglishName;
			objLisAddItemRefArr[25].Value = objResult.m_intStopFlag;
			objLisAddItemRefArr[26].Value = objResult.m_strProducing;
			objLisAddItemRefArr[27].Value = objResult.m_intIPCHARGEFLG_INT;
			objLisAddItemRefArr[28].Value = objResult.m_intOPCHARGEFLG_INT;
			objLisAddItemRefArr[29].Value = objResult.m_strINSURANCETYPE;
			objLisAddItemRefArr[30].Value = objResult.m_strAPPLY_TYPE_INT;
			objLisAddItemRefArr[31].Value = objResult.strCheckPartID;
			objLisAddItemRefArr[32].Value = objResult.m_strITEMBIHCTYPE_CHR;
            objLisAddItemRefArr[33].Value = objResult.m_strCommName;
            objLisAddItemRefArr[34].Value = objResult.m_strORDERCATEID;
            objLisAddItemRefArr[35].Value = objResult.m_strDefaultFreq;
            objLisAddItemRefArr[36].Value = objResult.m_strINPINSURANCETYPE;
            objLisAddItemRefArr[37].Value = objResult.m_strOrderCateID;
            objLisAddItemRefArr[38].Value = objResult.m_strISSELFPAY_CHR;
            objLisAddItemRefArr[39].Value = objResult.m_intKeepUse;
            objLisAddItemRefArr[40].Value = objResult.isChargeMate;
            objLisAddItemRefArr[41].Value = objResult.m_strItemID;
			try
			{
				long ret = 0;
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref ret,objLisAddItemRefArr);
                //strSQL = @"update  t_bse_bih_orderdic  set NAME_CHR=?,USERCODE_CHR=?,WBCODE_CHR=?,PYCODE_CHR=?,ORDERCATEID_CHR=?,NULLITEMUSEUNIT_CHR=?,NULLITEMDOSETYPEID_CHR=?,ENGNAME_VCHR=?,COMMNAME_VCHR=?,STATUS_INT=? where ITEMID_CHR=?";
                //objLisAddItemRefArr = null;
                //objHRPSvc.CreateDatabaseParameter(11, out objLisAddItemRefArr);
                //objLisAddItemRefArr[0].Value = objResult.m_strItemName;
                //objLisAddItemRefArr[1].Value = objResult.m_strItemCode;
                //objLisAddItemRefArr[2].Value = objResult.m_strItemWBCode;
                //objLisAddItemRefArr[3].Value = objResult.m_strItemPYCode;
              
                //objLisAddItemRefArr[4].Value = objResult.m_strOrderCateID;
                //objLisAddItemRefArr[5].Value = objResult.m_DosageUnit.m_strUnitName;
                //objLisAddItemRefArr[6].Value = objResult.m_Usage.m_strUsageID;
                //objLisAddItemRefArr[7].Value = objResult.m_strEnglishName;
                //objLisAddItemRefArr[8].Value = objResult.m_strCommName;
                //objLisAddItemRefArr[9].Value = objResult.m_intStopFlag==0?1:0;
                //objLisAddItemRefArr[10].Value = objResult.m_strItemID;
                //lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref ret, objLisAddItemRefArr);
          
				if(objResult.m_fltItemPrice!=objResult.m_fltPrePrice)
				{
					string p_strID="";
					lngRes=objHRPSvc.lngGenerateID(20,"SEQID_CHR","T_OPR_CHARGEITEMPRICEHIS",out p_strID);
					#region
					strSQL="Insert Into T_OPR_CHARGEITEMPRICEHIS " +
						"(SEQID_CHR,ITEMID_CHR,EFFECT_DAT,PREPRICE_MNY,CURPRICE_MNY," +
						"UNIT_VCHR,PSTATUS_INT,RECORDEMPID_CHR,RECORDE_DAT) Values " +"(?,?,to_date(?,'yyyy-mm-dd hh24:mi:ss'),?,?,?,?,?,to_date(?,'yyyy-mm-dd hh24:mi:ss'))";
		
					System.Data.IDataParameter[] objLisAddItemRefArr2 = null;
					objHRPSvc.CreateDatabaseParameter(9,out objLisAddItemRefArr2);
					//Please change the datetime and reocrdid 
					objLisAddItemRefArr2[0].Value = p_strID;
					objLisAddItemRefArr2[1].Value = objResult.m_strItemID;
					objLisAddItemRefArr2[2].Value = DateTime.Now.ToString();
					objLisAddItemRefArr2[3].Value = objResult.m_fltPrePrice;
					objLisAddItemRefArr2[4].Value = objResult.m_fltItemPrice;
					objLisAddItemRefArr2[5].Value = objResult.m_ItemUnit.m_strUnitName;
					objLisAddItemRefArr2[6].Value = 1;
					objLisAddItemRefArr2[7].Value = strOperatorID;
					objLisAddItemRefArr2[8].Value = DateTime.Now.ToString();
					long lngRecEff = -1;
					//往表增加记录
					lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr2);
					#endregion
				}
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 关联其它收费项目的方法
		/// <summary>
		/// 获取已经关联的项目数据
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="itemID"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_getSUBCHARGEITEM(System.Security.Principal.IPrincipal p_objPrincipal,string itemID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes = 0;
			//p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_getSUBCHARGEITEM");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select b.ITEMCODE_VCHR,b.IFSTOP_INT,b.ITEMNAME_VCHR,b.ITEMID_CHR,b.ITEMSPEC_VCHR,a.USAGEID_CHR,a.FREQID_CHR,a.DAYS_INT,'1' as UpFlag ,c.NOQTYFLAG_INT,b.ITEMPRICE_MNY,e.FREQNAME_CHR,b.ITEMOPUNIT_CHR,d.USAGENAME_VCHR,a.QTY_INT as usaQTY,TOTALQTY_DEC as QTY_INT,c.medicinetypeid_chr,c.IFSTOP_INT ,e.TIMES_INT,e.DAYS_INT as DAYS_INT1,b.DOSAGE_DEC,       CASE
          WHEN usescope_int = 0
             THEN '主项目'
          ELSE '所有主项目'
       END usescope_int ,'' as newusescope_int,
       case   WHEN CONTINUEUSETYPE_INT = 0
             THEN '连续用'
          ELSE '首次用'
       END CONTINUEUSETYPE_INT
       from T_BSE_SUBCHARGEITEM a,t_bse_chargeitem b,t_bse_medicine  c,t_bse_usagetype d,t_aid_recipefreq e where a.SUBITEMID_CHR=b.ITEMID_CHR  and b.ITEMSRCID_VCHR=c.MEDICINEID_CHR(+) and a.ITEMID_CHR='" + itemID + "' and a.USAGEID_CHR=d.USAGEID_CHR(+) and a.FREQID_CHR=e.FREQID_CHR(+) order by b.ITEMCODE_VCHR";

			try
			{
					
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		/// <summary>
		/// 保存数据
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="itemID"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngSaveSunItem(System.Security.Principal.IPrincipal p_objPrincipal,string itemID, DataTable dt,DataTable dtUpdata)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngSaveSunItem");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL = @"delete  T_BSE_SUBCHARGEITEM  where ITEMID_CHR='"+itemID+"'";
			try
			{
					
				lngRes = objHRPSvc.DoExcute(strSQL);					
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			if(dt.Rows.Count>0)
			{
				for(int i1=0;i1<dt.Rows.Count;i1++)
				{
                    strSQL = @"insert into T_BSE_SUBCHARGEITEM(ITEMID_CHR,SUBITEMID_CHR,QTY_INT,USAGEID_CHR,FREQID_CHR,DAYS_INT,TOTALQTY_DEC,UseScope_int,CONTINUEUSETYPE_INT) values('" + dt.Rows[i1]["ITEMID_CHR"].ToString() + "','" + dt.Rows[i1]["SUBITEMID_CHR"].ToString() + "','" + dt.Rows[i1]["QTY_INT"].ToString() + "','" + dt.Rows[i1]["USAGEID_CHR"].ToString() + "','" + dt.Rows[i1]["FREQID_CHR"].ToString() + "','" + dt.Rows[i1]["DAYS_INT"].ToString() + "','" + dt.Rows[i1]["TOTALQTY_DEC"].ToString() + "'," + dt.Rows[i1]["UseScope_int"].ToString() + "," + dt.Rows[i1]["CONTINUEUSETYPE_INT"].ToString() + ")";
					try
					{
						lngRes = objHRPSvc.DoExcute(strSQL);				
					}
					catch(Exception objEx)
					{
						string strTmp=objEx.Message;
						com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
						bool blnRes = objLogger.LogError(objEx);
					}
				}
			}
			if(dtUpdata!=null)
			{
				for(int i1=0;i1<dtUpdata.Rows.Count;i1++)
				{
					strSQL=@"update T_BSE_SUBCHARGEITEM set SUBITEMID_CHR='"+dtUpdata.Rows[i1]["UPID"].ToString()+"' where SUBITEMID_CHR='"+dtUpdata.Rows[i1]["ID"].ToString()+"'";
					try
					{
					
						lngRes = objHRPSvc.DoExcute(strSQL);				
					}
					catch(Exception objEx)
					{
						string strTmp=objEx.Message;
						com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
						bool blnRes = objLogger.LogError(objEx);
					}
				}

			}
			return lngRes;
		}
		/// <summary>
		/// 删除子项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="itemID"></param>
		/// <param name="sumItemID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeleteSunItem(System.Security.Principal.IPrincipal p_objPrincipal,string itemID, string sumItemID,bool isDeleAll)
		{
			long lngRes = 0;
			//p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngSaveSunItem");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL ="";
			if(isDeleAll==true)
			{
				strSQL=@"delete  T_BSE_SUBCHARGEITEM  where SUBITEMID_CHR='"+sumItemID+"'";
			}
			else
			{
				strSQL=@"delete  T_BSE_SUBCHARGEITEM  where ITEMID_CHR='"+itemID+"' and SUBITEMID_CHR='"+sumItemID+"'";
			}
			try
			{
					
				lngRes = objHRPSvc.DoExcute(strSQL);					
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		/// <summary>
		/// 查询项目数据
		/// </summary>
		/// <param name="p_strFindString"></param>
		/// <param name="p_dtResult"></param>
		/// <param name="p_objPrincipal"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthFindMedicineByID(out DataTable p_dtResult,System.Security.Principal.IPrincipal p_objPrincipal,string findFild,string strFind)
		{
			p_dtResult =new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindMedicineByID");
			if(lngRes < 0)
			{
				return -1;
			}
			string strWhere="";
			if(strFind!="")
				strWhere=" and UPPER (a."+findFild+") like '"+strFind.ToUpper().Trim()+"%'";
			string strSQL = @"SELECT   a.itemid_chr, a.itemname_vchr, a.itemspec_vchr, a.itemengname_vchr,
         a.itemopunit_chr, a.itemipunit_chr, a.dosageunit_chr,a.ITEMUNIT_CHR, a.packqty_dec,
         ROUND (a.itemprice_mny / a.packqty_dec, 4) submoney, a.itemprice_mny,
         a.itemcode_vchr TYPE, b.noqtyflag_int, b.mindosage_dec,
         b.maxdosage_dec, b.adultdosage_dec, b.childdosage_dec,
         b.nmldosage_dec, b.hype_int, a.opchargeflg_int, a.usageid_chr,b.medicinetypeid_chr,
         a.itemopinvtype_chr, c.usagename_vchr, a.dosage_dec, a.itemcode_vchr, g.partname,(SELECT k.typename_vchr
            FROM t_bse_chargeitemextype k
           WHERE k.typeid_chr = a.itemopinvtype_chr
             AND flag_int = 2) AS itemtype,a.FREQID_CHR ,d.FREQNAME_CHR 
    FROM t_bse_chargeitem a,
         t_bse_medicine b,
         t_bse_usagetype c,
         ar_apply_partlist g,
         t_aid_recipefreq d 
   WHERE TRIM (a.itemsrcid_vchr) = TRIM (b.medicineid_chr(+))
     AND a.ifstop_int = 0
     AND a.usageid_chr = c.usageid_chr(+)
     and a.freqid_chr=d.freqid_chr(+)
     AND a.itemchecktype_chr = g.partid(+) " + strWhere+@"
ORDER BY a.itemcode_vchr";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dtResult);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 获取医保分类
		[AutoComplete]
		public long m_getMEDICARETYPE(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes = 0;
			//p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoAddNewChargeItem");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			string strSQL = @"select USERCODE_CHR,TYPENAME_VCHR,TYPEID_CHR from T_AID_MEDICARETYPE";

			try
			{
					
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}

		#endregion
		#region 删除收费项目
		/// <summary>
		/// 删除收费项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeleteChargeItemByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoAddNewChargeItem");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			try
			{
				string strSQL="Delete t_bse_chargeitem  " +
					" Where itemid_chr='"+strID+"' ";
				lngRes = objHRPSvc.DoExcute(strSQL);
				strSQL="Delete T_AID_INSCHARGEITEM where ITEMID_CHR ='"+strID+"'";
				long l=objHRPSvc.DoExcute(strSQL);
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		
		}
		#endregion
		#region 判断编号是否使用
		[AutoComplete]
		public long m_mthItemIsUsed(string strCode,string strItemID)
		{
			long lngRes = 0;
			
			string strSQL="select * from T_BSE_CHARGEITEM where ITEMCODE_VCHR ='"+strCode+"'";
			if(strItemID.Trim()!="")
			{
			strSQL +="and  ITEMID_CHR <> '"+strItemID+"'";
			}
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);
				objHRPSvc.Dispose();
				if(lngRes>0 )
				{
				lngRes =dtResult.Rows.Count;
				}
					
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 改变项目分类
		/// <summary>
		/// 改变项目分类
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthChangeCat(System.Security.Principal.IPrincipal p_objPrincipal,string strID,string strType)
		{
			long lngRes = 0;
			//p_strRecordID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_mthChangeCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			try
			{
				string strSQL="Update t_bse_chargeitem set ITEMCATID_CHR ='"+strType+"' Where itemid_chr='"+strID+"' ";
				lngRes = objHRPSvc.DoExcute(strSQL);
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		
		}
		#endregion
		//收费项目组
		#region 新增项目组
		/// <summary>
		/// 新增项目组
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewChargeItemGroup(System.Security.Principal.IPrincipal p_objPrincipal,
			clsChargeItemGroup_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoAddNewChargeItemGroup");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}		
			string strSQL="Insert Into t_bse_chargeitemgroup " +
				" (groupitemid_chr,detailitemid_chr,rowno_chr) " +
				" Values ('"+objResult.m_strGroupItemID+"'," +
				"'"+objResult.m_strDetailItemID+"','"+objResult.m_strRowNo+"')";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 修改项目组
		/// <summary>
		/// 修改项目组(暂时没用的，因只是改变项目之间的关系）
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdChargeItemGroup(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItemGroup_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoUpdChargeItemGroup");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDate t_bse_chargeitemgroup  Set " +
				"detailitemid_chr='"+objResult.m_strDetailItemID+"'," +
				"rowno_chr='"+objResult.m_strRowNo+"' " +
				"Where groupitemid_chr='"+objResult.m_strGroupItemID+"' And " +
				"detailitemid_chr='"+objResult.m_strDetailItemID+"' ";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);	
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 删除项目组
		/// <summary>
		/// 删除项目组（删除项目与组的关系）
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelChargeItemGroup(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItemGroup_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDelChargeItemGroup");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Delete t_bse_chargeitemgroup " +
				" Where groupitemid_chr='"+objResult.m_strGroupItemID+"' And " +
				"detailitemid_chr='"+objResult.m_strDetailItemID+"' ";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 检查是否存在项目组（项目是否已存在组中）
		/// <summary>
		/// 检查是否存在项目组（项目是否已存在组中）
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public bool m_lngIsExistChargeItemGroup(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItemGroup_VO objResult)
		{
			long lngRes = 0;
			bool IsExist=false;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngIsExistChargeItemGroup");
			if(lngRes < 0) //没有使用的权限
			{
				return true;
			}
			string strSQL="Select * t_bse_chargeitemgroup " +
				" Where groupitemid_chr='"+objResult.m_strGroupItemID+"' And " +
				"detailitemid_chr='"+objResult.m_strDetailItemID+"' ";
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);
					objHRPSvc.Dispose();
				if(lngRes>0 && dtResult.Rows.Count>0)
					return true; //存在项目组
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return IsExist;
		}
		#endregion
		//收费项目分类类型
		#region  新增收费项目分类类型
		/// <summary>
		/// 新增收费项目分类类型(如西药费之类的）
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strName"></param>
		/// <param name="p_strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewChargeItemCat(System.Security.Principal.IPrincipal p_objPrincipal,clsCharegeItemCat_VO objResult)
		{
			long lngRes = 0;
			//			p_strID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoAddNewChargeItemCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			//			lngRes=objHRPSvc.lngGenerateID(4,"itemcatid_chr","t_bse_chargeitemcat",out p_strID);
			//			if(lngRes<0)
			//				return -1;
			string strSQL="Insert Into t_bse_chargeitemcat (itemcatid_chr, itemcatname_vchr) Values " +
				" ('"+objResult.m_strItemCatID+"','"+objResult.m_strItemCatName+"')";
         
			try
			{
				lngRes = objHRPSvc.DoExcute(strSQL);	
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 修改收费项目分类类型
		/// <summary>
		/// 修改收费类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdChargeItemCatByID(System.Security.Principal.IPrincipal p_objPrincipal,clsCharegeItemCat_VO objResult,string ID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoUpdChargeItemCatByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDate t_bse_chargeitemcat Set  " +
				"itemcatname_vchr='"+objResult.m_strItemCatName+"', " +
				"itemcatid_chr='"+objResult.m_strItemCatID+"'" +
				" Where itemcatid_chr='"+ID+"' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);	
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 删除收费项目分类类型
		/// <summary>
		/// 删除收费项目分类类型
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeleteChargeItemCatByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDeleteChargeItemCatByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Delete t_bse_chargeitemcat " +
				" Where itemcatid_chr='"+strID+"' ";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 收费项目分类类型(返回所有的类别)
		/// <summary>
		/// 收费项目分类类型(返回所有的类别)
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindChargeItemCatList(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsCharegeItemCat_VO[] objResult)
		{
			long lngRes = 0;
			objResult=new clsCharegeItemCat_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoAddNewChargeItem");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Select itemcatid_chr sID,itemcatname_vchr sName  From t_bse_chargeitemcat order by ITEMCATID_CHR";
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);
					objHRPSvc.Dispose();
				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					objResult=new clsCharegeItemCat_VO[dtResult.Rows.Count];
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1]=new clsCharegeItemCat_VO();
						objResult[i1].m_strItemCatID=dtResult.Rows[i1][0].ToString().Trim();
						objResult[i1].m_strItemCatName=dtResult.Rows[i1][1].ToString().Trim();
						
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		//收费特殊类别
		#region 新增特殊类别
		/// <summary>
		/// 新增特殊类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <param name="p_strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewChargeItemEXType(System.Security.Principal.IPrincipal p_objPrincipal,
			clsChargeItemEXType_VO objResult)
		{
			long lngRes = 0;
		
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoAddNewChargeItemEXType");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
//			lngRes=objHRPSvc.lngGenerateID(4,"typeid_chr","t_bse_chargeitemextype",out p_strID);
//			if(lngRes<0)
//				return -1;
			string strSQL="Insert Into t_bse_chargeitemextype (typeid_chr,typename_vchr,flag_int,USERCODE_CHR,SORTCODE_INT,GOVTOPCHARGE_MNY) " +
				" Values (?,?,?,?,?,?) " ;
			try
            {
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(6, out paramArr);
                paramArr[0].Value = objResult.m_strTypeID;
                paramArr[1].Value = objResult.m_strTypeName;
                paramArr[2].Value = objResult.m_intFlag;
                paramArr[3].Value = objResult.m_strUSERCODE_CHR;
                paramArr[4].Value = objResult.m_intSORTCODE_INT;
                paramArr[5].Value = objResult.m_decGOVTOPCHARGE_MNY;

                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
			    objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 修改特殊类别
		/// <summary>
		/// 修改特殊类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdChargeItemEXTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItemEXType_VO objResult,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoUpdChargeItemEXTypeByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDate t_bse_chargeitemextype  " +
				" set typename_vchr=?, "+
				" USERCODE_CHR=?, " +
				" typeid_chr=?, " +
				" GOVTOPCHARGE_MNY=?, " +
				" SORTCODE_INT=? " +
				" Where typeid_chr=? and flag_int =?" ;
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(7, out paramArr);
                paramArr[0].Value = objResult.m_strTypeName;
                paramArr[1].Value = objResult.m_strUSERCODE_CHR;
                paramArr[2].Value = objResult.m_strTypeID;
                paramArr[3].Value = objResult.m_decGOVTOPCHARGE_MNY;
                paramArr[4].Value = objResult.m_intSORTCODE_INT;
                paramArr[5].Value = strID;
                paramArr[6].Value = objResult.m_intFlag;
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 删除特殊类别
		/// <summary>
		/// 删除特殊类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDeleteCharegeItemEXTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDeleteCharegeItemEXTypeByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Delete t_bse_chargeitemextype  " +
				" Where typeid_chr='"+strID+"' " ;
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);	
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		
		}
		#endregion
		#region 根据特殊类别标志查找特殊类别
		/// <summary>
		/// 根据特殊类别标志查找特殊类别
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="intFlag"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindChargeItemEXTypeListByFlag(System.Security.Principal.IPrincipal p_objPrincipal,
			string intFlag,out clsChargeItemEXType_VO[] objResult)
		{
			long lngRes = 0;
			objResult=new clsChargeItemEXType_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngFindChargeItemEXTypeListByFlag");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Select * From t_bse_chargeitemextype ";
			if(intFlag!="")
				strSQL=strSQL + " Where flag_int='"+intFlag+"' order by SORTCODE_INT";
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);				
				objHRPSvc.Dispose();
				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					objResult=new clsChargeItemEXType_VO[dtResult.Rows.Count];
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1]=new clsChargeItemEXType_VO();
						objResult[i1].m_strTypeID=dtResult.Rows[i1]["typeid_chr"].ToString().Trim();
						objResult[i1].m_strTypeName=dtResult.Rows[i1]["typename_vchr"].ToString().Trim();
						if(dtResult.Rows[i1]["flag_int"].ToString().Trim()!="")
							objResult[i1].m_intFlag=int.Parse(dtResult.Rows[i1]["flag_int"].ToString().Trim());
						objResult[i1].m_strUSERCODE_CHR=dtResult.Rows[i1]["USERCODE_CHR"].ToString().Trim();
						if(dtResult.Rows[i1]["SORTCODE_INT"].ToString().Trim()!="")
							objResult[i1].m_intSORTCODE_INT=int.Parse(dtResult.Rows[i1]["SORTCODE_INT"].ToString().Trim());
						if(dtResult.Rows[i1]["GOVTOPCHARGE_MNY"].ToString().Trim()!="")
						{
							objResult[i1].m_decGOVTOPCHARGE_MNY=decimal.Parse(dtResult.Rows[i1]["GOVTOPCHARGE_MNY"].ToString().Trim());
						}
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		//项目用法(用法中包括了什么项目)
		#region 新增一项目的用法
		/// <summary>
		/// 新增一项目的用法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewChargeItemUsageGroup(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItemUsageGroup_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoAddNewChargeItemUsageGroup");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string p_strID = "";
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			lngRes=objHRPSvc.lngGenerateID(4,"rowno_chr","T_BSE_CHARGEITEMUSAGEGROUP",out p_strID);
			objResult.m_strRowNo= "0000";
			if(lngRes<0)
				return -1;
			string strSQL="Insert Into t_bse_chargeitemusagegroup " +
				" (rowno_chr,usageid_chr,itemid_chr,QTY_DEC) " +
				" Values ('"+p_strID+"'," +
				"'"+objResult.m_strUsageID+"','"+objResult.m_strItemID+"','"+objResult.m_strUNITPRICE+"')";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objSvc = new clsHRPTableService();
				lngRes = objSvc.DoExcute(strSQL);	
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		
		}
		#region 新增一项目的用法	加	2005-03-17
		/// <summary>
		/// 新增一项目的用法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strRecordID"></param>
		/// <param name="p_objRecord">流水号</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewChargeItemUsageGroup(System.Security.Principal.IPrincipal p_objPrincipal,out string p_strRecordID,clsChargeItemUsageGroup_VO p_objRecord)
		{
            com.digitalwave.Utility.clsLogText objLoggers = new clsLogText();
            objLoggers.LogError("m_lngDoAddNewChargeItemUsageGroup");

			long lngRes=0;
			p_strRecordID = "";
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewChargeItemUsageGroup");
			if(lngRes < 0)
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.lngGenerateID(4,"ROWNO_CHR","t_bse_chargeitemusagegroup",out p_strRecordID);
			if(lngRes < 0)
				return lngRes;
			string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO t_bse_chargeitemusagegroup (ROWNO_CHR,USAGEID_CHR,ITEMID_CHR,QTY_DEC,CLINICTYPE_INT,BIHQTY_DEC,BIHTYPE_INT,CONTINUEUSETYPE_INT,BIHEXECDEPTFLAG_INT,BIHEXECDEPTID_CHR) VALUES (?,?,?,?,?,?,?,?,?,?)";
			try
			{
				System.Data.IDataParameter[] objLisAddItemRefArr = null;
				objHRPSvc.CreateDatabaseParameter(10,out objLisAddItemRefArr);
				//Please change the datetime and reocrdid 
				objLisAddItemRefArr[0].Value = p_strRecordID;//p_objRecord.m_strROWNO_CHR;
				objLisAddItemRefArr[1].Value = p_objRecord.m_strUsageID;
				objLisAddItemRefArr[2].Value = p_objRecord.m_strItemID;
				objLisAddItemRefArr[3].Value = p_objRecord.m_strUNITPRICE;
				objLisAddItemRefArr[4].Value = p_objRecord.m_intCLINICTYPE_INT;
				objLisAddItemRefArr[5].Value = p_objRecord.m_dblBIHQTY_DEC;
				objLisAddItemRefArr[6].Value = p_objRecord.m_intBIHTYPE_INT;
				objLisAddItemRefArr[7].Value = p_objRecord.m_intCONTINUEUSETYPE_INT;
                objLisAddItemRefArr[8].Value = p_objRecord.m_intBihExecDeptflag;
                objLisAddItemRefArr[9].Value = p_objRecord.m_strBihExecDeptID;
				long lngRecEff = -1;
				//往表增加记录
				lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL,ref lngRecEff,objLisAddItemRefArr);
				objHRPSvc.Dispose();				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#endregion
	
		#region 修改项目的用法	修改	2005-03-17
		/// <summary>
		/// 修改项目的用法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoModifyChargeItemUsageGroup(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItemUsageGroup_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoModifyChargeItemUsageGroup");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
//			string strSubSql ="TRIM(usageid_chr)='" + objResult.m_strUsageID.Trim() + "' and";
//			if(objResult.m_intFlag==1&&objResult.m_strTOTALPRICE.Trim()!=objResult.m_strItemID.Trim())
//			{
//			strSubSql ="";
//			}
			if(lngRes<0)
				return -1;
            string strSQL = "UPDate t_bse_chargeitemusagegroup set "
                + "QTY_DEC=" + objResult.m_strUNITPRICE
                + ",CLINICTYPE_INT=" + objResult.m_intCLINICTYPE_INT.ToString()
                + ",BIHQTY_DEC=" + objResult.m_dblBIHQTY_DEC.ToString()
                + ",BIHTYPE_INT=" + objResult.m_intBIHTYPE_INT.ToString()
                + ",itemid_chr='" + objResult.m_strItemID
                + "',CONTINUEUSETYPE_INT=" + objResult.m_intCONTINUEUSETYPE_INT.ToString()
                + ",BIHEXECDEPTFLAG_INT=" + objResult.m_intBihExecDeptflag.ToString()
                + ",BIHEXECDEPTID_CHR='" + objResult.m_strBihExecDeptID.ToString()
				+ "' Where TRIM(usageid_chr)='" + objResult.m_strUsageID.Trim() + "' and TRIM(itemid_chr)='"+objResult.m_strTOTALPRICE.Trim()+"' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objSvc = new clsHRPTableService();
				lngRes = objSvc.DoExcute(strSQL);
				if(lngRes>0)
				{
					if(objResult.m_intFlag==1)
					{
						strSQL="UPDate t_bse_chargeitemusagegroup set " 
							+ "itemid_chr='"+objResult.m_strItemID
							+ "'  Where TRIM(usageid_chr) <>'" + objResult.m_strUsageID.Trim() + "' and TRIM(itemid_chr)='"+objResult.m_strTOTALPRICE.Trim()+"' ";
						lngRes = objSvc.DoExcute(strSQL);
					}
				}
				objSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		
		}
		#endregion

		#region 删除用法组中的项目
		/// <summary>
		/// 删除用法组中的项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelUsageGroupByID(System.Security.Principal.IPrincipal p_objPrincipal,clsChargeItemUsageGroup_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDelUsageGroupByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="";
			if(objResult.m_strItemID==null || objResult.m_strItemID=="")
			{
				strSQL="Delete t_bse_chargeitemusagegroup " +
					" Where usageid_chr='"+objResult.m_strUsageID+"' ";
			}
			else
			{
				strSQL="Delete t_bse_chargeitemusagegroup " +
					" Where usageid_chr='"+objResult.m_strUsageID+"' And " +
					" itemid_chr='"+objResult.m_strItemID+"' " ;
				if(objResult.m_intFlag==1)
				{
					strSQL="Delete t_bse_chargeitemusagegroup " +
						" Where itemid_chr='"+objResult.m_strItemID+"'";
				}
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		
		}
		#endregion

        #region 删除整剂用法组中的项目
        /// <summary>
        ///删除整剂用法组中的项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDelCMUsageGroupByID(System.Security.Principal.IPrincipal p_objPrincipal, clsChargeItemUsageGroup_VO objResult)
        {
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_lngDelCMUsageGroupByID");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "";
            if (objResult.m_strItemID == null || objResult.m_strItemID == "")
            {
                strSQL = "Delete t_aid_cmcookingmethoditemgroup " +
                    " Where usageid_chr='" + objResult.m_strUsageID + "' ";
            }
            else
            {
                strSQL = "Delete t_aid_cmcookingmethoditemgroup " +
                    " Where usageid_chr='" + objResult.m_strUsageID + "' And " +
                    " itemid_chr='" + objResult.m_strItemID + "' ";
                if (objResult.m_intFlag == 1)
                {
                    strSQL = "Delete t_aid_cmcookingmethoditemgroup " +
                        " Where itemid_chr='" + objResult.m_strItemID + "'";
                }
            }
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoExcute(strSQL);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion

        #region 获取执行医嘱分类名称
        /// <summary>
        /// 获取执行医嘱分类名称
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="tb"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllBihCate(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable tb)
        {
            long lngRes = 0;
            tb = new DataTable();
            //权限控制
            com.digitalwave.security.clsPrivilegeHandleService objHandle = new clsPrivilegeHandleService();
            lngRes = objHandle.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsMedicineSvc", "m_lngGetAllBihCate");
            if (lngRes < 0)
                return -1;
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            string strSQL = @"select * from t_aid_bih_orderperformcate  order by SORT_INT";
            try
            {

                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref tb);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }

            return lngRes;
        }

        #endregion

		#region 查询用法对应的项目
		[AutoComplete]
		public long m_GetItemByUsageID(System.Security.Principal.IPrincipal p_objPrincipal,	string strUsageID, out clsChargeItem_VO[] objResult)
		{
			DataTable dtbResult = new DataTable();
			long lngRes = 0;
			objResult=new clsChargeItem_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = @"SELECT a.*,decode (b.opchargeflg_int,
               0, b.itemprice_mny,
               1, round (b.itemprice_mny / b.packqty_dec, 4)
              ) as itemprice_mny, b.*, c.noqtyflag_int,d.USAGEID_CHR as USAGEID_CHR1,d.USAGENAME_VCHR as USAGENAME_VCHR1,e.USAGENAME_VCHR,f.deptname_vchr
  FROM t_bse_chargeitemusagegroup a, t_bse_chargeitem b, t_bse_medicine c,t_bse_usagetype d,t_bse_usagetype e,t_bse_deptdesc f
 WHERE a.usageid_chr = '" + strUsageID+ @"'
   and a.bihexecdeptid_chr=f.deptid_chr(+)
   AND a.itemid_chr = b.itemid_chr
   and a.USAGEID_CHR=e.USAGEID_CHR(+)
	and b.USAGEID_CHR=d.USAGEID_CHR(+)
   AND b.itemsrcid_vchr = c.medicineid_chr(+)";
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
				objHRPSvc.Dispose();
			if(lngRes>0 && dtbResult.Rows.Count>0)
			{
				objResult = new clsChargeItem_VO[dtbResult.Rows.Count];
				for(int i1=0;i1<objResult.Length;i1++)
				{
					objResult[i1] = new clsChargeItem_VO();
					//					if(dtbResult.Columns.IndexOf("ROWNO_CHR")>0)
					//						objResult[i1].m_strRowNo = dtbResult.Rows[i1]["ROWNO_CHR"].ToString().Trim(); 
					//					else
					//						objResult[i1].m_strRowNo=null;
					objResult[i1].m_intIFSTOP_INT= int.Parse(dtbResult.Rows[i1]["IFSTOP_INT"].ToString());
					//
					if(dtbResult.Rows[i1]["NOQTYFLAG_INT"]!=System.DBNull.Value)
						objResult[i1].m_intStopFlag=int.Parse(dtbResult.Rows[i1]["NOQTYFLAG_INT"].ToString());
					else
						objResult[i1].m_intStopFlag=0;
					objResult[i1].m_strItemID = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
					objResult[i1].m_strItemName = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
					objResult[i1].m_strItemCode = dtbResult.Rows[i1]["ITEMCODE_VCHR"].ToString().Trim();
					objResult[i1].m_strItemPYCode = dtbResult.Rows[i1]["ITEMPYCODE_CHR"].ToString().Trim();
					objResult[i1].m_strItemWBCode = dtbResult.Rows[i1]["ITEMWBCODE_CHR"].ToString().Trim();
					objResult[i1].m_strItemSrcID = dtbResult.Rows[i1]["ITEMSRCID_VCHR"].ToString().Trim();
					if(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim()!="")
						objResult[i1].m_intItemSrcType = Convert.ToInt32(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim());
					objResult[i1].m_strItemSpec = dtbResult.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
					if(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim()!="")
						objResult[i1].m_fltItemPrice = Convert.ToSingle(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
					objResult[i1].m_ItemUnit=new clsUnit_VO();
					objResult[i1].m_ItemUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMUNIT_CHR"].ToString().Trim();
					if (dtbResult.Columns.IndexOf("unitname_chr")>0)
						objResult[i1].m_ItemUnit.m_strUnitName = dtbResult.Rows[i1]["unitname_chr"].ToString().Trim();
					objResult[i1].m_ItemOPUnit=new clsUnit_VO();
					objResult[i1].m_ItemOPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
					//objResult[i1].m_ItemOPUnit.m_strUnitName = dtbResult.Rows[i1]["OPUnit"].ToString().Trim();
					objResult[i1].m_ItemIPUnit=new clsUnit_VO();
					objResult[i1].m_ItemIPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMIPUNIT_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemIPUnit.m_strUnitName = dtbResult.Rows[i1]["IPUnit"].ToString().Trim();
					objResult[i1].m_ItemOPCalcType=new clsChargeItemEXType_VO();
					objResult[i1].m_ItemOPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemOPCalcType.m_strTypeName = dtbResult.Rows[i1]["OPCal"].ToString().Trim();
					objResult[i1].m_ItemIPCalcType=new clsChargeItemEXType_VO();
					objResult[i1].m_ItemIPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMIPCALCTYPE_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemIPCalcType.m_strTypeName = dtbResult.Rows[i1]["IPCal"].ToString().Trim();
					objResult[i1].m_ItemOPInvType=new clsChargeItemEXType_VO();
					objResult[i1].m_ItemOPInvType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPINVTYPE_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemOPInvType.m_strTypeName = dtbResult.Rows[i1]["OPInv"].ToString().Trim();
					objResult[i1].m_ItemIPInvType=new clsChargeItemEXType_VO();
					objResult[i1].m_ItemIPInvType.m_strTypeID = dtbResult.Rows[i1]["ROWNO_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemIPInvType.m_strTypeName = dtbResult.Rows[i1]["IPInv"].ToString().Trim();
					if(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim()!="")
						objResult[i1].m_strDosage = Convert.ToSingle(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim());
					objResult[i1].m_DosageUnit=new clsUnit_VO();//用量单位
					objResult[i1].m_DosageUnit.m_strUnitID = dtbResult.Rows[i1]["DOSAGEUNIT_CHR"].ToString().Trim();
					//						objResult[i1].m_DosageUnit.m_strUnitName = dtbResult.Rows[i1]["DosageUnit"].ToString().Trim();
					if(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim()!="")
						objResult[i1].m_intIsGroupItem = Convert.ToInt32(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim());
					objResult[i1].m_ItemCat=new clsCharegeItemCat_VO();
					objResult[i1].m_ItemCat.m_strItemCatID = dtbResult.Rows[i1]["ITEMCATID_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemCat.m_strItemCatName = dtbResult.Rows[i1]["itemcatname_vchr"].ToString().Trim();
					objResult[i1].m_Usage=new clsUsageType_VO();
					if(dtbResult.Rows[i1]["USAGENAME_VCHR"].ToString().Trim()!="")
					{
						objResult[i1].m_Usage.m_strUsageID=dtbResult.Rows[i1]["USAGEID_CHR"].ToString().Trim();
						objResult[i1].m_Usage.m_strUsageName=dtbResult.Rows[i1]["USAGENAME_VCHR"].ToString().Trim();
					}
					else
					{
						objResult[i1].m_Usage.m_strUsageID=dtbResult.Rows[i1]["USAGEID_CHR1"].ToString().Trim();
						objResult[i1].m_Usage.m_strUsageName=dtbResult.Rows[i1]["USAGENAME_VCHR1"].ToString().Trim();
					}
					//						objResult[i1].m_Usage.m_strUsageName=dtbResult.Rows[i1]["usagename_vchr"].ToString().Trim();
					objResult[i1].m_strITEMOPCODE_CHR=dtbResult.Rows[i1]["ITEMOPCODE_CHR"].ToString();
					objResult[i1].m_strINSURANCEID_CHR=dtbResult.Rows[i1]["INSURANCEID_CHR"].ToString();
					if(dtbResult.Rows[i1]["qty_dec"] != Convert.DBNull )
					{
						objResult[i1].m_strUNITPRICE=dtbResult.Rows[i1]["qty_dec"].ToString();
						try
						{
							float sumprice =objResult[i1].m_fltItemPrice*float.Parse(objResult[i1].m_strUNITPRICE);
							objResult[i1].m_strTOTALPRICE =sumprice.ToString();
						}
						catch
						{
						
						}
					}
					if(dtbResult.Rows[i1]["PACKQTY_DEC"] != Convert.DBNull )
					{
						objResult[i1].m_decPACKQTY_DEC =Decimal.Parse(dtbResult.Rows[i1]["PACKQTY_DEC"].ToString());
					}
					try
					{
						objResult[i1].m_intCLINICTYPE_INT=Int32.Parse(dtbResult.Rows[i1]["CLINICTYPE_INT"].ToString());
					}
					catch{}
					try
					{
						objResult[i1].m_dblBIHQTY_DEC=double.Parse(dtbResult.Rows[i1]["BIHQTY_DEC"].ToString());
					}
					catch{}
					try
					{
						objResult[i1].m_intBIHTYPE_INT=Int32.Parse(dtbResult.Rows[i1]["BIHTYPE_INT"].ToString());
					}
					catch{}
					try
					{
						objResult[i1].m_intOPCHARGEFLG_INT =Int32.Parse(dtbResult.Rows[i1]["OPCHARGEFLG_INT"].ToString());
					}
					catch{}
					try
					{
						objResult[i1].m_intIPCHARGEFLG_INT =Int32.Parse(dtbResult.Rows[i1]["IPCHARGEFLG_INT"].ToString());
					}
					catch{}
					if(dtbResult.Rows[i1]["IPCHARGEFLG_INT"]!=System.DBNull.Value)
					{
						try
						{
							objResult[i1].m_intCONTINUEUSETYPE_INT =Int32.Parse(dtbResult.Rows[i1]["CONTINUEUSETYPE_INT"].ToString());
						}
						catch{}
					}

                    objResult[i1].m_intBihExecDeptflag = (dtbResult.Rows[i1]["BIHEXECDEPTFLAG_INT"] == DBNull.Value ? 1 : Convert.ToInt32(dtbResult.Rows[i1]["BIHEXECDEPTFLAG_INT"]));
                    objResult[i1].m_strBihExecDeptID = dtbResult.Rows[i1]["BIHEXECDEPTID_CHR"].ToString();
                    objResult[i1].m_strBihExecDeptName = dtbResult.Rows[i1]["DEPTNAME_VCHR"].ToString();
//						objResult[i1].m_strTOTALPRICE=dtbResult.Rows[i1]["TOTALPRICE_DEC"].ToString();
					
				}
			}
			return lngRes;
		}
		#endregion
        #region 查询整剂用法对应的项目
        [AutoComplete]
        public long m_lngGetItemByCMUsageID(System.Security.Principal.IPrincipal p_objPrincipal, string strUsageID, out clsChargeItem_VO[] objResult)
        {
            DataTable dtbResult = new DataTable();
            long lngRes = 0;
            objResult = new clsChargeItem_VO[0];
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_GetGroupCat");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = @"SELECT a.*,decode (b.opchargeflg_int,
               0, b.itemprice_mny,
               1, round (b.itemprice_mny / b.packqty_dec, 4)
              ) as itemprice_mny, b.*, c.noqtyflag_int,d.USAGEID_CHR as USAGEID_CHR1,d.USAGENAME_VCHR as USAGENAME_VCHR1,e.USAGENAME_VCHR
  FROM t_aid_cmcookingmethoditemgroup a, t_bse_chargeitem b, t_bse_medicine c,t_bse_usagetype d,t_bse_usagetype e
 WHERE a.usageid_chr = '" + strUsageID + @"'
   AND a.itemid_chr = b.itemid_chr
   and a.USAGEID_CHR=e.USAGEID_CHR(+)
	and b.USAGEID_CHR=d.USAGEID_CHR(+)
   AND b.itemsrcid_vchr = c.medicineid_chr(+)";
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtbResult);
            objHRPSvc.Dispose();
            if (lngRes > 0 && dtbResult.Rows.Count > 0)
            {
                objResult = new clsChargeItem_VO[dtbResult.Rows.Count];
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {
                    objResult[i1] = new clsChargeItem_VO();
                    //					if(dtbResult.Columns.IndexOf("ROWNO_CHR")>0)
                    //						objResult[i1].m_strRowNo = dtbResult.Rows[i1]["ROWNO_CHR"].ToString().Trim(); 
                    //					else
                    //						objResult[i1].m_strRowNo=null;
                    objResult[i1].m_intIFSTOP_INT = int.Parse(dtbResult.Rows[i1]["IFSTOP_INT"].ToString());
                    //
                    if (dtbResult.Rows[i1]["NOQTYFLAG_INT"] != System.DBNull.Value)
                        objResult[i1].m_intStopFlag = int.Parse(dtbResult.Rows[i1]["NOQTYFLAG_INT"].ToString());
                    else
                        objResult[i1].m_intStopFlag = 0;
                    objResult[i1].m_strItemID = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
                    objResult[i1].m_strItemName = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
                    objResult[i1].m_strItemCode = dtbResult.Rows[i1]["ITEMCODE_VCHR"].ToString().Trim();
                    objResult[i1].m_strItemPYCode = dtbResult.Rows[i1]["ITEMPYCODE_CHR"].ToString().Trim();
                    objResult[i1].m_strItemWBCode = dtbResult.Rows[i1]["ITEMWBCODE_CHR"].ToString().Trim();
                    objResult[i1].m_strItemSrcID = dtbResult.Rows[i1]["ITEMSRCID_VCHR"].ToString().Trim();
                    if (dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim() != "")
                        objResult[i1].m_intItemSrcType = Convert.ToInt32(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim());
                    objResult[i1].m_strItemSpec = dtbResult.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
                    if (dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim() != "")
                        objResult[i1].m_fltItemPrice = Convert.ToSingle(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
                    objResult[i1].m_ItemUnit = new clsUnit_VO();
                    objResult[i1].m_ItemUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMUNIT_CHR"].ToString().Trim();
                    if (dtbResult.Columns.IndexOf("unitname_chr") > 0)
                        objResult[i1].m_ItemUnit.m_strUnitName = dtbResult.Rows[i1]["unitname_chr"].ToString().Trim();
                    objResult[i1].m_ItemOPUnit = new clsUnit_VO();
                    objResult[i1].m_ItemOPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
                    //objResult[i1].m_ItemOPUnit.m_strUnitName = dtbResult.Rows[i1]["OPUnit"].ToString().Trim();
                    objResult[i1].m_ItemIPUnit = new clsUnit_VO();
                    objResult[i1].m_ItemIPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMIPUNIT_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemIPUnit.m_strUnitName = dtbResult.Rows[i1]["IPUnit"].ToString().Trim();
                    objResult[i1].m_ItemOPCalcType = new clsChargeItemEXType_VO();
                    objResult[i1].m_ItemOPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemOPCalcType.m_strTypeName = dtbResult.Rows[i1]["OPCal"].ToString().Trim();
                    objResult[i1].m_ItemIPCalcType = new clsChargeItemEXType_VO();
                    objResult[i1].m_ItemIPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMIPCALCTYPE_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemIPCalcType.m_strTypeName = dtbResult.Rows[i1]["IPCal"].ToString().Trim();
                    objResult[i1].m_ItemOPInvType = new clsChargeItemEXType_VO();
                    objResult[i1].m_ItemOPInvType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemOPInvType.m_strTypeName = dtbResult.Rows[i1]["OPInv"].ToString().Trim();
                    objResult[i1].m_ItemIPInvType = new clsChargeItemEXType_VO();
                    objResult[i1].m_ItemIPInvType.m_strTypeID = dtbResult.Rows[i1]["ROWNO_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemIPInvType.m_strTypeName = dtbResult.Rows[i1]["IPInv"].ToString().Trim();
                    if (dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim() != "")
                        objResult[i1].m_strDosage = Convert.ToSingle(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim());
                    objResult[i1].m_DosageUnit = new clsUnit_VO();//用量单位
                    objResult[i1].m_DosageUnit.m_strUnitID = dtbResult.Rows[i1]["DOSAGEUNIT_CHR"].ToString().Trim();
                    //						objResult[i1].m_DosageUnit.m_strUnitName = dtbResult.Rows[i1]["DosageUnit"].ToString().Trim();
                    if (dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim() != "")
                        objResult[i1].m_intIsGroupItem = Convert.ToInt32(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim());
                    objResult[i1].m_ItemCat = new clsCharegeItemCat_VO();
                    objResult[i1].m_ItemCat.m_strItemCatID = dtbResult.Rows[i1]["ITEMCATID_CHR"].ToString().Trim();
                    //						objResult[i1].m_ItemCat.m_strItemCatName = dtbResult.Rows[i1]["itemcatname_vchr"].ToString().Trim();
                    objResult[i1].m_Usage = new clsUsageType_VO();
                    if (dtbResult.Rows[i1]["USAGENAME_VCHR"].ToString().Trim() != "")
                    {
                        objResult[i1].m_Usage.m_strUsageID = dtbResult.Rows[i1]["USAGEID_CHR"].ToString().Trim();
                        objResult[i1].m_Usage.m_strUsageName = dtbResult.Rows[i1]["USAGENAME_VCHR"].ToString().Trim();
                    }
                    else
                    {
                        objResult[i1].m_Usage.m_strUsageID = dtbResult.Rows[i1]["USAGEID_CHR1"].ToString().Trim();
                        objResult[i1].m_Usage.m_strUsageName = dtbResult.Rows[i1]["USAGENAME_VCHR1"].ToString().Trim();
                    }
                    //						objResult[i1].m_Usage.m_strUsageName=dtbResult.Rows[i1]["usagename_vchr"].ToString().Trim();
                    objResult[i1].m_strITEMOPCODE_CHR = dtbResult.Rows[i1]["ITEMOPCODE_CHR"].ToString();
                    objResult[i1].m_strINSURANCEID_CHR = dtbResult.Rows[i1]["INSURANCEID_CHR"].ToString();
                    if (dtbResult.Rows[i1]["qty_dec"] != Convert.DBNull)
                    {
                        objResult[i1].m_strUNITPRICE = dtbResult.Rows[i1]["qty_dec"].ToString();
                        try
                        {
                            float sumprice = objResult[i1].m_fltItemPrice * float.Parse(objResult[i1].m_strUNITPRICE);
                            objResult[i1].m_strTOTALPRICE = sumprice.ToString();
                        }
                        catch
                        {

                        }
                    }
                    if (dtbResult.Rows[i1]["PACKQTY_DEC"] != Convert.DBNull)
                    {
                        objResult[i1].m_decPACKQTY_DEC = Decimal.Parse(dtbResult.Rows[i1]["PACKQTY_DEC"].ToString());
                    }
                    try
                    {
                        objResult[i1].m_intCLINICTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["CLINICTYPE_INT"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_dblBIHQTY_DEC = double.Parse(dtbResult.Rows[i1]["BIHQTY_DEC"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_intBIHTYPE_INT = Int32.Parse(dtbResult.Rows[i1]["BIHTYPE_INT"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_intOPCHARGEFLG_INT = Int32.Parse(dtbResult.Rows[i1]["OPCHARGEFLG_INT"].ToString());
                    }
                    catch { }
                    try
                    {
                        objResult[i1].m_intIPCHARGEFLG_INT = Int32.Parse(dtbResult.Rows[i1]["IPCHARGEFLG_INT"].ToString());
                    }
                    catch { }
                    if (dtbResult.Rows[i1]["IPCHARGEFLG_INT"] != System.DBNull.Value)
                    {
                        try
                        {
                            objResult[i1].m_intCONTINUEUSETYPE_INT = Int32.Parse(dtbResult.Rows[i1]["CONTINUEUSETYPE_INT"].ToString());
                        }
                        catch { }
                    }
                    //						objResult[i1].m_strTOTALPRICE=dtbResult.Rows[i1]["TOTALPRICE_DEC"].ToString();

                }
            }
            return lngRes;
        }
        #endregion
		#region 查询用法ID和收费ID对应的项目		2005-03-19
		/// <summary>
		/// 查询用法ID和收费ID对应的项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strITEMID_CHR">收费项目ID</param>
		/// <param name="strUSAGEID_CHR">用法ID</param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_GetItemByUsageIDAndItemID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strITEMID_CHR,string p_strUSAGEID_CHR,out clsChargeItem_VO[] objResult)
		{
			DataTable dtbResult = new DataTable();
			long lngRes = 0;
			objResult=new clsChargeItem_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetItemByUsageIDAndItemID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			string strSQL="select a.*,b.* from t_bse_chargeitemusagegroup a,t_bse_chargeitem b " +
				" where Trim(a.usageid_chr)='"+p_strUSAGEID_CHR+"' and Trim(a.itemid_chr)=Trim(b.itemid_chr) And Trim(b.itemid_chr)='" + p_strITEMID_CHR.Trim() + "'";
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
			objHRPSvc.Dispose();
			if(lngRes>0 && dtbResult.Rows.Count>0)
			{
				objResult = new clsChargeItem_VO[dtbResult.Rows.Count];
				for(int i1=0;i1<objResult.Length;i1++)
				{
					objResult[i1] = new clsChargeItem_VO();
					//					if(dtbResult.Columns.IndexOf("ROWNO_CHR")>0)
					//						objResult[i1].m_strRowNo = dtbResult.Rows[i1]["ROWNO_CHR"].ToString().Trim(); 
					//					else
					//						objResult[i1].m_strRowNo=null;
					objResult[i1].m_strItemID = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
					objResult[i1].m_strItemName = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
					objResult[i1].m_strItemCode = dtbResult.Rows[i1]["ITEMCODE_VCHR"].ToString().Trim();
					objResult[i1].m_strItemPYCode = dtbResult.Rows[i1]["ITEMPYCODE_CHR"].ToString().Trim();
					objResult[i1].m_strItemWBCode = dtbResult.Rows[i1]["ITEMWBCODE_CHR"].ToString().Trim();
					objResult[i1].m_strItemSrcID = dtbResult.Rows[i1]["ITEMSRCID_VCHR"].ToString().Trim();
					if(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim()!="")
						objResult[i1].m_intItemSrcType = Convert.ToInt32(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim());
					objResult[i1].m_strItemSpec = dtbResult.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
					if(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim()!="")
						objResult[i1].m_fltItemPrice = Convert.ToSingle(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
					objResult[i1].m_ItemUnit=new clsUnit_VO();
					objResult[i1].m_ItemUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMUNIT_CHR"].ToString().Trim();
					if (dtbResult.Columns.IndexOf("unitname_chr")>0)
						objResult[i1].m_ItemUnit.m_strUnitName = dtbResult.Rows[i1]["unitname_chr"].ToString().Trim();
					objResult[i1].m_ItemOPUnit=new clsUnit_VO();
					objResult[i1].m_ItemOPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
					//objResult[i1].m_ItemOPUnit.m_strUnitName = dtbResult.Rows[i1]["OPUnit"].ToString().Trim();
					objResult[i1].m_ItemIPUnit=new clsUnit_VO();
					objResult[i1].m_ItemIPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMIPUNIT_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemIPUnit.m_strUnitName = dtbResult.Rows[i1]["IPUnit"].ToString().Trim();
					objResult[i1].m_ItemOPCalcType=new clsChargeItemEXType_VO();
					objResult[i1].m_ItemOPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemOPCalcType.m_strTypeName = dtbResult.Rows[i1]["OPCal"].ToString().Trim();
					objResult[i1].m_ItemIPCalcType=new clsChargeItemEXType_VO();
					objResult[i1].m_ItemIPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMIPCALCTYPE_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemIPCalcType.m_strTypeName = dtbResult.Rows[i1]["IPCal"].ToString().Trim();
					objResult[i1].m_ItemOPInvType=new clsChargeItemEXType_VO();
					objResult[i1].m_ItemOPInvType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPINVTYPE_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemOPInvType.m_strTypeName = dtbResult.Rows[i1]["OPInv"].ToString().Trim();
					objResult[i1].m_ItemIPInvType=new clsChargeItemEXType_VO();
					objResult[i1].m_ItemIPInvType.m_strTypeID = dtbResult.Rows[i1]["ROWNO_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemIPInvType.m_strTypeName = dtbResult.Rows[i1]["IPInv"].ToString().Trim();
					if(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim()!="")
						objResult[i1].m_strDosage = Convert.ToSingle(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim());
					objResult[i1].m_DosageUnit=new clsUnit_VO();//用量单位
					objResult[i1].m_DosageUnit.m_strUnitID = dtbResult.Rows[i1]["DOSAGEUNIT_CHR"].ToString().Trim();
					//						objResult[i1].m_DosageUnit.m_strUnitName = dtbResult.Rows[i1]["DosageUnit"].ToString().Trim();
					if(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim()!="")
						objResult[i1].m_intIsGroupItem = Convert.ToInt32(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim());
					objResult[i1].m_ItemCat=new clsCharegeItemCat_VO();
					objResult[i1].m_ItemCat.m_strItemCatID = dtbResult.Rows[i1]["ITEMCATID_CHR"].ToString().Trim();
					//						objResult[i1].m_ItemCat.m_strItemCatName = dtbResult.Rows[i1]["itemcatname_vchr"].ToString().Trim();
					objResult[i1].m_Usage=new clsUsageType_VO();
					objResult[i1].m_Usage.m_strUsageID=dtbResult.Rows[i1]["USAGEID_CHR"].ToString().Trim();
					//						objResult[i1].m_Usage.m_strUsageName=dtbResult.Rows[i1]["usagename_vchr"].ToString().Trim();
					objResult[i1].m_strITEMOPCODE_CHR=dtbResult.Rows[i1]["ITEMOPCODE_CHR"].ToString();
					objResult[i1].m_strINSURANCEID_CHR=dtbResult.Rows[i1]["INSURANCEID_CHR"].ToString();
					if(dtbResult.Rows[i1]["qty_dec"] != Convert.DBNull )
					{
						objResult[i1].m_strUNITPRICE=dtbResult.Rows[i1]["qty_dec"].ToString();
						try
						{
							float sumprice =objResult[i1].m_fltItemPrice*float.Parse(objResult[i1].m_strUNITPRICE);
							objResult[i1].m_strTOTALPRICE =sumprice.ToString();
						}
						catch
						{
						
						}
					}
					try
					{
						objResult[i1].m_intCLINICTYPE_INT=Int32.Parse(dtbResult.Rows[i1]["CLINICTYPE_INT"].ToString());
					}
					catch{}
					try
					{
						objResult[i1].m_dblBIHQTY_DEC=double.Parse(dtbResult.Rows[i1]["BIHQTY_DEC"].ToString());
					}
					catch{}
					try
					{
						objResult[i1].m_intBIHTYPE_INT=Int32.Parse(dtbResult.Rows[i1]["BIHTYPE_INT"].ToString());
					}
					catch{}					
					
					//						objResult[i1].m_strTOTALPRICE=dtbResult.Rows[i1]["TOTALPRICE_DEC"].ToString();
					
				}
			}
			return lngRes;
		}
	
		#endregion
		//用法
		#region 新增用法
		/// <summary>
		/// 新增用法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <param name="p_strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngAddNewUsage(System.Security.Principal.IPrincipal p_objPrincipal,
			clsUsageType_VO objResult,out string p_strID)
		{
			long lngRes = 0;
			p_strID="";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngAddNewUsage");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes=objHRPSvc.lngGenerateID(4,"usageid_chr","t_bse_usagetype",out p_strID);
			if(lngRes<0)
				return -1;
            string strSQL = @"Insert Into t_bse_usagetype (USAGEID_CHR,USAGENAME_VCHR,USERCODE_CHR,PYCODE_VCHR,WBCODE_VCHR, scope_int,PUTMED_INT,TEST_INT,OPUSAGEDESC) Values(?,?,?,?,?,?,?,?,?) ";
			try
			{


                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(9, out paramArr);
                paramArr[0].Value = p_strID;
                paramArr[1].Value = objResult.m_strUsageName;
                paramArr[2].Value = objResult.m_strUsageCode;
                paramArr[3].Value = objResult.m_strUsagePYCODE;
                paramArr[4].Value = objResult.m_strUsageWBCODE;
                paramArr[5].Value = objResult.m_intScope;
                paramArr[6].Value = objResult.m_intPutMed;
                paramArr[7].Value = objResult.m_intTest;
                paramArr[8].Value = objResult.m_strOPUsageDesc;
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 修改用法
		/// <summary>
		/// 修改用法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpUsage(System.Security.Principal.IPrincipal p_objPrincipal,clsUsageType_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoUpUsage");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = "UPDate t_bse_usagetype Set USAGENAME_VCHR=?,USERCODE_CHR=?,PYCODE_VCHR=?,WBCODE_VCHR=?,scope_int =?,PUTMED_INT=?,TEST_INT=?,OPUSAGEDESC=? Where USAGEID_CHR=? ";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] paramArr = null;
                objHRPSvc.CreateDatabaseParameter(9, out paramArr);
                paramArr[0].Value = objResult.m_strUsageName;
                paramArr[1].Value = objResult.m_strUsageCode;
                paramArr[2].Value = objResult.m_strUsagePYCODE;
                paramArr[3].Value = objResult.m_strUsageWBCODE;
                paramArr[4].Value = objResult.m_intScope;
                paramArr[5].Value = objResult.m_intPutMed;
                paramArr[6].Value = objResult.m_intTest;
                paramArr[7].Value = objResult.m_strOPUsageDesc;
                paramArr[8].Value = objResult.m_strUsageID;
                long lngRecordsAffected = -1;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecordsAffected, paramArr);
                objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 删除用法
		/// <summary>
		/// 删除用法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelUsage(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDelUsage");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			string strSQL="Delete t_bse_usagetype Where usageid_chr='"+strID+"' ";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();	
				lngRes = objHRPSvc.DoExcute(strSQL);	
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 查找用法
		/// <summary>
		/// 查找用法(strCode IS Null时查找所有用法）
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <param name="strCode"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_GetUsage(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsUsageType_VO[] objResult, string strCode)
		{
			long lngRes = 0;
			objResult=new clsUsageType_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetUsage");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
            string strSQL = @"Select usageid_chr,usagename_vchr,usercode_chr,PYCODE_VCHR,WBCODE_VCHR From t_bse_usagetype order by usercode_chr";
			if(strCode!=null)
                strSQL = @"Select usageid_chr,usagename_vchr,usercode_chr,PYCODE_VCHR,WBCODE_VCHR From t_bse_usagetype Where usercode_chr='" + strCode + "' order by usercode_chr";
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();	
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);
					objHRPSvc.Dispose();
				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					objResult=new clsUsageType_VO[dtResult.Rows.Count];
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1]=new clsUsageType_VO();
						objResult[i1].m_strUsageID=dtResult.Rows[i1][0].ToString().Trim();
						objResult[i1].m_strUsageName=dtResult.Rows[i1][1].ToString().Trim();
						objResult[i1].m_strUsageCode=dtResult.Rows[i1][2].ToString().Trim();
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
      
		//查询
		#region 根据项目分类ID取得最上级的组目录
		[AutoComplete]
		public long m_GetGroupCat(System.Security.Principal.IPrincipal p_objPrincipal,
			string strID,out clsChargeItem_VO[] objResult)
		{
			long lngRes = 0;
			objResult=new clsChargeItem_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			string strSQL="select * from t_bse_chargeitem  " +
				" Where itemcatid_chr='"+strID+"'  " +
				" and isgroupitem_int=1 " ;                  
			try
			{
				this.m_lngPartResult(strSQL,out objResult);
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		        
		#region 取回所有未分组的项目
		[AutoComplete]
		public long m_GetItemNoGroup(System.Security.Principal.IPrincipal p_objPrincipal,
			string strCatID, out clsChargeItem_VO[] objResult)
		{
			long lngRes = 0;
			objResult=new clsChargeItem_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			string strSQL="select t_bse_chargeitem.*,t_aid_unit.unitname_chr from t_bse_chargeitem ,t_aid_unit " +
				"where t_bse_chargeitem.itemcatid_chr='"+strCatID+"' and t_bse_chargeitem.isgroupitem_int=0 " + 
				" And t_bse_chargeitem.itemunit_chr=t_aid_unit.unitid_chr(+) and " +
				" not exists " +
				"(select detailitemid_chr from t_bse_chargeitemgroup " +
				" where t_bse_chargeitem.itemid_chr=t_bse_chargeitemgroup.detailitemid_chr) ";
			this.m_lngPartResult(strSQL,out objResult);
			return lngRes;
		}
		#endregion

		#region 获取病历项目配置所有数据
[AutoComplete]
		public long m_mthGetCASEHISCHR(System.Security.Principal.IPrincipal p_objPrincipal,
			string GroupID, out DataTable dt)
		{
			long lngRes = 0;
			dt =new DataTable();
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			string strSQL="Select * From T_OPR_OUTPATIENTCASEHISCHR";
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
			return lngRes;
		}
		#endregion
		#region 删除病历项目配置数据
		[AutoComplete]
		public long m_mthDeleteCASEHISCHR(System.Security.Principal.IPrincipal p_objPrincipal,
			string GroupID, string strCatID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			string strSQL=" delete from T_OPR_OUTPATIENTCASEHISCHR where SEQID_CHR ='"+GroupID+"' and TYPEID_CHR ='"+strCatID+"'";
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.DoExcute(strSQL);
			return lngRes;
		}
		#endregion
		#region 添加病历项目配置数据
		[AutoComplete]
		public long m_mthInsertCASEHISCHR(System.Security.Principal.IPrincipal p_objPrincipal,
			string GroupID, string strCatID,string strName)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			string strSQL=" insert into T_OPR_OUTPATIENTCASEHISCHR (SEQID_CHR,TYPEID_CHR,TYPENAME_VCHR) values('"+GroupID+"','"+strCatID+"','"+strName+"')";
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			lngRes = objHRPSvc.DoExcute(strSQL);
			return lngRes;
		}
		#endregion
		#region 根据项目编号取回项目列表
		[AutoComplete]
		public long m_GetItemByItemCode(System.Security.Principal.IPrincipal p_objPrincipal,
			string ItemCode, out clsChargeItem_VO[] objResult)
		{
			long lngRes = 0;
			objResult=new clsChargeItem_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			string strSQL="Select a.*,b.unitname_chr From t_bse_chargeitem a,t_Aid_unit b " +
				" Where a.itemCode_Vchr='"+ItemCode+"' " +
				" And a.itemunit_chr=b.unitid_chr(+)";
			this.m_lngPartResult(strSQL,out objResult);
			return lngRes;
		}
		#endregion

		#region 取回用法表中没有的项目
		[AutoComplete]
		public long m_GetItemNoUsageGroup(System.Security.Principal.IPrincipal p_objPrincipal,
			string strCatID,string strUsageID, out DataTable dtbResult)
		{
			long lngRes = 0;
			dtbResult=new DataTable();
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			string strSQL="select t_bse_chargeitem.itemid_chr ID, " +
				"t_bse_chargeitem.itemname_vchr Name, " +
				"t_bse_chargeitem.itemcode_vchr Code, " +
				"t_bse_chargeitem.itemprice_mny Price from t_bse_chargeitem  " +
				" where t_bse_chargeitem.itemcatid_chr='"+strCatID+"' And " +
				" t_bse_chargeitem.isgroupitem_int=0 " +
				" and not exists( " +
				" select itemid_chr from t_bse_chargeitemusagegroup " +
				" where t_bse_chargeitemusagegroup.usageid_chr='"+strUsageID+"' and " +
				" t_bse_chargeitem.itemid_chr=t_bse_chargeitemusagegroup.itemid_chr )";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
			objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		//把结果填到VO中(部分)
		#region 把收费项目结果填到VO中
		[AutoComplete]
		private long m_lngPartResult(string strSQL,out clsChargeItem_VO[] objResult)
		{
			long lngRes=0;
			DataTable dtbResult=new DataTable();
			objResult = new clsChargeItem_VO[0];
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);
					objHRPSvc.Dispose();
				if(lngRes>0 && dtbResult.Rows.Count>0)
				{
					objResult = new clsChargeItem_VO[dtbResult.Rows.Count];
					for(int i1=0;i1<objResult.Length;i1++)
					{
						objResult[i1] = new clsChargeItem_VO();
						//						if(dtbResult.Columns.IndexOf("ROWNO_CHR")>0)
						//                           objResult[i1].m_strRowNo = dtbResult.Rows[i1]["ROWNO_CHR"].ToString().Trim(); 
						//						else
						//							objResult[i1].m_strRowNo=null;
						objResult[i1].m_strItemID = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
						objResult[i1].m_strItemName = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
						objResult[i1].m_strItemCode = dtbResult.Rows[i1]["ITEMCODE_VCHR"].ToString().Trim();
						objResult[i1].m_strItemPYCode = dtbResult.Rows[i1]["ITEMPYCODE_CHR"].ToString().Trim();
						objResult[i1].m_strItemWBCode = dtbResult.Rows[i1]["ITEMWBCODE_CHR"].ToString().Trim();
						objResult[i1].m_strItemSrcID = dtbResult.Rows[i1]["ITEMSRCID_VCHR"].ToString().Trim();
						if(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim()!="")
							objResult[i1].m_intItemSrcType = Convert.ToInt32(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim());
						objResult[i1].m_strItemSpec = dtbResult.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
						if(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim()!="")
							objResult[i1].m_fltItemPrice = Convert.ToSingle(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
						objResult[i1].m_ItemUnit=new clsUnit_VO();
						objResult[i1].m_ItemUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMUNIT_CHR"].ToString().Trim();
						if (dtbResult.Columns.IndexOf("unitname_chr")>0)
							objResult[i1].m_ItemUnit.m_strUnitName = dtbResult.Rows[i1]["unitname_chr"].ToString().Trim();
						objResult[i1].m_ItemOPUnit=new clsUnit_VO();
						objResult[i1].m_ItemOPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
						//objResult[i1].m_ItemOPUnit.m_strUnitName = dtbResult.Rows[i1]["OPUnit"].ToString().Trim();
						objResult[i1].m_ItemIPUnit=new clsUnit_VO();
						objResult[i1].m_ItemIPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMIPUNIT_CHR"].ToString().Trim();
						//						objResult[i1].m_ItemIPUnit.m_strUnitName = dtbResult.Rows[i1]["IPUnit"].ToString().Trim();
						objResult[i1].m_ItemOPCalcType=new clsChargeItemEXType_VO();
						objResult[i1].m_ItemOPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
						//						objResult[i1].m_ItemOPCalcType.m_strTypeName = dtbResult.Rows[i1]["OPCal"].ToString().Trim();
						objResult[i1].m_ItemIPCalcType=new clsChargeItemEXType_VO();
						objResult[i1].m_ItemIPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMIPCALCTYPE_CHR"].ToString().Trim();
						//						objResult[i1].m_ItemIPCalcType.m_strTypeName = dtbResult.Rows[i1]["IPCal"].ToString().Trim();
						objResult[i1].m_ItemOPInvType=new clsChargeItemEXType_VO();
						objResult[i1].m_ItemOPInvType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPINVTYPE_CHR"].ToString().Trim();
						//						objResult[i1].m_ItemOPInvType.m_strTypeName = dtbResult.Rows[i1]["OPInv"].ToString().Trim();
						objResult[i1].m_ItemIPInvType=new clsChargeItemEXType_VO();
						objResult[i1].m_ItemIPInvType.m_strTypeID = dtbResult.Rows[i1]["ITEMIPINVTYPE_CHR"].ToString().Trim();
						//						objResult[i1].m_ItemIPInvType.m_strTypeName = dtbResult.Rows[i1]["IPInv"].ToString().Trim();
						if(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim()!="")
							objResult[i1].m_strDosage = Convert.ToSingle(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim());
						objResult[i1].m_DosageUnit=new clsUnit_VO();//用量单位
						objResult[i1].m_DosageUnit.m_strUnitID = dtbResult.Rows[i1]["DOSAGEUNIT_CHR"].ToString().Trim();
						//						objResult[i1].m_DosageUnit.m_strUnitName = dtbResult.Rows[i1]["DosageUnit"].ToString().Trim();
						if(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim()!="")
							objResult[i1].m_intIsGroupItem = Convert.ToInt32(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim());
						objResult[i1].m_ItemCat=new clsCharegeItemCat_VO();
						objResult[i1].m_ItemCat.m_strItemCatID = dtbResult.Rows[i1]["ITEMCATID_CHR"].ToString().Trim();
						//						objResult[i1].m_ItemCat.m_strItemCatName = dtbResult.Rows[i1]["itemcatname_vchr"].ToString().Trim();
						objResult[i1].m_Usage=new clsUsageType_VO();
						objResult[i1].m_Usage.m_strUsageID=dtbResult.Rows[i1]["USAGEID_CHR"].ToString().Trim();
						//						objResult[i1].m_Usage.m_strUsageName=dtbResult.Rows[i1]["usagename_vchr"].ToString().Trim();
						objResult[i1].m_strITEMOPCODE_CHR=dtbResult.Rows[i1]["ITEMOPCODE_CHR"].ToString();
						objResult[i1].m_strINSURANCEID_CHR=dtbResult.Rows[i1]["INSURANCEID_CHR"].ToString();
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 根据源ID取回源的名称
		[AutoComplete]
		public long m_lngFindSour(System.Security.Principal.IPrincipal p_objPrincipal,
			string strSourID,string SourType,out string strName)
		{
			string strSQL="";
			strName="";
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			switch (SourType)
			{
				case "1": //西药
					strSQL="Select medicinename_vchr From t_bse_medicine Where medicineid_chr='"+strSourID+"'";
					break;
			}
			try
			{
				DataTable dtResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();	
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);
				objHRPSvc.Dispose();
				if(lngRes>0 && dtResult.Rows.Count>0)
				{
					strName=dtResult.Rows[0][0].ToString().Trim();
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 根据源类型取回源的列表
		[AutoComplete]
		public long m_lngFindAllSour(System.Security.Principal.IPrincipal p_objPrincipal,
			string SourType,ref DataTable dtResult)
		{
			string strSQL="select ''ID,''Name From dual";
			dtResult=new DataTable();
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_GetGroupCat");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}			
			switch (SourType)
			{
				case "0": //西药
					strSQL="Select medicineid_chr ID,medicinename_vchr Name From t_bse_medicine ";
					break;
				case "1":
					strSQL="Select MATERIALID_CHR ID,MATERIALNAME_VCHR Name From t_bse_material ";
					break;
				case "2":
					strSQL="Select APPLY_UNIT_ID_CHR ID,APPLY_UNIT_NAME_VCHR Name From T_AID_LIS_APPLY_UNIT ";
					break;
				case "3":
					//					strSQL="Select ITEMID_CHR ID,ITEMNAME_VCHR Name From t_bse_chargeitem ";
					break;
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();	
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtResult);
			objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion


		// 收费项目用法表
		#region 返回所有收费项目用法列表 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 返回所有收费项目用法列表
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngFindUsageTypeList(System.Security.Principal.IPrincipal p_objPrincipal,
			out clsUsageType_VO[] objResult)
		{
			long lngRes = 0;
			objResult = new clsUsageType_VO[0];
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_lngFindUsageTypeList");
			if (lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "SELECT USAGEID_CHR, USAGECODE_CHR, USAGENAME_VCHR " + 
				"FROM T_BSE_USAGETYPE " +
				"ORDER BY USAGECODE_CHR";
			try
			{
				DataTable dtResult = new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dtResult);
					objHRPSvc.Dispose();
				if (lngRes > 0 && dtResult.Rows.Count > 0)
				{
					objResult = new clsUsageType_VO[dtResult.Rows.Count];
					for (int i1 = 0; i1 < objResult.Length; i1++)
					{
						objResult[i1] = new clsUsageType_VO();
						objResult[i1].m_strUsageID = dtResult.Rows[i1][0].ToString().Trim();
						objResult[i1].m_strUsageCode = dtResult.Rows[i1][1].ToString().Trim();
						objResult[i1].m_strUsageName = dtResult.Rows[i1][2].ToString().Trim();
					}
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 新增收费项目用法 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 新增收费项目用法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strCode"></param>
		/// <param name="p_strName"></param>
		/// <param name="p_strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoAddNewUsageType(System.Security.Principal.IPrincipal p_objPrincipal,string p_strCode,string p_strName, out string p_strID)
		{
			long lngRes = 0;
			p_strID = "";
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsUsageSvc","m_lngDoAddNewUsageType");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
			//返回一最大的计划号
			lngRes = objHRPSvc.lngGenerateID(4, "USAGEID_CHR", "T_BSE_USAGETYPE", out p_strID);
			if (lngRes < 0)
				return -1;
			string strSQL = "INSERT INTO T_BSE_USAGETYPE (USAGEID_CHR, USAGECODE_CHR, USAGENAME_VCHR) VALUES " +
				" ('" + p_strID + "' , '" + p_strCode + "', '" + p_strName + "')";
         
			try
			{
				lngRes = objHRPSvc.DoExcute(strSQL);
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 修改收费项目用法 created by Cameron Wong on Aug 12, 2004
		/// <summary>
		/// 修改收费项目用法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdUsageTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,clsUsageType_VO objResult)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoUpdUsageTypeByID");
			if( lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="UPDATE T_BSE_USAGETYPE SET  " +
				"USAGENAME_VCHR = '" + objResult.m_strUsageName + "', " +
				"USAGECODE_CHR = '" + objResult.m_strUsageCode + "' " +
				"WHERE USAGEID_CHR = '" + objResult.m_strUsageID + "' ";

			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);	
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 删除收费项目用法 created by Cameron Wong on Aug 11, 2004
		/// <summary>
		/// 删除收费项目用法
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelUsageTypeByID(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDelUsageTypeByID");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL = "DELETE T_BSE_USAGETYPE " +
				"WHERE USAGEID_CHR = '" + strID + " '";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 新增与删除单据
		/// <summary>
		///  新增与删除单据
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="objResult"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDoUpdUsageorderid_vchrByIDAndTypeId(System.Security.Principal.IPrincipal p_objPrincipal,int p_intTypeindex,string p_strUsageID,string p_strGroupID,bool p_blnAdd)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDoUpdUsageorderid_vchrByIDAndTypeId");
			if( lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="";
			if(p_blnAdd == true)
			{
				strSQL=@"insert into  t_opr_setusage(USAGEID_CHR,TYPE_INT,ORDERID_VCHR)	values('" + p_strUsageID + "',"+p_intTypeindex.ToString()+",'"+p_strGroupID+"')";
					
			}
			else 
			{
				strSQL=@"delete  t_opr_setusage  where USAGEID_CHR='" + p_strUsageID + "' and TYPE_INT="+p_intTypeindex.ToString()+" and ORDERID_VCHR='"+p_strGroupID+"'";

			}
			
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);	
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

		#region 根据传入的SQL语句查询出数据
		[AutoComplete]
		public long m_lngGetData(System.Security.Principal.IPrincipal p_objPrincipal,string SQLstr,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngGetData");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
		
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(SQLstr,ref dt);				
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}

        public long m_lngGetData(System.Security.Principal.IPrincipal p_objPrincipal, string p_StrTypeID, string p_Strorderid, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = -1;

            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_lngGetData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            string strSQL = @"select USAGEID_CHR from t_opr_setusage where TYPE_INT= ? and ORDERID_VCHR=?";
            try
            {
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] param = null;
                objHRPSvc.CreateDatabaseParameter(2, out param);
                param[0].Value = p_StrTypeID;
                param[1].Value = p_Strorderid;

                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, param);
                objHRPSvc.Dispose();

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
		#endregion

		#region 删除收费项目
		/// <summary>
		/// 删除收费项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strID"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngDelCharegeItem(System.Security.Principal.IPrincipal p_objPrincipal,string strID)
		{
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngDelCharegeItem");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
			string strSQL="Delete t_bse_chargeitem  " +
				" Where ITEMID_CHR='"+strID+"' " ;
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.DoExcute(strSQL);	
					objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		
		}
		#endregion

        /// <summary>
        /// 获取所有科室列表
        /// </summary>
        /// <param name="p_objResultArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngGetAllDepartment(out clsBSEUsageType[] p_objResultArr)
        {
            long lngRes = 0;
            p_objResultArr = null;
            string strSQL = string.Empty;
            try
            {
                strSQL = @"select a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr, a.wbcode_chr,
       a.usercode_vchr
  from t_bse_deptdesc a
 where a.status_int = 1 and a.attributeid ='0000002'";
                DataTable dtbResult = null;
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.DoGetDataTable(strSQL, ref dtbResult);
                if (lngRes > 0 && dtbResult != null)
                {
                    DataView dv = dtbResult.DefaultView;
                    dv.Sort = "code_vchr asc";
                    dtbResult = dv.ToTable();
                    p_objResultArr = new clsBSEUsageType[dtbResult.Rows.Count];
                    DataRow dr = null;
                    for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
                    {
                        dr = dtbResult.Rows[i1];
                        p_objResultArr[i1] = new clsBSEUsageType();
                        p_objResultArr[i1].m_strUsageID = dr["deptid_chr"].ToString();
                        p_objResultArr[i1].m_strUsageName = dr["deptname_vchr"].ToString();
                        p_objResultArr[i1].m_strUserCode = dr["code_vchr"].ToString();
                        p_objResultArr[i1].m_intPUTMED_INT = 0;
                        p_objResultArr[i1].m_intSCOPE_INT = 0;
                        p_objResultArr[i1].m_intTEST_INT = 0;
                        p_objResultArr[i1].m_strPYCODE_VCHR = dr["pycode_chr"].ToString();
                        p_objResultArr[i1].m_strWBCODE_VCHR = dr["wbcode_chr"].ToString();
                    }
                }
            }
            catch (Exception objEx)
            {
                clsLogText objLogger = new clsLogText();
                objLogger.LogError(objEx);
            }
            return lngRes;
        }

		#region 查询收费项目	
		/// <summary>
		/// 查询收费项目
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strCatID">分类ID</param>
		/// <param name="strType"></param>
		/// <param name="strContent"></param>
		/// <param name="dt"></param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthFindChargeItem(System.Security.Principal.IPrincipal p_objPrincipal,string strCatID,string strType,string strContent,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes = 0;
			//权限类
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			//检查是否有使用些函数的权限
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngGetData");
			if(lngRes < 0) //没有使用的权限
			{
				return -1;
			}
		
			try
			{
				//住院价格
				string strSQL="";
                strSQL = @"select A.*,Round(A.ITEMPRICE_MNY/A.PACKQTY_DEC,4) MinPrice, b.hype_int ,c.freqname_chr ,d1.typename_vchr,d2.typename_vchr as TYPENAME_VCHR1,d3.typename_vchr as typename_vchr2 ,d4.typename_vchr as typename_vchr3,d5.typename_vchr as typename_vchr4 ,e.name_chr,f.ordercatename_vchr from t_bse_chargeitem A,t_bse_medicine b ,t_aid_recipefreq c ,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=1) d1,
                               (select typename_vchr ,typeid_chr from t_bse_chargeitemextype where flag_int=3) d2,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=2) d3,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=4) d4,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=5) d5,
                               t_aid_bih_ordercate e,
                               t_aid_bih_orderperformcate f
                           WHERE a.itemsrcid_vchr = b.medicineid_chr(+) and  A.ITEMCATID_CHR ='" + strCatID + @"' and a.freqid_chr=c.freqid_chr(+) 
                           and a.itemopcalctype_chr=d1.typeid_chr(+)
                           and a.itemipcalctype_chr=d2.typeid_chr(+)
                           and a.itemopinvtype_chr=d3.typeid_chr(+)
                           and a.itemipinvtype_chr=d4.typeid_chr(+)
                           and a.itembihctype_chr=d5.typeid_chr(+) 
                           AND a.ordercateid_chr=f.ordercateid_chr(+)
                           and a.ordercateid1_chr=e.ordercateid_chr(+)
                           order by A.ITEMCODE_VCHR";
				if(strCatID=="")
				{
                    strSQL = @"select A.*,Round(A.ITEMPRICE_MNY/A.PACKQTY_DEC,4) MinPrice,c.freqname_chr ,d1.typename_vchr,d2.typename_vchr as TYPENAME_VCHR1,d3.typename_vchr as typename_vchr2 ,d4.typename_vchr as typename_vchr3,d5.typename_vchr as typename_vchr4 ,e.name_chr,f.ordercatename_vchr from t_bse_chargeitem A,t_bse_medicine b ,t_aid_recipefreq c,    (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=1) d1,
                               (select typename_vchr ,typeid_chr from t_bse_chargeitemextype where flag_int=3) d2,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=2) d3,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=4) d4,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=5) d5,
                               t_aid_bih_ordercate e,
                               t_aid_bih_orderperformcate f  where a.itemsrcid_vchr = b.medicineid_chr(+) and a.freqid_chr=c.freqid_chr(+)  and a.itemopcalctype_chr=d1.typeid_chr(+)
                             and a.itemipcalctype_chr=d2.typeid_chr(+)
                             and a.itemopinvtype_chr=d3.typeid_chr(+)
                             and a.itemipinvtype_chr=d4.typeid_chr(+)
                             and a.itembihctype_chr=d5.typeid_chr(+) 
                                AND a.ordercateid_chr=f.ordercateid_chr(+)
                             and a.ordercateid1_chr=e.ordercateid_chr(+)
                             order by a.ITEMCODE_VCHR";
				}
				if(strContent.Trim()!="")
				{
                    strSQL = @"select A.* , b.hype_int ,c.freqname_chr ,d1.typename_vchr,d2.typename_vchr as TYPENAME_VCHR1,d3.typename_vchr as typename_vchr2 ,d4.typename_vchr as typename_vchr3,d5.typename_vchr as typename_vchr4 ,e.name_chr,f.ordercatename_vchr from t_bse_chargeitem  A,t_bse_medicine b,t_aid_recipefreq c ,    (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=1) d1,
                               (select typename_vchr ,typeid_chr from t_bse_chargeitemextype where flag_int=3) d2,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=2) d3,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=4) d4,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=5) d5,
                               t_aid_bih_ordercate e,
                               t_aid_bih_orderperformcate f WHERE a.itemsrcid_vchr = b.medicineid_chr(+) and A.ITEMCATID_CHR ='" + strCatID + "' AND A." + strType + " LIKE '" + strContent + @"%' and a.freqid_chr=c.freqid_chr(+)   and a.itemopcalctype_chr=d1.typeid_chr(+)
                           and a.itemipcalctype_chr=d2.typeid_chr(+)
                           and a.itemopinvtype_chr=d3.typeid_chr(+)
                           and a.itemipinvtype_chr=d4.typeid_chr(+)
                           and a.itembihctype_chr=d5.typeid_chr(+) 
                           AND a.ordercateid_chr=f.ordercateid_chr(+)
                           and a.ordercateid1_chr=e.ordercateid_chr(+)
                           order by A.ITEMCODE_VCHR";
					if(strCatID=="")
					{
                        strSQL = @"select A.* , b.hype_int ,c.freqname_chr ,d1.typename_vchr,d2.typename_vchr as TYPENAME_VCHR1,d3.typename_vchr as typename_vchr2 ,d4.typename_vchr as typename_vchr3,d5.typename_vchr as typename_vchr4 ,e.name_chr,f.ordercatename_vchr from t_bse_chargeitem  A,t_bse_medicine b,t_aid_recipefreq c ,   (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=1) d1,
                               (select typename_vchr ,typeid_chr from t_bse_chargeitemextype where flag_int=3) d2,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=2) d3,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=4) d4,
                               (select typename_vchr,typeid_chr  from t_bse_chargeitemextype where flag_int=5) d5,
                               t_aid_bih_ordercate e,
                               t_aid_bih_orderperformcate f WHERE a.itemsrcid_vchr = b.medicineid_chr(+) and A." + strType + " LIKE '" + strContent + @"%'and a.freqid_chr=c.freqid_chr(+)    and a.itemopcalctype_chr=d1.typeid_chr(+)
                           and a.itemipcalctype_chr=d2.typeid_chr(+)
                           and a.itemopinvtype_chr=d3.typeid_chr(+)
                           and a.itemipinvtype_chr=d4.typeid_chr(+)
                           and a.itembihctype_chr=d5.typeid_chr(+) 
                           AND a.ordercateid_chr=f.ordercateid_chr(+)
                           and a.ordercateid1_chr=e.ordercateid_chr(+)
                           order by A.ITEMCODE_VCHR";
					}
				}
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);				
			objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
        }
        #region 获取医嘱类型 
        /// <summary>
        /// 获取医嘱类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objTable"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthSelectOrderCate(System.Security.Principal.IPrincipal p_objPrincipal, out DataTable m_objTable)
        {
            m_objTable = new DataTable();
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_mthSelectOrderCate");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            try
            {
                string strSQL = @"select A.ordercateid_chr,A.name_chr  from t_aid_bih_ordercate A order by A.name_chr";
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion 
        #region 新增整剂用法的项目
        /// <summary>
        /// 新增整剂用法的项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strRecordID"></param>
        /// <param name="p_objRecord">流水号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDoAddNewChargeItemCMUsageGroup(System.Security.Principal.IPrincipal p_objPrincipal, out string p_strRecordID, clsChargeItemUsageGroup_VO p_objRecord)
        {
            long lngRes = 0;
            p_strRecordID = "";
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc", "m_lngDoAddNewChargeItemCMUsageGroup");
            if (lngRes < 0)
            {
                return -1;
            }
            com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
            lngRes = objHRPSvc.lngGenerateID(4, "ROWNO_CHR", "t_aid_cmcookingmethoditemgroup", out p_strRecordID);
            if (lngRes < 0)
                return lngRes;
            string strDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string strSQL = "INSERT INTO t_aid_cmcookingmethoditemgroup (ROWNO_CHR,USAGEID_CHR,ITEMID_CHR,QTY_DEC,CLINICTYPE_INT,BIHQTY_DEC,BIHTYPE_INT,CONTINUEUSETYPE_INT) VALUES (?,?,?,?,?,?,?,?)";
            try
            {
                System.Data.IDataParameter[] objLisAddItemRefArr = null;
                objHRPSvc.CreateDatabaseParameter(8, out objLisAddItemRefArr);
                //Please change the datetime and reocrdid 
                objLisAddItemRefArr[0].Value = p_strRecordID;//p_objRecord.m_strROWNO_CHR;
                objLisAddItemRefArr[1].Value = p_objRecord.m_strUsageID;
                objLisAddItemRefArr[2].Value = p_objRecord.m_strItemID;
                objLisAddItemRefArr[3].Value = p_objRecord.m_strUNITPRICE;
                objLisAddItemRefArr[4].Value = p_objRecord.m_intCLINICTYPE_INT;
                objLisAddItemRefArr[5].Value = p_objRecord.m_dblBIHQTY_DEC;
                objLisAddItemRefArr[6].Value = p_objRecord.m_intBIHTYPE_INT;
                objLisAddItemRefArr[7].Value = p_objRecord.m_intCONTINUEUSETYPE_INT;
                long lngRecEff = -1;
                //往表增加记录
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRecEff, objLisAddItemRefArr);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 修改整剂用法带出的项目
        /// <summary>
        /// 修改整剂用法带出的项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objResult"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngDoModifyChargeItemCMUsageGroup(System.Security.Principal.IPrincipal p_objPrincipal, clsChargeItemUsageGroup_VO objResult)
        {
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_lngDoModifyChargeItemCMUsageGroup");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            if (lngRes < 0)
                return -1;
            string strSQL = "UPDate t_aid_cmcookingmethoditemgroup set "
                + "QTY_DEC=" + objResult.m_strUNITPRICE
                + ",CLINICTYPE_INT=" + objResult.m_intCLINICTYPE_INT.ToString()
                + ",BIHQTY_DEC=" + objResult.m_dblBIHQTY_DEC.ToString()
                + ",BIHTYPE_INT=" + objResult.m_intBIHTYPE_INT.ToString()
                + ",itemid_chr='" + objResult.m_strItemID
                + "',CONTINUEUSETYPE_INT=" + objResult.m_intCONTINUEUSETYPE_INT.ToString()
                + " Where TRIM(usageid_chr)='" + objResult.m_strUsageID.Trim() + "' and TRIM(itemid_chr)='" + objResult.m_strTOTALPRICE.Trim() + "' ";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objSvc = new clsHRPTableService();
                lngRes = objSvc.DoExcute(strSQL);
                if (lngRes > 0)
                {
                    if (objResult.m_intFlag == 1)
                    {
                        strSQL = "UPDate t_aid_cmcookingmethoditemgroup set "
                            + "itemid_chr='" + objResult.m_strItemID
                            + "'  Where TRIM(usageid_chr) <>'" + objResult.m_strUsageID.Trim() + "' and TRIM(itemid_chr)='" + objResult.m_strTOTALPRICE.Trim() + "' ";
                        lngRes = objSvc.DoExcute(strSQL);
                    }
                }
                objSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;

        }
        #endregion
        #region 查询收费项目1
        /// <summary>
        /// 查询收费项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="strCatID">分类ID</param>
        /// <param name="strType"></param>
        /// <param name="strContent"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindChargeItem1(System.Security.Principal.IPrincipal p_objPrincipal, string strCatID, string strType, string strContent, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_lngGetData");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }

            try
            {
                //住院价格
                string strSQL = "";
                strSQL = "select A.*,Round(A.ITEMPRICE_MNY/A.PACKQTY_DEC,4) MinPrice, b.hype_int from t_bse_chargeitem A,t_bse_medicine b WHERE a.itemsrcid_vchr = b.medicineid_chr(+) and  A.ITEMCATID_CHR ='" + strCatID + "' order by A.ITEMCODE_VCHR";
                if (strCatID == "")
                {
                    strSQL = "select A.*,Round(A.ITEMPRICE_MNY/A.PACKQTY_DEC,4) MinPrice,b.hype_int from t_bse_chargeitem A,t_bse_medicine b where a.itemsrcid_vchr = b.medicineid_chr(+) order by a.ITEMCODE_VCHR";
                }
                if (strContent.Trim() != "")
                {
                    strSQL = "select A.* ,Round(A.ITEMPRICE_MNY/A.PACKQTY_DEC,4) MinPrice, b.hype_int  from t_bse_chargeitem  A,t_bse_medicine b WHERE a.itemsrcid_vchr = b.medicineid_chr(+) and A.ITEMCATID_CHR ='" + strCatID + "' AND A." + strType + " LIKE '" + strContent + "%' order by A.ITEMCODE_VCHR";
                    if (strCatID == "")
                    {
                        strSQL = "select A.* ,Round(A.ITEMPRICE_MNY/A.PACKQTY_DEC,4) MinPrice, b.hype_int  from t_bse_chargeitem  A,t_bse_medicine b WHERE a.itemsrcid_vchr = b.medicineid_chr(+) and A." + strType + " LIKE '" + strContent + "%' order by A.ITEMCODE_VCHR";
                    }
                }
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                objHRPSvc.Dispose();
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
		/// <summary>
		/// 查询收费项目--根据字符串 [20041027加]
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strFind">查询字符串</param>
		/// <param name="dt">DataTable类型 [out参数]</param>
		/// <returns></returns>
		public long m_lngFindChargeItem(System.Security.Principal.IPrincipal p_objPrincipal,string p_strFind,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes = 0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngFindChargeItem");
			if(lngRes < 0) 
			{
				return -1;
			}

			string strSQL="select a.* ,Round(a.ITEMPRICE_MNY/a.PACKQTY_DEC,4) MinPrice"; //住院价格
			strSQL +="	   ,(SELECT typename_vchr FROM t_bse_chargeitemextype WHERE typeid_chr=a.itemopcalctype_chr and flag_int=1)ItemOpcalcTypeName";//--项目门诊核算类别
			strSQL +="     ,(SELECT typename_vchr FROM t_bse_chargeitemextype WHERE typeid_chr=a.itemipcalctype_chr and flag_int=3)ItemIpcalcTypeName";//--项目住院核算类别
			strSQL +="     ,(SELECT typename_vchr FROM t_bse_chargeitemextype WHERE typeid_chr=a.itemopinvtype_chr and flag_int=2)ItemOpinvTypeName";//--项目门诊发票类别
			strSQL +="     ,(SELECT typename_vchr FROM t_bse_chargeitemextype WHERE typeid_chr=a.itemipinvtype_chr and flag_int=4)ItemIpinvTypeName";//--项目住院发票类别
			strSQL +=" FROM t_bse_chargeitem a";
			strSQL +=" WHERE ";
			strSQL +="     LOWER(a.itemname_vchr) like '" + p_strFind.ToLower() + "%'";
			strSQL +="     or LOWER(a.itemcode_vchr) like '" + p_strFind.ToLower() + "%'";
			strSQL +="     or LOWER(a.itempycode_chr) like '" + p_strFind.ToLower() + "%'";
			strSQL +="     or LOWER(a.itemwbcode_chr) like '" + p_strFind.ToLower() + "%'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);				
				objHRPSvc.Dispose();
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		/// <summary>
		/// 查询收费项目--根据流水号 [20041027加]
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_strID">查询字符串</param>
		/// <param name="dt">DataTable类型 [out参数]</param>
		/// <returns></returns>
		public long m_lngFindChargeItemByID(System.Security.Principal.IPrincipal p_objPrincipal,string p_strID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes = 0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_lngFindChargeItemByID");
			if(lngRes < 0) 
			{
				return -1;
			}

			string strSQL="select a.* ,Round(a.ITEMPRICE_MNY/a.PACKQTY_DEC,4) MinPrice"; //住院价格
			strSQL +="	   ,(SELECT typename_vchr FROM t_bse_chargeitemextype WHERE typeid_chr=a.itemopcalctype_chr and flag_int=1)ItemOpcalcTypeName";//--项目门诊核算类别
			strSQL +="     ,(SELECT typename_vchr FROM t_bse_chargeitemextype WHERE typeid_chr=a.itemipcalctype_chr and flag_int=3)ItemIpcalcTypeName";//--项目住院核算类别
			strSQL +="     ,(SELECT typename_vchr FROM t_bse_chargeitemextype WHERE typeid_chr=a.itemopinvtype_chr and flag_int=2)ItemOpinvTypeName";//--项目门诊发票类别
			strSQL +="     ,(SELECT typename_vchr FROM t_bse_chargeitemextype WHERE typeid_chr=a.itemipinvtype_chr and flag_int=4)ItemIpinvTypeName";//--项目住院发票类别
			strSQL +=" FROM t_bse_chargeitem a";
			strSQL +=" WHERE ";
			strSQL +="     ITEMID_CHR='" + p_strID.Trim() + "'";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);				
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
		#region 获取申请单类型
		[AutoComplete]
		public long m_mthFindApplyType(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dt,string p_strEx)
		{
			dt=new DataTable();
			long lngRes = 0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc","m_mthFindApplyType");
			if(lngRes < 0) 
			{
				return -1;
			}

			string strSQL="select * from AR_APPLY_TYPELIST where DELETED =0";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);				
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
        #region 获取用药频率
        /// <summary>
        /// 获取用药频率
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strFindText"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindRecipeFreq(System.Security.Principal.IPrincipal p_objPrincipal,string m_strFindText, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_mthFindRecipeFreq");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select freqid_chr,usercode_chr,freqname_chr from T_AID_RECIPEFREQ where upper(USERCODE_CHR) like '" + m_strFindText + "%' or upper(FREQNAME_CHR) like '" + m_strFindText + "%' order by USERCODE_CHR";
            string strSQL1 = @"select freqid_chr,usercode_chr,freqname_chr from T_AID_RECIPEFREQ";
            try
            {   
                
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                if (m_strFindText.Trim() != string.Empty)
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
                }
                else
                {
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL1, ref dt);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 获取用药频率
        /// <summary>
        ///  获取用药频率
       /// </summary>
       /// <param name="p_objPrincipal"></param>
       /// <param name="dt"></param>
       /// <returns></returns>
        [AutoComplete]
        public long m_mthFindRecipeFreq(System.Security.Principal.IPrincipal p_objPrincipal,out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_mthFindRecipeFreq");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select freqid_chr,usercode_chr,freqname_chr from T_AID_RECIPEFREQ order by USERCODE_CHR";
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref dt);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
               #endregion
		#region 根据申请单分类ID,获取收费项目
		/// <summary>
		/// 根据申请单分类ID,获取收费项目
		/// </summary>
		/// <param name="strTypeID">申请类型ID</param>
		/// <param name="strItem">为空("")时查询所有数据,否则按条件模糊查询</param>
		/// <param name="strFindType">查询时的条件,如"按拼音码,编号等,如果为空("")默认为编号"</param>
		/// <param name="objResult">返回收费项目VO数组</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_mthGetChargeItemByApplyTypeID(string strTypeID,string strItem,string strFindType,out clsChargeItem_VO[] objResult)
		{
			objResult =null;
			long lngRes = 0;
			if(strFindType==null||strFindType.Trim()=="")
			{
				strFindType ="itemcode_vchr";
			}

			string strSQL=@"SELECT   *
    FROM t_bse_chargeitem
   WHERE apply_type_int = '"+strTypeID+@"'";
			if(strItem!=null&&strItem.Trim()!="")
			{
			strSQL +=" and "+strFindType+" like '"+strItem+"%'";
			}
				strSQL +=" ORDER BY itemcode_vchr";
			try
			{
				DataTable dtbResult=new DataTable();
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dtbResult);				
				if(lngRes>0&&dtbResult.Rows.Count>0)
				{
					objResult =new clsChargeItem_VO[dtbResult.Rows.Count];
					for(int i1 =0;i1<dtbResult.Rows.Count;i1++)
					{
						objResult[i1] = new clsChargeItem_VO();
						objResult[i1].m_strItemID = dtbResult.Rows[i1]["ITEMID_CHR"].ToString().Trim();
						objResult[i1].m_strItemName = dtbResult.Rows[i1]["ITEMNAME_VCHR"].ToString().Trim();
						objResult[i1].m_strItemCode = dtbResult.Rows[i1]["ITEMCODE_VCHR"].ToString().Trim();
						objResult[i1].m_strItemPYCode = dtbResult.Rows[i1]["ITEMPYCODE_CHR"].ToString().Trim();
						objResult[i1].m_strItemWBCode = dtbResult.Rows[i1]["ITEMWBCODE_CHR"].ToString().Trim();
						objResult[i1].m_strItemSrcID = dtbResult.Rows[i1]["ITEMSRCID_VCHR"].ToString().Trim();
						if(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim()!="")
							objResult[i1].m_intItemSrcType = Convert.ToInt32(dtbResult.Rows[i1]["ITEMSRCTYPE_INT"].ToString().Trim());
						objResult[i1].m_strItemSpec = dtbResult.Rows[i1]["ITEMSPEC_VCHR"].ToString().Trim();
						if(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim()!="")
							objResult[i1].m_fltItemPrice = Convert.ToSingle(dtbResult.Rows[i1]["ITEMPRICE_MNY"].ToString().Trim());
						objResult[i1].m_ItemUnit=new clsUnit_VO();
						objResult[i1].m_ItemUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMUNIT_CHR"].ToString().Trim();
						if (dtbResult.Columns.IndexOf("unitname_chr")>0)
							objResult[i1].m_ItemUnit.m_strUnitName = dtbResult.Rows[i1]["unitname_chr"].ToString().Trim();
						objResult[i1].m_ItemOPUnit=new clsUnit_VO();
						objResult[i1].m_ItemOPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMOPUNIT_CHR"].ToString().Trim();
						objResult[i1].m_ItemIPUnit=new clsUnit_VO();
						objResult[i1].m_ItemIPUnit.m_strUnitID = dtbResult.Rows[i1]["ITEMIPUNIT_CHR"].ToString().Trim();
						objResult[i1].m_ItemOPCalcType=new clsChargeItemEXType_VO();
						objResult[i1].m_ItemOPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
						objResult[i1].m_ItemIPCalcType=new clsChargeItemEXType_VO();
						objResult[i1].m_ItemIPCalcType.m_strTypeID = dtbResult.Rows[i1]["ITEMIPCALCTYPE_CHR"].ToString().Trim();
						objResult[i1].m_ItemOPInvType=new clsChargeItemEXType_VO();
						objResult[i1].m_ItemOPInvType.m_strTypeID = dtbResult.Rows[i1]["ITEMOPINVTYPE_CHR"].ToString().Trim();
						objResult[i1].m_ItemIPInvType=new clsChargeItemEXType_VO();
						objResult[i1].m_ItemIPInvType.m_strTypeID = dtbResult.Rows[i1]["ITEMIPINVTYPE_CHR"].ToString().Trim();
						if(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim()!="")
							objResult[i1].m_strDosage = Convert.ToSingle(dtbResult.Rows[i1]["DOSAGE_DEC"].ToString().Trim());
						objResult[i1].m_DosageUnit=new clsUnit_VO();//用量单位
						objResult[i1].m_DosageUnit.m_strUnitID = dtbResult.Rows[i1]["DOSAGEUNIT_CHR"].ToString().Trim();
						if(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim()!="")
							objResult[i1].m_intIsGroupItem = Convert.ToInt32(dtbResult.Rows[i1]["ISGROUPITEM_INT"].ToString().Trim());
						objResult[i1].m_ItemCat=new clsCharegeItemCat_VO();
						objResult[i1].m_ItemCat.m_strItemCatID = dtbResult.Rows[i1]["ITEMCATID_CHR"].ToString().Trim();
						objResult[i1].m_Usage=new clsUsageType_VO();
						objResult[i1].m_Usage.m_strUsageID=dtbResult.Rows[i1]["USAGEID_CHR"].ToString().Trim();
						objResult[i1].m_strITEMOPCODE_CHR=dtbResult.Rows[i1]["ITEMOPCODE_CHR"].ToString();
						objResult[i1].m_strINSURANCEID_CHR=dtbResult.Rows[i1]["INSURANCEID_CHR"].ToString();
//						if(dtbResult.Rows[i1]["qty_dec"] != Convert.DBNull )
//						{
//							objResult[i1].m_strUNITPRICE=dtbResult.Rows[i1]["qty_dec"].ToString();
//							try
//							{
//								float sumprice =objResult[i1].m_fltItemPrice*float.Parse(objResult[i1].m_strUNITPRICE);
//								objResult[i1].m_strTOTALPRICE =sumprice.ToString();
//							}
//							catch
//							{
//						
//							}
//						}
						try
						{
							objResult[i1].m_intCLINICTYPE_INT=Int32.Parse(dtbResult.Rows[i1]["CLINICTYPE_INT"].ToString());
						}
						catch{}
						try
						{
							objResult[i1].m_dblBIHQTY_DEC=double.Parse(dtbResult.Rows[i1]["BIHQTY_DEC"].ToString());
						}
						catch{}
						try
						{
							objResult[i1].m_intBIHTYPE_INT=Int32.Parse(dtbResult.Rows[i1]["BIHTYPE_INT"].ToString());
						}
						catch{}			
					}
												 
				}
			}
			catch(Exception objEx)
			{
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion
        #region 将收费项目同步到诊疗项目
        /// <summary>
        /// 将收费项目同步到诊疗项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_objDataArr"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthChargeItemSynOrderDic(System.Security.Principal.IPrincipal p_objPrincipal, clsChargeItemSynToOrderDic[] m_objDataArr)
        {   
            DataTable m_objTable = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_mthChargeItemSynOrderDic");
            if (lngRes < 0)
            {
                return -1;
            }
            string strGetMaxSQL = @"select lpad(seq_ocmapid.NEXTVAL,18,'0') p_strRecordID  from dual";
            DataTable m_objMaxTable = new DataTable();
            string m_strocmapid = "";
           
                string strSQL = @"SELECT A.ORDERDICID_CHR FROM T_AID_BIH_ORDERDIC_CHARGE A WHERE A.ITEMID_CHR='" + m_objDataArr[0].m_strChargeItemID + "'";//查看关联项目
                try
                {
                    com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                    if (lngRes > 0)
                    {
                        if (m_objTable.Rows.Count > 0)
                        {
                            for (int i = 0; i < m_objTable.Rows.Count; i++)
                            {
                                strSQL = @"delete from t_aid_bih_orderdic_charge A where A.orderdicid_chr='" + m_objTable.Rows[i][0].ToString().Trim() + "'and trim(A.itemid_chr)<>(SELECT  a.itemid_chr FROM t_aid_bih_orderdic_charge a, t_bse_bih_orderdic b WHERE a.orderdicid_chr = b.orderdicid_chr(+) AND a.orderdicid_chr ='" + m_objTable.Rows[i][0].ToString().Trim() + "' and a.itemid_chr=b.itemid_chr)";
                                lngRes = objHRPSvc.DoExcute(strSQL);
                                for (int j = 0; j < m_objDataArr.Length; j++)
                                {
                                    if (m_objDataArr[j].m_strSubChargeItemID.ToString().Trim() == string.Empty)
                                        continue;
                                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strGetMaxSQL, ref m_objMaxTable);
                                    if (lngRes > 0 && m_objMaxTable.Rows.Count > 0)
                                    {
                                        m_strocmapid = Convert.ToString(m_objMaxTable.Rows[0]["p_strRecordID"].ToString());
                                    }
                                    else
                                    {
                                        return -1;
                                    }

                                    if (m_strocmapid.Trim()!=string.Empty && lngRes > 0)
                                    {
                                        strSQL = @"insert into t_aid_bih_orderdic_charge A (A.ocmapid_chr,A.orderdicid_chr,A.itemid_chr,A.qty_int,A.type_int,A.usescope_int,A.CONTINUEUSETYPE_INT)
                                       values('" + m_strocmapid.Trim() + "','" + m_objTable.Rows[i][0].ToString().Trim() + "','" + m_objDataArr[j].m_strSubChargeItemID.ToString().Trim() + "'," + m_objDataArr[j].m_intQuality + "," + m_objDataArr[j].m_intType + "," + m_objDataArr[j].m_intUseScope + "," + m_objDataArr[j].m_intContinueUseType + ") ";
                                        lngRes = objHRPSvc.DoExcute(strSQL);
                                    }
                                }

                            }
                        }
                        else//关联1:0
                        {
                            strSQL = @"select A.orderdicid_chr from t_bse_bih_orderdic A where A.itemid_chr='" + m_objDataArr[0].m_strChargeItemID + "'";
                            lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL, ref m_objTable);
                            if (m_objTable.Rows.Count>0&&lngRes>0)
                            {
                                lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strGetMaxSQL, ref m_objMaxTable);
                                if (lngRes > 0 && m_objMaxTable.Rows.Count > 0)
                                {
                                    m_strocmapid = Convert.ToString(m_objMaxTable.Rows[0]["p_strRecordID"].ToString());
                                }
                                else
                                {
                                    return -1;
                                }
                                if (m_strocmapid.Trim()!=string.Empty && lngRes > 0)
                                {
                                    strSQL = @"insert into t_aid_bih_orderdic_charge A (A.ocmapid_chr,A.orderdicid_chr,A.itemid_chr,A.qty_int,A.type_int,A.usescope_int,A.CONTINUEUSETYPE_INT)
                                       values('" + m_strocmapid.Trim() + "','" + m_objTable.Rows[0][0].ToString().Trim() + "','" + m_objDataArr[0].m_strChargeItemID.ToString().Trim() + "',1,1,0,0) ";
                                    lngRes = objHRPSvc.DoExcute(strSQL);
                                }

                                for (int j = 0; j < m_objDataArr.Length; j++)
                                {
                                    if (m_objDataArr[j].m_strSubChargeItemID.ToString().Trim() == string.Empty)
                                        continue;
                                    lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strGetMaxSQL, ref m_objMaxTable);
                                    if (lngRes > 0 && m_objMaxTable.Rows.Count > 0)
                                    {
                                        m_strocmapid = Convert.ToString(m_objMaxTable.Rows[0]["p_strRecordID"].ToString());
                                    }
                                    else
                                    {
                                        return -1;
                                    }

                                    if (m_strocmapid.Trim()!=string.Empty && lngRes > 0)
                                    {
                                        strSQL = @"insert into t_aid_bih_orderdic_charge A (A.ocmapid_chr,A.orderdicid_chr,A.itemid_chr,A.qty_int,A.type_int,A.usescope_int,A.CONTINUEUSETYPE_INT)
                                       values('" + m_strocmapid.ToString().Trim() + "','" + m_objTable.Rows[0][0].ToString().Trim() + "','" + m_objDataArr[j].m_strSubChargeItemID.ToString().Trim() + "'," + m_objDataArr[j].m_intQuality + "," + m_objDataArr[j].m_intType + "," + m_objDataArr[j].m_intUseScope + "," + m_objDataArr[j].m_intContinueUseType + ") ";
                                        lngRes = objHRPSvc.DoExcute(strSQL);
                                    }
                                }
                                

                            }

                        }

                    }
                }
                catch (Exception objEx)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                    bool blnRes = objLogger.LogError(objEx);
                }
       
            return lngRes;
        }
        #endregion
        #region 加载类ID
        [AutoComplete]
		public long m_mthLoadCheckType(out DataTable dt,string strEx)
		{
			long lngRes=0;
			dt =new DataTable();
//			string strSQL =@"SELECT TO_CHAR(partid) AS ID, partname AS typename
//  FROM ar_apply_partlist
//UNION
//SELECT sample_type_id_chr AS ID, sample_type_desc_vchr AS typename
//  FROM t_aid_lis_sampletype";
			string strSQL =@"SELECT partid AS ID, partname AS typename
  FROM ar_apply_partlist";
			if(strEx.Trim()!="")
			{
			strSQL +="  where TYPEID  ='"+strEx+"'";
			}
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
				
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			return lngRes;
		}
		#endregion

        #region 查找系统设置
        /// <summary>
        /// 查找系统设置
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="objResult"></param>
        /// <param name="strCode"></param>
        /// <returns></returns>
        [AutoComplete]
        public long GetSysSetting(System.Security.Principal.IPrincipal p_objPrincipal, string p_strSetId, out string p_strSetStatus)
        {
            long lngRes = 0;
           
            p_strSetStatus = "0";

            //权限类
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            //检查是否有使用些函数的权限
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_GetUsage");
            if (lngRes < 0) //没有使用的权限
            {
                return -1;
            }
            string strSQL = "Select SETSTATUS_INT From T_SYS_SETTING where SETID_CHR = ? ";

            try
            {
                DataTable dtResult = new DataTable();
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(1, out arrParams);
                arrParams[0].Value = p_strSetId;
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dtResult, arrParams);
                objHRPSvc.Dispose();

                if (lngRes > 0 && dtResult.Rows.Count > 0)
                {
                    p_strSetStatus = dtResult.Rows[0]["SETSTATUS_INT"].ToString();
                }

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion

        #region 更改
        /// <summary>
        /// 更改主收费项目关联的诊疗项目
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="p_strChiefItemID">主收费项目</param>
        /// <param name="p_strOrderdicid">诊疗项目流水号</param>
        /// <returns></returns>
        [AutoComplete]
        public long m_lngUpdateOrderDicByChargeItemId(System.Security.Principal.IPrincipal p_objPrincipal, clsChargeItem_VO clsVO)
        {
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_lngUpdateOrderDicByChargeItemId");
            if (lngRes < 0)
            {
                return -1;
            }
           
            string strSQL = string.Empty;
//            strSQL += @" UPDATE T_BSE_BIH_ORDERDIC a
//                            SET a.NAME_CHR = ?, 
//                                a.USERCODE_CHR = ?,
//                                a.WBCODE_CHR = ?,
//                                a.PYCODE_CHR = ?,
//                                a.ENGNAME_VCHR = ?,
//                                a.COMMNAME_VCHR = ?
//                          WHERE EXISTS 
//                              (SELECT ORDERDICID_CHR from T_AID_BIH_ORDERDIC_CHARGE b 
//                                               where a.ORDERDICID_CHR = b.ORDERDICID_CHR and 
//                                                     b.USESCOPE_INT = 0 and
//                                                     b.ITEMID_CHR = ?)";
            strSQL = @" UPDATE T_BSE_BIH_ORDERDIC a
                                        SET a.NAME_CHR = ?, 
                                            a.WBCODE_CHR = ?,
                                            a.PYCODE_CHR = ?,
                                            a.ENGNAME_VCHR = ?,
                                            a.COMMNAME_VCHR = ?
                                      WHERE EXISTS 
                                          (SELECT ORDERDICID_CHR from T_AID_BIH_ORDERDIC_CHARGE b 
                                                           where a.ORDERDICID_CHR = b.ORDERDICID_CHR and 
                                                                 b.USESCOPE_INT = 0 and
                                                                 b.ITEMID_CHR = ?)";
            
            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();

                System.Data.IDataParameter[] arrParams = null;
                new clsHRPTableService().CreateDatabaseParameter(6, out arrParams);

                arrParams[0].Value = clsVO.m_strItemName;
                //arrParams[1].Value = clsVO.m_strItemCode;
                arrParams[1].Value = clsVO.m_strItemWBCode;
                arrParams[2].Value = clsVO.m_strItemPYCode;
                arrParams[3].Value = clsVO.m_strEnglishName;
                arrParams[4].Value = clsVO.m_strCommName;
                arrParams[5].Value = clsVO.m_strItemID;

                lngRes = 0;
                lngRes = objHRPSvc.lngExecuteParameterSQL(strSQL, ref lngRes, arrParams);
            }
            catch (Exception objEx)
            {
                string strTmp = objEx.Message;
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 获取收费项目执行分类
        /// <summary>
        /// 获取收费项目执行分类
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strFindText"></param>
        /// <param name="m_intFlag"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindExeType(System.Security.Principal.IPrincipal p_objPrincipal, string m_strFindText,int m_intFlag, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_mthFindExeType");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.typeid_chr,a.usercode_chr,a.typename_vchr from t_bse_chargeitemextype A where a.flag_int=? and (upper(a.usercode_chr) like ? or upper(a.typename_vchr) like ? )order by a.usercode_chr";
            string strSQL1 = @"select a.typeid_chr,a.usercode_chr,a.typename_vchr from t_bse_chargeitemextype A where a.flag_int=?  order by a.usercode_chr";
            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objArrParams = null;
                if (m_strFindText.Trim() != string.Empty)
                {
                    objHRPSvc.CreateDatabaseParameter(3, out m_objArrParams);
                    m_objArrParams[0].Value=m_intFlag;
                    m_objArrParams[1].Value=m_strFindText.ToUpper()+"%";
                    m_objArrParams[2].Value =m_strFindText.ToUpper()+"%";
                    lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, m_objArrParams);
                }
                else
                {
                     objHRPSvc.CreateDatabaseParameter(1, out m_objArrParams);
                     m_objArrParams[0].Value = m_intFlag;
                     lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL1, ref dt, m_objArrParams);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
                #endregion
        #region 获取执行分类
        /// <summary>
        /// 获取执行分类
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strFindText"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindExeType(System.Security.Principal.IPrincipal p_objPrincipal, string m_strFindText, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_mthFindExeType");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.ordercateid_chr,a.ordercatename_vchr from t_aid_bih_orderperformcate a where upper(a.ordercatename_vchr) like ? order by a.sort_int";

            try
            {

                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objArrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out m_objArrParams);
                m_objArrParams[0].Value = m_strFindText.ToUpper()+"%";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, m_objArrParams);

            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
        #region 获取医嘱类型
        /// <summary>
        /// 获取医嘱类型
        /// </summary>
        /// <param name="p_objPrincipal"></param>
        /// <param name="m_strFindText"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        [AutoComplete]
        public long m_mthFindOrderType(System.Security.Principal.IPrincipal p_objPrincipal, string m_strFindText, out DataTable dt)
        {
            dt = new DataTable();
            long lngRes = 0;
            clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
            lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal, "com.digitalwave.iCare.middletier.HIS.clsChargeItemSvc", "m_mthFindOrderType");
            if (lngRes < 0)
            {
                return -1;
            }

            string strSQL = @"select a.ordercateid_chr,a.name_chr from t_aid_bih_ordercate a  where upper(a.name_chr) like ?";

            try
            {
                com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
                System.Data.IDataParameter[] m_objArrParams = null;
                objHRPSvc.CreateDatabaseParameter(1, out m_objArrParams);
                m_objArrParams[0].Value = m_strFindText.ToUpper() + "%";
                lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL, ref dt, m_objArrParams);
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            return lngRes;
        }
        #endregion
	}

}
        #endregion
