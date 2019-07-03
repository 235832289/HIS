using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// ȫԺ�����������ͳ�ơ���������Ʋ�
	/// ���ߣ� ����
	/// ����ʱ�䣺 2004-09-23
	/// </summary>
	public class clsCtl_StatHospitalPatientFlow: com.digitalwave.GUI_Base.clsController_Base
	{
		#region ����
		clsDcl_BedAdmin m_objBedAdmin = null;
		clsDcl_Register m_objRegister = null;
		public string m_strReportID;
		public string m_strOperatorID;
		#endregion 

		#region ���캯��
		public clsCtl_StatHospitalPatientFlow()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
			m_objBedAdmin =new clsDcl_BedAdmin();
			m_objRegister = new clsDcl_Register();
			m_strReportID = null;
			m_strOperatorID = "0000001";
		}
		#endregion 

		#region ���ô������
		com.digitalwave.iCare.gui.HIS.frmStatHospitalPatientFlow m_objViewer;
		/// <summary>
		/// ���ô������
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmStatHospitalPatientFlow)frmMDI_Child_Base_in;
		}
		#endregion
	}
}
