using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using com.digitalwave.GUI_Base;	//GUI_Base.dll
using com.digitalwave.iCare.middletier.HIS;	//his_svc.dll
using com.digitalwave.iCare.ValueObject;//iCareData.dll
using System.Collections;
using com.digitalwave.iCare.gui.HIS;
using System.Xml;
using System.IO;
using System.Drawing.Printing;
using com.digitalwave.iCare.middletier.HI;
using LEDInterface.LianCheng;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsControlDoctorUseMed : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsDomainControlOPMedStore m_objDomain;
        public clsControlDoctorUseMed()
        {
            m_objDomain = new clsDomainControlOPMedStore();
        }
        #region 设置窗体对象
        frmOPComUseMedStat m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmOPComUseMedStat)frmMDI_Child_Base_in;
        }
        #endregion
        public void m_mthFillDept()
        {
            DataTable m_objDeptTable = new DataTable();
            long lngRes = -1;
            lngRes = m_objDomain.m_lngGetOPDeptInfo(out m_objDeptTable);
            this.m_objViewer.m_cboDept.Item.Add("全部", "-1");
            if (lngRes > 0 && m_objDeptTable.Rows.Count > 0)
            {
               
                for (int i = 0; i < m_objDeptTable.Rows.Count; i++)
                {  
                    this.m_objViewer.m_cboDept.Item.Add(m_objDeptTable.Rows[i]["deptname_vchr"].ToString(), m_objDeptTable.Rows[i]["deptid_chr"].ToString());
                }
            }
            this.m_objViewer.m_cboDept.SelectedIndex = 0;
        }
        public void m_mthGetMedFeePercent()
        {
            string m_strDeptID = string.Empty;
            if (this.m_objViewer.m_cboDept.SelectedIndex != 0)
            {
                m_strDeptID = this.m_objViewer.m_cboDept.SelectItemValue;
            }
            string strStatTime ="统计时间:"+this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 至 " + this.m_objViewer.m_datEnd.Value.ToShortDateString();
            string strOperator = "统计员:" + this.m_objViewer.LoginInfo.m_strEmpName;
            string beginDate = this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 00:00:00";
            string endDate = this.m_objViewer.m_datEnd.Value.ToShortDateString() + " 23:59:59";
     
            long lngRes = -1;

            DataTable dtbResult = new DataTable();
            lngRes = this.m_objDomain.m_lngGetDeptMedFeePercentInfo(m_strDeptID,this.m_objViewer.m_strType, beginDate, endDate, out dtbResult);
            if (lngRes > 0)
            {
                this.m_objViewer.dwMed.Modify("t_date.text = '" + strStatTime + "'");
                this.m_objViewer.dwMed.Modify("t_operator.text='" + strOperator + "'");
                this.m_objViewer.dwMed.SetRedrawOff();
                this.m_objViewer.dwMed.Retrieve(dtbResult);
                this.m_objViewer.dwMed.SetRedrawOn();

                this.m_objViewer.dwMed.Refresh();
            }
        }
        public void GetDoctorUseMedInfo(int m_intFlag)
        {
            string m_strDeptID = string.Empty;
            if (this.m_objViewer.m_cboDept.SelectedIndex != 0)
            {
                m_strDeptID=this.m_objViewer.m_cboDept.SelectItemValue;
            }
            string strStatTime = this.m_objViewer.m_datBegin.Text + " 至 " + this.m_objViewer.m_datEnd.Text;
            string beginDate = this.m_objViewer.m_datBegin.Value.ToShortDateString() + " 00:00:00";
            string endDate = this.m_objViewer.m_datEnd.Value.ToShortDateString() + " 23:59:59";
            this.m_objViewer.dwMed.Modify("t_date.text = '" + strStatTime + "'");
            this.m_objViewer.dwMed.Modify("t_operator.text='" + this.m_objViewer.LoginInfo.m_strEmpName +"'");
            this.m_objViewer.Cursor = Cursors.WaitCursor;
            long lngRes = -1;
            DataTable dtbResult = new DataTable();
            if (m_intFlag == 1)
            {
                this.m_objViewer.dwMed.SetSort("t_bse_deptdesc_deptname_vchr,t_bse_employee_empno_chr,t_bse_employee_lastname_vchr,totalmoney desc");
                lngRes = this.m_objDomain.m_lngGetDoctorUseMedInfo(m_strDeptID, this.m_objViewer.m_strStatDocotr, m_strMedType, beginDate, endDate, out dtbResult);
            }
            else
            {
                this.m_objViewer.dwMed.SetSort("t_bse_deptdesc_deptname_vchr,t_bse_employee_empno_chr,t_bse_employee_lastname_vchr,acount desc");
                lngRes = this.m_objDomain.m_lngGetDoctorUseMedInfoByQuatity(m_strDeptID, this.m_objViewer.m_strStatDocotr, m_strMedType, beginDate, endDate, out dtbResult);
            }
            if (lngRes > 0)
            {
                DataTable m_objTable = new DataTable();
                m_objTable = dtbResult.Clone();

                bool m_blnExisted=false;
                for (int i = 0; i < dtbResult.Rows.Count; i++)
                { 
                    m_blnExisted=false;
                    int m_intCount = 0;
                    for(int j=0;j<m_objTable.Rows.Count;j++)
                    {
                        if (m_objTable.Rows[j]["empno_chr"].ToString().Trim()== dtbResult.Rows[i]["empno_chr"].ToString().Trim() && m_objTable.Rows[j]["deptname_vchr"].ToString().Trim() == dtbResult.Rows[i]["deptname_vchr"].ToString().Trim())
                        {
                            m_intCount++;
                        }
                        if (m_intCount == this.m_objViewer.numericUpDown1.Value)
                        {
                            m_blnExisted = true;
                            break;
                        }
                    }
                    if (m_blnExisted == false)
                    {
                        object[] objects = dtbResult.Rows[i].ItemArray;
                        DataRow m_objTempRow = m_objTable.NewRow();
                        m_objTempRow.ItemArray = objects;
                        m_objTable.Rows.Add(m_objTempRow);
                    }
           
                }
                this.m_objViewer.dwMed.SetRedrawOff();
                this.m_objViewer.dwMed.Retrieve(m_objTable);

                this.m_objViewer.dwMed.Sort();
                this.m_objViewer.dwMed.CalculateGroups();
              
            
                this.m_objViewer.dwMed.SetRedrawOn();
         
                this.m_objViewer.dwMed.Refresh();
            }

            this.m_objViewer.Cursor = Cursors.Default;
        }
        public string m_strMedType = string.Empty;
        public void m_mthGetMedTypeInfo(List<string> m_objList)
        {
            if (m_objList.Count > 0)
            {
                for (int i = 0; i < m_objList.Count; i++)
                {
                    m_strMedType += m_objList[i];
                    if (i != m_objList.Count - 1)
                    {
                        m_strMedType += ",";
                    }
                }
                DataTable dtbResult = new DataTable();
                long lngRes = this.m_objDomain.m_lngGetMedTypeInfo(m_strMedType, out dtbResult);
                if (lngRes > 0 && dtbResult.Rows.Count > 0)
                {
                    string m_strTemp = "";
                    for (int i = 0; i < dtbResult.Rows.Count; i++)
                    {
                        m_strTemp += "{" + dtbResult.Rows[i]["medicinetypename_vchr"].ToString() + "}";
                    }
                    this.m_objViewer.Text = m_strTemp +"-"+ this.m_objViewer.Text;
                }
            }
            
        }
    }
}
