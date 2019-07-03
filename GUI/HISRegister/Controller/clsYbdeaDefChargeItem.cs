using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Collections;
using System.Text;
using System.Drawing.Printing;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;

using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.iCare.middletier.baseInfo;//baseInfo_Svc.dll
using com.digitalwave.Utility;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 特定病种对应收费项目维护界面控制
    /// 作者：He Guiqiu
    /// 创建时间:2006-06-24
    /// </summary>
    public class clsYbdeaDefChargeItem : com.digitalwave.GUI_Base.clsController_Base
    {
        private frmYbdeaDefChargeitem m_objViewer;
        private clsDclYbdeaDefChargeItem m_objDomain;
       
        private DataTable m_dtChargeItem;
        private DataTable m_dtYBChargeItem;

        //private string m_deaCode;
        private ArrayList m_newArr = new ArrayList();
        private ArrayList m_removeArr = new ArrayList();

        public clsYbdeaDefChargeItem()
        {
            this.m_objDomain = new clsDclYbdeaDefChargeItem();
            this.m_dtChargeItem = new DataTable();
            this.m_dtYBChargeItem = new DataTable();
        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYbdeaDefChargeitem)frmMDI_Child_Base_in;
        }
        #endregion

        #region  建医保特种病TreeView视图
        public void GetSpecialDisease()
        {
            string rootId = "root";
            string rootName = "医保特种病";

            //建根节点
            TreeNode tnRoot = new TreeNode(rootName);
            tnRoot.Tag = rootId;
            tnRoot.ImageIndex = 0;
            tnRoot.SelectedImageIndex = 0;
            this.m_objViewer.m_tvDisease.Nodes.Add(tnRoot);

            long lngRes = 0;
            DataTable dtSpecialDisease = new DataTable();
            lngRes = m_objDomain.GetSpecialDisease(out dtSpecialDisease);

            if (lngRes > 0 && dtSpecialDisease.Rows.Count > 0)
            {
                string tnId = "";
                string tnName = "";

                for (int i = 0; i < dtSpecialDisease.Rows.Count; i++)
                {
                    tnId = dtSpecialDisease.Rows[i]["DEACODE_CHR"].ToString();
                    tnName = dtSpecialDisease.Rows[i]["DEADESC_VCHR"].ToString();
                    TreeNode tn = new TreeNode(tnName);
                    tn.Tag = tnId;
                    //tn.ImageIndex = 0;
                    //tn.SelectedImageIndex = 1;
                    tnRoot.Nodes.Add(tn);
                }


                this.m_objViewer.m_tvDisease.ExpandAll();
            }


        }
        #endregion


        #region  取收费项目信息
        public void GetChargeItem()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            
            long lngRes = 0;
            lngRes = m_objDomain.GetChargeItem(out m_dtChargeItem);

            this.m_objViewer.m_dgvAllItem.Rows.Clear();
            if (lngRes > 0 && m_dtChargeItem.Rows.Count > 0)
            {

                DataView dv = new DataView(m_dtChargeItem);
                //dv = m_dtChargeItem.DefaultView;

                foreach (DataRowView drv in dv)
                {
                    string[] s = new string[7];

                    //s[0] = i.ToString();
                    s[0] = drv["ITEMCODE_VCHR"].ToString().Trim();
                    s[1] = drv["ITEMNAME_VCHR"].ToString().Trim();
                    s[2] = drv["ITEMSPEC_VCHR"].ToString().Trim();
                    s[3] = drv["ITEMPRICE_MNY"].ToString().Trim();
                    s[4] = drv["ITEMPYCODE_CHR"].ToString().Trim();
                    s[5] = drv["ITEMWBCODE_CHR"].ToString().Trim();
                    s[6] = drv["ITEMID_CHR"].ToString().Trim();

                    this.m_objViewer.m_dgvAllItem.Rows.Add(s);
                }

                this.m_objViewer.Cursor = Cursors.Default;
            }

        }
        #endregion

        #region  过滤收费项目信息
        public void FilterChargeItem()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;

            string filter;
            filter = this.m_objViewer.m_filterText.Text.ToString().Trim();

            int filterType = -1; 
            filterType = this.m_objViewer.m_cmbFilterType.SelectedIndex;

            if (filterType < 0)
            {
                MessageBox.Show("请选择过滤的方式。");
                this.m_objViewer.m_cmbFilterType.Focus();
                this.m_objViewer.Cursor = Cursors.Default;
                return;
            }

            if (filter != null && filter != "")
            {
                this.m_objViewer.m_dgvAllItem.Rows.Clear();

                DataView dv = new DataView(m_dtChargeItem);
                //dv = m_dtChargeItem.DefaultView;

                string strTemp;
                switch (filterType)
                {
                    case 0:
                        //项目编码
                        strTemp = "ITEMCODE_VCHR like '" + filter + "%'";
                        break;
                    case 1:
                        //项目名称
                        strTemp = "ITEMNAME_VCHR like '%" + filter + "%'";
                        break;
                    case 2:
                        //拼音码
                        strTemp = "ITEMPYCODE_CHR like '" + filter + "%'";
                        break;
                    case 3:
                        //五笔码
                        strTemp = "ITEMWBCODE_CHR like '" + filter + "%'";
                        break;
                    default:
                        strTemp = "";
                        break;
                }

                dv.RowFilter = strTemp;

                foreach (DataRowView drv in dv)
                {
                    string[] s = new string[7];

                    s[0] = drv["ITEMCODE_VCHR"].ToString().Trim();
                    s[1] = drv["ITEMNAME_VCHR"].ToString().Trim();
                    s[2] = drv["ITEMSPEC_VCHR"].ToString().Trim();
                    s[3] = drv["ITEMPRICE_MNY"].ToString().Trim();
                    s[4] = drv["ITEMPYCODE_CHR"].ToString().Trim();
                    s[5] = drv["ITEMWBCODE_CHR"].ToString().Trim();
                    s[6] = drv["ITEMID_CHR"].ToString().Trim();

                    this.m_objViewer.m_dgvAllItem.Rows.Add(s);
                }
             }
                this.m_objViewer.Cursor = Cursors.Default;
            }
        #endregion

        #region  过滤特殊病对应的收费项目信息
        public void FilterYBChargeItem()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;

            string filter;
            filter = this.m_objViewer.m_filterText.Text.ToString().Trim();

            int filterType = -1;
            filterType = this.m_objViewer.m_cmbFilterType.SelectedIndex;

            if (filterType < 0)
            {
                MessageBox.Show("请选择过滤的方式。");
                this.m_objViewer.m_cmbFilterType.Focus();
                return;
            }

            if (filter != null && filter != "")
            {
                this.m_objViewer.m_dgvAccordItem.Rows.Clear();

                DataView dv = new DataView(m_dtYBChargeItem);
                dv = m_dtYBChargeItem.DefaultView;

                string strTemp;
                switch (filterType)
                {
                    case 0:
                        //项目编码
                        strTemp = "ITEMCODE_VCHR like '" + filter + "%'";
                        break;
                    case 1:
                        //项目名称
                        strTemp = "ITEMNAME_VCHR like '%" + filter + "%'";
                        break;
                    case 2:
                        //拼音码
                        strTemp = "ITEMPYCODE_CHR like '" + filter + "%'";
                        break;
                    case 3:
                        //五笔码
                        strTemp = "ITEMWBCODE_CHR like '" + filter + "%'";
                        break;
                    default:
                        strTemp = "";
                        break;
                }

            dv.RowFilter = strTemp;

            foreach (DataRowView drv in dv)
            {
                string[] s = new string[7];

                s[0] = drv["ITEMCODE_VCHR"].ToString().Trim();
                s[1] = drv["ITEMNAME_VCHR"].ToString().Trim();
                s[2] = drv["ITEMSPEC_VCHR"].ToString().Trim();
                s[3] = drv["ITEMPRICE_MNY"].ToString().Trim();
                s[4] = drv["ITEMPYCODE_CHR"].ToString().Trim();
                s[5] = drv["ITEMWBCODE_CHR"].ToString().Trim();
                s[6] = drv["ITEMID_CHR"].ToString().Trim();

                this.m_objViewer.m_dgvAccordItem.Rows.Add(s);
            }
          }
            this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region  重置收费项目信息
        public void ResetChargeItem()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;

            this.m_objViewer.m_dgvAllItem.Rows.Clear();

            DataView dv = new DataView(m_dtChargeItem);
            //dv = m_dtChargeItem.DefaultView;

               
            foreach (DataRowView drv in dv)
            {
                string[] s = new string[7];

                s[0] = drv["ITEMCODE_VCHR"].ToString().Trim();
                s[1] = drv["ITEMNAME_VCHR"].ToString().Trim();
                s[2] = drv["ITEMSPEC_VCHR"].ToString().Trim();
                s[3] = drv["ITEMPRICE_MNY"].ToString().Trim();
                s[4] = drv["ITEMPYCODE_CHR"].ToString().Trim();
                s[5] = drv["ITEMWBCODE_CHR"].ToString().Trim();
                s[6] = drv["ITEMID_CHR"].ToString().Trim();

                this.m_objViewer.m_dgvAllItem.Rows.Add(s);
            }

            this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region  重置特殊病对应的收费项目信息
        public void ResetYBChargeItem()
        {
            this.m_objViewer.Cursor = Cursors.WaitCursor;

            
            this.m_objViewer.m_dgvAccordItem.Rows.Clear();

            DataView dv = new DataView(m_dtYBChargeItem);
            //dv = m_dtYBChargeItem.DefaultView;
            
            foreach (DataRowView drv in dv)
            {
                string[] s = new string[7];

                s[0] = drv["ITEMCODE_VCHR"].ToString().Trim();
                s[1] = drv["ITEMNAME_VCHR"].ToString().Trim();
                s[2] = drv["ITEMSPEC_VCHR"].ToString().Trim();
                s[3] = drv["ITEMPRICE_MNY"].ToString().Trim();
                s[4] = drv["ITEMPYCODE_CHR"].ToString().Trim();
                s[5] = drv["ITEMWBCODE_CHR"].ToString().Trim();
                s[6] = drv["ITEMID_CHR"].ToString().Trim();

                this.m_objViewer.m_dgvAccordItem.Rows.Add(s);
            }

            this.m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region  根据选择疾病码显示对应的收费项目
        public void AfterSelectDisease(string deaCode)
        {
            if (this.m_newArr.Count > 0 || this.m_removeArr.Count > 0)
            {
                if (MessageBox.Show("是否保存您所做的修改? '", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    SaveDeaDefChargeItem();
                }
                else
                {
                    this.m_newArr.Clear();
                    this.m_removeArr.Clear();
                }

            }

            this.m_objViewer.m_dgvAccordItem.Rows.Clear();

            long lngRes = 0;
            lngRes = m_objDomain.GetChargeItemByDeaCode(deaCode, out m_dtYBChargeItem);

            if (m_dtYBChargeItem.Rows.Count > 0)
            {
                DataView dv = new DataView(m_dtYBChargeItem);
                dv = m_dtYBChargeItem.DefaultView;

                foreach (DataRowView drv in dv)
                {
                    string[] s = new string[7];

                    s[0] = drv["ITEMCODE_VCHR"].ToString().Trim();
                    s[1] = drv["ITEMNAME_VCHR"].ToString().Trim();
                    s[2] = drv["ITEMSPEC_VCHR"].ToString().Trim();
                    s[3] = drv["ITEMPRICE_MNY"].ToString().Trim();
                    s[4] = drv["ITEMPYCODE_CHR"].ToString().Trim();
                    s[5] = drv["ITEMWBCODE_CHR"].ToString().Trim();
                    s[6] = drv["ITEMID_CHR"].ToString().Trim();

                    this.m_objViewer.m_dgvAccordItem.Rows.Add(s);
                }
            }

        }
        #endregion

        #region 增加对应收费项目
        public void AddDefChargeItem()
        {
            TreeNode tn = new TreeNode();
            tn = this.m_objViewer.m_tvDisease.SelectedNode;
            if (tn == null)
            {
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }

            string deaCode = tn.Tag.ToString().Trim();

            if (deaCode == "" || deaCode.ToLower() == "root")
            {
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }


            if (this.m_objViewer.m_dgvAllItem.SelectedRows.Count < 1)
            {
                MessageBox.Show("你尚未选择要添加的ICD码", "提示");
                return;
            }

            //判断项目是否已存在
            for (int i1 = 0; i1 < this.m_objViewer.m_dgvAllItem.SelectedRows.Count; i1++)
            {
                for (int i2 = 0; i2 < m_objViewer.m_dgvAccordItem.Rows.Count; i2++)
                {
                    if (this.m_objViewer.m_dgvAccordItem.Rows[i2].Cells["YBItemID"].Value.ToString() == 
                        this.m_objViewer.m_dgvAllItem.SelectedRows[i1].Cells["ItemID"].Value.ToString())
                    {
                        MessageBox.Show("已存在相同的记录", "提示");
                        m_objViewer.m_dgvAccordItem.Rows[i2].Selected = true;
                        return;
                    }
                }

            }
                      
            string itemCode;
            string itemName;
            string itemSpec;
            string itemPrice;
            string itemPYCode;
            string itemWBCode;
            string itemID;
            int iCount = 0;
            //增加项目
            for (int i1 = 0; i1 < this.m_objViewer.m_dgvAllItem.SelectedRows.Count; i1++)
            {
                itemCode = this.m_objViewer.m_dgvAllItem.SelectedRows[i1].Cells["ItemCode"].Value.ToString();
                itemName = this.m_objViewer.m_dgvAllItem.SelectedRows[i1].Cells["ItemName"].Value.ToString();
                itemSpec = this.m_objViewer.m_dgvAllItem.SelectedRows[i1].Cells["ItemSpec"].Value.ToString();
                itemPrice = this.m_objViewer.m_dgvAllItem.SelectedRows[i1].Cells["ItemPrice"].Value.ToString();
                itemPYCode = this.m_objViewer.m_dgvAllItem.SelectedRows[i1].Cells["ItemPYCode"].Value.ToString();
                itemWBCode = this.m_objViewer.m_dgvAllItem.SelectedRows[i1].Cells["ItemWBCode"].Value.ToString();
                itemID = this.m_objViewer.m_dgvAllItem.SelectedRows[i1].Cells["ItemID"].Value.ToString();

                bool ifContains = this.m_newArr.Contains(itemID);
                if (!ifContains)
                {
                    m_newArr.Add(itemID);
                }

                string[] s = new string[7];
                s[0] = itemCode;
                s[1] = itemName;
                s[2] = itemSpec;
                s[3] = itemPrice;
                s[4] = itemPYCode;
                s[5] = itemWBCode;
                s[6] = itemID;

                int addIndex = this.m_objViewer.m_dgvAccordItem.Rows.Add(s);
                this.m_objViewer.m_dgvAccordItem.Rows[addIndex].Selected = true;
                iCount++;
            }
            MessageBox.Show("已增加了 " + iCount.ToString() + " 条记录。", "提示");

        }
        #endregion

        #region 删除对应收费项目
        public void RemoveDefChargeItem()
        {
            TreeNode tn = new TreeNode();
            tn = this.m_objViewer.m_tvDisease.SelectedNode;
            if (tn == null)
            {
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }

            string deaCode = tn.Tag.ToString().Trim();

            if (deaCode == "" || deaCode.ToLower() == "root")
            {
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }


            if (this.m_objViewer.m_dgvAccordItem.SelectedRows.Count < 1)
            {
                MessageBox.Show("你尚未选择要移去的收费项目", "提示");
                return;
            }

            if (MessageBox.Show("您真的要删除选中的医保收费项目吗? '", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            string itemID;
            for (int i1 = 0; i1 < this.m_objViewer.m_dgvAccordItem.SelectedRows.Count; i1++)
            {


                itemID = this.m_objViewer.m_dgvAccordItem.SelectedRows[0].Cells["YBItemID"].Value.ToString(); ;

                bool ifContains = this.m_newArr.Contains(itemID);
                if (ifContains)
                {
                    m_newArr.Remove(itemID);
                }

                
               ifContains = this.m_removeArr.Contains(itemID);
                if (!ifContains)
                {
                    m_removeArr.Add(itemID);
                }

                this.m_objViewer.m_dgvAccordItem.Rows.RemoveAt(this.m_objViewer.m_dgvAccordItem.SelectedRows[i1].Index);
            }
        }
        #endregion

        #region 保存
        public void SaveDeaDefChargeItem()
        {

            TreeNode tn = new TreeNode();
            tn = this.m_objViewer.m_tvDisease.SelectedNode;
            if (tn == null)
            {
                this.m_newArr.Clear();
                this.m_removeArr.Clear();
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }

            string deaCode = tn.Tag.ToString().Trim();

            if (deaCode == "" || deaCode.ToLower() == "root")
            {
                this.m_newArr.Clear();
                this.m_removeArr.Clear();
                MessageBox.Show("你尚未选择医保疾病", "提示");
                return;
            }

            long lngReg = 0;
            lngReg = this.m_objDomain.SaveDeaDefChargeItem(deaCode, this.m_newArr, this.m_removeArr);
            if (lngReg > 0)
            {
                this.m_newArr.Clear();
                this.m_removeArr.Clear();
                MessageBox.Show("保存成功！", "提示");
            }
            else
            {
                this.m_newArr.Clear();
                this.m_removeArr.Clear();
                MessageBox.Show("保存失败", "警告");
            }

        }
        #endregion
    }

}