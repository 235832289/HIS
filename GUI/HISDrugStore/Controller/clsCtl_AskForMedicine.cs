using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.gui.MedicineStore;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房请领控制层
    /// </summary>
    public class clsCtl_AskForMedicine : com.digitalwave.GUI_Base.clsController_Base
    {   
        /// <summary>
        /// 药房请领主界面
        /// </summary>
        private frmAskForMedicine m_objViewer;
        /// <summary>
        /// 药房请领主界面域控制层
        /// </summary>
        private clsDcl_AskForMedicine m_objDomain;
        private clsDcl_AskForMedDetail m_objDomainDetail;
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_AskForMedicine()
        {
            m_objDomain = new clsDcl_AskForMedicine();
            m_objDomainDetail = new clsDcl_AskForMedDetail();
        }
        public void m_mthIniMedData()
        {
            //m_objDomainDetail.m_lngGetMedicineInfo(this.m_objViewer.strout m_dtMedicineInfo);
        }
        /// <summary>
        /// 药品基本信息表
        /// </summary>
        private DataTable m_dtMedicineInfo = new DataTable();
        /// <summary>
        /// 药房请领主表信息
        /// </summary>
        internal DataTable m_dtAskMainInfo = new DataTable();
        /// <summary>
        /// 药库出库主表信息
        /// </summary>
        internal DataTable m_dtOutStorageMainInfo = new DataTable();
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmAskForMedicine)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 获取请领部门信息
        /// </summary>
        public void m_mthGetApplyDeptInfo(out DataTable m_dtDept)
        {
            long lngRes = -1;
            m_dtDept=new DataTable ();
            lngRes = this.m_objDomain.m_lngGetApplyDept(out m_dtDept);
          
        }
        /// <summary>
        /// 获取出库部门信息
        /// </summary>
        public void m_mthGetExportDeptInfo()
        {
            long lngRes = -1;
            DataTable m_dtExportDept = new DataTable();
            lngRes = this.m_objDomain.m_lngGetExportDept(out m_dtExportDept);
            this.m_objViewer.m_cboExportDept.Item.Add("全部", "0001");
            if (lngRes > 0 && m_dtExportDept != null)
            {
                for (int i = 0; i < m_dtExportDept.Rows.Count; i++)
                {
                    this.m_objViewer.m_cboExportDept.Item.Add(m_dtExportDept.Rows[i]["medicineroomname"].ToString(), m_dtExportDept.Rows[i]["medicineroomid"].ToString());
                }
            }
        }
        /// <summary>
        /// 药品查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null; 
        #region 显示药品字典最小元素信息查询窗体
        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(this.m_dtMedicineInfo);
                m_objViewer.Controls.Add(m_ctlQueryMedicint);

                int X = 0;
                int Y = 0;
                X = m_objViewer.m_txtMedName.Location.X + m_objViewer.gradientPanel2.Location.X;
                Y = m_objViewer.m_txtMedName.Location.Y + m_objViewer.m_txtMedName.Size.Height + m_objViewer.gradientPanel2.Location.Y;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(frmQueryForm_ReturnInfo);
                m_ctlQueryMedicint.RefreshMedicine += new RefreshMedicineInfo(m_ctlQueryMedicint_RefreshMedicine);
            }

            m_ctlQueryMedicint.Visible = true;
            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        private void m_ctlQueryMedicint_RefreshMedicine()
        {
            m_mthIniMedData();
            m_ctlQueryMedicint.m_dtbMedicineInfo = m_dtMedicineInfo;
        }

        internal void frmQueryForm_ReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                return;
            }
            m_objViewer.m_txtMedName.Tag = MS_VO.m_strMedicineID;
            m_objViewer.m_txtMedName.Text = MS_VO.m_strMedicineName;
            m_objViewer.m_txtBillId.Focus();
        }
        #endregion
        /// <summary>
        /// 根据输入条件查询药房请领主表信息
        /// </summary>
        public void m_mthGetAskInfoByConditions()
        {
            m_dtAskMainInfo = new DataTable();
            int m_intStatus = this.m_objViewer.m_cboStatus.SelectedIndex - 1;
            string m_strExpDept = this.m_objViewer.m_cboExportDept.SelectItemValue == "0001" ? string.Empty : this.m_objViewer.m_cboExportDept.SelectItemValue;
             this.m_objDomain.m_lngGetAskInfo(this.m_objViewer.m_datBegin.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_datEnd.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_txtApplyDept.StrItemId, m_strExpDept, m_intStatus, this.m_objViewer.m_txtMedName.Text, this.m_objViewer.m_txtBillId.Text, out m_dtAskMainInfo);
        }
        /// <summary>
        /// 获取药房当天请领主表信息
        /// </summary>
        public void m_mthGetCurrentDayAskInfo(string m_strAskDeptid,string m_strStorageid)
        {
            m_dtAskMainInfo = new DataTable();
            m_dtOutStorageMainInfo = new DataTable();
            this.m_objDomain.m_lngGetAskInfo(clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"), clsPub.CurrentDateTimeNow.ToString("yyyy-MM-dd"),m_strAskDeptid,m_strStorageid, out m_dtAskMainInfo, out m_dtOutStorageMainInfo);
            this.m_mthBindData();
        }
        /// <summary>
        /// 绑定主表信息
        /// </summary>
        public void m_mthBindData()
        {    
           // DataView dv = new DataView(this.m_dtAskMainInfo);
            this.m_objViewer.m_dgvMain.DataSource = m_dtAskMainInfo;

        }
        /// <summary>
        /// 根据主表流水号获取明细表信息
        /// </summary>
        public void m_lngGetAskDetailInfoByid()
        {
            long lngRes = 0;
            DataTable m_dtDetail=new DataTable ();
            string m_strSeq=this.m_objViewer.m_dgvMain.Rows[this.m_objViewer.m_dgvMain.CurrentCell.RowIndex].Cells["m_txtSeq"].Value.ToString().Trim();
            lngRes = this.m_objDomain.m_lngGetAskDetailInfoByid(false,Convert.ToInt64(m_strSeq), out m_dtDetail);//false随便给的值，因此界面没有使用
            if (lngRes > 0)
            {
                this.m_objViewer.m_dgvDetail.DataSource = m_dtDetail;
            }
        }
        #region 删除请领药品信息
        /// <summary>
        /// 删除请领药品信息
        /// </summary>
        internal void m_mthDeleteAskInfo()
        {
            List<long> lngCheckRowIndex = new List<long>();
            List<long> lngWrongRowIndex = new List<long>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMain.Rows.Count; iSe++)
            {
                if (m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value != null && Convert.ToBoolean(m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value))
                {
                    string strState = m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtStatus"].Value.ToString().Trim();
                    if (strState == "药房审核" || strState == "药库审核")//已审核
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtSeq"].Value));
                        continue;
                    }
                lngCheckRowIndex.Add(Convert.ToInt64(m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtSeq"].Value));
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录已审核，将不能删除，是否继续？", "药房请领", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (lngCheckRowIndex.Count == 0)
            {
                MessageBox.Show("请先打勾选择新制的药房请领信息", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否作废选中记录？", "药房请领", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            long lngRes = m_objDomain.m_lngDeleAskInfo(lngCheckRowIndex.ToArray());
            if (lngRes > 0)
            {
                MessageBox.Show("删除成功", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
                {
                    for (int j = 0; j < lngCheckRowIndex.Count; j++)
                    {
                        if (Convert.ToInt64(m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value)== lngCheckRowIndex[j])
                        {
                            m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "作废";
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("删除失败", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region 提交请领药品信息
        /// <summary>
        /// 提交请领药品信息
        /// </summary>
        internal void m_mthCommitAskInfo()
        {
            List<clsDS_Ask_VO> m_objAskVoList = new List<clsDS_Ask_VO>();
            clsDS_Ask_VO TempVo;
            List<long> lngWrongRowIndex = new List<long>();
            for (int iSe = 0; iSe < m_objViewer.m_dgvMain.Rows.Count; iSe++)
            {
                if (m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value != null && Convert.ToBoolean(m_objViewer.m_dgvMain.Rows[iSe].Cells[0].Value))
                {
                    string strState = m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtStatus"].Value.ToString().Trim();
                    if (strState == "药房审核" || strState == "药库审核")//已审核
                    {
                        lngWrongRowIndex.Add(Convert.ToInt64(m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtSeq"].Value));
                        continue;
                    }
                    TempVo = new clsDS_Ask_VO();
                    TempVo.m_lngSERIESID_INT = Convert.ToInt64(m_objViewer.m_dgvMain.Rows[iSe].Cells["m_txtSeq"].Value);
                    TempVo.m_intSTATUS_INT = 2;
                    TempVo.m_strCOMMITER_CHR=this.m_objViewer.LoginInfo.m_strEmpID;
                    TempVo.m_datCOMMIT_DAT=clsPub.CurrentDateTimeNow;
                    m_objAskVoList.Add(TempVo);
                }
            }

            if (lngWrongRowIndex.Count > 0)
            {
                DialogResult drResultQ = MessageBox.Show("部分已选择记录已审核，将不能提交，是否继续？", "药房请领", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (drResultQ == DialogResult.No)
                {
                    return;
                }
            }

            if (m_objAskVoList.Count == 0)
            {
                MessageBox.Show("请打勾选择新制的药房请领信息", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult drResult = MessageBox.Show("是否提交选中记录？", "药房请领", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (drResult == DialogResult.No)
            {
                return;
            }
            long lngRes = m_objDomain.m_lngCommiteAskInfo(m_objAskVoList.ToArray());
            if (lngRes > 0)
            {
                MessageBox.Show("提交成功", "药品入库", MessageBoxButtons.OK, MessageBoxIcon.Information);

                for (int i = 0; i < this.m_objViewer.m_dgvMain.Rows.Count; i++)
                {
                    for (int j = 0; j < m_objAskVoList.Count; j++)
                    {
                        if (Convert.ToInt64(m_objViewer.m_dgvMain.Rows[i].Cells["m_txtSeq"].Value) == m_objAskVoList[j].m_lngSERIESID_INT)
                        {
                            m_objViewer.m_dgvMain.Rows[i].Cells["m_txtStatus"].Value = "提交";
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("删除失败", "药房请领", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
