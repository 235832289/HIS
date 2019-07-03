using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using Sybase.DataWindow;

namespace com.digitalwave.iCare.gui.HIS
{
    public class clsCtl_PBReport
    {
        #region 构造
        public clsCtl_PBReport()
        {
        }
        #endregion

        #region 门诊各科挂号人次统计报表
        /// <summary>
        /// 门诊各科挂号人次统计报表
        /// </summary>
        /// <param name="BeginDate"></param>
        /// <param name="EndDate"></param>
        public bool m_mthDeptReg(string BeginDate, string EndDate, ref DataWindowControl DWC)
        {
            bool ret = true;

            clsDomainConrol_Print objPrint = new clsDomainConrol_Print();

            DataTable dtDeptRpt;
            DataTable dtDeptSort;
            
            long l = objPrint.m_lngDepIncomerpt(BeginDate, EndDate, out dtDeptRpt, out dtDeptSort);
            if (l > 0)
            {
                try
                {
                    DWC.Reset();

                    DataView DV = new DataView(dtDeptRpt);
                    DataView DV2 = new DataView(dtDeptSort);

                    int prow = 0;
                    string pdeptname = "";
                    string cdeptname = "";

                    int Normal1Total = 0;
                    int Normal2Total = 0;
                    int ExpertTotal = 0;
                    int EmerTotal = 0;

                    Hashtable hasPDept = new Hashtable();
                    for (int i = 0; i < dtDeptSort.Rows.Count; i++)
                    {
                        if (dtDeptSort.Rows[i]["code_vchr"].ToString() != "1")
                        {
                            pdeptname = dtDeptSort.Rows[i]["parentname_vchr"].ToString();
                            if (pdeptname.Trim() != "" && !hasPDept.ContainsKey(pdeptname))
                            {
                                prow = DWC.InsertRow(0);
                                DWC.SetItemString(prow, "parentflag", "1");
                                DWC.SetItemString(prow, "deptname", pdeptname);
                                                               
                                DV2.RowFilter = "parentname_vchr = '" + pdeptname + "'";
                                foreach (DataRowView drv in DV2)
                                {
                                    cdeptname = drv["deptname_vchr"].ToString();

                                    DV.RowFilter = "deptname_vchr = '" + cdeptname + "'";
                                    //总数
                                    int total = DV.Count;
                                    //日诊
                                    DV.RowFilter = "deptname_vchr = '" + cdeptname + "' and trim(planperiod_chr) = '上午'";
                                    int day1 = DV.Count;
                                    DV.RowFilter = "deptname_vchr = '" + cdeptname + "' and trim(planperiod_chr) = '下午'";
                                    int day2 = DV.Count;
                                    //夜诊
                                    DV.RowFilter = "deptname_vchr = '" + cdeptname + "' and trim(planperiod_chr) = '晚上'";
                                    int day3 = DV.Count;


                                }

                                hasPDept.Add(pdeptname, null);
                            }
                        }
                        else
                        {
                            pdeptname = dtDeptSort.Rows[i]["deptname_vchr"].ToString();
                            if (pdeptname.Trim() != "" && !hasPDept.ContainsKey(pdeptname))
                            {
                                ArrayList cdeptarr = new ArrayList();
                                cdeptarr.Add(pdeptname);
                                hasPDept.Add(pdeptname, cdeptarr);
                            }
                        }
                    }






                    //ArrayList PDeptArr = new ArrayList();
                    //PDeptArr.AddRange(hasPDept.Keys);

                    //for (int i = 0; i < PDeptArr.Count; i++)
                    //{
                    //    pdeptname = PDeptArr[i].ToString();

                    //    ArrayList CDeptArr = hasPDept[pdeptname] as ArrayList;

                    //    prow = DWC.InsertRow(0);
                    //    DWC.SetItemString(prow, "parentflag", "1");
                    //    DWC.SetItemString(prow, "deptname", pdeptname);
                    //    for (int j = 0; j < CDeptArr.Count; j++)
                    //    {

                    //    }


                    //}




                }
                catch
                {
                    ret = false;
                }
            }

            objPrint = null;
            dtDeptRpt = null;
            dtDeptSort = null;

            return ret;
        }
        #endregion
    }
}
