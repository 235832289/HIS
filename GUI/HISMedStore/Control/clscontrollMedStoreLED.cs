using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	
using com.digitalwave.iCare.ValueObject;
using System.Collections;
using com.digitalwave.iCare.gui.HIS;
using System.Xml;
using System.IO;
using System.Drawing.Printing;
using com.digitalwave.iCare.middletier.HI;
using LEDInterface.LianCheng;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{　　

    /// <summary>
    /// 药房同步屏控制层
    /// </summary>
    public class clscontrollMedStoreLED : com.digitalwave.GUI_Base.clsController_Base
    {　　
        /// <summary>
        /// 构造函数
        /// </summary>
        public clscontrollMedStoreLED()
        {
            m_objDomain = new clsDomainControlMedStoreBseInfo();
        }
        private clsDomainControlMedStoreBseInfo m_objDomain;
        private frmMedStoreLED m_objViewer;
        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmMedStoreLED)frmMDI_Child_Base_in;
        }
        #endregion
        /// <summary>
        /// 获取窗口基本信息
        /// </summary>
        public void m_mthGetWindowInfoTable()
        {
            DataTable m_objWindowinfo = new DataTable();
            DataColumn m_objDataColumn;
            m_objDomain.m_lngGetWindowInfoByMedstoreid(this.m_objViewer.MedStoreID, out m_objWindowinfo);
            if (m_objWindowinfo != null && m_objWindowinfo.Rows.Count > 0)
            {
                for (int i = 0; i < this.m_objViewer.m_objWindowIDList.Count; i++)
                {
                    for (int j = 0; j < m_objWindowinfo.Rows.Count; j++)
                    {
                        if (this.m_objViewer.m_objWindowIDList[i].m_strWindowID.Trim() == m_objWindowinfo.Rows[j]["WINDOWID_CHR"].ToString().Trim())
                        {
                            this.m_objViewer.m_objWindowIDList[i].m_strWindowName = m_objWindowinfo.Rows[j]["WINDOWNAME_VCHR"].ToString().Trim();
                        }
                    }
                }
                for (int i = 0; i < this.m_objViewer.m_objSendWinIDList.Count; i++)
                {
                    for (int j = 0; j < m_objWindowinfo.Rows.Count; j++)
                    {
                        if (this.m_objViewer.m_objSendWinIDList[i].m_strWindowID.Trim() == m_objWindowinfo.Rows[j]["WINDOWID_CHR"].ToString().Trim())
                        {
                            this.m_objViewer.m_objSendWinIDList[i].m_strWindowName = m_objWindowinfo.Rows[j]["WINDOWNAME_VCHR"].ToString().Trim();
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 保存发药窗口队列
        /// </summary>
        public DataTable m_dtSendWindow = new DataTable();
        /// <summary>
        /// 保存配药窗口队列
        /// </summary>
        public DataTable m_dtWindow = new DataTable();
        /// <summary>
        /// 设置数据源
        /// </summary>
        public void m_mthSetDataSource()
        {
            long lngRes = this.m_objDomain.m_lngGetDataByMedStoreID(this.m_objViewer.MedStoreID, DateTime.Now.ToString("yyyy-MM-dd"), ref this.m_objViewer.m_objWindowIDList, ref this.m_objViewer.m_objSendWinIDList);
            if (lngRes > 0)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        if (this.m_objViewer.m_objSendWinIDList.Count > 0 && this.m_objViewer.m_objSendWinIDList[0] != null)
                        {
                            this.m_objViewer.label1.Text = this.m_objViewer.m_objSendWinIDList[0].m_strWindowName;
                            this.m_objViewer.dataGridView1.DataSource = this.m_objViewer.m_objSendWinIDList[0].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label1.Text = string.Empty;
                        }
                        if (this.m_objViewer.m_objWindowIDList.Count > 0 && this.m_objViewer.m_objWindowIDList[0] != null)
                        {
                            this.m_objViewer.label6.Text = this.m_objViewer.m_objWindowIDList[0].m_strWindowName;
                            this.m_objViewer.dataGridView6.DataSource = this.m_objViewer.m_objWindowIDList[0].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label6.Text = string.Empty;
                        }
                    }
                    if (i == 1)
                    {
                        if (this.m_objViewer.m_objSendWinIDList.Count > 1 && this.m_objViewer.m_objSendWinIDList[1] != null)
                        {
                            this.m_objViewer.label2.Text = this.m_objViewer.m_objSendWinIDList[1].m_strWindowName;
                            this.m_objViewer.dataGridView2.DataSource = this.m_objViewer.m_objSendWinIDList[1].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label2.Text = string.Empty;
                        }
                        if (this.m_objViewer.m_objWindowIDList.Count > 1 && this.m_objViewer.m_objWindowIDList[1] != null)
                        {
                            this.m_objViewer.label7.Text = this.m_objViewer.m_objWindowIDList[1].m_strWindowName;
                            this.m_objViewer.dataGridView7.DataSource = this.m_objViewer.m_objWindowIDList[1].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label7.Text = string.Empty;
                        }
                    }
                    if (i == 2)
                    {
                        if (this.m_objViewer.m_objSendWinIDList.Count > 2 && this.m_objViewer.m_objSendWinIDList[2] != null)
                        {
                            this.m_objViewer.label3.Text = this.m_objViewer.m_objSendWinIDList[2].m_strWindowName;
                            this.m_objViewer.dataGridView3.DataSource = this.m_objViewer.m_objSendWinIDList[2].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label3.Text = string.Empty;
                        }
                        if (this.m_objViewer.m_objWindowIDList.Count > 2 && this.m_objViewer.m_objWindowIDList[2] != null)
                        {
                            this.m_objViewer.label8.Text = this.m_objViewer.m_objWindowIDList[2].m_strWindowName;
                            this.m_objViewer.dataGridView8.DataSource = this.m_objViewer.m_objWindowIDList[2].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label8.Text = string.Empty;
                        }
                    }
                    if (i == 3)
                    {
                        if (this.m_objViewer.m_objSendWinIDList.Count>3&&this.m_objViewer.m_objSendWinIDList[3] != null)
                        {
                            this.m_objViewer.label4.Text = this.m_objViewer.m_objSendWinIDList[3].m_strWindowName;
                            this.m_objViewer.dataGridView4.DataSource = this.m_objViewer.m_objSendWinIDList[3].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label4.Text = string.Empty;
                        }
                        if (this.m_objViewer.m_objWindowIDList.Count > 3 && this.m_objViewer.m_objWindowIDList[3] != null)
                        {
                            this.m_objViewer.label9.Text = this.m_objViewer.m_objWindowIDList[3].m_strWindowName;
                            this.m_objViewer.dataGridView9.DataSource = this.m_objViewer.m_objWindowIDList[3].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label9.Text = string.Empty;
                        }
                    }
                    if (i == 4)
                    {
                        if (this.m_objViewer.m_objSendWinIDList.Count > 4 && this.m_objViewer.m_objSendWinIDList[4] != null)
                        {
                            this.m_objViewer.label5.Text = this.m_objViewer.m_objSendWinIDList[4].m_strWindowName;
                            this.m_objViewer.dataGridView5.DataSource = this.m_objViewer.m_objSendWinIDList[4].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label5.Text = string.Empty;
                        }
                        if (this.m_objViewer.m_objWindowIDList.Count>4&&this.m_objViewer.m_objWindowIDList[4] != null)
                        {
                            this.m_objViewer.label10.Text = this.m_objViewer.m_objWindowIDList[4].m_strWindowName;
                            this.m_objViewer.dataGridView10.DataSource = this.m_objViewer.m_objWindowIDList[4].m_dtTable;
                        }
                        else
                        {
                            this.m_objViewer.label10.Text = string.Empty;
                        }
                    }
                }
                //this.m_objViewer.dataGridView3.DataSource = this.m_objViewer.m_objSendWinIDList[0].m_dtTable;
                //this.m_objViewer.label1.Text = this.m_objViewer.m_objSendWinIDList[0].m_strWindowName;
                //this.m_objViewer.dataGridView4.DataSource = this.m_objViewer.m_objSendWinIDList[1].m_dtTable;
                //this.m_objViewer.label2.Text = this.m_objViewer.m_objSendWinIDList[1].m_strWindowName;
                //this.m_objViewer.dataGridView5.DataSource = this.m_objViewer.m_objSendWinIDList[2].m_dtTable;
                //this.m_objViewer.label3.Text = this.m_objViewer.m_objSendWinIDList[2].m_strWindowName;

                //this.m_objViewer.dataGridView8.DataSource = this.m_objViewer.m_objWindowIDList[0].m_dtTable;
                //this.m_objViewer.label6.Text = this.m_objViewer.m_objWindowIDList[0].m_strWindowName;
                //this.m_objViewer.dataGridView9.DataSource = this.m_objViewer.m_objWindowIDList[1].m_dtTable;
                //this.m_objViewer.label7.Text = this.m_objViewer.m_objWindowIDList[1].m_strWindowName;
                //this.m_objViewer.dataGridView10.DataSource = this.m_objViewer.m_objWindowIDList[2].m_dtTable;
                //this.m_objViewer.label8.Text = this.m_objViewer.m_objWindowIDList[2].m_strWindowName;
                this.m_objViewer.label1.Focus();
            }
        }
    }
}
