using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房窗口控制类
	/// Create by kong 2004-07-06
	/// </summary>
	public class clsControlMedStoreWin : com.digitalwave.GUI_Base.clsController_Base
	{
		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public clsControlMedStoreWin()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDomainControlMedStoreBseInfo();
		}
		#endregion

		#region 变量
		clsDomainControlMedStoreBseInfo m_objManage = null;
		/// <summary>
		/// 药房窗口数据
		/// </summary>
		 public clsOPMedStoreWin_VO m_objItem;
		/// <summary>
		/// 当前选择行
		/// </summary>
		private int m_SelRow = 0;
       
		#endregion

		#region 设置窗体对象
		frmMedStoreWin m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmMedStoreWin)frmMDI_Child_Base_in;
		}

		#endregion

		#region 列表操作

		#region 向列表插入一条记录
		/// <summary>
		/// 向列表插入一条数据
		/// </summary>
		/// <param name="objItem">药房窗口数据</param>
		private void m_mthInsertDetail(clsOPMedStoreWin_VO objItem)
		{
			if(objItem != null)
			{
				
				ListViewItem lsvItem = new ListViewItem(objItem.m_strWindowID.Trim());
				lsvItem.SubItems.Add(objItem.m_objMedStore.m_strMedStoreName.Trim());
				lsvItem.SubItems.Add(objItem.m_strWindowName.Trim());
                if(objItem.m_intWindowType==0)
                 lsvItem.SubItems.Add("发药窗口");
				else
                  lsvItem.SubItems.Add("配药窗口");
				if(objItem.m_intWorkStatus==0)
					lsvItem.SubItems.Add("停止中");
				else
					lsvItem.SubItems.Add("工作中");

                if (objItem.m_strWinprop == "1")
                {
                    lsvItem.SubItems.Add("专用");
                }
                else
                {
                    lsvItem.SubItems.Add("普通");
                }

				lsvItem.Tag = objItem;
                
				this.m_objViewer.m_lsvDetail.Items.Add(lsvItem);
                 this.m_objViewer.m_lsvDetail.Items[this.m_objViewer.m_lsvDetail.Items.Count-1].Selected=true;
			}
		}
		#endregion

		#region 修改列表数据
		/// <summary>
		/// 修改列表数据
		/// </summary>
		/// <param name="objItem">药房窗口数据</param>
		private void m_mthModifyDetail(clsOPMedStoreWin_VO objItem)
		{
           
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[1].Text = this.m_objViewer.m_cboMedStore.Text.Trim();
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[2].Text = objItem.m_strWindowName.Trim();
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[3].Text = this.m_objViewer.m_cboWinStyle.Text.Trim();
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[4].Text = this.m_objViewer.m_cboWorkStatus.Text.Trim();
            this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[5].Text = this.m_objViewer.cboWinprop.Text.Trim();
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].Tag = objItem;
		}
		#endregion

		#endregion

		#region 获得列表数据
		/// <summary>
		/// 获得列表数据
		/// </summary>
		public void m_mthGetDetailList()
		{
			this.m_objViewer.m_lsvDetail.Items.Clear();
			clsOPMedStoreWin_VO[] objItemArr = new clsOPMedStoreWin_VO[0];
			long lngRes = 0;

			lngRes = this.m_objManage.m_lngGetMedStoreWinList(this.m_objViewer.m_cboWindowType.SelectedIndex,out objItemArr);
			if(lngRes>0 && objItemArr.Length>0)
			{
				for(int i1=0;i1<objItemArr.Length;i1++)
				{
					m_mthInsertDetail(objItemArr[i1]);
				}
                
			}
		}
		#endregion

		#region 设置窗体数据
		/// <summary>
		/// 设置窗体数据
		/// </summary>
		/// <param name="objItem">仓库数据</param>
		public void m_mthSetViewInfo(clsOPMedStoreWin_VO objItem)
		{
			this.m_objItem = objItem;

			if(this.m_objItem == null)
			{
				m_mthClear();

                //if(this.m_objViewer.m_cboMedStore.Items.Count >0)
                //{
                //    this.m_objViewer.m_cboMedStore.SelectedIndex =0;
                //}
                //if(this.m_objViewer.m_cboWinStyle.Items.Count >0)
                //{
                //    this.m_objViewer.m_cboWinStyle.SelectedIndex =0;
                //}
				this.m_objViewer.m_cboMedStore.Focus();
                

			}
			else
			{
				m_mthClear();
				int index = m_intGetMedStoreIndex(this.m_objItem.m_objMedStore);
				this.m_objViewer.m_cboMedStore.SelectedIndex = index;
				this.m_objViewer.m_txtWinName.Text = this.m_objItem.m_strWindowName.Trim();
                if (this.m_objItem.m_intWindowType == 0)
                    this.m_objViewer.m_cboWinStyle.SelectedIndex = 0;
                else if (this.m_objItem.m_intWindowType == 1)
                    this.m_objViewer.m_cboWinStyle.SelectedIndex = 1;          
				this.m_objViewer.m_cboWorkStatus.Text=this.m_objViewer.m_lsvDetail.Items[this.m_SelRow].SubItems[4].Text;

                if (this.m_objItem.m_strWinprop == "1")
                {
                    this.m_objViewer.cboWinprop.SelectedIndex = 1;
                }
                else
                {
                    this.m_objViewer.cboWinprop.SelectedIndex = 0;
                }

				this.m_objViewer.m_txtWinName.Focus();
			}
		}
		#endregion

		#region 填充药房选择项
		/// <summary>
		/// 填充药房选择项
		/// </summary>
		private void m_mthGetMedStore()
		{
			this.m_objViewer.m_cboMedStore.Items.Clear();

			clsMedStore_VO[] objItems = new clsMedStore_VO[0];
			long lngRes = 0;

			lngRes = this.m_objManage.m_lngGetMedStoreList(out objItems);

			if(lngRes>0 && objItems.Length>0)
			{
				for(int i=0;i<objItems.Length;i++)
				{
					this.m_objViewer.m_cboMedStore.Items.Add(objItems[i].m_strMedStoreName.Trim());
				}
				this.m_objViewer.m_cboMedStore.Tag = objItems;
				this.m_objViewer.m_cboMedStore.SelectedIndex = 0;
			}
		}
		#endregion

		#region 查找药房选项中对应的索引
		/// <summary>
		/// 查找药房选项中对应的索引
		/// </summary>
		/// <param name="objItem">需查询的药房</param>
		/// <returns></returns>
		private int m_intGetMedStoreIndex(clsMedStore_VO objItem)
		{
			clsMedStore_VO[] objItems = new clsMedStore_VO[0];

			if(this.m_objViewer.m_cboMedStore.Tag == null || this.m_objViewer.m_cboMedStore.Items.Count <=0)
				return -1;

			objItems = (clsMedStore_VO[])this.m_objViewer.m_cboMedStore.Tag;
			for(int i=0;i<objItems.Length;i++)
			{
				if(objItem.m_strMedStoreID.Trim() == objItems[i].m_strMedStoreID.Trim())
					return i;
			}

			return -1;
		}
		#endregion

		#region 窗体初始化
		/// <summary>
		/// 窗体初始化
		/// </summary>
		public void m_mthInit()
		{
			m_mthGetMedStore();
			m_mthGetDetailList();
			m_mthSetViewInfo(null);
		}
		#endregion
		#region 判断控件是否为空
		private bool m_Judge()
		{
			if(this.m_objViewer.m_cboMedStore.Text=="")
			{
				MessageBox.Show("请选择药房名称","提示");
				this.m_objViewer.m_cboMedStore.Focus();
				return false;
			}
			if(this.m_objViewer.m_txtWinName.Text=="")
			{
				MessageBox.Show("窗口名称不能为空","提示");
			    this.m_objViewer.m_txtWinName.Focus();
				return false;
			}
			if(this.m_objViewer.m_cboWorkStatus.Text=="")
			{
				MessageBox.Show("请选择工作状态","提示");
				this.m_objViewer.m_cboWorkStatus.Focus();
				return false;
			}
            if (this.m_objViewer.m_cboWinStyle.Text == "")
            {
                MessageBox.Show("请选择窗口类型", "提示");
                this.m_objViewer.m_cboWinStyle.Focus();
                return false;
            }

            if (this.m_objViewer.cboWinprop.Text.Trim() == "")
            {
                MessageBox.Show("请选择窗口属性", "提示");
                this.m_objViewer.m_cboWinStyle.Focus();
                return false;
            }

			if(this.m_objItem==null) 
			{
				for(int i1=0;i1<this.m_objViewer.m_lsvDetail.Items.Count;++i1)
				{
			 
					if(this.m_objViewer.m_cboMedStore.Text.Trim()==m_objViewer.m_lsvDetail.Items[i1].SubItems[1].Text.Trim()&&
                        this.m_objViewer.m_txtWinName.Text.Trim() == m_objViewer.m_lsvDetail.Items[i1].SubItems[2].Text.Trim() &&this.m_objViewer.m_cboWinStyle.Text==m_objViewer.m_lsvDetail.Items[i1].SubItems[3].Text.Trim())
					{
						MessageBox.Show("药房名称与窗口名称以及窗口类型不能存在相同的记录","提示");
						this.m_objViewer.m_cboMedStore.Focus(); 
                        m_objViewer.m_lsvDetail.Items[i1].Selected=true;
						return false;
					}
				}
			}
			else
			{
                if (this.m_objViewer.m_lsvDetail.SelectedItems.Count == 0)
                {
                   
                    this.m_mthClear();
                    MessageBox.Show("请选择要修改的记录 ","提示");
                    return false;
                }
				for(int i1=0;i1<this.m_objViewer.m_lsvDetail.Items.Count;++i1)
				{
					if(this.m_objViewer.m_cboMedStore.Text.Trim()==m_objViewer.m_lsvDetail.Items[i1].SubItems[1].Text.Trim()&&
						this.m_objViewer.m_txtWinName.Text.Trim()==m_objViewer.m_lsvDetail.Items[i1].SubItems[2].Text.Trim()&&
						this.m_objViewer.m_lsvDetail.SelectedItems[0].Index!=i1&&this.m_objViewer.m_cboWinStyle.Text==m_objViewer.m_lsvDetail.Items[i1].SubItems[3].Text.Trim())		
					{
                        MessageBox.Show("药房名称与窗口名称以及窗口类型不能存在相同的记录", "提示");
						this.m_objViewer.m_cboMedStore.Focus(); 
						m_objViewer.m_lsvDetail.Items[i1].Selected=true;
						return false;
					}
				}
			}
			return true;
		}
		#endregion
		#region 保存数据
		/// <summary>
		/// 保存数据
		/// </summary>
		public void m_mthSave()
		{
			if(!m_blnCheckValue())
			{
				return;
			}
			if(!m_Judge())
			{
			    return;
			}

			if(this.m_objItem == null)
			{
				m_mthDoAddNew();
				m_mthClear();
				this.m_objViewer.m_cboMedStore.Focus();
				//this.m_objViewer.m_cboMedStore.SelectedIndex=0;
			}
			else 
			{
				m_mthDoUpdate();
				m_mthClear();
			}
		}
		#endregion

		#region 明细列表双击
		/// <summary>
		/// 列表双击事件
		/// </summary>
		public void m_mthDetailSel()
		{
			if(this.m_objViewer.m_lsvDetail.SelectedItems.Count>0)
			{
				if(this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag != null)
				{
					clsOPMedStoreWin_VO objItem = (clsOPMedStoreWin_VO)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag;
					this.m_SelRow = this.m_objViewer.m_lsvDetail.SelectedItems[0].Index;
					m_mthSetViewInfo(objItem);
				}
               
			}
		}
		#endregion

		#region 保存新增
		/// <summary>
		/// 保存新增
		/// </summary>
		private void m_mthDoAddNew()
		{
			clsOPMedStoreWin_VO objItem = new clsOPMedStoreWin_VO();
			objItem.m_objMedStore = new clsMedStore_VO();

			string strID = "";
			long lngRes = this.m_objManage.m_lngGetMedStoreWinID(out strID);

			objItem.m_strWindowID = strID.Trim();
			objItem.m_strWindowName = this.m_objViewer.m_txtWinName.Text.Trim();
            objItem.m_intWindowType=this.m_objViewer.m_cboWinStyle.SelectedIndex;
			objItem.m_intWorkStatus=this.m_objViewer.m_cboWorkStatus.SelectedIndex;
            objItem.m_strWinprop = this.m_objViewer.cboWinprop.SelectedIndex.ToString();
			clsMedStore_VO[] objItems = (clsMedStore_VO[])this.m_objViewer.m_cboMedStore.Tag;
            objItem.m_objMedStore = objItems[this.m_objViewer.m_cboMedStore.SelectedIndex];

			lngRes = 0;
			lngRes = this.m_objManage.m_lngAddNewMedStoreWin(objItem);

			if(lngRes >0)
			{
				m_mthInsertDetail(objItem);
			}
			else
			{
				MessageBox.Show("数据保存出错，请与管理员联系","系统提示",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
		#endregion

		#region 保存修改
		/// <summary>
		/// 保存修改
		/// </summary>
		private void m_mthDoUpdate()
		{
			this.m_objItem.m_strWindowName = this.m_objViewer.m_txtWinName.Text.Trim();
			clsMedStore_VO[] objItems = (clsMedStore_VO[])this.m_objViewer.m_cboMedStore.Tag;
			this.m_objItem.m_objMedStore = objItems[this.m_objViewer.m_cboMedStore.SelectedIndex];
			this.m_objItem.m_intWindowType = this.m_objViewer.m_cboWinStyle.SelectedIndex;
			this.m_objItem.m_intWorkStatus = this.m_objViewer.m_cboWorkStatus.SelectedIndex;
            this.m_objItem.m_strWinprop = this.m_objViewer.cboWinprop.SelectedIndex.ToString();
            if (this.m_objViewer.m_lsvDetail.Items.Count<= m_SelRow)
            {
                MessageBox.Show("修改失败，请重新选择记录", "系统提示");
                return;
            }
            if (this.m_objViewer.m_lsvDetail.SelectedItems.Count==0)
            {
                MessageBox.Show("请选择要修改的记录", "系统提示");
                return;
            }
            if (this.m_objViewer.m_lsvDetail.SelectedIndices[0] != m_SelRow)
            {
                MessageBox.Show("请重新选择记录", "系统提示");
                return;
            }
			long lngRes = this.m_objManage.m_lngUpdMedStoreWin(this.m_objItem);
			
			if(lngRes >0)
			{
				m_mthModifyDetail(this.m_objItem);
			}
		}
		#endregion

		#region 保存删除
		/// <summary>
		/// 保存删除
		/// </summary>
		public void m_mthDoDelete()
		{
			if(this.m_objViewer.m_lsvDetail.SelectedItems.Count>0)
			{
				if(MessageBox.Show("你确定要删除该记录吗？","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				{
				   return;
				}
				if(this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag != null)
				{
					clsOPMedStoreWin_VO objItem = new clsOPMedStoreWin_VO();
					objItem = (clsOPMedStoreWin_VO)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag;

					long lngRes = this.m_objManage.m_lngDeleteMedStoreWin(objItem.m_strWindowID.Trim());
					if(lngRes>0)
					{
						this.m_objViewer.m_lsvDetail.SelectedItems[0].Remove();
						m_mthClear();
					}
					m_SelRow=0;
				}
			}
			else
			{
				MessageBox.Show("请选择需删除的项！","系统提示");
			}
			
		}
		#endregion

		#region 检测输入
		/// <summary>
		/// 检测输入
		/// </summary>
		/// <returns></returns>
		private bool m_blnCheckValue()
		{
			bool blnResult = true;

			if(this.m_objViewer.m_cboMedStore.SelectedIndex < 0 || this.m_objViewer.m_cboMedStore.Items.Count <=0)
			{
				MessageBox.Show("请选择药房。\n如无药房信息，请与系统管理员联系！","系统提示",
					MessageBoxButtons.OK,MessageBoxIcon.Warning);
				blnResult = false;
			}
			if(this.m_objViewer.m_txtWinName.Text.Trim() == "")
			{
				this.m_ephHandler.m_mthAddControl(this.m_objViewer.m_txtWinName);
				blnResult = false;
			}

			if(!blnResult)
			{
				this.m_ephHandler.m_mthShowControlsErrorProvider();
				this.m_ephHandler.m_mthClearControl();
			}

			return blnResult;
		}
		#endregion

		#region 清空编辑框数据
		/// <summary>
		/// 清除编辑框数据
		/// </summary>
		private void m_mthClear()
		{
			this.m_objViewer.m_txtWinName.Clear();

			this.m_objViewer.m_cboMedStore.SelectedIndex = -1;
			this.m_objViewer.m_cboWorkStatus.SelectedIndex=-1;
            if (this.m_objViewer.m_cboWinStyle.Enabled)
            {
                this.m_objViewer.m_cboWinStyle.SelectedIndex = -1;
            }
            this.m_objViewer.cboWinprop.SelectedIndex = 0;
		}
		#endregion
	}
}
