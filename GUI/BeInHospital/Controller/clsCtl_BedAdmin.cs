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
    /// 床位管理——界面控制层
    /// </summary>
    public class clsCtl_BedAdmin : com.digitalwave.GUI_Base.clsController_Base
    {
        #region 变量
        clsDcl_BIHTransfer m_objManage = null;
        public string m_strOperatorID = "";
        public string m_strOperatorName = "";
        /// <summary>
        /// 当前病区所属部门ID
        /// </summary>
        private string m_strDeptID = "";
        /// <summary>
        /// 当前病区ID
        /// </summary>
        internal string m_strAreaID = "";
        /// <summary>
        /// 病区床位总数
        /// </summary>
        int m_intBedCount = 0;
        /// <summary>
        ///  病区空床数
        /// </summary>
        int m_intBedEmptyCount = 0;
        /// <summary>
        /// 是否医保病人
        /// </summary>
        bool p_blnPretect;
        /// <summary>
        /// 病人门诊未结处方费用时控制出院结算与医嘱录入(医嘱录入1、2状态都为提示选择)0-关闭;1-提示选择，2-卡住
        /// </summary>
        internal int m_intParm1068 = 0;
        private string m_strRegister = "";
        private string m_stringTargetBedID = "";
        /// <summary>
        /// 出生时期转换年龄
        /// </summary>
        clsBrithdayToAge m_objAge;
        internal com.digitalwave.iCare.gui.Systempower.clsSystemPower_base objsystempower;
        #endregion

        #region 构造函数
        public clsCtl_BedAdmin()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            m_objManage = new clsDcl_BIHTransfer();
            m_objAge = new clsBrithdayToAge();
        }
        #endregion

        #region 设置窗体对象
        com.digitalwave.iCare.gui.HIS.frmBedAdmin m_objViewer;
        /// <summary>
        /// 设置窗体对象
        /// </summary>
        /// <param name="frmMDI_Child_Base_in"></param>
        public override void Set_GUI_Apperance(com.digitalwave.GUI_Base.frmMDI_Child_Base frmMDI_Child_Base_in)
        {
            base.Set_GUI_Apperance(frmMDI_Child_Base_in);
            m_objViewer = (frmBedAdmin)frmMDI_Child_Base_in;
        }
        #endregion

        #region 初始化设置
        /// <summary>
        /// 初始化设置
        /// </summary>
        public void m_mthInit()
        {
            m_strOperatorID = m_objViewer.LoginInfo.m_strEmpID;
            m_strOperatorName = m_objViewer.LoginInfo.m_strEmpName;
            m_objViewer.m_cmbView.SelectedIndex = 0;

            string setStatus;
            clsDclPrepayQuery objDomain = new clsDclPrepayQuery();
            //查找配置表，是否允许出院
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

        #region 获取病区列表
        /// <summary>
        /// 获取病区列表
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

        #region 获取当前选中病区床位信息
        /// <summary>
        /// 获取当前选中病区床位信息
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

        #region 加载当前选中病区床位信息
        /// <summary>
        /// 加载当前选中病区床位信息
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
                MessageBox.Show("获取床位信息失败！！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region 填充ListViewItemm
        /// <summary>
        /// 填充ListViewItemm
        /// </summary>
        /// <param name="lviTemp">ListViewItem</param>
        /// <param name="bedManageVO">床位信息VO</param>
        private void m_mthFillItme(ListViewItem lviTemp, clsBedManageVO bedManageVO)
        {
            lviTemp.ToolTipText = " 床　　号：" + bedManageVO.m_strCODE_CHR + "\r\n";
            lviTemp.SubItems[1].Text = bedManageVO.m_strCODE_CHR;
            lviTemp.SubItems[13].Text = bedManageVO.m_strITEMNAME_VCHR + " " + bedManageVO.m_strRATE_MNY + "(元)";
            #region 病人信息
            if (bedManageVO.m_strSTATUS_INT == "2" || bedManageVO.m_strSTATUS_INT == "6") //占床
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
                //判断是否是医保病人
                if (bedManageVO.m_strINTERNALFLAG_INT == "2")
                {
                    p_blnPretect = true;
                }

                //lviTemp.ImageIndex = intDisplayImageIndex(bedManageVO.m_strSTATE_INT, bedManageVO.m_strSEX_CHR, bedManageVO.m_strMAINDOC, bedManageVO.m_strICD10DIAGTEXT_VCHR, p_blnPretect, bedManageVO.m_strDIAGNOSEID_CHR);
                lviTemp.ImageIndex = intDisplayImageIndex(bedManageVO.m_strSTATE_INT, bedManageVO.m_strSEX_CHR, bedManageVO.m_strNURSECATE);

                lviTemp.ToolTipText += " 住  院  号：" + bedManageVO.m_strINPATIENTID_CHR + "\r\n" +
            " 病人姓名：" + bedManageVO.m_strNAME_VCHR + m_intPatientStatus(bedManageVO.m_strPSTATUS_INT) + "\r\n" +
            " 病人性别：" + bedManageVO.m_strSEX_CHR + "\r\n" +
            " 病人年龄：" + m_objAge.m_strGetAge(bedManageVO.m_strBIRTH_DAT) + "\r\n" +
            " 病情状态：" + strGetState(bedManageVO.m_strSTATE_INT) + "\r\n" +
            " 主治医生：" + bedManageVO.m_strMAINDOC + "\r\n" +
            " 入院诊断：" + bedManageVO.m_strICD10DIAGTEXT_VCHR + "\r\n" +
           " 入院时间：" + bedManageVO.m_strINPATIENT_DAT + "\r\n" +
            " 费用类别：" + bedManageVO.m_strPAYTYPENAME_VCHR + "\r\n" +
            " 护理级别：" + bedManageVO.m_strNURSECATE + "\r\n" +
            " 饮食类型：" + bedManageVO.m_strEATDICCATE + "\r\n";
            }
            else
            {
                if (bedManageVO.m_strSTATUS_INT == "4") //包床
                {
                    lviTemp.Text += "\n(" + bedManageVO.m_strWRAPBED + "包床)";
                    lviTemp.ToolTipText += " 病床状态: 包床\r\n";
                }
                else //空床
                {
                    //lviTemp.Text += "\n空床";
                    lviTemp.ToolTipText += " 病床状态: 空床\r\n";
                    m_intBedEmptyCount++;
                }
                lviTemp.ImageIndex = 0;
                lviTemp.ToolTipText += " 病床性别: " + bedManageVO.m_strSEXNAME + "\r\n" +
                    " 病床性质: " + bedManageVO.m_strCATEGORYNAME + "\r\n";
            }
            #endregion
            lviTemp.ToolTipText += " 床  位  费：" + bedManageVO.m_strITEMNAME_VCHR + " " + bedManageVO.m_strRATE_MNY + "(元)\r\n" +
            " 空  调  费：" + bedManageVO.m_strAIRCHARGEITEM + " " + bedManageVO.m_strAIRRATE_MNY + "(元)\r\n";
            lviTemp.Tag = bedManageVO;
        }
        #endregion

        #region 设置显示图标
        /// <summary>
        /// 确定显示图片
        /// </summary>
        /// <param name="BedState">//当前状态：{1空床、2占床、3预约占床、4包房占床}</param>
        /// <param name="Sex">性别</param>
        /// <param name="p_strMainDoc">主治医生</param>
        ///  <param name="p_strICD10">入院诊断ICD10</param>
        ///  <param name="p_blnProtect">是否医保病人</param>
        ///  <param name="p_strProtect">入院诊断(医保)</param>
        /// <returns></returns>
        private int intDisplayImageIndex(string Status, string Sex, string p_strMainDoc, string p_strICD10, bool p_blnProtect, string p_strProtect)
        {
            //状态：普通	类型：男床	
            if (Status.Equals("3") && (Sex.Equals("女") || Sex.Equals("其它")))
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
            //状态：危	类型：女床	
            if (Status.Equals("1") && (Sex.Equals("女") || Sex.Equals("其它")))
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

            //状态：急	类型：不限
            if (Status.Equals("2") && (Sex.Equals("女") || Sex.Equals("其它")))
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

            //状态：普通	类型：男床
            if (Status.Equals("3") && Sex.Equals("男"))
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

            //状态：危	类型：女床	
            if (Status.Equals("1") && Sex.Equals("男"))
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

            //状态：急	类型：不限
            if (Status.Equals("2") && Sex.Equals("男"))
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

        #region 设置显示图标(new)
        /// <summary>
        /// 确定显示图片
        /// </summary>
        /// <param name="Status">//当前状态：{1空床、2占床、3预约占床、4包房占床}</param>
        /// <param name="Sex">性别</param>
        /// <param name="nurseCate">护理等级</param>
        /// <returns></returns>
        private int intDisplayImageIndex(string Status, string Sex, string nurseCate)
        {

            if (Status == "3")
            {
                if (Sex == "女")
                {
                    if (nurseCate.Contains("特级"))
                    {
                        return 24;
                    }
                    else if (nurseCate.Contains("三级"))
                    {
                        return 21;
                    }
                    else if (nurseCate.Contains("二级"))
                    {
                        return 18;
                    }
                    else if (nurseCate.Contains("一级"))
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
                    if (nurseCate.Contains("特级"))
                    {
                        return 9;
                    }
                    else if (nurseCate.Contains("三级"))
                    {
                        return 6;
                    }
                    else if (nurseCate.Contains("二级"))
                    {
                        return 3;
                    }
                    else if (nurseCate.Contains("一级"))
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
                if (Sex == "女")
                {
                    if (nurseCate.Contains("特级"))
                    {
                        return 22;
                    }
                    else if (nurseCate.Contains("三级"))
                    {
                        return 19;
                    }
                    else if (nurseCate.Contains("二级"))
                    {
                        return 16;
                    }
                    else if (nurseCate.Contains("一级"))
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
                    if (nurseCate.Contains("特级"))
                    {
                        return 7;
                    }
                    else if (nurseCate.Contains("三级"))
                    {
                        return 4;
                    }
                    else if (nurseCate.Contains("二级"))
                    {
                        return 1;
                    }
                    else if (nurseCate.Contains("一级"))
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
                if (Sex == "女")
                {
                    if (nurseCate.Contains("特级"))
                    {
                        return 23;
                    }
                    else if (nurseCate.Contains("三级"))
                    {
                        return 20;
                    }
                    else if (nurseCate.Contains("二级"))
                    {
                        return 17;
                    }
                    else if (nurseCate.Contains("一级"))
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
                    if (nurseCate.Contains("特级"))
                    {
                        return 8;
                    }
                    else if (nurseCate.Contains("三级"))
                    {
                        return 5;
                    }
                    else if (nurseCate.Contains("二级"))
                    {
                        return 2;
                    }
                    else if (nurseCate.Contains("一级"))
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

        #region 标识转换
        /// <summary>
        /// 病情: 1-危、2-急、3-普通
        /// </summary>
        /// <param name="p_intState">标识ID</param>
        /// <returns></returns>
        private string strGetState(string p_strState)
        {
            switch (p_strState)
            {
                case "1":
                    return "危";
                case "2":
                    return "急";
                case "3":
                    return "普通";
                default:
                    return "";
            }
        }

        /// <summary>
        /// 病情	【String - Int】
        /// </summary>
        /// <param name="p_intState">病情 {1危、2急、3普通}</param>
        /// <returns></returns>
        private string m_intGetIntState(string p_strState)
        {
            switch (p_strState)
            {
                case "危":
                    return "1";
                case "急":
                    return "2";
                case "普通":
                    return "3";
                default:
                    return "2";
            }
        }
        /// <summary>
        /// 住院状态转换:0-未上床、1=已上床、2-预出院、3-实际出院、4-请假
        /// </summary>
        /// <param name="p_strFlag">标识ID</param>
        /// <returns></returns>
        private string m_intPatientStatus(string p_strFlag)
        {
            switch (p_strFlag)
            {
                case "2":
                    return "(预出院)";
                case "4":
                    return "(请假)";
                default:
                    return "";
            }
        }
        #endregion

        #region 拖放转床
        /// <summary>
        /// 拖放转床
        /// </summary>
        /// <param name="livSourceItem">原床位项</param>
        /// <param name="livTargetItem">目标床位项</param>
        public void m_cmdTransfer(ListViewItem livSourceItem, ListViewItem livTargetItem)
        {
            long lngReg = 0;
            clsBedManageVO souBedVO = (clsBedManageVO)livSourceItem.Tag;
            clsBedManageVO tarBedVO = (clsBedManageVO)livTargetItem.Tag;

            if (souBedVO.m_strSTATUS_INT == "1")
            {
                MessageBox.Show(m_objViewer, "空床不能转床操作!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (tarBedVO.m_strSTATUS_INT != "1" && tarBedVO.m_strSTATUS_INT != "6")
            {
                MessageBox.Show(m_objViewer, "只能转到空床!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (objsystempower.isHasRight("住院.进出转.转床"))
            {
                try
                {
                    lngReg = m_objManage.m_lngTurnBed(objTransferVO);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "！", "转床", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                MessageBox.Show(m_objViewer, "您沒有权限");
            }
            m_mthGetBidInfoByArearID();
        }
        /// <summary>
        /// 输入验证 {1、原床必须占床；2、目标床必须为空床；3、床的类别对应[性别]；}
        /// </summary>
        /// <param name="livSourceItem"></param>
        /// <param name="livTargetItem"></param>
        /// <returns></returns>
        private bool IsPassInputValidate(ListViewItem livSourceItem, ListViewItem livTargetItem)
        {
            //1、原床必须占床；
            if (livSourceItem.SubItems[1].Text.Trim() == "空床")
            {
                MessageBox.Show(m_objViewer, "空床不能转床操作!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //2、目标床必须为空床；
            if (livTargetItem.SubItems[1].Text.Trim() != "空床")
            {
                MessageBox.Show(m_objViewer, "只能转到空床!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            //3、床的类别对应[性别]；

            return true;
        }

        #region 控件赋值给Vo
        /// <summary>
        /// 控件赋值给Vo  {调转}
        /// </summary>
        /// <param name="objPatientVO">[clsT_Opr_Bih_Transfer_VO]</param>
        /// <param name="strSourceBedID">原病床流水号</param>
        /// <param name="strTargetBedID">目标病床流水号</param>
        /// <param name="strREGISTERID">患者入院登记流水号</param>
        private void ValueToVoForTransfer(out clsT_Opr_Bih_Transfer_VO objPatientVO, string strSourceBedID, string strTargetBedID, string strREGISTERID)
        {
            objPatientVO = new clsT_Opr_Bih_Transfer_VO();
            //源科室id
            objPatientVO.m_strSOURCEDEPTID_CHR = m_strDeptID;
            //源病区id
            objPatientVO.m_strSOURCEAREAID_CHR = m_strAreaID;
            //源病床id
            objPatientVO.m_strSOURCEBEDID_CHR = strSourceBedID;
            //目标科室id
            objPatientVO.m_strTARGETDEPTID_CHR = m_strDeptID;
            //目标病区id
            objPatientVO.m_strTARGETAREAID_CHR = m_strAreaID;
            //目标病床id
            objPatientVO.m_strTARGETBEDID_CHR = strTargetBedID;
            //操作类型{1=转科2=调床3=转科+调床4=出院唤回}			
            objPatientVO.m_intTYPE_INT = 2;
            //备注
            objPatientVO.m_strDES_VCHR = "";
            //操作人
            objPatientVO.m_strOPERATORID_CHR = m_strOperatorID;
            //入院登记流水号(200409010001)
            objPatientVO.m_strREGISTERID_CHR = strREGISTERID;
            //修改日期，操作日期
            objPatientVO.m_strMODIFY_DAT = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }
        #endregion

        #region 同步电子病历VO赋值
        private long SetVOValues(out iCareData.clsInDeptInfo objInDeptInfo)
        {
            objInDeptInfo = new iCareData.clsInDeptInfo();
            com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Transfer_VO objResult = null;
            long lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetTransferInfoByRegisterID(m_strRegister, out objResult);
            if (lngRes < 0)
            {
                return -1;
            }
            //住院信息
            com.digitalwave.iCare.ValueObject.clsT_Opr_Bih_Register_VO objInHosPitalInfo = null;
            //床位信息
            com.digitalwave.iCare.ValueObject.clsT_Bse_Bed_VO objBedInfo = null;
            //病区信息
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
            //进入病区时间
            if (objResult.m_strMODIFY_DAT != "" && objResult.m_strSOURCEAREAID_CHR != m_strAreaID)
            {
                objInDeptInfo.m_dtmBegin_Date_Area_Dept = Convert.ToDateTime(objResult.m_strMODIFY_DAT);
            }
            //上床时间
            objInDeptInfo.m_dtmBegin_Date_Bed_Room = System.DateTime.Now;
            //进入病房时间
            objInDeptInfo.m_dtmBegin_Date_Room_Area = System.DateTime.Now;
            objInDeptInfo.m_dtmInBedEndDate = Convert.ToDateTime("1900-1-1");
            //入院时间
            if (objInHosPitalInfo.m_strINPATIENT_DAT != "")
            {
                objInDeptInfo.m_dtmInPatientDate = Convert.ToDateTime(objInHosPitalInfo.m_strINPATIENT_DAT);
            }
            //修改时间
            objInDeptInfo.m_dtmModifyDate = System.DateTime.Now;
            //病区ID
            objInDeptInfo.m_strArea_ID = objAreaInfo.m_strSHORTNO_CHR;
            objInDeptInfo.m_strRoom_ID = new com.digitalwave.iCare.gui.HIS.clsDcl_BedAdmin().m_mlngGetEMRroomIDBYAREAID(objInDeptInfo.m_strArea_ID);
            objInDeptInfo.m_strBed_ID = new com.digitalwave.iCare.gui.HIS.clsDcl_BedAdmin().m_mlngGetEMRbedIDBYbedcode(objInDeptInfo.m_strRoom_ID, objBedInfo.m_strCODE_CHR);
            //病床ID
            //			objInDeptInfo.m_strBed_ID = objBedInfo.m_strCODE_CHR;
            //			string bed = objInDeptInfo.m_strBed_ID;
            //			Hashtable ht = this.getHt();
            //			string room = ht[bed].ToString();
            //科室ID
            com.digitalwave.iCare.ValueObject.clsT_BSE_DEPTDESC_VO objdept;
            lngRes = new com.digitalwave.iCare.gui.HIS.clsDcl_Register().m_lngGetAreaInfoByID(objAreaInfo.m_strPARENTID, out objdept);
            if (lngRes < 0)
            {
                return -1;
            }
            objInDeptInfo.m_strInDeptID = objdept.m_strSHORTNO_CHR;
            //病人ID
            objInDeptInfo.m_strInPatientID = objInHosPitalInfo.m_strINPATIENTID_CHR;
            //病房
            //			objInDeptInfo.m_strRoom_ID = room;
            return 1;
        }
        #endregion
        #endregion

        #region 撤消转出未被接收病人
        /// <summary>
        /// 撤消转出未被接收病人
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
                            MessageBox.Show("床位为必选项！", "撤消转出", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        MessageBox.Show("撤消成功！", "撤消转区", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadAreaTransferInfo();
                        m_mthGetBidInfoByArearID();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "撤消转区");
                }
            }
        }
        #endregion

        #region 增加床位
        /// <summary>
        /// 增加床位
        /// </summary>
        public void m_AddBed()
        {
            //没有病区则返回
            if (m_strAreaID.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "请选择您要加床的病区!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            frmAddBed objfrmAddBed = new frmAddBed(m_strAreaID);
            objfrmAddBed.m_txtDepName.Text = m_objViewer.m_lblDEPTNAME_VCHR.Text;
            objfrmAddBed.m_txtAreaName.Text = m_objViewer.m_lblPatientArea.Text;
            objfrmAddBed.ShowDialog();
            //向ListView中加载床位、患者信息
            if (objfrmAddBed.DialogResult == DialogResult.OK)
            {
                m_mthGetBidInfoByArearID();
            }
        }
        #endregion

        #region 编辑床位
        /// <summary>
        /// 编辑床位
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

        #region 根据床位ID删除床位
        /// <summary>
        /// 根据床位ID删除床位
        /// </summary>
        public void m_mthDeleteBedInfoByByBedID()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                try
                {
                    clsBedManageVO bedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                    string strMessage = "确认要删除病区“" + m_objViewer.m_lblPatientArea.Text.Trim() + "”的床位“" + bedVO.m_strCODE_CHR + "”吗?";
                    if (MessageBox.Show(strMessage, "删除床位", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    long lngRes = m_objManage.m_lngDeleteBedInfoByByBedID(bedVO.m_strBEDID_CHR);
                    if (lngRes > 0)
                    {
                        MessageBox.Show("删除成功！", "删除床位", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        m_objViewer.m_lsvBedInfo.SelectedItems[0].Remove();
                        m_mthFreshBedCount();
                    }
                    else
                    {
                        MessageBox.Show("删除失败！", "删除床位", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "！", "删除床位失败", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        #region 转入
        /// <summary>
        /// 转入
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

        #region 显示病人详细信息
        /// <summary>
        /// 显示病人详细信息
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

        #region 转病区
        /// <summary>
        /// 转病区
        /// </summary>
        public void m_TurnOut()
        {
            //没有病区则返回
            if (m_strAreaID.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "请选择病区!", "转病区", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //没有选中则返回
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "请选择要转床的病人!", "转病区", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            //没有入院登记流水号则返回 
            if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "没有患者信息!\n不能作转床操作!", "转病区", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //bool hasNotExcOrder;
            clsDclBihLeaHos leaHosDomain = new clsDclBihLeaHos();
            //检查是否存在尚为执行的医嘱
            long lngRes;
            int count;
            ArrayList arrCreator;

            lngRes = leaHosDomain.GetOrderNotExc(m_objBedVO.m_strREGISTERID_CHR, out count, out arrCreator);

            if (arrCreator.Count > 0)
            {

                string strDoctors = GetNewOrderDoctorList(arrCreator);
                MessageBox.Show(m_objViewer, "该病人有医生：" + strDoctors + " 新开的医嘱未提交。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (count > 0)
            {
                MessageBox.Show(m_objViewer, "该病人有尚未执行的医嘱。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region 转出和预出院时对包床信息进行处理
            //转出和预出院时对包床信息进行处理 2007.09.03 谢云杰 添加
            int intRowCount = 0;
            lngRes = m_objManage.m_lngGetWarpBedByRegID(m_objBedVO.m_strREGISTERID_CHR, ref intRowCount);//获取该病人的包床信息
            if (lngRes > 0)
            {
                if (intRowCount > 0)
                {
                    if (MessageBox.Show(m_objViewer, "该病人还存在包床信息。\r\n\r\n 点击[确定] 将删除该病人所有包床信息。\r\n\r\n点击[取消] 返回操作", "提示框", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        //删除所有包床
                        lngRes = m_objManage.m_lngUndoWarpBedByRegID(m_objBedVO.m_strREGISTERID_CHR, m_objViewer.LoginInfo.m_strEmpID);
                        if (lngRes < 0)
                        {
                            MessageBox.Show(m_objViewer, "撤消包床失败", "提示框", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
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
                MessageBox.Show(m_objViewer, "查询该病人包床信息失败。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        #region 出院
        /// <summary>
        /// 出院
        /// </summary>
        public void m_LeaveHospital()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "请选择要出院的患者!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "没有患者信息!\n操作失败!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            #region 转出和预出院时对包床信息进行处理
            //转出和预出院时对包床信息进行处理 2007.09.03 谢云杰 添加
            int intRowCount = 0;
            long lngRes = m_objManage.m_lngGetWarpBedByRegID(m_objBedVO.m_strREGISTERID_CHR, ref intRowCount);//获取该病人的包床信息
            if (lngRes > 0)
            {
                if (intRowCount > 0)
                {
                    if (MessageBox.Show(m_objViewer, "该病人还存在包床信息。\r\n\r\n 点击[确定] 将删除该病人所有包床信息。\r\n\r\n点击[取消] 不撤消包床，并继续操作", "提示框", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        //删除所有包床
                        lngRes = m_objManage.m_lngUndoWarpBedByRegID(m_objBedVO.m_strREGISTERID_CHR, m_objViewer.LoginInfo.m_strEmpID);
                        if (lngRes < 0)
                        {
                            MessageBox.Show(m_objViewer, "撤消包床失败", "提示框", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    m_mthGetBidInfoByArearID();
                }
            }
            else
            {
                MessageBox.Show(m_objViewer, "查询该病人包床信息失败。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion

            //bool hasNotExcOrder;
            clsDclBihLeaHos leaHosDomain = new clsDclBihLeaHos();
            //检查是否存在尚为执行的临嘱
            int count;
            ArrayList arrCreator;

            lngRes = leaHosDomain.GetOrderNotExc(m_objBedVO.m_strREGISTERID_CHR, out count, out arrCreator);

            if (arrCreator.Count > 0)
            {
                string strDoctors = GetNewOrderDoctorList(arrCreator);
                MessageBox.Show(m_objViewer, "该病人有医生：" + strDoctors + " 新开的医嘱未提交。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (count > 0)
            {
                MessageBox.Show(m_objViewer, "该病人有尚未执行的医嘱，不能出院。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region 直接出院
        /// <summary>
        /// 直接出院
        /// </summary>
        public void LeaveHospitalNoCheck()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "请选择要出院的患者!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "没有患者信息!\n操作失败!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //bool hasNotExcOrder;
            clsDclBihLeaHos leaHosDomain = new clsDclBihLeaHos();
            //检查是否存在尚为执行的临嘱
            long lngRes;
            // lngRes = leaHosDomain.GetOrderNotExc(m_objBedVO.m_strREGISTERID_CHR, 2, out hasNotExcOrder);
            int count;
            ArrayList arrCreator;

            lngRes = leaHosDomain.GetOrderNotExc(m_objBedVO.m_strREGISTERID_CHR, out count, out arrCreator);

            //if (arrCreator.Count > 0)
            //{
            //    MessageBox.Show(m_objViewer, "该病人有医生：" + arrCreator.ToString() + " 新开的医嘱未提交。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            //if (count > 0)
            //{
            //    MessageBox.Show(m_objViewer, "该病人有尚未执行的医嘱。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}            

            if (count > 0)
            {
                MessageBox.Show(m_objViewer, "该病人有尚未执行的临时医嘱，不能出院。", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult dlgRes = MessageBox.Show("确定办理　" + m_objBedVO.m_strNAME_VCHR + "　出院吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

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

        #region 请假
        /// <summary>
        /// 请假
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

        #region 撤销预出院/请假
        /// <summary>
        /// 撤销预出院/请假
        /// </summary>
        /// <returns></returns>
        public long m_lngUndoOutHospital()
        {
            long lngRes = 0;
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count > 0)
            {
                clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                if (m_objBedVO.m_strPSTATUS_INT == "2")  //撤销预出院
                {
                    if (MessageBox.Show("确认撤消预出院么？", "撤消预出院", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            //com.digitalwave.iCare.gui.HIS.clsDcl_Register objService = new clsDcl_Register();
                            //lngRes = objService.m_lngModifyBihRegisterPSTATUS_INTByRegisterID(m_objBedVO.m_strREGISTERID_CHR, 1, m_strOperatorID);
                            clsDclBihLeaHos objDomain = new clsDclBihLeaHos();
                            lngRes = objDomain.CancelPreLeaved(m_objBedVO.m_strREGISTERID_CHR, this.m_strOperatorID);
                            if (lngRes > 0)
                            {
                                MessageBox.Show("操作成功!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                m_objBedVO.m_strPSTATUS_INT = "1";
                                m_objBedVO.m_strSTATUS_INT = "2";
                                m_objBedVO.m_strSTATUSNAME = "占床";
                                m_objViewer.m_lsvBedInfo.SelectedItems[0].Text = m_objViewer.m_lsvBedInfo.SelectedItems[0].Text.Replace("(预出院)", "");
                                m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag = m_objBedVO;
                                m_objViewer.m_cmdUndoOut.Text = "撤销";
                                m_objViewer.m_cmdUndoOut.Enabled = false;
                                m_objViewer.cmdLeaveHospital.Enabled = true;

                                //刷新数据
                                m_mthGetBidInfoByArearID();
                                loadAreaTransferInfo();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "撤消预出院失败");
                        }
                    }
                }
                else if (m_objBedVO.m_strPSTATUS_INT == "4") //撤销请假
                {
                    if (MessageBox.Show("确认撤消请假么？", "撤消请假", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                            m_objBedVO.m_strSTATUSNAME = "占床";
                            m_objViewer.m_lsvBedInfo.SelectedItems[0].Text = m_objViewer.m_lsvBedInfo.SelectedItems[0].Text.Replace("(请假)", "");
                            m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag = m_objBedVO;
                            m_objViewer.m_cmdUndoOut.Text = "撤销";
                            m_objViewer.m_cmdUndoOut.Enabled = false;

                            //刷新数据
                            //m_mthGetBidInfoByArearID();
                            //loadAreaTransferInfo();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "撤消请假失败");
                        }
                    }
                }
            }
            return lngRes;
        }
        #endregion

        #region 载入病区转入转出信息
        /// <summary>
        /// 载入病区转入转出信息
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

        #region 载入转入未接收病人
        /// <summary>
        /// 载入转入未接收病人
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
                    listviewitem.SubItems.Add(Convert.ToDateTime(dr["HISINPATIENTDATE"]).ToString("yyyy年MM月dd日 HH时mm分"));

                    listviewitem.Tag = dr["REGISTERID_CHR"].ToString().Trim();
                    lsvItemArr[index] = listviewitem;
                    index++;
                }
                m_objViewer.m_lsvTurnInNA.Items.AddRange(lsvItemArr);
                p_dtbTurnInNA = null;
            }
        }
        #endregion

        #region 载入转入已接收病人
        /// <summary>
        /// 载入转入已接收病人
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

        #region 载入转出未接收病人
        /// <summary>
        /// 载入转出未接收病人
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

        #region 载入转出已接收病人
        /// <summary>
        /// 载入转出已接收病人
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

        #region 包床
        public void m_mthOccupyBed(string Bedid, string Registerid)
        {
            if (MessageBox.Show("确认包床么？", "床位管理", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    m_objManage.m_lngWarpBed(Registerid, Bedid, m_objViewer.LoginInfo.m_strEmpID);
                    this.m_mthGetBidInfoByArearID();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "包床失败！");
                }
            }
        }
        #endregion

        #region 撤消包床
        /// <summary>
        /// 撤消包床
        /// </summary>
        public void m_mthDelOccupBed()
        {
            if (MessageBox.Show("确认撤消包床么？", "床位管理", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                clsBedManageVO m_objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                try
                {
                    m_objManage.m_lngUndoWarpBed(m_objBedVO.m_strBEDID_CHR, m_objViewer.LoginInfo.m_strEmpID);
                    m_mthGetBidInfoByArearID();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "撤消包床失败");
                }
            }
        }
        #endregion

        #region	病人住院登记
        /// <summary>
        /// 病人住院登记
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
                // 控制在床位管理模块中，是否允许通过“F3”，直接调用住院登记模块:0-禁止 1-允许
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
                        MessageBox.Show(ex.Message + "！", "安排床位失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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

        #region 刷新床位数
        /// <summary>
        /// 刷新床位数
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

        #region 根据床位状态设置操作权限
        /// <summary>
        /// 根据床位状态设置操作权限
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
                    m_objViewer.m_cmdUndoOut.Text = "撤销";
                }
                else if (bedVO.m_strSTATUS_INT == "4")
                {
                    m_objViewer.cmdTurnIn.Enabled = false;
                    m_objViewer.cmdLeaveHospital.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Enabled = false;
                    m_objViewer.cmdTurnOut.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Text = "撤销";
                }

                else if (bedVO.m_strSTATUS_INT == "6")
                {
                    m_objViewer.cmdTurnIn.Enabled = true;
                    m_objViewer.cmdLeaveHospital.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Enabled = true;
                    m_objViewer.cmdTurnOut.Enabled = true;
                    m_objViewer.m_cmdUndoOut.Text = "撤销预出院";
                }

                else if (bedVO.m_strSTATUS_INT == "2")
                {
                    m_objViewer.cmdTurnOut.Enabled = true;
                    m_objViewer.cmdLeaveHospital.Enabled = true;
                    m_objViewer.m_cmdUndoOut.Enabled = false;
                    m_objViewer.cmdTurnIn.Enabled = false;

                    m_objViewer.m_cmdUndoOut.Enabled = false;
                    m_objViewer.m_cmdUndoOut.Text = "撤销";

                    if (bedVO.m_strPSTATUS_INT == "1")
                    {
                        m_objViewer.m_cmdHoliday.Enabled = true;
                    }
                    //else if (bedVO.m_strPSTATUS_INT == "2")
                    //{
                    //    m_objViewer.m_cmdHoliday.Enabled = true;
                    //    m_objViewer.m_cmdUndoOut.Enabled = true;
                    //    m_objViewer.m_cmdUndoOut.Text = "撤销预出院";
                    //}
                    else if (bedVO.m_strPSTATUS_INT == "4")
                    {
                        m_objViewer.m_cmdUndoOut.Enabled = true;
                        m_objViewer.m_cmdUndoOut.Text = "撤销请假";
                    }
                    else
                    {
                        m_objViewer.m_cmdHoliday.Enabled = false;
                        m_objViewer.m_cmdUndoOut.Text = "撤销";
                    }
                }
            }
        }


        #endregion

        #region 右键菜单设置
        /// <summary>
        /// 右键菜单设置
        /// </summary>
        public void m_mthSetComtext()
        {
            //没有选中床位
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count < 1)
            {
                //m_objViewer.BedAdmin.MenuItems[0].Visible = false; //编辑床位
                //m_objViewer.BedAdmin.MenuItems[2].Visible = false; //费用
                //m_objViewer.BedAdmin.MenuItems[3].Visible = false; //转入
                //m_objViewer.BedAdmin.MenuItems[4].Visible = false; //转出
                //m_objViewer.BedAdmin.MenuItems[5].Visible = false; //出院
                //m_objViewer.BedAdmin.MenuItems[6].Visible = false; //取消出院
                //m_objViewer.BedAdmin.MenuItems[7].Visible = true; //增加床位
                //m_objViewer.BedAdmin.MenuItems[8].Visible = false; //撤消包床
                //m_objViewer.BedAdmin.MenuItems[9].Visible = false; //删除床位
                //m_objViewer.BedAdmin.MenuItems[11].Visible = false; //请假
                //m_objViewer.BedAdmin.MenuItems[12].Visible = false; //撤消请假

                //m_objViewer.BedAdmin.MenuItems[1].MenuItems[0].Visible = false;
                //m_objViewer.BedAdmin.MenuItems[1].MenuItems[1].Visible = false;
                //m_objViewer.BedAdmin.MenuItems[1].MenuItems[2].Visible = false;
                //m_objViewer.BedAdmin.MenuItems[1].MenuItems[4].Visible = false;

                m_objViewer.BedAdmin.MenuItems[0].Enabled = false; //医嘱
                m_objViewer.BedAdmin.MenuItems[1].Enabled = false; //费用

                m_objViewer.BedAdmin.MenuItems[3].Enabled = false; //转入
                m_objViewer.BedAdmin.MenuItems[4].Enabled = false; //转出
                m_objViewer.BedAdmin.MenuItems[5].Enabled = false; //转床

                m_objViewer.BedAdmin.MenuItems[7].Enabled = false; //出院
                m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //取消出院
                m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //出院通知

                m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //请假
                m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //撤消请假
                m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //撤消包床

                m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //刷新

            }
            else //选中床位
            {
                clsBedManageVO bedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                //m_objViewer.BedAdmin.MenuItems[11].Visible = false; //请假
                //m_objViewer.BedAdmin.MenuItems[12].Visible = false; //撤消请假
                //空床
                if (bedVO.m_strSTATUS_INT.Equals("1"))
                {
                    //m_objViewer.BedAdmin.MenuItems[0].Visible = true; //入院登记
                    //m_objViewer.BedAdmin.MenuItems[2].Visible = false; //费用
                    //m_objViewer.BedAdmin.MenuItems[3].Visible = true; //转入
                    //m_objViewer.BedAdmin.MenuItems[4].Visible = false; //转出
                    //m_objViewer.BedAdmin.MenuItems[5].Visible = false; //出院
                    //m_objViewer.BedAdmin.MenuItems[6].Visible = false; //撤消出院
                    //m_objViewer.BedAdmin.MenuItems[7].Visible = false; //增加床位
                    //m_objViewer.BedAdmin.MenuItems[9].Visible = true; //删除床位

                    //m_objViewer.BedAdmin.MenuItems["menuItemOrder"].Enabled = false; //医嘱录入
                    m_objViewer.BedAdmin.MenuItems[0].Enabled = false; //医嘱
                    m_objViewer.BedAdmin.MenuItems[1].Enabled = false; //费用

                    m_objViewer.BedAdmin.MenuItems[3].Enabled = true; //转入
                    m_objViewer.BedAdmin.MenuItems[4].Enabled = false; //转出
                    m_objViewer.BedAdmin.MenuItems[5].Enabled = false; //转床

                    m_objViewer.BedAdmin.MenuItems[7].Enabled = false; //出院
                    m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //取消出院
                    m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //出院通知

                    m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //请假
                    m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //撤消请假
                    m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //撤消包床

                    m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //刷新
                }
                else //非空床
                {
                    //m_objViewer.BedAdmin.MenuItems[0].Visible = true; //入院登记
                    //m_objViewer.BedAdmin.MenuItems[2].Visible = false; //费用
                    //m_objViewer.BedAdmin.MenuItems[3].Visible = false; //转入
                    //m_objViewer.BedAdmin.MenuItems[4].Visible = true; //转出
                    //m_objViewer.BedAdmin.MenuItems[5].Visible = true; //出院

                    //m_objViewer.BedAdmin.MenuItems[7].Visible = false; //增加床位
                    //m_objViewer.BedAdmin.MenuItems[9].Visible = false; //删除床位

                    //m_objViewer.BedAdmin.MenuItems[1].MenuItems[1].Visible = true;
                    //m_objViewer.BedAdmin.MenuItems[1].MenuItems[2].Visible = true;
                    //m_objViewer.BedAdmin.MenuItems[1].MenuItems[4].Visible = true;



                    //if (bedVO.m_strPSTATUS_INT == "1" || bedVO.m_strPSTATUS_INT == "2")
                    if (bedVO.m_strPSTATUS_INT == "1")
                    {
                        //m_objViewer.BedAdmin.MenuItems[5].Visible = true; //出院
                        //m_objViewer.BedAdmin.MenuItems[6].Visible = false;  //撤消出院
                        //m_objViewer.BedAdmin.MenuItems[11].Visible = true;
                        m_objViewer.BedAdmin.MenuItems[0].Enabled = true; //医嘱
                        m_objViewer.BedAdmin.MenuItems[1].Enabled = true; //费用

                        m_objViewer.BedAdmin.MenuItems[3].Enabled = false; //转入
                        m_objViewer.BedAdmin.MenuItems[4].Enabled = true; //转出
                        m_objViewer.BedAdmin.MenuItems[5].Enabled = true; //转床

                        m_objViewer.BedAdmin.MenuItems[7].Enabled = true; //出院
                        m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //取消出院
                        m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //出院通知

                        m_objViewer.BedAdmin.MenuItems[11].Enabled = true; //请假
                        m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //撤消请假
                        m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //撤消包床

                        m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //刷新
                    }
                    else if (bedVO.m_strPSTATUS_INT == "4")
                    {
                        m_objViewer.BedAdmin.MenuItems[0].Enabled = true; //医嘱
                        m_objViewer.BedAdmin.MenuItems[1].Enabled = true; //费用

                        m_objViewer.BedAdmin.MenuItems[3].Enabled = false; //转入
                        m_objViewer.BedAdmin.MenuItems[4].Enabled = false; //转出
                        m_objViewer.BedAdmin.MenuItems[5].Enabled = false; //转床

                        m_objViewer.BedAdmin.MenuItems[7].Enabled = true; //出院
                        m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //取消出院
                        m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //出院通知

                        m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //请假
                        m_objViewer.BedAdmin.MenuItems[12].Enabled = true; //撤消请假
                        m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //撤消包床

                        m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //刷新
                    }
                    else if (bedVO.m_strPSTATUS_INT == "2")
                    {
                        m_objViewer.BedAdmin.MenuItems[0].Enabled = false; //医嘱
                        m_objViewer.BedAdmin.MenuItems[1].Enabled = true; //费用

                        m_objViewer.BedAdmin.MenuItems[3].Enabled = true; //转入
                        m_objViewer.BedAdmin.MenuItems[4].Enabled = true; //转出
                        m_objViewer.BedAdmin.MenuItems[5].Enabled = true; //转床

                        m_objViewer.BedAdmin.MenuItems[7].Enabled = false; //出院
                        m_objViewer.BedAdmin.MenuItems[8].Enabled = true; //取消出院
                        m_objViewer.BedAdmin.MenuItems[9].Enabled = true; //出院通知

                        m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //请假
                        m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //撤消请假
                        m_objViewer.BedAdmin.MenuItems[13].Enabled = false; //撤消包床

                        m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //刷新
                    }
                }
                //包床
                if (bedVO.m_strSTATUS_INT.Equals("4"))
                {
                    m_objViewer.BedAdmin.MenuItems[0].Enabled = false; //医嘱
                    m_objViewer.BedAdmin.MenuItems[1].Enabled = false; //费用

                    m_objViewer.BedAdmin.MenuItems[3].Enabled = false; //转入
                    m_objViewer.BedAdmin.MenuItems[4].Enabled = false; //转出
                    m_objViewer.BedAdmin.MenuItems[5].Enabled = false; //转床

                    m_objViewer.BedAdmin.MenuItems[7].Enabled = false; //出院
                    m_objViewer.BedAdmin.MenuItems[8].Enabled = false; //取消出院
                    m_objViewer.BedAdmin.MenuItems[9].Enabled = false; //出院通知

                    m_objViewer.BedAdmin.MenuItems[11].Enabled = false; //请假
                    m_objViewer.BedAdmin.MenuItems[12].Enabled = false; //撤消请假
                    m_objViewer.BedAdmin.MenuItems[13].Enabled = true; //撤消包床

                    m_objViewer.BedAdmin.MenuItems[15].Enabled = true; //刷新
                }
                //else
                //{
                //    m_objViewer.BedAdmin.MenuItems[7].Visible = false;
                //}
            }
        }
        #endregion

        #region 拖放安排床位
        /// <summary>
        /// 拖放安排床位
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
                if (m_objBeb.m_strSEXNAME != "不限" && strSex != m_objBeb.m_strSEXNAME)
                {
                    string strMessage = "确认将" + strSex + "性 " + m_objViewer.m_lsvTurnInNA.SelectedItems[0].SubItems[2].Text.Trim() +
                                    " 安排到 " + m_objBeb.m_strCODE_CHR + " 号" + m_objBeb.m_strSEXNAME + "床位么？";
                    if (MessageBox.Show(strMessage, "安排床位", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
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
                    MessageBox.Show(ex.Message, "安排床位失败", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                finally
                {
                    m_mthGetBidInfoByArearID();
                }
            }
        }
        #endregion

        #region 打印转区通知单
        /// <summary>
        /// 打印转区通知单
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
                    MessageBox.Show(ex.Message, "打印转区通知单失败");
                }
                finally
                {
                    m_objViewer.Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region 打印出院通知单 He Guiqiu 20060713
        /// <summary>
        /// 打印出院通知单
        /// </summary>
        public void PrintLeaveNotice()
        {
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "请选择要出院的患者!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            if (objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "没有患者信息!\n操作失败!", "提示框", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clsT_Opr_Bih_Leave_VO objLeaveVO;

            long lngReg = -1;
            clsDclBihLeaHos domainObj = new clsDclBihLeaHos();
            lngReg = domainObj.GetPreLeaveByRegisterID(objBedVO.m_strREGISTERID_CHR, out objLeaveVO);
            if (lngReg <= 0)
            {
                MessageBox.Show("取病人预出院信息时出错。", "提示框");
                return;
            }

            // 打印出院通知单
            frmPrintLeaveNotice printLeaveNotice = new frmPrintLeaveNotice(objBedVO, objLeaveVO);

            printLeaveNotice.ShowDialog();
        }
        #endregion

        #region 转床（菜单）
        internal void TurnBed()
        {
            //没有病区则返回
            if (m_strAreaID.Trim() == "")
            {
                MessageBox.Show(m_objViewer, "请选择病区!", "转床", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //没有选中则返回
            if (m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "请选择要转床的病人!", "转床", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO objBedVO = (clsBedManageVO)m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            //没有入院登记流水号则返回 
            if (objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(m_objViewer, "没有患者信息!\n不能作转床操作!", "转床", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                if (objsystempower.isHasRight("住院.进出转.转床"))
                {
                    try
                    {
                        m_objManage.m_lngTurnBed(objTransferVO);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message + "！", "转床", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show(m_objViewer, "您沒有权限");
                }
                m_mthGetBidInfoByArearID();
            }
        }
        #endregion

        #region 打腕带
        /// <summary>
        /// 打腕带
        /// </summary>
        internal void SpireLamella()
        {
            if (this.m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
            {
                MessageBox.Show(m_objViewer, "请选择患者。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            clsBedManageVO m_objBedVO = (clsBedManageVO)this.m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
            if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
            {
                MessageBox.Show(this.m_objViewer, "没有患者信息!\n操作失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        #region 欠费通知书
        /// <summary>
        /// 欠费通知书
        /// </summary>
        internal void PaymentNotice()
        {
            try
            {
                if (this.m_objViewer.m_lsvBedInfo.SelectedItems.Count <= 0)
                {
                    MessageBox.Show(m_objViewer, "请选择患者。", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                clsBedManageVO m_objBedVO = (clsBedManageVO)this.m_objViewer.m_lsvBedInfo.SelectedItems[0].Tag;
                if (m_objBedVO.m_strREGISTERID_CHR == string.Empty)
                {
                    MessageBox.Show(this.m_objViewer, "没有患者信息!\n操作失败!", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                clsPublic.PlayAvi("请稍候...");
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
                ds.Modify(string.Format("t_age.text = '{0}'", (new clsBrithdayToAge().m_strGetAge(Convert.ToDateTime(m_objBedVO.m_strBIRTH_DAT))).TrimEnd('岁')));
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

        #region 获取费用信息
        /// <summary>
        /// 获取费用信息
        /// </summary>
        /// <param name="regId"></param>
        /// <param name="totalMny">总费用</param>
        /// <param name="payMny">已支付</param>
        /// <param name="owingMny">欠费</param>
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


            // 1 在院; 3 登记ID
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

            // 可用预交金
            decimal Balanceprepaymoney = 0;
            svc3.m_lngGetPrepayByRegID(regId, 2, out dt);
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Balanceprepaymoney += clsPublic.ConvertObjToDecimal(dt.Rows[i]["balancetotal"]);
                }
                //预交金改为显示当前可用预交金
                vo.PrepayMoney = Balanceprepaymoney;
            }

            //获取总费用、待结、待清、直接收费、已清、结余、清帐日期、未结天数
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
                    //单项总费用
                    decimal d = clsPublic.Round(clsPublic.ConvertObjToDecimal(dt.Rows[i]["unitprice_dec"]) * clsPublic.ConvertObjToDecimal(dt.Rows[i]["amount_dec"]), 2);
                    //单项让利
                    decimal decDiffSum = clsPublic.Round(clsPublic.ConvertObjToDecimal(dt.Rows[i]["TOTALDIFFCOSTMONEY_DEC"]), 2);
                    //总费用
                    TotalFee += d + decDiffSum;
                    //费用状态 0 待确认 1 待结 2 待清 3 已清 4 直收
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

            // 总费用
            totalMny = TotalFee;
            // 已支付： 剩余预交金 + 已清 + 直收
            payMny = Balanceprepaymoney + CompleteClearFee + DirectorFee;
            // 欠费
            owingMny = totalMny - payMny;
        }
        #endregion
    }
}
