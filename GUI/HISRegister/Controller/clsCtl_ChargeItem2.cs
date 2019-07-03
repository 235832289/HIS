using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;
namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// clsCtl_ChargeItem2 的摘要说明。
	/// </summary>
	public class clsCtl_ChargeItem2:com.digitalwave.GUI_Base.clsController_Base
	{
		private clsDcl_ChargeItem objSvc=null;
		private DataTable dt=null;
		public clsCtl_ChargeItem2()
		{
			objSvc=new clsDcl_ChargeItem();
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}
		#region 设置窗体对象
		public com.digitalwave.iCare.gui.HIS.frmChargeItem3 m_objViewer;
		/// <summary>
		/// 设置窗体对象
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
			m_objViewer = (frmChargeItem3)frmMDI_Child_Base_in;
		}
		#endregion
		#region 窗口初始化工作
		public void m_mthFormLoad()
		{

		this.m_mthFillCat();
		this.m_mthFillAll();
        //this.m_mthFillBihCat();
		this.m_mthFillCARETYPE();
		m_mthSelectItem(m_objViewer.m_cmbCoustomPrice);
		m_mthSelectItem(this.m_objViewer.m_cmbOPUseUint);
		m_mthSelectItem(this.m_objViewer.m_cmbIPUseUint);
		m_mthSelectItem(this.m_objViewer.m_cmbCoustomPrice);
		//m_mthSelectItem((ComboBox)this.m_objViewer.m_cboCase);
		m_mthSelectItem((ComboBox)this.m_objViewer.m_cboApplyType);		
		m_mthSelectItem(this.m_objViewer.m_cmbIsExpensive);
		this.m_objViewer.m_cmbIsInDocAdv.SelectedIndex=1;
        this.m_objViewer.m_cboKeepUse.SelectedIndex = 1;
		m_objViewer.m_cmbFind.SelectedIndex=2;
		}
		private void m_mthSelectItem(ComboBox cb)
		{
			if(cb.Items.Count>0)
			{
			cb.SelectedIndex=0;
			}
		}
		#endregion
		#region 填充医保类型
		private void m_mthFillCARETYPE()
		{
			DataTable dtCARETYPE=new DataTable();
			long lngRes = objSvc.m_getMEDICARETYPE(out dtCARETYPE);
			if((lngRes>0)&&dtCARETYPE!=null)
			{
				this.m_objViewer.COBINSURANCETYPE.Item.Add("","");
                this.m_objViewer.cboInpInsuranceType.Item.Add("", "");
				for(int i1=0;i1<dtCARETYPE.Rows.Count;i1++)
				{
					this.m_objViewer.COBINSURANCETYPE.Item.Add(dtCARETYPE.Rows[i1]["TYPENAME_VCHR"].ToString(),dtCARETYPE.Rows[i1]["TYPEID_CHR"].ToString());
                    this.m_objViewer.cboInpInsuranceType.Item.Add(dtCARETYPE.Rows[i1]["TYPENAME_VCHR"].ToString(), dtCARETYPE.Rows[i1]["TYPEID_CHR"].ToString());
				}
			}

		}
		#endregion

        #region 获取医嘱类型
        //private void m_mthFillBihCat()
        //{
        //    DataTable dt = new DataTable();
        //    long lngRes = objSvc.m_lngGetAllBihCate(out dt);
        //    if (dt.Rows.Count > 0)
        //    {
        //        this.m_objViewer.ORDERCATENAME.Item.Add("", "");
        //        for (int i1 = 0; i1 < dt.Rows.Count; i1++)
        //        {
        //            this.m_objViewer.ORDERCATENAME.Item.Add(dt.Rows[i1]["ORDERCATENAME_VCHR"].ToString(), dt.Rows[i1]["ORDERCATEID_CHR"].ToString());
        //        }
        //    }
        //}
        #endregion
        #region 取得项目的类型
        private void m_mthFillCat()
		{
			clsCharegeItemCat_VO[] objResult;
			long lngRes = objSvc.m_mthFindCat(out objResult);
			m_objViewer.m_cmbType.Items.Clear();
			m_objViewer.m_cmbType2.Items.Clear();
			if((lngRes>0)&&(objResult != null))
			{
				for(int i1=0; i1<objResult.Length;i1++)
				{
					m_objViewer.m_cmbType2.Item.Add(objResult[i1].m_strItemCatName,objResult[i1].m_strItemCatID);
					if(this.m_objViewer.strPopedom=="")
					{
						m_objViewer.m_cmbType.Item.Add(objResult[i1].m_strItemCatName,objResult[i1].m_strItemCatID);
					}
					else
					{
						if(m_mthAddPopedom(objResult[i1].m_strItemCatID.Trim()))
						{
							m_objViewer.Name+=i1.ToString();
							m_objViewer.m_cmbType.Item.Add(objResult[i1].m_strItemCatName,objResult[i1].m_strItemCatID);
						}
					}
				}
			}
			if(m_objViewer.m_cmbType.Items.Count>0)
			{
				m_objViewer.m_cmbType.SelectedIndex=0;
                if (this.m_objViewer.dataGrid1.CurrentRowIndex >= 0)
                {
                    this.m_mthDataGridCellChange();
                }
				m_objViewer.m_cmbType2.SelectedIndex=0;
				
			}
		}
		private bool m_mthAddPopedom(string strCatID)
		{
			bool ret =false;
			string[] strArr =this.m_objViewer.strPopedom.Split('*');
			for(int i =0;i<strArr.Length;i++)
			{
				if(strArr[i].Trim()==strCatID)
				{
				ret =true;
				break;
				}
			}
			return ret;

		}
		#endregion
		#region 查询收费项目
		public void m_mthFindChargeItem(string strCatID,string strType,string strContent)
		{
			m_objViewer.m_cmbType.SelectedIndexChanged -= new System.EventHandler(m_objViewer.m_cmbType_SelectedIndexChanged);	
			long strRet=objSvc.m_mthFindChargeItem(strCatID,strType,strContent.ToUpper(),out dt);
				dt.TableName="dt";
			if(dt.Rows.Count>0&&strCatID=="")
			{
				this.m_objViewer.m_cmbType.FindKey(dt.Rows[0]["ITEMCATID_CHR"].ToString().Trim());
			}
			if(strRet>0)
			{
			this.m_objViewer.dataGrid1.DataSource=dt;
			}
			this.m_objViewer.dataGrid1.CurrentCell=new DataGridCell(0,0);
			if(dt.Rows.Count>0)
			{
				this.m_mthDataGridCellChange();
			}
			else
			{
			this.m_Clear();
			}
			m_objViewer.m_cmbType.SelectedIndexChanged += new System.EventHandler(m_objViewer.m_cmbType_SelectedIndexChanged);
		}
		#endregion
		#region 查找下拉框改变选项
		public void m_cmbFind_SelectedIndexChanged()
		{
            switch(m_objViewer.m_cmbFind.SelectedIndex)
			{
				case 0://项目ID
					m_objViewer.m_cmbFind.Tag="ITEMID_CHR";
					break;
				case 1://项目名称
					m_objViewer.m_cmbFind.Tag="ITEMNAME_VCHR";
					break;
				case 2://项目编码
					m_objViewer.m_cmbFind.Tag="ITEMCODE_VCHR";
					break;
				case 3://项目拼音
					m_objViewer.m_cmbFind.Tag="ITEMPYCODE_CHR";
					break;
				case 4://项目五笔
					m_objViewer.m_cmbFind.Tag="ITEMWBCODE_CHR";
					break;
				case 5:
					m_objViewer.m_cmbFind.Tag="ITEMENGNAME_VCHR";
					break;
			}
			m_objViewer.m_txtFind.Select();
		}
		#endregion
		#region 填充各下拉控件
		private void m_mthFillAll()
		{
			this.m_FillUnit();
			this.m_FillUsage();
			//this.m_FillExType();
			m_FillApplyType();
           // this.m_mthFillOrderCate();
      
            
		}
        //private void m_mthFillOrderCate()
        //{
        //    DataTable m_objTable;
        //    long lngRes = -1;
        //    lngRes = objSvc.m_mthSelectOrderCate(out m_objTable);
            
        //    if (lngRes > 0 && m_objTable.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < m_objTable.Rows.Count; i++)
        //        {
        //            m_objViewer.cboOrderCate.Item.Add(m_objTable.Rows[i]["NAME_CHR"].ToString().Trim(), m_objTable.Rows[i]["ORDERCATEID_CHR"].ToString().Trim());
        //        }
        //    }

        //}
        private void m_FillUnit()
		{
			clsUnit_VO[] objResult;
			long lngRes=objSvc.m_mthGetUnit(out objResult);
			if(lngRes>0 && objResult.Length>0)
			{
				for(int i1=0;i1<objResult.Length;i1++)
				{
					m_objViewer.m_cboUnit.Item.Add(objResult[i1].m_strUnitName,objResult[i1].m_strUnitID);
					m_objViewer.m_cboDosUnit.Item.Add(objResult[i1].m_strUnitName,objResult[i1].m_strUnitID);
					m_objViewer.m_cboOPUnit.Item.Add(objResult[i1].m_strUnitName,objResult[i1].m_strUnitID);
					m_objViewer.m_cboIPUnit.Item.Add(objResult[i1].m_strUnitName,objResult[i1].m_strUnitID);
					
				}
			}
			//暂时注释
//			m_objViewer.cmbCheckPart.Item.Add("","-1");
//			DataTable dt;
//			lngRes=objSvc.m_mthLoadCheckType(out dt,"");
//			if(lngRes>0 && dt.Rows.Count>0)
//			{
//				for(int i1=0;i1< dt.Rows.Count;i1++)
//				{
//					m_objViewer.cmbCheckPart.Item.Add(dt.Rows[i1]["TYPENAME"].ToString().Trim(),dt.Rows[i1]["ID"].ToString().Trim());
//				}
//			}
		}
		private void m_FillApplyType()
		{
			DataTable dt;
			long lngRes=objSvc.m_mthFindApplyType(out dt,"");
			m_objViewer.m_cboApplyType.Item.Add("","-1");
			if(lngRes>0 && dt.Rows.Count>0)
			{
				for(int i1=0;i1< dt.Rows.Count;i1++)
				{
					m_objViewer.m_cboApplyType.Item.Add(dt.Rows[i1]["TYPETEXT"].ToString().Trim(),dt.Rows[i1]["TYPEID"].ToString().Trim());
				}
			}
		}
       
        public  int  m_mthFindDefaultFreq(string m_strFindText)
        {
            long lngRes=-1;
            DataTable m_objFREQTable = new DataTable();
            lngRes = objSvc.m_mthFindRecipeFreq(m_strFindText,out m_objFREQTable);
            if (lngRes > 0 && m_objFREQTable.Rows.Count > 0)
            {
                if (m_objFREQTable.Rows.Count == 1)
                {
                    this.m_objViewer.m_txtDefaultFreq.Text = m_objFREQTable.Rows[0]["freqname_chr"].ToString().Trim();
                    this.m_objViewer.m_txtDefaultFreq.Tag = m_objFREQTable.Rows[0]["freqid_chr"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    return 0;
                }
                else
                {
                    this.m_objViewer.lsvDefaultFreq.Items.Clear();
                    for (int i = 0; i < m_objFREQTable.Rows.Count; i++)
                    {
                        ListViewItem m_objItem = new ListViewItem(m_objFREQTable.Rows[i]["freqid_chr"].ToString().Trim());
                        m_objItem.SubItems.Add(m_objFREQTable.Rows[i]["usercode_chr"].ToString().Trim());
                        m_objItem.SubItems.Add(m_objFREQTable.Rows[i]["freqname_chr"].ToString().Trim());
                        m_objViewer.lsvDefaultFreq.Items.Add(m_objItem);
                    }
                    return 1;

                }
            }
            else
            {
                this.m_objViewer.m_txtDefaultFreq.Text = "";
                MessageBox.Show(this.m_objViewer, "找不到相应的默认频率！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.m_objViewer.m_txtDefaultFreq.Focus();
                return -1;
            }
        }
        public int m_mthFindExeType(string m_strFindText)
        {
            long lngRes = -1;
            DataTable m_objExeTypeTable = new DataTable();
            lngRes = objSvc.m_mthFindExeType(m_strFindText, out m_objExeTypeTable);
            if (lngRes > 0 && m_objExeTypeTable.Rows.Count > 0)
            {
                if (m_objExeTypeTable.Rows.Count == 1)
                {
                    this.m_objViewer.m_txtExeType.Text = m_objExeTypeTable.Rows[0]["ordercatename_vchr"].ToString().Trim();
                    this.m_objViewer.m_txtExeType.Tag = m_objExeTypeTable.Rows[0]["ORDERCATEID_CHR"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    return 0;
                }
                else
                {
                    this.m_objViewer.m_lsvExeType.Items.Clear();
                    for (int i = 0; i < m_objExeTypeTable.Rows.Count; i++)
                    {
                        ListViewItem m_objItem = new ListViewItem(m_objExeTypeTable.Rows[i]["ORDERCATEID_CHR"].ToString().Trim());
                        m_objItem.SubItems.Add(m_objExeTypeTable.Rows[i]["ordercatename_vchr"].ToString().Trim());
                        m_objViewer.m_lsvExeType.Items.Add(m_objItem);
                    }
                    return 1;

                }
            }
            else
            {
                this.m_objViewer.m_txtExeType.Text = "";
                MessageBox.Show(this.m_objViewer, "找不到相应的执行分类！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.m_objViewer.m_txtExeType.Focus();
                return -1;
            }
        }
        public int m_mthFindOrderCateType(string m_strFindText)
        {
            long lngRes = -1;
            DataTable m_objOrderCateTypeTable = new DataTable();
            lngRes = objSvc.m_mthFindOrderType(m_strFindText, out m_objOrderCateTypeTable);
            if (lngRes > 0 && m_objOrderCateTypeTable.Rows.Count > 0)
            {
                if (m_objOrderCateTypeTable.Rows.Count == 1)
                {
                    this.m_objViewer.m_txtOrderCateType.Text = m_objOrderCateTypeTable.Rows[0]["name_chr"].ToString().Trim();
                    this.m_objViewer.m_txtOrderCateType.Tag = m_objOrderCateTypeTable.Rows[0]["ordercateid_chr"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    return 0;
                }
                else
                {
                    this.m_objViewer.m_lsvOrderType.Items.Clear();
                    for (int i = 0; i < m_objOrderCateTypeTable.Rows.Count; i++)
                    {
                        ListViewItem m_objItem = new ListViewItem(m_objOrderCateTypeTable.Rows[i]["ordercateid_chr"].ToString().Trim());
                        m_objItem.SubItems.Add(m_objOrderCateTypeTable.Rows[i]["name_chr"].ToString().Trim());
                        m_objViewer.m_lsvOrderType.Items.Add(m_objItem);
                    }
                    return 1;

                }
            }
            else
            {
                this.m_objViewer.m_txtOrderCateType.Text = "";
                MessageBox.Show(this.m_objViewer, "找不到相应的医嘱类型！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                this.m_objViewer.m_txtOrderCateType.Focus();
                return -1;
            }
        }
        public void m_mthFillExeType()
        {

            this.m_objViewer.m_txtExeType.Tag = this.m_objViewer.m_lsvExeType.SelectedItems[0].Text.Trim(); ;
            this.m_objViewer.m_txtExeType.Text = this.m_objViewer.m_lsvExeType.SelectedItems[0].SubItems[1].Text.Trim();
            this.m_objViewer.m_txtOrderCateType.Focus();
        }
        public void m_mthFillOrderCateType()
        {

            this.m_objViewer.m_txtOrderCateType.Tag = this.m_objViewer.m_lsvOrderType.SelectedItems[0].Text.Trim(); ;
            this.m_objViewer.m_txtOrderCateType.Text = this.m_objViewer.m_lsvOrderType.SelectedItems[0].SubItems[1].Text.Trim();
            this.m_objViewer.m_cboKeepUse.Focus();
        }
        public void m_mthFillDefaultFreq()
        { 
            
            this.m_objViewer.m_txtDefaultFreq.Tag = this.m_objViewer.lsvDefaultFreq.SelectedItems[0].Text.Trim(); ;
            this.m_objViewer.m_txtDefaultFreq.Text = this.m_objViewer.lsvDefaultFreq.SelectedItems[0].SubItems[2].Text.Trim();
            this.m_objViewer.m_cboUsage.Focus();
        }
        private void m_FillUsage()
		{
			clsUsageType_VO[] objResult;
			long lngRes=objSvc.m_mthGetUsage(out objResult,"");
			if(lngRes>0 && objResult.Length>0)
			{
				for(int i1=0;i1<objResult.Length;i1++)
				{
					m_objViewer.m_cboUsage.Item.Add(objResult[i1].m_strUsageName,objResult[i1].m_strUsageID);
				}
			}
		}
		
        //private void m_FillExType()
        //{
        //    clsChargeItemEXType_VO[] objResult;
        //    long lngRes=objSvc.m_mthEXType("1",out objResult); //门诊核算
        //    if(lngRes>0 && objResult.Length>0)
        //    {
        //        for(int i1=0;i1<objResult.Length;i1++)
        //        {
        //            m_objViewer.m_cboOPCal.Item.Add(objResult[i1].m_strTypeName,objResult[i1].m_strTypeID);

        //        }
        //    }

        //    lngRes=objSvc.m_mthEXType("2",out objResult); //门诊发票
        //    if(lngRes>0 && objResult.Length>0)
        //    {
        //        for(int i1=0;i1<objResult.Length;i1++)
        //        {
        //            m_objViewer.m_cboOPInv.Item.Add(objResult[i1].m_strTypeName,objResult[i1].m_strTypeID);

        //        }
        //    }
        //    lngRes=objSvc.m_mthEXType("3",out objResult); //住院核算
        //    if(lngRes>0 && objResult.Length>0)
        //    {
        //        for(int i1=0;i1<objResult.Length;i1++)
        //        {
        //            m_objViewer.m_cboIPCal.Item.Add(objResult[i1].m_strTypeName,objResult[i1].m_strTypeID);
        //        }
        //    }
        //    lngRes=objSvc.m_mthEXType("4",out objResult); //住院发票
        //    if(lngRes>0 && objResult.Length>0)
        //    {
        //        for(int i1=0;i1<objResult.Length;i1++)
        //        {
        //            m_objViewer.m_cboIPInv.Item.Add(objResult[i1].m_strTypeName,objResult[i1].m_strTypeID);
        //        }
        //    }
        //    lngRes=objSvc.m_mthEXType("5",out objResult); //住院发票
        //    if(lngRes>0 && objResult.Length>0)
        //    {
        //        for(int i1=0;i1<objResult.Length;i1++)
        //        {
        //            m_objViewer.m_cboCase.Item.Add(objResult[i1].m_strTypeName,objResult[i1].m_strTypeID);
        //        }
        //    }
        //}
		#endregion
		#region 清空
		public void m_Clear()
		{
			m_objViewer.COBINSURANCETYPE.Clear();
			m_objViewer.m_cboDosUnit.Clear();
			m_objViewer.m_txtIPCal.Clear();
			m_objViewer.m_txtIPInvoice.Clear();
			m_objViewer.m_cboIPUnit.Clear();
			m_objViewer.m_txtOPCal.Clear();
            m_objViewer.m_txtOPInvoice.Clear();
			m_objViewer.m_cboOPUnit.Clear();
			m_objViewer.m_cboUnit.Clear();
			m_objViewer.m_cboUsage.Clear();
			m_objViewer.m_txtDosage.Clear();
			m_objViewer.m_txtName.Clear();
			m_objViewer.m_txtNo.Clear();
			m_objViewer.m_txtPrice.Clear();
			m_objViewer.m_txtPY.Clear();
			m_objViewer.m_txtSourName.Clear();
			m_objViewer.m_txtSpec.Clear();
			m_objViewer.m_txtWB.Clear();
			m_objViewer.m_txtchargeNO.Clear();
			m_objViewer.m_txtFind.Text="";
			m_objViewer.m_txtInsuranceID.Clear();
			m_objViewer.m_txtPacQ.Clear();
			m_objViewer.m_txtTradePrice.Clear();
			m_objViewer.txtEnglishName.Clear();
            m_objViewer.txtCommName.Clear();
            m_objViewer.m_cmbSelf.SelectedIndex = -1;
            m_objViewer.cboInpInsuranceType.Clear();
            if (m_objViewer.cmbIsStop.Items.Count > 0)
            {
                m_objViewer.cmbIsStop.SelectedIndex = 0;
            }
            //if (m_objViewer.ORDERCATENAME.Items.Count > 0)
            //{
            //    m_objViewer.ORDERCATENAME.SelectedIndex = 0;
            //}
			m_objViewer.txtProduceing.Clear();
            if (m_objViewer.m_cmbIPUseUint.Items.Count > 0)
            {
                m_objViewer.m_cmbIPUseUint.SelectedIndex = 0;
            }
            if (this.m_objViewer.m_cmbSelf.Items.Count > 0)
            {
                m_objViewer.m_cmbSelf.SelectedIndex = 0;
            }
            m_objViewer.m_cboKeepUse.SelectedIndex = 1;
            m_objViewer.m_txtDefaultFreq.Tag = null;
            m_objViewer.m_txtDefaultFreq.Text = "";
          //  m_objViewer.cboOrderCate.Clear();
            m_objViewer.m_txtOrderCateType.Clear();
            m_objViewer.m_txtExeType.Clear();
            m_objViewer.cboSfcl.SelectedIndex = 0;
		}
		#endregion
		#region DataGridCellChange事件
		public void m_mthDataGridCellChange()
		{
				int index =this.m_objViewer.dataGrid1.CurrentRowIndex;
				this.m_objViewer.btSave.Tag=dt.Rows[index]["ITEMID_CHR"].ToString().Trim();
				this.m_objViewer.m_txtName.Text=dt.Rows[index]["ITEMNAME_VCHR"].ToString().Trim();
				this.m_objViewer.txtEnglishName.Text=dt.Rows[index]["ITEMENGNAME_VCHR"].ToString().Trim();
                this.m_objViewer.txtCommName.Text = dt.Rows[index]["ITEMCOMMNAME_VCHR"].ToString().Trim();
				this.m_objViewer.m_txtNo.Text=dt.Rows[index]["ITEMCODE_VCHR"].ToString().Trim();
				this.m_objViewer.m_txtPY.Text=dt.Rows[index]["ITEMPYCODE_CHR"].ToString().Trim();
				this.m_objViewer.m_txtWB.Text=dt.Rows[index]["ITEMWBCODE_CHR"].ToString().Trim();
				this.m_objViewer.m_txtSpec.Text=dt.Rows[index]["ITEMSPEC_VCHR"].ToString().Trim();
				this.m_objViewer.m_txtPrice.Text=dt.Rows[index]["ITEMPRICE_MNY"].ToString().Trim();
			    this.m_objViewer.m_txtPrice.Tag=dt.Rows[index]["ITEMPRICE_MNY"].ToString().Trim();
				this.m_objViewer.m_cboUnit.Text=dt.Rows[index]["ITEMUNIT_CHR"].ToString().Trim();
				this.m_objViewer.m_cboOPUnit.Text=dt.Rows[index]["ITEMOPUNIT_CHR"].ToString().Trim();
				this.m_objViewer.m_cboIPUnit.Text=dt.Rows[index]["ITEMIPUNIT_CHR"].ToString().Trim();
				this.m_objViewer.COBINSURANCETYPE.FindKey(dt.Rows[index]["INSURANCETYPE_VCHR"].ToString().Trim());
                this.m_objViewer.cboInpInsuranceType.FindKey(dt.Rows[index]["INPINSURANCETYPE_VCHR"].ToString().Trim());

                this.m_objViewer.m_txtOPCal.Text = dt.Rows[index]["TYPENAME_VCHR"].ToString().Trim();
                this.m_objViewer.m_txtOPCal.Tag = dt.Rows[index]["ITEMOPCALCTYPE_CHR"].ToString().Trim();
                this.m_objViewer.m_txtOPInvoice.Text = dt.Rows[index]["TYPENAME_VCHR2"].ToString().Trim();
                this.m_objViewer.m_txtOPInvoice.Tag = dt.Rows[index]["ITEMOPINVTYPE_CHR"].ToString().Trim();
                this.m_objViewer.m_txtIPCal.Text = dt.Rows[index]["TYPENAME_VCHR1"].ToString().Trim();
                this.m_objViewer.m_txtIPCal.Tag = dt.Rows[index]["ITEMIPCALCTYPE_CHR"].ToString().Trim();
                this.m_objViewer.m_txtIPInvoice.Text = dt.Rows[index]["TYPENAME_VCHR3"].ToString().Trim();
                this.m_objViewer.m_txtIPInvoice.Tag = dt.Rows[index]["ITEMIPINVTYPE_CHR"].ToString().Trim();
                this.m_objViewer.m_txtCaseCal.Text = dt.Rows[index]["TYPENAME_VCHR4"].ToString().Trim();
                this.m_objViewer.m_txtCaseCal.Tag = dt.Rows[index]["ITEMBIHCTYPE_CHR"].ToString().Trim();

                //this.m_objViewer.m_cboOPCal.FindKey(dt.Rows[index]["ITEMOPCALCTYPE_CHR"].ToString().Trim());
                //this.m_objViewer.m_cboIPCal.FindKey(dt.Rows[index]["ITEMIPCALCTYPE_CHR"].ToString().Trim());
                //this.m_objViewer.m_cboOPInv.FindKey(dt.Rows[index]["ITEMOPINVTYPE_CHR"].ToString().Trim());
                //this.m_objViewer.m_cboIPInv.FindKey(dt.Rows[index]["ITEMIPINVTYPE_CHR"].ToString().Trim());
                //this.m_objViewer.m_cboCase.FindKey(dt.Rows[index]["ITEMBIHCTYPE_CHR"].ToString().Trim());
				this.m_objViewer.m_cboApplyType.FindKey(dt.Rows[index]["APPLY_TYPE_INT"].ToString().Trim());
				this.m_objViewer.cmbCheckPart.FindKey(dt.Rows[index]["ITEMCHECKTYPE_CHR"].ToString().Trim());
				this.m_objViewer.m_cboUsage.FindKey(dt.Rows[index]["USAGEID_CHR"].ToString().Trim());
				this.m_objViewer.m_txtchargeNO.Text=dt.Rows[index]["ITEMOPCODE_CHR"].ToString().Trim();
				this.m_objViewer.m_txtDosage.Text=dt.Rows[index]["DOSAGE_DEC"].ToString().Trim();
				this.m_objViewer.m_cboDosUnit.Text=dt.Rows[index]["DOSAGEUNIT_CHR"].ToString().Trim();
				this.m_objViewer.m_txtPacQ.Text=dt.Rows[index]["PACKQTY_DEC"].ToString();
				this.m_objViewer.m_cmbCoustomPrice.SelectedIndex=m_mthGetIndex(dt.Rows[index]["SELFDEFINE_INT"]);
                if (dt.Rows[index]["ISSELFPAY_CHR"].ToString() == "T")
                {
                    this.m_objViewer.m_cmbSelf.SelectedIndex = 1;
                }
                else
                {
                    this.m_objViewer.m_cmbSelf.SelectedIndex = 0;
                }
				this.m_objViewer.m_cmbIsExpensive.SelectedIndex=m_mthGetIndex(dt.Rows[index]["ISRICH_INT"]);
				this.m_objViewer.m_cmbOPUseUint.SelectedIndex=m_mthGetIndex(dt.Rows[index]["OPCHARGEFLG_INT"]);
				this.m_objViewer.m_txtInsuranceID.Text=dt.Rows[index]["INSURANCEID_CHR"].ToString().Trim();
				this.m_objViewer.m_txtSourName.Text=dt.Rows[index]["ITEMSRCNAME_VCHR"].ToString().Trim();
				this.m_objViewer.m_txtSour.Text=dt.Rows[index]["ITEMSRCTYPENAME_VCHR"].ToString().Trim();
				this.m_objViewer.m_cmbIsInDocAdv.SelectedIndex=m_mthGetIndex(dt.Rows[index]["POFLAG_INT"]);
				this.m_objViewer.cmbIsStop.SelectedIndex=m_mthGetIndex(dt.Rows[index]["IFSTOP_INT"]);
				this.m_objViewer.m_txtTradePrice.Text=dt.Rows[index]["TRADEPRICE_MNY"].ToString();
				this.m_objViewer.txtProduceing.Text =dt.Rows[index]["PDCAREA_VCHR"].ToString();//产地
				this.m_objViewer.m_cmbIPUseUint.SelectedIndex=m_mthGetIndex(dt.Rows[index]["IPCHARGEFLG_INT"]);
               // this.m_objViewer.ORDERCATENAME.FindKey(dt.Rows[index]["ORDERCATEID_CHR"].ToString().Trim());
               // this.m_objViewer.cboOrderCate.FindKey(dt.Rows[index]["ORDERCATEID1_CHR"].ToString().Trim());
                this.m_objViewer.m_txtExeType.Text=dt.Rows[index]["ordercatename_vchr"].ToString().Trim();
                this.m_objViewer.m_txtExeType.Tag = dt.Rows[index]["ORDERCATEID_CHR"].ToString().Trim();
                this.m_objViewer.m_txtOrderCateType.Text = dt.Rows[index]["name_chr"].ToString().Trim();
                this.m_objViewer.m_txtOrderCateType.Tag = dt.Rows[index]["ORDERCATEID1_CHR"].ToString().Trim();
                this.m_objViewer.m_txtDefaultFreq.Tag = dt.Rows[index]["FREQID_CHR"].ToString().Trim();
                this.m_objViewer.m_txtDefaultFreq.Text = dt.Rows[index]["FREQNAME_CHR"].ToString().Trim();
				if(dt.Rows[index]["hype_int"].ToString().Trim()=="1")
				{
					this.m_objViewer.lbePS.Text ="皮试";
				}
				else
				{
				this.m_objViewer.lbePS.Text ="";
				}
				this.m_objViewer.dataGrid1.Select(this.m_objViewer.dataGrid1.CurrentRowIndex);
                this.m_objViewer.m_cboKeepUse.SelectedIndex = int.Parse(dt.Rows[index]["KEEPUSE_INT"].ToString().Trim());

                if (dt.Rows[index]["ischargemate"] == DBNull.Value)
                {
                    this.m_objViewer.cboSfcl.SelectedIndex = 0;
                }
                else
                {
                    this.m_objViewer.cboSfcl.SelectedIndex = Convert.ToInt32(dt.Rows[index]["ischargemate"]);
                }

		}
		private int m_mthGetIndex(object str)
		{
			try
			{
				if(str!=null&&str.ToString().Trim()!="")
				{
					return Convert.ToInt32(str.ToString().Trim());
				}
				else
				{
					return 0;
				}
			}
			catch
			{
			return 0;
			}
		}
		#endregion
		#region 计算价格
		public void m_mthCalPrice()
		{
			if(this.m_objViewer.m_cmbOPUseUint.SelectedIndex==0)
			{
				if(this.m_objViewer.m_txtPrice.Text.Trim()!=""&&this.m_objViewer.m_txtPrice.Text.Trim()!=".")		 
				{
					this.m_objViewer.lbePrice.Text=decimal.Parse(this.m_objViewer.m_txtPrice.Text).ToString("0.0000");
				}
				
			}
			else
			{
				decimal count =1;
				if(this.m_objViewer.m_txtPacQ.Text.Trim()!=""&&this.m_objViewer.m_txtPacQ.Text.Trim()!=".")
				{
				count =decimal.Parse(this.m_objViewer.m_txtPacQ.Text.Trim());
					if(count==0)
					{
					count=1;
					}
				}
				decimal price =0;
				if(this.m_objViewer.m_txtPrice.Text.Trim()!=""&&this.m_objViewer.m_txtPrice.Text.Trim()!=".")
				{
					price =decimal.Parse(this.m_objViewer.m_txtPrice.Text.Trim());
				}
			this.m_objViewer.lbePrice.Text=((decimal)(price/count)).ToString("0.0000");
			}

			if(this.m_objViewer.m_cmbIPUseUint.SelectedIndex==0)
			{
				if(this.m_objViewer.m_txtPrice.Text.Trim()!=""&&this.m_objViewer.m_txtPrice.Text.Trim()!=".")		 
				{
					this.m_objViewer.lbeIPPrice.Text=decimal.Parse(this.m_objViewer.m_txtPrice.Text).ToString("0.0000");
				}
				
			}
			else
			{
				decimal count =1;
				if(this.m_objViewer.m_txtPacQ.Text.Trim()!=""&&this.m_objViewer.m_txtPacQ.Text.Trim()!=".")
				{
					count =decimal.Parse(this.m_objViewer.m_txtPacQ.Text.Trim());
					if(count==0)
					{
						count=1;
					}
				}
				decimal price =0;
				if(this.m_objViewer.m_txtPrice.Text.Trim()!=""&&this.m_objViewer.m_txtPrice.Text.Trim()!=".")
				{
					price =decimal.Parse(this.m_objViewer.m_txtPrice.Text.Trim());
				}
				this.m_objViewer.lbeIPPrice.Text=((decimal)(price/count)).ToString("0.0000");
			}
		}
		#endregion
		#region 保存
		public void m_mthSave()
		{
			#region 判断能否保存
			if(this.m_objViewer.m_txtNo.Text.Trim()=="")
			{
			MessageBox.Show("项目编号不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			this.m_objViewer.m_txtNo.Select();
			return;
			}
			if(this.m_objViewer.m_txtName.Text.Trim()=="")
			{
				MessageBox.Show("项目名称不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.m_objViewer.m_txtName.Select();
				return;
			}
			if(this.m_objViewer.m_txtPacQ.Text.Trim()=="")
			{
				MessageBox.Show("包装量不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.m_objViewer.m_txtPacQ.Select();
				return;
			}
			if(this.m_objViewer.m_txtDosage.Text.Trim()=="")
			{
				MessageBox.Show("基本用量不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.m_objViewer.m_txtDosage.Select();
				return;
			}
			if(this.m_objViewer.m_txtPrice.Text.Trim()=="")
			{
				MessageBox.Show("价格不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.m_objViewer.m_txtPrice.Select();
				return;
			}
			if(this.m_objViewer.m_txtTradePrice.Text.Trim()=="")
			{
				MessageBox.Show("批发价不能为空！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
				this.m_objViewer.m_txtTradePrice.Select();
				return;
			}
            if (this.m_objViewer.m_txtOPCal.Text.Trim() == "")
            {
                MessageBox.Show("门诊核算类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtOPCal.Focus();
                return;
            }
            if (this.m_objViewer.m_txtOPInvoice.Text.Trim() == "")
            {
                MessageBox.Show("住院核算类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtOPInvoice.Focus();
                return;
            }
            if (this.m_objViewer.m_txtOrderCateType.Text.Trim() == "")
            {
                MessageBox.Show("医嘱类型不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtOrderCateType.Focus();
               // this.m_objViewer.cboOrderCate.DroppedDown = true; ;
                return;
            }
            if (this.m_objViewer.m_txtIPCal.Text.Trim() == "")
            {
                MessageBox.Show("门诊发票类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtIPCal.Focus();
                return;

            }
            if (this.m_objViewer.m_txtIPInvoice.Text.Trim() == "")
            {
                MessageBox.Show("住院发票类别不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtIPInvoice.Focus();
                return;
            }
            if (this.m_objViewer.m_txtDefaultFreq.Text.ToString().Trim() == "")
            {
                MessageBox.Show("默认频率不能为空！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtDefaultFreq.Focus();
                return;
            }
			#endregion
			clsChargeItem_VO clsVO;
			long lngRes=0;
			string strID;
			this.m_mthGetData(out clsVO);
			if(this.m_objViewer.btSave.Tag!=null)//修改
			{
				if(objSvc.m_mthItemIsUsed(this.m_objViewer.m_txtNo.Text,this.m_objViewer.btSave.Tag.ToString())>0)
				{
					if(MessageBox.Show("编号已被占用,是否继续?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
					{
						this.m_objViewer.m_txtNo.Focus();
						return;
					}
				}
				lngRes=objSvc.m_mthDoUpdChargeItem(clsVO,this.m_objViewer.LoginInfo.m_strEmpID);
				if(lngRes>0)
				{
					this.m_mthUpdateDataTable(this.m_objViewer.dataGrid1.CurrentRowIndex);

                    updateOrderDic(clsVO);
				}
				//在这里添加更新代码
			}
			else//新增
			{
				if(objSvc.m_mthItemIsUsed(this.m_objViewer.m_txtNo.Text,"")>0)
				{
					if(MessageBox.Show("编号已被占用,是否继续?","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.No)
					{
						this.m_objViewer.m_txtNo.Focus();
						return;
					}
				}
				lngRes=objSvc.m_mthDoAddNewChargeItem(clsVO,out strID);
				
				if(lngRes>0)
				{
					this.dt.Rows.Add(new object[]{""} );
					this.m_objViewer.btSave.Tag=strID;
					int index=dt.Rows.Count-1;
					this.dt.Rows[index]["ITEMID_CHR"]=strID;
					this.m_mthUpdateDataTable(index);
					this.m_objViewer.dataGrid1.CurrentCell=new DataGridCell(index,0);
				}
				//在这里添加代码

			}
		
			if(lngRes>0)
			{
				MessageBox.Show("保存成功！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				MessageBox.Show("对不起,保存失败！","提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}

        //更新诊疗项目
        private void updateOrderDic(clsChargeItem_VO clsVO)
        {
            objSvc.m_lngUpdateOrderDicByChargeItemId(clsVO);
        }
		/// <summary>
		/// 收集数据信息
		/// </summary>
		/// <param name="clsVO"></param>
		private void m_mthGetData(out clsChargeItem_VO clsVO)
		{
			clsVO=new clsChargeItem_VO();
			clsVO.m_DosageUnit=new clsUnit_VO();
			clsVO.m_DosageUnit.m_strUnitID=m_objViewer.m_cboDosUnit.Text;
			if(m_objViewer.m_txtPrice.Text.Trim()!="")
			{
			clsVO.m_fltItemPrice=float.Parse(m_objViewer.m_txtPrice.Text);
			}
			try
			{
				clsVO.m_fltPrePrice=float.Parse(m_objViewer.m_txtPrice.Tag.ToString());
			}
			catch
			{
				clsVO.m_fltPrePrice=0;
			}
            if (this.m_objViewer.m_txtExeType.Text.Trim()!=string.Empty)
            {
                clsVO.m_strORDERCATEID = this.m_objViewer.m_txtExeType.Tag.ToString();
            }
            else
            {
                clsVO.m_strORDERCATEID = "";
            }
            clsVO.m_strORDERCATENAME = this.m_objViewer.m_txtExeType.Text.Trim();
			clsVO.m_strINSURANCETYPE=this.m_objViewer.COBINSURANCETYPE.SelectItemValue;
            clsVO.m_strINPINSURANCETYPE = this.m_objViewer.cboInpInsuranceType.SelectItemValue;
			clsVO.m_ItemCat=new clsCharegeItemCat_VO();
			clsVO.m_ItemCat.m_strItemCatID=this.m_objViewer.m_cmbType.SelectItemValue.Trim();
			clsVO.m_ItemIPCalcType=new clsChargeItemEXType_VO();
			clsVO.m_ItemIPCalcType.m_strTypeID=m_objViewer.m_txtIPCal.Tag.ToString();
			clsVO.m_ItemIPInvType=new clsChargeItemEXType_VO();
			clsVO.m_ItemIPInvType.m_strTypeID=m_objViewer.m_txtIPInvoice.Tag.ToString();
			clsVO.m_ItemIPUnit=new clsUnit_VO();
			clsVO.m_ItemIPUnit.m_strUnitID=m_objViewer.m_cboIPUnit.Text;
			clsVO.m_ItemOPCalcType=new clsChargeItemEXType_VO();
			clsVO.m_ItemOPCalcType.m_strTypeID=m_objViewer.m_txtOPCal.Tag.ToString();
			clsVO.m_strAPPLY_TYPE_INT=m_objViewer.m_cboApplyType.SelectItemValue;
			clsVO.m_strITEMBIHCTYPE_CHR=m_objViewer.m_txtCaseCal.Tag.ToString();
			clsVO.strCheckPartID=m_objViewer.cmbCheckPart.SelectItemValue;
			clsVO.m_ItemOPInvType=new clsChargeItemEXType_VO();
			clsVO.m_ItemOPInvType.m_strTypeID=m_objViewer.m_txtOPInvoice.Tag.ToString();
			clsVO.m_ItemOPUnit=new clsUnit_VO();
			clsVO.m_ItemOPUnit.m_strUnitID=m_objViewer.m_cboOPUnit.Text;
			clsVO.m_ItemUnit=new clsUnit_VO();
			clsVO.m_ItemUnit.m_strUnitID=m_objViewer.m_cboUnit.Text;
			clsVO.m_ItemUnit.m_strUnitName=m_objViewer.m_cboUnit.Text;
			if(m_objViewer.m_txtDosage.Text!="")
				clsVO.m_strDosage=float.Parse(m_objViewer.m_txtDosage.Text);
			clsVO.m_strItemCode=m_objViewer.m_txtNo.Text;
			clsVO.m_strProducing=m_objViewer.txtProduceing.Text;
			clsVO.m_strItemName=m_objViewer.m_txtName.Text;
			clsVO.m_strItemPYCode=m_objViewer.m_txtPY.Text;
			clsVO.m_strItemSpec=m_objViewer.m_txtSpec.Text;
			clsVO.m_strItemWBCode=m_objViewer.m_txtWB.Text;
			clsVO.m_Usage=new clsUsageType_VO();
			clsVO.m_Usage.m_strUsageID=m_objViewer.m_cboUsage.SelectItemValue;
			if(this.m_objViewer.btSave.Tag!=null)
			{
				clsVO.m_strItemID=this.m_objViewer.btSave.Tag.ToString();
			}
			clsVO.m_strITEMOPCODE_CHR=m_objViewer.m_txtchargeNO.Text.Trim();
			clsVO.m_strINSURANCEID_CHR=m_objViewer.m_txtInsuranceID.Text.Trim();
			try
			{
				if(m_objViewer.m_txtPacQ.Text.Trim()==""||m_objViewer.m_txtPacQ.Text.Trim()=="0")
				{
				m_objViewer.m_txtPacQ.Text="1";
				}

				clsVO.m_decPACKQTY_DEC=decimal.Parse(m_objViewer.m_txtPacQ.Text.Trim());
			}
			catch
			{
				clsVO.m_decPACKQTY_DEC=1;
			}
			
			clsVO.m_intSELFDEFINE_INT=int.Parse(m_objViewer.m_cmbCoustomPrice.Tag.ToString());
			clsVO.m_intPOFLAG_INT=int.Parse(m_objViewer.m_cmbIsInDocAdv.Tag.ToString());
			clsVO.m_intISRICH_INT=int.Parse(m_objViewer.m_cmbIsExpensive.Tag.ToString());
            if (m_objViewer.m_cmbSelf.Text == "是")
            {
                clsVO.m_strISSELFPAY_CHR = "T";
            }
            else
            {
                clsVO.m_strISSELFPAY_CHR = "F";
            }
			clsVO.m_intOPCHARGEFLG_INT=int.Parse(m_objViewer.m_cmbOPUseUint.Tag.ToString());
			clsVO.m_intIPCHARGEFLG_INT=int.Parse(m_objViewer.m_cmbIPUseUint.Tag.ToString());
			if(m_objViewer.m_txtTradePrice.Text.Trim()!="")
			{
				clsVO.m_fltTradePrice=float.Parse(m_objViewer.m_txtTradePrice.Text);
			}
			clsVO.m_strEnglishName=this.m_objViewer.txtEnglishName.Text;
			if(this.m_objViewer.cmbIsStop.Tag!=null)
			{
				clsVO.m_intStopFlag=int.Parse(this.m_objViewer.cmbIsStop.Tag.ToString());
			}
			else
			{
			    clsVO.m_intStopFlag=0;
			}
            clsVO.m_strCommName = this.m_objViewer.txtCommName.Text.Trim();
            
            clsVO.m_strDefaultFreq = this.m_objViewer.m_txtDefaultFreq.Tag.ToString().Trim();
            clsVO.m_strOrderCateID = this.m_objViewer.m_txtOrderCateType.Tag.ToString();
            clsVO.m_intKeepUse = this.m_objViewer.m_cboKeepUse.SelectedIndex;
            clsVO.isChargeMate = this.m_objViewer.cboSfcl.SelectedIndex;
		}

		private void m_mthUpdateDataTable(int index)
		{
//			int index =this.m_objViewer.dataGrid1.CurrentRowIndex;
//			this.m_objViewer.btSave.Tag=dt.Rows[index]["ITEMID_CHR"].ToString().Trim();
	        dt.Rows[index]["ITEMNAME_VCHR"]=this.m_objViewer.m_txtName.Text;
	        dt.Rows[index]["ITEMCODE_VCHR"]=this.m_objViewer.m_txtNo.Text;
	        dt.Rows[index]["ITEMPYCODE_CHR"]=this.m_objViewer.m_txtPY.Text;
	        dt.Rows[index]["ITEMWBCODE_CHR"]=this.m_objViewer.m_txtWB.Text;
	        dt.Rows[index]["ITEMSPEC_VCHR"]=this.m_objViewer.m_txtSpec.Text;
			if(this.m_objViewer.m_txtPrice.Text.Trim()=="")
			{
				dt.Rows[index]["ITEMPRICE_MNY"]="0";
				this.m_objViewer.m_txtPrice.Tag ="0";
			}
			else
			{
				dt.Rows[index]["ITEMPRICE_MNY"]=this.m_objViewer.m_txtPrice.Text;
				this.m_objViewer.m_txtPrice.Tag =this.m_objViewer.m_txtPrice.Text;
			}
        //	dt.Rows[index]["ITEMPRICE_MNY"]=this.m_objViewer.m_txtPrice.Text;
	        dt.Rows[index]["ITEMUNIT_CHR"]=this.m_objViewer.m_cboUnit.Text;
	        dt.Rows[index]["ITEMOPUNIT_CHR"]=	this.m_objViewer.m_cboOPUnit.Text;
	        dt.Rows[index]["ITEMIPUNIT_CHR"]=this.m_objViewer.m_cboIPUnit.Text;
	        dt.Rows[index]["ITEMOPCALCTYPE_CHR"]=this.m_objViewer.m_txtOPCal.Tag;
		    dt.Rows[index]["INSURANCETYPE_VCHR"]=this.m_objViewer.COBINSURANCETYPE.SelectItemValue;
            dt.Rows[index]["INPINSURANCETYPE_VCHR"] = this.m_objViewer.cboInpInsuranceType.SelectItemValue;
	        dt.Rows[index]["ITEMIPCALCTYPE_CHR"]=this.m_objViewer.m_txtIPCal.Tag;
	        dt.Rows[index]["ITEMOPINVTYPE_CHR"]=this.m_objViewer.m_txtOPInvoice.Tag;
	        dt.Rows[index]["ITEMIPINVTYPE_CHR"]=this.m_objViewer.m_txtIPInvoice.Tag;
	        dt.Rows[index]["ITEMBIHCTYPE_CHR"]=this.m_objViewer.m_txtCaseCal.Tag;
            dt.Rows[index]["TYPENAME_VCHR"] = this.m_objViewer.m_txtOPCal.Text;
            dt.Rows[index]["TYPENAME_VCHR2"] = this.m_objViewer.m_txtOPInvoice.Text;
            dt.Rows[index]["TYPENAME_VCHR1"] = this.m_objViewer.m_txtIPCal.Text;
            dt.Rows[index]["TYPENAME_VCHR3"] = this.m_objViewer.m_txtIPInvoice.Text;
            dt.Rows[index]["TYPENAME_VCHR4"] = this.m_objViewer.m_txtCaseCal.Text;
	        if(this.m_objViewer.m_cboApplyType.SelectItemValue.Trim()!="")
	        dt.Rows[index]["APPLY_TYPE_INT"]=this.m_objViewer.m_cboApplyType.SelectItemValue;
	        dt.Rows[index]["ITEMCHECKTYPE_CHR"]=this.m_objViewer.cmbCheckPart.SelectItemValue;
	        dt.Rows[index]["USAGEID_CHR"]=this.m_objViewer.m_cboUsage.SelectItemValue;
	        dt.Rows[index]["ITEMOPCODE_CHR"]=this.m_objViewer.m_txtchargeNO.Text;
	        dt.Rows[index]["DOSAGE_DEC"]=this.m_objViewer.m_txtDosage.Text;
	        dt.Rows[index]["DOSAGEUNIT_CHR"]=this.m_objViewer.m_cboDosUnit.Text;
	        dt.Rows[index]["PACKQTY_DEC"]=this.m_objViewer.m_txtPacQ.Text;
	        dt.Rows[index]["SELFDEFINE_INT"]=this.m_objViewer.m_cmbCoustomPrice.Tag.ToString();
	        dt.Rows[index]["ISRICH_INT"]=this.m_objViewer.m_cmbIsExpensive.Tag.ToString();
	        dt.Rows[index]["OPCHARGEFLG_INT"]=this.m_objViewer.m_cmbOPUseUint.Tag.ToString();
	        dt.Rows[index]["POFLAG_INT"]=this.m_objViewer.m_cmbIsInDocAdv.Tag.ToString();
            if (this.m_objViewer.m_cmbSelf.Text == "是")
            {
                dt.Rows[index]["ISSELFPAY_CHR"] = "T";
            }
            else
            {
                dt.Rows[index]["ISSELFPAY_CHR"] = "F";
            }
	        dt.Rows[index]["INSURANCEID_CHR"]=this.m_objViewer.m_txtInsuranceID.Text;
	        dt.Rows[index]["ITEMSRCNAME_VCHR"]=this.m_objViewer.m_txtSourName.Text;
	        dt.Rows[index]["ITEMSRCTYPENAME_VCHR"]=this.m_objViewer.m_txtSour.Text;
	        dt.Rows[index]["ITEMENGNAME_VCHR"]=this.m_objViewer.txtEnglishName.Text.Trim();
	        dt.Rows[index]["IFSTOP_INT"]=this.m_objViewer.cmbIsStop.Tag.ToString().Trim();
	        dt.Rows[index]["PDCAREA_VCHR"]=this.m_objViewer.txtProduceing.Text.Trim();
	        dt.Rows[index]["IPCHARGEFLG_INT"]=this.m_objViewer.m_cmbIPUseUint.Tag.ToString().Trim();
            dt.Rows[index]["ORDERCATEID_CHR"] = this.m_objViewer.m_txtExeType.Tag.ToString();
            dt.Rows[index]["ordercatename_vchr"] = this.m_objViewer.m_txtExeType.Text.Trim();
            dt.Rows[index]["FREQID_CHR"] = this.m_objViewer.m_txtDefaultFreq.Tag;
            dt.Rows[index]["FREQNAME_CHR"] = this.m_objViewer.m_txtDefaultFreq.Text.Trim();
			if(this.m_objViewer.m_txtTradePrice.Text.Trim()=="")
			{
			    dt.Rows[index]["TRADEPRICE_MNY"]="0";
			}
			else
			{
			    dt.Rows[index]["TRADEPRICE_MNY"]=this.m_objViewer.m_txtTradePrice.Text;
			}
            dt.Rows[index]["ITEMCOMMNAME_VCHR"] = this.m_objViewer.txtCommName.Text.Trim();
            dt.Rows[index]["ORDERCATEID1_CHR"] = this.m_objViewer.m_txtOrderCateType.Tag.ToString();
            dt.Rows[index]["name_chr"] = this.m_objViewer.m_txtOrderCateType.Text.Trim();
            dt.Rows[index]["KEEPUSE_INT"] = this.m_objViewer.m_cboKeepUse.SelectedIndex;
            dt.Rows[index]["ischargemate"] = this.m_objViewer.cboSfcl.SelectedIndex;
	
		}
		private void m_mthAddNewRowToDataTable( clsChargeItem_VO clsVO)
		{
		
		}
		#endregion
		#region 新增数据
		public void m_mthAddNew()
		{
		this.m_Clear();
		this.m_objViewer.btSave.Tag=null;
		this.m_objViewer.m_txtchargeNO.Select();
		}
		#endregion
		#region 删除收费项目
		public void m_mthDeleteChargeItem()
		{
			if(this.m_objViewer.btSave.Tag==null)
			{
			return;
			}
			if(m_objViewer.dataGrid1.CurrentRowIndex>-1)
			{
				if(MessageBox.Show("是否要删除所选记录?","ICare",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes)
				{
					long strRet=objSvc.m_mthDelChargeItem(m_objViewer.btSave.Tag.ToString());
					if(strRet>0)
					{
						//删除表的数据
						dt.Rows[m_objViewer.dataGrid1.CurrentRowIndex].Delete();
						dt.AcceptChanges();
					}
				}
			}
		}
		#endregion
		#region 更改项目类别
		public void m_mthChangeCat()
		{
			if(this.m_objViewer.btSave.Tag==null)
			{
				return;
			}
			this.m_objViewer.btChangeCat.Enabled=false;
			long strRet=objSvc.m_mthChangeCat(m_objViewer.btSave.Tag.ToString(),this.m_objViewer.m_cmbType2.SelectItemValue);
			if(strRet>0)
			{
				//删除表的数据
				dt.Rows[m_objViewer.dataGrid1.CurrentRowIndex].Delete();
				dt.AcceptChanges();
				this.m_mthDataGridCellChange();
				this.m_objViewer.dataGrid1.Select(this.m_objViewer.dataGrid1.CurrentRowIndex);
				
			}
			else
			{
			MessageBox.Show("更改出错!");
			}
			this.m_objViewer.btChangeCat.Enabled=true;
		}
		#endregion
		#region 计算价格
		public void m_mthPrintChargeItem()
		{
			frmCharegeItemReport obj =new frmCharegeItemReport();
			obj.m_mthShowReport(this.dt);
			obj.Show();
		}
		#endregion
		#region 查找部位
		public void m_mthGetPartInfo()
		{
			m_objViewer.cmbCheckPart.m_mthClear();
			m_objViewer.cmbCheckPart.Items.Clear();
			m_objViewer.cmbCheckPart.Item.Add("","-1");
			DataTable dt;
			long lngRes=objSvc.m_mthLoadCheckType(out dt,this.m_objViewer.m_cboApplyType.SelectItemValue);
			if(lngRes>0 && dt.Rows.Count>0)
			{
				for(int i1=0;i1< dt.Rows.Count;i1++)
				{
					m_objViewer.cmbCheckPart.Item.Add(dt.Rows[i1]["TYPENAME"].ToString().Trim(),dt.Rows[i1]["ID"].ToString().Trim());
				}
			}
		}
		#endregion
        /// <summary>
        /// 查找各种收费类别
        /// </summary>
        /// <param name="m_strFindText"></param>
        /// <param name="m_intFlag"></param>
        /// <param name="m_objTextBox"></param>
        /// <param name="m_objListView"></param>
        /// <returns></returns>
        public int m_mthFindExeType(string m_strFindText, int m_intFlag, ref TextBox m_objTextBox)
        {
            long lngRes = -1;
            DataTable m_objExeTypeTable = new DataTable();
            lngRes = objSvc.m_mthFindExeType(m_strFindText, m_intFlag, out m_objExeTypeTable);
            if (lngRes > 0 && m_objExeTypeTable.Rows.Count > 0)
            {
                if (m_objExeTypeTable.Rows.Count == 1)
                {
                    m_objTextBox.Text = m_objExeTypeTable.Rows[0]["TYPENAME_VCHR"].ToString().Trim();
                    m_objTextBox.Tag = m_objExeTypeTable.Rows[0]["TYPEID_CHR"].ToString().Trim();
                    SendKeys.Send("{TAB}");
                    return 0;
                }
                else
                {
                    this.m_objViewer.m_lsvExcType.Items.Clear();
                    for (int i = 0; i < m_objExeTypeTable.Rows.Count; i++)
                    {
                        ListViewItem m_objItem = new ListViewItem(m_objExeTypeTable.Rows[i]["TYPEID_CHR"].ToString().Trim());
                        m_objItem.SubItems.Add(m_objExeTypeTable.Rows[i]["USERCODE_CHR"].ToString().Trim());
                        m_objItem.SubItems.Add(m_objExeTypeTable.Rows[i]["TYPENAME_VCHR"].ToString().Trim());
                        this.m_objViewer.m_lsvExcType.Items.Add(m_objItem);
                    }
                    return 1;

                }
            }
            else
            {
                m_objTextBox.Text = "";
                MessageBox.Show(this.m_objViewer, "找不到相应的类别！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                m_objTextBox.Focus();
                return -1;
            }
        }
        public void m_mthFillExeType(ref TextBox m_objTextBox)
        {

            m_objTextBox.Tag = this.m_objViewer.m_lsvExcType.SelectedItems[0].Text.Trim(); ;
            m_objTextBox.Text = this.m_objViewer.m_lsvExcType.SelectedItems[0].SubItems[2].Text.Trim();
        }
	
	}
}
