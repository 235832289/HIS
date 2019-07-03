using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.GUI_Base;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;


namespace com.digitalwave.iCare.gui.HIS
{　　
　　 
    /// <summary>
    /// 中心药房对应病区界面维护控制类
    /// </summary>
    public class clsControllMedStoreAreaRelation:com.digitalwave.GUI_Base.clsController_Base
    {
        #region 设置窗体对象
        private frmMedStoreAreaRelation m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmMedStoreAreaRelation)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 构造函数
        /// </summary>
        public clsControllMedStoreAreaRelation()
        {
            m_objDomain = new clsDomainControlMedStoreBseInfo();
        }
        clsDomainControlMedStoreBseInfo m_objDomain;
        /// <summary>
        /// 载入数据
        /// </summary>
        public void m_mthLoadData()
        {
            m_mthFillListViewAllAreas();
            m_mthFillMedStoreType();

        }
        /// <summary>
        /// 填充全部病区信息
        /// </summary>
        public void m_mthFillListViewAllAreas()
        {  
            DataTable m_objTable;
            long lngRes = -1;
            lngRes = m_objDomain.m_lngGetAreaInformation(out m_objTable);
            if (lngRes > 0 && m_objTable.Rows.Count > 0)
            {
                this.m_objViewer.m_lsvAllAreas.Items.Clear();
                for (int i = 0; i < m_objTable.Rows.Count; i++)
                {
                    ListViewItem m_objItem = new ListViewItem(m_objTable.Rows[i][0].ToString());
                    m_objItem.SubItems.Add(m_objTable.Rows[i][1].ToString());
                    m_objItem.SubItems.Add(string.Empty);
                    this.m_objViewer.m_lsvAllAreas.Items.Add(m_objItem);
                }
            }
            if (this.m_objViewer.m_lsvAllAreas.Items.Count > 0)
            {
                this.m_objViewer.m_lsvAllAreas.Items[0].Selected = true;
            }
            
        }
        /// <summary>
        /// 填充药房信息
        /// </summary>
        public void m_mthFillMedStoreType()
        {
            DataTable m_objTable;
            long lngRes = -1;
            lngRes = m_objDomain.m_lngGetMedStoreInfoByMedStoreType(out m_objTable);
            if (lngRes > 0 && m_objTable.Rows.Count > 0)
            {
                this.m_objViewer.cboMedStoreType.Items.Clear();
                for (int i = 0; i < m_objTable.Rows.Count; i++)
                {
                    this.m_objViewer.cboMedStoreType.Item.Add(m_objTable.Rows[i][1].ToString(), m_objTable.Rows[i][0].ToString());
                }
                this.m_objViewer.cboMedStoreType.SelectedIndex = 0;
            }
        }
        ///<summary>
        ///添加病区
        ///</summary>
        public void m_mthAddArea()
        {
            if (this.m_objViewer.m_lsvAllAreas.SelectedItems.Count > 0)
            {
                for (int i = 0; i < this.m_objViewer.m_lsvCurrentArea.Items.Count; i++)
                {
                    if (this.m_objViewer.m_lsvAllAreas.SelectedItems[0].Text.Trim() == this.m_objViewer.m_lsvCurrentArea.Items[i].Text.Trim())
                    {
                        MessageBox.Show("该中心药方已经存在着这个病区！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                clsMedStoreVsArea m_objVo = new clsMedStoreVsArea();
                m_objVo.m_datCreateTime=DateTime.Now;
                int m_intCount = this.m_objViewer.m_lsvCurrentArea.Items.Count;
                if (m_intCount > 0)
                {
                    m_objVo.m_intORDER_INT = int.Parse(this.m_objViewer.m_lsvCurrentArea.Items[m_intCount - 1].SubItems[2].Text.ToString()) + 1;
                }
                else
                {
                    m_objVo.m_intORDER_INT = 1;
                }
                m_objVo.m_intStatusINT = 1;
                m_objVo.m_strAREAID_CHR = this.m_objViewer.m_lsvAllAreas.SelectedItems[0].Text.Trim();
                m_objVo.m_strMEDSTOREID_CHR = this.m_objViewer.cboMedStoreType.SelectItemValue;
                m_objVo.m_strCreateID = this.m_objViewer.LoginInfo.m_strEmpID;
                long lngRes = -1;
                lngRes = m_objDomain.m_lngInsertMedStoreAreaRelation(m_objVo);
                if (lngRes > 0)
                {

                    ListViewItem m_objItem = (ListViewItem)this.m_objViewer.m_lsvAllAreas.SelectedItems[0].Clone();
                    m_objItem.Text = this.m_objViewer.m_lsvAllAreas.SelectedItems[0].Text;
                    m_objItem.SubItems[1].Text = this.m_objViewer.m_lsvAllAreas.SelectedItems[0].SubItems[1].Text;
                    m_objItem.SubItems[2].Text = m_objVo.m_intORDER_INT.ToString();
                    this.m_objViewer.m_lsvCurrentArea.Items.Add(m_objItem);
                    this.m_objViewer.m_lsvCurrentArea.Items[m_intCount].Selected = true;
                }


            }
            else
            {
                MessageBox.Show("请先选择病区！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                this.m_objViewer.m_lsvAllAreas.Items[0].Selected = true;
                return;
            }
        }
        ///<summary>
        ///删除病区
        ///</summary>
        public void m_mthRemoveArea()
        {
            if (this.m_objViewer.m_lsvCurrentArea.SelectedItems.Count > 0)
            {
                clsMedStoreVsArea m_objVO = new clsMedStoreVsArea();
                m_objVO.m_strMEDSTOREID_CHR= this.m_objViewer.cboMedStoreType.SelectItemValue;
                m_objVO.m_strAREAID_CHR = this.m_objViewer.m_lsvCurrentArea.SelectedItems[0].Text.Trim();
                m_objVO.m_strCANCELERID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
                m_objVO.m_datCANCEL_DAT = DateTime.Now;
                m_objVO.m_intStatusINT = 0;
                long lngRes = -1;
                lngRes = m_objDomain.m_lngUpdateMedStoreVsAreaInfo(m_objVO);
                if (lngRes > 0)
                {
                    this.m_objViewer.m_lsvCurrentArea.SelectedItems[0].Remove();
                    if (this.m_objViewer.m_lsvCurrentArea.Items.Count > 0)
                    {
                        this.m_objViewer.m_lsvCurrentArea.Items[0].Selected = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("请先选择病区！", "iCare系统温馨提示:", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
                if (this.m_objViewer.m_lsvCurrentArea.Items.Count > 0)
                {
                    this.m_objViewer.m_lsvCurrentArea.Items[0].Selected = true;
                }
                return;
            }
        }
        ///<summary>
        ///根据药房查询相应的病区
        ///</summary>
        public void m_mthMedStorChange()
        {
            if (this.m_objViewer.cboMedStoreType.Items.Count > 0)
            {
                long lngRes = -1;
                DataTable m_objTable;
                string m_strMedStoreID=this.m_objViewer.cboMedStoreType.SelectItemValue;
                lngRes = this.m_objDomain.m_lngGetAreaInformationByMedStoreID(m_strMedStoreID, out m_objTable);
                if (lngRes > 0)
                {
                    this.m_objViewer.m_lsvCurrentArea.Items.Clear();
                    if (m_objTable.Rows.Count > 0)
                    {
                        this.m_objViewer.m_lsvCurrentArea.Items.Clear();
                        for (int i = 0; i < m_objTable.Rows.Count; i++)
                        {
                            ListViewItem m_objitem = new ListViewItem(m_objTable.Rows[i][0].ToString().Trim());
                            m_objitem.SubItems.Add(m_objTable.Rows[i][1].ToString().Trim());
                            m_objitem.SubItems.Add(m_objTable.Rows[i][2].ToString().Trim());
                            this.m_objViewer.m_lsvCurrentArea.Items.Add(m_objitem);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 保存病区顺序号
        /// </summary>
        /// <returns></returns>
        public long m_mthSaveOrderOfTable()
        {
            long lngRes = -1;
            clsMedStoreVsArea[] m_objVOArr;
            m_objVOArr = new clsMedStoreVsArea[this.m_objViewer.m_lsvCurrentArea.Items.Count];
            for (int i = 0; i < this.m_objViewer.m_lsvCurrentArea.Items.Count; i++)
            {
                m_objVOArr[i] = new clsMedStoreVsArea();
                m_objVOArr[i].m_strMEDSTOREID_CHR = this.m_objViewer.cboMedStoreType.SelectItemValue;
                m_objVOArr[i].m_strAREAID_CHR = this.m_objViewer.m_lsvCurrentArea.Items[i].Text;
                m_objVOArr[i].m_intORDER_INT = int.Parse(this.m_objViewer.m_lsvCurrentArea.Items[i].SubItems[2].Text);
            }
            lngRes = m_objDomain.m_lngUpdateOrderOfTable(m_objVOArr);
            return lngRes;

        }
    }
}
