using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    /// <summary>
    /// 药品仓库设置
    /// </summary>
    public partial class frmMedicineStoreroomSet : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {

        #region 全局变量.

        /// <summary>
        /// 药品类型信息.
        /// </summary>
        internal clsMS_MedicineType_VO[] m_objMedicineTypeArr;

        /// <summary>
        /// 保存库房类型信息.
        /// </summary>
        internal List<clsMS_MedicineStoreroom_VO> m_lstMedicineRoomInfo;

        /// <summary>
        /// 当前库房类型信息.
        /// </summary>
        internal clsMS_MedicineStoreroom_VO m_objCurrentRoomInfo;
        /// <summary>
        /// 当前库房类型信息(删除用)
        /// </summary>
        internal clsMS_MedicineStoreroom_VO m_objCurrentRoomInfoForUpdate;

        /// <summary>
        /// 为TRUE时,表示保存,FALSE表示修改.
        /// </summary>
        internal bool m_blnIsSave;

        #endregion
        /// <summary>
        /// 保存药房基本信息表
        /// </summary>
        public DataTable m_dtMedStore;
        /// <summary>
        /// 保存传入的药房id
        /// </summary>
        public string[] m_strMedStoreArr = null;
        /// <summary>
        /// 自定义操作名称
        /// </summary>
        /// <param name="m_strMedStordid">显示的药房id</param>
        public void m_mthSetShow(string m_strMedStordid)
        {
            m_strMedStoreArr = m_strMedStordid.Split('*');
            this.m_mthSetGUI();
            this.Show();
        }
        /// <summary>
        /// 构造函数.
        /// </summary>
        public frmMedicineStoreroomSet()
        {
            InitializeComponent();
           
        }

        #region 方法.

        #region 设置窗体控制器.
        /// <summary>
        /// 重载方法,设置窗体控制器.
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtl_MedicineStoreroomSet();
            objController.Set_GUI_Apperance(this);
        }
        #endregion

        #region 初始化并显示药品类型信息.

        /// <summary>
        /// 初始化并显示药品类型信息.
        /// </summary>
        public void m_mthInitlsvMedicineName()
        {
            ListViewItem lvi;
            this.m_lsvMedicineName.Items.Clear();
            this.m_lsvMedicineName.BeginUpdate();
            try
            {
                ((clsCtl_MedicineStoreroomSet)objController).m_mthGetMedicineTypeInfo(out m_objMedicineTypeArr);
                
                foreach (clsMS_MedicineType_VO medicineType in m_objMedicineTypeArr)
                {
                    lvi = new ListViewItem(medicineType.m_strMedicineTypeName_VCHR);
                    //lvi.Text = medicineType.m_strMedicineTypeName_VCHR;
                    lvi.Tag = medicineType.m_strMedicineTypeID_CHR;
                    lvi.Checked = false;
                    this.m_lsvMedicineName.Items.Add(lvi);
                }
            }
            catch (Exception objEx)
            {
                MessageBox.Show(objEx.Message, "药品仓库设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.m_lsvMedicineName.EndUpdate();
            }
        }
        #endregion

        #region 初始化并显示库房信息.

        /// <summary>
        /// 初始化并显示库房信息.
        /// </summary>
        public void m_mthInitlsvMedicineStore()
        {
            ListViewItem lvi;
            ListViewItem.ListViewSubItem lvsi;
            ListViewItem.ListViewSubItem lvsii;
            ListViewItem.ListViewSubItem lvsiii;
            //StringBuilder strBuilder;

            this.m_lsvMedicineStore.Items.Clear();
            this.m_lsvMedicineStore.BeginUpdate();
            try
            {
                foreach (clsMS_MedicineStoreroom_VO objStoreroom in m_lstMedicineRoomInfo)
                {
                    //strBuilder = new StringBuilder();
                    //int j = 0;
                    //foreach (string str in objStoreroom.m_strMedicineTypeID_CHR)
                    //{
                    //    strBuilder.Append(str);
                    //    strBuilder.Append("; ");
                    //    j++;
                    //    if (j >= 2)
                    //        break;
                    //}
                    //strBuilder.Append("...");

                    lvi = new ListViewItem();
                    lvi.Text = objStoreroom.m_strMedicineRoomID_VCHR;
                    lvi.Tag = objStoreroom;

                    lvsi = new ListViewItem.ListViewSubItem();
                    lvsi.Text = objStoreroom.m_strMedicineRoomName_VCHR;
                    lvi.SubItems.Add(lvsi);

                    lvsii = new ListViewItem.ListViewSubItem();
                    lvsii.Text = objStoreroom.m_strDEPTNAME_CHR;
                    lvi.SubItems.Add(lvsii);
                    //+2008.5.14 wuchongkun
                    lvsiii = new ListViewItem.ListViewSubItem();
                    lvsiii.Text = objStoreroom.m_strMidicineRommShortName_CHR;
                    lvi.SubItems.Add(lvsiii );

                    this.m_lsvMedicineStore.Items.Add(lvi);  
                }
            }
            finally
            {
                this.m_lsvMedicineStore.EndUpdate();
            }
        }
        #endregion

        //#region 将库房信息添加到列表中

        ////public void AddToListView(clsMS_
        //#endregion

        #endregion

        /// <summary>
        /// 新增库房.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdAdd_Click(object sender, EventArgs e)
        {
            m_blnIsSave = true;
            m_txtMedicineStoreRoom.Text = "";
            m_txtMedStoreShortName.Text = "";
            m_txtDept.Clear();
            ListView.CheckedListViewItemCollection lvcCollection = m_lsvMedicineName.CheckedItems;
            if (lvcCollection.Count == 0)
            {
                return;
            }
            foreach (ListViewItem lvi in lvcCollection)
            {
                lvi.Checked = false;
            }
        }

        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            if (this.m_strMedStoreArr == null)
            {
                if (m_txtMedicineStoreRoom.Text.Length == 0 || m_txtMedicineStoreRoom.Text.Length >= 50)
                {
                    MessageBox.Show("仓库名称不能为空,且长度小于50个字符.", "药品仓库设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_txtMedicineStoreRoom.Focus();
                    return;
                }
                if (m_lsvMedicineName.CheckedItems.Count == 0)
                {
                    MessageBox.Show("药品类型不能为空", "药品仓库设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_lsvMedicineName.Focus();
                    return;
                }

                if (m_txtMedStoreShortName.Text.Trim().Replace(" ", "").Length != 3)
                {
                    MessageBox.Show("仓库简码必须为三位字母。", "药品仓库设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    m_txtMedStoreShortName.Focus();
                    return;
                }

                if (this.m_txtDept.Text.Trim() == string.Empty)
                {
                    MessageBox.Show("必须绑定该药库对应的部门！", "药品仓库设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.m_txtDept.Focus();
                    return;
                }

                string strStoreName = m_txtMedicineStoreRoom.Text;
                string strStoreID;

                if (!m_blnIsSave)
                {
                    strStoreID = m_objCurrentRoomInfo.m_strMedicineRoomID_VCHR;
                }
                else
                {
                    strStoreID = string.Empty;
                }

                //if (this.m_objCurrentRoomInfo == null)
                //{
                foreach (ListViewItem lvi in this.m_lsvMedicineStore.Items)
                {
                    if (((clsMS_MedicineStoreroom_VO)lvi.Tag).m_strDEPTID_CHR == this.m_txtDept.StrItemId.Trim() && this.m_txtDept.StrItemId.Trim() != "" && ((clsMS_MedicineStoreroom_VO)lvi.Tag).m_strMedicineRoomID_VCHR != strStoreID)
                    {
                        MessageBox.Show(((clsMS_MedicineStoreroom_VO)lvi.Tag).m_strMedicineRoomName_VCHR + "已对应到该部门， 一个部门只能对应一个药房！", "药品仓库设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.m_txtDept.Clear();
                        this.m_txtDept.Focus();
                        return;
                    }
                    if (((clsMS_MedicineStoreroom_VO)lvi.Tag).m_strMidicineRommShortName_CHR == this.m_txtMedStoreShortName.Text && ((clsMS_MedicineStoreroom_VO)lvi.Tag).m_strMedicineRoomID_VCHR != strStoreID)
                    {
                        MessageBox.Show("\""+this.m_txtMedStoreShortName.Text + "\"已被使用，请使用其他简码！", "药品仓库设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.m_txtMedStoreShortName.Clear();
                        this.m_txtMedStoreShortName.Focus();
                        return;
                    }
                }
                //}
                //else
                //{
                    //    foreach (ListViewItem lvi in this.m_lsvMedicineStore.Items)
                //    {
                //        if (((clsMS_MedicineStoreroom_VO)lvi.Tag).m_strDEPTID_CHR.Trim() == this.m_txtDept.StrItemId.Trim() && this.m_txtDept.StrItemId.Trim() != this.m_objCurrentRoomInfo.m_strDEPTID_CHR && this.m_txtDept.StrItemId.Trim() != "")
                //        {
                //            MessageBox.Show(((clsMS_MedicineStoreroom_VO)lvi.Tag).m_strMedicineRoomName_VCHR + "已对应到该部门， 一个部门只能对应一个药房！", "药品仓库设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            this.m_txtDept.Clear();
                //            this.m_txtDept.Focus();
                //            blnResult = false;
                //        }
                //    }
                //}

                

                int iMedicineCount = m_lsvMedicineName.CheckedItems.Count;

                m_objCurrentRoomInfo = new clsMS_MedicineStoreroom_VO();

                int i = 0;
                m_objCurrentRoomInfo.m_strMedicineTypeID_CHR = new string[m_lsvMedicineName.CheckedItems.Count];
                foreach (ListViewItem lvi in m_lsvMedicineName.CheckedItems)
                {
                    m_objCurrentRoomInfo.m_strMedicineRoomID_VCHR = strStoreID;
                    m_objCurrentRoomInfo.m_strMedicineRoomName_VCHR = strStoreName;
                    if (m_blnIsSave)
                        m_objCurrentRoomInfo.m_strDEPTID_CHR = m_txtDept.StrItemId.Trim();
                    else
                        m_objCurrentRoomInfo.m_strDEPTID_CHR = m_txtDept.Tag.ToString();
                    m_objCurrentRoomInfo.m_strDEPTNAME_CHR = m_txtDept.Text;
                    //+2008.5.14吴崇坤
                    m_objCurrentRoomInfo.m_strMidicineRommShortName_CHR = m_txtMedStoreShortName.Text.Trim();
                    m_objCurrentRoomInfo.m_strMedicineTypeID_CHR[i] = lvi.Tag as string;
                    i++;
                }

                if (m_blnIsSave)
                {
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthInsertMedicineRoomInfo(ref m_objCurrentRoomInfo);
                    m_lstMedicineRoomInfo.Add(m_objCurrentRoomInfo);
                }
                else
                {
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthDeleteMedicineRoomInfo(strStoreID);
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthInsertMedicineRoomInfo(ref m_objCurrentRoomInfo);
                    m_lstMedicineRoomInfo.Remove(m_objCurrentRoomInfoForUpdate);
                    m_lstMedicineRoomInfo.Add(m_objCurrentRoomInfo);
                    m_blnIsSave = true;
                }

                m_mthInitlsvMedicineStore();
                m_txtMedicineStoreRoom.Text = "";
                //2008.5.14 wuchongkun
                m_txtMedStoreShortName.Text = "";
                m_txtDept.Clear();
                ListView.CheckedListViewItemCollection lvcCollection = m_lsvMedicineName.CheckedItems;
                if (lvcCollection.Count == 0)
                {
                    return;
                }
                foreach (ListViewItem lvi in lvcCollection)
                {
                    lvi.Checked = false;
                }
            }
            else
            {
                if (m_txtMedicineStoreRoom.Text.Length == 0 || m_txtMedicineStoreRoom.Text.Length >= 50)
                {
                    MessageBox.Show("药房名称不能为空,且长度必须小于50个字符.", "药房对应药品类型设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (m_lsvMedicineName.CheckedItems.Count == 0)
                {
                    MessageBox.Show("药品类型不能为空", "药房对应药品类型设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string strStoreName = m_txtMedicineStoreRoom.Text;
                string strStoreID;

                  strStoreID = this.m_lsvMedicineStore.SelectedItems[0].Text;


                int iMedicineCount = m_lsvMedicineName.CheckedItems.Count;

                m_objCurrentRoomInfo = new clsMS_MedicineStoreroom_VO();

                int i = 0;
                m_objCurrentRoomInfo.m_strMedicineTypeID_CHR = new string[m_lsvMedicineName.CheckedItems.Count];
                foreach (ListViewItem lvi in m_lsvMedicineName.CheckedItems)
                {
                    m_objCurrentRoomInfo.m_strMedicineRoomID_VCHR = strStoreID;
                    m_objCurrentRoomInfo.m_strMedicineRoomName_VCHR = strStoreName;
                    m_objCurrentRoomInfo.m_strMedicineTypeID_CHR[i] = lvi.Tag as string;
                    i++;
                }

                if (m_blnIsSave)
                {
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthInsertMedStoreSetInfo(ref m_objCurrentRoomInfo);
                }
                else
                {
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthDeleteMedStoreSetInfo(strStoreID, false);
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthInsertMedStoreSetInfo(ref m_objCurrentRoomInfo);
                    m_blnIsSave = true;
                }

                m_txtMedicineStoreRoom.Text = "";
                m_txtMedStoreShortName.Text = "";
                m_txtDept.Clear();
                ListView.CheckedListViewItemCollection lvcCollection = m_lsvMedicineName.CheckedItems;
                if (lvcCollection.Count == 0)
                {
                    return;
                }
                foreach (ListViewItem lvi in lvcCollection)
                {
                    lvi.Checked = false;
                }                
            }
        }

        private void m_cmdDelete_Click(object sender, EventArgs e)
        {
            if (this.m_strMedStoreArr == null)
            {
                if (m_lsvMedicineStore.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要删除的记录.", "药品仓库设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult drResult = MessageBox.Show("确定删除选定仓库设置？", "药品仓库设置", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }

                if (m_lsvMedicineStore.SelectedItems.Count == 1)
                {
                    m_objCurrentRoomInfo = m_lsvMedicineStore.SelectedItems[0].Tag as clsMS_MedicineStoreroom_VO;
                    string strStoreID = m_objCurrentRoomInfo.m_strMedicineRoomID_VCHR;

                    ((clsCtl_MedicineStoreroomSet)objController).m_mthDeleteMedicineRoomInfo(strStoreID);

                    m_lstMedicineRoomInfo.Remove(m_objCurrentRoomInfo);
                    m_lsvMedicineStore.Items.Remove(m_lsvMedicineStore.SelectedItems[0]);
                    m_lsvMedicineStore.Refresh();
                }
            }
            else
            {
                if (m_lsvMedicineStore.SelectedItems.Count == 0)
                {
                    MessageBox.Show("请选择要删除的记录.", "药房对应药品类型设置", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                DialogResult drResult = MessageBox.Show("确定删除选定药房设置？", "药房对应药品类型设置", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (drResult == DialogResult.No)
                {
                    return;
                }
                if (m_lsvMedicineStore.SelectedItems.Count == 1)
                {
                   
                    string strStoreID = m_lsvMedicineStore.SelectedItems[0].Text;

                    ((clsCtl_MedicineStoreroomSet)objController).m_mthDeleteMedStoreSetInfo(strStoreID,true);
                    m_lsvMedicineStore.Refresh();
                }
            }
            
        }

        private void m_lsvMedicineStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_strMedStoreArr == null)
            {

                if (m_lsvMedicineStore.SelectedItems.Count == 1)
                {
                    foreach (ListViewItem lvi in m_lsvMedicineName.CheckedItems)
                    {
                        lvi.Checked = false;
                    }

                    m_objCurrentRoomInfo = m_lsvMedicineStore.SelectedItems[0].Tag as clsMS_MedicineStoreroom_VO;
                    m_objCurrentRoomInfoForUpdate = m_objCurrentRoomInfo;
                    m_txtMedicineStoreRoom.Text = m_objCurrentRoomInfo.m_strMedicineRoomName_VCHR;
                    m_txtDept.Text = m_objCurrentRoomInfo.m_strDEPTNAME_CHR;
                    m_txtMedStoreShortName.Text = m_objCurrentRoomInfo.m_strMidicineRommShortName_CHR;
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthSetMedicineTypeCheck(m_objCurrentRoomInfo.m_strMedicineRoomID_VCHR);
                }
            }
            else
            {
                if (m_lsvMedicineStore.SelectedItems.Count == 1)
                {
                    foreach (ListViewItem lvi in m_lsvMedicineName.CheckedItems)
                    {
                        lvi.Checked = false;
                    }
                    m_txtMedicineStoreRoom.Text = this.m_lsvMedicineStore.SelectedItems[0].SubItems[1].Text;
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthSetMedicineTypeCheck(this.m_lsvMedicineStore.SelectedItems[0].Text);
                }
            }
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void m_mthSetGUI()
        {
            this.Text = "药房对应药品类型设置";
            this.label1.Text = "药房名称";
            this.m_lsvMedicineStore.Columns[0].Text = "药房id";
            this.m_lsvMedicineStore.Columns[1].Text = "药房名称";
            this.m_txtMedicineStoreRoom.ReadOnly = true;
            this.m_cmdAdd.Enabled = false;
            m_txtDept.Visible = false;
            label10.Visible = false;
            m_txtMedStoreShortName.ReadOnly = true;
            this.m_lsvMedicineStore.Columns.RemoveAt(2);
        }
        private void frmMedicineStoreroomSet_Load(object sender, EventArgs e)
        {
            if (m_strMedStoreArr == null)
            {
                DataTable m_dtDeptDesc = new DataTable();
                ((clsCtl_MedicineStoreroomSet)objController).m_lngGetDeptInfo(out m_dtDeptDesc);
                this.m_txtDept.m_mthInitDeptData(m_dtDeptDesc);

                m_lstMedicineRoomInfo = new List<clsMS_MedicineStoreroom_VO>();
                m_blnIsSave = true;

                ((clsCtl_MedicineStoreroomSet)objController).m_mthGetMedicineTypeInfo(out m_objMedicineTypeArr);
                ((clsCtl_MedicineStoreroomSet)objController).m_mthGetMedicineRoomInfo(ref m_lstMedicineRoomInfo);

                // 初始化并显示药品类型信息.
                m_mthInitlsvMedicineName();
                // 初始化并显示库房信息
                m_mthInitlsvMedicineStore();
            }
            else
            {
                ((clsCtl_MedicineStoreroomSet)objController).m_mthGetMedicineTypeInfo(out m_objMedicineTypeArr);
                // 初始化并显示药品类型信息.
                m_mthInitlsvMedicineName();
                m_dtMedStore = new DataTable();
                ((clsCtl_MedicineStoreroomSet)objController).m_lngGetMedStoreInfo(out m_dtMedStore);
                ListViewItem lvi;
                this.m_lsvMedicineStore.BeginUpdate();
                if (m_strMedStoreArr.Length == 2 && m_strMedStoreArr[0] == string.Empty && m_strMedStoreArr[1] == string.Empty)
                {
                    for (int i = 0; i < m_dtMedStore.Rows.Count; i++)
                    {
                        lvi = new ListViewItem(m_dtMedStore.Rows[i]["medstoreid_chr"].ToString());
                        lvi.SubItems.Add(m_dtMedStore.Rows[i]["medstorename_vchr"].ToString());
                        lvi.SubItems.Add(m_dtMedStore.Rows[i]["shortname_chr"].ToString());
                        this.m_lsvMedicineStore.Items.Add(lvi);
                    }
                }
                else
                {
                    if (m_strMedStoreArr.Length > 0)
                    {
                        for (int i = 0; i < m_dtMedStore.Rows.Count; i++)
                        {
                            for (int j = 0; j < m_strMedStoreArr.Length; j++)
                            {
                                if (m_strMedStoreArr[j] == m_dtMedStore.Rows[i]["medstoreid_chr"].ToString())
                                {
                                    lvi = new ListViewItem(m_dtMedStore.Rows[i]["medstoreid_chr"].ToString());
                                    lvi.SubItems.Add(m_dtMedStore.Rows[i]["medstorename_vchr"].ToString());
                                    //2008.5.14wuchongkun
                                    lvi.SubItems.Add(m_dtMedStore .Rows [i]["shortname_chr"].ToString ());
                                    this.m_lsvMedicineStore.Items.Add(lvi);
                                }
                            }
                        }
                    }

                }
                this.m_lsvMedicineStore.EndUpdate();
                if (this.m_lsvMedicineStore.Items.Count > 0)
                    this.m_lsvMedicineStore.Items[0].Selected = true;
            }
        }

        private void m_lsvMedicineStore_Click(object sender, EventArgs e)
        {
            if (m_strMedStoreArr == null)
            {

                if (m_lsvMedicineStore.SelectedItems.Count == 1)
                {
                    foreach (ListViewItem lvi in m_lsvMedicineName.CheckedItems)
                    {
                        lvi.Checked = false;
                    }

                    m_objCurrentRoomInfo = m_lsvMedicineStore.SelectedItems[0].Tag as clsMS_MedicineStoreroom_VO;
                    m_txtMedicineStoreRoom.Text = m_objCurrentRoomInfo.m_strMedicineRoomName_VCHR;
                    m_txtDept.Text = m_objCurrentRoomInfo.m_strDEPTNAME_CHR;
                    m_txtDept.Tag = m_objCurrentRoomInfo.m_strDEPTID_CHR;
                    //2008.5.14  wuchongkun
                    m_txtMedStoreShortName.Text = m_objCurrentRoomInfo.m_strMidicineRommShortName_CHR;
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthSetMedicineTypeCheck(m_objCurrentRoomInfo.m_strMedicineRoomID_VCHR);
                }
            }
            else
            {
                if (m_lsvMedicineStore.SelectedItems.Count == 1)
                {
                    foreach (ListViewItem lvi in m_lsvMedicineName.CheckedItems)
                    {
                        lvi.Checked = false;
                    }
                    m_txtMedicineStoreRoom.Text = this.m_lsvMedicineStore.SelectedItems[0].SubItems[1].Text;
                    m_txtMedStoreShortName.Text = this.m_lsvMedicineStore.SelectedItems[0].SubItems[2].Text;
                    ((clsCtl_MedicineStoreroomSet)objController).m_mthSetMedicineTypeCheck(this.m_lsvMedicineStore.SelectedItems[0].Text);
                }
            }
        }

        private void m_txtMedStoreShortName_TextChanged(object sender, EventArgs e)
        {
            this.m_txtMedStoreShortName.Text = this.m_txtMedStoreShortName.Text.ToUpper();
            this.m_txtMedStoreShortName.SelectionStart = this.m_txtMedStoreShortName.Text.Length;
        }

        private void m_txtMedStoreShortName_Leave(object sender, EventArgs e)
        {
            if(this .m_txtMedStoreShortName .Text !=""&&this .m_txtMedStoreShortName.Text .Length <3)
            {
                MessageBox.Show("仓库简码必须是三位大写字母","提示",MessageBoxButtons .OK ,MessageBoxIcon.Information );
                this.m_txtMedStoreShortName.Focus();
                return;
            }
        }

        private void m_txtMedStoreShortName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void m_txtMedStoreShortName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 8 || e.KeyChar == 13 || (e.KeyChar >= 65 && e.KeyChar <= 90) || (e.KeyChar >= 97 && e.KeyChar <= 122))
            { }
            else
            {
                e.Handled = true;
                MessageBox.Show("仓库简码必须是三位大写字母", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_txtMedStoreShortName.Focus();
             
            }
        }

        private void m_txtMedicineStoreRoom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                SendKeys.Send("{TAB}");
            }

        }

        private void m_txtDept_ItemSelectedChanged(object sender, com.digitalwave.Controls.clsItemDataEventArg e)
        {
            m_txtDept.Tag = m_txtDept.StrItemId;
        }

        //private void m_lsvMedicineStore_DoubleClick(object sender, EventArgs e)
        //{
        //    if (m_lsvMedicineStore.SelectedItems.Count > 0)
        //    {
        //        m_objCurrentRoomInfo = (clsMS_MedicineStoreroom_VO)m_lsvMedicineStore.SelectedItems[0].Tag;
        //        ((clsCtl_MedicineStoreroomSet)objController).m_mthSelectMedicineName(m_objCurrentRoomInfo.m_strMedicineRoomID_VCHR, out m_objCurrentRoomInfo.m_strMedicineTypeID_CHR);

        //        m_txtMedicineStoreRoom.Text = m_objCurrentRoomInfo.m_strMedicineRoomID_VCHR;

        //        ListView.CheckedListViewItemCollection lvcCollection = m_lsvMedicineName.CheckedItems;
        //        if (lvcCollection.Count != 0)
        //        {
        //            foreach (ListViewItem lvi in lvcCollection)
        //            {
        //                lvi.Checked = false;
        //            }
        //        }
        //        foreach (string str in m_objCurrentRoomInfo.m_strMedicineTypeID_CHR)
        //        {
        //            ListViewItem lvi = m_lsvMedicineName.FindItemWithText(str);
        //            if (lvi != null)
        //            {
        //                lvi.Checked = true;
        //            }
        //        }
        //    }
        //    m_blnIsSave = false;
        //}
    }
}