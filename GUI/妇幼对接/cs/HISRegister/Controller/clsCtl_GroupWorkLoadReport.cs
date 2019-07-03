using System;
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using com.digitalwave.iCare.middletier.HI;
using System.Drawing.Printing;
using System.Drawing;
namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// clsCtl_DoctorWorkLoadReport 的摘要说明。
    /// </summary>
    public class clsCtl_GroupWorkLoadReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDcl_DifficultyReport objSvc;
        /// <summary>
        /// 合计总额行
        /// </summary>
        private DataRow drMain;
        /// <summary>
        /// 表的列头行
        /// </summary>
        private DataRow drTitle;
        /// <summary>
        /// 全局数据表
        /// </summary>
        public DataTable Mydt = new DataTable();
        public clsCtl_GroupWorkLoadReport()
        {
            objSvc = new clsDcl_DifficultyReport();

            //
            // TODO: 在此处添加构造函数逻辑
            //
        }
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmGroupWorkLoadReport m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmGroupWorkLoadReport)frmMDI_Child_Base_in;
        }
        #endregion
        #region 窗体初始化
        public void m_mthFromLoad()
        {
            this.m_mthCreatTable();
        }
        #endregion

        #region 生成表结构
        /// <summary>
        /// 生成表结构
        /// </summary>
        public void m_mthCreatTable()
        {
            Mydt.Columns.Clear();
            Mydt = new DataTable();
            Mydt.Columns.Add("名称", typeof(String));
            Mydt.Columns.Add("合计", typeof(String));
            Mydt.Columns.Add("正方", typeof(String));
            Mydt.Columns.Add("副方", typeof(String));
            Mydt.Columns.Add("就诊人数", typeof(String));
            Mydt.Columns.Add("药品让利", typeof(string));
            Mydt.Columns.Add("材料让利", typeof(string));
            DataTable dtTemp;
            long ret = objSvc.m_mthReportColumns(out dtTemp, "0066");
            if (ret > 0 && dtTemp.Rows.Count > 0)
            {
                DataColumn dtcol;
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    dtcol = new DataColumn();
                    dtcol.DataType = typeof(System.String);
                    dtcol.DefaultValue = 0;
                    dtcol.ColumnName = dtTemp.Rows[i]["GROUPNAME_CHR"].ToString().Trim();
                    this.Mydt.Columns.Add(dtcol);
                }
                drTitle = Mydt.NewRow();
                drTitle["名称"] = "分组名称";
                drTitle["合计"] = "合计";
                drTitle["正方"] = "正方数";
                drTitle["副方"] = "副方数";
                drTitle["就诊人数"] = "就诊人数";
                drTitle["药品让利"] = "药品让利";
                drTitle["材料让利"] = "材料让利";
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    drTitle[dtTemp.Rows[i]["GROUPNAME_CHR"].ToString().Trim()] = dtTemp.Rows[i]["GROUPNAME_CHR"].ToString().Trim();
                }
                Mydt.Rows.Add(drTitle);
            }

        }
        #endregion

        #region 获取多个工作量数据
        /// <summary>
        /// 获取多个工作量数据
        /// </summary>
        /// <param name="flag"></param>
        public void m_mthGetMultWorkLoadData(int flag)
        {
            //			Mydt.Rows.Clear();
            //			Mydt.Rows.Add(this.drTitle);//添加表头
            for (int iTemp = Mydt.Rows.Count - 1; iTemp > 0; iTemp--)
            {
                Mydt.Rows[iTemp].Delete();
            }
            #region 收集数据
            decimal decSumMoney = 0;
            clsSingleWorkLoadSubItem_VO[] objSubArr = null;
            drMain = Mydt.NewRow();
            drMain["名称"] = "合计";
            DataRow dr;
            // 0-全院 1-大院
            int intflag = 0;
            if (m_objViewer.comboBox2.Text == "全院")
            {
                intflag = 0;
            }
            else if (m_objViewer.comboBox2.Text == "大院")
            {
                intflag = 1;
            }
            long l = objSvc.m_mthGetGroupWorkLoad("", this.m_objViewer.m_daFinDate.Value, m_objViewer.m_daFinDateLast.Value, 0, intflag, out objSubArr);
            DataTable dtTemp;
            long l1 = objSvc.m_mthGetCount(this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), intflag, out dtTemp);
            DataTable dtPersonNums = new DataTable();
            long l2 = objSvc.m_lngGetSeeDoctorPersonNums(this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), intflag, out dtPersonNums);
            if (l > 0 && objSubArr != null)
            {
                dr = Mydt.NewRow();
                string strGroupTempName = objSubArr[0].m_strGroupName.Trim();
                dr["名称"] = strGroupTempName;

                for (int i = 0; i < objSubArr.Length; i++)
                {
                    if (strGroupTempName == objSubArr[i].m_strGroupName.Trim())
                    {
                        dr[objSubArr[i].m_strCatName] = objSubArr[i].m_strCatMoney;
                        drMain[objSubArr[i].m_strCatName] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain[objSubArr[i].m_strCatName]) + clsConvertToDecimal.m_mthConvertObjToDecimal(objSubArr[i].m_strCatMoney);
                        decSumMoney += clsConvertToDecimal.m_mthConvertObjToDecimal(objSubArr[i].m_strCatMoney);
                    }
                    else
                    {
                        dr["合计"] = decSumMoney;
                        for (int intCount = 0; intCount < dtTemp.Rows.Count; intCount++)
                        {
                            if (strGroupTempName == dtTemp.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                            {
                                dr["正方"] = dtTemp.Rows[intCount]["正方"].ToString().Trim() == "0" ? "" : dtTemp.Rows[intCount]["正方"].ToString().Trim();
                                dr["副方"] = dtTemp.Rows[intCount]["副方"].ToString().Trim() == "0" ? "" : dtTemp.Rows[intCount]["副方"].ToString().Trim();
                                drMain["正方"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["正方"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTemp.Rows[intCount]["正方"]);
                                drMain["副方"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["副方"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTemp.Rows[intCount]["副方"]);
                                break;
                            }
                        }

                        for (int intCount = 0; intCount < dtPersonNums.Rows.Count; intCount++)
                        {
                            if (strGroupTempName == dtPersonNums.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                            {
                                dr["就诊人数"] = dtPersonNums.Rows[intCount]["就诊人数"].ToString().Trim() == "0" ? "" : dtPersonNums.Rows[intCount]["就诊人数"].ToString().Trim();
                                drMain["就诊人数"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["就诊人数"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtPersonNums.Rows[intCount]["就诊人数"]);
                                break;
                            }
                        }

                        Mydt.Rows.Add(dr);
                        drMain["合计"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["合计"]) + decSumMoney;
                        dr = Mydt.NewRow();
                        strGroupTempName = objSubArr[i].m_strGroupName.Trim();
                        dr["名称"] = strGroupTempName;
                        dr[objSubArr[i].m_strCatName] = objSubArr[i].m_strCatMoney;
                        decSumMoney = clsConvertToDecimal.m_mthConvertObjToDecimal(objSubArr[i].m_strCatMoney);
                    }
                }
                //统计结束后把最后一行添加到表格
                dr["合计"] = decSumMoney;
                drMain["合计"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["合计"]) + decSumMoney;
                for (int intCount = 0; intCount < dtTemp.Rows.Count; intCount++)
                {
                    if (strGroupTempName == dtTemp.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                    {
                        dr["正方"] = dtTemp.Rows[intCount]["正方"].ToString().Trim() == "0" ? "" : dtTemp.Rows[intCount]["正方"].ToString().Trim();
                        dr["副方"] = dtTemp.Rows[intCount]["副方"].ToString().Trim() == "0" ? "" : dtTemp.Rows[intCount]["副方"].ToString().Trim();
                        drMain["正方"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["正方"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTemp.Rows[intCount]["正方"]);
                        drMain["副方"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["副方"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTemp.Rows[intCount]["副方"]);
                        break;
                    }
                }
                for (int intCount = 0; intCount < dtPersonNums.Rows.Count; intCount++)
                {
                    if (strGroupTempName == dtPersonNums.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                    {
                        dr["就诊人数"] = dtPersonNums.Rows[intCount]["就诊人数"].ToString().Trim() == "0" ? "" : dtPersonNums.Rows[intCount]["就诊人数"].ToString().Trim();
                        drMain["就诊人数"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["就诊人数"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtPersonNums.Rows[intCount]["就诊人数"]);
                        break;
                    }
                }
                Mydt.Rows.Add(dr);
            }

            #endregion
            DataRow drr = Mydt.NewRow();
            drr[0] = "总计";
            for (int i = 0; i < Mydt.Rows.Count; i++)
            {
                for (int i2 = 1; i2 < Mydt.Columns.Count; i2++)
                {
                    drr[i2] = clsConvertToDecimal.m_mthConvertObjToDecimal(drr[i2]) + clsConvertToDecimal.m_mthConvertObjToDecimal(Mydt.Rows[i][i2]);
                }
            }
            //Mydt.Rows.Add(drMain);
            Mydt.Rows.Add(drr);
            Mydt.AcceptChanges();
            int colindex = 0;
            int intAgv = int.Parse(this.m_objViewer.comboBox1.Text);
            DataTable dt = new DataTable();
            int col = Mydt.Columns.Count;
            for (int i = 0; i < col; i++)
            {
                dt.Columns.Add(Mydt.Columns[i].ColumnName);

                if (dt.Columns.Count % intAgv == 0 && i != col - 1)
                {
                    // intAgv--;
                    colindex++;

                    dt.Columns.Add("分组名称" + colindex.ToString());
                }
            }
            DataRow drTemp2 = null;
            for (int i = 0; i < Mydt.Rows.Count; i++)
            {
                drTemp2 = dt.NewRow();
                for (int i2 = 0; i2 < Mydt.Columns.Count; i2++)
                {
                    drTemp2[Mydt.Columns[i2].ColumnName] = Mydt.Rows[i][i2].ToString().Trim() == "0" ? "" : Mydt.Rows[i][i2].ToString().Trim();
                }
                for (int i3 = 1; i3 <= colindex; i3++)
                {
                    drTemp2["分组名称" + i3.ToString()] = Mydt.Rows[i][0];
                }
                dt.Rows.Add(drTemp2);
            }

            Mydt = dt;
        }
        #endregion
        #region 开始打印
        private clsPrintDataTable objPrint = null;
        public void m_mthBeginPrint(System.Drawing.Printing.PrintEventArgs e)
        {

            //			objPrint =new clsPrintDataTable();
            this.m_objViewer.myPrintPreViewControl1.m_mthSetDataSource(this.Mydt);

            this.m_objViewer.myPrintPreViewControl1.BeginTime = this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd");
            this.m_objViewer.myPrintPreViewControl1.EndTime = this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd");
            this.m_objViewer.myPrintPreViewControl1.HospitalName = m_objComInfo.m_strGetHospitalTitle();
            this.m_objViewer.myPrintPreViewControl1.Printer = this.m_objViewer.LoginInfo.m_strEmpName;
            this.m_objViewer.myPrintPreViewControl1.ReportName = "门诊收入分组统计表";
        }
        #endregion
        #region 打印
        public void m_mthPrint(System.Drawing.Printing.PrintPageEventArgs e)
        {
            //			objPrint.m_mthPrintMultWorkLoad(e);
        }
        #endregion
        #region 打印
        public void m_mthEndPrint(System.Drawing.Printing.PrintEventArgs e)
        {
            objPrint = null;
        }
        #endregion



    }
}

