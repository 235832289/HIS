using System;
using iCareData;
using com.digitalwave.emr.DigitalSign;//电子签名
using com.digitalwave.Emr.Signature_srv;
using System.Windows.Forms;
namespace com.digitalwave.Emr.Signature_gui
{
	/// <summary>
	/// clsDeleteVerify 的摘要说明。
	/// 删除表单验证
	/// 删除表单据确认方式：0－单人确认删除  1－多人确认删除
	/// 删除表单验证方式：0－无验证  1－密码验证  2－key验证  3－指纹验证
	/// </summary>
	public class clsDeleteVerify
	{
		/// <summary>
		/// 删除表单验证
		/// </summary>
		/// <param name="p_objSignArr">签名者集合</param>
		/// <param name="p_objOperator">操作者集合</param>
		/// <returns>返回 false=不可以删除 true=可以删除</returns>
		public bool m_mthIsDelete(clsEmrEmployeeBase_VO[] p_objSignArr,clsEmrEmployeeBase_VO p_objOperator)
		{
			bool blnReturn=false;
            if (p_objOperator==null|| p_objOperator==null)
            {
                MessageBox.Show("没有获取足够的验证信息，不能继续进行操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return blnReturn;
            }
			try
			{
				//确认方式
                #region 验证方式
                string strReturnSetting = string.Empty;
                clsSignature_srv objServ =
                    (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                long lngRes = objServ.m_lngGetConfigBySettingID("3003", out strReturnSetting);
                //objServ.Dispose();
                if (strReturnSetting != null)
                {
                    switch (strReturnSetting)
                    {
                        case "0"://无需验证
                            blnReturn = true; 
                            break;
                        case "1"://密码验证
                            blnReturn = true; 
                            break;
                        case "2"://key盘验证
                            //key操作类
                            clsDigitalSign objsign = new clsDigitalSign();
                            //获取证书
                            clsSignCert_VO objCert = new clsSignCert_VO();
                            long lngR = objsign.GetSpecifyCert(out objCert);
                            if (objCert == null)
                            {
                                MessageBox.Show("检测不到Key盘。不能继续进行操作", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            //检查当前操作者与key是否一致
                            if (objsign.currentCerts.m_strSerialNumber.Trim()!=p_objOperator.m_strEMPKEY_VCHR.Trim())
                            {
                                blnReturn = false;
                                break;
                            }
                            //虚拟签名使弹出密码窗口
                            string strContentTemp = null;
                            strContentTemp = objsign.sign("1", 0);
                            if (strContentTemp == null)
                                blnReturn = false;
                            else
                                blnReturn = true; 
                            break;
                        case "3"://指纹验证
                            blnReturn = true; 
                            break;
                        default:
                            blnReturn = true; 
                            break;

                    }
                }
                #endregion
				//验证方式

				
			}
			catch(Exception exp)
			{
				blnReturn=false;
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				bool blnRes = objLogger.LogError(exp);

			}
			return blnReturn;

		}
	}
}
