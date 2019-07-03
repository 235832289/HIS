using System;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    public partial class frmAntiConsultation : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="_patVo"></param>
        public frmAntiConsultation(clsBIHPatientInfo _patVo)
        {
            InitializeComponent();
            patVo = _patVo;
        }
        #endregion

        #region 变量.属性

        /// <summary>
        /// 病人信息
        /// </summary>
        clsBIHPatientInfo patVo { get; set; }

        #endregion

        #region 方法

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        void Init()
        {
            try
            {
                clsPublic.PlayAvi("请稍候...");
                clsEmrSignToolCollection tools = new clsEmrSignToolCollection();
                tools.m_mthBindEmployeeSign(this.btnDoct, this.txtDoct, 1, false);

                dwc.LibraryList = Application.StartupPath + @"\pbreport.pbl";
                dwc.DataWindowObject = "d_anticonsultation";
                dwc.InsertRow(0);

                GetHistory();
                New();
            }
            finally
            {
                clsPublic.CloseAvi();
            }
        }
        #endregion

        #region GetHistory
        /// <summary>
        /// GetHistory
        /// </summary>
        void GetHistory()
        {
            this.lvHistory.Items.Clear();
            clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
            DataTable dt = svc.GetSadcHistory(patVo.m_strRegisterID);
            if (dt != null && dt.Rows.Count > 0)
            {
                ListViewItem obj = null;
                this.lvHistory.BeginUpdate();
                foreach (DataRow dr in dt.Rows)
                {
                    obj = new ListViewItem();
                    obj.Text = Convert.ToDateTime(dr["applydate"]).ToString("yyyy-MM-dd HH:mm");
                    obj.Tag = dr;
                    this.lvHistory.Items.Add(obj);
                }
                this.lvHistory.EndUpdate();
            }
        }
        #endregion

        #region New
        /// <summary>
        /// New
        /// </summary>
        void New()
        {
            SetData(null);
        }
        #endregion

        #region SetData
        /// <summary>
        /// SetData
        /// </summary>
        /// <param name="dr"></param>
        void SetData(EntityBihSadcExperts expertVo)
        {
            if (expertVo == null)
            {
                this.txtCon.Tag = null;
                this.txtCon.Text = string.Empty;
                this.txtDoct.Text = string.Empty;
                this.dtpDoct.Text = string.Empty;
                // MessageBox.Show("您不是受邀请会诊专家。");
            }
            else
            {
                this.txtCon.Tag = expertVo;
                this.txtCon.Text = expertVo.responsedesc;
                this.txtDoct.Text = expertVo.expertname;
                this.dtpDoct.Text = (expertVo.responsedate == null) ? string.Empty : expertVo.responsedate.Value.ToString("yyyy-MM-dd HH:mm");
            }
            this.txtCon.Enabled = expertVo == null ? false : true;
            this.btnDoct.Enabled = expertVo == null ? false : true;
            this.dtpDoct.Enabled = expertVo == null ? false : true;

        }
        #endregion

        #region Load
        /// <summary>
        /// Load
        /// </summary>
        void LoadData(decimal applyId)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                DataTable dtMain = null;
                DataTable dtResponse = null;
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                svc.GetSadcRecord(applyId, out dtMain, out dtResponse);
                if (dtMain != null && dtMain.Rows.Count > 0)
                {
                    DataRow dr = dtMain.Rows[0];
                    #region datawindow.setdata
                    dwc.Modify("lbldeptname.text = '" + dr["applydeptname"].ToString() + "'");
                    dwc.Modify("lblmedname.text = '" + dr["drugname"].ToString() + "'");
                    if (Convert.ToDecimal(dr["pathcheck"].ToString()) == 1)
                    {
                        dwc.Modify("chkyes.text = '√'");
                        dwc.Modify("chkno.text = ''");
                        dwc.Modify("lblnodesc.text = '" + dr["pathdesc"].ToString() + "'");
                    }
                    else
                    {
                        dwc.Modify("chkyes.text = ''");
                        dwc.Modify("chkno.text = '√'");
                        dwc.Modify("lblnodesc.text = ''");
                    }
                    dwc.Modify("lblpatname.text = '" + patVo.m_strPatientName + "'");
                    dwc.Modify("lblsex.text = '" + patVo.m_strSex + "'");
                    dwc.Modify("lblage.text = '" + patVo.m_strAge + "'");
                    dwc.Modify("lblipno.text = '" + patVo.m_strInHospitalNo + "'");
                    dwc.Modify("lbldiag.text = '" + dr["clinicdiag"].ToString() + "'");
                    dwc.Modify("lblillness.text = '" + dr["medhistory"].ToString() + "'");
                    dwc.Modify("lblapplydesc.text = '" + dr["applyreason"].ToString() + "'");
                    dwc.Modify("lblapplyopername.text = '" + dr["applyopername"].ToString() + "'");
                    dwc.Modify("lblapplyyear.text = '" + Convert.ToDateTime(dr["applydate"].ToString()).ToString("yyyy") + "'");
                    dwc.Modify("lblapplymonth.text = '" + Convert.ToDateTime(dr["applydate"].ToString()).ToString("MM") + "'");
                    dwc.Modify("lblapplyday.text = '" + Convert.ToDateTime(dr["applydate"].ToString()).ToString("dd") + "'");
                    dwc.Modify("lblconfirmdesc.text = '" + dr["directoropinion"].ToString() + "'");
                    dwc.Modify("lblconfirmopername.text = '" + dr["directorname"].ToString() + "'");
                    if (dr["directorsigndate"] != DBNull.Value)
                    {
                        dwc.Modify("lblconfirmyear.text = '" + Convert.ToDateTime(dr["directorsigndate"].ToString()).ToString("yyyy") + "'");
                        dwc.Modify("lblconfirmmonth.text = '" + Convert.ToDateTime(dr["directorsigndate"].ToString()).ToString("MM") + "'");
                        dwc.Modify("lblconfirmday.text = '" + Convert.ToDateTime(dr["directorsigndate"].ToString()).ToString("dd") + "'");
                    }
                    if (dtResponse != null && dtResponse.Rows.Count > 0)
                    {
                        string conDesc = string.Empty;
                        string conDoct = string.Empty;
                        DateTime? dtmDoct = null;
                        foreach (DataRow dr3 in dtResponse.Rows)
                        {
                            conDesc += dr3["responsedesc"].ToString() + Environment.NewLine;
                            conDoct += dr3["expertname"].ToString() + " ";
                            if (dr3["responsedate"] != DBNull.Value) dtmDoct = Convert.ToDateTime(dr3["responsedate"].ToString());
                        }
                        if (conDesc != string.Empty && dtmDoct != null)
                        {
                            dwc.Modify("lblcondesc.text = '" + conDesc + "'");
                            dwc.Modify("lblcondoctname.text = '" + conDoct + "'");
                            dwc.Modify("lblconyear.text = '" + dtmDoct.Value.ToString("yyyy") + "'");
                            dwc.Modify("lblconmonth.text = '" + dtmDoct.Value.ToString("MM") + "'");
                            dwc.Modify("lblconday.text = '" + dtmDoct.Value.ToString("dd") + "'");
                        }
                    }
                    #endregion
                    SetData(svc.GetSadcResponse(applyId, LoginInfo.m_strEmpID));
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Save
        /// <summary>
        /// Save
        /// </summary>
        void Save()
        {
            EntityBihSadcExperts expertVo = this.txtCon.Tag as EntityBihSadcExperts;
            expertVo.responsedesc = this.txtCon.Text.Trim();
            expertVo.expertname = this.txtDoct.Text.Trim();
            expertVo.responsedate = this.dtpDoct.Value;
            if (expertVo.responsedesc == string.Empty)
            {
                MessageBox.Show("会诊意见不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtCon.Focus();
                return;
            }
            if (expertVo.expertname == string.Empty)
            {
                MessageBox.Show("会诊医师不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtDoct.Focus();
                return;
            }
            if (expertVo.responsedate <= Convert.ToDateTime("2018-01-01 00:00:00"))
            {
                MessageBox.Show("签名日期不能小于2018-01-01", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpDoct.Focus();
                return;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                int ret = svc.SaveSadcResponse(expertVo);
                svc = null;
                if (ret > 0)
                {
                    LoadData(expertVo.applyid);
                    MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "保存异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        void Delete()
        {
            EntityBihSadcExperts expertVo = this.txtCon.Tag as EntityBihSadcExperts;
            if (MessageBox.Show("删除前请再次确认？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    expertVo.responsedesc = null;
                    expertVo.responsedate = null;
                    clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                    int ret = svc.SaveSadcResponse(expertVo);
                    svc = null;
                    if (ret > 0)
                    {
                        LoadData(expertVo.applyid);
                        SetData(null);
                        MessageBox.Show("删除成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "删除异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region Print
        /// <summary>
        /// Print
        /// </summary>
        void Print()
        {
            dwc.Print();
        }
        #endregion

        #endregion

        #region 事件

        private void frmAntiConsultation_Load(object sender, EventArgs e)
        {
            if (this.DesignMode) return;
            this.Init();
        }

        private void lvHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHistory.SelectedItems.Count > 0)
            {
                DataRow dr = lvHistory.SelectedItems[0].Tag as DataRow;
                LoadData(Convert.ToDecimal(dr["applyid"].ToString()));
            }
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void tsbDel_Click(object sender, EventArgs e)
        {
            this.Delete();
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            this.Print();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

    }
}
