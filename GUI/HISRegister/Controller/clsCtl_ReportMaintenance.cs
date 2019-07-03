using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.ValueObject; 
using exDataGridSour;

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_ReportMaintenance 的摘要说明。
	/// </summary>
	public class clsCtl_ReportMaintenance: com.digitalwave.GUI_Base.clsController_Base
	{
	private clsDcl_ReportMaintenance objSvc=null;
		public clsCtl_ReportMaintenance()
		{
			objSvc=new clsDcl_ReportMaintenance();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		com.digitalwave.iCare.gui.HIS.frmReportMaintenance m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmReportMaintenance)frmMDI_Child_Base_in;
		}
		#endregion
		#region 窗体初始化
		public void m_mthInit()
		{
		this.m_mthGetReportInfo();
		this.m_objViewer.ra1.Checked=true;
		if(this.m_objViewer.listView1.Items.Count>0)
		{
		this.m_objViewer.listView1.Items[0].Selected=true;
		}
		}
		#endregion
		#region 加载报表信息
		public void m_mthGetReportInfo()
		{
		clsReportMain_VO[] objResult =null;
		long l =objSvc.m_mthGetReportInfo("",out objResult);
			this.m_objViewer.listView1.Items.Clear();
			if(l>0&&objResult!=null)
			{
				ListViewItem lv;
				for(int i=0;i<objResult.Length;i++)
				{
					lv=new ListViewItem(objResult[i].strReportID);
					lv.SubItems.Add(objResult[i].strReportName);
					this.m_objViewer.listView1.Items.Add(lv);
				}
			}
		}
		#endregion
		#region 加载报表字段信息
		public void m_mthGetGroupByID(string strID)
		{
			clsReportDetail_VO[] objResult =null;
			long l =objSvc.m_mthGetGroupByID(strID,out objResult);
			this.m_objViewer.listView2.Items.Clear();
			if(l>0&&objResult!=null)
			{
				ListViewItem lv;
				for(int i=0;i<objResult.Length;i++)
				{
					lv=new ListViewItem(objResult[i].strGroupID);
					lv.SubItems.Add(objResult[i].strGroupName);
					this.m_objViewer.listView2.Items.Add(lv);
				}
				if(this.m_objViewer.listView2.Items.Count>0)
				{
					this.m_objViewer.listView2.Items[0].Selected=true;
				}
				
			}
			else
			{
			m_mthClearChecked();
			this.m_objViewer.textBox3.Text="";
			this.m_objViewer.textBox4.Text="";
			this.m_objViewer.btChangeB.Tag=null;
			}
		}
		#endregion
		#region 根据报表ID,字段ID,分类标志查找分类信息
		private void m_mthClearChecked()
		{
			for(int i1=0;i1<this.m_objViewer.listView3.Items.Count;i1++)
			{
				this.m_objViewer.listView3.Items[i1].Checked=false;			
			}
		}
		public void m_mthGetGroupDetailByID()
		{
			if(this.m_objViewer.btChangeA.Tag==null||this.m_objViewer.btChangeB.Tag==null)
		   {
				return;
			}
			clsGroupDetail_VO[] objResult =null;
			long l =0;
			if(this.flag)
			{
				l =objSvc.m_mthGetGroupDetailByID(this.m_objViewer.btChangeA.Tag.ToString(),this.m_objViewer.btChangeB.Tag.ToString(),"",out objResult);
				if(l>0&&objResult!=null)
				{
					if(objResult[0].intFlag ==1)
					{
						this.m_objViewer.ra1.Checked =true;
					}
					if(objResult[0].intFlag ==2)
					{
						this.m_objViewer.ra2.Checked =true;
					}
					if(objResult[0].intFlag ==3)
					{
						this.m_objViewer.ra3.Checked =true;
					}
					if(objResult[0].intFlag ==4)
					{
						this.m_objViewer.ra4.Checked =true;
					}
				}
			}
			this.flag =false;
			 l =objSvc.m_mthGetGroupDetailByID(this.m_objViewer.btChangeA.Tag.ToString(),this.m_objViewer.btChangeB.Tag.ToString(),this.m_objViewer.ra1.Tag.ToString(),out objResult);
			this.m_mthClearChecked();	
			if(l>0&&objResult!=null)
			{
				for(int i2=0;i2<objResult.Length;i2++)
				{
					for(int i3=0;i3<this.m_objViewer.listView3.Items.Count;i3++)
					{
						if(this.m_objViewer.listView3.Items[i3].Tag==null)
						{
							continue;
						}
						else
						{
							if(objResult[i2].strTypeID==this.m_objViewer.listView3.Items[i3].Tag.ToString().Trim())
							{
							this.m_objViewer.listView3.Items[i3].Checked=true;
							}
						}
					}
				}
			}
		}
		#endregion
		#region 获取分类
		public void m_mthGetCat()
		{
			if(this.m_objViewer.ra1.Tag==null)
			{
			return;
			}
			m_objViewer.listView3.Items.Clear();
			clsChargeItemEXType_VO[] objResult;
			long lngRes=objSvc.m_mthGetCat(this.m_objViewer.ra1.Tag.ToString(),out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				ListViewItem lvw;
				for(int i1=0;i1<objResult.Length;i1++)
				{
					lvw=new ListViewItem(objResult[i1].m_strTypeName.Trim());
					lvw.Tag=objResult[i1].m_strTypeID;
					m_objViewer.listView3.Items.Add(lvw);
				}
			}
			this.m_mthGetGroupDetailByID();
		}
		#endregion
		#region RadionButton
		public void m_mthRadioButtonChange()
		{
			if(this.m_objViewer.ra1.Checked)
			{
			this.m_objViewer.ra1.Tag=1;
			}
			if(this.m_objViewer.ra2.Checked)
			{
				this.m_objViewer.ra1.Tag=2;
			}
			if(this.m_objViewer.ra3.Checked)
			{
				this.m_objViewer.ra1.Tag=3;
			}
			if(this.m_objViewer.ra4.Checked)
			{
				this.m_objViewer.ra1.Tag=4;
			}
		}
		#endregion
		#region 保存报表信息
		/// <summary>
		/// 获取信息
		/// </summary>
		/// <param name="obj_VO"></param>
		private void m_mthGetReportInfo(out clsReportMain_VO obj_VO)
		{
			
			obj_VO=new clsReportMain_VO();
			obj_VO.strReportID=this.m_objViewer.textBox1.Text.Trim();
			obj_VO.strReportName=this.m_objViewer.textBox2.Text.Trim();

		}
		/// <summary>
		/// 判断是否能保存
		/// </summary>
		/// <param name="flag"></param>
		/// <returns></returns>
		private bool m_mthCanSave(int flag)
		{
			if(this.m_objViewer.textBox1.Text.Trim()=="")
			{
			MessageBox.Show("ID不能为空","ICare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			this.m_objViewer.textBox1.Focus();
			return true;
			}
			if(this.m_objViewer.textBox2.Text.Trim()=="")
			{
				MessageBox.Show("名称不能为空","ICare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.m_objViewer.textBox2.Focus();
				return true;
			}
			if(flag ==1)//新增
			{
				for(int i=0;i<this.m_objViewer.listView1.Items.Count;i++)
				{
					if(this.m_objViewer.textBox1.Text.Trim()==m_objViewer.listView1.Items[i].SubItems[0].Text.Trim())
					{
						MessageBox.Show("ID已经存在,请选择另一个ID！","提示");
						this.m_objViewer.textBox1.Select();
						return true;
					}
				}
			}
			else//更新
			{
				for(int i=0;i<this.m_objViewer.listView1.Items.Count;i++)
				{
					if(i==this.m_objViewer.listView1.SelectedIndices[0])
					{
						continue;
					}
					if(this.m_objViewer.textBox1.Text.Trim()==m_objViewer.listView1.Items[i].SubItems[0].Text.Trim())
					{
						MessageBox.Show("ID已经存在,请选择另一个ID！","提示");
						this.m_objViewer.textBox1.Select();
						return true;
					}
					
				}		
			}
			return false;
		}
		public void m_mthAddNewReportInfo()
		{
			if(m_mthCanSave(1))
			{
			return;
			}
		clsReportMain_VO obj_VO;
		this.m_mthGetReportInfo(out obj_VO);
		long l=objSvc.m_mthAddNewReportInfo(obj_VO);
			if(l>0)
			{
				ListViewItem lv =new ListViewItem(obj_VO.strReportID);
				lv.SubItems.Add(obj_VO.strReportName);
				this.m_objViewer.listView1.Items.Add(lv);
				this.m_objViewer.btChangeA.Tag=obj_VO.strReportID;
				this.m_objViewer.textBox3.Focus();
				//在这里添加代码
                MessageBox.Show("保存成功!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
			MessageBox.Show("保存失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		public void m_mthUpdateReportInfo()
		{
			if(m_mthCanSave(2))
			{
				return;
			}
			clsReportMain_VO obj_VO;
			this.m_mthGetReportInfo(out obj_VO);
			if(this.m_objViewer.btChangeA.Tag==null)
			{
			return ;
			}
			string strID =this.m_objViewer.btChangeA.Tag.ToString();
			bool falg =this.m_objViewer.btChangeA.Tag.ToString()==this.m_objViewer.textBox1.Text.Trim();
			long l=objSvc.m_mthUpdateReportInfo(strID,obj_VO,!falg);
			if(l>0)
			{
				this.m_objViewer.listView1.SelectedItems[0].SubItems[0].Text=obj_VO.strReportID;
				this.m_objViewer.listView1.SelectedItems[0].SubItems[1].Text=obj_VO.strReportName;
				this.m_objViewer.btChangeA.Tag=obj_VO.strReportID;
				MessageBox.Show("保存成功!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("保存失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		public void m_mthDeleteReportByID()
		{
			if(this.m_objViewer.btChangeA.Tag==null)
			{
			return;
			}
			if(MessageBox.Show("是否要删除?","ICare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
			{
			return;
			}
			long l=objSvc.m_mthDeleteReportByID(this.m_objViewer.btChangeA.Tag.ToString());
			if(l>0)
			{
				this.m_objViewer.listView1.SelectedItems[0].Remove();
				MessageBox.Show("删除成功!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("删除失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		#endregion
		#region 保存报表字段信息
		/// <summary>
		/// 获取信息
		/// </summary>
		/// <param name="obj_VO"></param>
		private void m_mthGetReportInfo2(out clsReportDetail_VO obj_VO)
		{
			
			obj_VO=new clsReportDetail_VO();
			if(this.m_objViewer.btChangeA.Tag!=null)
			{
			obj_VO.strReportID=this.m_objViewer.btChangeA.Tag.ToString();
			}
			obj_VO.strGroupID=this.m_objViewer.textBox3.Text.Trim();
			obj_VO.strGroupName=this.m_objViewer.textBox4.Text.Trim();

		}
		/// <summary>
		/// 判断是否能保存
		/// </summary>
		/// <param name="flag"></param>
		/// <returns></returns>
		private bool m_mthCanSave2(int flag)
		{
			if(this.m_objViewer.textBox3.Text.Trim()=="")
			{
				MessageBox.Show("ID不能为空","ICare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.m_objViewer.textBox3.Focus();
				return true;
			}
			if(this.m_objViewer.textBox4.Text.Trim()=="")
			{
				MessageBox.Show("名称不能为空","ICare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.m_objViewer.textBox4.Focus();
				return true;
			}
			if(flag ==1)//新增
			{
				for(int i=0;i<this.m_objViewer.listView2.Items.Count;i++)
				{
					if(this.m_objViewer.textBox3.Text.Trim()==m_objViewer.listView2.Items[i].SubItems[0].Text.Trim())
					{
						MessageBox.Show("ID已经存在,请选择另一个ID！","提示");
						this.m_objViewer.textBox3.Select();
						return true;
					}
				}
			}
			else//更新
			{
				for(int i=0;i<this.m_objViewer.listView2.Items.Count;i++)
				{
					if(i==this.m_objViewer.listView2.SelectedIndices[0])
					{
						continue;
					}
					if(this.m_objViewer.textBox3.Text.Trim()==m_objViewer.listView2.Items[i].SubItems[0].Text.Trim())
					{
						MessageBox.Show("ID已经存在,请选择另一个ID！","提示");
						this.m_objViewer.textBox3.Select();
						return true;
					}
					
				}		
			}
			return false;
		}
		public void m_mthAddNewReportInfo2()
		{
			if(m_mthCanSave2(1))
			{
				return;
			}
			clsReportDetail_VO obj_VO;
			this.m_mthGetReportInfo2(out obj_VO);
			long l=objSvc.m_mthAddNewReportInfo2(obj_VO);
			if(l>0)
			{
				ListViewItem lv =new ListViewItem(obj_VO.strGroupID);
				lv.SubItems.Add(obj_VO.strGroupName);
				this.m_objViewer.listView2.Items.Add(lv);
				this.m_objViewer.btChangeB.Tag=obj_VO.strGroupID;
				//在这里添加代码
				MessageBox.Show("保存成功!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("保存失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}

		public void m_mthUpdateReportInfo2()
		{
			if(m_mthCanSave2(2))
			{
				return;
			}
			clsReportDetail_VO obj_VO;
			this.m_mthGetReportInfo2(out obj_VO);
			if(this.m_objViewer.btChangeB.Tag==null)
			{
				return ;
			}
			string strID =this.m_objViewer.btChangeB.Tag.ToString();
			bool falg =this.m_objViewer.btChangeB.Tag.ToString()==this.m_objViewer.textBox3.Text.Trim();
			long l=objSvc.m_mthUpdateReportInfo2(strID,obj_VO,!falg);
			if(l>0)
			{
				this.m_objViewer.listView2.SelectedItems[0].SubItems[0].Text=obj_VO.strGroupID;
				this.m_objViewer.listView2.SelectedItems[0].SubItems[1].Text=obj_VO.strGroupName;
				this.m_objViewer.btChangeB.Tag=obj_VO.strGroupID;
				MessageBox.Show("保存成功!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("保存失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		public void m_mthDeleteReportByID2()
		{
			if(this.m_objViewer.btChangeB.Tag==null||this.m_objViewer.btChangeA.Tag==null)
			{
				return;
			}
			if(MessageBox.Show("是否要删除?","ICare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
			{
				return;
			}
			long l=objSvc.m_mthDeleteReportByID2(this.m_objViewer.btChangeB.Tag.ToString(),this.m_objViewer.btChangeA.Tag.ToString());
			if(l>0)
			{
				this.m_objViewer.listView2.SelectedItems[0].Remove();
				MessageBox.Show("删除成功!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("删除失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		#endregion
		#region
		/// <summary>
		/// 获取信息
		/// </summary>
		/// <param name="obj_VO"></param>
		private void m_mthGetReportInfo3(out clsGroupDetail_VO[] obj_VO)
		{
			obj_VO=new clsGroupDetail_VO[this.m_objViewer.listView3.CheckedItems.Count];
			if(this.m_objViewer.listView3.CheckedItems.Count==0)
			{
				obj_VO=new clsGroupDetail_VO[1];
				obj_VO[0]=new clsGroupDetail_VO();
				obj_VO[0].strReportID =this.m_objViewer.btChangeA.Tag.ToString();
				obj_VO[0].intFlag =int.Parse(this.m_objViewer.ra1.Tag.ToString());
				obj_VO[0].strGroupID =this.m_objViewer.btChangeB.Tag.ToString();
				obj_VO[0].strTypeID=null;
			}
			else
			{
				for(int i=0;i<this.m_objViewer.listView3.CheckedItems.Count;i++)
				{
					obj_VO[i]=new clsGroupDetail_VO();
					obj_VO[i].strReportID =this.m_objViewer.btChangeA.Tag.ToString();
					obj_VO[i].intFlag =int.Parse(this.m_objViewer.ra1.Tag.ToString());
					obj_VO[i].strGroupID =this.m_objViewer.btChangeB.Tag.ToString();
					obj_VO[i].strTypeID =this.m_objViewer.listView3.CheckedItems[i].Tag.ToString();
				}
			}

		}
		public void m_mthSaveGroupDetail()
		{
			if(this.m_objViewer.btChangeA.Tag==null&&this.m_objViewer.btChangeB.Tag==null)
			{
			return;
			}
			clsGroupDetail_VO[] obj_VO;
			this.m_mthGetReportInfo3(out obj_VO);
			long l=objSvc.m_mthSaveGroupDetail(obj_VO);
			if(l>0)
			{
				MessageBox.Show("保存成功!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("保存失败!","ICare",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		#endregion
		#region listView1Change
		public void m_mthChange1()
		{
			if(this.m_objViewer.listView1.SelectedItems.Count>0)
			{
			this.m_objViewer.textBox1.Text=this.m_objViewer.listView1.SelectedItems[0].SubItems[0].Text.Trim();
			this.m_objViewer.btChangeA.Tag=this.m_objViewer.listView1.SelectedItems[0].SubItems[0].Text.Trim();
			this.m_mthGetGroupByID(this.m_objViewer.listView1.SelectedItems[0].SubItems[0].Text.Trim());
			this.m_objViewer.textBox2.Text=this.m_objViewer.listView1.SelectedItems[0].SubItems[1].Text.Trim();
			
			}

		}
		public void m_mthChange2()
		{
			if(this.m_objViewer.listView2.SelectedItems.Count>0)
			{
				this.m_objViewer.textBox3.Text=this.m_objViewer.listView2.SelectedItems[0].SubItems[0].Text.Trim();
				this.m_objViewer.btChangeB.Tag=this.m_objViewer.listView2.SelectedItems[0].SubItems[0].Text.Trim();
				this.m_objViewer.textBox4.Text=this.m_objViewer.listView2.SelectedItems[0].SubItems[1].Text.Trim();
				flag =true;
				this.m_mthGetGroupDetailByID();
			
			}

		}
		private bool flag =false;
		#endregion
	}
}
