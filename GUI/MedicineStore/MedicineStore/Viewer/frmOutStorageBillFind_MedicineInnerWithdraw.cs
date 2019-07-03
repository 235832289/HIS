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
    public partial class frmOutStorageBillFind_MedicineInnerWithdraw : com.digitalwave.GUI_Base.frmMDI_Child_Base
    {
        #region 字段

        /// <summary>
        /// 仓库ID
        /// </summary>
        internal string m_strStorageID = string.Empty;

        /// <summary>
        /// 下一个获得焦点的控件
        /// </summary>
        Control m_ctlNext = null;
        /// <summary>
        /// 参与跳转的控件数组
        /// </summary>
        private Control[] m_ctlControls = null;
        /// <summary>
        /// 控件激活标志
        /// </summary>
        private bool m_CtlActivate = false;

        /// <summary>
        ///  药典查询控件
        /// </summary>
        private ctlQueryMedicintLeastElement m_ctlQueryMedicint = null;

        /// <summary>
        /// 药品基本信息
        /// </summary>
        private clsValue_MedicineBse_VO m_objMedicineBase = new clsValue_MedicineBse_VO();

        /// <summary>
        /// 药典数据表
        /// </summary>
        internal DataTable m_dtbMedicinDict = null;

        /// <summary>
        /// 出库明细表DataGridView
        /// </summary>
        private com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab m_dgvOutStorageBill = null;
        /// <summary>
        /// 药品代码
        /// </summary>
        private string m_strMedicineID = string.Empty;

        /// <summary>
        /// 药品批号
        /// </summary>
        private string m_strLotno_vchr = string.Empty;

        #endregion
        #region 构造函数
        public frmOutStorageBillFind_MedicineInnerWithdraw()
        {
            InitializeComponent();

            //m_ctlControls = new Control[] {
            //    m_txtMedicineName,
            //    m_txtLotNo};
            //m_mthSetNextControl(ref m_ctlControls);

            //m_mthSetControlHighLight();

        }

        public frmOutStorageBillFind_MedicineInnerWithdraw(string p_strStorageID):this()
        {
            m_strStorageID = p_strStorageID;
        }
        #endregion

        #region 方法

        internal void m_mthShowFrmFind(ref com.digitalwave.controls.MedicineStoreControls.ctlDataGridView_EnterAsTab p_dgvOutStorageBill)
        {
            m_dgvOutStorageBill = p_dgvOutStorageBill;
            this.ShowDialog();
        }

        /// <summary>
        /// 设置下一个焦点控件
        /// </summary>
        internal void m_mthSetNextControl(ref Control[] p_ctlControls)
        {
            if (p_ctlControls == null)
            {
                return;
            }

            for (int iCtl = 0; iCtl < p_ctlControls.Length; iCtl++)
            {
                p_ctlControls[iCtl].Enter += new EventHandler(clsCtl_Public_Enter);
            }
        }

        /// <summary>
        /// 设定当前控件的下一个控件
        /// </summary>
        /// <param name="sender"></param>
        private void clsCtl_Public_Enter(object sender, EventArgs e)
        {
            int ctlIndex;
            for (ctlIndex = 0; ctlIndex < m_ctlControls.Length; ctlIndex++)
            {
                if ((m_ctlControls[ctlIndex].Name == "m_txtMedicineName"))
                {
                    m_CtlActivate = true;
                }
                else
                    m_CtlActivate = false;

                if (m_ctlControls[ctlIndex].Name == (sender as Control).Name)
                    break;
            }

            //if (ctlIndex == m_ctlControls.Length - 1)
            //    //m_ctlNext = m_dtpSearchBeginDate;
            //else
            //    m_ctlNext = m_ctlControls[ctlIndex + 1];

        }

        /// <summary>
        /// 设置活动控件背景高亮
        /// </summary>
        private void m_mthSetControlHighLight()
        {
            clsCtl_Public objCtl = new clsCtl_Public();
            objCtl.m_mthSetControlHighLight(groupBox1, Color.Moccasin);
            objCtl.m_mthSelectAllText(groupBox1);
        }


        /// <summary>
        /// 在药品框中按回车键后，显示药典查询窗口
        /// </summary>
        private void m_mthPopupWindow()
        {
            if ((m_dtbMedicinDict != null) && (m_dtbMedicinDict.Rows.Count > 0))
            {
                m_mthShowQueryMedicineForm(m_txtMedicineName.Text.Trim());
            }
        }

        /// <summary>
        /// 显示药品字典最小元素信息查询窗体
        /// </summary>
        /// <param name="p_strSearchCon">查询条件</param>
        internal void m_mthShowQueryMedicineForm(string p_strSearchCon)
        {
            if (m_ctlQueryMedicint == null)
            {
                m_ctlQueryMedicint = new ctlQueryMedicintLeastElement(m_dtbMedicinDict);
                this.Controls.Add(m_ctlQueryMedicint);

                int X = 10;
                int Y = 5;
                //int Y = groupBox1.Location.Y + m_txtMedicineName.Location.Y + m_txtMedicineName.Height;
                m_ctlQueryMedicint.Height = this.Height - 40;

                m_ctlQueryMedicint.Location = new System.Drawing.Point(X, Y);

                m_ctlQueryMedicint.ReturnInfo += new ReturnMedicineInfo(m_mthReturnInfo);

            }

            m_ctlQueryMedicint.Visible = true;


            m_ctlQueryMedicint.BringToFront();
            m_ctlQueryMedicint.Focus();
            m_ctlQueryMedicint.m_mthSetSearchText(p_strSearchCon);
        }

        internal void m_mthReturnInfo(com.digitalwave.iCare.ValueObject.clsMS_MedicintLeastElement_VO MS_VO)
        {
            if (MS_VO == null)
            {
                m_txtMedicineName.Text = string.Empty;

                m_objMedicineBase.m_strMedicineID = string.Empty;
                m_objMedicineBase.m_strAssistCode = string.Empty;
                m_objMedicineBase.m_strMedicineName = string.Empty;
                m_objMedicineBase.m_strMedSpec = string.Empty;
                return;
            }
            m_txtMedicineName.Text = MS_VO.m_strMedicineName;

            m_strMedicineID = MS_VO.m_strMedicineID;

            m_txtLotNo.Focus();
        }

        #endregion

        private void m_txtMedicineName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_mthPopupWindow();
            }

        }

        private void frmOutStorageBillFind_MedicineInnerWithdraw_Load(object sender, EventArgs e)
        {
            clsDcl_InMedicineWithdraw objDomain = new clsDcl_InMedicineWithdraw();

            //调用Com+服务端
            m_dtbMedicinDict = null;
            long lngRes = objDomain.m_lngGetBaseMedicine("", m_strStorageID, out  m_dtbMedicinDict);

        }

        private void frmOutStorageBillFind_MedicineInnerWithdraw_Shown(object sender, EventArgs e)
        {
            m_txtMedicineName.Focus();
        }

        private void m_txtLotNo_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
                m_cmdFind.Focus();
        }

        private void m_cmdFind_Click(object sender, EventArgs e)
        {
            m_mthFindRec();
            Close();
        }

        private void m_mthFindRec()
        {
            DataTable dtbOutStorageDetail = m_dgvOutStorageBill.DataSource as DataTable;
            DataRow drCurrRow = null;
            m_strLotno_vchr = m_txtLotNo.Text.Trim();
            if ((dtbOutStorageDetail != null) && (dtbOutStorageDetail.Rows.Count > 0))
            {
                if (m_strMedicineID.Trim().Length == 0)
                {
                    MessageBox.Show("请输入药品代码");
                    m_txtMedicineName.Focus();
                }
                else
                {

                    for (int i1 = 0; i1 < dtbOutStorageDetail.Rows.Count; i1++)
                    {
                        drCurrRow = dtbOutStorageDetail.Rows[i1];
                        if (m_strLotno_vchr.Length > 0)
                        {
                            if ((m_strMedicineID == drCurrRow["MEDICINEID_CHR"].ToString().Trim())
                                && (m_strLotno_vchr == drCurrRow["LOTNO_VCHR"].ToString().Trim()))
                            {
                                m_dgvOutStorageBill.CurrentCell = m_dgvOutStorageBill[7, i1];
                                //m_dgvOutStorageBill.Focus();
                                if (Convert.ToDecimal(drCurrRow["AvailAmount"].ToString()) > 0)
                                    m_mthSetCellColor(i1, Color.Blue);
                                continue;

                            }

                        }
                        else
                        {
                            if (m_strMedicineID == drCurrRow["MEDICINEID_CHR"].ToString().Trim())
                            {

                                m_dgvOutStorageBill.CurrentCell = m_dgvOutStorageBill[7, i1];
                                if (Convert.ToDecimal(drCurrRow["AvailAmount"].ToString()) > 0)
                                    m_mthSetCellColor(i1, Color.Blue);
                                continue;
                            }

                        }
                        if (Convert.ToDecimal(drCurrRow["AvailAmount"].ToString()) <= 0)
                        {
                            m_mthSetCellColor(i1, Color.Red);
                        }
                        else
                        {
                            m_mthSetCellColor(i1, Color.Black);
                        }


                    }//for
                }//if
            }
        }

        private void m_mthSetCellColor(int p_intRowIndex, Color p_cellColor)
        {
            for (int i1 = 0; i1 < m_dgvOutStorageBill.ColumnCount; i1++)
            {
                m_dgvOutStorageBill.Rows[p_intRowIndex].Cells[i1].Style.ForeColor = p_cellColor;
            }

        }

        private void m_cmdQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}