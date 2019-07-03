using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Sybase.DataWindow;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_Shiyingsetting : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsCtl_Shiyingsetting()
        {
            m_objDomain = new clsDcl_Report();
        }
        /// <summary>
        /// Domain类
        /// </summary>
        private clsDcl_Report m_objDomain;
        /// <summary>
        /// GUI对象
        /// </summary>
        com.digitalwave.iCare.gui.HIS.frmShiying m_objViewer;

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmShiying)frmMDI_Child_Base_in;
        }
        #endregion


        public void m_mthQuery()
        {
            long lngRes = 0;
            DataTable dtResult = new DataTable();
            DataRow dr = null;
            int Row = 0;
            lngRes = this.m_objDomain.m_lngGetShiying(this.m_objViewer.txtQuery.Text.Trim(), out dtResult);
            if (lngRes > 0 && dtResult != null)
            {
                Row = dtResult.Rows.Count;
            }
            this.m_objViewer.listView1.Items.Clear();
            for (int i = 0; i < Row; i++)
            {
                dr = dtResult.Rows[i];
                ListViewItem lvi = new ListViewItem(dr["hisitemcode_vchr"].ToString());
                lvi.SubItems.Add(dr["ybitemcode_vchr"].ToString());
                lvi.SubItems.Add(dr["itemtype"].ToString());
                lvi.SubItems.Add(dr["itemname_vchr"].ToString());
                lvi.SubItems.Add(dr["englishname_vchr"].ToString());
                lvi.SubItems.Add(dr["itemjixingtype_vchr"].ToString());
                lvi.SubItems.Add(dr["xzsyzbz"].ToString());
                lvi.SubItems.Add(dr["xzsysm"].ToString());
                lvi.SubItems.Add(dr["yxbz"].ToString());
                lvi.Tag = dr;
                this.m_objViewer.listView1.Items.Add(lvi);
            }
           
            
        }


        public void m_mthSelectedIndex()
        {
            if (this.m_objViewer.listView1.SelectedItems.Count <= 0)
            {
                return;
            }
            this.m_objViewer.txtHosCode.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[0].Text.ToString();
            this.m_objViewer.txtYbCode.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[1].Text.ToString();
            this.m_objViewer.txtItemType.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[2].Text.ToString();
            this.m_objViewer.txtName.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[3].Text.ToString();
            this.m_objViewer.txtNameEG.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[4].Text.ToString();
            this.m_objViewer.txtJixing.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[5].Text.ToString();
            this.m_objViewer.txtXzsybz.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[6].Text.ToString();
            this.m_objViewer.txtXzsysm.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[7].Text.ToString();
            this.m_objViewer.txtYxbz.Text = this.m_objViewer.listView1.SelectedItems[0].SubItems[8].Text.ToString();
            this.m_objViewer.btnSave.Tag = this.m_objViewer.txtHosCode.Text.Trim();
        }


        public void m_mthEmpty()
        {
            this.m_objViewer.txtHosCode.Text = "";
            this.m_objViewer.txtYbCode.Text = "";
            this.m_objViewer.txtItemType.Text = "";
            this.m_objViewer.txtName.Text = "";
            this.m_objViewer.txtNameEG.Text = "";
            this.m_objViewer.txtJixing.Text = "";
            this.m_objViewer.txtXzsybz.Text = "";
            this.m_objViewer.txtXzsysm.Text = "";
            this.m_objViewer.txtYxbz.Text = "";
        }

        public void m_mthSave()
        {
            clsShiyingVO objVO = null;
            m_mthBuildVO(out objVO);
            if (objVO == null || objVO.HosCode == "")
            {
                return;
            }
            long lngRes = this.m_objDomain.m_lngSaveShiying(objVO);
            if (lngRes > 0)
            {
                this.m_objViewer.listView1.Items.Clear();
                ListViewItem lvi = new ListViewItem(objVO.HosCode);
                lvi.SubItems.Add(objVO.ybitemcode);
                lvi.SubItems.Add(objVO.itemtype);
                lvi.SubItems.Add(objVO.itemname);
                lvi.SubItems.Add(objVO.englishname);
                lvi.SubItems.Add(objVO.itemjixingtype);
                lvi.SubItems.Add(objVO.xzsyzbz);
                lvi.SubItems.Add(objVO.xzsysm);
                lvi.SubItems.Add(objVO.yxbz);
                lvi.Tag = objVO;
                this.m_objViewer.listView1.Items.Add(lvi);
                m_mthEmpty();
                MessageBox.Show("保存成功！");
            }
            
        }

        public void m_mthDelete()
        {
            clsShiyingVO objVO = null;
            if(this.m_objViewer.listView1.SelectedItems.Count <= 0)
            {
                MessageBox.Show("请选择要删除的项！");
            }
            m_mthBuildVO(out objVO);
            if (objVO == null || objVO.HosCode == "")
            {
                return;
            }
            long lngRes = this.m_objDomain.m_lngDelShiying(objVO);
            if (lngRes > 0)
            {
                m_mthEmpty();
                this.m_objViewer.listView1.Items.Remove(this.m_objViewer.listView1.SelectedItems[0]);
                MessageBox.Show("删除成功！");
            }
        }

        public void m_mthBuildVO(out clsShiyingVO objVO)
        {
            objVO = new clsShiyingVO();
            objVO.HosCode = this.m_objViewer.txtHosCode.Text.Trim();
            objVO.ybitemcode = this.m_objViewer.txtYbCode.Text.Trim();
            objVO.itemtype = this.m_objViewer.txtItemType.Text.Trim();
            objVO.itemname = this.m_objViewer.txtName.Text.Trim();
            objVO.englishname = this.m_objViewer.txtNameEG.Text.Trim();
            objVO.itemjixingtype = this.m_objViewer.txtJixing.Text.Trim();
            objVO.xzsyzbz = this.m_objViewer.txtXzsybz.Text.Trim();
            objVO.xzsysm = this.m_objViewer.txtXzsysm.Text.Trim();
            objVO.yxbz = this.m_objViewer.txtYxbz.Text.Trim();
        }
    }
}
