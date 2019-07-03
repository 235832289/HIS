using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlReturnCheck 的摘要说明。
	/// </summary>
	public class clsControlReturnCar:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsControlReturnCar()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		clsDomainControl_Register clsDomain=new clsDomainControl_Register();
		com.digitalwave.iCare.gui.HIS.frmReturnCar m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmReturnCar)frmMDI_Child_Base_in;
		}
		#endregion
		#region 变量
		/// <summary>
		/// 保存卡号数据
		/// </summary>
		 DataTable bt=new DataTable();
		/// <summary>
		/// 保存查找数据
		/// </summary>
		DataTable btFind=new DataTable();
		#endregion
		#region 初始化表单
		public void m_lngfrmload()
		{
            string startDate = null;
            string endDate = null;
            if (this.m_objViewer.checkBox1.Checked)
            {
                startDate = this.m_objViewer.DtStart.Value.ToShortDateString();
                endDate = this.m_objViewer.dtend.Value.ToShortDateString();
            }
            long lngRes = clsDomain.m_lngGetCarData(startDate, endDate, out bt, this.m_objViewer.txt_CarID.Text.Trim() == "" ? null : this.m_objViewer.txt_CarID.Text.Trim(), null);
			if(lngRes==1&&bt.Rows.Count>0)
			{
				this.m_objViewer.ctlDgList.m_mthSetDataTable(bt);
				this.m_objViewer.ctlDgList.Tag="bt";
			}

		}
		#endregion
		#region 退卡操作
		public void m_lngReturnCar()
		{
			if((string)this.m_objViewer.ctlDgList.Tag=="bt")
			{
				if(bt.Rows.Count>0)
				{
					string carID=bt.Rows[this.m_objViewer.ctlDgList.CurrentCell.RowNumber]["PATIENTCARDID_CHR"].ToString();
					string patNO=bt.Rows[this.m_objViewer.ctlDgList.CurrentCell.RowNumber]["PATIENTID_CHR"].ToString();
					long lngRes=clsDomain.m_lngReturnCar(carID,patNO);
					if(lngRes==1&&bt.Rows.Count>0)
					{
						bt.Rows[this.m_objViewer.ctlDgList.CurrentCell.RowNumber]["status"]="已退卡";;
					}
				}
			}
			else
			{
				if(btFind.Rows.Count>0)
				{
					string carID=btFind.Rows[this.m_objViewer.ctlDgList.CurrentCell.RowNumber]["PATIENTCARDID_CHR"].ToString();
					string patNO=btFind.Rows[this.m_objViewer.ctlDgList.CurrentCell.RowNumber]["PATIENTID_CHR"].ToString();
					long lngRes=clsDomain.m_lngReturnCar(carID,patNO);
					if(lngRes==1&&bt.Rows.Count>0)
					{
						btFind.Rows[this.m_objViewer.ctlDgList.CurrentCell.RowNumber]["status"]="已退卡";;
					}
				}
			}
		}
		#endregion
		#region 返回事件
		public void m_lngReturnClick()
		{
			this.m_objViewer.ctlDgList.m_mthSetDataTable(bt);
			this.m_objViewer.ctlDgList.Tag="bt";
		}
		#endregion
		#region 查找数据
		public void m_lngReturnCarFind()
		{
			if(this.m_objViewer.txt_CarID.Text=="")
				return;
			try
			{
				btFind=bt.Clone();
			}
			catch
			{
			}
			btFind.Clear();
			for(int i1=0;i1<bt.Rows.Count;i1++)
			{
				if(bt.Rows[i1]["PATIENTCARDID_CHR"].ToString().IndexOf(this.m_objViewer.txt_CarID.Text.Trim(),0)==0)
				{
					DataRow newRow=btFind.NewRow();
					newRow["PATIENTCARDID_CHR"]=bt.Rows[i1]["PATIENTCARDID_CHR"];
					newRow["PATIENTID_CHR"]=bt.Rows[i1]["PATIENTID_CHR"];
					newRow["status"]=bt.Rows[i1]["status"];
					newRow["LASTNAME_VCHR"]=bt.Rows[i1]["LASTNAME_VCHR"];
					btFind.Rows.Add(newRow);
				}
			}
			this.m_objViewer.ctlDgList.m_mthSetDataTable(btFind);
			if(btFind.Rows.Count>0)
			{
			     this.m_objViewer.ctlDgList.CurrentCell=new DataGridCell(0,0);
				 this.m_objViewer.ctlDgList.m_mthSelectARow(0);
			}
			this.m_objViewer.ctlDgList.Tag="btFind";
		}
		#endregion

	}
}
