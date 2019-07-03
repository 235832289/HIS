using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;


namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 应用管理系统
	/// 作者： Cameron Wong
	/// 时间： Aug 12, 2004
	/// </summary>
	public class clsCtl_HISModuleDef : com.digitalwave.GUI_Base.clsController_Base
	{
		clsDcl_HISInfoDefine clsDomain;

		public clsCtl_HISModuleDef()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain = new clsDcl_HISInfoDefine();
		}

		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmHISModuleDef m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmHISModuleDef)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取应用管理系统列表
		/// <summary>
		/// 获取应用管理系统列表
		/// </summary>
		public void m_GetModule()
		{
			m_objViewer.m_lsv.Items.Clear();
			clsHISModuleDef_VO[] objResult;
			long lngRes = clsDomain.m_lngFindModuleList(out objResult);
			if (lngRes > 0 && objResult.Length > 0)
			{
				ListViewItem lvi;
				for (int i1 = 0; i1 < objResult.Length; i1++)
				{
					lvi = new ListViewItem();
					lvi.SubItems.Add(objResult[i1].m_strModuleID);
					lvi.SubItems.Add(objResult[i1].m_strModuleName);
					lvi.SubItems.Add(objResult[i1].m_strEngName);
					lvi.SubItems.Add(objResult[i1].m_strPYCode);
					lvi.SubItems.Add(objResult[i1].m_strWBCode);
					lvi.Tag = objResult[i1].m_strModuleID;
					m_objViewer.m_lsv.Items.Add(lvi);
				}
			}
			if (m_objViewer.m_lsv.Items.Count > 0)
				m_objViewer.m_lsv.Items[0].Selected = true;
		}
		#endregion

		#region 保存
		/// <summary>
		/// 保存
		/// </summary>
		public void m_lngSave()
		{
			long lngRes = 0;
			string strID = "";
			clsHISModuleDef_VO objResult = new clsHISModuleDef_VO();
			if (m_objViewer.m_txtModuleName.Tag == null) // 新增
			{
				lngRes = clsDomain.m_lngAddModule(m_objViewer.m_txtModuleName.Text, m_objViewer.m_txtEngName.Text, m_objViewer.m_txtPYCode.Text, m_objViewer.m_txtWBCode.Text, out strID);
			}
			else	// modify
			{
				objResult.m_strModuleID = m_objViewer.m_txtModuleName.Tag.ToString();
				objResult.m_strModuleName = m_objViewer.m_txtModuleName.Text;
				objResult.m_strEngName = m_objViewer.m_txtEngName.Text;
				objResult.m_strPYCode = m_objViewer.m_txtPYCode.Text;
				objResult.m_strWBCode = m_objViewer.m_txtWBCode.Text;
				lngRes = clsDomain.m_lngDoUpdModuleByID(objResult);
			}
		}
		#endregion

		#region 删除
		public void m_Delete()
		{
			if (m_objViewer.m_lsv.Items.Count == 0 || m_objViewer.m_lsv.SelectedItems == null)
				return;
			if (m_objViewer.m_lsv.SelectedItems[0].Tag == null)
				return;
			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.No)
				return;
			long lngRes = clsDomain.m_lngDelModuleByID(m_objViewer.m_lsv.SelectedItems[0].Tag.ToString());
		}
		#endregion


	}
}