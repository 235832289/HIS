using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// ctlLISSampleTypeComboBox 的摘要说明。
	/// 刘彬 2004.06.29
	/// </summary>
	public class ctlLISSampleTypeComboBox : System.Windows.Forms.ComboBox
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ctlLISSampleTypeComboBox()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();

			// TODO: 在 InitializeComponent 调用后添加任何初始化
			m_mthGetData();
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


		private void m_mthGetData()
		{
//			base.OnCreateControl ();

			try
			{
				DataTable dtbSampleType = null;
				new clsDomainController_SampleManage().m_lngGetSampleTypeList(out dtbSampleType);
				if(dtbSampleType != null)
				{				
					this.DataSource = dtbSampleType;
					this.DisplayMember = "SAMPLE_TYPE_DESC_VCHR";
					this.ValueMember = "SAMPLE_TYPE_ID_CHR";
				}
			}
			catch
			{
				this.DataSource = null;
				this.DisplayMember = null;
				this.ValueMember = null;
			}
		}

		public string m_strGetTypeName(string p_strTypeID)
		{
			if(this.DataSource != null)
			{
				foreach(DataRow dtr in ((DataTable)this.DataSource).Rows)
				{
					if(dtr["SAMPLE_TYPE_ID_CHR"].ToString() == p_strTypeID)
						return dtr["SAMPLE_TYPE_DESC_VCHR"].ToString();
				}
			}
			return null;
		}
		#region 组件设计器生成的代码
		/// <summary> 
		/// 设计器支持所需的方法 - 不要使用代码编辑器 
		/// 修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.Name = "UserControl1";
			this.Size = new System.Drawing.Size(120, 21);
		}
		#endregion
	}
}