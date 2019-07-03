using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.IO;
using System.Xml;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 药库出库
    /// </summary>
    public class clsCtl_MedicineOut : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量
        /// <summary>
        /// 模块控制类

        /// </summary>
        private clsDcl_MedicineOut m_objDomain = null;
        /// <summary>
        /// 窗体
        /// </summary>
        com.digitalwave.iCare.gui.MedicineStore.frmMedicineOut m_objViewer;
        /// <summary>
        /// 查询药品字典控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;
        /// <summary>
        /// 查询员工控件
        /// </summary>
        private ctlQueryEmployee m_ctlEMP = null;
        /// <summary>
        /// 当前药品出库主表信息
        /// </summary>
        private clsMS_OutStorage_VO m_objCurrentMain = null;
        /// <summary>
        /// 当前药品出库子表信息
        /// </summary>
        private clsMS_OutStorageDetail_VO[] m_objCurrentSubArr = null;
        #endregion

        #region 构造函数

        /// <summary>
        /// 药库出库
        /// </summary>
        public clsCtl_MedicineOut()
        {
            m_objDomain = new clsDcl_MedicineOut();
        } 
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMedicineOut)frmMDI_Child_Base_in;

        }
        #endregion

        #region 初始化子表作为DataGridView数据源的DataTable
        /// <summary>
        /// 初始化子表作为DataGridView数据源的DataTable
        /// </summary>
        /// <param name="p_dtbMedicineTalbe"></param>
        internal void m_mthInitMedicineTable(ref DataTable p_dtbMedicineTalbe)
        {
            p_dtbMedicineTalbe = new DataTable();
            DataColumn[] dcColumns = new DataColumn[] { new DataColumn("SERIESID_INT"), new DataColumn("SERIESID2_INT"), new DataColumn("MEDICINEID_CHR"), new DataColumn("MEDICINENAME_VCHr"),new DataColumn("medicinetypeid_chr"),
                new DataColumn("MEDSPEC_VCHR"),new DataColumn("OPUNIT_CHR"),new DataColumn("NETAMOUNT_INT",typeof(double)),new DataColumn("LOTNO_VCHR"),new DataColumn("INSTORAGEID_VCHR"),new DataColumn("CALLPRICE_INT",typeof(double)),
                new DataColumn("WHOLESALEPRICE_INT",typeof(double)),new DataColumn("RETAILPRICE_INT",typeof(double)),new DataColumn("VENDORID_CHR"),new DataColumn("vendorname_vchr"),new DataColumn("productorid_chr"),
                new DataColumn("inmoney",typeof(double)),new DataColumn("retailmoney",typeof(double)),new DataColumn("instoragedate_dat"),new DataColumn("validperiod_dat"),new DataColumn("realgross_int",typeof(double)),new DataColumn("assistcode_chr"),
                new DataColumn("availagross_int",typeof(double)),new DataColumn("storageunit"),new DataColumn("askamount"),new DataColumn("originality_Amount"),new DataColumn("allrealgross",typeof(double)), new DataColumn("allavagross",typeof(double)), 
                new DataColumn("oldgross_int",typeof(double)), new DataColumn("packqty_dec",typeof(double)), new DataColumn("ipunit_chr",typeof(string)),new DataColumn("typecode_vchr",typeof(string)),new DataColumn("PRODUCEDATE_DAT",typeof(DateTime)),new DataColumn("WHOLESALEPRICE_SUM",typeof(double))};
            p_dtbMedicineTalbe.Columns.AddRange(dcColumns);

            p_dtbMedicineTalbe.Columns["inmoney"].Expression = "callprice_int * netamount_int";
            p_dtbMedicineTalbe.Columns["retailmoney"].Expression = "retailprice_int * netamount_int";
            p_dtbMedicineTalbe.Columns["WHOLESALEPRICE_SUM"].Expression = "WHOLESALEPRICE_INT * netamount_int";
        } 
        #endregion

        #region 插入新的一行药品出库信息

        /// <summary>
        /// 插入新的一行药品出库信息

        /// </summary>
        internal void m_mthInsertNewMedicineDate()
        {
            if (m_objViewer.m_dtbOutMedicine == null)
            {
                return;
            }

            DataRow drNew = m_objViewer.m_dtbOutMedicine.NewRow();
            m_objViewer.m_dtbOutMedicine.Rows.Add(drNew);

            m_objViewer.m_dgvMedicineOutInfo.Focus();
            m_objViewer.m_dgvMedicineOutInfo.CurrentCell = m_objViewer.m_dgvMedicineOutInfo[1, m_objViewer.m_dgvMedicineOutInfo.RowCount - 1];

            if (m_objViewer.Text.Length < 4)
            {
                string strStorageName;
                m_objDomain.m_lngGetStoreRoomName(m_objViewer.m_strStorageID, out strStorageName);
                m_objViewer.Text += "(" + strStorageName + ")";
            }
        } 
        #endregion

        #region 初始化药品字典最小元素集信息
        /// <summary>
        /// 初始化药品字典最小元素集信息
        /// </summary>
        /// <param name="p_dtbMedicineInfo"></param>
        internal void m_mthInitMedicineInfo(ref DataTable p_dtbMedicineInfo)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetBaseMedicineNotZero(string.Empty, m_objViewer.m_strStorageID, out p_dtbMedicineInfo);
        }
        #endregion

        #region 显示药品字典最小元素信息查询窗体


        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        /// <param name="p_dtbMedicint">字典内容</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon, DataTable p_dtbMedicint)
        {
            System.Windows.Forms.DataGridViewCell cCell = this.m_objViewer.m_dgvMedicineOutInfo.CurrentCell;

            System.Drawing.Rectangle rect =
                m_objViewer.m_dgvMedicineOutInfo.GetCellDisplayRectangle(cCell.ColumnIndex,
                cCell.RowIndex, true);

            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(p_dtbMedicint,true);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                m_ctlQueryMedicint.BeforeReturnInfo += new BeforeReturnMedicineInfo(m_ctlQueryMedicint_BeforeReturnInfo);
                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
            }
            m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineOutInfo.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineOutInfo.Location.Y + rect.Height);
            if ((m_objViewer.Size.Height - m_ctlQueryMedicint.Location.Y) < m_ctlQueryMedicint.Size.Height)
            {
                m_ctlQueryMedicint.Location = new System.Drawing.Point(rect.X + m_objViewer.m_dgvMedicineOutInfo.Location.X,
                rect.Y + m_objViewer.m_dgvMedicineOutInfo.Location.Y - m_ctlQueryMedicint.Size.Height);
            }

            m_ctlQueryMedicint.m_blnNotShowZero = true;
            m_ctlQueryMedicint.m_strStorageID = m_objViewer.m_strStorageID;
            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);            
        }

        private long m_ctlQueryMedicint_BeforeReturnInfo(string p_strMedicineID)
        {
            long lngReturn = 1;

            double dblGrossTemp = 0d;
            clsDcl_Storage objSTDomain = new clsDcl_Storage();
            long lngRes = objSTDomain.m_lngGetAvailaGross(m_objViewer.m_strStorageID, p_strMedicineID, out dblGrossTemp);
            if (dblGrossTemp <= 0)
            {
                MessageBox.Show("此药品已无可用库存", "药库出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_ctlQueryMedicint.Visible = true;
                m_ctlQueryMedicint.Focus();
                lngReturn = -1;
            }
            return lngReturn;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }
            int intRowIndex = m_objViewer.m_dgvMedicineOutInfo.CurrentCell.RowIndex;
            int intColumnIndex = m_objViewer.m_dgvMedicineOutInfo.CurrentCell.ColumnIndex;

            if (m_objViewer.m_dtbOutMedicine != null)
            {
                //DataRow[] drOld = m_objViewer.m_dtbOutMedicine.Select("MEDICINEID_CHR = '" + MS_VO.m_strMedicineID + "'");
                //if (drOld != null && drOld.Length > 0)
                //{
                //    MessageBox.Show("本出库单已选择此药", "药库出库", MessageBoxButtons.OK, MessageBoxIcon.Error);

                //    m_objViewer.m_dgvMedicineOutInfo.CurrentCell = m_objViewer.m_dgvMedicineOutInfo.Rows[intRowIndex].Cells["m_dgvtxtMedicineCode"];
                //}
                //else
                //检查本出库单之前是否已录入相同药品且已调价
                DataRowView dtvTemp = null;
                bool bolAdjustrice;
                for (int iRow = 0; iRow < m_objViewer.m_dgvMedicineOutInfo.Rows.Count; iRow++)
                {
                    if (m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].DataBoundItem == null) continue;
                    dtvTemp = m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].DataBoundItem as DataRowView;
                    if (dtvTemp["MEDICINEID_CHR"].ToString() == MS_VO.m_strMedicineID && iRow != intRowIndex)
                    {
                        DataGridViewRow dgr = m_objViewer.m_dgvMedicineOutInfo.Rows[iRow];
                        m_mthGetAdjustrice(dtvTemp["medicineid_chr"].ToString(),
                            dtvTemp["lotno_vchr"].ToString(), dtvTemp["instorageid_vchr"].ToString(),
                            Convert.ToDateTime(dtvTemp["VALIDPERIOD_DAT"]), Convert.ToDouble(dtvTemp["CALLPRICE_INT"]), out bolAdjustrice);
                        if (bolAdjustrice)
                        {
                            MessageBox.Show("此药品列表包含已调价记录的相同药品,因此不能再选择此药品！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            m_objViewer.m_dgvMedicineOutInfo.Focus();
                            return ;
                        }
                    }
                }



                DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvMedicineOutInfo.CurrentCell.OwningRow.DataBoundItem)).Row;
                drCurrent["assistcode_chr"] = MS_VO.m_strMedicineCode;
                drCurrent["MEDICINENAME_VCHr"] = MS_VO.m_strMedicineName;
                drCurrent["MEDSPEC_VCHR"] = MS_VO.m_strMedicineSpec;
                drCurrent["OPUNIT_CHR"] = MS_VO.m_strMedicineUnit;
                drCurrent["productorid_chr"] = MS_VO.m_strManufacturer;
                drCurrent["MEDICINEID_CHR"] = MS_VO.m_strMedicineID;
                drCurrent["medicinetypeid_chr"] = MS_VO.m_strMedicineTypeID;
                drCurrent["ipunit_chr"] = MS_VO.m_strIpUnit_chr;
                drCurrent["packqty_dec"] = Convert.ToDecimal(MS_VO.m_strPackqty_dec);
                m_objViewer.m_dgvMedicineOutInfo.CurrentCell = m_objViewer.m_dgvMedicineOutInfo.Rows[intRowIndex].Cells["m_dgvtxtOutAmount"];

            }           

            m_objViewer.m_dgvMedicineOutInfo.Refresh();
            m_objViewer.m_dgvMedicineOutInfo.Focus();           
            m_objViewer.m_dgvMedicineOutInfo.CurrentCell.Selected = true;
        }
        #endregion

        #region 显示出库药品选择窗体
        /// <summary>
        /// 显示出库药品选择窗体
        /// </summary>
        /// <param name="p_strAmount"></param>
        internal long m_lngShowMedicineSelect(string p_strAmount)
        {
            double dblAmount = 0d;
            if (!double.TryParse(p_strAmount, out dblAmount))
            {
                MessageBox.Show("数量不能为空且必须为数字","药品出库",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return -1;
            }
            //20080114广医三院提出应可输入负数
            else
            {
                if (dblAmount == 0)
                {
                    MessageBox.Show("数量不能为零", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            if (m_objViewer.m_dgvMedicineOutInfo.CurrentCell == null || m_objViewer.m_dtbOutMedicine == null)
            {
                return -1;
            }

            int intCurrentRow = m_objViewer.m_dgvMedicineOutInfo.CurrentCell.RowIndex;
            DataRow drCurrent = ((DataRowView)(m_objViewer.m_dgvMedicineOutInfo.CurrentCell.OwningRow.DataBoundItem)).Row;
            string strMedicineID = drCurrent["MEDICINEID_CHR"].ToString();
            clsMS_StorageDetail[] objDetail = null;
            clsDcl_Storage objSTDomain = new clsDcl_Storage();
            Hashtable hstPeriod = null;
            long lngRes = 0;

            //检查本出库单之前是否已录入相同药品
            DataRowView dtvTemp = null;
            bool bolAdjustrice;
            for (int iRow = 0; iRow < m_objViewer.m_dgvMedicineOutInfo.Rows.Count; iRow++)
            {
                if (m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].DataBoundItem == null) continue;
                dtvTemp = m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].DataBoundItem as DataRowView;
                if (dtvTemp["MEDICINEID_CHR"].ToString() == strMedicineID && iRow != intCurrentRow && Convert.ToString(dtvTemp["VALIDPERIOD_DAT"]) != "")
                {
                    DataGridViewRow dgr = m_objViewer.m_dgvMedicineOutInfo.Rows[iRow];
                    m_mthGetAdjustrice(dtvTemp["medicineid_chr"].ToString(),
                        dtvTemp["lotno_vchr"].ToString(), dtvTemp["instorageid_vchr"].ToString(),
                        Convert.ToDateTime(dtvTemp["VALIDPERIOD_DAT"]), Convert.ToDouble(dtvTemp["CALLPRICE_INT"]), out bolAdjustrice);
                    if (bolAdjustrice)
                    {
                        m_objViewer.m_dgvMedicineOutInfo["m_dgvtxtOutAmount", intCurrentRow].Value = m_objViewer.dblNetAmount;
                        MessageBox.Show("此药品列表包含已调价的相同药品,因此不能修改此药品的出库数量！", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        m_objViewer.m_dgvMedicineOutInfo.Focus();
                        return -1;
                    }

                    DialogResult drQ = MessageBox.Show("本出库单已录入此药品，详见第" + (iRow + 1).ToString() + "行，如确定再次录入将与之合并，是否继续？", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drQ == DialogResult.No)
                    {
                        return -1;
                    }
                    else
                    {
                        //DataRowView dtvTmp = null;
                        //for (int i1 = 0; i1 < m_objViewer.m_dgvMedicineOutInfo.Rows.Count; i1++)
                        //{
                        //    dtvTmp = m_objViewer.m_dgvMedicineOutInfo.Rows[i1].DataBoundItem as DataRowView;
                        //    if (dtvTmp["MEDICINEID_CHR"].ToString() == strMedicineID && i1 != intCurrentRow && Convert.ToString(dtvTmp["VALIDPERIOD_DAT"]) != "")
                        //    {
                        //        dblAmount += Convert.ToDouble(m_objViewer.m_dgvMedicineOutInfo["m_dgvtxtOutAmount", i1].Value);
                        //    }
                        //}
                        //dblAmount += Convert.ToDouble(m_objViewer.m_dgvMedicineOutInfo["m_dgvtxtOutAmount", iRow].Value);
                        dblAmount = 0;
                        DataRowView dtvTmp = null;
                        hstPeriod = new Hashtable();
                        for (int i1 = 0; i1 < m_objViewer.m_dgvMedicineOutInfo.Rows.Count; i1++)
                        {
                            if (m_objViewer.m_dgvMedicineOutInfo.Rows[i1].DataBoundItem == null) continue;
                            dtvTmp = m_objViewer.m_dgvMedicineOutInfo.Rows[i1].DataBoundItem as DataRowView;
                            if (dtvTmp["MEDICINEID_CHR"].ToString() == strMedicineID && i1 != intCurrentRow && Convert.ToString(dtvTmp["VALIDPERIOD_DAT"]) != "")
                            {
                                if (i1 == iRow)
                                    hstPeriod.Add(dtvTmp["LOTNO_VCHR"].ToString() + dtvTmp["INSTORAGEID_VCHR"].ToString(), Convert.ToDouble(dtvTmp["NETAMOUNT_INT"]) + Convert.ToDouble(m_objViewer.m_dgvMedicineOutInfo["m_dgvtxtOutAmount", intCurrentRow].Value));
                                else
                                {
                                    if (!hstPeriod.Contains(dtvTmp["LOTNO_VCHR"].ToString() + dtvTmp["INSTORAGEID_VCHR"].ToString()))
                                    {
                                        hstPeriod.Add(dtvTmp["LOTNO_VCHR"].ToString() + dtvTmp["INSTORAGEID_VCHR"].ToString(), Convert.ToDouble(dtvTmp["NETAMOUNT_INT"]));
                                    }
                                }
                            }
                        }
                        break;
                    }
                }
            }
           
            DataRow[] drOld = m_objViewer.m_dtbOutMedicine.Select("MEDICINEID_CHR = '" + strMedicineID + "'");

            Hashtable hstNetAmount = new Hashtable();
            bool blnHasMain = false;//是否已有旧记录，即当前是否处于修改状态


            if (m_objCurrentMain != null)
            {
                blnHasMain = true;
            }
            
            lngRes = objSTDomain.m_lngGetStorageMedicineDetail(strMedicineID, m_objViewer.m_strStorageID, out objDetail);

            double dblAllRealGross = 0d;//总实际库存

            double dblAllAvaGross = 0d;//总可用库存

            double dblOldGross = 0d;

            if (objDetail != null && objDetail.Length > 0)
            {
                for (int iGro = 0; iGro < objDetail.Length; iGro++)
                {
                    dblAllAvaGross += objDetail[iGro].m_dblAVAILAGROSS_INT;
                    dblAllRealGross += objDetail[iGro].m_dblREALGROSS_INT;
                }

                if (blnHasMain)//当前处于修改状态

                {
                    lngRes = m_objDomain.m_lngGetNetAmount(m_objCurrentMain.m_lngSERIESID_INT, strMedicineID, out hstNetAmount);

                    if (drOld != null && drOld.Length > 0)
                    {
                        dblAmount = 0d;
                        double dblTemp = 0d;
                        for (int iOld = 0; iOld < drOld.Length; iOld++)
                        {
                            if (double.TryParse(drOld[iOld]["NETAMOUNT_INT"].ToString(), out dblTemp))
                            {
                                dblAmount += dblTemp;

                                if (drOld[iOld]["CALLPRICE_INT"] == DBNull.Value || drOld[iOld]["VALIDPERIOD_DAT"] == DBNull.Value)
                                {
                                    continue;
                                }
                                string strKey = drOld[iOld]["lotno_vchr"].ToString().PadLeft(10, '0') + drOld[iOld]["instorageid_vchr"].ToString()
                                    + Convert.ToDateTime(drOld[iOld]["VALIDPERIOD_DAT"]).ToString("yyyy-MM-dd HH:mm:ss") + Convert.ToDouble(drOld[iOld]["CALLPRICE_INT"]).ToString("0.0000");

                                if (blnHasMain && hstNetAmount.Contains(strKey))
                                {
                                    double dblTempAmount = 0d;
                                    if (double.TryParse(hstNetAmount[strKey].ToString(), out dblTempAmount))
                                    {
                                        for (int iSD = 0; iSD < objDetail.Length; iSD++)
                                        {
                                            if (drOld[iOld]["lotno_vchr"].ToString() == objDetail[iSD].m_strLOTNO_VCHR && drOld[iOld]["instorageid_vchr"].ToString() == objDetail[iSD].m_strINSTORAGEID_VCHR
                                                && Convert.ToDateTime(drOld[iOld]["VALIDPERIOD_DAT"]) == objDetail[iSD].m_dtmVALIDPERIOD_DAT && Convert.ToDecimal(drOld[iOld]["CALLPRICE_INT"]) == objDetail[iSD].m_dcmCALLPRICE_INT)
                                            {
                                                objDetail[iSD].m_dblAVAILAGROSS_INT += dblTempAmount;
                                                break;
                                            }
                                        }
                                        //lngRes = objSTDomain.m_lngAddStorageDetailAvailaGross(dblTempAmount, drCurrent["MEDICINEID_CHR"].ToString(), drCurrent["LOTNO_VCHR"].ToString(), drCurrent["INSTORAGEID_VCHR"].ToString(), m_objViewer.m_strStorageID);
                                    }
                                }
                            }
                        }
                    }
                }
                
                //可用库存少于出库数量时提示
                double dblAvalidAll = 0;
                for (int i2 = 0; i2 < objDetail.Length; i2++)
                {
                    dblAvalidAll += objDetail[i2].m_dblAVAILAGROSS_INT;
                }
                if (dblAmount > dblAvalidAll)
                {
                    if (MessageBox.Show("当前可用库存少于请求出库库存,是否继续？", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                        return -1;
                }
                frmQueryMedicineInfo frmQMI = new frmQueryMedicineInfo(dblAmount);
                frmQMI.m_strTYPECODE_CHR = m_objViewer.m_intOutStorageType.ToString();
                frmQMI.m_mthSetMedicineVO(objDetail,hstPeriod);
                frmQMI.ShowDialog();

                if (frmQMI.DialogResult == DialogResult.OK)
                {
                    int intFirstRowIndex = 0;//所选药品第一行在DataTable中的索引
                    if (drOld != null && drOld.Length > 0)
                    {
                        for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
                        {
                            if (strMedicineID == m_objViewer.m_dtbOutMedicine.Rows[iRow]["MEDICINEID_CHR"].ToString())
                            {
                                intFirstRowIndex = iRow;
                                break;
                            }
                        }
                        if (drOld[0]["oldgross_int"] != DBNull.Value)
                        {
                            dblOldGross = Convert.ToDouble(drOld[0]["oldgross_int"]);
                        }
                        foreach (DataRow drC in drOld)
                        {
                            m_objViewer.m_dtbOutMedicine.Rows.Remove(drC);
                        }
                    }
                    clsMS_StorageMedicineShow[] objValue = frmQMI.m_ObjOutMedicinArr;
                    m_mthSetOutMedicineVOToTable(objValue, dblAllRealGross, dblAllAvaGross, dblOldGross, intFirstRowIndex);
                }
                else
                {
                    return -1;
                }
                //else
                //{
                //    if (drOld != null && drOld.Length > 0 && blnHasMain)
                //    {
                //        for (int iOld = 0; iOld < drOld.Length; iOld++)
                //        {
                //            if (hstNetAmount.Contains(drOld[iOld]["lotno_vchr"].ToString()))
                //            {
                //                double dblTempAmount = 0d;
                //                if (double.TryParse(hstNetAmount[drOld[iOld]["lotno_vchr"].ToString()].ToString(), out dblTempAmount))
                //                {
                //                    lngRes = objSTDomain.m_lngSubStorageDetailAvailaGross(dblTempAmount, drCurrent["MEDICINEID_CHR"].ToString(), drCurrent["LOTNO_VCHR"].ToString(), drCurrent["INSTORAGEID_VCHR"].ToString(), Convert.ToDouble(drCurrent["CALLPRICE_INT"]), Convert.ToDateTime(drCurrent["VALIDPERIOD_DAT"]), m_objViewer.m_strStorageID);
                //                }
                //            }
                //        }
                //    }
                //}
            }
            else
            {
                MessageBox.Show("没有当前选择药品库存信息","药品出库",MessageBoxButtons.OK,MessageBoxIcon.Stop);
                return -1;
            }
            return lngRes;
        } 
        #endregion

        #region 设置出库药品信息至界面

        /// <summary>
        /// 设置出库药品信息至界面

        /// </summary>
        /// <param name="p_objValue">出库药品信息</param>
        /// <param name="p_dblAllRealGross">总实际库存</param>
        /// <param name="p_dblAllAvaGross">总可用库存</param>
        /// <param name="p_intFirstRowIndex">所选药品第一行在DataTable中的索引</param>
        internal void m_mthSetOutMedicineVOToTable(clsMS_StorageMedicineShow[] p_objValue, double p_dblAllRealGross, double p_dblAllAvaGross,double p_dblOldGross, int p_intFirstRowIndex)
        {
            if (p_objValue == null || p_objValue.Length == 0 )
            {
                return;
            }

            //DataRow drFirst = m_objViewer.m_dtbOutMedicine.Rows[m_objViewer.m_dgvMedicineOutInfo.CurrentCell.RowIndex];
            //m_mthAddDataToRow(drFirst, p_objValue[0]);

            int intRowsCount = m_objViewer.m_dtbOutMedicine.Rows.Count;
           
            //去除最后一行空行

            //if (intRowsCount > 0 && m_objViewer.m_dtbOutMedicine.Rows[intRowsCount - 1]["availagross_int"] == DBNull.Value)
            //{
            //    m_objViewer.m_dtbOutMedicine.Rows.RemoveAt(intRowsCount - 1);
            //}
            if (intRowsCount > 0)//去除空行
            {
                DataRow[] drNull = m_objViewer.m_dtbOutMedicine.Select("availagross_int is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow drTemp in drNull)
                    {
                        m_objViewer.m_dtbOutMedicine.Rows.Remove(drTemp);
                    }
                }
            }

            //m_objViewer.m_dtbOutMedicine.BeginLoadData();
            for (int iRow = 0; iRow < p_objValue.Length; iRow++)
            {
                DataRow drNew = m_objViewer.m_dtbOutMedicine.NewRow();
                m_mthAddDataToRow(drNew, p_objValue[iRow],p_dblAllRealGross,p_dblAllAvaGross,p_dblOldGross);
                m_objViewer.m_dtbOutMedicine.Rows.InsertAt(drNew, p_intFirstRowIndex);//要将新行插入至指定位置

                p_intFirstRowIndex++;
                //m_objViewer.m_dtbOutMedicine.LoadDataRow(drNew.ItemArray, true);
            }
            //m_objViewer.m_dtbOutMedicine.EndLoadData();
        }

        /// <summary>
        /// 添加数据至指定行
        /// </summary>
        /// <param name="p_drRow">数据行</param>
        /// <param name="p_objValue">出库药品信息</param>
        /// <param name="p_dblAllRealGross">总实际库存</param>
        /// <param name="p_dblAllAvaGross">总可用库存</param>
        private void m_mthAddDataToRow(DataRow p_drRow, clsMS_StorageMedicineShow p_objValue, double p_dblAllRealGross, double p_dblAllAvaGross, double p_dblOldGross)
        {
            if (p_drRow == null || p_objValue == null)
            {
                return;
            }

            p_drRow["MEDICINEID_CHR"] = p_objValue.m_strMEDICINEID_CHR;
            p_drRow["MEDICINENAME_VCHR"] = p_objValue.m_strMEDICINENAME_VCHR;
            p_drRow["MEDSPEC_VCHR"] = p_objValue.m_strMEDSPEC_VCHR;
            p_drRow["storageunit"] = p_objValue.m_strOPUNIT_VCHR;
            p_drRow["OPUNIT_CHR"] = p_objValue.m_strOPUNIT_VCHR;
            p_drRow["NETAMOUNT_INT"] = p_objValue.m_dblOutAmount.ToString("0.00");
            p_drRow["LOTNO_VCHR"] = p_objValue.m_strLOTNO_VCHR;
            p_drRow["INSTORAGEID_VCHR"] = p_objValue.m_strINSTORAGEID_VCHR;
            p_drRow["CALLPRICE_INT"] = p_objValue.m_dcmCALLPRICE_INT.ToString("0.0000");
            p_drRow["WHOLESALEPRICE_INT"] = p_objValue.m_dcmWHOLESALEPRICE_INT.ToString("0.0000");
            p_drRow["RETAILPRICE_INT"] = p_objValue.m_dcmRETAILPRICE_INT.ToString("0.0000");
            p_drRow["VENDORID_CHR"] = p_objValue.m_strVENDORID_CHR;
            p_drRow["vendorname_vchr"] = p_objValue.m_strVENDORName;
            p_drRow["productorid_chr"] = p_objValue.m_strPRODUCTORID_CHR;
            p_drRow["instoragedate_dat"] = p_objValue.m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
            p_drRow["validperiod_dat"] = p_objValue.m_dtmVALIDPERIOD_DAT.ToString("yyyy-MM-dd");
            p_drRow["realgross_int"] = p_objValue.m_dblREALGROSS_INT.ToString("0.00");
            p_drRow["assistcode_chr"] = p_objValue.m_strMEDICINECode;
            p_drRow["availagross_int"] = p_objValue.m_dblAVAILAGROSS_INT.ToString("0.00");
            //p_drRow["inmoney"] = (p_objValue.m_dblOutAmount * (double)p_objValue.m_dcmCALLPRICE_INT).ToString("0.0000");
            //p_drRow["retailmoney"] = (p_objValue.m_dblOutAmount * (double)p_objValue.m_dcmRETAILPRICE_INT).ToString("0.0000");
            p_drRow["allrealgross"] = p_dblAllRealGross.ToString("0.00");
            p_drRow["allavagross"] = p_dblAllAvaGross.ToString("0.00");
            p_drRow["medicinetypeid_chr"] = p_objValue.m_strMedicineTypeID_chr;
            p_drRow["oldgross_int"] = p_dblOldGross;
            p_drRow["ipunit_chr"] = p_objValue.m_strIPUnit;
            p_drRow["packqty_dec"] = p_objValue.m_dblPackQty;
            p_drRow["typecode_vchr"] = p_objValue.m_strTYPECODE_CHR;
            p_drRow["producedate_dat"] = p_objValue.m_dtmPRODUCEDATE_DAT;
            p_drRow.EndEdit();
        }
        #endregion

        #region 获取审核流程设置
        /// <summary>
        /// 获取审核流程设置
        /// </summary>
        /// <param name="p_intCommitFolw">审核流程设置</param>
        /// <returns></returns>
        internal void m_mthGetCommitFlow(out int p_intCommitFolw)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetCommitFlow(out p_intCommitFolw);
        }
        #endregion

        #region 获取是否审核即入帐

        /// <summary>
        /// 获取是否审核即入帐

        /// </summary>
        /// <param name="p_blnIsImmAccount">是否审核即入帐</param>
        internal void m_mthGetIsImmAccount(out bool p_blnIsImmAccount)
        {
            clsDcl_Purchase_Detail objPDDomain = new clsDcl_Purchase_Detail();
            long lngRes = objPDDomain.m_lngGetIsImmAccount(out p_blnIsImmAccount);
            objPDDomain = null;
        }
        #endregion

        #region 设置是否显示领用人


        /// <summary>
        /// 设置是否显示领用人

        /// </summary>
        internal void m_mthGetIsShowReceiptor()
        {
            bool blnIsShowReceiptor = false;
            long lngRes = m_objDomain.m_lngGetIsShowReceiptor(out blnIsShowReceiptor);
            if (blnIsShowReceiptor)
            {
                m_objViewer.m_txtReceiptor.Visible = true;
                m_objViewer.m_lblReceiptor.Visible = true;
            }
            else
            {
                m_objViewer.m_txtReceiptor.Visible = false;
                m_objViewer.m_lblReceiptor.Visible = false;
            }
        }
        #endregion

        #region 保存药品出库信息
        /// <summary>
        /// 保存药品出库信息
        /// </summary>
        /// <param name="p_blnWantHint">是否需要提示</param>
        /// <returns></returns>
        internal long m_lngSaveOutStorageInfo(bool p_blnWantHint)
        {
            #region 有效性检查
            //20090721:保存、删除、审核单据时，均判断是否新制状态
            if (m_objViewer.m_txtOutputOrder.Text.Length > 0)
            {
                bool blnNewState = false;
                clsDcl_Purchase_Detail clsDcl = new clsDcl_Purchase_Detail();
                clsDcl.m_lngCheckBillState(2, m_objViewer.m_txtOutputOrder.Text.Trim(), out blnNewState);
                if (!blnNewState)
                {
                    MessageBox.Show("该出库单不是新制状态，请关闭并刷新后重试", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return -1;
                }
            }

            this.m_objViewer.m_dgvMedicineOutInfo.EndEdit();
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS != 1 && p_blnWantHint)
            {
                if (m_objCurrentMain.m_intSTATUS == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品出库记录已入帐，不能修改", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品出库记录已审核，不能修改", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }


            DateTime datOutTime;
            m_objDomain.m_mthGetAccountperiodTime(out datOutTime);
            if (Convert.ToDateTime(m_objViewer.m_dtpDate.Tag) < datOutTime)
            {
                MessageBox.Show("制单日期不能小于上次帐务结转的结束日期。\r\n上次结转结束日期是：" + datOutTime.ToString("yyyy年MM月dd日"), "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_objViewer.m_dtpDate.Focus();
                return -1;
            }

            if (string.IsNullOrEmpty(m_objViewer.m_txtReceiveDept.StrItemId) && p_blnWantHint)
            {
                MessageBox.Show("必须选择领用部门", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            //if (string.IsNullOrEmpty(Convert.ToString(m_objViewer.m_txtReceiptor.Tag)) && p_blnWantHint)
            //{
            //    MessageBox.Show("必须选择领用人", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return -1;
            //}
            if ((m_objViewer.m_dtbOutMedicine == null || m_objViewer.m_dtbOutMedicine.Rows.Count == 0) && p_blnWantHint)
            {
                MessageBox.Show("请先选择出库药品", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
            else if (m_objViewer.m_dtbOutMedicine.Rows.Count == 1)//只有一行自动添加的空数据

            {
                if (m_objViewer.m_dtbOutMedicine.Rows[0]["availagross_int"] == DBNull.Value)
                {
                    MessageBox.Show("请先选择出库药品", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }

            double dblAmount = 0d;
            DataRow drTemp = null;
            for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
            {
                drTemp = m_objViewer.m_dtbOutMedicine.Rows[iRow];
                if (drTemp.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (drTemp["MEDICINEID_CHR"] != DBNull.Value && drTemp["availagross_int"] != DBNull.Value)
                {
                    if (!double.TryParse(drTemp["NETAMOUNT_INT"].ToString(), out dblAmount))
                    {
                        MessageBox.Show("出库数量必须为数字", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                    else
                    {
                        //if (dblAmount <= 0)
                        //{
                        //    MessageBox.Show("出库数量必须为大于零数字", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return -1;
                        //}
                        //else 
                        //{
                            double dblOriAmount = 0d;
                            if (double.TryParse(drTemp["originality_Amount"].ToString(), out dblOriAmount))
                            {
                                if ((dblAmount - dblOriAmount) > Convert.ToDouble(drTemp["availagross_int"]))
                                {
                                    MessageBox.Show("出库数量必须小于可用库存", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return -1;
                                }
                            }
                            else if (dblAmount > Convert.ToDouble(drTemp["availagross_int"]))
                            {
                                MessageBox.Show("出库数量必须小于可用库存", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return -1;
                            }
                        //}
                    }
                }
            }
            #endregion

            //检查是否有重复记录

            for (int intRow = 0; intRow < m_objViewer.m_dtbOutMedicine.Rows.Count; intRow++)
            {
                #region 去除空行
                DataRow[] drNull = m_objViewer.m_dtbOutMedicine.Select("availagross_int is null");
                if (drNull != null && drNull.Length > 0)
                {
                    foreach (DataRow drDel in drNull)
                    {
                        m_objViewer.m_dtbOutMedicine.Rows.Remove(drDel);
                    }
                }
                #endregion

                DataRow[] drOld = m_objViewer.m_dtbOutMedicine.Select("MEDICINEID_CHR = '" + m_objViewer.m_dtbOutMedicine.Rows[intRow]["MEDICINEID_CHR"].ToString() + "' and LOTNO_VCHR = '"
                    + m_objViewer.m_dtbOutMedicine.Rows[intRow]["LOTNO_VCHR"].ToString() + "' and INSTORAGEID_VCHR = '" + m_objViewer.m_dtbOutMedicine.Rows[intRow]["INSTORAGEID_VCHR"].ToString()
                    + "' and validperiod_dat = '" + m_objViewer.m_dtbOutMedicine.Rows[intRow]["validperiod_dat"].ToString() + "' and CALLPRICE_INT = " + m_objViewer.m_dtbOutMedicine.Rows[intRow]["CALLPRICE_INT"].ToString());
                if (drOld != null && drOld.Length > 1)
                {
                    DialogResult drResult = MessageBox.Show("本出库单有重复药品(" + drOld[0][3].ToString() + "),是否继续保存", "药品出库", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (drResult == DialogResult.No)
                    {
                        return -1;
                    }

                    double dblNetamount = 0;
                    for (int intDr = 0; intDr < drOld.Length; intDr++)
                    {
                        dblNetamount += Convert.ToDouble(drOld[intDr]["netamount_int"]);
                    }
                    
                    drOld[0]["netamount_int"] = dblNetamount;
                    DataRow drNew = m_objViewer.m_dtbOutMedicine.NewRow();
                    drNew.ItemArray = drOld[0].ItemArray;
                    drNew[0] = drOld[0][0].ToString();
                    foreach (DataRow drDel in drOld)
                    {
                        m_objViewer.m_dtbOutMedicine.Rows.Remove(drDel);
                    }
                    m_objViewer.m_dtbOutMedicine.Rows.Add(drNew);

                }
            }


            long lngRes = 0;

            try
            {
                bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;
                bool blnIsAddNew = m_objViewer.m_lngMainSEQ == 0 ? true : false;
                clsMS_OutStorage_VO objMain = m_objGetMainISVO();
                DataRow[] drNew = m_objViewer.m_dtbOutMedicine.Select("availagross_int is not null and NETAMOUNT_INT is not null");
                clsMS_OutStorageDetail_VO[] objDetailArr = m_objGetDetailArr(drNew,m_objViewer.m_dtbOutMedicine, objMain.m_lngSERIESID_INT);
                lngRes = m_objDomain.m_lngSaveOutStorage(ref objMain, m_objCurrentSubArr, ref objDetailArr, blnIsCommit, blnIsAddNew,m_objViewer.m_blnIsImmAccount);

                if (lngRes > 0)
                {
                    m_objViewer.m_lngMainSEQ = objMain.m_lngSERIESID_INT;
                    m_objViewer.m_txtOutputOrder.Text = objMain.m_strOUTSTORAGEID_VCHR;
                    m_objCurrentMain = objMain;
                    m_objCurrentSubArr = objDetailArr;

                    m_mthSetSeriesIDToUI(objDetailArr);
                    m_mthSetOldgrossToUI(objDetailArr);
                    #region 去除空行
                    DataRow[] drNull = m_objViewer.m_dtbOutMedicine.Select("availagross_int is null");
                    if (drNull != null && drNull.Length > 0)
                    {
                        foreach (DataRow drDel in drNull)
                        {
                            m_objViewer.m_dtbOutMedicine.Rows.Remove(drDel);
                        }
                    }
                    #endregion

                    m_objViewer.m_dtbOutMedicine.AcceptChanges();

                    if (blnIsCommit)
                    {
                        if (m_objViewer.m_blnIsImmAccount)
                        {
                            m_objCurrentMain.m_intSTATUS = 3;
                            m_objViewer.m_cmdSave.Enabled = false;
                            m_objViewer.m_cmdDelete.Enabled = false;
                            m_objViewer.m_cmdInsertRecord.Enabled = false;
                            m_objViewer.m_cmdNext.Enabled = false;
                            m_objViewer.panel1.Enabled = false;
                            m_objViewer.m_dgvMedicineOutInfo.ReadOnly = true;
                            //m_objViewer.m_dgvMedicineOutInfo.AllowUserToAddRows = false;
                        }
                        else
                        {
                            m_objCurrentMain.m_intSTATUS = 2;
                            m_objViewer.m_cmdSave.Enabled = true;
                            m_objViewer.m_cmdDelete.Enabled = true;
                            m_objViewer.m_cmdInsertRecord.Enabled = true;
                            m_objViewer.m_cmdNext.Enabled = true;
                            m_objViewer.panel1.Enabled = true;
                            m_objViewer.m_dgvMedicineOutInfo.ReadOnly = false;
                            //m_objViewer.m_dgvMedicineOutInfo.AllowUserToAddRows = true;
                        }                        
                    }
                    if (p_blnWantHint)
                    {
                        MessageBox.Show("保存成功", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("保存失败", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            catch (Exception Ex)
            {
                string strExMessage = "保存失败" + Environment.NewLine + Ex.Message;
                MessageBox.Show(strExMessage, "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }            
            
            return lngRes;
        }

        /// <summary>
        /// 更新界面数据的序列号
        /// </summary>
        /// <param name="p_objDetailArr">药品出库明细</param>
        private void m_mthSetSeriesIDToUI(clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            if (m_objViewer.m_dtbOutMedicine != null && m_objViewer.m_dtbOutMedicine.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
                {
                    if (iRow < p_objDetailArr.Length)
                    {
                        m_objViewer.m_dtbOutMedicine.Rows[iRow]["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        m_objViewer.m_dtbOutMedicine.Rows[iRow]["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                    }                    
                }
            }
        }
        #endregion

        #region 更新界面数据的当前可用库存数
        /// <summary>
        /// 更新界面数据的当前可用库存数
        /// </summary>
        /// <param name="p_objDetailArr">药品出库明细</param>
        private void m_mthSetOldgrossToUI(clsMS_OutStorageDetail_VO[] p_objDetailArr)
        {
            if (m_objViewer.m_dtbOutMedicine != null && m_objViewer.m_dtbOutMedicine.Rows.Count > 0)
            {
                for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
                {
                    for (int iTemRow = 0; iTemRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iTemRow++)
                    {
                        if (m_objViewer.m_dtbOutMedicine.Rows[iTemRow]["medicineid_chr"].ToString() == p_objDetailArr[iRow].m_strMEDICINEID_CHR)
                        {
                            m_objViewer.m_dtbOutMedicine.Rows[iTemRow]["oldgross_int"] = p_objDetailArr[iRow].m_dblOldGross;
                        }
                    }
                }
            }
        }
        #endregion

        #region 获取主表内容
        /// <summary>
        /// 获取主表内容
        /// </summary>
        /// <returns></returns>
        private clsMS_OutStorage_VO m_objGetMainISVO()
        {
            if (m_objCurrentMain == null)
            {
                m_objCurrentMain = new clsMS_OutStorage_VO();
                m_objCurrentMain.m_dtmASKDATE_DAT = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                m_objCurrentMain.m_intSTATUS = 1;
            }

            m_objCurrentMain.m_strASKDEPT_CHR = m_objViewer.m_txtReceiveDept.StrItemId.Trim();
            m_objCurrentMain.m_intOutStorageTYPE_INT = m_objViewer.m_intOutStorageType;
            m_objCurrentMain.m_intFORMTYPE_INT = 1;
            m_objCurrentMain.m_strASKERID_CHR = m_objViewer.m_txtMan.Tag.ToString();
            m_objCurrentMain.m_strCOMMENT_VCHR = m_objViewer.m_txtRemark.Text;
            m_objCurrentMain.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
            m_objCurrentMain.m_dtmOutStorageDate = Convert.ToDateTime(m_objViewer.m_dtpDate.Text);
            if (m_objViewer.m_txtReceiptor.Tag != null)
            {
                m_objCurrentMain.m_strRECEIPTORID_CHR = m_objViewer.m_txtReceiptor.Tag.ToString();
            }
            else
            {
                m_objCurrentMain.m_strRECEIPTORID_CHR = string.Empty;
            }
            return m_objCurrentMain;
        }  
        #endregion

        #region 获取子表内容
        /// <summary>
        /// 获取子表内容
        /// </summary>
        /// <param name="p_drDetail">子表数据</param>
        /// <param name="p_lngMainSEQ">主表序列</param>
        /// <returns></returns>
        private clsMS_OutStorageDetail_VO[] m_objGetDetailArr(DataRow[] p_drDetail,DataTable p_OutDtbVal, long p_lngMainSEQ)
        {
            clsMS_OutStorageDetail_VO[] objDetailArr = null;
            if (p_drDetail == null || p_drDetail.Length == 0)
            {
                return null;
            }
            //DataTable p_OutDtbVal = new DataTable();
            DataTable dtb = new DataTable();
            objDetailArr = new clsMS_OutStorageDetail_VO[p_drDetail.Length];
            decimal m_dblPackqty = 0;
            DateTime datTemp;
            for (int iRow = 0; iRow < p_drDetail.Length; iRow++)
            {
                objDetailArr[iRow] = new clsMS_OutStorageDetail_VO();
                objDetailArr[iRow].m_lngSERIESID2_INT = p_lngMainSEQ;
                objDetailArr[iRow].m_strMEDICINEID_CHR = p_drDetail[iRow]["MEDICINEID_CHR"].ToString();
                objDetailArr[iRow].m_strMEDICINENAME_VCH = p_drDetail[iRow]["MEDICINENAME_VCHR"].ToString();
                objDetailArr[iRow].m_strMEDSPEC_VCHR = p_drDetail[iRow]["MEDSPEC_VCHR"].ToString();
                objDetailArr[iRow].m_strOPUNIT_CHR = p_drDetail[iRow]["OPUNIT_CHR"].ToString().Trim(); ;
                objDetailArr[iRow].m_dblNETAMOUNT_INT = Convert.ToDouble(p_drDetail[iRow]["NETAMOUNT_INT"]);
                objDetailArr[iRow].m_strIPUnit = p_drDetail[iRow]["ipunit_chr"].ToString();
                decimal.TryParse(p_drDetail[iRow]["packqty_dec"].ToString(), out m_dblPackqty);
                objDetailArr[iRow].m_decPackQty = m_dblPackqty;// Convert.ToDecimal(p_drDetail[iRow]["packqty_dec"].ToString()); 
                clsMS_MedicineTypeVisionmSet clsTypeVO = new clsMS_MedicineTypeVisionmSet();
                m_objDomain.m_lngGetMedicineTypeVisionm(p_drDetail[iRow]["medicinetypeid_chr"].ToString(),out clsTypeVO);
                if (/*clsTypeVO != null && clsTypeVO.m_intLotno == 0 &&*/ p_drDetail[iRow]["LOTNO_VCHR"].ToString().Trim() == "")
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = "UNKNOWN";
                }
                else
                {
                    objDetailArr[iRow].m_strLOTNO_VCHR = p_drDetail[iRow]["LOTNO_VCHR"].ToString();
                }

                objDetailArr[iRow].m_strINSTORAGEID_VCHR = p_drDetail[iRow]["INSTORAGEID_VCHR"].ToString();
                objDetailArr[iRow].m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drDetail[iRow]["CALLPRICE_INT"]);
                objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(p_drDetail[iRow]["WHOLESALEPRICE_INT"]);
                objDetailArr[iRow].m_dcmRETAILPRICE_INT = Convert.ToDecimal(p_drDetail[iRow]["RETAILPRICE_INT"]);
                objDetailArr[iRow].m_strVENDORID_CHR = p_drDetail[iRow]["VENDORID_CHR"].ToString();
                objDetailArr[iRow].m_strVendorName = p_drDetail[iRow]["vendorname_vchr"].ToString();
                objDetailArr[iRow].m_dtmValidperiod_dat = Convert.ToDateTime(p_drDetail[iRow]["validperiod_dat"]);
                objDetailArr[iRow].m_strProductorID_chr = p_drDetail[iRow]["productorid_chr"].ToString();
                objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(p_drDetail[iRow]["instoragedate_dat"]);
                objDetailArr[iRow].m_strMedicineTypeID_chr = p_drDetail[iRow]["medicinetypeid_chr"].ToString();
                objDetailArr[iRow].m_dblRealGross = Convert.ToDouble(p_drDetail[iRow]["realgross_int"]);
                objDetailArr[iRow].m_dblAvailaGross = Convert.ToDouble(p_drDetail[iRow]["allrealgross"]);

               // objDetailArr[iRow].m_dblOldGross = Convert.ToDouble(p_drDetail[iRow]["allrealgross"]);

                objDetailArr[iRow].m_intStatus = 1;
                objDetailArr[iRow].m_intRETURNNUM_INT = 0;
                objDetailArr[iRow].m_strTYPECODE_CHR = p_drDetail[iRow]["typecode_vchr"].ToString();
                if(DateTime.TryParse(p_drDetail[iRow]["producedate_dat"].ToString(),out datTemp))
                {
                    objDetailArr[iRow].m_dtmPRODUCEDATE_DAT = datTemp;
                }

            }

            #region 当前库存计算(只在打印时显示，不在界面显示)

            double dblSum = 0;
            double dblSumAllrealgross = 0;
            double dblNewAmount = 0;
            double dblOldGross = 0;
            double dblOldAmount = 0;
            int intTemRow;
            dtb = p_OutDtbVal.Copy();
            List<string> lstMedid = new List<string>();
            clsDcl_Storage objSTDomain = new clsDcl_Storage();
            clsMS_StorageDetail[] objDetail = null;
            int intRow;

            for (intRow = 0; intRow < p_drDetail.Length; intRow++)
            {
                if (intRow + 2 > p_drDetail.Length || p_drDetail[intRow]["medicineid_chr"].ToString() != p_drDetail[intRow + 1]["medicineid_chr"].ToString())
                {
                    lstMedid.Add(p_drDetail[intRow]["medicineid_chr"].ToString());
                }
            }

            for (intRow = 0; intRow < lstMedid.Count; intRow++)
            {
                //当前界面实发数量总和
                //for (intTemRow = 0; intTemRow < p_drDetail.Length; intTemRow++)
                //{
                //    if (p_drDetail[intTemRow]["medicineid_chr"].ToString() == lstMedid[intRow].ToString())
                //    {
                //        dblNewAmount += Convert.ToDouble(p_drDetail[intTemRow]["netamount_int"]);

                //        if (p_drDetail[intTemRow]["oldgross_int"] != DBNull.Value)
                //        {
                //            dblOldGross = Convert.ToDouble(p_drDetail[intTemRow]["oldgross_int"]);
                //        }
                //    }
                //}

                for (int iRow = 0; iRow < m_objViewer.m_dgvMedicineOutInfo.Rows.Count; iRow++)
                {
                    if (m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].Cells[20].Value != DBNull.Value)
                    {
                        if (m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].Cells[20].Value.ToString() == lstMedid[intRow].ToString())
                        {
                            dblNewAmount += Convert.ToDouble(m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].Cells[5].Value);
                            if (m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].Cells[21].Value != DBNull.Value)
                            {
                                dblOldGross = Convert.ToDouble(m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].Cells[21].Value);
                            }
                        }
                    }
                }


                //获取总可用库存

                objSTDomain.m_lngGetStorageMedicineDetail(lstMedid[intRow].ToString(), m_objViewer.m_strStorageID, out objDetail);
                for (intTemRow = 0; intTemRow < objDetail.Length; intTemRow++)
                {
                    dblSumAllrealgross += objDetail[intTemRow].m_dblAVAILAGROSS_INT;
                }

                if (m_objCurrentSubArr == null) //新制
                {
                    dblSum = dblSumAllrealgross - dblNewAmount;
                }
                else　//修改
                {
                    //获取未作修改前的实发数量总和
                    for (intTemRow = 0; intTemRow < m_objCurrentSubArr.Length; intTemRow++)
                    {
                        if (m_objCurrentSubArr[intTemRow].m_strMEDICINEID_CHR == lstMedid[intRow].ToString())
                        {
                            dblOldAmount += m_objCurrentSubArr[intTemRow].m_dblNETAMOUNT_INT;
                        }
                    }
                    //dblSum = dblOldGross + dblOldAmount - dblNewAmount;
                    dblSum = dblSumAllrealgross + dblOldAmount - dblNewAmount;
                }
                
                for (intTemRow = 0; intTemRow < p_drDetail.Length; intTemRow++)
                {
                    if (objDetailArr[intTemRow].m_strMEDICINEID_CHR == lstMedid[intRow].ToString())
                    {
                        objDetailArr[intTemRow].m_dblOldGross = dblSum;
                    }
                }
                dblSum = 0;
                dblOldAmount = 0;
                dblOldGross = 0;
                dblNewAmount = 0;
                dblSumAllrealgross = 0;
            }
            #endregion

            return objDetailArr;
        } 
        #endregion

        #region 清空界面
        /// <summary>
        /// 清空界面
        /// </summary>
        internal void m_mthClear()
        {
            m_objViewer.m_dtbOutMedicine.Rows.Clear();
            m_objViewer.m_txtReceiveDept.Clear();
            m_objViewer.m_txtReceiveDept.Tag = null;
            m_objViewer.m_txtOutputOrder.Clear();
            m_objViewer.m_txtRemark.Clear();
            m_objViewer.m_lngMainSEQ = 0;
            m_objViewer.m_txtReceiptor.Tag = null;
            m_objViewer.m_txtReceiptor.Clear();

            m_objCurrentMain = null;
            m_objCurrentSubArr = null;
        } 
        #endregion

        #region 删除出库明细
        /// <summary>
        /// 删除出库明细
        /// </summary>
        /// <returns></returns>
        internal void m_mthDeleteDetail()
        {
            string strMedicine;
            double dblOldGross;
            if (m_objCurrentMain != null && m_objCurrentMain.m_intSTATUS != 1)
            {
                if (m_objCurrentMain.m_intSTATUS == 3 && m_objViewer.m_intCommitFolow == 1)
                {
                    MessageBox.Show("该药品出库记录已入帐，不能删除", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (m_objViewer.m_intCommitFolow == 0)
                {
                    MessageBox.Show("该药品出库记录已审核，不能删除", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (m_objViewer.m_dgvMedicineOutInfo.SelectedCells.Count == 0)
            {
                return;
            }
            
            int intRowIndex = m_objViewer.m_dgvMedicineOutInfo.SelectedCells[0].RowIndex;
            DataRow drCurrent = ((DataRowView)m_objViewer.m_dgvMedicineOutInfo.CurrentCell.OwningRow.DataBoundItem).Row;
            strMedicine = drCurrent["MEDICINEID_CHR"].ToString();
            long lngSEQ = 0;
            if (long.TryParse(drCurrent["SERIESID_INT"].ToString(), out lngSEQ))
            {
                //20090721:保存、删除、审核单据时，均判断是否新制状态
                if (m_objViewer.m_txtOutputOrder.Text.Length > 0)
                {
                    bool blnNewState = false;
                    clsDcl_Purchase_Detail clsDcl = new clsDcl_Purchase_Detail();
                    clsDcl.m_lngCheckBillState(2, m_objViewer.m_txtOutputOrder.Text.Trim(), out blnNewState);
                    if (!blnNewState)
                    {
                        MessageBox.Show("该出库单不是新制状态，请关闭并刷新后重试", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                double dblAmount = 0d;
                long lngRes = m_objDomain.m_lngGetOutStorageDetailGross(lngSEQ, out dblAmount);
                bool blnIsCommit = m_objViewer.m_intCommitFolow == 1 ? true : false;

                clsMS_Storage objStorage = null;
                if (blnIsCommit)
                {
                    objStorage = new clsMS_Storage();
                    objStorage.m_strMEDICINEID_CHR = drCurrent["MEDICINEID_CHR"].ToString();
                    objStorage.m_strMEDICINENAME_VCHR = drCurrent["MEDICINENAME_VCHR"].ToString();
                    objStorage.m_strMEDSPEC_VCHR = drCurrent["MEDSPEC_VCHR"].ToString();
                    objStorage.m_strOPUNIT_VCHR = drCurrent["OPUNIT_CHR"].ToString();
                    objStorage.m_dcmCALLPRICE_INT = Convert.ToDecimal(drCurrent["CALLPRICE_INT"]);
                    objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                    objStorage.m_strVENDORID_CHR = drCurrent["VENDORID_CHR"].ToString();
                }

                string m_strLotno = "";
                if (drCurrent["LOTNO_VCHR"].ToString() == "")
                {
                    m_strLotno = "UNKNOWN";
                }
                else
                {
                    m_strLotno = drCurrent["LOTNO_VCHR"].ToString();
                }
                lngRes = m_objDomain.m_lngDeleteSelectedMedicine(lngSEQ, m_objCurrentMain.m_strOUTSTORAGEID_VCHR, m_objViewer.m_strStorageID, drCurrent["MEDICINEID_CHR"].ToString(), m_strLotno, drCurrent["INSTORAGEID_VCHR"].ToString(), Convert.ToDateTime(drCurrent["validperiod_dat"]), Convert.ToDouble(drCurrent["CALLPRICE_INT"]), blnIsCommit, objStorage, dblAmount);
                if (lngRes > 0)
                {
                    if (m_objCurrentSubArr != null)
                    {
                        List<clsMS_OutStorageDetail_VO> lstDetail = new List<clsMS_OutStorageDetail_VO>();
                        for (int iDe = 0; iDe < m_objCurrentSubArr.Length; iDe++)
                        {
                            if (m_objCurrentSubArr[iDe].m_lngSERIESID_INT != lngSEQ)
                            {
                                lstDetail.Add(m_objCurrentSubArr[iDe]);
                            }
                        }
                        m_objCurrentSubArr = null;
                        if (lstDetail.Count > 0)
                        {
                            m_objCurrentSubArr = lstDetail.ToArray();
                        }
                    }
                    
                    //更新oldgross_int
                    //for (int intTemRow = 0; intTemRow < m_objCurrentSubArr.Length; intTemRow++)
                    //{
                    //    if (m_objCurrentSubArr[intTemRow].m_strMEDICINEID_CHR == strMedicine)
                    //    {
                    //        if (drCurrent["oldgross_int"] != DBNull.Value)
                    //        {
                    //            m_objCurrentSubArr[intTemRow].m_dblOldGross += Convert.ToDouble(drCurrent["oldgross_int"]);
                    //        }
                    //    }
                    //}

                    for (int iRow = 0; iRow < m_objViewer.m_dgvMedicineOutInfo.Rows.Count; iRow++)                    
                    {
                        if (m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].Cells[20].Value == null) continue;
                        if (m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].Cells[20].Value.ToString() == strMedicine)
                        {
                            dblOldGross = Convert.ToDouble(drCurrent["netamount_int"]) + Convert.ToDouble(m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].Cells[21].Value);
                            m_objViewer.m_dgvMedicineOutInfo.Rows[iRow].Cells[21].Value = dblOldGross;
              
                        }
                    }

                    m_objViewer.m_dtbOutMedicine.Rows.Remove(drCurrent);
                    MessageBox.Show("删除成功", "药品出库", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                m_objViewer.m_dtbOutMedicine.Rows.Remove(drCurrent);
            }
        } 
        #endregion

        #region 退审

        /// <summary>
        /// 退审

        /// </summary>
        /// <param name="p_drCurrent">选定药品数据</param>
        /// <param name="dblAmount">出库实发数量</param>
        internal void m_mthUnCommit(DataRow p_drCurrent, double dblAmount)
        {
            clsMS_Storage objStorage = new clsMS_Storage();
            objStorage.m_strMEDICINEID_CHR = p_drCurrent["MEDICINEID_CHR"].ToString();
            objStorage.m_strMEDICINENAME_VCHR = p_drCurrent["MEDICINENAME_VCHR"].ToString();
            objStorage.m_strMEDSPEC_VCHR = p_drCurrent["MEDSPEC_VCHR"].ToString();
            objStorage.m_strOPUNIT_VCHR = p_drCurrent["OPUNIT_CHR"].ToString();
            objStorage.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drCurrent["CALLPRICE_INT"]);
            objStorage.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

            clsDcl_Storage objSTDomain = new clsDcl_Storage();
            bool blnHasDetail = false;
            long lngCurrentSeriesID = 0;
            long lngRes = objSTDomain.m_lngCheckHasStorage(objStorage.m_strMEDICINEID_CHR, m_objViewer.m_strStorageID, out blnHasDetail, out lngCurrentSeriesID);

            long lngSubSEQ = 0;
            double p_dblRealgross = 0d;
            double p_dblAvailagross = 0d;
            lngRes = objSTDomain.m_lngGetDetailSEQByIndex(p_drCurrent["INSTORAGEID_VCHR"].ToString(), p_drCurrent["MEDICINEID_CHR"].ToString(), p_drCurrent["LOTNO_VCHR"].ToString(), Convert.ToDateTime(p_drCurrent["validperiod_dat"]), Convert.ToDouble(p_drCurrent["CALLPRICE_INT"]), m_objViewer.m_strStorageID, out lngSubSEQ, out p_dblRealgross, out p_dblAvailagross);
            if (lngSubSEQ > 0)
            {
                objStorage.m_dblINSTOREGROSS_INT = 0;
                objStorage.m_dblCURRENTGROSS_NUM = dblAmount;
                lngRes = objSTDomain.m_lngAddStorageDetailGross(dblAmount, 0, lngSubSEQ);//删除时不再增加可用库存，以免重复添加
            }

            objStorage.m_lngSERIESID_INT = lngCurrentSeriesID;
            lngRes = objSTDomain.m_lngModifyStorageFromInitial(objStorage, lngCurrentSeriesID);

            //lngRes = objSTDomain.m_lngStatisticsStorage(objStorage.m_strMEDICINEID_CHR, m_objViewer.m_strStorageID);
        }
        #endregion

        #region 获取库存子表VO
        ///// <summary>
        ///// 获取库存子表VO
        ///// </summary>
        ///// <param name="p_drCurrent">当前数据行</param>
        ///// <returns></returns>
        //private clsMS_StorageDetail m_objSTDetail(DataRow p_drCurrent)
        //{
        //    clsMS_StorageDetail objDetail = null;
        //    if (p_drCurrent == null)
        //    {
        //        return null;
        //    }

        //    objDetail = new clsMS_StorageDetail();
        //    objDetail.m_strMEDICINEID_CHR = p_drCurrent["MEDICINEID_CHR"].ToString();
        //    objDetail.m_strMEDICINENAME_VCHR = p_drCurrent["MEDICINENAME_VCHR"].ToString();
        //    objDetail.m_strMEDSPEC_VCHR = p_drCurrent["MEDSPEC_VCHR"].ToString();
        //    objDetail.m_strOPUNIT_VCHR = p_drCurrent["OPUNIT_CHR"].ToString();
        //    objDetail.m_dblAVAILAGROSS_INT = Convert.ToDouble(p_drCurrent["NETAMOUNT_INT"]);
        //    objDetail.m_dblREALGROSS_INT = Convert.ToDouble(p_drCurrent["NETAMOUNT_INT"]);
        //    objDetail.m_strLOTNO_VCHR = p_drCurrent["LOTNO_VCHR"].ToString();
        //    objDetail.m_strINSTORAGEID_VCHR = p_drCurrent["INSTORAGEID_VCHR"].ToString();
        //    objDetail.m_dcmCALLPRICE_INT = Convert.ToDecimal(p_drCurrent["CALLPRICE_INT"]);
        //    objDetail.m_dcmWHOLESALEPRICE_INT = Convert.ToDecimal(p_drCurrent["WHOLESALEPRICE_INT"]);
        //    objDetail.m_dcmRETAILPRICE_INT = Convert.ToDecimal(p_drCurrent["RETAILPRICE_INT"]);
        //    objDetail.m_strVENDORID_CHR = p_drCurrent["VENDORID_CHR"].ToString();
        //    objDetail.m_dtmINSTORAGEDATE_DAT = Convert.ToDateTime(p_drCurrent["INSTORAGEDATE_DAT"]);
        //    objDetail.m_dtmVALIDPERIOD_DAT = Convert.ToDateTime(p_drCurrent["validperiod_dat"]);
        //    objDetail.m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
        //    objDetail.m_strPRODUCTORID_CHR = p_drCurrent["productorid_chr"].ToString();
        //    return objDetail;
        //} 
        #endregion

        #region 审核药品信息
        /// <summary>
        /// 审核药品信息
        /// </summary>
        internal void m_mthCommitMedicine(clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objSubArr)
        {

            if (p_objMain == null || p_objSubArr == null)
            {
                return;
            }

            try
            {
                long lngRes = 0;
                clsDcl_Storage objSTDomain = new clsDcl_Storage();

                List<clsMS_StorageDetail> objDetail = new List<clsMS_StorageDetail>();
                DataTable dtbDetail = null;
                clsMS_StorageDetail[] objDetailTemp = m_objDetailVO(p_objSubArr);
                if (objDetailTemp != null && objDetailTemp.Length > 0)
                {
                    objDetail.AddRange(objDetailTemp);
                }

                clsMS_StorageDetail[] objAllDetail = objDetail.ToArray();//全部明细VO

                if (objAllDetail == null || objAllDetail.Length == 0)
                {
                    return;
                }

                clsMS_Storage[] objStorageArr = new clsMS_Storage[objAllDetail.Length];
                for (int iRow = 0; iRow < objAllDetail.Length; iRow++)
                {
                    //先获取库存主表信息

                    objStorageArr[iRow] = new clsMS_Storage();
                    objStorageArr[iRow].m_strMEDICINEID_CHR = objAllDetail[iRow].m_strMEDICINEID_CHR;
                    objStorageArr[iRow].m_strMEDICINENAME_VCHR = objAllDetail[iRow].m_strMEDICINENAME_VCHR;
                    objStorageArr[iRow].m_strMEDSPEC_VCHR = objAllDetail[iRow].m_strMEDSPEC_VCHR;
                    objStorageArr[iRow].m_strOPUNIT_VCHR = objAllDetail[iRow].m_strOPUNIT_VCHR;
                    objStorageArr[iRow].m_dblINSTOREGROSS_INT = 0;//出库时不需对入库总量作修改


                    objStorageArr[iRow].m_dblCURRENTGROSS_NUM = objAllDetail[iRow].m_dblAVAILAGROSS_INT;
                    objStorageArr[iRow].m_dcmCALLPRICE_INT = objAllDetail[iRow].m_dcmCALLPRICE_INT;
                    objStorageArr[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;

                    objAllDetail[iRow].m_dblAVAILAGROSS_INT = 0;//审核时库存子表不再对可用库存进行修改，以免重复

                }
                bool blnSaveComplete = true;
                lngRes = objSTDomain.m_lngSubStorageDetailGross(objAllDetail);

                if (lngRes > 0)
                {
                    blnSaveComplete = true;
                }
                else
                {
                    blnSaveComplete = false;
                }

                if (!blnSaveComplete)
                {
                    return;
                }

                for (int iRow = 0; iRow < objStorageArr.Length; iRow++)
                {
                    lngRes = objSTDomain.m_lngSubStorageGross(objStorageArr[iRow]);
                }

                //System.Collections.Hashtable hstStastic = new System.Collections.Hashtable();
                //for (int iRow = 0; iRow < objAllDetail.Length; iRow++)
                //{
                //    if (!hstStastic.Contains(objAllDetail[iRow].m_strMEDICINEID_CHR))
                //    {
                //        hstStastic.Add(objAllDetail[iRow].m_strMEDICINEID_CHR, objAllDetail[iRow].m_lngSERIESID_INT);
                //        lngRes = objSTDomain.m_lngStatisticsStorage(objAllDetail[iRow].m_strMEDICINEID_CHR, m_objViewer.m_strStorageID);
                //    }
                //}

                if (blnSaveComplete)
                {
                    m_mthUpdateUIAfterCommit(p_objMain);
                    m_mthSetCommitUser(p_objMain);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
        }

        /// <summary>
        /// 设置审核人

        /// </summary>
        /// <param name="p_objMain">数据</param>
        private void m_mthSetCommitUser(clsMS_OutStorage_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return;
            }

            clsDcl_OutStorage objPur = new clsDcl_OutStorage();
            long[] lngSeq = new long[] { p_objMain.m_lngSERIESID_INT };
            long lngRes = objPur.m_lngSetCommitUser(m_objViewer.LoginInfo.m_strEmpID, lngSeq);
        }

        /// <summary>
        /// 更新界面
        /// </summary>
        /// <param name="p_objMain">数据</param>
        private void m_mthUpdateUIAfterCommit(clsMS_OutStorage_VO p_objMain)
        {
            if (p_objMain == null)
            {
                return;
            }

            p_objMain.m_intSTATUS = 2;
        }

        #region 根据数据返回库存子表VO
        /// <summary>
        /// 根据数据返回库存子表VO
        /// </summary>
        /// <param name="p_objSubArr">数据</param>
        /// <returns></returns>
        private clsMS_StorageDetail[] m_objDetailVO(clsMS_OutStorageDetail_VO[] p_objSubArr)
        {
            if (p_objSubArr == null || p_objSubArr.Length == 0)
            {
                return null;
            }

            clsMS_StorageDetail[] objSubVO = new clsMS_StorageDetail[p_objSubArr.Length];
            for (int iRow = 0; iRow < p_objSubArr.Length; iRow++)
            {
                objSubVO[iRow] = new clsMS_StorageDetail();
                objSubVO[iRow].m_strSTORAGEID_CHR = m_objViewer.m_strStorageID;
                objSubVO[iRow].m_strMEDICINEID_CHR = p_objSubArr[iRow].m_strMEDICINEID_CHR;
                objSubVO[iRow].m_strMEDICINENAME_VCHR = p_objSubArr[iRow].m_strMEDICINENAME_VCH;
                objSubVO[iRow].m_strMEDSPEC_VCHR = p_objSubArr[iRow].m_strMEDSPEC_VCHR;
                objSubVO[iRow].m_strLOTNO_VCHR = p_objSubArr[iRow].m_strLOTNO_VCHR;
                objSubVO[iRow].m_dcmRETAILPRICE_INT = p_objSubArr[iRow].m_dcmRETAILPRICE_INT;
                objSubVO[iRow].m_dcmCALLPRICE_INT = p_objSubArr[iRow].m_dcmCALLPRICE_INT;
                objSubVO[iRow].m_dcmWHOLESALEPRICE_INT = p_objSubArr[iRow].m_dcmWHOLESALEPRICE_INT;
                objSubVO[iRow].m_dblREALGROSS_INT = p_objSubArr[iRow].m_dblNETAMOUNT_INT;
                objSubVO[iRow].m_dblAVAILAGROSS_INT = p_objSubArr[iRow].m_dblNETAMOUNT_INT;
                objSubVO[iRow].m_strOPUNIT_VCHR = p_objSubArr[iRow].m_strOPUNIT_CHR.Trim();
                objSubVO[iRow].m_dtmVALIDPERIOD_DAT = p_objSubArr[iRow].m_dtmValidperiod_dat;
                objSubVO[iRow].m_strPRODUCTORID_CHR = p_objSubArr[iRow].m_strProductorID_chr;
                objSubVO[iRow].m_strINSTORAGEID_VCHR = p_objSubArr[iRow].m_strINSTORAGEID_VCHR;
                objSubVO[iRow].m_dtmINSTORAGEDATE_DAT = p_objSubArr[iRow].m_dtmINSTORAGEDATE_DAT;
                objSubVO[iRow].m_strVENDORID_CHR = p_objSubArr[iRow].m_strVENDORID_CHR;
                objSubVO[iRow].m_strVENDORName = p_objSubArr[iRow].m_strVendorName;
                objSubVO[iRow].m_intStatus = 1;
            }
            return objSubVO;
        }
        #endregion
        #endregion

        #region 计算界面金额
        /// <summary>
        /// 计算界面金额
        /// </summary>
        internal void m_mthCountMoney()
        {
            m_objViewer.m_lblBugMoney.Text = string.Empty;
            m_objViewer.m_lblSaleMoney.Text = string.Empty;
            m_objViewer.m_lblDiffMoney.Text = string.Empty;

            if (m_objViewer.m_dtbOutMedicine != null)
            {
                int intRowsCount = m_objViewer.m_dtbOutMedicine.Rows.Count;
                double dblBuyMoney = 0d;
                double dblSaleMoney = 0d;
                double dblDiffMoney = 0d;

                double dblAmountTemp = 0d;
                double dblPriceTemp = 0d;
                double dblDiffTemp = 0d;
                DataRow drTemp = null;
                for (int iRow = 0; iRow < intRowsCount; iRow++)
                {
                    drTemp = m_objViewer.m_dtbOutMedicine.Rows[iRow];
                    if (drTemp.RowState == DataRowState.Deleted || drTemp.RowState == DataRowState.Detached)
                    {
                        continue;
                    }
                    if (double.TryParse(drTemp["NETAMOUNT_INT"].ToString(), out dblAmountTemp))
                    {
                        if (double.TryParse(drTemp["CALLPRICE_INT"].ToString(), out dblPriceTemp))
                        {
                            dblBuyMoney += dblAmountTemp * dblPriceTemp;
                        }
                        if (double.TryParse(drTemp["RETAILPRICE_INT"].ToString(), out dblPriceTemp))
                        {
                            dblSaleMoney += dblAmountTemp * dblPriceTemp;
                        }
                        if (double.TryParse(drTemp["WHOLESALEPRICE_INT"].ToString(), out dblDiffTemp))
                        {
                            dblDiffMoney += dblAmountTemp * dblDiffTemp;
                        }
                    }
                }
                m_objViewer.m_lblBugMoney.Text = dblBuyMoney.ToString("0.0000");
                m_objViewer.m_lblSaleMoney.Text = dblSaleMoney.ToString("0.0000");
                dblDiffMoney = dblSaleMoney - dblDiffMoney;
                m_objViewer.m_lblDiffMoney.Text = dblDiffMoney.ToString("0.0000");
            }
        } 
        #endregion

        #region 设置出库信息至界面

        /// <summary>
        /// 设置出库信息至界面

        /// </summary>
        /// <param name="p_objMain">出库主表信息</param>
        /// <param name="p_objDetailArr">出库子表信息</param>
        /// <param name="p_intSelectedSubRow">子表选中行索引</param>
        internal void m_mthSetOutStorageToUI(clsMS_OutStorage_VO p_objMain, clsMS_OutStorageDetail_VO[] p_objDetailArr, int p_intSelectedSubRow)
        {
            if (p_objMain == null)
            {
                return;
            }

            //string m_strBillTypeName;
            //m_objDomain.m_lngGetBillTypeName(p_objMain.m_intOutStorageTYPE_INT, out m_strBillTypeName);
            //if(m_strBillTypeName != "")
            //    m_objViewer.Text = m_strBillTypeName;
            
            #region 主表
            m_objCurrentMain = p_objMain;
            m_objViewer.m_txtReceiveDept.m_mthSelectItem(p_objMain.m_strASKDEPT_CHR.Trim());
            m_objViewer.m_txtOutputOrder.Text = p_objMain.m_strOUTSTORAGEID_VCHR;
            m_objViewer.m_dtpDate.Text = p_objMain.m_dtmOutStorageDate.ToString("yyyy年MM月dd日");
            if (m_objViewer.m_intCanModifyMakeDate == 0)
                m_objViewer.m_dtpDate.Enabled = false;
            if (m_objViewer.m_intCommitFolow == 1 && m_objViewer.m_intCanModifyAutoExam == 0)
            {
                m_objViewer.m_cmdSave.Enabled = false;
            }
            m_objViewer.m_txtMan.Text = p_objMain.m_strASKERName;
            m_objViewer.m_txtMan.Tag = p_objMain.m_strASKERID_CHR;
            m_objViewer.m_txtRemark.Text = p_objMain.m_strCOMMENT_VCHR;
            m_objViewer.m_lngMainSEQ = p_objMain.m_lngSERIESID_INT;
            m_objViewer.m_txtReceiptor.Text = p_objMain.m_strRECEIPTORName;
            m_objViewer.m_txtReceiptor.Tag = p_objMain.m_strRECEIPTORID_CHR;

            if (p_objMain.m_intSTATUS != 1)
            {
                m_objViewer.m_cmdSave.Enabled = false;
                m_objViewer.m_cmdDelete.Enabled = false;
                m_objViewer.m_cmdInsertRecord.Enabled = false;
                m_objViewer.m_cmdNext.Enabled = false;
                m_objViewer.panel1.Enabled = false;
                m_objViewer.m_dgvMedicineOutInfo.ReadOnly = true;
               // m_objViewer.m_dgvMedicineOutInfo.AllowUserToAddRows = false;
            }

            //if (m_objViewer.m_intCommitFolow == 1 && p_objMain.m_intSTATUS != 0 && p_objMain.m_intSTATUS != 3)
            //{
            //    m_objViewer.m_cmdSave.Enabled = true;
            //    m_objViewer.m_cmdDelete.Enabled = true;
            //    m_objViewer.m_cmdInsertRecord.Enabled = true;
            //    m_objViewer.m_cmdNext.Enabled = true;
            //    m_objViewer.panel1.Enabled = true;
            //    m_objViewer.m_dgvMedicineOutInfo.ReadOnly = false;
            //    //m_objViewer.m_dgvMedicineOutInfo.AllowUserToAddRows = true;
            //}
            #endregion

            if (p_objDetailArr != null)
            {
                try
                {
                    m_objCurrentSubArr = p_objDetailArr;
                    DateTime datTemp;
                    m_objViewer.m_dtbOutMedicine.BeginLoadData();
                    DataRow drSub = null;
                    for (int iRow = 0; iRow < p_objDetailArr.Length; iRow++)
                    {
                        drSub = m_objViewer.m_dtbOutMedicine.NewRow();
                        drSub["SERIESID_INT"] = p_objDetailArr[iRow].m_lngSERIESID_INT;
                        drSub["SERIESID2_INT"] = p_objDetailArr[iRow].m_lngSERIESID2_INT;
                        drSub["MEDICINEID_CHR"] = p_objDetailArr[iRow].m_strMEDICINEID_CHR;
                        drSub["MEDICINENAME_VCHr"] = p_objDetailArr[iRow].m_strMEDICINENAME_VCH;
                        drSub["MEDSPEC_VCHR"] = p_objDetailArr[iRow].m_strMEDSPEC_VCHR;
                        drSub["OPUNIT_CHR"] = p_objDetailArr[iRow].m_strOPUNIT_CHR.Trim(); ;
                        drSub["NETAMOUNT_INT"] = p_objDetailArr[iRow].m_dblNETAMOUNT_INT;
                        drSub["originality_Amount"] = p_objDetailArr[iRow].m_dblNETAMOUNT_INT;
                        drSub["LOTNO_VCHR"] = p_objDetailArr[iRow].m_strLOTNO_VCHR;
                        drSub["INSTORAGEID_VCHR"] = p_objDetailArr[iRow].m_strINSTORAGEID_VCHR;
                        drSub["CALLPRICE_INT"] = p_objDetailArr[iRow].m_dcmCALLPRICE_INT;
                        drSub["WHOLESALEPRICE_INT"] = p_objDetailArr[iRow].m_dcmWHOLESALEPRICE_INT;
                        drSub["RETAILPRICE_INT"] = p_objDetailArr[iRow].m_dcmRETAILPRICE_INT;
                        drSub["VENDORID_CHR"] = p_objDetailArr[iRow].m_strVENDORID_CHR;
                        drSub["vendorname_vchr"] = p_objDetailArr[iRow].m_strVendorName;
                        drSub["productorid_chr"] = p_objDetailArr[iRow].m_strProductorID_chr;
                        //drSub["inmoney"] = p_objDetailArr[iRow].m_dcmBuyInMoney;
                        //drSub["retailmoney"] = p_objDetailArr[iRow].m_dcmRetailMoney;
                        drSub["instoragedate_dat"] = p_objDetailArr[iRow].m_dtmINSTORAGEDATE_DAT.ToString("yyyy-MM-dd");
                        drSub["validperiod_dat"] = p_objDetailArr[iRow].m_dtmValidperiod_dat.ToString("yyyy-MM-dd");
                        drSub["realgross_int"] = p_objDetailArr[iRow].m_dblRealGross;
                        drSub["assistcode_chr"] = p_objDetailArr[iRow].m_strMEDICINECode;
                        drSub["availagross_int"] = p_objDetailArr[iRow].m_dblAvailaGross;
                        drSub["storageunit"] = p_objDetailArr[iRow].m_strStorageUnit;
                        drSub["medicinetypeid_chr"] = p_objDetailArr[iRow].m_strMedicineTypeID_chr;
                        drSub["typecode_vchr"] = p_objDetailArr[iRow].m_strTYPECODE_CHR;

                        drSub["oldgross_int"] = p_objDetailArr[iRow].m_dblOldGross;
                        if (p_objDetailArr[iRow].m_dblAskAmount == 0)
                        {
                            drSub["askamount"] = DBNull.Value;
                        }
                        else
                        {
                            drSub["askamount"] = p_objDetailArr[iRow].m_dblAskAmount;
                        }
                        if (DateTime.TryParse(p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT.ToString("yyyy-MM-dd"), out datTemp))
                        {
                            drSub["producedate_dat"] = p_objDetailArr[iRow].m_dtmPRODUCEDATE_DAT;
                        }
                        m_objViewer.m_dtbOutMedicine.LoadDataRow(drSub.ItemArray, true);
                    }

                    clsMS_MedicineGross[] objGross = null;//各药品当前总库存

                    long lngRes = m_objDomain.m_lngGetMedicineAllGross(m_objCurrentMain.m_lngSERIESID_INT, out objGross);
                    if (objGross != null && objGross.Length > 0)
                    {
                        Hashtable hstMedicine = new Hashtable();
                        for (int iGro = 0; iGro < objGross.Length; iGro++)
                        {
                            hstMedicine.Add(objGross[iGro].m_strMedicineID, iGro);
                        }

                        for (int iRow = 0; iRow < m_objViewer.m_dtbOutMedicine.Rows.Count; iRow++)
                        {
                            string strMedicineID = m_objViewer.m_dtbOutMedicine.Rows[iRow]["medicineid_chr"].ToString();
                            if (hstMedicine.Contains(strMedicineID))
                            {
                                int intIndex = Convert.ToInt32(hstMedicine[strMedicineID]);
                                m_objViewer.m_dtbOutMedicine.Rows[iRow]["allavagross"] = objGross[intIndex].m_dblAvailaGross;
                                m_objViewer.m_dtbOutMedicine.Rows[iRow]["allrealgross"] = objGross[intIndex].m_dblRealGross;
                            }
                        }
                        hstMedicine = null;
                        objGross = null;
                        m_objViewer.m_dtbOutMedicine.AcceptChanges();
                    }
                }
                catch (Exception Ex)
                {
                    com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                    bool blnRes = objLogger.LogError(Ex);
                }
                finally
                {
                    m_objViewer.m_dtbOutMedicine.EndLoadData();
                }

                if (p_intSelectedSubRow > 0 && m_objViewer.m_dgvMedicineOutInfo.Rows.Count > 0 && p_intSelectedSubRow < m_objViewer.m_dgvMedicineOutInfo.Rows.Count)
                {
                    m_objViewer.m_dgvMedicineOutInfo.Rows[p_intSelectedSubRow].Selected = true;
                    m_objViewer.m_dgvMedicineOutInfo.CurrentCell = m_objViewer.m_dgvMedicineOutInfo.Rows[p_intSelectedSubRow].Cells[1];
                }
            }
        } 
        #endregion

        #region 增加可用库存
        /// <summary>
        /// 增加可用库存
        /// </summary>
        /// <param name="p_objDetail">出库子表数据</param>
        private void m_mthAddAvailaGross(clsMS_OutStorageDetail_VO[] p_objDetail)
        {
            clsMS_StorageGrossForOut[] objSubArr = null;
            long lngRes = 0;
            objSubArr = m_objGetDetail(p_objDetail);

            if (objSubArr.Length > 0)
            {
                clsDcl_Storage objSTDomain = new clsDcl_Storage();
                lngRes = objSTDomain.m_lngAddStorageDetailAvailaGross(objSubArr);
            }
        }  
        #endregion

        #region 获取库存子表VO
        /// <summary>
        /// 获取库存子表VO
        /// </summary>
        /// <param name="p_objDetail">出库子表数据</param>
        /// <returns></returns>
        private clsMS_StorageGrossForOut[] m_objGetDetail(clsMS_OutStorageDetail_VO[] p_objDetail)
        {
            clsMS_StorageGrossForOut[] objDetailArr = null;

            if (p_objDetail == null || p_objDetail.Length == 0)
            {
                return null;
            }

            int intRowsCount = p_objDetail.Length;
            if (intRowsCount > 0)
            {
                objDetailArr = new clsMS_StorageGrossForOut[intRowsCount];
            }
            for (int iRow = 0; iRow < intRowsCount; iRow++)
            {
                objDetailArr[iRow] = new clsMS_StorageGrossForOut();
                objDetailArr[iRow].m_strMedicineID = p_objDetail[iRow].m_strMEDICINEID_CHR;
                objDetailArr[iRow].m_strStorageID = m_objViewer.m_strStorageID;
                objDetailArr[iRow].m_strInStorageID = p_objDetail[iRow].m_strINSTORAGEID_VCHR;
                objDetailArr[iRow].m_strLotNO = p_objDetail[iRow].m_strLOTNO_VCHR;
                objDetailArr[iRow].m_dblGross = p_objDetail[iRow].m_dblNETAMOUNT_INT;
                 
            }
            return objDetailArr;
        }
        #endregion

        #region 打开预览窗体
        /// <summary>
        ///打印
        /// </summary>
        internal long m_purchasePrint(int i_showType)
        {
            //
            decimal decTMoney;
            decTMoney = Convert.ToDecimal(m_objViewer.m_lblBugMoney.Text);
            string strAllInMoney = new Money(decTMoney).ToString();
            
            if (m_objCurrentSubArr == null)
            {
                MessageBox.Show("抱歉，没有数据可打印！", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
            int intPrintType;
            m_objDomain.m_lngGetPrinType(out intPrintType);
            frmMedicineOutReport frmReport = new frmMedicineOutReport();
            DataTable p_OutDtbVal = new DataTable();
            this.m_objDomain.m_lngGetOutStorageDetailReport(Convert.ToInt32(this.m_objViewer.m_dtbOutMedicine.Rows[0]["seriesid2_int"].ToString()),intPrintType, out p_OutDtbVal,m_objViewer.m_strSecondDBConfigString);
            
            DataRow dro;
            
            int i_temp = 0;
            DataTable dtb= new DataTable();

            string RoomName;
            this.m_objDomain.m_lngGetStoreRoomName(this.m_objViewer.m_strStorageID, out RoomName);


            if (intPrintType == 0)
            {
                dtb = p_OutDtbVal.Clone();
                for (int i_low = 0; i_low < p_OutDtbVal.Rows.Count; i_low++)
                {
                    i_temp++;
                   dtb.ImportRow(p_OutDtbVal.Rows[i_low]);
                    //药品和材料不能打在同一张

                    if (((i_low+1) >= p_OutDtbVal.Rows.Count) || ((p_OutDtbVal.Rows[i_low]["medicinetypesetid"].ToString()) != (p_OutDtbVal.Rows[i_low + 1]["medicinetypesetid"].ToString())))
                    {
                        int ros = 7 - i_temp % 7;
                        if (ros != 7)
                        {
                            int i_valCount = dtb.Rows.Count + ros;
                            for (int i = 0; i < ros; i++)
                            {
                                dro = dtb.NewRow();
                                dtb.Rows.Add(dro);
                            }
                            i_temp = 0;
                        }
                    }
                }
                frmReport.datWindow.DataWindowObject = "outstorage_detailreport_lj";
            }

            if (intPrintType == 1)
            {
                dtb = p_OutDtbVal.Copy();
               // List<string> lstMedid = new List<string>();
                
               //// DataRow[] rows = p_OutDtbVal.Select("endamount_int <> 0 and availagross_int =0");
               // int intRow;
               // for (intRow = 0; intRow < p_OutDtbVal.Rows.Count; intRow++)
               // {
               //     if (intRow + 2 > p_OutDtbVal.Rows.Count || p_OutDtbVal.Rows[intRow]["medicineid_chr"].ToString() != p_OutDtbVal.Rows[intRow + 1]["medicineid_chr"].ToString())
               //     {
               //         lstMedid.Add(p_OutDtbVal.Rows[intRow]["medicineid_chr"].ToString());
               //     }
               // }

               
               // double dblSum = 0;
               // int intTemRow;
               // for (intRow = 0; intRow < lstMedid.Count; intRow++)
               // {
               //     DataRow[] rows = p_OutDtbVal.Select("medicineid_chr = '" + lstMedid[intRow].ToString()+"'");
                    
               //     for (intTemRow = 0; intTemRow < rows.Length; intTemRow++)
               //     {
               //         if (rows[intTemRow]["netamount_int"] == DBNull.Value)
               //         {
               //             rows[intTemRow]["netamount_int"] = 0;
               //         }
               //         dblSum += Convert.ToDouble(rows[intTemRow]["netamount_int"]); 
                        
               //     }

               //     dblSum = Convert.ToDouble(rows[0]["oldgross_int"]) - dblSum;

               //     for (intTemRow = 0; intTemRow < dtb.Rows.Count; intTemRow++)
               //     {
               //         if (dtb.Rows[intTemRow]["medicineid_chr"].ToString() == lstMedid[intRow].ToString())
               //         {
               //             dtb.Rows[intTemRow]["oldgross_int"] = dblSum;
               //         }
               //     }
               //     dblSum = 0;
               // }


                frmReport.datWindow.DataWindowObject = "outstorage_detailreport_cs";
            }

            frmReport.ReceiveDept = m_objViewer.m_txtReceiveDept.Text;
            frmReport.OutputOrder = m_objViewer.m_txtOutputOrder.Text;
            decimal douBug = Convert.ToDecimal(m_objViewer.m_lblBugMoney.Text);
            string mmm = new Money(douBug).ToString();
            frmReport.strBigwrith = mmm;
            frmReport.zDate = m_objViewer.m_dtpDate.Text;
            frmReport.Man = m_objViewer.m_txtMan.Text;
            frmReport.RoomName = RoomName;
            frmReport.dtb = dtb;
            frmReport.i_showType = i_showType;
            frmReport.strAllInMoney = strAllInMoney;
            frmReport.ShowDialog();

            return 1;
        }
        #endregion

        #region 直接打印
        /// <summary>
        /// 直接打印
        /// </summary>
        /// <returns></returns>
        internal long m_mthPrintDirect()
        {
            Sybase.DataWindow.DataStore dsData = new Sybase.DataWindow.DataStore();
            dsData.LibraryList = clsMedicineStoreFormFactory.PBLPath;

            DataTable p_OutDtbVal = new DataTable();
            int intPrintType;
            m_objDomain.m_lngGetPrinType(out intPrintType);
            this.m_objDomain.m_lngGetOutStorageDetailReport(Convert.ToInt32(this.m_objViewer.m_dtbOutMedicine.Rows[0]["seriesid2_int"].ToString()),intPrintType, out p_OutDtbVal,m_objViewer.m_strSecondDBConfigString);
            DataRow dro;
            DataTable dtb = new DataTable();
            int i_temp = 0;

            dsData.DataWindowObject = "outstorage_detailreport_lj";

            string RoomName;
            this.m_objDomain.m_lngGetStoreRoomName(this.m_objViewer.m_strStorageID, out RoomName);



            if (intPrintType == 0)
            {
                dtb = p_OutDtbVal.Clone();
                for (int i_low = 0; i_low < p_OutDtbVal.Rows.Count; i_low++)
                {
                    i_temp++;
                    dtb.ImportRow(p_OutDtbVal.Rows[i_low]);
                    //药品和材料不能打在同一张
                    if (((i_low + 1) >= p_OutDtbVal.Rows.Count) || ((p_OutDtbVal.Rows[i_low]["medicinetypesetid"].ToString()) != (p_OutDtbVal.Rows[i_low + 1]["medicinetypesetid"].ToString())))
                    {
                        int ros =7 - i_temp % 7;
                        if (ros != 7)
                        {
                            int i_valCount = dtb.Rows.Count + ros;
                            for (int i = 0; i < ros; i++)
                            {
                                dro = dtb.NewRow();
                                dtb.Rows.Add(dro);
                            }
                            i_temp = 0;
                        }
                    }
                }
                dsData.DataWindowObject = "outstorage_detailreport_lj";
                dsData.Modify("t_titel.text='" + m_objComInfo.m_strGetHospitalTitle() + "药品调拔单'");
            }
            if (intPrintType == 1)
            {
                dtb = p_OutDtbVal.Copy();

                //List<string> lstMedid = new List<string>();

                //// DataRow[] rows = p_OutDtbVal.Select("endamount_int <> 0 and availagross_int =0");
                //int intRow;
                //for (intRow = 0; intRow < p_OutDtbVal.Rows.Count; intRow++)
                //{
                //    if (intRow + 2 > p_OutDtbVal.Rows.Count || p_OutDtbVal.Rows[intRow]["medicineid_chr"].ToString() != p_OutDtbVal.Rows[intRow + 1]["medicineid_chr"].ToString())
                //    {
                //        lstMedid.Add(p_OutDtbVal.Rows[intRow]["medicineid_chr"].ToString());
                //    }
                //}


                //double dblSum = 0;
                //int intTemRow;
                //for (intRow = 0; intRow < lstMedid.Count; intRow++)
                //{
                //    DataRow[] rows = p_OutDtbVal.Select("medicineid_chr = '" + lstMedid[intRow].ToString() + "'");

                //    for (intTemRow = 0; intTemRow < rows.Length; intTemRow++)
                //    {
                //        if (rows[intTemRow]["netamount_int"] == DBNull.Value)
                //        {
                //            rows[intTemRow]["netamount_int"] = 0;
                //        }
                //        dblSum += Convert.ToDouble(rows[intTemRow]["netamount_int"]);

                //    }

                //    dblSum = Convert.ToDouble(rows[0]["oldgross_int"]) - dblSum;

                //    for (intTemRow = 0; intTemRow < dtb.Rows.Count; intTemRow++)
                //    {
                //        if (dtb.Rows[intTemRow]["medicineid_chr"].ToString() == lstMedid[intRow].ToString())
                //        {
                //            dtb.Rows[intTemRow]["oldgross_int"] = dblSum;
                //        }
                //    }
                //    dblSum = 0;
                //}



                dsData.DataWindowObject = "outstorage_detailreport_cs";
                dsData.Modify("t_titel.text='" + m_objComInfo.m_strGetHospitalTitle() + "出库单(" + RoomName + ")'");
                decimal douBug = Convert.ToDecimal(m_objViewer.m_lblBugMoney.Text);
                string mmm = new Money(douBug).ToString();
                dsData.Modify("t_bigwrith.text='" + mmm + "'");


                dtb.Columns.Add("validperiod_chr", typeof(System.String));
                dtb.Columns.Add("group_int", typeof(System.Int32));
                int intGroup = 0;
                for (int i = 0; i < dtb.Rows.Count; i++)
                {
                    if (i % 15 == 0)
                    {
                        intGroup++;
                    }
                    dtb.Rows[i]["group_int"] = intGroup;
                    if(dtb.Rows[i]["validperiod_dat"].ToString().StartsWith("0001"))
                    {
                        dtb.Rows[i]["validperiod_chr"] = DBNull.Value;
                    }
                    else
                    {
                        dtb.Rows[i]["validperiod_chr"] = Convert.ToDateTime(dtb.Rows[i]["validperiod_dat"]).ToString("yyyy-MM-dd");
                    }
                }
                dtb.Columns.Remove("validperiod_dat");

            }
            dsData.Modify("m_storagename.text='" + RoomName + "'");
            dsData.Modify("m_txtreceivedept.text='" + m_objViewer.m_txtReceiveDept.Text + "'");
            dsData.Modify("m_txtman.text='" + m_objViewer.m_txtMan.Text + "'");
            dsData.Modify("m_txtman2.text='" + m_objViewer.m_txtMan.Text + "'");
            dsData.Modify("m_dtpdate.text='" + m_objViewer.m_dtpDate.Text + "'");
            dsData.Modify("m_txtoutputorder.text='" + m_objViewer.m_txtOutputOrder.Text + "'");

            int m_intShow;
            clsDcl_Purchase_DetailReport m_objDon = new clsDcl_Purchase_DetailReport();
            m_objDon.m_lngGetIfShowInfo(out m_intShow);
            if (m_intShow == 0)
                dsData.Modify("t_info.text=''");  

            dsData.PrintProperties.Preview = true;
            dsData.Retrieve(dtb);
            dsData.CalculateGroups();
            //dsData.Refresh();
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog_DataStore(dsData, true);
            return 1;
        }
        #endregion

        #region 获取领用部门信息
        /// <summary>
        /// 获取领用部门信息
        /// </summary>
        /// <param name="p_dtbExportDept"></param>
        internal void m_mthGetExportDept(out DataTable p_dtbExportDept)
        {
            clsDcl_InventoryRecord objIRDomain = new clsDcl_InventoryRecord();
            long lngRes = objIRDomain.m_lngGetExportDept(out p_dtbExportDept);
            objIRDomain = null;
        } 
        #endregion

        #region 判断是否调价
        /// <summary>
        /// 判断是否调价
        /// </summary>
        /// <param name="medicineid_chr">药品ID</param>
        /// <param name="lotno_vchr">批号</param>
        /// <param name="instorageid_vchr">入库单号</param>
        /// <param name="bolAdjustrice"></param>
        internal void m_mthGetAdjustrice(string medicineid_chr, string lotno_vchr, string instorageid_vchr, DateTime p_dtmValiDate, double p_dblInPrice, out bool bolAdjustrice)
        {
            bolAdjustrice = false;
            if (m_objCurrentMain == null) return;
            m_objDomain.m_mthGetAdjustrice(medicineid_chr, lotno_vchr, instorageid_vchr, p_dtmValiDate, p_dblInPrice, m_objCurrentMain.m_dtmASKDATE_DAT, out bolAdjustrice);

        }

        /// <summary>
        /// 判断是否调价
        /// </summary>
        /// <param name="orderid">出库单号</param>
        /// <param name="medicineid_chr">药品id</param>
        /// <param name="lotno_vchr">批号</param>
        /// <param name="instorageid_vchr"></param>
        /// <param name="p_dtmValiDate"></param>
        /// <param name="p_dblInPrice"></param>
        /// <param name="bolAdjustrice"></param>
        internal void m_mthGetAdjustrice(string orderid,string medicineid_chr, string lotno_vchr, string instorageid_vchr, DateTime p_dtmValiDate, double p_dblInPrice, out bool bolAdjustrice)
        {
            //获取主表的保存时间

            DateTime dtAskDate;
            long lngRes;
            if (m_objCurrentMain == null)
            {
                lngRes = m_objDomain.m_mthGetBillDate(orderid, out dtAskDate);
            }
            else
                dtAskDate = m_objCurrentMain.m_dtmASKDATE_DAT;
            m_objDomain.m_mthGetAdjustrice(medicineid_chr, lotno_vchr, instorageid_vchr, p_dtmValiDate, p_dblInPrice, dtAskDate, out bolAdjustrice);

        }
        
        #endregion

        #region 设置员工至列表

        /// <summary>
        /// 设置员工至列表

        /// </summary>
        /// <param name="p_strDeptID">科室ID</param>
        /// <param name="p_strSearch">搜索字符串</param>
        /// <param name="p_txtEmp">员工控件</param>
        internal void m_mthSetEmpToList(string p_strDeptID, string p_strSearch, TextBox p_txtEmp)
        {
            DataTable dtbEmp = null;
            long lngRes = 0;
            if (string.IsNullOrEmpty(p_strDeptID))
            {
                lngRes = m_objDomain.m_lngGetEMP(p_strSearch, out dtbEmp);
            }
            else
            {
                lngRes = m_objDomain.m_lngGetEMP(p_strDeptID, p_strSearch, out dtbEmp);
            }

            if (dtbEmp == null || dtbEmp.Rows.Count == 0)
            {
                p_txtEmp.Tag = null;
            }
            if (m_ctlEMP == null)
            {
                m_ctlEMP = new ctlQueryEmployee();
                m_objViewer.Controls.Add(m_ctlEMP);
            }
            m_ctlEMP.m_mthSetTxtBase(p_txtEmp);
            m_ctlEMP.BringToFront();
            int X = m_objViewer.panel1.Location.X + p_txtEmp.Location.X;
            int Y = m_objViewer.panel1.Location.Y + p_txtEmp.Location.Y + p_txtEmp.Size.Height;

            if ((X + m_ctlEMP.Size.Width) > m_objViewer.panel1.Size.Width)
            {
                X = m_objViewer.panel1.Location.X + p_txtEmp.Location.X - (m_ctlEMP.Size.Width - p_txtEmp.Size.Width);
            }
            m_ctlEMP.Location = new System.Drawing.Point(X, Y);
            m_ctlEMP.ReturnInfo += new ReturnEmpInfo(m_ctlEMP_ReturnInfo);

            try
            {
                int intRowCount = dtbEmp.Rows.Count;
                DataRow drCurrent = null;
                List<ListViewItem> lstItems = new List<ListViewItem>();
                for (int iRow = 0; iRow < intRowCount; iRow++)
                {
                    drCurrent = dtbEmp.Rows[iRow];
                    ListViewItem lsi = new ListViewItem(drCurrent["EMPNO_CHR"].ToString());
                    lsi.SubItems.Add(drCurrent["LASTNAME_VCHR"].ToString());
                    lsi.Tag = drCurrent;
                    lstItems.Add(lsi);
                }
                m_ctlEMP.AddRange(lstItems.ToArray());
                if (lstItems.Count == 0)
                {
                    p_txtEmp.Tag = null;
                }
                m_ctlEMP.Visible = true;
                m_ctlEMP.Focus();
            }
            catch (Exception Ex)
            {
                string strEx = Ex.Message;
            }
        }

        private void m_ctlEMP_ReturnInfo(DataRow DR_EMP, TextBox Sender)
        {
            Sender.Tag = null;
            if (DR_EMP != null)
            {
                Sender.Tag = DR_EMP["EMPID_CHR"].ToString();
                Sender.Text = DR_EMP["LASTNAME_VCHR"].ToString();
            }

            m_objViewer.m_txtRemark.Focus();            
        }
        #endregion

        #region 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// <summary>
        /// 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// </summary>
        /// <param name="m_intCanModifyMakeDate">是否允许修改</param>
        internal void m_lngGetCanModifyMakeDate(out int m_intCanModifyMakeDate)
        {
            m_objDomain.m_lngGetCanModifyMakeDate(out m_intCanModifyMakeDate);
        }
        #endregion

        #region 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// <summary>
        /// 是否允许修改出入库单据的制单时间','0，否 1,是'
        /// </summary>
        /// <param name="m_intCanModifyMakeDate">是否允许修改</param>
        internal void m_lngGetCanModifyAutoExam(out int m_intCanModifyAutoExam)
        {
            m_objDomain.m_lngGetCanModifyAutoExam(out m_intCanModifyAutoExam);
        }
        #endregion

        #region 获取数据库连接参数
        /// <summary>
        /// 获取数据库连接参数
        /// </summary>
        /// <param name="p_strConfig"></param>
        internal void m_intGetDBConfigFromXML(out string p_strConfig)
        {
            p_strConfig = string.Empty;
            try
            {
                string XMLFile = Application.StartupPath + "\\" + "SecondDBFile.xml";
                if (File.Exists(XMLFile))
                {
                    XmlDocument m_objXmlDoc = new XmlDocument();
                    m_objXmlDoc.Load(XMLFile);

                    XmlNode m_objXmlParentNode = m_objXmlDoc.DocumentElement.SelectNodes("DBConfig")[0];
                    XmlNode[] xmlChild = new XmlNode[5];
                    xmlChild[0] = m_objXmlParentNode.SelectSingleNode("userid");
                    xmlChild[1] = m_objXmlParentNode.SelectSingleNode("password");
                    xmlChild[2] = m_objXmlParentNode.SelectSingleNode("ip");
                    xmlChild[3] = m_objXmlParentNode.SelectSingleNode("port");
                    xmlChild[4] = m_objXmlParentNode.SelectSingleNode("service_name");
                    //string strTemp = "create public database link SECONDMSCONFIG connect to icare_fs identified by icare using '(DESCRIPTION =(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.0.10)(PORT = 1521)))(CONNECT_DATA =(SERVICE_NAME = icare)))'";
                    string strTemp = "create public database link SECONDMSCONFIG connect to {0} identified by {1} using '(DESCRIPTION =(ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = {2})(PORT = {3})))(CONNECT_DATA =(SERVICE_NAME = {4})))'";
                    p_strConfig = string.Format(strTemp, xmlChild[0].InnerText, xmlChild[1].InnerText, xmlChild[2].InnerText, xmlChild[3].InnerText, xmlChild[4].InnerText);
                    m_objDomain.m_lngEstablishConnection(p_strConfig);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
    }
}
