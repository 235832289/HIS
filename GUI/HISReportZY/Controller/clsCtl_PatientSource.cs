using System;
using System.Collections.Generic;
using System.Text;
using Sybase.DataWindow;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;

namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// ctl层处理
    /// shichun.chen
    /// 2010\8\11
    /// </summary>
    public class clsCtl_PatientSource : com.digitalwave.GUI_Base.clsController_Base
    {
        com.digitalwave.iCare.gui.HIS.Reports.frmRptPatientSource m_objViewer;
        /// <summary>
        /// 构造
        /// </summary>
        public clsCtl_PatientSource()
        {

        }

        #region 设置窗体对象
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            this.m_objViewer = (frmRptPatientSource)frmMDI_Child_Base_in;
        }
       #endregion

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="p_dwRpt"></param>
        /// <param name="p_strStartDate"></param>
        /// <param name="p_strEndDate"></param>
        /// <param name="p_strOutStartDate"></param>
        /// <param name="p_strOutEndDate"></param>
        public void m_mthGetYbCheckBill(DataWindowControl p_dwRpt, string p_strStartDate, string p_strEndDate, string p_strOutStartDate, string p_strOutEndDate)
        {
            clsDcl_DeptTransfer objSvc = new clsDcl_DeptTransfer();
            DataTable dtbReulst = null;
            long lngRes = objSvc.m_lngGetCollectorReport_PatientSource(p_strStartDate, p_strEndDate, p_strOutStartDate, p_strOutEndDate, out dtbReulst);
            p_dwRpt.Reset();
            p_dwRpt.SetRedrawOff();
            if (!string.IsNullOrEmpty(p_strStartDate))
            {
                p_dwRpt.Modify("t_date.text='" + DateTime.Parse(p_strStartDate).ToShortDateString() + "到" + DateTime.Parse(p_strEndDate).ToShortDateString() + "'");
            }
            else
            {
                p_dwRpt.Modify("t_date.text='" + DateTime.Parse(p_strOutStartDate).ToShortDateString() + "到" + DateTime.Parse(p_strOutEndDate).ToShortDateString() + "'");
            }
            if (lngRes > 0 && dtbReulst.Rows.Count > 0)
            {
                //处理数据
                int intRowCount = dtbReulst.Rows.Count;
                DataRow objDr = null;
                DataTable objDtResult = new DataTable();
                objDtResult.Columns.Add("deptname"); 
                objDtResult.Columns.Add("bz_peo");
                objDtResult.Columns.Add("bz_percent");
                objDtResult.Columns.Add("bswz_peo");
                objDtResult.Columns.Add("bswz_percent");
                objDtResult.Columns.Add("bsqt_peo");
                objDtResult.Columns.Add("bsqt_percent");
                objDtResult.Columns.Add("ws_peo");
                objDtResult.Columns.Add("ws_percent");
                objDtResult.Columns.Add("gat_peo");
                objDtResult.Columns.Add("gat_percent");
                objDtResult.Columns.Add("wg_peo");
            
                Hashtable objHashTable = new Hashtable();

                DataRow OneRow = objDtResult.NewRow();
                for (int intI = 0; intI < intRowCount; intI++)
                {
                    objDr = dtbReulst.Rows[intI];
                    OneRow["deptname"] = objDr["deptname_vchr"].ToString();
                    if (!objHashTable.Contains(OneRow["deptname"].ToString()))
                    {
                        clsPatientSoureVo objVo = new clsPatientSoureVo();
                        if (objDr["patientsources_vchr"].ToString() == "本镇区")
                        {
                            OneRow["deptname"] = objDr["deptname_vchr"].ToString();
                            OneRow["bz_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["bz_percent"] = double.Parse(objDr["a3"].ToString());

                            objVo.m_strDeptname = OneRow["deptname"].ToString();
                            objVo.m_intBz_peo = int.Parse(OneRow["bz_peo"].ToString());
                            objVo.m_dblBz_percent = double.Parse(OneRow["bz_percent"].ToString());
                            objHashTable.Add(OneRow["deptname"].ToString(), objVo);
                        }
                        if (objDr["patientsources_vchr"].ToString() == "本市外镇")
                        {
                            OneRow["deptname"] = objDr["deptname_vchr"].ToString();
                            OneRow["bswz_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["bswz_percent"] = double.Parse(objDr["a3"].ToString());

                            objVo.m_strDeptname = OneRow["deptname"].ToString();
                            objVo.m_intBswz_peo = int.Parse(OneRow["bswz_peo"].ToString());
                            objVo.m_dblBswz_percent = double.Parse(OneRow["bswz_percent"].ToString());
                            objHashTable.Add(OneRow["deptname"].ToString(), objVo);

                        }
                        if (objDr["patientsources_vchr"].ToString() == "本省其它市")
                        {
                            OneRow["deptname"] = objDr["deptname_vchr"].ToString();
                            OneRow["bsqt_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["bsqt_percent"] = double.Parse(objDr["a3"].ToString());

                            objVo.m_strDeptname = OneRow["deptname"].ToString();
                            objVo.m_intBsqt_peo = int.Parse(OneRow["bsqt_peo"].ToString());
                            objVo.m_dblBsqt_percent = double.Parse(OneRow["bsqt_percent"].ToString());
                            objHashTable.Add(OneRow["deptname"].ToString(), objVo);
                        }
                        if (objDr["patientsources_vchr"].ToString() == "外省（直辖市）")
                        {
                            OneRow["deptname"] = objDr["deptname_vchr"].ToString();
                            OneRow["ws_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["ws_percent"] = double.Parse(objDr["a3"].ToString());

                            objVo.m_strDeptname = OneRow["deptname"].ToString();
                            objVo.m_intWs_peo = int.Parse(OneRow["ws_peo"].ToString());
                            objVo.m_dblWs_percent = double.Parse(OneRow["ws_percent"].ToString());
                            objHashTable.Add(OneRow["deptname"].ToString(), objVo);

                        }
                        if (objDr["patientsources_vchr"].ToString() == "港、澳、台")
                        {
                            OneRow["deptname"] = objDr["deptname_vchr"].ToString();
                            OneRow["gat_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["gat_percent"] = double.Parse(objDr["a3"].ToString());

                            objVo.m_strDeptname = OneRow["deptname"].ToString();
                            objVo.m_intGat_peo = int.Parse(OneRow["gat_peo"].ToString());
                            objVo.m_dblGat_percent = double.Parse(OneRow["gat_percent"].ToString());
                            objHashTable.Add(OneRow["deptname"].ToString(), objVo);

                        }
                        if (objDr["patientsources_vchr"].ToString() == "外国")
                        {
                            OneRow["deptname"] = objDr["deptname_vchr"].ToString();
                            OneRow["wg_peo"] = int.Parse(objDr["a1"].ToString());

                            objVo.m_strDeptname = OneRow["deptname"].ToString();
                            objVo.m_intWg_peo = int.Parse(OneRow["wg_peo"].ToString());
                            objHashTable.Add(OneRow["deptname"].ToString(), objVo);
                        }
                        
                    }
                    else
                    {
                        clsPatientSoureVo objVo = new clsPatientSoureVo();
                        if (objDr["patientsources_vchr"].ToString() == "本镇区")
                        {
                            OneRow["bz_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["bz_percent"] = double.Parse(objDr["a3"].ToString());

                            objVo.m_intBz_peo = int.Parse(OneRow["bz_peo"].ToString());
                            objVo.m_dblBz_percent = double.Parse(OneRow["bz_percent"].ToString());

                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_intBz_peo = int.Parse(OneRow["bz_peo"].ToString());
                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_dblBz_percent = double.Parse(OneRow["bz_percent"].ToString());
                        }
                        if (objDr["patientsources_vchr"].ToString() == "本市外镇")
                        {
                            OneRow["bswz_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["bswz_percent"] = double.Parse(objDr["a3"].ToString());

                            objVo.m_intBswz_peo = int.Parse(OneRow["bswz_peo"].ToString());
                            objVo.m_dblBswz_percent = double.Parse(OneRow["bswz_percent"].ToString());

                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_intBswz_peo = int.Parse(OneRow["bswz_peo"].ToString());
                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_dblBswz_percent = double.Parse(OneRow["bswz_percent"].ToString());

                        }
                        if (objDr["patientsources_vchr"].ToString() == "本省其它市")
                        {
                            OneRow["bsqt_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["bsqt_percent"] = double.Parse(objDr["a3"].ToString());
                            
                            objVo.m_intBsqt_peo = int.Parse(OneRow["bsqt_peo"].ToString());
                            objVo.m_dblBsqt_percent = double.Parse(OneRow["bsqt_percent"].ToString());

                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_intBsqt_peo = int.Parse(OneRow["bsqt_peo"].ToString());
                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_dblBsqt_percent = double.Parse(OneRow["bsqt_percent"].ToString());
                        }
                        if (objDr["patientsources_vchr"].ToString() == "外省（直辖市）")
                        {
                            OneRow["ws_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["ws_percent"] = double.Parse(objDr["a3"].ToString());

                            objVo.m_intWs_peo = int.Parse(OneRow["ws_peo"].ToString());
                            objVo.m_dblWs_percent = double.Parse(OneRow["ws_percent"].ToString());

                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_intWs_peo = int.Parse(OneRow["ws_peo"].ToString());
                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_dblWs_percent = double.Parse(OneRow["ws_percent"].ToString());
                         }
                        if (objDr["patientsources_vchr"].ToString() == "港、澳、台")
                        {
                            OneRow["gat_peo"] = int.Parse(objDr["a1"].ToString());
                            OneRow["gat_percent"] = double.Parse(objDr["a3"].ToString());

                            objVo.m_intGat_peo = int.Parse(OneRow["gat_peo"].ToString());
                            objVo.m_dblGat_percent = double.Parse(OneRow["gat_percent"].ToString());

                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_intGat_peo = int.Parse(OneRow["gat_peo"].ToString());
                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_dblGat_percent = double.Parse(OneRow["gat_percent"].ToString());

                        }
                        if (objDr["patientsources_vchr"].ToString() == "外国")
                        {
                            OneRow["wg_peo"] = int.Parse(objDr["a1"].ToString());

                            objVo.m_intWg_peo = int.Parse(OneRow["wg_peo"].ToString());

                            ((clsPatientSoureVo)(objHashTable[OneRow["deptname"].ToString()])).m_intWg_peo = int.Parse(OneRow["wg_peo"].ToString());

                        }
                    }
            
                }
                foreach (DictionaryEntry var in objHashTable)
                {
                    clsPatientSoureVo objVo = (clsPatientSoureVo)var.Value as clsPatientSoureVo;
                    int intRow = p_dwRpt.InsertRow();
                    p_dwRpt.SetItemString(intRow, "deptname", objVo.m_strDeptname);
                    p_dwRpt.SetItemDouble(intRow, "bz_peo", objVo.m_intBz_peo);
                    p_dwRpt.SetItemDouble(intRow, "bz_ratio", objVo.m_dblBz_percent);
                    p_dwRpt.SetItemDouble(intRow, "bswz_peo", objVo.m_intBswz_peo);
                    p_dwRpt.SetItemDouble(intRow, "bswz_ratio", objVo.m_dblBswz_percent);
                    p_dwRpt.SetItemDouble(intRow, "bsqt_peo", objVo.m_intBsqt_peo);
                    p_dwRpt.SetItemDouble(intRow, "bsqt_ratio", objVo.m_dblBsqt_percent);
                    p_dwRpt.SetItemDouble(intRow, "ws_peo", objVo.m_intWs_peo);
                    p_dwRpt.SetItemDouble(intRow, "ws_ratio", objVo.m_dblWs_percent);
                    p_dwRpt.SetItemDouble(intRow, "gat_peo", objVo.m_intGat_peo);
                    p_dwRpt.SetItemDouble(intRow, "gat_ratio", objVo.m_dblGat_percent);
                    p_dwRpt.SetItemDouble(intRow, "wg_peo", objVo.m_intWg_peo);

                }
              
            }
            else
            {
                MessageBox.Show("没有检索到数据！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            p_dwRpt.CalculateGroups();
            p_dwRpt.Sort();
            p_dwRpt.SetRedrawOn();
            p_dwRpt.Refresh();
            objSvc = null;

        }
        class clsPatientSoureVo
        {
            /// <summary>
            /// 科室
            /// </summary>
            public string m_strDeptname = string.Empty;
            /// <summary>
            /// 本镇区人数
            /// </summary>
            public int m_intBz_peo;
            /// <summary>
            /// 本镇区比例
            /// </summary>
            public double m_dblBz_percent;
            /// <summary>
            /// 本市外镇人数
            /// </summary>
            public int m_intBswz_peo;
            /// <summary>
            /// 本市外镇比例
            /// </summary>
            public double m_dblBswz_percent;
            /// <summary>
            /// 本省其它市人数
            /// </summary>
            public int m_intBsqt_peo;
            /// <summary>
            /// 本省其它市比例
            /// </summary>
            public double m_dblBsqt_percent;
            /// <summary>
            /// 外省人数
            /// </summary>
            public int m_intWs_peo;
            /// <summary>
            /// 外省比例
            /// </summary>
            public double m_dblWs_percent;
            /// <summary>
            /// 港澳台人数
            /// </summary>
            public int m_intGat_peo;
            /// <summary>
            /// 港澳台比例
            /// </summary>
            public double m_dblGat_percent;
            /// <summary>
            /// 外国人数
            /// </summary>
            public int m_intWg_peo;
    
        }
       
    }
}
