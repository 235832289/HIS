using System;
using com.digitalwave.GUI_Base; //GUI_Base.dll
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Windows.Forms;
using System.Data;
using com.digitalwave.iCare.gui.Security;
using com.digitalwave.Utility;
using com.digitalwave.iCare.middletier.baseInfo;//baseInfo_Svc.dll
using System.Collections;
using CrystalDecisions.CrystalReports.Engine;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// ��λ������������Ʋ�
    /// </summary>
    public class clsCtl_BedAdmin : com.digitalwave.GUI_Base.clsController_Base
    {
        #region ����
        clsDcl_BIHTransfer m_objManage = null;
        public string m_strOperatorID = "";
        public string m_strOperatorName = "";
        /// <summary>
        /// ��ǰ������������ID
        /// </summary>
        private string m_strDeptID = "";
        /// <summary>
        /// ��ǰ����ID
        /// </summary>
        internal string m_strAreaID = "";
        /// <summary>
        /// ������λ����
        /// </summary>
        int m_intBedCount = 0;
        /// <summary>
        ///  �����մ���
        /// </summary>
        int m_intBedEmptyCount = 0;
        /// <summary>
        /// �Ƿ�ҽ������
        /// </summary>
        bool p_blnPretect;
        /// <summary>
        /// ��������δ�ᴦ������ʱ���Ƴ�Ժ������ҽ��¼��(ҽ��¼��1��2״̬��Ϊ��ʾѡ��)0-�ر�;1-��ʾѡ��2-��ס
        /// </summary>
        internal int m_intParm1068 = 0;
        private string m_strRegister = "";
        private string m_stringTargetBedID = "";
        /// <summary>
        /// ����ʱ��ת������
        /// </summary>
        clsBrithdayToAge m_objAge;
        internal com.digitalwave.iCare.gui.Systempower.clsSystemPower_base objsystempower;
        #endregion

        #region ���캯��
        public clsCtl_BedAdmin()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
            m_objManage = new clsDcl_BIHTransfer();
            m_objAge = new clsBrithdayToAge();
        }
        #endregion

        #region ���ô������
        com.digitalwave.iCare.gui.HIS.frmBedAdmin m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmBedAdmin)frmMDI_Child_Base_in;
        }
        #endregion

        #region ��ʼ������
        /// <summary>
        /// ��ʼ������
        /// </summary>
        public void m_mthInit()
        {
            m_strOperatorID = m_objViewer.LoginInfo.m_strEmpID;
            m_strOperatorName = m_objViewer.LoginInfo.m_strEmpName;
            m_objViewer.m_cmbView.SelectedIndex = 0;

            string setStatus;
            clsDclPrepayQuery objDomain = new clsDclPrepayQuery();
            //�������ñ��Ƿ������Ժ
            objDomain.GetSysSetting("1016", out setStatus);
            if (setStatus == "1")
            {
                this.m_objViewer.m_cmdLeaHosNoCheck.Visible = true;
            }
            else
            {
                this.m_objViewer.m_cmdLeaHosNoCheck.Visible = false;
            }
            m_intParm1068 = clsPublic.m_intGetSysParm("1068");
        }
        #endregion

        #region ��ȡ�����б�
        /// <summary>
        /// ��ȡ�����б�
        /// </summary>
        public void m_FillDepartListView()
        {
            m_objViewer.m_lsvDept.Items.Clear();
            clsAreaInfoVO[] p_objRecordArr;
            long lngRes = m_objManage.m_lngGetAreaList(m_objViewer.LoginInfo.m_strEmpID, out p_objRecordArr);
            if (lngRes > 0)
            {
                int index = 0;
                ListViewItem[] lsvItemArr = new ListViewItem[p_objRecordArr.Length];
                foreach (clsAreaInfoVO areInfoVo in p_objRecordArr)
                {
                    ListViewItem lsv = new ListViewItem(areInfoVo.m_strCODE_VCHR);
                    lsv.SubItems.Add(areInfoVo.m_strDEPTNAME_VCHR);
                    lsv.Tag = areInfoVo;
                    lsvItemArr[index] = lsv;
                    index++;
                }
                m_objViewer.m_lsvDept.Items.AddRange(lsvItemArr);
            }
            if (m_objViewer.m_lsvDept.Items.Count > 0)
            {
                m_objViewer.m_lsvDept.Items[0].Selected = true;
                m_mthDeptSelectedIndexChanged();
            }
        }
        #endregion

        #region ��ȡ��ǰѡ�в�����λ��Ϣ
        /// <summary>
        /// ��ȡ��ǰѡ�в�����λ��Ϣ
        /// </summary>
        public void m_mthDeptSelectedIndexChanged()
        {
            m_objViewer.Cursor = Cursors.WaitCursor;
            if (m_objViewer.m_lsvDept.SelectedItems.Count > 0)
            {
                clsAreaInfoVO areaInfoVo = (clsAreaInfoVO)m_objViewer.m_lsvDept.SelectedItems[0].Tag;
                m_strDeptID = areaInfoVo.m_strPARENTDEPTID;
                m_objViewer.m_lblDEPTNAME_VCHR.Text = areaInfoVo.m_strPARENTDEPTNAME;
                m_strAreaID = areaInfoVo.m_strDEPTID_CHR;
                //areaInfoVo.
                m_objViewer.m_lblPatientArea.Text = areaInfoVo.m_strDEPTNAME_VCHR;
                m_mthGetBidInfoByArearID();
                loadAreaTransferInfo();
            }
            m_objViewer.Cursor = Cursors.Default;
        }
        #endregion

        #region ���ص�ǰѡ�в�����λ��Ϣ
        /// <summary>
        /// ���ص�ǰѡ�в�����λ��Ϣ
        /// </summary>
        public void m_mthGetBidInfoByArearID()
        {
            m_objViewer.m_lsvBedInfo.Items.Clear();
            long lngReg = 0;
            clsBedManageVO[] p_objResultArr;
            lngReg = m_objManage.m_lngGetBidInfoByArearID(m_strAreaID, out p_objResultArr);
            if (lngReg > 0)
            {
                m_intBedCount = 0;
                m_intBedEmptyCount = 0;
                ListViewItem lviTemp;
                ListViewItem[] lsvItemArr = new ListViewItem[p_objResultArr.Length];
                foreach (clsBedManageVO bedManageVO in p_objResultArr)
                {
                    lviTemp = new ListViewItem(bedManageVO.m_strCODE_CHR);
                    for (int i2 = 1; i2 <= 13; i2++)
                    {
                        lviTemp.SubItems.Add("");
                    }
                    m_mthFillItme(lviTemp, bedManageVO);
                    lsvItemArr[m_intBedCount] = lviTemp;
                    m_intBedCount++;
                }
                m_objViewer.m_lsvBedInfo.Items.AddRange(lsvItemArr);
                m_objViewer.m_lblBedNumber.Text = m_intBedCount.ToString();
                m_objViewer.m_lblEmptyBedNumber.Text = m_intBedEmptyCount.ToString();
                p_objResultArr = null;
            }
            else
            {
                MessageBox.Show("��ȡ��λ��Ϣʧ�ܣ���", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region ���ListViewItemm
        /// <summary>
        /// ���ListViewItemm
        /// </summary>
        /// <param name="lviTemp">ListViewItem</param>
        /// <param name="bedManageVO">��λ��ϢVO</param>
        private void m_mthFillItme(ListViewItem lviTemp, clsBedManageVO bedManageVO)
        {
            lviTemp.ToolTipText = " �������ţ�" + bedManageVO.m_strCODE_CHR + "\r\n";
            lviTemp.SubItems[1].Text = bedManageVO.m_strCODE_CHR;
            lviTemp.SubItems[13].Text = bedManageVO.m_strITEMNAME_VCHR + " " + bedManageVO.m_strRATE_MNY + "(Ԫ)";
            #region ������Ϣ
            if (bedManageVO.m_strSTATUS_INT == "2" || bedManageVO.m_strSTATUS_INT == "6") //ռ��
            {
                lviTemp.Text += "\n" + bedManageVO.m_strNAME_VCHR + m_intPatientStatus(bedManageVO.m_strPSTATUS_INT);
                lviTemp.SubItems[2].Text = bedManageVO.m_strINPATIENTID_CHR;
                lviTemp.SubItems[3].Text = bedManageVO.m_strNAME_VCHR + m_intPatientStatus(bedManageVO.m_strPSTATUS_INT);
                lviTemp.SubItems[4].Text = bedManageVO.m_strSEX_CHR;
                lviTemp.SubItems[5].Text = m_objAge.m_strGetAge(bedManageVO.m_strBIRTH_DAT);
                lviTemp.SubItems[6].Text = strGetState(bedManageVO.m_strSTATE_INT);
                lviTemp.SubItems[7].Text = bedManageVO.m_strMAINDOC;
                lviTemp.SubItems[8].Text = bedManageVO.m_strICD10DIAGTEXT_VCHR;
                lviTemp.SubItems[9].Text = bedManageVO.m_strINPATIENT_DAT;
                lviTemp.SubItems[10].Text = bedManageVO.m_strPAYTYPENAME_VCHR;
                lviTemp.SubItems[11].Text = bedManageVO.m_strNURSECATE;
                lviTemp.SubItems[12].Text = bedManageVO.m_strEATDICCATE;
                //�ж��Ƿ���ҽ������
                if (bedManageVO.m_strINTERNALFLAG_INT == "2")
                {
                    p_blnPretect = true;
                }

                //lviTemp.ImageIndex = intDisplayImageIndex(bedManageVO.m_strSTATE_INT, bedManageVO.m_strSEX_CHR, bedManageVO.m_strMAINDOC, bedManageVO.m_strICD10DIAGTEXT_VCHR, p_blnPretect, bedManageVO.m_strDIAGNOSEID_CHR);
                lviTemp.ImageIndex = intDisplayImageIndex(bedManageVO.m_strSTATE_INT, bedManageVO.m_strSEX_CHR, bedManageVO.m_strNURSECATE);

                lviTemp.ToolTipText += " ס  Ժ  �ţ�" + bedManageVO.m_strINPATIENTID_CHR + "\r\n" +
            " ����������" + bedManageVO.m_strNAME_VCHR + m_intPatientStatus(bedManageVO.m_strPSTATUS_INT) + "\r\n" +
            " �����Ա�" + bedManageVO.m_strSEX_CHR + "\r\n" +
            " �������䣺" + m_objAge.m_strGetAge(bedManageVO.m_strBIRTH_DAT) + "\r\n" +
            " ����״̬��" + strGetState(bedManageVO.m_strSTATE_INT) + "\r\n" +
            " ����ҽ����" + bedManageVO.m_strMAINDOC + "\r\n" +
            " ��Ժ��ϣ�" + bedManageVO.m_strICD10DIAGTEXT_VCHR + "\r\n" +
           " ��Ժʱ�䣺" + bedManageVO.m_strINPATIENT_DAT + "\r\n" +
            " �������" + bedManageVO.m_strPAYTYPENAME_VCHR + "\r\n" +
            " ������" + bedManageVO.m_strNURSECATE + "\r\n" +
            " ��ʳ���ͣ�" + bedManageVO.m_strEATDICCATE + "\r\n";
            }
            else
            {
                if (bedManageVO.m_strSTATUS_INT == "4") //����
                {
                    lviTemp.Text += "\n(" + bedManageVO.m_strWRAPBED + "����)";
                    lviTemp.ToolTipText += " ����״̬: ����\r\n";
                }
                else //�մ�
                {
                    //lviTemp.Text += "\n�մ�";
                    lviTemp.ToolTipText += " ����״̬: �մ�\r\n";
                    m_intBedEmptyCount++;
                }
                lviTemp.ImageIndex = 0;
                lviTemp.ToolTipText += " �����Ա�: " + bedManageVO.m_strSEXNAME + "\r\n" +
                    " ��������: " + bedManageVO.m_strCATEGORYNAME + "\r\n";
            }
            #endregion
            lviTemp.ToolTipText += " ��  λ  �ѣ�" + bedManageVO.m_strITEMNAME_VCHR + " " + bedManageVO.m_strRATE_MNY + "(Ԫ)\r\n" +
            " ��  ��  �ѣ�" + bedManageVO.m_strAIRCHARGEITEM + " " + bedManageVO.m_strAIRRATE_MNY + "(Ԫ)\r\n";
            lviTemp.Tag = bedManageVO;
        }
        #endregion

        #region ������ʾͼ��
        /// <summary>
        /// ȷ����ʾͼƬ
        /// </summary>
        /// <param name="BedState">//��ǰ״̬��{1�մ���2ռ����3ԤԼռ����4����ռ��}</param>
        /// <param name="Sex">�Ա�</param>
        /// <param name="p_strMainDoc">����ҽ��</param>
        ///  <param name="p_strICD10">��Ժ���ICD10</param>
        ///  <param name="p_blnProtect">�Ƿ�ҽ������</param>
        ///  <param name="p_strProtect">��Ժ���(ҽ��)</param>
        /// <returns></returns>
        private int intDisplayImageIndex(string Status, string Sex, string p_strMainDoc, string p_strICD10, bool p_blnProtect, string p_strProtect)
        {
            //״̬����ͨ	���ͣ��д�	
            if (Status.Equals("3") && (Sex.Equals("Ů") || Sex.Equals("����")))
            {
                if (p_blnProtect)
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals("") || p_strProtect.Equals(""))
                    {
                        return 7;
                    }
                    else
                    {
                        return 1;
                    }
                }
                else
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals(""))
                    {
                        return 7;
                    }
                    else
                    {
                        return 1;
                    }
                }
            }
            //״̬��Σ	���ͣ�Ů��	
            if (Status.Equals("1") && (Sex.Equals("Ů") || Sex.Equals("����")))
            {
                if (p_blnProtect)
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals("") || p_strProtect.Equals(""))
                    {
                        return 8;
                    }
                    else
                    {
                        return 2;
                    }
                }
                else
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals(""))
                    {
                        return 8;
                    }
                    else
                    {
                        return 2;
                    }
                }

            }

            //״̬����	���ͣ�����
            if (Status.Equals("2") && (Sex.Equals("Ů") || Sex.Equals("����")))
            {
                if (p_blnProtect)
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals("") || p_strProtect.Equals(""))
                    {
                        return 9;
                    }
                    else
                    {
                        return 3;
                    }
                }
                else
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals(""))
                    {
                        return 9;
                    }
                    else
                    {
                        return 3;
                    }
                }

            }

            //״̬����ͨ	���ͣ��д�
            if (Status.Equals("3") && Sex.Equals("��"))
            {
                if (p_blnProtect)
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals("") || p_strProtect.Equals(""))
                    {
                        return 10;
                    }
                    else
                    {
                        return 4;
                    }
                }
                else
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals(""))
                    {
                        return 10;
                    }
                    else
                    {
                        return 4;
                    }
                }
            }

            //״̬��Σ	���ͣ�Ů��	
            if (Status.Equals("1") && Sex.Equals("��"))
            {
                if (p_blnProtect)
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals("") || p_strProtect.Equals(""))
                    {
                        return 11;
                    }
                    else
                    {
                        return 5;
                    }
                }
                else
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals(""))
                    {
                        return 11;
                    }
                    else
                    {
                        return 5;
                    }
                }
            }

            //״̬����	���ͣ�����
            if (Status.Equals("2") && Sex.Equals("��"))
            {
                if (p_blnProtect)
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals("") || p_strProtect.Equals(""))
                    {
                        return 12;
                    }
                    else
                    {
                        return 6;
                    }
                }
                else
                {
                    if (p_strMainDoc.Equals("") || p_strICD10.Equals(""))
                    {
                        return 12;
                    }
                    else
                    {
                        return 6;
                    }
                }
            }
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

        #region ��ʶת��
        /// <summary>
        /// ����: 1-Σ��2-����3-��ͨ
        /// </summary>
        /// <param name="p_intState">��ʶID</param>
        /// <returns></returns>
        private string strGetState(string p_strState)
        {
            switch (p_strState)
            {
                case "1":
                    return "Σ";
                case "2":
                    return "��";
                case "3":
                    return "��ͨ";
                default:
                    return "";
            }
        }

        /// <summary>
        /// ����	��String - Int��
        /// </summary>
        /// <param name="p_intState">���� {1Σ��2����3��ͨ}</param>
        /// <returns></returns>
        private string m_intGetIntState(string p_strState)
        {
            switch (p_strState)
            {
                case "Σ":
                    return "1";
                case "��":
                    return "2";
                case "��ͨ":
                    return "3";
                default:
                    return "2";
            }
        }
        /// <summary>
        /// סԺ״̬ת��:0-δ�ϴ���1=���ϴ���2-Ԥ��Ժ��3-ʵ�ʳ�Ժ��4-���
        /// </summary>
        /// <param name="p_strFlag">��ʶID</param>
        /// <returns></returns>
        private string m_intPatientStatus(string p_strFlag)
        {
            switch (p_strFlag)
            {
                case "2":
                    return "(Ԥ��Ժ)";
                case "4":
                    return "(���)";
                default:
                    return "";
            }
        }
        #endregion

        #region �Ϸ�ת��
        /// <summary>
        /// �Ϸ�ת��
        /// </summary>
        /// <param name="livSourceItem">ԭ��λ��</param>
        /// <param name="livTargetItem">Ŀ�괲λ��</param>
        public void m_cmdTransfer(ListViewItem livSourceItem, ListViewItem livTargetItem)
        {
            long lngReg = 0;
            clsBedManageVO souBedVO = (clsBedManageVO)livSourceItem.Tag;
            clsBedManageVO tarBedVO = (clsBedManageVO)livTargetItem.Tag;

            if (souBedVO.m_strSTATUS_INT == "1")
            {
                MessageBox.Show(m_objViewer, "�մ�����ת������!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tarBedVO.m_strSTATUS_INT != "1" && tarBedVO.m_strSTATUS_INT != "6")
            {
                MessageBox.Show(m_objViewer, "ֻ��ת���մ�!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsT_Opr_Bih_Transfer_VO objTransferVO = new clsT_Opr_Bih_Transfer_VO();
            objTransferVO.m_strSOURCEDEPTID_CHR = m_strDeptID;
            objTransferVO.m_strSOURCEAREAID_CHR = m_strAreaID;
            objTransferVO.m_strSOURCEBEDID_CHR = souBedVO.m_strBEDID_CHR;
            objTransferVO.m_strTARGETDEPTID_CHR = m_strDeptID;
            objTransferVO.m_strTARGETAREAID_CHR = m_strAreaID;
            objTransferVO.m_strTARGETBEDID_CHR = tarBedVO.m_strBEDID_CHR;
            objTransferVO.m_strREGISTERID_CHR = souBedVO.m_strREGISTERID_CHR;
            objTransferVO.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
            objTransferVO.m_intTYPE_INT = 2;
            if (objsystempower.isHasRight("סԺ.����ת.ת��"))
            {
                try
                {
                    lngReg = m_objManage.m_lngTurnBed(objTransferVO);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "��", "ת��", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show(m_objViewer, "���]��Ȩ��");
            }
            m_mthGetBidInfoByArearID();
        }
        /// <summary>
        /// ������֤ {1��ԭ������ռ����2��Ŀ�괲����Ϊ�մ���3����������Ӧ[�Ա�]��}
        /// </summary>
        /// <param name="livSourceItem"></param>
        /// <param name="livTargetItem"></param>
        /// <returns></returns>
        private bool IsPassInputValidate(ListViewItem livSourceItem, ListViewItem livTargetItem)
        {
            //1��ԭ������ռ����
            if (livSourceItem.SubItems[1].Text.Trim() == "�մ�")
            {
                MessageBox.Show(m_objViewer, "�մ�����ת������!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //2��Ŀ�괲����Ϊ�մ���
            if (livTargetItem.SubItems[1].Text.Trim() != "�մ�")
            {
                MessageBox.Show(m_objViewer, "ֻ��ת���մ�!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //3����������Ӧ[�Ա�]��

            return true;
        }

        #region �ؼ���ֵ��Vo
        /// <summary>
        /// �ؼ���ֵ��Vo  {��ת}
        /// </summary>
        /// <param name="objPatientVO">[clsT_Opr_Bih_Transfer_VO]</param>
        /// <param name="strSourceBedID">ԭ������ˮ��</param>
        /// <param name="strTargetBedID">Ŀ�겡����ˮ��</param>
        /// <param name="strREGISTERID">������Ժ�Ǽ���ˮ��</param>
        private void ValueToVoForTransfer(out clsT_Opr_Bih_Transfer_VO objPatientVO, string strSourceBedID, string strTargetBedID, string strREGISTERID)
        {
            objPatientVO = new clsT_Opr_Bih_Transfer_VO();
            //Դ����id
            objPatientVO.m_strSOURCEDEPTID_CHR = m_strDeptID;
            //Դ����id
            objPatientVO.m_strSOURCEAREAID_CHR = m_strAreaID;
            //Դ����id
            objPatientVO.m_strSOURCEBEDID_CHR = strSourceBedID;
            //Ŀ�����id
            objPatientVO.m_strTARGETDEPTID_CHR = m_strDeptID;
            //Ŀ�겡��id
            objPatientVO.m_strTARGETAREAID_CHR = m_strAreaID;
            //Ŀ�겡��id
            objPatientVO.m_strTARGETBEDID_CHR = strTargetBedID;
            //��������{1=ת��2=����3=ת��+����4=��Ժ����}			
            objPatientVO.m_intTYPE_INT = 2;
            //��ע
            objPatientVO.m_strDES_VCHR = "";
            //������
            objPatientVO.m_strOPERATORID_CHR = m_strOperatorID;
            //��Ժ�Ǽ���ˮ��(200409010001)
            objPatientVO.m_strREGISTERID_CHR = strREGISTERID;
            //�޸����ڣ���������
            objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region ͬ�����Ӳ���VO��ֵ
        private long SetVOValues(out iCareData.clsInDeptInfo objInDeptInfo)
        {
            objInDeptInfo = new iCareData.clsInDeptInfo();
            com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Transfer_VO objResult = null;
            long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetTransferInfoByRegisterID(m_strRegister, out objResult);
            if (lngRes < 0)
            {
                return -1;
            }
            //סԺ��Ϣ
            com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Register_VO objInHosPitalInfo = null;
            //��λ��Ϣ
            com.digitalwave.iCare.ValueObject.clsT_Bse_Bed_VO objBedInfo = null;
            //������Ϣ
            com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO objAreaInfo = null;
            lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetPatientRegisterInfoByID(m_strRegister, out objInHosPitalInfo);
            if (lngRes < 0)
            {
                return -1;
            }
            lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetBedInfoByID(m_stringTargetBedID, out objBedInfo);
            if (lngRes < 0)
            {
                return -1;
            }
            lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfoByID(m_strAreaID, out objAreaInfo);
            if (lngRes < 0)
            {
                return -1;
            }
            //���벡��ʱ��
            if (objResult.m_strMODIFY_DAT != "" && objResult.m_strSOURCEAREAID_CHR != m_strAreaID)
            {
                objInDeptInfo.m_dtmBegin_Date_Area_Dept = Convert.ToDateTime(objResult.m_strMODIFY_DAT);
            }
            //�ϴ�ʱ��
            objInDeptInfo.m_dtmBegin_Date_Bed_Room = System.DateTime.Now;
            //���벡��ʱ��
            objInDeptInfo.m_dtmBegin_Date_Room_Area = System.DateTime.Now;
            objInDeptInfo.m_dtmInBedEndDate = Convert.ToDateTime("1900-1-1");
            //��Ժʱ��
            if (objInHosPitalInfo.m_strINPATIENT_DAT != "")
            {
                objInDeptInfo.m_dtmInPatientDate = Convert.ToDateTime(objInHosPitalInfo.m_strINPATIENT_DAT);
            }
            //�޸�ʱ��
            objInDeptInfo.m_dtmModifyDate = System.DateTime.Now;
            //����ID
            objInDeptInfo.m_strArea_ID = objAreaInfo.m_strSHORTNO_CHR;
            objInDeptInfo.m_strRoom_ID = new com.digitalwave.iCare.gui.HIS.clsDcl_BedAdmin().m_mlngGetEMRroomIDBYAREAID(objInDeptInfo.m_strArea_ID);
            objInDeptInfo.m_strBed_ID = new com.digitalwave.iCare.gui.HIS.clsDcl_BedAdmin().m_mlngGetEMRbedIDBYbedcode(objInDeptInfo.m_strRoom_ID, objBedInfo.m_strCODE_CHR);
            //����ID
            //			objInDeptInfo.m_strBed_ID = objBedInfo.m_strCODE_CHR;
            //			string bed = objInDeptInfo.m_strBed_ID;
            //			Hashtable ht = this.getHt();
            //			string room = ht[bed].ToString();
            //����ID
            com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO objdept;
            lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfoByID(objAreaInfo.m_strPARENTID, out objdept);
            if (lngRes < 0)
            {
                return -1;
            }
            objInDeptInfo.m_strInDeptID = objdept.m_strSHORTNO_CHR;
            //����ID
            objInDeptInfo.m_strInPatientID = objInHosPitalInfo.m_strINPATIENTID_CHR;
            //����
            //			objInDeptInfo.m_strRoom_ID = room;
            return 1;
        }
        #endregion
        #endregion

        #region ����ת��δ�����ղ���
        /// <summary>
        /// ����ת��δ�����ղ���
        /// </summary>
        internal void UndoTransferOut()
        {
            if (m_objViewer.m_lsvTurnOutNA.SelectedItems.Count > 0)
            {
                clsTransferVO m_objTranfer = (clsTransferVO)m_objViewer.m_lsvTurnOutNA.SelectedItems[0].Tag;
                frmUndoTransferOut objfrm = new frmUndoTransferOut();
                long lngRes = 0;
                clsT_Bse_Bed_VO[] objBedArr;
                try
                {
                    lngRes = m_objManage.m_lngGetBedShortInfoByAreaID(m_strAreaID, "1", out objBedArr);
                    if (lngRes > 0)
                    {
                        objfrm.m_cboEmptyBed.DataSource = objBedArr;
                        objfrm.m_cboEmptyBed.DisplayMember = "m_strGetBedCODE";
                        objfrm.m_cboEmptyBed.ValueMember = "m_strGetBedID";
                    }
                    objfrm.m_cboEmptyBed.SelectedValue = m_objTranfer.m_strSOURCEBEDID_CHR;
                    if (objfrm.m_cboEmptyBed.SelectedItem == null && objfrm.m_cboEmptyBed.Items.Count > 0)
                    {
                        objfrm.m_cboEmptyBed.SelectedIndex = 0;
                    }
                    if (objfrm.ShowDialog() == DialogResult.OK)
                    {
                        if (objfrm.m_cboEmptyBed.SelectedItem == null)
                        {
                            MessageBox.Show("��λΪ��ѡ�", "����ת��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        clsT_Opr_Bih_Transfer_VO p_objRecord = new clsT_Opr_Bih_Transfer_VO();
                        p_objRecord.m_strSOURCEDEPTID_CHR = m_strDeptID;
                        p_objRecord.m_strSOURCEAREAID_CHR = m_strAreaID;
                        p_objRecord.m_strSOURCEBEDID_CHR = m_objTranfer.m_strSOURCEBEDID_CHR;
                        p_objRecord.m_strTARGETDEPTID_CHR = m_strDeptID;
                        p_objRecord.m_strTARGETAREAID_CHR = m_strAreaID;
                        p_objRecord.m_strTARGETBEDID_CHR = (string)objfrm.m_cboEmptyBed.SelectedValue;
                        p_objRecord.m_strREGISTERID_CHR = m_objTranfer.m_strREGISTERID_CHR;
                        p_objRecord.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                        p_objRecord.m_intTYPE_INT = 2;
                        p_objRecord.m_strTRANSFERID_CHR = m_objTranfer.m_strTRANSFERID_CHR;
                        m_objManage.m_lngUnDoTurnOut(p_objRecord);
                        MessageBox.Show("�����ɹ���", "����ת��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadAreaTransferInfo();
                        m_mthGetBidInfoByArearID();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "����ת��");
                }
            }
        }
        #endregion

        #region ���Ӵ�λ
        /// <summary>
        /// ���Ӵ�λ
        /// </summary>
        public void m_AddBed()
        {
            //û�в����򷵻�
            if (m_strAreaID.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "��ѡ����Ҫ�Ӵ��Ĳ���!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmAddBed objfrmAddBed = new frmAddBed(m_strAreaID);
            objfrmAddBed.m_txtDepName.Text = m_objViewer.m_lblDEPTNAME_VCHR.Text;
            objfrmAddBed.m_txtAreaName.Text = m_objViewer.m_lblPatientArea.Text;
            objfrmAddBed.ShowDialog();
            //��ListView�м��ش�λ��������Ϣ
            if (objfrmAddBed.DialogResult == DialogResult.OK)
            {
                m_mthGetBidInfoByArearID();
            }
        }
        #endregion

        #region �༭��λ
        /// <summary>
        /// �༭��λ
        /// </summary>
        public void m_mthEditBedInfo()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                clsBedManageVO bedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                frmAddBed objfrmEditBed = new frmAddBed(bedVO.m_strBEDID_CHR, "df");
                objfrmEditBed.m_txtDepName.Text = m_objViewer.m_lblDEPTNAME_VCHR.Text;
                objfrmEditBed.m_txtAreaName.Text = m_objViewer.m_lblPatientArea.Text;
                if (objfrmEditBed.ShowDialog() == DialogResult.OK)
                {
                    m_mthGetBidInfoByArearID();
                }
                objfrmEditBed = null;
            }
        }
        #endregion

        #region ���ݴ�λIDɾ����λ
        /// <summary>
        /// ���ݴ�λIDɾ����λ
        /// </summary>
        public void m_mthDeleteBedInfoByByBedID()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                try
                {
                    clsBedManageVO bedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                    string strMessage = "ȷ��Ҫɾ��������" + m_objViewer.m_lblPatientArea.Text.Trim() + "���Ĵ�λ��" + bedVO.m_strCODE_CHR + "����?";
                    if (MessageBox.Show(strMessage, "ɾ����λ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    long lngRes = m_objManage.m_lngDeleteBedInfoByByBedID(bedVO.m_strBEDID_CHR);
                    if (lngRes > 0)
                    {
                        MessageBox.Show("ɾ���ɹ���", "ɾ����λ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.m_lsvBedInfo.SelectedItems[0].Remove();
                        m_mthFreshBedCount();
                    }
                    else
                    {
                        MessageBox.Show("ɾ��ʧ�ܣ�", "ɾ����λ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "��", "ɾ����λʧ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region ת��
        /// <summary>
        /// ת��
        /// </summary>
        public void m_TurnIn()
        {
            string p_strBedID = "";
            string p_strRegistID = "";
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                clsBedManageVO bedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                if (bedVO.m_strSTATUS_INT == "1" || bedVO.m_strSTATUS_INT == "6")
                {
                    p_strBedID = bedVO.m_strBEDID_CHR;
                }
            }
            if (m_objViewer.m_lsvTurnInNA.SelectedItems.Count > 0)
            {
                p_strRegistID = m_objViewer.m_lsvTurnInNA.SelectedItems[0].Tag.ToString();
            }
            frmTurnIn objfrmTurnIn = new frmTurnIn(m_strDeptID, m_strAreaID, p_strBedID, p_strRegistID);
            objfrmTurnIn.m_lblDEPTNAME_VCHR.Text = m_objViewer.m_lblDEPTNAME_VCHR.Text;
            objfrmTurnIn.m_lblAREAName.Text = m_objViewer.m_lblPatientArea.Text;
            objfrmTurnIn.ShowDialog();
            if (objfrmTurnIn.DialogResult == DialogResult.OK)
            {
                m_mthGetBidInfoByArearID();
                loadAreaTransferInfo();
            }
        }
        #endregion

        #region ��ʾ������ϸ��Ϣ
        /// <summary>
        /// ��ʾ������ϸ��Ϣ
        /// </summary>
        public void m_EditBed()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                clsBedManageVO bedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                if (bedVO.m_strSTATUS_INT == "2" || bedVO.m_strSTATUS_INT == "5")
                {
                    frmEditBed objfrmEditBed = new frmEditBed(bedVO);
                    if (objfrmEditBed.ShowDialog() == DialogResult.OK)
                    {
                        m_mthGetBidInfoByArearID();
                    }
                    objfrmEditBed = null;
                }
                else
                {
                    //m_mthEditBedInfo();
                }
            }
        }
        #endregion

        #region ת����
        /// <summary>
        /// ת����
        /// </summary>
        public void m_TurnOut()
        {
            //û�в����򷵻�
            if (m_strAreaID.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "��ѡ����!", "ת����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //û��ѡ���򷵻�
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "��ѡ��Ҫת���Ĳ���!", "ת����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            //û����Ժ�Ǽ���ˮ���򷵻� 
            if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "û�л�����Ϣ!\n������ת������!", "ת����", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //bool hasNotExcOrder;
            clsDclBihLeaHos leaHosDomain = new clsDclBihLeaHos();
            //����Ƿ������Ϊִ�е�ҽ��
            long lngRes;
            int count;
            ArrayList arrCreator;

            lngRes = leaHosDomain.GetOrderNotExc(m_objBedVO.m_strREGISTERID_CHR, out count, out arrCreator);

            if (arrCreator.Count > 0)
            {

                string strDoctors = GetNewOrderDoctorList(arrCreator);
                MessageBox.Show(m_objViewer, "�ò�����ҽ����" + strDoctors + " �¿���ҽ��δ�ύ��", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (count > 0)
            {
                MessageBox.Show(m_objViewer, "�ò�������δִ�е�ҽ����", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region ת����Ԥ��Ժʱ�԰�����Ϣ���д���
            //ת����Ԥ��Ժʱ�԰�����Ϣ���д��� 2007.09.03 л�ƽ� ���
            int intRowCount = 0;
            lngRes = m_objManage.m_lngGetWarpBedByRegID(m_objBedVO.m_strREGISTERID_CHR, ref intRowCount);//��ȡ�ò��˵İ�����Ϣ
            if (lngRes > 0)
            {
                if (intRowCount > 0)
                {
                    if (MessageBox.Show(m_objViewer, "�ò��˻����ڰ�����Ϣ��\r\n\r\n ���[ȷ��] ��ɾ���ò������а�����Ϣ��\r\n\r\n���[ȡ��] ���ز���", "��ʾ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        //ɾ�����а���
                        lngRes = m_objManage.m_lngUndoWarpBedByRegID(m_objBedVO.m_strREGISTERID_CHR, m_objViewer.LoginInfo.m_strEmpID);
                        if (lngRes < 0)
                        {
                            MessageBox.Show(m_objViewer, "��������ʧ��", "��ʾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                    m_mthGetBidInfoByArearID();
                }
            }
            else
            {
                MessageBox.Show(m_objViewer, "��ѯ�ò��˰�����Ϣʧ�ܡ�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            frmTurnOut objfrmTurnOut = new frmTurnOut(m_objBedVO, m_strDeptID, m_strAreaID, m_objViewer.m_lblPatientArea.Text);
            objfrmTurnOut.ShowDialog();
            if (objfrmTurnOut.DialogResult == DialogResult.OK)
            {
                m_mthGetBidInfoByArearID();
                loadAreaTransferInfo();
            }
        }
        #endregion

        #region ��Ժ
        /// <summary>
        /// ��Ժ
        /// </summary>
        public void m_LeaveHospital()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "��ѡ��Ҫ��Ժ�Ļ���!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "û�л�����Ϣ!\n����ʧ��!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region ת����Ԥ��Ժʱ�԰�����Ϣ���д���
            //ת����Ԥ��Ժʱ�԰�����Ϣ���д��� 2007.09.03 л�ƽ� ���
            int intRowCount = 0;
            long lngRes = m_objManage.m_lngGetWarpBedByRegID(m_objBedVO.m_strREGISTERID_CHR, ref intRowCount);//��ȡ�ò��˵İ�����Ϣ
            if (lngRes > 0)
            {
                if (intRowCount > 0)
                {
                    if (MessageBox.Show(m_objViewer, "�ò��˻����ڰ�����Ϣ��\r\n\r\n ���[ȷ��] ��ɾ���ò������а�����Ϣ��\r\n\r\n���[ȡ��] ����������������������", "��ʾ��", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        //ɾ�����а���
                        lngRes = m_objManage.m_lngUndoWarpBedByRegID(m_objBedVO.m_strREGISTERID_CHR, m_objViewer.LoginInfo.m_strEmpID);
                        if (lngRes < 0)
                        {
                            MessageBox.Show(m_objViewer, "��������ʧ��", "��ʾ��", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    m_mthGetBidInfoByArearID();
                }
            }
            else
            {
                MessageBox.Show(m_objViewer, "��ѯ�ò��˰�����Ϣʧ�ܡ�", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            //bool hasNotExcOrder;
            clsDclBihLeaHos leaHosDomain = new clsDclBihLeaHos();
            //����Ƿ������Ϊִ�е�����
            int count;
            ArrayList arrCreator;

            lngRes = leaHosDomain.GetOrderNotExc(m_objBedVO.m_strREGISTERID_CHR, out count, out arrCreator);

            if (arrCreator.Count > 0)
            {
                string strDoctors = GetNewOrderDoctorList(arrCreator);
                MessageBox.Show(m_objViewer, "�ò�����ҽ����" + strDoctors + " �¿���ҽ��δ�ύ��", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (count > 0)
            {
                MessageBox.Show(m_objViewer, "�ò�������δִ�е�ҽ�������ܳ�Ժ��", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //frmBIHLeave objfrmBIHLeave = new frmBIHLeave(m_objBedVO.m_strREGISTERID_CHR, m_strDeptID, m_strAreaID, m_objBedVO.m_strBEDID_CHR);
            frmBIHLeave objfrmBIHLeave = new frmBIHLeave(m_objBedVO, m_strDeptID, m_strAreaID, m_objBedVO.m_strBEDID_CHR);
            objfrmBIHLeave.m_lblPatientName.Text = m_objBedVO.m_strNAME_VCHR;
            objfrmBIHLeave.m_lblDEPTID_CHR.Text = m_objViewer.m_lblDEPTNAME_VCHR.Text;
            objfrmBIHLeave.m_lblAREAID_CHR.Text = m_objViewer.m_lblPatientArea.Text;
            objfrmBIHLeave.m_lblBEDID_CHR.Text = m_objBedVO.m_strBEDID_CHR;
            objfrmBIHLeave.m_cbmTYPE.SelectedIndex = 1;
            objfrmBIHLeave.m_cbmPSTATUS_INT.SelectedIndex = 1;
            objfrmBIHLeave.ShowDialog();
            m_mthGetBidInfoByArearID();
        }

        private string GetNewOrderDoctorList(ArrayList arrCreator)
        {
            string m_strCreator = "";
            for (int i = 0; i < arrCreator.Count; i++)
            {
                m_strCreator += arrCreator[i].ToString() + ",";
            }
            m_strCreator = m_strCreator.TrimEnd(",".ToCharArray());
            return m_strCreator;
        }


        #endregion

        #region ֱ�ӳ�Ժ
        /// <summary>
        /// ֱ�ӳ�Ժ
        /// </summary>
        public void LeaveHospitalNoCheck()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "��ѡ��Ҫ��Ժ�Ļ���!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "û�л�����Ϣ!\n����ʧ��!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //bool hasNotExcOrder;
            clsDclBihLeaHos leaHosDomain = new clsDclBihLeaHos();
            //����Ƿ������Ϊִ�е�����
            long lngRes;
            // lngRes = leaHosDomain.GetOrderNotExc(m_objBedVO.m_strREGISTERID_CHR, 2, out hasNotExcOrder);
            int count;
            ArrayList arrCreator;

            lngRes = leaHosDomain.GetOrderNotExc(m_objBedVO.m_strREGISTERID_CHR, out count, out arrCreator);

            //if (arrCreator.Count > 0)
            //{
            //    MessageBox.Show(m_objViewer, "�ò�����ҽ����" + arrCreator.ToString() + " �¿���ҽ��δ�ύ��", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (count > 0)
            //{
            //    MessageBox.Show(m_objViewer, "�ò�������δִ�е�ҽ����", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}            

            if (count > 0)
            {
                MessageBox.Show(m_objViewer, "�ò�������δִ�е���ʱҽ�������ܳ�Ժ��", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dlgRes = MessageBox.Show("ȷ������" + m_objBedVO.m_strNAME_VCHR + "����Ժ��", "��ʾ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dlgRes == DialogResult.No)
            {
                return;
            }

            //frmBIHLeave objfrmBIHLeave = new frmBIHLeave(m_objBedVO.m_strREGISTERID_CHR, m_strDeptID, m_strAreaID, m_objBedVO.m_strBEDID_CHR);
            frmBIHLeave objfrmBIHLeave = new frmBIHLeave(m_objBedVO, m_strDeptID, m_strAreaID, m_objBedVO.m_strBEDID_CHR);
            objfrmBIHLeave.m_lblPatientName.Text = m_objBedVO.m_strNAME_VCHR;
            objfrmBIHLeave.m_lblDEPTID_CHR.Text = m_objViewer.m_lblDEPTNAME_VCHR.Text;
            objfrmBIHLeave.m_lblAREAID_CHR.Text = m_objViewer.m_lblPatientArea.Text;
            objfrmBIHLeave.m_lblBEDID_CHR.Text = m_objBedVO.m_strBEDID_CHR;
            objfrmBIHLeave.m_cbmTYPE.SelectedIndex = 1;
            objfrmBIHLeave.m_cbmPSTATUS_INT.SelectedIndex = 2;
            objfrmBIHLeave.ShowDialog();
            m_mthGetBidInfoByArearID();
        }
        #endregion

        #region ���
        /// <summary>
        /// ���
        /// </summary>
        public void m_mthHoliday()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                if (m_objBedVO.m_strPSTATUS_INT == "1")
                {
                    frmHolday frm = new frmHolday(m_objBedVO);
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        m_mthGetBidInfoByArearID();
                    }
                }
            }
        }
        #endregion

        #region ����Ԥ��Ժ/���
        /// <summary>
        /// ����Ԥ��Ժ/���
        /// </summary>
        /// <returns></returns>
        public long m_lngUndoOutHospital()
        {
            long lngRes = 0;
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                if (m_objBedVO.m_strPSTATUS_INT == "2")  //����Ԥ��Ժ
                {
                    if (MessageBox.Show("ȷ�ϳ���Ԥ��Ժô��", "����Ԥ��Ժ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            //com.digitalwave.iCare.gui.HIS.clsDcl_Register objService = new clsDcl_Register();
                            //lngRes = objService.m_lngModifyBihRegisterPSTATUS_INTByRegisterID(m_objBedVO.m_strREGISTERID_CHR, 1, m_strOperatorID);
                            clsDclBihLeaHos objDomain = new clsDclBihLeaHos();
                            lngRes = objDomain.CancelPreLeaved(m_objBedVO.m_strREGISTERID_CHR, this.m_strOperatorID);
                            if (lngRes > 0)
                            {
                                MessageBox.Show("�����ɹ�!", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                m_objBedVO.m_strPSTATUS_INT = "1";
                                m_objBedVO.m_strSTATUS_INT = "2";
                                m_objBedVO.m_strSTATUSNAME = "ռ��";
                                m_objViewer.m_lsvBedInfo.SelectedItems[0].Text = m_objViewer.m_lsvBedInfo.SelectedItems[0].Text.Replace("(Ԥ��Ժ)", "");
                                m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag = m_objBedVO;
                                m_objViewer.m_cmdUndoOut.Text = "����";
                                m_objViewer.m_cmdUndoOut.Enabled = false;
                                m_objViewer.cmdLeaveHospital.Enabled = true;

                                //ˢ������
                                m_mthGetBidInfoByArearID();
                                loadAreaTransferInfo();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "����Ԥ��Ժʧ��");
                        }
                    }
                }
                else if (m_objBedVO.m_strPSTATUS_INT == "4") //�������
                {
                    if (MessageBox.Show("ȷ�ϳ������ô��", "�������", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {

                            clsHolidayRecord_VO p_objRecord = new clsHolidayRecord_VO();
                            p_objRecord.m_intSTATUS_INT = 2;
                            p_objRecord.m_strBedID = m_objBedVO.m_strBEDID_CHR;
                            p_objRecord.m_strREGISTERID_CHR = m_objBedVO.m_strREGISTERID_CHR;
                            p_objRecord.m_strCANCELERID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                            m_objManage.m_lngUndoHoliday(p_objRecord);
                            m_objBedVO.m_strPSTATUS_INT = "1";
                            m_objBedVO.m_strSTATUS_INT = "2";
                            m_objBedVO.m_strSTATUSNAME = "ռ��";
                            m_objViewer.m_lsvBedInfo.SelectedItems[0].Text = m_objViewer.m_lsvBedInfo.SelectedItems[0].Text.Replace("(���)", "");
                            m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag = m_objBedVO;
                            m_objViewer.m_cmdUndoOut.Text = "����";
                            m_objViewer.m_cmdUndoOut.Enabled = false;

                            //ˢ������
                            //m_mthGetBidInfoByArearID();
                            //loadAreaTransferInfo();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "�������ʧ��");
                        }
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region ���벡��ת��ת����Ϣ
        /// <summary>
        /// ���벡��ת��ת����Ϣ
        /// </summary>
        internal void loadAreaTransferInfo()
        {
            switch (m_objViewer.tabControl1.SelectedIndex)
            {
                case 0:
                    m_mthGetTurnInNotAccept();
                    break;
                case 1:
                    m_mthGetTurnOutNotAccept();
                    break;
                case 2:
                    m_mthGetTurnInAccept();
                    break;
                case 3:
                    m_mthGetTurnOutAccept();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ����ת��δ���ղ���
        /// <summary>
        /// ����ת��δ���ղ���
        /// </summary>
        public void m_mthGetTurnInNotAccept()
        {
            m_objViewer.m_lsvTurnInNA.Items.Clear();
            DataTable p_dtbTurnInNA = null;
            long lngRes = m_objManage.m_lngGetTurnInNA(m_strAreaID, out p_dtbTurnInNA);
            if (lngRes > 0)
            {
                int index = 0;
                ListViewItem[] lsvItemArr = new ListViewItem[p_dtbTurnInNA.Rows.Count];
                foreach (DataRow dr in p_dtbTurnInNA.Rows)
                {
                    System.Windows.Forms.ListViewItem listviewitem = new ListViewItem(dr["areaname"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["inpatientid_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["name_vchr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["sex_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(m_objAge.m_strGetAge(dr["birth_dat"]));
                    listviewitem.SubItems.Add(dr["status"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["ICD10DIAGTEXT_VCHR"].ToString().Trim());
                    listviewitem.SubItems.Add(Convert.ToDateTime(dr["inpatient_dat"]).ToString("yyyy-MM-dd HH:mm"));
                    listviewitem.SubItems.Add(dr["type_int"].ToString().Trim());
                    listviewitem.SubItems.Add(Convert.ToDateTime(dr["HISINPATIENTDATE"]).ToString("yyyy��MM��dd�� HHʱmm��"));

                    listviewitem.Tag = dr["REGISTERID_CHR"].ToString().Trim();
                    lsvItemArr[index] = listviewitem;
                    index++;
                }
                m_objViewer.m_lsvTurnInNA.Items.AddRange(lsvItemArr);
                p_dtbTurnInNA = null;
            }
        }
        #endregion

        #region ����ת���ѽ��ղ���
        /// <summary>
        /// ����ת���ѽ��ղ���
        /// </summary>
        public void m_mthGetTurnInAccept()
        {
            m_objViewer.m_lsvTurnInA.Items.Clear();
            DataTable p_dtbTurnInA = null;
            long lngRes = m_objManage.m_lngGetTurnInA(m_strAreaID, out p_dtbTurnInA);
            if (lngRes > 0)
            {
                int index = 0;
                ListViewItem[] lsvItemArr = new ListViewItem[p_dtbTurnInA.Rows.Count];
                foreach (DataRow dr in p_dtbTurnInA.Rows)
                {
                    System.Windows.Forms.ListViewItem listviewitem = new ListViewItem(dr["areaname"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["inpatientid_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["name_vchr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["sex_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(m_objAge.m_strGetAge(dr["birth_dat"]));
                    listviewitem.SubItems.Add(dr["status"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["ICD10DIAGTEXT_VCHR"].ToString().Trim());
                    listviewitem.SubItems.Add(Convert.ToDateTime(dr["inpatient_dat"]).ToString("yyyy-MM-dd HH:mm"));
                    listviewitem.Tag = dr;
                    lsvItemArr[index] = listviewitem;
                    index++;
                }
                m_objViewer.m_lsvTurnInA.Items.AddRange(lsvItemArr);
                p_dtbTurnInA = null;
            }
        }
        #endregion

        #region ����ת��δ���ղ���
        /// <summary>
        /// ����ת��δ���ղ���
        /// </summary>
        public void m_mthGetTurnOutNotAccept()
        {
            m_objViewer.m_lsvTurnOutNA.Items.Clear();
            clsTransferVO[] p_objResultArr = null;
            long lngRes = m_objManage.m_lngGetTurnOutNA(m_strAreaID, out p_objResultArr);
            if (lngRes > 0)
            {
                int index = 0;
                ListViewItem[] lsvItemArr = new ListViewItem[p_objResultArr.Length];
                foreach (clsTransferVO m_objTransfer in p_objResultArr)
                {
                    System.Windows.Forms.ListViewItem listviewitem = new ListViewItem(m_objTransfer.m_strAREANAME);
                    listviewitem.SubItems.Add(m_objTransfer.m_strINPATIENTID_CHR);
                    listviewitem.SubItems.Add(m_objTransfer.m_strNAME_VCHR);
                    listviewitem.SubItems.Add(m_objTransfer.m_strSEX_CHR);
                    listviewitem.SubItems.Add(m_objAge.m_strGetAge(m_objTransfer.m_strBIRTH_DAT));
                    listviewitem.SubItems.Add(m_objTransfer.m_strSTATUS);
                    listviewitem.SubItems.Add(m_objTransfer.m_strICD10DIAGTEXT_VCHR);
                    listviewitem.SubItems.Add(m_objTransfer.m_strINPATIENT_DAT);
                    listviewitem.Tag = m_objTransfer;
                    lsvItemArr[index] = listviewitem;
                    index++;
                }
                m_objViewer.m_lsvTurnOutNA.Items.AddRange(lsvItemArr);
                p_objResultArr = null;
            }
        }
        #endregion

        #region ����ת���ѽ��ղ���
        /// <summary>
        /// ����ת���ѽ��ղ���
        /// </summary>
        public void m_mthGetTurnOutAccept()
        {
            m_objViewer.m_lsvTurnOutA.Items.Clear();
            DataTable p_dtbTurnOutA = null;
            long lngRes = m_objManage.m_lngGetTurnOutA(m_strAreaID, out p_dtbTurnOutA);
            if (lngRes > 0)
            {
                int index = 0;
                ListViewItem[] lsvItemArr = new ListViewItem[p_dtbTurnOutA.Rows.Count];
                foreach (DataRow dr in p_dtbTurnOutA.Rows)
                {
                    System.Windows.Forms.ListViewItem listviewitem = new ListViewItem(dr["areaname"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["inpatientid_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["name_vchr"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["sex_chr"].ToString().Trim());
                    listviewitem.SubItems.Add(m_objAge.m_strGetAge(dr["birth_dat"]));
                    listviewitem.SubItems.Add(dr["status"].ToString().Trim());
                    listviewitem.SubItems.Add(dr["ICD10DIAGTEXT_VCHR"].ToString().Trim());
                    listviewitem.SubItems.Add(Convert.ToDateTime(dr["inpatient_dat"]).ToString("yyyy-MM-dd HH:mm"));
                    lsvItemArr[index] = listviewitem;
                    index++;
                }
                m_objViewer.m_lsvTurnOutA.Items.AddRange(lsvItemArr);
                p_dtbTurnOutA = null;
            }
        }
        #endregion

        #region ����
        public void m_mthOccupyBed(string Bedid, string Registerid)
        {
            if (MessageBox.Show("ȷ�ϰ���ô��", "��λ����", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    m_objManage.m_lngWarpBed(Registerid, Bedid, m_objViewer.LoginInfo.m_strEmpID);
                    this.m_mthGetBidInfoByArearID();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "����ʧ�ܣ�");
                }
            }
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��������
        /// </summary>
        public void m_mthDelOccupBed()
        {
            if (MessageBox.Show("ȷ�ϳ�������ô��", "��λ����", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                try
                {
                    m_objManage.m_lngUndoWarpBed(m_objBedVO.m_strBEDID_CHR, m_objViewer.LoginInfo.m_strEmpID);
                    m_mthGetBidInfoByArearID();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "��������ʧ��");
                }
            }
        }
        #endregion

        #region	����סԺ�Ǽ�
        /// <summary>
        /// ����סԺ�Ǽ�
        /// </summary>
        public void m_mthRegidit()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count == 1)
            {
                clsBedManageVO m_objBeb = ((clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag);
                if (m_objBeb.m_strSTATUS_INT != "1")
                {
                    return;
                }
                // �����ڴ�λ����ģ���У��Ƿ�����ͨ����F3����ֱ�ӵ���סԺ�Ǽ�ģ��:0-��ֹ 1-����
                int p_intSetstatus;
                m_objManage.m_lngGetSetingByID("1005", out p_intSetstatus);
                if (p_intSetstatus != 1)
                {
                    return;
                }
                m_objViewer.Cursor = Cursors.WaitCursor;
                frmPatientRecord frm = new frmPatientRecord();
                frm.m_txtAREAID.Enabled = false;
                frm.ShowInTaskbar = false;
                frm.ShowIcon = false;
                frm.MaximizeBox = false;
                frm.Location = new System.Drawing.Point(0, 85);
                frm.StartPosition = FormStartPosition.Manual;
                frm.Size = new System.Drawing.Size(1030, 639);
                frm.FormBorderStyle = FormBorderStyle.FixedDialog;
                frm.m_txtAREAID.Value = m_strAreaID;
                frm.m_txtAREAID.Text = m_objViewer.m_lblPatientArea.Text;
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    clsT_Opr_Bih_Transfer_VO p_objRecord = new clsT_Opr_Bih_Transfer_VO();
                    p_objRecord.m_strTARGETDEPTID_CHR = m_strDeptID;
                    p_objRecord.m_strTARGETAREAID_CHR = m_strAreaID;
                    p_objRecord.m_strTARGETBEDID_CHR = m_objBeb.m_strBEDID_CHR;
                    p_objRecord.m_strREGISTERID_CHR = frm.m_strRegisterID;
                    p_objRecord.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                    try
                    {
                        m_objManage.m_lngArrangeBed(p_objRecord);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "��", "���Ŵ�λʧ��", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                    finally
                    {
                        m_mthGetBidInfoByArearID();
                    }
                }
                frm = null;
                m_objViewer.Cursor = Cursors.Default;
            }
        }
        #endregion

        #region ˢ�´�λ��
        /// <summary>
        /// ˢ�´�λ��
        /// </summary>
        private void m_mthFreshBedCount()
        {
            int intEmptyBedCount = 0;
            m_objViewer.m_lblBedNumber.Text = m_objViewer.m_lsvBedInfo.Items.Count.ToString();
            for (int i1 = 0; i1 < m_objViewer.m_lsvBedInfo.Items.Count; i1++)
            {
                if (((clsBedManageVO)m_objViewer.m_lsvBedInfo.Items[i1].Tag).m_strSTATUS_INT == "1")
                {
                    intEmptyBedCount++;
                }
            }
            m_objViewer.m_lblEmptyBedNumber.Text = intEmptyBedCount.ToString();
        }
        #endregion

        #region ���ݴ�λ״̬���ò���Ȩ��
        /// <summary>
        /// ���ݴ�λ״̬���ò���Ȩ��
        /// </summary>
        public void m_mthBedControl()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                clsBedManageVO bedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                m_objViewer.m_cmdHoliday.Enabled = false;
                if (bedVO.m_strSTATUS_INT == "1")
                {
                    m_objViewer.cmdTurnIn.Enabled = true;
                    m_objViewer.cmdLeaveHospital.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Enabled = false;
                    m_objViewer.cmdTurnOut.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Text = "����";
                }
                else if (bedVO.m_strSTATUS_INT == "4")
                {
                    m_objViewer.cmdTurnIn.Enabled = false;
                    m_objViewer.cmdLeaveHospital.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Enabled = false;
                    m_objViewer.cmdTurnOut.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Text = "����";
                }

                else if (bedVO.m_strSTATUS_INT == "6")
                {
                    m_objViewer.cmdTurnIn.Enabled = true;
                    m_objViewer.cmdLeaveHospital.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Enabled = true;
                    m_objViewer.cmdTurnOut.Enabled = true;
                    m_objViewer.m_cmdUndoOut.Text = "����Ԥ��Ժ";
                }

                else if (bedVO.m_strSTATUS_INT == "2")
                {
                    m_objViewer.cmdTurnOut.Enabled = true;
                    m_objViewer.cmdLeaveHospital.Enabled = true;
                    m_objViewer.m_cmdUndoOut.Enabled = false;
                    m_objViewer.cmdTurnIn.Enabled = false;

                    m_objViewer.m_cmdUndoOut.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Text = "����";

                    if (bedVO.m_strPSTATUS_INT == "1")
                    {
                        m_objViewer.m_cmdHoliday.Enabled = true;
                    }
                    //else if (bedVO.m_strPSTATUS_INT == "2")
                    //{
                    //    m_objViewer.m_cmdHoliday.Enabled = true;
                    //    m_objViewer.m_cmdUndoOut.Enabled = true;
                    //    m_objViewer.m_cmdUndoOut.Text = "����Ԥ��Ժ";
                    //}
                    else if (bedVO.m_strPSTATUS_INT == "4")
                    {
                        m_objViewer.m_cmdUndoOut.Enabled = true;
                        m_objViewer.m_cmdUndoOut.Text = "�������";
                    }
                    else
                    {
                        m_objViewer.m_cmdHoliday.Enabled = false;
                        m_objViewer.m_cmdUndoOut.Text = "����";
                    }
                }
            }
        }


        #endregion

        #region �Ҽ��˵�����
        /// <summary>
        /// �Ҽ��˵�����
        /// </summary>
        public void m_mthSetComtext()
        {
            //û��ѡ�д�λ
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count < 1)
            {
                //m_objViewer.BedAdmin.MenuItems[0].Visible = false; //�༭��λ
                //m_objViewer.BedAdmin.MenuItems[2].Visible = false; //����
                //m_objViewer.BedAdmin.MenuItems[3].Visible = false; //ת��
                //m_objViewer.BedAdmin.MenuItems[4].Visible = false; //ת��
                //m_objViewer.BedAdmin.MenuItems[5].Visible = false; //��Ժ
                //m_objViewer.BedAdmin.MenuItems[6].Visible = false; //ȡ����Ժ
                //m_objViewer.BedAdmin.MenuItems[7].Visible = true; //���Ӵ�λ
                //m_objViewer.BedAdmin.MenuItems[8].Visible = false; //��������
                //m_objViewer.BedAdmin.MenuItems[9].Visible = false; //ɾ����λ
                //m_objViewer.BedAdmin.MenuItems[11].Visible = false; //���
                //m_objViewer.BedAdmin.MenuItems[12].Visible = false; //�������

                //m_objViewer.BedAdmin.MenuItems[1].MenuItems[0].Visible = false;
                //m_objViewer.BedAdmin.MenuItems[1].MenuItems[1].Visible = false;
                //m_objViewer.BedAdmin.MenuItems[1].MenuItems[2].Visible = false;
                //m_objViewer.BedAdmin.MenuItems[1].MenuItems[4].Visible = false;

                m_objViewer.BedAdmin.MenuItems[0].Enabled = false; //ҽ��
                m_objViewer.BedAdmin.MenuItems[1].Enabled = false; //����

                m_objViewer.BedAdmin.MenuItems[3].Enabled = false; //ת��
                m_objViewer.BedAdmin.MenuItems[4].Enabled = false; //ת��
                m_objViewer.BedAdmin.MenuItems[5].Enabled = false; //ת��

                m_objViewer.BedAdmin.MenuItems[7].Enabled = false; //��Ժ
                m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //ȡ����Ժ
                m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //��Ժ֪ͨ

                m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //���
                m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //�������
                m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //��������

                m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //ˢ��

            }
            else //ѡ�д�λ
            {
                clsBedManageVO bedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                //m_objViewer.BedAdmin.MenuItems[11].Visible = false; //���
                //m_objViewer.BedAdmin.MenuItems[12].Visible = false; //�������
                //�մ�
                if (bedVO.m_strSTATUS_INT.Equals("1"))
                {
                    //m_objViewer.BedAdmin.MenuItems[0].Visible = true; //��Ժ�Ǽ�
                    //m_objViewer.BedAdmin.MenuItems[2].Visible = false; //����
                    //m_objViewer.BedAdmin.MenuItems[3].Visible = true; //ת��
                    //m_objViewer.BedAdmin.MenuItems[4].Visible = false; //ת��
                    //m_objViewer.BedAdmin.MenuItems[5].Visible = false; //��Ժ
                    //m_objViewer.BedAdmin.MenuItems[6].Visible = false; //������Ժ
                    //m_objViewer.BedAdmin.MenuItems[7].Visible = false; //���Ӵ�λ
                    //m_objViewer.BedAdmin.MenuItems[9].Visible = true; //ɾ����λ

                    //m_objViewer.BedAdmin.MenuItems["menuItemOrder"].Enabled = false; //ҽ��¼��
                    m_objViewer.BedAdmin.MenuItems[0].Enabled = false; //ҽ��
                    m_objViewer.BedAdmin.MenuItems[1].Enabled = false; //����

                    m_objViewer.BedAdmin.MenuItems[3].Enabled = true; //ת��
                    m_objViewer.BedAdmin.MenuItems[4].Enabled = false; //ת��
                    m_objViewer.BedAdmin.MenuItems[5].Enabled = false; //ת��

                    m_objViewer.BedAdmin.MenuItems[7].Enabled = false; //��Ժ
                    m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //ȡ����Ժ
                    m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //��Ժ֪ͨ

                    m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //���
                    m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //�������
                    m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //��������

                    m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //ˢ��
                }
                else //�ǿմ�
                {
                    //m_objViewer.BedAdmin.MenuItems[0].Visible = true; //��Ժ�Ǽ�
                    //m_objViewer.BedAdmin.MenuItems[2].Visible = false; //����
                    //m_objViewer.BedAdmin.MenuItems[3].Visible = false; //ת��
                    //m_objViewer.BedAdmin.MenuItems[4].Visible = true; //ת��
                    //m_objViewer.BedAdmin.MenuItems[5].Visible = true; //��Ժ

                    //m_objViewer.BedAdmin.MenuItems[7].Visible = false; //���Ӵ�λ
                    //m_objViewer.BedAdmin.MenuItems[9].Visible = false; //ɾ����λ

                    //m_objViewer.BedAdmin.MenuItems[1].MenuItems[1].Visible = true;
                    //m_objViewer.BedAdmin.MenuItems[1].MenuItems[2].Visible = true;
                    //m_objViewer.BedAdmin.MenuItems[1].MenuItems[4].Visible = true;



                    //if (bedVO.m_strPSTATUS_INT == "1" || bedVO.m_strPSTATUS_INT == "2")
                    if (bedVO.m_strPSTATUS_INT == "1")
                    {
                        //m_objViewer.BedAdmin.MenuItems[5].Visible = true; //��Ժ
                        //m_objViewer.BedAdmin.MenuItems[6].Visible = false;  //������Ժ
                        //m_objViewer.BedAdmin.MenuItems[11].Visible = true;
                        m_objViewer.BedAdmin.MenuItems[0].Enabled = true; //ҽ��
                        m_objViewer.BedAdmin.MenuItems[1].Enabled = true; //����

                        m_objViewer.BedAdmin.MenuItems[3].Enabled = false; //ת��
                        m_objViewer.BedAdmin.MenuItems[4].Enabled = true; //ת��
                        m_objViewer.BedAdmin.MenuItems[5].Enabled = true; //ת��

                        m_objViewer.BedAdmin.MenuItems[7].Enabled = true; //��Ժ
                        m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //ȡ����Ժ
                        m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //��Ժ֪ͨ

                        m_objViewer.BedAdmin.MenuItems[11].Enabled = true; //���
                        m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //�������
                        m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //��������

                        m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //ˢ��
                    }
                    else if (bedVO.m_strPSTATUS_INT == "4")
                    {
                        m_objViewer.BedAdmin.MenuItems[0].Enabled = true; //ҽ��
                        m_objViewer.BedAdmin.MenuItems[1].Enabled = true; //����

                        m_objViewer.BedAdmin.MenuItems[3].Enabled = false; //ת��
                        m_objViewer.BedAdmin.MenuItems[4].Enabled = false; //ת��
                        m_objViewer.BedAdmin.MenuItems[5].Enabled = false; //ת��

                        m_objViewer.BedAdmin.MenuItems[7].Enabled = true; //��Ժ
                        m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //ȡ����Ժ
                        m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //��Ժ֪ͨ

                        m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //���
                        m_objViewer.BedAdmin.MenuItems[12].Enabled = true; //�������
                        m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //��������

                        m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //ˢ��
                    }
                    else if (bedVO.m_strPSTATUS_INT == "2")
                    {
                        m_objViewer.BedAdmin.MenuItems[0].Enabled = false; //ҽ��
                        m_objViewer.BedAdmin.MenuItems[1].Enabled = true; //����

                        m_objViewer.BedAdmin.MenuItems[3].Enabled = true; //ת��
                        m_objViewer.BedAdmin.MenuItems[4].Enabled = true; //ת��
                        m_objViewer.BedAdmin.MenuItems[5].Enabled = true; //ת��

                        m_objViewer.BedAdmin.MenuItems[7].Enabled = false; //��Ժ
                        m_objViewer.BedAdmin.MenuItems[8].Enabled = true; //ȡ����Ժ
                        m_objViewer.BedAdmin.MenuItems[9].Enabled = true; //��Ժ֪ͨ

                        m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //���
                        m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //�������
                        m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //��������

                        m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //ˢ��
                    }
                }
                //����
                if (bedVO.m_strSTATUS_INT.Equals("4"))
                {
                    m_objViewer.BedAdmin.MenuItems[0].Enabled = false; //ҽ��
                    m_objViewer.BedAdmin.MenuItems[1].Enabled = false; //����

                    m_objViewer.BedAdmin.MenuItems[3].Enabled = false; //ת��
                    m_objViewer.BedAdmin.MenuItems[4].Enabled = false; //ת��
                    m_objViewer.BedAdmin.MenuItems[5].Enabled = false; //ת��

                    m_objViewer.BedAdmin.MenuItems[7].Enabled = false; //��Ժ
                    m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //ȡ����Ժ
                    m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //��Ժ֪ͨ

                    m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //���
                    m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //�������
                    m_objViewer.BedAdmin.MenuItems[13].Enabled = true; //��������

                    m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //ˢ��
                }
                //else
                //{
                //    m_objViewer.BedAdmin.MenuItems[7].Visible = false;
                //}
            }
        }
        #endregion

        #region �ϷŰ��Ŵ�λ
        /// <summary>
        /// �ϷŰ��Ŵ�λ
        /// </summary>
        public void m_mthArrange(ListViewItem p_lsvItem)
        {
            if (m_objViewer.m_lsvTurnInNA.SelectedItems.Count > 0)
            {
                clsBedManageVO m_objBeb = ((clsBedManageVO)p_lsvItem.Tag);
                if (m_objBeb.m_strSTATUS_INT != "1" && m_objBeb.m_strSTATUS_INT != "5")
                {
                    return;
                }
                string strSex = m_objViewer.m_lsvTurnInNA.SelectedItems[0].SubItems[3].Text.Trim();
                if (m_objBeb.m_strSEXNAME != "����" && strSex != m_objBeb.m_strSEXNAME)
                {
                    string strMessage = "ȷ�Ͻ�" + strSex + "�� " + m_objViewer.m_lsvTurnInNA.SelectedItems[0].SubItems[2].Text.Trim() +
                                    " ���ŵ� " + m_objBeb.m_strCODE_CHR + " ��" + m_objBeb.m_strSEXNAME + "��λô��";
                    if (MessageBox.Show(strMessage, "���Ŵ�λ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                }
                clsT_Opr_Bih_Transfer_VO p_objRecord = new clsT_Opr_Bih_Transfer_VO();
                p_objRecord.m_strTARGETDEPTID_CHR = m_strDeptID;
                p_objRecord.m_strTARGETAREAID_CHR = m_strAreaID;
                p_objRecord.m_strTARGETBEDID_CHR = m_objBeb.m_strBEDID_CHR;
                p_objRecord.m_strREGISTERID_CHR = m_objViewer.m_lsvTurnInNA.SelectedItems[0].Tag.ToString();
                p_objRecord.m_strType = m_objViewer.m_lsvTurnInNA.SelectedItems[0].SubItems[8].Text.Trim();
                p_objRecord.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                try
                {
                    m_objManage.m_lngArrangeBed(p_objRecord);
                    int intIndex = m_objViewer.m_lsvTurnInNA.SelectedIndices[0];
                    m_objViewer.m_lsvTurnInNA.SelectedItems[0].Remove();
                    if (m_objViewer.m_lsvTurnInNA.Items.Count > 0)
                    {
                        if (intIndex > 0)
                        {
                            m_objViewer.m_lsvTurnInNA.Items[intIndex - 1].Selected = true;
                        }
                        else
                        {
                            m_objViewer.m_lsvTurnInNA.Items[intIndex].Selected = true;
                        }
                    }
                    p_lsvItem.Remove();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "���Ŵ�λʧ��", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                finally
                {
                    m_mthGetBidInfoByArearID();
                }
            }
        }
        #endregion

        #region ��ӡת��֪ͨ��
        /// <summary>
        /// ��ӡת��֪ͨ��
        /// </summary>
        public void m_mthPrintTurnOutNotice()
        {
            if (m_objViewer.m_lsvTurnOutNA.SelectedItems.Count > 0)
            {
                clsTransferVO m_objTranfer = (clsTransferVO)m_objViewer.m_lsvTurnOutNA.SelectedItems[0].Tag;
                try
                {
                    m_objViewer.Cursor = Cursors.WaitCursor;
                    ReportDocument m_rptDocument = new ReportDocument();
                    m_rptDocument.Load(@".\report\rptTurnAreaNotice.rpt");
                    ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labName"]).Text = m_objTranfer.m_strNAME_VCHR;
                    ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labInpatientNun"]).Text = m_objTranfer.m_strINPATIENTID_CHR;
                    ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labTurnInArea"]).Text = m_objTranfer.m_strAREANAME;
                    ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labTurnOutArea"]).Text = m_objViewer.m_lblPatientArea.Text;
                    clsBedManageVO bedVO;
                    for (int i1 = 0; i1 < m_objViewer.m_lsvBedInfo.Items.Count; i1++)
                    {
                        bedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.Items[i1].Tag;
                        if (bedVO.m_strBEDID_CHR == m_objTranfer.m_strSOURCEBEDID_CHR)
                        {
                            ((TextObject)m_rptDocument.ReportDefinition.ReportObjects["m_labBedCode"]).Text = bedVO.m_strCODE_CHR;
                            break;
                        }
                    }
                    m_rptDocument.PrintToPrinter(1, true, 0, 0);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "��ӡת��֪ͨ��ʧ��");
                }
                finally
                {
                    m_objViewer.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region ��ӡ��Ժ֪ͨ�� He Guiqiu 20060713
        /// <summary>
        /// ��ӡ��Ժ֪ͨ��
        /// </summary>
        public void PrintLeaveNotice()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "��ѡ��Ҫ��Ժ�Ļ���!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            if (objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "û�л�����Ϣ!\n����ʧ��!", "��ʾ��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsT_Opr_Bih_Leave_VO objLeaveVO;

            long lngReg = -1;
            clsDclBihLeaHos domainObj = new clsDclBihLeaHos();
            lngReg = domainObj.GetPreLeaveByRegisterID(objBedVO.m_strREGISTERID_CHR, out objLeaveVO);
            if (lngReg <= 0)
            {
                MessageBox.Show("ȡ����Ԥ��Ժ��Ϣʱ����", "��ʾ��");
                return;
            }

            // ��ӡ��Ժ֪ͨ��
            frmPrintLeaveNotice printLeaveNotice = new frmPrintLeaveNotice(objBedVO, objLeaveVO);

            printLeaveNotice.ShowDialog();
        }
        #endregion

        #region ת�����˵���
        internal void TurnBed()
        {
            //û�в����򷵻�
            if (m_strAreaID.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "��ѡ����!", "ת��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //û��ѡ���򷵻�
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "��ѡ��Ҫת���Ĳ���!", "ת��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            //û����Ժ�Ǽ���ˮ���򷵻� 
            if (objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "û�л�����Ϣ!\n������ת������!", "ת��", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            frmTranBed trBed = new frmTranBed(m_strAreaID, objBedVO);
            trBed.ShowDialog();
            if (trBed.DialogResult == DialogResult.OK)
            {
                clsT_Opr_Bih_Transfer_VO objTransferVO = new clsT_Opr_Bih_Transfer_VO();
                objTransferVO.m_strSOURCEDEPTID_CHR = m_strDeptID;
                objTransferVO.m_strSOURCEAREAID_CHR = m_strAreaID;
                objTransferVO.m_strSOURCEBEDID_CHR = objBedVO.m_strBEDID_CHR;
                objTransferVO.m_strTARGETDEPTID_CHR = m_strDeptID;
                objTransferVO.m_strTARGETAREAID_CHR = m_strAreaID;
                objTransferVO.m_strTARGETBEDID_CHR = trBed.m_strBedId;
                objTransferVO.m_strREGISTERID_CHR = objBedVO.m_strREGISTERID_CHR;
                objTransferVO.m_strOPERATORID_CHR = m_objViewer.LoginInfo.m_strEmpID;
                objTransferVO.m_intTYPE_INT = 2;
                if (objsystempower.isHasRight("סԺ.����ת.ת��"))
                {
                    try
                    {
                        m_objManage.m_lngTurnBed(objTransferVO);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "��", "ת��", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show(m_objViewer, "���]��Ȩ��");
                }
                m_mthGetBidInfoByArearID();
            }
        }
        #endregion

        #region �����
        /// <summary>
        /// �����
        /// </summary>
        internal void SpireLamella()
        {
            if (this.m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "��ѡ���ߡ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO m_objBedVO = (clsBedManageVO)this.m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(this.m_objViewer, "û�л�����Ϣ!\n����ʧ��!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            SpireLamella.EntitySpireLamella vo = new SpireLamella.EntitySpireLamella();
            vo.IpNo = m_objBedVO.m_strINPATIENTID_CHR;
            vo.BedNo = m_objBedVO.m_strCODE_CHR;
            vo.PatName = m_objBedVO.m_strNAME_VCHR;
            vo.Sex = m_objBedVO.m_strSEX_CHR;
            vo.DeptName = this.m_objViewer.m_lblPatientArea.Text.Trim();
            vo.Oper = this.m_objViewer.LoginInfo.m_strEmpName;
            vo.Check = this.m_objViewer.LoginInfo.m_strEmpName;
            vo.Birthday = m_objBedVO.m_strBIRTH_DAT;
            SpireLamella.frmSpireLamella frm = new SpireLamella.frmSpireLamella(vo);
            frm.ShowDialog();
        }
        #endregion

        #region Ƿ��֪ͨ��
        /// <summary>
        /// Ƿ��֪ͨ��
        /// </summary>
        internal void PaymentNotice()
        {
            try
            {
                if (this.m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
                {
                    MessageBox.Show(m_objViewer, "��ѡ���ߡ�", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                clsBedManageVO m_objBedVO = (clsBedManageVO)this.m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
                {
                    MessageBox.Show(this.m_objViewer, "û�л�����Ϣ!\n����ʧ��!", "ϵͳ��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                clsPublic.PlayAvi("���Ժ�...");
                decimal totalMny = 0;
                decimal payMny = 0;
                decimal owingMny = 0;
                this.GetBihPatient(m_objBedVO.m_strREGISTERID_CHR, out totalMny, out payMny, out owingMny);

                DataStore ds = new DataStore();
                ds.LibraryList = Application.StartupPath + "\\pbwindow.pbl";
                ds.DataWindowObject = "d_bih_paymentnotice";
                ds.InsertRow(0);
                ds.Modify(string.Format("t_name.text = '{0}'", m_objBedVO.m_strNAME_VCHR));
                ds.Modify(string.Format("t_sex.text = '{0}'", m_objBedVO.m_strSEX_CHR));
                ds.Modify(string.Format("t_age.text = '{0}'", (new clsBrithdayToAge().m_strGetAge(Convert.ToDateTime(m_objBedVO.m_strBIRTH_DAT))).TrimEnd('��')));
                ds.Modify(string.Format("t_dept.text = '{0}'", this.m_objViewer.m_lblPatientArea.Text.Trim()));
                ds.Modify(string.Format("t_bed.text = '{0}'", m_objBedVO.m_strCODE_CHR));
                ds.Modify(string.Format("t_ipno.text = '{0}'", m_objBedVO.m_strINPATIENTID_CHR));
                ds.Modify(string.Format("t_name2.text = '{0}'", m_objBedVO.m_strNAME_VCHR));
                ds.Modify(string.Format("t_total.text = '{0}'", totalMny.ToString("0.00")));
                ds.Modify(string.Format("t_totalclear.text = '{0}'", payMny.ToString("0.00")));
                ds.Modify(string.Format("t_totalowing.text = '{0}'", owingMny.ToString("0.00")));
                ds.Modify(string.Format("t_year.text = '{0}'", DateTime.Now.ToString("yyyy")));
                ds.Modify(string.Format("t_month.text = '{0}'", DateTime.Now.ToString("MM")));
                ds.Modify(string.Format("t_day.text = '{0}'", DateTime.Now.ToString("dd")));
                clsPublic.CloseAvi();
                clsPublic.PrintDialog(ds);
            }
            catch (Exception ex)
            {
                clsPublic.CloseAvi();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region ��ȡ������Ϣ
        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <param name="regId"></param>
        /// <param name="totalMny">�ܷ���</param>
        /// <param name="payMny">��֧��</param>
        /// <param name="owingMny">Ƿ��</param>
        void GetBihPatient(string regId, out decimal totalMny, out decimal payMny, out decimal owingMny)
        {
            clsBihPatient_VO vo = new clsBihPatient_VO();
            DataTable dt = new DataTable();
            totalMny = 0;
            payMny = 0;
            owingMny = 0;
            com.digitalwave.iCare.middletier.HIS.clsCommonQuery svc1 =
                                                 (com.digitalwave.iCare.middletier.HIS.clsCommonQuery)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCommonQuery));


            com.digitalwave.iCare.middletier.HIS.clsCharge svc2 =
                                                           (com.digitalwave.iCare.middletier.HIS.clsCharge)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsCharge));

            com.digitalwave.iCare.middletier.HIS.clsPrePay svc3 =
                                                (com.digitalwave.iCare.middletier.HIS.clsPrePay)com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsPrePay));


            // 1 ��Ժ; 3 �Ǽ�ID
            svc1.m_lngGetPatientinfoByNO(regId, out dt, 1, 3);

            if (dt != null && dt.Rows.Count == 1)
            {
                DataRow dr = dt.Rows[0];
                vo.RegisterID = regId;
                vo.PatientID = dr["patientid_chr"].ToString().Trim();
                vo.Zyh = dr["inpatientid_chr"].ToString().Trim();
                vo.Zycs = int.Parse(dr["inpatientcount_int"].ToString());
                vo.Name = dr["lastname_vchr"].ToString().Trim();
                vo.FeeStatus = Convert.ToInt32(dr["feestatus_int"].ToString());
            }
            else
            {
                return;
            }

            // ����Ԥ����
            decimal Balanceprepaymoney = 0;
            svc3.m_lngGetPrepayByRegID(regId, 2, out dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Balanceprepaymoney += clsPublic.ConvertObjToDecimal(dt.Rows[i]["balancetotal"]);
                }
                //Ԥ�����Ϊ��ʾ��ǰ����Ԥ����
                vo.PrepayMoney = Balanceprepaymoney;
            }

            //��ȡ�ܷ��á����ᡢ���塢ֱ���շѡ����塢���ࡢ�������ڡ�δ������
            decimal TotalFee = 0;
            decimal WaitChargeFee = 0;
            decimal WaitClearFee = 0;
            decimal DirectorFee = 0;
            decimal CompleteClearFee = 0;

            svc2.m_lngGetChargeInfoByID(regId, 1, out dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //�����ܷ���
                    decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(dt.Rows[i]["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(dt.Rows[i]["amount_dec"]), 2);
                    //��������
                    decimal decDiffSum = clsPublic.Round(clsPublic.ConvertObjToDecimal(dt.Rows[i]["TOTALDIFFCOSTMONEY_DEC"]), 2);
                    //�ܷ���
                    TotalFee += d + decDiffSum;
                    //����״̬ 0 ��ȷ�� 1 ���� 2 ���� 3 ���� 4 ֱ��
                    int pstatus = Convert.ToInt32(dt.Rows[i]["pstatus_int"].ToString());
                    if (pstatus == 1)
                    {
                        WaitChargeFee += d + decDiffSum;
                    }
                    else if (pstatus == 2)
                    {
                        WaitClearFee += d + decDiffSum;
                    }
                    else if (pstatus == 3)
                    {
                        CompleteClearFee += d + decDiffSum;
                    }
                    else if (pstatus == 4)
                    {
                        DirectorFee += d + decDiffSum;
                    }
                }
            }

            // �ܷ���
            totalMny = TotalFee;
            // ��֧���� ʣ��Ԥ���� + ���� + ֱ��
            payMny = Balanceprepaymoney + CompleteClearFee + DirectorFee;
            // Ƿ��
            owingMny = totalMny - payMny;
        }
        #endregion
    }
}
