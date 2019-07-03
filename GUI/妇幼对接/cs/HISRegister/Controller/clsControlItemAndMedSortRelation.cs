using System;
using System.Windows.Forms;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlItemAndMedSortRelation 的摘要说明。
	/// </summary>
	public class clsControlItemAndMedSortRelation:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlItemAndMedSortRelation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象		
		com.digitalwave.iCare.gui.HIS.frmItemAndMedSortRelation m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmItemAndMedSortRelation)frmMDI_Child_Base_in;			
		}
		#endregion

		private System.Data.DataTable m_dtRelation = null;
		private System.Data.DataTable m_dtDel = null;
		clsDomainControlItemAndMedSortRel objSvc = new clsDomainControlItemAndMedSortRel();

		#region 初始化
		public void InitFrm()
		{		
			InitCmbItem();
			InitLvRelation();
		}
	
		private void InitCmbItem()
		{
			this.m_objViewer.comboBox2.Item.Add("","");
			this.m_objViewer.comboBox1.Item.Add("","");
			this.m_objViewer.m_cmbMedSort.Item.Add("","");
			System.Data.DataTable dt = null;
			System.Data.DataTable dt1 = null;
			System.Data.DataTable dt2 = null;
			System.Data.DataTable dt3 = null;
			objSvc.m_lngGetFeeSort(out dt,out dt1,out dt2,out dt3);
			if(dt.Rows.Count>0)
			{
				for(int i1=0;i1<dt.Rows.Count;i1++)
				{
					this.m_objViewer.m_cmbMedSort.Item.Add(dt.Rows[i1]["ITEMCATNAME_VCHR"].ToString(),dt.Rows[i1]["ITEMCATID_CHR"].ToString());
				}
			}
			if(dt2.Rows.Count>0)
			{
				for(int i1=0;i1<dt2.Rows.Count;i1++)
				{
					this.m_objViewer.comboBox2.Item.Add(dt2.Rows[i1]["MEDSTORENAME_VCHR"].ToString(),dt2.Rows[i1]["MEDSTOREID_CHR"].ToString());
				}
			}
			if(dt3.Rows.Count>0)
			{
				for(int i1=0;i1<dt3.Rows.Count;i1++)
				{
					this.m_objViewer.comboBox1.Item.Add(dt2.Rows[i1]["MEDSTORENAME_VCHR"].ToString(),dt2.Rows[i1]["MEDSTOREID_CHR"].ToString());
				}
			}

		}
		private void InitLvRelation()
		{			
			objSvc.m_lngGetFeeAndMedSortRel(out m_dtRelation);			
			this.m_objViewer.m_dgRelation.m_mthSetDataTable(m_dtRelation);
		}
		#endregion 初始化

		#region 增加关联
		public void AddRelation()
		{
//			if(this.m_objViewer.m_cmbMedSort.SelectedValue != null && this.m_objViewer.m_cmbItem.SelectedValue != null)
//			{
//				System.Data.DataRow dr = m_dtRelation.NewRow();
//				dr["ITEMCATID_CHR"] = this.m_objViewer.m_cmbItem.SelectedValue;
//				dr["ITEMCATNAME_VCHR"] = this.m_objViewer.m_cmbItem.Text;
//				dr["MEDICINETYPEID_CHR"] = this.m_objViewer.m_cmbMedSort.SelectedValue;
//				dr["MEDICINETYPENAME_VCHR"] = this.m_objViewer.m_cmbMedSort.Text;
//				dr["OUTMEDSTOREID_CHR"] = this.m_objViewer.comboBox2.SelectItemValue;
//				dr["MEDSTORENAME_VCHR"] = this.m_objViewer.comboBox2.Text;
//				dr["INMEDSTOREID_CHR"] = this.m_objViewer.comboBox1.SelectItemValue;
//				dr["MEDSTORENAME_VCHR1"] = this.m_objViewer.comboBox1.Text;
//				m_dtRelation.Rows.Add(dr);
//				System.Windows.Forms.ListViewItem lvi = new System.Windows.Forms.ListViewItem(this.m_objViewer.m_cmbItem.Text);
//				lvi.SubItems.Add(this.m_objViewer.m_cmbMedSort.Text);
//				lvi.SubItems.Add(this.m_objViewer.comboBox2.Text);
//				lvi.SubItems.Add(this.m_objViewer.comboBox1.Text);
//				lvi.Tag = dr;
//				this.m_objViewer.m_lvRelation.Items.Add(lvi);
//			}
		}
		#endregion 增加关联

		#region  删除关联
		public void DelRelation()
		{
//			if(this.m_objViewer.m_lvRelation.SelectedItems != null)
//			{
//				if(m_dtDel == null)
//				{
//					m_dtDel = m_dtRelation .Clone();
//				}
//				int count = this.m_objViewer.m_lvRelation.SelectedItems.Count;
//				for(int i = 0;i < count;i++)
//				{
//					m_dtDel.ImportRow(((System.Data.DataRow)this.m_objViewer.m_lvRelation.SelectedItems[0].Tag));
//					((System.Data.DataRow)this.m_objViewer.m_lvRelation.SelectedItems[0].Tag).Delete();					
//					this.m_objViewer.m_lvRelation.Items.Remove(this.m_objViewer.m_lvRelation.SelectedItems[0]);
//				}
//			}
		}
		#endregion 删除关联 

		#region 保存关联

		public void SaveRelation()
		{
			System.Data.DataTable dt=m_dtRelation.Clone();
			for(int i1=0;i1<this.m_objViewer.m_dgRelation.RowCount;i1++)
			{
				if(this.m_objViewer.m_dgRelation[i1,0].ToString()!="")
				{
					System.Data.DataRow newRow=dt.NewRow();
					newRow["medicinetypeid_chr"]=this.m_objViewer.m_dgRelation[i1,4].ToString();
					newRow["itemcatid_chr"]=this.m_objViewer.m_dgRelation[i1,5].ToString();
					newRow["OUTMEDSTOREID_CHR"]=this.m_objViewer.m_dgRelation[i1,6].ToString();
					newRow["INMEDSTOREID_CHR"]=this.m_objViewer.m_dgRelation[i1,7].ToString();
					dt.Rows.Add(newRow);
				}
			}
			long lngRes = objSvc.m_lngSaveFeeAndMedSortRel(dt,this.m_dtDel);
			if(lngRes > 0)
			{
				MessageBox.Show("保存成功");
			}
			else
			{
				MessageBox.Show("保存失败");
			}
		}
		#endregion 保存关联

		#region 更改判断
		public bool HasChange()
		{
			if(this.m_dtRelation.GetChanges()!= null && this.m_dtRelation.GetChanges().Rows.Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		#endregion 更改判断
	}
}
