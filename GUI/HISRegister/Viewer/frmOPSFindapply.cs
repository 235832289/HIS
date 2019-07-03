using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public partial class frmOPSFindapply : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        private int Type = 0;
        public frmOPSFindapply(int p_type)
        {
            InitializeComponent();
            Type = p_type;
        }
        #region 变量
        /// <summary>
        /// 科室数组
        /// </summary>
        string[,] strDeptArr = null;

        clsDcl_DoctorWorkstation objSvc = new clsDcl_DoctorWorkstation();
        #endregion
        private void frmOPSFindapply_Load(object sender, EventArgs e)
        {
            if (Type == 0)
            {
                this.panel1.Height = 0;
            }
            m_mthSetDeptList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void txtCardno_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string s = this.txtCardno.Text.Trim();
                this.txtCardno.Text = s.PadLeft(10, '0');
            }
        }
        #region 获取科室数据,赋值给控件
        /// <summary>
        /// 获取科室数据
        /// </summary>
        public void m_mthSetDeptList()
        {
            DataTable dt = null;
            com.digitalwave.iCare.gui.PACS.clsControlPacsBooking objCls = new com.digitalwave.iCare.gui.PACS.clsControlPacsBooking();
            long lngres = objCls.m_lngGetdeptdescData(out dt);
            if (lngres > 0)
            {
                if (dt != null)
                {
                    this.m_deptTbFind.m_GetDataTable = dt;
                }
            }
        }
        #endregion

        private void btnFind_Click(object sender, EventArgs e)
        {
            DataTable dt = null;
            string strTemp = " and ";
            string strOr = " AND (";
            if (txtCardno.Text.Trim() != "")
            {
                strOr += "(f.patientcardid_chr='" + txtCardno.Text.Trim() + "')" + strTemp;
            }
            if (txtName.Text.Trim() != "")
            {
                strOr += "(b.name_vchr like '" + txtName.Text.Trim() + "%')" + strTemp;
            }

            if (m_deptTbFind.Tag != null)
            {
                strOr += "(e.deptid_chr='" + m_deptTbFind.Tag.ToString() + "')" + strTemp;
            }
            if (m_deptTbFind.txtValuse.Trim() != "")
            {
                strOr += "(e.DEPTNAME_VCHR='" + m_deptTbFind.txtValuse.Trim().ToString() + "')" + strTemp;
            }
            //
            if (m_cboState.Text.Trim() != "")
            {
                strOr += "(a.STATUS_INT=" + m_strGetIdByStateText(m_cboState.Text.Trim()) + ")" + strTemp;
            }
            strOr += " (TO_CHAR (a.opsbookingdate_dat, 'yyyy-mm-dd') BETWEEN '" + dtpBegindate.Value.ToString("yyyy-MM-dd") + "'  AND  '" + dtpEnddate.Value.ToString("yyyy-MM-dd") + "')";
            strOr += " )";
            long lngRes = objSvc.m_lngGetApplyOPInfoByOrCondition(strOr, out dt);
            if (lngRes >0)
            {
                DataTable dtTemp = dt.Clone();
                DataRow dr = null;
                dtTemp.Columns["birth_dat"].DataType = System.Type.GetType("System.String");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    dr = dtTemp.NewRow();
                    for (int j2 = 0; j2 < dt.Columns.Count; j2++)
                    {
                        if (dt.Columns[j2].ColumnName == "birth_dat")
                        {
                            dr[j2] = dt.Rows[j][j2].ToString();
                        }
                        else
                        {
                            dr[j2] = dt.Rows[j][j2];
                        }
                    }
                    dtTemp.Rows.Add(dr);
                }
                string strDate = "";
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    strDate = dtTemp.Rows[i]["birth_dat"].ToString();
                    if (strDate != "")
                    {
                        try
                        {
                            dtTemp.Rows[i]["birth_dat"] = clsCreatFile.CalcAge(Convert.ToDateTime(strDate));
                        }
                        catch
                        {
                            dtTemp.Rows[i]["birth_dat"] = "0";
                        }
                    }
                    else
                    {
                        dtTemp.Rows[i]["birth_dat"] = "0";
                    }
                }
                dataGridView.DataSource = dtTemp;
            }
        }
        private string m_strGetIdByStateText(string p_strTest)
        {
            string strResult = "";
            switch  (p_strTest.Trim())
            {//状态 -1 删除；0 新建；1 已确认；2 退回
                case "删除":
                    strResult = "-1";
                    break;
                case "新建":
                    strResult = "0";
                    break;
                case "已确认":
                    strResult = "1";
                    break;
                case "退回":
                    strResult = "2";
                    break;
            }
            return strResult;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            com.digitalwave.iCare.common.clsCommmonInfo cls = new com.digitalwave.iCare.common.clsCommmonInfo ();
            string strTitle = cls.m_strGetHospitalTitle() +"门诊手术申请单信息查询报表";
            com.digitalwave.GLS_WS.clsCtl_Base objBase = new com.digitalwave.GLS_WS.clsCtl_Base();
            objBase.m_mthPrintPreviewFromDataGridView(dataGridView, 0, strTitle);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
            {
                return;
            }
            m_lblName.Tag = dataGridView["Column8", e.RowIndex].Value.ToString();
            m_lblName.Text = dataGridView["Column2", e.RowIndex].Value.ToString();
            string strDate = dataGridView["Column5", e.RowIndex].Value.ToString();
            string strStatus = dataGridView["Column7", e.RowIndex].Value.ToString();
            if (!string.IsNullOrEmpty(strDate))
            {
                lblCurrdate.Text = Convert.ToDateTime(strDate).ToString("yyyy年MM月dd日 HH时mm分");
            }
            if (strStatus.Trim() == "新建")
            {
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            btnUpdate.Enabled = false;
            if (m_lblName.Tag != null)
            {
                long lngRes = objSvc.m_lngGetApplyOPInfoUpdateDate(m_lblName.Tag.ToString(), dtAlterDate.Value.ToString("yyyy-MM-dd HH:mm"));
                if (lngRes>0)
                {
                    btnFind_Click(null,e);
                }
                frmShowWarning obj = new  frmShowWarning();
                obj.Location = this.PointToScreen(btnUpdate.Location);
                obj.m_GetWaring = "更新成功"; 
                obj.Show();
            }
            btnUpdate.Enabled = true ;
        }
    }
}