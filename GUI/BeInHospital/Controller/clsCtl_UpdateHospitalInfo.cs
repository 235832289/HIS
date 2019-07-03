using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;
using System.Collections;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 修改住院信息 - 逻辑控制
    /// </summary>
    class clsCtl_UpdateHospitalInfo : com.digitalwave.GUI_Base.clsController_Base
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

        private frmCommonFind m_commonFind = new frmCommonFind();

        #endregion

        #region 构造函数
        public clsCtl_UpdateHospitalInfo()
        {
            m_objManage = new clsDcl_BIHTransfer();
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmUpdateHospitalInfo m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmUpdateHospitalInfo)frmMDI_Child_Base_in;
        }
        #endregion

        #region 根据入院登记ID获取病人住院信息
        /// <summary>
        /// 根据入院登记ID获取病人住院信息
        /// </summary>
        /// <param name="p_strRegisterID">入院登记ID</param>
        public void m_mthGetBIHPatientInfo(string p_strRegisterID)
        {
            p_objRrecord = null;
            decBalance = 0;
            decUnclearCharge = 0;
            long lngRes = m_objManage.m_lngGetBIHPatientInfoAndCharge(p_strRegisterID, out p_objRrecord);
            if (lngRes > 0 && p_objRrecord != null)
            {
                if (p_objRrecord.m_strUnclearCharge != "" && p_objRrecord.m_strUnclearCharge == null)
                {
                    decUnclearCharge = Convert.ToDecimal(p_objRrecord.m_strUnclearCharge);
                }
                if (p_objRrecord.m_strBalance != "" && p_objRrecord.m_strBalance == null)
                {
                    decBalance = Convert.ToDecimal(p_objRrecord.m_strBalance);
                }

                //this.m_objViewer.cmdCancle.Enabled = true;
                //m_objViewer.m_txtName.Text = p_objRrecord.m_strNAME_VCHR;
                //m_objViewer.m_txtInHospitalID.Text = p_objRrecord.m_strINPATIENTID_CHR;
                //m_objViewer.m_txtSex.Text = p_objRrecord.m_strSEX_CHR;
                //m_objViewer.m_txtAge.Text = new clsBrithdayToAge().m_strGetAge(p_objRrecord.m_strBIRTH_DAT);
                //m_objViewer.m_txtArear.Text = p_objRrecord.m_strAREANAME;
                //m_objViewer.m_txtBalance.Text = decBalance.ToString("0.00");
                //m_objViewer.m_txtBedCode.Text = p_objRrecord.m_strCODE_CHR;
                //m_objViewer.m_txtStatus.Text = p_objRrecord.m_strSTATUS;
                //m_objViewer.m_txtPstatus.Text = p_objRrecord.m_strPSTATUS;
                //m_objViewer.m_txtUnclearCharge.Text = decUnclearCharge.ToString("0.00");
                //m_objViewer.m_txtDese.Text = p_objRrecord.m_strICD10DIAGTEXT_VCHR;
                //m_objViewer.m_txtInHospitalTime.Text = p_objRrecord.m_strINPATIENT_DAT;
                //m_objViewer.m_txtInTime.Text = p_objRrecord.m_strINPATIENTCOUNT_INT;
                //if (p_objRrecord.m_strINPATIENTNOTYPE_INT == "2")
                //{
                //    m_objViewer.m_txtInType.Text = "留观";
                //}
                //else
                //{
                //    m_objViewer.m_txtInType.Text = "正式";
                //}
            }
            else
            {
                MessageBox.Show("对不起,找不到该病人信息！", "查找病人", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion

        #region 撤消入院
        /// <summary>
        /// 撤消入院
        /// </summary>
        public void m_mthCancleInHospital()
        {
            if (this.m_objViewer.m_ucPatientInfo.RegisterID == "")
            {
                MessageBox.Show("请输入病人信息！", "撤消入院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Status.ToString().Trim() == "3")
            {
                MessageBox.Show("该病人已经出院！", "撤消入院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.m_objViewer.m_ucPatientInfo.Status == -1)
            {
                MessageBox.Show("该病人已经撤消入院！", "撤消入院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //bool hasNotExcOrder;
            clsDclBihLeaHos leaHosDomain = new clsDclBihLeaHos();
            //检查是否存在尚为执行的临嘱
            int count;

            long l = leaHosDomain.m_lngGetNotStopOrderByRegID(this.m_objViewer.m_ucPatientInfo.RegisterID, out count);

            if (count > 0)
            {
                if (MessageBox.Show(m_objViewer, "该病人有新开的医嘱，是否继续撤消入院操作？", "提示框", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }
            }     

            if (this.m_objViewer.m_ucPatientInfo.BihPatient_VO.WaitChargeFee > 0 || this.m_objViewer.m_ucPatientInfo.BihPatient_VO.WaitClearFee > 0)
            {
                MessageBox.Show("有费用未清,不能撤消入院操作！", "撤消入院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.m_objViewer.m_ucPatientInfo.BalancePrepayMoney > 0)
            {
                MessageBox.Show("有预交金未清,不能作撤消入院操作！", "撤消入院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (MessageBox.Show("确认撤消入院么?", "撤消入院", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                p_objRrecord = new clsBIHpatientVO();
                p_objRrecord.m_strREGISTERID_CHR = this.m_objViewer.m_ucPatientInfo.RegisterID;
                p_objRrecord.m_strINPATIENTID_CHR = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Zyh;
                p_objRrecord.m_strPSTATUS = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Status.ToString().Trim();
                p_objRrecord.m_strRemark = m_objViewer.m_txtRemark.Text.Trim();
                //p_objRrecord.m_strINPATIENTCOUNT_INT = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.InsuredZycs.ToString();
                p_objRrecord.m_strINPATIENTCOUNT_INT = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Zycs.ToString();//住院次数 
                p_objRrecord.m_strPATIENTID_CHR = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.PatientID;
                p_objRrecord.m_strINPATIENTNOTYPE_INT = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.InType;
                try
                {
                    p_objRrecord.m_strOpearID = m_objViewer.LoginInfo.m_strEmpID;
                    if (p_objRrecord.m_strOpearID == "" || p_objRrecord.m_strOpearID == null)
                    {
                        p_objRrecord.m_strOpearID = "0000001";
                    }
                    long lngRes = m_objManage.m_lngCancleBeInHospital(p_objRrecord);
                    if (lngRes > 0)
                    {
                        MessageBox.Show("撤消入院成功！", "撤消入院", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.m_objViewer.m_ucPatientInfo.m_mthReset();
                        //this.m_objViewer.cmdCancle.Enabled = false;
                        m_mthClearControl();
                        decBalance = 0;
                        decUnclearCharge = 0;
                        p_objRrecord = null;
                    }
                    else
                    {
                        MessageBox.Show("撤消入院失败！", "撤消入院", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "撤消入院", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
            }
        }
        #endregion

        #region 清空控件文本
        /// <summary>
        /// 清空控件文本
        /// </summary>
        private void m_mthClearControl()
        {
            foreach (object obj in m_objViewer.Controls)
            {
                if (obj is TextBox)
                {
                    ((TextBox)obj).Text = "";
                }
            }
        }
        #endregion

        #region 普通号->留观号
        /// <summary>
        /// 普通号->留观号
        /// </summary>
        internal void m_mthChangePatientIDOth()
        {
            int k=0;
            int status_int = -1; 
            try
            {
                k=int.Parse(p_objRrecord.m_strINPATIENTNOTYPE_INT);
                status_int = int.Parse(p_objRrecord.m_strSTATUS_INT);
            }
            catch
            {
                return;
            }
            if (k == 0||k==2)
            {
                MessageBox.Show(m_objViewer, "当前病人不是普通住院号！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status_int == -1)
            {
                MessageBox.Show(m_objViewer, "当前病人住院号已被撤消！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int count=0;//入院次数
            try
            {
                count = int.Parse(p_objRrecord.m_strINPATIENTCOUNT_INT);
            }
            catch
            {
            }
            if (count!=1)
            {
                MessageBox.Show(m_objViewer, "首次入院的病人才可进行止操作！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //新增留观号
            CreateInpatientNo newNo = new CreateInpatientNo(2);
            if (newNo.ShowDialog() == DialogResult.OK)
            {
               //新住院号头标识
                string m_strhead = "";
                //新住院号
                string m_strInpatientid_chr = "";
                //1,新最大值来源于历史记录，2来源于最大值,0其它
                int m_intSour = 0;
                //新住院号主体数字部份
                string m_strMain = "";

                m_strInpatientid_chr= newNo.m_strGetInpatientid_chr(out m_strhead, out m_intSour);
                if (!m_strhead.Trim().Equals(""))
                {
                    m_strMain = m_strInpatientid_chr.Replace(m_strhead, "");
                }
                else
                {
                    m_strMain = m_strInpatientid_chr.Trim();
                }
                //string m_strRegisterid_chr,string oldInpatientid_chr, int inpatientnotype_int, string m_strHead, string m_strMain, int m_intSour
                long lngRes = m_objManage.m_lngChangePatientIDOth(p_objRrecord.m_strREGISTERID_CHR,p_objRrecord.m_strINPATIENTID_CHR,1,2,m_strhead,m_strMain,m_intSour);
                if (lngRes > 0)
                {
                    MessageBox.Show("操作成功！", "普通号-->留观号", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
                else
                {
                    MessageBox.Show("操作失败！", "普通号-->留观号", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 普通号->普通号
        /// <summary>
        /// 普通号->普通号
        /// </summary>
        internal void m_mthChangePatientIDOth2()
        {
            int k = 0;
            int status_int = -1;
            try
            {
                k = int.Parse(p_objRrecord.m_strINPATIENTNOTYPE_INT);
                status_int = int.Parse(p_objRrecord.m_strSTATUS_INT);
            }
            catch
            {
                return;
            }
            if (k == 0 || k == 2)
            {
                MessageBox.Show(m_objViewer, "当前病人不是普通住院号！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status_int == -1)
            {
                MessageBox.Show(m_objViewer, "当前病人住院号已被撤消！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //新增普通号
            CreateInpatientNo newNo = new CreateInpatientNo(1);
            if (newNo.ShowDialog() == DialogResult.OK)
            {
                //新住院号头标识
                string m_strhead = "";
                //新住院号
                string m_strInpatientid_chr = "";
                //1,新最大值来源于历史记录，2来源于最大值,0其它
                int m_intSour = 0;
                //新住院号主体数字部份
                string m_strMain = "";

                m_strInpatientid_chr = newNo.m_strGetInpatientid_chr(out m_strhead, out m_intSour);
                if (!m_strhead.Trim().Equals(""))
                {
                    m_strMain = m_strInpatientid_chr.Replace(m_strhead, "");
                }
                else
                {
                    m_strMain = m_strInpatientid_chr.Trim();
                }
                //string m_strRegisterid_chr,string oldInpatientid_chr, int inpatientnotype_int, string m_strHead, string m_strMain, int m_intSour
                long lngRes = m_objManage.m_lngChangePatientIDOth(p_objRrecord.m_strREGISTERID_CHR, p_objRrecord.m_strINPATIENTID_CHR,1, 1, m_strhead, m_strMain, m_intSour);
                if (lngRes > 0)
                {
                    MessageBox.Show("操作成功！", "普通号-->普通号", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
                else
                {
                    MessageBox.Show("操作失败！", "普通号-->普通号", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 留观号->普通号
        /// <summary>
        /// 留观号->普通号
        /// </summary>
        internal void m_mthChangePatientIDOth3()
        {
            int k = 0;
            int status_int = -1;
            try
            {
                k = int.Parse(p_objRrecord.m_strINPATIENTNOTYPE_INT);
                status_int = int.Parse(p_objRrecord.m_strSTATUS_INT);
            }
            catch
            {
                return;
            }
            if (k != 2)
            {
                MessageBox.Show(m_objViewer, "当前病人不是留观住院号！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status_int == -1)
            {
                MessageBox.Show(m_objViewer, "当前病人住院号已被撤消！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int count = 0;//入院次数
            try
            {
                count = int.Parse(p_objRrecord.m_strINPATIENTCOUNT_INT);
            }
            catch
            {
            }
            if (count != 1)
            {
                MessageBox.Show(m_objViewer, "首次入院的病人才可进行止操作！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //新增普通号
            CreateInpatientNo newNo = new CreateInpatientNo(1);
            if (newNo.ShowDialog() == DialogResult.OK)
            {
                //新住院号头标识
                string m_strhead = "";
                //新住院号
                string m_strInpatientid_chr = "";
                //1,新最大值来源于历史记录，2来源于最大值,0其它
                int m_intSour = 0;
                //新住院号主体数字部份
                string m_strMain = "";

                m_strInpatientid_chr = newNo.m_strGetInpatientid_chr(out m_strhead, out m_intSour);
                if (!m_strhead.Trim().Equals(""))
                {
                    m_strMain = m_strInpatientid_chr.Replace(m_strhead, "");
                }
                else
                {
                    m_strMain = m_strInpatientid_chr.Trim();
                }
                //string m_strRegisterid_chr,string oldInpatientid_chr, int inpatientnotype_int, string m_strHead, string m_strMain, int m_intSour
                long lngRes = m_objManage.m_lngChangePatientIDOth(p_objRrecord.m_strREGISTERID_CHR, p_objRrecord.m_strINPATIENTID_CHR, 2, 1, m_strhead, m_strMain, m_intSour);
                if (lngRes > 0)
                {
                    MessageBox.Show("操作成功！", "留观号->普通号", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
                else
                {
                    MessageBox.Show("操作失败！", "留观号->普通号", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 留观号-> 留观号
        /// <summary>
        /// 留观号-> 留观号
        /// </summary>
        internal void m_mthChangePatientIDOth4()
        {
            int k = 0;
            int status_int = -1;
            try
            {
                k = int.Parse(p_objRrecord.m_strINPATIENTNOTYPE_INT);
                status_int = int.Parse(p_objRrecord.m_strSTATUS_INT);
            }
            catch
            {
                return;
            }
            if (k != 2)
            {
                MessageBox.Show(m_objViewer, "当前病人不是留观住院号！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (status_int == -1)
            {
                MessageBox.Show(m_objViewer, "当前病人住院号已被撤消！", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //新增普通号
            CreateInpatientNo newNo = new CreateInpatientNo(2);
            if (newNo.ShowDialog() == DialogResult.OK)
            {
                //新住院号头标识
                string m_strhead = "";
                //新住院号
                string m_strInpatientid_chr = "";
                //1,新最大值来源于历史记录，2来源于最大值,0其它
                int m_intSour = 0;
                //新住院号主体数字部份
                string m_strMain = "";

                m_strInpatientid_chr = newNo.m_strGetInpatientid_chr(out m_strhead, out m_intSour);
                if (!m_strhead.Trim().Equals(""))
                {
                    m_strMain = m_strInpatientid_chr.Replace(m_strhead, "");
                }
                else
                {
                    m_strMain = m_strInpatientid_chr.Trim();
                }
                //string m_strRegisterid_chr,string oldInpatientid_chr, int inpatientnotype_int, string m_strHead, string m_strMain, int m_intSour
                long lngRes = m_objManage.m_lngChangePatientIDOth(p_objRrecord.m_strREGISTERID_CHR, p_objRrecord.m_strINPATIENTID_CHR, 2, 2, m_strhead, m_strMain, m_intSour);
                if (lngRes > 0)
                {
                    MessageBox.Show("操作成功！", "留观号->普通号", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_mthGetBIHPatientInfo(p_objRrecord.m_strREGISTERID_CHR);
                }
                else
                {
                    MessageBox.Show("操作失败！", "留观号->普通号", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region
        public void FindPatient()
        {
            string zyh = "";
            //frmm_commonFind f = new frmm_commonFind();
            if (m_commonFind.ShowDialog() == DialogResult.OK)
            {
                zyh = m_commonFind.Zyh;
                this.m_objViewer.m_ucPatientInfo.Status = 0;
                this.m_objViewer.m_ucPatientInfo.m_mthFind(zyh, 2);

                string status = this.m_objViewer.m_ucPatientInfo.BihPatient_VO.Status.ToString().Trim();
                string registerId = this.m_objViewer.m_ucPatientInfo.RegisterID;

                if (status == "3")
                {
                    MessageBox.Show("该病人已出院，不能撤销入院。", "提示");
                    this.m_objViewer.cmdCancle.Visible = false;
                    FindPatient();
                    return;
                }

            }
            else
            {
                //this.m_objViewer.Hide();
                this.m_objViewer.m_cancle = true;
                return;
            }
        }
        #endregion
    }
}
