using System; 
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.OracleClient;
using System.Data;
using System.Xml; 
using com.digitalwave.iCare.common;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.middletier.CommunityInterface;
using System.Collections;

namespace com.digitalwave.iCare.gui.DataCollection
{
    public class clsReceiveData
    {
        public clsReceiveData()
        {
            XmlDocument document = new XmlDocument();
            document.Load("LoginFile.xml");
            XmlNodeList IPElements = document.GetElementsByTagName("MiddleServers");
            this.m_glstMiddleter = new List<string>();

            for (int i = 0; i < IPElements.Count; i++)
            {
                for (int j = 0; j < IPElements[i].ChildNodes.Count; j++)
                {
                    this.m_glstMiddleter.Add(IPElements[i].ChildNodes[j].InnerText);
                }
            }

            if (this.m_glstMiddleter.Count < 0)
            {
                MessageBox.Show("程序不是三层配置，将在两层环境下运行。");
            }

            //this.m_strHospitalID = clsUploadData.m_strReadXML("DONGGUAN.CHASHANCommunity", "CSHospitalNO", "AnyOne");
            this.m_strHospitalID = clsPublic.m_strConvertValue("DSN", "hospitalcode", "457226325");
        }
        private ListView m_lsvMain;

        private string m_strHospitalID = string.Empty;

        private List<string> m_glstMiddleter = null;

        private void m_mthAddListItem(string p_strName)
        {
            ListViewItem lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lsvItem.SubItems.Add("正在收集 " + p_strName + " 数据，请稍后...");
            this.m_lsvMain.Items.Insert(0, lsvItem);

            this.m_lsvMain.Refresh();
        }

        private void m_mthAddListItem(string p_strName, int intFlag)
        {
            if (intFlag == 1)
            {
                ListViewItem lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("正在收集出院病人 " + p_strName + " 数据.");
                this.m_lsvMain.Items.Insert(0, lsvItem);
            }
            else if (intFlag == 2)
            {
                ListViewItem lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("正在整理出院病人信息数据 " + p_strName + ".");
                this.m_lsvMain.Items.Insert(0, lsvItem);
            }
            else if (intFlag == 3)
            {
                ListViewItem lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("正在整理出院病人收费数据" + p_strName + ".");
                this.m_lsvMain.Items.Insert(0, lsvItem);
            }
            else if (intFlag == 3)
            {
                ListViewItem lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("正在整理出院病人医嘱数据" + p_strName + ".");
                this.m_lsvMain.Items.Insert(0, lsvItem);
            }
            else if (intFlag == 4)
            {
                ListViewItem lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("正在整理入院病人信息数据" + p_strName + ".");
                this.m_lsvMain.Items.Insert(0, lsvItem);
            }

            this.m_lsvMain.Refresh();
        }

        public long m_lngUpload(DateTime p_dtmDate, Label p_lblInfor, ListView p_lsvInfor)
        {
            long lngRes = -1;
            m_lsvMain = p_lsvInfor;

            p_lblInfor.Text = "正在统计需要上传的人数，请稍后...";
            ListViewItem lsvItem;

            #region 统计人数
            ///////////////////////////////////////////////////////////////////////
            lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lsvItem.SubItems.Add("正在统计需要上传人数");
            m_lsvMain.Items.Insert(0, lsvItem);
            p_lblInfor.Refresh();
            p_lsvInfor.Refresh();

            List<string> m_glsInRegID = null;
            List<string> m_glsOutRegID = null;
            if (m_glstMiddleter != null || m_glstMiddleter.Count > 0)
            {
                clsObjectGenerator.ltServers = this.m_glstMiddleter;
            }

            clsCommunityInterface_Svc objSvc = (clsCommunityInterface_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsCommunityInterface_Svc));
            lngRes = objSvc.m_lngGetPatientCount(p_dtmDate.ToString("yyyy-MM-dd"), out m_glsInRegID, out m_glsOutRegID);
            objSvc.Dispose();
            objSvc = null;
            if (lngRes < 0)
            {
                return lngRes;
            }

