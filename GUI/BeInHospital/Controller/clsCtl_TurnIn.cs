using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;
using iCareData;
using System.Collections;
using com.digitalwave.iCare.gui.Security;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ���Ŵ�λ���߼����Ʋ�
    /// </summary>
    public class clsCtl_TurnIn : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ����
        clsDcl_BIHTransfer m_objManage = null;
        #endregion

        #region ���캯��
        public clsCtl_TurnIn()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            m_objManage = new clsDcl_BIHTransfer();
            clsController_Security clsSe = new clsController_Security();
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmTurnIn m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmTurnIn)frmMDI_Child_Base_in;
        }
        #endregion

        #region ��ʼ������
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public void m_mthInit()
        {
            //ϵͳ��������
            int sysSet = 0;
            this.m_objManage.m_lngGetSetingByID("1056", out sysSet);

            #region ��ȡ����ҽ���б�
            clsColumns_VO[] columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("����","empno_chr",HorizontalAlignment.Left,50),
                new clsColumns_VO("ƴ����","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("����","doctorname",HorizontalAlignment.Left,80)
           };
            if (sysSet == 1)
            {
                m_objViewer.m_txtMaindoctor.m_strSQL = @"SELECT   t3.empid_chr, t3.empno_chr, t3.pycode_chr, t3.doctorname, t4.flag
                                                        FROM (SELECT t1.empid_chr, t1.empno_chr, t1.pycode_chr,
                                                                     t1.lastname_vchr AS doctorname, 1 AS flag
                                                                FROM t_bse_employee t1
                                                               WHERE status_int = 1 AND hasprescriptionright_chr = 1) t3,
                                                             (SELECT DISTINCT t1.empid_chr, t2.empno_chr, t2.pycode_chr,
                                                                              t2.lastname_vchr AS doctorname, 0 AS flag
                                                                         FROM t_bse_deptemp t1, t_bse_employee t2
                                                                        WHERE (   t1.deptid_chr = '" + m_objViewer.m_strAreaID + @"'
                                                                               OR t1.deptid_chr = '0000001'
                                                                              )
                                                                          AND t2.hasprescriptionright_chr = 1
                                                                          AND t2.status_int = 1
                                                                          AND t1.empid_chr = t2.empid_chr) t4
                                                       WHERE t3.empid_chr = t4.empid_chr(+)
                                                    ORDER BY flag, empno_chr";
            }
            else
            {
                m_objViewer.m_txtMaindoctor.m_strSQL = @"SELECT DISTINCT t1.empid_chr, t2.empno_chr, t2.pycode_chr,
                                                                              t2.lastname_vchr AS doctorname, 0 AS flag
                                                                         FROM t_bse_deptemp t1, t_bse_employee t2
                                                                        WHERE ( t1.deptid_chr = '" + m_objViewer.m_strAreaID + @"'
                                                                               OR t1.deptid_chr = '0000001'
                                                                              )
                                                                          AND t2.hasprescriptionright_chr = 1
                                                                          AND t2.status_int = 1
                                                                          AND t1.empid_chr = t2.empid_chr
                                                          ORDER BY flag, t2.empno_chr";
            }

            m_objViewer.m_txtMaindoctor.m_mthInitListView(columArr);
            for (int i1 = 0; i1 < m_objViewer.m_txtMaindoctor.m_listView.Items.Count; i1++)
            {
                DataRowView drv = (DataRowView)m_objViewer.m_txtMaindoctor.m_listView.Items[i1].Tag;
                if (drv["flag"].ToString().Trim() == "")
                {
                    if (m_objViewer.m_txtMaindoctor.m_listView.Items[i1].ForeColor == System.Drawing.SystemColors.WindowText)
                    {
                        m_objViewer.m_txtMaindoctor.m_listView.Items[i1].ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
            #endregion

            #region ��ȡ��ʳ�б�
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("����","USERCODE_CHR",HorizontalAlignment.Left,50),
                new clsColumns_VO("��Ŀ����","NAME_CHR",HorizontalAlignment.Left,150),
                new clsColumns_VO("ƴ����","PYCODE_CHR",HorizontalAlignment.Left,80)
           };
            m_objViewer.m_txtEat.m_strSQL = @"SELECT a.ORDERDICID_CHR, a.USERCODE_CHR, a.NAME_CHR, a.PYCODE_CHR  from t_bse_bih_orderdic a, T_BSE_BIH_SPECORDERCATE b
                                                       WHERE a.ordercateid_chr = b.EATDICCATE
                                                    ORDER BY a.USERCODE_CHR";
            m_objViewer.m_txtEat.m_mthInitListView(columArr);

            #endregion

            #region ��ȡ�����б�
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("����","USERCODE_CHR",HorizontalAlignment.Left,50),
                new clsColumns_VO("��Ŀ����","NAME_CHR",HorizontalAlignment.Left,100),
                new clsColumns_VO("ƴ����","PYCODE_CHR",HorizontalAlignment.Left,80)
           };
            m_objViewer.m_txtNurse.m_strSQL = @"SELECT a.ORDERDICID_CHR, a.USERCODE_CHR, a.NAME_CHR, a.PYCODE_CHR  from t_bse_bih_orderdic a, T_BSE_BIH_SPECORDERCATE b
                                                       WHERE a.ordercateid_chr = b.NURSECATE
                                                    ORDER BY a.USERCODE_CHR";
            m_objViewer.m_txtNurse.m_mthInitListView(columArr);

            #endregion

            m_mthGetTurnInNotAccept();
            m_mthGetEmptyBed();

            //û��Ĭ��ѡ�еĲ���
            if (m_objViewer.m_strRegisterID != "")
            {
                for (int i1 = 0; i1 < m_objViewer.m_lsvPatientInfo.Items.Count; i1++)
                {
                    if (m_objViewer.m_lsvPatientInfo.Items[i1].Tag.ToString().Trim().Equals(m_objViewer.m_strRegisterID))
                    {
                        m_objViewer.m_lsvPatientInfo.Items[i1].Selected = true;
                        break;
                    }
                }

                try
                {
                    string state = GetPatientStateByRegId(m_objViewer.m_strRegisterID);
                    this.m_objViewer.m_cboSTATE_INT.SelectedIndex = Convert.ToInt16(state);
                }
                catch
                {
                    this.m_objViewer.m_cboSTATE_INT.SelectedIndex = 3;
                }
            }
            else if (m_objViewer.m_lsvPatientInfo.Items.Count > 0)
            {
                m_objViewer.m_lsvPatientInfo.Items[0].Selected = true;
            }

            //����Ĭ��ѡ�еĴ�λ
            if (m_objViewer.m_strBedID != "")
            {
                this.m_objViewer.m_cmbBed.SelectedValue = m_objViewer.m_strBedID;
            }

            //�벡��ʱ��Ĭ��Ϊ��ǰʱ��
            //m_objViewer.m_inAreaDate.Text = DateTime.Now.ToString("yyyy��MM��dd��HHʱmm��");

            //��ȡϵͳ����
            string setting = clsSysSetting.GetSettingByID("1043");
            if (setting != "1")
            {
                this.m_objViewer.m_txtEat.Enabled = false;
                this.m_objViewer.m_txtNurse.Enabled = false;
            }

        }
        #endregion

        #region ���ݲ���ID��ѯδ���Ŵ�λ�Ĳ�����Ϣ
        /// <summary>
        /// ���ݲ���ID��ѯδ���Ŵ�λ�Ĳ�����Ϣ
        /// </summary>
        public void m_mthGetTurnInNotAccept()
        {
            m_objViewer.m_lsvPatientInfo.Items.Clear();
            DataTable p_dtbResult;
            try
            {
                m_objManage.m_lngGetTurnInNA(m_objViewer.m_strAreaID, out p_dtbResult);
                clsBrithdayToAge m_objAge = new clsBrithdayToAge();
                ListViewItem listviewitem;
                ListViewItem[] tempItemArr = new ListViewItem[p_dtbResult.Rows.Count];
                int index = 0;
                foreach (DataRow dr in p_dtbResult.Rows)
                {
                    listviewitem = new ListViewItem(dr["name_vchr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["inpatientid_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["name_vchr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["sex_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(m_objAge.m_strGetAge(dr["birth_dat"]));
                    listviewitem.SubItems.Add(dr["status"].ToString().Trim());
                    listviewitem.SubItems.Add(Convert.ToDateTime(dr["modify_dat"]).ToString("yyyy��MM��dd�� HHʱmm��"));
                    listviewitem.SubItems.Add(m_objViewer.m_lblAREAName.Text.Trim());
                    listviewitem.SubItems.Add(dr["type_int"].ToString().Trim());
                    listviewitem.SubItems.Add(Convert.ToDateTime(dr["HISINPATIENTDATE"]).ToString("yyyy��MM��dd�� HHʱmm��"));

                    listviewitem.Tag = dr["REGISTERID_CHR"].ToString().Trim();
                    //listviewitem.ImageIndex = intDisplayImageIndex(Int32.Parse(dr["STATE_INT"].ToString().Trim()), dr["SEX_CHR"].ToString().Trim());
                    listviewitem.ImageIndex = intDisplayImageIndex(dr["STATE_INT"].ToString().Trim(), dr["SEX_CHR"].ToString().Trim(), dr["nursecate"].ToString().Trim());
                    tempItemArr[index] = listviewitem;
                    index++;
                }
                m_objViewer.m_lsvPatientInfo.Items.AddRange(tempItemArr);
                p_dtbResult = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ȡ��ǰ����δ���Ŵ�λ�Ĳ�����Ϣ����");
            }
        }
        #endregion

        #region ��ȡ����ǰ������ȫԺδ���Ŵ�λ�Ĳ���
        /// <summary>
        /// ��ȡ����ǰ������ȫԺδ���Ŵ�λ�Ĳ���
        /// </summary>
        public void m_mthGetAllUmArrangeBedPatient()
        {
            DataTable p_dtbResult;
            try
            {
                m_objManage.m_lngGetAllUnArrangeBedPatient(m_objViewer.m_strAreaID, out p_dtbResult);
                clsBrithdayToAge m_objAge = new clsBrithdayToAge();
                ListViewItem listviewitem;
                ListViewItem[] tempItemArr = new ListViewItem[p_dtbResult.Rows.Count];
                int index = 0;
                foreach (DataRow dr in p_dtbResult.Rows)
                {
                    listviewitem = new ListViewItem(dr["name_vchr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["inpatientid_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["name_vchr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["sex_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(m_objAge.m_strGetAge(dr["birth_dat"]));
                    listviewitem.SubItems.Add(dr["status"].ToString().Trim());
                    listviewitem.SubItems.Add(Convert.ToDateTime(dr["modify_dat"]).ToString("yyyy��MM��dd�� HHʱmm��"));
                    listviewitem.SubItems.Add(dr["areaname"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["type_int"].ToString().Trim());
                    listviewitem.SubItems.Add(Convert.ToDateTime(dr["HISINPATIENTDATE"]).ToString("yyyy��MM��dd�� HHʱmm��"));

                    listviewitem.Tag = dr["REGISTERID_CHR"].ToString().Trim();
                    listviewitem.ForeColor = System.Drawing.Color.Red;
                    listviewitem.ImageIndex = intDisplayImageIndex(dr["STATE_INT"].ToString().Trim(), dr["SEX_CHR"].ToString().Trim(), dr["nursecate"].ToString().Trim());
                    tempItemArr[index] = listviewitem;
                    index++;
                }
                m_objViewer.m_lsvPatientInfo.Items.AddRange(tempItemArr);
                p_dtbResult = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ȡȫԺδ���Ŵ�λ����");
            }
        }
        #endregion

        #region	��ȡ��ǰ�����Ŀմ�
        /// <summary>
        /// ��ȡ��ǰ�����Ŀմ�
        /// </summary>
        public void m_mthGetEmptyBed()
        {
            long lngRes = 0;
            clsT_Bse_Bed_VO[] objBedArr;
            lngRes = m_objManage.m_lngGetBedShortInfoByAreaID(m_objViewer.m_strAreaID, "1,6", out objBedArr);
            if (lngRes > 0)
            {
                m_objViewer.m_cmbBed.DataSource = objBedArr;
                m_objViewer.m_cmbBed.DisplayMember = "m_strGetBedCODE";
                m_objViewer.m_cmbBed.ValueMember = "m_strGetBedID";
                if (m_objViewer.m_cmbBed.Items.Count > 0)
                {
                    this.m_objViewer.m_cmbBed.SelectedIndex = 0;
                }
            }
        }
        #endregion

        public void PatientChanged()
        {
            if (this.m_objViewer.m_lsvPatientInfo.SelectedItems[0].Tag != null)
            {
                string regId = this.m_objViewer.m_lsvPatientInfo.SelectedItems[0].Tag.ToString();
                try
                {
                    string state = GetPatientStateByRegId(regId);
                    this.m_objViewer.m_cboSTATE_INT.SelectedIndex = Convert.ToInt16(state);
                }
                catch
                {
                    this.m_objViewer.m_cboSTATE_INT.SelectedIndex = 0;
                }

                GetPatientNurseByRegId(regId);
            }
        }

        #region ���Ŵ�λ
        /// <summary>
        /// ���Ŵ�λ
        /// </summary>
        public void m_mthArrangeBed()
        {
            if (m_objViewer.m_cmbBed.SelectedItem == null)
            {
                MessageBox.Show("��λΪ��ѡ�", "���Ŵ�λ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_cmbBed.Focus();
                return;
            }

            if (m_objViewer.m_lsvPatientInfo.SelectedItems.Count < 1)
            {
                MessageBox.Show("����Ϊ��ѡ�", "���Ŵ�λ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (m_objViewer.m_txtMaindoctor.Value == null)
            {
                MessageBox.Show("����ҽ��Ϊ��ѡ�", "���Ŵ�λ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtMaindoctor.Focus();
                return;
            }

            if (m_objViewer.m_cboSTATE_INT.SelectedIndex == 0)
            {
                MessageBox.Show("���鲻��Ϊ�գ�", "���Ŵ�λ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_cboSTATE_INT.Focus();
                return;
            }

            clsT_Bse_Bed_VO bedVO = (clsT_Bse_Bed_VO)m_objViewer.m_cmbBed.SelectedItem;

            string strSex = m_objViewer.m_lsvPatientInfo.SelectedItems[0].SubItems[3].Text.Trim();
            if (bedVO.m_strSexName != "����" && strSex != bedVO.m_strSexName)
            {
                if (MessageBox.Show("��ȷ������" + strSex + "����ת��" + bedVO.m_strSexName + "������?", "���Ŵ�λ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }

            clsT_Opr_Bih_Transfer_VO p_objRecord = new clsT_Opr_Bih_Transfer_VO();
            p_objRecord.m_strTARGETDEPTID_CHR = m_objViewer.m_strDeptID;
            p_objRecord.m_strTARGETAREAID_CHR = m_objViewer.m_strAreaID;
            p_objRecord.m_strTARGETBEDID_CHR = bedVO.m_strBEDID_CHR;
            p_objRecord.m_strREGISTERID_CHR = (string)m_objViewer.m_lsvPatientInfo.SelectedItems[0].Tag;

            p_objRecord.m_strDES_VCHR = m_objViewer.m_txtMaindoctor.Value;
            p_objRecord.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            p_objRecord.m_strHisInpatientDate = m_objViewer.m_inAreaDate.Text;

            clsT_Opr_Bih_Register_VO objRegVO = new clsT_Opr_Bih_Register_VO();
            objRegVO.m_strREGISTERID_CHR = p_objRecord.m_strREGISTERID_CHR;
            objRegVO.m_intSTATE_INT = this.m_objViewer.m_cboSTATE_INT.SelectedIndex;
            objRegVO.m_strOPERATORID_CHR = this.m_objViewer.LoginInfo.m_strEmpID;
            objRegVO.m_strCASEDOCTOR_CHR = p_objRecord.m_strDES_VCHR = m_objViewer.m_txtMaindoctor.Value;

            if (this.m_objViewer.m_txtNurse.Value != null)
            {
                objRegVO.m_strNurseOrderdic = this.m_objViewer.m_txtNurse.Value;

                if (this.m_objViewer.m_txtNurse.Text.Contains("�ؼ�"))
                {
                    objRegVO.m_intNursingClass = 0;
                }
                else if (this.m_objViewer.m_txtNurse.Text.Contains("һ��"))
                {
                    objRegVO.m_intNursingClass = 1;
                }
                else if (this.m_objViewer.m_txtNurse.Text.Contains("����"))
                {
                    objRegVO.m_intNursingClass = 2;
                }
                else if (this.m_objViewer.m_txtNurse.Text.Contains("����"))
                {
                    objRegVO.m_intNursingClass = 3;
                }
            }
            else
            {
                objRegVO.m_strNurseOrderdic = "";
            }

            if (this.m_objViewer.m_txtEat.Value != null)
            {
                objRegVO.m_strEatOrderdic = this.m_objViewer.m_txtEat.Value;
            }
            else
            {
                objRegVO.m_strEatOrderdic = "";
            }

            try
            {
                long lngRes = m_objManage.m_lngArrangeBed(p_objRecord, objRegVO);
                if (lngRes > 0)
                {
                    MessageBox.Show("ת��ɹ���", "���Ŵ�λ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                    if ((new clsDcl_BedAdmin()).IsYbReg(p_objRecord.m_strREGISTERID_CHR))
                    {
                        frmYBRegisterZY frmYb = new frmYBRegisterZY();
                        frmYb.IsNurseModify = true;
                        frmYb.strRegisterId = p_objRecord.m_strREGISTERID_CHR;
                        frmYb.ShowDialog();
                    }

                    m_mthGetEmptyBed();
                    m_objViewer.m_lsvPatientInfo.SelectedItems[0].Remove();
                    if (m_objViewer.m_lsvPatientInfo.Items.Count > 0)
                    {
                        m_objViewer.m_lsvPatientInfo.Items[0].Selected = true;
                    }
                    m_objViewer.m_intFlag = 1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "��", "���Ŵ�λʧ��", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                m_mthGetEmptyBed();
                m_mthGetTurnInNotAccept();
            }
        }
        #endregion

        #region ȷ����ʾͼƬ
        /// <summary>
        /// ȷ����ʾͼƬ
        /// </summary>
        /// <param name="BedState">//��ǰ״̬��{1�մ���2ռ����3ԤԼռ����4����ռ��}</param>
        /// <param name="BedType"></param>
        /// <param name="RegisterID"></param>
        /// <returns></returns>
        private int intDisplayImageIndex(int Status, string Sex)
        {
            //״̬����ͨ	���ͣ��д�	
            if (Status == 3 && (Sex == "Ů" || Sex == "����"))
                return 1;

            //״̬��Σ	���ͣ�Ů��	
            if (Status == 1 && (Sex == "Ů" || Sex == "����"))
                return 2;

            //״̬����	���ͣ�����
            if (Status == 2 && (Sex == "Ů" || Sex == "����"))
                return 3;

            //״̬����ͨ	���ͣ��д�
            if (Status == 3 && Sex == "��")
                return 4;

            //״̬��Σ	���ͣ�Ů��	
            if (Status == 1 && Sex == "��")
                return 5;

            //״̬����	���ͣ�����
            if (Status == 2 && Sex == "��")
                return 6;

            //����
            return 0;
        }
        #endregion

        #region ������ʾͼ��(new)
        /// <summary>
        /// ȷ����ʾͼƬ
        /// </summary>
        /// <param name="Status">//��ǰ״̬��{1�մ���2ռ����3ԤԼռ����4����ռ��}</param>
        /// <param name="Sex">�Ա�</param>
        /// <param name="nurseCate">����ȼ�</param>
        /// <returns></returns>
        private int intDisplayImageIndex(string Status, string Sex, string nurseCate)
        {

            if (Status == "3")
            {
                if (Sex == "Ů")
                {
                    if (nurseCate.Contains("�ؼ�"))
                    {
                        return 24;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 21;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 18;
                    }
                    else if (nurseCate.Contains("һ��"))
                    {
                        return 30;
                    }
                    else
                    {
                        return 27;
                    }
                }
                else
                {
                    if (nurseCate.Contains("�ؼ�"))
                    {
                        return 9;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 6;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 3;
                    }
                    else if (nurseCate.Contains("һ��"))
                    {
                        return 15;
                    }
                    else
                    {
                        return 12;
                    }
                }
            }
            else if (Status == "2")
            {
                if (Sex == "Ů")
                {
                    if (nurseCate.Contains("�ؼ�"))
                    {
                        return 22;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 19;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 16;
                    }
                    else if (nurseCate.Contains("һ��"))
                    {
                        return 28;
                    }
                    else
                    {
                        return 25;
                    }
                }
                else
                {
                    if (nurseCate.Contains("�ؼ�"))
                    {
                        return 7;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 4;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 1;
                    }
                    else if (nurseCate.Contains("һ��"))
                    {
                        return 13;
                    }
                    else
                    {
                        return 10;
                    }
                }
            }

            else if (Status == "1")
            {
                if (Sex == "Ů")
                {
                    if (nurseCate.Contains("�ؼ�"))
                    {
                        return 23;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 20;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 17;
                    }
                    else if (nurseCate.Contains("һ��"))
                    {
                        return 29;
                    }
                    else
                    {
                        return 26;
                    }
                }
                else
                {
                    if (nurseCate.Contains("�ؼ�"))
                    {
                        return 8;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 5;
                    }
                    else if (nurseCate.Contains("����"))
                    {
                        return 2;
                    }
                    else if (nurseCate.Contains("һ��"))
                    {
                        return 14;
                    }
                    else
                    {
                        return 11;
                    }
                }
            }
            return 0;
        }

        #endregion

        private string GetPatientStateByRegId(string regId)
        {
            DataTable dt;
            long ret = 0;

            ret = this.m_objManage.GetPatientStateByRegID(regId, out dt);
            if (ret > 0 && dt.Rows.Count > 0)
            {
                return dt.Rows[0]["STATE_INT"].ToString();
            }
            else
            {
                return "0";
            }
        }

        private void GetPatientNurseByRegId(string regId)
        {
            DataTable dt;
            long ret = 0;

            ret = this.m_objManage.GetPatientNurseByRegID(regId, out dt);

            DataView dv = new DataView(dt);

            //������Ϣ
            dv.RowFilter = "TYPE_INT = 1";

            if (dv.Count > 0)
            {
                this.m_objViewer.m_txtNurse.Value = dv[0]["ORDERDICID_CHR"].ToString();
                this.m_objViewer.m_txtNurse.Text = dv[0]["NAME_CHR"].ToString();
            }

            //��ʳ��Ϣ
            dv.RowFilter = "TYPE_INT = 2";

            if (dv.Count > 0)
            {
                this.m_objViewer.m_txtEat.Value = dv[0]["ORDERDICID_CHR"].ToString();
                this.m_objViewer.m_txtEat.Text = dv[0]["NAME_CHR"].ToString();
            }
        }
    }
}
