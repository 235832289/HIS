using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// �޸�סԺ��Ϣ
    /// </summary>
    public partial class frmBabyRegister : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        #region �ֶ�
        /// <summary>
        /// �Ǽ���Ϣά����־
        /// 0��������2�޸ģ�3��ֻ����ѯ
        /// </summary>
        private int m_intStatus = 3;

        /// <summary>
        /// ��������
        /// </summary>
        private string m_strAreaName = string.Empty;

        /// <summary>
        /// ���ڱ���
        /// </summary>
        private string m_strWinTitle = "Ӥ���Ǽ�";

        /// <summary>
        /// Ӥ����Ժ��
        /// </summary>
        private string m_strInPatientID = string.Empty;


        #endregion //�ֶ�

        #region ����
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
        #endregion //����

        #region ����
        public frmBabyRegister()
        {
            InitializeComponent();
        }
        #endregion


        #region ����
        private void frmBabyRegister_KeyDown(object sender, KeyEventArgs e)
        {
            m_mthSetKeyTab(e);
        }
        #endregion

        #region �¼�

        #region �����Load�¼�
        private void frmBabyRegister_Load(object sender, EventArgs e)
        {
            //��ʼ������
            ((clsCtl_BabyRegister)objController).m_mthInit();
        }
        #endregion //�����Load�¼�

        #region �����¼�
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
        #endregion //�����¼�

        #region ��λ���¼�

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
        #endregion //��λ���¼�

        #region ��ѯ��ť��Click�¼�
        private void m_cmdfind_Click(object sender, EventArgs e)
        {
            //������Ժ�Ǽ�ID��ȡ����סԺ��Ϣ
            ((clsCtl_BabyRegister)objController).m_mthGetBIHPatientInfo();
        }
        #endregion //��ѯ��ť��Click�¼�



        #region ���水ť��Click�¼�
        /// <summary>
        /// ���水ť��Click�¼�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void m_cmdSave_Click(object sender, EventArgs e)
        {
            switch (intEditMode)
            {
                case 0:
                    {
                        //����Ӥ����Ժ�Ǽ�
                        ((clsCtl_BabyRegister)objController).m_mthBabyRegister();
                        break;
                    }
                case 2:
                    {
                        //�޸�Ӥ����Ժ�Ǽ�
                        ((clsCtl_BabyRegister)objController).m_mthChangeBabyRegister();
                        break;
                    }
            }

            m_txtArea.Focus();
    
        }
        #endregion

        #region �˳�
        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #endregion //�¼�

        #region ����

        #region ���ô��������
        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_BabyRegister();
            objController.Set_GUI_Apperance(this);
        }
        #endregion


        #region ��ʾ����
        /// <summary>
        /// ��ʾ����
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
                this.Text = m_strWinTitle + "-����";
                m_cmdSave.Text = "����(&S)";
            }
            else
            {
                this.Text = m_strWinTitle + "-�޸�";
                m_cmdSave.Text = "�޸�(&S)";
            }
            this.ShowDialog();
        }
                #endregion //��ʾ����

        private void m_txtArea_Leave(object sender, EventArgs e)
        {
            //m_txtArea.Text = strAreaName;
        }

        #endregion //����


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
                    MessageBox.Show("Ӥ����������Ϊ�գ�", "Ӥ���Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            ////��ȡӤ����Ժ�Ǽ���Ϣ
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
            //��ȡӤ����Ժ�Ǽ���Ϣ
            ((clsCtl_BabyRegister)objController).m_mthGetBabyInfo();
            ((clsCtl_BabyRegister)objController).m_mthSetBabyInfo(0);

        }





    }
}