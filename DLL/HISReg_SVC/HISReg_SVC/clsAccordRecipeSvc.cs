using System;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.EnterpriseServices;
using System.Data;
using System.Collections;
//using Oracle.DataAccess.Client;
//using System.Windows.Forms;
namespace com.digitalwave.iCare.middletier.HIS
{
	/// <summary>
	/// clsAccordRecipeSvc 的摘要说明。
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsAccordRecipeSvc:com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		public clsAccordRecipeSvc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 选择主处方号
		[AutoComplete]
		public long m_mthGetAccordRecipeDetail(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthGetAccordRecipeDetail");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT a.*, b.itemname_vchr, b.itemspec_vchr, b.itemcatid_chr, b.ifstop_int,
       c.usagename_vchr, d.freqname_chr, e.noqtyflag_int, b.itemopinvtype_chr,CASE
            WHEN b.opchargeflg_int = 1
               THEN ROUND (b.itemprice_mny / b.packqty_dec,
                           4
                          )
            WHEN b.opchargeflg_int = 0
               THEN b.itemprice_mny
         END AS itemprice_mny,b.ITEMCODE_VCHR,b.DOSAGEUNIT_CHR,e.MEDICINEID_CHR,b.ITEMOPUNIT_CHR,a.QTY_DEC,a.DOSETYPE_CHR
  FROM t_aid_concertrecipedetail a,
       t_bse_chargeitem b,
       t_bse_usagetype c,
       t_aid_recipefreq d,
       t_bse_medicine e
 WHERE a.itemid_chr = b.itemid_chr(+)
   AND a.freqid_chr = d.freqid_chr(+)
   AND a.dosetype_chr = c.usageid_chr(+)
   AND b.itemsrcid_vchr = e.medicineid_chr(+) AND a.recipeid_chr = ? order by a.sort_int";
			try
			{
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = ID;

				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dt, ParamArr);
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
		#region 查找西药处方明细
		[AutoComplete]
		public long m_mthFindWMRecipeDetail(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindWMRecipeDetail");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT a.itemid_chr, a.qty_dec,a.DOSAGEQTY_DEC, b.itemname_vchr, b.itemspec_vchr,b.ITEMOPUNIT_CHR,b.ITEMIPUNIT_CHR,
       b.dosageunit_chr, ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,b.itemengname_vchr,
       b.packqty_dec, b.itemprice_mny, b.opchargeflg_int,b.DOSAGE_DEC, a.dosetype_chr,
       c.usagename_vchr, a.freqid_chr, d.freqname_chr, d.times_int, b.insuranceid_chr, 
       d.days_int,b.ITEMOPINVTYPE_CHR,a.days_int as Days,b.ITEMCODE_VCHR,a.ROWNO_CHR,h.hype_int, h.deptprep_int
  FROM t_aid_concertrecipedetail a,
       t_bse_chargeitem b,
       t_bse_usagetype c,
       t_aid_recipefreq d,
       T_BSE_CHARGECATMAP e,
		t_bse_medicine H
 WHERE a.itemid_chr = b.itemid_chr(+)
   AND a.dosetype_chr = c.usageid_chr(+)
   AND a.freqid_chr = d.freqid_chr(+)
   AND b.ITEMOPINVTYPE_CHR =e.catid_chr(+)
   and b.ITEMSRCID_VCHR =h.medicineid_chr(+)
   and e.groupid_chr='0001'
   and e.INTERNALFLAG_INT=0
   AND recipeid_chr = '" + ID+"'  order by a.sort_int";
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
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
		#region 查找中药处方明细
		[AutoComplete]
		public long m_mthFindCMRecipeDetail(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindCMRecipeDetail");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT a.itemid_chr, a.qty_dec,a.DOSAGEQTY_DEC,a.DOSETYPE_CHR, b.itemname_vchr, b.itemspec_vchr,
       b.dosageunit_chr, ROUND (b.itemprice_mny / b.packqty_dec, 4) submoney,b.itemengname_vchr,
       b.packqty_dec, b.itemprice_mny,b.opchargeflg_int,b.dosage_dec, b.insuranceid_chr, 
       b.ITEMOPINVTYPE_CHR,d.usagename_vchr,b.ITEMCODE_VCHR,a.ROWNO_CHR, m.deptprep_int
  FROM t_aid_concertrecipedetail a,
       t_bse_chargeitem b,
       T_BSE_CHARGECATMAP e,
	   T_BSE_USAGETYPE d,
       t_bse_medicine m
 WHERE a.itemid_chr = b.itemid_chr(+)
    AND b.ITEMOPINVTYPE_CHR =e.catid_chr(+)
	and a.dosetype_chr=d.usageid_chr(+)
    and e.groupid_chr='0002'
    and e.INTERNALFLAG_INT=0
    and b.ITEMSRCID_VCHR = m.MEDICINEID_CHR(+)
    AND recipeid_chr = ? order by a.sort_int";
			try
			{
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = ID;

				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dt, ParamArr);
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
		#region 查找其他处方明细
		[AutoComplete]
		public long m_mthFindOtherRecipeDetail(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindOtherRecipeDetail");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL = @"SELECT a.itemid_chr, a.qty_dec, b.itemname_vchr, b.itemspec_vchr,
                b.itemunit_chr, b.itemprice_mny, b.selfdefine_int, b.usageid_chr, 
                b.itemopinvtype_chr, b.itemcode_vchr, b.itemengname_vchr, b.insuranceid_chr, 
                a.rowno_chr, g.sample_type_id_chr, h.sample_type_desc_vchr,
                d.partname, b.itemchecktype_chr,a.PARTORTYPE_VCHR,a.PARTORTYPENAME_VCHR, m.deptprep_int
           FROM t_aid_concertrecipedetail a,
                t_bse_chargeitem b,
                t_bse_chargecatmap e,
                t_aid_lis_apply_unit g,
                t_aid_lis_sampletype h,
                ar_apply_partlist d,
                t_bse_medicine m
          WHERE a.itemid_chr = b.itemid_chr(+)
            AND b.itemopinvtype_chr = e.catid_chr(+)
            AND e.groupid_chr <> '0001'
            AND e.groupid_chr <> '0002'
            AND e.internalflag_int = 0
            AND b.itemsrcid_vchr = g.APPLY_UNIT_ID_CHR(+)
            AND g.sample_type_id_chr = h.sample_type_id_chr(+)
            AND b.itemchecktype_chr = d.partid(+)
            and b.ITEMSRCID_VCHR = m.MEDICINEID_CHR(+)
			AND recipeid_chr = ? order by a.sort_int";
			try
			{			
                clsHRPTableService objHRPSvc = new clsHRPTableService();
                IDataParameter[] ParamArr = null;

                objHRPSvc.CreateDatabaseParameter(1, out ParamArr);
                //((OracleParameter)ParamArr[0]).OracleDbType = OracleDbType.Char;
                ParamArr[0].Value = ID;

				lngRes = objHRPSvc.lngGetDataTableWithParameters(strSQL,ref dt, ParamArr);
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
		#region 按项目ID查找比例
		[AutoComplete]
		public long m_mthFindDiscountByID(System.Security.Principal.IPrincipal p_objPrincipal,string ID,out DataTable dt)
		{
			dt=new DataTable();
			long lngRes=0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.HIS","m_mthFindDiscountByID");
			if(lngRes < 0)
			{
				return -1;
			}
            string strSQL = "";
            if (ID.Length > 0)
            {
                strSQL = @"SELECT   a.precent_dec decDiscount,a.copayid_chr, b.paytypename_vchr CatName
    FROM t_aid_inschargeitem a, t_bse_patientpaytype b
   WHERE a.copayid_chr = b.paytypeid_chr(+) AND itemid_chr = '" + ID + @"'  AND b.isusing_num = 1
ORDER BY b.paytypeid_chr";
            }
            else
            {
                strSQL = @"select 100                decdiscount,
			 b.paytypeid_chr    copayid_chr,
			 b.paytypename_vchr catname
	from t_bse_patientpaytype b
 where b.isusing_num = 1
 order by b.paytypeid_chr";//20080707：新增药品时，亦可输入比例
            }
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref dt);
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
		
	}
}
