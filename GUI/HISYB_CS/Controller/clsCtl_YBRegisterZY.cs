using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Data;
using System.Collections.Generic;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_YBRegisterZY : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsCtl_YBRegisterZY()
        {
        }
        public clsDcl_YB objDomain = new clsDcl_YB();

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmYBRegisterZY m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYBRegisterZY)frmMDI_Child_Base_in;
        }
        #endregion

        clsDGExtra_VO objDgextraVo = null;

        Dictionary<string, string> dicRYDYZDBY = new Dictionary<string, string>();

        /// <summary>
        /// 当前诊断控件: 1 主要诊断; 2 次要诊断(1); 3 次要诊断(2)
        /// </summary>
        internal int CurrDiagTxtIndex { get; set; }

        /// <summary>
        /// ICD.DataSource
        /// </summary>
        internal DataTable IcdDataSource { get; set; }

        #region 查找诊断
        /// <summary>
        /// 查找诊断
        /// </summary>
        /// <param name="findCode"></param>
        internal void FindICD(string findCode)
        {
            if (this.IcdDataSource == null || this.IcdDataSource.Rows.Count == 0) return;

            DataRow[] drr = null;
            if (findCode.Trim() == "")
            {
                drr = new DataRow[this.IcdDataSource.Rows.Count];
                for (int i = 0; i < this.IcdDataSource.Rows.Count; i++)
                {
                    drr[i] = this.IcdDataSource.Rows[i];
                }
            }
            else
            {
                string exp = "icdcode like '{0}%' or icdname like '{0}%' or pycode like '{0}%' ";
                exp = string.Format(exp, new string[3] { findCode, findCode, findCode });
                drr = this.IcdDataSource.Select(exp);
                if (drr == null || drr.Length == 0)
                {
                    MessageBox.Show("查无数据");
                    return;
                }
            }

            string icdCode = string.Empty;
            List<string> lstIcdCode = new List<string>();
            this.m_objViewer.lsvItemICD.BeginUpdate();
            this.m_objViewer.lsvItemICD.Items.Clear();
            foreach (DataRow dr in drr)
            {
                icdCode = dr["icdcode"].ToString();
                if (lstIcdCode.IndexOf(icdCode) < 0)
                {
                    lstIcdCode.Add(icdCode);
                    ListViewItem lv = new ListViewItem(icdCode);
                    lv.SubItems.Add(dr["icdname"].ToString());
                    lv.Tag = dr;
                    this.m_objViewer.lsvItemICD.Items.Add(lv);
                }
            }
            if (this.m_objViewer.lsvItemICD.Items.Count > 0)
            {
                if (CurrDiagTxtIndex == 1)
                {
                    this.m_objViewer.lsvItemICD.Height = 156;
                }
                else if (CurrDiagTxtIndex == 2)
                {
                    this.m_objViewer.lsvItemICD.Height = 116;
                }
                else if (CurrDiagTxtIndex == 3)
                {
                    this.m_objViewer.lsvItemICD.Height = 116;
                }
                this.m_objViewer.lsvItemICD.Items[0].Selected = true;
                this.m_objViewer.lsvItemICD.Focus();
            }

            this.m_objViewer.lsvItemICD.EndUpdate();
        }
        #endregion

        #region 选择诊断
        /// <summary>
        /// 选择诊断
        /// </summary>
        internal void SelectICD()
        {
            if (this.m_objViewer.lsvItemICD.Items.Count == 0 || this.m_objViewer.lsvItemICD.SelectedItems.Count == 0)
            {
                return;
            }
            DataRow dr = this.m_objViewer.lsvItemICD.SelectedItems[0].Tag as DataRow;
            if (CurrDiagTxtIndex == 1)
            {
                this.m_objViewer.txtMainDiag.Text = dr["icdname"].ToString();
                this.m_objViewer.txtMainDiag.Tag = dr;
                this.m_objViewer.txtMainDiag.Focus();
            }
            else if (CurrDiagTxtIndex == 2)
            {
                this.m_objViewer.txtSecDiag1.Text = dr["icdname"].ToString();
                this.m_objViewer.txtSecDiag1.Tag = dr;
                this.m_objViewer.txtSecDiag1.Focus();
            }
            else if (CurrDiagTxtIndex == 3)
            {
                this.m_objViewer.txtSecDiag2.Text = dr["icdname"].ToString();
                this.m_objViewer.txtSecDiag2.Tag = dr;
                this.m_objViewer.txtSecDiag2.Focus();
            }
        }
        #endregion

        #region 初始化界面
        /// <summary>
        /// 初始化界面
        /// </summary>
        public void m_mthInit()
        {
            try
            {
                if (string.IsNullOrEmpty(this.m_objViewer.strRegisterId))
                {
                    return;
                }
                this.m_objViewer.Cursor = Cursors.WaitCursor;
                this.m_objViewer.lsvItemICD.Height = 0;
                // ICD10字典表
                this.IcdDataSource = objDomain.GetIcd10();
                this.m_objViewer.txtCbdtcqbm.Text = "441925";  // 茶山

                long lngRes = -1;
                dicRYDYZDBY.Add("", "");
                dicRYDYZDBY.Add("疾病", "1");
                dicRYDYZDBY.Add("自我因素导致的伤害", "2");
                dicRYDYZDBY.Add("其他非第三方导致的伤害", "3");
                dicRYDYZDBY.Add("突发事件导致的伤害", "4");
                dicRYDYZDBY.Add("第三方导致的伤害（交通事故除外）", "5");
                dicRYDYZDBY.Add("交通事故", "6");

                foreach (string strKey in dicRYDYZDBY.Keys)
                {
                    this.m_objViewer.cobRYDYZDBY.Items.Add(strKey);
                }
                this.m_objViewer.cobRYDYZDBY.SelectedIndex = 0;

                this.m_objViewer.cboJZLB.SelectedIndex = -1;
                DataTable dtRegisterInfo = null;
                //need modify 补全下面datarow的赋值
                lngRes = this.objDomain.m_lngGetZYYBRegister(this.m_objViewer.strRegisterId, out dtRegisterInfo);
                if (dtRegisterInfo != null && dtRegisterInfo.Rows.Count > 0)
                {
                    if (m_lngLoadDataCtl() < 0)
                    {
                        MessageBox.Show("界面数据加载有误，请重新打开！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }

                    //初始化附加信息clsDGExtra_VO
                    objDgextraVo = new clsDGExtra_VO();
                    objDgextraVo.JBR = this.m_objViewer.LoginInfo.m_strEmpNo;
                    objDgextraVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne"); //医院编号
                    string strUser = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "USERNAMEZY", "AnyOne");
                    string strPwd = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "PASSWORDZY", "AnyOne");
                    lngRes = clsYBPublic_cs.m_lngUserLoin(strUser, strPwd, false);
                    if (lngRes < 0)
                    {
                        MessageBox.Show("界面数据加载有误，请重新打开！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    }
                    #region 调用1201查看病人基本信息
                    clsDGZydj_VO m_objItem = new clsDGZydj_VO();
                    //病人基本信息
                    clsDGPaitentInfo_VO m_objPatientInfo = new clsDGPaitentInfo_VO();
                    //继续诊疗信息
                    List<clsDGJxzlxx_VO> m_objJXzlxx = new List<clsDGJxzlxx_VO>();
                    //异地人员信息
                    List<clsDGYdryxx_VO> m_objYDryxx = new List<clsDGYdryxx_VO>();
                    //转院信息
                    List<clsDGZyxx_VO> m_objZYxx = new List<clsDGZyxx_VO>();
                    //最近住院信息
                    List<clsDGZjzyxx_VO> m_objZJzyxx = new List<clsDGZjzyxx_VO>();
                    m_objItem.GMSFHM = dtRegisterInfo.Rows[0]["idcard_chr"].ToString().Trim();
                    m_objItem.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne"); //医院编号
                    m_objItem.CBDTCQBM = dtRegisterInfo.Rows[0]["cbdtcqbm_vchr"].ToString();
                    m_objItem.LXDH = this.m_objViewer.LoginInfo.m_strEmpNo;
                    lngRes = clsYBPublic_cs.m_lngFunSP1201(m_objItem, out m_objPatientInfo, out m_objJXzlxx, out m_objYDryxx, out m_objZYxx, out m_objZJzyxx);
                    if (lngRes > 0)
                    {
                        if (m_objPatientInfo != null)
                        {
                            if (m_objPatientInfo.JSFS == "3")
                            {
                                if (MessageBox.Show("该病人的结算方式为：全部自费！ \n自费原因是：" + m_objPatientInfo.ZFYY.ToString() + ", 是否继续进行登记？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.No)
                                {
                                    return;
                                }
                            }
                            if (m_objPatientInfo.SBBZ.ToString().Trim() == "0")
                            {
                                MessageBox.Show("该病人的社保标志为0，当做自费病人处理，不做社保登记！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }
                        }
                    }
                    #endregion
                    DataRow drTemp = dtRegisterInfo.Rows[0];
                    if (drTemp["insdeptcode_vchr"].ToString() == null || drTemp["insdeptcode_vchr"].ToString() == "")
                    {
                        MessageBox.Show("病人所登记的入院科室:" + drTemp["deptname_vchr"].ToString() + " 关联不到社保科室，请联系管理员查看和维护！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return;
                    }
                    this.m_objViewer.strSBBZ = m_objPatientInfo.SBBZ.ToString();
                    this.m_objViewer.txtIDCard.Text = drTemp["idcard_chr"].ToString();//身份证号
                    this.m_objViewer.txtZYH.Text = drTemp["inpatientid_chr"].ToString();//住院号
                    this.m_objViewer.txtName.Text = drTemp["lastname_vchr"].ToString();//病人姓名
                    this.m_objViewer.txtDept.Text = drTemp["deptname_vchr"].ToString();//医院科室名称
                    this.m_objViewer.txtDept.Tag = drTemp["insdeptcode_vchr"].ToString();//t_ins_deptrel表中的社保科室id
                    this.m_objViewer.txtBedno.Text = drTemp["bed_no"].ToString();//床号
                    this.m_objViewer.txtDoctor.Value = drTemp["empno_chr"].ToString();//主治医生工号
                    this.m_objViewer.txtDoctor.Text = drTemp["doctorname_vchr"].ToString();//主治医生
                    this.m_objViewer.txtDoctor.Tag = drTemp["empno_chr"].ToString();//主治医生工号
                    //填充txtBedno，txtDoctor两个控件
                    this.m_objViewer.txtDept.Value = drTemp["areaid_chr"].ToString();

                    // 根据患者重新获取参保地编码 -- 异地医保
                    DataTable dtTmp = null;
                    this.objDomain.m_lngGetPatientInfo(drTemp["inpatientid_chr"].ToString(), "0", out dtTmp);
                    if (dtTmp != null && dtTmp.Rows.Count > 0)
                    {
                        this.m_objViewer.txtCbdtcqbm.Text = dtTmp.Rows[dtTmp.Rows.Count - 1]["CBDTCQBM_VCHR"].ToString();
                    }

                    this.m_mthFilterBed();
                    this.m_mthFilterDoc();
                    if (drTemp["cybz_vchr"] != null)
                    {
                        //this.m_objViewer.cboZYLB.Text = drTemp["zylb_vchr"].ToString();//住院类别
                        this.m_objViewer.cboCYBZ.SelectedIndex = 0;
                        for (int i = 0; i < this.m_objViewer.cboCYBZ.Items.Count; i++)
                        {
                            if (this.m_objViewer.cboCYBZ.Items[i].ToString().Trim().Split('-')[0].ToString().Equals(drTemp["cybz_vchr"].ToString()))
                            {
                                this.m_objViewer.cboCYBZ.SelectedIndex = i;
                            }
                        }
                    }
                    if (drTemp["zylb_vchr"] != null)
                    {
                        //this.m_objViewer.cboZYLB.Text = drTemp["zylb_vchr"].ToString();//住院类别
                        for (int i = 0; i < this.m_objViewer.cboZYLB.Items.Count; i++)
                        {
                            if (this.m_objViewer.cboZYLB.Items[i].ToString().Trim().Split('-')[0].ToString().Equals(drTemp["zylb_vchr"].ToString()))
                            {
                                this.m_objViewer.cboZYLB.SelectedIndex = i;
                            }
                        }
                    }
                    if (drTemp["jzlb_vchr"] != null)
                    {
                        //this.m_objViewer.cboJZLB.SelectedValue = drTemp["jzlb_vchr"].ToString();//就诊类别
                        for (int i = 0; i < this.m_objViewer.cboJZLB.Items.Count; i++)
                        {
                            if (this.m_objViewer.cboJZLB.Items[i].ToString().Trim().Split('-')[0].ToString().Equals(drTemp["jzlb_vchr"].ToString()))
                            {
                                this.m_objViewer.cboJZLB.SelectedIndex = i;
                            }
                        }
                    }
                    if (drTemp["wsbz_vchr"] != null)
                    {
                        //this.m_objViewer.cboWSBZ.Text = drTemp["wsbz_vchr"].ToString();//外伤标志
                        for (int i = 0; i < this.m_objViewer.cboWSBZ.Items.Count; i++)
                        {
                            if (this.m_objViewer.cboWSBZ.Items[i].ToString().Trim().Split('-')[0].ToString().Equals(drTemp["wsbz_vchr"].ToString()))
                            {
                                this.m_objViewer.cboWSBZ.SelectedIndex = i;
                            }
                        }
                    }
                    //"住院类别" == "2-工伤"
                    if (drTemp["zqqrqk_vchr"] != null)
                    {
                        //this.m_objViewer.cboZQQRQK.Text = drTemp["zqqrqk_vchr"].ToString();//知情确认情况 //（住院类别为工伤时，默认录入1、同意，且不可改变）住院类别为医疗时必须录入
                        for (int i = 0; i < this.m_objViewer.cboZQQRQK.Items.Count; i++)
                        {
                            if (this.m_objViewer.cboZQQRQK.Items[i].ToString().Trim().Split('-')[0].ToString().Equals(drTemp["zqqrqk_vchr"].ToString()))
                            {
                                this.m_objViewer.cboZQQRQK.SelectedIndex = i;
                            }
                        }
                        if (this.m_objViewer.cboZYLB.SelectedIndex == 1)
                        {
                            this.m_objViewer.cboZQQRQK.Enabled = false;
                        }
                        else
                        {
                            this.m_objViewer.cboZQQRQK.Enabled = true;
                        }
                    }

                    this.m_objViewer.txtZQQRSBH.Text = drTemp["zqqrsbh_vchr"].ToString();//知情确认书编号
                    this.m_objViewer.txtPhone.Text = drTemp["contactphone"].ToString();//联系电话
                    this.m_objViewer.dtmInHospitalDate.Value = Convert.ToDateTime(drTemp["inpatient_dat"].ToString());//入院日期YYYYMMDD，不能大于当前日期

                    this.m_objViewer.txtDiagnsis.Text = drTemp["mzdiagnose_vchr"].ToString();//入院诊断
                    if (drTemp["jzjlh_vchr"] != null)
                    {
                        this.m_objViewer.txtJZJLH.Text = drTemp["jzjlh_vchr"].ToString();//医保登记返回的就诊记录号
                    }

                    //入院第一诊断病因
                    if (drTemp["rydyzdby_vchr"] != null)
                    {
                        foreach (string strKey in dicRYDYZDBY.Keys)
                        {
                            if (dicRYDYZDBY[strKey] == drTemp["rydyzdby_vchr"].ToString())
                            {
                                this.m_objViewer.cobRYDYZDBY.SelectedItem = strKey;
                                break;
                            }
                        }
                    }

                    #region 异地医保

                    string icd10Code = string.Empty;
                    DataRow[] drr = null;
                    // 主要诊断
                    if (drTemp["icd10_1"] != null && this.IcdDataSource != null && this.IcdDataSource.Rows.Count > 0)
                    {
                        icd10Code = drTemp["icd10_1"].ToString();
                        drr = this.IcdDataSource.Select("icdcode = '" + icd10Code + "'");
                        if (drr != null && drr.Length > 0)
                        {
                            this.m_objViewer.txtMainDiag.Text = drr[0]["icdname"].ToString();
                            this.m_objViewer.txtMainDiag.Tag = drr[0];
                        }
                    }
                    // 次要诊断1
                    if (drTemp["icd10_2"] != null && this.IcdDataSource != null && this.IcdDataSource.Rows.Count > 0)
                    {
                        icd10Code = drTemp["icd10_2"].ToString();
                        drr = this.IcdDataSource.Select("icdcode = '" + icd10Code + "'");
                        if (drr != null && drr.Length > 0)
                        {
                            this.m_objViewer.txtSecDiag1.Text = drr[0]["icdname"].ToString();
                            this.m_objViewer.txtSecDiag1.Tag = drr[0];
                        }
                    }
                    // 次要诊断2
                    if (drTemp["icd10_3"] != null && this.IcdDataSource != null && this.IcdDataSource.Rows.Count > 0)
                    {
                        icd10Code = drTemp["icd10_3"].ToString();
                        drr = this.IcdDataSource.Select("icdcode = '" + icd10Code + "'");
                        if (drr != null && drr.Length > 0)
                        {
                            this.m_objViewer.txtSecDiag2.Text = drr[0]["icdname"].ToString();
                            this.m_objViewer.txtSecDiag2.Tag = drr[0];
                        }
                    }
                    // 入院原因
                    if (drTemp["inreason"] != null)
                    {
                        this.m_objViewer.cboZyyy.SelectedIndex = 0;
                        for (int i = 1; i < this.m_objViewer.cboZyyy.Items.Count; i++)
                        {
                            if (this.m_objViewer.cboZyyy.Items[i].ToString().Trim().Split('-')[0].ToString().Equals(drTemp["inreason"].ToString()))
                            {
                                this.m_objViewer.cboZyyy.SelectedIndex = i;
                            }
                        }
                    }
                    // 补助类型
                    if (drTemp["assitype"] != null)
                    {
                        this.m_objViewer.cboBzlx.SelectedIndex = 0;
                        for (int i = 1; i < this.m_objViewer.cboBzlx.Items.Count; i++)
                        {
                            if (this.m_objViewer.cboBzlx.Items[i].ToString().Trim().Split('-')[0].ToString().Equals(drTemp["assitype"].ToString()))
                            {
                                this.m_objViewer.cboBzlx.SelectedIndex = i;
                            }
                        }
                    }
                    // 出院原因
                    if (drTemp["outstatus"] != null)
                    {
                        this.m_objViewer.cboCyyy.SelectedIndex = 0;
                        for (int i = 1; i < this.m_objViewer.cboCyyy.Items.Count; i++)
                        {
                            if (this.m_objViewer.cboCyyy.Items[i].ToString().Trim().Split('-')[0].ToString().Equals(drTemp["outstatus"].ToString()))
                            {
                                this.m_objViewer.cboCyyy.SelectedIndex = i;
                            }
                        }
                    }
                    #endregion

                    if (string.IsNullOrEmpty(this.m_objViewer.txtJZJLH.Text))//如果查询出来的就诊记录号为空，说明是新医保登记
                    {
                        this.m_objViewer.btnYBReg.Tag = "Register";
                        this.m_objViewer.btnYBCancelReg.Enabled = false;
                        this.m_objViewer.btnYBModifyReg.Enabled = false;

                    }
                    else//如果查询出来的就诊记录号为空，说明是修改医保登记信息
                    {
                        //医保已登记
                        this.m_objViewer.btnYBReg.Tag = "Modify";
                        this.m_objViewer.lblTitle.Text = "医保病人住院登记(修改)";
                        this.m_objViewer.btnYBReg.Enabled = false;
                        this.m_objViewer.cboCYBZ.Enabled = true;

                    }
                }
            }
            finally
            {
                this.m_objViewer.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region 加载控件数据
        /// <summary>
        /// 加载控件数据
        /// </summary>
        /// <returns></returns>
        private long m_lngLoadDataCtl()
        {
            try
            {
                // 病区列表
                clsColumns_VO[] columArr = new clsColumns_VO[]{
                new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("病区名称","deptname_vchr",HorizontalAlignment.Left,130)
                };
                m_objViewer.txtDept.m_strSQL = @"select   deptid_chr, deptname_vchr, pycode_chr, code_vchr
                                                    from t_bse_deptdesc t1
                                                   where attributeid = '0000003' and status_int = 1
                                                order by code_vchr";
                m_objViewer.txtDept.m_mthInitListView(columArr);

                //获取床位列表
                columArr = new clsColumns_VO[]{
                new clsColumns_VO("科室ID","areaid_chr",HorizontalAlignment.Left,0),
                new clsColumns_VO("床位ID","bedid_chr",HorizontalAlignment.Left,0),
                new clsColumns_VO("床位号","code_chr",HorizontalAlignment.Left,60)
                };
                m_objViewer.txtBedno.m_strSQL = @"select areaid_chr,bedid_chr,code_chr from t_bse_bed where status_int=1 and areaid_chr='0000209' order by bedid_chr,bed_no";
                m_objViewer.txtBedno.m_mthInitListView(columArr);

                //获取主治医生列表
                columArr = new clsColumns_VO[]{
                new clsColumns_VO("工号","empno_chr",HorizontalAlignment.Left,50),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("姓名","doctorname",HorizontalAlignment.Left,80),
                };
                m_objViewer.txtDoctor.m_strSQL = @"select distinct t1.empid_chr,
                                                                    t2.empno_chr,
                                                                    t2.pycode_chr,
                                                                    t2.lastname_vchr as doctorname
                                                      from t_bse_deptemp t1, t_bse_employee t2
                                                     where t2.hasprescriptionright_chr = 1
                                                       and t2.status_int = 1
                                                       and t1.empid_chr = t2.empid_chr
                                                     order by t2.empno_chr";
                m_objViewer.txtDoctor.m_mthInitListView(columArr);
            }
            catch (Exception)
            {
                return -1;
            }
            return 1;
        }
        #endregion

        #region 验证界面上的控件
        /// <summary>
        /// 验证界面上的控件
        /// </summary>
        /// <returns></returns>
        private long m_lngCheckCtl()
        {
            foreach (System.Windows.Forms.Control c in m_objViewer.patientinto.Controls)
            {
                if (c.Name == "txtIDCard" && c.Text.Trim().Length == 0)
                {
                    MessageBox.Show("病人身份证不能为空，请填写！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return -1;
                }
                if (c.Name == "txtZYH" && c.Text.Trim().Length == 0)
                {
                    MessageBox.Show("病人住院号不能为空，请填写！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return -1;
                }
                if (c.Name == "txtName" && c.Text.Trim().Length == 0)
                {
                    MessageBox.Show("病人姓名不能为空，请填写！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return -1;
                }
                if (c.Name == "txtDept" && c.Text.Trim().Length == 0)
                {
                    MessageBox.Show("科室名称不能为空，请填写！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return -1;
                }
                //if (c.Name == "txtBedno" && c.Text.Trim().Length == 0)
                //{
                //    MessageBox.Show("床位号不能为空，请选择！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //    return -1;
                //}
                //if (c.Name == "txtDoctor" && c.Text.Trim().Length == 0)
                //{
                //    MessageBox.Show("主治医生不能为空，请填写！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //    return -1;
                //}
                if (c.Name == "cboZYLB")
                {
                    if (c.Text.Trim().Length == 0)
                    {
                        MessageBox.Show("住院类别不能为空，请选择！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        return -1;
                    }
                    else if (c.Text.Trim() == "2-工伤住院")
                    {
                        this.m_objViewer.cboZQQRQK.Text = "1-同意";
                        this.m_objViewer.cboZQQRQK.Enabled = false;
                    }
                    else if (c.Text.Trim() == "1-医疗住院")
                    {
                        if (string.IsNullOrEmpty(this.m_objViewer.cboZQQRQK.Text))
                        {
                            MessageBox.Show("知情确认情况为空，请填写！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            this.m_objViewer.cboZQQRQK.Focus();
                            return -1;
                        }
                        if (this.m_objViewer.cobRYDYZDBY.SelectedIndex == 0)
                        {
                            MessageBox.Show("医疗住院必须填写入院第一诊断病因！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            this.m_objViewer.cobRYDYZDBY.Focus();
                            return -1;
                        }
                    }
                }
                if (c.Name == "cboJZLB" && c.Text.Trim().Length == 0)
                {
                    MessageBox.Show("就诊类别不能为空，请选择！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return -1;
                }
                if (c.Name == "txtPhone" && c.Text.Trim().Length == 0)
                {
                    MessageBox.Show("联系电话不能为空，请填写！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return -1;
                }
                if (c.Name == "txtDiagnsis" && c.Text.Trim().Length == 0)
                {
                    MessageBox.Show("诊断信息不能为空，请填写！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return -1;
                }
                if (c.Name == "dtmInHospitalDate" && c.Text.Trim().Length == 0)
                {
                    MessageBox.Show("就诊(入院)日期不能为空，请选择！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    return -1;
                }
            }
            if (this.m_objViewer.btnYBReg.Tag == null)
            {
                return -1;
            }
            return 1;
        }
        #endregion

        #region 住院医保登记
        /// <summary>
        /// 住院医保登记
        /// </summary>
        public void m_mthYbReg()
        {
            if (m_lngCheckCtl() < 0)
            {
                return;
            }

            //need modify 登记VO赋值
            #region 医保住院登记VO赋值

            string bedNo = this.m_objViewer.txtBedno.Text.Trim();
            if (bedNo == string.Empty) bedNo = "9999";      // 入院登记时没有安排床号.暂定为9999

            string doctNo = this.m_objViewer.txtDoctor.Value.ToString();
            if (doctNo == string.Empty) doctNo = "0000";    // 入院登记时没有指定主治医师.暂定为0000

            clsDGZydj_VO objDgzydjVo = new clsDGZydj_VO();
            objDgzydjVo.GMSFHM = this.m_objViewer.txtIDCard.Text.Trim();
            objDgzydjVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne"); ;//住院医院编号
            objDgzydjVo.ZYH = this.m_objViewer.txtZYH.Text.Trim();
            objDgzydjVo.ZYKS = this.m_objViewer.txtDept.Tag.ToString().Trim();//t_ins_deptrel表中的社保科室id
            objDgzydjVo.YYRYKS = this.m_objViewer.txtDept.Text.Trim();//医院自己命名的科室名称
            objDgzydjVo.CWH = bedNo;
            objDgzydjVo.RYRQ = Convert.ToDateTime(this.m_objViewer.dtmInHospitalDate.Text.Trim()).ToString("yyyyMMdd");
            objDgzydjVo.ZYLB = this.m_objViewer.cboZYLB.Text.Trim().Split('-')[0].ToString();
            objDgzydjVo.JZLB = this.m_objViewer.cboJZLB.Text.Trim().Split('-')[0].ToString();
            objDgzydjVo.RYZD = this.m_objViewer.txtDiagnsis.Text.Trim();
            objDgzydjVo.WSBZ = string.Empty;
            objDgzydjVo.ZQQRQK = this.m_objViewer.cboZQQRQK.Text.Trim().Split('-')[0].ToString();
            objDgzydjVo.ZQQRSBH = this.m_objViewer.txtZQQRSBH.Text.Trim();
            objDgzydjVo.YSGH = doctNo;
            objDgzydjVo.LXDH = this.m_objViewer.txtPhone.Text.Trim();
            objDgzydjVo.CYBZ = this.m_objViewer.cboCYBZ.Text.Trim().Split('-')[0].ToString();
            objDgzydjVo.YYCYKS = this.m_objViewer.txtcyks.Text.Trim();
            objDgzydjVo.CYRQ = Convert.ToDateTime(this.m_objViewer.dtmOutHospitalDate.Text.Trim()).ToString("yyyyMMdd");
            objDgextraVo.JZJLH = this.m_objViewer.txtJZJLH.Text.Trim();
            objDgzydjVo.BZ = "";
            objDgzydjVo.CBDTCQBM = this.m_objViewer.txtCbdtcqbm.Text.Trim();    // 【异地就医平台预留字段】例：440600	佛山市
            objDgzydjVo.SBBZ = this.m_objViewer.strSBBZ;
            objDgzydjVo.RYDYZDBY = dicRYDYZDBY[this.m_objViewer.cobRYDYZDBY.SelectedItem.ToString()];

            #region 异地医保
            DataRow dr = null;
            if (this.m_objViewer.txtMainDiag.Tag != null)
            {
                dr = this.m_objViewer.txtMainDiag.Tag as DataRow;
                objDgzydjVo.Icd10_1 = dr["icdcode"].ToString();
            }
            if (this.m_objViewer.txtSecDiag1.Tag != null)
            {
                dr = this.m_objViewer.txtSecDiag1.Tag as DataRow;
                objDgzydjVo.Icd10_2 = dr["icdcode"].ToString();
            }
            if (this.m_objViewer.txtSecDiag2.Tag != null)
            {
                dr = this.m_objViewer.txtSecDiag2.Tag as DataRow;
                objDgzydjVo.Icd10_3 = dr["icdcode"].ToString();
            }
            if (this.m_objViewer.cboZyyy.SelectedIndex > 0)
            {
                objDgzydjVo.InReason = this.m_objViewer.cboZyyy.Text.Trim().Split('-')[0].ToString();
            }
            else
            {
                objDgzydjVo.InReason = string.Empty;
            }
            if (this.m_objViewer.cboBzlx.SelectedIndex > 0)
            {
                objDgzydjVo.AssiType = this.m_objViewer.cboBzlx.Text.Trim().Split('-')[0].ToString();
            }
            else
            {
                objDgzydjVo.AssiType = string.Empty;
            }
            if (this.m_objViewer.cboCyyy.SelectedIndex > 0)
            {
                objDgzydjVo.OutStatus = this.m_objViewer.cboCyyy.Text.Trim().Split('-')[0].ToString();
            }
            else
            {
                objDgzydjVo.OutStatus = string.Empty;
            }
            #endregion
            #endregion
            if (this.m_objViewer.btnYBReg.Tag.ToString() == "Register")
            {
                //医保登记
                string strJzjlhTemp = string.Empty;
                long lngRes = clsYBPublic_cs.m_lngFunSP3001(objDgzydjVo, objDgextraVo, ref strJzjlhTemp);
                if (lngRes > 0)
                {
                    //医保登记成功 保存医保返回的就诊记录号JZJLH
                    this.m_objViewer.txtJZJLH.Text = strJzjlhTemp;
                    lngRes = this.objDomain.m_lngSaveYBZYRegInfo(this.m_objViewer.strRegisterId, strJzjlhTemp, this.m_objViewer.LoginInfo.m_strEmpID, objDgzydjVo);
                    if (lngRes > 0)
                    {
                        MessageBox.Show("医保住院登记成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.m_objViewer.btnYBReg.Enabled = false;
                        this.m_objViewer.btnYBModifyReg.Enabled = true;
                    }
                }
                else
                {
                    MessageBox.Show("医保住院登记失败，请稍后再试！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
            else if (this.m_objViewer.btnYBReg.Tag.ToString() == "Modify")
            {
                // 护士(病区)修改
                if (this.m_objViewer.IsNurseModify)
                {
                    string jbrNo = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "JBRNO", "AnyOne");  // 经办人工号
                    objDgextraVo.JBR = string.IsNullOrEmpty(jbrNo) ? "049" : jbrNo;
                }
                //医保登记信息修改.need modify。医保可选功能【修改住院登记信息[SP3_3009]】，后期可酌情增加该功能
                long lngRes = clsYBPublic_cs.m_lngFunSP3009(objDgzydjVo, objDgextraVo);
                if (lngRes > 0)
                {
                    //医保登记信息修改
                    lngRes = this.objDomain.m_lngUpdateYBZYRegInfo(this.m_objViewer.strRegisterId, objDgzydjVo, objDgextraVo);
                    if (lngRes > 0)
                    {
                        MessageBox.Show("医保住院登记信息修改成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        this.m_objViewer.btnYBModifyReg.Enabled = false;
                        if (this.m_objViewer.IsNurseModify)
                        {
                            this.m_objViewer.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("医保住院登记信息修改失败，请稍后再试！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
        #endregion

        #region 过滤床位
        /// <summary>
        /// 过滤床位
        /// </summary>
        public void m_mthFilterBed()
        {
            string areaID = string.Empty;
            if (this.m_objViewer.txtDept.Value != null)
            {
                areaID = this.m_objViewer.txtDept.Value.ToString();
            }

            if (string.IsNullOrEmpty(areaID))
            {
                areaID = "0000330";
            }
            m_objViewer.txtBedno.m_strSQL = @"select areaid_chr,bedid_chr,code_chr from t_bse_bed where status_int=1 and areaid_chr='" + areaID + @"'order by bedid_chr,bed_no";
            m_objViewer.txtBedno.m_mthGetData();
        }
        #endregion

        #region 主治医生过滤
        /// <summary>
        /// 主治医生过滤
        /// </summary>
        public void m_mthFilterDoc()
        {
            string areaID = string.Empty;
            if (this.m_objViewer.txtDept.Value != null)
            {
                areaID = this.m_objViewer.txtDept.Value.ToString();
            }

            if (string.IsNullOrEmpty(areaID))
            {
                areaID = "0000330";
            }
            m_objViewer.txtDoctor.m_strSQL = @"select distinct t1.empid_chr,
                                                                    t2.empno_chr,
                                                                    t2.pycode_chr,
                                                                    t2.lastname_vchr as doctorname
                                                      from t_bse_deptemp t1, t_bse_employee t2
                                                     where t2.hasprescriptionright_chr = 1
                                                       and t2.status_int = 1
                                                       and t1.empid_chr = t2.empid_chr
                                                       and t1.deptid_chr = '" + areaID + @"'
                                                     order by t2.empno_chr";
            m_objViewer.txtDoctor.m_mthGetData();
        }
        #endregion

        #region 跨省异地卡鉴权
        /// <summary>
        /// 跨省异地卡鉴权
        /// </summary>
        internal void Ksydkjq()
        {
            if (m_lngCheckCtl() < 0)
            {
                return;
            }

            string uri = string.Empty;
            string JBR = this.m_objViewer.LoginInfo.m_strEmpNo;
            clsDGZydj_VO vo = new clsDGZydj_VO();
            vo.GMSFHM = this.m_objViewer.txtIDCard.Text.Trim();
            vo.JZLB = this.m_objViewer.cboJZLB.Text.Trim().Split('-')[0].ToString();
            vo.RYRQ = Convert.ToDateTime(this.m_objViewer.dtmInHospitalDate.Text.Trim()).ToString("yyyyMMdd");
            vo.CBDTCQBM = this.m_objViewer.txtCbdtcqbm.Text.Trim();
            vo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");  // 住院医院编号
            clsYBPublic_cs.SP3_5002(vo, JBR, out  uri);
            if (!string.IsNullOrEmpty(uri))
            {
                frmUri frm = new frmUri("跨省异地卡鉴权", uri);
                frm.ShowDialog();
            }
        }
        #endregion
    }
}
