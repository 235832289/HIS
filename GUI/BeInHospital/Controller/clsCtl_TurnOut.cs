using System;
using System.Data;
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.security;
using com.digitalwave.iCare.middletier.PatientSvc;
using com.digitalwave.iCare.gui.Security;
using CrystalDecisions.CrystalReports.Engine;
using ControlLibrary;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ת�����߼����Ʋ�
    /// ���ߣ� ����
    /// ����ʱ�䣺 2004-09-21
    /// </summary>
    public class clsCtl_TurnOut : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ����
        clsDcl_Register m_objRegister = null;
        public string m_strOperatorID;
        com.digitalwave.iCare.gui.Systempower.clsSystemPower_base objsystempower;
        #endregion

        #region ���캯��
        public clsCtl_TurnOut()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            m_objRegister = new clsDcl_Register();
            objsystempower = new com.digitalwave.iCare.gui.Systempower.clsSystemPower_base(m_strOperatorID);

        }
        #endregion

        #region ��ʼ������
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public void m_mthInit()
        {
            // ��ȡ�����б�
            //            clsListViewColumns_VO[] m_objColumnsArr = new clsListViewColumns_VO[2]{
            //                new clsListViewColumns_VO("ƴ����","pycode_chr",HorizontalAlignment.Left,80),
            //                new clsListViewColumns_VO("����","deptname_vchr",HorizontalAlignment.Left,120)
            //            };
            //            m_objViewer.m_txtListArea.m_mthInitListView(m_objColumnsArr);
            //            m_objViewer.m_txtListArea.m_strSQL = @"SELECT   deptid_chr, deptname_vchr, shortno_chr, pycode_chr, code_vchr
            //    FROM t_bse_deptdesc t1
            //   WHERE attributeid = '0000003'
            //     AND status_int = 1
            //     AND deptid_chr <> '" + m_objViewer.m_strAreaID + @"'
            //ORDER BY code_vchr";

            // �����б�
            clsColumns_VO[] columArr = new clsColumns_VO[]{
                new clsColumns_VO("���","code_vchr",HorizontalAlignment.Left,50),
                new clsColumns_VO("ƴ����","pycode_chr",HorizontalAlignment.Left,60),
                new clsColumns_VO("��������","deptname_vchr",HorizontalAlignment.Left,130)
            };

            this.m_objViewer.m_txtListArea.m_strSQL = @"SELECT   deptid_chr, deptname_vchr, shortno_chr, pycode_chr, code_vchr
                                                            FROM t_bse_deptdesc t1
                                                           WHERE attributeid = '0000003'
                                                             AND status_int = 1
                                                             AND deptid_chr <> '" + m_objViewer.m_strAreaID + @"'
                                                        ORDER BY code_vchr";
            m_objViewer.m_txtListArea.m_mthInitListView(columArr);


            //m_objViewer.m_txtListArea.m_mthGetData();

            m_strOperatorID = m_objViewer.LoginInfo.m_strEmpID;
            m_objViewer.m_cobPrint.SelectedIndex = 0;
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmTurnOut m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmTurnOut)frmMDI_Child_Base_in;
        }
        #endregion

        #region ת��
        /// <summary>
        /// ת��
        /// </summary>
        public void m_cmdTurnOut()
        {
            if (m_objViewer.m_txtListArea.Value == null || m_objViewer.m_txtListArea.Value == "")
            {
                MessageBox.Show(m_objViewer, "ת�벡��Ϊ�����", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                m_objViewer.m_txtListArea.Focus();
                return;
            }
            clsT_Opr_Bih_Transfer_VO objPatientVO;
            ValueToVoForTransfer(out objPatientVO);
            if (!blnDealWithOrder(objPatientVO.m_strREGISTERID_CHR))
            {
                return;
            }
            if (objsystempower.isHasRight("סԺ.����ת.ת��"))
            {
                try
                {
                    long lngReg = new clsDcl_BIHTransfer().m_lngTurnOut(objPatientVO);
                    if (lngReg > 0)
                    {
                        MessageBox.Show(m_objViewer, "ת���ɹ���", "ת����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (m_objViewer.m_cobPrint.SelectedIndex == 0)
                        {
                            m_mthPrintTurnOutNotice();
                        }
                        m_objViewer.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message + "��", "ת��ʧ��", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show("��û��Ȩ��");
            }
        }

        #region �ؼ���ֵ��Vo
        /// <summary>
        /// �ؼ���ֵ��Vo
        /// </summary>
        /// <param name="objPatientVO"></param>
        private void ValueToVoForTransfer(out clsT_Opr_Bih_Transfer_VO objPatientVO)
        {
            objPatientVO = new clsT_Opr_Bih_Transfer_VO();
            objPatientVO.m_strSOURCEDEPTID_CHR = m_objViewer.m_strDeptID;
            objPatientVO.m_strSOURCEAREAID_CHR = m_objViewer.m_strAreaID;
            objPatientVO.m_strSOURCEBEDID_CHR = m_objViewer.m_objBedManage.m_strBEDID_CHR;
            objPatientVO.m_strTARGETAREAID_CHR = (string)m_objViewer.m_txtListArea.Value;
            objPatientVO.m_strTARGETBEDID_CHR = "";
            objPatientVO.m_intTYPE_INT = 3;
            objPatientVO.m_strDES_VCHR = m_objViewer.m_txtDES.Text;
            objPatientVO.m_strOPERATORID_CHR = m_strOperatorID;
            objPatientVO.m_strREGISTERID_CHR = m_objViewer.m_objBedManage.m_strREGISTERID_CHR;
            objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region ������ҽ��
        /// <summary>
        /// ������ҽ����
        /// </summary>
        /// <param name="p_strRegisterID"></param>
        /// <returns></returns>
        private bool blnDealWithOrder(string p_strRegisterID)
        {
            bool p_blnHaveStop;
            try
            {
                m_objRegister.m_lngGetNotStopLongOrderByRegisterID3(p_strRegisterID, out p_blnHaveStop);
                if (p_blnHaveStop)
                {
                    if (MessageBox.Show(m_objViewer, "���ڳ���ҽ����ת����ǰ����ֹͣ���еĳ���ҽ����\r\n    ��Ҫ�Զ�ֹͣҽ����", "ת����", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return false;
                    }
                    else
                    {
                        //m_objRegister.m_lngStopANDAuditingOrderByRegID(p_strRegisterID, "", "ת���Զ�");

                        m_objRegister.m_lngStopANDAuditingOrderByRegID(p_strRegisterID, this.m_objViewer.LoginInfo.m_strEmpID, this.m_objViewer.LoginInfo.m_strEmpName);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ֹͣҽ��ʧ��");
                return false;
            }
            return true;
        }
        #endregion
        #endregion

        #region ��ӡת��֪ͨ��
        /// <summary>
        /// ��ӡת��֪ͨ��
        /// </summary>
        public void m_mthPrintTurnOutNotice()
        {
            try
            {
                ReportDocument m_rptDocument = new ReportDocument();
                m_rptDocument.Load(@".\report\rptTurnAreaNotice.rpt");
                ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labBedCode"]).Text = m_objViewer.m_objBedManage.m_strCODE_CHR;
                ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labName"]).Text = m_objViewer.m_objBedManage.m_strNAME_VCHR;
                ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labInpatientNun"]).Text = m_objViewer.m_objBedManage.m_strINPATIENTID_CHR;
                ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labTurnInArea"]).Text = m_objViewer.m_txtListArea.Text;
                ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labTurnOutArea"]).Text = m_objViewer.m_txtArea.Text; 
                m_rptDocument.PrintToPrinter(1, true, 0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "��ӡת��֪ͨ��ʧ��");
            }
        }
        #endregion
    }
}
