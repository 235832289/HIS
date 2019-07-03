using System;
using System.Windows.Forms;
using com.digitalwave.emr.DigitalSign;//电子签名
using com.digitalwave.Emr.Signature_srv;
using iCareData;
namespace com.digitalwave.Emr.Signature_gui
{
	/// <summary>
	/// clsVerifySignersController 的摘要说明。
	/// 无痕迹修改验证签名者控制类
	/// </summary>
	public class clsVerifySignersController
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsVerifySignersController(object objviewer)
		{
			//设置viewer对象
			m_objViewer=(frmVerifySigners)objviewer;
		}
		#endregion

		#region 字段
		/// <summary>
		/// viewer对象
		/// </summary>
		private frmVerifySigners m_objViewer;
		 
		#endregion

		#region 方法
		/// <summary>
		/// /列出签名者
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
					lsvItem.SubItems.Add("请双击验证");
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
		/// 验证签名者
		/// </summary>
		public void m_mthVerifySiger()
		{
			try
			{
				m_objViewer.Cursor=System.Windows.Forms.Cursors.WaitCursor;
				if(m_objViewer.m_lsvItemList.Items.Count>0 && m_objViewer.m_lsvItemList.SelectedItems.Count > 0)
				{
					#region 验证方式 
					string strReturnSetting = string .Empty;
                    clsSignature_srv objServ =
                        (clsSignature_srv)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(clsSignature_srv));

                    long lngRes = objServ.m_lngGetConfigBySettingID("3002", out strReturnSetting);
                    //objServ.Dispose();
					if (strReturnSetting!=null)
					{
						switch (strReturnSetting)
						{
							case "0"://无需验证
								break;
							case "1"://密码验证
								if(!m_blnCheckEmployeeSignByPwd(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text))
									return;
								break;
							case "2"://key盘验证
								if (!m_blnCheckEmployeeSignByKey(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text))
									return;
								break;
							case "3"://指纹验证
								if (!m_blnCheckEmployeeSignByFinger(m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[5].Text,m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[0].Text))
									return;
								break;
							default:
								break;

						}
					}
					#endregion

					m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[2].Text="通过";

				}

			}
			finally
			{
				m_objViewer.Cursor=System.Windows.Forms.Cursors.Default;
                
			}		
		}
		/// <summary>
		/// 退出确认验证
		/// </summary>
		public void m_mthComfirm()
		{
			for (int i=0; i<m_objViewer.m_lsvItemList.Items.Count;i++ )
			{
				if (m_objViewer.m_lsvItemList.Items[i].SubItems[2].Text.Trim()!="通过")
				{
					m_objViewer.blnIsPass=false;
					return;
				}
			}
			//执行到这里默认都认为通过验证
			m_objViewer.blnIsPass=true;

		}
		/// <summary>
		/// key盘验证签名者
		/// 适用于选择签名的时候使用
		/// </summary>
		/// <param name="p_strEmployeeID"></param>
		/// <param name="p_strEmployeeName"></param>
		/// <returns></returns>
		private bool m_blnCheckEmployeeSignByKey(string p_strEmployeeID,string p_strEmployeeName)
		{
			try
			{
				//key操作类
				clsDigitalSign objsign=new clsDigitalSign();
				//获取证书
				clsSignCert_VO objCert=new clsSignCert_VO();
				long lngR=objsign.GetSpecifyCert(out objCert);
				if (objCert==null)
				{
					MessageBox.Show("检测不到Key盘。不能继续进行操作","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;
				}

				//先验证是否签名者的Key
				if (m_objViewer.m_lsvItemList.SelectedItems[0].SubItems[4].Text.Trim()!=objCert.m_strSerialNumber.Trim())
				{
					MessageBox.Show("检测到key盘证书和指定的签名者不一致，不能通过验证","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;				
				}

				//虚拟签名使弹出密码窗口
				string strContentTemp=null;
				strContentTemp=objsign.sign("1",0);
				if (strContentTemp==null)
				{
					MessageBox.Show("key盘校验失败，请确认已插入key盘!","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
					return false;
				}

				//返回
				return true;	
			}
			catch(Exception exp)
			{
				com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
				bool blnRes = objLogger.LogError(exp);
				MessageBox.Show("未能检测到key盘,确认是否插入key盘","iCare Message", MessageBoxButtons.OK,MessageBoxIcon.Information);
				return false;
			}
			 
		}

		/// <summary>
		/// 密码验证签名者
		/// 适用于选择签名的时候使用
		/// </summary>
		/// <param name="p_strEmployeeID"></param>
		/// <param name="p_strEmployeeName"></param>
		/// <returns></returns>
		private bool m_blnCheckEmployeeSignByPwd(string p_strEmployeeID,string p_strEmployeeName)
		{
			try
			{
				//未实现

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
		/// 指纹验证签名者
		/// 适用于选择签名的时候使用
		/// </summary>
		/// <param name="p_strEmployeeID"></param>
		/// <param name="p_strEmployeeName"></param>
		/// <returns></returns>
		private bool m_blnCheckEmployeeSignByFinger(string p_strEmployeeID,string p_strEmployeeName)
		{
			try
			{
				//未实现
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
