using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using com.digitalwave.Utility;



namespace com.digitalwave.iCare.gui.MedicineStore_Maintain
{
    class clsCtl_StorageRackSet : com.digitalwave.GUI_Base.clsController_Base
    {
        public string strStorId;
        private clsDcl_StorageRacksetSet m_objDomain = null;
        private com.digitalwave.iCare.gui.MedicineStore_Maintain.frmStorageRackset m_objViewer;
              
        #region 构造函数.

        /// <summary>
        /// 构造函数.
        /// </summary>
        public clsCtl_StorageRackSet()
        {
            m_objDomain = new clsDcl_StorageRacksetSet();
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
            m_objViewer = (frmStorageRackset)frmMDI_Child_Base_in;
        }
        #endregion

        #region 生成五笔码/拼音码
        public void m_lngGetpywb()
        {
            try
            {
                string strAny = this.m_objViewer.m_txtStoragerackname.Text.Trim();
               // com.digitalwave.Utility.clsCreateChinaCode getChinaCode = new clsCreateChinaCode();
                com.digitalwave.Utility.clsCreateChinaCode getChinaCode = new com.digitalwave.Utility.clsCreateChinaCode();
                this.m_objViewer.m_txtWbcode.Text = getChinaCode.m_strCreateChinaCode(strAny, ChinaCode.WB);
                this.m_objViewer.m_txtPycode.Text = getChinaCode.m_strCreateChinaCode(strAny, ChinaCode.PY);
                
                if (this.m_objViewer.m_txtPycode.Text.Length > 0)
                {
                    this.m_objViewer.m_txtPycode.Text = this.m_objViewer.m_txtPycode.Text.Substring(0, this.m_objViewer.m_txtPycode.Text.Length > 10 ? 10 : this.m_objViewer.m_txtPycode.Text.Length);
                }
                if (this.m_objViewer.m_txtWbcode.Text.Length > 0)
                {
                    this.m_objViewer.m_txtWbcode.Text = this.m_objViewer.m_txtWbcode.Text.Substring(0, this.m_objViewer.m_txtWbcode.Text.Length > 10 ? 10 : this.m_objViewer.m_txtWbcode.Text.Length);
                }

            }
            catch
            {
                MessageBox.Show("生成生成五笔码/拼音码出错，请不要用英文字母", "系统提示");
            }
        }
        #endregion

        #region 获取库房信息.
        /// <summary>
        /// 获取库房信息.
        /// </summary>
        /// <param name="m_strType">1,药库货架 2,药房货架</param>
        /// <param name="cobRoom">返回结果</param>
        public void m_mthGetMedicineRoomInfo(string m_strType,ref ComboBox cobRoom)
        {
            clsMS_MedicineStoreroom_VO[] m_objMedicineRoomArr = null;
            m_objDomain.m_lngGetStorageInfoByTypeid(m_strType, out m_objMedicineRoomArr);
            if (m_objMedicineRoomArr == null || m_objMedicineRoomArr.Length == 0)
                return;
            foreach (clsMS_MedicineStoreroom_VO obj_VO in m_objMedicineRoomArr)
            {
                ListViewItem li = new ListViewItem(obj_VO.m_strMedicineRoomID_VCHR);
                li.SubItems.Add(obj_VO.m_strMedicineRoomName_VCHR);
                li.Tag = obj_VO;
                cobRoom.Items.Add(obj_VO);
            }
           
        }
        #endregion

        #region 获到货架明细
        /// <summary>
        /// 获到货架明细
        /// </summary>
        public void m_mthGetStorInfo()
        {
           
            DataTable dtb = new DataTable();

            clsMS_StorInfoVo[] objSto_Vo = null;

            m_objDomain.m_lngGetStor(this.m_objViewer.m_strStorageType,out objSto_Vo);

            m_objViewer.m_lsvMedicineTypeSet.Items.Clear();
            foreach (clsMS_StorInfoVo obj_vo in objSto_Vo)
            {
                ListViewItem li = new ListViewItem(obj_vo.m_storId);
               li.SubItems.Add(obj_vo.m_storName);
               li.SubItems.Add(obj_vo.m_ageName);
               li.SubItems.Add(obj_vo.m_pycode);
               li.SubItems.Add(obj_vo.m_wbcode);
               li.Tag=obj_vo;

               m_objViewer.m_lsvMedicineTypeSet.Items.Add(li);
            }
        }
        #endregion

        #region 列表的双击事件
        /// <summary>
        /// 列表的双击事件
        /// </summary>
        public void m_mthVendorListDoubleClick()
        {
            if (m_objViewer.m_lsvMedicineTypeSet.SelectedItems.Count > 0)
            {
                clsMS_StorInfoVo objItem = (clsMS_StorInfoVo)m_objViewer.m_lsvMedicineTypeSet.SelectedItems[0].Tag;
                m_objViewer.m_txtStoragerackcode.Text = objItem.m_storId;
                strStorId = objItem.m_storId;
                m_objViewer.m_txtStoragerackname.Text = objItem.m_storName;
                m_objViewer.m_cboStorageid.Text = objItem.m_ageName;
                m_objViewer.m_txtPycode.Text = objItem.m_pycode;
                m_objViewer.m_txtWbcode.Text = objItem.m_wbcode;
                m_objViewer.m_btnNew.Enabled = true;

            }
        }
        #endregion

