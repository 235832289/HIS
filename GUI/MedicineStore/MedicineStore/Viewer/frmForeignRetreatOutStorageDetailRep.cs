using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    public partial class frmForeignRetreatOutStorageDetailRep : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 0：不显示预览直接打印，1：显示预览窗体
        /// </summary>
        public int i_showType;
        public string strOutputOrder;
        public string strBug;
        public string strOutDate;
        public string strVENDOR;
        public DataTable dtb;
        /// <summary>
        /// 当前药品出库主表信息
        /// </summary>
        public clsMS_OutStorage_VO m_objCurrentSubArr = null;

        public frmForeignRetreatOutStorageDetailRep()
        {
            InitializeComponent();
            datWindow.LibraryList = clsMedicineStoreFormFactory.PBLPath;
        }
        #region 方法
        public override void CreateController()
        {
            this.objController = new clsCtl_ForeignRetreatOutStorageDetailReport();
            objController.Set_GUI_Apperance(this);
        }
        #endregion
        private void frmForeignRetreatOutStorageDetailRep_Load(object sender, EventArgs e)
        {
            try
            {
                ((clsCtl_ForeignRetreatOutStorageDetailReport)objController).m_OutPurchasePrint(m_objCurrentSubArr);
                datWindow.Retrieve(dtb);
                datWindow.PrintProperties.Preview = true;
                if (i_showType == 0)
                {
                    //this.Visible = false;
                    ////datWindow.Print();
                    //clsCtl_Public clsPub = new clsCtl_Public();
                    //clsPub.ChoosePrintDialog(datWindow, true);
                }
                else
                {
                    //datWindow.PrintProperties.Preview = true;
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("无法处理服务名"))
                    MessageBox.Show("请检查配置好第二个数据库的连接参数", "灏瀚系统温馨提示...", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void m_cmdPrint_Click(object sender, EventArgs e)
        {
            ((clsCtl_ForeignRetreatOutStorageDetail)objController).getOutStorageDetail_VO(out m_objCurrentSubArr);
            MessageBox.Show(m_objCurrentSubArr.m_strOUTSTORAGEID_VCHR);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {

        }

        private void m_cmdPrint_Click_1(object sender, EventArgs e)
        {
            //datWindow.Print();
            clsCtl_Public clsPub = new clsCtl_Public();
            clsPub.ChoosePrintDialog(datWindow, true);
                       
        }

        private void m_cmdExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}