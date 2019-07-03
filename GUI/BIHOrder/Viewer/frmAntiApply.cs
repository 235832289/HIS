using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using com.digitalwave.Emr.Signature_gui;
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.gui.HIS;
using com.digitalwave.iCare.middletier.Anaesthesia;
using com.digitalwave.iCare.middletier.BIHOrderServer;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.BIHOrder
{
    /// <summary>
    /// 特殊抗菌药会诊申请
    /// </summary>
    public partial class frmAntiApply : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 构造
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="_patVo"></param>
        public frmAntiApply(clsBIHPatientInfo _patVo, int _bizType)
        {
            InitializeComponent();
            patVo = _patVo;
            bizType = _bizType;
        }
        #endregion

        #region 变量.属性

        /// <summary>
        /// 病人信息
        /// </summary>
        clsBIHPatientInfo patVo { get; set; }

        /// <summary>
        /// 诊断描述
        /// </summary>
        string diagDesc { get; set; }

        /// <summary>
        /// 标志: 0 申请； 1 审核
        /// </summary>
        int bizType { get; set; }

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
                this.lblPatName.Text = patVo.m_strPatientName;
                this.lblAreaName.Text = patVo.m_strAreaName;
                this.lblBedNo.Text = patVo.m_strBedName;
                this.lblIpNo.Text = patVo.m_strInHospitalNo;
                this.lblSex.Text = patVo.m_strSex;
                this.lblAge.Text = patVo.m_strAge;
                this.dtpApplyDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

                DataTable dt = null;
                clsOperationRequisitionService_Oracle svc1 = (clsOperationRequisitionService_Oracle)clsObjectGenerator.objCreatorObjectByType(typeof(clsOperationRequisitionService_Oracle));
                svc1.m_lngQueryDiagnosis(patVo.m_strPatientID, out dt);
                svc1 = null;
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataView dv = dt.DefaultView;
                    dv.Sort = "inpatient_dat desc";
                    diagDesc = dv[0]["primarydiagnoseall"].ToString().Trim();
                }

                clsEmrSignToolCollection tools = new clsEmrSignToolCollection();
                tools.m_mthBindEmployeeSign(this.btnApplyDoct, this.txtApplyDoct, 1, false);
                tools.m_mthBindEmployeeSign(this.btnConfirmDoct, this.txtConfirmDoct, 1, false);

                GetHistory();
                New();

                // 申请、审核
                this.tsbSave.Enabled = (this.bizType == 0 ? true : false);
                this.tsbDel.Enabled = (this.bizType == 0 ? true : false);
                this.tsbConfirm.Enabled = (this.bizType == 0 ? false : true);
                this.txtConfirmDesc.Enabled = (this.bizType == 0 ? false : true);
                this.txtConfirmDoct.Enabled = (this.bizType == 0 ? false : true);
                this.btnConfirmDoct.Enabled = (this.bizType == 0 ? false : true);
                this.dtpConfirmDate.Enabled = (this.bizType == 0 ? false : true);
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
                    SetData(dr, dtResponse);
                }
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region SetData
        /// <summary>
        /// SetData
        /// </summary>
        /// <param name="dr"></param>
        void SetData(DataRow dr, DataTable dtResponse)
        {
            this.lvExperts.Items.Clear();
            if (dr == null)
            {
                this.txtMedName.Tag = null;
                this.txtMedName.Text = string.Empty;
                this.chkYes.Checked = false;
                this.chkNo.Checked = false;
                this.txtNoDesc.Text = string.Empty;
                this.txtDiag.Text = string.Empty;
                this.txtIllNess.Text = string.Empty;
                this.txtApplyDesc.Text = string.Empty;
                this.txtApplyDoct.Text = string.Empty;
                this.dtpApplyDate.Text = string.Empty;
                this.txtConfirmDesc.Text = string.Empty;
                this.txtConfirmDoct.Text = string.Empty;
                this.dtpConfirmDate.Text = string.Empty;
            }
            else
            {
                EntityBihSadcApply applyVo = new EntityBihSadcApply();
                applyVo.applyid = Convert.ToDecimal(dr["applyid"].ToString());
                applyVo.registerid = dr["registerid"].ToString();
                applyVo.applyoperid = dr["applyoperid"].ToString();
                applyVo.applyopername = dr["applyopername"].ToString();
                applyVo.applydeptid = dr["applydeptid"].ToString();
                applyVo.applydeptname = dr["applydeptname"].ToString();
                applyVo.applydate = Convert.ToDateTime(dr["applydate"].ToString());
                applyVo.drugname = dr["drugname"].ToString();
                applyVo.pathcheck = Convert.ToDecimal(dr["pathcheck"].ToString());
                applyVo.pathdesc = dr["pathdesc"].ToString();
                applyVo.clinicdiag = dr["clinicdiag"].ToString();
                applyVo.medhistory = dr["medhistory"].ToString();
                applyVo.applyreason = dr["applyreason"].ToString();
                applyVo.directorid = dr["directorid"].ToString();
                applyVo.directorname = dr["directorname"].ToString();
                applyVo.directoropinion = dr["directoropinion"].ToString();
                if (dr["directorsigndate"] == DBNull.Value)
                    applyVo.directorsigndate = null;
                else
                    applyVo.directorsigndate = Convert.ToDateTime(dr["directorsigndate"].ToString());
                applyVo.recorddate = Convert.ToDateTime(dr["recorddate"].ToString());
                applyVo.status = Convert.ToDecimal(dr["status"].ToString());

                this.tsbSave.Enabled = (applyVo.status > 0 ? false : true);
                this.tsbDel.Enabled = (applyVo.status > 0 ? false : true);
                this.tsbConfirm.Enabled = (applyVo.status > 1 ? false : true);

                this.txtMedName.Tag = applyVo;
                this.txtMedName.Text = applyVo.drugname;
                this.chkYes.Checked = applyVo.pathcheck == 1 ? true : false;
                this.chkNo.Checked = applyVo.pathcheck == 0 ? true : false;
                this.txtNoDesc.Text = applyVo.pathdesc;
                this.txtDiag.Text = applyVo.clinicdiag;
                this.txtIllNess.Text = applyVo.medhistory;
                this.txtApplyDesc.Text = applyVo.applyreason;
                this.txtApplyDoct.Text = applyVo.applyopername;
                this.dtpApplyDate.Text = applyVo.applydate.ToString("yyyy-MM-dd HH:mm");
                this.txtConfirmDesc.Text = applyVo.directoropinion;
                this.txtConfirmDoct.Text = applyVo.directorname;
                this.dtpConfirmDate.Text = (applyVo.directorsigndate == null) ? string.Empty : applyVo.directorsigndate.Value.ToString("yyyy-MM-dd HH:mm");
                if (dtResponse != null && dtResponse.Rows.Count > 0)
                {
                    ListViewItem lvi = null;
                    EntityBihSadcExperts expertVo = null;
                    foreach (DataRow dr2 in dtResponse.Rows)
                    {
                        expertVo = new EntityBihSadcExperts();
                        expertVo.applyid = Convert.ToDecimal(dr2["applyid"].ToString());
                        expertVo.expertid = dr2["expertid"].ToString();
                        expertVo.expertname = dr2["expertname"].ToString();
                        expertVo.deptid = dr2["deptid"].ToString();
                        expertVo.deptname = dr2["deptname"].ToString();
                        expertVo.responsedesc = dr2["responsedesc"].ToString();
                        if (dr2["responsedate"] == DBNull.Value)
                            expertVo.responsedate = null;
                        else
                            expertVo.responsedate = Convert.ToDateTime(dr2["responsedate"].ToString());

                        lvi = new ListViewItem(expertVo.deptname);
                        lvi.SubItems.Add(expertVo.expertname);
                        lvi.SubItems.Add(expertVo.deptid);
                        lvi.SubItems.Add(expertVo.expertid);
                        lvi.Tag = expertVo;
                        this.lvExperts.Items.Add(lvi);
                    }
                }
            }
        }
        #endregion

        #region New
        /// <summary>
        /// New
        /// </summary>
        void New()
        {
            SetData(null, null);
        }
        #endregion

        #region Delete
        /// <summary>
        /// Delete
        /// </summary>
        void Delete()
        {
            if (this.txtMedName.Tag == null)
            {
                SetData(null, null);
            }
            else
            {
                EntityBihSadcApply applyVo = this.txtMedName.Tag as EntityBihSadcApply;
                if (applyVo.status > 0)
                {
                    MessageBox.Show("申请已经通过审核，不能删除。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (MessageBox.Show("删除前请再次确认？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        this.Cursor = Cursors.WaitCursor;
                        clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                        int ret = svc.CancelSadcApply(applyVo.applyid);
                        svc = null;
                        if (ret > 0)
                        {
                            this.GetHistory();
                            SetData(null, null);
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
        }
        #endregion

        #region Save
        /// <summary>
        /// Save
        /// </summary>
        void Save()
        {
            bool isNew = false;
            EntityBihSadcApply applyVo = null;
            if (this.txtMedName.Tag == null)
            {
                applyVo = new EntityBihSadcApply();
                applyVo.status = 0;
                isNew = true;
            }
            else
            {
                applyVo = this.txtMedName.Tag as EntityBihSadcApply;
            }
            applyVo.drugname = this.txtMedName.Text.Trim();
            applyVo.pathcheck = this.chkYes.Checked ? 1 : 0;
            applyVo.pathdesc = this.txtNoDesc.Text.Trim();
            applyVo.clinicdiag = this.txtDiag.Text.Trim();
            applyVo.medhistory = this.txtIllNess.Text.Trim();
            applyVo.applyreason = this.txtApplyDesc.Text.Trim();
            applyVo.applyopername = this.txtApplyDoct.Text.Trim();
            applyVo.applydate = this.dtpApplyDate.Value;
            applyVo.directoropinion = this.txtConfirmDesc.Text.Trim();
            applyVo.directorname = this.txtConfirmDoct.Text.Trim();
            applyVo.directorsigndate = this.dtpConfirmDate.Value;

            List<EntityBihSadcExperts> lstExperts = new List<EntityBihSadcExperts>();
            if (this.lvExperts.Items.Count == 0)
            {
                MessageBox.Show("邀请专家不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                EntityBihSadcExperts expertVo = null;
                for (int i = 0; i < this.lvExperts.Items.Count; i++)
                {
                    if (this.lvExperts.Items[i].Tag == null)
                    {
                        expertVo = new EntityBihSadcExperts();
                        expertVo.deptname = this.lvExperts.Items[i].SubItems[0].Text;
                        expertVo.expertname = this.lvExperts.Items[i].SubItems[1].Text;
                        expertVo.deptid = this.lvExperts.Items[i].SubItems[2].Text;
                        expertVo.expertid = this.lvExperts.Items[i].SubItems[3].Text;
                    }
                    else
                    {
                        expertVo = this.lvExperts.Items[i].Tag as EntityBihSadcExperts;
                    }
                    lstExperts.Add(expertVo);
                }
            }
            if (applyVo.drugname == string.Empty)
            {
                MessageBox.Show("抗菌药物通用名不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMedName.Focus();
                return;
            }
            if (applyVo.applyreason == string.Empty)
            {
                MessageBox.Show("申请理由不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtApplyDesc.Focus();
                return;
            }
            if (applyVo.applyopername == string.Empty)
            {
                MessageBox.Show("申请人不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtApplyDoct.Focus();
                return;
            }
            if (applyVo.applydate <= Convert.ToDateTime("2018-01-01 00:00:00"))
            {
                MessageBox.Show("申请日期不能小于2018-01-01", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpApplyDate.Focus();
                return;
            }
            if (string.IsNullOrEmpty(applyVo.registerid)) applyVo.registerid = patVo.m_strRegisterID;

            try
            {
                decimal applyId = 0;
                DateTime openDate = DateTime.Now;
                this.Cursor = Cursors.WaitCursor;
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                applyVo.applyopername = applyVo.applyopername.Replace("主任医师", "").Replace("副主任医师", "").Replace("主治医师", "").Replace("医师", "");
                applyVo.applyoperid = svc.GetEmployeeId(applyVo.applyopername.Trim());
                DataTable dt = svc.GetEmployeeByEmpId(applyVo.applyoperid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    applyVo.applydeptid = dt.Rows[0]["deptid_chr"].ToString();
                    applyVo.applydeptname = dt.Rows[0]["deptname_vchr"].ToString();
                }
                if (string.IsNullOrEmpty(applyVo.applydeptid)) applyVo.applydeptid = LoginInfo.m_strDepartmentID;
                if (string.IsNullOrEmpty(applyVo.applydeptname)) applyVo.applydeptname = LoginInfo.m_strdepartmentName;
                if (!string.IsNullOrEmpty(applyVo.directorname))
                {
                    applyVo.directorname = applyVo.directorname.Replace("主任医师", "").Replace("副主任医师", "").Replace("主治医师", "").Replace("医师", "");
                    applyVo.directorid = svc.GetEmployeeId(applyVo.directorname.Trim());
                }
                int ret = svc.SaveSadcApply(applyVo, lstExperts, out applyId);
                svc = null;
                if (ret > 0)
                {
                    MessageBox.Show("保存成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (isNew)
                    {
                        this.GetHistory();
                        LoadData(applyId);
                    }
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

        #region Confirm
        /// <summary>
        /// Confirm
        /// </summary>
        void Confirm()
        {
            if (this.txtMedName.Tag == null)
            {
                MessageBox.Show("手术申请还未保存，不能审核。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            EntityBihSadcApply applyVo = this.txtMedName.Tag as EntityBihSadcApply;
            applyVo.drugname = this.txtMedName.Text.Trim();
            applyVo.pathcheck = this.chkYes.Checked ? 1 : 0;
            applyVo.pathdesc = this.txtNoDesc.Text.Trim();
            applyVo.clinicdiag = this.txtDiag.Text.Trim();
            applyVo.medhistory = this.txtIllNess.Text.Trim();
            applyVo.applyreason = this.txtApplyDesc.Text.Trim();
            applyVo.applyopername = this.txtApplyDoct.Text.Trim();
            applyVo.applydate = this.dtpApplyDate.Value;
            applyVo.directoropinion = this.txtConfirmDesc.Text.Trim();
            applyVo.directorname = this.txtConfirmDoct.Text.Trim();
            applyVo.directorsigndate = this.dtpConfirmDate.Value;

            List<EntityBihSadcExperts> lstExperts = new List<EntityBihSadcExperts>();
            if (this.lvExperts.Items.Count == 0)
            {
                MessageBox.Show("邀请专家不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                EntityBihSadcExperts expertVo = null;
                for (int i = 0; i < this.lvExperts.Items.Count; i++)
                {
                    if (this.lvExperts.Items[i].Tag == null)
                    {
                        expertVo = new EntityBihSadcExperts();
                        expertVo.deptname = this.lvExperts.Items[i].SubItems[0].Text;
                        expertVo.expertname = this.lvExperts.Items[i].SubItems[1].Text;
                        expertVo.deptid = this.lvExperts.Items[i].SubItems[2].Text;
                        expertVo.expertid = this.lvExperts.Items[i].SubItems[3].Text;
                    }
                    else
                    {
                        expertVo = this.lvExperts.Items[i].Tag as EntityBihSadcExperts;
                    }
                    lstExperts.Add(expertVo);
                }
            }
            if (applyVo.drugname == string.Empty)
            {
                MessageBox.Show("抗菌药物通用名不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtMedName.Focus();
                return;
            }
            if (applyVo.applyreason == string.Empty)
            {
                MessageBox.Show("申请理由不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtApplyDesc.Focus();
                return;
            }
            if (applyVo.applyopername == string.Empty)
            {
                MessageBox.Show("申请人不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtApplyDoct.Focus();
                return;
            }
            if (applyVo.applydate <= Convert.ToDateTime("2018-01-01 00:00:00"))
            {
                MessageBox.Show("申请日期不能小于2018-01-01", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpApplyDate.Focus();
                return;
            }
            if (applyVo.directorname == string.Empty)
            {
                MessageBox.Show("审核人不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtConfirmDoct.Focus();
                return;
            }
            if (applyVo.directoropinion == string.Empty)
            {
                MessageBox.Show("科主任审核意见不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtConfirmDesc.Focus();
                return;
            }
            if (applyVo.directorsigndate <= Convert.ToDateTime("2018-01-01 00:00:00"))
            {
                MessageBox.Show("审核日期不能小于2018-01-01", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.dtpConfirmDate.Focus();
                return;
            }

            try
            {
                decimal applyId = 0;
                DateTime openDate = DateTime.Now;
                this.Cursor = Cursors.WaitCursor;
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                applyVo.applyopername = applyVo.applyopername.Replace("主任医师", "").Replace("副主任医师", "").Replace("主治医师", "").Replace("医师", "");
                applyVo.applyoperid = svc.GetEmployeeId(applyVo.applyopername.Trim());
                DataTable dt = svc.GetEmployeeByEmpId(applyVo.applyoperid);
                if (dt != null && dt.Rows.Count > 0)
                {
                    applyVo.applydeptid = dt.Rows[0]["deptid_chr"].ToString();
                    applyVo.applydeptname = dt.Rows[0]["deptname_vchr"].ToString();
                }
                if (string.IsNullOrEmpty(applyVo.applydeptid)) applyVo.applydeptid = LoginInfo.m_strDepartmentID;
                if (string.IsNullOrEmpty(applyVo.applydeptname)) applyVo.applydeptname = LoginInfo.m_strdepartmentName;
                applyVo.directorname = applyVo.directorname.Replace("主任医师", "").Replace("副主任医师", "").Replace("主治医师", "").Replace("医师", "");
                applyVo.directorid = svc.GetEmployeeId(applyVo.directorname.Trim());
                int ret = svc.SaveSadcApply(applyVo, lstExperts, out applyId);
                svc = null;
                if (ret > 0)
                {
                    MessageBox.Show("审核成功！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("审核失败。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "审核异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Print
        /// <summary>
        /// Print
        /// </summary>
        void Print()
        {
            if (this.txtMedName.Tag == null)
            {
                MessageBox.Show("会诊申请还未保存，不能打印。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            List<EntityBihSadcExperts> lstExperts = new List<EntityBihSadcExperts>();
            if (this.lvExperts.Items.Count == 0)
            {
                MessageBox.Show("邀请专家不能为空", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                EntityBihSadcExperts expertVo = null;
                for (int i = 0; i < this.lvExperts.Items.Count; i++)
                {
                    expertVo = this.lvExperts.Items[i].Tag as EntityBihSadcExperts;
                    lstExperts.Add(expertVo);
                }
            }
            EntityBihSadcApply applyVo = this.txtMedName.Tag as EntityBihSadcApply;
            Sybase.DataWindow.DataStore ds = new Sybase.DataWindow.DataStore();
            ds.LibraryList = Application.StartupPath + @"\pbreport.pbl";
            ds.DataWindowObject = "d_anticonsultation";
            ds.InsertRow(0);
            ds.Modify("lbldeptname.text = '" + applyVo.applydeptname + "'");
            ds.Modify("lblmedname.text = '" + applyVo.drugname + "'");
            if (applyVo.pathcheck == 1)
            {
                ds.Modify("chkyes.text = '√'");
                ds.Modify("chkno.text = ''");
                ds.Modify("lblnodesc.text = '" + applyVo.pathdesc + "'");
            }
            else
            {
                ds.Modify("chkyes.text = ''");
                ds.Modify("chkno.text = '√'");
                ds.Modify("lblnodesc.text = ''");
            }
            ds.Modify("lblpatname.text = '" + patVo.m_strPatientName + "'");
            ds.Modify("lblsex.text = '" + patVo.m_strSex + "'");
            ds.Modify("lblage.text = '" + patVo.m_strAge + "'");
            ds.Modify("lblipno.text = '" + patVo.m_strInHospitalNo + "'");
            ds.Modify("lbldiag.text = '" + applyVo.clinicdiag + "'");
            ds.Modify("lblillness.text = '" + applyVo.medhistory + "'");
            ds.Modify("lblapplydesc.text = '" + applyVo.applyreason + "'");
            ds.Modify("lblapplyopername.text = '" + applyVo.applyopername + "'");
            ds.Modify("lblapplyyear.text = '" + applyVo.applydate.ToString("yyyy") + "'");
            ds.Modify("lblapplymonth.text = '" + applyVo.applydate.ToString("MM") + "'");
            ds.Modify("lblapplyday.text = '" + applyVo.applydate.ToString("dd") + "'");
            ds.Modify("lblconfirmdesc.text = '" + applyVo.directoropinion + "'");
            ds.Modify("lblconfirmopername.text = '" + applyVo.directorname + "'");
            if (applyVo.directorsigndate != null)
            {
                ds.Modify("lblconfirmyear.text = '" + applyVo.directorsigndate.Value.ToString("yyyy") + "'");
                ds.Modify("lblconfirmmonth.text = '" + applyVo.directorsigndate.Value.ToString("MM") + "'");
                ds.Modify("lblconfirmday.text = '" + applyVo.directorsigndate.Value.ToString("dd") + "'");
            }
            if (lstExperts.Count > 0)
            {
                string conDesc = string.Empty;
                string conDoct = string.Empty;
                DateTime? dtmDoct = null;
                foreach (EntityBihSadcExperts item in lstExperts)
                {
                    conDesc += item.responsedesc + Environment.NewLine;
                    conDoct += item.expertname + " ";
                    dtmDoct = item.responsedate;
                }
                if (conDesc != string.Empty && dtmDoct != null)
                {
                    ds.Modify("lblcondesc.text = '" + conDesc + "'");
                    ds.Modify("lblcondoctname.text = '" + conDoct + "'");
                    ds.Modify("lblconyear.text = '" + dtmDoct.Value.ToString("yyyy") + "'");
                    ds.Modify("lblconmonth.text = '" + dtmDoct.Value.ToString("MM") + "'");
                    ds.Modify("lblconday.text = '" + dtmDoct.Value.ToString("dd") + "'");
                }
            }
            ds.Print();
        }
        #endregion

        #endregion

        #region 事件

        private void frmAntiApply_Load(object sender, EventArgs e)
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAidChooseDoct frm = new frmAidChooseDoct();
            frm.EmpTypeId = 1;
            if (frm.ShowDialog() == DialogResult.OK)
            {
                // 可能是多个医生ID
                DataTable dt = null;
                string[] doctIdArr = frm.DoctIDArr.Replace("'", "").Split(',');
                clsBIHOrderService svc = new clsDcl_GetSvcObject().m_GetOrderSvcObject();
                foreach (string doctId in doctIdArr)
                {
                    dt = svc.GetEmployeeByEmpId(doctId);
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        ListViewItem lvi = null;
                        foreach (DataRow dr2 in dt.Rows)
                        {
                            lvi = new ListViewItem(dr2["deptname_vchr"].ToString());
                            lvi.SubItems.Add(dr2["lastname_vchr"].ToString());
                            lvi.SubItems.Add(dr2["deptid_chr"].ToString());
                            lvi.SubItems.Add(dr2["empid_chr"].ToString());
                            this.lvExperts.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            this.lvExperts.Items.Remove(this.lvExperts.SelectedItems[0]);
        }

        private void chkYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkYes.Checked)
            {
                this.chkNo.Checked = false;
            }
        }

        private void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkNo.Checked)
            {
                this.chkYes.Checked = false;
            }
        }

        private void tsbNew_Click(object sender, EventArgs e)
        {
            this.New();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            this.Save();
        }

        private void tsbConfirm_Click(object sender, EventArgs e)
        {
            this.Confirm();
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
