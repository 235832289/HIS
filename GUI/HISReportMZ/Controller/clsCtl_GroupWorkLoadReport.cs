using System;
using com.digitalwave.iCare.common;//ObjectGenerator.dll
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.security;
using System.Data;
using com.digitalwave.iCare.middletier.HI;
using System.Drawing.Printing;
using System.Drawing;
namespace com.digitalwave.iCare.gui.HIS.Reports
{
    /// <summary>
    /// clsCtl_DoctorWorkLoadReport ��ժҪ˵����
    /// </summary>
    public class clsCtl_GroupWorkLoadReport : com.digitalwave.GUI_Base.clsController_Base
    {
        private clsDcl_DifficultyReport objSvc;
        /// <summary>
        /// �ϼ��ܶ���
        /// </summary>
        private DataRow drMain;
        /// <summary>
        /// �����ͷ��
        /// </summary>
        private DataRow drTitle;
        /// <summary>
        /// ȫ�����ݱ�
        /// </summary>
        public DataTable Mydt = new DataTable();
        private DataTable m_objTempTable;
        public clsCtl_GroupWorkLoadReport()
        {
            objSvc = new clsDcl_DifficultyReport();
            m_objTempTable = new DataTable();
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }
        #region ���ô������
        com.digitalwave.iCare.gui.HIS.Reports.frmGroupWorkLoadReport m_objViewer;
        /// <summary>
        /// ���ô������
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmGroupWorkLoadReport)frmMDI_Child_Base_in;
        }
        #endregion
        #region �����ʼ��
        public void m_mthFromLoad()
        {
            this.m_mthCreatTable();
        }
        #endregion
        #region ���ɱ�ṹ

        public void m_mthCreatTable()
        {
            Mydt.Columns.Clear();
            Mydt = new DataTable();
            Mydt.Columns.Add("����", typeof(String));
            Mydt.Columns.Add("�ϼ�", typeof(String));
            Mydt.Columns.Add("����", typeof(String));
            Mydt.Columns.Add("����", typeof(String));
            Mydt.Columns.Add("��������", typeof(String));
            Mydt.Columns.Add("����", typeof(String));
            Mydt.Columns.Add("����", typeof(String));
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
                drTitle["����"] = "��������";
                drTitle["�ϼ�"] = "�ϼ�";
                drTitle["����"] = "������";
                drTitle["����"] = "������";
                drTitle["��������"] = "��������";
                drTitle["����"] = "����";
                drTitle["����"] = "����";
                for (int i = 0; i < dtTemp.Rows.Count; i++)
                {
                    drTitle[dtTemp.Rows[i]["GROUPNAME_CHR"].ToString().Trim()] = dtTemp.Rows[i]["GROUPNAME_CHR"].ToString().Trim();
                }
                Mydt.Rows.Add(drTitle);
            }

        }
        #endregion

        #region ��ȡ�������������
        public void m_mthGetMultWorkLoadData(int flag)
        {
            //			Mydt.Rows.Clear();
            //			Mydt.Rows.Add(this.drTitle);//��ӱ�ͷ
            for (int iTemp = Mydt.Rows.Count - 1; iTemp > 0; iTemp--)
            {
                Mydt.Rows[iTemp].Delete();
            }
            #region �ռ�����
            decimal decSumMoney = 0;
            clsSingleWorkLoadSubItem_VO[] objSubArr = null;
            drMain = Mydt.NewRow();
            drMain["����"] = "�ϼ�";
            DataRow dr;
            DataTable dtTempZFS;
            DataTable dtTempFFS;
            DataTable dtPersonNums = new DataTable();
            long l = -1;
            long l1 = -1;
            long l2 = -1;
            if (this.m_objViewer.m_cboCheckMan.SelectItemValue == "1000")
            {
                if (this.m_objViewer.m_cboDept.SelectItemValue == "1000")
                {
                    l = objSvc.m_mthGetGroupWorkLoad(string.Empty, string.Empty, this.m_objViewer.m_daFinDate.Value, m_objViewer.m_daFinDateLast.Value, 0, out objSubArr);
                    l1 = objSvc.m_mthGetCount(string.Empty, string.Empty, this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), out dtTempZFS,out dtTempFFS);
                    l2 = objSvc.m_lngGetSeeDoctorPersonNums(string.Empty, string.Empty, this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), out dtPersonNums);
                }
                else
                {
                    l = objSvc.m_mthGetGroupWorkLoad(string.Empty, this.m_objViewer.m_cboDept.SelectItemValue, this.m_objViewer.m_daFinDate.Value, m_objViewer.m_daFinDateLast.Value, 0, out objSubArr);
                    l1 = objSvc.m_mthGetCount(string.Empty, this.m_objViewer.m_cboDept.SelectItemValue, this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), out dtTempZFS, out dtTempFFS);
                    l2 = objSvc.m_lngGetSeeDoctorPersonNums(string.Empty, this.m_objViewer.m_cboDept.SelectItemValue, this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), out dtPersonNums);
                }
            }
            else
            {
                if (this.m_objViewer.m_cboDept.SelectItemValue == "1000")
                {
                    l = objSvc.m_mthGetGroupWorkLoad(this.m_objViewer.m_cboCheckMan.SelectItemValue, string.Empty, this.m_objViewer.m_daFinDate.Value, m_objViewer.m_daFinDateLast.Value, 0, out objSubArr);
                    l1 = objSvc.m_mthGetCount(this.m_objViewer.m_cboCheckMan.SelectItemValue, string.Empty, this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), out dtTempZFS, out dtTempFFS);
                    l2 = objSvc.m_lngGetSeeDoctorPersonNums(this.m_objViewer.m_cboCheckMan.SelectItemValue, string.Empty, this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), out dtPersonNums);
                }
                else
                {
                    l = objSvc.m_mthGetGroupWorkLoad(this.m_objViewer.m_cboCheckMan.SelectItemValue, this.m_objViewer.m_cboDept.SelectItemValue, this.m_objViewer.m_daFinDate.Value, m_objViewer.m_daFinDateLast.Value, 0, out objSubArr);
                    l1 = objSvc.m_mthGetCount(this.m_objViewer.m_cboCheckMan.SelectItemValue, this.m_objViewer.m_cboDept.SelectItemValue, this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), out dtTempZFS, out dtTempFFS);
                    l2 = objSvc.m_lngGetSeeDoctorPersonNums(this.m_objViewer.m_cboCheckMan.SelectItemValue, this.m_objViewer.m_cboDept.SelectItemValue, this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd"), this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd"), out dtPersonNums);
                }
            }
            if (l > 0 && objSubArr != null)
            {
                dr = Mydt.NewRow();
                string strGroupTempName = objSubArr[0].m_strGroupName.Trim();
                dr["����"] = strGroupTempName;

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
                        dr["�ϼ�"] = decSumMoney;
                        for (int intCount = 0; intCount < dtTempZFS.Rows.Count; intCount++)
                        {
                            if (strGroupTempName == dtTempZFS.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                            {
                                dr["����"] = dtTempZFS.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtTempZFS.Rows[intCount]["����"].ToString().Trim();
                                //dr["����"] = dtTemp.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtTemp.Rows[intCount]["����"].ToString().Trim();
                                drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTempZFS.Rows[intCount]["����"]);
                                //drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTemp.Rows[intCount]["����"]);
                                break;
                            }
                        }
                        for (int intCount = 0; intCount < dtTempFFS.Rows.Count; intCount++)
                        {
                            if (strGroupTempName == dtTempFFS.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                            {
                                //dr["����"] = dtTemp.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtTemp.Rows[intCount]["����"].ToString().Trim();
                                dr["����"] = dtTempFFS.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtTempFFS.Rows[intCount]["����"].ToString().Trim();
                               // drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTemp.Rows[intCount]["����"]);
                                drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTempFFS.Rows[intCount]["����"]);
                                break;
                            }
                        }
                        for (int intCount = 0; intCount < dtPersonNums.Rows.Count; intCount++)
                        {
                            if (strGroupTempName == dtPersonNums.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                            {
                                dr["��������"] = dtPersonNums.Rows[intCount]["��������"].ToString().Trim() == "0" ? "" : dtPersonNums.Rows[intCount]["��������"].ToString().Trim();
                                drMain["��������"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["��������"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtPersonNums.Rows[intCount]["��������"]);

                                dr["����"] = dtPersonNums.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtPersonNums.Rows[intCount]["����"].ToString().Trim();
                                drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtPersonNums.Rows[intCount]["����"]);

                                dr["����"] = dtPersonNums.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtPersonNums.Rows[intCount]["����"].ToString().Trim();
                                drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtPersonNums.Rows[intCount]["����"]);
                                break;
                            }
                        }

                        Mydt.Rows.Add(dr);
                        drMain["�ϼ�"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["�ϼ�"]) + decSumMoney;
                        dr = Mydt.NewRow();
                        strGroupTempName = objSubArr[i].m_strGroupName.Trim();
                        dr["����"] = strGroupTempName;
                        dr[objSubArr[i].m_strCatName] = objSubArr[i].m_strCatMoney;
                        decSumMoney = clsConvertToDecimal.m_mthConvertObjToDecimal(objSubArr[i].m_strCatMoney);
                    }
                }
                //ͳ�ƽ���������һ����ӵ����
                dr["�ϼ�"] = decSumMoney;
                drMain["�ϼ�"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["�ϼ�"]) + decSumMoney;
                for (int intCount = 0; intCount < dtTempZFS.Rows.Count; intCount++)
                {
                    if (strGroupTempName == dtTempZFS.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                    {
                        dr["����"] = dtTempZFS.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtTempZFS.Rows[intCount]["����"].ToString().Trim();
                       // dr["����"] = dtTempZFS.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtTempZFS.Rows[intCount]["����"].ToString().Trim();
                        drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTempZFS.Rows[intCount]["����"]);
                       // drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTemp.Rows[intCount]["����"]);
                        break;
                    }
                }
                for (int intCount = 0; intCount < dtTempFFS.Rows.Count; intCount++)
                {
                    if (strGroupTempName == dtTempFFS.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                    {
                        //dr["����"] = dtTemp.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtTemp.Rows[intCount]["����"].ToString().Trim();
                        dr["����"] = dtTempFFS.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtTempFFS.Rows[intCount]["����"].ToString().Trim();
                       // drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTemp.Rows[intCount]["����"]);
                        drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtTempFFS.Rows[intCount]["����"]);
                        break;
                    }
                }
                for (int intCount = 0; intCount < dtPersonNums.Rows.Count; intCount++)
                {
                    if (strGroupTempName == dtPersonNums.Rows[intCount]["GROUPNAME_VCHR"].ToString().Trim())
                    {
                        dr["��������"] = dtPersonNums.Rows[intCount]["��������"].ToString().Trim() == "0" ? "" : dtPersonNums.Rows[intCount]["��������"].ToString().Trim();
                        drMain["��������"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["��������"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtPersonNums.Rows[intCount]["��������"]);

                        dr["����"] = dtPersonNums.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtPersonNums.Rows[intCount]["����"].ToString().Trim();
                        drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtPersonNums.Rows[intCount]["����"]);

                        dr["����"] = dtPersonNums.Rows[intCount]["����"].ToString().Trim() == "0" ? "" : dtPersonNums.Rows[intCount]["����"].ToString().Trim();
                        drMain["����"] = clsConvertToDecimal.m_mthConvertObjToDecimal(drMain["����"]) + clsConvertToDecimal.m_mthConvertObjToDecimal(dtPersonNums.Rows[intCount]["����"]);
                        break;
                    }
                }
                Mydt.Rows.Add(dr);
            }

            #endregion
            DataRow drr = Mydt.NewRow();
            drr[0] = "�ܼ�";
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
            //int intAgv = 12;
            int intAgv = int.Parse(this.m_objViewer.comboBox1.Text);
            DataTable dt = new DataTable();
            int col = Mydt.Columns.Count;
            for (int i = 0; i < col; i++)
            {
                dt.Columns.Add(Mydt.Columns[i].ColumnName);

                if (dt.Columns.Count % intAgv == 0&&i!=col-1)
                {
                    // intAgv--;
                    colindex++;

                    dt.Columns.Add("��������" + colindex.ToString());
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
                    drTemp2["��������" + i3.ToString()] = Mydt.Rows[i][0];
                }
                dt.Rows.Add(drTemp2);
            }
            Mydt = dt;
            m_objTempTable = Mydt.Clone();
            DataRow m_objDataRow;
            for (int i = 0; i < Mydt.Rows.Count; i++)
            {
                m_objDataRow = m_objTempTable.NewRow();
               object[] m_obj=Mydt.Rows[i].ItemArray;
               m_objDataRow.ItemArray = m_obj;
               m_objTempTable.Rows.Add(m_objDataRow);
            }
            m_objTempTable.AcceptChanges();
           
        }
        #endregion
        #region ��ʼ��ӡ
        private clsPrintDataTable objPrint = null;
        public void m_mthBeginPrint(System.Drawing.Printing.PrintEventArgs e)
        {

            //			objPrint =new clsPrintDataTable();
            this.m_objViewer.myPrintPreViewControl1.m_mthSetDataSource(this.Mydt);

            this.m_objViewer.myPrintPreViewControl1.BeginTime = this.m_objViewer.m_daFinDate.Value.ToString("yyyy-MM-dd");
            this.m_objViewer.myPrintPreViewControl1.EndTime = this.m_objViewer.m_daFinDateLast.Value.ToString("yyyy-MM-dd");
            this.m_objViewer.myPrintPreViewControl1.HospitalName = m_objComInfo.m_strGetHospitalTitle();
            this.m_objViewer.myPrintPreViewControl1.Printer = this.m_objViewer.LoginInfo.m_strEmpName;
            this.m_objViewer.myPrintPreViewControl1.BlnCustomFlag = true;
            this.m_objViewer.myPrintPreViewControl1.strCheckName = this.m_objViewer.m_cboCheckMan.Text;
            this.m_objViewer.myPrintPreViewControl1.strDeptName = this.m_objViewer.m_cboDept.Text;
            this.m_objViewer.myPrintPreViewControl1.ReportName = "�����������ͳ�Ʊ�";
        }
        #endregion
        #region ��ӡ
        public void m_mthPrint(System.Drawing.Printing.PrintPageEventArgs e)
        {
            //			objPrint.m_mthPrintMultWorkLoad(e);
        }
        #endregion
        #region ��ӡ
        public void m_mthEndPrint(System.Drawing.Printing.PrintEventArgs e)
        {
            objPrint = null;
            Mydt.Clear();
            DataRow m_objDataRow;
            for (int i = 0; i < m_objTempTable.Rows.Count; i++)
            {
                m_objDataRow = Mydt.NewRow();
                object[] m_obj = m_objTempTable.Rows[i].ItemArray;
                m_objDataRow.ItemArray = m_obj;
                Mydt.Rows.Add(m_objDataRow);
            }
            Mydt.AcceptChanges();
        }
        #endregion



    }
}

