using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.common;	//objectGenerator.dll
//using CrystalDecisions.CrystalReports.Engine;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    public class clsCtl_ItemCollect : com.digitalwave.GUI_Base.clsController_Base
    {

        clsDcl_ItemBeFell m_objMain = null;
        public string ITEMID_CHR;
        private DataTable m_dtbTemp;
        string m_strItemCode = string.Empty;
        public clsCtl_ItemCollect()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objMain = new clsDcl_ItemBeFell();
        }
        /// <summary>
        /// 窗体对象
        /// </summary>

        frmItemCollect m_objViewerCollect;


        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);

            m_objViewerCollect = (frmItemCollect)frmMDI_Child_Base_in;
        }

        //取项目列表
        public int m_GetItem()
        {

            DataTable dt = new DataTable();
            //frmItem objItem = new frmItem();
            string strItem = m_objViewerCollect.txt_Item.Text.ToUpper().Trim();
            this.m_objMain.m_GetItem(strItem, out dt);

            if (dt.Rows.Count <= 0)
            {
                MessageBox.Show("抱歉，没有找到对应的项目记录!", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }

            if (dt.Rows.Count == 1)
            {
                //change 2007.5.8 zhu.w.t
                //m_objViewerCollect.txt_Item.Text = dt.Rows[0]["ITEMID_CHR"].ToString().Trim();
                //==================================================================>>
                m_objViewerCollect.txt_Item.Text = dt.Rows[0]["ITEMCODE_VCHR"].ToString().Trim();
                m_objViewerCollect.txt_Item.Tag = dt.Rows[0]["ITEMID_CHR"].ToString().Trim();
                m_strItemCode = dt.Rows[0]["ITEMCODE_VCHR"].ToString().Trim();
                //<<=================================================================
                m_objViewerCollect.labItemName.Text = dt.Rows[0]["ITEMNAME_VCHR"].ToString().Trim();
                return 1;
            }
            else
            {
                frmItem frmItem_view = new frmItem();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow dr = dt.Rows[i];

                    ListViewItem li = new ListViewItem();
                    li.SubItems.Clear();
                    //change 2007.5.8 zhu.w.t
                    //li.SubItems[0].Text = dr["ITEMID_CHR"].ToString();
                    //================================================>>
                    li.SubItems[0].Text = dr["ITEMCODE_VCHR"].ToString();
                    //<<================================================
                    li.SubItems.Add(dr["ITEMNAME_VCHR"].ToString());
                    li.Tag = dr;
                    frmItem_view.m_lsvList.Items.Add(li);
                }

                if (frmItem_view.ShowDialog() == DialogResult.OK)
                {
                    //change 2007.5.8 zhu.w.t
                    //string itemcode = frmItem_view.ItemCode;
                    //=================>>
                    string itemcode = frmItem_view.ItemCode_Vchr;
                    m_objViewerCollect.txt_Item.Tag = frmItem_view.ItemCode;
                    //<<=====================
                    string itemname = frmItem_view.ItemName;
                    m_objViewerCollect.txt_Item.Text = itemcode;
                    m_objViewerCollect.labItemName.Text = itemname;
                    // MessageBox.Show(itemcode + "  " + itemname);
                }
                else
                {
                    m_objViewerCollect.txt_Item.Text = string.Empty;
                    m_objViewerCollect.labItemName.Text = string.Empty;
                }
                frmItem_view.Dispose();
            }

            return 1;

        }
        public int m_GetItemCollect()
        {
            int datTyp;
            DataTable dt;
            dt = null;
            if (m_objViewerCollect.rdbDatType1.Checked)
            {
                datTyp = 1;
                m_objViewerCollect.dataWindowControl1.Modify("t_1.text = '" + m_objComInfo.m_strGetHospitalTitle() + "门诊单项消耗品报表(按发票)'");
            }
            else
            {
                datTyp = 2;
                m_objViewerCollect.dataWindowControl1.Modify("t_1.text = '" + m_objComInfo.m_strGetHospitalTitle() + "门诊单项消耗品报表(按日结)'");
            }

            if ((m_objViewerCollect.txt_Item.Text.Trim().Length == 0) || (m_objViewerCollect.txt_Item.Tag == null))
            {
                if (m_objViewerCollect.txt_Item.Tag == null)
                {
                    MessageBox.Show("请选择收费项目！");
                    m_objViewerCollect.labItemName.Text = string.Empty;
                    m_strItemCode = string.Empty;
                    return -1;
                }
                else
                {
                    m_objViewerCollect.txt_Item.Text = m_strItemCode;
                }
                
            }
            //change 2007.5.8 zhu.w.t
            //this.m_objMain.m_lngGetItemCollect(datTyp, m_objViewerCollect.dtp_star.Value.ToShortDateString() + " 00:00:00",
            //        m_objViewerCollect.dtp_end.Value.ToShortDateString() + " 23:59:59", m_objViewerCollect.txt_Item.Text, out dt);
            //=========================>>

            DataTable dtbStat = null;
            DataRow drCurrRow = null;
            DataRow drNewRow = null;

            long lngRes = 0;
            try
            {
                clsPublic.PlayAvi("findFILE.avi", "正在查询数据，请稍候...");
                for (int i1 = 1; i1 < 7; i1++)
                {
                    dt = null;
                    lngRes = this.m_objMain.m_lngGetItemCollect(datTyp,i1, m_objViewerCollect.dtp_star.Value.ToShortDateString() + " 00:00:00",
                            m_objViewerCollect.dtp_end.Value.ToShortDateString() + " 23:59:59", m_objViewerCollect.txt_Item.Tag.ToString(), out dt);
                    if (lngRes > 0)
                    {
                        if (i1 == 1)
                        {
                            dtbStat = dt.Copy();
                        }
                        else
                        {
                            if (dt.Rows.Count > 0)
                            {
                                for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
                                {
                                    drNewRow = dtbStat.NewRow();
                                    drCurrRow = dt.Rows[iRow];
                                    drNewRow["deptname_chr"] = drCurrRow["deptname_chr"];
                                    drNewRow["status_int"] = drCurrRow["status_int"];
                                    drNewRow["qty_dec"] = drCurrRow["qty_dec"];
                                    drNewRow["tolprice_mny"] = drCurrRow["tolprice_mny"];
                                    dtbStat.Rows.Add(drNewRow);
                                }
                                dtbStat.AcceptChanges();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("获取数据时出错！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return -1;
                    }
                }//for
            }
            finally
            {
                clsPublic.CloseAvi();
            }

            if (dtbStat != null)
            {
                if (dtbStat.Rows.Count == 0)
                {
                    MessageBox.Show("没有该项目的统计信息!", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return -1;
                }
                else
                {
                    try
                    {
                        clsPublic.PlayAvi("findFILE.avi", "正在统计数据，请稍候...");
                        m_mthStatDataTransact(ref dtbStat);
                    }
                    finally
                    {
                        clsPublic.CloseAvi();

                    }

                    m_objViewerCollect.dataWindowControl1.Modify("t_dat.text= '" +
                             m_objViewerCollect.dtp_star.Value.ToShortDateString() +
                            " ~ " + m_objViewerCollect.dtp_end.Value.ToShortDateString() + "'");
                    m_objViewerCollect.dataWindowControl1.Modify("t_itemname.text= '" + m_objViewerCollect.labItemName.Text + "'");
                    m_objViewerCollect.dataWindowControl1.Modify("t_itemid.text= '" + m_objViewerCollect.txt_Item.Text + "'");

                    
                    m_objViewerCollect.dataWindowControl1.SetRedrawOff();                    
                    m_objViewerCollect.dataWindowControl1.Retrieve(dtbStat);
                    m_objViewerCollect.dataWindowControl1.Sort();
                    m_objViewerCollect.dataWindowControl1.CalculateGroups();
                    m_objViewerCollect.dataWindowControl1.SetRedrawOn();
                    m_objViewerCollect.dataWindowControl1.Refresh();

                    return 1;
                }
            }//if
            else
            {
                MessageBox.Show("没有该项目的统计信息!", "提示 ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return -1;
            }
        }

        private void m_mthStatDataTransact(ref DataTable p_dtbStat)
        {
            DataRow[] drSelArr = null;
            DataRow drCurr = null;
            decimal decAmount = 0;
            decimal decTotalPrice = 0;
            drSelArr = p_dtbStat.Select("status_int = 2");
            for (int iRow = 0; iRow < drSelArr.Length; iRow++)
            {
                drCurr = drSelArr[iRow];
                decimal.TryParse(drCurr["qty_dec"].ToString(), out decAmount);
                drCurr["qty_dec"] = -decAmount;
                decimal.TryParse(drCurr["tolprice_mny"].ToString(), out decTotalPrice);
                drCurr["tolprice_mny"] = -decTotalPrice;

            }//for
            p_dtbStat.Columns.Remove("status_int");
            p_dtbStat.AcceptChanges();
        }

    }
}
