using System;
using System.Windows.Forms;
using System.Data;
using System.Drawing;

using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.Utility;
using com.digitalwave.iCare.gui.Security;

namespace com.digitalwave.iCare.gui.HIS
{
    class clsCtl_PATSPECREMARK : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ����
        com.digitalwave.iCare.gui.HIS.clsDcl_PATSPECREMARK m_objManager = null;
        /// <summary>
        /// ��ǰ���˵Ǽ���ˮ��
        /// </summary>
        public string m_strCurrentRegisterID = "";

        string m_strREMARK;

        string m_strDes;

        string m_strChargeCtl;

        #endregion

        #region ���캯��
        public clsCtl_PATSPECREMARK()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            m_objManager = new com.digitalwave.iCare.gui.HIS.clsDcl_PATSPECREMARK();
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmPATSPECREMARK m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmPATSPECREMARK)frmMDI_Child_Base_in;
        }
        #endregion



        internal void LoadData(string m_strRegisterID)
        {
            
            bindtheDataView();
            bindtheTextBox(m_strRegisterID);
           
        }

        public void bindtheTextBox(string m_strRegisterID)
        {
            clsSpecreMark_VO m_objSpecreMark_VO;
            long lngReg = m_objManager.m_lngGetPatientSPECREMARK(m_strRegisterID, out  m_objSpecreMark_VO);
           
            this.m_objViewer.m_txtREMARK.Tag = m_objSpecreMark_VO;
            this.m_objViewer.m_txtREMARK.Text = m_objSpecreMark_VO.m_strREMARKNAME_VCHR.Trim();
            //this.m_objViewer.m_txtDes.Text = m_objSpecreMark_VO.m_strDec_vchr.Trim();
            this.m_objViewer.m_txtDes.Text = this.m_objViewer.ucPatientInfo1.BihPatient_VO.Note;

            int chargeCtl = m_objSpecreMark_VO.m_intCHARGECTL_INT;
            if (chargeCtl == 1)
            {
                this.m_objViewer.m_ckbChargeCtl.Checked = true;
            }
            else
            {
                this.m_objViewer.m_ckbChargeCtl.Checked = false;
            }
        
            string m_strTemp= m_objSpecreMark_VO.m_strREMARKID_CHR.ToString().Trim();
            if (!m_strTemp.Equals(""))
            {
                for (int i = 0; i < this.m_objViewer.dataGridView1.RowCount; i++)
                {
                    if (this.m_objViewer.dataGridView1.Rows[i].Cells["REMARKID_CHR"].Value != null && this.m_objViewer.dataGridView1.Rows[i].Cells["REMARKID_CHR"].Value.ToString().Trim().Equals(m_strTemp))
                    {
                        this.m_objViewer.dataGridView1.Rows[i].Selected = true;
                        this.m_objViewer.dataGridView1.CurrentCell = this.m_objViewer.dataGridView1[0,i];
                    }
                }
            }

            this.m_strREMARK = this.m_objViewer.m_txtREMARK.Text.Trim();
            this.m_strDes = this.m_objViewer.m_txtDes.Text.Trim();
            if (this.m_objViewer.m_ckbChargeCtl.Checked == true)
            {
                this.m_strChargeCtl = "����Ƿ��";
            }
            else
            {
                this.m_strChargeCtl = "������Ƿ��";
            }
            
        }

        private void bindtheDataView()
        {
            this.m_objViewer.dataGridView1.Rows.Clear();

            DataTable m_dtSpcMessage = new DataTable();
            long lngReg = m_objManager.m_lngGetSPECREMARKMessage(out m_dtSpcMessage);
            //m_objViewer.dataGridView1.DataSource = m_dtSpcMessage;

            if (lngReg > 0 && m_dtSpcMessage.Rows.Count > 0)
            {
                foreach (DataRow dr in m_dtSpcMessage.Rows)
                {
                    string[] s = new string[6];

                    s[0] = dr["NO"].ToString();
                    s[1] = dr["REMARKID_CHR"].ToString();
                    s[2] = dr["REMARKNAME_VCHR"].ToString();
                    s[3] = dr["USERCODE_VCHR"].ToString();
                    s[4] = dr["CHARGECTL_INT"].ToString();

                    if (s[4] == "1")
                    {
                        s[5] = "��";
                    }
                    else
                    {
                        s[5] = "��";
                    }

                    int row = this.m_objViewer.dataGridView1.Rows.Add(s);
                    if (s[4] != "1")
                    {
                        this.m_objViewer.dataGridView1.Rows[row].DefaultCellStyle.BackColor = Color.YellowGreen;
                    }
                }

            }
            //m_objViewer.dataGridView1.CurrentCell = null;
            
        }

        /// <summary>
        /// �����ر�ע��
        /// </summary>
        internal void SaveData()
        {
            #region �ж�
            clsSpecreMark_VO Info_VO = null;
            long lngReg = m_objManager.m_lngGetPatientSPECREMARK(m_strCurrentRegisterID, out Info_VO);
            if (lngReg > 0)
            {
                if (this.m_objViewer.m_txtREMARK.Tag == null && Info_VO != null)
                {
                    MessageBox.Show("��ǰ���˵���ע��Ϣ�ѱ��޸ģ����˳�ϵͳ���µ�¼��", "����", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }
            #endregion

            clsSpecreMark_VO m_objSpecreMark_VO = new clsSpecreMark_VO();
            
            if (this.m_objViewer.m_txtREMARK.Tag != null)
            {
                m_objSpecreMark_VO = (clsSpecreMark_VO)this.m_objViewer.m_txtREMARK.Tag;
                if (m_objSpecreMark_VO.m_strSEQ_INT.ToString().Trim().Equals(""))
                {
                    m_objSpecreMark_VO.m_strCREATORID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
                    m_objSpecreMark_VO.m_strREMARKNAME_VCHR = this.m_objViewer.m_txtREMARK.Text.Trim();
                    m_objSpecreMark_VO.m_strREGISTERID_CHR = m_strCurrentRegisterID;
                    m_objSpecreMark_VO.m_strDec_vchr = this.m_objViewer.m_txtDes.Text.Trim();

                    if (this.m_objViewer.m_ckbChargeCtl.Checked == true)
                    {
                        m_objSpecreMark_VO.m_intCHARGECTL_INT = 1;
                    }
                    else
                    {
                        m_objSpecreMark_VO.m_intCHARGECTL_INT = 0;
                    }

                    if (m_objSpecreMark_VO.m_strREMARKID_CHR.ToString().Trim().Equals(""))
                    {
                        MessageBox.Show("����ѡ���ر�ע������!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        return;
                    }

                    if (m_objSpecreMark_VO.m_strREMARKNAME_VCHR.ToString().Trim().Equals(""))
                    {
                        MessageBox.Show("��ע���ݲ���Ϊ�գ�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        return;
                    }

                    lngReg = m_objManager.m_lngSaveNewPatientSPECREMARK(m_objSpecreMark_VO);
                    //m_objSpecreMark_VO.m_intSTATUS_INT = 1;
                    //m_objSpecreMark_VO.m_intCHARGECTL_INT = 0;
                    
                    //����䶯��־
                    SaveEditLog();
                }
                else
                {
                    m_objSpecreMark_VO.m_strREGISTERID_CHR = m_strCurrentRegisterID;
                    m_objSpecreMark_VO.m_strREMARKNAME_VCHR = this.m_objViewer.m_txtREMARK.Text.Trim();
                    m_objSpecreMark_VO.m_strDec_vchr = this.m_objViewer.m_txtDes.Text.Trim();

                    if (m_objSpecreMark_VO.m_strREMARKNAME_VCHR.ToString().Trim().Equals(""))
                    {
                        MessageBox.Show("��ע���ݲ���Ϊ�գ�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Question);

                        return;
                    }

                    if (this.m_objViewer.m_ckbChargeCtl.Checked == true)
                    {
                        m_objSpecreMark_VO.m_intCHARGECTL_INT = 1;
                    }
                    else
                    {
                        m_objSpecreMark_VO.m_intCHARGECTL_INT = 0;
                    }
                   
                    lngReg = m_objManager.m_lngSaveUpdatePatientSPECREMARK(m_objSpecreMark_VO);
                    
                    //����䶯��־
                    SaveEditLog();
                }
                if (lngReg > 0)
                {
                    MessageBox.Show("�����ɹ�!", "��ʾ��", MessageBoxButtons.OK,MessageBoxIcon.Information);
                    bindtheTextBox(m_strCurrentRegisterID);
                    //ˢ�������Ϣ
                    m_objViewer.ucPatientInfo1.m_mthFind(this.m_objViewer.zyh, 2);
                    m_strCurrentRegisterID = m_objViewer.ucPatientInfo1.RegisterID;
                    /*<===============================*/
                   
                }
               
            }
        }

        private void SaveEditLog()
        {
            clsPatientInfLog patientLogVo = new clsPatientInfLog();
            patientLogVo.operatorId = this.m_objViewer.LoginInfo.m_strEmpID;
            patientLogVo.registerId = this.m_objViewer.ucPatientInfo1.RegisterID;
            patientLogVo.desc = "";

            clsDcl_BIHTransfer m_objTran = new clsDcl_BIHTransfer();

            if (this.m_strREMARK != this.m_objViewer.m_txtREMARK.Text.Trim())
            {
                patientLogVo.detail = "��ע��Ϣ��" + this.m_strREMARK + "--> " + this.m_objViewer.m_txtREMARK.Text.Trim();

                m_objTran.AddPatienInfLog(patientLogVo);
            }

            if (this.m_strDes != this.m_objViewer.m_txtDes.Text.Trim())
            {
                patientLogVo.detail = "��ע��" + this.m_strDes + "--> " + this.m_objViewer.m_txtDes.Text.Trim();

                m_objTran.AddPatienInfLog(patientLogVo);
            }

            string strChargeCtl;

            if (this.m_objViewer.m_ckbChargeCtl.Checked == true)
            {
                strChargeCtl = "����Ƿ��";
            }
            else
            {
                strChargeCtl = "������Ƿ��";
            }

            if (this.m_strChargeCtl != strChargeCtl)
            {


                patientLogVo.detail = "Ƿ�ѿ��ƣ�" + this.m_strChargeCtl + "--> " + strChargeCtl;

                m_objTran.AddPatienInfLog(patientLogVo);
            }
           
        }
        /// <summary>
        /// ȡ���ر�ע��
        /// </summary>
        internal void DelData()
        {
            clsSpecreMark_VO m_objSpecreMark_VO = new clsSpecreMark_VO();
            if (this.m_objViewer.m_txtREMARK.Tag != null)
            {
                m_objSpecreMark_VO = (clsSpecreMark_VO)this.m_objViewer.m_txtREMARK.Tag;
                if (!m_objSpecreMark_VO.m_strSEQ_INT.ToString().Trim().Equals(""))
                {
                    m_objSpecreMark_VO.m_strCANCELERID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
                    long lngReg = m_objManager.m_lngSaveDelPatientSPECREMARK(m_objSpecreMark_VO);
                    if (lngReg > 0)
                    {
                        MessageBox.Show("�����ɹ�!", "��ʾ��",MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bindtheTextBox(m_strCurrentRegisterID);
                        //ˢ�������Ϣ
                        this.m_objViewer.ucPatientInfo1.m_mthFind(this.m_objViewer.zyh, 2);
                        m_strCurrentRegisterID = this.m_objViewer.ucPatientInfo1.RegisterID;
                        /*<===============================*/
                    }
                }
               
            }
        }

        internal void changeMessage()
        {
            if (!this.m_strCurrentRegisterID.Trim().Equals("")&&this.m_objViewer.m_txtREMARK.Tag!=null)
            {
                //if (this.m_objViewer.dataGridView1.SelectedRows.Count > 0)
                //{
                //    if (this.m_objViewer.dataGridView1.SelectedRows[0].Cells["REMARKID_CHR"].Value != null)
                //    {
                //        ((clsSpecreMark_VO)this.m_objViewer.m_txtREMARK.Tag).m_strREMARKID_CHR = this.m_objViewer.dataGridView1.SelectedRows[0].Cells["REMARKID_CHR"].Value.ToString().Trim();
                //    }
                //    if (this.m_objViewer.dataGridView1.SelectedRows[0].Cells["REMARKNAME_VCHR"].Value != null)
                //    {
                //        this.m_objViewer.m_txtREMARK.Text = this.m_objViewer.dataGridView1.SelectedRows[0].Cells["REMARKNAME_VCHR"].Value.ToString().Trim();
                  
                //    }
                //}
                if (this.m_objViewer.dataGridView1.CurrentCell!=null)
                {
                    if (this.m_objViewer.dataGridView1["REMARKID_CHR", this.m_objViewer.dataGridView1.CurrentCell.RowIndex].Value != null)
                    {
                        ((clsSpecreMark_VO)this.m_objViewer.m_txtREMARK.Tag).m_strREMARKID_CHR = this.m_objViewer.dataGridView1["REMARKID_CHR", this.m_objViewer.dataGridView1.CurrentCell.RowIndex].Value.ToString().Trim();
                    }
                    if (this.m_objViewer.dataGridView1["REMARKNAME_VCHR", this.m_objViewer.dataGridView1.CurrentCell.RowIndex].Value != null)
                    {
                        this.m_objViewer.m_txtREMARK.Text = this.m_objViewer.dataGridView1["REMARKNAME_VCHR", this.m_objViewer.dataGridView1.CurrentCell.RowIndex].Value.ToString().Trim();
                    }

                    if (this.m_objViewer.dataGridView1["CHARGECTL", this.m_objViewer.dataGridView1.CurrentCell.RowIndex].Value != null)
                    {
                        string chargeCtl = this.m_objViewer.dataGridView1["CHARGECTL", this.m_objViewer.dataGridView1.CurrentCell.RowIndex].Value.ToString().Trim();
                        if (chargeCtl == "1")
                        {
                            this.m_objViewer.m_ckbChargeCtl.Checked = true;
                        }
                        else
                        {
                            this.m_objViewer.m_ckbChargeCtl.Checked = false;
                        }
                    }
                }

            }
        }
    }
}
