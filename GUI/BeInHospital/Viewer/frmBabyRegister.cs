using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// 修改住院信息
    /// </summary>
    public partial class frmBabyRegister : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        #region 字段
        /// <summary>
        /// 登记信息维护标志
        /// 0：新增；2修改；3：只读查询
        /// </summary>
        private int m_intStatus = 3;

        /// <summary>
        /// 病区名称
        /// </summary>
        private string m_strAreaName = string.Empty;

        /// <summary>
        /// 窗口标题
        /// </summary>
        private string m_strWinTitle = "婴儿登记";

        /// <summary>
        /// 婴儿入院号
        /// </summary>
        private string m_strInPatientID = string.Empty;


        #endregion //字段

        #region 属性
        internal string strAreaName
        {
            get
            {
                return m_strAreaName;
            }
            set
            {
                m_strAreaName = value;
            }
        }

        internal int intEditMode
        {
            get
            {
                return m_intStatus;
            }
            set
            {
                m_intStatus = value;

            }
        }
        #endregion //属性

        #region 构造
        public frmBabyRegister()
        {
            InitializeComponent();
        }
        #endregion


        #region 调焦
        private void frmBabyRegister_KeyDown(object sender, KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
        }
        #endregion

        #region 事件

        #region 窗体的Load事件
        private void frmBabyRegister_Load(object sender, EventArgs e)
        {
            //初始化数据
            ((clsCtl_BabyRegister)objController).m_mthInit();
        }
        #endregion //窗体的Load事件

        #region 病区事件
        private void m_txtArea_m_evtInitListView(System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_BabyRegister)this.objController).m_txtAreaInitListView(lvwList);
        }

        private void m_txtArea_m_evtFindItem(object sender, string strFindCode, System.Windows.Forms.ListView lvwList)
        {
            ((clsCtl_BabyRegister)this.objController).m_txtAreaFindItem(strFindCode, lvwList);
        }

        private void m_txtArea_m_evtSelectItem(object sender, System.Windows.Forms.ListViewItem lviSelected)
        {
            ((clsCtl_BabyRegister)this.objController).m_txtAreaSelectItem(lviSelected);
        }
        #endregion //病区事件

        #region 床位号事件

        private void m_txtBedNo2_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            ((clsCtl_BabyRegister)this.objController).m_txtBedNo2FindItem(strFindCode, lvwList);
        }

        private void m_txtBedNo2_m_evtInitListView(ListView lvwList)
        {
            ((clsCtl_BabyRegister)this.objController).m_txtBedNo2InitListView(lvwList);


        }

        private void m_txtBedNo2_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            ((clsCtl_BabyRegister)this.objController).m_txtBedNo2SelectItem(lviSelected);
        }
        #endregion //床位号事件

        #region 查询按钮的Click事件
        private void m_cmdfind_Click(object sender, EventArgs e)
        {
            //根据入院登记ID获取病人住院信息
            ((clsCtl_BabyRegister)objController).m_mthGetBIHPatientInfo();
        }
        #endregion //查询按钮的Click事件



        #region 保存按钮的Click事件
        /// <summary>
        /// 保存按钮的Click事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            switch (intEditMode)
            {
                case 0:
                    {
                        //新增婴儿入院登记
                        ((clsCtl_BabyRegister)objController).m_mthBabyRegister();
                        break;
                    }
                case 2:
                    {
                        //修改婴儿入院登记
                        ((clsCtl_BabyRegister)objController).m_mthChangeBabyRegister();
                        break;
                    }
            }

            m_txtArea.Focus();
    
        }
        #endregion

        #region 退出
        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion //事件

        #region 方法

        #region 设置窗体控制器
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_BabyRegister();
            objController.Set_GUI_Apperance(this);
        }
        #endregion


        #region 显示窗体
        /// <summary>
        /// 显示窗体
        /// </summary>
        public void ShowDialogByNur(string p_strEditMode)
        {
            this.m_lblArea.Visible = true;
            this.m_lblBedNo.Visible = true;
            this.m_txtArea.Visible = true;
            this.m_txtBedNo2.Visible = true;

            m_cmdfind.Visible = true;
            intEditMode = Convert.ToInt32(p_strEditMode);
            if (intEditMode == 0)
            {
                this.Text = m_strWinTitle + "-新增";
                m_cmdSave.Text = "保存(&S)";
            }
            else
            {
                this.Text = m_strWinTitle + "-修改";
                m_cmdSave.Text = "修改(&S)";
            }
            this.ShowDialog();
        }
                #endregion //显示窗体

        private void m_txtArea_Leave(object sender, EventArgs e)
        {
            //m_txtArea.Text = strAreaName;
        }

        #endregion //方法


        private void m_txtBabyName_m_evtInitListView(ListView lvwList)
        {
            ((clsCtl_BabyRegister)objController).m_txtBabyNameInitListView(lvwList);
        }

        private void m_txtBabyName_m_evtSelectItem(object sender, ListViewItem lviSelected)
        {
            if (((clsCtl_BabyRegister)objController).m_objPatientInfoArr.Length > 0)
            {
                if (m_txtBabyName.Text.Trim().Length > 0)
                {
                    ((clsCtl_BabyRegister)objController).m_objPatientInfoArr[lviSelected.Index].m_strLASTNAME_VCHR = m_txtBabyName.Text.Trim();
                }
                else
                {
                    MessageBox.Show("婴儿姓名不能为空！", "婴儿登记", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m_txtBabyName.Text = ((clsCtl_BabyRegister)objController).m_objPatientInfoArr[lviSelected.Index].m_strLASTNAME_VCHR;
                    m_txtBabyName.Focus();
                    return;
                }
            }

            ((clsCtl_BabyRegister)objController).m_txtBabyNameSelectItem(lviSelected);
        }

        private void m_txtBabyName_m_evtFindItem(object sender, string strFindCode, ListView lvwList)
        {
            ((clsCtl_BabyRegister)this.objController).m_txtBabyNameFindItem(strFindCode, lvwList);
        }


        private void m_cmbBabyOrder_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        private void m_cmbBabyOrder_Leave(object sender, EventArgs e)
        {
            //m_txtBabyName.Text = string.Empty;
            //m_txtBabyName.Tag = null;
            //m_cmBabySex.SelectedIndex = 0;
            //if (m_cmdBabyPayType.Items.Count > 0)
            //{
            //    m_cmdBabyPayType.SelectedIndex = 0;
            //}
            //m_datBabyBrithday.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            ////获取婴儿入院登记信息
            //((clsCtl_BabyRegister)objController).m_mthGetBabyInfo();
            //((clsCtl_BabyRegister)objController).m_mthSetBabyInfo(0);

        }

        private void m_cmbBabyOrder_SelectionChangeCommitted(object sender, EventArgs e)
        {
            m_txtBabyName.Text = string.Empty;
            m_txtBabyName.Tag = null;
            m_cmBabySex.SelectedIndex = 0;
            if (m_cmdBabyPayType.Items.Count > 0)
            {
                m_cmdBabyPayType.SelectedIndex = 0;
            }
            m_datBabyBrithday.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            //获取婴儿入院登记信息
            ((clsCtl_BabyRegister)objController).m_mthGetBabyInfo();
            ((clsCtl_BabyRegister)objController).m_mthSetBabyInfo(0);

        }





    }
}