using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using iCareData;
using com.digitalwave.Emr.Signature_gui; 

namespace iCare
{
    public partial class frmPartogramPoint_GX : Form
    {
        private List<clsPartogram_Point> m_arlDeletePoint;
        private clsPartogramDomain m_objDomain;
        private clsPartogram_Point[] m_objPointArr;
        private string m_strDeptId = string.Empty;
        private int m_intSelectHour = -1;
        private string m_strRegisterId = string.Empty;
        public frmPartogramPoint_GX(clsPartogram_Point[] p_objPointArr,string p_strDeptId,int p_intSelectHour)
        {
            InitializeComponent();
            m_objDomain = new clsPartogramDomain();
            m_arlDeletePoint = new List<clsPartogram_Point>(3);
            if (p_objPointArr == null || p_objPointArr.Length == 0)
                return;
            lblHour.Text = "第"+p_intSelectHour+"小时";
            m_strDeptId = p_strDeptId;
            m_intSelectHour = p_intSelectHour;
            m_strRegisterId = p_objPointArr[0].m_strREGISTERID_CHR;
            for (int i = 0 ; i < p_objPointArr.Length ; i++)
            {
                if (p_objPointArr[i].m_intPointType_INT == 0)
                {
                    ListViewItem item = m_lsvU.Items.Add(p_objPointArr[i].m_intPointMin_INT.ToString());
                    item.SubItems.Add(p_objPointArr[i].m_fltPointValue_INT.ToString());
                    item.Tag = p_objPointArr[i];
                }
                else
                {
                    ListViewItem item = m_lsvDown.Items.Add(p_objPointArr[i].m_intPointMin_INT.ToString());
                    item.SubItems.Add(p_objPointArr[i].m_fltPointValue_INT.ToString());
                    item.Tag = p_objPointArr[i];
                }
            }
        }

        public clsPartogram_Point[] m_ObjGetPointArr
        {
            get { return m_objPointArr; }
        }
        private string m_strInPatientIdAndDate = string.Empty;
        public string m_StrInPatientIdAndDate
        {
            set { m_strInPatientIdAndDate = value; }
        }

        #region Event
        private void m_mniDelete_Click(object sender, EventArgs e)
        {
            m_mthDeleteItems(0);
        }

