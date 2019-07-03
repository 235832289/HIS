using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// ctlLISReportsComboBox 的摘要说明。
	/// 刘彬 2004.06.29
	/// </summary>
	public class ctlLISReportsComboBox : System.Windows.Forms.ComboBox
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ctlLISReportsComboBox()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();			

			// TODO: 在 InitializeComponent 调用后添加任何初始化
		}

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		protected override void OnCreateControl()
		{
			base.OnCreateControl ();
			try
			{
				//				com.digitalwave.iCare.ValueObject.clsReportGroup_VO objReportVO = new com.digitalwave.iCare.ValueObject.clsReportGroup_VO();
				//				this.Items.Add(objReportVO);
//				com.digitalwave.iCare.ValueObject.clsReportGroup_VO[] objReportVOArr = null;
//				new clsDomainController_LisCheckGroupManage().m_lngGetAllReportGroup(out objReportVOArr);
//				this.Items.AddRange(objReportVOArr);
			}
			catch
			{
			}
		}

		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "ctlLISReportsComboBox1";
			this.Size = new System.Drawing.Size(120, 21);
		}
		#endregion
	}
}