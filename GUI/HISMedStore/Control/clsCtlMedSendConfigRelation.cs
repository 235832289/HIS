using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 控制层
	///发药窗口与配药窗口的关系 的摘要说明。
	///  Create by xgpeng 2006-02-15
	/// </summary>
	public class clsCtlMedSendConfigRelation : com.digitalwave.GUI_Base.clsController_Base
	{
		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public clsCtlMedSendConfigRelation()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage=new clsDomainCtlMedSendConfigRelation();
		}
		#endregion
        clsDomainCtlMedSendConfigRelation m_objManage;
		DataTable p_dtable=null;
		/// <summary>
		/// 药房ID
		/// </summary>
		string p_strMedID="";
		#region 设置窗体对象
		frmMedSendConfigRelation m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmMedSendConfigRelation)frmMDI_Child_Base_in;
		}

		#endregion
		
		#region 获取 药房信息(名称)
		/// <summary>
		/// 获取 药房信息(名称)
		/// </summary>
		public void m_GetMedStoreInfo()
		{
             
			long lngRes=this.m_objManage.m_lngGetMedStoreInfo(out p_dtable);
			this.m_objViewer.m_cboMedStore.Items.Clear();
			for(int i1=0;i1<p_dtable.Rows.Count;i1++)
			{
			  this.m_objViewer.m_cboMedStore.Items.Add(p_dtable.Rows[i1]["medstorename_vchr"].ToString().Trim());
			}
			if(this.m_objViewer.m_cboMedStore.Items.Count!=0)
			{
			 this.m_objViewer.m_cboMedStore.SelectedIndex=0;
			}
        }
		#endregion

		#region 根据药房名称得到药房ID
		/// <summary>
		/// 根据药房名称得到药房ID
		/// </summary>
		public void m_GetMedStoreID()
		{
		  if(this.m_objViewer.m_cboMedStore.Items.Count==0)
			  return;
			for(int i1=0;i1<p_dtable.Rows.Count;i1++)
			{
				if(this.m_objViewer.m_cboMedStore.Text.Trim()==p_dtable.Rows[i1]["medstorename_vchr"].ToString().Trim())
				{
					this.m_objViewer.m_cboMedStore.Tag=p_dtable.Rows[i1]["medstoreid_chr"].ToString().Trim();
					p_strMedID= p_dtable.Rows[i1]["medstoreid_chr"].ToString().Trim();
					break;
				}
			}
			
		}
		#endregion

		#region 根据药房ID 获取窗口信息
		/// <summary>
		/// 根据药房ID 获取窗口信息
		/// </summary>
		public void m_GetMedWindowInfo()
		{
			#region 配药窗口
			int flage=1;//配药窗口
			clsOPMedStoreWin_VO[] p_objResArr=new clsOPMedStoreWin_VO[0];
			m_GetMedStoreID();
			this.m_objViewer.m_lsvConfig.Items.Clear();
			this.m_objViewer.m_lsvConfigGive.Items.Clear();
			long lngRes=this.m_objManage.m_lngGetMedWindowInfo(p_strMedID,flage,out p_objResArr);
			if(lngRes>0&&p_objResArr.Length>0)
			{
			  
				ListViewItem lsvTemp;
				for(int i1=0;i1<p_objResArr.Length;i1++)
				{
					lsvTemp=new ListViewItem(p_objResArr[i1].m_strWindowID.Trim());
                    lsvTemp.SubItems.Add(p_objResArr[i1].m_strWindowName.Trim()); 
					if(p_objResArr[i1].m_intWorkStatus==0)
					{
						lsvTemp.SubItems.Add("停止中");
						lsvTemp.BackColor=System.Drawing.Color.Red;
					}
					else
						lsvTemp.SubItems.Add("工作中");
					lsvTemp.Tag=p_objResArr[i1];
				 this.m_objViewer.m_lsvConfig.Items.Add(lsvTemp);

				}
					 	
			}
			#endregion

			#region 发药窗口
			    flage=0 ;//发药窗口
		    	clsOPMedStoreWin_VO[] p_objResArr1=new clsOPMedStoreWin_VO[0];
			    this.m_objViewer.m_lsvGive.Items.Clear();
				long lngRes1=this.m_objManage.m_lngGetMedWindowInfo(p_strMedID,flage,out p_objResArr1);
			if(lngRes1>0&&p_objResArr1.Length>0)
			{
				
				ListViewItem lsvTemp1;
				for(int i1=0;i1<p_objResArr1.Length;i1++)
				{
					lsvTemp1=new ListViewItem(p_objResArr1[i1].m_strWindowID.Trim());
					lsvTemp1.SubItems.Add(p_objResArr1[i1].m_strWindowName.Trim()); 
					if(p_objResArr1[i1].m_intWorkStatus==0)
					{
						lsvTemp1.SubItems.Add("停止中");
						lsvTemp1.BackColor=System.Drawing.Color.Red;
					}
					else
						lsvTemp1.SubItems.Add("工作中");
					lsvTemp1.Tag=p_objResArr1[i1];
					this.m_objViewer.m_lsvGive.Items.Add(lsvTemp1);
				}
			}
			#endregion
		}
		#endregion

		#region 根据配药窗口ID获取配药窗口->发药窗口 信息  
		/// <summary>
		/// 根据配药窗口ID获取配药窗口->发药窗口 信息  
		/// </summary>
		public void m_GetMedWinByID()
		{
			string p_WinID="";
			clsMedSendConfig_VO[] p_objResultArr=null;
			if(this.m_objViewer.flage==false)
			{
				if(MessageBox.Show("尚未保存修改的内容,是否保存？","系统提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					m_MovRecored();//保存记录
				}
                this.m_objViewer.flage=true;
			}
			if(this.m_objViewer.m_lsvConfig.Items.Count==0)
				return;
			if(this.m_objViewer.m_lsvConfig.SelectedItems.Count==0)
			{
			   MessageBox.Show("请选择配药窗口记录","提示");
				return;
			}
             p_WinID=this.m_objViewer.m_lsvConfig.SelectedItems[0].SubItems[0].Text.Trim();
            this.m_objViewer.m_lsvConfigGive.Items.Clear();
			long lngRes=this.m_objManage.m_lngGetMedWinByID(p_WinID,out p_objResultArr);	
			if(lngRes>0&& p_objResultArr.Length>0)
			{
				ListViewItem m_lsvTemp;
				for(int i1=0;i1<p_objResultArr.Length;i1++)
				{
				 m_lsvTemp=new ListViewItem(this.m_objViewer.m_lsvConfig.SelectedItems[0].SubItems[1].Text.Trim());
                 m_lsvTemp.SubItems.Add(p_objResultArr[i1].m_strGiveWinName);
				 m_lsvTemp.SubItems.Add(p_objResultArr[i1].m_intOrder.ToString().Trim());
                 m_lsvTemp.Tag=p_objResultArr[i1];
				 this.m_objViewer.m_lsvConfigGive.Items.Add(m_lsvTemp);
				}
			}			
		}
		#endregion

		#region 新增 配药窗口->发药窗口 关系
		/// <summary>
		/// 新增 配药窗口->发药窗口 关系
		/// </summary>
		public void m_AddMedSendGiveRelation()
		{
			int p_intSeq; //流水号
			int p_intorder=0;//关联顺序
			clsMedSendConfig_VO p_objWinArr=new clsMedSendConfig_VO();
			if(this.m_objViewer.m_lsvGive.Items.Count==0||this.m_objViewer.m_lsvConfig.Items.Count==0)
		    return;
	
			if(this.m_objViewer.m_lsvConfig.SelectedItems.Count==0)
			{
				MessageBox.Show("请选择配药窗口记录","提示");
				return;
			}
			
			if(this.m_objViewer.m_lsvGive.SelectedItems.Count==0)
			{
			 MessageBox.Show("请选择发药窗口记录","提示");
				return;
			}
			for(int i2=0;i2<this.m_objViewer.m_lsvConfigGive.Items.Count;++i2)//判断是否相同的记录
			{
				if(this.m_objViewer.m_lsvConfigGive.Items[i2].SubItems[0].Text.Trim()==this.m_objViewer.m_lsvConfig.SelectedItems[0].SubItems[1].Text.Trim()&&
					this.m_objViewer.m_lsvConfigGive.Items[i2].SubItems[1].Text.Trim()==this.m_objViewer.m_lsvGive.SelectedItems[0].SubItems[1].Text.Trim())
				{
				  MessageBox.Show("已存在相同的记录","提示");
                  this.m_objViewer.m_lsvConfigGive.Items[i2].Selected=true;
					return;
				}
			}
			
			m_GetMaxOrder(out p_intorder);//求最大关联顺序号
			p_objWinArr.m_intOrder=p_intorder;

			p_objWinArr.m_TreatWinID_chr=this.m_objViewer.m_lsvConfig.SelectedItems[0].SubItems[0].Text.Trim();
			p_objWinArr.m_strConfigWinName=this.m_objViewer.m_lsvConfig.SelectedItems[0].SubItems[1].Text.Trim();
			p_objWinArr.m_GiveWinID_chr=this.m_objViewer.m_lsvGive.SelectedItems[0].SubItems[0].Text.Trim();
			p_objWinArr.m_strGiveWinName=this.m_objViewer.m_lsvGive.SelectedItems[0].SubItems[1].Text.Trim();
			long lngRes=this.m_objManage.m_lngAddMedSendGiveRelation(out p_intSeq, p_objWinArr);
			if(lngRes>0)
			{
                p_objWinArr.m_intSeq=p_intSeq;
				ListViewItem m_lsv=new ListViewItem(m_objViewer.m_lsvConfig.SelectedItems[0].SubItems[1].Text.ToString());
                m_lsv.SubItems.Add(m_objViewer.m_lsvGive.SelectedItems[0].SubItems[1].Text.Trim());
				m_lsv.SubItems.Add(p_intorder.ToString().Trim());
				m_lsv.Tag=p_objWinArr;			
                this.m_objViewer.m_lsvConfigGive.Items.Add(m_lsv);
				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].Selected=true;
			    
			}
		}
		#endregion

		#region 获得最大的关联顺序号
		private void m_GetMaxOrder(out int p_intorder)
		{
			p_intorder=0;
		  if(this.m_objViewer.m_lsvConfigGive.Items.Count==0)
           p_intorder=1;
			if(this.m_objViewer.m_lsvConfigGive.Items.Count==1)
			{
				p_intorder=2;
				return;
			}
			for(int i1=1;i1<this.m_objViewer.m_lsvConfigGive.Items.Count;++i1)
			{
			 if(Convert.ToInt32(this.m_objViewer.m_lsvConfigGive.Items[i1-1].SubItems[2].Text.Trim())<=Convert.ToInt32(this.m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text.Trim()))
			  p_intorder=Convert.ToInt32(this.m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text.Trim())+1;
			 }
		}
		#endregion

		#region 删除 配药窗口->发药窗口 关系
		/// <summary>
		/// 删除 配药窗口->发药窗口 关系
		/// </summary>
		public void m_DelMedSendGiveRelation()
		{
			int p_intSeq=0;//流水号
			int p_intOrder=0 ;//关联顺序
			
			if(this.m_objViewer.m_lsvConfigGive.Items.Count==0)
				return;
	
			if(this.m_objViewer.m_lsvConfigGive.SelectedItems.Count==0)
			{
				MessageBox.Show("请选择配药窗口—>发药窗口记录","提示");
				return;
			}
			int index=this.m_objViewer.m_lsvConfigGive.SelectedIndices[0];
			if(this.m_objViewer.m_lsvConfigGive.SelectedItems[0].Tag==null)
				return;
			else
			{
				p_intSeq=((clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.SelectedItems[0].Tag).m_intSeq; //流水号
			    p_intOrder=((clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.SelectedItems[0].Tag).m_intOrder;
			}
			if(MessageBox.Show("你确定要删除该记录吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				return;
			long lngRes=this.m_objManage.m_thDelMedSendGiveRelation(p_intSeq);
			if(lngRes>0)
			{
				
				this.m_objViewer.m_lsvConfigGive.SelectedItems[0].Remove();
				clsMedSendConfig_VO[] p_objUpdateArr=new clsMedSendConfig_VO[this.m_objViewer.m_lsvConfigGive.Items.Count];
				if(this.m_objViewer.m_lsvConfigGive.Items.Count==0)
					return;
				if(index!=0)
					this.m_objViewer.m_lsvConfigGive.Items[index-1].Selected=true;
                else 
                    this.m_objViewer.m_lsvConfigGive.Items[index].Selected=true;
				for(int i2=0;i2<this.m_objViewer.m_lsvConfigGive.Items.Count;i2++)
				{
					if(Convert.ToInt32(this.m_objViewer.m_lsvConfigGive.Items[i2].SubItems[2].Text.ToString())>p_intOrder)
					{
					 this.m_objViewer.m_lsvConfigGive.Items[i2].SubItems[2].Text=Convert.ToString(Convert.ToInt32(this.m_objViewer.m_lsvConfigGive.Items[i2].SubItems[2].Text)-1);
                     ((clsMedSendConfig_VO)(m_objViewer.m_lsvConfigGive.Items[i2].Tag)).m_intOrder-=1;
					p_objUpdateArr[i2]=new clsMedSendConfig_VO();
					p_objUpdateArr[i2]=((clsMedSendConfig_VO)(m_objViewer.m_lsvConfigGive.Items[i2].Tag));
						if(index!=this.m_objViewer.m_lsvConfigGive.Items.Count)
						{
							clsMedSendConfig_VO[] p_objUpdateArr1=new clsMedSendConfig_VO[1];
                            p_objUpdateArr1[0]=p_objUpdateArr[i2];
							long lngRe=this.m_objManage.m_lngUpdateMovRecord( p_objUpdateArr1);
						}
					}
				}
				

			}
		}
		#endregion

		#region 向上移动记录
		/// <summary>
		/// 向上移动记录
		/// </summary>
		public void m_MoveUpRecord()
		{
			int p_intOrder=0;
			int index=0;
			clsMedSendConfig_VO p_WinArry=new clsMedSendConfig_VO();
			if(this.m_objViewer.m_lsvConfigGive.Items.Count==0||this.m_objViewer.m_lsvConfigGive.Items.Count==1)
			 return;
			if(this.m_objViewer.m_lsvConfigGive.SelectedItems.Count==0)
			{
			 MessageBox.Show("请选择要移动的记录","提示");
				return;
			}
            index=this.m_objViewer.m_lsvConfigGive.SelectedIndices[0];
			if(index!=0) 
			{
				p_WinArry=(clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.Items[index-1].Tag;
				this.m_objViewer.m_lsvConfigGive.Items[index-1].SubItems[0].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[0].Text;
				this.m_objViewer.m_lsvConfigGive.Items[index-1].SubItems[1].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[1].Text;
				//this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[2].Text= this.m_objViewer.m_lsvConfigGive.Items[index-1].SubItems[2].Text;      			    
				((clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.Items[index].Tag).m_intOrder=((clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.Items[index-1].Tag).m_intOrder;
				this.m_objViewer.m_lsvConfigGive.Items[index-1].Tag= this.m_objViewer.m_lsvConfigGive.Items[index].Tag;
      			
			//	this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[0].Text= p_WinArry.m_strConfigWinName.Trim();
				this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[1].Text= p_WinArry.m_strGiveWinName.Trim();
				p_WinArry.m_intOrder+=1;
				this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[2].Text= p_WinArry.m_intOrder.ToString().Trim();
                this.m_objViewer.m_lsvConfigGive.Items[index].Tag=p_WinArry;
				this.m_objViewer.m_lsvConfigGive.Items[index-1].Selected=true;
			}
			else
			{
				ListViewItem p_lsv=new ListViewItem();
				p_WinArry=(clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.Items[0].Tag;
				this.m_objViewer.m_lsvConfigGive.Items[0].Remove();
				for(int i1=0;i1<this.m_objViewer.m_lsvConfigGive.Items.Count;i1++)
				{
					m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text=Convert.ToString( Convert.ToInt32(m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text)-1);
                   ((clsMedSendConfig_VO)m_objViewer.m_lsvConfigGive.Items[i1].Tag).m_intOrder-=1;
				}
				//p_lsv.Text=p_WinArry.m_strConfigWinName.Trim();
				p_lsv.Text=this.m_objViewer.m_lsvConfigGive.Items[0].SubItems[0].Text;
				p_lsv.SubItems.Add(p_WinArry.m_strGiveWinName.Trim());
                p_WinArry.m_intOrder=Convert.ToInt32(this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].SubItems[2].Text)+1;
				p_lsv.SubItems.Add(p_WinArry.m_intOrder.ToString().Trim());
				p_lsv.Tag=p_WinArry;
				this.m_objViewer.m_lsvConfigGive.Items.Add(p_lsv);
				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].Selected=true;
//				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].SubItems[0].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[0].Text;
//				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].SubItems[1].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[1].Text;
//				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].SubItems[2].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[2].Text;      			    
//				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].Tag= this.m_objViewer.m_lsvConfigGive.Items[index].Tag;
//				
//				this.m_objViewer.m_lsvConfigGive.Items[0].Remove();
//				for(int i1=1;i1<this.m_objViewer.m_lsvConfigGive.Items.Count-1;i1++)
//				{
//				  m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text=Convert.ToString( Convert.ToInt32(m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text)-1);
//				}
//				
//			
			}

			
		}

        #endregion

		#region 向下移动记录
		/// <summary>
		/// 向下移动记录
		/// </summary>
		public void m_MoveDownRecord()
		{
			int p_intOrder=0;
			int index=0;
			clsMedSendConfig_VO p_WinArry=new clsMedSendConfig_VO();
			if(this.m_objViewer.m_lsvConfigGive.Items.Count==0||this.m_objViewer.m_lsvConfigGive.Items.Count==1)
				return;
			if(this.m_objViewer.m_lsvConfigGive.SelectedItems.Count==0)
			{
				MessageBox.Show("请选择要移动的记录","提示");
				return;
			}
			index=this.m_objViewer.m_lsvConfigGive.SelectedIndices[0];
			if(index!=(this.m_objViewer.m_lsvConfigGive.Items.Count-1)) 
			{
				p_WinArry=(clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.Items[index+1].Tag;
				this.m_objViewer.m_lsvConfigGive.Items[index+1].SubItems[0].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[0].Text;
				this.m_objViewer.m_lsvConfigGive.Items[index+1].SubItems[1].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[1].Text;
				//this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[2].Text= this.m_objViewer.m_lsvConfigGive.Items[index+1].SubItems[2].Text;      			    
				
				this.m_objViewer.m_lsvConfigGive.Items[index+1].Tag= this.m_objViewer.m_lsvConfigGive.Items[index].Tag;
				((clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.Items[index+1].Tag).m_intOrder=((clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.Items[index].Tag).m_intOrder+1;
      			
				//this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[0].Text= p_WinArry.m_strConfigWinName.Trim();
				this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[1].Text= p_WinArry.m_strGiveWinName.Trim();
				p_WinArry.m_intOrder-=1;
				this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[2].Text= p_WinArry.m_intOrder.ToString().Trim();
				this.m_objViewer.m_lsvConfigGive.Items[index].Tag=p_WinArry;
				this.m_objViewer.m_lsvConfigGive.Items[index+1].Selected=true;
				
			}
			else
			{  int lastCount=this.m_objViewer.m_lsvConfigGive.Items.Count-1;
				ListViewItem p_lsv=new ListViewItem();
				p_WinArry=(clsMedSendConfig_VO)this.m_objViewer.m_lsvConfigGive.Items[lastCount].Tag;
				this.m_objViewer.m_lsvConfigGive.Items[lastCount].Remove();
				for(int i1=0;i1<this.m_objViewer.m_lsvConfigGive.Items.Count;i1++)
				{
					m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text=Convert.ToString( Convert.ToInt32(m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text)+1);
				    ((clsMedSendConfig_VO)m_objViewer.m_lsvConfigGive.Items[i1].Tag).m_intOrder+=1;
				}
			//	p_lsv.Text=p_WinArry.m_strConfigWinName.Trim();
                p_lsv.Text=m_objViewer.m_lsvConfigGive.Items[0].SubItems[0].Text.Trim();
				p_lsv.SubItems.Add(p_WinArry.m_strGiveWinName.Trim());
				p_WinArry.m_intOrder=1;
				p_lsv.SubItems.Add(p_WinArry.m_intOrder.ToString().Trim());
				p_lsv.Tag=p_WinArry;
				this.m_objViewer.m_lsvConfigGive.Items.Insert(0,p_lsv);
				this.m_objViewer.m_lsvConfigGive.Items[0].Selected=true;
				//				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].SubItems[0].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[0].Text;
				//				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].SubItems[1].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[1].Text;
				//				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].SubItems[2].Text= this.m_objViewer.m_lsvConfigGive.Items[index].SubItems[2].Text;      			    
				//				this.m_objViewer.m_lsvConfigGive.Items[this.m_objViewer.m_lsvConfigGive.Items.Count-1].Tag= this.m_objViewer.m_lsvConfigGive.Items[index].Tag;
				//				
				//				this.m_objViewer.m_lsvConfigGive.Items[0].Remove();
				//				for(int i1=1;i1<this.m_objViewer.m_lsvConfigGive.Items.Count-1;i1++)
				//				{
				//				  m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text=Convert.ToString( Convert.ToInt32(m_objViewer.m_lsvConfigGive.Items[i1].SubItems[2].Text)-1);
				//				}
				//				
				//			
			}

			
		}
		#endregion

		#region 保存 批量移动记录
		/// <summary>
		/// 保存 批量移动记录
		/// </summary>
		public void m_MovRecored()
		{
			clsMedSendConfig_VO[] p_objUpdateArr=new clsMedSendConfig_VO[this.m_objViewer.m_lsvConfigGive.Items.Count];
			for(int i1=0;i1<this.m_objViewer.m_lsvConfigGive.Items.Count;++i1)
			{
			  p_objUpdateArr[i1]=new clsMedSendConfig_VO();
              p_objUpdateArr[i1]=((clsMedSendConfig_VO)(m_objViewer.m_lsvConfigGive.Items[i1].Tag));  
			}
		   long lngRes=this.m_objManage.m_lngUpdateMovRecord( p_objUpdateArr);
			if(lngRes<=0)
			{
			 MessageBox.Show("保存失败","系统提示");
				return;
			}
           this.m_objViewer.flage=true;
		}
		#endregion

	}
}
