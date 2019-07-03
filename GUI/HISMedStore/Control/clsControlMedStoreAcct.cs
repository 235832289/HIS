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
	/// 药房登帐窗体控制
	/// Create by kong 2004-07-13
	/// </summary>
	public class clsControlMedStoreAcct : com.digitalwave.GUI_Base.clsController_Base	//GUI_Base.dll
	{
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary>
		public clsControlMedStoreAcct()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
			m_objManage = new clsDomainControlMedStore();
			m_objMedStore = new clsMedStore_VO();
			m_objOperator = new clsEmployeeVO();
			m_objCurPeriod = new clsPeriod_VO();
		}
		#endregion

		#region 变量
		clsDomainControlMedStore m_objManage = null;
		/// <summary>
		/// 记录单VO
		/// </summary>
		clsICARE_BaseVO m_objItem;
		/// <summary>
		/// 未登帐列表
		/// </summary>
		DataTable m_dtbUnAcct = null;
		/// <summary>
		/// 已登帐列表
		/// </summary>
		DataTable m_dtbEnAcct = null;
		/// <summary>
		/// 药房
		/// </summary>
		clsMedStore_VO m_objMedStore;
		/// <summary>
		/// 操作员
		/// </summary>
		clsEmployeeVO m_objOperator;
		/// <summary>
		/// 当前帐务期
		/// </summary>
		clsPeriod_VO m_objCurPeriod;
		#endregion

		#region 设置窗体对象
		private frmMedStoreAcct m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			// TODO:  添加 clsControlStorageAcct.Set_GUI_Apperance 实现
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmMedStoreAcct)frmMDI_Child_Base_in;
		}
		#endregion

		#region 获得操作员  欧阳孔伟  2004-06-14
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

		#region 获得库房  欧阳孔伟  2004-06-14
		/// <summary>
		/// 获得库房
		/// </summary>
		private void m_mthGetStorage()
		{
			long lngRes;
			clsMedStore_VO[] objMedStoreArr = new clsMedStore_VO[0];

			clsDomainControlMedStoreBseInfo objManage = new clsDomainControlMedStoreBseInfo();
			lngRes = objManage.m_lngGetMedStoreList(out objMedStoreArr);
			
			if(objMedStoreArr.Length > 0)
			{
				m_objMedStore = objMedStoreArr[0];
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

		#region 获得当前帐期  欧阳孔伟  2004-06-14
		/// <summary>
		/// 获得当前帐务期
		/// </summary>
		private void m_mthGetCurPeriod()
		{
			this.m_objCurPeriod = clsPublicParm.s_GetCurPeriod();
			this.m_objViewer.m_txtCurPeriod.Text = this.m_objCurPeriod.m_strStartDate + " 至 " + this.m_objCurPeriod.m_strEndDate;
			this.m_objViewer.m_txtCurPeriod.Tag = this.m_objCurPeriod;
		}
		#endregion

		#region 获得帐务期列表  欧阳孔伟  2004-06-14
		/// <summary>
		/// 获得帐务期列表
		/// </summary>
		private void m_mthGetPeriodList()
		{
			DataTable dtbItem = new DataTable();
			dtbItem = clsPublicParm.s_GetPeriodTable();

			if(dtbItem != null && dtbItem.Rows.Count >0)
			{
				this.m_objViewer.m_cboSelPeriod.DataSource = dtbItem;
				this.m_objViewer.m_cboSelPeriod.ValueMember = "PERIODID_CHR";
				this.m_objViewer.m_cboSelPeriod.DisplayMember = "PERIOD";
				this.m_objViewer.m_cboSelPeriod.SelectedValue = this.m_objCurPeriod.m_strPeriodID;
			}
		}
		#endregion

		#region 根据帐务期获得当前单据的已登帐和未登帐列表  欧阳孔伟  2004-06-14
		/// <summary>
		/// 根据帐务期获得当前单据的已登帐和未登帐列表
		/// </summary>
		/// <param name="strPeriodID">帐务期代码</param>
		private void m_mthGetUnAndEnDetailList(string strPeriodID)
		{
			long lngRes = 0;
			int intRow = 0;

			//未登帐
			this.m_dtbUnAcct = null;
			this.m_objViewer.m_lsvUnAcct.Items.Clear();
//			lngRes = this.m_objManage.m_lngSelectAcct(strPeriodID,this.m_objStorage.m_strStroageID,true,out this.m_dtbUnAcct);
			if(lngRes >0 && m_dtbUnAcct != null)
			{
				//				this.m_objViewer.m_dtgUnAcct.DataSource = dtbItem;
				if(this.m_dtbUnAcct.Rows.Count >0)
				{
					for(int i1=0;i1<this.m_dtbUnAcct.Rows.Count;i1++)
					{
						intRow = i1 +1;
						ListViewItem lsvItem = new ListViewItem(intRow.ToString("0000"));
						lsvItem.SubItems.Add(this.m_dtbUnAcct.Rows[i1]["flag"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbUnAcct.Rows[i1]["id"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbUnAcct.Rows[i1]["typename"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbUnAcct.Rows[i1]["createdate"].ToString().Substring(0,8));
						lsvItem.SubItems.Add(this.m_dtbUnAcct.Rows[i1]["createemp"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbUnAcct.Rows[i1]["aduitemp"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbUnAcct.Rows[i1]["sign"].ToString().Trim());
						lsvItem.Tag = this.m_dtbUnAcct;
						this.m_objViewer.m_lsvUnAcct.Items.Add(lsvItem);
					}
					
				}
			}

			//登帐
			intRow = 0;
			this.m_dtbEnAcct = null;
			this.m_objViewer.m_lsvEnAcct.Items.Clear();
//			lngRes = this.m_objManage.m_lngSelectAcct(strPeriodID,this.m_objStorage.m_strStroageID,false,out this.m_dtbEnAcct);
			if(lngRes >0 && m_dtbEnAcct != null)
			{
				//				this.m_objViewer.m_dtgUnAcct.DataSource = dtbItem;
				if(this.m_dtbEnAcct.Rows.Count >0)
				{
					for(int i1=0;i1<this.m_dtbEnAcct.Rows.Count;i1++)
					{
						intRow = i1 +1;
						ListViewItem lsvItem = new ListViewItem(intRow.ToString("0000"));
						lsvItem.SubItems.Add(this.m_dtbEnAcct.Rows[i1]["flag"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbEnAcct.Rows[i1]["id"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbEnAcct.Rows[i1]["typename"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbEnAcct.Rows[i1]["createdate"].ToString().Substring(0,8));
						lsvItem.SubItems.Add(this.m_dtbEnAcct.Rows[i1]["createemp"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbEnAcct.Rows[i1]["aduitemp"].ToString().Trim());
						lsvItem.SubItems.Add(this.m_dtbEnAcct.Rows[i1]["sign"].ToString().Trim());
						lsvItem.Tag = this.m_dtbEnAcct;
						this.m_objViewer.m_lsvEnAcct.Items.Add(lsvItem);
					}
					
				}
			}
		}
		#endregion

		#region 根据单据不同创建不同列表
		/// <summary>
		/// 创建不同的列表外观
		/// </summary>
		/// <param name="intSign">1：出入库，2：盘点，3：调价</param>
		private void m_mthCreateDetailList(int intSign)
		{
			if(intSign == 1)
			{
				this.m_objViewer.clhQty.Text = "数量";
				this.m_objViewer.clhBuyPrice.Text = "购进金额";
				this.m_objViewer.clhSalePrice.Text = "零售金额";
				this.m_objViewer.clhDiff.Text = "差额";
				this.m_objViewer.clhOther.Width = 0;				
			}
			if(intSign == 2)
			{
				this.m_objViewer.clhQty.Text = "系统数量";
				this.m_objViewer.clhBuyPrice.Text = "盘点数量";
				this.m_objViewer.clhSalePrice.Text = "购进价";
				this.m_objViewer.clhDiff.Text = "零售价";
				this.m_objViewer.clhOther.Text = "差额";
				this.m_objViewer.clhOther.Width = 80;				
			}
		}
		#endregion

		#region 设置进出药记录单信息
		/// <summary>
		/// 设置进出药记录单信息
		/// </summary>
		/// <param name="objItem">进出药记录单数据</param>
		private void m_mthSetRecord(clsMedStoreOrd_VO objItem)
		{
			if(objItem != null)
			{
				this.m_objViewer.m_txtMedStore.Text = objItem.m_objMedStore.m_strMedStoreName.Trim();
				this.m_objViewer.m_txtMedStore.Tag = objItem.m_objMedStore;

				this.m_objViewer.m_txtOrdType.Text = objItem.m_objMedStoreOrdType.m_strMedStoreOrdTypeName.Trim();
				this.m_objViewer.m_txtOrdType.Tag = objItem.m_objMedStoreOrdType;

				string strEmpID = objItem.m_objCreator.strEmpID.Trim();
				string strEmpName = clsPublicParm.s_strGetEmpInfo("lastname_vchr","empid_chr",strEmpID);
				this.m_objViewer.m_txtCreator.Text = strEmpName;
				this.m_objViewer.m_txtCreator.Tag = objItem.m_objCreator;

				strEmpID = objItem.m_objAduitEmp.strEmpID.Trim();
				strEmpName = clsPublicParm.s_strGetEmpInfo("lastname_vchr","empid_chr",strEmpID);
				this.m_objViewer.m_txtAduit.Text = strEmpName;
				this.m_objViewer.m_txtAduit.Tag = objItem.m_objAduitEmp;

				this.m_objViewer.m_txtOrdID.Text = objItem.m_strMedStoreOrdID.Trim();
				this.m_objViewer.m_dtbCreateDate.Value = Convert.ToDateTime(objItem.m_strOrdDate.Trim());
				
			}
		}
		#endregion

		#region 向列表插入进出药明细信息
		/// <summary>
		/// 向列表插入进出药明细信息
		/// </summary>
		/// <param name="objItem">进出药明细数据</param>
		private void m_mthInsertDetialList(clsMedStoreOrdDe_VO objItem)
		{
			if(objItem != null)
			{
				ListViewItem lsvItem = new ListViewItem(objItem.m_strRowNo.Trim());
				lsvItem.SubItems.Add(objItem.m_objMedicine.m_strMedicineID.Trim());
				lsvItem.SubItems.Add(objItem.m_objMedicine.m_strMedicineName.Trim());
				lsvItem.SubItems.Add(objItem.m_objMedicine.m_strMedSpec.Trim());
				lsvItem.SubItems.Add(objItem.m_objUnit.m_strUnitName.Trim());
				
				decimal decQty = objItem.m_decQty;

				lsvItem.SubItems.Add(decQty.ToString("#######.00").Trim());
				lsvItem.Tag = objItem;

				this.m_objViewer.m_lsvDetail.Items.Add(lsvItem);

			}
		}
		#endregion

		#region 设置盘点记录单信息
		/// <summary>
		/// 设置盘点记录单信息
		/// </summary>
		/// <param name="objItem">盘点记录单数据</param>
		private void m_mthSetRecord(clsMedStoreCheck_VO objItem)
		{
			if(objItem != null)
			{
				this.m_objViewer.m_txtMedStore.Text = objItem.m_objMedStore.m_strMedStoreName.Trim();
				this.m_objViewer.m_txtMedStore.Tag = objItem.m_objMedStore;

				this.m_objViewer.m_txtOrdType.Text = "药房盘点单";
				this.m_objViewer.m_txtOrdType.Tag = null;

				string strEmpID = objItem.m_objCreator.strEmpID.Trim();
				string strEmpName = clsPublicParm.s_strGetEmpInfo("lastname_vchr","empid_chr",strEmpID);
				this.m_objViewer.m_txtCreator.Text = strEmpName;
				this.m_objViewer.m_txtCreator.Tag = objItem.m_objCreator;

				strEmpID = objItem.m_objAduitEmp.strEmpID.Trim();
				strEmpName = clsPublicParm.s_strGetEmpInfo("lastname_vchr","empid_chr",strEmpID);
				this.m_objViewer.m_txtAduit.Text = strEmpName;
				this.m_objViewer.m_txtAduit.Tag = objItem.m_objAduitEmp;

				this.m_objViewer.m_txtOrdID.Text = objItem.m_strCheckID.Trim();
				this.m_objViewer.m_dtbCreateDate.Value = Convert.ToDateTime(objItem.m_strCheckDate.Trim());
				
			}
		}
		#endregion

		#region 向列表插入盘点明细信息
		/// <summary>
		/// 向列表插入盘点明细信息
		/// </summary>
		/// <param name="objItem">盘点明细单数据</param>
		private void m_mthInsertDetialList(clsMedStoreCheckDe_VO objItem)
		{
			if(objItem != null)
			{
				ListViewItem lsvItem = new ListViewItem(objItem.m_strRowNo.Trim());
				lsvItem.SubItems.Add(objItem.m_objMedicine.m_strMedicineID.Trim());
				lsvItem.SubItems.Add(objItem.m_objMedicine.m_strMedicineName.Trim());
				lsvItem.SubItems.Add(objItem.m_objMedicine.m_strMedSpec.Trim());
				lsvItem.SubItems.Add(objItem.m_objUnit.m_strUnitName.Trim());
				
				lsvItem.Tag = objItem;

				this.m_objViewer.m_lsvDetail.Items.Add(lsvItem);

			}
		}
		#endregion

		#region 清空信息　欧阳孔伟　2004-06-16
		/// <summary>
		/// 清空信息
		/// </summary>
		private void m_mthClearPanl()
		{
			this.m_objViewer.m_txtMedStore.Clear();
			this.m_objViewer.m_txtOrdType.Clear();
			this.m_objViewer.m_txtCreator.Clear();
			this.m_objViewer.m_txtAduit.Clear();
			this.m_objViewer.m_txtOrdID.Clear();
			this.m_objViewer.m_txtBuyTolMoney.Clear();
			this.m_objViewer.m_txtBuyTolMoney.Text = "0.00";
			this.m_objViewer.m_txtSaleTolMoney.Clear();
			this.m_objViewer.m_txtSaleTolMoney.Text = "0.00";
			this.m_objViewer.m_dtbCreateDate.Value = clsPublicParm.s_datGetServerDate();
			this.m_objViewer.m_lsvDetail.Items.Clear();
		}
		#endregion

		#region 锁定登帐按钮　欧阳孔伟　2004-06-16
		/// <summary>
		/// 锁定登帐按钮
		/// </summary>
		private void m_mthLockAcctButton()
		{
			this.m_objViewer.m_cmdAcct.Enabled = false;
		}
		#endregion

		#region 解锁登帐按钮　欧阳孔伟　2004-06-16
		/// <summary>
		/// 解锁登帐按钮
		/// </summary>
		private void m_mthUnLockAcctButton()
		{
			this.m_objViewer.m_cmdAcct.Enabled = true;
		}
		#endregion

		#region 实例化m_objItem　欧阳孔伟　2004-06-17
		/// <summary>
		/// 实例化m_objItem
		/// </summary>
		/// <param name="intSign">单据标志</param>
		private void m_mthNewItem(int intSign)
		{
			switch(intSign)
			{
				case 1:					
				case 2:
					this.m_objItem = new clsMedStoreOrd_VO();
					break;
				case 3:
					this.m_objItem = new clsMedStoreCheck_VO();
					break;
			}
		}
		#endregion

		#region 导入进出药单
		/// <summary>
		/// 导入进出药单
		/// </summary>
		private void m_mthImpMedStoreInOrOutOrd()
		{
			m_mthClearPanl();
			m_mthCreateDetailList(1);
			this.m_objViewer.m_lsvDetail.Items.Clear();
			long lngRes = 0;
			if(this.m_objItem != null)
			{
				clsMedStoreOrdDe_VO[] objItems = new clsMedStoreOrdDe_VO[0];
				string strID = ((clsMedStoreOrd_VO)this.m_objItem).m_strMedStoreOrdID.Trim();
				string strTypeID = ((clsMedStoreOrd_VO)this.m_objItem).m_objMedStoreOrdType.m_strMedStoreOrdTypeID.Trim();
				lngRes = this.m_objManage.m_lngGetMedStoreOrdDeByOrdID(strID,out objItems);

				if(lngRes>0 && objItems.Length>0)
				{
					m_mthSetRecord((clsMedStoreOrd_VO)this.m_objItem);
					for(int i=0;i<objItems.Length;i++)
					{
						m_mthInsertDetialList(objItems[i]);
					}
				}
			}
		}
		#endregion

		#region 导入盘点单
		/// <summary>
		/// 导入盘点单
		/// </summary>
		private void m_mthImpStorageCheck()
		{
			m_mthClearPanl();
			m_mthCreateDetailList(2);
			this.m_objViewer.m_lsvDetail.Items.Clear();
			long lngRes = 0;
			if(this.m_objItem != null)
			{
				clsMedStoreCheckDe_VO[] objItems = new clsMedStoreCheckDe_VO[0];
				string strID = ((clsMedStoreCheck_VO)this.m_objItem).m_strCheckID.Trim();
				
				lngRes = this.m_objManage.m_lngGetMedStoreCheckDeByCheckID(strID,out objItems);

				if(lngRes>0 && objItems.Length>0)
				{
					m_mthSetRecord((clsMedStoreCheck_VO)this.m_objItem);
					for(int i=0;i<objItems.Length;i++)
					{
						m_mthInsertDetialList(objItems[i]);
					}
				}
			}		
		}
		#endregion

		#region 进出药单登帐
		/// <summary>
		/// 进出药单登帐
		/// </summary>
		private void m_mthInOrOutOrdAcct()
		{
			long lngRes = 0;
			clsMedStoreOrd_VO objItem = (clsMedStoreOrd_VO)this.m_objItem;
			objItem.m_objAcctEmp = new clsEmployeeVO();
			objItem.m_objAcctEmp = this.m_objOperator;
			objItem.m_strAcctDate = clsPublicParm.s_datGetServerDate().ToString("yyyy-MM-dd HH:mm:ss");

			lngRes = this.m_objManage.m_lngAcctMedStoreOrd(objItem);

			if(lngRes >0)
			{
				int intFlag =0;
				lngRes = this.m_objManage.m_lngChangeFinAfterAcctMedStoreOrd(objItem.m_strMedStoreOrdID.Trim(),out intFlag);

				if(lngRes >0)
				{
					switch(intFlag)
					{
						case 1:
							MessageBox.Show("登帐成功！","系统提示");
							break;
						case 0:
							objItem.m_objAcctEmp = new clsEmployeeVO();
							objItem.m_objAcctEmp.strEmpID = "";
							objItem.m_strAcctDate = "";
							lngRes = this.m_objManage.m_lngAcctMedStoreOrd(objItem);
							MessageBox.Show("登帐失败！\n登帐时出错。","系统提示");
							break;
						case -1:
							objItem.m_objAcctEmp = new clsEmployeeVO();
							objItem.m_objAcctEmp.strEmpID = "";
							objItem.m_strAcctDate = "";
							lngRes = this.m_objManage.m_lngAcctMedStoreOrd(objItem);
							MessageBox.Show("登帐失败！\n登帐时发生异常。","系统提示");
							break;
					}
				}
				else
				{
					objItem.m_objAcctEmp = new clsEmployeeVO();
					objItem.m_objAcctEmp.strEmpID = "";
					objItem.m_strAcctDate = "";
					lngRes = this.m_objManage.m_lngAcctMedStoreOrd(objItem);
					MessageBox.Show("登帐失败！\n更改帐务时出错。","系统提示");
				}
				m_mthPeriodSel();
			}
			else
			{
				MessageBox.Show("登帐失败！\n更改单据登帐标志时出错","系统提示");
			}
		}
		#endregion

		#region 盘点单登帐
		/// <summary>
		/// 盘点单登帐
		/// </summary>
		private void m_mthCheckAcct()
		{
			long lngRes = 0;
			clsMedStoreCheck_VO objItem = (clsMedStoreCheck_VO)this.m_objItem;
			objItem.m_objAcctEmp = new clsEmployeeVO();
			objItem.m_objAcctEmp = this.m_objOperator;
			objItem.m_strAcctDate = clsPublicParm.s_datGetServerDate().ToString("yyyy-MM-dd HH:mm:ss");

			lngRes = this.m_objManage.m_lngAcctMedStoreCheck(objItem);

			if(lngRes >0)
			{
				int intFlag =0;
				lngRes = this.m_objManage.m_lngChangeFinAfterAcctMedStoreCheck(objItem.m_strCheckID.Trim(),out intFlag);

				if(lngRes >0)
				{
					switch(intFlag)
					{
						case 1:
							MessageBox.Show("登帐成功！","系统提示");
							break;
						case 0:
							objItem.m_objAcctEmp = new clsEmployeeVO();
							objItem.m_objAcctEmp.strEmpID = "";
							objItem.m_strAcctDate = "";
							lngRes = this.m_objManage.m_lngAcctMedStoreCheck(objItem);
							MessageBox.Show("登帐失败！\n登帐时出错。","系统提示");
							break;
						case -1:
							objItem.m_objAcctEmp = new clsEmployeeVO();
							objItem.m_objAcctEmp.strEmpID = "";
							objItem.m_strAcctDate = "";
							lngRes = this.m_objManage.m_lngAcctMedStoreCheck(objItem);
							MessageBox.Show("登帐失败！\n登帐时发生异常。","系统提示");
							break;
					}
				}
				else
				{
					objItem.m_objAcctEmp = new clsEmployeeVO();
					objItem.m_objAcctEmp.strEmpID = "";
					objItem.m_strAcctDate = "";
					lngRes = this.m_objManage.m_lngAcctMedStoreCheck(objItem);
					MessageBox.Show("登帐失败！\n更改帐务时出错。","系统提示");
				}
				m_mthPeriodSel();
			}
			else
			{
				MessageBox.Show("登帐失败！\n更改单据登帐标志时出错","系统提示");
			}
		}
		#endregion

		#region 窗口初始化
		/// <summary>
		/// 初始化窗口
		/// </summary>
		public void m_mthInit()
		{
			m_mthClearPanl();
			m_mthGetOperator();
			m_mthGetStorage();
			m_mthGetCurPeriod();
			m_mthGetPeriodList();
			//			m_mthSetDataGridHeader();
			m_mthGetUnAndEnDetailList("0001");
			m_mthLockAcctButton();
		}
		#endregion

		#region 窗体操作

		#region 登帐
		/// <summary>
		/// 登帐
		/// </summary>
		public void m_mthAcct()
		{
			if (this.m_objItem != null)
			{
				string strType = this.m_objItem.GetType().FullName;

				switch(strType)
				{
					case "com.digitalwave.iCare.ValueObject.clsMedStoreOrd_VO":
						m_mthInOrOutOrdAcct();
						break;
					case "com.digitalwave.iCare.ValueObject.clsMedStoreCheck_VO":
						m_mthCheckAcct();
						break;
					default:
						MessageBox.Show("单据类型错误","系统提示");
						break;
				}					

			}
		}
		#endregion

		#region 登帐列表选择事件
		/// <summary>
		/// 登帐列表选择事件
		/// </summary>
		/// <param name="blnFlag">登帐标志，true：未登帐，false：已登帐</param>
		public void m_mthAcctListSel(bool blnFlag)
		{
			string strPeriod = this.m_objViewer.m_cboSelPeriod.SelectedValue.ToString().Trim();
			string strID = "";
			string strTypeID = "";
			int intSign =0;
			long lngRes = 0;
			DataTable dtbItem = null;
			string strSQL = "";
			int index = 0;

			if(blnFlag)
			{	
				m_mthUnLockAcctButton();
				index = this.m_objViewer.m_lsvUnAcct.SelectedItems[0].Index;
				dtbItem = (DataTable)this.m_objViewer.m_lsvUnAcct.SelectedItems[0].Tag;

				if(dtbItem != null)
				{
					strID = dtbItem.Rows[index]["ID"].ToString().Trim();
					strTypeID = dtbItem.Rows[index]["TYPE"].ToString().Trim();
					string strSign = dtbItem.Rows[index]["SIGN"].ToString().Trim();
					intSign = int.Parse(strSign);
				}
				
			}
			else
			{
				m_mthLockAcctButton();
				index = this.m_objViewer.m_lsvEnAcct.SelectedItems[0].Index;
				dtbItem = (DataTable)this.m_objViewer.m_lsvEnAcct.SelectedItems[0].Tag;

				if(dtbItem != null)
				{
					strID = dtbItem.Rows[index]["ID"].ToString().Trim();
					strTypeID = dtbItem.Rows[index]["TYPE"].ToString().Trim();
					string strSign = dtbItem.Rows[index]["SIGN"].ToString().Trim();
					intSign = int.Parse(strSign);
				}
			}
			m_mthNewItem(intSign);

			switch(intSign)
			{
				case 1:
				case 2:
					clsMedStoreOrdDe_VO[] objItemOrd = new clsMedStoreOrdDe_VO[0];					
					lngRes = this.m_objManage.m_lngGetMedStoreOrdDeByOrdID(strID,out objItemOrd);

					if(lngRes>0 && objItemOrd.Length >0)
					{
						this.m_objItem = objItemOrd[0];
						m_mthImpMedStoreInOrOutOrd();
					}
					break;
				case 3:
					clsMedStoreCheckDe_VO[] objItemCheck = new clsMedStoreCheckDe_VO[0];
					strSQL = " WHERE STORAGEORDTYPEID_CHR='" + strTypeID.Trim() + "' AND STORAGECHECKID_CHR='" + strID.Trim() + "' ";
					lngRes = this.m_objManage.m_lngGetMedStoreCheckDeByCheckID(strID,out objItemCheck);

					if(lngRes>0&& objItemCheck.Length >0)
					{
						this.m_objItem = objItemCheck[0];
						m_mthImpStorageCheck();
					}
					break;
			}
			
			
		}
		#endregion

		#region 帐务期选择事件
		/// <summary>
		/// 帐务期选择
		/// </summary>
		public void m_mthPeriodSel()
		{
			if(this.m_objViewer.m_cboSelPeriod.Items.Count>0)
			{
				string strPeriod = this.m_objViewer.m_cboSelPeriod.SelectedValue.ToString().Trim();
				m_mthGetUnAndEnDetailList(strPeriod);
			}
		}
		#endregion

		#endregion


	}
}
