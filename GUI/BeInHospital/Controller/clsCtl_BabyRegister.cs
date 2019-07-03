using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using System.Collections;

using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 修改住院信息 - 逻辑控制 glzhang 2006.06.21
    /// </summary>
    class clsCtl_BabyRegister : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量声明
        clsDcl_BIHTransfer m_objManage = null;
        /// <summary>
        /// 病人住院信息VO
        /// </summary>
        clsBIHpatientVO p_objRrecord;
        /// <summary>
        /// 预交金余额
        /// </summary>
        decimal decBalance = 0;
        /// <summary>
        /// 未清费用
        /// </summary>
        decimal decUnclearCharge = 0;

        /// <summary>
        /// 病人费用类别
        /// </summary>
        public clsPatientPayTypeVO[] p_objRecordArr;

        /// <summary>
        /// 是否设置婴儿姓名
        /// </summary>
        private bool m_blnSetName = false;

        /// <summary>
        /// 婴儿基本信息
        /// </summary>
        public clsPatient_VO[] m_objPatientInfoArr = null;

        /// <summary>
        /// 婴儿入院登记主表信息
        /// </summary>
        public clsT_Opr_Bih_Register_VO[] m_objBabyRegisterInfoArr = null;


        private DataTable m_dtbBabyRegister = null;

        #endregion

        #region 构造函数
        public clsCtl_BabyRegister()
        {
            m_objManage = new clsDcl_BIHTransfer();
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmBabyRegister m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmBabyRegister)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化数据
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void m_mthInit()
        {
            //登录用户所属默认病区
            this.m_objViewer.m_txtArea.Tag = this.m_objViewer.LoginInfo.m_strInpatientAreaID;
            this.m_objViewer.m_txtArea.Text = this.m_objViewer.LoginInfo.m_strInpatientAreaName;
            m_objViewer.strAreaName = m_objViewer.LoginInfo.m_strInpatientAreaName;

            m_objViewer.m_cmbBabyOrder.SelectedIndex = 0;
            m_objViewer.m_txtBabyName.Text = string.Empty;
            m_objViewer.m_cmBabySex.SelectedIndex = 0;
            m_objViewer.m_datBabyBrithday.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            try
            {

                long lngRes = m_objManage.m_GetBIHPatientType(out p_objRecordArr);
                m_objViewer.m_cmdBabyPayType.DataSource = p_objRecordArr;
                m_objViewer.m_cmdBabyPayType.DisplayMember = "m_strPayTypeName";
                m_objViewer.m_cmdBabyPayType.ValueMember = "m_strPayTypeID";
                if (m_objViewer.m_cmdBabyPayType.Items.Count > 0)
                {
                    this.m_objViewer.m_cmdBabyPayType.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "获取费用类别失败！");
            }
        }
        #endregion

        #region 保存婴儿入院登记（新增）
        /// <summary>
        /// 保存婴儿入院登记（新增）
        /// </summary>
        public void m_mthBabyRegister()
        {
            if (p_objRrecord == null || p_objRrecord.m_strREGISTERID_CHR == "")
            {
                MessageBox.Show("请输入病人信息！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (m_objViewer.m_txtBabyName.Text.Trim() == "")
            {
                MessageBox.Show("婴儿姓名不能为空！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                clsPatient_VO p_objPatientInfo;
                clsT_Opr_Bih_Register_VO p_obRegisterInfo;
                long lngRes = m_objManage.m_lngFindPatientInfoByPatientID(p_objRrecord.m_strPATIENTID_CHR, out p_objPatientInfo);
                if (lngRes > 0 && p_objPatientInfo.m_strPATIENTID_CHR != null)
                {
                    p_objPatientInfo.m_strFIRSTNAME_VCHR = m_objViewer.m_txtBabyName.Text.Trim();
                    p_objPatientInfo.m_strLASTNAME_VCHR = m_objViewer.m_txtBabyName.Text.Trim();
                    p_objPatientInfo.m_strNAME_VCHR = m_objViewer.m_txtBabyName.Text.Trim();
                    p_objPatientInfo.m_strSEX_CHR = m_objViewer.m_cmBabySex.Text;
                    p_objPatientInfo.m_strBIRTH_DAT = m_objViewer.m_datBabyBrithday.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                {
                    MessageBox.Show("获取婴儿母亲的基本信息失败！", "婴儿登记");
                    return;
                }
                lngRes = m_objManage.m_lngGetRegisterInfoByID(p_objRrecord.m_strREGISTERID_CHR, out p_obRegisterInfo);
                if (lngRes > 0 && p_obRegisterInfo.m_strREGISTERID_CHR != null)
                {
                    //string strOrder = "BCDEFGHIJ";
                    System.Collections.Generic.Dictionary<int, string> dicNum = new System.Collections.Generic.Dictionary<int, string>();
                    dicNum.Add(0, "A");
                    dicNum.Add(1, "B");
                    dicNum.Add(2, "C");
                    dicNum.Add(3, "D");
                    dicNum.Add(4, "E");
                    dicNum.Add(5, "F");
                    dicNum.Add(6, "G");
                    dicNum.Add(7, "H");
                    dicNum.Add(8, "I");
                    dicNum.Add(9, "J");
                    p_obRegisterInfo.m_strINPATIENTID_CHR = p_obRegisterInfo.m_strINPATIENTID_CHR + dicNum[m_objViewer.m_cmbBabyOrder.SelectedIndex + 1];//strOrder[m_objViewer.m_cmbBabyOrder.SelectedIndex];
                    //p_obRegisterInfo.m_strPATIENTID_CHR = p_obRegisterInfo.m_strPATIENTID_CHR.TrimStart('0') + strOrder[m_objViewer.m_cmbBabyOrder.SelectedIndex];
                    //p_obRegisterInfo.m_strPATIENTID_CHR = p_obRegisterInfo.m_strPATIENTID_CHR.PadLeft(10, '0');
                    p_obRegisterInfo.m_strPATIENTID_CHR = p_obRegisterInfo.m_strPATIENTID_CHR.Substring(0, p_obRegisterInfo.m_strPATIENTID_CHR.Length - 1) + dicNum[m_objViewer.m_cmbBabyOrder.SelectedIndex];
                    p_obRegisterInfo.m_intBORNNUM_INT = m_objViewer.m_cmbBabyOrder.SelectedIndex + 1;

                    p_obRegisterInfo.m_strPAYTYPEID_CHR = (string)m_objViewer.m_cmdBabyPayType.SelectedValue;
                    p_obRegisterInfo.m_strRELATEREGISTERID_CHR = p_obRegisterInfo.m_strREGISTERID_CHR;
                    p_obRegisterInfo.m_intPSTATUS_INT = 0;
                    p_obRegisterInfo.m_intINPATIENTCOUNT_INT = 1;
                    p_obRegisterInfo.m_strBEDID_CHR = "";
                    p_obRegisterInfo.m_intSTATE_INT = 3;
                    p_obRegisterInfo.m_strICD10DIAGID_VCHR = "";
                    p_obRegisterInfo.m_strICD10DIAGTEXT_VCHR = "";
                    p_obRegisterInfo.m_intIsShunchan = m_objViewer.chk_isSC.Checked ? 1 : 0;// 是否顺产 by zmx
                }
                else
                {
                    MessageBox.Show("获取婴儿母亲的入院登记信息失败！", "婴儿登记");
                    m_objViewer.m_cmbBabyOrder.Focus();
                    return;
                }

                lngRes = m_objManage.m_lngBabyRegister(p_objPatientInfo, p_obRegisterInfo);
                if (lngRes > 0)
                {
                    MessageBox.Show("保存成功！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthClearControl();
                }
                // 原代码是如果是已经存在的婴儿，中间件就throw new Exception("0")，但在跑三层时会出错，现修改成返回-3。
                else if (lngRes == -3)
                {
                    MessageBox.Show("该胎次婴儿已有登记记录！", "婴儿登记失败", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("保存失败！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 保存婴儿入院登记(修改)
        /// <summary>
        /// 保存婴儿入院登记(修改)
        /// </summary>
        public void m_mthChangeBabyRegister()
        {
            if (p_objRrecord == null || p_objRrecord.m_strREGISTERID_CHR == "")
            {
                MessageBox.Show("请输入病人信息！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (m_objViewer.m_txtBabyName.Text.Trim() == "")
            {
                MessageBox.Show("婴儿姓名不能为空！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (m_objViewer.m_txtBabyName.Tag == null || string.IsNullOrEmpty(m_objViewer.m_txtBabyName.Tag.ToString()))
            {
                MessageBox.Show("请选择婴儿！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                //明细表
                clsPatient_VO m_objPatientInfo = new clsPatient_VO();
                m_objPatientInfo.m_strFIRSTNAME_VCHR = m_objViewer.m_txtBabyName.Text.Trim();
                m_objPatientInfo.m_strLASTNAME_VCHR = m_objViewer.m_txtBabyName.Text.Trim();
                m_objPatientInfo.m_strNAME_VCHR = m_objViewer.m_txtBabyName.Text.Trim();
                m_objPatientInfo.m_strSEX_CHR = m_objViewer.m_cmBabySex.Text;
                m_objPatientInfo.m_strBIRTH_DAT = Convert.ToDateTime(m_objViewer.m_datBabyBrithday.Text).ToString("yyyy-MM-dd HH:mm:ss");

                //主表
                clsT_Opr_Bih_Register_VO m_objBabyRegisterInfo = new clsT_Opr_Bih_Register_VO();
                m_objBabyRegisterInfo.m_intBORNNUM_INT = m_objViewer.m_cmbBabyOrder.SelectedIndex + 1;
                m_objBabyRegisterInfo.m_strPAYTYPEID_CHR = (string)m_objViewer.m_cmdBabyPayType.SelectedValue;

                m_objBabyRegisterInfo.m_strREGISTERID_CHR = (string)m_objViewer.m_txtBabyName.Tag;

                m_objBabyRegisterInfo.m_intIsShunchan = m_objViewer.chk_isSC.Checked ? 1 : 0;// 是否顺产 by zmx


                long lngRes = m_objManage.m_lngChangeBabyRegister(m_objPatientInfo, m_objBabyRegisterInfo);
                if (lngRes > 0)
                {
                    MessageBox.Show("保存成功！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthClearControl();
                }
                else
                {
                    MessageBox.Show("保存失败！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion


        #region 清空控件文本
        /// <summary>
        /// 清空控件文本
        /// </summary>
        private void m_mthClearControl()
        {
            p_objRrecord = null;
            m_blnSetName = false;
            // m_objViewer.m_cmbBabyOrder.Items.Clear();
            m_objViewer.m_txtBabyName.Tag = null;
            m_objViewer.m_cmbBabyOrder.SelectedIndex = -1;
            m_objViewer.m_cmBabySex.SelectedIndex = -1;
            if (m_objViewer.m_cmdBabyPayType.Items.Count > 0)
            {
                this.m_objViewer.m_cmdBabyPayType.SelectedIndex = 0;
            }
            m_objViewer.m_txtBabyName.Text = "";
            foreach (object obj in m_objViewer.m_groMathorInfo.Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Text = "";
                }
            }

            this.m_objViewer.m_txtArea.Focus();
            this.m_objViewer.m_txtBedNo2.Text = "";
            this.m_objViewer.chk_isSC.Checked = false;//add by zxm
        }
        #endregion

        #region 根据入院登记ID获取病人住院信息
        /// <summary>
        /// 根据入院登记ID获取病人住院信息
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        public void m_mthGetBIHPatientInfo()
        {

            frmCommonFind frm = new frmCommonFind();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                p_objRrecord = null;
                decBalance = 0;
                decUnclearCharge = 0;
                try
                {
                    long lngRes = m_objManage.m_lngGetBIHPatientInfoAndCharge(frm.RegisterID, out p_objRrecord);
                    if (lngRes > 0 && p_objRrecord != null)
                    {
                        if (p_objRrecord.m_strSEX_CHR != "女")
                        {
                            MessageBox.Show("应选择女性！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frm = null;
                            m_mthGetBIHPatientInfo();
                            return;
                        }

                        if (p_objRrecord.m_strINPATIENTID_CHR.EndsWith("B") == true)
                        {
                            MessageBox.Show("应选择婴儿的母亲！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //frm = null;
                            //m_mthGetBIHPatientInfo();
                            this.m_objViewer.m_txtBedNo2.Focus();
                            return;
                        }

                        if (p_objRrecord.m_strPSTATUS_INT == "3" && p_objRrecord.m_strSTATUS_INT != "1")
                        {
                            MessageBox.Show("只能对在院病人对婴儿登记！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            frm = null;
                            m_mthGetBIHPatientInfo();
                            return;
                        }
                        frm = null;
                        if (p_objRrecord.m_strUnclearCharge != "" && p_objRrecord.m_strUnclearCharge == null)
                        {
                            decUnclearCharge = Convert.ToDecimal(p_objRrecord.m_strUnclearCharge);
                        }
                        if (p_objRrecord.m_strBalance != "" && p_objRrecord.m_strBalance == null)
                        {
                            decBalance = Convert.ToDecimal(p_objRrecord.m_strBalance);
                        }
                        m_objViewer.m_txtName.Text = p_objRrecord.m_strNAME_VCHR;
                        m_objViewer.m_txtInHospitalID.Text = p_objRrecord.m_strINPATIENTID_CHR;
                        m_objViewer.m_txtSex.Text = p_objRrecord.m_strSEX_CHR;
                        m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(p_objRrecord.m_strBIRTH_DAT);
                        m_objViewer.m_txtArear.Text = p_objRrecord.m_strAREANAME;
                        m_objViewer.m_txtBalance.Text = decBalance.ToString("0.00");
                        m_objViewer.m_txtBedCode.Text = p_objRrecord.m_strCODE_CHR;
                        m_objViewer.m_txtStatus.Text = p_objRrecord.m_strSTATUS;
                        m_objViewer.m_txtPstatus.Text = p_objRrecord.m_strPSTATUS;
                        m_objViewer.m_txtUnclearCharge.Text = decUnclearCharge.ToString("0.00");
                        m_objViewer.m_txtDese.Text = p_objRrecord.m_strICD10DIAGTEXT_VCHR;
                        m_objViewer.m_txtInHospitalTime.Text = p_objRrecord.m_strINPATIENT_DAT;
                        m_objViewer.m_txtInTime.Text = p_objRrecord.m_strINPATIENTCOUNT_INT;
                        // 2008-01-29
                        m_objViewer.m_txtBedNo2.Text = p_objRrecord.m_strCODE_CHR;
                        if (p_objRrecord.m_strINPATIENTNOTYPE_INT == "2")
                        {
                            m_objViewer.m_txtInType.Text = "留观";
                        }
                        else
                        {
                            m_objViewer.m_txtInType.Text = "正式";
                        }


                        m_objViewer.m_cmbBabyOrder.SelectedIndex = -1;
                        m_objViewer.m_cmBabySex.SelectedIndex = -1;
                        if (m_objViewer.intEditMode == 0)
                        {
                            m_objViewer.m_txtBabyName.Text = p_objRrecord.m_strNAME_VCHR + "B";
                        }
                        else
                        {
                            m_objViewer.m_txtBabyName.Text = string.Empty;
                            m_objViewer.m_txtBabyName.Tag = null;
                        }
                        if (m_objViewer.m_cmdBabyPayType.Items.Count > 0)
                        {
                            this.m_objViewer.m_cmdBabyPayType.SelectedIndex = 0;
                        }

                        if (m_objViewer.intEditMode == 0)
                        {
                            m_objViewer.m_cmbBabyOrder.Focus();
                            m_objViewer.m_cmbBabyOrder.SelectedIndex = 0;
                        }
                        else if (m_objViewer.intEditMode == 2)
                        {

                            //获取婴儿胎次
                            int intBornNum = 1;
                            ArrayList arrBornNum = new ArrayList();
                            //lngRes = m_objManage.m_lngGetBabyBornNumByID(((clsBIHBed)m_objViewer.m_txtBedNo2.Tag).m_objPatient.m_strRegisterID, ref intBornNum);
                            lngRes = m_objManage.m_lngGetBabyBornNumByID(p_objRrecord.m_strREGISTERID_CHR, ref arrBornNum);
                            if (lngRes > 0)
                            {
                                m_objViewer.m_cmbBabyOrder.Items.Clear();
                                //for (int i1 = 1; i1 <= intBornNum; i1++)
                                //{
                                //    m_objViewer.m_cmbBabyOrder.Items.Add(i1.ToString());
                                //}

                                foreach (Object obj in arrBornNum)
                                {
                                    m_objViewer.m_cmbBabyOrder.Items.Add(obj.ToString());
                                }
                                if (arrBornNum.Count > 0)
                                {
                                    m_objViewer.m_cmbBabyOrder.SelectedIndex = 0;
                                }
                                else
                                {
                                    m_objViewer.m_cmbBabyOrder.SelectedIndex = -1;
                                }

                                if (arrBornNum.Count > 0)
                                {
                                    //获取婴儿入院登记信息
                                    DataTable dtbBabyInfo = null;
                                    lngRes = m_objManage.m_lngGetBabyRegisterInfoByID(p_objRrecord.m_strREGISTERID_CHR, Convert.ToInt32(m_objViewer.m_cmbBabyOrder.Text), out dtbBabyInfo);
                                    if (lngRes > 0 && dtbBabyInfo.Rows.Count > 0)
                                    {
                                        m_objBabyRegisterInfoArr = new clsT_Opr_Bih_Register_VO[dtbBabyInfo.Rows.Count];
                                        m_objPatientInfoArr = new clsPatient_VO[dtbBabyInfo.Rows.Count];
                                        for (int i1 = 0; i1 < dtbBabyInfo.Rows.Count; i1++)
                                        {
                                            m_objBabyRegisterInfoArr[i1] = new clsT_Opr_Bih_Register_VO();
                                            m_objPatientInfoArr[i1] = new clsPatient_VO();
                                            m_objBabyRegisterInfoArr[i1].m_strREGISTERID_CHR = dtbBabyInfo.Rows[i1]["registerid_chr"].ToString().Trim();
                                            m_objBabyRegisterInfoArr[i1].m_strPAYTYPEID_CHR = dtbBabyInfo.Rows[i1]["paytypeid_chr"].ToString().Trim();
                                            m_objPatientInfoArr[i1].m_strSEX_CHR = dtbBabyInfo.Rows[i1]["sex_chr"].ToString().Trim();
                                            m_objPatientInfoArr[i1].m_strLASTNAME_VCHR = dtbBabyInfo.Rows[i1]["lastname_vchr"].ToString().Trim();
                                            m_objPatientInfoArr[i1].m_strBIRTH_DAT = dtbBabyInfo.Rows[i1]["birth_dat"].ToString().Trim();
                                            m_objPatientInfoArr[i1].m_strLASTNAME_VCHR = dtbBabyInfo.Rows[i1]["lastname_vchr"].ToString().Trim();

                                            m_objBabyRegisterInfoArr[i1].m_intIsShunchan = Convert.ToInt32(dtbBabyInfo.Rows[i1]["isshunchan"].ToString().Trim());//顺产标志 add by zxm

                                        }
                                        m_objViewer.m_txtBabyName.Text = m_objPatientInfoArr[0].m_strLASTNAME_VCHR;
                                        m_objViewer.m_txtBabyName.Tag = m_objBabyRegisterInfoArr[0].m_strREGISTERID_CHR;
                                        m_objViewer.m_datBabyBrithday.Value = Convert.ToDateTime(m_objPatientInfoArr[0].m_strBIRTH_DAT);

                                        m_objViewer.chk_isSC.Checked = (m_objBabyRegisterInfoArr[0].m_intIsShunchan == 1) ? true : false;//顺产标志 add by zxm

                                        //性别
                                        for (int i1 = 0; i1 < m_objViewer.m_cmBabySex.Items.Count; i1++)
                                        {
                                            if (m_objViewer.m_cmBabySex.Items[i1].ToString().Equals(m_objPatientInfoArr[0].m_strSEX_CHR))
                                            {
                                                m_objViewer.m_cmBabySex.SelectedIndex = i1;
                                                break;
                                            }

                                        }//for

                                        //病人身份
                                        for (int i1 = 0; i1 < m_objViewer.m_cmdBabyPayType.Items.Count; i1++)
                                        {
                                            if (p_objRecordArr[i1].m_strPayTypeID.Equals(m_objBabyRegisterInfoArr[0].m_strPAYTYPEID_CHR))
                                            //if (m_objViewer.m_cmdBabyPayType.ValueMember[i1].ToString().Equals(m_objBabyRegisterInfoArr[0].m_strPAYTYPEID_CHR) )
                                            {
                                                m_objViewer.m_cmdBabyPayType.SelectedIndex = i1;
                                                break;
                                            }

                                        }//for
                                    }//if
                                }

                            }//
                            m_objViewer.m_cmbBabyOrder.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("对不起,找不到该病人信息信息！", "查找病人", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "查找病人失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region 病区事件
        public void m_txtAreaInitListView(System.Windows.Forms.ListView lvwList)
        {
            lvwList.Columns.Add("病区编号", 50, HorizontalAlignment.Left);
            lvwList.Columns.Add("病区名称", 130, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 200;
        }
        public void m_txtAreaFindItem(string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            clsBIHArea[] objItemArr;
            long lngRes = m_objManage.m_lngFindArea(strFindCode, out objItemArr);
            if (lngRes > 0 && objItemArr != null && objItemArr.Length > 0)
            {
                //获取有权限访问的病区ID集合
                if (m_objViewer.LoginInfo != null)
                {
                    IList ilUsableAreaID = m_objViewer.LoginInfo.m_ilUsableAreaID;
                    //m_objManage objInputOrder = new clsDcl_InputOrder();
                    objItemArr = (clsBIHArea[])(GetUsableAreaObject(objItemArr, ilUsableAreaID)).ToArray(typeof(clsBIHArea));
                }
                for (int i = 0; i < objItemArr.Length; i++)
                {
                    /** @update by xzf (05-09-20) 
                     * 
                     */
                    //@ListViewItem lvi=lvwList.Items.Add(objItemArr[i].m_strAreaID);
                    ListViewItem lvi = lvwList.Items.Add(objItemArr[i].code);
                    lvi.SubItems.Add(objItemArr[i].m_strAreaName);
                    lvi.Tag = objItemArr[i].m_strAreaID;
                    /* <<======================== */
                }
            }
        }
        public void m_txtAreaSelectItem(System.Windows.Forms.ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_objViewer.m_txtArea.Text = lviSelected.SubItems[1].Text;
                m_objViewer.strAreaName = lviSelected.SubItems[1].Text;
                m_objViewer.m_txtArea.Tag = lviSelected.Tag;
                //LoadTheDate();
                this.m_objViewer.m_txtBedNo2.Focus();
            }
        }


        #region 访问权限
        /// <summary>
        /// 过滤出有权限的病区
        /// </summary>
        /// <param name="p_objArea">病区对象</param>
        /// <param name="p_ilUsableAreaID">有权访问的病区ID集合</param>
        /// <returns>有权访问的病区对象集合</returns>
        public ArrayList GetUsableAreaObject(clsBIHArea[] p_objArea, System.Collections.IList p_ilUsableAreaID)
        {
            ArrayList ilRes = new ArrayList();
            if (p_objArea == null || p_objArea.Length <= 0) return ilRes;

            //全部的可访问的病区对象
            for (int i1 = 0; i1 < p_objArea.Length; i1++)
            {
                if (p_objArea[i1] == null) continue;
                if (p_ilUsableAreaID.Contains(p_objArea[i1].m_strAreaID.Trim()))
                {
                    if (!(ilRes.Contains(p_objArea[i1])))
                        ilRes.Add(p_objArea[i1]);
                }
            }
            return ilRes;
        }

        /// <summary>
        /// 过滤出有权限的住院号
        /// </summary>
        /// <param name="p_objItemArr">入院登记对象	[数组]</param>
        /// <param name="p_ilUsableAreaID">有权访问的病区ID集合</param>
        /// <returns>有权访问的入院登记对象集合</returns>
        public ArrayList GetUsableRegisterObject(clsT_Opr_Bih_Register_VO[] p_objItemArr, IList p_ilUsableAreaID)
        {
            ArrayList ilRes = new ArrayList();
            if (p_objItemArr == null || p_objItemArr.Length <= 0) return ilRes;

            //全部的可访问的病区对象
            for (int i1 = 0; i1 < p_objItemArr.Length; i1++)
            {
                if (p_objItemArr[i1] == null) continue;
                if (p_ilUsableAreaID.Contains(p_objItemArr[i1].m_strAREAID_CHR.Trim()))
                {
                    if (!(ilRes.Contains(p_objItemArr[i1])))
                        ilRes.Add(p_objItemArr[i1]);
                }
            }
            return ilRes;
        }
        #endregion

        #endregion

        #region 床位号事件
        internal void m_txtBedNo2FindItem(string strFindCode, ListView lvwList)
        {

            this.m_objViewer.m_txtBedNo2.Tag = null;

            com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService m_objService =
                (com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.BIHOrderServer.clsBIHOrderService));

            if (this.m_objViewer.m_txtArea.Tag == null)
            {
                //if (m_blnPrompt) MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtArea.Text = "";
                this.m_objViewer.m_txtArea.Tag = null;
                this.m_objViewer.m_txtArea.Focus();
                return;
            }
            string strAreaID = (string)this.m_objViewer.m_txtArea.Tag;
            clsBIHBed[] arrBed;
            string strBedNo = this.m_objViewer.m_txtBedNo2.Text.Trim();
            long ret = m_objService.m_lngGetBedByArea(strAreaID, strBedNo, out arrBed);
            if ((ret > 0) && (arrBed != null))
            {
                if (arrBed.Length == 0)
                {
                    MessageBox.Show("当前科室没有床位，请重新选病区", "提示框！", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.m_objViewer.m_txtBedNo2.Focus();
                    return;
                }
                string upName = "";
                for (int i = 0; i < arrBed.Length; i++)
                {
                    //为床号列表加上姓名及姓别 add by wjqin(06-06-21)
                    // ListViewItem objItem = m_lvwBed.Items.Add(arrBed[i].m_strBedName);
                    /*------------------------------------>*/
                    //if (i > 0)
                    //{
                    //    upName = arrBed[i - 1].m_objPatient.m_strAreaName;
                    //}
                    //if (arrBed[i].m_objPatient.m_strAreaName.Trim().Equals(upName.Trim()))
                    //{
                    //    upName = "";
                    //}
                    //else
                    //{
                    //    upName = arrBed[i].m_objPatient.m_strAreaName;
                    //}

                    ListViewItem objItem = new ListViewItem(arrBed[i].m_strBedName);

                    //objItem.SubItems.Add(arrBed[i].m_strBedName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strPatientName);
                    objItem.SubItems.Add(arrBed[i].m_objPatient.m_strSex);
                    /*<----------------------*/
                    //objItem.Tag = arrBed[i].m_strBedID;
                    objItem.Tag = arrBed[i];
                    lvwList.Items.Add(objItem);

                }

            }
        }

        internal void m_txtBedNo2InitListView(ListView lvwList)
        {
            //lvwList.Columns.Add("病  区", 100, HorizontalAlignment.Left);
            lvwList.Columns.Add("床　号", 40, HorizontalAlignment.Left);
            lvwList.Columns.Add("姓　名", 80, HorizontalAlignment.Left);
            lvwList.Columns.Add("性　别", 40, HorizontalAlignment.Left);
            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 270;
            /* <<================================= */
        }

        internal void m_txtBedNo2SelectItem(ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                this.m_objViewer.m_txtBedNo2.Text = lviSelected.SubItems[0].Text;
                this.m_objViewer.m_txtBedNo2.Tag = lviSelected.Tag;
                refreshTheData();
                this.m_objBabyRegisterInfoArr = null;
            }
        }

        internal void m_txtBabyNameInitListView(ListView lvwList)
        {
            lvwList.Columns.Add("姓　名", 80, HorizontalAlignment.Left);
            lvwList.Columns.Add("性　别", 40, HorizontalAlignment.Left);
            //lvwList.Columns.Add("登记号", 40, HorizontalAlignment.Left);

            lvwList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            lvwList.Width = 270;
            /* <<================================= */
        }

        internal void m_txtBabyNameFindItem(string strFindCode, ListView lvwList)
        {
            this.m_objViewer.m_txtBabyName.Tag = null;

            //if (this.m_objViewer.m_txtArea.Tag == null)
            //{
            //    //if (m_blnPrompt) MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    MessageBox.Show("请先指定病区!", "提示框!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    this.m_objViewer.m_txtArea.Text = "";
            //    this.m_objViewer.m_txtArea.Tag = null;
            //    this.m_objViewer.m_txtArea.Focus();
            //    return;
            //}

            //获取婴儿入院登记信息
            m_mthGetBabyInfo();

            if ((m_objPatientInfoArr != null) && (m_objPatientInfoArr.Length > 0) && (m_objBabyRegisterInfoArr.Length > 0))
            {
                for (int i = 0; i < m_objPatientInfoArr.Length; i++)
                {

                    ListViewItem objItem = new ListViewItem(m_objPatientInfoArr[i].m_strLASTNAME_VCHR);

                    //objItem.SubItems.Add(arrBed[i].m_strBedName);
                    objItem.SubItems.Add(m_objPatientInfoArr[i].m_strLASTNAME_VCHR);
                    objItem.SubItems.Add(m_objPatientInfoArr[i].m_strSEX_CHR);

                    objItem.Tag = m_objBabyRegisterInfoArr[i].m_strREGISTERID_CHR;
                    lvwList.Items.Add(objItem);

                }//for
            }
        }

        /// <summary>
        /// 获取婴儿入院登记信息
        /// </summary>
        internal void m_mthGetBabyInfo()
        {
            DataTable dtbBabyInfo = null;

            if (p_objRrecord == null)
            {
                return;
            }

            long lngRes = m_objManage.m_lngGetBabyRegisterInfoByID(p_objRrecord.m_strREGISTERID_CHR, Convert.ToInt32(m_objViewer.m_cmbBabyOrder.Text), out dtbBabyInfo);
            if (lngRes > 0 && dtbBabyInfo.Rows.Count > 0)
            {
                m_objBabyRegisterInfoArr = new clsT_Opr_Bih_Register_VO[dtbBabyInfo.Rows.Count];
                m_objPatientInfoArr = new clsPatient_VO[dtbBabyInfo.Rows.Count];
                for (int i1 = 0; i1 < dtbBabyInfo.Rows.Count; i1++)
                {
                    m_objBabyRegisterInfoArr[i1] = new clsT_Opr_Bih_Register_VO();
                    m_objPatientInfoArr[i1] = new clsPatient_VO();
                    m_objBabyRegisterInfoArr[i1].m_strREGISTERID_CHR = dtbBabyInfo.Rows[i1]["registerid_chr"].ToString().Trim();
                    m_objBabyRegisterInfoArr[i1].m_strPAYTYPEID_CHR = dtbBabyInfo.Rows[i1]["paytypeid_chr"].ToString().Trim();
                    m_objPatientInfoArr[i1].m_strSEX_CHR = dtbBabyInfo.Rows[i1]["sex_chr"].ToString().Trim();
                    m_objPatientInfoArr[i1].m_strLASTNAME_VCHR = dtbBabyInfo.Rows[i1]["lastname_vchr"].ToString().Trim();
                    m_objPatientInfoArr[i1].m_strBIRTH_DAT = dtbBabyInfo.Rows[i1]["birth_dat"].ToString().Trim();
                    m_objPatientInfoArr[i1].m_strLASTNAME_VCHR = dtbBabyInfo.Rows[i1]["lastname_vchr"].ToString().Trim();

                    m_objBabyRegisterInfoArr[i1].m_intIsShunchan = Convert.ToInt32(dtbBabyInfo.Rows[i1]["isshunchan"].ToString().Trim());//顺产标志 add by zxm

                }

            }


        }

        internal void m_mthSetBabyInfo(int p_intIndex)
        {
            if (m_objPatientInfoArr != null)
            {
                if ((m_objPatientInfoArr.Length > 0) && (m_objBabyRegisterInfoArr.Length > 0) && (m_objPatientInfoArr.Length <= p_intIndex + 1))
                {

                    this.m_objViewer.m_txtBabyName.Text = m_objPatientInfoArr[p_intIndex].m_strLASTNAME_VCHR;
                    //this.m_objViewer.m_txtBabyName.Text = lviSelected.SubItems[0].Text;
                    this.m_objViewer.m_txtBabyName.Tag = m_objBabyRegisterInfoArr[p_intIndex].m_strREGISTERID_CHR;
                    m_objViewer.m_datBabyBrithday.Value = Convert.ToDateTime(m_objPatientInfoArr[p_intIndex].m_strBIRTH_DAT);

                    m_objViewer.chk_isSC.Checked = (m_objBabyRegisterInfoArr[p_intIndex].m_intIsShunchan == 1) ? true : false;//顺产标志 add by zxm

                    //性别
                    for (int i1 = 0; i1 < m_objViewer.m_cmBabySex.Items.Count; i1++)
                    {
                        this.m_objViewer.m_cmBabySex.SelectedIndex = -1;
                        if (m_objViewer.m_cmBabySex.Items[i1].ToString().Equals(m_objPatientInfoArr[p_intIndex].m_strSEX_CHR))
                        {
                            m_objViewer.m_cmBabySex.SelectedIndex = i1;
                            break;
                        }

                    }//for

                    //病人身份
                    for (int i1 = 0; i1 < m_objViewer.m_cmdBabyPayType.Items.Count; i1++)
                    {
                        this.m_objViewer.m_cmdBabyPayType.SelectedIndex = -1;
                        if (p_objRecordArr[i1].m_strPayTypeID.Equals(m_objBabyRegisterInfoArr[p_intIndex].m_strPAYTYPEID_CHR))
                        {
                            m_objViewer.m_cmdBabyPayType.SelectedIndex = i1;
                            break;
                        }

                    }//for
                }
            }
            else
            {
                this.m_objViewer.m_txtBabyName.Text = "";
                this.m_objViewer.m_txtBabyName.Tag = null;
                m_objViewer.m_datBabyBrithday.Value = DateTime.Now;
                m_objViewer.m_cmBabySex.SelectedIndex = -1;
                m_objViewer.m_cmdBabyPayType.SelectedIndex = -1;

                m_objViewer.chk_isSC.Checked = false;//顺产标志 add by zxm

            }
        }

        internal void m_txtBabyNameSelectItem(ListViewItem lviSelected)
        {
            if (lviSelected != null)
            {
                m_mthSetBabyInfo(lviSelected.Index);

            }
        }

        private void refreshTheData()
        {
            p_objRrecord = null;
            decBalance = 0;
            decUnclearCharge = 0;
            try
            {
                long lngRes = m_objManage.m_lngGetBIHPatientInfoAndCharge(((clsBIHBed)m_objViewer.m_txtBedNo2.Tag).m_objPatient.m_strRegisterID, out p_objRrecord);
                if (lngRes > 0 && p_objRrecord != null)
                {
                    if (p_objRrecord.m_strSEX_CHR != "女")
                    {
                        MessageBox.Show("应选择女性！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //frm = null;
                        //m_mthGetBIHPatientInfo();
                        this.m_objViewer.m_txtBedNo2.Focus();
                        return;
                    }

                    if (p_objRrecord.m_strINPATIENTID_CHR.EndsWith("B") == true)
                    {
                        MessageBox.Show("应选择婴儿的母亲！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //frm = null;
                        //m_mthGetBIHPatientInfo();
                        this.m_objViewer.m_txtBedNo2.Focus();
                        return;
                    }

                    if (p_objRrecord.m_strPSTATUS_INT == "3" && p_objRrecord.m_strSTATUS_INT != "1")
                    {
                        MessageBox.Show("只能对在院病人对婴儿登记！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //frm = null;
                        //m_mthGetBIHPatientInfo();
                        return;
                    }


                    //frm = null;
                    if (p_objRrecord.m_strUnclearCharge != "" && p_objRrecord.m_strUnclearCharge == null)
                    {
                        decUnclearCharge = Convert.ToDecimal(p_objRrecord.m_strUnclearCharge);
                    }
                    if (p_objRrecord.m_strBalance != "" && p_objRrecord.m_strBalance == null)
                    {
                        decBalance = Convert.ToDecimal(p_objRrecord.m_strBalance);
                    }
                    m_objViewer.m_txtName.Text = p_objRrecord.m_strNAME_VCHR;

                    m_objViewer.m_txtInHospitalID.Text = p_objRrecord.m_strINPATIENTID_CHR;
                    m_objViewer.m_txtSex.Text = p_objRrecord.m_strSEX_CHR;
                    m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(p_objRrecord.m_strBIRTH_DAT);
                    m_objViewer.m_txtArear.Text = p_objRrecord.m_strAREANAME;
                    decimal.TryParse(p_objRrecord.m_strBalance, out decBalance);
                    m_objViewer.m_txtBalance.Text = decBalance.ToString("0.00");
                    m_objViewer.m_txtBedCode.Text = p_objRrecord.m_strCODE_CHR;
                    m_objViewer.m_txtStatus.Text = p_objRrecord.m_strSTATUS;
                    m_objViewer.m_txtPstatus.Text = p_objRrecord.m_strPSTATUS;
                    decimal.TryParse(p_objRrecord.m_strUnclearCharge, out decUnclearCharge);
                    m_objViewer.m_txtUnclearCharge.Text = decUnclearCharge.ToString("0.00");
                    m_objViewer.m_txtDese.Text = p_objRrecord.m_strICD10DIAGTEXT_VCHR;
                    m_objViewer.m_txtInHospitalTime.Text = p_objRrecord.m_strINPATIENT_DAT;
                    m_objViewer.m_txtInTime.Text = p_objRrecord.m_strINPATIENTCOUNT_INT;
                    if (p_objRrecord.m_strINPATIENTNOTYPE_INT == "2")
                    {
                        m_objViewer.m_txtInType.Text = "留观";
                    }
                    else
                    {
                        m_objViewer.m_txtInType.Text = "正式";
                    }

                    m_objViewer.m_cmBabySex.SelectedIndex = 0;
                    if (m_objViewer.intEditMode == 0)
                    {
                        m_objViewer.m_cmbBabyOrder.SelectedIndex = 0;
                        m_objViewer.m_txtBabyName.Text = p_objRrecord.m_strNAME_VCHR + "B";
                    }
                    else
                    {
                        m_objViewer.m_txtBabyName.Text = string.Empty;
                        m_objViewer.m_txtBabyName.Tag = null;
                    }
                    if (m_objViewer.m_cmdBabyPayType.Items.Count > 0)
                    {
                        this.m_objViewer.m_cmdBabyPayType.SelectedIndex = 0;
                    }

                    if (m_objViewer.intEditMode == 0)
                    {
                        m_objViewer.m_cmbBabyOrder.Focus();
                    }
                    else if (m_objViewer.intEditMode == 2)
                    {

                        //获取婴儿胎次
                        int intBornNum = 1;
                        ArrayList arrBronNum = new ArrayList();
                        //lngRes = m_objManage.m_lngGetBabyBornNumByID(((clsBIHBed)m_objViewer.m_txtBedNo2.Tag).m_objPatient.m_strRegisterID, ref intBornNum);
                        lngRes = m_objManage.m_lngGetBabyBornNumByID(((clsBIHBed)m_objViewer.m_txtBedNo2.Tag).m_objPatient.m_strRegisterID, ref arrBronNum);
                        if (lngRes > 0)
                        {
                            m_objViewer.m_cmbBabyOrder.Items.Clear();
                            //for (int i1 = 1; i1 <= intBornNum; i1++)
                            //{
                            //    m_objViewer.m_cmbBabyOrder.Items.Add(i1.ToString());
                            //}
                            //if (intBornNum > 0)
                            //{
                            //    m_objViewer.m_cmbBabyOrder.SelectedIndex = 0;
                            //}

                            foreach (Object obj in arrBronNum)
                            {
                                m_objViewer.m_cmbBabyOrder.Items.Add(obj.ToString());
                            }

                            if (arrBronNum.Count > 0)
                            {
                                m_objViewer.m_cmbBabyOrder.SelectedIndex = 0;
                            }
                            else
                            {
                                MessageBox.Show("没有婴儿资料！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                m_objViewer.m_txtBedNo2.Focus();
                                return;
                            }
                            //获取婴儿入院登记信息
                            DataTable dtbBabyInfo = null;
                            lngRes = m_objManage.m_lngGetBabyRegisterInfoByID(p_objRrecord.m_strREGISTERID_CHR, Convert.ToInt32(m_objViewer.m_cmbBabyOrder.Text), out dtbBabyInfo);
                            if (lngRes > 0 && dtbBabyInfo.Rows.Count > 0)
                            {
                                m_objBabyRegisterInfoArr = new clsT_Opr_Bih_Register_VO[dtbBabyInfo.Rows.Count];
                                m_objPatientInfoArr = new clsPatient_VO[dtbBabyInfo.Rows.Count];
                                for (int i1 = 0; i1 < dtbBabyInfo.Rows.Count; i1++)
                                {
                                    m_objBabyRegisterInfoArr[i1] = new clsT_Opr_Bih_Register_VO();
                                    m_objPatientInfoArr[i1] = new clsPatient_VO();
                                    m_objBabyRegisterInfoArr[i1].m_strREGISTERID_CHR = dtbBabyInfo.Rows[i1]["registerid_chr"].ToString().Trim();
                                    m_objBabyRegisterInfoArr[i1].m_strPAYTYPEID_CHR = dtbBabyInfo.Rows[i1]["paytypeid_chr"].ToString().Trim();
                                    m_objPatientInfoArr[i1].m_strSEX_CHR = dtbBabyInfo.Rows[i1]["sex_chr"].ToString().Trim();
                                    m_objPatientInfoArr[i1].m_strLASTNAME_VCHR = dtbBabyInfo.Rows[i1]["lastname_vchr"].ToString().Trim();
                                    m_objPatientInfoArr[i1].m_strBIRTH_DAT = dtbBabyInfo.Rows[i1]["birth_dat"].ToString().Trim();
                                    m_objPatientInfoArr[i1].m_strLASTNAME_VCHR = dtbBabyInfo.Rows[i1]["lastname_vchr"].ToString().Trim();

                                    m_objBabyRegisterInfoArr[i1].m_intIsShunchan = Convert.ToInt32(dtbBabyInfo.Rows[i1]["isshunchan"].ToString().Trim());//顺产标志 add by zxm

                                }
                                m_objViewer.m_txtBabyName.Text = m_objPatientInfoArr[0].m_strLASTNAME_VCHR;
                                m_objViewer.m_txtBabyName.Tag = m_objBabyRegisterInfoArr[0].m_strREGISTERID_CHR;
                                m_objViewer.m_datBabyBrithday.Value = Convert.ToDateTime(m_objPatientInfoArr[0].m_strBIRTH_DAT);

                                m_objViewer.chk_isSC.Checked = (m_objBabyRegisterInfoArr[0].m_intIsShunchan == 1) ? true : false;//顺产标志 add by zxm
                                //性别
                                for (int i1 = 0; i1 < m_objViewer.m_cmBabySex.Items.Count; i1++)
                                {
                                    if (m_objViewer.m_cmBabySex.Items[i1].ToString().Equals(m_objPatientInfoArr[0].m_strSEX_CHR))
                                    {
                                        m_objViewer.m_cmBabySex.SelectedIndex = i1;
                                        break;
                                    }

                                }//for

                                //病人身份
                                for (int i1 = 0; i1 < m_objViewer.m_cmdBabyPayType.Items.Count; i1++)
                                {
                                    if (p_objRecordArr[i1].m_strPayTypeID.Equals(m_objBabyRegisterInfoArr[0].m_strPAYTYPEID_CHR))
                                    //if (m_objViewer.m_cmdBabyPayType.ValueMember[i1].ToString().Equals(m_objBabyRegisterInfoArr[0].m_strPAYTYPEID_CHR) )
                                    {
                                        m_objViewer.m_cmdBabyPayType.SelectedIndex = i1;
                                        break;
                                    }

                                }//for
                            }//if

                        }//
                        m_objViewer.m_cmbBabyOrder.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("对不起,找不到该病人信息！", "查找病人", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "查找病人失败！", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// 获取婴儿数据
        /// </summary>
        private void m_mthGetBabyData()
        {
            //this.m_objViewer.m_txtBabyName.Text = lviSelected.SubItems[0].Text;
            //this.m_objViewer.m_txtBabyName.Tag = lviSelected.Tag;
            //m_objViewer.m_datBabyBrithday.Value = Convert.ToDateTime(m_objPatientInfoArr[lviSelected.Index].m_strBIRTH_DAT);

            ////性别
            //for (int i1 = 0; i1 < m_objViewer.m_cmBabySex.Items.Count; i1++)
            //{
            //    if (m_objViewer.m_cmBabySex.Items[i1].ToString().Equals(lviSelected.SubItems[2].Text.Trim()))
            //    {
            //        m_objViewer.m_cmBabySex.SelectedIndex = i1;
            //        break;
            //    }

            //}//for

            ////病人身份
            //for (int i1 = 0; i1 < m_objViewer.m_cmdBabyPayType.Items.Count; i1++)
            //{
            //    if (m_objViewer.m_cmdBabyPayType.Items[i1].ToString().Equals(
            //        m_objBabyRegisterInfoArr[lviSelected.Index].m_strPAYTYPEID_CHR.ToString()))
            //    {
            //        m_objViewer.m_cmdBabyPayType.SelectedIndex = i1;
            //        break;
            //    }

            //}

        }
        #endregion
    }
}
