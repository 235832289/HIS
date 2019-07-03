using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.MedicineStore
{
    /// <summary>
    /// 包装/单位换算
    /// </summary>
    public partial class frmPackConversion : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        /// <summary>
        /// 基本单位
        /// </summary>
        private string m_strUnit = string.Empty;
        /// <summary>
        /// 包装/基本单位换算VO
        /// </summary>
        internal clsMS_PackConversion_VO m_objPC_VO = null;

        /// <summary>
        /// 包装/基本单位换算
        /// </summary>
        private frmPackConversion()
        {
            InitializeComponent();
            m_mthInitJumpControls();
        }

        /// <summary>
        /// 包装/基本单位换算
        /// </summary>
        /// <param name="p_strUnit">基本单位</param>
        /// <param name="p_strMedicineID">当前药品ID</param>
        public frmPackConversion(string p_strUnit, string p_strMedicineID) : this()
        {
            m_strUnit = p_strUnit;

            label4.Text = string.Format(label4.Text, m_strUnit);

            m_bgwGetPrice.RunWorkerAsync(p_strMedicineID);
        }

        #region 控件跳转
        /// <summary>
        /// 控件跳转
        /// </summary>
        private void m_mthInitJumpControls()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthJumpControl(this, new Control[] { m_txtPackAmount, m_txtPackUnit, m_txtConversion, m_txtPackPrice, m_cmdOK }, Keys.Enter, false);
        } 
        #endregion

        #region 从界面获取换算VO
        /// <summary>
        /// 从界面获取换算VO
        /// </summary>
        /// <returns></returns>
        private clsMS_PackConversion_VO m_objGetPCVO()
        {
            clsMS_PackConversion_VO objVO = new clsMS_PackConversion_VO();

            double dblTemp = 0d;
            if (!double.TryParse(m_txtPackAmount.Text, out dblTemp))
            {
                MessageBox.Show("包装数量为必填项且必须为数字", "换算", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtPackAmount.Focus();
                return null;
            }

            if (dblTemp <= 0)
            {
                 MessageBox.Show("包装数量必须大于零", "换算", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtPackAmount.Focus();
                return null;
            }
            objVO.m_dblPackAmount = Convert.ToDouble(dblTemp.ToString("0.00"));

            if (string.IsNullOrEmpty(m_txtPackUnit.Text))
            {
                MessageBox.Show("必须填写包装单位", "换算", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtPackUnit.Focus();
                return null;
            }
            else
            {
                objVO.m_strPackUnit = m_txtPackUnit.Text;
            }

            if (!double.TryParse(m_txtConversion.Text, out dblTemp))
            {
                MessageBox.Show("包装量为必填项且必须为数字", "换算", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtConversion.Focus();
                return null;
            }
            if (dblTemp <= 0)
            {
                MessageBox.Show("包装量必须大于零", "换算", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtConversion.Focus();
                return null;
            }
            objVO.m_dblPackConvert = Convert.ToDouble(dblTemp.ToString("0.00"));

            decimal dcmPrice = 0m;
            if (!decimal.TryParse(m_txtPackPrice.Text, out dcmPrice))
            {
                MessageBox.Show("购入单价为必填项且必须为数字", "换算", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtPackPrice.Focus();
                return null;
            }
            if (dcmPrice <= 0)
            {
                 MessageBox.Show("购入单价必须大于零", "换算", MessageBoxButtons.OK, MessageBoxIcon.Error);
                m_txtPackPrice.Focus();
                return null;
            }
            objVO.m_dcmPackPrice = Convert.ToDecimal(dcmPrice.ToString("0.0000"));

            objVO.m_strUnit = m_strUnit;
            return objVO;
        } 
        #endregion

        #region 设置转换VO至界面
        /// <summary>
        /// 设置转换VO至界面
        /// </summary>
        /// <param name="p_objPCVO">转换VO</param>
        internal void m_mthSetPCVOToUI(clsMS_PackConversion_VO p_objPCVO)
        {
            if (p_objPCVO == null)
            {
                return;
            }

            m_txtPackAmount.Text = p_objPCVO.m_dblPackAmount.ToString();
            m_txtPackUnit.Text = p_objPCVO.m_strPackUnit;
            m_txtConversion.Text = p_objPCVO.m_dblPackConvert.ToString();
            m_txtPackPrice.Text = p_objPCVO.m_dcmPackPrice.ToString();
        } 
        #endregion

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            m_objPC_VO = m_objGetPCVO();
            if (m_objPC_VO == null)
            {
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void m_bgwGetPrice_DoWork(object sender, DoWorkEventArgs e)
        {
            string strMedicineID = e.Argument as string;
            if (strMedicineID == null)
            {
        		 return;
            }

            decimal dcmPackBuyInPrice = 0m;
            clsDcl_Purchase_Detail objDomain = new clsDcl_Purchase_Detail();
            long lngRes = objDomain.m_lngGetLatestPackBuyInPrice(strMedicineID, out dcmPackBuyInPrice);

            e.Result = dcmPackBuyInPrice;
        }

        private void m_bgwGetPrice_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                decimal dcmPackBuyInPrice = Convert.ToDecimal(e.Result);
                if (dcmPackBuyInPrice > 0)
                {
                    m_txtPackPrice.Text = dcmPackBuyInPrice.ToString("0.0000");
                }
            }
            catch (Exception)
            {
                
                throw;
            }            
        }
    }
}