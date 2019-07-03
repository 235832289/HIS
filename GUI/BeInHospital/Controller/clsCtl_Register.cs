using System;
using System.Collections;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Xml;
using System.IO;
using com.digitalwave.iCare.middletier.HIS;
using System.Text.RegularExpressions;
using ControlLibrary;
using System.Collections.Generic;


namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 入院登记控制层
    /// </summary>
    public class clsCtl_Register : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        com.digitalwave.iCare.gui.HIS.clsDcl_Register m_objRegister = null;
        clsDcl_BedAdmin m_objBedAdmin = null;
        clsDcl_BIHTransfer m_objTran = null;
        public string m_strOperatorID;
        /// <summary>
        /// 入院登记流水号
        /// </summary>
        public string m_strRegisterID = "";
        /// <summary>
        /// 病人编号
        /// </summary>
        public string m_strPatientID = "";
        /// <summary>
        /// 住院号
        /// </summary>
        public string m_strInPatientID = "";
        /// <summary>
        ///  住院留观号
        /// </summary>
        private string m_strINPATIENTTEMPID = "";
        /// <summary>
        /// 住院状态	{-1=首次入院;0=未上床;1=已上床;2=预出院;3=实际出院}
        /// </summary>
        public int m_intPStatus = -1;
        /// <summary>
        /// 门诊建议预交金
        /// </summary>
        public string m_strCLINICSAYPREPAY = "";
        /// <summary>
        /// 标识:1-首次入院；、2-再次入院
        /// </summary>
        private int m_intFlag = 1;
        /// <summary>
        /// 是否获取新住院号
        /// </summary>
        private bool m_blnNewInPatienID = true;
        /// <summary>
        /// 控制入院登记带*号的项是否必填:0-可不填 1-必须填
        /// </summary>
        private int m_intNeedInput = 0;
        /// <summary>
        /// 新病人标识:1-新病人(没有病人基本资料)需要病人资料登记,2-已有病人基本资料,不需要病人资料登记
        /// </summary>
        private int m_intNewPatient = 1;
        /// <summary>
        /// 当前病人身份标识:0-普通 1-公费 2-医保 3-特困 4-应该是老人
        /// </summary>
        private int m_intPatientFlag = 0;

        //预交金处理标志 0 处理预交金，1不处理
        private int m_disPrepayFalg = 0;

        /// <summary>
        /// 入院登记住院号生成方式 1 自动 2 手动
        /// </summary>
        private int m_disCreatNOFlag = 1;

        com.digitalwave.iCare.gui.Systempower.clsSystemPower_base objsystempower;

        #endregion

        #region 构造函数
        public clsCtl_Register()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objRegister = new com.digitalwave.iCare.gui.HIS.clsDcl_Register();
            m_objBedAdmin = new clsDcl_BedAdmin();
            m_objTran = new clsDcl_BIHTransfer();
            m_strOperatorID = "0000001";
            objsystempower = new com.digitalwave.iCare.gui.Systempower.clsSystemPower_base(m_strOperatorID);
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmPatientRecord m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPatientRecord)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void m_mthInit()
        {
            //获取主治医生列表
            clsColumns_VO[] columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("工号","empno_chr",HorizontalAlignment.Left,50),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("姓名","doctorname",HorizontalAlignment.Left,80),
           };
            m_objViewer.m_txtMaindoctor.m_strSQL = @"SELECT   t1.empid_chr, t1.empno_chr, t1.pycode_chr,
                                                             t1.lastname_vchr AS doctorname
                                                        FROM t_bse_employee t1
                                                       WHERE status_int = 1 AND hasprescriptionright_chr = '1'
                                                    ORDER BY t1.empno_chr";
            m_objViewer.m_txtMaindoctor.m_mthInitListView(columArr);

            // 病区列表
            columArr = new clsColumns_VO[]{
                new clsColumns_VO("编号","code_vchr",HorizontalAlignment.Left,50),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("病区名称","deptname_vchr",HorizontalAlignment.Left,130)
            };
            m_objViewer.m_txtAREAID.m_strSQL = @"SELECT   deptid_chr, deptname_vchr, pycode_chr, code_vchr
                                                    FROM t_bse_deptdesc t1
                                                   WHERE attributeid = '0000003' AND status_int = 1
                                                ORDER BY code_vchr";
            m_objViewer.m_txtAREAID.m_mthInitListView(columArr);


            //民簇
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("编号","dictdefinecode_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("民簇","dictname_vchr",HorizontalAlignment.Left,60)
            };
            m_objViewer.m_txtRace.m_strSQL = @"SELECT   a.dictdefinecode_vchr, a.wbcode_chr, a.pycode_chr, a.dictname_vchr
                                                    FROM t_aid_dict a
                                                   WHERE dictid_chr != '0' AND dictkind_chr = '1'
                                                ORDER BY TO_NUMBER (dictdefinecode_vchr)";
            m_objViewer.m_txtRace.m_mthInitListView(columArr);

            //费用类别
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("编号","paytypeno_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("费用类别","paytypename_vchr",HorizontalAlignment.Left,140)
            };
            m_objViewer.m_txtPaytype.m_strSQL = @"SELECT   paytypeid_chr, paytypeno_vchr, paytypename_vchr, bihlimitrate_dec,
                                                         internalflag_int
                                                    FROM t_bse_patientpaytype
                                                   WHERE payflag_dec != 1 AND isusing_num != 0
                                                ORDER BY paytypeno_vchr";
            m_objViewer.m_txtPaytype.m_mthInitListView(columArr);

            //病人身份
