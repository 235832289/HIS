using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
using com.digitalwave.iCare.ValueObject;	//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药品领药申请窗体控制
	/// Create by kong 2004-07-13
	/// </summary>
	public class clsControlMedStoreMedAppl : clsController_Base
	{
		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public clsControlMedStoreMedAppl()
		{
			m_objManage = new clsDomainControlMedStore();
			m_objMedStore = new clsMedStore_VO();
			m_objOperator = new clsEmployeeVO();
			m_objStorages = new clsStorage_VO[0];
			m_objDoAddNewArr = new clsMedStoreMedApplDe_VO[0];
			m_objDoUpdateArr = new clsMedStoreMedApplDe_VO[0];
			m_objDoDeleteArr = new clsMedStoreMedApplDe_VO[0];
		}
		#endregion

		#region 变量
		clsDomainControlMedStore m_objManage = null;
		/// <summary>
		/// 记录单数据
		/// </summary>
		clsMedStoreMedAppl_VO m_objItem;
		/// <summary>
		/// 明细数据
		/// </summary>
		clsMedStoreMedApplDe_VO m_objDetail;
		/// <summary>
		/// 药房
		/// </summary>
		clsMedStore_VO m_objMedStore;
		/// <summary>
		/// 操作员
		/// </summary>
		clsEmployeeVO m_objOperator;
		clsStorage_VO[] m_objStorages;

		/// <summary>
		/// 是否为插入明细
		/// </summary>
		private bool m_blnIsInsert = false;

		/// <summary>
		/// 新增队列
		/// </summary>
		private clsMedStoreMedApplDe_VO[] m_objDoAddNewArr;

		/// <summary>
		/// 修改队列
		/// </summary>
		private clsMedStoreMedApplDe_VO[] m_objDoUpdateArr;

		/// <summary>
		/// 删除队列
		/// </summary>
		private clsMedStoreMedApplDe_VO[] m_objDoDeleteArr;

		/// <summary>
		/// 行号
		/// </summary>
		private int m_RowNo = 0;

		/// <summary>
		/// 当前选择行
		/// </summary>
		private int m_SelRow = 0;

		KeyEventHandler keyDown;
		EventHandler doubleClick;
		#endregion

		#region 设置窗体对象
		frmMedStoreMedAppl m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmMedStoreMedAppl)frmMDI_Child_Base_in;
		}

		#endregion

		#region 获得操作员 
		/// <summary>
		/// 获得操作员
		/// </summary>
		private void m_mthGetOperator()
		{
			string strOperID = "0000001";
			string strOperName = clsPublicParm.s_strGetEmpInfo("lastname_vchr","empid_chr",strOperID);

			m_objOperator.strEmpID = strOperID;
			m_objOperator.strLastName = strOperName;

		}
		#endregion

		#region 获得药房
		/// <summary>
		/// 获得药房
		/// </summary>
		private void m_mthGetMedStore()
		{
			long lngRes;
			clsMedStore_VO[] objMedStorearr = new clsMedStore_VO[0];
			clsDomainControlMedStoreBseInfo objManage = new clsDomainControlMedStoreBseInfo();
			lngRes = objManage.m_lngGetMedStoreList(out objMedStorearr);
			
			if(objMedStorearr.Length > 0)
			{
				m_objMedStore = objMedStorearr[0];
				m_objViewer.m_txtMedStore.Text = m_objMedStore.m_strMedStoreName.Trim();
				m_objViewer.m_txtMedStore.Tag = m_objMedStore;
			}
			else
			{
				m_objViewer.m_txtMedStore.Text = "获得库房出错";
				m_objViewer.m_txtMedStore.Tag = null;
			}
		}
		#endregion

		#region 获得药库
		/// <summary>
		/// 获得药库
		/// </summary>
		private void m_mthGetStorage()
		{
			long lngRes;
			lngRes = clsPublicParm.s_lngGetStorageList(out this.m_objStorages);

			m_objViewer.m_cboStorage.Items.Clear();

			if(lngRes <= 0 || this.m_objStorages.Length <=0)
				return;

			for(int i=0;i<this.m_objStorages.Length;i++)
			{
				m_objViewer.m_cboStorage.Items.Add(this.m_objStorages[i].m_strStroageName.Trim());
			}
			m_objViewer.m_cboStorage.Tag = this.m_objStorages;
		}
		#endregion

		#region 查找药库列表对应的位置
		/// <summary>
		/// 查找药库列表对应的位置
		/// </summary>
		/// <param name="strID">药库代码</param>
		/// <returns></returns>
		private int m_intGetStorageIndex(string strID)
		{
			int index =0;

			for(int i=0;i<this.m_objStorages.Length;i++)
			{
				if(this.m_objStorages[i].m_strStroageID.Trim() == strID.Trim())
				{
					index = i;
					break;
				}
			}

			return index;
		}
		#endregion

		#region 获得当前入库单的审核和末审核列表
		/// <summary>
		/// 获得当前入库单的审核和末审核列表
		/// </summary>
		private void m_mthGetUnAndEnDetailList()
		{
			long lngRes = 0;
			clsMedStoreMedAppl_VO[] objItems = new clsMedStoreMedAppl_VO[0];

			this.m_objViewer.m_lsvUnAsk.Items.Clear();
			lngRes = this.m_objManage.m_lngGetMedApplByStatus(1,out objItems);
			if(lngRes >0 && objItems.Length >0)
			{
				for(int i1=0;i1<objItems.Length;i1++)
				{
					System.Windows.Forms.ListViewItem lsvItem = new System.Windows.Forms.ListViewItem();
					lsvItem.Text = objItems[i1].m_strMedApplID.Trim();
					lsvItem.SubItems.Add(objItems[i1].m_objStorage.m_strStroageName);
					lsvItem.SubItems.Add(objItems[i1].m_strApplDate);
					lsvItem.Tag = objItems[i1];
					this.m_objViewer.m_lsvUnAsk.Items.Add(lsvItem);
				}
			}

			this.m_objViewer.m_lsvEnAsk.Items.Clear();
			objItems = new clsMedStoreMedAppl_VO[0];
			lngRes = this.m_objManage.m_lngGetMedApplByStatus(2,out objItems);
			if(lngRes>0 && objItems.Length >0)
			{
				for(int i1=0;i1<objItems.Length;i1++)
				{
					System.Windows.Forms.ListViewItem lsvItem = new System.Windows.Forms.ListViewItem();
					lsvItem.Text = objItems[i1].m_strMedApplID.Trim();
					lsvItem.SubItems.Add(objItems[i1].m_objStorage.m_strStroageName);
					lsvItem.SubItems.Add(objItems[i1].m_strApplDate);
					lsvItem.Tag = objItems[i1];
					this.m_objViewer.m_lsvEnAsk.Items.Add(lsvItem);
				}
			}


		}
		#endregion

		#region 清空操作

		#region 清空记录框数据
		/// <summary>
		/// 清空记录框 
		/// </summary>
		private void m_mthClearRecordPanl()
		{
			this.m_objViewer.m_dtpCreateDate.Value = clsPublicParm.s_datGetServerDate();
			this.m_objViewer.m_txtOrdID.Clear();
			this.m_objViewer.m_txtMedStore.Clear();
			this.m_objViewer.m_txtMemo.Clear();
			this.m_objViewer.m_cboStorage.SelectedIndex = -1;
		}
		#endregion

		#region 清空药品输入框数据
		/// <summary>
		/// 清空药品输入框数据
		/// </summary>
		private void m_mthClearDetailInput()
		{
			this.m_objViewer.m_txtMedID.Clear();
			this.m_objViewer.m_txtMedName.Clear();
			this.m_objViewer.m_txtMedSpec.Clear();
			this.m_objViewer.m_txtUnit.Clear();
			this.m_objViewer.m_txtQty.Clear();
			this.m_objViewer.m_txtQty.Text = "0";
		}
		#endregion

		#endregion

		#region 锁定与解锁

		#region 锁定药库选择项
		/// <summary>
		/// 锁定药库选择项
		/// </summary>
		private void m_mthLockStorage()
		{
			this.m_objViewer.m_cboStorage.Enabled = false;
		}
		#endregion

		#region 解锁药库选择项
		/// <summary>
		/// 解锁药库选择项
		/// </summary>
		private void m_mthUnLockStorage()
		{
			this.m_objViewer.m_cboStorage.Enabled = true;
		}
		#endregion

		#region 锁定记录框
		/// <summary>
		/// 锁定记录框
		/// </summary>
		private void m_mthLockRecord()
		{
			this.m_objViewer.m_dtpCreateDate.Enabled = false;
			this.m_objViewer.m_txtMemo.Enabled = false;
		}
		#endregion

		#region 解锁记录框
		/// <summary>
		/// 解锁记录框
		/// </summary>
		private void m_mthUnLockRecord()
		{
			this.m_objViewer.m_dtpCreateDate.Enabled = true;
			this.m_objViewer.m_txtMemo.Enabled = true;
		}
		#endregion

		#region 锁定明细列表
		/// <summary>
		/// 锁定明细列表，使之不能操作
		/// </summary>
		private void m_mthLockDetailList()
		{
			if(keyDown != null)
			{
				this.m_objViewer.m_lsvDetail.KeyDown -= keyDown;

			}
			if(doubleClick != null)
			{
				this.m_objViewer.m_lsvDetail.DoubleClick -= doubleClick;

			}
		}
		#endregion		

		#region 解锁明细列表
		/// <summary>
		/// 解锁明细列表，可操作
		/// </summary>
		private void m_mthUnLockDetailList()
		{
			if(keyDown == null)
			{
				keyDown = new KeyEventHandler(this.m_objViewer.m_lsvDetail_KeyDown);
				
				this.m_objViewer.m_lsvDetail.KeyDown += keyDown;

			}
			if(doubleClick == null)
			{
				doubleClick = new EventHandler(this.m_objViewer.m_lsvDetail_DoubleClick);
				
				this.m_objViewer.m_lsvDetail.DoubleClick += doubleClick;

			}
		}
		#endregion

		#region 锁定药品输入框
		/// <summary>
		/// 锁定药品输入框
		/// </summary>
		private void m_mthLockMedicineInput()
		{
			this.m_objViewer.m_txtMedID.Enabled = false;
		}
		#endregion

		#region 解锁药品输入框
		/// <summary>
		/// 解锁药品输入框
		/// </summary>
		private void m_mthUnLockMedicineInput()
		{
			this.m_objViewer.m_txtMedID.Enabled = true;
		}
		#endregion

		#region 锁定药品输入面板
		/// <summary>
		/// 锁定单位输入框
		/// </summary>
		private void m_mthLockMedInputPlan()
		{
			m_mthLockMedicineInput();
			this.m_objViewer.m_txtUnit.Enabled = false;
			this.m_objViewer.m_txtQty.Enabled = false; 
		}
		#endregion

		#region 解锁药品输入面板
		/// <summary>
		/// 解锁药品输入面板
		/// </summary>
		private void m_mthUnLockMedInputPlan()
		{
			m_mthUnLockMedicineInput();
			this.m_objViewer.m_txtUnit.Enabled = true;
			this.m_objViewer.m_txtQty.Enabled = true; 
		}
		#endregion

		#region 锁定确定按钮
		/// <summary>
		/// 锁定确定按钮
		/// </summary>
		private void m_mthLockOkButton()
		{
			this.m_objViewer.m_cmdConfirm.Enabled = false;
		}
		#endregion

		#region 解锁确定按钮
		/// <summary>
		/// 解锁确定按钮
		/// </summary>
		private void m_mthUnLockOkButton()
		{
			this.m_objViewer.m_cmdConfirm.Enabled = true;
		}
		#endregion

		#region 锁定保存按钮
		/// <summary>
		/// 锁定保存按钮
		/// </summary>
		private void m_mthLockSaveButton()
		{
			this.m_objViewer.tbrSave.Enabled = false;
		}
		#endregion

		#region  解锁保存按钮
		/// <summary>
		/// 解锁保存按钮
		/// </summary>
		private void m_mthUnLockSaveButton()
		{
			this.m_objViewer.tbrSave.Enabled = true;
		}
		#endregion

		#region 锁定增加按钮
		/// <summary>
		/// 锁定增加按钮
		/// </summary>
		private void m_mthLockAddButton()
		{
			this.m_objViewer.tbrAdd.Enabled = false;
			//			this.m_objViewer.menuItemAdd.Enabled = false;
		}
		#endregion

		#region 解锁增加按钮
		/// <summary>
		/// 解锁增加按钮
		/// </summary>
		private void m_mthUnLockAddButton()
		{
			this.m_objViewer.tbrAdd.Enabled = true;
			//			this.m_objViewer.menuItemAdd.Enabled = true;
		}
		#endregion

		#region 锁定插入按钮
		/// <summary>
		/// 锁定插入按钮
		/// </summary>
		private void m_mthLockInsertButton()
		{
			this.m_objViewer.tbrInsert.Enabled = false;
			//			this.m_objViewer.menuItemInsert.Enabled = false;
		}
		#endregion

		#region 解锁插入按钮
		/// <summary>
		/// 解锁插入按钮
		/// </summary>
		private void m_mthUnLockInsertButton()
		{
			this.m_objViewer.tbrInsert.Enabled = true;
			//			this.m_objViewer.menuItemInsert.Enabled = true;
		}
		#endregion

		#region 锁定删除按钮
		/// <summary>
		/// 锁定删除按钮
		/// </summary>
		private void m_mthLockDeleteButton()
		{
			this.m_objViewer.tbrDelete.Enabled = false;
			//			this.m_objViewer.menuItemDelete.Enabled = false;
		}
		#endregion

		#region 解锁删除按钮
		/// <summary>
		/// 解锁删除按钮
		/// </summary>
		private void m_mthUnLockDeleteButton()
		{
			this.m_objViewer.tbrDelete.Enabled = true;
			//			this.m_objViewer.menuItemDelete.Enabled = true;
		}
		#endregion

		#region 锁定工具栏
		/// <summary>
		/// 锁定工具栏
		/// </summary>
		private void m_mthLockToolBar()
		{
			this.m_objViewer.tbrNew.Enabled = false;
			this.m_objViewer.tbrFind.Enabled = false;
			this.m_objViewer.tbrImp.Enabled = false;
			m_mthLockSaveButton();
			m_mthLockAddButton();
			m_mthLockInsertButton();
			m_mthLockDeleteButton();
		}
		#endregion

		#region 解锁工具栏
		/// <summary>
		/// 解锁工具栏
		/// </summary>
		private void m_mthUnLockToolBar()
		{
			this.m_objViewer.tbrNew.Enabled = true;
			this.m_objViewer.tbrFind.Enabled = true;
			this.m_objViewer.tbrImp.Enabled = true;
			m_mthUnLockSaveButton();
			m_mthUnLockAddButton();
			m_mthUnLockInsertButton();
			m_mthUnLockDeleteButton();
		}
		#endregion


		#endregion

		#region 窗体初始化
		/// <summary>
		/// 窗体初始化
		/// </summary>
		public void m_mthInit()
		{
			m_mthGetOperator();
			m_mthGetMedStore();

//			if(! clsPublicParm.s_blnCheckCanOperator(this.m_objStorage.m_strStroageID.Trim()))
//			{
//				m_mthLockToolBar();
//				m_mthLockMedInputPlan();
//				m_mthLockOkButton();
//				return;
//			}
//			else
//			{
//				m_mthUnLockToolBar();
//				m_mthUnLockMedInputPlan();
//				m_mthUnLockOkButton();
//			}
			m_mthGetStorage();
			m_mthGetUnAndEnDetailList();
			m_mthNewOrd();
		}
		#endregion

		#region 窗体控制

		#region 设置领药申请记录框中的信息
		/// <summary>
		/// 设置领药申请记录框中的信息
		/// </summary>
		/// <param name="objItem">药房领药申请记录单数据</param>
		private void m_mthSetOrd(clsMedStoreMedAppl_VO objItem)
		{
			this.m_objItem = objItem;

			if(m_objItem == null)
			{
				m_mthClearRecordPanl();
				m_mthUnLockRecord();
				m_mthUnLockStorage();
				this.m_objViewer.m_dtpCreateDate.Value = clsPublicParm.s_datGetServerDate();
				
				string strID;
				long lngRes = this.m_objManage.m_lngGetMedApplID(out strID);
				this.m_objViewer.m_txtOrdID.Text = strID;
				this.m_objViewer.m_txtMedStore.Text = this.m_objMedStore.m_strMedStoreName;
				this.m_objViewer.m_txtMedStore.Tag = this.m_objMedStore;
			
			}
			else
			{
				m_mthClearRecordPanl();
				m_mthUnLockRecord();
				m_mthLockStorage();
				string strStorageID = this.m_objItem.m_objStorage.m_strStroageID;
				int index = m_intGetStorageIndex(strStorageID);
				this.m_objViewer.m_cboStorage.SelectedIndex = index;
				
				this.m_objViewer.m_dtpCreateDate.Value = Convert.ToDateTime(this.m_objItem.m_strApplDate.Trim());
				this.m_objViewer.m_txtOrdID.Text = this.m_objItem.m_strMedApplID.Trim();
				this.m_objViewer.m_txtMedStore.Text = this.m_objItem.m_objMedStore.m_strMedStoreName.Trim();
				this.m_objViewer.m_txtMedStore.Tag = this.m_objItem.m_objMedStore;
				this.m_objViewer.m_txtMemo.Text = this.m_objItem.m_strMemo;
			}
		}
		#endregion

		#region 获得的药房领药申请记录框中信息
		/// <summary>
		/// 获得的药房领药申请记录框中信息
		/// </summary>
		/// <returns></returns>
		private clsMedStoreMedAppl_VO m_objGetOrdInfo()
		{
			clsMedStoreMedAppl_VO objResult = new clsMedStoreMedAppl_VO();
			
			objResult.m_strMedApplID = this.m_objViewer.m_txtOrdID.Text.Trim();
			objResult.m_strApplDate = this.m_objViewer.m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			objResult.m_strMemo = this.m_objViewer.m_txtMemo.Text.Trim();
			objResult.m_objStorage = new clsStorage_VO();
			objResult.m_objStorage = this.m_objStorages[this.m_objViewer.m_cboStorage.SelectedIndex];
			objResult.m_objMedStore = new clsMedStore_VO();
			objResult.m_objMedStore = (clsMedStore_VO)this.m_objViewer.m_txtMedStore.Tag;
			objResult.m_objCreator = new clsEmployeeVO();
			objResult.m_objCreator = this.m_objOperator;

			return objResult;
		}
		#endregion

		#region 向明细列表中插入新数据
		/// <summary>
		/// 向明细列表中插入新的数据
		/// </summary>
		/// <param name="objItem"></param>
		private void m_mthInsertDetailList(clsMedStoreMedApplDe_VO objItem)
		{
			if(objItem != null)
			{
				if(m_blnIsInsert)
				{
					int intRowNoCount = m_objViewer.m_lsvDetail.Items.Count;
					m_mthChangeRowNo(this.m_SelRow,intRowNoCount,true);
				}
				System.Windows.Forms.ListViewItem lsvItem = new System.Windows.Forms.ListViewItem(objItem.m_strRowNo);
				lsvItem.SubItems.Add(objItem.m_objMedicine.m_strMedicineID);
				lsvItem.SubItems.Add(objItem.m_objMedicine.m_strMedicineName);
				lsvItem.SubItems.Add(objItem.m_objMedicine.m_strMedSpec);
				lsvItem.SubItems.Add(objItem.m_objUnit.m_strUnitName);
				lsvItem.SubItems.Add(objItem.m_decQty.ToString("######.00"));
				lsvItem.Tag = objItem;
				this.m_objViewer.m_lsvDetail.Items.Add(lsvItem);
			}
		}
		#endregion

		#region 设置更改后的列表数据
		/// <summary>
		/// 设置更改后的列表数据
		/// </summary>
		/// <param name="objItem"></param>
		private void m_mthChangeDetailList(clsMedStoreMedApplDe_VO objItem)
		{
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[4].Text = objItem.m_objUnit.m_strUnitName.Trim();
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[5].Text = objItem.m_decQty.ToString("######.00");
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].Tag = objItem;
		}
		#endregion

		#region 获得选定列表行的数据
		/// <summary>
		/// 获得选定列表行的数据
		/// </summary>
		/// <returns></returns>
		private clsMedStoreMedApplDe_VO m_mthGetSelDetailInfo()
		{
			clsMedStoreMedApplDe_VO objResult = new clsMedStoreMedApplDe_VO();
			if(this.m_objViewer.m_lsvDetail.SelectedItems.Count >0)
			{				
				if(this.m_objViewer.m_lsvDetail.Items[m_SelRow].Tag != null)
				{
					objResult = (clsMedStoreMedApplDe_VO)this.m_objViewer.m_lsvDetail.Items[m_SelRow].Tag;
				}
			}
			return objResult;
		}
		#endregion

		#region 设置药品输入窗口的数据
		/// <summary>
		/// 设置药品输入窗口的数据
		/// </summary>
		/// <param name="objItem">领药申请明细数据</param>
		private void m_mthSetInputPanl(clsMedStoreMedApplDe_VO objItem)
		{
			this.m_objDetail = objItem;

			if(this.m_objDetail == null)
			{
				m_mthClearDetailInput();
				m_mthUnLockMedInputPlan();
				this.m_objViewer.m_txtMedID.Focus();
				return;
			}
			else
			{
				m_mthClearDetailInput();
				m_mthUnLockMedInputPlan();
				m_mthLockMedicineInput();

				this.m_objViewer.m_txtMedID.Text = this.m_objDetail.m_objMedicine.m_strMedicineID;
				this.m_objViewer.m_txtMedName.Text = this.m_objDetail.m_objMedicine.m_strMedicineName;
				this.m_objViewer.m_txtMedSpec.Text = this.m_objDetail.m_objMedicine.m_strMedicineName;
				//				this.m_objViewer.m_txtMedID.Tag = this.m_objDetail.m_objMedicine;
				this.m_objViewer.m_txtUnit.Text = this.m_objDetail.m_objUnit.m_strUnitName;
				this.m_objViewer.m_txtUnit.Tag = this.m_objDetail.m_objUnit;				
				this.m_objViewer.m_txtQty.Text = this.m_objDetail.m_decQty.ToString("######.00");
				this.m_objViewer.m_txtQty.Focus();
				return;
			}
		}
		#endregion

		#region 向新增队列中增加一条记录
		/// <summary>
		/// 向新增队列中增加一条记录
		/// </summary>
		/// <param name="objItem">领药申请明细数据</param>
		private void m_mthAddToAddNewArr(clsMedStoreMedApplDe_VO objItem)
		{
			int intVoLength = 0;
			int intRow;
			clsMedStoreMedApplDe_VO[] objItemTmpArr;//临时VO
			
			//获得长度
			intVoLength = m_objDoAddNewArr.Length;
			objItemTmpArr = new clsMedStoreMedApplDe_VO[intVoLength];

			#region 传递到临时变量
			for(intRow =0;intRow<intVoLength;intRow++)
			{
				objItemTmpArr[intRow] = new clsMedStoreMedApplDe_VO();
				objItemTmpArr[intRow] = m_objDoAddNewArr[intRow];
			}
			#endregion

			++ intVoLength;

			m_objDoAddNewArr = new clsMedStoreMedApplDe_VO[intVoLength];

			#region 将临时VO传递回来
			for(intRow =0;intRow<intVoLength -1;intRow++)
			{
				m_objDoAddNewArr[intRow] = new clsMedStoreMedApplDe_VO();
				m_objDoAddNewArr[intRow] = objItemTmpArr[intRow];
			}
			#endregion

			#region 增加新的记录
			m_objDoAddNewArr[intVoLength -1] = new clsMedStoreMedApplDe_VO();
			m_objDoAddNewArr[intVoLength -1] = objItem;
			#endregion
		}
		#endregion

		#region 向修改队列中增加一条记录
		/// <summary>
		/// 向修改队列中增加一条记录
		/// </summary>
		/// <param name="objItem">领药申请明细数据</param>
		private void m_mthAddToUpdateArr(clsMedStoreMedApplDe_VO objItem)
		{
			int intVoLength = 0;
			int intRow;
			clsMedStoreMedApplDe_VO[] objItemTmpArr;//临时VO
			
			//获得长度
			intVoLength = m_objDoUpdateArr.Length;
			objItemTmpArr = new clsMedStoreMedApplDe_VO[intVoLength];

			#region 传递到临时变量
			for(intRow =0;intRow<intVoLength;intRow++)
			{
				objItemTmpArr[intRow] = new clsMedStoreMedApplDe_VO();
				objItemTmpArr[intRow] = m_objDoUpdateArr[intRow];
			}
			#endregion

			++ intVoLength;

			m_objDoUpdateArr = new clsMedStoreMedApplDe_VO[intVoLength];

			#region 将临时VO传递回来
			for(intRow =0;intRow<intVoLength -1;intRow++)
			{
				m_objDoUpdateArr[intRow] = new clsMedStoreMedApplDe_VO();
				m_objDoUpdateArr[intRow] = objItemTmpArr[intRow];
			}
			#endregion

			#region 增加新的记录
			m_objDoUpdateArr[intVoLength -1] = new clsMedStoreMedApplDe_VO();
			m_objDoUpdateArr[intVoLength -1] = objItem;
			#endregion
		}
		#endregion

		#region 向删除队列中增加一条记录
		/// <summary>
		/// 向删队列中增加一条记录
		/// </summary>
		/// <param name="objItem">领药申请明细数据</param>
		private void m_mthAddToDeleteArr(clsMedStoreMedApplDe_VO objItem)
		{
			int intVoLength = 0;
			int intRow;
			clsMedStoreMedApplDe_VO[] objItemTmpArr;//临时VO
			
			//获得长度
			intVoLength = m_objDoDeleteArr.Length;
			objItemTmpArr = new clsMedStoreMedApplDe_VO[intVoLength];

			#region 传递到临时变量
			for(intRow =0;intRow<intVoLength;intRow++)
			{
				objItemTmpArr[intRow] = new clsMedStoreMedApplDe_VO();
				objItemTmpArr[intRow] = m_objDoDeleteArr[intRow];
			}
			#endregion

			++ intVoLength;

			m_objDoDeleteArr = new clsMedStoreMedApplDe_VO[intVoLength];

			#region 将临时VO传递回来
			for(intRow =0;intRow<intVoLength -1;intRow++)
			{
				m_objDoDeleteArr[intRow] = new clsMedStoreMedApplDe_VO();
				m_objDoDeleteArr[intRow] = objItemTmpArr[intRow];
			}
			#endregion

			#region 增加新的记录
			m_objDoDeleteArr[intVoLength -1] = new clsMedStoreMedApplDe_VO();
			m_objDoDeleteArr[intVoLength -1] = objItem;
			#endregion
		}
		#endregion

		#region 清空队列
		/// <summary>
		/// 清空队列
		/// </summary>
		private void m_mthClearArr()
		{
			this.m_objDoAddNewArr = new clsMedStoreMedApplDe_VO[0];
			this.m_objDoUpdateArr = new clsMedStoreMedApplDe_VO[0];
			this.m_objDoDeleteArr = new clsMedStoreMedApplDe_VO[0];
		}
		#endregion

		#region 获得行号
		/// <summary>
		/// 获得行号
		/// </summary>
		/// <returns></returns>
		private string m_mthGetRowNo()
		{
			string strResult = "";
			++ m_RowNo;
			strResult = m_RowNo.ToString("0000");
			return strResult;
		}
		#endregion

		#region 更改某段列表中的行号
		/// <summary>
		/// 更改某段列表中的行号
		/// </summary>
		/// <param name="intStart">开始行</param>
		/// <param name="intEnd">末尾行</param>
		/// <param name="blnAdd">增号或减号</param>
		private void m_mthChangeRowNo(int intStart,int intEnd,bool blnAdd)
		{
			for(int i=intStart;i<intEnd;i++)
			{
				string strRowNo = m_objViewer.m_lsvDetail.Items[i].Text;
				int intRowNo = int.Parse(strRowNo);

				if(blnAdd)
				{
					++ intRowNo;
				}
				else
				{
					-- intRowNo;
				}
				m_objViewer.m_lsvDetail.Items[i].Text = intRowNo.ToString("0000");
			}
		}
		#endregion

		#region 检测列表中是否已经存在该药品
		/// <summary>
		/// 检测列表中是否已经存在该药品信息
		/// </summary>
		/// <param name="objItem">药品数据</param>
		/// <param name="index">索引</param>
		/// <returns></returns>
		private bool m_mthCheckExistsList(clsMedicine_VO objItem,out int index)
		{
			bool blnResult = true;
			index =0;

			for(int i=0;i<this.m_objViewer.m_lsvDetail.Items.Count;i++)
			{
				clsMedStoreMedApplDe_VO objTmp = new clsMedStoreMedApplDe_VO();
				objTmp = (clsMedStoreMedApplDe_VO)this.m_objViewer.m_lsvDetail.Items[i].Tag;
				if(objTmp != null)
				{
					if(objItem.m_strMedicineID.Trim() == objTmp.m_objMedicine.m_strMedicineID.Trim())
					{
						blnResult = false;
						index = i;
						break;
					}
				}
				else
				{
					blnResult = true;
				}
			}
			return blnResult;
		}
		#endregion

		#region 检测输入数据
		/// <summary>
		/// 检测输入数据
		/// </summary>
		/// <returns></returns>
		private bool m_blnCheckValue()
		{
			bool blnResult = true;

			decimal decQty = Convert.ToDecimal(this.m_objViewer.m_txtQty.Text.Trim());

			if(this.m_objViewer.m_txtMedID.Text == "" || this.m_objViewer.m_txtMedID.Text == " ")
			{
				this.m_ephHandler.m_mthAddControl(this.m_objViewer.m_txtMedID);
				blnResult = false;
			}
			if(this.m_objViewer.m_txtUnit.Text == "" || this.m_objViewer.m_txtUnit.Text == " ")
			{
				this.m_ephHandler.m_mthAddControl(this.m_objViewer.m_txtUnit);
				blnResult = false;
			}
			if(this.m_objViewer.m_txtQty.Text == "" || this.m_objViewer.m_txtQty.Text == " " || decQty <= 0)
			{
				this.m_ephHandler.m_mthAddControl(this.m_objViewer.m_txtQty);
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

		#region 新增明细
		/// <summary>
		/// 新增明细
		/// </summary>
		private void m_mthAddDetail()
		{
			clsMedStoreMedApplDe_VO objItem = new clsMedStoreMedApplDe_VO();
			objItem.m_objMedicine = new clsMedicine_VO();
			objItem.m_objUnit = new clsUnit_VO();
			
			objItem.m_strRowNo = m_mthGetRowNo();
			objItem.m_strMedApplID = this.m_objViewer.m_txtOrdID.Text.Trim();
			if(this.m_objViewer.m_txtMedID.Tag != null)
			{
				clsStorageMedDetail_VO objItemTmp = (clsStorageMedDetail_VO)this.m_objViewer.m_txtMedID.Tag;
				objItem.m_objMedicine = objItemTmp.m_objMedicine;
				objItem.m_strSysLotNo = objItemTmp.m_strSysLotNo;
				
			}
			if(this.m_objViewer.m_txtUnit.Tag != null)
			{
				objItem.m_objUnit = (clsUnit_VO)this.m_objViewer.m_txtUnit.Tag;
			}
			objItem.m_strApplDate = clsPublicParm.s_datGetServerDate().ToString("yyyy-MM-dd HH:mm:ss");
			objItem.m_decQty = Convert.ToDecimal(this.m_objViewer.m_txtQty.Text);
						
			m_mthAddToAddNewArr(objItem);
			m_mthInsertDetailList(objItem);

		}
		#endregion

		#region 修改明细
		/// <summary>
		/// 修改明细
		/// </summary>
		private void m_mthModifyDetail()
		{
			this.m_objDetail.m_objUnit = (clsUnit_VO)this.m_objViewer.m_txtUnit.Tag;
			this.m_objDetail.m_decQty = Convert.ToDecimal(this.m_objViewer.m_txtQty.Text);
			m_mthAddToUpdateArr(this.m_objDetail);
			m_mthChangeDetailList(this.m_objDetail);
		}
		#endregion

		#region 新增入库记录 
		/// <summary>
		/// 新增入库记录
		/// </summary>
		/// <returns></returns>
		private long m_lngDoAddNewOrd()
		{
			long lngRes = 0;
			
			clsMedStoreMedAppl_VO objItem = new clsMedStoreMedAppl_VO();
			objItem = m_objGetOrdInfo();
			objItem.m_intPStatus = 1;
			
			lngRes = this.m_objManage.m_lngAddNewMedAppl(objItem);

			return lngRes;
		}
		#endregion

		#region 修改入库记录
		/// <summary>
		/// 修改入库记录
		/// </summary>
		/// <returns></returns>
		private long m_lngDoUpdateOrd()
		{
			long lngRes = 0;

			this.m_objItem.m_strApplDate = this.m_objViewer.m_dtpCreateDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
			
			this.m_objItem.m_strMemo = this.m_objViewer.m_txtMemo.Text.Trim();
			this.m_objItem.m_intPStatus = 2;

			lngRes = this.m_objManage.m_lngUpdateMedAppl(this.m_objItem);
			return lngRes;

		}
		#endregion
		
		#region 保存入库明细
		/// <summary>
		/// 保存入库明细
		/// </summary>
		private void m_mthDoSaveDetail()
		{
			int i=0;
			long lngRes = 0;

			if(m_objItem == null)
			{
			}

			if(m_objDoAddNewArr.Length >0)
			{
				for(i=0;i<m_objDoAddNewArr.Length;i++)
				{
					string strDeID;
					lngRes = this.m_objManage.m_lngGetMedApplDeID(out strDeID);
					m_objDoAddNewArr[i].m_strMedApplDeID = strDeID.Trim();
					m_objDoAddNewArr[i].m_strMedApplID = this.m_objViewer.m_txtOrdID.Text.Trim();
					m_objDoAddNewArr[i].m_strApplDate = clsPublicParm.s_datGetServerDate().ToString("yyyy-MM-dd HH:mm:ss");
					lngRes = m_objManage.m_lngAddNewMedApplDe(m_objDoAddNewArr[i]);

					if(lngRes <= 0)
					{
						System.Windows.Forms.MessageBox.Show("保存失败！","系统提示");
						return;
					}
				}
			}

			if(m_objDoUpdateArr.Length >0)
			{
				for(i=0;i<m_objDoUpdateArr.Length;i++)
				{
					lngRes = m_objManage.m_lngUpdateMedApplDe(m_objDoUpdateArr[i]);

					//					if(lngRes <= 0)
					//					{
					//						System.Windows.Forms.MessageBox.Show("保存失败！","系统提示");
					//						return;
					//					}
				}
			}

			if(m_objDoDeleteArr.Length >0)
			{
				for(i=0;i<m_objDoDeleteArr.Length;i++)
				{
					lngRes = m_objManage.m_lngDeleteMedApplDe(m_objDoDeleteArr[i].m_strMedApplDeID);

					if(lngRes <= 0)
					{
						System.Windows.Forms.MessageBox.Show("保存失败！","系统提示");
						return;
					}
				}
			}
		}
		#endregion

		#endregion

		#region 窗体操作

		#region 自动生成
		/// <summary>
		/// 自动生成领药申请
		/// </summary>
		public void m_mthAutoCalc()
		{
			long lngRes = 0;
			clsMedStoreMedApplDe_VO[] p_objItems = new clsMedStoreMedApplDe_VO[0];

			lngRes = m_objManage.m_lngAutoCalcMedAppl(m_objMedStore.m_strMedStoreID.Trim(),out p_objItems);

			if(lngRes >0 && p_objItems.Length >0)
			{
				for(int i=0;i<p_objItems.Length;i++)
				{
					m_mthInsertDetailList(p_objItems[i]);
					m_mthAddToAddNewArr(p_objItems[i]);
				}
			}
			else
			{
				MessageBox.Show("目前无缺药，或未设置限额管理","系统提示");
			}
		}
		#endregion

		#region 新建单据
		/// <summary>
		/// 新建单据
		/// </summary>
		public void m_mthNewOrd()
		{
			m_mthSetOrd(null);
			m_mthClearDetailInput();
			this.m_objViewer.m_lsvDetail.Items.Clear();
			m_mthClearArr();
			m_mthSetInputPanl(null);
			m_mthUnLockRecord();
			m_mthUnLockDetailList();
			m_mthUnLockMedInputPlan();
			m_mthUnLockOkButton();
			m_mthUnLockAddButton();
			m_mthUnLockDeleteButton();
			m_mthUnLockInsertButton();
			m_mthUnLockSaveButton();
			
		}
		#endregion

		#region 保存
		/// <summary>
		/// 保存
		/// </summary>
		public void m_mthSave()
		{
			if(this.m_objViewer.m_lsvDetail.Items.Count >0)
			{
				long lngRes = 0;
				if(this.m_objItem == null)
				{
					lngRes = m_lngDoAddNewOrd();
				}
				else
				{
					lngRes = m_lngDoUpdateOrd();
				}

				if(lngRes >0)
				{
					m_mthDoSaveDetail();
					m_mthGetUnAndEnDetailList();
					m_mthNewOrd();
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("保存失败！","系统提示");
					return;
				}
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("明细列表中无数据，不被保存！","系统提示");
			}
		}
		#endregion

		#region 增加
		/// <summary>
		/// 增加
		/// </summary>
		public void m_mthAdd()
		{
			if(this.m_objViewer.m_lsvDetail.Items.Count>0)
			{
				this.m_RowNo = this.m_objViewer.m_lsvDetail.Items.Count;
			}
			else
			{
				this.m_RowNo = 0;
			}
			m_blnIsInsert = false;
			m_mthSetInputPanl(null);
		}
		#endregion

		#region  插入
		/// <summary>
		/// 插入
		/// </summary>
		public void m_mthInsert()
		{
			int intRowCount = this.m_objViewer.m_lsvDetail.Items.Count;
			if(intRowCount > 0)
			{
				if(this.m_objViewer.m_lsvDetail.SelectedItems.Count >0)
				{
					int index = this.m_objViewer.m_lsvDetail.SelectedItems[0].Index;
					string strRowNo = this.m_objViewer.m_lsvDetail.Items[index].Text;
					this.m_RowNo = int.Parse(strRowNo);
					this.m_RowNo -= 1;
					m_blnIsInsert = true;
					this.m_SelRow = index;
					m_mthSetInputPanl(null);
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("请选择要插入的行！","系统提示");
				}
			}
			else
			{
				m_mthAdd();
			}			
		}
		#endregion

		#region 删除
		/// <summary>
		/// 删除
		/// </summary>
		public void m_mthDelete()
		{
			int index = 0;
			int intRowCount = 0;
			
			if(this.m_objViewer.m_lsvDetail.SelectedItems.Count >0)
			{
				index = this.m_objViewer.m_lsvDetail.SelectedItems[0].Index;
				intRowCount = this.m_objViewer.m_lsvDetail.Items.Count;
				if(index>=0 && intRowCount >0)
				{
					//向删除VO增加一条记录
					m_mthAddToDeleteArr(m_mthGetSelDetailInfo());
					
					//明细列表删除记录
					this.m_objViewer.m_lsvDetail.Items[index].Remove();
					//更改行号
					m_mthChangeRowNo(index,intRowCount -1,false);
					//默认增加一条记录
					m_mthAdd();
				}
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("请选择要删除的记录","系统提示");
			}
		}
		#endregion

		#region 查找
		/// <summary>
		/// 查找
		/// </summary>
		public void m_mthFind()
		{
		}
		#endregion

		#region 导入
		/// <summary>
		/// 导入
		/// </summary>
		public void m_mthImp()
		{
		}
		#endregion

		#region 预览
		/// <summary>
		/// 预览
		/// </summary>
		public void m_mthPreView()
		{
		}
		#endregion

		#region 打印
		/// <summary>
		/// 打印
		/// </summary>
		public void m_mthPrint()
		{
		}
		#endregion

		#region 末处理列表选择事件
		/// <summary>
		/// 导入末处理数据
		/// </summary>
		public void m_mthSelectUnAskList()
		{
			clsMedStoreMedAppl_VO objItem = new clsMedStoreMedAppl_VO();
			if(this.m_objViewer.m_lsvUnAsk.SelectedItems[0].Tag != null)
			{
				objItem = (clsMedStoreMedAppl_VO)this.m_objViewer.m_lsvUnAsk.SelectedItems[0].Tag;
				clsMedStoreMedApplDe_VO[] objItemArr = new clsMedStoreMedApplDe_VO[0];
				long lngRes = 0;
				lngRes = this.m_objManage.m_lngGetMedApplDeByApplID(objItem.m_strMedApplID.Trim(),out objItemArr);

				if(lngRes >0 && objItemArr.Length >0)
				{
					m_mthSetOrd(objItem);
					this.m_objViewer.m_lsvDetail.Items.Clear();
					for(int i1=0;i1<objItemArr.Length;i1++)
					{
						m_mthInsertDetailList(objItemArr[i1]);
					}
					m_mthClearArr();
					m_mthUnLockRecord();
					m_mthUnLockDetailList();
					m_mthUnLockMedInputPlan();
					m_mthUnLockAddButton();
					m_mthUnLockDeleteButton();
					m_mthUnLockInsertButton();
					m_mthUnLockOkButton();
					m_mthUnLockSaveButton();
				}
			}
		}
		#endregion

		#region 已处理列表选择事件
		/// <summary>
		/// 导入已处理数据
		/// </summary>
		public void m_mthSelectEnAskList()
		{
			clsMedStoreMedAppl_VO objItem = new clsMedStoreMedAppl_VO();
			if(this.m_objViewer.m_lsvEnAsk.SelectedItems[0].Tag != null)
			{
				objItem = (clsMedStoreMedAppl_VO)this.m_objViewer.m_lsvEnAsk.SelectedItems[0].Tag;
				clsMedStoreMedApplDe_VO[] objItemArr = new clsMedStoreMedApplDe_VO[0];
				long lngRes = 0;
				lngRes = this.m_objManage.m_lngGetMedApplDeByApplID(objItem.m_strMedApplID.Trim(),out objItemArr);

				if(lngRes >0 && objItemArr.Length >0)
				{
					m_mthSetOrd(objItem);
					this.m_objViewer.m_lsvDetail.Items.Clear();
					for(int i1=0;i1<objItemArr.Length;i1++)
					{
						m_mthInsertDetailList(objItemArr[i1]);
					}
					m_mthClearArr();
					m_mthLockRecord();
					m_mthLockDetailList();
					m_mthLockMedInputPlan();
					m_mthLockAddButton();
					m_mthLockDeleteButton();
					m_mthLockInsertButton();
					m_mthLockOkButton();
					m_mthLockSaveButton();
				}
			}
		}
		#endregion

		#region 明细列表选择事件
		/// <summary>
		/// 选定明细列表中的行
		/// </summary>
		public void m_mthSelectDetailList()
		{
			clsMedStoreMedApplDe_VO objItem = new clsMedStoreMedApplDe_VO();

			if(this.m_objViewer.m_lsvDetail.SelectedItems.Count >0)
			{
				if(this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag != null)
				{
					this.m_SelRow = this.m_objViewer.m_lsvDetail.SelectedItems[0].Index;
					objItem = (clsMedStoreMedApplDe_VO)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag;
					m_mthSetInputPanl(objItem);
				}
			}
		}
		#endregion

		#region 选择药品
		/// <summary>
		/// 选择药品
		/// </summary>
		public void m_mthSelMedicine()
		{
			clsStorageMedDetail_VO objItem= new clsStorageMedDetail_VO();
			int index = 0;

			if(this.m_objViewer.m_txtMedID.objStorageMedicine !=null)
			{
				objItem = (clsStorageMedDetail_VO)this.m_objViewer.m_txtMedID.objStorageMedicine;
				if(!m_mthCheckExistsList(objItem.m_objMedicine,out index))
				{
					if(System.Windows.Forms.MessageBox.Show("药品已经在列表中\n更该药品数据吗？","",System.Windows.Forms.MessageBoxButtons.OKCancel,
						System.Windows.Forms.MessageBoxIcon.Warning,System.Windows.Forms.MessageBoxDefaultButton.Button1) == 
						System.Windows.Forms.DialogResult.OK)
					{
						this.m_objViewer.m_lsvDetail.Items[index].Selected = true;
						this.m_objViewer.m_txtMedID.m_mthClear();
						m_mthSelectDetailList();
						return;
					}
					else
					{
						this.m_objViewer.m_txtMedID.Clear();
						this.m_objViewer.m_txtMedID.Focus();
						this.m_objViewer.m_txtMedID.m_mthClear();
						return;
					}
				}
				this.m_objViewer.m_txtMedID.Text = objItem.m_objMedicine.m_strMedicineID.Trim();
				this.m_objViewer.m_txtMedName.Text = objItem.m_objMedicine.m_strMedicineName.Trim();
				this.m_objViewer.m_txtMedSpec.Text = objItem.m_objMedicine.m_strMedSpec.Trim();
				this.m_objViewer.m_txtMedID.Tag = objItem;
				this.m_objViewer.m_txtMedID.m_mthClear();
				this.m_objViewer.m_txtUnit.Focus();
				return;
			}
				
		}
		#endregion

		#region 确定按钮事件
		/// <summary>
		/// 确定按钮
		/// </summary>
		public void m_mthOkButtonClick()
		{
			if(!m_blnCheckValue())
			{
				return;
			}

			if(m_objDetail == null)
			{
				m_mthAddDetail();
			}
			else
			{
				m_mthModifyDetail();
			}
			m_mthClearDetailInput();
			m_mthAdd();
		}
		#endregion

		#region 弹出选择列表事件
		/// <summary>
		/// 显示单位选择列表
		/// </summary>
		public void m_mthEnablePopUnitList()
		{
			string strMedID = this.m_objViewer.m_txtMedID.Text.Trim();
			clsMedUnitAndUnit[] objItems = new clsMedUnitAndUnit[0];

			objItems = clsPublicParm.s_FindUnitByMedID(strMedID);
			
			if(objItems.Length>0)
			{
				this.m_objViewer.m_lsvPopUnit.Visible = true;
				this.m_objViewer.m_lsvPopUnit.Items.Clear();
				for(int i=0;i<objItems.Length;i++)
				{
					ListViewItem lsvItem = new ListViewItem(objItems[i].m_objBigUnit.m_strUnitID.Trim());
					lsvItem.SubItems.Add(objItems[i].m_objBigUnit.m_strUnitName);
					lsvItem.SubItems.Add(objItems[i].m_fltBigUnitQty.ToString() + " / " + objItems[i].m_fltSmallUnit.ToString()); 
					lsvItem.SubItems.Add(objItems[i].m_intLevel.ToString());
					lsvItem.Tag = objItems[i].m_objBigUnit;
					this.m_objViewer.m_lsvPopUnit.Items.Add(lsvItem);
				}
				this.m_objViewer.m_lsvPopUnit.Focus();
				this.m_objViewer.m_lsvPopUnit.Select();
				this.m_objViewer.m_lsvPopUnit.Items[0].Selected = true;
			}
		}
		/// <summary>
		/// 选择单位
		/// </summary>
		public void m_mthSelUnit()
		{
			clsUnit_VO objItem = new clsUnit_VO();

			if(this.m_objViewer.m_lsvPopUnit.SelectedItems[0].Tag != null)
			{
				objItem = (clsUnit_VO)this.m_objViewer.m_lsvPopUnit.SelectedItems[0].Tag;
				this.m_objViewer.m_txtUnit.Text = objItem.m_strUnitName;
				this.m_objViewer.m_txtUnit.Tag = objItem;
				this.m_objViewer.m_lsvPopUnit.Visible = false;
			}
		}
		#endregion
		
		#endregion

	}
}
