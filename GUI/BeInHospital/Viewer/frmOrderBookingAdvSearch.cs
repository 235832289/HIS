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
    public partial class frmOrderBookingAdvSearch : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        internal string m_strSearch= @"SELECT  a.BOOKID_INT,      
                                                    a.OPERATE_DAT,     
                                                    a.ORDERNAME_VCHR,  
                                                    a.CHARGEITEMNAME_VCHR, 
                                                    a.UNIT_VCHR,
                                                    a.UNITPRICE_DEC,
                                                    a.AMOUNT_DEC,
                                                    a.Remark_Vchr,
                                                    a.BOOK_DAT,
                                                    a.BOOKSTATUS_INT,
                                                    a.CONFIRM_DAT,
                                                    a.APPLY_TYPE_INT,
                                                    b.inpatientid_chr,
                                                    c.lastname_vchr,
                                                    c.sex_chr,
                                                    d1.deptname_vchr CREATEAREA,
                                                    d2.deptname_vchr CURAREA,
                                                    d2.CODE_VCHR,
                                                    e.code_chr,
                                                    f1.lastname_vchr creator,
                                                    f2.lastname_vchr SENDER,
                                                    f3.lastname_vchr DOCTOR,
                                                    f4.lastname_vchr CONFIRMER
                                              FROM T_OPR_BIH_ORDER_BOOKING a,
                                                   T_OPR_BIH_REGISTER b,
                                                   T_OPR_BIH_REGISTERDETAIL c,
                                                   T_BSE_DEPTDESC d1,
                                                   T_BSE_DEPTDESC d2,
                                                   T_BSE_BED e,
                                                   T_BSE_EMPLOYEE f1,
                                                   T_BSE_EMPLOYEE f2,
                                                   T_BSE_EMPLOYEE f3,
                                                   T_BSE_EMPLOYEE f4
                                            WHERE a.Registerid_Chr = b.registerid_chr AND
                                                  a.registerid_chr = c.registerid_chr AND
                                                  a.createarea_chr = d1.deptid_chr  AND
                                                  a.curareaid_chr = d2.deptid_chr AND
                                                  a.curbedid_chr = e.bedid_chr AND
                                                  a.createarea_chr = f1.empid_chr(+) AND
                                                  a.senderid_chr = f2.empid_chr(+) AND
                                                  a.doctorid_chr = f3.empid_chr(+) AND
                                                  a.confirmerid_chr = f4.empid_chr(+) ";

        public frmOrderBookingAdvSearch()
        {
            InitializeComponent();

            m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtArea, m_txtBedNo, m_txtApplyType });

            // 病区列表
            clsColumns_VO[] columArr = new clsColumns_VO[]{
                new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("病区名称","deptname_vchr",HorizontalAlignment.Left,130)
            };
            this.m_txtArea.m_strSQL = @"SELECT   a.deptid_chr, a.deptname_vchr, a.pycode_chr, a.code_vchr
                                        FROM t_bse_deptdesc a
                                        WHERE a.attributeid = '0000003' AND a.status_int = 1
                                             ORDER BY code_vchr";
            this.m_txtArea.m_mthInitListView(columArr);

            //设置默认病区
            this.m_txtArea.Value = this.LoginInfo.m_strInpatientAreaID;
            this.m_txtArea.Text = this.LoginInfo.m_strInpatientAreaName;

            //床位列表
            //            columArr = new clsColumns_VO[]{ 
            //                new clsColumns_VO("床号","code_chr",HorizontalAlignment.Left,50),
            //                new clsColumns_VO("姓名","lastname_vchr",HorizontalAlignment.Left,100),
            //                new clsColumns_VO("性别","sex_chr",HorizontalAlignment.Left,50)
            //            };

            //            this.m_txtBedNo.m_strSQL = @"SELECT    a.bedid_chr,a.code_chr,a.areaid_chr,b.lastname_vchr,b.sex_chr     
            //                    FROM t_bse_bed a,t_opr_bih_registerdetail b,t_opr_bih_register c
            //                    where a.bihregisterid_chr = c.registerid_chr
            //                    and b.registerid_chr = c.registerid_chr
            //                    AND (c.pstatus_int = 1 or c.PSTATUS_INT=2)
            //                    AND  c.areaid_chr= '" + this.m_txtArea.Value + @"'  
            //                    AND (a.status_int = 2 or a.status_int = 6)
            //                    order by a.code_chr";
            //            this.m_txtBedNo.m_mthInitListView(columArr);

            // 检查类型列表
            columArr = new clsColumns_VO[]{
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

            this.m_dtpOprBgnDate.Text = DateTime.Now.ToShortDateString() + " 00:00";
            this.m_dtpOprEndDate.Text = DateTime.Now.ToShortDateString() + " 23:59";

            this.m_dtpBookBgnDate.Text = DateTime.Now.ToShortDateString() + " 00:00";
            this.m_dtpBookEndDate.Text = DateTime.Now.ToShortDateString() + " 23:59";

            this.m_cmbStatus.SelectedIndex = 1;
        }

        public override void CreateController()
        {
            //this.objController = new com.digitalwave.iCare.gui.HIS.clsCtlOerderBookingRe();
            //objController.Set_GUI_Apperance(this);
        }

        private void frmOrderBookingAdvSearch_Load(object sender, EventArgs e)
        {
           
        }

        private void m_ckbArea_CheckedChanged(object sender, EventArgs e)
        {
           
            this.m_txtArea.Enabled = this.m_ckbArea.Checked;
            this.m_ckbBedNo.Enabled = this.m_ckbArea.Checked;
           
        }

        private void m_ckbBedNo_CheckedChanged(object sender, EventArgs e)
        {
            this.m_txtBedNo.Enabled = this.m_ckbBedNo.Checked;
            
            if (this.m_ckbBedNo.Checked == true)
            {
                //床位列表
                clsColumns_VO[] columArr = new clsColumns_VO[]{ 
                                new clsColumns_VO("床号","code_chr",HorizontalAlignment.Left,50),
                                new clsColumns_VO("姓名","lastname_vchr",HorizontalAlignment.Left,80),
                                new clsColumns_VO("性别","sex_chr",HorizontalAlignment.Left,50)
                            };

                this.m_txtBedNo.m_strSQL = @"SELECT    a.bedid_chr,a.code_chr,a.areaid_chr,b.lastname_vchr,b.sex_chr     
                                    FROM t_bse_bed a,t_opr_bih_registerdetail b,t_opr_bih_register c
                                    where a.bihregisterid_chr = c.registerid_chr
                                    and b.registerid_chr = c.registerid_chr
                                    AND (c.pstatus_int = 1 or c.PSTATUS_INT=2)
                                    AND  c.areaid_chr= '" + this.m_txtArea.Value + @"'  
                                    AND (a.status_int = 2 or a.status_int = 6)
                                    order by a.code_chr";
                this.m_txtBedNo.m_mthInitListView(columArr);
               
            }
        }

        private void m_ckbName_CheckedChanged(object sender, EventArgs e)
        {
            this.m_txtName.Enabled = this.m_ckbName.Checked;
        }

        private void m_ckbSex_CheckedChanged(object sender, EventArgs e)
        {
            this.m_cobSex.Enabled = this.m_ckbSex.Checked;
        }

        private void m_chbInpatientId_CheckedChanged(object sender, EventArgs e)
        {
            this.m_txtInpatienId.Enabled = this.m_chbInpatientId.Checked;
        }

        private void m_ckbOperateDate_CheckedChanged(object sender, EventArgs e)
        {
            this.m_dtpOprBgnDate.Enabled = this.m_ckbOperateDate.Checked;
            this.m_dtpOprEndDate.Enabled = this.m_ckbOperateDate.Checked;
            this.m_lblOprTo.Enabled = this.m_ckbOperateDate.Checked;
        }

        private void m_chbApplyType_CheckedChanged(object sender, EventArgs e)
        {
            this.m_txtApplyType.Enabled = this.m_ckbApplyType.Checked;
        }

        private void m_ckbBookDate_CheckedChanged(object sender, EventArgs e)
        {
            this.m_dtpBookBgnDate.Enabled = this.m_ckbBookDate.Checked;
            this.m_dtpBookEndDate.Enabled = this.m_ckbBookDate.Checked;
            this.m_lblBookTo.Enabled = this.m_ckbBookDate.Checked;
        }

        private void m_ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            this.m_cmbStatus.Enabled = this.m_ckbStatus.Checked;
        }

        private void m_cmdExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void m_cmdOk_Click(object sender, EventArgs e)
        {
            if (this.m_ckbArea.Checked == true)
            {
                this.DialogResult = DialogResult.OK;
                this.m_strSearch += @" and a.CURAREAID_CHR = '" + this.m_txtArea.Value + "'";
            }

            if (this.m_ckbBedNo.Checked == true)
            {
                this.DialogResult = DialogResult.OK;
                this.m_strSearch += @" and a.CURBEDID_CHR = '" + this.m_txtBedNo.Value + "'";
            }
            if (this.m_ckbName.Checked == true)
            {
                this.DialogResult = DialogResult.OK;
                this.m_strSearch += @" and c.lastname_vchr like '" + this.m_txtName.Text.Trim() + "%'";
            }

            if (this.m_ckbSex.Checked == true)
            {
                this.DialogResult = DialogResult.OK;
                this.m_strSearch += @" and c.sex_chr = '" + this.m_cobSex.Text + "'";
            }

            if (this.m_chbInpatientId.Checked == true)
            {
                this.DialogResult = DialogResult.OK;
                this.m_strSearch += @" and b.inpatientid_chr = '" + this.m_txtInpatienId.Text.Trim() + "'";
            }

            if (this.m_ckbOperateDate.Checked == true)
            {
                this.DialogResult = DialogResult.OK;
                this.m_strSearch += @"  AND a.OPERATE_DAT>to_date('" + this.m_dtpOprBgnDate.Text + ":00" + @"','YYYY-MM-DD HH24:MI:SS')
                      AND a.OPERATE_DAT<to_date('" + this.m_dtpOprEndDate.Text + ":59" + @"','YYYY-MM-DD HH24:MI:SS')";
            }

            if (this.m_ckbApplyType.Checked == true)
            {
                this.DialogResult = DialogResult.OK;
                this.m_strSearch += @" and a.apply_type_int = " + this.m_txtApplyType.Value;
            }

            if (this.m_ckbBookDate.Checked == true)
            {
                this.DialogResult = DialogResult.OK;
                this.m_strSearch += @"  AND a.BOOK_DAT>to_date('" + this.m_dtpBookBgnDate.Text + ":00" + @"','YYYY-MM-DD HH24:MI:SS')
                      AND a.BOOK_DAT<to_date('" + this.m_dtpBookEndDate.Text + ":59" + @"','YYYY-MM-DD HH24:MI:SS')";
            }

            if (this.m_ckbStatus.Checked == true)
            {
                int status = this.m_cmbStatus.SelectedIndex - 1;
                if (status > -1)
                {
                    this.DialogResult = DialogResult.OK;
                    this.m_strSearch += @" and a.BOOKSTATUS_INT = " + status.ToString();
                }
            }
            
            this.Hide();
        }

        private void frmOrderBookingAdvSearch_KeyDown(object sender, KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Hide();
                    break;
            }
        }

        private void m_txtArea_TextChanged(object sender, EventArgs e)
        {
            //m_mthSetEnter2Tab(new System.Windows.Forms.Control[] { m_txtArea, m_txtBedNo, m_txtApplyType });
                
            //床位列表
//                clsColumns_VO[] columArr = new clsColumns_VO[]{ 
//                new clsColumns_VO("床号","code_chr",HorizontalAlignment.Left,50),
//                new clsColumns_VO("姓名","lastname_vchr",HorizontalAlignment.Left,80),
//                new clsColumns_VO("性别","sex_chr",HorizontalAlignment.Left,50)
//            };

//                this.m_txtBedNo.m_strSQL = @"SELECT    a.bedid_chr,a.code_chr,a.areaid_chr,b.lastname_vchr,b.sex_chr     
//                    FROM t_bse_bed a,t_opr_bih_registerdetail b,t_opr_bih_register c
//                    where a.bihregisterid_chr = c.registerid_chr
//                    and b.registerid_chr = c.registerid_chr
//                    AND (c.pstatus_int = 1 or c.PSTATUS_INT=2)
//                    AND  c.areaid_chr= '" + this.m_txtArea.Value + @"'  
//                    AND (a.status_int = 2 or a.status_int = 6)
//                    order by a.code_chr";
//                this.m_txtBedNo.m_mthInitListView(columArr);
               

        }

        private void m_cmdReset_Click(object sender, EventArgs e)
        {
            //设置默认病区
            this.m_txtArea.Value = this.LoginInfo.m_strInpatientAreaID;
            this.m_txtArea.Text = this.LoginInfo.m_strInpatientAreaName;

            this.m_txtApplyType.Text = "全部";
            this.m_txtApplyType.Value = "0";

            this.m_dtpOprBgnDate.Text = DateTime.Now.ToShortDateString() + " 00:00";
            this.m_dtpOprEndDate.Text = DateTime.Now.ToShortDateString() + " 23:59";

            this.m_dtpBookBgnDate.Text = DateTime.Now.ToShortDateString() + " 00:00";
            this.m_dtpBookEndDate.Text = DateTime.Now.ToShortDateString() + " 23:59";

            this.m_cmbStatus.SelectedIndex = 1;
            
            this.m_txtName.Text = "";
            this.m_cobSex.Text = "";
            this.m_txtInpatienId.Text = "";

            this.m_ckbArea.Checked = false;
            this.m_ckbBedNo.Checked = false;
            this.m_ckbName.Checked = false;
            this.m_ckbSex.Checked = false;
            this.m_ckbBookDate.Checked = false;
            this.m_ckbOperateDate.Checked = false;
            this.m_ckbApplyType.Checked = false;
            this.m_chbInpatientId.Checked = false;
            this.m_ckbStatus.Checked = false;
        }       
    }
}