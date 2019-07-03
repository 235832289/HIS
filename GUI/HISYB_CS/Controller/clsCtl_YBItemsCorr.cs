using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_YBItemsCorr : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmItemsCorr m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmItemsCorr)frmMDI_Child_Base_in;
        }
        #endregion
        public static string XMLFile = Application.StartupPath + @"\HISYB.xml";
        public clsCtl_YBItemsCorr()
        {
            objDomain = new clsDcl_YB();
        }
        public clsDcl_YB objDomain = null;

        #region 展示数据
        /// <summary>
        /// 展示数据
        /// </summary>
        public void m_mthDisplayItmes()
        {
            int intType = 0;
            this.m_objViewer.lstHospital.Items.Clear();
            this.m_objViewer.lstYBItems.Items.Clear();
            this.m_objViewer.lstItemsCorr.Items.Clear();
            if (this.m_objViewer.cboType.SelectedIndex == 0)
            {
                intType = 1;
                m_mthLoadYB("InsDept");
            }
            if (this.m_objViewer.cboType.SelectedIndex == 1)
            {
                intType = 2;
                m_mthLoadYB("PayType");
            }
            DataTable dtHosp = null;
            DataTable dtYBHospCorr = null;
            long lngRes = this.objDomain.m_lngGetHosYBData(intType, out dtHosp, out dtYBHospCorr);
            if (lngRes > 0)
            {
                ListViewItem lstit = null;
                bool blnExists = false;
                if (dtHosp != null && dtHosp.Rows.Count > 0)
                {
                    for (int i = 0; i < dtHosp.Rows.Count; i++)
                    {
                        blnExists = false;
                        if (dtYBHospCorr != null && dtYBHospCorr.Rows.Count > 0)
                        {
                            for (int j = 0; j < dtYBHospCorr.Rows.Count; j++)
                            {
                                if (dtHosp.Rows[i]["id"].ToString() == dtYBHospCorr.Rows[j]["HOSDEPTID_VCHR"].ToString())
                                {
                                    blnExists = true;
                                }
                            }
                        }
                        if (!blnExists)
                        {
                            lstit = new ListViewItem();
                            lstit.SubItems.Add(dtHosp.Rows[i]["id"].ToString());
                            lstit.SubItems.Add(dtHosp.Rows[i]["name"].ToString());
                            this.m_objViewer.lstHospital.Items.Add(lstit);
                        }
                    }
                }
                if (dtYBHospCorr != null && dtYBHospCorr.Rows.Count > 0)
                {
                    for (int i = 0; i < dtYBHospCorr.Rows.Count; i++)
                    {
                        lstit = new ListViewItem();
                        lstit.SubItems.Add(dtYBHospCorr.Rows[i]["HOSDEPTID_VCHR"].ToString());
                        lstit.SubItems.Add(dtYBHospCorr.Rows[i]["HOSDEPTNAME_VCHR"].ToString());
                        lstit.SubItems.Add(dtYBHospCorr.Rows[i]["INSDEPTCODE_VCHR"].ToString());
                        lstit.SubItems.Add(dtYBHospCorr.Rows[i]["INSDEPTNAME_VCHR"].ToString());
                        this.m_objViewer.lstItemsCorr.Items.Add(lstit);
                    }
                }
            }
        }
        #endregion

        #region 加载社保信息
        /// <summary>
        /// 加载社保信息
        /// </summary>
        public void m_mthLoadYB(string parentnode)
        {
            string strRet = "";
            try
            {
                if (File.Exists(XMLFile))
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(XMLFile);
                    ListViewItem item = null;
                    XmlNode xndP = xdoc.DocumentElement.SelectSingleNode(@"//" + parentnode);
                    if (xndP.ChildNodes.Count > 0)
                    {
                        for (int i = 0; i < xndP.ChildNodes.Count; i++)
                        {
                            item = new ListViewItem();
                            item.SubItems.Add(xndP.ChildNodes[i].Attributes["key"].Value.ToString());
                            item.SubItems.Add(xndP.ChildNodes[i].Attributes["value"].Value.ToString());
                            this.m_objViewer.lstYBItems.Items.Add(item);
                        }
                    }
                }
            }
            catch(Exception objEx)
            {
                MessageBox.Show(objEx.Message);
            }
        }
        #endregion

        #region 保存数据
        /// <summary>
        /// 保存数据
        /// </summary>
        public void m_mthSaveData()
        {
            int intType = 0;
            string strHospID = string.Empty;
            string strHospNmae = string.Empty;
            string strYBID = string.Empty;
            string strYBName = string.Empty;
            if (this.m_objViewer.cboType.SelectedIndex == 0)
            {
                intType = 1;
            }
            if (this.m_objViewer.cboType.SelectedIndex == 1)
            {
                intType = 2;
            }
            if (this.m_objViewer.lstHospital.SelectedItems.Count > 0 && this.m_objViewer.lstYBItems.SelectedItems.Count > 0)
            {
                strHospID = this.m_objViewer.lstHospital.SelectedItems[0].SubItems[1].Text.ToString();
                strHospNmae = this.m_objViewer.lstHospital.SelectedItems[0].SubItems[2].Text.ToString();
                strYBID = this.m_objViewer.lstYBItems.SelectedItems[0].SubItems[1].Text.ToString();
                strYBName = this.m_objViewer.lstYBItems.SelectedItems[0].SubItems[2].Text.ToString();
                long  lngRes = this.objDomain.m_lngSaveData(intType, strHospID, strHospNmae, strYBID, strYBName);
                if (lngRes > 0)
                {
                    this.m_objViewer.lstHospital.Items.RemoveAt(this.m_objViewer.lstHospital.SelectedItems[0].Index);
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(strHospID);
                    item.SubItems.Add(strHospNmae);
                    item.SubItems.Add(strYBID);
                    item.SubItems.Add(strYBName);
                    this.m_objViewer.lstItemsCorr.Items.Add(item);
                    this.m_objViewer.lstHospital.FocusedItem.Selected = false;
                    this.m_objViewer.lstYBItems.FocusedItem.Selected = false;
                }
            }
            else
            {
                MessageBox.Show("请选择对应的项目！", "提示");
                return;
            }

        }
        #endregion

        #region 删除数据
        /// <summary>
        /// 删除数据
        /// </summary>
        public void m_mthDelData()
        {
            int intType = 0;
            if( this.m_objViewer.cboType.SelectedIndex == 0)
            {
                intType = 1;
            }
            if(this.m_objViewer.cboType.SelectedIndex ==1)
            {
                intType =2;
            }
            if (this.m_objViewer.lstItemsCorr.SelectedItems.Count > 0)
            {
                string strHospID = this.m_objViewer.lstItemsCorr.SelectedItems[0].SubItems[1].Text.ToString();
                string strYBID = this.m_objViewer.lstItemsCorr.SelectedItems[0].SubItems[3].Text.ToString();
                string strHospName = this.m_objViewer.lstItemsCorr.SelectedItems[0].SubItems[2].Text.ToString();
                long lngRes = this.objDomain.m_lngDelData(strHospID, strYBID, intType);
                if (lngRes > 0)
                {
                    this.m_objViewer.lstItemsCorr.Items.RemoveAt(this.m_objViewer.lstItemsCorr.SelectedItems[0].Index);
                    ListViewItem item = new ListViewItem();
                    item.SubItems.Add(strHospID);
                    item.SubItems.Add(strHospName);
                    this.m_objViewer.lstHospital.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("请选择要删除的项目！", "提示");
            }
        }
        #endregion
    }
}
