using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.LIS
{
    public partial class frmMK3ItemSet :com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 变量
        /// <summary>
        /// MK3酶标仪控制层
        /// </summary>
        clsCtl_MK3ItemSet m_objController;
        internal string m_strCheckItemID;
        #endregion

        #region  创建控制层
        public override void CreateController()
        {
            m_objController = new clsCtl_MK3ItemSet();
            m_objController.Set_GUI_Apperance(this);
            objController = m_objController;
        }
        #endregion

        #region 构造函数
        public frmMK3ItemSet()
        {
            InitializeComponent();
        }
        #endregion

        private void frmMK3ItemSet_Load(object sender, EventArgs e)
        {
            
            m_mthInitDataGridview();
            m_dgCheckItemCustom.AutoGenerateColumns = false;
            m_dgCheckItemResult.AutoGenerateColumns = false;
            m_dgCheckItemResult.AllowUserToAddRows = false;
            m_dgCheckItemCustom.AllowUserToAddRows = false;
            m_txtNo.Text = "1";
            m_cboResult.SelectedIndex = 0;
            string m_strDeviceModelID = null;
            try
            {
                string strConfigFilePath = Application.StartupPath + "\\MK3.config";
                System.Configuration.ConfigXmlDocument appConfig = new System.Configuration.ConfigXmlDocument();
                appConfig.Load(strConfigFilePath);
                m_strDeviceModelID = appConfig["configuration"]["appSettings"].SelectSingleNode("add[@key=\"strDeviceModelID\"]").Attributes["value"].Value.Trim();
            }
            catch
            {
                MessageBox.Show("初始化失败！,请重新启动", "酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            m_objController.m_mthGetAllCheckItem(m_strDeviceModelID);
        }

       

        #region 填充m_dgCheckItemCustom控件
        /// <summary>
        /// 填充m_dgCheckItemCustom控件
        /// </summary>
        private void m_mthInitDataGridview()
        {
            clsLisCheckItemCustom[] objCheckItemCustomVO = null;
            long lngRes = 0;
            DataTable m_dtResult = null;
            lngRes = m_objController.m_lngGetAllCheckItemCustomInfo(out objCheckItemCustomVO, out m_dtResult);
            if (lngRes > 0 && objCheckItemCustomVO != null)
            {
                //m_dgCheckItemCustom.RowsAdded -= new DataGridViewRowsAddedEventHandler(m_dgCheckItemCustom_RowsAdded);
                for (int i = 0; i < objCheckItemCustomVO.Length; i++)
                {
                    m_dgCheckItemCustom.Rows.Add(new object[] {objCheckItemCustomVO[i].m_strCheckItemName,objCheckItemCustomVO[i].m_strPosMaxValue,objCheckItemCustomVO[i].m_strPosMinValue,
                    objCheckItemCustomVO[i].m_strNegMaxValue,objCheckItemCustomVO[i].m_strNegMinValue,objCheckItemCustomVO[i].m_strformula,objCheckItemCustomVO[i].m_strSeq_chr,
                     objCheckItemCustomVO[i].m_strQc_Neg_Maxvalue_vchr,objCheckItemCustomVO[i].m_strQc_Neg_Minvalue_vchr,objCheckItemCustomVO[i].m_strQc_Pos_Maxvalue_vchr
                    ,objCheckItemCustomVO[i].m_strQc_Pos_Minvalue_vchr, objCheckItemCustomVO[i].m_strQCFormula_vchr,objCheckItemCustomVO[i].m_strQc_Result_vchr,objCheckItemCustomVO[i].m_strMore_Neg_Formula_vchr,
                        objCheckItemCustomVO[i].m_strMore_Pos_Formula_vchr,objCheckItemCustomVO[i].m_strQc_Neg_Formula_vchr,objCheckItemCustomVO[i].m_strQc_Pos_Formula_vchr, objCheckItemCustomVO[i].m_strCheckItemID,objCheckItemCustomVO[i]});
                }
                m_dgCheckItemCustom.RowsAdded += new DataGridViewRowsAddedEventHandler(m_dgCheckItemCustom_RowsAdded);
            }
        }

        void m_dgCheckItemCustom_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int idx = e.RowIndex;
            m_dgCheckItemCustom.Rows[idx].Selected = true;
        }
        #endregion


        

        private void m_dgCheckItemCustom_SelectionChanged(object sender, EventArgs e)
        {
            if (m_dgCheckItemCustom.SelectedRows.Count <= 0)
                return;
            clsLisCheckItemCustom objCheckItemCustomVO = (clsLisCheckItemCustom)m_dgCheckItemCustom.SelectedRows[0].Cells["Tag"].Value;
            clsCheckItem_VO objCheckItemVO = new clsCheckItem_VO();
            m_strCheckItemID = objCheckItemCustomVO.m_strCheckItemID;
            m_cboDeviceCheckItem.SelectedValue = objCheckItemCustomVO.m_strCheckItemID;
            m_txtPCMaxValue.Text= objCheckItemCustomVO.m_strPosMaxValue;
            m_txtPCMinValue.Text= objCheckItemCustomVO.m_strPosMinValue;
            m_txtNCMaxValue.Text= objCheckItemCustomVO.m_strNegMaxValue;
            m_txtNCMinValue.Text= objCheckItemCustomVO.m_strNegMinValue;
            m_txtSeq.Text = objCheckItemCustomVO.m_strSeq_chr;
            m_txtCOFormula.Text = objCheckItemCustomVO.m_strQCFormula_vchr;
            m_txtCutoff.Text = objCheckItemCustomVO.m_strformula;
            m_txtCutoff.Tag = objCheckItemCustomVO;
            m_txtColor.BackColor = Color.FromArgb(255, 255, 255);
            m_txtQCNCMaxValue.Text = objCheckItemCustomVO.m_strQc_Neg_Maxvalue_vchr;
            m_txtQCNCMinvalue.Text = objCheckItemCustomVO.m_strQc_Neg_Minvalue_vchr;
            m_txtQCPCMaxvalue.Text = objCheckItemCustomVO.m_strQc_Pos_Maxvalue_vchr;
            m_txtQCPCMinvalue.Text = objCheckItemCustomVO.m_strQc_Pos_Minvalue_vchr;
            m_txtQCResultFromula.Text = objCheckItemCustomVO.m_strQc_Result_vchr;
            string[] m_strColorArr = objCheckItemCustomVO.m_strColor.Split(new char[] { ':', '\r', '\n' });
            if (m_strColorArr != null)
            {
                if (m_strColorArr.Length == 3)
                {
                    
                    int iR = Convert.ToInt32(m_strColorArr[0]);
                    int iG = Convert.ToInt32(m_strColorArr[1]);
                    int iB = Convert.ToInt32(m_strColorArr[2]);
                    m_txtColor.BackColor = Color.FromArgb(iR, iG, iB);
                }
            }
            m_txtNo.Text = "1";
            m_txtMorePCFormula.Text = objCheckItemCustomVO.m_strMore_Pos_Formula_vchr;
            m_txtMoreNCFormula.Text = objCheckItemCustomVO.m_strMore_Neg_Formula_vchr;
            m_txtQCNCFormula.Text = objCheckItemCustomVO.m_strQc_Neg_Formula_vchr;
            m_txtQCPCFormula.Text = objCheckItemCustomVO.m_strQc_Pos_Formula_vchr;
            m_objController.m_mthGetCheckItemCustomRes();
        }

        private void m_btnAddCheckItem_Click(object sender, EventArgs e)
        {
            int intMaxValue = 0;
            int intValue = 0;
            int intMinValue = 0;
            for (int i = 0; i <m_dgCheckItemCustom.Rows.Count; i++)
            {
                try
                {
                    intValue = Convert.ToInt32(m_dgCheckItemCustom.Rows[i].Cells["m_chNum"].Value.ToString().Trim());
                    if (intMinValue < intValue)
                    {
                        intMaxValue = intValue;
                    }
                    else
                    {
                        intMaxValue = intMinValue;
                    }
                    intMinValue = intValue;
                }
                catch
                {
                    continue;
                }
                
            }
            intMaxValue++;
            m_txtSeq.Text = intMaxValue.ToString();
            m_txtQCNCMinvalue.Text = "";
            m_txtQCNCMaxValue.Text = "";
            m_txtQCPCMaxvalue.Text = "";
            m_txtQCPCMinvalue.Text = "";
            m_txtQCResultFromula.Text = "";
            m_txtCOFormula.Text = "";
            m_txtPCMaxValue.Text = "";
            m_txtPCMinValue.Text = "";
            m_txtNCMaxValue.Text = "";
            m_txtNCMinValue.Text = "";
            m_txtCutoff.Text = "";
            m_txtColor.BackColor = Color.Empty;
            m_txtCutoff.Tag = null;
            m_cboDeviceCheckItem.SelectedIndex = 0;
            m_txtMoreNCFormula.Text = "";
            m_txtMorePCFormula.Text = "";
        }

        private void m_btnUpdateCheckItem_Click(object sender, EventArgs e)
        {
            m_objController.m_mthOperationCheckItemCustom();
        }

        private void m_btnSaveCheckItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txtQCNCFormula.Text) || string.IsNullOrEmpty(m_txtQCPCFormula.Text)
                || string.IsNullOrEmpty(m_txtMoreNCFormula.Text) || string.IsNullOrEmpty(m_txtMorePCFormula.Text)
                || string.IsNullOrEmpty(m_txtCutoff.Text) || string.IsNullOrEmpty(m_txtCOFormula.Text) || string.IsNullOrEmpty(m_txtQCResultFromula.Text))
            {
                return;
            }
            m_objController.m_mthOperationCheckItemCustom();
        }

        private void m_btnDelCheckItem_Click(object sender, EventArgs e)
        {
            if (m_dgCheckItemResult.Rows.Count > 0)
            {
                MessageBox.Show(this, "请先删除实验结果判断", "MK3酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            long lngRes = 0;
            if (m_txtCutoff.Tag != null)
            {
                string strDeviceCheckItemID = m_cboDeviceCheckItem.SelectedValue.ToString();
                clsLisCheckItemCustomOrder objCheckItemCustomOrder = null;
                lngRes = m_objController.m_lngQueryChcekItemCustomOrder(strDeviceCheckItemID, out objCheckItemCustomOrder);
                if (lngRes > 0 && objCheckItemCustomOrder == null)
                {
                    m_objController.m_mthDeleteCheckItemCustom(strDeviceCheckItemID);
                }
                else
                {
                    MessageBox.Show(this, "请先删除设置的仪器发送命令", "MK3酶标仪操作提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void m_btnCheckItemResultAdd_Click(object sender, EventArgs e)
        {
            if (m_dgCheckItemResult.Rows.Count <= 0)
            {
                m_txtNo.Text = "1";
            }
            else
            {
                int intMaxValue = 0;
                int intValue = 0;
                int intMinValue = 0;
                for (int i = 0; i < m_dgCheckItemResult.Rows.Count; i++)
                {
                    intValue = Convert.ToInt32(m_dgCheckItemResult.Rows[i].Cells["m_chSeq"].Value.ToString().Trim());
                    if (intMinValue < intValue)
                    {
                        intMaxValue = intValue;
                    }
                    else
                    {
                        intMaxValue = intMinValue;
                    }
                    intMinValue = intValue;
                }
                intMaxValue++;
                m_txtNo.Text = intMaxValue.ToString();
            }
            m_txtConditions.Text = "";
            m_cboResult.SelectedIndex = 0;
            m_txtConditions.Tag = null;
        }

        private void m_btnCheckItemResultSave_Click(object sender, EventArgs e)
        {
            m_objController.m_mthOperationCheckItemCustomRes();
        }

        private void m_btnCheckItemResultUpdate_Click(object sender, EventArgs e)
        {
            m_objController.m_mthOperationCheckItemCustomRes();
        }

        private void m_btnCheckItemResultDel_Click(object sender, EventArgs e)
        {
            m_objController.m_mhDeleteCheckItemCustomRes();
        }

        private void m_dgCheckItemResult_SelectionChanged(object sender, EventArgs e)
        {
            m_txtConditions.Tag = null;
            if (m_dgCheckItemResult.SelectedRows.Count <= 0)
                return;
            clsLisCheckItemCustomRes m_objCheckItemCustomRes = (clsLisCheckItemCustomRes)m_dgCheckItemResult.SelectedRows[0].Cells["DataSource"].Value;
            m_txtNo.Text = m_objCheckItemCustomRes.m_strSeq;
            m_txtConditions.Text = m_objCheckItemCustomRes.m_strConditions;
            m_cboResult.Text = m_objCheckItemCustomRes.m_strResult;
            m_txtConditions.Tag = m_objCheckItemCustomRes;
        }

        private void m_txtColor_Click(object sender, EventArgs e)
        {
            if (m_cdColor.ShowDialog() == DialogResult.OK)
            {
                m_txtColor.BackColor = m_cdColor.Color;
            }
            
        }

        private void m_btnDeviceCommunications_Click(object sender, EventArgs e)
        {
            frmMK3DeviceCommunications frmAss = new frmMK3DeviceCommunications(m_strCheckItemID);
            frmAss.ShowDialog();
        }
    }
}