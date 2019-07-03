using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsContorlInput 的摘要说明。
	/// </summary>
	public class clsContorlInput  : com.digitalwave.GUI_Base.clsController_Base
	{
		/// <summary>
		/// jjj
		/// </summary>
		public clsContorlInput()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		private bool blcomm;
		clsDomainControlMedStore objcontrol=new clsDomainControlMedStore();
		frmInput m_objViewer;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmInput)frmMDI_Child_Base_in;
		}
		#endregion

		#region 判定员工工号
		public void Determinant()
		{
			if(this.m_objViewer.txtNo.Text!="")
			{
				string p_strName="";
				string empID="";
				string p_strID=this.m_objViewer.txtNo.Text.Trim();
				m_lngFineName(p_strID,out p_strName,out empID);
				if(p_strName=="")
				{
					blcomm=false;
					this.m_objViewer.txtname.Text="错误的员工号";
				}
				else
				{
					this.m_objViewer.txtNo.Tag=empID;
					blcomm=true;
					this.m_objViewer.txtname.Text=p_strName;
				}
				this.m_objViewer.m_cmdSave.Focus();
			}
			else
			{
				blcomm=false;
				this.m_objViewer.txtname.Text="工号不能为空";
				this.m_objViewer.txtname.Focus();
			}
		}
		#endregion

		#region 确定按钮事件
		public bool m_cmdSaveClick()
		{
		  return blcomm;
		}
		#endregion

		public void ShowForm()
		{
			m_objViewer.Show();
		}

		#region 查找员工名称
		public void m_lngFineName(string p_strID,out string p_strName,out string empID)
		{
            objcontrol.m_lngfinedata(p_strID,out p_strName,out empID);
		}
		#endregion
	}
}
