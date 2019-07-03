using System;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll


namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房单据类型设置控制类
	/// Create by kong 2004-07-05
	/// </summary>
	public class clsControlMedStoreOrdType : clsController_Base
	{
		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public clsControlMedStoreOrdType()
		{
			this.m_objManage = new clsDomainControlMedStoreBseInfo();
		}
		#endregion

		#region 变量
		clsDomainControlMedStoreBseInfo m_objManage = null;
		clsMedStoreOrdType_VO m_objItem;
		/// <summary>
		/// 当前选择行
		/// </summary>
		private int m_SelRow = 0;
		#endregion

		#region 设置窗体对象
		frmMedStoreOrdType m_objViewer;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmMedStoreOrdType)frmMDI_Child_Base_in;
		}
		#endregion

		#region 列表操作

		#region 向列表插入一条记录
		/// <summary>
		/// 向列表插入一条数据
		/// </summary>
		/// <param name="objItem">药房单据类型数据</param>
		private void m_mthInsertDetail(clsMedStoreOrdType_VO objItem)
		{
			if(objItem != null)
			{
				string strSign = "";
				
				if(objItem.m_intSign == 1)
				{
					strSign = "药房进药";
				}
				else if(objItem.m_intSign == 2)
				{
					strSign = "药房出药";
				}
				else
				{
					strSign = "药房调拔";
				}

				ListViewItem lsvItem = new ListViewItem(objItem.m_strMedStoreOrdTypeID.Trim());
				lsvItem.SubItems.Add(objItem.m_strMedStoreOrdTypeName.Trim());
				lsvItem.SubItems.Add(strSign);
                lsvItem.SubItems.Add(objItem.m_strBEGINSTR_CHR.Trim());
                if (objItem.m_intSTORAGESIGN == 1)
                {
                    lsvItem.SubItems.Add("是");
                }
                else
                {
                    lsvItem.SubItems.Add("否");
                }
				lsvItem.Tag = objItem;

				this.m_objViewer.m_lsvDetail.Items.Add(lsvItem);
			}
		}
		#endregion

		#region 修改列表数据
		/// <summary>
		/// 修改列表数据
		/// </summary>
		/// <param name="objItem">药房单据类型数据</param>
		private void m_mthModifyDetail(clsMedStoreOrdType_VO objItem)
		{
			string strSign = "";
				
			if(objItem.m_intSign == 1)
			{
				strSign = "药房进药";
			}
			else
			{
				strSign = "药房出药";
			}

			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[1].Text = objItem.m_strMedStoreOrdTypeName.Trim();
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[2].Text = strSign;
            this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[3].Text = objItem.m_strBEGINSTR_CHR;
            if (objItem.m_intSTORAGESIGN == 1)
            {
                this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[4].Text = "是";
            }
            else
            {
                this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[4].Text = "否";
            }
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
			clsMedStoreOrdType_VO[] objItemArr = new clsMedStoreOrdType_VO[0];
			long lngRes = 0;

			lngRes = this.m_objManage.m_lngGetMedStoreOrdTypeList(out objItemArr);
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
		public void m_mthSetViewInfo(clsMedStoreOrdType_VO objItem)
		{
			this.m_objItem = objItem;

			if(this.m_objItem == null)
			{
				m_mthClear();
				if(this.m_objViewer.m_cboSign.Items.Count >0)
				{
					this.m_objViewer.m_cboSign.SelectedIndex = 0;
				}
				this.m_objViewer.m_txtID.Focus();
			}
			else
			{
				m_mthClear();
				this.m_objViewer.m_txtID.Text = this.m_objItem.m_strMedStoreOrdTypeID.Trim();
				this.m_objViewer.m_txtName.Text = this.m_objItem.m_strMedStoreOrdTypeName.Trim();
				this.m_objViewer.m_cboSign.SelectedIndex = this.m_objItem.m_intSign - 1;
                this.m_objViewer.textBox1.Text = this.m_objItem.m_strBEGINSTR_CHR;
                if (this.m_objItem.m_intSTORAGESIGN == 1)
                {
                    this.m_objViewer.checkBox1.Checked = true;
                }
                else
                {
                    this.m_objViewer.checkBox1.Checked = false;
                }
				this.m_objViewer.m_txtID.Enabled = false;
				this.m_objViewer.m_txtName.Focus();
			}
		}
		#endregion

		#region 窗体初始化
		/// <summary>
		/// 窗体初始化
		/// </summary>
		public void m_mthInit()
		{
			m_mthGetDetailList();
			m_mthSetViewInfo(null);
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

			if(this.m_objItem == null)
			{
				m_mthDoAddNew();
				m_mthClear();
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
					clsMedStoreOrdType_VO objItem = (clsMedStoreOrdType_VO)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag;
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
			long lngRes = 0;
			string strID;
			lngRes = this.m_objManage.m_lngGetMedStoreOrdTypeID(out strID);
			clsMedStoreOrdType_VO objItem = new clsMedStoreOrdType_VO();
			objItem.m_strMedStoreOrdTypeID = strID;
			objItem.m_strMedStoreOrdTypeName = this.m_objViewer.m_txtName.Text.Trim();
			objItem.m_intSign = this.m_objViewer.m_cboSign.SelectedIndex + 1;
            objItem.m_strBEGINSTR_CHR = this.m_objViewer.textBox1.Text.Trim();
            if(this.m_objViewer.checkBox1.Checked==true)
                objItem.m_intSTORAGESIGN = 1;
            else
                objItem.m_intSTORAGESIGN = 0;
			lngRes = this.m_objManage.m_lngAddNewMedStoreOrdType(objItem);

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
			this.m_objItem.m_strMedStoreOrdTypeName = this.m_objViewer.m_txtName.Text.Trim();
			this.m_objItem.m_intSign = this.m_objViewer.m_cboSign.SelectedIndex + 1;
            if(this.m_objViewer.checkBox1.Checked==true)
                this.m_objItem.m_intSTORAGESIGN = 1;
            else
                this.m_objItem.m_intSTORAGESIGN = 0;
            this.m_objItem.m_strBEGINSTR_CHR = this.m_objViewer.textBox1.Text;
			long lngRes = this.m_objManage.m_lngUpdMedStoreOrdTypeByID(this.m_objItem);
			
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
				if(this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag != null)
				{
					clsMedStoreOrdType_VO objItem = new clsMedStoreOrdType_VO();
					objItem = (clsMedStoreOrdType_VO)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag;

					long lngRes = this.m_objManage.m_lngDeleteMedStoreOrdType(objItem.m_strMedStoreOrdTypeID.Trim());

					if(lngRes>0)
					{
						this.m_objViewer.m_lsvDetail.SelectedItems[0].Remove();
					}
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
			if(this.m_objViewer.m_txtName.Text.Trim() == "")
			{
				this.m_ephHandler.m_mthAddControl(this.m_objViewer.m_txtName);
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
			this.m_objViewer.m_txtID.Clear();
			this.m_objViewer.m_txtName.Clear();
			this.m_objViewer.m_cboSign.SelectedIndex = -1;
            this.m_objViewer.checkBox1.Checked = false;
            this.m_objViewer.textBox1.Text = "";
		}
		#endregion
	}
}
