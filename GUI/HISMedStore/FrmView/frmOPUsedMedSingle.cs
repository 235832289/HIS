using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.HI;
using System.Collections.Generic;
using com.digitalwave.iCare.gui.HIS;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOPUsedMedSingle : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 科室ID数组
        /// </summary>
        private ArrayList DeptIDArr = new ArrayList();
        private string MedType = "";

        public frmOPUsedMedSingle()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置窗体对象
        /// </summary>
        public override void CreateController()
        {
            this.objController = new clsCtlOPUsedMedSingle();
            this.objController.Set_GUI_Apperance(this);
        }

        private void frmOPUsedMedSingle_Load(object sender, EventArgs e)
        {

        }

        private void lsvItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SelectedItem();
            }
        }

        private void lsvItem_DoubleClick(object sender, EventArgs e)
        {
            SelectedItem();
        }

        private void SelectedItem()
        {
            if (this.lsvItem.Items.Count == 0 || this.lsvItem.SelectedItems.Count == 0)
            {
                return;
            }

            DataRow dr = this.lsvItem.SelectedItems[0].Tag as DataRow;

            //string ItemName = dr["itemname_vchr"].ToString().Trim();
            //string ItemSpe = dr["itemspec_vchr"].ToString().Trim();
            //string ItemUnit, ItemPrice;
            //if (dr["ipchargeflg_int"].ToString().Trim() == "1")
            //{
            //    ItemUnit = dr["itemipunit_chr"].ToString().Trim();
            //    ItemPrice = dr["submoney"].ToString().Trim();
            //}
            //else
            //{
            //    ItemUnit = dr["itemunit_chr"].ToString().Trim();
            //    ItemPrice = dr["itemprice_mny"].ToString().Trim();
            //}

            //string Precent = "100";
            //if (dr["precent_dec"].ToString().Trim() != "")
            //{
            //    Precent = dr["precent_dec"].ToString().Trim();
            //}

            //填充主项目


            //this.m_objViewer.txtItemName.Text = ItemName;
            //this.m_objViewer.lblStandard.Text = ItemSpe;
            //this.m_objViewer.lblUnit.Text = ItemUnit;
            //this.m_objViewer.lblPrice.Text = ItemPrice;

            this.txtCodeNo.Text = dr["itemcode_vchr"].ToString();

            //填充默认执行地点
            //string ApplyAreaID = "";
            //if (this.m_objViewer.txtApplyArea.Value != null)
            //{
            //    ApplyAreaID = this.m_objViewer.txtApplyArea.Value.ToString().Trim();
            //}

            //string ItemId = dr["itemid_chr"].ToString();
            //string ExecAreaID = this.objSvc.m_strGetChargeItemDefaultExecAreaID(ItemId, ApplyAreaID);
            //if (ExecAreaID == "")
            //{
            //    this.m_mthLoadExecArea(1, null);
            //}
            //else
            //{
            //    this.m_mthLoadExecArea(2, ItemId);
            //}

            //this.m_objViewer.txtExecArea.m_mthFindAndSelect(ExecAreaID);

            //this.m_objViewer.txtItemName.Tag = dr;

            this.txtCodeNo.Focus();
        }
        
        private void lsvItem_Leave(object sender, EventArgs e)
        {
            this.m_pnlItem.Height = 0;
        }

        private void txtCodeNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ((clsCtlOPUsedMedSingle)this.objController).m_mthFindChargeItem(this.txtCodeNo.Text);
            }
        }

        private void btnDept_Click(object sender, EventArgs e)
        {
            frmAidDeptList fDept = new frmAidDeptList();
            if (fDept.ShowDialog() == DialogResult.OK)
            {
                DeptIDArr = fDept.DeptIDArr;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string CodeNo = this.txtCodeNo.Text.Trim();
            if (CodeNo == "")
            {
                MessageBox.Show("请输入项目编码!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCodeNo.Focus();
                return;
            }

            string BeginDate = this.dteRq1.Value.ToString("yyyy-MM-dd");
            string EndDate = this.dteRq2.Value.ToString("yyyy-MM-dd");

            if (Convert.ToDateTime(BeginDate + " 00:00:01") > Convert.ToDateTime(EndDate + " 00:00:01"))
            {
                MessageBox.Show("开始日期不能大于结束日期。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsPublic.PlayAvi("findFILE.avi", "正在统计消耗药品信息，请稍候...");
            ((clsCtlOPUsedMedSingle)this.objController).GetData(this.DeptIDArr, CodeNo, MedType, BeginDate, EndDate);
            clsPublic.CloseAvi();

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            clsPublic.ChoosePrintDialog(this.dwMed, true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (this.dwMed.RowCount > 0)
            {
                clsPublic.ExportDataWindow(this.dwMed);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}