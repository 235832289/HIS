using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.EnterpriseServices;

namespace com.digitalwave.iCare.gui.HIS
{
    class clsCtl_Multiunit_drug : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// 逻辑层
        /// </summary>
        private clsDcl_Multiunit_drug m_objDomain;

        /// <summary>
        /// 窗体层
        /// </summary>
        private frmMultiunit_drug m_objViewer;

        private DataView dvMedicine;
        private DataView dvMultiUnit;
        private DataTable dtMultiUnit1;
        /// <summary>
        /// 药品数据表字段
        /// </summary>
        private string[] strMedColArr = new string[7] { "itemid_chr", "itemcode_vchr", "itemname_vchr", 
                                                      "itempycode_chr", "itemwbcode_chr", "itemcommname_vchr", 
                                                      "itemengname_vchr" 
                                                    };

        #endregion

        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsCtl_Multiunit_drug()
        {
            this.m_objDomain = new clsDcl_Multiunit_drug();
            dvMedicine = new DataView();
            //dvAlias = new DataView();
        }
        #endregion
        
        #region 设置窗体
        /// <summary>
        /// 设置窗体
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmMultiunit_drug)frmMDI_Child_Base_in;
        }
        #endregion

        #region 窗体初始化
        /// <summary>
        /// 窗体初始化
        /// </summary>
        public void m_mthInit()
        {
            m_mthLoadDvMedicine();
        }
        #endregion

        #region 显示全部药品
        /// <summary>
        /// 显示全部药品
        /// </summary>
        public void m_mthShowAllMedicine()
        {
            this.dvMedicine.RowFilter = "";
            m_mthDgvMedicineDataBind();
            if (this.m_objViewer.dtgMedicineList.Rows.Count > 0)
            {
                this.m_objViewer.dtgMedicineList.Rows[0].Selected = true;
                m_mthShowSeledMedName();
                m_mthLoadDvMultiUnit();
                m_mthDgvMultiUnitDataBind();
                if (this.m_objViewer.dtgMultiUnitList.Rows.Count > 0)
                {
                    this.m_objViewer.dtgMultiUnitList.Rows[0].Selected = true;
                }
                m_mthTxtLoadData();
            }
        }
        #endregion

        #region 从数据库加载药品视图
        /// <summary>
        /// 从数据库加载药品视图
        /// </summary>
        public void m_mthLoadDvMedicine()
        {
            DataTable dtMedicine = new DataTable();
            long lngRes = this.m_objDomain.m_lngGetTableMedicineList(ref dtMedicine);
            if (lngRes > -1)
            {
                this.dvMedicine = new DataView(dtMedicine);
                this.dvMedicine.Sort = "itemid_chr asc";
                this.dvMedicine.RowFilter = "";
            }
            dtMedicine = null;
            //this.m_mthDgvMedicineDataBind();
        }
        #endregion

        #region 显示当前药品名字
        /// <summary>
        /// 显示选择的药品名字
        /// </summary>
        public void m_mthShowSeledMedName()
        {
            if (this.m_objViewer.dtgMedicineList.Rows.Count > 0)
            {
                this.m_objViewer.labMedicineName.Text = "药品名称：（" + this.m_objViewer.dtgMedicineList.SelectedRows[0].Cells["ColumnMedicineName"].Value.ToString() + "）";
                this.m_objViewer.lblSpec.Text = "药品规格：" + this.m_objViewer.dtgMedicineList.SelectedRows[0].Cells["medspec_vchr"].Value.ToString() ;
                this.m_objViewer.lblProductor.Text = "生产厂家：" + this.m_objViewer.dtgMedicineList.SelectedRows[0].Cells["productorid_chr"].Value.ToString() ;
            }
            else
            {
                this.m_objViewer.labMedicineName.Text = "药品名称：（没有）";
                this.m_objViewer.lblSpec.Text = "药品规格：";
                this.m_objViewer.lblProductor.Text = "生产厂家：";
            }
        }
        #endregion

        #region 绑定药品列表与药品视图
        /// <summary>
        /// 绑定药品列表与药品视图
        /// </summary>
        public void m_mthDgvMedicineDataBind()
        {
            m_objViewer.dtgMedicineList.DataSource = this.dvMedicine;
        }
        #endregion

        #region 根据关键字查找药品
        /// <summary>
        /// 根据关键字查找药品
        /// </summary>
        public void m_mthQueryMedicine()
        {
            string strKey = this.m_objViewer.txtMKey.Text.Trim();
            string strBy = strMedColArr[this.m_objViewer.cmbMKey.SelectedIndex + 1];

            try
            {
                this.dvMedicine.RowFilter = strBy + " like '" + strKey + "%' ";
            }
            catch (Exception ex)
            {
                MessageBox.Show(this.m_objViewer, "所输入的查询条件包含非法字符，请修改查询条件。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.txtMKey.Focus();
                return;
            }
            m_mthDgvMedicineDataBind();

            if (this.m_objViewer.dtgMedicineList.Rows.Count > 0)
            {
                this.m_objViewer.dtgMedicineList.Rows[0].Selected = true;
                m_mthLoadDvMultiUnit();
                m_mthDgvMultiUnitDataBind();
                if (this.m_objViewer.dtgMultiUnitList.Rows.Count > 0)
                {
                    this.m_objViewer.dtgMultiUnitList.Rows[0].Selected = true;
                }
            }
            else
            {
                MessageBox.Show("找不到此药品！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.cmdSave.Tag = null;
                this.m_mthClearTXT();
                this.m_objViewer.dtgMultiUnitList.DataSource = this.dtMultiUnit1;
                return;
            }
            //给维护文本加载别名信息
            m_mthTxtLoadData();
            //显示当前选择的药品名称
            m_mthShowSeledMedName();
        }
        #endregion

        #region 清空维护中的textbox
        /// <summary>
        /// 清空维护中的textbox
        /// </summary>
        public void m_mthClearTXT()
        {
            this.m_objViewer.txtUnitName.Text = "";
            this.m_objViewer.txtPackage.Text = "";
            this.m_objViewer.ckbCurruseFlag.Checked = false;
            this.m_objViewer.cboStatus.SelectedIndex = 1;
        }
        #endregion

        #region 从数据库加载选定的药品的单位视图
        /// <summary>
        /// 从数据库加载选定的药品的单位视图
        /// </summary>
        public void m_mthLoadDvMultiUnit()
        {
            if (this.m_objViewer.dtgMedicineList.SelectedRows.Count < 1)
            {
                return;
            }

            DataTable dtMultiUnit = new DataTable();
            string p_strMedId = this.m_objViewer.dtgMedicineList.SelectedRows[0].Cells["ColumnMedicineId"].Value.ToString();
            long lngRes = this.m_objDomain.m_lngGetTableMultiUnitList(p_strMedId, out dtMultiUnit);
            if (lngRes > -1)
            {
                this.dtMultiUnit1 = dtMultiUnit.Clone();
                this.dvMultiUnit = new DataView(dtMultiUnit);
                this.dvMultiUnit.Sort = "itemid_chr asc";
                this.dvMultiUnit.RowFilter = "";
                m_mthDgvMultiUnitDataBind();
            }
            dtMultiUnit = null;
        }
        #endregion

        #region 绑定别名列表与单位视图
        /// <summary>
        /// 绑定别名列表与单位视图
        /// </summary>
        public void m_mthDgvMultiUnitDataBind()
        {
            m_objViewer.cmdNew.Enabled = true;
            m_objViewer.cmdCancel.Enabled = true;
            m_objViewer.dtgMultiUnitList.DataSource = dvMultiUnit;
            if (m_objViewer.dtgMultiUnitList.SelectedRows.Count > 0)
            {
                m_objViewer.dtgMultiUnitList_RowEnter(m_objViewer.dtgMultiUnitList, null);
            }
        }
        #endregion

        #region 维护文本加载选定单位信息
        /// <summary>
        /// 维护文本加载选定的单位信息
        /// </summary>
        public void m_mthTxtLoadData()
        {
            //列表没有单位，不可保存与删除
            if (this.m_objViewer.dtgMultiUnitList.Rows.Count < 1)
            {
                //清空维护中的textbox
                m_mthClearTXT();
                return;
                
            }
            //把当前选中的单位加载到txt上
            DataGridViewRow dgvrSelectedRow = this.m_objViewer.dtgMultiUnitList.SelectedRows[0];
            this.m_objViewer.txtUnitName.Text = dgvrSelectedRow.Cells["ColumnUnitName"].Value.ToString();
            this.m_objViewer.txtPackage.Text = dgvrSelectedRow.Cells["ColumnPackageNum"].Value.ToString();
            if (dgvrSelectedRow.Cells[3].Value.ToString() == "是")
            {
                m_objViewer.ckbCurruseFlag.Checked = true;
            }
            else 
            {
                m_objViewer.ckbCurruseFlag.Checked = false;
            }
            //this.m_objViewer.cboStatus.SelectedIndex = int.Parse(dgvrSelectedRow.Cells["Status"].Value.ToString());
            if (dgvrSelectedRow.Cells["Status"].Value.ToString() == "启用")
            {
                this.m_objViewer.cboStatus.SelectedIndex = 1;
            }
            else
            {
                this.m_objViewer.cboStatus.SelectedIndex = 0;
            }
            clsMultiunit_drug_VO objTmp = new clsMultiunit_drug_VO();
            objTmp.m_strItemId = dgvrSelectedRow.Cells["ColumnItemID"].Value.ToString();
            objTmp.m_strUnit = dgvrSelectedRow.Cells["ColumnUnitName"].Value.ToString();
            objTmp.m_intPackage = int.Parse(dgvrSelectedRow.Cells["ColumnPackageNum"].Value.ToString());
            if (dgvrSelectedRow.Cells[3].Value.ToString() == "是")
            {
                objTmp.m_intCurruseFlag_Int = 1;
            }
            else
            {
                objTmp.m_intCurruseFlag_Int = 0;
            }
            if (dgvrSelectedRow.Cells["Status"].Value.ToString() == "启用")
            {
                objTmp.m_intStauts = 1;
            }
            else
            {
                objTmp.m_intStauts = 0;
            }

            this.m_objViewer.cmdSave.Tag = objTmp;
            
        }
        #endregion

        #region 删除单位
        /// <summary>
        /// 删除单位
        /// </summary>
        /// <returns></returns>
        public bool m_blnDeleteMultiUnit()
        {
            if (this.m_objViewer.dtgMultiUnitList.Rows.Count <= 0)
            {
                return false;
            }

            //实例化VO并住其字段中赋值
            clsMultiunit_drug_VO objVO = m_objGetVOFromText();

            //从数据库中删除单位
            long lngRes = this.m_objDomain.m_lngDeleteMultiUnit(objVO);
            //如果从数据库中删除别名成功
            if (lngRes > 0)
            {
                
                MessageBox.Show("单位删除成功!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("单位删除失败!", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }
        #endregion

        #region  实例化clsMultiunit_drug_VO对象
        /// <summary>
        /// 实例化clsMultiunit_drug_VO对象
        /// </summary>
        /// <returns>clsMultiunit_drug_VO对象</returns>
        private clsMultiunit_drug_VO m_objGetVOFromText()
        {
            clsMultiunit_drug_VO objVO = new clsMultiunit_drug_VO();
            objVO.m_strItemId = this.m_objViewer.dtgMedicineList.SelectedRows[0].Cells["ColumnMedicineId"].Value.ToString();
            objVO.m_strUnit = this.m_objViewer.txtUnitName.Text.ToString().Trim();
            objVO.m_intPackage = Convert.ToInt16(this.m_objViewer.txtPackage.Text.ToString().Trim());
            if (m_objViewer.ckbCurruseFlag.Checked)
            {
                
                objVO.m_intCurruseFlag_Int = 1;
            }
            else 
            {
                objVO.m_intCurruseFlag_Int = 0;
            }
            objVO.m_intStauts = this.m_objViewer.cboStatus.SelectedIndex;
            return objVO;
        }
        #endregion

        #region 增加单位
        /// <summary>
        /// 增加单位
        /// </summary>
        /// <returns></returns>
        public bool m_blnAddMultiUnit()
        {
            //实例化VO并住其字段中赋值
            clsMultiunit_drug_VO objVO = m_objGetVOFromText();
            string strSeledMedId = this.m_objViewer.dtgMedicineList.SelectedRows[0].Cells["ColumnMedicineId"].Value.ToString();
            if (this.m_objDomain.m_blnQueryByIndex(strSeledMedId, objVO.m_strUnit, objVO.m_intPackage, objVO.m_intCurruseFlag_Int))
            {
                MessageBox.Show("当前药品单位中已存在此单位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.txtUnitName.Focus();
                m_objViewer.txtUnitName.SelectAll();
                return false;
            }

            //往数据库中增加别名
            long lngRes = this.m_objDomain.m_lngAddMultiUnit(objVO);
            //如果往数据库中增加别名成功
            if (lngRes > 0)
            {
                //往视图中增加所添加的数据

                this.m_mthLoadDvMultiUnit();
                this.m_mthDgvMultiUnitDataBind();
                this.m_objViewer.dtgMultiUnitList.Rows[this.m_objViewer.dtgMultiUnitList.Rows.Count - 1].Selected = true;
                m_mthTxtLoadData();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 判断是否为数字
        /// <summary>
        /// 判断是否为数字
        /// </summary>
        /// <returns></returns>
        public bool m_blnIsNum()
        {
            string strS = m_objViewer.txtPackage.Text.ToString().Trim();
            if (strS == null || strS.Length == 0)
            {
                return true;
            }
            System.Text.ASCIIEncoding ascii = new System.Text.ASCIIEncoding();
            byte[] bytestr = ascii.GetBytes(strS);
            foreach (byte c1 in bytestr)
            {
                if (c1 < 48 || c1 > 57)
                {
                    return true;
                }
            }
            return false; 

        }
        #endregion

        #region 保存单位
        /// <summary>
        /// 保存单位
        /// </summary>
        /// <returns></returns>
        public bool m_blnUpdateMultiUnit()
        {
            //更新的条件
            string strMedicineId = this.m_objViewer.dtgMedicineList.SelectedRows[0].Cells["ColumnMedicineId"].Value.ToString();
            string strUnitName = this.m_objViewer.dtgMultiUnitList.SelectedRows[0].Cells["ColumnUnitName"].Value.ToString();
            int intPackAge = Convert.ToInt16(this.m_objViewer.dtgMultiUnitList.SelectedRows[0].Cells["ColumnPackageNum"].Value.ToString());
            int intCurruseFlag = -1;
            if (this.m_objViewer.dtgMultiUnitList.SelectedRows[0].Cells["ColumnCurruseFlag"].Value.ToString() == "是")
            {
                intCurruseFlag = 1;
            }
            else
            {
                intCurruseFlag = 0;
            }
            int intCurruseFlag_Int = intCurruseFlag;
            //实例化VO并住其字段中赋值
            clsMultiunit_drug_VO objVO = m_objGetVOFromText();

            //判断单位是否已经存在
            //if (this.m_objDomain.m_blnQueryByIndex(strMedicineId, objVO.m_strUnit, objVO.m_intPackage))
            //{
            //    MessageBox.Show("当前药品单位中已存在此单位！\n请更改数量单位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    m_objViewer.txtPackage.Focus();
            //    m_objViewer.txtPackage.SelectAll();
            //    return false;
            //}
            //else
            //{
            //    if (this.m_objDomain.m_blnQueryByIndex(strMedicineId, objVO.m_strUnit, objVO.m_intPackage, objVO.m_intCurruseFlag_Int))
            //    {
            //        MessageBox.Show("当前药品单位中已存在此单位！\n请更改数量单位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        m_objViewer.txtPackage.Focus();
            //        m_objViewer.txtPackage.SelectAll();
            //        return false;
            //    }
            //    else
            //    {
            //        //从数据库中更新单位
            //        long lngRes = this.m_objDomain.m_lngUpdateMultiUnit(objVO, strMedicineId, strUnitName, intPackAge, intCurruseFlag_Int);
            //        if (lngRes > 0)
            //        {

            //            return true;
            //        }
            //        else
            //        {

            //            return false;
            //        }
            //    }
            //}

            DataGridViewRow dgvr;
            int intCount=this.m_objViewer.dtgMultiUnitList.Rows.Count;
            int intCurRow=this.m_objViewer.dtgMultiUnitList.SelectedRows[0].Cells[0].RowIndex;
            if (intCurRow != 0)
            {
                for (int i1 = 0; i1 < intCount && i1 != intCurRow; i1++)
                {
                    dgvr = this.m_objViewer.dtgMultiUnitList.Rows[i1];
                    if (objVO.m_strItemId == dgvr.Cells[0].Value.ToString() && objVO.m_strUnit == dgvr.Cells[1].Value.ToString() && objVO.m_intPackage == int.Parse(dgvr.Cells[2].Value.ToString()))
                    {
                        MessageBox.Show("当前药品单位中已存在此单位！\n请更改数量单位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.txtPackage.Focus();
                        m_objViewer.txtPackage.SelectAll();
                        return false;
                    }
                }
            }
            else
            {
                for (int i1 = 1; i1 < intCount; i1++)
                {
                    dgvr = this.m_objViewer.dtgMultiUnitList.Rows[i1];
                    if (objVO.m_strItemId == dgvr.Cells[0].Value.ToString() && objVO.m_strUnit == dgvr.Cells[1].Value.ToString() && objVO.m_intPackage == int.Parse(dgvr.Cells[2].Value.ToString()))
                    {
                        MessageBox.Show("当前药品单位中已存在此单位！\n请更改数量单位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.txtPackage.Focus();
                        m_objViewer.txtPackage.SelectAll();
                        return false;
                    }
                }
            }

            long lngRes = this.m_objDomain.m_lngUpdateMultiUnit(objVO, strMedicineId, strUnitName, intPackAge, intCurruseFlag_Int, this.m_objViewer.cboStatus.SelectedIndex);
            if (lngRes > 0)
            {

                return true;
            }
            else
            {

                return false;
            } 

            //if (this.m_objDomain.m_blnQueryByIndex(strMedicineId, objVO.m_strUnit, objVO.m_intPackage, objVO.m_intCurruseFlag_Int,this.m_objViewer.cboStatus.SelectedIndex))
            //{
            //    MessageBox.Show("当前药品单位中已存在此单位！\n请更改数量单位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    m_objViewer.txtPackage.Focus();
            //    m_objViewer.txtPackage.SelectAll();
            //    return false;
            //} 
                //从数据库中更新单位
        }
        #endregion

        #region 把所有单位设为非当前单位
        /// <summary>
        /// 把所有单位设为非当前单位
        /// </summary>
        /// <param name="p_strMedicineId"></param>
        /// <returns></returns>
        public long m_lngSetAllCurruseFlag_0ByItemId()
        {
            string strSeledMedId = this.m_objViewer.dtgMedicineList.SelectedRows[0].Cells["ColumnMedicineId"].Value.ToString();
            string strUnitName=m_objViewer.txtUnitName.Text.ToString().Trim();
            int intF = Convert.ToInt32(m_objViewer.txtPackage.Text.ToString());
            long lngRes = this.m_objDomain.m_lngSetAllCurruseFlag_0ByItemId(strSeledMedId);
            return lngRes;
            //if (m_objDomain.m_blnQueryByIndex(strSeledMedId, strUnitName, intF))
            //{
            //    MessageBox.Show("当前药品单位中已存在此单位！\n请更改数量单位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    m_objViewer.txtPackage.Focus();
            //    m_objViewer.txtPackage.SelectAll();
            //    return -1;
            //}
            //else
            //{
            //    long lngRes = this.m_objDomain.m_lngSetAllCurruseFlag_0ByItemId(strSeledMedId);
            //    return lngRes;
            //}
        }
        #endregion

        public bool m_BlnQueryByIndex()
        {
            long lngRes = -1;
            string strSeledMedId = this.m_objViewer.dtgMedicineList.SelectedRows[0].Cells["ColumnMedicineId"].Value.ToString();
            string strUnitName = m_objViewer.txtUnitName.Text.ToString().Trim();
            int intF = Convert.ToInt32(m_objViewer.txtPackage.Text.ToString());
            if (m_objDomain.m_blnQueryByIndex(strSeledMedId, strUnitName, intF))
            {
                MessageBox.Show("当前药品单位中已存在此单位！\n请更改数量单位！", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.txtPackage.Focus();
                m_objViewer.txtPackage.SelectAll();
                return false;
            }
            return true;
        }

    }
}
