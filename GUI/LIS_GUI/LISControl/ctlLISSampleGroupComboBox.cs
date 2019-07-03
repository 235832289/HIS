using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
	/// <summary>
	/// ctlLISSampleGroupComboBox 的摘要说明。
	/// 刘彬 2004.06.29
	/// </summary>
	public class ctlLISSampleGroupComboBox : System.Windows.Forms.ComboBox
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.Container components = null;

		public ctlLISSampleGroupComboBox()
		{
			// 该调用是 Windows.Forms 窗体设计器所必需的。
			InitializeComponent();
			try
			{
				DataTable dtbSampleGroup = null;
				new clsDomainController_SampleGroupManage().m_lngGetSampleGroupList(null,null,out dtbSampleGroup);
				if(dtbSampleGroup != null)
				{
					m_mthAddNullData(dtbSampleGroup);
					this.DataSource = dtbSampleGroup;
					this.DisplayMember = "SAMPLE_GROUP_NAME_CHR";
					this.ValueMember = "SAMPLE_GROUP_ID_CHR";
				}
			}
			catch
			{
				this.DataSource = null;
				this.DisplayMember = null;
				this.ValueMember = null;
			}

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


		public void m_mthShowStateByCategoryAndType(string p_strCategoryID,string p_strSampleTypeID)
		{
			DataTable dtbSampleGroup = null;
			this.SuspendLayout();
//			this.DataSource = null;
//			this.DisplayMember = null;
//			this.ValueMember = null;
			
			try
			{
				new clsDomainController_SampleGroupManage().m_lngGetSampleGroupList(p_strCategoryID,p_strSampleTypeID,out dtbSampleGroup);
				if(dtbSampleGroup != null)
				{
					m_mthAddNullData(dtbSampleGroup);
					this.DataSource = dtbSampleGroup;
					this.DisplayMember = "SAMPLE_GROUP_NAME_CHR";
					this.ValueMember = "SAMPLE_GROUP_ID_CHR";
				}
			}
			catch
			{
				this.DataSource = null;
				this.DisplayMember = null;
				this.ValueMember = null;
			}
			this.ResumeLayout();
		}
		
		private void m_mthAddNullData(DataTable p_dtbTable)
		{
            DataRow dtr = p_dtbTable.NewRow();
			p_dtbTable.Rows.InsertAt(dtr,0);
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