        private void m_mniDelete2_Click(object sender, EventArgs e)
        {
            m_mthDeleteItems(1);
        }
        private void m_mthDeleteItems(int p_intType)
        {
            IEnumerator objEnumerator = null;
            if (p_intType == 0 && m_lsvU.SelectedItems.Count > 0)
            {
                objEnumerator = m_lsvU.SelectedItems.GetEnumerator();
            }
            else if (p_intType == 1 && m_lsvDown.SelectedItems.Count > 0)
                objEnumerator = m_lsvDown.SelectedItems.GetEnumerator();
            string strEmpArr = string.Empty;
            if (objEnumerator != null)
            {
                while (objEnumerator.MoveNext())
                {
                    ListViewItem item = (ListViewItem)objEnumerator.Current;
                    clsPartogram_Point objPoint = item.Tag as clsPartogram_Point;
                    if (objPoint != null)
                    {
                        //权限判断
                        bool blnIsAllow = clsPublicFunction.IsAllowDelete(m_strDeptId, objPoint.m_strMODIFYUSERID_CHR, clsEMRLogin.LoginEmployee, 1);
                        if (!blnIsAllow)
                        {
                            strEmpArr += objPoint.m_strMODIFYUSERID_CHR + " ";
                            continue;
                        }
                        else if (!m_arlDeletePoint.Contains(objPoint))
                        {
                            objPoint.m_dtmDEACTIVEDDATE_DAT = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                            objPoint.m_strDEACTIVEDOPERATORID_CHR = clsEMRLogin.LoginInfo.m_strEmpID;
                            objPoint.m_strDEACTIVEDOPERATORNAME_VCHR = clsEMRLogin.LoginInfo.m_strEmpName;
                            objPoint.m_intSTATUS_INT = 0;
                            m_arlDeletePoint.Add(objPoint);
                        }
                    }
                    item.Remove();
                }
            }
            if (strEmpArr != string.Empty)
            {
                Point p;
                if (p_intType == 0)
                    p = groupBox2.PointToScreen(m_lsvU.PointToClient(m_lsvU.Location));
                else
                    p = groupBox3.PointToScreen(m_lsvDown.PointToClient(m_lsvU.Location));
                m_tipMain.Show("有一个或多个创建者分别为“" + strEmpArr + "”的项目不能删除！", this, p, 2000);
            }
        }
        private void m_cmdAddU_Click(object sender, EventArgs e)
        {
            if (m_txtMin1.m_objGetValue() == string.Empty)
            {
                m_tipMain.Show("请输入有效值！", m_txtMin1, 2000);
                return;
            }
            ListViewItem item = new ListViewItem(new string[] { m_txtMin1.m_objGetValue(), m_numUtricm.Value.ToString() });
            if (m_cmdAddU.Tag is clsPartogram_Point)
            {
                clsPartogram_Point objPoint = (clsPartogram_Point)m_cmdAddU.Tag;
                if (objPoint.m_intPointType_INT == 0)
                {
                    objPoint.m_intPointMin_INT = (int)m_txtMin1.m_dcmGetValue();
                    objPoint.m_fltPointValue_INT = (float)m_numUtricm.Value;
                    objPoint.m_dtmMODIFYDATE_DAT = new clsPublicDomain().m_dtmGetServerTime();
                    objPoint.m_intSTATUS_INT = 2;
                    objPoint.m_strMODIFYUSERID_CHR = clsEMRLogin.LoginInfo.m_strEmpID;
                    item.Tag = objPoint;
                }
            }
            m_lsvU.Items.Add(item);
            m_txtMin1.m_mthClearValue();
            m_numUtricm.Value = 0;
            m_cmdAddU.Tag = null;
        }
        private void m_cmdAddDown_Click(object sender, EventArgs e)
        {
            if (m_txtMin2.m_objGetValue() == string.Empty)
            {
                m_tipMain.Show("请输入有效值！", m_txtMin2,  2000);
                return;
            }
            ListViewItem item = new ListViewItem(new string[] { m_txtMin2.m_objGetValue(), m_numDown.Value.ToString() });
            if (m_cmdAddDown.Tag is clsPartogram_Point)
            {
                clsPartogram_Point objPoint = (clsPartogram_Point)m_cmdAddDown.Tag;
                if (objPoint.m_intPointType_INT == 1)
                {
                    objPoint.m_intPointMin_INT = (int)m_txtMin2.m_dcmGetValue();
                    objPoint.m_fltPointValue_INT = (float)m_numDown.Value;
                    objPoint.m_dtmMODIFYDATE_DAT = new clsPublicDomain().m_dtmGetServerTime();
                    objPoint.m_intSTATUS_INT = 2;
                    objPoint.m_strMODIFYUSERID_CHR = clsEMRLogin.LoginInfo.m_strEmpID;
                    item.Tag = objPoint;
                }
            }
            m_lsvDown.Items.Add(item);
            m_txtMin2.m_mthClearValue();
            m_numDown.Value = 0;
            m_cmdAddDown.Tag = null;
        }

        private void m_cmdCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_cmdOK_Click(object sender, EventArgs e)
        {
            long lngRes = 0;
            m_objPointArr = m_objGetPointArr();
            //数字签名 兼容考虑 
            //记录ID通常为 住院号＋住院时间 || 住院号＋记录时间 来识别唯一 格式 00000056-2005-10-10 10:20:20

            clsEmrDigitalSign_VO objSign_VO = new clsEmrDigitalSign_VO();
            objSign_VO.m_strFORMID_VCHR = this.Name;
            objSign_VO.m_strFORMRECORDID_VCHR = m_strInPatientIdAndDate;
            objSign_VO.m_strSIGNIDID_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objSign_VO.m_strRegisterId = m_strRegisterId;
            clsCheckSignersController objCheck = new clsCheckSignersController();
            if (objCheck.m_lngSign(m_objPointArr, objSign_VO) == -1)
                return ;

            if (m_objPointArr != null)
                lngRes = m_objDomain.m_lngSetPointToDb(m_objPointArr);
            else
                lngRes = 1;
            if (lngRes > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                m_objPointArr = null;
                m_tipMain.Show("保存失败！", this, m_cmdOK.Location, 2000);
            }
        }

        private void m_lsvU_DoubleClick(object sender, EventArgs e)
        {
            if (m_lsvU.SelectedItems.Count > 0)
            {
                clsPartogram_Point objPoint = m_lsvU.SelectedItems[0].Tag as clsPartogram_Point;
                if (objPoint != null)
                {
                    m_txtMin1.m_mthSetValue(objPoint.m_intPointMin_INT.ToString());
                    m_numUtricm.Value = (decimal)objPoint.m_fltPointValue_INT;
                    m_cmdAddU.Tag = objPoint.m_objClone();
                }
                else
                {
                    m_txtMin1.m_mthSetValue(m_lsvU.SelectedItems[0].Text);
                    m_numUtricm.Value = decimal.Parse(m_lsvU.SelectedItems[0].SubItems[1].Text);
                    m_cmdAddU.Tag = null;
                }
                m_lsvU.SelectedItems[0].Remove();
            }
        }