            if (m_glsInRegID != null && m_glsInRegID.Count > 0)
            {
                p_lblInfor.Text = "入院人数：" + m_glsInRegID.Count;
            }
            else
            {
                p_lblInfor.Text = "入院人数：0 ";
            }

            if (m_glsOutRegID != null && m_glsOutRegID.Count > 0)
            {
                p_lblInfor.Text += "  出院人数：" + m_glsOutRegID.Count;
            }
            else
            {
                p_lblInfor.Text += "  出院人数：0";
            }
            lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lsvItem.SubItems.Add(p_lblInfor.Text.ToString());
            lsvItem.ForeColor = System.Drawing.Color.DarkRed;
            m_lsvMain.Items.Insert(0, lsvItem);
            p_lblInfor.Refresh();
            p_lsvInfor.Refresh();
            /////////////////////////////////////////////////////////////////////
            #endregion

            int intTotolInfor = 0;

            #region 入院病人信息
            List<clsHospRecordCS_Vo> m_glsInHospInfor = null; ;
            if (m_glsInRegID != null && m_glsInRegID.Count > 0)
            {
                intTotolInfor += m_glsInRegID.Count;
                p_lblInfor.Text = "正在统计入院病人的信息,请稍后.....";
                lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add(p_lblInfor.Text.ToString());
                m_lsvMain.Items.Insert(0, lsvItem);
                p_lblInfor.Refresh();
                p_lsvInfor.Refresh();
                if (m_glstMiddleter != null || m_glstMiddleter.Count > 0)
                {
                    clsObjectGenerator.ltServers = this.m_glstMiddleter;
                }

                objSvc = (clsCommunityInterface_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsCommunityInterface_Svc));
                lngRes = objSvc.m_lngGetInpatientInfo(m_glsInRegID, out m_glsInHospInfor);
                objSvc.Dispose();
                objSvc = null;


                p_lblInfor.Text = "完成统计";
                lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("统计入院病人信息完成,共" + m_glsInHospInfor.Count + " 人");
                lsvItem.ForeColor = System.Drawing.Color.DarkRed;
                m_lsvMain.Items.Insert(0, lsvItem);
                p_lblInfor.Refresh();
                p_lsvInfor.Refresh();
            }
            #endregion

            #region 出院病人信息
            List<clsHospBillCS_Vo> m_glsMianHospBill = null;
            List<clsHospOrderCS_Vo> m_glsMianHospOrder = null;
            List<clsHospRecordCS_Vo> m_glsMianhospRecord = null;
            if (m_glsOutRegID != null && m_glsOutRegID.Count > 0)
            {
                p_lblInfor.Text = "正在统计出院病人信息,请稍后...";
                p_lblInfor.Refresh();
                m_glsMianHospBill = new List<clsHospBillCS_Vo>();//发票信息
                m_glsMianHospOrder = new List<clsHospOrderCS_Vo>();//医嘱信息
                m_glsMianhospRecord = new List<clsHospRecordCS_Vo>();//个人信息

                int PatientCount = m_glsOutRegID.Count;
                for (int i1 = 0; i1 < PatientCount; i1++)
                {
                    this.m_mthAddListItem(m_glsOutRegID[i1].ToString(), 1);

                    List<clsHospBillCS_Vo> m_glsNewHospBill = null;
                    List<clsHospOrderCS_Vo> m_glsNewHospOrder = null;
                    clsHospRecordCS_Vo m_objRecord = null;

                    if (m_glstMiddleter != null || m_glstMiddleter.Count > 0)
                    {
                        clsObjectGenerator.ltServers = this.m_glstMiddleter;
                    }
                    objSvc = (clsCommunityInterface_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsCommunityInterface_Svc));
                    lngRes = objSvc.m_lngGetOutPatientInfor(m_glsOutRegID[i1], out m_objRecord, out m_glsNewHospBill, out m_glsNewHospOrder);
                    objSvc.Dispose();
                    objSvc = null;

                    if (m_glsNewHospBill != null && m_glsNewHospBill.Count > 0)
                    {
                        m_glsMianHospBill.AddRange(m_glsNewHospBill);
                    }
                    if (m_glsNewHospOrder != null && m_glsNewHospOrder.Count > 0)
                    {
                        m_glsMianHospOrder.AddRange(m_glsNewHospOrder);
                    }
                    if (m_objRecord != null)
                    {
                        m_glsMianhospRecord.Add(m_objRecord);
                    }

                    System.Threading.Thread.Sleep(500);
                }
                intTotolInfor += m_glsMianHospBill.Count + m_glsMianHospOrder.Count + m_glsMianhospRecord.Count;

