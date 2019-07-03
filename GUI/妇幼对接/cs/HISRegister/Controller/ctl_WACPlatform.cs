using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using com.digitalwave.iCare.gui.LIS;
using com.digitalwave.iCare.middletier.HI;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 妇幼信息平台
    /// </summary>
    public class ctl_WACPlatform : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量

        /// <summary>
        /// 服务器IP
        /// </summary>
        string ServerIp = "http://10.10.2.109";

        #endregion

        #region 设置窗体对象

        frmWACPlatform m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmWACPlatform)frmMDI_Child_Base_in;
        }
        #endregion

        #region Reset
        /// <summary>
        /// Reset
        /// </summary>
        void Reset()
        {
            this.m_objViewer.txtCardNo.Text = string.Empty;
            this.m_objViewer.lblPatName.Text = string.Empty;
            this.m_objViewer.lblSex.Text = string.Empty;
            this.m_objViewer.lblAge.Text = string.Empty;
            this.m_objViewer.lblPayType.Text = string.Empty;
            this.m_objViewer.webBrowser.Navigate(string.Empty);
            this.m_objViewer.txtCardNo.Tag = null;
            this.m_objViewer.txtCardNo.Focus();
        }
        #endregion

        #region Init
        /// <summary>
        /// Init
        /// </summary>
        internal void Init()
        {
            Reset();
        }
        #endregion

        #region FindPatient
        /// <summary>
        /// FindPatient
        /// </summary>
        internal void FindPatient()
        {
            string cardNo = this.m_objViewer.txtCardNo.Text.Trim();
            if (cardNo == string.Empty)
            {
                MessageBox.Show("请输入卡号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.txtCardNo.Focus();
                return;
            }
            else
            {
                if (cardNo.Length != 10)
                {
                    cardNo = cardNo.PadLeft(10, '0');
                    this.m_objViewer.txtCardNo.Text = cardNo;
                }
            }
            DataTable dt = null;
            (new clsDcl_ShowReports()).m_mthFindPatientInfo(1, cardNo, out dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                this.m_objViewer.lblPatName.Text = dr["lastname_vchr"].ToString();
                this.m_objViewer.lblSex.Text = dr["sex_chr"].ToString();
                this.m_objViewer.lblAge.Text = dr["birth_dat"] == DBNull.Value ? string.Empty : (new clsBrithdayToAge()).m_strGetAge(dr["birth_dat"].ToString());
                this.m_objViewer.lblPayType.Text = dr["paytypename_vchr"].ToString();
                this.m_objViewer.txtCardNo.Tag = dr;
            }
            else
            {
                MessageBox.Show("查无数据", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reset();
            }
        }
        #endregion

        #region GetPatObj
        /// <summary>
        /// GetPatObj
        /// </summary>
        /// <returns></returns>
        DataRow GetPatObj()
        {
            if (this.m_objViewer.txtCardNo.Tag == null)
            {
                MessageBox.Show("请输入门诊卡号", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            else
            {
                return this.m_objViewer.txtCardNo.Tag as DataRow;
            }
        }
        #endregion

        #region Record
        /// <summary>
        /// 妇幼建档
        /// </summary>
        internal void Record()
        {
            DataRow dr = this.GetPatObj();
            if (dr != null)
            {
                try
                {
                    int n = -1;
                    object[] objs = new object[21];
                    // HIS单位对应的
                    objs[++n] = "A74CC68F-B009-4264-A880-FBE87DD91E56";
                    // HIS单位对应的
                    objs[++n] = "763709818";
                    // 卡号.PatientNo
                    objs[++n] = dr["patientcardid_chr"].ToString();
                    // 操作员
                    objs[++n] = "0001";
                    // HISID
                    objs[++n] = dr["patientid_chr"].ToString();
                    // 女方姓名
                    objs[++n] = dr["lastname_vchr"].ToString();
                    // 证件类型
                    objs[++n] = "01";
                    // 证件号
                    objs[++n] = dr["idcard_chr"].ToString();
                    // 费别类别
                    objs[++n] = dr["paytypename_vchr"].ToString();
                    // 出生日期
                    objs[++n] = Convert.ToDateTime(dr["birth_dat"].ToString()).ToString("yyyy-MM-dd");
                    // 单位
                    objs[++n] = dr["employer_vchr"].ToString();
                    // 电话
                    objs[++n] = dr["homephone_vchr"].ToString();
                    // 现住地址行政区划代码
                    objs[++n] = "";
                    // 现住地址门牌
                    objs[++n] = dr["homeaddress_vchr"].ToString();
                    // 职业代码
                    objs[++n] = "";
                    // 联系人
                    objs[++n] = dr["contactpersonfirstname_vchr"].ToString();
                    // 关系代码
                    objs[++n] = "1"; // 默认1: 父母与亲生儿女 dr[""].ToString();
                    // 联系电话
                    objs[++n] = dr["contactpersonphone_vchr"].ToString();
                    // 诊疗卡号.PatientNo
                    objs[++n] = dr["patientcardid_chr"].ToString();
                    // 户籍地址行政区划代码
                    objs[++n] = "";
                    // 户籍地址门牌
                    objs[++n] = "";
                    clsPublic.PlayAvi("加载妇幼平台界面，请稍候...");
                    string uri = string.Format(this.ServerIp + "/W_Fubao/AspCode/JiBenXinXi/HIS/Default.aspx?INFOID={0}&AUTHORID={1}&PatientNo={2}&USER={3}&page=CreateArchive&HISID={4}&HDSB0101001={5}&HDSB0101004={6}&HDSB0101005={7}&HDSB0101002={8}ID&HDSB0101006={9}&HDSB0101008={10}&HDSB0101009={11}&HDSB0101022={12}&HDSB0101023={13}&HDSB0101010={14}&HDSB0101011={15}&HDSB0101012={16}&HDSB0101013={17}&PatientNo={18}&BARCODE=&DEP=&HDSB0101020={19}&HDSB0101021={20}", objs);
                    this.m_objViewer.webBrowser.Navigate(uri);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsPublic.CloseAvi();
                }
            }
        }
        #endregion

        #region Measurement
        /// <summary>
        /// 一般测量
        /// </summary>
        internal void Measurement()
        {
            // 妇幼平台总入口
            this.Query();
        }
        #endregion

        #region Query
        /// <summary>
        /// Query
        /// </summary>
        internal void Query()
        {
            DataRow dr = this.GetPatObj();
            if (dr != null)
            {
                try
                {
                    int n = -1;
                    object[] objs = new object[5];
                    objs[++n] = "763709818";
                    objs[++n] = "A74CC68F-B009-4264-A880-FBE87DD91E56";
                    objs[++n] = "0001";
                    objs[++n] = dr["patientid_chr"].ToString();
                    objs[++n] = DateTime.Now.ToString("yyyy-MM-dd");
                    clsPublic.PlayAvi("加载妇幼平台界面，请稍候...");
                    string uri = string.Format(this.ServerIp + "/W_Fubao/AspCode/JiBenXinXi/HIS/Default.aspx?AUTHORID={0}&INFOID={1}&USER={2}&page=ChanJianTab&HISID={3}&DATE={4}&BARCODE=&HDSB0101005=&DEP=", objs);
                    this.m_objViewer.webBrowser.Navigate(uri);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsPublic.CloseAvi();
                }
            }
        }
        #endregion

        #region Print
        /// <summary>
        /// Print
        /// </summary>
        internal void Print()
        {
            DataRow dr = this.GetPatObj();
            if (dr != null)
            {
                try
                {
                    int n = -1;
                    object[] objs = new object[4];
                    objs[++n] = "763709818";
                    objs[++n] = "A74CC68F-B009-4264-A880-FBE87DD91E56";
                    objs[++n] = "0001";
                    objs[++n] = dr["patientid_chr"].ToString();
                    clsPublic.PlayAvi("加载妇幼平台界面，请稍候...");
                    string uri = string.Format(this.ServerIp + "/W_Fubao/AspCode/JiBenXinXi/HIS/Default.aspx?AUTHORID={0}&INFOID={1}&USER={2}&page=print&HISID={3}&BARCODE=&HDSB0101005=&DEP=", objs);
                    this.m_objViewer.webBrowser.Navigate(uri);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    clsPublic.CloseAvi();
                }
            }
        }
        #endregion


    }
}
