using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ���סԺ��
    /// </summary>
    public partial class CreateInpatientNo : com.digitalwave.GUI_Base.frmMDI_Child_Base //GUI_Base.dll
    {
        /// <summary>
        /// סԺ��
        /// </summary>
        public string m_strInpatientid_chr = "";
        /// <summary>
        /// סԺ�ſ�ͷ��ĸ
        /// </summary>
        public string m_strHead = "";
        /// <summary>
        /// סԺ����������
        /// </summary>
        public string m_strMain = "";
        /// <summary>
        /// 1,���ֵ��Դ����ʷ��¼��2��Դ�����ֵ,0����
        /// </summary>
        public int m_intSour = 0;
        /// <summary>
        /// ��Ժ���ͱ�־1-������2-����
        /// </summary>
        public int m_intINPATIENTNOTYPE_INT = 1;

        /// <summary>
        /// ��Ժ�Ǽ�סԺ�����ɷ�ʽ 1 �Զ� 2 �ֶ�
        /// </summary>
        internal int m_intCreatNOFlag = 1;

        #region
        /// <summary>
        /// ���캯��
        /// </summary>
        public CreateInpatientNo()
        {
            InitializeComponent();
        }
        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="m_intInpatientnotype">1-��ͨ��2-����</param>
        public CreateInpatientNo(int m_intInpatientnotype)
        {
            InitializeComponent();
            this.m_intINPATIENTNOTYPE_INT = m_intInpatientnotype;
        }
        #endregion

        public override void CreateController()
        {
            this.objController = new com.digitalwave.iCare.gui.HIS.clsCtl_inpatientNoManager();
            objController.Set_GUI_Apperance(this);
        }

        private void cmdSaveBihRegister_Click(object sender, EventArgs e)
        {
            if (this.radioButton2.Checked)
            {
                if (textBox1.Text.Trim() == "")
                {
                    MessageBox.Show("סԺ�Ų���Ϊ�գ�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                    return;
                }
                long lng = ((clsCtl_inpatientNoManager)this.objController).m_lngGetBigPatientIDFree();
                if (lng < 0)
                {
                    MessageBox.Show("��ǰסԺ���ѱ�ռ�ã�", "��Ժ�Ǽ�", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                    return;
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        private void buttonXP1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string m_head;
            this.m_intINPATIENTNOTYPE_INT = 1;
            m_strGetInpatientid_chr(out m_head, out m_intSour);
            MessageBox.Show(m_strInpatientid_chr);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButton1.Checked)
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox1.ReadOnly = true;
            }
            else
            {
                this.textBox1.ReadOnly = false;
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            long m_lng = ((clsCtl_inpatientNoManager)this.objController).m_lngAddBigIDTableMax();
        }

        private void CreateInpatientNo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.Close();
                    break;
                default:
                    break;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            this.textBox2.Text = this.textBox2.Text.Trim().ToUpper();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSaveBihRegister.Focus();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (this.textBox2.Text.Trim().Length > 0)
            {
                this.textBox1.MaxLength = 5;
                if (this.textBox1.Text.Length > 5)
                    this.textBox1.Text = this.textBox1.Text.Trim().Substring(0, 5);
            }
            else
            {
                this.textBox1.MaxLength = 6;
            }
        }

        #region ����ӿ�
        /// <summary>
        /// ��ȡ��ԺסԺ��
        /// </summary>
        /// <param name="m_strhead2">����ͷ��ʶ</param>
        /// <param name="m_intSour2">����1,���ֵ��Դ����ʷ��¼��2��Դ�����ֵ,0����</param>
        /// <returns>������ԺסԺ��</returns>
        public string m_strGetInpatientid_chr(out string m_strhead2, out int m_intSour2)
        {
            if (this.radioButton1.Checked)
            {
                if (this.m_intINPATIENTNOTYPE_INT == 1)
                {
                    ((clsCtl_inpatientNoManager)this.objController).m_strGetInpatientNo();
                }
                else if (this.m_intINPATIENTNOTYPE_INT == 2)
                {
                    //m_strHead = this.textBox2.Text.Trim().Substring(0, 1);
                    ((clsCtl_inpatientNoManager)this.objController).m_strGetOthInpatientid_chr();
                }
            }
            else
            {
                m_strHead = this.textBox2.Text.Trim();
                m_strMain = this.textBox1.Text.Trim();
                long lng = ((clsCtl_inpatientNoManager)this.objController).m_lngGetBigPatientIDFree();
                if (lng <= 0)
                {
                    //MessageBox.Show("��ǰסԺ���ѱ�ռ��!");
                    // this.textBox1.Focus();
                    m_strhead2 = "";
                    m_intSour2 = 0;
                    return "";
                }
            }
            m_strhead2 = this.m_strHead.Trim();
            m_intSour2 = m_intSour;
            return m_strInpatientid_chr;
        }

        /// <summary>
        /// �޸����ֵ��
        /// </summary>
        public long m_strChangeTheBigTable()
        {
            long m_lng = ((clsCtl_inpatientNoManager)this.objController).m_lngAddBigIDTableMax();
            return m_lng;
        }
        #endregion

        private void CreateInpatientNo_Load(object sender, EventArgs e)
        {
            if (m_intINPATIENTNOTYPE_INT == 2)
            {
                textBox2.Text = "L";
            }

            if (m_intCreatNOFlag == 2)
            {
                this.radioButton2.Checked = true;
                this.radioButton1.Checked = false;
            }
            else
            {
                this.radioButton1.Checked = true;
                this.radioButton2.Checked = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this.m_strInpatientid_chr);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string m_head = "";
            this.m_intINPATIENTNOTYPE_INT = 2;
            m_strGetInpatientid_chr(out m_head, out m_intSour);
            MessageBox.Show(m_strInpatientid_chr);
        }

        private void radioButton1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cmdSaveBihRegister.Focus();
            }
        }

    }
}