using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_YBBillInfoMZ : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmYBBillInfoMZ m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYBBillInfoMZ)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化界面
        /// <summary>
        /// 初始化界面
        /// </summary>
        public void m_mthInit()
        {
            //医院经办人注册需住院登录
            string strUser = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHMZ", "AnyOne");
            string strPwd = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "PASSWORDMZ", "AnyOne");
            long lngRes = clsYBPublic_cs.m_lngUserLoin(strUser, strPwd, false);
            if (lngRes < 0)
            {
                MessageBox.Show("初始化失败，请重新打开！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }
        #endregion

        public clsCtl_YBBillInfoMZ()
        {
            objDomain = new clsDcl_YB();
        }
        public clsDcl_YB objDomain = null;

        #region 查询门诊结算信息
        /// <summary>
        /// 查询门诊结算信息
        /// </summary>
        public void m_mthGetBillInfoMZ()
        {
            this.m_objViewer.dgvBillDetail.Rows.Clear();
            if (string.IsNullOrEmpty(this.m_objViewer.txtCardNo.Text.ToString().Trim()))
            {
                MessageBox.Show("请输入卡号或者身份证号!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DateTime dtStart = this.m_objViewer.dtpStart.Value;
            DateTime dtEnd = this.m_objViewer.dtpEnd.Value;
            if (DateTime.Compare(dtStart, dtEnd) > 0)
            {
                MessageBox.Show("起始时间大于终止时间!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string IDcard = this.m_objViewer.txtCardNo.Text.Trim();
            if (this.m_objViewer.cboPatientType.SelectedIndex == 0)
            {
                if (IDcard.Length < 10)
                {
                    IDcard = IDcard.PadLeft(10, '0');
                    this.m_objViewer.txtCardNo.Text = IDcard;
                }
                DataTable dt = new DataTable();
                long lngRes1 = this.objDomain.m_lngGetPatientInfo(IDcard, out dt);
                if (lngRes1 > 0 && dt.Rows.Count > 0)
                {
                    IDcard = dt.Rows[0]["idcard_chr"].ToString();
                }
                else
                {
                    MessageBox.Show("请检查卡号是否输入正确！","提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            List<clsBillInfoMZ_VO> lstBillInfo = new List<clsBillInfoMZ_VO>();
            clsDGExtra_VO objDGyb = new clsDGExtra_VO();
            objDGyb.GMSFHM = IDcard;
            objDGyb.StarTime = dtStart;
            objDGyb.EndTime = dtEnd;
            objDGyb.JBR = this.m_objViewer.LoginInfo.m_strEmpNo;
            objDGyb.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHMZ", "AnyOne");
            long lngRes = clsYBPublic_cs.m_lngFunSP1206(objDGyb, out lstBillInfo);
            if (lngRes > 0 && lstBillInfo.Count > 0)
            {
                int Index = 0;
                foreach (clsBillInfoMZ_VO objBillInfo in lstBillInfo)
                {
                    Index = this.m_objViewer.dgvBillDetail.Rows.Add();
                    this.m_objViewer.dgvBillDetail["GMSFHM", Index].Value = objBillInfo.GMSFHM;
                    this.m_objViewer.dgvBillDetail["GRBH", Index].Value = objBillInfo.GRBH;
                    this.m_objViewer.dgvBillDetail["XM", Index].Value = objBillInfo.XM;
                    this.m_objViewer.dgvBillDetail["YYBH", Index].Value = objBillInfo.YYBH;
                    this.m_objViewer.dgvBillDetail["YYMC", Index].Value = objBillInfo.YYMC;
                    this.m_objViewer.dgvBillDetail["ZYJSLB", Index].Value = objBillInfo.ZYJSLB;
                    this.m_objViewer.dgvBillDetail["JZLB", Index].Value = objBillInfo.JZLB;
                    this.m_objViewer.dgvBillDetail["JSRQ", Index].Value = objBillInfo.JSRQ;
                    this.m_objViewer.dgvBillDetail["RYRQ", Index].Value = objBillInfo.RYRQ;
                    this.m_objViewer.dgvBillDetail["CYRQ", Index].Value = objBillInfo.CYRQ;
                    this.m_objViewer.dgvBillDetail["CYZD", Index].Value = objBillInfo.CYZD;
                    this.m_objViewer.dgvBillDetail["JZJLH", Index].Value = objBillInfo.JZJLH;
                    this.m_objViewer.dgvBillDetail["SDYWH", Index].Value = objBillInfo.SDYWH;
                    this.m_objViewer.dgvBillDetail["CFH", Index].Value = objBillInfo.CFH;
                    this.m_objViewer.dgvBillDetail["ZH", Index].Value = objBillInfo.ZH;
                    this.m_objViewer.dgvBillDetail["YLFYZE", Index].Value = objBillInfo.YLFYZE;
                    this.m_objViewer.dgvBillDetail["GRZFZE", Index].Value = objBillInfo.GRZFZE;
                    this.m_objViewer.dgvBillDetail["KSMC", Index].Value = objBillInfo.KSMC;
                    this.m_objViewer.dgvBillDetail["YYRYKS", Index].Value = objBillInfo.YYRYKS;
                    this.m_objViewer.dgvBillDetail["MZYFBXJE", Index].Value = objBillInfo.MZYFBXJE;
                    this.m_objViewer.dgvBillDetail["BCYLTCZF1", Index].Value = objBillInfo.BCYLTCZF1;
                    this.m_objViewer.dgvBillDetail["BCYLTCZF2", Index].Value = objBillInfo.BCYLTCZF2;
                    this.m_objViewer.dgvBillDetail["BCYLTCZF3", Index].Value = objBillInfo.BCYLTCZF3;
                    this.m_objViewer.dgvBillDetail["BCYLTCZF4", Index].Value = objBillInfo.BCYLTCZF4;
                    this.m_objViewer.dgvBillDetail["QTZHIFU", Index].Value = objBillInfo.QTZHIFU;
                }
            }
        }
        #endregion
    }
}
