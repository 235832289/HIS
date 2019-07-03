using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using System.Collections;

namespace com.digitalwave.iCare.BIHOrder
{
	/// <summary>
	/// 手工执行连续医嘱滚费	逻辑控制层
	/// 作者： 徐斌辉
	/// 创建时间： 2005-04-18
	/// </summary>
	public class clsCtl_HandworkContinuousOrder: com.digitalwave.GUI_Base.clsController_Base
	{
		#region 变量
		clsDcl_ExecuteOrder m_objManage = null;
		public string m_strReportID;
		/// <summary>
		/// 操作人ID
		/// </summary>
		public string m_strOperatorID;
		/// <summary>
		/// 操作人
		/// </summary>
		public string m_strOperatorName;
		#endregion 
		#region 构造函数
		public clsCtl_HandworkContinuousOrder()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDcl_ExecuteOrder();
			m_strReportID = null;
		}
		#endregion 
		#region 设置窗体对象
		com.digitalwave.iCare.BIHOrder.frmHandworkContinuousOrder m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmHandworkContinuousOrder)frmMDI_Child_Base_in;
		}
		#endregion
		#region 清空
		/// <summary>
		/// 清空ListView
		/// </summary>
		private void ClearListView()
		{
			
		}
		#endregion
		#region 窗体事件
		/// <summary>
		/// 载入连续性医嘱的滚费信息	{业务说明: }
		/// </summary>
		public void m_LoadMoneyForContinuousOrder()
		{
			ClearListView();
		}
		#endregion

		#region 按钮事件
		/// <summary>
		/// 滚费
		/// </summary>
		public void m_AutoCumulateMoneyForContinuousOrder()
		{
			//获取滚费时间
			string strAuto =m_objViewer.m_dtpAuto.Value.ToString("yyyy-MM-dd") + " 23:59:59";
			DateTime dtAuto =System.Convert.ToDateTime(strAuto);

			//验证是否可以滚费	｛只能手工滚今天以前的的费用｝
			if(!blnValidateCumulateMoney(dtAuto)) return;

			if(MessageBox.Show(m_objViewer,"确定手工对“" +dtAuto.ToString("yyyy年MM月dd日")+ "”作滚费操作吗？\r\n提示:已经滚费，则不计费！","提示框！",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				return;			
			long lngRes =m_objManage.m_lngAuToCumulateMoneyForContinuousOrder(m_strOperatorName,m_strOperatorID,dtAuto);
			if(lngRes>0)
			{
				if(lngRes==999)
				{
					MessageBox.Show(m_objViewer,"没有需要滚费的连续医嘱或已经滚过费了！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(m_objViewer,"滚费成功！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show(m_objViewer,"滚费失败！","提示框！",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		/// <summary>
		/// 验证是否可以滚费	｛只能对过去的日期作滚费操作｝
		/// </summary>
		/// <param name="p_dtAuToExecDataTime">执行时间</param>
		/// <returns></returns>
		private bool blnValidateCumulateMoney(DateTime p_dtAuToExecDataTime)
		{
			if(p_dtAuToExecDataTime>System.DateTime.Now)
			{
				MessageBox.Show(m_objViewer,"只能对过去的日期作滚费操作！","警告！",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				return false;
			}
			return true;
		}
		#endregion
	}
}
