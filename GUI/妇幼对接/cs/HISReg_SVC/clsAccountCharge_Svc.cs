using System;
using System.EnterpriseServices;
using System.Data;
using com.digitalwave.Utility;//Utility.dll
using com.digitalwave.iCare.middletier.HRPService;//HRPService.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.security;//PrivilegeSystemService.dll
using System.Collections;

namespace com.digitalwave.iCare.middletier.HIS
{
	/// <summary>
	/// 收费
	/// 创建人：	2005-03-18
	/// </summary>
	[Transaction(TransactionOption.Required)]
	[ObjectPooling(true)]
	public class clsAccountCharge_Svc: com.digitalwave.iCare.middletier.clsMiddleTierBase
	{
		#region 构造函数
		public clsAccountCharge_Svc()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#endregion

		//用法收费
		#region 门诊用法单位频率天数的领量
		/// <summary>
		/// 获取门诊用法单位频率天数的领量
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_intTIMES">周期用药次数</param>
		/// <param name="p_dblQTY">数量	{if(p_intType==1) 一次领量; if(p_intType==2) 医生下的剂量;}</param>
		/// <param name="p_intType">{1=领量单位;2=剂量单位}</param>
		/// <param name="p_dblUnitDosage">单位剂量	{只有p_intType==2，此参数才有意义}</param>
		/// <param name="p_dblGet">单位频率天数的领量	[out 参数]</param>
		/// <returns></returns>
		/// <remarks>
		/// 业务描述：
		///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
		///		if(TYPE_INT==2[剂量单位]) then {=次数*(医生下的剂量/单位剂量)；}
		/// 业务描述：[领量、用量、频率]
		///		领量 = 用量 * 周期用药次数
		///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
		/// </remarks>
		[AutoComplete]
		public long m_lngGetMeasureClinicUsage(System.Security.Principal.IPrincipal p_objPrincipal,int p_intTIMES,double p_dblQTY,int p_intType,double p_dblUnitDosage,out double p_dblGet)
		{
			long lngRes=0;
			p_dblGet =0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewT_opr_opinvoiceman");
			if(lngRes < 0)
			{
				return -1;
			}

			p_dblGet =0;
			if(p_intType==2)//剂量单位
			{
				double dblUse =p_dblQTY/p_dblUnitDosage;
				p_dblGet = dblUse * p_intTIMES;	//用量*次数
			}
			else if(p_intType==1)//领量单位
			{
				p_dblGet = p_dblQTY * p_intTIMES;
			}
			return lngRes;
		}
		#endregion
		#region 门诊用法收费
		/// <summary>
		/// 获取门诊用法收费
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strITEMID_CHR">收费项目ID</param>
		/// <param name="strUSAGEID_CHR">用法ID</param>
		/// <param name="p_dblMoney">收费	[out 参数]</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetChargeClinicUsage(System.Security.Principal.IPrincipal p_objPrincipal,string strITEMID_CHR,string strUSAGEID_CHR,out double p_dblMoney)
		{
			long lngRes =0;
			p_dblMoney =0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewT_opr_opinvoiceman");
			if(lngRes < 0)
			{
				return -1;
			}

			clsChargeItem_VO[] objItemArr;
			lngRes =new clsChargeItemSvc().m_GetItemByUsageIDAndItemID(p_objPrincipal,strITEMID_CHR,strUSAGEID_CHR,out objItemArr);
			if(lngRes>0)
			{
				//住院单价								itemprice_mny
				//decode(a.IPCHARGEFLG_INT,1,Round(a.ItemPrice_Mny/a.PackQty_Dec,4),0,a.ItemPrice_Mny,Round(a.ItemPrice_Mny/a.PackQty_Dec,4)) MinPrice
				double dblPrice =0;
				try
				{
					//住院收费单位 0 －基本单位 1－最小单位
					if(objItemArr[0].m_intOPCHARGEFLG_INT==0)//门诊收费单位 0 －基本单位 1－最小单位
						dblPrice =double.Parse(objItemArr[0].m_fltItemPrice.ToString());
					else
					{
						double dblItemPrice =double.Parse(objItemArr[0].m_fltItemPrice.ToString());
						double dblPACKQTY_DEC =double.Parse(objItemArr[0].m_decPACKQTY_DEC.ToString());
						dblPrice =double.Parse((dblItemPrice/dblPACKQTY_DEC).ToString("0.0000"));
					}
				}
				catch{}
				//门诊数量
				double dblQTY_DEC =0;
				try
				{
					dblQTY_DEC =double.Parse(objItemArr[0].m_strUNITPRICE.ToString());
				}
				catch{}
				//医生下的剂量
				double dblDosage =0;
				try
				{
					dblDosage =double.Parse(objItemArr[0].m_strDosage.ToString());
				}
				catch{}
				lngRes =m_lngGetChargeClinicUsage(p_objPrincipal,dblPrice,1,dblQTY_DEC,objItemArr[0].m_intCLINICTYPE_INT,dblDosage,out p_dblMoney);
			}
			return lngRes;
		}
		/// <summary>
		/// 获取门诊用法收费
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_dblPrice">价格</param>
		/// <param name="p_intTIMES">周期用药次数</param>
		/// <param name="p_dblQTY">数量	{if(p_intType==1) 一次领量; if(p_intType==2) 医生下的剂量;}</param>
		/// <param name="p_intType">{1=领量单位;2=剂量单位}</param>
		/// <param name="p_dblUnitDosage">单位剂量	{只有p_intType==2，此参数才有意义}</param>
		/// <param name="p_dblMoney">单位频率天数总价	[out 参数]</param>
		/// <returns></returns>
		/// <remarks>
		/// 业务描述：
		///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
		///		if(TYPE_INT==2[剂量单位]) then {=次数*(医生下的剂量/单位剂量)}
		/// 业务描述：[领量、用量、频率]
		///		领量 = 用量 * 周期用药次数
		///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
		/// </remarks>
		[AutoComplete]
		public long m_lngGetChargeClinicUsage(System.Security.Principal.IPrincipal p_objPrincipal,double p_dblPrice,int p_intTIMES,double p_dblQTY,int p_intType,double p_dblUnitDosage,out double p_dblMoney)
		{
			long lngRes=0;
			p_dblMoney =0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewT_opr_opinvoiceman");
			if(lngRes < 0)
			{
				return -1;
			}

			double dblGet =0;
			lngRes =m_lngGetMeasureClinicUsage(p_objPrincipal,p_intTIMES,p_dblQTY,p_intType,p_dblUnitDosage,out dblGet);
			p_dblMoney =p_dblPrice * dblGet;
			return lngRes;
		}
		#endregion
		#region 住院用法单位频率天数的领量
		/// <summary>
		/// 获取住院用法单位频率天数的领量
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_intTIMES">周期用药次数</param>
		/// <param name="p_dblQTY">数量	{if(p_intType==1) 一次领量; if(p_intType==2) 医生下的剂量;}</param>
		/// <param name="p_intType">{1=领量单位;2=剂量单位}</param>
		/// <param name="p_dblUnitDosage">单位剂量	{只有p_intType==2，此参数才有意义}</param>
		/// <param name="p_dblGet">单位频率天数的领量	[out 参数]</param>
		/// <returns></returns>
		/// <remarks>
		/// 业务描述：
		///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
		///		if(TYPE_INT==2[剂量单位]) then {=次数*(医生下的剂量/单位剂量)；}
		/// 业务描述：[领量、用量、频率]
		///		领量 = 用量 * 周期用药次数
		///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
		/// </remarks>
		[AutoComplete]
		public long m_lngGetMeasureBIHUsage(System.Security.Principal.IPrincipal p_objPrincipal,int p_intTIMES,double p_dblQTY,int p_intType,double p_dblUnitDosage,out double p_dblGet)
		{
			long lngRes=0;
			p_dblGet =0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewT_opr_opinvoiceman");
			if(lngRes < 0)
			{
				return -1;
			}

			p_dblGet =0;
			if(p_intType==2)//剂量单位
			{
				double dblUse =p_dblQTY/p_dblUnitDosage;
				p_dblGet = dblUse * p_intTIMES;	//用量*次数
			}
			else if(p_intType==1)//领量单位
			{
				p_dblGet = p_dblQTY * p_intTIMES;
			}
			return 1;
		}
		#endregion
		#region 获取门诊总价及住院总价
		/// <summary>
		/// 获取门诊总价及住院总价
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strITEMID_CHR">项目ID</param>
		/// <param name="intType">1-门诊总价，2-住院总价</param>
		/// <param name="dblQTY">数量</param>
		/// <param name="intNuit">1-领药单位，2-剂量单位</param>
		/// <param name="dblTotailMoney">返回总金额</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetChargeUsageTotailMoney(System.Security.Principal.IPrincipal p_objPrincipal,string strITEMID_CHR,int intType,double dblQTY,int intNuit,out double dblTotailMoney)
		{
			long lngRes =0;
			dblTotailMoney =0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewT_opr_opinvoiceman");
			if(lngRes < 0)
			{
				return -1;
			}
			string strSQL=@"select ITEMPRICE_MNY,ITEMOPUNIT_CHR,ITEMIPUNIT_CHR,DOSAGE_DEC,DOSAGEUNIT_CHR,PACKQTY_DEC,OPCHARGEFLG_INT,IPCHARGEFLG_INT from t_bse_chargeitem where ITEMID_CHR='"+strITEMID_CHR+"'";
			DataTable p_dt=new DataTable();
			try
			{
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new clsHRPTableService();
				lngRes = objHRPSvc.lngGetDataTableWithoutParameters(strSQL,ref p_dt);
			}
			catch(Exception objEx)
			{
				string strTmp=objEx.Message;
				com.digitalwave.Utility.clsLogText objLogger = new clsLogText();
				bool blnRes = objLogger.LogError(objEx);
			}
			//最小单位单价
			double littlePrice=0.00;
			try
			{
				littlePrice=Double.Parse(p_dt.Rows[0]["ITEMPRICE_MNY"].ToString())/int.Parse(p_dt.Rows[0]["PACKQTY_DEC"].ToString());
			}
			catch
			{
			}

			if(intType==1)
			{
				if(intNuit==1)
				{
					if(p_dt.Rows[0]["OPCHARGEFLG_INT"].ToString()=="0")
					{
						dblTotailMoney=Double.Parse(p_dt.Rows[0]["ITEMPRICE_MNY"].ToString())*dblQTY;
					}
					else
					{
						dblTotailMoney=littlePrice*dblQTY;
					}
				}
				else
				{
					if(p_dt.Rows[0]["DOSAGE_DEC"]!=System.DBNull.Value&&p_dt.Rows[0]["DOSAGE_DEC"].ToString()!="")
					{
						dblTotailMoney=dblQTY/Double.Parse(p_dt.Rows[0]["DOSAGE_DEC"].ToString())*littlePrice;
					}
				}
			}
			else
			{
				if(intNuit==1)
				{
					if(p_dt.Rows[0]["IPCHARGEFLG_INT"].ToString()=="0")
					{
						dblTotailMoney=Double.Parse(p_dt.Rows[0]["ITEMPRICE_MNY"].ToString())*dblQTY;
					}
					else
					{
						dblTotailMoney=littlePrice*dblQTY;
					}
				}
				else
				{
					if(p_dt.Rows[0]["DOSAGE_DEC"]!=System.DBNull.Value&&p_dt.Rows[0]["DOSAGE_DEC"].ToString()!="")
					{
						dblTotailMoney=dblQTY/Double.Parse(p_dt.Rows[0]["DOSAGE_DEC"].ToString())*littlePrice;
					}
				}

			}
			return lngRes;
		}

