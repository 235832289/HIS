using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.BIHOrder;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOrderBookingRe : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        frmOrderBookingAdvSearch m_frmAdvSearch;
        
        public frmOrderBookingRe()
        {
            InitializeComponent();
        }

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlOerderBookingRe();
            objController.Set_GUI_Apperance(this);
        }

        private void frmOrderBookingRe_Load(object sender, EventArgs e)
        {
            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtApplyType});

            // 检查类型列表
            clsColumns_VO[] columArr = new clsColumns_VO[]{
                new clsColumns_VO("检查类型","TYPETEXT",HorizontalAlignment.Left,150)
            };
            this.m_txtApplyType.m_strSQL = @"SELECT 0 TYPEID, '全部' TYPETEXT, 0 ORDERSEQ_INT
                                        FROM ar_apply_typelist
                                        WHERE rownum = 1
                                        union all
                                        SELECT * from (SELECT distinct a.TYPEID, a.TYPETEXT,a.ORDERSEQ_INT 
                                        FROM ar_apply_typelist a,
                                             T_OPR_CHECKDEPT_ROLE b,
                                             T_Sys_EmpRoleMap c
                                        WHERE a.TYPEID = b.APPLY_TYPE_INT and
                                              b.ROLEID_CHR = c.ROLEID_CHR and
                                              a.DELETED = 0 and
                                              c.EmpID_Chr='" + this.LoginInfo.m_strEmpID
                                        + @"') ORDER BY ORDERSEQ_INT";
          
            this.m_txtApplyType.m_mthInitListView(columArr);
            
            this.m_txtApplyType.Text = "全部";
            this.m_txtApplyType.Value = "0";

            this.m_dtpBeginDate.Text = DateTime.Now.ToShortDateString() + " 00:00";
            this.m_dtpEndDate.Text = DateTime.Now.ToShortDateString() + " 23:59";

            this.m_cmbStatus.SelectedIndex = 1;

            this.dw_seach.LibraryList = clsPublic.PBLPath;
            this.dw_seach.DataWindowObject = "d_orderbooking_list";

            m_cmdSearch_Click(sender, e);
        }

        private void m_cmdRevert_Click(object sender, EventArgs e)
        {
            ((clsCtlOerderBookingRe)this.objController).ShowBookingInf();
        }

        private void m_cmdSearch_Click(object sender, EventArgs e)
        {
            ((clsCtlOerderBookingRe)this.objController).SeachData();
        }

        private void dw_seach_RowFocusChanged(object sender, Sybase.DataWindow.RowFocusChangedEventArgs e)
        {
            //if (e.RowNumber > this.dw_seach.RowCount)
            //{
            //    e.Cancel = true;
            //    return;
            //}
            
            this.dw_seach.SelectRow(0, false);
            this.dw_seach.SelectRow(e.RowNumber, true);
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmOrderBookingRe_KeyDown(object sender, KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    if (MessageBox.Show("确认退出么?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        this.Close();
                    }
                    break;
            }
        }

        private void m_cmdAdv_Click(object sender, EventArgs e)
        {
            if (this.m_frmAdvSearch == null)
            {
                this.m_frmAdvSearch = new frmOrderBookingAdvSearch();
            }

            #region 初始化变量
            this.m_frmAdvSearch.m_strSearch = @"select a.registerid_chr, a.bookid_int, a.operate_dat, a.orderid_chr,
                                                   a.ordername_vchr, a.chargeitemname_vchr, a.unit_vchr, a.unitprice_dec,
                                                   a.amount_dec, a.remark_vchr, a.book_dat, a.bookstatus_int,
                                                   a.confirm_dat, a.apply_type_int, a.print_flag, b.inpatientid_chr,
                                                   c.lastname_vchr, c.sex_chr, c.birth_dat, d1.deptname_vchr createarea,
                                                   d2.deptname_vchr curarea, d2.code_vchr, e.code_chr,
                                                   f1.lastname_vchr creator, f2.lastname_vchr sender,
                                                   f3.lastname_vchr doctor, f4.lastname_vchr confirmer,
                                                   k.patientcardid_chr 
                                              FROM T_OPR_BIH_ORDER_BOOKING a,
                                                   T_OPR_BIH_REGISTER b,
                                                   T_OPR_BIH_REGISTERDETAIL c,
                                                   T_BSE_DEPTDESC d1,
                                                   T_BSE_DEPTDESC d2,
                                                   T_BSE_BED e,
                                                   T_BSE_EMPLOYEE f1,
                                                   T_BSE_EMPLOYEE f2,
                                                   T_BSE_EMPLOYEE f3,
                                                   T_BSE_EMPLOYEE f4,
                                                   t_bse_patientcard k 
                                            WHERE a.Registerid_Chr = b.registerid_chr AND
                                                  a.registerid_chr = c.registerid_chr AND
                                                  a.createarea_chr = d1.deptid_chr  AND
                                                  a.curareaid_chr = d2.deptid_chr AND
                                                  a.curbedid_chr = e.bedid_chr AND
                                                  a.createarea_chr = f1.empid_chr(+) AND
                                                  a.senderid_chr = f2.empid_chr(+) AND
                                                  a.doctorid_chr = f3.empid_chr(+) AND
                                                  a.confirmerid_chr = f4.empid_chr(+) and
                                                  b.patientid_chr = k.patientid_chr and 
                                                  k.status_int = 1  ";
            #endregion

            this.m_frmAdvSearch.ShowDialog();

            if (this.m_frmAdvSearch.DialogResult == DialogResult.OK)
            {
                ((clsCtlOerderBookingRe)this.objController).GetBySearchSentence(this.m_frmAdvSearch.m_strSearch);
            }
        }

        private void m_cmdReplyForm_Click(object sender, EventArgs e)
        {
            ((clsCtlOerderBookingRe)this.objController).OpentApplyForm();
        }
    }
}