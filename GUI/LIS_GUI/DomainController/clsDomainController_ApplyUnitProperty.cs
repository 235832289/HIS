using System;
using System.Data;
using System.Collections;
using com.digitalwave.iCare.middletier.LIS;//LisSvc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// clsDomainController_ApplyUnitProperty 的摘要说明。
	/// </summary>
	public class clsDomainController_ApplyUnitProperty:com.digitalwave.GUI_Base.clsDomainController_Base
	{
		public clsDomainController_ApplyUnitProperty()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}


		public long m_lngGetAllUnitPropertyData(out clsUnitProperty_VO[] p_objPropertyArr,
			out clsUnitPropertyValue_VO[] p_objValueArr)
		{
			p_objPropertyArr = null;
			p_objValueArr = null;
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc));
			lngRes = objSvc.m_lngGetAllUnitPropertyAndDetail(objPrincipal,out p_objPropertyArr,out p_objValueArr);

			return lngRes;
		}


		public long m_lngSave(clsApplyUnitPropertyDoc p_objDoc)
		{
			long lngRes = 0;
			clsApplyUnitPropertyDoc objDocOut = null;
			com.digitalwave.iCare.middletier.LIS.clsApplyPropertySv objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsApplyPropertySv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsApplyPropertySv));
			lngRes = objSvc.m_lngSavePropertyAndValue(objPrincipal,p_objDoc,out objDocOut);

			return lngRes;			
		}


		public long m_lngConstructDoc(out clsApplyUnitPropertyDoc p_objDoc)
		{
			p_objDoc = null;
			clsUnitProperty_VO[] objPropertyArr;
			clsUnitPropertyValue_VO[] objValueArr;

			long lngRes = m_lngGetAllUnitPropertyData(out objPropertyArr,out objValueArr);

			if(lngRes <=0)
			{
				return lngRes;
			}
			
			p_objDoc = new clsApplyUnitPropertyDoc();

			Hashtable hasPorperty = new Hashtable();
			if(objPropertyArr != null)
			{
				foreach(clsUnitProperty_VO objPropertyVO in objPropertyArr)
				{
					clsApplyUnitProperty objProperty = new clsApplyUnitProperty();
					objProperty.PropertyVO = objPropertyVO;
					objProperty.State = enmRecordState.Original;
					p_objDoc.Properties.Add(objProperty);
					if(!hasPorperty.ContainsKey(objPropertyVO.m_strPROPERTY_ID_CHR))
					{
						hasPorperty.Add(objPropertyVO.m_strPROPERTY_ID_CHR,objProperty);
					}
				}
			}
			if(objValueArr != null)
			{
				foreach(clsUnitPropertyValue_VO objValueVO in objValueArr)
				{
					clsPropertyValue objValue = new clsPropertyValue();
					objValue.ValueVO = objValueVO;
					objValue.State = enmRecordState.Original;
					if(hasPorperty.ContainsKey(objValueVO.m_strPROPERTY_ID_CHR))
					{
						((clsApplyUnitProperty)hasPorperty[objValueVO.m_strPROPERTY_ID_CHR]).Values.Add(objValue);
					}
				}
			}
			return lngRes;
		}


		public long m_lngGetRelatesByUnitID(string p_strApplyUnitID,out clsUnitPropertyRelate_VO[] p_objVOArr)
		{
			long lngRes = 0;
			p_objVOArr = null;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc));
			lngRes = objSvc.m_lngGetRelatesByUnitID(objPrincipal,p_strApplyUnitID,out p_objVOArr);

			return lngRes;
		}


		public long m_lngSaveRelate(string p_strApplyUnitID,clsUnitPropertyRelate_VO[] p_objVOArr)
		{
			long lngRes = 0;
			com.digitalwave.iCare.middletier.LIS.clsApplyPropertySv objSvc = 
				(com.digitalwave.iCare.middletier.LIS.clsApplyPropertySv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
				typeof(com.digitalwave.iCare.middletier.LIS.clsApplyPropertySv));
			lngRes = objSvc.m_lngSaveRelate(objPrincipal,p_strApplyUnitID, p_objVOArr);

			return lngRes;
		}





		#region		返回所有的属性id
		/// <summary>
		/// 返回所有的属性id
		/// </summary>
		/// <param name="p_strPropertyIDArr">结果集合</param>
		/// <returns>是否成功</returns>
		public long m_mthGetAllPropertyId(out string[] p_strPropertyIDArr)
		{
			long lngRes = 0;

            com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc));

			lngRes = objSvc.m_lngGetAllPropertyId(objPrincipal,out p_strPropertyIDArr);
			
			return lngRes;
		}
		#endregion

		#region		返回满足条件的属性值集合
		/// <summary>
		/// 返回满足条件的属性值集合
		/// </summary>
		/// <param name="p_strPropertyId">属性id</param>
		/// <param name="p_strApplyUnitId"><申请单元id/param>
		/// <param name="p_arlResult">结果集合</param>
		/// <returns>是否成功</returns>
		public long m_mthGetPropertyValue(string p_strPropertyId,string p_strApplyUnitId,out ArrayList p_arlResult)
		{
			long lngRes = 0;
            com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc objSvc =
                (com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(
                typeof(com.digitalwave.iCare.middletier.LIS.clsQueryApplyPropertySvc));

			lngRes = objSvc.m_lngGetPropertyValue(objPrincipal,p_strPropertyId,p_strApplyUnitId,out p_arlResult);
			
			return lngRes;
		}
		#endregion
	}

	/// <summary>
	/// 进行分单操作  --> 即是通常说的: "合单"
	/// </summary>
	public class clsSeparateCheckApplication
	{
		public clsSeparateCheckApplication()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		private ArrayList m_hasSeparate(string p_strPropertyID,string[] p_strApplyUnitIDArr)
		{
			Hashtable htbValueArlUnitId = new Hashtable();
			ArrayList arlUnitArlValue = new ArrayList();
			foreach(string unitId in p_strApplyUnitIDArr)		//循环申请单元id，返回申请单元id和其属性值的结构
			{
				arlUnitArlValue.Add(this.m_mthGetUnitArlValueByPropertyAndUnitId(p_strPropertyID,unitId));
			}

			foreach(UnitArlValue uv in arlUnitArlValue)
			{
				//区分属性值为空值的申请单元组
				if(uv.arlValue.Count == 0)
				{
					if(htbValueArlUnitId.Contains("!@#$%^&*"))
					{
						((ArrayList)htbValueArlUnitId["!@#$%^&*"]).Add(uv.UnitId);
					}
					else
					{
						ArrayList arl = new ArrayList();
						arl.Add(uv.UnitId);
						htbValueArlUnitId.Add("!@#$%^&*",arl);
					}
				}
			}

			foreach(UnitArlValue uv in arlUnitArlValue)
			{
				//区分属性值为单值的申请单元组与属性值为多值的申请单元组
				if(uv.arlValue.Count == 1)
				{
					if(htbValueArlUnitId.Contains(uv.arlValue[0].ToString()))
					{
						((ArrayList)htbValueArlUnitId[uv.arlValue[0].ToString()]).Add(uv.UnitId);
					}
					else
					{
						ArrayList arl = new ArrayList();
						arl.Add(uv.UnitId);
						htbValueArlUnitId.Add(uv.arlValue[0].ToString(),arl);
					}
				}
			}

			//分析属性值为多值的申请单元的分单
			foreach(UnitArlValue uv in arlUnitArlValue)
			{
				if(uv.arlValue.Count <= 1)
					continue;
				//对多个属性值做循环，与已有的属性值为单值的申请单元做比较，从而进行分单
				bool blnAdded = false;
				foreach( string strValue in uv.arlValue)
				{
					if ( htbValueArlUnitId.Contains(strValue) )
					{
						((ArrayList)htbValueArlUnitId[strValue]).Add(uv.UnitId);
						blnAdded = true;
						break;
					}
				}
				if(!blnAdded)
				{
					ArrayList arlTemp = new ArrayList();
					arlTemp.Add(uv.UnitId);
					htbValueArlUnitId.Add(uv.arlValue[0],arlTemp);
				}
			}
			ArrayList arl11 = new ArrayList();
			arl11.AddRange(htbValueArlUnitId.Values);
			return arl11;
		}
		/// <summary>
		/// 分单方法
		/// </summary>
		/// <param name="p_arlAppUnit">申请所包含的申请单元</param>
		/// <returns>分单结果集合</returns>
		public clsSeparatedApp[] m_mthSeparateCheckApplication(string[] p_arlAppUnit)
		{ 
			com.digitalwave.iCare.gui.LIS.clsDomainController_ApplyUnitProperty m_objSeparateApplyUnit = new clsDomainController_ApplyUnitProperty();

			ArrayList arlUnitArlValue = new ArrayList();
			
			string[] strPropertyIdArr = null;
			long lngRes = 0;
			try
			{
				lngRes = m_objSeparateApplyUnit.m_mthGetAllPropertyId(out strPropertyIdArr);//获取所有的属性

			}
			catch(Exception ex)
			{
			}

			if( lngRes > 0 && strPropertyIdArr != null )
			{
				ArrayList arlValueArlUnitId = new ArrayList();
				ArrayList arlTemp = new ArrayList();
				arlTemp.AddRange(p_arlAppUnit);
				arlValueArlUnitId.Add(arlTemp);

				foreach(string strPropertyId in strPropertyIdArr)		//循环属性
				{
					ArrayList arlResult = new ArrayList();
					foreach(ArrayList arl in arlValueArlUnitId)
					{
						ArrayList objarl = m_hasSeparate(strPropertyId,(string[])arl.ToArray(typeof(string)));
						arlResult.Add(objarl);
					}

					arlValueArlUnitId.Clear();

					foreach(ArrayList arlarl in arlResult)
					{
						arlValueArlUnitId.AddRange(arlarl);
					}
				}

				// Result in arlValueArlUnitId 

				clsSeparatedApp[] objApps = null;
				ArrayList arl1 = new ArrayList();
				foreach(ArrayList arl2 in arlValueArlUnitId)
				{
					clsSeparatedApp objApp = new clsSeparatedApp();
					objApp.m_strApplyUnits = (string[])arl2.ToArray(typeof(string));
					arl1.Add(objApp);
				}
				objApps = (clsSeparatedApp[])arl1.ToArray(typeof(clsSeparatedApp));
				return objApps;
			}
			else
			{
				clsSeparatedApp objApp = new clsSeparatedApp();
				objApp.m_strApplyUnits = p_arlAppUnit;
				clsSeparatedApp[] objApps = new clsSeparatedApp[1]{objApp};
				return objApps;
			}
		}


		//（申请单元，属性值组）结构		申请单元及其所属属性值集合
		private class UnitArlValue
		{
			public string UnitId = null;

			public ArrayList arlValue = new ArrayList();
		}

		/// <summary>
		/// 根据属性id、申请单元id获取（申请单元，属性值组）结构
		/// </summary>
		/// <param name="p_strPropertyId">属性id</param>
		/// <param name="p_strUnitId">申请单元id</param>
		/// <returns>（申请单元，属性值组）结构</returns>
		private UnitArlValue m_mthGetUnitArlValueByPropertyAndUnitId(string p_strPropertyId,string p_strUnitId)
		{
			UnitArlValue uv = new UnitArlValue() ;

			com.digitalwave.iCare.gui.LIS.clsDomainController_ApplyUnitProperty m_objSeparateApplyUnit = new com.digitalwave.iCare.gui.LIS.clsDomainController_ApplyUnitProperty();

			ArrayList arlPropertyValue = null;
			long lngRes = 0;
			try
			{
				lngRes = m_objSeparateApplyUnit.m_mthGetPropertyValue(p_strPropertyId,p_strUnitId,out arlPropertyValue);//
			}
			catch{}
			
			if( lngRes > 0 && arlPropertyValue != null )
			{
				uv.UnitId = p_strUnitId;
				uv.arlValue = arlPropertyValue;
			}	
			else
			{
				uv.UnitId = p_strUnitId;
				uv.arlValue = new ArrayList();
			}

			return uv;
		}
	}
	public class clsSeparatedApp
	{
		public string[] m_strApplyUnits;
	}
}
