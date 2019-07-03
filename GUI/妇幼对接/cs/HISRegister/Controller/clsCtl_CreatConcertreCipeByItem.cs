using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_CreatConcertreCipeByItem 的摘要说明。
	/// </summary>
	public class clsCtl_CreatConcertreCipeByItem:com.digitalwave.GUI_Base.clsController_Base
	{
		public clsCtl_CreatConcertreCipeByItem()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		public com.digitalwave.iCare.gui.HIS.frmCreatConcertreCipeByItem m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmCreatConcertreCipeByItem)frmMDI_Child_Base_in;
		}
		#endregion
		public void m_mthCalMoney()
		{
			decimal temp =0;
			for(int i=0;i<this.m_objViewer.listView1.CheckedItems.Count;i++)
			{
			temp +=clsConvertToDecimal.m_mthConvertObjToDecimal(this.m_objViewer.listView1.CheckedItems[i].SubItems[12].Text);
			}
			this.m_objViewer.lbeSumMoney.Text =temp.ToString("0.00");
		}
		public void m_mthSelectAll()
		{
			for(int i=0;i<this.m_objViewer.listView1.Items.Count;i++)
			{
				this.m_objViewer.listView1.Items[i].Checked=true;
			}
		}
		public void m_mthSelectBack()
		{
			for(int i=0;i<this.m_objViewer.listView1.Items.Count;i++)
			{
				if(this.m_objViewer.listView1.Items[i].Checked)
				{
					this.m_objViewer.listView1.Items[i].Checked =false;
				}
				else
				{
				this.m_objViewer.listView1.Items[i].Checked =true;
				}
			}
		}
		public void m_mthSaveData()
		{
			if(this.m_objViewer.txtName.Text.Trim()=="")
			{
				MessageBox.Show("必需输入名称");
				this.m_objViewer.txtName.Focus();
				return;
			}
			if(this.m_objViewer.txtCode.Text.Trim()=="")
			{
				MessageBox.Show("必需助记码");
				this.m_objViewer.txtCode.Focus();
				return;
			}
				clsDomainConrol_ConcertreCipe m_objDoMain=new clsDomainConrol_ConcertreCipe();
			if(m_objDoMain.m_mthCheckCodeIsUsed(this.m_objViewer.txtCode.Text.Trim(),"","0")==3)
			{
				if(MessageBox.Show("助记码已经使用,是否继续?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.No)
				{
				return;
				}
			}
				DataRow AddNewRow=this.m_objViewer.dtMain.NewRow();
				AddNewRow["RECIPENAME_CHR"]=this.m_objViewer.txtName.Text.Trim();
				string isDetp="0";
				if(this.m_objViewer.ra_public.Checked==true)
					AddNewRow["strPRIVILEGE"]="0";
				if(this.m_objViewer.ra_private.Checked==true)
					AddNewRow["strPRIVILEGE"]="1";
				if(this.m_objViewer.ra_dep.Checked==true)
				{
					AddNewRow["strPRIVILEGE"]="2";
					isDetp="1";
				}
				string strRecordID="";
				AddNewRow["USERCODE_CHR"]=this.m_objViewer.txtCode.Text.Trim();
				AddNewRow["PYCODE_CHR"]=this.m_objViewer.txtPy.Text.Trim();
			    AddNewRow["DISEASENAME_VCHR"]=this.m_objViewer.txtRemark.Text.Trim();
				AddNewRow["WBCODE_CHR"]=this.m_objViewer.txtWb.Text.Trim();
				AddNewRow["CREATERID_CHR"]=this.m_objViewer.LoginInfo.m_strEmpID;
				DataTable dt=this.m_objViewer.dtDetail.Clone();
				for(int i1=0;i1<this.m_objViewer.listView1.CheckedItems.Count;i1++)
				{
					DataRow drTemp =(DataRow)this.m_objViewer.listView1.CheckedItems[i1].Tag;
                    drTemp["sort_int"] = i1;
					dt.Rows.Add(drTemp.ItemArray);
                    
				}
            ///////////////////////////////////
                object[] AddNewRowArr = AddNewRow.ItemArray;
                long l = m_objDoMain.m_lngAddNewConcertre(out strRecordID, AddNewRowArr, dt, this.m_objViewer.dtDepement, isDetp, 0);
				if(l>0)
				{
					this.m_objViewer.Close();
				}
				else
				{
					MessageBox.Show("保存失败!");
				}
			}
		}
	}