                p_lblInfor.Text = "出院病人数据整理完成.";
                lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("出院病人数据整理完成.  一共" + m_glsMianhospRecord.Count.ToString() + "条数据. ");
                lsvItem.ForeColor = System.Drawing.Color.DarkRed;
                m_lsvMain.Items.Insert(0, lsvItem);
                p_lblInfor.Refresh();
                p_lsvInfor.Refresh();
            }
            #endregion

            lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lsvItem.SubItems.Add("住院信息收集完成!");
            lsvItem.ForeColor = System.Drawing.Color.DarkBlue;
            m_lsvMain.Items.Insert(0, lsvItem);

            #region 整理信息

            List<string> m_glsSQL = new List<string>(intTotolInfor);
            p_lblInfor.Text = "正在整理信息,请稍后.....";
            p_lblInfor.Refresh();
            string strSQL = "";
            int intLen = 0;
            if (m_glsInHospInfor != null)
            {
                intLen = m_glsInHospInfor.Count;
                //去除重复数据
                Hashtable objHsTable = new Hashtable();
                for (int i = 0; i < intLen; i++)
                {
                    clsHospRecordCS_Vo obj = m_glsInHospInfor[i];
                    try
                    {
                        objHsTable.Add(obj.m_strRegisterID, "");
                    }
                    catch
                    {
                        continue;
                    }
                    //this.m_mthAddListItem(obj.m_strRegisterID, 4);
                    strSQL = @"insert into hosp_hospitalizationrecord
                                        (name, sex, kind,
                                         ethnicgroup, address, jobtitle,phonenumberhome,
                                         contactperson, nationality, maritalstatus,birthday,
                                         idnumbers, ssid, inhospno,
                                         inhosseqno,clinicid, patientbed, indeptcode, 
                                         indeptname, maincuredocname,maincuredoccode, indate, 
                                         diagnosisname1, diagnosiscode1,inhosptime
                                        )
              values('" + obj.m_strName + "','" + obj.m_strSex + "','" + obj.m_strKind + "','" +
                         obj.m_strEthnicGroup + "','" + obj.m_strAddress + "','" + obj.m_strJobTitle + "','" + obj.m_strPhoneNum + "','" +
                         obj.m_strContactPerson + "','" + obj.m_strNationality + "','" + obj.m_strMaritalStatus + "',to_date('" + obj.m_dtmBirthDay.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),'" +
                         obj.m_strIDNumber + "','" + obj.m_strSSID + "','" + obj.m_strInHospNO + "','" +
                         obj.m_strRegisterID + "','" + obj.m_strClinicID + "','" + obj.m_strBedNO + "','" + obj.m_strInDeptCode + "','" +
                         obj.m_strInDeptName + "','" + obj.m_strMainDoctorName + "','" + obj.m_strMainDoctorID + "', to_date('" + obj.m_dtmInDate.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),'" +
                         obj.m_strInDiagnosName + "','" + obj.m_strInDiagnosCode + "','" + obj.m_intInHospCount.ToString() + "')";
                    m_glsSQL.Add(strSQL);
                }
                m_glsInHospInfor = null;
                lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("入院病人数据整理完成.  一共" + m_glsSQL.Count.ToString() + "条数据. ");
                lsvItem.ForeColor = System.Drawing.Color.DarkRed;
                m_lsvMain.Items.Insert(0, lsvItem);
                p_lsvInfor.Refresh();

                //System.Threading.Thread.Sleep(1000);
            }

            strSQL = "";
            if (m_glsMianhospRecord != null)
            {
                intLen = m_glsMianhospRecord.Count;
                Hashtable objHsTable = new Hashtable();
                for (int i = 0; i < intLen; i++)
                {

                    clsHospRecordCS_Vo obj = m_glsMianhospRecord[i];
                    try
                    {
                        objHsTable.Add(obj.m_strRegisterID, "");
                    }
                    catch
                    {
                        continue;
                    }
                    //this.m_mthAddListItem(obj.m_strRegisterID, 2);
                    strSQL = @"insert into hosp_hospitalizationrecord
                                        (name, sex, kind,
                                         ethnicgroup, address, jobtitle,phonenumberhome,
                                         contactperson, nationality, maritalstatus,birthday,
                                         idnumbers, ssid, inhospno,
                                         inhosseqno,clinicid, patientbed, indeptcode, 
                                         indeptname, maincuredocname,maincuredoccode, indate, 
                                         diagnosisname1, diagnosiscode1,inhosptime, 
                                         diagnosiscode2, status,
                                         outdeptcode, outdeptname, leftdate, inhospdays
                                        )
              values('" + obj.m_strName + "','" + obj.m_strSex + "','" + obj.m_strKind + "','" +
                         obj.m_strEthnicGroup + "','" + obj.m_strAddress + "','" + obj.m_strJobTitle + "','" + obj.m_strPhoneNum + "','" +
                         obj.m_strContactPerson + "','" + obj.m_strNationality + "','" + obj.m_strMaritalStatus + "',to_date('" + obj.m_dtmBirthDay.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),'" +
                         obj.m_strIDNumber + "','" + obj.m_strSSID + "','" + obj.m_strInHospNO + "','" +
                         obj.m_strRegisterID + "','" + obj.m_strClinicID + "','" + obj.m_strBedNO + "','" + obj.m_strInDeptCode + "','" +
                         obj.m_strInDeptName + "','" + obj.m_strMainDoctorName + "','" + obj.m_strMainDoctorID + "', to_date('" + obj.m_dtmInDate.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),'" +
                         obj.m_strInDiagnosName + "','" + obj.m_strInDiagnosCode + "','" + obj.m_intInHospCount.ToString() +
                         "','" + obj.m_strOutDiagnosName + "','" + obj.m_strStatus + "','" + obj.m_strOutDeptCode + "','" + obj.m_strOutDeptName +
                         "',to_date('" + obj.m_dtmOutDate.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')" + ",'" + obj.m_intHospDay.ToString() + "')";
                    m_glsSQL.Add(strSQL);
                }
                m_glsMianhospRecord = null;
                lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("出院病人数据整理完成.  一共" + intLen.ToString() + "条数据. ");
                lsvItem.ForeColor = System.Drawing.Color.DarkRed;
                m_lsvMain.Items.Insert(0, lsvItem);
                p_lsvInfor.Refresh();

                //System.Threading.Thread.Sleep(1000);
            }

            strSQL = "";
            if (m_glsMianHospBill != null)
            {
                intLen = m_glsMianHospBill.Count;
                System.Collections.ArrayList arrTmp = new System.Collections.ArrayList();
                Hashtable objHsTable = new Hashtable();
                for (int i = 0; i < intLen; i++)
                {
                    clsHospBillCS_Vo obj = m_glsMianHospBill[i];
                    try
                    {
                        objHsTable.Add(obj.m_strRegisterID + obj.m_strInvoNo + obj.m_strFareCode + obj.m_strFareName, "");
                    }
                    catch
                    {
                        continue;
                    }
                    //if (!arrTmp.Contains(obj.m_strInvoNo))
                    //{
                    //    arrTmp.Add(obj.m_strInvoNo);
                    //    this.m_mthAddListItem(obj.m_strInvoNo, 3);
                    //}
                    strSQL = @"insert into Hosp_HospitalizationBill
            (inhosseqno, billno, faretotal, 
             fareselfpay,accountstartdate, accountenddate, billdate,
             kind, farecode, farename, sum
            )
            values('" + obj.m_strRegisterID + "','" + obj.m_strInvoNo + "','" + obj.m_dclInvoTotolMoney.ToString() + "','" +
                       obj.m_dclInvoFSPMoney.ToString() + "',to_date('" + obj.m_dtmBeginDate.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'), to_date('" + obj.m_dtmEndDate.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')," +
                       " to_date('" + obj.m_dtmBillDate.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss'),'" + obj.m_strKind + "','" + obj.m_strFareCode + "','" +
                       obj.m_strFareName + "','" + obj.m_dclSubMoney + "')";
                    m_glsSQL.Add(strSQL);
                }
                m_glsMianhospRecord = null;
                lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("病人费用整理完成.  一共" + intLen.ToString() + "条数据. ");
                lsvItem.ForeColor = System.Drawing.Color.DarkRed;
                m_lsvMain.Items.Insert(0, lsvItem);
                p_lsvInfor.Refresh();
            }

            if (m_glsMianHospOrder != null && m_glsMianHospOrder.Count > 0)
            {
                //intLen = m_glsMianHospOrder.Count;
                Hashtable objHsTable = new Hashtable();
                //for (int intI = 0; intI < intLen;intI++)
                foreach (clsHospOrderCS_Vo order in m_glsMianHospOrder)
                {
                    try
                    {
                        objHsTable.Add(order.m_strRegisterID + order.m_strOrderID + order.m_strChargeItemID + order.m_dtmCreateDate.ToString(), "");
                    }
                    catch
                    {
                        continue;
                    }
                    strSQL = @"insert into hosp_inhosporder
                                        (doctcode,inhosseqno, doctname, depcode, depname, groupno, itemcode,
                                         itemname, itemspec, itemprice, itemamout, itemunit, inputdt,
                                         startdt, type
                                        )
                                 values (" +
                                         " '" + order.m_strCreatorID + "'," +
                                         " '" + order.m_strRegisterID + "'," +
                                         " '" + order.m_strCreateDoctor + "'," +
                                         " '" + order.m_strCreateDeptID + "'," +
                                         " '" + order.m_strCreateDept + "'," +
                                         " '" + order.m_strOrderID + "'," +
                                         " '" + order.m_strChargeItemID + "'," +
                                         " '" + order.m_strChargeItemName + "'," +
                                         " '" + order.m_strSpec + "'," +
                                         " '" + order.m_dclPrice + "'," +
                                         " '" + order.m_dclAmount + "'," +
                                         " '" + order.m_strUnit + "'," +
                                         " to_date('" + order.m_dtmCreateDate.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')," +
                                         " to_date('" + order.m_dtmStartDT.ToString("yyyy-MM-dd HH:mm:ss") + "','yyyy-mm-dd hh24:mi:ss')," +
                                         " '" + order.m_intOrderStauts.ToString() + "'" +
                                         ")";

                    m_glsSQL.Add(strSQL);
                }
                lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("病人医嘱整理完成.  一共" + m_glsMianHospOrder.Count.ToString() + "条数据. ");
                lsvItem.ForeColor = System.Drawing.Color.DarkRed;
                m_lsvMain.Items.Insert(0, lsvItem);
                p_lsvInfor.Refresh();
            }

            //睡一会....
            System.Threading.Thread.Sleep(1000);

            p_lblInfor.Text = "整理完成,正在更新数据库,请稍后.....";
            lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            lsvItem.SubItems.Add("整理完成,更新数据.");
            lsvItem.ForeColor = System.Drawing.Color.DarkRed;
            m_lsvMain.Items.Insert(0, lsvItem);
            p_lblInfor.Refresh();
            p_lsvInfor.Refresh();
            #endregion

            //更新数据
            clsUploadData objUpLoad = new clsUploadData();
            lngRes = objUpLoad.m_lngUploadData(m_glsSQL);
            objUpLoad = null;
            if (lngRes > 0)
            {
                p_lblInfor.Text = "上传完成!";
                p_lblInfor.ForeColor = System.Drawing.Color.DarkBlue;
                lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("更新完成!");
                lsvItem.ForeColor = System.Drawing.Color.DarkBlue;
                m_lsvMain.Items.Insert(0, lsvItem);
                p_lblInfor.Refresh();
                p_lsvInfor.Refresh();
            }
            else
            {
                p_lblInfor.Text = "上传失败!";
                p_lblInfor.ForeColor = System.Drawing.Color.DarkRed;
                lsvItem = new ListViewItem(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                lsvItem.SubItems.Add("上传失败!");
                lsvItem.ForeColor = System.Drawing.Color.DarkRed;
                m_lsvMain.Items.Insert(0, lsvItem);
                p_lblInfor.Refresh();
                p_lsvInfor.Refresh();
            }
            return lngRes;
        }

        public long m_lngUpload(DateTime p_dtmDate, Label p_lblInfor)
        {
            List<string> m_glsOutRegID = null;
            p_lblInfor.Text = "正在整理病人信息，请稍候....";
            p_lblInfor.Refresh();

            clsCommunityInterface_Svc objSvc = (clsCommunityInterface_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(clsCommunityInterface_Svc));
            long lngRes = objSvc.m_lngGetPatientCount(p_dtmDate.ToString("yyyy-MM-dd"), out m_glsOutRegID);
            if (lngRes > 0 && m_glsOutRegID != null && m_glsOutRegID.Count > 0)
            { 
                List<clsHospBillCS_Vo> m_glsMianHospBill = new List<clsHospBillCS_Vo>(m_glsOutRegID.Count);
                List<clsHospOrderCS_Vo> m_glsMianHospOrder = new List<clsHospOrderCS_Vo>();
                List<clsHospRecordCS_Vo> m_glsMianhospRecord = new List<clsHospRecordCS_Vo>();

                List<clsHospBillCS_Vo> m_glsSubHospBill = null;
                List<clsHospOrderCS_Vo> m_glsSubHospOrder = null;
                clsHospRecordCS_Vo m_objhospRecord = null;

                for (int i = 0; i < m_glsOutRegID.Count; i++)
                {
                    p_lblInfor.Text = "正在整理第" + Convert.ToString(i + 1) + "个病人的信息，一共" + m_glsOutRegID.Count.ToString() + "个病人...";
                    p_lblInfor.Refresh();

                    m_glsSubHospBill = null;
                    m_glsSubHospOrder = null;
                    m_objhospRecord = null;

                    lngRes = objSvc.m_lngGetOutPatientInfor(m_glsOutRegID[i].Trim(), out m_objhospRecord, out m_glsSubHospBill, out m_glsSubHospOrder);

                    if (lngRes > 0)
                    {
                        if (m_objhospRecord != null)
                        {
                            m_glsMianhospRecord.Add(m_objhospRecord);
                        }
                        if (m_glsSubHospOrder != null && m_glsSubHospOrder.Count > 0)
                        {
                            m_glsMianHospOrder.AddRange(m_glsSubHospOrder);
                        }
                        if (m_glsSubHospBill != null && m_glsSubHospBill.Count > 0)
                        {
                            m_glsMianHospBill.AddRange(m_glsSubHospBill);
                        }
                    }
                }
                com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc objUpLoad = (com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc)clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.DataCollection.clsDataUpload_Svc));

                p_lblInfor.Text = "正在上传数据，请稍候....";
                p_lblInfor.Refresh();

                lngRes = objUpLoad.m_lngUpLoadZyData(m_glsMianhospRecord, m_glsMianHospOrder, m_glsMianHospBill);
                if (lngRes > 0)
                {
                    p_lblInfor.Text = "住院数据上传完成！";
                    p_lblInfor.Refresh();
                }
                else
                {
                    p_lblInfor.Text = "住院数据上传失败，请重新操作。";
                    p_lblInfor.Refresh();
                }

                objUpLoad.Dispose();
                objUpLoad = null;
            }
            else
            {
                p_lblInfor.Text = "没有住院数据需要上传。";
                p_lblInfor.Refresh();
            }

            objSvc.Dispose();
            objSvc = null;
            return lngRes;
        }
    }
}
