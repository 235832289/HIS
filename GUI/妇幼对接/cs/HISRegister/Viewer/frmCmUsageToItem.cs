using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using com.digitalwave.controls.datagrid;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmCmUsageToItem :com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmCmUsageToItem()
        {
            InitializeComponent();
            clsDomain = new clsDomainControl_ChargeItem();
           
        }
        public string strUsageID = "";
        private clsDcl_OPCharge objSvc = new clsDcl_OPCharge();
        clsDomainControl_ChargeItem clsDomain;
        /// <summary>
        /// set窗体控制类

        /// </summary>
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsControllCMUsageToItem();
            objController.Set_GUI_Apperance(this);
        }
        private void m_btnRef_Click(object sender, EventArgs e)
        {
            ((clsControllCMUsageToItem)this.objController).m_mthGetCMUsageInformation();
        }
        private void m_cmdAddNew_Click(object sender, EventArgs e)
        {
            clsBridgeForUsaEdit objItem = new clsBridgeForUsaEdit();
            objItem.m_strUsageID = this.strUsageID;
            frmUsaEdit objfrmUsaEdit = new frmUsaEdit(objItem);
            objfrmUsaEdit.m_blnIsCMUsageEdit = true;
            objfrmUsaEdit.ShowDialog();
            m_FillItem();
        }

        private void m_cmdChange_Click(object sender, EventArgs e)
        {
            clsBridgeForUsaEdit objItem = null;
            GetCurrentObj(out objItem);
            ArrayList objArr = new ArrayList();
            int location = this.m_dtgGroup.CurrentCell.RowNumber;
            for (int i = 0; i < m_dtgGroup.RowCount; i++)
            {
                if (i == location)
                {
                    continue;
                }
                objArr.Add(this.m_dtgGroup[i, 1].ToString().Trim());
            }
            frmUsaEdit objfrmUsaEdit = new frmUsaEdit(objItem);
            objfrmUsaEdit.CurrentItem = objArr;
            objfrmUsaEdit.m_blnIsCMUsageEdit = true;
            objfrmUsaEdit.ShowDialog();
            m_FillItem();
        }

        private void m_btndeleteDetail_Click(object sender, EventArgs e)
        {
            if (this.m_dtgGroup.RowCount == 0)
                return;
            this.m_Del();
        }

        private void m_cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCmUsageToItem_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (ActiveControl.ToString() != m_dtgGroup.ToString())
                    {	//避免自定义控件的一个Bug
                        this.Close();
                    }
                    break;
                case Keys.F2:
                    if (m_cmdAddNew.Visible && m_cmdAddNew.Enabled) m_cmdAddNew_Click(null, null);
                    break;
                case Keys.F3:
                    if (m_cmdChange.Visible && m_cmdChange.Enabled) m_cmdChange_Click(null, null);
                    break;
                case Keys.F4:
                    if (m_btndeleteDetail.Visible && m_btndeleteDetail.Enabled) m_btndeleteDetail_Click(null, null);
                    break;
                case Keys.F5:
                    if (m_btnRef.Visible && m_btnRef.Enabled) m_btnRef_Click(null, null);
                    break;
            }
        }

        private void frmCmUsageToItem_Load(object sender, EventArgs e)
        {
            splitter1.MinExtra = m_dtgGroup.Width;
            ((clsControllCMUsageToItem)this.objController).m_mthGetCMUsageInformation();
            m_dtgUsa_m_evtCurrentCellChanged(null, null);
        }

        private void m_dtgUsa_m_evtCurrentCellChanged(object sender, EventArgs e)
        {
            if (this.m_dtgUsa.RowCount == 0) return;
            if (this.m_dtgUsa[this.m_dtgUsa.CurrentCell.RowNumber, 0].ToString().Trim() != this.strUsageID)
            {
                this.strUsageID = this.m_dtgUsa[this.m_dtgUsa.CurrentCell.RowNumber, 0].ToString().Trim();
                m_FillItem();
            }
        }

        private void m_dtgGroup_m_evtDataGridKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F2:
                    if (m_cmdAddNew.Visible && m_cmdAddNew.Enabled) m_cmdAddNew_Click(null, null);
                    break;
                case Keys.F3:
                    if (m_cmdChange.Visible && m_cmdChange.Enabled) m_cmdChange_Click(null, null);
                    break;
                case Keys.F4:
                    if (m_btndeleteDetail.Visible && m_btndeleteDetail.Enabled) m_btndeleteDetail_Click(null, null);
                    break;
                case Keys.F5:
                    if (m_btnRef.Visible && m_btnRef.Enabled) m_btnRef_Click(null, null);
                    break;
            }
        }

        private void m_dtgGroup_m_evtDoubleClickCell(object sender, com.digitalwave.controls.datagrid.clsDGTextMouseClickEventArgs e)
        {
            if (m_cmdChange.Visible && m_cmdChange.Enabled) m_cmdChange_Click(null, null);
        }

        private void splitter1_DoubleClick(object sender, EventArgs e)
        {
            if (splitter1.SplitPosition < 150)
                splitter1.SplitPosition = 256;
            else
                splitter1.SplitPosition = splitter1.MinSize;
        }
        //#region 获取用法
        //public void m_GetUsage()
        //{
        //    m_dtgUsa.m_mthDeleteAllRow();
        //    com.digitalwave.iCare.ValueObject.clsUsageType_VO[] objResult = new com.digitalwave.iCare.ValueObject.clsUsageType_VO[0];
        //    long lngRes = clsDomain.m_lngGetUsage(out objResult, "");
        //    if (lngRes > 0 && objResult.Length > 0)
        //    {
        //        for (int i = 0; i < objResult.Length; i++)
        //        {
        //            this.m_dtgUsa.m_mthAppendRow(new object[] { objResult[i].m_strUsageID, objResult[i].m_strUsageCode, objResult[i].m_strUsageName, objResult[i].m_strUsagePYCODE, objResult[i].m_strUsageWBCODE });
        //        }
        //    }
        //}
        //#endregion
        #region 获取项目
        com.digitalwave.iCare.ValueObject.clsChargeItem_VO[] m_clsChargeItem_VO = new com.digitalwave.iCare.ValueObject.clsChargeItem_VO[0];
        public void m_FillItem()
        {
            com.digitalwave.iCare.ValueObject.clsChargeItem_VO[] objResult = this.m_clsChargeItem_VO;
            if (objResult.Length > 0)
            {
                return;
            }
            long lngRes = clsDomain.m_lngGetItemByCMUsageID(strUsageID, out objResult);
            this.m_dtgGroup.BeginUpdate();
            this.m_dtgGroup.m_mthDeleteAllRow();
            if ((lngRes > 0) && (objResult != null))
            {
                double dblTem = 0;
                string strClinicUnit = "", strGetBihUnit = "", strClinicNumberUnit = "", strBihNumberUnit = "";
                for (int i = 0; i < objResult.Length; i++)
                {
                    GetUnit(objResult[i], out strClinicUnit, out strGetBihUnit);

                    if (objResult[i].m_intCLINICTYPE_INT == 1)//门诊领量单位
                    {
                        strClinicNumberUnit = objResult[i].m_strUNITPRICE.Trim() + strClinicUnit.Trim();
                    }
                    else if (objResult[i].m_intCLINICTYPE_INT == 2)
                    {
                        strClinicNumberUnit = objResult[i].m_strUNITPRICE.Trim() + objResult[i].m_DosageUnit.m_strUnitID;
                    }
                    if (objResult[i].m_intBIHTYPE_INT == 1)//门诊领量单位
                    {
                        strBihNumberUnit = objResult[i].m_dblBIHQTY_DEC.ToString().Trim() + strGetBihUnit.Trim();
                    }
                    else if (objResult[i].m_intBIHTYPE_INT == 2)
                    {
                        strBihNumberUnit = objResult[i].m_dblBIHQTY_DEC.ToString().Trim() + objResult[i].m_DosageUnit.m_strUnitID;
                    }
                    dblTem = 0;
                    try
                    {
                        dblTem = double.Parse(objResult[i].m_strTOTALPRICE);
                    }
                    catch { }

                    this.m_dtgGroup.m_mthAppendRow(new object[] {	objResult[i].m_ItemOPInvType.m_strTypeID,
																	objResult[i].m_strItemID,
																	objResult[i].m_strItemName,
																	m_mthConvertToChType(objResult[i].m_ItemCat.m_strItemCatID),
																	objResult[i].m_strItemSpec,																	
																	objResult[i].m_fltItemPrice.ToString("0.0000"),
																	strClinicNumberUnit,
																	(objResult[i].m_intCLINICTYPE_INT==1)?"门诊领量单位":"门诊剂量单位",
																	dblTem.ToString("0.00"),
																	strBihNumberUnit,
																	(objResult[i].m_intBIHTYPE_INT==1)?"住院领量单位":"住院剂量单位",
																	"",
																	strGetContinueUseTypeName(objResult[i].m_intCONTINUEUSETYPE_INT),
																	objResult[i].m_strDosage.ToString(),
																	objResult[i].m_DosageUnit.m_strUnitID,
																	strClinicUnit,
																	strGetBihUnit,
																	objResult[i].m_strUNITPRICE,
																	objResult[i].m_dblBIHQTY_DEC,
																	objResult[i].m_intCONTINUEUSETYPE_INT
																});
                    this.m_dtgGroup.BeginUpdate();
                    if (objResult[i].m_intStopFlag == 1 && objResult[i].m_intItemSrcType == 1)
                    {
                        for (int f2 = 0; f2 < this.m_dtgGroup.Columns.Count; f2++)
                        {
                            this.m_dtgGroup.m_mthFormatCell(i, f2, m_dtgGroup.Font, System.Drawing.Color.White, System.Drawing.Color.Red);
                        }

                    }
                    this.m_dtgGroup.EndUpdate();
                    //填充门诊费用合计、住院费用合计

                    m_mthCalMoney(objResult);
                }
            }
        }
        #endregion
        #region 删除项目
        /// <summary>
        /// 删除项目
        /// </summary>
        public void m_Del()
        {
            if (this.m_dtgGroup.RowCount == 0) return;
            com.digitalwave.iCare.ValueObject.clsChargeItemUsageGroup_VO clsVO = new com.digitalwave.iCare.ValueObject.clsChargeItemUsageGroup_VO();
            clsVO.m_strItemID = this.m_dtgGroup[this.m_dtgGroup.CurrentCell.RowNumber, 1].ToString();
            clsVO.m_strUsageID = this.strUsageID;
            if (strUsageID.Trim() != "" && MessageBox.Show("确定删除选中项吗?", "提示框!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsVO.m_intFlag = 0;
                if (MessageBox.Show("是否删除其他同法的此项目?", "提示框!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    clsVO.m_intFlag = 1;
                }
                long lngRes = clsDomain.m_lngDelCMUsageGroupByID(clsVO);
                if (lngRes > 0)
                {
                    MessageBox.Show("操作成功!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_dtgGroup.m_mthDeleteRow(this.m_dtgGroup.CurrentCell.RowNumber);
                }
                else
                {
                    MessageBox.Show("操作失败!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 获取当前选中行的对象
        /// </summary>
        /// <param name="p_objResult"></param>
        /// <returns>返回是否获取成功</returns>
        private void GetCurrentObj(out clsBridgeForUsaEdit p_objResult)
        {
            p_objResult = new clsBridgeForUsaEdit();
            //用法ID
            p_objResult.m_strUsageID = this.strUsageID;
            if (m_dtgGroup.CurrentCell.RowNumber < 0 || m_dtgGroup.CurrentCell.RowNumber >= m_dtgGroup.RowCount)
            {
                return;
            }
            int intRow = m_dtgGroup.CurrentCell.RowNumber;
            //填充值

            //项目ID
            p_objResult.m_strItemID = this.m_dtgGroup[intRow, "ITEMID_CHR"].ToString();
            //项目名称
            p_objResult.m_strItemName = this.m_dtgGroup[intRow, "ITEMNAME_VCHR"].ToString();
            //项目类型
            p_objResult.m_strItemType = this.m_dtgGroup[intRow, "ItemType"].ToString();
            //项目规格
            p_objResult.m_strItemSpec = this.m_dtgGroup[intRow, "ItemSpec"].ToString();
            //住院单价
            p_objResult.m_strItemPrice = this.m_dtgGroup[intRow, "ItemPrice"].ToString();
            //门诊数量	[不包括单位]
            p_objResult.m_strUNITPRICE = this.m_dtgGroup[intRow, "ClinicNumber"].ToString().Trim();
            //门诊数量单位
            string strTem = m_dtgGroup[intRow, "ClinicType"].ToString().Trim();
            if (m_dtgGroup[intRow, "ClinicType"] != System.DBNull.Value) p_objResult.m_intCLINICTYPE_INT = (strTem == "门诊领量单位") ? 1 : 2;
            //门诊费用合计
            p_objResult.m_strTOTALPRICE = this.m_dtgGroup[intRow, "ITEMPRICE_MNY"].ToString().Trim();
            //住院数量	[不包括单位]
            if (m_dtgGroup[intRow, "BihNumber"] != System.DBNull.Value) p_objResult.m_dblBIHQTY_DEC = double.Parse(m_dtgGroup[intRow, "BihNumber"].ToString());
            //住院数量单位
            strTem = m_dtgGroup[intRow, "BihType"].ToString().Trim();
            if (m_dtgGroup[intRow, "BihType"] != System.DBNull.Value) p_objResult.m_intBIHTYPE_INT = (strTem == "住院领量单位") ? 1 : 2;
            //住院费用合计
            p_objResult.m_strBihOtalPrice = this.m_dtgGroup[intRow, "BIHITEMPRICE_MNY"].ToString();
            //单位剂量
            try
            {
                p_objResult.m_dblDOSAGE_DEC = Convert.ToDouble(m_dtgGroup[intRow, "DOSAGE_DEC"].ToString());
            }
            catch { }
            //剂量单位
            p_objResult.m_strDOSAGEUNIT_CHR = this.m_dtgGroup[intRow, "DOSAGEUNIT_CHR"].ToString();
            //门诊领量单位
            p_objResult.m_strGetClinicUnit = this.m_dtgGroup[intRow, "GetClinicUnit"].ToString();
            //住院领量单位
            p_objResult.m_strGetBihUnit = this.m_dtgGroup[intRow, "GetBihUnit"].ToString();
            //续用类型 {0=不续用;1=全部续用;2-长嘱续用}
            p_objResult.m_intCONTINUEUSETYPE_INT = Convert.ToInt32(this.m_dtgGroup[intRow, "CONTINUEUSETYPE_INT"].ToString());
        }
        /// <summary>
        /// 获取领量单位
        /// </summary>
        /// <param name="p_objItem"></param>
        /// <param name="p_strClinicUnit">[out 参数] 门诊领量单位</param>
        /// <param name="p_strGetBihUnit">[out 参数] 住院领量单位</param>
        private void GetUnit(com.digitalwave.iCare.ValueObject.clsChargeItem_VO p_objItem, out string p_strClinicUnit, out string p_strGetBihUnit)
        {
            p_strClinicUnit = "";
            p_strGetBihUnit = "";
            if (p_objItem == null) return;

            int intGetType = 0;
            //门诊单位
            intGetType = 0;//门诊收费单位 0 －基本单位 1－最小单位

            try { intGetType = Convert.ToInt32(p_objItem.m_intOPCHARGEFLG_INT); }
            catch { }
            try
            {
                if (intGetType == 0)
                    p_strClinicUnit = p_objItem.m_ItemOPUnit.m_strUnitID;//基本单位
                else
                    p_strClinicUnit = p_objItem.m_ItemIPUnit.m_strUnitID;//最小单位

            }
            catch { }

            //住院单位
            intGetType = 0;//住院收费单位 0 －基本单位 1－最小单位

            try { intGetType = Convert.ToInt32(p_objItem.m_intIPCHARGEFLG_INT); }
            catch { }
            try
            {
                if (intGetType == 0)
                    p_strGetBihUnit = p_objItem.m_ItemOPUnit.m_strUnitID;//基本单位
                else
                    p_strGetBihUnit = p_objItem.m_ItemIPUnit.m_strUnitID;//最小单位

            }
            catch { }
        }
        private string m_mthConvertToChType(string strTypeNo)
        {
            string strRet = "西药";
            switch (strTypeNo)
            {
                case "0002":
                    strRet = "中药";
                    break;
                case "0003":
                    strRet = "检验";
                    break;
                case "0004":
                    strRet = "治疗";
                    break;
                case "0005":
                    strRet = "其他";
                    break;
                case "0006":
                    strRet = "手术";
                    break;
                default:
                    strRet = "西药";
                    break;
            }
            return strRet;
        }
        private void m_mthCalMoney(clsChargeItem_VO[] objResult)
        {
            clsDcl_ChargeItem objChargeItem = new clsDcl_ChargeItem();
            double dblPrice = 0, dblUnitDosage = 0, dblMoney = 0, dblQTY = 0;
            int intTIMES = 1, intType = 0;
            string strTem = "";
            for (int i = 0; i < this.m_dtgGroup.RowCount; i++)
            {
                dblPrice = 0;
                dblUnitDosage = 0;
                dblMoney = 0;
                dblQTY = 0;
                intType = 0;
                if (m_dtgGroup[i, "ItemPrice"] != System.DBNull.Value) dblPrice = double.Parse(m_dtgGroup[i, "ItemPrice"].ToString());
                try
                {
                    if (m_dtgGroup[i, "DOSAGE_DEC"] != System.DBNull.Value) dblUnitDosage = double.Parse(m_dtgGroup[i, "DOSAGE_DEC"].ToString());
                }
                catch { }
                //求门诊费用

                if (m_dtgGroup[i, "ClinicNumber"] != System.DBNull.Value) dblQTY = double.Parse(m_dtgGroup[i, "ClinicNumber"].ToString());
                strTem = m_dtgGroup[i, "ClinicType"].ToString().Trim();
                if (m_dtgGroup[i, "ClinicType"] != System.DBNull.Value) intType = (strTem == "门诊领量单位") ? 1 : 2;
                objChargeItem.m_lngGetChargeClinicUsage(dblPrice, intTIMES, dblQTY, intType, dblUnitDosage, out dblMoney);
                m_dtgGroup[i, "ITEMPRICE_MNY"] = dblMoney.ToString("0.00");

                //求住院费用

                dblQTY = 0; intType = 0;
                if (m_dtgGroup[i, "BihNumber"] != System.DBNull.Value) dblQTY = double.Parse(m_dtgGroup[i, "BihNumber"].ToString());
                strTem = m_dtgGroup[i, "BihType"].ToString().Trim();
                if (m_dtgGroup[i, "BihType"] != System.DBNull.Value) intType = (strTem == "住院领量单位") ? 1 : 2;
                objChargeItem.m_lngGetChargeBIHUsage(dblPrice, intTIMES, dblQTY, intType, dblUnitDosage, out dblMoney);
                m_dtgGroup[i, "BIHITEMPRICE_MNY"] = dblMoney.ToString("0.00");
            }
        }
        private decimal m_mthConvertToDecimal(object obj)
        {
            decimal ret = 0;
            try
            {
                if (obj != null)
                {

                    ret = decimal.Parse(obj.ToString());
                }
            }
            catch
            {
                ret = 0;
            }
            return ret;

        }
        /// <summary>
        /// 返回续用类型名称表示 根据续用类型
        /// </summary>
        /// <param name="p_intType">续用类型 {0=不续用;1=全部续用;2-长嘱续用}</param>
        /// <returns></returns>
        private string strGetContinueUseTypeName(int p_intType)
        {
            string strRes = "";
            switch (p_intType)
            {
                case 0:
                    strRes = "连续用";
                    break;
                case 1:
                    strRes = "首次用";
                    break;
                default:
                    strRes = "";
                    break;
            }
            return strRes;
        }
        #endregion

    }
}