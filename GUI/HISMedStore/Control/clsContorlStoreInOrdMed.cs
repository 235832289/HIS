using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsContorlStoreInOrdMed 的摘要说明。
	/// </summary>
	public class clsContorlStoreInOrdMed : com.digitalwave.GUI_Base.clsController_Base
	{
		/// <summary>
		/// 构造函数逻辑
		/// </summary>
		public clsContorlStoreInOrdMed()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		frmStoreInOrdMed m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmStoreInOrdMed)frmMDI_Child_Base_in;
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
		/// 保存入库数据
		/// </summary>
		DataTable dtbSaveOrd=new DataTable();
		/// <summary>
		/// 保存明细表
		/// </summary>
		DataTable tableDe=new DataTable();
		/// <summary>
		/// 保存查找数据
		/// </summary>
		DataTable dtbFind=new DataTable();
		/// <summary>
		/// 删除标志，1删除明细数据，2删除入库单数据，0没有要删除的数据
		/// </summary>
		int DelCommand=0;
		/// <summary>
		/// 新增或修改标志.0新增，1修改整个入库单及明细，2只修改入单不修改明细。
		/// </summary>
		int isAddNew=0;
		/// <summary>
		/// 保存所有符合查找条件的入库单数据
		/// </summary>
		DataTable objFindTable=null;
		/// <summary>
		/// 保存财务期数据
		/// </summary>
		clsPeriod_VO[] objPriodItems = new clsPeriod_VO[0];
		/// <summary>
		/// 保存当前财务期的索引
		/// </summary>
		int intSelPeriod=-1;
		//com.digitalwave.iCare.middletier.HIS.clsHisBase  HisBase=new clsHisBase();	
        com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));
		#endregion

		#region 初始化窗体
		/// <summary>
		/// 初始化窗体
		/// </summary>
		public void m_lngFrmLoad()
		{
		     this.m_objViewer.dateTime.Text=HisBase.s_GetServerDate().ToString("yyyy年MM月dd日");;
			this.m_objViewer.m_lblCreage.Text=this.m_objViewer.LoginInfo.m_strEmpName;
			this.m_objViewer.m_lblCreage.Tag=this.m_objViewer.LoginInfo.m_strEmpID;
			m_lngSetupDeTable();
			m_mthGetPeriodList();
		}
		#endregion

		#region 初始化明细表
		/// <summary>
		/// 初始化明细表
		/// </summary>
		private void m_lngSetupDeTable()
		{
			tableDe.Columns.Add("MEDICINEID_CHR");
		    tableDe.Columns.Add("MEDSTOREORDDEID_CHR");
			tableDe.Columns.Add("MEDICINENAME_VCHR");
			tableDe.Columns.Add("MEDNO_CHR");
			tableDe.Columns.Add("ROWNO_CHR");
			tableDe.Columns.Add("QTY_DEC");
			tableDe.Columns.Add("SALEUNITPRICE_DEC");
			tableDe.Columns.Add("SALETOLPRICE_DEC");
			tableDe.Columns.Add("MEDSPEC_VCHR");
			tableDe.Columns.Add("UNITID_CHR");
			tableDe.Columns.Add("PRODUCTORID_CHR");
			tableDe.Columns.Add("ASSISTCODE_CHR");
			tableDe.Columns.Add("USEFULLIFE_DAT");
			tableDe.Columns.Add("SYSLOTNO_CHR");
			tableDe.Columns.Add("AMOUNT_DEC");
			
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
				m_lngGetAndFill(objPriodItems[this.m_objViewer.m_cboSelPeriod.SelectedIndex].m_strPeriodID);
				this.m_objViewer.m_cboSelPeriod.Tag=objPriodItems[this.m_objViewer.m_cboSelPeriod.SelectedIndex].m_strPeriodID;
			}
			else
			{
				m_lngGetAndFill("");
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

		#region 把选择药品填充到Txtbox
		/// <summary>
		/// 把选择填充到Txtbox
		/// </summary>
		/// <param name="seleRow"></param>
		private  void m_lngFillTxtBox(DataRow seleRow)
		{
			this.m_objViewer.txtmedicine.Text=seleRow["MEDICINENAME_VCHR"].ToString().Trim();
			this.m_objViewer.txtmedicine.Tag=seleRow["MEDICINEID_CHR"].ToString().Trim();
			this.m_objViewer.m_lblSpace.Text=seleRow["MEDSPEC_VCHR"].ToString().Trim();
			this.m_objViewer.lblUnit.Text=seleRow["IPUNIT_CHR"].ToString().Trim();
			if(seleRow["UNITPRICE_MNY"].ToString().Trim()=="")
				this.m_objViewer.txtbuyprice.Text="0.00";
			else
				this.m_objViewer.txtbuyprice.Text=seleRow["UNITPRICE_MNY"].ToString().Trim();
		}
		#endregion

		#region 把选择的入库单数据填充到Txtbox
		/// <summary>
		/// 把选择的入库单数据填充到Txtbox
		/// </summary>
		/// <param name="SelectRow"></param>
		private void m_lngFillTxtboxOrd(DataRow SelectRow)
		{
			if(SelectRow["ORDDATE_DAT"].ToString()!="")
			    this.m_objViewer.dateTime.Text=DateTime.Parse(SelectRow["ORDDATE_DAT"].ToString().Trim()).ToString("yyyy年MM月dd日");;
			this.m_objViewer.txtTolmoney.Text=SelectRow["TOLMNY_MNY"].ToString().Trim();
			this.m_objViewer.m_txtMemo.Text=SelectRow["MEMO_VCHR"].ToString().Trim();
			this.m_objViewer.m_lblCreage.Tag=SelectRow["CREATOR_CHR"].ToString().Trim();
			this.m_objViewer.m_lblCreage.Text=SelectRow["CREATORNAME"].ToString().Trim();
			this.m_objViewer.m_txtSrcNO.Text=SelectRow["STORERDOCNO_CHR"].ToString().Trim();
			this.m_objViewer.m_cboIPCal.Text=SelectRow["STORAGENAME_VCHR"].ToString().Trim();
			this.m_objViewer.panel4.Tag =SelectRow["MEDSTOREORDID_CHR"].ToString().Trim();

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
			if(isAddNew==0)
			{
				this.m_objViewer.btnSave.Text="修改(&S)";
			}
			this.m_objViewer.btnAdd.Enabled=false;
			this.m_objViewer.btnClear.Enabled=false;
			DataRow SelectRow=tableDe.NewRow();
			SelectRow=(DataRow)this.m_objViewer.LSVInOrdDe.SelectedItems[0].Tag;
			this.m_objViewer.panel3.Tag=SelectRow["MEDSTOREORDDEID_CHR"].ToString();
			this.m_objViewer.txtmedicine.Tag=SelectRow["MEDICINEID_CHR"].ToString().Trim();
			this.m_objViewer.txtmedicine.Text=SelectRow["MEDICINENAME_VCHR"].ToString().Trim();
			this.m_objViewer.m_txtMedNo.Text=SelectRow["MEDNO_CHR"].ToString().Trim();
			this.m_objViewer.txttol.Text=SelectRow["QTY_DEC"].ToString().Trim();
			this.m_objViewer.txtbuyprice.Text=SelectRow["SALEUNITPRICE_DEC"].ToString().Trim();
			this.m_objViewer.DetotalMoney.Text=SelectRow["SALETOLPRICE_DEC"].ToString().Trim();
			this.m_objViewer.m_lblSpace.Text=SelectRow["MEDSPEC_VCHR"].ToString().Trim();

			this.m_objViewer.label38.Text=SelectRow["SYSLOTNO_CHR"].ToString().Trim();
			this.m_objViewer.totailCoun.Text=SelectRow["AMOUNT_DEC"].ToString().Trim();
			this.m_objViewer.m_lblSpace.Tag =SelectRow["ASSISTCODE_CHR"].ToString().Trim();
			this.m_objViewer.label23.Text=this.m_objViewer.lblUnit.Text=SelectRow["UNITID_CHR"].ToString().Trim();
			this.m_objViewer.lblWorkShop.Text=SelectRow["PRODUCTORID_CHR"].ToString().Trim();
			if(SelectRow["USEFULLIFE_DAT"]!=null&&SelectRow["USEFULLIFE_DAT"].ToString().Trim()!="")
			     this.m_objViewer.ctlValidityDate.Text=DateTime.Parse(SelectRow["USEFULLIFE_DAT"].ToString()).ToString("yyyy年MM月dd日");
			else
				this.m_objViewer.ctlValidityDate.Text="";
		}
		#endregion

		#region 获得所有的入库单并填充到“未审核”和“己审核”列表中
		/// <summary>
		/// 获得所有的入库单并填充到“未审核”和“己审核”列表中
		/// </summary>
		/// <param name="nowPriod">财务期</param>
		private void m_lngGetAndFill(string nowPriod)
		{
			long lngRes;

			if(this.m_objViewer.intSIGN_INT==1||this.m_objViewer.intSIGN_INT==3)
				lngRes=this.objSVC.m_lngGetMedStoreOrd((string)this.m_objViewer.comboType.Tag,out dtbSaveOrd,nowPriod,(string)this.m_objViewer.m_lbStroage.Tag,"1");
			else
				lngRes=this.objSVC.m_lngGetMedStoreOrd((string)this.m_objViewer.comboType.Tag,out dtbSaveOrd,nowPriod,(string)this.m_objViewer.m_lbStroage.Tag,"2");
			if(lngRes>0&&dtbSaveOrd.Rows.Count>0)
			{
				for(int i1=0;i1<dtbSaveOrd.Rows.Count;i1++)
				{
					if(dtbSaveOrd.Rows[i1]["PSTATUS_INT"].ToString()=="1")
					    m_lngFillLsvAumNo(dtbSaveOrd.Rows[i1]);
					else
						m_lngFillLsvAumOk(dtbSaveOrd.Rows[i1]);
				}
			}
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
			this.m_objViewer.btnSave.Text="修改(&S)";
			this.m_objViewer.LSVInOrdDe.Items.Clear();
			DataRow seleRow=dtbSaveOrd.NewRow();
			DataTable p_dtbResultArr=new DataTable();
			if(this.m_objViewer.tabInOrd.SelectedIndex==0&&this.m_objViewer.LSVInord.SelectedItems.Count>0)
			   seleRow=(DataRow)this.m_objViewer.LSVInord.SelectedItems[0].Tag;
			if(this.m_objViewer.tabInOrd.SelectedIndex==1&&this.m_objViewer.LSVInOrdEmp.SelectedItems.Count>0)
				seleRow=(DataRow)this.m_objViewer.LSVInOrdEmp.SelectedItems[0].Tag;
			m_lngFillTxtboxOrd(seleRow);
			long lngRes;
			if(this.m_objViewer.intSIGN_INT==1||this.m_objViewer.intSIGN_INT==4)
				lngRes=this.objSVC.m_lngGetStoreOrdDeByOrdID(seleRow["MEDSTOREORDID_CHR"].ToString(),out p_dtbResultArr,true,(string)this.m_objViewer.m_lbStroage.Tag);
			else
				lngRes=this.objSVC.m_lngGetStoreOrdDeByOrdID(seleRow["MEDSTOREORDID_CHR"].ToString(),out p_dtbResultArr,false,(string)this.m_objViewer.m_lbStroage.Tag);
			if(lngRes>0&&p_dtbResultArr.Rows.Count>0)
			{
				for(int i1=0;i1<p_dtbResultArr.Rows.Count;i1++)
				{
					m_lngFillLSVInOrdDe(p_dtbResultArr.Rows[i1]);
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
			LisTemp=new ListViewItem(tableRow["STORERDOCNO_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["STORAGENAME_VCHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["CREATORNAME"].ToString().Trim());
			if(tableRow["ORDDATE_DAT"].ToString()!="")
			    LisTemp.SubItems.Add(DateTime.Parse(tableRow["ORDDATE_DAT"].ToString()).ToString("yyyy-MM-dd"));
			else
				 LisTemp.SubItems.Add("");
			LisTemp.SubItems.Add(tableRow["TOLMNY_MNY"].ToString().Trim());
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
			LisTemp=new ListViewItem(tableRow["STORERDOCNO_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["STORAGENAME_VCHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["ADUITEMPNAME"].ToString().Trim());
			LisTemp.SubItems.Add(DateTime.Parse(tableRow["ADUITDATE_DAT"].ToString()).ToString("yyyy-MM-dd"));
			LisTemp.SubItems.Add(tableRow["TOLMNY_MNY"].ToString().Trim());
			LisTemp.Tag=tableRow;
			this.m_objViewer.LSVInOrdEmp.Items.Add(LisTemp);
		}
		#endregion

		#region  填充入库明细列表
		/// <summary>
		/// 填充入库明细列表
		/// </summary>
		/// <param name="tableRow"></param>
		private void m_lngFillLSVInOrdDe(DataRow tableRow)
		{
			ListViewItem LisTemp=null;
			LisTemp=new ListViewItem(tableRow["ROWNO_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["ASSISTCODE_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["MEDICINENAME_VCHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["MEDSPEC_VCHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["PRODUCTORID_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["UNITID_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["QTY_DEC"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["SALEUNITPRICE_DEC"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["SALETOLPRICE_DEC"].ToString().Trim());
			if(tableRow["USEFULLIFE_DAT"]!=null&&tableRow["USEFULLIFE_DAT"].ToString().Trim()!="")
			   LisTemp.SubItems.Add(DateTime .Parse(tableRow["USEFULLIFE_DAT"].ToString().Trim()).ToString("yyyy-MM-dd"));
			else
			   LisTemp.SubItems.Add("");
			LisTemp.SubItems.Add(tableRow["MEDNO_CHR"].ToString().Trim());
			LisTemp.Tag=tableRow;
			this.m_objViewer.LSVInOrdDe.Items.Add(LisTemp);
		}
		#endregion

		#region 保存按钮事件
		/// <summary>
		/// 保存按钮事件
		/// </summary>
		clsMedStorePublic publiClass=new clsMedStorePublic();
		public void m_lngSaveClick()
		{
			DataRow OrdDataRow=null;
			m_lngFillToDataRow(out OrdDataRow);
			long lngRes;
			if(isAddNew==0)
			{
				if(this.m_objViewer.LSVInOrdDe.Items.Count>0)
				{
					if(this.m_objViewer.btnSave.Text=="修改(&S)")
					{
//						DataRow  upOrdDe=tableDe.NewRow();
//						m_lngFillToDeDataRow(out upOrdDe);
//						m_lngUpLSV(upOrdDe,null);
						this.m_objViewer.btnSave.Text="保存(&S)";
						this.m_objViewer.btnAdd.Enabled=true;
						this.m_objViewer.btnClear.Enabled=true;
						m_lngClear(1);
						return;
					}

					DataTable tableDe1=new DataTable();
					m_lngFillToTable(out tableDe1);
					string newID=null;
					lngRes=this.objSVC.m_lngSave(OrdDataRow,tableDe1,out newID,this.m_objViewer.intSIGN_INT);
		
					if(lngRes>0)
					{
						OrdDataRow["MEDSTOREORDID_CHR"]=newID;
						m_lngFillLsvAumNo(OrdDataRow);
						m_lngClear(2);
					}
				}
				else
				{
					publiClass.m_mthShowWarning(this.m_objViewer.LSVInOrdDe,"明细列表中的数据不能为空!");
					this.m_objViewer.txtmedicine.Focus();
					return;
				}
			}
			else
			{
				if(isAddNew==1)
				{
					DataRow  upOrdDe=tableDe.NewRow();
					m_lngFillToDeDataRow(out upOrdDe);
					m_lngUpLSV(upOrdDe,null);
					double tolMoney;
					m_lngCountTol(out tolMoney);
					OrdDataRow["TOLMNY_MNY"]=tolMoney;
					lngRes=this.objSVC.m_lngModifiy(upOrdDe,OrdDataRow);
					if(lngRes>0)
						m_lngUpLSV(null,OrdDataRow);
					m_lngClear(1);
				}
				else
				{
					lngRes=this.objSVC.m_lngModifiy(null,OrdDataRow);
					if(lngRes>0)
						m_lngUpLSV(null,OrdDataRow);
					m_lngClear(2);
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
					this.m_objViewer.LSVInord.SelectedItems[0].SubItems[0].Text=OrdDataRow["STORERDOCNO_CHR"].ToString();
					this.m_objViewer.LSVInord.SelectedItems[0].SubItems[1].Text=OrdDataRow["STORAGENAME_VCHR"].ToString();
					this.m_objViewer.LSVInord.SelectedItems[0].SubItems[2].Text=OrdDataRow["CREATORNAME"].ToString();
					if(OrdDataRow["ORDDATE_DAT"].ToString()!="")
						this.m_objViewer.LSVInord.SelectedItems[0].SubItems[3].Text=DateTime.Parse(OrdDataRow["ORDDATE_DAT"].ToString()).ToString("yyyy-MM-dd");
					else
						this.m_objViewer.LSVInord.SelectedItems[0].SubItems[3].Text="";
					this.m_objViewer.LSVInord.SelectedItems[0].SubItems[4].Text=OrdDataRow["TOLMNY_MNY"].ToString();
					this.m_objViewer.LSVInord.SelectedItems[0].Tag=OrdDataRow;
				}
			}
			if(upOrdDe!=null&&OrdDataRow==null)
			{
				if(this.m_objViewer.LSVInOrdDe.SelectedItems.Count>0)
				{
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[1].Text=upOrdDe["ASSISTCODE_CHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[2].Text=upOrdDe["MEDICINENAME_VCHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[3].Text=upOrdDe["MEDSPEC_VCHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[4].Text=upOrdDe["PRODUCTORID_CHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[5].Text=upOrdDe["UNITID_CHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[6].Text=upOrdDe["QTY_DEC"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[7].Text=upOrdDe["SALEUNITPRICE_DEC"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[8].Text=upOrdDe["SALETOLPRICE_DEC"].ToString();

					if(upOrdDe["USEFULLIFE_DAT"]!=null&&upOrdDe["USEFULLIFE_DAT"].ToString().Trim()!="")
						this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[9].Text=DateTime .Parse(upOrdDe["USEFULLIFE_DAT"].ToString().Trim()).ToString("yyyy-MM-dd");
					else
						this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[9].Text="";
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].SubItems[10].Text=upOrdDe["MEDNO_CHR"].ToString();
					this.m_objViewer.LSVInOrdDe.SelectedItems[0].Tag=upOrdDe;
				}
			}

		}
		#endregion

		#region 计算入库单的总金额
		/// <summary>
		/// 计算入库单的总金额
		/// </summary>
		/// <param name="Tolmoney"></param>
		private void m_lngCountTol(out double Tolmoney)
		{
			Tolmoney=0;
			if(this.m_objViewer.LSVInOrdDe.Items.Count>0)
			{
				for(int i1=0;i1<this.m_objViewer.LSVInOrdDe.Items.Count;i1++)
				{
					DataRow Row=tableDe.NewRow();
					Row=(DataRow)this.m_objViewer.LSVInOrdDe.Items[i1].Tag;
					if(Row["SALETOLPRICE_DEC"].ToString()!="")
						Tolmoney+=Convert.ToDouble(Row["SALETOLPRICE_DEC"]);
				}
			}
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
				tableDeAll.Columns.Add("MEDSTOREORDDEID_CHR");
				tableDeAll.Columns.Add("MEDICINENAME_VCHR");
				tableDeAll.Columns.Add("MEDNO_CHR");
				tableDeAll.Columns.Add("ROWNO_CHR");
				tableDeAll.Columns.Add("QTY_DEC");
				tableDeAll.Columns.Add("SALEUNITPRICE_DEC");
				tableDeAll.Columns.Add("SALETOLPRICE_DEC");
				tableDeAll.Columns.Add("MEDSPEC_VCHR");
				tableDeAll.Columns.Add("UNITID_CHR");
				tableDeAll.Columns.Add("PRODUCTORID_CHR");
				tableDeAll.Columns.Add("ASSISTCODE_CHR");
				tableDeAll.Columns.Add("USEFULLIFE_DAT");
				tableDeAll.Columns.Add("SYSLOTNO_CHR");
			}
			catch
			{
			}
				for(int i1=0;i1<this.m_objViewer.LSVInOrdDe.Items.Count;i1++)
				{
					DataRow AddRow=tableDe.NewRow();
					AddRow=(DataRow)this.m_objViewer.LSVInOrdDe.Items[i1].Tag;
					DataRow newRow=tableDeAll.NewRow();
					newRow["MEDICINEID_CHR"]=AddRow["MEDICINEID_CHR"];
					newRow["MEDICINENAME_VCHR"]=AddRow["MEDICINENAME_VCHR"];
					newRow["MEDNO_CHR"]=AddRow["MEDNO_CHR"];
					newRow["ROWNO_CHR"]=AddRow["ROWNO_CHR"];
					newRow["QTY_DEC"]=AddRow["QTY_DEC"];
					newRow["SALEUNITPRICE_DEC"]=AddRow["SALEUNITPRICE_DEC"];
					newRow["SALETOLPRICE_DEC"]=AddRow["SALETOLPRICE_DEC"];
					newRow["MEDSPEC_VCHR"]=AddRow["MEDSPEC_VCHR"];
					newRow["UNITID_CHR"]=AddRow["UNITID_CHR"];
					newRow["USEFULLIFE_DAT"]=AddRow["USEFULLIFE_DAT"];
					newRow["PRODUCTORID_CHR"]=AddRow["PRODUCTORID_CHR"];
					newRow["SYSLOTNO_CHR"]=AddRow["SYSLOTNO_CHR"];
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
			
			OrdDataRow=dtbSaveOrd.NewRow();
			OrdDataRow["MEDSTOREORDID_CHR"]=(string)this.m_objViewer.panel4.Tag;
			OrdDataRow["MEDSTOREID_CHR"]=(string)this.m_objViewer.m_lbStroage.Tag;
			OrdDataRow["MEDSTORENAME_VCHR"]=this.m_objViewer.m_lbStroage.Text.Trim();
			OrdDataRow["ORDDATE_DAT"]=DateTime.Parse(this.m_objViewer.dateTime.Text).ToString("yyyy-MM-dd");
			double TolMoney=0;
			m_lngCountTol(out TolMoney);
			OrdDataRow["TOLMNY_MNY"]=TolMoney;
			OrdDataRow["MEMO_VCHR"]=this.m_objViewer.m_txtMemo.Text.Trim();
			OrdDataRow["MEDSTOREORDTYPEID_CHR"]=(string)this.m_objViewer.comboType.Tag;
			OrdDataRow["CREATOR_CHR"]=this.m_objViewer.LoginInfo.m_strEmpID;
			OrdDataRow["CREATORNAME"]=this.m_objViewer.LoginInfo.m_strEmpName;
			OrdDataRow["PERIODID_CHR"]=objPriodItems[intSelPeriod].m_strPeriodID;
			OrdDataRow["SRCID_CHR"]=this.m_objViewer.m_cboIPCal.SelectItemValue.ToString();
			OrdDataRow["STORAGENAME_VCHR"]=this.m_objViewer.m_cboIPCal.SelectItemText;
			OrdDataRow["STORERDOCNO_CHR"]=this.m_objViewer.m_txtSrcNO.Text.Trim();
		}
		#endregion

		#region 增加按钮事件
		/// <summary>
		/// 增加按钮事件
		/// </summary>
		public void m_lngAddClick()
		{
			if(isAddNew!=2)
			{
				DataRow DeDataRow=tableDe.NewRow();
				m_lngFillToDeDataRow(out DeDataRow);
				m_lngFillLSVInOrdDe(DeDataRow);
				double TolMoney=0;
				m_lngCountTol(out TolMoney);
				this.m_objViewer.txtTolmoney.Text=TolMoney.ToString();
				m_lngClear(1);
			}
			else
			{
				if(MessageBox.Show("是否确定向药房入库单添加明细数据？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
				{
					return;
				}
				DataRow DeDataRow=tableDe.NewRow();
				m_lngFillToDeDataRow(out DeDataRow);
				string newDeid;
				double tolMoney;
				long lngRes=this.objSVC.m_lngAddNewDe((string)this.m_objViewer.panel4.Tag,Convert.ToDouble(this.m_objViewer.txtTolmoney.Text),DeDataRow,out newDeid,out tolMoney);
				if(lngRes>0)
				{
					DeDataRow["MEDSTOREORDDEID_CHR"]=newDeid;
					m_lngFillLSVInOrdDe(DeDataRow);
					Double TolMoney=0;
					m_lngCountTol(out TolMoney);
					this.m_objViewer.txtTolmoney.Text=TolMoney.ToString();
					for(int i1=0;i1<dtbSaveOrd.Rows.Count;i1++)
					{
						if(dtbSaveOrd.Rows[i1]["MEDSTOREORDID_CHR"].ToString()==(string)this.m_objViewer.panel4.Tag)
						{
							dtbSaveOrd.Rows[i1]["TOLMNY_MNY"]=TolMoney;
							this.m_objViewer.LSVInord.SelectedItems[0].SubItems[4].Text=TolMoney.ToString();
							break;
						}
					}
					m_lngClear(1);
				}
			}
		}
		#endregion

		#region 把用户输入的明细数据绑定到DataRow
		/// <summary>
		/// 把用户输入的明细数据绑定到DataRow
		/// </summary>
		/// <param name="DeDataRow"></param>
		private void m_lngFillToDeDataRow(out DataRow DeDataRow)
		{
			DeDataRow=tableDe.NewRow();
			DeDataRow["MEDSTOREORDDEID_CHR"]=(string)this.m_objViewer.panel3.Tag;
			DeDataRow["MEDICINEID_CHR"]=(string)this.m_objViewer.txtmedicine.Tag;
			DeDataRow["MEDICINENAME_VCHR"]=this.m_objViewer.txtmedicine.Text.Trim();
			DeDataRow["MEDNO_CHR"]=this.m_objViewer.m_txtMedNo.Text.Trim();
			DeDataRow["PRODUCTORID_CHR"]=this.m_objViewer.lblWorkShop.Text.Trim();
			int Row;
			if(this.m_objViewer.LSVInOrdDe.Items.Count>0)
				Row=Convert.ToInt16(this.m_objViewer.LSVInOrdDe.Items[this.m_objViewer.LSVInOrdDe.Items.Count-1].SubItems[0].Text)+1;
			else
				Row=1;
			DeDataRow["ROWNO_CHR"]=Row.ToString("000");
			DeDataRow["QTY_DEC"]=Convert.ToDouble(this.m_objViewer.txttol.Text.Trim());
			DeDataRow["SALEUNITPRICE_DEC"]=Convert.ToDouble(this.m_objViewer.txtbuyprice.Text.Trim());
			DeDataRow["SALETOLPRICE_DEC"]=Convert.ToDouble(this.m_objViewer.txtbuyprice.Text.Trim())*Convert.ToDouble(this.m_objViewer.txttol.Text.Trim());
			DeDataRow["MEDSPEC_VCHR"]=this.m_objViewer.m_lblSpace.Text.Trim();
			DeDataRow["UNITID_CHR"]=this.m_objViewer.lblUnit.Text.Trim();
			if(this.m_objViewer.ctlValidityDate.Text!=null&&this.m_objViewer.ctlValidityDate.Text!="")
			     DeDataRow["USEFULLIFE_DAT"]=DateTime.Parse(m_objViewer.ctlValidityDate.Text.Trim()).ToString("yyyy-MM-dd");
			else
				 DeDataRow["USEFULLIFE_DAT"]="";
			DeDataRow["ASSISTCODE_CHR"]=(string)this.m_objViewer.m_lblSpace.Tag;
			DeDataRow["SYSLOTNO_CHR"]=this.m_objViewer.label38.Text;
		}
		#endregion

		#region 清空用户输入
		/// <summary>
		/// 清空用户输入
		/// </summary>
		/// <param name="Command">1,清空输入明细。2，清空全部</param>
		public void m_lngClear(int Command)
		{
			this.m_objViewer.txtmedicine.Text="";
			this.m_objViewer.m_lblSpace.Text="";
			this.m_objViewer.txttol.Text="0";
			this.m_objViewer.txtbuyprice.Text="0.00";
			this.m_objViewer.txtbuyprice.Text="0.00";
			this.m_objViewer.m_lblSpace.Text="";
			this.m_objViewer.lblUnit.Text="";
			this.m_objViewer.ctlValidityDate.Text="";
			this.m_objViewer.DetotalMoney.Text="0.00";
			this.m_objViewer.txttol.Text="";
			this.m_objViewer.lblWorkShop.Text="";
			this.m_objViewer.m_txtMedNo.Text="";
			this.m_objViewer.errorProvider1.SetError(this.m_objViewer.txtmedicine,"");
			this.m_objViewer.errorProvider1.SetError(this.m_objViewer.txttol,"");
			this.m_objViewer.errorProvider1.SetError(this.m_objViewer.txtbuyprice,"");
			this.m_objViewer.panel3.Tag=null;
			this.m_objViewer.txtmedicine.Focus();
			this.m_objViewer.label38.Text="";
			this.m_objViewer.totailCoun.Text="0";
			this.m_objViewer.label23.Text="";
			this.m_objViewer.btnAdd.Enabled=true;
			this.m_objViewer.btnClear.Enabled=true;
			if(Command==1)
			{
				this.m_objViewer.txtmedicine.Focus();
				return;
			}
			if(Command==2)
			{
				isAddNew=0;
				this.m_objViewer.btnSave.Text="保存(&S)";
				this.m_objViewer.dateTime.Text=HisBase.s_GetServerDate().ToString("yyyy年MM月dd日");
				this.m_objViewer.btnAdd.Enabled=true;
				this.m_objViewer.btnClear.Enabled=true;
				this.m_objViewer.txtTolmoney.Text="0.00";
				this.m_objViewer.m_txtMemo.Text="";
				string ScrNO="";
				this.objSVC.m_lngGetScrNO(out ScrNO);
				this.m_objViewer.m_txtSrcNO.Text=clsMedStorePublic.m_mthGetNewDocument(ScrNO);
				this.m_objViewer.LSVInOrdDe.Items.Clear();
				this.m_objViewer.m_cboIPCal.Text="";
				this.m_objViewer.comboType.Focus();
				this.m_objViewer.panel4.Tag=null;
				this.m_objViewer.m_lblCreage.Tag =this.m_objViewer.LoginInfo.m_strEmpID;
				this.m_objViewer.m_lblCreage.Text =this.m_objViewer.LoginInfo.m_strEmpName;
				this.m_objViewer.m_txtSrcNO.Focus();
			}
		}

		#endregion

		#region Combobox控件选择事件
		/// <summary>
		/// Combobox控件选择事件
		/// </summary>
		/// <param name="Command">1,选择入库类型。2，选择药房</param>
		public void m_lngSeleChang(int Command)
		{
//			if(Command==2&&this.m_objViewer.comboStroage.Text!="")
//				this.m_objViewer.comboStroage.Tag=dtbStorage.Rows[this.m_objViewer.comboStroage.SelectedIndex]["MEDSTOREID_CHR"].ToString();
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
						m_lngClear(1);
						return;
					}
					else
					{
						if(this.m_objViewer.LSVInOrdDe.SelectedItems.Count>0&&this.m_objViewer.LSVInord.SelectedItems.Count>0)
						{
							DataRow SeleRow=tableDe.NewRow();
							SeleRow=(DataRow)this.m_objViewer.LSVInOrdDe.SelectedItems[0].Tag;
							double TolMoney=Convert.ToDouble(this.m_objViewer.txtTolmoney.Text);
							double DelDeMoney=Convert.ToDouble(SeleRow["SALETOLPRICE_DEC"]);
							long lngRes=this.objSVC.m_lngDelete(null,SeleRow["MEDSTOREORDDEID_CHR"].ToString(),TolMoney,DelDeMoney);	
							if(lngRes>0)
							{
								this.m_objViewer.LSVInOrdDe.Items.RemoveAt(this.m_objViewer.LSVInOrdDe.SelectedItems[0].Index);
								m_lngCountTol(out TolMoney);
								this.m_objViewer.txtTolmoney.Text=TolMoney.ToString();
								for(int i1=0;i1<dtbSaveOrd.Rows.Count;i1++)
								{
									if(dtbSaveOrd.Rows[i1]["MEDSTOREORDID_CHR"].ToString()==(string)this.m_objViewer.panel4.Tag)
									{
										dtbSaveOrd.Rows[i1]["TOLMNY_MNY"]=TolMoney;
										this.m_objViewer.LSVInord.SelectedItems[0].SubItems[4].Text=TolMoney.ToString();
										break;
									}
								}
								m_lngClear(1);
							}
						}
						else
						{
							publiClass.m_mthShowWarning(this.m_objViewer.panel4,"请选择你要删除的数据!");
							return;
						}
					}
				}
				if(DelCommand==2)
				{
					if(this.m_objViewer.LSVInord.SelectedItems.Count>0)
					{
						DataRow SeleRow=dtbSaveOrd.NewRow();
						SeleRow=(DataRow)this.m_objViewer.LSVInord.SelectedItems[0].Tag;
						long lngRes=this.objSVC.m_lngDelete(SeleRow["MEDSTOREORDID_CHR"].ToString(),null,1,1);
						if(lngRes>0)
						{
							this.m_objViewer.LSVInord.Items.RemoveAt(this.m_objViewer.LSVInord.SelectedItems[0].Index);
							for(int i1=0;i1<dtbSaveOrd.Rows.Count;i1++)
							{
								if(dtbSaveOrd.Rows[i1]["MEDSTOREORDID_CHR"]==SeleRow["MEDSTOREORDID_CHR"])
								{
									dtbSaveOrd.Rows[i1].Delete();
									dtbSaveOrd.AcceptChanges();
									break;
								}
							}
							m_lngClear(2);
						}
					}
					else
					{
						publiClass.m_mthShowWarning(this.m_objViewer.panel4,"请选择你要删除的数据!");
						return;
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
			if(dtbSaveOrd.Rows.Count>0&&this.m_objViewer.m_cboFind.Text!=""&&this.m_objViewer.textBoxTyped1.Text!="")
			{
				string findtext=this.m_objViewer.textBoxTyped1.Text;
				if(objFindTable==null)
					objFindTable=dtbSaveOrd.Clone();
				objFindTable.Clear();
				switch(this.m_objViewer.m_cboFind.Text)
				{
					case "源单据号":
						for(int i1=0;i1<dtbSaveOrd.Rows.Count;i1++)
						{
							if(dtbSaveOrd.Rows[i1]["STORERDOCNO_CHR"].ToString().IndexOf(findtext,0)==0)
							{
								m_mthAddNewRow(dtbSaveOrd.Rows[i1],ref objFindTable);
							}
						}

						break;
					case "源药库":
						for(int i1=0;i1<dtbSaveOrd.Rows.Count;i1++)
						{
							if(dtbSaveOrd.Rows[i1]["STORAGENAME_VCHR"].ToString().IndexOf(findtext,0)==0)
							{
								m_mthAddNewRow(dtbSaveOrd.Rows[i1],ref objFindTable);
							}
						}

						break;
					case "创建人":
						for(int i1=0;i1<dtbSaveOrd.Rows.Count;i1++)
						{
							if(dtbSaveOrd.Rows[i1]["CREATORNAME"].ToString().IndexOf(findtext,0)==0)
							{
								m_mthAddNewRow(dtbSaveOrd.Rows[i1],ref objFindTable);
							}
						}

						break;
					case "单据日期":
						for(int i1=0;i1<dtbSaveOrd.Rows.Count;i1++)
						{
							if(dtbSaveOrd.Rows[i1]["ORDDATE_DAT"].ToString().IndexOf(findtext,0)==0)
							{
								m_mthAddNewRow(dtbSaveOrd.Rows[i1],ref objFindTable);
							}
						}

						break;

				}
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
				{
					MessageBox.Show("找不到你所需的数据!","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);
				}
			}
			else
			{
				MessageBox.Show("请输入查找条件!","Icare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
			}
		#endregion

		#region 向表添加一行
		private void m_mthAddNewRow(DataRow Row1,ref DataTable objFindTable)
		{
			DataRow newRow=objFindTable.NewRow();
			newRow["MEDSTOREORDID_CHR"]=Row1["MEDSTOREORDID_CHR"];
			newRow["STORAGENAME_VCHR"]=Row1["STORAGENAME_VCHR"];
			newRow["MEDSTOREID_CHR"]=Row1["MEDSTOREID_CHR"];
			newRow["ORDDATE_DAT"]=Row1["ORDDATE_DAT"];
			newRow["TOLMNY_MNY"]=Row1["TOLMNY_MNY"];
			newRow["MEMO_VCHR"]=Row1["MEMO_VCHR"];
			newRow["CREATOR_CHR"]=Row1["CREATOR_CHR"];
			newRow["CREATEDATE_DAT"]=Row1["CREATEDATE_DAT"];
			newRow["ADUITEMP_CHR"]=Row1["ADUITEMP_CHR"];
			newRow["ADUITDATE_DAT"]=Row1["ADUITDATE_DAT"];
			newRow["MEDSTOREORDTYPEID_CHR"]=Row1["MEDSTOREORDTYPEID_CHR"];
			newRow["PSTATUS_INT"]=Row1["PSTATUS_INT"];
			newRow["MEDSTORENAME_VCHR"]=Row1["MEDSTORENAME_VCHR"];
			newRow["CREATORNAME"]=Row1["CREATORNAME"];
			newRow["ADUITEMPNAME"]=Row1["ADUITEMPNAME"];
			newRow["SRCID_CHR"]=Row1["SRCID_CHR"];
			newRow["STORERDOCNO_CHR"]=Row1["STORERDOCNO_CHR"];
			objFindTable.Rows.Add(newRow);
		}


		#endregion

		#region 清空查找数据输入框
		/// <summary>
		///  清空查找数据输入框
		/// </summary>
		private void m_lngClearFind()
		{
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
			if(dtbSaveOrd.Rows.Count>0)
			{
				for(int i1=0;i1<dtbSaveOrd.Rows.Count;i1++)
				{
					if(dtbSaveOrd.Rows[i1]["PSTATUS_INT"].ToString()=="1")
						m_lngFillLsvAumNo(dtbSaveOrd.Rows[i1]);
					else
						m_lngFillLsvAumOk(dtbSaveOrd.Rows[i1]);
				}
			}
			this.m_objViewer.panel6.Visible=false;
		}
		#endregion

		#region 审核功能按钮
		/// <summary>
		/// 审核功能按钮
		/// </summary>
		public void m_lngAduiClick()
		{
			if(this.m_objViewer.LSVInord.SelectedItems.Count>0)
			{
				DataTable OrdDeTable=new DataTable();
				m_lngFillToTable(out OrdDeTable);
				DataRow SeleRow=dtbSaveOrd.NewRow();
				SeleRow=(DataRow)this.m_objViewer.LSVInord.SelectedItems[0].Tag;
				long lngRes=0;
					switch(this.m_objViewer.intSIGN_INT)
					{
						case 1:
							 lngRes=this.objSVC.m_lngAduiTemp(SeleRow["MEDSTOREORDID_CHR"].ToString(),SeleRow["MEDSTOREID_CHR"].ToString(),this.m_objViewer.LoginInfo.m_strEmpID,OrdDeTable,1,false,SeleRow);
							break;
						case 2:
							if(MessageBox.Show("是否要生成相应药库的入库单？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
							{
								string ordTypeID;
								this.objSVC.m_lngGetOrdTypeID(out ordTypeID,1);
								if(ordTypeID!=null)
								{
									SeleRow["MEDSTOREORDTYPEID_CHR"]=ordTypeID;
									ordTypeID=SeleRow["SRCID_CHR"].ToString();
									SeleRow["SRCID_CHR"]=SeleRow["MEDSTOREID_CHR"];
									SeleRow["MEDSTOREID_CHR"]=ordTypeID;
									lngRes=this.objSVC.m_lngAduiTemp(SeleRow["MEDSTOREORDID_CHR"].ToString(),SeleRow["MEDSTOREID_CHR"].ToString(),this.m_objViewer.LoginInfo.m_strEmpID,OrdDeTable,2,true,SeleRow);
								}
								else
								{
									if(MessageBox.Show("找不到“药房退药入库”的药库入库单据类型，是否要断续并放弃数据同步到药库？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
									{
										lngRes=this.objSVC.m_lngAduiTemp(SeleRow["MEDSTOREORDID_CHR"].ToString(),SeleRow["MEDSTOREID_CHR"].ToString(),this.m_objViewer.LoginInfo.m_strEmpID,OrdDeTable,2,true,SeleRow);
										
									}
									else
									{
										return;
									}
								}

							}
							else
							{
								lngRes=this.objSVC.m_lngAduiTemp(SeleRow["MEDSTOREORDID_CHR"].ToString(),SeleRow["MEDSTOREID_CHR"].ToString(),this.m_objViewer.LoginInfo.m_strEmpID,OrdDeTable,2,true,SeleRow);
							}
							break;
						case 3:
							lngRes=this.objSVC.m_lngAduiTemp(SeleRow["MEDSTOREORDID_CHR"].ToString(),SeleRow["MEDSTOREID_CHR"].ToString(),this.m_objViewer.LoginInfo.m_strEmpID,OrdDeTable,3,false,SeleRow);

							break;
						case 4:
							if(MessageBox.Show("是否要生成相应药房的入库单？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
							{
								string ordTypeID;
								this.objSVC.m_lngGetOrdTypeID(out ordTypeID,0);
								if(ordTypeID!=null)
								{
									SeleRow["MEDSTOREORDTYPEID_CHR"]=ordTypeID;
									ordTypeID=SeleRow["SRCID_CHR"].ToString();
									SeleRow["SRCID_CHR"]=SeleRow["MEDSTOREID_CHR"];
									SeleRow["MEDSTOREID_CHR"]=ordTypeID;
									lngRes=this.objSVC.m_lngAduiTemp(SeleRow["MEDSTOREORDID_CHR"].ToString(),SeleRow["SRCID_CHR"].ToString(),this.m_objViewer.LoginInfo.m_strEmpID,OrdDeTable,4,true,SeleRow);
								}
								else
								{
									if(MessageBox.Show("找不到“调拔入库”的药房入库单据类型，是否要断续并放弃数据同步到目标药房？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
									{
										SeleRow["MEDSTOREORDTYPEID_CHR"]=ordTypeID;
										ordTypeID=SeleRow["SRCID_CHR"].ToString();
										SeleRow["SRCID_CHR"]=SeleRow["MEDSTOREID_CHR"];
										SeleRow["MEDSTOREID_CHR"]=ordTypeID;
										lngRes=this.objSVC.m_lngAduiTemp(SeleRow["MEDSTOREORDID_CHR"].ToString(),SeleRow["MEDSTOREID_CHR"].ToString(),this.m_objViewer.LoginInfo.m_strEmpID,OrdDeTable,4,false,SeleRow);
									}
								}

							}
							break;
					}
				if(lngRes>0)
				{
					SeleRow["ADUITEMP_CHR"]=this.m_objViewer.LoginInfo.m_strEmpID;
					SeleRow["ADUITEMPNAME"]=this.m_objViewer.LoginInfo.m_strEmpName;
					SeleRow["ADUITDATE_DAT"]=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
					this.m_objViewer.LSVInord.Items.RemoveAt(this.m_objViewer.LSVInord.SelectedItems[0].Index);
					m_lngClear(2);
					m_lngFillLsvAumOk(SeleRow);
				}
			}
		}
		#endregion
	}
}
