using System;
using iCareData;
using com.digitalwave.emr.DigitalSign;//����ǩ��
using com.digitalwave.Emr.Signature_srv;
using System.Windows.Forms;
namespace com.digitalwave.Emr.Signature_gui
{
	/// <summary>
	/// clsDeleteVerify ��ժҪ˵����
	/// ɾ������֤
	/// ɾ������ȷ�Ϸ�ʽ��0������ȷ��ɾ��  1������ȷ��ɾ��
	/// ɾ������֤��ʽ��0������֤  1��������֤  2��key��֤  3��ָ����֤
	/// </summary>
	public class clsDeleteVerify
	{
		/// <summary>
		/// ɾ������֤
		/// </summary>
		/// <param name="p_objSignArr">ǩ���߼���</param>
		/// <param name="p_objOperator">�����߼���</param>
		/// <returns>���� false=������ɾ�� true=����ɾ��</returns>
		public bool m_mthIsDelete(clsEmrEmployeeBase_VO[] p_objSignArr,clsEmrEmployeeBase_VO p_objOperator)
		{
			bool blnReturn=false;
            if (p_objOperator==null|| p_objOperator==null)
            {
                MessageBox.Show("û�л�ȡ�㹻����֤��Ϣ�����ܼ������в���", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return blnReturn;
            }
			try
			{
				//ȷ�Ϸ�ʽ
                #region ��֤��ʽ
                string strReturnSetting = string.Empty;
                clsSignature_srv objServ =
                    (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                long lngRes = objServ.m_lngGetConfigBySettingID("3003", out strReturnSetting);
                //objServ.Dispose();
                if (strReturnSetting != null)
                {
                    switch (strReturnSetting)
                    {
                        case "0"://������֤
                            blnReturn = true; 
                            break;
                        case "1"://������֤
                            blnReturn = true; 
                            break;
                        case "2"://key����֤
                            //key������
                            clsDigitalSign objsign = new clsDigitalSign();
                            //��ȡ֤��
                            clsSignCert_VO objCert = new clsSignCert_VO();
                            long lngR = objsign.GetSpecifyCert(out objCert);
                            if (objCert == null)
                            {
                                MessageBox.Show("��ⲻ��Key�̡����ܼ������в���", "iCare Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                            //��鵱ǰ��������key�Ƿ�һ��
                            if (objsign.currentCerts.m_strSerialNumber.Trim()!=p_objOperator.m_strEMPKEY_VCHR.Trim())
                            {
                                blnReturn = false;
                                break;
                            }
                            //����ǩ��ʹ�������봰��
                            string strContentTemp = null;
                            strContentTemp = objsign.sign("1", 0);
                            if (strContentTemp == null)
                                blnReturn = false;
                            else
                                blnReturn = true; 
                            break;
                        case "3"://ָ����֤
                            blnReturn = true; 
                            break;
                        default:
                            blnReturn = true; 
                            break;

                    }
                }
                #endregion
				//��֤��ʽ

				
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
