
using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using ControlLibrary;
using Sybase.DataWindow;
using System.Windows.Forms;
using com.digitalwave.iCare.gui.MedicineStore;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 盘点对账表
    /// </summary>
    public class clsCtl_BalanceReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmBalanceReport m_objViewer;
        private clsDcl_BalanceReport m_objDomain;
        private DataView dtvMedType;
        private ctlQueryMedicintLeastElement m_ctlMedQuery;
        private DataTable dt;
        DataTable dtbResult = new DataTable();//数据库返回的结果集
        DataTable dtbTrueResult = null;
        private string m_strCurrentSelectedPeriod = string.Empty;//当前选择帐务期
        private DataTable m_dtbRawResult;//保存此次结果，如不改变帐务期，下次查询直接取这个值
        private DateTime m_dtStartDate;
        private DateTime m_dtEndDate;
        private DataTable m_dtbRecipeDetail = new DataTable();//处方明细
        private string m_strType = string.Empty;

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_BalanceReport()
        {
            m_objDomain = new clsDcl_BalanceReport();
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
            m_objViewer = (frmBalanceReport)frmMDI_Child_Base_in;
        }
        #endregion


        internal void m_mthInit()
        {
            clsDcl_OutStorageDetailReport objTmp = new clsDcl_OutStorageDetailReport();
            DataTable dtRoom;
            DataTable dtRoomToid = new DataTable();
            DataTable dtVonder;
            DataTable dtMedType;
            long lngRes = objTmp.m_lngGetExptypeAndVendor(m_objViewer.m_blnForDrugStore, out dtRoom, out dtVonder, out dtMedType);
            this.dtvMedType = new DataView(dtMedType);
            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            this.m_objViewer.txtTypecode.m_dtbDataSourse = null;

            if (m_objViewer.m_strRoomidArr.Length > 0)
            {
                if (dtRoom.Rows.Count > 0)
                {
                    dtRoomToid = dtRoom.Clone();
                    DataRow dr = null;
                    int iRowCount = dtRoom.Rows.Count;
                    int iLength = m_objViewer.m_strRoomidArr.Length;
                    dtRoomToid.BeginLoadData();

                    for (int i = 0; i < iLength; i++)
                    {
                        for (int j = 0; j < iRowCount; j++)
                        {
                            dr = dtRoom.Rows[j];
                            if (m_objViewer.m_strRoomidArr[i].ToString().Trim() == dr["medicineroomid"].ToString().Trim())
                            {
                                dtRoomToid.LoadDataRow(dr.ItemArray, true);
                            }
                        }
                    }
                    dtRoomToid.EndLoadData();
                    dtRoomToid.AcceptChanges();
                }
            }

            clsColumns_VO[] column3 = new clsColumns_VO[] { new clsColumns_VO("库房名称", "medicineroomname", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtStoreroom.m_mthInitListView(column3);
            if (m_objViewer.m_strRoomidArr.Length > 0)
            {
                this.m_objViewer.txtStoreroom.m_dtbDataSourse = dtRoomToid;
            }
            else
            {
                this.m_objViewer.txtStoreroom.m_dtbDataSourse = dtRoom;
            }
            this.m_objViewer.txtStoreroom.m_mthFillData();
            if (m_objViewer.m_strRoomidArr.Length > 0)
            {
                DataRow drRoom = null;
                for (int iRow = 0; iRow < dtRoom.Rows.Count; iRow++)
                {
                    drRoom = dtRoom.Rows[iRow];
                    if (m_objViewer.m_strRoomidArr[0].ToString().Trim() == drRoom["medicineroomid"].ToString().Trim())
                    {
                        this.m_objViewer.txtStoreroom.Text = drRoom["medicineroomname"].ToString().Trim();
                        this.m_objViewer.txtStoreroom.Value = drRoom["medicineroomid"].ToString().Trim();
                        break;
                    }
                }
            }
            else
            {
                this.m_objViewer.txtStoreroom.Text = dtRoom.Rows[0]["medicineroomname"].ToString().Trim();
                this.m_objViewer.txtStoreroom.Value = dtRoom.Rows[0]["medicineroomid"].ToString().Trim();
            }
            m_objDomain.m_lngGetBillType(m_objViewer.m_blnForDrugStore, out m_strType);
        }

        internal void m_mthGetMedicine()
        {
            string strMedid = string.Empty;
            dt = new DataTable();
            clsDcl_InstorageDetailReport objTemp = new clsDcl_InstorageDetailReport();
            long lngRes = objTemp.m_lngGetBaseMedicine(m_objViewer.m_blnForDrugStore,true,this .m_objViewer .m_strLastStorageID, this.m_objViewer.txtStoreroom.Value.ToString(), out dt);
        }

        public void m_mthFillMedType()
        {
            this.m_objViewer.txtTypecode.m_listView.Items.Clear();
            if (string.IsNullOrEmpty(this.m_objViewer.txtStoreroom.Value))
            {
                return;
            }
            this.dtvMedType.RowFilter = "medicineroomid='" + this.m_objViewer.txtStoreroom.Value.ToString() + "'";

            DataTable dtValue = dtvMedType.ToTable();
            DataRow drTmp = dtValue.NewRow();
            drTmp["medicinetypeid_chr"] = "";
            drTmp["medicinetypename_vchr"] = "全部";
            drTmp["medicineroomid"] = "-1";
            dtValue.BeginLoadData();
            dtValue.Rows.Add(drTmp);
            dtValue.EndLoadData();

            this.m_objViewer.txtTypecode.m_dtbDataSourse = dtValue;
            this.m_objViewer.txtTypecode.m_mthFillData();
        }

        public void m_mthShowMedince(string strMedid)
        {
            if (string.IsNullOrEmpty(this.m_objViewer.txtStoreroom.Value))
            {
                MessageBox.Show(this.m_objViewer, "请先选择库房。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (m_ctlMedQuery == null)
            {
                this.m_objViewer.m_dtMedince = dt;
                this.m_ctlMedQuery = new ctlQueryMedicintLeastElement(dt);
                this.m_objViewer.Controls.Add(m_ctlMedQuery);

                int X = this.m_objViewer.m_txtMedicineCode.Location.X - 140;
                int Y = this.m_objViewer.m_txtMedicineCode.Location.Y + this.m_objViewer.m_txtMedicineCode.Size.Height+48;
                m_ctlMedQuery.Location = new Point(X, Y);

                m_ctlMedQuery.ReturnInfo += new ReturnMedicineInfo(m_ctlRetureInfo);
                m_ctlMedQuery.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
                m_ctlMedQuery.RefreshMedicine += new RefreshMedicineInfo(m_ctlMedQuery_RefreshMedicine);
            }
            m_ctlMedQuery.Visible = true;
            m_ctlMedQuery.BringToFront();
            m_ctlMedQuery.Focus();
            m_ctlMedQuery.m_mthSetSearchText(strMedid);
        }

        internal void m_ctlMedQuery_RefreshMedicine()
        {
            m_mthGetMedicine();
            this.m_objViewer.m_dtMedince = dt;
            m_ctlMedQuery.m_dtbMedicineInfo = dt;
        }

        internal void m_ctlQueryMedicint_CancelResult()
        {
            this.m_objViewer.m_txtMedicineCode.Focus();
            m_ctlMedQuery.Visible = false;
        }

        internal void m_ctlRetureInfo(clsMS_MedicintLeastElement_VO objVO)
        {
            this.m_objViewer.m_txtMedicineCode.Text = objVO.m_strMedicineName;
            this.m_objViewer.m_txtMedicineCode.Tag = objVO.m_strMedicineID;
        }

        internal void m_mthSearch()
        {
            #region 作废
            //if (Convert.ToString(this.m_objViewer.txtStoreroom.Value) == string.Empty)
            //{
            //    MessageBox.Show("必须选择库房！", "错误...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    this.m_objViewer.txtStoreroom.Focus();
            //    return;
            //}
            //if ((Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text)) > (Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text)))
            //{
            //    MessageBox.Show("开始日期必须小于结束日期！", "错误...", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //    m_objViewer.m_dtpSearchBeginDate.Focus();
            //    return;
            //}
            //m_mthGetAccount();            
            //long lngRes = m_objDomain.m_lngGetBalance(m_objViewer.txtStoreroom.Value, out dtbResult);
            //if (lngRes > 0)
            //{
            //    m_mthFilterResult();
            //}
            //m_objViewer.m_dgvBalance.DataSource = dtbResult;
            //m_objViewer.m_dgvBalance.Refresh();
            #endregion            

            if (m_objViewer.m_blnForDrugStore)
            {
                if (m_objViewer.m_txtAccountID.Text == m_strCurrentSelectedPeriod)
                {
                    m_mthFilterResultDetailForDrugStore(m_dtbRawResult, m_dtbRecipeDetail);
                }
                else
                {
                    m_dtStartDate = m_objViewer.AccouVO.m_dtmSTARTTIME_DAT;
                    m_dtEndDate = m_objViewer.AccouVO.m_dtmTRANSFERTIME_DAT;
                    long lngRes = m_objDomain.m_lngGetBalanceDetailForDrugStore(m_objViewer.txtStoreroom.Value,m_objViewer.m_txtAccountID.Text,m_objViewer.m_strLastStorageID,m_dtStartDate,m_dtEndDate, out dtbResult);
                    if (lngRes > 0)
                    {
                        m_objDomain.m_lngGetRecipeDetail(m_objViewer.txtStoreroom.Value, m_dtStartDate, m_dtEndDate, out m_dtbRecipeDetail);
                        m_dtbRecipeDetail.PrimaryKey = new DataColumn[] { m_dtbRecipeDetail.Columns["medicineid_chr"] };
                        m_strCurrentSelectedPeriod = m_objViewer.m_txtAccountID.Text;
                        m_dtbRawResult = dtbResult.Copy();
                        m_mthFilterResultDetailForDrugStore(m_dtbRawResult, m_dtbRecipeDetail);
                    }
                }
                if (dtbTrueResult == null || dtbTrueResult.Rows.Count == 0)
                {
                    MessageBox.Show("没有查询到数据", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                m_objViewer.m_dgvBalance.DataSource = dtbTrueResult;
                m_objViewer.m_dgvBalance.Refresh();
            }
            else
            {
                if (m_objViewer.m_txtAccountID.Text == m_strCurrentSelectedPeriod)
                {
                    m_mthFilterResultDetail(m_dtbRawResult);
                }
                else
                {
                    long lngRes = m_objDomain.m_lngGetBalanceDetail(m_objViewer.txtStoreroom.Value, out dtbResult);
                    if (lngRes > 0)
                    {
                        m_dtStartDate = m_objViewer.AccouVO.m_dtmSTARTTIME_DAT;
                        m_dtEndDate = m_objViewer.AccouVO.m_dtmTRANSFERTIME_DAT;
                        m_strCurrentSelectedPeriod = m_objViewer.m_txtAccountID.Text;
                        m_dtbRawResult = dtbResult.Copy();
                        m_mthFilterResultDetail(m_dtbRawResult);
                    }
                }
                if (dtbTrueResult == null || dtbTrueResult.Rows.Count == 0)
                {
                    MessageBox.Show("没有查询到数据", "注意...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                m_objViewer.m_dgvBalance.DataSource = dtbTrueResult;
                m_objViewer.m_dgvBalance.Refresh();

            }
        }
        /*  type_int 1入库、2出库、3初始化、0调价 */
        //实际期末数 应减去 处方数 20080625
        private void m_mthFilterResultDetailForDrugStore(DataTable p_dtResult, DataTable p_dtbRecipeDetail)
        {
            string str = "";
            int i = 0;
            try
            {
               
                if (p_dtResult == null)
                {
                    return;
                }
                if (dtbTrueResult == null || !(dtbTrueResult.IsInitialized))
                {
                    m_mthInitialDataTable();
                }

                DataView dvTemp = p_dtResult.DefaultView;
                dvTemp.RowFilter = string.Empty;
                if (m_objViewer.m_txtMedicineCode.Text.Trim() != string.Empty && Convert.ToString(m_objViewer.m_txtMedicineCode.Tag) != string.Empty)
                {
                    dvTemp.RowFilter = "medicineid_chr = '" + Convert.ToString(m_objViewer.m_txtMedicineCode.Tag) + "'";
                }
                if (!string.IsNullOrEmpty(m_objViewer.txtTypecode.Value) && m_objViewer.txtTypecode.Value != "-1")
                {
                    if (dvTemp.RowFilter == string.Empty)
                        dvTemp.RowFilter = "medicinetypeid_chr = '" + m_objViewer.txtTypecode.Value + "'";
                    else
                        dvTemp.RowFilter += " and medicinetypeid_chr = '" + m_objViewer.txtTypecode.Value + "'";
                }
                p_dtResult = dvTemp.ToTable();

                if (p_dtResult.Rows.Count > 0)
                {
                    string p_strMedicineId = string.Empty;
                    dtbTrueResult.Clear();

                    double p_dblRetailPrice = 0d;//零售单价
                    double p_dblOPAmount = 0d;//基本数量
                    double p_dblIPAmount = 0d;//最小数量
                    double p_dblPackQty = 0d;//包装量
                    double p_dblNewPrice = 0d;//调价后价格
                    double p_dblSum = 0d;//金额
                    double p_dblEndOPAmount = 0d;//期末数量
                    double p_dblEndIPAmount = 0d;//期末数量
                    double p_dblEndRetailPrice = 0d;//期末单价
                    double p_dblEndSum = 0d;//期末金额


                    string strProcessType = string.Empty;//操作类型
                    DataRow p_drRow = null;
                    DataRow p_drNew = null;
                    DataRow drRecipe = null;
                    if (m_objViewer.m_txtAccountID.Text != "未结转")//查询已结转帐务期的内容
                    {
                        if (string.IsNullOrEmpty(m_objViewer.m_strLastStorageID))//上一期帐务期为空，即结转的第一期
                        {
                            for (int i1 = 0; i1 < p_dtResult.Rows.Count; i1++)
                            {
                                p_drRow = p_dtResult.Rows[i1];
                                str = p_drRow["medicineid_chr"].ToString();
                                i = i1;
                                if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                                {
                                    p_drNew = dtbTrueResult.NewRow();
                                    p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                    p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                    p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                    p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                    p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                    //其他帐务期
                                    if (((Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_txtAccountID.Text))
                                        || ((Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && (Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_dtStartDate || Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtEndDate))))
                                    {
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["recipeamount"] = 0;
                                        p_drNew["recipesum"] = 0;
                                        p_drNew["putamount"] = 0;
                                        p_drNew["putsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;

                                        drRecipe = p_dtbRecipeDetail.Rows.Find(p_drRow["medicineid_chr"]);
                                        if (drRecipe != null)
                                        {
                                            p_drNew["recipeamount"] = drRecipe["amount_int"];
                                            p_drNew["recipesum"] = drRecipe["sum_int"];
                                        }
                                        else
                                        {
                                            p_drNew["recipeamount"] = 0;
                                            p_drNew["recipesum"] = 0;
                                        }

                                        p_drNew["realendamount"] = 0;
                                        p_drNew["realendsum"] = 0;
                                        p_drNew["realendamountdiff"] = 0 - Convert.ToDouble(p_drNew["recipeamount"]); ;
                                        p_drNew["realendsumdiff"] = 0 - Convert.ToDouble(p_drNew["recipesum"]);
                                        p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                        p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                        p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                        p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                        dtbTrueResult.Rows.Add(p_drNew);
                                        continue;
                                    }

                                    if (Convert.ToString(p_drRow["isend_int"]) == "")//没有明细记录，只有基础表
                                    {
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                    }
                                    else if (Convert.ToInt16(p_drRow["isend_int"]) == 0)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["opamount_int"]), out p_dblOPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["ipamount_int"]), out p_dblIPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                        if (p_dblPackQty == 0)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                        }
                                        double.TryParse(Convert.ToString(p_drRow["opretailprice_int"]), out p_dblRetailPrice);//单价
                                        double.TryParse(Convert.ToString(p_drRow["opnewretailprice_int"]), out p_dblNewPrice);
                                        p_dblSum = p_dblIPAmount * p_dblRetailPrice / p_dblPackQty;
                                        if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                        {

                                        }
                                        else//最小单位
                                        {
                                            p_dblOPAmount = p_dblIPAmount;
                                        }
                                        //调价
                                        if (Convert.ToInt16(p_drRow["type_int"]) == 0)
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = p_dblOPAmount;
                                            p_drNew["adjustsum"] = p_dblIPAmount * (p_dblNewPrice - p_dblRetailPrice) / p_dblPackQty;
                                            p_drNew["startamount"] = 0;
                                            p_drNew["startsum"] = 0;
                                            p_drNew["endamount"] = 0;
                                            p_drNew["endsum"] = 0;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 3)//期初数
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["startamount"] = p_dblOPAmount;
                                            p_drNew["startsum"] = p_dblSum;
                                            p_drNew["endamount"] = 0;
                                            p_drNew["endsum"] = 0;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 1)
                                        {
                                            p_drNew["inamount"] = p_dblOPAmount;
                                            p_drNew["insum"] = p_dblSum;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["startamount"] = 0;
                                            p_drNew["startsum"] = 0;
                                            p_drNew["endamount"] = 0;
                                            p_drNew["endsum"] = 0;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 2)
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = p_dblOPAmount;
                                            p_drNew["outsum"] = p_dblSum;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["startamount"] = 0;
                                            p_drNew["startsum"] = 0;
                                            p_drNew["endamount"] = 0;
                                            p_drNew["endsum"] = 0;
                                        }                                        
                                    }
                                    else if (p_drRow["isend_int"].ToString() == "1")//取得期末数
                                    {                                        
                                        if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_txtAccountID.Text)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["endopamount_int"]), out p_dblEndOPAmount);//数量
                                            double.TryParse(Convert.ToString(p_drRow["endipamount_int"]), out p_dblEndIPAmount);//数量
                                            double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量          
                                            if (p_dblPackQty == 0)
                                            {
                                                double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                            }
                                            double.TryParse(Convert.ToString(p_drRow["endopretailprice_int"]), out p_dblEndRetailPrice);//单价
                                            if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                            {
                                                
                                            }
                                            else//最小单位
                                            {
                                                p_dblEndOPAmount = p_dblEndIPAmount;
                                            }
                                            p_drNew["endamount"] = p_dblEndOPAmount;
                                            p_drNew["endsum"] = p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                        }
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                    }

                                    drRecipe = p_dtbRecipeDetail.Rows.Find(p_drRow["medicineid_chr"]);
                                    if (drRecipe != null)
                                    {
                                        p_drNew["recipeamount"] = drRecipe["amount_int"];
                                        p_drNew["recipesum"] = drRecipe["sum_int"];
                                    }
                                    else
                                    {
                                        p_drNew["recipeamount"] = 0;
                                        p_drNew["recipesum"] = 0;
                                    }
                                    p_drNew["putamount"] = 0;
                                    p_drNew["putsum"] = 0;

                                    p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                    p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                    p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]) - Convert.ToDouble(p_drNew["recipeamount"]);
                                    p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]) - Convert.ToDouble(p_drNew["recipesum"]);

                                    p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                    p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                    p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                    p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                    dtbTrueResult.Rows.Add(p_drNew);
                                }
                                else
                                {
                                    //其他记录                                
                                    if (Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_txtAccountID.Text)
                                    {
                                        continue;
                                    }

                                    if (p_drRow["isend_int"].ToString() == "1")//取得期末数
                                    {
                                        if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_txtAccountID.Text)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["endopamount_int"]), out p_dblEndOPAmount);//数量
                                            double.TryParse(Convert.ToString(p_drRow["endipamount_int"]), out p_dblEndIPAmount);//数量
                                            double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                            if (p_dblPackQty == 0)
                                            {
                                                double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                            }
                                            double.TryParse(Convert.ToString(p_drRow["endopretailprice_int"]), out p_dblEndRetailPrice);//单价
                                            if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                            {                                                
                                            }
                                            else//最小单位
                                            {
                                                p_dblEndOPAmount = p_dblEndIPAmount;
                                            }
                                            p_drNew["endamount"] = Convert.ToDouble(p_drNew["endamount"]) + p_dblEndOPAmount;
                                            p_drNew["endsum"] = Convert.ToDouble(p_drNew["endsum"]) + p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                        }
                                    }
                                    if (Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtEndDate)
                                    {
                                        continue;
                                    }       

                                    if (Convert.ToInt16(p_drRow["isend_int"]) == 0)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["opamount_int"]), out p_dblOPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["ipamount_int"]), out p_dblIPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                        if (p_dblPackQty == 0)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                        }
                                        double.TryParse(Convert.ToString(p_drRow["opretailprice_int"]), out p_dblRetailPrice);//单价
                                        double.TryParse(Convert.ToString(p_drRow["opnewretailprice_int"]), out p_dblNewPrice);
                                        p_dblSum = p_dblIPAmount * p_dblRetailPrice / p_dblPackQty;
                                        if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                        {

                                        }
                                        else//最小单位
                                        {
                                            p_dblOPAmount = p_dblIPAmount;
                                        }
                                        //调价
                                        if (Convert.ToInt16(p_drRow["type_int"]) == 0)
                                        {
                                            p_drNew["adjustamount"] = Convert.ToDouble(p_drNew["adjustamount"]) + p_dblOPAmount;
                                            p_drNew["adjustsum"] = Convert.ToDouble(p_drNew["adjustsum"]) + p_dblIPAmount * (p_dblNewPrice - p_dblRetailPrice) / p_dblPackQty;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 3)
                                        {
                                            p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"]) + p_dblOPAmount;
                                            p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblSum;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 1)
                                        {
                                            p_drNew["inamount"] = Convert.ToDouble(p_drNew["inamount"]) + p_dblOPAmount;
                                            p_drNew["insum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblSum;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 2)
                                        {
                                            p_drNew["outamount"] = Convert.ToDouble(p_drNew["outamount"]) + p_dblOPAmount;
                                            p_drNew["outsum"] = Convert.ToDouble(p_drNew["outsum"]) + p_dblSum;
                                        }
                                    }
                                    p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                    p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                    p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"])- Convert.ToDouble(p_drNew["recipeamount"]);
                                    p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"])- Convert.ToDouble(p_drNew["recipesum"]);
                                }
                            }
                        }
                        else//上一期不为空
                        {
                            for (int i1 = 0; i1 < p_dtResult.Rows.Count; i1++)
                            {
                                p_drRow = p_dtResult.Rows[i1];
                                str = p_drRow["medicineid_chr"].ToString();
                                i = i1;
                                if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                                {
                                    //其他帐务期
                                    if (((Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_txtAccountID.Text))
                                        || ((Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && (Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_dtStartDate || Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtEndDate))))
                                    {
                                        p_dblOPAmount = 0;
                                        p_dblRetailPrice = 0;
                                        p_dblPackQty = 0d;//包装量
                                        p_dblNewPrice = 0d;//调价后价格

                                        //取得期初数
                                        if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strLastStorageID)
                                        {
                                            if (Convert.ToString(p_drRow["isend_int"]) != "" && p_drRow["isend_int"].ToString() == "1")
                                            {
                                                double.TryParse(Convert.ToString(p_drRow["endopamount_int"]), out p_dblEndOPAmount);//数量
                                                double.TryParse(Convert.ToString(p_drRow["endipamount_int"]), out p_dblEndIPAmount);//数量
                                                double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                                if (p_dblPackQty == 0)
                                                {
                                                    double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                                }
                                                if (p_dblPackQty == 0)
                                                {
                                                    double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                                }
                                                double.TryParse(Convert.ToString(p_drRow["endopretailprice_int"]), out p_dblEndRetailPrice);//单价
                                                if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                                {
                                                    
                                                }
                                                else//最小单位
                                                {
                                                    p_dblEndOPAmount = p_dblEndIPAmount;                                                   
                                                }
                                            }
                                        }
                                        p_drNew = dtbTrueResult.NewRow();
                                        p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                        p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                        p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                        p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                        p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;

                                        drRecipe = p_dtbRecipeDetail.Rows.Find(p_drRow["medicineid_chr"]);
                                        if (drRecipe != null)
                                        {
                                            p_drNew["recipeamount"] = drRecipe["amount_int"];
                                            p_drNew["recipesum"] = drRecipe["sum_int"];
                                        }
                                        else
                                        {
                                            p_drNew["recipeamount"] = 0;
                                            p_drNew["recipesum"] = 0;
                                        }

                                        p_drNew["putamount"] = 0;
                                        p_drNew["putsum"] = 0;
                                        p_drNew["startamount"] = p_dblEndOPAmount;
                                        if (p_dblPackQty == 0 || p_dblEndIPAmount == 0 || p_dblEndRetailPrice == 0)
                                        {
                                            p_drNew["startsum"] = 0;
                                        }
                                        else
                                        {
                                            p_drNew["startsum"] = p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                        }
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        p_drNew["realendamount"] = 0;
                                        p_drNew["realendsum"] = 0;
                                        p_drNew["realendamountdiff"] = 0 - Convert.ToDouble(p_drNew["recipeamount"]);
                                        p_drNew["realendsumdiff"] = 0 - Convert.ToDouble(p_drNew["recipesum"]);
                                        p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                        p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                        p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                        p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                        dtbTrueResult.Rows.Add(p_drNew);
                                        continue;
                                    }

                                    p_drNew = dtbTrueResult.NewRow();
                                    p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                    p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                    p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                    p_drNew["opunit_chr"] = p_drRow["opunit_chr"];                                    
                                    p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                    //取得上期期末数作为本期期初数
                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strLastStorageID)
                                    {
                                        if (Convert.ToString(p_drRow["isend_int"]) != "" && p_drRow["isend_int"].ToString() == "1")
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["endopamount_int"]), out p_dblEndOPAmount);//数量
                                            double.TryParse(Convert.ToString(p_drRow["endipamount_int"]), out p_dblEndIPAmount);//数量
                                            double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                            if (p_dblPackQty == 0)
                                            {
                                                double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                            }
                                            double.TryParse(Convert.ToString(p_drRow["endopretailprice_int"]), out p_dblEndRetailPrice);//单价
                                            if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                            {

                                            }
                                            else//最小单位
                                            {
                                                p_dblEndOPAmount = p_dblEndIPAmount;
                                            }
                                        }
                                        p_dblEndSum = p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                    }
                                    p_drNew["startamount"] = p_dblEndOPAmount;
                                    if (p_dblPackQty == 0 || p_dblEndIPAmount == 0 || p_dblEndRetailPrice == 0)
                                    {
                                        p_drNew["startsum"] = 0;
                                    }
                                    else
                                    {
                                        p_drNew["startsum"] = p_dblEndSum;
                                    }
                                    if (Convert.ToString(p_drRow["isend_int"]) == "")//没有明细记录，只有基础表
                                    {
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                    }
                                    else if (Convert.ToInt16(p_drRow["isend_int"]) == 0)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["opamount_int"]), out p_dblOPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["ipamount_int"]), out p_dblIPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                        if (p_dblPackQty == 0)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                        }
                                        double.TryParse(Convert.ToString(p_drRow["opretailprice_int"]), out p_dblRetailPrice);//单价
                                        double.TryParse(Convert.ToString(p_drRow["opnewretailprice_int"]), out p_dblNewPrice);
                                        p_dblSum = p_dblIPAmount * p_dblRetailPrice / p_dblPackQty;
                                        if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                        {
                                        }
                                        else//最小单位
                                        {
                                            p_dblOPAmount = p_dblIPAmount;
                                        }
                                        //调价
                                        if (Convert.ToInt16(p_drRow["type_int"]) == 0)
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = p_dblOPAmount;
                                            p_drNew["adjustsum"] = p_dblIPAmount * (p_dblNewPrice - p_dblRetailPrice) / p_dblPackQty;
                                            p_drNew["endamount"] = 0;
                                            p_drNew["endsum"] = 0;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 3)
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["endamount"] = 0;
                                            p_drNew["endsum"] = 0;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 1)
                                        {
                                            p_drNew["inamount"] = p_dblOPAmount;
                                            p_drNew["insum"] = p_dblSum;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["endamount"] = 0;
                                            p_drNew["endsum"] = 0;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 2)
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = p_dblOPAmount;
                                            p_drNew["outsum"] = p_dblSum;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["endamount"] = 0;
                                            p_drNew["endsum"] = 0;
                                        }                                        
                                    }
                                    else if (p_drRow["isend_int"].ToString() == "1")//取得期末数
                                    {
                                        if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_txtAccountID.Text)
                                        {
                                            if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                            {
                                                double.TryParse(Convert.ToString(p_drRow["endopamount_int"]), out p_dblEndOPAmount);//数量
                                                double.TryParse(Convert.ToString(p_drRow["endipamount_int"]), out p_dblEndIPAmount);//数量
                                                double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                                if (p_dblPackQty == 0)
                                                {
                                                    double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                                }
                                                double.TryParse(Convert.ToString(p_drRow["endopretailprice_int"]), out p_dblEndRetailPrice);//单价
                                            }
                                            else//最小单位
                                            {
                                                p_dblEndOPAmount = p_dblEndIPAmount;                                               
                                            }
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["endamount"] = p_dblEndOPAmount;
                                            p_drNew["endsum"] = p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                        }
                                    }

                                    drRecipe = p_dtbRecipeDetail.Rows.Find(p_drRow["medicineid_chr"]);
                                    if (drRecipe != null)
                                    {
                                        p_drNew["recipeamount"] = drRecipe["amount_int"];
                                        p_drNew["recipesum"] = drRecipe["sum_int"];
                                    }
                                    else
                                    {
                                        p_drNew["recipeamount"] = 0;
                                        p_drNew["recipesum"] = 0;
                                    }
                                    p_drNew["putamount"] = 0;
                                    p_drNew["putsum"] = 0;

                                    p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                    p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                    p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"])- Convert.ToDouble(p_drNew["recipeamount"]);
                                    p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"])- Convert.ToDouble(p_drNew["recipesum"]);

                                    p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                    p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                    p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                    p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                    dtbTrueResult.Rows.Add(p_drNew);
                                }
                                else
                                {
                                    if (Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_txtAccountID.Text)
                                    {
                                        if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strLastStorageID)
                                        {
                                            if (Convert.ToString(p_drRow["isend_int"]) != "" && p_drRow["isend_int"].ToString() == "1")//取得期初数
                                            {
                                                double.TryParse(Convert.ToString(p_drRow["endopamount_int"]), out p_dblEndOPAmount);//数量
                                                double.TryParse(Convert.ToString(p_drRow["endipamount_int"]), out p_dblIPAmount);//数量
                                                double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                                if (p_dblPackQty == 0)
                                                {
                                                    double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                                }
                                                double.TryParse(Convert.ToString(p_drRow["endopretailprice_int"]), out p_dblEndRetailPrice);//单价
                                                if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                                {
                                                    
                                                }
                                                else//最小单位
                                                {
                                                    p_dblEndOPAmount = p_dblIPAmount;
                                                }
                                                p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"]) + p_dblEndOPAmount;
                                                p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                            }
                                            p_dblOPAmount = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                            p_dblRetailPrice = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);

                                            p_drNew["realendamount"] = p_dblOPAmount;// Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                            p_drNew["realendsum"] = p_dblRetailPrice;// Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                            p_dblOPAmount = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"])- Convert.ToDouble(p_drNew["recipeamount"]);
                                            p_dblRetailPrice = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"])- Convert.ToDouble(p_drNew["recipesum"]);
                                            p_drNew["realendamountdiff"] = p_dblOPAmount;//Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                            p_drNew["realendsumdiff"] = p_dblRetailPrice;// Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);
                                        }
                                        continue;
                                    }

                                    if (Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && (Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_dtStartDate || Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtEndDate))
                                    {
                                        continue;
                                    }

                                    if (Convert.ToString(p_drRow["isend_int"]) == "")//没有明细记录，只有基础表
                                    {
                                    }
                                    else if (Convert.ToInt16(p_drRow["isend_int"]) == 0)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["opamount_int"]), out p_dblOPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["ipamount_int"]), out p_dblIPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                        if (p_dblPackQty == 0)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                        }
                                        double.TryParse(Convert.ToString(p_drRow["opretailprice_int"]), out p_dblRetailPrice);//单价
                                        double.TryParse(Convert.ToString(p_drRow["opnewretailprice_int"]), out p_dblNewPrice);
                                        if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                        {
                                            
                                        }
                                        else//最小单位
                                        {
                                            p_dblOPAmount = p_dblIPAmount;
                                        }

                                        //调价
                                        if (Convert.ToInt16(p_drRow["type_int"]) == 0)
                                        {
                                            p_drNew["adjustamount"] = Convert.ToDouble(p_drNew["adjustamount"]) + p_dblOPAmount;
                                            p_drNew["adjustsum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblIPAmount * (p_dblNewPrice - p_dblRetailPrice) / p_dblPackQty;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 1)
                                        {
                                            p_drNew["inamount"] = Convert.ToDouble(p_drNew["inamount"]) + p_dblOPAmount;
                                            p_drNew["insum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblIPAmount * p_dblRetailPrice / p_dblPackQty;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 2)
                                        {
                                            p_drNew["outamount"] = Convert.ToDouble(p_drNew["outamount"]) + p_dblOPAmount;
                                            p_drNew["outsum"] = Convert.ToDouble(p_drNew["outsum"]) + p_dblIPAmount * p_dblRetailPrice / p_dblPackQty;
                                        }                                           
                                    }
                                    else if (p_drRow["isend_int"].ToString() == "1")//取得期末数
                                    {
                                        if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_txtAccountID.Text)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["endopamount_int"]), out p_dblEndOPAmount);//数量
                                            double.TryParse(Convert.ToString(p_drRow["endipamount_int"]), out p_dblEndIPAmount);//数量
                                            double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                            if (p_dblPackQty == 0)
                                            {
                                                double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                            }
                                            double.TryParse(Convert.ToString(p_drRow["endopretailprice_int"]), out p_dblEndRetailPrice);//单价
                                            if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                            {
                                                
                                            }
                                            else//最小单位
                                            {
                                                p_dblEndOPAmount = p_dblEndIPAmount;
                                            }
                                            p_drNew["endamount"] = Convert.ToDouble(p_drNew["endamount"]) + p_dblEndOPAmount;
                                            p_drNew["endsum"] = Convert.ToDouble(p_drNew["endsum"]) + p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                        }
                                    }

                                    p_dblOPAmount = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                    p_dblRetailPrice = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);

                                    p_drNew["realendamount"] = p_dblOPAmount;// Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                    p_drNew["realendsum"] = p_dblRetailPrice;// Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                    p_dblOPAmount = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"])- Convert.ToDouble(p_drNew["recipeamount"]);
                                    p_dblRetailPrice = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"])- Convert.ToDouble(p_drNew["recipesum"]);
                                    p_drNew["realendamountdiff"] = p_dblOPAmount;//Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                    p_drNew["realendsumdiff"] = p_dblRetailPrice;// Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);
                                }
                            }
                        }
                    }
                    else//查询未结转的内容
                    {
                        if (string.IsNullOrEmpty(m_objViewer.m_strLastStorageID))//上一期帐务期为空，即未结转的是第一期
                        {
                            for (int i1 = 0; i1 < p_dtResult.Rows.Count; i1++)
                            {
                                p_drRow = p_dtResult.Rows[i1];
                                str = p_drRow["medicineid_chr"].ToString();
                                i = i1;
                                if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                                {
                                    p_drNew = dtbTrueResult.NewRow();
                                    p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                    p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                    p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                    p_drNew["opunit_chr"] = p_drRow["opunit_chr"];                                    
                                    p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                    if (Convert.ToString(p_drRow["isend_int"]) == "")//没有明细记录，只有基础表
                                    {
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                    }
                                    else
                                    {
                                        //期末数为当前库存
                                        double.TryParse(Convert.ToString(p_drRow["oprealgross_int"]), out p_dblEndOPAmount);//期末数量
                                        double.TryParse(Convert.ToString(p_drRow["iprealgross_int"]), out p_dblEndIPAmount);//期末数量
                                        double.TryParse(Convert.ToString(p_drRow["oprealprice"]), out p_dblEndRetailPrice);//单价

                                        double.TryParse(Convert.ToString(p_drRow["opamount_int"]), out p_dblOPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["ipamount_int"]), out p_dblIPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                        if (p_dblPackQty == 0)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                        }
                                        double.TryParse(Convert.ToString(p_drRow["opretailprice_int"]), out p_dblRetailPrice);//单价
                                        double.TryParse(Convert.ToString(p_drRow["opnewretailprice_int"]), out p_dblNewPrice);
                                        p_dblSum = p_dblIPAmount * p_dblRetailPrice / p_dblPackQty;
                                        p_dblEndSum = p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                        if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                        {
                                            p_drNew["endamount"] = p_dblEndOPAmount;
                                        }
                                        else//最小单位
                                        {
                                            p_dblOPAmount = p_dblIPAmount;
                                            p_drNew["endamount"] = p_dblEndIPAmount;
                                        }
                                        p_drNew["endsum"] = p_dblEndSum;

                                        //调价
                                        if (Convert.ToInt16(p_drRow["type_int"]) == 0)
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = p_dblOPAmount;
                                            p_drNew["adjustsum"] = p_dblIPAmount * (p_dblNewPrice - p_dblRetailPrice) / p_dblPackQty;
                                            p_drNew["startamount"] = 0;
                                            p_drNew["startsum"] = 0;
                                        }                                        
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 1)
                                        {
                                            p_drNew["inamount"] = p_dblOPAmount;
                                            p_drNew["insum"] = p_dblSum;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["startamount"] = 0;
                                            p_drNew["startsum"] = 0;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 2)
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = p_dblOPAmount;
                                            p_drNew["outsum"] = p_dblSum;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["startamount"] = 0;
                                            p_drNew["startsum"] = 0;
                                        }
                                        else if (Convert.ToInt16(p_drRow["type_int"]) == 3)//取得期初数
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["startamount"] = p_dblOPAmount;
                                            p_drNew["startsum"] = p_dblSum;
                                        }
                                    }

                                    drRecipe = p_dtbRecipeDetail.Rows.Find(p_drRow["medicineid_chr"]);
                                    if (drRecipe != null)
                                    {
                                        p_drNew["recipeamount"] = drRecipe["amount_int"];
                                        p_drNew["recipesum"] = drRecipe["sum_int"];
                                    }
                                    else
                                    {
                                        p_drNew["recipeamount"] = 0;
                                        p_drNew["recipesum"] = 0;
                                    }
                                    p_drNew["putamount"] = 0;
                                    p_drNew["putsum"] = 0;

                                    p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                    p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                    p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"])- Convert.ToDouble(p_drNew["recipeamount"]);
                                    p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"])- Convert.ToDouble(p_drNew["recipesum"]);

                                    p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                    p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                    p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                    p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                    dtbTrueResult.Rows.Add(p_drNew);
                                }
                                else
                                {
                                    double.TryParse(Convert.ToString(p_drRow["opamount_int"]), out p_dblOPAmount);//数量
                                    double.TryParse(Convert.ToString(p_drRow["ipamount_int"]), out p_dblIPAmount);//数量
                                    double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                    if (p_dblPackQty == 0)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                    }
                                    double.TryParse(Convert.ToString(p_drRow["opretailprice_int"]), out p_dblRetailPrice);//单价
                                    double.TryParse(Convert.ToString(p_drRow["opnewretailprice_int"]), out p_dblNewPrice);
                                    p_dblSum = p_dblIPAmount * p_dblRetailPrice / p_dblPackQty;
                                    if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                    {                                        
                                    }
                                    else//最小单位
                                    {                                       
                                        p_dblOPAmount = p_dblIPAmount;                                      
                                    }                                   

                                    //调价
                                    if (Convert.ToInt16(p_drRow["type_int"]) == 0)
                                    {
                                        p_drNew["adjustamount"] = Convert.ToDouble(p_drNew["adjustamount"]) + p_dblOPAmount;
                                        p_drNew["adjustsum"] = Convert.ToDouble(p_drNew["adjustsum"]) + p_dblIPAmount * (p_dblNewPrice - p_dblRetailPrice) / p_dblPackQty;
                                    }
                                    else if (Convert.ToInt16(p_drRow["type_int"]) == 1)
                                    {
                                        p_drNew["inamount"] = Convert.ToDouble(p_drNew["inamount"]) + p_dblOPAmount;
                                        p_drNew["insum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblSum;
                                    }
                                    else if (Convert.ToInt16(p_drRow["type_int"]) == 2)
                                    {
                                        p_drNew["outamount"] = Convert.ToDouble(p_drNew["outamount"]) + p_dblOPAmount;
                                        p_drNew["outsum"] = Convert.ToDouble(p_drNew["outsum"]) + p_dblSum;
                                    }
                                    else if (Convert.ToInt16(p_drRow["type_int"]) == 3)
                                    {
                                        p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"]) + p_dblOPAmount;
                                        p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblSum;
                                    }

                                    p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                    p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                    p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"])- Convert.ToDouble(p_drNew["recipeamount"]);
                                    p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"])- Convert.ToDouble(p_drNew["recipesum"]);
                                }
                            }
                        }
                        else//已有结转记录
                        {
                            for (int i1 = 0; i1 < p_dtResult.Rows.Count; i1++)
                            {
                                p_drRow = p_dtResult.Rows[i1];
                                str = p_drRow["medicineid_chr"].ToString();
                                i = i1;
                                if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                                {
                                    //其他帐务期或未结转的记录，
                                    if (((Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_strLastStorageID))
                                        || ((Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_dtStartDate)))
                                    {
                                        p_drNew = dtbTrueResult.NewRow();
                                        p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                        p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                        p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                        p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                        p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["recipeamount"] = 0;
                                        p_drNew["recipesum"] = 0;
                                        p_drNew["putamount"] = 0;
                                        p_drNew["putsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        //取得期末数 = 库存数
                                        double.TryParse(Convert.ToString(p_drRow["oprealgross_int"]), out p_dblEndOPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["iprealgross_int"]), out p_dblEndIPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["oprealprice"]), out p_dblEndRetailPrice);//数量
                                        double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                        if (p_dblPackQty == 0)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                        }
                                        p_dblEndSum = p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                        if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                        {
                                            p_drNew["endamount"] = p_dblEndOPAmount;                                           
                                        }
                                        else//最小单位
                                        {
                                            p_drNew["endamount"] = p_dblEndIPAmount;
                                        }
                                        p_drNew["endsum"] = p_dblEndSum;

                                        drRecipe = p_dtbRecipeDetail.Rows.Find(p_drRow["medicineid_chr"]);
                                        if (drRecipe != null)
                                        {
                                            p_drNew["recipeamount"] = drRecipe["amount_int"];
                                            p_drNew["recipesum"] = drRecipe["sum_int"];
                                        }
                                        else
                                        {
                                            p_drNew["recipeamount"] = 0;
                                            p_drNew["recipesum"] = 0;
                                        }

                                        //p_drNew["realendamount"] = 0;
                                        //p_drNew["realendsum"] = 0;
                                        //p_drNew["realendamountdiff"] = 0;
                                        //p_drNew["realendsumdiff"] = 0;

                                        p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                        p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                        p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"])- Convert.ToDouble(p_drNew["recipeamount"]);
                                        p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"])- Convert.ToDouble(p_drNew["recipesum"]);

                                        p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                        p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                        p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                        p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                        dtbTrueResult.Rows.Add(p_drNew);
                                        continue;
                                    }

                                    p_drNew = dtbTrueResult.NewRow();
                                    p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                    p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                    p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                    p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                    p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                    double.TryParse(Convert.ToString(p_drRow["oprealgross_int"]), out p_dblEndOPAmount);//期末数量
                                    double.TryParse(Convert.ToString(p_drRow["iprealgross_int"]), out p_dblEndIPAmount);//期末数量
                                    double.TryParse(Convert.ToString(p_drRow["oprealprice"]), out p_dblEndRetailPrice);//单价
                                    double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                    if (p_dblPackQty == 0)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                    }
                                    p_dblEndSum = p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;

                                    double.TryParse(Convert.ToString(p_drRow["opamount_int"]), out p_dblOPAmount);//数量
                                    double.TryParse(Convert.ToString(p_drRow["ipamount_int"]), out p_dblIPAmount);//数量
                                    double.TryParse(Convert.ToString(p_drRow["opretailprice_int"]), out p_dblRetailPrice);//单价
                                    double.TryParse(Convert.ToString(p_drRow["opnewretailprice_int"]), out p_dblNewPrice);
                                    
                                    p_dblSum = p_dblIPAmount * p_dblRetailPrice / p_dblPackQty; 
                                    if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                    {                                        
                                        p_drNew["endamount"] = p_dblEndOPAmount;   
                                    }
                                    else//最小单位
                                    {
                                        p_dblOPAmount = p_dblIPAmount;                                        
                                        p_drNew["endamount"] = p_dblEndIPAmount;
                                        
                                    }
                                    p_drNew["endsum"] = p_dblEndSum;                                    

                                    if (Convert.ToString(p_drRow["isend_int"]) == "")//没有明细记录，只有基础表
                                    {
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;                                        
                                    }
                                    else
                                    {
                                        if (Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtStartDate)
                                        {
                                            //调价
                                            if (Convert.ToInt16(p_drRow["type_int"]) == 0)
                                            {
                                                p_drNew["inamount"] = 0;
                                                p_drNew["insum"] = 0;
                                                p_drNew["outamount"] = 0;
                                                p_drNew["outsum"] = 0;
                                                p_drNew["adjustamount"] = p_dblOPAmount;
                                                p_drNew["adjustsum"] = p_dblIPAmount * (p_dblNewPrice - p_dblRetailPrice) / p_dblPackQty;
                                                p_drNew["startamount"] = 0;
                                                p_drNew["startsum"] = 0;                                                
                                            }
                                            else if (Convert.ToInt16(p_drRow["type_int"]) == 1)
                                            {
                                                p_drNew["inamount"] = p_dblOPAmount;
                                                p_drNew["insum"] = p_dblSum;
                                                p_drNew["outamount"] = 0;
                                                p_drNew["outsum"] = 0;
                                                p_drNew["adjustamount"] = 0;
                                                p_drNew["adjustsum"] = 0;
                                                p_drNew["startamount"] = 0;
                                                p_drNew["startsum"] = 0;
                                            }
                                            else if (Convert.ToInt16(p_drRow["type_int"]) == 2)
                                            {
                                                p_drNew["inamount"] = 0;
                                                p_drNew["insum"] = 0;
                                                p_drNew["outamount"] = p_dblOPAmount;
                                                p_drNew["outsum"] = p_dblSum;
                                                p_drNew["adjustamount"] = 0;
                                                p_drNew["adjustsum"] = 0;
                                                p_drNew["startamount"] = 0;
                                                p_drNew["startsum"] = 0;
                                            }
                                            else if (Convert.ToInt16(p_drRow["type_int"]) == 3)//期初数
                                            {
                                                //取得期初数
                                                if (p_drRow["isend_int"].ToString() == "1")
                                                {
                                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strLastStorageID)
                                                    {
                                                        double.TryParse(Convert.ToString(p_drRow["endopamount_int"]), out p_dblEndOPAmount);//数量
                                                        double.TryParse(Convert.ToString(p_drRow["endipamount_int"]), out p_dblEndIPAmount);//数量
                                                        double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                                        if (p_dblPackQty == 0)
                                                        {
                                                            double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                                        }
                                                        double.TryParse(Convert.ToString(p_drRow["endopretailprice_int"]), out p_dblEndRetailPrice);//单价
                                                        p_dblEndSum = p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                                        if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                                        {
                                                        }
                                                        else//最小单位
                                                        {
                                                            p_dblEndOPAmount = p_dblEndIPAmount;
                                                        }

                                                        p_drNew["startamount"] = p_dblEndOPAmount;
                                                        p_drNew["startsum"] = p_dblEndSum;
                                                        p_drNew["inamount"] = 0;
                                                        p_drNew["insum"] = 0;
                                                        p_drNew["outamount"] = 0;
                                                        p_drNew["outsum"] = 0;
                                                        p_drNew["adjustamount"] = 0;
                                                        p_drNew["adjustsum"] = 0;
                                                    }
                                                    else
                                                    {
                                                        p_drNew["inamount"] = 0;
                                                        p_drNew["insum"] = 0;
                                                        p_drNew["outamount"] = 0;
                                                        p_drNew["outsum"] = 0;
                                                        p_drNew["adjustamount"] = 0;
                                                        p_drNew["adjustsum"] = 0;
                                                        p_drNew["startamount"] = 0;
                                                        p_drNew["startsum"] = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    p_drNew["inamount"] = 0;
                                                    p_drNew["insum"] = 0;
                                                    p_drNew["outamount"] = 0;
                                                    p_drNew["outsum"] = 0;
                                                    p_drNew["adjustamount"] = 0;
                                                    p_drNew["adjustsum"] = 0;
                                                    p_drNew["startamount"] = 0;
                                                    p_drNew["startsum"] = 0;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            p_drNew["inamount"] = 0;
                                            p_drNew["insum"] = 0;
                                            p_drNew["outamount"] = 0;
                                            p_drNew["outsum"] = 0;
                                            p_drNew["adjustamount"] = 0;
                                            p_drNew["adjustsum"] = 0;
                                            p_drNew["startamount"] = 0;
                                            p_drNew["startsum"] = 0;                                       
                                        }
                                    }

                                    
                                    
                                    drRecipe = p_dtbRecipeDetail.Rows.Find(p_drRow["medicineid_chr"]);
                                    if (drRecipe != null)
                                    {
                                        p_drNew["recipeamount"] = drRecipe["amount_int"];
                                        p_drNew["recipesum"] = drRecipe["sum_int"];
                                    }
                                    else
                                    {
                                        p_drNew["recipeamount"] = 0;
                                        p_drNew["recipesum"] = 0;
                                    }
                                    p_drNew["putamount"] = 0;
                                    p_drNew["putsum"] = 0;

                                    p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                    p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                    p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"])- Convert.ToDouble(p_drNew["recipeamount"]);
                                    p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"])- Convert.ToDouble(p_drNew["recipesum"]);

                                    p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                    p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                    p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                    p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                    dtbTrueResult.Rows.Add(p_drNew);
                                }
                                else
                                {
                                    //其他帐务期或未结转的记录                                
                                    if (Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_strLastStorageID)
                                    {
                                        continue;
                                    }
                                    
                                    //取得期初数
                                    if (p_drRow["isend_int"].ToString() == "1")
                                    {
                                        if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strLastStorageID)
                                        {
                                            if (Convert.ToString(p_drRow["isend_int"]) != "" && p_drRow["isend_int"].ToString() == "1")
                                            {
                                                double.TryParse(Convert.ToString(p_drRow["endopamount_int"]), out p_dblEndOPAmount);//数量
                                                double.TryParse(Convert.ToString(p_drRow["endipamount_int"]), out p_dblEndIPAmount);//数量
                                                double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                                if (p_dblPackQty == 0)
                                                {
                                                    double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                                }
                                                double.TryParse(Convert.ToString(p_drRow["endopretailprice_int"]), out p_dblEndRetailPrice);//单价
                                                p_dblEndSum = p_dblEndIPAmount * p_dblEndRetailPrice / p_dblPackQty;
                                                if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                                {
                                                }
                                                else//最小单位
                                                {
                                                    p_dblEndOPAmount = p_dblEndIPAmount;
                                                }
                                            }
                                            p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"]) + p_dblEndOPAmount;
                                            p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblEndSum;
                                        }
                                    }
                                    else
                                    {
                                        if (Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_dtStartDate)
                                        {
                                            continue;
                                        }
                                        double.TryParse(Convert.ToString(p_drRow["opamount_int"]), out p_dblOPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["ipamount_int"]), out p_dblIPAmount);//数量
                                        double.TryParse(Convert.ToString(p_drRow["packqty_dec"]), out p_dblPackQty);//包装量
                                        if (p_dblPackQty == 0)
                                        {
                                            double.TryParse(Convert.ToString(p_drRow["bsepackty"]), out p_dblPackQty);//包装量
                                        }
                                        double.TryParse(Convert.ToString(p_drRow["opretailprice_int"]), out p_dblRetailPrice);//单价
                                        double.TryParse(Convert.ToString(p_drRow["opnewretailprice_int"]), out p_dblNewPrice);
                                        p_dblSum = p_dblIPAmount * p_dblRetailPrice / p_dblPackQty;
                                        if (Convert.ToInt16(p_drRow["opchargeflg_int"]) == 0)//基本单位
                                        {
                                        }
                                        else//最小单位
                                        {
                                            p_dblOPAmount = p_dblIPAmount;
                                        }
                                        if (Convert.ToString(p_drRow["isend_int"]) == "")//没有明细记录，只有基础表
                                        {
                                        }
                                        else
                                        {
                                            if (Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtStartDate)
                                            {
                                                //调价
                                                if (Convert.ToInt16(p_drRow["type_int"]) == 0)
                                                {
                                                    p_drNew["adjustamount"] = Convert.ToDouble(p_drNew["adjustamount"]) + p_dblOPAmount;
                                                    p_drNew["adjustsum"] = Convert.ToDouble(p_drNew["adjustsum"]) + p_dblIPAmount * (p_dblNewPrice - p_dblRetailPrice) / p_dblPackQty;
                                                }
                                                else if (Convert.ToInt16(p_drRow["type_int"]) == 1)
                                                {
                                                    p_drNew["inamount"] = Convert.ToDouble(p_drNew["inamount"]) + p_dblOPAmount;
                                                    p_drNew["insum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblSum;
                                                }
                                                else if (Convert.ToInt16(p_drRow["type_int"]) == 2)
                                                {
                                                    p_drNew["outamount"] = Convert.ToDouble(p_drNew["outamount"]) + p_dblOPAmount;
                                                    p_drNew["outsum"] = Convert.ToDouble(p_drNew["outsum"]) + p_dblSum;
                                                }
                                            }
                                        }
                                    }
                                    p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                    p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                    p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"])- Convert.ToDouble(p_drNew["recipeamount"]);
                                    p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"])- Convert.ToDouble(p_drNew["recipesum"]);
                                }
                            }
                        }
                    }
                }
                else
                {
                    dtbTrueResult.Clear();
                }
                if (!dtbTrueResult.Columns.Contains("SortRowNo"))
                {
                    dtbTrueResult.Columns.Add("SortRowNo", typeof(long));
                }
                m_mthAddTotalSumRow(dtbTrueResult);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,str + "     " +i.ToString());
            }

        }

        /*20080410 唐水敏提供
    分两种情况
一、帐务期（结转）
1、开始时间是帐务期的开始时间，结束时间是帐务期的结束时间
2、如果是第一期，那么期初数就库存初始化的值，单据号是7，如果是非第一期，  期初就拿上一期期未数
2、入库，单据号第九位数字是1
3、出库，单据号第九位数字是2
4、调价，单据号第九位数字是8；
5、期未数：取流水帐表该期的期末数
6、实际期未数量：根据公式算出来，也就是期初+入库-出库
    实际期未金额：根据公式算出来，也就是期初+入库-出库+调价盈亏金额 

注意，相同ID不同批号的数量加起来，也就是不考虑批号
而且注意状态，无效的状态不要选择，金额取四位

二、当前期（没有结转）
1、开始时间是上个帐务期的结束时间加一秒，结束时间是当前时间(如果是第一期，那开始时间参数设置中的“帐务期开始时间”------不明白问阿瑞)
2、如果是第一期，期初数就是库存初始化的，单据号是7，如果非第一期，期初就拿上一期期未
5、期未数：拿当前库存数*/ 
        /// <summary>
        /// 根据条件过滤计算查询结果
        /// </summary>
        private void m_mthFilterResultDetail(DataTable p_dtbResult)
        {
            if (p_dtbResult == null)
            {
                return;
            }
            if (dtbTrueResult == null)
            {
                m_mthInitialDataTable();
            }

            DataView dvTemp = p_dtbResult.DefaultView;
            dvTemp.RowFilter = string.Empty;
            if (m_objViewer.m_txtMedicineCode.Text.Trim() != string.Empty && Convert.ToString(m_objViewer.m_txtMedicineCode.Tag) != string.Empty)
            {
                dvTemp.RowFilter = "medicineid_chr = '" + Convert.ToString(m_objViewer.m_txtMedicineCode.Tag) + "'";
            }
            if (!string.IsNullOrEmpty(m_objViewer.txtTypecode.Value) && m_objViewer.txtTypecode.Value != "-1")
            {
                if (dvTemp.RowFilter == string.Empty)
                    dvTemp.RowFilter = "medicinetypeid_chr = '" + m_objViewer.txtTypecode.Value + "'";
                else
                    dvTemp.RowFilter += " and medicinetypeid_chr = '" + m_objViewer.txtTypecode.Value + "'";
            }
            dvTemp.Sort = "medicinename_vchr,medicineid_chr,accountid_chr";
            p_dtbResult = dvTemp.ToTable();
            DataRow p_drRow = null;
            DataRow p_drNew = null;
            if (p_dtbResult.Rows.Count > 0)
            {
                string p_strMedicineId = string.Empty;
                dtbTrueResult.Clear();
             
                double p_dblRetailPrice = 0d;//零售单价
                double p_dblAmount = 0d;//数量
                double p_dblCommon = 0d;//其他
                double p_dblStartAmount = 0d;
                double p_dblStartSum = 0d;
                int intProcessType = 0;//操作类型

                if (m_objViewer.m_txtAccountID.Text != "未结转")//查询已结转帐务期的内容
                {                    
                    if (string.IsNullOrEmpty(m_objViewer.m_strLastStorageID))//上一期帐务期为空，即结转的第一期
                    {
                        for (int i1 = 0; i1 < p_dtbResult.Rows.Count; i1++)
                        {
                            p_drRow = p_dtbResult.Rows[i1];
                            
                            if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                            {
                                //其他帐务期或未结转的记录，
                                if (((Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_txtAccountID.Text))
                                    || ((Convert.ToString(p_drRow["operatedate_dat"])!=string.Empty && Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtEndDate) && m_intGetProcessType(Convert.ToString(p_drRow["chittyid_vchr"])) != 7))
                                {
                                    p_drNew = dtbTrueResult.NewRow();
                                    p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                    p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                    p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                    p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                    p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                    p_drNew["inamount"] = 0;
                                    p_drNew["insum"] = 0;
                                    p_drNew["outamount"] = 0;
                                    p_drNew["outsum"] = 0;
                                    p_drNew["adjustamount"] = 0;
                                    p_drNew["adjustsum"] = 0;
                                    p_drNew["recipeamount"] = 0;
                                    p_drNew["recipesum"] = 0;
                                    p_drNew["putamount"] = 0;
                                    p_drNew["putsum"] = 0;
                                    p_drNew["startamount"] = 0;
                                    p_drNew["startsum"] = 0;
                                    p_drNew["endamount"] = 0;
                                    p_drNew["endsum"] = 0;
                                    p_drNew["realendamount"] = 0;
                                    p_drNew["realendsum"] = 0;
                                    p_drNew["realendamountdiff"] = 0;
                                    p_drNew["realendsumdiff"] = 0;
                                    p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                    p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                    p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                    p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                    dtbTrueResult.Rows.Add(p_drNew);
                                    continue;
                                }

                                p_drNew = dtbTrueResult.NewRow();
                                p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                double.TryParse(Convert.ToString(p_drRow["amount_int"]), out p_dblAmount);//数量
                                double.TryParse(Convert.ToString(p_drRow["retailprice_int"]), out p_dblRetailPrice);//单价

                                intProcessType = m_intGetProcessType(Convert.ToString(p_drRow["chittyid_vchr"]));
                                switch(intProcessType)
                                {
                                    case 1://入库
                                        p_drNew["inamount"] = p_dblAmount;
                                        p_drNew["insum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 2://出库
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = p_dblAmount;
                                        p_drNew["outsum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 4://取得期初数
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                         p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = p_dblAmount;
                                        p_drNew["startsum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 5://调价
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = p_dblAmount;
                                        double.TryParse(Convert.ToString(p_drRow["newretailprice_int"]), out p_dblCommon);
                                        p_drNew["adjustsum"] = p_dblAmount*(p_dblCommon -p_dblRetailPrice) ;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    default:
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                }

                                if (p_drRow["isend_int"].ToString() == "1")//取得期末数
                                {
                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_txtAccountID.Text)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["endamount_int"]), out p_dblAmount);
                                        double.TryParse(Convert.ToString(p_drRow["endretailprice_int"]), out p_dblRetailPrice);
                                        p_drNew["endamount"] = p_dblAmount;
                                        p_drNew["endsum"] = p_dblAmount * p_dblRetailPrice;
                                    }
                                }

                                p_drNew["recipeamount"] = 0;
                                p_drNew["recipesum"] = 0;
                                p_drNew["putamount"] = 0;
                                p_drNew["putsum"] = 0;

                                p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);

                                p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                dtbTrueResult.Rows.Add(p_drNew);
                            }
                            else
                            {
                                //其他帐务期或未结转的记录                                
                                if (Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_txtAccountID.Text)
                                {
                                    continue;
                                }

                                if (p_drRow["isend_int"].ToString() == "1")//取得期末数
                                {
                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_txtAccountID.Text)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["endamount_int"]), out p_dblAmount);
                                        double.TryParse(Convert.ToString(p_drRow["endretailprice_int"]), out p_dblRetailPrice);
                                        p_drNew["endamount"] = Convert.ToDouble(p_drNew["endamount"]) +p_dblAmount;
                                        p_drNew["endsum"] = Convert.ToDouble(p_drNew["endsum"]) + p_dblAmount * p_dblRetailPrice;  
                                    }
                                }
                                if(Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtEndDate)
                                {
                                    continue;
                                }

                                double.TryParse(Convert.ToString(p_drRow["amount_int"]), out p_dblAmount);//数量
                                double.TryParse(Convert.ToString(p_drRow["retailprice_int"]), out p_dblRetailPrice);//单价

                                intProcessType = m_intGetProcessType(Convert.ToString(p_drRow["chittyid_vchr"]));
                                switch (intProcessType)
                                {
                                    case 1://入库
                                        p_drNew["inamount"] = Convert.ToDouble(p_drNew["inamount"]) + p_dblAmount;
                                        p_drNew["insum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblAmount * p_dblRetailPrice;                                       
                                        break;
                                    case 2://出库                                        
                                        p_drNew["outamount"] = Convert.ToDouble(p_drNew["outamount"]) + p_dblAmount;
                                        p_drNew["outsum"] = Convert.ToDouble(p_drNew["outsum"]) + p_dblAmount * p_dblRetailPrice;                                       
                                        break;
                                    case 4://取得期初数                                       
                                        p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"]) + p_dblAmount;
                                        p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 5://调价                                        
                                        p_drNew["adjustamount"] = Convert.ToDouble(p_drNew["adjustamount"]) + p_dblAmount;
                                        double.TryParse(Convert.ToString(p_drRow["newretailprice_int"]), out p_dblCommon);
                                        p_drNew["adjustsum"] = Convert.ToDouble(p_drNew["adjustsum"]) + p_dblAmount * (p_dblCommon - p_dblRetailPrice);
                                        break;
                                    default:                                       
                                        break;
                                }

                                p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);
                            }
                        }           
                    }
                    else//上一期不为空
                    {
                        for (int i1 = 0; i1 < p_dtbResult.Rows.Count; i1++)
                        {
                            p_drRow = p_dtbResult.Rows[i1];

                            if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                            {
                                //其他帐务期
                                if (((Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_txtAccountID.Text))
                                    || ((Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && (Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_dtStartDate || Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtEndDate))))
                                {
                                    p_dblAmount = 0;
                                    p_dblRetailPrice = 0;
                                    p_dblStartAmount = 0d;
                                    p_dblStartSum = 0d;
                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strLastStorageID)
                                    {
                                        if (p_drRow["isend_int"].ToString() == "1")//取得期初数
                                        {                                            
                                            double.TryParse(Convert.ToString(p_drRow["endamount_int"]), out p_dblAmount);
                                            double.TryParse(Convert.ToString(p_drRow["endretailprice_int"]), out p_dblRetailPrice);                                            
                                        }
                                    }
                                    p_drNew = dtbTrueResult.NewRow();
                                    p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                    p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                    p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                    p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                    p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                    p_drNew["inamount"] = 0;
                                    p_drNew["insum"] = 0;
                                    p_drNew["outamount"] = 0;
                                    p_drNew["outsum"] = 0;
                                    p_drNew["adjustamount"] = 0;
                                    p_drNew["adjustsum"] = 0;
                                    p_drNew["recipeamount"] = 0;
                                    p_drNew["recipesum"] = 0;
                                    p_drNew["putamount"] = 0;
                                    p_drNew["putsum"] = 0;
                                    p_drNew["startamount"] = p_dblAmount;
                                    p_drNew["startsum"] = p_dblAmount * p_dblRetailPrice;
                                    p_drNew["endamount"] = 0;
                                    p_drNew["endsum"] = 0;
                                    p_drNew["realendamount"] = 0;
                                    p_drNew["realendsum"] = 0;
                                    p_drNew["realendamountdiff"] = 0;
                                    p_drNew["realendsumdiff"] = 0;
                                    p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                    p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                    p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                    p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                    dtbTrueResult.Rows.Add(p_drNew);
                                    continue;
                                }
                                if (Convert.ToString(p_drRow["accountid_chr"]) == "")//排除不是在此帐务期内发生的记录
                                {

                                }

                                double.TryParse(Convert.ToString(p_drRow["startamount"]), out p_dblStartAmount);
                                double.TryParse(Convert.ToString(p_drRow["startsum"]), out p_dblStartSum);

                                p_drNew = dtbTrueResult.NewRow();
                                p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                double.TryParse(Convert.ToString(p_drRow["amount_int"]), out p_dblAmount);//数量
                                double.TryParse(Convert.ToString(p_drRow["retailprice_int"]), out p_dblRetailPrice);//单价

                                intProcessType = m_intGetProcessType(Convert.ToString(p_drRow["chittyid_vchr"]));
                                switch (intProcessType)
                                {
                                    case 1://入库
                                        p_drNew["inamount"] = p_dblAmount;
                                        p_drNew["insum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = p_dblStartAmount;
                                        p_drNew["startsum"] = p_dblStartSum;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 2://出库
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = p_dblAmount;
                                        p_drNew["outsum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = p_dblStartAmount;
                                        p_drNew["startsum"] = p_dblStartSum;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 4://取得期初数
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = p_dblStartAmount;
                                        p_drNew["startsum"] = p_dblStartSum;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 5://调价
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = p_dblAmount;
                                        double.TryParse(Convert.ToString(p_drRow["newretailprice_int"]), out p_dblCommon);
                                        p_drNew["adjustsum"] = p_dblAmount * (p_dblCommon - p_dblRetailPrice);
                                        p_drNew["startamount"] = p_dblStartAmount;
                                        p_drNew["startsum"] = p_dblStartSum;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    default:
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = p_dblStartAmount;
                                        p_drNew["startsum"] = p_dblStartSum;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                }

                                if (p_drRow["isend_int"].ToString() == "1")//取得期末数
                                {
                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_txtAccountID.Text)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["endamount_int"]), out p_dblAmount);
                                        double.TryParse(Convert.ToString(p_drRow["endretailprice_int"]), out p_dblRetailPrice);
                                        p_drNew["endamount"] = p_dblAmount;
                                        p_drNew["endsum"] = p_dblAmount * p_dblRetailPrice;
                                    }
                                }

                                p_drNew["recipeamount"] = 0;
                                p_drNew["recipesum"] = 0;
                                p_drNew["putamount"] = 0;
                                p_drNew["putsum"] = 0;

                                p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);

                                p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                dtbTrueResult.Rows.Add(p_drNew);
                            }
                            else
                            {
                                //其他帐务期或未结转的记录                                
                                if (Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_txtAccountID.Text)
                                {
                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strLastStorageID)
                                    {
                                        if (p_drRow["isend_int"].ToString() == "1")//取得期初数
                                        {                                            
                                            double.TryParse(Convert.ToString(p_drRow["endamount_int"]), out p_dblAmount);
                                            double.TryParse(Convert.ToString(p_drRow["endretailprice_int"]), out p_dblRetailPrice);
                                            p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"])+ p_dblAmount;
                                            p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblAmount * p_dblRetailPrice;
                                        }
                                        p_dblAmount = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                        p_dblRetailPrice = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);

                                        p_drNew["realendamount"] = p_dblAmount;// Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                        p_drNew["realendsum"] = p_dblRetailPrice;// Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                        p_dblAmount = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                        p_dblRetailPrice = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);
                                        p_drNew["realendamountdiff"] = p_dblAmount;//Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                        p_drNew["realendsumdiff"] = p_dblRetailPrice;// Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);
                                    }
                                    continue;
                                }

                                if (p_drRow["isend_int"].ToString() == "1")//取得期末数
                                {
                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_txtAccountID.Text)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["endamount_int"]), out p_dblAmount);
                                        double.TryParse(Convert.ToString(p_drRow["endretailprice_int"]), out p_dblRetailPrice);
                                        p_drNew["endamount"] = Convert.ToDouble(p_drNew["endamount"]) + p_dblAmount;
                                        p_drNew["endsum"] = Convert.ToDouble(p_drNew["endsum"]) + p_dblAmount * p_dblRetailPrice;
                                    }
                                }

                                if (Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && (Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_dtStartDate || Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_dtEndDate))
                                {
                                    continue;
                                }

                                double.TryParse(Convert.ToString(p_drRow["amount_int"]), out p_dblAmount);//数量
                                double.TryParse(Convert.ToString(p_drRow["retailprice_int"]), out p_dblRetailPrice);//单价

                                intProcessType = m_intGetProcessType(Convert.ToString(p_drRow["chittyid_vchr"]));
                                switch (intProcessType)
                                {
                                    case 1://入库
                                        p_drNew["inamount"] = Convert.ToDouble(p_drNew["inamount"]) + p_dblAmount;
                                        p_drNew["insum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 2://出库                                        
                                        p_drNew["outamount"] = Convert.ToDouble(p_drNew["outamount"]) + p_dblAmount;
                                        p_drNew["outsum"] = Convert.ToDouble(p_drNew["outsum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 4://取得期初数                                       
                                        //p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"]) + p_dblAmount;
                                        //p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 5://调价                                        
                                        p_drNew["adjustamount"] = Convert.ToDouble(p_drNew["adjustamount"]) + p_dblAmount;
                                        double.TryParse(Convert.ToString(p_drRow["newretailprice_int"]), out p_dblCommon);
                                        p_drNew["adjustsum"] = Convert.ToDouble(p_drNew["adjustsum"]) + p_dblAmount * (p_dblCommon - p_dblRetailPrice);
                                        break;
                                    default:
                                        break;
                                }

                                p_dblAmount = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                p_dblRetailPrice = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);

                                p_drNew["realendamount"] = p_dblAmount;// Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                p_drNew["realendsum"] = p_dblRetailPrice;// Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                p_dblAmount = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                p_dblRetailPrice = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);
                                p_drNew["realendamountdiff"] = p_dblAmount;//Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                p_drNew["realendsumdiff"] = p_dblRetailPrice;// Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);
                            }
                        }      
                    }
                }
                else//查询未结转的内容
                {
                    if (string.IsNullOrEmpty(m_objViewer.m_strLastStorageID))//上一期帐务期为空，即未结转的是第一期
                    {
                        for (int i1 = 0; i1 < p_dtbResult.Rows.Count; i1++)
                        {
                            p_drRow = p_dtbResult.Rows[i1];

                            if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                            {
                                p_drNew = dtbTrueResult.NewRow();
                                p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                double.TryParse(Convert.ToString(p_drRow["amount_int"]), out p_dblAmount);//数量
                                double.TryParse(Convert.ToString(p_drRow["retailprice_int"]), out p_dblRetailPrice);//单价

                                intProcessType = m_intGetProcessType(Convert.ToString(p_drRow["chittyid_vchr"]));
                                switch (intProcessType)
                                {
                                    case 1://入库
                                        p_drNew["inamount"] = p_dblAmount;
                                        p_drNew["insum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 2://出库
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = p_dblAmount;
                                        p_drNew["outsum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 4://取得期初数
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = p_dblAmount;
                                        p_drNew["startsum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 5://调价
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = p_dblAmount;
                                        double.TryParse(Convert.ToString(p_drRow["newretailprice_int"]), out p_dblCommon);
                                        p_drNew["adjustsum"] = p_dblAmount * (p_dblCommon - p_dblRetailPrice);
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    default:
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                }

                                //期末数为当前库存
                                double.TryParse(Convert.ToString(p_drRow["realamount"]), out p_dblAmount);
                                double.TryParse(Convert.ToString(p_drRow["realsum"]), out p_dblRetailPrice);
                                p_drNew["endamount"] = p_dblAmount;
                                p_drNew["endsum"] = p_dblRetailPrice;                                    

                                p_drNew["recipeamount"] = 0;
                                p_drNew["recipesum"] = 0;
                                p_drNew["putamount"] = 0;
                                p_drNew["putsum"] = 0;

                                p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);

                                p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                dtbTrueResult.Rows.Add(p_drNew);
                            }
                            else
                            {
                                double.TryParse(Convert.ToString(p_drRow["amount_int"]), out p_dblAmount);//数量
                                double.TryParse(Convert.ToString(p_drRow["retailprice_int"]), out p_dblRetailPrice);//单价

                                intProcessType = m_intGetProcessType(Convert.ToString(p_drRow["chittyid_vchr"]));
                                switch (intProcessType)
                                {
                                    case 1://入库
                                        p_drNew["inamount"] = Convert.ToDouble(p_drNew["inamount"]) + p_dblAmount;
                                        p_drNew["insum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 2://出库                                        
                                        p_drNew["outamount"] = Convert.ToDouble(p_drNew["outamount"]) + p_dblAmount;
                                        p_drNew["outsum"] = Convert.ToDouble(p_drNew["outsum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 4://取得期初数                                       
                                        p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"]) + p_dblAmount;
                                        p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 5://调价                                        
                                        p_drNew["adjustamount"] = Convert.ToDouble(p_drNew["adjustamount"]) + p_dblAmount;
                                        double.TryParse(Convert.ToString(p_drRow["newretailprice_int"]), out p_dblCommon);
                                        p_drNew["adjustsum"] = Convert.ToDouble(p_drNew["adjustsum"]) + p_dblAmount * (p_dblCommon - p_dblRetailPrice);
                                        break;
                                    default:
                                        break;
                                }

                                p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);
                            }
                        }
                    }

                    else//已有结转记录
                    {
                        for (int i1 = 0; i1 < p_dtbResult.Rows.Count; i1++)
                        {
                            p_drRow = p_dtbResult.Rows[i1];

                            if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                            {
                                //其他帐务期或未结转的记录，
                                if (((Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_strLastStorageID))
                                    || ((Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_dtStartDate)))
                                {
                                    p_drNew = dtbTrueResult.NewRow();
                                    p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                    p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                    p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                    p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                    p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                    p_drNew["inamount"] = 0;
                                    p_drNew["insum"] = 0;
                                    p_drNew["outamount"] = 0;
                                    p_drNew["outsum"] = 0;
                                    p_drNew["adjustamount"] = 0;
                                    p_drNew["adjustsum"] = 0;
                                    p_drNew["recipeamount"] = 0;
                                    p_drNew["recipesum"] = 0;
                                    p_drNew["putamount"] = 0;
                                    p_drNew["putsum"] = 0;
                                    p_drNew["startamount"] = 0;
                                    p_drNew["startsum"] = 0;
                                    p_drNew["endamount"] = 0;
                                    p_drNew["endsum"] = 0;
                                    p_drNew["realendamount"] = 0;
                                    p_drNew["realendsum"] = 0;
                                    p_drNew["realendamountdiff"] = 0;
                                    p_drNew["realendsumdiff"] = 0;
                                    p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                    p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                    p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                    p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                    dtbTrueResult.Rows.Add(p_drNew);
                                    continue;
                                }

                                p_drNew = dtbTrueResult.NewRow();
                                p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                                p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                                p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                                p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                                p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                                double.TryParse(Convert.ToString(p_drRow["amount_int"]), out p_dblAmount);//数量
                                double.TryParse(Convert.ToString(p_drRow["retailprice_int"]), out p_dblRetailPrice);//单价

                                intProcessType = m_intGetProcessType(Convert.ToString(p_drRow["chittyid_vchr"]));
                                switch (intProcessType)
                                {
                                    case 1://入库
                                        p_drNew["inamount"] = p_dblAmount;
                                        p_drNew["insum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 2://出库
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = p_dblAmount;
                                        p_drNew["outsum"] = p_dblAmount * p_dblRetailPrice;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 4://取得期初数
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    case 5://调价
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = p_dblAmount;
                                        double.TryParse(Convert.ToString(p_drRow["newretailprice_int"]), out p_dblCommon);
                                        p_drNew["adjustsum"] = p_dblAmount * (p_dblCommon - p_dblRetailPrice);
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                    default:
                                        p_drNew["inamount"] = 0;
                                        p_drNew["insum"] = 0;
                                        p_drNew["outamount"] = 0;
                                        p_drNew["outsum"] = 0;
                                        p_drNew["adjustamount"] = 0;
                                        p_drNew["adjustsum"] = 0;
                                        p_drNew["startamount"] = 0;
                                        p_drNew["startsum"] = 0;
                                        p_drNew["endamount"] = 0;
                                        p_drNew["endsum"] = 0;
                                        break;
                                }

                                //取得期初数
                                if (p_drRow["isend_int"].ToString() == "1")
                                {
                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strLastStorageID)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["endamount_int"]), out p_dblAmount);
                                        double.TryParse(Convert.ToString(p_drRow["endretailprice_int"]), out p_dblRetailPrice);
                                        p_drNew["startamount"] = p_dblAmount;
                                        p_drNew["startsum"] = p_dblAmount * p_dblRetailPrice;
                                    }
                                }
                                //取得期末数 = 库存数
                                double.TryParse(Convert.ToString(p_drRow["realamount"]), out p_dblAmount);
                                double.TryParse(Convert.ToString(p_drRow["realsum"]), out p_dblRetailPrice);
                                p_drNew["endamount"] = p_dblAmount;
                                p_drNew["endsum"] = p_dblRetailPrice;                                    

                                p_drNew["recipeamount"] = 0;
                                p_drNew["recipesum"] = 0;
                                p_drNew["putamount"] = 0;
                                p_drNew["putsum"] = 0;

                                p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);

                                p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                                p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                                p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                                p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                                dtbTrueResult.Rows.Add(p_drNew);
                            }
                            else
                            {
                                //其他帐务期或未结转的记录                                
                                if (Convert.ToString(p_drRow["accountid_chr"]) != "" && Convert.ToString(p_drRow["accountid_chr"]) != m_objViewer.m_strLastStorageID)                                    
                                {
                                    continue;
                                }

                                //取得期初数
                                if (p_drRow["isend_int"].ToString() == "1")
                                {
                                    if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strLastStorageID)
                                    {
                                        double.TryParse(Convert.ToString(p_drRow["endamount_int"]), out p_dblAmount);
                                        double.TryParse(Convert.ToString(p_drRow["endretailprice_int"]), out p_dblRetailPrice);
                                        p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"]) + p_dblAmount;
                                        p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblAmount * p_dblRetailPrice;
                                    }
                                }
                                //取得期末数 = 库存数
                                double.TryParse(Convert.ToString(p_drRow["realamount"]), out p_dblAmount);
                                double.TryParse(Convert.ToString(p_drRow["realsum"]), out p_dblRetailPrice);
                                p_drNew["endamount"] = p_dblAmount;
                                p_drNew["endsum"] = p_dblRetailPrice;   

                                if (Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty && Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_dtStartDate)
                                {
                                    continue;
                                }

                                double.TryParse(Convert.ToString(p_drRow["amount_int"]), out p_dblAmount);//数量
                                double.TryParse(Convert.ToString(p_drRow["retailprice_int"]), out p_dblRetailPrice);//单价

                                intProcessType = m_intGetProcessType(Convert.ToString(p_drRow["chittyid_vchr"]));
                                switch (intProcessType)
                                {
                                    case 1://入库
                                        p_drNew["inamount"] = Convert.ToDouble(p_drNew["inamount"]) + p_dblAmount;
                                        p_drNew["insum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 2://出库                                        
                                        p_drNew["outamount"] = Convert.ToDouble(p_drNew["outamount"]) + p_dblAmount;
                                        p_drNew["outsum"] = Convert.ToDouble(p_drNew["outsum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 4://取得期初数                                       
                                        //p_drNew["startamount"] = Convert.ToDouble(p_drNew["startamount"]) + p_dblAmount;
                                        //p_drNew["startsum"] = Convert.ToDouble(p_drNew["startsum"]) + p_dblAmount * p_dblRetailPrice;
                                        break;
                                    case 5://调价                                        
                                        p_drNew["adjustamount"] = Convert.ToDouble(p_drNew["adjustamount"]) + p_dblAmount;
                                        double.TryParse(Convert.ToString(p_drRow["newretailprice_int"]), out p_dblCommon);
                                        p_drNew["adjustsum"] = Convert.ToDouble(p_drNew["adjustsum"]) + p_dblAmount * (p_dblCommon - p_dblRetailPrice);
                                        break;
                                    default:
                                        break;
                                }

                                p_drNew["realendamount"] = Convert.ToDouble(p_drNew["startamount"]) + Convert.ToDouble(p_drNew["inamount"]) - Convert.ToDouble(p_drNew["outamount"]);
                                p_drNew["realendsum"] = Convert.ToDouble(p_drNew["startsum"]) + Convert.ToDouble(p_drNew["insum"]) - Convert.ToDouble(p_drNew["outsum"]) + Convert.ToDouble(p_drNew["adjustsum"]);
                                p_drNew["realendamountdiff"] = Convert.ToDouble(p_drNew["realendamount"]) - Convert.ToDouble(p_drNew["endamount"]);
                                p_drNew["realendsumdiff"] = Convert.ToDouble(p_drNew["realendsum"]) - Convert.ToDouble(p_drNew["endsum"]);
                            }
                        }    
                    }
                }   
            }
            if (!dtbTrueResult.Columns.Contains("SortRowNo"))
            {
                dtbTrueResult.Columns.Add("SortRowNo", typeof(long));
            }
            m_mthAddTotalSumRow(dtbTrueResult);
        }

        internal void m_mthAddTotalSumRow(DataTable p_dtbTarget)
        {
            if (p_dtbTarget.Rows.Count > 0)
            {
                double dblTempSum = 0d;
                DataRow drAdd = p_dtbTarget.NewRow();
                for (int i1 = 0; i1 < p_dtbTarget.Columns.Count; i1++)
                {
                    dblTempSum = 0d;
                    if (p_dtbTarget.Columns[i1].ColumnName == "medicinename_vchr" || p_dtbTarget.Columns[i1].ColumnName == "medicineid_chr")//medicineid_chr是为删除此行时定位
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbTarget.Columns[i1].DataType == typeof(double))
                    {
                        for (int i2 = 0; i2 < p_dtbTarget.Rows.Count; i2++)
                        {
                            dblTempSum += Convert.ToDouble(p_dtbTarget.Rows[i2][i1]);
                        }
                        drAdd[i1] = dblTempSum;
                    }
                }
                p_dtbTarget.Rows.Add(drAdd);
                p_dtbTarget.AcceptChanges();
            }  
        }

        #region 获取操作类型
        /// <summary>
        /// 获取操作类型
        /// </summary>
        /// <param name="p_strChitty">单据号</param>
        /// <returns></returns>
        private int m_intGetProcessType(string p_strChitty)
        {
            int intType = 0;
            if (string.IsNullOrEmpty(p_strChitty))
            {
                return -1;
            }

            try
            {
                //入库；出库；盘点；药房初始化；调价
                char chrPro = p_strChitty[9];
                //m_objDomain.m_lngGetBillType(false,out strType);
                if (chrPro.ToString() == m_strType.Split(';')[0])
                {
                    intType = 1;//入库
                }
                else if (chrPro.ToString() == m_strType.Split(';')[1])
                {
                    intType = 2;//出库
                }
                else if (chrPro.ToString() == m_strType.Split(';')[2])
                {
                    intType = 3;//盘点
                }
                else if (chrPro.ToString() == m_strType.Split(';')[3])
                {
                    intType = 4;//药库初始化
                }
                else if (chrPro.ToString() == m_strType.Split(';')[4])
                {
                    intType = 5;//调价
                }
            }
            catch 
            {
                
            }
            return intType;
        }

        /// <summary>
        /// 获取操作类型（药房）
        /// </summary>
        /// <param name="p_strChitty">单据号</param>
        /// <returns></returns>
        private string m_strGetProcessTypeForDrugStore(string p_strChitty)
        {
            string strType = string.Empty;
            string m_strType = string.Empty;
            if (string.IsNullOrEmpty(p_strChitty))
            {
                return strType;
            }

            try
            {
                //入库；出库；盘点；请领；药房初始化；调价
                if (p_strChitty.Length < 10)
                    return strType;
                //m_objDomain.m_lngGetBillType(true,out m_strType); 
                char chrPro = p_strChitty[9];
                if (chrPro.ToString() == m_strType.Split(';')[0])
                {
                    strType = "01";//入库
                }
                else if (chrPro.ToString() == m_strType.Split(';')[1])
                {
                    strType = "02";//出库
                }
                else if (chrPro.ToString() == m_strType.Split(';')[2])
                {
                    strType = "03";//盘点
                }
                else if (chrPro.ToString() == m_strType.Split(';')[3])
                {
                    strType = "04";//请领
                }
                else if (chrPro.ToString() == m_strType.Split(';')[4])
                {
                    strType = "05";//药房初始化
                }
                else if (chrPro.ToString() == m_strType.Split(';')[5])
                {
                    strType = "06";//调价
                }
            }
            catch
            {

            }
            return strType;
        }
        
        #endregion
        /// <summary>
        /// 初始化数据
        /// </summary>
        private void m_mthInitialDataTable()
        {
            dtbTrueResult = new DataTable();
            DataColumn[] dcColArr = new DataColumn[] { new DataColumn("medicineid_chr", typeof(string)), new DataColumn("medicinename_vchr", typeof(string)), new DataColumn("medspec_vchr", typeof(string)), 
                new DataColumn("opunit_chr", typeof(string)),new DataColumn("productorid_chr", typeof(string)),
            new DataColumn("realendamountdiff", typeof(double)),new DataColumn("realendsumdiff", typeof(double)),new DataColumn("inamount", typeof(double)),new DataColumn("insum", typeof(double)),
            new DataColumn("outamount", typeof(double)),new DataColumn("outsum", typeof(double)),new DataColumn("adjustamount", typeof(double)),new DataColumn("adjustsum", typeof(double)),
            new DataColumn("recipeamount", typeof(double)),new DataColumn("recipesum", typeof(double)),new DataColumn("startamount", typeof(double)),new DataColumn("startsum", typeof(double)),
            new DataColumn("endamount", typeof(double)),new DataColumn("endsum", typeof(double)),new DataColumn("realendamount", typeof(double)),new DataColumn("realendsum", typeof(double)),
            new DataColumn("putamount", typeof(double)),new DataColumn("putsum", typeof(double)),new DataColumn("assistcode_chr", typeof(string)),new DataColumn("wbcode_chr", typeof(string)),
            new DataColumn("pycode_chr", typeof(string)),};
            dtbTrueResult.Columns.AddRange(dcColArr);
            dtbTrueResult.PrimaryKey = new DataColumn[] { dtbTrueResult.Columns["medicineid_chr"] };
        }

        #region 作废
        /// <summary>
        /// 根据条件过滤计算查询结果
        /// </summary>
        private void m_mthFilterResult()
        {
           if(dtbResult == null)
           {
               return;
           }
           DataTable dtbTemp = dtbResult.Copy();
           DataView dvTemp = dtbResult.DefaultView;
           if (Convert.ToString(m_objViewer.m_txtMedicineCode.Tag) != string.Empty)
           {
               dvTemp.RowFilter = "medicineid_chr = '" + Convert.ToString(m_objViewer.m_txtMedicineCode.Tag) + "'";
           }
           if (!string.IsNullOrEmpty(m_objViewer.txtTypecode.Value) && m_objViewer.txtTypecode.Value != "-1")
           {
               if(dvTemp.RowFilter == string.Empty)
                dvTemp.RowFilter = "medicinetypeid_chr = '" + m_objViewer.txtTypecode.Value + "'";
               else
                dvTemp.RowFilter += "and medicinetypeid_chr = '" + m_objViewer.txtTypecode.Value + "'";
           }
           dtbResult = dvTemp.ToTable();
           DataRow p_drRow = null;
           DataRow p_drNew = null;
           if (dtbResult.Rows.Count > 0)
           {
               string p_strMedicineId = string.Empty;
               dtbTemp.Clear();
               double p_dblStartAmount = 0d;
               double p_dblStartSum = 0d;
               double p_dblEndAmount = 0d;
               double p_dblEndSum = 0d;
               double p_dblCommon = 0d;//共用
               for (int i1 = 0; i1 < dtbResult.Rows.Count; i1++)
               {
                  
                   p_drRow = dtbResult.Rows[i1];                   
                   if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                   {                       
                       if (p_drRow["isend_int"].ToString() == "1")//取得期初数和期末数
                       {
                           if (Convert.ToString(p_drRow["accountid_chr"]) == m_objViewer.m_strBackAccount
                               && m_objViewer.m_strBackAccount == m_objViewer.m_strForeAccount && m_objViewer.m_strBackAccount != string.Empty)
                           {
                                double.TryParse(Convert.ToString(p_drRow["startamount"]),out p_dblStartAmount);
                                double.TryParse(Convert.ToString(p_drRow["startsum"]), out p_dblStartSum);
                                double.TryParse(Convert.ToString(p_drRow["endamount"]), out p_dblEndAmount);
                                double.TryParse(Convert.ToString(p_drRow["endsum"]), out p_dblEndSum);
                                p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                           }
                           else
                           {
                               continue;
                           }
                       }
                       else
                       {
                           //操作日期必须在查询范围内
                           if (Convert.ToString(p_drRow["operatedate_dat"]) != string.Empty)
                           {
                               //if (Convert.ToDateTime(p_drRow["operatedate_dat"]) < m_objViewer.m_dtpSearchBeginDate.Value
                               //    || Convert.ToDateTime(p_drRow["operatedate_dat"]) > m_objViewer.m_dtpSearchEndDate.Value)
                               //{
                               //    continue;
                               //}
                           }
                           if (p_strMedicineId != p_drRow["medicineid_chr"].ToString())
                           {
                               p_dblStartAmount = 0d;
                               p_dblStartSum = 0d;
                               p_dblEndAmount = 0d;
                               p_dblEndSum = 0d;
                           }
                       }
                       
                       p_drNew = dtbTemp.NewRow();
                       p_drNew["medicineid_chr"] = p_drRow["medicineid_chr"];
                       p_drNew["medicinename_vchr"] = p_drRow["medicinename_vchr"];
                       p_drNew["medspec_vchr"] = p_drRow["medspec_vchr"];
                       p_drNew["opunit_chr"] = p_drRow["opunit_chr"];
                       p_drNew["productorid_chr"] = p_drRow["productorid_chr"];
                       double.TryParse(Convert.ToString(p_drRow["realendamount"]),out p_dblCommon);
                       p_drNew["realendamountdiff"] = p_dblCommon - p_dblEndAmount;
                       double.TryParse(Convert.ToString(p_drRow["realendsum"]), out p_dblCommon);
                       p_drNew["realendsumdiff"] = p_dblCommon - p_dblEndSum;
                       double.TryParse(Convert.ToString(p_drRow["inamount"]), out p_dblCommon);
                       p_drNew["inamount"] = p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["insum"]), out p_dblCommon);
                       p_drNew["insum"] = p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["outamount"]), out p_dblCommon);
                       p_drNew["outamount"] = p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["outsum"]), out p_dblCommon);
                       p_drNew["outsum"] = p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["adjustamount"]), out p_dblCommon);
                       p_drNew["adjustamount"] = p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["adjustsum"]), out p_dblCommon);
                       p_drNew["adjustsum"] = p_dblCommon;
                       p_drNew["recipeamount"] = p_drRow["recipeamount"];
                       p_drNew["recipesum"] = p_drRow["recipesum"];
                       p_drNew["startamount"] = p_dblStartAmount;
                       p_drNew["startsum"] = p_dblStartSum;
                       p_drNew["endamount"] = p_dblEndAmount;
                       p_drNew["endsum"] = p_dblEndSum;
                       double.TryParse(Convert.ToString(p_drRow["realendamount"]), out p_dblCommon);
                       p_drNew["realendamount"] = p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["realendsum"]), out p_dblCommon);
                       p_drNew["realendsum"] = p_dblCommon;
                       p_drNew["putamount"] = p_drRow["putamount"];
                       p_drNew["putsum"] = p_drRow["putsum"];
                       p_drNew["type_int"] = p_drRow["type_int"];
                       p_drNew["isend_int"] = p_drRow["isend_int"];
                       p_drNew["state_int"] = p_drRow["state_int"];
                       p_drNew["accountid_chr"] = p_drRow["accountid_chr"];
                       p_drNew["medicinetypeid_chr"] = p_drRow["medicinetypeid_chr"];
                       p_drNew["operatedate_dat"] = p_drRow["operatedate_dat"];
                       p_drNew["assistcode_chr"] = p_drRow["assistcode_chr"];
                       p_drNew["wbcode_chr"] = p_drRow["wbcode_chr"];
                       p_drNew["pycode_chr"] = p_drRow["pycode_chr"];
                       p_strMedicineId = p_drRow["medicineid_chr"].ToString();
                       dtbTemp.Rows.Add(p_drNew);
                   }
                   else
                   {
                       double.TryParse(Convert.ToString(p_drRow["realendamount"]), out p_dblCommon);
                       p_drNew["realendamountdiff"] = p_dblCommon - p_dblEndAmount;
                       double.TryParse(Convert.ToString(p_drRow["realendsum"]), out p_dblCommon);
                       p_drNew["realendsumdiff"] = p_dblCommon - p_dblEndSum;
                       double.TryParse(Convert.ToString(p_drRow["inamount"]), out p_dblCommon);
                       p_drNew["inamount"] = Convert.ToDouble(p_drNew["inamount"]) + p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["insum"]), out p_dblCommon);
                       p_drNew["insum"] = Convert.ToDouble(p_drNew["insum"]) + p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["outamount"]), out p_dblCommon);
                       p_drNew["outamount"] = Convert.ToDouble(p_drNew["outamount"]) + p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["outsum"]), out p_dblCommon);
                       p_drNew["outsum"] = Convert.ToDouble(p_drNew["outsum"]) + p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["adjustamount"]), out p_dblCommon);
                       p_drNew["adjustamount"] = Convert.ToDouble(p_drNew["adjustamount"]) + p_dblCommon;
                       double.TryParse(Convert.ToString(p_drRow["adjustsum"]), out p_dblCommon);
                       p_drNew["adjustsum"] = Convert.ToDouble(p_drNew["adjustsum"]) + p_dblCommon;
                   }
                   
               }
               dtbResult = dtbTemp.Copy();
               dtbResult.Columns.Remove("type_int");
               dtbResult.Columns.Remove("isend_int");
               dtbResult.Columns.Remove("state_int");
               dtbResult.Columns.Remove("accountid_chr");
               dtbResult.Columns.Remove("medicinetypeid_chr");
               dtbResult.Columns.Remove("operatedate_dat");
           }
        }

        //#region 获取时间对应的帐务期
        ///// <summary>
        ///// 获取时间对应的帐务期
        ///// </summary>
        //internal void m_mthGetAccount()
        //{
        //    string m_strAccountName = string.Empty;
        //    m_objDomain.m_lngGetAccount(m_objViewer.txtStoreroom.Value, DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchBeginDate.Text).ToString("yyyy-MM-dd HH:mm:ss")), out m_strAccountName);
        //    m_objViewer.m_strForeAccount = m_strAccountName;
        //    m_objDomain.m_lngGetAccount(m_objViewer.txtStoreroom.Value, DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpSearchEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss")), out m_strAccountName);
        //    m_objViewer.m_strBackAccount = m_strAccountName;
        //}
        //#endregion
        #endregion

        #region 从网格导出数据到Excel
        /// <summary>
        /// 从网格导出数据到Excel
        /// </summary>
        internal void m_mthExportToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel文件(*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = true;
            saveFileDialog.Title = "导出Excel文件到";
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            Stream myStream;
            myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding("gb2312"));
            string str = "";
            try
            {
                //添加列标题
                for (int iOr = 0; iOr < m_objViewer.m_dgvBalance.ColumnCount; iOr++)
                {
                    if (m_objViewer.m_dgvBalance.Columns[iOr].Visible == false) continue;
                    if (iOr > 0)
                    {
                        str += "\t";
                    }
                    str += m_objViewer.m_dgvBalance.Columns[iOr].HeaderText.Replace("\n", "");
                }
                sw.WriteLine(str);
                //添加行文本
                StringBuilder objStrBuilder = null;
                for (int iOr = 0; iOr < m_objViewer.m_dgvBalance.Rows.Count; iOr++)
                {
                    objStrBuilder = new StringBuilder();
                    for (int jOr = 0; jOr < m_objViewer.m_dgvBalance.Columns.Count; jOr++)
                    {
                        if (m_objViewer.m_dgvBalance.Columns[jOr].Visible == false) continue;
                        if (jOr > 0)
                        {
                            objStrBuilder.Append("\t");
                        }
                        objStrBuilder.Append(m_objViewer.m_dgvBalance.Rows[iOr].Cells[jOr].Value.ToString());
                    }
                    sw.WriteLine(objStrBuilder);
                }
                MessageBox.Show("导出成功！", "盘点对账表", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sw.Close();
                myStream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
        #endregion

        internal void m_mthPrint()
        {

            DataTable p_dtPrint = (m_objViewer.m_dgvBalance.DataSource as DataTable).Copy();
            if (p_dtPrint.Columns.Contains("productorid_chr"))
            {
                p_dtPrint.Columns.Remove("productorid_chr");
            }
            if (p_dtPrint.Columns.Contains("SortRowNo"))
            {
                p_dtPrint.Columns.Remove("SortRowNo");
            }
            if (Convert.ToString(p_dtPrint.Rows[p_dtPrint.Rows.Count - 1]["medicineid_chr"]) == "合计")
            {
                p_dtPrint.Rows.Remove(p_dtPrint.Rows[p_dtPrint.Rows.Count - 1]);
            }
            DataStore ds = new DataStore();
            ds.LibraryList = clsPublic.PBLPath;
            ds.DataWindowObject = "ms_balancereport";
            ds.Reset();
            ds.Modify("t_title.text='" + this.m_objViewer.objController.m_objComInfo.m_strGetHospitalTitle()+ "'");
            ds.Modify("storagename.text='" + m_objViewer.txtStoreroom.Text + "'");
            ds.Modify("date.text='" + m_objViewer.m_lblAccountTime.Text + "'");
            ds.Retrieve(p_dtPrint);
            com.digitalwave.iCare.gui.HIS.clsPublic.PrintDialog(ds);
        }

        internal long m_lngGetLastBalanceTime(string p_strStorageID,out DateTime dtBegin)
        {
            long lngRes = 0;
            lngRes = m_objDomain.m_lngGetLastBalanceTime(p_strStorageID,out dtBegin);
            return lngRes;
        }

        internal long m_lngGetSysParm(string p_strID, out string strBegin)
        {
            return  m_objDomain.m_lngGetSysParm(p_strID, out strBegin);
        }

        #region 获取帐务期ID列表
        /// <summary>
        /// 获取帐务期ID列表
        /// </summary>
        /// <param name="p_objAccArr">帐务期结转</param>
        internal void m_mthGetAccountIDList(out clsMS_AccountPeriodVO[] p_objAccArr)
        {
            clsDcl_TotalAccountReport objDomain = new clsDcl_TotalAccountReport();
            long lngRes = objDomain.m_lngGetAccountPeriod(m_objViewer.txtStoreroom.Value, out p_objAccArr);
        }

        /// <summary>
        /// 设置帐务期列表至界面
        /// </summary>
        /// <param name="p_objAccArr">帐务期结转</param>
        internal void m_mthSetAccountPeriodToList(clsMS_AccountPeriodVO[] p_objAccArr)
        {
            m_objViewer.m_lsvAccountIDList.Items.Clear();
            if (p_objAccArr == null || p_objAccArr.Length == 0)
            {
                clsMS_AccountPeriodVO objNow = new clsMS_AccountPeriodVO();
                string strDate;
                long lngRes = m_objDomain.m_lngGetSysParm("5001", out strDate);
                objNow.m_dtmSTARTTIME_DAT = Convert.ToDateTime(strDate);
                objNow.m_dtmENDTIME_DAT = clsPublic.SysDateTimeNow;
                objNow.m_dtmTRANSFERTIME_DAT = clsPublic.SysDateTimeNow;
                objNow.m_strACCOUNTID_CHR = "未结转";

                StringBuilder stbID = new StringBuilder(30);
                stbID.Append(objNow.m_strACCOUNTID_CHR);
                stbID.Append("  ");
                stbID.Append(objNow.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                stbID.Append("～");
                stbID.Append(objNow.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                ListViewItem lsiNow = new ListViewItem(stbID.ToString());
                lsiNow.Tag = objNow;
                stbID = null;
                m_objViewer.m_lsvAccountIDList.Items.Add(lsiNow);
                return;
            }


            try
            {
                m_objViewer.m_lsvAccountIDList.Items.Clear();
                m_objViewer.m_lsvAccountIDList.BeginUpdate();
                ListViewItem[] lsiItems = new ListViewItem[p_objAccArr.Length];
                for (int iItem = 0; iItem < p_objAccArr.Length; iItem++)
                {
                    StringBuilder stbID = new StringBuilder(30);
                    stbID.Append(p_objAccArr[iItem].m_strACCOUNTID_CHR);
                    stbID.Append("  ");
                    stbID.Append(p_objAccArr[iItem].m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    stbID.Append("～");
                    stbID.Append(p_objAccArr[iItem].m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    lsiItems[iItem] = new ListViewItem(stbID.ToString());
                    lsiItems[iItem].Tag = p_objAccArr[iItem];
                    stbID = null;
                }
                m_objViewer.m_lsvAccountIDList.Items.AddRange(lsiItems);

                //添加未结转选项
                if (clsPublic.SysDateTimeNow > p_objAccArr[p_objAccArr.Length - 1].m_dtmENDTIME_DAT)
                {
                    clsMS_AccountPeriodVO objNow = new clsMS_AccountPeriodVO();
                    objNow.m_dtmSTARTTIME_DAT = Convert.ToDateTime(p_objAccArr[p_objAccArr.Length - 1].m_dtmENDTIME_DAT.AddSeconds(1).ToString("yyyy-MM-dd HH:mm:ss"));
                    objNow.m_dtmENDTIME_DAT = clsPublic.SysDateTimeNow;
                    objNow.m_dtmTRANSFERTIME_DAT = clsPublic.SysDateTimeNow;
                    objNow.m_strACCOUNTID_CHR = "未结转";

                    StringBuilder stbID = new StringBuilder(30);
                    stbID.Append(objNow.m_strACCOUNTID_CHR);
                    stbID.Append("  ");
                    stbID.Append(objNow.m_dtmSTARTTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    stbID.Append("～");
                    stbID.Append(objNow.m_dtmENDTIME_DAT.ToString("yyyy年MM月dd日 HH:mm:ss"));
                    ListViewItem lsiNow = new ListViewItem(stbID.ToString());
                    lsiNow.Tag = objNow;
                    stbID = null;
                    m_objViewer.m_lsvAccountIDList.Items.Add(lsiNow);
                }
            }
            catch (Exception objEx)
            {
                com.digitalwave.Utility.clsLogText objLogger = new com.digitalwave.Utility.clsLogText();
                bool blnRes = objLogger.LogError(objEx);
            }
            finally
            {
                m_objViewer.m_lsvAccountIDList.EndUpdate();
            }
        }
        #endregion

        internal long m_lngGetRoomid(out DataTable dtTemp)
        {
            return m_objDomain.m_lngGetRoomid(out dtTemp);
        }

        internal void m_mthGetAccountIDListForDrugStore(out clsMS_AccountPeriodVO[] p_objAccArr)
        {
            m_objDomain.m_mthGetAccountIDListForDrugStore(m_objViewer.txtStoreroom.Value, out p_objAccArr);
        }
       internal DataRow drDelete = null;
        internal void m_mthDeleteTotalSumRow()
        {
            drDelete = dtbTrueResult.Rows.Find("合计");
            if (drDelete != null)
            {
                dtbTrueResult.Rows.Remove(drDelete);
                dtbTrueResult.AcceptChanges();
                //m_mthAddTotalSumRow(dtbTrueResult);
                //m_objViewer.m_dgvBalance.Refresh();
            }
        }
    }
}