using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Drawing;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    class clsCtl_YBDscx : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsCtl_YBDscx()
        {

        }

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmYBDscx m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYBDscx)frmMDI_Child_Base_in;
        }
        #endregion

        /// <summary>
        /// 医保对数查询VO
        /// </summary>
        clsDGYBDscx_VO objDgybdscxVo = null;
        /// <summary>
        /// 登录密码
        /// </summary>
        string strYBPass = string.Empty;

        public void m_mthInit()
        {
            objDgybdscxVo = new clsDGYBDscx_VO();
            objDgybdscxVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "YYBHMZ", "AnyOne");//默认查门诊
            strYBPass = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "PASSWORDMZ", "AnyOne");
            if (this.m_objViewer.cboYWLB.SelectedIndex == 0)
            {
                objDgybdscxVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "YYBHMZ", "AnyOne");
                strYBPass = clsYBPublic_cs.m_strReadXML("DGCSMZYB", "PASSWORDMZ", "AnyOne");
            }
            else if (this.m_objViewer.cboYWLB.SelectedIndex == 1)
            {
                objDgybdscxVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
                strYBPass = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "PASSWORDZY", "AnyOne");
            }
            //收费员编码
            objDgybdscxVo.SFYBH = this.m_objViewer.txtSFYBH.Text.Trim();//need modify,此界面能否取到收费员编码，是否允许查询全部收费员的明细，是否需要在界面上录入
            objDgybdscxVo.YWLB = this.m_objViewer.cboYWLB.Text.Trim().Split('-')[0].ToString();
            objDgybdscxVo.KSRQ = this.m_objViewer.dtmStart.Value.ToString("yyyyMMdd");
            objDgybdscxVo.ZZRQ = this.m_objViewer.dtmEnd.Value.ToString("yyyyMMdd");
        }

        public void m_mthQuery()
        {
            //初始化传入值
            m_mthInit();
            long lngRes = clsYBPublic_cs.m_lngUserLoin(objDgybdscxVo.YYBH, strYBPass, false);
            if (lngRes < 0)
            {
                MessageBox.Show("登录社保系统失败，请关闭界面打开重试！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            //因为结算数据量较大，“开始日期”，“截止日期”的日期间隔不可超过一个月
            if (this.m_objViewer.dtmStart.Value.AddMonths(1) < this.m_objViewer.dtmEnd.Value)
            {
                MessageBox.Show("查询日期范围不能超过1个月！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (this.m_objViewer.dtmStart.Value > this.m_objViewer.dtmEnd.Value)
            {
                MessageBox.Show("开始时间不能大于结束时间！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }

            if (this.m_objViewer.cboYWLB.SelectedIndex < 0 || string.IsNullOrEmpty(this.m_objViewer.cboYWLB.Text.Trim()))
            {
                MessageBox.Show("请选择正确业务类型！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                return;
            }
            if (objDgybdscxVo == null)
            {
                return;
            }
            clsDGYBDscxfh_VO objDgybdscxfhVo = null;
            List<clsDGYBDscxYYDSXX_VO> lstDgybdscxYYDSXXVo = null;
            lngRes = clsYBPublic_cs.m_lngFunSP1208(objDgybdscxVo, out objDgybdscxfhVo, out lstDgybdscxYYDSXXVo);
            if (lngRes > 0)
            {
                if (objDgybdscxfhVo == null || lstDgybdscxYYDSXXVo == null || lstDgybdscxYYDSXXVo.Count == 0)
                {
                    MessageBox.Show("该时间段没有对数数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
                //界面赋值
                this.m_objViewer.txtZYZJE.Text = objDgybdscxfhVo.ZYZJE_HJ;
                this.m_objViewer.txtZRS.Text = objDgybdscxfhVo.ZRS;
                this.m_objViewer.txtSBZFJE_HJ.Text = objDgybdscxfhVo.SBZFJE_HJ;
                this.m_objViewer.txtYLBZ_HJ.Text = objDgybdscxfhVo.YLBZ_HJ;
                this.m_objViewer.txtJZJE_HJ.Text = objDgybdscxfhVo.JZJE_HJ;
                this.m_objViewer.txtDBYLJZJ_HJ.Text = objDgybdscxfhVo.DBYLJZJ_HJ;
                this.m_objViewer.txtGRZFEIJE_HJ.Text = objDgybdscxfhVo.GRZFEIJE_HJ;
                try
                {
                    this.m_objViewer.txtSBBXJE_HJ.Text = (decimal.Parse(objDgybdscxfhVo.SBZFJE_HJ) + decimal.Parse(objDgybdscxfhVo.YLBZ_HJ) + decimal.Parse(objDgybdscxfhVo.JZJE_HJ) + decimal.Parse(objDgybdscxfhVo.DBYLJZJ_HJ)).ToString();
                }
                catch (Exception)
                {
                    throw;
                }
                //datagridview赋值
                int intCount = lstDgybdscxYYDSXXVo.Count;
                clsDGYBDscxYYDSXX_VO objDgybdscxYYDSXXTmpVo = null;
                string strJZLB = string.Empty;
                this.m_objViewer.dgvDetail.Rows.Clear();
                int intRow = 0;
                for (int i = 0; i < intCount; i++)
                {
                    objDgybdscxYYDSXXTmpVo = lstDgybdscxYYDSXXVo[i];
                    intRow = this.m_objViewer.dgvDetail.Rows.Add();
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells[0].Value = (i+1).ToString(); //"colXH"
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells[1].Value = objDgybdscxYYDSXXTmpVo.GMSFHM; //"colGMSFHM"
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colXM"].Value = objDgybdscxYYDSXXTmpVo.XM;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colJSRQ"].Value = objDgybdscxYYDSXXTmpVo.JSRQ;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colJZJLH"].Value = objDgybdscxYYDSXXTmpVo.JZJLH;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colJSYWH"].Value = objDgybdscxYYDSXXTmpVo.JSYWH;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colYWLB"].Value = objDgybdscxYYDSXXTmpVo.YWLB == "1" ? "门诊" : "住院";
                    #region 就诊类别
                    switch (objDgybdscxYYDSXXTmpVo.JZLB)
                    {
                        case "11":
                            strJZLB = "普通住院";
                            break;
                        case "12":
                            strJZLB = "特定门诊";
                            break;
                        case "13":
                            strJZLB = "家庭病床";
                            break;
                        case "22":
                            strJZLB = "急诊住院";
                            break;
                        case "23":
                            strJZLB = "转院住院";
                            break;
                        case "24":
                            strJZLB = "市外继续治疗";
                            break;
                        case "31":
                            strJZLB = "住院康复";
                            break;
                        case "32":
                            strJZLB = "门诊康复";
                            break;
                        case "33":
                            strJZLB = "康复器具";
                            break;
                        case "34":
                            strJZLB = "劳动能力鉴定";
                            break;
                        case "41":
                            strJZLB = "生育引起疾病住院";
                            break;
                        case "51":
                            strJZLB = "普通门诊";
                            break;
                        case "52":
                            strJZLB = "急诊门诊";
                            break;
                        case "53":
                            strJZLB = "转诊门诊";
                            break;
                        case "54":
                            strJZLB = "门诊抢救";
                            break;
                        case "61":
                            strJZLB = "特定门诊";
                            break;
                        case "62":
                            strJZLB = "社区特定门诊转诊";
                            break;
                        case "63":
                            strJZLB = "医院特定门诊(综保)";
                            break;
                        case "64":
                            strJZLB = "社区二类特定门诊";
                            break;
                        case "71":
                            strJZLB = "生育";
                            break;
                        case "72":
                            strJZLB = "生育剖腹产待遇";
                            break;
                        case "81":
                            strJZLB = "公务员体检";
                            break;
                        case "91":
                            strJZLB = "重流疾病";
                            break;
                        case "101":
                            strJZLB = "医学检查";
                            break;
                    }
                    #endregion
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colJZLB"].Value = strJZLB;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colZYZJE"].Value = objDgybdscxYYDSXXTmpVo.ZYZJE;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colSBZFJE"].Value = objDgybdscxYYDSXXTmpVo.SBZFJE;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colYLBZ"].Value = objDgybdscxYYDSXXTmpVo.YLBZ;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colJZJE"].Value = objDgybdscxYYDSXXTmpVo.JZJE;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colDBYLJZJ"].Value = objDgybdscxYYDSXXTmpVo.DBYLJZJ;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colGRZFEIJE"].Value = objDgybdscxYYDSXXTmpVo.GRZFEIJE;

                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colZFEIYY"].Value = objDgybdscxYYDSXXTmpVo.ZFEIYY;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colFPHM"].Value = objDgybdscxYYDSXXTmpVo.FPHM;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colJSJKLX"].Value = objDgybdscxYYDSXXTmpVo.JSJKLX;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colBCYLTCZF1"].Value = objDgybdscxYYDSXXTmpVo.BCYLTCZF1;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colBCYLTCZF2"].Value = objDgybdscxYYDSXXTmpVo.BCYLTCZF2;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colBCYLTCZF3"].Value = objDgybdscxYYDSXXTmpVo.BCYLTCZF3;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colBCYLTCZF4"].Value = objDgybdscxYYDSXXTmpVo.BCYLTCZF4;
                    this.m_objViewer.dgvDetail.Rows[intRow].Cells["colQTZHIFU"].Value = objDgybdscxYYDSXXTmpVo.QTZHIFU;
                    if (Math.IEEERemainder(Convert.ToDouble(i), 2) == 0)
                    {
                        this.m_objViewer.dgvDetail.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(235, 240, 235);
                    }
                }
            }
        }
    }
}
