using System;
using System.Collections.Generic;
using System.Text;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public  class clsCtl_MK3DeviceCommunications:com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        /// <summary>
        /// 仪器通讯Domain层
        /// </summary>
        clsDomainController_MK3DeviceCommunications m_objDomain;
        /// <summary>
        /// 仪器通讯Viewer层
        /// </summary>
        frmMK3DeviceCommunications m_objViewer;
        #endregion

        #region 设置界面层
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            m_objViewer = (frmMK3DeviceCommunications)frmMDI_Child_Base_in;
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
        }
        #endregion

        #region 构造函数
        public clsCtl_MK3DeviceCommunications()
        {
            m_objDomain = new clsDomainController_MK3DeviceCommunications();
        }
        #endregion

        #region 获取和设置自定义项目的发送命令
        /// <summary>
        /// 获取和设置自定义项目的发送命令
        /// </summary>
        public void m_mthGetCheckItemCustomOrder()
        {
            long lngRes = 0;
            clsLisCheckItemCustomOrder m_objCheckItemCustomOrder = null;
            lngRes = m_objDomain.m_lngQueryChcekItemCustomOrder(m_objViewer.m_strCheckItemID, out m_objCheckItemCustomOrder);
            if (lngRes > 0 && m_objCheckItemCustomOrder != null)
            {
                if (m_objCheckItemCustomOrder.m_strAir_blank == "0")
                {
                    m_objViewer.m_chAirBlank.Checked = false;
                }
                else
                {
                    m_objViewer.m_chAirBlank.Checked = true;
                }
                if (m_objCheckItemCustomOrder.m_strJin_plate_way_chr == "E0")
                {
                    m_objViewer.m_cboJinPlateWay.Text = "持续进板";
                }
                else
                {
                    m_objViewer.m_cboJinPlateWay.Text = "逐步进板";
                }
                switch (m_objCheckItemCustomOrder.m_strShock_speed_chr)
                {
                    case"X1":
                        m_objViewer.m_cboShockSpeed.Text = "快速震荡";
                        break;
                    case"X2":
                        m_objViewer.m_cboShockSpeed.Text = "中速震荡";
                        break;
                    case"X3":
                        m_objViewer.m_cboShockSpeed.Text = "慢速震荡";
                        break;

                }
                if (!string.IsNullOrEmpty(m_objCheckItemCustomOrder.m_strShock_time_chr))
                {
                    string m_strShockTime = m_objCheckItemCustomOrder.m_strShock_time_chr.Substring(1);
                    m_strShockTime = m_strShockTime.Trim();
                    m_objViewer.m_txtShockTime.Text = m_strShockTime;
                }
                if (m_objCheckItemCustomOrder.m_strWavelength_chr == "0")
                {
                    m_objViewer.m_chWavelength.Checked = false;
                }
                else
                {
                    m_objViewer.m_chWavelength.Checked = true;
                }
                if (!string.IsNullOrEmpty(m_objCheckItemCustomOrder.m_strFilter_chr))
                {
                    string m_strFilter = m_objCheckItemCustomOrder.m_strFilter_chr.Substring(1);
                    m_objViewer.m_cboFilter.Text = m_strFilter;
                }
                if (!string.IsNullOrEmpty(m_objCheckItemCustomOrder.m_strDeputy_filter_chr))
                {
                    string m_strDeputy_filter = m_objCheckItemCustomOrder.m_strDeputy_filter_chr.Substring(1);
                    m_objViewer.m_cboDeputyFilter.Text = m_strDeputy_filter;
                }
                m_objViewer.m_txtShockTime.Tag = m_objCheckItemCustomOrder;
            }
        }
        #endregion

        #region 添加或者修改发送给仪器的命令
        /// <summary>
        /// 添加或者修改发送给仪器的命令
        /// </summary>
        public void m_mthOperationCheckItemCustomOrder()
        {
            clsLisCheckItemCustomOrder m_objCheckItemCustomOrderVO = new clsLisCheckItemCustomOrder();
            if (m_objViewer.m_chAirBlank.Checked)
            {
                m_objCheckItemCustomOrderVO.m_strAir_blank = "1";
            }
            else
            {
                m_objCheckItemCustomOrderVO.m_strAir_blank = "0";
            }
            if (m_objViewer.m_cboJinPlateWay.Text == "持续进板")
            {
                m_objCheckItemCustomOrderVO.m_strJin_plate_way_chr = "E0";
            }
            else
            {
                m_objCheckItemCustomOrderVO.m_strJin_plate_way_chr = "E1";
            }
            if (m_objViewer.m_cboShockSpeed.Text == "快速震荡")
            {
                m_objCheckItemCustomOrderVO.m_strShock_speed_chr = "X1";
            }
            if (m_objViewer.m_cboShockSpeed.Text == "中速震荡")
            {
                m_objCheckItemCustomOrderVO.m_strShock_speed_chr = "X2";
            }
            if (m_objViewer.m_cboShockSpeed.Text == "慢速震荡")
            {
                m_objCheckItemCustomOrderVO.m_strShock_speed_chr = "X3";
            }
            int intShockTime;
            try
            {
                intShockTime = Convert.ToInt32(m_objViewer.m_txtShockTime.Text.Trim());
                if (intShockTime < 10)
                {
                    m_objCheckItemCustomOrderVO.m_strShock_time_chr = "Z" + "0" + intShockTime.ToString();
                }
                else
                {
                    m_objCheckItemCustomOrderVO.m_strShock_time_chr = "Z" + intShockTime.ToString();
                }
            }
            catch
            { }
            if (m_objViewer.m_chWavelength.Checked)
            {
                m_objCheckItemCustomOrderVO.m_strWavelength_chr = "1";
            }
            else
            {
                m_objCheckItemCustomOrderVO.m_strWavelength_chr = "0";
            }
            m_objCheckItemCustomOrderVO.m_strFilter_chr = "F" + m_objViewer.m_cboFilter.Text;
            m_objCheckItemCustomOrderVO.m_strDeputy_filter_chr = "F" + m_objViewer.m_cboDeputyFilter.Text;
            m_objCheckItemCustomOrderVO.m_strCheckItemID = m_objViewer.m_strCheckItemID;
            long lngRes = 0;
            if (m_objViewer.m_txtShockTime.Tag == null)
            {
                lngRes = m_objDomain.m_lngInsertCheckItemCustomOrder(m_objCheckItemCustomOrderVO);
            }
            else
            {
                lngRes = m_objDomain.m_lngUpdateChcekItemCustomOrder(m_objCheckItemCustomOrderVO);
            }
        }
        #endregion

        #region 删除自定义项目的命令
        /// <summary>
        /// 删除自定义项目的命令
        /// </summary>
        public void m_mthDeleteCheckItemCustomOrder()
        {
            long lngRes = 0;
            lngRes = m_objDomain.m_lngDeleteCheckItemCustomOrder(m_objViewer.m_strCheckItemID);
            if (lngRes > 0)
            {
                m_objViewer.m_chAirBlank.Checked = false;
                m_objViewer.m_cboJinPlateWay.Text = "";
                m_objViewer.m_cboShockSpeed.Text = "";
                m_objViewer.m_txtShockTime.Text = "";
                m_objViewer.m_chWavelength.Checked = false;
                m_objViewer.m_cboFilter.Text = "";
                m_objViewer.m_txtShockTime.Tag = null;
            }
        }
        #endregion
    }
}
