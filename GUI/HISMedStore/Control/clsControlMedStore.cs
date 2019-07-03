using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 药房设置控制类
    /// Create by kong 2004-07-05
    /// </summary>
    public class clsControlMedStore : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 构造函数
        /// <summary>
        /// 
        /// </summary>
        public clsControlMedStore()
        {
            m_objManage = new clsDomainControlMedStoreBseInfo();
        }
        #endregion

        #region 变量
        public string flage = "Add";
        clsDomainControlMedStoreBseInfo m_objManage = null;
        clsMedStore_VO m_objItem;
        /// <summary>
        /// 当前选择行
        /// </summary>
        private int m_SelRow = 0;
        #endregion

        #region 设置窗体对象
        frmMedStore m_objViewer;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmMedStore)frmMDI_Child_Base_in;
        }
        #endregion

        #region 列表操作

        #region 向列表插入一条记录
        /// <summary>
        /// 向列表插入一条数据
        /// </summary>
        /// <param name="objItem">药房数据</param>
        private void m_mthInsertDetail(clsMedStore_VO objItem)
        {
            if (objItem != null)
            {
                string strMedStoreType = "";
                string strMedicineType = "";
                string m_isUrgency = "";

                if (objItem.m_intMedStoreType == 1)
                {
                    strMedStoreType = "门诊药房";
                }
                else if (objItem.m_intMedStoreType == 2)
                {
                    strMedStoreType = "住院药房";
                }
                else if (objItem.m_intMedStoreType == 3)
                {
                    strMedStoreType = "全院药房";
                }

                if (objItem.m_intMedicneType == 1)
                {
                    strMedicineType = "西药";
                }
                else if (objItem.m_intMedicneType == 2)
                {
                    strMedicineType = "中药";
                }
                else if (objItem.m_intMedicneType == 3)
                    strMedicineType = "材料";
                if (objItem.m_intUrgency == 1)//判断是否急诊
                {
                    m_isUrgency = "是";
                }
                else
                    m_isUrgency = "否";
                ListViewItem lsvItem = new ListViewItem(objItem.m_strMedStoreID);
                lsvItem.SubItems.Add(objItem.m_strMedStoreName.Trim());
                lsvItem.SubItems.Add(strMedStoreType);
                lsvItem.SubItems.Add(strMedicineType);
                lsvItem.SubItems.Add(m_isUrgency);//判断是否急诊
                lsvItem.SubItems.Add(objItem.m_strDeptName);
                lsvItem.SubItems.Add(objItem.m_strDeptid);
                //2008.6.2 chongkun.wu+
                lsvItem.SubItems.Add(objItem.m_strMedStoreShortName);
                lsvItem.Tag = objItem;

                this.m_objViewer.m_lsvDetail.Items.Add(lsvItem);
            }
        }
        #endregion

        #region 修改列表数据
        /// <summary>
        /// 修改列表数据
        /// </summary>
        /// <param name="objItem">药房数据</param>
        private void m_mthModifyDetail(clsMedStore_VO objItem)
        {
            string strMedStoreType = "";
            string strMedicineType = "";
            string m_isUrgency = "";
            if (objItem.m_intMedStoreType == 1)
            {
                strMedStoreType = "门诊药房";
            }
            else if (objItem.m_intMedStoreType == 2)
            {
                strMedStoreType = "住院药房";
            }
            else if (objItem.m_intMedStoreType == 3)
            {
                strMedStoreType = "全院药房";
            }

            if (objItem.m_intMedicneType == 1)
            {
                strMedicineType = "西药";
            }
            else if (objItem.m_intMedicneType == 2)
            {
                strMedicineType = "中药";
            }
            else
                strMedicineType = "材料";
            if (this.m_objViewer.m_chkUrgency.Checked)
            {
                m_isUrgency = "是";
                //objItem.m_intUrgency==1;
            }
            else
            {
                m_isUrgency = "否";
                //objItem.m_intUrgency==0;
            }


            this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[1].Text = objItem.m_strMedStoreName.Trim();
            this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[2].Text = strMedStoreType;
            this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[3].Text = strMedicineType;
            this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[4].Text = m_isUrgency;
            this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[5].Text = objItem.m_strDeptName;
            this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[6].Text = objItem.m_strDeptid;
            //2008.6.2 chongkun.wu+
            this.m_objViewer.m_lsvDetail.Items[m_SelRow].SubItems[7].Text = objItem.m_strMedStoreShortName;
            this.m_objViewer.m_lsvDetail.Items[m_SelRow].Tag = objItem;
        }
        #endregion

        #endregion

        #region 获得列表数据
        /// <summary>
        /// 获得列表数据
        /// </summary>
        public void m_mthGetDetailList()
        {
            this.m_objViewer.m_lsvDetail.Items.Clear();
            clsMedStore_VO[] objItemArr = new clsMedStore_VO[0];
            long lngRes = 0;

            lngRes = this.m_objManage.m_lngGetMedStoreList(out objItemArr);
            if (lngRes > 0 && objItemArr.Length > 0)
            {
                for (int i1 = 0; i1 < objItemArr.Length; i1++)
                {
                    m_mthInsertDetail(objItemArr[i1]);
                }
                if (this.m_objViewer.m_lsvDetail.Items.Count != 0)
                    this.m_objViewer.m_lsvDetail.Items[0].Selected = true;

            }
        }
        #endregion

        #region 设置窗体数据
        /// <summary>
        /// 设置窗体数据
        /// </summary>
        /// <param name="objItem">药房数据</param>
        public void m_mthSetViewInfo(clsMedStore_VO objItem)
        {
            this.m_objItem = objItem;

            if (this.m_objItem == null)
            {
                m_mthClear();
                if (this.m_objViewer.m_cboMedStoreType.Items.Count > 0)
                {
                    this.m_objViewer.m_cboMedStoreType.SelectedIndex = 0;
                }
                if (this.m_objViewer.m_cboMedicineType.Items.Count > 0)
                {
                    this.m_objViewer.m_cboMedicineType.SelectedIndex = 0;
                }
                this.m_objViewer.m_txtMedStoreName.Focus();

            }
            else
            {
                m_mthClear();
                this.m_objViewer.m_txtMedStoreName.Text = this.m_objItem.m_strMedStoreName.Trim();
                this.m_objViewer.m_cboMedStoreType.SelectedIndex = this.m_objItem.m_intMedStoreType - 1;
                this.m_objViewer.m_cboMedicineType.SelectedIndex = this.m_objItem.m_intMedicneType - 1;
                this.m_objViewer.m_txtDept.Text = this.m_objItem.m_strDeptName;
                this.m_objViewer.m_txtDept.AccessibleName = this.m_objItem.m_strDeptid;
                //2008.6.2 chongkun.wu+
                this.m_objViewer.txtMedStoreShortName.Text = this.m_objItem.m_strMedStoreShortName;

                this.m_objViewer.m_txtMedStoreName.Focus();
            }
        }
        #endregion

        #region 窗体初始化
        /// <summary>
        /// 窗体初始化
        /// </summary>
        public void m_mthInit()
        {
            m_mthGetDetailList();
            m_mthSetViewInfo(null);
        }
        #endregion

        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public void m_mthSave()
        {
            if (!m_blnCheckValue())
            {
                return;
            }

            if (this.m_objItem == null)
            {
                m_mthDoAddNew();
                m_mthClear();
            }
            else
            {
                m_mthDoUpdate();
                m_mthClear();
            }
        }
        #endregion

        #region 明细列表双击
        /// <summary>
        /// 列表双击事件
        /// </summary>
        public void m_mthDetailSel()
        {
            if (this.m_objViewer.m_lsvDetail.SelectedItems.Count > 0)
            {
                if (this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag != null)
                {
                    clsMedStore_VO objItem = (clsMedStore_VO)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag;
                    this.m_SelRow = this.m_objViewer.m_lsvDetail.SelectedItems[0].Index;
                    if (objItem.m_intUrgency == 1)
                        this.m_objViewer.m_chkUrgency.Checked = true;
                    else
                        this.m_objViewer.m_chkUrgency.Checked = false;
                    m_mthSetViewInfo(objItem);
                }
            }
            this.flage = "Add";
        }
        #endregion

        #region 保存新增
        /// <summary>
        /// 保存新增
        /// </summary>
        private void m_mthDoAddNew()
        {
            clsMedStore_VO objItem = new clsMedStore_VO();
            string strDeID;
            this.m_objManage.m_lngGetMedStoreID(out strDeID);
            objItem.m_strMedStoreID = strDeID;
            objItem.m_strMedStoreName = this.m_objViewer.m_txtMedStoreName.Text.Trim();
            objItem.m_intMedStoreType = this.m_objViewer.m_cboMedStoreType.SelectedIndex + 1;
            objItem.m_intMedicneType = this.m_objViewer.m_cboMedicineType.SelectedIndex + 1;
            objItem.m_strDeptid = this.m_objViewer.m_txtDept.StrItemId.Trim();
            objItem.m_strDeptName = this.m_objViewer.m_txtDept.Text.Trim();
            //2008.6.2 chongkun.wu+
            objItem.m_strMedStoreShortName = this.m_objViewer.txtMedStoreShortName.Text.Trim();
            if (this.m_objViewer.m_chkUrgency.Checked)//判断是否急诊
            {
                objItem.m_intUrgency = 1;
            }
            else
            {
                objItem.m_intUrgency = 0;
            }



            long lngRes = this.m_objManage.m_lngAddNewMedStore(objItem);

            if (lngRes > 0)
            {
                m_mthInsertDetail(objItem);
                this.m_objViewer.m_lsvDetail.Items[this.m_objViewer.m_lsvDetail.Items.Count - 1].Selected = true;

            }
            else
            {
                MessageBox.Show("数据保存出错，请与管理员联系", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        #endregion

        #region 保存修改
        /// <summary>
        /// 保存修改
        /// </summary>
        private void m_mthDoUpdate()
        {
            this.m_objItem.m_strMedStoreName = this.m_objViewer.m_txtMedStoreName.Text.Trim();
            this.m_objItem.m_intMedStoreType = this.m_objViewer.m_cboMedStoreType.SelectedIndex + 1;
            this.m_objItem.m_intMedicneType = this.m_objViewer.m_cboMedicineType.SelectedIndex + 1;
            this.m_objItem.m_strDeptid = this.m_objViewer.m_txtDept.AccessibleName;
            this.m_objItem.m_strDeptName = this.m_objViewer.m_txtDept.Text;
            //2008.6.2 chongkun.wu+
            this.m_objItem.m_strMedStoreShortName = this.m_objViewer.txtMedStoreShortName.Text;
            if (this.m_objViewer.m_chkUrgency.Checked)//判断是否急诊
            {
                m_objItem.m_intUrgency = 1;
            }
            else
            {
                m_objItem.m_intUrgency = 0;
            }

            long lngRes = this.m_objManage.m_lngUpdMedStoreByID(this.m_objItem);

            if (lngRes > 0)
            {
                m_mthModifyDetail(this.m_objItem);
            }
        }
        #endregion

        #region 保存删除
        /// <summary>
        /// 保存删除
        /// </summary>
        public void m_mthDoDelete()
        {
            if (this.m_objViewer.m_lsvDetail.SelectedItems.Count > 0)
            {
                if (this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag != null)
                {
                    clsMedStore_VO objItem = new clsMedStore_VO();
                    objItem = (clsMedStore_VO)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag;
                    if (MessageBox.Show("确定要删除该记录吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        return;
                    long lngRes = this.m_objManage.m_lngDeleteMedStoreByID(objItem.m_strMedStoreID.Trim());
                    int index = this.m_objViewer.m_lsvDetail.SelectedIndices[0];
                    if (lngRes > 0)
                    {
                        this.m_objViewer.m_lsvDetail.SelectedItems[0].Remove();
                        //						if(this.m_objViewer.m_lsvDetail.Items.Count>0)
                        //						{
                        //							if(index>0)
                        //								this.m_objViewer.m_lsvDetail.Items[index-1].Selected=true;
                        //							else
                        //								this.m_objViewer.m_lsvDetail.Items[index].Selected=true;
                        //						}
                        this.m_objViewer.m_lsv.Items.Clear();//删除排班信息表
                        m_mthClearDeptDutyInfo();

                    }
                }
            }
            else
            {
                MessageBox.Show("请选择需删除的项！", "系统提示");
                return;
            }

        }
        #endregion

        #region 检测输入
        /// <summary>
        /// 检测输入
        /// </summary>
        /// <returns></returns>
        private bool m_blnCheckValue()
        {
            bool blnResult = true;

            if (this.m_objViewer.m_txtMedStoreName.Text.Trim() == "")
            {
                this.m_ephHandler.m_mthAddControl(this.m_objViewer.m_txtMedStoreName);
                blnResult = false;
            }
            if (this.m_objViewer.txtMedStoreShortName.Text.Trim().Replace(" ", "").Length != 3)
            {
                MessageBox.Show("简码必须为三位大写字母！", "药房设置提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.txtMedStoreShortName.Focus();
                blnResult = false;
                return false;
            }
            if (this.m_objViewer.m_txtDept.Text.Trim() == string.Empty)
            {
                MessageBox.Show("必须绑定该药房对应的部门！", "药房设置提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.m_objViewer.m_txtDept.Focus();
                blnResult = false;
                return false;
            }
            if (this.m_objItem == null)
            {
                foreach (ListViewItem lvi in this.m_objViewer.m_lsvDetail.Items)
                {
                    if (((clsMedStore_VO)lvi.Tag).m_strDeptid.Trim() == this.m_objViewer.m_txtDept.StrItemId.Trim() && this.m_objViewer.m_txtDept.StrItemId.Trim() != "")
                    {
                        MessageBox.Show(((clsMedStore_VO)lvi.Tag).m_strMedStoreName + "已对应到该部门， 一个部门只能对应一个药房！", "药房设置提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.m_objViewer.m_txtDept.Clear();
                        this.m_objViewer.m_txtDept.Focus();
                        blnResult = false;
                        return false;
                    }
                    if (((clsMedStore_VO)lvi.Tag).m_strMedStoreShortName.Trim() == this.m_objViewer.txtMedStoreShortName.Text)
                    {
                        MessageBox.Show("\"" + m_objViewer.txtMedStoreShortName.Text + "\"已被使用！", "药房设置提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.m_objViewer.txtMedStoreShortName.Clear();
                        this.m_objViewer.txtMedStoreShortName.Focus();
                        blnResult = false;
                        return false;
                    }
                }
            }
            else
            {
                foreach (ListViewItem lvi in this.m_objViewer.m_lsvDetail.Items)
                {
                    if (((clsMedStore_VO)lvi.Tag).m_strDeptid.Trim() == this.m_objViewer.m_txtDept.AccessibleName && ((clsMedStore_VO)lvi.Tag).m_strMedStoreID.Trim() != this.m_objItem.m_strMedStoreID)
                    {
                        MessageBox.Show(((clsMedStore_VO)lvi.Tag).m_strMedStoreName + "已对应到该部门， 一个部门只能对应一个药房！", "药房设置提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.m_objViewer.m_txtDept.Clear();
                        this.m_objViewer.m_txtDept.Focus();
                        blnResult = false;
                        return false;
                    }
                    if (((clsMedStore_VO)lvi.Tag).m_strMedStoreShortName.Trim() == this.m_objViewer.txtMedStoreShortName.Text && ((clsMedStore_VO)lvi.Tag).m_strMedStoreID.Trim() != this.m_objItem.m_strMedStoreID)
                    {
                        MessageBox.Show("\"" + m_objViewer.txtMedStoreShortName.Text + "\"已被使用！", "药房设置提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.m_objViewer.txtMedStoreShortName.Clear();
                        this.m_objViewer.txtMedStoreShortName.Focus();
                        blnResult = false;
                        return false;
                    }
                }
            }
            if (!blnResult)
            {
                this.m_ephHandler.m_mthShowControlsErrorProvider();
                this.m_ephHandler.m_mthClearControl();
            }
            return blnResult;
        }
        #endregion

        #region 清空编辑框数据  xgpeng 2006-2-9
        /// <summary>
        /// 清除编辑框数据
        /// </summary>
        private void m_mthClear()
        {
            this.m_objViewer.m_txtMedStoreName.Clear();
            this.m_objViewer.m_txtDept.Clear();
            this.m_objViewer.txtMedStoreShortName.Clear();
            this.m_objViewer.m_cboMedStoreType.SelectedIndex = -1;
            this.m_objViewer.m_cboMedicineType.SelectedIndex = -1;
        }
        #endregion

        #region 清空编辑框数据(排班) xgpeng 2006-2-9
        /// <summary>
        /// 清空编辑框数据(排班)
        /// </summary>
        public void m_mthClearDeptDutyInfo()
        {
            this.m_objViewer.m_txtRemark.Text = "";
            this.m_objViewer.m_chkMorning.Checked = false;
            this.m_objViewer.m_chkNoon.Checked = false;
            this.m_objViewer.m_chkEvening.Checked = false;
            this.m_objViewer.m_txtMedStore.txtValuse = "";
            this.m_objViewer.m_txtMedStore.Tag = "";/////新加
            this.m_objViewer.m_cboDate.SelectedIndex = -1;
        }
        #endregion

        #region 载入药房信息 xgpeng 2006-2-9
        /// <summary>
        /// 载入药房信息
        /// </summary>
        public void LoadMedStoreInfo1()
        {
            int i = 4;//过滤字段
            DataTable m_dtable = new DataTable();
            if (this.m_objViewer.m_lsvDetail.Items.Count == 0)
                return;
            if (this.m_objViewer.m_lsvDetail.SelectedItems.Count == 0)
                return;

            long lngRes = this.m_objManage.m_lngGetMedStoreInfo(out m_dtable);

            if (lngRes > 0 && m_dtable.Rows.Count > 0)
            {
                //				DataTable tempTable = new DataTable();
                //				DataRow tempRow;
                //				tempTable.Columns[i].c.Add("药房ID");
                //				tempTable.Columns.Add("药房名称");
                //				tempTable.Columns.Add("药房类别");

                m_dtable.Columns[0].ColumnName = "药房ID";
                m_dtable.Columns[1].ColumnName = "  药房名称";
                m_dtable.Columns[2].ColumnName = "药房类型";


                //					 				for(int i = 0;i<m_dtable.Rows.Count;i++)
                //					 				{
                //					 					tempRow = tempTable.NewRow();
                //					 					tempRow[0]=m_dtable.Rows[i][].m_strEMPNO_CHR;
                //					 					tempRow[1] = DataResultArr[i].m_strLASTNAME_VCHR;
                //					 					tempRow[2] = DataResultArr[i].m_strEMPID_CHR;
                //					 					tempTable.Rows.Add(tempRow);
                //					 				}
                if (this.m_objViewer.m_lsvDetail.SelectedItems[0].SubItems[3].Text.ToString().Trim() == "西药")
                    i = 1;
                else if (this.m_objViewer.m_lsvDetail.SelectedItems[0].SubItems[3].Text.ToString().Trim() == "中药")
                    i = 2;
                else
                    i = 3;
                int count = m_dtable.Rows.Count;
                for (int i1 = 0; i1 < m_dtable.Rows.Count; i1++)
                {
                    if (Convert.ToInt32(m_dtable.Rows[i1]["药房类型"].ToString().Trim()) != i ||
                        m_objViewer.m_lsvDetail.SelectedItems[0].SubItems[1].Text.ToString().Trim() == m_dtable.Rows[i1]["  药房名称"].ToString().Trim())
                    {
                        m_dtable.Rows.RemoveAt(i1);
                        i1--;
                    }


                }
                //if (m_dtable.Rows.Count == 1)
                //    m_dtable.Rows.Clear();
                m_objViewer.m_txtMedStore.m_GetDataTable = m_dtable;
            }
        }
        #endregion
        public void m_mthInitialDept()
        {
            DataTable m_dtDeptDesc = new DataTable();
            this.m_objManage.m_lngGetDeptInfo(out m_dtDeptDesc);
            this.m_objViewer.m_txtDept.m_mthInitDeptData(m_dtDeptDesc);

        }
        #region 根据药房ID获取药房排班信息 xgpeng 2006-2-9
        /// <summary>
        /// 根据药房ID获取药房排班信息
        /// </summary>
        public void m_GetDeptDutyInfo()
        {
            string p_TypeID = "";
            string m_strDate = "";
            clsMedDeptDuty_VO[] m_objResArr;
            if (this.m_objViewer.m_lsvDetail.Items.Count == 0)
                return;
            //			if(this.m_objViewer.m_lsvDetail.SelectedItems.Count==0)
            //			{
            //				//MessageBox.Show("请选择记录","提示",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            //				//MessageBox.Show("请选择记录","提示");
            //				return;
            //			}
            p_TypeID = ((clsMedStore_VO)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag).m_strMedStoreID;
            long lngRes = this.m_objManage.m_lngGetDeptDutyInfo(p_TypeID, out m_objResArr);
            this.m_objViewer.m_lsv.Items.Clear();
            if (lngRes > 0 && m_objResArr.Length > 0)
            {
                ListViewItem ListTemp = null;
                for (int i1 = 0; i1 < m_objResArr.Length; ++i1)
                {
                    m_strDate = m_changeDate(m_objResArr[i1].m_intWeekDay);
                    ListTemp = new ListViewItem(m_strDate);
                    ListTemp.SubItems.Add(m_objResArr[i1].m_strWorkTime.ToString().Trim());
                    ListTemp.SubItems.Add(m_objResArr[i1].m_strObjectDeptName.ToString().Trim());
                    ListTemp.SubItems.Add(m_objResArr[i1].m_strRemark.ToString().Trim());
                    ListTemp.Tag = m_objResArr[i1];
                    this.m_objViewer.m_lsv.Items.Add(ListTemp);
                }
            }
        }
        #endregion

        #region 日期转换成数字  xgpeng 2006-2-9
        private string m_changeDate(int i2)
        {
            string p_strDate = "";
            switch (i2)
            {
                case 1: p_strDate = "星期一";
                    break;
                case 2: p_strDate = "星期二";
                    break;
                case 3: p_strDate = "星期三";
                    break;
                case 4: p_strDate = "星期四";
                    break;
                case 5: p_strDate = "星期五";
                    break;
                case 6: p_strDate = "星期六";
                    break;
                case 7: p_strDate = "星期日";
                    break;
            }
            return p_strDate;
        }
        #endregion

        #region 数字转换成日期 xgpeng 2006-2-9
        private int m_changeNum(string p_strDate)
        {
            int m_intWeekDay = 0;
            switch (p_strDate)
            {
                case "星期一": m_intWeekDay = 1;
                    break;
                case "星期二": m_intWeekDay = 2;
                    break;
                case "星期三": m_intWeekDay = 3;
                    break;
                case "星期四": m_intWeekDay = 4;
                    break;
                case "星期五": m_intWeekDay = 5;
                    break;
                case "星期六": m_intWeekDay = 6;
                    break;
                case "星期日": m_intWeekDay = 7;
                    break;
            }
            return m_intWeekDay;
        }
        #endregion

        #region 新增药房排班信息  xgpeng 2006-2-9
        public void m_AddDuty()
        {
            this.flage = "Add";
            m_mthClearDeptDutyInfo();
            this.m_objViewer.m_cboDate.Focus();
        }
        #endregion

        #region 保存 新增药房排班信息  xgpeng 2006-2-9
        /// <summary>
        /// 保存 新增药房排班信息
        /// </summary>
        public void m_AddDeptDutyInfo()
        {
            string p_strTime = ""; //排班时间
            bool flag = false;
            int m_intSeq;   //流水号
            clsMedDeptDuty_VO p_objDuty = new clsMedDeptDuty_VO();

            p_objDuty.m_intWeekDay = m_changeNum(this.m_objViewer.m_cboDate.Text.Trim());

            flag = m_Judge(out p_strTime);
            if (flag == false)
                return;
            p_objDuty.m_strWorkTime = p_strTime.Trim();
            p_objDuty.m_strDeptID = ((clsMedStore_VO)this.m_objViewer.m_lsvDetail.SelectedItems[0].Tag).m_strMedStoreID;
            p_objDuty.m_intTypeID = 1;
            p_objDuty.m_strObjectDeptID = this.m_objViewer.m_txtMedStore.Tag.ToString().Trim();
            p_objDuty.m_strObjectDeptName = this.m_objViewer.m_txtMedStore.txtValuse.Trim();
            p_objDuty.m_strRemark = this.m_objViewer.m_txtRemark.Text.Trim();

            long lngRes = this.m_objManage.m_lngAddDeptDutyInfo(out  m_intSeq, p_objDuty);
            if (lngRes > 0)
            {
                //			    p_objDuty.m_strSeq= m_intSeq;
                //				ListViewItem LsvTemp=new ListViewItem(this.m_objViewer.m_cboDate.Text.Trim());
                //				LsvTemp.SubItems.Add(p_objDuty.m_strWorkTime.ToString().Trim());
                //				LsvTemp.SubItems.Add(p_objDuty.m_strObjectDeptName.ToString().Trim());
                //				LsvTemp.SubItems.Add(p_objDuty.m_strRemark.ToString().Trim());
                //				LsvTemp.Tag=p_objDuty;
                //				this.m_objViewer.m_lsv.Items.Add(LsvTemp);
                m_GetDeptDutyInfo();
                m_mthClearDeptDutyInfo();
            }
        }

        #endregion

        #region 判断控件是否为空 与 拼凑时间  xgpeng 2006-2-9
        private bool m_Judge(out string p_strTime)
        {
            p_strTime = "";
            this.m_objViewer.m_dtpMorng1.Value = Convert.ToDateTime(this.m_objViewer.m_dtpMorng1.Value.ToString("HH:mm"));
            this.m_objViewer.m_dtpMorng2.Value = Convert.ToDateTime(this.m_objViewer.m_dtpMorng2.Value.ToString("HH:mm"));
            this.m_objViewer.m_dtpNoon1.Value = Convert.ToDateTime(this.m_objViewer.m_dtpNoon1.Value.ToString("HH:mm"));
            this.m_objViewer.m_dtpNoon2.Value = Convert.ToDateTime(this.m_objViewer.m_dtpNoon2.Value.ToString("HH:mm"));
            this.m_objViewer.m_dtpEven1.Value = Convert.ToDateTime(this.m_objViewer.m_dtpEven1.Value.ToString("HH:mm"));
            this.m_objViewer.m_dtpEven2.Value = Convert.ToDateTime(this.m_objViewer.m_dtpEven2.Value.ToString("HH:mm"));

            if (this.m_objViewer.m_chkMorning.Checked == true)//时间段1
            {
                if (this.m_objViewer.m_chkNoon.Checked == true && Convert.ToDateTime(this.m_objViewer.m_dtpMorng1.Value.ToString("HH:mm")) > Convert.ToDateTime(this.m_objViewer.m_dtpNoon1.Value.ToString("HH:mm")))
                {

                    MessageBox.Show("请递增设置时间段", "提示");
                    this.m_objViewer.m_dtpNoon1.Focus();
                    return false;
                }
                else if (this.m_objViewer.m_chkEvening.Checked == true && this.m_objViewer.m_dtpMorng1.Value > this.m_objViewer.m_dtpEven1.Value)
                {
                    MessageBox.Show("请递增设置时间段", "提示");
                    this.m_objViewer.m_dtpEven1.Focus();
                    return false;
                }
                if (this.m_objViewer.m_dtpMorng1.Value > this.m_objViewer.m_dtpMorng2.Value)
                {
                    MessageBox.Show("不能小于前段时间", "提示");
                    this.m_objViewer.m_dtpMorng2.Focus();
                    return false;
                }
                if (this.m_objViewer.m_chkNoon.Checked == true && this.m_objViewer.m_dtpMorng2.Value > this.m_objViewer.m_dtpNoon1.Value)
                {
                    MessageBox.Show("请递增设置时间段", "提示");
                    this.m_objViewer.m_dtpNoon1.Focus();
                    return false;
                }
                else if (this.m_objViewer.m_chkEvening.Checked == true && this.m_objViewer.m_dtpMorng2.Value > this.m_objViewer.m_dtpEven1.Value)
                {
                    MessageBox.Show("请递增设置时间段", "提示");
                    this.m_objViewer.m_dtpEven1.Focus();
                    return false;
                }

                p_strTime = this.m_objViewer.m_dtpMorng1.Value.ToString("HH:mm") + "-" + this.m_objViewer.m_dtpMorng2.Value.ToString("HH:mm");
            }

            if (this.m_objViewer.m_chkNoon.Checked == true) //时间段2
            {
                if (this.m_objViewer.m_chkMorning.Checked == true)
                    p_strTime += "|";
                if (this.m_objViewer.m_chkMorning.Checked == true && this.m_objViewer.m_dtpNoon1.Value < this.m_objViewer.m_dtpMorng2.Value)
                {

                    MessageBox.Show("请递增设置时间段", "提示");
                    this.m_objViewer.m_dtpNoon1.Focus();
                    return false;
                }
                if (this.m_objViewer.m_dtpNoon1.Value > this.m_objViewer.m_dtpNoon2.Value)
                {
                    MessageBox.Show("不能小于前段时间", "提示");
                    this.m_objViewer.m_dtpNoon2.Focus();
                    return false;
                }
                else if (this.m_objViewer.m_chkEvening.Checked == true && this.m_objViewer.m_dtpNoon1.Value > this.m_objViewer.m_dtpEven1.Value)
                {
                    MessageBox.Show("请递增设置时间段", "提示");
                    this.m_objViewer.m_dtpEven1.Focus();
                    return false;
                }

                if (this.m_objViewer.m_chkEvening.Checked == true && this.m_objViewer.m_dtpNoon2.Value > this.m_objViewer.m_dtpEven1.Value)
                {
                    MessageBox.Show("请递增设置时间段", "提示");
                    this.m_objViewer.m_dtpEven1.Focus();
                    return false;
                }
                p_strTime += this.m_objViewer.m_dtpNoon1.Value.ToString("HH:mm") + "-" + this.m_objViewer.m_dtpNoon2.Value.ToString("HH:mm");
            }
            if (this.m_objViewer.m_chkEvening.Checked == true)  //时间段3
            {
                if (this.m_objViewer.m_chkMorning.Checked == true || this.m_objViewer.m_chkNoon.Checked == true)
                    p_strTime += "|";
                if (this.m_objViewer.m_chkMorning.Checked == true && this.m_objViewer.m_dtpEven1.Value < this.m_objViewer.m_dtpMorng2.Value)
                {

                    MessageBox.Show("请递增设置时间段", "提示");
                    this.m_objViewer.m_dtpEven1.Focus();
                    return false;
                }
                else if (this.m_objViewer.m_chkNoon.Checked == true && this.m_objViewer.m_dtpEven1.Value < this.m_objViewer.m_dtpNoon2.Value)
                {
                    MessageBox.Show("请递增设置时间段", "提示");
                    this.m_objViewer.m_dtpEven1.Focus();
                    return false;
                }
                if (this.m_objViewer.m_dtpEven1.Value > this.m_objViewer.m_dtpEven2.Value)
                {
                    MessageBox.Show("不能小于前段时间", "提示");
                    this.m_objViewer.m_dtpEven2.Focus();
                    return false;
                }
                p_strTime += this.m_objViewer.m_dtpEven1.Value.ToString("HH:mm") + "-" + this.m_objViewer.m_dtpEven1.Value.ToString("HH:mm");
            }

            if (this.m_objViewer.m_cboDate.Text == "")
            {
                MessageBox.Show("请选择排班日期", "提示");
                this.m_objViewer.m_cboDate.Focus();
                return false;
            }
            if (p_strTime == "")
            {
                MessageBox.Show("请选择排班时间", "提示");
                this.m_objViewer.m_chkMorning.Focus();
                return false;
            }
            //if(this.m_objViewer.m_txtMedStore.txtValuse=="")
            //{
            //    MessageBox.Show("转发药房不能为空","提示");
            //    this.m_objViewer.m_txtMedStore.Focus();
            //    return false;
            //}
            if (this.flage == "Add")
            {
                for (int i1 = 0; i1 < this.m_objViewer.m_lsv.Items.Count; ++i1)
                {

                    if (this.m_objViewer.m_cboDate.Text.Trim() == m_objViewer.m_lsv.Items[i1].SubItems[0].Text.Trim())
                    {
                        MessageBox.Show("日期不能重复", "提示");
                        this.m_objViewer.m_cboDate.Focus();
                        return false;
                    }
                }
            }
            else
            {
                for (int i1 = 0; i1 < this.m_objViewer.m_lsv.Items.Count; ++i1)
                {
                    if (this.m_objViewer.m_cboDate.Text.Trim() == m_objViewer.m_lsv.Items[i1].SubItems[0].Text.Trim() &&
                        this.m_objViewer.m_lsv.SelectedItems[0].Index != i1)
                    {
                        MessageBox.Show("日期不能重复", "提示");
                        this.m_objViewer.m_cboDate.Focus();
                        return false;
                    }
                }
            }
            return true;


        }
        #endregion

        #region 保存 排班信息 xgpeng 2006-2-9
        /// <summary>
        /// 保存 排班信息
        /// </summary>
        public void m_saveDeptDutyInfo()
        {
            if (this.m_objViewer.m_lsvDetail.Items.Count == 0)
                return;

            if (this.m_objViewer.m_lsvDetail.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择排班药房", "提示");
                return;
            }
            if (this.m_objViewer.m_lsvDetail.SelectedItems[0].SubItems[1].Text == this.m_objViewer.m_txtMedStore.txtValuse.Trim())
            {
                MessageBox.Show("转发药房不能为自己", "提示");
                m_objViewer.m_txtMedStore.Focus();
                return;
            }
            if (this.flage == "Add")
            {
                m_AddDeptDutyInfo();
            }
            else
                m_UpdateDeptDutyInfo();



        }
        #endregion

        #region 保存 修改排班信息 xgpeng 2006-2-9
        /// <summary>
        /// 保存 修改排班信息
        /// </summary>
        public void m_UpdateDeptDutyInfo()
        {
            bool flag = false;
            string p_strTime = "";
            if (this.m_objViewer.m_lsv.Items.Count == 0)
                return;
            if (this.m_objViewer.m_lsv.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改的记录", "提示");
                return;
            }
            flag = m_Judge(out p_strTime);
            if (flag == false)
                return;
            clsMedDeptDuty_VO p_objWorkDuty = new clsMedDeptDuty_VO();
            p_objWorkDuty = (clsMedDeptDuty_VO)(this.m_objViewer.m_lsv.SelectedItems[0].Tag);
            p_objWorkDuty.m_strWorkTime = p_strTime.Trim();
            p_objWorkDuty.m_intWeekDay = m_changeNum(this.m_objViewer.m_cboDate.Text.Trim());
            //p_objWorkDuty.m_strDeptID=((clsMedStore_VO)this.m_objViewer.m_lsv.SelectedItems[0].Tag).m_strMedStoreID;
            //p_objWorkDuty.m_intTypeID=1;
            p_objWorkDuty.m_strObjectDeptID = this.m_objViewer.m_txtMedStore.Tag.ToString().Trim();
            p_objWorkDuty.m_strObjectDeptName = this.m_objViewer.m_txtMedStore.txtValuse.Trim();
            p_objWorkDuty.m_strRemark = this.m_objViewer.m_txtRemark.Text.Trim();
            long lngRes = this.m_objManage.m_thUpdateDeptDutyInfo(p_objWorkDuty);
            if (lngRes > 0)
            {
                //				this.m_objViewer.m_lsv.SelectedItems[0].SubItems[0].Text=this.m_objViewer.m_cboDate.Text.Trim();
                //				this.m_objViewer.m_lsv.SelectedItems[0].SubItems[1].Text=p_objWorkDuty.m_strWorkTime.ToString().Trim();
                //				this.m_objViewer.m_lsv.SelectedItems[0].SubItems[2].Text=p_objWorkDuty.m_strObjectDeptName.ToString().Trim();
                //				this.m_objViewer.m_lsv.SelectedItems[0].SubItems[3].Text=p_objWorkDuty.m_strRemark.ToString().Trim();
                //				this.m_objViewer.m_lsv.SelectedItems[0].Tag=p_objWorkDuty;
                m_GetDeptDutyInfo();
                this.flage = "Add";
                //this.m_objViewer.m_lsv.SelectedItems[0].Checked=false;
                m_mthClearDeptDutyInfo();
            }

        }

        #region 删除 排班信息  xgpeng 2006-2-9
        /// <summary>
        /// 删除 排班信息
        /// </summary>
        public void m_DelDeptDutyInfo()
        {
            int p_intID;
            if (this.m_objViewer.m_lsv.Items.Count == 0)
                return;
            if (this.m_objViewer.m_lsv.SelectedItems.Count == 0)
            {
                MessageBox.Show("请选择要修改的记录", "提示");
                return;
            }
            if (MessageBox.Show("确定要删除该记录吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            //clsMedDeptDuty_VO p_objWorkDuty=new clsMedDeptDuty_VO();
            p_intID = ((clsMedDeptDuty_VO)m_objViewer.m_lsv.SelectedItems[0].Tag).m_strSeq;
            long lngRes = this.m_objManage.m_thDelDeptDutyInfo(p_intID);
            if (lngRes > 0)
            {
                m_objViewer.m_lsv.SelectedItems[0].Remove();
                m_mthClearDeptDutyInfo(); //清空控件内容
                this.flage = "Add";
            }
        }
        #endregion


        #endregion

        #region 排班列表框项改变  xgpeng 2006-2-9
        /// <summary>
        /// 排班列表框项改变 
        /// </summary>
        public void m_thChangeLsvText()
        {
            string p_strWorkTime = "";
            this.flage = "Update";
            if (this.m_objViewer.m_lsv.Items.Count == 0)
                return;
            if (this.m_objViewer.m_lsv.SelectedItems.Count == 0)
            {
                //MessageBox.Show("请选择记录","提示");
                return;
            }
            this.m_objViewer.m_cboDate.Text = this.m_objViewer.m_lsv.SelectedItems[0].SubItems[0].Text.Trim();
            p_strWorkTime = this.m_objViewer.m_lsv.SelectedItems[0].SubItems[1].Text.Trim();
            m_DischargeWorkTime(p_strWorkTime);
            this.m_objViewer.m_txtMedStore.Tag = ((clsMedDeptDuty_VO)m_objViewer.m_lsv.SelectedItems[0].Tag).m_strObjectDeptID.Trim();
            this.m_objViewer.m_txtMedStore.txtValuse = this.m_objViewer.m_lsv.SelectedItems[0].SubItems[2].Text.Trim();
            this.m_objViewer.m_txtRemark.Text = this.m_objViewer.m_lsv.SelectedItems[0].SubItems[3].Text.Trim();
        }
        #endregion

        #region 拆分时间  xgpeng 2006-2-9
        /// <summary>
        /// 拆分时间
        /// </summary>
        /// <param name="p_strWorkTime"></param>
        private void m_DischargeWorkTime(string p_strWorkTime)
        {
            string _split = "|";
            string[] objstr = p_strWorkTime.ToString().Split(_split.ToCharArray());


            for (int f2 = 0; f2 < objstr.Length; f2++)
            {
                _split = "-";
                string[] objstr1 = objstr[f2].Split(_split.ToCharArray());
                if (objstr1.Length == 2)
                {
                    if (f2 == 2) //第三段时间
                    {
                        this.m_objViewer.m_chkEvening.Checked = true;
                        this.m_objViewer.m_dtpEven1.Value = Convert.ToDateTime(objstr1[0].ToString().Trim());
                        this.m_objViewer.m_dtpEven2.Value = Convert.ToDateTime(objstr1[1].ToString().Trim());
                        continue;
                    }
                    else
                        this.m_objViewer.m_chkEvening.Checked = false;
                    if (f2 == 1) //第二段时间
                    {
                        this.m_objViewer.m_chkNoon.Checked = true;
                        this.m_objViewer.m_dtpNoon1.Value = Convert.ToDateTime(objstr1[0].ToString().Trim());
                        this.m_objViewer.m_dtpNoon2.Value = Convert.ToDateTime(objstr1[1].ToString().Trim());
                        continue;
                    }
                    else
                        this.m_objViewer.m_chkNoon.Checked = false;

                    if (f2 == 0) //第一段时间
                    {
                        this.m_objViewer.m_chkMorning.Checked = true;
                        this.m_objViewer.m_dtpMorng1.Value = Convert.ToDateTime(objstr1[0].ToString().Trim());
                        this.m_objViewer.m_dtpMorng2.Value = Convert.ToDateTime(objstr1[1].ToString().Trim());
                        continue;
                    }
                    else
                        this.m_objViewer.m_chkMorning.Checked = false;
                }
            }
        }
        #endregion


    }
}