//            columArr = new clsColumns_VO[]
//            {
//                new clsColumns_VO("身份ID","paytypeid_chr",HorizontalAlignment.Left,0),
//                new clsColumns_VO("编号","paytypeno_vchr",HorizontalAlignment.Left,40),
//                new clsColumns_VO("身份","paytypename_vchr",HorizontalAlignment.Left,140)
//            };
//            m_objViewer.m_txtPatiemtType.m_strSQL = @"SELECT   paytypeid_chr, paytypeno_vchr, paytypename_vchr
//                                                        FROM t_bse_patientpaytype
//                                                       WHERE payflag_dec != 1 AND isusing_num != 0
//                                                    ORDER BY paytypeno_vchr";
//            m_objViewer.m_txtPatiemtType.m_mthInitListView(columArr);

            //职业
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("编号","dictdefinecode_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("职业","dictname_vchr",HorizontalAlignment.Left,80)
            };
            m_objViewer.m_txtOccupation.m_strSQL = @"SELECT   '0' AS dictdefinecode_vchr, '' AS wbcode_chr, '' AS pycode_chr,
                                                             '' AS dictname_vchr
                                                        FROM DUAL
                                                    UNION ALL
                                                    SELECT   a.dictdefinecode_vchr, a.wbcode_chr, a.pycode_chr, a.dictname_vchr
                                                        FROM t_aid_dict a
                                                       WHERE dictid_chr != '0' AND dictkind_chr = '9'";
            m_objViewer.m_txtOccupation.m_mthInitListView(columArr);

            //关系
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("编号","dictdefinecode_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("关系","dictname_vchr",HorizontalAlignment.Left,60)
            };
            m_objViewer.m_txtRelation.m_strSQL = @"SELECT   '0' AS dictdefinecode_vchr, '' AS wbcode_chr, '' AS pycode_chr,
                                                             '' AS dictname_vchr
                                                        FROM DUAL
                                                    UNION ALL
                                                    SELECT   a.dictdefinecode_vchr, a.wbcode_chr, a.pycode_chr, a.dictname_vchr
                                                        FROM t_aid_dict a
                                                       WHERE dictid_chr != '0' AND dictkind_chr = '4'";
            m_objViewer.m_txtRelation.m_mthInitListView(columArr);

            //初始化国籍类别下拉框
            clsAIDDICT_VO[] objAIDDICTArr = null;
            m_objTran.m_lngGetAID_DICTArr(2, out objAIDDICTArr);
            m_objViewer.txtNationality.DataSource = objAIDDICTArr;
            m_objViewer.txtNationality.DisplayMember = "m_strGetCodeAndName";
            m_objViewer.txtNationality.ValueMember = "m_strGetDICTNAME_VCHR";

            //初始化婚否下拉框
            m_objTran.m_lngGetAID_DICTArr(5, out objAIDDICTArr);
            m_objViewer.cobMarried.DataSource = objAIDDICTArr;
            m_objViewer.cobMarried.ValueMember = "m_strGetDICTNAME_VCHR";
            m_objViewer.cobMarried.DisplayMember = "m_strGetCodeAndName";

            // 添加"病人来源"项  陈世春修改于2010\8\6
            m_objTran.m_lngGetAID_DICTArr(23, out objAIDDICTArr);
            m_objViewer.m_cboPatientSource.DataSource = objAIDDICTArr;
            m_objViewer.m_cboPatientSource.ValueMember = "m_strGetDICTNAME_VCHR";
            m_objViewer.m_cboPatientSource.DisplayMember = "m_strGetCodeAndName";

            //初始化性别下拉框
            m_objTran.m_lngGetAID_DICTArr(10, out objAIDDICTArr);
            m_objViewer.cboSex.DataSource = objAIDDICTArr;
            m_objViewer.cboSex.ValueMember = "m_strGetDICTNAME_VCHR";
            m_objViewer.cboSex.DisplayMember = "m_strGetCodeAndName";

            m_objTran.m_lngGetSetingByID("1006", out m_intNeedInput);

            m_strOperatorID = m_objViewer.LoginInfo.m_strEmpID;
            m_objViewer.m_cboCUYCATE_INT.SelectedIndex = 0;
            m_objViewer.m_cobPrint.SelectedIndex = 0;
            m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
            m_objViewer.cboSex.SelectedIndex = 0;
            m_objViewer.m_cboPatientSource.SelectedValue = "本镇区";
            m_objViewer.m_txtRace.Text = "汉族";
            m_objViewer.txtNationality.SelectedValue = "中国";
            m_objViewer.cobMarried.SelectedIndex = 0;
            m_objViewer.m_cboTYPE_INT.SelectedIndex = 0;
            m_objViewer.m_cboSTATE_INT.SelectedIndex = 2;
            m_objViewer.m_cmbFindType.SelectedIndex = 0;
            m_objViewer.cboIsemployee.SelectedIndex = 0;
            m_objViewer.m_dtpBirthDate.Text = "1900-01-01";
            m_objViewer.m_txtAge.Text = "0天";
            m_strReadInvoiceNO();

            //读系统配置，是否处理预交金
            this.m_objTran.m_lngGetSetingByID("1057", out this.m_disPrepayFalg);
            if (this.m_disPrepayFalg != 1)
                this.m_disPrepayFalg = 0;

            if (this.m_disPrepayFalg == 1)
            {
                this.m_objViewer.m_txtMONEY_DEC.Enabled = false;
                this.m_objViewer.m_cboCUYCATE_INT.Enabled = false;
                this.m_objViewer.m_txtPREPAYINV_VCHR.Enabled = false;
                this.m_objViewer.m_cobPrint.Enabled = false;
            }

            //设定入院登记住院号生成方式 1 自动 2 手动
            this.m_objTran.m_lngGetSetingByID("1064", out this.m_disCreatNOFlag);
            this.m_mthInitYB();
        }
        #endregion

        #region 病人登记
        /// <summary>
        /// 病人登记
        /// </summary>
        public void m_mthPationRecord()
        {
            m_objViewer.Cursor = Cursors.WaitCursor;
            com.digitalwave.iCare.gui.Patient.frmPatient frm = new com.digitalwave.iCare.gui.Patient.frmPatient(1, m_objViewer.txtPatientName.Text.Trim(), m_objViewer.cboSex.Text.Trim());
            frm.LoginInfo = this.m_objViewer.LoginInfo;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK || frm.DialogResult == DialogResult.Yes)
            {
                m_strPatientID = frm.m_strPatientID;
                m_mthFindPatientInfoByPatientID();
            }
            frm = null;
            m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region	查找病人
        /// <summary>
        /// 查找病人
        /// </summary>
        public void m_mthFindPatient()
        {
            frmCommonFind frm = new frmCommonFind();
            frm.IsBihReg = true;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                m_strPatientID = frm.PatientID;
                m_mthFindPatientInfoByPatientID();
            }
            frm = null;
        }
        #endregion

        #region 获取门诊转入病人信息
        /// <summary>
        /// 获取门诊转入病人信息
        /// </summary>
        public void m_mthGetTurnInPatienList()
        {
            DataTable m_dtbReselt;
            long lngRes = m_objRegister.m_lngGetTurnInPatienList(out m_dtbReselt);
            if (lngRes > 0)
            {
                ListViewItem tempItem;
                m_objViewer.m_lsvTurnInPation.Items.Clear();
                for (int i1 = 0; i1 < m_dtbReselt.Rows.Count; i1++)
                {
                    tempItem = new ListViewItem(m_dtbReselt.Rows[i1]["patientcardid_chr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["inpatientid_chr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["deptname_vchr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["patientname"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["sex_chr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["state_int"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["paytypename_vchr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["doctername"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["modify_dat"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["areaid_chr"].ToString().Trim());
                    tempItem.SubItems.Add(m_dtbReselt.Rows[i1]["patientid_chr"].ToString().Trim());
                    tempItem.Tag = m_dtbReselt.Rows[i1]["registerid_chr"].ToString().Trim();
                    m_objViewer.m_lsvTurnInPation.Items.Add(tempItem);
                }
            }
            m_dtbReselt.Dispose();
        }
        #endregion

        #region 门诊转入病人入院
        /// <summary>
        /// 门诊转入病人入院
        /// </summary>
        public void m_mthPatientTurnIn()
        {
            if (m_objViewer.m_lsvTurnInPation.SelectedItems.Count > 0)
            {
                DataTable p_dtbResult;
                long ret = m_objRegister.m_lngGetPatientInHospitalInfo(m_objViewer.m_lsvTurnInPation.SelectedItems[0].SubItems[10].Text.Trim(), 1, out p_dtbResult);
                if (ret > 0 && p_dtbResult.Rows.Count < 1)
                {
                    long lngRes = m_objRegister.m_lngPatientTurnIn(m_objViewer.m_lsvTurnInPation.SelectedItems[0].Tag.ToString().Trim(), m_objViewer.m_lsvTurnInPation.SelectedItems[0].SubItems[9].Text.Trim(), m_objViewer.LoginInfo.m_strEmpID, m_objViewer.m_lsvTurnInPation.SelectedItems[0].SubItems[1].Text.Trim());
                    if (lngRes > 0)
                    {
                        m_EmptyAndInitialization();
                        //QueryPatient();
                        m_objViewer.m_lsvTurnInPation.SelectedItems[0].Remove();
                        m_objViewer.tabControl1.SelectedIndex = 0;
                    }
                }
                else
                {
                    MessageBox.Show("该病人已存在在院信息!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }
        #endregion

        #region 删除门诊转入病人信息
        /// <summary>
        /// 删除门诊转入病人信息
        /// </summary>
        public void m_mthDelTrunInInfo()
        {

            if (m_objViewer.m_lsvTurnInPation.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("确认删除该信息么？", "删除门诊转入病人信息", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                string strSQL = @"DELETE      t_opr_bih_register t1
      WHERE t1.status_int = 2 AND t1.registerid_chr = '" + m_objViewer.m_lsvTurnInPation.SelectedItems[0].Tag.ToString().Trim() + "'";
                long lngResult = m_objRegister.m_lngModifyBihRegisterInfo(strSQL);
                if (lngResult > 0)
                {
                    m_objViewer.m_lsvTurnInPation.SelectedItems[0].Remove();
                }
                else
                {
                    MessageBox.Show("删除失败！", "删除门诊转入病人信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetTurnInPatienList();
                }
            }
        }
        #endregion

        #region 清空

        #region 清空所有信息
        /// <summary>
        /// 清空所有信息
        /// </summary>
        public void m_EmptyAndInitialization()
        {
            // 清空住院状态
            m_strRegisterID = "";
            m_strInPatientID = "";
            m_strPatientID = "";
            m_strINPATIENTTEMPID = "";
            m_intFlag = 1;
            m_intNewPatient = 1;
            m_objViewer.m_txtFindText.Text = "";
            m_objViewer.m_txtMONEY_DEC.Text = "";
            m_objViewer.m_cboCUYCATE_INT.SelectedIndex = 0;
            m_objViewer.m_cobPrint.SelectedIndex = 0;
            m_objViewer.m_lblPStatusName.Text = "首次入院";
            m_EmptyBaseInfo();
            m_EmptyBihRegisterInfo();
            m_objViewer.txtPatientName.Focus();
        }
        #endregion

        #region 清空病人基本信息
        /// <summary>
        /// 清空病人基本信息
        /// </summary>
        public void m_EmptyBaseInfo()
        {
            //病历卡号
            m_objViewer.txtPATIENTCARDID.Text = "";
            //医保编号
            m_objViewer.m_txtinsuranceid.Text = "";
            //出生年月
            m_objViewer.m_txtAge.Text = "0天";
            m_objViewer.m_dtpBirthDate.Text = "1900-01-01";
            //身份证号 
            m_objViewer.txtIDCard.Text = "";
            //病人姓名 
            m_objViewer.txtPatientName.Text = "";
            //性别 
            m_objViewer.cboSex.SelectedIndex = 0;
            //联系电话 
            m_objViewer.txtPhone.Text = "";
            //是否员工
            m_objViewer.cboIsemployee.SelectedIndex = 0;
            //婚否 
            m_objViewer.cobMarried.SelectedIndex = 0;
            //移动电话 
            m_objViewer.txtMobile.Text = "";
            //初诊日期 
            m_objViewer.dtpFirstDate.Value = System.DateTime.Now;
            //有效状态 {1：有效、0：无效、-1：历史}
            m_objViewer.cobStatus.Text = "";
            //家庭住址 
            m_objViewer.txtAddress.Text = "";
            //国籍
            m_objViewer.txtNationality.SelectedValue = "中国";
            //病人来源
            m_objViewer.m_cboPatientSource.SelectedValue = "本镇区";
            //民族 
            m_objViewer.m_txtRace.Text = "汉族";
            //籍贯 
            m_objViewer.m_txttNativeplace.Text = "";
            //职业 
            m_objViewer.m_txtOccupation.Text = "";
            m_objViewer.m_txtOccupation.m_mthFindDate();
            m_objViewer.m_txtOccupation.m_listView.Visible = false;
            //地址邮编 
            m_objViewer.txtHomepc.Text = "";
            //出生地 
            m_objViewer.txtBirthPlace.Text = "";
            //联系人姓名 
            m_objViewer.txtContactpersonFirstaName.Text = "";
            //联系人电话 
            m_objViewer.txtContactpersonPhone.Text = "";
            //联系人邮编 
            m_objViewer.txtContactpersonpc.Text = "";
            //与联系人关系 
            m_objViewer.m_txtRelation.Text = "";
            m_objViewer.m_txtRelation.m_mthFindDate();
            m_objViewer.m_txtRelation.m_listView.Visible = false;
            //联系人地址 
            m_objViewer.txtContactpersonAddress.Text = "";
            //办公电话 
            m_objViewer.txtOfficephone.Text = "";
            //办公邮编 
            m_objViewer.txtOfficepc.Text = "";
            //工作单位 
            m_objViewer.txtEmployer.Text = "";
            //电子邮箱 
            m_objViewer.txtEmail.Text = "";
            //办公地址
            m_objViewer.txtOfficeAddress.Text = "";
            //作废日期
            m_objViewer.txtDeactivateDate.Text = "";
            //操作人员
            m_objViewer.txtOperatorid.Text = "";
            //更新日期
            m_objViewer.txtModifydate.Text = "";
            // 医疗证号
            m_objViewer.m_txtGOVCARD_CHR.Text = "";

            this.m_objViewer.m_txtInsuredMoney.Text = "";
            this.m_objViewer.m_txtInsuredPayTime.Text = "";
            this.m_objViewer.m_txtInsuredPayMoney.Text = "";

            this.m_objViewer.txtBirthPlace.Text = "";
            this.m_objViewer.txtResidenceplace.Text = "";
            this.m_objViewer.txtConsigneeAddr.Text = "";
        }
        #endregion

        #region 清空住院信息
        /// <summary>
        /// 清空住院信息
        /// </summary>
        public void m_EmptyBihRegisterInfo()
        {
            m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
            //是否预约
            m_objViewer.m_chkISBOOKING_INT.Checked = false;
            //住院号
            m_objViewer.m_txtINPATIENTID_CHR.Text = "";
            m_objViewer.m_txtINPATIENTID_CHR.Tag = "";
            //入院日期
            m_objViewer.m_dateInHosp.Enabled = true;
            m_objViewer.m_dateInHosp.Text = "";
            m_objViewer.m_dateInHosp.Tag = "";
            //入院科室、入院病区、入院病
            m_objViewer.m_txtDEPTID_CHR.Text = "";
            m_objViewer.m_txtDEPTID_CHR.Tag = "";
            if (m_objViewer.m_txtAREAID.Enabled)
            {
                m_objViewer.m_txtAREAID.Text = "";
                m_objViewer.m_txtAREAID.Value = null;
                m_objViewer.m_txtAREAID.m_mthFindDate();
            }
            //入院方式 {１门诊、２急诊、３他院转入}
            m_objViewer.m_cboTYPE_INT.SelectedIndex = 0;
            //病情　｛１危、２急、３普通｝
            m_objViewer.m_cboSTATE_INT.SelectedIndex = 2;
            //操作人、操作时间
            m_objViewer.m_lblOperatorName.Text = "";
            m_objViewer.m_lblOperatorName.Tag = null;
            //费用类别 
            m_objViewer.m_txtPaytype.Value = "";
            m_objViewer.m_txtPaytype.Text = "";
            m_objViewer.m_txtPaytype.m_mthFindDate();
            m_objViewer.m_txtLIMITRATE_MNY.Text = "";
            //身份类别
            //m_objViewer.m_txtPatiemtType.Value = "";
            //m_objViewer.m_txtPatiemtType.Text = "";
            //m_objViewer.m_txtPatiemtType.m_mthFindDate();
            //费用下限
            m_mthSetPatType();
            m_objViewer.m_txtMONEY_DEC.Text = "";
            //清空门诊医生
            m_objViewer.m_txtMaindoctor.Value = null;
            m_objViewer.m_txtMaindoctor.Text = "";
            m_objViewer.m_txtMaindoctor.m_mthFindDate();
            m_objViewer.m_txtRemark.Text = "";
            // 门诊诊断
            m_objViewer.m_txtMZDiagnose.Text = "";
        }
        #endregion

        #endregion

        #region 载入数据信息

        #region 载入病人基本信息
        #region 根据身份证号
        /// <summary>
        /// 根据身份证号获取病人基本信息
        /// </summary>
        public bool LoadPatientInfoByIDCARD()
        {
            //身份证号为空则返回
            if (m_objViewer.txtIDCard.Text.Trim() == "") return false;
            clsPatient_VO objPatientVO = new clsPatient_VO();
            long lngReg = m_objRegister.m_lngGetPatientInfoByIDCARD(m_objViewer.txtIDCard.Text.Trim(), out objPatientVO);
            if (lngReg > 0 && objPatientVO != null)
            {
                m_EmptyAndInitialization();
                VoToValueForAll(objPatientVO);
            }
            else
            {
                return false;
            }
            return true;
        }
        #endregion
        #region 给病人基本信息赋值
        /// <summary>
        /// 给病人基本资料赋值
        /// </summary>
        /// <param name="objPatientVO"></param>
        private void VoToValueForAll(clsPatient_VO objPatientVO)
        {
            string strTem = "";
            m_strPatientID = objPatientVO.m_strPATIENTID_CHR;
            //医保编号
            m_objViewer.m_txtinsuranceid.Text = objPatientVO.m_strINSURANCEID_VCHR;
            //出生年月
            if (objPatientVO.m_strBIRTH_DAT != null && objPatientVO.m_strBIRTH_DAT.ToString() != "")
                m_objViewer.m_dtpBirthDate.Text = Convert.ToDateTime(objPatientVO.m_strBIRTH_DAT.ToString()).ToString("yyyy-MM-dd");
            //身份证号 
            m_objViewer.txtIDCard.Text = objPatientVO.m_strIDCARD_CHR;
            //病人姓名 
            m_objViewer.txtPatientName.Text = objPatientVO.m_strNAME_VCHR;//m_strLASTNAME_VCHR ;//m_strFIRSTNAME_VCHR;
            //联系电话 
            m_objViewer.txtPhone.Text = objPatientVO.m_strHOMEPHONE_VCHR;
            //性别 
            m_objViewer.cboSex.SelectedValue = objPatientVO.m_strSEX_CHR;
            //病人身份
            //m_objViewer.m_txtPatiemtType.Value = objPatientVO.m_strPAYTYPEID_CHR;
            //m_objViewer.m_txtPatiemtType.m_mthFindAndSelect(objPatientVO.m_strPAYTYPEID_CHR);
            //是否员工
            m_objViewer.cboIsemployee.SelectedIndex = objPatientVO.m_intISEMPLOYEE_INT;
            //婚否 
            m_objViewer.cobMarried.SelectedValue = objPatientVO.m_strMARRIED_CHR;
            //移动电话 
            m_objViewer.txtMobile.Text = objPatientVO.m_strMOBILE_CHR;
            //初诊日期 
            if (objPatientVO.m_strFIRSTDATE_DAT != null && objPatientVO.m_strFIRSTDATE_DAT.ToString() != "")
                m_objViewer.dtpFirstDate.Value = Convert.ToDateTime(objPatientVO.m_strFIRSTDATE_DAT.ToString());
            //有效状态 {1：有效、0：无效、-1：历史}
            switch (objPatientVO.m_intSTATUS_INT)
            {
                case 1:
                    strTem = "有效";
                    break;
                case 0:
                    strTem = "无效";
                    break;
                case -1:
                    strTem = "历史";
                    break;
                default:
                    strTem = "";
                    break;
            }
            m_objViewer.cobStatus.Text = strTem;
            //家庭住址 
            m_objViewer.txtAddress.Text = objPatientVO.m_strHOMEADDRESS_VCHR;

            //详细信息
            //国籍
            if (objPatientVO.m_strNATIONALITY_VCHR == null || objPatientVO.m_strNATIONALITY_VCHR == "")
            {
                m_objViewer.txtNationality.SelectedValue = "中国";
            }
            else
            {
                m_objViewer.txtNationality.SelectedValue = objPatientVO.m_strNATIONALITY_VCHR;
            }
            //民族 
            if (objPatientVO.m_strRACE_VCHR == null || objPatientVO.m_strRACE_VCHR == "")
            {
                m_objViewer.m_txtRace.Text = "汉族";
            }
            else
            {
                m_objViewer.m_txtRace.Text = objPatientVO.m_strRACE_VCHR;
            }
            //病人来源
            if (objPatientVO.m_strPatientSource == null || objPatientVO.m_strPatientSource == "")
            {
                m_objViewer.m_cboPatientSource.SelectedValue = "本镇区";
            }
            else
            {
                m_objViewer.m_cboPatientSource.SelectedValue = objPatientVO.m_strPatientSource;
            }
            //籍贯 
            m_objViewer.m_txttNativeplace.Text = objPatientVO.m_strNATIVEPLACE_VCHR;
            //职业 
            m_objViewer.m_txtOccupation.Text = objPatientVO.m_strOCCUPATION_VCHR;
            //地址邮编 
            m_objViewer.txtHomepc.Text = objPatientVO.m_strHOMEPC_CHR;
            //出生地 
            m_objViewer.txtBirthPlace.Text = objPatientVO.m_strBIRTHPLACE_VCHR;
            //联系人姓名 
            if (objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR != "")
            {
                m_objViewer.txtContactpersonFirstaName.Text = objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR;
            }
            else
            {
                m_objViewer.txtContactpersonFirstaName.Text = m_objViewer.txtPatientName.Text;
            }
            //联系人电话 
            m_objViewer.txtContactpersonPhone.Text = objPatientVO.m_strCONTACTPERSONPHONE_VCHR;
            //联系人邮编 
            m_objViewer.txtContactpersonpc.Text = objPatientVO.m_strCONTACTPERSONPC_CHR;
            //与联系人关系 
            m_objViewer.m_txtRelation.Text = objPatientVO.m_strPATIENTRELATION_VCHR;
            //联系人地址 
            m_objViewer.txtContactpersonAddress.Text = objPatientVO.m_strCONTACTPERSONADDRESS_VCHR;
            //办公电话 
            m_objViewer.txtOfficephone.Text = objPatientVO.m_strOFFICEPHONE_VCHR;
            //办公邮编 
            m_objViewer.txtOfficepc.Text = objPatientVO.m_strOFFICEPC_VCHR;
            //工作单位 
            m_objViewer.txtEmployer.Text = objPatientVO.m_strEMPLOYER_VCHR;
            //电子邮箱 
            m_objViewer.txtEmail.Text = objPatientVO.m_strEMAIL_VCHR;
            //办公地址
            m_objViewer.txtOfficeAddress.Text = objPatientVO.m_strOFFICEADDRESS_VCHR;
            //作废日期
            m_objViewer.txtDeactivateDate.Text = objPatientVO.m_strDEACTIVATE_DAT;
            //操作人员
            m_objViewer.txtOperatorid.Text = objPatientVO.m_strOPERATORID_CHR;
            //更新日期
            m_objViewer.txtModifydate.Text = objPatientVO.m_strMODIFY_DAT;
            m_objViewer.m_txttNativeplace.Text = objPatientVO.m_strNATIVEPLACE_VCHR;
            m_objViewer.m_txtGOVCARD_CHR.Text = objPatientVO.m_strGOVCARD_CHR;

            this.m_objViewer.m_txtInsuredMoney.Text = objPatientVO.m_decInsuredMoney.ToString();
            this.m_objViewer.m_txtInsuredPayTime.Text = objPatientVO.m_decInsuredPayTime.ToString();
            this.m_objViewer.m_txtInsuredPayMoney.Text = objPatientVO.m_decInsuredPayMoney.ToString();

            this.m_objViewer.txtBirthPlace.Text = objPatientVO.m_strBIRTHPLACE_VCHR;
            this.m_objViewer.txtResidenceplace.Text = objPatientVO.m_strResidencePlace;
            this.m_objViewer.txtConsigneeAddr.Text = objPatientVO.ConsigneeAddr;
            objPatientVO = null;
        }
        #endregion
        #endregion

        #region 载入住院信息
        /// <summary>
        /// 载入住院信息[根据住院号]
        /// </summary>
        public void LoadBihRegister()
        {
            // 获取住院号的最近一次住院登记流水号
            long lngReg = m_objRegister.m_lngGetRegisteridByInpatientID(m_strInPatientID, out m_strRegisterID);
            if (lngReg < 0)
                return;
            if (m_strRegisterID == "")
            {
                return;
            }
            m_mthGetPatientInfo(m_strRegisterID);
        }
        #endregion

        #region 根据入院登记获取病人住院信息
        /// <summary>
        /// 根据入院登记获取病人住院信息
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        private void m_mthGetPatientInfo(string p_strRegisterID)
        {
            //根据住院流水号 查询住院登记
            clsT_Opr_Bih_Register_VO m_objItem = new clsT_Opr_Bih_Register_VO();
            long lngReg = m_objRegister.m_lngGetBinRegisterByRegisterID(p_strRegisterID, out m_objItem);
            if (lngReg <= 0 || m_objItem == null)
                return;

            //给控件赋值
            m_strPatientID = m_objItem.m_strPATIENTID_CHR;
            m_objViewer.m_chkISBOOKING_INT.Checked = Convert.ToBoolean(m_objItem.m_intISBOOKING_INT);
            //入院日期
            m_objViewer.m_dateInHosp.Text = m_objItem.m_strINPATIENT_DAT.ToString();
            m_objViewer.m_dateInHosp.Tag = m_objItem.m_strINPATIENT_DAT.ToString();

            //入院科室、病区、床号
            m_objViewer.m_txtDEPTID_CHR.Text = m_objItem.m_strDeptName;
            m_objViewer.m_txtDEPTID_CHR.Tag = m_objItem.m_strDEPTID_CHR;
            m_objViewer.m_txtAREAID.Text = m_objItem.m_strAreaName;
            m_objViewer.m_txtAREAID.Value = m_objItem.m_strAREAID_CHR;
            //入院方式{1=门诊;2=急诊;3=他院转入;4=他科转入}
            m_objViewer.m_cboTYPE_INT.SelectedIndex = m_objItem.m_intTYPE_INT - 1;
            m_objViewer.m_txtLIMITRATE_MNY.Text = m_objItem.m_dblLIMITRATE_MNY.ToString();
            //病情 {1危、2急、3普通}
            m_objViewer.m_cboSTATE_INT.SelectedIndex = m_objItem.m_intSTATE_INT - 1;
            m_objViewer.m_lblOperatorName.Text = m_objRegister.m_GetEmployeeNameByID(m_objItem.m_strOPERATORID_CHR);
            //住院状态	{0=未上床;1=已上床;2=预出院;3=实际出院}
            m_intPStatus = m_objItem.m_intPSTATUS_INT;
            switch (m_objItem.m_intINPATIENTNOTYPE_INT)
            {
                case 1:
                    {
                        this.m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
                        break;
                    }
                case 2:
                    {
                        this.m_objViewer.m_cboInpatientNoType.SelectedIndex = 1;
                        break;
                    }
                case 3:
                    {
                        this.m_objViewer.m_cboInpatientNoType.SelectedIndex = 2;
                        break;
                    }
                default:
                    break;
            }
            //门诊医生]
            this.m_objViewer.m_txtMaindoctor.Text = m_objItem.m_stroutdoctorname;
            this.m_objViewer.m_txtMaindoctor.Value = m_objItem.m_strMZDOCTOR_CHR;
            //门诊建议预交金
            m_strCLINICSAYPREPAY = m_objItem.m_strCLINICSAYPREPAY;
            this.m_objViewer.m_txtRemark.Text = m_objItem.DES_VCHR;
            if (m_objViewer.m_lblPStatusName.Text == "首次入院" || m_objViewer.m_lblPStatusName.Text == "已出院")
            {
                m_objViewer.m_dateInHosp.Enabled = true;
                m_objViewer.m_dateInHosp.Text = m_objBedAdmin.m_GetServTime().ToString();
            }
            else
            {
                m_objViewer.m_dateInHosp.Enabled = false;
            }
            DataTable dtbResult = null;
            DataTable dtbResult1 = null;
            m_objRegister.m_lngGetSpChargeItemIDType(out dtbResult1);
            string id1 = "";
            string id2 = "";
            if (dtbResult1.Rows.Count > 0)
            {
                id1 = dtbResult1.Rows[0]["EATDICCATE"].ToString();
                id2 = dtbResult1.Rows[0]["NURSECATE"].ToString();
            }
            if (m_intPStatus == 1 || m_intPStatus == 2)
            {
                m_objRegister.m_lngGetPatientCareInfo(m_strRegisterID, out dtbResult);
                if (dtbResult.Rows.Count > 0)
                {
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        if (dtbResult.Rows[i]["ordercateid_chr"].ToString() == id1)
                        {
                            this.m_objViewer.m_txtFoodInfo.Text = dtbResult.Rows[i]["NAME_CHR"].ToString();
                        }
                        if (dtbResult.Rows[i]["ordercateid_chr"].ToString() == id2)
                        {
                            this.m_objViewer.m_txtCareInfo.Text = dtbResult.Rows[i]["NAME_CHR"].ToString();
                        }
                    }
                }
            }
            if (m_objViewer.m_lblPStatusName.Text == "首次入院" || m_objViewer.m_lblPStatusName.Text == "已出院")
            {
                //获取病人历史欠费信息
                string strResult = "";
                this.m_GetPatientHistoryDebtByInpatientID(m_strInPatientID.Trim(), out strResult);
                this.m_objViewer.m_txtRemark.Text = strResult;
                if (strResult != "")
                {
                    MessageBox.Show(this.m_objViewer, "注意该病人有未清帐记录", "提示!!");
                }
            }
        }
        #endregion

        #region 载入病人调转信息
        /// <summary>
        /// 载入病人调转信息
        /// </summary>
        public void LoadBihTransfer()
        {
            if (m_strRegisterID.Trim() == "") return;

            clsT_Opr_Bih_Transfer_VO[] objResultArr = null;
            long lngReg = 0;
            string strSQLFilter = "AND(1=0 ";
            if (m_objViewer.m_ckbInhospital.Checked)
            {
                strSQLFilter += "or a.type_int = 5";
            }
            if (m_objViewer.m_ckbOutHospital.Checked)
            {
                strSQLFilter += " or a.type_int = 6";
            }
            //			if(m_objViewer.m_ckbTraDept.Checked)
            //			{
            //				strSQLFilter+=" or a.type_int = 1";
            //			}
            if (m_objViewer.m_ckbTraBed.Checked)
            {
                strSQLFilter += " or a.type_int = 2";
            }
            if (m_objViewer.m_ckbTraDEPTAndBED.Checked)
            {
                strSQLFilter += " or a.type_int = 3";
            }
            strSQLFilter += " or 0=1)";
            if (m_objViewer.m_rdbCurrent.Checked)
            {
                //显示当前住院调转信息
                lngReg = m_objRegister.m_lngGetBinTransferByRegisterID(m_strRegisterID, strSQLFilter, out objResultArr, 0);
            }
            else
            {
                //显示历史住院调转信息
                lngReg = m_objRegister.m_lngGetBinTransferByRegisterID(m_strInPatientID, strSQLFilter, out objResultArr, 1);
            }
            if (lngReg <= 0 || objResultArr == null || objResultArr.Length == 0)
                return;

            ListViewItem lviTemp = null;

            int intTem = 0;
            m_objViewer.m_lsvBihTransfer.Items.Clear();
            for (int i1 = 0; i1 < objResultArr.Length; i1++)
            {
                //住院次序数
                try
                {
                    intTem = Convert.ToInt16(objResultArr[i1].m_strINPATIENTCOUNT_INT);
                }
                catch
                {
                    intTem = 1;
                }
                lviTemp = new ListViewItem("第" + objResultArr[i1].m_strINPATIENTCOUNT_INT + "次住院");
                //操作日期 {调转时间}
                lviTemp.SubItems.Add(Convert.ToDateTime(objResultArr[i1].m_strMODIFY_DAT).ToString("yyyy年MM月dd日 HH时mm分"));
                //操作类型 {1转科、2调床、3转科+调床、4出院召回}
                lviTemp.SubItems.Add(objResultArr[i1].m_strTypeName);
                //原科室、原病区、原病床
                lviTemp.SubItems.Add(objResultArr[i1].m_strSourceDeptName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strSourceAreaName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strSourceBedNo);
                //目标科室、目标病区、目标病床
                lviTemp.SubItems.Add(objResultArr[i1].m_strTargetDeptName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strTargetAreaName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strTargetBedNo);
                //操作人
                lviTemp.SubItems.Add(objResultArr[i1].m_strOperatorName);
                //备注
                lviTemp.SubItems.Add(objResultArr[i1].m_strDES_VCHR);
                //入院登记ID
                lviTemp.SubItems.Add(objResultArr[i1].m_strREGISTERID_CHR);
                //增加 Tag属性[流水号]
                lviTemp.Tag = objResultArr[i1].m_strTRANSFERID_CHR;
                if (!m_objViewer.m_rdbCurrent.Checked)
                {
                    lviTemp.ForeColor = clsColor.m_ColorByInt((intTem - 1) % clsColor.Count);
                }
                m_objViewer.m_lsvBihTransfer.Items.Add(lviTemp);
            }
        }
        #endregion

        #region 载入出院信息
        /// <summary>
        /// 载入出院信息
        /// </summary>
        public void LoadBihLeave()
        {
            //清空
            if (m_objViewer.m_txtINPATIENTID_CHR.Text.Trim() == "") return;

            clsT_Opr_Bih_Leave_VO[] objResultArr = null;
            long lngReg = m_objRegister.m_lngGetBihLeaveByInpatientID(m_objViewer.m_txtINPATIENTID_CHR.Text.Trim(), out objResultArr);
            if (lngReg <= 0 || objResultArr == null || objResultArr.Length == 0)
                return;

            ListViewItem lviTemp = null;

            int intTem = 0;
            m_objViewer.m_lsvBihLeave.Items.Clear();
            for (int i1 = 0; i1 < objResultArr.Length; i1++)
            {
                //住院次序数
                intTem = m_objRegister.m_intGetBihOrderByRegisterID(objResultArr[i1].m_strREGISTERID_CHR);
                lviTemp = new ListViewItem("第" + intTem.ToString() + "次住院");
                //操作日期 {出院时间}
                lviTemp.SubItems.Add(Convert.ToDateTime(objResultArr[i1].m_strMODIFY_DAT).ToString("yyyy年MM月dd日 HH时mm分"));
                //类型
                lviTemp.SubItems.Add(objResultArr[i1].m_strTYPE_INT);
                //出院科室、出院病区、出院病床
                lviTemp.SubItems.Add(objResultArr[i1].m_strOutDeptName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strOutAreaName);
                lviTemp.SubItems.Add(objResultArr[i1].m_strOutBedNo);
                //操作人
                lviTemp.SubItems.Add(objResultArr[i1].m_strOperatorName);
                //备注
                lviTemp.SubItems.Add(objResultArr[i1].m_strDES_VCHR);
                //增加 Tag属性[流水号]
                lviTemp.Tag = objResultArr[i1].m_strLEAVEID_CHR;
                lviTemp.ForeColor = clsColor.m_ColorByInt((intTem - 1) % clsColor.Count);
                m_objViewer.m_lsvBihLeave.Items.Add(lviTemp);
            }
        }
        #endregion

        #region 载入预交金余额   改为调用费用窗口
        //		/// <summary>
        //		/// 载入预交金余额
        //		/// </summary>
        //		/// <param name="m_strREGISTERID">入院登记流水号</param>
        //		private void LoadBalanceMoney(string m_strREGISTERID)
        //		{
        ////			m_objViewer.m_txtMONEY_DEC.Text ="";
        //			double p_dblBalanceMoney =0;
        //			long lngReg =m_objRegister.m_lngGetBalanceMoneyByRegisterID(m_strREGISTERID,out p_dblBalanceMoney);
        ////			m_objViewer.m_txtMONEY_DEC.Text =p_dblBalanceMoney.ToString("0.00");
        ////			m_objViewer.m_txtMONEY_DEC.ReadOnly = true;
        ////			this.m_objViewer.m_txtPREPAYINV_VCHR.ReadOnly = true;
        //		}
        #endregion

        #region 根据住院号查询病人历史欠费信息
        public void m_GetPatientHistoryDebtByInpatientID(string InPatientID, out string strResult)
        {
            strResult = "";
            string[] registeridArr;
            long lngRes = m_objRegister.m_lngGetRegisteridByInpatientID(InPatientID, out registeridArr);
            if (registeridArr.Length > 0)
            {
                string strDebt = "";
                for (int i = 0; i < registeridArr.Length; i++)
                {
                    int a = i + 1;
                    lngRes = new clsDcl_StatQuery().m_lngGetPatientDebtByRegisterID(registeridArr[i], out strDebt);
                    if (strDebt != "")
                    {
                        strResult += "第" + a.ToString() + "住院欠费:" + strDebt;
                    }
                }
            }
            if (strResult.Length > 200)
            {
                strResult = strResult.Substring(0, 200);
            }
        }
        #endregion

        #endregion

        #region 保存入院登记
        /// <summary>
        /// 保存入院登记
        /// </summary>
        public void m_mthSaveRegister()
        {
            if (objsystempower.isHasRight("住院.进出转.入院"))
            {
                long lngReg = 0;
                //输入验证
                if (!IsPassValidate())
                {
                    return;
                }
                clsRegisterParameterVO p_objParaVO = new clsRegisterParameterVO();
                clsPatient_VO objPatientVO;
                clsT_Opr_Bih_Register_VO objBIHVO;
                clsT_opr_bih_prepay_VO p_objPay;
                ValueToVoForBaseInfo(out objPatientVO);

                //查询历史信息
                if (m_intFlag == 1)
                {
                    clsPatient_VO objPatientCopy = new clsPatient_VO();
                    objPatientVO.m_mthClone(objPatientCopy);
                    frmFindPatient findPat = new frmFindPatient(ref objPatientCopy);
                    long ret = findPat.InitView();
                    if (ret > 0)
                    {
                        findPat.ShowDialog();

                        if (findPat.DialogResult == DialogResult.Cancel)
                        {
                            this.m_objViewer.txtPatientName.Focus();
                            return;
                        }
                        else if (findPat.DialogResult == DialogResult.OK)
                        {
                            objPatientVO = objPatientCopy;
                            m_strPatientID = objPatientVO.m_strPATIENTID_CHR;

                            //m_mthFindPatientInfoByPatientID();
                            FindPatientInfoByPatientID();

                            ValueToVoForBaseInfo(out objPatientVO);
                            m_intFlag = 2;
                        }
                    }
                }

                if (!ValueToVoForBIHInfo(out objBIHVO))
                {
                    return;
                }
                if (!m_blnprepay(out p_objPay))
                {
                    return;
                }
                // 同步身份(费别)2018-04-23
                objPatientVO.m_strPAYTYPEID_CHR = objBIHVO.m_strPAYTYPEID_CHR;
                try
                {
                    if (m_intFlag == 2)
                    {
                        if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0 && m_strInPatientID != "")
                        {
                            m_blnNewInPatienID = false;
                            objBIHVO.m_strINPATIENTID_CHR = m_strInPatientID;
                            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;
                        }
                        else if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 1 && m_strINPATIENTTEMPID != "")
                        {
                            m_blnNewInPatienID = false;
                            objBIHVO.m_strINPATIENTID_CHR = m_strINPATIENTTEMPID;
                            objPatientVO.m_strINPATIENTTEMPID_VCHR = m_strINPATIENTTEMPID;
                        }
                    }

                    if (m_blnNewInPatienID)
                    {
                        CreateInpatientNo m_objfrm = new CreateInpatientNo(m_objViewer.m_cboInpatientNoType.SelectedIndex + 1);
                        m_objfrm.m_intCreatNOFlag = m_disCreatNOFlag;
                        m_objfrm.ShowDialog();
                        if (m_objfrm.DialogResult == DialogResult.OK)
                        {
                            p_objParaVO.m_intFlag = 1;
                            objBIHVO.m_strINPATIENTID_CHR = m_objfrm.m_strGetInpatientid_chr(out p_objParaVO.m_strHeardFlag, out p_objParaVO.m_intSourse);
                            if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0)
                            {
                                objPatientVO.m_strINPATIENTID_CHR = objBIHVO.m_strINPATIENTID_CHR;
                            }
                            else
                            {
                                objPatientVO.m_strINPATIENTTEMPID_VCHR = objBIHVO.m_strINPATIENTID_CHR;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    m_objViewer.Cursor = Cursors.WaitCursor;
                    p_objParaVO.m_intIsNewPatient = m_intNewPatient;
                    lngReg = m_objTran.m_lngPatientRegister(p_objParaVO, objPatientVO, p_objPay, ref objBIHVO);
                    if (lngReg > 0)
                    {
                        #region 顺德医保资料同步
                        ArrayList PayTypeArr = clsPublic.m_mthGetYBPayID();
                        if (clsPublic.m_strGetSysparm("1000") == "003" && PayTypeArr.IndexOf(m_objViewer.m_txtPaytype.Value) != -1)
                        {
                            objBIHVO.m_strAreaName = this.m_objViewer.m_txtAREAID.Text.Trim();
                            clsCtl_Report objRep = new clsCtl_Report();
                            objRep.m_mthBihRegister_SDYB(objPatientVO, objBIHVO);
                        }
                        #endregion

                        frmInPatientIDAlert frmInPatientID = new frmInPatientIDAlert(objBIHVO.m_strINPATIENTID_CHR);
                        frmInPatientID.ShowDialog();
                        //m_EmptyAndInitialization();

                        if (this.m_disPrepayFalg == 0)
                        {
                            m_mthPrintPay(p_objPay.m_dblMONEY_DEC, objBIHVO.m_strBEDID_CHR); //此处的床位ID为预交金记录ID
                        }

                        m_objViewer.m_strRegisterID = objBIHVO.m_strREGISTERID_CHR;
                        m_objViewer.DialogResult = DialogResult.OK;
                        //加入嵌入式社保调用登记窗体
                        if (m_intPatientFlag == 2 || m_intPatientFlag == 4)
                        {
                            if (MessageBox.Show("此病人属于社保病人，是否要进行社保登记？", "入院登记", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                m_mthYBPatient();
                            }
                        }
                        m_EmptyAndInitialization();

                        #region 判断门诊转来未交费处方显示关联
                        System.Collections.Generic.List<clsRecipeNoPay_VO> m_lstRecipeNoPay_VO = new System.Collections.Generic.List<clsRecipeNoPay_VO>();
                        lngReg = m_objTran.m_lngGetPatientRecipeNopay(objBIHVO.m_strINPATIENTID_CHR, 1, out m_lstRecipeNoPay_VO);
                        if (m_lstRecipeNoPay_VO.Count > 0)
                        {
                            frmPatientRecipeNoPay objfrmPatientRec = new frmPatientRecipeNoPay(objBIHVO.m_strINPATIENTID_CHR, 1, m_lstRecipeNoPay_VO);
                            objfrmPatientRec.ShowDialog();
                        }

                        #endregion


                    }
                    else if (lngReg == -2)
                    {
                        MessageBox.Show("住院号已被占用！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //m_SaveInfo();
                    }
                    else if (lngReg == -3)
                    {
                        MessageBox.Show("该病人已经入院！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("入院失败！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception e)
                {
                    if (e.Message.Trim() == "0") //新增入院登记记录时失败,可能住院已被占用！
                    {
                        if (MessageBox.Show("保存失败！", "入院登记", MessageBoxButtons.RetryCancel, MessageBoxIcon.Information) == DialogResult.Retry)
                        {
                            //m_mthSaveRegister();
                            MessageBox.Show(e.Message, "新增入院登记记录时失败,请重试！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show(e.Message, "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                finally
                {
                    m_blnNewInPatienID = true;
                    p_objParaVO = null;
                    objPatientVO = null;
                    objBIHVO = null;
                    p_objPay = null;
                    m_objViewer.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show(m_objViewer, "您沒有权限");
            }
        }
        #endregion

        #region 控件赋值给Vo
        /// <summary>
        /// 控件赋值给Vo {主索引}
        /// </summary>
        /// <param name="objPatientVO">[out 参数]</param>
        private void ValueToVoForIndexInfo(out clsclsPatientIdxVO objPatientVO)
        {
            objPatientVO = new clsclsPatientIdxVO();
            //病人编号
            objPatientVO.m_strPATIENTID_CHR = m_strPatientID;
            //住院编号
            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;
            //身份证号
            objPatientVO.m_strIDCARD_CHR = m_objViewer.txtIDCard.Text;
            //家庭住址
            objPatientVO.m_strHOMEADDRESS_VCHR = m_objViewer.txtAddress.Text;
            //性别
            objPatientVO.m_strSEX_CHR = (string)m_objViewer.cboSex.SelectedValue;
            //出生年月
            try
            {
                objPatientVO.m_strBIRTH_DAT = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
            }
            //病人姓名
            objPatientVO.m_strNAME_VCHR = m_objViewer.txtPatientName.Text;
            //联系电话
            objPatientVO.m_strHOMEPHONE_VCHR = m_objViewer.txtPhone.Text;
            //医保编号
            objPatientVO.m_strINSURANCEID_VCHR = m_objViewer.m_txtinsuranceid.Text;
        }
        /// <summary>
        /// 控件赋值给Vo {基本信息}
        /// </summary>
        /// <param name="objPatientVO">[out 参数]</param>
        private void ValueToVoForBaseInfo(out clsPatient_VO objPatientVO)
        {
            objPatientVO = new clsPatient_VO();
            //病人编号
            objPatientVO.m_strPATIENTID_CHR = m_strPatientID;
            //医保编号
            objPatientVO.m_strINSURANCEID_VCHR = m_objViewer.m_txtinsuranceid.Text;
            //出生年月
            try
            {
                objPatientVO.m_strBIRTH_DAT = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
            }
            //身份证号 
            objPatientVO.m_strIDCARD_CHR = m_objViewer.txtIDCard.Text;
            //病人姓名 
            objPatientVO.m_strLASTNAME_VCHR = m_objViewer.txtPatientName.Text;
            objPatientVO.m_strFIRSTNAME_VCHR = m_objViewer.txtPatientName.Text;
            objPatientVO.m_strNAME_VCHR = m_objViewer.txtPatientName.Text;
            //联系电话 
            objPatientVO.m_strHOMEPHONE_VCHR = m_objViewer.txtPhone.Text;
            //性别 
            objPatientVO.m_strSEX_CHR = (string)m_objViewer.cboSex.SelectedValue;
            //费用类别
            //objPatientVO.m_strPAYTYPEID_CHR = m_objViewer.m_txtPatiemtType.Value;
            //住院编号
            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;
            //留观号
            objPatientVO.m_strINPATIENTTEMPID_VCHR = m_strINPATIENTTEMPID;
            //是否员工
            objPatientVO.m_intISEMPLOYEE_INT = m_objViewer.cboIsemployee.SelectedIndex;
            //婚否 
            objPatientVO.m_strMARRIED_CHR = (string)m_objViewer.cobMarried.SelectedValue;
            //移动电话 
            objPatientVO.m_strMOBILE_CHR = m_objViewer.txtMobile.Text;
            //初诊日期 
            objPatientVO.m_strFIRSTDATE_DAT = m_objViewer.dtpFirstDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
            //有效状态 {1：有效、0：无效、-1：历史}
            objPatientVO.m_intSTATUS_INT = 1;
            //家庭住址 
            objPatientVO.m_strHOMEADDRESS_VCHR = m_objViewer.txtAddress.Text;
            //国籍
            objPatientVO.m_strNATIONALITY_VCHR = (string)m_objViewer.txtNationality.SelectedValue;
            //民族 
            objPatientVO.m_strRACE_VCHR = m_objViewer.m_txtRace.Text;
            //籍贯 
            objPatientVO.m_strNATIVEPLACE_VCHR = m_objViewer.m_txttNativeplace.Text;
            //职业 
            objPatientVO.m_strOCCUPATION_VCHR = m_objViewer.m_txtOccupation.Text.Trim();
            //病人来源
            objPatientVO.m_strPatientSource = (string)m_objViewer.m_cboPatientSource.SelectedValue;
            //地址邮编 
            objPatientVO.m_strHOMEPC_CHR = m_objViewer.txtHomepc.Text;
            //出生地 
            objPatientVO.m_strBIRTHPLACE_VCHR = m_objViewer.txtBirthPlace.Text;
            //联系人姓名 
            objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR = m_objViewer.txtContactpersonFirstaName.Text;
            objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonFirstaName.Text;
            //联系人电话 
            objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonPhone.Text;
            //联系人邮编 
            objPatientVO.m_strCONTACTPERSONPC_CHR = m_objViewer.txtContactpersonpc.Text;
            //与联系人关系 
            objPatientVO.m_strPATIENTRELATION_VCHR = m_objViewer.m_txtRelation.Text.Trim();
            //联系人地址 
            objPatientVO.m_strCONTACTPERSONADDRESS_VCHR = m_objViewer.txtContactpersonAddress.Text;
            //办公电话 
            objPatientVO.m_strOFFICEPHONE_VCHR = m_objViewer.txtOfficephone.Text;
            //办公邮编 
            objPatientVO.m_strOFFICEPC_VCHR = m_objViewer.txtOfficepc.Text;
            //工作单位 
            objPatientVO.m_strEMPLOYER_VCHR = m_objViewer.txtEmployer.Text;
            //电子邮箱 
            objPatientVO.m_strEMAIL_VCHR = m_objViewer.txtEmail.Text;
            //办公地址
            objPatientVO.m_strOFFICEADDRESS_VCHR = m_objViewer.txtOfficeAddress.Text;
            //操作人员
            objPatientVO.m_strOPERATORID_CHR = m_strOperatorID;
            //更新日期
            objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            objPatientVO.m_strNATIVEPLACE_VCHR = m_objViewer.m_txttNativeplace.Text.Trim();
            objPatientVO.m_strGOVCARD_CHR = m_objViewer.m_txtGOVCARD_CHR.Text.Trim();

            if (this.m_objViewer.m_txtInsuredMoney.Text.Trim() != "")
            {
                objPatientVO.m_decInsuredMoney = Convert.ToDecimal(this.m_objViewer.m_txtInsuredMoney.Text.Trim());
            }
            else
            {
                objPatientVO.m_decInsuredMoney = 0;
            }
            if (this.m_objViewer.m_txtInsuredPayTime.Text.Trim() != "")
            {
                objPatientVO.m_decInsuredPayTime = Convert.ToDecimal(this.m_objViewer.m_txtInsuredPayTime.Text.Trim());
            }
            else
            {
                objPatientVO.m_decInsuredPayTime = 0;
            }
            if (this.m_objViewer.m_txtInsuredPayMoney.Text.Trim() != "")
            {
                objPatientVO.m_decInsuredPayMoney = Convert.ToDecimal(this.m_objViewer.m_txtInsuredPayMoney.Text.Trim());
            }
            else
            {
                objPatientVO.m_decInsuredPayMoney = 0;
            }
            objPatientVO.m_strResidencePlace = this.m_objViewer.txtResidenceplace.Text.Trim();
            objPatientVO.ConsigneeAddr = this.m_objViewer.txtConsigneeAddr.Text.Trim();
        }
        /// <summary>
        /// 控件赋值给Vo {住院信息}
        /// </summary>
        /// <param name="objPatientVO">[out 参数]</param>
        private bool ValueToVoForBIHInfo(out clsT_Opr_Bih_Register_VO objPatientVO)
        {
            objPatientVO = new clsT_Opr_Bih_Register_VO();

            //入院登记流水号(200409010001)
            objPatientVO.m_strREGISTERID_CHR = m_strRegisterID;
            //病人ＩＤ
            objPatientVO.m_strPATIENTID_CHR = m_strPatientID;
            //是否预约
            objPatientVO.m_intISBOOKING_INT = Convert.ToInt16(m_objViewer.m_chkISBOOKING_INT.Checked);
            //住院号
            objPatientVO.m_strINPATIENTID_CHR = m_strInPatientID;

            if (m_objViewer.m_dateInHosp.Value > DateTime.Now)
            {
                MessageBox.Show("入院日期不能大于当前系统时间，请修改！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_dateInHosp.Focus();
                return false;
            }
            else
            {
                objPatientVO.m_strINPATIENT_DAT = m_objViewer.m_dateInHosp.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }

            //入院科室、入院病区、入院病床
            objPatientVO.m_strDEPTID_CHR = "";
            objPatientVO.m_strBEDID_CHR = "";
            //if(m_objViewer.m_txtDEPTID_CHR.Tag!=null)
            //{
            //    objPatientVO.m_strDEPTID_CHR = ((string)m_objViewer.m_txtDEPTID_CHR.Tag).ToString();
            //}
            string strDeptId;
            m_objTran.GetParentIdByDeptId(m_objViewer.m_txtAREAID.Value, out strDeptId);
            objPatientVO.m_strDEPTID_CHR = strDeptId;

            objPatientVO.m_strAREAID_CHR = m_objViewer.m_txtAREAID.Value;
            //入院方式 {１门诊、２急诊、３他院转入}
            objPatientVO.m_intTYPE_INT = m_objViewer.m_cboTYPE_INT.SelectedIndex + 1;
            //费用下限
            if (m_objViewer.m_txtLIMITRATE_MNY.Text.Trim() == "")
            {
                objPatientVO.m_dblLIMITRATE_MNY = 0;
            }
            else
            {
                try
                {
                    objPatientVO.m_dblLIMITRATE_MNY = Convert.ToDouble(m_objViewer.m_txtLIMITRATE_MNY.Text.Trim());
                    if (objPatientVO.m_dblLIMITRATE_MNY < 0)
                    {
                        MessageBox.Show("费用下限不能为负数！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.m_txtLIMITRATE_MNY.Focus();
                        return false;
                    }
                }
                catch
                {
                    MessageBox.Show("费用下限不是有效数字", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtLIMITRATE_MNY.Focus();
                    return false;
                }
            }
            //病情　｛１危、２急、３普通｝
            objPatientVO.m_intSTATE_INT = m_objViewer.m_cboSTATE_INT.SelectedIndex + 1;
            //状态　｛－１历史、０无效、１有效｝
            objPatientVO.m_intSTATUS_INT = 1;
            //操作人、操作时间
            objPatientVO.m_strOPERATORID_CHR = m_strOperatorID;
            objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //患者在院状态	{0=未上床;1=已上床;2=预出院;3=实际出院}
            objPatientVO.m_intPSTATUS_INT = 0;
            //住院号类型
            objPatientVO.m_intINPATIENTNOTYPE_INT = m_objViewer.m_cboInpatientNoType.SelectedIndex + 1;
            //门诊医生]
            objPatientVO.m_strMZDOCTOR_CHR = m_objViewer.m_txtMaindoctor.Value;

            //门诊医生所属的科室
            DataTable dt;
            long lngReg = m_objTran.GetDeptByEmpID(m_objViewer.m_txtMaindoctor.Value, out dt);
            if (lngReg > 0 && dt.Rows.Count > 0)
            {
                objPatientVO.m_strCaseDoctorDept = dt.Rows[0]["DEPTID_CHR"].ToString();
            }

            objPatientVO.m_strPAYTYPEID_CHR = m_objViewer.m_txtPaytype.Value;
            // 门诊诊断
            objPatientVO.m_strMZDIAGNOSE_VCHR = m_objViewer.m_txtMZDiagnose.Text.Trim();
            //备注
            objPatientVO.DES_VCHR = m_objViewer.m_txtRemark.Text.Trim();

            return true;
        }
        #endregion

        #region 调转
        /// <summary>
        /// 调转
        /// </summary>
        public void m_BihTransfer()
        {
            //调转	{1、空出原来的床位；2、占领已转的床位；3、增加调转记录；4、修改入院登记的病床信息；}
            frmBIHTransfer objfrmBIHTransfer = new frmBIHTransfer(m_strRegisterID, (string)m_objViewer.m_txtDEPTID_CHR.Tag, (string)m_objViewer.m_txtAREAID.Tag, "");
            //显示信息
            objfrmBIHTransfer.m_lblDEPTID_CHR.Text = m_objViewer.m_txtDEPTID_CHR.Text;	//源科室
            objfrmBIHTransfer.m_lblAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;	//源病区
            objfrmBIHTransfer.m_lblPatientName.Text = m_objViewer.txtPatientName.Text;//患者姓名
            //初始化默认值
            //			objfrmBIHTransfer.m_txtDEPTID_CHR.Text =m_objViewer.m_txtDEPTID_CHR.Text;
            //			objfrmBIHTransfer.m_txtDEPTID_CHR.Tag =(string)m_objViewer.m_txtDEPTID_CHR.Tag;
            objfrmBIHTransfer.m_txtAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;
            objfrmBIHTransfer.m_txtAREAID_CHR.Tag = (string)m_objViewer.m_txtAREAID.Tag;
            //			objfrmBIHTransfer.m_cbmTYPE.SelectedIndex =1;//转科+调床
            //			objfrmBIHTransfer.m_txtBEDID_CHR.Text =string.Empty;
            //			objfrmBIHTransfer.m_txtBEDID_CHR.Value =string.Empty;
            objfrmBIHTransfer.ShowDialog();
            //载入住院信息[根据住院号]
            LoadBihRegister();
            //载入病人调转信息
            LoadBihTransfer();
        }
        #endregion

        #region 出院召回
        /// <summary>
        /// 出院召回
        /// </summary>
        public void m_BihRecall()
        {
            //出院召回	{1、删除出院记录；2、占领新床位；3、增加住院调转记录；4、修改入院登记的病床信息；}
            frmBIHRecall objfrmBIHRecall = new frmBIHRecall(m_strRegisterID, (string)m_objViewer.m_txtDEPTID_CHR.Tag, (string)m_objViewer.m_txtAREAID.Tag, "");
            //显示信息
            objfrmBIHRecall.m_lblDEPTID_CHR.Text = m_objViewer.m_txtDEPTID_CHR.Text;	//出院科室
            objfrmBIHRecall.m_lblAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;	//出院病区
            objfrmBIHRecall.m_lblPatientName.Text = m_objViewer.txtPatientName.Text;//患者姓名
            //初始化默认值
            objfrmBIHRecall.m_txtAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;
            objfrmBIHRecall.m_txtAREAID_CHR.Tag = (string)m_objViewer.m_txtAREAID.Tag;
            objfrmBIHRecall.ShowDialog();
            //载入住院信息[根据住院号]
            LoadBihRegister();
            //载入病人调转信息
            LoadBihTransfer();
            //载入出院信息
            LoadBihLeave();
        }
        #endregion

        #region 出院
        /// <summary>
        /// 出院
        /// </summary>
        public void m_BihLeave()
        {
            //出院	{1、空出床位；2、增加一条出院记录；}
            frmBIHLeave objfrmBIHLeave = new frmBIHLeave(m_strRegisterID, (string)m_objViewer.m_txtDEPTID_CHR.Tag, (string)m_objViewer.m_txtAREAID.Tag, "");
            //显示信息
            objfrmBIHLeave.m_lblPatientName.Text = m_objViewer.txtPatientName.Text;	//患者姓名
            objfrmBIHLeave.m_lblDEPTID_CHR.Text = m_objViewer.m_txtDEPTID_CHR.Text;	//出院科室
            objfrmBIHLeave.m_lblAREAID_CHR.Text = m_objViewer.m_txtAREAID.Text;	//出院病区
            objfrmBIHLeave.m_cbmPSTATUS_INT.SelectedIndex = 2;	//实际出院
            objfrmBIHLeave.m_cbmTYPE.SelectedIndex = 1;			//治愈出院
            objfrmBIHLeave.ShowDialog();
            //载入住院信息[根据住院号]
            LoadBihRegister();
            //载入病人调转信息
            LoadBihTransfer();
            //载入出院信息
            LoadBihLeave();
        }
        #endregion

        #region 查询同名病人同时调出病人信息,如果没有同名病人则调出病人登记
        /// <summary>
        /// 查询同名病人同时调出病人信息,如果没有同名病人则调出病人登记
        /// </summary>
        public void m_mthFindPatientInfoByName()
        {
            if (m_objViewer.txtPatientName.Text.Trim() == "")
            {
                MessageBox.Show("病人姓名不能为空", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.txtPatientName.Focus();
            }
            else
            {
                m_objViewer.Cursor = Cursors.WaitCursor;
                frmCommonFind frm = new frmCommonFind();
                frm.IsBihReg = true;
                if (frm.m_intFindByNameSexType(m_objViewer.txtPatientName.Text.Trim(), m_objViewer.cboSex.SelectedValue.ToString(), m_objViewer.m_cboInpatientNoType.SelectedIndex + 1, false, true) > 0)
                {
                    frm.ShowDialog();
                    if (frm.DialogResult == DialogResult.OK)
                    {
                        m_strPatientID = frm.PatientID;
                        m_mthFindPatientInfoByPatientID();
                    }
                    else
                    {
                        m_objViewer.m_dtpBirthDate.Focus();
                    }
                    frm = null;
                    m_objViewer.Cursor = Cursors.Default;
                }
                else
                {
                    m_objViewer.Cursor = Cursors.Default;
                    m_objViewer.m_dtpBirthDate.Focus();
                }
            }
        }
        #endregion

        #region 预交金处理
        /// <summary>
        /// 预交金处理
        /// </summary>
        /// <returns></returns>
        public bool m_blnprepay(out clsT_opr_bih_prepay_VO objItem)
        {
            objItem = new clsT_opr_bih_prepay_VO();
            if (m_objViewer.m_txtMONEY_DEC.Text.Trim() == "")
            {
                objItem.m_dblMONEY_DEC = 0;
                return true;
            }
            objItem.m_dblMONEY_DEC = double.Parse(m_objViewer.m_txtMONEY_DEC.Text.Trim());
            if (objItem.m_dblMONEY_DEC == 0)
            {
                objItem.m_dblMONEY_DEC = 0;
                return true;
            }
            else if (objItem.m_dblMONEY_DEC < 0)
            {
                MessageBox.Show("预交金不能为负数！", "预交金", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (new frmPrepayAlert(m_objViewer.m_cboCUYCATE_INT.Text.Substring(2, m_objViewer.m_cboCUYCATE_INT.Text.Length - 2), CurrencyToString(objItem.m_dblMONEY_DEC)).ShowDialog() != DialogResult.OK)
            {
                m_objViewer.m_txtMONEY_DEC.Focus();
                m_objViewer.m_txtMONEY_DEC.SelectAll();
                return false;
            }

            Regex r = new Regex(clsPublic.m_strReadXML("BeInHospital", "PrepayBillNoExp", "AnyOne"));
            Match m = r.Match(m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim());
            if (!m.Success)
            {
                MessageBox.Show("当前预交金收据的编号规则不正确，请仔细检查。", "预交金", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtPREPAYINV_VCHR.Focus();
                m_objViewer.m_txtPREPAYINV_VCHR.SelectAll();
                return false;
            }

            //if (new clsBIHChargeSvc().m_lngCheckInvoiceNO(objPrincipal, m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim()) > 0)
            if (clsPublic.m_blnCheckPrepayNoIsUsed(this.m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim(), 0))
            {
                MessageBox.Show("发票号重复！", "预交金", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtPREPAYINV_VCHR.Focus();
                m_objViewer.m_txtPREPAYINV_VCHR.SelectAll();
                return false;
            }

            objItem.m_strPREPAYINV_VCHR = m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim();
            objItem.m_strPATIENTID_CHR = m_strPatientID;
            objItem.m_strPatientName = m_objViewer.txtPatientName.Text.Trim();
            objItem.m_strREGISTERID_CHR = m_strRegisterID;
            objItem.m_intLINER_INT = 1;
            objItem.m_intPAYTYPE_INT = 1;
            objItem.m_intCUYCATE_INT = m_objViewer.m_cboCUYCATE_INT.SelectedIndex + 1;
            objItem.m_strAREAID_CHR = m_objViewer.m_txtAREAID.Value;
            objItem.m_strPRESSNO_VCHR = m_objViewer.m_txtPREPAYINV_VCHR.Text;
            objItem.m_strAreaName = m_objViewer.m_txtAREAID.Text.Trim();
            objItem.m_strDES_VCHR = m_objViewer.m_txtRemark.Text.Trim();
            objItem.m_strCREATORID_CHR = this.m_objViewer.LoginInfo.m_strEmpID.Trim();
            objItem.m_strCREATE_DAT = System.DateTime.Now.ToString();
            objItem.m_intSTATUS_INT = 1;
            objItem.m_intISCLEAR_INT = 0;
            objItem.m_intUPTYPE_INT = 0;
            objItem.m_strPatientName = m_objViewer.txtPatientName.Text.Trim();
            objItem.m_strAreaName = m_objViewer.m_txtAREAID.Text.Trim();
            objItem.m_intBALANCEFLAG_INT = 0;
            return true;
        }
        /// <summary>
        /// 获取发票号
        /// </summary>
        public void m_strReadInvoiceNO()
        {
            try
            {
                //string m_strPrepayBillNo = clsPublic.m_strReadXML("BeInHospital", "CurrPrepayBillNo", "AnyOne");
                //m_objViewer.m_txtPREPAYINV_VCHR.Text = Convert.ToString(int.Parse(m_strPrepayBillNo) + 1).PadLeft(m_strPrepayBillNo.Length,'0');

                string m_strPrepayBillNo = clsPublic.m_strGetCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, 2);
                m_objViewer.m_txtPREPAYINV_VCHR.Text = m_strPrepayBillNo;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "获取发票号失败");
            }
        }
        /// <summary>
        /// 保存发票号
        /// </summary>
        /// <param name="strInvoiceNO"></param>
        public void m_mthSaveInvoiceNO()
        {
            //try
            //{
            //    clsPublic.m_blnWriteXML("BeInHospital", "CurrPrepayBillNo", "AnyOne", m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim());
            //}
            //catch
            //{
            //    MessageBox.Show("\t保存发票号失败,\n请检查\"" + Application.StartupPath + "\\LoginFile.xml\"是否只读!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            clsPublic.m_blnSaveCurrInvoiceNo(this.m_objViewer.LoginInfo.m_strEmpID, m_objViewer.m_txtPREPAYINV_VCHR.Text.Trim(), 2);
        }
        /// <summary>
        /// 打印预交金
        /// </summary>
        private void m_mthPrintPay(double p_dblMoney, string p_strPrepayID)
        {
            if (p_dblMoney > 0)
            {
                m_mthSaveInvoiceNO();
                m_strReadInvoiceNO();
                if (this.m_objViewer.m_cobPrint.SelectedIndex == 0)//{0=不预览-打印;1=不打印}
                {
                    try
                    {
                        clsPBNetPrint.m_mthPrintPrepayBill(p_strPrepayID, "");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "打印预交金失败");
                    }
                }
            }
        }
        /// <summary>
        /// 预交金焦点设置
        /// </summary>
        public void m_mthSetFocus()
        {
            if (m_objViewer.m_txtMONEY_DEC.Text.Trim() == "" || m_objViewer.m_txtMONEY_DEC.Text.Trim() == "0")
            {
                m_objViewer.cmdSaveBihRegister.Focus();
            }
            else
            {
                try
                {
                    decimal decMoney = Convert.ToDecimal(m_objViewer.m_txtMONEY_DEC.Text.Trim());
                    if (decMoney < 0)
                    {
                        MessageBox.Show("预交金额不能为负数！", " 预交金", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.m_txtMONEY_DEC.Focus();
                    }
                    m_objViewer.m_txtMONEY_DEC.Text = decMoney.ToString("0.00");
                }
                catch
                {
                    MessageBox.Show("预交金额不是有效数字！", " 预交金", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtMONEY_DEC.Focus();
                    m_objViewer.m_txtMONEY_DEC.SelectAll();
                }
            }
        }
        #endregion

        #region 把数字转换成中文大写
        private static string[] cstr = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
        private static string[] wstr = { "分", "角", "圆", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟" };
        /// <summary>
        /// 把数字转换成中文大写
        /// </summary>
        /// <param name="fltCurrency"></param>
        /// <returns></returns>
        public string CurrencyToString(double fltCurrency)
        {
            string str = fltCurrency.ToString("0.00");
            str = str.Replace(".", "");
            int len = str.Length;
            int i;
            string tmpstr, rstr;
            rstr = "";
            for (i = 1; i <= len; i++)
            {
                tmpstr = str.Substring(len - i, 1);
                rstr = string.Concat(cstr[Int32.Parse(tmpstr)] + wstr[i - 1], rstr);
            }
            rstr = rstr.Replace("拾零", "拾");
            rstr = rstr.Replace("零拾", "零");
            rstr = rstr.Replace("零佰", "零");
            rstr = rstr.Replace("零仟", "零");
            rstr = rstr.Replace("零万", "万");
            for (i = 1; i <= 6; i++)
                rstr = rstr.Replace("零零", "零");
            rstr = rstr.Replace("零万", "零");
            rstr = rstr.Replace("零亿", "億");
            rstr = rstr.Replace("零零", "零");
            rstr = rstr.Replace("零角零分", "");
            rstr = rstr.Replace("零分", "");
            rstr += "整";
            rstr = rstr.Replace("分整", "分");
            rstr = rstr.Replace("零圆", "圆");
            rstr = rstr.Replace("零角", "零");
            return rstr;
        }
        #endregion

        #region 根据病人诊疗卡号或住院号获取病人ID
        /// <summary>
        /// 根据病人诊疗卡号或住院号获取病人ID
        /// </summary>
        public void m_mthGetPatientIDByCarIDOrInPatientID()
        {
            if (m_objViewer.m_txtFindText.Text.Trim() != "")
            {
                if (m_objViewer.m_cmbFindType.SelectedIndex == 0)
                {
                    m_objViewer.m_txtFindText.Text = m_objViewer.m_txtFindText.Text.Trim().PadLeft(10, '0');
                }
                try
                {
                    string p_strPatientID;
                    long lngRes = m_objTran.m_lngGetPatientIDByCarIDOrInPatientID(m_objViewer.m_cmbFindType.SelectedIndex, m_objViewer.m_txtFindText.Text.Trim(), out p_strPatientID);
                    if (lngRes > 0 && p_strPatientID != "")
                    {
                        m_strPatientID = p_strPatientID;
                        m_mthFindPatientInfoByPatientID();
                    }
                    else if (this.m_objViewer.m_cmbFindType.SelectedIndex == 2)
                    {
                        #region 从社保获取数据
                        if (System.IO.File.Exists(Application.StartupPath + "\\HNBridge.dll"))
                        {
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
                            m_objItem.GMSFHM = this.m_objViewer.m_txtFindText.Text.ToString().Trim();
                            m_objItem.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne"); //医院编号
                            m_objItem.CBDTCQBM = "";   //need modify
                            m_objItem.CYKS = this.m_objViewer.LoginInfo.m_strEmpNo; //更改为经办人
                            lngRes = clsYBPublic_cs.m_lngFunSP1201(m_objItem, out m_objPatientInfo, out m_objJXzlxx, out m_objYDryxx, out m_objZYxx, out m_objZJzyxx);

                            if (lngRes > 0)
                            {
                                this.m_objViewer.txtPatientName.Text = m_objPatientInfo.XM;
                                if (m_objPatientInfo.XB == "1")
                                {
                                    this.m_objViewer.cboSex.SelectedIndex = 0;
                                }
                                else if (m_objPatientInfo.XB == "2")
                                {
                                    this.m_objViewer.cboSex.SelectedIndex = 1;
                                }
                                else
                                {
                                    this.m_objViewer.cboSex.SelectedIndex = 3;
                                }
                                try
                                {
                                    m_objViewer.m_dtpBirthDate.Text = DateTime.ParseExact(m_objPatientInfo.CSNY.Trim(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToShortDateString();
                                    m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(DateTime.ParseExact(m_objPatientInfo.CSNY.Trim(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture).ToShortDateString());
                                }
                                catch
                                {
                                    m_objViewer.m_txtAge.Text = m_objPatientInfo.CSNY;
                                    int nowDate = DateTime.Now.Year - Convert.ToInt32(m_objViewer.m_txtAge.Text.Trim());
                                    string strNowDate = nowDate.ToString() + "-01-01";
                                    m_objViewer.m_dtpBirthDate.Text = strNowDate;
                                }
                                this.m_objViewer.txtIDCard.Text = this.m_objViewer.m_txtFindText.Text.ToString().Trim();
                                this.m_objViewer.txtPhone.Text = m_objPatientInfo.LXDH;
                                this.m_objViewer.txtEmployer.Text = m_objPatientInfo.ZZMC;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        MessageBox.Show("找不到该病人信息！", "查询病人", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "查询病人");
                }
            }
        }
        #endregion

        #region 根据病人ID获取病人基本信息
        /// <summary>
        /// 根据病人ID获取病人基本信息
        /// </summary>
        /// <param name="p_strPatientid">病人ID</param>
        /// <returns></returns>
        public void m_mthFindPatientInfoByPatientID()
        {
            if (m_strPatientID == "")
            {
                return;
            }
            m_intFlag = 1;
            string m_strInTimes = "首次入院";
            clsBIHpatientVO p_objBIHPationVO;
            long lngRes = m_objTran.m_lngGetLatestInHospitalInfo(m_strPatientID, m_objViewer.m_cboInpatientNoType.SelectedIndex + 1, out p_objBIHPationVO);
            if (lngRes > 0 && p_objBIHPationVO.m_strPSTATUS_INT != "")
            {
                if (p_objBIHPationVO.m_strPSTATUS_INT != "0")
                {
                    m_strPatientID = "";
                    MessageBox.Show("该病人已经入院！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtPatientName.Focus();
                    m_objViewer.txtPatientName.SelectAll();
                    return;
                }
                else if (p_objBIHPationVO.m_strINPATIENTCOUNT_INT != "")
                {
                    m_intFlag = 2;
                    m_strInTimes = "第 " + p_objBIHPationVO.m_strINPATIENTCOUNT_INT + " 次入院";
                    if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0)
                    {
                        m_strInPatientID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                    else
                    {
                        m_strINPATIENTTEMPID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                }
            }
            clsPatient_VO p_objPatienVO;
            lngRes = m_objTran.m_lngFindPatientInfoByPatientID(m_strPatientID, out p_objPatienVO);
            if (lngRes > 0 && p_objPatienVO.m_strPATIENTID_CHR != "")
            {
                m_objViewer.m_lblPStatusName.Text = m_strInTimes;
                VoToValueForAll(p_objPatienVO);
                m_intNewPatient = 2;
                if (m_intNeedInput == 1)
                {
                    m_objViewer.m_dtpBirthDate.Focus();
                }
                else
                {
                    m_objViewer.m_cboTYPE_INT.Focus();
                }
            }
            else
            {
                MessageBox.Show("找不到该病人信息！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 根据病人ID获取病人基本信息(只是取其住院号和入院次数)
        /// <summary>
        /// 根据病人ID获取病人基本信息
        /// </summary>
        /// <param name="p_strPatientid">病人ID</param>
        /// <returns></returns>
        public void FindPatientInfoByPatientID()
        {
            if (m_strPatientID == "")
            {
                return;
            }
            m_intFlag = 1;
            string m_strInTimes = "首次入院";
            clsBIHpatientVO p_objBIHPationVO;
            long lngRes = m_objTran.m_lngGetLatestInHospitalInfo(m_strPatientID, m_objViewer.m_cboInpatientNoType.SelectedIndex + 1, out p_objBIHPationVO);
            if (lngRes > 0 && p_objBIHPationVO.m_strPSTATUS_INT != "")
            {
                if (p_objBIHPationVO.m_strPSTATUS_INT != "0")
                {
                    m_strPatientID = "";
                    MessageBox.Show("该病人已经入院！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtPatientName.Focus();
                    m_objViewer.txtPatientName.SelectAll();
                    return;
                }
                else if (p_objBIHPationVO.m_strINPATIENTCOUNT_INT != "")
                {
                    m_intFlag = 2;
                    m_strInTimes = "第 " + p_objBIHPationVO.m_strINPATIENTCOUNT_INT + " 次入院";
                    if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0)
                    {
                        m_strInPatientID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                    else
                    {
                        m_strINPATIENTTEMPID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }

                    m_objViewer.m_lblPStatusName.Text = m_strInTimes;
                    //VoToValueForAll(p_objPatienVO);
                    m_intNewPatient = 2;
                }
            }
        }
        #endregion

        #region 设置费用类型
        /// <summary>
        /// 设置费用类型
        /// </summary>
        public void m_mthSetPatType()
        {
            if (m_objViewer.m_txtPaytype.Value != null)
            {
                DataRowView drv = m_objViewer.m_txtPaytype.SelectedItem;
                m_intPatientFlag = Convert.ToInt16(drv["internalflag_int"]);
                m_objViewer.m_txtLIMITRATE_MNY.Text = drv["bihlimitrate_dec"].ToString().Trim();
                if (m_intPatientFlag == 2 || m_intPatientFlag == 4)
                {
                    //m_objViewer.m_txtinsuranceid.Text = "";
                    m_objViewer.m_txtinsuranceid.Enabled = true;
                    this.m_objViewer.m_txtInsuredMoney.Enabled = true;
                    this.m_objViewer.m_txtInsuredPayMoney.Enabled = true;
                    this.m_objViewer.m_txtInsuredPayTime.Enabled = true;
                }
                else
                {
                    m_objViewer.m_txtinsuranceid.Text = "";
                    m_objViewer.m_txtinsuranceid.Enabled = false;

                    this.m_objViewer.m_txtInsuredMoney.Text = "";
                    this.m_objViewer.m_txtInsuredPayMoney.Text = "";
                    this.m_objViewer.m_txtInsuredPayTime.Text = "";

                    this.m_objViewer.m_txtInsuredMoney.Enabled = false;
                    this.m_objViewer.m_txtInsuredPayMoney.Enabled = false;
                    this.m_objViewer.m_txtInsuredPayTime.Enabled = false;
                }
            }
        }
        #endregion

        #region 正式留观撤换时刷新入院次数
        /// <summary>
        /// 正式留观撤换时刷新入院次数
        /// </summary>
        public void m_mthFreshInTime()
        {
            if (m_strPatientID == "")
            {
                return;
            }
            m_intFlag = 1;
            string m_strInTimes = "首次入院";
            clsBIHpatientVO p_objBIHPationVO;
            long lngRes = m_objTran.m_lngGetLatestInHospitalInfo(m_strPatientID, m_objViewer.m_cboInpatientNoType.SelectedIndex + 1, out p_objBIHPationVO);
            if (lngRes > 0 && p_objBIHPationVO.m_strPSTATUS_INT != "")
            {
                if (p_objBIHPationVO.m_strPSTATUS_INT != "0")
                {
                    m_strPatientID = "";
                    MessageBox.Show("该病人已经入院！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (p_objBIHPationVO.m_strINPATIENTCOUNT_INT != "")
                {
                    m_intFlag = 2;
                    m_strInTimes = "第 " + p_objBIHPationVO.m_strINPATIENTCOUNT_INT + " 次入院";
                    if (m_objViewer.m_cboInpatientNoType.SelectedIndex == 0)
                    {
                        m_strInPatientID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                    else
                    {
                        m_strINPATIENTTEMPID = p_objBIHPationVO.m_strINPATIENTID_CHR;
                    }
                }
            }
            m_objViewer.m_lblPStatusName.Text = m_strInTimes;
        }
        #endregion

        #region 刷新
        /// <summary>
        /// 刷新
        /// </summary>
        public void m_mthFresh()
        {
            m_objViewer.Cursor = Cursors.WaitCursor;
            m_objTran.m_lngGetSetingByID("1006", out m_intNeedInput);
            m_strReadInvoiceNO();
            if (m_strPatientID == "")
            {
                m_EmptyAndInitialization();
            }
            else
            {
                m_mthFindPatientInfoByPatientID();
            }
            m_objViewer.Cursor = Cursors.Default;
        }
        #endregion


        // 对用用户输入操作的控制
        #region 处理带*号不能为空的项
        /// <summary>
        /// 处理带*号不能为空的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthManageEmptyItem(object sender, EventArgs e)
        {
            if (sender is ControlLibrary.txtListView)
            {
                if (((ControlLibrary.txtListView)sender).m_listView.SelectedItems.Count < 1)
                {
                    MessageBox.Show("该项不能为空！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }
            if (m_intNeedInput == 1) //控制入院登记带*号的项是否必填:0-可不填 1-必须填
            {
                if (sender is ComboBox)
                {
                    if (((ComboBox)sender).Text.Trim() == "")
                    {
                        MessageBox.Show("该项不能为空！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((ComboBox)sender).Focus();
                    }
                }
                else if (sender is TextBox)
                {
                    if (((TextBox)sender).Text.Trim() == "")
                    {
                        MessageBox.Show("该项不能为空！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((TextBox)sender).Focus();
                    }
                }
            }
        }
        #endregion

        #region 处理医保病人不能为空的项
        /// <summary>
        /// 处理医保病人不能为空的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthManagTinsuranceEmpty(object sender, EventArgs e)
        {
            if (m_objViewer.m_txtinsuranceid.Enabled)
            {
                if (sender is TextBox)
                {
                    if (((TextBox)sender).Text.Trim() == "")
                    {
                        MessageBox.Show("医保病人该项不能为空！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ((TextBox)sender).Focus();
                    }
                }
            }
        }
        #endregion

        #region 处理职工病人不能为空的项
        /// <summary>
        /// 处理职工病人不能为空的项
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void m_mthManagEmployeeEmpty(object sender, EventArgs e)
        {
            if (m_objViewer.m_txtGOVCARD_CHR.Enabled)
            {
                if (m_objViewer.m_txtGOVCARD_CHR.Text.Trim() == "")
                {
                    MessageBox.Show("职工医疗证号为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtGOVCARD_CHR.Focus();
                }
            }
        }
        #endregion

        #region 身份证号输入控制
        /// <summary>
        /// 身份证号输入控制
        /// </summary>
        public void m_mthManageIdentity()
        {
            if (m_intPatientFlag == 2)
            {
                if (m_objViewer.txtIDCard.Text.Trim() == "")
                {
                    MessageBox.Show("医保病人身份证号为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtIDCard.Focus();
                    return;
                }
            }
            if (m_objViewer.txtIDCard.Text.Trim() != "")
            {
                //if (m_objViewer.txtIDCard.Text.Trim().Length == 15 || m_objViewer.txtIDCard.Text.Trim().Length == 18)
                //{
                //    Regex objReg = new Regex("^[1-9]([0-9]{16}|[0-9]{13})[xX0-9]$");
                //    Match objMat = objReg.Match(m_objViewer.txtIDCard.Text.Trim());
                //    if (!objMat.Success)
                //    {
                //        MessageBox.Show("请输入有效身份证号！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        m_objViewer.txtIDCard.Focus();
                //        return;
                //    }
                //}
                if (m_objViewer.txtIDCard.Text.Trim().Length != 18)
                {
                    MessageBox.Show("请注意：身份证号不是18位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (m_objViewer.txtIDCard.Text.Length == 15)
            {
                string birthdate;
                birthdate = m_objViewer.txtIDCard.Text.Substring(6, 6);
                birthdate = "19" + birthdate.Substring(0, 2) + "-" + birthdate.Substring(2, 2) + "-" + birthdate.Substring(4, 2);
                m_objViewer.m_dtpBirthDate.Text = birthdate;
            }
            else if (m_objViewer.txtIDCard.Text.Length == 18)
            {
                string birthdate;
                birthdate = m_objViewer.txtIDCard.Text.Substring(6, 8);
                birthdate = birthdate.Substring(0, 4) + "-" + birthdate.Substring(4, 2) + "-" + birthdate.Substring(6, 2);
                m_objViewer.m_dtpBirthDate.Text = birthdate;
            }
        }
        #endregion

        #region 对家庭地址输入控制
        /// <summary>
        /// 对家庭地址输入控制
        /// </summary>
        public void m_mthAddressIdentity()
        {
            if (m_intNeedInput == 1)
            {
                if (m_objViewer.txtAddress.Text.Trim() == "")
                {
                    MessageBox.Show("家庭地址为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtAddress.Focus();
                    return;
                }
            }
            if (m_objViewer.m_txtinsuranceid.Enabled)
            {
                if (m_objViewer.txtAddress.Text.Trim() == "")
                {
                    MessageBox.Show("医保病人家庭地址为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtAddress.Focus();
                }
            }
        }
        #endregion

        #region 保存时对用户输入验证
        /// <summary>
        /// 保存时对用户输入验证
        /// </summary>
        /// <returns></returns>
        private bool IsPassValidate()
        {
            if (m_objViewer.txtPatientName.Text.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "病人姓名为必填项!", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.txtPatientName.Focus();
                return false;
            }
            try
            {
                DateTime tempDate = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text);
            }
            catch
            {
                MessageBox.Show("请输入有效出生日期！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_dtpBirthDate.Focus();
                return false;
            }
            //if (m_objViewer.m_txtPatiemtType.Value == null)
            //{
            //    MessageBox.Show("身份为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    m_objViewer.m_txtPatiemtType.Focus();
            //    return false;
            //}
            if (m_objViewer.m_cboPatientSource.Text.Trim() == "" || m_objViewer.m_cboPatientSource.Text.Trim() == null)
            {
                MessageBox.Show("病人来源为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_cboPatientSource.Focus();
                return false;
            }
            if (m_objViewer.m_txtPaytype.Value == null)
            {
                MessageBox.Show("收费类型为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtPaytype.Focus();
                return false;
            }
            if (m_objViewer.txtIDCard.Text.Trim() != "")
            {
                //if (m_objViewer.txtIDCard.Text.Trim().Length == 15 || m_objViewer.txtIDCard.Text.Trim().Length == 18)
                //{
                //    Regex objReg = new Regex("^[1-9]([0-9]{16}|[0-9]{13})[xX0-9]$");
                //    Match objMat = objReg.Match(m_objViewer.txtIDCard.Text.Trim());
                //    if (!objMat.Success)
                //    {
                //        MessageBox.Show("请输入有效身份证号！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        m_objViewer.txtIDCard.Focus();
                //        return false;
                //    }
                //}
                if (m_objViewer.txtIDCard.Text.Trim().Length != 18)
                {
                    MessageBox.Show("请注意：身份证号不是18位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (m_objViewer.txtPatientName.Text != m_objViewer.txtContactpersonFirstaName.Text && m_objViewer.m_txtRelation.Text == "")
            {
                MessageBox.Show("联系人非本人，请修改关系！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtRelation.Focus();
                return false;
            }
            if (m_objViewer.m_txtAREAID.Value == null || m_objViewer.m_txtAREAID.Text == string.Empty)
            {
                MessageBox.Show("病区为必填项!", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtAREAID.Focus();
                return false;
            }
            if (m_objViewer.m_txtMaindoctor.Value == null || m_objViewer.m_txtMaindoctor.Text == string.Empty)
            {
                MessageBox.Show("门诊医生为必填项!", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtMaindoctor.Focus();
                return false;
            }

            if (m_intNeedInput == 1)  //控制入院登记带*号的项是否必填:0-可不填 1-必须填
            {
                if (m_objViewer.txtAddress.Text.Trim() == "")
                {
                    MessageBox.Show("家庭地址为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtAddress.Focus();
                    return false;
                }
            }

            if (m_intPatientFlag == 2 || m_intPatientFlag == 4)
            {
                if (m_objViewer.m_txtinsuranceid.Text.Trim() == "")
                {
                    MessageBox.Show("医保病人医保号为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtinsuranceid.Focus();
                    return false;
                }
                if (m_intPatientFlag == 2)
                {
                    if (m_objViewer.txtIDCard.Text.Trim() == "")
                    {
                        MessageBox.Show("医保病人身份证号为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.txtIDCard.Focus();
                        return false;
                    }
                }
                if (m_objViewer.txtAddress.Text.Trim() == "")
                {
                    MessageBox.Show("医保病人家庭地址为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtAddress.Focus();
                    return false;
                }
                if (m_objViewer.txtEmployer.Text.Trim() == "")
                {
                    MessageBox.Show("医保病人工作单位为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.txtEmployer.Focus();
                    return false;
                }

                if (this.m_objViewer.m_txtInsuredMoney.Text.Trim() != "")
                {
                    try
                    {
                        if (Convert.ToDecimal(this.m_objViewer.m_txtInsuredMoney.Text.Trim()) >= 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("医保剩余金额输入不正确。", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.m_objViewer.m_txtInsuredMoney.Focus();
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("医保剩余金额输入不正确。", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.m_txtInsuredMoney.Focus();
                        return false;
                    }
                }

                if (this.m_objViewer.m_txtInsuredPayTime.Text.Trim() != "")
                {
                    try
                    {
                        if (Convert.ToDecimal(this.m_objViewer.m_txtInsuredPayTime.Text.Trim()) >= 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("医保报销次数输入不正确。", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.m_objViewer.m_txtInsuredPayTime.Focus();
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("医保报销次数输入不正确。", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.m_txtInsuredPayTime.Focus();
                        return false;
                    }
                }

                if (this.m_objViewer.m_txtInsuredPayMoney.Text.Trim() != "")
                {
                    try
                    {
                        if (Convert.ToDecimal(this.m_objViewer.m_txtInsuredPayMoney.Text.Trim()) >= 0)
                        {
                        }
                        else
                        {
                            MessageBox.Show("医保报销次金额入不正确。", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.m_objViewer.m_txtInsuredPayMoney.Focus();
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("医保报销金额输入不正确。", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.m_txtInsuredPayMoney.Focus();
                        return false;
                    }
                }
            }

            if (m_objViewer.m_txtGOVCARD_CHR.Enabled)
            {
                if (m_objViewer.m_txtGOVCARD_CHR.Text.Trim() == "")
                {
                    MessageBox.Show("职工医疗证号为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_objViewer.m_txtGOVCARD_CHR.Focus();
                    return false;
                }
            }

            if (this.m_disPrepayFalg == 0 && (m_objViewer.m_txtMONEY_DEC.Text.Trim() == "" || m_objViewer.m_txtMONEY_DEC.Text.Trim() == "0"))
            {
                string message = "该病人首次预交金额为0元，是否继续？";
                string caption = "入院登记";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(this.m_objViewer, message, caption, buttons,
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RightAlign);

                if (result == DialogResult.No)
                {
                    m_objViewer.m_txtMONEY_DEC.Focus();
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 计算年龄
        /// <summary>
        /// 计算年龄
        /// </summary>
        public void m_mthCalculateAge()
        {
            DateTime tempDate;
            try
            {
                tempDate = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text);

                //add 2007.5.9 zhu.w.t
                if (tempDate < Convert.ToDateTime("1753-1-1 12:00:00") || tempDate > Convert.ToDateTime("9999-12-31 11:59:59"))
                {
                }
                else
                {
                    m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(tempDate);
                }
            }
            catch
            {
                return;
            }

        }
        #endregion

        #region 调用医保窗体
        public void m_mthYBPatient()
        {
            if (string.IsNullOrEmpty(m_objViewer.m_strRegisterID))
            {
                return;
            }
            frmYBRegisterZY objYBReg = new frmYBRegisterZY();
            objYBReg.strRegisterId = m_objViewer.m_strRegisterID;
            objYBReg.ShowDialog();
        }
        #endregion

        #region 医保登录初始化
        /// <summary>
        /// 医保登录初始化
        /// </summary>
        public void m_mthInitYB()
        {
            if (System.IO.File.Exists(Application.StartupPath + "\\HNBridge.dll"))
            {
                //医院经办人注册需住院登录
                string strUser = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
                string strPwd = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "PASSWORDZY", "AnyOne");
                long lngRes = clsYBPublic_cs.m_lngUserLoin(strUser, strPwd, false);
                if (lngRes < 0)
                {
                    MessageBox.Show("社保初始化失败，请重新打开！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }
        #endregion


    }



    #region 类clsColor 取颜色类
    public class clsColor
    {
        public clsColor()
        {
        }

        public static System.Drawing.Color m_ColorByInt(int itemIndex)
        {
            System.Drawing.Color selectedColor;
            switch (itemIndex)
            {
                case 0:
                    selectedColor = System.Drawing.Color.Blue;
                    break;
                case 1:
                    selectedColor = System.Drawing.Color.Red;
                    break;
                case 2:
                    selectedColor = System.Drawing.Color.Green;
                    break;
                case 3:
                    selectedColor = System.Drawing.Color.Tomato;
                    break;
                case 4:
                    selectedColor = System.Drawing.Color.Brown;
                    break;
                default:
                    selectedColor = System.Drawing.Color.Black;
                    break;
            }
            return selectedColor;
        }
        /// <summary>
        /// 总共定义的颜色数
        /// </summary>
        /// <returns>总共定义的颜色数</returns>
        public static int Count
        {
            get
            {
                return 5;
            }
        }
    }
    #endregion

    #region 类clsComboBoxTextValue
    public class clsComboBoxTextValue
    {
        private string _text;
        private int _value;

        public clsComboBoxTextValue(string _Text, int _Value)
        {
            _text = _Text;
            _value = _Value;
        }

        public override string ToString()
        {
            return _text;
        }

        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }
    }
    #endregion

}
