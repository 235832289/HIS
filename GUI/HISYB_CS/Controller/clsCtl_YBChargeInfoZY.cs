using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;
using System.Data;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_YBChargeInfoZY : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsCtl_YBChargeInfoZY()
        {
            objDomain = new clsDcl_YB();
        }
        public clsDcl_YB objDomain = null;

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmYBChargeInfoZY m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYBChargeInfoZY)frmMDI_Child_Base_in;
        }
        #endregion

        #region 界面初始化
        /// <summary>
        /// 界面初始化
        /// </summary>
        public void m_mthInit()
        {
            //医院经办人注册需住院登录
            string strUser = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
            string strPwd = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "PASSWORDZY", "AnyOne");
            long lngRes = clsYBPublic_cs.m_lngUserLoin(strUser, strPwd, false);
            if (lngRes < 0)
            {
                MessageBox.Show("初始化失败，请重新打开！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question);
                //return;
            }
            this.m_mthIniTextBox();
        }
        #endregion

        #region 住院就诊记录查询
        /// <summary>
        /// 住院就诊记录查询
        /// </summary>
        public void m_mthQueryChargesInfo()
        {
            if (string.IsNullOrEmpty(this.m_objViewer.cmbJZJLH.Text.Trim()) && string.IsNullOrEmpty(this.m_objViewer.cmbJSXH.Text.Trim()))
            {
                MessageBox.Show("【就诊记录号】与【社保结算序号】不能同时为空");
                return;
            }
            List<clsChargeInfoZY_VO> lstChargeInfo = new List<clsChargeInfoZY_VO>();
            clsDGExtra_VO objDGyb = new clsDGExtra_VO();
            objDGyb.JZJLH = this.m_objViewer.cmbJZJLH.Text.Trim();
            objDGyb.SDYWH = this.m_objViewer.cmbJSXH.Text.Trim();
            objDGyb.JBR = this.m_objViewer.LoginInfo.m_strEmpNo;
            objDGyb.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
            objDGyb.CBDTCQBM = "";
            long lngRes = clsYBPublic_cs.m_lngFunSP1207(objDGyb, out lstChargeInfo);
            this.m_objViewer.lsvChargeDetails.Items.Clear();
            this.m_mthClearTextBox();
            if (lstChargeInfo.Count > 0)
            {
                ListViewItem objItem = null;
                clsChargeInfoZY_VO objChargeInfo = new clsChargeInfoZY_VO();
                for (int i = 0; i < lstChargeInfo.Count; i++)
                {
                    objItem = new ListViewItem(objChargeInfo.GMSFHM);
                    objChargeInfo = lstChargeInfo[i];
                    objItem.SubItems[0].Text = objChargeInfo.GMSFHM;
                    objItem.SubItems.Add(objChargeInfo.XM);
                    objItem.SubItems.Add(objChargeInfo.JZYY);
                    objItem.SubItems.Add(objChargeInfo.ZYH);
                    objItem.SubItems.Add(objChargeInfo.RYKS);
                    objItem.SubItems.Add(objChargeInfo.YYRYKS);
                    objItem.SubItems.Add(objChargeInfo.CYKS);
                    objItem.SubItems.Add(objChargeInfo.YYCYKS);
                    objItem.SubItems.Add( objChargeInfo.CWH);
                    objItem.SubItems.Add(objChargeInfo.RYRQ);
                    objItem.SubItems.Add(objChargeInfo.CYRQ);
                    objItem.SubItems.Add(objChargeInfo.ZYLB);
                    objItem.Tag = objChargeInfo;
                    this.m_objViewer.lsvChargeDetails.Items.Add(objItem);
                }
                this.m_objViewer.lsvChargeDetails.Select();
            }
        }
        #endregion

        #region 绑定数据
        /// <summary>
        /// 绑定数据
        /// </summary>
        public void m_mthFillAllData()
        {
            if (this.m_objViewer.lsvChargeDetails.SelectedItems.Count > 0)
            {
                clsChargeInfoZY_VO objChargeVO = this.m_objViewer.lsvChargeDetails.SelectedItems[0].Tag as clsChargeInfoZY_VO;
                this.m_objViewer.txtGMSFHM.Text = objChargeVO.GMSFHM;
                this.m_objViewer.txtXM.Text = objChargeVO.XM;
                this.m_objViewer.txtJZYY.Text = objChargeVO.JZYY;
                this.m_objViewer.txtZYH.Text = objChargeVO.ZYH;
                this.m_objViewer.txtRYKS.Text = objChargeVO.RYKS;

                this.m_objViewer.txtYYRYKS.Text = objChargeVO.YYRYKS;
                this.m_objViewer.txtCYKS.Text = objChargeVO.CYKS;
                this.m_objViewer.txtYYCYKS.Text = objChargeVO.YYCYKS;
                this.m_objViewer.txtCWH.Text = objChargeVO.CWH;
                this.m_objViewer.txtRYRQ.Text = objChargeVO.RYRQ;

                this.m_objViewer.txtCYRQ.Text = objChargeVO.CYRQ;
                this.m_objViewer.txtZYLB.Text = objChargeVO.ZYLB;
                this.m_objViewer.txtJZLB.Text = objChargeVO.JZLB;
                this.m_objViewer.txtRYZD.Text = objChargeVO.RYZD;
                this.m_objViewer.txtCYZD.Text = objChargeVO.CYZD;

                this.m_objViewer.txtWSBZ.Text = objChargeVO.WSBZ;
                this.m_objViewer.txtZQQRQK.Text = objChargeVO.ZQQRQK;
                this.m_objViewer.txtZQQRSBH.Text = objChargeVO.ZQQRSBH;
                this.m_objViewer.txtLXDH.Text = objChargeVO.LXDH;
                this.m_objViewer.txtBZ.Text = objChargeVO.BZ;

                this.m_objViewer.txtJBR.Text = objChargeVO.JBR;
                this.m_objViewer.txtJZJLH.Text = objChargeVO.JZJLH;
                this.m_objViewer.txtZYTS.Text = objChargeVO.ZYTS;
                this.m_objViewer.txtZYZJE.Text = objChargeVO.ZYZJE;
                this.m_objViewer.txtSBZFJE.Text = objChargeVO.SBZFJE;

                this.m_objViewer.txtGWYBZJE.Text = objChargeVO.GWYBZJE;
                this.m_objViewer.txtJZJE.Text = objChargeVO.JZJE;
                this.m_objViewer.txtGRZFJE.Text = objChargeVO.GRZFJE;
                this.m_objViewer.txtCYBZ.Text = objChargeVO.CYBZ;
                this.m_objViewer.txtJSQSRQ.Text = objChargeVO.JSQSRQ;

                this.m_objViewer.txtJSZZRQ.Text = objChargeVO.JSZZRQ;
                this.m_objViewer.txtJSSJ.Text = objChargeVO.JSSJ;
                this.m_objViewer.txtSDYWH.Text = objChargeVO.SDYWH;
                this.m_objViewer.txtZYSHJG.Text = objChargeVO.ZYSHJG;
                this.m_objViewer.txtCYYY.Text = objChargeVO.CYYY;

                this.m_objViewer.txtMZYFBXJE.Text = objChargeVO.MZYFBXJE;
                this.m_objViewer.txtDBYLJZJ.Text = objChargeVO.DBYLJZJ;
                this.m_objViewer.txtZTJSBZ.Text = objChargeVO.ZTJSBZ;
                this.m_objViewer.txtYSGH.Text = objChargeVO.YSGH;
                this.m_objViewer.txtFPHM.Text = objChargeVO.FPHM;

                this.m_objViewer.txtZDZMHM.Text = objChargeVO.ZDZMHM;
                this.m_objViewer.txtJSBZ.Text = objChargeVO.JSBZ;
                this.m_objViewer.txtCBDTCQBM.Text = objChargeVO.CBDTCQBM;
                this.m_objViewer.txtBCYLTCZF1.Text = objChargeVO.BCYLTCZF1;
                this.m_objViewer.txtBCYLTCZF2.Text = objChargeVO.BCYLTCZF2;

                this.m_objViewer.txtBCYLTCZF3.Text = objChargeVO.BCYLTCZF3;
                this.m_objViewer.txtBCYLTCZF4.Text = objChargeVO.BCYLTCZF4;
                this.m_objViewer.txtQTZHIFU.Text = objChargeVO.QTZHIFU;
                this.m_objViewer.txtRYDYZDBY.Text = objChargeVO.RYDYZDBY;
                this.m_objViewer.txtJSDYZDBY.Text = objChargeVO.JSDYZDBY;
            }
        }
        #endregion

        #region 清空TextBox数据
        /// <summary>
        /// 清空TextBox数据
        /// </summary>
        private void m_mthClearTextBox()
        {
            foreach (Control objCon in this.m_objViewer.groupBox2.Controls)
            {
                if (objCon.GetType().ToString().Contains("TextBox"))
                {
                    ((TextBox)objCon).Text = "";
                }
            }
        }

        private void m_mthIniTextBox()
        {
            foreach (Control objCon in this.m_objViewer.groupBox2.Controls)
            {
                if (objCon.GetType().ToString().Contains("TextBox"))
                {
                    ((TextBox)objCon).ReadOnly = true;
                    ((TextBox)objCon).BackColor = System.Drawing.Color.White;
                }
            }
        }
        #endregion

        #region 通过住院号来获取社保病人的就诊记录号
        /// <summary>
        /// 通过住院号来获取社保病人的就诊记录号
        /// </summary>
        public void m_mthGetJZJLHbyInpatientID()
        {
            string strInPatientID = this.m_objViewer.txtInpatient.Text.Trim();
            if (string.IsNullOrEmpty(strInPatientID))
            {
                MessageBox.Show("【住院号】不能为空！", "提示");
                return;
            }
            this.m_objViewer.cmbJZJLH.Focus();
            DataTable dtResult = new DataTable();
            this.m_objViewer.cmbJZJLH.Items.Clear();
            this.m_objViewer.cmbJZJLH.Text = "";
            this.objDomain.m_lngGetJZJLHbyInpatientID(strInPatientID, out dtResult);
            if (dtResult.Rows.Count > 0)
            {
                DataRow dr = null;
                ComboBoxItem cbi = null;
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    dr = dtResult.Rows[i];
                    cbi = new ComboBoxItem();
                    cbi.Text = dr["jzjlh_vchr"].ToString();
                    this.m_objViewer.cmbJZJLH.Items.Add(cbi);
                }
                this.m_objViewer.cmbJZJLH.SelectedIndex = 0;
                this.m_objViewer.cmbJZJLH.DroppedDown = true;
            }
            else
            {
                MessageBox.Show("该【住院号】没有相关的社保记录，请确认该病人是否是社保病人！");
                this.m_objViewer.txtInpatient.Focus();
            }
        }
        #endregion

        #region 通过就诊记录号来获取社保病人的结算号
        /// <summary>
        /// 通过就诊记录号来获取社保病人的结算号
        /// </summary>
        public void m_mthGetJSHbyJZJLH()
        {
            string strJZJLH = this.m_objViewer.cmbJZJLH.Text.Trim();
            if (string.IsNullOrEmpty(strJZJLH))
            {
                MessageBox.Show("【就诊记录号】不能为空！", "提示");
                return;
            }
            this.m_objViewer.cmbJSXH.Focus();
            DataTable dtResult = new DataTable();
            this.m_objViewer.cmbJSXH.Items.Clear();
            this.m_objViewer.cmbJSXH.Text = "";
            this.objDomain.m_lngGetJSHbyJZJLH(strJZJLH, out dtResult);
            if (dtResult.Rows.Count > 0)
            {
                DataRow dr = null;
                ComboBoxItem cbi = null;
                for (int i = 0; i < dtResult.Rows.Count; i++)
                {
                    dr = dtResult.Rows[i];
                    cbi = new ComboBoxItem();
                    cbi.Text = dr["sdywh"].ToString();
                    this.m_objViewer.cmbJSXH.Items.Add(cbi);
                }
                this.m_objViewer.cmbJSXH.SelectedIndex = 0;
                this.m_objViewer.cmbJSXH.DroppedDown = true;
            }
            else
            {
               // MessageBox.Show("该【住院号】没有相关的社保记录，请确认该病人是否是社保病人！");
            }
        }
        #endregion
    }

    public class ComboBoxItem
    {
        private string _text = null;
        private object _value = null;
        public string Text { get { return this._text; } set { this._text = value; } }
        public object Value { get { return this._value; } set { this._value = value; } }
        public override string ToString()
        {
            return this._text;
        }
    }
}
