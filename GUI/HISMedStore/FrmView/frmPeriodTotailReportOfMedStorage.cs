using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Collections;
namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmPeriodTotailReportOfMedStorage : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        public frmPeriodTotailReportOfMedStorage()
        {
            InitializeComponent();
        }

        private void frmPeriodTotailReport_Load(object sender, EventArgs e)
        {
            m_mthGetPeriodList();

            clsMedStore_VO[] objItems = new clsMedStore_VO[0];
            long lngRes = 0;
            clsDomainControlMedStoreBseInfo manage = new clsDomainControlMedStoreBseInfo();
            lngRes =manage.m_lngGetMedStoreList(out objItems);
            if (objItems.Length > 0)
            {
                for (int i1 = 0; i1 < objItems.Length; i1++)
                {
                    exComboBox1.Item.Add(objItems[i1].m_strMedStoreName, objItems[i1].m_strMedStoreID);
                }
            }
            this.exComboBox1.SelectedIndex = 1;
        }
        clsPeriod_VO[] objPriodItems = null;
        #region 获得帐务期列表
        /// <summary>
        /// 获得帐务期列表
        /// </summary>
        private void m_mthGetPeriodList()
        {
            objPriodItems = clsPublicParm.s_GetPeriodList();
            string nowdate = clsPublicParm.s_datGetServerDate().Date.ToString();
            int intSelPeriod = -1;
            if (objPriodItems.Length > 0)
            {
                for (int i1 = 0; i1 < objPriodItems.Length; i1++)
                {
                    this.m_cboSelPeriodBegion.Item.Add(objPriodItems[i1].m_strStartDate + " 至 " + objPriodItems[i1].m_strEndDate, objPriodItems[i1].m_strPeriodID);
                    this.m_cboSelPeriodEnd.Item.Add(objPriodItems[i1].m_strStartDate + " 至 " + objPriodItems[i1].m_strEndDate, objPriodItems[i1].m_strPeriodID);
                    if(Convert.ToDateTime(nowdate)>=Convert.ToDateTime(objPriodItems[i1].m_strStartDate)&&Convert.ToDateTime(nowdate)<=Convert.ToDateTime(objPriodItems[i1].m_strEndDate))
					{
						intSelPeriod = i1;
					}
                }
            }
				if(intSelPeriod!=-1)
				{
                    this.m_cboSelPeriodEnd.SelectedIndex = intSelPeriod;
                    this.m_cboSelPeriodBegion.SelectedIndex = intSelPeriod;
				}
        }
        #endregion

        private void m_btnQuery_Click(object sender, EventArgs e)
        {
            if (int.Parse(this.m_cboSelPeriodBegion.SelectItemValue) > int.Parse(this.m_cboSelPeriodEnd.SelectItemValue))
            {
                MessageBox.Show("开始财务期不能大于结束财务期！");
            }
            else
            {
                ArrayList itemlist = new ArrayList();
                clsDomainControlMedStore domain = new clsDomainControlMedStore();
                for (int i1 = this.m_cboSelPeriodBegion.SelectedIndex; i1 <=this.m_cboSelPeriodEnd.SelectedIndex; i1++)
                {
                    itemlist.Add(objPriodItems[i1].m_strPeriodID);
                }
                DataTable dt = new DataTable();
                domain.m_lngGetReportmoth(itemlist, objPriodItems[this.m_cboSelPeriodBegion.SelectedIndex - 1].m_strPeriodID, out dt,this.exComboBox1.SelectItemValue);
                if (dt.Rows.Count > 0)
                {
                    dw_1.Reset();
                    int newRow;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        newRow = dw_1.InsertRow();
                        dw_1.SetItemString(newRow, "rowname", dt.Rows[i]["rowname"].ToString());
                        if (dt.Rows[i]["westmedsalemoney"] == null || dt.Rows[i]["westmedsalemoney"].ToString() == "")
                        {
                            dt.Rows[i]["westmedsalemoney"] = 0;
                        }
                        dw_1.SetItemDecimal(newRow, "westmedsalemoney", decimal.Parse(dt.Rows[i]["westmedsalemoney"].ToString()));
                        if (dt.Rows[i]["WCsalemoney"] == null || dt.Rows[i]["WCsalemoney"].ToString() == "")
                        {
                            dt.Rows[i]["WCsalemoney"] = 0;
                        }
                        dw_1.SetItemDecimal(newRow, "wcsalemoney", decimal.Parse(dt.Rows[i]["WCsalemoney"].ToString()));
                        if (dt.Rows[i]["chsalemoney"] == null || dt.Rows[i]["chsalemoney"].ToString() == "")
                        {
                            dt.Rows[i]["chsalemoney"] = 0;
                        }
                        dw_1.SetItemDecimal(newRow, "chsalemoney", decimal.Parse(dt.Rows[i]["chsalemoney"].ToString()));
                        if (dt.Rows[i]["totailsalemoney"] == null || dt.Rows[i]["totailsalemoney"].ToString() == "")
                        {
                            dt.Rows[i]["totailsalemoney"] = 0;
                        }
                        dw_1.SetItemDecimal(newRow, "totailsalemoney", decimal.Parse(dt.Rows[i]["totailsalemoney"].ToString()));
                    }
                    dw_1.Modify("t_1.text = '" + this.exComboBox1.SelectItemText + "月结报表'");
                    dw_1.Modify("t_7.text = '财务期：" + this.m_cboSelPeriodBegion.Text +"到"+this.m_cboSelPeriodEnd.Text+ "'");
                    dw_1.CalculateGroups();
                    dw_1.Refresh();
                }
            }
        }

        private void m_btnPrint_Click(object sender, EventArgs e)
        {
            dw_1.Print();
        }

        private void btnesc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cboSelPeriodEnd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void m_cboSelPeriodBegion_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}