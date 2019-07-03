using System;
using System.Windows.Forms;
using com.digitalwave.iCare.ValueObject;
using com.digitalwave.iCare.gui.Security;
using System.Xml;
using System.IO;
using System.Data;
using System.Text.RegularExpressions;
using com.digitalwave.iCare.middletier.HI;
using System.Collections.Generic;

namespace com.digitalwave.iCare.gui.HIS
{
    /// <summary>
    /// clsControlRegister 的摘要说明。
    /// </summary>
    public class clsControlRegister : com.digitalwave.GUI_Base.clsController_Base
    {
        public clsControlRegister()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            clsDomain = new clsDomainControl_Register();
            clsDomain.m_mthGetRegisterSetting("1201", out m_intShowEmpName);
            clsRegister = new clsPatientRegister_VO();
            m_objPrintRegister = new clsPrintRegister();
            clsController_Security clsSe = new clsController_Security();
            OperatorID = clsSe.objGetCurrentLoginEmployee().strEmpID;
            m_objChargeCal = new clsCalcPatientCharge(string.Empty, string.Empty, 0, this.m_objComInfo.m_strGetHospitalTitle(), 0, 0);
        }
        /// <summary>
        /// 是否显示挂号员姓名 ，0-不显示；1-显示
        /// </summary>。
        int m_intShowEmpName = 0;
        clsPrintRegister m_objPrintRegister;
        clsDomainControl_Register clsDomain;
        public clsPatientRegister_VO clsRegister;
        string OperatorID;
        private enum enumlvwSel : byte
        {
            PatType = 1,
            Dept = 2,
            RegType = 3,
            Doc = 4
        }
        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmRegister m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmRegister)frmMDI_Child_Base_in;
        }
        #endregion

        #region 清空窗体数据
        public void m_Clear(object objSend)
        {
            m_objViewer.intAeg.Text = "";
            m_objViewer.m_txtCardID.Clear();
            m_objViewer.m_txtCardID.Enabled = false;
            m_objViewer.label21.Text = "普通";
            m_objViewer.m_txtDoc.Enabled = true;
            m_objViewer.m_lblRecount.Text = "";
            m_objViewer.m_txtAge.Clear();
            m_objViewer.intAeg.Visible = false;
            m_objViewer.m_txtDiagFee.Text = "0";
            clsRegister = new clsPatientRegister_VO();
            clsRegister.m_objDiagDept = new clsDepartmentVO();
            clsRegister.m_objDiagDoctor = new clsEmployeeVO();
            clsRegister.m_strPayType = new clsPatientType_VO();
            clsRegister.m_strRegisterType = new clsRegisterType_VO();
            clsRegister.m_objPatientCard = new clsPatientCard_VO();
            clsRegister.m_objRegisterEmp = new clsEmployeeVO();
            clsRegister.m_objRegisterEmp.strEmpID = this.OperatorID;
            this.m_objViewer.m_txtChangeCharge.Text = "0";
            this.m_objViewer.m_txtChangeDisCount.Text = "0";
            m_objViewer.m_lsvRegDetail.Items.Clear();
            this.m_objViewer.m_paytypename.SelectedIndex = 0;
            this.m_objViewer.m_lblOptimes.Text = "";
            m_objViewer.m_txtRegFee.Text = "0";
            m_objViewer.m_txtAmount.Clear();
            m_objViewer.m_cboSex.SelectedIndex = -1;
            m_objViewer.m_cboSex.Text = "";
            m_objViewer.m_dtpBirth.Value = DateTime.Now.Date;
            m_objViewer.m_dtpPreTime.Value = m_ServDate();
            m_objViewer.m_cboSeg.SelectedIndex = this.m_GetSerPerio();
            m_objViewer.m_lbEnd.Text = "";
            m_objViewer.m_lbRoom.Text = "";
            m_objViewer.m_lbStart.Text = "";
            m_objViewer.m_txtAmount.Clear();
            m_objViewer.m_txtCard.Clear();
            m_objViewer.m_txtDept.Clear();
            m_objViewer.m_txtDiagFee.Text = "";
            m_objViewer.m_txtDoc.Clear();
            m_objViewer.m_txtName.Clear();
            m_objViewer.m_txtPatType.Clear();
            m_objViewer.m_txtRegFee.Text = "";
            m_objViewer.m_txtRegType.Clear();
            try
            {

                m_lngReadXML();

            }
            catch
            {
            }
            m_objViewer.m_txtCard.Focus();
            m_objViewer.m_btnSave.Text = "挂号确认 F2";
        }
        #endregion
        //当前服务器日期
        /// <summary>
        /// 当前服务器日期
        /// </summary>
        /// <returns></returns>
        public DateTime m_ServDate()
        {
            DateTime DTP;
            DTP = DateTime.Now;
            return DTP;
        }

        #region 取得当前服务器时间段
        /// <summary>
        /// 取得当前服务器时间段
        /// </summary>
        /// <returns></returns>
        public int m_GetSerPerio()
        {
            int intPerio = 0;
            //int sevTime=clsDomain.m_GetServTime().Hour;
            int sevTime = DateTime.Now.Hour;
            if (sevTime >= 12 && sevTime < 18)
                intPerio = 1; //下午
            else
            {
                if (sevTime >= 18)
                    intPerio = 2; //晚上
                else
                    intPerio = 0; //上午
            }
            return intPerio;
        }
        #endregion

        #region 填充各ComboBox
        /// <summary>
        /// 填充各ComboBox
        /// </summary>
        public void m_FillComboBox()
        {

            //时间段
            m_objViewer.m_cboSeg.Items.Clear();
            m_objViewer.m_cboSeg.Items.Add("上午");
            m_objViewer.m_cboSeg.Items.Add("下午");
            m_objViewer.m_cboSeg.Items.Add("晚上");

            //性别
            m_objViewer.m_cboSex.Items.Clear();
            m_objViewer.m_cboSex.Items.Add("男");
            m_objViewer.m_cboSex.Items.Add("女");
            m_objViewer.m_cboSex.Items.Add("不详");
        }
        #endregion

        #region 检查是否有当前时段的排班
        public void m_CheckPlan()
        {
            //			bool isExits=false;
            //			isExits=clsDomain.m_bnlCheckPlanByDatePerio(m_objViewer.m_dtpPreTime.Value.ToShortDateString(),m_objViewer.m_cboSeg.Text);
            //			if(!isExits)
            //			{
            //				MessageBox.Show(m_objViewer,m_objViewer.m_cboSeg.Text + " 没有排班记录，请到相应模块维护！","提示");
            //			}

        }
        #endregion

        #region 填充lvwItem
        public void m_GetlvwItem(ListView objlsv)
        {
            m_objViewer.Cursor = Cursors.WaitCursor;
            objlsv.Tag = m_objViewer.ActiveControl.Name;
            switch (m_objViewer.ActiveControl.Name)
            {
                case "m_txtPatType":
                    this.FillPatType();
                    //m_objViewer.m_lsvAllpay.SelectedItems[0].EnsureVisible();
                    break;
                case "m_txtRegType":
                    this.FillRegType();
                    //m_objViewer.m_lsvAllpay.SelectedItems[0].EnsureVisible();
                    break;
                case "m_txtDept":
                    this.FillDept();
                    break;
                case "m_txtDoc":
                    this.FillDoc();
                    break;
            }
            if (objlsv.Items.Count > 0)
                objlsv.Items[0].Selected = true;
            m_objViewer.Cursor = Cursors.Default;
        }
        public clsPatientType_VO[] m_clsPayTypeVO = null;
        private void FillPatType()
        {
            if (m_objViewer.m_lsvAllpay.Columns.Count > 0) return;
            clsPatientType_VO[] objResultArr = m_clsPayTypeVO;
            m_objViewer.m_lsvAllpay.Columns.Clear();
            m_objViewer.m_lsvAllpay.Columns.Add("", 40, HorizontalAlignment.Center);
            m_objViewer.m_lsvAllpay.Columns.Add("病人类型", 160, HorizontalAlignment.Left);
            m_objViewer.m_lsvAllpay.Items.Clear();
            long lngRes = 0;
            if (objResultArr == null)
            {
                lngRes = clsDomain.m_lngGetPatType(out objResultArr);
                this.m_clsPayTypeVO = objResultArr;
            }
            else
            {
                lngRes = 1;
            }
            if ((lngRes > 0) && (objResultArr != null))
            {
                if (objResultArr.Length > 0)
                {
                    ListViewItem lvw = null;
                    for (int i1 = 0; i1 < objResultArr.Length; i1++)
                    {
                        lvw = new ListViewItem(objResultArr[i1].m_strPayTypeNo);
                        lvw.SubItems.Add(objResultArr[i1].m_strPayTypeName);
                        lvw.Tag = objResultArr[i1];
                        m_objViewer.m_lsvAllpay.Items.Add(lvw);
                    }
                }
            }
        }
        public clsRegisterType_VO[] m_clsRegisterTypeVo = null;
        private void FillRegType()
        {
            if (m_objViewer.m_lsvAllregtype.Columns.Count > 0) return;
            clsRegisterType_VO[] objResultArr = m_clsRegisterTypeVo;

            m_objViewer.m_lsvAllregtype.Columns.Clear();
            //m_objViewer.m_lsvAllregtype.Columns.Add("",0,HorizontalAlignment.Center);
            m_objViewer.m_lsvAllregtype.Columns.Add("", 60, HorizontalAlignment.Left);
            m_objViewer.m_lsvAllregtype.Columns.Add("挂号类型", 100, HorizontalAlignment.Left);
            //			objlsv.Columns.Add("挂号费",60,HorizontalAlignment.Center);
            //			objlsv.Columns.Add("诊金",60,HorizontalAlignment.Center);
            m_objViewer.m_lsvAllregtype.ResumeLayout(false);
            m_objViewer.m_lsvAllregtype.Items.Clear();
            long lngRes = 0;
            if (objResultArr == null)
            {
                lngRes = clsDomain.m_lngGetRegType(out objResultArr);
                this.m_clsRegisterTypeVo = objResultArr;
            }
            else
            {
                lngRes = 1;
            }
            if ((lngRes > 0) && (objResultArr != null))
            {
                if (objResultArr.Length > 0)
                {
                    ListViewItem lvw = null;
                    for (int i1 = 0; i1 < objResultArr.Length; i1++)
                    {
                        lvw = new ListViewItem(objResultArr[i1].m_strRegisterTypeNo);

                        lvw.SubItems.Add(objResultArr[i1].m_strRegisterTypeName);
                        //						lvw.SubItems.Add(objResultArr[i1].m_decRegPay.ToString());
                        //						lvw.SubItems.Add(objResultArr[i1].m_decDiagPay.ToString());
                        lvw.Tag = objResultArr[i1];
                        m_objViewer.m_lsvAllregtype.Items.Add(lvw);
                    }
                }
            }
        }
        public clsDepartmentVO[] m_clsDepartmentVo = null;
        private void FillDept()
        {
            long lngRes = 0;
            //if (m_objViewer.m_lsvAlldept.Columns.Count > 0)
            //{
            //    if (m_clsDepartmentVo != null)
            //    {
            //        for (int i1 = 0; i1 < m_clsDepartmentVo.Length; i1++)
            //        {
            //            if (m_clsDepartmentVo[i1].strDeptID == string.Empty)
            //            {
            //                lngRes = clsDomain.m_lngGetPlanDep(clsRegister.m_strRegisterDate, "", out m_clsDepartmentVo);
            //                break;
            //            }
            //        }
            //    }
            //    return;
            //}
            lngRes = clsDomain.m_lngGetPlanDep(clsRegister.m_strRegisterDate, "", out m_clsDepartmentVo);
            m_objViewer.m_lsvAlldept.Columns.Clear();
            m_objViewer.m_lsvAlldept.Columns.Add("", 60, HorizontalAlignment.Left);
            m_objViewer.m_lsvAlldept.Columns.Add("科室名称", 150, HorizontalAlignment.Left);
            m_objViewer.m_lsvAlldept.Columns.Add("拼音码", 70, HorizontalAlignment.Left);
            m_objViewer.m_lsvAlldept.ResumeLayout(false);
            m_objViewer.m_lsvAlldept.Items.Clear();

            if (m_clsDepartmentVo == null)
            {
                lngRes = clsDomain.m_lngGetPlanDep(clsRegister.m_strRegisterDate, "", out m_clsDepartmentVo);
            }
            else
            {
                lngRes = 1;
            }
            if ((lngRes > 0) && (m_clsDepartmentVo != null))
            {
                if (m_clsDepartmentVo.Length > 0)
                {
                    ListViewItem lvw = null;
                    for (int i1 = 0; i1 < m_clsDepartmentVo.Length; i1++)
                    {
                        lvw = new ListViewItem(m_clsDepartmentVo[i1].strShortNo);
                        lvw.SubItems.Add(m_clsDepartmentVo[i1].strDeptName);
                        lvw.SubItems.Add(m_clsDepartmentVo[i1].strPYCode);
                        lvw.SubItems.Add(m_clsDepartmentVo[i1].strAddress);
                        lvw.Tag = m_clsDepartmentVo[i1];
                        m_objViewer.m_lsvAlldept.Items.Add(lvw);
                    }
                }
            }
        }
        public clsEmployeeVO[] m_clsEmployeeVo = null;
        private void FillDoc()
        {
            m_objViewer.m_lsvAlldoc.Columns.Clear();
            m_objViewer.m_lsvAlldoc.Columns.Add("", 40, HorizontalAlignment.Center);
            m_objViewer.m_lsvAlldoc.Columns.Add("医生姓名", 100, HorizontalAlignment.Center);
            m_objViewer.m_lsvAlldoc.Columns.Add("拼音码", 70, HorizontalAlignment.Center);
            m_objViewer.m_lsvAlldoc.ResumeLayout(false);
            m_objViewer.m_lsvAlldoc.Items.Clear();
            string strDate = clsMain.IsNullToString(clsRegister.m_strRegisterDate, null);
            string strDeptID = clsRegister.m_objDiagDept.strDeptID;
            string strRegType = clsRegister.m_strRegisterType.m_strRegisterTypeID;
            long lngRes = 0;
            if (strDeptID == "")
                strDeptID = null;
            lngRes = clsDomain.m_lngGetOPDoctorList(strDeptID, out m_clsEmployeeVo);


            if ((lngRes > 0) && (m_clsEmployeeVo != null))
            {
                if (m_clsEmployeeVo.Length > 0)
                {
                    ListViewItem lvw = null;
                    for (int i1 = 0; i1 < m_clsEmployeeVo.Length; i1++)
                    {
                        lvw = new ListViewItem(m_clsEmployeeVo[i1].strEmpNO);
                        lvw.SubItems.Add(m_clsEmployeeVo[i1].strName);
                        lvw.SubItems.Add(m_clsEmployeeVo[i1].strPYCode);
                        lvw.Tag = m_clsEmployeeVo[i1];
                        m_objViewer.m_lsvAlldoc.Items.Add(lvw);
                        if (strDeptID != null)
                        {
                            if (m_clsEmployeeVo[i1].strDEPTID_CHR.Trim() == strDeptID.Trim())
                            {
                                m_objViewer.m_lsvAlldoc.Items[i1].BackColor = System.Drawing.Color.DarkOrange;
                            }
                        }

                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// 发票规则
        /// </summary>
        private string strInvoiceExpression = "";

        #region 读取当前发票号
        /// <summary>
        /// 读取当前发票号
        /// </summary>
        public void m_lngReadXML()
        {
            try
            {
                string patXML = Application.StartupPath + "\\LoginFile.xml";
                if (File.Exists(patXML))
                {
                    string strCurrEmpNO = "AnyOne";
                    XmlDocument doc = new XmlDocument();
                    doc.Load(patXML);
                    XmlNode xn = doc.DocumentElement.SelectNodes(@"//register")[0];
                    XmlNode xnCurr = xn.SelectSingleNode(@"//EmpNo[@key='" + strCurrEmpNO + @"']");
                    if (xnCurr != null)
                    {
                        this.m_objViewer.txtCheckNO.Text = clsMain.m_mthGetNewCheckNO(xnCurr.Attributes["value"].Value);
                    }
                    else
                    {
                        this.m_objViewer.txtCheckNO.Text = "0000001";
                    }
                    if (this.strInvoiceExpression.Trim() == "")
                    {
                        xn = doc.DocumentElement.SelectSingleNode("InvoiceExpression");
                        this.strInvoiceExpression = xn.InnerText;
                    }
                }

            }
            catch
            {
                this.m_objViewer.txtCheckNO.Text = "0000001";
            }

        }
        #endregion

        #region 判断发票号是否正确
        public bool m_mthInvoiceExpression()
        {
            Regex r = new Regex(this.strInvoiceExpression);
            Match m = r.Match(this.m_objViewer.txtCheckNO.Text.Trim());
            if (m.Success)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 修改发票号
        /// <summary>
        /// 修改发票号
        /// </summary>
        public void m_lngRepalceXML(string newNO)
        {
            string patXML = Application.StartupPath + "\\LoginFile.xml";
            if (File.Exists(patXML))
            {
                string strCurrEmpNO = "AnyOne";
                XmlDocument doc = new XmlDocument();
                doc.Load(patXML);
                XmlNode xn = doc.DocumentElement.SelectNodes(@"//register")[0];
                XmlNode xnCurr = xn.SelectSingleNode(@"//EmpNo[@key='" + strCurrEmpNO + @"']");
                if (xnCurr != null)
                {
                    xnCurr.Attributes["value"].Value = newNO;
                }
                //				else //用户数据不存在则新增
                //				{
                //					XmlElement xnNew = doc.CreateElement("EmpNo");
                //					xnNew.SetAttributeNode("key",null);
                //					xnNew.SetAttribute("key",strCurrEmpNO);
                //					xnNew.SetAttributeNode("value",null);
                //					xnNew.SetAttribute("value","0000000001");
                //					xn.AppendChild(xnNew);
                //				}

                doc.Save(patXML);
            }
        }
        #endregion

        #region 排班表vo填充liv
        /// <summary>
        ///排班表vo填充liv  
        /// </summary>
        public void m_FillDoctorPlan()
        {
            m_objViewer.m_lvItem.Clear();
            clsOPDoctorPlan_VO[] p_objResult = null;
            long lngRes = clsDomain.m_lngGetTodayPlan(out p_objResult);
            ListViewItem lviTemp = null;

            m_objViewer.m_lvItem.Columns.Add("排班记录ID", 0, HorizontalAlignment.Center);

            m_objViewer.m_lvItem.Columns.Add("科室ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("医生ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("记录员ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("坐诊类型ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("时间段", 60, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("科室名称", 120, HorizontalAlignment.Left);
            m_objViewer.m_lvItem.Columns.Add("医生姓名", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("坐诊类型", 70, HorizontalAlignment.Center);

            m_objViewer.m_lvItem.Columns.Add("限诊", 40, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("号数", 40, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("排班时间", 80, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("开诊时间", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("离诊时间", 70, HorizontalAlignment.Center);

            m_objViewer.m_lvItem.Columns.Add("记录员名称", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("记录时间", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("坐诊地点", 100, HorizontalAlignment.Center);
            for (int i = 0; i < p_objResult.Length; i++)
            {
                lviTemp = new ListViewItem(p_objResult[i].m_strOPDrPlanID);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDept.strDeptID);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDoctor.strEmpID);
                lviTemp.SubItems.Add(p_objResult[i].m_objRecordEmp.strEmpID);
                lviTemp.SubItems.Add(p_objResult[i].m_objRegisterType.m_strRegisterTypeID);
                lviTemp.SubItems.Add(p_objResult[i].m_strPlanPeriod);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDept.strDeptName);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDoctor.strLastName);
                lviTemp.SubItems.Add(p_objResult[i].m_objRegisterType.m_strRegisterTypeName);
                lviTemp.SubItems.Add(p_objResult[i].m_intMaxDiagTimes.ToString());
                if (p_objResult[i].m_strOPTIMES.ToString() == "")
                    p_objResult[i].m_strOPTIMES = "0";
                lviTemp.SubItems.Add(p_objResult[i].m_strOPTIMES.ToString());
                lviTemp.SubItems.Add(Convert.ToDateTime(p_objResult[i].m_strPlanDate).ToShortDateString());
                lviTemp.SubItems.Add(p_objResult[i].m_strStartTime);
                lviTemp.SubItems.Add(p_objResult[i].m_strEndTime);
                lviTemp.SubItems.Add(p_objResult[i].m_objRecordEmp.strLastName);
                lviTemp.SubItems.Add(p_objResult[i].m_objRecordDate);
                lviTemp.SubItems.Add(p_objResult[i].m_strOPAddress);
                lviTemp.Tag = (object)p_objResult[i];
                this.m_objViewer.m_lvItem.Items.Add(lviTemp);
                switch (p_objResult[i].m_strPlanPeriod.Trim())
                {
                    case "上午":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.LightSeaGreen;
                        break;
                    case "下午":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.Tan;
                        break;
                    case "晚上":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.Orange;
                        break;
                    case "全天":
                        //						this.m_objViewer.m_lvItem.Items[i].BackColor=System.Drawing.Color.LightCoral;
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.LightSalmon;
                        break;
                }
            }
        }

        public void m_FillDoctorPlanByDate()
        {
            m_objViewer.m_lvItem.Clear();
            string strDate = this.m_objViewer.m_dtpPreTime.Value.ToString("yyyy-MM-dd");
            clsOPDoctorPlan_VO[] p_objResult = null;
            long lngRes = clsDomain.m_lngGetTodayPlanByDate(strDate, out p_objResult);
            ListViewItem lviTemp = null;

            m_objViewer.m_lvItem.Columns.Add("排班记录ID", 0, HorizontalAlignment.Center);

            m_objViewer.m_lvItem.Columns.Add("科室ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("医生ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("记录员ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("坐诊类型ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("时间段", 60, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("科室名称", 120, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("医生姓名", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("坐诊类型", 70, HorizontalAlignment.Center);

            m_objViewer.m_lvItem.Columns.Add("限诊", 50, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("号数", 50, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("排班时间", 120, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("开诊时间", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("离诊时间", 70, HorizontalAlignment.Center);

            m_objViewer.m_lvItem.Columns.Add("记录员名称", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("记录时间", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("坐诊地点", 100, HorizontalAlignment.Center);
            for (int i = 0; i < p_objResult.Length; i++)
            {
                lviTemp = new ListViewItem(p_objResult[i].m_strOPDrPlanID);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDept.strDeptID);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDoctor.strEmpID);
                lviTemp.SubItems.Add(p_objResult[i].m_objRecordEmp.strEmpID);
                lviTemp.SubItems.Add(p_objResult[i].m_objRegisterType.m_strRegisterTypeID);
                lviTemp.SubItems.Add(p_objResult[i].m_strPlanPeriod);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDept.strDeptName);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDoctor.strLastName);
                lviTemp.SubItems.Add(p_objResult[i].m_objRegisterType.m_strRegisterTypeName);
                lviTemp.SubItems.Add(p_objResult[i].m_intMaxDiagTimes.ToString());
                if (p_objResult[i].m_strOPTIMES.ToString() == "")
                    p_objResult[i].m_strOPTIMES = "0";
                lviTemp.SubItems.Add(p_objResult[i].m_strOPTIMES.ToString());
                lviTemp.SubItems.Add(Convert.ToDateTime(p_objResult[i].m_strPlanDate).ToShortDateString());
                lviTemp.SubItems.Add(p_objResult[i].m_strStartTime);
                lviTemp.SubItems.Add(p_objResult[i].m_strEndTime);
                lviTemp.SubItems.Add(p_objResult[i].m_objRecordEmp.strLastName);
                lviTemp.SubItems.Add(p_objResult[i].m_objRecordDate);
                lviTemp.SubItems.Add(p_objResult[i].m_strOPAddress);
                lviTemp.Tag = (object)p_objResult[i];
                this.m_objViewer.m_lvItem.Items.Add(lviTemp);
                switch (p_objResult[i].m_strPlanPeriod.Trim())
                {
                    case "上午":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.LightSeaGreen;
                        break;
                    case "下午":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.Tan;
                        break;
                    case "晚上":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.Orange;
                        break;
                    case "全天":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.LightSalmon;
                        break;
                }
            }
        }

        public void m_FillDoctorPlanDate()
        {
            if (!this.m_objViewer.m_chkPre.Checked) return;
            m_objViewer.m_lvItem.Clear();
            clsOPDoctorPlan_VO[] p_objResult = null;
            long lngRes = clsDomain.m_lngGetSomedayPlan(this.m_objViewer.m_dtpPreTime.Value, out p_objResult);
            ListViewItem lviTemp = null;

            m_objViewer.m_lvItem.Columns.Add("排班记录ID", 0, HorizontalAlignment.Center);

            m_objViewer.m_lvItem.Columns.Add("科室ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("医生ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("记录员ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("坐诊类型ID", 0, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("时间段", 60, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("科室名称", 120, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("医生姓名", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("坐诊类型", 70, HorizontalAlignment.Center);

            m_objViewer.m_lvItem.Columns.Add("限诊次数", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("挂号次数", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("排班时间", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("开诊时间", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("离诊时间", 70, HorizontalAlignment.Center);

            m_objViewer.m_lvItem.Columns.Add("记录员名称", 100, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("记录时间", 70, HorizontalAlignment.Center);
            m_objViewer.m_lvItem.Columns.Add("坐诊地点", 100, HorizontalAlignment.Center);
            for (int i = 0; i < p_objResult.Length; i++)
            {
                lviTemp = new ListViewItem(p_objResult[i].m_strOPDrPlanID);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDept.strDeptID);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDoctor.strEmpID);
                lviTemp.SubItems.Add(p_objResult[i].m_objRecordEmp.strEmpID);
                lviTemp.SubItems.Add(p_objResult[i].m_objRegisterType.m_strRegisterTypeID);
                lviTemp.SubItems.Add(p_objResult[i].m_strPlanPeriod);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDept.strDeptName);
                lviTemp.SubItems.Add(p_objResult[i].m_objOPDoctor.strLastName);
                lviTemp.SubItems.Add(p_objResult[i].m_objRegisterType.m_strRegisterTypeName);
                lviTemp.SubItems.Add(p_objResult[i].m_intMaxDiagTimes.ToString());
                lviTemp.SubItems.Add(p_objResult[i].m_strOPTIMES.ToString());
                lviTemp.SubItems.Add(Convert.ToDateTime(p_objResult[i].m_strPlanDate).ToShortDateString());
                lviTemp.SubItems.Add(p_objResult[i].m_strStartTime);
                lviTemp.SubItems.Add(p_objResult[i].m_strEndTime);
                lviTemp.SubItems.Add(p_objResult[i].m_objRecordEmp.strLastName);
                lviTemp.SubItems.Add(p_objResult[i].m_objRecordDate);
                lviTemp.SubItems.Add(p_objResult[i].m_strOPAddress);
                lviTemp.Tag = (object)p_objResult[i];
                this.m_objViewer.m_lvItem.Items.Add(lviTemp);
                switch (p_objResult[i].m_strPlanPeriod.Trim())
                {
                    case "上午":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.LightSeaGreen;
                        break;
                    case "下午":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.Tan;
                        break;
                    case "晚上":
                        this.m_objViewer.m_lvItem.Items[i].BackColor = System.Drawing.Color.Orange;
                        break;
                }
            }

        }
        #endregion

        #region 选择排班
        public void m_SelectPlan()
        {
            m_objViewer.m_lsvAllregtype.Clear();
            m_objViewer.m_lsvAlldept.Clear();
            m_clsRegisterTypeVo = null;
            m_clsDepartmentVo = null;
            if (m_objViewer.m_lvItem.Items.Count == 0 || m_objViewer.m_lvItem.SelectedItems.Count == 0)
                return;
            for (int i = 0; i < m_objViewer.m_lvItem.Items.Count; i++)
            {
                if (m_objViewer.m_lvItem.Items[i].Selected)
                {
                    try
                    {
                        if ((int.Parse(m_objViewer.m_lvItem.Items[i].SubItems[10].Text) >= int.Parse(m_objViewer.m_lvItem.Items[i].SubItems[9].Text)) && m_objViewer.m_lvItem.Items[i].SubItems[9].Text.Trim() != "0")
                        {
                            if (MessageBox.Show("该医生已达到限号，继续挂号吗？", "", MessageBoxButtons.YesNo) == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                    catch { }

                    this.m_objViewer.m_cboSeg.Text = m_objViewer.m_lvItem.Items[i].SubItems[5].Text;
                    int seg = this.m_GetSerPerio();
                    if (seg > this.m_objViewer.m_cboSeg.SelectedIndex)
                    {
                        if (MessageBox.Show("该时间段已过，是否要选择该排班！", "提示", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            this.m_objViewer.m_cboSeg.SelectedIndex = seg;
                            return;
                        }
                    }
                    clsRegister.m_strRegisterType.m_strRegisterTypeID = m_objViewer.m_lvItem.Items[i].SubItems[4].Text;
                    this.m_objViewer.m_txtRegType.Tag = m_objViewer.m_lvItem.Items[i].SubItems[4].Text;
                    clsRegister.m_strRegisterType.m_strRegisterTypeName = this.m_objViewer.m_txtRegType.Text = m_objViewer.m_lvItem.Items[i].SubItems[8].Text;

                    clsRegister.m_objDiagDept.strDeptID = m_objViewer.m_lvItem.Items[i].SubItems[1].Text;
                    this.m_objViewer.m_txtDept.Tag = m_objViewer.m_lvItem.Items[i].SubItems[1].Text;
                    clsRegister.m_objDiagDept.strDeptName = this.m_objViewer.m_txtDept.Text = m_objViewer.m_lvItem.Items[i].SubItems[6].Text;

                    if (((clsOPDoctorPlan_VO)this.m_objViewer.m_lvItem.Items[i].Tag).m_objRegisterType.m_decRegPay == 1)
                    {
                        this.m_objViewer.m_txtDoc.Enabled = false;
                        clsRegister.m_objDiagDoctor.strEmpID = null;
                        this.m_objViewer.m_txtDoc.Tag = null;
                        clsRegister.m_objDiagDoctor.strFirstName = null;
                        this.m_objViewer.m_txtDoc.Text = "";
                    }
                    else
                    {
                        this.m_objViewer.m_txtDoc.Enabled = true;
                        clsRegister.m_objDiagDoctor.strEmpID = m_objViewer.m_lvItem.Items[i].SubItems[2].Text;
                        this.m_objViewer.m_txtDoc.Tag = m_objViewer.m_lvItem.Items[i].SubItems[2].Text;
                        clsRegister.m_objDiagDoctor.strFirstName = clsRegister.m_objDiagDoctor.strLastName = this.m_objViewer.m_txtDoc.Text = m_objViewer.m_lvItem.Items[i].SubItems[7].Text;
                    }

                    this.m_objViewer.m_lbStart.Text = m_objViewer.m_lvItem.Items[i].SubItems[12].Text;
                    this.m_objViewer.m_lbEnd.Text = m_objViewer.m_lvItem.Items[i].SubItems[13].Text;
                }
            }
            m_GetCurPay();
            this.m_objViewer.m_txtAmount.Focus();
        }
        #endregion

        #region 点击lvwItem触发的事件
        /// <summary>
        /// 点击lvwItem触发的事件
        /// </summary>
        /// <param name="objlsv"></param>
        public void m_lvwItemClick(ListView objlsv)
        {
            if (objlsv.Items.Count == 0 || objlsv.SelectedItems.Count == 0)
            {
                return;
            }
            if (objlsv.SelectedItems[0].Tag == null)
                return;
            switch (objlsv.Tag.ToString())
            {
                case "m_txtPatType":
                    clsRegister.m_strPayType = (clsPatientType_VO)objlsv.SelectedItems[0].Tag;
                    this.m_objViewer.m_txtPatType.Tag = clsRegister.m_strPayType.m_strPayTypeID;
                    m_objViewer.m_txtPatType.Text = clsRegister.m_strPayType.m_strPayTypeName;
                    if (clsMain.IsNullToString(clsRegister.m_strRegisterType.m_strRegisterTypeID, null) != "")
                    {
                        m_GetCurPay();
                    }
                    if (objPatientvo == null) objPatientvo = new clsPatient_VO();
                    if (clsRegister.m_strPayType.m_strPayTypeID != null || clsRegister.m_strPayType.m_strPayTypeID != "")
                    {
                        int intFlag;
                        clsDomain.m_lngGetPatTypeFLAG(clsRegister.m_strPayType.m_strPayTypeID, out intFlag);
                        switch (intFlag)
                        {
                            case 0:
                                this.m_objViewer.label21.Text = "普通";
                                this.m_objViewer.m_txtCardID.Enabled = false;
                                this.m_objViewer.m_txtCardID.Tag = 0;
                                this.m_objViewer.m_txtAge.Focus();
                                break;
                            case 1:
                                this.m_objViewer.label21.Text = "公费号";
                                this.m_objViewer.m_txtCardID.Enabled = true;
                                this.m_objViewer.m_txtCardID.Tag = 1;
                                this.m_objViewer.m_txtCardID.Focus();
                                break;
                            case 2:
                                this.m_objViewer.label21.Text = "医保号";
                                this.m_objViewer.m_txtCardID.Enabled = true;
                                this.m_objViewer.m_txtCardID.Tag = 2;
                                this.m_objViewer.m_txtCardID.Focus();
                                break;
                            case 3:
                                this.m_objViewer.label21.Text = "特困号";
                                this.m_objViewer.m_txtCardID.Enabled = true;
                                this.m_objViewer.m_txtCardID.Tag = 3;
                                this.m_objViewer.m_txtCardID.Focus();
                                break;
                            case 4:
                                this.m_objViewer.label21.Text = "离休号";
                                this.m_objViewer.m_txtCardID.Enabled = true;
                                this.m_objViewer.m_txtCardID.Tag = 4;
                                this.m_objViewer.m_txtCardID.Focus();
                                break;
                            case 5:
                                this.m_objViewer.label21.Text = "医疗证号";
                                this.m_objViewer.m_txtCardID.Enabled = true;
                                this.m_objViewer.m_txtCardID.Tag = 5;
                                this.m_objViewer.m_txtCardID.Focus();
                                break;
                        }
                    }
                    break;
                case "m_txtRegType":
                    clsRegister.m_strRegisterType = (clsRegisterType_VO)objlsv.SelectedItems[0].Tag;
                    this.m_objViewer.m_txtRegType.Tag = clsRegister.m_strRegisterType.m_strRegisterTypeID;
                    this.m_objViewer.m_txtRegType.Text = clsRegister.m_strRegisterType.m_strRegisterTypeName;

                    if (clsMain.IsNullToString(clsRegister.m_strPayType.m_strPayTypeID, null) != "")
                    {
                        m_GetCurPay();

                    }
                    if (clsRegister.m_strRegisterType.m_decRegPay == 1)
                    {
                        m_objViewer.m_txtDoc.Enabled = false;
                        clsRegister.m_objDiagDoctor = new clsEmployeeVO();
                        this.m_objViewer.m_txtDoc.Text = "";
                        this.m_objViewer.m_txtDoc.Tag = null;
                        m_objViewer.m_txtAmount.Focus();
                    }
                    else
                    {
                        m_objViewer.m_txtDoc.Enabled = true;
                        m_objViewer.m_txtDoc.Focus();
                    }
                    break;
                case "m_txtDept":
                    clsRegister.m_objDiagDept = (clsDepartmentVO)objlsv.SelectedItems[0].Tag;
                    m_objViewer.m_txtDept.Text = clsRegister.m_objDiagDept.strDeptName;
                    m_objViewer.m_lbRoom.Text = clsRegister.m_objDiagDept.strAddress;
                    this.m_objViewer.m_txtDept.Tag = clsRegister.m_objDiagDept.strDeptID;
                    m_objViewer.m_txtRegType.Focus();
                    break;
                case "m_txtDoc":
                    if (FilltxtByDoc(objlsv))
                        m_objViewer.m_btnSave.Focus();
                    break;
            }
        }
        private void CalFee()
        {
            m_objViewer.m_txtRegType.Text = clsRegister.m_strRegisterType.m_strRegisterTypeName;
            string RegTypeID = clsRegister.m_strRegisterType.m_strRegisterTypeID;
            string PatTypeID = clsRegister.m_strPayType.m_strPayTypeID;
            if (clsMain.IsNullToString(PatTypeID, null) == "" || clsMain.IsNullToString(RegTypeID, null) == "")
            {
                m_objViewer.m_txtRegFee.Text = "";
                m_objViewer.m_txtDiagFee.Text = "";
                m_objViewer.m_txtAmount.Clear();
                clsRegister.m_decRegisterPay = 0;
                clsRegister.m_decDiagPay = 0;
                return;
            }
            clsPatRegFee_VO clsVO;
            long lngRes = clsDomain.m_lngFindPatRegFeeByID(PatTypeID, RegTypeID, out clsVO);
            if (clsVO.m_strRegisterTypeID == null || clsVO.m_strRegisterTypeID == "")
            {
                m_objViewer.m_txtRegFee.Text = "";
                m_objViewer.m_txtDiagFee.Text = "";
                m_objViewer.m_txtAmount.Clear();
                clsRegister.m_decRegisterPay = 0;
                clsRegister.m_decDiagPay = 0;
                return;
            }
            else
            {
                m_objViewer.m_txtRegFee.Text = clsVO.m_decRegFee.ToString();
                m_objViewer.m_txtDiagFee.Text = clsVO.m_decDiagFee.ToString();
                clsRegister.m_decRegisterPay = clsVO.m_decRegFee;
                clsRegister.m_decDiagPay = clsVO.m_decDiagFee;
                m_objViewer.m_txtAmount.Text = Convert.ToString(clsVO.m_decRegFee + clsVO.m_decDiagFee);
            }
        }
        private bool FilltxtByDoc(ListView objlsv)
        {
            long lngRes = 0;
            if (objlsv.SelectedItems[0].Tag == null)
                return false;
            clsOPDoctorPlan_VO objResult = new clsOPDoctorPlan_VO();
            clsRegister.m_objDiagDoctor = (clsEmployeeVO)objlsv.SelectedItems[0].Tag;
            int lngLimitNo = clsRegister.m_objDiagDoctor.intStatus;
            if (lngLimitNo == 0)
            {
                if (MessageBox.Show("该医生已达到限号，继续挂号吗？", "", MessageBoxButtons.YesNo) == DialogResult.No)
                    return false;
            }

            m_objViewer.m_txtDoc.Text = clsRegister.m_objDiagDoctor.strName;


            if (clsMain.IsNullToString(clsRegister.m_objDiagDept.strDeptID, null) == "") //没有填充科室
            {
                clsRegister.m_objDiagDept.strDeptID = clsRegister.m_objDiagDoctor.strContactZip;//部门ID
                m_objViewer.m_txtDept.Text = clsRegister.m_objDiagDoctor.strContactRelation;//部门名称
                m_objViewer.m_lbRoom.Text = clsRegister.m_objDiagDoctor.strContactAddress;//部门地址
                int perio = this.m_GetSerPerio();
                switch (perio)
                {
                    case 0:
                        clsRegister.m_strPiod = "上午";
                        break;
                    case 1:
                        clsRegister.m_strPiod = "下午";
                        break;
                    case 2:
                        clsRegister.m_strPiod = "晚上";
                        break;
                }


            }

            if (this.m_objViewer.m_lsvRegDetail.Items.Count == 0)
            {
                this.m_GetCurPay();
            }

            return true;
        }
        #endregion

        #region 文本框改变时触发的事件
        /// <summary>
        /// 文本框改变时触发的事件
        /// </summary>
        public void m_txtChange()
        {
            if (m_objViewer.ActiveControl == null)
                return;

            if (m_objViewer.ActiveControl.Name == "m_txtRegFee" || m_objViewer.ActiveControl.Name == "m_txtDiagFee")
            {
                decimal decReg = decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtRegFee.Text, "0"));
                decimal decDiag = decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtDiagFee.Text, "0"));
                decimal decAmount = decReg + decDiag;
                clsRegister.m_decRegisterPay = decReg;
                clsRegister.m_decDiagPay = decDiag;
                if (decAmount != 0)
                    m_objViewer.m_txtAmount.Text = decAmount.ToString();
                else
                    m_objViewer.m_txtAmount.Clear();
                return;
            }

            switch (m_objViewer.ActiveControl.Name)
            {
                case "m_txtPatType":
                    if (m_objViewer.ActiveControl.Text == "")
                    {

                    }
                    else
                    {

                        this.m_FindLvw(m_objViewer.m_txtPatType.Text, this.m_objViewer.m_lsvAllpay);
                    }
                    break;
                case "m_txtRegType":
                    if (m_objViewer.ActiveControl.Text == "")
                    {

                    }
                    else
                    {
                        this.m_FindLvw(m_objViewer.m_txtRegType.Text, this.m_objViewer.m_lsvAllregtype);
                    }
                    break;
                case "m_txtDept":
                    if (m_objViewer.ActiveControl.Text != "")
                    {
                        this.m_FindLvw(m_objViewer.m_txtDept.Text, this.m_objViewer.m_lsvAlldept);
                    }
                    break;
                case "m_txtDoc":
                    if (m_objViewer.ActiveControl.Text == "")
                    {
                        clsRegister.m_objDiagDoctor.strEmpID = "";
                    }
                    else
                    {
                        string strValues = m_objViewer.m_txtDoc.Text;
                        ListView objlsv = this.m_objViewer.m_lsvAlldoc;
                        if (objlsv.Items.Count == 0)
                            return;
                        int i = 0;
                        if (clsMain.IsNumber(strValues))
                            i = clsMain.FindItemByValues(objlsv, 0, strValues);
                        else if (objlsv.Columns.Count > 2)
                            i = clsMain.FindItemByValues(objlsv, 2, strValues);
                        else
                            i = clsMain.FindItemByValues(objlsv, 1, strValues);
                        for (int i1 = 0; i1 < objlsv.Items.Count; i1++)
                        {
                            objlsv.Items[i1].Selected = false;
                        }
                        if (i >= 0)
                        {
                            objlsv.Items[i].Selected = true;
                            objlsv.Items[i].EnsureVisible();
                        }
                    }
                    break;
            }
        }
        #endregion

        #region 显示科室、挂号类别、医生
        public void m_ShowDept(object sender)
        {
            if (((TextBox)sender).Name == "m_txtPatType")
            {
                this.m_objViewer.m_pnlAllPlan.Left = ((TextBox)sender).Left + this.m_objViewer.groupBox1.Left;
                this.m_objViewer.m_pnlAllPlan.Top = this.m_objViewer.groupBox1.Top + ((TextBox)sender).Top + ((TextBox)sender).Height;
            }
            else
            {
                this.m_objViewer.m_pnlAllPlan.Left = ((TextBox)sender).Left + this.m_objViewer.groupBox2.Left;
                this.m_objViewer.m_pnlAllPlan.Top = this.m_objViewer.groupBox2.Top + ((TextBox)sender).Top + ((TextBox)sender).Height;
            }

            this.m_objViewer.m_pnlAllPlan.Visible = true;
            //this.m_objViewer.m_pnlAllPlan.BringToFront();
            this.m_objViewer.panel1.Controls.Add(this.m_objViewer.m_pnlAllPlan);
            this.m_objViewer.m_pnlAllPlan.Tag = ((TextBox)sender).Name;
            this.m_objViewer.m_pnlAllPlan.BringToFront();
        }
        #endregion

        #region 文本框得到焦点
        public void m_txtFocus(ListView objlsv)
        {
            try
            {
                switch (objlsv.Tag.ToString())
                {
                    case "m_txtPatType":
                        m_objViewer.m_txtPatType.Focus();
                        break;
                    case "m_txtRegType":
                        m_objViewer.m_txtRegType.Focus();
                        break;
                    case "m_txtDept":
                        m_objViewer.m_txtDept.Focus();
                        break;
                    case "m_txtDoc":
                        m_objViewer.m_txtDoc.Focus();
                        break;
                }
            }
            catch
            {
                m_objViewer.m_txtDoc.Focus();
            }
        }
        #endregion

        #region 查找Lvw中的值
        /// <summary>
        /// 查找Lvw中的值
        /// </summary>
        /// <param name="strValues"></param>
        /// <param name="objlsv"></param>
        public void m_FindLvw(string strValues, ListView objlsv)
        {

            if (objlsv.Items.Count == 0)
                return;
            int i = 0;
            if (clsMain.IsNumber(strValues))
                i = clsMain.FindItemByValues(objlsv, 0, strValues);
            else if (objlsv.Columns.Count > 2)
                i = clsMain.FindItemByValues(objlsv, 2, strValues);
            else
                i = clsMain.FindItemByValues(objlsv, 1, strValues);
            for (int i1 = 0; i1 < objlsv.Items.Count; i1++)
            {
                objlsv.Items[i1].Selected = false;
            }
            if (i > 0)
            {
                objlsv.Items[i].Selected = true;
                objlsv.Items[i].EnsureVisible();
            }
            else
                objlsv.Items[0].Selected = true;
        }
        #endregion

        #region 获取当前病人类型的挂号费用
        /// <summary>
        /// 获取当前病人类型的挂号费用
        /// </summary>

        public void m_GetCurPay()
        {
            this.m_objViewer.m_lsvRegDetail.Items.Clear();
            decimal mny = 0;

            bool blnNoReg = false;
            DateTime datBirthDate = Convert.ToDateTime(objPatientvo.strBirthDate);
            int intYear = datBirthDate.Year;
            int intMonth = datBirthDate.Month;
            int intDay = datBirthDate.Day;
            string[] strNoRegArr = clsPublic.m_strGetSysparm("0023").Split(';');
            string[] strFreePayType = clsPublic.m_strGetSysparm("0001").Split(';');
            List<string> lisFreePayType = new List<string>();
            for (int i = 0; i < strFreePayType.Length; i++)
            {
                lisFreePayType.Add(strFreePayType[i]);
            }

            if (objPatientvo.strSex == "男" && lisFreePayType.Contains(objPatientvo.objPatType.m_strPayTypeID))
            {
                if ((DateTime.Now.Year - intYear) > Convert.ToInt32(strNoRegArr[0]))
                {
                    blnNoReg = true;
                }
                else if ((DateTime.Now.Year - intYear) == Convert.ToInt32(strNoRegArr[0]))
                {
                    if ((DateTime.Now.Month - intMonth) > 0)
                    {
                        blnNoReg = true;
                    }
                    else if ((DateTime.Now.Month - intMonth) == 0)
                    {
                        if ((DateTime.Now.Day - intDay) >= 0)
                        {
                            blnNoReg = true;
                        }
                    }
                }
            }
            else if (objPatientvo.strSex == "女" && lisFreePayType.Contains(objPatientvo.objPatType.m_strPayTypeID))
            {
                if ((DateTime.Now.Year - intYear) > Convert.ToInt32(strNoRegArr[1]))
                {
                    blnNoReg = true;
                }
                else if ((DateTime.Now.Year - intYear) == Convert.ToInt32(strNoRegArr[1]))
                {
                    if ((DateTime.Now.Month - intMonth) > 0)
                    {
                        blnNoReg = true;
                    }
                    else if ((DateTime.Now.Month - intMonth) == 0)
                    {
                        if ((DateTime.Now.Day - intDay) >= 0)
                        {
                            blnNoReg = true;
                        }
                    }
                }
            }

            try
            {
                for (int i = 0; i < this.m_clsRegisterPayVO.Length; i++)
                {
                    if (this.m_clsRegisterPayVO[i].m_strPAYTYPEID_CHR.Trim() == this.m_objViewer.m_txtPatType.Tag.ToString().Trim()
                        && this.m_clsRegisterPayVO[i].m_strREGISTERTYPEID_CHR.Trim() == this.m_objViewer.m_txtRegType.Tag.ToString().Trim())
                    {
                        ListViewItem lvi = new ListViewItem();
                        lvi.Text = "0";
                        lvi.SubItems.Add(this.m_clsRegisterPayVO[i].m_strCHARGEID_CHR);
                        lvi.SubItems.Add(this.m_clsRegisterPayVO[i].m_strCHARGENAME_CHR);
                        if (this.m_clsRegisterPayVO[i].m_strCHARGEID_CHR.Trim() == "001" && blnNoReg == true)
                        {
                            lvi.SubItems.Add("0");
                        }
                        else
                        {
                            lvi.SubItems.Add(Convert.ToString(this.m_clsRegisterPayVO[i].m_dblPAYMENT_MNY));
                        }
                        float money = this.m_clsRegisterPayVO[i].m_fltDISCOUNT_DEC * 100;
                        string strRete = money.ToString().Trim() + "%";
                        lvi.SubItems.Add(strRete);
                        lvi.SubItems.Add(Convert.ToString(this.m_clsRegisterPayVO[i].m_strMEMO_VCHR));
                        lvi.Tag = this.m_clsRegisterPayVO[i];
                        this.m_objViewer.m_lsvRegDetail.Items.Add(lvi);
                        mny += decimal.Parse(this.m_clsRegisterPayVO[i].m_dblPAYMENT_MNY.ToString()) * decimal.Parse(this.m_clsRegisterPayVO[i].m_fltDISCOUNT_DEC.ToString());

                    }
                }
                m_MoveCardPay("m_chkNeedNotfalill");
                m_MoveCardPay("m_chkNeedNotCard");
            }
            catch
            {
            }
            m_objViewer.m_txtRegType.Text = clsRegister.m_strRegisterType.m_strRegisterTypeName;
            m_objViewer.m_txtRegFee.Text = mny.ToString();
            m_FigureUpPay();
        }
        /// <summary>
        /// 总计金额
        /// </summary>
        public void m_FigureUpPay()
        {
            Double mny = 0;

            for (int i = 0; i < this.m_objViewer.m_lsvRegDetail.Items.Count; i++)
            {
                Double Baibe = Convert.ToDouble(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
                mny += Convert.ToDouble(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text.Trim()) * Baibe;
            }
            m_objViewer.m_txtRegFee.Text = mny.ToString();
            m_Calculate();
        }
        /// <summary>
        /// 计算余额
        /// </summary>
        public void m_Calculate()
        {
            if (m_objViewer.m_txtAmount.Text.Trim() == "" || m_objViewer.m_txtRegFee.Text.Trim() == "")
            {
                m_objViewer.m_txtDiagFee.Text = "";
                return;
            }
            if (this.m_objViewer.m_txtAmount.Text.IndexOf(".") == 0)
            {
                this.m_objViewer.m_txtAmount.Text = "0.";
                this.m_objViewer.m_txtAmount.SelectionStart = this.m_objViewer.m_txtAmount.Text.Length;
            }
            m_objViewer.m_txtDiagFee.Text = Convert.ToString(decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtAmount.Text, "0")) - decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtRegFee.Text, "0")));
        }
        #endregion

        #region 获得病人VO
        /// <summary>
        ///获得病人VO 
        /// </summary>
        /// <returns></returns>
        public void m_lngNewPatient(out com.digitalwave.iCare.ValueObject.clsPatient_VO clsPatientvo)
        {
            clsPatientvo = new com.digitalwave.iCare.ValueObject.clsPatient_VO();
            clsPatientvo.strPatientCardID = this.m_objViewer.m_txtCard.Text;
            clsPatientvo.m_strBIRTH_DAT = clsPatientvo.strBirthDate = this.m_objViewer.m_dtpBirth.Value.ToShortDateString();
            clsPatientvo.m_strNAME_VCHR = this.m_objViewer.m_txtName.Text;
            clsPatientvo.m_strLASTNAME_VCHR = this.m_objViewer.m_txtName.Text;
            clsPatientvo.m_strSEX_CHR = this.m_objViewer.m_cboSex.Text;
            clsPatientvo.m_intERNALFLAG_INT = (int)this.m_objViewer.m_txtCardID.Tag;
            com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = new com.digitalwave.iCare.middletier.HIS.clsHisBase();
            clsPatientvo.m_strMODIFY_DAT = clsPatientvo.m_strFIRSTDATE_DAT = HisBase.s_GetServerDate().ToShortDateString();

            if (clsPatientvo.m_intERNALFLAG_INT == 1)
            {
                clsPatientvo.m_strGOVCARD_CHR = this.m_objViewer.m_txtCardID.Text.Trim();
            }
            if (clsPatientvo.m_intERNALFLAG_INT == 2)
            {
                clsPatientvo.m_strINSURANCEID_VCHR = this.m_objViewer.m_txtCardID.Text.Trim();
            }
            if (clsPatientvo.m_intERNALFLAG_INT == 5)
            {
                clsPatientvo.m_strINSURANCEID_VCHR = this.m_objViewer.m_txtCardID.Text.Trim();
            }
            if (clsPatientvo.m_intERNALFLAG_INT == 3)
            {
                clsPatientvo.m_strDIFFICULTY_VCHR = this.m_objViewer.m_txtCardID.Text.Trim();
            }
            if (clsPatientvo.m_intERNALFLAG_INT == 4)
            {
                clsPatientvo.m_strINSURANCEID_VCHR = this.m_objViewer.m_txtCardID.Text.Trim();
            }
            clsPatientvo.m_strPAYTYPEID_CHR = (string)this.m_objViewer.m_txtPatType.Tag;
            if (m_objViewer.m_radbirth.Checked == true)
                clsPatientvo.strBirthDate = Convert.ToString(this.m_objViewer.m_dtpBirth.Value);
            else if (m_objViewer.m_txtAge.Text != "")
            {
                string[] ArrChar = m_objViewer.m_txtAge.Text.Split(new char[] { '.' }, 2);
                if (ArrChar.Length > 2)
                {
                    MessageBox.Show("错误的岁数！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    m_objViewer.m_txtAge.Focus();
                    return;
                }
                int nowDate;
                int month;
                string strNowDate = "";
                if (ArrChar.Length == 2)
                {
                    nowDate = HisBase.s_GetServerDate().Year - Convert.ToInt32(ArrChar[0].ToString());
                    month = HisBase.s_GetServerDate().Month - 6;
                    if (month < 0)
                    {
                        nowDate--;
                        month = HisBase.s_GetServerDate().Month - 6 + 12;
                        strNowDate = nowDate.ToString() + "-" + month.ToString() + "-01";
                    }
                    else
                    {
                        month = HisBase.s_GetServerDate().Month - 6 - 12;
                        strNowDate = nowDate.ToString() + "-" + month.ToString() + "-01";
                    }
                }
                else
                {
                    nowDate = HisBase.s_GetServerDate().Year - Convert.ToInt32(ArrChar[0].ToString());
                    strNowDate = nowDate.ToString() + "-01-01";
                }
                clsPatientvo.strBirthDate = strNowDate;
            }
            else
            {
                clsPatientvo.strBirthDate = "1900-01-01";
            }
        }
        #endregion

        #region 查找并填充病人的资料
        /// <summary>
        /// 标志是否新病人1-新，0-旧
        /// </summary>
        public int m_NewOrModefy = 0;
        public int isNewAdd;
        clsPatient_VO objPatientvo;
        public DateTime birthDate;
        /// <summary>
        /// 查找并填充病人的资料
        /// </summary>
        public void m_FindPat(out string DepName, out string doctorName, out string registerDate)
        {
            isNewAdd = 0;
            DepName = null;
            doctorName = null;
            registerDate = null;
            if (m_objViewer.m_txtCard.Text == "")
            {
                isNewAdd = 1;
                this.m_NewOrModefy = 1;
                return;
            }
            long lngRes = 0;
            clsPatient_VO objResult = new clsPatient_VO();
            lngRes = clsDomain.m_lngGetPatByCard(m_objViewer.m_txtCard.Text, out objResult, DateTime.Now.ToShortDateString(), out DepName, out doctorName, out registerDate);
            objPatientvo = objResult;
            if (lngRes > 0 && clsMain.IsNullToString(objResult.strPatientID, null) != "")
            {
                m_objViewer.m_txtName.Text = objResult.strName;
                if (clsMain.IsNullToString(objResult.strBirthDate, null) != "")
                {
                    if (m_objViewer.m_radAge.Checked)
                    {
                        //com.digitalwave.iCare.middletier.HIS.clsHisBase  HisBase=new com.digitalwave.iCare.middletier.HIS.clsHisBase();
                        //com.digitalwave.iCare.middletier.HIS.clsHisBase HisBase = (com.digitalwave.iCare.middletier.HIS.clsHisBase)
                        //    com.digitalwave.iCare.common.clsObjectGenerator.objCreatorObjectByType(typeof(com.digitalwave.iCare.middletier.HIS.clsHisBase));
                        //DateTime nowTime = HisBase.s_GetServerDate();
                        birthDate = DateTime.Parse(objResult.strBirthDate);
                        //int nowTimeOfYear = nowTime.Year;
                        //int nowTimeOfMonth = nowTime.Month;
                        //int birOfYear = birthDate.Year;
                        //int birOfMonth = birthDate.Month;
                        //int year;
                        //int month;
                        //if ((nowTimeOfMonth - birOfMonth) < 0)
                        //{
                        //    year = nowTime.Year - birthDate.Year - 1;
                        //    month = -(nowTime.Month - birthDate.Month);
                        //}
                        //else
                        //{
                        //    year = nowTime.Year - birthDate.Year;
                        //    month = nowTime.Month - birthDate.Month;
                        //}
                        //string birthTime;
                        //if (month < 10)
                        //{
                        //    birthTime = year.ToString() + "岁0" + month.ToString() + "月";
                        //}
                        //else
                        //{
                        //    birthTime = year.ToString() + "岁" + month.ToString() + "月";
                        //}

                        m_objViewer.textBox1.Text = new clsBrithdayToAge().m_strGetAge(birthDate);
                        m_objViewer.intAeg.Text = new clsBrithdayToAge().m_strGetAge(birthDate);
                        m_objViewer.intAeg.Visible = true;
                        m_objViewer.intAeg.Enabled = false;
                    }
                    else
                    {
                        m_objViewer.m_dtpBirth.Value = Convert.ToDateTime(objResult.strBirthDate);
                    }
                }
                //m_objViewer.m_dtpBirth.Value=objResult.strBirthDate;
                clsRegister.m_strPayType = objResult.objPatType;
                m_objViewer.m_txtPatType.Text = objResult.objPatType.m_strPayTypeName;
                switch (objResult.m_intERNALFLAG_INT)
                {
                    case 0:
                        this.m_objViewer.label21.Text = "普通";
                        this.m_objViewer.m_txtCardID.Text = "";
                        this.m_objViewer.m_txtCardID.Tag = 0;
                        this.m_objViewer.m_txtCardID.Enabled = false;
                        break;
                    case 1:
                        this.m_objViewer.label21.Text = "公费号";
                        this.m_objViewer.m_txtCardID.Text = objResult.m_strGOVCARD_CHR;
                        this.m_objViewer.m_txtCardID.Tag = 1;
                        this.m_objViewer.m_txtCardID.Enabled = false;
                        break;
                    case 2:
                        this.m_objViewer.label21.Text = "医保号";
                        this.m_objViewer.m_txtCardID.Text = objResult.strInsuranceID;
                        this.m_objViewer.m_txtCardID.Tag = 2;
                        this.m_objViewer.m_txtCardID.Enabled = false;
                        break;
                    case 5:
                        this.m_objViewer.label21.Text = "医疗证号";
                        this.m_objViewer.m_txtCardID.Text = objResult.strInsuranceID;
                        this.m_objViewer.m_txtCardID.Tag = 5;
                        this.m_objViewer.m_txtCardID.Enabled = false;
                        break;
                    case 3:
                        this.m_objViewer.label21.Text = "特困号";
                        this.m_objViewer.m_txtCardID.Text = objResult.m_strDIFFICULTY_VCHR;
                        this.m_objViewer.m_txtCardID.Tag = 3;
                        this.m_objViewer.m_txtCardID.Enabled = false;
                        break;
                    case 4:
                        this.m_objViewer.label21.Text = "离休号";
                        this.m_objViewer.m_txtCardID.Text = objResult.strInsuranceID;
                        this.m_objViewer.m_txtCardID.Tag = 4;
                        this.m_objViewer.m_txtCardID.Enabled = true;
                        break;
                }
                m_objViewer.m_txtPatType.Text = objResult.objPatType.m_strPayTypeName;
                m_objViewer.m_txtPatType.Tag = (object)objResult.objPatType.m_strPayTypeID;
                clsRegister.m_objPatientCard.m_strCardID = objResult.strPatientCardID;
                clsRegister.m_strPatient = objResult.strPatientID;
                clsRegister.strOptimes = objResult.m_strOPTIMES_INT;
                m_objViewer.m_cboSex.Text = objResult.strSex;
                objPatientvo.strID_Card = objResult.strID_Card;
                objPatientvo.strID_Card = objResult.strInsuranceID;
                m_objViewer.m_txtDept.Focus();
            }
            else
            {
                if (!this.m_objViewer.m_cobModify.Checked)
                {
                    if (MessageBox.Show("查无该卡号病人信息！是否新增？", "ICARE	", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (this.m_objViewer.isRegist)
                        {
                            isNewAdd = 1;
                            this.m_NewOrModefy = 1;
                            this.m_objViewer.m_txtName.Clear();
                            this.m_objViewer.m_txtPatType.Clear();
                            this.m_objViewer.m_cboSex.Text = "";
                            this.m_objViewer.m_dtpBirth.Value = DateTime.Now.Date;
                            this.m_objViewer.m_txtAge.Clear();
                            this.m_objViewer.m_txtCardID.Text = "";
                            this.m_objViewer.m_lblOptimes.Text = "第1次挂号！";
                            this.m_objViewer.intAeg.Enabled = true;
                            this.m_objViewer.intAeg.Text = "";
                        }
                        else
                        {
                            m_NewCard();
                        }

                        return;

                    }
                    else
                    {
                        m_objViewer.m_txtCard.Focus();
                        this.m_NewOrModefy = 0;
                    }
                }
                else
                {
                    this.m_NewOrModefy = 0;
                }
            }
            if (!this.m_objViewer.m_cobModify.Checked)
            {
                try
                {
                    this.m_objViewer.m_lblOptimes.Text = "第" + Convert.ToString(int.Parse(clsRegister.strOptimes) + 1) + "次挂号！";
                    string patientcardid = this.m_objViewer.m_txtCard.Text;//"0000000000" + 
                    this.m_objViewer.m_txtCard.Text = patientcardid;
                    if (int.Parse(clsRegister.strOptimes) >= 1)
                    {
                        this.m_objViewer.m_chkNeedNotCard.Checked = false;
                        this.m_objViewer.m_chkNeedNotCard.Checked = true;
                        this.m_objViewer.m_chkNeedNotfalill.Checked = false;
                        this.m_objViewer.m_chkNeedNotfalill.Checked = true;
                    }
                    else
                    {
                        //this.m_objViewer.m_chkNeedNotCard.Checked = true;
                        //this.m_objViewer.m_chkNeedNotCard.Checked = false;
                        //this.m_objViewer.m_chkNeedNotfalill.Checked = true;
                        //this.m_objViewer.m_chkNeedNotfalill.Checked = false;
                        this.m_objViewer.m_chkNeedNotCard.Checked = false;
                        this.m_objViewer.m_chkNeedNotCard.Checked = true;
                        this.m_objViewer.m_chkNeedNotfalill.Checked = false;
                        this.m_objViewer.m_chkNeedNotfalill.Checked = true;
                    }
                }
                catch { }
            }

        }
        #endregion

        #region 新增卡号 zlc 2004-7-27
        /// <summary>
        /// 新增卡号
        /// </summary>
        public void m_NewCard()
        {
            string patientcardid = "";
            com.digitalwave.iCare.ValueObject.clsPatient_VO objPatientVo = new clsPatient_VO();
            //objPatientVo.strPatType = this.m_objViewer.m_txtPatType.Text;
            //objPatientVo.strName = this.m_objViewer.m_txtName.Text;
            //objPatientVo.strBirthDate = this.m_objViewer.m_dtpBirth.Value.ToShortDateString();
            //if (new com.digitalwave.iCare.gui.Patient.frmPatient().m_diaGetPatientCardID("1", objPatientVo, out patientcardid, out objPatientVo, this.m_objViewer.m_txtCard.Text.Trim()) == DialogResult.OK)
            if (new com.digitalwave.iCare.gui.Patient.frmPatient().m_diaGetPatientCardID("1", objPatientVo, out patientcardid, out objPatientVo, "") == DialogResult.OK)
            {
                patientcardid = "0000000000" + patientcardid;
                this.m_objViewer.m_txtCard.Text = patientcardid.Substring(patientcardid.Length - 10);
                string DepName = null;
                string doctorName = null;
                string registerDate = null;
                this.m_FindPat(out DepName, out doctorName, out registerDate);
                if (patientcardid.Length == 0)
                {
                    this.m_objViewer.m_txtName.Text = objPatientVo.m_strNAME_VCHR;
                    this.m_objViewer.m_txtPatType.Text = objPatientVo.m_strPAYTYPEID_CHR;
                    this.m_objViewer.m_cboSex.Text = objPatientVo.m_strSEX_CHR;
                    this.m_objViewer.m_dtpBirth.Text = objPatientVo.m_strBIRTH_DAT;
                }
            }
            else
            {
                m_objViewer.m_txtCard.Focus();
            }
        }
        #endregion

        #region 根据收费类型来选择医生
        /// <summary>
        /// 根据收费类型来选择医生0-医生可填 1-不需医生 2-医生必填
        /// </summary>
        public void m_lngChengDortor()
        {
            string objResult = "";
            if (this.m_objViewer.m_txtRegType.Text != "")
            {
                long lngRes = clsDomain.m_lngFindType(this.m_objViewer.m_txtRegType.Text.Trim(), out objResult);
                if (lngRes > 0 && objResult != "")
                {
                    switch (objResult)
                    {
                        case "0":
                            this.m_objViewer.m_lblRecount.Text = "医生可填";
                            break;
                        case "1":
                            this.m_objViewer.m_lblRecount.Text = "不需医生";
                            this.m_objViewer.m_txtDoc.Enabled = false;
                            break;
                        case "2":
                            this.m_objViewer.m_lblRecount.Text = "医生必填";
                            break;
                    }
                }
                else
                    this.m_objViewer.m_lblRecount.Text = "找不到此挂号类型的医生设置";
            }

        }
        #endregion

        #region 获取费用表 zlc 2004-8-3
        public clsRegisterPay[] m_clsRegisterPayVO;
        public void m_GetPay()
        {
            m_clsRegisterPayVO = new clsRegisterPay[0];
            clsDomain.m_lngGetPay(out m_clsRegisterPayVO);
        }
        #endregion

        #region 挂号或退号后在前台的数据（挂号次数、退号次数)
        string optime = "0";
        /// <summary>
        /// 挂号或退号后在前台的数据（挂号次数、退号次数)
        /// </summary>
        public void m_ResetRegTimes()
        {
            for (int i = 0; i < this.m_objViewer.m_lvItem.Items.Count; i++)
            {
                if (this.m_objViewer.m_lvItem.Items[i].Selected)
                {
                    this.m_objViewer.m_lvItem.Items[i].SubItems[10].Text = this.intRegCount;
                    this.optime = this.m_objViewer.m_lvItem.Items[i].SubItems[9].Text;
                }
            }
        }
        #endregion

        #region 获取挂号或预约时间
        /// <summary>
        /// 获取挂号或预约时间
        /// </summary>
        private void m_mthGetdate()
        {
            this.clsRegister.m_strRegisterDate = DateTime.Now.ToShortDateString();
            if (this.m_objViewer.m_chkPre.Checked == true)
            {
                this.clsRegister.strbespeakDate = this.m_objViewer.m_dtpPreTime.Value.ToShortDateString();
                this.clsRegister.strbespeak = this.m_objViewer.m_cboSeg.Text;
            }
            else
            {
                this.clsRegister.strbespeakDate = this.clsRegister.m_strRegisterDate;
                this.clsRegister.strbespeak = "";
            }
        }
        #endregion
        #region 新增一挂号记录
        private string strOrderNo = "";
        private string intRegCount = "0";
        private string registerTime = "";
        /// <summary>
        /// 新增一挂号记录
        /// </summary>
        /// <returns></returns>
        public long m_lngAddRegister()
        {
            string strID = "";
            string strNo = "";
            clsRegister.m_objDiagDept.strDeptID = (string)this.m_objViewer.m_txtDept.Tag;
            if (clsRegister == null)
                return -1;
            long lngRes = 0;
            if (!this.m_bolCheckValuePass())
                return -1;
            if (m_objViewer.m_chkPre.Checked) //预约
            {
                clsRegister.m_intFlag = "2";
            }
            else
            {
                //int hour=clsDomain.m_GetServTime().Hour;
                //int min= clsDomain.m_GetServTime().Minute;
                //registerTime=hour.ToString()+":"+min.ToString();
                registerTime = DateTime.Now.ToString("HH:mm");
            }
            clsRegister.m_strPiod = m_objViewer.m_cboSeg.Text;
            clsRegister.strINVNO_CHR = m_objViewer.txtCheckNO.Text.Trim();
            clsRegister.m_decRegisterPay = decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtRegFee.Text, "0"));
            clsRegister.m_decDiagPay = decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtDiagFee.Text, "0"));
            clsRegister.m_decRegisterPay = this.m_objViewer.m_paytypename.SelectedIndex;
            int year;
            int month;
            int day;
            DateTime RegisterDate = new DateTime();
            RegisterDate = Convert.ToDateTime(clsRegister.m_strRegisterDate);
            year = RegisterDate.Year;
            month = RegisterDate.Month;
            day = RegisterDate.Day;
            clsRegister.m_strRegisterNo = year.ToString().Trim() + month.ToString("00").Trim() + day.ToString("00").Trim();
            int isNewPatient = 0;
            com.digitalwave.iCare.ValueObject.clsPatient_VO clsPatientvo = new com.digitalwave.iCare.ValueObject.clsPatient_VO();
            //医辽号码
            string strNO = "";
            //病人类型ＩＤ
            string strPatienID = (string)this.m_objViewer.m_txtPatType.Tag;
            if (isNewAdd == 1 || this.m_objViewer.m_txtCard.Text == "")
            {
                isNewPatient = 1;
                this.m_lngNewPatient(out clsPatientvo);
            }
            else
            {
                if (this.m_objViewer.m_txtCardID.Tag != null)
                {
                    try
                    {
                        clsPatientvo.m_intERNALFLAG_INT = (int)this.m_objViewer.m_txtCardID.Tag;
                        if (clsPatientvo.m_intERNALFLAG_INT == 1)
                        {
                            strNO = clsPatientvo.m_strGOVCARD_CHR = this.m_objViewer.m_txtCardID.Text.Trim();

                        }
                        if (clsPatientvo.m_intERNALFLAG_INT == 2)
                        {
                            strNO = clsPatientvo.m_strINSURANCEID_VCHR = this.m_objViewer.m_txtCardID.Text.Trim();
                        }
                        if (clsPatientvo.m_intERNALFLAG_INT == 5)
                        {
                            strNO = clsPatientvo.m_strINSURANCEID_VCHR = this.m_objViewer.m_txtCardID.Text.Trim();
                        }
                        if (clsPatientvo.m_intERNALFLAG_INT == 3)
                        {
                            strNO = clsPatientvo.m_strDIFFICULTY_VCHR = this.m_objViewer.m_txtCardID.Text.Trim();
                        }
                        if (clsPatientvo.m_intERNALFLAG_INT == 4)
                        {
                            strNO = clsPatientvo.m_strINSURANCEID_VCHR = this.m_objViewer.m_txtCardID.Text.Trim();
                        }
                    }
                    catch
                    {
                    }
                }
            }
            clsPatientDetail_VO[] PatientDetail_VO = new clsPatientDetail_VO[m_objViewer.m_lsvRegDetail.Items.Count];
            int DetailCount = m_objViewer.m_lsvRegDetail.Items.Count;
            for (int i = 0; i < DetailCount; i++)
            {
                PatientDetail_VO[i] = new clsPatientDetail_VO();
                PatientDetail_VO[i].m_strREGISTERID_CHR = this.m_strRegisterID;
                PatientDetail_VO[i].m_strCHARGEID_CHR = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[1].Text;
                PatientDetail_VO[i].m_dblPAYMENT_MNY = double.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text);
                PatientDetail_VO[i].m_fltDISCOUNT_DEC = float.Parse(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
            }
            clsRegister.m_objRegisterEmp.strEmpID = this.m_objViewer.LoginInfo.m_strEmpID;
            string outCardID;
            m_mthGetdate();
            if (this.m_objViewer.m_cobModify.Checked)
            {
                clsRegister.m_strRegisterDate = DateTime.Now.ToShortDateString();
                lngRes = clsDomain.m_lngModifyRegister(clsRegister);
                this.m_strRegisterID = clsRegister.m_strRegisterID;
                lngRes = m_lngAddRegisterDetail();
                this.m_objViewer.m_cobModify.Checked = false;
                return lngRes;
            }
            else
            {
                clsRegister.m_objPatientCard.m_strCardID = m_objViewer.m_txtCard.Text;
                lngRes = clsDomain.m_lngAddRegister(clsRegister, out strID, out strNo, out strOrderNo, out intRegCount, clsPatientvo, isNewPatient, this.m_objViewer.m_txtCard.Text.Trim(), out outCardID, PatientDetail_VO, strNO, strPatienID, this.m_objViewer.m_txtCardID.Text.Trim());
            }
            if (lngRes > 0 && strID != "-1")
            {
                m_lngRepalceXML(this.m_objViewer.txtCheckNO.Text.Trim());
                this.m_strRegisterID = clsRegister.m_strRegisterID = strID;
                clsRegister.m_strRegisterNo = strNo;
                this.m_objViewer.m_txtCard.Text = outCardID;
                this.m_AddListPat();
                m_ResetRegTimes();
            }
            else
            {
                MessageBox.Show("挂号失败，请联系管理员！", "Icare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return -1;
            }
            return lngRes;
        }
        public long m_lngAddRegisterDetail()
        {
            int DetailCount = m_objViewer.m_lsvRegDetail.Items.Count;
            long lngarg = 0;
            for (int i = 0; i < DetailCount; i++)
            {
            }
            return lngarg;
        }

        private void m_AddListPat()
        {

            if (clsMain.IsNullToString(clsRegister.m_strRegisterID, null) != "")
            {
                ListViewItem lvw = null;
                lvw = new ListViewItem(long.Parse(clsRegister.m_strRegisterNo).ToString());
                lvw.SubItems.Add(clsRegister.m_strRegisterDate);
                lvw.SubItems.Add(m_objViewer.m_cboSeg.Text);
                lvw.SubItems.Add(m_objViewer.m_txtName.Text);
                lvw.SubItems.Add(clsRegister.m_objDiagDept.strDeptName);
                lvw.SubItems.Add(clsRegister.m_strRegisterType.m_strRegisterTypeName);
                lvw.SubItems.Add(clsRegister.m_objDiagDoctor.strName);
                lvw.Tag = clsRegister;
            }

        }

        #endregion

        #region 修改金额和优惠
        /// <summary>
        /// 修改金额和优惠
        /// </summary>
        /// <returns></returns>
        public int m_intModifyPrice()
        {
            for (int i = 0; i < this.m_objViewer.m_lsvRegDetail.Items.Count; i++)
            {
                if (this.m_objViewer.m_lsvRegDetail.Items[i].Selected == true)
                {
                    if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[5].Text.IndexOf("不可修改") >= 0)
                    {
                        return i;
                    }
                    this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text = Convert.ToString(decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtChangeCharge.Text, "0")));
                    this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text = Convert.ToString(decimal.Parse(clsMain.IsNullToString(m_objViewer.m_txtChangeDisCount.Text, "0")));
                    m_FigureUpPay();
                    return i;
                }
            }

            return 0;
        }
        public void m_getCurPrice()
        {

            for (int i = 0; i < this.m_objViewer.m_lsvRegDetail.Items.Count; i++)
            {

                if (this.m_objViewer.m_lsvRegDetail.Items[i].Selected == true)
                {
                    if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[5].Text.IndexOf("不可修改") >= 0)
                    {
                        m_objViewer.m_txtChangeCharge.ReadOnly = true;
                        m_objViewer.m_txtChangeDisCount.ReadOnly = true;
                    }
                    else
                    {
                        m_objViewer.m_txtChangeCharge.ReadOnly = false;
                        m_objViewer.m_txtChangeDisCount.ReadOnly = false;
                    }
                    m_objViewer.m_txtChangeCharge.Text = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text;
                    m_objViewer.m_txtChangeDisCount.Text = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text;
                }

            }

        }
        public void m_UpDown(int index, System.Windows.Forms.KeyEventArgs e, object sender)
        {
            if (((ListView)sender).Items.Count > 0)
            {
                if (index == ((ListView)sender).Items.Count - 1 && e.KeyCode == Keys.Down)
                {
                    ((ListView)sender).Items[index].Selected = false;
                    ((ListView)sender).Items[0].Selected = true;
                    ((ListView)sender).Items[0].EnsureVisible();
                }
                if (index == 0 && e.KeyCode == Keys.Up)
                {
                    ((ListView)sender).Items[0].Selected = false;
                    ((ListView)sender).Items[((ListView)sender).Items.Count - 1].Selected = true;
                    ((ListView)sender).Items[((ListView)sender).Items.Count - 1].EnsureVisible();
                }
                if (index > 0 && index <= ((ListView)sender).Items.Count - 1 && e.KeyCode == Keys.Up)
                {
                    ((ListView)sender).Items[index].Selected = false;
                    ((ListView)sender).Items[index - 1].Selected = true;
                    ((ListView)sender).Items[index - 1].EnsureVisible();
                }
                if (index >= 0 && index < ((ListView)sender).Items.Count - 1 && e.KeyCode == Keys.Down)
                {
                    ((ListView)sender).Items[index].Selected = false;
                    ((ListView)sender).Items[index + 1].Selected = true;
                    ((ListView)sender).Items[index + 1].EnsureVisible();
                }
                if (index < 0 && e.KeyCode == Keys.Down)
                {
                    ((ListView)sender).Items[0].Selected = true;
                    ((ListView)sender).Items[0].EnsureVisible();
                }
                if (index < 0 && e.KeyCode == Keys.Up)
                {
                    ((ListView)sender).Items[((ListView)sender).Items.Count - 1].Selected = true;
                    ((ListView)sender).Items[((ListView)sender).Items.Count - 1].EnsureVisible();
                }
            }
        }
        #endregion

        #region 不须发卡时的费用
        /// <summary>
        /// 不须发卡时的费用
        /// </summary>
        /// <param name="strName"></param>
        public void m_MoveCardPay(string strName)
        {

            switch (strName)
            {
                case "m_chkNeedNotfalill":
                    if (this.m_objViewer.m_chkNeedNotfalill.Checked)
                    {
                        for (int i = 0; i < this.m_objViewer.m_lsvRegDetail.Items.Count; i++)
                        {
                            if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.IndexOf("工本费") >= 0)
                            {
                                this.m_objViewer.m_lsvRegDetail.Items[i].Selected = true;
                            }
                            else
                            {
                                this.m_objViewer.m_lsvRegDetail.Items[i].Selected = false;
                            }
                        }
                        this.m_objViewer.m_txtChangeCharge.Text = "0";
                        this.m_objViewer.m_txtChangeDisCount.Text = "0";
                        this.m_intModifyPrice();
                    }
                    break;
                case "m_chkNeedNotCard":
                    if (this.m_objViewer.m_chkNeedNotCard.Checked)
                    {
                        for (int i = 0; i < this.m_objViewer.m_lsvRegDetail.Items.Count; i++)
                        {
                            if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.IndexOf("磁卡费") >= 0)
                            {
                                this.m_objViewer.m_lsvRegDetail.Items[i].Selected = true;
                            }
                            else
                            {
                                this.m_objViewer.m_lsvRegDetail.Items[i].Selected = false;
                            }
                        }
                        this.m_objViewer.m_txtChangeCharge.Text = "0";
                        this.m_objViewer.m_txtChangeDisCount.Text = "0";
                        this.m_intModifyPrice();
                    }
                    break;
            }

        }
        #endregion
        /// <summary>
        /// 开始初始化
        /// </summary>
        public void m_mthBeginInitial()
        {
            clsRegister_Vo m_objRegisterVo = new clsRegister_Vo();
            m_objRegisterVo.m_strEmpName = this.m_objViewer.LoginInfo.m_strEmpName;
            m_objRegisterVo.m_DateRegister = Convert.ToDateTime(clsRegister.m_strRegisterDate);
            m_objRegisterVo.m_strPatientName = this.m_objViewer.m_txtName.Text;
            m_objRegisterVo.m_strSerialNo = this.m_objViewer.txtCheckNO.Text.Trim();
            for (int i = 0; i < this.m_objViewer.m_lsvRegDetail.Items.Count; i++)
            {
                if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim() == "挂号费")
                {
                    decimal beli = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
                    decimal m_objTemp = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text) * beli;
                    m_objRegisterVo.m_strRegisterFee = m_objTemp.ToString("0.00");

                }
                else if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim() == "诊疗费")
                {
                    decimal beli = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
                    decimal m_objTemp = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text) * beli;
                    m_objRegisterVo.m_strTreatFee = m_objTemp.ToString("0.00");
                }
                else
                {
                    decimal beli = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
                    decimal m_objTemp = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text) * beli;
                    m_objRegisterVo.m_strMaterialFee = m_objTemp.ToString("0.00");
                    m_objRegisterVo.m_strMaterialFeeName = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim();
                }
            }
            decimal m_objTempDecimal = 0;
            if (m_objRegisterVo.m_strTreatFee.Trim() != string.Empty)
            {
                m_objTempDecimal = decimal.Parse(m_objRegisterVo.m_strTreatFee);
            }
            if (m_objRegisterVo.m_strRegisterFee.Trim() != string.Empty)
            {
                m_objTempDecimal += decimal.Parse(m_objRegisterVo.m_strRegisterFee);
            }
            if (m_objRegisterVo.m_strMaterialFee.Trim() != string.Empty)
            {
                m_objTempDecimal += decimal.Parse(m_objRegisterVo.m_strMaterialFee);
            }
            m_objRegisterVo.m_strTotalFee = m_objTempDecimal.ToString("0.00");
            m_objPrintRegister.obj_VO = m_objRegisterVo;
        }
        public void m_mthPrintPage(System.Drawing.Printing.PrintPageEventArgs e)
        {
            m_objPrintRegister.DrawObject = e;
            m_objPrintRegister.m_mthBeginPrint();
        }
        #region 打印挂号票
        private clsCalcPatientCharge m_objChargeCal;
        private string m_strRegisterID = "";
        int totailprint = 0;
        /// <summary>
        /// 发票格式设置，0-挂号专用发票；1-门诊收费发票
        /// </summary>
        int statusint = 0;
        public void m_PrintRegister(object sender)
        {


            long lngRes = clsDomain.m_mthGetRegisterSetting("1200", out statusint);
            if (lngRes == 1)
            {
                if (statusint == 0)
                {
                    #region
                    System.Data.DataTable dtbSource = new System.Data.DataTable("printtemptable");
                    dtbSource.Columns.Add("varchar1");
                    dtbSource.Columns.Add("patientname");
                    dtbSource.Columns.Add("date");
                    dtbSource.Columns.Add("orderno");
                    dtbSource.Columns.Add("registerno");
                    dtbSource.Columns.Add("address");
                    dtbSource.Columns.Add("registertype");
                    dtbSource.Columns.Add("strDiagdept");
                    dtbSource.Columns.Add("strEmpt");
                    dtbSource.Columns.Add("doctorName");
                    dtbSource.Columns.Add("patienCard");
                    dtbSource.Columns.Add("txtNO");
                    dtbSource.Columns.Add("decimal1", typeof(decimal));
                    dtbSource.Columns.Add("decimal2", typeof(decimal));
                    dtbSource.Columns.Add("txtAvailDays");
                    dtbSource.Columns.Add("txtRepeatNo");
                    dtbSource.Rows.Add(new object[] { });
                    dtbSource.Rows[0][12] = 0;
                    dtbSource.Rows[0][13] = 0;

                    for (int i = 0; i < this.m_objViewer.m_lsvRegDetail.Items.Count; i++)
                    {
                        if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim() == "挂号费")
                        {
                            decimal beli = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
                            dtbSource.Rows[0][0] = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text;
                            dtbSource.Rows[0][1] = this.m_objViewer.m_txtName.Text;
                            if (this.m_objViewer.m_chkPre.Checked == true)
                            {
                                dtbSource.Rows[0][2] = "预约" + this.m_objViewer.m_dtpPreTime.Value.ToShortDateString() + this.m_objViewer.m_cboSeg.Text;
                            }
                            else
                            {
                                dtbSource.Rows[0][2] = clsRegister.m_strRegisterDate + " " + registerTime;
                            }
                            dtbSource.Rows[0][3] = strOrderNo;
                            dtbSource.Rows[0][4] = clsRegister.m_strRegisterNo;
                            dtbSource.Rows[0][5] = this.m_objViewer.m_lbRoom.Text;
                            dtbSource.Rows[0][6] = this.m_objViewer.m_txtRegType.Text;
                            dtbSource.Rows[0][7] = this.m_objViewer.m_txtDept.Text;
                            if (this.m_intShowEmpName == 1)
                            {
                                dtbSource.Rows[0][8] = this.m_objViewer.LoginInfo.m_strEmpNo + "(" + this.m_objViewer.LoginInfo.m_strEmpName + ")";
                            }
                            else
                            {
                                dtbSource.Rows[0][8] = this.m_objViewer.LoginInfo.m_strEmpNo;
                            }
                            dtbSource.Rows[0][9] = this.m_objViewer.m_txtDoc.Text.Trim();
                            dtbSource.Rows[0][10] = this.m_objViewer.m_txtCard.Text.Trim();
                            dtbSource.Rows[0][11] = this.m_objViewer.txtCheckNO.Text.Trim();
                            dtbSource.Rows[0][12] = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text) * beli;
                            dtbSource.Rows[0][14] = AvailDays;
                            dtbSource.Rows[0][15] = "";
                        }
                        if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim() == "诊疗费")
                        {
                            decimal beli = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
                            dtbSource.Rows[0][13] = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text) * beli;
                        }


                    }
                    #endregion
                    switch (this.m_objViewer.m_cobSetPrint.SelectedIndex)
                    {

                        case 0:
                            new FrmShowPrint().m_PrintRegister11(dtbSource);
                            break;
                        case 1:
                            new FrmShowPrint().m_ShowRegister11(dtbSource);
                            break;
                        case 2:
                            break;
                        default:
                            break;
                    }
                    this.m_Clear(sender);
                }
                else
                {
                    clsRegister_Vo m_objRegisterVo = new clsRegister_Vo();
                    for (int i = 0; i < this.m_objViewer.m_lsvRegDetail.Items.Count; i++)
                    {
                        if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim() == "挂号费")
                        {
                            decimal beli = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
                            decimal m_objTemp = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text) * beli;
                            m_objRegisterVo.m_strRegisterFee = m_objTemp.ToString("0.00");

                        }
                        else if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim() == "诊疗费")
                        {
                            decimal beli = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
                            decimal m_objTemp = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text) * beli;
                            m_objRegisterVo.m_strTreatFee = m_objTemp.ToString("0.00");
                        }
                        else
                        {
                            decimal beli = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text.Replace("%", "")) / 100;
                            decimal m_objTemp = Convert.ToDecimal(this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text) * beli;
                            m_objRegisterVo.m_strMaterialFee = m_objTemp.ToString("0.00");
                            m_objRegisterVo.m_strMaterialFeeName = this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim();
                        }
                    }
                    decimal m_objTempDecimal = 0;
                    if (m_objRegisterVo.m_strTreatFee.Trim() != string.Empty)
                    {
                        m_objTempDecimal = decimal.Parse(m_objRegisterVo.m_strTreatFee);
                    }
                    if (m_objRegisterVo.m_strRegisterFee.Trim() != string.Empty)
                    {
                        m_objTempDecimal += decimal.Parse(m_objRegisterVo.m_strRegisterFee);
                    }
                    if (m_objRegisterVo.m_strMaterialFee.Trim() != string.Empty)
                    {
                        m_objTempDecimal += decimal.Parse(m_objRegisterVo.m_strMaterialFee);
                    }
                    clsPatientChargeCal m_objPatientChargeCal = new clsPatientChargeCal();
                    m_objPatientChargeCal.m_strPatientCardID = this.m_objViewer.m_txtCard.Text.Trim();
                    m_objPatientChargeCal.m_strInvoiceNO = this.m_objViewer.txtCheckNO.Text.Trim();
                    m_objPatientChargeCal.m_strPatientName = this.m_objViewer.m_txtName.Text.Trim();
                    m_objPatientChargeCal.m_decTotalCost = m_objTempDecimal;
                    m_objPatientChargeCal.m_strCollector = this.m_objViewer.LoginInfo.m_strEmpName;
                    m_objPatientChargeCal.m_decPersonCost = m_objTempDecimal;
                    m_objPatientChargeCal.m_strDateOfReception = DateTime.Now.ToString();
                    m_objPatientChargeCal.m_strHospitalName = this.m_objComInfo.m_strGetHospitalTitle();
                    m_objPatientChargeCal.m_strInvoiceNO = this.m_objViewer.txtCheckNO.Text;
                    m_objPatientChargeCal.m_intInvoiceType = 1;
                    m_objPatientChargeCal.m_strDeptName = this.m_objViewer.m_txtDept.Text;
                    m_objPatientChargeCal.m_strDoctorName = this.m_objViewer.m_txtDoc.Text;
                    m_objPatientChargeCal.m_strRegisterTime = DateTime.Now.ToString("HH:mm");
                    if (m_objRegisterVo.m_strRegisterFee.Trim() != string.Empty)
                    {
                        m_objPatientChargeCal.m_decGHf = Convert.ToDecimal(m_objRegisterVo.m_strRegisterFee);
                    }
                    if (m_objRegisterVo.m_strTreatFee.Trim() != string.Empty)
                    {
                        m_objPatientChargeCal.m_decZjf = Convert.ToDecimal(m_objRegisterVo.m_strTreatFee);
                    }
                    if (m_objRegisterVo.m_strMaterialFee.Trim() != string.Empty)
                    {
                        m_objPatientChargeCal.m_decClf = Convert.ToDecimal(m_objRegisterVo.m_strMaterialFee);
                    }
                    switch (this.m_objViewer.m_cobSetPrint.SelectedIndex)
                    {

                        case 0:
                            this.m_objChargeCal.m_mthPrintCharge(m_objPatientChargeCal);
                            break;
                        case 1:
                            this.m_objChargeCal.m_mthPrintChargePreview(m_objPatientChargeCal);
                            break;
                        case 2:
                            break;
                        default:
                            break;
                    }
                    this.m_Clear(sender);

                }
            }
        }
        #endregion

        #region 检查当前的数据是否有效
        /// <summary>
        /// 检查当前的数据是否有效
        /// </summary>
        /// <returns></returns>
        public bool m_bolCheckValuePass()
        {
            bool bolReturn = true;
            if (m_objViewer.m_txtName.Text.Trim() == "")
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtName, "病人名称");
                this.m_objViewer.m_txtName.Focus();
                return false;
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtName, "");
            }

            if (m_objViewer.m_cboSex.SelectedIndex < 0)
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSex, "请选择性别");
                this.m_objViewer.m_cboSex.Focus();
                return false;
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSex, "");
            }
            if (m_objViewer.m_txtAge.Text.Trim() == "" && m_objViewer.m_txtAge.Visible)
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtAge, "请填岁数");
                m_objViewer.m_txtAge.Focus();
                return false;
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtAge, "");
            }
            if (m_objViewer.textBox1.Text.Trim() == "" && m_objViewer.textBox1.Visible)
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.textBox1, "请填岁数");
                m_objViewer.textBox1.Focus();
                return false;
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.textBox1, "");
            }
            if (clsMain.IsNullToString(clsRegister.m_strPayType.m_strPayTypeID, null) == "")
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtPatType, "病人类别");
                //m_ephHandler.m_mthAddControl(m_objViewer.m_txtPatType);
                m_objViewer.m_txtPatType.Focus();
                return false;
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtPatType, "");
            }

            if (m_objViewer.m_cboSeg.SelectedIndex < 0)
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSeg, "请选择时间段");
                m_objViewer.m_cboSeg.Focus();
                return false;
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSeg, "");
            }

            if (!bnlChekcBirth()) //出生日期
                bolReturn = false;
            if (clsMain.IsNullToString(clsRegister.m_objDiagDept.strDeptID, null) == "")
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtDept, "科室");
                m_objViewer.m_txtDept.Focus();
                //m_ephHandler.m_mthAddControl(m_objViewer.m_txtDept);
                return false;
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtDept, "");
            }
            if (clsMain.IsNullToString(clsRegister.m_objDiagDoctor.strEmpID, null) == "" && clsRegister.m_strRegisterType.m_decRegPay == 2)
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtDoc, "医生");
                m_objViewer.m_txtDoc.Focus();
                //m_ephHandler.m_mthAddControl(m_objViewer.m_txtDoc);
                return false;
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtDoc, "");
            }
            if (clsMain.IsNullToString(clsRegister.m_strRegisterType.m_strRegisterTypeID, null) == "" || m_objViewer.m_txtRegType.Text.Trim() == "")
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtRegType, "挂号类型");
                //m_ephHandler.m_mthAddControl(m_objViewer.m_txtRegType);
                m_objViewer.m_txtRegType.Focus();
                return false;
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_txtRegType, "");
            }
            bool bnlChk = this.bnlCheckDate();
            if (!bnlChk)
                bolReturn = false;
            if (!bolReturn)
            {
                m_ephHandler.m_mthShowControlsErrorProvider();
                m_ephHandler.m_mthClearControl();
            }
            return bolReturn;
        }
        public bool bnlCheckDate()
        {
            bool bolReturn = true;
            if (m_objViewer.m_chkPre.Checked) //预约
            {
                DateTime PreTime = Convert.ToDateTime(m_objViewer.m_dtpPreTime.Value.ToShortDateString());
                DateTime sevTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                if (PreTime < sevTime) //不能预约以前
                {
                    m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpPreTime, "不能预约当天之前的号");
                    bolReturn = false;
                }
                else
                {
                    if (sevTime == PreTime)//如果是当天，可以预约下午或晚上的
                    {
                        m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpPreTime, "");
                        if (this.m_GetSerPerio() > m_objViewer.m_cboSeg.SelectedIndex) //不能挂前一个时间段的
                        {
                            m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSeg, "不能预约当前时间段之前的号");
                            bolReturn = false;
                        }
                    }
                }
                if (bolReturn)
                {
                    m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpPreTime, "");
                    m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSeg, "");
                }
            }
            else
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpPreTime, "");
                m_objViewer.errorProvider1.SetError(m_objViewer.m_cboSeg, "");
            }
            return bolReturn;
        }
        public bool bnlChekcBirth()
        {
            bool bolReturn = true;
            if (m_objViewer.m_dtpBirth.Value > DateTime.Now)
            {
                m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpBirth, "出生日期不能大于当前的时间");
                bolReturn = false;
            }
            else
                m_objViewer.errorProvider1.SetError(m_objViewer.m_dtpBirth, "");
            return bolReturn;
        }
        #endregion

        #region 查询挂号票 zlc 2004-7-30
        public void m_lngQuy()
        {
        }
        #endregion

        #region 填充TEXTBOX zlc
        public void m_FillTextbox(clsPatientRegister_VO[] objreg)
        {

        }
        #endregion

        #region 给lv 定位
        public void m_AlignlvItem(string strTxtName, ListView objlsv)
        {
            switch (strTxtName)
            {
                case "m_txtDept":
                    try
                    {
                        if (this.m_objViewer.m_lvItem.SelectedItems[0].SubItems[1].Text ==
                            objlsv.SelectedItems[0].SubItems[0].Text)
                        {
                            return;
                        }
                    }
                    catch { }
                    try
                    {
                        for (int i = 0; i < this.m_objViewer.m_lvItem.Items.Count; i++)
                        {
                            if (this.m_objViewer.m_lvItem.Items[i].SubItems[1].Text == objlsv.SelectedItems[0].SubItems[0].Text)
                            {
                                this.m_objViewer.m_lvItem.Items[i].Selected = true;
                                this.m_objViewer.m_lvItem.Items[i].EnsureVisible();
                                return;
                            }

                            else
                            {
                                this.m_objViewer.m_lvItem.Items[i].Selected = false;
                            }
                        }
                    }
                    catch { }

                    break;
                case "m_txtRegType":
                    try
                    {
                        if (this.m_objViewer.m_lvItem.SelectedItems[0].SubItems[2].Text ==
                            objlsv.SelectedItems[0].SubItems[0].Text)
                        {
                            return;
                        }
                    }
                    catch { }
                    try
                    {
                        for (int i = 0; i < this.m_objViewer.m_lvItem.Items.Count; i++)
                        {
                            if (this.m_objViewer.m_lvItem.Items[i].SubItems[4].Text == objlsv.SelectedItems[0].SubItems[0].Text)
                            {
                                this.m_objViewer.m_lvItem.Items[i].Selected = true;
                                this.m_objViewer.m_lvItem.Items[i].EnsureVisible();
                                return;
                            }
                            else
                            {
                                this.m_objViewer.m_lvItem.Items[i].Selected = false;
                            }
                        }
                    }
                    catch { }
                    break;
                case "m_txtDoc":
                    bool bl = false;
                    try
                    {
                        if (this.m_objViewer.m_lvItem.SelectedItems[0].SubItems[4].Text ==
                            objlsv.SelectedItems[0].SubItems[0].Text)
                        {
                            return;
                        }
                    }
                    catch { }
                    try
                    {
                        for (int i = 0; i < this.m_objViewer.m_lvItem.Items.Count; i++)
                        {
                            if (this.m_objViewer.m_lvItem.Items[i].SubItems[2].Text == objlsv.SelectedItems[0].SubItems[0].Text)
                            {
                                this.m_objViewer.m_lvItem.Items[i].Selected = true;
                                this.m_objViewer.m_lvItem.Items[i].EnsureVisible();
                                bl = true;
                                break;
                            }
                            else if (this.m_objViewer.m_lvItem.Items[i].SubItems[7].Text.Trim().IndexOf(this.m_objViewer.m_txtDoc.Text.Trim()) == 0)
                            {
                                this.m_objViewer.m_lvItem.Items[i].Selected = true;
                                bl = false;
                            }
                            else
                            {
                                this.m_objViewer.m_lvItem.Items[i].Selected = false;
                                bl = false;
                            }
                        }
                        //					if(!bl)
                        //					{
                        //						this.m_objViewer.m_lblRecount.Text = "该医生没有排班！";
                        //					}
                        //					else
                        //					{
                        //						this.m_objViewer.m_lblRecount.Text = "";
                        //					}
                        m_lngChengDortor();
                    }
                    catch { }
                    //					this.m_objViewer.m_txtDoc.Text = this.m_objViewer.m_lsvAllplan.SelectedItems[0].SubItems[1].Text;
                    //					this.m_objViewer.m_txtDoc.Tag = this.m_objViewer.m_lsvAllplan.SelectedItems[0].SubItems[0].Text;
                    break;
            }
        }
        #endregion

        #region 设置或取消控件的只读
        /// <summary>
        /// 设置或取消控件的只读
        /// </summary>
        /// <param name="bl"></param>
        public void m_SetReadOnly(bool bl)
        {
            this.m_objViewer.m_txtRegType.Enabled = !bl;
            this.m_objViewer.m_txtDept.Enabled = !bl;
            this.m_objViewer.m_txtDoc.Enabled = !bl;
            this.m_objViewer.m_lblRegisterNo.Enabled = bl;
            this.m_objViewer.m_txtRegisterNo.Enabled = bl;
            this.m_objViewer.m_txtCard.ReadOnly = bl;
            this.m_objViewer.m_txtName.ReadOnly = bl;
            this.m_objViewer.m_txtPatType.Enabled = !bl;
            this.m_objViewer.m_radAge.Enabled = !bl;
            this.m_objViewer.m_radbirth.Enabled = !bl;
            this.m_objViewer.m_dtpBirth.Enabled = !bl;
            this.m_objViewer.m_txtAge.ReadOnly = bl;
            this.m_objViewer.m_paytypename.Enabled = !bl;
            this.m_objViewer.m_cboSex.Enabled = !bl;
            this.m_objViewer.m_chkPre.Checked = false;
            this.m_objViewer.m_chkPre.Enabled = !bl;
            //	this.m_objViewer.m_btnReturnReg.Visible = bl;
            if (bl)
            {
                this.m_objViewer.m_txtRegisterNo.Focus();
            }
            else
            {
                this.m_objViewer.m_txtRegisterNo.Clear();

                this.m_objViewer.m_txtCard.Focus();
            }
            //			this.m_Clear();

        }
        #endregion

        #region 退号
        public void m_ReturnReg(Object sender)
        {
            string strReturnDate = DateTime.Now.ToShortDateString();
            string strReturnEmpno = this.m_objViewer.LoginInfo.m_strEmpID;
            string newID = "";

            string ConfirmID = "";
            frmOPSConfirm fc = new frmOPSConfirm();
            if (fc.ShowDialog() == DialogResult.OK)
            {
                ConfirmID = fc.Empid;
            }
            else
            {
                return;
            }

            clsDomain.m_lngCancelReg(clsRegister.m_strRegisterID, strReturnEmpno, strReturnDate, ConfirmID, out newID);
            this.m_objViewer.m_cobModify.Checked = false;
            this.m_Clear(sender);
        }
        #endregion

        #region 根据流水号查找挂号
        public void m_GetRegByRegNo(object sender)
        {
            clsPatientRegister_VO objreg = null;
            string date = DateTime.Now.ToShortDateString();
            long lngarr = this.clsDomain.m_lngGetRegiterByNo(this.m_objViewer.m_txtRegisterNo.Text, date, out objreg);
            if (lngarr == 0)
            {
                this.m_Clear(sender);
                this.m_objViewer.m_txtRegisterNo.Focus();
                return;
            }
            m_FillTextbox(objreg);
            m_GetCurPay();
            m_FillDetail(objreg.m_strRegisterID);
            this.m_objViewer.m_txtCard.Focus();
            this.m_objViewer.m_txtCard.ReadOnly = false;
            this.m_objViewer.m_txtName.ReadOnly = false;
            this.m_objViewer.m_txtPatType.Enabled = true;
            this.m_objViewer.m_radAge.Enabled = true;
            this.m_objViewer.m_radbirth.Enabled = true;
            this.m_objViewer.m_dtpBirth.Enabled = true;
            this.m_objViewer.m_txtAge.ReadOnly = false;
            this.m_objViewer.m_paytypename.Enabled = true;
            this.m_objViewer.m_cboSex.Enabled = true;
            m_AlignlvItem("m_txtDoc", this.m_objViewer.m_lsvAlldoc);
            //this.m_objViewer.m_lblOptimes.Text = "第"+Convert.ToString(int.Parse(clsRegister.strOptimes))+"次挂号！";
        }
        #endregion

        #region VO填充TEXTBOX zlc
        public void m_FillTextbox(clsPatientRegister_VO objreg)
        {
            clsRegister = objreg;
            this.m_objViewer.m_txtCard.Text = objreg.m_objPatientCard.m_strCardID;
            this.m_objViewer.m_txtCard.Tag = objreg.m_objPatientCard.m_strCardID;
            this.m_objViewer.m_txtName.Text = objreg.m_clsPatientVO.strName;
            this.m_objViewer.m_txtName.Tag = objreg.m_clsPatientVO.strPatientID;
            this.m_objViewer.m_cboSex.Text = objreg.m_clsPatientVO.strSex.Trim();
            if (this.m_objViewer.m_radAge.Checked)
            {
                //int age = 
                this.m_objViewer.m_txtAge.Value = Convert.ToDateTime(objreg.m_clsPatientVO.strBirthDate);
            }
            else
            {
                this.m_objViewer.m_dtpBirth.Value = Convert.ToDateTime(objreg.m_clsPatientVO.strBirthDate);
            }

            this.m_objViewer.m_txtPatType.Text = objreg.m_strPayType.m_strPayTypeName.Trim();
            this.m_objViewer.m_txtPatType.Tag = objreg.m_strPayType.m_strPayTypeID;

            this.m_objViewer.m_txtDept.Text = objreg.m_objDiagDept.strDeptName.Trim();
            this.m_objViewer.m_txtDept.Tag = objreg.m_objDiagDept.strDeptID;
            clsRegister.m_strRegisterType.m_strRegisterTypeName = this.m_objViewer.m_txtRegType.Text = objreg.m_strRegisterType.m_strRegisterTypeName.Trim();
            this.m_objViewer.m_txtRegType.Tag = objreg.m_strRegisterType.m_strRegisterTypeID;
            this.m_objViewer.m_txtDoc.Text = objreg.m_objDiagDoctor.strFirstName.Trim();
            this.m_objViewer.m_txtDoc.Tag = objreg.m_objDiagDoctor.strEmpID;

            this.m_objViewer.m_lbStart.Text = objreg.m_clsOPDoctorPlanVO.m_strStartTime;
            this.m_objViewer.m_lbEnd.Text = objreg.m_clsOPDoctorPlanVO.m_strEndTime;
            this.m_objViewer.m_lbRoom.Text = objreg.m_clsOPDoctorPlanVO.m_strOPAddress.Trim();
        }
        #endregion

        #region 填充明细
        public void m_FillDetail(string strRegister)
        {
            System.Data.DataTable dtRegisterDetail = new System.Data.DataTable();
            clsDomain.m_lngQulRegDetail(strRegister, out dtRegisterDetail);
            for (int i = 0; i < this.m_objViewer.m_lsvRegDetail.Items.Count; i++)
            {
                for (int i1 = 0; i1 < dtRegisterDetail.Rows.Count; i1++)
                {
                    if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[1].Text.Trim() == dtRegisterDetail.Rows[i1][1].ToString().Trim())
                    {
                        this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text = dtRegisterDetail.Rows[i1][3].ToString().Trim();
                        this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text = dtRegisterDetail.Rows[i1][4].ToString().Trim();
                        break;
                    }
                    else
                    {
                        this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text = "0";
                        this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[4].Text = "0";
                    }
                }
                if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim() == "工本费")
                {
                    if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text == "0")
                    {
                        this.m_objViewer.m_chkNeedNotfalill.Checked = true;
                    }
                    else
                    {
                        this.m_objViewer.m_chkNeedNotfalill.Checked = false;
                    }
                }
                if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[2].Text.Trim() == "磁卡费")
                {
                    if (this.m_objViewer.m_lsvRegDetail.Items[i].SubItems[3].Text == "0")
                    {
                        this.m_objViewer.m_chkNeedNotCard.Checked = true;
                    }
                    else
                    {
                        this.m_objViewer.m_chkNeedNotCard.Checked = false;
                    }
                }
            }
        }
        #endregion

        #region 获取挂号有效天数
        /// <summary>
        /// 获取挂号有效天数
        /// </summary>
        private string AvailDays = "一";
        /// <summary>
        /// 获取挂号有效天数
        /// </summary>
        public void m_mthGetAvailDays()
        {
            clsDcl_DoctorWorkstation objDoctor = new clsDcl_DoctorWorkstation();
            DataTable dt;
            long ret = objDoctor.m_lngGetWSParm("0058", out dt);		//0058 挂号有效天数

            if (ret > 0 && dt.Rows.Count > 0)
            {
                string[] bs = new string[10] { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

                AvailDays = bs[Convert.ToInt32(dt.Rows[0]["SETSTATUS_INT"]) - 1];
            }
        }
        #endregion
    }

}
