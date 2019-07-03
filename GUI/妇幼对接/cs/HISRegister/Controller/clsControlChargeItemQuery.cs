using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 收费项目查询界面控制层
    /// </summary>
    class clsControlChargeItemQuery : com.digitalwave.GUI_Base.clsController_Base
    {

        private clsDcl_ChargeItem objSvc = null;
        private DataTable dt = null;
        public clsControlChargeItemQuery()
        {
            objSvc = new clsDcl_ChargeItem();
        }
        public void m_mthLoadData()
        {
            this.m_mthFillCat();
            this.m_mthFillAll();
            this.m_mthFillBihCat();
            this.m_mthFillCARETYPE();
            m_mthSelectItem(m_objViewer.m_cmbCoustomPrice);
            m_mthSelectItem(this.m_objViewer.m_cmbOPUseUint);
            m_mthSelectItem(this.m_objViewer.m_cmbIPUseUint);
            m_mthSelectItem(this.m_objViewer.m_cmbCoustomPrice);
            m_mthSelectItem((ComboBox)this.m_objViewer.m_cboCase);
            m_mthSelectItem((ComboBox)this.m_objViewer.m_cboApplyType);
            m_mthSelectItem(this.m_objViewer.m_cmbIsExpensive);
            this.m_objViewer.m_cmbIsInDocAdv.SelectedIndex = 1;
            m_objViewer.m_cmbFind.SelectedIndex = 2;
        }
        #region 填充医保类型
        private void m_mthFillCARETYPE()
        {
            DataTable dtCARETYPE = new DataTable();
            long lngRes = objSvc.m_getMEDICARETYPE(out dtCARETYPE);
            if ((lngRes > 0) && dtCARETYPE != null)
            {
                this.m_objViewer.COBINSURANCETYPE.Item.Add("", "");
                this.m_objViewer.cboInpInsuranceType.Item.Add("", "");
                for (int i1 = 0; i1 < dtCARETYPE.Rows.Count; i1++)
                {
                    this.m_objViewer.COBINSURANCETYPE.Item.Add(dtCARETYPE.Rows[i1]["TYPENAME_VCHR"].ToString(), dtCARETYPE.Rows[i1]["TYPEID_CHR"].ToString());
                    this.m_objViewer.cboInpInsuranceType.Item.Add(dtCARETYPE.Rows[i1]["TYPENAME_VCHR"].ToString(), dtCARETYPE.Rows[i1]["TYPEID_CHR"].ToString());
                }
            }

        }
        #endregion
        #region 获取医嘱类型
        private void m_mthFillBihCat()
        {
            DataTable dt = new DataTable();
            long lngRes = objSvc.m_lngGetAllBihCate(out dt);
            if (dt.Rows.Count > 0)
            {
                this.m_objViewer.ORDERCATENAME.Item.Add("", "");
                for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                {
                    this.m_objViewer.ORDERCATENAME.Item.Add(dt.Rows[i1]["ORDERCATENAME_VCHR"].ToString(), dt.Rows[i1]["ORDERCATEID_CHR"].ToString());
                }
            }
        }
        #endregion
        private void m_FillDefaultFREQ()
        {
            DataTable dt;
            long lngRes = objSvc.m_mthFindRecipeFreq(out dt);
            m_objViewer.m_cboDefaultFreq.Items.Clear();
            m_objViewer.m_cboDefaultFreq.Item.Add("", "-1");
            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                {
                    m_objViewer.m_cboDefaultFreq.Item.Add(dt.Rows[i1]["freqname_chr"].ToString().Trim(), dt.Rows[i1]["freqid_chr"].ToString().Trim());
                }
            }
        }
        private void m_mthSelectItem(ComboBox cb)
        {
            if (cb.Items.Count > 0)
            {
                cb.SelectedIndex = 0;
            }
        }
        #region 设置窗体对象
        public com.digitalwave.iCare.gui.HIS.frmChargeItemQuery m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmChargeItemQuery)frmMDI_Child_Base_in;
        }
        #endregion
        #region 查询收费项目
        public void m_mthFindChargeItem(string strCatID, string strType, string strContent)
        {
            m_objViewer.m_cmbType.SelectedIndexChanged -= new System.EventHandler(m_objViewer.m_cmbType_SelectedIndexChanged);
            long strRet = objSvc.m_mthFindChargeItem1(strCatID, strType, strContent.ToUpper(), out dt);
            dt.TableName = "dt";
            if (dt.Rows.Count > 0 && strCatID == "")
            {
                this.m_objViewer.m_cmbType.FindKey(dt.Rows[0]["ITEMCATID_CHR"].ToString().Trim());
            }
            if (strRet > 0)
            {

                this.m_objViewer.m_dtgChargeItem.m_mthSetDataTable(dt);
            }
            this.m_objViewer.m_dtgChargeItem.CurrentCell = new DataGridCell(0, 0);

            if (dt.Rows.Count > 0)
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
        public void m_mthPrintChargeItem()
        {
            frmCharegeItemReport obj = new frmCharegeItemReport();
            obj.m_mthShowReport(this.dt);
            obj.Show();
        }
        #region DataGridCellChange事件
        public void m_mthDataGridCellChange()
        {
            int index = this.m_objViewer.m_dtgChargeItem.CurrentCell.RowNumber;
            this.m_objViewer.btSave.Tag = dt.Rows[index]["ITEMID_CHR"].ToString().Trim();
            this.m_objViewer.m_txtName.Text = dt.Rows[index]["ITEMNAME_VCHR"].ToString().Trim();
            this.m_objViewer.txtEnglishName.Text = dt.Rows[index]["ITEMENGNAME_VCHR"].ToString().Trim();
            this.m_objViewer.txtCommName.Text = dt.Rows[index]["ITEMCOMMNAME_VCHR"].ToString().Trim();
            this.m_objViewer.m_txtNo.Text = dt.Rows[index]["ITEMCODE_VCHR"].ToString().Trim();
            this.m_objViewer.m_txtPY.Text = dt.Rows[index]["ITEMPYCODE_CHR"].ToString().Trim();
            this.m_objViewer.m_txtWB.Text = dt.Rows[index]["ITEMWBCODE_CHR"].ToString().Trim();
            this.m_objViewer.m_txtSpec.Text = dt.Rows[index]["ITEMSPEC_VCHR"].ToString().Trim();
            this.m_objViewer.m_txtPrice.Text = dt.Rows[index]["ITEMPRICE_MNY"].ToString().Trim();
            this.m_objViewer.m_txtPrice.Tag = dt.Rows[index]["ITEMPRICE_MNY"].ToString().Trim();
            this.m_objViewer.m_cboUnit.Text = dt.Rows[index]["ITEMUNIT_CHR"].ToString().Trim();
            this.m_objViewer.m_cboOPUnit.Text = dt.Rows[index]["ITEMOPUNIT_CHR"].ToString().Trim();
            this.m_objViewer.m_cboIPUnit.Text = dt.Rows[index]["ITEMIPUNIT_CHR"].ToString().Trim();
            this.m_objViewer.COBINSURANCETYPE.FindKey(dt.Rows[index]["INSURANCETYPE_VCHR"].ToString().Trim());
            this.m_objViewer.cboInpInsuranceType.FindKey(dt.Rows[index]["INPINSURANCETYPE_VCHR"].ToString().Trim());
            this.m_objViewer.m_cboOPCal.FindKey(dt.Rows[index]["ITEMOPCALCTYPE_CHR"].ToString().Trim());
            this.m_objViewer.m_cboIPCal.FindKey(dt.Rows[index]["ITEMIPCALCTYPE_CHR"].ToString().Trim());
            this.m_objViewer.m_cboOPInv.FindKey(dt.Rows[index]["ITEMOPINVTYPE_CHR"].ToString().Trim());
            this.m_objViewer.m_cboIPInv.FindKey(dt.Rows[index]["ITEMIPINVTYPE_CHR"].ToString().Trim());
            this.m_objViewer.m_cboCase.FindKey(dt.Rows[index]["ITEMBIHCTYPE_CHR"].ToString().Trim());
            this.m_objViewer.m_cboApplyType.FindKey(dt.Rows[index]["APPLY_TYPE_INT"].ToString().Trim());
            this.m_objViewer.cmbCheckPart.FindKey(dt.Rows[index]["ITEMCHECKTYPE_CHR"].ToString().Trim());
            this.m_objViewer.m_cboUsage.FindKey(dt.Rows[index]["USAGEID_CHR"].ToString().Trim());
            this.m_objViewer.m_txtchargeNO.Text = dt.Rows[index]["ITEMOPCODE_CHR"].ToString().Trim();
            this.m_objViewer.m_txtDosage.Text = dt.Rows[index]["DOSAGE_DEC"].ToString().Trim();
            this.m_objViewer.m_cboDosUnit.Text = dt.Rows[index]["DOSAGEUNIT_CHR"].ToString().Trim();
            this.m_objViewer.m_txtPacQ.Text = dt.Rows[index]["PACKQTY_DEC"].ToString();
            this.m_objViewer.m_cmbCoustomPrice.SelectedIndex = m_mthGetIndex(dt.Rows[index]["SELFDEFINE_INT"]);
            this.m_objViewer.m_cmbIsExpensive.SelectedIndex = m_mthGetIndex(dt.Rows[index]["ISRICH_INT"]);
            this.m_objViewer.m_cmbOPUseUint.SelectedIndex = m_mthGetIndex(dt.Rows[index]["OPCHARGEFLG_INT"]);
            this.m_objViewer.m_txtInsuranceID.Text = dt.Rows[index]["INSURANCEID_CHR"].ToString().Trim();
            this.m_objViewer.m_txtSourName.Text = dt.Rows[index]["ITEMSRCNAME_VCHR"].ToString().Trim();
            this.m_objViewer.m_txtSour.Text = dt.Rows[index]["ITEMSRCTYPENAME_VCHR"].ToString().Trim();
            this.m_objViewer.m_cmbIsInDocAdv.SelectedIndex = m_mthGetIndex(dt.Rows[index]["POFLAG_INT"]);
            this.m_objViewer.cmbIsStop.SelectedIndex = m_mthGetIndex(dt.Rows[index]["IFSTOP_INT"]);
            this.m_objViewer.m_txtTradePrice.Text = dt.Rows[index]["TRADEPRICE_MNY"].ToString();
            this.m_objViewer.txtProduceing.Text = dt.Rows[index]["PDCAREA_VCHR"].ToString();//产地
            this.m_objViewer.m_cmbIPUseUint.SelectedIndex = m_mthGetIndex(dt.Rows[index]["IPCHARGEFLG_INT"]);
            this.m_objViewer.ORDERCATENAME.FindKey(dt.Rows[index]["ORDERCATEID_CHR"].ToString().Trim());
            this.m_objViewer.cboOrderCate.FindKey(dt.Rows[index]["ORDERCATEID1_CHR"].ToString().Trim());
            this.m_objViewer.m_cboDefaultFreq.FindKey(dt.Rows[index]["FREQID_CHR"].ToString().Trim());

            this.m_objViewer.m_dtgChargeItem.m_mthSelectRow(this.m_objViewer.m_dtgChargeItem.CurrentCell.RowNumber, true);
            if (dt.Rows[index]["ISSELFPAY_CHR"].ToString() == "T")
            {
                this.m_objViewer.m_cmbSelf.SelectedIndex = 1;
            }
            else
            {
                this.m_objViewer.m_cmbSelf.SelectedIndex = 0;
            }
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
                if (str != null && str.ToString().Trim() != "")
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
            if (this.m_objViewer.m_cmbOPUseUint.SelectedIndex == 0)
            {
                if (this.m_objViewer.m_txtPrice.Text.Trim() != "" && this.m_objViewer.m_txtPrice.Text.Trim() != ".")
                {
                    this.m_objViewer.lbePrice.Text = decimal.Parse(this.m_objViewer.m_txtPrice.Text).ToString("0.0000");
                }

            }
            else
            {
                decimal count = 1;
                if (this.m_objViewer.m_txtPacQ.Text.Trim() != "" && this.m_objViewer.m_txtPacQ.Text.Trim() != ".")
                {
                    count = decimal.Parse(this.m_objViewer.m_txtPacQ.Text.Trim());
                    if (count == 0)
                    {
                        count = 1;
                    }
                }
                decimal price = 0;
                if (this.m_objViewer.m_txtPrice.Text.Trim() != "" && this.m_objViewer.m_txtPrice.Text.Trim() != ".")
                {
                    price = decimal.Parse(this.m_objViewer.m_txtPrice.Text.Trim());
                }
                this.m_objViewer.lbePrice.Text = ((decimal)(price / count)).ToString("0.0000");
            }

            if (this.m_objViewer.m_cmbIPUseUint.SelectedIndex == 0)
            {
                if (this.m_objViewer.m_txtPrice.Text.Trim() != "" && this.m_objViewer.m_txtPrice.Text.Trim() != ".")
                {
                    this.m_objViewer.lbeIPPrice.Text = decimal.Parse(this.m_objViewer.m_txtPrice.Text).ToString("0.0000");
                }

            }
            else
            {
                decimal count = 1;
                if (this.m_objViewer.m_txtPacQ.Text.Trim() != "" && this.m_objViewer.m_txtPacQ.Text.Trim() != ".")
                {
                    count = decimal.Parse(this.m_objViewer.m_txtPacQ.Text.Trim());
                    if (count == 0)
                    {
                        count = 1;
                    }
                }
                decimal price = 0;
                if (this.m_objViewer.m_txtPrice.Text.Trim() != "" && this.m_objViewer.m_txtPrice.Text.Trim() != ".")
                {
                    price = decimal.Parse(this.m_objViewer.m_txtPrice.Text.Trim());
                }
                this.m_objViewer.lbeIPPrice.Text = ((decimal)(price / count)).ToString("0.0000");
            }
        }
        #endregion
        #region 填充各下拉控件
        private void m_mthFillAll()
        {
            this.m_FillUnit();
            this.m_FillUsage();
            this.m_FillExType();
            m_FillApplyType();
            this.m_FillDefaultFREQ();
            this.m_mthFillOrderCate();
        }
        private void m_mthFillOrderCate()
        {
            DataTable m_objTable;
            long lngRes = -1;
            lngRes = objSvc.m_mthSelectOrderCate(out m_objTable);

            if (lngRes > 0 && m_objTable.Rows.Count > 0)
            {
                for (int i = 0; i < m_objTable.Rows.Count; i++)
                {
                    m_objViewer.cboOrderCate.Item.Add(m_objTable.Rows[i]["NAME_CHR"].ToString().Trim(), m_objTable.Rows[i]["ORDERCATEID_CHR"].ToString().Trim());
                }
            }

        }
        private void m_FillUnit()
        {
            clsUnit_VO[] objResult;
            long lngRes = objSvc.m_mthGetUnit(out objResult);
            if (lngRes > 0 && objResult.Length > 0)
            {
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {
                    m_objViewer.m_cboUnit.Item.Add(objResult[i1].m_strUnitName, objResult[i1].m_strUnitID);
                    m_objViewer.m_cboDosUnit.Item.Add(objResult[i1].m_strUnitName, objResult[i1].m_strUnitID);
                    m_objViewer.m_cboOPUnit.Item.Add(objResult[i1].m_strUnitName, objResult[i1].m_strUnitID);
                    m_objViewer.m_cboIPUnit.Item.Add(objResult[i1].m_strUnitName, objResult[i1].m_strUnitID);

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
            long lngRes = objSvc.m_mthFindApplyType(out dt, "");
            m_objViewer.m_cboApplyType.Item.Add("", "-1");
            if (lngRes > 0 && dt.Rows.Count > 0)
            {
                for (int i1 = 0; i1 < dt.Rows.Count; i1++)
                {
                    m_objViewer.m_cboApplyType.Item.Add(dt.Rows[i1]["TYPETEXT"].ToString().Trim(), dt.Rows[i1]["TYPEID"].ToString().Trim());
                }
            }
        }
        private void m_FillUsage()
        {
            clsUsageType_VO[] objResult;
            long lngRes = objSvc.m_mthGetUsage(out objResult, "");
            if (lngRes > 0 && objResult.Length > 0)
            {
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {
                    m_objViewer.m_cboUsage.Item.Add(objResult[i1].m_strUsageName, objResult[i1].m_strUsageID);
                }
            }
        }

        private void m_FillExType()
        {
            clsChargeItemEXType_VO[] objResult;
            long lngRes = objSvc.m_mthEXType("1", out objResult); //门诊核算
            if (lngRes > 0 && objResult.Length > 0)
            {
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {
                    m_objViewer.m_cboOPCal.Item.Add(objResult[i1].m_strTypeName, objResult[i1].m_strTypeID);

                }
            }

            lngRes = objSvc.m_mthEXType("2", out objResult); //门诊发票
            if (lngRes > 0 && objResult.Length > 0)
            {
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {
                    m_objViewer.m_cboOPInv.Item.Add(objResult[i1].m_strTypeName, objResult[i1].m_strTypeID);

                }
            }
            lngRes = objSvc.m_mthEXType("3", out objResult); //住院核算
            if (lngRes > 0 && objResult.Length > 0)
            {
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {
                    m_objViewer.m_cboIPCal.Item.Add(objResult[i1].m_strTypeName, objResult[i1].m_strTypeID);
                }
            }
            lngRes = objSvc.m_mthEXType("4", out objResult); //住院发票
            if (lngRes > 0 && objResult.Length > 0)
            {
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {
                    m_objViewer.m_cboIPInv.Item.Add(objResult[i1].m_strTypeName, objResult[i1].m_strTypeID);
                }
            }
            lngRes = objSvc.m_mthEXType("5", out objResult); //住院发票
            if (lngRes > 0 && objResult.Length > 0)
            {
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {
                    m_objViewer.m_cboCase.Item.Add(objResult[i1].m_strTypeName, objResult[i1].m_strTypeID);
                }
            }
        }
        #endregion
        #region 清空
        public void m_Clear()
        {

            m_objViewer.COBINSURANCETYPE.Clear();
            m_objViewer.m_cboDosUnit.Clear();
            m_objViewer.m_cboIPCal.Clear();
            m_objViewer.m_cboIPInv.Clear();
            m_objViewer.m_cboIPUnit.Clear();
            m_objViewer.m_cboOPCal.Clear();
            m_objViewer.m_cboOPInv.Clear();
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
            m_objViewer.m_txtFind.Text = "";
            m_objViewer.m_txtInsuranceID.Clear();
            m_objViewer.m_txtPacQ.Clear();
            m_objViewer.m_txtTradePrice.Clear();
            m_objViewer.txtEnglishName.Clear();
            m_objViewer.txtCommName.Clear();
            m_objViewer.cmbIsStop.SelectedIndex = 0;
            m_objViewer.ORDERCATENAME.SelectedIndex = 0;
            m_objViewer.txtProduceing.Clear();
            m_objViewer.m_cmbIPUseUint.SelectedIndex = 0;

        }
        #endregion
        #region 查找下拉框改变选项
        public void m_cmbFind_SelectedIndexChanged()
        {
            switch (m_objViewer.m_cmbFind.SelectedIndex)
            {
                case 0://项目ID
                    m_objViewer.m_cmbFind.Tag = "ITEMID_CHR";
                    break;
                case 1://项目名称
                    m_objViewer.m_cmbFind.Tag = "ITEMNAME_VCHR";
                    break;
                case 2://项目编码
                    m_objViewer.m_cmbFind.Tag = "ITEMCODE_VCHR";
                    break;
                case 3://项目拼音
                    m_objViewer.m_cmbFind.Tag = "ITEMPYCODE_CHR";
                    break;
                case 4://项目五笔
                    m_objViewer.m_cmbFind.Tag = "ITEMWBCODE_CHR";
                    break;
                case 5:
                    m_objViewer.m_cmbFind.Tag = "ITEMENGNAME_VCHR";
                    break;
            }
            m_objViewer.m_txtFind.Select();
        }
        #endregion
        #region 取得项目的类型
        private void m_mthFillCat()
        {
            clsCharegeItemCat_VO[] objResult;
            long lngRes = objSvc.m_mthFindCat(out objResult);
            m_objViewer.m_cmbType.Items.Clear();
            if ((lngRes > 0) && (objResult != null))
            {
                for (int i1 = 0; i1 < objResult.Length; i1++)
                {

                    if (this.m_objViewer.strPopedom == "")
                    {
                        m_objViewer.m_cmbType.Item.Add(objResult[i1].m_strItemCatName, objResult[i1].m_strItemCatID);
                    }
                    else
                    {
                        if (m_mthAddPopedom(objResult[i1].m_strItemCatID.Trim()))
                        {
                            m_objViewer.Name += i1.ToString();
                            m_objViewer.m_cmbType.Item.Add(objResult[i1].m_strItemCatName, objResult[i1].m_strItemCatID);
                        }
                    }
                }
            }
            if (m_objViewer.m_cmbType.Items.Count > 0)
            {
                m_objViewer.m_cmbType.SelectedIndex = 0;

            }
        }
        private bool m_mthAddPopedom(string strCatID)
        {
            bool ret = false;
            string[] strArr = this.m_objViewer.strPopedom.Split('*');
            for (int i = 0; i < strArr.Length; i++)
            {
                if (strArr[i].Trim() == strCatID)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }
        #endregion
    }
}
