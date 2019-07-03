using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_MedicineSource 的摘要说明。
	/// </summary>
	public class clsCtl_MedicineSource:com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_MedicineSource objSvc =null;
		private DataTable dt=null;
		private DataTable dt2=null;
		int index=0;
		public clsCtl_MedicineSource()
		{
			objSvc=new clsDcl_MedicineSource();
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		public com.digitalwave.iCare.gui.HIS.frmMedicineSource m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmMedicineSource)frmMDI_Child_Base_in;
		}
		#endregion
		#region 窗口初始化工作
		public void m_mthFormLoad()
		{
			this.m_objViewer.m_cboFindCharge.SelectedIndex=0;
			m_objViewer.m_cmbFind.SelectedIndex=0;
			this.m_mthFindChargeItem("","");
			this.m_mthFindChargeItemSource();
		}
		#endregion
		#region 查询药品信息
		public void m_mthFindChargeItem(string strType,string strContent)
		{
				
			long strRet=objSvc.m_mthFindChargeItem(strType,strContent,out dt);
			dt.TableName="dt";
			if(strRet>0)
			{
				this.m_objViewer.ctlDataGrid1.m_mthSetDataTable(dt);
			}
			this.m_objViewer.ctlDataGrid1.CurrentCell=new DataGridCell(0,0);
			if(dt.Rows.Count>0)
			{
				this.m_mthDataGridCellChange();
			}
		}
		#endregion
		#region 查询项目源
		/// <summary>
		/// 查询项目源
		/// </summary>
		/// <param name="strType">分类</param>
		public void m_mthFindChargeItemSource()
		{
			long strRet=objSvc.m_mthFindChargeItemSource(out dt2);
		
			if(strRet>0)
			{
				this.m_objViewer.ctlDataGrid2.m_mthSetDataTable(dt2);
			}
		
			
		}
		#endregion
		#region 查找下拉框改变选项
		public void m_cmbFind_SelectedIndexChanged()
		{
			switch(m_objViewer.m_cmbFind.SelectedIndex)
			{
				case 0://药品ID
					m_objViewer.m_cmbFind.Tag="MEDICINEID_CHR";
					break;
				case 1://药品名称
					m_objViewer.m_cmbFind.Tag="ASSISTCODE_CHR";
					break;
				case 2://药品编码
					m_objViewer.m_cmbFind.Tag="MEDICINENAME_VCHR";
					break;
				case 3://药品拼音
					m_objViewer.m_cmbFind.Tag="ITEMPYCODE_CHR";
					break;
				case 4://药品五笔
					m_objViewer.m_cmbFind.Tag="ITEMWBCODE_CHR";
					break;
			}
			m_objViewer.m_txtFind.Select();
		}
		#endregion
		#region DataGridCellChange事件
		public void m_mthDataGridCellChange()
		{
			int row =this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
			this.m_objViewer.btSave.Tag=dt.Rows[row]["ID"].ToString();
			this.m_objViewer.txtSourceID.Text=dt.Rows[row]["MEDICINESTDID_CHR"].ToString();
			this.m_objViewer.txtSourceName.Text=dt.Rows[row]["MEDICINESTDNAME_VCHR"].ToString();
		}
		public void m_mthDataGridCellChange2()
		{
			int row =this.m_objViewer.ctlDataGrid2.CurrentCell.RowNumber;
			this.m_objViewer.txtSourceID.Text=dt2.Rows[row]["ID"].ToString();
			this.m_objViewer.txtSourceName.Text=dt2.Rows[row]["Name"].ToString();
		}
		#endregion
		#region 从右边的列表查找收费项目
		/// <summary>
		/// 从右边的列表查找收费项目
		/// </summary>
		public void m_FillChargeItem()
		{
			string strCat="ID";//
			if(m_objViewer.m_cboFindCharge.SelectedIndex==1)
			{
				strCat="Name";//按名称查找
			}
			
			for(int i=this.index;i<dt2.Rows.Count;i++)
			{
				int row=0;
				row= dt2.Rows[i][strCat].ToString().IndexOf(m_objViewer.m_txtFindChargItem.Text.Trim());
				if(row>=0)
				{
					m_objViewer.ctlDataGrid2.CurrentCell=new DataGridCell(i,0);
					this.index=i+1;
					m_objViewer.m_txtFindChargItem.Select();
					return;
				}
			}
			MessageBox.Show("  已经到了所有记录的尽头,\n点确定返回首记录重新查找!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.index=0;
			m_objViewer.m_txtFindChargItem.Select();
		}
		#endregion
		#region 改变查找文本
		public void m_mthChangeText()
		{
			this.index=0;
		}
		#endregion
		#region 保存数据
		public void m_mthSaveData()
		{
			if(this.m_objViewer.btSave.Tag==null)
			{
			return;
			}
			long strRet=objSvc.m_mthSaveData(this.m_objViewer.btSave.Tag.ToString(),this.m_objViewer.txtSourceID.Text);
		
			if(strRet>0)
			{
				MessageBox.Show("  保存成功!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
				int row =this.m_objViewer.ctlDataGrid1.CurrentCell.RowNumber;
				dt.Rows[row]["MEDICINESTDID_CHR"]=this.m_objViewer.txtSourceID.Text.Trim();
				dt.Rows[row]["MEDICINESTDNAME_VCHR"]=this.m_objViewer.txtSourceName.Text.Trim();
			}
			else
			{
				MessageBox.Show("  保存失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		#endregion
	}
}
