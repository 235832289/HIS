using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_HISInfoDefine 的摘要说明。
	/// </summary>
	public class clsCtl_HISInfoDefine :com.digitalwave.GUI_Base.clsController_Base
	{
		public clsCtl_HISInfoDefine()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain=new clsDcl_HISInfoDefine();
		}
		clsDcl_HISInfoDefine clsDomain;
		#region 设置窗体对象	张国良	 2004-8-8
		com.digitalwave.iCare.gui.HIS.frmHISInfoDefine m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmHISInfoDefine)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取医院基本信息	张国良		2004-8-12
		public void m_GetHospitalinfo()
		{
			
			clsHISInfoDefine_VO[] objResult;
			long lngRes=clsDomain.m_lngFindHospitalInfo(out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				m_objViewer.m_txtName.Text=objResult[0].m_strHOSPITAL_NAME_CHR;
				m_objViewer.m_txtAddress.Text=objResult[0].m_strADDRESS_VCHR;
				m_objViewer.m_txtPhone1.Text=objResult[0].m_strPHONE_NUMBER_CHR;
				m_objViewer.m_txtPhone2.Text=objResult[0].m_strPHONE_NUMBER2_CHR;
				m_objViewer.m_txtZIP.Text=objResult[0].m_strZIP_CHR;
				m_objViewer.m_txtMemo.Text=objResult[0].m_strMEMO_VCHR;
					
				
			}
		}
		#endregion

		#region 保存医院基本信息	张国良	 2004-8-12
		public void m_lngSaveHospitalinfo()
		{
			
			if(m_objViewer.m_txtName.Text.Trim()=="")
			{
				m_ephHandler.m_mthAddControl(m_objViewer.m_txtName);
				m_ephHandler.m_mthShowControlsErrorProvider();
				m_ephHandler.m_mthClearControl();
				return;
			}
			long lngRes=0;
			
			clsHISInfoDefine_VO objResult=new clsHISInfoDefine_VO();
			
				objResult.m_strHOSPITAL_NAME_CHR=m_objViewer.m_txtName.Text;
				objResult.m_strADDRESS_VCHR=m_objViewer.m_txtAddress.Text; 
				objResult.m_strPHONE_NUMBER_CHR=m_objViewer.m_txtPhone1.Text;
				objResult.m_strPHONE_NUMBER2_CHR=m_objViewer.m_txtPhone2.Text;
				objResult.m_strZIP_CHR=m_objViewer.m_txtZIP.Text; 
				objResult.m_strMEMO_VCHR=m_objViewer.m_txtMemo.Text;
				lngRes=clsDomain.m_lngDoUpdHospitalInfo(objResult);
				if(lngRes>0)
				{

					MessageBox.Show("保存成功！","提示");
					
				}
			else MessageBox.Show("保存失败！","提示");
			
		}
		#endregion

		
	}
}
