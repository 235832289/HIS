using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlChargeCat 的摘要说明。
	/// </summary>
	public class clsControlUsageItem:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlUsageItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			clsDomain=new clsDomainControl_ChargeItem();
		}
		clsDomainControl_ChargeItem clsDomain;
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmUsageGroup m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmUsageGroup)frmMDI_Child_Base_in;
		}
		#endregion

		#region 取得项目的类型
		public void m_FillCat()
		{
			clsCharegeItemCat_VO[] objResult;
			long lngRes = clsDomain.m_lngFindCat(out objResult);
			m_objViewer.m_cboCat.Items.Clear();
			if((lngRes>0)&&(objResult != null))
			{
				for(int i1=0; i1<objResult.Length;i1++)
				{
					m_objViewer.m_cboCat.Item.Add(objResult[i1].m_strItemCatName,objResult[i1].m_strItemCatID);
				}
			}
			if(m_objViewer.m_cboCat.Items.Count>0)
			{
				m_objViewer.m_cboCat.SelectedIndex=0;
			}
		}
		#endregion

		#region 填充源列表
		public void m_FillItemGrid()
		{
			DataTable dtResult=new DataTable();
			string strUsageID=m_objViewer.m_cboUsage.SelectItemValue;
			string strCatID=m_objViewer.m_cboCat.SelectItemValue;
			m_objViewer.m_dg.DataSource=dtResult;
			if(strUsageID=="")
			{
				MessageBox.Show("请选择用法","提示");
				m_objViewer.m_cboUsage.Focus();
				return;
			}
			if(strCatID=="")
				return;
			long lngRes=clsDomain.m_lngFindItemNoUsageGroup(strCatID,strUsageID,out dtResult);
			m_objViewer.m_dg.DataSource=dtResult;
		}
		#endregion
		#region 获取用法列表
		public void m_GetUsage()
		{
			m_objViewer.m_cboUsage.Items.Clear();
			clsUsageType_VO[] objResult;
			long lngRes=clsDomain.m_lngGetUsage(out objResult,"");
			if(lngRes>0 && objResult.Length>0)
			{
				for(int i1=0;i1<objResult.Length;i1++)
				{
					m_objViewer.m_cboUsage.Item.Add(objResult[i1].m_strUsageName,objResult[i1].m_strUsageID);
				}
			}
			if(m_objViewer.m_cboUsage.Items.Count>0)
				m_objViewer.m_cboUsage.SelectedIndex=0;
		}
		#endregion
		#region 根据用法ID取回项目列表
		public void m_GetItemByUsageID()
		{
			m_objViewer.m_lvw.Items.Clear();
			clsChargeItem_VO[] objResult;
			string strID=m_objViewer.m_cboUsage.SelectItemValue;
            if(strID=="")
				return;
			long lngRes=clsDomain.m_lngFindItemByUsageID(strID,out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					lvw=new ListViewItem(objResult[i1].m_strItemName);
					lvw.Tag=objResult[i1].m_strItemID;
					m_objViewer.m_lvw.Items.Add(lvw);
				}
			}
			if(m_objViewer.m_lvw.Items.Count>0)
				m_objViewer.m_lvw.Items[0].Selected=true;
		}
		#endregion
		#region 新增
		public void m_Add()
		{
            string strID="";
			string strName="";
			if(m_objViewer.m_cboUsage.SelectItemValue=="")
			{
				MessageBox.Show("请选择用法","提示");
				m_objViewer.m_cboUsage.Focus();
				return;
			}
			if(m_objViewer.m_dg.VisibleRowCount>0 && m_objViewer.m_dg.CurrentCell.RowNumber>-1)
			{
				strID=m_objViewer.m_dg[m_objViewer.m_dg.CurrentCell.RowNumber,0].ToString();
				if(strID=="")
					return;
				strName=m_objViewer.m_dg[m_objViewer.m_dg.CurrentCell.RowNumber,2].ToString();
			}
			else
				return;
			clsChargeItemUsageGroup_VO clsVO=new clsChargeItemUsageGroup_VO();
			clsVO.m_strItemID=strID;
			clsVO.m_strUsageID=m_objViewer.m_cboUsage.SelectItemValue;
			long lngRes=clsDomain.m_lngDoAddNewChargeItemUsageGroup(clsVO);
			if(lngRes>0)
			{
				
				ListViewItem lvw=new ListViewItem(strName);
				lvw.Tag=clsVO.m_strItemID;
				m_objViewer.m_lvw.Items.Add(lvw);
				this.m_FillItemGrid();
			}
		}
		#endregion
		#region 删除
		public void m_Del(bool IsAll)
		{
			int index=0;
			if(m_objViewer.m_cboUsage.SelectItemValue=="" || m_objViewer.m_lvw.Items.Count==0)
				return;
            clsChargeItemUsageGroup_VO clsVO=new clsChargeItemUsageGroup_VO();
			if(IsAll)
			{
				clsVO.m_strUsageID=m_objViewer.m_cboUsage.SelectItemValue;
				clsVO.m_strItemID=null;
			}   
			else
			{
				if(m_objViewer.m_lvw.SelectedItems.Count==0 || m_objViewer.m_lvw.SelectedItems[0].Tag==null)
					return;
				clsVO.m_strItemID=m_objViewer.m_lvw.SelectedItems[0].Tag.ToString();
				clsVO.m_strUsageID=m_objViewer.m_cboUsage.SelectItemValue;
				index=m_objViewer.m_lvw.SelectedItems[0].Index;
			}
			long lngRes=clsDomain.m_lngDelUsageGroupByID(clsVO);
			if(lngRes>0)
			{
				if(IsAll)
					m_objViewer.m_lvw.Items.Clear();
				else
					m_objViewer.m_lvw.Items[index].Remove();
				if(m_objViewer.m_lvw.Items.Count>0 && index>0)
                    m_objViewer.m_lvw.Items[index-1].Selected=true;
				this.m_FillItemGrid();
			}
		}
		#endregion
	}
}