		#endregion
		#region 住院用法收费
		/// <summary>
		/// 获取住院用法收费
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="strITEMID_CHR">收费项目ID</param>
		/// <param name="strUSAGEID_CHR">用法ID</param>
		/// <param name="p_dblMoney">收费	[out 参数]</param>
		/// <returns></returns>
		[AutoComplete]
		public long m_lngGetChargeBIHUsage(System.Security.Principal.IPrincipal p_objPrincipal,string strITEMID_CHR,string strUSAGEID_CHR,out double p_dblMoney)
		{
			long lngRes =0;
			p_dblMoney =0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewT_opr_opinvoiceman");
			if(lngRes < 0)
			{
				return -1;
			}

			clsChargeItem_VO[] objItemArr;
			lngRes =new clsChargeItemSvc().m_GetItemByUsageIDAndItemID(p_objPrincipal,strITEMID_CHR,strUSAGEID_CHR,out objItemArr);
			if(lngRes>0)
			{
				//住院单价								
				//decode(a.IPCHARGEFLG_INT,1,Round(a.ItemPrice_Mny/a.PackQty_Dec,4),0,a.ItemPrice_Mny,Round(a.ItemPrice_Mny/a.PackQty_Dec,4)) MinPrice
				double dblPrice =0;
				try
				{
					//住院收费单位 0 －基本单位 1－最小单位
					if(objItemArr[0].m_intOPCHARGEFLG_INT==0)//门诊收费单位 0 －基本单位 1－最小单位
						dblPrice =double.Parse(objItemArr[0].m_fltItemPrice.ToString());
					else
					{
						double dblItemPrice =double.Parse(objItemArr[0].m_fltItemPrice.ToString());
						double dblPACKQTY_DEC =double.Parse(objItemArr[0].m_decPACKQTY_DEC.ToString());
						dblPrice =double.Parse((dblItemPrice/dblPACKQTY_DEC).ToString("0.0000"));
					}
				}
				catch{}
				//住院数量
				double dblQTY_DEC =0;
				try
				{
					dblQTY_DEC =objItemArr[0].m_dblBIHQTY_DEC;
				}
				catch{}
				//医生下的剂量
				double dblDosage =0;
				try
				{
					dblDosage =double.Parse(objItemArr[0].m_strDosage.ToString());
				}
				catch{}
				lngRes =m_lngGetChargeClinicUsage(p_objPrincipal,dblPrice,1,dblQTY_DEC,objItemArr[0].m_intBIHTYPE_INT,dblDosage,out p_dblMoney);
			}
			return lngRes;
		}
		/// <summary>
		/// 获取住院用法收费
		/// </summary>
		/// <param name="p_objPrincipal"></param>
		/// <param name="p_dblPrice">价格</param>
		/// <param name="p_intTIMES">周期用药次数</param>
		/// <param name="p_dblQTY">数量	{if(p_intType==1) 一次领量; if(p_intType==2) 医生下的剂量;}</param>
		/// <param name="p_intType">{1=领量单位;2=剂量单位}</param>
		/// <param name="p_dblUnitDosage">单位剂量	{只有p_intType==2，此参数才有意义}</param>
		/// <param name="p_dblMoney">单位频率天数总价	[out 参数]</param>
		/// <returns></returns>
		/// <remarks>
		/// 业务描述：
		///		if(TYPE_INT==1[领量单位]) then {=次数*领量}
		///		if(TYPE_INT==2[剂量单位]) then {=次数*(医生下的剂量/单位剂量)；}
		/// 业务描述：[领量、用量、频率]
		///		领量 = 用量 * 周期用药次数
		///		例如：用量=2,频率=3天4次,则 领量(3天的)=2*4;
		/// </remarks>
		[AutoComplete]
		public long m_lngGetChargeBIHUsage(System.Security.Principal.IPrincipal p_objPrincipal,double p_dblPrice,int p_intTIMES,double p_dblQTY,int p_intType,double p_dblUnitDosage,out double p_dblMoney)
		{
			long lngRes=0;
			p_dblMoney =0;
			clsPrivilegeHandleService objPrivilege = new clsPrivilegeHandleService();
			lngRes = objPrivilege.m_lngCheckCallPrivilege(p_objPrincipal,"com.digitalwave.iCare.middletier.LIS.clsLisDeviceSvc","m_lngDoAddNewT_opr_opinvoiceman");
			if(lngRes < 0)
			{
				return -1;
			}

			double dblGet =0;
			lngRes =m_lngGetMeasureBIHUsage(p_objPrincipal,p_intTIMES,p_dblQTY,p_intType,p_dblUnitDosage,out dblGet);
			p_dblMoney =p_dblPrice * dblGet;
			return lngRes;
		}
		#endregion
	}
}