        private void m_lsvDown_DoubleClick(object sender, EventArgs e)
        {
            if (m_lsvDown.SelectedItems.Count > 0)
            {
                clsPartogram_Point objPoint = m_lsvDown.SelectedItems[0].Tag as clsPartogram_Point;
                if (objPoint != null)
                {
                    m_txtMin2.m_mthSetValue(objPoint.m_intPointMin_INT.ToString());
                    m_numDown.Value = (decimal)objPoint.m_fltPointValue_INT;
                    m_cmdAddDown.Tag = objPoint.m_objClone();
                }
                else
                {
                    m_txtMin2.m_mthSetValue(m_lsvDown.SelectedItems[0].Text);
                    m_numDown.Value = decimal.Parse(m_lsvDown.SelectedItems[0].SubItems[1].Text);
                    m_cmdAddDown.Tag = null;
                }
                m_lsvDown.SelectedItems[0].Remove();
            }
        }

        #endregion Event

        private clsPartogram_Point[] m_objGetPointArr()
        {
            DateTime dtmNow = new clsPublicDomain().m_dtmGetServerTime();
            List<clsPartogram_Point> objPointArr = new List<clsPartogram_Point>();
            if (m_lsvU.Items.Count > 0)
            {
                for (int i = 0 ; i < m_lsvU.Items.Count ; i++)
                {
                    if (m_lsvU.Items[i].Tag is clsPartogram_Point)
                    {
                        clsPartogram_Point objPoint = (clsPartogram_Point)m_lsvU.Items[i].Tag;
                        objPoint.m_dtmMODIFYDATE_DAT = dtmNow;
                        objPointArr.Add(objPoint);
                    }
                    else
                    {
                        float flt = float.MinValue;
                        if (!float.TryParse(m_lsvU.Items[i].SubItems[1].Text, out flt))
                            flt = float.MinValue;
                        int intTmp = -1;
                        int.TryParse(m_lsvU.Items[i].Text, out intTmp);
                        objPointArr.Add(m_objGetPoint(flt, intTmp, 0));
                    }
                }
            }
            if (m_lsvDown.Items.Count > 0)
            {
                for (int i = 0 ; i < m_lsvDown.Items.Count ; i++)
                {
                    if (m_lsvDown.Items[i].Tag is clsPartogram_Point)
                    {
                        clsPartogram_Point objPoint = (clsPartogram_Point)m_lsvDown.Items[i].Tag;
                        objPoint.m_dtmMODIFYDATE_DAT = dtmNow;
                        objPointArr.Add(objPoint);
                    }
                    else
                    {
                        float flt = float.MinValue;
                        if (!float.TryParse(m_lsvDown.Items[i].SubItems[1].Text, out flt))
                            flt = float.MinValue;
                        int intTmp = -1;
                        int.TryParse(m_lsvDown.Items[i].Text, out intTmp);
                        objPointArr.Add(m_objGetPoint(flt, intTmp, 1));
                    }
                }
            }
            if (m_arlDeletePoint.Count > 0)
            {
                objPointArr.AddRange(m_arlDeletePoint.ToArray());
            }
            if(objPointArr.Count > 0)
                return objPointArr.ToArray();
            return null;
        }
        private clsPartogram_Point m_objGetPoint(float p_fltValue, int p_intMin, int p_intType)
        {
            clsPartogram_Point objPoint = new clsPartogram_Point();
            objPoint.m_dtmCREATEDATE_DAT = new clsPublicDomain().m_dtmGetServerTime();
            objPoint.m_dtmMODIFYDATE_DAT = objPoint.m_dtmCREATEDATE_DAT;
            objPoint.m_fltPointValue_INT = p_fltValue;
            objPoint.m_intPARTOGRAM_INT = m_intSelectHour;
            objPoint.m_intPointID_INT = -1;
            objPoint.m_intPointMin_INT = p_intMin;
            objPoint.m_intPointType_INT = p_intType;
            objPoint.m_intSTATUS_INT = 1;
            objPoint.m_strMODIFYUSERID_CHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objPoint.m_strMODIFYUSERNAME_VCHR = clsEMRLogin.LoginInfo.m_strEmpID;
            objPoint.m_strREGISTERID_CHR = m_strRegisterId;
            return objPoint;
        }

        private void frmPartogramPoint_GX_Load(object sender, EventArgs e)
        {
            if (m_intSelectHour == -1)
            {
                MessageBox.Show("参数有误！");
                this.Close();
            }
        }
    }
}