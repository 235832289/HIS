using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_ItemCatMapping 的摘要说明。
	/// </summary>
	public class clsCtl_ItemCatMapping:com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_ItemCatMapping objSvc=null;
		public clsCtl_ItemCatMapping()
		{
			objSvc=new clsDcl_ItemCatMapping();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmItemCatMapping m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmItemCatMapping)frmMDI_Child_Base_in;
		}
		#endregion
		#region 加载主listview的选项
		public void m_mthLoadMainListViewItem()
		{
			m_objViewer.listView2.Items.Clear();
			clsChargeItemEXType_VO[] objResult;
			long lngRes=objSvc.m_mthLoadMainListViewItem(out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					lvw=new ListViewItem(objResult[i1].m_strTypeName);
					lvw.Tag=objResult[i1].m_strTypeID;
					m_objViewer.listView2.Items.Add(lvw);
				}
				m_objViewer.listView1.Items[0].Selected=true;
				m_objViewer.listView1.Focus();

			}
		
		}
		#endregion
		#region 获得隶属分类
		public void m_mthGetSubjectionCat()
		{
			if(this.m_objViewer.btOK.Tag==null)
			{
			return;
			}
			DataTable dt;
			long strRet =objSvc.m_mthGetSubjectionCat(out dt,this.m_objViewer.btOK.Tag.ToString().Trim(),this.m_objViewer.cmbCatType.SelectedIndex);
			for(int ii=0;ii<this.m_objViewer.listView2.Items.Count;ii++)
			{
				this.m_objViewer.listView2.Items[ii].Checked=false;
			}
			if(strRet>0&&dt.Rows.Count>0)
			{
				for(int i=0;i<dt.Rows.Count;i++)
				{
					this.m_mthSetCheckState(dt.Rows[i][0].ToString().Trim());
				}
			}
			
		
		}
		private void m_mthSetCheckState(string strCatMappingID)
		{
			for(int i=0;i<this.m_objViewer.listView2.Items.Count;i++)
			{
				if(this.m_objViewer.listView2.Items[i].Tag==null)
				{
				this.m_objViewer.listView2.Items[i].Checked=false;
					continue;
				}
				else
				{
					if(strCatMappingID==this.m_objViewer.listView2.Items[i].Tag.ToString().Trim())
					{
						this.m_objViewer.listView2.Items[i].Checked=true;
						
					}
					
				}
			}
		}
		#endregion
		#region 保存数据
		
		public void m_mthSaveData()
		{
			if(this.m_objViewer.btOK.Tag==null)
			{
			MessageBox.Show("不能保存,Tag属性为空!");
			return;
			}
			clsItemCatMapping_VO[] ICM_VO =new clsItemCatMapping_VO[this.m_objViewer.listView2.CheckedItems.Count];
			
			for(int i =0;i<this.m_objViewer.listView2.CheckedItems.Count;i++)
			{
				ICM_VO[i]=new clsItemCatMapping_VO();
				if(this.m_objViewer.listView2.CheckedItems[i].Tag!=null)
				{
					ICM_VO[i].m_strCatMappingID=this.m_objViewer.listView2.CheckedItems[i].Tag.ToString().Trim();
				}
			}
			long l =objSvc.m_mthSaveData(ICM_VO,this.m_objViewer.btOK.Tag.ToString().Trim(),this.m_objViewer.cmbCatType.SelectedIndex);
			if(l>0)
			{
			MessageBox.Show("保存成功!");
			}
		}
		#endregion

	}
}
