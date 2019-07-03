using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_YBChargeItems : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmYBChargeItems m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmYBChargeItems)frmMDI_Child_Base_in;
        }
        #endregion

        public clsDcl_YB objDomain = null;
        public clsCtl_YBChargeItems()
        {
            objDomain = new clsDcl_YB();
        }

        #region 初始化界面
        /// <summary>
        /// 初始化界面
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
            }
        }
        #endregion

        clsDGExtra_VO objDgextraVo = null;
        #region 查询记账处方项目
        /// <summary>
        /// 查询记账处方项目
        /// </summary>
        public void m_mthGetYBChargeItems()
        {
            objDgextraVo = new clsDGExtra_VO();
            this.m_objViewer.lsvJZXM.Items.Clear();
            List<clsDGZyxmcs_VO> lstDgzyxmcsVo = null;
            System.Text.StringBuilder strValue = null;
            objDgextraVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
            objDgextraVo.JZJLH = this.m_objViewer.txtJZJLH.Text.ToString().Trim();
            objDgextraVo.StarTime = this.m_objViewer.dtpStarTime.Value;
            objDgextraVo.EndTime = this.m_objViewer.dtpEndTime.Value;
            objDgextraVo.JBR = this.m_objViewer.LoginInfo.m_strEmpNo;
            long lngRes = clsYBPublic_cs.m_lngFunSP3011(objDgextraVo, out lstDgzyxmcsVo, out strValue);
            if (lngRes > 0)
            {
                if (lstDgzyxmcsVo != null && lstDgzyxmcsVo.Count > 0)
                {
                    foreach (clsDGZyxmcs_VO objDGZyxm in lstDgzyxmcsVo)
                    {
                        #region 赋值
                        ListViewItem lsvItem = new ListViewItem(); ;//objDGZyxm.JZSJ
                        lsvItem.SubItems.Add(objDGZyxm.JZSJ);
                        lsvItem.SubItems.Add(objDGZyxm.FYRQ);
                        lsvItem.SubItems.Add(objDGZyxm.ZYH);
                        lsvItem.SubItems.Add(objDGZyxm.XMXH);
                        lsvItem.SubItems.Add(objDGZyxm.YYXMBM);
                        lsvItem.SubItems.Add(objDGZyxm.XMMC);
                        lsvItem.SubItems.Add(objDGZyxm.FLDM);
                        lsvItem.SubItems.Add(objDGZyxm.YBXMBM);
                        lsvItem.SubItems.Add(objDGZyxm.CFXMWYH);
                        lsvItem.SubItems.Add(objDGZyxm.JG.ToString());
                        lsvItem.SubItems.Add(objDGZyxm.MCYL.ToString());
                        lsvItem.SubItems.Add(objDGZyxm.JE.ToString());
                        lsvItem.SubItems.Add(objDGZyxm.XZSYBZ);
                        lsvItem.SubItems.Add(objDGZyxm.FHXZBZ);
                        lsvItem.SubItems.Add(objDGZyxm.DYBZ);
                        lsvItem.SubItems.Add(objDGZyxm.ZFEIBL.ToString());
                        lsvItem.SubItems.Add(objDGZyxm.ZFEIJE.ToString());
                        lsvItem.SubItems.Add(objDGZyxm.GWYBZBL.ToString());
                        this.m_objViewer.lsvJZXM.Items.Add(lsvItem);
                        #endregion
                    }
                }
            }
        }
        #endregion

        #region 全选
        /// <summary>
        /// 全选
        /// </summary>
        public void m_mthSelectAllItems()
        {
            foreach (ListViewItem item in this.m_objViewer.lsvJZXM.Items)
            {
                item.Checked = true;
            }
        }
        #endregion

        #region 反选
        /// <summary>
        /// 反选
        /// </summary>
        public void m_mthInvertSelection()
        {
            foreach (ListViewItem item in this.m_objViewer.lsvJZXM.Items)
            {
                if (item.Checked)
                {
                    item.Checked = false;
                }
                else
                {
                    item.Checked = true;
                }
            }
        }
        #endregion

        #region 住院记帐处方项目批量删除
        /// <summary>
        /// 住院记帐处方项目批量删除
        /// </summary>
        public void m_mthDeleteYBChargeItems()
        {
            if (this.m_objViewer.lsvJZXM.Items.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
            {
                return;
            }
            objDgextraVo = new clsDGExtra_VO();
            List<clsDGZyxmcs_VO> lstDgzyxmcsVo = null;
            System.Text.StringBuilder strValue = null;
            objDgextraVo.YYBH = clsYBPublic_cs.m_strReadXML("DGCSZYYB", "YYBHZY", "AnyOne");
            objDgextraVo.JZJLH = this.m_objViewer.txtJZJLH.Text.ToString().Trim();
            objDgextraVo.ZYH = this.m_objViewer.lsvJZXM.Items[0].SubItems[3].Text.ToString().Trim();
            objDgextraVo.CBDTCQBM = "441925";
            objDgextraVo.JBR = this.m_objViewer.LoginInfo.m_strEmpNo;
            #region 获取该就诊记录下，所有的处方项目唯一号
            clsDGZyxmcs_VO objDGZyxm = null;
            lstDgzyxmcsVo = new List<clsDGZyxmcs_VO>();
            com.digitalwave.Utility.clsLogText objLog = new com.digitalwave.Utility.clsLogText();
            for (int i = 0; i < this.m_objViewer.lsvJZXM.Items.Count; i++)
            {
                objDGZyxm = new clsDGZyxmcs_VO();
                objDGZyxm.CFXMWYH = this.m_objViewer.lsvJZXM.Items[i].SubItems[9].Text.ToString().Trim();
                objLog.LogError("objDGZyxm.CFXMWYH:" + objDGZyxm.CFXMWYH + "\n");
                lstDgzyxmcsVo.Add(objDGZyxm);
            }
            #endregion
            long lngRes = clsYBPublic_cs.m_lngFunSP3012(lstDgzyxmcsVo, objDgextraVo);
            if (lngRes > 0)
            {
                this.m_objViewer.lsvJZXM.Items.Clear();
                MessageBox.Show("删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        #endregion
    }
}
