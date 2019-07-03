using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// 药房限额设置控制类
	/// Create by kong 2004-07-05
	/// </summary>
	public class clsControlMedStoreLimit : com.digitalwave.GUI_Base.clsController_Base
	{
		#region 构造函数
		/// <summary>
		/// 
		/// </summary>
		public clsControlMedStoreLimit()
		{
			m_objManage = new clsDomainControlMedStoreBseInfo();
		}
		#endregion

		#region 变量
		clsDomainControlMedStoreBseInfo m_objManage = null;
		/// <summary>
		/// 药房限额数据
		/// </summary>
		clsMedStoreLimit_VO m_objItem;
		/// <summary>
		/// 药房
		/// </summary>
		clsMedStore_VO m_objMedStore;
		/// <summary>
		/// 当前选择行
		/// </summary>
		private int m_SelRow = 0;
		/// <summary>
		/// 保存药品资料
		/// </summary>
		DataTable SaveMed=new DataTable();
		/// <summary>
		/// 保存查找的数据
		/// </summary>
		DataTable dtbFind=new DataTable();
		/// <summary>
		/// 保存药房限额
		/// </summary>
		DataTable dtbStoreLimit=new DataTable();
		/// <summary>
		/// 判断是否选择药品
		/// </summary>
		int Comm=0;
		#endregion

		#region 设置窗体对象
		frmMedStoreLimit m_objViewer;
		/// <summary>
		/// 
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmMedStoreLimit)frmMDI_Child_Base_in;
		}
		#endregion

		#region 列表操作

		#region 向列表插入一条记录
		/// <summary>
		/// 向列表插入一条数据
		/// </summary>
		/// <param name="objItem">药房限额数据</param>
		private void m_mthInsertDetail(DataRow objItem)
		{
			if(objItem != null)
			{
				ListViewItem lsvItem = new ListViewItem(objItem["MEDICINEID_CHR"].ToString());
				lsvItem.SubItems.Add(objItem["medicinename_vchr"].ToString());
				lsvItem.SubItems.Add(objItem["UNITID_CHR"].ToString());
				lsvItem.SubItems.Add(objItem["LOWLIMIT_DEC"].ToString());
				lsvItem.SubItems.Add(objItem["HIGHLIMIT_DEC"].ToString());
				lsvItem.SubItems.Add(objItem["PLANQTY_DEC"].ToString());
				lsvItem.SubItems.Add(Convert.ToString(Convert.ToInt32(objItem["PLANPERCENT_DEC"]) * 100) + "%");
				lsvItem.Tag = objItem;
				this.m_objViewer.m_lsvDetail.Items.Add(lsvItem);
			}
		}
		#endregion

		#region 修改列表数据
		/// <summary>
		/// 修改列表数据
		/// </summary>
		/// <param name="objItem">药房数据</param>
		private void m_mthModifyDetail(DataRow objItem)
		{
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[3].Text = objItem["LOWLIMIT_DEC"].ToString();
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[4].Text = objItem["HIGHLIMIT_DEC"].ToString();
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[5].Text = objItem["PLANQTY_DEC"].ToString();
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[6].Text = Convert.ToString(Convert.ToInt32(objItem["PLANPERCENT_DEC"]) * 100) + "%";
			this.m_objViewer.m_lsvDetail.Items[m_SelRow].Tag = objItem;
		}
		#endregion

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

		#region 查找单位选项中对应的索引
		/// <summary>
		/// 查找单位选项中对应的索引
		/// </summary>
		/// <param name="objItem">需查询的单位</param>
		/// <returns></returns>
		private int m_intGetUnitIndex(clsUnit_VO objItem)
		{
			clsUnit_VO[] objItems = new clsUnit_VO[0];
			for(int i=0;i<objItems.Length;i++)
			{
				if(objItem.m_strUnitID.Trim() == objItems[i].m_strUnitID.Trim())
					return i;
			}

			return -1;
		}
		#endregion

		#region 获得列表数据
		/// <summary>
		/// 获得列表数据
		/// </summary>
		public void m_mthGetDetailList()
		{
			this.m_objViewer.m_lsvDetail.Items.Clear();

			if(this.m_objMedStore == null)
				return;
			long lngRes = 0;

			lngRes = this.m_objManage.m_lngGetMedStoreLimitByAnyWinID(this.m_objMedStore.m_strMedStoreID,out dtbStoreLimit);
			if(lngRes>0 && dtbStoreLimit.Rows.Count>0)
			{
				for(int i1=0;i1<dtbStoreLimit.Rows.Count;i1++)
				{
					m_mthInsertDetail(dtbStoreLimit.Rows[i1]);
				}
			}
		}
		#endregion

		#region 设置窗体数据
		/// <summary>
		/// 设置窗体数据
		/// </summary>
		/// <param name="objItem">药房数据</param>
		public void m_mthSetViewInfo(DataRow objItem)
		{
			if(objItem == null)
			{
				m_mthClear();
				this.m_objViewer.m_txtmedName.Enabled = true;
				this.m_objViewer.m_txtUnit.Text="";
				this.m_objViewer.m_txtLow.Text = "0.00";
				this.m_objViewer.m_txtHight.Text = "0.00";
				this.m_objViewer.m_txtPlanQty.Text = "0.00";
				this.m_objViewer.m_numPlanPercent.Value = 0;
				this.m_objViewer.m_txtMedID.Focus();
			}
			else
			{
				m_mthClear();
				this.m_objViewer.m_txtmedName.Enabled = false;
				this.m_objViewer.m_txtmedName.Text = objItem["medicinename_vchr"].ToString().Trim();
				this.m_objViewer.m_txtmedName.Tag = objItem["MEDICINEID_CHR"].ToString().Trim();
				this.m_objViewer.m_txtUnit.Text = objItem["UNITID_CHR"].ToString().Trim();
				this.m_objViewer.m_txtLow.Text =objItem["LOWLIMIT_DEC"].ToString().Trim();
				this.m_objViewer.m_txtHight.Text = objItem["HIGHLIMIT_DEC"].ToString().Trim();
				this.m_objViewer.m_txtPlanQty.Text =objItem["PLANQTY_DEC"].ToString().Trim();
				this.m_objViewer.m_numPlanPercent.Value = Convert.ToDecimal(Convert.ToInt32(objItem["PLANPERCENT_DEC"]) * 100);
			}
		}
		#endregion

		#region 窗体初始化
		/// <summary>
		/// 窗体初始化
		/// </summary>
		public void m_mthInit()
		{
			m_mthGetMedStore();
			m_mthSetViewInfo(null);
			m_lngSetupTable();
		}
		#endregion

		#region 药品输入框的更改事件
		/// <summary>
		/// 药品输入框的更改事件
		/// </summary>
		public void m_mthMedicineChange()
		{
			if(this.m_objViewer.m_txtmedName.Tag == null)
				return;

			clsMedicine_VO objItem = (clsMedicine_VO)this.m_objViewer.m_txtMedID.Tag;
		}
		#endregion

		#region 初始化查找数据表
		/// <summary>
		/// 初始化查找数据表
		/// </summary>
		private void m_lngSetupTable()
		{
			dtbFind.Columns.Add("MEDICINEID_CHR");
			dtbFind.Columns.Add("MEDICINENAME_VCHR");
			dtbFind.Columns.Add("OPUNIT_CHR");
			dtbFind.Columns.Add("PYCODE_CHR");
			dtbFind.Columns.Add("WBCODE_CHR");
		}
		#endregion

		#region 显示药品选择列表
		/// <summary>
		/// 显示药品选择列表
		/// </summary>
		public void m_mthEnablePopMed()
		{
			long lngRes = m_objManage.m_lngGetMed(out SaveMed);
			if(lngRes>0&&SaveMed.Rows.Count>0)
				this.m_objViewer.ctlDataGridMed.m_mthSetDataTable(SaveMed);
			this.m_objViewer.ctlDataGridMed.Left = this.m_objViewer.m_txtMedID.Left;
			this.m_objViewer.ctlDataGridMed.Top = this.m_objViewer.m_txtMedID.Top + this.m_objViewer.m_txtMedID.Height;
			this.m_objViewer.ctlDataGridMed.Visible = true;

		}
		#endregion

		#region  查找事件
		/// <summary>
		/// 查找事件
		/// </summary>
		public void m_lngFind()
		{
			if(this.m_objViewer.m_txtMedID.Text.Trim()==""||Comm==1)
			{
				this.m_objViewer.ctlDataGridMed.m_mthSetDataTable(SaveMed);
				dtbFind.Rows.Clear();
				Comm=0;
				return;
			}
			dtbFind.Rows.Clear();
			int Command;
			string strSele;
			try
			{
				Command=Convert.ToInt32(this.m_objViewer.m_txtMedID.Text.Trim());
				strSele=this.m_objViewer.m_txtMedID.Text.Trim();
				for(int i1=0;i1<SaveMed.Rows.Count;i1++)
				{
					Command=SaveMed.Rows[i1]["MEDICINEID_CHR"].ToString().IndexOf(strSele,0);
					if(Command==0)
					{
						DataRow FindRow=dtbFind.NewRow();
						FindRow["MEDICINEID_CHR"]=SaveMed.Rows[i1]["MEDICINEID_CHR"];
						FindRow["MEDICINENAME_VCHR"]=SaveMed.Rows[i1]["MEDICINENAME_VCHR"];
						FindRow["OPUNIT_CHR"]=SaveMed.Rows[i1]["OPUNIT_CHR"];
						FindRow["PYCODE_CHR"]=SaveMed.Rows[i1]["PYCODE_CHR"];
						FindRow["WBCODE_CHR"]=SaveMed.Rows[i1]["WBCODE_CHR"];
						dtbFind.Rows.Add(FindRow);
					}
				}
			}
			catch
			{
				strSele=this.m_objViewer.m_txtMedID.Text.Trim();
				string strSele1=strSele.ToUpper();
				for(int i1=0;i1<SaveMed.Rows.Count;i1++)
				{
					if(SaveMed.Rows[i1]["PYCODE_CHR"].ToString().IndexOf(strSele1,0)==0||SaveMed.Rows[i1]["WBCODE_CHR"].ToString().IndexOf(strSele1,0)==0||SaveMed.Rows[i1]["MEDICINENAME_VCHR"].ToString().IndexOf(strSele1,0)==0)
					{
						DataRow FindRow=dtbFind.NewRow();
						FindRow["MEDICINEID_CHR"]=SaveMed.Rows[i1]["MEDICINEID_CHR"];
						FindRow["MEDICINENAME_VCHR"]=SaveMed.Rows[i1]["MEDICINENAME_VCHR"];
						FindRow["OPUNIT_CHR"]=SaveMed.Rows[i1]["OPUNIT_CHR"];
						FindRow["PYCODE_CHR"]=SaveMed.Rows[i1]["PYCODE_CHR"];
						FindRow["WBCODE_CHR"]=SaveMed.Rows[i1]["WBCODE_CHR"];
						dtbFind.Rows.Add(FindRow);
					}
				}
			}
			this.m_objViewer.ctlDataGridMed.m_mthSetDataTable(dtbFind);
		}
		#endregion

		#region  药品选择事件
		/// <summary>
		/// 药品选择事件
		/// </summary>
		public void m_lngSeleMed()
		{
			Comm=1;
			if(this.dtbFind.Rows.Count==0)
			{
				DataRow seleRow=SaveMed.NewRow();
				seleRow=SaveMed.Rows[this.m_objViewer.ctlDataGridMed.CurrentCell.RowNumber];
				int index;
				if(!m_mthCheckExistsList(seleRow,out index))
				{
					if(System.Windows.Forms.MessageBox.Show("药品已经在列表中\n更该药品数据吗？","",System.Windows.Forms.MessageBoxButtons.OKCancel,
						System.Windows.Forms.MessageBoxIcon.Warning,System.Windows.Forms.MessageBoxDefaultButton.Button1) == 
						System.Windows.Forms.DialogResult.OK)
					{
						this.m_objViewer.m_lsvDetail.Items[index].Selected = true;
						m_mthDetailSel();
						return;
					}
					else
					{
						this.m_objViewer.m_txtMedID.Clear();
						this.m_objViewer.m_txtMedID.Focus();
						return;
					}
				}
				else
				{
					this.m_objViewer.m_txtmedName.Text=seleRow["MEDICINENAME_VCHR"].ToString().Trim();
					this.m_objViewer.m_txtmedName.Tag=seleRow["MEDICINEID_CHR"].ToString().Trim();
				}
			}
			else
			{
				DataRow seleRow=dtbFind.NewRow();
				seleRow=dtbFind.Rows[this.m_objViewer.ctlDataGridMed.CurrentCell.RowNumber];
				int index;
				if(!m_mthCheckExistsList(seleRow,out index))
				{
					if(System.Windows.Forms.MessageBox.Show("药品已经在列表中\n更该药品数据吗？","",System.Windows.Forms.MessageBoxButtons.OKCancel,
						System.Windows.Forms.MessageBoxIcon.Warning,System.Windows.Forms.MessageBoxDefaultButton.Button1) == 
						System.Windows.Forms.DialogResult.OK)
					{
						this.m_objViewer.m_lsvDetail.Items[index].Selected = true;
						m_mthDetailSel();
						return;
					}
					else
					{
						this.m_objViewer.m_txtMedID.Clear();
						this.m_objViewer.m_txtMedID.Focus();
						return;
					}
				}
				else
				{
					this.m_objViewer.m_txtmedName.Text=seleRow["MEDICINENAME_VCHR"].ToString().Trim();
					this.m_objViewer.m_txtmedName.Tag=seleRow["MEDICINEID_CHR"].ToString().Trim();
				}
			}
			this.m_objViewer.ctlDataGridMed.Visible=false;
		}
		#endregion

		#region 检测列表中是否已经存在该药品
		/// <summary>
		/// 检测列表中是否已经存在该药品信息
		/// </summary>
		/// <param name="objItem">药品数据</param>
		/// <param name="index">索引</param>
		/// <returns></returns>
		private bool m_mthCheckExistsList(DataRow objItem,out int index)
		{
			bool blnResult = true;
			index =0;

			for(int i=0;i<this.m_objViewer.m_lsvDetail.Items.Count;i++)
			{
				DataRow objTmp =dtbStoreLimit.NewRow();
				objTmp = (DataRow)this.m_objViewer.m_lsvDetail.Items[i].Tag;
				if(objTmp != null)
				{
					if(objItem["MEDICINEID_CHR"].ToString().Trim() == objTmp["MEDICINEID_CHR"].ToString().Trim())
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

		#region 药房更改事件
		/// <summary>
		/// 药房更改事件
		/// </summary>
		public void m_mthChangeMedStore()
		{
			if(this.m_objViewer.m_cboMedStore.Tag == null)
				return;

			clsMedStore_VO[] objItems = (clsMedStore_VO[])this.m_objViewer.m_cboMedStore.Tag;
			int index = this.m_objViewer.m_cboMedStore.SelectedIndex;
			this.m_objMedStore = objItems[index];
			m_mthGetDetailList();
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

			if(this.m_objViewer.m_txtmedName.Enabled==true)
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
                    DataRow objItem=dtbStoreLimit.NewRow();
					objItem = (DataRow)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag;
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
			DataRow SaveRow=dtbStoreLimit.NewRow();
			SaveRow["MEDSTOREID_CHR"]= this.m_objMedStore.m_strMedStoreID;
			SaveRow["MEDICINEID_CHR"]= (string)this.m_objViewer.m_txtmedName.Tag;
			SaveRow["medicinename_vchr"]=this.m_objViewer.m_txtmedName.Text.Trim();
			SaveRow["UNITID_CHR"] = this.m_objViewer.m_txtUnit.Text.Trim();
			SaveRow["LOWLIMIT_DEC"] = float.Parse(this.m_objViewer.m_txtLow.Text.Trim());
			SaveRow["HIGHLIMIT_DEC"] = float.Parse(this.m_objViewer.m_txtHight.Text.Trim());
			SaveRow["PLANQTY_DEC"] = float.Parse(this.m_objViewer.m_txtPlanQty.Text.Trim());
			SaveRow["PLANPERCENT_DEC"]= Convert.ToSingle(this.m_objViewer.m_numPlanPercent.Value / 100);

			long lngRes = this.m_objManage.m_lngAddNewMedStoreLimit(SaveRow);

			if(lngRes >0)
			{
				m_mthInsertDetail(SaveRow);
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
			DataRow ModifyRow=dtbStoreLimit.NewRow();
			ModifyRow["MEDSTOREID_CHR"] = this.m_objMedStore.m_strMedStoreID;
			ModifyRow["MEDICINEID_CHR"] = (string)this.m_objViewer.m_txtmedName.Tag;
			ModifyRow["LOWLIMIT_DEC"] = float.Parse(this.m_objViewer.m_txtLow.Text.Trim());
			ModifyRow["HIGHLIMIT_DEC"] = float.Parse(this.m_objViewer.m_txtHight.Text.Trim());
			ModifyRow["PLANQTY_DEC"] = float.Parse(this.m_objViewer.m_txtPlanQty.Text.Trim());
			ModifyRow["PLANPERCENT_DEC"] = Convert.ToSingle(this.m_objViewer.m_numPlanPercent.Value / 100);
			long lngRes = this.m_objManage.m_lngUpdMedStoreLimitByID(ModifyRow);
			
			if(lngRes >0)
			{
				m_mthModifyDetail(ModifyRow);
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
					DataRow objItem =dtbStoreLimit.NewRow();
					objItem = (DataRow)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag;

					long lngRes = this.m_objManage.m_lngDeleteMedStoreLimitByID(objItem["MEDSTOREID_CHR"].ToString().Trim(),objItem["MEDICINEID_CHR"].ToString().Trim());

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

			if(this.m_objViewer.m_numPlanPercent.Value > 100)
			{
				return false;
			}

			if(this.m_objViewer.m_txtmedName.Text.Trim() == "" || this.m_objViewer.m_txtmedName.Tag == null)
			{
				this.m_ephHandler.m_mthAddControl(this.m_objViewer.m_txtmedName);
				blnResult = false;
			}
			if(this.m_objViewer.m_txtLow.Text.Trim() == "" || float.Parse(this.m_objViewer.m_txtLow.Text.Trim()) < 0)
			{
				this.m_ephHandler.m_mthAddControl(this.m_objViewer.m_txtLow);
				blnResult = false;
			}
			if(this.m_objViewer.m_txtHight.Text.Trim() == "" || float.Parse(this.m_objViewer.m_txtHight.Text.Trim()) < 0)
			{
				this.m_ephHandler.m_mthAddControl(this.m_objViewer.m_txtHight);
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
			this.m_objViewer.m_txtmedName.Clear();
			this.m_objViewer.m_txtLow.Clear();
			this.m_objViewer.m_txtHight.Clear();
			this.m_objViewer.m_txtPlanQty.Clear();
			this.m_objViewer.m_txtUnit.Clear();
			this.m_objViewer.m_numPlanPercent.Value = 0;
		}
		#endregion
	}
}