        #region 插入记录
        /// <summary>
        /// 插入记录
        /// </summary>
        public void m_mthInsert()
        {
            if (m_objDomain.m_lngFindId(this.m_objViewer.m_strStorageType,m_objViewer.m_txtStoragerackcode.Text.Trim()))
            {
                clsMS_StorInfoVo objVO = new clsMS_StorInfoVo();
                clsMS_MedicineStoreroom_VO li = (clsMS_MedicineStoreroom_VO)m_objViewer.m_cboStorageid.SelectedItem;
                objVO.m_storId = m_objViewer.m_txtStoragerackcode.Text.Trim();
                objVO.m_storName = m_objViewer.m_txtStoragerackname.Text.Trim();
                objVO.m_ageID = li.m_strMedicineRoomID_VCHR;
                objVO.m_pycode = m_objViewer.m_txtPycode.Text.Trim();
                objVO.m_wbcode = m_objViewer.m_txtWbcode.Text.Trim();
                if (m_objViewer.m_strStorageType == "1")
                    objVO.m_intTypeid = 1;
                else
                    objVO.m_intTypeid = 2;
                m_objDomain.m_lngInsertStor(objVO);
                m_objViewer.m_btnNew.Enabled = true;
                MessageBox.Show("新建成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                m_newClick();
            }
            else
            {
                MessageBox.Show("该货架编码已存在,请输入新的编码!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            this.m_mthGetStorInfo();
        }
        #endregion

        #region 修改记录
        /// <summary>
        /// 修改记录
        /// </summary>
        public long m_mthEdit()
        {

            if (m_objViewer.m_lsvMedicineTypeSet.SelectedItems.Count<=0)
            {
                DialogResult result = MessageBox.Show("当前没有选定记录!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return 0;
            }

            
            clsMS_StorInfoVo objVO = new clsMS_StorInfoVo();
            clsMS_MedicineStoreroom_VO li = (clsMS_MedicineStoreroom_VO)m_objViewer.m_cboStorageid.SelectedItem;
            clsMS_StorInfoVo objItem = (clsMS_StorInfoVo)m_objViewer.m_lsvMedicineTypeSet.SelectedItems[0].Tag;

            if (strStorId != m_objViewer.m_txtStoragerackcode.Text.Trim())
            {
                if (m_objDomain.m_lngFindId(this.m_objViewer.m_strStorageType,m_objViewer.m_txtStoragerackcode.Text.Trim()) == false)
                {
                    MessageBox.Show("该货架编码已存在,请输入新的编码!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return 0;
                }
            }

            objVO.m_ID = objItem.m_ID;
            objVO.m_storId = m_objViewer.m_txtStoragerackcode.Text.Trim();
            objVO.m_storName = m_objViewer.m_txtStoragerackname.Text.Trim();
            objVO.m_ageID = li.m_strMedicineRoomID_VCHR;
            objVO.m_pycode = m_objViewer.m_txtPycode.Text.Trim();
            objVO.m_wbcode = m_objViewer.m_txtWbcode.Text.Trim();
            if(m_objViewer.m_strStorageType=="1")
            objVO.m_intTypeid = 1;
            else 
            objVO.m_intTypeid = 2;
            m_objDomain.m_lngEditStor(objVO);
            m_objViewer.m_btnNew.Enabled = true;
            MessageBox.Show("修改成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            this.m_mthGetStorInfo();
            return 1;
        }
        #endregion

        #region 删除记录
        /// <summary>
        /// 删除记录
        /// </summary>
        public void m_mthDel()
        {
            if (m_objViewer.m_lsvMedicineTypeSet.SelectedItems.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("请先选择要删除的作废原因", "作废原因设置", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("确定要删除当前记录吗?", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                clsMS_StorInfoVo objItem = (clsMS_StorInfoVo)m_objViewer.m_lsvMedicineTypeSet.SelectedItems[0].Tag;
                m_objDomain.m_lngDelStore(objItem.m_ID);
                m_objViewer.m_btnNew.Enabled = true;
                MessageBox.Show("删除成功!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.m_mthGetStorInfo();

            }
        }
        /// <summary>
        /// 新建按钮事件
        /// </summary>
        public void m_newClick()
        {
            m_objViewer.m_txtStoragerackcode.Text = "";
            m_objViewer.m_txtStoragerackname.Text = "";
            m_objViewer.m_cboStorageid.Text = "";
            m_objViewer.m_txtPycode.Text = "";
            m_objViewer.m_txtStoragerackcode.Text = "";
            m_objViewer.m_txtWbcode.Text = "";
            m_objViewer.m_btnNew.Enabled = false;
            m_objViewer.m_txtStoragerackcode.Focus();

        }
        #endregion

        #region 保存检查
        /// <summary>
        /// 保存检查
        /// </summary>
        public bool m_mthSerChack()
        {
            
            if (m_objViewer.m_txtStoragerackcode.Text.Trim() == "")
            {
                MessageBox.Show("货架编码不能为空!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.m_objViewer.m_txtStoragerackcode.Focus();
                return false;
            }

　          if (m_objViewer.m_txtStoragerackname.Text.Trim() == "")
            {
                MessageBox.Show("请输入货架名称!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.m_objViewer.m_txtStoragerackname.Focus();
                return false;
            }
            if (m_objViewer.m_cboStorageid.Text.Trim() == "")
            {
                if (this.m_objViewer.m_strStorageType == "1")
                    MessageBox.Show("请先选择药库!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else if (this.m_objViewer.m_strStorageType == "2")
                    MessageBox.Show("请先选择药房!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.m_objViewer.m_cboStorageid.Focus();
                return false;
            }
            return true;
        }
        #endregion

      
    }
}
