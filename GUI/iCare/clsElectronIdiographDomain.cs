using System;
using System.Collections;
using com.digitalwave.AssistantToolService;
using System.Data;
using System.Windows.Forms;
using ctlSecurForm;

namespace iCare
{
	/// <summary>
	/// 电子签名使用类
	/// </summary>
	public class clsElectronIdiographDomain
	{
        //private clsElectronIdiograph m_objElectronIdiograph;

		/// <summary>
		/// 签名结果保存对象。
		/// </summary>
		private Hashtable m_hasIdiographResult;

		/// <summary>
		/// 使用此对象的当前窗体。
		/// </summary>
		private string m_strFormName ="";

		private ctlSecurForm.ctlSecurForm objSecurForm;

		/// <summary>
		///  构造1
		/// </summary>
		/// <param name="p_strFormName">使用此对象得当前窗体</param>
		public clsElectronIdiographDomain(string p_strFormName)
		{
            //m_objElectronIdiograph = new clsElectronIdiograph();
			m_hasIdiographResult = new Hashtable();
			
			objSecurForm = new ctlSecurForm.ctlSecurForm();


			if (p_strFormName != null)
				m_strFormName = p_strFormName;
		}

		/// <summary>
		/// 签名结果
		/// </summary>
		public Hashtable MP_HasIdiographResult
		{
			get{return m_hasIdiographResult;}
		}

		/// <summary>
		/// 通过运算得到电子签名(两个ArrayList的个数要相同)
		/// </summary>
		/// <param name="p_strInPatientID">病人住院号</param>
		/// <param name="p_strInPatientDate">病人住院日期</param>
		/// <param name="p_altIdiographObject">需要签名对象集合</param>
		/// <param name="p_altIdiographObjectContent">需要签名对象的内容集合</param>
		public void m_mthGetIdiograph(ArrayList p_altIdiographObject,ArrayList p_altIdiographObjectContent)
		{
			m_hasIdiographResult.Clear();

			if (p_altIdiographObject == null)
				return;

			for (int i=0;i<p_altIdiographObject.Count;i++)
			{
				#region 获取签名调用方法
				//((Control)p_altIdiographObject).Text
				string strIdiograph = objSecurForm.sign(p_altIdiographObjectContent[i].ToString(),false);
				#endregion 获取签名调用方法

				m_hasIdiographResult.Add(p_altIdiographObject[i].ToString(),strIdiograph);
			}
		}


		/// <summary>
		/// 得到数据库中对应项目的签名
		/// </summary>
		/// <param name="p_strInPatientID">病人住院号</param>
		/// <param name="p_strInPatientDate">病人住院日期</param>
		/// <param name="p_altIdiographObject">需要查询签名对象集合(字符串类型)</param>
		public void m_mthGetIdiograph(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate,ArrayList p_altIdiographObject)
		{
			m_hasIdiographResult.Clear();

			string strKey = m_strFormName + "_" + p_strInPatientID + "_" + p_strInPatientDate + "_" + p_strOpenDate ;

			DataTable dtRecord = null;

            clsElectronIdiograph m_objElectronIdiograph =
                (clsElectronIdiograph)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsElectronIdiograph));

			m_objElectronIdiograph.m_lngGetIdiographResultArry(strKey,ref dtRecord);

			if (dtRecord != null)
			{
				for (int i=0;i<dtRecord.Rows.Count;i++)
				{
					for (int j=0;j<p_altIdiographObject.Count;j++)
					{
						if (dtRecord.Rows[i]["SIGN_ID_VCHR"].ToString().ToUpper() == (strKey.ToUpper() + "_" + p_altIdiographObject[j].ToString().ToUpper()))
						{
							m_hasIdiographResult.Add(p_altIdiographObject[i].ToString(),dtRecord.Rows[i]["SIGN_DATA_VCHR"].ToString());
							break;
						}
					}
				}
			}
		}

		public long m_lngSaveIdiographResultArry(string p_strInPatientID,string p_strInPatientDate,string p_strOpenDate)
		{
			ArrayList altkey = new ArrayList();
			ArrayList altIdiographResult = new ArrayList();
			string[] strarrykey = new string[m_hasIdiographResult.Keys.Count]; 
			m_hasIdiographResult.Keys.CopyTo(strarrykey,0);

			for (int i=0;i<strarrykey.Length;i++)
			{
				string strkey = m_strFormName + "_" + p_strInPatientID + "_" + p_strInPatientDate + "_" + p_strOpenDate + "_" + strarrykey[i];
				string strIdiographResult = m_hasIdiographResult[strarrykey[i]].ToString();
				altkey.Add(strkey);
				altIdiographResult.Add(strIdiographResult);
			}

            clsElectronIdiograph m_objElectronIdiograph =
                (clsElectronIdiograph)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsElectronIdiograph));

			return m_objElectronIdiograph.m_lngSaveIdiographResultArry(altkey,altIdiographResult);
		}

		/// <summary>
		/// 验证签名
		/// </summary>
		/// <param name="p_altIdiographObject">需要验证签名的控件对象名称</param>
		/// <returns></returns>
		public bool m_blnValidateIdiograph(ArrayList p_altIdiographObject,ArrayList p_altIdiographObjectContent)
		{
			for (int i=0;i<p_altIdiographObject.Count;i++)
			{
				#region 获取签名调用方法
//				string strIdiograph = "AAAAAAAAAAAAAAAAAA";
				#endregion 获取签名调用方法

				//string strOldIdiograph = m_hasIdiographResult[((Control)p_altIdiographObject[i]).Name].ToString();
				string strOldIdiograph = m_hasIdiographResult[p_altIdiographObject[i].ToString()].ToString();

//				if (strIdiograph != strOldIdiograph)
//					return false;

				//return objSecurForm.verify(strOldIdiograph,((Control)p_altIdiographObject[i]).Text,false);
				return objSecurForm.verify(p_altIdiographObjectContent[i].ToString(),strOldIdiograph,false);
				
			}

			return true;
		}

	}
}
