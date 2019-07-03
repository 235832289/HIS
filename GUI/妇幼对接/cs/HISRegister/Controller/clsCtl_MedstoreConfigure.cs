using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
using System.Xml;
using System.IO;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_MedstoreConfigure 的摘要说明。
	/// </summary>
	public class clsCtl_MedstoreConfigure:com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_ItemCatMapping objSvc=null;
		public clsCtl_MedstoreConfigure()
		{
			objSvc=new clsDcl_ItemCatMapping();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		public com.digitalwave.iCare.gui.HIS.frmMedstoreConfigure m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmMedstoreConfigure)frmMDI_Child_Base_in;
		}
		#endregion
		#region 加载药房信息
		public void m_mthMedstoreInfo(string flag)
		{
			DataTable dt;
			long ret =objSvc.m_mthMedstoreInfo(out dt,flag);
			this.m_objViewer.listView1.Items.Clear();
			this.m_objViewer.listView2.Items.Clear();
			if(ret >0&&dt.Rows.Count>0)
			{
				ListViewItem lv;
				for(int i=0;i<dt.Rows.Count;i++)
				{
				lv=new ListViewItem(dt.Rows[i]["MEDSTORENAME_VCHR"].ToString().Trim());
				lv.ImageIndex=0;
				lv.Tag =dt.Rows[i]["MEDSTOREID_CHR"].ToString().Trim();
				this.m_objViewer.listView1.Items.Add(lv);
				}
			}
			m_mthGetMedstoreInfo();
		}
		#endregion
		#region 加载药房类型
		public void m_mthMedstoreType()
		{
			this.m_objViewer.listView3.Items.Clear();
			ListViewItem lv;
			lv=new ListViewItem("西药");
			lv.ImageIndex=2;
			lv.Tag="1";
			this.m_objViewer.listView3.Items.Add(lv);
			lv=new ListViewItem("中药");
			lv.ImageIndex=2;
			lv.Tag="2";
			this.m_objViewer.listView3.Items.Add(lv);
			lv=new ListViewItem("材料");
			lv.ImageIndex=2;
			lv.Tag="3";
			this.m_objViewer.listView3.Items.Add(lv);
		}
		#endregion
		#region 根据药房ID选择药房
		private void m_mthSelectItemByID(string strID,string windowID)
		{
			this.m_objViewer.lbeName.Text="";
			this.m_objViewer.lbeWindowName.Text="";
			if(strID!=null)
			{
				for(int i=0;i<this.m_objViewer.listView1.Items.Count;i++)
				{
					if(this.m_objViewer.listView1.Items[i].Tag.ToString()==strID)
					{
						this.m_objViewer.listView1.Items[i].Selected=true;
						this.m_objViewer.listView1.Focus();
						this.m_objViewer.listView1.Select();
						this.m_objViewer.lbeName.Text=this.m_objViewer.listView1.Items[i].SubItems[0].Text;
						break;
					}
				}
			}
			for(int i2=0;i2<this.m_objViewer.listView2.Items.Count;i2++)
			{
				if(this.m_objViewer.listView2.Items[i2].Tag.ToString()==windowID)
				{
					this.m_objViewer.listView2.Items[i2].Selected=true;
					this.m_objViewer.lbeWindowName.Text=this.m_objViewer.listView2.Items[i2].SubItems[0].Text;
					break;
				}
			}
		
		}
		#endregion
		#region 读出药对应的药房
		public void m_mthGetMedstoreInfo()
		{
			try
			{
//				this.m_objViewer.lbeName.Text="";
//				this.m_objViewer.btSave.Tag=null;
                string patXML = Application.StartupPath + "\\LoginFile.xml";
				if(File.Exists(patXML))
				{
					string strCurrEmpNO = "AnyOne"; 
					string strType ="WMedicinestore";
					if(this.m_objViewer.listView3.SelectedItems[0].Index==1)
					{
						strType ="CMedicinestore";
					}
					else if(this.m_objViewer.listView3.SelectedItems[0].Index==2)
					{
						strType ="MaterialStore";
					}
　　				XmlDocument doc=new XmlDocument(); 
　　				doc.Load(patXML); 
					XmlNode xn = doc.DocumentElement.SelectNodes(@"//register")[0];
					XmlNode xnCurr = xn.SelectSingleNode(@"//"+strType+"[@key='" + strCurrEmpNO + @"']");
					if(xnCurr != null)
					{
						this.m_mthSelectItemByID(xnCurr.Attributes["value"].Value.ToString().Trim(),xnCurr.Attributes["windows"].Value.ToString().Trim());
					}
					
				}
			}
			catch
			{
				
			}
		}
		#endregion

		#region 读出当前药房的发药窗口
		public string  m_mthGetMedstoreNow(string storageID)
		{

			try
			{
				//				this.m_objViewer.lbeName.Text="";
				//				this.m_objViewer.btSave.Tag=null;
                string patXML = Application.StartupPath + "\\LoginFile.xml";
				if(File.Exists(patXML))
				{
					string strCurrEmpNO = "AnyOne"; 
					string strType ="WMedicinestore";
					if(this.m_objViewer.listView3.SelectedItems[0].Index==1)
					{
						strType ="CMedicinestore";
					}
　　				XmlDocument doc=new XmlDocument(); 
　　				doc.Load(patXML); 
					XmlNode xn = doc.DocumentElement.SelectNodes(@"//register")[0];
					XmlNode xnCurr = xn.SelectSingleNode(@"//"+strType+"[@key='" + strCurrEmpNO + @"']");
					if(xnCurr.Attributes["value"].Value.ToString().Trim()==storageID)
					{
						return xnCurr.Attributes["windows"].Value.ToString().Trim();
					}
					else
					{
						return null;
					}

				}
			}
			catch
			{
				return null;
			}
			return null;
		}
		#endregion

		#region 根据药房ID查出窗口
		public void m_mthWindowInfoByID()
		{
			this.m_objViewer.listView2.Items.Clear();
			if(this.m_objViewer.btSave.Tag==null)
			{
			return;
			}
			DataTable dt;
			long ret =objSvc.m_mthWindowInfoByID(out dt,this.m_objViewer.btSave.Tag.ToString());
			
			if(ret >0&&dt.Rows.Count>0)
			{
				string window=m_mthGetMedstoreNow(this.m_objViewer.btSave.Tag.ToString());
				ListViewItem lv;
				for(int i=0;i<dt.Rows.Count;i++)
				{
					lv=new ListViewItem(dt.Rows[i]["WINDOWNAME_VCHR"].ToString().Trim());
					lv.ImageIndex=1;
					lv.Tag =dt.Rows[i]["WINDOWID_CHR"].ToString().Trim();
					this.m_objViewer.listView2.Items.Add(lv);
					if(window!=null&&window==dt.Rows[i]["WINDOWID_CHR"].ToString().Trim())
					{
						this.m_objViewer.listView2.Items[i].Selected=true;
					}
				}
			}
		}
		#endregion
		#region 保存
		public void m_mthSave()
		{
			if(this.m_objViewer.btSave.Tag==null)
			{
			return;
			}
            string patXML = Application.StartupPath + "\\LoginFile.xml";
			try
			{
				if(File.Exists(patXML))
				{
					string strCurrEmpNO = "AnyOne"; 
					string strType ="WMedicinestore";
					if(this.m_objViewer.listView3.SelectedItems[0].Index==1)
					{
						strType ="CMedicinestore";
					}
					else if(this.m_objViewer.listView3.SelectedItems[0].Index==2)
					{
						strType ="MaterialStore";
					}
　　            XmlDocument doc=new XmlDocument(); 
　　            doc.Load(patXML); 
					XmlNode xn = doc.DocumentElement.SelectNodes(@"//register")[0];
					XmlNode xnCurr = xn.SelectSingleNode(@"//"+strType+"[@key='" + strCurrEmpNO + @"']");
					if(xnCurr != null)
					{
						xnCurr.Attributes["value"].Value =this.m_objViewer.btSave.Tag.ToString().Trim();
						//xnCurr.Attributes["windows"].Value =this.m_objViewer.lbeWindowName.Tag.ToString().Trim();
					}
					doc.Save(patXML);
					MessageBox.Show("保存成功","提示");
				}
				m_mthGetMedstoreInfo();
			}
			catch
			{
				MessageBox.Show("\t保存失败,\n请检查\""+Application.StartupPath+"\\"+patXML+"\"是否只读!","提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		#endregion

	}
}
