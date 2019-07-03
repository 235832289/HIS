using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsControlMedStoreAppl 的摘要说明。
	/// </summary>
	public class clsControlMedStoreAppl: com.digitalwave.GUI_Base.clsController_Base
	{
		/// <summary>
		/// 构造函数逻辑
		/// </summary>
		public clsControlMedStoreAppl()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region 设置窗体对象

		frmMedStoreAppl m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance (frmMDI_Child_Base_in);
			this.m_objViewer = (frmMedStoreAppl)frmMDI_Child_Base_in;
		}
		#endregion

		#region 变量
		clsDomainControlMedStore objSVC=new clsDomainControlMedStore();
		/// <summary>
		/// 保存药品信息
		/// </summary>
		DataTable dtbMedicine=null;
		/// <summary>
		/// 保存药品查找数据
		/// </summary>
		DataTable dtbFindMed=new DataTable();
		/// <summary>
		/// 保存药库信息
		/// </summary>
		DataTable dtbStorage=new DataTable();
		/// <summary>
		/// 保存药房信息
		/// </summary>
		DataTable dtbStore=new DataTable();
		/// <summary>
		/// 保存明细数据表
		/// </summary>
		DataTable dtbApplDe=new DataTable();
		/// <summary>
		/// 新增或修改标志.0新增，1修改
		/// </summary>
		int isAddNew=0;
		/// <summary>
		/// 保存申请单数据
		/// </summary>
		DataTable dtbApplArr=new DataTable();
		/// <summary>
		/// 保存符合条件申请单数据
		/// </summary>
		DataTable dtbFindApplArr=new DataTable();
		/// <summary>
		/// 删除标志，1删除明细数据，2删除入库单数据，0没有要删除的数据
		/// </summary>
		int DelCommand=0;
		/// <summary>
		/// 保存自动生成数据
		/// </summary>
		DataTable dtbAutoTable=null;
		/// <summary>
		/// 保存自动生成数据(查找)
		/// </summary>
		DataTable dtbAutoFind=null;
		/// <summary>
		/// 0-修改申请单，1-修改申请单同明细数据
		/// </summary>
		int ModifyDe=1;

		//com.digitalwave.iCare.middletier.HIS.clsHisBase  HisBase=new clsHisBase();	
        com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = (com.digitalwave.iCare.middletier.HIS.clsHisBase)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));

		#endregion

		#region 初始化窗体
		/// <summary>
		/// 初始化窗体
		/// </summary>
		public void m_lngSetupFrm()
		{
            m_lngSetupTable();
			m_lngFillComboBox();
			this.m_objViewer.ctlShowMed.intIsReData=0;
			this.m_objViewer.ctlShowMed.strSTORAGEID=(string)this.m_objViewer.blebostore.Tag;
			this.m_objViewer.dateTime.Text=HisBase.s_GetServerDate().ToString("yyyy年MM月dd日");
			this.m_objViewer.txtGrearMan.Text=this.m_objViewer.LoginInfo.m_strEmpName;
			m_lngSetupDeTable();
			m_lngGetAndFill();
		}
		#endregion

		#region 初始化查找数据表
		/// <summary>
		/// 初始化查找数据表
		/// </summary>
		private void m_lngSetupTable()
		{
			dtbFindMed.Columns.Add("MEDICINEID_CHR");
			dtbFindMed.Columns.Add("ASSISTCODE_CHR");
			dtbFindMed.Columns.Add("MEDICINENAME_VCHR");
			dtbFindMed.Columns.Add("PACKQTY_DEC");
			dtbFindMed.Columns.Add("MEDSPEC_VCHR");
			dtbFindMed.Columns.Add("IPUNIT_CHR");
			dtbFindMed.Columns.Add("UNITPRICE_MNY");
			dtbFindMed.Columns.Add("PYCODE_CHR");
			dtbFindMed.Columns.Add("WBCODE_CHR");
		}
		#endregion

		#region 初始化明细表
		/// <summary>
		/// 初始化明细表
		/// </summary>
		private void m_lngSetupDeTable()
		{
			dtbApplDe.Columns.Add("MEDAPPLID_CHR");
			dtbApplDe.Columns.Add("MEDAPPLDEID_CHR");
			dtbApplDe.Columns.Add("MEDICINENAME_VCHR");
			dtbApplDe.Columns.Add("MEDICINEID_CHR");
			dtbApplDe.Columns.Add("ROWNO_CHR");
			dtbApplDe.Columns.Add("QTY_DEC");
			dtbApplDe.Columns.Add("APPLDATE_DAT");
			dtbApplDe.Columns.Add("MEDSPEC_VCHR");
			dtbApplDe.Columns.Add("UNITID_CHR");
			dtbApplDe.Columns.Add("ASSISTCODE_CHR");
			dtbApplDe.Columns.Add("TOLFINANCE_DEC");
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
//			this.m_objViewer.txtUnti.Text=seleRow["IPUNIT_CHR"].ToString().Trim();
			this.m_objViewer.txttQyt.Tag=seleRow["PACKQTY_DEC"].ToString().Trim();
//			this.m_objViewer.txtfind.Clear();
		}
		#endregion

		#region 填充药库、药房信息
		/// <summary>
		/// 填充药库、药房信息
		/// </summary>
		private void m_lngFillComboBox()
		{
			long lngRes=this.objSVC.m_lngGetStoreAndStorage(out dtbStorage,out dtbStore);
			if(dtbStorage.Rows.Count>0)
			{
				for(int i1=0;i1<dtbStorage.Rows.Count;i1++)
				{
					this.m_objViewer.comboStroage.Item.Add(dtbStorage.Rows[i1]["STORAGENAME_VCHR"].ToString(),dtbStorage.Rows[i1]["STORAGEID_CHR"].ToString());
				}
//				this.m_objViewer.comboStroage.Items.Add("");
			}
		}
		#endregion

		#region 获得所有的申请单并填充到申请列表
		/// <summary>
		/// 获得所有的申请单并填充到申请列表
		/// </summary>
		public void m_lngGetAndFill()
		{
			long lngRes=this.objSVC.m_lngGetMedApplAll(out dtbApplArr,(string)this.m_objViewer.blebostore.Tag);
			this.m_objViewer.LSVAppl.Items.Clear();
			if(lngRes>0&&dtbApplArr.Rows.Count>0)
			{
				for(int i1=0;i1<dtbApplArr.Rows.Count;i1++)
				{
					m_lngFillLsv(dtbApplArr.Rows[i1]);
				}
			}
			this.m_objViewer.panel6.Visible=false;

		}
		#endregion

		#region  把申请单填充到列表
		/// <summary>
		/// 把申请单填充到列表
		/// </summary>
		/// <param name="tableRow"></param>
		private void m_lngFillLsv(DataRow tableRow)
		{
			ListViewItem LisTemp=null;
			LisTemp=new ListViewItem(tableRow["MEDAPPLID_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["medstorename_vchr"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["lastname_vchr"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["APPLDATE_DAT"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["storagename_vchr"].ToString().Trim());
			LisTemp.Tag=tableRow;
			this.m_objViewer.LSVAppl.Items.Add(LisTemp);
            if (tableRow["PSTATUS_INT"].ToString() == "3")
            {
                this.m_objViewer.LSVAppl.Items[this.m_objViewer.LSVAppl.Items.Count - 1].BackColor = System.Drawing.Color.Honeydew;
            }
		}
		#endregion

		#region 增加按钮事件
		/// <summary>
		/// 增加按钮事件
		/// </summary>
		public void m_lngAddClick()
		{
			if(isAddNew!=1)
			{
				DataRow DeDataRow=dtbApplDe.NewRow();
				m_lngFillToDeDataRow(out DeDataRow);
				m_lngFillLSVApplDe(DeDataRow);
				m_lngClear(1);
			}
			else
			{
				if(MessageBox.Show("是否确定向申请单添加申请明细？","Icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
				{
					DataRow DeDataRow=dtbApplDe.NewRow();
					m_lngFillToDeDataRow(out DeDataRow);
					string newDeid;
					long lngRes=this.objSVC.m_lngAddApplDe((string)this.m_objViewer.panel4.Tag,DeDataRow,out newDeid);
					if(lngRes>0)
					{
						DeDataRow["MEDAPPLDEID_CHR"]=newDeid;
						m_lngFillLSVApplDe(DeDataRow);
						m_lngClear(1);
					}
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
			DeDataRow=dtbApplDe.NewRow();
			DeDataRow["MEDAPPLDEID_CHR"]=(string)this.m_objViewer.panel3.Tag;
			DeDataRow["MEDICINEID_CHR"]=(string)this.m_objViewer.txtmedicine.Tag;
			DeDataRow["MEDICINENAME_VCHR"]=this.m_objViewer.txtmedicine.Text.Trim();
			int Row;
			if(this.m_objViewer.LSVApplDe.Items.Count>0)
				Row=Convert.ToInt16(this.m_objViewer.LSVApplDe.Items[this.m_objViewer.LSVApplDe.Items.Count-1].SubItems[0].Text)+1;
			else
				Row=1;
			DeDataRow["ROWNO_CHR"]=Row.ToString("000");
			DeDataRow["QTY_DEC"]=Convert.ToDouble(this.m_objViewer.txttQyt.Text.Trim());
			DeDataRow["MEDSPEC_VCHR"]=this.m_objViewer.txtSpace.Text.Trim();
			DeDataRow["assistcode_chr"]=(string)this.m_objViewer.txtSpace.Tag;
			DeDataRow["UNITID_CHR"]=this.m_objViewer.lableUnit.Text.Trim();
			DeDataRow["TOLFINANCE_DEC"]=this.m_objViewer.lableNowStorage.Text.Trim();
		}
		#endregion

		#region 根据用户的选择显示申请明细
		/// <summary>
		/// 根据用户的选择显示申请明细
		/// </summary>
		public void m_lngShowDeBySelete()
		{
			ModifyDe=0;
			isAddNew=1;
			DelCommand=2;
			this.m_objViewer.btnAdd.Enabled=true;
			this.m_objViewer.btnClear.Enabled=true;
			this.m_objViewer.btnSave.Text="修改F2";
			this.m_objViewer.LSVApplDe.Items.Clear();
			DataRow seleRow=dtbApplArr.NewRow();
			DataTable p_dtbResultArr=new DataTable();
			if(this.m_objViewer.LSVAppl.SelectedItems.Count>0)
				seleRow=(DataRow)this.m_objViewer.LSVAppl.SelectedItems[0].Tag;
			m_lngFillTxtboxOrd(seleRow);
			long lngRes=this.objSVC.m_lngGetMedApplDeById(seleRow["MEDAPPLID_CHR"].ToString(),out p_dtbResultArr,(string)this.m_objViewer.blebostore.Tag);
			if(lngRes>0&&p_dtbResultArr.Rows.Count>0)
			{
				for(int i1=0;i1<p_dtbResultArr.Rows.Count;i1++)
				{
					m_lngFillLSVApplDe(p_dtbResultArr.Rows[i1]);
				}
			}
            if (seleRow["PSTATUS_INT"].ToString() == "3")
            {
                m_Clock(false);
            }
            else
            {
                m_Clock(true);
            }
		}
		#endregion

		#region 把选择的申请单数据填充到Txtbox
		/// <summary>
		///把选择的申请单数据填充到Txtbox 
		/// </summary>
		/// <param name="SelectRow"></param>
		private void m_lngFillTxtboxOrd(DataRow SelectRow)
		{
			this.m_objViewer.panel4.Tag=SelectRow["MEDAPPLID_CHR"].ToString().Trim();
			this.m_objViewer.comboStroage.Tag=SelectRow["MEDSTORAGEID_CHR"].ToString().Trim();
			this.m_objViewer.comboStroage.Text=SelectRow["storagename_vchr"].ToString().Trim();
			if(SelectRow["APPLDATE_DAT"].ToString()!="")
				this.m_objViewer.dateTime.Text=Convert.ToDateTime(SelectRow["APPLDATE_DAT"].ToString().Trim()).ToString("yyyy年MM月dd日");
			this.m_objViewer.m_txtMemo.Text=SelectRow["MEMO_VCHR"].ToString().Trim();
			this.m_objViewer.txtGrearMan.Tag=SelectRow["CREATOR_CHR"].ToString().Trim();
			this.m_objViewer.txtGrearMan.Text=SelectRow["lastname_vchr"].ToString().Trim();
		}
		#endregion

		#region 把选择的入库单明细数据填充到Txtbox
		/// <summary>
		/// 把选择的入库单明细数据填充到Txtbox
		/// </summary>
		public  void m_lngFillTxtboxOrdDe()
		{
			ModifyDe=1;
			DelCommand=1;
			isAddNew=1;
			this.m_objViewer.btnAdd.Enabled=false;
			this.m_objViewer.btnClear.Enabled=false;
			DataRow SelectRow=dtbApplDe.NewRow();
			SelectRow=(DataRow)this.m_objViewer.LSVApplDe.SelectedItems[0].Tag;
			this.m_objViewer.panel3.Tag=SelectRow["MEDAPPLDEID_CHR"].ToString();
			this.m_objViewer.txtmedicine.Tag=SelectRow["MEDICINEID_CHR"].ToString().Trim();
			this.m_objViewer.txtmedicine.Text=SelectRow["MEDICINENAME_VCHR"].ToString().Trim();
			this.m_objViewer.txttQyt.Text=SelectRow["QTY_DEC"].ToString().Trim();
			this.m_objViewer.txtSpace.Tag=SelectRow["ASSISTCODE_CHR"].ToString().Trim();
			this.m_objViewer.txtSpace.Text=SelectRow["MEDSPEC_VCHR"].ToString().Trim();
			this.m_objViewer.lableUnit.Text=this.m_objViewer.lableUnit1.Text=SelectRow["UNITID_CHR"].ToString().Trim();
		}
		#endregion

		#region  填充申请明细列表
		/// <summary>
		/// 填充申请明细列表
		/// </summary>
		/// <param name="tableRow"></param>
		private void m_lngFillLSVApplDe(DataRow tableRow)
		{
			ListViewItem LisTemp=null;
			LisTemp=new ListViewItem(tableRow["ROWNO_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["ASSISTCODE_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["MEDICINENAME_VCHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["MEDSPEC_VCHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["QTY_DEC"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["UNITID_CHR"].ToString().Trim());
			LisTemp.SubItems.Add(tableRow["TOLFINANCE_DEC"].ToString().Trim());
			LisTemp.Tag=tableRow;
			this.m_objViewer.LSVApplDe.Items.Add(LisTemp);
		}
		#endregion

		#region 把所有的明细数据传到表
		/// <summary>
		/// 把所有的明细数据传到表
		/// </summary>
		/// <param name="dtbApplDeAll"></param>
		private void m_lngFillToTable(out DataTable dtbApplDeAll)
		{
			dtbApplDeAll=new DataTable();
			for(int i1=0;i1<this.m_objViewer.LSVApplDe.Items.Count;i1++)
			{
				DataRow AddRow=dtbApplDe.NewRow();
				AddRow=(DataRow)this.m_objViewer.LSVApplDe.Items[i1].Tag;
				try
				{
					dtbApplDeAll.Columns.Add("MEDAPPLID_CHR");
					dtbApplDeAll.Columns.Add("MEDAPPLDEID_CHR");
					dtbApplDeAll.Columns.Add("MEDICINENAME_VCHR");
					dtbApplDeAll.Columns.Add("MEDICINEID_CHR");
					dtbApplDeAll.Columns.Add("ROWNO_CHR");
					dtbApplDeAll.Columns.Add("QTY_DEC");
					dtbApplDeAll.Columns.Add("APPLDATE_DAT");
					dtbApplDeAll.Columns.Add("MEDSPEC_VCHR");
					dtbApplDeAll.Columns.Add("UNITID_CHR");
					dtbApplDeAll.Columns.Add("ASSISTCODE_CHR");
					dtbApplDeAll.Columns.Add("TOLFINANCE_DEC");

				}
				catch
				{
				}
				DataRow newRow=dtbApplDeAll.NewRow();
				newRow["MEDICINEID_CHR"]=AddRow["MEDICINEID_CHR"];
				newRow["MEDICINENAME_VCHR"]=AddRow["MEDICINENAME_VCHR"];
				newRow["ROWNO_CHR"]=AddRow["ROWNO_CHR"];
				newRow["QTY_DEC"]=AddRow["QTY_DEC"];
				newRow["UNITID_CHR"]=AddRow["UNITID_CHR"];
				newRow["ASSISTCODE_CHR"]=AddRow["ASSISTCODE_CHR"];
				newRow["TOLFINANCE_DEC"]=AddRow["TOLFINANCE_DEC"];
				dtbApplDeAll.Rows.Add(newRow);
			}
		}
		#endregion

		#region 把用户输入的入库单数据绑定到DataRow
		/// <summary>
		/// 把用户输入的入库单数据绑定到DataRow
		/// </summary>
		/// <param name="ApplDataRow"></param>
		private void m_lngFillToDataRow(out DataRow ApplDataRow)
		{
			ApplDataRow=dtbApplArr.NewRow();
			ApplDataRow["MEDAPPLID_CHR"]=(string)this.m_objViewer.panel4.Tag;
			ApplDataRow["APPLMEDSTOREID_CHR"]=(string)this.m_objViewer.blebostore.Tag;
			ApplDataRow["APPLDATE_DAT"]=DateTime.Parse(this.m_objViewer.dateTime.Text).ToString("yyyy-MM-dd")+" "+HisBase.s_GetServerDate().ToLongTimeString();
			ApplDataRow["MEMO_VCHR"]=this.m_objViewer.m_txtMemo.Text.Trim();
			ApplDataRow["CREATOR_CHR"]=this.m_objViewer.LoginInfo.m_strEmpID;
			ApplDataRow["lastname_vchr"]=this.m_objViewer.LoginInfo.m_strEmpName;
			ApplDataRow["MEDSTORAGEID_CHR"]=this.m_objViewer.comboStroage.SelectItemValue;
			ApplDataRow["medstorename_vchr"]=this.m_objViewer.blebostore.Text;
			ApplDataRow["storagename_vchr"]=this.m_objViewer.comboStroage.Text.Trim();
		}
		#endregion


        #region 把用户输入的入库单数据绑定到DataRow
        /// <summary>
        /// 把用户输入的入库单数据绑定到DataRow
        /// </summary>
        /// <param name="ApplDataRow"></param>
        private void m_lngFillToDataRow2(out DataTable dtbApp)
        {
            dtbApp = dtbApplArr.Clone();
            DataRow ApplDataRow = dtbApplArr.NewRow();
            dtbApp.BeginLoadData();
            ApplDataRow["MEDAPPLID_CHR"] = (string)this.m_objViewer.panel4.Tag;
            ApplDataRow["APPLMEDSTOREID_CHR"] = (string)this.m_objViewer.blebostore.Tag;
            ApplDataRow["APPLDATE_DAT"] = DateTime.Parse(this.m_objViewer.dateTime.Text).ToString("yyyy-MM-dd") + " " + HisBase.s_GetServerDate().ToLongTimeString();
            ApplDataRow["MEMO_VCHR"] = this.m_objViewer.m_txtMemo.Text.Trim();
            ApplDataRow["CREATOR_CHR"] = this.m_objViewer.LoginInfo.m_strEmpID;
            ApplDataRow["lastname_vchr"] = this.m_objViewer.LoginInfo.m_strEmpName;
            ApplDataRow["MEDSTORAGEID_CHR"] = this.m_objViewer.comboStroage.SelectItemValue;
            ApplDataRow["medstorename_vchr"] = this.m_objViewer.blebostore.Text;
            ApplDataRow["storagename_vchr"] = this.m_objViewer.comboStroage.Text.Trim();
            dtbApp.Rows.Add(ApplDataRow);
            dtbApp.EndLoadData();
            dtbApp.AcceptChanges();
        }
        #endregion

		#region 保存按钮事件
		/// <summary>
		/// 保存按钮事件
		/// </summary>
		public void m_lngSaveClick()
		{
            DataTable dtApp = null;
            this.m_lngFillToDataRow2(out dtApp);
            DataRow ApplDataRow = dtApp.Rows[0];
            //m_lngFillToDataRow(out ApplDataRow);
			long lngRes;
			if(isAddNew==0)
			{
				if(this.m_objViewer.LSVApplDe.Items.Count>0)
				{
					DataTable dtbApplDe=new DataTable();
					m_lngFillToTable(out dtbApplDe);
					string newID=null;
                    lngRes = this.objSVC.m_lngApplSave(dtApp, dtbApplDe, out newID);
					if(lngRes>0)
					{
						ApplDataRow["MEDAPPLID_CHR"]=newID;
						m_lngFillLsv(ApplDataRow);
						m_lngClear(2);
					}
				}
				else
				{
					clsPublicParm publicClass=new clsPublicParm();
					publicClass.m_mthShowWarning(this.m_objViewer.LSVApplDe,"明细列表中的数据不能为空！");
					this.m_objViewer.txtmedicine.Focus();
				}
			}
			else
			{
				if(ModifyDe==1)
				{
					DataRow  upApplDe=dtbApplDe.NewRow();
					m_lngFillToDeDataRow(out upApplDe);
					lngRes=this.objSVC.m_lngModifiyAppl(upApplDe,ApplDataRow);
					if(lngRes>0)
					{
						MessageBox.Show("修改成功！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
						m_lngModifiyLISV(upApplDe,ApplDataRow);
						m_lngClear(1);
						ModifyDe=0;
					}
					
				}
				else
				{
					lngRes=this.objSVC.m_lngModifiyAppl(null,ApplDataRow);
					if(lngRes>0)
					{
						m_lngModifiyLISV(null,ApplDataRow);
						m_lngClear(1);
					}
				}
			
			}
		}
		#endregion
        #region 提交申请
        /// <summary>
        /// 提交申请
        /// </summary>
        public void m_mthPutAppl()
        {
            if (this.m_objViewer.LSVAppl.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("提交后，该申请单不能再修改，你确定要提交吗？","icare",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataRow DelAppl = dtbApplArr.NewRow();
                    DelAppl = (DataRow)this.m_objViewer.LSVAppl.SelectedItems[0].Tag;
                    long lngRes = this.objSVC.m_lngPutinAppll(DelAppl["MEDAPPLID_CHR"].ToString());
                    if (lngRes > 0)
                    {
                        this.m_objViewer.LSVAppl.Items[this.m_objViewer.LSVAppl.SelectedItems[0].Index].BackColor = System.Drawing.Color.Honeydew;
                        DelAppl["PSTATUS_INT"] = 3;
                        this.m_objViewer.LSVAppl.Items[this.m_objViewer.LSVAppl.SelectedItems[0].Index].Tag = DelAppl;
                        m_Clock(false);
                    }
                }
            }
        }

        #endregion
        #region 锁定用户的操作
        public void m_Clock(bool isclock)
        {
            this.m_objViewer.panel4.Enabled = isclock;
            this.m_objViewer.panel3.Enabled = isclock;
            this.m_objViewer.buttonXP1.Enabled = isclock;
            this.m_objViewer.btnSave.Enabled = isclock;
        }
        #endregion
        #region 修改LisView
        /// <summary>
		/// 修改LisView
		/// </summary>
		/// <param name="upApplDe"></param>
		/// <param name="ApplDataRow"></param>
		private void m_lngModifiyLISV(DataRow upApplDe,DataRow ApplDataRow)
		{
			if(this.m_objViewer.LSVAppl.SelectedItems.Count>0)
			{
				this.m_objViewer.LSVAppl.SelectedItems[0].SubItems[1].Text=ApplDataRow["medstorename_vchr"].ToString();
				this.m_objViewer.LSVAppl.SelectedItems[0].SubItems[3].Text=ApplDataRow["APPLDATE_DAT"].ToString();
				this.m_objViewer.LSVAppl.SelectedItems[0].SubItems[4].Text=ApplDataRow["storagename_vchr"].ToString();
				this.m_objViewer.LSVAppl.SelectedItems[0].Tag=ApplDataRow;
			}
			if(this.m_objViewer.LSVApplDe.SelectedItems.Count>0&&upApplDe!=null)
			{
				this.m_objViewer.LSVApplDe.SelectedItems[0].SubItems[1].Text=upApplDe["ASSISTCODE_CHR"].ToString();
				this.m_objViewer.LSVApplDe.SelectedItems[0].SubItems[2].Text=upApplDe["MEDICINENAME_VCHR"].ToString();
				this.m_objViewer.LSVApplDe.SelectedItems[0].SubItems[3].Text=upApplDe["MEDSPEC_VCHR"].ToString();
				this.m_objViewer.LSVApplDe.SelectedItems[0].SubItems[4].Text=upApplDe["QTY_DEC"].ToString();
				this.m_objViewer.LSVApplDe.SelectedItems[0].SubItems[5].Text=upApplDe["UNITID_CHR"].ToString();
				this.m_objViewer.LSVApplDe.SelectedItems[0].SubItems[6].Text=upApplDe["TOLFINANCE_DEC"].ToString();
				this.m_objViewer.LSVApplDe.SelectedItems[0].Tag=upApplDe;
			}

		}
		#endregion 

		#region 清空用户输入
		/// <summary>
		/// 清空用户输入
		/// </summary>
		/// <param name="Command">1,清空输入申请明细。2，清空全部</param>
		public void m_lngClear(int Command)
		{
			this.m_objViewer.lableUnit1.Text="";
			this.m_objViewer.txtmedicine.Clear();
			this.m_objViewer.txtSpace.Text="";
			this.m_objViewer.txtSpace.Tag=null;
			this.m_objViewer.lableUnit.Text="";
			this.m_objViewer.txttQyt.Text="";
			this.m_objViewer.lableNowStorage.Text="";
			this.m_objViewer.panel3.Tag=null;
			this.m_objViewer.errorProvider1.SetError(this.m_objViewer.comboStroage,"");
			this.m_objViewer.errorProvider1.SetError(this.m_objViewer.txtmedicine,"");
			this.m_objViewer.errorProvider1.SetError(this.m_objViewer.txttQyt,"");
			if(Command==2)
			{
				isAddNew=0;
				this.m_objViewer.btnSave.Text="保存(&S)";
				this.m_objViewer.dateTime.Text=HisBase.s_GetServerDate().ToString("yyyy年MM月dd日");
				this.m_objViewer.panel4.Tag=null;
				this.m_objViewer.m_txtMemo.Text="";
				this.m_objViewer.btnAdd.Enabled=true;
				this.m_objViewer.btnClear.Enabled=true;
				this.m_objViewer.comboStroage.Text="";
				this.m_objViewer.comboStroage.Tag=null;
				this.m_objViewer.LSVApplDe.Items.Clear();
                this.m_Clock(true);
			}
		}

		#endregion

		#region 删除数据
		/// <summary>
		/// 删除数据
		/// </summary>
		public void m_lngDeleClick()
		{
			if(DelCommand==1&&this.m_objViewer.LSVApplDe.SelectedItems.Count>0)
			{
				DataRow DelDe=dtbApplDe.NewRow();
				DelDe=(DataRow)this.m_objViewer.LSVApplDe.SelectedItems[0].Tag;
				long lngRes=this.objSVC.m_lngDeleAppl(DelDe["MEDAPPLDEID_CHR"].ToString(),null);
				if(lngRes>0)
				{
					this.m_objViewer.LSVApplDe.Items.RemoveAt(this.m_objViewer.LSVApplDe.SelectedItems[0].Index);
					m_lngClear(1);
				}
			}
			if(DelCommand==2&&this.m_objViewer.LSVAppl.SelectedItems.Count>0)
			{
				DataRow DelAppl=dtbApplArr.NewRow();
				DelAppl=(DataRow)this.m_objViewer.LSVAppl.SelectedItems[0].Tag;
				long lngRes=this.objSVC.m_lngDeleAppl(null,DelAppl["MEDAPPLID_CHR"].ToString());
				if(lngRes>0)
				{
					this.m_objViewer.LSVAppl.Items.RemoveAt(this.m_objViewer.LSVAppl.SelectedItems[0].Index);
					this.m_objViewer.LSVApplDe.Items.Clear();
					m_lngClear(2);
				}
			}
		}
		#endregion
		#region 为表构造一行
		private void m_mthAddRow(DataRow dtRow,ref DataTable dtbFindApplArr)
		{
			DataRow newRow=dtbFindApplArr.NewRow();
			newRow["MEDAPPLID_CHR"]=dtRow["MEDAPPLID_CHR"];
			newRow["APPLMEDSTOREID_CHR"]=dtRow["APPLMEDSTOREID_CHR"];
			newRow["APPLDATE_DAT"]=dtRow["APPLDATE_DAT"];
			newRow["MEMO_VCHR"]=dtRow["MEMO_VCHR"];
			newRow["CREATOR_CHR"]=dtRow["CREATOR_CHR"];
			newRow["PSTATUS_INT"]=dtRow["PSTATUS_INT"];
			newRow["medstorename_vchr"]=dtRow["medstorename_vchr"];
			newRow["storagename_vchr"]=dtRow["storagename_vchr"];
			newRow["lastname_vchr"]=dtRow["lastname_vchr"];
			dtbFindApplArr.Rows.Add(newRow);
		}

		#endregion
		#region 查找事件
		/// <summary>
		/// 查找事件
		/// </summary>
		public void m_lngFindClick()
		{
			this.m_objViewer.LSVAppl.Items.Clear();
			this.m_objViewer.LSVApplDe.Items.Clear();
			if(dtbApplArr.Rows.Count>0)
			{
				string p_strFindType=this.m_objViewer.cboFind.Text.Trim();
				string p_strFind=this.m_objViewer.txtFind.Text.Trim();
				dtbFindApplArr.Rows.Clear();
				if(p_strFindType!=""&&p_strFind!="")
				{
					try
					{
						dtbFindApplArr.Columns.Add("MEDAPPLID_CHR");
						dtbFindApplArr.Columns.Add("APPLMEDSTOREID_CHR");
						dtbFindApplArr.Columns.Add("APPLDATE_DAT");
						dtbFindApplArr.Columns.Add("MEMO_VCHR");
						dtbFindApplArr.Columns.Add("CREATOR_CHR");
						dtbFindApplArr.Columns.Add("MEDSTORAGEID_CHR");
						dtbFindApplArr.Columns.Add("PSTATUS_INT");
						dtbFindApplArr.Columns.Add("medstorename_vchr");
						dtbFindApplArr.Columns.Add("storagename_vchr");
						dtbFindApplArr.Columns.Add("lastname_vchr");
					}
					catch
					{
					}
					switch(p_strFindType)
					{
						case "领药药库":
							for(int i1=0;i1<dtbApplArr.Rows.Count;i1++)
							{
								if(dtbApplArr.Rows[i1]["storagename_vchr"].ToString().IndexOf(p_strFind,0)==0)
								{
									m_mthAddRow(dtbApplArr.Rows[i1],ref dtbFindApplArr);
								}
							}
							break;
						case "申请日期":
							for(int i1=0;i1<dtbApplArr.Rows.Count;i1++)
							{
								if(dtbApplArr.Rows[i1]["APPLDATE_DAT"].ToString().IndexOf(p_strFind,0)==0)
								{
									m_mthAddRow(dtbApplArr.Rows[i1],ref dtbFindApplArr);
								}
							}
							break;
						case "申领人":
							for(int i1=0;i1<dtbApplArr.Rows.Count;i1++)
							{
								if(dtbApplArr.Rows[i1]["lastname_vchr"].ToString().IndexOf(p_strFind,0)==0)
								{
									m_mthAddRow(dtbApplArr.Rows[i1],ref dtbFindApplArr);
								}
							}
							break;
					}
					m_lngClearFind();
					if(dtbFindApplArr.Rows.Count>0)
					{
						for(int i1=0;i1<dtbFindApplArr.Rows.Count;i1++)
						{
								m_lngFillLsv(dtbFindApplArr.Rows[i1]);
						}
					}
					else
						MessageBox.Show("找不到你所需的数据","Icare",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				else
					MessageBox.Show("请你输入查询条件！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Warning);
			}
		}
		#endregion

		#region 清空查找数据输入框
		/// <summary>
		///  清空查找数据输入框
		/// </summary>
		private void m_lngClearFind()
		{
			this.m_objViewer.LSVAppl.Items.Clear();
			this.m_objViewer.LSVApplDe.Items.Clear();
		}
		#endregion

		#region 返回按钮事件
		/// <summary>
		/// 返回按钮事件
		/// </summary>
		public void m_lngReturnClick()
		{

			this.m_objViewer.LSVAppl.Items.Clear();
			if(dtbApplArr.Rows.Count>0)
			{
				for(int i1=0;i1<dtbApplArr.Rows.Count;i1++)
				{
					m_lngFillLsv(dtbApplArr.Rows[i1]);
				}
			}
			this.m_objViewer.panel6.Visible=false;
		}
		#endregion

		#region 生成按钮事件
		/// <summary>
		/// 生成按钮事件
		/// </summary>
		public void m_lngAutoClick()
		{
				long lngRes=this.objSVC.m_lngAutoGetMedAppl(out dtbAutoTable,(string)this.m_objViewer.blebostore.Tag);
			    this.m_objViewer.lsvlimi.Items.Clear();
				if(lngRes>0&&dtbAutoTable.Rows.Count>0)
				{
					for(int i1=0;i1<dtbAutoTable.Rows.Count;i1++)
					{
						m_lngAutoFillLSV(dtbAutoTable.Rows[i1]);
					}
				}
			this.m_objViewer.panelord.Top=0;
			this.m_objViewer.panelord.Left=0;
			this.m_objViewer.panelord.Visible=true;
		}
		#endregion
		
		#region 初始化查找数据表
		private void m_ResetFindDt()
		{
			dtbAutoFind=new DataTable();
			dtbAutoFind.Columns.Add("MEDSTOREID_CHR");
			dtbAutoFind.Columns.Add("MEDICINEID_CHR");
			dtbAutoFind.Columns.Add("LOWLIMIT_DEC");
			dtbAutoFind.Columns.Add("PLANQTY_DEC");
			dtbAutoFind.Columns.Add("UNITID_CHR");
			dtbAutoFind.Columns.Add("medstorename_vchr");
			dtbAutoFind.Columns.Add("medicinename_vchr");
			dtbAutoFind.Columns.Add("medspec_vchr");
			dtbAutoFind.Columns.Add("amount_dec");
		}
		#endregion

		#region 为表构造一行
		private void m_mthAddRowToTable(DataRow DtRow,ref DataTable dtbAutoFind)
		{
			DataRow Row=dtbAutoFind.NewRow();
			Row["MEDSTOREID_CHR"]=DtRow["MEDSTOREID_CHR"];
			Row["MEDICINEID_CHR"]=DtRow["MEDICINEID_CHR"];
			Row["LOWLIMIT_DEC"]=DtRow["LOWLIMIT_DEC"];
			Row["PLANQTY_DEC"]=DtRow["PLANQTY_DEC"];
			Row["UNITID_CHR"]=DtRow["UNITID_CHR"];
			Row["medstorename_vchr"]=DtRow["medstorename_vchr"];
			Row["medicinename_vchr"]=DtRow["medicinename_vchr"];
			Row["medspec_vchr"]=DtRow["medspec_vchr"];
			Row["amount_dec"]=DtRow["amount_dec"];
			dtbAutoFind.Rows.Add(Row);
			
		}
		#endregion
		#region 自动生成中的查找按钮
		/// <summary>
		///自动生成中的查找按钮 
		/// </summary>
		public void m_lngAutoFindClick()
		{
			if(dtbAutoTable.Rows.Count==0)
				return;
			this.m_objViewer.lsvlimi.Items.Clear();
			string StoreAuto=this.m_objViewer.cbosele.Text.Trim();
			string medNameAuto=this.m_objViewer.txt_Find.Text.Trim();
			if(dtbAutoFind!=null)
			dtbAutoFind.Rows.Clear();
			if(StoreAuto!=""||medNameAuto!="")
			{
				if(dtbAutoTable.Rows.Count>0)
				{
					if(dtbAutoFind==null)
					{
						m_ResetFindDt();
					}
					switch(StoreAuto)
					{
						case "药品助记码":
							for(int i1=0;i1<dtbAutoTable.Rows.Count;i1++)
							{
								if(dtbAutoTable.Rows[i1]["ASSISTCODE_CHR"].ToString().IndexOf(medNameAuto,0)==0)
								{
									m_mthAddRowToTable(dtbAutoTable.Rows[i1],ref dtbAutoFind);
								}
							}
							break;
						case "药品名称":
							for(int i1=0;i1<dtbAutoTable.Rows.Count;i1++)
							{
								if(dtbAutoTable.Rows[i1]["medicinename_vchr"].ToString().IndexOf(medNameAuto,0)==0)
								{
									m_mthAddRowToTable(dtbAutoTable.Rows[i1],ref dtbAutoFind);
								}
							}
							break;
						case "拼音码":
							for(int i1=0;i1<dtbAutoTable.Rows.Count;i1++)
							{
								if(dtbAutoTable.Rows[i1]["PYCODE_CHR"].ToString().IndexOf(medNameAuto,0)==0)
								{
									m_mthAddRowToTable(dtbAutoTable.Rows[i1],ref dtbAutoFind);
								}
							}
							break;
						case "五笔码码":
							for(int i1=0;i1<dtbAutoTable.Rows.Count;i1++)
							{
								if(dtbAutoTable.Rows[i1]["WBCODE_CHR"].ToString().IndexOf(medNameAuto,0)==0)
								{
									m_mthAddRowToTable(dtbAutoTable.Rows[i1],ref dtbAutoFind);
								}
							}
							break;
					}
				}
				if(dtbAutoFind.Rows.Count>0)
				{
					for(int i1=0;i1<dtbAutoFind.Rows.Count;i1++)
					{
						m_lngAutoFillLSV(dtbAutoFind.Rows[i1]);
					}
				}
				else
					MessageBox.Show("对不起，找不到你所需的数据！","Icare",MessageBoxButtons.OK,MessageBoxIcon.Hand);
			}
			else
			  MessageBox.Show("请入查询条件","Icare",MessageBoxButtons.OK,MessageBoxIcon.Stop);

		}
		#endregion

		#region 把自动生成数据填充到列表
		/// <summary>
		/// 把自动生成数据填充到列表
		/// </summary>
		/// <param name="Row"></param>
		private void m_lngAutoFillLSV(DataRow Row)
		{
			ListViewItem LisTemp=new ListViewItem("");
			LisTemp.SubItems.Add(Row["medicinename_vchr"].ToString());
			LisTemp.SubItems.Add(Row["UNITID_CHR"].ToString());
			LisTemp.SubItems.Add(Row["amount_dec"].ToString());
			LisTemp.SubItems.Add(Row["LOWLIMIT_DEC"].ToString());
			LisTemp.SubItems.Add(Row["PLANQTY_DEC"].ToString());
			LisTemp.Tag=Row;
			this.m_objViewer.lsvlimi.Items.Add(LisTemp);
		}
		#endregion

		#region 自动生成中的返回按钮
		/// <summary>
		/// 自动生成中的返回按钮
		/// </summary>
		public void m_lngRetureAuto()
		{
			if(dtbAutoFind!=null)
			   dtbAutoFind.Rows.Clear();
			this.m_objViewer.lsvlimi.Items.Clear();
			this.m_objViewer.cbosele.Text="";
			this.m_objViewer.txt_Find.Text="";
			if(dtbAutoTable.Rows.Count>0)
			{
				for(int i1=0;i1<dtbAutoTable.Rows.Count;i1++)
				{
					m_lngAutoFillLSV(dtbAutoTable.Rows[i1]);
				}
			}

		}
		#endregion

		#region 自动生成采购单(全部)
		/// <summary>
		/// 自动生成采购单(全部)
		/// </summary>
		public void m_lngAutomatismAll()
		{

			if(dtbAutoFind!=null&&dtbAutoFind.Rows.Count>0)
			{
				DataSet TableArr=new DataSet();
				int i1=0;
				int j2=0;
				while(i1<dtbAutoFind.Rows.Count)
				{
					DataTable Table=new DataTable("Table"+j2.ToString());
					try
					{
						Table.Columns.Add("MEDSTOREID_CHR");
						Table.Columns.Add("MEDICINEID_CHR");
						Table.Columns.Add("QTY_DEC");
						Table.Columns.Add("UNITID_CHR");
						Table.Columns.Add("medstorename_vchr");
						Table.Columns.Add("medicinename_vchr");
						Table.Columns.Add("medspec_vchr");
						Table.Columns.Add("MEDAPPLID_CHR");
						Table.Columns.Add("ROWNO_CHR");
						Table.Columns.Add("amount_dec");
					}
					catch
					{
					}
					int e4=1;
					for(int f2=i1+1;f2<dtbAutoFind.Rows.Count;f2++)
					{
						if(dtbAutoFind.Rows[f2]["MEDSTOREID_CHR"].ToString().Trim()==dtbAutoFind.Rows[i1]["MEDSTOREID_CHR"].ToString().Trim())
						{
							DataRow NewRow=Table.NewRow();
							NewRow["MEDSTOREID_CHR"]=dtbAutoFind.Rows[f2]["MEDSTOREID_CHR"];
							NewRow["MEDICINEID_CHR"]=dtbAutoFind.Rows[f2]["MEDICINEID_CHR"];
							NewRow["medstorename_vchr"]=dtbAutoFind.Rows[f2]["medstorename_vchr"];
							NewRow["QTY_DEC"]=dtbAutoFind.Rows[f2]["PLANQTY_DEC"];
							NewRow["UNITID_CHR"]=dtbAutoFind.Rows[f2]["UNITID_CHR"];
							NewRow["amount_dec"]=dtbAutoFind.Rows[f2]["amount_dec"];
							NewRow["ROWNO_CHR"]=e4.ToString("000");
							Table.Rows.Add(NewRow);
							dtbAutoFind.Rows.RemoveAt(f2);
							e4++;
						}
					}
					DataRow NewRow1=Table.NewRow();
					NewRow1["MEDSTOREID_CHR"]=dtbAutoFind.Rows[i1]["MEDSTOREID_CHR"];
					NewRow1["MEDICINEID_CHR"]=dtbAutoFind.Rows[i1]["MEDICINEID_CHR"];
					NewRow1["medstorename_vchr"]=dtbAutoFind.Rows[i1]["medstorename_vchr"];
					NewRow1["QTY_DEC"]=dtbAutoFind.Rows[i1]["PLANQTY_DEC"];
					NewRow1["UNITID_CHR"]=dtbAutoFind.Rows[i1]["UNITID_CHR"];
					NewRow1["amount_dec"]=dtbAutoFind.Rows[i1]["amount_dec"];
					NewRow1["ROWNO_CHR"]=e4.ToString("000");
					Table.Rows.Add(NewRow1);
					TableArr.Tables.Add(Table);
					dtbAutoFind.Rows.RemoveAt(i1);
					i1=0;
					j2++;
				}
				for(int h3=0;h3<TableArr.Tables.Count;h3++)
				{
                    DataTable dtbApp = dtbApplArr.Clone();
					DataRow newRow=dtbApplArr.NewRow();
					newRow["CREATOR_CHR"]=this.m_objViewer.LoginInfo.m_strEmpID;
					newRow["lastname_vchr"]=this.m_objViewer.LoginInfo.m_strEmpName;
					newRow["MEMO_VCHR"]="系统自动生成的领药单";
					newRow["APPLDATE_DAT"]=clsPublicParm.s_datGetServerDate();
					newRow["APPLMEDSTOREID_CHR"]=TableArr.Tables["Table"+h3.ToString()].Rows[0]["MEDSTOREID_CHR"].ToString().Trim();
					newRow["medstorename_vchr"]=TableArr.Tables["Table"+h3.ToString()].Rows[0]["medstorename_vchr"].ToString().Trim();
					string newidOk="";
                    dtbApp.Rows.Add(newRow);
                    dtbApp.AcceptChanges();
                    long lngRes = this.objSVC.m_lngApplSave(dtbApp, TableArr.Tables["Table" + h3.ToString()], out newidOk);
					if(lngRes==1)
					{
						newRow["MEDAPPLID_CHR"]=newidOk;
						m_lngFillLsv(newRow);
					}
				}
				this.m_objViewer.panelord.Visible=false;
				MessageBox.Show("己成功生成领药单","Icare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				DataSet TableArr=new DataSet();
				int i1=0;
				int j2=0;
				while(i1<dtbAutoTable.Rows.Count)
				{
					DataTable Table=new DataTable("Table"+j2.ToString());
					try
					{
						Table.Columns.Add("MEDSTOREID_CHR");
						Table.Columns.Add("MEDICINEID_CHR");
						Table.Columns.Add("QTY_DEC");
						Table.Columns.Add("UNITID_CHR");
						Table.Columns.Add("medstorename_vchr");
						Table.Columns.Add("medicinename_vchr");
						Table.Columns.Add("medspec_vchr");
						Table.Columns.Add("MEDAPPLID_CHR");
						Table.Columns.Add("ROWNO_CHR");
						Table.Columns.Add("amount_dec");
					}
					catch
					{
					}
					int e4=1;
					for(int f2=i1+1;f2<dtbAutoTable.Rows.Count;f2++)
					{
						if(dtbAutoTable.Rows[f2]["MEDSTOREID_CHR"].ToString().Trim()==dtbAutoTable.Rows[i1]["MEDSTOREID_CHR"].ToString().Trim())
						{
							DataRow NewRow=Table.NewRow();
							NewRow["MEDSTOREID_CHR"]=dtbAutoTable.Rows[f2]["MEDSTOREID_CHR"];
							NewRow["MEDICINEID_CHR"]=dtbAutoTable.Rows[f2]["MEDICINEID_CHR"];
							NewRow["medstorename_vchr"]=dtbAutoTable.Rows[f2]["medstorename_vchr"];
							NewRow["QTY_DEC"]=dtbAutoTable.Rows[f2]["PLANQTY_DEC"];
							NewRow["UNITID_CHR"]=dtbAutoTable.Rows[f2]["UNITID_CHR"];
							NewRow["amount_dec"]=dtbAutoTable.Rows[f2]["amount_dec"];
							NewRow["ROWNO_CHR"]=e4.ToString("000");
							Table.Rows.Add(NewRow);
							dtbAutoTable.Rows.RemoveAt(f2);
							e4++;
						}
					}
					DataRow NewRow1=Table.NewRow();
					NewRow1["MEDSTOREID_CHR"]=dtbAutoTable.Rows[i1]["MEDSTOREID_CHR"];
					NewRow1["MEDICINEID_CHR"]=dtbAutoTable.Rows[i1]["MEDICINEID_CHR"];
					NewRow1["medstorename_vchr"]=dtbAutoTable.Rows[i1]["medstorename_vchr"];
					NewRow1["QTY_DEC"]=dtbAutoTable.Rows[i1]["PLANQTY_DEC"];
					NewRow1["UNITID_CHR"]=dtbAutoTable.Rows[i1]["UNITID_CHR"];
					NewRow1["amount_dec"]=dtbAutoTable.Rows[i1]["amount_dec"];
					NewRow1["ROWNO_CHR"]=e4.ToString("000");
					Table.Rows.Add(NewRow1);
					TableArr.Tables.Add(Table);
					dtbAutoTable.Rows.RemoveAt(i1);
					i1=0;
					j2++;
				}
				for(int h3=0;h3<TableArr.Tables.Count;h3++)
				{
                    DataTable dtapp = dtbApplArr.Clone();
					DataRow newRow=dtbApplArr.NewRow();
					newRow["CREATOR_CHR"]=this.m_objViewer.LoginInfo.m_strEmpID;
					newRow["lastname_vchr"]=this.m_objViewer.LoginInfo.m_strEmpName;
					newRow["MEMO_VCHR"]="系统自动生成的领药单";
					newRow["APPLDATE_DAT"]=clsPublicParm.s_datGetServerDate();
					newRow["APPLMEDSTOREID_CHR"]=TableArr.Tables["Table"+h3.ToString()].Rows[0]["MEDSTOREID_CHR"].ToString().Trim();
					newRow["medstorename_vchr"]=TableArr.Tables["Table"+h3.ToString()].Rows[0]["medstorename_vchr"].ToString().Trim();
					string newidOk="";
                    dtapp.Rows.Add(newRow);
                    dtapp.AcceptChanges();
                    long lngRes = this.objSVC.m_lngApplSave(dtapp, TableArr.Tables["Table" + h3.ToString()], out newidOk);
					if(lngRes==1)
					{
						newRow["MEDAPPLID_CHR"]=newidOk;
						m_lngFillLsv(newRow);
					}
				}
				this.m_objViewer.panelord.Visible=false;
				MessageBox.Show("己成功生成领药单","Icare",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}

		}
		#endregion

		#region 自动生成采购单(根据选择生成)
		/// <summary>
		/// 自动生成采购单(根据选择生成)
		/// </summary>
		public void m_lngAutomatism()
		{
			DataTable SeleDataToTable=new DataTable();
			try
			{
				SeleDataToTable.Columns.Add("MEDSTOREID_CHR");
				SeleDataToTable.Columns.Add("MEDICINEID_CHR");
				SeleDataToTable.Columns.Add("LOWLIMIT_DEC");
				SeleDataToTable.Columns.Add("PLANQTY_DEC");
				SeleDataToTable.Columns.Add("UNITID_CHR");
				SeleDataToTable.Columns.Add("medstorename_vchr");
				SeleDataToTable.Columns.Add("medicinename_vchr");
				SeleDataToTable.Columns.Add("medspec_vchr");
				SeleDataToTable.Columns.Add("amount_dec");
			}
			catch
			{
			}
			if(this.m_objViewer.lsvlimi.Items.Count>0)
			{
				for(int k1=0;k1<this.m_objViewer.lsvlimi.Items.Count;k1++)
				{
					if(this.m_objViewer.lsvlimi.Items[k1].Checked==true)
					{
						DataRow newRow=SeleDataToTable.NewRow();
						newRow=(DataRow)this.m_objViewer.lsvlimi.Items[k1].Tag;
						DataRow SeleRow=SeleDataToTable.NewRow();
						SeleRow["MEDSTOREID_CHR"]=newRow["MEDSTOREID_CHR"];
						SeleRow["MEDICINEID_CHR"]=newRow["MEDICINEID_CHR"];
						SeleRow["LOWLIMIT_DEC"]=newRow["LOWLIMIT_DEC"];
						SeleRow["PLANQTY_DEC"]=newRow["PLANQTY_DEC"];
						SeleRow["UNITID_CHR"]=newRow["UNITID_CHR"];
						SeleRow["medstorename_vchr"]=newRow["medstorename_vchr"];
						SeleRow["medicinename_vchr"]=newRow["medicinename_vchr"];
						SeleRow["medspec_vchr"]=newRow["medspec_vchr"];
						SeleRow["amount_dec"]=newRow["amount_dec"];
						SeleDataToTable.Rows.Add(SeleRow);
					}
				}
			}
			DataSet TableArr=new DataSet();
			int i1=0;
			int j2=0;
			while(i1<SeleDataToTable.Rows.Count)
			{
				DataTable Table=new DataTable("Table"+j2.ToString());
				try
				{
					Table.Columns.Add("MEDSTOREID_CHR");
					Table.Columns.Add("MEDICINEID_CHR");
					Table.Columns.Add("QTY_DEC");
					Table.Columns.Add("UNITID_CHR");
					Table.Columns.Add("medstorename_vchr");
					Table.Columns.Add("medicinename_vchr");
					Table.Columns.Add("medspec_vchr");
					Table.Columns.Add("MEDAPPLID_CHR");
					Table.Columns.Add("ROWNO_CHR");
					Table.Columns.Add("amount_dec");
				}
				catch
				{
				}
				int e4=1;
				for(int f2=i1+1;f2<SeleDataToTable.Rows.Count;f2++)
				{
					if(SeleDataToTable.Rows[f2]["MEDSTOREID_CHR"].ToString().Trim()==SeleDataToTable.Rows[i1]["MEDSTOREID_CHR"].ToString().Trim())
					{
						DataRow NewRow=Table.NewRow();
						NewRow["MEDSTOREID_CHR"]=SeleDataToTable.Rows[f2]["MEDSTOREID_CHR"];
						NewRow["MEDICINEID_CHR"]=SeleDataToTable.Rows[f2]["MEDICINEID_CHR"];
						NewRow["medstorename_vchr"]=SeleDataToTable.Rows[f2]["medstorename_vchr"];
						NewRow["QTY_DEC"]=SeleDataToTable.Rows[f2]["PLANQTY_DEC"];
						NewRow["UNITID_CHR"]=SeleDataToTable.Rows[f2]["UNITID_CHR"];
						NewRow["amount_dec"]=SeleDataToTable.Rows[f2]["amount_dec"];
						NewRow["ROWNO_CHR"]=e4.ToString("000");
						Table.Rows.Add(NewRow);
						SeleDataToTable.Rows.RemoveAt(f2);
						e4++;
					}
				}
				DataRow NewRow1=Table.NewRow();
				NewRow1["MEDSTOREID_CHR"]=SeleDataToTable.Rows[i1]["MEDSTOREID_CHR"];
				NewRow1["MEDICINEID_CHR"]=SeleDataToTable.Rows[i1]["MEDICINEID_CHR"];
				NewRow1["medstorename_vchr"]=SeleDataToTable.Rows[i1]["medstorename_vchr"];
				NewRow1["QTY_DEC"]=SeleDataToTable.Rows[i1]["PLANQTY_DEC"];
				NewRow1["UNITID_CHR"]=SeleDataToTable.Rows[i1]["UNITID_CHR"];
				NewRow1["amount_dec"]=SeleDataToTable.Rows[i1]["amount_dec"];
				NewRow1["ROWNO_CHR"]=e4.ToString("000");
				Table.Rows.Add(NewRow1);
				TableArr.Tables.Add(Table);
				SeleDataToTable.Rows.RemoveAt(i1);
				i1=0;
				j2++;
			}
			for(int h3=0;h3<TableArr.Tables.Count;h3++)
			{
                DataTable dtTmp = dtbApplArr.Clone();
				DataRow newRow=dtbApplArr.NewRow();
				newRow["CREATOR_CHR"]=this.m_objViewer.LoginInfo.m_strEmpID;
				newRow["lastname_vchr"]=this.m_objViewer.LoginInfo.m_strEmpName;
				newRow["MEMO_VCHR"]="系统自动生成的领药单";
				newRow["APPLDATE_DAT"]=clsPublicParm.s_datGetServerDate();
				newRow["APPLMEDSTOREID_CHR"]=TableArr.Tables["Table"+h3.ToString()].Rows[0]["MEDSTOREID_CHR"].ToString().Trim();
				newRow["medstorename_vchr"]=TableArr.Tables["Table"+h3.ToString()].Rows[0]["medstorename_vchr"].ToString().Trim();
				string newidOk="";
                dtTmp.Rows.Add(newRow);
                dtTmp.AcceptChanges();
                long lngRes = this.objSVC.m_lngApplSave(dtTmp, TableArr.Tables["Table" + h3.ToString()], out newidOk);
				if(lngRes==1)
				{
					newRow["MEDAPPLID_CHR"]=newidOk;
					m_lngFillLsv(newRow);
				}
			}
			this.m_objViewer.panelord.Visible=false;
			MessageBox.Show("己成功生成领药单","系统提示");

		}
		#endregion
	}
}
