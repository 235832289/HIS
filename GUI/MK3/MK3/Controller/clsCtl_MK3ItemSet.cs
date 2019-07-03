using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using com.digitalwave.iCare.ValueObject;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.LIS
{
    public class clsCtl_MK3ItemSet:com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// 窗体viewer
        /// </summary>
        frmMK3ItemSet m_objViewer;
        /// <summary>
        /// 检验项目表
        /// </summary>
        internal DataTable m_dtCheckItem = null;
        /// <summary>
        /// 酶标仪控制Domain层
        /// </summary>
        clsDomainController_MK3ItemSetManage m_objDomain;
        #endregion

        #region 设置界面层
   
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmMK3ItemSet)frmMDI_Child_Base_in;
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
        }
        #endregion

        #region 构造函数
        public clsCtl_MK3ItemSet()
        {
            m_objDomain = new clsDomainController_MK3ItemSetManage();
        }
        #endregion

        #region 获取所有的检验项目
        /// <summary>
        /// 获取所有的检验项目
        /// </summary>
        public void m_mthGetAllCheckItem(string p_strDeviceModelID)
        {
            long lngRes = 0;    
            lngRes = m_objDomain.m_lngGetAllCheckItem(p_strDeviceModelID,out m_dtCheckItem);
            if (lngRes > 0)
            {
                m_objViewer.m_cboDeviceCheckItem.ValueMember = "device_check_item_id_chr";
                m_objViewer.m_cboDeviceCheckItem.DisplayMember = "device_check_item_name_vchr";
                m_objViewer.m_cboDeviceCheckItem.DataSource = m_dtCheckItem;
            }
        }
        #endregion

        #region 获取所有自定义项目的信息
        /// <summary>
        /// 获取所有自定义项目的信息
        /// </summary>
        /// <param name="p_objCheckItemCustomVO"></param>
        /// <returns></returns>
        public long m_lngGetAllCheckItemCustomInfo(out clsLisCheckItemCustom[] p_objCheckItemCustomVO,out DataTable p_dtResult)
        {
            long lngRes = 0;
            p_objCheckItemCustomVO = null;
            DataTable m_dtResult = null;
            lngRes = m_objDomain.m_lngGetAllCheckItemCustomInfo(out p_objCheckItemCustomVO, out p_dtResult);
            return lngRes;
        }
        #endregion

        #region 修改自定义项目
        /// <summary>
        /// 修改自定义项目
        /// </summary>
        /// <param name="p_objCheckItemCustomVO"></param>
        public void m_mthUpdateCheckItemCustom(clsLisCheckItemCustom p_objCheckItemCustomVO)
        {
            long lngRes = 0;
            lngRes = m_objDomain.m_lngUpdateCheckItemCustom(p_objCheckItemCustomVO);
            if (lngRes > 0)
            {
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chCheckItemId"].Value = p_objCheckItemCustomVO.m_strCheckItemID;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chCheckItemName"].Value = p_objCheckItemCustomVO.m_strCheckItemName;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chPosMax"].Value = p_objCheckItemCustomVO.m_strPosMaxValue;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chPosMin"].Value = p_objCheckItemCustomVO.m_strPosMinValue;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chNegMax"].Value = p_objCheckItemCustomVO.m_strNegMaxValue;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chNegMin"].Value = p_objCheckItemCustomVO.m_strNegMinValue;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_cheformula"].Value = p_objCheckItemCustomVO.m_strformula;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chNum"].Value = p_objCheckItemCustomVO.m_strSeq_chr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chNcQCMaxValue"].Value = p_objCheckItemCustomVO.m_strQc_Neg_Maxvalue_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chNCQCMinValue"].Value = p_objCheckItemCustomVO.m_strQc_Neg_Minvalue_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chPCQCMaxValue"].Value = p_objCheckItemCustomVO.m_strQc_Pos_Maxvalue_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chPCQCMinValue"].Value = p_objCheckItemCustomVO.m_strQc_Pos_Minvalue_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chCOFormula"].Value = p_objCheckItemCustomVO.m_strQCFormula_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chQCFormula"].Value = p_objCheckItemCustomVO.m_strQc_Result_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chrMoreNCFormula"].Value = p_objCheckItemCustomVO.m_strMore_Neg_Formula_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chMorePCFormula"].Value = p_objCheckItemCustomVO.m_strMore_Pos_Formula_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chQCNCFormula"].Value = p_objCheckItemCustomVO.m_strQc_Neg_Formula_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chQCPCFormula"].Value = p_objCheckItemCustomVO.m_strQc_Pos_Formula_vchr;
                m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["Tag"].Value = p_objCheckItemCustomVO;
            }
        }
        #endregion

        #region 删除自定义项目
        /// <summary>
        /// 删除自定义项目
        /// </summary>
        /// <param name="p_strCheckItemID"></param>
        public void m_mthDeleteCheckItemCustom(string p_strCheckItemID)
        {
            long lngRes = 0;
            lngRes = m_objDomain.m_lngDelteCheckItemCustom(p_strCheckItemID);
            if (lngRes > 0)
            {
                int i = m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Index;
                m_objViewer.m_dgCheckItemCustom.Rows.RemoveAt(i);
            }
        }
        #endregion

        #region 添加自定义项目
        /// <summary>
        /// 添加自定义项目
        /// </summary>
        /// <param name="p_objCheckItemCustomVO"></param>
        public void m_mthInsertCheckItemCustom(clsLisCheckItemCustom p_objCheckItemCustomVO)
        {
            long lngRes = 0;
            lngRes = m_objDomain.m_lngInsertCheckItemCustom(p_objCheckItemCustomVO);
            if (lngRes > 0)
            {
                m_objViewer.m_dgCheckItemCustom.Rows.Add(new object[] {p_objCheckItemCustomVO.m_strCheckItemName,p_objCheckItemCustomVO.m_strPosMaxValue,p_objCheckItemCustomVO.m_strPosMinValue,
                    p_objCheckItemCustomVO.m_strNegMaxValue,p_objCheckItemCustomVO.m_strNegMinValue,p_objCheckItemCustomVO.m_strformula,p_objCheckItemCustomVO.m_strSeq_chr,
                     p_objCheckItemCustomVO.m_strQc_Neg_Maxvalue_vchr,p_objCheckItemCustomVO.m_strQc_Neg_Minvalue_vchr,p_objCheckItemCustomVO.m_strQc_Pos_Maxvalue_vchr
                    ,p_objCheckItemCustomVO.m_strQc_Pos_Minvalue_vchr, p_objCheckItemCustomVO.m_strQCFormula_vchr,p_objCheckItemCustomVO.m_strQc_Result_vchr,
                    p_objCheckItemCustomVO.m_strMore_Neg_Formula_vchr,p_objCheckItemCustomVO.m_strMore_Pos_Formula_vchr,p_objCheckItemCustomVO.m_strQc_Neg_Formula_vchr,p_objCheckItemCustomVO.m_strQc_Pos_Formula_vchr,
                    p_objCheckItemCustomVO.m_strCheckItemID,p_objCheckItemCustomVO});
            }
        }
        #endregion

        #region 添加或修改自定义项目
        public void m_mthOperationCheckItemCustom()
        {
            clsLisCheckItemCustom objCheckItemCustomVO = new clsLisCheckItemCustom();

            objCheckItemCustomVO.m_strCheckItemID = m_objViewer.m_cboDeviceCheckItem.SelectedValue.ToString();
            objCheckItemCustomVO.m_strCheckItemName = m_objViewer.m_cboDeviceCheckItem.Text;
            objCheckItemCustomVO.m_strPosMaxValue = m_objViewer.m_txtPCMaxValue.Text;
            objCheckItemCustomVO.m_strPosMinValue = m_objViewer.m_txtPCMinValue.Text;
            objCheckItemCustomVO.m_strNegMaxValue = m_objViewer.m_txtNCMaxValue.Text;
            objCheckItemCustomVO.m_strNegMinValue = m_objViewer.m_txtNCMinValue.Text;
            objCheckItemCustomVO.m_strSeq_chr = m_objViewer.m_txtSeq.Text;
            objCheckItemCustomVO.m_strQCFormula_vchr = m_objViewer.m_txtCOFormula.Text;
            objCheckItemCustomVO.m_strQc_Neg_Maxvalue_vchr = m_objViewer.m_txtQCNCMaxValue.Text;
            objCheckItemCustomVO.m_strQc_Neg_Minvalue_vchr = m_objViewer.m_txtQCNCMinvalue.Text;
            objCheckItemCustomVO.m_strQc_Pos_Maxvalue_vchr = m_objViewer.m_txtQCPCMaxvalue.Text;
            objCheckItemCustomVO.m_strQc_Pos_Minvalue_vchr = m_objViewer.m_txtQCPCMinvalue.Text;
            objCheckItemCustomVO.m_strQc_Result_vchr = m_objViewer.m_txtQCResultFromula.Text;
            objCheckItemCustomVO.m_strColor = m_objViewer.m_txtColor.BackColor.R.ToString() + ":"
                + m_objViewer.m_txtColor.BackColor.G.ToString() + ":" + m_objViewer.m_txtColor.BackColor.B.ToString();
            objCheckItemCustomVO.m_strformula = m_objViewer.m_txtCutoff.Text;
            objCheckItemCustomVO.m_strMore_Neg_Formula_vchr = m_objViewer.m_txtMoreNCFormula.Text;
            objCheckItemCustomVO.m_strMore_Pos_Formula_vchr = m_objViewer.m_txtMorePCFormula.Text;
            objCheckItemCustomVO.m_strQc_Neg_Formula_vchr = m_objViewer.m_txtQCNCFormula.Text;
            objCheckItemCustomVO.m_strQc_Pos_Formula_vchr = m_objViewer.m_txtQCPCFormula.Text;
            long lngRes = 0;
            if (m_objViewer.m_txtCutoff.Tag != null)
            {
                m_mthUpdateCheckItemCustom(objCheckItemCustomVO);
            }
            else
            {
                m_mthInsertCheckItemCustom(objCheckItemCustomVO);
            }
        }
        #endregion

        #region 获取自定义项目的结果判断
        /// <summary>
        /// 获取自定义项目的结果判断
        /// </summary>
        public void m_mthGetCheckItemCustomRes()
        {
            m_objViewer.m_dgCheckItemResult.Rows.Clear();
            string m_strCheckItemID = m_objViewer.m_dgCheckItemCustom.SelectedRows[0].Cells["m_chCheckItemId"].Value.ToString().Trim();
            long lngRes = 0;
            clsLisCheckItemCustomRes[] m_objCheckItemCustomResArr = null;
            m_objViewer.m_txtNo.Text = "1";
            m_objViewer.m_txtConditions.Text = "";
            m_objViewer.m_cboResult.SelectedIndex = 0;
            lngRes = m_objDomain.m_lngQueryCheckItemCustomRes(m_strCheckItemID, out m_objCheckItemCustomResArr);
            if (lngRes > 0 && m_objCheckItemCustomResArr != null)
            {
                if (m_objCheckItemCustomResArr.Length > 0)
                {
                    for (int i = 0; i < m_objCheckItemCustomResArr.Length; i++)
                    {
                        m_objViewer.m_dgCheckItemResult.Rows.Add(new object[] {m_objCheckItemCustomResArr[i].m_strSeq,
                        m_objCheckItemCustomResArr[i].m_strConditions,m_objCheckItemCustomResArr[i].m_strResult,
                        m_objCheckItemCustomResArr[i].m_strCheckItemID,m_objCheckItemCustomResArr[i]});
                    }
                }
            }
        }
        #endregion

        #region 添加或者修改自定义项目的结果判断
        /// <summary>
        /// 添加或者修改自定义项目的结果判断
        /// </summary>
        public void m_mthOperationCheckItemCustomRes()
        {
            clsLisCheckItemCustomRes m_objCheckItemCustomRes = new clsLisCheckItemCustomRes();
            m_objCheckItemCustomRes.m_strCheckItemID = m_objViewer.m_cboDeviceCheckItem.SelectedValue.ToString();
            m_objCheckItemCustomRes.m_strConditions = m_objViewer.m_txtConditions.Text;
            m_objCheckItemCustomRes.m_strResult = m_objViewer.m_cboResult.Text;
            m_objCheckItemCustomRes.m_strSeq = m_objViewer.m_txtNo.Text;
            clsLisCheckItemCustomRes m_objCheckItemCustomResVO = (clsLisCheckItemCustomRes)m_objViewer.m_txtConditions.Tag;
            long lngRes = 0;
            if (m_objCheckItemCustomResVO != null)
            {
                lngRes = m_objDomain.m_lngUpdateCheckItemCustomRes(m_objCheckItemCustomRes);
                if (lngRes > 0)
                {
                    m_objViewer.m_dgCheckItemResult.SelectedRows[0].Cells["m_chSeq"].Value = m_objCheckItemCustomRes.m_strSeq;
                    m_objViewer.m_dgCheckItemResult.SelectedRows[0].Cells["m_chconditions"].Value = m_objCheckItemCustomRes.m_strConditions;
                    m_objViewer.m_dgCheckItemResult.SelectedRows[0].Cells["m_cheresult"].Value = m_objCheckItemCustomRes.m_strResult;
                    m_objViewer.m_dgCheckItemResult.SelectedRows[0].Cells["m_chCheckiteid"].Value = m_objCheckItemCustomRes.m_strCheckItemID;
                    m_objViewer.m_dgCheckItemResult.SelectedRows[0].Cells["DataSource"].Value = m_objCheckItemCustomRes;
                }
            }
            else
            {
                lngRes = m_objDomain.m_lngInsertCheckItemCustomRes(m_objCheckItemCustomRes);
                m_objViewer.m_dgCheckItemResult.Rows.Add(new object[] {m_objCheckItemCustomRes.m_strSeq,m_objCheckItemCustomRes.m_strConditions,
                m_objCheckItemCustomRes.m_strResult,m_objCheckItemCustomRes.m_strCheckItemID,m_objCheckItemCustomRes});
            }
        }
        #endregion

        #region 删除自定义项目结果判断
        /// <summary>
        /// 删除自定义项目结果判断
        /// </summary>
        public void m_mhDeleteCheckItemCustomRes()
        {
            long lngRes = 0;
            clsLisCheckItemCustomRes m_objLisCheckItemCustomRes = (clsLisCheckItemCustomRes)m_objViewer.m_txtConditions.Tag;
            if (string.IsNullOrEmpty(m_objLisCheckItemCustomRes.m_strCheckItemID))
                return;
            lngRes = m_objDomain.m_lngDeleteCheckItemCustomRes(m_objLisCheckItemCustomRes);
            if (lngRes > 0)
            {
                int idx = m_objViewer.m_dgCheckItemResult.SelectedRows[0].Index;
                m_objViewer.m_dgCheckItemResult.Rows.RemoveAt(idx);
            }
        }
        #endregion

        #region 获取自定义项目的发送命令
        /// <summary>
        /// 获取自定义项目的发送命令
        /// </summary>
        /// <param name="p_strCheckItemID"></param>
        /// <param name="p_objCheckItemCustomOrderVO"></param>
        /// <returns></returns>
        public long m_lngQueryChcekItemCustomOrder(string p_strCheckItemID, out clsLisCheckItemCustomOrder p_objCheckItemCustomOrderVO)
        {
            p_objCheckItemCustomOrderVO = null;
            long lngRes = 0;
            lngRes = new clsDomainController_MK3DeviceCommunications().m_lngQueryChcekItemCustomOrder(p_strCheckItemID, out p_objCheckItemCustomOrderVO);
            return lngRes;
        }
        #endregion

    }
}
