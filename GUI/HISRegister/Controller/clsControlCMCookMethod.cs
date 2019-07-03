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
	/// clsControlCMCookMethod 的摘要说明。
	/// 作者： Cameron Wong
	/// 时间： Aug 9, 2004
	/// </summary>
	public class clsControlCMCookMethod : com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlCMCookMethod()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain = new clsDomainControl_RegDefine();
		}
		clsDomainControl_RegDefine clsDomain;

		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmCMCookMethod m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmCMCookMethod)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获取煎制方法列表
		public void m_GetCookMethod()
		{
			m_objViewer.m_lst.Items.Clear();
			clsCookMethod_VO[] objResult;
			long lngRes = clsDomain.m_lngFindCookMethodList(out objResult);
			if (lngRes > 0 && objResult.Length > 0)
			{
				ListViewItem lvw;
				for (int i1=0; i1 < objResult.Length; i1++)
				{
					lvw = new ListViewItem();
					lvw.SubItems.Add(objResult[i1].m_strCookMethodID);
					lvw.SubItems.Add(objResult[i1].m_strCookMethodName);
					lvw.SubItems.Add(objResult[i1].m_strMNemonic);
					lvw.Tag = objResult[i1].m_strCookMethodID;
					m_objViewer.m_lst.Items.Add(lvw);
				}
			}
			if (m_objViewer.m_lst.Items.Count > 0)
				m_objViewer.m_lst.Items[0].Selected = true;
		}
		#endregion

		#region 保存
		public void m_lngSave()
		{
			if (m_objViewer.m_txtCookMethodName.Text.Trim() == "")
			{
				MessageBox.Show("煎制名称不能为空！");
				return;
			}
			if (m_objViewer.m_txtMNemonic.Text.Trim() == "")
			{
				MessageBox.Show("缩写不能为空！");
				return;
			}

			long lngRes = 0;
			string strID = "";
			clsCookMethod_VO objResult = new clsCookMethod_VO();
			if (m_objViewer.m_txtCookMethodName.Tag == null) // 新增
			{
				lngRes = clsDomain.m_lngAddCookMethod(m_objViewer.m_txtCookMethodName.Text, m_objViewer.m_txtMNemonic.Text, out strID);
				if (lngRes > 0)
				{
					ListViewItem lti = new ListViewItem();
					lti.SubItems.Add(strID);
					lti.SubItems.Add(m_objViewer.m_txtCookMethodName.Text);
					lti.SubItems.Add(m_objViewer.m_txtMNemonic.Text);
					lti.Tag = strID;
					m_objViewer.m_lst.Items.Add(lti);
				}
			}
			else	// 修改
			{
				objResult.m_strCookMethodID = m_objViewer.m_txtCookMethodName.Tag.ToString();
				objResult.m_strCookMethodName = m_objViewer.m_txtCookMethodName.Text;  
				objResult.m_strMNemonic = m_objViewer.m_txtMNemonic.Text;
				lngRes = clsDomain.m_lngDoUpdMethodByID(objResult);
/*				if (lngRes > 0)
				{
					m_objViewer.m_lst.SelectedItems[0].SubItems[1].Text = m_objViewer.m_txtCookMethodName.Text;
					m_objViewer.m_lst.SelectedItems[0].SubItems[2].Text = m_objViewer.m_txtMNemonic.Text;
				}
*/			}
		}
		#endregion


		#region 删除煎制方法
		public void m_Delete()
		{
			if (m_objViewer.m_lst.Items.Count == 0 || m_objViewer.m_lst.SelectedItems == null)
				return;
			if (m_objViewer.m_lst.SelectedItems[0].Tag == null)
				return;
			if(MessageBox.Show("确认删除该项吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button2) == DialogResult.No)
				return;
			long lngRes = clsDomain.m_lngDelMethodByID(m_objViewer.m_lst.SelectedItems[0].Tag.ToString());
			if (lngRes > 0)
				m_objViewer.m_lst.Items.RemoveAt(m_objViewer.m_lst.SelectedItems[0].Index);
		}
		#endregion


	}
}