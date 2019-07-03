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
	/// clsControlMedStoreOut 的摘要说明。
	/// </summary>
	public class clsControlMedStoreOut: com.digitalwave.GUI_Base.clsController_Base
	{
		/// <summary>
		/// 构造函数逻辑
		/// </summary>
		public clsControlMedStoreOut()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 设置窗体对象
		frmMedStoreOut m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmMedStoreOut)frmMDI_Child_Base_in;
		}
		#endregion

		#region 变量
		/// <summary>
		/// 
		/// </summary>
		clsDomainControlMedStore objSVC=new clsDomainControlMedStore();
		/// <summary>
		/// 保存入库类型信息
		/// </summary>
		DataTable dtbType=new DataTable();
		/// <summary>
		/// 保存药房信息
		/// </summary>
		DataTable dtbStorage=new DataTable();
		/// <summary>
		/// 新增或修改标志.0新增，1修改整个入库单及明细，2只修改入单不修改明细。
		/// </summary>
		int isAddNew=0;
		/// <summary>
		/// 保存明细表
		/// </summary>
		DataTable tableDeOut=new DataTable();
		/// <summary>
		/// 保存药品基本信息
		/// </summary>
		DataTable dtbMedicine=null;
		/// <summary>
		/// 保存查找数据
		/// </summary>
		DataTable dtbFind=new DataTable();
		/// <summary>
		/// 保存出药数据
		/// </summary>
		DataTable dtbSaveOrdOut=new DataTable();
		/// <summary>
		/// 删除标志，1删除明细数据，2删除入库单数据，0没有要删除的数据
		/// </summary>
		int DelCommand=0;
		/// <summary>
		/// 保存所有符合查找条件的出药单数据
		/// </summary>
		DataTable objFindTable=new DataTable();
		/// <summary>
		/// 保存财务期数据
		/// </summary>
		clsPeriod_VO[] objPriodItems = new clsPeriod_VO[0];
		/// <summary>
		/// 保存当前财务期的索引
		/// </summary>
		int intSelPeriod=-1;

		#endregion

		#region 初始化窗体
		/// <summary>
		/// 初始化窗体
		/// </summary>
		public void m_lngFrmLoad()
		{
			m_lngFillComboBoxOut();
			this.m_objViewer.txtGrearMan.Text=this.m_objViewer.LoginInfo.m_strEmpName;
			com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
			this.m_objViewer.txtInOrdID.Text=objHRPSvc.m_strGetNewID("t_opr_medstoreord","MEDSTOREORDID_CHR",18);
			this.m_objViewer.dateTime.Value=DateTime.Now;
			m_lngSetupDeTable();
			m_lngSetupFindTable();
			m_mthGetPeriodList();
		}
		#endregion

		#region 获得帐务期列表
		/// <summary>
		/// 获得帐务期列表
		/// </summary>
		private void m_mthGetPeriodList()
		{
			objPriodItems = clsPublicParm.s_GetPeriodList();
			string nowdate=clsPublicParm.s_datGetServerDate().Date.ToString();
			if(objPriodItems.Length >0)
			{
				int j2=0;
				for(int i1=0;i1<objPriodItems.Length;i1++)
				{
					this.m_objViewer.m_cboSelPeriod.Items.Insert(i1,objPriodItems[i1].m_strStartDate + " 至 " + objPriodItems[i1].m_strEndDate);
					if(Convert.ToDateTime(nowdate)>=Convert.ToDateTime(objPriodItems[i1].m_strStartDate)&&Convert.ToDateTime(nowdate)<=Convert.ToDateTime(objPriodItems[i1].m_strEndDate))
					{
						intSelPeriod = i1;
						this.m_objViewer.m_cboSelPeriod.Tag = objPriodItems[i1].m_strPeriodID;
					}
					j2=i1+1;
				}
				this.m_objViewer.m_cboSelPeriod.Items.Insert(j2,"所有财务期数据");
				if(intSelPeriod!=-1)
				{
					m_objViewer.m_cboSelPeriod.SelectedIndex = intSelPeriod;
				}
				else
				{
					MessageBox.Show("系统找不到当前财务期,请先设置财务期!","系统提示");
				}

			}
		}
		#endregion

		#region 财务期选择事件
		/// <summary>
		/// 财务期选择事件
		/// </summary>
		public void m_lngPriodchang()
		{
			this.m_objViewer.LSVInord.Items.Clear();
			this.m_objViewer.LSVInOrdEmp.Items.Clear();
			this.m_objViewer.LSVInOrdDe.Items.Clear();
			if(this.m_objViewer.m_cboSelPeriod.Text!="所有财务期数据")
			{
				m_lngGetAndFillOut(objPriodItems[this.m_objViewer.m_cboSelPeriod.SelectedIndex].m_strPeriodID);
				this.m_objViewer.m_cboSelPeriod.Tag=objPriodItems[this.m_objViewer.m_cboSelPeriod.SelectedIndex].m_strPeriodID;
			}
			else
			{
				m_lngGetAndFillOut("");
				this.m_objViewer.m_cboSelPeriod.Tag="";
			}
			if(this.m_objViewer.m_cboSelPeriod.SelectedIndex!=intSelPeriod)
			{
				this.m_objViewer.panel4.Enabled=false;
				this.m_objViewer.panel3.Enabled=false;
				this.m_objViewer.m_btnNew.Enabled=false;
				this.m_objViewer.btnSave.Enabled=false;
				this.m_objViewer.dntEmp.Enabled=false;
				this.m_objViewer.btnDelect.Enabled=false;
			}
			else
			{	
				this.m_objViewer.panel4.Enabled=true;
				this.m_objViewer.panel3.Enabled=true;
				this.m_objViewer.m_btnNew.Enabled=true;
				this.m_objViewer.btnSave.Enabled=true;
				this.m_objViewer.dntEmp.Enabled=true;
				this.m_objViewer.btnDelect.Enabled=true;
				
			}
		}
		#endregion
        
		#region 初始化明细表
		/// <summary>
		/// 初始化明细表
		/// </summary>
		private void m_lngSetupDeTable()
		{
			tableDeOut.Columns.Add("MEDICINEID_CHR");
			tableDeOut.Columns.Add("MEDSTOREORDDEID_CHR");
			tableDeOut.Columns.Add("MEDICINENAME_VCHR");
			tableDeOut.Columns.Add("SYSLOTNO_CHR");
			tableDeOut.Columns.Add("ROWNO_CHR");
			tableDeOut.Columns.Add("QTY_DEC");
			tableDeOut.Columns.Add("SALEUNITPRICE_DEC");
			tableDeOut.Columns.Add("SALETOLPRICE_DEC");
			tableDeOut.Columns.Add("MEDSPEC_VCHR");
			tableDeOut.Columns.Add("UNITID_CHR");
		}
		#endregion

		#region 获得所有的入库单并填充到“未审核”和“己审核”列表中
		/// <summary>
		/// 获得所有的入库单并填充到“未审核”和“己审核”列表中
		/// </summary>
		/// <param name="nowPriod">财务期ID</param>
		private void m_lngGetAndFillOut(string nowPriod)
		{
			long lngRes=this.objSVC.m_lngGetMedStoreOrdOut((string)this.m_objViewer.comboType.Tag,out dtbSaveOrdOut,nowPriod);
			if(lngRes>0&&dtbSaveOrdOut.Rows.Count>0)
			{
				for(int i1=0;i1<dtbSaveOrdOut.Rows.Count;i1++)
				{
					if(dtbSaveOrdOut.Rows[i1]["PSTATUS_INT"].ToString()=="1")
						m_lngFillLsvAumNo(dtbSaveOrdOut.Rows[i1]);
					else
						m_lngFillLsvAumOk(dtbSaveOrdOut.Rows[i1]);
				}
			}
		}
		#endregion

		#region 初始化查找数据表
		/// <summary>
		/// 初始化查找数据表
		/// </summary>
		private void m_lngSetupFindTable()
		{
			dtbFind.Columns.Add("MEDICINEID_CHR");
			dtbFind.Columns.Add("ASSISTCODE_CHR");
			dtbFind.Columns.Add("MEDICINENAME_VCHR");
			dtbFind.Columns.Add("MEDSPEC_VCHR");
			dtbFind.Columns.Add("IPUNIT_CHR");
			dtbFind.Columns.Add("UNITPRICE_MNY");
			dtbFind.Columns.Add("PYCODE_CHR");
			dtbFind.Columns.Add("WBCODE_CHR");
		}
		#endregion

		#region 填充药房及入库类型信息
		/// <summary>
		/// 填充药房及入库类型信息
		/// </summary>
		private void m_lngFillComboBoxOut()
		{
			string strTypeName="";
			long lngRes=this.objSVC.m_lngGetTypeAndStorageOut((string)this.m_objViewer.comboType.Tag,out strTypeName,out dtbStorage);
			if(dtbStorage.Rows.Count>0)
			{
				for(int i1=0;i1<dtbStorage.Rows.Count;i1++)
				{
					this.m_objViewer.comboStroage.Items.Add(dtbStorage.Rows[i1]["MEDSTORENAME_VCHR"].ToString());
				}
				this.m_objViewer.comboStroage.Items.Add("");
			}

		}
		#endregion

		#region 增加按钮事件
		/// <summary>
		/// 增加按钮事件
		/// </summary>
		public void m_lngAddClickOut()
		{
			if(isAddNew!=2)
			{
				DataRow DeDataRow=tableDeOut.NewRow();
				m_lngFillToDeDataRowOut(out DeDataRow);
				m_lngFillLSVInOrdDeOut(DeDataRow);
				double TolMoney=0;
				m_lngCountTolOut(out TolMoney);
				this.m_objViewer.txtTolmoney.Text=TolMoney.ToString();
				m_lngClearOut(1);
			}
			else
			{
				DataRow DeDataRow=tableDeOut.NewRow();
				m_lngFillToDeDataRowOut(out DeDataRow);
				string newDeid;
				double tolMoney;
				long lngRes=this.objSVC.m_lngAddNewDe(this.m_objViewer.txtInOrdID.Text.Trim(),Convert.ToDouble(this.m_objViewer.txtTolmoney.Text),DeDataRow,out newDeid,out tolMoney);
				if(lngRes>0)
				{
					DeDataRow["MEDSTOREORDDEID_CHR"]=newDeid;
					m_lngFillLSVInOrdDeOut(DeDataRow);
					this.m_objViewer.txtTolmoney.Text=tolMoney.ToString();
					this.m_objViewer.LSVInord.SelectedItems[0].SubItems[3].Text=tolMoney.ToString();
					m_lngClearOut(1);
				}
			}
		}
		#endregion

		#region 清空用户输入
		/// <summary>
		/// 清空用户输入
		/// </summary>
		/// <param name="Command">1,清空输入明细。2，清空全部</param>
		public void m_lngClearOut(int Command)
		{
			this.m_objViewer.txtfind.Text="";
			this.m_objViewer.txtmedicine.Text="";
			this.m_objViewer.txttol.Text="0";
			this.m_objViewer.txtbuyprice.Text="0.00";
			this.m_objViewer.txtTolPrice.Text="0.00";
			this.m_objViewer.txtSpace.Text="";
			this.m_objViewer.txtUnti.Text="";
			this.m_objViewer.errorProvider1.SetError(this.m_objViewer.comboType,"");
			this.m_objViewer.errorProvider1.SetError(this.m_objViewer.txtmedicine,"");
			this.m_objViewer.errorProvider1.SetError(this.m_objViewer.txttol,"");
			if(Command==2)
			{
				isAddNew=0;
				this.m_objViewer.btnSave.Text="保存F2";
				this.m_objViewer.lblfind.Text="查找药品";
				this.m_objViewer.dateTime.Value=DateTime.Now;
				this.m_objViewer.btnAdd.Enabled=true;
				this.m_objViewer.btnClear.Enabled=true;
				com.digitalwave.iCare.middletier.HRPService.clsHRPTableService objHRPSvc = new com.digitalwave.iCare.middletier.HRPService.clsHRPTableService();
				this.m_objViewer.txtInOrdID.Text=objHRPSvc.m_strGetNewID("t_opr_medstoreord","MEDSTOREORDID_CHR",18);
				this.m_objViewer.comboStroage.Text="";
				this.m_objViewer.comboStroage.Tag=null;
				this.m_objViewer.txtTolmoney.Text="0.00";
				this.m_objViewer.m_txtMemo.Text="";
				this.m_objViewer.LSVInOrdDe.Items.Clear();
				this.m_objViewer.comboType.Focus();
			}
		}

		#endregion

		#region 计算入库单的总金额
		/// <summary>
		/// 计算入库单的总金额
		/// </summary>
		/// <param name="Tolmoney"></param>
		private void m_lngCountTolOut(out double Tolmoney)
		{
			Tolmoney=0;
			if(this.m_objViewer.LSVInOrdDe.Items.Count>0)
			{
				for(int i1=0;i1<this.m_objViewer.LSVInOrdDe.Items.Count;i1++)
				{
					DataRow Row=tableDeOut.NewRow();
					Row=(DataRow)this.m_objViewer.LSVInOrdDe.Items[i1].Tag;
					if(Row["SALETOLPRICE_DEC"].ToString()!="")
						Tolmoney+=Convert.ToDouble(Row["SALETOLPRICE_DEC"]);
				}
			}
		}
		#endregion

		#region 把用户输入的明细数据绑定到DataRow
		/// <summary>
		/// 把用户输入的明细数据绑定到DataRow
		/// </summary>
		/// <param name="DeDataRow"></param>
		private void m_lngFillToDeDataRowOut(out DataRow DeDataRow)
		{
			DeDataRow=tableDeOut.NewRow();
			DeDataRow["MEDSTOREORDDEID_CHR"]=(string)this.m_objViewer.txtfind.Tag;
			DeDataRow["MEDICINEID_CHR"]=(string)this.m_objViewer.txtmedicine.Tag;
			DeDataRow["MEDICINENAME_VCHR"]=this.m_objViewer.txtmedicine.Text.Trim();
			int Row;
			if(this.m_objViewer.LSVInOrdDe.Items.Count>0)
				Row=Convert.ToInt16(this.m_objViewer.LSVInOrdDe.Items[this.m_objViewer.LSVInOrdDe.Items.Count-1].SubItems[0].Text)+1;
			else
				Row=1;
			DeDataRow["ROWNO_CHR"]=Row.ToString("000");
			DeDataRow["QTY_DEC"]=Convert.ToInt32(this.m_objViewer.txttol.Text.Trim());
			DeDataRow["SALEUNITPRICE_DEC"]=Convert.ToDouble(this.m_objViewer.txtbuyprice.Text.Trim());
			DeDataRow["SALETOLPRICE_DEC"]=Convert.ToDouble(this.m_objViewer.txtbuyprice.Text.Trim())*Convert.ToInt32(this.m_objViewer.txttol.Text.Trim());
			DeDataRow["MEDSPEC_VCHR"]=this.m_objViewer.txtSpace.Text.Trim();
			DeDataRow["UNITID_CHR"]=this.m_objViewer.txtUnti.Text.Trim();
		}
		#endregion

		#region  填充入库明细列表
		/// <summary>
		/// 填充入库明细列表
		/// </summary>
		/// <param name="tableRow"></param>
		private void m_lngFillLSVInOrdDeOut(DataRow tableRow)
		{
			ListViewItem LisTemp=null;
			LisTemp=new ListViewItem(tableRow["ROWNO_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["MEDICINEID_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["MEDICINENAME_VCHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["MEDSPEC_VCHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["UNITID_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["QTY_DEC"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["SALEUNITPRICE_DEC"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["SALETOLPRICE_DEC"].ToString().Trim());
			LisTemp.Tag=tableRow;
			this.m_objViewer.LSVInOrdDe.Items.Add(LisTemp);
		}
		#endregion

		#region 填充药品信息
		/// <summary>
		/// 填充药品信息
		/// </summary>
		public void m_lngFillDgrOut()
		{
			if(dtbMedicine==null)
			{
				long lngRes=0;
				lngRes=objSVC.m_lngGetAllMedicine(out dtbMedicine);
			}
			if(dtbMedicine.Rows.Count>0)
			{
				this.m_objViewer.dgrMedicine.m_mthSetDataTable(dtbMedicine);
			}
			this.m_objViewer.dgrMedicine.Top=this.m_objViewer.panel3.Top-this.m_objViewer.dgrMedicine.Height-6;
			this.m_objViewer.dgrMedicine.Left=this.m_objViewer.panel4.Left;
			this.m_objViewer.dgrMedicine.Visible=true;
			this.m_objViewer.dgrMedicine.m_mthSelectARow(0);
			dtbFind.Rows.Clear();
		}
		#endregion

		#region  查找事件
		/// <summary>
		/// 查找事件
		/// </summary>
		public void m_lngFind()
		{
			if(this.m_objViewer.comboStroage.Text=="")
			{
				MessageBox.Show("请先选择要出药的药房！","药房出库提示");
				this.m_objViewer.comboStroage.Focus();
				return;
			}
			string strID=(string)this.m_objViewer.comboStroage.Tag;
			long lngRes=0;
			lngRes=objSVC.m_lngGetMedicineByID(out dtbMedicine,strID);
			if(this.m_objViewer.txtfind.Text.Trim()=="")
			{
				this.m_objViewer.dgrMedicine.m_mthSetDataTable(dtbMedicine);
				this.m_objViewer.dgrMedicine.Tag="dtbMedicine";
				this.m_objViewer.dgrMedicine.Top=this.m_objViewer.panel3.Top-this.m_objViewer.dgrMedicine.Height-6;
				this.m_objViewer.dgrMedicine.Left=this.m_objViewer.panel4.Left;
				this.m_objViewer.dgrMedicine.Visible=true;
				this.m_objViewer.dgrMedicine.m_mthSelectARow(0);
				return;
			}
			dtbFind.Rows.Clear();
			string strSele=this.m_objViewer.txtfind.Text.Trim();
			if(strSele=="")
			{
				this.m_objViewer.dgrMedicine.m_mthSetDataTable(dtbMedicine);
				this.m_objViewer.dgrMedicine.Tag="dtbMedicine";
				this.m_objViewer.dgrMedicine.Top=this.m_objViewer.panel3.Top-this.m_objViewer.dgrMedicine.Height-6;
				this.m_objViewer.dgrMedicine.Left=this.m_objViewer.panel4.Left;
				this.m_objViewer.dgrMedicine.Visible=true;
				this.m_objViewer.dgrMedicine.m_mthSelectARow(0);
				return;
			}
			if(clsMedStorePublic.IsEngOrNumOrChina(strSele)==3||clsMedStorePublic.IsEngOrNumOrChina(strSele)==1)
			{
				for(int i1=0;i1<dtbMedicine.Rows.Count;i1++)
				{
					if(dtbMedicine.Rows[i1]["ASSISTCODE_CHR"].ToString().IndexOf(strSele,0)==0)
					{
						DataRow FindRow=dtbFind.NewRow();
						FindRow["MEDICINEID_CHR"]=dtbMedicine.Rows[i1]["MEDICINEID_CHR"];
						FindRow["ASSISTCODE_CHR"]=dtbMedicine.Rows[i1]["ASSISTCODE_CHR"];
						FindRow["MEDICINENAME_VCHR"]=dtbMedicine.Rows[i1]["MEDICINENAME_VCHR"];
						FindRow["MEDSPEC_VCHR"]=dtbMedicine.Rows[i1]["MEDSPEC_VCHR"];
						FindRow["IPUNIT_CHR"]=dtbMedicine.Rows[i1]["IPUNIT_CHR"];
						FindRow["UNITPRICE_MNY"]=dtbMedicine.Rows[i1]["UNITPRICE_MNY"];
						FindRow["PYCODE_CHR"]=dtbMedicine.Rows[i1]["PYCODE_CHR"];
						FindRow["WBCODE_CHR"]=dtbMedicine.Rows[i1]["WBCODE_CHR"];
						dtbFind.Rows.Add(FindRow);
					}
				}
			}
			if(clsMedStorePublic.IsEngOrNumOrChina(strSele)==3)
			{
				string strSele1=strSele.ToUpper();
				for(int i1=0;i1<dtbMedicine.Rows.Count;i1++)
				{
					if(dtbMedicine.Rows[i1]["PYCODE_CHR"].ToString().IndexOf(strSele1,0)==0||dtbMedicine.Rows[i1]["WBCODE_CHR"].ToString().IndexOf(strSele1,0)==0)
					{
						DataRow FindRow=dtbFind.NewRow();
						FindRow["MEDICINEID_CHR"]=dtbMedicine.Rows[i1]["MEDICINEID_CHR"];
						FindRow["ASSISTCODE_CHR"]=dtbMedicine.Rows[i1]["ASSISTCODE_CHR"];
						FindRow["MEDICINENAME_VCHR"]=dtbMedicine.Rows[i1]["MEDICINENAME_VCHR"];
						FindRow["MEDSPEC_VCHR"]=dtbMedicine.Rows[i1]["MEDSPEC_VCHR"];
						FindRow["IPUNIT_CHR"]=dtbMedicine.Rows[i1]["IPUNIT_CHR"];
						FindRow["UNITPRICE_MNY"]=dtbMedicine.Rows[i1]["UNITPRICE_MNY"];
						FindRow["PYCODE_CHR"]=dtbMedicine.Rows[i1]["PYCODE_CHR"];
						FindRow["WBCODE_CHR"]=dtbMedicine.Rows[i1]["WBCODE_CHR"];
						dtbFind.Rows.Add(FindRow);
					}
				}
			}
			if(clsMedStorePublic.IsEngOrNumOrChina(strSele)==2||clsMedStorePublic.IsEngOrNumOrChina(strSele)==4)
			{
				for(int i1=0;i1<dtbMedicine.Rows.Count;i1++)
				{
					if(dtbMedicine.Rows[i1]["MEDICINENAME_VCHR"].ToString().IndexOf(strSele,0)==0)
					{
						DataRow FindRow=dtbFind.NewRow();
						FindRow["MEDICINEID_CHR"]=dtbMedicine.Rows[i1]["MEDICINEID_CHR"];
						FindRow["ASSISTCODE_CHR"]=dtbMedicine.Rows[i1]["ASSISTCODE_CHR"];
						FindRow["MEDICINENAME_VCHR"]=dtbMedicine.Rows[i1]["MEDICINENAME_VCHR"];
						FindRow["MEDSPEC_VCHR"]=dtbMedicine.Rows[i1]["MEDSPEC_VCHR"];
						FindRow["IPUNIT_CHR"]=dtbMedicine.Rows[i1]["IPUNIT_CHR"];
						FindRow["UNITPRICE_MNY"]=dtbMedicine.Rows[i1]["UNITPRICE_MNY"];
						FindRow["PYCODE_CHR"]=dtbMedicine.Rows[i1]["PYCODE_CHR"];
						FindRow["WBCODE_CHR"]=dtbMedicine.Rows[i1]["WBCODE_CHR"];
						dtbFind.Rows.Add(FindRow);
					}
				}
			}
			if(dtbFind.Rows.Count==0)
				return;
			this.m_objViewer.dgrMedicine.m_mthSetDataTable(dtbFind);
			this.m_objViewer.dgrMedicine.Tag="dtbFind";
			if(dtbFind.Rows.Count==1)
			{
				m_lngSeleMed();
				return;
			}
			this.m_objViewer.dgrMedicine.Top=this.m_objViewer.panel3.Top-this.m_objViewer.dgrMedicine.Height-6;
			this.m_objViewer.dgrMedicine.Left=this.m_objViewer.panel4.Left;
			this.m_objViewer.dgrMedicine.Visible=true;
			this.m_objViewer.dgrMedicine.m_mthSelectARow(0);
		}
		#endregion

		#region  药品选择事件
		/// <summary>
		/// 药品选择事件
		/// </summary>
		public void m_lngSeleMed()
		{
			if((string)this.m_objViewer.dgrMedicine.Tag=="dtbMedicine")
			{
				DataRow seleRow=dtbMedicine.NewRow();
				seleRow=dtbMedicine.Rows[this.m_objViewer.dgrMedicine.CurrentCell.RowNumber];
				m_lngFillTxtBox(seleRow);
				this.m_objViewer.txttol.Focus();
			}
			else
			{
				DataRow seleRow=dtbFind.NewRow();
				seleRow=dtbFind.Rows[this.m_objViewer.dgrMedicine.CurrentCell.RowNumber];
				m_lngFillTxtBox(seleRow);
				this.m_objViewer.txttol.Focus();
			}
	}
		#endregion

		#region 把选择药品填充到Txtbox
		/// <summary>
		/// 把选择填充到Txtbox
		/// </summary>
		/// <param name="seleRow"></param>
		private  void m_lngFillTxtBox(DataRow seleRow)
		{
			this.m_objViewer.txtmedicine.Text=seleRow["MEDICINENAME_VCHR"].ToString().Trim();
			this.m_objViewer.txtmedicine.Tag=seleRow["MEDICINEID_CHR"].ToString().Trim();
			this.m_objViewer.txtSpace.Text=seleRow["MEDSPEC_VCHR"].ToString().Trim();
			this.m_objViewer.txtUnti.Text=seleRow["IPUNIT_CHR"].ToString().Trim();
			this.m_objViewer.txtStorage.Text=seleRow["AMOUNT_DEC"].ToString().Trim();
			if(seleRow["UNITPRICE_MNY"].ToString().Trim()=="")
				this.m_objViewer.txtbuyprice.Text="0.00";
			else
				this.m_objViewer.txtbuyprice.Text=seleRow["UNITPRICE_MNY"].ToString().Trim();
		}
		#endregion

		#region Combobox控件选择事件
		/// <summary>
		/// Combobox控件选择事件
		/// </summary>
		/// <param name="Command">1,选择入库类型。2，选择药房</param>
		public void m_lngSeleChangOut(int Command)
		{
			if(Command==2&&this.m_objViewer.comboStroage.Text!="")
				this.m_objViewer.comboStroage.Tag=dtbStorage.Rows[this.m_objViewer.comboStroage.SelectedIndex]["MEDSTOREID_CHR"].ToString();
		}
		#endregion

		#region 保存按钮事件
		/// <summary>
		/// 保存按钮事件
		/// </summary>
		public void m_lngSaveClickOut()
		{
			DataRow OrdDataRow=null;
			m_lngFillToDataRow(out OrdDataRow);
			long lngRes;
			if(isAddNew==0)
			{
				if(this.m_objViewer.LSVInOrdDe.Items.Count>0)
				{
					DataTable tableDe=new DataTable();
					m_lngFillToTable(out tableDe);
					string newID=null;
					lngRes=this.objSVC.m_lngSaveOut(OrdDataRow,tableDe,out newID);
					if(lngRes>0)
					{
						m_lngFillLsvAumNo(OrdDataRow);
						m_lngClearOut(2);
					}
				}
				else
					MessageBox.Show("明细列表中的数据不能为空！","系统提示");
			}
			else
			{
				if(isAddNew==1)
				{
					DataRow  upOrdDe=tableDeOut.NewRow();
					m_lngFillToDeDataRowOut(out upOrdDe);
					m_lngUpLSV(upOrdDe,null);
					double tolMoney;
					m_lngCountTolOut(out tolMoney);
					OrdDataRow["TOLMNY_MNY"]=tolMoney;
					lngRes=this.objSVC.m_lngModifiy(upOrdDe,OrdDataRow);
					if(lngRes>0)
						m_lngUpLSV(null,OrdDataRow);
					m_lngClearOut(1);
				}
				else
				{
					lngRes=this.objSVC.m_lngModifiy(null,OrdDataRow);
					if(lngRes>0)
						m_lngUpLSV(null,OrdDataRow);
					m_lngClearOut(2);
				}
			}
		}
		#endregion

		#region 修改LisView数据
		/// <summary>
		/// 修改LisView数据
		/// </summary>
		/// <param name="upOrdDe"></param>
		/// <param name="OrdDataRow"></param>
		private void m_lngUpLSV(DataRow upOrdDe,DataRow OrdDataRow)
		{
			if(upOrdDe==null&&OrdDataRow!=null)
			{
				if(this.m_objViewer.LSVInord.SelectedItems.Count>0)
				{
					this.m_objViewer.LSVInord.SelectedItems[0].SubItems[3].Text=OrdDataRow["TOLMNY_MNY"].ToString();
					this.m_objViewer.LSVInord.SelectedItems[0].Tag=OrdDataRow;
				}
			}
			if(upOrdDe!=null&&OrdDataRow==null)
			{
				if(this.m_objViewer.LSVInOrdDe.SelectedItems.Count>0)
				{
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[1].Text=upOrdDe["MEDICINEID_CHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[2].Text=upOrdDe["MEDICINENAME_VCHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[3].Text=upOrdDe["MEDSPEC_VCHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[4].Text=upOrdDe["UNITID_CHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[5].Text=upOrdDe["QTY_DEC"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[6].Text=upOrdDe["SALEUNITPRICE_DEC"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[7].Text=upOrdDe["SALETOLPRICE_DEC"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].Tag=upOrdDe;
				}
			}

		}
		#endregion

		#region  填充未审核列表
		/// <summary>
		/// 填充未审核列表
		/// </summary>
		/// <param name="tableRow"></param>
		private void m_lngFillLsvAumNo(DataRow tableRow)
		{
			ListViewItem LisTemp=null;
			LisTemp=new ListViewItem(tableRow["MEDSTOREORDID_CHR"].ToString());
			LisTemp.SubItems.Add(tableRow["CREATORNAME"].ToString());
			LisTemp.SubItems.Add(tableRow["CREATEDATE_DAT"].ToString());
			LisTemp.SubItems.Add(tableRow["TOLMNY_MNY"].ToString());
			LisTemp.Tag=tableRow;
			this.m_objViewer.LSVInord.Items.Add(LisTemp);
		}
		#endregion

		#region  填充己审核列表
		/// <summary>
		/// 填充己审核列表
		/// </summary>
		/// <param name="tableRow"></param>
		private void m_lngFillLsvAumOk(DataRow tableRow)
		{
			ListViewItem LisTemp=null;
			LisTemp=new ListViewItem(tableRow["MEDSTOREORDID_CHR"].ToString());
			LisTemp.SubItems.Add(tableRow["ADUITEMPNAME"].ToString());
			LisTemp.SubItems.Add(tableRow["CREATEDATE_DAT"].ToString());
			LisTemp.SubItems.Add(tableRow["TOLMNY_MNY"].ToString());
			LisTemp.Tag=tableRow;
			this.m_objViewer.LSVInOrdEmp.Items.Add(LisTemp);
		}
		#endregion

		#region 把所有的明细数据传到表
		/// <summary>
		/// 把所有的明细数据传到表
		/// </summary>
		/// <param name="tableDeAll"></param>
		private void m_lngFillToTable(out DataTable tableDeAll)
		{
			tableDeAll=new DataTable();
			try
			{
				tableDeAll.Columns.Add("MEDICINEID_CHR");
				tableDeAll.Columns.Add("MEDICINENAME_VCHR");
				tableDeAll.Columns.Add("SYSLOTNO_CHR");
				tableDeAll.Columns.Add("ROWNO_CHR");
				tableDeAll.Columns.Add("QTY_DEC");
				tableDeAll.Columns.Add("SALEUNITPRICE_DEC");
				tableDeAll.Columns.Add("SALETOLPRICE_DEC");
				tableDeAll.Columns.Add("MEDSPEC_VCHR");
				tableDeAll.Columns.Add("UNITID_CHR");
			}
			catch
			{
			}
			for(int i1=0;i1<this.m_objViewer.LSVInOrdDe.Items.Count;i1++)
			{
				DataRow AddRow=tableDeOut.NewRow();
				AddRow=(DataRow)this.m_objViewer.LSVInOrdDe.Items[i1].Tag;
				DataRow newRow=tableDeAll.NewRow();
				newRow["MEDICINEID_CHR"]=AddRow["MEDICINEID_CHR"];
				newRow["MEDICINENAME_VCHR"]=AddRow["MEDICINENAME_VCHR"];
				newRow["SYSLOTNO_CHR"]=AddRow["SYSLOTNO_CHR"];
				newRow["ROWNO_CHR"]=AddRow["ROWNO_CHR"];
				newRow["QTY_DEC"]=AddRow["QTY_DEC"];
				newRow["SALEUNITPRICE_DEC"]=AddRow["SALEUNITPRICE_DEC"];
				newRow["SALETOLPRICE_DEC"]=AddRow["SALETOLPRICE_DEC"];
				newRow["MEDSPEC_VCHR"]=AddRow["MEDSPEC_VCHR"];
				newRow["UNITID_CHR"]=AddRow["UNITID_CHR"];
				tableDeAll.Rows.Add(newRow);
			}
		}
		#endregion

		#region 把用户输入的入库单数据绑定到DataRow
		/// <summary>
		/// 把用户输入的入库单数据绑定到DataRow
		/// </summary>
		/// <param name="OrdDataRow"></param>
		private void m_lngFillToDataRow(out DataRow OrdDataRow)
		{
			OrdDataRow=dtbSaveOrdOut.NewRow();
			OrdDataRow["MEDSTOREORDID_CHR"]=this.m_objViewer.txtInOrdID.Text.Trim();
			OrdDataRow["MEDSTOREID_CHR"]=(string)this.m_objViewer.comboStroage.Tag;
			OrdDataRow["MEDSTORENAME_VCHR"]=this.m_objViewer.comboStroage.Text.Trim();
			OrdDataRow["ORDDATE_DAT"]=this.m_objViewer.dateTime.Value;
			double TolMoney=0;
			m_lngCountTolOut(out TolMoney);
			OrdDataRow["TOLMNY_MNY"]=TolMoney;
			OrdDataRow["MEMO_VCHR"]=this.m_objViewer.m_txtMemo.Text.Trim();
			OrdDataRow["MEDSTOREORDTYPEID_CHR"]=(string)this.m_objViewer.comboType.Tag;
			OrdDataRow["CREATOR_CHR"]=this.m_objViewer.LoginInfo.m_strEmpID;
			OrdDataRow["CREATORNAME"]=this.m_objViewer.LoginInfo.m_strEmpName;
			OrdDataRow["PERIODID_CHR"]=objPriodItems[intSelPeriod].m_strPeriodID;
			OrdDataRow["CREATEDATE_DAT"]=DateTime.Now;
		}
		#endregion

		#region 根据用户的选择显示入库明细
		/// <summary>
		/// 根据用户的选择显示入库明细
		/// </summary>
		public void m_lngShowDeBySelete()
		{
			DelCommand=2;
			isAddNew=2;
			this.m_objViewer.btnAdd.Enabled=true;
			this.m_objViewer.btnClear.Enabled=true;
			this.m_objViewer.btnSave.Text="修改F2";
			this.m_objViewer.LSVInOrdDe.Items.Clear();
			DataRow seleRow=dtbSaveOrdOut.NewRow();
			DataTable p_dtbResultArr=new DataTable();
			if(this.m_objViewer.tabInOrd.SelectedIndex==0&&this.m_objViewer.LSVInord.SelectedItems.Count>0)
				seleRow=(DataRow)this.m_objViewer.LSVInord.SelectedItems[0].Tag;
			if(this.m_objViewer.tabInOrd.SelectedIndex==1&&this.m_objViewer.LSVInOrdEmp.SelectedItems.Count>0)
				seleRow=(DataRow)this.m_objViewer.LSVInOrdEmp.SelectedItems[0].Tag;
			m_lngFillTxtboxOrd(seleRow);
			long lngRes=this.objSVC.m_lngGetStoreOrdDeByOrdID(seleRow["MEDSTOREORDID_CHR"].ToString(),out p_dtbResultArr,true,"");
			if(lngRes>0&&p_dtbResultArr.Rows.Count>0)
			{
				for(int i1=0;i1<p_dtbResultArr.Rows.Count;i1++)
				{
					m_lngFillLSVInOrdDeOut(p_dtbResultArr.Rows[i1]);
				}
			}

		}
		#endregion

		#region 把选择的入库单数据填充到Txtbox
		/// <summary>
		/// 把选择的入库单数据填充到Txtbox
		/// </summary>
		/// <param name="SelectRow"></param>
		private void m_lngFillTxtboxOrd(DataRow SelectRow)
		{
			this.m_objViewer.txtInOrdID.Text=SelectRow["MEDSTOREORDID_CHR"].ToString().Trim();
			this.m_objViewer.comboStroage.Tag=SelectRow["MEDSTOREID_CHR"].ToString().Trim();
			this.m_objViewer.comboStroage.Text=SelectRow["MEDSTORENAME_VCHR"].ToString().Trim();
			if(SelectRow["ORDDATE_DAT"].ToString()!="")
				this.m_objViewer.dateTime.Value=Convert.ToDateTime(SelectRow["ORDDATE_DAT"].ToString().Trim());
			this.m_objViewer.txtTolmoney.Text=SelectRow["TOLMNY_MNY"].ToString().Trim();
			this.m_objViewer.m_txtMemo.Text=SelectRow["MEMO_VCHR"].ToString().Trim();
			this.m_objViewer.txtGrearMan.Tag=SelectRow["CREATOR_CHR"].ToString().Trim();
			this.m_objViewer.txtGrearMan.Text=SelectRow["CREATORNAME"].ToString().Trim();
		}
		#endregion

		#region 把选择的入库单明细数据填充到Txtbox
		/// <summary>
		/// 把选择的入库单明细数据填充到Txtbox
		/// </summary>
		public  void m_lngFillTxtboxOrdDe()
		{
			DelCommand=1;
			if(isAddNew==2)
				isAddNew=1;
			this.m_objViewer.btnAdd.Enabled=false;
			this.m_objViewer.btnClear.Enabled=false;
			DataRow SelectRow=tableDeOut.NewRow();
			SelectRow=(DataRow)this.m_objViewer.LSVInOrdDe.SelectedItems[0].Tag;
			this.m_objViewer.txtfind.Tag=SelectRow["MEDSTOREORDDEID_CHR"].ToString();
			this.m_objViewer.txtmedicine.Tag=SelectRow["MEDICINEID_CHR"].ToString().Trim();
			this.m_objViewer.txtmedicine.Text=SelectRow["MEDICINENAME_VCHR"].ToString().Trim();
			this.m_objViewer.txttol.Text=SelectRow["QTY_DEC"].ToString().Trim();
			this.m_objViewer.txtbuyprice.Text=SelectRow["SALEUNITPRICE_DEC"].ToString().Trim();
			this.m_objViewer.txtTolPrice.Text=SelectRow["SALETOLPRICE_DEC"].ToString().Trim();
			this.m_objViewer.txtSpace.Text=SelectRow["MEDSPEC_VCHR"].ToString().Trim();
			this.m_objViewer.txtUnti.Text=SelectRow["UNITID_CHR"].ToString().Trim();
		}
		#endregion

		#region 删除事件
		/// <summary>
		/// 删除事件
		/// </summary>
		public void m_lngDeleClick()
		{
			if(DelCommand==1)
			{
				if(isAddNew==0)
				{
					this.m_objViewer.LSVInOrdDe.Items.RemoveAt(this.m_objViewer.LSVInOrdDe.SelectedItems[0].Index);
					return;
				}
				else
				{
					if(this.m_objViewer.LSVInOrdDe.SelectedItems.Count>0)
					{
						DataRow SeleRow=tableDeOut.NewRow();
						SeleRow=(DataRow)this.m_objViewer.LSVInOrdDe.SelectedItems[0].Tag;
						double TolMoney=Convert.ToDouble(this.m_objViewer.txtTolmoney.Text);
						double DelDeMoney=Convert.ToDouble(SeleRow["SALETOLPRICE_DEC"]);
						long lngRes=this.objSVC.m_lngDelete(null,SeleRow["MEDSTOREORDDEID_CHR"].ToString(),TolMoney,DelDeMoney);
						TolMoney=TolMoney-DelDeMoney;
						this.m_objViewer.txtTolmoney.Text=TolMoney.ToString();
						this.m_objViewer.LSVInord.SelectedItems[0].SubItems[3].Text=TolMoney.ToString();
						if(lngRes>0)
							this.m_objViewer.LSVInOrdDe.Items.RemoveAt(this.m_objViewer.LSVInOrdDe.SelectedItems[0].Index);
						m_lngClearOut(1);
					}
					else
					{
						MessageBox.Show("请选择你要删除的数据","删除提示");
						return;
					}
				}
			}
			if(DelCommand==2)
			{
				if(this.m_objViewer.LSVInord.SelectedItems.Count>0)
				{
					DataRow SeleRow=dtbSaveOrdOut.NewRow();
					SeleRow=(DataRow)this.m_objViewer.LSVInord.SelectedItems[0].Tag;
					long lngRes=this.objSVC.m_lngDelete(SeleRow["MEDSTOREORDID_CHR"].ToString(),null,1,1);
					if(lngRes>0)
					{
						this.m_objViewer.LSVInord.Items.RemoveAt(this.m_objViewer.LSVInord.SelectedItems[0].Index);
						m_lngClearOut(2);
					}
				}
				else
				{
					MessageBox.Show("请选择你要删除的数据","删除提示");
					return;
				}
			}
		}
		#endregion

		#region 审核功能按钮
		/// <summary>
		/// 审核功能按钮
		/// </summary>
		public void m_lngAduiClickOut()
		{
			if(this.m_objViewer.LSVInord.SelectedItems.Count>0)
			{
				DataTable OrdDeTable=new DataTable();
				m_lngFillToTable(out OrdDeTable);
				DataRow SeleRow=dtbSaveOrdOut.NewRow();
				SeleRow=(DataRow)this.m_objViewer.LSVInord.SelectedItems[0].Tag;
				long lngRes=this.objSVC.m_lngAduiTempOut(SeleRow["MEDSTOREORDID_CHR"].ToString(),SeleRow["MEDSTOREID_CHR"].ToString(),this.m_objViewer.LoginInfo.m_strEmpID,OrdDeTable);
				if(lngRes>0)
				{
					SeleRow["ADUITEMP_CHR"]=this.m_objViewer.LoginInfo.m_strEmpID;
					SeleRow["ADUITDATE_DAT"]=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					this.m_objViewer.LSVInord.Items.RemoveAt(this.m_objViewer.LSVInord.SelectedItems[0].Index);
					m_lngClearOut(2);
					m_lngFillLsvAumOk(SeleRow);
				}
				else
				{
					if(lngRes==-2)
						MessageBox.Show("库存不足，审核失败","系统提示");
				}
			}
		}
		#endregion

		#region 查找事件
		/// <summary>
		/// 查找事件
		/// </summary>
		public void m_lngFindClick()
		{
			this.m_objViewer.LSVInord.Items.Clear();
			this.m_objViewer.LSVInOrdEmp.Items.Clear();
			if(dtbSaveOrdOut.Rows.Count>0)
			{
				string findID=this.m_objViewer.TextID.Text.Trim();
				string findNAME=this.m_objViewer.GrearNAME.Text.Trim();
				string findDATE=this.m_objViewer.APPLDATE.Text.Trim();
				string findstroage=this.m_objViewer.txtfindstroage.Text.Trim();
				string findType=this.m_objViewer.txtType.Text.Trim();
				objFindTable.Rows.Clear();
				if(findID!=""||findNAME!=""||findDATE!=""||findstroage!=""||findType!="")
				{
					try
					{
						objFindTable.Columns.Add("MEDSTOREORDID_CHR");
						objFindTable.Columns.Add("MEDSTOREID_CHR");
						objFindTable.Columns.Add("ORDDATE_DAT");
						objFindTable.Columns.Add("TOLMNY_MNY");
						objFindTable.Columns.Add("MEMO_VCHR");
						objFindTable.Columns.Add("CREATOR_CHR");
						objFindTable.Columns.Add("CREATEDATE_DAT");
						objFindTable.Columns.Add("ADUITEMP_CHR");
						objFindTable.Columns.Add("ADUITDATE_DAT");
						objFindTable.Columns.Add("MEDSTOREORDTYPEID_CHR");
						objFindTable.Columns.Add("PSTATUS_INT");
						objFindTable.Columns.Add("MEDSTORENAME_VCHR");
						objFindTable.Columns.Add("CREATORNAME");
						objFindTable.Columns.Add("ADUITEMPNAME");
						objFindTable.Columns.Add("MEDSTOREORDTYPE_VCHR");
					}
					catch
					{
					}
					if(findID!="")
					{
						for(int i1=0;i1<dtbSaveOrdOut.Rows.Count;i1++)
						{
							if(dtbSaveOrdOut.Rows[i1]["MEDSTOREORDID_CHR"].ToString().IndexOf(findID,0)==0)
							{
								DataRow newRow=objFindTable.NewRow();
								newRow["MEDSTOREORDID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDID_CHR"];
								newRow["MEDSTOREID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREID_CHR"];
								newRow["ORDDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ORDDATE_DAT"];
								newRow["TOLMNY_MNY"]=dtbSaveOrdOut.Rows[i1]["TOLMNY_MNY"];
								newRow["MEMO_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEMO_VCHR"];
								newRow["CREATOR_CHR"]=dtbSaveOrdOut.Rows[i1]["CREATOR_CHR"];
								newRow["CREATEDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["CREATEDATE_DAT"];
								newRow["ADUITEMP_CHR"]=dtbSaveOrdOut.Rows[i1]["ADUITEMP_CHR"];
								newRow["ADUITDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ADUITDATE_DAT"];
								newRow["MEDSTOREORDTYPEID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPEID_CHR"];
								newRow["PSTATUS_INT"]=dtbSaveOrdOut.Rows[i1]["PSTATUS_INT"];
								newRow["MEDSTORENAME_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTORENAME_VCHR"];
								newRow["CREATORNAME"]=dtbSaveOrdOut.Rows[i1]["CREATORNAME"];
								newRow["ADUITEMPNAME"]=dtbSaveOrdOut.Rows[i1]["ADUITEMPNAME"];
								newRow["MEDSTOREORDTYPE_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPE_VCHR"];
								objFindTable.Rows.Add(newRow);
							}
						}
					}
					if(findNAME!="")
					{
						for(int i1=0;i1<dtbSaveOrdOut.Rows.Count;i1++)
						{
							if(dtbSaveOrdOut.Rows[i1]["CREATORNAME"].ToString().IndexOf(findNAME,0)==0)
							{
								DataRow newRow=objFindTable.NewRow();
								newRow["MEDSTOREORDID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDID_CHR"];
								newRow["MEDSTOREID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREID_CHR"];
								newRow["ORDDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ORDDATE_DAT"];
								newRow["TOLMNY_MNY"]=dtbSaveOrdOut.Rows[i1]["TOLMNY_MNY"];
								newRow["MEMO_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEMO_VCHR"];
								newRow["CREATOR_CHR"]=dtbSaveOrdOut.Rows[i1]["CREATOR_CHR"];
								newRow["CREATEDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["CREATEDATE_DAT"];
								newRow["ADUITEMP_CHR"]=dtbSaveOrdOut.Rows[i1]["ADUITEMP_CHR"];
								newRow["ADUITDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ADUITDATE_DAT"];
								newRow["MEDSTOREORDTYPEID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPEID_CHR"];
								newRow["PSTATUS_INT"]=dtbSaveOrdOut.Rows[i1]["PSTATUS_INT"];
								newRow["MEDSTORENAME_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTORENAME_VCHR"];
								newRow["CREATORNAME"]=dtbSaveOrdOut.Rows[i1]["CREATORNAME"];
								newRow["ADUITEMPNAME"]=dtbSaveOrdOut.Rows[i1]["ADUITEMPNAME"];
								newRow["MEDSTOREORDTYPE_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPE_VCHR"];
								objFindTable.Rows.Add(newRow);
							}
						}
					}
					if(findDATE!="")
					{
						for(int i1=0;i1<dtbSaveOrdOut.Rows.Count;i1++)
						{
							if(dtbSaveOrdOut.Rows[i1]["ORDDATE_DAT"].ToString().IndexOf(findDATE,0)==0)
							{
								DataRow newRow=objFindTable.NewRow();
								newRow["MEDSTOREORDID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDID_CHR"];
								newRow["MEDSTOREID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREID_CHR"];
								newRow["ORDDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ORDDATE_DAT"];
								newRow["TOLMNY_MNY"]=dtbSaveOrdOut.Rows[i1]["TOLMNY_MNY"];
								newRow["MEMO_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEMO_VCHR"];
								newRow["CREATOR_CHR"]=dtbSaveOrdOut.Rows[i1]["CREATOR_CHR"];
								newRow["CREATEDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["CREATEDATE_DAT"];
								newRow["ADUITEMP_CHR"]=dtbSaveOrdOut.Rows[i1]["ADUITEMP_CHR"];
								newRow["ADUITDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ADUITDATE_DAT"];
								newRow["MEDSTOREORDTYPEID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPEID_CHR"];
								newRow["PSTATUS_INT"]=dtbSaveOrdOut.Rows[i1]["PSTATUS_INT"];
								newRow["MEDSTORENAME_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTORENAME_VCHR"];
								newRow["CREATORNAME"]=dtbSaveOrdOut.Rows[i1]["CREATORNAME"];
								newRow["ADUITEMPNAME"]=dtbSaveOrdOut.Rows[i1]["ADUITEMPNAME"];
								newRow["MEDSTOREORDTYPE_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPE_VCHR"];
								objFindTable.Rows.Add(newRow);
							}
						}
					}
					if(findstroage!="")
					{
						for(int i1=0;i1<dtbSaveOrdOut.Rows.Count;i1++)
						{
							if(dtbSaveOrdOut.Rows[i1]["MEDSTORENAME_VCHR"].ToString().IndexOf(findstroage,0)==0)
							{
								DataRow newRow=objFindTable.NewRow();
								newRow["MEDSTOREORDID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDID_CHR"];
								newRow["MEDSTOREID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREID_CHR"];
								newRow["ORDDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ORDDATE_DAT"];
								newRow["TOLMNY_MNY"]=dtbSaveOrdOut.Rows[i1]["TOLMNY_MNY"];
								newRow["MEMO_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEMO_VCHR"];
								newRow["CREATOR_CHR"]=dtbSaveOrdOut.Rows[i1]["CREATOR_CHR"];
								newRow["CREATEDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["CREATEDATE_DAT"];
								newRow["ADUITEMP_CHR"]=dtbSaveOrdOut.Rows[i1]["ADUITEMP_CHR"];
								newRow["ADUITDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ADUITDATE_DAT"];
								newRow["MEDSTOREORDTYPEID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPEID_CHR"];
								newRow["PSTATUS_INT"]=dtbSaveOrdOut.Rows[i1]["PSTATUS_INT"];
								newRow["MEDSTORENAME_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTORENAME_VCHR"];
								newRow["CREATORNAME"]=dtbSaveOrdOut.Rows[i1]["CREATORNAME"];
								newRow["ADUITEMPNAME"]=dtbSaveOrdOut.Rows[i1]["ADUITEMPNAME"];
								newRow["MEDSTOREORDTYPE_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPE_VCHR"];
								objFindTable.Rows.Add(newRow);
							}
						}
					}
					if(findType!="")
					{
						for(int i1=0;i1<dtbSaveOrdOut.Rows.Count;i1++)
						{
							if(dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPE_VCHR"].ToString().IndexOf(findType,0)==0)
							{
								DataRow newRow=objFindTable.NewRow();
								newRow["MEDSTOREORDID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDID_CHR"];
								newRow["MEDSTOREID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREID_CHR"];
								newRow["ORDDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ORDDATE_DAT"];
								newRow["TOLMNY_MNY"]=dtbSaveOrdOut.Rows[i1]["TOLMNY_MNY"];
								newRow["MEMO_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEMO_VCHR"];
								newRow["CREATOR_CHR"]=dtbSaveOrdOut.Rows[i1]["CREATOR_CHR"];
								newRow["CREATEDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["CREATEDATE_DAT"];
								newRow["ADUITEMP_CHR"]=dtbSaveOrdOut.Rows[i1]["ADUITEMP_CHR"];
								newRow["ADUITDATE_DAT"]=dtbSaveOrdOut.Rows[i1]["ADUITDATE_DAT"];
								newRow["MEDSTOREORDTYPEID_CHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPEID_CHR"];
								newRow["PSTATUS_INT"]=dtbSaveOrdOut.Rows[i1]["PSTATUS_INT"];
								newRow["MEDSTORENAME_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTORENAME_VCHR"];
								newRow["CREATORNAME"]=dtbSaveOrdOut.Rows[i1]["CREATORNAME"];
								newRow["ADUITEMPNAME"]=dtbSaveOrdOut.Rows[i1]["ADUITEMPNAME"];
								newRow["MEDSTOREORDTYPE_VCHR"]=dtbSaveOrdOut.Rows[i1]["MEDSTOREORDTYPE_VCHR"];
								objFindTable.Rows.Add(newRow);
							}
						}
					}
					m_lngClearFind();
					if(objFindTable.Rows.Count>0)
					{
						for(int i1=0;i1<objFindTable.Rows.Count;i1++)
						{
							if(objFindTable.Rows[i1]["PSTATUS_INT"].ToString()=="1")
								m_lngFillLsvAumNo(objFindTable.Rows[i1]);
							else
								m_lngFillLsvAumOk(objFindTable.Rows[i1]);
						}
					}
					else
						MessageBox.Show("找不到你所需的数据","系统提示");
				}
				else
					MessageBox.Show("请输入查找条件","查找提示");
			}
		}
		#endregion

		#region 清空查找数据输入框
		/// <summary>
		///  清空查找数据输入框
		/// </summary>
		private void m_lngClearFind()
		{
			this.m_objViewer.TextID.Clear();
			this.m_objViewer.GrearNAME.Clear();
			this.m_objViewer.APPLDATE.Clear();
			this.m_objViewer.txtfindstroage.Clear();
			this.m_objViewer.txtType.Clear();
		}
		#endregion

		#region 返回按钮事件
		/// <summary>
		/// 返回按钮事件
		/// </summary>
		public void m_lngReturnClick()
		{
			this.m_objViewer.LSVInord.Items.Clear();
			this.m_objViewer.LSVInOrdEmp.Items.Clear();
			if(dtbSaveOrdOut.Rows.Count>0)
			{
				for(int i1=0;i1<dtbSaveOrdOut.Rows.Count;i1++)
				{
					if(dtbSaveOrdOut.Rows[i1]["PSTATUS_INT"].ToString()=="1")
						m_lngFillLsvAumNo(dtbSaveOrdOut.Rows[i1]);
					else
						m_lngFillLsvAumOk(dtbSaveOrdOut.Rows[i1]);
				}
			}
			this.m_objViewer.panel6.Visible=false;
		}
		#endregion
	}
}
