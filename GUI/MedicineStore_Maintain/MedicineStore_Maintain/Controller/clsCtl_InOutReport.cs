using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    class clsCtl_InOutReport : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 全局变量

        /// <summary>
        /// 模块控制类
        /// </summary>
        private clsDcl_InOutReport m_objDomain = null;

        /// <summary>
        /// 窗体
        /// </summary>
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmInOutReport m_objViewer;
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;

        #endregion

        #region 构造函数

        /// <summary>
        /// 出库明细报表
        /// </summary>
        public clsCtl_InOutReport()
        {
            m_objDomain = new clsDcl_InOutReport();
        }
        #endregion

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象.
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmInOutReport)frmMDI_Child_Base_in;
        }
        #endregion

        #region 查询药品
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {

                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_objViewer.m_dtbMedicinDict);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = m_objViewer.txtTypecode.Location.X;// - m_objViewer.m_txtMedicine.Size.Width);
                int Y = m_objViewer.txtTypecode.Location.Y + 60;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.CancelResult += new MecicineCancelAndReturn(m_ctlQueryMedicint_CancelResult);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthGetMedicineInfo();
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_objViewer.m_dtbMedicinDict;
        }

        internal void m_ctlQueryMedicint_CancelResult()
        {
            m_objViewer.m_txtMedicine.Focus();
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }

            if(m_objViewer.m_rbtSingle.Checked)
                m_objViewer.m_txtMedicine.Text = MS_VO.m_strMedicineName;
            else
                m_objViewer.m_txtMedicine.Text = MS_VO.m_strMedicineCode;
            m_objViewer.m_txtMedicine.Tag = MS_VO.m_strMedicineID;
            
        }
        #endregion

        #region 查询明细(药库使用）
        /// <summary>
        /// 查询明细(药库使用）
        /// </summary>
        internal void m_mthQuery()
        {
            DateTime m_dtmBegin,m_dtmEnd;
            if(!DateTime.TryParse(m_objViewer.m_dtpBeginDate.Text,out m_dtmBegin))
            {
                MessageBox.Show("请输入查询开始时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpEndDate.Text, out m_dtmEnd))
            {
                MessageBox.Show("请输入查询结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            //DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            //DateTime m_dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));

            if (m_dtmBegin.Date > m_dtmEnd.Date)
            {
                MessageBox.Show("查询开始时间不能超过结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable m_dtbReport = null;
            long lngRes = 0;
                        
            string strMedTypeCode = "";
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }

            string p_strMedicineID = string.Empty;
            if (m_objViewer.m_rbtSingle.Checked)
                p_strMedicineID = Convert.ToString(m_objViewer.m_txtMedicine.Tag);
            else
                p_strMedicineID = m_objViewer.m_txtMedicine.Text;
            
            int p_intFilter = 0;//查询有无情况组合
            if (m_objViewer.m_rbtOutAll.Checked && m_objViewer.m_rbtInAll.Checked)
            {
                p_intFilter = 0;
            }
            else if (m_objViewer.m_rbtOutAll.Checked && m_objViewer.m_rbtInY.Checked)
            {
                p_intFilter = 1;
            }
            else if (m_objViewer.m_rbtOutAll.Checked && m_objViewer.m_rbtInN.Checked)
            {
                p_intFilter = 2;
            }
            else if (m_objViewer.m_rbtOutY.Checked && m_objViewer.m_rbtInAll.Checked)
            {
                p_intFilter = 3;
            }
            else if (m_objViewer.m_rbtOutY.Checked && m_objViewer.m_rbtInY.Checked)
            {
                p_intFilter = 4;
            }
            else if (m_objViewer.m_rbtOutY.Checked && m_objViewer.m_rbtInN.Checked)
            {
                p_intFilter = 5;
            }
            else if (m_objViewer.m_rbtOutN.Checked && m_objViewer.m_rbtInAll.Checked)
            {
                p_intFilter = 6;
            }
            else if (m_objViewer.m_rbtOutN.Checked && m_objViewer.m_rbtInY.Checked)
            {
                p_intFilter = 7;
            }
            else if (m_objViewer.m_rbtOutN.Checked && m_objViewer.m_rbtInN.Checked)
            {
                p_intFilter = 8;
            }


            lngRes = m_objDomain.m_lngGetInOutDetail(m_objViewer.m_rbtCombine.Checked,m_objViewer.m_strStorageID, m_dtmBegin, m_dtmEnd, strMedTypeCode,p_strMedicineID,
                p_intFilter,m_objViewer.m_ckbShowNoAmount.Checked,out m_dtbReport);
            if (lngRes < 0)
            {
                MessageBox.Show("获取报表内容失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DataRow dr in m_dtbReport.Rows)
            {
                if (dr["storageamount"].ToString().Length == 0)
                {
                    dr["storageamount"] = 0;
                }
                if (dr["inamount"].ToString().Length == 0)
                {
                    dr["inamount"] = 0;
                }
                if (dr["outamount"].ToString().Length == 0)
                {
                    dr["outamount"] = 0;
                }
            }
            this.m_objViewer.m_dgvInOutDetail.DataSource = m_dtbReport;

            m_objViewer.m_dwcData.Modify("storagename.text='" + m_objViewer.m_strStorageName + "'");
            m_objViewer.m_dwcData.Modify("begindate.text='" + m_objViewer.m_dtpBeginDate.Text  +"'");
            m_objViewer.m_dwcData.Modify("enddate.text='" + m_objViewer.m_dtpEndDate.Text + "'");
            m_objViewer.m_dwcData.SetRedrawOff();
            m_objViewer.m_dwcData.Retrieve(m_dtbReport);
            m_objViewer.m_dwcData.SetRedrawOn();
            m_objViewer.m_dwcData.Refresh();            

            if (!m_dtbReport.Columns.Contains("SortRowNo"))
            {
                m_dtbReport.Columns.Add("SortRowNo", typeof(long));
            }
            m_mthAddTotalSumRow(m_dtbReport);
        }
        #endregion 
        
        #region 获取药品字典最小元素集
        /// <summary>
        /// 获取药品字典最小元素集
        /// </summary>
        internal void m_mthGetMedicineInfo()
        {
            long lngRes = m_objDomain.m_lngGetBaseMedicine(false,string.Empty, m_objViewer.m_strStorageID, out m_objViewer.m_dtbMedicinDict);
        }
        #endregion

        #region 根据药房Id获取对应的部门ID
        /// <summary>
        /// 根据药房Id获取对应的部门ID
        /// </summary>
        /// <param name="m_strStorageID"></param>
        /// <param name="m_strDeptID"></param>
        internal void m_lngGetDeptIDForStore(string m_strStorageID, out string m_strDeptID)
        {
            m_objDomain.m_lngGetDeptIDForStore(m_strStorageID, out m_strDeptID);
        }
        #endregion

        #region 查询出入库情况(药房使用）
        /// <summary>
        /// 查询出入库情况(药房使用）
        /// </summary>
        internal void m_mthQueryForDrugStore()
        {
            DateTime m_dtmBegin, m_dtmEnd;
            if (!DateTime.TryParse(m_objViewer.m_dtpBeginDate.Text, out m_dtmBegin))
            {
                MessageBox.Show("请输入查询开始时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!DateTime.TryParse(m_objViewer.m_dtpEndDate.Text, out m_dtmEnd))
            {
                MessageBox.Show("请输入查询结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //DateTime m_dtmBegin = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpBeginDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));
            //DateTime m_dtmEnd = DateTime.Parse(Convert.ToDateTime(m_objViewer.m_dtpEndDate.Text).ToString("yyyy-MM-dd HH:mm:ss"));

            if (m_dtmBegin.Date > m_dtmEnd.Date)
            {
                MessageBox.Show("查询开始时间不能超过结束时间", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable m_dtbReport = null;
            long lngRes = 0; 
            
            string strMedTypeCode = "";
            if (!string.IsNullOrEmpty(this.m_objViewer.txtTypecode.Value))
            {
                strMedTypeCode = this.m_objViewer.txtTypecode.Value.ToString();
            }

            string p_strMedicineID = string.Empty;
            if (m_objViewer.m_rbtSingle.Checked)
                p_strMedicineID = Convert.ToString(m_objViewer.m_txtMedicine.Tag);
            else
                p_strMedicineID = m_objViewer.m_txtMedicine.Text;

            int p_intFilter = 0;//查询有无情况组合
            if (m_objViewer.m_rbtOutAll.Checked && m_objViewer.m_rbtInAll.Checked)
            {
                p_intFilter = 0;
            }
            else if (m_objViewer.m_rbtOutAll.Checked && m_objViewer.m_rbtInY.Checked)
            {
                p_intFilter = 1;
            }
            else if (m_objViewer.m_rbtOutAll.Checked && m_objViewer.m_rbtInN.Checked)
            {
                p_intFilter = 2;
            }
            else if (m_objViewer.m_rbtOutY.Checked && m_objViewer.m_rbtInAll.Checked)
            {
                p_intFilter = 3;
            }
            else if (m_objViewer.m_rbtOutY.Checked && m_objViewer.m_rbtInY.Checked)
            {
                p_intFilter = 4;
            }
            else if (m_objViewer.m_rbtOutY.Checked && m_objViewer.m_rbtInN.Checked)
            {
                p_intFilter = 5;
            }
            else if (m_objViewer.m_rbtOutN.Checked && m_objViewer.m_rbtInAll.Checked)
            {
                p_intFilter = 6;
            }
            else if (m_objViewer.m_rbtOutN.Checked && m_objViewer.m_rbtInY.Checked)
            {
                p_intFilter = 7;
            }
            else if (m_objViewer.m_rbtOutN.Checked && m_objViewer.m_rbtInN.Checked)
            {
                p_intFilter = 8;
            }

            lngRes = m_objDomain.m_lngGetInOutDetailForDrugStore(m_objViewer.m_rbtCombine.Checked, m_objViewer.m_strDeptID, m_dtmBegin, m_dtmEnd, strMedTypeCode, p_strMedicineID,
                p_intFilter, m_objViewer.m_ckbShowNoAmount.Checked, out m_dtbReport);
            if (lngRes < 0)
            {
                MessageBox.Show("获取报表内容失败", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }           

            foreach (DataRow dr in m_dtbReport.Rows)
            {
                if (dr["storageamount"].ToString().Length == 0)
                {
                    dr["storageamount"] = 0;
                }
                if (dr["inamount"].ToString().Length == 0)
                {
                    dr["inamount"] = 0;
                }
                if (dr["outamount"].ToString().Length == 0)
                {
                    dr["outamount"] = 0;
                }
            }
            this.m_objViewer.m_dgvInOutDetail.DataSource = m_dtbReport;

            m_objViewer.m_dwcData.Modify("storagename.text='" + m_objViewer.m_strStorageName + "'");
            m_objViewer.m_dwcData.Modify("begindate.text='" + m_objViewer.m_dtpBeginDate.Text + "'");
            m_objViewer.m_dwcData.Modify("enddate.text='" + m_objViewer.m_dtpEndDate.Text + "'");
            m_objViewer.m_dwcData.SetRedrawOff();
            m_objViewer.m_dwcData.Retrieve(m_dtbReport);
            m_objViewer.m_dwcData.SetRedrawOn();
            m_objViewer.m_dwcData.Refresh();

            if (!m_dtbReport.Columns.Contains("SortRowNo"))
            {
                m_dtbReport.Columns.Add("SortRowNo", typeof(long));
            }
            m_mthAddTotalSumRow(m_dtbReport);
        }
        #endregion  

        public void m_mthFillMedType()
        {
            //this.m_objViewer.txtTypecode.m_listView.Items.Clear();
            clsDcl_OutStorageDetailReport2 objTmp = new clsDcl_OutStorageDetailReport2();
            DataTable dtRoom;
            DataTable dtVonder;
            DataTable dtMedType;
            long lngRes = objTmp.m_lngGetExptypeAndVendor(m_objViewer.m_blnForDrugStore, out dtRoom, out dtVonder, out dtMedType);
            DataView dtvMedType = new DataView(dtMedType);
            clsColumns_VO[] column2 = new clsColumns_VO[] { new clsColumns_VO("类别名称", "medicinetypename_vchr", HorizontalAlignment.Left, 145) };
            this.m_objViewer.txtTypecode.m_mthInitListView(column2);
            if (m_objViewer.m_blnForDrugStore)
            {
                dtvMedType.RowFilter = "medicineroomid='" + this.m_objViewer.m_strDeptID + "'";
            }
            else
            {
                dtvMedType.RowFilter = "medicineroomid='" + this.m_objViewer.m_strStorageID + "'";
            }
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

        internal void m_mthAddTotalSumRow(DataTable p_dtbResult)
        {
            if (p_dtbResult.Rows.Count > 0)
            {
                double dblTempSum = 0d;
                DataRow drAdd = p_dtbResult.NewRow();
                for (int i1 = 0; i1 < p_dtbResult.Columns.Count; i1++)
                {
                    dblTempSum = 0d;
                    if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "medicinename_vchr")
                    {
                        drAdd[i1] = "合计";
                    }
                    else if (p_dtbResult.Columns[i1].ColumnName.ToLower() == "storageamount" || p_dtbResult.Columns[i1].ColumnName.ToLower() == "inamount" ||
                        p_dtbResult.Columns[i1].ColumnName.ToLower() == "outamount")
                    {
                        for (int i2 = 0; i2 < p_dtbResult.Rows.Count; i2++)
                        {
                            if (p_dtbResult.Rows[i2][i1].ToString() == "") continue;
                            dblTempSum += Convert.ToDouble(p_dtbResult.Rows[i2][i1]);
                        }
                        drAdd[i1] = dblTempSum;
                    }
                }
                p_dtbResult.Rows.Add(drAdd);
                p_dtbResult.AcceptChanges();
            }  
        }
    }
}
