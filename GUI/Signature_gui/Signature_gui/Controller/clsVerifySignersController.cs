using System;
using System.Windows.Forms;
using com.digitalwave.emr.DigitalSign;//����ǩ��
using com.digitalwave.Emr.Signature_srv;
using iCareData;
namespace com.digitalwave.Emr.Signature_gui
{
	/// <summary>
	/// clsVerifySignersController ��ժҪ˵����
	/// �޺ۼ��޸���֤ǩ���߿�����
	/// </summary>
	public class clsVerifySignersController
	{
		#region ���캯��
		/// <summary>
		/// ���캯��
		/// </summary>
		public clsVerifySignersController(object objviewer)
		{
			//����viewer����
			m_objViewer=(frmVerifySigners)objviewer;
		}
		#endregion

		#region �ֶ�
		/// <summary>
		/// viewer����
		/// </summary>
		private frmVerifySigners m_objViewer;
		 
		#endregion

		#region ����
		/// <summary>
		/// /�г�ǩ����
		/// </summary>
		public void m_mthListSigners()
		{
			try
			{
				m_objViewer.m_lsvItemList.Items.Clear();
				m_objViewer.m_lsvItemList.BeginUpdate();
				for (int i = 0; i <m_objViewer.objSignerArr.Count; i++)
				{
					clsEmrEmployeeBase_VO objVO=new clsEmrEmployeeBase_VO();
					objVO=(clsEmrEmployeeBase_VO)(m_objViewer.objSignerArr[i]);
					ListViewItem lsvItem = new ListViewItem(objVO.m_strLASTNAME_VCHR.Trim());
					lsvItem.SubItems.Add(objVO.m_strTECHNICALRANK_CHR.Trim());
					lsvItem.SubItems.Add("��˫����֤");
					lsvItem.SubItems.Add(objVO.m_strEMPPWD_VCHR.Trim());
					lsvItem.SubItems.Add(objVO.m_strEMPKEY_VCHR.Trim());
					lsvItem.SubItems.Add(objVO.m_strEMPID_CHR.Trim());
					m_objViewer.m_lsvItemList.Items.Add(lsvItem);
				}
				if (m_objViewer.m_lsvItemList.Items.Count>1)
					m_objViewer.m_lsvItemList.Items[0].Selected=true;
			}
			finally
			{
				m_objViewer.m_lsvItemList.EndUpdate();
			}
		}
		/// <summary>
		/// ��֤ǩ����
		/// </summary>
		public void m_mthVerifySiger()
		{
			try
			{
				m_objViewer.Cursor=System.Windows.Forms.Cursors.WaitCursor;
				if(m_objViewer.m_lsvItemList.Items.Count>0 && m_objViewer.m_lsvItemList.SelectedItems.Count > 0)
				{
					#region ��֤��ʽ 
					string strReturnSetting = string .Empty;
                    clsSignature_srv objServ =
                        (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                    long lngRes = objServ.m_lngGetConfigBySettingID("3002", out strReturnSetting);
                    //objServ.Dispose();
					if (strReturnSetting!=null)
					{
						switch (strReturnSetting)
						{
							case "0"://������֤
								break;
							case "1"://������֤
								if(!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text))
									return;
								break;
							case "2"://key����֤
								if (!m_blnCheckEmployeeSignByKey(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text))
									return;
								break;
							case "3"://ָ����֤
								if (!m_blnCheckEmployeeSignByFinger(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text))
									return;
								break;
							default:
								break;

						}
					}
					#endregion

					m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[2].Text="ͨ��";

				}

			}
			finally
			{
				m_objViewer.Cursor=System.Windows.Forms.Cursors.Default;
                
			}		
		}
		/// <summary>
		/// �˳�ȷ����֤
		/// </summary>
		public void m_mthComfirm()
		{
			for (int i=0; i<m_objViewer.m_lsvItemList.Items.Count;i++ )
			{
				if (m_objViewer.m_lsvItemList.Items[i].SubItems[2].Text.Trim()!="ͨ��")
				{
					m_objViewer.blnIsPass=false;
					return;
				}
			}
			//ִ�е�����Ĭ�϶���Ϊͨ����֤
			m_objViewer.blnIsPass=true;

		}
		/// <summary>
		/// key����֤ǩ����
		/// ������ѡ��ǩ����ʱ��ʹ��
		/// </summary>
		/// <param name="p_strEmployeeID"></param>
		/// <param name="p_strEmployeeName"></param>
		/// <returns></returns>
		private bool m_blnCheckEmployeeSignByKey(string p_strEmployeeID,string p_strEmployeeName)
		{
			try
			{
				//key������
				clsDigitalSign objsign=new clsDigitalSign();
				//��ȡ֤��
				clsSignCert_VO objCert=new clsSignCert_VO();
				long lngR=objsign.GetSpecifyCert(out objCert);
				if (objCert==null)
				{
					MessageBox.Show("��ⲻ��Key�̡����ܼ������в���","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;
				}

				//����֤�Ƿ�ǩ���ߵ�Key
				if (m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text.Trim()!=objCert.m_strSerialNumber.Trim())
				{
					MessageBox.Show("��⵽key��֤���ָ����ǩ���߲�һ�£�����ͨ����֤","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;				
				}

				//����ǩ��ʹ�������봰��
				string strContentTemp=null;
				strContentTemp=objsign.sign("1",0);
				if (strContentTemp==null)
				{
					MessageBox.Show("key��У��ʧ�ܣ���ȷ���Ѳ���key��!","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;
				}

				//����
				return true;	
			}
			catch(Exception exp)
			{
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				bool blnRes = objLogger.LogError(exp);
				MessageBox.Show("δ�ܼ�⵽key��,ȷ���Ƿ����key��","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}
			 
		}

		/// <summary>
		/// ������֤ǩ����
		/// ������ѡ��ǩ����ʱ��ʹ��
		/// </summary>
		/// <param name="p_strEmployeeID"></param>
		/// <param name="p_strEmployeeName"></param>
		/// <returns></returns>
		private bool m_blnCheckEmployeeSignByPwd(string p_strEmployeeID,string p_strEmployeeName)
		{
			try
			{
				//δʵ��

				return false;
			}
			catch (Exception exp)
			{
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				bool blnRes = objLogger.LogError(exp);
				return false;
			}
			
		}

		/// <summary>
		/// ָ����֤ǩ����
		/// ������ѡ��ǩ����ʱ��ʹ��
		/// </summary>
		/// <param name="p_strEmployeeID"></param>
		/// <param name="p_strEmployeeName"></param>
		/// <returns></returns>
		private bool m_blnCheckEmployeeSignByFinger(string p_strEmployeeID,string p_strEmployeeName)
		{
			try
			{
				//δʵ��
				return false;
			}
			catch (Exception exp)
			{
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				bool blnRes = objLogger.LogError(exp);
				return false;
			}
			
		}		

		#endregion
	}
}
