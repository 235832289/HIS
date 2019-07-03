using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;
using iCare;
using com.digitalwave.iCare.middletier.HIS;
using ControlLibrary;


namespace com.digitalwave.iCare.gui.HIS
{
	/// <summary>
	/// ��λ����[�Ӵ�]���߼����Ʋ�
	/// </summary>
	public class clsCtl_EditBed: com.digitalwave.GUI_Base.clsController_Base
	{
		#region ����
        clsDcl_BIHTransfer m_objManage;
		/// <summary>
		/// �Ƿ�ҽ������
		/// </summary>
		private bool m_bolProtect = false;
        /// <summary>
        /// ��Ժ�Ǽ�ID
        /// </summary>
        private string m_strRegisterID;
        /// <summary>
        /// ����ID
        /// </summary>
        private string m_strAreaID;
		#endregion 

		#region ���캯��
		public clsCtl_EditBed()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
            m_objManage = new clsDcl_BIHTransfer();
		}
		#endregion 

		#region ���ô������
        com.digitalwave.iCare.gui.HIS.frmEditBed m_objViewer;
		/// <summary>
		/// ���ô������
		/// </summary>
		/// <param name="frmMDI_Child_Base_in"></param>
		public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
		{
			base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmEditBed)frmMDI_Child_Base_in;
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
                                                                        WHERE (   t1.deptid_chr = '" + this.m_strAreaID + @"'
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
                                                                        WHERE ( t1.deptid_chr = '" + this.m_strAreaID + @"'
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

            #region ҽ�����
            clsColumns_VO[] columArr2 = new clsColumns_VO[]
            {
                new clsColumns_VO("���","dmcode",HorizontalAlignment.Left,60),
                new clsColumns_VO("�������(ҽ��)","zhsm",HorizontalAlignment.Left,180),
           };
            //m_objViewer.m_txtDIAGNOSE.m_mthInitListView(lsvCloumnArr);            
            m_objViewer.m_txtDIAGNOSE.m_strSQL = @"SELECT zdfl || dmzh dmcode, zhsm
                                                  FROM ybgd05 a, ybgd04 b
                                                 WHERE a.zdfl = b.dmlb";
            //m_objViewer.m_txtDIAGNOSE.m_mthGetData();
            //m_objViewer.m_txtDIAGNOSE.m_strFindFieldsArr = new string[2] { "dmcode", "zhsm" };
            m_objViewer.m_txtDIAGNOSE.m_mthInitListView(columArr2);
            #endregion

            #region ��ȡ��ʳ�б�
            columArr = new clsColumns_VO[]
            {
                new clsColumns_VO("����","USERCODE_CHR",HorizontalAlignment.Left,50),
                new clsColumns_VO("��Ŀ����","NAME_CHR",HorizontalAlignment.Left,150),
                new clsColumns_VO("ƴ����","PYCODE_CHR",HorizontalAlignment.Left,0)
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
                new clsColumns_VO("ƴ����","PYCODE_CHR",HorizontalAlignment.Left,0)
           };
            m_objViewer.m_txtNurse.m_strSQL = @"SELECT a.ORDERDICID_CHR, a.USERCODE_CHR, a.NAME_CHR, a.PYCODE_CHR  from t_bse_bih_orderdic a, T_BSE_BIH_SPECORDERCATE b
                                                       WHERE a.ordercateid_chr = b.NURSECATE
                                                    ORDER BY a.USERCODE_CHR";
            m_objViewer.m_txtNurse.m_mthInitListView(columArr);

            #endregion 

               
            //��ȡϵͳ����
            string setting = clsSysSetting.GetSettingByID("1043");
            if (setting != "1")
            {
                this.m_objViewer.m_txtEat.Enabled = false;
                this.m_objViewer.m_txtNurse.Enabled = false;
            }
        }

        #endregion

		#region ������Ժ�Ǽ�ID��ȡ������Ϣ
		/// <summary>
        /// ������Ժ�Ǽ�ID��ȡ������Ϣ
		/// </summary>
        public void m_mthShowPatientInfo(clsBedManageVO p_bedManageVO)
        {
            clsBIHpatientVO p_obRecord;
            try
            {
                long lngRes = m_objManage.m_lngGetBIHPatientInfoByRegID(p_bedManageVO.m_strREGISTERID_CHR, out p_obRecord);
                if (lngRes > 0)
                {
                    m_strRegisterID = p_bedManageVO.m_strREGISTERID_CHR;
                    m_strAreaID = p_obRecord.m_strAREAID;
                    m_objViewer.m_txtMaindoctor.Value = p_obRecord.m_strCASEDOCTOR_CHR;
                    m_objViewer.m_txtMaindoctor.Text = p_obRecord.m_strDOCTORNAME;
                    m_objViewer.m_txtINPatient.Text = p_obRecord.m_strINPATIENTID_CHR;
                    m_objViewer.m_txtPATIENTCARDID.Text = p_obRecord.m_strPATIENTCARDID_CHR;
                    m_objViewer.m_txtInsuranceID.Text = p_obRecord.m_strINSURANCEID_VCHR;
                    m_objViewer.m_txtPatientName.Text = p_obRecord.m_strNAME_VCHR;
                    m_objViewer.m_txtSex.Text = p_obRecord.m_strSEX_CHR;

                    try
                    {
                        m_objViewer.m_inAreaDate.Text = Convert.ToDateTime(p_obRecord.m_strInAreaDate).ToString("yyyy��MM��dd��HHʱmm��");
                    }
                    catch { }

                    try
                    {
                        m_objViewer.m_txtBIRTH_DAT.Text = Convert.ToDateTime(p_obRecord.m_strBIRTH_DAT).ToString("yyyy-MM-dd HH:mm");
                    }
                    catch { }
                    m_objViewer.m_txtIDCARD_CHR.Text = p_obRecord.m_strIDCARD_CHR;
                    m_objViewer.m_txtHOMEPHONE_VCHR.Text = p_obRecord.m_strHOMEPHONE_VCHR;
                    m_objViewer.m_txtPaytypeid.Text = p_obRecord.m_strPAYTYPENAME_VCHR;
                    //m_objViewer.m_txtSTATE_INT.Text = p_obRecord.m_strSTATUS;
                    string strTem = "";
                    switch (p_obRecord.m_strTYPE_INT)
                    {
                        case "1":
                            strTem = "����";
                            break;
                        case "2":
                            strTem = "����";
                            break;
                        case "3":
                            strTem = "��Ժת��";
                            break;
                        case "4":
                            strTem = "����ת��";
                            break;
                        default:
                            strTem = "";
                            break;
                    }
                    m_objViewer.m_txtTYPE_INT.Text = strTem;
                    //��Ժ����
                    try
                    {
                        m_objViewer.m_txtINPATIENT_DAT.Text = Convert.ToDateTime(p_obRecord.m_strINPATIENT_DAT).ToString("yyyy-MM-dd HH:mm");
                    }
                    catch{}
                    m_objViewer.m_txtICD.Tag = p_obRecord.m_strICD10DIAGID_VCHR;
                    m_objViewer.m_txtICD.Text = p_obRecord.m_strICD10DIAGTEXT_VCHR;
                    //�ж��Ƿ���ҽ������
                    if (p_obRecord.m_strINTERNALFLAG_INT == "2")  //նʱд��,�Ժ�Ҫ�ĵ�
                    {
                        m_bolProtect = true;
                    }
                    if (m_bolProtect)
                    {
                        m_objViewer.m_txtDIAGNOSE.Enabled = true;
                        m_objViewer.m_txtDIAGNOSE.Tag = p_obRecord.m_strDIAGNOSEID_CHR;
                        m_objViewer.m_txtDIAGNOSE.Text = p_obRecord.m_strDIAGNOSE_VCHR;
                    }
                    else
                    {
                        m_objViewer.m_txtDIAGNOSE.Tag = "";
                        m_objViewer.m_txtDIAGNOSE.Text = "��ҽ�����ˣ�";
                        m_objViewer.m_txtDIAGNOSE.Enabled = false;
                    }
                    //this.m_objViewer.m_txtFoodInfo.Text = p_bedManageVO.m_strEATDICCATE;
                    //this.m_objViewer.m_txtCareInfo.Text = p_bedManageVO.m_strNURSECATE;

                   //������ʳ��Ϣ
                    GetPatientNurseByRegId(m_strRegisterID);

                    //������Ϣ
                    try
                    {
                        //string state = GetPatientStateByRegId(m_strRegisterID);
                        this.m_objViewer.m_cboSTATE_INT.SelectedIndex = Convert.ToInt16(p_bedManageVO.m_strSTATE_INT);
                    }
                    catch
                    {
                        this.m_objViewer.m_cboSTATE_INT.SelectedIndex = 0;
                    }
                    
                }

                //������Ժ�Ǽ�ID�жϲ����Ƿ����ת�����Ժ��¼
                lngRes = this.m_objManage.CheckTranOrOut(p_bedManageVO.m_strREGISTERID_CHR);
                if (lngRes > 0)
                {
                    this.m_objViewer.m_inAreaDate.Enabled = false;
                }
            }
            catch
            {
                MessageBox.Show("��ȡ������Ϣ����");
            }

        }
		#endregion 

        #region ������Ժ���(ICD10)��Ϣ
        /// <summary>
		/// ������Ժ���(ICD10)��Ϣ
		/// </summary>
		public void m_mthFindICD10Info()
		{
			m_objViewer.m_lsvICD.Items.Clear();
            DataTable p_dtbResult;
			ListViewItem lsvItem;
			try
			{
                long lngReg = m_objManage.m_lngFindICD10(m_objViewer.m_txtICD.Text.Trim().ToUpper(),out p_dtbResult);
				foreach (DataRow dr in p_dtbResult.Rows)
				{
					lsvItem = new ListViewItem(dr["icdcode_chr"].ToString().Trim());
					lsvItem.SubItems.Add(dr["icdname_vchr"].ToString().Trim());
					m_objViewer.m_lsvICD.Items.Add(lsvItem);
				}
			}
			catch{}
			
			m_objViewer.m_lsvICD.Visible = true;
		}
		#endregion

		#region	ѡ��ICD���
		/// <summary>
		/// ѡ��ICD���	glzhang	2005.09.02
		/// </summary>
		public void m_mthSelectedProtectPatien()
		{
			if(m_objViewer.m_lsvICD.SelectedItems.Count>0)
			{
				m_objViewer.m_txtICD.Tag = m_objViewer.m_lsvICD.SelectedItems[0].SubItems[0].Text.Trim();
				m_objViewer.m_txtICD.Text = m_objViewer.m_lsvICD.SelectedItems[0].SubItems[1].Text.Trim();
				m_objViewer.m_lsvICD.Visible=false;
				SendKeys.SendWait("{TAB}");
			}
		}
		#endregion

		#region	ѡ��ICD���
		/// <summary>
		/// ѡ��ICD���
		/// </summary>
		public void m_mthSelectProtectPactien(int p_intPra)
		{
			if(m_objViewer.m_lsvICD.Visible == true)
			{
				if(m_objViewer.m_lsvICD.SelectedItems.Count<1)
				{
					m_objViewer.m_lsvICD.Items[0].Selected=true;
				}
				else
				{
					try
					{
						if(p_intPra == 0)
						{
							m_objViewer.m_lsvICD.Items[m_objViewer.m_lsvICD.SelectedItems[0].Index+1].Selected=true;
							m_objViewer.m_lsvICD.SelectedItems[0].EnsureVisible();
						}
						else
						{
							m_objViewer.m_lsvICD.Items[m_objViewer.m_lsvICD.SelectedItems[0].Index-1].Selected=true;
							m_objViewer.m_lsvICD.SelectedItems[0].EnsureVisible();
						}
					}
					catch
					{
						if(p_intPra == 0)
						{
							m_objViewer.m_lsvICD.Items[0].Selected=true;
							m_objViewer.m_lsvICD.SelectedItems[0].EnsureVisible();
						}
						else
						{
							m_objViewer.m_lsvICD.Items[m_objViewer.m_lsvICD.Items.Count-1].Selected=true;
							m_objViewer.m_lsvICD.SelectedItems[0].EnsureVisible();
						}
					}
				}
			}
		}
		#endregion

		#region	����סԺ��Ϣ
		/// <summary>
		/// ����סԺ��Ϣ
		/// </summary>
		public void m_thSaveInHospInfo()
		{
			clsT_Opr_Bih_Register_VO p_objRecord = new clsT_Opr_Bih_Register_VO();
			p_objRecord.m_strREGISTERID_CHR = m_strRegisterID;

            if (m_objViewer.m_cboSTATE_INT.SelectedIndex == 0)
            {
                MessageBox.Show("���鲻��Ϊ�գ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_cboSTATE_INT.Focus();
                return;
            }

            if (m_objViewer.m_txtMaindoctor.Value == null)
            {
                MessageBox.Show("����ҽ��Ϊ��ѡ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.m_objViewer.m_txtMaindoctor.Focus(); 
                return;
            }
            else
            {
                p_objRecord.m_strCASEDOCTOR_CHR = m_objViewer.m_txtMaindoctor.Value.Trim();
            }

			if(m_objViewer.m_txtICD.Text.Trim() == "")
			{
				p_objRecord.m_strICD10DIAGID_VCHR="";
			}
			else
			{
				p_objRecord.m_strICD10DIAGID_VCHR =m_objViewer.m_txtICD.Tag.ToString().Trim();
			}
			p_objRecord.m_strICD10DIAGTEXT_VCHR =m_objViewer.m_txtICD.Text.Trim();
            if (m_objViewer.m_txtDIAGNOSE.Text.Trim() == "" || m_bolProtect == false)
			{
				p_objRecord.m_strDIAGNOSEID_CHR = "";
				p_objRecord.m_strDIAGNOSE_VCHR = "";
			}
			else
			{
				p_objRecord.m_strDIAGNOSEID_CHR=m_objViewer.m_txtDIAGNOSE.Tag.ToString().Trim();
				p_objRecord.m_strDIAGNOSE_VCHR  =m_objViewer.m_txtDIAGNOSE.Text.Trim();
			}
            
            p_objRecord.m_strINAREADATE_DAT = m_objViewer.m_inAreaDate.Text.Trim();
            
			p_objRecord.m_strOPERATORID_CHR=m_objViewer.LoginInfo.m_strEmpID;
            m_objViewer.Cursor = Cursors.WaitCursor;
            try
            {
                string firstOrderDate;
                //������Ժ�Ǽ�ID��ȡ���������ҽ��ʱ��
                this.m_objManage.GetFirstOrderDateByRegId(this.m_strRegisterID, out firstOrderDate);
                if (firstOrderDate != "")
                {
                    if (Convert.ToDateTime(p_objRecord.m_strINAREADATE_DAT) > Convert.ToDateTime(firstOrderDate))
                    {
                        MessageBox.Show("�벡��ʱ�䲻�ܳ���ҽ��ʱ�䣡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.m_objViewer.m_inAreaDate.Focus();
                        return;
                    }
                }

                if (Convert.ToDateTime(p_objRecord.m_strINAREADATE_DAT) < Convert.ToDateTime(m_objViewer.m_txtINPATIENT_DAT.Text.Trim()))
                {
                    MessageBox.Show("�벡��ʱ�䲻��������Ժʱ�䣡", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.m_objViewer.m_inAreaDate.Focus();
                    return;
                }

                p_objRecord.m_intSTATE_INT = this.m_objViewer.m_cboSTATE_INT.SelectedIndex;
                p_objRecord.m_strEatOrderdic = this.m_objViewer.m_txtEat.Value;
                p_objRecord.m_strNurseOrderdic = this.m_objViewer.m_txtNurse.Value;

                if (this.m_objViewer.m_txtNurse.Text.Contains("�ؼ�"))
                {
                    p_objRecord.m_intNursingClass = 0;
                }
                else if (this.m_objViewer.m_txtNurse.Text.Contains("һ��"))
                {
                    p_objRecord.m_intNursingClass = 1;
                }
                else if (this.m_objViewer.m_txtNurse.Text.Contains("����"))
                {
                    p_objRecord.m_intNursingClass = 2;
                }
                else if (this.m_objViewer.m_txtNurse.Text.Contains("����"))
                {
                    p_objRecord.m_intNursingClass = 3;
                }

                long lngReg = m_objManage.m_lngModifyRegInfo(p_objRecord);
                if (lngReg > 0)
                {
                    m_objViewer.DialogResult = System.Windows.Forms.DialogResult.OK;
                    MessageBox.Show("����ɹ���", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("����ʧ�ܣ�", "��λ����", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��λ����");
            }
            finally
            {
                m_objViewer.Cursor = Cursors.Default;
            }
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
