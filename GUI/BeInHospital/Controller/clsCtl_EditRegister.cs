using System;
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
using System.Collections;
using System.Collections.Generic;


namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 入院登记资料修改--控制层
    /// </summary>
    public class clsCtl_EditRegister : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        clsDcl_BIHTransfer m_objTran = null;
        /// <summary>
        /// 病人基本信息VO
        /// </summary>
        clsPatient_VO m_objPatientVO = null;
        /// <summary>
        /// 病人住院入院登记信息VO
        /// </summary>
        clsT_Opr_Bih_Register_VO m_objRegisterVO = null;
        /// <summary>
        /// 入院登记流水号
        /// </summary>
        public string m_strRegisterID = "";
        /// <summary>
        /// 病人编号
        /// </summary>
        public string m_strPatientID = "";
        /// <summary>
        /// 控制入院登记带*号的项是否必填:0-可不填 1-必须填
        /// </summary>
        private int m_intNeedInput = 0;
        /// <summary>
        /// 当前病人身份标识:0-普通 1-公费 2-医保 3-特困 4-应该是老人
        /// </summary>
        private int m_intPatientFlag = 0;

        Hashtable m_initCtl;
        private clsBrithdayToAge m_objAge;

        #endregion

        #region 构造函数
        public clsCtl_EditRegister()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objTran = new clsDcl_BIHTransfer();
            m_objAge = new clsBrithdayToAge();
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmEditRegister m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmEditRegister)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void m_mthInit()
        {
            //m_objViewer.Cursor = Cursors.AppStarting;
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
                new clsColumns_VO("类别ID","paytypeid_chr",HorizontalAlignment.Left,0),
                new clsColumns_VO("编号","paytypeno_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("费用类别","paytypename_vchr",HorizontalAlignment.Left,140)
            };
            m_objViewer.m_txtPaytype.m_strSQL = @"SELECT   paytypeid_chr, paytypeno_vchr, paytypename_vchr, bihlimitrate_dec,
         internalflag_int
    FROM t_bse_patientpaytype
   WHERE payflag_dec != 1 AND isusing_num != 0
ORDER BY paytypeno_vchr";
            m_objViewer.m_txtPaytype.m_mthInitListView(columArr);

//            //病人身份
//            columArr = new clsColumns_VO[]
//            {
//                new clsColumns_VO("身份ID","paytypeid_chr",HorizontalAlignment.Left,0),
//                new clsColumns_VO("编号","paytypeno_vchr",HorizontalAlignment.Left,40),
//                new clsColumns_VO("身份","paytypename_vchr",HorizontalAlignment.Left,140)
//            };
//            m_objViewer.m_txtPatiemtType.m_strSQL = @"SELECT   paytypeid_chr, paytypeno_vchr, paytypename_vchr
//    FROM t_bse_patientpaytype
//   WHERE payflag_dec != 2 AND isusing_num != 0
//ORDER BY paytypeno_vchr";
//            m_objViewer.m_txtPatiemtType.m_mthInitListView(columArr);

            //职业
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("编号","dictdefinecode_vchr",HorizontalAlignment.Left,40),
                new clsColumns_VO("拼音码","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("职业","dictname_vchr",HorizontalAlignment.Left,60)
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

            // 添加"病人来源"项  陈世春修改于2010\8\25
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

            m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
            m_objViewer.cboSex.SelectedIndex = 0;
            m_objViewer.m_txtRace.Text = "汉族";
            m_objViewer.txtNationality.SelectedValue = "中国";
            m_objViewer.cobMarried.SelectedIndex = 0;
            m_objViewer.m_cboTYPE_INT.SelectedIndex = 0;
            m_objViewer.m_cboSTATE_INT.SelectedIndex = 2;
            m_objViewer.m_cmbFindType.SelectedIndex = 0;
            m_objViewer.cboIsemployee.SelectedIndex = 0;
            m_objViewer.m_dtpBirthDate.Text = "1900-01-01";
            m_objViewer.m_txtAge.Text = "0天";
            //m_objViewer.Cursor = Cursors.Default;
            m_mthFindPatient();

            //出院病人资料，不允许修改
            if (this.m_objViewer.m_strOpentParm == "1")
            {
                DisableContols();
            }

            //保存控件的初始值
            SaveContolsText();
        }
        #endregion

        #region	查找病人
        /// <summary>
        /// 查找病人
        /// </summary>
        public void m_mthFindPatient()
        {
            frmCommonFind frm;
            if (this.m_objViewer.m_strOpentParm == "1" || this.m_objViewer.m_strOpentParm == "2")
            {
                frm = new frmCommonFind("查找病人", 3);
            }
            else
            {
                frm = new frmCommonFind("查找病人", 9);
            }

            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                this.m_strPatientID = frm.PatientID;
                this.m_strRegisterID = frm.RegisterID;
                m_objViewer.Cursor = Cursors.WaitCursor;
                if (m_mthGetRegisterInfoByPatientID())
                {
                    m_mthFindPatientInfoByPatientID();
                }
                m_objViewer.Cursor = Cursors.Default;
            }
            frm = null;
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
                    m_objViewer.Cursor = Cursors.WaitCursor;
                    long lngRes = m_objTran.m_lngGetPatientIDByCarIDOrInPatientID(m_objViewer.m_cmbFindType.SelectedIndex, m_objViewer.m_txtFindText.Text.Trim(), out m_strPatientID);
                    if (lngRes > 0 && m_strPatientID != "")
                    {
                        if (m_mthGetRegisterInfoByPatientID())
                        {
                            m_mthFindPatientInfoByPatientID();
                        }
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
                finally
                {
                    m_objViewer.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region 根据病人ID获取病人入院登记信息
        /// <summary>
        /// 根据病人ID获取病人入院登记信息
        /// </summary>
        public bool m_mthGetRegisterInfoByPatientID()
        {
            try
            {
                long lngRes = -1;
                if (this.m_objViewer.m_strOpentParm == "1" || this.m_objViewer.m_strOpentParm == "2")
                {
                    //出院病人
                    // lngRes = m_objTran.m_lngGetRegisterInfoByPatientID(m_strPatientID, "3", out m_objRegisterVO);
                    lngRes = m_objTran.m_lngGetRegisterInfoByRegisterID(this.m_strRegisterID, out m_objRegisterVO);
                }
                else
                {
                    lngRes = m_objTran.m_lngGetRegisterInfoByPatientID(m_strPatientID, out m_objRegisterVO);
                    //lngRes = m_objTran.m_lngGetRegisterInfoByRegisterID(this.m_strRegisterID, out m_objRegisterVO);
                }

                if (m_objRegisterVO.m_strREGISTERID_CHR != null)
                {
                    m_objViewer.m_lblPStatusName.Text = "第 " + m_objRegisterVO.m_intINPATIENTCOUNT_INT.ToString() + " 次住院";
                    m_objViewer.m_txtInPatienID.Text = m_objRegisterVO.m_strINPATIENTID_CHR;
                    m_objViewer.m_cboInpatientNoType.SelectedIndex = m_objRegisterVO.m_intINPATIENTNOTYPE_INT - 1;
                    m_objViewer.m_dateInHosp.Value = Convert.ToDateTime(m_objRegisterVO.m_strINPATIENT_DAT);
                    m_objViewer.m_cboTYPE_INT.SelectedIndex = m_objRegisterVO.m_intTYPE_INT - 1;
                    m_objViewer.m_txtAREAID.Value = m_objRegisterVO.m_strAREAID_CHR;
                    m_objViewer.m_txtAREAID.Text = m_objRegisterVO.m_strAreaName;
                    m_objViewer.m_txtBedCode.Text = m_objRegisterVO.m_strBedNo;
                    m_objViewer.m_txtMaindoctor.Value = m_objRegisterVO.m_strMZDOCTOR_CHR;
                    m_objViewer.m_txtMaindoctor.Text = m_objRegisterVO.m_stroutdoctorname;
                    m_objViewer.m_cboSTATE_INT.SelectedIndex = m_objRegisterVO.m_intSTATE_INT - 1;
                    m_objViewer.m_txtMZDiagnose.Text = m_objRegisterVO.m_strMZDIAGNOSE_VCHR;
                    m_objViewer.m_txtRemark.Text = m_objRegisterVO.DES_VCHR;
                    m_objViewer.m_txtPaytype.m_mthFindAndSelect(m_objRegisterVO.m_strPAYTYPEID_CHR);
                    m_objViewer.m_txtLIMITRATE_MNY.Text = m_objRegisterVO.m_dblLIMITRATE_MNY.ToString();

                    if (m_objRegisterVO.m_intPSTATUS_INT == 0)
                    {
                        m_objViewer.m_txtAREAID.Enabled = true;
                    }
                    else
                    {
                        m_objViewer.m_txtAREAID.Enabled = false;
                    }

                    //医保病人
                    if (m_objViewer.m_txtinsuranceid.Enabled)
                    {
                        this.m_objViewer.m_txtInsuredTotalMoney.Enabled = true;
                        this.m_objViewer.m_txtInsuredPayMoney.Enabled = true;
                        this.m_objViewer.m_txtInsuredPayScale.Enabled = true;
                        this.m_objViewer.m_txtInsuredPayTime.Enabled = true;
                    }
                }
                else
                {
                    //MessageBox.Show("该病人不在住院！", "修改登记资料", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("无法获取该病人的住院登记信息！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "获取病人住院信息失败！");
                return false;
            }
            return true;
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
            long lngRes = m_objTran.m_lngFindPatientInfoByPatientID(m_strPatientID, out m_objPatientVO);
            //long lngRes = m_objTran.m_lngGetPatientINfoByRegisterID(m_strRegisterID, out m_objPatientVO);
            if (lngRes > 0 && m_objPatientVO.m_strPATIENTID_CHR != "")
            {
                //医保编号
                m_objViewer.m_txtinsuranceid.Text = m_objPatientVO.m_strINSURANCEID_VCHR;
                //出生年月
                if (m_objPatientVO.m_strBIRTH_DAT != null && m_objPatientVO.m_strBIRTH_DAT.ToString() != "")
                {
                    m_objViewer.m_dtpBirthDate.Text = Convert.ToDateTime(m_objPatientVO.m_strBIRTH_DAT).ToString("yyyy-MM-dd");
                    //m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(Convert.ToDateTime(m_objPatientVO.m_strBIRTH_DAT));
                    m_objViewer.m_txtAge.Text = m_objAge.m_strGetAge(Convert.ToDateTime(m_objPatientVO.m_strBIRTH_DAT));
                }
                //身份证号 
                m_objViewer.txtIDCard.Text = m_objPatientVO.m_strIDCARD_CHR;
                //病人姓名 
                m_objViewer.txtPatientName.Text = m_objPatientVO.m_strNAME_VCHR;//m_strLASTNAME_VCHR ;//m_strFIRSTNAME_VCHR;
                //联系电话 
                m_objViewer.txtPhone.Text = m_objPatientVO.m_strHOMEPHONE_VCHR;
                //性别 
                m_objViewer.cboSex.SelectedValue = m_objPatientVO.m_strSEX_CHR;
                //病人身份
                //m_objViewer.m_txtPatiemtType.m_mthFindAndSelect(m_objPatientVO.m_strPAYTYPEID_CHR);
                //是否员工
                m_objViewer.cboIsemployee.SelectedIndex = m_objPatientVO.m_intISEMPLOYEE_INT;
                //病人来源
                m_objViewer.m_cboPatientSource.SelectedValue = m_objPatientVO.m_strPatientSource;
                //婚否 
                m_objViewer.cobMarried.SelectedValue = m_objPatientVO.m_strMARRIED_CHR;
                //移动电话 
                m_objViewer.txtMobile.Text = m_objPatientVO.m_strMOBILE_CHR;
                //家庭住址 
                m_objViewer.txtAddress.Text = m_objPatientVO.m_strHOMEADDRESS_VCHR;
                //国籍
                if (m_objPatientVO.m_strNATIONALITY_VCHR == null || m_objPatientVO.m_strNATIONALITY_VCHR == "")
                {
                    m_objViewer.txtNationality.SelectedValue = "中国";
                }
                else
                {
                    m_objViewer.txtNationality.SelectedValue = m_objPatientVO.m_strNATIONALITY_VCHR;
                }

                m_objViewer.m_txttNativeplace.Text = m_objPatientVO.m_strNATIVEPLACE_VCHR;

                //民族 
                if (m_objPatientVO.m_strRACE_VCHR == null || m_objPatientVO.m_strRACE_VCHR == "")
                {
                    m_objViewer.m_txtRace.Text = "汉族";
                }
                else
                {
                    m_objViewer.m_txtRace.Text = m_objPatientVO.m_strRACE_VCHR;
                }
                //职业 
                m_objViewer.m_txtOccupation.Text = m_objPatientVO.m_strOCCUPATION_VCHR;
                //地址邮编 
                m_objViewer.txtHomepc.Text = m_objPatientVO.m_strHOMEPC_CHR;
                //联系人姓名 
                if (m_objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR != "")
                {
                    m_objViewer.txtContactpersonFirstaName.Text = m_objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR;
                }
                else
                {
                    m_objViewer.txtContactpersonFirstaName.Text = m_objViewer.txtPatientName.Text;
                }
                //联系人电话 
                m_objViewer.txtContactpersonPhone.Text = m_objPatientVO.m_strCONTACTPERSONPHONE_VCHR;
                //联系人邮编 
                m_objViewer.txtContactpersonpc.Text = m_objPatientVO.m_strCONTACTPERSONPC_CHR;
                //与联系人关系 
                m_objViewer.m_txtRelation.Text = m_objPatientVO.m_strPATIENTRELATION_VCHR;
                //联系人地址 
                m_objViewer.txtContactpersonAddress.Text = m_objPatientVO.m_strCONTACTPERSONADDRESS_VCHR;
                //办公电话 
                m_objViewer.txtOfficephone.Text = m_objPatientVO.m_strOFFICEPHONE_VCHR;
                //办公邮编 
                m_objViewer.txtOfficepc.Text = m_objPatientVO.m_strOFFICEPC_VCHR;
                //工作单位 
                m_objViewer.txtEmployer.Text = m_objPatientVO.m_strEMPLOYER_VCHR;
                //电子邮箱 
                m_objViewer.txtEmail.Text = m_objPatientVO.m_strEMAIL_VCHR;
                //办公地址
                m_objViewer.txtOfficeAddress.Text = m_objPatientVO.m_strOFFICEADDRESS_VCHR;
                //作废日期
                m_objViewer.txtDeactivateDate.Text = m_objPatientVO.m_strDEACTIVATE_DAT;
                //操作人员
                m_objViewer.txtOperatorid.Text = m_objPatientVO.m_strOPERATORID_CHR;
                //更新日期
                m_objViewer.txtModifydate.Text = m_objPatientVO.m_strMODIFY_DAT;
                m_objViewer.m_txtGOVCARD_CHR.Text = m_objPatientVO.m_strGOVCARD_CHR;

                m_objViewer.m_txtInsuredTotalMoney.Text = m_objPatientVO.m_decInsuredMoney.ToString();
                m_objViewer.m_txtInsuredPayMoney.Text = m_objPatientVO.m_decInsuredPayMoney.ToString();
                m_objViewer.m_txtInsuredPayTime.Text = m_objPatientVO.m_decInsuredPayTime.ToString();
                m_objViewer.m_txtInsuredPayScale.Text = m_objPatientVO.m_decInsuredPayScale.ToString();
                m_objViewer.txtBirthPlace.Text = m_objPatientVO.m_strBIRTHPLACE_VCHR.ToString();
                m_objViewer.txtResidenceplace.Text = m_objPatientVO.m_strResidencePlace.ToString();
                m_objViewer.txtConsigneeAddr.Text = m_objPatientVO.ConsigneeAddr;
                m_objViewer.txtPatientName.Focus();
            }
            else
            {
                MessageBox.Show("找不到该病人信息！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 保存入院登记
        /// <summary>
        /// 保存入院登记
        /// </summary>
        public void m_mthSaveRegister()
        {
            m_objViewer.Cursor = Cursors.WaitCursor;
            if (!IsPassValidate())
            {
                m_objViewer.Cursor = Cursors.Default;
                return;
            }
            int intFlag;
            if (m_objRegisterVO.m_strAREAID_CHR != m_objViewer.m_txtAREAID.Value)
            {
                intFlag = 1;
            }
            else
            {
                intFlag = 0;
            }
            ValueToVoForBaseInfo();
            ValueToVoForBIHInfo();
            try
            {
                // 同步身份 2018-04-23
                m_objPatientVO.m_strPAYTYPEID_CHR = m_objRegisterVO.m_strPAYTYPEID_CHR;
                m_objTran.m_lngEditRegister(intFlag, m_objPatientVO, m_objRegisterVO);
                MessageBox.Show("保存成功！", "修改登记资料", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //保存变动日志
                SaveEditLog();

                //控件的当前值为初始值
                SaveContolsText();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "修改登记资料", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                m_objViewer.Cursor = Cursors.Default;
            }
        }

        #region 保存变动日志
        private void SaveEditLog()
        {
            clsPatientInfLog patientLogVo = new clsPatientInfLog();
            patientLogVo.operatorId = this.m_objViewer.LoginInfo.m_strEmpID;
            patientLogVo.registerId = this.m_objRegisterVO.m_strREGISTERID_CHR;
            patientLogVo.desc = "";

            //姓名
            if (this.m_initCtl.Contains("txtPatientName"))
            {
                if (this.m_initCtl["txtPatientName"].ToString() != this.m_objViewer.txtPatientName.Text)
                {
                    patientLogVo.detail = "姓名：" + this.m_initCtl["txtPatientName"].ToString() + "--> " + this.m_objViewer.txtPatientName.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //住院类型
            if (this.m_initCtl.Contains("m_cboInpatientNoType"))
            {
                if (this.m_initCtl["m_cboInpatientNoType"].ToString() != this.m_objViewer.m_cboInpatientNoType.Text)
                {
                    patientLogVo.detail = "住院类型：" + this.m_initCtl["m_cboInpatientNoType"].ToString() + "--> " + this.m_objViewer.m_cboInpatientNoType.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //性别
            if (this.m_initCtl.Contains("cboSex"))
            {
                if (this.m_initCtl["cboSex"].ToString() != this.m_objViewer.cboSex.Text)
                {
                    patientLogVo.detail = "性别：" + this.m_initCtl["cboSex"].ToString() + "--> " + this.m_objViewer.cboSex.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //出生日期
            if (this.m_initCtl.Contains("m_dtpBirthDate"))
            {
                if (this.m_initCtl["m_dtpBirthDate"].ToString() != this.m_objViewer.m_dtpBirthDate.Text)
                {
                    patientLogVo.detail = "出生日期：" + this.m_initCtl["m_dtpBirthDate"].ToString() + "--> " + this.m_objViewer.m_dtpBirthDate.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //婚否
            if (this.m_initCtl.Contains("cobMarried"))
            {
                if (this.m_initCtl["cobMarried"].ToString() != this.m_objViewer.cobMarried.Text)
                {
                    patientLogVo.detail = "婚否：" + this.m_initCtl["cobMarried"].ToString() + "--> " + this.m_objViewer.cobMarried.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //民族
            if (this.m_initCtl.Contains("m_txtRace"))
            {
                if (this.m_initCtl["m_txtRace"].ToString() != this.m_objViewer.m_txtRace.Text)
                {
                    patientLogVo.detail = "民族：" + this.m_initCtl["m_txtRace"].ToString() + "--> " + this.m_objViewer.m_txtRace.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //国籍
            if (this.m_initCtl.Contains("txtNationality"))
            {
                if (this.m_initCtl["txtNationality"].ToString() != this.m_objViewer.txtNationality.Text)
                {
                    patientLogVo.detail = "国籍：" + this.m_initCtl["txtNationality"].ToString() + "--> " + this.m_objViewer.txtNationality.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //是否职工
            if (this.m_initCtl.Contains("cboIsemployee"))
            {
                if (this.m_initCtl["cboIsemployee"].ToString() != this.m_objViewer.cboIsemployee.Text)
                {
                    patientLogVo.detail = "是否职工：" + this.m_initCtl["cboIsemployee"].ToString() + "--> " + this.m_objViewer.cboIsemployee.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //医疗证号
            if (this.m_initCtl.Contains("m_txtGOVCARD_CHR"))
            {
                if (this.m_initCtl["m_txtGOVCARD_CHR"].ToString() != this.m_objViewer.m_txtGOVCARD_CHR.Text)
                {
                    patientLogVo.detail = "医疗证号：" + this.m_initCtl["m_txtGOVCARD_CHR"].ToString() + "--> " + this.m_objViewer.m_txtGOVCARD_CHR.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //身份
            //if (this.m_initCtl.Contains("m_txtPatiemtType"))
            //{
            //    if (this.m_initCtl["m_txtPatiemtType"].ToString() != this.m_objViewer.m_txtPatiemtType.Text)
            //    {
            //        patientLogVo.detail = "身份：" + this.m_initCtl["m_txtPatiemtType"].ToString() + "--> " + this.m_objViewer.m_txtPatiemtType.Text;

            //        m_objTran.AddPatienInfLog(patientLogVo);
            //    }
            //}


            //费用类别
            if (this.m_initCtl.Contains("m_txtPaytype"))
            {
                if (this.m_initCtl["m_txtPaytype"].ToString() != this.m_objViewer.m_txtPaytype.Text)
                {
                    patientLogVo.detail = "姓名：" + this.m_initCtl["m_txtPaytype"].ToString() + "--> " + this.m_objViewer.m_txtPaytype.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //医保号
            if (this.m_initCtl.Contains("m_txtinsuranceid"))
            {
                if (this.m_initCtl["m_txtinsuranceid"].ToString() != this.m_objViewer.m_txtinsuranceid.Text)
                {
                    patientLogVo.detail = "医保号：" + this.m_initCtl["m_txtinsuranceid"].ToString() + "--> " + this.m_objViewer.m_txtinsuranceid.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //身份证号
            if (this.m_initCtl.Contains("txtIDCard"))
            {
                if (this.m_initCtl["txtIDCard"].ToString() != this.m_objViewer.txtIDCard.Text)
                {
                    patientLogVo.detail = "身份证号：" + this.m_initCtl["txtIDCard"].ToString() + "--> " + this.m_objViewer.txtIDCard.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //家庭地址
            if (this.m_initCtl.Contains("txtAddress"))
            {
                if (this.m_initCtl["txtAddress"].ToString() != this.m_objViewer.txtAddress.Text)
                {
                    patientLogVo.detail = "家庭地址：" + this.m_initCtl["txtAddress"].ToString() + "--> " + this.m_objViewer.txtAddress.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //医保剩余金额
            if (this.m_initCtl.Contains("m_txtInsuredTotalMoney"))
            {
                if (this.m_initCtl["m_txtInsuredTotalMoney"].ToString() != this.m_objViewer.m_txtInsuredTotalMoney.Text)
                {
                    patientLogVo.detail = "医保剩余金额：" + this.m_initCtl["m_txtInsuredTotalMoney"].ToString() + "--> " + this.m_objViewer.m_txtInsuredTotalMoney.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //医保报销次数
            if (this.m_initCtl.Contains("m_txtInsuredPayTime"))
            {
                if (this.m_initCtl["m_txtInsuredPayTime"].ToString() != this.m_objViewer.m_txtInsuredPayTime.Text)
                {
                    patientLogVo.detail = "医保报销次数：" + this.m_initCtl["m_txtInsuredPayTime"].ToString() + "--> " + this.m_objViewer.m_txtInsuredPayTime.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //医保报销金额
            if (this.m_initCtl.Contains("m_txtInsuredPayMoney"))
            {
                if (this.m_initCtl["m_txtInsuredPayMoney"].ToString() != this.m_objViewer.m_txtInsuredPayMoney.Text)
                {
                    patientLogVo.detail = "医保报销金额：" + this.m_initCtl["m_txtInsuredPayMoney"].ToString() + "--> " + this.m_objViewer.m_txtInsuredPayMoney.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //入院时间
            if (this.m_initCtl.Contains("m_dateInHosp"))
            {
                if (this.m_initCtl["m_dateInHosp"].ToString() != this.m_objViewer.m_dateInHosp.Text)
                {
                    patientLogVo.detail = "入院时间：" + this.m_initCtl["m_dateInHosp"].ToString() + "--> " + this.m_objViewer.m_dateInHosp.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //转入方式
            if (this.m_initCtl.Contains("m_cboTYPE_INT"))
            {
                if (this.m_initCtl["m_cboTYPE_INT"].ToString() != this.m_objViewer.m_cboTYPE_INT.Text)
                {
                    patientLogVo.detail = "转入方式：" + this.m_initCtl["m_cboTYPE_INT"].ToString() + "--> " + this.m_objViewer.m_cboTYPE_INT.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }

            //门诊医生
            if (this.m_initCtl.Contains("m_txtMaindoctor"))
            {
                if (this.m_initCtl["m_txtMaindoctor"].ToString() != this.m_objViewer.m_txtMaindoctor.Text)
                {
                    patientLogVo.detail = "门诊医生：" + this.m_initCtl["m_txtMaindoctor"].ToString() + "--> " + this.m_objViewer.m_txtMaindoctor.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


            //费用下限
            if (this.m_initCtl.Contains("m_txtLIMITRATE_MNY"))
            {
                if (this.m_initCtl["m_txtLIMITRATE_MNY"].ToString() != this.m_objViewer.m_txtLIMITRATE_MNY.Text)
                {
                    patientLogVo.detail = "费用下限：" + this.m_initCtl["m_txtLIMITRATE_MNY"].ToString() + "--> " + this.m_objViewer.m_txtLIMITRATE_MNY.Text;

                    m_objTran.AddPatienInfLog(patientLogVo);
                }
            }


        }
        #endregion

        #endregion

        #region 控件赋值给基本信息Vo
        /// <summary>
        /// 控件赋值给基本信息Vo
        /// </summary>
        private void ValueToVoForBaseInfo()
        {
            //医保编号
            m_objPatientVO.m_strINSURANCEID_VCHR = m_objViewer.m_txtinsuranceid.Text;
            //出生年月
            try
            {
                m_objPatientVO.m_strBIRTH_DAT = Convert.ToDateTime(m_objViewer.m_dtpBirthDate.Text).ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch
            {
            }
            //身份证号 
            m_objPatientVO.m_strIDCARD_CHR = m_objViewer.txtIDCard.Text;
            //病人姓名 
            m_objPatientVO.m_strLASTNAME_VCHR = m_objViewer.txtPatientName.Text;
            m_objPatientVO.m_strFIRSTNAME_VCHR = m_objViewer.txtPatientName.Text;
            m_objPatientVO.m_strNAME_VCHR = m_objViewer.txtPatientName.Text;
            //联系电话 
            m_objPatientVO.m_strHOMEPHONE_VCHR = m_objViewer.txtPhone.Text;
            //性别 
            m_objPatientVO.m_strSEX_CHR = (string)m_objViewer.cboSex.SelectedValue;
            //费用类别
            //m_objPatientVO.m_strPAYTYPEID_CHR = m_objViewer.m_txtPatiemtType.Value;
            //是否员工
            m_objPatientVO.m_intISEMPLOYEE_INT = m_objViewer.cboIsemployee.SelectedIndex;
            //婚否 
            m_objPatientVO.m_strMARRIED_CHR = (string)m_objViewer.cobMarried.SelectedValue;
            //移动电话 
            m_objPatientVO.m_strMOBILE_CHR = m_objViewer.txtMobile.Text;
            //家庭住址 
            m_objPatientVO.m_strHOMEADDRESS_VCHR = m_objViewer.txtAddress.Text;
            //国籍
            m_objPatientVO.m_strNATIONALITY_VCHR = (string)m_objViewer.txtNationality.SelectedValue;

            m_objPatientVO.m_strNATIVEPLACE_VCHR = m_objViewer.m_txttNativeplace.Text;

            //民族 
            m_objPatientVO.m_strRACE_VCHR = m_objViewer.m_txtRace.Text;
            //职业 
            m_objPatientVO.m_strOCCUPATION_VCHR = m_objViewer.m_txtOccupation.Text.Trim();
            //病人来源
            m_objPatientVO.m_strPatientSource = (string)m_objViewer.m_cboPatientSource.SelectedValue;
            //地址邮编 
            m_objPatientVO.m_strHOMEPC_CHR = m_objViewer.txtHomepc.Text;
            //联系人姓名 
            m_objPatientVO.m_strCONTACTPERSONFIRSTNAME_VCHR = m_objViewer.txtContactpersonFirstaName.Text;
            m_objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonFirstaName.Text;
            //联系人电话 
            m_objPatientVO.m_strCONTACTPERSONPHONE_VCHR = m_objViewer.txtContactpersonPhone.Text;
            //联系人邮编 
            m_objPatientVO.m_strCONTACTPERSONPC_CHR = m_objViewer.txtContactpersonpc.Text;
            //与联系人关系 
            m_objPatientVO.m_strPATIENTRELATION_VCHR = m_objViewer.m_txtRelation.Text.Trim();
            //联系人地址 
            m_objPatientVO.m_strCONTACTPERSONADDRESS_VCHR = m_objViewer.txtContactpersonAddress.Text;
            //办公电话 
            m_objPatientVO.m_strOFFICEPHONE_VCHR = m_objViewer.txtOfficephone.Text;
            //办公邮编 
            m_objPatientVO.m_strOFFICEPC_VCHR = m_objViewer.txtOfficepc.Text;
            //工作单位 
            m_objPatientVO.m_strEMPLOYER_VCHR = m_objViewer.txtEmployer.Text;
            //电子邮箱 
            m_objPatientVO.m_strEMAIL_VCHR = m_objViewer.txtEmail.Text;
            //办公地址
            m_objPatientVO.m_strOFFICEADDRESS_VCHR = m_objViewer.txtOfficeAddress.Text;
            //操作人员
            m_objPatientVO.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            m_objPatientVO.m_strGOVCARD_CHR = m_objViewer.m_txtGOVCARD_CHR.Text.Trim();

            try
            {
                m_objPatientVO.m_decInsuredMoney = Convert.ToDecimal(m_objViewer.m_txtInsuredTotalMoney.Text);
            }
            catch
            {
                m_objPatientVO.m_decInsuredMoney = 0;
            }

            try
            {
                m_objPatientVO.m_decInsuredPayMoney = Convert.ToDecimal(m_objViewer.m_txtInsuredPayMoney.Text);
            }
            catch
            {
                m_objPatientVO.m_decInsuredPayMoney = 0;
            }

            try
            {
                m_objPatientVO.m_decInsuredPayTime = Convert.ToDecimal(m_objViewer.m_txtInsuredPayTime.Text);
            }
            catch
            {
                m_objPatientVO.m_decInsuredPayTime = 0;
            }

            try
            {
                m_objPatientVO.m_decInsuredPayScale = Convert.ToDecimal(m_objViewer.m_txtInsuredPayScale.Text);
            }
            catch
            {
                m_objPatientVO.m_decInsuredPayScale = 100;
            }

            m_objPatientVO.m_strBIRTHPLACE_VCHR = this.m_objViewer.txtBirthPlace.Text.Trim();
            m_objPatientVO.m_strResidencePlace = this.m_objViewer.txtResidenceplace.Text.Trim();
            m_objPatientVO.ConsigneeAddr = this.m_objViewer.txtConsigneeAddr.Text.Trim();
        }
        #endregion

        #region 控件赋值给入院登记信息Vo
        /// <summary>
        /// 控件赋值给入院登记信息Vo
        /// </summary>
        private bool ValueToVoForBIHInfo()
        {
            m_objRegisterVO.m_strINPATIENT_DAT = m_objViewer.m_dateInHosp.Value.ToString("yyyy-MM-dd HH:mm:ss");
            m_objRegisterVO.m_strAREAID_CHR = m_objViewer.m_txtAREAID.Value;
            m_objRegisterVO.m_intTYPE_INT = m_objViewer.m_cboTYPE_INT.SelectedIndex + 1;
            if (m_objViewer.m_txtLIMITRATE_MNY.Text.Trim() == "")
            {
                m_objRegisterVO.m_dblLIMITRATE_MNY = 0;
            }
            else
            {
                m_objRegisterVO.m_dblLIMITRATE_MNY = Convert.ToDouble(m_objViewer.m_txtLIMITRATE_MNY.Text.Trim());
            }
            m_objRegisterVO.m_intSTATE_INT = m_objViewer.m_cboSTATE_INT.SelectedIndex + 1;
            m_objRegisterVO.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            m_objRegisterVO.m_intPSTATUS_INT = 0;
            m_objRegisterVO.m_strMZDOCTOR_CHR = m_objViewer.m_txtMaindoctor.Value;
            m_objRegisterVO.m_strPAYTYPEID_CHR = m_objViewer.m_txtPaytype.Value;
            m_objRegisterVO.m_strMZDIAGNOSE_VCHR = m_objViewer.m_txtMZDiagnose.Text.Trim();
            m_objRegisterVO.DES_VCHR = m_objViewer.m_txtRemark.Text.Trim();
            return true;
        }
        #endregion

        #region 清空所有信息
        /// <summary>
        /// 清空所有信息
        /// </summary>
        public void m_EmptyAndInitialization()
        {
            // 清空住院状态
            m_strRegisterID = "";
            m_strPatientID = "";
            m_objViewer.m_txtFindText.Text = "";
            m_objViewer.m_lblPStatusName.Text = "首次入院";
            m_EmptyBaseInfo();
            m_objPatientVO = null;
            m_EmptyBihRegisterInfo();
            m_objRegisterVO = null;
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
            //家庭住址 
            m_objViewer.txtAddress.Text = "";
            //国籍
            m_objViewer.txtNationality.SelectedValue = "中国";
            //民族 
            m_objViewer.m_txtRace.Text = "汉族";
            //职业 
            m_objViewer.m_txtOccupation.Text = "";
            m_objViewer.m_txtOccupation.m_mthFindDate();
            m_objViewer.m_txtOccupation.m_listView.Visible = false;
            //地址邮编 
            m_objViewer.txtHomepc.Text = "";
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

            m_objViewer.txtConsigneeAddr.Text = "";
        }
        #endregion

        #region 清空住院信息
        /// <summary>
        /// 清空住院信息
        /// </summary>
        public void m_EmptyBihRegisterInfo()
        {
            m_objViewer.m_cboInpatientNoType.SelectedIndex = 0;
            //入院日期
            m_objViewer.m_dateInHosp.Enabled = true;
            m_objViewer.m_dateInHosp.Text = "";
            m_objViewer.m_dateInHosp.Tag = "";
            //入院病区
            m_objViewer.m_txtAREAID.Value = null;
            m_objViewer.m_txtAREAID.Text = "";
            if (m_objViewer.m_txtAREAID.Enabled)
            {
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
            m_objViewer.m_txtPaytype.Value = null;
            m_objViewer.m_txtPaytype.Text = "";
            m_objViewer.m_txtPaytype.m_mthFindDate();
            m_objViewer.m_txtLIMITRATE_MNY.Text = "";
            ////身份类别
            //m_objViewer.m_txtPatiemtType.Value = null;
            //m_objViewer.m_txtPatiemtType.Text = "";
            //m_objViewer.m_txtPatiemtType.m_mthFindDate();
            m_mthSetPatType();
            m_objViewer.m_txtMaindoctor.Value = null;
            m_objViewer.m_txtMaindoctor.Text = "";
            m_objViewer.m_txtMaindoctor.m_mthFindDate();
            m_objViewer.m_txtRemark.Text = "";
            m_objViewer.m_txtMZDiagnose.Text = "";
            m_objViewer.m_txtInPatienID.Text = "";
            m_objViewer.m_txtBedCode.Text = "";
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
                    m_objViewer.m_txtinsuranceid.Text = "";
                    m_objViewer.m_txtinsuranceid.Enabled = true;

                    this.m_objViewer.m_txtInsuredTotalMoney.Enabled = true;
                    this.m_objViewer.m_txtInsuredPayMoney.Enabled = true;
                    this.m_objViewer.m_txtInsuredPayTime.Enabled = true;
                }
                else
                {
                    m_objViewer.m_txtinsuranceid.Text = "";
                    m_objViewer.m_txtinsuranceid.Enabled = false;

                    this.m_objViewer.m_txtInsuredTotalMoney.Enabled = false;
                    this.m_objViewer.m_txtInsuredPayMoney.Enabled = false;
                    this.m_objViewer.m_txtInsuredPayTime.Enabled = false;
                }
            }
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
            if (m_strPatientID == "")
            {
                m_EmptyAndInitialization();
            }
            else
            {
                if (m_mthGetRegisterInfoByPatientID())
                {
                    m_mthFindPatientInfoByPatientID();
                }
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
                //    }
                //}
                if (m_objViewer.txtIDCard.Text.Trim().Length != 18)
                {
                    MessageBox.Show("请注意：身份证号不是18位", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            if (m_objPatientVO == null)
            {
                MessageBox.Show(m_objViewer, "请调入病人信息！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (m_objViewer.txtPatientName.Text.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "病人姓名为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (m_objViewer.m_txtAREAID.Value == null || m_objViewer.m_txtAREAID.Text == string.Empty)
            {
                MessageBox.Show("病区为必填项!", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtAREAID.Focus();
                return false;
            }
            if (m_objViewer.m_txtMaindoctor.Value == null || m_objViewer.m_txtMaindoctor.Text == string.Empty)
            {
                MessageBox.Show("门诊医生为必填项！", "入院登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    m_objViewer.m_txtAge.Text = m_objAge.m_strGetAge(tempDate);
                }
            }
            catch
            {
                return;
            }
        }
        #endregion

        private void SaveContolsText()
        {
            this.m_initCtl = new Hashtable();
            for (int i = 0; i < this.m_objViewer.groupBox2.Controls.Count; i++)
            {
                if (!this.m_initCtl.Contains(this.m_objViewer.groupBox2.Controls[i].Name))
                {
                    this.m_initCtl.Add(this.m_objViewer.groupBox2.Controls[i].Name, this.m_objViewer.groupBox2.Controls[i].Text);
                }
            }

            for (int i = 0; i < this.m_objViewer.groupBox5.Controls.Count; i++)
            {
                if (!this.m_initCtl.Contains(this.m_objViewer.groupBox5.Controls[i].Name))
                {
                    this.m_initCtl.Add(this.m_objViewer.groupBox5.Controls[i].Name, this.m_objViewer.groupBox5.Controls[i].Text);
                }
            }
        }

        private void DisableContols()
        {
            for (int i = 0; i < this.m_objViewer.groupBox2.Controls.Count; i++)
            {
                if (!(this.m_objViewer.groupBox2.Controls[i] is Label))
                {
                    this.m_objViewer.groupBox2.Controls[i].Enabled = false;
                    this.m_objViewer.groupBox2.Controls[i].BackColor = System.Drawing.Color.White;
                    this.m_objViewer.groupBox2.Controls[i].ForeColor = System.Drawing.Color.Black;
                }
            }

            for (int i = 0; i < this.m_objViewer.groupBox5.Controls.Count; i++)
            {
                if (!(this.m_objViewer.groupBox5.Controls[i] is Label))
                {
                    this.m_objViewer.groupBox5.Controls[i].Enabled = false;
                    this.m_objViewer.groupBox5.Controls[i].BackColor = System.Drawing.Color.White;
                    this.m_objViewer.groupBox5.Controls[i].ForeColor = System.Drawing.Color.Black;
                }
            }

            this.m_objViewer.cmdSaveBihRegister.Visible = false;
            this.m_objViewer.cmdEmpty.Enabled = false;
        }


        #region	加入嵌入式社保调用登记窗体
        /// <summary>
        /// 调用社保窗体
        /// </summary>
        public void m_mthYBPatient()
        {
            string strRegisterID = m_objRegisterVO.m_strREGISTERID_CHR;
            if (strRegisterID == string.Empty)
            {
                return;
            }
            frmYBRegisterZY objYBReg = new frmYBRegisterZY();
            objYBReg.strRegisterId = strRegisterID;
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

}
